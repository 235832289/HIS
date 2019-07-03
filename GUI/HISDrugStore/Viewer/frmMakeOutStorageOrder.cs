using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 药库审核出库制单界面
    /// </summary>
    public partial class frmMakeOutStorageOrder : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 是否住院药房
        /// </summary>
        internal bool m_blnIsHospital = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMakeOutStorageOrder()
        {
            InitializeComponent();
            this.m_dgvMedicineOutInfo.AutoGenerateColumns = false;
            m_intDaysToValidDate = Convert.ToInt32(this.objController.m_objComInfo.m_lonGetModuleInfo("5032"));

            ((clsCtl_MakeOutStorageOrder)objController).m_mthInitMedicineTable(ref m_dtbOutMedicine);            
            this.m_dgvMedicineOutInfo.DataSource = m_dtbOutMedicine;
            this.m_bgWorker.RunWorkerAsync();
        }
        /// <summary>
        /// 绑定界面控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MakeOutStorageOrder();
            objController.Set_GUI_Apperance(this);
        } 
        #region 全局变量
        /// <summary>
        /// 请领主表id
        /// </summary>
        public long m_lngAskSeq = 0;
        /// <summary>
        /// 出库药品信息
        /// </summary>
        internal DataTable m_dtbOutMedicine = null;
        /// <summary>
        /// 药品字典信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// 保存出库数量
        /// </summary>
        internal double dblNetAmount=0;
        /// <summary>
        /// 出库主表id
        /// </summary>
        public long m_lngMainSEQ = 0;
        /// <summary>
        /// 是否直接审核
        /// </summary>        
        public long m_intCommitFolow = 1;
        /// <summary>
        /// 是否新增（新增则载入所需的请领单子表信息和对应的出库明细）
        /// </summary>
        internal bool m_blnNew = false;
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 出库类型
        /// </summary>
        internal DataTable m_dtOutStoreType = null;
        /// <summary>
        /// '药库药品离失效期特定时间设置',默认30，单位：天
        /// </summary>
        private int m_intDaysToValidDate = 30;
        #endregion
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMakeOutStorageOrder_Load(object sender, EventArgs e)
        {
            try
            {
                m_datMakeOrder.Value = clsPub.CurrentDateTimeNow;
                timer1.Start();

                this.m_dgvMedicineOutInfo.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                this.m_cboStatus.Enter -= new EventHandler(m_cboStatus_Enter);
                if (m_blnNew)
                {
                    DataTable m_dtRequestDetail = new DataTable();
                    clsDcl_AskForMedicine objDomain = new clsDcl_AskForMedicine();
                    objDomain.m_lngCheckIsHospital(m_txtApplyDept.AccessibleName, out m_blnIsHospital);
                    objDomain.m_lngGetAskDetailInfoByid(m_blnIsHospital, Convert.ToInt64(m_lngAskSeq), out m_dtRequestDetail);
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthLoadMedicineData(m_lngAskSeq, m_dtRequestDetail,ref m_dtbOutMedicine);
                    this.m_mthShowRetailMoney();
                    this.m_cboStatus.Enter += new EventHandler(m_cboStatus_Enter);
                }
                if (m_dtbOutMedicine != null && m_dtbOutMedicine.Rows.Count == 0)
                {
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthInsertNewMedicineData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void m_dgvMedicineOutInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                this.m_dgvMedicineOutInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }

            for (int iRow = 0; iRow < this.m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                this.m_dgvMedicineOutInfo.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                if (Convert.ToString(this.m_dgvMedicineOutInfo.Rows[iRow].Cells["m_dgvtxtEffectData"].Value) == "")
                    continue;
                if (Convert.ToDateTime(this.m_dgvMedicineOutInfo.Rows[iRow].Cells["m_dgvtxtEffectData"].Value).Date < m_datMakeOrder.Value.Date)//clsPub.SysDateTimeNow)
                {
                    if (Convert.ToDateTime(this.m_dgvMedicineOutInfo.Rows[iRow].Cells["m_dgvtxtEffectData"].Value).ToString("yyyy-MM-dd").Trim() != "0001-01-01")
                    {
                        this.m_dgvMedicineOutInfo.Rows[iRow].DefaultCellStyle.ForeColor = Color.Crimson;
                    }
                }
                else if (Convert.ToDateTime(this.m_dgvMedicineOutInfo.Rows[iRow].Cells["m_dgvtxtEffectData"].Value).AddDays(-m_intDaysToValidDate).Date < m_datMakeOrder.Value.Date)//clsPub.SysDateTimeNow)
                {
                    this.m_dgvMedicineOutInfo.Rows[iRow].DefaultCellStyle.ForeColor = SystemColors.HotTrack;
                }

            }
        }

        private void m_dgvMedicineOutInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                this.m_dgvMedicineOutInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("确定删除选中出库记录？", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            ((clsCtl_MakeOutStorageOrder)objController).m_mthDeleteDetail();
        }

        private void m_btnInsert_Click(object sender, EventArgs e)
        {
            ((clsCtl_MakeOutStorageOrder)objController).m_mthInsertNewMedicineData();
        }

        private void m_txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtbOutMedicine.Rows.Count > 0)
                {
                    DataRow drLast = m_dtbOutMedicine.Rows[m_dtbOutMedicine.Rows.Count - 1];
                    if (drLast["MEDICINEID_CHR"] == DBNull.Value && drLast["availagross_int"] == DBNull.Value)
                    {
                        m_dgvMedicineOutInfo.Focus();
                        m_dgvMedicineOutInfo.CurrentCell = m_dgvMedicineOutInfo.Rows[m_dtbOutMedicine.Rows.Count - 1].Cells[1];
                        m_dgvMedicineOutInfo.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthInsertNewMedicineData();
                }
            }
        }
        internal void m_mthShowRetailMoney()
        {
            DataTable m_dtbDetail = (DataTable)this.m_dgvMedicineOutInfo.DataSource;
            //DataRow[] m_drRow = m_dtbDetail.Select("","",DataViewRowState.Deleted
            if (m_dtbDetail != null && m_dtbDetail.Rows.Count > 0)
            {
                double dblTemp = 0d;
                double dblFormat = 0d;
                for (int i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
                {
                    if (m_dtbDetail.Rows[i1].RowState == DataRowState.Deleted) continue;
                    double.TryParse(m_dtbDetail.Rows[i1]["retailmoney"].ToString(), out dblFormat);
                    //m_dtbDetail.Rows[i1]["retailmoney"] = dblFormat.ToString("F4");
                    dblTemp += dblFormat;
                }
                m_lblRetailSubMoney.Text = dblTemp.ToString("F4") + "元";
            }
            else
            {
                m_lblRetailSubMoney.Text = "0.0000元";
            }
        }

        private void m_dgvMedicineOutInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }
            m_dgvMedicineOutInfo.EndEdit();

            if (CurrentCell.ColumnIndex == 1)
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                if (m_dtbMedicineInfo == null || m_dtbMedicineInfo.Rows.Count == 0)
                {
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthInitMedicineInfo(ref m_dtbMedicineInfo);
                }
                
                ((clsCtl_MakeOutStorageOrder)objController).m_mthShowQueryMedicineForm(strFilter, m_dtbMedicineInfo);                
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 8)
            {
                if (m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"].ToString().Trim() == "")
                {
                    return;
                }
                if (Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"]) != dblNetAmount &&
                    m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["seriesid_int"].ToString() != "")
                {
                    bool bolAdjustrice;
                    DataGridViewRow dgr = m_dgvMedicineOutInfo.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex];
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthGetAdjustrice(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["medicineid_chr"].ToString(),
                        m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["lotno_vchr"].ToString(), m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["instorageid_vchr"].ToString(),
                        Convert.ToDateTime(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["VALIDPERIOD_DAT"]), Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["CALLPRICE_INT"]), out bolAdjustrice);
                    if (bolAdjustrice)
                    {
                        m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"] = dblNetAmount;
                        MessageBox.Show("该药品已调价,不能修改出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_dgvMedicineOutInfo.Focus();
                        return;
                    }
                }
                double dblTemp = 0d;
                if (!double.TryParse(CurrentCell.Value.ToString(), out dblTemp))
                {
                    CancelJump = true;
                    return;
                }
                int intRowIndex = CurrentCell.RowIndex;
                long lngRes = ((clsCtl_MakeOutStorageOrder)objController).m_lngShowMedicineSelect(CurrentCell.Value.ToString());
                if (lngRes <= 0)
                {
                    m_dgvMedicineOutInfo.Focus();
                    CurrentCell.Selected = true;
                }
                else
                {                    
                    this.m_mthShowRetailMoney();
                    if (intRowIndex == m_dtbOutMedicine.Rows.Count - 1)
                    {
                        ((clsCtl_MakeOutStorageOrder)objController).m_mthInsertNewMedicineData();
                    }
                    else
                    {
                        m_dgvMedicineOutInfo.CurrentCell = m_dgvMedicineOutInfo.Rows[intRowIndex + 1].Cells[8];
                    }
                }
                CancelJump = true;
            }
        }

        private void m_dgvMedicineOutInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && m_dtbOutMedicine != null)
            {
                double dblAmount = 0d;
                DataRow drCurrent = ((DataRowView)(m_dgvMedicineOutInfo.Rows[e.RowIndex].DataBoundItem)).Row;
                if (double.TryParse(drCurrent["NETAMOUNT_INT"].ToString(), out dblAmount))
                {
                    if(dblAmount != 0)
                        drCurrent.EndEdit();
                }
            }
        }

        private void m_bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
          //  clsPub.m_mthGetMedBaseInfo(this.m_obj,out this.m_dtbMedicineInfo);
            clsPub.m_lngGetTypeCode(1, out this.m_dtOutStoreType);
        }

        private void m_dgvMedicineOutInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_btnStorageExam_Click(object sender, EventArgs e)
        {
            m_dgvMedicineOutInfo.EndEdit();
            this.m_mthShowRetailMoney();
            DialogResult drResult = MessageBox.Show("该药品出库单一旦审核将不能修改,是否继续审核", "药品出库提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.Yes)
            {
                long lngRes = ((clsCtl_MakeOutStorageOrder)objController).m_lngSaveOutStorageInfo(true);
                if (lngRes > 0)
                {
                    timer1.Stop();
                     drResult = MessageBox.Show("是否打印当前窗体记录?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.Yes)
                    {
                        ((clsCtl_MakeOutStorageOrder)objController).m_mthPrintDirect();
                    }

                }
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtOutStorageBillNo.Text))
            {
                MessageBox.Show("请先保存单据", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //((clsCtl_MakeOutStorageOrder)objController).m_mthPrintPreview();
            ((clsCtl_MakeOutStorageOrder)objController).m_purchasePrint(1);
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            if (m_txtOutStorageBillNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请先保存单据", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_MakeOutStorageOrder)objController).m_mthExportToExcel();
        }

        private void m_cboStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_txtComment.Focus();
            }
        }

        private void m_cboStatus_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{F4}");
        }

        private void m_cboStatus_Leave(object sender, EventArgs e)
        {
            this.m_cboStatus.Enter -= new EventHandler(m_cboStatus_Enter);
        }

        private void m_cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_cboStatus.AccessibleName = m_cboStatus.SelectItemValue != string.Empty ? m_cboStatus.SelectItemValue : m_cboStatus.AccessibleName;
        }

        private void m_bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_cboStatus.Items.Clear();
            if (this.m_dtOutStoreType != null)
            {
                for (int i = 0; i < this.m_dtOutStoreType.Rows.Count; i++)
                {
                    this.m_cboStatus.Item.Add(m_dtOutStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtOutStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }
            }
            m_cboStatus.Text = "领药出库";//三院是发放出库
            int m_intType;
            ((clsCtl_MakeOutStorageOrder)objController).m_lngGetTypeCodeByName(out m_intType); 
            m_cboStatus.AccessibleName = m_intType.ToString();
        }

        private void m_dgvMedicineOutInfo_DataSourceChanged(object sender, EventArgs e)
        {
            this.m_mthShowRetailMoney();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_datMakeOrder.Value = m_datMakeOrder.Value.AddSeconds(1);
        }

    }
}