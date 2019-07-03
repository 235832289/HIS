using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.gui.MedicineStore
{
    #region 药品内退调出库单控制类
    /// <summary>
    /// 药品内退调出库单控制类
    /// </summary>
    class clsCtl_MedicWithdrawCallOutStorage : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数

        public clsCtl_MedicWithdrawCallOutStorage()
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
        private com.digitalwave.iCare.gui.MedicineStore.frmCallOutStorageBill m_objViewer;

        #endregion 字段

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);

            m_objViewer = (frmCallOutStorageBill)frmMDI_Child_Base_in;
        }



        #endregion

        #region 获取药品出库主表数据
        /// <summary>
        /// 获取药品出库主表数据
        /// </summary>
        /// <param name="objvalue_Param">查询条件</param>
        /// <param name="dtbResult">结果集</param>
        /// <returns></returns>
        public long m_mthGetOutStorageMainData(ref clsMs_MedicineWithdrawOutStorageQueryCondition_VO objvalue_Param, out DataTable dtbResult)
        {
            long lngRes = 0;
            try
            {
                //调用Com+服务端

                DataTable Query_dtbResult = new DataTable();//数据库返回的结果集

                lngRes = m_objDomain.m_lngGetOutStorageMainData(ref objvalue_Param, ref Query_dtbResult);
                if (lngRes > 0)
                {
                    DataColumn[] drColumns = new DataColumn[] { new DataColumn("SortNum") };
                    Query_dtbResult.Columns.AddRange(drColumns);
                    DataRow m_dtbResultRow = null;
                    for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
                    {
                        m_dtbResultRow = Query_dtbResult.Rows[i1];
                        m_dtbResultRow["SortNum"] = i1 + 1;
                    }
                    Query_dtbResult.AcceptChanges();

                    dtbResult = Query_dtbResult;
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

        #region 获取药品出库明细数据

        /// <summary>
        /// 获取药品出库明细数据
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long m_mthGetOutStorageDetailData(ref clsMs_OutStorageDetailQueryCondition_VO objvalue_Param, ref DataTable m_dtbMedicineCancelDetail, out DataTable dtbResult)
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

                lngRes = m_objDomain.m_lngGetOutStorageDetailData(ref objvalue_Param, ref Query_dtbResult);
                if (lngRes > 0)
                {
                    DataColumn[] drColumns = new DataColumn[] {
                        new DataColumn("SortNum",typeof(int)), 
                        new DataColumn("ReturnAmount",typeof(decimal)), 
                        new DataColumn("AvailAmount",typeof(decimal)) ,
                        new DataColumn("Amount",typeof(decimal)) ,
                        new DataColumn("AVAILAGROSS_INT",typeof(decimal)) ,
                        //new DataColumn("validperiod_dat",typeof(DateTime)) ,
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

                        //已退药数量


                        //m_objDomain.m_lngGetMedicineWithdrawSum(ref m_objMedicineWithdrawNumCondition, out  m_decMedicineWithdrawSum);
                        //m_dtbResultRow["ReturnAmount"] = m_decMedicineWithdrawSum;

                        //出库数量
                        decimal.TryParse(m_dtbResultRow["NETAMOUNT_INT"].ToString(), out m_decNetAmount);

                        //已退数量
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

                    dtbResult = Query_dtbResult;
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

        #region 查询出库明细时获取退药次数和退药数量

        private void m_mthGetInnerWithdrawNum(clsMs_MedicineWithdrawNumQueryCondition_VO p_objValueParam, ref DataTable Query_dtbResult)
        {
            DataTable m_dtbResult = new DataTable();

            decimal m_decNetAmount = 0;//出库数量
            decimal m_decAvailAmount = 0;//可退数量
            string m_strOutStorageID = string.Empty;            
            decimal m_decReturnNum = 0;
            decimal m_decReturnAmount = 0;
            decimal m_decTmpReturnAmount = 0;
            string m_strMedicineID = string.Empty;
            string m_strLotNo = string.Empty;
            DataRow m_dtbQueryRow = null;
            DataRow m_dtbResultRow = null;

            m_objDomain.m_lngGetMedicineWithdrawSum(ref p_objValueParam, ref  m_dtbResult);

            for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
            {
                m_dtbQueryRow = Query_dtbResult.Rows[i1];
                m_strMedicineID = m_dtbQueryRow["MEDICINEID_CHR"].ToString();
                m_strLotNo = m_dtbQueryRow["LOTNO_VCHR"].ToString();
                m_strOutStorageID = m_dtbQueryRow["outstorageid_vchr"].ToString();
                decimal.TryParse(m_dtbQueryRow["NETAMOUNT_INT"].ToString(), out m_decNetAmount);

                m_decReturnNum = 0;
                m_decReturnAmount = 0;
                for (int j1 = 0; j1 < m_dtbResult.Rows.Count; j1++)
                {
                    m_dtbResultRow = m_dtbResult.Rows[j1];
                    if ((m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim() == m_strMedicineID)
                        && (m_dtbResultRow["LOTNO_VCHR"].ToString().Trim() == m_strLotNo)
                        && (m_dtbResultRow["outstorageid_vchr"].ToString().Trim() == m_strOutStorageID))
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

    }

    #endregion 药品内退调出库单控制类
}
