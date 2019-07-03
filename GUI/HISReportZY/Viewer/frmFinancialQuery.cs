using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using Sybase.DataWindow;
using com.digitalwave.iCare.ValueObject;
using System.IO;
using System.Reflection;
using Excel;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmFinancialQuery : Form
    {
        public frmFinancialQuery()
        {
            InitializeComponent();
        }

        #region 事件 
        private void frmFinancialQuery_Load(object sender, EventArgs e)
        {
 
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Query();
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Query();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 

        #region  方法

        void Query()
        {

            string findStr = string.Empty;
         
            findStr = this.txtFind.Text.Trim();
            clsHISReportZy_Supported_Svc svc;

            try
            {
                svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                System.Data.DataTable dt = svc.GeItemContent(findStr);

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.multiColHeaderDgv2.DataSource = dt;

                    this.multiColHeaderDgv2.Columns[0].FillWeight = 25;      //第一列的相对宽度为25%
                    this.multiColHeaderDgv2.Columns[1].FillWeight = 25;      
                    this.multiColHeaderDgv2.Columns[2].FillWeight = 80;      
                    this.multiColHeaderDgv2.Columns[5].FillWeight = 25;      
                    this.multiColHeaderDgv2.Columns[7].FillWeight = 20;      
                    this.multiColHeaderDgv2.Columns[8].FillWeight = 15;      
                    this.multiColHeaderDgv2.Columns[9].FillWeight = 15;      
                    this.multiColHeaderDgv2.Columns[10].FillWeight = 15;      
                }
                else
                {
                    MessageBox.Show(this, "查无项目 ！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                svc = null;
            }
        }
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.multiColHeaderDgv2.RowCount > 0)
            {
                DataGridViewToExcel(this.multiColHeaderDgv2);
            }
        }

        #region DataGridView导出到Excel，有一定的判断性
        /// <summary> 
        ///方法，导出DataGridView中的数据到Excel文件 
        /// </summary> 
        /// <remarks>
        /// </remarks>
        /// <param name= "dgv"> DataGridView </param> 
        public static void DataGridViewToExcel(MultiColHeaderDgv dgv)
        {
            #region   

            //申明保存对话框 
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀 
            dlg.DefaultExt = "xls ";
            //文件后缀列表 
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默然路径是系统当前路径 
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框 
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径 
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效 
            if (fileNameString.Trim() == " ")
            { return; }
            //定义表格内数据的行数和列数 
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0 
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0 
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536 
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255 
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它 
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion
            Excel.Application objExcel = new Excel.Application();
            Excel.Workbook  objWorkbook = null;
            Excel.Worksheet  objsheet = null;
              
            try
            {
                //申明对象 
                objExcel = new Excel.ApplicationClass();
                
                //objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                //objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                objsheet = (Excel.Worksheet)objWorkbook.ActiveSheet;
                
                
                //设置EXCEL不可见 
                objExcel.Visible = false;

                //向Excel中写入表格的表头 
                int displayColumnsCount = 1;

                //Excel.Range
                Excel.Range range1 = objExcel.get_Range(objExcel.Cells[1, 1], objExcel.Cells[3, 1]);
                Excel.Range range2 = objExcel.get_Range(objExcel.Cells[1, 2], objExcel.Cells[3, 2]);
                Excel.Range range3 = objExcel.get_Range(objExcel.Cells[1, 3], objExcel.Cells[3, 3]);
                Excel.Range range4 = objExcel.get_Range(objExcel.Cells[1, 4], objExcel.Cells[3, 4]);
                Excel.Range range5 = objExcel.get_Range(objExcel.Cells[1, 5], objExcel.Cells[3, 5]);
                Excel.Range range6 = objExcel.get_Range(objExcel.Cells[1, 6], objExcel.Cells[3, 6]);
                Excel.Range range7 = objExcel.get_Range(objExcel.Cells[1, 7], objExcel.Cells[3, 7]);
                Excel.Range range8 = objExcel.get_Range(objExcel.Cells[2, 8], objExcel.Cells[3, 8]);
                Excel.Range range9 = objExcel.get_Range(objExcel.Cells[1, 8], objExcel.Cells[1, 11]);
                Excel.Range range10 = objExcel.get_Range(objExcel.Cells[2, 9], objExcel.Cells[2, 11]);

                range1.Merge(0);
                range2.Merge(0);
                range3.Merge(0);
                range4.Merge(0);
                range5.Merge(0);
                range6.Merge(0);
                range7.Merge(0);
                range8.Merge(0);
                range9.Merge(0);
                range9.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;     // 文本水平居中方式   
                range10.Merge(0);
                range10.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range1.NumberFormatLocal = "@";     //设置单元格格式为文本  
                range2.NumberFormatLocal = "@";     //设置单元格格式为文本  
                range3.NumberFormatLocal = "@";     //设置单元格格式为文本  
                range4.NumberFormatLocal = "@";     //设置单元格格式为文本  
                range5.NumberFormatLocal = "@";     //设置单元格格式为文本  
                range6.NumberFormatLocal = "@";     //设置单元格格式为文本  
                range7.NumberFormatLocal = "@";     //设置单元格格式为文本  
                range8.NumberFormatLocal = "@";     //设置单元格格式为文本  
                range9.NumberFormatLocal = "@";     //设置单元格格式为文本  
                objsheet.Cells[1, 1] = "财务分类";
                objsheet.Cells[1, 2] = "项目代码";
                objsheet.Cells[1, 3] = "项目名称";
                objsheet.Cells[1, 4] = "项目内涵";
                objsheet.Cells[1, 5] = "除外内容";
                objsheet.Cells[1, 6] = "计价单位";
                objsheet.Cells[1, 7] = "说明";
                objsheet.Cells[2, 8] = "省定价";
                objsheet.Cells[3, 9] = "三档";
                objsheet.Cells[3, 10] = "二档";
                objsheet.Cells[3, 11] = "一档";
                objsheet.Cells[1, 8] = "价格（元）";
                objsheet.Cells[2, 9] = "市定价格";

                range2.ColumnWidth = 12;     //设置单元格的宽度 
                range3.ColumnWidth = 20;     //设置单元格的宽度 
                range4.ColumnWidth = 35;     //设置单元格的宽度 
                range5.ColumnWidth = 25;     //设置单元格的宽度
                range7.ColumnWidth = 25;     //设置单元格的宽度

                range2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;     // 文本水平居中方式 
                range3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;     // 文本水平居中方式 
                range4.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;     // 文本水平居中方式 
                range5.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;     // 文本水平居中方式 
                range7.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;     // 文本水平居中方式 

                Excel.Range rangGol = objsheet.get_Range("A1", "K" + dgv.RowCount.ToString());
                rangGol.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;     // 文本水平居中方式 
                rangGol.WrapText = true;  

                //向Excel中逐行逐列写入表格中的数据 
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    //tempProgressBar.PerformStep();

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible == true)
                        {
                            try
                            {
                                objExcel.Cells[row+4, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }

                //保存文件 
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用 
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void multiColHeaderDgv2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar <= 'z' && e.KeyChar >= 'a')
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
