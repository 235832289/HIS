using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 期初数录入
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsInventoryRecordSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }

            try
            {
                string strSQL = @"select t.assistcode_chr,
			 t.medicinename_vchr,
			 t.medspec_vchr,
			 t.opunit_chr,
			 t.ipunit_chr,
			 t.packqty_dec,
			 t.productorid_chr,
			 t.pycode_chr,
			 t.wbcode_chr,
			 t.medicineid_chr,
			 t.ispoison_chr,
			 t.ischlorpromazine2_chr,
			 t.unitprice_mny,
			 t.medicinetypeid_chr,
			 t.tradeprice_mny,
			 t.limitunitprice_mny,
			 t.opchargeflg_int,
			 t.ipchargeflg_int,
			 t.ifstop_int,
			 decode(sum(s.realgross_int),null,0,sum(s.realgross_int)) currentgross_num
	from t_bse_medicine t
	left join t_ms_storage_detail s on t.medicineid_chr = s.medicineid_chr
 where t.assistcode_chr like ?
 group by t.assistcode_chr,
					t.medicinename_vchr,
					t.medspec_vchr,
					t.opunit_chr,
					t.ipunit_chr,
					t.packqty_dec,
					t.productorid_chr,
					t.pycode_chr,
					t.wbcode_chr,
					t.medicineid_chr,
					t.ispoison_chr,
					t.ischlorpromazine2_chr,
					t.unitprice_mny,
					t.medicinetypeid_chr,
					t.tradeprice_mny,
					t.limitunitprice_mny,
					t.opchargeflg_int,
					t.ipchargeflg_int,
					t.ifstop_int
 order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strAssistCode + "%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode,string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }

            try
            {
                string strSQL = @"select t.assistcode_chr,
			 t.medicinename_vchr,
			 t.medspec_vchr,
			 t.opunit_chr,
			 t.ipunit_chr,
			 t.packqty_dec,
			 t.productorid_chr,
			 t.pycode_chr,
			 t.wbcode_chr,
			 t.medicineid_chr,
			 t.ispoison_chr,
			 t.ischlorpromazine2_chr,
			 t.unitprice_mny,
			 t.medicinetypeid_chr,
			 t.tradeprice_mny,
			 t.limitunitprice_mny,
			 t.opchargeflg_int,
			 t.ipchargeflg_int,
			 t.ifstop_int,
			 decode(sum(s.realgross_int),null,0,sum(s.realgross_int)) currentgross_num
	from t_bse_medicine t
	left join t_ms_storage_detail s on t.medicineid_chr = s.medicineid_chr
 where t.assistcode_chr like ?
	 and exists (select r.medicineroomid
					from t_ms_medicinestoreroomset r
				 where r.medicinetypeid_chr = t.medicinetypeid_chr
					 and r.medicineroomid = ?)
 group by t.assistcode_chr,
					t.medicinename_vchr,
					t.medspec_vchr,
					t.opunit_chr,
					t.ipunit_chr,
					t.packqty_dec,
					t.productorid_chr,
					t.pycode_chr,
					t.wbcode_chr,
					t.medicineid_chr,
					t.ispoison_chr,
					t.ischlorpromazine2_chr,
					t.unitprice_mny,
					t.medicinetypeid_chr,
					t.tradeprice_mny,
					t.limitunitprice_mny,
					t.opchargeflg_int,
					t.ipchargeflg_int,
					t.ifstop_int
 order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strAssistCode + "%";
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取可用数大于0药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicineNotZero(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, string p_strStorageID,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }

            try
            {
                string strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       t.opunit_chr,
       t.ipunit_chr,
       t.packqty_dec,
       t.productorid_chr,
       t.pycode_chr,
       t.wbcode_chr,
       t.medicineid_chr,
       t.ispoison_chr,
       t.ischlorpromazine2_chr,
       t.unitprice_mny,
       t.medicinetypeid_chr,
       t.tradeprice_mny,
       t.limitunitprice_mny,
       t.opchargeflg_int,
       t.ipchargeflg_int,
       t.ifstop_int,
			 sum(a.availagross_int)
  from t_bse_medicine t
	left join t_ms_storage_detail a on a.medicineid_chr = t.medicineid_chr
 where t.assistcode_chr like ?
   and exists (select r.medicineroomid
          from t_ms_medicinestoreroomset r
         where r.medicinetypeid_chr = t.medicinetypeid_chr
           and r.medicineroomid = ? and a.storageid_chr = ?)
					 having sum(a.availagross_int) > 0
					 and a.status = 1
					 group by t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       t.opunit_chr,
       t.ipunit_chr,
       t.packqty_dec,
       t.productorid_chr,
       t.pycode_chr,
       t.wbcode_chr,
       t.medicineid_chr,
       t.ispoison_chr,
       t.ischlorpromazine2_chr,
       t.unitprice_mny,
       t.medicinetypeid_chr,
       t.tradeprice_mny,
       t.limitunitprice_mny,
       t.opchargeflg_int,
       t.ipchargeflg_int,
       t.ifstop_int,
	   a.status,
       a.storageid_chr
 order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strAssistCode + "%";
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        /// <summary>
        /// 获取药品最基本信息(带库存信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicineWithGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }

            try
            {
                string strSQL = @"select t.assistcode_chr,
			 t.medicinename_vchr,
			 t.medspec_vchr,
			 t.opunit_chr,
			 t.ipunit_chr,
			 t.packqty_dec,
			 t.productorid_chr,
			 t.pycode_chr,
			 t.wbcode_chr,
			 t.medicineid_chr,
			 t.ispoison_chr,
			 t.ischlorpromazine2_chr,
			 t.unitprice_mny,
			 t.medicinetypeid_chr,
			 t.tradeprice_mny,
			 t.limitunitprice_mny,
			 t.opchargeflg_int,
			 t.ipchargeflg_int,
			 t.ifstop_int,
			 s.currentgross_num,
			 nvl(b.itemname_vchr,'') as aliasname_vchr,
			 nvl(b.pycode_vchr,'') as aliaspycode_vchr,
			 nvl(b.wbcode_vchr,'') as aliaswbcode_vchr
	from t_bse_medicine t
	left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
	left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
																	and b.status_int = 1
																	and b.flag_int = 1
	left join t_ms_storage s on s.medicineid_chr = t.medicineid_chr
													and s.storageid_chr = ?
 where t.assistcode_chr like ? and t.deleted_int=0
	 and exists (select r.medicineroomid
					from t_ms_medicinestoreroomset r
				 where r.medicinetypeid_chr = t.medicinetypeid_chr
					 and r.medicineroomid = ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAssistCode + "%";
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbMedicine != null && p_dtbMedicine.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbMedicine.DefaultView;
                    dvResult.Sort = "assistcode_chr";
                    p_dtbMedicine = dvResult.ToTable();
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

        #region 获取已录入药品信息
        /// <summary>
        /// 获取已录入药品信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"select a.seriesid_int seriesid,
       a.medicineid_chr medicineid,
       a.medicinename_vch medicinename,
       a.medspec_vchr medicinespec,
       a.currentgross_num storeamount,
       a.retailprice_int saleunitprice,
       a.wholesaleprice_int wholesaleunitprice,
       a.callprice_int bugunitprice,
       a.vendorid_chr supplierid,
       a.productorid_chr manufacturer,
       a.validperiod_dat validity,
       b.assistcode_chr medicinecode,
       b.medicinetypeid_chr,
       a.opunit_vchr medicineunit,
        case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end  batchnumber,
       a.createrid,
       c.empno_chr createrno,
       c.lastname_vchr creatername,
       a.examerid,
       d.empno_chr examerno,
       d.lastname_vchr examername,
       case
         when examerid is null then
          '未审核'
         when inaccounterid_chr is not null then
          '已入帐'
         else
          '已审核'
       end status,
       e.vendorname_vchr suppliername,
       a.inaccounterid_chr,
       a.initialid_chr,
       f.lotno_int,
       f.validperiod_int
  from t_ms_initial a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 inner join t_bse_employee c on a.createrid = c.empid_chr
  left outer join t_bse_vendor e on e.vendorid_chr = a.vendorid_chr
  left outer join t_bse_employee d on a.examerid = d.empid_chr
  left outer join t_ms_medicinetypevisionmset f on b.medicinetypeid_chr = f.medicinetypeid_vchr
 where a.storageid_chr = ?
  order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 添加原始库存
        /// <summary>
        /// 添加原始库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMSVOArr">原始库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedicineInitial(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_MedicineInitial_VO[] p_objMSVOArr)
        {
            if (p_objMSVOArr == null || p_objMSVOArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"insert into t_ms_initial
  (seriesid_int,
   storageid_chr,
   medicineid_chr,
   medicinename_vch,
   medspec_vchr,
   currentgross_num,
   retailprice_int,
   wholesaleprice_int,
   callprice_int,
   vendorid_chr,
   productorid_chr,
   validperiod_dat,
   lotno_vchr,
   createrid,
   examerid,
   opunit_vchr,
   inaccounterid_chr,
   initialid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                long[] lngSEQArr = null;
                string strNow = DateTime.Now.ToString("yyyyMMdd") + "7";
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_INITIAL", p_objMSVOArr.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < p_objMSVOArr.Length; iRow++)
                    {
                        string strSEQ = lngSEQArr[iRow].ToString().PadLeft(4, '0');

                        p_objMSVOArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        p_objMSVOArr[iRow].m_strINITIALID_CHR = strNow + strSEQ;

                        objHRPServ.CreateDatabaseParameter(18, out objDPArr);
                        objDPArr[0].Value = p_objMSVOArr[iRow].m_lngSERIESID_INT;
                        objDPArr[1].Value = p_objMSVOArr[iRow].m_strSTORAGEID_CHR;
		                objDPArr[2].Value = p_objMSVOArr[iRow].m_strMEDICINEID_CHR;
		                objDPArr[3].Value = p_objMSVOArr[iRow].m_strMEDICINENAME_VCH;
		                objDPArr[4].Value = p_objMSVOArr[iRow].m_strMEDSPEC_VCHR;
		                objDPArr[5].Value = p_objMSVOArr[iRow].m_dblCURRENTGROSS_NUM;
		                objDPArr[6].Value = p_objMSVOArr[iRow].m_dcmRETAILPRICE_INT;
		                objDPArr[7].Value = p_objMSVOArr[iRow].m_dcmWHOLESALEPRICE_INT;
		                objDPArr[8].Value = p_objMSVOArr[iRow].m_dcmCALLPRICE_INT;
		                objDPArr[9].Value = p_objMSVOArr[iRow].m_strVENDORID_CHR;
		                objDPArr[10].Value = p_objMSVOArr[iRow].m_strPRODUCTORID_CHR;
                        objDPArr[11].DbType = DbType.DateTime;
		                objDPArr[11].Value = p_objMSVOArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objDPArr[12].Value = p_objMSVOArr[iRow].m_strLOTNO_VCHR;
                        objDPArr[13].Value = p_objMSVOArr[iRow].m_strCREATERID;
                        objDPArr[14].Value = p_objMSVOArr[iRow].m_strEXAMERID;
                        objDPArr[15].Value = p_objMSVOArr[iRow].m_strOPUNIT_VCHR;
                        objDPArr[16].Value = p_objMSVOArr[iRow].m_strINACCOUNTERID_CHR;
                        objDPArr[17].Value = p_objMSVOArr[iRow].m_strINITIALID_CHR;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.DateTime,DbType.String,DbType.String,
                        DbType.String,DbType.String,DbType.String,DbType.String};

                    object[][] objValues = new object[18][];

                    int intItemCount = p_objMSVOArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }


                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_INITIAL", intItemCount, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        string strSEQ = lngSEQArr[iRow].ToString().PadLeft(4, '0');

                        p_objMSVOArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        p_objMSVOArr[iRow].m_strINITIALID_CHR = strNow + strSEQ;

                        objValues[0][iRow] = p_objMSVOArr[iRow].m_lngSERIESID_INT;
                        objValues[1][iRow] = p_objMSVOArr[iRow].m_strSTORAGEID_CHR;
                        objValues[2][iRow] = p_objMSVOArr[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = p_objMSVOArr[iRow].m_strMEDICINENAME_VCH;
                        objValues[4][iRow] = p_objMSVOArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[5][iRow] = p_objMSVOArr[iRow].m_dblCURRENTGROSS_NUM;
                        objValues[6][iRow] = p_objMSVOArr[iRow].m_dcmRETAILPRICE_INT;
                        objValues[7][iRow] = p_objMSVOArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objValues[8][iRow] = p_objMSVOArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[9][iRow] = p_objMSVOArr[iRow].m_strVENDORID_CHR;
                        objValues[10][iRow] = p_objMSVOArr[iRow].m_strPRODUCTORID_CHR;
                        objValues[11][iRow] = p_objMSVOArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[12][iRow] = p_objMSVOArr[iRow].m_strLOTNO_VCHR;
                        objValues[13][iRow] = p_objMSVOArr[iRow].m_strCREATERID;
                        objValues[14][iRow] = p_objMSVOArr[iRow].m_strEXAMERID;
                        objValues[15][iRow] = p_objMSVOArr[iRow].m_strOPUNIT_VCHR;
                        objValues[16][iRow] = p_objMSVOArr[iRow].m_strINACCOUNTERID_CHR;
                        objValues[17][iRow] = p_objMSVOArr[iRow].m_strINITIALID_CHR;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 修改原始库存
        /// <summary>
        /// 修改原始库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMSVOArr">原始库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyMedicineInitial(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_MedicineInitial_VO[] p_objMSVOArr)
        {
            if (p_objMSVOArr == null || p_objMSVOArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_initial
   set storageid_chr      = ?,
       medicineid_chr     = ?,
       medicinename_vch   = ?,
       medspec_vchr       = ?,
       currentgross_num   = ?,
       retailprice_int    = ?,
       wholesaleprice_int = ?,
       callprice_int      = ?,
       vendorid_chr       = ?,
       productorid_chr    = ?,
       validperiod_dat    = ?,
       lotno_vchr         = ?,
       createrid          = ?,
       examerid           = ?,
       opunit_vchr        = ?
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objMSVOArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(16, out objDPArr);
                        objDPArr[0].Value = p_objMSVOArr[iRow].m_strSTORAGEID_CHR;
                        objDPArr[1].Value = p_objMSVOArr[iRow].m_strMEDICINEID_CHR;
                        objDPArr[2].Value = p_objMSVOArr[iRow].m_strMEDICINENAME_VCH;
                        objDPArr[3].Value = p_objMSVOArr[iRow].m_strMEDSPEC_VCHR;
                        objDPArr[4].Value = p_objMSVOArr[iRow].m_dblCURRENTGROSS_NUM;
                        objDPArr[5].Value = p_objMSVOArr[iRow].m_dcmRETAILPRICE_INT;
                        objDPArr[6].Value = p_objMSVOArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objDPArr[7].Value = p_objMSVOArr[iRow].m_dcmCALLPRICE_INT;
                        objDPArr[8].Value = p_objMSVOArr[iRow].m_strVENDORID_CHR;
                        objDPArr[9].Value = p_objMSVOArr[iRow].m_strPRODUCTORID_CHR;
                        objDPArr[10].DbType = DbType.DateTime;
                        objDPArr[10].Value = p_objMSVOArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objDPArr[11].Value = p_objMSVOArr[iRow].m_strLOTNO_VCHR;
                        objDPArr[12].Value = p_objMSVOArr[iRow].m_strCREATERID;
                        objDPArr[13].Value = p_objMSVOArr[iRow].m_strEXAMERID;
                        objDPArr[14].Value = p_objMSVOArr[iRow].m_strOPUNIT_VCHR;
                        objDPArr[15].Value = p_objMSVOArr[iRow].m_lngSERIESID_INT;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.DateTime,DbType.String,DbType.String,
                        DbType.String,DbType.String,DbType.Int64};

                    object[][] objValues = new object[16][];

                    int intItemCount = p_objMSVOArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objMSVOArr[iRow].m_strSTORAGEID_CHR;
                        objValues[1][iRow] = p_objMSVOArr[iRow].m_strMEDICINEID_CHR;
                        objValues[2][iRow] = p_objMSVOArr[iRow].m_strMEDICINENAME_VCH;
                        objValues[3][iRow] = p_objMSVOArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[4][iRow] = p_objMSVOArr[iRow].m_dblCURRENTGROSS_NUM;
                        objValues[5][iRow] = p_objMSVOArr[iRow].m_dcmRETAILPRICE_INT;
                        objValues[6][iRow] = p_objMSVOArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objValues[7][iRow] = p_objMSVOArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[8][iRow] = p_objMSVOArr[iRow].m_strVENDORID_CHR;
                        objValues[9][iRow] = p_objMSVOArr[iRow].m_strPRODUCTORID_CHR;
                        objValues[10][iRow] = p_objMSVOArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[11][iRow] = p_objMSVOArr[iRow].m_strLOTNO_VCHR;
                        objValues[12][iRow] = p_objMSVOArr[iRow].m_strCREATERID;
                        objValues[13][iRow] = p_objMSVOArr[iRow].m_strEXAMERID;
                        objValues[14][iRow] = p_objMSVOArr[iRow].m_strOPUNIT_VCHR;
                        objValues[15][iRow] = p_objMSVOArr[iRow].m_lngSERIESID_INT;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 删除指定初始库存
        /// <summary>
        /// 删除指定初始库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedicineInitial(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ)
        {
            if (p_lngSEQ <= 0)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"delete from t_ms_initial where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 设置审核者
        /// <summary>
        /// 设置审核者
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQArr">审核药品序列号</param>
        /// <param name="p_strEMPID">审核者ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetCommitUser(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQArr, string p_strEMPID)
        {
            if (p_lngSEQArr == null || p_lngSEQArr.Length == 0 || p_strEMPID == null)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_initial set examerid = ? where seriesid_int = ?";

                 clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;

                    for (int iRow = 0; iRow < p_lngSEQArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_strEMPID;
                        objDPArr[1].Value = p_lngSEQArr[iRow];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String,DbType.Int64};

                    object[][] objValues = new object[2][];

                    int intItemCount = p_lngSEQArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEMPID;
                        objValues[1][iRow] = p_lngSEQArr[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 设置入帐者

        /// <summary>
        /// 设置入帐者
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strIniIDArr">审核药品序列号</param>
        /// <param name="p_strEMPID">审核者ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccoutnUser(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strIniIDArr, string p_strEMPID, string p_strStorageID)
        {
            if (p_strIniIDArr == null || p_strIniIDArr.Length == 0 || string.IsNullOrEmpty(p_strEMPID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_initial set inaccounterid_chr = ? where initialid_chr = ? and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;

                    for (int iRow = 0; iRow < p_strIniIDArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_strEMPID;
                        objDPArr[1].Value = p_strIniIDArr[iRow];
                        objDPArr[2].Value = p_strStorageID;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_strIniIDArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEMPID;
                        objValues[1][iRow] = p_strIniIDArr[iRow];
                        objValues[2][iRow] = p_strStorageID;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 保存药品
        /// <summary>
        /// 保存药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objNew">新添的药品</param>
        /// <param name="p_objModify">修改的药品</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveMedicineInfo(System.Security.Principal.IPrincipal p_objPrincipal,ref clsMS_MedicineInitial_VO[] p_objNew, clsMS_MedicineInitial_VO[] p_objModify)
        {
            if ((p_objNew == null || p_objNew.Length == 0) && (p_objModify == null || p_objModify.Length == 0))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                if (p_objNew != null && p_objNew.Length > 0)
                {
                    lngRes = m_lngAddNewMedicineInitial(p_objPrincipal, ref p_objNew);

                    if (lngRes <= 0)
                    {
                        return -1;
                    }
                }

                if (p_objModify != null && p_objModify.Length > 0)
                {
                    lngRes = m_lngModifyMedicineInitial(p_objPrincipal, p_objModify);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
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

        #region 审核药品
        /// <summary>
        /// 审核药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailArr">库存明细</param>
        /// <param name="p_objStorageArr">库存主表内容</param>
        /// <param name="p_lngSEQArr">审核行序列</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommitMedicineInfo(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail[] p_objDetailArr, clsMS_Storage[] p_objStorageArr, long[] p_lngSEQArr, string p_strEmpID, bool p_blnIsImmAccount)
        {
            if (p_objDetailArr == null || p_objDetailArr.Length == 0 || p_objStorageArr == null || p_objStorageArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                clsStorageSVC objStSVC = new clsStorageSVC();

                lngRes = objStSVC.m_lngAddNewStorageDetail(p_objPrincipal, p_objDetailArr);
                if (lngRes <= 0)
                {
                    return -1;
                }

                System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                bool blnHasDetail = false;//是否已存在
                for (int iRow = 0; iRow < p_objStorageArr.Length; iRow++)
                {
                    if (!hstMedicine.Contains(p_objStorageArr[iRow].m_strMEDICINEID_CHR))
                    {
                        long lngCurrentSeriesID = 0;
                        //检查库存主表是否已存在该药
                        lngRes = objStSVC.m_lngCheckHasStorage(p_objPrincipal, p_objStorageArr[iRow].m_strMEDICINEID_CHR, p_objStorageArr[iRow].m_strSTORAGEID_CHR, out blnHasDetail, out lngCurrentSeriesID);

                        if (blnHasDetail)
                        {
                            //库存主表添加库存
                            lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, p_objStorageArr[iRow], lngCurrentSeriesID);
                            if (lngRes <= 0)
                            {
                                throw new Exception("库存主表添加库存失败1");
                            }
                        }
                        else
                        {
                            //库存主表新增药品
                            lngRes = objStSVC.m_lngAddNewStorage(p_objPrincipal, ref p_objStorageArr[iRow]);
                            if (lngRes <= 0)
                            {
                                throw new Exception("库存主表新增药品失败");
                            }
                            hstMedicine.Add(p_objStorageArr[iRow].m_strMEDICINEID_CHR, p_objStorageArr[iRow].m_lngSERIESID_INT);
                        }
                    }
                    else
                    {
                        //向库存主表添加库存
                        lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, p_objStorageArr[iRow], Convert.ToInt64(hstMedicine[p_objStorageArr[iRow].m_strMEDICINEID_CHR]));
                        if (lngRes <= 0)
                        {
                            throw new Exception("库存主表添加库存失败2");
                        }
                    }
                }
                hstMedicine = null;

                System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                for (int iRow = 0; iRow < p_objStorageArr.Length; iRow++)
                {
                    if (!hstStastic.Contains(p_objStorageArr[iRow].m_strMEDICINEID_CHR))
                    {
                        hstStastic.Add(p_objStorageArr[iRow].m_strMEDICINEID_CHR, p_objStorageArr[iRow].m_lngSERIESID_INT);
                        //统计库存主表药品价格
                        lngRes = objStSVC.m_lngStatisticsStorage(p_objPrincipal, p_objStorageArr[iRow].m_strMEDICINEID_CHR, p_objStorageArr[iRow].m_strSTORAGEID_CHR);
                        if (lngRes <= 0)
                        {
                            throw new Exception("统计库存主表药品价格失败");
                        }
                    }
                }
                hstStastic = null;
                p_objStorageArr = null;
                objStSVC = null;

                lngRes = m_lngSetCommitUser(p_objPrincipal, p_lngSEQArr, p_strEmpID);
                if (lngRes <= 0)
                {
                    throw new Exception("设置审核者失败");
                }

                #region 操作帐本明细表
                DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[p_objDetailArr.Length];
                int intAccState = p_blnIsImmAccount ? 1 : 2;//入帐明细状态
                DateTime dtmInDate = p_blnIsImmAccount ? dtmNow : DateTime.MinValue;//入账日期
                string strInEmp = p_blnIsImmAccount ? p_strEmpID : string.Empty;//入账人


                for (int iAcc = 0; iAcc < p_objDetailArr.Length; iAcc++)
                {
                    objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                    objAccArr[iAcc].m_dblAMOUNT_INT = p_objDetailArr[iAcc].m_dblREALGROSS_INT;
                    objAccArr[iAcc].m_dblCALLPRICE_INT = (double)p_objDetailArr[iAcc].m_dcmCALLPRICE_INT;
                    objAccArr[iAcc].m_dblOLDGROSS_INT = 0;
                    objAccArr[iAcc].m_dblRETAILPRICE_INT = (double)p_objDetailArr[iAcc].m_dcmRETAILPRICE_INT;
                    objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = (double)p_objDetailArr[iAcc].m_dcmWHOLESALEPRICE_INT;
                    objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                    objAccArr[iAcc].m_intFORMTYPE_INT = 0;
                    objAccArr[iAcc].m_intISEND_INT = 0;
                    objAccArr[iAcc].m_intSTATE_INT = intAccState;
                    objAccArr[iAcc].m_intTYPE_INT = 1;
                    objAccArr[iAcc].m_strCHITTYID_VCHR = p_objDetailArr[iAcc].m_strINSTORAGEID_VCHR;
                    objAccArr[iAcc].m_strDEPTID_CHR = p_objDetailArr[iAcc].m_strVENDORID_CHR;
                    objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                    objAccArr[iAcc].m_strINSTORAGEID_VCHR = p_objDetailArr[iAcc].m_strINSTORAGEID_VCHR;
                    objAccArr[iAcc].m_strLOTNO_VCHR = p_objDetailArr[iAcc].m_strLOTNO_VCHR;
                    objAccArr[iAcc].m_strMEDICINEID_CHR = p_objDetailArr[iAcc].m_strMEDICINEID_CHR;
                    objAccArr[iAcc].m_strMEDICINENAME_VCH = p_objDetailArr[iAcc].m_strMEDICINENAME_VCHR;
                    objAccArr[iAcc].m_strMEDICINETYPEID_CHR = p_objDetailArr[iAcc].m_strMEDICINETYPEID_CHR;
                    objAccArr[iAcc].m_strMEDSPEC_VCHR = p_objDetailArr[iAcc].m_strMEDSPEC_VCHR;
                    objAccArr[iAcc].m_strOPUNIT_CHR = p_objDetailArr[iAcc].m_strOPUNIT_VCHR;
                    objAccArr[iAcc].m_strSTORAGEID_CHR = p_objDetailArr[iAcc].m_strSTORAGEID_CHR;
                    objAccArr[iAcc].m_dtmOperateDate = dtmNow;
                }

                clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();
                lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccArr);
                if (lngRes <= 0)
                {
                    throw new Exception();
                }
                objAcSVC = null;
                #endregion

                if (p_blnIsImmAccount)
                {
                    lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_lngSEQArr);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
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

        #region 设置入帐者
        /// <summary>
        /// 设置入帐者
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, long[] p_lngSeq)
        {
            if (p_lngSeq == null || p_lngSeq.Length == 0 || string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_initial set inaccounterid_chr = ? where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_lngSeq.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_strEmpID;
                        objDPArr[1].Value = p_lngSeq[iRow];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String,  DbType.Int64 };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_lngSeq.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = p_lngSeq[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQArr">入帐记录序列</param>
        /// <param name="p_strInitialID">入帐ID</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInAccount(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQArr, string[] p_strInitialID, string p_strEmpID, string p_strStorageID)
        {
            if (p_lngSEQArr == null || p_lngSEQArr.Length == 0 || p_strInitialID == null || p_strInitialID.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_lngSEQArr);
                if (lngRes <= 0)
                {
                    return -1;
                }

                DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                lngRes = objAccSVC.m_lngRatifyAccountDetail(p_objPrincipal, p_strInitialID, p_strStorageID, p_strEmpID, dtmNow);
                if (lngRes <= 0)
                {
                    throw new Exception();
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

        #region 退审
        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列</param>
        /// <param name="p_strInitialID">序列</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_dblInAmount">入库数量</param>
        /// <param name="p_strVendorID">供应商</param>
        /// <param name="p_dcmCallPrice">购入价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUnCommit(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, string p_strInitialID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, double p_dblInAmount,string p_strVendorID, decimal p_dcmCallPrice)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"delete from t_ms_storage_detail t
 where t.medicineid_chr = ?
   and t.lotno_vchr = ?
   and t.instorageid_vchr = ?
   and t.storageid_chr = ?
   and t.status = 1
   and t.realgross_int = ?
   and t.availagross_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(6, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strLotNO;
                objDPArr[2].Value = p_strInitialID;
                objDPArr[3].Value = p_strStorageID;
                objDPArr[4].Value = p_dblInAmount;
                objDPArr[5].Value = p_dblInAmount;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngEff <= 0)
                {
                    return -1;
                }

                clsMS_Storage objSt = new clsMS_Storage();
                objSt.m_strMEDICINEID_CHR = p_strMedicineID;
                objSt.m_strSTORAGEID_CHR = p_strStorageID;
                objSt.m_dblCURRENTGROSS_NUM = p_dblInAmount;
                objSt.m_dblINSTOREGROSS_INT = p_dblInAmount;
                objSt.m_strVENDORID_CHR = p_strVendorID;
                objSt.m_dcmCALLPRICE_INT = p_dcmCallPrice;

                clsStorageSVC objStSVC = new clsStorageSVC();
                lngRes = objStSVC.m_lngSubStorageGross(p_objPrincipal, objSt);
                if (lngRes <= 0)
                {
                    throw new Exception();
                }

                strSQL = @"delete from t_ms_account_detail t
 where t.medicineid_chr = ?
   and t.lotno_vchr = ?
   and t.instorageid_vchr = ?
   and t.storageid_chr = ?
   and t.chittyid_vchr = ?";

                objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strLotNO;
                objDPArr[2].Value = p_strInitialID;
                objDPArr[3].Value = p_strStorageID;
                objDPArr[4].Value = p_strInitialID;
    
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngEff <= 0)
                {
                    throw new Exception();
                }

                long[] lngSeq = new long[]{p_lngSEQ};
                lngRes = m_lngSetCommitUser(p_objPrincipal, lngSeq, string.Empty);
                if (lngRes <= 0)
                {
                    throw new Exception();
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
    }
}
