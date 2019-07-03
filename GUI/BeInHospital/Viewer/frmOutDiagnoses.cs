using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOutDiagnoses : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        /// <summary>
        /// ฟฦสาIDสýื้
        /// </summary>
        internal ArrayList m_deptIDArr = new ArrayList();

        public frmOutDiagnoses()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlOutDiagnoses();
            objController.Set_GUI_Apperance(this);
        }

        private void frmOutDiagnoses_Load(object sender, EventArgs e)
        {
            this.m_dwOutDiagnoses.LibraryList = Application.StartupPath + "\\pb_new.pbl";
            this.m_dwOutDiagnoses.DataWindowObject = "d_out_diagnoses";
            this.m_dwOutDiagnoses.PrintProperties.ShowPreviewRulers = true;
            this.m_dwOutDiagnoses.PrintProperties.Preview = true;
        }

        private void m_buttonFind_Click(object sender, EventArgs e)
        {
            ((clsCtlOutDiagnoses)this.objController).ButtonFind_Click();
            this.m_dwOutDiagnoses.PrintProperties.ShowPreviewRulers = true;
            this.m_dwOutDiagnoses.PrintProperties.Preview = true;
        }

        private void m_checkBoxArea_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_checkBoxArea.Checked == true)
            {
                frmAidDeptList fDept = new frmAidDeptList();
                if (fDept.ShowDialog() == DialogResult.OK)
                {
                    m_deptIDArr = fDept.DeptIDArr;
                }
            }
        }

        private void m_ckbType_CheckedChanged(object sender, EventArgs e)
        {
            this.m_dwOutDiagnoses.SetRedrawOff();
            if (this.m_ckbType.Checked == true)
            {
                this.m_dwOutDiagnoses.SetFilter("t_opr_bih_leave_diseasetype_int = 1");
                this.m_dwOutDiagnoses.Filter();
            }
            else
            {
                this.m_dwOutDiagnoses.SetFilter("1 = 1");
                this.m_dwOutDiagnoses.Filter();
            }

            this.m_dwOutDiagnoses.Sort();
            this.m_dwOutDiagnoses.CalculateGroups();
            this.m_dwOutDiagnoses.SetRedrawOn();
            this.m_dwOutDiagnoses.Refresh();
        }

        private void m_buttonPrint_Click(object sender, EventArgs e)
        {
            this.m_dwOutDiagnoses.Print(true);
        }

        private void m_buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOutDiagnoses_KeyDown(object sender, KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            if (this.m_dwOutDiagnoses.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.m_dwOutDiagnoses, null);
            }
        }
    }
}