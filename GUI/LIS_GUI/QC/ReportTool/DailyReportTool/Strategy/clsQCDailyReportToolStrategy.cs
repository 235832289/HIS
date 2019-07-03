using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// clsSealedLisApplyReportPrint 的摘要说明。
    /// </summary>
    public class clsQCDailyReportToolStrategy
    {
        #region initalParameter
        PrintDocument m_printDoc;
        PrintDialog m_printDlg;
        PrintPreviewDialog m_printPrev;
        clsQCDailyReportTool m_objReportPrint;
        clsLISQCDailyReportPrintVO m_objReportInfo = new clsLISQCDailyReportPrintVO();

        public clsLISQCDailyReportPrintVO ReportInfo
        {
            get { return m_objReportInfo; }
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
        public clsQCDailyReportToolStrategy()
        {
            m_mthInit();
        }
        public clsQCDailyReportToolStrategy(clsLisQCReportVO objReportInfo,clsLisQCBatchVO objBaseInfo)
        {
            m_mthInit();
            this.m_objReportInfo.objReportInfo = objReportInfo;
            this.m_objReportInfo.objBaseInfo = objBaseInfo;
        }
        #endregion

        #region Init
        private void m_mthInit()
        {
            m_printDoc = new PrintDocument();
            m_objReportPrint = new clsQCDailyReportTool();
            m_printDoc.PrintController = new System.Drawing.Printing.StandardPrintController();
            m_printDoc.BeginPrint += new PrintEventHandler(m_printDoc_BeginPrint);
            m_printDoc.PrintPage += new PrintPageEventHandler(m_printDoc_PrintPage);
            m_printDoc.EndPrint += new PrintEventHandler(m_printDoc_EndPrint);
        }
        #endregion

        #region printDocumentEvent
        private void m_printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_objReportPrint.m_mthInitPrintTool(m_printDoc);
            m_objReportPrint.m_mthBeginPrint(m_objReportInfo);
        }

        private void m_printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_objReportPrint.m_mthPrintPage(e);
        }

        private void m_printDoc_EndPrint(object sender, PrintEventArgs e)
        {
            m_objReportPrint.m_mthEndPrint(e);
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
    public class clsLISQCDailyReportPrintVO
    {
        public clsLisQCReportVO objReportInfo;
        public clsLisQCBatchVO objBaseInfo;
    }
}
