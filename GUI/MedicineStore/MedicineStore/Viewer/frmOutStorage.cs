using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品出库
    /// </summary>
    public partial class frmOutStorage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 药品出库主表数据
        /// </summary>
        internal DataTable m_dtbMainDataPage1 = null;
        /// <summary>
        /// 当前药品出库主表显示数据
        /// </summary>
        internal DataView m_dtvCurrentMainVienPage1 = null;
        /// <summary>
        /// 药品出库子表数据
        /// </summary>
        internal DataTable m_dtbSubDataPage1 = null;
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        /// <summary>
        /// 是否有药库管理员权限
        /// </summary>
        internal bool m_blnIsAdmin = false;
        /// <summary>
        /// 查询出来的金额
        /// </summary>
        internal DataTable m_dtbAllMoney = null;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false;
        /// <summary>
        /// 药品中的批号,有效期录入控制
        /// </summary>
        internal clsMS_MedicineTypeVisionmSet m_clsTypeVisVO;

        /// <summary>
        /// 是否广医三院模式，即出库类型可自定义
        /// </summary>
        internal bool m_blnIsGY3Y = false;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品出库
        /// </summary>
        private frmOutStorage()
        {
            InitializeComponent();

            m_dgvMainPage1.AutoGenerateColumns = false;
            m_dgvSubPage1.AutoGenerateColumns = false;

            m_dtpBeginDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpEndDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");
          

            //初始化出库类型,兼容其他医院
            this.m_cboOutStorageTypePage1.Item.Add("全部", "0");
            this.m_cboOutStorageTypePage1.Item.Add("领药出库", "1");
            this.m_cboOutStorageTypePage1.Item.Add("销售出库", "2");

            m_cboOutStorageTypePage1.SelectedIndex = 0;
            m_cboStatusPage1.SelectedIndex = 0;
           

            DataTable dtbDept = null;
            ((clsCtl_OutStorage)objController).m_mthGetExportDept(out dtbDept);
            m_txtAskDeptPage1.m_mthInitDeptData(dtbDept);

            m_mthSetControlHighLight();
            
         
        }

        /// <summary>
        /// 药品出库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmOutStorage(string p_strStorageID)
        {
            InitializeComponent();
            m_dgvMainPage1.AutoGenerateColumns = false;
            m_dgvSubPage1.AutoGenerateColumns = false;
            m_dtpBeginDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpEndDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_strStorageID = p_strStorageID;
            //初始化出库类型,兼容其他医院
            this.m_cboOutStorageTypePage1.Item.Add("全部", "0");
            this.m_cboOutStorageTypePage1.Item.Add("领药出库", "1");
            this.m_cboOutStorageTypePage1.Item.Add("销售出库", "2");

            m_cboOutStorageTypePage1.SelectedIndex = 0;
            m_cboStatusPage1.SelectedIndex = 0;


            DataTable dtbDept = null;
            ((clsCtl_OutStorage)objController).m_mthGetExportDept(out dtbDept);
            m_txtAskDeptPage1.m_mthInitDeptData(dtbDept);

            m_mthSetControlHighLight();
            ((clsCtl_OutStorage)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            ((clsCtl_OutStorage)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);

            m_mthGetMainData();
        }

        /// <summary>
        /// 药品出库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="m_strOutStorageType">出库类型</param>
        public frmOutStorage(string p_strStorageID, string m_strOutStorageType)            
        {
            InitializeComponent();

            m_blnIsGY3Y = true;

            m_dgvMainPage1.AutoGenerateColumns = false;
            m_dgvSubPage1.AutoGenerateColumns = false;

            m_dtpBeginDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpEndDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            m_cboStatusPage1.SelectedIndex = 0;


            DataTable dtbDept = null;
            ((clsCtl_OutStorage)objController).m_mthGetExportDept(out dtbDept);
            m_txtAskDeptPage1.m_mthInitDeptData(dtbDept);

            m_mthSetControlHighLight();

            m_strStorageID = p_strStorageID;
           
            ((clsCtl_OutStorage)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            ((clsCtl_OutStorage)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);

            m_mthGetMainData();
            
            this.m_cmdAddNewPage1.Click -= new EventHandler(m_cmdAddNewPage1_Click);
            this.m_cmdAddNewPage1.Click += new EventHandler(m_cmdNewAddNewPage1_Click);
            this.m_cboOutStorageTypePage1.Items.Clear();
            ((clsCtl_OutStorage)objController).m_mthGetImpExpTypeInfo(m_strOutStorageType);
        } 
        #endregion

        private void m_cmdNewAddNewPage1_Click(object sender, EventArgs e)
        {
            Point p = new Point(this.m_cmdAddNewPage1.Left, this.m_cmdAddNewPage1.Top + this.m_cmdAddNewPage1.Height);
            this.m_tmsShowNewMake.Show(this.m_cmdAddNewPage1, p);
        }
        #region 事件

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdAddNewPage1_Click(object sender, EventArgs e)
        {
            frmMedicineOut frmMO = new frmMedicineOut(m_strStorageID, 1, 1);
            frmMO.FormClosed += new FormClosedEventHandler(frmMO_FormClosed);
            frmMO.ShowDialog();
        }

        private void frmMO_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_mthGetMainData();
        }

        private void m_bgwGetData1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Collections.ArrayList arrPa = e.Argument as System.Collections.ArrayList;
            if(m_blnIsGY3Y)
            ((clsCtl_OutStorage)objController).m_mthGetMainData(arrPa[2].ToString(), Convert.ToDateTime(arrPa[0]), Convert.ToDateTime(arrPa[1]),
                arrPa[4].ToString(), arrPa[3].ToString(), arrPa[5].ToString(), Convert.ToInt16(arrPa[6]), out m_dtbMainDataPage1);
            else
            ((clsCtl_OutStorage)objController).m_mthGetMainData(arrPa[2].ToString(), Convert.ToDateTime(arrPa[0]), Convert.ToDateTime(arrPa[1]),
                arrPa[4].ToString(), arrPa[3].ToString(), arrPa[5].ToString(), out m_dtbMainDataPage1);


            if (m_dtbMedicinDict == null)
            {
                ((clsCtl_OutStorage)objController).m_mthGetMedicineInfo();
            }
        }

        private void m_bgwGetData1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_dtvCurrentMainVienPage1 = new DataView(m_dtbMainDataPage1);
            ((clsCtl_OutStorage)objController).m_mthFilterMainDataPage1();
        }

        private void m_txtMedicineNamePage1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_OutStorage)objController).m_mthShowQueryMedicineForm(m_txtMedicineNamePage1.Text);
            }
        }

        private void m_cboOutStorageTypePage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_OutStorage)objController).m_mthFilterMainDataPage1();
        }

        private void m_cboStatusPage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_OutStorage)objController).m_mthFilterMainDataPage1();
        }

        private void m_cmdModifyPage1_Click(object sender, EventArgs e)
        {
            clsMS_OutStorage_VO objMain = null;
            clsMS_OutStorageDetail_VO[] objDetail = null;
            ((clsCtl_OutStorage)objController).m_mthModifyPage1(out objMain, out objDetail);

            if (objMain == null)
            {
                return;
            }

            int intSelectedSubRow = 0;
            if (m_dgvSubPage1.SelectedRows != null && m_dgvSubPage1.SelectedRows.Count > 0)
            {
                intSelectedSubRow = m_dgvSubPage1.SelectedRows[0].Index;
            }
            frmMedicineOut frmMO = new frmMedicineOut(m_strStorageID, objMain.m_intOutStorageTYPE_INT, objMain.m_intFORMTYPE_INT, objMain, objDetail, intSelectedSubRow);
            frmMO.FormClosed +=new FormClosedEventHandler(frmMO_FormClosed);
            frmMO.ShowDialog();
        }

        private void m_cmdDeletePage1_Click(object sender, EventArgs e)
        {
            ((clsCtl_OutStorage)objController).m_mthDeleteOutStorage();
        }

        private void m_cmdCommitPage1_Click(object sender, EventArgs e)
        {
            m_cmdCommitPage1.Enabled = false;
            m_pnlWaiting.Visible = true;
            Application.DoEvents();

            DataRow[] drCommit = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_OutStorage)objController).m_mthCommitOutStorage();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                m_cmdCommitPage1.Enabled = true;
                m_pnlWaiting.Visible = false;
            }
        }

        private void m_cmdUnCommitPage1_Click(object sender, EventArgs e)
        {
            ((clsCtl_OutStorage)objController).m_mthUnCommitOutStorage();
        }

        private void m_dgvMainPage1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (m_dgvMainPage1.CurrentCell == null)
            {
                return;
            }

            if (m_dgvMainPage1.Rows[m_dgvMainPage1.CurrentCell.RowIndex].Cells[4].Value.ToString().Trim() == "即入即出")
            {
                m_cmdModifyPage1.Enabled = false;
                m_cmdInAccount.Enabled = false;
                m_cmdDeletePage1.Enabled = false;
                m_cmdCommitPage1.Enabled = false;
                m_cmdUnCommitPage1.Enabled = false;
            }
            else
            {
                m_cmdModifyPage1.Enabled = true;
                m_cmdInAccount.Enabled = true;
                m_cmdDeletePage1.Enabled = true;
                m_cmdCommitPage1.Enabled = true;
                m_cmdUnCommitPage1.Enabled = true;
            }
            DataRowView drvSelected = m_dtvCurrentMainVienPage1[m_dgvMainPage1.CurrentCell.RowIndex];
            if (drvSelected != null)
            {
                long lngSEQ = Convert.ToInt64(drvSelected["SERIESID_INT"]);
                ((clsCtl_OutStorage)objController).m_mthGetOutStorageDetail(lngSEQ, out m_dtbSubDataPage1);
                DataView dtvSub = new DataView(m_dtbSubDataPage1);
                m_dgvSubPage1.DataSource = dtvSub;
            }

            ((clsCtl_OutStorage)objController).m_mthGetAllSubMoney();
        }

        private void m_lblSelectAllPage1_Click(object sender, EventArgs e)
        {
            if (m_dgvMainPage1.Rows.Count > 0)
            {
                if (m_lblSelectAllPage1.Text == "全选")
                {
                    m_lblSelectAllPage1.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvMainPage1.Rows.Count; iRow++)
                    {
                        m_dgvMainPage1.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelectAllPage1.Text == "反选")
                {
                    m_lblSelectAllPage1.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvMainPage1.Rows.Count; iRow++)
                    {
                        m_dgvMainPage1.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }  
        }

        private void m_dgvSubPage1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvSubPage1.Rows.Count; iRow++)
            {
                m_dgvSubPage1.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvSubPage1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvSubPage1.Rows.Count; iRow++)
            {
                m_dgvSubPage1.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvMainPage1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModifyPage1_Click(null, null);
        }

        private void m_dgvSubPage1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModifyPage1_Click(null, null);
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            m_dtbAllMoney = null;
            m_mthGetMainData();
        }

        private void m_cmdInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_OutStorage)objController).m_mthInAccount();
        }
        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_OutStorage();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 设置活动控件背景高亮
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthSetControlHighLight(panel4, Color.Moccasin);
            objCtl.m_mthSelectAllText(panel4);

        }

        #region 异步获取主表内容
        /// <summary>
        /// 异步获取主表内容
        /// </summary>
        private void m_mthGetMainData()
        {
            m_dgvMainPage1.DataSource = null;

            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_dtpBeginDatePage1.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_dtpEndDatePage1.Text).ToString("yyyy-MM-dd 23:59:59"));
            if (dtmBegin.Date > dtmEnd)
            {
                return;
            }

            System.Collections.ArrayList arrPa = new System.Collections.ArrayList();
            arrPa.Add(dtmBegin);
            arrPa.Add(dtmEnd);
            arrPa.Add(m_strStorageID);
            arrPa.Add(m_txtMedicineNamePage1.Text.Trim());
            arrPa.Add(m_txtAskDeptPage1.Text.Trim());
            arrPa.Add(m_txtAskIDPage1.Text.Trim());

            if(m_blnIsGY3Y)
                arrPa.Add(m_cboOutStorageTypePage1.SelectItemValue);

            if (!m_bgwGetData1.IsBusy)
            {
                m_bgwGetData1.RunWorkerAsync(arrPa);
            }
        }
        #endregion

        private void m_dgvSubPage1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgr = m_dgvSubPage1.Rows[e.RowIndex];
            if (dgr.Cells[4].Value.ToString() == "UNKNOWN")
            {
                dgr.Cells[4].Value = "";
            }
        }

        #endregion

        private void frmOutStorage_Load(object sender, EventArgs e)
        {
            ((clsCtl_OutStorage)objController).m_mthStorageName();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}