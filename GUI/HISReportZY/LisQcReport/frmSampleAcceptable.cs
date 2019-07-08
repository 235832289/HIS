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
    public partial class frmSampleAcceptable : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmSampleAcceptable()
        {
            InitializeComponent();
        }

        #region
        /// <summary>
        /// 窗体设计器
        /// </summary>
        private clsCtl_SampleAccetable m_objController;
        public string DeptIdArr = string.Empty;

        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_SampleAccetable();
            this.m_objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 事件

        private void frmSampleAcceptable_Load(object sender, EventArgs e)
        {
            m_objController.m_mthInti();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;

            //"检验标本周转中位数统计表", "检验标本周转中位数明细" 

            if (intTem == 0)
            {
                m_objController.m_mthGeSampleAcceptable();
            }
            if (intTem == 1)
            {
                m_objController.m_mthGeSampleAcceptableDetail();
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

                    dgvCheckItem.Rows.Add(value);
                }
            }

            //this.tabContorl.Visible = false;
        }


        private void tabColse_Click(object sender, EventArgs e)
        {
            this.tabContorl.Visible = false;
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            m_objController.m_mthGetCheckItemByName();
        }

        private void cbxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择检验项目";
            m_objController.m_mthListCheckItem();
        }

        private void cbxGroup_MouseDown(object sender, MouseEventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择检验项目";
            m_objController.m_mthListCheckItem();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;

            //"检验标本周转中位数统计表", "检验标本周转中位数汇总" 

            if (intTem == 0)
            {
                m_objController.m_mthExportToExcel();
            }
            if (intTem == 1)
            {
                m_objController.m_mthExportToExcel2();
            }
        }

        private void btnExite_Click(object sender, EventArgs e)
        {
            m_objController.Closed();
        }

        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            m_objController.Clear();
        }

        private void cboStatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;

            if (intTem == 0)
            {
                this.dgvdata.Visible = true;
                this.dgvStat.Visible = false;
            }
            if (intTem == 1)
            {
                this.dgvdata.Visible = false;
                this.dgvStat.Visible = true;
            }
        }

        private void btnTabClose_Click(object sender, EventArgs e)
        {
            this.tabContorl.Visible = false;
        }

        private void dgvStat_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (dgvStat.Rows.Count > 0)
                {
                    if (e.RowIndex <= dgvStat.Rows.Count - 1)
                    {
                        DataGridViewRow dgrSingle = dgvStat.Rows[e.RowIndex];

                        if (dgrSingle.Cells["acceptFlg"].Value.ToString().Contains("F"))
                        {
                            dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvStat_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();  
        }
    }
}
