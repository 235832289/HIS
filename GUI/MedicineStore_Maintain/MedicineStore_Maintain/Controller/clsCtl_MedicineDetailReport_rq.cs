using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using System.IO;
using com.digitalwave.iCare.middletier.MedicineStoreService;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品明细帐表
    /// </summary>
    public class clsCtl_MedicineDetailReport_rq : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_MedicineDetailReport_rq m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmMedicineDetailReport_rq m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 账表内容VO
        /// </summary>
        private clsMS_TotalAccountVO_rq[] accountVO = null;
        private clsMS_TotalAccountVO_rq accountMedicineVO;

        #endregion

        #region 构造函数

        /// <summary>
        /// 药品明细帐表
        /// </summary>
        public clsCtl_MedicineDetailReport_rq()
        {
            m_objDomain = new clsDcl_MedicineDetailReport_rq();
        }
        #endregion

        #region 设置窗体对象

        /// <summary>
        /// 设置窗体对象.
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMedicineDetailReport_rq)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            clsDcl_OutStorageDetailReport objOSD = new clsDcl_OutStorageDetailReport();
            long lngRes = objOSD.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
            objOSD = null;
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {

                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = m_objViewer.m_txtMedicine.Location.X;// -(m_ctlQueryMedicint.Size.Width - m_objViewer.m_txtMedicineCode.Size.Width);
                int Y = m_objViewer.m_txtMedicine.Location.Y + m_objViewer.m_txtMedicine.Size.Height;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            m_objViewer.m_txtMedicine.Focus();
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtMedicine.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicine.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_cboMedicineType.SelectedIndex = -1;
            m_objViewer.m_cboMedicineType.Text = string.Empty;

            m_objViewer.m_cmdSearch.Focus();
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型
        /// </summary>
        internal void m_mthGetMedicineTypeSet(out clsMS_MedicineTypeSetVO[] p_objMPVO)
        {
            p_objMPVO = null;
            clsDcl_MedicineTypeSet objMTDomain = new clsDcl_MedicineTypeSet();
            long lngRes = objMTDomain.m_lngGetAllMedicinTypeSetInfo(out p_objMPVO);
            objMTDomain = null;
        }
        #endregion              

        #region 获取药品明细帐表
        /// <summary>
        /// 获取药品明细帐表
        /// </summary>
        internal void m_mthGetMedicineDetailReport()
        {
            try
            {
                m_objViewer.Cursor = Cursors.WaitCursor;
                m_objViewer.m_dtbAccou.Clear();

                if (m_objViewer.m_txtMedicine.Text.Trim() != "")//指定某种药品
                {

                    m_objDomain.m_lngGetMedicineTotalAccountByTime(m_objViewer.m_strStorageID, m_objViewer.m_txtMedicine.Tag.ToString(),
                        DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd 00:00:00")),
                        DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd 23:59:59")),
                        m_objViewer.m_strForeAccount, m_objViewer.m_strBackAccount, out accountMedicineVO);
                }
                //指定药品的类型
                else if ((m_objViewer.m_cboMedicineType.SelectedIndex >= 0) && (m_objViewer.m_cboMedicineType.Text != "全部"))
                {
                    clsMS_MedicineTypeSetVO objMPVO = new clsMS_MedicineTypeSetVO();
                    objMPVO = (clsMS_MedicineTypeSetVO)m_objViewer.m_cboMedicineType.Items[m_objViewer.m_cboMedicineType.SelectedIndex];
                    m_objDomain.m_lngGetMedicineTypeAccountByTime(m_objViewer.m_strStorageID, objMPVO.m_intMedicineTypeSetID.ToString(),
                        DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd 00:00:00")),
                        DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd 23:59:59")),
                      m_objViewer.m_strForeAccount, m_objViewer.m_strBackAccount, out accountVO);

                }
                //全部药品
                else
                {
                    m_objDomain.m_lngGetAllMedicineDetailAccountByTime(m_objViewer.m_strStorageID,
                           DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd 00:00:00")),
                           DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd 23:59:59")),
                         m_objViewer.m_strForeAccount, m_objViewer.m_strBackAccount, out accountVO);

                }
                if ((m_objViewer.m_txtMedicine.Tag == null) && (accountVO == null || accountVO.Length == 0))
                {
                    MessageBox.Show("抱歉，没有查到该期药品明细帐数据。", "药品明细帐表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_objViewer.datWindow.Reset();
                    return;
                }

                if (m_objViewer.m_txtMedicine.Text.Trim() != "")
                {
                    if (accountMedicineVO == null)
                    {
                        MessageBox.Show("抱歉，没有查到该药品明细帐数据。", "药品明细帐表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_objViewer.datWindow.Reset();
                        return;
                    }

                    DataRow dr = m_objViewer.m_dtbAccou.NewRow();
                    dr["medicinename_vch"] = accountMedicineVO.m_strMedicineName;
                    dr["medspec_vchr"] = accountMedicineVO.m_strMedicineSpec;
                    dr["m_dblBeginAmount"] = accountMedicineVO.m_dblBeginAmount;
                    dr["m_dblBeginCallMoney"] = accountMedicineVO.m_dblBeginCallMoney;
                    dr["m_dblBeginRetailMoney"] = accountMedicineVO.m_dblBeginRetailMoney;
                    dr["m_dblBeginWholesaleMoney"] = accountMedicineVO.m_dblBeginWholesaleMoney;
                    dr["m_dblInAmount"] = accountMedicineVO.m_dblInAmount;
                    dr["m_dblInCallMoney"] = accountMedicineVO.m_dblInCallMoney;
                    dr["m_dblInRetailMoney"] = accountMedicineVO.m_dblInRetailMoney;
                    dr["m_dblInWholesaleMoney"] = accountMedicineVO.m_dblInWholesaleMoney;
                    dr["m_dblOutAmount"] = accountMedicineVO.m_dblOutAmount;
                    dr["m_dblOutCallMoney"] = accountMedicineVO.m_dblOutCallMoney;
                    dr["m_dblOutRetailMoney"] = accountMedicineVO.m_dblOutRetailMoney;
                    dr["m_dblOutWholesaleMoney"] = accountMedicineVO.m_dblOutWholesaleMoney;
                    dr["m_dblEndAmount"] = accountMedicineVO.m_dblEndAmount;
                    dr["m_dblEndCallMoney"] = accountMedicineVO.m_dblEndCallMoney;
                    dr["m_dblEndRetailMoney"] = accountMedicineVO.m_dblEndRetailMoney;
                    dr["m_dblEndWholesaleMoney"] = accountMedicineVO.m_dblEndWholesaleMoney;

                    m_objViewer.m_dtbAccou.Rows.Add(dr);
                }
                else
                {
                    for (int i = 0; i < accountVO.Length; i++)
                    {
                        DataRow dr = m_objViewer.m_dtbAccou.NewRow();
                        dr["medicinename_vch"] = accountVO[i].m_strMedicineName;
                        dr["medspec_vchr"] = accountVO[i].m_strMedicineSpec;
                        dr["m_dblBeginAmount"] = accountVO[i].m_dblBeginAmount;
                        dr["m_dblBeginCallMoney"] = accountVO[i].m_dblBeginCallMoney;
                        dr["m_dblBeginRetailMoney"] = accountVO[i].m_dblBeginRetailMoney;
                        dr["m_dblBeginWholesaleMoney"] = accountVO[i].m_dblBeginWholesaleMoney;
                        dr["m_dblInAmount"] = accountVO[i].m_dblInAmount;
                        dr["m_dblInCallMoney"] = accountVO[i].m_dblInCallMoney;
                        dr["m_dblInRetailMoney"] = accountVO[i].m_dblInRetailMoney;
                        dr["m_dblInWholesaleMoney"] = accountVO[i].m_dblInWholesaleMoney;
                        dr["m_dblOutAmount"] = accountVO[i].m_dblOutAmount;
                        dr["m_dblOutCallMoney"] = accountVO[i].m_dblOutCallMoney;
                        dr["m_dblOutRetailMoney"] = accountVO[i].m_dblOutRetailMoney;
                        dr["m_dblOutWholesaleMoney"] = accountVO[i].m_dblOutWholesaleMoney;
                        dr["m_dblEndAmount"] = accountVO[i].m_dblEndAmount;
                        dr["m_dblEndCallMoney"] = accountVO[i].m_dblEndCallMoney;
                        dr["m_dblEndRetailMoney"] = accountVO[i].m_dblEndRetailMoney;
                        dr["m_dblEndWholesaleMoney"] = accountVO[i].m_dblEndWholesaleMoney;
                        m_objViewer.m_dtbAccou.Rows.Add(dr);
                    }
                }
                m_objViewer.datWindow.LibraryList = clsPublic.PBLPath;
                m_objViewer.datWindow.DataWindowObject = "ms_account_Detail2";
                string strStoreRoomName;
                m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStoreRoomName);
                m_objViewer.datWindow.Modify("t_storage.text='" + strStoreRoomName + "'");
                m_objViewer.datWindow.Modify("t_22.text='" + m_objViewer.m_dtpBeginDate.Text + "到" + m_objViewer.m_dtpEndDate.Text + "'");
                DataView dtv = new DataView();
                dtv = m_objViewer.m_dtbAccou.DefaultView;
                dtv.Sort = "m_dbloutamount desc";
                m_objViewer.m_dtbAccou = dtv.ToTable();
                m_objViewer.datWindow.SetRedrawOff();
                m_objViewer.datWindow.Retrieve(m_objViewer.m_dtbAccou);
                m_objViewer.datWindow.SetRedrawOn();
                m_objViewer.datWindow.Refresh();
            }
            catch(Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                m_objViewer.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region 把datatable导出到excel
        /// <summary>
        /// 把datatable导出到excel
        /// </summary>
        /// <param name="p_dt"></param>
        public void m_mthOutExcel(DataTable p_dt)
        {
            int intCount = 0;
            intCount++;
            DataTable dttemp = new DataTable("Table" + intCount.ToString());
            string str = "";
            for (int i = 0; i < p_dt.Columns.Count; i++)
            {
                str = p_dt.Columns[i].ColumnName.Replace("(", "");
                str = str.Replace(")", "");
                dttemp.Columns.Add(str, p_dt.Columns[i].DataType);
            }
            DataRow dr = null;
            for (int i = 0; i < p_dt.Rows.Count; i++)
            {
                dr = dttemp.NewRow();
                for (int i2 = 0; i2 < p_dt.Columns.Count; i2++)
                {
                    dr[i2] = p_dt.Rows[i][i2];
                }
                dttemp.Rows.Add(dr);
            }
            DataSet ds = new DataSet();
            ds.Tables.Clear();
            ds.Tables.Add(dttemp);
            ExcelExporter excel = new ExcelExporter(ds);
            bool b = excel.m_mthExport();
            if (b)
            {
                MessageBox.Show("导出数据成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("导出数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            ds.Tables.Clear();
            dttemp = null;
            ds = null;
        }
        #endregion

        #region 将DataGridView显示的内容导入excel中 using System.IO
        /// <summary>
        /// 将DataGridView显示的内容导入excel中 
        /// </summary>
        /// <param name="dataGridview1">DataGridView</param>
        public void ExportDataGridViewToExcel(DataGridView dataGridview1)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
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
                for (int j = 0; j < dataGridview1.Rows.Count-1; j++)
                 {
                    StringBuilder tempStr = new StringBuilder("");
                    for (int k = 0; k < dataGridview1.Columns.Count; k++)
                    {
                        if (k > 0)
                        {

                            tempStr.Append("\t");
                        }
                        tempStr.Append(dataGridview1.Rows[j].Cells[k].Value.ToString());

                    }
                    sw.WriteLine(tempStr.ToString());
                }
                MessageBox.Show("导出成功！", "库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region 获取时间对应的帐务期
        /// <summary>
        /// 获取时间对应的帐务期
        /// </summary>
        internal void m_mthGetAccount()
        {
            string m_strAccountName = string.Empty;
            m_objDomain.m_lngGetAccount(m_objViewer.m_strStorageID, DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd 00:00:00")), out m_strAccountName);
            m_objViewer.m_strForeAccount = m_strAccountName;
            m_objDomain.m_lngGetAccount(m_objViewer.m_strStorageID, DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd 23:59:59")), out m_strAccountName);
            m_objViewer.m_strBackAccount = m_strAccountName;            
        }
        #endregion
    }
}
