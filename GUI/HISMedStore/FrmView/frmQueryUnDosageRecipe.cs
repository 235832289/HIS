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
    /// 药房未配处方查询
    /// </summary>
    public partial class frmQueryUnDosageRecipe : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {   
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmQueryUnDosageRecipe()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 创建界面控制层
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsControlQueryUnDosageRecipe();
            this.objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// 当前药房id
        /// </summary>
        public string m_strMedStoreid;
        /// <summary>
        /// 显示具体某个药房未配处方查询
        /// </summary>
        /// <param name="strMedStoreid"></param>
        public void m_mthSetShow(string strMedStoreid)
        {
            m_strMedStoreid = strMedStoreid.Trim();
            this.Show();
        }
        private void frmQueryUnDosageRecipe_Load(object sender, EventArgs e)
        {

            this.m_cboFindType.SelectedIndex = 4;
            this.m_dgvSendMed.AutoGenerateColumns = false;
            this.m_dgvDetail.AutoGenerateColumns = false;
            this.m_dgvSendMed.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            ((clsControlQueryUnDosageRecipe)this.objController).m_mthInitialGUI(m_strMedStoreid);
            ((clsControlQueryUnDosageRecipe)this.objController).m_mthGetUnDosageRecipeInfo();
            
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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


        private void ctlDataGridView_EnterAsTab1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }
        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            ((clsControlQueryUnDosageRecipe)this.objController).m_mthGetUnDosageRecipeInfo();
        }

        private void m_btnFind_Click(object sender, EventArgs e)
        {
            ((clsControlQueryUnDosageRecipe)this.objController).m_mthGetUnDosageRecipeInfo();
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

        private void m_dgvSendMed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.m_dgvSendMed.CurrentCell == null) return;
            ((clsControlQueryUnDosageRecipe)this.objController).m_mthBindDetailData();
        }
    }
}