using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text;
using com.digitalwave.iCare.middletier.MedicineStoreService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.MedicineStore;


namespace com.digitalwave.iCare.gui.MedicineStore
{
    #region 药品明细查询/业务逻辑层  王勇  2007-4-2
    /// <summary>
    /// 库存明细查询中间件访问类
    /// </summary>
    class clsDcl_StorageDetailQuery : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsDomainController_StorageDetailQuery objDomain = null;

        #region 构造函数

        /// <summary>
        /// 构造函数

        /// </summary>
        public clsDcl_StorageDetailQuery()
        {

        }
        #endregion


        #region 获取库存明细数据
        /// <summary>
        /// 获取库存明细数据
        /// </summary>
        /// <param name="objvalue_Param">查询条件</param>
        /// <param name="dtbResult">返回的结果集</param>
        /// <param name="m_objStatValue">统计数据</param>
        /// <param name="blnQueryFlag">查询标志</param>
        /// <returns></returns>
        public long m_mthGetStorageDetailData(ref clsStorageDetail_SqlConditionQueryParam_VO objvalue_Param, bool p_blnAccount,out DataTable dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue, List<string> lstMedicineType, bool blnQueryFlag)
        {
            long lngRes = 0;
            try
            {
                //调用Com+服务端


                m_objStatValue.m_decCallSumTotal = 0;
                m_objStatValue.m_decRetailSumTotal = 0;
                m_objStatValue.m_decWholesaleSumTotal = 0;

                DataTable Query_dtbResult = new DataTable();//数据库返回的结果集

                clsDomainController_StorageDetailQuery objDomain = new clsDomainController_StorageDetailQuery();

                lngRes = objDomain.m_lngGetResultByConditionStorageDetail(ref objvalue_Param, p_blnAccount,lstMedicineType, ref Query_dtbResult);

                if (lngRes > 0)
                {
                    DataTable Stat_dtbResult = new DataTable();//处理后生成的统计表



                    //统计查询
                    if (blnQueryFlag == true)
                    {
                        m_GroupSum(objvalue_Param.m_strStorageName, ref Query_dtbResult, ref Stat_dtbResult, ref m_objStatValue);
                        dtbResult = Stat_dtbResult;
                        Query_dtbResult = null;
                    }
                    else//明细查询
                    {
                        m_DetailQuery(objvalue_Param.m_strStorageName, ref Query_dtbResult, ref m_objStatValue);
                        dtbResult = Query_dtbResult;
                    }
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


        #region 明细查询函数
        /// <summary>
        /// 明细查询函数
        /// </summary>
        /// <param name="dtbResult">初始的结果集</param>
        /// <param name="tmp_dtbResult">处理后的统计表</param>
        private void m_DetailQuery(string strMedicineStorageName, ref DataTable Query_dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue)
        {
            DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("callsum", typeof(double)), new DataColumn("retailsum", typeof(double)), new DataColumn("wholesalesum", typeof(double)) };
            Query_dtbResult.Columns.AddRange(drColumns);

            decimal m_decDBRealGross = 0;//结果集记录中的实际库存

            decimal m_decCallPrice = 0;//结果中的购入单价
            decimal m_decRetailPrice = 0;//结果中的零售单价
            decimal m_decWholesalePrice = 0;//结果中的批发单价

            decimal m_decCallSum = 0;//统计表中的购入金额

            decimal m_decRetailSum = 0;//统计表中的零售金额

            decimal m_decWholesaleSum = 0;//统计表中的批发金额

            decimal m_decEndamount = 0;



            DataRow m_dtbResultRow = null;

            m_objStatValue.m_decCallSumTotal = 0;
            m_objStatValue.m_decRetailSumTotal = 0;
            m_objStatValue.m_decWholesaleSumTotal = 0;

            for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
            {
                m_dtbResultRow = Query_dtbResult.Rows[i1];

                decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decDBRealGross);

                decimal.TryParse(m_dtbResultRow["callprice_int"].ToString(), out m_decCallPrice);
                decimal.TryParse(m_dtbResultRow["retailprice_int"].ToString(), out m_decRetailPrice);
                decimal.TryParse(m_dtbResultRow["wholesaleprice_int"].ToString(), out m_decWholesalePrice);
                decimal.TryParse(m_dtbResultRow["endamount_int"].ToString(), out m_decEndamount);

                m_decCallSum = m_decDBRealGross * m_decCallPrice;
                m_decRetailSum = m_decDBRealGross * m_decRetailPrice;
                m_decWholesaleSum = m_decDBRealGross * m_decWholesalePrice;
                //m_decEndamount += m_decEndamount;
                m_dtbResultRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                m_dtbResultRow["callsum"] = m_decCallSum;
                m_dtbResultRow["retailsum"] = m_decRetailSum;
                m_dtbResultRow["wholesalesum"] = m_decWholesaleSum;
                m_dtbResultRow["endamount_int"] = m_decEndamount;

                m_objStatValue.m_decCallSumTotal += m_decCallSum;
                m_objStatValue.m_decRetailSumTotal += m_decRetailSum;
                m_objStatValue.m_decWholesaleSumTotal += m_decWholesaleSum;
            }


        }
        #endregion


        #region 分组统计函数
        /// <summary>
        /// 分组统计数据
        /// 根据药品ID（MEDICINEID_CHR）进行分组统计，药品ID相同的记录归为一组。

        /// 对每组的“实际库存”、“可用库存”、“购入金额”、“零售金额”、“批发金额”进行求和计算。

        /// 将每组的统计数据写入最终的统计表。统计表中“购入单价”、“零售单价”、“批发单价”采用平均价格。

        /// </summary>
        /// <param name="dtbResult">初始的结果集</param>
        /// <param name="tmp_dtbResult">处理后的统计表</param>
        private void m_GroupSum(string strMedicineStorageName, ref DataTable dtbResult, ref DataTable tmp_dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue)
        {
            DataRow m_newRow = null, m_dtbResultRow = null;

            int i1;
            string m_strMedicineID = string.Empty;//用于分组的药品ID
            string m_strDBMedicineID = string.Empty;//结果集中被筛选的药品ID
            decimal m_decRealGrossSum = 0;//每组的实际库存合计

            decimal m_decAvailGrossSum = 0;//每组的可用库存合计


            decimal m_decDBRealGross = 0;//结果集记录中的实际库存

            decimal m_decDBAvailGross = 0;//结果集记录中的可用库存
            decimal m_decEndamount = 0;

            decimal m_decCallSum = 0;//统计表中的购入金额

            decimal m_decRetailSum = 0;//统计表中的零售金额

            decimal m_decWholesaleSum = 0;//统计表中的批发金额


            decimal m_decCallPrice = 0;//统计表中的购入平均单价

            decimal m_decRetailPrice = 0;//统计表中的零售平均单价

            decimal m_decWholesalePrice = 0;//统计表中的批发平均单价


            m_objStatValue.m_decCallSumTotal = 0;
            m_objStatValue.m_decRetailSumTotal = 0;
            m_objStatValue.m_decWholesaleSumTotal = 0;

            if (dtbResult.Rows.Count == 1)
            {
                tmp_dtbResult = dtbResult.Copy();

                DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("callsum", typeof(double)), new DataColumn("retailsum", typeof(double)), new DataColumn("wholesalesum", typeof(double)) };
                tmp_dtbResult.Columns.AddRange(drColumns);

                m_dtbResultRow = tmp_dtbResult.Rows[0];

                decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decDBRealGross);
                decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                decimal.TryParse(m_dtbResultRow["endamount_int"].ToString(), out m_decEndamount);

                decimal.TryParse(m_dtbResultRow["callprice_int"].ToString(), out m_decCallPrice);
                decimal.TryParse(m_dtbResultRow["retailprice_int"].ToString(), out m_decRetailPrice);
                decimal.TryParse(m_dtbResultRow["wholesaleprice_int"].ToString(), out m_decWholesalePrice);



                m_decCallSum = m_decDBRealGross * m_decCallPrice;
                m_decRetailSum = m_decDBRealGross * m_decRetailPrice;
                m_decWholesaleSum = m_decDBRealGross * m_decWholesalePrice;


                m_dtbResultRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                m_dtbResultRow["callsum"] = m_decCallSum;
                m_dtbResultRow["retailsum"] = m_decRetailSum;
                m_dtbResultRow["wholesalesum"] = m_decWholesaleSum;
                m_dtbResultRow["endamount_int"] = m_decEndamount;

                m_objStatValue.m_decCallSumTotal += m_decCallSum;
                m_objStatValue.m_decRetailSumTotal += m_decRetailSum;
                m_objStatValue.m_decWholesaleSumTotal += m_decWholesaleSum;


            }
            else if (dtbResult.Rows.Count > 1)
            {
                tmp_dtbResult = dtbResult.Clone();

                DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("callsum", typeof(double)), new DataColumn("retailsum", typeof(double)), new DataColumn("wholesalesum", typeof(double)) };
                tmp_dtbResult.Columns.AddRange(drColumns);

