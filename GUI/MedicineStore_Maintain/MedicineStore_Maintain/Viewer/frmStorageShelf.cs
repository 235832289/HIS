using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.MedicineStore;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 库存货架设置
    /// </summary>
    public partial class frmStorageShelf : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 药品基本信息表
        /// </summary>
        internal DataTable m_dtMedicineInfo = new DataTable();
        /// <summary>
        /// 货架
        /// </summary>
        internal DataGridViewComboBoxColumn colRack = new DataGridViewComboBoxColumn();
        /// <summary>
        /// 药库对应的货架
        /// </summary>
        internal DataTable m_dtbShelf = null;
        /// <summary>
        /// 药品基本信息
        /// </summary>
        internal clsValue_MedicineBse_VO m_objMedicineBase = new clsValue_MedicineBse_VO();
        internal DataTable m_dtbModify = new DataTable();
        
        /// <summary>
        /// 保存传入的药库id
        /// </summary>
        public string m_strStorageID = string.Empty;
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string m_strStorageName = string.Empty;
        #endregion

        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="m_strMedStordid">显示的药库id</param>
        public void m_mthSetShow(string m_strMedStordid)
        {
            m_strStorageID = m_strMedStordid;
            com.digitalwave.iCare.gui.MedicineStore_Maintain.clsDcl_InStorageStatisticsReport m_objDomain = new com.digitalwave.iCare.gui.MedicineStore_Maintain.clsDcl_InStorageStatisticsReport();
            m_objDomain.m_lngGetStoreRoomName(m_strStorageID, out m_strStorageName);
            this.Text += "(" + m_strStorageName + ")";
            this.Show();
        }
        #endregion

        #region 窗体初始化
        /// <summary>
        /// 构造方法
        /// </summary>
        public frmStorageShelf()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_StorageShelf();
            objController.Set_GUI_Apperance(this);
        }


        #endregion

        #region 初始化数据表
        /// <summary>
        /// 初始化DataGridView
        /// </summary>
        internal void m_mthInitDataTable()
        {

            #region 设置DataGridView的列属性

            m_dgvDrugStorage.Columns.Clear();

            colRack.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colRack.Name = "colSTORAGERACKID_CHR";
            colRack.HeaderText = "货架";
            m_dgvDrugStorage.Columns.Add(colRack);
            m_dgvDrugStorage.Columns[0].Width = 120;
            m_dgvDrugStorage.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[0].ReadOnly = false;
            m_dgvDrugStorage.Columns[0].Frozen = true;

            m_dgvDrugStorage.Columns.Add("colMedicineID", "药品ID");
            m_dgvDrugStorage.Columns[1].Width = 56;
            m_dgvDrugStorage.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[1].Visible = false;

            m_dgvDrugStorage.Columns.Add("colAssistCode", "代码");
            m_dgvDrugStorage.Columns[2].Width = 80;
            m_dgvDrugStorage.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[2].ReadOnly = true;

            m_dgvDrugStorage.Columns.Add("colMedicineName", "名称");
            m_dgvDrugStorage.Columns[3].Width = 320;
            m_dgvDrugStorage.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[3].ReadOnly = true;


            m_dgvDrugStorage.Columns.Add("colMedSpec", "规格");
            m_dgvDrugStorage.Columns[4].Width = 120;
            m_dgvDrugStorage.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[4].ReadOnly = true;

            m_dgvDrugStorage.Columns.Add("unit_chr", "单位");
            m_dgvDrugStorage.Columns[5].Width = 70;
            m_dgvDrugStorage.Columns[5].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[5].ReadOnly = true;

            m_dgvDrugStorage.Columns.Add("productorid_chr", "生产厂家");
            m_dgvDrugStorage.Columns[6].Width = 100;
            m_dgvDrugStorage.Columns[6].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[6].ReadOnly = true;

            m_dgvDrugStorage.Columns.Add("realgross_int", "实际库存");
            m_dgvDrugStorage.Columns[7].Width = 90;
            m_dgvDrugStorage.Columns[7].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[7].ReadOnly = true;

            m_dgvDrugStorage.Columns.Add("availablegross_sum", "可用库存");
            m_dgvDrugStorage.Columns[8].Width = 90;
            m_dgvDrugStorage.Columns[8].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[8].ReadOnly = true;

            m_dgvDrugStorage.Columns.Add("pycode_chr", "拼音码");
            m_dgvDrugStorage.Columns[9].Width = 90;
            m_dgvDrugStorage.Columns[9].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[9].Visible = false;

            m_dgvDrugStorage.Columns.Add("wbcode_chr", "五笔码");
            m_dgvDrugStorage.Columns[10].Width = 90;
            m_dgvDrugStorage.Columns[10].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[10].Visible = false;
            #endregion


            for (int i1 = 0; i1 < m_dgvDrugStorage.ColumnCount; i1++)
            {
                m_dgvDrugStorage.Columns[i1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            }

            #region 设置DataGride的“DataPropertyName”属性
            m_dgvDrugStorage.Columns[0].DataPropertyName = "STORAGERACKID_CHR";
            m_dgvDrugStorage.Columns[1].DataPropertyName = "MEDICINEID_CHR";
            m_dgvDrugStorage.Columns[2].DataPropertyName = "ASSISTCODE_CHR";
            m_dgvDrugStorage.Columns[3].DataPropertyName = "MEDICINENAME_VCHR";
            m_dgvDrugStorage.Columns[4].DataPropertyName = "MEDSPEC_VCHR";
            m_dgvDrugStorage.Columns[5].DataPropertyName = "opunit_vchr";
            m_dgvDrugStorage.Columns[6].DataPropertyName = "productorid_chr";
            m_dgvDrugStorage.Columns[7].DataPropertyName = "availagross_int";
            m_dgvDrugStorage.Columns[8].DataPropertyName = "realgross_int";
            m_dgvDrugStorage.Columns[9].DataPropertyName = "pycode_chr";
            m_dgvDrugStorage.Columns[10].DataPropertyName = "wbcode_chr";
           
            #endregion

        }
        #endregion        

        #region 窗体事件
        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_StorageShelf)objController).m_mthQuery();                
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "查询出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageShelf)objController).m_mthPrint();
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageShelf)objController).m_mthExportToExcel();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
            GC.Collect();
        }

        private void frmStorageSet_Load(object sender, EventArgs e)
        {
            m_objMedicineBase.m_strMedicineID = "";
            m_objMedicineBase.m_strAssistCode = "";
            m_objMedicineBase.m_strMedicineName = "";
            m_objMedicineBase.m_strMedSpec = "";

            this.m_dgvDrugStorage.AutoGenerateColumns = false;
            ((clsCtl_StorageShelf)objController).m_mthShowStorage();
            ((clsCtl_StorageShelf)objController).m_mthShowMedicineType();
            ((clsCtl_StorageShelf)objController).m_mthGetStorageShelfInfo(out m_dtbShelf);
            ((clsCtl_StorageShelf)objController).m_mthBindStorageShelf();
                      
            m_mthInitDataTable();
        }

        private void m_cboStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_StorageShelf)objController).m_mthShowMedicineType();
        }

        private void m_dgvDrugStorage_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_dtMedicineInfo == null || m_dtMedicineInfo.Rows.Count == 0)
            {
                ((clsCtl_StorageShelf)objController).m_lngGetBaseMedicine(m_strStorageID, out  m_dtMedicineInfo);
            }
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_StorageShelf)objController).m_mthShowQueryMedicineForm(this.m_txtMedicineCode.Text, m_dtMedicineInfo);
            }
        }
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_dgvDrugStorage.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            //保存货架
            if (((clsCtl_StorageShelf)objController).m_lngSaveStorageShelf(m_dtbModify) > 0)
            {
                m_btnQuery.PerformClick();
                m_dtbModify.Clear();
            }            
        }

        private void m_dgvDrugStorage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            DataRow m_rowAmount = ((DataRowView)(m_dgvDrugStorage.CurrentCell.OwningRow.DataBoundItem)).Row;
            if (m_dtbModify.Rows.Contains(m_rowAmount["seriesid_int"]))
            {
                m_dtbModify.Rows.Remove(m_dtbModify.Rows.Find(m_rowAmount["seriesid_int"]));
            }
            m_dtbModify.Rows.Add(m_rowAmount.ItemArray);
        }

        private void m_dgvDrugStorage_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "出错！";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "出错！";

                e.ThrowException = false;
            }
        }

        private void m_dgvDrugStorage_Sorted(object sender, EventArgs e)
        {
           
        }
              
        private void m_dgvDrugStorage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void m_dgvDrugStorage_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void m_dgvDrugStorage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        #endregion

        private void m_ckbStop_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_StorageShelf)objController).m_mthFilterShow();
        }

        private void m_ckbNoQuality_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_StorageShelf)objController).m_mthFilterShow();
        }

        private void m_btnLocate_Click(object sender, EventArgs e)
        {
            frmQueryNavigator fqn = new frmQueryNavigator(m_txtMedicineCode.Text);
            fqn.m_dtbMedicinDict = this.m_dtMedicineInfo;
            fqn.OnLocateMedicine += new LocateMedicine(fqn_OnLocateMedicine);
            fqn.Location = new Point(491, 100);
            fqn.ShowInTaskbar = false;
            fqn.Show();
        }

        /// <summary>
        /// 定位药品
        /// </summary>
        /// <param name="p_strMedicineName"></param>
        /// <param name="p_intDirection"></param>
        private void fqn_OnLocateMedicine(string p_strMedicineName, short p_intDirection)
        {
            if (m_dgvDrugStorage.Rows.Count == 0) return;
            if (p_strMedicineName == string.Empty) return;

            switch (p_intDirection)
            {
                case 1:
                    for (int i1 = 1; i1 < m_dgvDrugStorage.Rows.Count; i1++)
                    {
                        if (m_dgvDrugStorage["colAssistCode", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvDrugStorage["colMedicineName", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvDrugStorage.Rows[i1].Selected = true;
                            m_dgvDrugStorage.CurrentCell = m_dgvDrugStorage.Rows[i1].Cells["colMedicineName"];
                            break;
                        }
                    }
                    break;
                case 2:
                    for (int i1 = m_dgvDrugStorage.SelectedRows[0].Index - 1; i1 > 0; i1--)
                    {
                        if (m_dgvDrugStorage["colAssistCode", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvDrugStorage["colMedicineName", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvDrugStorage.Rows[i1].Selected = true;
                            m_dgvDrugStorage.CurrentCell = m_dgvDrugStorage.Rows[i1].Cells["colMedicineName"];
                            break;
                        }
                    }
                    break;
                case 3:
                    if (m_dgvDrugStorage.SelectedRows[0].Index == m_dgvDrugStorage.Rows.Count - 1) return;
                    for (int i1 = m_dgvDrugStorage.SelectedRows[0].Index + 1; i1 < m_dgvDrugStorage.Rows.Count; i1++)
                    {
                        if (m_dgvDrugStorage["colAssistCode", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvDrugStorage["colMedicineName", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvDrugStorage.Rows[i1].Selected = true;
                            m_dgvDrugStorage.CurrentCell = m_dgvDrugStorage.Rows[i1].Cells["colMedicineName"];
                            break;
                        }
                    }
                    break;
                case 4:
                    for (int i1 = m_dgvDrugStorage.Rows.Count - 1; i1 > 0; i1--)
                    {
                        if (m_dgvDrugStorage["colAssistCode", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvDrugStorage["colMedicineName", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvDrugStorage.Rows[i1].Selected = true;
                            m_dgvDrugStorage.CurrentCell = m_dgvDrugStorage.Rows[i1].Cells["colMedicineName"];
                            break;
                        }
                    }
                    break;
            }
        }
    }
}