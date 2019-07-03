using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS.Reports;
using com.digitalwave.iCare.gui.HIS.Reports.Controller;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmCuremedStatment : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmCuremedStatment()
        {
            InitializeComponent();
        }

        private void frmCuremedStatment_Load(object sender, EventArgs e)
        {
            m_objController.m_mthInit();
        }

        /// <summary>
        /// 变量
        /// </summary>
        public string DeptIdArr = string.Empty;
        DataGridViewPrint dp;

        

        #region
        /// <summary>
        /// 窗体设计器
        /// </summary>
        private clsCtl_CuremedStatment m_objController;

        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_CuremedStatment();
            this.m_objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void btnStat_Click(object sender, EventArgs e)
        {
            m_objController.m_mthGetCureMedStatment();
        }

        private void btnByDept_Click(object sender, EventArgs e)
        {
            frmByDept frmAidChooseDept = new frmByDept(1);

            if (frmAidChooseDept.ShowDialog() == DialogResult.OK)
            {
                this.DeptIdArr = frmAidChooseDept.DeptIDArr;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //显示打印对话框
            PrintDialog MyDlg = new PrintDialog();
            MyDlg.Document = this.printDoc;
            if (MyDlg.ShowDialog().Equals(DialogResult.OK))
            {
                //显示打印预览对话框
                dp = new DataGridViewPrint(this.dgvData, this.printDoc, true, true, "疗程用药汇总","", new System.Drawing.Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
                PrintPreviewDialog a = new PrintPreviewDialog();
                a.Document = this.printDoc;
                a.ShowDialog();
            }
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //true表示还有数据行没有打印完,则继续打
            if (dp.DrawDataGridView(e.Graphics))
            {
                //附加打印页
                e.HasMorePages = true;
            }
            else
            {
                DataGridViewPrint.PageNumber = 0;
                DataGridViewPrint.mColumnPoints.Clear();
                DataGridViewPrint.mColumPointsWidth.Clear();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.m_objController.m_mthExportToExcel();
        }

        private void btnExite_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