                m_dtbResultRow = dtbResult.Rows[0];

                m_strMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim();

                decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decDBRealGross);
                decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                decimal.TryParse(m_dtbResultRow["endamount_int"].ToString(), out m_decEndamount);

                m_decRealGrossSum = m_decDBRealGross;
                m_decAvailGrossSum = m_decDBAvailGross;

                decimal.TryParse(m_dtbResultRow["callprice_int"].ToString(), out m_decCallPrice);
                decimal.TryParse(m_dtbResultRow["retailprice_int"].ToString(), out m_decRetailPrice);
                decimal.TryParse(m_dtbResultRow["wholesaleprice_int"].ToString(), out m_decWholesalePrice);


                m_decCallSum = m_decDBRealGross * m_decCallPrice;
                m_decRetailSum = m_decDBRealGross * m_decRetailPrice;
                m_decWholesaleSum = m_decDBRealGross * m_decWholesalePrice;

                m_objStatValue.m_decCallSumTotal += m_decCallSum;
                m_objStatValue.m_decRetailSumTotal += m_decRetailSum;
                m_objStatValue.m_decWholesaleSumTotal += m_decWholesaleSum;

                decimal dcmEndAmountTemp = 0m;
                for (i1 = 1; i1 < dtbResult.Rows.Count; i1++)
                {//汇总

                    m_dtbResultRow = dtbResult.Rows[i1];

                    //小计
                    m_strDBMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim();

                    decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decDBRealGross);
                    decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                    decimal.TryParse(m_dtbResultRow["endamount_int"].ToString(), out dcmEndAmountTemp);

                    decimal.TryParse(m_dtbResultRow["callprice_int"].ToString(), out m_decCallPrice);
                    decimal.TryParse(m_dtbResultRow["retailprice_int"].ToString(), out m_decRetailPrice);
                    decimal.TryParse(m_dtbResultRow["wholesaleprice_int"].ToString(), out m_decWholesalePrice);
                    //decimal.TryParse(m_dtbResultRow["endamount_int"].ToString(), out m_decEndamount);

                    //计算最终的合计金额
                    m_objStatValue.m_decCallSumTotal += m_decDBRealGross * m_decCallPrice;
                    m_objStatValue.m_decRetailSumTotal += m_decDBRealGross * m_decRetailPrice;
                    m_objStatValue.m_decWholesaleSumTotal += m_decDBRealGross * m_decWholesalePrice;


                    if (m_strMedicineID == m_strDBMedicineID)
                    {
                        m_decRealGrossSum += m_decDBRealGross;
                        m_decAvailGrossSum += m_decDBAvailGross;

                        m_decCallSum += m_decDBRealGross * m_decCallPrice;
                        m_decRetailSum += m_decDBRealGross * m_decRetailPrice;
                        m_decWholesaleSum += m_decDBRealGross * m_decWholesalePrice;
                        
                        m_decEndamount += dcmEndAmountTemp;

                    }//小计
                    else
                    {
                        m_dtbResultRow = dtbResult.Rows[i1 - 1];



                        m_newRow = tmp_dtbResult.NewRow();

                        m_newRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                        m_newRow["ASSISTCODE_CHR"] = m_dtbResultRow["ASSISTCODE_CHR"];//助记码

                        m_newRow["MEDICINENAME_VCHR"] = m_dtbResultRow["MEDICINENAME_VCHR"];//药品名称
                        m_newRow["MEDSPEC_VCHR"] = m_dtbResultRow["MEDSPEC_VCHR"];//规格
                        m_newRow["LOTNO_VCHR"] = m_dtbResultRow["LOTNO_VCHR"];//批号
                        m_newRow["storagerackid_chr"] = m_dtbResultRow["storagerackid_chr"];//货架
                        m_newRow["canprovide"] = m_dtbResultRow["canprovide"];//可供标志
                        m_newRow["MEDICINETYPENAME_VCHR"] = m_dtbResultRow["MEDICINETYPENAME_VCHR"];//药品类型名称
                        m_newRow["REALGROSS_INT"] = m_decRealGrossSum;//实际库存
                        m_newRow["AVAILAGROSS_INT"] = m_decAvailGrossSum;//可用库存
                        m_newRow["endamount_int"] = m_decEndamount;//上期结存
                        m_newRow["OPUNIT_VCHR"] = m_dtbResultRow["OPUNIT_VCHR"];//单位

                        

                        if (m_decRealGrossSum == 0)
                            m_newRow["CALLPRICE_INT"] = 0;//购入单价
                        else
                            m_newRow["CALLPRICE_INT"] = m_decCallSum / m_decRealGrossSum;//购入单价

                        if (m_decRealGrossSum == 0)
                            m_newRow["RETAILPRICE_INT"] = 0;//零售单价
                        else
                            m_newRow["RETAILPRICE_INT"] = m_decRetailSum / m_decRealGrossSum;//零售单价

                        if (m_decRealGrossSum == 0)
                            m_newRow["WHOLESALEPRICE_INT"] = 0;//批发单价
                        else
                            m_newRow["WHOLESALEPRICE_INT"] = m_decWholesaleSum / m_decRealGrossSum;//批发单价


                        m_newRow["CALLSUM"] = m_decCallSum;//购入金额
                        m_newRow["RETAILSUM"] = m_decRetailSum;//零售金额
                        m_newRow["WHOLESALESUM"] = m_decWholesaleSum;//批发金额

                        m_newRow["VALIDPERIOD_DAT"] = m_dtbResultRow["VALIDPERIOD_DAT"];//失效日期
                        m_newRow["MEDICINEPREPTYPENAME_VCHR"] = m_dtbResultRow["MEDICINEPREPTYPENAME_VCHR"];//药品剂型

                        //增加新行
                        tmp_dtbResult.Rows.Add(m_newRow);
                        m_newRow.AcceptChanges();

                        m_dtbResultRow = dtbResult.Rows[i1];

                        m_strMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString();

                        //重置m_decRealGrossSum、m_decAvailGrossSum、

                        m_decRealGrossSum = m_decDBRealGross;
                        m_decAvailGrossSum = m_decDBAvailGross;

                        m_decCallSum = m_decDBRealGross * m_decCallPrice;
                        m_decRetailSum = m_decDBRealGross * m_decRetailPrice;
                        m_decWholesaleSum = m_decDBRealGross * m_decWholesalePrice;

                        m_decEndamount = dcmEndAmountTemp;

                    }//else

                    //处理最后一条记录



                    if (i1 == dtbResult.Rows.Count - 1)
                    {
                        m_dtbResultRow = dtbResult.Rows[i1];


                        m_newRow = tmp_dtbResult.NewRow();

                        m_newRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                        m_newRow["ASSISTCODE_CHR"] = m_dtbResultRow["ASSISTCODE_CHR"];//助记码


                        m_newRow["MEDICINENAME_VCHR"] = m_dtbResultRow["MEDICINENAME_VCHR"];//药品名称
                        m_newRow["MEDSPEC_VCHR"] = m_dtbResultRow["MEDSPEC_VCHR"];//规格
                        m_newRow["LOTNO_VCHR"] = m_dtbResultRow["LOTNO_VCHR"];//批号
                        m_newRow["storagerackid_chr"] = m_dtbResultRow["storagerackid_chr"];//货架
                        m_newRow["canprovide"] = m_dtbResultRow["canprovide"];//可供标志
                        m_newRow["MEDICINETYPENAME_VCHR"] = m_dtbResultRow["MEDICINETYPENAME_VCHR"];//药品类型名称
                        m_newRow["REALGROSS_INT"] = m_decRealGrossSum;//实际库存
                        m_newRow["AVAILAGROSS_INT"] = m_decAvailGrossSum;//可用库存
                        m_newRow["endamount_int"] = m_decEndamount;//上期结存
                        m_newRow["OPUNIT_VCHR"] = m_dtbResultRow["OPUNIT_VCHR"];//单位
                        
                        if (m_decRealGrossSum == 0)
                            m_newRow["CALLPRICE_INT"] = 0;//购入单价
                        else
                            m_newRow["CALLPRICE_INT"] = m_decCallSum / m_decRealGrossSum;//购入单价

                        if (m_decRealGrossSum == 0)
                            m_newRow["RETAILPRICE_INT"] = 0;//零售单价
                        else
                            m_newRow["RETAILPRICE_INT"] = m_decRetailSum / m_decRealGrossSum;//零售单价

                        if (m_decRealGrossSum == 0)
                            m_newRow["WHOLESALEPRICE_INT"] = 0;//批发单价
                        else
                            m_newRow["WHOLESALEPRICE_INT"] = m_decWholesaleSum / m_decRealGrossSum;//批发单价


                        m_newRow["CALLSUM"] = m_decCallSum;//购入金额
                        m_newRow["RETAILSUM"] = m_decRetailSum;//零售金额
                        m_newRow["WHOLESALESUM"] = m_decWholesaleSum;//批发金额

                        m_newRow["VALIDPERIOD_DAT"] = m_dtbResultRow["VALIDPERIOD_DAT"];//失效日期
                        m_newRow["MEDICINEPREPTYPENAME_VCHR"] = m_dtbResultRow["MEDICINEPREPTYPENAME_VCHR"];//药品剂型

                        //增加新行
                        tmp_dtbResult.Rows.Add(m_newRow);
                        m_newRow.AcceptChanges();
                    }


                }//for

            }

        }
        #endregion

    }
    #endregion
}
