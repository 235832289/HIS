using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 全院缴款分类报表UI类
    /// </summary>
    public partial class frmRptIncomeClass : Form //: com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// 报表类型 0 缴款分类(已结) 1 发票分类(所有)
        /// </summary>
        private int RepType = 0;
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmRptIncomeClass()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        /// <summary>
        /// 外部接口(全院发票分类统计报表)
        /// </summary>
        internal string str_parmval = "";
        public void mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            RepType = 1;
            this.Show();
        }

        private void frmRptIncomeClass_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_incomeclass";
            this.dwRep.InsertRow(0);

            if (RepType == 0)
            {
                dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + "住院缴款分类报表'");                
            }
            else if (RepType == 1)
            {
                dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + "住院发票分类报表'");

                this.Text = "住院发票分类报表";
                this.lblDate.Text = "发票日期：从";
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

        private void btnStat_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dteBegin.Value.ToString("yyyy-MM-dd"), this.dteEnd.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
            string BeginDate = this.dteBegin.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteEnd.Value.ToString("yyyy-MM-dd");
                        
            clsPublic.PlayAvi("findFILE.avi", "正在生成费用清单，请稍候...");            
            this.objReport.m_mthRptIncomeClass(BeginDate, EndDate, RepType, this.dwRep);
            clsPublic.CloseAvi();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }    
}