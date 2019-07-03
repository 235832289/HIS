using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{   
    /// <summary>
    /// 计费类中间件
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsCalPatientChargeSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsCalPatientChargeSvc()
        {

        }
        /// <summary>
        /// 获取注射单打印信息

        /// </summary>
        /// <param name="m_strSid_int"></param>
        /// <param name="obj_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrintData( string m_strSid_int, out ArrayList m_objList1, out ArrayList m_objList2, out ArrayList m_objListGroupName, out clsOutpatientPrintRecipe_VO obj_VO)
        {
            long lngRes = 0;
            m_objList1 = new ArrayList();
            m_objList2 = new ArrayList();
            m_objListGroupName = new ArrayList();
            obj_VO = new clsOutpatientPrintRecipe_VO();
            string strSQL = @" select   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
         b.itemid_chr, b.unitid_chr, b.usageid_chr, b.tolqty_dec,
         b.unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, b.days_int, b.qty_dec, b.discount_dec,
         b.freqid_chr, b.itemname_vchr, b.dosageunit_chr, b.itemspec_vchr,
         h.usagename_vchr, k.freqname_chr, b.dosage_dec, c.birth_dat,
         a.recorddate_dat, g.lastname_vchr as doctorname_chr, c.lastname_vchr,
         c.sex_chr, j.patientcardid_chr, b.desc_vchr, m1.serno_chr,
         e.diag_vchr
    from t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_outpatientrecipe a,
         t_opr_outpatientpwmrecipede b,
         t_bse_chargeitem d,
         t_opr_outpatientcasehis e,
         (select distinct (usageid_chr)
                     from t_opr_setusage
                    where orderid_vchr = 1 or orderid_vchr = 0) f,
         t_bse_usagetype h,
         t_aid_recipefreq k,
         t_bse_patient c,
         t_bse_employee g,
         t_bse_medicine m,
         t_bse_patientcard j
   where m1.sid_int = n1.sid_int
     and m1.sid_int = ?
     and a.outpatrecipeid_chr = n1.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
     and b.itemid_chr = d.itemid_chr(+)
     and b.freqid_chr = k.freqid_chr
     and b.usageid_chr = f.usageid_chr
     and b.usageid_chr = h.usageid_chr
     and a.patientid_chr = c.patientid_chr
     and a.diagdr_chr = g.empid_chr(+)
     and d.itemsrcid_vchr = m.medicineid_chr
     and a.patientid_chr = j.patientid_chr
     and a.casehisid_chr = e.casehisid_chr
union all
select   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
         b.itemid_chr, b.unitid_chr, b.usageid_chr, 0 as tolqty_dec,
         b.unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
         h.usagename_vchr, '' as freqname_chr, d.dosage_dec, c.birth_dat,
         a.recorddate_dat, g.lastname_vchr as doctorname_chr, c.lastname_vchr,
         c.sex_chr, j.patientcardid_chr, n.desc_vchr, m1.serno_chr,
         e.diag_vchr
    from t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_outpatientrecipe a,
         t_opr_outpatientcmrecipede b,
         t_bse_chargeitem d,
         t_opr_outpatientpwmrecipede n,
         t_opr_outpatientcasehis e,
         (select distinct (usageid_chr)
                     from t_opr_setusage
                    where orderid_vchr = 1 or orderid_vchr = 0) f,
         t_bse_usagetype h,
         t_bse_patient c,
         t_bse_employee g,
         t_bse_medicine m,
         t_bse_patientcard j
   where m1.sid_int = n1.sid_int
     and m1.sid_int = ?
     and a.outpatrecipeid_chr = n1.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
     and b.itemid_chr = d.itemid_chr(+)
     and b.usageid_chr = f.usageid_chr
     and b.usageid_chr = h.usageid_chr
     and a.patientid_chr = c.patientid_chr
     and a.diagdr_chr = g.empid_chr(+)
     and d.itemsrcid_vchr = m.medicineid_chr
     and a.patientid_chr = j.patientid_chr
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
     and a.casehisid_chr = e.casehisid_chr
union all
select   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
         b.itemid_chr, b.itemunit_vchr as unitid_chr, '' as usageid_chr,
         0 as tolqty_dec, 0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
         '' as usagename_vchr, '' as freqname_chr, d.dosage_dec, c.birth_dat,
         a.recorddate_dat, g.lastname_vchr as doctorname_chr, c.lastname_vchr,
         c.sex_chr, j.patientcardid_chr, n.desc_vchr, m1.serno_chr,
         e.diag_vchr
    from t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_outpatientrecipe a,
         t_opr_outpatientchkrecipede b,
         t_opr_outpatientpwmrecipede n,
         t_bse_chargeitem d,
         t_opr_outpatientcasehis e,
         (select distinct (usageid_chr)
                     from t_opr_setusage
                    where orderid_vchr = 1 or orderid_vchr = 0) f,
         t_bse_patient c,
         t_bse_employee g,
         t_bse_medicine m,
         t_bse_patientcard j
   where m1.sid_int = n1.sid_int
     and m1.sid_int = ?
     and a.outpatrecipeid_chr = n1.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
     and b.itemid_chr = d.itemid_chr(+)
     and d.usageid_chr = f.usageid_chr
     and a.patientid_chr = c.patientid_chr
     and a.diagdr_chr = g.empid_chr(+)
     and d.itemsrcid_vchr = m.medicineid_chr
     and a.patientid_chr = j.patientid_chr
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
     and a.casehisid_chr = e.casehisid_chr
union all
select   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
         b.itemid_chr, b.itemunit_vchr as unitid_chr, '' as usageid_chr,
         0 as tolqty_dec, 0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
         '' as usagename_vchr, '' as freqname_chr, d.dosage_dec, c.birth_dat,
         a.recorddate_dat, g.lastname_vchr as doctorname_chr, c.lastname_vchr,
         c.sex_chr, j.patientcardid_chr, n.desc_vchr, m1.serno_chr,
         e.diag_vchr
    from t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_outpatientrecipe a,
         t_opr_outpatienttestrecipede b,
         t_opr_outpatientpwmrecipede n,
         t_bse_chargeitem d,
         t_opr_outpatientcasehis e,
         (select distinct (usageid_chr)
                     from t_opr_setusage
                    where orderid_vchr = 1 or orderid_vchr = 0) f,
         t_bse_patient c,
         t_bse_employee g,
         t_bse_medicine m,
         t_bse_patientcard j
   where m1.sid_int = n1.sid_int
     and m1.sid_int = ?
     and a.outpatrecipeid_chr = n1.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
     and b.itemid_chr = d.itemid_chr(+)
     and d.usageid_chr = f.usageid_chr
     and a.patientid_chr = c.patientid_chr
     and a.diagdr_chr = g.empid_chr(+)
     and d.itemsrcid_vchr = m.medicineid_chr
     and a.patientid_chr = j.patientid_chr
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
     and a.casehisid_chr = e.casehisid_chr
union all
select   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
         b.itemid_chr, b.itemunit_vchr as unitid_chr, '' as usageid_chr,
         0 as tolqty_dec, 0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
         '' as usagename_vchr, '' as freqname_chr, d.dosage_dec, c.birth_dat,
         a.recorddate_dat, g.lastname_vchr as doctorname_chr, c.lastname_vchr,
         c.sex_chr, j.patientcardid_chr, n.desc_vchr, m1.serno_chr,
         e.diag_vchr
    from t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_outpatientrecipe a,
         t_opr_outpatientopsrecipede b,
         t_opr_outpatientpwmrecipede n,
         t_bse_chargeitem d,
         t_opr_outpatientcasehis e,
         (select distinct (usageid_chr)
                     from t_opr_setusage
                    where orderid_vchr = 1 or orderid_vchr = 0) f,
         t_bse_patient c,
         t_bse_employee g,
         t_bse_medicine m,
         t_bse_patientcard j
   where m1.sid_int = n1.sid_int
     and m1.sid_int = ?
     and a.outpatrecipeid_chr = n1.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
     and b.itemid_chr = d.itemid_chr(+)
     and d.usageid_chr = f.usageid_chr
     and a.patientid_chr = c.patientid_chr
     and a.diagdr_chr = g.empid_chr(+)
     and d.itemsrcid_vchr = m.medicineid_chr
     and a.patientid_chr = j.patientid_chr
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
     and a.casehisid_chr = e.casehisid_chr
union all
select   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
         b.itemid_chr, b.itemunit_vchr as unitid_chr, '' as usageid_chr,
         0 as tolqty_dec, 0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
         '' as usagename_vchr, '' as freqname_chr, d.dosage_dec, c.birth_dat,
         a.recorddate_dat, g.lastname_vchr as doctorname_chr, c.lastname_vchr,
         c.sex_chr, j.patientcardid_chr, n.desc_vchr, m1.serno_chr,
         e.diag_vchr
    from t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_outpatientrecipe a,
         t_opr_outpatientothrecipede b,
         t_opr_outpatientpwmrecipede n,
         t_bse_chargeitem d,
         t_opr_outpatientcasehis e,
         (select distinct (usageid_chr)
                     from t_opr_setusage
                    where orderid_vchr = 1 or orderid_vchr = 0) f,
         t_bse_patient c,
         t_bse_employee g,
         t_bse_medicine m,
         t_bse_patientcard j
   where m1.sid_int = n1.sid_int
     and m1.sid_int = ?
     and a.outpatrecipeid_chr = n1.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
     and b.itemid_chr = d.itemid_chr(+)
     and d.usageid_chr = f.usageid_chr
     and a.patientid_chr = c.patientid_chr
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
     and a.diagdr_chr = g.empid_chr(+)
     and d.itemsrcid_vchr = m.medicineid_chr
     and a.patientid_chr = j.patientid_chr
     and a.casehisid_chr = e.casehisid_chr
order by rowno_chr";
            DataTable dtbResult = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strSid_int;
                objLisAddItemRefArr[1].Value = m_strSid_int;
                objLisAddItemRefArr[2].Value = m_strSid_int;
                objLisAddItemRefArr[3].Value = m_strSid_int;
                objLisAddItemRefArr[4].Value = m_strSid_int;
                objLisAddItemRefArr[5].Value = m_strSid_int;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                   
                    DateTime dteBirth = Convert.ToDateTime("1900-1-1");
                    if (dtbResult.Rows[0]["BIRTH_DAT"] != System.DBNull.Value)
                        dteBirth = Convert.ToDateTime(dtbResult.Rows[0]["BIRTH_DAT"].ToString());

                    if (obj_VO == null)
                    {
                        obj_VO = new clsOutpatientPrintRecipe_VO();
                        obj_VO.objinjectArr = new ArrayList();
                        obj_VO.objPRDArr = new ArrayList();
                        obj_VO.objPRDArr2 = new ArrayList();
                    }
                    //obj_VO.m_strAge = clsConvertDateTime.CalcAge(dteBirth);
                    obj_VO.m_strAge =new clsBrithdayToAge().m_strGetAge(dteBirth);
                    obj_VO.m_strDiagDrName = dtbResult.Rows[0]["DOCTORNAME_CHR"].ToString().Trim();
                    obj_VO.m_strHospitalName ="";
                    obj_VO.m_strPatientName = dtbResult.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
                    obj_VO.m_strPhotoNo = dtbResult.Rows[0]["HOMEPHONE_VCHR"].ToString().Trim();
                    obj_VO.m_strCardID = dtbResult.Rows[0]["PATIENTCARDID_CHR"].ToString().Trim();
                    obj_VO.m_strAddress = "";
                    obj_VO.m_strRecipeType = "";
                    obj_VO.m_strdiagnose = dtbResult.Rows[0]["diag_vchr"].ToString().Trim();
                    obj_VO.m_strGOVCARD = "";
                    obj_VO.m_strINSURANCEID = "";
                    obj_VO.m_strRecordEmpID = "";//员工ID
                    obj_VO.m_strRegisterID = "";
                    if (dtbResult.Rows[0]["RECORDDATE_DAT"] != System.DBNull.Value)
                        obj_VO.m_strPrintDate = DateTime.Parse(dtbResult.Rows[0]["RECORDDATE_DAT"].ToString()).ToString("yyyy-MM-dd");
                    else
                        obj_VO.m_strPrintDate = DateTime.Now.ToString("yyyy-MM-dd");
                    obj_VO.m_strSex = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
                    obj_VO.m_strSelfPay = "";
                    obj_VO.m_strChargeUp = "";
                    obj_VO.m_strRecipePrice = "";
                    obj_VO.m_strSelfPay = "";
                    obj_VO.m_strHerbalmedicineUsage = "";
                    obj_VO.m_strTimes = "";
                    obj_VO.m_strSerNO = dtbResult.Rows[0]["SERNO_CHR"].ToString().Trim();
                    obj_VO.objinjectArr2 = new ArrayList();
                    int temRow = 0;
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                        objtemp.m_strChargeName = dtbResult.Rows[i]["ITEMNAME_VCHR"].ToString().Trim();
                        objtemp.m_strCount = dtbResult.Rows[i]["TOLQTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                        objtemp.m_strPrice = dtbResult.Rows[i]["UNITPRICE_MNY"].ToString().Trim();
                        objtemp.m_strSumPrice = dtbResult.Rows[i]["TOLPRICE_MNY"].ToString().Trim();
                        objtemp.m_strUnit = dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                        objtemp.m_strFrequency = dtbResult.Rows[i]["FREQNAME_CHR"].ToString().Trim();
                        objtemp.m_strDosage = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["dosageunit_chr"].ToString().Trim();
                        objtemp.m_strDays = dtbResult.Rows[i]["DAYS_INT"].ToString().Trim();
                        objtemp.m_strSpec = dtbResult.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim();
                        objtemp.m_strUsage = dtbResult.Rows[i]["USAGENAME_VCHR"].ToString().Trim();
                        objtemp.m_strRowNo = dtbResult.Rows[i]["ROWNO_CHR"].ToString().Trim();
                        objtemp.m_strUsageDetail = dtbResult.Rows[i]["DESC_VCHR"].ToString().Trim();
                        if (objtemp.m_strRowNo == "" || objtemp.m_strRowNo == "0")
                        {
                            objtemp.m_strRowNo = "0" + temRow.ToString();
                            temRow++;
                        }
                        obj_VO.objinjectArr2.Add(objtemp);

                    }
                }
                else
                {
                 
                    obj_VO.m_strAge = "";
                    obj_VO.m_strDiagDrName = "";
                    obj_VO.m_strHospitalName = "";
                    obj_VO.m_strPatientName = "";
                    // obj_VO.m_strRecipeID = strRecipedeID;
                    obj_VO.m_strAddress = "";
                    obj_VO.m_strRecipeType = "";
                    obj_VO.m_strdiagnose = "";
                    obj_VO.m_strGOVCARD = "";
                    obj_VO.m_strINSURANCEID = "";
                    obj_VO.m_strRecordEmpID = "";//员工ID
                    obj_VO.m_strRegisterID = "";
                    obj_VO.m_strPrintDate = "";
                    obj_VO.m_strSex = "";
                    obj_VO.m_strSelfPay = "";
                    obj_VO.m_strChargeUp = "";
                    obj_VO.m_strRecipePrice = "";
                    obj_VO.m_strSelfPay = "";
                    obj_VO.m_strHerbalmedicineUsage = "";
                    obj_VO.m_strTimes = "";
                    obj_VO.objinjectArr2 = new ArrayList();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            DataTable ArrdtRow = new DataTable();
            ArrdtRow.Columns.Add("rowno_chr");
            ArrdtRow.Columns.Add("USAGEID_CHR");
            DataRow[] objRowsList = dtbResult.Select("rowno_chr>0 and USAGEID_CHR is not null", "rowno_chr");
            if (objRowsList.Length > 0)
            {
                for (int j = 0; j < objRowsList.Length; j++)
                {
                    if (j == 0)
                    {
                        DataRow newRow = ArrdtRow.NewRow();
                        newRow["rowno_chr"] = objRowsList[j]["rowno_chr"].ToString();
                        newRow["USAGEID_CHR"] = objRowsList[j]["USAGEID_CHR"].ToString();
                        ArrdtRow.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int r = 0; r < ArrdtRow.Rows.Count; r++)
                        {
                            if (objRowsList[j]["rowno_chr"].ToString() == ArrdtRow.Rows[r]["rowno_chr"].ToString())
                                break;
                            if (r == ArrdtRow.Rows.Count - 1)
                            {
                                DataRow newRow = ArrdtRow.NewRow();
                                newRow["rowno_chr"] = objRowsList[j]["rowno_chr"].ToString();
                                newRow["USAGEID_CHR"] = objRowsList[j]["USAGEID_CHR"].ToString();
                                ArrdtRow.Rows.Add(newRow);
                            }
                        }
                    }
                }
            }
            DataTable dtItemArr = new DataTable();
            dtItemArr.Columns.Add("itemname_vchr");
            dtItemArr.Columns.Add("rowno_chr");
            dtItemArr.Columns.Add("itemid_chr");
            dtItemArr.Columns.Add("USAGEID_CHR");
            if (dtbResult.Rows.Count > 0)
            {
                for (int m = 0; m < dtbResult.Rows.Count; m++)
                {
                    if (m == 0)
                    {
                        DataRow newRow = dtItemArr.NewRow();
                        newRow["itemname_vchr"] = dtbResult.Rows[m]["itemname_vchr"].ToString();
                        newRow["rowno_chr"] = dtbResult.Rows[m]["rowno_chr"];
                        newRow["itemid_chr"] = dtbResult.Rows[m]["itemid_chr"].ToString();
                        newRow["USAGEID_CHR"] = dtbResult.Rows[m]["USAGEID_CHR"].ToString();
                        dtItemArr.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int n = 0; n < dtItemArr.Rows.Count; n++)
                        {
                            if (dtItemArr.Rows[n]["itemid_chr"].ToString().Trim() == dtbResult.Rows[m]["itemid_chr"].ToString().Trim() && dtItemArr.Rows[n]["rowno_chr"].ToString().Trim() == dtbResult.Rows[m]["rowno_chr"].ToString().Trim())
                                break;
                            if (n == dtItemArr.Rows.Count - 1)
                            {
                                DataRow newRow = dtItemArr.NewRow();
                                newRow["itemname_vchr"] = dtbResult.Rows[m]["itemname_vchr"].ToString();
                                newRow["rowno_chr"] = dtbResult.Rows[m]["rowno_chr"];
                                newRow["itemid_chr"] = dtbResult.Rows[m]["itemid_chr"].ToString();
                                newRow["USAGEID_CHR"] = dtbResult.Rows[m]["USAGEID_CHR"].ToString();
                                dtItemArr.Rows.Add(newRow);
                            }
                        }

                    }
                }
            }
            strSQL = @"SELECT   a.itemid_chr, a.operatorid_chr, a.exectime_dat, a.operatortype_int,
         b.lastname_vchr
    FROM t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_nurseexecute a,
         t_bse_employee b,
         (SELECT MAX (itemid_chr) itemid_chr
            FROM t_opr_nurseexecute p,t_opr_recipesend m,t_opr_recipesendentry n 
           WHERE m.sid_int=n.sid_int and p.outpatrecipeid_chr=n.outpatrecipeid_chr and m.sid_int=?
             AND (operatortype_int = 1 OR operatortype_int = 2)
             AND status_int = 1) c
   WHERE m1.sid_int=n1.sid_int
     and n1.outpatrecipeid_chr=a.outpatrecipeid_chr
     and m1.sid_int=?
     AND (a.operatortype_int = 1 OR a.operatortype_int = 2)
     AND a.status_int = 1
     AND a.operatorid_chr = b.empid_chr
     AND a.itemid_chr = c.itemid_chr
