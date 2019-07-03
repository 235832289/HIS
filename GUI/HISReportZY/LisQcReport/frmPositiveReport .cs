using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS.Reports;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPositiveReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmPositiveReport()
        {
            InitializeComponent();
        }

        #region
        /// <summary>
        /// 窗体设计器
        /// </summary>
        private clsCtl_PositiveReport m_objController;
        public string DeptIdArr = string.Empty;

        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_PositiveReport();
            this.m_objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            m_objController.Clear();
        }

        private void frmPositiveReport_Load(object sender, EventArgs e)
        {
            m_objController.m_mthInti();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;
            if (intTem == 0)
            {
                m_objController.m_mthGetPositiveReport();
            }

            if (intTem == 1)
            {
                m_objController.m_mthGetLisResultReport();
            }

            if (intTem == 2)
            {
                m_objController.m_mthGetPositivePerReport();
            }
        }

        private void btnByDept_Click(object sender, EventArgs e)
        {
            frmByDept frmAidChooseDept = new frmByDept();
            
            if (frmAidChooseDept.ShowDialog() == DialogResult.OK)
            {
                this.DeptIdArr = frmAidChooseDept.DeptIDArr;
            }
        }

        private void cboStatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;

            //"检验项目阳性结果分析统计表", "检验项目结果分析汇总表", "检验项目阳性率分析统计表" 
            
            if (intTem == 0)
            {
                this.dgvPositiveResult.Visible = true;
                this.dgvPositivePer.Visible = false;
            }
            if (intTem == 1)
            {
                this.dgvPositiveResult.Visible = true;
                this.dgvPositivePer.Visible = false;
            }
            if (intTem == 2)
            {
                this.dgvPositiveResult.Visible = false;
                this.dgvPositivePer.Visible = true;
            }
        }

        private void cbxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择检验项目";
            m_objController.m_mthListCheckItem();
        }

        private void tabColse_Click(object sender, EventArgs e)
        {
            //this.txtSearchName.Text = "";
            this.tabContorl.Visible = false;
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            m_objController.m_mthGetCheckItemByName();
        }

        private void cbxGroup_MouseDown(object sender, MouseEventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择检验项目";
            m_objController.m_mthListCheckItem();
        }

        private void dgvItem_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvItem.CurrentRow != null)
            {
                {
                    object[] value = new object[dgvItem.Columns.Count];
                    for (int i = 0; i < dgvItem.Columns.Count; i++)
                    {
                        value[i] = dgvItem.CurrentRow.Cells[i].Value;
                    }

                    //dgvCheckItem.Rows.Clear();
                    dgvCheckItem.Rows.Add(value);
                }
            }

            //this.tabContorl.Visible = false;
        }

        private void cbxGroup_MouseClick(object sender, MouseEventArgs e)
        {
            m_objController.m_mthGetCheckItemByName();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;
            m_objController.m_mthExportToExcel(intTem);
        }

        private void btnTabClose_Click(object sender, EventArgs e)
        {
            this.tabContorl.Visible = false;
        }

        private void btnExite_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvPositiveResult_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();  
        }
    }
}
