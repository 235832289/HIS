using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 新药通知单
    /// </summary>
    public partial class frmNewPurchaseMedicine :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 药品基本信息表
        /// </summary>
        internal DataTable m_dtMedicineInfo = null;
        /// <summary>
        /// 药品基本信息
        /// </summary>
        internal clsValue_MedicineBse_VO m_objMedicineBase = new clsValue_MedicineBse_VO();
        /// <summary>
        /// 药库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品类型
        /// </summary>
        internal clsMS_MedicineType_VO[] m_objMPVO = null;
        #endregion 

        /// <summary>
        /// 新药通知单
        /// </summary>
        public frmNewPurchaseMedicine()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_NewPurchaseMedicine();
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

            m_dgvNewMedicine.Columns.Clear();

            m_dgvNewMedicine.Columns.Add("colMedicineID", "药品ID");
            m_dgvNewMedicine.Columns[0].Width = 56;
            m_dgvNewMedicine.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvNewMedicine.Columns[0].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            m_dgvNewMedicine.Columns[0].Visible = false;            

            m_dgvNewMedicine.Columns.Add("colStorageID", "药库ID");
            m_dgvNewMedicine.Columns[1].Width = 80;
            m_dgvNewMedicine.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvNewMedicine.Columns[1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;            
            m_dgvNewMedicine.Columns[1].Visible = false;

            m_dgvNewMedicine.Columns.Add("colAssistCode", "代码");
            m_dgvNewMedicine.Columns[2].Width = 90;
            m_dgvNewMedicine.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvNewMedicine.Columns[2].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;            

            m_dgvNewMedicine.Columns.Add("colMedicineName", "名称");
            m_dgvNewMedicine.Columns[3].Width = 180;
            m_dgvNewMedicine.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvNewMedicine.Columns[3].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            
            m_dgvNewMedicine.Columns.Add("colMedSpec", "规格");
            m_dgvNewMedicine.Columns[4].Width = 100;
            m_dgvNewMedicine.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvNewMedicine.Columns[4].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;            

            m_dgvNewMedicine.Columns.Add("colLotNo", "批号");
            m_dgvNewMedicine.Columns[5].Width = 90;
            m_dgvNewMedicine.Columns[5].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvNewMedicine.Columns[5].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            
            m_dgvNewMedicine.Columns.Add("colMedicineTypeName", "类型");
            m_dgvNewMedicine.Columns[6].Width = 60;
            m_dgvNewMedicine.Columns[6].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvNewMedicine.Columns[6].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;            

            m_dgvNewMedicine.Columns.Add("colOPUnit", "单位");
            m_dgvNewMedicine.Columns[7].Width = 45;
            m_dgvNewMedicine.Columns[7].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvNewMedicine.Columns[7].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvNewMedicine.Columns.Add("colWholesalePrice", "购入单价");
            m_dgvNewMedicine.Columns[8].Width = 88;
            m_dgvNewMedicine.Columns[8].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvNewMedicine.Columns[8].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvNewMedicine.Columns[8].DefaultCellStyle.Format = "0.0000";

            m_dgvNewMedicine.Columns.Add("colRetailPrice", "零售单价");
            m_dgvNewMedicine.Columns[9].Width = 88;
            m_dgvNewMedicine.Columns[9].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvNewMedicine.Columns[9].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvNewMedicine.Columns[9].DefaultCellStyle.Format = "0.0000";

            m_dgvNewMedicine.Columns.Add("colDate", "失效日期");
            m_dgvNewMedicine.Columns[10].Width = 92;
            m_dgvNewMedicine.Columns[10].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvNewMedicine.Columns[10].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvNewMedicine.Columns.Add("productorid_chr", "生产厂家");
            m_dgvNewMedicine.Columns[11].Width = 180;
            m_dgvNewMedicine.Columns[11].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvNewMedicine.Columns[11].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            #endregion


            for (int i1 = 0; i1 < m_dgvNewMedicine.ColumnCount - 1; i1++)
            {
                m_dgvNewMedicine.Columns[i1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                m_dgvNewMedicine.Columns[i1].ReadOnly = true;
            }

            #region 设置DataGridView的“DataPropertyName”属性
            m_dgvNewMedicine.Columns[0].DataPropertyName = "MEDICINEID_CHR";
            m_dgvNewMedicine.Columns[1].DataPropertyName = "storageid_chr";
            m_dgvNewMedicine.Columns[2].DataPropertyName = "ASSISTCODE_CHR";
            m_dgvNewMedicine.Columns[3].DataPropertyName = "MEDICINENAME_VCH";
            m_dgvNewMedicine.Columns[4].DataPropertyName = "MEDSPEC_VCHR";
            m_dgvNewMedicine.Columns[5].DataPropertyName = "LOTNO_VCHR";
            m_dgvNewMedicine.Columns[6].DataPropertyName = "MEDICINETYPENAME_VCHR";
            m_dgvNewMedicine.Columns[7].DataPropertyName = "unit_vchr";
            m_dgvNewMedicine.Columns[8].DataPropertyName = "WHOLESALEPRICE_INT";
            m_dgvNewMedicine.Columns[9].DataPropertyName = "RETAILPRICE_INT";
            m_dgvNewMedicine.Columns[10].DataPropertyName = "VALIDPERIOD_DAT";
            m_dgvNewMedicine.Columns[11].DataPropertyName = "productorid_chr";
            #endregion
        }
        #endregion

        #region 调用显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">药库ID</param>
        public void m_mthShowThis(string p_strStorageID)
        {
            m_strStorageID = p_strStorageID;
            this.Show();
        }
        #endregion

        #region 窗体事件
        private void cmdQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_NewPurchaseMedicine)objController).m_mthQuery();
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

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_NewPurchaseMedicine)objController).m_mthPrint();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmNewPurchaseMedicine_Load(object sender, EventArgs e)
        {
            m_objMedicineBase.m_strMedicineID = "";
            m_objMedicineBase.m_strAssistCode = "";
            m_objMedicineBase.m_strMedicineName = "";
            m_objMedicineBase.m_strMedSpec = "";

            m_dtpSearchBeginDate.Text = DateTime.Now.Date.ToString("yyyy年MM月dd日");
            m_dtpSearchEndDate.Text = DateTime.Now.Date.ToString("yyyy年MM月dd日");

            this.m_dgvNewMedicine.AutoGenerateColumns = false; 

            this.m_bgwGetData.RunWorkerAsync();
        }

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_NewPurchaseMedicine)objController).m_mthShowQueryMedicineForm(this.m_txtMedicineName.Text, m_dtMedicineInfo);
            }
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            if (m_objMPVO == null)
            {
                ((clsCtl_NewPurchaseMedicine)objController).m_mthGetMedicineType(m_strStorageID, out m_objMPVO);
            }

            if (m_dtMedicineInfo == null)
            {
                m_dtMedicineInfo = ((clsCtl_NewPurchaseMedicine)objController).m_mthGetMedicineInfo();
            }
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((clsCtl_NewPurchaseMedicine)objController).m_mthSetMedicineType(m_objMPVO);
        }

        private void m_txtProviderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_NewPurchaseMedicine)objController).m_mthShowVendor(m_txtProviderName.Text);
            }
        }
        #endregion
    }
}