ORDER BY a.seq_int DESC";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strSid_int;
                objLisAddItemRefArr[1].Value = m_strSid_int;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            ArrayList list1 = new ArrayList();
            ArrayList objArr = new ArrayList();
            if (lngRes == 1)
            {
                ArrayList arr1 = new ArrayList();
                arr1.Add("配药人");
                ArrayList arr2 = new ArrayList();
                arr2.Add("时间");
                ArrayList arr3 = new ArrayList();
                arr3.Add("复核人");
                ArrayList arr4 = new ArrayList();
                arr4.Add("时间");
                if (dtbResult.Rows.Count > 0)
                {
                    int tolMunber1 = 0;
                    int tolMunber2 = 0;
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        if (dtbResult.Rows[i1]["OPERATORTYPE_INT"].ToString() == "1" && tolMunber1 < 7)
                        {
                            arr1.Add(dtbResult.Rows[i1]["LASTNAME_VCHR"].ToString());
                            arr2.Add(DateTime.Parse(dtbResult.Rows[i1]["EXECTIME_DAT"].ToString()).ToString("MM-dd HH:mm"));
                            tolMunber1++;
                        }
                        else if (tolMunber2 < 7)
                        {
                            arr3.Add(dtbResult.Rows[i1]["LASTNAME_VCHR"].ToString());
                            arr4.Add(DateTime.Parse(dtbResult.Rows[i1]["EXECTIME_DAT"].ToString()).ToString("MM-dd HH:mm"));
                            tolMunber2++;
                        }
                    }
                }
                list1.Add(arr1);
                list1.Add(arr2);
                list1.Add(arr3);
                list1.Add(arr4);
            }
            strSQL = @"SELECT   a.itemid_chr, d.itemname_vchr, a.rowno_chr, a.operatorid_chr,
         a.exectime_dat, a.operatortype_int, b.lastname_vchr, a.remark1_vchr
    FROM t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_nurseexecute a,
         t_bse_employee b,
         t_bse_chargeitem d,
         (SELECT   MAX (a.itemid_chr) itemid_chr
              FROM t_opr_nurseexecute a,
                   t_opr_recipesend m,
                   t_opr_recipesendentry n
             WHERE m.sid_int = n.sid_int
               AND a.outpatrecipeid_chr = n.outpatrecipeid_chr
               AND m.sid_int = ?
               AND (   a.operatortype_int = 10
                    OR a.operatortype_int = 3
                    OR a.operatortype_int = 4
                   )
               AND a.status_int = 1
          GROUP BY rowno_chr) c
   WHERE m1.sid_int = n1.sid_int
     AND n1.outpatrecipeid_chr = a.outpatrecipeid_chr
     AND m1.sid_int = ?
     AND (   a.operatortype_int = 10
          OR a.operatortype_int = 3
          OR a.operatortype_int = 4
         )
     AND a.status_int = 1
     AND a.rowno_chr > 0
     AND a.operatorid_chr = b.empid_chr
     AND a.itemid_chr = c.itemid_chr
     AND a.itemid_chr = d.itemid_chr(+)
