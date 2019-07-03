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
namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品明细帐表
    /// </summary>
    public class clsCtl_MedicineDetailReport : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_MedicineDetailReport m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmMedicineDetailReport m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 账表内容VO
        /// </summary>
        private clsMS_TotalAccountVO[] accountVO = null;
        private clsMS_TotalAccountVO accountMedicineVO;

        #endregion

        #region 构造函数

        /// <summary>
        /// 药品明细帐表
        /// </summary>
        public clsCtl_MedicineDetailReport()
        {
            m_objDomain = new clsDcl_MedicineDetailReport();
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
            m_objViewer = (frmMedicineDetailReport)frmMDI_Child_Base_in;
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

        #region 获取帐务期ID列表
        /// <summary>
        /// 获取帐务期ID列表
        /// </summary>
        /// <param name="p_objAccArr">帐务期结转</param>
        internal void m_mthGetAccountIDList(out clsMS_AccountPeriodVO[] p_objAccArr)
        {
            long lngRes = m_objDomain.m_lngGetAccountPeriod(m_objViewer.m_strStorageID, out p_objAccArr);
        }

        /// <summary>
        /// 设置帐务期列表至界面
        /// </summary>
        /// <param name="p_objAccArr">帐务期结转</param>
        internal void m_mthSetAccountPeriodToList(clsMS_AccountPeriodVO[] p_objAccArr)
        {
            if (p_objAccArr == null || p_objAccArr.Length == 0)
            {
                clsMS_AccountPeriodVO objNow = new clsMS_AccountPeriodVO();
                string strDate;
                long lngRes = m_objDomain.m_lngGetSysParm("5001", out strDate);
                objNow.m_dtmSTARTTIME_DAT = Convert.ToDateTime(strDate);
                objNow.m_dtmENDTIME_DAT = DateTime.Now;
                objNow.m_strACCOUNTID_CHR = "未结转";

                StringBuilder stbID = new StringBuilder(30);
                stbID.Append(objNow.m_strACCOUNTID_CHR);
                stbID.Append("  ");
                stbID.Append(objNow.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日"));
                stbID.Append("～");
                stbID.Append(objNow.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日"));
                ListViewItem lsiNow = new ListViewItem(stbID.ToString());
                lsiNow.Tag = objNow;
                stbID = null;
                m_objViewer.m_lsvAccountIDList.Items.Add(lsiNow);
                return;
            }

            try
            {
                m_objViewer.m_lsvAccountIDList.Items.Clear();
                m_objViewer.m_lsvAccountIDList.BeginUpdate();
                ListViewItem[] lsiItems = new ListViewItem[p_objAccArr.Length];
                for (int iItem = 0; iItem < p_objAccArr.Length; iItem++)
                {
                    StringBuilder stbID = new StringBuilder(30);
                    stbID.Append(p_objAccArr[iItem].m_strACCOUNTID_CHR);
                    stbID.Append("  ");
                    stbID.Append(p_objAccArr[iItem].m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日"));
                    stbID.Append("～");
                    stbID.Append(p_objAccArr[iItem].m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日"));
                    lsiItems[iItem] = new ListViewItem(stbID.ToString());
                    lsiItems[iItem].Tag = p_objAccArr[iItem];
                    stbID = null;
                }
                m_objViewer.m_lsvAccountIDList.Items.AddRange(lsiItems);
                //添加未结转选项
                if (DateTime.Now.Date > p_objAccArr[p_objAccArr.Length - 1].m_dtmENDTIME_DAT.Date)
                {
                    clsMS_AccountPeriodVO objNow = new clsMS_AccountPeriodVO();
                    objNow.m_dtmSTARTTIME_DAT = Convert.ToDateTime(p_objAccArr[p_objAccArr.Length - 1].m_dtmENDTIME_DAT.AddDays(1).ToString("yyyy-MM-dd"));
                    objNow.m_dtmENDTIME_DAT = DateTime.Now;
                    objNow.m_strACCOUNTID_CHR = "未结转";

                    StringBuilder stbID = new StringBuilder(30);
                    stbID.Append(objNow.m_strACCOUNTID_CHR);
                    stbID.Append("  ");
                    stbID.Append(objNow.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日"));
                    stbID.Append("～");
                    stbID.Append(objNow.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日"));
                    ListViewItem lsiNow = new ListViewItem(stbID.ToString());
                    lsiNow.Tag = objNow;
                    stbID = null;
                    m_objViewer.m_lsvAccountIDList.Items.Add(lsiNow);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                m_objViewer.m_lsvAccountIDList.EndUpdate();
            }
        }
        #endregion

        #region 获取药品明细帐表
        /// <summary>
        /// 获取药品明细帐表
        /// </summary>
        internal void m_mthGetMedicineDetailReport()
        {
            m_objViewer.m_dtbAccou.Clear();
            if (m_objViewer.m_txtAccountID.Text.Trim() == "")
            {
                MessageBox.Show("请先选择帐期。", "药品明细帐表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (m_objViewer.m_txtMedicine.Text.Trim() != "")
            {
                if (m_objViewer.m_txtAccountID.Text.Trim() == "未结转")
                {
                    m_objDomain.m_lngGetMedicineTotalAccountNoAcc(m_objViewer.m_strStorageID, m_objViewer.m_txtMedicine.Tag.ToString(), m_objViewer.AccouVO.m_dtmSTARTTIME_DAT,
                        m_objViewer.AccouVO.m_dtmENDTIME_DAT, m_objViewer.m_strLastStorageID, m_objViewer.AccouVO.m_strACCOUNTID_CHR, out accountMedicineVO);
                }
                else
                {
                    m_objDomain.m_lngGetMedicineTotalAccount(m_objViewer.m_strStorageID, m_objViewer.m_txtMedicine.Tag.ToString(), m_objViewer.AccouVO.m_dtmSTARTTIME_DAT,
                        m_objViewer.AccouVO.m_dtmENDTIME_DAT, m_objViewer.m_strLastStorageID, m_objViewer.AccouVO.m_strACCOUNTID_CHR, out accountMedicineVO);
                }
            }
            else if ((m_objViewer.m_cboMedicineType.SelectedIndex >= 0) && (m_objViewer.m_cboMedicineType.Text != "全部"))
            {
                if (m_objViewer.m_txtAccountID.Text.Trim() == "未结转")
                {
                    clsMS_MedicineTypeSetVO objMPVO = new clsMS_MedicineTypeSetVO();
                    objMPVO = (clsMS_MedicineTypeSetVO)m_objViewer.m_cboMedicineType.Items[m_objViewer.m_cboMedicineType.SelectedIndex];
                    m_objDomain.m_lngGetMedicineTypeAccountNoAcc(m_objViewer.m_strStorageID, objMPVO.m_intMedicineTypeSetID.ToString(), m_objViewer.AccouVO.m_dtmSTARTTIME_DAT,
                      m_objViewer.AccouVO.m_dtmENDTIME_DAT, m_objViewer.m_strLastStorageID, m_objViewer.AccouVO.m_strACCOUNTID_CHR, out accountVO);
                }
                else
                {
                    clsMS_MedicineTypeSetVO objMPVO = new clsMS_MedicineTypeSetVO();
                    objMPVO = (clsMS_MedicineTypeSetVO)m_objViewer.m_cboMedicineType.Items[m_objViewer.m_cboMedicineType.SelectedIndex];
                    m_objDomain.m_lngGetMedicineTypeAccount(m_objViewer.m_strStorageID, objMPVO.m_intMedicineTypeSetID.ToString(), m_objViewer.AccouVO.m_dtmSTARTTIME_DAT,
                      m_objViewer.AccouVO.m_dtmENDTIME_DAT, m_objViewer.m_strLastStorageID, m_objViewer.AccouVO.m_strACCOUNTID_CHR, out accountVO);
                }
            }
            else
            {
                if (m_objViewer.m_txtAccountID.Text.Trim() == "未结转")
                {
                    m_objDomain.m_lngGetAllMedicineDetailAccountNoAcc(m_objViewer.m_strStorageID, m_objViewer.AccouVO.m_dtmSTARTTIME_DAT,
                        m_objViewer.AccouVO.m_dtmENDTIME_DAT, m_objViewer.m_strLastStorageID, m_objViewer.AccouVO.m_strACCOUNTID_CHR, out accountVO);
                }
                else
                {
                    m_objDomain.m_lngGetAllMedicineDetailAccount(m_objViewer.m_strStorageID, m_objViewer.AccouVO.m_dtmSTARTTIME_DAT,
                        m_objViewer.AccouVO.m_dtmENDTIME_DAT, m_objViewer.m_strLastStorageID, m_objViewer.AccouVO.m_strACCOUNTID_CHR, out accountVO);
                }
            }
            if ((m_objViewer.m_txtMedicine.Tag == null) && (accountVO == null || accountVO.Length == 0))
            {
                MessageBox.Show("抱歉，没有查到该期药品明细帐数据。", "药品明细帐表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_objViewer.datWindow.Reset();
                return;
            }
            //m_objViewer.m_dtbAccou.Columns.Add("medicinename_vch", typeof(System.String));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblbeginwholesalemoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblbeginretailmoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblincallmoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblinwholesalemoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblinretailmoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dbloutwholesalemoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dbloutretailmoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblendwholesalemoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblendretailmoney", typeof(System.Double));

            //m_objViewer.m_dtbAccou.Columns.Add("m_dblBeginAmount", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblinAmount", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dbloutAmount", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblendAmount", typeof(System.Double));

            //m_objViewer.m_dtbAccou.Columns.Add("m_dblBeginCallMoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblOutCallMoney", typeof(System.Double));
            //m_objViewer.m_dtbAccou.Columns.Add("m_dblEndCallMoney", typeof(System.Double));

            if (m_objViewer.m_txtMedicine.Text.Trim() != "")
            {
                if (accountMedicineVO == null)
                {
                    MessageBox.Show("抱歉，没有查到该药品明细帐数据。", "药品明细帐表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_objViewer.datWindow.Reset();
                    return;
                }

                DataRow dr = m_objViewer.m_dtbAccou.NewRow();
                dr[0] = accountMedicineVO.m_strMedicineName;
                dr[1] = accountMedicineVO.m_dblBeginWholesaleMoney;
                dr[2] = accountMedicineVO.m_dblBeginRetailMoney;

                dr[3] = accountMedicineVO.m_dblInCallMoney;
                dr[4] = accountMedicineVO.m_dblInWholesaleMoney;
                dr[5] = accountMedicineVO.m_dblInRetailMoney;

                dr[6] = accountMedicineVO.m_dblOutWholesaleMoney;
                dr[7] = accountMedicineVO.m_dblOutRetailMoney;
                dr[8] = accountMedicineVO.m_dblEndWholesaleMoney;
                dr[9] = accountMedicineVO.m_dblEndRetailMoney;

                dr[10] = accountMedicineVO.m_dblBeginAmount;
                dr[11] = accountMedicineVO.m_dblInAmount;
                dr[12] = accountMedicineVO.m_dblOutAmount;
                dr[13] = accountMedicineVO.m_dblEndAmount;

                dr[14] = accountMedicineVO.m_dblBeginCallMoney;
                dr[15] = accountMedicineVO.m_dblOutCallMoney;
                dr[16] = accountMedicineVO.m_dblEndCallMoney;


                m_objViewer.m_dtbAccou.Rows.Add(dr);
            }
            else
            {
                for (int i = 0; i < accountVO.Length; i++)
                {
                    DataRow dr = m_objViewer.m_dtbAccou.NewRow();
                    dr[0] = accountVO[i].m_strMedicineName;
                    dr[1] = accountVO[i].m_dblBeginWholesaleMoney;
                    dr[2] = accountVO[i].m_dblBeginRetailMoney;

                    dr[3] = accountVO[i].m_dblInCallMoney;
                    dr[4] = accountVO[i].m_dblInWholesaleMoney;
                    dr[5] = accountVO[i].m_dblInRetailMoney;

                    dr[6] = accountVO[i].m_dblOutWholesaleMoney;
                    dr[7] = accountVO[i].m_dblOutRetailMoney;
                    dr[8] = accountVO[i].m_dblEndWholesaleMoney;
                    dr[9] = accountVO[i].m_dblEndRetailMoney;
                    dr[10] = accountVO[i].m_dblBeginAmount;
                    dr[11] = accountVO[i].m_dblInAmount;
                    dr[12] = accountVO[i].m_dblOutAmount;
                    dr[13] = accountVO[i].m_dblEndAmount;

                    dr[14] = accountVO[i].m_dblBeginCallMoney;
                    dr[15] = accountVO[i].m_dblOutCallMoney;
                    dr[16] = accountVO[i].m_dblEndCallMoney;
                    m_objViewer.m_dtbAccou.Rows.Add(dr);
                }
            }
            m_objViewer.datWindow.LibraryList = clsPublic.PBLPath;
            m_objViewer.datWindow.DataWindowObject = "ms_account_Detail";
            string strStoreRoomName;
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStoreRoomName);
            m_objViewer.datWindow.Modify("t_storage.text='" + strStoreRoomName + "'");
            DataView dtv = new DataView();
            dtv = m_objViewer.m_dtbAccou.DefaultView;
            dtv.Sort = "m_dbloutamount desc";
            m_objViewer.m_dtbAccou = dtv.ToTable();
            m_objViewer.datWindow.SetRedrawOff();
            m_objViewer.datWindow.Retrieve(m_objViewer.m_dtbAccou);
            m_objViewer.datWindow.SetRedrawOn();
            m_objViewer.datWindow.Refresh();

     

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
        /// <param name="dg">DataGridView</param>
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
    }
}
