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
    /// 药品外退(编辑窗体)
    /// </summary>
    public partial class frmForeignRetreatOutStorageDetail: com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
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
        /// 是否审核即入帐        /// </summary>
        internal bool m_blnIsImmAccount = false;

        /// <summary>
        /// 保存出库数量
        /// </summary>
        internal double dblNetAmount;

        /// <summary>
        /// 打印格式
        /// </summary>
        public int intPrintType;

        /// <summary>
        /// 窗体格式０：正常状态　１：初始化状态
        /// </summary>
        public int intInitial;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品外退(编辑窗体)
        /// </summary>
        private frmForeignRetreatOutStorageDetail()
        {
            InitializeComponent();

            m_dgvMedicineOutInfo.AutoGenerateColumns = false;

            //zhenwei.yang修改,添加时间
            DateTime dtDate = DateTime.Now;
            m_dtpDate.Text = dtDate.ToString("yyyy年MM月dd日");
            m_dtpDate.Tag = dtDate.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthInitMedicineTable(ref m_dtbOutMedicine);
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
            m_dgvMedicineOutInfo.DataSource = m_dtbOutMedicine;
        }

        /// <summary>
        /// 药品外退(编辑窗体)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmForeignRetreatOutStorageDetail(string p_strStorageID) : this()
        {
            m_strStorageID = p_strStorageID;
            m_bgwGetData.RunWorkerAsync();
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthGetCommitFlow(out m_intCommitFolow);
        }

        /// <summary>
        /// 药品外退
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objMain">主表内容</param>
        /// <param name="p_objDetailArr">子表内容</param>
        /// <param name="p_intSelectedRow">子表选中行索引</param>
        public frmForeignRetreatOutStorageDetail(string p_strStorageID, clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objDetailArr, int p_intSelectedRow)
            : this(p_strStorageID)
        {
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthSetOutStorageToUI(p_objMain, p_objDetailArr, p_intSelectedRow);
        }
        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_ForeignRetreatOutStorageDetail();
            objController.Set_GUI_Apperance(this);
        } 
        #endregion

        #region 事件
        private void m_dgvOutMedicine_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
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
                if (m_txtVendor.Tag == null && string.IsNullOrEmpty(m_txtVendor.Text) && intInitial == 0)
                {
                    MessageBox.Show("请先选择供应商","退货出库",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    m_txtVendor.Focus();
                }
                else
                {
                    string strFilter = string.Empty;
                    if (CurrentCell.Value != null)
                    {
                        strFilter = CurrentCell.Value.ToString();
                    }
                    ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthShowQueryMedicineForm(strFilter, m_dtbMedicineInfo);                    
                }
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 5)
            {
                //bool bolAdjustrice;
                //DataGridViewRow dgr = m_dgvMedicineOutInfo.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex];
                //((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthGetAdjustrice(dgr.Cells[14].Value.ToString(), dgr.Cells[4].Value.ToString(), dgr.Cells[12].Value.ToString(), out bolAdjustrice);
                //if (bolAdjustrice)
                //{
                //    dgr.Cells[5].Value = dblNetAmount;
                //    MessageBox.Show("该药品已调价,不能修改出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                //
                if (CurrentCell.RowIndex < m_dgvMedicineOutInfo.Rows.Count - 1)
                {
                    if (m_dgvMedicineOutInfo.Rows[CurrentCell.RowIndex + 1].Cells["m_dgvtxtCurrentGross"].Value == DBNull.Value)
                    {
                        m_dgvMedicineOutInfo.CurrentCell = m_dgvMedicineOutInfo.Rows[CurrentCell.RowIndex + 1].Cells[1];

                    }
                    else
                    {
                        m_dgvMedicineOutInfo.CurrentCell = m_dgvMedicineOutInfo.Rows[CurrentCell.RowIndex + 1].Cells["m_dgvtxtOutAmount"];
                    
                    }

                    m_dgvMedicineOutInfo.CurrentCell.Selected = true;
                }
                else
                {
                    ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthInsertNewMedicineDate();
                }
                CancelJump = true;
            }
        }

        private void m_dgvOutMedicine_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                m_dgvMedicineOutInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthCountMoney();
        }

        private void m_dgvOutMedicine_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                m_dgvMedicineOutInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthCountMoney();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            long lngRes=((clsCtl_ForeignRetreatOutStorageDetail)objController).m_lngSaveOutStorageInfo();
            if (lngRes > 0)
            {
                DialogResult drResult = MessageBox.Show("是否打印当前窗体记录?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.Yes)
                {
                    try
                    {
                        ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_OutPrint();
                        //clsMS_OutStorage_VO m_objCurrentSubArr = null;
                        //((clsCtl_ForeignRetreatOutStorageDetail)objController).getOutStorageDetail_VO(out m_objCurrentSubArr);
                        //frmForeignRetreatOutStorageDetailRep frmRet = new frmForeignRetreatOutStorageDetailRep();
                        //frmRet.m_objCurrentSubArr = m_objCurrentSubArr;
                        //frmRet.i_showType = 0;

                        //frmRet.Show();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("无法处理服务名"))
                            MessageBox.Show("请检查配置好第二个数据库的连接参数", "灏瀚系统温馨提示...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }  
        }

        private void m_cmdInsertRecord_Click(object sender, EventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthInsertNewMedicineDate();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMedicineOutInfo.Rows.Count > 1)
            {
                DialogResult drResult = MessageBox.Show("确定删除选中退货记录？", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
            }
            else if (this.m_dgvMedicineOutInfo.Rows.Count == 1)
            {
                DialogResult drResult = MessageBox.Show("删除最后一条退货记录将删除整张退货单,是否继续?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
            }
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthDeleteDetail();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsMS_OutStorage_VO m_objCurrentSubArr = null;
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).getOutStorageDetail_VO(out m_objCurrentSubArr);
            frmForeignRetreatOutStorageDetailRep frmRet = new frmForeignRetreatOutStorageDetailRep();
            frmRet.strOutputOrder = m_txtOutputOrder.Text;
            frmRet.m_objCurrentSubArr = m_objCurrentSubArr;
            
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_lngGetPrinType(out intPrintType);

            frmRet.i_showType = intPrintType;
            frmRet.strBug = m_lblBugMoney.Text;
          　frmRet.strOutDate =m_dtpDate.Text;
           frmRet.strVENDOR = m_txtVendor.Text;

            frmRet.ShowDialog();
        }

        private void m_cmdNext_Click(object sender, EventArgs e)
        {
            DataRow[] drNull = null;
            if (m_dtbOutMedicine != null)
            {
                drNull = m_dtbOutMedicine.Select("availagross_int is null and realgross_int");//选择无用的数据
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

            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthClear();
        }

        private void m_cmdGetInStorage_Click(object sender, EventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthCallInStorageInfo();
        }        

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthInsertNewMedicineDate();
                }
            }
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthInitMedicineInfo(ref m_dtbMedicineInfo);
        }

        private void frmForeignRetreatOutStorageDetail_Load(object sender, EventArgs e)
        {

            if (m_dtbOutMedicine != null && m_dtbOutMedicine.Rows.Count == 0)
            {
                ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthInsertNewMedicineDate();
            }
            if (intInitial == 1)
            {
                this.Text = "药品外退（初始化）";
                label1.Text = "备注";
                m_txtVendor.Text = "";
                m_txtVendor.Visible = false;
                m_txtRemark.Location = m_txtVendor.Location;
                label5.Visible = false;

            }
            m_txtVendor.Focus();
        }

        private void m_txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthShowVendor(m_txtVendor.Text);
            }            
        }
        #endregion  

        private void m_dgvMedicineOutInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                double.TryParse(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"].ToString(), out dblNetAmount);
            }
        }

        private void m_dgvMedicineOutInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"] == DBNull.Value)
            {
                return;
            }
            if (e.ColumnIndex == 5 && Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"]) != dblNetAmount &&
                m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["seriesid_int"].ToString() != "")
            {
                bool bolAdjustrice;
                DataGridViewRow dgr = m_dgvMedicineOutInfo.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex];
                ((clsCtl_ForeignRetreatOutStorageDetail)objController).m_mthGetAdjustrice(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["medicineid_chr"].ToString(),
                    m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["lotno_vchr"].ToString(), m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["instorageid_vchr"].ToString(),
                    Convert.ToDateTime(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["VALIDPERIOD_DAT"]), Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["CALLPRICE_INT"]), out bolAdjustrice);
                if (bolAdjustrice)
                {
                    //dgr.Cells[9].Value = dblNetAmount;
                    m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"] = dblNetAmount;
                    MessageBox.Show("该药品已调价,不能修改出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_dgvMedicineOutInfo.Focus();
                    return;
                }
            }
        }

        private void m_txtVendor_TextChanged(object sender, EventArgs e)
        {

        }


    }
}