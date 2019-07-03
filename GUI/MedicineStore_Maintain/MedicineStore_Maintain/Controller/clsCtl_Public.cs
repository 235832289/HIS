using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
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
                try
                {
                    DW.Print(ShowPrintDialog);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            pDiag = null;
        }

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

        #region 将DataGridView显示的内容导入excel中 using System.IO
        /// <summary>
        /// 将DataGridView显示的内容导入excel中 
        /// </summary>
        /// <param name="dg">DataGridView</param>
        public void ExportDataGridViewToExcel(DataGridView dataGridview1)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            saveFileDialog.ShowDialog();
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //写标题     
                for (int i = 0; i < dataGridview1.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dataGridview1.Columns[i].HeaderText;
                }

                sw.WriteLine(str);
                //写内容   
                for (int j = 0; j < dataGridview1.Rows.Count; j++)
                {
                    StringBuilder tempStr = new StringBuilder("");
                    for (int k = 0; k < dataGridview1.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            //tempStr += "\t";
                            tempStr.Append("\t");
                        }
                        tempStr.Append(dataGridview1.Rows[j].Cells[k].Value.ToString());

                    }
                    sw.WriteLine(tempStr.ToString());
                }
                MessageBox.Show("导出成功！", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sw.Close();
                myStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
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
