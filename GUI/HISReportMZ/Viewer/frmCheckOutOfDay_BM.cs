using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.common;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmCheckOutOfDay_BM : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal string m_rptId;

        /// <summary>
        /// 模式：0为结帐模式，1为查询模式
        /// </summary>
        internal int m_intMode = 0;

        public frmCheckOutOfDay_BM()
        {
            InitializeComponent();
        }

        public void ShowWithParm(string p_rptId)
        {
            this.m_rptId = p_rptId;
            this.Show();
        }

        public void ShowForQuery(string p_rptId)
        {
            this.m_rptId = p_rptId;
            m_intMode = 1;
            this.Show();
        }

        /// <summary>
        /// 设置窗体对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtlCheckOutOfDay_BM();
            this.objController.Set_GUI_Apperance(this);
        }

        private void frmCheckOutOfDayNew_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            starDate.Value = Convert.ToDateTime(starDate.Value.Year.ToString() + "-" + starDate.Value.Month.ToString() + "-" + "01");
            //if (isDoctorDean == true)
            //{
            //    DataTable dtBalanceemp = new DataTable();
            //    clsDomainControl_Register domain = new clsDomainControl_Register();
            //    domain.m_lngReturnAllBALANCEEMP(out dtBalanceemp);
            //    if (dtBalanceemp.Rows.Count > 0)
            //    {
            //        for (int i1 = 0; i1 < dtBalanceemp.Rows.Count; i1++)
            //        {
            //            m_cboCheckMan.Item.Add(dtBalanceemp.Rows[i1]["LASTNAME_VCHR"].ToString(), dtBalanceemp.Rows[i1]["BALANCEEMP_CHR"].ToString());
            //        }
            //    }
            //}
            //Hospital_No = this.objController.m_objComInfo.m_mthGetHospitalNo();

            //this.ctlprintShow2.IsShowClose = false;
            //ctlprintShow2.setDocument = printDocument1;
            this.m_dwShow.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            //((clsCtlCheckOutOfDay_BM)this.objController).m_mthGetParameters();
            if (m_intMode == 0)
            {
                groupBox1.Visible = true;
                groupBox4.Visible = false;
                groupBox2.Visible = true;
                ((clsCtlCheckOutOfDay_BM)this.objController).Reset();
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox4.Visible = true;
                DataTable dt;
                clsDomainControl_Register domain = new clsDomainControl_Register();
                domain.m_lngGetCheckMan(out dt, "0");
                if (dt != null)
                {
                    this.m_cboCheckMan.Items.Clear();

                    if (dt.Rows.Count > 0)
                    {
                        this.m_cboCheckMan.Item.Add("全部", "1000");
                        for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                        {
                            this.m_cboCheckMan.Item.Add(dt.Rows[i1]["LASTNAME_VCHR"].ToString(), dt.Rows[i1]["BALANCEEMP_CHR"].ToString());
                        }
                        this.m_cboCheckMan.SelectedIndex = 0;
                    }

                }
            }
            this.Cursor = Cursors.Default;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ((clsCtlCheckOutOfDay_BM)this.objController).Reset();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("注意：结帐后不能修改数据，是否要结帐？", "Icare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ((clsCtlCheckOutOfDay_BM)this.objController).CheckData();
            }
        }

        private void ctlDgFind_m_evtClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (ctlDgFind.CurrentCell.RowNumber == e.m_intRowNumber)
            {
                ((clsCtlCheckOutOfDay_BM)this.objController).dgSelect();
            }
            //ctlprintShow2.Tag = "printDocument1";
        }

        private void ctlDgFind_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsCtlCheckOutOfDay_BM)this.objController).dgSelect();
        }

        private void starDate_ValueChanged(object sender, EventArgs e)
        {
            ((clsCtlCheckOutOfDay_BM)this.objController).FindHistory();
        }

        private void EndDate_ValueChanged(object sender, EventArgs e)
        {
            ((clsCtlCheckOutOfDay_BM)this.objController).FindHistory();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //this.m_dwShow.Print();
            PrintDialog pDiag = new PrintDialog();
            if (pDiag.ShowDialog() == DialogResult.OK)
            {
                this.m_dwShow.PrintProperties.PrinterName = pDiag.PrinterSettings.PrinterName;
                this.m_dwShow.Print();
            }
            pDiag = null;
        }

        private void m_btnStat_Click(object sender, EventArgs e)
        {
            ((clsCtlCheckOutOfDay_BM)this.objController).GetData();
        }
    }
}