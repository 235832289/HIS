using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品出库
    /// </summary>
    public class clsDcl_Public : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        /// <summary>
        /// 获取服务器当前时间
        /// </summary>        
        public long m_lngGetSysDateTimeNow(out DateTime p_dtmDateTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSystemDateTime(out p_dtmDateTime);
            return lngRes;
        }

        public long m_lngGetDrugStoreName(string m_strStorageID, out string m_strRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetDrugStoreRoomName(objPrincipal, m_strStorageID, out m_strRoomName);
            return lngRes;
        }

        public long m_lngGetStoreName(string m_strStorageID, out string m_strRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStorageRoomName(objPrincipal, m_strStorageID, out m_strRoomName);
            return lngRes;
        }

        public long m_lngGetCurrentDateTime(out DateTime p_dtmDateTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetCurrentDateTime(out p_dtmDateTime);
            return lngRes;
        }

        #region 选择打印机打印

        /// <summary>
        /// 选择打印机打印

        /// </summary>
        /// <param name="DW">数据窗口</param>
        /// <param name="ShowPrintDialog">True 显示打印对话窗口 False 不显示打印对话窗口</param>
        public void ChoosePrintDialog(Sybase.DataWindow.DataWindowControl DW, bool ShowPrintDialog)
        {
            PrintDialog pDiag = new PrintDialog();
            pDiag.UseEXDialog = true;
            pDiag.AllowSomePages = true;
            pDiag.AllowCurrentPage = true;
            if (pDiag.ShowDialog() == DialogResult.OK)
            {
                DW.PrintProperties.PrinterName = pDiag.PrinterSettings.PrinterName;

                if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                {
                    DW.PrintProperties.PageRange = pDiag.PrinterSettings.FromPage.ToString() + "-" + pDiag.PrinterSettings.ToPage.ToString();
                }
                else if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.CurrentPage)
                {
                    int intRow = DW.FirstRowOnPage;
                    string strTemp = DW.Describe("evaluate('pageabs()'," + intRow.ToString() + ")");
                    DW.PrintProperties.PageRange = strTemp;
                }

                DW.Print(ShowPrintDialog);
            }
            pDiag = null;
        }
        #endregion

        #region 选择打印机打印(datsto)
        /// <summary>
        /// 选择打印机打印(datsto)
        /// </summary>
        /// <param name="DW">数据窗口</param>
        /// <param name="ShowPrintDialog">True 显示打印对话窗口 False 不显示打印对话窗口</param>

        public void ChoosePrintDialog_DataStore(Sybase.DataWindow.DataStore datasto, bool ShowPrintDialog)
        {
            PrintDialog pDiag = new PrintDialog();
            pDiag.UseEXDialog = true;
            pDiag.AllowSomePages = true;
            pDiag.AllowCurrentPage = true;
            if (pDiag.ShowDialog() == DialogResult.OK)
            {
                datasto.PrintProperties.PrinterName = pDiag.PrinterSettings.PrinterName;

                if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                {
                    datasto.PrintProperties.PageRange = pDiag.PrinterSettings.FromPage.ToString() + "-" + pDiag.PrinterSettings.ToPage.ToString();
                }
                else if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.CurrentPage)
                {
                    int intRow = datasto.CurrentRow;
                    string strTemp = datasto.Describe("evaluate('pageabs()'," + intRow.ToString() + ")");
                    datasto.PrintProperties.PageRange = strTemp;
                }
                datasto.Print(ShowPrintDialog);
            }
            pDiag = null;
        }
        #endregion

        #region 数据窗口DataWindow/DataStore导出成HTML,再转成EXCEL
        /// <summary>
        /// 数据窗口DataWindow/DataStore导出成HTML,再转成EXCEL
        /// </summary>
        /// <param name="DW"></param>
        /// <param name="volExcel"></param>
        public static void ExportDataWindow(Sybase.DataWindow.DataWindowControl DW, clsVolDatawindowToExcel[] volExcel)
        {
            SaveFileDialog FD = new SaveFileDialog();
            FD.Filter = "Excel 文档|*.xls";
            FD.Title = "导出";
            FD.ShowDialog();
            string filename = FD.FileName.Trim();

            if (filename != "")
            {
                DW.SaveAs(filename, Sybase.DataWindow.FileSaveAsType.HtmlTable, false, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                if (volExcel != null)
                {
                    //定义
                    object MissingValue = Type.Missing;

                    Excel.Application Excel_app = new Excel.ApplicationClass();
                    //打开Excel文挡
                    Excel.Workbook Excel_work = Excel_app.Workbooks.Open(filename, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue);
                    //获取当前工作列表
                    Excel.Worksheet mySheet = (Excel.Worksheet)Excel_work.Worksheets[1];

                    for (int i = volExcel.Length - 1; i >= 0; i--)
                    {
                        Excel.Range range = null;
                        range = (Excel.Range)mySheet.Rows.get_Item(1, Type.Missing);
                        //在顶行插入空行

                        range.Rows.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                        for (int j = 0; j < volExcel[i].m_title_text.Length; j++)
                        {
                            //合并行

                            if (volExcel[i].m_endcommn[j] == "ALL")
                            {
                                range = mySheet.get_Range(volExcel[i].m_firstcommn[j], mySheet.Cells[1, mySheet.UsedRange.Columns.Count]);
                            }
                            else
                            {
                                range = mySheet.get_Range(volExcel[i].m_firstcommn[j], volExcel[i].m_endcommn[j]);
                            }
                            range.Merge(MissingValue);

                            range.Value2 = volExcel[i].m_title_text[j];
                            if (volExcel[i].m_HorizontalAlignment[j] == "0")
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            }
                            else if (volExcel[i].m_HorizontalAlignment[j] == "L")
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            }
                            else
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                            range.RowHeight = volExcel[i].m_rowheight[j];
                        }

                    }

                    mySheet.UsedRange.Rows.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    mySheet = null;
                    Excel_app.ActiveWorkbook.Close(true, filename.ToString(), null);
                    Excel_app.Workbooks.Close();
                    Excel_app.Quit();
                    Excel_app = null;
                }
            }
        }
        /// <summary>
        /// 数据窗口DataWindow/DataStore导出成HTML,再转成EXCEL
        /// </summary>
        /// <param name="DS"></param>
        /// <param name="volExcel"></param>
        public static void ExportDataStore(Sybase.DataWindow.DataStore DS, clsVolDatawindowToExcel[] volExcel)
        {
            SaveFileDialog FD = new SaveFileDialog();
            FD.Filter = "Excel 文档|*.xls";
            FD.Title = "导出";
            FD.ShowDialog();
            string filename = FD.FileName.Trim();

            if (filename != "")
            {
                DS.SaveAs(filename, Sybase.DataWindow.FileSaveAsType.HtmlTable, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                if (volExcel != null)
                {

                    //定义
                    object MissingValue = Type.Missing;
                    Excel.Application Excel_app = new Excel.ApplicationClass();

                    //打开Excel文挡
                    Excel.Workbook Excel_work = Excel_app.Workbooks.Open(filename, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue);
                    //获取当前工作列表
                    Excel.Worksheet mySheet = (Excel.Worksheet)Excel_work.Worksheets[1];

                    for (int i = volExcel.Length - 1; i >= 0; i--)
                    {
                        Excel.Range range = null;
                        range = (Excel.Range)mySheet.Rows.get_Item(1, Type.Missing);
                        //在顶行插入空行

                        range.Rows.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                        for (int j = 0; j < volExcel[i].m_title_text.Length; j++)
                        {
                            //合并行

                            if (volExcel[i].m_endcommn[j] == "ALL")
                            {
                                range = mySheet.get_Range(volExcel[i].m_firstcommn[j], mySheet.Cells[1, mySheet.UsedRange.Columns.Count]);
                            }
                            else
                            {
                                range = mySheet.get_Range(volExcel[i].m_firstcommn[j], volExcel[i].m_endcommn[j]);
                            }
                            range.Merge(MissingValue);

                            range.Value2 = volExcel[i].m_title_text[j];
                            if (volExcel[i].m_HorizontalAlignment[j] == "0")
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            }
                            else if (volExcel[i].m_HorizontalAlignment[j] == "L")
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            }
                            else
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                            range.RowHeight = volExcel[i].m_rowheight[j];
                        }

                    }

                    mySheet.UsedRange.Rows.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    mySheet = null;
                    Excel_app.ActiveWorkbook.Close(true, filename.ToString(), null);
                    Excel_app.Workbooks.Close();
                    Excel_app.Quit();
                    Excel_app = null;
                }
            }
        }
        #endregion

        #region 数据窗口DataWindow/DataStore预览打印
        /// <summary>
        /// DataWindow预览打印
        /// </summary>
        /// <param name="DW"></param>
        public static void PrintDialog(Sybase.DataWindow.DataWindowControl DW)
        {
            frmPrint PrintDialog = new frmPrint(DW);
            PrintDialog.ShowDialog();
        }
        /// <summary>
        /// DataWindow预览打印
        /// </summary>
        /// <param name="DW"></param>
        /// <param name="BlnChoosePrinter"></param>
        public static void PrintDialog(Sybase.DataWindow.DataWindowControl DW, bool BlnChoosePrinter, ArrayList OnlyPriviewCtlArr)
        {
            frmPrint PrintDialog = new frmPrint(DW, BlnChoosePrinter, OnlyPriviewCtlArr);
            PrintDialog.ShowDialog();
        }
        /// <summary>
        /// DataStore预览打印
        /// </summary>
        /// <param name="DS"></param>
        public static void PrintDialog(Sybase.DataWindow.DataStore DS)
        {
            frmPrint PrintDialog = new frmPrint(DS);
            PrintDialog.ShowDialog();
        }
        /// <summary>
        /// DataStore预览打印
        /// </summary>
        /// <param name="DS"></param>
        /// <param name="BlnChoosePrinter"></param>
        public static void PrintDialog(Sybase.DataWindow.DataStore DS, bool BlnChoosePrinter, ArrayList OnlyPriviewCtlArr)
        {
            frmPrint PrintDialog = new frmPrint(DS, BlnChoosePrinter, OnlyPriviewCtlArr);
            PrintDialog.ShowDialog();
        }
        #endregion
    }
}
