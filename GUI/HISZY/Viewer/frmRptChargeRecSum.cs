using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 住院结算方式汇总报表(按日结)UI类
    /// </summary>
    public partial class frmRptChargeRecSum : Form //: com.digitalwave.GUI_Base.frmMDI_Child_Base
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
        public frmRptChargeRecSum()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        ///// <summary>
        ///// 外部接口(全院发票分类统计报表)
        ///// </summary>
        //public void mthShow()
        //{
        //    //RepType = 1;
        //    this.Show();
        //}

        private void frmRptChargeRecSum_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_chargerecsum";
            this.dwRep.InsertRow(0);           
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


        #region 外部接口

        internal string str_parmval = "";
        /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="ParmVal"></param>
       public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            this.Show();
        }
        #endregion

        private void btnStat_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dteBegin.Value.ToString("yyyy-MM-dd"), this.dteEnd.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
            string BeginDate = this.dteBegin.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteEnd.Value.ToString("yyyy-MM-dd");
                        
            clsPublic.PlayAvi("findFILE.avi", "正在汇总日结费用，请稍候...");            
            this.objReport.m_mthRptChargeRecSum(BeginDate, EndDate, 0, this.dwRep);
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