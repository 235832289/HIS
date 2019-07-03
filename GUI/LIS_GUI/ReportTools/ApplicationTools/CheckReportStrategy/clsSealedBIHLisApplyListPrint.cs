using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Collections.Generic;
using System.Collections;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// 住院检验申请列表打印
	/// </summary>
	public class clsSealedBIHLisApplyListPrint
	{
		#region initalParameter
		PrintDocument m_printDoc;
		PrintDialog m_printDlg=new PrintDialog();
		PrintPreviewDialog m_printPrev;
        clsBIHApplyListPrintTool m_objReportPrint;
        clsBIHLisPrintVO m_objPrint = null;
        

		bool m_blnPrintShowDialog = false;
		public bool m_BlnPrintWithDialog
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
        public clsSealedBIHLisApplyListPrint(clsBIHLisPrintVO m_objPrint) 
        {
            this.m_objPrint = m_objPrint;
            m_mthInit();
        }
		#endregion

		#region Init
		private void m_mthInit()
		{
			m_printDoc = new PrintDocument();
			m_objReportPrint = new clsBIHApplyListPrintTool();
			m_printDoc.PrintController = new System.Drawing.Printing.StandardPrintController();
			m_printDoc.BeginPrint +=new PrintEventHandler(m_printDoc_BeginPrint);
			m_printDoc.PrintPage +=new PrintPageEventHandler(m_printDoc_PrintPage);
			m_printDoc.EndPrint +=new PrintEventHandler(m_printDoc_EndPrint);
		}
		#endregion

		#region SetPrintContent
        private void m_mthGetPrintCount(clsBIHLisPrintVO m_objPrint) 
        {
            
        }
		#endregion

		#region printDocumentEvent
		private void m_printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_objReportPrint.m_mthInitPrintTool(m_printDoc);
            if (m_objPrint != null && m_objPrint.dictReportPrint != null && m_objPrint.dictReportPrint.Count>0)
            {
                m_objReportPrint.m_mthBeginPrint(this.m_objPrint);
            }
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
                //if ( m_printDlg.ShowDialog()==DialogResult.OK)
                //{
                m_printPrev = new PrintPreviewDialog();
                ((Form)m_printPrev).WindowState = FormWindowState.Maximized;
                m_printPrev.PrintPreviewControl.Zoom = 1;
                m_printPrev.Document = m_printDoc;
                m_printPrev.ShowDialog();
                //}
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
				if(m_blnPrintShowDialog)
				{
					m_printDlg = new PrintDialog();
					m_printDlg.Document = m_printDoc;
					DialogResult dlgRes = m_printDlg.ShowDialog();
					if(dlgRes == DialogResult.OK)
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

    /// <summary>
    /// 住院列表打印
    /// </summary>
    public class clsBIHLisPrintVO 
    {
        public DateTime m_dtStart;
        public DateTime m_dtEnd;
        public string m_strApplDept;
        public Dictionary<clsLisApplMainVO, string> dictReportPrint;
    }
}
