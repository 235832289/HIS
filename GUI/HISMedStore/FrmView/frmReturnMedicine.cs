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
    /// 药品退药管理界面
    /// </summary>
    public partial class frmReturnMedicine : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 扣减库存流程 参数0401
        /// </summary>
        internal int m_intDeductFlow = 0;
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmReturnMedicine()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            this.objController = new clsControlReturnMedicine();
            this.objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// 当前药房id
        /// </summary>
        public string m_strMedStoreid;
        /// <summary>
        /// 显示具体某个药房发药退药管理信息
        /// </summary>
        /// <param name="strMedStoreid"></param>
        public void m_mthSetShow(string strMedStoreid)
        {
            m_strMedStoreid = strMedStoreid.Trim();
            this.Show();
        }
        private void frmReturnMedicine_Load(object sender, EventArgs e)
        {

            this.m_cboFindType.SelectedIndex = 4;
            this.m_dgvReturnMed.AutoGenerateColumns = false;
            this.m_dgvSendMed.AutoGenerateColumns = false;
            this.m_dgvDetail.AutoGenerateColumns = false;
            this.m_dgvReturnDetail.AutoGenerateColumns = false;
            this.m_dgvSourceRecipeDetail.AutoGenerateColumns = false;

            m_intDeductFlow = int.Parse(objController.m_objComInfo.m_lonGetModuleInfo("0401"));
            ((clsControlReturnMedicine)this.objController).m_mthInitialGUI(m_strMedStoreid);
            ((clsControlReturnMedicine)this.objController).m_mthGetReturnMedicine();
            
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_datCurrentDate_ValueChanged(object sender, EventArgs e)
        {
            //((clsControlReturnMedicine)this.objController).m_mthGetReturnMedicine();
        }

        private void m_dgvSendMed_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvSendMed.Rows.Count; iRow++)
            {
                m_dgvSendMed.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvSendMed_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvSendMed.Rows.Count; iRow++)
            {
                m_dgvSendMed.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvReturnMed_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvReturnMed.Rows.Count; iRow++)
            {
                this.m_dgvReturnMed.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvReturnMed_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvReturnMed.Rows.Count; iRow++)
            {
                this.m_dgvReturnMed.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void ctlDataGridView_EnterAsTab1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_dgvSendMed_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (this.m_dgvSendMed.CurrentCell == null) return;
                ((clsControlReturnMedicine)this.objController).m_mthBindDetailData(0);
            }

        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value ="False";
            }
        }

        private void m_dgvDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = "False";
            }
        }

        private void m_dgvDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (this.m_dgvDetail.Rows.Count == 0) return;
                this.m_dgvDetail.CurrentCell = this.m_dgvDetail.Rows[0].Cells[1];
                if (this.m_dgvDetail.Columns[e.ColumnIndex].HeaderText.Trim() == "全选")
                {
                    this.m_dgvDetail.Columns[e.ColumnIndex].HeaderText = "反选";
                    for (int i = 0; i < this.m_dgvDetail.Rows.Count; i++)
                    {
                        this.m_dgvDetail.Rows[i].Cells[0].Value = "True";
                        this.m_dgvDetail.CurrentCell = this.m_dgvDetail.Rows[i].Cells[1];
                    }
                }
                else
                {
                    this.m_dgvDetail.Columns[e.ColumnIndex].HeaderText = "全选";
                    for (int i = 0; i < this.m_dgvDetail.Rows.Count; i++)
                    {
                        if (this.m_dgvDetail.Rows[i].Cells[0].Value.ToString() == "True")
                        {
                            this.m_dgvDetail.Rows[i].Cells[0].Value = "False";
                        }
                        else
                        {
                            this.m_dgvDetail.Rows[i].Cells[0].Value = "True";
                        }
                        this.m_dgvDetail.CurrentCell = this.m_dgvDetail.Rows[i].Cells[1];
                    }
             
                }
             
            }
        }

        private void m_btnReturn_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1) return;
            if (this.m_dgvSendMed.CurrentCell == null)
            {
                MessageBox.Show("请先选择一张已发药的处方进行退药！");
                return;
            }
            if (this.m_dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("该处方不存在任何需要退药的明细信息！");
                return;
            }
            else
            {
                this.m_dgvDetail.CurrentCell = this.m_dgvDetail.Rows[0].Cells[1];
                for (int i = 0; i < this.m_dgvDetail.Rows.Count; i++)
                {
                    if (this.m_dgvDetail.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        break;
                    }
                    if (i == this.m_dgvDetail.Rows.Count - 1)
                    {
                        MessageBox.Show("请选择需要退药的处方明细信息！");
                        return;
                    }
                }
            }
            this.m_dgvDetail.CurrentCell = this.m_dgvDetail.Rows[0].Cells[1];
            ((clsControlReturnMedicine)this.objController).m_mthReturnMedicine();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.m_dgvDetail.Visible = true ;
                this.m_dgvReturnDetail.Visible = false;
            }
            else
            {
                this.m_dgvDetail.Visible = false;
                this.m_dgvReturnDetail.Visible = true;
            }
        }

        private void m_dgvReturnMed_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                if (this.m_dgvReturnMed.CurrentCell == null) return;
                ((clsControlReturnMedicine)this.objController).m_mthBindDetailData(1);
            }
        }

        private void m_dgvReturnDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvReturnDetail.Rows.Count; iRow++)
            {
                this.m_dgvReturnDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvReturnDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvReturnDetail.Rows.Count; iRow++)
            {
                this.m_dgvReturnDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }
        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            ((clsControlReturnMedicine)this.objController).m_mthGetReturnMedicine();
        }

        private void m_btnFind_Click(object sender, EventArgs e)
        {
            ((clsControlReturnMedicine)this.objController).m_mthGetReturnMedicine();
            string m_strRowFilter = "";
            switch (this.m_cboFindType.SelectedIndex)
            {
                case 0: m_strRowFilter = "patientcardid_chr='" + this.m_cboText.Text.Trim() + "'"; break;
                case 1: m_strRowFilter = "lastname_vchr='" + this.m_cboText.Text.Trim() + "'"; break;
                case 2: m_strRowFilter = "serno_chr='" + this.m_cboText.Text.Trim() + "'"; break;
                case 3: m_strRowFilter = "outpatrecipeid_chr='" + this.m_cboText.Text.Trim() + "'"; break;
                case 4: m_strRowFilter = "invoiceno_vchr='" + this.m_cboText.Text.Trim() + "'"; break;
            }
            if (this.m_dgvSendMed.DataSource != null)
            {
                if (this.m_dgvSendMed.DataSource is DataTable)
                {
                    this.m_dgvSendMed.DataSource = ((DataTable)this.m_dgvSendMed.DataSource).DefaultView;
                    ((DataView)this.m_dgvSendMed.DataSource).RowFilter = m_strRowFilter;
                }
                else
                {
                    ((DataView)this.m_dgvSendMed.DataSource).RowFilter = m_strRowFilter;
                }
                if (this.m_dgvSendMed.Rows.Count == 0)
                {
                    this.m_dgvDetail.DataSource = null;
                }
            }
            if (this.m_dgvReturnMed.DataSource != null)
            {
                if (this.m_dgvReturnMed.DataSource is DataTable)
                {
                    this.m_dgvReturnMed.DataSource = ((DataTable)this.m_dgvReturnMed.DataSource).DefaultView;
                    ((DataView)this.m_dgvReturnMed.DataSource).RowFilter = m_strRowFilter;
                }
                else
                {
                    ((DataView)this.m_dgvReturnMed.DataSource).RowFilter = m_strRowFilter;
                }
                if (this.m_dgvReturnMed.Rows.Count == 0)
                {
                    this.m_dgvReturnDetail.DataSource = null;
                }
               
            }
        }

        private void m_cboText_KeyDown(object sender, KeyEventArgs e)
        {   
            
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_cboFindType.SelectedIndex == 0)
                {
                    this.m_cboText.Text = this.m_cboText.Text.PadLeft(10, '0');
                }
                this.m_btnFind.Select();
            }
        }

        private void m_dgvDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_dgvDetail_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }
            this.m_dgvDetail.EndEdit();
            if (CurrentCell.ColumnIndex == 6)
            {
                string strValue = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strValue = CurrentCell.Value.ToString();
                    double dblResult=0d;
                     if(double.TryParse(strValue,out dblResult))
                     {
                         if (dblResult > Convert.ToDouble(this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells["m_txtOrgAmount"].Value))
                         {
                             MessageBox.Show("输入的退药数量不能大于原始发药数量！","iCare系统提示信息",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             CancelJump = true;
                             return;
                         }
                         else if (dblResult<=0)
                         {
                             MessageBox.Show("输入的退药数量应大于零！", "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             CancelJump = true;
                             return;
                         }
                     
                     }
                     else
                     {
                         MessageBox.Show("请输入正确的退药数量！", "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         CancelJump = true;
                         return;
                     }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0) return;
            if (this.m_dgvReturnMed.CurrentCell == null)
            {
                MessageBox.Show("请先选择一张已退药的处方进行重打退药凭据！");
                return;
            }
            if (this.m_dgvReturnDetail.Rows.Count == 0)
            {
                MessageBox.Show("该处方不存在任何需要退药的明细信息！");
                return;
            }
            this.m_dgvReturnDetail.CurrentCell = this.m_dgvReturnDetail.Rows[0].Cells[1];
            ((clsControlReturnMedicine)this.objController).m_mthRePrintBill();
        }

        private void m_dgvSourceRecipeDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvSourceRecipeDetail.Rows.Count; iRow++)
            {
                this.m_dgvSourceRecipeDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvSourceRecipeDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvSourceRecipeDetail.Rows.Count; iRow++)
            {
                this.m_dgvSourceRecipeDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvReturnDetail_DoubleClick(object sender, EventArgs e)
        {
            ((clsControlReturnMedicine)this.objController).m_mthShowSourceRecipeDetail();
        }

        private void m_dgvSourceRecipeDetail_Leave(object sender, EventArgs e)
        {
            this.m_dgvSourceRecipeDetail.Visible = false;
        }

        private void m_btnRollBack_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0) return;
            if (this.m_dgvReturnMed.CurrentCell == null)
            {
                MessageBox.Show("请先选择一张已退药处方进行撤销退药！");
                return;
            }
            if (this.m_dgvReturnDetail.Rows.Count == 0)
            {
                MessageBox.Show("该处方不存在任何需要撤销退药的明细信息！");
                return;
            }
            ((clsControlReturnMedicine)this.objController).m_mthRollBackReturnMedicine();
        }


    }
}