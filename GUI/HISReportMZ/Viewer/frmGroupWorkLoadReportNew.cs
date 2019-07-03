using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmGroupWorkLoadReportNew : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmGroupWorkLoadReportNew()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsControlGroupworkloadnew();
            objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        ///报表格式；1-横向；2-纵向
        /// </summary>
        public string m_strReportStyle = "2";
        /// <summary>
        /// 统计时间；1-结算时间；2-发生时间
        /// </summary>
        public string m_strStatTime = "1";
        /// <summary>
        /// 窗体显示设置
        /// </summary>
        /// <param name="parm1"></param>
        /// <param name="parm2"></param>
        public void m_mthShow(string parm1, string parm2)
        {
            m_strStatTime = parm1.Trim();
            m_strReportStyle = parm2.Trim();
            this.Show();
        }
        private void frmGroupWorkLoadReportNew_Load(object sender, EventArgs e)
        {
            this.m_dwShow.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            if (this.m_strReportStyle == "2")
            {
                this.m_dwShow.DataWindowObject = "d_op_groupworkloadreportnew";
            }
            else
            {
                this.m_dwShow.DataWindowObject = "d_op_groupworkloadreportnew1";
            }
            DataTable m_objTable;
            string strINTERNALFLAG = "-1";
            clsDomainControl_Register domain = new clsDomainControl_Register();
            domain.m_lngGetDeptInfo(out m_objTable, strINTERNALFLAG);
            if (m_objTable != null)
            {
                this.m_cboDept.Items.Clear();
                this.m_cboDept.Item.Add("全部", "1000");
                if (m_objTable.Rows.Count > 0)
                {

                    for (int i1 = 0; i1 < m_objTable.Rows.Count; i1++)
                    {
                        this.m_cboDept.Item.Add(m_objTable.Rows[i1]["deptname_vchr"].ToString(), m_objTable.Rows[i1]["deptid_chr"].ToString());
                    }
                    this.m_cboDept.SelectedIndex = 0;
                }

            }
            m_objTable = null;
            domain.m_lngGetCheckMan(out m_objTable, strINTERNALFLAG);
            if (m_objTable != null)
            {
                this.m_cboCheckMan.Items.Clear();

                if (m_objTable.Rows.Count > 0)
                {
                    this.m_cboCheckMan.Item.Add("全部", "1000");
                    for (int i1 = 0; i1 < m_objTable.Rows.Count; i1++)
                    {
                        this.m_cboCheckMan.Item.Add(m_objTable.Rows[i1]["LASTNAME_VCHR"].ToString(), m_objTable.Rows[i1]["BALANCEEMP_CHR"].ToString());
                    }
                    this.m_cboCheckMan.SelectedIndex = 0;
                }

            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.m_datBegin.Value.ToShortDateString()) > Convert.ToDateTime(this.m_datEnd.Value.ToShortDateString()))
            {
                MessageBox.Show("开始统计时间不能大于统计结束时间!", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
            ((clsControlGroupworkloadnew)this.objController).m_mthBeginStat();
            clsPublic.CloseAvi();
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            this.m_dwShow.PrintProperties.Preview = !this.m_dwShow.PrintProperties.Preview;
            this.m_dwShow.PrintProperties.ShowPreviewRulers = this.m_dwShow.PrintProperties.Preview;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            clsPublic.PrintDialog(this.m_dwShow);
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if (this.m_dwShow.RowCount > 0)
            {
                SaveFileDialog FD = new SaveFileDialog();
                FD.Filter = "Excel 文档|*.xls";
                FD.Title = "导出";
                FD.ShowDialog();

                if (FD.FileName.Trim() != "")
                {
                    this.m_dwShow.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                }
            }
        }
    }
}