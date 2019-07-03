using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPatientRecipeNoPay : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmPatientRecipeNoPay()
        {
            InitializeComponent();

        }

        #region 设置控制对象

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_PatientRecipeNoPay();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 构造
        /// <summary>
        /// 构造函数自动查询传入的参数
        /// </summary>
        /// <param name="p_strPatientNo">病人住院号或诊疗号</param>
        /// <param name="p_intType">1-为住院号，2-为诊疗号</param>
        public frmPatientRecipeNoPay(string p_strPatientNo, int p_intType, List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            InitializeComponent();
            this.m_cboType.SelectedIndex = p_intType;
            this.m_txtPatientNo.Text = p_strPatientNo;
            this.m_lblName.Text = p_lstRecipeNoPay_VO[0].m_strName;
            this.m_lblSex.Text = p_lstRecipeNoPay_VO[0].m_strSex;
            ((clsCtl_PatientRecipeNoPay)this.objController).m_mthFillData(p_lstRecipeNoPay_VO);
            this.m_dgvResult.Columns[0].Visible = true;

            this.m_lblReminder.Visible = true;
            this.m_cmdAssociate.Enabled = true;
        }
        #endregion

        private void m_cmdSelect_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatientRecipeNoPay)this.objController).m_mthSelect();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.OK;
            this.Close();
        }

        private void m_cmdAssociate_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatientRecipeNoPay)this.objController).m_lngInsertPatientNopayRecipeZY();
        }

        private void frmPatientRecipeNoPay_Load(object sender, EventArgs e)
        {
            this.m_cboType.SelectedIndex = 1;
            //this.m_cmdAssociate.Enabled = false;
        }

        private void m_txtPatientNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_PatientRecipeNoPay)this.objController).m_mthSelect();
            }

        }

        private void m_cmdReSet_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatientRecipeNoPay)this.objController).m_mthReSetPatientNoPayRecipe();
        }

        private void m_dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (this.m_dgvResult.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper() == "T")
            {
                this.m_dgvResult.Rows[e.RowIndex].Cells[0].Value = "F";
            }
            else
            {
                this.m_dgvResult.Rows[e.RowIndex].Cells[0].Value = "T";
            }
        }

        private void m_dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex==0)
            {

                if (this.m_dgvResult.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper() == "T")
                {
                    this.m_dgvResult.Rows[e.RowIndex].Cells[0].Value = "F";
                }
                else
                {
                    this.m_dgvResult.Rows[e.RowIndex].Cells[0].Value = "T";
                }
            }

            
        }

        

        
    }
}