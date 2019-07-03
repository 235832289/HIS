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
    /// 药库出库
    /// </summary>
    public partial class frmMedicineOut : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 出库类型
        /// </summary>
        internal int m_intOutStorageType = 1;
        /// <summary>
        /// 单据类型
        /// </summary>
        internal int m_intFormType = 1;
        /// <summary>
        /// 出库药品信息
        /// </summary>
        internal DataTable m_dtbOutMedicine = null;

        /// <summary>
        /// 药品字典信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// 审核流程(0,保存后由药库管理角色审核 1,保存后立即审核)
        /// </summary>
        internal int m_intCommitFolow = 0;
        /// <summary>
        /// 出库主表序列
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// 当前记录是否已审核
        /// </summary>
        internal bool m_blnHasCommit = false;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false;

        internal clsCtl_MedicineOut m_objControl = new clsCtl_MedicineOut();

        /// <summary>
        /// 药品中的批号,有效期录入控制
        /// </summary>
        internal clsMS_MedicineTypeVisionmSet m_clsTypeVisVO;

        /// <summary>
        /// 保存出库数量
        /// </summary>
        internal double dblNetAmount;
        /// <summary>
        /// 是否允许修改出入库单据的制单时间','0，否 1,是
        /// </summary>
        public int m_intCanModifyMakeDate;
        /// <summary>
        /// 自动审核后单据是否允许修改','0，否 1,是'
        /// </summary>
        public int m_intCanModifyAutoExam;
        /// <summary>
        /// 另一个数据库的数据库连接参数
        /// </summary>
        internal string m_strSecondDBConfigString = string.Empty;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药库出库
        /// </summary>
        private frmMedicineOut()
        {
            InitializeComponent();

            m_dtpDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpDate.Tag = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            
            m_dgvMedicineOutInfo.AutoGenerateColumns = false;

            ((clsCtl_MedicineOut)objController).m_mthInitMedicineTable(ref m_dtbOutMedicine);


            ((clsCtl_MedicineOut)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
            ((clsCtl_MedicineOut)objController).m_mthGetIsShowReceiptor();

            m_dgvMedicineOutInfo.DataSource = m_dtbOutMedicine;
            m_txtMan.Text = LoginInfo.m_strEmpName;
            m_txtMan.Tag = LoginInfo.m_strEmpID;

            m_mthInitJumpControls();

            DataTable dtbDept = null;
            ((clsCtl_MedicineOut)objController).m_mthGetExportDept(out dtbDept);
            m_txtReceiveDept.m_mthInitDeptData(dtbDept);
        }

        /// <summary>
        /// 药库出库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intOutStorageType">出库类型</param>
        /// <param name="p_intFormType">单据类型</param>
        public frmMedicineOut(string p_strStorageID, int p_intOutStorageType, int p_intFormType)
            : this()
        {
            m_strStorageID = p_strStorageID;
            m_intOutStorageType = p_intOutStorageType;
            m_intFormType = p_intFormType;
            m_bgwGetData.RunWorkerAsync();
            ((clsCtl_MedicineOut)objController).m_mthGetCommitFlow(out m_intCommitFolow);
            ((clsCtl_MedicineOut)objController).m_lngGetCanModifyMakeDate(out m_intCanModifyMakeDate);
            ((clsCtl_MedicineOut)objController).m_lngGetCanModifyAutoExam(out m_intCanModifyAutoExam);

            if (m_intCanModifyMakeDate == 0)
                m_dtpDate.Enabled = false;
        }

        /// <summary>
        /// 药库出库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intOutStorageType">出库类型</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_objMain">主表内容</param>
        /// <param name="p_objDetailArr">子表内容</param>
        /// <param name="p_intSelectedRow">子表选中行索引</param>
        public frmMedicineOut(string p_strStorageID, int p_intOutStorageType, int p_intFormType, clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objDetailArr, int p_intSelectedRow)
            : this(p_strStorageID, p_intOutStorageType, p_intFormType)
        {
            ((clsCtl_MedicineOut)objController).m_mthSetOutStorageToUI(p_objMain, p_objDetailArr, p_intSelectedRow);
        }
        #endregion

        #region 事件
        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ((clsCtl_MedicineOut)objController).m_purchasePrint(1);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("无法处理服务名"))
                    MessageBox.Show("请检查配置好第二个数据库的连接参数", "灏瀚系统温馨提示...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void m_cmdInsertRecord_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineOut)objController).m_mthInsertNewMedicineDate();
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_MedicineOut)objController).m_mthInitMedicineInfo(ref m_dtbMedicineInfo);
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        #region DataGridView跳转
        private void m_dgvMedicineOutInfo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_dgvMedicineOutInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void m_dgvMedicineOutInfo_ArriveLastColoumn()
        {

        }

        private void m_dgvMedicineOutInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (m_dgvMedicineOutInfo.ReadOnly) return;
            
            if (CurrentCell == null)
            {
                return;
            }
            m_dgvMedicineOutInfo.EndEdit();

            if (CurrentCell.ColumnIndex == 1)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["VALIDPERIOD_DAT"])) &&
                    m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["seriesid_int"].ToString() != "")
                {
                    bool bolAdjustrice;
                    DataGridViewRow dgr = m_dgvMedicineOutInfo.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex];
                    ((clsCtl_MedicineOut)objController).m_mthGetAdjustrice(this.m_txtOutputOrder.Text, m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["medicineid_chr"].ToString(),
                        m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["lotno_vchr"].ToString(), m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["instorageid_vchr"].ToString(),
                        Convert.ToDateTime(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["VALIDPERIOD_DAT"]), Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["CALLPRICE_INT"]), out bolAdjustrice);
                    if (bolAdjustrice)
                    {
                        m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"] = dblNetAmount;
                        MessageBox.Show("该药品已调价,不能修改！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        return;
                    }
                }
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                ((clsCtl_MedicineOut)objController).m_mthShowQueryMedicineForm(strFilter,m_dtbMedicineInfo);
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 5)
            {
                if (m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"].ToString().Trim() == "")
                {
                    return;
                }
                if (//Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"]) != dblNetAmount &&
                    !string.IsNullOrEmpty(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["VALIDPERIOD_DAT"].ToString()) &&
                    m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["seriesid_int"].ToString() != "")
                {
                    bool bolAdjustrice;
                    DataGridViewRow dgr = m_dgvMedicineOutInfo.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex];
                    ((clsCtl_MedicineOut)objController).m_mthGetAdjustrice(this.m_txtOutputOrder.Text,m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["medicineid_chr"].ToString(),
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
                long lngRes = ((clsCtl_MedicineOut)objController).m_lngShowMedicineSelect(CurrentCell.Value.ToString());
                if (lngRes <= 0)
                {
                    m_dgvMedicineOutInfo.Focus();
                    CurrentCell.Selected = true;
                    CancelJump = false;
                }
                else
                {
                    int intRowsCount = m_dtbOutMedicine.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        DataRow drLast = m_dtbOutMedicine.Rows[intRowsCount - 1];
                        //if (drLast["MEDICINEID_CHR"] == DBNull.Value && drLast["availagross_int"] == DBNull.Value)
                        //{
                        //    m_dgvMedicineOutInfo.Focus();
                        //    m_dgvMedicineOutInfo.CurrentCell = m_dgvMedicineOutInfo.Rows[intRowsCount - 1].Cells[1];
                        //}
                        //else
                        {
                            ((clsCtl_MedicineOut)objController).m_mthInsertNewMedicineDate();
                        }
                    }
                    CancelJump = true;
                }
                
            }
        }
        #endregion

        private void m_cmdNext_Click(object sender, EventArgs e)
        {
            DataRow[] drNull = null;
            if (m_dtbOutMedicine != null)
            {
                drNull = m_dtbOutMedicine.Select("availagross_int is null and realgross_int is null");//选择无用的数据
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_dtbOutMedicine.Rows.Remove(drTemp);
                    }
                }

                DataTable dtbNew = m_dtbOutMedicine.GetChanges(DataRowState.Added);
                DataTable dtbEdit = m_dtbOutMedicine.GetChanges(DataRowState.Modified);
                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定清空并书写下一张单?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            
            ((clsCtl_MedicineOut)objController).m_mthClear();
            m_dtpDate.Enabled = true;
        }

        private void m_txtMan_Enter(object sender, EventArgs e)
        {
            if (m_txtReceiptor.Visible)
            {
                m_txtReceiptor.Focus();
            }
            else
            {
                m_txtRemark.Focus();
            }            
        }

        private void m_txtRemark_KeyDown(object sender, KeyEventArgs e)
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
                    ((clsCtl_MedicineOut)objController).m_mthInsertNewMedicineDate();
                }
            }
        }

        private void m_dgvMedicineOutInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                m_dgvMedicineOutInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_MedicineOut)objController).m_mthCountMoney();
        }

        private void m_dgvMedicineOutInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                m_dgvMedicineOutInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_MedicineOut)objController).m_mthCountMoney();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            long lngRes= ((clsCtl_MedicineOut)objController).m_lngSaveOutStorageInfo(true);
            if (lngRes > 0)
            {
                if (m_intCanModifyMakeDate == 0)
                    m_dtpDate.Enabled = false;
                DialogResult drResult = MessageBox.Show("是否打印当前窗体记录?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.Yes)
                {
                    try
                    {
                        ((clsCtl_MedicineOut)objController).m_mthPrintDirect();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("无法处理服务名"))
                            MessageBox.Show("请检查配置好第二个数据库的连接参数", "灏瀚系统温馨提示...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                }
            }  

        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("确定删除选中出库记录？","药品出库",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            ((clsCtl_MedicineOut)objController).m_mthDeleteDetail();
        }

        private void m_txtReceiveDept_FocusNextControl(object sender, EventArgs e)
        {
            if (m_intCanModifyMakeDate == 1)
            {
                m_dtpDate.Focus();
                m_dtpDate.SelectionStart = 0;
            }
            else
            {
                m_txtRemark.Focus();
            }
        }

        private void m_dgvMedicineOutInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && m_dtbOutMedicine != null)
            {
                if (m_dgvMedicineOutInfo.Rows[e.RowIndex].DataBoundItem == null) return;
                double dblAmount = 0d;
                DataRow drCurrent = ((DataRowView)(m_dgvMedicineOutInfo.Rows[e.RowIndex].DataBoundItem)).Row;
                string strMedicineID = drCurrent["MEDICINEID_CHR"].ToString();
                bool bolAdjustrice;
                DataRowView dtvTemp;
                int intCurrentRow = m_dgvMedicineOutInfo.CurrentCell.RowIndex;
                for (int iRow = 0; iRow < m_dgvMedicineOutInfo.Rows.Count; iRow++)
                {
                    dtvTemp = m_dgvMedicineOutInfo.Rows[iRow].DataBoundItem as DataRowView;
                    if (dtvTemp["MEDICINEID_CHR"].ToString() == strMedicineID && Convert.ToString(dtvTemp["VALIDPERIOD_DAT"]) != "")
                    {
                        m_objControl.m_mthGetAdjustrice(this.m_txtOutputOrder.Text,dtvTemp["medicineid_chr"].ToString(),
                            dtvTemp["lotno_vchr"].ToString(), dtvTemp["instorageid_vchr"].ToString(),
                            Convert.ToDateTime(dtvTemp["VALIDPERIOD_DAT"]), Convert.ToDouble(dtvTemp["CALLPRICE_INT"]), out bolAdjustrice);
                        if (bolAdjustrice)
                        {
                            drCurrent.CancelEdit();
                            m_dgvMedicineOutInfo["m_dgvtxtOutAmount", intCurrentRow].Value = dblNetAmount;
                            MessageBox.Show("此药品已调价,因此不能修改此药品的出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            
                            return;
                        }
                    }
                }
                if (double.TryParse(drCurrent["NETAMOUNT_INT"].ToString(), out dblAmount))
                {
                    //if (drCurrent["CALLPRICE_INT"] != DBNull.Value && drCurrent["RETAILPRICE_INT"] != DBNull.Value)
                    //{
                    //    drCurrent["inmoney"] = (Convert.ToDouble(drCurrent["CALLPRICE_INT"]) * dblAmount).ToString("0.0000");
                    //    drCurrent["retailmoney"] = (Convert.ToDouble(drCurrent["RETAILPRICE_INT"]) * dblAmount).ToString("0.0000");
                    //}
                    drCurrent.EndEdit();
                }
            }
        }

        private void frmMedicineOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (m_blnHasChangeAmount)
            //{
            //    long lngRes = ((clsCtl_MedicineOut)objController).m_lngSaveOutStorageInfo(false);
            //    if (lngRes <= 0)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}            
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            DataRow[] drNull = null;
            if (m_dtbOutMedicine != null)
            {
                drNull = m_dtbOutMedicine.Select("availagross_int is null and realgross_int is null");//选择无用的数据
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_dtbOutMedicine.Rows.Remove(drTemp);
                    }
                }

                DataTable dtbNew = m_dtbOutMedicine.GetChanges(DataRowState.Added);
                DataTable dtbEdit = m_dtbOutMedicine.GetChanges(DataRowState.Modified);
                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定退出?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            this.Close();
        }

        private void frmMedicineOut_Load(object sender, EventArgs e)
        {
            if (m_dtbOutMedicine != null && m_dtbOutMedicine.Rows.Count == 0)
            {
                ((clsCtl_MedicineOut)objController).m_mthInsertNewMedicineDate();
            }

            if (m_intOutStorageType == 3)
            {
                m_cmdSave.Enabled = false;
                m_cmdInsertRecord.Enabled = false;
                m_cmdDelete.Enabled = false;
            }
            this.m_txtReceiveDept.Focus();

            //((clsCtl_MedicineOut)objController).m_intGetDBConfigFromXML(out m_strSecondDBConfigString);
        }
        #endregion

        #region 方法
        /// <summary>
        /// 控件跳转及背景高亮
        /// </summary>
        private void m_mthInitJumpControls()
        {
            clsCtl_Public objCtl = new clsCtl_Public();

            objCtl.m_mthSetControlHighLight(panel1, Color.Moccasin);
            objCtl.m_mthSelectAllText(panel1);
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineOut();
            objController.Set_GUI_Apperance(this);
        } 
        #endregion

        private void m_dgvMedicineOutInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void m_dgvMedicineOutInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void m_dgvMedicineOutInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                double.TryParse(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"].ToString(), out dblNetAmount);
            }
        }

        private void m_dgvMedicineOutInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_dgvMedicineOutInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_txtReceiptor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ((clsCtl_MedicineOut)objController).m_mthSetEmpToList(m_txtReceiveDept.StrItemId.Trim(), m_txtReceiptor.Text, m_txtReceiptor);
            }
        }

        private void m_txtReceiveDept_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtReceiveDept.Text.Trim()))
            {
                m_txtReceiveDept.Tag = null;
            }
        }

    }
}