using System;
using System.Collections.Generic;
using System.Data;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using System.IO;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsCtl_MedicineAcceptance : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 入库统计报表中间件访问类
        /// </summary>
        private clsDcl_MedicineAcceptance m_objDomain = null;
        /// <summary>
        /// 入库统计报表窗体
        /// </summary>
        private FrmMedicineAcceptance m_objViewer = null;

        
        public clsCtl_MedicineAcceptance()
        {
            m_objDomain = new clsDcl_MedicineAcceptance();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (FrmMedicineAcceptance)frmMDI_Child_Base_in;
        }
        #endregion

        #region 汇总
        internal void m_mthMedicineAcceptance(string p_strReportName)
        {
            DataTable dtbValue = new DataTable();
            DataTable dtbValue_Med = new DataTable();
        
            string strEndDate;
            strEndDate = Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd 23:59:59");

            m_objDomain.m_lngGetAcceptance(m_objViewer.m_strStorageID, Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text),Convert.ToDateTime(strEndDate), out dtbValue);
            if (m_objViewer.m_chkStatOut.Checked)
            {
                m_objDomain.m_lngGetAcceptance_Med(m_objViewer.m_strStorageID, Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text), Convert.ToDateTime(strEndDate), out dtbValue_Med);
            }
            //合并入库统计及外退统计
            DataTable dtbStatistics = m_dtbMergeStatisticsData(dtbValue, dtbValue_Med);
            m_objViewer.m_dwcData.DataWindowObject = "medicineacceptance";
            m_objViewer.m_dwcData.Modify("t_date.text='" + m_objViewer.m_dtpBeginDate.Text + " 到 " + m_objViewer.m_dtpEndDate.Text + "'");
            m_objViewer.m_dwcData.Modify("t_titel.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "中标药品入库分类汇总(" + m_objViewer.m_strStorageName + ")'");

            if (dtbStatistics == null || dtbStatistics.Rows.Count < 0)
            {
                MessageBox.Show("没有找到任何数据！", "药品入库分类汇总", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // if (m_objViewer.m_dwcData.DataWindowObject != "")
                {
                   m_objViewer.m_dwcData.Reset();

                }
                return;
            }
            m_objViewer.m_dwcData.SetRedrawOff();
            m_objViewer.m_dwcData.Retrieve(dtbStatistics);
            m_objViewer.m_dwcData.SetRedrawOn();
            m_objViewer.m_dwcData.Refresh();
        }
        #endregion

        #region 明细
        internal void m_lngGetAcceptanceDetal(string p_strReportName)
        {
            DataTable dtbValue = new DataTable();
            DataTable dtbValue_Med = new DataTable();

            string strEndDate;
            strEndDate = Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd 23:59:59");

            m_objDomain.m_lngGetAcceptanceDetal(m_objViewer.m_strStorageID, Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text), Convert.ToDateTime(strEndDate), out dtbValue);
            if (m_objViewer.m_chkStatOut.Checked)
            {
                m_objDomain.m_lngGetAcceptanceDetal_Med(m_objViewer.m_strStorageID, Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text), Convert.ToDateTime(strEndDate), out dtbValue_Med);
            }
            //合并入库统计及外退统计
            DataTable dtbStatistics = m_dtbMergeStatisticsDataDetal(dtbValue, dtbValue_Med);
            if (dtbStatistics == null || dtbStatistics.Rows.Count < 0)
            {
                MessageBox.Show("没有找到任何数据！", "药品入库分类汇总", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            m_objViewer.m_dtbPrint = dtbStatistics.Copy();
            dtbStatistics.Columns.Remove("topprice");//查询的列比DataWindow的列多1列，所以移去

            m_objViewer.m_dwcData.DataWindowObject = p_strReportName == "" ? "medicineacceptancedetal" : "medicineacceptancedetal_" + p_strReportName;
            m_objViewer.m_dwcData.Modify("t_date.text='" + m_objViewer.m_dtpBeginDate.Text + " 到 " + m_objViewer.m_dtpEndDate.Text + "'");
            m_objViewer.m_dwcData.Modify("t_titel.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "中标药品进仓明细("+ m_objViewer.m_strStorageName +")'");
          
            m_objViewer.m_dwcData.SetRedrawOff();
            m_objViewer.m_dwcData.Retrieve(dtbStatistics);
            m_objViewer.m_dwcData.SetRedrawOn();
            m_objViewer.m_dwcData.Refresh();
        }
        #endregion

        #region 获取仓库名
        internal void m_mthGetStoreRoomName(out string strStorageName)
        {
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID,out strStorageName);
        }
        #endregion

        #region 合并入库统计及外退统计
        /// <summary>
        /// 合并入库统计及外退统计
        /// </summary>
        /// <param name="p_dtbData">入库统计表数据</param>
        /// <param name="p_dtbForeignRetreat">外退统计表数据</param>
        /// <returns></returns>
        private DataTable m_dtbMergeStatisticsData(DataTable p_dtbData, DataTable p_dtbForeignRetreat)
        {
            DataTable dtbReturn = null;

            if ((p_dtbData == null || p_dtbData.Rows.Count == 0) && (p_dtbForeignRetreat == null || p_dtbForeignRetreat.Rows.Count == 0))
            {
                return null;
            }

            #region 只有其中一表有数据，则返回该表，不合并
            if (p_dtbData != null && p_dtbData.Rows.Count > 0 && (p_dtbForeignRetreat == null || p_dtbForeignRetreat.Rows.Count == 0))
            {
                dtbReturn = p_dtbData;
                return dtbReturn;
            }
            if (p_dtbForeignRetreat != null && p_dtbForeignRetreat.Rows.Count > 0 && (p_dtbData == null || p_dtbData.Rows.Count == 0))
            {
                DataRow drTemp = null;
                int intRowsCount = p_dtbForeignRetreat.Rows.Count;
                string strVendorName = string.Empty;//供应商名
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = p_dtbForeignRetreat.Rows[iRow];
                    strVendorName = drTemp["vendorname_vchr"].ToString();
                    if (string.IsNullOrEmpty(strVendorName))
                    {
                        drTemp["vendorname_vchr"] = "退";
                    }
                    else
                    {
                        drTemp["vendorname_vchr"] = "退(" + strVendorName + ")";
                    }
                    drTemp["callprice_int"] = 0 - Convert.ToDouble(drTemp["callprice_int"]);
                    drTemp["retailprice_int"] = 0 - Convert.ToDouble(drTemp["retailprice_int"]);
                    drTemp["limitunitprice_mny"] = 0 - Convert.ToDouble(drTemp["limitunitprice_mny"]);
                }
                dtbReturn = p_dtbForeignRetreat;
                return dtbReturn;
            }
            #endregion

            int intInDataCount = p_dtbData.Rows.Count;//入库统计行数            
            DataRow drInTemp = null;
            for (int iInRow = 0; iInRow < intInDataCount; iInRow++)
            {
                drInTemp = p_dtbData.Rows[iInRow];
                //获取相同供应商相同分类的数据行
                DataRow[] drOut = p_dtbForeignRetreat.Select("vendorname_vchr = '" + drInTemp["vendorname_vchr"].ToString() + "'");
               
                if (drOut != null && drOut.Length > 0)
                {
                    //入库统计中的金额减去外退金额
                    double dblCallprice_int = Convert.ToDouble(drInTemp["callprice_int"]);
                    double dblRetailMoney = Convert.ToDouble(drInTemp["retailprice_int"]);
                    double dblLimitunitprice = Convert.ToDouble(drInTemp["limitunitprice_mny"]);
                    
                    for (int iRow = 0; iRow < drOut.Length; iRow++)
                    {
                        dblCallprice_int -= Convert.ToDouble(drOut[iRow]["callprice_int"]);
                        dblRetailMoney -= Convert.ToDouble(drOut[iRow]["retailprice_int"]);
                        dblLimitunitprice -= Convert.ToDouble(drOut[iRow]["limitunitprice_mny"]);
                    }
                    drInTemp["callprice_int"] = dblCallprice_int.ToString("0.0000");
                    drInTemp["retailprice_int"] = dblRetailMoney.ToString("0.0000");
                    drInTemp["limitunitprice_mny"] = dblLimitunitprice.ToString("0.0000");
                    foreach (DataRow drDel in drOut)
                    {
                        p_dtbForeignRetreat.Rows.Remove(drDel);
                    }
                }
            }

            #region 处理外退数据
            //如有剩余外退统计供应商数据，即此外退供应商未能与入库统计中的供应商相对应，则在供应商名前标明"退"
            //同时将这些数据添加至返回表中
            int intOutDataCount = p_dtbForeignRetreat.Rows.Count;
            if (intOutDataCount > 0)
            {
                DataRow drTemp = null;
                string strVendorName = string.Empty;//供应商名
                for (int iRow = 0; iRow < intOutDataCount; iRow++)
                {
                    drTemp = p_dtbForeignRetreat.Rows[iRow];
                    strVendorName = drTemp["vendorname_vchr"].ToString();
                    if (string.IsNullOrEmpty(strVendorName))
                    {
                        drTemp["vendorname_vchr"] = "退";
                    }
                    else
                    {
                        drTemp["vendorname_vchr"] = "退(" + strVendorName + ")";
                    }
                    drTemp["callprice_int"] = 0 - Convert.ToDouble(drTemp["callprice_int"]);
                    drTemp["retailprice_int"] = 0 - Convert.ToDouble(drTemp["retailprice_int"]);
                    drTemp["limitunitprice_mny"] = 0 - Convert.ToDouble(drTemp["limitunitprice_mny"]);
                }
                dtbReturn = p_dtbForeignRetreat;
            }
            #endregion

            if (dtbReturn != null)//有剩余外退统计供应商数据
            {
                try
                {
                    dtbReturn.BeginLoadData();
                    for (int iInRow = 0; iInRow < intInDataCount; iInRow++)
                    {
                        dtbReturn.LoadDataRow(p_dtbData.Rows[iInRow].ItemArray, true);
                    }
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
                finally
                {
                    dtbReturn.EndLoadData();
                }
            }
            else
            {
                dtbReturn = p_dtbData;
            }
            return dtbReturn;
        }


        #endregion

        #region 合并入库统计及外退统计(明细)
        /// <summary>
        /// 合并入库统计及外退统计(明细)
        /// </summary>
        /// <param name="p_dtbData">入库统计表数据</param>
        /// <param name="p_dtbForeignRetreat">外退统计表数据</param>
        /// <returns></returns>
        private DataTable m_dtbMergeStatisticsDataDetal(DataTable p_dtbData, DataTable p_dtbForeignRetreat)
        {
            DataTable dtbReturn = null;

            if ((p_dtbData == null || p_dtbData.Rows.Count == 0) && (p_dtbForeignRetreat == null || p_dtbForeignRetreat.Rows.Count == 0))
            {
                return null;
            }

            #region 只有其中一表有数据，则返回该表，不合并
            if (p_dtbData != null && p_dtbData.Rows.Count > 0 && (p_dtbForeignRetreat == null || p_dtbForeignRetreat.Rows.Count == 0))
            {
                dtbReturn = p_dtbData;
                return dtbReturn;
            }
            if (p_dtbForeignRetreat != null && p_dtbForeignRetreat.Rows.Count > 0 && (p_dtbData == null || p_dtbData.Rows.Count == 0))
            {
                DataRow drTemp = null;
                int intRowsCount = p_dtbForeignRetreat.Rows.Count;
                string strVendorName = string.Empty;//供应商名
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = p_dtbForeignRetreat.Rows[iRow];
                    strVendorName = drTemp["vendorname_vchr"].ToString();
                    if (string.IsNullOrEmpty(strVendorName))
                    {
                        drTemp["vendorname_vchr"] = "退";
                    }
                    else
                    {
                        drTemp["vendorname_vchr"] = "退(" + strVendorName + ")";
                    }
                    drTemp["netamount_int"] = 0 - Convert.ToDouble(drTemp["netamount_int"]);
                }
                dtbReturn = p_dtbForeignRetreat;
                return dtbReturn;
            }
            #endregion

            int intInDataCount = p_dtbData.Rows.Count;//入库统计行数            
            DataRow drInTemp = null;
            for (int iInRow = 0; iInRow < intInDataCount; iInRow++)
            {
                drInTemp = p_dtbData.Rows[iInRow];
                //获取相同供应商相同分类的数据行

                DataRow[] drOut = p_dtbForeignRetreat.Select("medicineid_chr = '" + drInTemp["medicineid_chr"].ToString() + "' and callprice_int = '" + drInTemp["callprice_int"].ToString() + "'");
                //DataRow[] drOut = p_dtbForeignRetreat.Select();
                if (drOut != null && drOut.Length > 0)
                {
                    //入库统计中的金额减去外退金额
                    double dblNetamount_int = Convert.ToDouble(drInTemp["netamount_int"]);
                   
                    for (int iRow = 0; iRow < drOut.Length; iRow++)
                    {
                        dblNetamount_int -= Convert.ToDouble(drOut[iRow]["netamount_int"]);
                        
                    }
                    drInTemp["netamount_int"] = dblNetamount_int.ToString("0.0000");
                   

                    foreach (DataRow drDel in drOut)
                    {
                        p_dtbForeignRetreat.Rows.Remove(drDel);
                    }
                }
            }

            #region 处理外退数据
            //如有剩余外退统计供应商数据，即此外退供应商未能与入库统计中的供应商相对应，则在供应商名前标明"退"
            //同时将这些数据添加至返回表中
            int intOutDataCount = p_dtbForeignRetreat.Rows.Count;
            if (intOutDataCount > 0)
            {
                DataRow drTemp = null;
                string strVendorName = string.Empty;//供应商名
                for (int iRow = 0; iRow < intOutDataCount; iRow++)
                {
                    drTemp = p_dtbForeignRetreat.Rows[iRow];
                    strVendorName = drTemp["vendorname_vchr"].ToString();
                    if (string.IsNullOrEmpty(strVendorName))
                    {
                        drTemp["vendorname_vchr"] = "退";
                    }
                    else
                    {
                        drTemp["vendorname_vchr"] = "退(" + strVendorName + ")";
                    }
                    drTemp["netamount_int"] = 0 - Convert.ToDouble(drTemp["netamount_int"]);
    
                }
                dtbReturn = p_dtbForeignRetreat;
            }
            #endregion

            if (dtbReturn != null)//有剩余外退统计供应商数据
            {
                try
                {
                    dtbReturn.BeginLoadData();
                    for (int iInRow = 0; iInRow < intInDataCount; iInRow++)
                    {
                        dtbReturn.LoadDataRow(p_dtbData.Rows[iInRow].ItemArray, true);
                    }
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
                finally
                {
                    dtbReturn.EndLoadData();
                }
            }
            else
            {
                dtbReturn = p_dtbData;
            }
            return dtbReturn;
        }


        #endregion


        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="p_dt">DataTable</param>
        internal void m_mthOutExcel(DataTable p_dt)
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
    }
}
