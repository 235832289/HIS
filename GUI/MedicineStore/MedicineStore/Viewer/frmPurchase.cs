using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Controls;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品入库
    /// </summary>
    public partial class frmPurchase : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 当前主表内容
        /// </summary>
        internal DataTable m_dtbMainData = null;
        /// <summary>
        /// 当前子表内容
        /// </summary>
        internal DataTable m_dtbSubData = null;
        /// <summary>
        /// 当前主表显示内容
        /// </summary>
        internal DataView m_dtvMainView = null;
        /// <summary>
        /// 药品类型
        /// </summary>
        private clsMS_MedicineType_VO[] m_objMPVO = null;
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
        /// 是否广医三院模式，即入库类型可自定义
        /// </summary>
        internal bool m_blnIsGY3Y = false;
        #endregion

        #region 构造函数

        /// <summary>
        /// 药品入库
        /// </summary>
        private frmPurchase()
        {
            InitializeComponent();
            m_dtpSearchBeginDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpSearchEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dgvMainInfo.AutoGenerateColumns = false;
            m_dgvSubInfo.AutoGenerateColumns = false;
            //初始化出库类型,兼容其他医院
            this.m_cboInComeType.Item.Add("全部", "0");
            this.m_cboInComeType.Item.Add("采购入库", "1");
            this.m_cboInComeType.Item.Add("生产入库", "2");
            this.m_cboInComeType.Item.Add("即出即入", "3");
            m_cboInComeType.SelectedIndex = 0;
            m_cboBillState.SelectedIndex = 0;
            ((clsCtl_Purchase)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            ((clsCtl_Purchase)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);

            m_dtpSearchBeginDate.Focus();
            m_mthSetControlHighLight();
        
        }

        /// <summary>
        /// 药品入库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmPurchase(string p_strStorageID)
            : this()
        {
            m_strStorageID = p_strStorageID;
            string strStoreRoomName = ((clsCtl_Purchase)objController).m_strStoreRoomName(p_strStorageID);
            if (!string.IsNullOrEmpty(strStoreRoomName))
            {
                this.Text += " - " + strStoreRoomName;
            }
            m_mthGetMainDate();
        }
        /// <summary>
        /// 药品入库
        /// </summary>
        /// <param name="p_strStorageID">药库id</param>
        /// <param name="m_strInStorageType">入库类型</param>
        public frmPurchase(string p_strStorageID,string m_strInStorageType)
            : this()
        {
            m_blnIsGY3Y = true;

            m_strStorageID = p_strStorageID;
            string strStoreRoomName = ((clsCtl_Purchase)objController).m_strStoreRoomName(p_strStorageID);
            if (!string.IsNullOrEmpty(strStoreRoomName))
            {
                this.Text += " - " + strStoreRoomName;
            }
            m_mthGetMainDate();
            this.m_cmdNewMake.Click -= new EventHandler(cmdNewMake_Click);
            this.m_cmdNewMake.Click += new EventHandler(m_cmdNewMake_Click);            
            ((clsCtl_Purchase)objController).m_mthGetImpExpTypeInfo(m_strInStorageType);
        }

        void m_cmdNewMake_Click(object sender, EventArgs e)
        {
            this.button1.PerformClick();
        } 
        #endregion

        #region 事件
        private void cmdNewMake_Click(object sender, EventArgs e)
        {
            frmPurchase_Detail frmPurchaseType = new frmPurchase_Detail(m_strStorageID, 1, 1);
            //frmPurchaseType.TopMost = true;
            frmPurchaseType.FormClosed += new FormClosedEventHandler(frmPurchaseType_FormClosed);
            frmPurchaseType.ShowDialog();
        }

        internal void frmPurchaseType_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_cmdSearch_Click(null, null);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdModify_Click(object sender, EventArgs e)
        {
            clsMS_InStorage_VO objMain = null;
            clsMS_InStorageDetail_VO[] objSubArr = null;
            ((clsCtl_Purchase)objController).m_mthModifySelected(out objMain, out objSubArr);

            if (objMain == null)
            {
                return;
            }

            int intSelectedSubRow = 0;
            if (m_dgvSubInfo.SelectedRows != null && m_dgvSubInfo.SelectedRows.Count > 0)
            {
                intSelectedSubRow = m_dgvSubInfo.SelectedRows[0].Index;
            }

            frmPurchase_Detail frmPurchaseType = new frmPurchase_Detail(m_strStorageID, objMain.m_intFORMTYPE_INT, objMain.m_intINSTORAGETYPE_INT, objMain, objSubArr, intSelectedSubRow);
            frmPurchaseType.FormClosed += new FormClosedEventHandler(frmPurchaseType_FormClosed);

            frmPurchaseType.ShowDialog();


        }

        private void m_cmdDelee_Click(object sender, EventArgs e)
        {
            ((clsCtl_Purchase)objController).m_mthDeleteMedicine();
        }

        private void m_cmdAuditing_Click(object sender, EventArgs e)
        {
            m_cmdAuditing.Enabled = false;
            m_pnlWaiting.Visible = true;
            Application.DoEvents();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataRow[] drCommit = null;
                ((clsCtl_Purchase)objController).m_mthCommitMedicine(out drCommit);

                ((clsCtl_Purchase)objController).m_mthUpdateUIAfterCommit(drCommit);
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                m_cmdAuditing.Enabled = true;
                m_pnlWaiting.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void m_cmdExitAuditing_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_Purchase)objController).m_mthUnCommit();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_cmdInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_Purchase)objController).m_mthInAccount();
        }

        private void m_cmdOutAccount_Click(object sender, EventArgs e)
        {

        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Collections.ArrayList arrPa = e.Argument as System.Collections.ArrayList;
            if(m_blnIsGY3Y)
            ((clsCtl_Purchase)objController).m_mthGetMainData(Convert.ToDateTime(arrPa[0]), Convert.ToDateTime(arrPa[1]), arrPa[2].ToString(), 
                arrPa[3].ToString(), arrPa[4].ToString(), arrPa[5].ToString(),arrPa[6].ToString(),Convert.ToInt16(arrPa[6].ToString()), out m_dtbMainData);
            else
            ((clsCtl_Purchase)objController).m_mthGetMainData(Convert.ToDateTime(arrPa[0]), Convert.ToDateTime(arrPa[1]), arrPa[2].ToString(),
            arrPa[3].ToString(), arrPa[4].ToString(), arrPa[5].ToString(), arrPa[6].ToString(), out m_dtbMainData);

            if (m_objMPVO == null)
            {
                ((clsCtl_Purchase)objController).m_mthGetStorageMedicineType(m_strStorageID,out m_objMPVO);
            }

            if (m_dtbMedicinDict == null)
            {
                ((clsCtl_Purchase)objController).m_mthGetMedicineInfo();
            }
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_dtvMainView = new DataView(m_dtbMainData);
            //m_dgvMainInfo.DataSource = m_dtvMainView;
            ((clsCtl_Purchase)objController).m_mthFilterMainData();
            
            if (m_dgvMainInfo.Rows.Count > 0 && m_dtvMainView.Count > 0)
            {
                if (m_dgvMainInfo.CurrentCell == null)
                {
                    m_dgvMainInfo.Rows[0].Selected = true;
                    m_dgvMainInfo.CurrentCell = m_dgvMainInfo.Rows[0].Cells[1];
                }
                //((clsCtl_Purchase)objController).m_mthSetCommitSelectReadonly();
            }

            ((clsCtl_Purchase)objController).m_mthSetMedicineType(m_objMPVO);
        }


        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            m_dtbAllMoney = null;
            if (m_dtbMainData != null)
            {
                m_dtbMainData.Rows.Clear();
            }
            if (m_dtbSubData != null)
            {
                m_dtbSubData.Rows.Clear();
            }

            m_mthGetMainDate();
            //((clsCtl_Purchase)objController).m_mthFilterMainData();
        }

        private void m_dgvMainInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            m_lblBuyInSubMoney.Text = string.Empty;
            m_lblWholeSaleSubMoney.Text = string.Empty;
            m_lblRetailSubMoney.Text = string.Empty;

            if (m_dgvMainInfo.CurrentCell == null)
            {
                return;
            }
            DataRowView drvSelected = m_dtvMainView[m_dgvMainInfo.CurrentCell.RowIndex];
            if (drvSelected != null)
            {
                long lngSEQ = Convert.ToInt64(drvSelected["SERIESID_INT"]);
                ((clsCtl_Purchase)objController).m_mthGetInstorageDetal(lngSEQ, out m_dtbSubData);
                
                DataView dtvSub = new DataView(m_dtbSubData);
                
                m_dgvSubInfo.DataSource = dtvSub;

                ((clsCtl_Purchase)objController).m_mthGetAllSubMoney();
            }
        }

        private void m_txtProviderName_TextChanged(object sender, EventArgs e)
        {
            //废弃即时查询
            //((clsCtl_Purchase)objController).m_mthFilterMainData();
        }

        private void m_cboInComeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_Purchase)objController).m_mthFilterMainData();
        }

        private void m_cboBillState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_Purchase)objController).m_mthFilterMainData();
        }

        private void m_cboDoseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //废弃即时查询
            //((clsCtl_Purchase)objController).m_mthFilterSubData();
        }

        private void m_txtMedicineName_TextChanged(object sender, EventArgs e)
        {
            //废弃即时查询
            //((clsCtl_Purchase)objController).m_mthFilterSubData();
        }

        private void m_txtBillNumber_TextChanged(object sender, EventArgs e)
        {
            //废弃即时查询
            //((clsCtl_Purchase)objController).m_mthFilterMainData();
        }

        private void m_dgvSubInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvSubInfo.Rows.Count; iRow++)
            {
                m_dgvSubInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dtpSearchEndDate_Enter(object sender, EventArgs e)
        {
            m_dtpSearchEndDate.SelectionStart = 0;
        }

        private void m_dtpSearchBeginDate_Enter(object sender, EventArgs e)
        {
            m_dtpSearchBeginDate.SelectionStart = 0;
        }

        #region 显示查询控件及控件跳转

        private void m_txtProviderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_Purchase)objController).m_mthShowVendor(m_txtProviderName.Text);
            }
        }

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_Purchase)objController).m_mthShowQueryMedicineForm(m_txtMedicineName.Text);
            }
        }

        private void m_cboInComeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cboBillState.Focus();
            }
        }

        private void m_cboBillState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtMedicineName.Focus();
            }
        }

        private void m_txtBillNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cboDoseType.Focus();
            }
        }
        #endregion


        private void m_dgvSubInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModify_Click(null, null);
        }

        private void m_dgvMainInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModify_Click(null, null);
        }

        private void m_lblSelectAll_Click(object sender, EventArgs e)
        {
            if (m_dgvMainInfo.Rows.Count > 0)
            {
                if (m_lblSelectAll.Text == "全选")
                {
                    m_lblSelectAll.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvMainInfo.Rows.Count; iRow++)
                    {
                        m_dgvMainInfo.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelectAll.Text == "反选")
                {
                    m_lblSelectAll.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvMainInfo.Rows.Count; iRow++)
                    {
                        m_dgvMainInfo.Rows[iRow].Cells[0].Value =false;
                    }
                }
            }  
        }

        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_Purchase();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 设置活动控件背景高亮
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthSetControlHighLight(panel1, Color.Moccasin);
            objCtl.m_mthSelectAllText(panel1);
        }

        #region 异步获取主表内容
        /// <summary>
        /// 异步获取主表内容
        /// </summary>
        private void m_mthGetMainDate()
        {
            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));
            if (dtmBegin.Date > dtmEnd)
            {
                return;
            }

            System.Collections.ArrayList arrPa = new System.Collections.ArrayList();
            arrPa.Add(dtmBegin);
            arrPa.Add(dtmEnd);
            arrPa.Add(m_strStorageID);
            arrPa.Add(m_txtMedicineName.Text.Trim());
            arrPa.Add(m_txtProviderName.Text);
            arrPa.Add(m_txtBillNumber.Text);
            if (m_cboDoseType.SelectedIndex < 0 || m_cboDoseType.SelectedIndex == 0)
            {
                arrPa.Add(0);
            }
            else
            {
                clsMS_MedicineType_VO objVo = m_cboDoseType.SelectedItem as clsMS_MedicineType_VO;
                arrPa.Add(objVo.m_strMedicineTypeID_CHR);
            }
            if (m_blnIsGY3Y)
            {
                arrPa.Add(m_cboInComeType.SelectedValue);
            }
            
            if (!m_bgwGetData.IsBusy)
            {
                m_bgwGetData.RunWorkerAsync(arrPa);
            }
        }
        #endregion

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            //是否显示批发价

            int m_intShowWholePrice;
            ((clsCtl_Purchase)objController).m_lngGetShowWholePrice(out m_intShowWholePrice);
            if (m_intShowWholePrice == 0)
            {
                m_dgvSubInfo.Columns["m_dgvtxtWholeSalePrice"].Visible = false;
            }
            
        }



        #endregion

        private void label9_Click(object sender, EventArgs e)
        {
            m_tmsShowNewMake.Top = m_cmdNewMake.Top + m_cmdNewMake.Height;
            m_tmsShowNewMake.Left = m_cmdNewMake.Left;
            this.m_cmdNewMake.ContextMenuStrip = this.m_tmsShowNewMake;
            m_tmsShowNewMake.ShowImageMargin = false;
            m_tmsShowNewMake.Top = 100;
            m_tmsShowNewMake.Show();
            
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            Point p = new Point(this.m_cmdNewMake.Left, this.m_cmdNewMake.Top+this.m_cmdNewMake.Height);
            this.m_tmsShowNewMake.Show(this.m_cmdNewMake, p);
        }

        private void 入即出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase_Detail frmPurchaseType = new frmPurchase_Detail(m_strStorageID, 1, 3);
            //frmPurchaseType.m_bolAddOutMedicineInfo = true;
            //frmPurchaseType.m_intInstorageType = 3;
            frmPurchaseType.FormClosed += new FormClosedEventHandler(frmPurchaseType_FormClosed);
            frmPurchaseType.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point p = new Point(this.m_cmdNewMake.Left, this.m_cmdNewMake.Top + this.m_cmdNewMake.Height);
            this.m_tmsShowNewMake.Show(this.m_cmdNewMake, p);
        }

        private void m_dgvSubInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }


    }
}