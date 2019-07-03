using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility.SQLConvert;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药品出入库明细查询
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsQueryMedicineDetailSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药品出入库明细
        /// <summary>
        /// 获取药品出入库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">开始日期</param>
        /// <param name="p_dtmEnd">结束日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_dtbMedicineDetail"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetQueryMedicineDetail(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin,
            DateTime p_dtmEnd, string p_strStorageID, string p_strMedicine, out DataTable p_dtbMedicineDetail, out clsMS_QueryMedicineDetailVO clsQuerVO)
        {
            clsQuerVO = new clsMS_QueryMedicineDetailVO();
            p_dtbMedicineDetail = new DataTable();
            p_dtbMedicineDetail.Columns.Add("operatedate_dat", typeof(System.DateTime));
            p_dtbMedicineDetail.Columns.Add("chittyid_vchr", typeof(System.String));
            p_dtbMedicineDetail.Columns.Add("lotno_vchr", typeof(System.String));
            p_dtbMedicineDetail.Columns.Add("brief_vchr", typeof(System.String));
            p_dtbMedicineDetail.Columns.Add("inRetailprice_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("inAmount_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("outRetailprice_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("outAmount_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("balance", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("oldgross_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("medicinename_vch", typeof(System.String));
            DataTable dtb = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.medicinename_vch,
       t.lotno_vchr,
       t.retailprice_int,
       t.amount_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.operatedate_dat,
       t.instorageid_vchr,
       t.endamount_int,
       t.isend_int,
       b.oldretailprice_int,
       b.newretailprice_int,
       e.deptname_vchr,
       f.vendorname_vchr
   from t_ms_account_detail t
  left join t_ms_adjustprice a on t.chittyid_vchr = a.adjustpriceid_vchr
  left join t_ms_adjustprice_detail b on a.seriesid_int = b.seriesid2_int
  left join t_bse_deptdesc e on t.deptid_chr = e.deptid_chr
  left join t_bse_vendor f on t.deptid_chr = f.vendorid_chr
 where t.storageid_chr= ?
   and t.medicineid_chr = ?
   and t.operatedate_dat between ? and ?
   and (t.state_int = 1 or t.state_int =2)
   order by t.operatedate_dat,t.instorageid_vchr";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicine;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmBegin;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_dtmEnd;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtb, objDPArr);
                if (lngRes > 0 && dtb.Rows.Count > 0)
                {
                    int p_intSet;
                    m_lngGetSysSetting(null, "5018", out p_intSet);
                    DataRow drCurrent = null;

                    double douAmount = 0;
                    double douOldgross = 0;

                    for (int iRow = 0; iRow < dtb.Rows.Count; iRow++)
                    {
                        drCurrent = dtb.Rows[iRow];

                        if (drCurrent["amount_int"] == DBNull.Value) drCurrent["amount_int"] = 0;
                        if (drCurrent["retailprice_int"] == DBNull.Value) drCurrent["retailprice_int"] = 0;
                        if (drCurrent["oldgross_int"] == DBNull.Value) drCurrent["oldgross_int"] = 0;
                        if (drCurrent["retailprice_int"] == DBNull.Value) drCurrent["retailprice_int"] = 0;
                        if (drCurrent["oldretailprice_int"] == DBNull.Value) drCurrent["oldretailprice_int"] = 0;
                        if (drCurrent["newretailprice_int"] == DBNull.Value) drCurrent["newretailprice_int"] = 0;

                        DataRow drMedicine = p_dtbMedicineDetail.NewRow();
                        drMedicine[0] = drCurrent["operatedate_dat"];
                        drMedicine[1] = drCurrent["chittyid_vchr"];
                        if (drCurrent["lotno_vchr"].ToString() == "UNKNOWN")
                        {
                            drMedicine[2] = "";
                        }
                        else
                        {
                            drMedicine[2] = drCurrent["lotno_vchr"];
                        }
                        int intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                        int intInOutType = 1;//1:入库 2:出库
                        if (Convert.ToInt16(drCurrent["isend_int"]) == 1) intProcessType = 7;
                        //单据号(第九位数字分别表示:1,入库2,出库3,外退4,内退5,损耗6,盘点7期初数,8调价)

                        switch (intProcessType)
                        {
                            case 1:

                                drMedicine[3] = "入库(" + drCurrent["vendorname_vchr"].ToString() + ")";
                                drMedicine[4] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                drMedicine[5] = Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[9] = Convert.ToDouble(drCurrent["oldgross_int"]) + Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblInAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                intInOutType = 1;
                                break;
                            case 2:
                                drMedicine[3] = "出库(" + drCurrent["deptname_vchr"].ToString() + ")";
                                drMedicine[6] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[9] = Convert.ToDouble(drCurrent["oldgross_int"]) - Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblOutAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                intInOutType = 2;
                                break;
                            case 3:
                                drMedicine[3] = "外退(" + drCurrent["vendorname_vchr"].ToString() + ")";
                                drMedicine[6] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[9] = Convert.ToDouble(drCurrent["oldgross_int"]) - Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblOutStorageAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                intInOutType = 2;
                                break;
                            case 4:
                                drMedicine[3] = "内退(" + drCurrent["deptname_vchr"].ToString() + ")";
                                drMedicine[4] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                drMedicine[5] = Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[9] = Convert.ToDouble(drCurrent["oldgross_int"]) + Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblInStorageAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                intInOutType = 1;
                                break;
                            case 5:
                                drMedicine[3] = "损耗(" + drCurrent["vendorname_vchr"].ToString() + ")";
                                drMedicine[6] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[9] = Convert.ToDouble(drCurrent["oldgross_int"]) - Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblRejectAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                intInOutType = 2;
                                break;

                            case 6:
                                drMedicine[3] = "盘点";
                                if (Convert.ToDouble(drCurrent["amount_int"]) > 0)
                                {
                                    drMedicine[4] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                    drMedicine[5] = Convert.ToDouble(drCurrent["amount_int"]);
                                    drMedicine[9] = Convert.ToDouble(drCurrent["oldgross_int"]) + Convert.ToDouble(drCurrent["amount_int"]);
                                    intInOutType = 1;

                                }
                                else
                                {
                                    drMedicine[6] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                    drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                    drMedicine[9] = Convert.ToDouble(drCurrent["oldgross_int"]) - Convert.ToDouble(drCurrent["amount_int"]);
                                    intInOutType = 2;
                                }
                                clsQuerVO.m_dblCheckAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                break;

                            case 7:
                                if (Convert.ToInt16(drCurrent["isend_int"]) == 1)
                                {
                                    drMedicine[3] = "结存";
                                }
                                else
                                {
                                    drMedicine[3] = "期初";
                                }
                                drMedicine[9] = Convert.ToDouble(drCurrent["endamount_int"]);
                                intInOutType = 1;
                                clsQuerVO.m_dblBeginAmount += Convert.ToDouble(drCurrent["endamount_int"]);
                                break;

                            case 8:
                                drMedicine[3] = "调价";
                                if ((Convert.ToDouble(drCurrent["newretailprice_int"]) - Convert.ToDouble(drCurrent["oldretailprice_int"])) > 0)
                                {
                                    drMedicine[4] = Convert.ToDouble(drCurrent["newretailprice_int"]) - Convert.ToDouble(drCurrent["oldretailprice_int"]);
                                    drMedicine[5] = Convert.ToDouble(drCurrent["amount_int"]);
                                    intInOutType = 1;
                                }
                                else
                                {
                                    drMedicine[6] = Convert.ToDouble(drCurrent["oldretailprice_int"]) - Convert.ToDouble(drCurrent["newretailprice_int"]);
                                    drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                    intInOutType = 2;
                                }
                                drMedicine[9] = Convert.ToDouble(drCurrent["oldgross_int"]);
                                clsQuerVO.m_dblRetailPriceAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                break;
                        }
                        if (p_intSet == 0)//余额零价取值 0 取当前零价,1 加权平均(未完成)
                        {
                            drMedicine[8] = Convert.ToDouble(drCurrent["retailprice_int"]);
                        }
                        else
                        {
                            drMedicine[8] = Convert.ToDouble(drCurrent["retailprice_int"]);
                        }
                        drMedicine[10] = drCurrent["medicinename_vch"];
                        // p_dtbMedicineDetail.Rows.Add(drMedicine);
                        if ((iRow + 1 >= dtb.Rows.Count) || ((dtb.Rows[iRow]["chittyid_vchr"].ToString() != dtb.Rows[iRow + 1]["chittyid_vchr"].ToString())))
                        {
                            if (douAmount == 0)
                            {
                                if (intInOutType == 1)
                                {
                                    if (drMedicine[5] != DBNull.Value)
                                        douAmount = Convert.ToDouble(drMedicine[5]);
                                }
                                else
                                {
                                    if (drMedicine[7] != DBNull.Value)
                                        douAmount = Convert.ToDouble(drMedicine[7]);
                                }
                            }
                            if (intInOutType == 1)
                            {

                                if (drMedicine[4] != DBNull.Value)
                                    drMedicine[5] = douAmount + Convert.ToDouble(drMedicine[4]);
                            }
                            else
                            {
                                drMedicine[7] = douAmount + Convert.ToDouble(drMedicine[7]);
                            }
                            p_dtbMedicineDetail.Rows.Add(drMedicine);
                            douAmount = 0;
                        }
                        else
                        {
                            if (intInOutType == 1)
                            {
                                if (drMedicine[5] != DBNull.Value)
                                    douAmount += Convert.ToDouble(drMedicine[5]);
                            }
                            else
                            {
                                if (drMedicine[7] != DBNull.Value)
                                    douAmount += Convert.ToDouble(drMedicine[7]);
                            }
                        }

                    }//for
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取药品出入库明细(不分批号)
        /// <summary>
        /// 获取药品出入库明细(不分批号)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">开始日期</param>
        /// <param name="p_dtmEnd">结束日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_dtbMedicineDetail"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetQueryMedicineDetail_NoLotno(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd,
            string p_strStorageID, string p_strMedicine, out DataTable p_dtbMedicineDetail, out clsMS_QueryMedicineDetailVO clsQuerVO)
        {
            clsQuerVO = new clsMS_QueryMedicineDetailVO();
            p_dtbMedicineDetail = new DataTable();
            p_dtbMedicineDetail.Columns.Add("operatedate_dat", typeof(System.DateTime));
            p_dtbMedicineDetail.Columns.Add("chittyid_vchr", typeof(System.String));
            p_dtbMedicineDetail.Columns.Add("lotno_vchr", typeof(System.String));
            p_dtbMedicineDetail.Columns.Add("brief_vchr", typeof(System.String));
            p_dtbMedicineDetail.Columns.Add("inRetailprice_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("inAmount_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("outRetailprice_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("outAmount_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("balance", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("oldgross_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("medicinename_vch", typeof(System.String));

            p_dtbMedicineDetail.Columns.Add("callprice_int", typeof(System.Double));
            p_dtbMedicineDetail.Columns.Add("validperiod_chr", typeof(System.String));
            //p_dtbMedicineDetail.Columns.Add("productorid_chr", typeof(System.String));
            p_dtbMedicineDetail.Columns.Add("oldmoney", typeof(System.Double));//结存零售金额

            DataTable dtb = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.medicinename_vch,
			 t.lotno_vchr,
			 t.retailprice_int,
			 t.amount_int,
			 t.oldgross_int,
			 t.chittyid_vchr,
			 t.operatedate_dat,
			 t.instorageid_vchr,
			 t.endamount_int,
			 t.isend_int,
			 b.oldretailprice_int,
			 b.newretailprice_int,
			 e.deptname_vchr,
			 f.vendorname_vchr,
			 t.callprice_int,
			 t.validperiod_dat validperiod_chr
	from t_ms_account_detail t
	left join t_ms_adjustprice a on t.chittyid_vchr = a.adjustpriceid_vchr
	left join t_ms_adjustprice_detail b on a.seriesid_int = b.seriesid2_int
	left join t_bse_deptdesc e on t.deptid_chr = e.deptid_chr
	left join t_bse_vendor f on t.deptid_chr = f.vendorid_chr
 where t.storageid_chr = ?
	 and t.medicineid_chr = ?
	 and t.operatedate_dat between ?
	 and ?
	 and (t.state_int = 1 or t.state_int = 2)
 order by t.operatedate_dat, t.instorageid_vchr";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicine;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmBegin;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_dtmEnd;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtb, objDPArr);
                if (lngRes > 0 && dtb.Rows.Count > 0)
                {
                    int p_intSet;
                    m_lngGetSysSetting(null, "5018", out p_intSet);
                    DataRow drCurrent = null;

                    double douAmount = 0;
                    double douOldgross = 0;

                    //查出在开始时间前的最后一次结存数
                    double dblEndGross;
                    double p_intAmount;
                    string p_datOperatedate;
                    double p_dblOldMoney = 0d;
                    m_lngGetEndGross(null, p_strStorageID, p_dtmBegin, p_strMedicine, out dblEndGross, out p_intAmount, out p_datOperatedate, out p_dblOldMoney);
                    clsQuerVO.m_dblOldGross = dblEndGross;
                    DataRow drMedicineH = p_dtbMedicineDetail.NewRow();

                    if (p_datOperatedate == "") p_datOperatedate = p_dtmBegin.ToString();

                    drMedicineH[0] = p_datOperatedate;
                    drMedicineH[8] = dtb.Rows[0]["retailprice_int"].ToString();
                    drMedicineH[9] = dblEndGross;
                    drMedicineH[10] = dtb.Rows[dtb.Rows.Count - 1]["medicinename_vch"].ToString();
                    drMedicineH[13] = p_dblOldMoney;
                    p_dtbMedicineDetail.Rows.Add(drMedicineH);
                    double dblInAmount = 0;
                    double dblOutAmount = 0;
                    double dblJcGross = 0;
                    for (int iRow = 0; iRow < dtb.Rows.Count; iRow++)
                    {
                        drCurrent = dtb.Rows[iRow];

                        ////20090318:调价的过滤掉，不要显示
                        int intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                        //if (intProcessType == 8)
                        //{
                        //    continue;
                        //}


                        if (drCurrent["amount_int"] == DBNull.Value) drCurrent["amount_int"] = 0;
                        if (drCurrent["retailprice_int"] == DBNull.Value) drCurrent["retailprice_int"] = 0;
                        if (drCurrent["oldgross_int"] == DBNull.Value) drCurrent["oldgross_int"] = 0;
                        if (drCurrent["retailprice_int"] == DBNull.Value) drCurrent["retailprice_int"] = 0;
                        if (drCurrent["oldretailprice_int"] == DBNull.Value) drCurrent["oldretailprice_int"] = 0;
                        if (drCurrent["newretailprice_int"] == DBNull.Value) drCurrent["newretailprice_int"] = 0;
                        if (drCurrent["callprice_int"] == DBNull.Value) drCurrent["callprice_int"] = 0;


                        DataRow drMedicine = p_dtbMedicineDetail.NewRow();
                        drMedicine[0] = drCurrent["operatedate_dat"];
                        drMedicine[1] = drCurrent["chittyid_vchr"];

                        if (drCurrent["lotno_vchr"].ToString() == "UNKNOWN")
                        {
                            drMedicine[2] = "";
                        }
                        else
                        {
                            drMedicine[2] = drCurrent["lotno_vchr"];
                        }

                        int intInOutType = 1;//1:入库 2:出库


                        if (Convert.ToInt16(drCurrent["isend_int"]) == 1) intProcessType = 7;
                        //单据号(第九位数字分别表示:1,入库2,出库3,外退4,内退5,损耗6,盘点7期初数,8调价)
                        switch (intProcessType)
                        {
                            case 1:
                                drMedicine[3] = "入库(" + drCurrent["vendorname_vchr"].ToString() + ")";
                                drMedicine[4] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                // drMedicine[5] = Convert.ToDouble(drCurrent["amount_int"]);
                                dblInAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[5] = dblInAmount;
                                dblEndGross = dblEndGross + Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblInAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                p_dblOldMoney = p_dblOldMoney + System.Math.Round(Convert.ToDouble(drCurrent["amount_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                intInOutType = 1;
                                break;
                            case 2:
                                drMedicine[3] = "出库(" + drCurrent["deptname_vchr"].ToString() + ")";
                                drMedicine[6] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                // drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);

                                dblOutAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[7] = dblOutAmount;

                                dblEndGross = dblEndGross - Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblOutAmount -= Convert.ToDouble(drCurrent["amount_int"]);
                                p_dblOldMoney = p_dblOldMoney - System.Math.Round(Convert.ToDouble(drCurrent["amount_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                intInOutType = 2;
                                break;
                            case 3:
                                drMedicine[3] = "外退(" + drCurrent["vendorname_vchr"].ToString() + ")";
                                drMedicine[6] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                //  drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                dblOutAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[7] = dblOutAmount;
                                dblEndGross = dblEndGross - Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblOutStorageAmount -= Convert.ToDouble(drCurrent["amount_int"]);
                                p_dblOldMoney = p_dblOldMoney - System.Math.Round(Convert.ToDouble(drCurrent["amount_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                intInOutType = 2;
                                break;
                            case 4:
                                drMedicine[3] = "内退(" + drCurrent["deptname_vchr"].ToString() + ")";
                                drMedicine[4] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                //drMedicine[5] = Convert.ToDouble(drCurrent["amount_int"]);
                                dblInAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[5] = dblInAmount;
                                dblEndGross = dblEndGross + Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblInStorageAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                p_dblOldMoney = p_dblOldMoney + System.Math.Round(Convert.ToDouble(drCurrent["amount_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                intInOutType = 1;
                                break;
                            case 5:
                                drMedicine[3] = "损耗(" + drCurrent["vendorname_vchr"].ToString() + ")";
                                drMedicine[6] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                //drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                dblOutAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                drMedicine[7] = dblOutAmount;
                                dblEndGross = dblEndGross - Convert.ToDouble(drCurrent["amount_int"]);
                                clsQuerVO.m_dblRejectAmount -= Convert.ToDouble(drCurrent["amount_int"]);
                                p_dblOldMoney = p_dblOldMoney - System.Math.Round(Convert.ToDouble(drCurrent["amount_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                intInOutType = 2;
                                break;

                            case 6:
                                drMedicine[3] = "盘点";
                                if (Convert.ToDouble(drCurrent["amount_int"]) > 0)
                                {
                                    drMedicine[4] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                    drMedicine[5] = Convert.ToDouble(drCurrent["amount_int"]);
                                    dblEndGross = dblEndGross + Convert.ToDouble(drCurrent["amount_int"]);
                                    p_dblOldMoney = p_dblOldMoney + System.Math.Round(Convert.ToDouble(drCurrent["amount_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                    intInOutType = 1;
                                }
                                else
                                {
                                    drMedicine[6] = Convert.ToDouble(drCurrent["retailprice_int"]);
                                    drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                    dblEndGross = dblEndGross - Convert.ToDouble(drCurrent["amount_int"]);
                                    p_dblOldMoney = p_dblOldMoney - System.Math.Round(Convert.ToDouble(drCurrent["amount_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                    intInOutType = 2;
                                }
                                clsQuerVO.m_dblCheckAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                break;

                            case 7:
                                if (Convert.ToInt16(drCurrent["isend_int"]) == 1)
                                {
                                    drMedicine[3] = "结存";
                                    dblJcGross = Convert.ToDouble(p_dtbMedicineDetail.Rows[p_dtbMedicineDetail.Rows.Count - 1]["oldgross_int"]);
                                    p_dblOldMoney = Convert.ToDouble(p_dtbMedicineDetail.Rows[p_dtbMedicineDetail.Rows.Count - 1]["oldmoney"]);
                                    clsQuerVO.m_dblBeginAmount += Convert.ToDouble(drCurrent["endamount_int"]);
                                }
                                else
                                {
                                    drMedicine[3] = "期初";
                                    dblEndGross = dblEndGross + Convert.ToDouble(drCurrent["amount_int"]);
                                    p_dblOldMoney = p_dblOldMoney + System.Math.Round(Convert.ToDouble(drCurrent["amount_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                    clsQuerVO.m_dblQcAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                }
                                drMedicine[1] = "";

                                intInOutType = 1;
                                break;

                            case 8:
                                drMedicine[3] = "调价";
                                if ((Convert.ToDouble(drCurrent["newretailprice_int"]) - Convert.ToDouble(drCurrent["oldretailprice_int"])) > 0)
                                {
                                    drMedicine[4] = Convert.ToDouble(drCurrent["newretailprice_int"]) - Convert.ToDouble(drCurrent["oldretailprice_int"]);
                                    drMedicine[5] = Convert.ToDouble(drCurrent["amount_int"]);
                                    intInOutType = 1;
                                }
                                else
                                {
                                    drMedicine[6] = Convert.ToDouble(drCurrent["oldretailprice_int"]) - Convert.ToDouble(drCurrent["newretailprice_int"]);
                                    drMedicine[7] = Convert.ToDouble(drCurrent["amount_int"]);
                                    intInOutType = 2;
                                }
                                clsQuerVO.m_dblRetailPriceAmount += Convert.ToDouble(drCurrent["amount_int"]);
                                //调价时数量不应改变。 by zhengshaowei 20121031
                                //dblEndGross = Convert.ToDouble(drCurrent["oldgross_int"]);
                                p_dblOldMoney = System.Math.Round(dblEndGross * Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                break;
                        }
                        if (p_intSet == 0)//余额零价取值 0 取当前零价,1 加权平均(未完成)
                        {
                            drMedicine[8] = Convert.ToDouble(drCurrent["retailprice_int"]);
                        }
                        else
                        {
                            drMedicine[8] = Convert.ToDouble(drCurrent["retailprice_int"]);
                        }

                        drMedicine[9] = dblEndGross;
                        drMedicine[10] = drCurrent["medicinename_vch"];
                        if (intProcessType != 7)
                        {
                            drMedicine[11] = Convert.ToDouble(drCurrent["callprice_int"]);
                            if (Convert.ToString(drCurrent["validperiod_chr"]) == "" || Convert.ToString(drCurrent["validperiod_chr"]) == "0001-01-01")
                            {
                                drMedicine[12] = "";
                            }
                            else
                            {
                                drMedicine[12] = Convert.ToDateTime(drCurrent["validperiod_chr"]).ToString("yyyy-MM-dd");
                            }

                            //drMedicine[13] = drCurrent["productorid_chr"];
                            //drMedicine[14] = Convert.ToDouble(drCurrent["retailprice_int"]);
                        }
                        else
                        {
                            drMedicine[2] = "";
                            drMedicine[11] = DBNull.Value;
                            drMedicine[12] = "";
                            //drMedicine[13] = "";
                        }
                        drMedicine[13] = p_dblOldMoney;
                        int intProcessType2 = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                        if ((iRow + 1 >= dtb.Rows.Count) || (dtb.Rows[iRow]["chittyid_vchr"].ToString() != dtb.Rows[iRow + 1]["chittyid_vchr"].ToString())
                            && dtb.Rows[iRow]["isend_int"].ToString() != "1" && intProcessType2 != 7)
                        {
                            if (intProcessType2 == 7)
                            {
                                drMedicine[9] = dblJcGross;
                                drMedicine[13] = p_dblOldMoney;
                            }
                            p_dtbMedicineDetail.Rows.Add(drMedicine);
                            dblInAmount = 0;
                            dblOutAmount = 0;
                        }
                        else if (dtb.Rows[iRow]["isend_int"].ToString() == "1" && dtb.Rows[iRow + 1]["isend_int"].ToString() != "1" && intProcessType2 != 7)
                        {
                            drMedicine[9] = dblJcGross;
                            drMedicine[13] = p_dblOldMoney;
                            p_dtbMedicineDetail.Rows.Add(drMedicine);
                            dblJcGross = 0;
                            dblInAmount = 0;
                            dblOutAmount = 0;
                        }
                        else if (dtb.Rows[iRow]["isend_int"].ToString() != "1" && m_intGetProcessType(dtb.Rows[iRow]["chittyid_vchr"].ToString()) == 7 && m_intGetProcessType(dtb.Rows[iRow + 1]["chittyid_vchr"].ToString()) != 7)
                        {
                            p_dtbMedicineDetail.Rows.Add(drMedicine);
                            dblInAmount = 0;
                            dblOutAmount = 0;
                        }
                    }//for
                    clsQuerVO.m_dblNewGross = dblEndGross;

                    p_dtbMedicineDetail.DefaultView.RowFilter = "brief_vchr <> '调价'";
                    p_dtbMedicineDetail = p_dtbMedicineDetail.DefaultView.ToTable();
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取操作类型
        /// <summary>
        /// 获取操作类型
        /// </summary>
        /// <param name="p_strChitty">单据号</param>
        /// <returns></returns>
        [AutoComplete]
        private int m_intGetProcessType(string p_strChitty)
        {
            int intType = 0;
            if (string.IsNullOrEmpty(p_strChitty))
            {
                return -1;
            }

            try
            {
                char chrPro = p_strChitty[8];

                if (!int.TryParse(chrPro.ToString(), out intType))
                {
                    return -1;
                }
                else
                {
                    if (intType < 1 || intType > 8)
                    {
                        return -1;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return intType;
        }
        #endregion

        #region 获取系统设置
        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSetID">设置ID</param>
        /// <param name="p_intSet">设置代码</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSysSetting(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSetID, out int p_intSet)
        {
            p_intSet = 0;
            if (p_strSetID == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select setstatus_int from t_sys_setting where setid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strSetID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_intSet = Convert.ToInt32(dtbValue.Rows[0][0]);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取在开始时间前的最后一次结存数
        /// <summary>
        /// 获取在开始时间前的最后一次结存数
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtmBegin"></param>
        /// <param name="p_strMedicine"></param>
        /// <param name="p_intEndGross"></param>
        /// <param name="p_intAmount"></param>
        /// <param name="p_datOperatedate"></param>
        /// <returns></returns>
        public long m_lngGetEndGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID,
            DateTime p_dtmBegin, string p_strMedicine, out double p_intEndGross, out double p_intAmount, out string p_datOperatedate, out double p_dblOldMoney)
        {
            p_intEndGross = 0;
            p_intAmount = 0;
            p_datOperatedate = "";
            p_dblOldMoney = 0;
            long lngRes = 0;
            string strAccountid;
            DateTime EndAccTime;
            try
            {
                //查出最近的一次不是结存的操作日期
                string Sql = @"select *
                                  from (select t.operatedate_dat
                                          from t_ms_account_detail t
                                         where t.medicineid_chr = ?
                                           and t.operatedate_dat < ?
                                           and t.isend_int = 0
                                           and (t.state_int = 1 or t.state_int = 2)
                                         order by t.operatedate_dat desc) a
                                 where rownum = 1";

                Sql = @" select t.operatedate_dat
                           from t_ms_account_detail t
                          where t.medicineid_chr = ?
                            and (t.operatedate_dat is not null and
                                t.operatedate_dat < to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                            and t.isend_int = 0
                            and (t.state_int = 1 or t.state_int = 2)";

                DataTable dtbValue = new DataTable();
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicine;
                //objDPArr[1].DbType = DbType.DateTime;
                //objDPArr[1].Value = p_dtmBegin;
                objDPArr[1].Value = p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss");

                lngRes = objHRPServ.lngGetDataTableWithParameters(Sql, ref dtbValue, objDPArr);
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    DataView dv = new DataView(dtbValue);
                    dv.Sort = "operatedate_dat desc";
                    EndAccTime = Convert.ToDateTime(dv[0]["operatedate_dat"]);

                    //EndAccTime = Convert.ToDateTime(dtbValue.Rows[0]["operatedate_dat"]);
                }
                else
                {
                    EndAccTime = Convert.ToDateTime("2005-01-01 00:00:00");
                    //return -1;
                }
                //获取最后一次不是结存的真实数量和金额
                Sql = @"select a.endamount endamount_int, (a.endamount * a.retailprice_int) oldmoney from
                            (select (sum(t.oldgross_int) +
                                   sum(t.amount_int * decode(t.type_int, 1, 1, 2, -1, 1))) endamount, t.retailprice_int
                              from t_ms_account_detail t
                             where t.medicineid_chr = ?
                               and t.operatedate_dat = ?
                               and (t.state_int = 1 or t.state_int = 2) 
                               group by t.retailprice_int) a";

                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicine;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = EndAccTime;

                lngRes = objHRPServ.lngGetDataTableWithParameters(Sql, ref dtbValue, objDPArr);
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    if (dtbValue.Rows[0]["endamount_int"] != DBNull.Value)
                    {
                        p_intEndGross = Convert.ToDouble(dtbValue.Rows[0]["endamount_int"]);
                        p_dblOldMoney = Convert.ToDouble(dtbValue.Rows[0]["oldmoney"]);
                    }
                    else
                    {
                        Sql = @"select t.amount_int,t.operatedate_dat
                                      from t_ms_account_detail t
                                     where t.medicineid_chr = ?
                                       and t.operatedate_dat < ?
                                       (t.operatedate_dat is not null and t.operatedate_dat < to_date(?, 'yyyy-mm-dd hh24:mi:ss')) 
                                       and (t.state_int = 1 or t.state_int =2)";
                        //order by t.operatedate_dat desc";
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_strMedicine;
                        //objDPArr[1].DbType = DbType.DateTime;
                        //objDPArr[1].Value = p_dtmBegin;
                        objDPArr[1].Value = p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss");
                        lngRes = objHRPServ.lngGetDataTableWithParameters(Sql, ref dtbValue, objDPArr);
                        if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dtbValue);
                            dv.Sort = "operatedate_dat desc";
                            p_intEndGross = 0;
                            p_dblOldMoney = 0;
                            EndAccTime = Convert.ToDateTime(dv[0]["operatedate_dat"]);
                            //EndAccTime = Convert.ToDateTime(dtbValue.Rows[0]["operatedate_dat"]);
                        }

                        Sql = @"select t.medicinename_vch,
			                                 t.lotno_vchr,
			                                 t.retailprice_int,
			                                 t.amount_int,
			                                 t.oldgross_int,
			                                 t.chittyid_vchr,
			                                 t.operatedate_dat,
			                                 t.instorageid_vchr,
			                                 t.endamount_int,
			                                 t.isend_int,
			                                 b.oldretailprice_int,
			                                 b.newretailprice_int,
			                                 e.deptname_vchr,
			                                 f.vendorname_vchr,
			                                 t.callprice_int,
			                                 t.validperiod_dat validperiod_chr,
			                                 '' productorid_chr,t.retailprice_int * t.amount_int oldmoney
	                                from t_ms_account_detail t
	                                left join t_ms_adjustprice a on t.chittyid_vchr = a.adjustpriceid_vchr
	                                left join t_ms_adjustprice_detail b on a.seriesid_int = b.seriesid2_int
	                                left join t_bse_deptdesc e on t.deptid_chr = e.deptid_chr
	                                left join t_bse_vendor f on t.deptid_chr = f.vendorid_chr
                                 where t.storageid_chr = ?
	                                 and t.medicineid_chr = ?
	                                 and t.operatedate_dat between ?
	                                 and ?
	                                 and (t.state_int = 1 or t.state_int = 2)
                                 order by t.operatedate_dat, t.instorageid_vchr";
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].Value = p_strStorageID;
                        objDPArr[1].Value = p_strMedicine;
                        objDPArr[2].DbType = DbType.DateTime;
                        objDPArr[2].Value = EndAccTime;
                        objDPArr[3].DbType = DbType.DateTime;
                        objDPArr[3].Value = p_dtmBegin;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(Sql, ref dtbValue, objDPArr);
                        if (lngRes > 0 && dtbValue.Rows.Count > 0)
                        {
                            int p_intSet;
                            m_lngGetSysSetting(null, "5018", out p_intSet);
                            DataRow drCurrent = null;

                            double douAmount = 0;
                            double douOldgross = 0;

                            for (int iRow = 0; iRow < dtbValue.Rows.Count; iRow++)
                            {
                                drCurrent = dtbValue.Rows[iRow];

                                //  DataRow drMedicine = p_dtbMedicineDetail.NewRow();
                                int intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                                int intInOutType = 1;//1:入库 2:出库
                                //单据号(第九位数字分别表示:1,入库2,出库3,外退4,内退5,损耗6,盘点7期初数,8调价)

                                switch (intProcessType)
                                {
                                    case 1:
                                        p_intEndGross += Convert.ToDouble(drCurrent["amount_int"]);
                                        p_dblOldMoney += Convert.ToDouble(drCurrent["oldmoney"]);
                                        break;
                                    case 2:
                                        p_intEndGross -= Convert.ToDouble(drCurrent["amount_int"]);
                                        p_dblOldMoney -= Convert.ToDouble(drCurrent["oldmoney"]);
                                        break;
                                    case 3:
                                        p_intEndGross -= Convert.ToDouble(drCurrent["amount_int"]);
                                        p_dblOldMoney -= Convert.ToDouble(drCurrent["oldmoney"]);
                                        break;
                                    case 4:
                                        p_intEndGross += Convert.ToDouble(drCurrent["amount_int"]);
                                        p_dblOldMoney += Convert.ToDouble(drCurrent["oldmoney"]);
                                        break;
                                    case 5:
                                        p_intEndGross -= Convert.ToDouble(drCurrent["amount_int"]);
                                        p_dblOldMoney -= Convert.ToDouble(drCurrent["oldmoney"]);
                                        break;

                                    case 6:

                                        if (Convert.ToDouble(drCurrent["amount_int"]) > 0)
                                        {
                                            p_intEndGross += Convert.ToDouble(drCurrent["amount_int"]);
                                            p_dblOldMoney += Convert.ToDouble(drCurrent["oldmoney"]);
                                        }
                                        else
                                        {
                                            p_intEndGross -= Convert.ToDouble(drCurrent["amount_int"]);
                                            p_dblOldMoney -= Convert.ToDouble(drCurrent["oldmoney"]);
                                        }
                                        break;

                                    case 7:
                                        p_intEndGross += Convert.ToDouble(drCurrent["amount_int"]);
                                        p_dblOldMoney += Convert.ToDouble(drCurrent["oldmoney"]);
                                        break;
                                    case 8:
                                        p_intEndGross = Convert.ToDouble(drCurrent["oldgross_int"]);
                                        p_dblOldMoney = Convert.ToDouble(drCurrent["oldgross_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]);
                                        break;
                                }

                            }
                            p_intAmount = Convert.ToDouble(drCurrent["amount_int"]);
                            p_datOperatedate = drCurrent["operatedate_dat"].ToString();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return 1;
        }
        #endregion
    }
}
