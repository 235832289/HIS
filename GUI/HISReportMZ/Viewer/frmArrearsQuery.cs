using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmArrearsQuery : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public string m_strQueryType = "欠费病人";
        public frmArrearsQuery()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new clsCtlArrearsQuery();
            objController.Set_GUI_Apperance(this);
        }

        private void frmArrearsQuery_Load(object sender, EventArgs e)
        {
            ((clsCtlArrearsQuery)this.objController).m_mthLoad();
        }

        public void m_mthShow(string p_strValue)
        {
            if (p_strValue == "0")
            {
                m_strQueryType = "0";
            }
            else if (p_strValue == "1")
            {
                m_strQueryType = "1";
                this.Text = "缴费（补欠款）病人查询";
            }
            else if (p_strValue == "2")
            {
                m_strQueryType = "2";
            }
            this.Show();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ((clsCtlArrearsQuery)this.objController).m_mthQueryArrearsPatient();
        }

        private void datStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.datStartDate.Value > this.datEndDate.Value)
            {
                MessageBox.Show("提示：开始日期大于结束日期！");
            }
        }

        private void frmArrearsQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("确认退出吗?", "iCare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmArrearsQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            clsPublic.PrintDialog(this.dwRpt);//.ChoosePrintDialog(this.dwRpt, true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRpt.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRpt);
            }
        }
    }
}