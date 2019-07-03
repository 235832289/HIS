using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房限量设置及自动生成请领单
    /// </summary>
    public partial class frmMedicineLimit : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        /// <summary>
        /// 药房ID
        /// </summary>
        public string m_strStoreID = string.Empty;
        /// <summary>
        /// 药品类型
        /// </summary>
        public string m_strDrugType = string.Empty;
        /// <summary>
        /// 是否住院药房
        /// </summary>
        internal bool m_blnIsHospital = false;

        #region 窗体初始化
        /// <summary>
        /// 药房限量设置及自动生成请领单
        /// </summary>
        public frmMedicineLimit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineLimit();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 窗体事件
        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_MedicineLimit)objController).m_mthQuery();                
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
            //((clsCtl_MedicineLimit)objController).m_mthPrint();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMedicineLimit_Load(object sender, EventArgs e)
        {            
            this.m_dgvDrugLimit.AutoGenerateColumns = false;
            ((clsCtl_MedicineLimit)objController).m_mthShowDrugType();
            ((clsCtl_MedicineLimit)objController).m_mthGetMedicineInfo();
            m_btnQuery.PerformClick();            
        }

        #endregion

        #region 设置DataGridView的列属性
        internal void m_mthInitDataTable()
        {
            m_dgvDrugLimit.Columns.Clear();

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.Name = "IfCheck";
            column.HeaderText = "";
            column.TrueValue = "T";
            column.FalseValue = "F";
            m_dgvDrugLimit.Columns.Add(column);
            m_dgvDrugLimit.Columns[0].Width = 20;
            m_dgvDrugLimit.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugLimit.Columns[0].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            m_dgvDrugLimit.Columns[0].Frozen = true;
            m_dgvDrugLimit.Columns[0].Visible = false;

            m_dgvDrugLimit.Columns.Add("assistcode_chr", "药品代码");
            m_dgvDrugLimit.Columns[1].Width = 100;
            m_dgvDrugLimit.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;            

            m_dgvDrugLimit.Columns.Add("medicineid_chr", "药品ID");
            m_dgvDrugLimit.Columns[2].Width = 82;
            m_dgvDrugLimit.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;            
            m_dgvDrugLimit.Columns[2].Visible = false;

            m_dgvDrugLimit.Columns.Add("medicinename_vchr", "药品名称");
            m_dgvDrugLimit.Columns[3].Width = 274;
            m_dgvDrugLimit.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;            

            m_dgvDrugLimit.Columns.Add("medspec_vchr", "规格");
            m_dgvDrugLimit.Columns[4].Width = 130;
            m_dgvDrugLimit.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            m_dgvDrugLimit.Columns.Add("productorid_chr", "生产厂家");
            m_dgvDrugLimit.Columns[5].Width = 110;
            m_dgvDrugLimit.Columns[5].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            if (m_blnIsHospital)
            {
                m_dgvDrugLimit.Columns.Add("unit_chr", "住院单位");
            }
            else
            {
                m_dgvDrugLimit.Columns.Add("unit_chr", "门诊单位");
            }            
            m_dgvDrugLimit.Columns[6].Width = 78;
            m_dgvDrugLimit.Columns[6].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;            

            m_dgvDrugLimit.Columns.Add("realgross_int", "现有库存");
            m_dgvDrugLimit.Columns[7].Width = 100;
            m_dgvDrugLimit.Columns[7].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;            
            m_dgvDrugLimit.Columns[7].DefaultCellStyle.Format = "0.0000";

            m_dgvDrugLimit.Columns.Add("tiptoplimit_int", "最高限量");
            m_dgvDrugLimit.Columns[8].Width = 100;
            m_dgvDrugLimit.Columns[8].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;            
            m_dgvDrugLimit.Columns[8].DefaultCellStyle.Format = "0.0000";

            m_dgvDrugLimit.Columns.Add("neaplimit_int", "最低限量");
            m_dgvDrugLimit.Columns[9].Width = 100;
            m_dgvDrugLimit.Columns[9].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;            
            m_dgvDrugLimit.Columns[9].DefaultCellStyle.Format = "0.0000";

            for (int i1 = 0; i1 < m_dgvDrugLimit.ColumnCount - 1; i1++)
            {
                m_dgvDrugLimit.Columns[i1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                if (i1 == 0 || i1 == 8 || i1 == 9)
                {
                    m_dgvDrugLimit.Columns[i1].ReadOnly = false;
                }
                else
                {
                    m_dgvDrugLimit.Columns[i1].ReadOnly = true;
                }
            }

            m_dgvDrugLimit.Columns[0].DataPropertyName = "IfCheck";
            m_dgvDrugLimit.Columns[1].DataPropertyName = "assistcode_chr";
            m_dgvDrugLimit.Columns[2].DataPropertyName = "medicineid_chr";
            m_dgvDrugLimit.Columns[3].DataPropertyName = "medicinename_vchr";
            m_dgvDrugLimit.Columns[4].DataPropertyName = "medspec_vchr";
            m_dgvDrugLimit.Columns[5].DataPropertyName = "productorid_chr";
            m_dgvDrugLimit.Columns[6].DataPropertyName = "unit_chr";
            m_dgvDrugLimit.Columns[7].DataPropertyName = "realgross_int";
            m_dgvDrugLimit.Columns[8].DataPropertyName = "tiptoplimit_int";
            m_dgvDrugLimit.Columns[9].DataPropertyName = "neaplimit_int";
        }
        #endregion

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            //m_dgvDrugLimit.EndEdit();
            m_dgvDrugLimit.CurrentCell = null;
            //m_dgvDrugLimit.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            ((clsCtl_MedicineLimit)objController).m_mthSaveMedicine();
        }

        private void m_dgvDrugLimit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("抱歉！此处只能输入数字，请更正。", "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void m_dgvDrugLimit_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex != -1)
                m_dgvDrugLimit.BeginEdit(true);
        }

        private void m_dgvDrugLimit_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            //if(e.KeyChar == (char)13)
            //{
                int intCulumnIndex = m_dgvDrugLimit.CurrentCell.ColumnIndex;
                int intRowIndex = m_dgvDrugLimit.CurrentCell.RowIndex;
                if (intCulumnIndex == 8)
                {
                    m_dgvDrugLimit.CurrentCell = m_dgvDrugLimit.Rows[intRowIndex].Cells[9];
                    CancelJump = true;
                    return;
                }
                if (intCulumnIndex == 9 && intRowIndex != m_dgvDrugLimit.Rows.Count - 1)
                {
                    m_dgvDrugLimit.CurrentCell = m_dgvDrugLimit.Rows[intRowIndex + 1].Cells[8];
                    CancelJump = true;
                    return;
                }
                CancelJump = true; 
            //}
        }

        private void m_txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_MedicineLimit)objController).m_mthShowQueryMedicineForm(m_txtSearch.Text);
            }
        }

        private void m_txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtSearch.SelectAll();
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStoreID">药房ID</param>
        /// <param name="p_strDrugType">药品类型</param>
        public void m_mthShow(string p_strStoreID, string p_strDrugType)
        {
            m_strStoreID = p_strStoreID;
            m_strDrugType = p_strDrugType;
            clsMedStore_VO objReturnVo = clsPub.m_mthGetMedStoreNameByid(p_strStoreID);
            ((clsCtl_MedicineLimit)objController).m_lngCheckIsHospital(m_strStoreID, out m_blnIsHospital);
            this.Text += "(" + objReturnVo.m_strDeptName + ")";
            Show();            
        }
        /// <summary>
        /// 导出到Excle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtondataout_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimit)objController).m_mthExportExcle();
        }
    }
}