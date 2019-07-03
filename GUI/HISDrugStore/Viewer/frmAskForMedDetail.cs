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
    /// 药房请领明细
    /// </summary>
    public partial class frmAskForMedDetail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {  
        /// <summary>
        /// 药房请领主界面
        /// </summary>
        public frmAskForMedManage frmMain;
        /// <summary>
        /// 请领药品信息
        /// </summary>
        public DataTable m_dtApplyMedicine=null;
        /// <summary>
        /// 药房领药主表序列号
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// 是否有修改的权限
        /// </summary>
        internal bool IsCanModify = true;
        /// <summary>
        /// 药品信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// 药房ID
        /// </summary>
        public string m_strDrugStoreID = string.Empty;
        /// <summary>
        /// 修改单据时，如果删除，则值等于0
        /// </summary>
        internal int m_intStatus = 999;
        /// <summary>
        /// 是否住院单位
        /// </summary>
        internal bool m_blnIsHospital = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmAskForMedDetail()
        {
            InitializeComponent();

        }
        private DataTable m_dtExportDept;
        public DataTable dtExportDept
        {
            get
            {
                return m_dtExportDept;
            }
            set
            {
                m_dtExportDept = value;
            }
        }
        /// <summary>
        /// 领药部门（生成请领单）
        /// </summary>
        public DataTable dtApplyDept;
        /// <summary>
        /// 自动生成时候的药库ID
        /// </summary>
        public string m_strStoreid;
        /// <summary>
        /// 自动生成时候的药库名称
        /// </summary>
        public string m_strStorename;
        internal string m_strOldStorageId = string.Empty;
        /// <summary>
        ///  创建控制层对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_AskForMedicineDetail();
            objController.Set_GUI_Apperance(this);
        }
        private void frmAskForMedDetail_Load(object sender, EventArgs e)
        {
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvDetail.AutoGenerateColumns = false;
            if (frmMain != null)
            {
                m_strDrugStoreID = frmMain.strStorageid;
                if (frmMain.Tag == null)
                {
                    if (frmMain.m_dtApplyDept != null)
                    {
                        for (int i = 0; i < frmMain.m_dtApplyDept.Rows.Count; i++)
                        {
                            this.m_cboAskDept.Item.Add(frmMain.m_dtApplyDept.Rows[i]["deptname_vchr"].ToString(), frmMain.m_dtApplyDept.Rows[i]["deptid_chr"].ToString());
                        }
                    }
                }
                else
                {
                    this.m_cboAskDept.AccessibleName = this.frmMain.Tag.ToString();
                    this.m_cboAskDept.Text = this.frmMain.AccessibleName;
                    this.m_cboAskDept.Enabled = false;
                    this.m_cboAskDept.BackColor = Color.White;
                }
            }
            else
            {
                if (dtApplyDept != null)
                {
                    for (int i = 0; i < dtApplyDept.Rows.Count; i++)
                    {
                        this.m_cboAskDept.Item.Add(dtApplyDept.Rows[i]["deptname_vchr"].ToString(), dtApplyDept.Rows[i]["deptid_chr"].ToString());
                    }
                }
            }
            this.m_mthGetExportDeptInfo();
            if (this.m_dtApplyMedicine == null)
            {
                ((clsCtl_AskForMedicineDetail)objController).m_mthInitMedicineTable(ref m_dtApplyMedicine);
                this.m_dgvDetail.DataSource = m_dtApplyMedicine;
                m_mthShowRetailMoney();
                this.m_datApplyDate.Text = clsPub.CurrentDateTimeNow.ToString("yyyy年MM月dd日");
                this.m_txtAsker.Text = this.LoginInfo.m_strEmpName;
                this.m_txtAsker.AccessibleName = this.LoginInfo.m_strEmpID;
                if (m_dtApplyMedicine != null && m_dtApplyMedicine.Rows.Count == 0)
                {
                    ((clsCtl_AskForMedicineDetail)objController).m_mthInsertNewMedicineInfo();
                }
                this.m_cboAskDept.Focus();
            }
            else
            {
                this.m_dgvDetail.DataSource = m_dtApplyMedicine;
                m_mthShowRetailMoney();
                m_dtApplyMedicine.AcceptChanges();
                if (IsCanModify == false)
                {
                    this.m_btnSave.Enabled = false;
                    this.m_btnDelete.Enabled = false;
                    this.m_btnInsert.Enabled = false;
                    //this.m_btnNext.Enabled = false;                    
                    this.m_cboExportDept.Enabled = false;

                    this.m_dgvDetail.Columns[1].ReadOnly = true;
                    this.m_dgvDetail.Columns[5].ReadOnly = true;
                }
            }

            if (m_blnIsHospital)
            {
                m_dgvDetail.Columns["unit_chr"].HeaderText = "住院单位";
            }
        }
        #region 获取出库部门信息
        /// <summary>
        /// 获取出库部门信息
        /// </summary>
        public void m_mthGetExportDeptInfo()
        {
            for (int i = 0; i < m_dtExportDept.Rows.Count; i++)
            {
                this.m_cboExportDept.Item.Add(m_dtExportDept.Rows[i]["medicineroomname"].ToString(), m_dtExportDept.Rows[i]["medicineroomid"].ToString());
            }
        }
        #endregion
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            DataRow[] drNull = null;
            if (m_dtApplyMedicine != null)
            {  
               drNull = m_dtApplyMedicine.Select("medicineid_chr is null and opamount_int is null");//选择无用的数据
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_dtApplyMedicine.Rows.Remove(drTemp);
                    }
                }
                DataTable dtbNew = m_dtApplyMedicine.GetChanges(DataRowState.Added);
                DataTable dtbEdit = m_dtApplyMedicine.GetChanges(DataRowState.Modified);
                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("当前窗体存在未保存的请领记录，是否退出?", "药房请领", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            this.Close();
        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                this.m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;

                if (Convert.ToString(m_dgvDetail.Rows[iRow].Cells["requestunit_chr"].Value) != Convert.ToString(m_dgvDetail.Rows[iRow].Cells["m_dgvtxtOutUint"].Value))
                {
                    m_dgvDetail.Rows[iRow].Cells["requestunit_chr"].Style.ForeColor = Color.Blue;
                    m_dgvDetail.Rows[iRow].Cells["requestamount_int"].Style.ForeColor = Color.Blue;
                }
                else
                {
                    m_dgvDetail.Rows[iRow].Cells["requestunit_chr"].Style.ForeColor = Color.Black;
                    m_dgvDetail.Rows[iRow].Cells["requestamount_int"].Style.ForeColor = Color.Black;
                }
            }
        }

        private void m_dgvDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                this.m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }
        private void m_dgvDetail_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }
            this.m_dgvDetail.EndEdit();
            if (CurrentCell.ColumnIndex == 1)
            {
                if (string.IsNullOrEmpty(m_cboExportDept.AccessibleName))
                {
                    MessageBox.Show("请先选择药库！", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_cboExportDept.Focus();
                    CancelJump = true;
                    return;
                }
                
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                if (m_cboExportDept.AccessibleName != m_strOldStorageId || m_dtbMedicineInfo == null || m_dtbMedicineInfo.Rows.Count == 0)
                {
                    // clsPub.m_mthGetMedBaseInfo(this.m_strDrugStoreID, m_cboExportDept.SelectItemValue, out m_dtbMedicineInfo);
                    // ((clsCtl_AskForMedicineDetail)objController).m_lngGetMedicineInfoForAsk(this.m_strDrugStoreID, out m_dtbMedicineInfo);
                    ((clsCtl_AskForMedicineDetail)objController).m_lngGetMedicineInfoForAskWithStorageInfo(m_blnIsHospital, this.m_strDrugStoreID, out m_dtbMedicineInfo);
                    m_strOldStorageId = m_cboExportDept.AccessibleName;
                }
                ((clsCtl_AskForMedicineDetail)objController).m_mthShowQueryMedicineForm(strFilter, m_dtbMedicineInfo);
                
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 5)
            {
                int p_intRowIndex = CurrentCell.RowIndex;
                double m_dblValue = 0;//请领数量
                double dblTemp = 0d;//包装量
                double dblTmp = 0d;//请领包装量 
                if (double.TryParse(Convert.ToString(CurrentCell.Value),out m_dblValue))
                {
                    m_dblValue = Convert.ToDouble(m_dblValue.ToString("F2"));
                    try
                    {
                        DataRowView drvCurrent = m_dgvDetail.Rows[p_intRowIndex].DataBoundItem as DataRowView;

                        if (double.TryParse(this.m_dgvDetail.Rows[p_intRowIndex].Cells["requestpackqty_dec"].Value.ToString(), out dblTmp))
                        {
                            this.m_dgvDetail.Rows[p_intRowIndex].Cells["m_dgvtxtOutAmount"].Value = m_dblValue * dblTmp;
                            if (double.TryParse(this.m_dgvDetail.Rows[p_intRowIndex].Cells["m_dgvPackDec"].Value.ToString(), out dblTemp))
                            {
                                if (m_blnIsHospital)
                                {
                                    if (Convert.ToInt16(drvCurrent["ipchargeflg_int"]) == 0)//基本单位
                                    {
                                        //最小数量
                                        this.m_dgvDetail.Rows[p_intRowIndex].Cells["m_dgvtxtInAmount"].Value = m_dblValue * dblTmp;
                                        m_dgvDetail.Rows[p_intRowIndex].Cells["AMOUNT_INT"].Value = m_dblValue * dblTmp;
                                        m_dgvDetail.Rows[p_intRowIndex].Cells["unit_chr"].Value = drvCurrent["opunit_chr"];
                                    }
                                    else
                                    {
                                        //最小数量
                                        this.m_dgvDetail.Rows[p_intRowIndex].Cells["m_dgvtxtInAmount"].Value = m_dblValue * dblTmp * dblTemp;
                                        m_dgvDetail.Rows[p_intRowIndex].Cells["AMOUNT_INT"].Value = m_dblValue * dblTmp * dblTemp;
                                        m_dgvDetail.Rows[p_intRowIndex].Cells["unit_chr"].Value = drvCurrent["ipunit_chr"];
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt16(drvCurrent["opchargeflg_int"]) == 0)//基本单位
                                    {
                                        //最小数量
                                        this.m_dgvDetail.Rows[p_intRowIndex].Cells["m_dgvtxtInAmount"].Value = m_dblValue * dblTmp;
                                        m_dgvDetail.Rows[p_intRowIndex].Cells["AMOUNT_INT"].Value = m_dblValue * dblTmp;
                                        m_dgvDetail.Rows[p_intRowIndex].Cells["unit_chr"].Value = drvCurrent["opunit_chr"];
                                    }
                                    else
                                    {
                                        //最小数量
                                        this.m_dgvDetail.Rows[p_intRowIndex].Cells["m_dgvtxtInAmount"].Value = m_dblValue * dblTmp * dblTemp;
                                        m_dgvDetail.Rows[p_intRowIndex].Cells["AMOUNT_INT"].Value = m_dblValue * dblTmp * dblTemp;
                                        m_dgvDetail.Rows[p_intRowIndex].Cells["unit_chr"].Value = drvCurrent["ipunit_chr"];
                                    }
                                }
                                m_dgvDetail.Rows[p_intRowIndex].Cells["RetailSum"].Value = m_dblValue * Convert.ToDouble(drvCurrent["unitprice_mny"]);
                                m_mthShowRetailMoney();
                                ((clsCtl_AskForMedicineDetail)objController).m_mthInsertNewMedicineInfo();
                                CancelJump = true;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (CurrentCell.ColumnIndex == 6)
            {

                ((clsCtl_AskForMedicineDetail)objController).m_mthInsertNewMedicineInfo();
                CancelJump = true;
            }
        }
        /// <summary>
        /// 保存基本单位对应的数量
        /// </summary>
        public double dblOPAmount;
        /// <summary>
        /// 保存最小单位对应的数量
        /// </summary>
        public double dblIPAmount;
        private void m_dgvDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4)
            //{
            //    double.TryParse(this.m_dtApplyMedicine.Rows[this.m_dgvDetail.CurrentCell.RowIndex]["OPAMOUNT_INT"].ToString(), out this.dblOPAmount);
            //}
            //if (e.ColumnIndex == 6)
            //{
            //    double.TryParse(this.m_dtApplyMedicine.Rows[this.m_dgvDetail.CurrentCell.RowIndex]["IPAMOUNT_INT"].ToString(), out dblIPAmount);
            //}
        }

        private void m_dgvDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_btnInsert_Click(object sender, EventArgs e)
        {
            ((clsCtl_AskForMedicineDetail)objController).m_mthInsertNewMedicineInfo();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (this.m_dgvDetail.SelectedCells.Count > 0)
            {
                DialogResult drResult = MessageBox.Show("确定删除选中的请领记录？", "药房请领", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
                ((clsCtl_AskForMedicineDetail)objController).m_mthDeleteDetail();
            }
            else
            {
                return;
            }
        }

        private void m_btnNext_Click(object sender, EventArgs e)
        {
            DataRow[] drNull = null;
            if (m_dtApplyMedicine!= null)
            {
                drNull = m_dtApplyMedicine.Select("medicineid_chr is null and opamount_int is null");//选择无用的数据
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_dtApplyMedicine.Rows.Remove(drTemp);
                    }
                }
                DataTable dtbNew = m_dtApplyMedicine.GetChanges(DataRowState.Added);
                DataTable dtbEdit = m_dtApplyMedicine.GetChanges(DataRowState.Modified);
                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定保存并书写下一张单?", "药房请领", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.Yes)
                    {
                        ((clsCtl_AskForMedicineDetail)objController).m_lngSaveApplyMedInfo(true);
                    }
                }
            }
            ((clsCtl_AskForMedicineDetail)objController).m_mthClear();
            this.m_txtComment.Focus();
        }
        private void m_mthControls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (((Control)sender).Name)
                {  
                    case "m_txtComment": this.m_dgvDetail.Focus(); break;
                    case "m_cboExportDept": this.m_datApplyDate.Focus(); break;
                    default: System.Windows.Forms.SendKeys.Send("{TAB}"); break;
                }
            }
        }

        private void m_txtApplyDept_TextChanged(object sender, EventArgs e)
        {
            this.m_datApplyDate.Focus();
        }
        private void m_txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_dtApplyMedicine.Rows.Count > 0)
                {
                    DataRow drLast = m_dtApplyMedicine.Rows[m_dtApplyMedicine.Rows.Count - 1];
                    if (drLast["MEDICINEID_CHR"] == DBNull.Value)
                    {
                        this.m_dgvDetail.Focus();
                        m_dgvDetail.CurrentCell = m_dgvDetail.Rows[this.m_dtApplyMedicine.Rows.Count - 1].Cells[1];
                        m_dgvDetail.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    ((clsCtl_AskForMedicineDetail)objController).m_mthInsertNewMedicineInfo();
                }
            }
        }

        private void m_datApplyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_txtComment.Focus();
            }
        }

        private void m_cboApplyDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //System.Windows.Forms.SendKeys.Send("{TAB}");
                this.m_datApplyDate.Focus();
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_AskForMedicineDetail)objController).m_lngSaveApplyMedInfo(true);
            //20080320 	药房请领不需要打印，保存时不需要提示“是否打印”
            //if (lngRes > 0)
            //{
            //    DialogResult drResult = MessageBox.Show("是否打印当前窗体记录?", "药房请领", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (drResult == DialogResult.Yes)
            //    {
            //        ((clsCtl_AskForMedicineDetail)objController).m_mthPrint();

            //    }

            //}  
        }
        private void m_txtAskDept_FocusNextControl(object sender, EventArgs e)
        {
            this.m_cboExportDept.Focus();
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_AskForMedicineDetail)objController).m_mthPrint();
        }
        private void m_cboExportDept_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{F4}");
        }

        internal void SetDetail(DataTable dtbSelected)
        {
            ((clsCtl_AskForMedicineDetail)objController).m_mthSetDetail(dtbSelected);
        }

        internal void m_mthShowRetailMoney()
        {
            DataTable m_dtbDetail = (DataTable)this.m_dgvDetail.DataSource;
            //DataRow[] m_drRow = m_dtbDetail.Select("","",DataViewRowState.Deleted
            if (m_dtbDetail != null && m_dtbDetail.Rows.Count > 0)
            {
                double dblTemp = 0d;
                double dblFormat = 0d;
                for (int i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
                {
                    if(m_dtbDetail.Rows[i1].RowState == DataRowState.Deleted)continue;
                    double.TryParse(m_dtbDetail.Rows[i1]["RetailSum"].ToString(), out dblFormat);
                    m_dtbDetail.Rows[i1]["RetailSum"] = dblFormat.ToString("F4");
                    dblTemp += dblFormat;
                }
                m_lblRetailSubMoney.Text = dblTemp.ToString("F4")+"元";
            }
            else
            {
                m_lblRetailSubMoney.Text = "0.0000元";
            }
        }

        private void m_dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.ColumnIndex == 5)
            {
                DataRowView drvCurrent = m_dgvDetail.Rows[e.RowIndex].DataBoundItem as DataRowView;
                double dblAmount = 0;//请领数量
                double dblTemp = 0d;//包装量
                double dblTmp = 0d;//请领包装量 

                if (double.TryParse(Convert.ToString(this.m_dgvDetail.Rows[e.RowIndex].Cells["requestamount_int"].Value), out dblAmount))
                {
                    dblAmount = Convert.ToDouble(dblAmount.ToString("F2"));
                    if (double.TryParse(this.m_dgvDetail.Rows[e.RowIndex].Cells["requestpackqty_dec"].Value.ToString(), out dblTmp))
                    {
                        this.m_dgvDetail.Rows[e.RowIndex].Cells["m_dgvtxtOutAmount"].Value = dblAmount * dblTmp;
                        if (double.TryParse(this.m_dgvDetail.Rows[e.RowIndex].Cells["m_dgvPackDec"].Value.ToString(), out dblTemp))
                        {
                            if (m_blnIsHospital)
                            {
                                if (Convert.ToInt16(drvCurrent["ipchargeflg_int"]) == 0)//基本单位
                                {
                                    this.m_dgvDetail.Rows[e.RowIndex].Cells["AMOUNT_INT"].Value = dblAmount * dblTmp;
                                    //最小数量
                                    this.m_dgvDetail.Rows[e.RowIndex].Cells["m_dgvtxtInAmount"].Value = dblAmount * dblTmp * dblTemp;
                                }
                                else
                                {
                                    this.m_dgvDetail.Rows[e.RowIndex].Cells["AMOUNT_INT"].Value = dblAmount * dblTmp * dblTemp;
                                    //最小数量
                                    this.m_dgvDetail.Rows[e.RowIndex].Cells["m_dgvtxtInAmount"].Value = dblAmount * dblTmp * dblTemp;
                                }
                            }
                            else
                            {
                                if (Convert.ToInt16(drvCurrent["opchargeflg_int"]) == 0)//基本单位
                                {
                                    this.m_dgvDetail.Rows[e.RowIndex].Cells["AMOUNT_INT"].Value = dblAmount * dblTmp;
                                    //最小数量
                                    this.m_dgvDetail.Rows[e.RowIndex].Cells["m_dgvtxtInAmount"].Value = dblAmount * dblTmp * dblTemp;
                                }
                                else
                                {
                                    this.m_dgvDetail.Rows[e.RowIndex].Cells["AMOUNT_INT"].Value = dblAmount * dblTmp * dblTemp;
                                    //最小数量
                                    this.m_dgvDetail.Rows[e.RowIndex].Cells["m_dgvtxtInAmount"].Value = dblAmount * dblTmp * dblTemp;
                                }
                            }
                            m_dgvDetail.Rows[e.RowIndex].Cells["RetailSum"].Value = dblAmount * dblTmp * Convert.ToDouble(drvCurrent["unitprice_mny"]);
                            m_mthShowRetailMoney();
                        }
                    }
                }
            }
        }

        private void frmAskForMedDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_txtAskBillNo.Text.Length > 0 && (m_dtApplyMedicine == null || m_dtApplyMedicine.Rows.Count == 0))
            {
                DialogResult drResult = MessageBox.Show("没有输入药品明细，关闭此界面将自动作废该请领单，是否继续关闭？", "注意...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.Yes)
                {
                    if (((clsCtl_AskForMedicineDetail)objController).m_lngDeleteBill(m_txtAskBillNo.Text) < 0)
                    {
                        MessageBox.Show("作废单据失败，请检查该单据状态！", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        m_intStatus = 0;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void m_cboExportDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_cboExportDept.AccessibleName = m_cboExportDept.SelectItemValue;
        }
    }
}