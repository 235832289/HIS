using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmRptCriticalVal : Form
    {
        public frmRptCriticalVal()
        {
            InitializeComponent();
        }

        string DeptIdArr { get; set; }

        bool IsYG { get; set; }

        private void frmRptCriticalVal_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_criticalvalue";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            if (this.IsYG) this.dwRep.Modify("t_title.text = '" + "多重耐药菌记录汇总表" + "'");
        }

        public void Show2()
        {
            this.IsYG = true;
            this.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在统计危急值信息，请稍候...");
                dwRep.Reset();
                bizCriticalValue svc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
                List<EntityCriReport> lstRpt = svc.GetCriReport(Convert.ToDateTime(BeginDate + " 00:00:00"), Convert.ToDateTime(EndDate + " 23:59:59"), (this.chkDept.Checked ? this.DeptIdArr : ""), this.IsYG);
                if (lstRpt != null && lstRpt.Count > 0)
                {
                    int row = 0;
                    dwRep.SetRedrawOff();
                    foreach (EntityCriReport item in lstRpt)
                    {
                        row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "recorddata", item.recorddata);
                        dwRep.SetItemString(row, "patname", item.patname);
                        dwRep.SetItemString(row, "ipno", item.ipno);
                        dwRep.SetItemString(row, "deptname", item.deptname);
                        dwRep.SetItemString(row, "bedno", item.bedno);
                        dwRep.SetItemString(row, "reportname", item.reportname);
                        dwRep.SetItemString(row, "reportdept", item.reportdept);
                        dwRep.SetItemString(row, "reportmin", item.reportmin);
                        dwRep.SetItemString(row, "responser", item.responser);
                        dwRep.SetItemString(row, "responsedate", item.responsedate);
                        dwRep.SetItemString(row, "crivalue", item.crivalue);
                        dwRep.SetItemString(row, "responsemsg", item.responsemsg);
                        dwRep.SetItemString(row, "doctadvicemsg", item.doctadvicemsg);
                        if (item.crivalue.Contains("耐药菌结果") && item.reportmin.Contains("00:00"))
                        {
                            item.upper10Min = 0;
                        }
                        dwRep.SetItemString(row, "moretan10", item.upper10Min.ToString() == "0" ? "" : item.upper10Min.ToString());
                    }
                    dwRep.SetRedrawOn();
                }
                else
                {
                    dwRep.InsertRow(0);
                }
                dwRep.Modify("t_date.text = '" + BeginDate + " ~ " + EndDate + "'");
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsVolDatawindowToExcel[] volExcel = new clsVolDatawindowToExcel[2];

                volExcel[0] = new clsVolDatawindowToExcel(1);
                volExcel[0].m_rowheight[0] = 20;
                volExcel[0].m_title_text[0] = this.dwRep.Describe("t_title.text");
                volExcel[0].m_HorizontalAlignment[0] = "0";
                volExcel[0].m_firstcommn[0] = "A1";
                volExcel[0].m_endcommn[0] = "ALL";

                volExcel[1] = new clsVolDatawindowToExcel(1);
                volExcel[1].m_rowheight[0] = 20;
                volExcel[1].m_title_text[0] = this.dwRep.Describe("t_date.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_firstcommn[0] = "B1";
                volExcel[1].m_endcommn[0] = "ALL";

                clsPublic.ExportDataWindow(this.dwRep, volExcel);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnByDept_Click(object sender, EventArgs e)
        {
            frmAidChooseDept fDept = new frmAidChooseDept();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                this.DeptIdArr = fDept.DeptIDArr;
            }
        }
    }
}