ORDER BY a.seq_int DESC ";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strSid_int;
                objLisAddItemRefArr[1].Value = m_strSid_int;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"SELECT   a.itemid_chr, d.itemname_vchr, a.rowno_chr, a.operatorid_chr,
         a.exectime_dat, a.operatortype_int, b.lastname_vchr, a.remark1_vchr
    FROM t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_nurseexecute a,
         t_bse_employee b,
         t_bse_chargeitem d
   WHERE m1.sid_int = n1.sid_int
     AND n1.outpatrecipeid_chr = a.outpatrecipeid_chr
     AND m1.sid_int = ?
     AND (   a.operatortype_int = 10
          OR a.operatortype_int = 3
          OR a.operatortype_int = 4
         )
     AND a.status_int = 1
     AND a.rowno_chr <= 0
     AND a.operatorid_chr = b.empid_chr
     AND a.itemid_chr = d.itemid_chr(+)
ORDER BY a.seq_int DESC ";
            DataTable dtbResult2 = new DataTable();
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strSid_int;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult2, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            DataTable dtUsage = new DataTable();//保存需要打印输液巡视单的用法数据

            strSQL = @"select USAGEID_CHR from t_opr_setusage where ORDERID_VCHR='1'";
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtUsage);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            ArrayList arrGroud = new ArrayList();
            if (ArrdtRow.Rows.Count > 0)
            {
                for (int f2 = 0; f2 < ArrdtRow.Rows.Count; f2++)
                {
                    DataRow[] objRows = dtItemArr.Select("ROWNO_CHR =" + ArrdtRow.Rows[f2]["ROWNO_CHR"].ToString().Trim());
                    int kk = f2 + 1;
                    string strGroud = "第" + kk.ToString() + "组:";
                    int currInt = 0;//标志当前组中是否存在需要打印的明细-1.有

                    int currint1 = 0;
                    for (int k1 = 0; k1 < objRows.Length; k1++)
                    {
                        DataRow[] tempArr = dtUsage.Select("USAGEID_CHR=" + objRows[k1]["usageid_chr"].ToString());
                        if (tempArr.Length == 0)
                            continue;
                        if (currint1 == 0)
                        {
                            currInt = -1;
                            strGroud += objRows[k1]["ITEMNAME_VCHR"].ToString();
                            currint1++;
                        }
                        else
                        {
                            strGroud = strGroud + "、" + objRows[k1]["ITEMNAME_VCHR"].ToString();
                        }

                    }
                    if (currInt == -1)
                    {
                        ArrayList arr1 = new ArrayList();
                        arr1.Add("配药护士");
                        ArrayList arr2 = new ArrayList();
                        arr2.Add("时间");
                        ArrayList arr3 = new ArrayList();
                        arr3.Add("执行人");
                        ArrayList arr4 = new ArrayList();
                        arr4.Add("输液时间");
                        ArrayList arr5 = new ArrayList();
                        arr5.Add("滴速（分）");
                        ArrayList arr6 = new ArrayList();
                        arr6.Add("巡视时间");
                        ArrayList arr7 = new ArrayList();
                        arr7.Add("滴速（分）");
                        ArrayList arr8 = new ArrayList();
                        arr8.Add("签名");
                        int tolMunber1 = 0;
                        int tolMunber2 = 0;
                        int tolMunber3 = 0;
                        ArrayList objList = new ArrayList();
                        if (dtbResult.Rows.Count > 0)
                        {
                            for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                            {
                                if (ArrdtRow.Rows[f2]["ROWNO_CHR"].ToString() == dtbResult.Rows[i1]["ROWNO_CHR"].ToString())
                                {
                                    if (dtbResult.Rows[i1]["OPERATORTYPE_INT"].ToString() == "3" && tolMunber1 < 7)
                                    {
                                        arr3.Add(dtbResult.Rows[i1]["LASTNAME_VCHR"].ToString());
                                        arr4.Add(DateTime.Parse(dtbResult.Rows[i1]["EXECTIME_DAT"].ToString()).ToString("MM-dd HH:mm"));
                                        arr5.Add(dtbResult.Rows[i1]["REMARK1_VCHR"].ToString());
                                        tolMunber1++;
                                    }
                                    if (dtbResult.Rows[i1]["OPERATORTYPE_INT"].ToString() == "10" && tolMunber2 < 7)
                                    {
                                        arr1.Add(dtbResult.Rows[i1]["LASTNAME_VCHR"].ToString());
                                        arr2.Add(DateTime.Parse(dtbResult.Rows[i1]["EXECTIME_DAT"].ToString()).ToString("MM-dd HH:mm"));
                                        tolMunber2++;
                                    }
                                    if (dtbResult.Rows[i1]["OPERATORTYPE_INT"].ToString() == "4" && tolMunber3 < 7)
                                    {
                                        arr8.Add(dtbResult.Rows[i1]["LASTNAME_VCHR"].ToString());
                                        arr6.Add(DateTime.Parse(dtbResult.Rows[i1]["EXECTIME_DAT"].ToString()).ToString("MM-dd HH:mm"));
                                        arr7.Add(dtbResult.Rows[i1]["REMARK1_VCHR"].ToString());
                                        tolMunber3++;
                                    }
                                }
                            }
                        }
                        objList.Add(arr1);
                        objList.Add(arr2);
                        objList.Add(arr3);
                        objList.Add(arr4);
                        objList.Add(arr5);
                        objList.Add(arr6);
                        objList.Add(arr7);
                        objList.Add(arr8);
                        objArr.Add(objList);
                        arrGroud.Add(strGroud);
                    }
                }
            }

            if (dtItemArr.Rows.Count > 0)
            {
                for (int h = 0; h < dtItemArr.Rows.Count; h++)
                {
                    try
                    {
                        if (int.Parse(dtItemArr.Rows[h]["ROWNO_CHR"].ToString()) > 0)
                        {
                            dtItemArr.Rows[h].Delete();
                            h--;
                        }
                    }
                    catch
                    {
                    }
                }
                dtItemArr.AcceptChanges();
            }
            if (dtItemArr.Rows.Count > 0)
            {

                for (int f2 = 0; f2 < dtItemArr.Rows.Count; f2++)
                {
                    DataRow[] tempArr = dtUsage.Select("USAGEID_CHR=" + dtItemArr.Rows[f2]["usageid_chr"].ToString());
                    if (tempArr.Length == 0)
                        continue;
                    arrGroud.Add(dtItemArr.Rows[f2]["ITEMNAME_VCHR"].ToString());
                    ArrayList tempList = new ArrayList();
                    ArrayList arr1 = new ArrayList();
                    arr1.Add("配药护士");
                    ArrayList arr2 = new ArrayList();
                    arr2.Add("时间");
                    ArrayList arr3 = new ArrayList();
                    arr3.Add("执行人");
                    ArrayList arr4 = new ArrayList();
                    arr4.Add("输液时间");
                    ArrayList arr5 = new ArrayList();
                    arr5.Add("滴速（分）");
                    ArrayList arr6 = new ArrayList();
                    arr6.Add("巡视时间");
                    ArrayList arr7 = new ArrayList();
                    arr7.Add("滴速（分）");
                    ArrayList arr8 = new ArrayList();
                    arr8.Add("签名");
                    int tolMunber1 = 0;
                    int tolMunber2 = 0;
                    int tolMunber3 = 0;
                    ArrayList objList = new ArrayList();
                    for (int i1 = 0; i1 < dtbResult2.Rows.Count; i1++)
                    {
                        if (dtItemArr.Rows[f2]["ITEMNAME_VCHR"].ToString().Trim() == dtbResult2.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim())
                        {
                            if (dtbResult2.Rows[i1]["OPERATORTYPE_INT"].ToString() == "3" && tolMunber1 < 7)
                            {
                                arr3.Add(dtbResult2.Rows[i1]["LASTNAME_VCHR"].ToString());
                                arr4.Add(DateTime.Parse(dtbResult2.Rows[i1]["EXECTIME_DAT"].ToString()).ToString("MM-dd HH:mm"));
                                arr5.Add(dtbResult.Rows[i1]["REMARK1_VCHR"].ToString());
                                tolMunber1++;
                            }
                            if (dtbResult2.Rows[i1]["OPERATORTYPE_INT"].ToString() == "10" && tolMunber2 < 7)
                            {
                                arr1.Add(dtbResult2.Rows[i1]["LASTNAME_VCHR"].ToString());
                                arr2.Add(DateTime.Parse(dtbResult2.Rows[i1]["EXECTIME_DAT"].ToString()).ToString("MM-dd HH:mm"));
                                tolMunber2++;
                            }
                            if (dtbResult2.Rows[i1]["OPERATORTYPE_INT"].ToString() == "4" && tolMunber3 < 7)
                            {
                                arr8.Add(dtbResult2.Rows[i1]["LASTNAME_VCHR"].ToString());
                                arr6.Add(DateTime.Parse(dtbResult2.Rows[i1]["EXECTIME_DAT"].ToString()).ToString("MM-dd HH:mm"));
                                arr7.Add(dtbResult2.Rows[i1]["REMARK1_VCHR"].ToString());
                                tolMunber3++;
                            }
                        }

                    }
                    objList.Add(arr1);
                    objList.Add(arr2);
                    objList.Add(arr3);
                    objList.Add(arr4);

                    objList.Add(arr5);
                    objList.Add(arr6);
                    objList.Add(arr7);
                    objList.Add(arr8);
                    objArr.Add(objList);
                }
            }
            m_objList1 = list1;
            m_objList2 = objArr;
            m_objListGroupName = arrGroud;
            return lngRes;

        }

        /// <summary>
        /// 获取发票分类信息
        /// </summary>
        /// <param name="p_strInvoiceNo">发票号</param>
        /// <param name="p_dtResultTable">结果集</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChargeItemTypeByInvoice(string p_strInvoiceNo, out DataTable p_dtResultTable)
        {
            long lngRes = -1;
            p_dtResultTable = new DataTable();            
            string strSQL = @"select t.itemcatid_chr,
                                    t.tolfee_mny,
                                    t.invoiceno_vchr,
                                    t.seqid_chr,
                                    t.sbsum_mny
                               from t_opr_outpatientrecipeinvde t
                               where t.invoiceno_vchr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = p_strInvoiceNo;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResultTable, ParamArr);
                if (p_dtResultTable == null || p_dtResultTable.Rows.Count == 0)
                {
                    strSQL = @"select t.itemcatid_chr,
                                       t.tolfee_mny,
                                       t.invoiceno_vchr,
                                       t.seqid_chr,
                                       t.sbsum_mny
                                  from t_opr_outpatientrecipeinvde t
                                 inner join t_opr_outpatientrecipeinv b
                                    on t.invoiceno_vchr = b.invoiceno_vchr
                                 inner join t_opr_invoicerepeatprint c
                                    on b.seqid_chr = c.seqid_chr
                                 where c.repprninvono_vchr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_strInvoiceNo;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResultTable, ParamArr);
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

        /// <summary>
        /// 获取发票核算信息
        /// </summary>
        /// <param name="p_strInvoiceNo">发票类型</param>
        /// <param name="p_dtResultTable">结果集</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngComputationByScope(string p_strScope, out DataTable p_dtResultTable)
        {
            long lngRes = -1;
            p_dtResultTable = new DataTable();
            string strSQL = @"select t.scope_chr,
                                  t.catid_chr,
                                  t.catname_vchr,
                                  t.type_int,
                                  t.compexp_vchr,
                                  t.dispctl_vchr,
                                  t.prtclt_vchr,
                                  t.status_int
                             from t_bse_defchargecat t
                            where t.scope_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = p_strScope;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResultTable, ParamArr);
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
