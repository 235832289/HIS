using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmDiscountStatistic : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public DataTable dtResult = new DataTable();
        public frmDiscountStatistic()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsControlDiscountStiatistic();
            this.objController.Set_GUI_Apperance(this);
        }

        private string _strReportName;
        /// <summary>
        /// 报告名称
        /// </summary>
        public string StrReportName
        {
            get { return _strReportName; }
            set { _strReportName = value; }
        }
        private void frmDiscountStatistic_Load(object sender, EventArgs e)
        {

            this.dtwindow.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            this.dtwindow.DataWindowObject = "d_opdiscountstatistic";
            _strReportName = dtwindow.Describe("t_title.text");
            this.dtwindow.Modify("t_title.text = '" + this.objController.m_objComInfo.m_strGetHospitalTitle() + _strReportName + "'");
            ((clsControlDiscountStiatistic)this.objController).m_GetDepartInfo(ref dtResult);
            
        }

        private void rbDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDoctor.Checked)
            {
                this.buttonXP2.Enabled = false;
            }
            else
            {
                this.buttonXP2.Enabled = true;
            }
        }

        private void rbDepart_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDepart.Checked)
            {
                this.buttonXP1.Enabled = false;
            }
            else
            {
                this.buttonXP1.Enabled = true;
            }
        }

        public string m_strStatDocotr = string.Empty;
        private void buttonXP1_Click(object sender, EventArgs e)
        {
            frmAidChooseDoct m_objForm = new frmAidChooseDoct();
            if (m_objForm.ShowDialog() == DialogResult.OK)
            {
                m_strStatDocotr = m_objForm.DoctIDArr;
            }
            else
            {
                m_strStatDocotr = string.Empty;
            }
        }
        public string m_strDepart = string.Empty;
        private void buttonXP2_Click(object sender, EventArgs e)
        {
            frmAidChooseDepart m_objForm = new frmAidChooseDepart();
            m_objForm.objDiscountStatistic = this;
            if (m_objForm.ShowDialog() == DialogResult.OK)
            {

                this.m_strDepart = m_objForm.DepartID;
            }
            else
            {
                this.m_strDepart = string.Empty;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.m_datBegin.Value.ToShortDateString()) > Convert.ToDateTime(this.m_datEndTime.Value.ToShortDateString()))
            {
                MessageBox.Show("开始统计时间不能大于统计结束时间!", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
            ((clsControlDiscountStiatistic)this.objController).m_thBeginStat();
            clsPublic.CloseAvi();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dtwindow.PrintProperties.Preview = !this.dtwindow.PrintProperties.Preview;
            this.dtwindow.PrintProperties.ShowPreviewRulers = this.dtwindow.PrintProperties.Preview;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dtwindow.RowCount > 0)
            {
                SaveFileDialog FD = new SaveFileDialog();
                FD.Filter = "Excel 文档|*.xls";
                FD.Title = "导出";
                FD.ShowDialog();

                if (FD.FileName.Trim() != "")
                {
                    this.dtwindow.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.PrintDialog(this.dtwindow);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtListView1_TextChanged(object sender, EventArgs e)
        {
            //if (this.txtListView1.SelectedItem != null)
            //{
            //    this.lbID.Text = this.txtListView1.SelectedItem[0].ToString();
            //}
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsControlDiscountStiatistic)this.objController).m_GetItem();
            } 
        }

    }
}