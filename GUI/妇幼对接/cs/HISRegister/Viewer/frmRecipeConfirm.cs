using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmRecipeConfirm : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmRecipeConfirm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 申请单ID
        /// </summary>
        public List<string> objListApp = new List<string>();
        public Dictionary<string, string> objDicApp = new Dictionary<string, string>();

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_RecipeConfirm();
            objController.Set_GUI_Apperance(this);
        }

        private void txtCardno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_RecipeConfirm)this.objController).m_mthGetPatientInfo();
            }
        }

        private void trvRecipe_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ((clsCtl_RecipeConfirm)this.objController).m_mthGetRecipeInfo();
        }

        private void frmRecipeConfirm_Load(object sender, EventArgs e)
        {
            //dgvRecipe.RowTemplate.Height = 45;
            ((clsCtl_RecipeConfirm)this.objController).m_mthCompetence();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.dgvDetails.Rows.Count > 0)
            {
                if ((MessageBox.Show("确定要确认这部分费用么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == DialogResult.Yes)
                {
                    ((clsCtl_RecipeConfirm)this.objController).m_mthConfirmApp();
                }
            }
            else
            {
                MessageBox.Show("请选择需要确认的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRecipe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int intIndexRow = e.RowIndex;

            if (e.ColumnIndex != dgvRecipe.Columns["colChecked"].Index)
            {
                return;
            }
            if (intIndexRow < 0 || intIndexRow > dgvRecipe.Rows.Count - 1)
            {
                return;
            }

            if (dgvRecipe.Rows[intIndexRow].Cells["colstatus"].Value != null && dgvRecipe.Rows[intIndexRow].Cells["colstatus"].Value.ToString().Contains("已确认"))
            {
                return;
            }
            string p_strRecipeNO = this.dgvRecipe.Rows[intIndexRow].Cells["colRepNo"].Value.ToString();
            string p_strPatientID = this.dgvRecipe.Rows[intIndexRow].Cells["colpatientid"].Value.ToString();
            string p_strPaitentDeID = this.dgvRecipe.Rows[intIndexRow].Cells["coldeid"].Value.ToString();
            string p_strType = this.dgvRecipe.Rows[intIndexRow].Cells["colType"].Value.ToString();
            string p_strItemID = string.Empty;
            if (string.IsNullOrEmpty(p_strPatientID))
            {
                p_strItemID = this.dgvRecipe.Rows[intIndexRow].Cells["colItemID"].Value.ToString();
            }
            if (dgvRecipe.Rows[intIndexRow].Cells["colChecked"].Value.ToString() == "T")
            {
                dgvRecipe.Rows[intIndexRow].Cells["colChecked"].Value = "F";
                //objListApp.Remove(this.dgvRecipe.Rows[intIndexRow].Cells["colAttachid"].Value.ToString());
              //  objDicApp.Remove(this.dgvRecipe.Rows[intIndexRow].Cells["colAttachid"].Value.ToString());
                ((clsCtl_RecipeConfirm)this.objController).m_mthDeleteItemDetails(p_strPaitentDeID);
            }
            else
            {
                dgvRecipe.Rows[intIndexRow].Cells["colChecked"].Value = "T";
               // objListApp.Add(this.dgvRecipe.Rows[intIndexRow].Cells["colAttachid"].Value.ToString());
                //if (!objDicApp.ContainsKey(this.dgvRecipe.Rows[intIndexRow].Cells["colAttachid"].Value.ToString()))
                //{
                //    objDicApp.Add(this.dgvRecipe.Rows[intIndexRow].Cells["colAttachid"].Value.ToString(), this.dgvRecipe.Rows[intIndexRow].Cells["colItemAttribute"].Value.ToString());
                //}
                ((clsCtl_RecipeConfirm)this.objController).m_mthGetItemDetails(p_strRecipeNO, p_strItemID, p_strPatientID, p_strPaitentDeID, p_strType);
            }
            
            
           // ((clsCtl_RecipeConfirm)this.objController).m_mthSelectMergeItem(intIndexRow);
        }

        private void comCancel_Click(object sender, EventArgs e)
        {
            ((clsCtl_RecipeConfirm)this.objController).m_mthItemsCancel();
        }
    }
}