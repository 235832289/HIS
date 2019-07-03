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
    public partial class frmRptInstorageStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal DataTable m_dtProduct;
        private DataTable dtTemp;
        
        internal string[] m_strRoomidArr;

        internal string m_strTypeName = string.Empty;
        /// <summary>
        /// 是否药房使用，0否，1是
        /// </summary>
        internal bool m_blnForDrugStore = false;
        /// <summary>
        /// 药房对应的部门ID
        /// </summary>
        internal string m_strDeptId = string.Empty;
        /// <summary>
        /// 是否住院药房使用
        /// </summary>
        internal bool m_blnIsHospital = false;

        /// <summary>
        /// 查找出来的原始数据（用于做名称过滤操作）20081107
        /// </summary>
        internal DataTable m_dtbOriginalResult = null;
        public frmRptInstorageStat()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            objController = new clsCtl_RptInstorageStat();
            objController.Set_GUI_Apperance(this);
        }

        ///// <summary>
        ///// 药库使用
        ///// </summary>
        ///// <param name="p_strInstorageType"></param>
        //public void m_mthShowWithType(string p_strInstorageType)
        //{
        //    this.strInstorageType = p_strInstorageType.Trim();
        //    ((clsCtl_RptInstorageStat)this.objController).m_lngGetTypeNameByID(strInstorageType, out m_strTypeName);
        //    this.Text = this.Text + m_strTypeName;
        //    this.Show();
        //}

        /// <summary>
        /// 药库使用
        /// </summary>
        public void m_mthShow(string p_strStorageid)
        {
            m_strRoomidArr = p_strStorageid.Split('*');
            this.Text = "药库入库统计";
            this.Show();
        }

        ///// <summary>
        ///// 药房使用
        ///// </summary>
        //public void m_mthShowThis()
        //{
        //    this.strInstorageType = p_strInstorageType.Trim();
        //    m_blnForDrugStore = true;
        //    ((clsCtl_RptInstorageStat)this.objController).m_lngGetTypeNameByID(strInstorageType, out m_strTypeName);
        //    ((clsCtl_RptInstorageStat)this.objController).m_lngGetDeptIDByStoreID(strInstorageType, out m_strDeptId);
        //    this.Text = this.Text + m_strTypeName;
        //    this.Show();
        //}

        /// <summary>
        /// 药房使用
        /// </summary>
        public void m_mthShowThis(string p_strRoomid)
        {
            m_strRoomidArr = p_strRoomid.Split('*');
            string strStoreID = string.Empty;
            ((clsCtl_RptInstorageStat)this.objController).m_mthGetRoomid(out dtTemp);
            if (m_strRoomidArr.Length > 0)
            {
                strStoreID = m_strRoomidArr[0];
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
            //m_strRoomidArr = p_strRoomid.Split('*');
            this.Text = "药房入库统计";
            m_blnForDrugStore = true;
            ((clsCtl_RptInstorageStat)objController).m_lngCheckIsHospital(strStoreID, out m_blnIsHospital);
            this.Show();
        }

        private void frmRptInstorageStat_Load(object sender, EventArgs e)
        {
            this.m_dgvInstorage.AutoGenerateColumns = false;
            this.m_dtpSearchBeginDate.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            this.m_dtpSearchEndDate.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");

            ((clsCtl_RptInstorageStat)this.objController).m_mthInit();            
            ((clsCtl_RptInstorageStat)this.objController).m_mthFillMedType();

            if (m_blnForDrugStore)
            {
                m_gbBid.Visible = false;
                m_lblBidYear.Visible = false;
                m_txtBidYear.Visible = false;
                m_dgvInstorage.Columns.Remove("standard_int");
                m_dgvInstorage.Columns.Remove("standarddate");

                m_dgvInstorage.Columns.Remove("callprice_int");
                m_dgvInstorage.Columns.Remove("callsum");
                m_dgvInstorage.Columns.Remove("diffsum");
            }
            this.Text = "入库统计报表(" + txtStoreroom.Text + ")";
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_RptInstorageStat)this.objController).m_mthShowMedince(this.m_txtMedicineCode.Text.Trim());
            }
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStoreroom.Value))
            {
                MessageBox.Show(this, "请先选择需要统计的药房。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtStoreroom.Focus();
                return;
            }
            ((clsCtl_RptInstorageStat)this.objController).m_mthSearch();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.dw.RowCount > 0)
            {
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public clsPub = new com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public();
                clsPub.ChoosePrintDialog(this.dw, true);
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_RptInstorageStat)this.objController).m_mthShowManufacturer(this.txtProduct.Text);
                //this.m_cmdSearch.Focus();
            }
        }

        private void txtStoreroom_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");            
            ((clsCtl_RptInstorageStat)this.objController).m_mthFillMedType();
            this.Text = "入库统计报表(" + txtStoreroom.Text + ")";
        }

        private void m_txtMedicineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ((clsCtl_RptInstorageStat)this.objController).m_mthSearch();
        }

        private void txtTypecode_ItemSelectedOK(object s, EventArgs e)
        {
            if (txtProduct.Visible)
                txtProduct.Focus();
            else
                m_txtReceiveDept.Focus();            
        }

        private void m_cmdPreview_Click(object sender, EventArgs e)
        {
            //dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            //dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.dw);
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

            if (this.m_dgvInstorage.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_dgvInstorage);
            }
        }

        private void m_txtReceiveDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_RptInstorageStat)objController).m_mthShowVendor(m_txtReceiveDept.Text);
            }
        }

        private void m_txtReceiveDept_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtReceiveDept.Text.Trim()))
            {
                m_txtReceiveDept.Tag = "";
            }
        }

        private void m_txtReceiveDept_FocusNextControl(object sender, EventArgs e)
        {
            m_txtMedicineCode.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dw.FindRow(
            int index = this.m_dgvtxtMedName.DisplayIndex;
            this.m_dgvtxtMedName.DisplayIndex = ++index;
        }

        private void m_dgvInstorage_DragDrop(object sender, DragEventArgs e)
        {
          System.Windows.Forms.Control ctl=this.m_dgvInstorage.GetChildAtPoint(new Point(e.X,e.Y));
          if (ctl is System.Windows.Forms.DataGridTextBox)
              MessageBox.Show(ctl.Name);
          
        }

        private void m_dgvInstorage_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(this.m_dgvInstorage.Columns[e.ColumnIndex].DisplayIndex>0)
            --this.m_dgvInstorage.Columns[e.ColumnIndex].DisplayIndex;
        }

        private void m_dgvInstorage_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvInstorage.DataSource == null) return;
            DataTable dt = m_dtbOriginalResult.Copy();//this.m_dgvInstorage.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            //dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            //dt.AcceptChanges();
            
            if (!dt.Columns.Contains("SortRowNo"))
            {
                dt.Columns.Add("SortRowNo", typeof(long));
            }
            this.m_dgvInstorage.DataSource = dt;
            DataGridViewColumn dgvColumn = this.m_dgvInstorage.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvInstorage.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            m_mthResetDW(this.m_dgvInstorage.Columns[e.ColumnIndex].DataPropertyName, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvInstorage.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvInstorage.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_RptInstorageStat)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvInstorage.Sort(m_dgvInstorage.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);

            DataGridViewRow dgvr = null;
            for (int i2 = 1; i2 < m_dgvInstorage.Rows.Count - 1; i2++)
            {
                dgvr = m_dgvInstorage.Rows[i2];
                if (dgvr.Cells["m_dgvtxtMedid"].Value.ToString() == m_dgvInstorage["m_dgvtxtMedid", i2 - 1].Value.ToString())
                {
                    dgvr.Cells["m_dgvtxtMedName"].Value = "";
                    dgvr.Cells["m_dgvtxtSpec"].Value = "";
                    dgvr.Cells["m_dgvtxtUnit"].Value = "";
                    dgvr.Cells["m_dgvtxtProduct"].Value = "";
                }
            }
        }

        private void m_mthResetDW(string p_strColName,ListSortDirection p_lsdSort)
        {
            dw.Reset();
            dw.SetRedrawOff();
            string strDept = string.Empty;
            if (m_txtReceiveDept.Text.Trim() == "")
            {
                strDept = "全部";
            }
            else
            {
                strDept = m_txtReceiveDept.Text.Trim();
            }
            dw.Modify("t_hospitalname.text='" + ((clsCtl_RptInstorageStat)this.objController).m_objComInfo.m_strGetHospitalTitle() + "'");
            //dw.Modify("t_outdept.text='" + "(" + txtStoreroom.Text.Trim() + ")" + "'");
            dw.Modify("t_deptname.text='领用部门：" + strDept + "'");
            dw.Modify("t_time.text='统计日期：" + Convert.ToDateTime(m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss") + " --- " + Convert.ToDateTime(m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss") + "'");

            DataTable dt = ((DataTable)this.m_dgvInstorage.DataSource).Copy();
            if (dt.Columns.Contains("SortRowNo"))
            {
                dt.Columns.Remove("SortRowNo");
            }

            string strOutType = dt.Rows[0]["TYPENAME_VCHR"].ToString();
            string strTypeName = "";
            if (Convert.ToString(m_cboType.SelectedValue) == "")
                strOutType = "全部入库";

            if (string.IsNullOrEmpty(txtTypecode.Value))
            {
                strTypeName = "全部";
            }
            else
            {
                strTypeName = txtTypecode.Text;
            }
            //dw.Modify("t_title.text='入库统计报表" + "（" + strOutType + "）'");
            this.dw.Modify("t_title.text='(" + this.txtStoreroom.Text.Trim() + ")入库统计报表(" + strOutType + ")'");
            dw.Modify("t_type.text='药品分类：" + strTypeName + "'");

            string strTmpMedName = "";
            DataView dv = dt.DefaultView;
            if (p_lsdSort == ListSortDirection.Ascending)
            {
                dv.Sort = p_strColName;
            }
            else
            {
                dv.Sort = p_strColName + " desc";
            }
            dt = dv.ToTable();
            DataRow dr = null;
            for (int k = 0; dt != null && k < dt.Rows.Count; k++)
            {
                dr = dt.Rows[k];
                int row = dw.InsertRow(0);
                if (strTmpMedName == dr["MEDICINEID_CHR"].ToString())
                {
                    dw.SetItemString(row, "colmedname", "");
                    dw.SetItemString(row, "colmedspec", "");
                    dw.SetItemString(row, "colunit", "");
                    dw.SetItemString(row, "colpuduct", "");
                }
                else
                {
                    dw.SetItemString(row, "colmedname", dr["MEDICINENAME_VCH"].ToString());
                    strTmpMedName = dr["MEDICINEID_CHR"].ToString();

                    dw.SetItemString(row, "colmedspec", dr["MEDSPEC_VCHR"].ToString());
                    dw.SetItemString(row, "colunit", dr["unit"].ToString());
                    dw.SetItemString(row, "colpuduct", dr["PRODUCTORID_CHR"].ToString());
                }
                dw.SetItemString(row, "colmedid", dr["MEDICINEID_CHR"].ToString());                
                dw.SetItemDecimal(row, "colretailprice", Convert.ToDecimal(Convert.ToDouble(dr["retailprice"]).ToString("0.0000")));
                dw.SetItemDecimal(row, "colamount", Convert.ToDecimal(Convert.ToDouble(dr["AMOUNT"]).ToString("0.00")));
                dw.SetItemDecimal(row, "colmoney", Convert.ToDecimal(Convert.ToDouble(dr["UNITPRICE"]).ToString("0.0000")));
                dw.SetItemString(row, "colno", dr["INSTORAGEID_VCHR"].ToString());
                dw.SetItemString(row, "colindate", DateTime.Parse(dr["INSTORAGEDATE_DAT"].ToString()).ToString("yyyy-MM-dd"));// HH:mm:ss"));
            }
            dw.SetRedrawOn();
            dw.Refresh();
        }

        private void m_txtMedicineCode_TextChanged(object sender, EventArgs e)
        {
            if (m_txtMedicineCode.Text.Length == 0)
                m_txtMedicineCode.Tag = "";
        }

        private void m_rbtSingle_CheckedChanged(object sender, EventArgs e)
        {
            m_txtMedicineCode.Clear();
            m_txtMedicineCode.Tag = "";
            m_txtMedicineCode.Focus();
        }

        private void m_cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTypecode.Focus();
        }
    }
}