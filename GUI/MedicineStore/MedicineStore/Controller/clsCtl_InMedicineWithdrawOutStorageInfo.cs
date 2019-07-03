using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品内退制单时弹出出库单信息窗口控制类

    /// </summary>
    class clsCtl_InMedicineWithdrawOutStorageInfo : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数

        public clsCtl_InMedicineWithdrawOutStorageInfo()
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
        private com.digitalwave.iCare.gui.MedicineStore.frmInMedicineCancelCallOutStorageInfo m_objViewer;

        /// <summary>
        /// 药品内退制单窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmInStorageMedicineWithdrawDetail m_objViewerMakerBill;


        /// <summary>
        /// 药品内退制单控制器

        /// </summary>
        private clsCtl_InMedicineWithdrawMakerBill m_objCtlMedicineWithdrawMakerBill = null;
        #endregion 字段

        public void m_mthSetMakerBillCtrl(clsCtl_InMedicineWithdrawMakerBill p_objCtlMedicineWithdrawMakerBill)
        {
            m_objCtlMedicineWithdrawMakerBill = p_objCtlMedicineWithdrawMakerBill;
            m_objViewerMakerBill = m_objCtlMedicineWithdrawMakerBill.m_objViewer;
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);

            m_objViewer = (frmInMedicineCancelCallOutStorageInfo)frmMDI_Child_Base_in;
        }

        #region 获取药品出库明细数据

        /// <summary>
        /// 获取药品出库明细数据
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long m_mthGetOutStorageDetailData(ref clsMs_MedicineWithdrawOutStorageQueryCondition_VO objvalue_Param)
        {
            long lngRes = 0;
            decimal m_decNetAmount = 0;//出库数量
            int m_intMedicineWithdrawNum = 0;//退药次数


            decimal m_decMedicineWithdrawSum = 0;//已退药数量


            decimal m_decAvailAmount = 0;//可退数量
            try
            {
                //调用Com+服务端


                DataTable Query_dtbResult = new DataTable();//数据库返回的结果集


                lngRes = m_objDomain.m_lngGetOutStorageDetailData_MakerBill(ref objvalue_Param, ref Query_dtbResult);
                if (lngRes > 0)
                {
                    DataColumn[] drColumns = new DataColumn[] {
                        new DataColumn("SortNum",typeof(int)), 
                        new DataColumn("ReturnAmount",typeof(decimal)), 
                        new DataColumn("AvailAmount",typeof(decimal)) ,
                        new DataColumn("AMOUNT",typeof(decimal)), 
                        new DataColumn("AVAILAGROSS_INT",typeof(decimal)) ,
                        //new DataColumn("validperiod_dat") ,
                        new DataColumn("ReturnNum",typeof(int))};
                    Query_dtbResult.Columns.AddRange(drColumns);
                    DataRow m_dtbResultRow = null;
                    DataRow m_dtbCancelDetailRow = null;
                    m_objMedicineWithdrawNumCondition = new clsMs_MedicineWithdrawNumQueryCondition_VO();
                    for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
                    {
                        m_dtbResultRow = Query_dtbResult.Rows[i1];
                        m_dtbResultRow["SortNum"] = i1 + 1;
                        m_objMedicineWithdrawNumCondition.m_strStorageID = m_dtbResultRow["STORAGEID_CHR"].ToString();
                        m_objMedicineWithdrawNumCondition.m_strMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString();
                        m_objMedicineWithdrawNumCondition.m_strLotNo = m_dtbResultRow["LOTNO_VCHR"].ToString();
                        m_objMedicineWithdrawNumCondition.m_strOutStorageID = m_dtbResultRow["OUTSTORAGEID_VCHR"].ToString();
                        m_objMedicineWithdrawNumCondition.m_strInStorageID = string.Empty;

                        ////退药次数


                        //m_objDomain.m_lngGetMedicineWithdrawNum(ref m_objMedicineWithdrawNumCondition, out  m_intMedicineWithdrawNum);
                        //m_dtbResultRow["ReturnNum"] = m_intMedicineWithdrawNum;


                        //出库数量
                        decimal.TryParse(m_dtbResultRow["NETAMOUNT_INT"].ToString(), out m_decNetAmount);

                        //已退药数量

                        m_dtbResultRow["ReturnAmount"] = 0;
                        //可退数量
                        m_dtbResultRow["AvailAmount"] = m_decNetAmount;
                        //退药数量

                        m_dtbResultRow["Amount"] = 0;
                        //内退次数
                        m_dtbResultRow["ReturnNum"] = 0;


                        //药品当前库存
                        m_dtbResultRow["AVAILAGROSS_INT"] = m_dtbResultRow["realgross_int"];
                        //m_dtbResultRow["validperiod_dat"] = m_dtbResultRow["validperiod_dat"];


                        //m_decAvailAmount = 0;
                        //for (int j1 = 0; j1 < m_dtbMedicineCancelDetail.Rows.Count; j1++)
                        //{
                        //    m_dtbCancelDetailRow = m_dtbMedicineCancelDetail.Rows[j1];
                        //    if ((m_dtbCancelDetailRow["MEDICINEID_CHR"].ToString().Trim() == m_objMedicineWithdrawNumCondition.m_strMedicineID)
                        //       && (m_dtbCancelDetailRow["OUTSTORAGEID_VCHR"].ToString().Trim() == m_objMedicineWithdrawNumCondition.m_strOutStorageID)
                        //       && (m_dtbCancelDetailRow["LOTNO_VCHR"].ToString().Trim() == m_objMedicineWithdrawNumCondition.m_strLotNo))
                        //    {
                        //        decimal.TryParse(m_dtbCancelDetailRow["Amount"].ToString(), out m_decAvailAmount);
                        //        break;
                        //    }
                        //}


                    }
                    Query_dtbResult.AcceptChanges();
                    //已退药数量


                    m_objMedicineWithdrawNumCondition.m_strStorageID = objvalue_Param.m_strStorageID;
                    m_objMedicineWithdrawNumCondition.m_strOutStorageID = objvalue_Param.m_strOutStorageID;
                    m_objMedicineWithdrawNumCondition.m_strInStorageID = string.Empty;
                    m_mthGetInnerWithdrawNum(m_objMedicineWithdrawNumCondition, ref Query_dtbResult);

                    m_objViewer.m_dtbOutStorageDetail = Query_dtbResult;
                }
                else
                    m_objViewer.m_dtbOutStorageDetail = null;

                return lngRes;
            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                MessageBox.Show("查询失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            m_objViewer.m_dtbOutStorageDetail = null;
            return lngRes;

        }
        #endregion

        #region 查询出库明细时获取退药次数和退药数量


        private void m_mthGetInnerWithdrawNum(clsMs_MedicineWithdrawNumQueryCondition_VO p_objValueParam, ref DataTable Query_dtbResult)
        {
            DataTable m_dtbResult = new DataTable();

            decimal m_decNetAmount = 0;//出库数量
            decimal m_decAvailAmount = 0;//可退数量


            decimal m_decReturnNum = 0;
            decimal m_decReturnAmount = 0;
            decimal m_decTmpReturnAmount = 0;
            string m_strMedicineID = string.Empty;
            string m_strLotNo = string.Empty;
            string m_strOutStorageID = string.Empty;
            DataRow m_dtbQueryRow = null;
            DataRow m_dtbResultRow = null;
            string m_strInStorageID = string.Empty;
            decimal m_callPrice = 0;
            decimal dbResultCallprice = 0;

            m_objDomain.m_lngGetMedicineWithdrawSum(ref p_objValueParam, ref  m_dtbResult);
            for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
            {
                m_dtbQueryRow = Query_dtbResult.Rows[i1];

                // 2018-12-24
                if (Convert.ToDecimal(m_dtbQueryRow["AvailAmount"]) == 0) continue;

                m_strMedicineID = m_dtbQueryRow["MEDICINEID_CHR"].ToString();
                m_strLotNo = m_dtbQueryRow["LOTNO_VCHR"].ToString();
                m_strOutStorageID = m_dtbQueryRow["outstorageid_vchr"].ToString();
                m_strInStorageID = m_dtbQueryRow["instorageid_vchr"].ToString();

                if(m_dtbQueryRow["callprice_int"] != DBNull.Value)
                    m_callPrice = Convert.ToDecimal(m_dtbQueryRow["callprice_int"].ToString());

                decimal.TryParse(m_dtbQueryRow["NETAMOUNT_INT"].ToString(), out m_decNetAmount);

                m_decReturnNum = 0;
                m_decReturnAmount = 0;
                for (int j1 = 0; j1 < m_dtbResult.Rows.Count; j1++)
                {
                    m_dtbResultRow = m_dtbResult.Rows[j1];

                    if (m_dtbResultRow["callprice_int"] != DBNull.Value)
                        dbResultCallprice = Convert.ToDecimal(m_dtbResultRow["callprice_int"].ToString());

                    if ((m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim() == m_strMedicineID)
                        && (m_dtbResultRow["LOTNO_VCHR"].ToString().Trim() == m_strLotNo)
                        && (m_dtbResultRow["outstorageid_vchr"].ToString().Trim() == m_strOutStorageID)
                        && (m_dtbResultRow["WithdrawInID"].ToString().Trim() == m_strInStorageID)
                        && (m_callPrice == dbResultCallprice))
                    {
                        m_decReturnNum++;
                        decimal.TryParse(m_dtbResultRow["amount"].ToString(), out m_decTmpReturnAmount);
                        m_decReturnAmount += m_decTmpReturnAmount;
                    }
                }
                //已退数量
                m_dtbQueryRow["ReturnAmount"] = m_decReturnAmount;
                //可退数量
                m_dtbQueryRow["AvailAmount"] = m_decNetAmount - m_decReturnAmount;
                //退药数量

                m_dtbQueryRow["Amount"] = 0;

                //内退次数
                m_dtbQueryRow["ReturnNum"] = m_decReturnNum;
            }
        }
        #endregion

        #region 选入已选中的记录

        /// <summary>
        /// 选入已选中的记录
        /// </summary>
        public void m_mthCall()
        {
            if ((m_objViewer.m_dtbOutStorageDetail != null) && (m_objViewer.m_dtbOutStorageDetail.Rows.Count > 0))
            {
                DataRow m_dtbCancelDetailRow = null;
                DataRow m_dtbOutStorageDetailRow = null;
                DataRow m_dtbRow = null;
                decimal m_decOutStorageAvailAmount = 0;
                decimal m_decCancelAvailAmount = 0;
                decimal m_decAvailAmount = 0;
                decimal m_decCallPrice = 0;
                decimal m_decRetailPrice = 0;
                decimal m_decWholesalePrice = 0;
                bool blnNewRow = false;
                int j1 = 0;
                for (int i1 = 0; i1 < m_objViewer.m_dtbOutStorageDetail.Rows.Count; i1++)
                {
                    if (Convert.ToBoolean(m_objViewer.m_dgvSubInfo.Rows[i1].Cells[0].Value))
                    {
                        m_dtbOutStorageDetailRow = m_objViewer.m_dtbOutStorageDetail.Rows[i1];
                        //blnNewRow = true;
                        for (j1 = 0; j1 < m_objViewerMakerBill.m_dtbDetail.Rows.Count; j1++)
                        {
                            m_dtbCancelDetailRow = m_objViewerMakerBill.m_dtbDetail.Rows[j1];
                            if ((m_dtbCancelDetailRow["MEDICINEID_CHR"].ToString().Trim() == m_dtbOutStorageDetailRow["MEDICINEID_CHR"].ToString())
                               && (m_dtbCancelDetailRow["LOTNO_VCHR"].ToString().Trim() == m_dtbOutStorageDetailRow["LOTNO_VCHR"].ToString())
                               && (m_dtbCancelDetailRow["OUTSTORAGEID_VCHR"].ToString().Trim() == m_dtbOutStorageDetailRow["OUTSTORAGEID_VCHR"].ToString()))
                            {
                                //MessageBox.Show("该药品已录入","药品内退",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                m_dtbCancelDetailRow["AMOUNT"] = Convert.ToDecimal(m_dtbOutStorageDetailRow["AMOUNT"]);    // 退药数量

                                break;
                            }
                        }

                        if (j1 == m_objViewerMakerBill.m_dtbDetail.Rows.Count)
                        {
                            clsMS_MedicineTypeVisionmSet clsTypeVO = new clsMS_MedicineTypeVisionmSet();
                            m_objDomain.m_lngGetMedicineTypeVisionm(m_dtbOutStorageDetailRow["MEDICINETYPEID_CHR"].ToString(), out clsTypeVO);

                            if (clsTypeVO != null && clsTypeVO.m_intLotno == 1 && m_objViewerMakerBill.m_dtbDetail.Rows[m_objViewerMakerBill.m_dgvMedicineDetail.CurrentRow.Index]["LOTNO_VCHR"].ToString().Trim() != "")
                            {
                                m_dtbRow = m_objViewerMakerBill.m_dtbDetail.NewRow();
                                blnNewRow = true;
                            }
                            else
                            {
                                m_dtbRow = m_objViewerMakerBill.m_dtbDetail.Rows[m_objViewerMakerBill.m_dgvMedicineDetail.CurrentRow.Index];
                                blnNewRow = false;
                            }

                            if (m_objViewerMakerBill.m_dtbDetail != null)
                            {
                                if (blnNewRow)
                                    m_dtbRow["SortNum"] = m_objViewerMakerBill.m_dtbDetail.Rows.Count + 1;
                            }
                            else
                            {
                                m_dtbRow["SortNum"] = 1;
                            }

                            decimal.TryParse(m_dtbOutStorageDetailRow["AvailAmount"].ToString(), out  m_decAvailAmount);

                            decimal.TryParse(m_dtbOutStorageDetailRow["CALLPRICE_INT"].ToString(), out m_decCallPrice);
                            decimal.TryParse(m_dtbOutStorageDetailRow["RETAILPRICE_INT"].ToString(), out m_decRetailPrice);
                            decimal.TryParse(m_dtbOutStorageDetailRow["WHOLESALEPRICE_INT"].ToString(), out m_decWholesalePrice);

                            m_dtbRow["MEDICINEID_CHR"] = m_dtbOutStorageDetailRow["MEDICINEID_CHR"];
                            m_dtbRow["ASSISTCODE_CHR"] = m_dtbOutStorageDetailRow["ASSISTCODE_CHR"];
                            m_dtbRow["MEDICINENAME_VCH"] = m_dtbOutStorageDetailRow["medicinename_vchr"];
                            m_dtbRow["MEDSPEC_VCHR"] = m_dtbOutStorageDetailRow["MEDSPEC_VCHR"];
                            m_dtbRow["LOTNO_VCHR"] = m_dtbOutStorageDetailRow["LOTNO_VCHR"];
                            m_dtbRow["AVAILAGROSS_INT"] = m_dtbOutStorageDetailRow["AVAILAGROSS_INT"];
                            m_dtbRow["NETAMOUNT_INT"] = m_dtbOutStorageDetailRow["NETAMOUNT_INT"];
                            m_dtbRow["CancelAmount"] = m_dtbOutStorageDetailRow["ReturnAmount"];
                            m_dtbRow["AvailAmount"] = m_dtbOutStorageDetailRow["AvailAmount"];//可退数量
                            m_dtbRow["AMOUNT"] = m_dtbOutStorageDetailRow["AMOUNT"];//退药数量

                            m_dtbRow["OPUNIT_CHR"] = m_dtbOutStorageDetailRow["OPUNIT_CHR"];
                            m_dtbRow["CALLPRICE_INT"] = m_dtbOutStorageDetailRow["CALLPRICE_INT"];
                            m_dtbRow["CallSum"] = m_decAvailAmount * m_decCallPrice;
                            m_dtbRow["RetailSum"] = m_decAvailAmount * m_decRetailPrice;
                            m_dtbRow["withdrawsum"] = Convert.ToDecimal(m_dtbOutStorageDetailRow["AMOUNT"].ToString()) * m_decCallPrice;
                            m_dtbRow["RETAILPRICE_INT"] = m_dtbOutStorageDetailRow["RETAILPRICE_INT"];

                            m_dtbRow["WHOLESALEPRICE_INT"] = m_dtbOutStorageDetailRow["WHOLESALEPRICE_INT"];
                            m_dtbRow["INSTORAGEID_VCHR"] = m_dtbOutStorageDetailRow["INSTORAGEID_VCHR"];
                            m_dtbRow["OUTSTORAGEID_VCHR"] = m_dtbOutStorageDetailRow["OUTSTORAGEID_VCHR"];
                            m_dtbRow["PRODUCTORID_CHR"] = m_dtbOutStorageDetailRow["productorid_chr"];
                            m_dtbRow["VALIDPERIOD_DAT"] = m_dtbOutStorageDetailRow["validperiod_dat"];//有效期

                            m_dtbRow["RUTURNNUM_INT"] = m_dtbOutStorageDetailRow["ReturnNum"];//内退次数
                            //m_dtbRow["PACKCONVERT_INT"] = m_dtbOutStorageDetail.Rows[i1][""];
                            //m_dtbRow["PACKAMOUNT"] = m_dtbOutStorageDetail.Rows[i1][""];
                            //m_dtbRow["PACKUNIT_VCHR"] = m_dtbOutStorageDetail.Rows[i1][""];
                            //m_dtbRow["PACKCALLPRICE_INT"] = m_dtbOutStorageDetail.Rows[i1][""];
                            if (blnNewRow)
                            {
                                m_objViewerMakerBill.m_dtbDetail.Rows.Add(m_dtbRow);
                                m_objViewerMakerBill.m_dgvMedicineDetail.CurrentCell =
                                    m_objViewerMakerBill.m_dgvMedicineDetail[m_objViewerMakerBill.m_intAmountColIndex, m_objViewerMakerBill.m_dtbDetail.Rows.Count - 1];
                            }
                        }

                    }//if

                }//for


            }


        }

        #endregion


        #endregion
    }
}
