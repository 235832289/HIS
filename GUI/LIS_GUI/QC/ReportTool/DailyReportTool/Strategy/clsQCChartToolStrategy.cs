using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.Text;
using ZedGraph;
namespace com.digitalwave.iCare.gui.LIS
{
    public class clsQCChartToolStrategy
    {
        #region initalParameter
        PrintDocument m_printDoc;
        PrintDialog m_printDlg;
        PrintPreviewDialog m_printPrev;
        clsQCChartTool m_objChartPrint;
        clsLISQCChartPrintVO m_objChartInfo = new clsLISQCChartPrintVO();

        internal clsLISQCChartPrintVO ChartInfo
        {
            get { return m_objChartInfo; }
        }

        bool m_blnPrintShowDialog = false;
        public bool PrintWithDialog
        {
            get
            {
                return m_blnPrintShowDialog;
            }
            set
            {
                m_blnPrintShowDialog = value;
            }
        }

        #endregion

        #region 构造函数

        public clsQCChartToolStrategy()
        {
            m_mthInit();
        }
        public clsQCChartToolStrategy(ZedGraphControl zedChart, clsQCBatchNew p_objBatchInfo)
        {
            m_mthInit();
            m_objChartInfo.zedChart = zedChart;
            m_objChartInfo.objBatch = p_objBatchInfo;
        }
        public clsQCChartToolStrategy(ZedGraphControl p_zedChart, clsQCBatchNew p_objBatchInfo, clsLisQCConcentrationVO p_objQCCon)
            : this()
        {
            m_objChartInfo.zedChart = p_zedChart;
            m_objChartInfo.objBatch = p_objBatchInfo;
            m_objChartInfo.objSelectQCCon = p_objQCCon;
        }
        #endregion

        #region Init
        private void m_mthInit()
        {
            m_printDoc = new PrintDocument();
            m_printDoc.DefaultPageSettings.Landscape = false;
            m_objChartPrint = new clsQCChartTool();
            m_printDoc.PrintController = new System.Drawing.Printing.StandardPrintController();
            m_printDoc.BeginPrint += new PrintEventHandler(m_printDoc_BeginPrint);
            m_printDoc.PrintPage += new PrintPageEventHandler(m_printDoc_PrintPage);
            m_printDoc.EndPrint += new PrintEventHandler(m_printDoc_EndPrint);
        }
        #endregion

        #region printDocumentEvent
        private void m_printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_objChartPrint.m_mthInitPrintTool(m_printDoc);
            m_objChartPrint.m_mthBeginPrint(m_objChartInfo);
        }

        private void m_printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_objChartPrint.m_mthPrintPage(e);
        }

        private void m_printDoc_EndPrint(object sender, PrintEventArgs e)
        {
            m_objChartPrint.m_mthEndPrint(e);
        }
        #endregion

        #region publicMethod
        public void m_mthPrintPreview()
        {
            try
            {
                m_printPrev = new PrintPreviewDialog();
                m_printPrev.Document = m_printDoc;
                m_printPrev.ShowDialog();
            }
            catch
            {
                MessageBox.Show("打印预览失败！");
            }
        }

        public void m_mthPrint()
        {
            try
            {
                if (m_blnPrintShowDialog)
                {
                    m_printDlg = new PrintDialog();
                    m_printDlg.Document = m_printDoc;
                    DialogResult dlgRes = m_printDlg.ShowDialog();
                    if (dlgRes == DialogResult.OK)
                    {
                        m_printDoc.Print();
                    }
                }
                else
                {
                    m_printDoc.Print();
                }
            }
            catch
            {
                MessageBox.Show("打印失败！");
            }
        }
        #endregion
    }

    public class clsLISQCChartPrintVO
    {
        /// <summary>
        /// 图形控件
        /// </summary>
        public ZedGraphControl zedChart;
        /// <summary>
        /// 质控数据管理类
        /// </summary>
        public clsQCBatchNew objBatch;
        /// <summary>
        /// 选择浓度
        /// </summary>
        public clsLisQCConcentrationVO objSelectQCCon;
    }
}
