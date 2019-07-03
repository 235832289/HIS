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
    public partial class frmPmpctStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmPmpctStat()
        {
            InitializeComponent();
        }

        #region
        /// <summary>
        /// 窗体设计器
        /// </summary>
        private clsCtl_PmpctStat m_objController;
        public string DeptIdArr = string.Empty;

        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_PmpctStat();
            this.m_objController.Set_GUI_Apperance(this);
        }
        #endregion


        private void frmPmpctStat_Load(object sender, EventArgs e)
        {
            m_objController.m_mthInit();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;

            if (intTem == 0)
            {
                m_objController.m_mthGetPmpctStat(); 
            }

            if (intTem == 1)
            {
                m_objController.m_mthGetPmpctDetail();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;

            if(intTem == 0)
                m_objController.m_mthExportToExcel(intTem,this.dgvData);
            else
                m_objController.m_mthExportToExcel(intTem, this.dgvDetail);
        }

        private void cboStatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intTem = this.cboStatType.SelectedIndex;

            if (intTem == 0)
            {
                this.dgvData.Visible = true;
                this.dgvDetail.Visible = false;
            }
            if (intTem == 1)
            {
                this.dgvData.Visible = false;
                this.dgvDetail.Visible = true;
            }
        }

        private void dgvDetail_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //显示在HeaderCell上
            for (int i = 0; i < this.dgvDetail.Rows.Count; i++)
            {
                DataGridViewRow r = this.dgvDetail.Rows[i];
                r.HeaderCell.Value = string.Format("{0}", i + 1);
            }
            this.dgvDetail.Refresh();
        }

        private void btnExite_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
