using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 公共操作类
    /// </summary>
    public class clsCtl_Public : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 控件跳转
        /// <summary>
        /// 需作跳转控制的控件
        /// </summary>
        private Control[] m_ctlControls = null;
        /// <summary>
        /// 是否循环
        /// </summary>
        private bool m_blnIsCircle = false;
        /// <summary>
        /// 控件跳转
        /// </summary>
        /// <param name="p_frmParent">所属窗体</param>
        /// <param name="p_ctlControls">控件</param>
        /// <param name="p_keyDown">按下键</param>
        /// <param name="p_blnIsCircle">是否循环</param>
        internal void m_mthJumpControl(Form p_frmParent, Control[] p_ctlControls, Keys p_keyDown, bool p_blnIsCircle)
        {
            m_blnIsCircle = p_blnIsCircle;
            if (p_frmParent == null || p_ctlControls == null)
            {
                return;
            }

            m_ctlControls = p_ctlControls;

            for (int iCtl = 0; iCtl < p_ctlControls.Length; iCtl++)
            {
                if (p_ctlControls[iCtl].FindForm() != p_frmParent)
                {
                    return;
                }
            }

            for (int iCtl = 0; iCtl < p_ctlControls.Length; iCtl++)
            {
                p_ctlControls[iCtl].KeyDown += new KeyEventHandler(clsCtl_Public_KeyDown);
            }
        }

        private void clsCtl_Public_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_ctlControls == null)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                Control ctlCurrent = sender as Control;
                int intIndex = 0;

                for (int iCtl = 0; iCtl < m_ctlControls.Length; iCtl++)
                {
                    if (ctlCurrent == m_ctlControls[iCtl])
                    {
                        intIndex = iCtl;
                        break;
                    }
                }

                if (intIndex == m_ctlControls.Length - 1)
                {
                    if (m_blnIsCircle)
                    {
                        m_ctlControls[0].Focus(); 
                    }                    
                }
                else
                {
                    m_ctlControls[intIndex + 1].Focus();
                }
            }            
        } 
        #endregion

        #region 设置控件活动时高亮显示
        /// <summary>
        /// 设置控件活动时高亮显示
        /// </summary>
        /// <param name="p_ctlParent"></param>
        /// <param name="p_clrHightLight"></param>
        internal void m_mthSetControlHighLight(Control p_ctlParent, System.Drawing.Color p_clrHightLight)
        {
            com.digitalwave.controls.ctlHighLightFocus objHighLight = new com.digitalwave.controls.ctlHighLightFocus(p_clrHightLight);
            objHighLight.m_mthAddControlInContainer(p_ctlParent);
        } 
        #endregion

        #region 文本框全选
        /// <summary>
        /// 文本框全选
        /// </summary>
        /// <param name="p_ctlParent">父控件</param>
        internal void m_mthSelectAllText(System.Windows.Forms.Control p_ctlParent)
        {
            if (p_ctlParent.HasChildren)
            {
                foreach (System.Windows.Forms.Control currentCtl in p_ctlParent.Controls)
                {
                    if (currentCtl is System.Windows.Forms.TextBoxBase)
                    {
                        currentCtl.GotFocus += new EventHandler(currentCtl_GotFocus);
                    }                    
                }
            }
        }

        private void currentCtl_GotFocus(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBoxBase)
                (sender as System.Windows.Forms.TextBoxBase).SelectAll();
        } 
        #endregion

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
            if (pDiag.ShowDialog() == DialogResult.OK)
            {
                DW.PrintProperties.PrinterName = pDiag.PrinterSettings.PrinterName;

                if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                {
                    DW.PrintProperties.PageRange = pDiag.PrinterSettings.FromPage.ToString() + "-" + pDiag.PrinterSettings.ToPage.ToString();
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
            if (pDiag.ShowDialog() == DialogResult.OK)
            {
                datasto.PrintProperties.PrinterName = pDiag.PrinterSettings.PrinterName;

                if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                {
                    datasto.PrintProperties.PageRange = pDiag.PrinterSettings.FromPage.ToString() + "-" + pDiag.PrinterSettings.ToPage.ToString();
                }

                datasto.Print(ShowPrintDialog);
            }
            pDiag = null;
        }
        #endregion

        public static long m_lngGetSysDateTimeNow(out DateTime p_dtmDateTime)
        {
            com.digitalwave.iCare.gui.MedicineStore.clsDcl_Public objDomain = new clsDcl_Public();
            return objDomain.m_lngGetSysDateTimeNow(out p_dtmDateTime);
        }

        public static long m_lngGetCurrentDateTime(out DateTime p_dtmDateTime)
        {
            com.digitalwave.iCare.gui.MedicineStore.clsDcl_Public objDomain = new clsDcl_Public();
            return objDomain.m_lngGetCurrentDateTime(out p_dtmDateTime);
        }

        public long m_lngGetStorageName(bool p_blnForDrugStore, string p_strStorageID, out string p_strStroageName)
        {
            com.digitalwave.iCare.gui.MedicineStore.clsDcl_Public objDomain = new clsDcl_Public();
            if (p_blnForDrugStore)
            {
                return objDomain.m_lngGetDrugStoreName(p_strStorageID, out p_strStroageName);
            }
            else
            {
                return objDomain.m_lngGetStoreName(p_strStorageID, out p_strStroageName);
            }
        }

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
        
        #region 由购入价计算零售价
        /// <summary>
        /// 由购入价计算零售价
        /// </summary>
        /// <param name="m_strStorageID">仓库ID</param>
        /// <param name="p_dcmBuyIn">购入价</param>
        /// <param name="dblRate">利率</param>
        /// <returns></returns>
        public static double m_mthMathPayment(string m_strStorageID, double p_dcmBuyIn, double dblRate)
        {
            // 西药库  按照最新的计算公式来计算零售价
            //（1）X<=10  Y=X*1.25    （2）10<X<=40  Y=X*1.15+1
            //（3）40<X<=200 Y=X*1.1+3 （4）200<X<=600 Y=X*1.08+5
            //（5）600<X<=2000 Y=X*1.06+15 （6）X>2000 Y=X+135
            // 材料
            //关于卫生材料
            //（1）<=1000元  加收10%  即：零售价=1000+购入单价*10%
            //（2）1000 < X <=9750   实行累积差率  即：零售价=购入单价*(1+0.08) +20
            //（3）X > 9750 单次一次性医用消耗材料加收部分，最高不得超过800元
            double dblRetailMoney = 0d;
            // 西药库:0001 一类疫苗:0006  二类疫苗:0007 中药库:0002  卫生材料:0003  低值材料:0004  其他材料:0005
            if (m_strStorageID == "0001")
            {
                if (p_dcmBuyIn <= 10)
                {
                    dblRetailMoney = p_dcmBuyIn * 1.25;
                }
                else if (p_dcmBuyIn > 10 && p_dcmBuyIn <= 40)
                {
                    dblRetailMoney = p_dcmBuyIn * 1.15 + 1;
                }
                else if (p_dcmBuyIn > 40 && p_dcmBuyIn <= 200)
                {
                    dblRetailMoney = p_dcmBuyIn * 1.1 + 3;
                }
                else if (p_dcmBuyIn > 200 && p_dcmBuyIn <= 600)
                {
                    dblRetailMoney = p_dcmBuyIn * 1.08 + 5;
                }
                else if (p_dcmBuyIn > 600 && p_dcmBuyIn <= 2000)
                {
                    dblRetailMoney = p_dcmBuyIn * 1.06 + 15;
                }
                else
                {
                    dblRetailMoney = p_dcmBuyIn + 135;
                }
            }
            else if (m_strStorageID == "0003")
            {
                if (p_dcmBuyIn <= 1000)
                {
                    dblRetailMoney = p_dcmBuyIn * 0.1 + p_dcmBuyIn;
                }
                else if (p_dcmBuyIn > 1000 && p_dcmBuyIn <= 9750)
                {
                    dblRetailMoney = p_dcmBuyIn * (1 + 0.08) + 20;
                }
                else
                {
                    dblRetailMoney = p_dcmBuyIn + 800;
                }
            }
            else
            {
                dblRetailMoney = (double)p_dcmBuyIn * (1 + dblRate / 100);
            }
            return dblRetailMoney;
        }
        #endregion
    }

    #region 小写金额转为大写金额
    /// <summary>
    /// 小写金额转为大写金额
    /// string mmm = new Money(128321.21M).ToString();
    /// </summary>
    public class Money
    {
        public string Yuan = "元";
        public string Jiao = "角";
        public string Fen = "分";
        static string Digit = "零壹贰叁肆伍陆柒捌玖";
        bool isAllZero = true;
        bool isPreZero = true;
        bool Overflow = false;
        long money100;
        long value;
        StringBuilder sb = new StringBuilder();

        // 只读属性: "零元" 
        public string ZeroString
        {
            get { return Digit[0] + Yuan; }
        }

        // 构造函数 
        public Money(decimal money)
        {
            try { money100 = (long)(money * 100m); }
            catch { Overflow = true; }
            if (money100 == long.MinValue) Overflow = true;
        }

        // 重载 ToString() 方法，返回大写金额字符串 
        public override string ToString()
        {
            if (Overflow) return "金额超出范围";
            if (money100 == 0) return ZeroString;
            string[] Unit = { Yuan, "万", "亿", "万", "亿亿" };
            value = System.Math.Abs(money100);
            ParseSection(true);
            for (int i = 0; i < Unit.Length && value > 0; i++)
            {
                if (isPreZero && !isAllZero) sb.Append(Digit[0]);
                if (i == 4 && sb.ToString().EndsWith(Unit[2]))
                    sb.Remove(sb.Length - Unit[2].Length, Unit[2].Length);
                sb.Append(Unit[i]);
                ParseSection(false);
                if ((i % 2) == 1 && isAllZero)
                    sb.Remove(sb.Length - Unit[i].Length, Unit[i].Length);
            }
            if (money100 < 0) sb.Append("负");
            return Reverse();
        }

        // 解析“片段”: “角分(2位)”或“万以内的一段(4位)” 
        void ParseSection(bool isJiaoFen)
        {
            string[] Unit = isJiaoFen ?
            new string[] { Fen, Jiao } :
            new string[] { "", "拾", "佰", "仟" };
            isAllZero = true;
            for (int i = 0; i < Unit.Length && value > 0; i++)
            {
                int d = (int)(value % 10);
                if (d != 0)
                {
                    if (isPreZero && !isAllZero) sb.Append(Digit[0]);
                    sb.AppendFormat("{0}{1}", Unit[i], Digit[d]);
                    isAllZero = false;
                }
                isPreZero = (d == 0);
                value /= 10;
            }
        }

        // 反转字符串 
        string Reverse()
        {
            StringBuilder sbReversed = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
                sbReversed.Append(sb[i]);
            return sbReversed.ToString();
        }
    }
    #endregion

}
