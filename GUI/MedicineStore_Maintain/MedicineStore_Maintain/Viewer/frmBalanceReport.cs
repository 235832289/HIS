using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;
//using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmBalanceReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal DataTable m_dtMedince;
        internal string[] m_strRoomidArr;
        /// <summary>
        /// 是否药房使用，0否，1是
        /// </summary>
        internal bool m_blnForDrugStore = false;
        /// <summary>
        /// 起始时间之前的帐务期
        /// </summary>
        internal string m_strForeAccount = string.Empty;
        /// <summary>
        /// 结束日期之前的帐务期
        /// </summary>
        internal string m_strBackAccount = string.Empty;
        /// <summary>
        /// 帐务期
        /// </summary>
        internal clsMS_AccountPeriodVO AccouVO;
        /// <summary>
        /// 上一期帐务期ID(如IsNullOrEmpty则表示本次为第一期)
        /// </summary>
        internal string m_strLastStorageID = string.Empty;
        public frmBalanceReport()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            objController = new clsCtl_BalanceReport();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 药库使用
        /// </summary>
        public void m_mthShow(string p_strStorageid)
        {            
            m_strRoomidArr = p_strStorageid.Split('*');
            this.Text = "药库盘点对账表";            
            this.Show();
        }

        /// <summary>
        /// 药房使用
        /// </summary>
        public void m_mthShowThis(string p_strStorageid)
        {
            m_blnForDrugStore = true;
            m_strRoomidArr = p_strStorageid.Split('*');
            DataTable dtTemp = null;
            ((clsCtl_BalanceReport)this.objController).m_lngGetRoomid(out dtTemp);
            if (m_strRoomidArr.Length > 0)
            {
                int iRowCount = dtTemp.Rows.Count;
                DataRow dr = null;
                for (int i = 0; i < iRowCount; i++)
                {
                    dr = dtTemp.Rows[i];
                    for (int j = 0; j < m_strRoomidArr.Length; j++)
                    {
                        if (m_strRoomidArr[j].ToString().Trim() == dr["medstoreid_chr"].ToString().Trim())
                        {
                            m_strRoomidArr[j] = dr["deptid_chr"].ToString();
                        }
                    }
                }
            }
            this.Text = "药房盘点对账表";
            this.Show();
        }

        private void frmBalanceReport_Load(object sender, EventArgs e)
        {
            ((clsCtl_BalanceReport)this.objController).m_mthInit();
            //((clsCtl_BalanceReport)this.objController).m_mthGetMedicine();
            ((clsCtl_BalanceReport)this.objController).m_mthFillMedType();
            m_bgwGetIDList.RunWorkerAsync();

            //取得上次结转时间，如果为空，则返回配置表5001药库初次帐务结转开始时间
            //DateTime dtBegin = DateTime.MinValue;
            //((clsCtl_BalanceReport)this.objController).m_lngGetLastBalanceTime(txtStoreroom.Value, out dtBegin);
            //if (dtBegin == DateTime.MinValue)
            //{
            //    string strTempTime = string.Empty;
            //    ((clsCtl_BalanceReport)this.objController).m_lngGetSysParm("5001", out strTempTime);    
            //    if(!DateTime.TryParse(strTempTime,out dtBegin))
            //    {
            //        dtBegin = DateTime.MinValue;
            //    }
            //}
            //this.m_dtpSearchBeginDate.Text = dtBegin.AddSeconds(1).ToString("yyyy年MM月dd日 HH时mm分ss秒");
            //this.m_dtpSearchEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");


            foreach (DataGridViewColumn dgvc in m_dgvBalance.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtMedince == null || m_dtMedince.Rows.Count == 0)
                {
                    ((clsCtl_BalanceReport)this.objController).m_mthGetMedicine();
                }
                ((clsCtl_BalanceReport)this.objController).m_mthShowMedince(this.m_txtMedicineCode.Text.Trim());
            }
        }

        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStoreroom.Value))
            {
                MessageBox.Show(this, "请先选择需要统计的库房。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtStoreroom.Focus();
                return;
            }
            if (Convert.ToString(this.txtStoreroom.Value) == string.Empty)
            {
                MessageBox.Show("必须选择库房", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtStoreroom.Focus();
                return;
            }
            if (m_txtAccountID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择帐务期", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_txtAccountID.Focus();
                return;
            }
            try
            {                
                this.Cursor = Cursors.WaitCursor;
                iCare.gui.HIS.clsPublic.PlayAvi("正在统计信息，请稍候...");
                ((clsCtl_BalanceReport)this.objController).m_mthSearch();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                iCare.gui.HIS.clsPublic.CloseAvi();
                this.Cursor = Cursors.Default;
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            if (this.m_dgvBalance.RowCount > 0)
            {
                ((clsCtl_BalanceReport)this.objController).m_mthPrint();               
            }
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtStoreroom_ItemSelectedOK(object s, EventArgs e)
        {
            m_bgwGetIDList.RunWorkerAsync();
            SendKeys.Send("{TAB}");
            ((clsCtl_BalanceReport)this.objController).m_mthFillMedType();
            m_txtAccountID.Text = "";
            m_lblAccountTime.Text = "";
        }

        private void m_txtMedicineCode_DoubleClick(object sender, EventArgs e)
        {
            //((clsCtl_BalanceReport)this.objController).m_mthSearch();
        }

        private void txtTypecode_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            
        }

        private void m_txtMedicineCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtMedicineCode.Text.Trim()))
            {
                m_txtMedicineCode.Tag = "";
            }
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            ((clsCtl_BalanceReport)objController).m_mthExportToExcel();
        }

        private void m_btnLocate_Click(object sender, EventArgs e)
        {
            com.digitalwave.iCare.gui.MedicineStore.frmQueryNavigator fqn = new com.digitalwave.iCare.gui.MedicineStore.frmQueryNavigator(m_txtMedicineCode.Text);
            fqn.m_dtbMedicinDict = this.m_dtMedince;
            fqn.OnLocateMedicine += new com.digitalwave.iCare.gui.MedicineStore.LocateMedicine(fqn_OnLocateMedicine);
            fqn.Location = new Point(510, 95);
            fqn.ShowInTaskbar = false;
            fqn.ShowDialog();
        }

        internal void fqn_OnLocateMedicine(string p_strMedicineName, short p_intDirection)
        {
            if (m_dgvBalance.Rows.Count == 0) return;
            if (p_strMedicineName == string.Empty) return;

            switch (p_intDirection)
            {
                case 1:
                    for (int i1 = 1; i1 < m_dgvBalance.Rows.Count; i1++)
                    {
                        if (m_dgvBalance["assistcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvBalance["medicinename_vchr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvBalance["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvBalance["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvBalance.Rows[i1].Selected = true;
                            m_dgvBalance.CurrentCell = m_dgvBalance.Rows[i1].Cells["medicinename_vchr"];
                            break;
                        }
                    }
                    break;
                case 2:
                    for (int i1 = m_dgvBalance.SelectedRows[0].Index - 1; i1 > 0; i1--)
                    {
                        if (m_dgvBalance["assistcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvBalance["medicinename_vchr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvBalance["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvBalance["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvBalance.Rows[i1].Selected = true;
                            m_dgvBalance.CurrentCell = m_dgvBalance.Rows[i1].Cells["medicinename_vchr"];
                            break;
                        }
                    }
                    break;
                case 3:
                    if (m_dgvBalance.SelectedRows[0].Index == m_dgvBalance.Rows.Count - 1) return;
                    for (int i1 = m_dgvBalance.SelectedRows[0].Index + 1; i1 < m_dgvBalance.Rows.Count; i1++)
                    {
                        if (m_dgvBalance["assistcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvBalance["medicinename_vchr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvBalance["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvBalance["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvBalance.Rows[i1].Selected = true;
                            m_dgvBalance.CurrentCell = m_dgvBalance.Rows[i1].Cells["medicinename_vchr"];
                            break;
                        }
                    }
                    break;
                case 4:
                    for (int i1 = m_dgvBalance.Rows.Count - 1; i1 > 0; i1--)
                    {
                        if (m_dgvBalance["assistcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvBalance["medicinename_vchr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvBalance["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvBalance["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvBalance.Rows[i1].Selected = true;
                            m_dgvBalance.CurrentCell = m_dgvBalance.Rows[i1].Cells["medicinename_vchr"];
                            break;
                        }
                    }
                    break;
            }
        }

        private void m_txtAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_lsvAccountIDList.Items.Count > 0)
                {
                    m_lsvAccountIDList.Visible = true;
                }
            }
        }

        private void m_cmdShowAccountDate_Click(object sender, EventArgs e)
        {
            if (m_lsvAccountIDList.Items.Count > 0)
            {
                m_lsvAccountIDList.Visible = true;
                m_lsvAccountIDList.Focus();
            }
        }

        private void m_lsvAccountIDList_Leave(object sender, EventArgs e)
        {
            m_lsvAccountIDList.Visible = false;
        }

        private void m_lsvAccountIDList_MouseUp(object sender, MouseEventArgs e)
        {
            int lsvItemIndex = -1;
            if (this.m_lsvAccountIDList.SelectedItems.Count > 0)
            {
                lsvItemIndex = this.m_lsvAccountIDList.SelectedItems[0].Index;
            }

            if (lsvItemIndex == -1)
            {
                return;
            }

            AccouVO = (clsMS_AccountPeriodVO)m_lsvAccountIDList.Items[lsvItemIndex].Tag;
            if (lsvItemIndex > 0)
            {
                clsMS_AccountPeriodVO lasAccouVO = new clsMS_AccountPeriodVO();
                lasAccouVO = (clsMS_AccountPeriodVO)m_lsvAccountIDList.Items[lsvItemIndex - 1].Tag;
                m_strLastStorageID = lasAccouVO.m_strACCOUNTID_CHR;
            }
            else
            {
                m_strLastStorageID = string.Empty;
            }
            m_txtAccountID.Text = AccouVO.m_strACCOUNTID_CHR;
            m_lblAccountTime.Text = AccouVO.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss") + " ~ " + AccouVO.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss");
            m_lblAccountTime.Visible = true;
            m_lsvAccountIDList.Visible = false;
        }

        private void m_bgwGetIDList_DoWork(object sender, DoWorkEventArgs e)
        {
            clsMS_AccountPeriodVO[] objAccArr = null;
            if (m_blnForDrugStore)
            {
                ((clsCtl_BalanceReport)objController).m_mthGetAccountIDListForDrugStore(out objAccArr);
            }
            else
            {
                ((clsCtl_BalanceReport)objController).m_mthGetAccountIDList(out objAccArr);
            }
            e.Result = objAccArr;
        }

        private void m_bgwGetIDList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            clsMS_AccountPeriodVO[] objAccArr = e.Result as clsMS_AccountPeriodVO[];
            ((clsCtl_BalanceReport)objController).m_mthSetAccountPeriodToList(objAccArr);
        }

        private void txtStoreroom_TextChanged(object sender, EventArgs e)
        {
            this.Text = "盘点对账表(" + txtStoreroom.Text + ")";
        }

        private void m_dgvBalance_Sorted(object sender, EventArgs e)
        {
            try
            {
                //20080613 暂时没法控制排序（按名称）
                //((clsCtl_BalanceReport)objController).m_mthDeleteTotalSumRow();
                //((clsCtl_BalanceReport)objController).m_mthAddTotalSumRow(m_dgvBalance.DataSource as DataTable);                
            }
            catch
            {
            }
        }

        private void m_dgvBalance_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvBalance.DataSource == null) return;
            DataTable dt = this.m_dgvBalance.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvBalance.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvBalance.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvBalance.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvBalance.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_BalanceReport)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvBalance.Sort(m_dgvBalance.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }

    }
}