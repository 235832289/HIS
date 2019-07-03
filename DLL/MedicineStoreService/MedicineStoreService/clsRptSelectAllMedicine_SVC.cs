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
    /// 查询药品
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsRptSelectAllMedicine_SVC:com.digitalwave .iCare .middletier .clsMiddleTierBase
    {
        #region 查询旧药品
        /// <summary>
        /// 查询旧药品
        /// </summary>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_dtMedicineInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineInfo(string p_strMedicineID,out DataTable p_dtMedicineInfo)
        {
            long lngRes = -1;
            p_dtMedicineInfo = new DataTable();
            try
            {
                string strSQL = @"select t.assistcode_chr,t.medicinename_vchr,t.medspec_vchr,t.opunit_chr,t.productorid_chr,t.unitprice_mny from(
select a.assistcode_chr, a.medicinename_vchr, a.medspec_vchr,a.opunit_chr,a.productorid_chr,a.unitprice_mny
  from t_bse_medicine a
 where  a.medicinename_vchr like ?
union all
select b.assistcode_chr, b.medicinename_vchr, b.medspec_vchr,b.opunit_chr,b.productorid_chr,b.unitprice_mny
  from t_bse_medicine_0318 b
 where  b.medicinename_vchr like ?
 )t group by t.assistcode_chr,t.medicinename_vchr,t.medspec_vchr,t.opunit_chr,t.productorid_chr,t.unitprice_mny
";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2,out objDPArr);
                objDPArr[0].DbType = DbType.String;
                objDPArr[0].Value = p_strMedicineID+"%";
                objDPArr[1].DbType = DbType.String;
                objDPArr[1].Value = p_strMedicineID+"%";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtMedicineInfo, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }

            return lngRes;
        }
        #endregion

        #region 查询出入库帐
        /// <summary>
        /// 查询出入库帐
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_blnIsDS">是否药房</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_blnCombine">是否单品种</param>
        /// <param name="p_strStorageID">库房ID</param>
        /// <param name="p_strMedicineID">药品ID或助记码</param>
        /// <param name="p_dtmStart">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineDetailReport(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsDS, bool p_blnIsHospital, bool p_blnCombine,
            string p_strStorageID,string p_strMedicineID, DateTime p_dtmStart, DateTime p_dtmEnd, out DataTable p_dtbResult)
        {
            p_dtbResult = null;
            DataTable dtbTemp1 = new DataTable();
            DataTable dtbTemp2 = new DataTable();
            DataTable dtbTemp3 = new DataTable();
            DataTable dtbTemp4 = new DataTable();
            long lngRes = 0;
            string strSQL = string.Empty;
            string strMedicine1 = string.Empty;
            string strMedicine2 = string.Empty;
            string strMedicine3 = string.Empty;
            string strMedicine4 = string.Empty;
            
            clsHRPTableService objHRP = new clsHRPTableService();
            IDataParameter[] objParamArr = null;

            if (p_blnIsDS)
            {
                if (p_blnCombine)
                {
                    strMedicine1 = @" and q.assistcode_chr = ? ";
                    strMedicine2 = @" and d.assistcode_chr = ? ";
                    strMedicine3 = @" and i.assistcode_chr = ? ";
                    strMedicine4 = @" and n.assistcode_chr = ? ";
                }
                else
                {
                    strMedicine1 = @" and p.medicineid_chr = ? ";
                    strMedicine2 = @" and a.medicineid_chr = ? ";
                    strMedicine3 = @" and f.medicineid_chr = ? ";
                    strMedicine4 = @" and n.medicineid_chr = ? ";
                }

                strSQL = @"select '入库' direction,
       '建帐入库' typename_vchr,
       p.productorid_chr,
       p.exam_dat operatedate_dat,
       '' deptname,
       '' patientcardid_chr,
       '' lastname_vchr,
       p.lotno_vchr,
       p.validperiod_dat validperiod,
       decode(q.opchargeflg_int, 0, q.opunit_chr, q.ipunit_chr) unit,
       decode(q.opchargeflg_int,
              0,
              p.opretailprice_int,
              round(p.opretailprice_int / p.packqty_dec, 2)) retailprice_int,
       decode(q.opchargeflg_int, 0, p.opamount, p.ipamount) inamount,
       round(p.ipamount * p.opretailprice_int / p.packqty_dec, 4) insum,
       0 outamount,
       0 outsum,
       decode(q.opchargeflg_int, 0, p.opamount, p.ipamount) oldgross_int
  from t_ds_initial p
  left join t_bse_medicine q on q.medicineid_chr = p.medicineid_chr
  left join t_bse_medstore r on r.deptid_chr = p.drugstoreid_chr
 where p.exam_dat is not null
   and r.medstoreid_chr = ? " + strMedicine1 + @" and p.exam_dat between ? and ?";
                if (p_blnIsHospital)
                {
                    strSQL = strSQL.Replace("opchargeflg_int", "ipchargeflg_int");
                }
                objParamArr = null;
                objHRP.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = p_strStorageID;
                objParamArr[1].Value = p_strMedicineID;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmStart;
                objParamArr[3].DbType = DbType.DateTime;
                objParamArr[3].Value = p_dtmEnd;
                lngRes = objHRP.lngGetDataTableWithParameters(strSQL, ref dtbTemp1, objParamArr);

                strSQL = @"select '入库' direction,
       c.typename_vchr,
       a.productorid_chr,
       b.drugstoreexam_date operatedate_dat,
       e.deptname_vchr deptname,
       '' patientcardid_chr,
       '' lastname_vchr,
       a.lotno_vchr,
       a.validperiod_dat validperiod,
       decode(d.opchargeflg_int, 0, d.opunit_chr, d.ipunit_chr) unit,
       decode(d.opchargeflg_int,
              0,
              a.opretailprice_int,
              round(a.opretailprice_int / a.packqty_dec, 2)) retailprice_int,
       decode(d.opchargeflg_int,
              0,
              a.opamount_int,
              a.ipamount_int) inamount,
       round(a.ipamount_int * a.opretailprice_int / a.packqty_dec, 4) insum,
       0 outamount,
       0 outsum,
       decode(d.opchargeflg_int, 0, a.opoldgross_int, a.ipoldgross_int) oldgross_int 
  from t_ds_instorage_detail a
 right join t_ds_instorage b on b.seriesid_int = a.seriesid2_int
  left join t_aid_impexptype c on c.typecode_vchr = b.typecode_vchr
  left join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
  left join t_bse_deptdesc e on e.deptid_chr = b.borrowdept_chr
  left join t_bse_medstore s on s.deptid_chr = b.drugstoreid_chr
 where a.status = 1
   and (b.status = 2 or a.status = 3)
   and s.medstoreid_chr = ? " + strMedicine2 + @" and b.drugstoreexam_date between ? and ?";
                //应该不用加以下数据了
              //+decode(d.opchargeflg_int,
              //0,
              //round(a.ipamount_int / a.packqty_dec, 2),
              //a.ipamount_int) 
                //+decode(d.opchargeflg_int,
              //0,
              //round(a.ipamount_int / a.packqty_dec, 2),
              //a.ipamount_int)
                if (p_blnIsHospital)
                {
                    strSQL = strSQL.Replace("opchargeflg_int", "ipchargeflg_int");
                }
                objParamArr = null;
                objHRP.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = p_strStorageID;
                objParamArr[1].Value = p_strMedicineID;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmStart;
                objParamArr[3].DbType = DbType.DateTime;
                objParamArr[3].Value = p_dtmEnd;
                lngRes = objHRP.lngGetDataTableWithParameters(strSQL, ref dtbTemp2, objParamArr);
                strSQL = @"select '出库' direction,
       h.typename_vchr,
       f.productorid_chr,
       g.examdate_dat operatedate_dat,
       j.deptname_vchr deptname,
       '' patientcardid_chr,
       '' lastname_vchr,
       f.lotno_vchr,
       f.validperiod_dat validperiod,
       decode(i.opchargeflg_int, 0, i.opunit_chr, i.ipunit_chr) unit,
       decode(i.opchargeflg_int,
              0,
              f.opretailprice_int,
              round(f.opretailprice_int / f.packqty_dec, 2)) retailprice_int,
       0 inamount,
       0 insum,
       decode(i.opchargeflg_int, 0, f.opamount_int, f.ipamount_int) outamount,
       round(f.ipamount_int * f.opretailprice_int / f.packqty_dec, 4) outsum,
       decode(i.opchargeflg_int, 0, f.opoldgross_int, f.ipoldgross_int) oldgross_int
  from t_ds_outstorage_detail f
 right join t_ds_outstorage g on g.seriesid_int = f.seriesid2_int
  left join t_aid_impexptype h on h.typecode_vchr = g.typecode_vchr
  left join t_bse_medicine i on i.medicineid_chr = f.medicineid_chr
  left join t_bse_deptdesc j on j.deptid_chr = g.instoredept_chr
  left join t_bse_medstore t on t.deptid_chr = g.drugstoreid_chr
 where f.status = 1
   and (g.status_int = 2 or g.status_int = 3)
   and t.medstoreid_chr = ? " + strMedicine3 + @" and g.examdate_dat between ? and ?";
              //  -decode(i.opchargeflg_int,
              //0,
              //round(f.ipamount_int / f.packqty_dec, 2),
              //f.ipamount_int)
              //  -decode(i.opchargeflg_int,
              //0,
              //round(f.ipamount_int / f.packqty_dec, 2),
              //f.ipamount_int)

                if (p_blnIsHospital)
                {
                    strSQL = strSQL.Replace("opchargeflg_int", "ipchargeflg_int");
                }
                objParamArr = null;
                objHRP.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = p_strStorageID;
                objParamArr[1].Value = p_strMedicineID;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmStart;
                objParamArr[3].DbType = DbType.DateTime;
                objParamArr[3].Value = p_dtmEnd;
                lngRes = objHRP.lngGetDataTableWithParameters(strSQL, ref dtbTemp3, objParamArr);

                if (p_blnIsHospital)
                {
                    strSQL = @"select '医嘱' direction,
       decode(k.type_int, 1, '病人发药', 2, '病人退药') typename_vchr,
       k.productorid_chr,
       k.operatedate_dat,
       v.deptname_vchr deptname,
       o.inpatientid_chr patientcardid_chr,
       m.lastname_vchr,
       k.lotno_vchr,
       k.validperiod_dat validperiod,
       decode(n.ipchargeflg_int, 0, n.opunit_chr, n.ipunit_chr) unit,
       decode(n.ipchargeflg_int,
              0,
              k.opretailprice_int,
              round(k.opretailprice_int / n.packqty_dec, 2)) retailprice_int,
       0 inamount,
       0 insum,
       decode(k.type_int, 1, 1, -1) *
       decode(n.ipchargeflg_int, 0, k.opamount_int, k.ipamount_int) outamount,
       decode(k.type_int, 1, 1, -1) *
       round(k.ipamount_int * k.opretailprice_int / n.packqty_dec, 4) outsum,
       decode(n.ipchargeflg_int, 0, k.opoldgross_int, k.ipoldgross_int) oldgross_int
  from t_ds_putmedaccount_detail k
  left join t_bih_opr_putmeddetail l on l.putmeddetailid_chr =
                                        k.putmeddetailid_chr
  left join t_bse_patient m on m.patientid_chr = l.paientid_chr
  left join t_bse_medicine n on n.medicineid_chr = k.medicineid_chr
  left join t_opr_bih_register o on o.registerid_chr = l.registerid_chr
  left join t_bse_medstore u on u.deptid_chr = k.drugstoreid_int
  left join t_bse_deptdesc v on v.deptid_chr = k.deptid_chr
 where k.state_int <> 0
   and u.medstoreid_chr = ? " + strMedicine4 + @"and k.operatedate_dat between ? and ? ";
                }
                else
                {
                    strSQL = @"select '处方' direction,
       decode(k.type_int, 2, '病人发药', 1, '病人退药') typename_vchr,
       k.productorid_chr,
       k.operatedate_dat,
       '' deptname,
       o.patientcardid_chr,
       m.lastname_vchr,
       k.lotno_vchr,
       k.validperiod_dat validperiod,
       decode(n.opchargeflg_int, 0, n.opunit_chr, n.ipunit_chr) unit,
       decode(n.opchargeflg_int,
              0,
              k.opretailprice_int,
              round(k.opretailprice_int / n.packqty_dec, 2)) retailprice_int,
       0 inamount,
       0 insum,
       decode(k.type_int, 2, 1, -1) *
       decode(n.opchargeflg_int, 0, k.opamount_int, k.ipamount_int) outamount,
       decode(k.type_int, 2, 1, -1) *
       round(k.ipamount_int * k.opretailprice_int / n.packqty_dec, 4) outsum,
       decode(n.opchargeflg_int, 0, k.opoldgross_int, k.ipoldgross_int) oldgross_int
  from t_ds_recipeaccount_detail k
  left join t_opr_outpatientrecipe l on l.outpatrecipeid_chr =
                                        k.outpatrecipeid_chr
  left join t_bse_patient m on m.patientid_chr = l.patientid_chr
  left join t_bse_medicine n on n.medicineid_chr = k.medicineid_chr
  left join t_bse_patientcard o on o.patientid_chr = l.patientid_chr
  left join t_bse_medstore u on u.deptid_chr = k.drugstoreid_int
 where k.state_int <> 0
   and u.medstoreid_chr = ? " + strMedicine4 + @"and k.operatedate_dat between ? and ? ";
                }

                objParamArr = null;
                objHRP.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = p_strStorageID;
                objParamArr[1].Value = p_strMedicineID;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmStart;
                objParamArr[3].DbType = DbType.DateTime;
                objParamArr[3].Value = p_dtmEnd;
                lngRes = objHRP.lngGetDataTableWithParameters(strSQL, ref dtbTemp4, objParamArr);

                dtbTemp1.Merge(dtbTemp2);
                dtbTemp1.Merge(dtbTemp3);
                dtbTemp1.Merge(dtbTemp4);
                p_dtbResult = dtbTemp1.Copy();
            }
            else
            {
                if (p_blnCombine)
                {
                    strMedicine1 = @" and c.assistcode_chr = ? ";
                }
                else
                {
                    strMedicine1 = @" and a.medicineid_chr = ? ";
                }

                strSQL = @"select decode(a.type_int, 1, '入库', 2, '出库') direction,
       b.typename_vchr,
       c.productorid_chr,
       a.operatedate_dat,
       decode(a.type_int, 1, d.vendorname_vchr, 2, e.deptname_vchr) deptname,
       '' patientcardid_chr,
       '' lastname_vchr,
       a.lotno_vchr,
       a.validperiod_dat validperiod,
       a.opunit_chr unit,
       a.retailprice_int,
       decode(a.type_int, 1, a.amount_int, 2, 0) inamount,       
       decode(a.type_int, 1, a.amount_int, 2, 0) * a.retailprice_int insum,
       decode(a.type_int, 1, 0, 2, a.amount_int) outamount,
       decode(a.type_int, 1, 0, 2, a.amount_int) * a.retailprice_int outsum,
       a.oldgross_int
  from t_ms_account_detail a
  left join t_aid_impexptype b on b.typecode_vchr = a.typecode_vchr
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_vendor d on d.vendorid_chr = a.deptid_chr
  left join t_bse_deptdesc e on e.deptid_chr = a.deptid_chr
 where (a.type_int = 1 or a.type_int = 2)
   and a.state_int <> 0 and a.storageid_chr = ? " + strMedicine1 + @" and a.operatedate_dat between ? and ?";
                //+decode(a.type_int, 1, a.amount_int, 2, 0)-decode(a.type_int, 1, 0, 2, a.amount_int) oldgross_int
                objParamArr = null;
                objHRP.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = p_strStorageID;
                objParamArr[1].Value = p_strMedicineID;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmStart;
                objParamArr[3].DbType = DbType.DateTime;
                objParamArr[3].Value = p_dtmEnd;
                lngRes = objHRP.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objParamArr);
            }    
            
            
            try
            {
                                
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbResult.DefaultView;
                    dvResult.Sort = "operatedate_dat";
                    p_dtbResult = dvResult.ToTable();
                    foreach (DataRow dr in p_dtbResult.Rows)
                    {
                        if (Convert.ToDateTime(dr["validperiod"]).ToString("yyyy-MM-dd").Trim() == "0001-01-01")
                        {
                            dr["validperiod"] = DBNull.Value;
                        }
                        else
                        {
                            dr["validperiod"] = Convert.ToDateTime(dr["validperiod"]).ToString("yy-MM-dd");
                        }
                    }
                    p_dtbResult.AcceptChanges();
                }
            }
            catch(Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }
            return lngRes;
        }
        #endregion
    }
}
