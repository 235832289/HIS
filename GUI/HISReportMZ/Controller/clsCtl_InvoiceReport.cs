using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
//using CrystalDecisions.CrystalReports.Engine;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsCtl_InvoiceReport: com.digitalwave.GUI_Base.clsController_Base
    {
        clsDcl_InvoiceReport m_objMain = null;
        public clsCtl_InvoiceReport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objMain = new clsDcl_InvoiceReport();
        }
        /// <summary>
        /// 窗体对象
        /// </summary>

        frmRptNOCheckOutInvoice m_objViewerCollect;

        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewerCollect = (frmRptNOCheckOutInvoice)frmMDI_Child_Base_in;
        }

        /// <summary>
        /// 门诊未日结汇总报表
        /// </summary>
        public void m_intGetNOCheckOutInvoice()
        {
            DataTable p_dtResult = new DataTable();
            string startDate = this.m_objViewerCollect.dtm_start.Value.ToShortDateString() + " 00:00:00";
            string endDate = this.m_objViewerCollect.dtm_end.Value.ToShortDateString() + " 23:59:59";
            this.m_objViewerCollect.dataWindowControl1.Modify("t_start.text='" + this.m_objViewerCollect.dtm_start.Value.ToShortDateString() + "'");
            this.m_objViewerCollect.dataWindowControl1.Modify("t_end.text='" + this.m_objViewerCollect.dtm_end.Value.ToShortDateString() + "'");
            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在查询数据，请稍候...");
                long lngRes = this.m_objMain.m_lngGetNOCheckOutInvoice(startDate,endDate,out p_dtResult);
                if (lngRes > 0)
                {
                    if (p_dtResult.Rows.Count > 0)
                    {
                        m_objViewerCollect.dataWindowControl1.SetRedrawOff();
                        m_objViewerCollect.dataWindowControl1.Retrieve(p_dtResult);
                        m_objViewerCollect.dataWindowControl1.Sort();
                        m_objViewerCollect.dataWindowControl1.CalculateGroups();
                        m_objViewerCollect.dataWindowControl1.SetRedrawOn();
                        m_objViewerCollect.dataWindowControl1.Refresh();
                    }

                    if (p_dtResult.Rows.Count <= 0)
                    {
                        MessageBox.Show("抱歉，没有找到对应的项目记录!", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
    }
}