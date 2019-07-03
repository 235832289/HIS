using System;
using System.Data;
using Oracle.DataAccess.Client;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.Utility;//Utility.dll
using System.Collections;

namespace com.digitalwave.iCare.middletier.BIHOrderServer
{
    /// <summary>
    /// clsBIHChargeItemService 的摘要说明。
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBIHOrderChangeService : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 查询用法对应的项目
        [AutoComplete]
        public long m_GetItemByUsageID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOrderID, out clsChargeItem_VO[] objResult)
        {
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            objResult = new clsChargeItem_VO[0];
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer", "m_GetItemByUsageID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            /*
            string strSQL = @"SELECT a.*, b.*, c.noqtyflag_int,d.USAGEID_CHR as USAGEID_CHR1,d.USAGENAME_VCHR as USAGENAME_VCHR1,e.USAGENAME_VCHR,
            g.deptid_chr,
            g.deptname_vchr
            FROM t_bse_chargeitemusagegroup a, t_bse_chargeitem b, t_bse_medicine c,t_bse_usagetype d,t_bse_usagetype e,
            t_aid_bih_ocdeptdefault  f,
            t_bse_deptdesc  g
            WHERE a.usageid_chr = '" + strUsageID + @"'
            AND a.itemid_chr = b.itemid_chr
            and a.USAGEID_CHR=e.USAGEID_CHR(+)
            and b.USAGEID_CHR=d.USAGEID_CHR(+)
            AND b.itemsrcid_vchr = c.medicineid_chr(+)
            and b.ordercateid_chr=f.ordercateid_chr(+)
            and f.clacarea_chr=g.deptid_chr(+)";
             */
            string strSQL = @"
            SELECT a.rowno_chr, a.usageid_chr, a.itemid_chr, a.qty_dec, a.clinictype_int, a.bihqty_dec, a.bihtype_int, a.continueusetype_int, a.bihexecdeptflag_int, a.bihexecdeptid_chr,
            b.itemid_chr, b.itemname_vchr, b.itemcode_vchr, b.itempycode_chr, b.itemwbcode_chr, b.itemsrcid_vchr, b.itemsrctype_int, b.itemspec_vchr, b.itemprice_mny,
             b.itemunit_chr, b.itemopunit_chr, b.itemipunit_chr, b.itemopcalctype_chr, b.itemipcalctype_chr, b.itemopinvtype_chr, b.itemipinvtype_chr, b.dosage_dec, 
            b.dosageunit_chr, b.isgroupitem_int, b.itemcatid_chr, b.usageid_chr, b.itemopcode_chr, b.insuranceid_chr, b.selfdefine_int, b.packqty_dec,
             b.tradeprice_mny, b.poflag_int, b.isrich_int, b.opchargeflg_int, b.itemsrcname_vchr, b.itemsrctypename_vchr, b.itemengname_vchr, b.ifstop_int,
             b.pdcarea_vchr, b.ipchargeflg_int, b.insurancetype_vchr, b.apply_type_int, b.itembihctype_chr, b.defaultpart_vchr, b.itemchecktype_chr, 
            b.itemcommname_vchr, b.ordercateid_chr, b.freqid_chr, b.inpinsurancetype_vchr, b.ordercateid1_chr, b.isselfpay_chr, b.itemprice_mny_old, 
            b.itemprice_mny_new, b.keepuse_int, b.price_temp, b.itemspec_vchr1, b.lastchange_dat, c.noqtyflag_int,d.USAGEID_CHR as USAGEID_CHR1,d.USAGENAME_VCHR as USAGENAME_VCHR1,e.USAGENAME_VCHR,
            g.deptid_chr,
            g.deptname_vchr,
            f.seq_int,
            f.seq_int  F_seq_int,
            f.orderid_chr F_orderid_chr,                  
            f.orderdicid_chr   F_orderdicid_chr,              
            f.chargeitemid_chr  F_chargeitemid_chr ,            
            f.clacarea_chr    F_clacarea_chr ,            
            f.createarea_chr  F_createarea_chr ,              
            f.chargeitemname_chr  F_chargeitemname_chr ,          
            f.spec_vchr       F_spec_vchr         ,    
            f.unit_vchr          F_unit_vchr    ,        
            f.amount_dec            F_amount_dec    ,     
            f.unitprice_dec         F_unitprice_dec  ,       
            f.creatorid_chr         F_creatorid_chr,   
            f.creator_vchr          F_creator_vchr   ,    
            f.createdate_dat        F_createdate_dat

            FROM t_bse_chargeitemusagegroup a, t_bse_chargeitem b, t_bse_medicine c,t_bse_usagetype d,t_bse_usagetype e,
            T_OPR_BIH_ORDERCHARGEDEPT  f,
            t_bse_deptdesc  g,
            t_opr_bih_order h
            WHERE 
              h.dosetypeid_chr=a.usageid_chr 
              and h.orderid_chr=f.orderid_chr
            AND a.itemid_chr = b.itemid_chr
            and b.itemid_chr=f.chargeitemid_chr
            and a.USAGEID_CHR=e.USAGEID_CHR(+)
            and b.USAGEID_CHR=d.USAGEID_CHR(+)
            AND b.itemsrcid_vchr = c.medicineid_chr(+)
            and f.flag_int=1
            and f.clacarea_chr=g.deptid_chr(+)
            and h.orderid_chr='[orderid_chr]'
            ";
            strSQL = strSQL.Replace("[orderid_chr]", p_strOrderID.Trim());
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            objHRPSvc.Dispose();
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                objResult = new clsChargeItem_VO[dtbResult.Rows.Count];
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    objResult[i1] = new clsChargeItem_VO();
                    /*
                    objResult[i1].m_intIFSTOP_INT = int.Parse(dtbResult.Rows[i1]["IFSTOP_INT"].ToString());
                  
                    if (dtbResult.Rows[i1]["NOQTYFLAG_INT"] != System.DBNull.Value)
                        objResult[i1].m_intStopFlag = int.Parse(dtbResult.Rows[i1]["NOQTYFLAG_INT"].ToString());
                    else
                        objResult[i1].m_intStopFlag = 0;
                    objResult[i1].m_strItemID = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                    objResult[i1].m_strItemName = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
                    objResult[i1].m_strItemCode = dtbResult.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
           
                    objResult[i1].m_strItemSrcID = dtbResult.Rows[i1]["ITEMSRCID_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim() != "")
                        objResult[i1].m_intItemSrcType = Convert.ToInt32(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim());
                    objResult[i1].m_strItemSpec = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim() != "")
                        objResult[i1].m_fltItemPrice = Convert.ToSingle(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
                    objResult[i1].m_ItemUnit = new clsUnit_VO();
                    objResult[i1].m_ItemUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMUNIT_CHR"].ToString().Trim();
                    if (dtbResult.Columns.IndexOf("unitname_chr") > 0)
                        objResult[i1].m_ItemUnit.m_strUnitName = dtbResult.Rows[i1]["unitname_chr"].ToString().Trim();
                    objResult[i1].m_ItemOPUnit = new clsUnit_VO();
                    objResult[i1].m_ItemOPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
                    //objResult[i1].m_ItemOPUnit.m_strUnitName = dtbResult.Rows[i1]["OPUnit"].ToString().Trim();
                    objResult[i1].m_ItemIPUnit = new clsUnit_VO();
                    objResult[i1].m_ItemIPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemIPUnit.m_strUnitName = dtbResult.Rows[i1]["IPUnit"].ToString().Trim();
                    objResult[i1].m_ItemOPCalcType = new clsChargeItemEXType_VO();
                    objResult[i1].m_ItemOPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemOPCalcType.m_strTypeName = dtbResult.Rows[i1]["OPCal"].ToString().Trim();
                    objResult[i1].m_ItemIPCalcType = new clsChargeItemEXType_VO();
                    objResult[i1].m_ItemIPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemIPCalcType.m_strTypeName = dtbResult.Rows[i1]["IPCal"].ToString().Trim();
                    objResult[i1].m_ItemOPInvType = new clsChargeItemEXType_VO();
                    objResult[i1].m_ItemOPInvType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemOPInvType.m_strTypeName = dtbResult.Rows[i1]["OPInv"].ToString().Trim();
                    objResult[i1].m_ItemIPInvType = new clsChargeItemEXType_VO();
                    objResult[i1].m_ItemIPInvType.m_strTypeID = dtbResult.Rows[i1]["ROWNO_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemIPInvType.m_strTypeName = dtbResult.Rows[i1]["IPInv"].ToString().Trim();
                    if (dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim() != "")
                        objResult[i1].m_strDosage = Convert.ToSingle(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
                    objResult[i1].m_DosageUnit = new clsUnit_VO();//用量单位
                    objResult[i1].m_DosageUnit.m_strUnitID = dtbResult.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim();
                    //						objResult[i1].m_DosageUnit.m_strUnitName = dtbResult.Rows[i1]["DosageUnit"].ToString().Trim();
                    if (dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim() != "")
                        objResult[i1].m_intIsGroupItem = Convert.ToInt32(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim());
                    objResult[i1].m_ItemCat = new clsCharegeItemCat_VO();
                    objResult[i1].m_ItemCat.m_strItemCatID = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemCat.m_strItemCatName = dtbResult.Rows[i1]["itemcatname_vchr"].ToString().Trim();
                    objResult[i1].m_Usage = new clsUsageType_VO();
                    if (dtbResult.Rows[i1]["USAGENAME_VCHR"].ToString().Trim() != "")
                    {
                        objResult[i1].m_Usage.m_strUsageID = dtbResult.Rows[i1]["USAGEID_CHR"].ToString().Trim();
                        objResult[i1].m_Usage.m_strUsageName = dtbResult.Rows[i1]["USAGENAME_VCHR"].ToString().Trim();
                    }
                    else
                    {
                        objResult[i1].m_Usage.m_strUsageID = dtbResult.Rows[i1]["USAGEID_CHR1"].ToString().Trim();
                        objResult[i1].m_Usage.m_strUsageName = dtbResult.Rows[i1]["USAGENAME_VCHR1"].ToString().Trim();
                    }
                    //						objResult[i1].m_Usage.m_strUsageName=dtbResult.Rows[i1]["usagename_vchr"].ToString().Trim();
                    objResult[i1].m_strITEMOPCODE_CHR = dtbResult.Rows[i1]["ITEMOPCODE_CHR"].ToString();
                    objResult[i1].m_strINSURANCEID_CHR = dtbResult.Rows[i1]["INSURANCEID_CHR"].ToString();
                    if (dtbResult.Rows[i1]["qty_dec"] != Convert.DBNull)
                    {
                        objResult[i1].m_strUNITPRICE = dtbResult.Rows[i1]["qty_dec"].ToString();
                        try
                        {
                            float sumprice = objResult[i1].m_fltItemPrice * float.Parse(objResult[i1].m_strUNITPRICE);
                            objResult[i1].m_strTOTALPRICE = sumprice.ToString();
                        }
                        catch
                        {

                        }
                    }
                    if (dtbResult.Rows[i1]["PACKQTY_DEC"] != Convert.DBNull)
                    {
                        objResult[i1].m_decPACKQTY_DEC = Decimal.Parse(dtbResult.Rows[i1]["PACKQTY_DEC"].ToString());
                    }
                    try
                    {
                        objResult[i1].m_intCLINICTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["CLINICTYPE_INT"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_dblBIHQTY_DEC = double.Parse(dtbResult.Rows[i1]["BIHQTY_DEC"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_intBIHTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["BIHTYPE_INT"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_intOPCHARGEFLG_INT = Int32.Parse(dtbResult.Rows[i1]["OPCHARGEFLG_INT"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_intIPCHARGEFLG_INT = Int32.Parse(dtbResult.Rows[i1]["IPCHARGEFLG_INT"].ToString());
                    }
                    catch { }
                    if (dtbResult.Rows[i1]["IPCHARGEFLG_INT"] != System.DBNull.Value)
                    {
                        try
                        {
                            objResult[i1].m_intCONTINUEUSETYPE_INT = Int32.Parse(dtbResult.Rows[i1]["CONTINUEUSETYPE_INT"].ToString());
                        }
                        catch { }
                    }
                    //						objResult[i1].m_strTOTALPRICE=dtbResult.Rows[i1]["TOTALPRICE_DEC"].ToString();
                     */
                    objResult[i1].m_strItemID = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                    objResult[i1].m_strItemName = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
                    try
                    {
                        objResult[i1].m_intOPCHARGEFLG_INT = Int32.Parse(dtbResult.Rows[i1]["OPCHARGEFLG_INT"].ToString());
                    }
                    catch { }
                    if (dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim() != "")
                        objResult[i1].m_fltItemPrice = Convert.ToSingle(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
                    if (dtbResult.Rows[i1]["PACKQTY_DEC"] != Convert.DBNull)
                    {
                        objResult[i1].m_decPACKQTY_DEC = Decimal.Parse(dtbResult.Rows[i1]["PACKQTY_DEC"].ToString());
                    }
                    if (dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim() != "")
                        objResult[i1].m_strDosage = Convert.ToSingle(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
                    try
                    {
                        objResult[i1].m_dblBIHQTY_DEC = double.Parse(dtbResult.Rows[i1]["BIHQTY_DEC"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_intBIHTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["BIHTYPE_INT"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_intIPCHARGEFLG_INT = Int32.Parse(dtbResult.Rows[i1]["IPCHARGEFLG_INT"].ToString());
                    }
                    catch { }
                    if (dtbResult.Rows[i1]["IPCHARGEFLG_INT"] != System.DBNull.Value)
                    {
                        try
                        {
                            objResult[i1].m_intCONTINUEUSETYPE_INT = Int32.Parse(dtbResult.Rows[i1]["CONTINUEUSETYPE_INT"].ToString());
                        }
                        catch { }
                    }
                    //暂存执行科室ID
                    objResult[i1].m_strItemPYCode = dtbResult.Rows[i1]["deptid_chr"].ToString().Trim();
                    //暂存执行科室名称
                    objResult[i1].m_strItemWBCode = dtbResult.Rows[i1]["deptname_vchr"].ToString().Trim();
                    //暂存住院诊疗项目收费项目执行客户表的流水号
                    objResult[i1].m_strItemCode = dtbResult.Rows[i1]["seq_int"].ToString().Trim();
                    clsORDERCHARGEDEPT_VO m_objOrderChargeDept = new clsORDERCHARGEDEPT_VO();
                    m_objOrderChargeDept.m_strSeq_int = clsConverter.ToString(dtbResult.Rows[i1]["F_seq_int"].ToString().Trim());
                    m_objOrderChargeDept.m_strOrderid_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_orderid_chr"].ToString().Trim());
                    m_objOrderChargeDept.m_strOrderdicid_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_orderdicid_chr"].ToString().Trim());
                    m_objOrderChargeDept.m_strChargeitemid_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_chargeitemid_chr"].ToString().Trim());
                    m_objOrderChargeDept.m_strClacarea_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_clacarea_chr"].ToString().Trim());
                    m_objOrderChargeDept.m_strCreatearea_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_createarea_chr"].ToString().Trim());
                    m_objOrderChargeDept.m_strChargeitemname_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_chargeitemname_chr"].ToString().Trim());
                    m_objOrderChargeDept.m_strSpec_vchr = clsConverter.ToString(dtbResult.Rows[i1]["F_spec_vchr"].ToString().Trim());
                    m_objOrderChargeDept.m_strUnit_vchr = clsConverter.ToString(dtbResult.Rows[i1]["F_unit_vchr"].ToString().Trim());
                    m_objOrderChargeDept.m_decAmount_dec = clsConverter.ToDecimal(dtbResult.Rows[i1]["F_amount_dec"].ToString().Trim());
                    m_objOrderChargeDept.m_decUnitprice_dec = clsConverter.ToDecimal(dtbResult.Rows[i1]["F_unitprice_dec"].ToString().Trim());
                    m_objOrderChargeDept.m_strCreatorid_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_creatorid_chr"].ToString().Trim());
                    m_objOrderChargeDept.m_strCreator_vchr = clsConverter.ToString(dtbResult.Rows[i1]["F_creator_vchr"].ToString().Trim());
                    m_objOrderChargeDept.m_strCreatedate_dat = clsConverter.ToDateTime(dtbResult.Rows[i1]["F_createdate_dat"].ToString().Trim());

                    objResult[i1].m_objORDERCHARGEDEPT_VO = m_objOrderChargeDept;
              
                }
            }
            return lngRes;
        }
        #endregion

        #region	查询诊疗项目|收费项目	根据医嘱ID
        /// <summary>
        /// 查询诊疗项目|收费项目	根据医嘱ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderdicChargeByOrderID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOrderID, out clsT_aid_bih_orderdic_charge_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_aid_bih_orderdic_charge_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc", "m_lngGetOrderdicChargeByOrderID");
            if (lngRes < 0)
            {
                return -1;
            }
            /*
            
            string strSQL = @"SELECT C.ITEMID_CHR,
            B.NAME_CHR OrdericName,
            C.ITEMNAME_VCHR ItemName,
            B.itemid_chr ChiefItemID,
            decode(A.itemid_chr, B.itemid_chr, '√', '×') IsChiefItem,
            decode(C.itemid_chr, B.itemid_chr,C.ITEMNAME_VCHR , '') ChiefItemName,
            decode(c.IPCHARGEFLG_INT,
            1,
            Round(c.ItemPrice_Mny / c.PackQty_Dec, 4),
            0,
            c.ItemPrice_Mny,
            Round(c.ItemPrice_Mny / c.PackQty_Dec, 4)) MinPrice,
            d.noqtyflag_int,
            g.deptid_chr,
            g.deptname_vchr
            FROM T_AID_BIH_ORDERDIC_CHARGE A,
            T_BSE_BIH_ORDERDIC        B,
            T_BSE_CHARGEITEM          C,
            t_bse_medicine            d,
            t_opr_bih_order           e,
            t_aid_bih_ocdeptdefault   f,
            t_bse_deptdesc            g
            WHERE A.orderdicid_chr = B.orderdicid_chr(+)
            AND A.itemid_chr = C.itemid_chr(+)
            AND (c.itemsrcid_vchr) = (d.medicineid_chr(+))
            and c.ordercateid_chr=f.ordercateid_chr(+)
            and f.clacarea_chr=g.deptid_chr(+)
            and A.orderdicid_chr =e.orderdicid_chr and e.orderid_chr = '[orderid_chr]'

            order by IsChiefItem desc";
             */
            string strSQL = @"
            SELECT C.ITEMID_CHR,
            B.NAME_CHR OrdericName,
            C.ITEMNAME_VCHR ItemName,
            B.itemid_chr ChiefItemID,
            decode(A.itemid_chr, B.itemid_chr, '√', '×') IsChiefItem,
            decode(C.itemid_chr, B.itemid_chr,C.ITEMNAME_VCHR , '') ChiefItemName,
            decode(c.IPCHARGEFLG_INT,
            1,
            Round(c.ItemPrice_Mny / c.PackQty_Dec, 4),
            0,
            c.ItemPrice_Mny,
            Round(c.ItemPrice_Mny / c.PackQty_Dec, 4)) MinPrice,
            d.noqtyflag_int,
            g.deptid_chr,
            g.deptname_vchr,
            f.seq_int,
            f.seq_int  F_seq_int,
            f.orderid_chr F_orderid_chr,                  
            f.orderdicid_chr   F_orderdicid_chr,              
            f.chargeitemid_chr  F_chargeitemid_chr ,            
            f.clacarea_chr    F_clacarea_chr ,            
            f.createarea_chr  F_createarea_chr ,              
            f.chargeitemname_chr  F_chargeitemname_chr ,          
            f.spec_vchr       F_spec_vchr         ,    
            f.unit_vchr          F_unit_vchr    ,        
            f.amount_dec            F_amount_dec    ,     
            f.unitprice_dec         F_unitprice_dec  ,       
            f.creatorid_chr         F_creatorid_chr,   
            f.creator_vchr          F_creator_vchr   ,    
            f.createdate_dat        F_createdate_dat

            FROM T_AID_BIH_ORDERDIC_CHARGE A,
            T_BSE_BIH_ORDERDIC        B,
            T_BSE_CHARGEITEM          C,
            t_bse_medicine            d,
            t_opr_bih_order           e,
            T_OPR_BIH_ORDERCHARGEDEPT   f,
            t_bse_deptdesc            g
            WHERE A.orderdicid_chr = B.orderdicid_chr(+)
            AND A.itemid_chr = C.itemid_chr(+)
            AND (c.itemsrcid_vchr) = (d.medicineid_chr(+))
            and e.orderid_chr=f.orderid_chr
            and c.itemid_chr=f.chargeitemid_chr
            and f.clacarea_chr=g.deptid_chr(+)
            and A.orderdicid_chr =e.orderdicid_chr and e.orderid_chr = '[orderid_chr]'

            order by IsChiefItem desc
            ";

            strSQL = @"
SELECT   c.ITEMID_CHR,
            B.NAME_CHR OrdericName,
            C.ITEMNAME_VCHR ItemName,
            B.itemid_chr ChiefItemID,
            decode(C.itemid_chr, B.itemid_chr, '√', '×') IsChiefItem,
            decode(C.itemid_chr, B.itemid_chr,C.ITEMNAME_VCHR , '') ChiefItemName,
            decode(c.IPCHARGEFLG_INT,
            1,
            Round(c.ItemPrice_Mny / c.PackQty_Dec, 4),
            0,
            c.ItemPrice_Mny,
            Round(c.ItemPrice_Mny / c.PackQty_Dec, 4)) MinPrice,
            d.noqtyflag_int,
            g.deptid_chr,
            g.deptname_vchr,
            f.seq_int,
            f.seq_int  F_seq_int,
            f.orderid_chr F_orderid_chr,                  
            f.orderdicid_chr   F_orderdicid_chr,              
            f.chargeitemid_chr  F_chargeitemid_chr ,            
            f.clacarea_chr    F_clacarea_chr ,            
            f.createarea_chr  F_createarea_chr ,              
            f.chargeitemname_chr  F_chargeitemname_chr ,          
            f.spec_vchr       F_spec_vchr         ,    
            f.unit_vchr          F_unit_vchr    ,        
            f.amount_dec            F_amount_dec    ,     
            f.unitprice_dec         F_unitprice_dec  ,       
            f.creatorid_chr         F_creatorid_chr,   
            f.creator_vchr          F_creator_vchr   ,    
            f.createdate_dat        F_createdate_dat

            FROM 
            
            T_BSE_BIH_ORDERDIC        B,
            T_BSE_CHARGEITEM          C,
            t_bse_medicine            d,
            t_opr_bih_order           e,
            T_OPR_BIH_ORDERCHARGEDEPT   f,
            t_bse_deptdesc            g
            WHERE 
        
            f.orderid_chr=e.orderid_chr
            and e.ORDERDICID_CHR=b.ORDERDICID_CHR(+)
            and f.chargeitemid_chr=c.itemid_chr
            and (c.itemsrcid_vchr) = (d.medicineid_chr(+))
            and f.clacarea_chr=g.deptid_chr(+)
            and f.orderid_chr = '[orderid_chr]'
            and f.flag_int=0
            
            union all
            
            SELECT C.ITEMID_CHR,
            '' OrdericName,
            C.ITEMNAME_VCHR ItemName,
            '' ChiefItemID,
            '×' IsChiefItem,
            '' ChiefItemName,
            decode(c.IPCHARGEFLG_INT,
            1,
            Round(c.ItemPrice_Mny / c.PackQty_Dec, 4),
            0,
            c.ItemPrice_Mny,
            Round(c.ItemPrice_Mny / c.PackQty_Dec, 4)) MinPrice,
            d.noqtyflag_int,
            g.deptid_chr,
            g.deptname_vchr,
            f.seq_int,
            f.seq_int  F_seq_int,
            f.orderid_chr F_orderid_chr,                  
            f.orderdicid_chr   F_orderdicid_chr,              
            f.chargeitemid_chr  F_chargeitemid_chr ,            
            f.clacarea_chr    F_clacarea_chr ,            
            f.createarea_chr  F_createarea_chr ,              
            f.chargeitemname_chr  F_chargeitemname_chr ,          
            f.spec_vchr       F_spec_vchr         ,    
            f.unit_vchr          F_unit_vchr    ,        
            f.amount_dec            F_amount_dec    ,     
            f.unitprice_dec         F_unitprice_dec  ,       
            f.creatorid_chr         F_creatorid_chr,   
            f.creator_vchr          F_creator_vchr   ,    
            f.createdate_dat        F_createdate_dat

            FROM 
            
            T_BSE_CHARGEITEM          C,
            t_bse_medicine            d,
            t_opr_bih_order           e,
            T_OPR_BIH_ORDERCHARGEDEPT   f,
            t_bse_deptdesc            g
            WHERE 
            
            (c.itemsrcid_vchr) = (d.medicineid_chr(+))
            and e.orderid_chr=f.orderid_chr
            and c.itemid_chr=f.chargeitemid_chr
            and f.clacarea_chr=g.deptid_chr(+)
            and e.orderid_chr = '[orderid_chr]'
            and f.flag_int=2
            
            order by IsChiefItem desc
            ";

            strSQL = strSQL.Replace("[orderid_chr]", p_strOrderID.Trim());
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_aid_bih_orderdic_charge_VO[dtbResult.Rows.Count];
                    clsT_bse_chargeitem_VO objChargeItem = new clsT_bse_chargeitem_VO();
                    clsT_bse_bih_orderdic_VO objOrderDicItem = new clsT_bse_bih_orderdic_VO();
                   
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_aid_bih_orderdic_charge_VO();
                        #region 收费项目对象
                        //objChargeItem = new clsT_bse_chargeitem_VO();
                        //objChargeItem.m_strITEMID_CHR = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMNAME_VCHR = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
                        //objChargeItem.m_strITEMCODE_VCHR = dtbResult.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
                        //objChargeItem.m_strITEMPYCODE_CHR = dtbResult.Rows[i1]["ITEMPYCODE_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMWBCODE_CHR = dtbResult.Rows[i1]["ITEMWBCODE_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMSRCID_VCHR = dtbResult.Rows[i1]["ITEMSRCID_VCHR"].ToString().Trim();
                        //try
                        //{
                        //    objChargeItem.m_intITEMSRCTYPE_INT = Convert.ToInt32(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim());
                        //}
                        //catch { }
                        //objChargeItem.m_strITEMSPEC_VCHR = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
                        //try
                        //{
                        //    objChargeItem.m_dblITEMPRICE_MNY = double.Parse(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
                        //}
                        //catch { }
                        //objChargeItem.m_strITEMUNIT_CHR = dtbResult.Rows[i1]["ITEMUNIT_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMOPUNIT_CHR = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMIPUNIT_CHR = dtbResult.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMOPCALCTYPE_CHR = dtbResult.Rows[i1]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMIPCALCTYPE_CHR = dtbResult.Rows[i1]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMOPINVTYPE_CHR = dtbResult.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMIPINVTYPE_CHR = dtbResult.Rows[i1]["ITEMIPINVTYPE_CHR"].ToString().Trim();
                        //try
                        //{
                        //    objChargeItem.m_dblDOSAGE_DEC = double.Parse(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
                        //}
                        //catch { }
                        //objChargeItem.m_strDOSAGEUNIT_CHR = dtbResult.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim();
                        //try
                        //{
                        //    objChargeItem.m_intISGROUPITEM_INT = Convert.ToInt32(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim());
                        //}
                        //catch { }
                        //objChargeItem.m_strITEMCATID_CHR = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
                        //objChargeItem.m_strUSAGEID_CHR = dtbResult.Rows[i1]["USAGEID_CHR"].ToString().Trim();
                        //objChargeItem.m_strITEMOPCODE_CHR = dtbResult.Rows[i1]["ITEMOPCODE_CHR"].ToString().Trim();
                        //objChargeItem.m_strINSURANCEID_CHR = dtbResult.Rows[i1]["INSURANCEID_CHR"].ToString().Trim();
                        ////非字段
                        //try
                        //{
                        //    objChargeItem.m_intSELFDEFINE_INT = Convert.ToInt32(dtbResult.Rows[i1]["SELFDEFINE_INT"].ToString().Trim());
                        //}
                        //catch { }
                        //try
                        //{
                        //    objChargeItem.m_dblPACKQTY_DEC = double.Parse(dtbResult.Rows[i1]["PACKQTY_DEC"].ToString().Trim());
                        //}
                        //catch { }
                        //try
                        //{
                        //    objChargeItem.m_dblTRADEPRICE_MNY = double.Parse(dtbResult.Rows[i1]["TRADEPRICE_MNY"].ToString().Trim());
                        //}
                        //catch { }
                        //try
                        //{
                        //    objChargeItem.m_intPOFLAG_INT = Convert.ToInt32(dtbResult.Rows[i1]["POFLAG_INT"].ToString().Trim());
                        //}
                        //catch { }
                        ////非字段
                        //try
                        //{
                        //    objChargeItem.m_dblMinPrice = double.Parse(dtbResult.Rows[i1]["MinPrice"].ToString());
                        //}
                        //catch { }
                        objChargeItem = new clsT_bse_chargeitem_VO();
                        objChargeItem.m_strITEMID_CHR = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                        //暂存部门ID及部门名称 
                        objChargeItem.m_strITEMPYCODE_CHR = dtbResult.Rows[i1]["deptid_chr"].ToString().Trim();
                        objChargeItem.m_strITEMWBCODE_CHR = dtbResult.Rows[i1]["deptname_vchr"].ToString().Trim();
                        /*<===========================*/
                        try
                        {
                            objChargeItem.m_dblMinPrice = double.Parse(dtbResult.Rows[i1]["MinPrice"].ToString());
                        }
                        catch { }
                        p_objResultArr[i1].m_objChargeItem = objChargeItem;
                        #endregion
                        #region 诊疗项目对象
                        /*
                        objOrderDicItem = new clsT_bse_bih_orderdic_VO();
                        objOrderDicItem.m_strORDERDICID_CHR = dtbResult.Rows[i1]["ORDERDICID_CHR"].ToString().Trim();
                        objOrderDicItem.m_strNAME_CHR = dtbResult.Rows[i1]["NAME_CHR"].ToString().Trim();
                        objOrderDicItem.m_strDES_VCHR = dtbResult.Rows[i1]["DES_VCHR"].ToString().Trim();
                        objOrderDicItem.m_strUSERCODE_CHR = dtbResult.Rows[i1]["USERCODE_CHR"].ToString().Trim();
                        objOrderDicItem.m_strWBCODE_CHR = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
                        objOrderDicItem.m_strPYCODE_CHR = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
                        objOrderDicItem.m_strEXECDEPT_CHR = dtbResult.Rows[i1]["EXECDEPT_CHR"].ToString().Trim();
                        objOrderDicItem.m_strORDERCATEID_CHR = dtbResult.Rows[i1]["ORDERCATEID_CHR"].ToString().Trim();
                        objOrderDicItem.m_strITEMID_CHR = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                        objOrderDicItem.m_strNULLITEMDOSAGEUNIT_CHR = dtbResult.Rows[i1]["NULLITEMDOSAGEUNIT_CHR"].ToString().Trim();
                        objOrderDicItem.m_strNULLITEMUSEUNIT_CHR = dtbResult.Rows[i1]["NULLITEMUSEUNIT_CHR"].ToString().Trim();
                        objOrderDicItem.m_strNULLITEMDOSETYPEID_CHR = dtbResult.Rows[i1]["NULLITEMDOSETYPEID_CHR"].ToString().Trim();
                        //执行科室		[非字段]
                        objOrderDicItem.m_strExecdept = dtbResult.Rows[i1]["Execdept"].ToString().Trim();
                        //医嘱类型		[非字段]
                        objOrderDicItem.m_strOrderCate = dtbResult.Rows[i1]["OrderCate"].ToString().Trim();
                        //主收费项目	[非字段]
                        objOrderDicItem.m_strItem = dtbResult.Rows[i1]["Item"].ToString().Trim();
                        //用法名称	[非字段]
                        objOrderDicItem.m_strNullItemDosetypeName = dtbResult.Rows[i1]["NullItemDosetypeName"].ToString().Trim();
                        p_objResultArr[i1].m_objOrderDic = objOrderDicItem;
                         */
                        #endregion
                        #region 影射对象
                        /*
                        p_objResultArr[i1].m_strOCMAPID_CHR = dtbResult.Rows[i1]["OCMAPID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strORDERDICID_CHR = dtbResult.Rows[i1]["ORDERDICID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strITEMID_CHR = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intQTY_INT = Int32.Parse(dtbResult.Rows[i1]["QTY_INT"].ToString());
                        p_objResultArr[i1].m_intTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["TYPE_INT"].ToString());
                        //非字段
                        p_objResultArr[i1].m_strItemName = dtbResult.Rows[i1]["ItemName"].ToString().Trim();
                        p_objResultArr[i1].m_strOrdericName = dtbResult.Rows[i1]["OrdericName"].ToString().Trim();
                        p_objResultArr[i1].m_strChiefItemID = dtbResult.Rows[i1]["ChiefItemID"].ToString().Trim();
                        p_objResultArr[i1].m_strChiefItemName = dtbResult.Rows[i1]["ChiefItemName"].ToString().Trim();
                        p_objResultArr[i1].m_strIsChiefItem = dtbResult.Rows[i1]["IsChiefItem"].ToString().Trim();
                        p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        p_objResultArr[i1].m_strNoqtyFLag = dtbResult.Rows[i1]["noqtyflag_int"].ToString().Trim();
                        */
                        p_objResultArr[i1].m_strITEMID_CHR = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strItemName = dtbResult.Rows[i1]["ItemName"].ToString().Trim();
                        p_objResultArr[i1].m_strChiefItemID = dtbResult.Rows[i1]["ChiefItemID"].ToString().Trim();
                        p_objResultArr[i1].m_strChiefItemName = dtbResult.Rows[i1]["ChiefItemName"].ToString().Trim();
                        p_objResultArr[i1].m_strNoqtyFLag = dtbResult.Rows[i1]["noqtyflag_int"].ToString().Trim();
                        //暂存住院诊疗项目收费项目执行客户表的流水号
                        p_objResultArr[i1].m_strOCMAPID_CHR = dtbResult.Rows[i1]["seq_int"].ToString().Trim();
 
                        clsORDERCHARGEDEPT_VO m_objOrderChargeDept = new clsORDERCHARGEDEPT_VO();
                        m_objOrderChargeDept.m_strSeq_int = clsConverter.ToString(dtbResult.Rows[i1]["F_seq_int"].ToString().Trim());
                        m_objOrderChargeDept.m_strOrderid_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_orderid_chr"].ToString().Trim());
                        m_objOrderChargeDept.m_strOrderdicid_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_orderdicid_chr"].ToString().Trim());
                        m_objOrderChargeDept.m_strChargeitemid_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_chargeitemid_chr"].ToString().Trim());
                        m_objOrderChargeDept.m_strClacarea_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_clacarea_chr"].ToString().Trim());
                        m_objOrderChargeDept.m_strCreatearea_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_createarea_chr"].ToString().Trim());
                        m_objOrderChargeDept.m_strChargeitemname_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_chargeitemname_chr"].ToString().Trim());
                        m_objOrderChargeDept.m_strSpec_vchr = clsConverter.ToString(dtbResult.Rows[i1]["F_spec_vchr"].ToString().Trim());
                        m_objOrderChargeDept.m_strUnit_vchr = clsConverter.ToString(dtbResult.Rows[i1]["F_unit_vchr"].ToString().Trim());
                        m_objOrderChargeDept.m_decAmount_dec = clsConverter.ToDecimal(dtbResult.Rows[i1]["F_amount_dec"].ToString().Trim());
                        m_objOrderChargeDept.m_decUnitprice_dec = clsConverter.ToDecimal(dtbResult.Rows[i1]["F_unitprice_dec"].ToString().Trim());
                        m_objOrderChargeDept.m_strCreatorid_chr = clsConverter.ToString(dtbResult.Rows[i1]["F_creatorid_chr"].ToString().Trim());
                        m_objOrderChargeDept.m_strCreator_vchr = clsConverter.ToString(dtbResult.Rows[i1]["F_creator_vchr"].ToString().Trim());
                        m_objOrderChargeDept.m_strCreatedate_dat = clsConverter.ToDateTime(dtbResult.Rows[i1]["F_createdate_dat"].ToString().Trim());
                       
                        p_objResultArr[i1].m_objORDERCHARGEDEPT_VO = m_objOrderChargeDept;
                        #endregion

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

        #region 查询住院诊疗项目收费项目执行客户表相关的信息
        /// <summary>
        /// 查询住院诊疗项目收费项目执行客户表相关的信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSeq_int">流水号</param>
        /// <param name="objResult"></param>
        /// <param name="m_strGet">领量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_GetORDERCHARGEDEPT(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSeq_int, out clsBIHChargeItem objResult,out clsBIHExecOrder order)
        {
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            order =new  clsBIHExecOrder();
            objResult = new clsBIHChargeItem();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer", "m_GetORDERCHARGEDEPT");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"
           select  a.itemid_chr,
       a.itemname_vchr,
       a.itemcode_vchr,
       a.itempycode_chr,
       a.itemwbcode_chr,
       a.itemsrcid_vchr,
       a.itemsrctype_int,
       a.itemspec_vchr,
       a.itemprice_mny,
       a.itemunit_chr,
       a.itemopunit_chr,
       a.itemipunit_chr,
       a.itemopcalctype_chr,
       a.itemipcalctype_chr,
       a.itemopinvtype_chr,
       a.itemipinvtype_chr,
       a.dosage_dec,
       a.dosageunit_chr,
       a.isgroupitem_int,
       a.itemcatid_chr,
       a.usageid_chr,
       a.itemopcode_chr,
       a.insuranceid_chr,
       a.selfdefine_int,
       a.packqty_dec,
       a.tradeprice_mny,
       a.poflag_int,
       a.isrich_int,
       a.opchargeflg_int,
       a.itemsrcname_vchr,
       a.itemsrctypename_vchr,
       a.itemengname_vchr,
       a.ifstop_int,
       a.pdcarea_vchr,
       a.ipchargeflg_int,
       a.insurancetype_vchr,
       a.apply_type_int,
       a.itembihctype_chr,
       a.defaultpart_vchr,
       a.itemchecktype_chr,
       a.itemcommname_vchr,
       a.ordercateid_chr,
       a.freqid_chr,
       a.inpinsurancetype_vchr,
       a.ordercateid1_chr,
       a.isselfpay_chr,
       a.itemprice_mny_old,
       a.itemprice_mny_new,
       a.keepuse_int,
       a.price_temp,
       a.itemspec_vchr1,
       a.lastchange_dat, b.unitprice_dec itemprice,b.amount_dec,b.unit_vchr,b.spec_vchr,b.createarea_chr,b.remark,b.insuracedesc_vchr,b.continueusetype_int,
                  e.name_vchr patientname,f.code_chr bedname,c.name_vchr,g.deptid_chr,g.deptname_vchr
						from 
            t_bse_chargeitem a,
            t_opr_bih_orderchargedept b,
            t_opr_bih_order c,
            t_opr_bih_register d,
            t_opr_bih_registerdetail  e,
            t_bse_bed f,
            t_bse_deptdesc g
            where 
            a.itemid_chr=b.chargeitemid_chr
            and b.orderid_chr=c.orderid_chr
            and c.registerid_chr=d.registerid_chr
            and d.registerid_chr=e.registerid_chr(+)
            and b.clacarea_chr=g.deptid_chr(+)
            and d.areaid_chr=f.areaid_chr and d.bedid_chr=f.bedid_chr(+)
            and b.seq_int='[seq_int]'
            ";
            strSQL = strSQL.Replace("[seq_int]", p_strSeq_int.Trim());
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            objHRPSvc.Dispose();
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                   
            
                //暂存病人名称
                order.m_strPatientName = clsConverter.ToString(dtbResult.Rows[0]["PatientName"].ToString()).Trim();
                //暂存病人床号
                order.m_strBedName = clsConverter.ToString(dtbResult.Rows[0]["BedName"].ToString()).Trim();
                //暂存医嘱名称
                order.m_strName = clsConverter.ToString(dtbResult.Rows[0]["Name_Vchr"].ToString()).Trim();
                //暂存执行科室的ＩＤ和名称
                order.m_strExecDeptID = clsConverter.ToString(dtbResult.Rows[0]["deptid_chr"].ToString());
                order.m_strExecDeptName = clsConverter.ToString(dtbResult.Rows[0]["deptname_vchr"].ToString());
                //领量
                order.m_dmlGet = clsConverter.ToDecimal(dtbResult.Rows[0]["AMOUNT_DEC"].ToString());
                //开单科室
                order.m_strCREATEAREA_ID = clsConverter.ToString(dtbResult.Rows[0]["CREATEAREA_CHR"].ToString());
                //一次的剂量 
                order.m_dmlDosageRate = clsConverter.ToDecimal(dtbResult.Rows[0]["DOSAGE_DEC"].ToString());
                /*<==================*/
                if (dtbResult.Rows[0]["ItemSrcID_VChr"] != DBNull.Value)
                    objResult.m_strItemSrcID = clsConverter.ToString(dtbResult.Rows[0]["ItemSrcID_VChr"].ToString()).Trim();
                if (dtbResult.Rows[0]["ItemSpec_VChr"] != DBNull.Value)
                    objResult.m_strSpec = clsConverter.ToString(dtbResult.Rows[0]["ItemSpec_VChr"].ToString()).Trim();
                if (dtbResult.Rows[0]["ItemIpUnit_Chr"] != DBNull.Value)
                    objResult.m_strUnit = clsConverter.ToString(dtbResult.Rows[0]["ItemIpUnit_Chr"].ToString()).Trim();
                if (dtbResult.Rows[0]["ItemIpCalcType_Chr"] != DBNull.Value)
                    objResult.m_strItemIPCalcType = clsConverter.ToString(dtbResult.Rows[0]["ItemIpCalcType_Chr"].ToString()).Trim();
                if (dtbResult.Rows[0]["ItemIpInvType_Chr"] != DBNull.Value)
                    objResult.m_strItemIPInvType = clsConverter.ToString(dtbResult.Rows[0]["ItemIpInvType_Chr"].ToString()).Trim();
                    if(dtbResult.Rows[0]["ItemID_Chr"]!=DBNull.Value)
                    objResult.m_strItemID = clsConverter.ToString(dtbResult.Rows[0]["ItemID_Chr"].ToString()).Trim();
                if (dtbResult.Rows[0]["ItemName_VChr"] != DBNull.Value)
                    objResult.m_strItemName = clsConverter.ToString(dtbResult.Rows[0]["ItemName_VChr"].ToString()).Trim();
                objResult.m_intIsRich = clsConverter.ToInt(dtbResult.Rows[0]["IsRich_Int"].ToString());
                objResult.m_dmlPrice = clsConverter.ToDecimal(dtbResult.Rows[0]["ItemPrice"].ToString());
                objResult.m_strItemCode = clsConverter.ToString(dtbResult.Rows[0]["ITEMCODE_VCHR"].ToString().Trim());
                objResult.REMARK = clsConverter.ToString(dtbResult.Rows[0]["REMARK"].ToString().Trim());
                objResult.m_strINSURACEDESC_VCHR = clsConverter.ToString(dtbResult.Rows[0]["INSURACEDESC_VCHR"].ToString().Trim());
                objResult.m_intCONTINUEUSETYPE_INT = clsConverter.ToInt(dtbResult.Rows[0]["CONTINUEUSETYPE_INT"].ToString().Trim());
                
            }
            return lngRes;
        }
        #endregion

        #region 查询部门列表
        [AutoComplete]
        public long m_lngGetDEPTList(System.Security.Principal.IPrincipal p_objPrincipal, string strFindCode, string p_strSeq_int,out ArrayList[] arrItem)
        {
            DataTable dtbResult = new DataTable();
            arrItem = new ArrayList[0];
            long lngRes = 0;
          
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer", "m_lngGetDEPTList");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"
          
            select distinct b.deptid_chr,b.deptname_vchr from 
            t_aid_bih_ocdeptlist a,
            t_bse_deptdesc b,
            T_OPR_BIH_ORDERCHARGEDEPT c,
            T_BSE_CHARGEITEM D
            where 
            c.chargeitemid_chr=d.itemid_chr
            and
            d.ordercateid_chr=a.ordercateid_chr
            and 
            a.clacarea_chr=b.deptid_chr
           and
            (
            b.code_vchr like ?
            or
            b.pycode_chr like ?
            or
            b.wbcode_chr like ?
            or
            b.deptname_vchr like ?
            )
            and
            c.seq_int=?
            ";
            
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strFind = strFindCode.ToLower().Trim() + "%";
            
            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(5, out arrParams);
            arrParams[0].Value = strFind;
            arrParams[1].Value = strFind;
            arrParams[2].Value = strFind;
            arrParams[3].Value = strFind;
            arrParams[4].Value = p_strSeq_int;
            
            
            try
            {
                lngRes = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                lngRes = new clsHRPTableService().lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);


                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    arrItem = new ArrayList[dtbResult.Rows.Count];
                    for (int i = 0; i < arrItem.Length; i++)
                    {
                        arrItem[i] = new ArrayList();
                    }
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        arrItem[i].Add(clsConverter.ToString(dtbResult.Rows[i]["deptid_chr"].ToString()).Trim());
                        arrItem[i].Add(clsConverter.ToString(dtbResult.Rows[i]["deptname_vchr"].ToString()).Trim());
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

        public long m_lngGetDEPTList(System.Security.Principal.IPrincipal p_objPrincipal, string strFindCode, string p_strChangeItemCode, out ArrayList[] arrItem,bool m_blNewTag)
        {
            DataTable dtbResult = new DataTable();
            arrItem = new ArrayList[0];
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer", "m_lngGetDEPTList");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"
          
            select distinct b.deptid_chr,b.deptname_vchr from 
            t_aid_bih_ocdeptlist a,
            t_bse_deptdesc b,
          
            T_BSE_CHARGEITEM D
            where 
           
            d.ordercateid_chr=a.ordercateid_chr
            and 
            a.clacarea_chr=b.deptid_chr
           and
            (
            b.code_vchr like ?
            or
            b.pycode_chr like ?
            or
            b.wbcode_chr like ?
            or
            b.deptname_vchr like ?
            )
            and
            d.itemid_chr=?
            ";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strFind = strFindCode.ToLower().Trim() + "%";

            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(5, out arrParams);
            arrParams[0].Value = strFind;
            arrParams[1].Value = strFind;
            arrParams[2].Value = strFind;
            arrParams[3].Value = strFind;
            arrParams[4].Value = p_strChangeItemCode.Trim();


            try
            {
                lngRes = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                lngRes = new clsHRPTableService().lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);


                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    arrItem = new ArrayList[dtbResult.Rows.Count];
                    for (int i = 0; i < arrItem.Length; i++)
                    {
                        arrItem[i] = new ArrayList();
                    }
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        arrItem[i].Add(clsConverter.ToString(dtbResult.Rows[i]["deptid_chr"].ToString()).Trim());
                        arrItem[i].Add(clsConverter.ToString(dtbResult.Rows[i]["deptname_vchr"].ToString()).Trim());
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

        public long m_lngGetDEPTList(System.Security.Principal.IPrincipal p_objPrincipal, string strFindCode,  out ArrayList[] arrItem)
        {
            DataTable dtbResult = new DataTable();
            arrItem = new ArrayList[0];
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer", "m_lngGetDEPTList");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"
          
            select distinct b.deptid_chr,b.deptname_vchr from 
           
            t_bse_deptdesc b
            where 
          
            b.code_vchr like ?
            or
            b.pycode_chr like ?
            or
            b.wbcode_chr like ?
            or
            b.deptname_vchr like ?
           
           
            ";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strFind = strFindCode.ToLower().Trim() + "%";

            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(4, out arrParams);
            arrParams[0].Value = strFind;
            arrParams[1].Value = strFind;
            arrParams[2].Value = strFind;
            arrParams[3].Value = strFind;

            try
            {
                lngRes = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                lngRes = new clsHRPTableService().lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);


                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    arrItem = new ArrayList[dtbResult.Rows.Count];
                    for (int i = 0; i < arrItem.Length; i++)
                    {
                        arrItem[i] = new ArrayList();
                    }
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        arrItem[i].Add(clsConverter.ToString(dtbResult.Rows[i]["deptid_chr"].ToString()).Trim());
                        arrItem[i].Add(clsConverter.ToString(dtbResult.Rows[i]["deptname_vchr"].ToString()).Trim());
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

        #region 更新相关的收费项目明细的执行部门
        [AutoComplete]
        public long SaveTheDeptChange(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSeq_int,string m_strClacarea_chr)
        {
                long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer", "SaveTheDeptChange");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"
            update T_OPR_BIH_ORDERCHARGEDEPT a
            set 
            a.clacarea_chr='[clacarea_chr]'
            where
            a.seq_int='[seq_int]'
            ";
            strSQL = strSQL.Replace("[clacarea_chr]", m_strClacarea_chr.Trim());
            strSQL = strSQL.Replace("[seq_int]", p_strSeq_int.Trim());
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
           
            try
            {
                lngRes = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                lngRes = objHRPSvc.DoExcute(strSQL);

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

        //获取收费项目对应的申请/执行科室
        /// <summary>
        /// 获取收费项目对应的申请/执行科室
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="CREATEAREA_CHR">申请科室</param>
        /// <param name="ItemID_Chr">收费项目ID</param>
        /// <param name="arrItem"></param>
        /// <returns></returns>
        public long m_lngGetDEPTDefault(System.Security.Principal.IPrincipal p_objPrincipal, string CREATEAREA_CHR,string ItemID_Chr, out ArrayList arrItem)
        {
            DataTable dtbResult = new DataTable();
            arrItem = new ArrayList();
            long lngRes = 0;
            string CLACAREA_CHR  = "";//执行科室ID
            string deptname_vchr = "";//执行科室名称
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer", "m_lngGetDEPTList");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"
                        select
                        b.CLACAREA_CHR,
                        c.CLACAREA_CHR CLACAREA_CHR2,
                        d.deptname_vchr,
                        e.deptname_vchr deptname_vchr2
                        from 
                        T_BSE_CHARGEITEM a,
                        t_aid_bih_ocdeptdefault b,
                        t_aid_bih_ocdeptlist c,
                        T_BSE_DeptDesc d,
                        T_BSE_DeptDesc e
                        where
                        a.ordercateid_chr=b.ordercateid_chr(+)
                        and
                        a.ordercateid_chr=c.ordercateid_chr(+)
                        and
                        b.clacarea_chr=d.deptid_chr(+)
                        and
                        c.clacarea_chr=e.deptid_chr(+)
                        and
                        rownum=1
                        and
                        b.createarea_chr=?
                        and
                        a.itemid_chr=?
                        ";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            System.Data.IDataParameter[] arrParams = null;
            objHRPSvc.CreateDatabaseParameter(2, out arrParams);
            arrParams[0].Value = CREATEAREA_CHR;
            arrParams[1].Value = ItemID_Chr;
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    CLACAREA_CHR = clsConverter.ToString(dtbResult.Rows[0]["CLACAREA_CHR"].ToString());
                    deptname_vchr = clsConverter.ToString(dtbResult.Rows[0]["deptname_vchr"].ToString());
                    if (CLACAREA_CHR.Trim().Equals(""))
                    {
                        CLACAREA_CHR = clsConverter.ToString(dtbResult.Rows[0]["CLACAREA_CHR2"].ToString());
                        deptname_vchr = clsConverter.ToString(dtbResult.Rows[0]["deptname_vchr2"].ToString());
                    }
                }

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    arrItem.Add(CLACAREA_CHR);
                    arrItem.Add(deptname_vchr);
                    
                }
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
       

    }

    
}
