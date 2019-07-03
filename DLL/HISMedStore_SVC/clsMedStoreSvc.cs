using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections.Generic;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房业务操作
    /// Create by kong 2004-07-07
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsMedStoreSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsMedStoreSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 药房进出药

        #region 新系统

        #region 获得药品基本信息
        /// <summary>
        /// 获得药品基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtbMedicine"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMedicine(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbMedicine)
        {
            dtbMedicine = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetAllMedicine");
            string strSQL = @"select b.MEDICINEID_CHR,b.ASSISTCODE_CHR,b.MEDICINENAME_VCHR,b.MEDSPEC_VCHR,b.IPUNIT_CHR,b.UNITPRICE_MNY,b.PYCODE_CHR,b.WBCODE_CHR,b.PACKQTY_DEC from t_bse_medicine b  order by b.ASSISTCODE_CHR";
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbMedicine);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据药房获得有库存的药品
        /// <summary>
        /// 根据药房获得有库存的药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtbMedicine"></param>
        /// <param name="strStorageID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineByID(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbMedicine, string strStorageID)
        {
            dtbMedicine = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetAllMedicine");
            string strSQL = @"select a.*,b.ASSISTCODE_CHR,b.MEDICINENAME_VCHR,b.MEDSPEC_VCHR,b.IPUNIT_CHR,b.UNITPRICE_MNY,b.PYCODE_CHR,b.WBCODE_CHR,b.PACKQTY_DEC from t_tol_medstoremedicine a, t_bse_medicine b where a.MEDICINEID_CHR=b.MEDICINEID_CHR and a.AMOUNT_DEC>0 and MEDSTOREID_CHR='" + strStorageID + "' order by b.ASSISTCODE_CHR";
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbMedicine);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region  获得药房入库类型、药房信息
        /// <summary>
        /// 获得药房入库类型、药房信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strTypeName">出入库类型名称</param>
        /// <param name="intSIGN_INT">出入标志，2-出库,1-入库,3-调拔</param>
        /// <param name="StorageName">药房名称</param>
        ///  <param name="strTypeID">入库类型ID</param>
        ///  <param name="storageID">药房ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTypeAndStorage(System.Security.Principal.IPrincipal p_objPrincipal, string strTypeID, string storageID, out string strTypeName, out int intSIGN_INT, out string StorageName)
        {
            long lngRes = 0;
            strTypeName = "";
            StorageName = "";
            intSIGN_INT = -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngGetTypeAndStorage");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            string strSQL = @"select MEDSTOREORDTYPE_VCHR,SIGN_INT from t_aid_medstoreordtype where MEDSTOREORDTYPEID_CHR='" + strTypeID + "'";
            DataTable dt = new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dt.Rows.Count > 0)
            {
                strTypeName = dt.Rows[0]["MEDSTOREORDTYPE_VCHR"].ToString().Trim();
                if (dt.Rows[0]["SIGN_INT"].ToString() != "")
                    intSIGN_INT = Convert.ToInt16(dt.Rows[0]["SIGN_INT"]);
            }
            strSQL = @"select MEDSTORENAME_VCHR from t_bse_medstore where MEDSTORETYPE_INT=1 and MEDSTOREID_CHR='" + storageID + "'";
            DataTable dtbStorage = new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbStorage);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dtbStorage.Rows.Count > 0)
            {
                StorageName = dtbStorage.Rows[0]["MEDSTORENAME_VCHR"].ToString();
            }
            return lngRes;

        }
        #endregion

        #region 查找所有的入库单
        /// <summary>
        /// 查找所有的入库单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strTypeID"></param>
        /// <param name="dtbResult"></param>
        /// <param name="nowPriod"></param>
        /// <param name="strStorageID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrd(System.Security.Principal.IPrincipal p_objPrincipal, string strTypeID, out DataTable dtbResult, string nowPriod, string strStorageID, string strOUTFLAN)
        {
            long lngRes = 0;
            dtbResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrd");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            if (nowPriod != "")
                strSQL = @"SELECT a.MEDSTOREORDID_CHR,a.MEDSTOREID_CHR,a.STORERDOCNO_CHR,a.ORDDATE_DAT,a.TOLMNY_MNY,a.MEMO_VCHR,a.CREATOR_CHR," +
                    "a.CREATEDATE_DAT,a.ADUITEMP_CHR,a.ADUITDATE_DAT,case when SRCTYPE_INT=3 or SRCTYPE_INT=4 then a.SRCID_CHR when SRCTYPE_INT<3 then ''  end as SRCID_CHR,a.MEDSTOREORDTYPEID_CHR,a.PSTATUS_INT,a.PERIODID_CHR, b.MEDSTORENAME_VCHR ,"
                    + "c.LASTNAME_VCHR as CREATORNAME,d.LASTNAME_VCHR as ADUITEMPNAME,e.MEDSTOREORDTYPE_VCHR,case when SRCTYPE_INT=3 then (select STORAGENAME_VCHR from T_BSE_STORAGE where a.SRCID_CHR=STORAGEID_CHR )when SRCTYPE_INT=4 then (select  MEDSTORENAME_VCHR from t_bse_medstore where a.SRCID_CHR=MEDSTOREID_CHR) end as STORAGENAME_VCHR  FROM t_opr_medstoreord a,"
                    + "t_bse_medstore b,t_bse_employee c,t_bse_employee d,t_aid_medstoreordtype e  where a.MEDSTOREID_CHR=b.MEDSTOREID_CHR(+) and a.CREATOR_CHR=c.EMPID_CHR(+) and a.ADUITEMP_CHR=d.EMPID_CHR(+) AND a.MEDSTOREORDTYPEID_CHR=e.MEDSTOREORDTYPEID_CHR(+) and a.MEDSTOREORDTYPEID_CHR='" + strTypeID + "' and a.MEDSTOREID_CHR='" + strStorageID + "' and a.OUTFLAN_INT=" + strOUTFLAN + " and  a.PERIODID_CHR='" + nowPriod + "'";
            else
                strSQL = @"SELECT a.MEDSTOREORDID_CHR,a.MEDSTOREID_CHR,a.STORERDOCNO_CHR,a.ORDDATE_DAT,a.TOLMNY_MNY,a.MEMO_VCHR,a.CREATOR_CHR," +
                    "a.CREATEDATE_DAT,a.ADUITEMP_CHR,a.ADUITDATE_DAT,case when SRCTYPE_INT=3 or SRCTYPE_INT=4 then a.SRCID_CHR when SRCTYPE_INT<3 then ''  end as SRCID_CHR,a.MEDSTOREORDTYPEID_CHR,a.PSTATUS_INT,a.PERIODID_CHR, b.MEDSTORENAME_VCHR ,"
                    + "c.LASTNAME_VCHR as CREATORNAME,d.LASTNAME_VCHR as ADUITEMPNAME,e.MEDSTOREORDTYPE_VCHR,case when SRCTYPE_INT=3 then (select STORAGENAME_VCHR from T_BSE_STORAGE where a.SRCID_CHR=STORAGEID_CHR) when SRCTYPE_INT=4 then (select  MEDSTORENAME_VCHR from t_bse_medstore where a.SRCID_CHR=MEDSTOREID_CHR) end as STORAGENAME_VCHR  FROM t_opr_medstoreord a,"
                    + "t_bse_medstore b,t_bse_employee c,t_bse_employee d,t_aid_medstoreordtype e  where a.MEDSTOREID_CHR=b.MEDSTOREID_CHR(+) and a.CREATOR_CHR=c.EMPID_CHR(+) and a.ADUITEMP_CHR=d.EMPID_CHR(+) AND a.MEDSTOREORDTYPEID_CHR=e.MEDSTOREORDTYPEID_CHR(+) and a.MEDSTOREORDTYPEID_CHR='" + strTypeID + "' and a.MEDSTOREID_CHR='" + strStorageID + "' and a.OUTFLAN_INT=" + strOUTFLAN;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获得药房信息
        /// <summary>
        /// 获得药房信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="StoreID"></param>
        /// <param name="StoreName"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreName(System.Security.Principal.IPrincipal p_objPrincipal, string StoreID, out string StoreName)
        {
            long lngRes = 0;
            StoreName = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreName");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT MEDSTORENAME_VCHR
							    FROM t_bse_medstore where MEDSTOREID_CHR='" + StoreID + "'";
            DataTable dt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dt.Rows.Count > 0)
            {
                StoreName = dt.Rows[0]["MEDSTORENAME_VCHR"].ToString();
            }
            return lngRes;
        }
        #endregion

        #region 获得药房信息
        /// <summary>
        /// 获得药房信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStore(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStore");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT MEDSTOREID_CHR, MEDSTORENAME_VCHR
							    FROM t_bse_medstore";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获得药库信息
        /// <summary>
        /// 获得药库信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtStore"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStore(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtStore)
        {
            long lngRes = 0;
            dtStore = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetStore");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT STORAGEID_CHR,STORAGENAME_VCHR
							    FROM T_BSE_STORAGE";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtStore);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region  获得药房最大的源单据号
        /// <summary>
        ///  获得药房最大的源单据号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="ScrNO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetScrNO(System.Security.Principal.IPrincipal p_objPrincipal, out string ScrNO)
        {
            long lngRes = 0;
            ScrNO = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetScrNO");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT max(STORERDOCNO_CHR)
							    FROM T_OPR_MEDSTOREORD";
            DataTable dt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dt.Rows.Count > 0)
            {
                ScrNO = dt.Rows[0][0].ToString();
            }
            return lngRes;
        }


        #endregion

        #region 按药房进出药记录单ID查询药房进出药明细单
        /// <summary>
        /// 按药房进出药记录单ID查询药房进出药明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">记录单ID</param>
        /// <param name="p_dtbResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoreOrdDeByOrdID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out DataTable p_dtbResultArr, bool blCenter, string storageID)
        {
            long lngRes = 0;
            p_dtbResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetStoreOrdDeByOrdID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            if (blCenter == true)
            {
                strSQL = @" select a.MEDSTOREORDDEID_CHR,a.MEDICINEID_CHR,a.ROWNO_CHR,a.QTY_DEC,a.SALEUNITPRICE_DEC,a.SALETOLPRICE_DEC," +
                    "a.UNITID_CHR,a.USEFULLIFE_DAT,a.SYSLOTNO_CHR,a.MEDNO_CHR,b.ASSISTCODE_CHR,b.MEDICINENAME_VCHR,b.MEDSPEC_VCHR,b.PRODUCTORID_CHR,c.AMOUNT_DEC  from t_opr_medstoreordde a left join T_BSE_STORAGEMEDICINE c on c.MEDICINEID_CHR=a.MEDICINEID_CHR and c.STORAGEID_CHR='" + storageID + "' and c.FLAG_INT=1,t_bse_medicine b  where a.MEDICINEID_CHR=b.MEDICINEID_CHR and a.MEDSTOREORDID_CHR='" + p_strID + "' order by ROWNO_CHR";
            }
            else
            {
                strSQL = @" select a.MEDSTOREORDDEID_CHR,a.MEDICINEID_CHR,a.ROWNO_CHR,a.QTY_DEC,a.SALEUNITPRICE_DEC,a.SALETOLPRICE_DEC," +
                    "a.UNITID_CHR,a.USEFULLIFE_DAT,a.SYSLOTNO_CHR,a.MEDNO_CHR,b.ASSISTCODE_CHR,b.MEDICINENAME_VCHR,b.MEDSPEC_VCHR,b.PRODUCTORID_CHR,c.CURQTY_DEC as AMOUNT_DEC  from t_opr_medstoreordde a left join T_OPR_STORAGEMEDDETAIL c on  c.MEDICINEID_CHR=a.MEDICINEID_CHR and c.SYSLOTNO_CHR=a.SYSLOTNO_CHR and c.STORAGEID_CHR='" + storageID + "' and c.FLAG_INT=1,t_bse_medicine b where a.MEDICINEID_CHR=b.MEDICINEID_CHR and a.MEDSTOREORDID_CHR='" + p_strID + "' order by ROWNO_CHR";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref p_dtbResultArr);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 保存出入库单
        /// <summary>
        /// 保存出入库单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="DtrStorage"></param>
        /// <param name="dtbStorageDe"></param>
        /// <param name="newid"></param>
        ///  <param name="intSIGN_INT">出入标志，2-出库,1-入库,3-调拔入库，4调拔出库</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSave(System.Security.Principal.IPrincipal p_objPrincipal, DataRow DtrStorage, DataTable dtbStorageDe, out string newid, int intSIGN_INT)
        {
            long lngRes = 0;
            newid = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngSave");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            objHRPSvc.m_lngGenerateNewID("t_opr_medstoreord", "MEDSTOREORDID_CHR", out newid);
            string strSQL = "";
            string strSign = "";
            string strSrc = "";
            switch (intSIGN_INT)
            {
                case 1:
                    strSign = "1";
                    strSrc = "3";
                    break;
                case 2:
                    strSign = "2";
                    strSrc = "3";
                    break;
                case 3:
                    strSign = "1";
                    strSrc = "4";
                    break;
                case 4:
                    strSign = "2";
                    strSrc = "4";
                    break;
            }

            strSQL = @"insert into t_opr_medstoreord(MEDSTOREORDID_CHR,MEDSTOREID_CHR,ORDDATE_DAT,TOLMNY_MNY,MEMO_VCHR,CREATOR_CHR," +
                "CREATEDATE_DAT,MEDSTOREORDTYPEID_CHR,PSTATUS_INT,OUTFLAN_INT,PERIODID_CHR,SRCID_CHR,SRCTYPE_INT,STORERDOCNO_CHR) values('" + newid + "','"
                + DtrStorage["MEDSTOREID_CHR"].ToString().Trim() + "',To_Date('" + DtrStorage["ORDDATE_DAT"].ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss')," + DtrStorage["TOLMNY_MNY"].ToString().Trim() + ",'" + DtrStorage["MEMO_VCHR"].ToString().Trim() + "','"
                + DtrStorage["CREATOR_CHR"].ToString().Trim() + "',sysdate,'"
                + DtrStorage["MEDSTOREORDTYPEID_CHR"].ToString().Trim() + "',1," + strSign + ",'" + DtrStorage["PERIODID_CHR"].ToString().Trim() + "','" + DtrStorage["SRCID_CHR"].ToString() + "'," + strSrc + ",'" + DtrStorage["STORERDOCNO_CHR"].ToString().Trim() + "')";
            try
            {
                lngRes = objHRPSvc.DoExcute(strSQL);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtbStorageDe.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtbStorageDe.Rows.Count; i1++)
                {
                    string newDeid = "";
                    objHRPSvc.m_lngGenerateNewID("t_opr_medstoreordde", "MEDSTOREORDDEID_CHR", out newDeid);
                    strSQL = @"insert into t_opr_medstoreordde(MEDSTOREORDDEID_CHR,MEDSTOREORDID_CHR,MEDICINEID_CHR,ROWNO_CHR,QTY_DEC,SALEUNITPRICE_DEC,SALETOLPRICE_DEC,UNITID_CHR,USEFULLIFE_DAT,MEDNO_CHR,SYSLOTNO_CHR)"
                            + " values('" + newDeid + "','" + newid + "','" + dtbStorageDe.Rows[i1]["MEDICINEID_CHR"].ToString().Trim() + "','"
                            + dtbStorageDe.Rows[i1]["ROWNO_CHR"].ToString().Trim() + "'," + dtbStorageDe.Rows[i1]["QTY_DEC"].ToString().Trim() + "," + dtbStorageDe.Rows[i1]["SALEUNITPRICE_DEC"].ToString().Trim() + ","
                            + dtbStorageDe.Rows[i1]["SALETOLPRICE_DEC"].ToString().Trim() + ",'" + dtbStorageDe.Rows[i1]["UNITID_CHR"].ToString().Trim() + "',To_Date('" + dtbStorageDe.Rows[i1]["USEFULLIFE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'" + dtbStorageDe.Rows[i1]["MEDNO_CHR"].ToString().Trim() + "','" + dtbStorageDe.Rows[i1]["SYSLOTNO_CHR"].ToString().Trim() + "')";
                    try
                    {
                        lngRes = objHRPSvc.DoExcute(strSQL);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 保存出库单
        /// <summary>
        /// 保存出库单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="DtrStorage"></param>
        /// <param name="dtbStorageDe"></param>
        /// <param name="newid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveOut(System.Security.Principal.IPrincipal p_objPrincipal, DataRow DtrStorage, DataTable dtbStorageDe, out string newid)
        {
            long lngRes = 0;
            newid = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngSave");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            newid = objHRPSvc.m_strGetNewID("t_opr_medstoreord", "MEDSTOREORDID_CHR", 18);
            string strSQL = @"insert into t_opr_medstoreord(MEDSTOREORDID_CHR,MEDSTOREID_CHR,ORDDATE_DAT,TOLMNY_MNY,MEMO_VCHR,CREATOR_CHR," +
                "CREATEDATE_DAT,MEDSTOREORDTYPEID_CHR,PSTATUS_INT,OUTFLAN_INT,PERIODID_CHR) values('" + newid + "','"
                + DtrStorage["MEDSTOREID_CHR"].ToString() + "',To_Date('" + DtrStorage["ORDDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss')," + DtrStorage["TOLMNY_MNY"].ToString() + ",'" + DtrStorage["MEMO_VCHR"].ToString() + "','"
                + DtrStorage["CREATOR_CHR"].ToString() + "',To_Date('" + DtrStorage["CREATEDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'"
                + DtrStorage["MEDSTOREORDTYPEID_CHR"].ToString() + "',1,2,'" + DtrStorage["PERIODID_CHR"].ToString() + "')";
            try
            {
                lngRes = objHRPSvc.DoExcute(strSQL);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtbStorageDe.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtbStorageDe.Rows.Count; i1++)
                {
                    string newDeid = objHRPSvc.m_strGetNewID("t_opr_medstoreordde", "MEDSTOREORDDEID_CHR", 18);
                    strSQL = @"insert into t_opr_medstoreordde(MEDSTOREORDDEID_CHR,MEDSTOREORDID_CHR,MEDICINEID_CHR,SYSLOTNO_CHR,ROWNO_CHR,QTY_DEC,SALEUNITPRICE_DEC,SALETOLPRICE_DEC,UNITID_CHR)"
                        + " values('" + newDeid + "','" + newid + "','" + dtbStorageDe.Rows[i1]["MEDICINEID_CHR"].ToString() + "','" + dtbStorageDe.Rows[i1]["SYSLOTNO_CHR"].ToString() + "','"
                        + dtbStorageDe.Rows[i1]["ROWNO_CHR"].ToString() + "'," + dtbStorageDe.Rows[i1]["QTY_DEC"].ToString() + "," + dtbStorageDe.Rows[i1]["SALEUNITPRICE_DEC"].ToString() + ","
                        + dtbStorageDe.Rows[i1]["SALETOLPRICE_DEC"].ToString() + ",'" + dtbStorageDe.Rows[i1]["UNITID_CHR"].ToString() + "')";
                    try
                    {
                        lngRes = objHRPSvc.DoExcute(strSQL);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 增加明细
        /// <summary>
        /// 增加明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strOrdID">单据号ID</param>
        /// <param name="tolMoney">单据的总金额</param>
        /// <param name="ModifiyMoney">返回增加后的单据总金额</param>
        /// <param name="dtbStorageDe">明细数据</param>
        /// <param name="strOrdDeID">返回新增的明细ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewDe(System.Security.Principal.IPrincipal p_objPrincipal, string strOrdID, double tolMoney, DataRow dtbStorageDe, out string strOrdDeID, out double ModifiyMoney)
        {
            ModifiyMoney = 0;
            long lngRes = 0;
            strOrdDeID = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngSave");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            objHRPSvc.m_lngGenerateNewID("t_opr_medstoreordde", "MEDSTOREORDDEID_CHR", out strOrdDeID);
            string strSQL = @"insert into t_opr_medstoreordde(MEDSTOREORDDEID_CHR,MEDSTOREORDID_CHR,MEDICINEID_CHR,ROWNO_CHR,QTY_DEC,SALEUNITPRICE_DEC,SALETOLPRICE_DEC,UNITID_CHR,USEFULLIFE_DAT,MEDNO_CHR)"
                + " values('" + strOrdDeID + "','" + strOrdID + "','" + dtbStorageDe["MEDICINEID_CHR"].ToString() + "','"
                + dtbStorageDe["ROWNO_CHR"].ToString() + "'," + dtbStorageDe["QTY_DEC"].ToString() + "," + dtbStorageDe["SALEUNITPRICE_DEC"].ToString() + ","
                + dtbStorageDe["SALETOLPRICE_DEC"].ToString() + ",'" + dtbStorageDe["UNITID_CHR"].ToString() + "',To_Date('" + dtbStorageDe["USEFULLIFE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'" + dtbStorageDe["MEDNO_CHR"].ToString() + "')";
            try
            {
                lngRes = objHRPSvc.DoExcute(strSQL);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                ModifiyMoney = tolMoney + Convert.ToDouble(dtbStorageDe["SALETOLPRICE_DEC"]);
                strSQL = @"update t_opr_medstoreord set TOLMNY_MNY=" + ModifiyMoney + "where MEDSTOREORDID_CHR='" + strOrdID + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }

        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strID">入库单ID</param>
        /// <param name="strDeID">入库单明细ID,不为null只删除明细数据</param>
        /// <param name="TolMoney">单据总金额</param>
        /// <param name="DelDeMoney">要删除明细数据的金额</param>
        [AutoComplete]
        public long m_lngDelete(System.Security.Principal.IPrincipal p_objPrincipal, string strID, string strDeID, double TolMoney, double DelDeMoney)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngDelete");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            if (strDeID != null)
            {
                strSQL = @"Delete t_opr_medstoreordde where MEDSTOREORDDEID_CHR='" + strDeID + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (lngRes > 0)
                {
                    TolMoney = TolMoney - DelDeMoney;
                    strSQL = @"update t_opr_medstoreord set TOLMNY_MNY=" + TolMoney + " where MEDSTOREORDID_CHR='" + strID + "'";
                }
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            else
            {
                strSQL = @"Delete t_opr_medstoreordde where MEDSTOREORDID_CHR='" + strID + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (lngRes > 0)
                {
                    strSQL = @"Delete t_opr_medstoreord where MEDSTOREORDID_CHR='" + strID + "'";
                    try
                    {
                        lngRes = objHRPSvc.DoExcute(strSQL);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 修改数据
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="UpOrdDe">明细数据行，如为null不用修改</param>
        /// <param name="UpOrd">入库单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifiy(System.Security.Principal.IPrincipal p_objPrincipal, DataRow UpOrdDe, DataRow UpOrd)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngModifiy");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            if (UpOrdDe == null)
            {
                strSQL = @"update t_opr_medstoreord set MEDSTOREID_CHR='" + UpOrd["MEDSTOREID_CHR"].ToString() + "',ORDDATE_DAT=To_Date('" + UpOrd["ORDDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),MEMO_VCHR='" + UpOrd["MEMO_VCHR"].ToString() + "',MEDSTOREORDTYPEID_CHR='" + UpOrd["MEDSTOREORDTYPEID_CHR"].ToString() + "',TOLMNY_MNY=" + UpOrd["TOLMNY_MNY"].ToString() + " ,SRCID_CHR='" + UpOrd["SRCID_CHR"].ToString() + "',STORERDOCNO_CHR='" + UpOrd["STORERDOCNO_CHR"].ToString() + "' where MEDSTOREORDID_CHR='" + UpOrd["MEDSTOREORDID_CHR"].ToString() + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                strSQL = @"update t_opr_medstoreord set MEDSTOREID_CHR='" + UpOrd["MEDSTOREID_CHR"].ToString() + "',ORDDATE_DAT=To_Date('" + UpOrd["ORDDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),MEMO_VCHR='" + UpOrd["MEMO_VCHR"].ToString() + "',MEDSTOREORDTYPEID_CHR='" + UpOrd["MEDSTOREORDTYPEID_CHR"].ToString() + "',TOLMNY_MNY=" + UpOrd["TOLMNY_MNY"].ToString() + " ,SRCID_CHR='" + UpOrd["SRCID_CHR"].ToString() + "',STORERDOCNO_CHR='" + UpOrd["STORERDOCNO_CHR"].ToString() + "'  where MEDSTOREORDID_CHR='" + UpOrd["MEDSTOREORDID_CHR"].ToString() + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (lngRes > 0)
                {
                    strSQL = @"update t_opr_medstoreordde set MEDICINEID_CHR='" + UpOrdDe["MEDICINEID_CHR"].ToString() + "',MEDNO_CHR='" + UpOrdDe["MEDNO_CHR"].ToString() + "',QTY_DEC=" + UpOrdDe["QTY_DEC"].ToString() + ",SALEUNITPRICE_DEC=" + UpOrdDe["SALEUNITPRICE_DEC"].ToString() + ",SALETOLPRICE_DEC=" + UpOrdDe["SALETOLPRICE_DEC"].ToString() + ",UNITID_CHR='" + UpOrdDe["UNITID_CHR"].ToString() + "',USEFULLIFE_DAT=to_date('" + UpOrdDe["USEFULLIFE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss') where MEDSTOREORDDEID_CHR='" + UpOrdDe["MEDSTOREORDDEID_CHR"].ToString() + "'";
                    try
                    {
                        lngRes = objHRPSvc.DoExcute(strSQL);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }

            }
            return lngRes;

        }
        #endregion

        #region 检查相应的单据号是否存在
        /// <summary>
        /// 检查相应的单据号是否存在
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="ordTypeName"></param>
        /// <param name="ordTypeID"></param>
        /// <param name="intFlan">0-药房，1-药库</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrdTypeID(System.Security.Principal.IPrincipal p_objPrincipal, out string ordTypeID, int intFlan)
        {
            long lngRes = 0;
            ordTypeID = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetOrdTypeID");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            string strSQL = "";
            if (intFlan == 0)
                strSQL = @"SELECT MEDSTOREORDTYPEID_CHR
								FROM t_aid_medstoreordtype where trim(MEDSTORAGE_INT)=0";
            else
                strSQL = @"SELECT STORAGEORDTYPEID_CHR as MEDSTOREORDTYPEID_CHR
								FROM T_AID_STORAGEORDTYPE  where trim(MEDSTORAGE_INT)=1";
            DataTable dt = new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                ordTypeID = dt.Rows[0]["MEDSTOREORDTYPEID_CHR"].ToString();

            }
            return lngRes;
        }
        #endregion

        #region 审核功能
        /// <summary>
        /// 审核功能
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="stroageID">药库ID</param>
        /// <param name="GrearName">审核人ID</param>
        /// <param name="strID">单号ID</param>
        /// <param name="OrdDeTable">入库单明细</param>
        /// <param name="intFlan">出入标志，2-出库,1-入库,3-调拔入库，4调拔出库</param>
        /// <param name="blisAutoInsert">是否要自动生成相应的入库单</param>
        /// <param name="OrdTableRow">出库单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAduiTemp(System.Security.Principal.IPrincipal p_objPrincipal, string strID, string stroageID, string GrearName, DataTable OrdDeTable, int intFlan, bool blisAutoInsert, DataRow OrdTableRow)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAduiTemp");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            com.digitalwave.iCare.middletier.HIS.clsMedStorageManage mange = new clsMedStorageManage();
            if (blisAutoInsert == true)
            {
                switch (intFlan)
                {
                    case 1:
                        break;
                    case 2:
                        string newID = "";
                        lngRes = objHRPSvc.m_lngGenerateNewID("t_opr_storageord", "STORAGEORDID_CHR", out newID);
                        strSQL = @"insert into t_opr_storageord(STORAGEORDID_CHR,STORAGEORDTYPEID_CHR,STORAGEID_CHR,PERIODID_CHR,INORD_DAT,TOLMNY_MNY,PSTATUS_INT,DOCID_VCHR,OFFERID_CHR,DEPTID_CHR,VENDORID_CHR,CREATORID_CHR,CREATEDATE_DAT,MEMO_VCHR,sign_int) 
                            VALUES('" + newID + "','" + OrdTableRow["MEDSTOREORDTYPEID_CHR"].ToString().Trim() + "','" + OrdTableRow["SRCID_CHR"].ToString().Trim() + "','" + OrdTableRow["PERIODID_CHR"].ToString().Trim() + "',sysdate," + OrdTableRow["TOLMNY_MNY"].ToString().Trim()
                            + ",1,'" + OrdTableRow["STORERDOCNO_CHR"].ToString().Trim() + "',' ','" + OrdTableRow["MEDSTOREID_CHR"].ToString().Trim() + "',' ','" + GrearName + "',sysdate"
                            + ",'药房退货药品',1)";
                        try
                        {
                            lngRes = objHRPSvc.DoExcute(strSQL);
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        if (OrdDeTable.Rows.Count > 0)
                        {
                            string intStarNO = "";

                            for (int i1 = 0; i1 < OrdDeTable.Rows.Count; i1++)
                            {
                                #region 获取药品的基本单位
                                string strUnit = "";
                                int PACKQTY = 0;
                                Double totNuber = 0;
                                DataTable dt1 = new DataTable();
                                strSQL = @"select OPUNIT_CHR,PACKQTY_DEC,OPCHARGEFLG_INT from t_bse_medicine where MEDICINEID_CHR='" + OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString() + "'";
                                try
                                {
                                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt1);
                                }
                                catch (Exception objEx)
                                {
                                    string strTmp = objEx.Message;
                                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                                    bool blnRes = objLogger.LogError(objEx);
                                }
                                if (lngRes > 0 && dt1.Rows.Count > 0)
                                {
                                    if (dt1.Rows[0]["OPCHARGEFLG_INT"].ToString() == "1")
                                    {
                                        if (dt1.Rows[0]["OPUNIT_CHR"].ToString() == "")
                                        {
                                            throw new Exception("药品" + OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString() + "的‘药品基本单位’不存在");
                                        }
                                        else
                                        {
                                            strUnit = dt1.Rows[0]["OPUNIT_CHR"].ToString();
                                        }
                                        if (dt1.Rows[0]["PACKQTY_DEC"].ToString() == "" || dt1.Rows[0]["PACKQTY_DEC"].ToString() == "0")
                                        {
                                            throw new Exception("药品" + OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString() + "的‘包装量’不存在");
                                        }
                                        else
                                        {
                                            PACKQTY = int.Parse(dt1.Rows[0]["PACKQTY_DEC"].ToString());
                                            try
                                            {
                                                totNuber = Double.Parse(OrdDeTable.Rows[i1]["QTY_DEC"].ToString()) / PACKQTY;
                                            }
                                            catch
                                            {

                                            }
                                        }
                                    }
                                    else
                                    {
                                        totNuber = Double.Parse(OrdDeTable.Rows[i1]["QTY_DEC"].ToString());
                                        strUnit = dt1.Rows[0]["OPUNIT_CHR"].ToString();
                                    }

                                }
                                else
                                {
                                    throw new Exception("药品" + OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString() + "的‘药品基本单位’或‘包装量’不存在");
                                }
                                #endregion
                                objHRPSvc.m_lngGenerateNewID("t_opr_storageordde", "STORAGEORDDEID_CHR", out intStarNO);

                                strSQL = @"INSERT INTO t_opr_storageordde (STORAGEORDDEID_CHR,STORAGEORDID_CHR,STORAGEORDTYPEID_CHR,MEDICINEID_CHR,ORD_DAT,
                           ROWNO_CHR,UNITID_CHR,LOTNO_VCHR,USEFULLIFE_DAT,PRODCUTORID_CHR,QTY_DEC,BUYUNITPRICE_MNY,WHOLESALEUNITPRICE_MNY,
                           DISCOUNT_DEC,BUYTOLPRICE_MNY,INVOICENO_VCHR,PACKAGEQTY_DEC,PACKAGEPRICE_MNY,SALEUNITPRICE_MNY) 
                          VALUES('" + intStarNO + "','" + newID + "','" + OrdTableRow["MEDSTOREORDTYPEID_CHR"].ToString().Trim() + "','" + OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString().Trim() + "',sysdate,'" + OrdDeTable.Rows[i1]["ROWNO_CHR"].ToString().Trim() + "','" + strUnit + "','" + OrdDeTable.Rows[i1]["MEDNO_CHR"].ToString().Trim() + "',To_Date('" + OrdDeTable.Rows[i1]["USEFULLIFE_DAT"].ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss')"
                                    + ",'" + OrdDeTable.Rows[i1]["PRODUCTORID_CHR"].ToString().Trim() + "'," + totNuber.ToString().Trim() + "," + OrdDeTable.Rows[i1]["SALEUNITPRICE_DEC"].ToString().Trim() + ",0,1," + OrdDeTable.Rows[i1]["SALETOLPRICE_DEC"].ToString().Trim() + ",' '," + PACKQTY
                                    + ",0,0)";
                                try
                                {
                                    lngRes = objHRPSvc.DoExcute(strSQL);
                                }
                                catch (Exception objEx)
                                {
                                    string strTmp = objEx.Message;
                                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                                    bool blnRes = objLogger.LogError(objEx);
                                }

                            }
                        }
                        break;
                    case 3:
                        string newID1 = "";
                        m_lngSave(p_objPrincipal, OrdTableRow, OrdDeTable, out newID1, 3);
                        break;
                    case 4:
                        m_lngSave(p_objPrincipal, OrdTableRow, OrdDeTable, out newID1, 4);
                        break;
                }
            }

            for (int i1 = 0; i1 < OrdDeTable.Rows.Count; i1++)
            {
                if (intFlan == 1 || intFlan == 3)
                {
                    mange.m_lnghMedInit(p_objPrincipal, OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString().Trim(), OrdDeTable.Rows[i1]["MEDNO_CHR"].ToString().Trim(),
                        stroageID, Double.Parse(OrdDeTable.Rows[i1]["QTY_DEC"].ToString().Trim()), OrdDeTable.Rows[i1]["UNITID_CHR"].ToString().Trim(), 0,
                        0, 0, OrdDeTable.Rows[i1]["USEFULLIFE_DAT"].ToString().Trim(),
                        OrdDeTable.Rows[i1]["PRODUCTORID_CHR"].ToString().Trim(), "1", OrdDeTable.Rows[i1]["SYSLOTNO_CHR"].ToString());
                }
                else
                {
                    mange.m_lngReduceMedQty(p_objPrincipal, OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString().Trim(), OrdDeTable.Rows[i1]["MEDNO_CHR"].ToString().Trim(), OrdDeTable.Rows[i1]["SYSLOTNO_CHR"].ToString().Trim(), stroageID.Trim(), "1", Double.Parse(OrdDeTable.Rows[i1]["QTY_DEC"].ToString().Trim()), OrdDeTable.Rows[i1]["UNITID_CHR"].ToString().Trim(), 1);
                }
                #region 不用的代码
                //				DataTable dtbstroage=new DataTable();
                //				strSQL=@"select AMOUNT_DEC from t_tol_medstoremedicine where MEDSTOREID_CHR='"+stroageID+"' and MEDICINEID_CHR='"+OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString()+"'";
                //				try
                //				{
                //					lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbstroage);
                //					
                //				}
                //				catch(Exception objEx)
                //				{
                //					string strTmp=objEx.Message;
                //					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                //					bool blnRes = objLogger.LogError(objEx);
                //				}
                //				if(dtbstroage.Rows.Count>0)
                //				{
                //					int Tolstrage=Convert.ToInt32(dtbstroage.Rows[0]["AMOUNT_DEC"])+Convert.ToInt32(OrdDeTable.Rows[i1]["QTY_DEC"]);
                //					strSQL=@"update t_tol_medstoremedicine set AMOUNT_DEC="+Tolstrage+" where MEDSTOREID_CHR='"+stroageID+"' and MEDICINEID_CHR='"+OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString()+"'";
                //					try
                //					{
                //						lngRes = objHRPSvc.DoExcute(strSQL);
                //						
                //					}
                //					catch(Exception objEx)
                //					{
                //						string strTmp=objEx.Message;
                //						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                //						bool blnRes = objLogger.LogError(objEx);
                //					}
                //				}
                //				else
                //				{
                //					strSQL=@"insert into  t_tol_medstoremedicine(MEDSTOREID_CHR,MEDICINEID_CHR,AMOUNT_DEC) values('"+stroageID+"','"+OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString()+"',"+OrdDeTable.Rows[i1]["QTY_DEC"].ToString()+")";
                //					try
                //					{
                //						lngRes = objHRPSvc.DoExcute(strSQL);
                //						
                //					}
                //					catch(Exception objEx)
                //					{
                //						string strTmp=objEx.Message;
                //						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                //						bool blnRes = objLogger.LogError(objEx);
                //					}
                //				}
                #endregion
            }
            if (lngRes > 0)
            {
                strSQL = @"update t_opr_medstoreord set ADUITEMP_CHR='" + GrearName + "',ADUITDATE_DAT=To_Date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'),PSTATUS_INT=2 where MEDSTOREORDID_CHR='" + strID + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region  获得药房出药类型、药房信息
        /// <summary>
        /// 获得药房出药类型、药房信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strTypeName">出药类型名称</param>
        /// <param name="dtbStorage">药房信息</param>
        /// <param name="strTypeID">出药类型ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTypeAndStorageOut(System.Security.Principal.IPrincipal p_objPrincipal, string strTypeID, out string strTypeName, out DataTable dtbStorage)
        {
            long lngRes = 0;
            strTypeName = "";
            dtbStorage = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngGetTypeAndStorageOut");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            string strSQL = @"select MEDSTOREORDTYPE_VCHR from t_aid_medstoreordtype where SIGN_INT=2 and MEDSTOREORDTYPEID_CHR='" + strTypeID + "'";
            DataTable dtbType = new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbType);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dtbType.Rows.Count > 0)
            {
                strTypeName = dtbType.Rows[0]["MEDSTOREORDTYPE_VCHR"].ToString().Trim();
            }
            strSQL = @"select STORAGEID_CHR,MEDSTORENAME_VCHR from t_bse_medstore where MEDSTORETYPE_INT=1";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbStorage);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion

        #region 获得所有的出药数据
        /// <summary>
        /// 获得所有的出药数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtbResult"></param>
        /// <param name="nowPriod">财务期ID</param>
        /// <param name="strTypeID">类型ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdOut(System.Security.Principal.IPrincipal p_objPrincipal, string strTypeID, out DataTable dtbResult, string nowPriod)
        {
            long lngRes = 0;
            dtbResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdOut");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            if (nowPriod != "")
                strSQL = @"SELECT a.MEDSTOREORDID_CHR,a.MEDSTOREID_CHR,a.ORDDATE_DAT,a.TOLMNY_MNY,a.MEMO_VCHR,a.CREATOR_CHR," +
                    "a.CREATEDATE_DAT,a.ADUITEMP_CHR,a.ADUITDATE_DAT,a.MEDSTOREORDTYPEID_CHR,a.PSTATUS_INT,a.PERIODID_CHR,b.MEDSTORENAME_VCHR,"
                    + "c.LASTNAME_VCHR as CREATORNAME,d.LASTNAME_VCHR as ADUITEMPNAME FROM t_opr_medstoreord a,"
                    + "t_bse_medstore b,t_bse_employee c,t_bse_employee d where a.MEDSTOREID_CHR=b.MEDSTOREID_CHR(+) and a.CREATOR_CHR=c.EMPID_CHR(+) and a.ADUITEMP_CHR=d.EMPID_CHR(+) AND a.MEDSTOREORDTYPEID_CHR='" + strTypeID + "'"
                    + " and a.OUTFLAN_INT=2 and PERIODID_CHR='" + nowPriod + "'";
            else
                strSQL = @"SELECT a.MEDSTOREORDID_CHR,a.MEDSTOREID_CHR,a.ORDDATE_DAT,a.TOLMNY_MNY,a.MEMO_VCHR,a.CREATOR_CHR," +
                    "a.CREATEDATE_DAT,a.ADUITEMP_CHR,a.ADUITDATE_DAT,a.MEDSTOREORDTYPEID_CHR,a.PSTATUS_INT,a.PERIODID_CHR,b.MEDSTORENAME_VCHR,"
                    + "c.LASTNAME_VCHR as CREATORNAME,d.LASTNAME_VCHR as ADUITEMPNAME  FROM t_opr_medstoreord a,"
                    + "t_bse_medstore b,t_bse_employee c,t_bse_employee d where a.MEDSTOREID_CHR=b.MEDSTOREID_CHR(+) and a.CREATOR_CHR=c.EMPID_CHR(+) and a.ADUITEMP_CHR=d.EMPID_CHR(+) AND a.MEDSTOREORDTYPEID_CHR='" + strTypeID + "'"
                    + " and a.OUTFLAN_INT=2";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 审核功能(出药)
        /// <summary>
        /// 审核功能
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="stroageID">药库ID</param>
        /// <param name="strID">单号ID</param>
        /// <param name="GrearName">审核人ID</param>
        /// <param name="OrdDeTable">入库单明细</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAduiTempOut(System.Security.Principal.IPrincipal p_objPrincipal, string strID, string stroageID, string GrearName, DataTable OrdDeTable)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAduiTempOut");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            for (int i1 = 0; i1 < OrdDeTable.Rows.Count; i1++)
            {
                DataTable dtbstroage = new DataTable();
                strSQL = @"select AMOUNT_DEC from t_tol_medstoremedicine where MEDSTOREID_CHR='" + stroageID + "' and MEDICINEID_CHR='" + OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString() + "'";
                try
                {
                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbstroage);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (dtbstroage.Rows.Count > 0)
                {
                    int Tolstrage = Convert.ToInt32(dtbstroage.Rows[0]["AMOUNT_DEC"]) - Convert.ToInt32(OrdDeTable.Rows[i1]["QTY_DEC"]);
                    if (Tolstrage >= 0)
                    {
                        strSQL = @"update t_tol_medstoremedicine set AMOUNT_DEC=" + Tolstrage + " where MEDSTOREID_CHR='" + stroageID + "' and MEDICINEID_CHR='" + OrdDeTable.Rows[i1]["MEDICINEID_CHR"].ToString() + "'";
                        try
                        {
                            lngRes = objHRPSvc.DoExcute(strSQL);

                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                    }
                    else
                    {
                        lngRes = -2;
                        return lngRes;
                    }
                }
                else
                {
                    lngRes = -2;
                    return lngRes;
                }
            }
            if (lngRes > 0)
            {
                strSQL = @"update t_opr_medstoreord set ADUITEMP_CHR='" + GrearName + "',ADUITDATE_DAT=To_Date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'),PSTATUS_INT=2 where MEDSTOREORDID_CHR='" + strID + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 查找药品的库存
        /// <summary>
        /// 查找药品的库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strstogeId"></param>
        /// <param name="Medid"></param>
        /// <param name="StoreNumber"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllStorage(System.Security.Principal.IPrincipal p_objPrincipal, string strstogeId, string Medid, out int StoreNumber)
        {
            long lngRes = 0;
            StoreNumber = -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetAllStorage");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select AMOUNT_DEC FROM T_TOL_MEDSTOREMEDICINE WHERE MEDSTOREID_CHR='" + strstogeId + "' AND MEDICINEID_CHR='" + Medid + "'";
            DataTable dtResult = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtResult);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtResult.Rows.Count > 0)
            {
                StoreNumber = Convert.ToInt32(dtResult.Rows[0]["AMOUNT_DEC"]);
            }
            return lngRes;
        }
        #endregion

        #endregion

        #region 新增药房进出药记录单
        /// <summary>
        /// 新增药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房进出记录单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedStoreOrd(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreOrd_VO p_objItem)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAddNewMedStoreOrd");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"INSERT INTO t_opr_medstoreord
										  (medstoreordid_chr, medstoreid_chr, orddate_dat,
										   tolqty_dec, tolmny_mny, periodid_chr, memo_vchr, creator_chr,
										   createdate_dat, aduitemp_chr,
										   aduitdate_dat, acctemp_chr,
										   acctdate_dat, srcid_chr, srctype_int,
										   medstoreordtypeid_chr, pstatus_int
										  )
								  VALUES ('" + p_objItem.m_strMedStoreOrdID.Trim() + "', '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "', TO_DATE ('" + p_objItem.m_strOrdDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"				  " + p_objItem.m_decTolQty.ToString() + ", " + p_objItem.m_decTolMny.ToString() + ", '" + p_objItem.m_objPeriod.m_strPeriodID.Trim() + "', '" + p_objItem.m_strMemo.Trim() + "', '" + p_objItem.m_objCreator.strEmpID.Trim() + "',";
            strSQL += @"				  TO_DATE ('" + p_objItem.m_strCreateDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), '" + p_objItem.m_objAduitEmp.strEmpID.Trim() + "',";
            strSQL += @"				  TO_DATE ('" + p_objItem.m_strAduitDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), '" + p_objItem.m_objAcctEmp.strEmpID.Trim() + "',";
            strSQL += @"				  TO_DATE ('" + p_objItem.m_strAcctDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), '" + p_objItem.m_strSrcID.Trim() + "', " + p_objItem.m_intSrcType.ToString() + ",";
            strSQL += @"				  '" + p_objItem.m_objMedStoreOrdType.m_strMedStoreOrdTypeID.Trim() + "', " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"				 )";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 修改药房进出药记录单
        /// <summary>
        /// 修改药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房进出记录单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateMedStoreOrd(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreOrd_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedStoreOrd");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstoreord
								 SET orddate_dat = TO_DATE ('" + p_objItem.m_strOrdDate.Trim() + "', 'yyyy-mm-dd hh24:mi;ss'),";
            strSQL += @"			 tolqty_dec = " + p_objItem.m_decTolQty.ToString() + ", ";
            strSQL += @"			 tolmny_mny = " + p_objItem.m_decTolMny.ToString() + ", ";
            strSQL += @"			 periodid_chr = '" + p_objItem.m_objPeriod.m_strPeriodID.Trim() + "', ";
            strSQL += @"			 memo_vchr = '" + p_objItem.m_strMemo.Trim() + "', ";
            strSQL += @"			 creator_chr = '" + p_objItem.m_objCreator.strEmpID.Trim() + "', ";
            strSQL += @"			 createdate_dat = TO_DATE ('" + p_objItem.m_strCreateDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 aduitemp_chr = '" + p_objItem.m_objAduitEmp.strEmpID.Trim() + "', ";
            strSQL += @"			 aduitdate_dat = TO_DATE ('" + p_objItem.m_strAduitDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 acctemp_chr = '" + p_objItem.m_objAcctEmp.strEmpID.Trim() + "', ";
            strSQL += @"			 acctdate_dat = TO_DATE ('" + p_objItem.m_strAcctDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 srcid_chr = '" + p_objItem.m_strSrcID.Trim() + "',";
            strSQL += @"			 srctype_int = " + p_objItem.m_intSrcType.ToString() + ", ";
            strSQL += @"			 medstoreordtypeid_chr = '" + p_objItem.m_objMedStoreOrdType.m_strMedStoreOrdTypeID.Trim() + "', ";
            strSQL += @"			 pstatus_int = " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"	   WHERE TRIM(medstoreordid_chr) = '" + p_objItem.m_strMedStoreOrdID.Trim() + "' AND TRIM(medstoreid_chr) = '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 修改药房进出药记录单状态标志
        /// <summary>
        /// 修改药房进出药记录单状态标志
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="strID">药房进出记录单ID</param>
        /// <param name="intStatus">状态标志</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateMedStoreOrdStatus(System.Security.Principal.IPrincipal p_objPrincipal,
            string strID, int intStatus)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedStoreOrdStatus");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstoreord
								 SET pstatus_int = " + intStatus.ToString() + " ";
            strSQL += @"	   WHERE TRIM(medstoreordid_chr) = '" + strID.Trim() + "' ";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;

        }
        #endregion

        #region 删除药房进出药记录单
        /// <summary>
        /// 删除药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房进出记录单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedStoreOrd(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngDeleteMedStoreOrd");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE t_opr_medstoreord
							   WHERE TRIM(medstoreordid_chr) = '" + p_strID.Trim() + "' ";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }



            return lngRes;
        }
        #endregion

        #region 审核药房进出药记录单
        /// <summary>
        /// 药房进出药记录单审核
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房进出记录单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAduitMedStoreOrd(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreOrd_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedStoreOrd");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstoreord
								 SET aduitemp_chr = '" + p_objItem.m_objAduitEmp.strEmpID.Trim() + "', ";
            strSQL += @"			 aduitdate_dat = TO_DATE ('" + p_objItem.m_strAduitDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 pstatus_int = " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"	   WHERE TRIM(medstoreordid_chr) = '" + p_objItem.m_strMedStoreOrdID.Trim() + "' AND TRIM(medstoreid_chr) = '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 审核药房进出药记录单后更改库存
        /// <summary>
        /// 药房进出药记录单审核后更改库存
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房进出记录单ID</param>
        /// <param name="p_intFlag">标识，1：成功，0：失败，-1：异常</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangeStorageAfterAduitMedStoreOrd(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out int p_intFlag)
        {
            long lngRes = 0;
            p_intFlag = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngChangeStorageAfterAduitMedStoreOrd");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                string strProcedure = "P_MEDSTOREORDADUIT";
                com.digitalwave.iCare.ValueObject.clsSQLParamDefinitionVO[] objParams = new clsSQLParamDefinitionVO[2];

                for (int i = 0; i < objParams.Length; i++)
                {
                    objParams[i] = new clsSQLParamDefinitionVO();
                }
                objParams[0].objParameter_Value = p_strID;
                objParams[0].strParameter_Type = clsOracleDbType.strVarchar2;
                objParams[0].strParameter_Name = "ordid";

                objParams[1].strParameter_Type = clsOracleDbType.strInt32;
                objParams[1].strParameter_Direction = clsDirection.strOutput;
                objParams[1].strParameter_Name = "flag";


                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngExecuteParameterProc(strProcedure, objParams);
                p_intFlag = int.Parse(objParams[1].objParameter_Value.ToString().Trim());

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 药房进出药记录单登帐
        /// <summary>
        /// 药房进出药记录单登帐
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房进出记录单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAcctMedStoreOrd(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreOrd_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedStoreOrd");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstoreord
								 SET acctemp_chr = '" + p_objItem.m_objAcctEmp.strEmpID.Trim() + "', ";
            strSQL += @"			 acctdate_dat = TO_DATE ('" + p_objItem.m_strAcctDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 pstatus_int = " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"	   WHERE TRIM(medstoreordid_chr) = '" + p_objItem.m_strMedStoreOrdID.Trim() + "' AND TRIM(medstoreid_chr) = '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 药房进出药记录单登帐后更改帐务
        /// <summary>
        /// 药房进出药记录单登帐后更改帐务
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房进出记录单ID</param>
        /// <param name="p_intFlag">标识，1：成功，0：失败，-1：异常</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangeFinAfterAcctMedStoreOrd(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out int p_intFlag)
        {
            long lngRes = 0;
            p_intFlag = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngChangeFinAfterAcctMedStoreOrd");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                string strProcedure = "P_MEDSTOREORDACCT";
                com.digitalwave.iCare.ValueObject.clsSQLParamDefinitionVO[] objParams = new clsSQLParamDefinitionVO[2];

                for (int i = 0; i < objParams.Length; i++)
                {
                    objParams[i] = new clsSQLParamDefinitionVO();
                }
                objParams[0].objParameter_Value = p_strID;
                objParams[0].strParameter_Type = clsOracleDbType.strVarchar2;
                objParams[0].strParameter_Name = "ordid";

                objParams[1].strParameter_Type = clsOracleDbType.strInt32;
                objParams[1].strParameter_Direction = clsDirection.strOutput;
                objParams[1].strParameter_Name = "flag";


                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngExecuteParameterProc(strProcedure, objParams);
                p_intFlag = int.Parse(objParams[1].objParameter_Value.ToString().Trim());

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 新增药房进出药明细单记录
        /// <summary>
        /// 新增药房进出药明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房进出药明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedStoreOrdDe(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreOrdDe_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAddNewMedStoreOrdDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_opr_medstoreordde
										  (medstoreorddeid_chr, medstoreordid_chr, medicineid_chr,
										   syslotno_chr, rowno_chr, orddate_dat,
										   qty_dec, saleunitprice_dec, saletolprice_dec, unitid_chr
										  )
								   VALUES ('" + p_objItem.m_strMedStoreOrdDeID.Trim() + "', '" + p_objItem.m_strMedStoreOrdID.Trim() + "', '" + p_objItem.m_objMedicine.m_strMedicineID.Trim() + "', ";
            strSQL += @"				   '" + p_objItem.m_strSysLotNo.Trim() + "', '" + p_objItem.m_strRowNo.Trim() + "', TO_DATE ('" + p_objItem.m_strOrdDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"				   " + p_objItem.m_decQty.ToString() + ", " + p_objItem.m_decSaleUnitPrice.ToString() + ", " + p_objItem.m_decSaleTolPrice.ToString() + ", '" + p_objItem.m_objUnit.m_strUnitID.Trim() + "' ";
            strSQL += @"				  )";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 修改药房进出药明细单记录
        /// <summary>
        /// 修改药房进出药明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房进出药明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateMedStoreOrdDe(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreOrdDe_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedStoreOrdDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstoreordde
								 SET rowno_chr = '" + p_objItem.m_strRowNo.Trim() + "', ";
            strSQL += @"			 unitid_chr = '" + p_objItem.m_objUnit.m_strUnitID.Trim() + "', ";
            strSQL += @"			 qty_dec = " + p_objItem.m_decQty.ToString() + ", ";
            strSQL += @"			 saleunitprice_dec = " + p_objItem.m_decSaleUnitPrice.ToString() + ", ";
            strSQL += @"			 saletolprice_dec = " + p_objItem.m_decSaleTolPrice.ToString() + " ";
            strSQL += @"	   WHERE TRIM(medstoreorddeid_chr) = '" + p_objItem.m_strMedStoreOrdDeID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 删除药房进出药明细单记录
        /// <summary>
        /// 删除药房进出药明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房进出药明细ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedStoreOrdDe(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngDeleteMedStoreOrdDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE t_opr_medstoreordde
							   WHERE TRIM(medstoreorddeid_chr) = '" + p_strID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 模糊查询药房进出药记录单
        /// <summary>
        /// 模糊查询药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdByAny(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSQL, out clsMedStoreOrd_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrd_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreByAny");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT *
							    FROM v_opr_medstoreord
							 " + p_strSQL;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    if (intRow > 0)
                    {
                        p_objResultArr = new clsMedStoreOrd_VO[intRow];
                        for (int i = 0; i < intRow; i++)
                        {
                            p_objResultArr[i] = new clsMedStoreOrd_VO();
                            p_objResultArr[i].m_objMedStore = new clsMedStore_VO();
                            p_objResultArr[i].m_objMedStoreOrdType = new clsMedStoreOrdType_VO();
                            p_objResultArr[i].m_objPeriod = new clsPeriod_VO();
                            p_objResultArr[i].m_objCreator = new clsEmployeeVO();
                            p_objResultArr[i].m_objAduitEmp = new clsEmployeeVO();
                            p_objResultArr[i].m_objAcctEmp = new clsEmployeeVO();
                            p_objResultArr[i].m_strMedStoreOrdID = dtbResult.Rows[i]["medstoreordid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_strMedStoreID = dtbResult.Rows[i]["medstoreid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_strMedStoreName = dtbResult.Rows[i]["medstorename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_intMedStoreType = Convert.ToInt32(dtbResult.Rows[i]["medstoretype_int"].ToString().Trim());
                            p_objResultArr[i].m_objMedStore.m_intMedicneType = Convert.ToInt32(dtbResult.Rows[i]["medicnetype_int"].ToString().Trim());
                            p_objResultArr[i].m_strOrdDate = dtbResult.Rows[i]["orddate_dat"].ToString().Trim();
                            p_objResultArr[i].m_decTolQty = Convert.ToDecimal(dtbResult.Rows[i]["tolqty_dec"].ToString().Trim());
                            p_objResultArr[i].m_decTolMny = Convert.ToDecimal(dtbResult.Rows[i]["tolmny_mny"].ToString().Trim());
                            p_objResultArr[i].m_objPeriod.m_strPeriodID = dtbResult.Rows[i]["periodid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objPeriod.m_strStartDate = dtbResult.Rows[i]["startdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objPeriod.m_strEndDate = dtbResult.Rows[i]["enddate_dat"].ToString().Trim();
                            p_objResultArr[i].m_strMemo = dtbResult.Rows[i]["memo_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objCreator.strEmpID = dtbResult.Rows[i]["creator_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCreateDate = dtbResult.Rows[i]["createdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objAduitEmp.strEmpID = dtbResult.Rows[i]["aduitemp_chr"].ToString().Trim();
                            p_objResultArr[i].m_strAduitDate = dtbResult.Rows[i]["aduitdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objAcctEmp.strEmpID = dtbResult.Rows[i]["acctemp_chr"].ToString().Trim();
                            p_objResultArr[i].m_strAcctDate = dtbResult.Rows[i]["acctdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_strSrcID = dtbResult.Rows[i]["srcid_chr"].ToString().Trim();
                            p_objResultArr[i].m_intSrcType = Convert.ToInt32(dtbResult.Rows[i]["srctype_int"].ToString().Trim());
                            p_objResultArr[i].m_objMedStoreOrdType.m_strMedStoreOrdTypeID = dtbResult.Rows[i]["medstoreordtypeid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStoreOrdType.m_strMedStoreOrdTypeName = dtbResult.Rows[i]["medstoreordtype_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStoreOrdType.m_intSign = Convert.ToInt32(dtbResult.Rows[i]["sign_int"].ToString().Trim());
                            p_objResultArr[i].m_intPStatus = Convert.ToInt32(dtbResult.Rows[i]["pstatus_int"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 按记录单ID查询药房进出药记录单
        /// <summary>
        /// 按记录单ID查询药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">记录单ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdByID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrd_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrd_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdByID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medstoreordid_chr) = '" + p_strID.Trim() + "' ";

            lngRes = m_lngGetMedStoreOrdByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按单据类型查询药房进出药记录单
        /// <summary>
        /// 按单据类型查询药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">单据类型ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdByOrdType(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrd_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrd_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdByOrdType");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medstoreordtypeid_chr) = '" + p_strID.Trim() + "' ";

            lngRes = m_lngGetMedStoreOrdByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按药房查询药房进出药记录单
        /// <summary>
        /// 按药房查询药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdByMedStore(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrd_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrd_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdByMedStore");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medstoreid_chr) = '" + p_strID.Trim() + "' ";

            lngRes = m_lngGetMedStoreOrdByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按操作时间查询药房进出药记录单
        /// <summary>
        /// 按操作时间查询药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strStartDate">开始时间</param>
        /// <param name="p_strEndDate">结束时间</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdByDate(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strStartDate, string p_strEndDate, out clsMedStoreOrd_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrd_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdByDate");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE orddate_dat >= TO_DATE ('" + p_strStartDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss') ";
            strSQL += @"	     AND orddate_dat <= TO_DATE ('" + p_strEndDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss')";

            lngRes = m_lngGetMedStoreOrdByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按帐务期查询药房进出药记录单
        /// <summary>
        /// 按帐务期查询药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">帐务期ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdByPeriod(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrd_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrd_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdByPeriod");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(periodid_chr) = '" + p_strID.Trim() + "' ";

            lngRes = m_lngGetMedStoreOrdByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按状态标志查询药房进出药记录单
        /// <summary>
        /// 按状态标志查询药房进出药记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_intStatus">状态标识</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdByStatus(System.Security.Principal.IPrincipal p_objPrincipal,
            int p_intStatus, out clsMedStoreOrd_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrd_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdByStatus");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE pstatus_int = " + p_intStatus.ToString() + " ";

            lngRes = m_lngGetMedStoreOrdByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 模糊查询药房进出药明细单
        /// <summary>
        /// 模糊查询药房进出药明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdDeByAny(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSQL, out clsMedStoreOrdDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdDeByAny");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT *
							    FROM v_opr_medstoreordde
							 " + p_strSQL;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    if (intRow > 0)
                    {
                        p_objResultArr = new clsMedStoreOrdDe_VO[intRow];
                        for (int i = 0; i < intRow; i++)
                        {
                            p_objResultArr[i] = new clsMedStoreOrdDe_VO();
                            p_objResultArr[i].m_objMedicine = new clsMedicine_VO();
                            p_objResultArr[i].m_objUnit = new clsUnit_VO();

                            p_objResultArr[i].m_strMedStoreOrdDeID = dtbResult.Rows[i]["medstoreorddeid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strMedStoreOrdID = dtbResult.Rows[i]["medstoreordid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineID = dtbResult.Rows[i]["medicineid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineName = dtbResult.Rows[i]["medicinename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineEngName = dtbResult.Rows[i]["medicineengname_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strPYCode = dtbResult.Rows[i]["pycode_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strWBCode = dtbResult.Rows[i]["wbcode_chr"].ToString().Trim();
                            p_objResultArr[i].m_strSysLotNo = dtbResult.Rows[i]["syslotno_chr"].ToString().Trim();
                            p_objResultArr[i].m_strRowNo = dtbResult.Rows[i]["rowno_chr"].ToString().Trim();
                            p_objResultArr[i].m_strOrdDate = dtbResult.Rows[i]["orddate_dat"].ToString().Trim();
                            p_objResultArr[i].m_decQty = Convert.ToDecimal(dtbResult.Rows[i]["qty_dec"].ToString().Trim());
                            p_objResultArr[i].m_decSaleUnitPrice = Convert.ToDecimal(dtbResult.Rows[i]["saleunitprice_dec"].ToString().Trim());
                            p_objResultArr[i].m_decSaleTolPrice = Convert.ToDecimal(dtbResult.Rows[i]["saletolprice_dec"].ToString().Trim());
                            p_objResultArr[i].m_objUnit.m_strUnitID = dtbResult.Rows[i]["unitid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objUnit.m_strUnitName = dtbResult.Rows[i]["unitname_chr"].ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 按药房进出药记录单ID查询药房进出药明细单
        /// <summary>
        /// 按药房进出药记录单ID查询药房进出药明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">记录单ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdDeByOrdID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrdDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdDeByOrdID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medstoreordid_chr) = '" + p_strID.Trim() + "'";

            lngRes = m_lngGetMedStoreOrdDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按药品查询药房进出药明细单
        /// <summary>
        /// 按药品查询药房进出药明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药品ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdDeByMedicine(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrdDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdDeByMedicine");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medicineid_chr) = '" + p_strID.Trim() + "'";

            lngRes = m_lngGetMedStoreOrdDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 获取当前最大的药房进出药记录单ID
        /// <summary>
        /// 获取当前最大的药房进出药记录单ID
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">记录单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdID(System.Security.Principal.IPrincipal p_objPrincipal,
            out string p_strID)
        {
            long lngRes = 0;
            p_strID = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdID");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                p_strID = objHRPSvc.m_strGetNewID("t_opr_medstoreord", "medstoreordid_chr", 18);


                if (p_strID != null)
                {
                    if (Convert.ToInt32(p_strID.Trim()) <= 0)
                    {
                        int ID = Convert.ToInt32(p_strID.Trim()) + 1;
                        p_strID = ID.ToString("000000000000000000");
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 获取当前最大的药房显示出药明细单ID
        /// <summary>
        /// 获取当前最大的药房显示出药明细单ID
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">明细单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdDeID(System.Security.Principal.IPrincipal p_objPrincipal,
            out string p_strID)
        {
            long lngRes = 0;
            p_strID = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdID");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                p_strID = objHRPSvc.m_strGetNewID("t_opr_medstoreordde", "medstoreorddeid_chr", 18);


                if (p_strID != null)
                {
                    if (Convert.ToInt32(p_strID.Trim()) <= 0)
                    {
                        int ID = Convert.ToInt32(p_strID.Trim()) + 1;
                        p_strID = ID.ToString("000000000000000000");
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #endregion

        #region 药房领药申请

        #region 新系统的方法

        #region 获取当前最大的药房领药申请单ID
        /// <summary>
        /// 获取当前最大的药房领药申请单ID
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">申请单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplID(System.Security.Principal.IPrincipal p_objPrincipal,
            out string p_strID)
        {
            long lngRes = 0;
            p_strID = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplID");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                p_strID = objHRPSvc.m_strGetNewID("t_opr_medstoremedappl", "MEDAPPLID_CHR", 14);


                if (p_strID != null)
                {
                    if (Convert.ToInt32(p_strID.Trim()) <= 0)
                    {
                        int ID = Convert.ToInt32(p_strID.Trim()) + 1;
                        p_strID = ID.ToString("00000000000000");
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region  获得药库、药房信息
        /// <summary>
        /// 获得药库、药房信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtbStorage">药库信息表</param>
        /// <param name="dtbStore">药房信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoreAndStorage(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbStorage, out DataTable dtbStore)
        {
            long lngRes = 0;
            dtbStore = null;
            dtbStorage = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngGetStoreAndStorage");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            string strSQL = @"select STORAGEID_CHR,STORAGENAME_VCHR from t_bse_storage";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbStorage);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select MEDSTOREID_CHR,MEDSTORENAME_VCHR from t_bse_medstore where MEDSTORETYPE_INT=1";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbStore);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion

        #region 获得药房领药申请记录单
        /// <summary>
        /// 获得药房领药申请记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <param name="storageID">申请药房</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplAll(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_objResultArr, string storageID)
        {
            long lngRes = 0;
            p_objResultArr = new DataTable();

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplAll");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            string strSQL = @"SELECT a.*, b.medstorename_vchr,c.storagename_vchr, d.lastname_vchr" +
                            " FROM t_opr_medstoremedappl a,t_bse_medstore b,t_bse_storage c,t_bse_employee d" +
                            " WHERE a.applmedstoreid_chr = b.medstoreid_chr(+) AND a.medstorageid_chr = c.storageid_chr(+) AND a.creator_chr = d.empid_chr(+) and a.PSTATUS_INT!=2 and APPLMEDSTOREID_CHR='" + storageID + "'";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref p_objResultArr);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 保存申请单
        /// <summary>
        /// 保存申请单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="DtrAppl">申请单行</param>
        /// <param name="dtbApplDe">明细表数据</param>
        /// <param name="newid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngApplSave(System.Security.Principal.IPrincipal p_objPrincipal, DataRow DtrAppl, DataTable dtbApplDe, out string newid)
        {
            long lngRes = 0;
            newid = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngApplSave");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            objHRPSvc.m_lngGenerateNewID("t_opr_medstoremedappl", "MEDAPPLID_CHR", out newid);
            string strSQL = @"insert into t_opr_medstoremedappl(MEDAPPLID_CHR,APPLMEDSTOREID_CHR,APPLDATE_DAT,MEMO_VCHR,CREATOR_CHR,MEDSTORAGEID_CHR," +
                "PSTATUS_INT) values('" + newid + "','" + DtrAppl["APPLMEDSTOREID_CHR"].ToString() + "',To_Date('" + DtrAppl["APPLDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'"
                + DtrAppl["MEMO_VCHR"].ToString() + "','" + DtrAppl["CREATOR_CHR"].ToString() + "','" + DtrAppl["MEDSTORAGEID_CHR"].ToString() + "',1)";
            try
            {
                lngRes = objHRPSvc.DoExcute(strSQL);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtbApplDe.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtbApplDe.Rows.Count; i1++)
                {
                    string newDeid = "";
                    objHRPSvc.m_lngGenerateNewID("t_opr_medstoremedapplde", "MEDAPPLDEID_CHR", out newDeid);
                    strSQL = @"insert into t_opr_medstoremedapplde(MEDAPPLID_CHR,MEDAPPLDEID_CHR,MEDICINEID_CHR,ROWNO_CHR,UNITID_CHR,QTY_DEC)"
                        + " values('" + newid + "','" + newDeid + "','" + dtbApplDe.Rows[i1]["MEDICINEID_CHR"].ToString() + "','"
                        + dtbApplDe.Rows[i1]["ROWNO_CHR"].ToString() + "','" + dtbApplDe.Rows[i1]["UNITID_CHR"].ToString() + "',"
                        + dtbApplDe.Rows[i1]["QTY_DEC"].ToString() + ")";
                    try
                    {
                        lngRes = objHRPSvc.DoExcute(strSQL);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }
            }
            return lngRes;
        }
        #endregion


        #region 保存申请单
        /// <summary>
        /// 保存申请单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="DtrAppl">申请单行</param>
        /// <param name="dtbApplDe">明细表数据</param>
        /// <param name="newid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngApplSave(System.Security.Principal.IPrincipal p_objPrincipal, DataTable dtbApp, DataTable dtbApplDe, out string newid)
        {
            long lngRes = 0;
            newid = null;
            DataRow DtrAppl = dtbApp.Rows[0];
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngApplSave");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            objHRPSvc.m_lngGenerateNewID("t_opr_medstoremedappl", "MEDAPPLID_CHR", out newid);
            string strSQL = @"insert into t_opr_medstoremedappl(MEDAPPLID_CHR,APPLMEDSTOREID_CHR,APPLDATE_DAT,MEMO_VCHR,CREATOR_CHR,MEDSTORAGEID_CHR," +
                "PSTATUS_INT) values('" + newid + "','" + DtrAppl["APPLMEDSTOREID_CHR"].ToString() + "',To_Date('" + DtrAppl["APPLDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'"
                + DtrAppl["MEMO_VCHR"].ToString() + "','" + DtrAppl["CREATOR_CHR"].ToString() + "','" + DtrAppl["MEDSTORAGEID_CHR"].ToString() + "',1)";
            try
            {
                lngRes = objHRPSvc.DoExcute(strSQL);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtbApplDe.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtbApplDe.Rows.Count; i1++)
                {
                    string newDeid = "";
                    objHRPSvc.m_lngGenerateNewID("t_opr_medstoremedapplde", "MEDAPPLDEID_CHR", out newDeid);
                    strSQL = @"insert into t_opr_medstoremedapplde(MEDAPPLID_CHR,MEDAPPLDEID_CHR,MEDICINEID_CHR,ROWNO_CHR,UNITID_CHR,QTY_DEC)"
                        + " values('" + newid + "','" + newDeid + "','" + dtbApplDe.Rows[i1]["MEDICINEID_CHR"].ToString() + "','"
                        + dtbApplDe.Rows[i1]["ROWNO_CHR"].ToString() + "','" + dtbApplDe.Rows[i1]["UNITID_CHR"].ToString() + "',"
                        + dtbApplDe.Rows[i1]["QTY_DEC"].ToString() + ")";
                    try
                    {
                        lngRes = objHRPSvc.DoExcute(strSQL);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 根据申请单号ID获取申请明细数据
        /// <summary>
        /// 根据申请单号ID获取申请明细数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtbApplDe">返回申请明细</param>
        /// <param name="strID">申请单ID</param>
        /// <param name="strSTORAGEID">药房ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplDeById(System.Security.Principal.IPrincipal p_objPrincipal, string strID, out DataTable dtbApplDe, string strSTORAGEID)
        {
            long lngRes = 0;
            dtbApplDe = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplDeById");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT a.*,b.ASSISTCODE_CHR, b.MEDICINENAME_VCHR, b.MEDSPEC_VCHR ,c.AMOUNT_DEC as TOLFINANCE_DEC FROM t_opr_medstoremedapplde a left join  t_bse_storagemedicine c 
    on c.storageid_chr='" + strSTORAGEID + "' and a.medicineid_chr = c.medicineid_chr  and c.flag_int = 1, t_bse_medicine b WHERE a.medicineid_chr = b.medicineid_chr and a.MEDAPPLID_CHR='" + strID + "' order by ROWNO_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbApplDe);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 修改数据
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="RowApplDe"></param>
        /// <param name="RowAppl"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifiyAppl(System.Security.Principal.IPrincipal p_objPrincipal, DataRow RowApplDe, DataRow RowAppl)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngModifiy");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            if (RowApplDe != null)
            {
                strSQL = @"update t_opr_medstoremedapplde  set MEDICINEID_CHR='" + RowApplDe["MEDICINEID_CHR"].ToString() + "',UNITID_CHR='" + RowApplDe["UNITID_CHR"].ToString() + "',QTY_DEC=" + RowApplDe["QTY_DEC"].ToString() + "  where MEDAPPLDEID_CHR='" + RowApplDe["MEDAPPLDEID_CHR"].ToString() + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            strSQL = @"update t_opr_medstoremedappl set APPLMEDSTOREID_CHR='" + RowAppl["APPLMEDSTOREID_CHR"].ToString() + "',APPLDATE_DAT=To_Date('" + RowAppl["APPLDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),MEMO_VCHR='" + RowAppl["MEMO_VCHR"].ToString() + "',MEDSTORAGEID_CHR='" + RowAppl["MEDSTORAGEID_CHR"].ToString() + "' where MEDAPPLID_CHR='" + RowAppl["MEDAPPLID_CHR"].ToString() + "'";
            try
            {
                lngRes = objHRPSvc.DoExcute(strSQL);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strDeId">明细ID</param>
        /// <param name="strId">申请单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleAppl(System.Security.Principal.IPrincipal p_objPrincipal, string strDeId, string strId)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngDeleAppl");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            if (strDeId != null)
            {
                strSQL = @"delete  t_opr_medstoremedapplde where MEDAPPLDEID_CHR='" + strDeId + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                strSQL = @"delete  t_opr_medstoremedapplde where MEDAPPLID_CHR='" + strId + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                strSQL = @"delete  t_opr_medstoremedappl where MEDAPPLID_CHR='" + strId + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;

        }
        #endregion

        #region 提交申请单
        /// <summary>
        /// 提交申请单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strDeId"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPutinAppll(System.Security.Principal.IPrincipal p_objPrincipal, string strDeId)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngPutinAppll");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            if (strDeId != null)
            {
                strSQL = @"update  T_OPR_MEDSTOREMEDAPPL set PSTATUS_INT=3 where MEDAPPLID_CHR='" + strDeId + "'";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;

        }
        #endregion

        #region 向申请单新增一条明细
        /// <summary>
        /// 向申请单新增一条明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strId">申请单ID</param>
        /// <param name="RowDe">明细数据</param>
        /// <param name="newDeid">返回明细ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddApplDe(System.Security.Principal.IPrincipal p_objPrincipal, string strId, DataRow RowDe, out string newDeid)
        {
            long lngRes = 0;
            newDeid = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngDeleAppl");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            objHRPSvc.m_lngGenerateNewID("t_opr_medstoremedapplde", "MEDAPPLDEID_CHR", out newDeid);
            string strSQL = @"insert into t_opr_medstoremedapplde(MEDAPPLID_CHR,MEDAPPLDEID_CHR,MEDICINEID_CHR,ROWNO_CHR,UNITID_CHR,QTY_DEC)"
                + " values('" + strId + "','" + newDeid + "','" + RowDe["MEDICINEID_CHR"].ToString() + "','"
                + RowDe["ROWNO_CHR"].ToString() + "','" + RowDe["UNITID_CHR"].ToString() + "',"
                + RowDe["QTY_DEC"].ToString() + ")";
            try
            {
                lngRes = objHRPSvc.DoExcute(strSQL);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion

        #region 自动生成领药申请单
        /// <summary>
        /// 自动生成领药申请单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtbResult">返回数据表</param>
        /// <param name="stroageID">药房ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAutoGetMedAppl(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbResult, string stroageID)
        {
            long lngRes = 0;
            dtbResult = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAutoCalcMedAppl");
            if (lngRes < 0)
            {
                return -1;
            }

            dtbResult = new DataTable();
            string strSQL = @"select f.MEDSTOREID_CHR,f.MEDICINEID_CHR,f.ASSISTCODE_CHR,f.PYCODE_CHR,f.WBCODE_CHR,f.LOWLIMIT_DEC,f.PLANQTY_DEC,f.UNITID_CHR,
                                     f.medstorename_vchr, 
									 f.medicinename_vchr, f.medspec_vchr,
									 case when f.amount_dec is null then 0 when f.amount_dec is not null then f.amount_dec end as  amount_dec  from (SELECT a.MEDSTOREID_CHR,a.MEDICINEID_CHR,a.LOWLIMIT_DEC,a.PLANQTY_DEC,a.UNITID_CHR,
                                     b.medstorename_vchr, 
									 c.medicinename_vchr, c.medspec_vchr,
									 e.amount_dec,c.ASSISTCODE_CHR,c.PYCODE_CHR,c.WBCODE_CHR
								FROM t_bse_medstorelimit a left join T_BSE_STORAGEMEDICINE e on e.FLAG_INT=1 and e.STORAGEID_CHR='" + stroageID + "' and e.MEDICINEID_CHR=a.MEDICINEID_CHR," + "t_bse_medstore b,t_bse_medicine c WHERE a.medstoreid_chr = b.medstoreid_chr AND a.medicineid_chr = c.medicineid_chr and a.MEDSTOREID_CHR='" + stroageID + "') f where f.amount_dec<=f.LOWLIMIT_DEC or f.amount_dec is null";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #endregion

        #region 新增药房领药申请记录单
        /// <summary>
        /// 新增药房领药申请记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房领药申请记录单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedAppl(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreMedAppl_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAddNewMedAppl");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_opr_medstoremedappl
										  (medapplid_chr, applmedstoreid_chr, appldate_dat,
										   memo_vchr, creator_chr, medstorageid_chr, pstatus_int
										  )
								   VALUES ('" + p_objItem.m_strMedApplID.Trim() + "', '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "', TO_DATE ('" + p_objItem.m_strApplDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"				   '" + p_objItem.m_strMemo.Trim() + "', '" + p_objItem.m_objCreator.strEmpID.Trim() + "', '" + p_objItem.m_objStorage.m_strStroageID.Trim() + "', " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"				  )";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 修改药房领药申请记录单
        /// <summary>
        /// 修改药房领药申请记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房领药申请记录单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateMedAppl(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreMedAppl_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedAppl");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstoremedappl
								 SET appldate_dat = TO_DATE ('" + p_objItem.m_strApplDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 memo_vchr = '" + p_objItem.m_strMemo.Trim() + "', ";
            strSQL += @"			 creator_chr = '" + p_objItem.m_objCreator.strEmpID.Trim() + "', ";
            strSQL += @"		     medstorageid_chr = '" + p_objItem.m_objStorage.m_strStroageID.Trim() + "', ";
            strSQL += @"			 pstatus_int = " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"       WHERE TRIM(medapplid_chr) = '" + p_objItem.m_strMedApplID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 删除药房领药申请记录单
        /// <summary>
        /// 删除药房领药申请记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">记录单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedAppl(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngDeleteMedAppl");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE t_opr_medstoremedappl
							   WHERE TRIM(medapplid_chr) = '" + p_strID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 新增药房领药申请明细单记录
        /// <summary>
        /// 新增药房领药申请明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房领药申请明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedApplDe(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreMedApplDe_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAddNewMedApplDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_opr_medstoremedapplde
										  (medapplid_chr, medappldeid_chr, syslotno_chr, medicineid_chr,
										   rowno_chr, appldate_dat, unitid_chr, qty_dec
										  )
								   VALUES ('" + p_objItem.m_strMedApplID.Trim() + "', '" + p_objItem.m_strMedApplDeID.Trim() + "', '" + p_objItem.m_strSysLotNo.Trim() + "', '" + p_objItem.m_objMedicine.m_strMedicineID.Trim() + "', ";
            strSQL += @"				   '" + p_objItem.m_strRowNo.Trim() + "', TO_DATE ('" + p_objItem.m_strApplDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), '" + p_objItem.m_objUnit.m_strUnitID.Trim() + "', " + p_objItem.m_decQty.ToString() + " ";
            strSQL += @"				  )";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 修改药房领药申请明细单记录
        /// <summary>
        /// 修改药房领药申请明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房领药申请明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateMedApplDe(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreMedApplDe_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedApplDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstoremedapplde
								 SET rowno_chr = '" + p_objItem.m_strRowNo.Trim() + "', ";
            strSQL += @"			 unitid_chr = '" + p_objItem.m_objUnit.m_strUnitID.Trim() + "', ";
            strSQL += @"			 qty_dec = " + p_objItem.m_decQty.ToString() + " ";
            strSQL += @"	   WHERE TRIM(medappldeid_chr) = '" + p_objItem.m_strMedApplDeID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 删除药房领药申请明细单记录
        /// <summary>
        /// 删除药房领药申请明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">明细单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedApplDe(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngDeleteMedApplDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE t_opr_medstoremedapplde
							   WHERE TRIM(medappldeid_chr) = '" + p_strID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 模糊查询药房领药申请记录单
        /// <summary>
        /// 模糊查询药房领药申请记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplByAny(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSQL, out clsMedStoreMedAppl_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedAppl_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplByAny");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT *
							    FROM v_opr_medstoremedappl
							 " + p_strSQL;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    if (intRow > 0)
                    {
                        p_objResultArr = new clsMedStoreMedAppl_VO[intRow];
                        for (int i = 0; i < intRow; i++)
                        {
                            p_objResultArr[i] = new clsMedStoreMedAppl_VO();
                            p_objResultArr[i].m_objMedStore = new clsMedStore_VO();
                            p_objResultArr[i].m_objStorage = new clsStorage_VO();
                            p_objResultArr[i].m_objCreator = new clsEmployeeVO();

                            p_objResultArr[i].m_strMedApplID = dtbResult.Rows[i]["medapplid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_strMedStoreID = dtbResult.Rows[i]["applmedstoreid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_strMedStoreName = dtbResult.Rows[i]["medstorename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_intMedStoreType = Convert.ToInt32(dtbResult.Rows[i]["medstoretype_int"].ToString().Trim());
                            p_objResultArr[i].m_objMedStore.m_intMedicneType = Convert.ToInt32(dtbResult.Rows[i]["medicnetype_int"].ToString().Trim());
                            p_objResultArr[i].m_strApplDate = dtbResult.Rows[i]["appldate_dat"].ToString().Trim();
                            p_objResultArr[i].m_strMemo = dtbResult.Rows[i]["memo_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objCreator.strEmpID = dtbResult.Rows[i]["creator_chr"].ToString().Trim();
                            p_objResultArr[i].m_objCreator.strLastName = dtbResult.Rows[i]["lastname_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objStorage.m_strStroageID = dtbResult.Rows[i]["medstorageid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objStorage.m_strStroageName = dtbResult.Rows[i]["storagename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_intPStatus = Convert.ToInt32(dtbResult.Rows[i]["pstatus_int"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 按记录单ID查询药房领药申请记录单
        /// <summary>
        /// 按记录单ID查询药房领药申请记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">记录单ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplByID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreMedAppl_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedAppl_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplByID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " WHERE TRIM(medapplid_chr) = '" + p_strID.Trim() + "' ";

            lngRes = m_lngGetMedApplByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按药房查询药房领药申请记录单
        /// <summary>
        /// 按药房查询药房领药申请记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplByMedStore(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreMedAppl_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedAppl_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplByMedStore");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " WHERE TRIM(applmedstoreid_chr) = '" + p_strID.Trim() + "' ";

            lngRes = m_lngGetMedApplByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按申请药库查询药房领药申请单
        /// <summary>
        /// 按申请药库查询药房领药申请单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">库房ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplByStorage(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreMedAppl_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedAppl_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplByStorage");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " WHERE TRIM(medstorageid_chr) = '" + p_strID.Trim() + "' ";

            lngRes = m_lngGetMedApplByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按申请时间查询药房领药申请单
        /// <summary>
        /// 按申请时间查询药房领药申请单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strStartDate">开始时间</param>
        /// <param name="p_strEndDate">结束时间</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplByDate(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strStartDate, string p_strEndDate, out clsMedStoreMedAppl_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedAppl_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplByDate");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " WHERE appldate_dat >= TO_DATE('" + p_strStartDate.Trim() + "','yyyy-mm-dd hh24:mi:ss'),appldate_dat <= TO_DATE('" + p_strEndDate.Trim() + "','yyyy-mm-dd hh24:mi:ss')";

            lngRes = m_lngGetMedApplByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按状态标志查询药房领药申请单
        /// <summary>
        /// 按状态标志查询药房领药申请单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_intStatus">状态标识</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplByStatus(System.Security.Principal.IPrincipal p_objPrincipal,
            int p_intStatus, out clsMedStoreMedAppl_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedAppl_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplByStatus");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " WHERE pstatus_int = " + p_intStatus.ToString() + " ";

            lngRes = m_lngGetMedApplByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 模糊查询药房领药申请明细单
        /// <summary>
        /// 模糊查询药房领药申请明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplDeByAny(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSQL, out clsMedStoreMedApplDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedApplDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplDeByAny");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT *
							    FROM v_opr_medstoremedapplde
							 " + p_strSQL;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    if (intRow > 0)
                    {
                        p_objResultArr = new clsMedStoreMedApplDe_VO[intRow];
                        for (int i = 0; i < intRow; i++)
                        {
                            p_objResultArr[i] = new clsMedStoreMedApplDe_VO();
                            p_objResultArr[i].m_objMedicine = new clsMedicine_VO();
                            p_objResultArr[i].m_objUnit = new clsUnit_VO();

                            p_objResultArr[i].m_strMedApplID = dtbResult.Rows[i]["medapplid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strMedApplDeID = dtbResult.Rows[i]["medappldeid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strSysLotNo = dtbResult.Rows[i]["syslotno_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineID = dtbResult.Rows[i]["medicineid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineName = dtbResult.Rows[i]["medicinename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineEngName = dtbResult.Rows[i]["medicineengname_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strPYCode = dtbResult.Rows[i]["pycode_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strWBCode = dtbResult.Rows[i]["wbcode_chr"].ToString().Trim();
                            p_objResultArr[i].m_strRowNo = dtbResult.Rows[i]["rowno_chr"].ToString().Trim();
                            p_objResultArr[i].m_strApplDate = dtbResult.Rows[i]["appldate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objUnit.m_strUnitID = dtbResult.Rows[i]["unitid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objUnit.m_strUnitName = dtbResult.Rows[i]["unitname_chr"].ToString().Trim();
                            p_objResultArr[i].m_decQty = Convert.ToDecimal(dtbResult.Rows[i]["qty_dec"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 按领药申请记录单ID查询药房领药申请明细单
        /// <summary>
        /// 按领药申请记录单ID查询药房领药申请明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">记录单ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplDeByApplID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreMedApplDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedApplDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplDeByApplID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " WHERE TRIM(medapplid_chr) = '" + p_strID.Trim() + "' ";
            lngRes = m_lngGetMedApplDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按药品查询药房领药申请明细单
        /// <summary>
        /// 按药品查询药房领药申请明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药品ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedApplDeByMedicine(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreMedApplDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreMedApplDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedApplDeByMedicine");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " WHERE TRIM(medicineid_chr) = '" + p_strID.Trim() + " ";
            lngRes = m_lngGetMedApplDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 自动获得领药申请单
        /// <summary>
        /// 自动生成采购单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房ID</param>
        /// <param name="p_objResult">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAutoCalcMedAppl(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreMedApplDe_VO[] p_objResult)
        {
            long lngRes = 0;
            p_objResult = new clsMedStoreMedApplDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAutoCalcMedAppl");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = new DataTable();
            string strSQL = @"SELECT a.*, b.medstorename_vchr, b.medstoretype_int, b.medicnetype_int,
									 c.medicinename_vchr, c.medspec_vchr, d.unitname_chr,
									 a.lowlimit_dec - e.amount_dec AS qty
								FROM t_bse_medstorelimit a,
									 t_bse_medstore b,
									 t_bse_medicine c,
									 t_aid_unit d,
									 t_tol_medstoremedicine e
							   WHERE a.medstoreid_chr = b.medstoreid_chr
								 AND a.medicineid_chr = c.medicineid_chr
								 AND a.unitid_chr = d.unitid_chr(+)
							     AND a.medstoreid_chr = e.medstoreid_chr
								 AND a.medicineid_chr = e.medicineid_chr
								 AND e.amount_dec < a.lowlimit_dec ";
            strSQL += @" AND a.medstoreid_chr = '" + p_strID.Trim() + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);



                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    p_objResult = new clsMedStoreMedApplDe_VO[intRow];
                    for (int i = 0; i < intRow; i++)
                    {
                        p_objResult[i] = new clsMedStoreMedApplDe_VO();
                        p_objResult[i].m_objMedicine = new clsMedicine_VO();
                        p_objResult[i].m_objUnit = new clsUnit_VO();
                        int RowNo = i + 1;
                        p_objResult[i].m_strRowNo = RowNo.ToString("0000");
                        p_objResult[i].m_objMedicine.m_strMedicineID = dtbResult.Rows[i]["medicineid_chr"].ToString().Trim();
                        p_objResult[i].m_objMedicine.m_strMedicineName = dtbResult.Rows[i]["medicinename_vchr"].ToString().Trim();
                        p_objResult[i].m_objMedicine.m_strMedSpec = dtbResult.Rows[i]["medspec_vchr"].ToString().Trim();
                        p_objResult[i].m_objUnit.m_strUnitID = dtbResult.Rows[i]["unitid_chr"].ToString().Trim();
                        p_objResult[i].m_objUnit.m_strUnitName = dtbResult.Rows[i]["unitname_chr"].ToString().Trim();
                        p_objResult[i].m_strSysLotNo = DateTime.Now.ToString("yyyyMMddHHmmss");
                        p_objResult[i].m_decQty = Convert.ToDecimal(dtbResult.Rows[i]["qty"].ToString().Trim());
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #endregion

        #region 药房盘点

        #region 新系统
        #region 获得所有的盘点数据
        /// <summary>
        /// 获得所有的盘点数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtStorData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckStore(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtStorData)
        {
            long lngRes = 0;
            dtStorData = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngGetCheckStore");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.*,b.MEDICINENAME_VCHR,b.MEDSPEC_VCHR,b.OPUNIT_CHR,b.UNITPRICE_MNY,c.MEDSTORENAME_VCHR from t_tol_medstoremedicine a,t_bse_medicine b,t_bse_medstore c where a.MEDICINEID_CHR=b.MEDICINEID_CHR  and a.MEDSTOREID_CHR=c.MEDSTOREID_CHR";
            try
            {
                dtStorData = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtStorData);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 自动生成出入库单
        /// <summary>
        /// 自动生成出入库单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="dtStorCheckData">自动生成的入库数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAutoGreat(System.Security.Principal.IPrincipal p_objPrincipal, DataTable dtStorCheckData)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngGetCheckStore");
            if (lngRes < 0)
            {
                return -1;
            }
            string newid;
            string newDeid;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            //com.digitalwave.iCare.middletier.HIS.clsHisBase  HisBase=new clsHisBase();
            DateTime nowData = System.DateTime.Now.Date;//HisBase.s_GetServerDate().Date;
            string strSQL = @"select * from t_bse_period";
            DataTable periodTable = new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref periodTable);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes == 0 || periodTable.Rows.Count == 0)
                return -3;
            string nowperodID = "";
            for (int i1 = 0; i1 < periodTable.Rows.Count; i1++)
            {
                if (nowData >= Convert.ToDateTime(periodTable.Rows[i1]["STARTDATE_DAT"]) && nowData <= Convert.ToDateTime(periodTable.Rows[i1]["ENDDATE_DAT"]))
                    nowperodID = (string)periodTable.Rows[i1]["PERIODID_CHR"];
            }
            if (nowperodID == "")
                return -3;

            for (int i1 = 0; i1 < dtStorCheckData.Rows.Count; i1++)
            {
                newid = objHRPSvc.m_strGetNewID("t_opr_medstoreord", "MEDSTOREORDID_CHR", 18);
                strSQL = @"insert into t_opr_medstoreord(MEDSTOREORDID_CHR,MEDSTOREID_CHR,ORDDATE_DAT,TOLMNY_MNY,MEMO_VCHR,CREATOR_CHR," +
                    "CREATEDATE_DAT,MEDSTOREORDTYPEID_CHR,PSTATUS_INT,OUTFLAN_INT,PERIODID_CHR) values('" + newid + "','"
                    + dtStorCheckData.Rows[i1]["MEDSTOREID_CHR"].ToString() + "',To_Date('" + dtStorCheckData.Rows[i1]["ORDDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss')," + dtStorCheckData.Rows[i1]["TOLMNY_MNY"].ToString() + ",'" + dtStorCheckData.Rows[i1]["MEMO_VCHR"].ToString() + "','"
                    + dtStorCheckData.Rows[i1]["CREATOR_CHR"].ToString() + "',To_Date('" + dtStorCheckData.Rows[i1]["CREATEDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'"
                    + dtStorCheckData.Rows[i1]["MEDSTOREORDTYPEID_CHR"].ToString() + "',1," + dtStorCheckData.Rows[i1]["OUTFLAN_INT"].ToString() + ",'" + nowperodID + "')";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (lngRes > 0)
                {
                    newDeid = objHRPSvc.m_strGetNewID("t_opr_medstoreordde", "MEDSTOREORDDEID_CHR", 18);
                    strSQL = @"insert into t_opr_medstoreordde(MEDSTOREORDDEID_CHR,MEDSTOREORDID_CHR,MEDICINEID_CHR,ROWNO_CHR,QTY_DEC,SALEUNITPRICE_DEC,SALETOLPRICE_DEC,UNITID_CHR)"
                        + " values('" + newDeid + "','" + newid + "','" + dtStorCheckData.Rows[i1]["MEDICINEID_CHR"].ToString() + "','0001',"
                        + dtStorCheckData.Rows[i1]["QTY_DEC"].ToString() + "," + dtStorCheckData.Rows[i1]["SALEUNITPRICE_DEC"].ToString() + ","
                        + dtStorCheckData.Rows[i1]["SALETOLPRICE_DEC"].ToString() + ",'" + dtStorCheckData.Rows[i1]["UNITID_CHR"].ToString() + "')";
                    try
                    {
                        lngRes = objHRPSvc.DoExcute(strSQL);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }
            }

            return lngRes;
        }
        #endregion

        #region 判断是否设置有盘点出库或入库的单据类型
        /// <summary>
        /// 判断是否设置有盘点出库或入库的单据类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="typeName">出入库类型名称</param>
        /// <param name="typeID">返回单据类型ID</param>
        /// <returns>2有，3则是该类型在更新库类别中不存在</returns>
        [AutoComplete]
        public long m_lngisCheckType(System.Security.Principal.IPrincipal p_objPrincipal, string typeName, out string typeID)
        {
            long lngRes = 0;
            typeID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngGetCheckStore");
            if (lngRes < 0)
            {
                return -1;
            }
            DataTable dtResult = new DataTable();
            string strSQL = @"select MEDSTOREORDTYPEID_CHR from t_aid_medstoreordtype where MEDSTOREORDTYPE_VCHR='" + typeName + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtResult);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtResult.Rows.Count == 0)
                lngRes = 3;
            if (lngRes > 0 && dtResult.Rows.Count > 0)
            {
                typeID = dtResult.Rows[0]["MEDSTOREORDTYPEID_CHR"].ToString();
                lngRes = 2;
            }
            return lngRes;
        }
        #endregion

        #endregion

        #region 新增药房盘点记录单
        /// <summary>
        /// 新增药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房盘点记录数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedStoreCheck(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreCheck_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAddNewMedStoreCheck");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_opr_medstorecheck
										  (checkid_chr, checkdate_dat, remark_vchr,
										   medstoreid_chr, periodid_chr, creator_chr,
										   createdate_dat, aduitemp_chr,
										   aduitdate_dat, acctemp_chr,
										   acctdate_dat, pstatus_int
										  )
								   VALUES ('" + p_objItem.m_strCheckID.Trim() + "', TO_DATE ('" + p_objItem.m_strCheckDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), '" + p_objItem.m_strRemark.Trim() + "', ";
            strSQL += @"				   '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "', '" + p_objItem.m_objPeriod.m_strPeriodID.Trim() + "', '" + p_objItem.m_objCreator.strEmpID.Trim() + "', ";
            strSQL += @"				   TO_DATE ('" + p_objItem.m_strCreateDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), '" + p_objItem.m_objAduitEmp.strEmpID.Trim() + "', ";
            strSQL += @"				   TO_DATE ('" + p_objItem.m_strAduitDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), '" + p_objItem.m_objAcctEmp.strEmpID.Trim() + "', ";
            strSQL += @"				   TO_DATE ('" + p_objItem.m_strAcctDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"				  )";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 修改药房盘点记录单
        /// <summary>
        /// 修改药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房盘点记录数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateMedStoreCheck(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreCheck_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedStoreCheck");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstorecheck
								 SET checkdate_dat = TO_DATE ('" + p_objItem.m_strCheckDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 remark_vchr = '" + p_objItem.m_strRemark.Trim() + "', ";
            strSQL += @"			 pstatus_int = " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"	   WHERE TRIM(checkid_chr) = '" + p_objItem.m_strCheckID.Trim() + "' AND TRIM(medstoreid_chr) = '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "' AND TRIM(period_chr) = '" + p_objItem.m_objPeriod.m_strPeriodID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 删除药房盘点记录单
        /// <summary>
        /// 删除药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房盘点记录单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedStoreCheck(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngDeleteMedStoreCheck");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE t_opr_medstorecheck
							   WHERE TRIM(checkid_chr) = '" + p_strID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 审核药房盘点记录单
        /// <summary>
        /// 审核药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房盘点记录单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAduitMedStoreCheck(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreCheck_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAduitMedStoreCheck");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstoreord
								 SET aduitemp_chr = '" + p_objItem.m_objAduitEmp.strEmpID.Trim() + "', ";
            strSQL += @"			 aduitdate_dat = TO_DATE ('" + p_objItem.m_strAduitDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 pstatus_int = " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"	   WHERE TRIM(checkid_chr) = '" + p_objItem.m_strCheckID.Trim() + "' AND TRIM(medstoreid_chr) = '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 审核药房盘点记录单后更改库存
        /// <summary>
        /// 审核药房盘点记录单后更改库存
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房盘点记录单ID</param>
        /// <param name="p_intFlag">标识，1：成功，0：失败，-1：异常</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangeStorageAfterAduitMedStoreCheck(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out int p_intFlag)
        {
            long lngRes = 0;
            p_intFlag = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngChangeStorageAfterAduitMedStoreCheck");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                string strProcedure = "P_MEDSTORECHECKADUIT";
                com.digitalwave.iCare.ValueObject.clsSQLParamDefinitionVO[] objParams = new clsSQLParamDefinitionVO[2];

                for (int i = 0; i < objParams.Length; i++)
                {
                    objParams[i] = new clsSQLParamDefinitionVO();
                }
                objParams[0].objParameter_Value = p_strID;
                objParams[0].strParameter_Type = clsOracleDbType.strVarchar2;
                objParams[0].strParameter_Name = "checkid";

                objParams[1].strParameter_Type = clsOracleDbType.strInt32;
                objParams[1].strParameter_Direction = clsDirection.strOutput;
                objParams[1].strParameter_Name = "flag";


                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngExecuteParameterProc(strProcedure, objParams);
                p_intFlag = int.Parse(objParams[1].objParameter_Value.ToString().Trim());

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 药房盘点记录单登帐
        /// <summary>
        /// 药房盘点记录单登帐
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房盘点记录单数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAcctMedStoreCheck(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreCheck_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAcctMedStoreCheck");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstorecheck
								 SET acctemp_chr = '" + p_objItem.m_objAcctEmp.strEmpID.Trim() + "', ";
            strSQL += @"			 acctdate_dat = TO_DATE ('" + p_objItem.m_strAcctDate.Trim() + "', 'yyyy-mm-dd hh24:mi:ss'), ";
            strSQL += @"			 pstatus_int = " + p_objItem.m_intPStatus.ToString() + " ";
            strSQL += @"	   WHERE TRIM(checkid_chr) = '" + p_objItem.m_strCheckID.Trim() + "' AND TRIM(medstoreid_chr) = '" + p_objItem.m_objMedStore.m_strMedStoreID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 药房盘点记录单登帐后更改帐务
        /// <summary>
        /// 药房盘点记录单登帐后更改帐务
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房盘点记录单ID</param>
        /// <param name="p_intFlag">标识，1：成功，0：失败，-1：异常</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangeFinAfterAcctMedStoreCheck(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out int p_intFlag)
        {
            long lngRes = 0;
            p_intFlag = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngChangeFinAfterAcctMedStoreCheck");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                string strProcedure = "P_MEDSTORECHECKACCT";
                com.digitalwave.iCare.ValueObject.clsSQLParamDefinitionVO[] objParams = new clsSQLParamDefinitionVO[2];

                for (int i = 0; i < objParams.Length; i++)
                {
                    objParams[i] = new clsSQLParamDefinitionVO();
                }
                objParams[0].objParameter_Value = p_strID;
                objParams[0].strParameter_Type = clsOracleDbType.strVarchar2;
                objParams[0].strParameter_Name = "checkid";

                objParams[1].strParameter_Type = clsOracleDbType.strInt32;
                objParams[1].strParameter_Direction = clsDirection.strOutput;
                objParams[1].strParameter_Name = "flag";


                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngExecuteParameterProc(strProcedure, objParams);
                p_intFlag = int.Parse(objParams[1].objParameter_Value.ToString().Trim());

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 新增药房盘点明细单记录
        /// <summary>
        /// 新增药房盘点明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房盘点明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedStoreCheckDe(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreCheckDe_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAddNewMedStoreCheckDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_opr_medstorecheckde
										  (checkid_chr, checkdetailid_chr, rowno_chr, medicineid_chr,
										   unitid_chr, calcqty_dec, realqty_dec, syslotno_chr,
										   curprice_mny, buyprice_mny
										  )
								   VALUES ('" + p_objItem.m_strCheckID.Trim() + "', '" + p_objItem.m_strCheckDetailID.Trim() + "', '" + p_objItem.m_strRowNo.Trim() + "', '" + p_objItem.m_objMedicine.m_strMedicineID.Trim() + "', ";
            strSQL += @"				   '" + p_objItem.m_objUnit.m_strUnitID.Trim() + "', " + p_objItem.m_decCalcQty.ToString() + ", " + p_objItem.m_decRealQty.ToString() + ", '" + p_objItem.m_strSysLotNo.Trim() + "', ";
            strSQL += @"				   " + p_objItem.m_decCurPrice.ToString() + ", " + p_objItem.m_decBuyPrice.ToString() + " ";
            strSQL += @"				  )";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 修改药房盘点明细单记录
        /// <summary>
        /// 修改药房盘点明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_objItem">药房盘点明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateMedStoreCheckDe(System.Security.Principal.IPrincipal p_objPrincipal,
            clsMedStoreCheckDe_VO p_objItem)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngUpdateMedStoreCheckDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_medstorecheckde
								 SET rowno_chr = '" + p_objItem.m_strRowNo.Trim() + "', ";
            strSQL += @"			 unitid_chr = '" + p_objItem.m_objUnit.m_strUnitID.Trim() + "', ";
            strSQL += @"			 realqty_dec = '" + p_objItem.m_decRealQty.ToString() + "' ";
            strSQL += @"	   WHERE TRIM(checkdetailid_chr) = '" + p_objItem.m_strCheckDetailID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 删除药房盘点明细单记录
        /// <summary>
        /// 删除药房盘点明细单记录
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房盘点明细ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedStoreCheckDe(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngAddNewMedStoreCheckDe");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE t_opr_medstorecheckde
							   WHERE TRIM(checkdetailid_chr) = '" + p_strID.Trim() + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            return lngRes;
        }
        #endregion

        #region 模糊查询药房盘点记录单
        /// <summary>
        /// 模糊查询药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckByAny(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSQL, out clsMedStoreCheck_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheck_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckByAny");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT *
							    FROM v_opr_medstorecheck
							 " + p_strSQL;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    if (intRow > 0)
                    {
                        p_objResultArr = new clsMedStoreCheck_VO[intRow];
                        for (int i = 0; i < intRow; i++)
                        {
                            p_objResultArr[i] = new clsMedStoreCheck_VO();
                            p_objResultArr[i].m_objMedStore = new clsMedStore_VO();
                            p_objResultArr[i].m_objPeriod = new clsPeriod_VO();
                            p_objResultArr[i].m_objCreator = new clsEmployeeVO();
                            p_objResultArr[i].m_objAduitEmp = new clsEmployeeVO();
                            p_objResultArr[i].m_objAcctEmp = new clsEmployeeVO();

                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["checkid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckDate = dtbResult.Rows[i]["checkdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_strRemark = dtbResult.Rows[i]["remark_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_strMedStoreID = dtbResult.Rows[i]["medstoreid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_strMedStoreName = dtbResult.Rows[i]["medstorename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_intMedStoreType = Convert.ToInt32(dtbResult.Rows[i]["medstoretype_int"].ToString().Trim());
                            p_objResultArr[i].m_objMedStore.m_intMedicneType = Convert.ToInt32(dtbResult.Rows[i]["medicnetype_int"].ToString().Trim());
                            p_objResultArr[i].m_objPeriod.m_strPeriodID = dtbResult.Rows[i]["periodid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objPeriod.m_strStartDate = dtbResult.Rows[i]["startdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objPeriod.m_strEndDate = dtbResult.Rows[i]["enddate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objCreator.strEmpID = dtbResult.Rows[i]["creator_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCreateDate = dtbResult.Rows[i]["createdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objAduitEmp.strEmpID = dtbResult.Rows[i]["aduitemp_chr"].ToString().Trim();
                            p_objResultArr[i].m_strAduitDate = dtbResult.Rows[i]["aduitdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objAcctEmp.strEmpID = dtbResult.Rows[i]["acctemp_chr"].ToString().Trim();
                            p_objResultArr[i].m_strAcctDate = dtbResult.Rows[i]["acctdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_intPStatus = Convert.ToInt32(dtbResult.Rows[i]["pstatus_int"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 按盘点单ID查询药房盘点记录单
        /// <summary>
        /// 按盘点单ID查询药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">盘点单ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckByID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreCheck_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheck_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckByID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(checkid_chr) = '" + p_strID.Trim() + " ";

            lngRes = m_lngGetMedStoreCheckByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按药房查询药房盘点记录单
        /// <summary>
        /// 按药房查询药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckByMedStore(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreCheck_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheck_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckByMedStore");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medstoreid_chr) = '" + p_strID.Trim() + " ";

            lngRes = m_lngGetMedStoreCheckByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按盘点时间查询药房盘点记录单
        /// <summary>
        /// 按盘点时间查询药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strStartDate">开始时间</param>
        /// <param name="p_strEndDate">结束时间</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckByDate(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strStartDate, string p_strEndDate, out clsMedStoreCheck_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheck_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckByDate");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE checkdate_dat >= TO_DATE('" + p_strStartDate.Trim() + "','yyyy-mm-dd hh24:mi:ss'), checkdate_dat <= TO_DATE('" + p_strEndDate + "','yyyy-mm-dd hh24:mi:ss') ";

            lngRes = m_lngGetMedStoreCheckByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按帐务期查询药房盘点记录单
        /// <summary>
        /// 按帐务期查询药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">帐务期ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckByPeriod(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreCheck_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheck_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckByPeriod");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(periodid_chr) = '" + p_strID.Trim() + "' ";

            lngRes = m_lngGetMedStoreCheckByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按单据标志查询药房盘点记录单
        /// <summary>
        /// 按单据标志查询药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_intStatus">状态标志</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckByStatus(System.Security.Principal.IPrincipal p_objPrincipal,
            int p_intStatus, out clsMedStoreCheck_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheck_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckByStatus");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE pstatus_int = " + p_intStatus.ToString() + " ";

            lngRes = m_lngGetMedStoreCheckByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 模糊查询药房盘点明细单
        /// <summary>
        /// 模糊查询药房盘点记录单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckDeByAny(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSQL, out clsMedStoreCheckDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheckDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckDeByAny");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT *
							    FROM v_opr_medstorecheckde
							 " + p_strSQL;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    if (intRow > 0)
                    {
                        p_objResultArr = new clsMedStoreCheckDe_VO[intRow];
                        for (int i = 0; i < intRow; i++)
                        {
                            p_objResultArr[i] = new clsMedStoreCheckDe_VO();
                            p_objResultArr[i].m_objMedicine = new clsMedicine_VO();
                            p_objResultArr[i].m_objUnit = new clsUnit_VO();

                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["checkid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["checkdetailid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["rowno_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["medicineid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["medicinename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["medicineengname_vchr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["pycode_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["wbcode_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["unitid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["unitname_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["calcqty_dec"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["realqty_dec"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["syslotno_chr"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["curprice_mny"].ToString().Trim();
                            p_objResultArr[i].m_strCheckID = dtbResult.Rows[i]["buyprice_mny"].ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 按记录单ID查询药房盘点明细单
        /// <summary>
        /// 按记录单ID查询药房盘点明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">盘点记录单ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckDeByCheckID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreCheckDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheckDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckDeByCheckID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(checkid_chr) = '" + p_strID.Trim() + "'";

            lngRes = m_lngGetMedStoreCheckDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按药品查询药房盘点明细单
        /// <summary>
        /// 按药品查询药房盘点明细单
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药品ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckDeByMedicine(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreCheckDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreCheckDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckDeByMedicine");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medicineid_chr) = '" + p_strID.Trim() + "'";

            lngRes = m_lngGetMedStoreCheckDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 获取当前最大的药房盘点记录单ID
        /// <summary>
        /// 获取当前最大的药房盘点记录单ID
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房盘点记录单ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckID(System.Security.Principal.IPrincipal p_objPrincipal,
            out string p_strID)
        {
            long lngRes = 0;
            p_strID = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckID");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                p_strID = objHRPSvc.m_strGetNewID("t_opr_medstorecheck", "checkid_chr", 14);


                if (p_strID != null)
                {
                    if (Convert.ToInt32(p_strID.Trim()) <= 0)
                    {
                        int ID = Convert.ToInt32(p_strID.Trim()) + 1;
                        p_strID = ID.ToString("00000000000000");
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 获取当前最大的盘点明细单ID
        /// <summary>
        /// 获取当前最大的盘点明细单ID
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房盘点明细ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreCheckDeID(System.Security.Principal.IPrincipal p_objPrincipal,
            out string p_strID)
        {
            long lngRes = 0;
            p_strID = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreCheckDeID");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                p_strID = objHRPSvc.m_strGetNewID("t_opr_medstorecheckde", "checkdetailid_chr", 18);


                if (p_strID != null)
                {
                    if (Convert.ToInt32(p_strID.Trim()) <= 0)
                    {
                        int ID = Convert.ToInt32(p_strID.Trim()) + 1;
                        p_strID = ID.ToString("000000000000000000");
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #endregion

        #region 药房明细帐

        #region 模糊查询药房明细帐
        /// <summary>
        /// 模糊查询药房明细帐
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdFinDeByAny(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSQL, out clsMedStoreOrdFinDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdFinDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdFinDeByAny");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT *
							    FROM v_opr_medstoreordfinde
							 " + p_strSQL;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    if (intRow > 0)
                    {
                        p_objResultArr = new clsMedStoreOrdFinDe_VO[intRow];
                        for (int i = 0; i < intRow; i++)
                        {
                            p_objResultArr[i] = new clsMedStoreOrdFinDe_VO();
                            p_objResultArr[i].m_objMedStore = new clsMedStore_VO();
                            p_objResultArr[i].m_objPeriod = new clsPeriod_VO();
                            p_objResultArr[i].m_objOperator = new clsEmployeeVO();

                            p_objResultArr[i].m_objMedStore.m_strMedStoreID = dtbResult.Rows[i]["medstoreid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_strMedStoreName = dtbResult.Rows[i]["medstorename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_intMedStoreType = Convert.ToInt32(dtbResult.Rows[i]["medstoretype_int"].ToString().Trim());
                            p_objResultArr[i].m_objMedStore.m_intMedicneType = Convert.ToInt32(dtbResult.Rows[i]["medicnetype_int"].ToString().Trim());
                            p_objResultArr[i].m_strMedStoreOrdID = dtbResult.Rows[i]["medstoreordid_chr"].ToString().Trim();
                            p_objResultArr[i].m_strMedStoreOrdType = dtbResult.Rows[i]["medstoreordtypeid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineID = dtbResult.Rows[i]["medicineid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineName = dtbResult.Rows[i]["medicinename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineEngName = dtbResult.Rows[i]["medicineengname_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strPYCode = dtbResult.Rows[i]["pycode_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strWBCode = dtbResult.Rows[i]["wbcode_chr"].ToString().Trim();
                            p_objResultArr[i].m_strSyslotNo = dtbResult.Rows[i]["syslotno_chr"].ToString().Trim();
                            p_objResultArr[i].m_objPeriod.m_strPeriodID = dtbResult.Rows[i]["periodid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objPeriod.m_strStartDate = dtbResult.Rows[i]["startdate_dat"].ToString().Trim();
                            p_objResultArr[i].m_objPeriod.m_strEndDate = dtbResult.Rows[i]["enddate_dat"].ToString().Trim();
                            p_objResultArr[i].m_decQty = Convert.ToDecimal(dtbResult.Rows[i]["qty_dec"].ToString().Trim());
                            p_objResultArr[i].m_decBorrow = Convert.ToDecimal(dtbResult.Rows[i]["borrow_mny"].ToString().Trim());
                            p_objResultArr[i].m_decLoan = Convert.ToDecimal(dtbResult.Rows[i]["loan_mny"].ToString().Trim());
                            p_objResultArr[i].m_objOperator.strEmpID = dtbResult.Rows[i]["operator_chr"].ToString().Trim();
                            p_objResultArr[i].m_objOperator.strLastName = dtbResult.Rows[i]["lastname_vchr"].ToString().Trim();
                            p_objResultArr[i].m_strCreateDate = dtbResult.Rows[i]["createdate_dat"].ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 按药房查询药房明细帐
        /// <summary>
        /// 按药房查询药房明细帐
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdFinDeByMedStore(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrdFinDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdFinDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdFinDeByMedStore");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medstoreid_chr) = '" + p_strID.Trim() + "'";

            lngRes = m_lngGetMedStoreOrdFinDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按单据类型查询药房明细帐
        /// <summary>
        /// 按单据类型查询药房明细帐
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">单据类型ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdFinDeByOrdType(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrdFinDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdFinDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdFinDeByOrdType");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medstoreordtypeid_chr) = '" + p_strID.Trim() + "'";

            lngRes = m_lngGetMedStoreOrdFinDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按单据类型和单据号查询药房明细帐
        /// <summary>
        /// 按单据类型和单据号查询药房明细帐
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">单据号</param>
        /// <param name="p_strOrdTypeID">单据类型ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdFinDeByOrdIDAndOrdType(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, string p_strOrdTypeID, out clsMedStoreOrdFinDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdFinDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdFinDeByOrdIDAndOrdType");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medstoreordid_chr) = '" + p_strID.Trim() + "' AND TRIM(medstoreordtypeid_chr) = '" + p_strOrdTypeID.Trim() + "'";

            lngRes = m_lngGetMedStoreOrdFinDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按帐务期查询药房明细帐
        /// <summary>
        /// 按帐务期查询药房明细帐
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">帐务期ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdFinDePeriod(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrdFinDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdFinDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdFinDePeriod");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(periodid_chr) = '" + p_strID.Trim() + "'";

            lngRes = m_lngGetMedStoreOrdFinDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按药品查询药房明细帐
        /// <summary>
        /// 按药品查询药房明细帐
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药品ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreOrdFinDeMedicine(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreOrdFinDe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreOrdFinDe_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreOrdFinDeMedicine");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" WHERE TRIM(medicineid_chr) = '" + p_strID.Trim() + "'";

            lngRes = m_lngGetMedStoreOrdFinDeByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #endregion

        #region 药房库存

        #region 模糊查询药房明细库存
        /// <summary>
        /// 模糊查询药房明细库存
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreDetailByAny(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSQL, out clsMedStoreDetail_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreDetail_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreDetailByAny");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT a.*, b.medstorename_vchr, b.medstoretype_int, b.medicnetype_int,
									 c.medicinename_vchr, c.medicineengname_vchr, c.pycode_chr,
									 c.wbcode_chr
							    FROM t_opr_medstoredetail a, t_bse_medstore b, t_bse_medicine c
							   WHERE a.medstoreid_chr = b.medstoreid_chr AND a.medicineid_chr = c.medicineid_chr(+)
							 " + p_strSQL;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    int intRow = dtbResult.Rows.Count;
                    if (intRow > 0)
                    {
                        p_objResultArr = new clsMedStoreDetail_VO[intRow];
                        for (int i = 0; i < intRow; i++)
                        {
                            p_objResultArr[i] = new clsMedStoreDetail_VO();
                            p_objResultArr[i].m_objMedStore = new clsMedStore_VO();
                            p_objResultArr[i].m_objMedicine = new clsMedicine_VO();

                            p_objResultArr[i].m_objMedStore.m_strMedStoreID = dtbResult.Rows[i]["medstoreid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_strMedStoreName = dtbResult.Rows[i]["medstorename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedStore.m_intMedStoreType = Convert.ToInt32(dtbResult.Rows[i]["medstoretype_int"].ToString().Trim());
                            p_objResultArr[i].m_objMedStore.m_intMedicneType = Convert.ToInt32(dtbResult.Rows[i]["medicnetype_int"].ToString().Trim());
                            p_objResultArr[i].m_objMedicine.m_strMedicineID = dtbResult.Rows[i]["medicineid_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineName = dtbResult.Rows[i]["medicinename_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strMedicineEngName = dtbResult.Rows[i]["medicineengname_vchr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strPYCode = dtbResult.Rows[i]["pycode_chr"].ToString().Trim();
                            p_objResultArr[i].m_objMedicine.m_strWBCode = dtbResult.Rows[i]["wbcode_chr"].ToString().Trim();
                            p_objResultArr[i].m_strSysLotNo = dtbResult.Rows[i]["syslotno_chr"].ToString().Trim();
                            p_objResultArr[i].m_decQty = Convert.ToDecimal(dtbResult.Rows[i]["qty_dec"].ToString().Trim());

                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 按药房查询药房明细库存
        /// <summary>
        /// 按药房查询药房明细库存
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药房ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreDetailByMedStore(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreDetail_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreDetail_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreDetailByMedStore");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " AND TRIM(a.medstoreid_chr) = '" + p_strID.Trim() + "'";
            lngRes = m_lngGetMedStoreDetailByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 按药品查询药房明细库存
        /// <summary>
        /// 按药品查询药房明细库存
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">药品ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreDetailByMedicine(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, out clsMedStoreDetail_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedStoreDetail_VO[0];

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedStoreDetailByMedicine");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = " AND TRIM(a.medicineid_chr) = '" + p_strID.Trim() + "'";
            lngRes = m_lngGetMedStoreDetailByAny(p_objPrincipal, strSQL, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 模糊查询药房总库存
        #endregion

        #region 按药房查询药房总库存
        #endregion

        #region 按药品查询药房总库存
        #endregion

        #region 根据收费项目ID查找药品库存
        /// <summary>
        /// 根据收费项目ID查找药品库存
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="p_strID">收费项目ID</param>
        /// <param name="p_decQty">药品数量</param>
        /// <param name="p_blnResult">库存是否足：true为够，false为库存不够申请的数量</param>
        /// <param name="p_decResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckMedStoreMedicineStorageByID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strID, decimal p_decQty, out bool p_blnResult, out decimal p_decResult)
        {
            long lngRes = 0;
            p_blnResult = false;
            p_decResult = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngCheckMedStoreMedicineStorageByID");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtbResult = null;
            string strSQL = @"SELECT SUM (amount_dec) AS tolqty
								FROM t_tol_medstoremedicine
							   WHERE TRIM(medicineid_chr) = (SELECT TRIM(itemsrcid_vchr)
															   FROM t_bse_chargeitem
															  WHERE TRIM (itemid_chr) = '" + p_strID.Trim() + "')";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    p_decResult = Convert.ToDecimal(dtbResult.Rows[0]["tolqty"].ToString().Trim());
                    if ((p_decResult - p_decQty) >= 0)
                        p_blnResult = true;
                    else
                        p_blnResult = false;

                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #endregion

        #region 公共模块的方法
        [AutoComplete]
        public long m_lngGetMedicine(System.Security.Principal.IPrincipal p_objPrincipal,
            out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetMedicine");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT MEDICINEID_CHR,MEDICINENAME_VCHR,MEDSPEC_VCHR,OPUNIT_CHR FROM T_BSE_MEDICINE";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;

        }
        #endregion

        #region 根据药房ID查找药房信息及窗口信息
        /// <summary>
        /// 根据药房ID查找药房信息及窗口信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strID"></param>
        /// <param name="dtstroageMessage"></param>
        /// <param name="dtwindowsMessage"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageMessage(System.Security.Principal.IPrincipal p_objPrincipal,
            string strID, out DataTable dtstroageMessage, out DataTable dtwindowsMessage, int intStatus)
        {
            long lngRes = 0;
            dtstroageMessage = null;
            dtwindowsMessage = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngGetStorageMessage");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT MEDSTORENAME_VCHR,deptid_chr,case when MEDICNETYPE_INT=1 then '西药' when MEDICNETYPE_INT=2 then '中药' else '材料' end as MEDICNETYPE,URGENCE_INT  FROM T_BSE_MEDSTORE WHERE MEDSTOREID_CHR='" + strID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtstroageMessage);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes == 1 && dtstroageMessage.Rows.Count > 0)
            {
                strSQL = @"select * from t_bse_medstorewin where MEDSTOREID_CHR='" + strID + "' and WINDOWTYPE_INT=" + intStatus;
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtwindowsMessage);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            return lngRes;

        }

        #endregion

        #region 把发药单据设成无效单据
        /// <summary>
        /// 把发药单据设成无效单据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetNullityData(System.Security.Principal.IPrincipal p_objPrincipal,
            string strID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngSetNullityData");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"update t_opr_medrecipesend set PSTATUS_INT=3  WHERE OUTPATRECIPEID_CHR='" + strID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 取时间
        /// <summary>
        /// 取时间
        /// </summary>
        /// <param name="p_datatime"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetServerDate(out DateTime p_datatime)
        {
            long lngRes = 0;
            p_datatime = DateTime.Now;
            string strSQL = @"SELECT sysdate from dual";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0)
                {
                    p_datatime = Convert.ToDateTime(dtbResult.Rows[0][0].ToString());
                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;

        }
        #endregion

        #region 根据处方号查找发送处方序列ID
        /// <summary>
        /// 根据序列号获取处方发送表状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_lngSid"></param>
        /// <param name="m_strStatus"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeSendStatusBySid(System.Security.Principal.IPrincipal p_objPrincipal, long m_lngSid, out string m_strStatus)
        {
            long lngRes = 0;
            m_strStatus = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetRecipeSendStatusBySid");
            if (lngRes < 0)
            { return -1; }

            lngRes = 0;
            string strSQL = @"select  a.pstatus_int from t_opr_recipesend a where a.sid_int=?";
            try
            {
                DataTable dtbResult = new DataTable();
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_lngSid;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_strStatus = dtbResult.Rows[0]["pstatus_int"].ToString();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 取窗口信息
        /// <summary>
        /// 取窗口信息
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWindowInfo(out DataTable dtbResult, string p_strWINDOWID_CHR, string p_strMEDSTOREID_CHR)
        {
            long lngRes = 0;
            dtbResult = null;
            string strSQL = @"select * from t_bse_medstorewin where WINDOWID_CHR='" + p_strWINDOWID_CHR + "' and MEDSTOREID_CHR='" + p_strMEDSTOREID_CHR + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region GetSendMedInfo
        /// <summary>
        /// GetSendMedInfo
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetSendMedInfo(string recipeId)
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                Sql = @"select a.sid_int,
                               b.outpatrecipeid_chr as recipeid,
                               d.lastname_vchr      as patname,
                               a.sendwindowid_chr   as sendwindowid,
                               a.medstoreid_chr     as medstoreid,
                               d.birth_dat          as birthday
                          from t_opr_recipesend a
                         inner join t_opr_recipesendentry b
                            on a.sid_int = b.sid_int
                         inner join t_opr_outpatientrecipe c
                            on b.outpatrecipeid_chr = c.outpatrecipeid_chr
                         inner join t_bse_patient d
                            on c.patientid_chr = d.patientid_chr
                         where c.outpatrecipeid_chr = ?";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = recipeId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            }
            catch (Exception ex)
            {
                string strTmp = ex.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }
            return dt;
        }
        #endregion

        #region 判断是否已发药
        /// <summary>
        /// 判断是否已发药
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool IsSendMed(string sid)
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                Sql = @"select 1 from t_opr_recipesend t where t.sid_int = ? and t.pstatus_int = 3";
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = sid;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                string strTmp = ex.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }
            return false;
        }
        #endregion

        #region 写入执行记录
        /// <summary>
        /// 写入执行记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewNurseexecute(System.Security.Principal.IPrincipal p_objPrincipal, clst_opr_nurseexecute p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewNurseexecute");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            int p_strRecordID = 0;
            //lngRes = objHRPSvc.m_lngGenerateNewID("t_opr_nurseexecute","SEQ_INT",out p_strRecordID);
            //if(lngRes < 0)
            //    return lngRes;

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"insert into t_opr_nurseexecute
            (seq_int, business_int, tablename_vchr, outpatrecipeid_chr,
             rowno_chr, itemid_chr, exectimes_int, operatortype_int,
             operatorid_chr, exectime_dat, systime_dat, remark1_vchr,
             remark2_vchr, status_int
            )
           values (seq_nurseexecuteid.nextval, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?
            )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(13, out objLisAddItemRefArr);
                //objLisAddItemRefArr[0].Value = p_strRecordID;
                objLisAddItemRefArr[0].Value = p_objRecord.m_intBUSINESS_INT;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTABLENAME_VCHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strOUTPATRECIPEID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strROWNO_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strITEMID_CHR;
                objLisAddItemRefArr[5].Value = p_objRecord.m_intEXECTIMES_INT;
                objLisAddItemRefArr[6].Value = p_objRecord.m_intOPERATORTYPE_INT;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[8].Value = DateTime.Parse(strDateTime);
                objLisAddItemRefArr[9].Value = DateTime.Parse(strDateTime);
                objLisAddItemRefArr[10].Value = p_objRecord.m_strREMARK1_VCHR;
                objLisAddItemRefArr[11].Value = p_objRecord.m_strREMARK2_VCHR;
                objLisAddItemRefArr[12].Value = p_objRecord.m_intSTATUS_INT;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 报表SQL
        /// <summary>
        /// 药房月结报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="arrPrID">要统计的财务期列表</param>
        /// <param name="strUpPr">要统计的第一个财务期</param>
        /// <param name="dt">返回相应的财务期统计数据</param>
        /// <param name="strStorageID">要统计的仓库</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetReportmoth(System.Security.Principal.IPrincipal p_objPrincipal, System.Collections.ArrayList arrPrID, string strUpPr, out DataTable dt, string strStorageID)
        {
            long lngRes = 0;
            dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            //权限控制
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedicineSvc", "m_lngGetVendorData");
            if (lngRes < 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "";
            string strWhere = "";
            string strWhere2 = "";
            string strWhere1 = " and a.PERIODID_CHR='" + strUpPr + "' and a.STORAGEID_CHR='" + strStorageID + "'";
            if (arrPrID.Count > 0)
            {
                for (int i1 = 0; i1 < arrPrID.Count; i1++)
                {
                    strSQL = (string)arrPrID[i1];
                    if (i1 == 0)
                    {
                        strWhere = "  and (a.PERIODID_CHR='" + strSQL + "'";
                    }
                    else
                    {
                        strWhere += " or a.PERIODID_CHR='" + strSQL + "'";
                    }
                    if (i1 == arrPrID.Count - 1)
                    {
                        strWhere2 = @" and a.PERIODID_CHR='" + strSQL + "'";
                        strWhere += ")";
                    }
                }
            }
            strWhere += " and MEDSTOREID_CHR='" + strStorageID + "'";
            strWhere2 += " and a.STORAGEID_CHR='" + strStorageID + "'";
            strSQL = @"select k.*,f.*,h.* from(SELECT  '上期结存' as RowName, sum(b.realqty_dec * b.BUYPRICE_MNY) AS WestMedinmoney,
       sum(b.realqty_dec * b.SALEUNITPRICE_MNY) AS WestMedsalemoney
  FROM t_opr_storagecheck a, t_opr_storagecheckdetail b, t_bse_medicine c
 WHERE a.storagecheckid_chr = b.storagecheckid_chr
   AND b.medicineid_chr = c.medicineid_chr
    and  PSTATUS_INT=1  and FLAG_INT=1
   AND c.medicinetypeid_chr = 1" + strWhere1 + @")k,
(SELECT sum(b.realqty_dec *  b.BUYPRICE_MNY) AS WCinmoney,
       sum(b.realqty_dec *  b.SALEUNITPRICE_MNY) AS WCsalemoney
  FROM t_opr_storagecheck a, t_opr_storagecheckdetail b, t_bse_medicine c
 WHERE a.storagecheckid_chr = b.storagecheckid_chr
   AND b.medicineid_chr = c.medicineid_chr
   and  PSTATUS_INT=1 and FLAG_INT=1
   AND c.medicinetypeid_chr = 3" + strWhere1 + @")f,
(SELECT 
       sum(b.realqty_dec *  b.SALEUNITPRICE_MNY) AS CHsalemoney
  FROM t_opr_storagecheck a, t_opr_storagecheckdetail b, t_bse_medicine c
 WHERE a.storagecheckid_chr = b.storagecheckid_chr
   AND b.medicineid_chr = c.medicineid_chr
   and  PSTATUS_INT=1 and FLAG_INT=1
   AND c.medicinetypeid_chr = 2" + strWhere1 + @")h";
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select k.*,f.*,h.* from(SELECT '本期购入' as RowName,
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS WestMedsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=1
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr = 1" + strWhere + @")k,
(SELECT 
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS WCsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=1
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr =3" + strWhere + @")f,
(SELECT 
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS CHsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=1
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr =2" + strWhere + @")h";
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt1);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select k.*,f.*,h.* from(SELECT '本期退库' as RowName,
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS WestMedsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=2
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr = 1" + strWhere + @")k,
(SELECT 
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS WCsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=2
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr =3" + strWhere + @") f,
(SELECT 
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS CHsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=2
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr =2" + strWhere + @")h";
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt2);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select k.*,f.*,h.* from(SELECT '本期发药' as RowName,
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS WestMedsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=5
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr = 1" + strWhere + @")k,
(SELECT 
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS WCsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=5
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr =3" + strWhere + @")f,
(SELECT 
       sum(b.QTY_DEC * b.SALEUNITPRICE_DEC) AS CHsalemoney
  FROM t_opr_medstoreord a, t_opr_medstoreordde b, t_bse_medicine c,t_aid_medstoreordtype d
 WHERE a.MEDSTOREORDID_CHR = b.MEDSTOREORDID_CHR
   AND b.medicineid_chr = c.medicineid_chr
   and a.MEDSTOREORDTYPEID_CHR=d.MEDSTOREORDTYPEID_CHR
   and d.SIGN_INT=5
   and a.PSTATUS_INT=2
   AND c.medicinetypeid_chr =2" + strWhere + @")h";
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt3);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select k.*,f.*,h.* from(SELECT  '本期结存' as RowName,
       sum(b.realqty_dec * b.SALEUNITPRICE_MNY) AS WestMedsalemoney
  FROM t_opr_storagecheck a, t_opr_storagecheckdetail b, t_bse_medicine c
 WHERE a.storagecheckid_chr = b.storagecheckid_chr
   AND b.medicineid_chr = c.medicineid_chr
    and  PSTATUS_INT=1 and FLAG_INT=1
   AND c.medicinetypeid_chr = 1" + strWhere2 + @")k,
(SELECT 
       sum(b.realqty_dec *  b.SALEUNITPRICE_MNY) AS WCsalemoney
  FROM t_opr_storagecheck a, t_opr_storagecheckdetail b, t_bse_medicine c
 WHERE a.storagecheckid_chr = b.storagecheckid_chr
   AND b.medicineid_chr = c.medicineid_chr
   and  PSTATUS_INT=1 and FLAG_INT=1
   AND c.medicinetypeid_chr = 3" + strWhere2 + @")f,
(SELECT 
       sum(b.realqty_dec *  b.SALEUNITPRICE_MNY) AS CHsalemoney
  FROM t_opr_storagecheck a, t_opr_storagecheckdetail b, t_bse_medicine c
 WHERE a.storagecheckid_chr = b.storagecheckid_chr
   AND b.medicineid_chr = c.medicineid_chr
   and  PSTATUS_INT=1 and FLAG_INT=1
   AND c.medicinetypeid_chr = 2" + strWhere2 + @")h";
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt4);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            dt.ImportRow(dt1.Rows[0]);
            dt.ImportRow(dt2.Rows[0]);
            dt.ImportRow(dt3.Rows[0]);
            dt.ImportRow(dt4.Rows[0]);
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("Totailsalemoney");
                for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                {
                    double Totailinmoney = 0;
                    double Totailsalemoney = 0;
                    for (int f3 = 1; f3 < dt.Columns.Count - 2; f3++)
                    {
                        if (dt.Rows[i1][f3].ToString() != "")
                            Totailsalemoney += double.Parse(dt.Rows[i1][f3].ToString());
                    }
                    dt.Rows[i1]["Totailsalemoney"] = Totailsalemoney;
                }
            }
            return lngRes;
        }
        #endregion

        #region 通过ID更改药品处方发送记录的状态
        /// <summary>
        ///   通过ID更改药品处方发送记录的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="winID"></param>
        /// <param name="p_objItem"></param>
        /// <param name="dtbStorageDe"></param>
        /// <param name="stroageID"></param>
        /// <param name="strTOLMNY"></param>
        /// <param name="nurseexecuteArr"></param>
        /// <param name="p_objDetail"></param>
        /// <param name="m_objOutStorageDetail"></param>
        /// <param name="m_strSubtractMode"></param>
        /// <returns>-99 更新药房库存主表和明细表错误！ -100 插入处方流水表异常！ </returns>
        [AutoComplete]
        public long m_lngUpdateMedRecipeListByID(System.Security.Principal.IPrincipal p_objPrincipal, string winID,
            clsMedRecipeSend_VO p_objItem, DataTable dtbStorageDe, string stroageID, string strTOLMNY,
            clst_opr_nurseexecute[] nurseexecuteArr, clsDS_StorageDetail_VO[] p_objDetail,
            ref clsDS_Outstorage_Detail[] m_objOutStorageDetail, string m_strSubtractMode, string m_strSecodeLevelMode)
        {
            long lngRes = 0;
            try
            {
                clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
                lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngUpdateMedRecipeListByID");
                if (lngRes < 0)
                {
                    return -1;
                }
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                string strSQL = @"update t_opr_recipesend
       set autoprint_int = ?,
       pstatus_int = ?,
       finaltreateemp_chr = ?,
       sendemp_chr = ?,
       senddate_dat = sysdate
       where sid_int = ? and sendwindowid_chr = ?";
                try
                {
                    System.Data.IDataParameter[] paramArr = null;
                    HRPSvc.CreateDatabaseParameter(6, out paramArr);
                    paramArr[0].Value = p_objItem.m_AUTOPRINT_INT;
                    paramArr[1].Value = p_objItem.m_intPStatus;
                    paramArr[2].Value = string.Empty;
                    paramArr[3].Value = p_objItem.m_objSendEmp.strEmpID;
                    paramArr[4].Value = p_objItem.m_intSID;
                    paramArr[5].Value = winID;

                    long lngRecordsAffected = -1;
                    lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);

                    if (!string.IsNullOrEmpty(stroageID))
                    {
                        strSQL = @"update  t_opr_recipesend t
                                   set t.orgmedstoreid_chr = t.medstoreid_chr, t.medstoreid_chr = ?
                                 where sid_int = ?
                                   and t.medstoreid_chr <> ?";
                        HRPSvc.CreateDatabaseParameter(3, out paramArr);
                        paramArr[0].Value = stroageID;
                        paramArr[1].Value = p_objItem.m_intSID;
                        paramArr[1].DbType = DbType.Int32;
                        paramArr[2].Value = stroageID;

                        long lngAffected = -1;
                        lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffected, paramArr);
                    }

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (lngRes == 1)
                {
                    clsmedstorewinque p_objVO = new clsmedstorewinque();
                    p_objVO.m_strMEDSTOREID_CHR = nurseexecuteArr[0].m_strFrom;
                    p_objVO.m_strWINDOWID_CHR = nurseexecuteArr[0].m_strWindow;
                    p_objVO.m_strOUTPATRECIPEID_CHR = nurseexecuteArr[0].m_strOUTPATRECIPEID_CHR;
                    p_objVO.m_intWINDOWTYPE_INT = 0;
                    clsWindowsCortrol windowsctl = new clsWindowsCortrol();
                    windowsctl.m_lngDeleWinque(p_objPrincipal, p_objVO);
                }
                if (m_strSecodeLevelMode == "1" && m_strSubtractMode == "1")
                {
                    lngRes = this.m_lngSubtractStorage(p_objPrincipal, p_objDetail, ref m_objOutStorageDetail);
                    if (lngRes <= 0)
                    {
                        ContextUtil.SetAbort();
                        return lngRes;
                    }

                    //throw new Exception("药房配药扣减库存错误！");
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }
            return lngRes;
        }
        #endregion

        #region 配药处理
        /// <summary>
        /// 配药处理
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <param name="m_strWindowid"></param>
        /// <param name="m_strSendWindowid"></param>
        /// <param name="m_intSID"></param>
        /// <param name="p_objDetail"></param>
        /// <param name="m_objOutStorageDetail"></param>
        /// <param name="m_strSubtractMode">设置门诊药房在哪个业务之后扣减药房库存,0-配药后,1-发药后;</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDosageRecipe(System.Security.Principal.IPrincipal p_objPrincipal,
               clst_opr_nurseexecute[] p_objRecord, string m_strWindowid, string m_strSendWindowid, int m_intSID,
               clsDS_StorageDetail_VO[] p_objDetail, ref clsDS_Outstorage_Detail[] m_objOutStorageDetail,
               string m_strSubtractMode, string m_strSecondLevelMode, string p_strMedStoreID)
        {
            long lngRes = 0;
            try
            {
                clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
                lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc", "m_lngDosageRecipe");
                if (lngRes < 0)
                {
                    return -1;
                }

                if (p_objRecord.Length > 0)
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    string strWindowID = m_strSendWindowid;
                    int waiterNO = 0;
                    clsWindowsCortrol windCortrol = new clsWindowsCortrol();
                    string strTemp = string.Empty;
                    windCortrol.m_lngGetGiveWindID(p_objPrincipal, p_objRecord[0].m_strWindow, out strTemp, out waiterNO);
                    //windCortrol.m_lngGetGiveWindID(p_objPrincipal, p_objRecord[0].m_strWindow, out strWindowID, out waiterNO);
                    //if (strWindowID == "")
                    //    throw (new System.Exception("还没有设置相应的发药窗口，或当前所有的发药窗口都不在工作中！"));

                    string strSQL = @"update t_opr_recipesend
       set pstatus_int = 2, 
       treatdate_dat = sysdate,
       treatemp_chr = ?
       where sid_int = ?";
                    try
                    {
                        System.Data.IDataParameter[] param = null;
                        objHRPSvc.CreateDatabaseParameter(2, out param);
                        param[0].Value = p_objRecord[0].m_strOPERATORID_CHR;
                        param[1].Value = m_intSID;
                        long lngAffected = -1;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffected, param);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }

                    if (!string.IsNullOrEmpty(p_strMedStoreID))
                    {
                        strSQL = @"update  t_opr_recipesend t
                                   set t.orgmedstoreid_chr = t.medstoreid_chr, t.medstoreid_chr = ?
                                 where sid_int = ?
                                   and t.medstoreid_chr <> ?";
                        IDataParameter[] param = null;
                        objHRPSvc.CreateDatabaseParameter(3, out param);
                        param[0].Value = p_strMedStoreID;
                        param[1].Value = m_intSID;
                        param[1].DbType = DbType.Int32;
                        param[2].Value = p_strMedStoreID;

                        long lngAffected = -1;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffected, param);
                    }


                    clsmedstorewinque p_objWind = new clsmedstorewinque();
                    p_objWind.m_strMEDSTOREID_CHR = p_objRecord[0].m_strFrom;
                    p_objWind.m_strOUTPATRECIPEID_CHR = p_objRecord[0].m_strOUTPATRECIPEID_CHR;
                    p_objWind.m_strRECIPETYPE_CHR = p_objRecord[0].m_strOUTPATRECIPETYPE;
                    p_objWind.m_intSid = m_intSID;

                    //删除配药队列
                    p_objWind.m_strWINDOWID_CHR = p_objRecord[0].m_strWindow;
                    p_objWind.m_intWINDOWTYPE_INT = 1;
                    windCortrol.m_lngDeleWinque(p_objPrincipal, p_objWind);
                    //写入发药队列

                    p_objWind.m_strWINDOWID_CHR = strWindowID;
                    p_objWind.m_intWaitNO = waiterNO;
                    p_objWind.m_intWINDOWTYPE_INT = 0;
                    windCortrol.m_lngAddNewWinque(p_objPrincipal, p_objWind);

                    for (int i1 = 0; i1 < p_objRecord.Length; i1++)
                    {
                        lngRes = m_lngAddNewNurseexecute(p_objPrincipal, p_objRecord[i1]);
                    }

                }
                if (m_strSecondLevelMode == "1" && m_strSubtractMode == "0")
                {
                    lngRes = this.m_lngSubtractStorage(p_objPrincipal, p_objDetail, ref m_objOutStorageDetail);
                    if (lngRes <= 0)
                        throw new Exception("药房配药扣减库存错误！");
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }
            return lngRes;
        }
        #endregion

        #region 药房发药,修改库存
        /// <summary>
        ///  药房发药,修改库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">库存明细</param>
        /// <param name="m_objOutStorageDetail">出库明细</param>
        /// <returns>-99 更新药房库存主表和明细表错误！ -100 插入处方流水表异常！ </returns>
        [AutoComplete]
        public long m_lngSubtractStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageDetail_VO[] p_objDetail, ref clsDS_Outstorage_Detail[] m_objOutStorageDetail)
        {
            long lngRes = -1;
            try
            {
                if (p_objDetail == null || p_objDetail.Length == 0)
                {
                    return -1;
                }

                bool p_blnHasDetail = false;
                long p_lngSeriesID;
                m_objOutStorageDetail = new clsDS_Outstorage_Detail[p_objDetail.Length];
                for (int intRow = 0; intRow < p_objDetail.Length; intRow++)
                {
                    m_objOutStorageDetail[intRow] = new clsDS_Outstorage_Detail();
                    //判断当前药品是否已存在库存主表中
                    m_lngCheckMedExistInStorageDetail(null, p_objDetail[intRow], ref  m_objOutStorageDetail[intRow], out p_blnHasDetail, out p_lngSeriesID);
                    if (p_blnHasDetail)
                    {
                        //更新库存明细表记录
                        lngRes = m_lngModifyStorageDetailGross(ref p_objDetail[intRow], 2, p_lngSeriesID);
                        //修改库存主表数量
                        if (lngRes > 0)
                        {
                            lngRes = m_lngModifyStorageGross(p_objDetail[intRow], 2);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (lngRes < 1)
                    //throw new Exception("更新药房库存主表和明细表错误！");
                    return -99;
                else
                {
                    lngRes = this.m_lngAddDSRecipeAccountInfo(p_objPrincipal, p_objDetail);
                }
                if (lngRes < 1)
                    return -100;
                //throw new Exception("插入处方流水表异常！");
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }
            return lngRes;

        }
        #endregion

        #region 添加药房处方流水帐表
        /// <summary>
        /// 添加药房处方流水帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objStorageDetailVoArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddDSRecipeAccountInfo(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageDetail_VO[] m_objStorageDetailVoArr)
        {
            long lngRes = -1;
            string strSQL;
            if (m_objStorageDetailVoArr == null || m_objStorageDetailVoArr.Length < 1)
                return -1;
            clsHRPTableService objHRPServ = new clsHRPTableService();

            strSQL = @" insert into t_ds_recipeaccount_detail a
  (seriesid_int,
   medicineid_chr,
   medicinename_vchr,
   medicinetypeid_chr,
   medspec_vchr,
   drugstoreid_int,
   lotno_vchr,
   validperiod_dat,
   ipretailprice_int,
   opretailprice_int,
   ipunit_chr,
   ipamount_int,
   opamount_int,
   opunit_chr,
   ipoldgross_int,
   opoldgross_int,
   type_int,
   state_int,
   isend_int,
   endipamount_int,
   endopamount_int,
   endipretailprice_int,
   endopretailprice_int,
   inaccountid_chr,
   inaccountdate_dat,
   accountid_chr,
   productorid_chr,
   operatedate_dat,
   outpatrecipeid_chr,
   medseriesid_int,
   operatorid_chr,
   ipavaigross_int,
   opavaigross_int)
  select seq_ds_recipeaccount_detail.nextval,
         b.medicineid_chr,
         b.medicinename_vchr,
         c.medicinetypeid_chr,
         b.medspec_vchr,
         b.drugstoreid_chr,
         b.lotno_vchr,
         b.validperiod_dat,
         b.ipretailprice_int,
         b.opretailprice_int,
         b.ipunit_chr,
         ?,
         ?,
         b.opunit_chr,
         ?,
         ?,
         ?,
         1,
         0,
         null,
         null,
         null,
         null,
         ?,
         sysdate,
         null,
         b.productorid_chr,
         sysdate,
         ?,
         b.seriesid_int,
         ?,
         b.ipavailablegross_num,
         b.opavailablegross_num
    from t_ds_storage_detail b, t_bse_medicine c
   where b.seriesid_int = ?
     and b.medicineid_chr = c.medicineid_chr(+)";
            DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Int16, DbType.String, DbType.String, DbType.String, DbType.Int64 };
            object[][] objValuesArr = new object[9][];

            //20091021 如数量为0时不保存在流水表
            int intLength = 0;
            for (int i1 = 0; i1 < m_objStorageDetailVoArr.Length; i1++)
            {
                if (m_objStorageDetailVoArr[i1].m_dblIPREALGROSS_INT != 0)
                {
                    intLength++;
                }
            }

            if (intLength == 0)
            {
                return 1;
            }


            int m_intCount = m_objStorageDetailVoArr.Length;
            clsDS_StorageDetail_VO m_objTempVo;
            for (int j = 0; j < objValuesArr.Length; j++)//初始化数组
            {
                objValuesArr[j] = new object[intLength];
            }

            int intIdx = 0;
            for (int i = 0; i < m_intCount; i++)
            {
                if (m_objStorageDetailVoArr[i].m_dblIPREALGROSS_INT == 0)
                    continue;
                m_objTempVo = m_objStorageDetailVoArr[i];
                objValuesArr[0][intIdx] = m_objTempVo.m_dblIPREALGROSS_INT;
                objValuesArr[1][intIdx] = m_objTempVo.m_dblOPREALGROSS_INT;
                objValuesArr[2][intIdx] = m_objTempVo.m_dblOldIPREALGROSS_INT;
                objValuesArr[3][intIdx] = m_objTempVo.m_dblOldOPREALGROSS_INT;
                objValuesArr[4][intIdx] = m_objTempVo.m_intSubStorageType;
                objValuesArr[5][intIdx] = m_objTempVo.m_strOperatorid;
                objValuesArr[6][intIdx] = m_objTempVo.m_strOutPatientRecipeid;
                objValuesArr[7][intIdx] = m_objTempVo.m_strOperatorid;
                objValuesArr[8][intIdx] = m_objTempVo.m_lngSERIESID_INT;
                intIdx++;
            }
            try
            {
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValuesArr, dbTypes);
                if (lngRes <= 0)
                    throw new Exception();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion

        #region 修改库存主表数量
        /// <summary>
        /// 修改库存主表数量
        /// </summary>
        /// <param name="p_objDetail">库存明细VO</param>
        /// <param name="intType">修改类型　1：加库存,2：减库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageGross(clsDS_StorageDetail_VO p_objDetail, Int16 intType)
        {
            //修改库存主表
            long lngRes = -1;
            string strSQL;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"update t_ds_storage a
set a.opcurrentgross_num = a.opcurrentgross_num + ?,
a.ipcurrentgross_num = a.ipcurrentgross_num + ?
where a.medicineid_chr = ? and a.drugstoreid_chr=?";
            objHRPServ.CreateDatabaseParameter(4, out objValues);
            //判断当前为添加库存数还是减小
            if (intType == 1)
            {
                objValues[0].Value = p_objDetail.m_dblOPREALGROSS_INT;
                objValues[1].Value = p_objDetail.m_dblIPREALGROSS_INT;
                objValues[2].Value = p_objDetail.m_strMEDICINEID_CHR;
                objValues[3].Value = p_objDetail.m_strDRUGSTOREID_CHR;
            }
            else
            {
                objValues[0].Value = -p_objDetail.m_dblOPREALGROSS_INT;
                objValues[1].Value = -p_objDetail.m_dblIPREALGROSS_INT;
                objValues[2].Value = p_objDetail.m_strMEDICINEID_CHR;
                objValues[3].Value = p_objDetail.m_strDRUGSTOREID_CHR;
            }
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据药房id和药品id判断库存明细表是否已存在该药
        /// <summary>
        /// 根据药房id和药品id判断库存明细表是否已存在该药
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objStorageDetail">库存明细</param>
        /// <param name="m_objOutStorageDetail">获取出库明细</param>
        /// <param name="p_blnHasDetail">是否存在</param>
        /// <param name="p_lngSeriesID">如存在，返回序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckMedExistInStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageDetail_VO m_objStorageDetail, ref clsDS_Outstorage_Detail m_objOutStorageDetail, out bool p_blnHasDetail, out long p_lngSeriesID)
        {
            p_lngSeriesID = 0;
            p_blnHasDetail = false;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.seriesid_int,a.medicineid_chr,a.medicinename_vchr,a.medspec_vchr,a.lotno_vchr,a.ipunit_chr,
a.opunit_chr,a.packqty_dec,a.ipretailprice_int,a.opretailprice_int,a.ipwholesaleprice_int,
a.opwholesaleprice_int,a.validperiod_dat,a.instoreid_vchr,a.drugstoreid_chr,a.productorid_chr
from t_ds_storage_detail a where a.seriesid_int=? ";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_objStorageDetail.m_lngSERIESID_INT;
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_blnHasDetail = true;
                    p_lngSeriesID = Convert.ToInt64(dtbValue.Rows[0]["seriesid_int"]);
                    m_objOutStorageDetail.m_datVALIDPERIOD_DAT = Convert.ToDateTime(dtbValue.Rows[0]["validperiod_dat"]);
                    m_objOutStorageDetail.m_dblIPAMOUNT_INT = m_objStorageDetail.m_dblIPREALGROSS_INT;
                    m_objOutStorageDetail.m_dblIPRETAILPRICE_INT = Convert.ToDouble(dtbValue.Rows[0]["ipretailprice_int"]);
                    m_objOutStorageDetail.m_dblIPWHOLESALEPRICE_INT = dtbValue.Rows[0]["ipwholesaleprice_int"] == System.DBNull.Value ? 0 : Convert.ToDouble(dtbValue.Rows[0]["ipwholesaleprice_int"]);
                    m_objOutStorageDetail.m_dblOPAMOUNT_INT = m_objStorageDetail.m_dblOPREALGROSS_INT;
                    m_objOutStorageDetail.m_dblOPRETAILPRICE_INT = Convert.ToDouble(dtbValue.Rows[0]["opretailprice_int"]);
                    m_objOutStorageDetail.m_dblOPWHOLESALEPRICE_INT = dtbValue.Rows[0]["opwholesaleprice_int"] == System.DBNull.Value ? 0 : Convert.ToDouble(dtbValue.Rows[0]["opwholesaleprice_int"]);
                    m_objOutStorageDetail.m_dblPACKQTY_DEC = Convert.ToDouble(dtbValue.Rows[0]["packqty_dec"]);
                    m_objOutStorageDetail.m_intSTATUS = 1;
                    m_objOutStorageDetail.m_strIPUNIT_CHR = dtbValue.Rows[0]["ipunit_chr"].ToString();
                    m_objOutStorageDetail.m_strLOTNO_VCHR = dtbValue.Rows[0]["lotno_vchr"].ToString();
                    m_objOutStorageDetail.m_strMEDICINEID_CHR = m_objStorageDetail.m_strMEDICINEID_CHR;
                    m_objOutStorageDetail.m_strMEDICINENAME_VCHR = dtbValue.Rows[0]["medicinename_vchr"].ToString();
                    m_objOutStorageDetail.m_strMEDSPEC_VCHR = dtbValue.Rows[0]["medspec_vchr"].ToString();
                    m_objOutStorageDetail.m_strOPUNIT_CHR = dtbValue.Rows[0]["opunit_chr"].ToString();
                    m_objOutStorageDetail.m_strInStorageid = dtbValue.Rows[0]["instoreid_vchr"].ToString();
                    m_objOutStorageDetail.m_strPRODUCTORID_CHR = dtbValue.Rows[0]["productorid_chr"].ToString();
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

        #region 修改库存明细数量
        /// <summary>
        /// 修改库存明细数量
        /// </summary>
        /// <param name="p_objDetail">库存明细VO</param>
        /// <param name="intType">修改类型　1：加库存,2：减库存</param>
        /// <param name="p_lngSeriesID">主表顺号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageDetailGross(ref clsDS_StorageDetail_VO p_objDetail, Int16 intType, long p_lngSeriesID)
        {
            //修改库存明细表
            long lngRes = -1;
            string strSQL;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;


            //判断当前为添加库存数还是减小
            if (intType == 1)
            {
                strSQL = @"update t_ds_storage_detail a
set a.oprealgross_int = a.oprealgross_int + ?,
a.iprealgross_int = a.iprealgross_int + ?,
a.opavailablegross_num = a.opavailablegross_num + ?,
a.ipavailablegross_num = a.ipavailablegross_num + ?
where a.seriesid_int=?
   and a.iprealgross_int + ? >= 0";
                objHRPServ.CreateDatabaseParameter(6, out objValues);
                objValues[0].Value = p_objDetail.m_dblOPREALGROSS_INT;
                objValues[1].Value = p_objDetail.m_dblIPREALGROSS_INT;
                objValues[2].Value = p_objDetail.m_dblOPREALGROSS_INT;
                objValues[3].Value = p_objDetail.m_dblIPREALGROSS_INT;
                objValues[4].Value = p_lngSeriesID;
                objValues[5].Value = p_objDetail.m_dblIPREALGROSS_INT;
            }
            else
            {
                strSQL = @"update t_ds_storage_detail a
set a.oprealgross_int = a.oprealgross_int + ?,
a.iprealgross_int = a.iprealgross_int + ?,
a.opavailablegross_num = a.opavailablegross_num + ?,
a.ipavailablegross_num = a.ipavailablegross_num + ?
where a.seriesid_int=?
   and a.iprealgross_int + ? >= 0";
                objHRPServ.CreateDatabaseParameter(6, out objValues);
                objValues[0].Value = -p_objDetail.m_dblOPREALGROSS_INT;
                objValues[1].Value = -p_objDetail.m_dblIPREALGROSS_INT;
                objValues[2].Value = -p_objDetail.m_dblOPREALGROSS_INT;
                objValues[3].Value = -p_objDetail.m_dblIPREALGROSS_INT;
                objValues[4].Value = p_lngSeriesID;
                objValues[5].Value = -p_objDetail.m_dblIPREALGROSS_INT;
            }
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                if (lngRes <= 0 || lngAffected != 1)
                    return -90;
                //throw new Exception("扣库存出错！");

                //20091010:在发药的时候写入药品扣减表 t_opr_recipededuct
                if (intType == 2 && p_objDetail.m_dblIPREALGROSS_INT != 0)
                {
                    //获取行号
                    int p_intRowNo = 0;
                    strSQL = @"select a.rowno_chr
  from t_opr_outpatientpwmrecipede a
  left join t_bse_chargeitem b on b.itemid_chr = a.itemid_chr
 where a.outpatrecipeid_chr = ?
   and b.itemsrcid_vchr = ?";
                    objHRPServ.CreateDatabaseParameter(2, out objValues);
                    objValues[0].Value = p_objDetail.m_strOutPatientRecipeid;
                    objValues[1].Value = p_objDetail.m_strMEDICINEID_CHR;
                    DataTable dtbTemp = new DataTable();
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objValues);
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        Int32.TryParse(dtbTemp.Rows[0][0].ToString(), out p_intRowNo);
                    }


                    strSQL = @"insert into t_opr_recipededuct
  (outpatrecipeid_chr, medseriesid_int, drugstoreid_chr, medicineid_chr,
   rowno_vchr, lotno_vchr, chargetype_int, opamount_dec, ipamount_dec, status_int)
values
  (?, ?, ?, ?, ?,'X', ?, ?, ?, 0)";

                    objHRPServ.CreateDatabaseParameter(8, out objValues);
                    objValues[0].Value = p_objDetail.m_strOutPatientRecipeid;
                    objValues[1].Value = p_objDetail.m_lngSERIESID_INT;
                    objValues[2].Value = p_objDetail.m_strDRUGSTOREID_CHR;
                    objValues[3].Value = p_objDetail.m_strMEDICINEID_CHR;
                    objValues[4].Value = p_intRowNo;
                    objValues[5].Value = p_objDetail.m_dblOPCHARGEFLG_INT;//基本或最小
                    objValues[6].Value = p_objDetail.m_dblOPREALGROSS_INT;
                    objValues[7].Value = p_objDetail.m_dblIPREALGROSS_INT;

                    lngAffected = -1;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                    if (lngAffected < 1 || lngRes < 1)
                        throw new Exception("写入药品扣减表失败！");
                }

                DataTable dtReuslt = new DataTable();
                strSQL = @"select a.iprealgross_int ,a.oprealgross_int from  t_ds_storage_detail a where a.seriesid_int=?";
                objValues = null;
                objHRPServ.CreateDatabaseParameter(1, out objValues);
                objValues[0].Value = p_lngSeriesID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtReuslt, objValues);
                if (lngRes > 0 && dtReuslt != null && dtReuslt.Rows.Count > 0)
                {
                    p_objDetail.m_dblOldIPREALGROSS_INT = Convert.ToDouble(dtReuslt.Rows[0]["iprealgross_int"]);
                    p_objDetail.m_dblOldOPREALGROSS_INT = Convert.ToDouble(dtReuslt.Rows[0]["oprealgross_int"]);
                }
                else
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

        #region 添加药房退药信息
        /// <summary>
        /// 添加药房退药信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddReturnMedInfo(System.Security.Principal.IPrincipal p_objPrincipal, clsReutrnMed m_objMainVo, List<clsReutrnMedEntry> m_objDetailList)
        {
            long lngRes = -1;
            string strSQL;
            if (m_objDetailList == null || m_objDetailList.Count == 0)
                return -1;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"insert into t_opr_returnmed a
                                           (a.outpatrecipeid_chr,
                                            a.operemp_chr,
                                            a.opertime_dat,
                                            a.confirmemp_chr,
                                            a.confirmtime_dat,
                                            a.status_int,
                                            a.flag_int,a.drugstoreid_chr)
                                         values
                                           (?, ?, ?, ?, ?, ?, ?,?)";
            objValues = null;
            objHRPServ.CreateDatabaseParameter(8, out objValues);
            objValues[0].Value = m_objMainVo.m_strOUTPATRECIPEID_CHR;
            objValues[1].Value = m_objMainVo.m_strOPEREMP_CHR;
            objValues[2].Value = m_objMainVo.m_datOPERTIME_DAT;
            objValues[3].Value = m_objMainVo.m_strCONFIRMEMP_CHR;
            objValues[4].Value = m_objMainVo.m_datCONFIRMTIME_DAT;
            objValues[5].Value = m_objMainVo.m_intSTATUS_INT;
            objValues[6].Value = m_objMainVo.m_intFLAG_INT;
            objValues[7].Value = m_objMainVo.m_strDrugStoreid;
            long lngAffected = -1;
            lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
            if (lngAffected < 1 || lngRes < 1)
                throw new Exception();
            if (lngRes > 0)
            {
                strSQL = @" insert into t_opr_returnmed_entry b
  (b.outpatrecipeid_chr,
   b.itemid_chr,
   b.itemname_vchr,
   b.orgamout_dec,
   b.retamout_dec,
   b.price_dec,
   b.billrowno_int,
   b.unitid_chr,
   b.medseriesid_int,
   b.opamount_dec,
   b.ipamount_dec)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ";
                DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.Double, DbType.Double, DbType.Double, DbType.Int16, DbType.String, DbType.Int64, DbType.Double, DbType.Double };
                object[][] objValuesArr = new object[11][];
                int m_intListCount = m_objDetailList.Count;
                clsReutrnMedEntry m_objTempVo;
                for (int j = 0; j < objValuesArr.Length; j++)//初始化数组
                {
                    objValuesArr[j] = new object[m_intListCount];
                }
                for (int i = 0; i < m_intListCount; i++)
                {
                    m_objTempVo = m_objDetailList[i];
                    objValuesArr[0][i] = m_objTempVo.m_strOUTPATRECIPEID_CHR;
                    objValuesArr[1][i] = m_objTempVo.m_strITEMID_CHR;
                    objValuesArr[2][i] = m_objTempVo.m_strITEMNAME_VCHR;
                    objValuesArr[3][i] = m_objTempVo.ORGAMOUT_DEC;
                    objValuesArr[4][i] = m_objTempVo.RETAMOUT_DEC;
                    objValuesArr[5][i] = m_objTempVo.PRICE_DEC;
                    objValuesArr[6][i] = m_objTempVo.BILLROWNO_INT;
                    objValuesArr[7][i] = m_objTempVo.m_strUnit_chr;
                    objValuesArr[8][i] = Convert.ToInt64(m_objTempVo.m_strSerialno);

                    objValuesArr[9][i] = Convert.ToDouble(m_objDetailList[i].m_dblLotsReturnAmount / m_objDetailList[i].m_dblPackage).ToString("0.0000");
                    objValuesArr[10][i] = m_objDetailList[i].m_dblLotsReturnAmount;



                }
                try
                {
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValuesArr, dbTypes);
                    if (lngRes <= 0)
                        throw new Exception();
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                throw new Exception();
            }
            if (lngRes > 0)
            {
                clsDS_Outstorage_Detail[] m_objOutStorageDetailVoArr = null;
                clsDS_StorageDetail_VO[] m_objStorageDetailVoArr = new clsDS_StorageDetail_VO[m_objDetailList.Count];
                for (int m_intRow = 0; m_intRow < m_objDetailList.Count; m_intRow++)
                {
                    m_objStorageDetailVoArr[m_intRow] = new clsDS_StorageDetail_VO();
                    m_objStorageDetailVoArr[m_intRow].m_strMEDICINEID_CHR = m_objDetailList[m_intRow].m_strMEDICINEID_CHR;
                    m_objStorageDetailVoArr[m_intRow].m_lngSERIESID_INT = Convert.ToInt64(m_objDetailList[m_intRow].m_strSerialno);
                    m_objStorageDetailVoArr[m_intRow].m_strDRUGSTOREID_CHR = m_objDetailList[m_intRow].m_strDrugStoreid_chr;
                    m_objStorageDetailVoArr[m_intRow].m_intSubStorageType = 1;
                    m_objStorageDetailVoArr[m_intRow].m_strOutPatientRecipeid = m_objMainVo.m_strOUTPATRECIPEID_CHR;
                    m_objStorageDetailVoArr[m_intRow].m_strOperatorid = m_objMainVo.m_strOPEREMP_CHR;
                    //m_objStorageDetailVoArr[m_intRow].m_strMEDICINEID_CHR = dtSendMedRecipeDetail.Rows[m_intRow]["medicineid_chr"].ToString();

                    m_objStorageDetailVoArr[m_intRow].m_dblOPREALGROSS_INT = Convert.ToDouble(Convert.ToDouble(m_objDetailList[m_intRow].m_dblLotsReturnAmount / m_objDetailList[m_intRow].m_dblPackage).ToString("0.0000"));
                    m_objStorageDetailVoArr[m_intRow].m_dblIPREALGROSS_INT = m_objDetailList[m_intRow].m_dblLotsReturnAmount;


                }
                //修改药房库存
                lngRes = this.m_lngSubtractStorage(p_objPrincipal, 1, m_objStorageDetailVoArr, ref m_objOutStorageDetailVoArr);
                if (lngRes <= 0)
                {
                    throw new Exception();
                }
                else  //写入处方流水帐表
                {
                    lngRes = this.m_lngAddDSRecipeAccountInfo(p_objPrincipal, m_objStorageDetailVoArr);
                }
                if (lngRes <= 0)
                {
                    throw new Exception();
                }
            }
            return lngRes;

        }
        #endregion

        #region 药房发药,修改库存
        /// <summary>
        /// 药房发药,修改库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_intSubStorageType">修改类型　1：加库存,2：减库存</param>
        /// <param name="p_objDetail"></param>
        /// <param name="m_objOutStorageDetail"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubtractStorage(System.Security.Principal.IPrincipal p_objPrincipal, Int16 m_intSubStorageType, clsDS_StorageDetail_VO[] p_objDetail, ref clsDS_Outstorage_Detail[] m_objOutStorageDetail)
        {
            if (p_objDetail == null || p_objDetail.Length == 0)
            {
                return -1;
            }
            long lngRes = -1;
            bool p_blnHasDetail = false;
            long p_lngSeriesID;
            m_objOutStorageDetail = new clsDS_Outstorage_Detail[p_objDetail.Length];
            for (int intRow = 0; intRow < p_objDetail.Length; intRow++)
            {
                m_objOutStorageDetail[intRow] = new clsDS_Outstorage_Detail();
                //判断当前药品是否已存在库存主表中
                m_lngCheckMedExistInStorageDetail(null, p_objDetail[intRow], ref  m_objOutStorageDetail[intRow], out p_blnHasDetail, out p_lngSeriesID);
                if (p_blnHasDetail)
                {
                    //更新库存明细表记录
                    lngRes = m_lngModifyStorageDetailGross(p_objDetail[intRow], m_intSubStorageType, p_lngSeriesID);
                    //修改库存主表数量
                    if (lngRes != -1)
                    {
                        lngRes = m_lngModifyStorageGross(p_objDetail[intRow], m_intSubStorageType);
                    }
                }
            }
            return lngRes;

        }
        #endregion

        #region 修改库存明细数量
        /// <summary>
        /// 修改库存明细数量
        /// </summary>
        /// <param name="p_objDetail">库存明细VO</param>
        /// <param name="intType">修改类型　1：加库存,2：减库存</param>
        /// <param name="p_lngSeriesID">主表顺号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageDetailGross(clsDS_StorageDetail_VO p_objDetail, Int16 intType, long p_lngSeriesID)
        {
            //修改库存明细表
            long lngRes = -1;
            string strSQL;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;


            //判断当前为添加库存数还是减小
            if (intType == 1)
            {
                strSQL = @"update t_ds_storage_detail a
set a.oprealgross_int = a.oprealgross_int + ?,
a.iprealgross_int = a.iprealgross_int + ?,
a.opavailablegross_num = a.opavailablegross_num + ?,
a.ipavailablegross_num = a.ipavailablegross_num + ?
where a.seriesid_int=?
   and a.ipavailablegross_num + ? >= 0 ";
                objHRPServ.CreateDatabaseParameter(6, out objValues);
                objValues[0].Value = p_objDetail.m_dblOPREALGROSS_INT;
                objValues[1].Value = p_objDetail.m_dblIPREALGROSS_INT;
                objValues[2].Value = p_objDetail.m_dblOPREALGROSS_INT;
                objValues[3].Value = p_objDetail.m_dblIPREALGROSS_INT;
                objValues[4].Value = p_lngSeriesID;
                objValues[5].Value = p_objDetail.m_dblIPREALGROSS_INT;
            }
            else
            {
                strSQL = @"update t_ds_storage_detail a
set a.oprealgross_int = a.oprealgross_int + ?,
a.iprealgross_int = a.iprealgross_int + ?,
a.opavailablegross_num = a.opavailablegross_num + ?,
a.ipavailablegross_num = a.ipavailablegross_num + ?
where a.seriesid_int=?
   and a.ipavailablegross_num + ? >= 0";
                objHRPServ.CreateDatabaseParameter(6, out objValues);
                objValues[0].Value = -p_objDetail.m_dblOPREALGROSS_INT;
                objValues[1].Value = -p_objDetail.m_dblIPREALGROSS_INT;
                objValues[2].Value = -p_objDetail.m_dblOPREALGROSS_INT;
                objValues[3].Value = -p_objDetail.m_dblIPREALGROSS_INT;
                objValues[4].Value = p_lngSeriesID;
                objValues[5].Value = -p_objDetail.m_dblIPREALGROSS_INT;
            }
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                if (lngRes <= 0 || lngAffected != 1)
                    throw new Exception("扣库存出错！");
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 取消药房发送表叫号标志
        /// <summary>
        /// 取消药房发送表叫号标志
        /// </summary>
        /// <param name="m_intSid">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCancelRecipeSendCalledFlag(long m_intSid)
        {

            long lngRes = -1;
            string strSQL;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"update t_opr_recipesend a set a.called_int=0,a.currentcall_int=0,a.recalled_int=0,a.quit_int=0 where a.sid_int=?";
            objHRPServ.CreateDatabaseParameter(1, out objValues);
            objValues[0].Value = m_intSid;
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 通过发票号查询患者信息
        /// <summary>
        /// 通过发票号查询患者信息
        /// </summary>
        /// <param name="invoNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetPatInfoByInvo(string invoNo)
        {
            DataTable dt = null;
            string Sql = @"select a.patientid_chr, a.patientname_chr, a.seqid_chr, b.patientcardid_chr
                              from t_opr_outpatientrecipeinv a
                             inner join t_bse_patientcard b
                                on a.patientid_chr = b.patientid_chr
                             where a.invoiceno_vchr = ?";
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = invoNo;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dt;
        }
        #endregion

        #region 微信检查是否绑卡
        /// <summary>
        /// 微信检查是否绑卡
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool IsWechatBanding(string cardNo)
        {
            string Sql = @"select t.cardno from opRegWeChatBinding t where t.cardno = ? and t.status = 1";
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = cardNo;

                DataTable dt = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;    // 存在绑定
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return false;
        }
        #endregion

        #region 通过处方ID获取诊疗卡号
        /// <summary>
        /// 通过处方ID获取诊疗卡号
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [AutoComplete]
        public string GetCardNoByRecipeId(string recipeId)
        {
            string cardNo = string.Empty;
            string Sql = @"select b.patientcardid_chr
                              from t_opr_outpatientrecipe a
                             inner join t_bse_patientcard b
                                on a.patientid_chr = b.patientid_chr
                             where a.outpatrecipeid_chr = ?";
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = recipeId;

                DataTable dt = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    cardNo = dt.Rows[0]["patientcardid_chr"].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return cardNo;
        }
        #endregion

        #region 外送代煎中药方法

        #region 查询外送代煎中药数据源列表
        /// <summary>
        /// 查询外送代煎中药数据源列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="opIp">1 门诊; 2 住院</param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable QueryProxyBoilMed(string startDate, string endDate, int opIp)
        {
            string Sql = string.Empty;
            DataTable dtMed = null;
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;

                if (opIp == 1)              // 门诊
                {
                    Sql = @"select a.outpatrecipeid_chr as recipeid,
                                   a.registerid_chr as registerid,
                                   '' as ipno, 
                                   b.lastname_vchr as patname,
                                   b.sex_chr as sex,
                                   b.birth_dat as birthday,
                                   b.homephone_vchr as tel,
                                   b.email_vchr as email,
                                   b.consigneeaddr,
                                   b.mobile_chr,
                                   c.deptname_vchr as deptname,
                                   '' as areaname,
                                   d.lastname_vchr as doctname,
                                   to_char(a.recorddate_dat, 'yyyy-mm-dd hh24:mi') as recipedate,
                                   0 as recipeno, 
                                   e.invoiceno_vchr as invono,
                                   (e.totalsum_mny - abs(e.totaldiffcost_mny)) as invmoney,
                                   f.paytypename_vchr as paytypename,
                                   g.patientcardid_chr as cardno,
                                   '' as bedno,
                                   s.sid_int as putmedid,
                                   p.status as sendstatus
                              from t_opr_outpatientrecipe a
                             inner join t_bse_patient b
                                on a.patientid_chr = b.patientid_chr
                             inner join t_bse_deptdesc c
                                on a.diagdept_chr = c.deptid_chr
                             inner join t_bse_employee d
                                on a.diagdr_chr = d.empid_chr
                             inner join t_opr_outpatientrecipeinv e
                                on a.outpatrecipeid_chr = e.outpatrecipeid_chr
                             inner join t_bse_patientpaytype f
                                on a.paytypeid_chr = f.paytypeid_chr
                             inner join t_bse_patientcard g
                                on a.patientid_chr = g.patientid_chr
                             inner join t_opr_recipesendentry s
                                on a.outpatrecipeid_chr = s.outpatrecipeid_chr
                              left join t_log_medtrans_cfyp p
                                on a.outpatrecipeid_chr = p.recipeid and p.flagid = 1 
                             where a.pstauts_int = 2
                               and (a.isproxyboilmed = 1 or a.isproxyboilmed = 2) 
                               and (a.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";
                }
                else if (opIp == 2)         // 住院
                {
                    // -- a.orderid_chr as recipeid,
                    Sql = @"select a.registerid_chr as recipeid,
                                   b.registerid_chr as registerid,
                                   b.inpatientid_chr as ipno,
                                   c.lastname_vchr as patname,
                                   c.sex_chr as sex,
                                   c.birth_dat as birthday,
                                   c.homephone_vchr as tel,
                                   c.email_vchr as email,
                                   c.consigneeaddr,
                                   c.mobile_chr,
                                   '' as deptname,
                                   d.deptname_vchr as areaname,
                                   a.creator_chr as doctname,
                                   to_char(p.create_dat, 'yyyy-mm-dd hh24:mi') as recipedate,
                                   nvl(a.recipeno_int, 0) as recipeno,
                                   '' as invono,
                                   0 as invmoney,
                                   f.paytypename_vchr as paytypename,
                                   g.patientcardid_chr as cardno,
                                   x.code_chr as bedno,
                                   p.putmeddetailid_chr as putmedid,
                                   y.status as sendstatus
                              from t_opr_bih_order a
                             inner join t_opr_bih_register b
                                on a.registerid_chr = b.registerid_chr
                             inner join t_bse_patient c
                                on b.patientid_chr = c.patientid_chr
                             inner join t_bse_deptdesc d
                                on a.curareaid_chr = d.deptid_chr
                             inner join t_bse_patientpaytype f
                                on b.paytypeid_chr = f.paytypeid_chr
                             inner join t_bse_patientcard g
                                on b.patientid_chr = g.patientid_chr
                             inner join t_bih_opr_putmeddetail p
                                on a.orderid_chr = p.orderid_chr
                               and p.status_int = 1
                              left join t_bse_bed x
                                on b.registerid_chr = x.bihregisterid_chr
                              left join t_log_medtrans_cfyp y
                                on p.putmeddetailid_chr = y.putmedid
                               and y.flagid = 2
                             where (a.isproxyboilmed = 1 or a.isproxyboilmed = 2)
                               and a.status_int in ( 2, 4, 5 ) 
                               and (p.create_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                }

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = startDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                svc.lngGetDataTableWithParameters(Sql, ref dtMed, parm);
                svc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dtMed;
        }
        #endregion

        #region 查询外送代煎中药明细
        /// <summary>
        /// 查询外送代煎中药明细
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="recipeNo"></param>
        /// <param name="opIp"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable QueryProxyBoilMedDet(string recipeId, string recipeNo, string recipeDate, int opIp)
        {
            string Sql = string.Empty;
            DataTable dtMed = null;
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;

                if (opIp == 1)              // 门诊
                {
                    Sql = @"select a.outpatrecipeid_chr as recipeid,
                                   a.times_int          as times,
                                   a.itemid_chr         as itemid,
                                   a.itemname_vchr      as itemname,
                                   a.unitid_chr         as unit,
                                   a.qty_dec            as qty,
                                   a.unitprice_mny      as price,
                                   a.sumusage_vchr      as recipeusage,
                                   c.medicineid_chr     as medid,
                                   c.assistcode_chr     as medcode,
                                   c.medicinename_vchr  as medname,
                                   c.medspec_vchr       as spec,
                                   d.usagename_vchr     as usageName,
                                   round(a.qty_dec * a.unitprice_mny, 2) as total                                   
                              from t_opr_outpatientcmrecipede a
                             inner join t_bse_chargeitem b
                                on a.itemid_chr = b.itemid_chr
                             inner join t_bse_medicine c
                                on b.itemsrcid_vchr = c.medicineid_chr
                              left join t_bse_usagetype d
                                on a.usageid_chr = d.usageid_chr
                             where a.outpatrecipeid_chr = ?";

                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = recipeId;
                }
                else if (opIp == 2)         // 住院
                {
                    Sql = @"select a.registerid_chr as recipeid,
                                   1 as times,
                                   '' as itemid,
                                   '' as itemname,
                                   p.unit_vchr as unit,
                                   p.get_dec as qty,
                                   p.unitprice_mny as price,
                                   '' as recipeusage,
                                   c.medicineid_chr as medid,
                                   c.assistcode_chr as medcode,
                                   c.medicinename_vchr as medname,
                                   c.medspec_vchr as spec,
                                   (a.dosetypename_chr || nvl(a.remark_vchr,'')) as usageName, 
                                   round(p.get_dec * p.unitprice_mny, 2) as total,
                                   to_char(p.create_dat, 'yyyy-mm-dd hh24:mi') as recipedate 
                              from t_opr_bih_order a
                             inner join t_bih_opr_putmeddetail p
                                on a.orderid_chr = p.orderid_chr
                               and p.status_int = 1
                             inner join t_bse_medicine c
                                on p.medid_chr = c.medicineid_chr
                             where (a.isproxyboilmed = 1 or a.isproxyboilmed = 2) 
                               and a.registerid_chr = ?
                               and a.recipeno_int = ? ";

                    svc.CreateDatabaseParameter(2, out parm);
                    parm[0].Value = recipeId;
                    parm[1].Value = recipeNo;
                }
                svc.lngGetDataTableWithParameters(Sql, ref dtMed, parm);
                svc.Dispose();
                if (opIp == 2 && dtMed != null && dtMed.Rows.Count > 0)
                {
                    for (int i = dtMed.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dtMed.Rows[i]["recipedate"].ToString() != recipeDate)
                        {
                            dtMed.Rows.RemoveAt(i);
                        }
                    }
                    dtMed.AcceptChanges();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dtMed;
        }
        #endregion

        #region 检测是否已发送
        /// <summary>
        /// 检测是否已发送
        /// </summary>
        /// <param name="putMedIds"></param>
        /// <param name="isEqual">true 判断发送; false 判断取消发送</param>
        /// <returns></returns>
        [AutoComplete]
        public bool CheckIsSend(string putMedIds, bool isEqual)
        {
            string Sql = @"select t.status from t_log_medtrans_cfyp t where t.putmedid in ({0})";
            Sql = string.Format(Sql, putMedIds);
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                DataTable dt = null;
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                svc.Dispose();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (isEqual)
                        {
                            if (Convert.ToInt32(dr["status"].ToString()) == 1)
                            {
                                return true;        // 已发送
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(dr["status"].ToString()) != 1)
                            {
                                return true;        // 未发送
                            }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return false;
        }
        #endregion

        #region 外送代煎药转门诊中药房
        /// <summary>
        /// 外送代煎药转门诊中药房
        /// </summary>
        /// <param name="recipeIds"></param>
        /// <param name="putMedIds"></param>
        /// <param name="operId"></param>
        /// <param name="opIp"></param>
        /// <returns></returns>
        [AutoComplete]
        public int ConvertMedStore(string recipeIds, string putMedIds, string operId, int opIp)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            try
            {
                clsHRPTableService svc = new clsHRPTableService();

                if (opIp == 1)              // 门诊
                {
                    Sql = @"update t_opr_outpatientrecipe t set t.isproxyboilmed = 0 where t.outpatrecipeid_chr in ({0})";
                    Sql = string.Format(Sql, recipeIds);
                }
                else if (opIp == 2)         // 住院
                {
                    Sql = @"update t_opr_bih_order t
                               set t.isproxyboilmed = 0
                             where t.orderid_chr in
                                   (select b.orderid_chr
                                      from t_bih_opr_putmeddetail b
                                     where b.putmeddetailid_chr in ({0}))";
                    Sql = string.Format(Sql, putMedIds);
                }
                affectRows += svc.DoExcute(Sql);

                Sql = @"update t_log_medtrans_cfyp t set t.convertoperid = '{0}', t.convertdate = sysdate where t.putmedid in ({1})";
                affectRows += svc.DoExcute(string.Format(Sql, operId, putMedIds));

                svc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return (int)affectRows;
        }
        #endregion

        #endregion

    }
}
