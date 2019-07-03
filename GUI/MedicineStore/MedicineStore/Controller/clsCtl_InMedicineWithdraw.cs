using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    #region 药品内退主窗体控制类
    /// <summary>
    /// 药品内退主窗体控制类
    /// </summary>
    class clsCtl_InMedicineWithdraw : com.digitalwave.GUI_Base.clsController_Base
    {
        DataTable Query_dtbResult = new DataTable();//数据库返回的结果集
        //private frmInStorageMedicineWithdrawDetail m_objViewer;
        #region 构造函数

        public clsCtl_InMedicineWithdraw()
        {
            m_objDomain = new clsDcl_InMedicineWithdraw();
        }


        #endregion

        #region 字段

        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_InMedicineWithdraw m_objDomain = null;

        
        /// <summary>
        /// 供应商

        /// </summary>
        private DataTable m_dtbVendor = null;

        /// <summary>
        /// 药品退药次数查询条件

        /// </summary>
        private clsMs_MedicineWithdrawNumQueryCondition_VO m_objMedicineWithdrawNumCondition = null;

        /// <summary>
        /// 同一出库单的药品已退数量查询条件
        /// </summary>
        private clsMs_MedicineWithdrawNumQueryCondition_VO m_objMedicineWithdrawSumCondition = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmInStorageMedicineInnerWithdraw m_objViewer;


        /// <summary>
        /// 查询供应商控件

        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;

        /// <summary>
        /// 查询员工控件
        /// </summary>
        private ctlQueryEmployee m_ctlEMP = null;

        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);

            m_objViewer = (frmInStorageMedicineInnerWithdraw)frmMDI_Child_Base_in;
        }



        #endregion

        #region 显示供应商查询


        /// <summary>
        /// 获取供应商信息


        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetVendor(out p_dtbVendor);
        }


        /// <summary>
        /// 显示供应商查询

        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_mthGetVendor(out m_dtbVendor);
                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = m_objViewer.panel1.Location.X + m_objViewer.m_txtProviderName.Location.X;
                int Y = m_objViewer.panel1.Location.Y + m_objViewer.m_txtProviderName.Location.Y + m_objViewer.m_txtProviderName.Size.Height;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtProviderName.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtProviderName.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtProviderName.Text = MS_VO.m_strVendorName;

            //m_objViewer.m_txtMedicineName.Focus();
        }

        #endregion

        #region 设置员工至列表


        /// <summary>
        /// 设置员工至列表

        /// </summary>
        /// <param name="p_strSearch">搜索字符串</param>
        /// <param name="p_txtEmp">员工控件</param>
        internal void m_mthSetEmpToList(string p_strSearch, TextBox p_txtEmp)
        {
            DataTable dtbEmp = null;
            long lngRes = m_objDomain.m_lngGetEMP(p_strSearch, out dtbEmp);

            if (dtbEmp == null || dtbEmp.Rows.Count == 0)
            {
                p_txtEmp.Tag = null;
            }

            if (m_ctlEMP == null)
            {
                m_ctlEMP = new ctlQueryEmployee();
                m_objViewer.Controls.Add(m_ctlEMP);
            }
            m_ctlEMP.m_mthSetTxtBase(p_txtEmp);
            m_ctlEMP.BringToFront();
            int X = m_objViewer.panel1.Location.X + p_txtEmp.Location.X;
            int Y = m_objViewer.panel1.Location.Y + p_txtEmp.Location.Y + p_txtEmp.Size.Height;

            if ((X + m_ctlEMP.Size.Width) > m_objViewer.Size.Width)
            {
                X = m_objViewer.panel1.Location.X + p_txtEmp.Location.X - (X + m_ctlEMP.Size.Width - m_objViewer.Size.Width);
            }
            m_ctlEMP.Location = new System.Drawing.Point(X, Y);
            m_ctlEMP.ReturnInfo += new ReturnEmpInfo(m_ctlEMP_ReturnInfo);

            try
            {
                int intRowCount = dtbEmp.Rows.Count;
                DataRow drCurrent = null;
                List<ListViewItem> lstItems = new List<ListViewItem>();
                for (int iRow = 0; iRow < intRowCount; iRow++)
                {
                    drCurrent = dtbEmp.Rows[iRow];
                    ListViewItem lsi = new ListViewItem(drCurrent["EMPNO_CHR"].ToString());
                    lsi.SubItems.Add(drCurrent["LASTNAME_VCHR"].ToString());
                    lsi.Tag = drCurrent;
                    lstItems.Add(lsi);
                }
                m_ctlEMP.AddRange(lstItems.ToArray());
                if (lstItems.Count == 0)
                {
                    p_txtEmp.Tag = null;
                }
                m_ctlEMP.Visible = true;
                m_ctlEMP.Focus();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
        }

        private void m_ctlEMP_ReturnInfo(DataRow DR_EMP, TextBox Sender)
        {
            Sender.Tag = null;
            if (DR_EMP != null)
            {
                Sender.Tag = DR_EMP["EMPID_CHR"].ToString();
                Sender.Text = DR_EMP["LASTNAME_VCHR"].ToString();
            }

        }
        #endregion

        #region 获取仓库名


        /// <summary>
        /// 获取仓库名


        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <returns></returns>
        internal string m_strStoreRoomName(string p_strStoreRoomID)
        {
            string strStoreRoomName = string.Empty;
            long lngRes = m_objDomain.m_lngGetStoreRoomName(p_strStoreRoomID, out strStoreRoomName);
            return strStoreRoomName;
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药剂类型
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetMedicineType(out clsValue_MedicineType_VO[] p_objResultArr)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_objDomain.m_lngGetResultByMedicineType(out p_objResultArr);
            }
            catch
            {
                lngRes = 0;
                p_objResultArr = null;
                MessageBox.Show("获取药品剂型时出错！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lngRes;
        }
        #endregion

        #region 获取药品内退主表数据
        /// <summary>
        /// 获取药品内退数据
        /// </summary>
        /// <param name="objvalue_Param">查询条件</param>
        /// <param name="dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_mthGetMedicineInnerWithdrawData(ref clsMs_InMedicineWithdrawQueryCondition_VO objvalue_Param, out DataTable dtbResult)
        {
            long lngRes = 0;
            int m_intState = 0;
            m_objViewer.m_lblBuyInMoney.Text = string.Empty;
            m_objViewer.m_lblRetailMoney.Text = string.Empty;

            try
            {
                //调用Com+服务端


                DataTable Query_dtbResult = new DataTable();//数据库返回的结果集


                lngRes = m_objDomain.m_lngGetMedicineInnerWithdrawData(ref objvalue_Param, ref Query_dtbResult);
                if (lngRes > 0)
                {
                    DataColumn[] drColumns = new DataColumn[] { new DataColumn("SortNum"), new DataColumn("STATEName") };
                    drColumns[0].DataType = typeof(int);
                    Query_dtbResult.Columns.AddRange(drColumns);
                    Query_dtbResult.AcceptChanges();
                    DataRow m_dtbRow = null;
                    for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
                    {
                        m_dtbRow = Query_dtbResult.Rows[i1];
                        m_dtbRow["SortNum"] = i1 + 1;
                        int.TryParse(m_dtbRow["state_int"].ToString(), out m_intState);
                        switch (m_intState)
                        {
                            case 0:
                                m_dtbRow["STATEName"] = "删除";
                                break;
                            case 1:
                                m_dtbRow["STATEName"] = "新制";
                                break;
                            case 2:
                                m_dtbRow["STATEName"] = "审核";
                                break;
                            case 3:
                                m_dtbRow["STATEName"] = "入帐";
                                break;
                        }
                    }

                    
                    dtbResult = Query_dtbResult;
                    m_mthGetAllMoney();
                    //ComputeBillSum单据金额
                    //DataTable Stat_dtbResult = new DataTable();//处理后生成的统计表



                    ////统计查询
                    //if (blnQueryFlag == true)
                    //{
                    //    m_GroupSum(objvalue_Param.m_strStorageName, ref Query_dtbResult, ref Stat_dtbResult, ref m_objStatValue);
                    //    dtbResult = Stat_dtbResult;
                    //    Query_dtbResult = null;
                    //}
                    //else//明细查询
                    //{
                    //    m_DetailQuery(objvalue_Param.m_strStorageName, ref Query_dtbResult, ref m_objStatValue);
                    //    dtbResult = Query_dtbResult;
                    //}
                }
                else
                    dtbResult = null;

                return lngRes;
            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                MessageBox.Show("查询失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            dtbResult = null;
            return lngRes;

        }
        #endregion

        #region 获取指定日期内的金额
        /// <summary>
        /// 获取指定日期内的金额
        /// </summary>
        internal void m_mthGetAllMoney()
        {
            m_objViewer.m_lblBuyInMoney.Text = string.Empty;
            m_objViewer.m_lblRetailMoney.Text = string.Empty;

            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));

            long lngRes = m_objDomain.m_lngGetAllInMoney(dtmBegin, dtmEnd, m_objViewer.m_strStorageID, 2, out m_objViewer.m_dtbAllMoney);
            //if (m_objViewer.m_dtbAllMoney == null)
            //{
            //    long lngRes = m_objDomain.m_lngGetAllInMoney(dtmBegin, dtmEnd, m_objViewer.m_strStorageID, 2, out m_objViewer.m_dtbAllMoney);
            //}

            if (m_objViewer.m_dtbAllMoney != null && m_objViewer.m_dtbAllMoney.Rows.Count == 0)
            {
                m_objViewer.m_dtbAllMoney = null;
            }

            if (m_objViewer.m_dtbAllMoney != null && m_objViewer.m_dtbMedicineInnerWithdraw != null)
            {
                StringBuilder stbFilter = new StringBuilder(100);
                int intRowsCount = m_objViewer.m_dtbMedicineInnerWithdraw.Rows.Count;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    stbFilter.Append(" seriesid_int =");
                    stbFilter.Append(m_objViewer.m_dtbMedicineInnerWithdraw.Rows[iRow]["SERIESID_INT"].ToString());
                    if (iRow < intRowsCount - 1)
                    {
                        stbFilter.Append(" or ");
                    }
                }

                string strFilterResult = stbFilter.ToString();

                if (!string.IsNullOrEmpty(strFilterResult))
                {
                    DataRow[] drAllMoney = m_objViewer.m_dtbAllMoney.Select(strFilterResult);

                    if (drAllMoney != null && drAllMoney.Length > 0)
                    {
                        decimal dcmBuyIn = 0m;
                        decimal dcmRetailSale = 0m;
                        for (int iM = 0; iM < drAllMoney.Length; iM++)
                        {
                            dcmBuyIn += Convert.ToDecimal(drAllMoney[iM]["BuyInMoney"]);
                            dcmRetailSale += Convert.ToDecimal(drAllMoney[iM]["retailmoney"]);
                        }

                        m_objViewer.m_lblBuyInMoney.Text = dcmBuyIn.ToString("0.0000");
                        m_objViewer.m_lblRetailMoney.Text = dcmRetailSale.ToString("0.0000");
                    }
                }
            }
        }

        /// <summary>
        /// 获取明细金额
        /// </summary>
        internal void m_mthGetAllSubMoney()
        {
            m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
            m_objViewer.m_lblWholeSaleSubMoney.Text = string.Empty;
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;

            if (m_objViewer.m_dtbMedicineInnerWithdrawDetail != null)
            {
                double dcmBuyIn = 0d;
                double dcmWholeSale = 0d;
                double dcmRetailSale = 0d;
                DataRow drTemp = null;
                for (int iM = 0; iM < m_objViewer.m_dtbMedicineInnerWithdrawDetail.Rows.Count; iM++)
                {
                    drTemp = m_objViewer.m_dtbMedicineInnerWithdrawDetail.Rows[iM];
                    dcmBuyIn += Convert.ToDouble(drTemp["CALLPRICE_INT"]) * Convert.ToDouble(drTemp["AMOUNT"]);
                    dcmWholeSale += Convert.ToDouble(drTemp["WHOLESALEPRICE_INT"]) * Convert.ToDouble(drTemp["AMOUNT"]);
                    dcmRetailSale += Convert.ToDouble(drTemp["RETAILPRICE_INT"]) * Convert.ToDouble(drTemp["AMOUNT"]);
                }

                m_objViewer.m_lblBuyInSubMoney.Text = dcmBuyIn.ToString("0.0000");
                m_objViewer.m_lblRetailSubMoney.Text = dcmRetailSale.ToString("0.0000");
                m_objViewer.m_lblWholeSaleSubMoney.Text = dcmWholeSale.ToString("0.0000");
            }
        }
        #endregion


        #region 获取药品内退明细数据

        /// <summary>
        /// 获取药品内退明细数据
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long m_mthGetMedicineInnerWithdrawDetailData(ref clsMs_MedicineWithdrawDetailQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
            m_objViewer.m_lblWholeSaleSubMoney.Text = string.Empty;
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;
            try
            {

                //调用Com+服务端

               // DataTable Query_dtbResult = new DataTable();//数据库返回的结果集

                lngRes = m_objDomain.m_lngGetMedicineInnerWithdrawDetailData(ref objvalue_Param, ref Query_dtbResult);
                if (lngRes > 0)
                {
                    clsMs_MedicineWithdrawNumQueryCondition_VO m_objMedicineWithdrawNumCondition = new clsMs_MedicineWithdrawNumQueryCondition_VO();
                    DataRow m_dtbRow = null;
                    DataRow m_dtbResultRow = null;
                    decimal m_decOutStorageAvailAmount = 0;
                    decimal m_decCancelAvailAmount = 0;
                    decimal m_decAvailAmount = 0;
                    decimal m_decNetAmount = 0;
                    decimal m_decCallPrice = 0;
                    decimal m_decRetailPrice = 0;
                    decimal m_decWholesalePrice = 0;
                    decimal m_decMedicineWithdrawSum = 0;
                    string m_strLotNo = string.Empty;

                    for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
                    {
                        m_dtbResultRow = Query_dtbResult.Rows[i1];
                        m_dtbRow = dtbResult.NewRow();

                        m_dtbRow["SortNum"] = i1 + 1;

                        decimal.TryParse(m_dtbResultRow["AMOUNT"].ToString(), out  m_decAvailAmount);

                        decimal.TryParse(m_dtbResultRow["CALLPRICE_INT"].ToString(), out m_decCallPrice);
                        decimal.TryParse(m_dtbResultRow["RETAILPRICE_INT"].ToString(), out m_decRetailPrice);
                        decimal.TryParse(m_dtbResultRow["WHOLESALEPRICE_INT"].ToString(), out m_decWholesalePrice);

                        m_dtbRow["SERIESID_INT"] = m_dtbResultRow["SERIESID_INT"];
                        m_dtbRow["SERIESID2_INT"] = m_dtbResultRow["SERIESID2_INT"];


                        m_dtbRow["MEDICINEID_CHR"] = m_dtbResultRow["MEDICINEID_CHR"];
                        m_dtbRow["ASSISTCODE_CHR"] = m_dtbResultRow["ASSISTCODE_CHR"];
                        m_dtbRow["MEDICINENAME_VCH"] = m_dtbResultRow["MEDICINENAME_VCH"];
                        m_dtbRow["MEDSPEC_VCHR"] = m_dtbResultRow["MEDSPEC_VCHR"];
                        m_dtbRow["LOTNO_VCHR"] = m_dtbResultRow["LOTNO_VCHR"];

                        //药品当前库存
                        m_dtbRow["AVAILAGROSS_INT"] = m_dtbResultRow["realgross_int"];

                        //出库数量
                        decimal.TryParse(m_dtbResultRow["NETAMOUNT_INT"].ToString(), out m_decNetAmount);
                        m_dtbRow["NETAMOUNT_INT"] = m_decNetAmount;


                        m_dtbRow["AMOUNT"] = m_dtbResultRow["AMOUNT"];//退药数量

                        //已退数量
                        m_dtbRow["CancelAmount"] = 0;
                        //可退数量
                        m_dtbRow["AvailAmount"] = m_decNetAmount;

                        m_dtbRow["OPUNIT_CHR"] = m_dtbResultRow["UNIT_VCHR"];
                        m_dtbRow["CALLPRICE_INT"] = m_dtbResultRow["CALLPRICE_INT"];
                        m_dtbRow["CallSum"] = m_decAvailAmount * m_decCallPrice;
                        m_dtbRow["RetailSum"] = m_decAvailAmount * m_decRetailPrice;
                        m_dtbRow["RETAILPRICE_INT"] = m_dtbResultRow["RETAILPRICE_INT"];

                        m_dtbRow["WHOLESALEPRICE_INT"] = m_dtbResultRow["WHOLESALEPRICE_INT"];
                        m_dtbRow["INSTORAGEID_VCHR"] = m_dtbResultRow["INSTORAGEID_VCHR"];
                        m_dtbRow["OUTSTORAGEID_VCHR"] = m_dtbResultRow["OUTSTORAGEID_VCHR"];
                        m_dtbRow["PRODUCTORID_CHR"] = m_dtbResultRow["productorid_chr"];
                        m_dtbRow["VALIDPERIOD_DAT"] = m_dtbResultRow["validperiod_dat"];//有效期

                        m_dtbRow["RUTURNNUM_INT"] = m_dtbResultRow["ruturnnum_int"];//内退次数
                        m_dtbRow["withdrawsum"] = m_decAvailAmount * m_decCallPrice;//内退金额
                        //m_dtbRow["PACKCONVERT_INT"] = m_dtbOutStorageDetail.Rows[i1][""];
                        //m_dtbRow["PACKAMOUNT"] = m_dtbOutStorageDetail.Rows[i1][""];
                        //m_dtbRow["PACKUNIT_VCHR"] = m_dtbOutStorageDetail.Rows[i1][""];
                        //m_dtbRow["PACKCALLPRICE_INT"] = m_dtbOutStorageDetail.Rows[i1][""];
                        m_dtbRow["medicinetypeid_chr"] = m_dtbResultRow["medicinetypeid_chr"].ToString();
                        m_dtbRow["SortNum"] = i1 + 1;

                        dtbResult.Rows.Add(m_dtbRow);

                    }
                    dtbResult.AcceptChanges();

                    //已退药数量

                    m_objMedicineWithdrawNumCondition.m_strStorageID = objvalue_Param.m_strStorageID;
                    m_objMedicineWithdrawNumCondition.m_strOutStorageID = string.Empty;
                    m_objMedicineWithdrawNumCondition.m_strInStorageID = objvalue_Param.m_strInStorageID;
                    m_mthGetInnerWithdrawDetailNum(m_objMedicineWithdrawNumCondition, ref dtbResult);
                    m_mthGetAllSubMoney();
                }
                else
                    dtbResult = null;

                return lngRes;
            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                MessageBox.Show("查询失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            dtbResult = null;
            return lngRes;

        }
        #endregion

        #region 查询内退明细时获取退药次数和退药数量


        private void m_mthGetInnerWithdrawDetailNum(clsMs_MedicineWithdrawNumQueryCondition_VO p_objValueParam, ref DataTable Query_dtbResult)
        {
            DataTable m_dtbResult = new DataTable();

            
            decimal m_decNetAmount = 0;
            decimal m_decReturnNum = 0;
            decimal m_decReturnAmount = 0;
            decimal m_decTmpReturnAmount = 0;
            string m_strMedicineID = string.Empty;
            string m_strLotNo = string.Empty;
            string m_strOutStorageID = string.Empty;
            string m_strInStorageID = string.Empty;
            DataRow m_dtbQueryRow = null;
            DataRow m_dtbResultRow = null;

            m_objDomain.m_lngGetMedicineWithdrawSum(ref p_objValueParam, ref  m_dtbResult);
            if ((m_dtbResult != null) && (m_dtbResult.Rows.Count > 0))
            {
                for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
                {
                    m_dtbQueryRow = Query_dtbResult.Rows[i1];
                    m_strMedicineID = m_dtbQueryRow["MEDICINEID_CHR"].ToString();
                    m_strLotNo = m_dtbQueryRow["LOTNO_VCHR"].ToString();
                    m_strOutStorageID = m_dtbQueryRow["outstorageid_vchr"].ToString();
                    m_strInStorageID = m_dtbQueryRow["INSTORAGEID_VCHR"].ToString().Trim();
                    decimal.TryParse(m_dtbQueryRow["NETAMOUNT_INT"].ToString(), out  m_decNetAmount);
                    m_decReturnAmount = 0;
                    for (int j1 = 0; j1 < m_dtbResult.Rows.Count; j1++)
                    {
                        m_dtbResultRow = m_dtbResult.Rows[j1];
                        if ((m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim() == m_strMedicineID)
                            && (m_dtbResultRow["LOTNO_VCHR"].ToString().Trim() == m_strLotNo)
                            && (m_dtbResultRow["outstorageid_vchr"].ToString().Trim() == m_strOutStorageID)
                            && (m_dtbResultRow["instorageid_vchr"].ToString().Trim() == m_strInStorageID))
                        {
                            m_decReturnNum++;
                            decimal.TryParse(m_dtbResultRow["amount"].ToString(), out m_decTmpReturnAmount);
                            m_decReturnAmount += m_decTmpReturnAmount;
                        }
                    }
                    m_dtbQueryRow["CancelAmount"] = m_decReturnAmount;
                    //可退数量
                    m_dtbQueryRow["AvailAmount"] = m_decNetAmount - m_decReturnAmount;//可退数量

                }//for
            }//if
        }
        #endregion


        #region 退审时获取当前库存、实际库存、可用库存


        /// <summary>
        /// 退审时获取当前库存、实际库存、可用库存

        /// </summary>
        /// <param name="p_objValueParam"></param>
        /// <param name="Query_dtbResult"></param>
        internal long m_lngCheckMedicineGross(string p_strStorageID, string p_strInStorageID,ref DataTable p_dtbDetail)
        {
            decimal decRealGross = 0;
            decimal decAvailGross = 0;
            //要退审的总数量

            decimal decTotalGross = 0;
            //返回的当前库存

            decimal decCurrGross = 0;
            //退药数量

            decimal decAmount = 0;
            clsMs_MedicineWithdrawNumQueryCondition_VO objValueParam = new clsMs_MedicineWithdrawNumQueryCondition_VO();
            DataTable Query_dtbResult = null;
            DataRow drCurrRow = null;
            DataRow drResult = null;
            //int intRowIndex = 0;
            //intRowIndex = m_objViewer.m_dgvMainInfo.CurrentRow.Index;

            objValueParam.m_strStorageID = p_strStorageID;
            objValueParam.m_strInStorageID = p_strInStorageID;
            //获取库存
            m_objDomain.m_lngDclGetMedicineGross(ref objValueParam, ref  Query_dtbResult);

            if ((Query_dtbResult != null) && (Query_dtbResult.Rows.Count > 0))
            {
                DataRow[] drNew = null;


                //验证当前库存、可用库存和实际库存
                for (int i1 = 0; i1 < p_dtbDetail.Rows.Count; i1++)
                {
                    drCurrRow = p_dtbDetail.Rows[i1];

                    objValueParam.m_strMedicineID = drCurrRow["MEDICINEID_CHR"].ToString();
                    objValueParam.m_strLotNo = drCurrRow["LOTNO_VCHR"].ToString();

                    drNew = p_dtbDetail.Select("medicineid_chr = '" + objValueParam.m_strMedicineID + "'");
                    decTotalGross = 0;
                    if ((drNew != null) && (drNew.Length > 0))
                    {
                        decimal.TryParse(drCurrRow["AMOUNT"].ToString(), out decAmount);
                        decTotalGross += decAmount;
                    }




                    for (int j1 = 0; j1 < Query_dtbResult.Rows.Count; j1++)
                    {
                        drResult = Query_dtbResult.Rows[j1];
                        //验证当前库存
                        if (objValueParam.m_strMedicineID == drResult["MEDICINEID_CHR"].ToString().Trim())
                        {
                            decimal.TryParse(Query_dtbResult.Rows[0]["currentgross_num"].ToString(), out decCurrGross);
                            if (decTotalGross > decCurrGross)
                                return -1;
                        }

                        //验证可用库存和实际库存

                        if ((objValueParam.m_strMedicineID == drResult["MEDICINEID_CHR"].ToString().Trim())
                            && (objValueParam.m_strLotNo == drResult["LOTNO_VCHR"].ToString().Trim()))
                        {
                            decimal.TryParse(drResult["availagross_int"].ToString(), out decAvailGross);
                            decimal.TryParse(drResult["realgross_int"].ToString(), out decRealGross);
                            decimal.TryParse(drCurrRow["AMOUNT"].ToString(), out decAmount);
                            if ((decAmount > decAvailGross) || (decAmount > decRealGross))
                            {
                                return -1;
                            }
                        }

                    }//for                    

                }//for
                return 1;
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region 修改选定的入库单
        /// <summary>
        /// 修改选定的入库单
        /// </summary>
        /// <param name="p_objMain">主表</param>
        /// <param name="p_objSubVO">子表</param>
        internal void m_mthModifySelected(out clsMS_InStorage_VO p_objMain, out clsMS_InStorageDetail_VO[] p_objSubVO)
        {
            p_objMain = null;
            p_objSubVO = null;
            #region 主表VO
            clsMS_InStorage_VO objMain = null;
            if (m_objViewer.m_dgvMainInfo.SelectedRows.Count == 1)
            {
                DataRow drvMain = m_objViewer.m_dtbMedicineInnerWithdraw.Rows[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index];
                //int intState = Convert.ToInt32(drvMain["STATE_INT"]);
                //if (intState != 1)
                //{
                //    MessageBox.Show("非新制表单不能修改", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                objMain = new clsMS_InStorage_VO();
                objMain.m_lngSERIESID_INT = Convert.ToInt64(drvMain["SERIESID_INT"]);
                objMain.m_intSTATE_INT = Convert.ToInt32(drvMain["STATE_INT"]);
                objMain.m_strSTORAGEID_CHR = drvMain["STORAGEID_CHR"].ToString();
                objMain.m_strINSTORAGEID_VCHR = drvMain["INSTORAGEID_VCHR"].ToString();
                //objMain.m_m_strBUYERID_CHAR = drvMain["RETURNDEPT_CHR"].ToString();
                objMain.m_strMAKERID_CHR = drvMain["MAKERID_CHR"].ToString();
                objMain.m_strVENDORID_CHR = drvMain["VENDORID_CHR"].ToString();
                objMain.m_strVENDORName = drvMain["vendorname_vchr"].ToString();
                objMain.m_strRETURNDEPT_CHR = drvMain["RETURNDEPT_CHR"].ToString();
                objMain.m_dtmNEWORDER_DAT = Convert.ToDateTime(drvMain["neworder_dat"].ToString());
                //objMain.m_dtmNEWORDER_DAT = Convert.ToDateTime(drvMain["neworder_dat"].ToString("yy-mm-dd 00:00:00"));

                //objMain.m_strMAKERName = drvMain["makername"].ToString();

                //objMain.m_strACCOUNTERID_CHAR = drvMain["ACCOUNTERID_CHAR"].ToString();
                //objMain.m_strSTORAGERID_CHAR = drvMain["STORAGERID_CHAR"].ToString();
                DateTime.TryParse(drvMain["INSTORAGEDATE_DAT"].ToString(), out objMain.m_dtmINSTORAGEDATE_DAT);

            }

            if (objMain == null)
            {
                return;
            }
            p_objMain = objMain;
            #endregion

            #region 子表VO
            clsMS_InStorageDetail_VO[] objSubVO = null;
            DataTable dvSub = m_objViewer.m_dgvSubInfo.DataSource as DataTable;
            if (dvSub != null && dvSub.Rows.Count > 0)
            {
                DataRow drvCurrent = null;
                objSubVO = new clsMS_InStorageDetail_VO[dvSub.Rows.Count];
                for (int iRow = 0; iRow < m_objViewer.m_dgvSubInfo.Rows.Count; iRow++)
                {
                    drvCurrent = dvSub.Rows[iRow];
                    objSubVO[iRow] = new clsMS_InStorageDetail_VO();
                    objSubVO[iRow].m_lngSERIESID_INT = Convert.ToInt64(drvCurrent["SERIESID_INT"]);
                    objSubVO[iRow].m_lngSERIESID_INT2 = Convert.ToInt64(drvCurrent["SERIESID2_INT"]);
                    objSubVO[iRow].m_strMEDICINEID_CHR = drvCurrent["MEDICINEID_CHR"].ToString();

                    objSubVO[iRow].m_strMEDICINENAME_VCH = drvCurrent["MEDICINENAME_VCH"].ToString();
                    objSubVO[iRow].m_strMEDSPEC_VCHR = drvCurrent["MEDSPEC_VCHR"].ToString();


                    //if (drvCurrent["PACKAMOUNT"] != DBNull.Value)
                    //{
                    //    objSubVO[iRow].m_dblPACKAMOUNT = Convert.ToDouble(drvCurrent["PACKAMOUNT"]);
                    //}
                    //objSubVO[iRow].m_strPACKUNIT_VCHR = drvCurrent["PACKUNIT_VCHR"].ToString();
                    //if (drvCurrent["PACKCALLPRICE_INT"] != DBNull.Value)
                    //{
                    //    objSubVO[iRow].m_dcmPACKCALLPRICE_INT = Convert.ToDecimal(drvCurrent["PACKCALLPRICE_INT"]);
                    //}
                    //if (drvCurrent["PACKCONVERT_INT"] != DBNull.Value)
                    //{
                    //    objSubVO[iRow].m_dblPACKCONVERT_INT = Convert.ToDouble(drvCurrent["PACKCONVERT_INT"]);
                    //}
                    objSubVO[iRow].m_strLOTNO_VCHR = drvCurrent["LOTNO_VCHR"].ToString();
                    objSubVO[iRow].m_dblAMOUNT = Convert.ToDouble(drvCurrent["AMOUNT"]);
                    objSubVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drvCurrent["CALLPRICE_INT"]);
                    objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drvCurrent["WHOLESALEPRICE_INT"]);
                    objSubVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drvCurrent["RETAILPRICE_INT"]);
                    objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drvCurrent["VALIDPERIOD_DAT"]);

                    //if (drvCurrent["ACCEPTANCE_INT"] != DBNull.Value)
                    //{
                    //    objSubVO[iRow].m_intACCEPTANCE_INT = Convert.ToInt32(drvCurrent["ACCEPTANCE_INT"]);
                    //}
                    //objSubVO[iRow].m_strAPPROVECODE_VCHR = drvCurrent["APPROVECODE_VCHR"].ToString();
                    //if (drvCurrent["APPARENTQUALITY_INT"] != DBNull.Value)
                    //{
                    //    objSubVO[iRow].m_intAPPARENTQUALITY_INT = Convert.ToInt32(drvCurrent["APPARENTQUALITY_INT"]);
                    //}
                    //if (drvCurrent["PACKQUALITY_INT"] != DBNull.Value)
                    //{
                    //    objSubVO[iRow].m_intPACKQUALITY_INT = Convert.ToInt32(drvCurrent["PACKQUALITY_INT"]);
                    //}
                    //if (drvCurrent["EXAMRUSULT_INT"] != DBNull.Value)
                    //{
                    //    objSubVO[iRow].m_intEXAMRUSULT_INT = Convert.ToInt32(drvCurrent["EXAMRUSULT_INT"]);
                    //}
                    //objSubVO[iRow].m_strEXAMINER = drvCurrent["EXAMINER"].ToString();
                    //objSubVO[iRow].m_strEXAMINERName = drvCurrent["examinername"].ToString();
                    objSubVO[iRow].m_strPRODUCTORID_CHR = drvCurrent["PRODUCTORID_CHR"].ToString();
                    //objSubVO[iRow].m_strACCEPTANCECOMPANY_CHR = drvCurrent["ACCEPTANCECOMPANY_CHR"].ToString();
                    //objSubVO[iRow].m_strACCEPTANCECOMPANYName = drvCurrent["ACCEPTANCECOMPANYname"].ToString();
                    objSubVO[iRow].m_strUNIT_VCHR = drvCurrent["OPUNIT_CHR"].ToString();
                    //objSubVO[iRow].m_strMEDICINECode = drvCurrent["MedicineCode"].ToString();
                    //objSubVO[iRow].m_strMEDICINEPREPTYPE_CHR = drvCurrent["MEDICINEPREPTYPE_CHR"].ToString();
                }
            }
            p_objSubVO = objSubVO;
            #endregion
        }
        #endregion

        #region 删除药品信息
        /// <summary>
        /// 删除药品信息
        /// </summary>
        internal void m_mthDeleteMedicine()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能删除", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            bool blnNewState = false;
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                    clsDcl.m_lngCheckBillState(1, m_objViewer.m_dtbMedicineInnerWithdraw.Rows[iSe]["INSTORAGEID_VCHR"].ToString(), out blnNewState);
                    if (!blnNewState)
                    {
                        MessageBox.Show("已选中的内退单，包含不是新制状态的单据，请刷新后重试", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    int intState = Convert.ToInt32(m_objViewer.m_dtbMedicineInnerWithdraw.Rows[iSe]["STATE_INT"]);
                    if (intState == 2 || intState == 3)//已审核或已入帐
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtbMedicineInnerWithdraw.Rows[iSe]["SERIESID_INT"]));
                        continue;
                    }
                    lngCheckRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtbMedicineInnerWithdraw.Rows[iSe]["SERIESID_INT"]));
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录已审核或已入账，将不能删除，是否继续？", "药品内退", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先选择一条药品内退记录", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否删除选中记录？", "药品内退", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }


            long lngRes = m_objDomain.m_lngDeleteMainInStorage(lngCheckRowIndex.ToArray());
            if (lngRes > 0)
            {
                MessageBox.Show("删除成功", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if (m_objViewer.m_dtbMedicineInnerWithdrawDetail != null)
                //{
                //    while (m_objViewer.m_dtbMedicineInnerWithdrawDetail.Rows.Count > 0)
                //    {
                //        m_objViewer.m_dtbMedicineInnerWithdrawDetail.Rows.RemoveAt(0);
                //    }
                //    m_objViewer.m_dtbMedicineInnerWithdrawDetail.AcceptChanges();
                //}


                StringBuilder stbFilter = new StringBuilder(50);
                for (int iSer = 0; iSer < lngCheckRowIndex.Count; iSer++)
                {
                    stbFilter.Append(" SERIESID_INT = '");
                    stbFilter.Append(lngCheckRowIndex[iSer]);
                    stbFilter.Append("'");
                    if (iSer < lngCheckRowIndex.Count - 1)
                    {
                        stbFilter.Append(" or ");
                    }
                }
                DataRow[] drRemove = m_objViewer.m_dtbMedicineInnerWithdraw.Select(stbFilter.ToString());
                if (drRemove != null && drRemove.Length > 0)
                {
                    for (int iRev = 0; iRev < drRemove.Length; iRev++)
                    {
                        m_objViewer.m_dtbMedicineInnerWithdraw.Rows.Remove(drRemove[iRev]);
                    }
                }

                DataView dtvSub = m_objViewer.m_dgvSubInfo.DataSource as DataView;
                if (dtvSub != null)
                {
                    dtvSub.Table.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("删除失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 获取是否审核即入帐
        /// <summary>
        /// 获取是否审核即入帐
        /// </summary>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        internal void m_mthGetIsImmAccount(out bool p_blnIsImmAccount)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetIsImmAccount(out p_blnIsImmAccount);
            objPDDomain = null;
        }
        #endregion

        #region 审核内退药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        /// <param name="p_drCommit">审核的行</param>
        internal void m_mthCommitMedicine()
        {
            //p_drCommit = null;

            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能审核", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    if (drCheck["STATE_INT"].ToString() == "1")
                    {
                        lstCheck.Add(drCheck);
                    }
                }
            }

            DataRow[] drNew = lstCheck.ToArray();

            if (drNew == null || drNew.Length == 0)
            {
                MessageBox.Show("没有需审核的药品入库信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                long lngRes = 0;
                long lngSEQ = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
                DataTable dtbDetail = null;
                //clsMS_StorageDetail[] objDetailTemp = null;//各入库单需要审核的明细VO
                clsMS_StorageGrossForOut m_objStorageGrossForOut = new clsMS_StorageGrossForOut();
                clsMS_StorageGrossForOut[] m_objStorageGrossForOutArr = null;
                //DataRow m_drResultRow = null;


                long[] lngSEQArr = new long[1];
                DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                for (int iRow = 0; iRow < drNew.Length; iRow++)
                {
                    lngSEQ = Convert.ToInt64(drNew[iRow]["SERIESID_INT"]);
                    

                    string strStatus = null;
                    long lng = this.m_objDomain.m_lngReturnInStroageStatus(lngSEQ.ToString(), out strStatus);
                    if (strStatus != "1")
                    {
                        MessageBox.Show("药品内退单据状态已改变,请重新加载数据!", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //获取明细数据
                    lngRes = m_objDomain.m_lngDclGetWithdrawDetailData(lngSEQ, ref dtbDetail);

                    bool blnIsInitial = m_blnIsInitialWithdraw(dtbDetail);//是否为内退初始化

                    if (blnIsInitial)
                    {
                        long lngIni = m_lngCommitInitialMedicine(dtbDetail, drNew[iRow]["INSTORAGEID_VCHR"].ToString(), drNew[iRow]["VENDORID_CHR"].ToString(), drNew[iRow]["RETURNDEPT_CHR"].ToString(), lngSEQ, dtmNow);
                        if (lngIni > 0)
                        {
                            lngSEQArr[0] = lngSEQ;
                            lngRes = m_objDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSEQArr);

                            drNew[iRow]["STATE_INT"] = m_objViewer.m_blnIsImmAccount ? 3 : 2;
                            drNew[iRow]["STATEName"] = m_objViewer.m_blnIsImmAccount ? "入帐" : "审核";
                            drNew[iRow]["EXAM_DAT"] = dtmNow;
                            
                        }
                        continue;
                    }

                    if (lngRes > 0)
                    {
                        m_objStorageGrossForOutArr = new clsMS_StorageGrossForOut[dtbDetail.Rows.Count];
                        //设置审核人
                        clsMS_StorageDetail[] objStDetail = m_objDetailVO(dtbDetail);
                        clsMS_AccountDetail_VO[] objAccDetail = m_objAccountDetail(dtbDetail, dtmNow, drNew[iRow]["INSTORAGEID_VCHR"].ToString(), drNew[iRow]["returndept_chr"].ToString());

                        lngRes = m_objDomain.m_lngCommit(objStDetail, objAccDetail, m_objViewer.LoginInfo.m_strEmpID, dtmNow, lngSEQ, drNew[iRow]["INSTORAGEID_VCHR"].ToString(), m_objViewer.m_blnIsImmAccount);
                        
                        if (lngRes <= 0)
                        {
                            MessageBox.Show("审核失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        //for (int j1 = 0; j1 < dtbDetail.Rows.Count; j1++)
                        //{
                        //    m_drResultRow = dtbDetail.Rows[j1];
                        //    //增加库存主表当前库存
                        //    double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objStorageGrossForOut.m_dblGross);
                        //    m_objStorageGrossForOut.m_strMedicineID = m_drResultRow["MEDICINEID_CHR"].ToString();
                        //    m_objStorageGrossForOut.m_strStorageID = drNew[iRow]["STORAGEID_CHR"].ToString();

                        //    lngRes = m_objDomain.m_lngModifyStorageMain(m_objStorageGrossForOut);
                        //    if (lngRes <= 0)
                        //    {
                        //        MessageBox.Show("审核失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //        return;
                        //    }


                        //    m_objStorageGrossForOutArr[j1] = new clsMS_StorageGrossForOut();
                        //    double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objStorageGrossForOutArr[j1].m_dblGross);
                        //    m_objStorageGrossForOutArr[j1].m_strStorageID = drNew[iRow]["STORAGEID_CHR"].ToString();
                        //    m_objStorageGrossForOutArr[j1].m_strMedicineID = m_drResultRow["MEDICINEID_CHR"].ToString();
                        //    m_objStorageGrossForOutArr[j1].m_strLotNO = m_drResultRow["LOTNO_VCHR"].ToString();
                        //    m_objStorageGrossForOutArr[j1].m_strInStorageID = m_drResultRow["INSTORAGEID_VCHR"].ToString();
                        //}
                        ////增加库存明细表可用库存

                        //m_objDomain.m_lngAddStorageDetailAvailaGrossDcl(m_objStorageGrossForOutArr);
                        ////增加库存明细表实际库存

                        //lngRes = m_objDomain.m_lngDclAddStorageDetailRealGross(m_objStorageGrossForOutArr);
                        if (lngRes > 0)
                        {
                            drNew[iRow]["STATE_INT"] = m_objViewer.m_blnIsImmAccount ? 3 : 2;
                            drNew[iRow]["STATEName"] = m_objViewer.m_blnIsImmAccount ? "入帐" : "审核";
                            drNew[iRow]["EXAM_DAT"] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else if (lngRes <= 0)
                        {
                            MessageBox.Show("审核失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("没有需审核的药品入库信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }//for
                MessageBox.Show("审核完成", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


            }//try
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

        }

        #region 根据数据返回库存子表VO
        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_dtbDetail">数据</param>
        /// <param name="p_strInID">入库单号</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(DataTable p_dtbDetail, string p_strInID, string p_strVendorID, string p_strDEPTID, string p_strVendorName)
        {
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0)
            {
                return null;
            }

            DataRow drCurrent = null;
            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_dtbDetail.Rows.Count];
            for (int iRow = 0; iRow < p_dtbDetail.Rows.Count; iRow++)
            {
                drCurrent = p_dtbDetail.Rows[iRow];
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objSubVO[iRow].m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCH"].ToString();
                objSubVO[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                objSubVO[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                objSubVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drCurrent["RETAILPRICE_INT"]);
                objSubVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                if (drCurrent["WHOLESALEPRICE_INT"] != DBNull.Value)
                {
                    objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drCurrent["WHOLESALEPRICE_INT"]);
                }
                objSubVO[iRow].m_dblREALGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_dblAVAILAGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_strOPUNIT_VCHR = drCurrent["UNIT_VCHR"].ToString();
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                objSubVO[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();
                objSubVO[iRow].m_strINSTORAGEID_VCHR = p_strInID;
                objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                objSubVO[iRow].m_strVENDORID_CHR = p_strVendorID;
                objSubVO[iRow].m_strVENDORName = p_strVendorName;
                objSubVO[iRow].m_strMEDICINETYPEID_CHR = drCurrent["medicinetypeid_chr"].ToString();
                objSubVO[iRow].m_intStatus = 1;

                objSubVO[iRow].m_strDEPTID_CHR = p_strDEPTID;

            }
            return objSubVO;
        }

        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_dtbDetail">数据</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(DataTable p_dtbDetail)
        {
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0)
            {
                return null;
            }

            DataRow drCurrent = null;
            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_dtbDetail.Rows.Count];
            for (int iRow = 0; iRow < p_dtbDetail.Rows.Count; iRow++)
            {
                drCurrent = p_dtbDetail.Rows[iRow];
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objSubVO[iRow].m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCH"].ToString();
                objSubVO[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                objSubVO[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                objSubVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drCurrent["RETAILPRICE_INT"]);
                objSubVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                if (drCurrent["WHOLESALEPRICE_INT"] != DBNull.Value)
                {
                    objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drCurrent["WHOLESALEPRICE_INT"]);
                }
                objSubVO[iRow].m_dblREALGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_dblAVAILAGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_strOPUNIT_VCHR = drCurrent["UNIT_VCHR"].ToString();
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                objSubVO[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();
                objSubVO[iRow].m_strINSTORAGEID_VCHR = drCurrent["INSTORAGEID_VCHR"].ToString();
                objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //objSubVO[iRow].m_strVENDORID_CHR = p_strVendorID;
                //objSubVO[iRow].m_strVENDORName = p_strVendorName;
                objSubVO[iRow].m_intStatus = 1;
            }
            return objSubVO;
        }

        /// <summary>
        /// 入帐明细
        /// </summary>
        /// <param name="p_dtbData">数据</param>
        /// <param name="p_dtmAccDate">入账日期</param>
        /// <param name="p_strInID">内退单据号</param>
        /// <param name="p_strReturnDept">内退部门ID</param>
        /// <returns></returns>
        private clsMS_AccountDetail_VO[] m_objAccountDetail(DataTable p_dtbData,DateTime p_dtmAccDate, string p_strInID, string p_strReturnDept)
        {
            if (p_dtbData == null || p_dtbData.Rows.Count == 0)
            {
                return null;
            }

            int intRowsCount = p_dtbData.Rows.Count;
            clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[intRowsCount];
            int intAccState = m_objViewer.m_blnIsImmAccount ? 1 : 2;//入帐明细状态
            DateTime dtmInDate = m_objViewer.m_blnIsImmAccount ? p_dtmAccDate : DateTime.MinValue;//入账日期
            string strInEmp = m_objViewer.m_blnIsImmAccount ? m_objViewer.LoginInfo.m_strEmpID : string.Empty;//入账人

            DataRow drCurrent = null;
            for (int iAcc = 0; iAcc < intRowsCount; iAcc++)
            {
                drCurrent = p_dtbData.Rows[iAcc];
                objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                objAccArr[iAcc].m_dblAMOUNT_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objAccArr[iAcc].m_dblCALLPRICE_INT = Convert.ToDouble(drCurrent["CALLPRICE_INT"]);
                //杨镇伟添加,控制药品库存为空时预防审核不过报错09-11-02
                if (drCurrent["realgross_int"] == DBNull.Value)
                {
                    objAccArr[iAcc].m_dblOLDGROSS_INT = 0.0;
                }
                else {
                    objAccArr[iAcc].m_dblOLDGROSS_INT = Convert.ToDouble(drCurrent["realgross_int"]);    
                }
                objAccArr[iAcc].m_dblRETAILPRICE_INT = Convert.ToDouble(drCurrent["RETAILPRICE_INT"]);
                objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = Convert.ToDouble(drCurrent["WHOLESALEPRICE_INT"]);
                objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                objAccArr[iAcc].m_intFORMTYPE_INT = 2;
                objAccArr[iAcc].m_intISEND_INT = 0;
                objAccArr[iAcc].m_intSTATE_INT = intAccState;
                objAccArr[iAcc].m_intTYPE_INT = 1;
                objAccArr[iAcc].m_strCHITTYID_VCHR = p_strInID;
                objAccArr[iAcc].m_strDEPTID_CHR = p_strReturnDept;
                objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                objAccArr[iAcc].m_strINSTORAGEID_VCHR = drCurrent["INSTORAGEID_VCHR"].ToString();
                objAccArr[iAcc].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                objAccArr[iAcc].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objAccArr[iAcc].m_strMEDICINENAME_VCH = drCurrent["MEDICINENAME_VCH"].ToString();
                objAccArr[iAcc].m_strMEDICINETYPEID_CHR = drCurrent["medicinetypeid_chr"].ToString();
                objAccArr[iAcc].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                objAccArr[iAcc].m_strOPUNIT_CHR = drCurrent["UNIT_VCHR"].ToString();
                objAccArr[iAcc].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objAccArr[iAcc].m_dtmOperateDate = p_dtmAccDate;
                objAccArr[iAcc].m_dtmValidDate = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);

                //objAccArr[iAcc].m_strDEPTID_CHR = drCurrent["DEPTID_CHR"].ToString();

            }
            return objAccArr;
        }
        #endregion

        #region 设置审核人

        /// <summary>
        /// 设置审核人

        /// </summary>
        /// <param name="p_drCommit">数据</param>
        private void m_mthSetCommitUser(DataRow[] p_drCommit)
        {
            if (p_drCommit == null || p_drCommit.Length == 0)
            {
                return;
            }

            long[] lngSEQ = new long[p_drCommit.Length];
            for (int iRow = 0; iRow < p_drCommit.Length; iRow++)
            {
                lngSEQ[iRow] = Convert.ToInt64(p_drCommit[iRow]["SERIESID_INT"]);
            }

            long lngRes = m_objDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSEQ);
        }
        #endregion


        #endregion

        #region 退审


        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_drCurrent">选定药品数据</param>
        /// <param name="p_intRowIndex">第几行数据</param>
        internal void m_mthUnCommit()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能退审", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;

                    string strStatus = null;
                    long lng = this.m_objDomain.m_lngReturnInStroageStatus(drCheck["SERIESID_INT"].ToString(), out strStatus);
                    if (strStatus != "2")
                    {
                        MessageBox.Show("药品内退单据状态已改变,请重新加载数据!", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (drCheck["STATE_INT"].ToString() == "2")
                    {
                        lstCheck.Add(drCheck);
                    }
                }
            }

            DataRow[] drNew = lstCheck.ToArray();

            if (drNew == null || drNew.Length == 0)
            {
                MessageBox.Show("没有需退审的药品入库信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                long lngRes = 0;
                long lngSEQ = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
                DataTable dtbDetail = null;
                clsMS_StorageGrossForOut m_objStorageGrossForOut = new clsMS_StorageGrossForOut();
                clsMS_StorageGrossForOut[] m_objStorageGrossForOutArr = null;
                long[] lngSEQArr = new long[1];
                DataRow m_drResultRow = null;
                clsMS_StorageDetail[] m_objOutArr = new clsMS_StorageDetail[1];
                m_objOutArr[0] = new clsMS_StorageDetail();
                for (int iRow = 0; iRow < drNew.Length; iRow++)
                {
                    lngSEQ = Convert.ToInt64(drNew[iRow]["SERIESID_INT"]);
                    //获取明细数据
                    lngRes = m_objDomain.m_lngDclGetWithdrawDetailData(lngSEQ, ref dtbDetail);
                    if (lngRes > 0)
                    {
                        if ((dtbDetail != null) && (dtbDetail.Rows.Count > 0))
                        {
                            string m_strStorageID = string.Empty;
                            string m_strInStorageID = string.Empty;
                            m_strStorageID = drNew[iRow]["STORAGEID_CHR"].ToString();
                            m_strInStorageID = drNew[iRow]["INSTORAGEID_VCHR"].ToString();

                            long lngChkRes = m_lngCheckMedicineGross(m_strStorageID, m_strInStorageID, ref dtbDetail);
                            if (lngChkRes < 0)
                            {
                                MessageBox.Show("药品库存不足，不能退审", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                        }
                    }
                    bool blnIsInitial = m_blnIsInitialWithdraw(dtbDetail);//是否为内退初始化

                    if (blnIsInitial)
                    {
                        long lngIni = m_lngUnCommitInitialMedicine(dtbDetail, drNew[iRow]["INSTORAGEID_VCHR"].ToString(), lngSEQ);
                        if (lngIni > 0)
                        {
                            drNew[iRow]["STATE_INT"] = 1;
                            drNew[iRow]["STATEName"] = "新制";
                            drNew[iRow]["EXAM_DAT"] = DBNull.Value;
                        }
                        continue;
                    }

                    if (lngRes > 0)
                    {
                        m_objStorageGrossForOutArr = new clsMS_StorageGrossForOut[dtbDetail.Rows.Count];

                        clsMS_StorageDetail[] objStDetail = m_objDetailVO(dtbDetail);
                        lngRes = m_objDomain.m_lngUnCommit(objStDetail, lngSEQ, drNew[iRow]["INSTORAGEID_VCHR"].ToString());
                        //lngSEQArr[0] = lngSEQ;
                        ////设置审核人

                        //lngRes = m_objDomain.m_lngUnCommit(lngSEQArr);
                        //if (lngRes <= 0)
                        //{
                        //    MessageBox.Show("退审失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return;
                        //}

                        //for (int j1 = 0; j1 < dtbDetail.Rows.Count; j1++)
                        //{
                        //    m_drResultRow = dtbDetail.Rows[j1];
                        //    //减少库存主表当前库存
                        //    double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objStorageGrossForOut.m_dblGross);
                        //    m_objStorageGrossForOut.m_strMedicineID = m_drResultRow["MEDICINEID_CHR"].ToString();
                        //    m_objStorageGrossForOut.m_strStorageID = drNew[iRow]["STORAGEID_CHR"].ToString();
                        //    lngRes = m_objDomain.m_lngSubModifyStorageMain(m_objStorageGrossForOut);
                        //    if (lngRes <= 0)
                        //    {
                        //        MessageBox.Show("退审失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //        return;
                        //    }


                        //    m_objStorageGrossForOutArr[j1] = new clsMS_StorageGrossForOut();
                        //    double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objStorageGrossForOutArr[j1].m_dblGross);
                        //    m_objStorageGrossForOutArr[j1].m_strStorageID = drNew[iRow]["STORAGEID_CHR"].ToString();
                        //    m_objStorageGrossForOutArr[j1].m_strMedicineID = m_drResultRow["MEDICINEID_CHR"].ToString();
                        //    m_objStorageGrossForOutArr[j1].m_strLotNO = m_drResultRow["LOTNO_VCHR"].ToString();
                        //    m_objStorageGrossForOutArr[j1].m_strInStorageID = m_drResultRow["INSTORAGEID_VCHR"].ToString();

                        //    //修改库存明细可用库存
                        //    double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objOutArr[0].m_dblAVAILAGROSS_INT);
                        //    m_objOutArr[0].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                        //    m_objOutArr[0].m_strINSTORAGEID_VCHR = m_drResultRow["INSTORAGEID_VCHR"].ToString();
                        //    m_objOutArr[0].m_strMEDICINEID_CHR = m_drResultRow["MEDICINEID_CHR"].ToString();
                        //    m_objOutArr[0].m_strLOTNO_VCHR = m_drResultRow["LOTNO_VCHR"].ToString();

                        //    m_objDomain.m_lngSubStorageDetailAvailaGrossDcl(m_objOutArr);

                        //}
                        ////减少库存明细表实际库存

                        //lngRes = m_objDomain.m_lngDclSubStorageDetailRealGross(m_objStorageGrossForOutArr);

                        if (lngRes > 0)
                        {
                            drNew[iRow]["STATE_INT"] = 1;
                            drNew[iRow]["STATEName"] = "新制";
                            drNew[iRow]["EXAM_DAT"] = DBNull.Value;

                        }
                        else if (lngRes <= 0)
                        {
                            MessageBox.Show("退审失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("没有需退审的药品入库信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }//for

                MessageBox.Show("退审完成", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }//try
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

        }
        #endregion

        #region 检查是否有药库管理权限
        /// <summary>
        /// 检查是否有药库管理权限
        /// </summary>
        /// <param name="strEmpID">员工ID</param>
        /// <param name="p_blnHasRole">是否有权限</param>
        internal void m_mthCheckHasAdminRole(string strEmpID, out bool p_blnHasRole)
        {
            long lngRes = m_objDomain.m_lngCheckEmpHasRole(strEmpID, out p_blnHasRole);
        }
        #endregion

        #region 是否是初始化内退单据
        /// <summary>
        /// 是否是初始化内退单据
        /// </summary>
        /// <returns></returns>
        internal bool m_blnIsInitialWithdraw()
        {
            bool blnIsInitial = false;
            if (m_objViewer.m_dgvSubInfo.Rows.Count == 0)
            {
                return false;
            }

            bool blnIsAllNull = true;//初始化内退单据，出库单号全为空
            for (int iRow = 0; iRow < m_objViewer.m_dgvSubInfo.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvSubInfo.Rows[iRow].Cells["m_dgvtxtOutStorageBill"].Value != null
                    && !string.IsNullOrEmpty(m_objViewer.m_dgvSubInfo.Rows[iRow].Cells["m_dgvtxtOutStorageBill"].Value.ToString()))
                {
                    blnIsAllNull = false;
                    break;
                }
            }

            if (blnIsAllNull)
            {
                blnIsInitial = blnIsAllNull;
            }
            return blnIsInitial;
        }

        /// <summary>
        /// 是否是初始化内退单据
        /// </summary>
        /// <param name="p_dtbSub">子表内容</param>
        /// <returns></returns>
        internal bool m_blnIsInitialWithdraw(DataTable p_dtbSub)
        {
            bool blnIsInitial = false;
            if (p_dtbSub == null || p_dtbSub.Rows.Count == 0)
            {
                return false;
            }

            bool blnIsAllNull = true;//初始化内退单据，出库单号全为空
            for (int iRow = 0; iRow < p_dtbSub.Rows.Count; iRow++)
            {
                if (!string.IsNullOrEmpty(p_dtbSub.Rows[iRow]["OUTSTORAGEID_VCHR"].ToString()))
                {
                    blnIsAllNull = false;
                    break;
                }
            }

            if (blnIsAllNull)
            {
                blnIsInitial = blnIsAllNull;
            }
            return blnIsInitial;
        }
        #endregion

        #region 修改内退初始化

        /// <summary>
        /// 修改内退初始化

        /// </summary>
        /// <param name="objMain">主表内容</param>
        /// <param name="objSubVO">子表内容</param>
        internal void m_mthModifyInitialWithdraw(out clsMS_InStorage_VO objMain, out clsMS_InStorageDetail_VO[] objSubVO)
        {
            objMain = null;
            objSubVO = null;

            #region 主表
            if (m_objViewer.m_dgvMainInfo.SelectedRows.Count == 1)
            {
                DataRow drvMain = ((DataRowView)m_objViewer.m_dgvMainInfo.SelectedRows[0].DataBoundItem).Row;
                objMain = new clsMS_InStorage_VO();
                objMain.m_lngSERIESID_INT = Convert.ToInt64(drvMain["SERIESID_INT"]);
                objMain.m_intSTATE_INT = Convert.ToInt32(drvMain["STATE_INT"]);
                objMain.m_strSTORAGEID_CHR = drvMain["STORAGEID_CHR"].ToString();
                objMain.m_strINSTORAGEID_VCHR = string.Empty;
                objMain.m_strBUYERID_CHAR = string.Empty;
                DateTime dtmTemp = DateTime.MinValue;
                if (DateTime.TryParse(drvMain["EXAM_DAT"].ToString(), out dtmTemp))
                {
                    objMain.m_dtmEXAM_DAT = dtmTemp;
                }
                else
                {
                    objMain.m_dtmEXAM_DAT = DateTime.MinValue;
                }
                objMain.m_dtmACCOUNT_DAT = DateTime.MinValue;
                objMain.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(drvMain["INSTORAGEDATE_DAT"]);
                objMain.m_dtmINVOICEDATER_DAT = DateTime.MinValue;
                objMain.m_dtmNEWORDER_DAT = Convert.ToDateTime(drvMain["NEWORDER_DAT"]);
                objMain.m_dtmPAYDATE_DAT = DateTime.MinValue;
                objMain.m_intFORMTYPE_INT = 2;
                objMain.m_intINSTORAGETYPE_INT = 1;
                objMain.m_intPAYSTATE_INT = 0;
                objMain.m_strCOMMNET_VCHR = drvMain["COMMNET_VCHR"].ToString();
                objMain.m_strEXAMERID_CHR = drvMain["EXAMERID_CHR"].ToString();
                objMain.m_strMAKERID_CHR = drvMain["MAKERID_CHR"].ToString();
                objMain.m_strRETURNDEPT_CHR = drvMain["RETURNDEPT_CHR"].ToString();
                objMain.m_strINSTORAGEID_VCHR = drvMain["instorageid_vchr"].ToString();
                objMain.m_strVENDORID_CHR = drvMain["vendorid_chr"].ToString();
                objMain.m_strVENDORName = drvMain["vendorname_vchr"].ToString();
            }
            #endregion

            #region 子表
            DataTable dvSub = m_objViewer.m_dgvSubInfo.DataSource as DataTable;
            if (dvSub != null && dvSub.Rows.Count > 0)
            {
                objSubVO = new clsMS_InStorageDetail_VO[dvSub.Rows.Count];
                DataRow drCurrent = null;
                for (int iRow = 0; iRow < objSubVO.Length; iRow++)
                {
                    drCurrent = dvSub.Rows[iRow];
                    objSubVO[iRow] = new clsMS_InStorageDetail_VO();
                    objSubVO[iRow].m_dblAMOUNT = Convert.ToDouble(drCurrent["amount"]);
                    objSubVO[iRow].m_dblPACKAMOUNT = 0d;
                    objSubVO[iRow].m_dblPACKCONVERT_INT = 0d;
                    objSubVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                    objSubVO[iRow].m_dcmPACKCALLPRICE_INT = 0m;
                    objSubVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drCurrent["RETAILPRICE_INT"]);
                    objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drCurrent["WHOLESALEPRICE_INT"]);
                    objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                    objSubVO[iRow].m_intACCEPTANCE_INT = 1;
                    objSubVO[iRow].m_intAPPARENTQUALITY_INT = 1;
                    objSubVO[iRow].m_intEXAMRUSULT_INT = 1;
                    objSubVO[iRow].m_intPACKQUALITY_INT = 1;
                    objSubVO[iRow].m_intRUTURNNUM_INT = Convert.ToInt32(drCurrent["RUTURNNUM_INT"]);
                    objSubVO[iRow].m_intStatus = 1;
                    objSubVO[iRow].m_lngACCOUNTPERIOD_INT = 0;
                    objSubVO[iRow].m_lngSERIESID_INT = Convert.ToInt64(drCurrent["SERIESID_INT"]);
                    objSubVO[iRow].m_lngSERIESID_INT2 = Convert.ToInt64(drCurrent["SERIESID2_INT"]);
                    objSubVO[iRow].m_strACCEPTANCECOMPANY_CHR = string.Empty;
                    objSubVO[iRow].m_strAPPROVECODE_VCHR = string.Empty;
                    objSubVO[iRow].m_strEXAMINER = string.Empty;
                    objSubVO[iRow].m_strInStorageID = string.Empty;
                    objSubVO[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                    objSubVO[iRow].m_strMEDICINECode = drCurrent["assistcode_chr"].ToString();
                    objSubVO[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                    objSubVO[iRow].m_strMEDICINENAME_VCH = drCurrent["MEDICINENAME_VCH"].ToString();
                    objSubVO[iRow].m_strMEDICINEPREPTYPE_CHR = string.Empty;
                    objSubVO[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                    objSubVO[iRow].m_strOUTSTORAGEID_VCHR = string.Empty;
                    objSubVO[iRow].m_strPACKUNIT_VCHR = string.Empty;
                    objSubVO[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();
                    objSubVO[iRow].m_strUNIT_VCHR = drCurrent["OPUNIT_CHR"].ToString();
                    objSubVO[iRow].m_strMedicineTypeID_chr = drCurrent["medicinetypeid_chr"].ToString();
                }
            }
            #endregion
        }
        #endregion

        #region 审核药品内退初始化信息

        /// <summary>
        /// 审核药品内退初始化信息
        /// </summary>
        /// <param name="p_dtbMedicineInfo">审核的数据</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        internal long m_lngCommitInitialMedicine(DataTable p_dtbMedicineInfo, string p_strInStorageID, string p_strVendorID,string p_strDEPTID, long p_lngMainSEQ, DateTime p_dtmCommitDate)
        {
            if (p_dtbMedicineInfo == null || p_dtbMedicineInfo.Rows.Count == 0)
            {
                return 0;
            }

            try
            {
                long lngRes = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                clsMS_StorageDetail[] objAllDetail = m_objDetailVO(p_dtbMedicineInfo, p_strInStorageID, p_strVendorID,p_strDEPTID, string.Empty);

                if (objAllDetail == null || objAllDetail.Length == 0)
                {
                    return 0;
                }

                clsDcl_Purchase objPDomain = new clsDcl_Purchase();
                lngRes = objPDomain.m_lngCommitInStorage(objAllDetail, m_objViewer.LoginInfo.m_strEmpID, p_dtmCommitDate, p_lngMainSEQ, 2, p_strInStorageID, m_objViewer.m_blnIsImmAccount);
                
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return 1;
        }
        #endregion

        #region 退审药品内退初始化

        /// <summary>
        /// 退审药品内退初始化        /// </summary>
        /// <param name="p_dtbMedicineInfo">审核的数据</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="lngMainSEQ">入库主表序列号</param>
        internal long m_lngUnCommitInitialMedicine(DataTable p_dtbMedicineInfo, string p_strInStorageID, long lngMainSEQ)
        {
            long[] lngSEQ = new long[] { lngMainSEQ };
            long lngRes = m_objDomain.m_lngUnCommit(lngSEQ);

            clsMS_StorageDetail[] objAllDetail = m_objDetailVO(p_dtbMedicineInfo, p_strInStorageID, string.Empty, string.Empty, string.Empty);

            if (objAllDetail == null || objAllDetail.Length == 0)
            {
                return 0;
            }

            clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            long[] lngMainSEQArr = new long[] { lngMainSEQ };
            string[] strInIDArr = new string[] { p_strInStorageID };
            lngRes = objPDomain.m_lngUnCommit(m_objViewer.m_strStorageID, lngMainSEQArr, strInIDArr, objAllDetail);            
            return 1;
        }
        #endregion

        #region 打印
        internal void m_lngPring(string p_strEmpName,string m_strStoreRoomName,string m_strInnerWithdrawBillNo,string m_strTransactDate,string m_strWithdrawDept, DataTable m_dtbDetail,string m_strSum)
        //internal void m_lngPring(DataRow[] rows, DataTable m_dtbDetail)
        {
            frmInStorageMedicineWithdrawDetailReport frmRepot = new frmInStorageMedicineWithdrawDetailReport();
            decimal decBug = Convert.ToDecimal(m_strSum==""?"0":m_strSum);
            string mmm = new Money(decBug).ToString();
            frmRepot.decBug = mmm;
            frmRepot.strStoragename_chr = m_strStoreRoomName;
            frmRepot.strInstorageid_vchr = m_strInnerWithdrawBillNo;
            frmRepot.strExam_dat = m_strTransactDate;
           frmRepot.strReturndept_chr = m_strWithdrawDept;


            frmRepot.m_dtbDetail = m_dtbDetail.Copy();



            frmRepot.strMakername_chr = p_strEmpName;
            frmRepot.ShowDialog();
        }
        #endregion

        #region 获取领用部门信息
        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetExportDept(out p_dtbExportDept);
            objIRDomain = null;
        }
        #endregion

        #region 入账
        /// <summary>
        /// 入账
        /// </summary>
        internal void m_mthInAccount()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能将药品入帐", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            List<long> lstSeq = new List<long>();//主表序列
            List<string> lstInStorageID = new List<string>();//入库单据号
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    if (drCheck["STATE_INT"].ToString() == "2")
                    {
                        lstCheck.Add(drCheck);
                        lstSeq.Add(Convert.ToInt64(drCheck["seriesid_int"]));
                        lstInStorageID.Add(drCheck["instorageid_vchr"].ToString());
                    }
                }
            }

            DataRow[] drCommit = lstCheck.ToArray();

            if (drCommit == null || drCommit.Length == 0)
            {
                MessageBox.Show("没有需入帐的药品内退信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            long lngRes = objPDomain.m_lngInAccount(lstInStorageID.ToArray(), lstSeq.ToArray(), m_objViewer.m_strStorageID, m_objViewer.LoginInfo.m_strEmpID, dtmNow);
            objPDomain = null;

            if (lngRes > 0)
            {
                foreach (DataRow dr in drCommit)
                {
                    dr["STATE_INT"] = 3;
                    dr["STATEName"] = "入帐";
                }
                MessageBox.Show("入帐成功", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("入帐失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }


    #endregion 药品内退主窗体控制类



}
