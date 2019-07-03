using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 住院科室工作日志(明细)
    /// </summary>
    public partial class frmRptDeptWorkLog_Detail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptDeptWorkLog_Detail()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }           

        #region 变量       
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// 医保身份ID数组
        /// </summary>
        private ArrayList YBPayTypeIDArr = new ArrayList();
        #endregion           
             
        private void frmRptDeptWorkLog_Detail_Load(object sender, EventArgs e)
        {       
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_deptworklog_det";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + this.dwRep.Describe("t_title.text") + "'");
            this.dwRep.PrintProperties.ShowPreviewRulers = true;

            YBPayTypeIDArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("0008"), ";");

            // 病区列表
            clsColumns_VO[] columArr = new clsColumns_VO[]{ new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                                                            new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                                                            new clsColumns_VO("病区名称","deptname_vchr",HorizontalAlignment.Left,130)
                                                          };

            this.txtAREAID.m_strSQL = @"select a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
                                          from t_bse_deptdesc a
                                         where a.status_int = 1 
                                           and a.attributeid = '0000003'";

            this.txtAREAID.m_mthInitListView(columArr);
            this.txtAREAID.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string AreaID = this.txtAREAID.Value.ToString().Trim();
            string CurrDate = this.dteRq1.Value.ToString("yyyy-MM-dd");

            if (AreaID == null || AreaID == "")
            {
                MessageBox.Show("请选择病区。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                this.dwRep.PrintProperties.Preview = false;
                this.dwRep.Modify("t_areaname.text = '" + this.txtAREAID.Text + "'");
                this.dwRep.Modify("t_date.text = '" + CurrDate + "'");
                clsPublic.PlayAvi("findFILE.avi", "正在统计日志信息，请稍候...");
                this.objReport.m_mthRptDeptWorkLog_Det(AreaID, CurrDate, YBPayTypeIDArr, this.dwRep);
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }   
     
    }
}