using System;
using System.EnterpriseServices;
using System.Data;
using System.Text;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsItemBefell : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {


        public long GetItem(string itemName, out DataTable dtbResult)
        {

            long lngRes = 0;

            dtbResult = new DataTable();
                       
            string strSQL = @"
                        select a.itemid_chr,a.itemcode_vchr,a.itemname_vchr 
                          from t_bse_chargeitem a
                         where itemcode_vchr like ?
                            or itemname_vchr like ?
                            or itempycode_chr like ?
                            or itemwbcode_chr like ?";
            
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(4, out arrParams);
                arrParams[0].Value = itemName + '%';
                arrParams[1].Value = '%'+ itemName+'%';
                arrParams[2].Value = itemName+'%';
                arrParams[3].Value = itemName+'%';
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
               
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
        public long GetItemCollect(int p_DataType, int p_intRecipeType, string p_strBegin, string p_strEnd, string p_ITEMID, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();

            StringBuilder sbdSQL = new StringBuilder("");
            switch (p_intRecipeType)
            {
                case 1://西药
                    {
//                        sbdSQL.Append(@"select 
//                                           a.deptname_chr, 
//                                           a.status_int, 
//                                           b.tolqty_dec qty_dec,
//                                           b.tolprice_mny  
//    
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_opr_outpatientpwmrecipede b
//                                        where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                          and b.itemid_chr = ? ");
                        sbdSQL.Append(@"select        e.deptname_vchr, 
                                           a.status_int, 
                                           b.tolqty_dec qty_dec,
                                           b.tolprice_mny  
                                        from t_opr_charge a,
                                             t_opr_reciperelation c,
                                             t_opr_outpatientpwmrecipede b,
                                             t_bse_deptdesc e
                                        where a.chargeno_chr = c.chargeno_chr
                                          and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                          and a.deptid_chr = e.deptid_chr
                                          and b.itemid_chr = ?");
                        break;

                    }
                case 2://中药
                    {
//                        sbdSQL.Append(@"select 
//                                            a.deptname_chr, 
//                                            a.status_int, 
//                                            b.times_int * b.min_qty_dec qty_dec,
//                                            b.tolprice_mny   
//        
//                                        from t_opr_outpatientrecipeinv  a,
//                                             t_opr_outpatientcmrecipede b
//                                        where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                          and b.itemid_chr = ? ");
                        sbdSQL.Append(@"select 
                                            e.deptname_vchr, 
                                            a.status_int, 
                                            b.times_int * b.min_qty_dec qty_dec,
                                            b.tolprice_mny   
        
                                        from t_opr_charge a,
                                             t_opr_reciperelation c,
                                             t_opr_outpatientcmrecipede b,
                                             t_bse_deptdesc e
                                        where a.chargeno_chr = c.chargeno_chr
                                          and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                          and a.deptid_chr = e.deptid_chr
                                          and b.itemid_chr = ?");
                        break;
                    }
                case 3://检验明细
                    {
//                        sbdSQL.Append(@"select 
//                                            a.deptname_chr, 
//                                            a.status_int, 
//                                            b.qty_dec,
//                                            b.tolprice_mny
//        
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_opr_outpatientchkrecipede b
//                                        where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                         and b.itemid_chr = ? ");
                        sbdSQL.Append(@"select 
                                            e.deptname_vchr, 
                                            a.status_int, 
                                            b.qty_dec,
                                            b.tolprice_mny
                                        from t_opr_charge a,
                                             t_opr_reciperelation c,
                                             t_opr_outpatientchkrecipede b,
                                             t_bse_deptdesc e
                                        where a.chargeno_chr = c.chargeno_chr
                                        and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                        and a.deptid_chr = e.deptid_chr
                                         and b.itemid_chr = ?");
                        break;
                    }
                case 4://检查明细
                    {
//                        sbdSQL.Append(@"select 
//                                            a.deptname_chr, 
//                                            a.status_int, 
//                                            b.qty_dec,
//                                            b.tolprice_mny
//    
//                                       from t_opr_outpatientrecipeinv a,
//                                            t_opr_outpatienttestrecipede b
//                                       where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                            and b.itemid_chr = ? ");
                        sbdSQL.Append(@"select 
                                            e.deptname_vchr, 
                                            a.status_int, 
                                            b.qty_dec,
                                            b.tolprice_mny
    
                                       from t_opr_charge a,
                                            t_opr_reciperelation c,
                                            t_opr_outpatienttestrecipede b,
                                            t_bse_deptdesc e
                                       where a.chargeno_chr = c.chargeno_chr
                                        and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                        and a.deptid_chr = e.deptid_chr
                                        and b.itemid_chr = ?");
                        break;
                    }
                case 5://手术明细
                    {
//                        sbdSQL.Append(@"select 
//                                            a.deptname_chr, 
//                                            a.status_int, 
//                                            b.qty_dec,
//                                            b.tolprice_mny    
//    
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_opr_outpatientopsrecipede b
//                                        where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                            and b.itemid_chr = ?   ");
                        sbdSQL.Append(@"select 
                                            e.deptname_vchr, 
                                            a.status_int, 
                                            b.qty_dec,
                                            b.tolprice_mny
    
                                       from t_opr_charge a,
                                            t_opr_reciperelation c,
                                             t_opr_outpatientopsrecipede b,
                                            t_bse_deptdesc e
                                       where a.chargeno_chr = c.chargeno_chr
                                        and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                        and a.deptid_chr = e.deptid_chr
                                        and b.itemid_chr = ?");
                        break;
                    }
                case 6://其他明细
                    {
//                        sbdSQL.Append(@"select 
//                                            a.deptname_chr, 
//                                            a.status_int, 
//                                            b.qty_dec,
//                                            b.tolprice_mny    
//       
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_opr_outpatientothrecipede b
//                                        where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                            and b.itemid_chr = ?   ");
                        sbdSQL.Append(@"select 
                                            e.deptname_vchr, 
                                            a.status_int, 
                                            b.qty_dec,
                                            b.tolprice_mny   
                                        from t_opr_charge a,
                                             t_opr_reciperelation c,
                                             t_opr_outpatientothrecipede b,
                                             t_bse_deptdesc e
                                        where a.chargeno_chr = c.chargeno_chr
                                        and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                        and a.deptid_chr = e.deptid_chr
                                        and b.itemid_chr = ?");
                        break;
                    }
            }
            //结帐日期
            if (p_DataType == 1)
            {
                sbdSQL.Append(@" and a.operdate_dat >= ?
                                 and a.operdate_dat <= ?");
//                strSQL = @"select   a.deptname_chr, b.qty_dec, b.tolprice_mny
//
//                            from t_opr_outpatientrecipeinv a,
//                                 t_opr_oprecipeitemde b,
//                                 t_opr_outpatientrecipe c,
//                                 t_opr_reciperelation d,
//                                 t_bse_patientcard e
//
//                           where a.outpatrecipeid_chr = d.seqid
//                             and d.outpatrecipeid_chr = b.outpatrecipeid_chr
//                             and c.outpatrecipeid_chr = d.outpatrecipeid_chr
//                             and a.patientid_chr = e.patientid_chr
//                             and (c.pstauts_int = 2 or c.pstauts_int = 3) 
//                             and b.itemid_chr = ?
//                             and a.recorddate_dat >= ?
//                             and a.recorddate_dat <= ?";
                

            }
            //发票日期
            else if (p_DataType == 2)
            {
                sbdSQL.Append(@"and a.recdate_dat >= ?
                                and a.recdate_dat <= ?");

//                strSQL = @"select   a.deptname_chr, b.qty_dec, b.tolprice_mny
//
//                            from t_opr_outpatientrecipeinv a,
//                                 t_opr_oprecipeitemde b,
//                                 t_opr_outpatientrecipe c,
//                                 t_opr_reciperelation d,
//                                 t_bse_patientcard e
//
//                           where a.outpatrecipeid_chr = d.seqid
//                             and d.outpatrecipeid_chr = b.outpatrecipeid_chr
//                             and c.outpatrecipeid_chr = d.outpatrecipeid_chr
//                             and a.patientid_chr = e.patientid_chr
//                             and a.balance_dat >= ?
//                             and a.balance_dat <= ?
//                             and b.itemid_chr = ?
//                             and (c.pstauts_int = 2 or c.pstauts_int = 3) ";
                
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;

                objHRPSvc.CreateDatabaseParameter(3, out arrParams);

                arrParams[0].Value = p_ITEMID;
                arrParams[1].Value = DateTime.Parse(p_strBegin);
                arrParams[2].Value = DateTime.Parse(p_strEnd);


                lngRes = objHRPSvc.lngGetDataTableWithParameters(sbdSQL.ToString(), ref p_dtResult, arrParams);
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

        public long GetItemByDate(int p_DataType,int p_intRecipeType, string p_strBegin, string p_strEnd, string p_ITEMID, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            StringBuilder sbdSQL = new StringBuilder("");
            switch (p_intRecipeType)
            {
                case 1://西药
                    {
//                        sbdSQL.Append(@"select a.deptname_chr,
//                                               a.deptid_chr,
//                                               a.patientname_chr,
//                                               a.recorddate_dat as balance_dat,
//                                               a.status_int,
//                                               b.patientcardid_chr,              
//                                               c.unitid_chr,       
//                                               c.tolqty_dec,
//                                               c.unitprice_mny,
//                                               c.tolprice_mny
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_bse_patientcard         b,
//                                             t_opr_outpatientpwmrecipede c
//       
//                                        where a.patientid_chr = b.patientid_chr
//                                          and a.outpatrecipeid_chr = c.outpatrecipeid_chr
//                                          and c.itemid_chr = ? ");
                        sbdSQL.Append(@"select f.deptname_vchr,
                                               a.deptid_chr,
                                               d.lastname_vchr,
                                               a.invdate_dat as balance_dat,
                                               a.status_int,
                                               b.patientcardid_chr,              
                                               c.unitid_chr,       
                                               c.tolqty_dec,
                                               c.unitprice_mny,
                                               c.tolprice_mny
                                        from t_opr_outpatientrecipeinv a,
                                             t_bse_patientcard b,
                                             t_opr_outpatientpwmrecipede c,
                                             t_bse_patient d,
                                             t_bse_deptdesc f       
                                        where a.patientid_chr = b.patientid_chr
                                          and c.outpatrecipeid_chr = a.outpatrecipeid_chr
                                          and a.patientid_chr = d.patientid_chr
                                          and a.deptid_chr = f.deptid_chr
                                          and c.itemid_chr = ?");
                        break;

                    }
                case 2://中药
                    {
//                        sbdSQL.Append(@"select a.deptname_chr,
//                                               a.deptid_chr,
//                                               a.patientname_chr,
//                                               a.recorddate_dat as balance_dat,
//                                               a.status_int,
//                                               b.patientcardid_chr,       
//                                               c.unitid_chr unitid_chr,
//                                               c.times_int * c.min_qty_dec tolqty_dec,
//                                               c.unitprice_mny,
//                                               c.tolprice_mny
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_bse_patientcard         b,
//                                             t_opr_outpatientcmrecipede c
//                                        where a.patientid_chr = b.patientid_chr
//                                          and a.outpatrecipeid_chr = c.outpatrecipeid_chr   
//                                          and c.itemid_chr = ? ");
                        sbdSQL.Append(@"select f.deptname_vchr,
                                               a.deptid_chr,
                                               d.lastname_vchr,
                                               a.invdate_dat as balance_dat,
                                               a.status_int,
                                               b.patientcardid_chr,       
                                               c.unitid_chr unitid_chr,
                                               c.times_int * c.min_qty_dec tolqty_dec,
                                               c.unitprice_mny,
                                               c.tolprice_mny
                                        from t_opr_outpatientrecipeinv a,
                                             t_bse_patientcard  b,
                                             t_opr_outpatientcmrecipede c,
                                             t_bse_patient d,
                                             t_bse_deptdesc f
                                        where a.patientid_chr = b.patientid_chr
                                          and c.outpatrecipeid_chr = a.outpatrecipeid_chr
                                          and a.patientid_chr = d.patientid_chr
                                          and a.deptid_chr = f.deptid_chr  
                                          and c.itemid_chr = ?");
                        break;
                    }
                case 3://检验明细
                    {
//                        sbdSQL.Append(@"select a.deptname_chr,
//                                               a.deptid_chr,
//                                               a.patientname_chr,
//                                               a.recorddate_dat as balance_dat,
//                                               a.status_int,
//                                               b.patientcardid_chr,       
//                                               c.itemunit_vchr unitid_chr,
//                                               c.qty_dec tolqty_dec,   
//                                               c.price_mny unitprice_mny,
//                                               c.tolprice_mny
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_bse_patientcard         b,
//                                             t_opr_outpatientchkrecipede c    
//
//                                        where a.patientid_chr = b.patientid_chr
//                                          and a.outpatrecipeid_chr = c.outpatrecipeid_chr
//                                          and c.itemid_chr = ? ");
                        sbdSQL.Append(@"select f.deptname_vchr,
                                               a.deptid_chr,
                                               d.lastname_vchr,
                                               a.invdate_dat as balance_dat,
                                               a.status_int,
                                               b.patientcardid_chr,       
                                               c.itemunit_vchr unitid_chr,
                                               c.qty_dec tolqty_dec,   
                                               c.price_mny unitprice_mny,
                                               c.tolprice_mny
                                        from t_opr_outpatientrecipeinv a,
                                             t_bse_patientcard b,
                                             t_opr_outpatientchkrecipede c,
                                             t_bse_patient d,
                                             t_bse_deptdesc f   
                                        where a.patientid_chr = b.patientid_chr
                                          and c.outpatrecipeid_chr = a.outpatrecipeid_chr
                                          and a.patientid_chr = d.patientid_chr
                                          and a.deptid_chr = f.deptid_chr
                                          and c.itemid_chr = ?");
                        break;
                    }
                case 4://检查明细
                    {
//                        sbdSQL.Append(@"select a.deptname_chr,
//                                               a.deptid_chr,
//                                               a.patientname_chr,
//                                               a.recorddate_dat as balance_dat,
//                                               a.status_int,
//                                               b.patientcardid_chr,       
//                                               c.itemunit_vchr unitid_chr,
//                                               c.qty_dec tolqty_dec,
//                                               c.price_mny unitprice_mny,
//                                               c.tolprice_mny
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_bse_patientcard         b,
//                                             t_opr_outpatienttestrecipede c
//
//                                        where a.patientid_chr = b.patientid_chr
//                                          and a.outpatrecipeid_chr = c.outpatrecipeid_chr
//                                          and c.itemid_chr = ? ");
                        sbdSQL.Append(@"select f.deptname_vchr,
                                               a.deptid_chr,
                                               d.lastname_vchr,
                                               a.invdate_dat as balance_dat,
                                               a.status_int,
                                               b.patientcardid_chr,       
                                               c.itemunit_vchr unitid_chr,
                                               c.qty_dec tolqty_dec,
                                               c.price_mny unitprice_mny,
                                               c.tolprice_mny
                                        from t_opr_outpatientrecipeinv a,
                                             t_bse_patientcard b,
                                             t_opr_outpatienttestrecipede c,
                                             t_bse_patient d,
                                             t_bse_deptdesc f 
                                        where a.patientid_chr = b.patientid_chr
                                          and c.outpatrecipeid_chr = a.outpatrecipeid_chr
                                          and a.patientid_chr = d.patientid_chr
                                          and a.deptid_chr = f.deptid_chr
                                          and c.itemid_chr = ?");
                        break;
                    }
                case 5://手术明细
                    {
//                        sbdSQL.Append(@"select a.deptname_chr,
//                                               a.deptid_chr,
//                                               a.patientname_chr,
//                                               a.recorddate_dat as balance_dat,
//                                               a.status_int,
//                                               b.patientcardid_chr,       
//                                               c.itemunit_vchr unitid_chr,
//                                               c.qty_dec tolqty_dec,
//                                               c.price_mny unitprice_mny,
//                                               c.tolprice_mny
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_bse_patientcard         b,
//                                             t_opr_outpatientopsrecipede c
//                                        where a.patientid_chr = b.patientid_chr
//                                          and a.outpatrecipeid_chr = c.outpatrecipeid_chr
//                                          and c.itemid_chr = ? "); 
                        sbdSQL.Append(@"select f.deptname_vchr,
                                               a.deptid_chr,
                                               d.lastname_vchr,
                                               a.invdate_dat as balance_dat,
                                               a.status_int,
                                               b.patientcardid_chr,       
                                               c.itemunit_vchr unitid_chr,
                                               c.qty_dec tolqty_dec,
                                               c.price_mny unitprice_mny,
                                               c.tolprice_mny
                                        from t_opr_outpatientrecipeinv a,
                                             t_bse_patientcard b,
                                             t_opr_outpatientopsrecipede c,
                                             t_bse_patient d,
                                             t_bse_deptdesc f                                                
                                        where a.patientid_chr = b.patientid_chr
                                          and c.outpatrecipeid_chr = a.outpatrecipeid_chr
                                          and a.patientid_chr = d.patientid_chr
                                          and a.deptid_chr = f.deptid_chr
                                          and c.itemid_chr = ?");
                        break;
                    }
                case 6://其他明细
                    {
//                        sbdSQL.Append(@"select a.deptname_chr,
//                                               a.deptid_chr,
//                                               a.patientname_chr,
//                                               a.recorddate_dat as balance_dat,
//                                               a.status_int,
//                                               b.patientcardid_chr,       
//                                               c.unitid_chr unitid_chr,
//                                               c.qty_dec tolqty_dec,
//                                               c.unitprice_mny ,
//                                               c.tolprice_mny
//                                        from t_opr_outpatientrecipeinv a,
//                                             t_bse_patientcard         b,
//                                             t_opr_outpatientothrecipede c
//
//                                        where a.patientid_chr = b.patientid_chr
//                                          and a.outpatrecipeid_chr = c.outpatrecipeid_chr
//                                          and c.itemid_chr = ? ");
                        sbdSQL.Append(@"select f.deptname_vchr,
                                               a.deptid_chr,
                                               a.patientid_chr,
                                               d.lastname_vchr,
                                               a.invdate_dat as balance_dat,
                                               a.status_int,
                                               b.patientcardid_chr,       
                                               c.unitid_chr unitid_chr,
                                               c.qty_dec tolqty_dec,
                                               c.unitprice_mny ,
                                               c.tolprice_mny
                                        from t_opr_outpatientrecipeinv a,
                                             t_bse_patientcard         b,
                                             t_opr_outpatientothrecipede c,
                                             t_bse_patient d,
                                             t_bse_deptdesc f
                                        where a.patientid_chr = b.patientid_chr
                                          and c.outpatrecipeid_chr = a.outpatrecipeid_chr
                                          and a.patientid_chr = d.patientid_chr
                                          and a.deptid_chr = f.deptid_chr
                                          and c.itemid_chr = ?");
                        break;
                    }
            }
            //结帐日期
            if (p_DataType == 1) 
            {
                sbdSQL.Append(@"  and a.invdate_dat >= ?
                                  and a.invdate_dat <= ?");
//                strSQL = @"select   a.deptname_chr, e.patientcardid_chr, a.patientname_chr,
//                                 a.balance_dat, b.unitid_chr, 
//                                 b.qty_dec, b.price_mny, b.tolprice_mny  
//                                
//                            from t_opr_outpatientrecipeinv a,
//                                 t_opr_oprecipeitemde b,
//                                 t_opr_outpatientrecipe c,
//                                 t_opr_reciperelation d,
//                                 t_bse_patientcard e   
//                              
//                           where a.outpatrecipeid_chr = d.seqid
//                             and d.outpatrecipeid_chr = b.outpatrecipeid_chr
//                             and c.outpatrecipeid_chr = d.outpatrecipeid_chr
//                             and a.patientid_chr = e.patientid_chr
//                             and a.recorddate_dat >= ?
//                             and a.recorddate_dat <= ?
//                             and b.itemid_chr = ?
//                             and (c.pstauts_int = 2 or c.pstauts_int = 3) ";


                

            }
            //发票日期
            else if (p_DataType == 2)
            {
                sbdSQL.Append(@"  and a.balance_dat >= ?
                                  and a.balance_dat <= ?");

//                strSQL = @"select   a.deptname_chr, e.patientcardid_chr, a.patientname_chr,
//                                 a.balance_dat, b.unitid_chr, 
//                                 b.qty_dec, b.price_mny, b.tolprice_mny  
//                                
//                            from t_opr_outpatientrecipeinv a,
//                                 t_opr_oprecipeitemde b,
//                                 t_opr_outpatientrecipe c,
//                                 t_opr_reciperelation d,
//                                 t_bse_patientcard e 
//                                
//                           where a.outpatrecipeid_chr = d.seqid
//                             and d.outpatrecipeid_chr = b.outpatrecipeid_chr
//                             and c.outpatrecipeid_chr = d.outpatrecipeid_chr
//                             and a.patientid_chr = e.patientid_chr
//                             and a.balance_dat >= ?
//                             and a.balance_dat <= ?
//                             and b.itemid_chr = ?
//                             and (c.pstauts_int = 2 or c.pstauts_int = 3) ";

//               @"SELECT a.deptname_chr, e.patientcardid_chr, a.patientname_chr, a.balance_dat,
//       b.unitid_chr, b.qty_dec, b.price_mny, b.tolprice_mny
//  FROM (SELECT   a.outpatrecipeid_chr, a.patientid_chr, a.deptname_chr,
//                 a.patientname_chr, a.balance_dat,
//                 SUM (a.totalsum_mny) AS totalsum
//            FROM t_opr_outpatientrecipeinv a
//           WHERE a.balance_dat BETWEEN ? AND ?
//        GROUP BY a.outpatrecipeid_chr,
//                 a.patientid_chr,
//                 a.deptname_chr,
//                 a.patientname_chr,
//                 a.balance_dat) a,
//       t_opr_oprecipeitemde b,
//       t_opr_reciperelation d,
//       t_bse_patientcard e
// WHERE a.outpatrecipeid_chr = d.seqid
//   AND d.outpatrecipeid_chr = b.outpatrecipeid_chr
//   AND a.patientid_chr = e.patientid_chr
//   AND b.itemid_chr = ?
//   AND a.totalsum > 0"
                
            }
           try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;

                objHRPSvc.CreateDatabaseParameter(3, out arrParams);

                arrParams[0].Value = p_ITEMID;
                arrParams[1].DbType = DbType.Date;
                arrParams[1].Value = DateTime.Parse(p_strBegin);
                arrParams[2].DbType = DbType.Date;
                arrParams[2].Value = DateTime.Parse(p_strEnd);


                lngRes = objHRPSvc.lngGetDataTableWithParameters(sbdSQL.ToString(), ref p_dtResult, arrParams);
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
