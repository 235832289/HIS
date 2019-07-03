using System;
using com.digitalwave.iCare.middletier.HRPService;
using System.Data;
using Oracle.DataAccess.Client;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections;
using com.digitalwave.iCare.middletier.HIS;
using System.Collections.Generic;

namespace com.digitalwave.iCare.middletier.BIHOrderServer
{
    #region class clsConverter
    /// <summary>
    /// 类型转换(处理了异常)
    /// </summary>
    public class clsConverter
    {
        public static string ToString(object objValue)
        {
            try
            {
                if (objValue == null)
                    return "";
                else
                    return objValue.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static int ToInt(object objValue)
        {
            try
            {
                return Convert.ToInt32(objValue);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static long ToLong(object objValue)
        {
            try
            {
                return Convert.ToInt64(objValue);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static decimal ToDecimal(object objValue)
        {
            try
            {
                return Convert.ToDecimal(objValue);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static DateTime ToDateTime(object objValue)
        {
            try
            {
                return Convert.ToDateTime(objValue);
            }
            catch (Exception)
            {
                return System.DateTime.MinValue;
            }
        }
    }
    #endregion

    #region class clsBIHOrderService
    /// <summary>
    /// 医嘱相关
    /// 修改人：徐斌辉	2004-12-16
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBIHOrderService : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 查询病人信息
        [AutoComplete]
        public long m_lngGetPatientByAreaBed(string strAreaID, string strBedID, out clsBIHPatientInfo objPatient)
        {
            objPatient = null;
            string strSql = @"
            select * from (
                select  
                a.registerid_chr,a.patientid_chr,a.inpatientid_chr,a.inpatient_dat,
                a.deptid_chr,a.areaid_chr,a.bedid_chr,a.diagnose_vchr,a.inpatientcount_int,a.icd10diagtext_vchr,
                b.name_vchr,b.sex_chr,b.birth_dat,b.homephone_vchr,
                a.paytypeid_chr,
                c.code_chr bedname,d.deptname_vchr areaname,a.limitrate_mny
                ,e.flgname_vchr as state
                ,mzdiagnose_vchr
                ,f.paytypename_vchr paytypename_vchr
                ,sysdate today
                ,g.remarkname_vchr
                ,a.des_vchr
                ,a.casedoctor_chr doctorid_chr
                ,h.lastname_vchr  doctor_vchr
                ,h.empno_chr  doctorno_vchr
                ,patientcardid_chr
                ,a.nursing_class
                ,k.deptname_vchr deptname
                from t_opr_bih_register a,
                t_opr_bih_registerdetail b ,
                t_bse_bed c,
                t_bse_deptdesc d,
                (select flg_int,flgname_vchr from  t_sys_flg_table where tablename_vchr = 't_opr_bih_register' and columnname_vchr = 'pstatus_int') e,
                ( select tf.paytypeid_chr, tf.paytypename_vchr, tf.memo_vchr, tf.paylimit_mny, tf.payflag_dec, tf.paypercent_dec, tf.paytypeno_vchr, tf.isusing_num, tf.copayid_chr, tf.chargepercent_dec, tf.internalflag_int, tf.coalitionrecipeflag_int, tf.bihlimitrate_dec 
                         from t_bse_patientpaytype tf where tf.isusing_num=1 and tf.payflag_dec!=1)  f,
                t_opr_bih_patspecremark g,
                t_bse_employee h,
                t_bse_patientcard j ,
                t_bse_deptdesc k
                where a.registerid_chr=b.registerid_chr(+)
                and a.status_int=1
                
                and c.bedid_chr=?
                and a.registerid_chr=c.bihregisterid_chr(+)
                and a.areaid_chr=d.deptid_chr(+)
                and a.pstatus_int = e.flg_int(+)
                and a.paytypeid_chr=f.paytypeid_chr(+)
                and a.registerid_chr=g.registerid_chr(+)
                and a.casedoctor_chr=h.empid_chr(+)
                and a.patientid_chr=j.patientid_chr(+)
                and a.deptid_chr=k.deptid_chr(+)
                order by a.inpatientcount_int desc
                ) where rownum =1
               ";
            /*<----------------------------------------------*/


            DataTable objDT = new DataTable();
            clsHRPTableService HRPService = new clsHRPTableService();
            long ret = 0;
            try
            {
                ret = 0;
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = strBedID;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
                {
                    m_mthGetPatientInfoFromDateTable(objDT.Rows[0], out objPatient);
                    decimal m_decPreMoney, m_decPreUseMoney, m_decClearMoney, m_decVerticalMoney, m_decPrePayMoney;
                    ret = m_lngGetPatientChargeMessage(objPatient.m_strRegisterID, out  m_decPreMoney, out  m_decPreUseMoney, out  m_decClearMoney, out  m_decVerticalMoney, out  m_decPrePayMoney);
                    if (ret > 0)
                    {
                        objPatient.m_decPreMoney = m_decPreMoney;
                        objPatient.m_decPreUseMoney = m_decPreUseMoney;
                        objPatient.m_decClearMoney = m_decClearMoney;
                        objPatient.m_decVerticalMoney = m_decVerticalMoney;
                        objPatient.m_decPrePayMoney = m_decPrePayMoney;
                    }
                    // 加上相应的预交金,已用金等状态.
                    //System.Data.IDataParameter[] arrParams2 = null;
                    //HRPService.CreateDatabaseParameter(1, out arrParams2);
                    //strSql = @" select sum(round(a.money_dec,2)) NotUsePreMoney from t_opr_bih_prepay a where a.registerid_chr=? and a.isclear_int=0";
                    //arrParams2[0].Value = objPatient.m_strRegisterID;
                    //ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams2);
                    //if (objDT.Rows.Count > 0)
                    //{
                    //    if (!objDT.Rows[0]["NotUsePreMoney"].ToString().Trim().Equals(""))
                    //    {
                    //        NotUsePreMoney = decimal.Parse(objDT.Rows[0]["NotUsePreMoney"].ToString().Trim());
                    //    }
                    //}
                    //System.Data.IDataParameter[] arrParams3 = null;
                    //HRPService.CreateDatabaseParameter(1, out arrParams3);
                    //strSql = @"select a.unitprice_dec,a.amount_dec,a.pstatus_int from t_opr_bih_patientcharge a where a.STATUS_INT=1 and a.chargeactive_dat is not null and a.registerid_chr=?";
                    //arrParams3[0].Value = objPatient.m_strRegisterID;
                    //ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT,arrParams3);
                    //if (objDT.Rows.Count > 0)
                    //{
                    //    decimal unitprice_dec=0;
                    //    decimal amount_dec=0;
                    //    int pstatus_int=0;
                    //    for (int i = 0; i < objDT.Rows.Count; i++)
                    //    {
                    //       DataRow objRow= objDT.Rows[i];
                    //       pstatus_int=clsConverter.ToInt(objRow["pstatus_int"].ToString().Trim());
                    //       unitprice_dec=clsConverter.ToDecimal(objRow["unitprice_dec"].ToString().Trim());
                    //       amount_dec=clsConverter.ToDecimal(objRow["amount_dec"].ToString().Trim());
                    //       switch(pstatus_int)
                    //       {
                    //           case 0:
                    //               break;
                    //           case 1:
                    //               WaitMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                    //               PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                    //               break;
                    //           case 2:
                    //               WaitClearMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                    //               PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                    //               break;
                    //           case 3:
                    //               ClearMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                    //               PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                    //               break;
                    //           case 4:
                    //               VerticalMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                    //               PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                    //               break;
                    //           default:
                    //               PreUseMoney += decimal.Round(unitprice_dec * amount_dec,2);
                    //               break;
                    //       }

                    //    }

                    //}
                    //objPatient.m_decPreMoney = NotUsePreMoney;
                    //objPatient.m_decPreUseMoney = PreUseMoney;
                    //objPatient.m_decClearMoney = ClearMoney;
                    //objPatient.m_decVerticalMoney = VerticalMoney;
                    //objPatient.m_decPrePayMoney = NotUsePreMoney - WaitMoney - WaitClearMoney;

                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        [AutoComplete]
        public long m_lngGetPatientByDoctorID(string m_strDoctorID, out clsBIHPatientInfo[] m_arrObjPatient)
        {
            m_arrObjPatient = null;
            string strSql = @"
            
                select  
                a.RegisterID_Chr,a.PatientID_Chr,a.InPatientID_Chr,a.InPatient_Dat,
                a.DeptID_Chr,a.AreaID_Chr,a.BedID_Chr,a.Diagnose_Vchr,a.InPatientCount_Int,a.ICD10DIAGTEXT_VCHR,
                b.Name_VChr,b.Sex_Chr,b.Birth_Dat,b.HOMEPHONE_VCHR,
                a.PayTypeID_Chr,
                c.Code_Chr BedName,d.DeptName_VChr AreaName,a.limitrate_mny
                ,e.flgname_vchr AS state
                ,mzdiagnose_vchr
                ,f.PAYTYPENAME_VCHR PayTypeName_VChr
                ,sysdate today
                ,g.REMARKNAME_VCHR
                ,a.DES_VCHR
                ,a.CASEDOCTOR_CHR DOCTORID_CHR
                ,h.LastName_Vchr  DOCTOR_VCHR
                ,h.EMPNO_CHR  DOCTORNO_VCHR
                ,PATIENTCARDID_CHR
                ,a.NURSING_CLASS
                ,a.STATE_INT
                ,k.DeptName_VChr DeptName
                from T_Opr_BIH_Register a,
                t_opr_bih_registerdetail b ,
                T_BSE_Bed c,
                T_BSE_DeptDesc d,
                (select flg_int,flgname_vchr from  t_sys_flg_table where tablename_vchr = 't_opr_bih_register' and columnname_vchr = 'PSTATUS_INT') e,
                ( select tf.* from T_BSE_PatientPayType tf where tf.isusing_num=1 and tf.payflag_dec!=1)  f,
                T_OPR_BIH_PATSPECREMARK g,
                t_bse_employee h,
                t_bse_patientcard j,
                T_BSE_DeptDesc k
                where a.REGISTERID_CHR=b.REGISTERID_CHR(+)
                and a.Status_Int=1
                and a.REGISTERID_CHR=c.BIHREGISTERID_CHR(+)
                and a.AreaID_Chr=d.DeptID_Chr(+)
                AND a.pstatus_int = e.flg_int(+)
                and a.PayTypeID_Chr=f.PayTypeID_Chr(+)
                and a.REGISTERID_CHR=g.REGISTERID_CHR(+)
                and a.CASEDOCTOR_CHR=h.EMPID_CHR(+)
                and a.PATIENTID_CHR=j.PATIENTID_CHR(+)
                and a.DeptID_Chr=k.DeptID_Chr(+)
                and A.CASEDOCTOR_CHR=?
                and A.PSTATUS_INT=1
                order by a.INPATIENTID_CHR 
               
               ";
            /*<----------------------------------------------*/


            DataTable objDT = new DataTable();
            clsHRPTableService HRPService = new clsHRPTableService();
            long ret = 0;
            try
            {
                ret = 0;
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strDoctorID;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
                {
                    m_arrObjPatient = new clsBIHPatientInfo[objDT.Rows.Count];
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        m_mthGetPatientInfoFromDateTable(objDT.Rows[i], out m_arrObjPatient[i]);

                    }

                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        [AutoComplete]
        public long m_lngGetPatientEatCareByDoctorID(string m_strDoctorID, out DataTable objDT)
        {

            string strSql = @"
            select a.registerid_chr,c.name_chr from
            T_Opr_BIH_Register a,
            t_opr_bih_patientnurse b,
            t_bse_bih_orderdic c
            where
            a.registerid_chr=b.registerid_chr
            and
            b.orderdicid_chr=c.orderdicid_chr
            and
            b.active_int=1 and b.type_int=2
            and a.Status_Int=1
            and a.PSTATUS_INT<>3
            and a.casedoctor_chr=?
            order by b.active_dat
               ";
            /*<----------------------------------------------*/


            objDT = new DataTable();
            clsHRPTableService HRPService = new clsHRPTableService();
            long ret = 0;
            try
            {
                ret = 0;
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strDoctorID;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }


        [AutoComplete]
        public long m_lngGetPatientByPATIENTID(string PATIENTID_CHR, out clsBIHPatientInfo objPatient)
        {
            objPatient = null;

            string strSql = @"
            select * from (
                select  
                a.registerid_chr,a.patientid_chr,a.inpatientid_chr,a.inpatient_dat,
                a.deptid_chr,a.areaid_chr,a.bedid_chr,a.diagnose_vchr,a.inpatientcount_int,a.icd10diagtext_vchr,
                b.name_vchr,b.sex_chr,b.birth_dat,b.homephone_vchr,
                a.paytypeid_chr,
                c.code_chr bedname,d.deptname_vchr areaname,a.limitrate_mny
                ,e.flgname_vchr as state
                ,mzdiagnose_vchr
                ,f.paytypename_vchr paytypename_vchr
                ,sysdate today
                ,g.remarkname_vchr
                ,a.des_vchr
                ,a.casedoctor_chr doctorid_chr
                ,h.lastname_vchr  doctor_vchr
                ,h.empno_chr  doctorno_vchr
                ,patientcardid_chr
                from t_opr_bih_register a,
                t_opr_bih_registerdetail b ,
                t_bse_bed c,
                t_bse_deptdesc d,
                (select flg_int,flgname_vchr from  t_sys_flg_table where tablename_vchr = 't_opr_bih_register' and columnname_vchr = 'pstatus_int') e,
                ( select tf.paytypeid_chr, tf.paytypename_vchr, tf.memo_vchr, tf.paylimit_mny, tf.payflag_dec, tf.paypercent_dec, tf.paytypeno_vchr, tf.isusing_num, tf.copayid_chr, tf.chargepercent_dec, tf.internalflag_int, tf.coalitionrecipeflag_int, tf.bihlimitrate_dec 
                          from t_bse_patientpaytype tf where tf.isusing_num=1 and tf.payflag_dec!=1)  f,
                t_opr_bih_patspecremark g,
                t_bse_employee h,
                t_bse_patientcard j 
                where a.registerid_chr=b.registerid_chr(+)
                and a.registerid_chr=c.bihregisterid_chr(+)
                and a.areaid_chr=d.deptid_chr(+)
                and a.pstatus_int = e.flg_int(+)
                and a.paytypeid_chr=f.paytypeid_chr(+)
                and a.registerid_chr=g.registerid_chr(+)
                and a.casedoctor_chr=h.empid_chr(+)
                and a.patientid_chr=j.patientid_chr(+)
                and a.status_int=1
                and a.patientid_chr='[patientid_chr]'
                order by a.inpatientcount_int desc
                ) where rownum =1
               ";
            /*<----------------------------------------------*/
            strSql = strSql.Replace("[PATIENTID_CHR]", PATIENTID_CHR);

            DataTable objDT = new DataTable();
            clsHRPTableService HRPService = new clsHRPTableService();
            long ret = 0;
            try
            {
                ret = 0;
                ret = HRPService.DoGetDataTable(strSql, ref objDT);
                if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
                {
                    m_mthGetPatientInfoFromDateTable(objDT.Rows[0], out objPatient);
                    decimal m_decPreMoney, m_decPreUseMoney, m_decClearMoney, m_decVerticalMoney, m_decPrePayMoney;
                    ret = m_lngGetPatientChargeMessage(objPatient.m_strRegisterID, out  m_decPreMoney, out  m_decPreUseMoney, out  m_decClearMoney, out  m_decVerticalMoney, out  m_decPrePayMoney);
                    if (ret > 0)
                    {
                        objPatient.m_decPreMoney = m_decPreMoney;
                        objPatient.m_decPreUseMoney = m_decPreUseMoney;
                        objPatient.m_decClearMoney = m_decClearMoney;
                        objPatient.m_decVerticalMoney = m_decVerticalMoney;
                        objPatient.m_decPrePayMoney = m_decPrePayMoney;
                    }
                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }


        [AutoComplete]
        public long m_lngGetPatientByInHospitalNo(string strInHospitalNo, out clsBIHPatientInfo objPatient)
        {
            objPatient = null;
            /*<---------------------------------------------------------*/
            string strSql = @"
            select a.registerid_chr from t_opr_bih_register a 
            where 
            a.inpatientid_chr=?
            order by a.inpatientcount_int desc
            ";

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                clsHRPTableService HRPService = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = strInHospitalNo;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
            {
                //m_mthGetPatientInfoFromDateTable(objDT.Rows[0], out objPatient);
                string registerid_chr = objDT.Rows[0]["registerid_chr"].ToString().Trim();
                //m_lngGetPatientByAreaBed("", strBedID, out  objPatient);
                m_lngGetPatientByInRegisterID(registerid_chr, out objPatient);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [AutoComplete]
        public long m_lngGetPatientByInHospitalNo(string strInHospitalNo, out clsBIHPatientInfo objPatient, out int PSTATUS_INT)
        {
            objPatient = null;
            PSTATUS_INT = 0;
            /*<---------------------------------------------------------*/
            string strSql = @"
            select a.registerid_chr,a.PSTATUS_INT from t_opr_bih_register a 
            where 
            a.STATUS_INT=1 and a.inpatientid_chr=? 
            order by a.inpatientcount_int desc
            ";

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                clsHRPTableService HRPService = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = strInHospitalNo;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
            {
                //m_mthGetPatientInfoFromDateTable(objDT.Rows[0], out objPatient);
                string registerid_chr = objDT.Rows[0]["registerid_chr"].ToString().Trim();
                PSTATUS_INT = clsConverter.ToInt(objDT.Rows[0]["PSTATUS_INT"].ToString().Trim());
                if (PSTATUS_INT == 2 || PSTATUS_INT == 3)
                {
                    return 1;
                }
                //m_lngGetPatientByAreaBed("", strBedID, out  objPatient);
                m_lngGetPatientByInRegisterID(registerid_chr, out objPatient);
                return 1;
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 查询病人信息根据流水登记号
        /// </summary>
        /// <param name="strRegisterID"></param>
        /// <param name="objPatient"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientByInRegisterID(string strRegisterID, out clsBIHPatientInfo objPatient)
        {
            //            objPatient = null;
            //            string strSql = @"
            //			select * from (
            //				select TA.RegisterID_Chr,TA.PatientID_Chr,TA.InPatientID_Chr,TA.InPatient_Dat,
            //				TA.DeptID_Chr,TA.AreaID_Chr,TA.BedID_Chr,TA.Diagnose_Vchr,TA.InPatientCount_Int,
            //				TB.Name_VChr,TB.Sex_Chr,TB.Birth_Dat,TB.PayTypeID_Chr,TB.PayTypeName_VChr,
            //				TC.Code_Chr BedName,TD.DeptName_VChr AreaName,TA.limitrate_mny
            //				from T_Opr_BIH_Register TA,
            //				(   select B.PatientID_Chr,B.Name_VChr,B.Sex_Chr,B.Birth_Dat,B.PayTypeID_Chr,
            //							C.PayTypeName_VChr
            //					from T_BSE_Patient B,( select * from T_BSE_PatientPayType where IsUsing_Num=1 ) C
            //					where B.status_int=1
            //					and B.PayTypeID_Chr=C.PayTypeID_Chr(+)
            //				
            //				) TB,
            //				T_BSE_Bed TC,
            //				T_BSE_DeptDesc TD
            //				where TA.PatientID_Chr=TB.PatientID_Chr(+)
            //				and TA.Status_Int=1 and TA.PStatus_Int=1
            //				and Trim(TA.RegisterID_Chr) ='[RegisterIDValue]'
            //				and TA.AreaID_Chr=TC.AreaID_Chr(+) and TA.BedID_Chr=TC.BedID_Chr(+)
            //				and TA.AreaID_Chr=TD.DeptID_Chr(+)
            //				order by TA.InPatientCount_Int desc
            //			) where rownum =1
            //
            //			";
            //            strSql = strSql.Replace("[RegisterIDValue]", strRegisterID.Trim());

            //            DataTable objDT = new DataTable();
            //            long ret = 0;
            //            try
            //            {
            //                ret = 0;
            //                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            //            }
            //            catch (Exception objEx)
            //            {
            //                string strTmp = objEx.Message;
            //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
            //                bool blnRes = objLogger.LogError(objEx);
            //            }
            //            if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
            //            {
            //                m_mthGetPatientInfoFromDateTable(objDT.Rows[0], out objPatient);
            //                return 1;
            //            }
            //            else
            //            {
            //                return 0;
            //            }
            objPatient = null;
            string strSql = @"select a.RegisterID_Chr,
                                   a.PatientID_Chr,
                                   a.InPatientID_Chr,
                                   a.InPatient_Dat,
                                   a.DeptID_Chr,
                                   a.AreaID_Chr,
                                   a.BedID_Chr,
                                   a.Diagnose_Vchr,
                                   a.InPatientCount_Int,
                                   a.ICD10DIAGTEXT_VCHR,
                                   b.Name_VChr,
                                   b.Sex_Chr,
                                   b.Birth_Dat,
                                   b.HOMEPHONE_VCHR,
                                   a.PayTypeID_Chr,
                                   c.Code_Chr           BedName,
                                   d.DeptName_VChr      AreaName,
                                   a.limitrate_mny,
                                   e.flgname_vchr       AS state,
                                   mzdiagnose_vchr,
                                   f.PAYTYPENAME_VCHR   PayTypeName_VChr,
                                   sysdate              today,
                                   g.REMARKNAME_VCHR,
                                   a.DES_VCHR,
                                   a.CASEDOCTOR_CHR     DOCTORID_CHR,
                                   h.LastName_Vchr      DOCTOR_VCHR,
                                   h.EMPNO_CHR          DOCTORNO_VCHR,
                                   PATIENTCARDID_CHR,
                                   a.NURSING_CLASS,
                                   a.INSUREDSUM_MNY,
                                   k.DeptName_VChr      DeptName,
                                   a.cpstatus
                              from T_Opr_BIH_Register a,
                                   t_opr_bih_registerdetail b,
                                   T_BSE_Bed c,
                                   T_BSE_DeptDesc d,
                                   (select flg_int, flgname_vchr
                                      from t_sys_flg_table
                                     where tablename_vchr = 't_opr_bih_register'
                                       and columnname_vchr = 'PSTATUS_INT') e,
                                   (select tf.*
                                      from T_BSE_PatientPayType tf
                                     where tf.isusing_num = 1
                                       and tf.payflag_dec != 1) f,
                                   T_OPR_BIH_PATSPECREMARK g,
                                   t_bse_employee h,
                                   t_bse_patientcard j,
                                   T_BSE_DeptDesc k
                             where a.REGISTERID_CHR = b.REGISTERID_CHR(+)
                               and a.Status_Int = 1
                               and a.REGISTERID_CHR = c.BIHREGISTERID_CHR(+)
                               and a.AreaID_Chr = d.DeptID_Chr(+)
                               AND a.pstatus_int = e.flg_int(+)
                               and a.PayTypeID_Chr = f.PayTypeID_Chr(+)
                               and a.REGISTERID_CHR = g.REGISTERID_CHR(+)
                               and a.CASEDOCTOR_CHR = h.EMPID_CHR(+)
                               and a.PATIENTID_CHR = j.PATIENTID_CHR(+)
                               and a.DEPTID_CHR = k.DeptID_Chr(+)
                               and a.REGISTERID_CHR = ?
                ";
            /*<----------------------------------------------*/


            DataTable objDT = new DataTable();
            clsHRPTableService HRPService = new clsHRPTableService();
            long ret = 0;
            try
            {
                ret = 0;
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = strRegisterID;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
                {
                    m_mthGetPatientInfoFromDateTable(objDT.Rows[0], out objPatient);
                    if (objPatient != null) objPatient.cpstatus = objDT.Rows[0]["cpstatus"] == DBNull.Value ? 0 : Convert.ToInt32(objDT.Rows[0]["cpstatus"].ToString());

                    decimal m_decPreMoney, m_decPreUseMoney, m_decClearMoney, m_decVerticalMoney, m_decPrePayMoney;
                    ret = m_lngGetPatientChargeMessage(objPatient.m_strRegisterID, out  m_decPreMoney, out  m_decPreUseMoney, out  m_decClearMoney, out  m_decVerticalMoney, out  m_decPrePayMoney);
                    if (ret > 0)
                    {
                        objPatient.m_decPreMoney = m_decPreMoney;
                        objPatient.m_decPreUseMoney = m_decPreUseMoney;
                        objPatient.m_decClearMoney = m_decClearMoney;
                        objPatient.m_decVerticalMoney = m_decVerticalMoney;
                        objPatient.m_decPrePayMoney = m_decPrePayMoney;
                    }
                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        #endregion

        #region 查询病人费用信息
        /// <summary>
        /// 查询病人费用信息
        /// </summary>
        /// <param name="m_strRegisterID">病人登记流水号</param>
        /// <param name="m_decPreMoney">预交金额</param>
        /// <param name="m_decPreUseMoney">已用金额</param>
        /// <param name="m_decClearMoney">已清金额</param>
        /// <param name="m_decVerticalMoney">直收金额</param>
        /// <param name="m_decPrePayMoney">结余金额</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientChargeMessage(string m_strRegisterID, out decimal m_decPreMoney, out decimal m_decPreUseMoney, out decimal m_decClearMoney, out decimal m_decVerticalMoney, out decimal m_decPrePayMoney)
        {
            m_decPreMoney = 0;
            m_decPreUseMoney = 0;
            m_decClearMoney = 0;
            m_decVerticalMoney = 0;
            m_decPrePayMoney = 0;
            decimal PreMoney = 0, PreUseMoney = 0, NotUsePreMoney = 0, WaitMoney = 0, WaitClearMoney = 0, ClearMoney = 0, VerticalMoney = 0;
            long ret = 0;
            try
            {
                ret = 0;
                clsHRPTableService HRPService = new clsHRPTableService();
                DataTable objDT = new DataTable();
                // 加上相应的预交金,已用金等状态.
                string strSql = @" select sum(round(a.money_dec,2)) NotUsePreMoney from t_opr_bih_prepay a where a.registerid_chr=? and a.isclear_int=0";
                System.Data.IDataParameter[] arrParams2 = null;
                HRPService.CreateDatabaseParameter(1, out arrParams2);
                arrParams2[0].Value = m_strRegisterID;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams2);
                if (objDT.Rows.Count > 0)
                {
                    if (!objDT.Rows[0]["NotUsePreMoney"].ToString().Trim().Equals(""))
                    {
                        NotUsePreMoney = decimal.Parse(objDT.Rows[0]["NotUsePreMoney"].ToString().Trim());
                    }
                }
                System.Data.IDataParameter[] arrParams3 = null;
                HRPService.CreateDatabaseParameter(1, out arrParams3);
                strSql = @"select a.unitprice_dec,a.amount_dec,a.pstatus_int from t_opr_bih_patientcharge a where a.STATUS_INT=1 and a.chargeactive_dat is not null and a.registerid_chr=?";
                arrParams3[0].Value = m_strRegisterID;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams3);
                if (objDT.Rows.Count > 0)
                {
                    decimal unitprice_dec = 0;
                    decimal amount_dec = 0;
                    int pstatus_int = 0;
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        DataRow objRow = objDT.Rows[i];
                        pstatus_int = clsConverter.ToInt(objRow["pstatus_int"].ToString().Trim());
                        unitprice_dec = clsConverter.ToDecimal(objRow["unitprice_dec"].ToString().Trim());
                        amount_dec = clsConverter.ToDecimal(objRow["amount_dec"].ToString().Trim());
                        switch (pstatus_int)
                        {
                            case 0:
                                break;
                            case 1:
                                WaitMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                break;
                            case 2:
                                WaitClearMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                break;
                            case 3:
                                ClearMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                break;
                            case 4:
                                VerticalMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                break;
                            default:
                                PreUseMoney += decimal.Round(unitprice_dec * amount_dec, 2);
                                break;
                        }

                    }
                }

                //预交金额
                m_decPreMoney = NotUsePreMoney;
                //已用金额
                m_decPreUseMoney = PreUseMoney;
                //已清金额
                m_decClearMoney = ClearMoney;
                //直收金额
                m_decVerticalMoney = VerticalMoney;
                //结余金额
                m_decPrePayMoney = NotUsePreMoney - WaitMoney - WaitClearMoney;


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        #endregion

        [AutoComplete]
        private void m_mthGetPatientInfoFromDateTable(DataRow objRow, out clsBIHPatientInfo objPatient)
        {
            objPatient = null;
            if (objRow == null) return;

            objPatient = new clsBIHPatientInfo();
            objPatient.m_strRegisterID = clsConverter.ToString(objRow["RegisterID_Chr"]).Trim();
            objPatient.m_strPatientID = clsConverter.ToString(objRow["PatientID_Chr"]).Trim();
            objPatient.m_strInHospitalNo = clsConverter.ToString(objRow["InPatientID_Chr"]).Trim();
            objPatient.m_dtInHospital = clsConverter.ToDateTime(objRow["InPatient_Dat"]);
            objPatient.m_strDeptID = clsConverter.ToString(objRow["DeptID_Chr"]).Trim();
            objPatient.m_strDeptName = clsConverter.ToString(objRow["DeptName"]).Trim();
            objPatient.m_strAreaID = clsConverter.ToString(objRow["AreaID_Chr"]).Trim();

            objPatient.m_strAreaName = clsConverter.ToString(objRow["AreaName"]).Trim();
            objPatient.m_strBedID = clsConverter.ToString(objRow["BedID_Chr"]).Trim();
            objPatient.m_strBedName = clsConverter.ToString(objRow["BedName"]).Trim();
            /** update by xzf (05-09-29) */
            //@ objPatient.m_strDiagnose=clsConverter.ToString(objRow["Diagnose_Vchr"]).Trim();
            objPatient.m_strDiagnose = clsConverter.ToString(objRow["ICD10DIAGTEXT_VCHR"]).Trim();
            /* <<============================= */
            objPatient.m_intInTimes = clsConverter.ToInt(objRow["InPatientCount_Int"]);
            objPatient.m_strPatientName = clsConverter.ToString(objRow["Name_VChr"]).Trim();

            objPatient.m_strSex = clsConverter.ToString(objRow["Sex_Chr"]).Trim();
            objPatient.m_dtBorn = clsConverter.ToDateTime(objRow["Birth_Dat"]);
            objPatient.m_strPayTypeID = clsConverter.ToString(objRow["PayTypeID_Chr"]).Trim();
            objPatient.m_strPayTypeName = clsConverter.ToString(objRow["PayTypeName_VChr"]).Trim();
            objPatient.m_strInpatientState = clsConverter.ToString(objRow["state"]).Trim();
            objPatient.m_strMzdiagnose_vchr = clsConverter.ToString(objRow["mzdiagnose_vchr"]).Trim();
            objPatient.m_strDiagnose_vchr = clsConverter.ToString(objRow["diagnose_vchr"]).Trim();
            if (objRow["limitrate_mny"] != System.DBNull.Value)
            {
                objPatient.m_dblLIMITRATE_MNY = double.Parse(objRow["limitrate_mny"].ToString());
            }
            try
            {
                TimeSpan span1 = clsConverter.ToDateTime(objRow["today"].ToString().Trim()) - objPatient.m_dtBorn;
                objPatient.m_intAge = span1.Days / 365;
                //change 2007.4.25 zhu.w.t
                //if (objPatient.m_intAge == 0)
                //{
                //    if (span1.Days / 30 >= 1)
                //    {
                //        objPatient.m_strAge = span1.Days / 30 + "个月";
                //    }
                //    else if (span1.Days  >= 1)
                //    {
                //        objPatient.m_strAge = "1个月";
                //    }
                //}
                //else
                //{
                //    objPatient.m_strAge = objPatient.m_intAge + "岁";
                //}
                //====================>>
                objPatient.m_strAge = s_strGetAge(objPatient.m_dtBorn);
                /*<<====================*/
            }
            catch
            {
            }
            try
            {
                objPatient.m_strNursecate = clsConverter.ToString(objRow["NURSING_CLASS"]).Trim();
            }
            catch
            {
            }
            try
            {
                objPatient.m_strSTATE_INT = clsConverter.ToString(objRow["STATE_INT"]).Trim();
            }
            catch
            {
            }
            try
            {
                objPatient.m_strREMARKNAME_VCHR = objRow["REMARKNAME_VCHR"].ToString().Trim();
            }
            catch
            {
            }
            try
            {
                objPatient.m_strDES_VCHR = objRow["DES_VCHR"].ToString().Trim();
            }
            catch
            {
            }
            try
            {
                objPatient.m_strDOCTORID_CHR = objRow["DOCTORID_CHR"].ToString().Trim();
            }
            catch
            {
            }
            try
            {
                objPatient.m_strDOCTOR_VCHR = objRow["DOCTOR_VCHR"].ToString().Trim();
            }
            catch
            {
            }
            try
            {
                objPatient.m_strPATIENTCARDID_CHR = objRow["PATIENTCARDID_CHR"].ToString().Trim();
                objPatient.m_strHOMEPHONE_VCHR = objRow["HOMEPHONE_VCHR"].ToString().Trim();
                objPatient.m_strDOCTORNO_CHR = objRow["DOCTORNO_CHR"].ToString().Trim();
            }
            catch
            {
            }
            if (objRow.Table.Columns.Contains("INSUREDSUM_MNY"))
            {
                decimal.TryParse(objRow["INSUREDSUM_MNY"].ToString(), out objPatient.m_decinsuredsum_mny);
            }
        }

        /// <summary>
        /// 根据生日计算出实际年龄(婴儿可精确到分钟)
        /// </summary>
        /// <param name="datBirth">出生时间</param>
        /// <returns></returns>
        private string s_strGetAge(DateTime datBirth)
        {
            DateTime datNow = DateTime.Now;
            string strResult = "";
            int years = datNow.Year - datBirth.Year;
            int months = datNow.Month - datBirth.Month;
            int days = datNow.Day - datBirth.Day;
            int hours = datNow.Hour - datBirth.Hour;
            int minutes = datNow.Minute - datBirth.Minute;

            TimeSpan compare = datNow.Date - datBirth.Date;
            //int hours = (int)(compare.TotalHours) % 24;
            //int minutes = (int)compare.TotalMinutes % 60;

            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }

            if (hours < 0)
            {
                days--;
                hours += 24;
            }

            if (days < 0)
            {
                months--;
                days += 30;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            if (years >= 15)
            {
                strResult = years.ToString() + "岁";
            }
            else if (years >= 1)
            {
                strResult = years.ToString() + "岁" + months.ToString() + "月";
            }
            else if (months >= 1)
            {
                strResult = months.ToString() + "月" + days.ToString() + "天";
            }
            else if (days >= 1)
            {
                strResult = compare.Days.ToString() + "天" + hours.ToString() + "小时";
            }
            else if (hours >= 1)
            {
                strResult = hours.ToString() + "小时" + minutes.ToString() + "分钟";
            }
            else
                strResult = minutes.ToString() + "分钟";

            return strResult;
        }

        #region 改写病人入院诊断
        /// <summary>
        /// 改写病人入院诊断 add zhu.w.t 2007.4.26
        /// </summary>
        /// <param name="strRegisterId">住院登记流水号</param>
        /// <param name="strDiagnose">改写的入院诊断</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangePatientDiagnoseByRegisterID(string strRegisterId, string strDiagnose)
        {
            long lngRecEff = -1;
            string strSql = @"update t_opr_bih_register set icd10diagtext_vchr = ? where registerid_chr = ?";
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPSvc = new clsHRPTableService();
                HRPSvc.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = strDiagnose;
                arrParams[1].Value = strRegisterId;
                long lngRes = HRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRecEff;
        }
        #endregion

        /// <summary>
        /// 查找住院号	
        /// 包括(1=已上床;2=预出院;4=请假)
        /// </summary>
        /// <param name="strCode">查询字符串</param>
        /// <param name="arrNo">住院号 [out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindHospitalNo(string strCode, out string[] arrNo)
        {
            /*------------------------------->
            string strSql = @"
            SELECT DISTINCT inpatientid_chr
            FROM t_opr_bih_register
            WHERE status_int = 1
                AND (pstatus_int = 1 OR pstatus_int = 2 OR pstatus_int = 4)
                AND TRIM (LOWER (inpatientid_chr)) LIKE '%[FindCodeValue]'";
            strSql = strSql.Replace("[FindCodeValue]", strCode.ToLower().Trim());
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            */
            string strSql = @"
			SELECT DISTINCT inpatientid_chr
			FROM t_opr_bih_register
			WHERE status_int = 1
				AND (pstatus_int = 1 OR pstatus_int = 2 OR pstatus_int = 4)
				AND TRIM (LOWER (inpatientid_chr)) LIKE ? ";
            string InputCode = strCode.ToLower().Trim() + "%";
            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = InputCode;

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                ret = new clsHRPTableService().lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            /*<--------------------------------------------------*/
            if ((ret > 0) && (objDT != null))
            {
                arrNo = new string[objDT.Rows.Count];
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    arrNo[i] = clsConverter.ToString(objDT.Rows[i]["InPatientID_Chr"]).Trim();
                }
                return 1;
            }
            else
            {
                arrNo = null;
                return 0;
            }
        }

        /// <summary>
        /// 查找住院号	
        /// 包括(1=已上床;2=预出院;4=请假)
        /// </summary>
        /// <param name="p_strCode">查询字符串</param>
        /// <param name="p_objResultArr">入院登记对象 [out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindHospitalNo(string p_strCode, out clsT_Opr_Bih_Register_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            string strSQL = @"
							SELECT a.* 
								,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.deptid_chr) DeptName  
								,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.areaid_chr) AreaName  
								,(select code_chr from t_bse_bed where bedid_chr=a.bedid_chr) BedNo  
								,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) =trim(a.operatorid_chr)) OPERATORNAME  
								,(select LastName_vchr from T_BSE_EMPLOYEE where trim(empid_chr) = trim(a.CASEDOCTOR_CHR)) doctorname 
								,(select LastName_vchr from T_BSE_EMPLOYEE where trim(empid_chr) = trim(a.MZDOCTOR_CHR)) outdoctorname 
								,decode(type_int,1,'门诊',2,'急诊',3,'他院转入',4,'他科转入','') TypeName  
								,decode(pstatus_int,0,'未上床',1,'已上床',2,'预出院',3,'实际出院','') PstatusName  
							FROM t_opr_bih_register a 
							WHERE status_int = 1
								AND (pstatus_int = 1 OR pstatus_int = 2 OR pstatus_int = 4)
								AND TRIM (LOWER (inpatientid_chr)) LIKE '%[FindCodeValue]'";
            strSQL = strSQL.Replace("[FindCodeValue]", p_strCode.ToLower().Trim());
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Opr_Bih_Register_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        #region 填充
                        p_objResultArr[i1] = new clsT_Opr_Bih_Register_VO();
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        p_objResultArr[i1].m_strPATIENTID_CHR = dtbResult.Rows[i1]["PATIENTID_CHR"].ToString().Trim();
                        if (!dtbResult.Rows[i1]["ISBOOKING_INT"].ToString().Equals(""))
                            p_objResultArr[i1].m_intISBOOKING_INT = Convert.ToInt32(dtbResult.Rows[i1]["ISBOOKING_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strINPATIENTID_CHR = dtbResult.Rows[i1]["INPATIENTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strINPATIENT_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["INPATIENT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        p_objResultArr[i1].m_strDEPTID_CHR = dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strAREAID_CHR = dtbResult.Rows[i1]["AREAID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strBEDID_CHR = dtbResult.Rows[i1]["BEDID_CHR"].ToString().Trim();
                        if (!dtbResult.Rows[i1]["TYPE_INT"].ToString().Trim().Equals(""))
                            p_objResultArr[i1].m_intTYPE_INT = Convert.ToInt32(dtbResult.Rows[i1]["TYPE_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strDIAGNOSE_VCHR = dtbResult.Rows[i1]["DIAGNOSE_VCHR"].ToString().Trim();
                        if (!dtbResult.Rows[i1]["LIMITRATE_MNY"].ToString().Trim().Equals(""))
                            p_objResultArr[i1].m_dblLIMITRATE_MNY = Convert.ToDouble(dtbResult.Rows[i1]["LIMITRATE_MNY"].ToString().Trim());
                        if (!dtbResult.Rows[i1]["INPATIENTCOUNT_INT"].ToString().Trim().Equals(""))
                            p_objResultArr[i1].m_intINPATIENTCOUNT_INT = Convert.ToInt16(dtbResult.Rows[i1]["INPATIENTCOUNT_INT"].ToString().Trim());
                        if (!dtbResult.Rows[i1]["STATE_INT"].ToString().Trim().Equals(""))
                            p_objResultArr[i1].m_intSTATE_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATE_INT"].ToString().Trim());
                        if (!dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim().Equals(""))
                            p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        if (!dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim().Equals(""))
                            p_objResultArr[i1].m_intPSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim());
                        // 入院科室名称 [非字段]
                        p_objResultArr[i1].m_strDeptName = dtbResult.Rows[i1]["DeptName"].ToString().Trim();
                        // 入院病区名称 [非字段]
                        if (dtbResult.Rows[i1]["AreaName"] != null)
                        {
                            p_objResultArr[i1].m_strAreaName = dtbResult.Rows[i1]["AreaName"].ToString().Trim();
                        }
                        // 入院床号 [非字段]
                        if (dtbResult.Rows[i1]["BedNo"] != null)
                        {
                            p_objResultArr[i1].m_strBedNo = dtbResult.Rows[i1]["BedNo"].ToString().Trim();
                        }
                        // 操作人名称 [非字段]
                        p_objResultArr[i1].m_strOperatorName = dtbResult.Rows[i1]["OperatorName"].ToString().Trim();
                        // 入院方式名称	[非字段]	{1=门诊;2=急诊;3=他院转入}
                        p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        // 状态标志	[非字段] {0=未上床;1=已上床;2=预出院;3=实际出院}
                        p_objResultArr[i1].m_strPstatusName = dtbResult.Rows[i1]["PstatusName"].ToString().Trim();
                        p_objResultArr[i1].m_strCASEDOCTOR_CHR = dtbResult.Rows[i1]["CASEDOCTOR_CHR"].ToString().Trim();
                        //门诊医生
                        p_objResultArr[i1].m_strMZDOCTOR_CHR = dtbResult.Rows[i1]["MZDOCTOR_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_stroutdoctorname = dtbResult.Rows[i1]["outdoctorname"].ToString().Trim();
                        //门诊诊断
                        p_objResultArr[i1].m_strMZDIAGNOSE_VCHR = dtbResult.Rows[i1]["MZDIAGNOSE_VCHR"].ToString().Trim();
                        try
                        {
                            p_objResultArr[i1].m_intINPATIENTNOTYPE_INT = int.Parse(dtbResult.Rows[i1]["INPATIENTNOTYPE_INT"].ToString());
                        }
                        catch
                        {
                            p_objResultArr[i1].m_intINPATIENTNOTYPE_INT = -1;
                        }
                        p_objResultArr[i1].m_strdoctname = dtbResult.Rows[i1]["doctorname"].ToString().Trim();
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

        /// <summary>
        /// 查找住院号	
        /// 包括(0=未上床;1=已上床;2=预出院;4=请假)
        /// </summary>
        /// <param name="strCode">查询字符串</param>
        /// <param name="arrNo">住院号 [out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindHospitalNo0124(string strCode, out string[] arrNo)
        {
            string strSql = @"
			SELECT DISTINCT inpatientid_chr
			FROM t_opr_bih_register
			WHERE status_int = 1
				AND (pstatus_int = 0 OR pstatus_int = 1 OR pstatus_int = 2 OR pstatus_int = 4)
				AND TRIM (LOWER (inpatientid_chr)) LIKE '%[FindCodeValue]'";
            strSql = strSql.Replace("[FindCodeValue]", strCode.ToLower().Trim());
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrNo = new string[objDT.Rows.Count];
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    arrNo[i] = clsConverter.ToString(objDT.Rows[i]["InPatientID_Chr"]).Trim();
                }
                return 1;
            }
            else
            {
                arrNo = null;
                return 0;
            }
        }
        //Add by jli in 2005-03-03

        /// <summary>
        /// 查找诊疗卡号
        /// </summary>
        /// <param name="strCode">查找字符串</param>
        /// <param name="arrCard">诊疗卡号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindPatientCard(string strCode, out string[] arrCard)
        {
            string strSQL = @"SELECT * FROM t_bse_patientcard a
							LEFT JOIN t_opr_bih_register b
							on a.patientid_chr=b.patientid_chr
							where a.status_int=1 and b.status_int=1 AND LOWER(a.patientcardid_chr) like '%" + strCode.ToLower().Trim() + "'";

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSQL, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrCard = new string[objDT.Rows.Count];
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    arrCard[i] = clsConverter.ToString(objDT.Rows[i]["patientcardid_chr"]).Trim();
                }
                return 1;
            }
            else
            {
                arrCard = null;
                return 0;
            }
        }

        //Add End

        [AutoComplete]
        public long m_lngGetAreaByID(string strAreaID, out clsBIHArea objArea)
        {
            string strSql = @"
			select DeptName_VChr 
			from T_BSE_DeptDesc 
			where Trim(DeptID_Chr) = Trim('[AreaIDValue]')
			order by Modify_Dat desc
			";

            strSql = strSql.Replace("[AreaIDValue]", strAreaID.Trim());

            object objValue = new object();
            long ret = 0;
            try
            {
                ret = m_lngGetValue(strSql, out objValue);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (ret == 0)
            {
                objArea = null;
                return 0;
            }
            else
            {
                objArea = new clsBIHArea();
                objArea.m_strAreaID = strAreaID;
                objArea.m_strAreaName = clsConverter.ToString(objValue).Trim();
                return 1;
            }
        }

        /// <summary>
        /// 获取病床Vo信息
        /// </summary>
        /// <param name="strAreaID">病区ID</param>
        /// <param name="strInputCode">查询字符串</param>
        /// <param name="arrBed"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBedByArea(string strAreaID, string strInputCode, out clsBIHBed[] arrBed)
        {
            //状态{1=空床;2=占床;3=预约占床;4=包房占床} 
            /*
            string strSql = @"
				select BedID_Chr,Code_Chr 
				from T_BSE_Bed 
				where Trim(LOWER(Code_Chr)) Like '[InputCode]%' and Trim(AreaID_Chr) = '[AreaIDValue]' 
				and Status_Int=2
				order by Code_Chr
			"; 
            strSql = strSql.Replace("[InputCode]", strInputCode.ToLower().Trim());
            strSql = strSql.Replace("[AreaIDValue]", strAreaID.Trim());
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            /*------------------------------------------*/
            string strSql = @"
				 SELECT    a.bedid_chr,a.code_chr,a.areaid_chr,b.lastname_vchr,b.sex_chr, c.registerid_chr     
                    FROM t_bse_bed a,t_opr_bih_registerdetail b,t_opr_bih_register c
                    where a.bihregisterid_chr = c.registerid_chr
                    and b.registerid_chr = c.registerid_chr
                    AND (c.pstatus_int = 1)
                    and Trim(LOWER(Code_Chr)) Like ? and  c.areaid_chr=? 
                    AND (a.status_int = 2 or a.status_int = 6)
                    order by a.code_chr
			";
            string InputCode = strInputCode.ToLower().Trim() + "%";
            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
            arrParams[0].Value = InputCode;
            arrParams[1].Value = strAreaID.Trim();
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                ret = new clsHRPTableService().lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            /*<--------------------------------------------------*/

            if ((ret > 0) && (objDT != null))
            {
                arrBed = new clsBIHBed[objDT.Rows.Count];
                for (int i = 0; i < arrBed.Length; i++)
                {
                    arrBed[i] = new clsBIHBed();
                    arrBed[i].m_strAreaID = strAreaID;
                    arrBed[i].m_strBedID = clsConverter.ToString(objDT.Rows[i]["BedID_Chr"]).Trim();
                    arrBed[i].m_strBedName = clsConverter.ToString(objDT.Rows[i]["Code_Chr"]).Trim();
                    clsBIHPatientInfo patient = new clsBIHPatientInfo();
                    patient.m_strPatientName = clsConverter.ToString(objDT.Rows[i]["lastname_vchr"].ToString()).Trim();
                    patient.m_strSex = clsConverter.ToString(objDT.Rows[i]["sex_chr"].ToString()).Trim();
                    patient.m_strRegisterID = clsConverter.ToString(objDT.Rows[i]["registerid_chr"].ToString()).Trim();
                    arrBed[i].m_objPatient = patient;
                }
                return 1;
            }
            else
            {
                arrBed = null;
                return 0;
            }

        }

        /// <summary>
        /// 获取病床、病人Vo信息
        /// </summary>
        /// <param name="strAreaID">病区ID</param>
        /// <param name="strInputCode">查询字符串</param>
        /// <param name="arrBed"></param>
        /// <returns></returns>
        /// add by chenxiang 2006-03-22
        [AutoComplete]
        public long m_lngGetBedAndPatientInfoByArea(string strAreaID, string strInputCode, out clsBIHPatientInfo[] objPatient)
        {
            //状态{1=空床;2=占床;3=预约占床;4=包房占床}
            string strSql = @"select   a.bedid_chr, a.code_chr, c.inpatientid_chr, c.lastname_vchr
                                from t_bse_bed a, t_opr_bih_register b, t_bse_patient c
                               where trim (lower (a.code_chr)) like '[InputCode]%'
                                 and trim (a.areaid_chr) = '[AreaIDValue]'
                                 and a.status_int = 2
                                 and a.bedid_chr = b.bedid_chr
                                 and a.areaid_chr = b.areaid_chr
                                 and b.patientid_chr = c.patientid_chr
                                 and (b.pstatus_int = 1 or b.pstatus_int = 4)
                            order by a.code_chr";

            strSql = strSql.Replace("[InputCode]", strInputCode.ToLower().Trim());
            strSql = strSql.Replace("[AreaIDValue]", strAreaID.Trim());

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                objPatient = new clsBIHPatientInfo[objDT.Rows.Count];
                for (int i = 0; i < objPatient.Length; i++)
                {
                    objPatient[i] = new clsBIHPatientInfo();
                    objPatient[i].m_strAreaID = strAreaID;
                    objPatient[i].m_strBedID = clsConverter.ToString(objDT.Rows[i]["BedID_Chr"]).Trim();
                    objPatient[i].m_strBedName = clsConverter.ToString(objDT.Rows[i]["Code_Chr"]).Trim();
                    objPatient[i].m_strPatientName = clsConverter.ToString(objDT.Rows[i]["LASTNAME_VCHR"]).Trim();
                    objPatient[i].m_strInHospitalNo = clsConverter.ToString(objDT.Rows[i]["INPATIENTID_CHR"]).Trim();
                }
                return 1;
            }
            else
            {
                objPatient = null;
                return 0;
            }

        }

        [AutoComplete]
        public long m_lngGetAreaBeds(string strAreaID, out clsBIHBed[] arrBed)
        {
            string strSql = @"
				select TBed.BedID_Chr ,TBed.Code_Chr BedName,TPat.*
				from T_BSE_Bed TBed,
				(
						select TA.RegisterID_Chr,TA.PatientID_Chr,TA.InPatientID_Chr,TA.InPatient_Dat,
							TA.DeptID_Chr,TA.AreaID_Chr,TA.BedID_Chr BedID,TA.Diagnose_Vchr,TA.InPatientCount_Int,
							TB.Name_VChr,TB.Sex_Chr,TB.Birth_Dat,TB.PayTypeID_Chr,TB.PayTypeName_VChr,
							TD.DeptName_VChr AreaName,TA.limitrate_mny
							from T_Opr_BIH_Register TA,
							(   select B.PatientID_Chr,B.Name_VChr,B.Sex_Chr,B.Birth_Dat,B.PayTypeID_Chr,
										C.PayTypeName_VChr
								from T_BSE_Patient B,T_BSE_PatientPayType C
								where B.status_int=1
								and B.PayTypeID_Chr=C.PayTypeID_Chr(+)
								and C.IsUsing_Num=1
							) TB,
							T_BSE_DeptDesc TD
							where TA.PatientID_Chr=TB.PatientID_Chr(+)
							and TA.AreaID_Chr=TD.DeptID_Chr(+)
							and TA.Status_Int=1 
							and Trim(TA.AreaID_Chr)='[AreaIDValue]'
				)TPat
				where Trim(TBed.AreaID_Chr)='[AreaIDValue]' and TBed.BedID_Chr=TPat.BedID(+)
				order by TBed.Code_Chr
			";

            strSql = strSql.Replace("[AreaIDValue]", strAreaID);

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrBed = new clsBIHBed[objDT.Rows.Count];
                for (int i = 0; i < arrBed.Length; i++)
                {
                    arrBed[i] = new clsBIHBed();
                    arrBed[i].m_strAreaID = strAreaID;
                    arrBed[i].m_strBedID = clsConverter.ToString(objDT.Rows[i]["BedID_Chr"]).Trim();
                    arrBed[i].m_strBedName = clsConverter.ToString(objDT.Rows[i]["BedName"]).Trim();

                    if (clsConverter.ToString(objDT.Rows[i]["RegisterID_Chr"]).Trim() != "")
                    {
                        clsBIHPatientInfo objPatient;
                        m_mthGetPatientInfoFromDateTable(objDT.Rows[i], out objPatient);
                        arrBed[i].m_objPatient = objPatient;
                    }
                }
                return 1;
            }
            else
            {
                arrBed = null;
                return 0;
            }

        }

        /// <summary>
        /// 获取Sql语句的值	[单个值-数据集中第一行第一列的值]
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="objValue">数据集中第一行第一列的值 [out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngGetValue(string strSql, out object objValue)
        {
            long ret = 0;
            objValue = null;
            try
            {
                DataTable objDT = new DataTable();
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                if ((ret > 0) && (objDT != null))
                {
                    if (objDT.Rows.Count > 0)
                    {
                        objValue = objDT.Rows[0][0];
                    }
                    else
                    {
                        objValue = null;
                    }
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return 0;
            }
        }
        /// <summary>
        /// 查询病区信息VO
        /// </summary>
        /// <param name="strCode">查询字符串</param>
        /// <param name="arrArea"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindArea(string strCode, out clsBIHArea[] arrArea)
        {
            /** @update by xzf (05-09-20)
             * 增加了code字段
             */
            string strSql = @"
				select DeptID_Chr,DeptName_VChr,ShortNo_Chr,PYCode_Chr,CODE_VCHR 
                from T_BSE_DeptDesc
				where ATTRIBUTEID='0000003'
					and Status_Int=1 [FindCondition]
				ORDER BY deptid_chr
			";

            strCode = strCode.Trim();
            if (strCode.Length <= 0)
            {
                strSql = strSql.Replace("[FindCondition]", "");
            }
            else if ((strCode[0] >= '0') && (strCode[0] <= '9'))
            {
                /** @update by xzf (05-09-20)
                 * 
                 */
                //@strSql=strSql.Replace("[FindCondition]"," and Trim(LOWER(ShortNo_Chr)) Like '" + strCode.ToLower().Trim() + "%' ");
                strSql = strSql.Replace("[FindCondition]", " and Trim(LOWER(code_vchr)) Like '" + strCode.ToLower().Trim() + "%' ");
                /* <<============================================= */
            }
            else if (((strCode[0] >= 'a') && (strCode[0] <= 'z')) || ((strCode[0] >= 'A') && (strCode[0] <= 'Z')))
            {
                strSql = strSql.Replace("[FindCondition]", " and Trim(LOWER(PYCode_Chr)) Like '" + strCode.ToLower().Trim() + "%' ");
            }
            else
            {
                strSql = strSql.Replace("[FindCondition]", " and LOWER(DeptName_VChr) Like '" + strCode.ToLower().Trim() + "%' ");
            }

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrArea = new clsBIHArea[objDT.Rows.Count];
                for (int i = 0; i < arrArea.Length; i++)
                {
                    arrArea[i] = new clsBIHArea();
                    arrArea[i].m_strAreaID = clsConverter.ToString(objDT.Rows[i]["DeptID_Chr"]).Trim();
                    arrArea[i].m_strAreaName = clsConverter.ToString(objDT.Rows[i]["DeptName_VChr"]).Trim();
                    arrArea[i].code = clsConverter.ToString(objDT.Rows[i]["code_vchr"].ToString().Trim());

                }
                return 1;
            }
            else
            {
                arrArea = null;
                return 0;
            }
            /* <<============================== */
        }

        /// <summary>
        /// 查询医生信息VO
        /// </summary>
        /// <param name="strCode"></param>
        /// <param name="arrDoctor"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindDoctor(string strCode, out clsBIHDoctor[] arrDoctor)
        {
            string strSql = @"
				select  EmpID_Chr,LastName_VChr,EmpNo_Chr 
				from T_bse_Employee
				where Status_Int=1 [FindCondition]
			";

            strCode = strCode.Trim();
            if (strCode.Length <= 0)
            {
                strSql = strSql.Replace("[FindCondition]", "");
            }
            else if ((strCode[0] >= '0') && (strCode[0] <= '9'))
            {
                strSql = strSql.Replace("[FindCondition]", " and LOWER(EmpNo_Chr) Like '" + strCode.ToLower().Trim() + "%' ");
            }
            else if (((strCode[0] >= 'a') && (strCode[0] <= 'z')) || ((strCode[0] >= 'A') && (strCode[0] <= 'Z')))
            {
                strSql = strSql.Replace("[FindCondition]", " and LOWER(PYCode_Chr) Like '" + strCode.Trim().ToLower() + "%' ");
            }
            else
            {
                strSql = strSql.Replace("[FindCondition]", " and LOWER(LastName_VChr) Like '" + strCode.Trim().ToLower() + "%' ");
            }

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrDoctor = new clsBIHDoctor[objDT.Rows.Count];
                for (int i = 0; i < arrDoctor.Length; i++)
                {
                    arrDoctor[i] = new clsBIHDoctor();
                    arrDoctor[i].m_strDoctorID = clsConverter.ToString(objDT.Rows[i]["EmpID_Chr"]).Trim();
                    arrDoctor[i].m_strDoctorNo = clsConverter.ToString(objDT.Rows[i]["EmpNo_Chr"]).Trim();
                    arrDoctor[i].m_strDoctorName = clsConverter.ToString(objDT.Rows[i]["LastName_VChr"]).Trim();
                }
                return 1;
            }
            else
            {
                arrDoctor = null;
                return 0;
            }
        }

        /// <summary>
        /// 按编码获取用药频率信息
        /// </summary>
        /// <param name="strCode">编码,为""时获取所有</param>
        /// <param name="arrFreq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeFreq(string strCode, out clsAIDRecipeFreq[] arrFreq)
        {
            arrFreq = null;
            string strSql = @"
				SELECT freqid_chr, freqname_chr, usercode_chr, times_int, days_int,
					lexectime_vchr, texectime_vchr, execweekday_chr, printdesc_vchr
				FROM t_aid_recipefreq
					where 
						(UPPER(Trim(UserCode_Chr)) like '[FindCode]%')
					or	(UPPER(Trim(FREQNAME_CHR)) like '%[FindCode]%')
				order by UserCode_Chr
				";

            strSql = strSql.Replace("[FindCode]", strCode.Trim().ToUpper());

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrFreq = new clsAIDRecipeFreq[objDT.Rows.Count];
                for (int i = 0; i < arrFreq.Length; i++)
                {
                    arrFreq[i] = m_objGetFreqFromDataRow(objDT.Rows[i]);

                }

                return 1;
            }
            else
            {
                return 0;
            }
        }
        [AutoComplete]
        private clsAIDRecipeFreq m_objGetFreqFromDataRow(DataRow objRow)
        {
            if (objRow == null)
                return null;
            else
            {
                clsAIDRecipeFreq objFreq = new clsAIDRecipeFreq();
                objFreq.m_strFreqID = clsConverter.ToString(objRow["FreqID_Chr"]).Trim();
                objFreq.m_strFreqName = clsConverter.ToString(objRow["FreqName_Chr"]).Trim();
                objFreq.m_strUserCode = clsConverter.ToString(objRow["UserCode_Chr"]).Trim();
                objFreq.m_intTimes = clsConverter.ToInt(objRow["Times_Int"]);
                objFreq.m_intDays = clsConverter.ToInt(objRow["Days_Int"]);
                objFreq.m_strLExecTime = clsConverter.ToString(objRow["LExecTime_VChr"]).Trim();
                objFreq.m_strTExecTime = clsConverter.ToString(objRow["TExecTime_VChr"]).Trim();
                objFreq.m_strExecWeekDay = clsConverter.ToString(objRow["ExecWeekDay_Chr"]).Trim();
                objFreq.m_strPrintDesc = clsConverter.ToString(objRow["PrintDesc_VChr"]).Trim();
                return objFreq;
            }
        }
        /// <summary>
        /// 获取当前频率信息--根据流水号
        /// </summary>
        /// <param name="strFreqID">流水号</param>
        /// <param name="objFreq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeFreqByID(string strFreqID, out clsAIDRecipeFreq objFreq)
        {
            string strSql = @"
				select FreqID_Chr,FreqName_Chr,UserCode_Chr,Times_Int,Days_Int,
				LExecTime_VChr,TExecTime_VChr,ExecWeekDay_Chr,PrintDesc_VChr
				from T_Aid_RecipeFreq
				where Trim(FreqID_Chr)=Trim('[FreqIDValue]')
				";

            strSql = strSql.Replace("[FreqIDValue]", strFreqID.Trim());

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
            {
                objFreq = m_objGetFreqFromDataRow(objDT.Rows[0]);
                return 1;
            }
            else
            {
                objFreq = null;
                return 0;
            }

        }

        /// <summary>
        /// 科室列表
        /// </summary>
        /// <param name="p_strFindString"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDepartment(string p_strFindString, out clsBSEUsageType[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            string strSQL = @"select a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr, a.wbcode_chr, a.usercode_vchr
                                from t_bse_deptdesc a
                               where a.status_int = 1
                                 and (a.inpatientoroutpatient_int = 0 or a.inpatientoroutpatient_int = 2) 
                                 and (a.expertdeptflag_int = 0)
                                 and (   (lower(a.usercode_vchr) like ?)
                                      or (lower(a.deptname_vchr) like ?)
                                      or (lower(a.pycode_chr) like ?)
                                      or (lower(a.wbcode_chr) like ?)
                                      or (lower(a.code_vchr) like ?)
                                     )   
                                order by a.code_vchr";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(5, out arrParams);
                arrParams[0].Value = p_strFindString.Trim().ToLower() + "%";
                arrParams[1].Value = "%" + p_strFindString.Trim().ToLower() + "%";
                arrParams[2].Value = p_strFindString.Trim().ToLower() + "%";
                arrParams[3].Value = p_strFindString.Trim().ToLower() + "%";
                arrParams[4].Value = p_strFindString.Trim().ToLower() + "%";

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsBSEUsageType[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsBSEUsageType();
                        p_objResultArr[i].m_strUsageID = clsConverter.ToString(dtbResult.Rows[i]["deptid_chr"]);
                        p_objResultArr[i].m_strUsageName = clsConverter.ToString(dtbResult.Rows[i]["deptname_vchr"]);
                        p_objResultArr[i].m_strUserCode = clsConverter.ToString(dtbResult.Rows[i]["code_vchr"]);
                        p_objResultArr[i].m_intPUTMED_INT = 0;
                        p_objResultArr[i].m_intSCOPE_INT = 0;
                        p_objResultArr[i].m_intTEST_INT = 0;
                        p_objResultArr[i].m_strPYCODE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["pycode_chr"]);
                        p_objResultArr[i].m_strWBCODE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["wbcode_chr"]);
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

        /// <summary>
        /// 获取用药方式VO	根据查询字符串
        /// </summary>
        /// <param name="p_strFindString">编码,为""时获取所有</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUsageType(string p_strFindString, out clsBSEUsageType[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            string strSQL = @"
                select UsageID_Chr,UsageName_Vchr,UserCode_Chr,PYCODE_VCHR,WBCODE_VCHR,SCOPE_INT,PUTMED_INT,TEST_INT
				from T_Bse_UsageType
				where 
					 (	(UPPER(UserCode_Chr) like ?)
					 or (UPPER(UsageName_Vchr) like ?)
					 or (UPPER(PYCODE_VCHR) like ?)
					 or (UPPER(WBCODE_VCHR) like ?)  )
				order by UserCode_Chr
				";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(4, out arrParams);
                arrParams[0].Value = p_strFindString.Trim().ToUpper() + "%";
                arrParams[1].Value = "%" + p_strFindString.Trim().ToUpper() + "%";
                arrParams[2].Value = p_strFindString.Trim().ToUpper() + "%";
                arrParams[3].Value = p_strFindString.Trim().ToUpper() + "%";

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsBSEUsageType[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsBSEUsageType();
                        p_objResultArr[i].m_strUsageID = clsConverter.ToString(dtbResult.Rows[i]["UsageID_Chr"]);
                        p_objResultArr[i].m_strUsageName = clsConverter.ToString(dtbResult.Rows[i]["UsageName_Vchr"]);
                        p_objResultArr[i].m_strUserCode = clsConverter.ToString(dtbResult.Rows[i]["UserCode_Chr"]);
                        p_objResultArr[i].m_intPUTMED_INT = clsConverter.ToInt(dtbResult.Rows[i]["PUTMED_INT"]);
                        p_objResultArr[i].m_intSCOPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["SCOPE_INT"]);
                        p_objResultArr[i].m_intTEST_INT = clsConverter.ToInt(dtbResult.Rows[i]["TEST_INT"]);
                        p_objResultArr[i].m_strPYCODE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["PYCODE_VCHR"]);
                        p_objResultArr[i].m_strWBCODE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["WBCODE_VCHR"]);
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

        /// <summary>
        /// 获取用药方式VO	根据查询字符串
        /// </summary>
        /// <param name="p_strFindString">编码,为""时获取所有</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUsageType(string p_strFindString, out clsBSEUsageType[] p_objResultArr, int m_intMEDICNETYPE_INT)
        {
            long lngRes = 0;
            p_objResultArr = null;
            string strSQL = @"
                select UsageID_Chr,UsageName_Vchr,UserCode_Chr,PYCODE_VCHR,WBCODE_VCHR,SCOPE_INT,PUTMED_INT,TEST_INT
				from T_Bse_UsageType
				where 
					 (	(UPPER(UserCode_Chr) like ?)
					 or (UPPER(UsageName_Vchr) like ?)
					 or (UPPER(PYCODE_VCHR) like ?)
					 or (UPPER(WBCODE_VCHR) like ?)  )
                [SCOPE_INT]
				order by UserCode_Chr
				
				";
            string m_strScope = "";
            switch (m_intMEDICNETYPE_INT)
            {

                case 1:
                    m_strScope = " and SCOPE_INT in(0,1) ";
                    break;
                case 2:
                    m_strScope = " and SCOPE_INT in(0,2) ";
                    break;
                default:
                    m_strScope = "";
                    break;

            }
            strSQL = strSQL.Replace("[SCOPE_INT]", m_strScope);

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(4, out arrParams);
                arrParams[0].Value = p_strFindString.Trim().ToUpper() + "%";
                arrParams[1].Value = "%" + p_strFindString.Trim().ToUpper() + "%";
                arrParams[2].Value = p_strFindString.Trim().ToUpper() + "%";
                arrParams[3].Value = p_strFindString.Trim().ToUpper() + "%";

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsBSEUsageType[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsBSEUsageType();
                        p_objResultArr[i].m_strUsageID = clsConverter.ToString(dtbResult.Rows[i]["UsageID_Chr"]);
                        p_objResultArr[i].m_strUsageName = clsConverter.ToString(dtbResult.Rows[i]["UsageName_Vchr"]);
                        p_objResultArr[i].m_strUserCode = clsConverter.ToString(dtbResult.Rows[i]["UserCode_Chr"]);
                        p_objResultArr[i].m_intPUTMED_INT = clsConverter.ToInt(dtbResult.Rows[i]["PUTMED_INT"]);
                        p_objResultArr[i].m_intSCOPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["SCOPE_INT"]);
                        p_objResultArr[i].m_intTEST_INT = clsConverter.ToInt(dtbResult.Rows[i]["TEST_INT"]);
                        p_objResultArr[i].m_strPYCODE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["PYCODE_VCHR"]);
                        p_objResultArr[i].m_strWBCODE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["WBCODE_VCHR"]);
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

        /// <summary>
        /// 获取用药方式Vo	根据ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">用药方式ID</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUsageTypeByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID, out clsBSEUsageType p_objResult)
        {
            p_objResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"
				select UsageID_Chr,UsageName_Vchr,UserCode_Chr 
				from T_Bse_UsageType
				where UsageID_Chr = '" + p_strID.Trim() + "'";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsBSEUsageType();
                    p_objResult.m_strUsageID = clsConverter.ToString(dtbResult.Rows[0]["UsageID_Chr"]);
                    p_objResult.m_strUsageName = clsConverter.ToString(dtbResult.Rows[0]["UsageName_Vchr"]);
                    p_objResult.m_strUserCode = clsConverter.ToString(dtbResult.Rows[0]["UserCode_Chr"]);
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


        #region 查询诊疗项目
        /// <summary>
        /// 构造SQL语句的查询条件	[返回格式包括"and"]
        /// </summary>
        /// <param name="strTableName">表名</param>
        /// <param name="strAreaID">病区ID</param>
        /// <param name="strBedBegin">起始病床号</param>
        /// <param name="strBedEnd">截至病床号</param>
        /// <returns>条件字符串: 如：“and ID='00001'”</returns>
        [AutoComplete]
        public string m_strGetPatientsSQL(string strTableName, string strAreaID, string strBedBegin, string strBedEnd)
        {
            string strSql = "";
            if (strAreaID.Trim() != "")
            {
                strSql = strSql + " and ( trim([TableName].AreaID_Chr)='[AreaIDValue]' ) ";
            }
            if (strBedBegin.Trim() != "")
            {
                strSql = strSql + " and ( BIHPack.ToNumber([TableName].Code_Chr)>= [BeginBedNO] ) ";
            }
            if (strBedEnd.Trim() != "")
            {
                strSql = strSql + " and ( BIHPack.ToNumber([TableName].Code_Chr)<= [EndBedNO] ) ";
            }
            strSql = strSql.Replace("[TableName]", strTableName);
            strSql = strSql.Replace("[AreaIDValue]", strAreaID.Trim());
            strSql = strSql.Replace("[BeginBedNO]", clsConverter.ToInt(strBedBegin).ToString());
            strSql = strSql.Replace("[EndBedNO]", clsConverter.ToInt(strBedEnd).ToString());
            return strSql;
        }

        /// <summary>
        /// 按编码查询诊疗项目
        /// </summary>
        /// <param name="p_strFindString">查询字符串</param>
        /// <param name="arrDic">诊疗项目Vo</param>
        /// <returns></returns>
        /// <remarks>
        /// 注意：在诊疗项目不存在收费项目时取诊疗项目本身的: 剂量单位/用量单位/用法
        /// </remarks>
        [AutoComplete]
        public long m_lngGetOrderDicByCode(string p_strFindString, out clsBIHOrderDic[] arrDic)
        {
            arrDic = null;
            /*
            string strSql = @"
                select	A.OrderDicID_Chr,A.Name_Chr,A.Des_VChr,A.UserCode_Chr,A.WBCode_Chr,A.PYCode_Chr,A.ExecDept_Chr,A.OrderCateID_Chr,A.ItemID_Chr 
                        ,B.IsRich_Int,B.ItemSpec_Vchr
                        ,decode(B.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPrice
                        ,B.Dosage_Dec,B.DosageUnit_Chr,B.ItemIpUnit_Chr UseUnit_Chr,B.USAGEID_CHR
                        ,(SELECT usagename_vchr FROM t_bse_usagetype WHERE t_bse_usagetype.usageid_chr=B.USAGEID_CHR) UsageName
                from T_BSE_BIH_ORDERDIC A,T_BSE_CHARGEITEM B
                where A.ItemID_Chr=B.ItemID_Chr
                and [FindItem] and ROWNUM<=[ROWNUM]
                UNION
                select  A.OrderDicID_Chr,A.Name_Chr,A.Des_VChr,A.UserCode_Chr,A.WBCode_Chr,A.PYCode_Chr,A.ExecDept_Chr,A.OrderCateID_Chr,A.ItemID_Chr 
                        ,null IsRich_Int,null ItemSpec_Vchr,null ItemPrice,1 Dosage_Dec
                        ,A.NULLITEMDOSAGEUNIT_CHR DosageUnit_Chr,A.NULLITEMUSEUNIT_CHR UseUnit_Chr,A.NULLITEMDOSETYPEID_CHR USAGEID_CHR
                        ,(SELECT usagename_vchr FROM t_bse_usagetype WHERE t_bse_usagetype.usageid_chr=A.NULLITEMDOSETYPEID_CHR) UsageName
                from T_BSE_BIH_ORDERDIC A
                where (A.ItemID_Chr is null or trim(A.ItemID_Chr)='') 
                and [FindItem] and ROWNUM<=[ROWNUM]
            ";
             */
            string strSql = @"
				select	
                        (select b.partname from ar_apply_partlist b where b.partid=a.partid_vchr) partname, 
                        (select b.sample_type_desc_vchr from  t_aid_lis_sampletype b where b.sample_type_id_chr=a.SAMPLEID_VCHR) sample_name,
                         A.PARTID_VCHR,A.SAMPLEID_VCHR,A.OrderDicID_Chr,A.Name_Chr,A.Des_VChr,A.UserCode_Chr,A.WBCode_Chr,A.PYCode_Chr,A.ExecDept_Chr,A.OrderCateID_Chr,A.ItemID_Chr 
						,B.IsRich_Int,B.ItemSpec_Vchr
						,decode(B.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPrice
						,B.Dosage_Dec,B.DosageUnit_Chr,B.ItemIpUnit_Chr UseUnit_Chr,B.USAGEID_CHR
						,(SELECT usagename_vchr FROM t_bse_usagetype WHERE t_bse_usagetype.usageid_chr=B.USAGEID_CHR) UsageName
				from T_BSE_BIH_ORDERDIC A,T_BSE_CHARGEITEM B
				where A.ItemID_Chr=B.ItemID_Chr and a.status_int=1 and b.ifstop_int=0
				and [FindItem] and ROWNUM<=[ROWNUM]
				UNION
				select  
                        (select b.partname from ar_apply_partlist b where b.partid=a.partid_vchr) partname,
                        (select b.sample_type_desc_vchr from  t_aid_lis_sampletype b where b.sample_type_id_chr=a.SAMPLEID_VCHR) sample_name,
                        A.PARTID_VCHR,A.SAMPLEID_VCHR,A.OrderDicID_Chr,A.Name_Chr,A.Des_VChr,A.UserCode_Chr,A.WBCode_Chr,A.PYCode_Chr,A.ExecDept_Chr,A.OrderCateID_Chr,A.ItemID_Chr 
                        ,null IsRich_Int,null ItemSpec_Vchr,null ItemPrice,1 Dosage_Dec
                        ,A.NULLITEMDOSAGEUNIT_CHR DosageUnit_Chr,A.NULLITEMUSEUNIT_CHR UseUnit_Chr,A.NULLITEMDOSETYPEID_CHR USAGEID_CHR
                        ,(SELECT usagename_vchr FROM t_bse_usagetype WHERE t_bse_usagetype.usageid_chr=A.NULLITEMDOSETYPEID_CHR) UsageName
				from T_BSE_BIH_ORDERDIC A
				where (A.ItemID_Chr is null or trim(A.ItemID_Chr)='') and A.status_int=1
				and [FindItem] and ROWNUM<=[ROWNUM]
			";
            /*<=======================================================================*/

            string strFind = " (( LOWER(UserCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(WBCode_Chr)	 like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(PYCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(Name_Chr) like '%" + p_strFindString.ToLower().Trim() + "%')) ";
            strSql = strSql.Replace("[FindItem]", strFind);
            strSql = strSql.Replace("[ROWNUM]", m_intGetTop().ToString());

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrDic = new clsBIHOrderDic[objDT.Rows.Count];
                for (int i = 0; i < arrDic.Length; i++)
                {
                    arrDic[i] = new clsBIHOrderDic();
                    arrDic[i].m_strOrderDicID = clsConverter.ToString(objDT.Rows[i]["OrderDicID_Chr"]).Trim();
                    arrDic[i].m_strName = clsConverter.ToString(objDT.Rows[i]["Name_Chr"]).Trim();
                    arrDic[i].m_strDesc = clsConverter.ToString(objDT.Rows[i]["Des_VChr"]).Trim();
                    arrDic[i].m_strUserCode = clsConverter.ToString(objDT.Rows[i]["UserCode_Chr"]).Trim();
                    arrDic[i].m_strWBCode = clsConverter.ToString(objDT.Rows[i]["WBCode_Chr"]).Trim();
                    arrDic[i].m_strPYCode = clsConverter.ToString(objDT.Rows[i]["PYCode_Chr"]).Trim();

                    arrDic[i].m_strExecDept = clsConverter.ToString(objDT.Rows[i]["ExecDept_Chr"]).Trim();
                    arrDic[i].m_strOrderCateID = clsConverter.ToString(objDT.Rows[i]["OrderCateID_Chr"]).Trim();
                    arrDic[i].m_strChargeItemID = clsConverter.ToString(objDT.Rows[i]["ItemID_Chr"]).Trim();
                    arrDic[i].m_intIsRich = clsConverter.ToInt(objDT.Rows[i]["IsRich_Int"]);

                    arrDic[i].m_strSpec = clsConverter.ToString(objDT.Rows[i]["ItemSpec_Vchr"]).Trim();//
                    arrDic[i].m_dmlPrice = clsConverter.ToDecimal(objDT.Rows[i]["ItemPrice"]);//住院单价
                    arrDic[i].m_dmlDosageRate = clsConverter.ToDecimal(objDT.Rows[i]["Dosage_Dec"]);//剂量

                    arrDic[i].m_strDosageUnit = clsConverter.ToString(objDT.Rows[i]["DosageUnit_Chr"]).Trim();//剂量单位
                    arrDic[i].m_strUseUnit = clsConverter.ToString(objDT.Rows[i]["UseUnit_Chr"]).Trim();//项目住院单位(最小单位)
                    arrDic[i].m_strUsageID_chr = clsConverter.ToString(objDT.Rows[i]["USAGEID_CHR"]).Trim();//默认用法
                    arrDic[i].m_strUsageName = clsConverter.ToString(objDT.Rows[i]["UsageName"]).Trim();//默认用法	非字段	
                    /* 加上检验样本*/
                    arrDic[i].m_strSAMPLE_NAME = clsConverter.ToString(objDT.Rows[i]["sample_name"]).Trim();
                    arrDic[i].m_strSAMPLEID_VCHR = clsConverter.ToString(objDT.Rows[i]["SAMPLEID_VCHR"]).Trim();
                    /* 加上检查部位*/
                    arrDic[i].m_strPARTID_VCHR = clsConverter.ToString(objDT.Rows[i]["PARTID_VCHR"]).Trim();
                    arrDic[i].m_strPART_NAME = clsConverter.ToString(objDT.Rows[i]["partname"]).Trim();
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }


        [AutoComplete]
        public long m_lngGetOrderDicByCode(string p_strFindString, int m_intClass, out clsBIHOrderDic[] arrDic)
        {
            arrDic = null;
            string strSql = @"
            select	
            distinct  (select b.partname from ar_apply_partlist b where b.partid=a.partid_vchr) partname, 
            (select b.sample_type_desc_vchr from  t_aid_lis_sampletype b where b.sample_type_id_chr=a.SAMPLEID_VCHR) sample_name,
            A.PARTID_VCHR,A.SAMPLEID_VCHR,A.OrderDicID_Chr,A.Name_Chr,A.Des_VChr,A.UserCode_Chr,A.WBCode_Chr,A.PYCode_Chr,A.ExecDept_Chr,A.OrderCateID_Chr,A.ItemID_Chr 
            ,B.IsRich_Int,B.ItemSpec_Vchr
            ,decode(B.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPrice
            ,B.Dosage_Dec,B.DosageUnit_Chr,B.ItemIpUnit_Chr UseUnit_Chr,B.USAGEID_CHR
            ,(SELECT usagename_vchr FROM t_bse_usagetype WHERE t_bse_usagetype.usageid_chr=B.USAGEID_CHR) UsageName
            from T_BSE_BIH_ORDERDIC A,T_BSE_CHARGEITEM B
            where A.ItemID_Chr=B.ItemID_Chr(+) and a.status_int=1 and b.ifstop_int=0 
            and (LOWER(UserCode_Chr) like ? or [FindItem] like ? ) and ROWNUM<=[ROWNUM] order by a.UserCode_Chr

            ";

            //string strFind = " (( LOWER(UserCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(WBCode_Chr)	 like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(PYCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(Name_Chr) like '%" + p_strFindString.ToLower().Trim() + "%')) ";
            string strFind = "";
            switch (m_intClass)
            {
                case -1:
                    strFind = "LOWER(PYCode_Chr)";
                    break;
                case 0:
                    strFind = "LOWER(PYCode_Chr)";
                    break;
                case 1:
                    strFind = "LOWER(WBCode_Chr)";
                    break;
                case 2:
                    strFind = "LOWER(Name_Chr)";
                    break;
                case 3:
                    strFind = "LOWER(UserCode_Chr)";
                    break;
            }

            strSql = strSql.Replace("[FindItem]", strFind);
            strSql = strSql.Replace("[ROWNUM]", m_intGetTop().ToString());
            strFind = p_strFindString.ToLower().Trim() + "%";
            if (m_intClass == 2)
            {
                strFind = "%" + p_strFindString.ToLower().Trim() + "%";
            }
            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);

            arrParams[0].Value = strFind;
            arrParams[1].Value = strFind;
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                ret = new clsHRPTableService().lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrDic = new clsBIHOrderDic[objDT.Rows.Count];
                for (int i = 0; i < arrDic.Length; i++)
                {
                    arrDic[i] = new clsBIHOrderDic();
                    arrDic[i].m_strOrderDicID = clsConverter.ToString(objDT.Rows[i]["OrderDicID_Chr"]).Trim();
                    arrDic[i].m_strName = clsConverter.ToString(objDT.Rows[i]["Name_Chr"]).Trim();
                    arrDic[i].m_strDesc = clsConverter.ToString(objDT.Rows[i]["Des_VChr"]).Trim();
                    arrDic[i].m_strUserCode = clsConverter.ToString(objDT.Rows[i]["UserCode_Chr"]).Trim();
                    arrDic[i].m_strWBCode = clsConverter.ToString(objDT.Rows[i]["WBCode_Chr"]).Trim();
                    arrDic[i].m_strPYCode = clsConverter.ToString(objDT.Rows[i]["PYCode_Chr"]).Trim();

                    arrDic[i].m_strExecDept = clsConverter.ToString(objDT.Rows[i]["ExecDept_Chr"]).Trim();
                    arrDic[i].m_strOrderCateID = clsConverter.ToString(objDT.Rows[i]["OrderCateID_Chr"]).Trim();
                    arrDic[i].m_strChargeItemID = clsConverter.ToString(objDT.Rows[i]["ItemID_Chr"]).Trim();
                    arrDic[i].m_intIsRich = clsConverter.ToInt(objDT.Rows[i]["IsRich_Int"]);

                    arrDic[i].m_strSpec = clsConverter.ToString(objDT.Rows[i]["ItemSpec_Vchr"]).Trim();//
                    arrDic[i].m_dmlPrice = clsConverter.ToDecimal(objDT.Rows[i]["ItemPrice"]);//住院单价
                    arrDic[i].m_dmlDosageRate = clsConverter.ToDecimal(objDT.Rows[i]["Dosage_Dec"]);//剂量

                    arrDic[i].m_strDosageUnit = clsConverter.ToString(objDT.Rows[i]["DosageUnit_Chr"]).Trim();//剂量单位
                    arrDic[i].m_strUseUnit = clsConverter.ToString(objDT.Rows[i]["UseUnit_Chr"]).Trim();//项目住院单位(最小单位)
                    arrDic[i].m_strUsageID_chr = clsConverter.ToString(objDT.Rows[i]["USAGEID_CHR"]).Trim();//默认用法
                    arrDic[i].m_strUsageName = clsConverter.ToString(objDT.Rows[i]["UsageName"]).Trim();//默认用法	非字段	
                    /* 加上检验样本*/
                    arrDic[i].m_strSAMPLE_NAME = clsConverter.ToString(objDT.Rows[i]["sample_name"]).Trim();
                    arrDic[i].m_strSAMPLEID_VCHR = clsConverter.ToString(objDT.Rows[i]["SAMPLEID_VCHR"]).Trim();
                    /* 加上检查部位*/
                    arrDic[i].m_strPARTID_VCHR = clsConverter.ToString(objDT.Rows[i]["PARTID_VCHR"]).Trim();
                    arrDic[i].m_strPART_NAME = clsConverter.ToString(objDT.Rows[i]["partname"]).Trim();
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 常用诊疗项目
        /// </summary>
        /// <param name="p_strFindString"></param>
        /// <param name="strEmpid_chr"></param>
        /// <param name="m_intClass"></param>
        /// <param name="arrDic"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCommonOrderDicByCode(string p_strFindString, string strEmpid_chr, int m_intClass, out clsBIHOrderDic[] arrDic)
        {
            arrDic = null;
            /*
            string strSql = @"
				select	
                      distinct  (select b.partname from ar_apply_partlist b where b.partid=a.partid_vchr) partname, 
                        (select b.sample_type_desc_vchr from  t_aid_lis_sampletype b where b.sample_type_id_chr=a.SAMPLEID_VCHR) sample_name,
                         A.PARTID_VCHR,A.SAMPLEID_VCHR,A.OrderDicID_Chr,A.Name_Chr,A.Des_VChr,A.UserCode_Chr,A.WBCode_Chr,A.PYCode_Chr,A.ExecDept_Chr,A.OrderCateID_Chr,A.ItemID_Chr 
						,B.IsRich_Int,B.ItemSpec_Vchr
						,decode(B.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPrice
						,B.Dosage_Dec,B.DosageUnit_Chr,B.ItemIpUnit_Chr UseUnit_Chr,B.USAGEID_CHR
						,(SELECT usagename_vchr FROM t_bse_usagetype WHERE t_bse_usagetype.usageid_chr=B.USAGEID_CHR) UsageName
				from T_BSE_BIH_ORDERDIC A,T_BSE_CHARGEITEM B,t_aid_bih_comuseorderdic C
				where A.ItemID_Chr=B.ItemID_Chr and a.status_int=1 and b.ifstop_int=0 and A.orderdicid_chr=C.orderdicid_chr and CREATERID_CHR=?
				and [FindItem] like ? 
				UNION
				select  
                        (select b.partname from ar_apply_partlist b where b.partid=a.partid_vchr) partname,
                        (select b.sample_type_desc_vchr from  t_aid_lis_sampletype b where b.sample_type_id_chr=a.SAMPLEID_VCHR) sample_name,
                        A.PARTID_VCHR,A.SAMPLEID_VCHR,A.OrderDicID_Chr,A.Name_Chr,A.Des_VChr,A.UserCode_Chr,A.WBCode_Chr,A.PYCode_Chr,A.ExecDept_Chr,A.OrderCateID_Chr,A.ItemID_Chr 
                        ,null IsRich_Int,null ItemSpec_Vchr,null ItemPrice,1 Dosage_Dec
                        ,A.NULLITEMDOSAGEUNIT_CHR DosageUnit_Chr,A.NULLITEMUSEUNIT_CHR UseUnit_Chr,A.NULLITEMDOSETYPEID_CHR USAGEID_CHR
                        ,(SELECT usagename_vchr FROM t_bse_usagetype WHERE t_bse_usagetype.usageid_chr=A.NULLITEMDOSETYPEID_CHR) UsageName
				from T_BSE_BIH_ORDERDIC A,t_aid_bih_comuseorderdic C
				where (A.ItemID_Chr is null or trim(A.ItemID_Chr)='') and A.status_int=1 and A.orderdicid_chr=C.orderdicid_chr and CREATERID_CHR=?
				and [FindItem] like ?
			";

            //string strFind = " (( LOWER(UserCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(WBCode_Chr)	 like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(PYCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(Name_Chr) like '%" + p_strFindString.ToLower().Trim() + "%')) ";
            string strFind = "";
            switch(m_intClass)
            {
                case -1:
                    strFind = "LOWER(PYCode_Chr)";
                    break;
                case 0:
                    strFind = "LOWER(PYCode_Chr)";
                    break;
                case 1:
                    strFind = "LOWER(WBCode_Chr)";
                    break;
                case 2:
                    strFind = "LOWER(Name_Chr)";
                    break;
                case 3:
                    strFind = "LOWER(UserCode_Chr)";
                    break;
            }
            
            strSql = strSql.Replace("[FindItem]", strFind);
           // strSql = strSql.Replace("[strEmpid_chr]", strEmpid_chr);
            strFind = p_strFindString.ToLower().Trim()+"%";
            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(4, out arrParams);
            arrParams[0].Value =  strEmpid_chr;
            arrParams[1].Value = strFind;
            arrParams[2].Value = strEmpid_chr;
            arrParams[3].Value = strFind;
            */

            string strSql = @"
            select	
            distinct  (select b.partname from ar_apply_partlist b where b.partid=a.partid_vchr) partname, 
            (select b.sample_type_desc_vchr from  t_aid_lis_sampletype b where b.sample_type_id_chr=a.SAMPLEID_VCHR) sample_name,
            A.PARTID_VCHR,A.SAMPLEID_VCHR,A.OrderDicID_Chr,A.Name_Chr,A.Des_VChr,A.UserCode_Chr,A.WBCode_Chr,A.PYCode_Chr,A.ExecDept_Chr,A.OrderCateID_Chr,A.ItemID_Chr 
            ,B.IsRich_Int,B.ItemSpec_Vchr
            ,decode(B.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPrice
            ,B.Dosage_Dec,B.DosageUnit_Chr,B.ItemIpUnit_Chr UseUnit_Chr,B.USAGEID_CHR
            ,(SELECT usagename_vchr FROM t_bse_usagetype WHERE t_bse_usagetype.usageid_chr=B.USAGEID_CHR) UsageName
            from T_BSE_BIH_ORDERDIC A,T_BSE_CHARGEITEM B,t_aid_bih_comuseorderdic C
            where A.ItemID_Chr=B.ItemID_Chr(+) and a.status_int=1 and b.ifstop_int=0 and A.orderdicid_chr=C.orderdicid_chr and CREATERID_CHR=?
            and (LOWER(UserCode_Chr) like ? or  [FindItem] like ?  or [FindItem] is null) order by a.UserCode_Chr

            ";

            //string strFind = " (( LOWER(UserCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(WBCode_Chr)	 like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(PYCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(Name_Chr) like '%" + p_strFindString.ToLower().Trim() + "%')) ";
            string strFind = "";
            switch (m_intClass)
            {
                case -1:
                    strFind = "LOWER(PYCode_Chr)";
                    break;
                case 0:
                    strFind = "LOWER(PYCode_Chr)";
                    break;
                case 1:
                    strFind = "LOWER(WBCode_Chr)";
                    break;
                case 2:
                    strFind = "LOWER(Name_Chr)";
                    break;
                case 3:
                    strFind = "LOWER(UserCode_Chr)";
                    break;
            }

            strSql = strSql.Replace("[FindItem]", strFind);
            // strSql = strSql.Replace("[strEmpid_chr]", strEmpid_chr);
            strFind = p_strFindString.ToLower().Trim() + "%";
            if (m_intClass == 2)
            {
                strFind = "%" + p_strFindString.ToLower().Trim() + "%";
            }
            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(3, out arrParams);
            arrParams[0].Value = strEmpid_chr;
            arrParams[1].Value = strFind;
            arrParams[2].Value = strFind;
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                ret = new clsHRPTableService().lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrDic = new clsBIHOrderDic[objDT.Rows.Count];
                for (int i = 0; i < arrDic.Length; i++)
                {
                    arrDic[i] = new clsBIHOrderDic();
                    arrDic[i].m_strOrderDicID = clsConverter.ToString(objDT.Rows[i]["OrderDicID_Chr"]).Trim();
                    arrDic[i].m_strName = clsConverter.ToString(objDT.Rows[i]["Name_Chr"]).Trim();
                    arrDic[i].m_strDesc = clsConverter.ToString(objDT.Rows[i]["Des_VChr"]).Trim();
                    arrDic[i].m_strUserCode = clsConverter.ToString(objDT.Rows[i]["UserCode_Chr"]).Trim();
                    arrDic[i].m_strWBCode = clsConverter.ToString(objDT.Rows[i]["WBCode_Chr"]).Trim();
                    arrDic[i].m_strPYCode = clsConverter.ToString(objDT.Rows[i]["PYCode_Chr"]).Trim();

                    arrDic[i].m_strExecDept = clsConverter.ToString(objDT.Rows[i]["ExecDept_Chr"]).Trim();
                    arrDic[i].m_strOrderCateID = clsConverter.ToString(objDT.Rows[i]["OrderCateID_Chr"]).Trim();
                    arrDic[i].m_strChargeItemID = clsConverter.ToString(objDT.Rows[i]["ItemID_Chr"]).Trim();
                    arrDic[i].m_intIsRich = clsConverter.ToInt(objDT.Rows[i]["IsRich_Int"]);

                    arrDic[i].m_strSpec = clsConverter.ToString(objDT.Rows[i]["ItemSpec_Vchr"]).Trim();//
                    arrDic[i].m_dmlPrice = clsConverter.ToDecimal(objDT.Rows[i]["ItemPrice"]);//住院单价
                    arrDic[i].m_dmlDosageRate = clsConverter.ToDecimal(objDT.Rows[i]["Dosage_Dec"]);//剂量

                    arrDic[i].m_strDosageUnit = clsConverter.ToString(objDT.Rows[i]["DosageUnit_Chr"]).Trim();//剂量单位
                    arrDic[i].m_strUseUnit = clsConverter.ToString(objDT.Rows[i]["UseUnit_Chr"]).Trim();//项目住院单位(最小单位)
                    arrDic[i].m_strUsageID_chr = clsConverter.ToString(objDT.Rows[i]["USAGEID_CHR"]).Trim();//默认用法
                    arrDic[i].m_strUsageName = clsConverter.ToString(objDT.Rows[i]["UsageName"]).Trim();//默认用法	非字段	
                    /* 加上检验样本*/
                    arrDic[i].m_strSAMPLE_NAME = clsConverter.ToString(objDT.Rows[i]["sample_name"]).Trim();
                    arrDic[i].m_strSAMPLEID_VCHR = clsConverter.ToString(objDT.Rows[i]["SAMPLEID_VCHR"]).Trim();
                    /* 加上检查部位*/
                    arrDic[i].m_strPARTID_VCHR = clsConverter.ToString(objDT.Rows[i]["PARTID_VCHR"]).Trim();
                    arrDic[i].m_strPART_NAME = clsConverter.ToString(objDT.Rows[i]["partname"]).Trim();
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #endregion
        #region 获取医嘱信息
        /// <summary>
        /// 获取医嘱	根据病人和医嘱状态 
        /// </summary>
        /// <param name="strRegisterID_Chr">入院登记流水号</param>
        /// <param name="strPatientID_Chr">病人ID</param>
        /// <param name="arrStatus">执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}</param>
        /// <param name="blnOnlyToday">是否仅当天的医嘱</param>
        /// <param name="intExecuteType">医嘱类型	{1长期医嘱   2临时医嘱	0所有医嘱}</param>
        /// <param name="p_blnNeedFeel">是否仅皮试医嘱</param>
        /// <param name="arrOrder">医嘱Vo对象[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByPatient(string strRegisterID, string strPatientID, int[] arrStatus, bool blnOnlyToday, int intExecuteType, bool p_blnNeedFeel, out clsBIHOrder[] arrOrder)
        {
            return m_lngGetOrderByPatient(strRegisterID, strPatientID, arrStatus, blnOnlyToday, intExecuteType, p_blnNeedFeel, "", out arrOrder);
        }

        /// <summary>
        /// 获取医嘱	根据病人和医嘱状态 --医嘱输入主界面列表用
        /// </summary>
        /// <param name="strRegisterID_Chr">入院登记流水号</param>
        /// <param name="strPatientID_Chr">病人ID</param>
        /// <param name="arrStatus">执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}</param>
        /// <param name="blnOnlyToday">是否仅当天的医嘱</param>
        /// <param name="intExecuteType">医嘱类型	{1长期医嘱   2临时医嘱	0所有医嘱}</param>
        /// <param name="p_blnNeedFeel">是否仅皮试医嘱</param>
        /// <param name="p_strOrderCateID">诊疗项目类型ID	[为空则不作为查询条件]</param>
        /// <param name="arrOrder">医嘱Vo对象[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByPatient(string strRegisterID, string strPatientID, int[] arrStatus, bool blnOnlyToday, int intExecuteType, bool p_blnNeedFeel, string strViewName, out clsBIHOrder[] arrOrder)
        {
            long lngRes = -1;
            arrOrder = null;
            /*
            string strSql = @"	
                        select A.*,B.ItemPrice,B.DosageRate,B.OrderCateID_Chr
                                ,(select REPLACE(trim(RECIPENO_INT || ' ' || NAME_VCHR),' ',' - ') from T_Opr_Bih_Order where T_Opr_Bih_Order.ORDERID_CHR = A.PARENTID_CHR) ParentName
                        from T_Opr_Bih_Order A,
                        (
                            select TA.OrderDicID_Chr,TB.Dosage_Dec DosageRate,TA.OrderCateID_Chr,TA.VIEWNAME_VCHR
                                    ,decode(TB.IPCHARGEFLG_INT,1,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4),0,TB.ItemPrice_Mny,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4)) ItemPrice 
                            from (SELECT a.*, b.viewname_vchr
                                  FROM t_bse_bih_orderdic a, t_aid_bih_ordercate b
                                  WHERE a.ordercateid_chr = b.ordercateid_chr
                                 ) TA,T_BSE_ChargeItem TB
                            where TA.ItemID_chr=TB.itemid_chr(+)
                        ) B
                        where A.OrderDicID_Chr=B.OrderDicID_Chr(+) and  Status_Int in ([StatusArr]) 
                        and Trim(RegisterID_Chr)='[RegIDValue]' and Trim(PatientID_Chr)='[PatIDValue]' 
                        [OnlyTodayCondition]
                        [ExecuteTypeCondition]
                        [NeedFeelCondition]
                        [OrderCateIDCondition]
                        order by a.recipeno_int,a.parentid_chr desc,a.createdate_dat 
            ";
            */
            string strSql = @"	
					  select k.*,a.INSURACEDESC_VCHR MedicareTypeName from
                     (	
                       select d.partname,c.sample_type_desc_vchr,a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr,b.viewname_vchr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,t_aid_lis_sampletype c, ar_apply_partlist d ,
						(
							select ta.orderdicid_chr,tb.dosage_dec dosagerate,ta.ordercateid_chr,ta.viewname_vchr
									,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice 
							from (select a.orderdicid_chr, a.name_chr, a.des_vchr, a.usercode_chr, a.wbcode_chr, a.pycode_chr, a.execdept_chr, 
	a.ordercateid_chr, a.itemid_chr, a.nullitemdosageunit_chr, a.nullitemuseunit_chr, a.nullitemdosetypeid_chr, 
	a.status_int, a.sampleid_vchr, a.partid_vchr, a.engname_vchr, a.commname_vchr, a.nullitemfreqid_vchr, 
	a.nullitemuse_dec, a.lisapplyunitid_chr, a.applytypeid_chr, a.newchargetype_int, a.opexecdept_chr, b.viewname_vchr
								  from t_bse_bih_orderdic a, t_aid_bih_ordercate b
								  where a.ordercateid_chr = b.ordercateid_chr
								 ) ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.SAMPLEID_VCHR=c.SAMPLE_TYPE_ID_CHR(+)
                        and a.partid_vchr=d.partid(+)
                        and A.OrderDicID_Chr=B.OrderDicID_Chr(+) and  Status_Int in ([StatusArr]) 
						and Trim(RegisterID_Chr)='[RegIDValue]' 
						[OnlyTodayCondition]
						[ExecuteTypeCondition]
						[NeedFeelCondition]
						[OrderCateIDCondition]
						
                    ) k,
T_OPR_BIH_ORDERCHARGEDEPT a,
t_bse_bih_orderdic b
where k.orderid_chr=a.ORDERID_CHR(+)
and k.ORDERDICID_CHR=b.ORDERDICID_CHR(+)
and a.CHARGEITEMID_CHR=b.ITEMID_CHR
order by k.recipeno_int,k.PARENTID_CHR desc,k.ORDERID_CHR
			";
            /*<====================================================================*/

            #region 条件
            //状态条件
            if ((arrStatus == null) || (arrStatus.Length == 0))
            {
                arrOrder = new clsBIHOrder[0];
                return 1;
            }

            string strStatusArr = "";
            for (int i = 0; i < arrStatus.Length; i++)
            {
                if (i > 0) strStatusArr += ",";
                strStatusArr += arrStatus[i].ToString();
            }

            strSql = strSql.Replace("[StatusArr]", strStatusArr);
            strSql = strSql.Replace("[RegIDValue]", strRegisterID);
            //strSql = strSql.Replace("[PatIDValue]", strPatientID);

            //是否当天
            if (blnOnlyToday)
            {
                string strNow = DateTime.Now.ToString("yyyy-MM-dd");
                string strStart = strNow + " 0:0:0";
                string strEnd = strNow + " 23:59:59";
                strSql = strSql.Replace("[OnlyTodayCondition]", "  and ( CreateDate_Dat between to_date('" + strStart + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEnd + "','yyyy-mm-dd hh24:mi:ss')  ) ");
            }
            else
            {
                strSql = strSql.Replace("[OnlyTodayCondition]", "");
            }
            //医嘱类型
            if (intExecuteType == 1)
            {
                strSql = strSql.Replace("[ExecuteTypeCondition]", " and A.ExecuteType_Int=1 ");		//长期
            }
            else if (intExecuteType == 2)
            {
                strSql = strSql.Replace("[ExecuteTypeCondition]", " and A.ExecuteType_Int=2 ");		//临时
            }
            else
            {
                strSql = strSql.Replace("[ExecuteTypeCondition]", "");		//所有
            }
            //皮试
            if (p_blnNeedFeel)
                strSql = strSql.Replace("[NeedFeelCondition]", "  and A.IsNeedFeeL=1 ");
            else
                strSql = strSql.Replace("[NeedFeelCondition]", "");
            //诊疗项目类型ID
            if (strViewName.Trim() != "" && strViewName.Trim() != "全部")
                strSql = strSql.Replace("[OrderCateIDCondition]", "  and Trim(B.VIEWNAME_VCHR)='" + strViewName.Trim() + "' ");
            else
                strSql = strSql.Replace("[OrderCateIDCondition]", "");
            #endregion

            try
            {
                clsHRPTableService HRPService = new clsHRPTableService();
                DataTable objDT = new DataTable();
                lngRes = 0;
                lngRes = HRPService.DoGetDataTable(strSql, ref objDT);
                if ((lngRes > 0) && (objDT != null) && objDT.Rows.Count > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngGetOrderArrFromDataTable(objDT, out arrOrder);
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

        /// <summary>
        /// 获取医嘱	根据病人和医嘱状态 
        /// 父医嘱业务说明：	
        ///				不属于其他医嘱的子医嘱;
        ///				状态要求:	0-创建;1-提交;2-执行;7-退回;
        /// 注意：		这里所获得的医嘱都是非子级医嘱的医嘱
        /// </summary>
        /// <param name="strRegisterID_Chr">入院登记流水号</param>
        /// <param name="strPatientID_Chr">病人ID</param>
        /// <param name="arrOrder">医嘱Vo对象[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByPatient(string strRegisterID, string strPatientID, out clsBIHOrder[] arrOrder)
        {
            long lngRes = -1;
            arrOrder = null;
            string strSql = @"	
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr ,tb.dosage_dec dosagerate,ta.ordercateid_chr
									,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b4
						where a.orderdicid_chr=b.orderdicid_chr(+)
						and (status_int=0 or status_int=1 or status_int=2 or status_int=7)
						and (a.parentid_chr is null or trim(a.parentid_chr)='')
						and Trim(RegisterID_Chr)='[RegIDValue]' and Trim(PatientID_Chr)='[PatIDValue]'
						order by a.recipeno_int,a.parentid_chr desc,a.createdate_dat 
			";

            strSql = strSql.Replace("[RegIDValue]", strRegisterID);
            strSql = strSql.Replace("[PatIDValue]", strPatientID);

            try
            {
                DataTable objDT = new DataTable();
                lngRes = 0;
                lngRes = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                if ((lngRes > 0) && (objDT != null) && objDT.Rows.Count > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngGetOrderArrFromDataTable(objDT, out arrOrder);
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
        /// <summary>
        /// 获取当前未停的长期医嘱	根据入院登记ID	
        /// 业务说明: {类型=1-长期; 执行状态=1-提交;2-执行;5- 已审核提交;}
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResultArr">医嘱Vo对象[out 参数]</param>
        /// <returns></returns>
        /// <remark>
        /// 执行类型	{1=长期;2=临时;}
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// </remark>
        [AutoComplete]
        public long m_lngGetNotStopLongOrderByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsBIHOrder[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSql = @"	
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr ,tb.dosage_dec dosagerate,ta.ordercateid_chr
									,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.orderdicid_chr=b.orderdicid_chr(+) 
						and  status_int in (1,2,5) and executetype_int=1 
						and ((stoperid_chr is null) or (stopdate_dat is null))
						and Trim(RegisterID_Chr)='[REGISTERIDVALUE]'
			";

            strSql = strSql.Replace("[REGISTERIDVALUE]", p_strRegisterID);
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngGetOrderArrFromDataTable(dtbResult, out p_objResultArr);
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
        /// <summary>
        /// 获取当前未停[审核]的长期医嘱	根据入院登记ID	
        /// 业务说明: {类型=1-长期; 执行状态=1-提交;2-执行;3-停止;5- 已审核提交;}
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResultArr">医嘱Vo对象[out 参数]</param>
        /// <returns></returns>
        /// <remark>
        /// 执行类型	{1=长期;2=临时;}
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// </remark>
        [AutoComplete]
        public long m_lngGetNotStopLongOrderByRegisterID2(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsBIHOrder[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSql = @"	
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr ,tb.dosage_dec dosagerate,ta.ordercateid_chr
									,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.orderdicid_chr=b.orderdicid_chr(+) 
						and  status_int in (1,2,3,5) and executetype_int=1 
						and ((stoperid_chr is null) or (stopdate_dat is null))
						and Trim(RegisterID_Chr)='[REGISTERIDVALUE]'
			";

            strSql = strSql.Replace("[REGISTERIDVALUE]", p_strRegisterID);
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngGetOrderArrFromDataTable(dtbResult, out p_objResultArr);
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
        /// <summary>
        /// 获取当前未停的普通长期医嘱|已停但未审核停的连续性长嘱	根据入院登记ID	
        /// 业务说明: {类型=1-长期; 执行状态=1-提交;2-执行;5- 已审核提交;}
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResultArr">医嘱Vo对象[out 参数]</param>
        /// <returns></returns>
        /// <remark>
        /// 执行类型	{1=长期;2=临时;}
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// </remark>
        [AutoComplete]
        public long m_lngGetNotStopLongOrderByRegisterID3(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsBIHOrder[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSql = @"	
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr ,tb.dosage_dec dosagerate,ta.ordercateid_chr
									,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.orderdicid_chr=b.orderdicid_chr(+) 
						and (a.status_int in (1,2,5) or (a.status_int=3 and exists(select spec.confreqid_chr from t_bse_bih_specordercate spec where spec.confreqid_chr=a.execfreqid_chr)))
						and a.executetype_int=1 
						and ((stoperid_chr is null) or (stopdate_dat is null))
						and Trim(RegisterID_Chr)='[REGISTERIDVALUE]'
			";

            strSql = strSql.Replace("[REGISTERIDVALUE]", p_strRegisterID);
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngGetOrderArrFromDataTable(dtbResult, out p_objResultArr);
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
        /// <summary>
        /// 获取未提交的医嘱	根据病区起始和结束病床
        /// </summary>
        /// <param name="strAreaID">病区ID</param>
        /// <param name="strBedBegin"></param>
        /// <param name="strBedEnd"></param>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrder(string strAreaID, string strBedBegin, string strBedEnd, out clsBIHOrder[] arrOrder)
        {
            arrOrder = new clsBIHOrder[0];

            string strSql = @"
				select TA.RegisterID_Chr,TB.BedID_Chr,TB.Code_Chr BedName 
					from T_Opr_Bih_Register TA,T_BSE_Bed TB
					where TA.AreaID_Chr=TB.AreaID_Chr and TA.BedID_Chr=TB.BedID_Chr
					[PatientCondition]
				";
            string strCondition = m_strGetPatientsSQL("TB", strAreaID, strBedBegin, strBedEnd);
            strSql = strSql.Replace("[PatientCondition]", strCondition);

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (ret > 0)
            {
                if ((objDT != null) && (objDT.Rows.Count > 0))
                {
                    string strRegisterIDArr = "";

                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        string strRegID = objDT.Rows[i]["RegisterID_Chr"].ToString().Trim();
                        if (strRegID == "") continue;

                        if (strRegisterIDArr != "") strRegisterIDArr += ",";
                        strRegisterIDArr += "'" + strRegID + "'";
                    }

                    string strSql2 = @"
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr,tb.dosage_dec dosagerate,ta.ordercateid_chr
									,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice 
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.orderdicid_chr=b.orderdicid_chr(+) 
						and  (status_int = 0 or status_int = 7)
						and Trim(RegisterID_Chr) in ([RegIDArr])
						order by A.OrderID_Chr
					";
                    if (strRegisterIDArr.Trim() == "") strRegisterIDArr = "''";
                    strSql2 = strSql2.Replace("[RegIDArr]", strRegisterIDArr);
                    DataTable dt2 = new DataTable();
                    long ret2 = new clsHRPTableService().DoGetDataTable(strSql2, ref dt2);
                    if ((ret2 > 0) && (dt2 != null))
                    {
                        m_lngGetOrderArrFromDataTable(dt2, out arrOrder);
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取有效医嘱	根据父级医嘱	{不包括执行状态为“作废-1、停止3、重整4”的医嘱}
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// </summary>
        /// <param name="p_strParentID">父级医嘱ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByParentID(string p_strParentID, out clsBIHOrder[] p_objResultArr)
        {
            p_objResultArr = null;
            string strSql = @"	
					select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr ,tb.dosage_dec dosagerate,ta.ordercateid_chr
								,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.orderdicid_chr=b.orderdicid_chr(+) and  a.status_int in (0,1,2,5,7) and trim(PARENTID_CHR)='" + p_strParentID.Trim() + "' order by a.createdate_dat,a.ORDERID_CHR";
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                m_lngGetOrderArrFromDataTable(objDT, out p_objResultArr);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取有效医嘱	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByOrderID(string p_strOrderID, out clsBIHOrder p_objResult)
        {
            p_objResult = null;
            /*
            string strSql = @"	
                    select A.*,B.ItemPrice,B.DosageRate,B.OrderCateID_Chr
                                ,(select REPLACE(trim(RECIPENO_INT || ' ' || NAME_VCHR),' ',' - ') from T_Opr_Bih_Order where T_Opr_Bih_Order.ORDERID_CHR = A.PARENTID_CHR) ParentName
                        from T_Opr_Bih_Order A,
                        (
                            select TA.OrderDicID_Chr ,TB.Dosage_Dec DosageRate,TA.OrderCateID_Chr
                                ,decode(TB.IPCHARGEFLG_INT,1,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4),0,TB.ItemPrice_Mny,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4)) ItemPrice
                            from T_BSE_BIH_OrderDic TA,T_BSE_ChargeItem TB
                            where TA.ItemID_chr=TB.itemid_chr(+)
                        ) B
                        where A.OrderDicID_Chr=B.OrderDicID_Chr(+) and  A.Status_Int in (0,1,2,7) and trim(A.Orderid_Chr)='" + p_strOrderID.Trim() + "'";
             */

            string strSql = @"	
					select  d.partname,c.sample_type_desc_vchr,a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,t_aid_lis_sampletype c,ar_apply_partlist d,
						(
							select ta.orderdicid_chr ,tb.dosage_dec dosagerate,ta.ordercateid_chr
								,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.sampleid_vchr=c.sample_type_id_chr(+) and a.partid_vchr=d.partid(+) and a.orderdicid_chr=b.orderdicid_chr(+) and  a.status_int in (0,1,2,5,7) and trim(a.orderid_chr)='" + p_strOrderID.Trim() + "'";

            /*<============================================================================*/
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                clsBIHOrder[] objItemArr;
                m_lngGetOrderArrFromDataTable(objDT, out objItemArr);
                if (objItemArr != null && objItemArr.Length > 0)
                    p_objResult = objItemArr[0];
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取医嘱类型
        /// </summary>
        /// <param name="arrCate">医嘱类型Vo</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderCate(out clsBIHOrderCate[] arrCate)
        {
            string strSql = @"select ordercateid_chr, name_chr, des_vchr, sourcetable_vchr, tablepk_vchr, dllname_vchr, classname_vchr, opradd_vchr, oprupd_vchr, isattach_int, viewname_vchr, usageviewtype, dosageviewtype, createchargetype, iscontrolmoney, feqviewtype, appendviewtype_int, qtyviewtype_int, orderseq_int, usercode_vchr, autoshow_int, orderselect_int, sameorder_int, changetype_int from t_aid_bih_ordercate";
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrCate = new clsBIHOrderCate[objDT.Rows.Count];
                for (int i = 0; i < arrCate.Length; i++)
                {
                    arrCate[i] = new clsBIHOrderCate();
                    arrCate[i].m_strOrderCateID = objDT.Rows[i]["OrderCateID_Chr"].ToString().Trim();
                    arrCate[i].m_strName = objDT.Rows[i]["Name_Chr"].ToString().Trim();
                    arrCate[i].m_strDes = objDT.Rows[i]["Des_VChr"].ToString().Trim();
                    arrCate[i].m_strSourceTable = objDT.Rows[i]["SourceTable_VChr"].ToString().Trim();
                    arrCate[i].m_strTABLEPK_VCHR = objDT.Rows[i]["TABLEPK_VCHR"].ToString().Trim();
                    arrCate[i].m_strDLLNAME_VCHR = objDT.Rows[i]["DLLNAME_VCHR"].ToString().Trim();
                    arrCate[i].m_strCLASSNAME_VCHR = objDT.Rows[i]["CLASSNAME_VCHR"].ToString().Trim();
                    arrCate[i].m_strOPRADD_VCHR = objDT.Rows[i]["OPRADD_VCHR"].ToString().Trim();
                    arrCate[i].m_strOPRUPD_VCHR = objDT.Rows[i]["OPRUPD_VCHR"].ToString().Trim();
                    try { arrCate[i].m_intISATTACH_INT = Int32.Parse(objDT.Rows[i]["ISATTACH_INT"].ToString()); }
                    catch { }
                }
                return 1;
            }
            else
            {
                arrCate = null;
                return 0;
            }
        }
        /// <summary>
        /// 获取可以重整地医嘱	根据入院登记ID	
        /// 包括:	
        ///		1、6-审核停止的长期医嘱;
        ///		2、执行状态的临时医嘱
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResultArr">[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCanReformingOrder(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsBIHOrder[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetCanReformingOrder");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSql = @"	
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr, b.itemprice, b.dosagerate, b.ordercateid_chr,
							(select replace (trim (recipeno_int || ' ' || name_vchr),' ', ' - ')
								from t_opr_bih_order
								where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
							(select ta.orderdicid_chr, tb.dosage_dec dosagerate,
									ta.ordercateid_chr,
									decode (tb.ipchargeflg_int,
											1, round (tb.itemprice_mny / tb.packqty_dec, 4),
											0, tb.itemprice_mny,
											round (tb.itemprice_mny / tb.packqty_dec, 4)
											) itemprice
								from t_bse_bih_orderdic ta, t_bse_chargeitem tb
								where ta.itemid_chr = tb.itemid_chr(+)) b
						where a.orderdicid_chr = b.orderdicid_chr(+)
						and ((a.status_int = 6 and a.executetype_int = 1) or (a.status_int = 2 and a.executetype_int = 2))
						AND TRIM (a.registerid_chr) = '[REGISTERID]'
						order by a.recipeno_int,a.parentid_chr desc,a.createdate_dat ";
            strSql = strSql.Replace("[REGISTERID]", p_strRegisterID.Trim());
            DataTable objDT = new DataTable();
            try
            {
                lngRes = 0;
                lngRes = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                if (lngRes > 0 && objDT.Rows.Count > 0)
                {
                    m_lngGetOrderArrFromDataTable(objDT, out p_objResultArr);
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
        /// <summary>
        /// 获取可以停止的医嘱	根据入院登记ID	
        /// 业务说明:	只有状态为	2-执行  长期医嘱
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResultArr">[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCanStopOrder(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsBIHOrder[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderNotCommit");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSql = @"	
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr, b.itemprice, b.dosagerate, b.ordercateid_chr,
							(select replace (trim (recipeno_int || ' ' || name_vchr),' ', ' - ')
								from t_opr_bih_order
								where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
							(select ta.orderdicid_chr, tb.dosage_dec dosagerate,
									ta.ordercateid_chr,
									decode (tb.ipchargeflg_int,
											1, round (tb.itemprice_mny / tb.packqty_dec, 4),
											0, tb.itemprice_mny,
											round (tb.itemprice_mny / tb.packqty_dec, 4)
											) itemprice
								from t_bse_bih_orderdic ta, t_bse_chargeitem tb
								where ta.itemid_chr = tb.itemid_chr(+)) b
						where a.orderdicid_chr = b.orderdicid_chr(+)
						and (a.status_int = 2)
						and (a.executetype_int = 1)
						AND TRIM (a.registerid_chr) = '[REGISTERID]'
						order by a.recipeno_int,a.parentid_chr desc,a.createdate_dat ";
            strSql = strSql.Replace("[REGISTERID]", p_strRegisterID.Trim());
            DataTable objDT = new DataTable();
            try
            {
                lngRes = 0;
                lngRes = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                if (lngRes > 0 && objDT.Rows.Count > 0)
                {
                    m_lngGetOrderArrFromDataTable(objDT, out p_objResultArr);
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
        /// <summary>
        /// 获取未提交的医嘱	根据病区起始和结束病床
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedBeginNO">起始床位号</param>
        /// <param name="p_strBedEndNO">结束床位号</param>
        /// <param name="p_objCommitOrderArr">提交医嘱对象</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderCommit(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, string p_strBedBeginNO, string p_strBedEndNO, out clsCommitOrder[] p_objCommitOrderArr)
        {
            p_objCommitOrderArr = new clsCommitOrder[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderNotCommit");
            if (lngRes < 0)
            {
                return -1;
            }
            string strGetRegisterIDSQL = @"select TA.RegisterID_Chr from T_Opr_Bih_Register TA,T_BSE_Bed TB where TA.AreaID_Chr=TB.AreaID_Chr and TA.BedID_Chr=TB.BedID_Chr [PatientCondition]";
            string strCondition = m_strGetPatientsSQL("TB", p_strAreaID, p_strBedBeginNO, p_strBedEndNO);
            strGetRegisterIDSQL = strGetRegisterIDSQL.Replace("[PatientCondition]", strCondition);

            string strSQL = @"
						select	 a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
								,(select bedid_chr from t_opr_bih_register where t_opr_bih_register.registerid_chr=a.registerid_chr) bedid
								,(select code_chr from t_bse_bed where trim(t_bse_bed.bedid_chr)=(select bedid_chr from t_opr_bih_register where t_opr_bih_register.registerid_chr=a.registerid_chr)) bedname
								,(select name_vchr from t_bse_patient where trim(t_bse_patient.patientid_chr)=trim(a.patientid_chr)) patientname 
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr,tb.dosage_dec dosagerate,ta.ordercateid_chr
								,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice 									
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.orderdicid_chr=b.orderdicid_chr(+) 
						and (status_int = 0 or status_int = 7)
						AND Trim(A.RegisterID_Chr) IN ([GetRegisterIDSQL])
						ORDER BY A.RegisterID_Chr,Recipeno_Int,a.parentid_chr desc
					";
            strSQL = strSQL.Replace("[GetRegisterIDSQL]", strGetRegisterIDSQL);
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objCommitOrderArr = new clsCommitOrder[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objCommitOrderArr.Length; i++)
                    {
                        p_objCommitOrderArr[i] = new clsCommitOrder();

                        p_objCommitOrderArr[i].m_strOrderID = clsConverter.ToString(dtbResult.Rows[i]["Orderid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strOrderDicID = clsConverter.ToString(dtbResult.Rows[i]["Orderdicid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strRegisterID = clsConverter.ToString(dtbResult.Rows[i]["Registerid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPatientID = clsConverter.ToString(dtbResult.Rows[i]["Patientid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPatientName = clsConverter.ToString(dtbResult.Rows[i]["PatientName"]).Trim();
                        p_objCommitOrderArr[i].m_intExecuteType = clsConverter.ToInt(dtbResult.Rows[i]["Executetype_Int"]);
                        p_objCommitOrderArr[i].m_intRecipenNo = clsConverter.ToInt(dtbResult.Rows[i]["Recipeno_Int"]);

                        p_objCommitOrderArr[i].m_strBedID = clsConverter.ToString(dtbResult.Rows[i]["BedID"]).Trim();
                        p_objCommitOrderArr[i].m_strBedName = clsConverter.ToString(dtbResult.Rows[i]["BedName"]).Trim();

                        p_objCommitOrderArr[i].m_strName = clsConverter.ToString(dtbResult.Rows[i]["Name_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strSpec = clsConverter.ToString(dtbResult.Rows[i]["Spec_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecFreqID = clsConverter.ToString(dtbResult.Rows[i]["Execfreqid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecFreqName = clsConverter.ToString(dtbResult.Rows[i]["Execfreqname_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dmlDosage = clsConverter.ToDecimal(dtbResult.Rows[i]["Dosage_Dec"]);
                        p_objCommitOrderArr[i].m_strDosageUnit = clsConverter.ToString(dtbResult.Rows[i]["Dosageunit_Chr"]).Trim();

                        p_objCommitOrderArr[i].m_dmlUse = clsConverter.ToDecimal(dtbResult.Rows[i]["Use_Dec"]);
                        p_objCommitOrderArr[i].m_strUseunit = clsConverter.ToString(dtbResult.Rows[i]["Useunit_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dmlGet = clsConverter.ToDecimal(dtbResult.Rows[i]["Get_Dec"]);
                        p_objCommitOrderArr[i].m_strGetunit = clsConverter.ToString(dtbResult.Rows[i]["Getunit_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strDosetypeID = clsConverter.ToString(dtbResult.Rows[i]["Dosetypeid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strDosetypeName = clsConverter.ToString(dtbResult.Rows[i]["Dosetypename_Chr"]).Trim();


                        p_objCommitOrderArr[i].m_dtStartDate = clsConverter.ToDateTime(dtbResult.Rows[i]["Startdate_Dat"]);
                        p_objCommitOrderArr[i].m_dtFinishDate = clsConverter.ToDateTime(dtbResult.Rows[i]["Finishdate_Dat"]);
                        p_objCommitOrderArr[i].m_strExecDeptID = clsConverter.ToString(dtbResult.Rows[i]["Execdeptid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecDeptName = clsConverter.ToString(dtbResult.Rows[i]["Execdeptname_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strEntrust = clsConverter.ToString(dtbResult.Rows[i]["Entrust_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strParentID = clsConverter.ToString(dtbResult.Rows[i]["Parentid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strParentName = clsConverter.ToString(dtbResult.Rows[i]["ParentName"]).Trim();

                        p_objCommitOrderArr[i].m_intStatus = clsConverter.ToInt(dtbResult.Rows[i]["Status_Int"]);
                        p_objCommitOrderArr[i].m_intIsRich = clsConverter.ToInt(dtbResult.Rows[i]["Isrich_Int"]);
                        p_objCommitOrderArr[i].RateType = clsConverter.ToInt(dtbResult.Rows[i]["Ratetype_Int"]);
                        p_objCommitOrderArr[i].m_intOUTGETMEDDAYS_INT = clsConverter.ToInt(dtbResult.Rows[i]["OUTGETMEDDAYS_INT"]);
                        p_objCommitOrderArr[i].m_intIsRepare = clsConverter.ToInt(dtbResult.Rows[i]["Isrepare_Int"]);

                        p_objCommitOrderArr[i].m_strCreatorID = clsConverter.ToString(dtbResult.Rows[i]["Creatorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strCreator = clsConverter.ToString(dtbResult.Rows[i]["Creator_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtCreatedate = clsConverter.ToDateTime(dtbResult.Rows[i]["Createdate_Dat"]);

                        p_objCommitOrderArr[i].m_strPosterId = clsConverter.ToString(dtbResult.Rows[i]["Posterid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPoster = clsConverter.ToString(dtbResult.Rows[i]["Poster_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtPostdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Postdate_Dat"]);

                        p_objCommitOrderArr[i].m_strExecutorID = clsConverter.ToString(dtbResult.Rows[i]["Executorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecutor = clsConverter.ToString(dtbResult.Rows[i]["Executor_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtExecutedate = clsConverter.ToDateTime(dtbResult.Rows[i]["Executedate_Dat"]);

                        p_objCommitOrderArr[i].m_strStoperID = clsConverter.ToString(dtbResult.Rows[i]["Stoperid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strStoper = clsConverter.ToString(dtbResult.Rows[i]["Stoper_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtStopdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Stopdate_Dat"]);

                        p_objCommitOrderArr[i].m_strRetractorID = clsConverter.ToString(dtbResult.Rows[i]["Retractorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strRetractor = clsConverter.ToString(dtbResult.Rows[i]["Retractor_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtRetractdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Retractdate_Dat"]);
                        p_objCommitOrderArr[i].m_dmlPrice = clsConverter.ToDecimal(dtbResult.Rows[i]["ItemPrice"]);
                        p_objCommitOrderArr[i].m_dmlDosageRate = clsConverter.ToDecimal(dtbResult.Rows[i]["DosageRate"]);
                        p_objCommitOrderArr[i].m_strOrderDicCateID = clsConverter.ToString(dtbResult.Rows[i]["OrderCateID_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_intISNEEDFEEL = clsConverter.ToInt(dtbResult.Rows[i]["ISNEEDFEEL"]);
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
        /// <summary>
        /// 获取未提交的医嘱	根据病区起始和结束病床
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="p_objCommitOrderArr">提交医嘱对象</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderCommit(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, string p_strBedIDs, out clsCommitOrder[] p_objCommitOrderArr)
        {
            p_objCommitOrderArr = new clsCommitOrder[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderNotCommit");
            if (lngRes < 0)
            {
                return -1;
            }
            string strGetRegisterIDSQL = @"
						SELECT ta.registerid_chr 
						FROM t_opr_bih_register ta,t_bse_bed tb 
						WHERE ta.REGISTERID_CHR=tb.BIHREGISTERID_CHR AND ta.pstatus_int!=3 
							[AREAIDCONDITION]
							[BEDIDCONDITION]";
            if (p_strAreaID.Trim() != "")
            {
                strGetRegisterIDSQL = strGetRegisterIDSQL.Replace("[AREAIDCONDITION]", " AND TRIM(tb.areaid_chr)='" + p_strAreaID.Trim() + "' ");
                if (p_strBedIDs.Trim() != "")
                {
                    strGetRegisterIDSQL = strGetRegisterIDSQL.Replace("[BEDIDCONDITION]", " AND TRIM(tb.bedid_chr) IN (" + p_strBedIDs.Trim() + ")");
                }
                else
                {
                    strGetRegisterIDSQL = strGetRegisterIDSQL.Replace("[BEDIDCONDITION]", "");
                }
            }
            else
            {
                strGetRegisterIDSQL = strGetRegisterIDSQL.Replace("[AREAIDCONDITION]", "");
                strGetRegisterIDSQL = strGetRegisterIDSQL.Replace("[BEDIDCONDITION]", "");
            }

            //			string strSQL =@"
            //						select	A.*,B.ItemPrice,B.DosageRate,B.OrderCateID_Chr
            //								,(select REPLACE(trim(RECIPENO_INT || ' ' || NAME_VCHR),' ',' - ') from T_Opr_Bih_Order where T_Opr_Bih_Order.ORDERID_CHR = A.PARENTID_CHR) ParentName
            //								,(select bedid_chr from T_Opr_Bih_Register where T_Opr_Bih_Register.RegisterID_Chr=a.RegisterID_Chr) BedID
            //								,(select code_chr from t_bse_bed where Trim(t_bse_bed.bedid_chr)=(select bedid_chr from T_Opr_Bih_Register where T_Opr_Bih_Register.RegisterID_Chr=a.RegisterID_Chr)) BedName
            //								,(select Name_Vchr from T_BSE_Patient where Trim(T_BSE_Patient.PatientID_Chr)=Trim(A.PatientID_Chr)) PatientName 
            //						from T_Opr_Bih_Order A,
            //						(
            //							select TA.OrderDicID_Chr,TB.Dosage_Dec DosageRate,TA.OrderCateID_Chr
            //								,decode(TB.IPCHARGEFLG_INT,1,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4),0,TB.ItemPrice_Mny,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4)) ItemPrice 									
            //							from T_BSE_BIH_OrderDic TA,T_BSE_ChargeItem TB
            //							where TA.ItemID_chr=TB.itemid_chr(+)
            //						) B
            //						WHERE A.OrderDicID_Chr=B.OrderDicID_Chr(+) 
            //						AND (Status_Int = 0 OR Status_Int = 7)
            //						AND Trim(A.RegisterID_Chr) IN ([GetRegisterIDSQL])
            //						ORDER BY A.RegisterID_Chr,Recipeno_Int,a.parentid_chr desc
            //					";

            /*
            string strSQL = @"SELECT   a.*, b.itemprice, b.dosagerate, b.ordercateid_chr, c.bedid_chr as bedid,
         d.code_chr AS bedname, e.name_vchr AS patientname,
         f.recipeno_int || '- ' || f.name_vchr AS parentname
    FROM t_opr_bih_order a,
         t_opr_bih_register c,
         t_bse_bed d,
         t_bse_patient e,
         t_opr_bih_order f,(select TA.OrderDicID_Chr,TB.Dosage_Dec DosageRate,TA.OrderCateID_Chr
                                ,decode(TB.IPCHARGEFLG_INT,1,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4),0,TB.ItemPrice_Mny,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4)) ItemPrice 									
                            from T_BSE_BIH_OrderDic TA,T_BSE_ChargeItem TB
                            where TA.ItemID_chr=TB.itemid_chr(+)
                        ) B
                        WHERE A.OrderDicID_Chr=B.OrderDicID_Chr(+) 
                        AND a.registerid_chr = c.registerid_chr(+)
                        AND c.bedid_chr = d.bedid_chr(+)
                        AND a.parentid_chr = f.orderid_chr(+)
                        AND c.patientid_chr = e.patientid_chr(+)
                        AND (a.Status_Int = 0 OR a.Status_Int = 7)
                        AND Trim(A.RegisterID_Chr) IN ([GetRegisterIDSQL])
                        ORDER BY A.RegisterID_Chr,A.Recipeno_Int,a.parentid_chr desc
                    ";
             */
            string strSQL = @"SELECT  a2.PARTNAME,d.AREAID_CHR,  g.DEPTID_CHR,g.DEPTNAME_VCHR,c.INPATIENTID_CHR,h.PATIENTCARDID_CHR,a.*, b.ItemID_chr, b.ITEMNAME_VCHR,b.itemprice, b.dosagerate, b.ordercateid_chr, c.bedid_chr as bedid,c.DIAGNOSE_VCHR,
         d.code_chr AS bedname, e.name_vchr AS patientname,e.sex_chr,round(months_between(sysdate,e.birth_dat)/12) year,
         f.recipeno_int || '- ' || f.name_vchr AS parentname
    FROM t_opr_bih_order a,
         t_opr_bih_register c,
         t_bse_bed d,
         t_bse_patient e,
         t_opr_bih_order f,
         t_bse_deptdesc g,
         t_bse_patientcard h,
         ar_apply_partlist a2,
          (select TA.ItemID_chr,TB.ITEMNAME_VCHR,TA.OrderDicID_Chr,TB.Dosage_Dec DosageRate,TA.OrderCateID_Chr
								,decode(TB.IPCHARGEFLG_INT,1,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4),0,TB.ItemPrice_Mny,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4)) ItemPrice 									
							from T_BSE_BIH_OrderDic TA,T_BSE_ChargeItem TB
							where TA.ItemID_chr=TB.itemid_chr(+)
						) B
						WHERE 
                        e.PATIENTID_CHR=h.PATIENTID_CHR(+)
                        and c.DEPTID_CHR=g.DEPTID_CHR(+)
                        AND A.OrderDicID_Chr=B.OrderDicID_Chr(+) 
						AND a.registerid_chr = c.registerid_chr(+)
						AND c.bedid_chr = d.bedid_chr(+)
						AND a.parentid_chr = f.orderid_chr(+)
						AND c.patientid_chr = e.patientid_chr(+)

                        and a.PARTID_VCHR=a2.PARTID(+)

						AND (a.Status_Int = 0 OR a.Status_Int = 7)
						AND Trim(A.RegisterID_Chr) IN ([GetRegisterIDSQL])
						ORDER BY A.RegisterID_Chr,A.Recipeno_Int,a.parentid_chr desc
					";
            /*<==========================================================*/
            strSQL = strSQL.Replace("[GetRegisterIDSQL]", strGetRegisterIDSQL);
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objCommitOrderArr = new clsCommitOrder[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objCommitOrderArr.Length; i++)
                    {
                        #region 填充
                        p_objCommitOrderArr[i] = new clsCommitOrder();

                        p_objCommitOrderArr[i].m_strOrderID = clsConverter.ToString(dtbResult.Rows[i]["Orderid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strOrderDicID = clsConverter.ToString(dtbResult.Rows[i]["Orderdicid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strRegisterID = clsConverter.ToString(dtbResult.Rows[i]["Registerid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPatientID = clsConverter.ToString(dtbResult.Rows[i]["Patientid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPatientName = clsConverter.ToString(dtbResult.Rows[i]["PatientName"]).Trim();
                        p_objCommitOrderArr[i].m_intExecuteType = clsConverter.ToInt(dtbResult.Rows[i]["Executetype_Int"]);
                        p_objCommitOrderArr[i].m_intRecipenNo = clsConverter.ToInt(dtbResult.Rows[i]["Recipeno_Int"]);

                        p_objCommitOrderArr[i].m_strBedID = clsConverter.ToString(dtbResult.Rows[i]["BedID"]).Trim();
                        p_objCommitOrderArr[i].m_strBedName = clsConverter.ToString(dtbResult.Rows[i]["BedName"]).Trim();

                        p_objCommitOrderArr[i].m_strName = clsConverter.ToString(dtbResult.Rows[i]["Name_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strSpec = clsConverter.ToString(dtbResult.Rows[i]["Spec_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecFreqID = clsConverter.ToString(dtbResult.Rows[i]["Execfreqid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecFreqName = clsConverter.ToString(dtbResult.Rows[i]["Execfreqname_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dmlDosage = clsConverter.ToDecimal(dtbResult.Rows[i]["Dosage_Dec"]);
                        p_objCommitOrderArr[i].m_strDosageUnit = clsConverter.ToString(dtbResult.Rows[i]["Dosageunit_Chr"]).Trim();

                        p_objCommitOrderArr[i].m_dmlUse = clsConverter.ToDecimal(dtbResult.Rows[i]["Use_Dec"]);
                        p_objCommitOrderArr[i].m_strUseunit = clsConverter.ToString(dtbResult.Rows[i]["Useunit_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dmlGet = clsConverter.ToDecimal(dtbResult.Rows[i]["Get_Dec"]);
                        p_objCommitOrderArr[i].m_strGetunit = clsConverter.ToString(dtbResult.Rows[i]["Getunit_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strDosetypeID = clsConverter.ToString(dtbResult.Rows[i]["Dosetypeid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strDosetypeName = clsConverter.ToString(dtbResult.Rows[i]["Dosetypename_Chr"]).Trim();


                        p_objCommitOrderArr[i].m_dtStartDate = clsConverter.ToDateTime(dtbResult.Rows[i]["Startdate_Dat"]);
                        p_objCommitOrderArr[i].m_dtFinishDate = clsConverter.ToDateTime(dtbResult.Rows[i]["Finishdate_Dat"]);
                        p_objCommitOrderArr[i].m_strExecDeptID = clsConverter.ToString(dtbResult.Rows[i]["Execdeptid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecDeptName = clsConverter.ToString(dtbResult.Rows[i]["Execdeptname_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strEntrust = clsConverter.ToString(dtbResult.Rows[i]["Entrust_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strParentID = clsConverter.ToString(dtbResult.Rows[i]["Parentid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strParentName = clsConverter.ToString(dtbResult.Rows[i]["ParentName"]).Trim();

                        p_objCommitOrderArr[i].m_intStatus = clsConverter.ToInt(dtbResult.Rows[i]["Status_Int"]);
                        p_objCommitOrderArr[i].m_intIsRich = clsConverter.ToInt(dtbResult.Rows[i]["Isrich_Int"]);
                        p_objCommitOrderArr[i].RateType = clsConverter.ToInt(dtbResult.Rows[i]["Ratetype_Int"]);
                        p_objCommitOrderArr[i].m_intOUTGETMEDDAYS_INT = clsConverter.ToInt(dtbResult.Rows[i]["OUTGETMEDDAYS_INT"]);
                        p_objCommitOrderArr[i].m_intIsRepare = clsConverter.ToInt(dtbResult.Rows[i]["Isrepare_Int"]);

                        p_objCommitOrderArr[i].m_strCreatorID = clsConverter.ToString(dtbResult.Rows[i]["Creatorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strCreator = clsConverter.ToString(dtbResult.Rows[i]["Creator_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtCreatedate = clsConverter.ToDateTime(dtbResult.Rows[i]["Createdate_Dat"]);

                        p_objCommitOrderArr[i].m_strPosterId = clsConverter.ToString(dtbResult.Rows[i]["Posterid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPoster = clsConverter.ToString(dtbResult.Rows[i]["Poster_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtPostdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Postdate_Dat"]);

                        p_objCommitOrderArr[i].m_strExecutorID = clsConverter.ToString(dtbResult.Rows[i]["Executorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecutor = clsConverter.ToString(dtbResult.Rows[i]["Executor_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtExecutedate = clsConverter.ToDateTime(dtbResult.Rows[i]["Executedate_Dat"]);

                        p_objCommitOrderArr[i].m_strStoperID = clsConverter.ToString(dtbResult.Rows[i]["Stoperid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strStoper = clsConverter.ToString(dtbResult.Rows[i]["Stoper_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtStopdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Stopdate_Dat"]);

                        p_objCommitOrderArr[i].m_strRetractorID = clsConverter.ToString(dtbResult.Rows[i]["Retractorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strRetractor = clsConverter.ToString(dtbResult.Rows[i]["Retractor_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtRetractdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Retractdate_Dat"]);
                        p_objCommitOrderArr[i].m_dmlPrice = clsConverter.ToDecimal(dtbResult.Rows[i]["ItemPrice"]);
                        p_objCommitOrderArr[i].m_dmlDosageRate = clsConverter.ToDecimal(dtbResult.Rows[i]["DosageRate"]);
                        p_objCommitOrderArr[i].m_strOrderDicCateID = clsConverter.ToString(dtbResult.Rows[i]["OrderCateID_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_intISNEEDFEEL = clsConverter.ToInt(dtbResult.Rows[i]["ISNEEDFEEL"]);
                        p_objCommitOrderArr[i].m_strsex_chr = clsConverter.ToString(dtbResult.Rows[i]["sex_chr"]).Trim();
                        p_objCommitOrderArr[i].m_strAge = clsConverter.ToString(dtbResult.Rows[i]["year"]);
                        p_objCommitOrderArr[i].m_strDIAGNOSE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["DIAGNOSE_VCHR"]).Trim();
                        p_objCommitOrderArr[i].m_strChargeITEMID_CHR = clsConverter.ToString(dtbResult.Rows[i]["ItemID_chr"]);
                        p_objCommitOrderArr[i].m_strCharegITEMName = clsConverter.ToString(dtbResult.Rows[i]["ITEMNAME_VCHR"]);
                        p_objCommitOrderArr[i].m_strINPATIENTID_CHR = clsConverter.ToString(dtbResult.Rows[i]["INPATIENTID_CHR"]);
                        p_objCommitOrderArr[i].m_strDEPTNAME_VCHR = clsConverter.ToString(dtbResult.Rows[i]["DEPTNAME_VCHR"]);
                        p_objCommitOrderArr[i].m_strDEPTID_CHR = clsConverter.ToString(dtbResult.Rows[i]["DEPTID_CHR"]);
                        p_objCommitOrderArr[i].m_strPATIENTCARDID_CHR = clsConverter.ToString(dtbResult.Rows[i]["PATIENTCARDID_CHR"]);
                        p_objCommitOrderArr[i].m_strCREATEAREA_ID = clsConverter.ToString(dtbResult.Rows[i]["AREAID_CHR"]);
                        p_objCommitOrderArr[i].m_strSAMPLEID_VCHR = clsConverter.ToString(dtbResult.Rows[i]["SAMPLEID_VCHR"]);
                        p_objCommitOrderArr[i].m_strPARTID_VCHR = clsConverter.ToString(dtbResult.Rows[i]["PARTID_VCHR"]);
                        p_objCommitOrderArr[i].m_strPARTNAME_VCHR = clsConverter.ToString(dtbResult.Rows[i]["PARTNAME"]);
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

        /// <summary>
        /// 获取未提交的医嘱	根据病区起始和结束病床及当前员工ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="CREATORID_CHR">员工ID</param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="p_objCommitOrderArr">提交医嘱对象</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderCommitByEmpID(System.Security.Principal.IPrincipal p_objPrincipal, string CREATORID_CHR, string p_strAreaID, string p_strBedIDs, out clsCommitOrder[] p_objCommitOrderArr)
        {
            p_objCommitOrderArr = new clsCommitOrder[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderNotCommit");
            if (lngRes < 0)
            {
                return -1;
            }


            //int m_intDoctorSign = 0;
            string p_strSIGN_INT = "";
            string strSQL = "";
            //strSQL="select a.setstatus_int,a.setid_chr from t_sys_setting a where a.setid_chr in ('1026')";
            try
            {
                //DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                //objHRPSvc.Dispose();
                //if (lngRes > 0 && dtbResult.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtbResult.Rows.Count; i++)
                //    {
                //        switch (dtbResult.Rows[i]["setid_chr"].ToString().TrimEnd())
                //        {

                //            case "1026":
                //                if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                //                {
                //                    m_intDoctorSign = 0;
                //                }
                //                else
                //                {
                //                    m_intDoctorSign = 1;
                //                }
                //                break;
                //        }
                //    }
                //}
                //if (m_intDoctorSign == 1)
                //{
                //    p_strSIGN_INT = " and a.SIGN_INT=1 ";
                //}

                strSQL = @"SELECT  a2.PARTNAME,d.AREAID_CHR,  g.DEPTID_CHR,g.DEPTNAME_VCHR,c.INPATIENTID_CHR,h.PATIENTCARDID_CHR,a.*, b.ItemID_chr, b.ITEMNAME_VCHR,b.itemprice, b.dosagerate, b.ordercateid_chr,b.LISAPPLYUNITID_CHR, c.bedid_chr as bedid,c.DIAGNOSE_VCHR,
         d.code_chr AS bedname, e.name_vchr AS patientname,e.sex_chr,round(months_between(sysdate,e.birth_dat)/12) year,
         f.recipeno_int || '- ' || f.name_vchr AS parentname
    FROM t_opr_bih_order a,
         t_opr_bih_register c,
         t_bse_bed d,
         t_bse_patient e,
         t_opr_bih_order f,
         t_bse_deptdesc g,
         t_bse_patientcard h,
         ar_apply_partlist a2,
          (select TA.ItemID_chr,TB.ITEMNAME_VCHR,TA.OrderDicID_Chr,TB.Dosage_Dec DosageRate,TA.OrderCateID_Chr,TA.LISAPPLYUNITID_CHR
								,decode(TB.IPCHARGEFLG_INT,1,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4),0,TB.ItemPrice_Mny,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4)) ItemPrice 									
							from T_BSE_BIH_OrderDic TA,T_BSE_ChargeItem TB
							where TA.ItemID_chr=TB.itemid_chr(+)
						) B
						WHERE 
                        e.PATIENTID_CHR=h.PATIENTID_CHR(+)
                        and c.DEPTID_CHR=g.DEPTID_CHR(+)
                        AND A.OrderDicID_Chr=B.OrderDicID_Chr(+) 
						AND a.registerid_chr = c.registerid_chr(+)
						AND c.bedid_chr = d.bedid_chr(+)
						AND a.parentid_chr = f.orderid_chr(+)
						AND c.patientid_chr = e.patientid_chr(+)

                        and a.PARTID_VCHR=a2.PARTID(+)
                        and a.CREATORID_CHR=?
						AND (a.Status_Int = 0)
					　　and c.AREAID_CHR=?
						and c.BEDID_CHR in ([CURBEDID_CHR])
                        [SIGN_INT]
						ORDER BY A.RegisterID_Chr,A.Recipeno_Int,a.parentid_chr desc
					";
                strSQL = strSQL.Replace("[CURBEDID_CHR]", p_strBedIDs);
                strSQL = strSQL.Replace("[SIGN_INT]", p_strSIGN_INT);

                DataTable dtbResult = new DataTable();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = CREATORID_CHR.Trim();
                arrParams[1].Value = p_strAreaID.Trim();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objCommitOrderArr = new clsCommitOrder[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objCommitOrderArr.Length; i++)
                    {
                        #region 填充
                        p_objCommitOrderArr[i] = new clsCommitOrder();

                        p_objCommitOrderArr[i].m_strOrderID = clsConverter.ToString(dtbResult.Rows[i]["Orderid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strOrderDicID = clsConverter.ToString(dtbResult.Rows[i]["Orderdicid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strRegisterID = clsConverter.ToString(dtbResult.Rows[i]["Registerid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPatientID = clsConverter.ToString(dtbResult.Rows[i]["Patientid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPatientName = clsConverter.ToString(dtbResult.Rows[i]["PatientName"]).Trim();
                        p_objCommitOrderArr[i].m_intExecuteType = clsConverter.ToInt(dtbResult.Rows[i]["Executetype_Int"]);
                        p_objCommitOrderArr[i].m_intRecipenNo = clsConverter.ToInt(dtbResult.Rows[i]["Recipeno_Int"]);

                        p_objCommitOrderArr[i].m_strBedID = clsConverter.ToString(dtbResult.Rows[i]["BedID"]).Trim();
                        p_objCommitOrderArr[i].m_strBedName = clsConverter.ToString(dtbResult.Rows[i]["BedName"]).Trim();

                        p_objCommitOrderArr[i].m_strName = clsConverter.ToString(dtbResult.Rows[i]["Name_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strSpec = clsConverter.ToString(dtbResult.Rows[i]["Spec_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecFreqID = clsConverter.ToString(dtbResult.Rows[i]["Execfreqid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecFreqName = clsConverter.ToString(dtbResult.Rows[i]["Execfreqname_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dmlDosage = clsConverter.ToDecimal(dtbResult.Rows[i]["Dosage_Dec"]);
                        p_objCommitOrderArr[i].m_strDosageUnit = clsConverter.ToString(dtbResult.Rows[i]["Dosageunit_Chr"]).Trim();

                        p_objCommitOrderArr[i].m_dmlUse = clsConverter.ToDecimal(dtbResult.Rows[i]["Use_Dec"]);
                        p_objCommitOrderArr[i].m_strUseunit = clsConverter.ToString(dtbResult.Rows[i]["Useunit_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dmlGet = clsConverter.ToDecimal(dtbResult.Rows[i]["Get_Dec"]);
                        p_objCommitOrderArr[i].m_strGetunit = clsConverter.ToString(dtbResult.Rows[i]["Getunit_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strDosetypeID = clsConverter.ToString(dtbResult.Rows[i]["Dosetypeid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strDosetypeName = clsConverter.ToString(dtbResult.Rows[i]["Dosetypename_Chr"]).Trim();


                        p_objCommitOrderArr[i].m_dtStartDate = clsConverter.ToDateTime(dtbResult.Rows[i]["Startdate_Dat"]);
                        p_objCommitOrderArr[i].m_dtFinishDate = clsConverter.ToDateTime(dtbResult.Rows[i]["Finishdate_Dat"]);
                        p_objCommitOrderArr[i].m_strExecDeptID = clsConverter.ToString(dtbResult.Rows[i]["Execdeptid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecDeptName = clsConverter.ToString(dtbResult.Rows[i]["Execdeptname_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strEntrust = clsConverter.ToString(dtbResult.Rows[i]["Entrust_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strParentID = clsConverter.ToString(dtbResult.Rows[i]["Parentid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strParentName = clsConverter.ToString(dtbResult.Rows[i]["ParentName"]).Trim();

                        p_objCommitOrderArr[i].m_intStatus = clsConverter.ToInt(dtbResult.Rows[i]["Status_Int"]);
                        p_objCommitOrderArr[i].m_intIsRich = clsConverter.ToInt(dtbResult.Rows[i]["Isrich_Int"]);
                        p_objCommitOrderArr[i].RateType = clsConverter.ToInt(dtbResult.Rows[i]["Ratetype_Int"]);
                        p_objCommitOrderArr[i].m_intOUTGETMEDDAYS_INT = clsConverter.ToInt(dtbResult.Rows[i]["OUTGETMEDDAYS_INT"]);
                        p_objCommitOrderArr[i].m_intIsRepare = clsConverter.ToInt(dtbResult.Rows[i]["Isrepare_Int"]);

                        p_objCommitOrderArr[i].m_strCreatorID = clsConverter.ToString(dtbResult.Rows[i]["Creatorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strCreator = clsConverter.ToString(dtbResult.Rows[i]["Creator_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtCreatedate = clsConverter.ToDateTime(dtbResult.Rows[i]["Createdate_Dat"]);

                        p_objCommitOrderArr[i].m_strPosterId = clsConverter.ToString(dtbResult.Rows[i]["Posterid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPoster = clsConverter.ToString(dtbResult.Rows[i]["Poster_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtPostdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Postdate_Dat"]);

                        p_objCommitOrderArr[i].m_strExecutorID = clsConverter.ToString(dtbResult.Rows[i]["Executorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecutor = clsConverter.ToString(dtbResult.Rows[i]["Executor_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtExecutedate = clsConverter.ToDateTime(dtbResult.Rows[i]["Executedate_Dat"]);

                        p_objCommitOrderArr[i].m_strStoperID = clsConverter.ToString(dtbResult.Rows[i]["Stoperid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strStoper = clsConverter.ToString(dtbResult.Rows[i]["Stoper_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtStopdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Stopdate_Dat"]);

                        p_objCommitOrderArr[i].m_strRetractorID = clsConverter.ToString(dtbResult.Rows[i]["Retractorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strRetractor = clsConverter.ToString(dtbResult.Rows[i]["Retractor_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtRetractdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Retractdate_Dat"]);
                        p_objCommitOrderArr[i].m_dmlPrice = clsConverter.ToDecimal(dtbResult.Rows[i]["ItemPrice"]);
                        p_objCommitOrderArr[i].m_dmlDosageRate = clsConverter.ToDecimal(dtbResult.Rows[i]["DosageRate"]);
                        p_objCommitOrderArr[i].m_strOrderDicCateID = clsConverter.ToString(dtbResult.Rows[i]["OrderCateID_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_intISNEEDFEEL = clsConverter.ToInt(dtbResult.Rows[i]["ISNEEDFEEL"]);
                        p_objCommitOrderArr[i].m_strsex_chr = clsConverter.ToString(dtbResult.Rows[i]["sex_chr"]).Trim();
                        p_objCommitOrderArr[i].m_strAge = clsConverter.ToString(dtbResult.Rows[i]["year"]);
                        p_objCommitOrderArr[i].m_strDIAGNOSE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["DIAGNOSE_VCHR"]).Trim();
                        p_objCommitOrderArr[i].m_strChargeITEMID_CHR = clsConverter.ToString(dtbResult.Rows[i]["ItemID_chr"]);
                        p_objCommitOrderArr[i].m_strCharegITEMName = clsConverter.ToString(dtbResult.Rows[i]["ITEMNAME_VCHR"]);
                        p_objCommitOrderArr[i].m_strINPATIENTID_CHR = clsConverter.ToString(dtbResult.Rows[i]["INPATIENTID_CHR"]);
                        p_objCommitOrderArr[i].m_strDEPTNAME_VCHR = clsConverter.ToString(dtbResult.Rows[i]["DEPTNAME_VCHR"]);
                        p_objCommitOrderArr[i].m_strDEPTID_CHR = clsConverter.ToString(dtbResult.Rows[i]["DEPTID_CHR"]);
                        p_objCommitOrderArr[i].m_strPATIENTCARDID_CHR = clsConverter.ToString(dtbResult.Rows[i]["PATIENTCARDID_CHR"]);
                        p_objCommitOrderArr[i].m_strCREATEAREA_ID = clsConverter.ToString(dtbResult.Rows[i]["CREATEAREAID_CHR"]);
                        p_objCommitOrderArr[i].m_strCURAREAID_CHR = clsConverter.ToString(dtbResult.Rows[i]["AREAID_CHR"]);
                        p_objCommitOrderArr[i].m_intSOURCETYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["SOURCETYPE_INT"]);
                        p_objCommitOrderArr[i].m_strSAMPLEID_VCHR = clsConverter.ToString(dtbResult.Rows[i]["SAMPLEID_VCHR"]);
                        p_objCommitOrderArr[i].m_strPARTID_VCHR = clsConverter.ToString(dtbResult.Rows[i]["PARTID_VCHR"]);
                        p_objCommitOrderArr[i].m_strPARTNAME_VCHR = clsConverter.ToString(dtbResult.Rows[i]["PARTNAME"]);
                        //检验申请单元ID(t_aid_lis_apply_unit)
                        p_objCommitOrderArr[i].m_strLISAPPLYUNITID_CHR = clsConverter.ToString(dtbResult.Rows[i]["LISAPPLYUNITID_CHR"]);

                        p_objCommitOrderArr[i].AntiUse = dtbResult.Rows[i]["AntiUse"] == DBNull.Value ? 0 : clsConverter.ToInt(dtbResult.Rows[i]["AntiUse"]);
                        p_objCommitOrderArr[i].AntiUse_YFLX = dtbResult.Rows[i]["AntiUse_yflx"] == DBNull.Value ? 0 : clsConverter.ToInt(dtbResult.Rows[i]["AntiUse_yflx"]);
                        p_objCommitOrderArr[i].CureDays = dtbResult.Rows[i]["curedays"] == DBNull.Value ? 0 : clsConverter.ToInt(dtbResult.Rows[i]["curedays"]);

                        p_objCommitOrderArr[i].IsProxyBoilMed = dtbResult.Rows[i]["isproxyboilmed"] == DBNull.Value ? 0 : clsConverter.ToInt(dtbResult.Rows[i]["isproxyboilmed"]);
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

        [AutoComplete]
        public long m_lngGetOrderCommitByOrderID(ref string strApp, string strNewDic, ref int intSampleFlag, string strOrderID)
        {
            string strSQL = "";
            long lngRes = -1;
            DataTable dt;
            try
            {
                strSQL = @"select a.status_int from t_opr_bih_order a where a.orderid_chr = ?";
                dt = new DataTable();
                int orderStatul = -1;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = strOrderID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                if (lngRes > 0)
                {
                    if (dt.Rows.Count < 0)
                    {
                        objHRPSvc.Dispose();
                        return -10;
                    }
                    orderStatul = Convert.ToInt16(dt.Rows[0][0]);
                    if (orderStatul != 0 && orderStatul != 1)
                    {
                        objHRPSvc.Dispose();
                        return -10;
                    }
                }
                if (orderStatul != 1)
                {
                    dt = new DataTable();
                    strSQL = @"select b.status_int
                              from t_opr_lis_application a, t_opr_lis_sample b
                             where a.application_id_chr = b.application_id_chr
                               and a.orderunitrelation_vchr like ? ";
                    strSQL = @"select c.status_int 
                                  from t_opr_attachrelation a
                                 inner join t_opr_lis_application b
                                    on a.attachid_vchr = b.application_id_chr
                                  left join t_opr_lis_sample c
                                    on b.application_id_chr = c.application_id_chr
                                 where a.sourceitemid_vchr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out param);
                    param[0].Value = strOrderID; //"%" + strOrderID + "%";
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                    if (lngRes > 0)
                    {
                        if (dt.Rows.Count <= 0)
                        {
                            objHRPSvc.Dispose();
                            return lngRes;
                        }
                        intSampleFlag = int.Parse(dt.Rows[0][0].ToString());
                        if (intSampleFlag != 1)
                        {
                            objHRPSvc.Dispose();
                            return lngRes;
                        }
                    }
                }
                dt = new DataTable();
                //p_objCommitOrder=new clsCommitOrder();
                strSQL = @"select ta.lisapplyunitid_chr from t_bse_bih_orderdic ta where ta.orderdicid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = strNewDic;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                if (dt.Rows.Count == 1)
                {
                    //p_objCommitOrder.m_strLISAPPLYUNITID_CHR = clsConverter.ToString(dt.Rows[0][0]);
                    strApp = dt.Rows[0]["lisapplyunitid_chr"].ToString();
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

        [AutoComplete]
        public long m_lngGetOrderCommitByEmpIDAndRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string CREATORID_CHR, string m_strRegisterID, out clsCommitOrder[] p_objCommitOrderArr)
        {
            p_objCommitOrderArr = new clsCommitOrder[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService", "m_lngGetOrderCommitByEmpIDAndRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            try
            {
                //DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();


                strSQL = @"select a2.partname,
       d.areaid_chr,
       g.deptid_chr,
       g.deptname_vchr,
       c.inpatientid_chr,
       h.patientcardid_chr,
       a.*,
       b.itemid_chr,
       b.name_chr itemname_vchr,
       b.ordercateid_chr,
       b.lisapplyunitid_chr,
       c.bedid_chr as bedid,
       c.diagnose_vchr,
       d.code_chr as bedname,
       e.lastname_vchr as patientname,
       e.sex_chr,
       e.birth_dat,
       b.applytypeid_chr
  from t_opr_bih_order          a,
       t_opr_bih_register       c,
       t_bse_bed                d,
       t_opr_bih_registerdetail e,
       t_bse_deptdesc           g,
       t_bse_patientcard        h,
       ar_apply_partlist        a2,
       t_bse_bih_orderdic       b
 where c.registerid_chr = e.registerid_chr
   and c.registerid_chr = a.registerid_chr
   and c.deptid_chr = g.deptid_chr(+)
   and c.patientid_chr = h.patientid_chr(+)
   and a.orderdicid_chr = b.orderdicid_chr(+)
   and c.bedid_chr = d.bedid_chr(+)
   and a.partid_vchr = a2.partid(+)
   and a.creatorid_chr = ?
   and a.status_int = 0 　　and a.registerid_chr = ?
 order by a.recipeno_int, a.orderid_chr";

                DataTable dtbResult = new DataTable();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = CREATORID_CHR;
                arrParams[1].Value = m_strRegisterID;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objCommitOrderArr = new clsCommitOrder[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objCommitOrderArr.Length; i++)
                    {
                        #region 填充
                        p_objCommitOrderArr[i] = new clsCommitOrder();

                        p_objCommitOrderArr[i].m_strOrderID = clsConverter.ToString(dtbResult.Rows[i]["Orderid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strOrderDicID = clsConverter.ToString(dtbResult.Rows[i]["Orderdicid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strRegisterID = clsConverter.ToString(dtbResult.Rows[i]["Registerid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPatientID = clsConverter.ToString(dtbResult.Rows[i]["Patientid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPatientName = clsConverter.ToString(dtbResult.Rows[i]["PatientName"]).Trim();
                        p_objCommitOrderArr[i].m_intExecuteType = clsConverter.ToInt(dtbResult.Rows[i]["Executetype_Int"]);
                        p_objCommitOrderArr[i].m_intRecipenNo = clsConverter.ToInt(dtbResult.Rows[i]["Recipeno_Int"]);

                        p_objCommitOrderArr[i].m_strBedID = clsConverter.ToString(dtbResult.Rows[i]["BedID"]).Trim();
                        p_objCommitOrderArr[i].m_strBedName = clsConverter.ToString(dtbResult.Rows[i]["BedName"]).Trim();

                        p_objCommitOrderArr[i].m_strName = clsConverter.ToString(dtbResult.Rows[i]["Name_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strSpec = clsConverter.ToString(dtbResult.Rows[i]["Spec_Vchr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecFreqID = clsConverter.ToString(dtbResult.Rows[i]["Execfreqid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecFreqName = clsConverter.ToString(dtbResult.Rows[i]["Execfreqname_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dmlDosage = clsConverter.ToDecimal(dtbResult.Rows[i]["Dosage_Dec"]);
                        p_objCommitOrderArr[i].m_strDosageUnit = clsConverter.ToString(dtbResult.Rows[i]["Dosageunit_Chr"]).Trim();

                        p_objCommitOrderArr[i].m_dmlUse = clsConverter.ToDecimal(dtbResult.Rows[i]["Use_Dec"]);
                        p_objCommitOrderArr[i].m_strUseunit = clsConverter.ToString(dtbResult.Rows[i]["Useunit_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dmlGet = clsConverter.ToDecimal(dtbResult.Rows[i]["Get_Dec"]);
                        p_objCommitOrderArr[i].m_strGetunit = clsConverter.ToString(dtbResult.Rows[i]["Getunit_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strDosetypeID = clsConverter.ToString(dtbResult.Rows[i]["Dosetypeid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strDosetypeName = clsConverter.ToString(dtbResult.Rows[i]["Dosetypename_Chr"]).Trim();


                        p_objCommitOrderArr[i].m_dtStartDate = clsConverter.ToDateTime(dtbResult.Rows[i]["Startdate_Dat"]);
                        p_objCommitOrderArr[i].m_dtFinishDate = clsConverter.ToDateTime(dtbResult.Rows[i]["Finishdate_Dat"]);
                        p_objCommitOrderArr[i].m_strExecDeptID = clsConverter.ToString(dtbResult.Rows[i]["Execdeptid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecDeptName = clsConverter.ToString(dtbResult.Rows[i]["Execdeptname_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strEntrust = clsConverter.ToString(dtbResult.Rows[i]["Entrust_Vchr"]).Trim();
                        //p_objCommitOrderArr[i].m_strParentID = clsConverter.ToString(dtbResult.Rows[i]["Parentid_Chr"]).Trim();
                        //p_objCommitOrderArr[i].m_strParentName = clsConverter.ToString(dtbResult.Rows[i]["ParentName"]).Trim();

                        p_objCommitOrderArr[i].m_intStatus = clsConverter.ToInt(dtbResult.Rows[i]["Status_Int"]);
                        p_objCommitOrderArr[i].m_intIsRich = clsConverter.ToInt(dtbResult.Rows[i]["Isrich_Int"]);
                        p_objCommitOrderArr[i].RateType = clsConverter.ToInt(dtbResult.Rows[i]["Ratetype_Int"]);
                        p_objCommitOrderArr[i].m_intOUTGETMEDDAYS_INT = clsConverter.ToInt(dtbResult.Rows[i]["OUTGETMEDDAYS_INT"]);
                        p_objCommitOrderArr[i].m_intIsRepare = clsConverter.ToInt(dtbResult.Rows[i]["Isrepare_Int"]);

                        p_objCommitOrderArr[i].m_strCreatorID = clsConverter.ToString(dtbResult.Rows[i]["Creatorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strCreator = clsConverter.ToString(dtbResult.Rows[i]["Creator_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtCreatedate = clsConverter.ToDateTime(dtbResult.Rows[i]["Createdate_Dat"]);

                        p_objCommitOrderArr[i].m_strPosterId = clsConverter.ToString(dtbResult.Rows[i]["Posterid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strPoster = clsConverter.ToString(dtbResult.Rows[i]["Poster_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtPostdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Postdate_Dat"]);

                        p_objCommitOrderArr[i].m_strExecutorID = clsConverter.ToString(dtbResult.Rows[i]["Executorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strExecutor = clsConverter.ToString(dtbResult.Rows[i]["Executor_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtExecutedate = clsConverter.ToDateTime(dtbResult.Rows[i]["Executedate_Dat"]);

                        p_objCommitOrderArr[i].m_strStoperID = clsConverter.ToString(dtbResult.Rows[i]["Stoperid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strStoper = clsConverter.ToString(dtbResult.Rows[i]["Stoper_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtStopdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Stopdate_Dat"]);

                        p_objCommitOrderArr[i].m_strRetractorID = clsConverter.ToString(dtbResult.Rows[i]["Retractorid_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_strRetractor = clsConverter.ToString(dtbResult.Rows[i]["Retractor_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_dtRetractdate = clsConverter.ToDateTime(dtbResult.Rows[i]["Retractdate_Dat"]);
                        //p_objCommitOrderArr[i].m_dmlPrice = clsConverter.ToDecimal(dtbResult.Rows[i]["ItemPrice"]);
                        p_objCommitOrderArr[i].m_dmlDosageRate = clsConverter.ToDecimal(dtbResult.Rows[i]["USE_DEC"]);
                        p_objCommitOrderArr[i].m_strOrderDicCateID = clsConverter.ToString(dtbResult.Rows[i]["OrderCateID_Chr"]).Trim();
                        p_objCommitOrderArr[i].m_intISNEEDFEEL = clsConverter.ToInt(dtbResult.Rows[i]["ISNEEDFEEL"]);
                        p_objCommitOrderArr[i].m_strsex_chr = clsConverter.ToString(dtbResult.Rows[i]["sex_chr"]).Trim();
                        // 修改住院采集年龄显示
                        DateTime dtebirth = Convert.ToDateTime(dtbResult.Rows[i]["birth_dat"].ToString());
                        p_objCommitOrderArr[i].m_strAge = s_strGetAge(dtebirth);

                        //p_objCommitOrderArr[i].m_strAge = clsConverter.ToString(dtbResult.Rows[i]["birth_dat"]);
                        p_objCommitOrderArr[i].m_strDIAGNOSE_VCHR = clsConverter.ToString(dtbResult.Rows[i]["DIAGNOSE_VCHR"]).Trim();
                        p_objCommitOrderArr[i].m_strChargeITEMID_CHR = clsConverter.ToString(dtbResult.Rows[i]["ItemID_chr"]);
                        p_objCommitOrderArr[i].m_strCharegITEMName = clsConverter.ToString(dtbResult.Rows[i]["ITEMNAME_VCHR"]);
                        p_objCommitOrderArr[i].m_strINPATIENTID_CHR = clsConverter.ToString(dtbResult.Rows[i]["INPATIENTID_CHR"]);
                        p_objCommitOrderArr[i].m_strDEPTNAME_VCHR = clsConverter.ToString(dtbResult.Rows[i]["DEPTNAME_VCHR"]);
                        p_objCommitOrderArr[i].m_strDEPTID_CHR = clsConverter.ToString(dtbResult.Rows[i]["DEPTID_CHR"]);
                        p_objCommitOrderArr[i].m_strPATIENTCARDID_CHR = clsConverter.ToString(dtbResult.Rows[i]["PATIENTCARDID_CHR"]);
                        p_objCommitOrderArr[i].m_strCREATEAREA_ID = clsConverter.ToString(dtbResult.Rows[i]["CREATEAREAID_CHR"]);
                        p_objCommitOrderArr[i].m_strCURAREAID_CHR = clsConverter.ToString(dtbResult.Rows[i]["AREAID_CHR"]);
                        p_objCommitOrderArr[i].m_intSOURCETYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["SOURCETYPE_INT"]);
                        p_objCommitOrderArr[i].m_strSAMPLEID_VCHR = clsConverter.ToString(dtbResult.Rows[i]["SAMPLEID_VCHR"]);
                        p_objCommitOrderArr[i].m_strPARTID_VCHR = clsConverter.ToString(dtbResult.Rows[i]["PARTID_VCHR"]);
                        p_objCommitOrderArr[i].m_strPARTNAME_VCHR = clsConverter.ToString(dtbResult.Rows[i]["PARTNAME"]);
                        //检验申请单元ID(t_aid_lis_apply_unit)
                        p_objCommitOrderArr[i].m_strLISAPPLYUNITID_CHR = clsConverter.ToString(dtbResult.Rows[i]["LISAPPLYUNITID_CHR"]);
                        p_objCommitOrderArr[i].m_strAPPLYTYPEID_CHR = clsConverter.ToString(dtbResult.Rows[i]["applytypeid_chr"]);

                        p_objCommitOrderArr[i].AntiUse = dtbResult.Rows[i]["AntiUse"] == DBNull.Value ? 0 : clsConverter.ToInt(dtbResult.Rows[i]["AntiUse"]);
                        p_objCommitOrderArr[i].AntiUse_YFLX = dtbResult.Rows[i]["AntiUse_yflx"] == DBNull.Value ? 0 : clsConverter.ToInt(dtbResult.Rows[i]["AntiUse_yflx"]);
                        p_objCommitOrderArr[i].CureDays = dtbResult.Rows[i]["curedays"] == DBNull.Value ? 0 : clsConverter.ToInt(dtbResult.Rows[i]["curedays"]);
                        p_objCommitOrderArr[i].IsProxyBoilMed = dtbResult.Rows[i]["isproxyboilmed"] == DBNull.Value ? 0 : clsConverter.ToInt(dtbResult.Rows[i]["isproxyboilmed"]);
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

        #region 私有方法
        /// <summary>
        /// 获取医嘱信息	根据DataTable
        /// </summary>
        /// <param name="objDT">DataTable</param>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngGetOrderArrFromDataTable(DataTable objDT, out clsBIHOrder[] arrOrder)
        {
            arrOrder = null;
            if (objDT == null) return 0;

            arrOrder = new clsBIHOrder[objDT.Rows.Count];
            for (int i = 0; i < arrOrder.Length; i++)
            {
                arrOrder[i] = new clsBIHOrder();

                arrOrder[i].m_strOrderID = clsConverter.ToString(objDT.Rows[i]["Orderid_Chr"]).Trim();
                arrOrder[i].m_strOrderDicID = clsConverter.ToString(objDT.Rows[i]["Orderdicid_Chr"]).Trim();
                arrOrder[i].m_strRegisterID = clsConverter.ToString(objDT.Rows[i]["Registerid_Chr"]).Trim();
                arrOrder[i].m_strPatientID = clsConverter.ToString(objDT.Rows[i]["Patientid_Chr"]).Trim();
                arrOrder[i].m_intExecuteType = clsConverter.ToInt(objDT.Rows[i]["Executetype_Int"]);
                arrOrder[i].m_intRecipenNo = clsConverter.ToInt(objDT.Rows[i]["Recipeno_Int"]);

                arrOrder[i].m_strName = clsConverter.ToString(objDT.Rows[i]["Name_Vchr"]).Trim();
                arrOrder[i].m_strSpec = clsConverter.ToString(objDT.Rows[i]["Spec_Vchr"]).Trim();
                arrOrder[i].m_strExecFreqID = clsConverter.ToString(objDT.Rows[i]["Execfreqid_Chr"]).Trim();
                arrOrder[i].m_strExecFreqName = clsConverter.ToString(objDT.Rows[i]["Execfreqname_Chr"]).Trim();
                arrOrder[i].m_dmlDosage = clsConverter.ToDecimal(objDT.Rows[i]["Dosage_Dec"]);
                arrOrder[i].m_strDosageUnit = clsConverter.ToString(objDT.Rows[i]["Dosageunit_Chr"]).Trim();

                arrOrder[i].m_dmlUse = clsConverter.ToDecimal(objDT.Rows[i]["Use_Dec"]);
                arrOrder[i].m_strUseunit = clsConverter.ToString(objDT.Rows[i]["Useunit_Chr"]).Trim();
                arrOrder[i].m_dmlGet = clsConverter.ToDecimal(objDT.Rows[i]["Get_Dec"]);
                arrOrder[i].m_strGetunit = clsConverter.ToString(objDT.Rows[i]["Getunit_Chr"]).Trim();
                arrOrder[i].m_strDosetypeID = clsConverter.ToString(objDT.Rows[i]["Dosetypeid_Chr"]).Trim();
                arrOrder[i].m_strDosetypeName = clsConverter.ToString(objDT.Rows[i]["Dosetypename_Chr"]).Trim();

                if (!objDT.Rows[i]["Startdate_Dat"].ToString().Equals(""))
                {
                    arrOrder[i].m_dtStartDate = clsConverter.ToDateTime(objDT.Rows[i]["Startdate_Dat"]);
                }
                else
                {
                    arrOrder[i].m_dtStartDate = DateTime.MinValue;
                }

                arrOrder[i].m_dtFinishDate = clsConverter.ToDateTime(objDT.Rows[i]["Finishdate_Dat"]);
                arrOrder[i].m_strExecDeptID = clsConverter.ToString(objDT.Rows[i]["Execdeptid_Chr"]).Trim();
                arrOrder[i].m_strExecDeptName = clsConverter.ToString(objDT.Rows[i]["Execdeptname_Chr"]).Trim();
                arrOrder[i].m_strEntrust = clsConverter.ToString(objDT.Rows[i]["Entrust_Vchr"]).Trim();
                arrOrder[i].m_strParentID = clsConverter.ToString(objDT.Rows[i]["Parentid_Chr"]).Trim();
                arrOrder[i].m_strParentName = clsConverter.ToString(objDT.Rows[i]["ParentName"]).Trim();

                arrOrder[i].m_intStatus = clsConverter.ToInt(objDT.Rows[i]["Status_Int"]);
                arrOrder[i].m_intIsRich = clsConverter.ToInt(objDT.Rows[i]["Isrich_Int"]);
                arrOrder[i].RateType = clsConverter.ToInt(objDT.Rows[i]["Ratetype_Int"]);
                arrOrder[i].m_intOUTGETMEDDAYS_INT = clsConverter.ToInt(objDT.Rows[i]["OUTGETMEDDAYS_INT"]);
                arrOrder[i].m_intIsRepare = clsConverter.ToInt(objDT.Rows[i]["Isrepare_Int"]);

                arrOrder[i].m_strCreatorID = clsConverter.ToString(objDT.Rows[i]["Creatorid_Chr"]).Trim();
                arrOrder[i].m_strCreator = clsConverter.ToString(objDT.Rows[i]["Creator_Chr"]).Trim();
                arrOrder[i].m_dtCreatedate = clsConverter.ToDateTime(objDT.Rows[i]["Createdate_Dat"]);

                arrOrder[i].m_strPosterId = clsConverter.ToString(objDT.Rows[i]["Posterid_Chr"]).Trim();
                arrOrder[i].m_strPoster = clsConverter.ToString(objDT.Rows[i]["Poster_Chr"]).Trim();
                arrOrder[i].m_dtPostdate = clsConverter.ToDateTime(objDT.Rows[i]["Postdate_Dat"]);

                arrOrder[i].m_strExecutorID = clsConverter.ToString(objDT.Rows[i]["Executorid_Chr"]).Trim();
                arrOrder[i].m_strExecutor = clsConverter.ToString(objDT.Rows[i]["Executor_Chr"]).Trim();
                arrOrder[i].m_dtExecutedate = clsConverter.ToDateTime(objDT.Rows[i]["Executedate_Dat"]);

                arrOrder[i].m_strStoperID = clsConverter.ToString(objDT.Rows[i]["Stoperid_Chr"]).Trim();
                arrOrder[i].m_strStoper = clsConverter.ToString(objDT.Rows[i]["Stoper_Chr"]).Trim();
                if (!objDT.Rows[i]["Stopdate_Dat"].ToString().Equals(""))
                {
                    arrOrder[i].m_dtStopdate = clsConverter.ToDateTime(objDT.Rows[i]["Stopdate_Dat"]);
                }
                else
                {
                    arrOrder[i].m_dtStopdate = DateTime.MinValue;
                }

                arrOrder[i].m_strRetractorID = clsConverter.ToString(objDT.Rows[i]["Retractorid_Chr"]).Trim();
                arrOrder[i].m_strRetractor = clsConverter.ToString(objDT.Rows[i]["Retractor_Chr"]).Trim();
                arrOrder[i].m_dtRetractdate = clsConverter.ToDateTime(objDT.Rows[i]["Retractdate_Dat"]);
                arrOrder[i].m_dmlPrice = clsConverter.ToDecimal(objDT.Rows[i]["ItemPrice"]);
                arrOrder[i].m_dmlDosageRate = clsConverter.ToDecimal(objDT.Rows[i]["DosageRate"]);
                arrOrder[i].m_strOrderDicCateID = clsConverter.ToString(objDT.Rows[i]["OrderCateID_Chr"]).Trim();
                arrOrder[i].m_intISNEEDFEEL = clsConverter.ToInt(objDT.Rows[i]["ISNEEDFEEL"]);

                // 增加检验类型信息
                if (objDT.Columns.Contains("SAMPLEID_VCHR"))
                {
                    arrOrder[i].m_strSAMPLEID_VCHR = clsConverter.ToString(objDT.Rows[i]["SAMPLEID_VCHR"]).Trim();
                }
                else
                {
                    arrOrder[i].m_strSAMPLEID_VCHR = "";
                }
                if (objDT.Columns.Contains("SAMPLE_TYPE_DESC_VCHR"))
                {
                    arrOrder[i].m_strSAMPLEName_VCHR = clsConverter.ToString(objDT.Rows[i]["SAMPLE_TYPE_DESC_VCHR"]).Trim();
                }
                else
                {
                    arrOrder[i].m_strSAMPLEName_VCHR = "";
                }
                // 增加检查部位信息
                if (objDT.Columns.Contains("PARTID_VCHR"))
                {
                    arrOrder[i].m_strPARTID_VCHR = clsConverter.ToString(objDT.Rows[i]["PARTID_VCHR"]).Trim();
                }
                else
                {
                    arrOrder[i].m_strPARTID_VCHR = "";
                }
                if (objDT.Columns.Contains("partname"))
                {
                    arrOrder[i].m_strPARTNAME_VCHR = clsConverter.ToString(objDT.Rows[i]["partname"]).Trim();
                }
                else
                {
                    arrOrder[i].m_strPARTNAME_VCHR = "";
                }
                /*<======================================================================================*/

                //已审核提交
                arrOrder[i].m_strASSESSORIDFOREXEC_CHR = clsConverter.ToString(objDT.Rows[i]["ASSESSORIDFOREXEC_CHR"]).Trim();
                arrOrder[i].m_strASSESSORFOREXEC_CHR = clsConverter.ToString(objDT.Rows[i]["ASSESSORFOREXEC_CHR"]).Trim();
                if (objDT.Rows[i]["ASSESSORFOREXEC_DAT"] != System.DBNull.Value)
                {
                    try
                    {
                        arrOrder[i].m_strASSESSORFOREXEC_DAT = Convert.ToDateTime(objDT.Rows[i]["ASSESSORFOREXEC_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    catch { }
                }
                //审核停止
                arrOrder[i].m_strASSESSORIDFORSTOP_CHR = clsConverter.ToString(objDT.Rows[i]["ASSESSORIDFORSTOP_CHR"]).Trim();
                arrOrder[i].m_strASSESSORFORSTOP_CHR = clsConverter.ToString(objDT.Rows[i]["ASSESSORFORSTOP_CHR"]).Trim();
                if (objDT.Rows[i]["ASSESSORFORSTOP_DAT"] != System.DBNull.Value)
                {
                    try
                    {
                        arrOrder[i].m_strASSESSORFORSTOP_DAT = Convert.ToDateTime(objDT.Rows[i]["ASSESSORFORSTOP_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    catch { }
                }
                //退回
                if (objDT.Rows[i]["BACKREASON"] != System.DBNull.Value)
                {
                    arrOrder[i].m_strBACKREASON = clsConverter.ToString(objDT.Rows[i]["BACKREASON"]).Trim();
                }
                if (objDT.Rows[i]["SENDBACKID_CHR"] != System.DBNull.Value)
                {
                    arrOrder[i].m_strSENDBACKID_CHR = clsConverter.ToString(objDT.Rows[i]["SENDBACKID_CHR"]).Trim();
                }
                if (objDT.Rows[i]["SENDBACKER_CHR"] != System.DBNull.Value)
                {
                    arrOrder[i].m_strSENDBACKER_CHR = clsConverter.ToString(objDT.Rows[i]["SENDBACKER_CHR"]).Trim();
                }
                if (objDT.Rows[i]["SENDBACK_DAT"] != System.DBNull.Value)
                {
                    arrOrder[i].m_strSENDBACK_DAT = clsConverter.ToString(objDT.Rows[i]["SENDBACK_DAT"]).Trim();
                }
                if (objDT.Rows[i]["isYB_int"] != System.DBNull.Value)
                {
                    arrOrder[i].isYB_int = clsConverter.ToString(objDT.Rows[i]["isYB_int"]).Trim();
                }
                /* 是否父医嘱*/
                arrOrder[i].m_intIFPARENTID_INT = clsConverter.ToInt(objDT.Rows[i]["IFPARENTID_INT"].ToString());
                arrOrder[i].m_strCREATEAREA_ID = clsConverter.ToString(objDT.Rows[i]["CREATEAREAID_CHR"].ToString());
                arrOrder[i].m_strCREATEAREA_Name = clsConverter.ToString(objDT.Rows[i]["CREATEAREANAME_VCHR"].ToString());
                /* 医嘱类型(如检查)*/
                if (objDT.Columns.Contains("viewname_vchr"))
                {
                    arrOrder[i].m_strOrderDicCateName = clsConverter.ToString(objDT.Rows[i]["viewname_vchr"].ToString());
                }
                /*  医保信息*/
                if (objDT.Columns.Contains("MedicareTypeName"))
                {
                    arrOrder[i].m_strMedicareTypeName = clsConverter.ToString(objDT.Rows[i]["MedicareTypeName"].ToString());
                }
                /* 补次次数*/
                if (objDT.Columns.Contains("ATTACHTIMES_INT"))
                {
                    arrOrder[i].m_intATTACHTIMES_INT = clsConverter.ToInt(objDT.Rows[i]["ATTACHTIMES_INT"].ToString());
                }
                /*<=============================================*/
                //医生ID
                if (objDT.Columns.Contains("DOCTORID_CHR"))
                {
                    arrOrder[i].m_strDOCTORID_CHR = clsConverter.ToString(objDT.Rows[i]["DOCTORID_CHR"].ToString());
                }
                /*<====================================*/
                //医生名称
                if (objDT.Columns.Contains("DOCTOR_VCHR"))
                {
                    arrOrder[i].m_strDOCTOR_VCHR = clsConverter.ToString(objDT.Rows[i]["DOCTOR_VCHR"].ToString());
                }
                /*<====================================*/
                //作废人ID
                if (objDT.Columns.Contains("DELETERID_CHR"))
                {
                    arrOrder[i].m_strDELETERID_CHR = clsConverter.ToString(objDT.Rows[i]["DELETERID_CHR"].ToString());
                }
                /*<====================================*/
                //作废人名
                if (objDT.Columns.Contains("DELETERNAME_VCHR"))
                {
                    arrOrder[i].m_strDELETERNAME_VCHR = clsConverter.ToString(objDT.Rows[i]["DELETERNAME_VCHR"].ToString());
                }
                /*<====================================*/
                //作废时间
                if (objDT.Columns.Contains("DELETE_DAT"))
                {
                    arrOrder[i].m_strDELETE_DAT = clsConverter.ToString(objDT.Rows[i]["DELETE_DAT"].ToString());
                }
                if (objDT.Columns.Contains("SIGN_GRP"))
                {
                    if (objDT.Rows[i]["SIGN_GRP"] != System.DBNull.Value)
                    {
                        Byte[] sign_grp = (byte[])objDT.Rows[i]["SIGN_GRP"];

                        arrOrder[i].SIGN_GRP = sign_grp;
                    }
                }
                if (objDT.Columns.Contains("SIGN_INT"))
                {
                    if (!objDT.Columns.Contains("SIGN_INT").ToString().Equals(""))
                    {
                        arrOrder[i].SIGN_INT = clsConverter.ToInt(objDT.Rows[i]["SIGN_INT"].ToString());
                    }
                }
            }
            return 1;
        }
        #endregion

        #region 通过DATATABLE转换成医嘱对象
        /// <summary>
        /// 获取医嘱信息	根据DataTable
        /// </summary>
        /// <param name="objDT">DataTable</param>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderArrFromDataTableNew(DataTable objDT, out clsBIHOrder[] arrOrder)
        {
            arrOrder = null;
            if (objDT == null) return 0;

            arrOrder = new clsBIHOrder[objDT.Rows.Count];
            for (int i = 0; i < arrOrder.Length; i++)
            {
                arrOrder[i] = new clsBIHOrder();
                DataRow objRow = objDT.Rows[i];
                arrOrder[i].m_strOrderID = clsConverter.ToString(objRow["Orderid_Chr"]).Trim();
                arrOrder[i].m_strOrderDicID = clsConverter.ToString(objRow["Orderdicid_Chr"]).Trim();
                arrOrder[i].m_strRegisterID = clsConverter.ToString(objRow["Registerid_Chr"]).Trim();
                arrOrder[i].m_strPatientID = clsConverter.ToString(objRow["Patientid_Chr"]).Trim();
                arrOrder[i].m_intExecuteType = clsConverter.ToInt(objRow["Executetype_Int"]);
                arrOrder[i].m_intRecipenNo = clsConverter.ToInt(objRow["Recipeno_Int"]);
                arrOrder[i].m_intRecipenNo2 = clsConverter.ToInt(objRow["Recipeno2_Int"]);

                arrOrder[i].m_strName = clsConverter.ToString(objRow["Name_Vchr"]).Trim();
                arrOrder[i].m_strSpec = clsConverter.ToString(objRow["Spec_Vchr"]).Trim();
                arrOrder[i].m_strExecFreqID = clsConverter.ToString(objRow["Execfreqid_Chr"]).Trim();
                arrOrder[i].m_strExecFreqName = clsConverter.ToString(objRow["Execfreqname_Chr"]).Trim();
                arrOrder[i].m_dmlDosage = clsConverter.ToDecimal(objRow["Dosage_Dec"]);
                arrOrder[i].m_strDosageUnit = clsConverter.ToString(objRow["Dosageunit_Chr"]).Trim();

                arrOrder[i].m_dmlUse = clsConverter.ToDecimal(objRow["Use_Dec"]);
                arrOrder[i].m_strUseunit = clsConverter.ToString(objRow["Useunit_Chr"]).Trim();
                arrOrder[i].m_dmlGet = clsConverter.ToDecimal(objRow["Get_Dec"]);
                arrOrder[i].m_strGetunit = clsConverter.ToString(objRow["Getunit_Chr"]).Trim();
                arrOrder[i].m_strDosetypeID = clsConverter.ToString(objRow["Dosetypeid_Chr"]).Trim();
                arrOrder[i].m_strDosetypeName = clsConverter.ToString(objRow["Dosetypename_Chr"]).Trim();

                //if (!objRow["Startdate_Dat"].ToString().Equals(""))
                //{
                //    arrOrder[i].m_dtStartDate = clsConverter.ToDateTime(objRow["Startdate_Dat"]);
                //}
                //else
                //{
                //    arrOrder[i].m_dtStartDate = DateTime.MinValue;
                //}
                arrOrder[i].m_dtStartDate = clsConverter.ToDateTime(objRow["Startdate_Dat"]);
                arrOrder[i].m_dtFinishDate = clsConverter.ToDateTime(objRow["Finishdate_Dat"]);
                arrOrder[i].m_strExecDeptID = clsConverter.ToString(objRow["Execdeptid_Chr"]).Trim();
                arrOrder[i].m_strExecDeptName = clsConverter.ToString(objRow["Execdeptname_Chr"]).Trim();
                arrOrder[i].m_strEntrust = clsConverter.ToString(objRow["Entrust_Vchr"]).Trim();
                arrOrder[i].m_strParentID = clsConverter.ToString(objRow["Parentid_Chr"]).Trim();
                if (objDT.Columns.Contains("ParentName"))
                    arrOrder[i].m_strParentName = clsConverter.ToString(objRow["ParentName"]).Trim();

                arrOrder[i].m_intStatus = clsConverter.ToInt(objRow["Status_Int"]);
                arrOrder[i].m_intIsRich = clsConverter.ToInt(objRow["Isrich_Int"]);
                arrOrder[i].RateType = clsConverter.ToInt(objRow["Ratetype_Int"]);
                arrOrder[i].m_intOUTGETMEDDAYS_INT = clsConverter.ToInt(objRow["OUTGETMEDDAYS_INT"]);
                arrOrder[i].m_intIsRepare = clsConverter.ToInt(objRow["Isrepare_Int"]);

                arrOrder[i].m_strCreatorID = clsConverter.ToString(objRow["Creatorid_Chr"]).Trim();
                arrOrder[i].m_strCreator = clsConverter.ToString(objRow["Creator_Chr"]).Trim();
                arrOrder[i].m_dtCreatedate = clsConverter.ToDateTime(objRow["Createdate_Dat"]);

                arrOrder[i].m_strPosterId = clsConverter.ToString(objRow["Posterid_Chr"]).Trim();
                arrOrder[i].m_strPoster = clsConverter.ToString(objRow["Poster_Chr"]).Trim();
                arrOrder[i].m_dtPostdate = clsConverter.ToDateTime(objRow["Postdate_Dat"]);

                arrOrder[i].m_strExecutorID = clsConverter.ToString(objRow["Executorid_Chr"]).Trim();
                arrOrder[i].m_strExecutor = clsConverter.ToString(objRow["Executor_Chr"]).Trim();
                arrOrder[i].m_dtExecutedate = clsConverter.ToDateTime(objRow["Executedate_Dat"]);

                arrOrder[i].m_strStoperID = clsConverter.ToString(objRow["Stoperid_Chr"]).Trim();
                arrOrder[i].m_strStoper = clsConverter.ToString(objRow["Stoper_Chr"]).Trim();
                //if (!objRow["Stopdate_Dat"].ToString().Equals(""))
                //{
                //    arrOrder[i].m_dtStopdate = clsConverter.ToDateTime(objRow["Stopdate_Dat"]);
                //}
                //else
                //{
                //    arrOrder[i].m_dtStopdate = DateTime.MinValue;
                //}
                arrOrder[i].m_dtStopdate = clsConverter.ToDateTime(objRow["Stopdate_Dat"]);
                arrOrder[i].m_strRetractorID = clsConverter.ToString(objRow["Retractorid_Chr"]).Trim();
                arrOrder[i].m_strRetractor = clsConverter.ToString(objRow["Retractor_Chr"]).Trim();
                arrOrder[i].m_dtRetractdate = clsConverter.ToDateTime(objRow["Retractdate_Dat"]);
                if (objDT.Columns.Contains("ItemPrice"))
                {
                    arrOrder[i].m_dmlPrice = clsConverter.ToDecimal(objRow["ItemPrice"]);
                }
                if (objDT.Columns.Contains("DosageRate"))
                {
                    arrOrder[i].m_dmlDosageRate = clsConverter.ToDecimal(objRow["DosageRate"]);
                }
                else
                {
                    arrOrder[i].m_dmlDosageRate = arrOrder[i].m_dmlUse;
                }
                arrOrder[i].m_strOrderDicCateID = clsConverter.ToString(objRow["OrderCateID_Chr"]).Trim();
                arrOrder[i].m_intISNEEDFEEL = clsConverter.ToInt(objRow["ISNEEDFEEL"]);
                arrOrder[i].m_intFEEL_INT = clsConverter.ToInt(objRow["FEEL_INT"]);
                // 增加检验类型信息
                arrOrder[i].m_strSAMPLEID_VCHR = clsConverter.ToString(objRow["SAMPLEID_VCHR"]).Trim();
                arrOrder[i].m_strSAMPLEName_VCHR = clsConverter.ToString(objRow["SAMPLE_TYPE_DESC_VCHR"]).Trim();
                // 增加检查部位信息
                arrOrder[i].m_strPARTID_VCHR = clsConverter.ToString(objRow["PARTID_VCHR"]).Trim();
                arrOrder[i].m_strPARTNAME_VCHR = clsConverter.ToString(objRow["partname"]).Trim();

                //医嘱修改者
                arrOrder[i].m_strChangedID_CHR = clsConverter.ToString(objRow["ASSESSORIDFOREXEC_CHR"]).Trim();
                arrOrder[i].m_strChangedName_CHR = clsConverter.ToString(objRow["ASSESSORFOREXEC_CHR"]).Trim();
                //if (objRow["ASSESSORFOREXEC_DAT"] != System.DBNull.Value)
                //{
                //    try
                //    {
                //        arrOrder[i].m_dtChanged_DAT = Convert.ToDateTime(objRow["ASSESSORFOREXEC_DAT"]);
                //    }
                //    catch { }
                //}
                /*<=========================*/
                arrOrder[i].m_dtChanged_DAT = clsConverter.ToDateTime(objRow["ASSESSORFOREXEC_DAT"]);
                arrOrder[i].m_strASSESSORIDFOREXEC_CHR = clsConverter.ToString(objRow["CONFIRMERID_CHR"]).Trim();
                arrOrder[i].m_strASSESSORFOREXEC_CHR = clsConverter.ToString(objRow["CONFIRMER_VCHR"]).Trim();
                //if (objRow["CONFIRM_DAT"] != System.DBNull.Value)
                //{
                //    try
                //    {
                //        arrOrder[i].m_strASSESSORFOREXEC_DAT = Convert.ToDateTime(objRow["CONFIRM_DAT"]).ToString("yyyy-MM-dd 24HH:mm:ss").Trim();
                //    }
                //    catch { }
                //}
                arrOrder[i].m_strASSESSORFOREXEC_DAT = clsConverter.ToDateTime(objRow["CONFIRM_DAT"]).ToString("yyyy-MM-dd 24HH:mm:ss").Trim();

                //审核停止
                arrOrder[i].m_strASSESSORIDFORSTOP_CHR = clsConverter.ToString(objRow["ASSESSORIDFORSTOP_CHR"]).Trim();
                arrOrder[i].m_strASSESSORFORSTOP_CHR = clsConverter.ToString(objRow["ASSESSORFORSTOP_CHR"]).Trim();
                //if (objRow["ASSESSORFORSTOP_DAT"] != System.DBNull.Value)
                //{
                //    try
                //    {
                //        arrOrder[i].m_strASSESSORFORSTOP_DAT = Convert.ToDateTime(objRow["ASSESSORFORSTOP_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                //    }
                //    catch { }
                //}

                arrOrder[i].m_strASSESSORFORSTOP_DAT = clsConverter.ToDateTime(objRow["ASSESSORFORSTOP_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                arrOrder[i].m_strBACKREASON = clsConverter.ToString(objRow["BACKREASON"]).Trim();
                arrOrder[i].m_strSENDBACKID_CHR = clsConverter.ToString(objRow["SENDBACKID_CHR"]).Trim();
                arrOrder[i].m_strSENDBACKER_CHR = clsConverter.ToString(objRow["SENDBACKER_CHR"]).Trim();
                arrOrder[i].m_strSENDBACK_DAT = clsConverter.ToString(objRow["SENDBACK_DAT"]).Trim();
                arrOrder[i].isYB_int = clsConverter.ToString(objRow["isYB_int"]).Trim();
                /* 是否父医嘱*/
                arrOrder[i].m_intIFPARENTID_INT = clsConverter.ToInt(objRow["IFPARENTID_INT"].ToString());
                arrOrder[i].m_strCREATEAREA_ID = clsConverter.ToString(objRow["CREATEAREAID_CHR"].ToString());
                arrOrder[i].m_strCREATEAREA_Name = clsConverter.ToString(objRow["CREATEAREANAME_VCHR"].ToString());
                /* 医嘱类型(如检查)*/
                if (objDT.Columns.Contains("viewname_vchr"))
                    arrOrder[i].m_strOrderDicCateName = clsConverter.ToString(objRow["viewname_vchr"].ToString());
                /*  医保信息*/
                if (objDT.Columns.Contains("MedicareTypeName"))
                    arrOrder[i].m_strMedicareTypeName = clsConverter.ToString(objRow["MedicareTypeName"].ToString());
                /* 补次次数*/
                arrOrder[i].m_intATTACHTIMES_INT = clsConverter.ToInt(objRow["ATTACHTIMES_INT"].ToString());
                arrOrder[i].m_strDOCTORID_CHR = clsConverter.ToString(objRow["DOCTORID_CHR"].ToString());
                //医生名称
                arrOrder[i].m_strDOCTOR_VCHR = clsConverter.ToString(objRow["DOCTOR_VCHR"].ToString());
                //作废人ID
                arrOrder[i].m_strDELETERID_CHR = clsConverter.ToString(objRow["DELETERID_CHR"].ToString());
                //作废人名
                arrOrder[i].m_strDELETERNAME_VCHR = clsConverter.ToString(objRow["DELETERNAME_VCHR"].ToString());
                //作废时间
                arrOrder[i].m_strDELETE_DAT = clsConverter.ToString(objRow["DELETE_DAT"].ToString());
                arrOrder[i].SIGN_INT = clsConverter.ToInt(objRow["SIGN_INT"].ToString());
                // 主收费项目ID
                if (objDT.Columns.Contains("CHARGEITEMID_CHR"))
                    arrOrder[i].m_strCHARGEITEMID_CHR = clsConverter.ToString(objRow["CHARGEITEMID_CHR"].ToString());
                // 主收费项目名称
                if (objDT.Columns.Contains("CHARGEITEMNAME_CHR"))
                    arrOrder[i].m_strCHARGEITEMNAME_CHR = clsConverter.ToString(objRow["CHARGEITEMNAME_CHR"].ToString());
                // 术后标志（0-术前，1-术后) 
                arrOrder[i].m_intOPERATION_INT = clsConverter.ToInt(objRow["OPERATION_INT"].ToString());
                // 医嘱说明
                arrOrder[i].m_strREMARK_VCHR = clsConverter.ToString(objRow["REMARK_VCHR"].ToString());
                //修改标志(0-普通状态,1-频率修改)
                arrOrder[i].m_intCHARGE_INT = clsConverter.ToInt(objRow["CHARGE_INT"].ToString());
                //医嘱归类(0-普通,1-术后医嘱,2-转科医嘱,3-出院(今日),4-出院(明日))
                arrOrder[i].m_intTYPE_INT = clsConverter.ToInt(objRow["TYPE_INT"].ToString());
                arrOrder[i].m_dmlOneUse = clsConverter.ToDecimal(objRow["SINGLEAMOUNT_DEC"].ToString());
                //检验申请单类别
                arrOrder[i].m_strLISAPPLYUNITID_CHR = clsConverter.ToString(objRow["LISAPPLYUNITID_CHR"].ToString());
                //检查申请单类别
                arrOrder[i].m_strAPPLYTYPEID_CHR = clsConverter.ToString(objRow["APPLYTYPEID_CHR"].ToString());
                //诊疗项目名称
                if (objDT.Columns.Contains("DicName"))
                {
                    arrOrder[i].m_strDicName = clsConverter.ToString(objRow["DicName"]);
                }
                //医嘱源类型(0-普通录入,1-特别科室录入)
                arrOrder[i].m_intSOURCETYPE_INT = clsConverter.ToInt(objRow["SOURCETYPE_INT"].ToString());

                arrOrder[i].AntiUse = objRow["antiuse"] == DBNull.Value ? 0 : clsConverter.ToInt(objRow["antiuse"].ToString());
                arrOrder[i].AntiUse_YFLX = objRow["antiuse_yflx"] == DBNull.Value ? 0 : clsConverter.ToInt(objRow["antiuse_yflx"].ToString());
                arrOrder[i].CureDays = objRow["curedays"] == DBNull.Value ? 0 : clsConverter.ToInt(objRow["curedays"].ToString());
                arrOrder[i].IsProxyBoilMed = objRow["isproxyboilmed"] == DBNull.Value ? 0 : clsConverter.ToInt(objRow["isproxyboilmed"].ToString());
            }
            return 1;
        }
        #endregion

        #region 通过DATATABLE转换成医嘱对象
        /// <summary>
        /// 获取医嘱信息	根据DataTable
        /// </summary>
        /// <param name="objDT">DataTable</param>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderArrFromDataTableNew2(DataTable objDT, out clsBIHOrder[] arrOrder)
        {
            arrOrder = null;
            if (objDT == null) return 0;

            arrOrder = new clsBIHOrder[objDT.Rows.Count];
            for (int i = 0; i < arrOrder.Length; i++)
            {
                arrOrder[i] = new clsBIHOrder();
                DataRow objRow = objDT.Rows[i];
                arrOrder[i].m_strOrderID = clsConverter.ToString(objRow["Orderid_Chr"]).Trim();
                arrOrder[i].m_strOrderDicID = clsConverter.ToString(objRow["Orderdicid_Chr"]).Trim();
                arrOrder[i].m_strRegisterID = clsConverter.ToString(objRow["Registerid_Chr"]).Trim();
                arrOrder[i].m_strPatientID = clsConverter.ToString(objRow["Patientid_Chr"]).Trim();
                arrOrder[i].m_intExecuteType = clsConverter.ToInt(objRow["Executetype_Int"]);
                arrOrder[i].m_intRecipenNo = clsConverter.ToInt(objRow["Recipeno_Int"]);
                arrOrder[i].m_intRecipenNo2 = clsConverter.ToInt(objRow["Recipeno2_Int"]);

                arrOrder[i].m_strName = clsConverter.ToString(objRow["Name_Vchr"]).Trim();
                arrOrder[i].m_mednormalname_vchr = clsConverter.ToString(objRow["mednormalname_vchr"]).Trim();
                arrOrder[i].m_strSpec = clsConverter.ToString(objRow["Spec_Vchr"]).Trim();
                arrOrder[i].m_strExecFreqID = clsConverter.ToString(objRow["Execfreqid_Chr"]).Trim();
                arrOrder[i].m_strExecFreqName = clsConverter.ToString(objRow["Execfreqname_Chr"]).Trim();
                arrOrder[i].m_dmlDosage = clsConverter.ToDecimal(objRow["Dosage_Dec"]);
                arrOrder[i].m_strDosageUnit = clsConverter.ToString(objRow["Dosageunit_Chr"]).Trim();
                arrOrder[i].m_intIPCHARGEFLG_INT = clsConverter.ToInt(objRow["ipchargeflg_int"]);
                arrOrder[i].m_dmlPACKQTY_DEC = clsConverter.ToDecimal(objRow["packqty_dec"]);

                arrOrder[i].m_dmlUse = clsConverter.ToDecimal(objRow["Use_Dec"]);
                arrOrder[i].m_strUseunit = clsConverter.ToString(objRow["Useunit_Chr"]).Trim();
                arrOrder[i].m_dmlGet = clsConverter.ToDecimal(objRow["Get_Dec"]);
                arrOrder[i].m_strGetunit = clsConverter.ToString(objRow["Getunit_Chr"]).Trim();
                arrOrder[i].m_strDosetypeID = clsConverter.ToString(objRow["Dosetypeid_Chr"]).Trim();
                arrOrder[i].m_strDosetypeName = clsConverter.ToString(objRow["Dosetypename_Chr"]).Trim();

                //if (!objRow["Startdate_Dat"].ToString().Equals(""))
                //{
                //    arrOrder[i].m_dtStartDate = clsConverter.ToDateTime(objRow["Startdate_Dat"]);
                //}
                //else
                //{
                //    arrOrder[i].m_dtStartDate = DateTime.MinValue;
                //}
                arrOrder[i].m_dtStartDate = clsConverter.ToDateTime(objRow["Startdate_Dat"]);
                arrOrder[i].m_dtFinishDate = clsConverter.ToDateTime(objRow["Finishdate_Dat"]);
                arrOrder[i].m_strExecDeptID = clsConverter.ToString(objRow["Execdeptid_Chr"]).Trim();
                arrOrder[i].m_strExecDeptName = clsConverter.ToString(objRow["Execdeptname_Chr"]).Trim();
                arrOrder[i].m_strEntrust = clsConverter.ToString(objRow["Entrust_Vchr"]).Trim();
                arrOrder[i].m_strParentID = clsConverter.ToString(objRow["Parentid_Chr"]).Trim();
                if (objDT.Columns.Contains("ParentName"))
                    arrOrder[i].m_strParentName = clsConverter.ToString(objRow["ParentName"]).Trim();

                arrOrder[i].m_intStatus = clsConverter.ToInt(objRow["Status_Int"]);
                arrOrder[i].m_intIsRich = clsConverter.ToInt(objRow["Isrich_Int"]);
                arrOrder[i].RateType = clsConverter.ToInt(objRow["Ratetype_Int"]);
                arrOrder[i].m_intOUTGETMEDDAYS_INT = clsConverter.ToInt(objRow["OUTGETMEDDAYS_INT"]);
                arrOrder[i].m_intIsRepare = clsConverter.ToInt(objRow["Isrepare_Int"]);

                arrOrder[i].m_strCreatorID = clsConverter.ToString(objRow["Creatorid_Chr"]).Trim();
                arrOrder[i].m_strCreator = clsConverter.ToString(objRow["Creator_Chr"]).Trim();
                arrOrder[i].m_dtCreatedate = clsConverter.ToDateTime(objRow["Createdate_Dat"]);

                arrOrder[i].m_strPosterId = clsConverter.ToString(objRow["Posterid_Chr"]).Trim();
                arrOrder[i].m_strPoster = clsConverter.ToString(objRow["Poster_Chr"]).Trim();
                arrOrder[i].m_dtPostdate = clsConverter.ToDateTime(objRow["Postdate_Dat"]);

                arrOrder[i].m_strExecutorID = clsConverter.ToString(objRow["Executorid_Chr"]).Trim();
                arrOrder[i].m_strExecutor = clsConverter.ToString(objRow["Executor_Chr"]).Trim();
                arrOrder[i].m_dtExecutedate = clsConverter.ToDateTime(objRow["Executedate_Dat"]);

                arrOrder[i].m_strStoperID = clsConverter.ToString(objRow["Stoperid_Chr"]).Trim();
                arrOrder[i].m_strStoper = clsConverter.ToString(objRow["Stoper_Chr"]).Trim();
                //if (!objRow["Stopdate_Dat"].ToString().Equals(""))
                //{
                //    arrOrder[i].m_dtStopdate = clsConverter.ToDateTime(objRow["Stopdate_Dat"]);
                //}
                //else
                //{
                //    arrOrder[i].m_dtStopdate = DateTime.MinValue;
                //}
                arrOrder[i].m_dtStopdate = clsConverter.ToDateTime(objRow["Stopdate_Dat"]);
                arrOrder[i].m_strRetractorID = clsConverter.ToString(objRow["Retractorid_Chr"]).Trim();
                arrOrder[i].m_strRetractor = clsConverter.ToString(objRow["Retractor_Chr"]).Trim();
                arrOrder[i].m_dtRetractdate = clsConverter.ToDateTime(objRow["Retractdate_Dat"]);
                if (objDT.Columns.Contains("ItemPrice"))
                {
                    arrOrder[i].m_dmlPrice = clsConverter.ToDecimal(objRow["ItemPrice"]);
                }
                if (objDT.Columns.Contains("DosageRate"))
                {
                    arrOrder[i].m_dmlDosageRate = clsConverter.ToDecimal(objRow["DosageRate"]);
                }
                else
                {
                    arrOrder[i].m_dmlDosageRate = arrOrder[i].m_dmlUse;
                }
                arrOrder[i].m_strOrderDicCateID = clsConverter.ToString(objRow["OrderCateID_Chr"]).Trim();
                arrOrder[i].m_intISNEEDFEEL = clsConverter.ToInt(objRow["ISNEEDFEEL"]);
                arrOrder[i].m_intFEEL_INT = clsConverter.ToInt(objRow["FEEL_INT"]);
                // 增加检验类型信息
                arrOrder[i].m_strSAMPLEID_VCHR = clsConverter.ToString(objRow["SAMPLEID_VCHR"]).Trim();
                arrOrder[i].m_strSAMPLEName_VCHR = clsConverter.ToString(objRow["SAMPLE_TYPE_DESC_VCHR"]).Trim();
                // 增加检查部位信息
                arrOrder[i].m_strPARTID_VCHR = clsConverter.ToString(objRow["PARTID_VCHR"]).Trim();
                arrOrder[i].m_strPARTNAME_VCHR = clsConverter.ToString(objRow["partname"]).Trim();

                //医嘱修改者
                arrOrder[i].m_strChangedID_CHR = clsConverter.ToString(objRow["ASSESSORIDFOREXEC_CHR"]).Trim();
                arrOrder[i].m_strChangedName_CHR = clsConverter.ToString(objRow["ASSESSORFOREXEC_CHR"]).Trim();
                //if (objRow["ASSESSORFOREXEC_DAT"] != System.DBNull.Value)
                //{
                //    try
                //    {
                //        arrOrder[i].m_dtChanged_DAT = Convert.ToDateTime(objRow["ASSESSORFOREXEC_DAT"]);
                //    }
                //    catch { }
                //}
                /*<=========================*/
                arrOrder[i].m_dtChanged_DAT = clsConverter.ToDateTime(objRow["ASSESSORFOREXEC_DAT"]);
                arrOrder[i].m_strASSESSORIDFOREXEC_CHR = clsConverter.ToString(objRow["CONFIRMERID_CHR"]).Trim();
                arrOrder[i].m_strASSESSORFOREXEC_CHR = clsConverter.ToString(objRow["CONFIRMER_VCHR"]).Trim();
                //if (objRow["CONFIRM_DAT"] != System.DBNull.Value)
                //{
                //    try
                //    {
                //        arrOrder[i].m_strASSESSORFOREXEC_DAT = Convert.ToDateTime(objRow["CONFIRM_DAT"]).ToString("yyyy-MM-dd 24HH:mm:ss").Trim();
                //    }
                //    catch { }
                //}
                arrOrder[i].m_strASSESSORFOREXEC_DAT = clsConverter.ToDateTime(objRow["CONFIRM_DAT"]).ToString("yyyy-MM-dd 24HH:mm:ss").Trim();

                //审核停止
                arrOrder[i].m_strASSESSORIDFORSTOP_CHR = clsConverter.ToString(objRow["ASSESSORIDFORSTOP_CHR"]).Trim();
                arrOrder[i].m_strASSESSORFORSTOP_CHR = clsConverter.ToString(objRow["ASSESSORFORSTOP_CHR"]).Trim();

                arrOrder[i].m_strASSESSORFORSTOP_DAT = clsConverter.ToDateTime(objRow["ASSESSORFORSTOP_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                arrOrder[i].m_strBACKREASON = clsConverter.ToString(objRow["BACKREASON"]).Trim();
                arrOrder[i].m_strSENDBACKID_CHR = clsConverter.ToString(objRow["SENDBACKID_CHR"]).Trim();
                arrOrder[i].m_strSENDBACKER_CHR = clsConverter.ToString(objRow["SENDBACKER_CHR"]).Trim();
                arrOrder[i].m_strSENDBACK_DAT = clsConverter.ToString(objRow["SENDBACK_DAT"]).Trim();
                arrOrder[i].isYB_int = clsConverter.ToString(objRow["isYB_int"]).Trim();
                /* 是否父医嘱*/
                arrOrder[i].m_intIFPARENTID_INT = clsConverter.ToInt(objRow["IFPARENTID_INT"].ToString());
                arrOrder[i].m_strCREATEAREA_ID = clsConverter.ToString(objRow["CREATEAREAID_CHR"].ToString());
                arrOrder[i].m_strCREATEAREA_Name = clsConverter.ToString(objRow["CREATEAREANAME_VCHR"].ToString());
                /* 医嘱类型(如检查)*/
                if (objDT.Columns.Contains("viewname_vchr"))
                    arrOrder[i].m_strOrderDicCateName = clsConverter.ToString(objRow["viewname_vchr"].ToString());
                /* 医保信息*/
                if (objDT.Columns.Contains("MedicareTypeName"))
                    arrOrder[i].m_strMedicareTypeName = clsConverter.ToString(objRow["MedicareTypeName"].ToString());
                /* 补次次数*/
                arrOrder[i].m_intATTACHTIMES_INT = clsConverter.ToInt(objRow["ATTACHTIMES_INT"].ToString());
                arrOrder[i].m_strDOCTORID_CHR = clsConverter.ToString(objRow["DOCTORID_CHR"].ToString());
                //医生名称
                arrOrder[i].m_strDOCTOR_VCHR = clsConverter.ToString(objRow["DOCTOR_VCHR"].ToString());
                //作废人ID
                arrOrder[i].m_strDELETERID_CHR = clsConverter.ToString(objRow["DELETERID_CHR"].ToString());
                //作废人名
                arrOrder[i].m_strDELETERNAME_VCHR = clsConverter.ToString(objRow["DELETERNAME_VCHR"].ToString());
                //作废时间
                arrOrder[i].m_strDELETE_DAT = clsConverter.ToString(objRow["DELETE_DAT"].ToString());
                arrOrder[i].SIGN_INT = clsConverter.ToInt(objRow["SIGN_INT"].ToString());
                // 主收费项目ID
                if (objDT.Columns.Contains("CHARGEITEMID_CHR"))
                    arrOrder[i].m_strCHARGEITEMID_CHR = clsConverter.ToString(objRow["CHARGEITEMID_CHR"].ToString());
                // 主收费项目名称
                if (objDT.Columns.Contains("CHARGEITEMNAME_CHR"))
                    arrOrder[i].m_strCHARGEITEMNAME_CHR = clsConverter.ToString(objRow["CHARGEITEMNAME_CHR"].ToString());
                // 术后标志（0-术前，1-术后) 
                arrOrder[i].m_intOPERATION_INT = clsConverter.ToInt(objRow["OPERATION_INT"].ToString());
                // 医嘱说明
                arrOrder[i].m_strREMARK_VCHR = clsConverter.ToString(objRow["REMARK_VCHR"].ToString());
                //修改标志(0-普通状态,1-频率修改)
                arrOrder[i].m_intCHARGE_INT = clsConverter.ToInt(objRow["CHARGE_INT"].ToString());
                //医嘱归类(0-普通,1-术后医嘱,2-转科医嘱,3-出院(今日),4-出院(明日))
                arrOrder[i].m_intTYPE_INT = clsConverter.ToInt(objRow["TYPE_INT"].ToString());
                arrOrder[i].m_dmlOneUse = clsConverter.ToDecimal(objRow["SINGLEAMOUNT_DEC"].ToString());
                //检验申请单类别
                arrOrder[i].m_strLISAPPLYUNITID_CHR = clsConverter.ToString(objRow["LISAPPLYUNITID_CHR"].ToString());
                //检查申请单类别
                arrOrder[i].m_strAPPLYTYPEID_CHR = clsConverter.ToString(objRow["APPLYTYPEID_CHR"].ToString());
                //诊疗项目名称
                if (objDT.Columns.Contains("DicName"))
                {
                    arrOrder[i].m_strDicName = clsConverter.ToString(objRow["DicName"]);
                }
                //医嘱源类型(0-普通录入,1-特别科室录入)
                arrOrder[i].m_intSOURCETYPE_INT = clsConverter.ToInt(objRow["SOURCETYPE_INT"].ToString());

                arrOrder[i].creatorsign = objRow["creatorsign"];
                arrOrder[i].confirmersign = objRow["confirmersign"];
                arrOrder[i].stopersign = objRow["stopersign"];
                arrOrder[i].assessorsign = objRow["assessorsign"];

                arrOrder[i].AntiUse = objRow["antiuse"] == DBNull.Value ? 0 : clsConverter.ToInt(objRow["antiuse"].ToString());
                arrOrder[i].AntiUse_YFLX = objRow["antiuse_yflx"] == DBNull.Value ? 0 : clsConverter.ToInt(objRow["antiuse_yflx"].ToString());
                arrOrder[i].CureDays = objRow["curedays"] == DBNull.Value ? 0 : clsConverter.ToInt(objRow["curedays"].ToString());
                arrOrder[i].IsProxyBoilMed = objRow["isproxyboilmed"] == DBNull.Value ? 0 : clsConverter.ToInt(objRow["isproxyboilmed"].ToString());
            }
            return 1;
        }
        #endregion

        #endregion

        #region 获取医嘱类型ＩＤ
        /// <summary>
        /// 获取医嘱类型ＩＤ	根据医嘱ＩＤ
        /// </summary>
        /// <param name="p_strOrderID">医嘱ＩＤ</param>
        /// <param name="p_strOrderCateID">医嘱类型ＩＤ　［out 参数］</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderCateIDByOrderID(string p_strOrderID, out string p_strOrderCateID)
        {
            long lngRes = 0;
            p_strOrderCateID = "";
            string strSQL = "SELECT (select ordercateid_chr from t_bse_bih_orderdic where Trim(t_bse_bih_orderdic.orderdicid_chr)=Trim(a.orderdicid_chr))ordercateid_chr FROM t_opr_bih_order a";
            strSQL += " where trim(a.ORDERID_CHR)='" + p_strOrderID.Trim() + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_strOrderCateID = dtbResult.Rows[0]["ordercateid_chr"].ToString().Trim();
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

        #region 改变医嘱的执行状态: -1 作废医嘱; 0 创建; 1 提交; 2 执行; 3 停止; 4 重整; 5 已审核提交; 6 审核停止; 7 退回;

        #region 提交医嘱
        /// <summary>
        /// 提交医嘱	执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明:	针对状态0-创建
        /// </summary>
        /// <param name="arrOrder">医嘱对象Vo [数组]</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPostOrder(clsBIHOrder[] arrOrder, string strDoctorID, string strDoctorName)
        {
            if ((arrOrder == null) || (arrOrder.Length <= 0)) return 1;

            string[] arrOrderID = new string[arrOrder.Length];
            for (int i = 0; i < arrOrder.Length; i++)
            {
                arrOrderID[i] = arrOrder[i].m_strOrderID;
            }

            DateTime dtPost = DateTime.Now;

            long ret = 0;
            try
            {
                ret = 0;
                ret = m_lngPostOrder(arrOrderID, strDoctorID, strDoctorName, dtPost);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (ret > 0)
            {
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    if (arrOrder[i] == null) continue;
                    arrOrder[i].m_intStatus = 1;		//提交
                    arrOrder[i].m_strPosterId = strDoctorID;
                    arrOrder[i].m_strPoster = strDoctorName;
                    arrOrder[i].m_dtPostdate = dtPost;
                }
            }

            return ret;
        }

        /// <summary>
        /// 提交医嘱	执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明:	针对状态0-创建
        ///				同方号的全部都提交了
        /// </summary>
        /// <param name="arrOrder">医嘱ID [数组]</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <param name="dtPost">执行时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPostOrder(string[] arrOrderID, string strDoctorID, string strDoctorName, DateTime dtPost)
        {
            //            int intNewStatus = 1;
            //            string strSql = @"
            //				update T_Opr_Bih_Order
            //				set Status_Int = [StatusValue] , PosterID_Chr='[DocIDValue]' , Poster_Chr = '[DocValue]' ,PostDate_Dat =to_date('[DocDate]','yyyy-mm-dd hh24:mi:ss')
            //				where (Status_Int = 0 OR Status_Int = 7) and trim(OrderID_Chr) in ([OrderIDArr])
            //			";

            //            strSql = strSql.Replace("[StatusValue]", intNewStatus.ToString());
            //            strSql = strSql.Replace("[DocIDValue]", strDoctorID);
            //            strSql = strSql.Replace("[DocValue]", strDoctorName);
            //            strSql = strSql.Replace("[DocDate]", dtPost.ToString("yyyy-MM-dd HH:mm:ss"));

            //            string strOrderIDs = GetOrderIDSameRecipeNO(arrOrderID, 0);
            //            string strOrderIDs7 = GetOrderIDSameRecipeNO(arrOrderID, 7);
            //            if (strOrderIDs.Trim() == "")
            //            {
            //                strOrderIDs = strOrderIDs7;
            //            }
            //            else if (strOrderIDs7.Trim() != "")
            //            {
            //                strOrderIDs += "," + strOrderIDs7;
            //            }
            //            if (strOrderIDs.Trim() == "") return 1;
            //            strSql = strSql.Replace("[OrderIDArr]", strOrderIDs);

            //            long ret = 0;
            //            try
            //            {
            //                ret = 0;
            //                ret = new clsHRPTableService().DoExcute(strSql);
            //            }
            //            catch (Exception objEx)
            //            {
            //                string strTmp = objEx.Message;
            //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
            //                bool blnRes = objLogger.LogError(objEx);
            //            }
            //            return ret;

            #region 提交医嘱
            int n = 0;
            long lngRes = 0;
            string strSQL = @"  
	            update T_Opr_Bih_Order
				set Status_Int = 1 , PosterID_Chr=?, Poster_Chr = ? ,PostDate_Dat =sysdate,STARTDATE_DAT=sysdate
				where (Status_Int = 0 OR Status_Int = 7) and OrderID_Chr =?
			                      ";

            DbType[] dbTypes = new DbType[] { 
                        DbType.String,DbType.String,DbType.String
                        };
            object[][] objValues = new object[3][];
            for (int j = 0; j < objValues.Length; j++)
            {
                objValues[j] = new object[arrOrderID.Length];//初始化
            }

            for (int k1 = 0; k1 < arrOrderID.Length; k1++)
            {
                n = -1;
                objValues[++n][k1] = strDoctorID;
                objValues[++n][k1] = strDoctorName;
                objValues[++n][k1] = arrOrderID[k1].Trim();

            }

            if (arrOrderID.Length > 0)
            {
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                    if (lngRes > 0)
                    {
                        //判断是否进行自动转抄
                        #region 转抄医嘱
                        //查1027机关 跳过医嘱转抄这个流程，0－不跳过，1－跳过
                        int ShowCodexRemarkFrmTimerinterval = -1;//跳过医嘱转抄这个流程，0－不跳过，1－跳过

                        strSQL = "select a.setstatus_int,a.setid_chr from t_sys_setting a where a.setid_chr ='1027' ";
                        DataTable dtbResult = new DataTable();
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                        if (lngRes > 0 && dtbResult.Rows.Count > 0)
                        {
                            if (dtbResult.Rows[0]["setstatus_int"].ToString().Equals("1"))
                            {
                                ShowCodexRemarkFrmTimerinterval = 1;
                            }
                            else
                            {
                                ShowCodexRemarkFrmTimerinterval = 0;
                            }

                        }
                        if (ShowCodexRemarkFrmTimerinterval == 1)
                        {
                            strSQL = @"  
	            update T_Opr_Bih_Order
				set Status_Int = 5 , CONFIRMERID_CHR=?, CONFIRMER_VCHR = ? ,CONFIRM_DAT =sysdate
				where Status_Int = 1  and OrderID_Chr =?
			                      ";
                            lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                        }
                        objHRPSvc.Dispose();
                        #endregion
                    }
                    /*<================================*/
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            #endregion

            return lngRes;

        }

        /// <summary>
        /// 提交医嘱	执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明:	针对状态0-创建
        /// </summary>
        /// <param name="strAreaID">病区ID</param>
        /// <param name="strBedBegin">起始病床</param>
        /// <param name="strBedEnd">截至病床</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPostOrder(string strAreaID, string strBedBegin, string strBedEnd, string strDoctorID, string strDoctorName)
        {
            string strSql = @"
				select TA.RegisterID_Chr,TB.BedID_Chr,TB.Code_Chr BedName 
					from T_Opr_Bih_Register TA,T_BSE_Bed TB
					where TA.AreaID_Chr=TB.AreaID_Chr and TA.BedID_Chr=TB.BedID_Chr
					[PatientCondition]
				";
            string strCondition = m_strGetPatientsSQL("TB", strAreaID, strBedBegin, strBedEnd);
            strSql = strSql.Replace("[PatientCondition]", strCondition);

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (ret > 0)
            {
                if ((objDT != null) && (objDT.Rows.Count > 0))
                {
                    string strRegisterIDArr = "";

                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        string strRegID = objDT.Rows[i]["RegisterID_Chr"].ToString().Trim();
                        if (strRegID == "") continue;

                        if (strRegisterIDArr != "") strRegisterIDArr += ",";
                        strRegisterIDArr += "'" + strRegID + "'";
                    }

                    string strSql2 = @"
						update T_Opr_Bih_Order
						set Status_Int = [StatusValue] , PosterID_Chr='[DocIDValue]' , Poster_Chr = '[DocValue]' ,PostDate_Dat =to_date('[DocDate]','yyyy-mm-dd hh24:mi:ss')
						where Status_Int = 0 and trim(RegisterID_Chr) in ([RegisterIDValueArr])
					";

                    strSql2 = strSql2.Replace("[StatusValue]", "1");
                    strSql2 = strSql2.Replace("[DocIDValue]", strDoctorID);
                    strSql2 = strSql2.Replace("[DocValue]", strDoctorName);
                    strSql2 = strSql2.Replace("[DocDate]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    strSql2 = strSql2.Replace("[RegisterIDValueArr]", strRegisterIDArr);
                    long ret2 = 0;
                    try
                    {
                        ret2 = new clsHRPTableService().DoExcute(strSql2);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                    if (ret2 > 0)
                        return 1;
                    else
                        return 0;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 执行医嘱	{没用}
        //		/// <summary>
        //		/// 执行医嘱	
        //		/// 执行状态：	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        //		/// 业务说明：	子级医嘱不能单独执行，必须和其父级医嘱一起执行
        //		/// </summary>
        //		/// <param name="p_objOrder">医嘱对象Vo	[ref 参数]</param>
        //		/// <param name="strDoctorID">执行者ID</param>
        //		/// <param name="strDoctorName">执行者姓名</param>
        //		/// <returns></returns>
        //		[AutoComplete]
        //		public long m_lngExecuteOrder(ref clsBIHOrder p_objOrder,string strDoctorID,string strDoctorName)
        //		{
        //			long lngRes =-1;
        //			if(p_objOrder.m_strParentID!=null && p_objOrder.m_strParentID!=string.Empty)
        //			{
        //				return lngRes;
        //			}
        //			lngRes=0;
        //			lngRes =m_lngChangeOrderStatus(p_objOrder.m_strOrderID,strDoctorID,strDoctorName,2);
        //			
        //			if(lngRes>0)
        //			{
        //				p_objOrder.m_intStatus=2;
        //				p_objOrder.m_strStoperID=strDoctorID;
        //				p_objOrder.m_strStoper=strDoctorName;
        //				p_objOrder.m_dtStartDate=System.DateTime.Now;
        //			}
        //			return lngRes;
        //		}
        //		/// <summary>
        //		/// 执行医嘱	
        //		/// 执行状态：	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        //		/// 业务说明：	子级医嘱不能单独执行，必须和其父级医嘱一起执行
        //		/// </summary>
        //		/// <param name="objOrderArr">医嘱对象Vo [数组]</param>
        //		/// <param name="strDoctorID">执行者ID</param>
        //		/// <param name="strDoctorName">执行者姓名</param>
        //		/// <returns>返回{-1=不能作执行操作；、0=执行出错；、1=成功；}</returns>
        //		[AutoComplete]
        //		public long m_lngExecuteOrder(clsBIHOrder[] arrOrder,string strDoctorID,string strDoctorName)
        //		{
        //			DateTime dtNow=DateTime.Now;
        //			int intNewStatus=2;
        //			string strSql=@"
        //				update T_Opr_Bih_Order
        //				set Status_Int = [StatusValue] , StoperID_Chr='[DocIDValue]' , Stoper_Chr = '[DocValue]' ,StopDate_Dat =to_date('[DocDate]','yyyy-mm-dd hh24:mi:ss')
        //				where trim(OrderID_Chr) in ([OrderIDArr])
        //			";
        //
        //			strSql=strSql.Replace("[StatusValue]",intNewStatus.ToString());
        //			strSql=strSql.Replace("[DocIDValue]",strDoctorID);
        //			strSql=strSql.Replace("[DocValue]",strDoctorName);
        //			strSql=strSql.Replace("[DocDate]",dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
        //
        //			string strIDs="";
        //			for(int i=0;i<arrOrder.Length;i++)
        //			{
        //				if(arrOrder[i]==null) continue;
        //				if(strIDs.Length>0) strIDs += ",";
        //				strIDs += "'" + arrOrder[i].m_strOrderID.Trim() + "'";
        //			}
        //			if(strIDs.Length<=0) return 1;
        //			strSql=strSql.Replace("[OrderIDArr]",strIDs);
        //
        //			long ret=new clsHRPTableService().DoExcute(strSql);
        //			if(ret>0)
        //			{
        //				for(int i=0;i<arrOrder.Length;i++)
        //				{
        //					if(arrOrder[i]==null) continue;
        //					arrOrder[i].m_intStatus=intNewStatus;
        //					arrOrder[i].m_strStoperID=strDoctorID;
        //					arrOrder[i].m_strStoper=strDoctorName;
        //					arrOrder[i].m_dtStartDate=dtNow;
        //				}
        //			}
        //			else
        //			{
        //				return 0;
        //			}
        //			return 1;
        //		}		
        #endregion

        #region 停止长期医嘱
        /// <summary>
        /// 停止长期医嘱	
        /// 执行状态: -1 作废医嘱; 0 创建; 1 提交; 2 执行; 3 停止; 4 重整; 5 已审核提交; 6 审核停止; 7 退回; 
        /// 业务说明: 只针对状态 1-提交、2-执行
        ///				
        /// </summary>
        /// <param name="objOrderArr">医嘱对象Vo [数组]</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStopOrder(clsBIHOrder[] arrOrder, string doctorId, string doctorName, DateTime stopTime)
        {
            int intNewStatus = 3;
            string Sql = @"update t_opr_bih_order
                               set status_int     = {0},
                                   stoperid_chr   = '{1}',
                                   stoper_chr     = '{2}',
                                   stopdate_dat   = {3},
                                   finishdate_dat = {4}
                             where orderid_chr in ({5})";

            DateTime dtNow = DateTime.Now;
            // 连续性医嘱的特殊情况
            if (arrOrder.Length == 1 && dtNow.AddYears(-100) < arrOrder[0].m_dtStopdate && dtNow.AddYears(100) > arrOrder[0].m_dtStopdate)
                dtNow = arrOrder[0].m_dtStopdate;
            string[] sarr = new string[6];
            sarr[0] = intNewStatus.ToString();
            sarr[1] = doctorId;
            sarr[2] = doctorName;
            sarr[3] = (stopTime == DateTime.MinValue ? "sysdate" : "to_date('" + stopTime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')");
            sarr[4] = sarr[3];

            string[] orderIdArr = new string[arrOrder.Length];
            for (int i = 0; i < arrOrder.Length; i++)
            {
                if (arrOrder[i] != null)
                    orderIdArr[i] = arrOrder[i].m_strOrderID.Trim();
                else
                    orderIdArr[i] = "";
            }
            string orderIds = "";
            /*保证同放号的一起操作 
             * strOrderIDs =GetOrderIDSameRecipeNO(strOrderIDArr,2);
             * if(strOrderIDs.Trim()=="") return 1;//没有要停止的医嘱
            */
            for (int i1 = 0; i1 < orderIdArr.Length; i1++)
            {
                if (orderIds != "" && orderIdArr[i1].Trim() != "") orderIds += ",";
                orderIds += "'" + orderIdArr[i1].Trim() + "'";
            }
            sarr[5] = orderIds;
            Sql = string.Format(Sql, sarr);

            long ret = 0;
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                ret = svc.DoExcute(Sql);

                #region 恢复预扣库存

                if (intNewStatus == 3)
                {
                    long lngAff = 0;
                    DataTable dt = null;
                    Sql = @"select a.serno,
                                   a.registerid,
                                   a.orderid,
                                   a.storeid,
                                   a.medid,
                                   a.seriesid,
                                   a.ipamountreal,
                                   a.opamountreal,
                                   a.ipamountre,
                                   a.opamountre
                              from t_curemedsubtract a
                             where a.orderid in ({0}) 
                               and (a.ipamountre <> 0 or a.ipamountre <> 0)";
                    svc.lngGetDataTableWithoutParameters(string.Format(Sql, orderIds), ref dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Sql = @"update t_ds_storage_detail a
                                   set a.iprealgross_int      = a.iprealgross_int + ?,
                                       a.ipavailablegross_num = a.ipavailablegross_num + ?,
                                       a.oprealgross_int      = a.oprealgross_int + ?,
                                       a.opavailablegross_num = a.opavailablegross_num + ?
                                 where a.seriesid_int = ?";

                        DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Int32 };
                        object[][] objValues = new object[5][];
                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[dt.Rows.Count];
                        }
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            objValues[0][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                            objValues[1][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                            objValues[2][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                            objValues[3][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                            objValues[4][k] = Convert.ToInt32(dt.Rows[k]["seriesid"]);
                        }
                        svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref lngAff, dbTypes);

                        Sql = @"update t_ds_storage a
                                   set a.ipcurrentgross_num = a.ipcurrentgross_num + ?,
                                       a.opcurrentgross_num = a.opcurrentgross_num + ?
                                 where a.drugstoreid_chr = ?
                                   and a.medicineid_chr = ?";

                        dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String };
                        objValues = new object[4][];
                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[dt.Rows.Count];
                        }
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            objValues[0][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                            objValues[1][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                            objValues[2][k] = dt.Rows[k]["storeid"].ToString();
                            objValues[3][k] = dt.Rows[k]["medid"].ToString();
                        }
                        svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref lngAff, dbTypes);

                        Sql = @"update t_opr_bih_order t
                                   set t.preamount2 = 0
                                 where t.orderid_chr in ({0}) 
                                   and t.preamount2 > 0";
                        svc.DoExcute(string.Format(Sql, orderIds));

                        Sql = @"update t_curemedsubtract t
                                   set t.ipamountre = 0, t.opamountre = 0
                                 where t.orderid in ({0}) 
                                   and (t.ipamountre > 0 or t.opamountre > 0)";
                        svc.DoExcute(string.Format(Sql, orderIds));
                    }
                }
                #endregion
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (ret > 0)
            {
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    if (arrOrder[i] == null) continue;
                    arrOrder[i].m_intStatus = intNewStatus;
                    arrOrder[i].m_strStoperID = doctorId;
                    arrOrder[i].m_strStoper = doctorName;
                    arrOrder[i].m_dtStartDate = dtNow;
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 停止长期医嘱	[可以梯归删除子级医嘱]
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：2-执行
        ///	在更新父医嘱时同时更新"同样状态"的子医嘱
        /// </summary>
        /// <param name="p_objOrder">医嘱对象Vo</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <param name="p_blnInfectSon">是否梯归删除子级医嘱</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStopOrder(clsBIHOrder p_objOrder, string strDoctorID, string strDoctorName, bool p_blnInfectSon, DateTime m_dtStopTime)
        {
            long lngRes = 0;
            // 停止本目录
            lngRes = m_lngStopOrder(new clsBIHOrder[] { p_objOrder }, strDoctorID, strDoctorName, m_dtStopTime);
            // 梯归停止子级医嘱
            clsBIHOrder[] objResultArr;
            int i = 0;
            if (p_blnInfectSon && lngRes > 0)
            {
                objResultArr = null;
                lngRes = 0;
                lngRes = m_lngGetOrderByParentID(p_objOrder.m_strOrderID, out objResultArr);
                if (lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
                {
                    for (i = 0; i < objResultArr.Length; i++)
                    {
                        if (lngRes > 0)
                        {
                            if (objResultArr[i].m_intStatus == 2)
                            {
                                lngRes = 0;
                                lngRes = m_lngStopOrder(objResultArr[i], strDoctorID, strDoctorName, true, m_dtStopTime);
                            }
                        }
                    }
                }
            }
            if (lngRes <= 0)
            {
                throw (new System.Exception("停止医嘱失败！"));
            }
            return lngRes;
        }

        #region bak
        /// <summary>
        /// 停止长期医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：1-提交、2-执行
        ///				
        /// </summary>
        /// <param name="p_objItemArr">医嘱对象Vo [数组]</param>
        /// <param name="p_strDoctorID">执行者ID</param>
        /// <param name="p_strDoctorName">执行者姓名</param>
        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngStopOrder(System.Security.Principal.IPrincipal p_objPrincipal, clsBIHOrder[] p_objItemArr, string p_strDoctorID, string p_strDoctorName)
        //        {
        //            long lngRes = 0;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngDeleteOrderAttachTransfer");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }
        //            #region SQL
        //            string strSQL = @"
        //				update T_Opr_Bih_Order
        //				set Status_Int = [STATUSVALUE] , StoperID_Chr='[DOCIDVALUE]' , Stoper_Chr = '[DOCVALUE]' ,StopDate_Dat =to_date('[DOCDATE]','yyyy-mm-dd hh24:mi:ss')
        //				where (trim(OrderID_Chr) in ([ORDERIDVALUE])) 
        //					  and (Status_Int in (1,2))
        //			";
        //            DateTime dtNow = DateTime.Now;
        //            strSQL = strSQL.Replace("[STATUSVALUE]", "3");
        //            strSQL = strSQL.Replace("[DOCIDVALUE]", p_strDoctorID);
        //            strSQL = strSQL.Replace("[DOCVALUE]", p_strDoctorName);
        //            strSQL = strSQL.Replace("[DOCDATE]", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
        //            string strOrderIDValue = "";
        //            for (int i = 0; i < p_objItemArr.Length; i++)
        //            {
        //                if (p_objItemArr[i] != null && p_objItemArr[i].m_strOrderID.Trim() != "")
        //                {
        //                    if (strOrderIDValue.Trim() == "")
        //                        strOrderIDValue = "'" + p_objItemArr[i].m_strOrderID.Trim() + "'";
        //                    else
        //                        strOrderIDValue += ",'" + p_objItemArr[i].m_strOrderID.Trim() + "'";
        //                }
        //            }
        //            if (strOrderIDValue.Trim() == "") return 1;
        //            strSQL = strSQL.Replace("[ORDERIDVALUE]", strOrderIDValue);
        //            #endregion

        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = 0;
        //                lngRes = objHRPSvc.DoExcute(strSQL);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                string strTmp = objEx.Message;
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        #endregion

        /// <summary>
        /// 停止医嘱
        /// </summary>
        /// <param name="p_strStopOrderIDArr"></param>
        /// <param name="strDoctorID"></param>
        /// <param name="strDoctorName"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStopOrder(string[] stopOrderIdArr, string doctorID, string doctorName)
        {
            long lngRecEff = 0;
            long ret = 0;
            string Sql = string.Empty;
            if ((stopOrderIdArr == null) && (stopOrderIdArr.Length <= 0)) return 1;
            string orderIds = "";
            for (int i1 = 0; i1 < stopOrderIdArr.Length; i1++)
            {
                if (orderIds != "" && stopOrderIdArr[i1].Trim() != "") orderIds += ",";
                orderIds += "'" + stopOrderIdArr[i1].Trim() + "'";
            }
            if (orderIds.Trim() == "") return 1;

            try
            {
                Sql = @"update t_opr_bih_order
                           set status_int     = 3,
                               stoperid_chr   = ?,
                               stoper_chr     = ?,
                               stopdate_dat   = sysdate,
                               finishdate_dat = sysdate
                         where status_int = 2
                           and executetype_int = 1
                           and orderid_chr in ({0})";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = doctorID.Trim();
                parm[1].Value = doctorName.Trim();
                ret = svc.lngExecuteParameterSQL(string.Format(Sql, orderIds), ref lngRecEff, parm);

                // 同步更新执行单表
                if (ret > 0)
                {
                    Sql = @"update t_opr_bih_orderexecute
                               set executedate_vchr = '已停止'
                             where orderid_chr in ({0})";
                    ret = svc.DoExcute(string.Format(Sql, orderIds));
                }

                #region 恢复预扣库存

                long lngAff = 0;
                DataTable dt = null;
                Sql = @"select a.serno,
                               a.registerid,
                               a.orderid,
                               a.storeid,
                               a.medid,
                               a.seriesid,
                               a.ipamountreal,
                               a.opamountreal,
                               a.ipamountre,
                               a.opamountre
                          from t_curemedsubtract a
                         where a.orderid in ({0}) 
                           and (a.ipamountre <> 0 or a.ipamountre <> 0)";
                svc.lngGetDataTableWithoutParameters(string.Format(Sql, orderIds), ref dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Sql = @"update t_ds_storage_detail a
                               set a.iprealgross_int      = a.iprealgross_int + ?,
                                   a.ipavailablegross_num = a.ipavailablegross_num + ?,
                                   a.oprealgross_int      = a.oprealgross_int + ?,
                                   a.opavailablegross_num = a.opavailablegross_num + ?
                             where a.seriesid_int = ?";

                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Int32 };
                    object[][] objValues = new object[5][];
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[dt.Rows.Count];
                    }
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        objValues[0][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                        objValues[1][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                        objValues[2][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                        objValues[3][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                        objValues[4][k] = Convert.ToInt32(dt.Rows[k]["seriesid"]);
                    }
                    svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref lngAff, dbTypes);

                    Sql = @"update t_ds_storage a
                               set a.ipcurrentgross_num = a.ipcurrentgross_num + ?,
                                   a.opcurrentgross_num = a.opcurrentgross_num + ?
                             where a.drugstoreid_chr = ?
                               and a.medicineid_chr = ?";

                    dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String };
                    objValues = new object[4][];
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[dt.Rows.Count];
                    }
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        objValues[0][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                        objValues[1][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                        objValues[2][k] = dt.Rows[k]["storeid"].ToString();
                        objValues[3][k] = dt.Rows[k]["medid"].ToString();
                    }
                    svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref lngAff, dbTypes);

                    Sql = @"update t_opr_bih_order t
                               set t.preamount2 = 0
                             where t.orderid_chr in ({0}) 
                               and t.preamount2 > 0";
                    svc.DoExcute(string.Format(Sql, orderIds));

                    Sql = @"update t_curemedsubtract t
                               set t.ipamountre = 0, t.opamountre = 0
                             where t.orderid in ({0}) 
                               and (t.ipamountre > 0 or t.opamountre > 0)";
                    svc.DoExcute(string.Format(Sql, orderIds));

                }
                #endregion

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        /// <summary>
        /// 停止当前病人所有医嘱
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strHandlersID"></param>
        /// <param name="p_strHandlerse"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStopAllOrderByRegID(string registerId, string handlersId, string handlers)
        {
            long lngRes = 0;
            long lngAff = 0;
            clsHRPTableService svc = new clsHRPTableService();

            try
            {
                string Sql = string.Empty;
                // 同步更新执行单表
                Sql = @"update t_opr_bih_orderexecute b
                           set b.executedate_vchr = '已停止'
                         where b.orderid_chr in (select a.orderid_chr
                                                   from t_opr_bih_order a
                                                  where a.status_int = 2
                                                    and a.executetype_int = 1
                                                    and a.registerid_chr = ?)";

                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = registerId;
                lngRes = svc.lngExecuteParameterSQL(Sql, ref lngAff, parm);

                Sql = @"update t_opr_bih_order
                           set status_int     = 3,
                               stoperid_chr   = ?,
                               stoper_chr     = ?,
                               stopdate_dat   = sysdate,
                               finishdate_dat = sysdate
                         where status_int = 2
                           and executetype_int = 1
                           and registerid_chr = ?";

                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = handlersId;
                parm[1].Value = handlers;
                parm[2].Value = registerId;
                lngRes = svc.lngExecuteParameterSQL(Sql, ref lngAff, parm);

                #region 恢复预扣库存

                DataTable dt = null;
                Sql = @"select a.serno,
                               a.registerid,
                               a.orderid,
                               a.storeid,
                               a.medid,
                               a.seriesid,
                               a.ipamountreal,
                               a.opamountreal,
                               a.ipamountre,
                               a.opamountre
                          from t_curemedsubtract a
                         where a.registerid = ?
                           and (a.ipamountre <> 0 or a.ipamountre <> 0)";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = registerId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Sql = @"update t_ds_storage_detail a
                               set a.iprealgross_int      = a.iprealgross_int + ?,
                                   a.ipavailablegross_num = a.ipavailablegross_num + ?,
                                   a.oprealgross_int      = a.oprealgross_int + ?,
                                   a.opavailablegross_num = a.opavailablegross_num + ?
                             where a.seriesid_int = ?";

                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Int32 };
                    object[][] objValues = new object[5][];
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[dt.Rows.Count];
                    }
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        objValues[0][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                        objValues[1][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                        objValues[2][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                        objValues[3][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                        objValues[4][k] = Convert.ToInt32(dt.Rows[k]["seriesid"]);
                    }
                    svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref lngAff, dbTypes);

                    Sql = @"update t_ds_storage a
                           set a.ipcurrentgross_num = a.ipcurrentgross_num + ?,
                               a.opcurrentgross_num = a.opcurrentgross_num + ?
                         where a.drugstoreid_chr = ?
                           and a.medicineid_chr = ?";

                    dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String };
                    objValues = new object[4][];
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[dt.Rows.Count];
                    }
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        objValues[0][k] = Convert.ToDouble(dt.Rows[k]["ipamountre"]);
                        objValues[1][k] = Convert.ToDouble(dt.Rows[k]["opamountre"]);
                        objValues[2][k] = dt.Rows[k]["storeid"].ToString();
                        objValues[3][k] = dt.Rows[k]["medid"].ToString();
                    }
                    svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref lngAff, dbTypes);

                    Sql = @"update t_opr_bih_order t
                               set t.preamount2 = 0
                             where t.registerid_chr = ?
                               and t.preamount2 > 0";

                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = registerId;
                    lngRes = svc.lngExecuteParameterSQL(Sql, ref lngAff, parm);

                    Sql = @"update t_curemedsubtract t
                               set t.ipamountre = 0, t.opamountre = 0
                             where t.registerid = ?
                               and (t.ipamountre > 0 or t.opamountre > 0)";

                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = registerId;
                    lngRes = svc.lngExecuteParameterSQL(Sql, ref lngAff, parm);

                }
                #endregion

                svc.Dispose();
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

        #region 重整医嘱
        /// <summary>
        /// 重整医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：6-审核停止;
        /// </summary>
        /// <param name="objOrderArr">医嘱对象Vo [数组]</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRetractOrder(clsBIHOrder[] arrOrder, string strDoctorID, string strDoctorName)
        {
            int intNewStatus = 4;
            string strSql = @"
				update T_Opr_Bih_Order
				set Status_Int = [StatusValue] , RetractorID_Chr='[DocIDValue]' , Retractor_Chr = '[DocValue]' ,RetractDate_Dat =to_date('[DocDate]','yyyy-mm-dd hh24:mi:ss')
				where trim(OrderID_Chr) in ([OrderIDArr])
			";

            DateTime dtNow = DateTime.Now;

            strSql = strSql.Replace("[StatusValue]", intNewStatus.ToString());
            strSql = strSql.Replace("[DocIDValue]", strDoctorID);
            strSql = strSql.Replace("[DocValue]", strDoctorName);
            strSql = strSql.Replace("[DocDate]", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));

            string[] strOrderIDArr = new string[arrOrder.Length];
            for (int i = 0; i < arrOrder.Length; i++)
            {
                if (arrOrder[i] != null)
                    strOrderIDArr[i] = arrOrder[i].m_strOrderID.Trim();
                else
                    strOrderIDArr[i] = "";
            }
            string strOrderIDs = "";
            /*保证同放号的一起操作 
            string strOrderIDs =GetOrderIDSameRecipeNO(strOrderIDArr,3);
            string strOrderID5 =GetOrderIDSameRecipeNO(strOrderIDArr,6);
            if (strOrderIDs.Trim()=="") 
                strOrderIDs =strOrderID5;
            else
                strOrderIDs +=(strOrderID5.Trim()=="")?(""):("," + strOrderID5);
            */
            for (int i1 = 0; i1 < strOrderIDArr.Length; i1++)
            {
                if (strOrderIDs != "" && strOrderIDArr[i1].Trim() != "") strOrderIDs += ",";
                strOrderIDs += "'" + strOrderIDArr[i1].Trim() + "'";
            }

            if (strOrderIDs.Trim() == "") return 1;

            strSql = strSql.Replace("[OrderIDArr]", strOrderIDs);

            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoExcute(strSql);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (ret > 0)
            {
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    if (arrOrder[i] == null) continue;
                    arrOrder[i].m_intStatus = intNewStatus;
                    arrOrder[i].m_strRetractorID = strDoctorID;
                    arrOrder[i].m_strRetractor = strDoctorName;
                    arrOrder[i].m_dtRetractdate = dtNow;
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 重整医嘱	[可以梯归重整子级医嘱]
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：6-审核停止;
        ///				在更新父医嘱时同时更新"同样状态"的子医嘱
        /// </summary>
        /// <param name="p_objOrder">医嘱对象Vo</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <param name="p_blnInfectSon">是否梯归重整子级医嘱</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRetractOrder(clsBIHOrder p_objOrder, string strDoctorID, string strDoctorName, bool p_blnInfectSon)
        {
            long lngRes = 0;
            //重整本目录
            lngRes = m_lngRetractOrder(new clsBIHOrder[] { p_objOrder }, strDoctorID, strDoctorName);
            //梯归重整子级医嘱
            clsBIHOrder[] objResultArr;
            int i = 0;
            if (p_blnInfectSon && lngRes > 0)
            {
                objResultArr = null;
                lngRes = 0;
                lngRes = m_lngGetOrderByParentID(p_objOrder.m_strOrderID, out objResultArr);
                if (lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
                {
                    for (i = 0; i < objResultArr.Length; i++)
                    {
                        if (lngRes > 0)
                        {
                            if (objResultArr[i].m_intStatus == 6)
                            {
                                lngRes = 0;
                                lngRes = m_lngRetractOrder(objResultArr[i], strDoctorID, strDoctorName, true);
                            }
                        }
                    }
                }
            }
            if (lngRes <= 0)
            {
                throw (new System.Exception("重整医嘱失败！"));
            }
            return lngRes;
        }
        #endregion

        #region 作废医嘱
        /// <summary>
        /// 作废医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：1-提交、5- 已审核提交;
        /// </summary>
        /// <param name="p_strBlankOutOrderIDArr">医嘱ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBlankOutOrder(string[] p_strBlankOutOrderIDArr, string DELETERID_CHR, string DELETERNAME_VCHR)
        {
            long lngRecEff = 0;
            // string strSql = @"UPDATE t_opr_bih_order SET status_int = -1,DELETERID_CHR=?,DELETERNAME_VCHR=?,DELETE_DAT=sysdate WHERE (status_int=0 OR status_int=1 OR status_int=3 or status_int=5 OR status_int=7 or (EXECUTETYPE_INT=2 and status_int=2)) AND orderid_chr IN ([ORDERIDARR]) ";
            string strSql = @"UPDATE t_opr_bih_order SET status_int = -1,DELETERID_CHR=?,DELETERNAME_VCHR=?,DELETE_DAT=sysdate WHERE  orderid_chr IN ([ORDERIDARR]) ";

            if ((p_strBlankOutOrderIDArr == null) && (p_strBlankOutOrderIDArr.Length <= 0)) return 1;
            string strOrderIDs = "";
            for (int i1 = 0; i1 < p_strBlankOutOrderIDArr.Length; i1++)
            {
                if (strOrderIDs != "" && p_strBlankOutOrderIDArr[i1].Trim() != "") strOrderIDs += ",";
                strOrderIDs += "'" + p_strBlankOutOrderIDArr[i1].Trim() + "'";
            }
            if (strOrderIDs.Trim() == "") return 1;
            strSql = strSql.Replace("[ORDERIDARR]", strOrderIDs);
            long ret = 0;
            try
            {
                ret = 0;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] Params = null;
                objHRPSvc.CreateDatabaseParameter(2, out Params);
                Params[0].Value = DELETERID_CHR.Trim();
                Params[1].Value = DELETERNAME_VCHR.Trim();
                ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, Params);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        /// <summary>
        /// 作废医嘱	[可以梯归作废子级医嘱]
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：1-提交、5- 已审核提交;
        ///				在更新父医嘱时同时更新"同样状态"的子医嘱
        /// </summary>
        /// <param name="arrDeleteOrderID">医嘱ID</param>
        /// <param name="p_blnInfectSon">是否梯归删除子级医嘱</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBlankOutOrder(string p_strBlankOutOrderID, bool p_blnInfectSon, string DELETERID_CHR, string DELETERNAME_VCHR)
        {
            long lngRes = 0;
            //作废本目录
            lngRes = m_lngBlankOutOrder(new string[] { p_strBlankOutOrderID }, DELETERID_CHR, DELETERNAME_VCHR);
            //梯归作废子级医嘱
            clsBIHOrder[] objResultArr;
            int i = 0;
            if (p_blnInfectSon && lngRes > 0)
            {
                objResultArr = null;
                lngRes = 0;
                lngRes = m_lngGetOrderByParentID(p_strBlankOutOrderID, out objResultArr);
                if (lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
                {
                    for (i = 0; i < objResultArr.Length; i++)
                    {
                        if (lngRes > 0)
                        {
                            if (objResultArr[i].m_intStatus == 0 || objResultArr[i].m_intStatus == 1 || objResultArr[i].m_intStatus == 5 || objResultArr[i].m_intStatus == 7)
                            {
                                lngRes = 0;
                                lngRes = m_lngBlankOutOrder(objResultArr[i].m_strOrderID, true, DELETERID_CHR, DELETERNAME_VCHR);
                            }
                        }
                    }
                }
            }
            if (lngRes <= 0)
            {
                throw (new System.Exception("作废医嘱失败！"));
            }
            return lngRes;
        }
        #endregion

        #region 删除医嘱
        /// <summary>
        /// 删除医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：0-创建
        /// </summary>
        /// <param name="p_strDeleteOrderIDArr">医嘱ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteOrder2(string[] p_strDeleteOrderIDArr)
        {
            //string strSql=@"Delete T_Opr_Bih_Order where trim(OrderID_Chr) in ([OrderIDArr]) ";
            string strSql = @"Delete T_Opr_Bih_Order where (Status_Int=0 OR Status_Int=1 OR Status_Int=7 OR TYPE_INT<>0) and trim(OrderID_Chr) in ([OrderIDArr]) ";

            if ((p_strDeleteOrderIDArr == null) && (p_strDeleteOrderIDArr.Length <= 0)) return 1;
            string strIDs = "";
            for (int i = 0; i < p_strDeleteOrderIDArr.Length; i++)
            {
                if (i > 0) strIDs += ",";
                strIDs += "'" + p_strDeleteOrderIDArr[i].Trim() + "'";
            }
            strSql = strSql.Replace("[OrderIDArr]", strIDs);
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoExcute(strSql);
                if (ret > 0)
                {
                    strSql = "delete  T_OPR_BIH_ORDERCHARGEDEPT  where orderid_chr in ([OrderIDArr]) ";
                    strSql = strSql.Replace("[OrderIDArr]", strIDs);
                    ret = 0;
                    ret = new clsHRPTableService().DoExcute(strSql);

                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        /// <summary>
        /// 删除医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：0-创建
        /// </summary>
        /// <param name="p_strDeleteOrderIDArr">医嘱ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteOrder(string[] p_strDeleteOrderIDArr)
        {

            int n = 0;
            long lngRes = 0;
            string strSQL = @"  
                             update T_Opr_Bih_Order
                             set Status_Int=-2 
                             where (Status_Int=0 OR Status_Int=1 OR Status_Int=7 OR TYPE_INT<>0) and OrderID_Chr=?
                                            ";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            DbType[] dbTypes = new DbType[] { 
                        DbType.String
                       
                        };
            object[][] objValues = new object[1][];
            for (int j = 0; j < objValues.Length; j++)
            {
                objValues[j] = new object[p_strDeleteOrderIDArr.Length];//初始化
            }

            for (int k1 = 0; k1 < p_strDeleteOrderIDArr.Length; k1++)
            {

                n = -1;
                objValues[++n][k1] = p_strDeleteOrderIDArr[k1];

            }

            if (p_strDeleteOrderIDArr.Length > 0)
            {
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
            }
            return lngRes;
        }


        /// <summary>
        /// 删除医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：0-创建
        /// </summary>
        /// <param name="p_strDeleteOrderIDArr">医嘱ID</param>
        /// <param name="p_strDeleteContinueIDArr">连续性医嘱id(要删除相关费用)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteOrder(string[] p_strDeleteOrderIDArr, string[] p_strDeleteContinueIDArr)
        {

            int n = 0;
            long lngRes = 0;
            if (p_strDeleteOrderIDArr != null && p_strDeleteOrderIDArr.Length > 0)
            {
                string strSQL = @"  
                             update T_Opr_Bih_Order
                             set Status_Int=-2 
                             where (Status_Int=0 OR Status_Int=1 OR Status_Int=7 OR TYPE_INT<>0) and OrderID_Chr=?
                                            ";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                DbType[] dbTypes = new DbType[] { 
                        DbType.String
                       
                        };
                object[][] objValues = new object[1][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[p_strDeleteOrderIDArr.Length];//初始化
                }

                for (int k1 = 0; k1 < p_strDeleteOrderIDArr.Length; k1++)
                {

                    n = -1;
                    objValues[++n][k1] = p_strDeleteOrderIDArr[k1];

                }


                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                if (p_strDeleteContinueIDArr != null && p_strDeleteContinueIDArr.Length > 0)
                {
                    #region 同步处理费用明细表
                    strSQL = @"  
                             update 
                             T_Opr_Bih_PatientCharge
                             set STATUS_INT=0
                             where
                              PAYMONEYID_CHR is  null 
                             and 
                             exists(select 1 from t_opr_bih_order a where a.STATUS_INT=-2 and OrderID_Chr=?)
                             and  
                             OrderID_Chr=? ";

                    dbTypes = new DbType[] { 
                        DbType.String, DbType.String
                       
                        };
                    objValues = new object[2][];
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[p_strDeleteContinueIDArr.Length];//初始化
                    }

                    for (int k1 = 0; k1 < p_strDeleteContinueIDArr.Length; k1++)
                    {

                        n = -1;
                        objValues[++n][k1] = p_strDeleteContinueIDArr[k1];
                        objValues[++n][k1] = p_strDeleteContinueIDArr[k1];
                    }
                    if (p_strDeleteOrderIDArr.Length > 0)
                    {
                        long lngRes2 = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                    }

                    #endregion
                }
            }
            return lngRes;
        }

        /// <summary>
        /// 删除医嘱	[可以梯归删除子级医嘱]
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：0-创建
        /// </summary>
        /// <param name="p_strDeleteOrderIDArr">医嘱ID [数组]</param>
        /// <param name="p_blnInfectSon">是否梯归删除子级医嘱</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteOrder(string p_strDeleteOrderID, bool p_blnInfectSon)
        {
            long lngRes = 0;
            //删除本目录
            lngRes = m_lngDeleteOrder(new string[] { p_strDeleteOrderID });
            //梯归删除子级医嘱
            clsBIHOrder[] objResultArr;
            int i = 0;
            if (p_blnInfectSon && lngRes > 0)
            {
                objResultArr = null;
                lngRes = 0;
                lngRes = m_lngGetOrderByParentID(p_strDeleteOrderID, out objResultArr);
                if (lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
                {
                    for (i = 0; i < objResultArr.Length; i++)
                    {
                        if (lngRes > 0)
                        {
                            //if(objResultArr[i].m_intStatus==2 || objResultArr[i].m_intStatus==1)
                            //{
                            //	lngRes =-1;
                            //	throw(new System.Exception("只能作废状态为已提交的医嘱,包括子级医嘱！"));
                            //}
                            if (objResultArr[i].m_intStatus == 0)
                            {
                                lngRes = 0;
                                lngRes = m_lngDeleteOrder(objResultArr[i].m_strOrderID, true);
                            }
                        }
                    }
                }
            }
            if (lngRes <= 0)
            {
                throw (new System.Exception("删除医嘱失败！"));
            }
            return lngRes;
        }
        #endregion

        #region 退回医嘱
        /// <summary>
        /// 退回医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：2-执行、5-已审核提交
        /// </summary>
        /// <param name="p_strReturnOrderID">退回医嘱ID</param>
        /// <param name="p_strReturnReason">退回原因</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReturnOrder(string p_strReturnOrderID, string p_strReturnReason, string strDoctorID, string strDoctorName)
        {
            int intNewStatus = 7;
            string strSql = @"
					UPDATE t_opr_bih_order
					SET status_int = '[status_int]',
						backreason = '[backreason]',
						sendbackid_chr = '[sendbackid_chr]',
						sendbacker_chr = '[sendbacker_chr]',
						sendback_dat = TO_DATE ('[sendback_dat]', 'yyyy-mm-dd hh24:mi:ss')
					WHERE TRIM (orderid_chr) = '[orderid_chr]'";

            DateTime dtNow = DateTime.Now;
            strSql = strSql.Replace("[status_int]", intNewStatus.ToString());
            strSql = strSql.Replace("[backreason]", p_strReturnReason.Replace(",", "").Trim());
            strSql = strSql.Replace("[sendbackid_chr]", strDoctorID.Trim());
            strSql = strSql.Replace("[sendbacker_chr]", strDoctorName);
            strSql = strSql.Replace("[sendback_dat]", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
            strSql = strSql.Replace("[orderid_chr]", p_strReturnOrderID.Trim());

            long ret = 0;
            try
            {
                ret = new clsHRPTableService().DoExcute(strSql);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        /// <summary>
        /// 退回医嘱
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：2-执行、5-已审核提交
        /// </summary>
        /// <param name="p_strReturnOrderID">[数组]	退回医嘱ID</param>
        /// <param name="p_strReturnReason">退回原因</param>
        /// <param name="strDoctorID">执行者ID</param>
        /// <param name="strDoctorName">执行者姓名</param>
        /// <param name="p_blnInfectSon">是否梯归退回子级医嘱</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReturnOrder(string p_strReturnOrderID, string p_strReturnReason, string strDoctorID, string strDoctorName, bool p_blnInfectSon)
        {
            long lngRes = 0;
            //退回本目录
            lngRes = m_lngReturnOrder(p_strReturnOrderID, p_strReturnReason, strDoctorID, strDoctorName);
            //梯归退回子级医嘱
            clsBIHOrder[] objResultArr;
            int i = 0;
            if (p_blnInfectSon && lngRes > 0)
            {
                objResultArr = null;
                lngRes = 0;
                lngRes = m_lngGetOrderByParentID(p_strReturnOrderID, out objResultArr);
                if (lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
                {
                    for (i = 0; i < objResultArr.Length; i++)
                    {
                        if (lngRes > 0)
                        {
                            if (objResultArr[i].m_intStatus == 1 || objResultArr[i].m_intStatus == 5)
                            {
                                lngRes = 0;
                                lngRes = m_lngReturnOrder(objResultArr[i].m_strOrderID.ToString().Trim(), p_strReturnReason, strDoctorID, strDoctorName);
                            }
                        }
                    }
                }
            }
            if (lngRes <= 0)
            {
                throw (new System.Exception("退回医嘱失败！"));
            }
            return lngRes;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 改变医嘱执行状态
        /// </summary>
        /// <param name="p_strOrderID">医嘱ＩＤ</param>
        /// <param name="p_strDoctorID">执行医生ＩＤ</param>
        /// <param name="p_strDoctorName">执行医生名称</param>
        /// <param name="p_intStatus">执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngChangeOrderStatus(string p_strOrderID, string p_strDoctorID, string p_strDoctorName, int p_intStatus)
        {
            long lngRes = -1;
            DateTime dtNow = DateTime.Now;
            string strSql = "";
            strSql += "  update T_Opr_Bih_Order Set";
            strSql += "	 Status_Int =" + p_intStatus.ToString();
            strSql += "	,StoperID_Chr ='" + p_strDoctorID.Trim() + "'";
            strSql += "	,Stoper_Chr ='" + p_strDoctorName.Trim() + "'";
            strSql += "	,StopDate_Dat =to_date('" + dtNow.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')";
            strSql += " where trim(OrderID_Chr)='" + p_strOrderID.Trim() + "'";

            try
            {
                lngRes = 0;
                lngRes = new clsHRPTableService().DoExcute(strSql);
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
        /// 返回医嘱ID	字符串[用“,”号相隔]
        /// 作用: 保证同方号的医嘱一起操作	{提交医嘱、停止医嘱、重整医嘱、作废医嘱}
        /// </summary>
        /// <param name="p_strOrderIDArr">医嘱ID [数组]</param>
        /// <param name="p_intStatus">执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}</param>
        /// <returns></returns>
        [AutoComplete]
        private string GetOrderIDSameRecipeNO(string[] p_strOrderIDArr, int p_intStatus)
        {
            string strReturn = "";
            p_strOrderIDArr = GetOrderIDSameRecipeNOForCommit(p_strOrderIDArr, p_intStatus);
            for (int i1 = 0; i1 < p_strOrderIDArr.Length; i1++)
            {
                strReturn += ",'" + p_strOrderIDArr[i1].Trim() + "'";
            }
            if (strReturn.Length > 1) strReturn = strReturn.Substring(1);
            return strReturn;
        }
        /// <summary>
        /// 返回医嘱ID	[数组]
        /// 作用: 保证同方号的医嘱一起操作	{提交医嘱、停止医嘱、重整医嘱、作废医嘱}
        /// </summary>
        /// <param name="p_strOrderIDArr">医嘱ID [数组]</param>
        /// <param name="p_intStatus">执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}</param>
        /// <returns></returns>
        [AutoComplete]
        public string[] GetOrderIDSameRecipeNOForCommit(string[] p_strOrderIDArr, int p_intStatus)
        {
            string[] strReturnOrderIDArr = new string[0];
            if (p_strOrderIDArr.Length <= 0) return strReturnOrderIDArr;
            ArrayList myAL = new ArrayList();

            string strSQLTem = @"
					SELECT	a.orderid_chr FROM t_opr_bih_order a 
					WHERE	a.RECIPENO_INT=(select a1.RECIPENO_INT from t_opr_bih_order a1 where a1.orderid_chr='[ORDERID]') 
							and a.registerid_chr=(select a1.registerid_chr from t_opr_bih_order a1 where a1.orderid_chr='[ORDERID]')
							and a.status_int=[STATUS_INT]
					";
            #region 获取医嘱ID
            long lngRes = 0;
            string strSQL = "";
            DataTable dtbResult = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            for (int i1 = 0; i1 < p_strOrderIDArr.Length; i1++)
            {
                strSQL = strSQLTem;
                strSQL = strSQL.Replace("[ORDERID]", p_strOrderIDArr[i1].Trim());
                strSQL = strSQL.Replace("[STATUS_INT]", p_intStatus.ToString().Trim());
                try
                {
                    dtbResult = new DataTable();
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                    if (lngRes > 0 && dtbResult.Rows.Count > 0)
                    {
                        for (int i2 = 0; i2 < dtbResult.Rows.Count; i2++)
                        {
                            bool blnHaveSame = false;
                            for (int i3 = 0; i3 < myAL.Count; i3++)
                            {
                                if (myAL[i3].ToString().Trim() == dtbResult.Rows[i2]["orderid_chr"].ToString().Trim())
                                {
                                    blnHaveSame = true;
                                    break;
                                }
                            }
                            if (!blnHaveSame) myAL.Add(dtbResult.Rows[i2]["orderid_chr"].ToString());
                        }
                    }
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            objHRPSvc.Dispose();
            #endregion

            strReturnOrderIDArr = new string[myAL.Count];
            for (int i1 = 0; i1 < myAL.Count; i1++) strReturnOrderIDArr[i1] = myAL[i1].ToString().Trim();
            return strReturnOrderIDArr;
        }
        #endregion

        #region 附加单据
        [AutoComplete]
        private long m_lngCreateAttachOrderID(out string strOrderAttachID)
        {

            strOrderAttachID = "";
            string strSql = " select max(OrderAttachID_Chr) from T_Opr_Bih_OrderAttach ";

            object objValue;
            if (m_lngGetValue(strSql, out objValue) == 0) return 0;

            long intID = 0;
            if (objValue == null)
                intID = 1;
            else
                intID = clsConverter.ToLong(objValue) + 1;

            strOrderAttachID = intID.ToString().Trim().PadLeft(18, '0');
            return 1;

        }
        /// <summary>
        /// 增加附加单据影射
        /// </summary>
        /// <param name="strOrderID">>医嘱ID</param>
        /// <param name="strAttachID">医嘱附加单据ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddAttachOrder(string strOrderID, string strAttachID)
        {
            string strSql = @"
				Insert into T_Opr_Bih_OrderAttach(OrderAttachID_Chr,AttachID_Chr,OrderID_Chr)
				values('[ID]','[AttachID]','[OrderID]')
			";

            string strOrderAttachID;
            if (m_lngCreateAttachOrderID(out strOrderAttachID) < 1) return 0;

            strSql = strSql.Replace("[ID]", strOrderAttachID);
            strSql = strSql.Replace("[OrderID]", strOrderID);
            strSql = strSql.Replace("[AttachID]", strAttachID);

            long lngRes = 0;
            try
            {
                lngRes = 0;
                lngRes = new clsHRPTableService().DoExcute(strSql);
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
        /// 删除附加单据影射
        /// </summary>
        /// <param name="strID">附加单据ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteAttachOrder(string strID)
        {
            long lngRes = 0;
            string strSQL = "Delete T_Opr_Bih_OrderAttach where Trim(ATTACHID_CHR) ='" + strID.Trim() + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
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
        /// <summary>
        /// 获取附加单据影射表中的附加单据ID	根据医嘱ID
        /// </summary>
        /// <param name="strOrderID">医嘱ID</param>
        /// <param name="arrAttachID">附加单据ID	{数组}</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAttachOrder(string strOrderID, out string[] arrAttachID)
        {
            string strSql = @"
				select attarelaid_chr, sysfrom_int, attachtype_int, sourceitemid_vchr, attachid_vchr, urgency_int, status_int, chargedetail_vchr, diagnosepart_vchr, diagnosepartid_int 
 from  t_opr_attachrelation where trim(sourceitemid_vchr)=trim('[OrderID]') ";

            strSql = strSql.Replace("[OrderID]", strOrderID);

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrAttachID = new string[objDT.Rows.Count];
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    arrAttachID[i] = clsConverter.ToString(objDT.Rows[i]["ATTACHID_VCHR"]).Trim();
                }
                return 1;
            }
            else
            {
                arrAttachID = null;
                return 0;
            }
        }
        /// <summary>
        /// 获取附加单据内容对象	根据医嘱ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOrderIDArr">医嘱ID	[数组]</param>
        /// <param name="p_objResultArr">附加单据内容对象</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAttachOrderByOrderID(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strOrderIDArr, out clsOrderAttach[] p_objResultArr)
        {
            p_objResultArr = new clsOrderAttach[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }
            //			string strSQL=@"	
            //						select OrderAttachID_Chr,AttachID_Chr,OrderID_Chr 
            //						from  T_Opr_Bih_OrderAttach
            //						where Trim(OrderID_Chr)in([GETORDERID])";
            string strSQL = @"SELECT attarelaid_chr AS orderattachid_chr, attachid_vchr AS attachid_chr,
       sourceitemid_vchr AS orderid_chr
  FROM t_opr_attachrelation
 WHERE TRIM (sourceitemid_vchr) IN ([GETORDERID])";
            string strTem = "";
            if (p_strOrderIDArr != null)
            {
                for (int i1 = 0; i1 < p_strOrderIDArr.Length; i1++)
                {
                    if (i1 > 0) strTem += ",";
                    strTem += "'" + p_strOrderIDArr[i1].Trim() + "'";
                }
            }
            if (strTem.Trim() == "") strTem = "''";
            strSQL = strSQL.Replace("[GETORDERID]", strTem);
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsOrderAttach[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        p_objResultArr[i1] = new clsOrderAttach();
                        p_objResultArr[i1].m_strID = dtbResult.Rows[i1]["ATTACHID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strOrderID = dtbResult.Rows[i1]["ORDERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strCreatorID = "";
                        p_objResultArr[i1].m_strCreatorName = "";
                        p_objResultArr[i1].m_strCreateDate = "";
                        p_objResultArr[i1].m_strContent = "开发中……";
                        p_objResultArr[i1].m_intStatus = 0;
                        p_objResultArr[i1].m_strStatusName = "";
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
        /// <summary>
        /// 是否存在附加单据	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_blnExist">是否存在附加单据	[out 参数]</param>
        /// <returns></returns>
        /// <remarks>
        /// 这里只是根据附加单据影射表来判断，影射表里有则有。
        /// </remarks>
        [AutoComplete]
        public long m_lngExistAttchOrder(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOrderID, out bool p_blnExist)
        {
            p_blnExist = false;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService", "m_lngExistAttchOrder");
            if (lngRes < 0)
            {
                return -1;
            }

            string[] strAttachIDArr;
            lngRes = 0;
            lngRes = m_lngGetAttachOrder(p_strOrderID, out strAttachIDArr);
            if (lngRes > 0 && strAttachIDArr != null && strAttachIDArr.Length > 0)
            {
                p_blnExist = true;
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
            string strSQL = @"
						select a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat, a.orderid_chr, a.orderexectype_int, 
	a.orderexecid_chr, a.clacarea_chr, a.createarea_chr, a.calccateid_chr, a.invcateid_chr, a.chargeitemid_chr, 
	a.chargeitemname_chr, a.unit_vchr, a.unitprice_dec, a.amount_dec, a.discount_dec, a.ismepay_int, a.des_vchr, 
	a.createtype_int, a.creator_chr, a.create_dat, a.operator_chr, a.modify_dat, a.deactivator_chr, a.deactivate_dat, 
	a.status_int, a.pstatus_int, a.chearaccount_dat, a.dayaccountid_chr, a.paymoneyid_chr, a.activator_chr, 
	a.activatetype_int, a.isrich_int, a.isconfirmrefundment, a.refundmentchecker, a.refundmentdate, a.bmstatus_int, 
	a.curareaid_chr, a.curbedid_chr, a.doctorid_chr, a.doctor_vchr, a.doctorgroupid_chr, a.needconfirm_int, 
	a.confirmerid_chr, a.confirmer_vchr, a.confirm_dat, a.chargeactive_dat, a.insuracedesc_vchr, a.spec_vchr, 
	a.totalmoney_dec, a.acctmoney_dec, a.newdiscount_dec, a.patientnurse_int, a.attachorderid_vchr, 
	a.attachorderbasenum_dec, a.putmedicineflag_int, a.chargedoctorid_chr, a.chargedoctor_vchr, a.pchargeidorg_chr, 
	a.chargedoctorgroupid_chr, a.returnmedbillno, a.manyreturnmedill_int, a.itemchargetype_vchr,
    b.orderdicid_chr, b.name_chr, b.des_vchr, b.usercode_chr, b.wbcode_chr, b.pycode_chr, b.execdept_chr, 
	b.ordercateid_chr, b.itemid_chr, b.nullitemdosageunit_chr, b.nullitemuseunit_chr, b.nullitemdosetypeid_chr, 
	b.status_int, b.sampleid_vchr, b.partid_vchr, b.engname_vchr, b.commname_vchr, b.nullitemfreqid_vchr, 
	b.nullitemuse_dec, b.lisapplyunitid_chr, b.applytypeid_chr, b.newchargetype_int, b.opexecdept_chr,
    c.itemid_chr, c.itemname_vchr, c.itemcode_vchr, c.itempycode_chr, c.itemwbcode_chr, c.itemsrcid_vchr, 
	c.itemsrctype_int, c.itemspec_vchr, c.itemprice_mny, c.itemunit_chr, c.itemopunit_chr, c.itemipunit_chr, 
	c.itemopcalctype_chr, c.itemipcalctype_chr, c.itemopinvtype_chr, c.itemipinvtype_chr, c.dosage_dec, 
	c.dosageunit_chr, c.isgroupitem_int, c.itemcatid_chr, c.usageid_chr, c.itemopcode_chr, c.insuranceid_chr, 
	c.selfdefine_int, c.packqty_dec, c.tradeprice_mny, c.poflag_int, c.isrich_int, c.opchargeflg_int, 
	c.itemsrcname_vchr, c.itemsrctypename_vchr, c.itemengname_vchr, c.ifstop_int, c.pdcarea_vchr, 
	c.ipchargeflg_int, c.insurancetype_vchr, c.apply_type_int, c.itembihctype_chr, c.defaultpart_vchr, 
	c.itemchecktype_chr, c.itemcommname_vchr, c.ordercateid_chr, c.freqid_chr, c.inpinsurancetype_vchr, 
	c.ordercateid1_chr, c.isselfpay_chr, c.itemprice_mny_old, c.itemprice_mny_new, c.keepuse_int, c.price_temp, c.itemspec_vchr1, c.lastchange_dat,
    b.name_chr ordericname, c.itemname_vchr itemname,b.itemid_chr chiefitemid 
							,(select b0.itemname_vchr from t_bse_chargeitem b0 where b.itemid_chr=b0.itemid_chr)chiefitemname
							,decode(a.itemid_chr,b.itemid_chr,'√','×' )ischiefitem	
							,decode(a.type_int,1,'领量单位',2,'剂量单位','' )typename
							,(select b1.deptname_vchr from t_bse_deptdesc b1 where b1.deptid_chr=b.execdept_chr) execdept
							,(select b2.name_chr from t_aid_bih_ordercate b2 where b2.ordercateid_chr=b.ordercateid_chr) ordercate
							,(select b3.itemname_vchr from t_bse_chargeitem b3 where b3.itemid_chr=b.itemid_chr) item  
							,(select b4.usagename_vchr from t_bse_usagetype b4 where trim(b4.usageid_chr)=trim(b.nullitemdosetypeid_chr)) nullitemdosetypename
							,decode(c.ipchargeflg_int,1,round(c.itemprice_mny/c.packqty_dec,4),0,c.itemprice_mny,round(c.itemprice_mny/c.packqty_dec,4)) minprice
							,d.noqtyflag_int
						from
							t_aid_bih_orderdic_charge a , t_bse_bih_orderdic b , t_bse_chargeitem c,t_bse_medicine d
						where a.orderdicid_chr =b.orderdicid_chr(+) and a.itemid_chr =c.itemid_chr (+) and trim (c.itemsrcid_vchr) = trim (d.medicineid_chr(+))
							  and A.orderdicid_chr=[GETORDERID]
						order by IsChiefItem desc";
            string strGetOrderdicID = " (SELECT orderdicid_chr FROM t_opr_bih_order WHERE Trim(orderid_chr)='" + p_strOrderID.Trim() + "') ";
            strSQL = strSQL.Replace("[GETORDERID]", strGetOrderdicID);

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
                        objChargeItem = new clsT_bse_chargeitem_VO();
                        objChargeItem.m_strITEMID_CHR = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMNAME_VCHR = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
                        objChargeItem.m_strITEMCODE_VCHR = dtbResult.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
                        objChargeItem.m_strITEMPYCODE_CHR = dtbResult.Rows[i1]["ITEMPYCODE_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMWBCODE_CHR = dtbResult.Rows[i1]["ITEMWBCODE_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMSRCID_VCHR = dtbResult.Rows[i1]["ITEMSRCID_VCHR"].ToString().Trim();
                        try
                        {
                            objChargeItem.m_intITEMSRCTYPE_INT = Convert.ToInt32(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim());
                        }
                        catch { }
                        objChargeItem.m_strITEMSPEC_VCHR = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
                        try
                        {
                            objChargeItem.m_dblITEMPRICE_MNY = double.Parse(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
                        }
                        catch { }
                        objChargeItem.m_strITEMUNIT_CHR = dtbResult.Rows[i1]["ITEMUNIT_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMOPUNIT_CHR = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMIPUNIT_CHR = dtbResult.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMOPCALCTYPE_CHR = dtbResult.Rows[i1]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMIPCALCTYPE_CHR = dtbResult.Rows[i1]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMOPINVTYPE_CHR = dtbResult.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMIPINVTYPE_CHR = dtbResult.Rows[i1]["ITEMIPINVTYPE_CHR"].ToString().Trim();
                        try
                        {
                            objChargeItem.m_dblDOSAGE_DEC = double.Parse(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
                        }
                        catch { }
                        objChargeItem.m_strDOSAGEUNIT_CHR = dtbResult.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim();
                        try
                        {
                            objChargeItem.m_intISGROUPITEM_INT = Convert.ToInt32(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim());
                        }
                        catch { }
                        objChargeItem.m_strITEMCATID_CHR = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
                        objChargeItem.m_strUSAGEID_CHR = dtbResult.Rows[i1]["USAGEID_CHR"].ToString().Trim();
                        objChargeItem.m_strITEMOPCODE_CHR = dtbResult.Rows[i1]["ITEMOPCODE_CHR"].ToString().Trim();
                        objChargeItem.m_strINSURANCEID_CHR = dtbResult.Rows[i1]["INSURANCEID_CHR"].ToString().Trim();
                        //非字段
                        try
                        {
                            objChargeItem.m_intSELFDEFINE_INT = Convert.ToInt32(dtbResult.Rows[i1]["SELFDEFINE_INT"].ToString().Trim());
                        }
                        catch { }
                        try
                        {
                            objChargeItem.m_dblPACKQTY_DEC = double.Parse(dtbResult.Rows[i1]["PACKQTY_DEC"].ToString().Trim());
                        }
                        catch { }
                        try
                        {
                            objChargeItem.m_dblTRADEPRICE_MNY = double.Parse(dtbResult.Rows[i1]["TRADEPRICE_MNY"].ToString().Trim());
                        }
                        catch { }
                        try
                        {
                            objChargeItem.m_intPOFLAG_INT = Convert.ToInt32(dtbResult.Rows[i1]["POFLAG_INT"].ToString().Trim());
                        }
                        catch { }
                        //非字段
                        try
                        {
                            objChargeItem.m_dblMinPrice = double.Parse(dtbResult.Rows[i1]["MinPrice"].ToString());
                        }
                        catch { }

                        p_objResultArr[i1].m_objChargeItem = objChargeItem;
                        #endregion
                        #region 诊疗项目对象
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
                        #endregion
                        #region 影射对象
                        p_objResultArr[i1].m_strOCMAPID_CHR = dtbResult.Rows[i1]["OCMAPID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strORDERDICID_CHR = dtbResult.Rows[i1]["ORDERDICID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strITEMID_CHR = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intQTY_INT = clsConverter.ToDecimal(dtbResult.Rows[i1]["QTY_INT"].ToString());
                        p_objResultArr[i1].m_intTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["TYPE_INT"].ToString());
                        //非字段
                        p_objResultArr[i1].m_strItemName = dtbResult.Rows[i1]["ItemName"].ToString().Trim();
                        p_objResultArr[i1].m_strOrdericName = dtbResult.Rows[i1]["OrdericName"].ToString().Trim();
                        p_objResultArr[i1].m_strChiefItemID = dtbResult.Rows[i1]["ChiefItemID"].ToString().Trim();
                        p_objResultArr[i1].m_strChiefItemName = dtbResult.Rows[i1]["ChiefItemName"].ToString().Trim();
                        p_objResultArr[i1].m_strIsChiefItem = dtbResult.Rows[i1]["IsChiefItem"].ToString().Trim();
                        p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        p_objResultArr[i1].m_strNoqtyFLag = dtbResult.Rows[i1]["noqtyflag_int"].ToString().Trim();
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

        #region 修改医嘱
        /// <summary>
        /// 医生修改未提交医嘱的内容
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyOrder(clsBIHOrder objOrder)
        {
            string strSql = @"update t_opr_bih_order
                                   set orderdicid_chr = ?,
                                       registerid_chr = ?,
                                       patientid_chr = ?,
                                       executetype_int = ?,
                                       recipeno_int = ?,
                                       name_vchr = ?,
                                       spec_vchr = ?,
                                       execfreqid_chr = ?,
                                       execfreqname_chr = ?,
                                       dosage_dec = ?,
                                       dosageunit_chr = ?,
                                       get_dec = ?,
                                       getunit_chr = ?,
                                       use_dec = ?,
                                       useunit_chr = ?,
                                       dosetypeid_chr = ?,
                                       dosetypename_chr = ?,
                                       entrust_vchr = ?,
                                       parentid_chr = ?,
                                       status_int = ?,
                                       isrich_int = ?,
                                       ratetype_int = ?,
                                       isrepare_int = ?,
                                       creatorid_chr = ?,
                                       creator_chr = ?,
                                       createdate_dat = ?,
                                       isneedfeel = ?,
                                       outgetmeddays_int = ?,
                                       startdate_dat = ?,
                                       sampleid_vchr = ?,
                                       lisappid_vchr = ?,
                                       partid_vchr = ?,
                                       finishdate_dat = ?,
                                       attachtimes_int = ?,
                                       doctorid_chr = ?,
                                       doctor_vchr = ?,
                                       stoperid_chr = ?,
                                       stoper_chr = ?,
                                       stopdate_dat = ?,
                                       remark_vchr = ?,
                                       charge_int = ?,
                                       assessoridforexec_chr = ?,
                                       assessorforexec_chr = ?,
                                       assessorforexec_dat = sysdate,
                                       singleamount_dec = ?,
                                       antiUse = ?, 
                                       antiUse_yflx = ?, 
                                       curedays = ?,
                                       isproxyboilmed = ? 
                                 where orderid_chr = ? ";
            /*<=========================================================================*/
            /*可以修改的字段为：
           objOrder.m_intRecipenNo  m_intExecuteType m_strOrderDicID m_strName m_strSpec
           m_strDosageUnit m_strUseunit m_strGetunit m_strExecDeptID m_strExecDeptName
           m_intIsRich m_dmlPrice m_dmlDosageRate m_dmlDosage m_dmlUse
           m_dmlGet m_strExecFreqID m_strExecFreqName m_strDosetypeID m_strDosetypeName
           m_strEntrust m_intRateType m_strDOCTORID_CHR m_strDOCTOR_VCHR m_strParentName
           m_strParentID m_strOrderDicCateID m_strSAMPLEID_VCHR m_strSAMPLEName_VCHR m_strPARTID_VCHR
           m_strPARTNAME_VCHR m_strCREATEAREA_ID  m_strCREATEAREA_Name m_intOUTGETMEDDAYS_INT m_intATTACHTIMES_INT
           m_dtStartDate m_dtFinishDate m_strDOCTORGROUPID_CHR  m_strCURAREAID_CHR m_strCURBEDID_CHR
           *<==================================================*/

            System.Data.IDataParameter[] arrParams = null;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            objHRPSvc.CreateDatabaseParameter(49, out arrParams);
            int n = -1;
            arrParams[++n].Value = objOrder.m_strOrderDicID;
            arrParams[++n].Value = objOrder.m_strRegisterID;
            arrParams[++n].Value = objOrder.m_strPatientID;
            arrParams[++n].Value = objOrder.m_intExecuteType;
            arrParams[++n].Value = objOrder.m_intRecipenNo;

            arrParams[++n].Value = objOrder.m_strName;
            arrParams[++n].Value = objOrder.m_strSpec;
            arrParams[++n].Value = objOrder.m_strExecFreqID;
            arrParams[++n].Value = objOrder.m_strExecFreqName;
            if (objOrder.m_dmlDosage > 0)
                arrParams[++n].Value = objOrder.m_dmlDosage;
            else
                arrParams[++n].Value = null;


            arrParams[++n].Value = objOrder.m_strDosageUnit;
            if (objOrder.m_dmlGet > 0)
                arrParams[++n].Value = objOrder.m_dmlGet;
            else
                arrParams[++n].Value = null;
            arrParams[++n].Value = objOrder.m_strGetunit;
            if (objOrder.m_dmlGet > 0)
                arrParams[++n].Value = objOrder.m_dmlDosageRate;//objOrder.m_dmlUse;
            else
                arrParams[++n].Value = null;
            arrParams[++n].Value = objOrder.m_strDosageUnit;//objOrder.m_strUseunit;


            arrParams[++n].Value = objOrder.m_strDosetypeID;
            arrParams[++n].Value = objOrder.m_strDosetypeName;
            arrParams[++n].Value = objOrder.m_strEntrust;
            arrParams[++n].Value = objOrder.m_strParentID;
            arrParams[++n].Value = objOrder.m_intStatus;

            arrParams[++n].Value = objOrder.m_intIsRich;
            arrParams[++n].Value = objOrder.RateType;
            arrParams[++n].Value = objOrder.m_intIsRepare;
            arrParams[++n].Value = objOrder.m_strCreatorID;
            arrParams[++n].Value = objOrder.m_strCreator;


            arrParams[++n].Value = objOrder.m_dtCreatedate;
            arrParams[++n].Value = objOrder.m_intISNEEDFEEL;
            arrParams[++n].Value = objOrder.m_intOUTGETMEDDAYS_INT;
            if (objOrder.m_dtStartDate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtStartDate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            arrParams[++n].Value = objOrder.m_strSAMPLEID_VCHR;


            arrParams[++n].Value = objOrder.m_strLISAPPID_VCHR;
            arrParams[++n].Value = objOrder.m_strPARTID_VCHR;
            if (objOrder.m_dtFinishDate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtFinishDate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            if (objOrder.m_intExecuteType == 1)
            {
                arrParams[++n].Value = objOrder.m_intATTACHTIMES_INT;
            }
            else
            {
                arrParams[++n].Value = 0;
            }
            arrParams[++n].Value = objOrder.m_strDOCTORID_CHR;
            arrParams[++n].Value = objOrder.m_strDOCTOR_VCHR;
            arrParams[++n].Value = objOrder.m_strStoperID;
            arrParams[++n].Value = objOrder.m_strStoper;
            if (objOrder.m_dtStopdate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtStopdate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            arrParams[++n].Value = objOrder.m_strREMARK_VCHR;
            arrParams[++n].Value = objOrder.m_intCHARGE_INT;
            arrParams[++n].Value = objOrder.m_strChangedID_CHR;
            arrParams[++n].Value = objOrder.m_strChangedName_CHR;
            arrParams[++n].Value = objOrder.m_dmlOneUse;

            arrParams[++n].Value = objOrder.AntiUse;
            arrParams[++n].Value = objOrder.AntiUse_YFLX;
            arrParams[++n].Value = objOrder.CureDays;
            arrParams[++n].Value = objOrder.IsProxyBoilMed;

            arrParams[++n].Value = objOrder.m_strOrderID;

            long lngAff = 0;
            long ret = 0;
            try
            {
                ret = 0;
                long lngRecEff = 0;
                ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);

                //往表增加记录 
                //如果是长嘱转临嘱将删除显示方号
                if (objOrder.m_intExecuteType != 1)
                {

                    strSql = @"update t_opr_bih_order set RECIPENO2_INT = null where orderid_chr = ? ";
                    System.Data.IDataParameter[] Params4 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out Params4);
                    Params4[0].Value = objOrder.m_strOrderID;
                    ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, Params4);
                }
                else
                {
                    //如果是临嘱转长嘱将新增显示方号
                    if (objOrder.m_intRecipenNo2 == 0)
                    {
                        strSql = @"update t_opr_bih_order
                                       set RECIPENO2_INT = decode((select max(a.recipeno2_int) recipeno2_int
                                                                    from t_opr_bih_order a
                                                                   where EXECUTETYPE_INT = 1
                                                                     and STATUS_INT <> -2
                                                                     and OPERATION_INT = 0
                                                                     and a.registerid_chr = ?),
                                                                  null,
                                                                  1,
                                                                  (select max(a.recipeno2_int) + 1 recipeno2_int
                                                                     from t_opr_bih_order a
                                                                    where EXECUTETYPE_INT = 1
                                                                      and STATUS_INT <> -2
                                                                      and OPERATION_INT = 0
                                                                      and a.registerid_chr = ?))
                                     where orderid_chr = ?";
                        System.Data.IDataParameter[] Params4 = null;
                        objHRPSvc.CreateDatabaseParameter(3, out Params4);
                        Params4[0].Value = objOrder.m_strRegisterID.Trim();
                        Params4[1].Value = objOrder.m_strRegisterID.Trim();
                        Params4[2].Value = objOrder.m_strOrderID;
                        ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, Params4);
                    }
                }
                if (ret > 0)
                {
                    string strSQL = @"delete from T_OPR_BIH_ORDERCHARGEDEPT where ORDERID_CHR = ? ";

                    arrParams = null;
                    objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                    //Please change the datetime and reocrdid 
                    arrParams[0].Value = objOrder.m_strOrderID;
                    long lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams);
                    objHRPSvc.Dispose();
                    //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT] 
                    ArrayList m_arrORDERCHARGEDEPT = new ArrayList();
                    ExecOrderToChargeItem(objOrder, ref  m_arrORDERCHARGEDEPT);
                    UsageToChargeItem(objOrder, ref m_arrORDERCHARGEDEPT);
                    ret = UpdateOrderToChargeItem(objOrder, (clsORDERCHARGEDEPT_VO[])m_arrORDERCHARGEDEPT.ToArray((new clsORDERCHARGEDEPT_VO()).GetType()));
                }
            }
            catch (Exception objEx)
            {
                if (ret > 0)
                {
                    throw new Exception(objEx.Message);
                }
                else
                {
                    string strTmp = objEx.Message;

                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }

            if (ret > 0)
                return 1;
            else
                return 0;
        }

        #region  查询医嘱是否满足状态
        /// <summary>
        /// 查询医嘱是否满足状态 //由于医嘱修改方面还有方法存在于clsBIHORDERCHARGEDService当中，此方法将Copy至clsBIHORDERCHARGEDService类当中。若要修改，请先得两者都得修改
        /// </summary>
        /// <param name="arrOrderID">OrderID数组</param>
        /// <param name="ArrFlag">需要满足的状态</param>
        /// <param name="Exist"></param>
        /// <returns>如果并不是全部满足是返回false 全部满足则返回True</returns>
        [AutoComplete]
        public long m_lngCheckOrderStatus(ArrayList arrOrderID, ArrayList ArrFlag, ref bool Exist)
        {
            long lngRes = -1;
            Exist = true;
            DataTable dt = new DataTable();
            string sql = string.Empty;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (arrOrderID.Count == 1)
                {
                    sql = @"select a.status_int from t_opr_bih_order a where a.orderid_chr = ?";
                    IDataParameter[] param = null;
                    objHRPSvc.CreateDatabaseParameter(1, out param);
                    param[0].Value = arrOrderID[0].ToString();

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(sql, ref dt, param);
                }
                else if (arrOrderID.Count > 0)
                {
                    sql = @"select a.status_int from t_opr_bih_order a where a.orderid_chr in ([arrOrderID])";
                    string strOrderid = "";
                    foreach (Object objTmp in arrOrderID)
                    {
                        strOrderid += "'" + arrOrderID + "',";
                    }
                    strOrderid = strOrderid.TrimEnd(',');
                    sql = sql.Replace("[arrOrderID]", strOrderid);

                    lngRes = objHRPSvc.DoGetDataTable(sql, ref dt);
                }
                objHRPSvc.Dispose();

                for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                {
                    if (!ArrFlag.Contains(int.Parse(dt.Rows[i1][0].ToString())))
                    {
                        Exist = false;
                        return lngRes;
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

        /// <summary>
        /// 医生修改未提交医嘱的内容
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns>返回-10代表医嘱不能再改变了</returns>
        [AutoComplete]
        public long m_lngModifyOrder(clsBIHOrder objOrder, clsBIHOrder[] arrOrder)
        {
            if (objOrder.m_intStatus != 0)
            {
                ArrayList arrOrderID = new ArrayList();
                arrOrderID.Add(objOrder.m_strOrderID);
                for (int i1 = 0; i1 < arrOrder.Length; i1++)
                {
                    if (!arrOrderID.Contains(arrOrder[i1].m_strOrderID))
                    {
                        arrOrderID.Add(arrOrder[i1].m_strOrderID);
                    }
                }
                int[] intFlag = new int[] { 0, 1 };
                ArrayList arrFlag = new ArrayList();
                arrFlag.AddRange(intFlag);

                bool blnExist = false;
                long lngExist = this.m_lngCheckOrderStatus(arrOrderID, arrFlag, ref blnExist);
                if (lngExist < 0 || blnExist == false)
                {
                    return -10;
                }
            }

            long lngRes = m_lngModifyOrder(objOrder);
            //修改同方的医嘱
            if (lngRes > 0)
            {
                //修改同方医嘱
                if (arrOrder != null)
                {
                    if (arrOrder.Length > 1)
                    {
                        lngRes = m_lngChangeOrderBySameNO(objOrder.m_strOrderID, arrOrder);
                    }
                    else if (arrOrder.Length == 1)
                    {
                        //如果不是同方医嘱的主收费项就删除用法带出的费用
                        lngRes = m_lngDeleChangeofOrder(objOrder);
                    }
                }
            }
            return lngRes;
        }

        /// <summary>
        /// 如果不是同方医嘱的主收费项就删除用法带出的费用
        /// </summary>
        /// <param name="m_strOrderID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleChangeofOrder(clsBIHOrder objOrder)
        {
            string strSql = "";
            long lngAff = 0;
            long lngRes = 0;
            try
            {

                clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = @"
                    delete from T_OPR_BIH_ORDERCHARGEDEPT where ORDERID_CHR=? and FLAG_INT=2 and ORDERID_CHR<>(select min(ORDERID_CHR) from t_opr_bih_order a where a.recipeno_int=? and a.registerid_chr=? )
                    ";
                System.Data.IDataParameter[] arrParams = null;
                arrParams = null;
                objHRPSvc.CreateDatabaseParameter(3, out arrParams);
                //Please change the datetime and reocrdid 
                arrParams[0].Value = objOrder.m_strOrderID;
                arrParams[1].Value = objOrder.m_intRecipenNo;
                arrParams[2].Value = objOrder.m_strRegisterID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams);
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
        /// 医生修改未提交医嘱的内容	带有子医嘱，子医嘱只更改频率和用法
        /// 注意：这里是个事务
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyOrderWithSon(clsBIHOrder objOrder)
        {
            long lngRes = 0;
            //修改父级医嘱
            lngRes = m_lngModifyOrder(objOrder);
            //修改子级医嘱	{类型、频率、用法}
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (lngRes > 0)
                {
                    string strSql = @"
				update T_Opr_Bih_Order
				set ExecFreqID_Chr=?,ExecFreqName_Chr=?,DoseTypeID_Chr=?,DoseTypeName_Chr=?,EXECUTETYPE_INT=?
                ,STARTDATE_DAT=?,FINISHDATE_DAT=?,ATTACHTIMES_INT=?,DOCTORID_CHR=?,DOCTOR_VCHR=?,STOPERID_CHR=?,STOPER_CHR=?,STOPDATE_DAT=?  
				where registerid_chr =? and RECIPENO_INT=? ";
                    System.Data.IDataParameter[] arrParams = null;
                    objHRPSvc.CreateDatabaseParameter(15, out arrParams);
                    int n = -1;
                    arrParams[++n].Value = objOrder.m_strExecFreqID;
                    arrParams[++n].Value = objOrder.m_strExecFreqName;
                    arrParams[++n].Value = objOrder.m_strDosetypeID;
                    arrParams[++n].Value = objOrder.m_strDosetypeName;
                    arrParams[++n].Value = objOrder.m_intExecuteType;

                    arrParams[++n].Value = objOrder.m_dtStartDate;
                    arrParams[++n].Value = objOrder.m_dtFinishDate;
                    arrParams[++n].Value = objOrder.m_intATTACHTIMES_INT;
                    arrParams[++n].Value = objOrder.m_strDOCTORID_CHR;
                    arrParams[++n].Value = objOrder.m_strDOCTOR_VCHR;

                    arrParams[++n].Value = objOrder.m_strStoperID;
                    arrParams[++n].Value = objOrder.m_strStoper;
                    if (objOrder.m_dtStopdate != DateTime.MinValue)
                    {
                        arrParams[++n].Value = objOrder.m_dtStopdate;
                    }
                    else
                    {
                        arrParams[++n].Value = null;
                    }
                    arrParams[++n].Value = objOrder.m_strRegisterID;
                    arrParams[++n].Value = objOrder.m_intRecipenNo;
                    long lngAff = 0;
                    lngRes = 0;
                    //lngRes = new clsHRPTableService().lngExecuteParameterSQL(strSql, ref lngAff, arrParams[1], arrParams[2], arrParams[3], arrParams[4], arrParams[5], arrParams[0]);
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);
                    if (lngRes > 0)
                    {
                        //如果是长嘱转临嘱将删除显示方号
                        if (objOrder.m_intExecuteType != 1)
                        {

                            strSql = @"
                            update t_opr_bih_order 
                            set
                            RECIPENO2_INT=null
                            where registerid_chr =? and RECIPENO_INT=? ";
                            System.Data.IDataParameter[] Params4 = null;
                            objHRPSvc.CreateDatabaseParameter(2, out Params4);
                            Params4[0].Value = objOrder.m_strRegisterID;
                            Params4[1].Value = objOrder.m_intRecipenNo;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, Params4);

                        }
                        else
                        {
                            //如果是临嘱转长嘱将新增显示方号
                            if (objOrder.m_intRecipenNo2 == 0)
                            {
                                strSql = @"
                            update t_opr_bih_order 
                            set
                            RECIPENO2_INT=
                            decode(
                            (select max(a.recipeno2_int) recipeno2_int from t_opr_bih_order a where  EXECUTETYPE_INT=1 and OPERATION_INT=0 and a.registerid_chr=? )
                            ,null,
                             1,
                             (select max(a.recipeno2_int)+1 recipeno2_int from t_opr_bih_order a where EXECUTETYPE_INT=1 and OPERATION_INT=0 and a.registerid_chr=?) 
                              )
                            where orderid_chr=?";
                                System.Data.IDataParameter[] Params4 = null;
                                objHRPSvc.CreateDatabaseParameter(3, out Params4);
                                Params4[0].Value = objOrder.m_strRegisterID.Trim();
                                Params4[1].Value = objOrder.m_strRegisterID.Trim();
                                Params4[2].Value = objOrder.m_strOrderID;
                                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, Params4);
                                //同步子医嘱的显示方号
                                strSql = @"
                            update t_opr_bih_order 
                            set
                            RECIPENO2_INT=(select a.recipeno2_int from t_opr_bih_order a where a.orderid_chr=?)
                             where registerid_chr =? and RECIPENO_INT=? ";
                                System.Data.IDataParameter[] Params5 = null;
                                objHRPSvc.CreateDatabaseParameter(3, out Params5);
                                Params5[0].Value = objOrder.m_strOrderID;
                                Params5[1].Value = objOrder.m_strRegisterID;
                                Params5[2].Value = objOrder.m_intRecipenNo;
                                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, Params5);

                            }
                        }
                    }
                    //往表增加记录 
                    if (lngRes > 0)
                    {

                        string strSQL = @"
                    delete from T_OPR_BIH_ORDERCHARGEDEPT a
                    where
                    a.orderid_chr =?
                    ";

                        System.Data.IDataParameter[] arrParams2 = null;
                        objHRPSvc.CreateDatabaseParameter(1, out arrParams2);
                        //Please change the datetime and reocrdid 
                        arrParams2[0].Value = objOrder.m_strOrderID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams2);

                        objHRPSvc.Dispose();
                        //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT]
                        //clsBIHORDERCHARGEDService OrderCharge = new clsBIHORDERCHARGEDService();
                        //OrderCharge.ExecOrderToChargeItem(objOrder.m_strOrderID, objOrder.m_strCREATEAREA_ID);
                        //OrderCharge.UsageToChargeItem(objOrder.m_strOrderID, objOrder.m_strCREATEAREA_ID);
                        ExecOrderToChargeItem(objOrder);
                        UsageToChargeItem(objOrder);
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
        /// <summary>
        /// 填充医嘱的停止时间
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_dtStopTime">停止时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFillConOrderStopTime(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOrderID, DateTime p_dtStopTime)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyOrderFeel");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = p_dtStopTime.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "";
            strSQL += "UPDATE T_Opr_Bih_Order A SET ";
            strSQL += "   A.STOPDATE_DAT =TO_DATE('" + strDateTime.Trim() + "','YYYY-MM-DD hh24:mi:ss')";
            strSQL += "	Where Trim(A.OrderID_Chr)='" + p_strOrderID.Trim() + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
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

        #region 新增医嘱
        /// <summary>
        /// 医生创建医嘱(状态0) 
        /// </summary>
        /// <param name="objOrder">医嘱Vo对象</param>
        [AutoComplete]
        public long m_lngCreateOrder(clsBIHOrder objOrder)
        {
            string strSql = @"
				insert into T_Opr_Bih_Order(
					OrderID_Chr,OrderDicID_Chr,RegisterID_Chr,PatientID_Chr,ExecuteType_Int,RecipeNo_Int,
					Name_VChr,Spec_VChr,ExecFreqID_Chr,ExecFreqName_Chr,Dosage_Dec,DosageUnit_Chr,
					Get_Dec,GetUnit_Chr,Use_Dec,UseUnit_Chr,DoseTypeID_Chr,DoseTypeName_Chr,
					Entrust_Vchr,ParentID_Chr,Status_Int,IsRich_Int,
					RateType_Int,IsRepare_Int,CreatorID_Chr,Creator_Chr,CreateDate_Dat,ISNEEDFEEL,OUTGETMEDDAYS_INT, antiUse, antiUse_yflx, curedays, checkstate, isproxyboilmed)
				values( ?,?,?,  ?,?,?,
						?,?,?,  ?,?,?,
						?,?,?,  ?,?,?,
						?,?,?,  ?,?,?,
						?,?,?,  ?,?,?, ?, ?, ?, ?)
			";


            //
            string strOrderID = "";
            if (m_lngCreateOrderID(out strOrderID) < 1) return 0;
            objOrder.m_strOrderID = strOrderID;

            if (objOrder.m_intRecipenNo <= 0)
            {
                int intRecipeNo = 0;
                if (m_lngCreateRecipeNO(objOrder.m_strRegisterID, objOrder.m_strPatientID, out intRecipeNo) < 1) return 0;
                objOrder.m_intRecipenNo = intRecipeNo;
            }

            objOrder.m_intStatus = 0;

            //
            OracleParameter[] arrParams = new OracleParameter[34];
            for (int i = 0; i < arrParams.Length; i++) arrParams[i] = new OracleParameter();
            arrParams[0].Value = objOrder.m_strOrderID;
            arrParams[1].Value = objOrder.m_strOrderDicID;
            arrParams[2].Value = objOrder.m_strRegisterID;
            arrParams[3].Value = objOrder.m_strPatientID;
            arrParams[4].Value = objOrder.m_intExecuteType;
            arrParams[4].OracleDbType = OracleDbType.Int32;
            arrParams[5].Value = objOrder.m_intRecipenNo;
            arrParams[5].OracleDbType = OracleDbType.Int32;

            arrParams[6].Value = objOrder.m_strName;
            arrParams[7].Value = objOrder.m_strSpec;
            arrParams[8].Value = objOrder.m_strExecFreqID;
            arrParams[9].Value = objOrder.m_strExecFreqName;
            if (objOrder.m_dmlDosage > 0)
                arrParams[10].Value = objOrder.m_dmlDosage;
            else
                arrParams[10].Value = null;
            arrParams[10].OracleDbType = OracleDbType.Decimal;
            arrParams[11].Value = objOrder.m_strDosageUnit;

            if (objOrder.m_dmlDosage > 0)
                arrParams[12].Value = objOrder.m_dmlGet;
            else
                arrParams[12].Value = null;
            arrParams[12].OracleDbType = OracleDbType.Decimal;
            arrParams[13].Value = objOrder.m_strGetunit;
            if (objOrder.m_dmlUse > 0)
                arrParams[14].Value = objOrder.m_dmlUse;
            else
                arrParams[14].Value = null;
            arrParams[14].OracleDbType = OracleDbType.Decimal;
            arrParams[15].Value = objOrder.m_strUseunit;
            arrParams[16].Value = objOrder.m_strDosetypeID;
            arrParams[17].Value = objOrder.m_strDosetypeName;
            arrParams[18].Value = objOrder.m_strEntrust;
            arrParams[19].Value = objOrder.m_strParentID;
            arrParams[20].Value = objOrder.m_intStatus;
            arrParams[20].OracleDbType = OracleDbType.Int32;
            arrParams[21].Value = objOrder.m_intIsRich;
            arrParams[21].OracleDbType = OracleDbType.Int32;

            arrParams[22].Value = objOrder.RateType;
            arrParams[22].OracleDbType = OracleDbType.Int32;
            arrParams[23].Value = objOrder.m_intIsRepare;
            arrParams[23].OracleDbType = OracleDbType.Int32;

            arrParams[24].Value = objOrder.m_strCreatorID;
            arrParams[25].Value = objOrder.m_strCreator;
            arrParams[26].Value = objOrder.m_dtCreatedate;
            arrParams[26].OracleDbType = OracleDbType.Date;
            arrParams[27].Value = objOrder.m_intISNEEDFEEL;
            arrParams[27].OracleDbType = OracleDbType.Int32;
            arrParams[28].Value = objOrder.m_intOUTGETMEDDAYS_INT;
            arrParams[28].OracleDbType = OracleDbType.Int32;
            arrParams[29].Value = objOrder.AntiUse;
            arrParams[29].OracleDbType = OracleDbType.Int32;
            arrParams[30].Value = objOrder.AntiUse_YFLX;
            arrParams[30].OracleDbType = OracleDbType.Int32;
            arrParams[31].Value = objOrder.CureDays;
            arrParams[31].OracleDbType = OracleDbType.Int32;
            arrParams[32].Value = 0;
            arrParams[32].OracleDbType = OracleDbType.Int32;
            arrParams[33].Value = objOrder.IsProxyBoilMed;
            arrParams[33].OracleDbType = OracleDbType.Int32;
            long lngAff = 0;
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().lngExecuteParameterSQL(strSql, ref lngAff,
                    arrParams[0], arrParams[1], arrParams[2], arrParams[3], arrParams[4], arrParams[5],
                    arrParams[6], arrParams[7], arrParams[8], arrParams[9], arrParams[10], arrParams[11],
                    arrParams[12], arrParams[13], arrParams[14], arrParams[15], arrParams[16], arrParams[17],
                    arrParams[18], arrParams[19], arrParams[20], arrParams[21], arrParams[22], arrParams[23],
                    arrParams[24], arrParams[25], arrParams[26], arrParams[27], arrParams[28], arrParams[29], arrParams[30]
                    );
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (ret > 0)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 新建医嘱
        /// </summary>
        /// <param name="p_strRecordID">医嘱ID	[out 参数]</param>
        /// <param name="p_objRecord">医嘱Vo对象</param>
        /// <param name="intRecipeNo">方号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOrder(out string p_strRecordID, clsBIHOrder p_objRecord)
        {
            p_strRecordID = "";
            long lngRes = -1;
            if (p_objRecord.m_intIsSubOrderAdd == 0)
            {
                lngRes = m_lngAddNewOrderNotSubAdd(out p_strRecordID, p_objRecord);

            }
            else if (p_objRecord.m_intIsSubOrderAdd == 1)
            {
                lngRes = m_lngAddNewOrderSubAdd(out p_strRecordID, p_objRecord);
            }

            /*<=====================================================*/
            return lngRes;
        }

        /// <summary>
        /// 新建医嘱-并修改同方医嘱
        /// </summary>
        /// <param name="p_strRecordID">医嘱ID	[out 参数]</param>
        /// <param name="p_objRecord">医嘱Vo对象</param>
        /// <param name="intRecipeNo">方号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOrderAndChanged(clsBIHOrder p_objRecord, clsBIHOrder[] arrOrder)
        {
            string p_strRecordID = "";
            long lngRes = 0;
            if (p_objRecord.m_intIsSubOrderAdd == 1)
            {
                //修改同方医嘱
                if (arrOrder != null && arrOrder.Length > 0)
                {
                    lngRes = m_lngChangeOrderBySameNO(arrOrder);
                }
                lngRes = m_lngAddNewOrderSubAdd(out p_strRecordID, p_objRecord);
            }

            /*<=====================================================*/
            return lngRes;
        }

        /// <summary>
        /// 修改同方医嘱 -批处理 (用于医嘱界面对同方医嘱的新增操作后的同步修改)
        /// </summary>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        private long m_lngChangeOrderBySameNO(clsBIHOrder[] arrOrder)
        {

            int n = 0;
            long lngRes = 0;
            string strSQL = @"  
	            update T_Opr_Bih_Order
				set GET_DEC=?,DOSETYPEID_CHR=?,DOSETYPENAME_CHR=?,EXECFREQID_CHR = ? ,EXECFREQNAME_CHR=?,ISNEEDFEEL=?,OUTGETMEDDAYS_INT=?,REMARK_VCHR=?
                where OrderID_Chr =? ";

            DbType[] dbTypes = new DbType[] { 
                        DbType.Int32,DbType.String,DbType.String,DbType.String,DbType.String,DbType.Int32,DbType.Int32,DbType.String,DbType.String
                        };
            object[][] objValues = new object[9][];
            for (int j = 0; j < objValues.Length; j++)
            {
                objValues[j] = new object[arrOrder.Length];//初始化
            }
            for (int k1 = 0; k1 < arrOrder.Length; k1++)
            {
                clsBIHOrder order = arrOrder[k1];
                n = -1;
                objValues[++n][k1] = order.m_dmlGet;
                objValues[++n][k1] = order.m_strDosetypeID;
                objValues[++n][k1] = order.m_strDosetypeName;
                objValues[++n][k1] = order.m_strExecFreqID;
                objValues[++n][k1] = order.m_strExecFreqName;
                objValues[++n][k1] = order.m_intISNEEDFEEL;
                objValues[++n][k1] = order.m_intOUTGETMEDDAYS_INT;
                objValues[++n][k1] = order.m_strREMARK_VCHR;
                objValues[++n][k1] = order.m_strOrderID;
            }
            try
            {
                if (arrOrder.Length > 0)
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                    if (lngRes > 0)
                    {
                        #region 删除相关费用表
                        strSQL = @"
                        delete from T_OPR_BIH_ORDERCHARGEDEPT where ORDERID_CHR=? ";
                        dbTypes = new DbType[] { 
                        DbType.String
                        };
                        objValues = new object[1][];
                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[arrOrder.Length];//初始化
                        }
                        for (int k1 = 0; k1 < arrOrder.Length; k1++)
                        {
                            clsBIHOrder order = arrOrder[k1];
                            n = -1;
                            objValues[++n][k1] = order.m_strOrderID;
                        }
                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                        //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT]
                        for (int i = 0; i < arrOrder.Length; i++)
                        {
                            //clsBIHOrder objOrder = arrOrder[i];
                            //ExecOrderToChargeItem(objOrder);
                            //if (i == 0)
                            //{
                            //    UsageToChargeItem(objOrder);
                            //}
                            //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT]
                            ArrayList m_arrORDERCHARGEDEPT = new ArrayList();
                            clsBIHOrder objOrder = arrOrder[i];
                            ExecOrderToChargeItem(objOrder, ref m_arrORDERCHARGEDEPT);
                            if (i == 0)
                            {
                                UsageToChargeItem(objOrder, ref m_arrORDERCHARGEDEPT);
                            }
                            lngRes = UpdateOrderToChargeItem(objOrder, (clsORDERCHARGEDEPT_VO[])m_arrORDERCHARGEDEPT.ToArray((new clsORDERCHARGEDEPT_VO()).GetType()));

                        }
                        #endregion
                        objHRPSvc.Dispose();

                    }
                }
            }
            catch (Exception objEx)
            {

                if (lngRes > 0)
                {
                    throw new Exception(objEx.Message);
                }
                else
                {
                    string strTmp = objEx.Message;

                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            return lngRes;

        }

        /// <summary>
        /// 修改同方医嘱 -批处理 (用于医嘱界面对同方医嘱的修改操作)
        /// </summary>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        private long m_lngChangeOrderBySameNO(string m_strOrderID, clsBIHOrder[] arrOrder)
        {

            int n = 0;
            long lngRes = 0;
            string strSQL = @"update t_opr_bih_order
                                   set executetype_int   = (select executetype_int
                                                              from t_opr_bih_order
                                                             where orderid_chr = ?),
                                       recipeno2_int     = (select recipeno2_int
                                                              from t_opr_bih_order
                                                             where orderid_chr = ?),
                                       get_dec           = ?,
                                       dosetypeid_chr    = ?,
                                       dosetypename_chr  = ?,
                                       execfreqid_chr    = ?,
                                       execfreqname_chr  = ?,
                                       isneedfeel        = ?,
                                       outgetmeddays_int = ?,
                                       remark_vchr       = ?,
                                       attachtimes_int   = ?,
                                       entrust_vchr      = (select entrust_vchr
                                                              from t_opr_bih_order
                                                             where orderid_chr = ?)
                                 where orderid_chr = ?";

            DbType[] dbTypes = new DbType[] { 
                        DbType.String,DbType.String,DbType.Int32,DbType.String,DbType.String,DbType.String,DbType.String,DbType.Int32,DbType.Int32,DbType.String,DbType.Int32,DbType.String,DbType.String
                        };
            object[][] objValues = new object[13][];
            for (int j = 0; j < objValues.Length; j++)
            {
                objValues[j] = new object[arrOrder.Length];//初始化
            }
            for (int k1 = 0; k1 < arrOrder.Length; k1++)
            {
                clsBIHOrder order = arrOrder[k1];
                n = -1;
                objValues[++n][k1] = m_strOrderID;
                objValues[++n][k1] = m_strOrderID;
                objValues[++n][k1] = order.m_dmlGet;
                objValues[++n][k1] = order.m_strDosetypeID;
                objValues[++n][k1] = order.m_strDosetypeName;
                objValues[++n][k1] = order.m_strExecFreqID;
                objValues[++n][k1] = order.m_strExecFreqName;
                objValues[++n][k1] = order.m_intISNEEDFEEL;
                objValues[++n][k1] = order.m_intOUTGETMEDDAYS_INT;
                objValues[++n][k1] = order.m_strREMARK_VCHR;
                objValues[++n][k1] = order.m_intATTACHTIMES_INT;
                objValues[++n][k1] = m_strOrderID;
                objValues[++n][k1] = order.m_strOrderID;
            }
            try
            {
                if (arrOrder.Length > 0)
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                    if (lngRes > 0)
                    {
                        #region 删除相关费用表
                        strSQL = @"
                        delete from T_OPR_BIH_ORDERCHARGEDEPT where ORDERID_CHR=? ";
                        dbTypes = new DbType[] { 
                        DbType.String
                        };
                        objValues = new object[1][];
                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[arrOrder.Length];//初始化
                        }
                        for (int k1 = 0; k1 < arrOrder.Length; k1++)
                        {
                            clsBIHOrder order = arrOrder[k1];
                            n = -1;
                            objValues[++n][k1] = order.m_strOrderID;
                        }
                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                        //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT]
                        for (int i = 0; i < arrOrder.Length; i++)
                        {
                            clsBIHOrder objOrder = arrOrder[i];
                            //ExecOrderToChargeItem(objOrder);
                            //if (i == 0)
                            //{
                            //    UsageToChargeItem(objOrder);
                            //}
                            ArrayList m_arrORDERCHARGEDEPT = new ArrayList();
                            ExecOrderToChargeItem(objOrder, ref  m_arrORDERCHARGEDEPT);
                            if (i == 0)
                            {
                                UsageToChargeItem(objOrder, ref m_arrORDERCHARGEDEPT);
                            }
                            lngRes = UpdateOrderToChargeItem(objOrder, (clsORDERCHARGEDEPT_VO[])m_arrORDERCHARGEDEPT.ToArray((new clsORDERCHARGEDEPT_VO()).GetType()));

                        }
                        #endregion
                        objHRPSvc.Dispose();

                    }
                }
            }
            catch (Exception objEx)
            {
                if (lngRes > 0)
                {
                    throw new Exception(objEx.Message);
                }
                else
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            return lngRes;

        }


        /// <summary>
        ///  新增医嘱-子医嘱
        /// </summary>
        /// <param name="p_strRecordID"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngAddNewOrderSubAdd(out string p_strRecordID, clsBIHOrder p_objRecord)
        {
            long lngRes = -1;
            p_strRecordID = "";
            DateTime m_dtToday = DateTime.MinValue;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "   select lpad(seq_orderid.NEXTVAL,18,'0') p_strRecordID ,sysdate today  from dual ";
            DataTable dtbResult2 = new DataTable();
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult2);
            if (lngRes > 0 && dtbResult2.Rows.Count > 0)
            {
                p_strRecordID = Convert.ToString(dtbResult2.Rows[0]["p_strRecordID"].ToString());
                m_dtToday = Convert.ToDateTime(dtbResult2.Rows[0]["today"].ToString());
            }
            else
            {
                return -1;
            }

            p_objRecord.m_intStatus = 0;
            p_objRecord.m_strOrderID = p_strRecordID;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            strSQL = @"insert into T_Opr_Bih_Order(
           OrderID_Chr,OrderDicID_Chr,RegisterID_Chr,PatientID_Chr,ExecuteType_Int,
           RecipeNo_Int,Name_VChr,Spec_VChr,ExecFreqID_Chr,ExecFreqName_Chr,
           Dosage_Dec,DosageUnit_Chr,Get_Dec,GetUnit_Chr,Use_Dec,
           UseUnit_Chr,DoseTypeID_Chr,DoseTypeName_Chr,Entrust_Vchr,ParentID_Chr,
           Status_Int,IsRich_Int,RateType_Int,IsRepare_Int,CreatorID_Chr,
           Creator_Chr,CreateDate_Dat,ISNEEDFEEL,OUTGETMEDDAYS_INT,STARTDATE_DAT,FINISHDATE_DAT,
           isYB_int,SAMPLEID_VCHR,LISAPPID_VCHR,PARTID_VCHR,IFPARENTID_INT,
          CREATEAREAID_CHR,CREATEAREANAME_VCHR,ATTACHTIMES_INT,DOCTORID_CHR,DOCTOR_VCHR
          ,CURAREAID_CHR,CURBEDID_CHR,DOCTORGROUPID_CHR,SIGN_INT,RecipeNo2_Int
          ,STOPERID_CHR,STOPER_CHR,STOPDATE_DAT,OPERATION_INT,REMARK_VCHR
          ,CHARGE_INT,PostDate_Dat,TYPE_INT,SINGLEAMOUNT_DEC,SOURCETYPE_INT, chargedoctorgroupid_chr, antiUse, antiUse_yflx, curedays, checkstate, isproxyboilmed)
           values(?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?
                  ,?,?,?,?,?
                  ,?,?,?,?,?
                  ,?,?,?,?,?, ?, ?, ?, ?, ?, ?)";
            try
            {
                System.Data.IDataParameter[] Params = null;
                objHRPSvc.CreateDatabaseParameter(62, out Params);
                //Please change the datetime and reocrdid 
                int n = -1;
                n++; Params[n].Value = p_objRecord.m_strOrderID;
                n++; Params[n].Value = p_objRecord.m_strOrderDicID;
                n++; Params[n].Value = p_objRecord.m_strRegisterID;
                n++; Params[n].Value = p_objRecord.m_strPatientID;
                n++; Params[n].Value = p_objRecord.m_intExecuteType;

                n++; Params[n].Value = p_objRecord.m_intRecipenNo;
                n++; Params[n].Value = p_objRecord.m_strName;
                n++; Params[n].Value = p_objRecord.m_strSpec;
                n++; Params[n].Value = p_objRecord.m_strExecFreqID;
                n++; Params[n].Value = p_objRecord.m_strExecFreqName;

                if (p_objRecord.m_dmlDosage > 0)
                {
                    n++; Params[n].Value = p_objRecord.m_dmlDosage;
                }
                else
                {
                    n++; Params[n].Value = null;
                }
                n++; Params[n].Value = p_objRecord.m_strDosageUnit;
                if (p_objRecord.m_dmlGet > 0)
                {
                    n++; Params[n].Value = p_objRecord.m_dmlGet;
                }
                else
                {
                    n++; Params[n].Value = null;
                }
                n++; Params[n].Value = p_objRecord.m_strGetunit;
                if (p_objRecord.m_dmlDosageRate > 0)
                {
                    n++; Params[n].Value = p_objRecord.m_dmlDosageRate;//p_objRecord.m_dmlUse;
                }
                else
                {
                    n++; Params[n].Value = null;
                }



                n++; Params[n].Value = p_objRecord.m_strDosageUnit;//p_objRecord.m_strUseunit;
                n++; Params[n].Value = p_objRecord.m_strDosetypeID;
                n++; Params[n].Value = p_objRecord.m_strDosetypeName;
                n++; Params[n].Value = p_objRecord.m_strEntrust;
                n++; Params[n].Value = p_objRecord.m_strParentID;


                n++; Params[n].Value = p_objRecord.m_intStatus;
                n++; Params[n].Value = p_objRecord.m_intIsRich;
                n++; Params[n].Value = p_objRecord.RateType;
                n++; Params[n].Value = p_objRecord.m_intIsRepare;
                n++; Params[n].Value = p_objRecord.m_strCreatorID;

                n++; Params[n].Value = p_objRecord.m_strCreator;
                n++; Params[n].Value = m_dtToday;
                //p_objRecord.m_dtCreatedate;
                n++; Params[n].Value = p_objRecord.m_intISNEEDFEEL;
                n++; Params[n].Value = p_objRecord.m_intOUTGETMEDDAYS_INT;
                if (p_objRecord.m_dtStartDate == DateTime.MinValue)
                {
                    n++; Params[n].Value = null;
                }
                else
                {
                    n++; Params[n].Value = p_objRecord.m_dtStartDate;
                }
                if (p_objRecord.m_dtFinishDate == DateTime.MinValue)
                {
                    n++; Params[n].Value = null;
                }
                else
                {
                    n++; Params[n].Value = p_objRecord.m_dtFinishDate;
                }


                n++; Params[n].Value = p_objRecord.isYB_int;
                n++; Params[n].Value = p_objRecord.m_strSAMPLEID_VCHR;
                n++; Params[n].Value = p_objRecord.m_strLISAPPID_VCHR;
                n++; Params[n].Value = p_objRecord.m_strPARTID_VCHR;
                n++; Params[n].Value = p_objRecord.m_intIFPARENTID_INT;
                n++; Params[n].Value = p_objRecord.m_strCREATEAREA_ID;
                n++; Params[n].Value = p_objRecord.m_strCREATEAREA_Name;
                n++; Params[n].Value = p_objRecord.m_intATTACHTIMES_INT;
                n++; Params[n].Value = p_objRecord.m_strDOCTORID_CHR;
                n++; Params[n].Value = p_objRecord.m_strDOCTOR_VCHR;
                n++; Params[n].Value = p_objRecord.m_strCURAREAID_CHR;
                n++; Params[n].Value = p_objRecord.m_strCURBEDID_CHR;
                n++; Params[n].Value = p_objRecord.m_strDOCTORGROUPID_CHR;
                n++; Params[n].Value = p_objRecord.SIGN_INT;
                n++; Params[n].Value = p_objRecord.m_intRecipenNo2;
                /* <<================================= */

                n++; Params[n].Value = p_objRecord.m_strStoperID;
                n++; Params[n].Value = p_objRecord.m_strStoper;
                if (p_objRecord.m_dtStopdate != DateTime.MinValue)
                {
                    n++; Params[n].Value = p_objRecord.m_dtStopdate;
                }
                else
                {
                    n++; Params[n].Value = null;
                }
                n++; Params[n].Value = p_objRecord.m_intOPERATION_INT;
                n++; Params[n].Value = p_objRecord.m_strREMARK_VCHR;

                n++; Params[n].Value = p_objRecord.m_intCHARGE_INT;
                n++; Params[n].Value = m_dtToday;
                n++; Params[n].Value = p_objRecord.m_intTYPE_INT;
                n++; Params[n].Value = p_objRecord.m_dmlOneUse;
                n++; Params[n].Value = p_objRecord.m_intSOURCETYPE_INT;
                n++; Params[n].Value = p_objRecord.m_strCHARGEDOCTORGROUPID;
                n++; Params[n].Value = p_objRecord.AntiUse;
                n++; Params[n].Value = p_objRecord.AntiUse_YFLX;
                n++; Params[n].Value = p_objRecord.CureDays;
                n++; Params[n].Value = 0;
                n++; Params[n].Value = p_objRecord.IsProxyBoilMed;

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, Params);

                // 将诊疗项目相关的费用信息传入（T_OPR_BIH_ORDERCHARGEDEPT 住院诊疗项目收费项目执行客户表）
                if (lngRes > 0)
                {
                    // 如果是增加子医嘱，则改变父医嘱的父医嘱标记
                    if (p_objRecord.m_intIFPARENTID_INT == 0 && p_objRecord.m_strParentID != null && !p_objRecord.m_strParentID.ToString().Trim().Equals(""))
                    {
                        strSQL = "update T_Opr_Bih_Order a set a.IFPARENTID_INT=1 where a.ORDERID_CHR=? ";
                        System.Data.IDataParameter[] Params2 = null;
                        objHRPSvc.CreateDatabaseParameter(1, out Params2);
                        Params2[0].Value = p_objRecord.m_strParentID;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, Params2);
                    }
                }
                if (lngRes > 0)
                {

                    //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT]
                    // ExecOrderToChargeItem(p_objRecord);
                    ArrayList m_arrORDERCHARGEDEPT = new ArrayList();
                    ExecOrderToChargeItem(p_objRecord, ref  m_arrORDERCHARGEDEPT);
                    //UsageToChargeItem(p_objRecord, ref m_arrORDERCHARGEDEPT);
                    lngRes = UpdateOrderToChargeItem(p_objRecord, (clsORDERCHARGEDEPT_VO[])m_arrORDERCHARGEDEPT.ToArray((new clsORDERCHARGEDEPT_VO()).GetType()));

                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                if (lngRes > 0)
                {
                    throw new Exception(objEx.Message);
                }
                else
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            return lngRes;
        }

        /// <summary>
        /// 新增医嘱-非子医嘱
        /// </summary>
        /// <param name="p_strRecordID"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOrderNotSubAdd(out string p_strRecordID, clsBIHOrder p_objRecord)
        {
            long lngRes = -1;
            p_strRecordID = "";
            DateTime m_dtTody;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "   select lpad(seq_orderid.NEXTVAL,18,'0') p_strRecordID ,sysdate today  from dual ";
            DataTable dtbResult2 = new DataTable();
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult2);
            if (lngRes > 0 && dtbResult2.Rows.Count > 0)
            {
                p_strRecordID = Convert.ToString(dtbResult2.Rows[0]["p_strRecordID"].ToString());
                m_dtTody = Convert.ToDateTime(dtbResult2.Rows[0]["today"].ToString());
            }
            else
            {
                return -1;
            }
            p_objRecord.m_intStatus = 0;
            p_objRecord.m_strOrderID = p_strRecordID;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            strSQL = @"insert into T_Opr_Bih_Order(
            OrderID_Chr,OrderDicID_Chr,RegisterID_Chr,PatientID_Chr,ExecuteType_Int,
            RecipeNo_Int,Name_VChr,Spec_VChr,ExecFreqID_Chr,ExecFreqName_Chr,
            Dosage_Dec,DosageUnit_Chr,Get_Dec,GetUnit_Chr,Use_Dec,
            UseUnit_Chr,DoseTypeID_Chr,DoseTypeName_Chr,Entrust_Vchr,ParentID_Chr,
            Status_Int,IsRich_Int,RateType_Int,IsRepare_Int,CreatorID_Chr,
           Creator_Chr,CreateDate_Dat,ISNEEDFEEL,OUTGETMEDDAYS_INT,STARTDATE_DAT,FINISHDATE_DAT,
           isYB_int,SAMPLEID_VCHR,LISAPPID_VCHR,PARTID_VCHR,IFPARENTID_INT,
           CREATEAREAID_CHR,CREATEAREANAME_VCHR,ATTACHTIMES_INT,DOCTORID_CHR,DOCTOR_VCHR
           ,CURAREAID_CHR,CURBEDID_CHR,DOCTORGROUPID_CHR,SIGN_INT
           ,STOPERID_CHR,STOPER_CHR,STOPDATE_DAT,OPERATION_INT,REMARK_VCHR
           ,CHARGE_INT,PostDate_Dat,TYPE_INT,SINGLEAMOUNT_DEC,SOURCETYPE_INT, chargedoctorgroupid_chr, antiUse, antiUse_yflx, curedays, isproxyboilmed)
           values(?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?,?,
                  ?,?,?,?,?,
                  ?,?,?,?,?
                  ,?,?,?,?
                  ,?,?,?,?,?
                  ,?,?,?,?,?, ?, ?, ?, ?, ?)";
            try
            {
                System.Data.IDataParameter[] Params = null;
                objHRPSvc.CreateDatabaseParameter(60, out Params);
                int n = -1;
                n++; Params[n].Value = p_objRecord.m_strOrderID;
                n++; Params[n].Value = p_objRecord.m_strOrderDicID;
                n++; Params[n].Value = p_objRecord.m_strRegisterID;
                n++; Params[n].Value = p_objRecord.m_strPatientID;
                n++; Params[n].Value = p_objRecord.m_intExecuteType;

                n++; Params[n].Value = null;
                n++; Params[n].Value = p_objRecord.m_strName;
                n++; Params[n].Value = p_objRecord.m_strSpec;
                n++; Params[n].Value = p_objRecord.m_strExecFreqID;
                n++; Params[n].Value = p_objRecord.m_strExecFreqName;

                if (p_objRecord.m_dmlDosage > 0)
                {
                    n++; Params[n].Value = p_objRecord.m_dmlDosage;
                }
                else
                {
                    n++; Params[n].Value = null;
                }
                n++; Params[n].Value = p_objRecord.m_strDosageUnit;
                if (p_objRecord.m_dmlGet > 0)
                {
                    n++; Params[n].Value = p_objRecord.m_dmlGet;
                }
                else
                {
                    n++; Params[n].Value = null;
                }
                n++; Params[n].Value = p_objRecord.m_strGetunit;
                if (p_objRecord.m_dmlDosageRate > 0)
                {
                    n++; Params[n].Value = p_objRecord.m_dmlDosageRate;
                }
                else
                {
                    n++; Params[n].Value = null;
                }
                n++; Params[n].Value = p_objRecord.m_strDosageUnit;
                n++; Params[n].Value = p_objRecord.m_strDosetypeID;
                n++; Params[n].Value = p_objRecord.m_strDosetypeName;
                n++; Params[n].Value = p_objRecord.m_strEntrust;
                n++; Params[n].Value = p_objRecord.m_strParentID;


                n++; Params[n].Value = p_objRecord.m_intStatus;
                n++; Params[n].Value = p_objRecord.m_intIsRich;
                n++; Params[n].Value = p_objRecord.RateType;
                n++; Params[n].Value = p_objRecord.m_intIsRepare;
                n++; Params[n].Value = p_objRecord.m_strCreatorID;

                n++; Params[n].Value = p_objRecord.m_strCreator;
                n++; Params[n].Value = m_dtTody;
                n++; Params[n].Value = p_objRecord.m_intISNEEDFEEL;
                n++; Params[n].Value = p_objRecord.m_intOUTGETMEDDAYS_INT;

                if (p_objRecord.m_dtStartDate == DateTime.MinValue)
                {
                    n++; Params[n].Value = m_dtTody;
                }
                else
                {
                    n++; Params[n].Value = p_objRecord.m_dtStartDate;
                }
                if (p_objRecord.m_dtFinishDate == DateTime.MinValue)
                {
                    n++; Params[n].Value = null;
                }
                else
                {
                    n++; Params[n].Value = p_objRecord.m_dtFinishDate;
                }
                n++; Params[n].Value = p_objRecord.isYB_int;

                n++; Params[n].Value = p_objRecord.m_strSAMPLEID_VCHR;
                n++; Params[n].Value = p_objRecord.m_strLISAPPID_VCHR;
                n++; Params[n].Value = p_objRecord.m_strPARTID_VCHR;
                n++; Params[n].Value = p_objRecord.m_intIFPARENTID_INT;

                n++; Params[n].Value = p_objRecord.m_strCREATEAREA_ID;
                n++; Params[n].Value = p_objRecord.m_strCREATEAREA_Name;
                n++; Params[n].Value = p_objRecord.m_intATTACHTIMES_INT;
                n++; Params[n].Value = p_objRecord.m_strDOCTORID_CHR;
                n++; Params[n].Value = p_objRecord.m_strDOCTOR_VCHR;

                n++; Params[n].Value = p_objRecord.m_strCURAREAID_CHR;
                n++; Params[n].Value = p_objRecord.m_strCURBEDID_CHR;
                n++; Params[n].Value = p_objRecord.m_strDOCTORGROUPID_CHR;
                n++; Params[n].Value = p_objRecord.SIGN_INT;

                n++; Params[n].Value = p_objRecord.m_strStoperID;
                n++; Params[n].Value = p_objRecord.m_strStoper;

                if (p_objRecord.m_dtStopdate != DateTime.MinValue)
                {
                    n++; Params[n].Value = p_objRecord.m_dtStopdate;
                }
                else
                {
                    n++; Params[n].Value = null;
                }
                n++; Params[n].Value = p_objRecord.m_intOPERATION_INT;
                n++; Params[n].Value = p_objRecord.m_strREMARK_VCHR;

                n++; Params[n].Value = p_objRecord.m_intCHARGE_INT;
                n++; Params[n].Value = m_dtTody;
                n++; Params[n].Value = p_objRecord.m_intTYPE_INT;
                n++; Params[n].Value = p_objRecord.m_dmlOneUse;
                n++; Params[n].Value = p_objRecord.m_intSOURCETYPE_INT;
                n++; Params[n].Value = p_objRecord.m_strCHARGEDOCTORGROUPID;
                n++; Params[n].Value = p_objRecord.AntiUse;
                n++; Params[n].Value = p_objRecord.AntiUse_YFLX;
                n++; Params[n].Value = p_objRecord.CureDays;
                n++; Params[n].Value = p_objRecord.IsProxyBoilMed;

                long lngRecEff = -1;
                // 往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, Params);

                // 将诊疗项目相关的费用信息传入（T_OPR_BIH_ORDERCHARGEDEPT 住院诊疗项目收费项目执行客户表）
                if (lngRes > 0)
                {
                    // 如果是增加子医嘱，则改变父医嘱的交医嘱标记
                    if (p_objRecord.m_intIFPARENTID_INT == 0 && p_objRecord.m_strParentID != null && !p_objRecord.m_strParentID.ToString().Trim().Equals(""))
                    {
                        strSQL = "update T_Opr_Bih_Order a set a.IFPARENTID_INT=1 where a.ORDERID_CHR=?";
                        System.Data.IDataParameter[] Params2 = null;
                        objHRPSvc.CreateDatabaseParameter(1, out Params2);
                        Params2[0].Value = p_objRecord.m_strOrderID;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, Params2);

                    }
                    if (lngRes > 0)
                    {
                        strSQL = @"
                    update t_opr_bih_order 
                    set
                    RECIPENO_INT=
                    decode(
                    (select max(a.recipeno_int) recipeno_int from t_opr_bih_order a where a.registerid_chr=?)
                    ,null,
                     1,
                     (select max(a.recipeno_int)+1 recipeno_int from t_opr_bih_order a where a.registerid_chr=?) 
                      )
                    where orderid_chr=?";
                        System.Data.IDataParameter[] Params3 = null;
                        objHRPSvc.CreateDatabaseParameter(3, out Params3);
                        Params3[0].Value = p_objRecord.m_strRegisterID.Trim();
                        Params3[1].Value = p_objRecord.m_strRegisterID.Trim();
                        Params3[2].Value = p_objRecord.m_strOrderID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, Params3);
                        if (lngRes > 0 && p_objRecord.m_intExecuteType == 1)
                        {
                            strSQL = @"
                            update t_opr_bih_order 
                            set
                            RECIPENO2_INT=
                            decode(
                            (select max(a.recipeno2_int) recipeno2_int from t_opr_bih_order a where  EXECUTETYPE_INT=1 and STATUS_INT<>-2 and OPERATION_INT=0 and a.registerid_chr=? )
                            ,null,
                             1,
                             (select max(a.recipeno2_int)+1 recipeno2_int from t_opr_bih_order a where EXECUTETYPE_INT=1 and STATUS_INT<>-2 and OPERATION_INT=0 and a.registerid_chr=?) 
                              )
                            where orderid_chr=?";
                            System.Data.IDataParameter[] Params4 = null;
                            objHRPSvc.CreateDatabaseParameter(3, out Params4);
                            Params4[0].Value = p_objRecord.m_strRegisterID.Trim();
                            Params4[1].Value = p_objRecord.m_strRegisterID.Trim();
                            Params4[2].Value = p_objRecord.m_strOrderID;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, Params4);
                        }
                    }
                }
                if (lngRes > 0)
                {
                    //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT]
                    ArrayList m_arrORDERCHARGEDEPT = new ArrayList();
                    ExecOrderToChargeItem(p_objRecord, ref  m_arrORDERCHARGEDEPT);
                    UsageToChargeItem(p_objRecord, ref m_arrORDERCHARGEDEPT);
                    lngRes = UpdateOrderToChargeItem(p_objRecord, (clsORDERCHARGEDEPT_VO[])m_arrORDERCHARGEDEPT.ToArray((new clsORDERCHARGEDEPT_VO()).GetType()));
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                if (lngRes > 0)
                {
                    throw new Exception(objEx.Message);
                }
                else
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        /// <summary>
        /// 新建医嘱
        /// </summary>
        /// <param name="p_strRecordID">医嘱ID	[out 参数]</param>
        /// <param name="p_objRecord">医嘱Vo对象</param>
        /// <param name="p_intRecipeNo">方号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOrder(out string p_strRecordID, clsBIHOrder p_objRecord, int p_intRecipeNo)
        {
            long lngRes = -1;
            p_strRecordID = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //lngRes = objHRPSvc.lngGenerateID(18, "ORDERID_CHR", "T_Opr_Bih_Order", out p_strRecordID);
            // if (lngRes < 0) return lngRes;
            string strSQL = "   select lpad(seq_orderid.NEXTVAL,18,'0') p_strRecordID   from dual ";
            DataTable dtbResult2 = new DataTable();
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult2);
            if (lngRes > 0 && dtbResult2.Rows.Count > 0)
            {
                p_strRecordID = Convert.ToString(dtbResult2.Rows[0]["p_strRecordID"].ToString());
            }
            else
            {
                return -1;
            }
            p_objRecord.m_intRecipenNo = p_intRecipeNo;
            p_objRecord.m_intStatus = 0;

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            strSQL = @"insert into t_opr_bih_order
                                            (orderid_chr, orderdicid_chr, registerid_chr, patientid_chr,
                                             executetype_int, recipeno_int, name_vchr, spec_vchr,
                                             execfreqid_chr, execfreqname_chr, dosage_dec, dosageunit_chr,
                                             get_dec, getunit_chr, use_dec, useunit_chr, dosetypeid_chr,
                                             dosetypename_chr, entrust_vchr, parentid_chr, status_int,
                                             isrich_int, ratetype_int, isrepare_int, creatorid_chr,
                                             creator_chr, createdate_dat, isneedfeel, outgetmeddays_int,
                                             startdate_dat, isyb_int, sampleid_vchr, lisappid_vchr,
                                             partid_vchr, ifparentid_int, createareaid_chr,
                                             createareaname_vchr, chargedoctorgroupid_chr, antiUse, antiUse_yflx, curedays, checkstate, isproxyboilmed   
                                            )
                                     values (?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?,
                                             ?, ?, ?, ?, ?, ?, ?   
                                            )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(43, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strOrderDicID;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strRegisterID;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strPatientID;
                objLisAddItemRefArr[4].Value = p_objRecord.m_intExecuteType;
                objLisAddItemRefArr[5].Value = p_objRecord.m_intRecipenNo;
                objLisAddItemRefArr[6].Value = p_objRecord.m_strName;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strSpec;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strExecFreqID;
                objLisAddItemRefArr[9].Value = p_objRecord.m_strExecFreqName;
                if (p_objRecord.m_dmlDosage > 0)
                    objLisAddItemRefArr[10].Value = p_objRecord.m_dmlDosage;
                else
                    objLisAddItemRefArr[10].Value = null;
                objLisAddItemRefArr[11].Value = p_objRecord.m_strDosageUnit;
                if (p_objRecord.m_dmlGet > 0)
                    objLisAddItemRefArr[12].Value = p_objRecord.m_dmlGet;
                else
                    objLisAddItemRefArr[12].Value = null;
                objLisAddItemRefArr[13].Value = p_objRecord.m_strGetunit;
                if (p_objRecord.m_dmlUse > 0)
                    objLisAddItemRefArr[14].Value = p_objRecord.m_dmlUse;
                else
                    objLisAddItemRefArr[14].Value = null;
                objLisAddItemRefArr[15].Value = p_objRecord.m_strUseunit;
                objLisAddItemRefArr[16].Value = p_objRecord.m_strDosetypeID;
                objLisAddItemRefArr[17].Value = p_objRecord.m_strDosetypeName;
                objLisAddItemRefArr[18].Value = p_objRecord.m_strEntrust;
                objLisAddItemRefArr[19].Value = p_objRecord.m_strParentID;
                objLisAddItemRefArr[20].Value = p_objRecord.m_intStatus;
                objLisAddItemRefArr[21].Value = p_objRecord.m_intIsRich;
                objLisAddItemRefArr[22].Value = p_objRecord.RateType;
                objLisAddItemRefArr[23].Value = p_objRecord.m_intIsRepare;
                objLisAddItemRefArr[24].Value = p_objRecord.m_strCreatorID;
                objLisAddItemRefArr[25].Value = p_objRecord.m_strCreator;
                objLisAddItemRefArr[26].Value = p_objRecord.m_dtCreatedate;
                objLisAddItemRefArr[27].Value = p_objRecord.m_intISNEEDFEEL;
                objLisAddItemRefArr[28].Value = p_objRecord.m_intOUTGETMEDDAYS_INT;
                if (p_objRecord.m_dtStartDate > System.DateTime.Now.AddDays(-1))
                {
                    objLisAddItemRefArr[29].Value = p_objRecord.m_dtStartDate;
                }
                else
                {
                    objLisAddItemRefArr[29].Value = null;
                }
                objLisAddItemRefArr[30].Value = p_objRecord.isYB_int;
                objLisAddItemRefArr[31].Value = p_objRecord.m_strSAMPLEID_VCHR;
                objLisAddItemRefArr[32].Value = p_objRecord.m_strLISAPPID_VCHR;
                objLisAddItemRefArr[33].Value = p_objRecord.m_strPARTID_VCHR;
                objLisAddItemRefArr[34].Value = p_objRecord.m_intIFPARENTID_INT;
                objLisAddItemRefArr[35].Value = p_objRecord.m_strCREATEAREA_ID;
                objLisAddItemRefArr[36].Value = p_objRecord.m_strCREATEAREA_Name;
                objLisAddItemRefArr[37].Value = p_objRecord.m_strCHARGEDOCTORGROUPID;
                objLisAddItemRefArr[38].Value = p_objRecord.AntiUse;
                objLisAddItemRefArr[39].Value = p_objRecord.AntiUse_YFLX;
                objLisAddItemRefArr[40].Value = p_objRecord.CureDays;
                objLisAddItemRefArr[41].Value = 0;
                objLisAddItemRefArr[42].Value = p_objRecord.IsProxyBoilMed;

                long lngRecEff = -1;
                // 往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);

                // 将诊疗项目相关的费用信息传入（T_OPR_BIH_ORDERCHARGEDEPT 住院诊疗项目收费项目执行客户表）
                if (lngRes > 0)
                {
                    // 如果是增加子医嘱，则改变父医嘱的交医嘱标记
                    if (p_objRecord.m_intIFPARENTID_INT == 0 && p_objRecord.m_strParentID != null && !p_objRecord.m_strParentID.ToString().Trim().Equals(""))
                    {
                        strSQL = "update T_Opr_Bih_Order a set a.IFPARENTID_INT=1 where a.ORDERID_CHR='" + p_strRecordID + "'";
                        lngRes = objHRPSvc.DoExcute(strSQL);
                    }
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
        /// 新增医嘱	根据组套ID	[多条]	[事务方式]
        /// </summary>
        /// <param name="p_strRecordIDArr">医嘱ID [out 参数]</param>
        /// <param name="p_objRecord">医嘱Vo对象</param>
        /// <param name="p_blnIsSameNO">是否相同方号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOrder(out string[] p_strRecordIDArr, clsBIHOrder[] p_objRecordArr, bool p_blnIsSameNO)
        {
            long lngRes = 1;
            p_strRecordIDArr = new string[p_objRecordArr.Length];
            if (p_objRecordArr.Length <= 0) return lngRes;

            //排序医嘱记录(父级医嘱放在首列)最多一列父级医嘱
            int intParent = 0;
            for (int i1 = 0; i1 < p_objRecordArr.Length; i1++)
            {
                //注意: 这里存储的是: 父诊疗项目id	{=诊疗项目.Id}
                // if (p_objRecordArr[i1].m_strParentID == null || (p_objRecordArr[i1].m_strParentID != null && p_objRecordArr[i1].m_strParentID.Trim() == p_objRecordArr[i1].m_strOrderDicID.Trim()))
                if (p_objRecordArr[i1].m_intIFPARENTID_INT == 1)
                {
                    intParent = i1;
                    break;
                }
            }
            if (intParent > 0)
            {//替换位置
                clsBIHOrder objItem = new clsBIHOrder();
                objItem = p_objRecordArr[intParent];
                p_objRecordArr[intParent] = p_objRecordArr[0];
                //p_objRecordArr[intParent] = objItem;
                p_objRecordArr[0] = objItem;
            }

            //方号
            int intRecipeNo = int.MinValue;
            //显示的方号
            int intRecipeNo2 = int.MinValue;
            for (int i1 = 0; i1 < p_objRecordArr.Length; i1++)
            {
                //获取方号
                if (lngRes > 0 && (!p_blnIsSameNO || intRecipeNo == int.MinValue) && p_strRecordIDArr[0] != null)
                {
                    lngRes = 0;
                    lngRes = m_lngGetParentRecipeNO(p_strRecordIDArr[0], out intRecipeNo, out intRecipeNo2);
                }
                if (lngRes > 0 && p_objRecordArr[i1] != null)
                {
                    if (i1 > 0 && p_objRecordArr[0].m_intIFPARENTID_INT == 1)
                    {
                        p_objRecordArr[i1].m_strParentID = p_strRecordIDArr[0];
                        p_objRecordArr[i1].m_intIsSubOrderAdd = 1;
                        p_objRecordArr[i1].m_intRecipenNo = intRecipeNo;
                        p_objRecordArr[i1].m_intRecipenNo2 = intRecipeNo2;
                    }
                    else
                    {
                        p_objRecordArr[i1].m_strParentID = "";
                        p_objRecordArr[0].m_intIsSubOrderAdd = 0;
                    }

                    lngRes = 0;
                    lngRes = m_lngAddNewOrder(out p_strRecordIDArr[i1], p_objRecordArr[i1]);
                }
            }
            if (lngRes <= 0)
            {
                throw (new System.Exception("新增医嘱失败!"));
            }
            return lngRes;
        }

        /// <summary>
        /// 新增医嘱	根据组套ID	[多条]	[事务方式]
        /// </summary>
        /// <param name="p_strRecordIDArr">医嘱ID [out 参数]</param>
        /// <param name="p_objRecord">医嘱Vo对象</param>
        /// <param name="p_blnIsSameNO">是否相同方号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOrderByGroup(out string[] p_strRecordIDArr, ArrayList p_RecordArr)
        {
            long lngRes = 1;
            bool p_blnIsSameNO = false;
            p_strRecordIDArr = new string[p_RecordArr.Count];
            ArrayList SameOrder = new ArrayList();//保存组套的医嘱集
            ArrayList HadSaveOrder = new ArrayList();//保存已保存的医嘱记录号(现在的医嘱号暂存为医嘱组套明细水长流的流水号)
            //clsBIHOrder[] p_objRecordArr
            if (p_strRecordIDArr.Length <= 0) return lngRes;

            /*将同方的医嘱归组再执行*/
            ////执行当前这组非同方的医嘱
            for (int i = 0; i < p_RecordArr.Count; i++)
            {
                clsBIHOrder p_objOrder = (clsBIHOrder)p_RecordArr[i];
                SameOrder = new ArrayList();
                if (HadSaveOrder.Contains(p_objOrder.m_strOrderID))//执行保存过的医嘱不进行处理
                {
                    continue;
                }
                SameOrder.Add(p_objOrder);
                HadSaveOrder.Add(p_objOrder.m_strOrderID);

                for (int j = i + 1; j < p_RecordArr.Count; j++)
                {

                    clsBIHOrder p_objOrder2 = (clsBIHOrder)p_RecordArr[j];
                    if (p_objOrder.m_intRecipenNo == p_objOrder2.m_intRecipenNo)
                    {
                        SameOrder.Add(p_objOrder2);//记录执行过的医嘱编号
                        HadSaveOrder.Add(p_objOrder2.m_strOrderID);
                    }

                }
                if (SameOrder.Count > 1)//多于一个说明是组套医嘱
                {
                    //执行当前这组同方的医嘱
                    lngRes = m_lngAddNewOrder(out p_strRecordIDArr, (clsBIHOrder[])SameOrder.ToArray((new clsBIHOrder()).GetType()), true);

                    /*<===========================*/
                }
                else
                {
                    lngRes = m_lngAddNewOrder(out p_strRecordIDArr, (clsBIHOrder[])SameOrder.ToArray((new clsBIHOrder()).GetType()), false);

                }
                for (int j = 0; j < p_strRecordIDArr.Length; j++)
                {
                    HadSaveOrder.Add(p_strRecordIDArr[j]);
                }
            }
            //执行当前这组非同方的医嘱
            return lngRes;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 创建医嘱流水号
        /// </summary>
        /// <param name="strOrderID">医嘱流水号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCreateOrderID(out string strOrderID)
        {
            strOrderID = "";
            string strSql = " select Max(OrderID_Chr) as MaxID from T_Opr_BIH_ORDER ";

            object objValue;
            if (m_lngGetValue(strSql, out objValue) == 0) return 0;

            long intID = 0;
            if (objValue == null)
                intID = 1;
            else
                intID = clsConverter.ToLong(objValue) + 1;

            strOrderID = intID.ToString().Trim().PadLeft(18, '0');
            return 1;
        }

        /// <summary>
        /// 创建医嘱方号
        /// </summary>
        /// <param name="strRegisterID"></param>
        /// <param name="strPatientID"></param>
        /// <param name="intRecipeNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCreateRecipeNO(string strRegisterID, string strPatientID, out int intRecipeNo)
        {
            intRecipeNo = 0;
            string strSql = @"	select Max(RecipeNo_Int) as MaxNo from T_Opr_BIH_ORDER
								where Trim(RegisterID_Chr)='[RegID]' and Trim(PatientID_Chr)='[PatID]'";
            strSql = strSql.Replace("[RegID]", strRegisterID.Trim());
            strSql = strSql.Replace("[PatID]", strPatientID.Trim());

            object objValue;
            if (m_lngGetValue(strSql, out objValue) == 0) return 0;

            int intNo = 0;
            if (objValue == null)
                intNo = 1;
            else
                intNo = clsConverter.ToInt(objValue) + 1;

            intRecipeNo = intNo;
            return 1;

        }

        /// <summary>
        /// 获取当前医嘱的方号
        /// </summary>
        /// <param name="strRegisterID"></param>
        /// <param name="strPatientID"></param>
        /// <param name="intRecipeNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetParentRecipeNO(string m_strOrderid_chr, out int intRecipeNo, out int intRecipeNo2)
        {
            intRecipeNo = 0;
            intRecipeNo2 = 0;
            long lngRes = 0;
            string strSql = @"	
                            select a.recipeno_int,a.recipeno2_int from T_Opr_BIH_ORDER a
                            where
                            a.orderid_chr=?
                             ";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strOrderid_chr.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtbResult, arrParams);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    if (!dtbResult.Rows[0]["recipeno_int"].ToString().Trim().Equals(""))
                    {
                        intRecipeNo = int.Parse(dtbResult.Rows[0]["recipeno_int"].ToString().Trim());
                    }
                    if (!dtbResult.Rows[0]["recipeno2_int"].ToString().Trim().Equals(""))
                    {
                        intRecipeNo2 = int.Parse(dtbResult.Rows[0]["recipeno2_int"].ToString().Trim());
                    }

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

        #endregion

        #endregion

        #region 获取查询的数
        /// <summary>
        /// 获取查询的最大显示数目
        /// </summary>
        /// <returns>返回查询的最大显示数目</returns>
        public int m_intGetTop()
        {
            return 200;
        }
        #endregion

        #region 查找
        /// <summary>
        /// 获取医嘱记录Vo		根据医嘱ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_objResult">医嘱记录Vo	[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOrderID, out clsBIHOrder p_objResult)
        {
            p_objResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"	
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr,tb.dosage_dec dosagerate,ta.ordercateid_chr
									,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice 
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.orderdicid_chr=b.orderdicid_chr(+) and  status_int in (0,1,2) 
							 and Trim(a.orderid_chr)='" + p_strOrderID.Trim() + "'";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    clsBIHOrder[] objResultArr = null;
                    lngRes = 0;
                    lngRes = m_lngGetOrderArrFromDataTable(dtbResult, out objResultArr);
                    if (lngRes > 0 && objResultArr != null && objResultArr.Length > 0) p_objResult = objResultArr[0];
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

        #region 查询医嘱信息	根据条件
        /// <summary>
        /// 查询医嘱信息	根据条件
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCondition">条件表达式[不包括“Where”]</param>
        /// <param name="p_objResultArr">医嘱记录对象	[数组]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCondition, out clsBIHOrder[] p_objResultArr)
        {
            p_objResultArr = new clsBIHOrder[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"	
						select a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr,b.itemprice,b.dosagerate,b.ordercateid_chr
								,(select replace(trim(recipeno_int || ' ' || name_vchr),' ',' - ') from t_opr_bih_order where t_opr_bih_order.orderid_chr = a.parentid_chr) parentname
						from t_opr_bih_order a,
						(
							select ta.orderdicid_chr,tb.dosage_dec dosagerate,ta.ordercateid_chr
									,decode(tb.ipchargeflg_int,1,round(tb.itemprice_mny/tb.packqty_dec,4),0,tb.itemprice_mny,round(tb.itemprice_mny/tb.packqty_dec,4)) itemprice 
							from t_bse_bih_orderdic ta,t_bse_chargeitem tb
							where ta.itemid_chr=tb.itemid_chr(+)
						) b
						where a.orderdicid_chr=b.orderdicid_chr(+)";
            strSQL += " AND " + p_strCondition.Trim();
            strSQL += " order by a.recipeno_int,a.parentid_chr desc,a.createdate_dat ";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngGetOrderArrFromDataTable(dtbResult, out p_objResultArr);
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

        #region 根据医生ID判断是否有处方权
        /// <summary>
        /// 根据医生ID判断是否有处方权
        /// </summary>
        /// <param name="p_strDoctorID">医生ID</param>
        /// <returns>有:0,无:-1</returns>
        [AutoComplete]
        public long m_lngGetHASPRESCRIPTIONRIGHT(string p_strDoctorID)
        {
            try
            {
                string strSQL = @"SELECT EMPID_CHR FROM T_BSE_Employee WHERE EMPID_CHR=? AND STATUS_INT=1 AND HASPRESCRIPTIONRIGHT_CHR='1'";
                DataTable dtbRes = new DataTable();
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPService = new clsHRPTableService();
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strDoctorID.Trim();
                long lngRes = HRPService.lngGetDataTableWithParameters(strSQL, ref dtbRes, arrParams);

                if (lngRes > 0 && dtbRes.Rows.Count > 0)
                {
                    return 0;
                }
                return -1;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
        }
        #endregion

        #region 获取医生列表
        [AutoComplete]
        public long m_lngGetDoctors(string strFilter, out DataTable p_dtbDoctors)
        {
            string strSQL = "";

            //if (strFilter.Trim() == "")
            //{
            //    strSQL = @"SELECT * FROM T_BSE_EMPLOYEE WHERE HASPRESCRIPTIONRIGHT_CHR='1' AND STATUS_INT=1";
            //}
            //else
            //{
            //    strSQL = @"SELECT * FROM T_BSE_EMPLOYEE WHERE HASPRESCRIPTIONRIGHT_CHR='1' AND STATUS_INT=1 AND " + strFilter.Trim();
            //}
            strSQL = @"select empid_chr, begindate_dat, firstname_vchr, lastname_vchr, empidcard_chr, pycode_chr, sex_chr, 
	educationallevel_chr, maritalstatus_chr, technicalrank_chr, languageability_vchr, birthdate_dat, 
	officephone_vchr, homephone_vchr, mobile_vchr, officeaddress_vchr, officezip_chr, homeaddress_vchr, 
	homezip_chr, email_vchr, contactname_vchr, contactphone_vchr, remark_vchr, status_int, deactivate_dat, 
	shortname_chr, operatorid_chr, hasprescriptionright_chr, haspsychosisprescriptionright_, hasopiateprescriptionright_chr, 
	isexpert_chr, expertfee_mny, isexternalexpert_chr, ancestoraddr_vchar, experience_vchr, psw_chr, deptcode_chr, 
	technicallevel_chr, digitalsign_dta, extendid_vchr, isemployee_int, empno_chr, employeeidentity_int, empduty_int  from t_bse_employee where hasprescriptionright_chr='1' and status_int=1 and empno_chr like ?";

            p_dtbDoctors = new DataTable();

            long lngRes = 0;
            try
            {
                lngRes = 0;
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPService = new clsHRPTableService();
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = strFilter + "%";
                lngRes = HRPService.lngGetDataTableWithParameters(strSQL, ref p_dtbDoctors, arrParams);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            if (lngRes > 0 && p_dtbDoctors.Rows.Count > 0)
            {
                return 0;
            }
            return -1;
        }
        #endregion

        #region 获取医生的当前病人列表
        [AutoComplete]
        public long m_lngGetPatientInfoByDoctorID(string p_strFilter, string p_strDodctorID, out DataTable p_dtbPatients)
        {
            string strSQL = "";

            p_dtbPatients = new DataTable();

            if (p_strDodctorID.Trim() == "")
            {
                return -1;
            }

            if (p_strFilter.Trim() == "")
            {
                strSQL = @"select a.registerid_chr,a.modify_dat,a.patientid_chr,a.isbooking_int,a.inpatientid_chr,a.inpatient_dat,
       a.deptid_chr,a.areaid_chr,a.bedid_chr,a.type_int,a.diagnose_vchr,a.limitrate_mny,a.inpatientcount_int,
       a.state_int,a.status_int,a.operatorid_chr,a.pstatus_int,a.casedoctor_chr,a.inpatientnotype_int,
       a.des_vchr,a.inareadate_dat,a.mzdoctor_chr,a.mzdiagnose_vchr,a.diagnoseid_chr,a.icd10diagid_vchr,
       a.icd10diagtext_vchr,a.isfromclinic,a.clinicsayprepay,a.paytypeid_chr,a.bornnum_int,
       a.relateregisterid_chr,a.feestatus_int,a.extendid_vchr,a.nursing_class,a.casedoctordept_chr,
       a.cancelerid_chr,a.cancel_dat,a.outdiagnose_vchr,a.insuredsum_mny,a.checkstatus_int,a.diseasetype_int,
       a.isshunchan from t_opr_bih_register a
						left join t_bse_patient b
						on a.patientid_chr=b.patientid_chr
						where a.status_int=1 and a.pstatus_int<>3  
						and a.casedoctor_chr='" + p_strDodctorID.Trim() + "'";
            }
            else
            {
                strSQL = @"select a.registerid_chr,a.modify_dat,a.patientid_chr,a.isbooking_int,a.inpatientid_chr,a.inpatient_dat,
       a.deptid_chr,a.areaid_chr,a.bedid_chr,a.type_int,a.diagnose_vchr,a.limitrate_mny,a.inpatientcount_int,
       a.state_int,a.status_int,a.operatorid_chr,a.pstatus_int,a.casedoctor_chr,a.inpatientnotype_int,
       a.des_vchr,a.inareadate_dat,a.mzdoctor_chr,a.mzdiagnose_vchr,a.diagnoseid_chr,a.icd10diagid_vchr,
       a.icd10diagtext_vchr,a.isfromclinic,a.clinicsayprepay,a.paytypeid_chr,a.bornnum_int,
       a.relateregisterid_chr,a.feestatus_int,a.extendid_vchr,a.nursing_class,a.casedoctordept_chr,
       a.cancelerid_chr,a.cancel_dat,a.outdiagnose_vchr,a.insuredsum_mny,a.checkstatus_int,a.diseasetype_int,
       a.isshunchan from t_opr_bih_register a
						left join t_bse_patient b
						on a.patientid_chr=b.patientid_chr
						where a.status_int=1 and a.pstatus_int<>3  
						and a.casedoctor_chr='" + p_strDodctorID.Trim() + "' AND " + p_strFilter.Trim();
            }

            long lngRes = 0;
            try
            {
                lngRes = 0;
                lngRes = new clsHRPTableService().DoGetDataTable(strSQL, ref p_dtbPatients);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            if (lngRes > 0 && p_dtbPatients.Rows.Count > 0)
            {
                return 0;
            }

            return -1;
        }
        #endregion

        #region 获取病人卡号 根据病人ID
        /// <summary>
        /// 获取病人卡号 根据病人ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strCardID">病人卡号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCardIDByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientID, out string p_strCardID)
        {
            p_strCardID = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetCardIDByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"
						SELECT a.patientcardid_chr, a.patientid_chr, a.issue_date, a.status_int
						FROM t_bse_patientcard a
						WHERE a.status_int > 1 AND TRIM (a.patientid_chr) = '[PATIENTID]'";
            strSQL = strSQL.Replace("[PATIENTID]", p_strPatientID.Trim());
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_strCardID = dtbResult.Rows[0]["PATIENTCARDID_CHR"].ToString().Trim();
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

        #region 获取医保信息
        /// <summary>
        /// 获取医保信息	根据诊疗项目ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOrderdicID">诊疗项目ID</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicareByOrderdicID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOrderdicID, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"	
						SELECT  decode(upper(a.xmclsa),'F','乙类','O','其他','T','甲类','') names    
							,a.xmclsa 
							,a.xmcdea, a.xmcdeb, a.xmdesc, a.xmeng, a.xmjx, a.xmunit, a.nrxamt, a.othamt, a.nrper, a.regper, a.retper, 
	a.othper, a.isnryb, a.isper, a.xmjsfl, a.xmflag, a.xmclsa, a.xmclsb, a.xmclsc, a.xmclsd, a.xmclse, a.xmmemo, 
	a.u_version, a.lxamt, a.lxper, a.serperg, a.seramtg, a.serperq, a.seramtq, a.serperuq, a.seramtuq, a.serreg, 
	a.serret, a.serifper, a.serbzfl, a.lxamtq, a.lxperq, a.lxamtuq, a.lxperuq, a.lxisper, a.lxzffl ,b.hos_code, b.xmcode, b.xmcdea, b.xmcdeb, b.trnuid, b.trndate, b.u_version
						FROM ybgd01 a, ybgd02 b
						WHERE TRIM (hos_code) = '[HOS_CODE]'
							AND TRIM (xmcode) = '[ORDERDICID]'
							AND TRIM (a.xmcdea) = TRIM (b.xmcdea)
							AND TRIM (a.xmcdeb) = TRIM (b.xmcdeb)";

            strSQL = strSQL.Replace("[HOS_CODE]", "A-02");//A-02
            strSQL = strSQL.Replace("[ORDERDICID]", p_strOrderdicID.Trim());
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
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
        /// 获取医保信息	根据诊疗项目编码
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strUserCode">诊疗项目编码</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicareByUserCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strUserCode, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"	
						SELECT  decode(upper(a.xmclsa),'F','乙类','O','其他','T','甲类','') names    
							,a.xmclsa 
							,a.*, b.*
						FROM ybgd01 a, ybgd02 b
						WHERE TRIM (hos_code) = '[HOS_CODE]'
							AND TRIM (xmcode) = '[UserCode]'
							AND TRIM (a.xmcdea) = TRIM (b.xmcdea)
							AND TRIM (a.xmcdeb) = TRIM (b.xmcdeb)";

            strSQL = strSQL.Replace("[HOS_CODE]", "A-02");//A-02
            strSQL = strSQL.Replace("[UserCode]", p_strUserCode.Trim());
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
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

        /// <summary>
        /// 根据病人登记号(registerId),执行日期({yyyy-mm-dd})显示医嘱执行单记录
        /// </summary>
        /// <param name="registerId">病人登记日期</param>
        /// <param name="date">执行单生成日期{yyyy-mm-dd}</param>
        /// <returns>{CODE_CHR(床号)/LASTNAME_VCHR(姓名)/NAME_VCHR(医嘱名称)/USE_DEC(用量)/USEUNIT_CHR(用量单位)/EXECFREQNAME_CHR(频率)/DOSETYPENAME_CHR(用法)/EXECUTEDATE_VCHR(执行时间)/CREATEDATE_DAT}</returns>
        [AutoComplete]
        public DataTable getOrderExecute(string registerId, string date)
        {
            long lngRes = 0;
            DataTable p_dtResult = null;
            string strSQL = "select bed.CODE_CHR,patient.LASTNAME_VCHR,DECODE (ord.executetype_int, 1, '长嘱', 2, '临嘱', '') AS exetype,ord.NAME_VCHR,ord.USE_DEC,ord.USEUNIT_CHR,ord.EXECFREQNAME_CHR,ord.DOSETYPENAME_CHR,orderExec.EXECUTEDATE_VCHR"
                + " from t_bse_bed bed,t_bse_patient patient,t_opr_bih_order ord,t_opr_bih_orderExecute orderExec,t_opr_bih_register register"
                + " where bed.BEDID_CHR = register.BEDID_CHR"
                + " and register.PATIENTID_CHR = patient.PATIENTID_CHR"
                + " and ord.REGISTERID_CHR = register.REGISTERID_CHR"
                + " and orderExec.ORDERID_CHR = ord.ORDERID_CHR"
                + " and orderExec.CREATEDATE_DAT >= to_date('" + date + " 00:00:00','yyyy-mm-dd hh24:mi:ss')"
                + " and orderExec.CREATEDATE_DAT <= to_date('" + date + " 23:59:59','yyyy-mm-dd hh24:mi:ss')"
                + " and register.registerid_chr='" + registerId + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return p_dtResult;
        }

        /// <summary>
        /// 根据诊疗项目id取其用户编码
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public string getOrderDicUserCodeById(string id)
        {
            string userCode = "";
            long lngRes = 0;
            DataTable p_dtResult = null;
            string strSQL = @"select USERCODE_CHR from t_bse_bih_orderDic where ORDERDICID_CHR='" + id + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && p_dtResult.Rows.Count > 0)
            {
                userCode = p_dtResult.Rows[0][0].ToString().Trim();
            }
            return userCode;
        }

        /// <summary>
        /// 根据住院登记id,取出所有历史住院信息
        /// </summary>
        /// <param name="registerId">住院登记id</param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable getBihHistory(string registerId)
        {
            long lngRes = 0;
            DataTable dt = null;
            string sql = "select registerId_chr,inpatient_dat"
                    + " from t_opr_bih_register"
                    + " where patientid_chr ="
                    + " (select max(patientid_chr) from t_opr_bih_register where registerId_chr='" + registerId + "')";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql, ref dt);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dt;
        }
        #region 加载系统配置
        [AutoComplete]
        public long m_mthGetSysConfig(out DataTable dt, string strEx)
        {
            string strSql = @"select * from T_BSE_BIH_SPECORDERCATE";
            dt = new DataTable();
            long ret = 0;
            try
            {
                ret = new clsHRPTableService().lngGetDataTableWithoutParameters(strSql, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return ret;

        }
        /// <summary>
        /// 获取医嘱特殊配置表
        /// </summary>
        /// <param name="m_objSpecateVo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddGetSPECORDERCATE(out clsSPECORDERCATE m_objSpecateVo)
        {
            m_objSpecateVo = new clsSPECORDERCATE();
            string strSql = @"select a.ischeckmed, a.iscontrlmoneyactived, a.ishosnumatuo, a.isorderexclude,
                                   a.leaverange_int, a.seq_int, a.autochargeitemtype, a.bedchargecate,
                                   a.confreqid_chr, a.eatdiccate, a.freqid_chr, a.nursecate,
                                   a.ordercateid_leave_chr, a.ordercateid_medicine_chr,
                                   a.ordercateid_transfer_chr, a.usageid_chr, a.ordercateid_lis_chr,
                                   a.mid_medicine_chr
                              from t_bse_bih_specordercate a";
            DataTable dt = new DataTable();
            long ret = 0;
            try
            {
                ret = new clsHRPTableService().lngGetDataTableWithoutParameters(strSql, ref dt);
                if (ret > 0 && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    m_objSpecateVo.m_intISCHECKMED = clsConverter.ToInt(row["ISCHECKMED"].ToString().Trim());
                    m_objSpecateVo.m_intISCONTRLMONEYACTIVED = clsConverter.ToInt(row["ISCONTRLMONEYACTIVED"].ToString().Trim());
                    m_objSpecateVo.m_intISHOSNUMATUO = clsConverter.ToInt(row["ISHOSNUMATUO"].ToString().Trim());
                    m_objSpecateVo.m_intISORDEREXCLUDE = clsConverter.ToInt(row["ISORDEREXCLUDE"].ToString().Trim());
                    m_objSpecateVo.m_intLEAVERANGE_INT = clsConverter.ToInt(row["LEAVERANGE_INT"].ToString().Trim());
                    m_objSpecateVo.m_intSEQ_INT = clsConverter.ToInt(row["SEQ_INT"].ToString().Trim());
                    m_objSpecateVo.m_strAUTOCHARGEITEMTYPE = clsConverter.ToString(row["AUTOCHARGEITEMTYPE"].ToString().Trim());
                    m_objSpecateVo.m_strBEDCHARGECATE = clsConverter.ToString(row["BEDCHARGECATE"].ToString().Trim());
                    m_objSpecateVo.m_strCONFREQID_CHR = clsConverter.ToString(row["CONFREQID_CHR"].ToString().Trim());
                    m_objSpecateVo.m_strEATDICCATE = clsConverter.ToString(row["EATDICCATE"].ToString().Trim());
                    m_objSpecateVo.m_strFREQID_CHR = clsConverter.ToString(row["FREQID_CHR"].ToString().Trim());
                    m_objSpecateVo.m_strNURSECATE = clsConverter.ToString(row["NURSECATE"].ToString().Trim());
                    m_objSpecateVo.m_strORDERCATEID_LEAVE_CHR = clsConverter.ToString(row["ORDERCATEID_LEAVE_CHR"].ToString().Trim());
                    m_objSpecateVo.m_strORDERCATEID_MEDICINE_CHR = clsConverter.ToString(row["ORDERCATEID_MEDICINE_CHR"].ToString().Trim());
                    m_objSpecateVo.m_strORDERCATEID_TRANSFER_CHR = clsConverter.ToString(row["ORDERCATEID_TRANSFER_CHR"].ToString().Trim());
                    m_objSpecateVo.m_strUSAGEID_CHR = clsConverter.ToString(row["USAGEID_CHR"].ToString().Trim());
                    m_objSpecateVo.m_strORDERCATEID_LIS_CHR = clsConverter.ToString(row["ORDERCATEID_LIS_CHR"].ToString().Trim());
                    m_objSpecateVo.m_strMID_MEDICINE_CHR = clsConverter.ToString(row["MID_MEDICINE_CHR"].ToString().Trim());

                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return ret;

        }

        /// <summary>
        /// 查看当前员工号是否有处方权
        /// </summary>
        /// <param name="m_strEmpID"></param>
        /// <param name="m_blAcess"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddGetAccessPower(string m_strEmpID, out bool m_blAcess)
        {
            m_blAcess = false;
            DataTable objDT = new DataTable();
            string strSql = @"
            select a.HASPRESCRIPTIONRIGHT_CHR from t_bse_employee  a where a.empid_chr=?
			";
            long ret = 0;
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPService = new clsHRPTableService();
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strEmpID;
                ret = 0;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if (ret > 0 && objDT.Rows.Count > 0)
                {
                    if (!objDT.Rows[0]["HASPRESCRIPTIONRIGHT_CHR"].ToString().Equals(""))
                    {
                        if (int.Parse(objDT.Rows[0]["HASPRESCRIPTIONRIGHT_CHR"].ToString()) > 0)
                        {
                            m_blAcess = true;
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

            /* <<============================== */
            return ret;

        }
        #endregion

        #region 获取医保状态
        /// <summary>
        /// 获取医保状态		根据收费ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strIsYB">是否医保项（1/0）</param>
        /// <param name="m_strYBClass">医保类型</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetYBStatus(System.Security.Principal.IPrincipal p_objPrincipal, string hos_code, string[] m_strChargeIDArr, out Hashtable m_htbYBClass)
        {

            m_htbYBClass = new Hashtable();
            long lngRes = 0;
            if (m_strChargeIDArr.Length <= 0)
                return 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetYBStatus");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            /*
            string strSQL=@"	
                        SELECT  
decode(upper(a.xmclsa),'F','乙类','O','其他','T','甲类','') YBClass    
FROM ybgd01 a, ybgd02 b
WHERE TRIM (hos_code) = '"+hos_code.ToString().Trim()+@"'
AND TRIM (xmcode) = 
(
select  Trim(b.usercode_chr)
from 
t_bse_chargeitem a,
t_bse_bih_orderdic b,
t_aid_bih_orderdic_charge c
where
a.itemid_chr=c.itemid_chr
and
b.orderdicid_chr=c.orderdicid_chr
and rownum=1
and 
a.itemid_chr='"+m_strChargeID.ToString().Trim()+@"'
)
AND TRIM (a.xmcdea) = TRIM (b.xmcdea)
AND TRIM (a.xmcdeb) = TRIM (b.xmcdeb)
";
*/


            for (int i = 0; i < m_strChargeIDArr.Length; i++)
            {
                if (i > 0)
                {
                    strSQL += " union ";
                }
                strSQL += @"	
				SELECT  '" + m_strChargeIDArr[i].ToString().Trim() + @"' ChargeID,
				decode(upper(a.xmclsa),'F','乙类','O','其他','T','甲类','') YBClass    
				FROM ybgd01 a, ybgd02 b
				WHERE TRIM (hos_code) = '" + hos_code.ToString().Trim() + @"'
				AND TRIM (xmcode) = 
				(
				select  Trim(b.usercode_chr)
				from 
				t_bse_chargeitem a,
				t_bse_bih_orderdic b,
				t_aid_bih_orderdic_charge c
				where
				a.itemid_chr=c.itemid_chr
				and
				b.orderdicid_chr=c.orderdicid_chr
				and rownum=1
				and 
				a.itemid_chr='" + m_strChargeIDArr[i].ToString().Trim() + @"'
				)
				AND TRIM (a.xmcdea) = TRIM (b.xmcdea)
				AND TRIM (a.xmcdeb) = TRIM (b.xmcdeb)
				";
            }

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        if (dtbResult.Rows[i1]["ChargeID"] != System.DBNull.Value && dtbResult.Rows[i1]["YBClass"] != System.DBNull.Value)
                            m_htbYBClass.Add(dtbResult.Rows[i1]["ChargeID"].ToString().Trim(), dtbResult.Rows[i1]["YBClass"].ToString().Trim());
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

        #region 验验样本查询
        /// <summary>
        /// 验验样本查询
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strFind"></param>
        /// <param name="p_dtResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSampleByFindString(string p_strFind, out DataTable p_dtResultArr)
        {
            p_dtResultArr = new DataTable();
            long lngRes = 0;

            string strSQL = @"
                        SELECT a.sample_type_id_chr sample_code,a.sample_type_desc_vchr sample_name
                        FROM t_aid_lis_sampletype a
                        WHERE LOWER (TRIM (a.sample_type_id_chr)) LIKE '[p_strFind]%'
                        OR LOWER (TRIM (a.sample_type_desc_vchr)) LIKE '%[p_strFind]%'
                        OR LOWER (TRIM (a.pycode_chr)) LIKE '%[p_strFind]%'
                        OR LOWER (TRIM (a.wbcode_chr)) LIKE '%[p_strFind]%'
                        ORDER BY a.sample_type_id_chr
							";

            strSQL = strSQL.Replace("[p_strFind]", p_strFind.Trim().ToLower());
            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResultArr);
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

        #region 检查部位查询
        /// <summary>
        /// 验验样本查询
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strFind"></param>
        /// <param name="p_dtResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckByFindString(string p_strFind, out DataTable p_dtResultArr)
        {
            p_dtResultArr = new DataTable();
            long lngRes = 0;

            string strSQL = @"
                SELECT a.partid,a.partname,a.assistcode_chr,a.TYPEID
                FROM ar_apply_partlist a
                where 
                (lower(a.assistcode_chr) like ?
                or
                lower(a.partname) like ?
                or
                lower(a.PYCODE_VCHR) like ?
                or
                lower(a.WBCODE_VCHR) like ?)
                and a.deleted=0
                order by a.ASSISTCODE_CHR
							";

            try
            {
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPService = new clsHRPTableService();
                HRPService.CreateDatabaseParameter(4, out arrParams);

                arrParams[0].Value = p_strFind.Trim().ToLower() + "%";
                arrParams[1].Value = "%" + p_strFind.Trim().ToLower() + "%";
                arrParams[2].Value = p_strFind.Trim().ToLower() + "%";
                arrParams[3].Value = p_strFind.Trim().ToLower() + "%";
                lngRes = 0;
                lngRes = HRPService.lngGetDataTableWithParameters(strSQL, ref p_dtResultArr, arrParams);
                HRPService.Dispose();

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

        #region 检验申请单相关逻辑
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objBIHOrder"></param>
        /// <param name="p_dtResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewCheckByOrderID(clsBIHOrder p_objBIHOrder, out DataTable p_dtResultArr)
        {
            long lngRes = -1;
            p_dtResultArr = new DataTable();
            string strSQL = @"
            select 
            --a.spec_vchr,     --规格 
            --a.use_dec,       --一次邻量 
            c.itemid_chr,    --收费项目ID 
            c.ITEMNAME_VCHR,  --收费项目名称 
            c.ITEMIPUNIT_CHR, --住院收费单位 
            decode(c.IPCHARGEFLG_INT,1,Round(c.ItemPrice_Mny/c.PackQty_Dec,4),0,c.ItemPrice_Mny,Round(c.ItemPrice_Mny/c.PackQty_Dec,4)) MinPrice,
            --单价 

            d.lastname_vchr,
            d.sex_chr,
            d.year,
            

            e.DIAGNOSE_VCHR --诊断

            from 
            
            T_BSE_BIH_OrderDic b,
            T_BSE_ChargeItem c,
            (select lastname_vchr,sex_chr,round(months_between(sysdate,birth_dat)/12) year from t_bse_patient where patientid_chr='[patientid_chr]') d, 
            (select diagnose_vchr from t_opr_bih_register where registerid_chr='[registerid_chr]') e
            where 
           
            b.itemid_chr=c.itemid_chr
            and b.ORDERDICID_CHR='[ORDERDICID_CHR]'
							";

            strSQL = strSQL.Replace("[patientid_chr]", p_objBIHOrder.m_strPatientID.ToString().Trim());
            strSQL = strSQL.Replace("[ORDERDICID_CHR]", p_objBIHOrder.m_strOrderDicID.ToString().Trim());
            strSQL = strSQL.Replace("[registerid_chr]", p_objBIHOrder.m_strRegisterID.ToString().Trim());


            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResultArr);
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

        #region 根据当前诊疗项目ID判断是否是可自动发送的检验项目
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m_strOrderDicID"></param>
        /// <param name="m_blHave"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGegCheckByID(string m_strOrderDicID, out bool m_blHave)
        {
            long lngRes = -1;
            m_blHave = false;
            string strSQL = @"
                    select b.ordercateid_chr
                    from T_BSE_BIH_OrderDic a,t_aid_bih_ordercate b
                    where
                    a.ordercateid_chr=b.ordercateid_chr
                    and 
                    a.status_int=1
                    and 
                    Trim(b.name_chr)='检验'
                    and 
                    a.orderdicid_chr='[orderdicid_chr]'
							";

            strSQL = strSQL.Replace("[orderdicid_chr]", m_strOrderDicID.ToString().Trim());

            try
            {
                DataTable p_dtResultArr = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResultArr);
                objHRPSvc.Dispose();
                if (p_dtResultArr.Rows.Count > 0)
                {
                    m_blHave = true;
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

        #region 根据当前诊疗项目ID判断是否是可自动发送的检验项目--医嘱提交时用
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m_strORDERID_CHR"></param>
        /// <param name="m_blHave"></param>
        /// <param name="m_blSumit"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGegCheckByID(string m_strORDERID_CHR, out bool m_blHave, bool m_blSumit)
        {
            long lngRes = -1;


            m_blHave = false;
            string strSQL = @"
                   select b.ordercateid_chr
                    from T_BSE_BIH_OrderDic a,t_aid_bih_ordercate b,t_opr_bih_order c
                    where
                    a.ordercateid_chr=b.ordercateid_chr
                    and
                    c.orderdicid_chr=a.orderdicid_chr
                    and
                    c.orderid_chr='[orderid_chr]'
                    and 
                    a.status_int=1
                    and 
                    Trim(b.name_chr)='检验'
                    and rownum=1
							";

            strSQL = strSQL.Replace("[orderid_chr]", m_strORDERID_CHR.ToString().Trim());

            try
            {
                DataTable p_dtResultArr = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResultArr);
                objHRPSvc.Dispose();
                if (p_dtResultArr.Rows.Count > 0)
                {
                    m_blHave = true;
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

        #region 根据当前诊疗项目ID判断是否是可自动发送的检查项目
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m_strOrderDicID"></param>
        /// <param name="m_blHave"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetCheckByID2(string m_strOrderDicID, out bool m_blHave)
        {
            long lngRes = -1;
            m_blHave = false;
            //            string strSQL = @"
            //                    select b.ordercateid_chr
            //                    from T_BSE_BIH_OrderDic a,t_aid_bih_ordercate b
            //                    where
            //                    a.ordercateid_chr=b.ordercateid_chr
            //                    and 
            //                    a.status_int=1
            //                    and 
            //                    Trim(b.name_chr)='检查'
            //                    and 
            //                    a.orderdicid_chr='[orderdicid_chr]'
            //							";

            //            strSQL = strSQL.Replace("[orderdicid_chr]", m_strOrderDicID.ToString().Trim());
            string strSQL = @"
               SELECT 
                 m.TYPEID,
                 m.typetext,
                 m.DELETED
            FROM 
           t_bse_bih_orderdic a,
           t_bse_chargeitem b, 
           AR_APPLY_TYPELIST m
          WHERE 
             a.itemid_chr = b.itemid_chr(+)
            and b.APPLY_TYPE_INT=m.typeid(+)
            and a.orderdicid_chr=?
            ";

            try
            {
                DataTable p_dtResultArr = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strOrderDicID;


                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResultArr, arrParams);
                objHRPSvc.Dispose();
                if (p_dtResultArr.Rows.Count > 0)
                {
                    DataRow row = p_dtResultArr.Rows[0];
                    if (!row["TYPEID"].ToString().Trim().Equals("-1") && row["typetext"].ToString().Trim().Length > 0 && row["DELETED"].ToString().Trim().Equals("0"))
                    {
                        m_blHave = true;
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

        #region 为检验申请单赋参数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dtResultArr"></param>
        /// <param name="strTypeID"></param>
        /// <param name="p_objBIHOrder"></param>
        /// <param name="objLMVO"></param>
        /// <param name="itemArr_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSendTestApplyBill(DataTable p_dtResultArr, string strTypeID, clsBIHOrder p_objBIHOrder, out clsLisApplMainVO objLMVO, out clsTestApplyItme_VO[] itemArr_VO)
        {
            ArrayList objTemp = new ArrayList();

            for (int i = 0; i < p_dtResultArr.Rows.Count; i++)
            {

                clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                //  item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Discount]);
                if (p_dtResultArr.Rows[i]["MinPrice"] != null && !p_dtResultArr.Rows[i]["MinPrice"].Equals(""))
                {
                    item_VO.m_decPrice = decimal.Parse(p_dtResultArr.Rows[i]["MinPrice"].ToString().Trim());
                }
                item_VO.m_decQty = p_objBIHOrder.m_dmlGet;
                item_VO.m_decTolPrice = item_VO.m_decQty * item_VO.m_decPrice;
                item_VO.m_strItemID = new clsDoctorWorkStationSvc().m_mthGetResourceIDByItemID(p_dtResultArr.Rows[i]["itemid_chr"].ToString());
                item_VO.m_strItemName = p_dtResultArr.Rows[i]["ITEMNAME_VCHR"].ToString();
                item_VO.m_strSpec = p_objBIHOrder.m_strSpec;
                item_VO.m_strUnit = p_objBIHOrder.m_strUseunit;
                item_VO.m_strOutpatRecipeID = "";
                item_VO.m_strRowNo = i.ToString();
                item_VO.m_strOprDeptID = "";
                item_VO.strPartID = "";
                item_VO.m_strOutpatRecipeDeID = p_dtResultArr.Rows[i]["itemid_chr"].ToString();//这里借用保存项目ID

                strTypeID = "000001";

                objTemp.Add(item_VO);

            }
            if (objTemp.Count <= 0)
            {

                objTemp.Add(new clsTestApplyItme_VO());
            }
            itemArr_VO = (clsTestApplyItme_VO[])objTemp.ToArray(typeof(clsTestApplyItme_VO));

            #region 收费病人基本数据
            objLMVO = new clsLisApplMainVO();
            if (p_dtResultArr.Rows.Count <= 0)
            {
                return -1;
            }
            //给VO附病人数据
            objLMVO.m_intEmergency = 0;
            objLMVO.m_intForm_int = 0;
            objLMVO.m_strAge = p_dtResultArr.Rows[0]["year"] + " 岁";
            objLMVO.m_strAppl_DeptID = p_objBIHOrder.m_strExecDeptID;
            //string strEmployeeID = "0000001";
            //if (this.m_objViewer.LoginInfo != null)
            //{
            //    strEmployeeID = this.m_objViewer.LoginInfo.m_strEmpID;
            //}
            objLMVO.m_strAppl_EmpID = p_objBIHOrder.m_strCreatorID;
            objLMVO.m_strDiagnose = p_dtResultArr.Rows[0]["DIAGNOSE_VCHR"].ToString();
            objLMVO.m_strOperator_ID = p_objBIHOrder.m_strCreatorID;
            objLMVO.m_strPatient_Name = p_dtResultArr.Rows[0]["lastname_vchr"].ToString();
            //objLMVO.m_strPatientcardID = p_dtResultArr.Rows[0]["lastname_vchr"];
            objLMVO.m_strPatientID = p_objBIHOrder.m_strPatientID;
            objLMVO.m_strPatientType = "1";
            objLMVO.m_strSex = p_dtResultArr.Rows[0]["sex_chr"].ToString();
            //急诊标志
            objLMVO.m_intEmergency = 0;
            /*<===============================================*/

            #endregion
            if (itemArr_VO.Length > 0)
            {

                //				DataTable dt;
                //				long l =objSvc.m_mthGetApplyTypeByID(itemArr_VO[0].m_strOutpatRecipeDeID,out dt);
                //				if(l>0&&dt.Rows.Count>0)
                //				{
                //					strTypeID =dt.Rows[0]["ITEMCHECKTYPE_CHR"].ToString().Trim();
                //				}
                objLMVO.m_strSampleTypeID = strTypeID;//加入获取样本类型代码
            }
            else
            {
                return 0;
            }
            //frmLisAppl obj = new frmLisAppl();
            //if (obj.m_mthNewApp(objLMVO, itemArr_VO, false) == System.Windows.Forms.DialogResult.OK)
            //{
            //    //暂时注释
            //    clsLISAppResults[] objAppResult = obj.m_objGetMutiResults();

            //}

            return 1;
        }

        /// <summary>
        /// 检验申请单参数填充
        /// </summary>
        /// <param name="CommitArr"></param>
        /// <param name="objLMVO"></param>
        /// <param name="itemArr_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSendTestApplyBillByCommit(ArrayList CommitArr, out clsLisApplMainVO objLMVO, out clsTestApplyItme_VO[] itemArr_VO)
        {
            ArrayList objTemp = new ArrayList();
            objLMVO = new clsLisApplMainVO();
            itemArr_VO = null;
            clsCommitOrder[] p_objCommitOrder = (clsCommitOrder[])CommitArr.ToArray(typeof(clsCommitOrder));
            for (int i = 0; i < p_objCommitOrder.Length; i++)
            {
                //if (p_objCommitOrder[i].m_strLISAPPLYUNITID_CHR.Trim().Equals("") || p_objCommitOrder[i].m_strSAMPLEID_VCHR.Trim().Equals(""))
                //{
                //    return 0;//不存在样本或申请单元时返回不成功
                //}
                clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                item_VO.m_decPrice = p_objCommitOrder[i].m_dmlPrice;
                item_VO.m_decQty = p_objCommitOrder[i].m_dmlGet;
                item_VO.m_decTolPrice = p_objCommitOrder[i].m_decTotalPrice;
                item_VO.m_strItemID = p_objCommitOrder[i].m_strLISAPPLYUNITID_CHR;
                item_VO.m_strUsageID = p_objCommitOrder[i].m_strSAMPLEID_VCHR;
                item_VO.m_strItemName = p_objCommitOrder[i].m_strName;
                item_VO.m_strSpec = p_objCommitOrder[i].m_strSpec;
                item_VO.m_strSampleId = p_objCommitOrder[i].m_strSAMPLEID_VCHR;
                item_VO.m_strUnit = p_objCommitOrder[i].m_strUseunit;
                item_VO.m_strOutpatRecipeID = "";
                item_VO.m_strRowNo = i.ToString();
                item_VO.m_strOprDeptID = "";
                item_VO.strPartID = "";
                item_VO.m_strOutpatRecipeDeID = p_objCommitOrder[i].m_strChargeITEMID_CHR;//这里借用保存项目ID
                item_VO.m_strOrderID = p_objCommitOrder[i].m_strOrderID;
                item_VO.m_decDiscount = p_objCommitOrder[i].m_decDiscount;
                objTemp.Add(item_VO);
            }
            if (objTemp.Count <= 0)
            {
                objTemp.Add(new clsTestApplyItme_VO());
            }
            itemArr_VO = (clsTestApplyItme_VO[])objTemp.ToArray(typeof(clsTestApplyItme_VO));

            #region 收费病人基本数据

            if (p_objCommitOrder.Length <= 0)
            {
                return -1;
            }
            //给VO附病人数据
            objLMVO.m_intEmergency = 0;
            objLMVO.m_intForm_int = 0;
            objLMVO.m_strAge = p_objCommitOrder[0].m_strAge;

            // objLMVO.m_strAppl_DeptID = p_objCommitOrder[0].m_strExecDeptID;
            if (p_objCommitOrder[0].m_intSOURCETYPE_INT == 1)
            {
                objLMVO.m_strAppl_DeptID = p_objCommitOrder[0].m_strCREATEAREA_ID;
            }
            else
            {
                objLMVO.m_strAppl_DeptID = p_objCommitOrder[0].m_strCURAREAID_CHR;
            }
            string strEmployeeID = p_objCommitOrder[0].m_strCreatorID;
            //if (this.m_objViewer.LoginInfo != null)
            //{
            //    strEmployeeID = this.m_objViewer.LoginInfo.m_strEmpID;
            //}
            objLMVO.m_strAppl_EmpID = p_objCommitOrder[0].m_strCreatorID;
            objLMVO.m_strDiagnose = p_objCommitOrder[0].m_strDIAGNOSE_VCHR;
            objLMVO.m_strOperator_ID = p_objCommitOrder[0].m_strExecutorID; ;
            objLMVO.m_strPatient_Name = p_objCommitOrder[0].m_strPatientName;
            //objLMVO.m_strPatientcardID = p_dtResultArr.Rows[0]["lastname_vchr"];
            objLMVO.m_strPatientID = p_objCommitOrder[0].m_strPatientID;
            objLMVO.m_strPatientType = "1";
            objLMVO.m_strSex = p_objCommitOrder[0].m_strsex_chr;
            //急诊标志
            objLMVO.m_intEmergency = 0;
            /*<===============================================*/
            //收费状态
            objLMVO.m_intChargeState = 1;
            //住院号
            objLMVO.m_strPatient_inhospitalno_chr = p_objCommitOrder[0].m_strINPATIENTID_CHR;
            //床号
            objLMVO.m_strBedNO = p_objCommitOrder[0].m_strBedName;
            //当时病人所在的病区(借用的字段)
            objLMVO.m_strSummary = p_objCommitOrder[0].m_strCURAREAID_CHR;

            objLMVO.m_strOrderunitrelation = p_objCommitOrder[0].m_strOrderID;
            #endregion
            if (itemArr_VO.Length > 0)
            {
                objLMVO.m_strSampleTypeID = p_objCommitOrder[0].m_strSAMPLEID_VCHR;//加入获取样本类型代码
            }
            else
            {
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 查找检查分类
        /// </summary>
        /// <param name="strItemID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetApplyTypeByID(string strItemID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            string strSQL = @"SELECT a.APPLY_TYPE_INT,a.itemchecktype_chr, b.partname
              FROM t_bse_chargeitem a, AR_APPLY_PARTLIST  b
                WHERE a.itemchecktype_chr = b.partid(+) and  a.ITEMID_CHR ='" + strItemID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
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

        /// <summary>
        /// 按编码查询诊疗项目（新加库存）
        /// </summary>
        /// <param name="p_strFindString">查询字符串</param>
        /// <param name="m_intClass">查询条件</param>
        /// <param name="m_strORDERCATEID_CHR">医嘱类型</param>
        /// <param name="arrDic">诊疗项目Vo</param>
        /// <param name="m_dsDicCharge">诊疗项目对应的收费DATASET</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderDicChargeByCode(string p_strFindString, int m_intClass, string m_strORDERCATEID_CHR, bool m_blLessMedControl, string p_strMedDeptId, out clsBIHOrderDic[] arrDic, out DataSet m_dsDicChargeSet)
        // public long m_lngGetOrderDicChargeByCode(string p_strFindString, int m_intClass, string m_strORDERCATEID_CHR, bool m_blLessMedControl, out clsBIHOrderDic[] arrDic, out DataSet m_dsDicChargeSet)
        {
            arrDic = null;
            int m_intLessMedControl = 0;
            if (m_blLessMedControl)
            {
                m_intLessMedControl = 1;
            }
            m_dsDicChargeSet = new DataSet();
            string strMedDeptId = "";
            string[] strMedDeptIdArr = p_strMedDeptId.Split('*');
            int intArrCount = strMedDeptIdArr.Length;
            for (int i = 0; i < intArrCount; i++)
            {
                strMedDeptId += "'" + strMedDeptIdArr[i] + "',";
            }
            strMedDeptId = strMedDeptId.TrimEnd(',');
            #region 当没有选诊疗类型时的过滤
            string strSql2 = @"
              
                SELECT distinct 
                m.TYPEID,
                m.typetext,
                m.DELETED,
                c.partname,
                d.sample_type_desc_vchr sample_name,
                a.partid_vchr, a.sampleid_vchr, a.orderdicid_chr, a.name_chr,
                a.des_vchr, a.usercode_chr, a.wbcode_chr, a.pycode_chr,a.COMMNAME_VCHR,
                a.execdept_chr, a.ordercateid_chr, a.itemid_chr, 
                a.NULLITEMUSE_DEC,a.NULLITEMUSEUNIT_CHR,a.NULLITEMDOSETYPEID_CHR,a.NULLITEMFREQID_VCHR,
                a.LISAPPLYUNITID_CHR,a.APPLYTYPEID_CHR,
                b.isrich_int,b.itemspec_vchr,b.IPCHARGEFLG_INT,b.ITEMOPUNIT_CHR,
                DECODE (b.ipchargeflg_int,
                        1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                        0, b.itemprice_mny,
                        ROUND (b.itemprice_mny / b.packqty_dec, 4)
                       ) itemprice,
                DECODE (b.ipchargeflg_int,
                        1, round (b.tradeprice_mny / b.packqty_dec, 4),
                        0, b.tradeprice_mny,
                        round (b.tradeprice_mny / b.packqty_dec, 4)
                       ) itemtradeprice,
                b.ITEMUNIT_CHR,b.dosage_dec,b.dosageunit_chr, b.itemipunit_chr useunit_chr,
                b.usageid_chr,
                b.ITEMCOMMNAME_VCHR,
                b.FREQID_CHR,
                b.itemsrctype_int,
                b.PACKQTY_DEC,
                g.CHILDDOSAGE_DEC,
                g.ADULTDOSAGE_DEC,
                g.MEDICNETYPE_INT,
                g.HYPE_INT,
                h.typeid_chr MedicareTypeID,
                h.typename_vchr MedicareTypeName,
                L.remark_vchr medicineRemark,
                s.noqtyflag_int as IPNOQTYFLAG_INT,
                '' CommonName,
                n.MEDICINEPREPTYPENAME_VCHR,
                n.FLAGA_INT MEDICINEPREPTYPE_FLAGE,
                b.inpinsurancetype_vchr as ybtypeid,
                 s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num
            FROM 
           (select a.* from 
           t_bse_bih_orderdic a,t_aid_bih_ordercate b
           where
           a.ordercateid_chr=b.ordercateid_chr
           and b.orderselect_int=1 and a.status_int = 1
           and ( ( [FindItem] like ? ) or (LOWER(a.commname_vchr|| a.name_chr) like ?)) and ROWNUM<=[ROWNUM] order by a.UserCode_Chr,a.orderdicid_chr
           ) a,
           t_bse_chargeitem b,
           ar_apply_partlist c,
           t_aid_lis_sampletype d,
           T_BSE_MEDICINE g,
           T_AID_MEDICARETYPE h,
           t_bse_medicinestddesc l,
           AR_APPLY_TYPELIST m,
           T_AID_MEDICINEPREPTYPE n,
           (select t.noqtyflag_int,t.opcurrentgross_num, t.medicineid_chr, t.ipcurrentgross_num
          from t_ds_storage t
         where t.drugstoreid_chr in ([meddeptid])) s
           
          WHERE 
             a.itemid_chr = b.itemid_chr(+)
            and a.PARTID_VCHR=c.partid(+)
            and a.SAMPLEID_VCHR=d.sample_type_id_chr(+)
            and b.ITEMSRCID_VCHR=g.medicineid_chr(+)
            and b.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
            and g.medicineid_chr=s.medicineid_chr(+)
            and g.medicinestdid_chr = L.medicinestdid_chr(+)
            and a.APPLYTYPEID_CHR=m.typeid(+)
            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
            --and s.drugstoreid_chr in ([meddeptid]) 
            order by [m_strClass],IPNOQTYFLAG_INT
            ";//9981,s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,9999t_ds_storage s,10006and g.medicineid_chr=s.medicineid_chr(+)
            #endregion
            string strSql = @"
              
                SELECT distinct 
                m.TYPEID,
                m.typetext,
                m.DELETED,
                c.partname,
                d.sample_type_desc_vchr sample_name,
                a.partid_vchr, a.sampleid_vchr, a.orderdicid_chr, a.name_chr,
                a.des_vchr, a.usercode_chr, a.wbcode_chr, a.pycode_chr,a.COMMNAME_VCHR,
                a.execdept_chr, a.ordercateid_chr, a.itemid_chr, 
                a.NULLITEMUSE_DEC,a.NULLITEMUSEUNIT_CHR,a.NULLITEMDOSETYPEID_CHR,a.NULLITEMFREQID_VCHR,
                a.LISAPPLYUNITID_CHR,a.APPLYTYPEID_CHR,
                b.isrich_int,b.itemspec_vchr,b.IPCHARGEFLG_INT,b.ITEMOPUNIT_CHR,
                DECODE (b.ipchargeflg_int,
                        1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                        0, b.itemprice_mny,
                        ROUND (b.itemprice_mny / b.packqty_dec, 4)
                       ) itemprice,
                DECODE (b.ipchargeflg_int,
                        1, round (b.tradeprice_mny / b.packqty_dec, 4),
                        0, b.tradeprice_mny,
                        round (b.tradeprice_mny / b.packqty_dec, 4)
                       ) itemtradeprice,
                b.ITEMUNIT_CHR,b.dosage_dec,b.dosageunit_chr, b.itemipunit_chr useunit_chr,
                b.usageid_chr,
                b.ITEMCOMMNAME_VCHR,
                b.FREQID_CHR,
                b.itemsrctype_int,
                b.PACKQTY_DEC,
                g.CHILDDOSAGE_DEC,
                g.ADULTDOSAGE_DEC,
                g.MEDICNETYPE_INT,
                g.HYPE_INT,
                h.typeid_chr MedicareTypeID,
                h.typename_vchr MedicareTypeName,
                L.remark_vchr medicineRemark,
                s.noqtyflag_int as IPNOQTYFLAG_INT,
                '' CommonName,
                n.MEDICINEPREPTYPENAME_VCHR,
                n.FLAGA_INT MEDICINEPREPTYPE_FLAGE,
                b.inpinsurancetype_vchr as ybtypeid,
                s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num
            FROM 
           (select a.* from 
           t_bse_bih_orderdic a
           where
           a.status_int = 1
           [ordercateid]
           and (([FindItem] like ? ) or (LOWER(a.commname_vchr|| a.name_chr) like ?)) and ROWNUM<=[ROWNUM] order by a.UserCode_Chr,a.orderdicid_chr
           ) a,
           t_bse_chargeitem b,
           ar_apply_partlist c,
           t_aid_lis_sampletype d,
           T_BSE_MEDICINE g,
           T_AID_MEDICARETYPE h,
           t_aid_lis_apply_unit k,
           t_bse_medicinestddesc L,
           AR_APPLY_TYPELIST m,
           T_AID_MEDICINEPREPTYPE n,
           (select t.noqtyflag_int,t.opcurrentgross_num, t.medicineid_chr, t.ipcurrentgross_num
          from t_ds_storage t
         where t.drugstoreid_chr in ([meddeptid])) s
          WHERE 
             a.itemid_chr = b.itemid_chr(+)
            and a.PARTID_VCHR=c.partid(+)
            and a.SAMPLEID_VCHR=d.sample_type_id_chr(+)
            and g.medicineid_chr=s.medicineid_chr(+) 
            and b.ITEMSRCID_VCHR=g.medicineid_chr(+)
            and b.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
            and g.medicinestdid_chr = L.medicinestdid_chr(+)
            and a.APPLYTYPEID_CHR=m.typeid(+)
            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
            --and s.drugstoreid_chr in ([meddeptid]) 
            order by [m_strClass],IPNOQTYFLAG_INT
            ";//10049s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,10068 t_ds_storage s,10073and g.medicineid_chr=s.medicineid_chr(+)

            //string strFind = " (( LOWER(UserCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(WBCode_Chr)	 like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(PYCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(Name_Chr) like '%" + p_strFindString.ToLower().Trim() + "%')) ";
            string strFind = "";
            string m_strClass = "a.UserCode_Chr";
            switch (m_intClass)
            {
                case -1:
                    strFind = "LOWER(a.PYCode_Chr)";
                    m_strClass = "a.PYCode_Chr";
                    break;
                case 0:
                    strFind = "LOWER(a.PYCode_Chr)";
                    m_strClass = "a.PYCode_Chr";
                    break;
                case 1:
                    strFind = "LOWER(a.WBCode_Chr)";
                    m_strClass = "a.WBCode_Chr";
                    break;
                case 2:
                    strFind = "LOWER(a.Name_Chr)";
                    m_strClass = "a.Name_Chr";
                    break;
                case 3:
                    strFind = "LOWER(a.UserCode_Chr)";
                    m_strClass = "a.UserCode_Chr";
                    break;
            }
            string m_strORDERCATEID = "";
            if (!m_strORDERCATEID_CHR.Trim().Equals(""))
            {
                m_strORDERCATEID = " and a.ordercateid_chr= ?";
            }
            else
            {
                strSql = strSql2;
            }

            strSql = strSql.Replace("[FindItem]", strFind);
            strSql = strSql.Replace("[ROWNUM]", m_intGetTop().ToString());
            strSql = strSql.Replace("[ordercateid]", m_strORDERCATEID.Trim());
            strSql = strSql.Replace("[m_strClass]", m_strClass.Trim());
            strSql = strSql.Replace("[meddeptid]", strMedDeptId);
            string strFind2 = p_strFindString.ToLower().Trim() + "%";
            string strFind3 = "%" + p_strFindString.ToLower().Trim() + "%";
            //if (m_intClass == 2)
            //{
            //    strFind2 = "%" + p_strFindString.ToLower().Trim() + "%";
            //}
            System.Data.IDataParameter[] arrParams = null;
            clsHRPTableService HRPService = new clsHRPTableService();
            if (m_strORDERCATEID_CHR.Trim().Equals(""))
            {
                HRPService.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = strFind2;
                arrParams[1].Value = strFind3;

            }
            else
            {
                HRPService.CreateDatabaseParameter(3, out arrParams);
                arrParams[0].Value = m_strORDERCATEID_CHR;
                arrParams[1].Value = strFind2;
                arrParams[2].Value = strFind3;

            }
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                #region
                strSql2 = @"
                	SELECT  A.orderdicid_chr,c.itemid_chr, trim(C.ITEMNAME_VCHR) as ItemName
							,decode(A.itemid_chr,B.itemid_chr,1,0 )IsChiefItem	
							,a.QTY_INT
                            ,c.ITEMCODE_VCHR
                            ,c.ITEMUNIT_CHR
							,c.ITEMIPUNIT_CHR
                            ,c.ITEMOPUNIT_CHR
                            ,c.IFSTOP_INT
							,c.DOSAGE_DEC
							,c.DOSAGEUNIT_CHR
							,c.ITEMSPEC_VCHR
                            ,c.ITEMSRCTYPE_INT
							,decode(c.IPCHARGEFLG_INT,1,Round(c.ItemPrice_Mny/c.PackQty_Dec,4),0,c.ItemPrice_Mny,Round(c.ItemPrice_Mny/c.PackQty_Dec,4)) MinPrice
                            ,decode (c.ipchargeflg_int,1, Round (c.tradeprice_mny / c.packqty_dec, 4),0, c.tradeprice_mny,Round (c.tradeprice_mny / c.packqty_dec, 4)) itemtradeprice
                            ,s.noqtyflag_int as IPNOQTYFLAG_INT
                            ,g.IPCHARGEFLG_INT
                            ,h.typename_vchr MedicareTypeName
                            ,n.MEDICINEPREPTYPENAME_VCHR
                            ,n.FLAGA_INT MEDICINEPREPTYPE_FLAGE
                            ,s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,s.drugstoreid_chr,
                            g.expenselimit_mny
                            FROM
							T_AID_BIH_ORDERDIC_CHARGE A , 
                            (
                          select	
                          A.itemid_chr,A.USERCODE_CHR ,A.orderdicid_chr
                          from T_BSE_BIH_ORDERDIC A,t_aid_bih_ordercate b
                          where a.ordercateid_chr=b.ordercateid_chr
                          and b.orderselect_int=1 and a.status_int = 1
                          and (([FindItem] like ? ) or (LOWER(a.commname_vchr|| a.name_chr) like ?)) and ROWNUM<=[ROWNUM]  order by a.UserCode_Chr,a.orderdicid_chr) B ,
                            T_BSE_CHARGEITEM C 
                            ,T_BSE_MEDICINE g
                            ,T_AID_MEDICARETYPE h
                            ,T_AID_MEDICINEPREPTYPE n
                            ,(select j.medicineid_chr,
       j.drugstoreid_chr,j.noqtyflag_int,
       sum(j.ipcurrentgross_num) as ipcurrentgross_num,
       sum(j.opcurrentgross_num) as opcurrentgross_num
  from t_ds_storage j, t_ds_storage_detail k
 where j.medicineid_chr = k.medicineid_chr
   and j.drugstoreid_chr = k.drugstoreid_chr and k.canprovide_int=1 
   and j.drugstoreid_chr in ([meddeptid])
 group by j.medicineid_chr,j.drugstoreid_chr,j.noqtyflag_int
         ) s
 
                            WHERE A.orderdicid_chr =B.orderdicid_chr AND A.itemid_chr =C.itemid_chr 
                            and c.ITEMSRCID_VCHR=g.medicineid_chr(+)
                            and c.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
                            and g.medicineid_chr=s.medicineid_chr(+) 
                            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
                            
                           ORDER BY B.USERCODE_CHR,B.orderdicid_chr,IsChiefItem DESC 
                       ";//10172s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,10186 t_ds_storage s10191 and g.medicineid_chr=s.medicineid_chr(+),10193and s.drugstoreid_chr=?
                #endregion
                strSql = @"
                	SELECT  A.orderdicid_chr,c.itemid_chr, trim(C.ITEMNAME_VCHR) as ItemName
							,decode(A.itemid_chr,B.itemid_chr,1,0 )IsChiefItem	
							,a.QTY_INT
                            ,c.ITEMCODE_VCHR
                            ,c.ITEMUNIT_CHR
							,c.ITEMIPUNIT_CHR
                            ,c.ITEMOPUNIT_CHR
                            ,c.IFSTOP_INT
							,c.DOSAGE_DEC
							,c.DOSAGEUNIT_CHR
							,c.ITEMSPEC_VCHR
                            ,c.ITEMSRCTYPE_INT
							,decode(c.IPCHARGEFLG_INT,1,Round(c.ItemPrice_Mny/c.PackQty_Dec,4),0,c.ItemPrice_Mny,Round(c.ItemPrice_Mny/c.PackQty_Dec,4)) MinPrice
                            ,decode(c.IPCHARGEFLG_INT,1,Round(c.tradeprice_mny/c.PackQty_Dec,4),0,c.tradeprice_mny,Round(c.tradeprice_mny/c.PackQty_Dec,4)) itemtradeprice
                            ,s.noqtyflag_int as IPNOQTYFLAG_INT
                            ,g.IPCHARGEFLG_INT
                            ,h.typename_vchr MedicareTypeName
                            ,n.MEDICINEPREPTYPENAME_VCHR
                            ,n.FLAGA_INT MEDICINEPREPTYPE_FLAGE
                            ,s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,s.drugstoreid_chr,
                            g.expenselimit_mny
                            FROM
							T_AID_BIH_ORDERDIC_CHARGE A , 
                            (
                          select	
                          A.itemid_chr,A.USERCODE_CHR ,A.orderdicid_chr
                          from T_BSE_BIH_ORDERDIC A
                          where  a.status_int=1 
                          [ordercateid]
                          and (([FindItem] like ? ) or (LOWER(a.commname_vchr|| a.name_chr) like ?)) and ROWNUM<=[ROWNUM]  order by a.UserCode_Chr,a.orderdicid_chr) B ,
                            T_BSE_CHARGEITEM C 
                            ,T_BSE_MEDICINE g
                            ,T_AID_MEDICARETYPE h
                            , T_AID_MEDICINEPREPTYPE n
                             ,(select j.medicineid_chr,
       j.drugstoreid_chr,j.noqtyflag_int,
       sum(j.ipcurrentgross_num) as ipcurrentgross_num,
       sum(j.opcurrentgross_num) as opcurrentgross_num
  from t_ds_storage j, t_ds_storage_detail k
 where j.medicineid_chr = k.medicineid_chr
   and j.drugstoreid_chr = k.drugstoreid_chr and k.canprovide_int=1 
   and j.drugstoreid_chr in ([meddeptid])
 group by j.medicineid_chr,j.drugstoreid_chr,j.noqtyflag_int) s

                            WHERE A.orderdicid_chr =B.orderdicid_chr AND A.itemid_chr =C.itemid_chr 
                            and g.medicineid_chr=s.medicineid_chr(+) 
                              
                            and c.ITEMSRCID_VCHR=g.medicineid_chr(+)
                            and c.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
                            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
                           
                           ORDER BY B.USERCODE_CHR,B.orderdicid_chr,IsChiefItem DESC 
                       ";//10216s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,10230t_ds_storage s,10233and g.medicineid_chr=s.medicineid_chr(+),10237and s.drugstoreid_chr=?
                if (m_strORDERCATEID.Trim().Equals(""))
                {
                    strSql = strSql2;
                }
                strSql = strSql.Replace("[FindItem]", strFind);
                strSql = strSql.Replace("[ROWNUM]", m_intGetTop().ToString());
                strSql = strSql.Replace("[ordercateid]", m_strORDERCATEID.Trim());
                strSql = strSql.Replace("[meddeptid]", strMedDeptId);
                System.Data.IDataParameter[] arrParams2 = null;
                if (m_strORDERCATEID_CHR.Trim().Equals(""))
                {
                    HRPService.CreateDatabaseParameter(2, out arrParams2);//3改为2
                    arrParams2[0].Value = strFind2;
                    arrParams2[1].Value = strFind3;


                }
                else
                {
                    HRPService.CreateDatabaseParameter(3, out arrParams2);//4改为3
                    arrParams2[0].Value = m_strORDERCATEID_CHR;
                    arrParams2[1].Value = strFind2;
                    arrParams2[2].Value = strFind3;


                }
                DataTable objDT2 = new DataTable("chargeList");
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT2, arrParams2);
                HRPService.Dispose();
                if (ret > 0)
                {
                    m_dsDicChargeSet.Tables.Add(objDT2);
                }
                if ((ret > 0) && (objDT != null))
                {
                    m_lngConvertOrderDicByTable(out arrDic, objDT, m_blLessMedControl);


                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        /// <summary>
        /// 按编码查询诊疗项目
        /// </summary>
        /// <param name="p_strFindString">查询字符串</param>
        /// <param name="m_intClass">查询条件</param>
        /// <param name="m_strORDERCATEID_CHR">医嘱类型</param>
        /// <param name="arrDic">诊疗项目Vo</param>
        /// <param name="m_dsDicCharge">诊疗项目对应的收费DATASET</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderDicChargeByCode(string p_strFindString, int m_intClass, string m_strORDERCATEID_CHR, bool m_blLessMedControl, out clsBIHOrderDic[] arrDic, out DataSet m_dsDicChargeSet)
        {
            arrDic = null;
            int m_intLessMedControl = 0;
            if (m_blLessMedControl)
            {
                m_intLessMedControl = 1;
            }
            m_dsDicChargeSet = new DataSet();
            #region 当没有选诊疗类型时的过滤
            string strSql2 = @"
              
                SELECT distinct 
                m.TYPEID,
                m.typetext,
                m.DELETED,
                c.partname,
                d.sample_type_desc_vchr sample_name,
                a.partid_vchr, a.sampleid_vchr, a.orderdicid_chr, a.name_chr,
                a.des_vchr, a.usercode_chr, a.wbcode_chr, a.pycode_chr,a.COMMNAME_VCHR,
                a.execdept_chr, a.ordercateid_chr, a.itemid_chr, 
                a.NULLITEMUSE_DEC,a.NULLITEMUSEUNIT_CHR,a.NULLITEMDOSETYPEID_CHR,a.NULLITEMFREQID_VCHR,
                a.LISAPPLYUNITID_CHR,a.APPLYTYPEID_CHR,
                b.isrich_int,b.itemspec_vchr,b.IPCHARGEFLG_INT,b.ITEMOPUNIT_CHR,
                DECODE (b.ipchargeflg_int,
                        1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                        0, b.itemprice_mny,
                        ROUND (b.itemprice_mny / b.packqty_dec, 4)
                       ) itemprice,
                b.ITEMUNIT_CHR,b.dosage_dec,b.dosageunit_chr, b.itemipunit_chr useunit_chr,
                b.usageid_chr,
                b.ITEMCOMMNAME_VCHR,
                b.FREQID_CHR,
                b.itemsrctype_int,
                b.PACKQTY_DEC,
                g.CHILDDOSAGE_DEC,
                g.ADULTDOSAGE_DEC,
                g.MEDICNETYPE_INT,
                g.HYPE_INT,
                h.typeid_chr MedicareTypeID,
                h.typename_vchr MedicareTypeName,
                L.remark_vchr medicineRemark,
                g.IPNOQTYFLAG_INT,
                '' CommonName,
                n.MEDICINEPREPTYPENAME_VCHR,
                n.FLAGA_INT MEDICINEPREPTYPE_FLAGE,
                b.inpinsurancetype_vchr as ybtypeid
            FROM 
           (select a.* from 
           t_bse_bih_orderdic a,t_aid_bih_ordercate b
           where
           a.ordercateid_chr=b.ordercateid_chr
           and b.orderselect_int=1 and a.status_int = 1
           and ( ( [FindItem] like ? ) or (LOWER(a.commname_vchr|| a.name_chr) like ?)) and ROWNUM<=[ROWNUM] order by a.UserCode_Chr,a.orderdicid_chr
           ) a,
           t_bse_chargeitem b,
           ar_apply_partlist c,
           t_aid_lis_sampletype d,
           T_BSE_MEDICINE g,
           T_AID_MEDICARETYPE h,
           t_bse_medicinestddesc l,
           AR_APPLY_TYPELIST m,
           T_AID_MEDICINEPREPTYPE n
           
          WHERE 
             a.itemid_chr = b.itemid_chr(+)
            and a.PARTID_VCHR=c.partid(+)
            and a.SAMPLEID_VCHR=d.sample_type_id_chr(+)
            and b.ITEMSRCID_VCHR=g.medicineid_chr(+)
            and b.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
             
            and g.medicinestdid_chr = L.medicinestdid_chr(+)
            and a.APPLYTYPEID_CHR=m.typeid(+)
            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
            order by [m_strClass],IPNOQTYFLAG_INT
            ";
            #endregion
            string strSql = @"
              
                SELECT distinct 
                m.TYPEID,
                m.typetext,
                m.DELETED,
                c.partname,
                d.sample_type_desc_vchr sample_name,
                a.partid_vchr, a.sampleid_vchr, a.orderdicid_chr, a.name_chr,
                a.des_vchr, a.usercode_chr, a.wbcode_chr, a.pycode_chr,a.COMMNAME_VCHR,
                a.execdept_chr, a.ordercateid_chr, a.itemid_chr, 
                a.NULLITEMUSE_DEC,a.NULLITEMUSEUNIT_CHR,a.NULLITEMDOSETYPEID_CHR,a.NULLITEMFREQID_VCHR,
                a.LISAPPLYUNITID_CHR,a.APPLYTYPEID_CHR,
                b.isrich_int,b.itemspec_vchr,b.IPCHARGEFLG_INT,b.ITEMOPUNIT_CHR,
                DECODE (b.ipchargeflg_int,
                        1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                        0, b.itemprice_mny,
                        ROUND (b.itemprice_mny / b.packqty_dec, 4)
                       ) itemprice,
                b.ITEMUNIT_CHR,b.dosage_dec,b.dosageunit_chr, b.itemipunit_chr useunit_chr,
                b.usageid_chr,
                b.ITEMCOMMNAME_VCHR,
                b.FREQID_CHR,
                b.itemsrctype_int,
                b.PACKQTY_DEC,
                g.CHILDDOSAGE_DEC,
                g.ADULTDOSAGE_DEC,
                g.MEDICNETYPE_INT,
                g.HYPE_INT,
                h.typeid_chr MedicareTypeID,
                h.typename_vchr MedicareTypeName,
                L.remark_vchr medicineRemark,
                g.IPNOQTYFLAG_INT,
                '' CommonName,
                n.MEDICINEPREPTYPENAME_VCHR,
                n.FLAGA_INT MEDICINEPREPTYPE_FLAGE,
                b.inpinsurancetype_vchr as ybtypeid
                
            FROM 
           (select a.* from 
           t_bse_bih_orderdic a
           where
           a.status_int = 1
           [ordercateid]
           and (([FindItem] like ? ) or (LOWER(a.commname_vchr|| a.name_chr) like ?)) and ROWNUM<=[ROWNUM] order by a.UserCode_Chr,a.orderdicid_chr
           ) a,
           t_bse_chargeitem b,
           ar_apply_partlist c,
           t_aid_lis_sampletype d,
           T_BSE_MEDICINE g,
           T_AID_MEDICARETYPE h,
           t_aid_lis_apply_unit k,
           t_bse_medicinestddesc L,
           AR_APPLY_TYPELIST m,
           T_AID_MEDICINEPREPTYPE n
           
          WHERE 
             a.itemid_chr = b.itemid_chr(+)
            and a.PARTID_VCHR=c.partid(+)
            and a.SAMPLEID_VCHR=d.sample_type_id_chr(+)
             
            and b.ITEMSRCID_VCHR=g.medicineid_chr(+)
            and b.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
            and g.medicinestdid_chr = L.medicinestdid_chr(+)
            and a.APPLYTYPEID_CHR=m.typeid(+)
            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
            order by [m_strClass],IPNOQTYFLAG_INT
            ";
            string strFind = "";
            string m_strClass = "a.UserCode_Chr";
            switch (m_intClass)
            {
                case -1:
                    strFind = "LOWER(a.PYCode_Chr)";
                    m_strClass = "a.PYCode_Chr";
                    break;
                case 0:
                    strFind = "LOWER(a.PYCode_Chr)";
                    m_strClass = "a.PYCode_Chr";
                    break;
                case 1:
                    strFind = "LOWER(a.WBCode_Chr)";
                    m_strClass = "a.WBCode_Chr";
                    break;
                case 2:
                    strFind = "LOWER(a.Name_Chr)";
                    m_strClass = "a.Name_Chr";
                    break;
                case 3:
                    strFind = "LOWER(a.UserCode_Chr)";
                    m_strClass = "a.UserCode_Chr";
                    break;
            }
            string m_strORDERCATEID = "";
            if (!m_strORDERCATEID_CHR.Trim().Equals(""))
            {
                m_strORDERCATEID = " and a.ordercateid_chr= ?";
            }
            else
            {
                strSql = strSql2;
            }

            strSql = strSql.Replace("[FindItem]", strFind);
            strSql = strSql.Replace("[ROWNUM]", m_intGetTop().ToString());
            strSql = strSql.Replace("[ordercateid]", m_strORDERCATEID.Trim());
            strSql = strSql.Replace("[m_strClass]", m_strClass.Trim());

            string strFind2 = p_strFindString.ToLower().Trim() + "%";
            string strFind3 = "%" + p_strFindString.ToLower().Trim() + "%";

            System.Data.IDataParameter[] arrParams = null;
            clsHRPTableService HRPService = new clsHRPTableService();
            if (m_strORDERCATEID_CHR.Trim().Equals(""))
            {
                HRPService.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = strFind2;
                arrParams[1].Value = strFind3;

            }
            else
            {
                HRPService.CreateDatabaseParameter(3, out arrParams);
                arrParams[0].Value = m_strORDERCATEID_CHR;
                arrParams[1].Value = strFind2;
                arrParams[2].Value = strFind3;

            }
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                #region
                strSql2 = @"
                	SELECT  A.orderdicid_chr, trim(C.ITEMNAME_VCHR) as ItemName
							,decode(A.itemid_chr,B.itemid_chr,1,0 )IsChiefItem	
							,a.QTY_INT
                            ,c.ITEMCODE_VCHR
                            ,c.ITEMUNIT_CHR
							,c.ITEMIPUNIT_CHR
                            ,c.ITEMOPUNIT_CHR
                            ,c.IFSTOP_INT
							,c.DOSAGE_DEC
							,c.DOSAGEUNIT_CHR
							,c.ITEMSPEC_VCHR
                            ,c.ITEMSRCTYPE_INT
							,decode(c.IPCHARGEFLG_INT,1,Round(c.ItemPrice_Mny/c.PackQty_Dec,4),0,c.ItemPrice_Mny,Round(c.ItemPrice_Mny/c.PackQty_Dec,4)) MinPrice
                            ,g.IPNOQTYFLAG_INT
                            ,g.IPCHARGEFLG_INT
                            ,h.typename_vchr MedicareTypeName
                            ,n.MEDICINEPREPTYPENAME_VCHR
                            ,n.FLAGA_INT MEDICINEPREPTYPE_FLAGE
                            
                            FROM
							T_AID_BIH_ORDERDIC_CHARGE A , 
                            (
                          select	
                          A.itemid_chr,A.USERCODE_CHR ,A.orderdicid_chr
                          from T_BSE_BIH_ORDERDIC A,t_aid_bih_ordercate b
                          where a.ordercateid_chr=b.ordercateid_chr
                          and b.orderselect_int=1 and a.status_int = 1
                          and (([FindItem] like ? ) or (LOWER(a.commname_vchr|| a.name_chr) like ?)) and ROWNUM<=[ROWNUM]  order by a.UserCode_Chr,a.orderdicid_chr) B ,
                            T_BSE_CHARGEITEM C 
                            ,T_BSE_MEDICINE g
                            ,T_AID_MEDICARETYPE h
                            ,T_AID_MEDICINEPREPTYPE n
                            
 
                            WHERE A.orderdicid_chr =B.orderdicid_chr AND A.itemid_chr =C.itemid_chr 
                            and c.ITEMSRCID_VCHR=g.medicineid_chr(+)
                            and c.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
                            
                            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
                            
                           ORDER BY B.USERCODE_CHR,B.orderdicid_chr,IsChiefItem DESC 
                       ";//10172s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,10186 t_ds_storage s10191 and g.medicineid_chr=s.medicineid_chr(+),10193and s.drugstoreid_chr=?
                #endregion
                strSql = @"
                	SELECT  A.orderdicid_chr, trim(C.ITEMNAME_VCHR) as ItemName
							,decode(A.itemid_chr,B.itemid_chr,1,0 )IsChiefItem	
							,a.QTY_INT
                            ,c.ITEMCODE_VCHR
                            ,c.ITEMUNIT_CHR
							,c.ITEMIPUNIT_CHR
                            ,c.ITEMOPUNIT_CHR
                            ,c.IFSTOP_INT
							,c.DOSAGE_DEC
							,c.DOSAGEUNIT_CHR
							,c.ITEMSPEC_VCHR
                            ,c.ITEMSRCTYPE_INT
							,decode(c.IPCHARGEFLG_INT,1,Round(c.ItemPrice_Mny/c.PackQty_Dec,4),0,c.ItemPrice_Mny,Round(c.ItemPrice_Mny/c.PackQty_Dec,4)) MinPrice
                            ,g.IPNOQTYFLAG_INT
                            ,g.IPCHARGEFLG_INT
                            ,h.typename_vchr MedicareTypeName
                            ,n.MEDICINEPREPTYPENAME_VCHR
                            ,n.FLAGA_INT MEDICINEPREPTYPE_FLAGE
                              
                            FROM
							T_AID_BIH_ORDERDIC_CHARGE A , 
                            (
                          select	
                          A.itemid_chr,A.USERCODE_CHR ,A.orderdicid_chr
                          from T_BSE_BIH_ORDERDIC A
                          where  a.status_int=1 
                          [ordercateid]
                          and (([FindItem] like ? ) or (LOWER(a.commname_vchr|| a.name_chr) like ?)) and ROWNUM<=[ROWNUM]  order by a.UserCode_Chr,a.orderdicid_chr) B ,
                            T_BSE_CHARGEITEM C 
                            ,T_BSE_MEDICINE g
                            ,T_AID_MEDICARETYPE h
                            , T_AID_MEDICINEPREPTYPE n
                             

                            WHERE A.orderdicid_chr =B.orderdicid_chr AND A.itemid_chr =C.itemid_chr 
                              
                            and c.ITEMSRCID_VCHR=g.medicineid_chr(+)
                            and c.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
                            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
                            
                           ORDER BY B.USERCODE_CHR,B.orderdicid_chr,IsChiefItem DESC 
                       ";
                if (m_strORDERCATEID.Trim().Equals(""))
                {
                    strSql = strSql2;
                }
                strSql = strSql.Replace("[FindItem]", strFind);
                strSql = strSql.Replace("[ROWNUM]", m_intGetTop().ToString());
                strSql = strSql.Replace("[ordercateid]", m_strORDERCATEID.Trim());

                System.Data.IDataParameter[] arrParams2 = null;
                if (m_strORDERCATEID_CHR.Trim().Equals(""))
                {
                    HRPService.CreateDatabaseParameter(2, out arrParams2);
                    arrParams2[0].Value = strFind2;
                    arrParams2[1].Value = strFind3;


                }
                else
                {
                    HRPService.CreateDatabaseParameter(3, out arrParams2);
                    arrParams2[0].Value = m_strORDERCATEID_CHR;
                    arrParams2[1].Value = strFind2;
                    arrParams2[2].Value = strFind3;


                }
                DataTable objDT2 = new DataTable("chargeList");
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT2, arrParams2);
                HRPService.Dispose();
                if (ret > 0)
                {
                    m_dsDicChargeSet.Tables.Add(objDT2);
                }
                if ((ret > 0) && (objDT != null))
                {
                    m_lngConvertOrderDicByTableNOCheck(out arrDic, objDT, m_blLessMedControl);


                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        #region  进行诊疗项目VO填充,判断库存，复用模板时用。
        /// <summary>
        /// 进行诊疗项目VO填充
        /// </summary>
        /// <param name="arrDic">返回的vo数组</param>
        /// <param name="objDT">数据表</param>
        /// <param name="m_blLessMedControl">是否显示缺药(true-显示,false-不显示)</param>
        /// <returns></returns>
        internal void m_lngConvertOrderDicByTable(out clsBIHOrderDic[] arrDic, DataTable objDT, bool m_blLessMedControl)
        {
            arrDic = new clsBIHOrderDic[0];
            ArrayList m_arrDic = new ArrayList();
            clsBIHOrderDic objDic = null;
            Hashtable hasOrderID = new Hashtable();

            int m_intIPNOQTYFLAG_INT = 0;//中心药房缺药标志 0-有药 1－缺药
            //排序
            DataView myDataView = new DataView(objDT);

            myDataView.Sort = "medicineremark desc, IPNOQTYFLAG_INT asc";
            objDT = myDataView.ToTable();
            /*<=============================*/
            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                DataRow row = objDT.Rows[i];
                if (!row["IPNOQTYFLAG_INT"].ToString().Trim().Equals(""))
                {
                    m_intIPNOQTYFLAG_INT = clsConverter.ToInt(row["IPNOQTYFLAG_INT"].ToString().Trim());//中心药房缺药标志 0-有药 1－缺药
                }
                if (m_blLessMedControl == false)//缺药不显示开关
                {
                    if (m_intIPNOQTYFLAG_INT == 1)//缺药
                    {
                        continue;
                    }
                }

                string ID = clsConverter.ToString(row["OrderDicID_Chr"]).Trim();
                if (hasOrderID.ContainsKey(ID))
                {
                    continue;
                }
                else
                {
                    hasOrderID.Add(ID, null);
                }

                objDic = new clsBIHOrderDic();
                objDic.m_strOrderDicID = ID;
                objDic.m_strName = clsConverter.ToString(row["Name_Chr"]).Trim();
                objDic.m_strDesc = clsConverter.ToString(row["Des_VChr"]).Trim();
                objDic.m_strUserCode = clsConverter.ToString(row["UserCode_Chr"]).Trim();
                objDic.m_strWBCode = clsConverter.ToString(row["WBCode_Chr"]).Trim();
                objDic.m_strPYCode = clsConverter.ToString(row["PYCode_Chr"]).Trim();

                objDic.m_strExecDept = clsConverter.ToString(row["ExecDept_Chr"]).Trim();
                objDic.m_strOrderCateID = clsConverter.ToString(row["OrderCateID_Chr"]).Trim();
                objDic.m_strChargeItemID = clsConverter.ToString(row["ItemID_Chr"]).Trim();
                objDic.m_intIsRich = clsConverter.ToInt(row["IsRich_Int"]);

                objDic.m_strSpec = clsConverter.ToString(row["ItemSpec_Vchr"]).Trim();//
                objDic.m_dmlPrice = clsConverter.ToDecimal(row["ItemPrice"]);//住院单价
                if (objDT.Columns.Contains("itemtradeprice"))
                    objDic.m_dmlTradePrice = clsConverter.ToDecimal(row["itemtradeprice"]);//住院批发单价 
                objDic.m_dmlDosageRate = clsConverter.ToDecimal(row["Dosage_Dec"]);//剂量
                objDic.m_intITEMSRCTYPE_INT = clsConverter.ToInt(row["itemsrctype_int"]);//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。

                #region 药房库存修改
                int intItemsrctype = clsConverter.ToInt(row["itemsrctype_int"]);
                objDic.m_intITEMSRCTYPE_INT = intItemsrctype; //项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
                if (intItemsrctype == 1)
                {
                    //药房库存量 ，如果不为空，则取库存量，否即黙认为0
                    if (!row["ipcurrentgross_num"].ToString().Trim().Equals(""))
                    {
                        objDic.m_dmlIPCURRENTGROSS_NUM = clsConverter.ToDecimal(row["ipcurrentgross_num"]);//库存量
                    }
                }
                else
                {
                    objDic.m_dmlIPCURRENTGROSS_NUM = 0;
                }

                #endregion

                objDic.m_intIPCHARGEFLG_INT = clsConverter.ToInt(row["IPCHARGEFLG_INT"]);//住院收费单位 0 －基本单位 1－最小单位
                objDic.m_strDosageUnit = clsConverter.ToString(row["DosageUnit_Chr"]).Trim();//剂量单位
                objDic.m_strITEMUNIT_CHR = clsConverter.ToString(row["ITEMUNIT_CHR"]).Trim();//项目单位(非药品)
                objDic.m_strITEMOPUNIT_CHR = clsConverter.ToString(row["ITEMOPUNIT_CHR"]).Trim();//项目门诊单位(基本单位)
                objDic.m_strUseUnit = clsConverter.ToString(row["UseUnit_Chr"]).Trim();//项目住院单位(最小单位)
                objDic.m_strUsageID_chr = clsConverter.ToString(row["USAGEID_CHR"]).Trim();//默认用法
                //objDic.m_strUsageName = clsConverter.ToString(row["UsageName"]).Trim();//默认用法	非字段	
                /* 加上检验样本*/
                objDic.m_strSAMPLE_NAME = clsConverter.ToString(row["sample_name"]).Trim();
                objDic.m_strSAMPLEID_VCHR = clsConverter.ToString(row["SAMPLEID_VCHR"]).Trim();
                /*<==================================*/
                /* 加上检查部位*/
                objDic.m_strPARTID_VCHR = clsConverter.ToString(row["PARTID_VCHR"]).Trim();
                objDic.m_strPART_NAME = clsConverter.ToString(row["partname"]).Trim();
                objDic.m_strFREQID_CHR = clsConverter.ToString(row["FREQID_CHR"]).Trim();
                objDic.m_decADULTDOSAGE_DEC = clsConverter.ToDecimal(row["ADULTDOSAGE_DEC"].ToString().Trim());
                objDic.m_decCHILDDOSAGE_DEC = clsConverter.ToDecimal(row["CHILDDOSAGE_DEC"].ToString().Trim());
                objDic.m_intITEMSRCTYPE_INT = clsConverter.ToInt(row["itemsrctype_int"].ToString().Trim());
                /* 添加医保信息*/
                objDic.m_strMedicareTypeID = clsConverter.ToString(row["MedicareTypeID"].ToString().Trim());
                objDic.m_strMedicareTypeName = clsConverter.ToString(row["MedicareTypeName"].ToString().Trim());
                objDic.m_intMEDICNETYPE_INT = clsConverter.ToInt(row["MEDICNETYPE_INT"].ToString().Trim());//药房类型分类(中/西药) 
                objDic.m_strITEMCOMMNAME_VCHR = clsConverter.ToString(row["COMMNAME_VCHR"].ToString().Trim());

                objDic.m_strMedcineREMARK = clsConverter.ToString(row["medicineRemark"].ToString().Trim());//药典备注
                objDic.m_intIPNOQTYFLAG_INT = clsConverter.ToInt(row["IPNOQTYFLAG_INT"].ToString().Trim());//缺药标志
                //检查申请单元相关字段
                objDic.m_intCheckTypeID = clsConverter.ToInt(row["TYPEID"].ToString().Trim());//检查类型流水号(申请单类别)
                objDic.m_strCheckType = clsConverter.ToString(row["typetext"].ToString().Trim());//检查类型
                objDic.m_intDELETED = clsConverter.ToInt(row["DELETED"].ToString().Trim());//伪删除状态.1 - 已删除.0 - 未
                /*<========================================*/
                //检验申请单元
                objDic.m_strLISAPPLYUNITID_CHR = clsConverter.ToString(row["LISAPPLYUNITID_CHR"].ToString().Trim());
                /*<===============================*/
                //皮试标志 0--否 1--是
                objDic.m_intHYPE_INT = clsConverter.ToInt(row["HYPE_INT"].ToString().Trim());
                if (objDic.m_strChargeItemID.Trim().Equals(""))//当收费项目为空时，取诊疗项目的默认值
                {
                    //if (objDT.Columns.Contains("NULLITEMUSE_DEC") && objDT.Columns.Contains("NULLITEMUSEUNIT_CHR") && objDT.Columns.Contains("NULLITEMDOSETYPEID_CHR") && objDT.Columns.Contains("NULLITEMFREQID_VCHR"))
                    //{
                    objDic.m_dmlDosageRate = clsConverter.ToDecimal(row["NULLITEMUSE_DEC"]);//剂量
                    objDic.m_strDosageUnit = clsConverter.ToString(row["NULLITEMUSEUNIT_CHR"]).Trim();//剂量单位
                    objDic.m_strUsageID_chr = clsConverter.ToString(row["NULLITEMDOSETYPEID_CHR"]).Trim();//默认用法
                    objDic.m_strFREQID_CHR = clsConverter.ToString(row["NULLITEMFREQID_VCHR"]).Trim();//默认频率
                    objDic.m_strITEMUNIT_CHR = objDic.m_strDosageUnit;
                    //}
                }
                objDic.m_dmlPACKQTY_DEC = clsConverter.ToDecimal(row["PACKQTY_DEC"]);//包装量
                //常用项目名称，如果不为空，则取其名称取代原诊疗项目名称
                if (!row["CommonName"].ToString().Trim().Equals(""))
                {
                    objDic.m_strName = clsConverter.ToString(row["CommonName"]).Trim();
                    objDic.m_strITEMCOMMNAME_VCHR = clsConverter.ToString(row["CommonName"]).Trim();
                }
                /*<=================================================*/
                objDic.m_strMEDICINEPREPTYPENAME_VCHR = row["MEDICINEPREPTYPENAME_VCHR"].ToString().Trim();//药品制剂类型名称
                int.TryParse(row["MEDICINEPREPTYPE_FLAGE"].ToString().Trim(), out objDic.m_intMEDICINEPREPTYPE_FLAGE);//剂型分类 1-口服类 2-针剂类

                objDic.m_strYBTypeID = row["ybtypeid"].ToString().Trim();

                m_arrDic.Add(objDic);
            }
            if (m_arrDic.Count > 0)
            {
                arrDic = (clsBIHOrderDic[])(m_arrDic.ToArray(typeof(clsBIHOrderDic)));
            }
        }
        #endregion

        #region  进行诊疗项目VO填充,不判断库存。做模板时用。
        /// <summary>
        /// 进行诊疗项目VO填充,不判断库存。做模板时用。
        /// </summary>
        /// <param name="arrDic"></param>
        /// <param name="objDT"></param>
        /// <param name="m_blLessMedControl"></param>
        internal void m_lngConvertOrderDicByTableNOCheck(out clsBIHOrderDic[] arrDic, DataTable objDT, bool m_blLessMedControl)
        {
            arrDic = new clsBIHOrderDic[0];
            ArrayList m_arrDic = new ArrayList();
            clsBIHOrderDic objDic = null;
            Hashtable hasOrderID = new Hashtable();

            int m_intIPNOQTYFLAG_INT = 0;//中心药房缺药标志 0-有药 1－缺药
            //排序
            DataView myDataView = new DataView(objDT);

            myDataView.Sort = "medicineremark desc, IPNOQTYFLAG_INT asc";
            objDT = myDataView.ToTable();
            /*<=============================*/
            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                DataRow row = objDT.Rows[i];
                if (!row["IPNOQTYFLAG_INT"].ToString().Trim().Equals(""))
                {
                    m_intIPNOQTYFLAG_INT = clsConverter.ToInt(row["IPNOQTYFLAG_INT"].ToString().Trim());//中心药房缺药标志 0-有药 1－缺药
                }
                if (m_blLessMedControl == false)//缺药不显示开关
                {
                    if (m_intIPNOQTYFLAG_INT == 1)//缺药
                    {
                        continue;
                    }
                }

                string ID = clsConverter.ToString(row["OrderDicID_Chr"]).Trim();
                if (hasOrderID.ContainsKey(ID))
                {
                    continue;
                }
                else
                {
                    hasOrderID.Add(ID, null);
                }

                objDic = new clsBIHOrderDic();
                objDic.m_strOrderDicID = ID;
                objDic.m_strName = clsConverter.ToString(row["Name_Chr"]).Trim();
                objDic.m_strDesc = clsConverter.ToString(row["Des_VChr"]).Trim();
                objDic.m_strUserCode = clsConverter.ToString(row["UserCode_Chr"]).Trim();
                objDic.m_strWBCode = clsConverter.ToString(row["WBCode_Chr"]).Trim();
                objDic.m_strPYCode = clsConverter.ToString(row["PYCode_Chr"]).Trim();

                objDic.m_strExecDept = clsConverter.ToString(row["ExecDept_Chr"]).Trim();
                objDic.m_strOrderCateID = clsConverter.ToString(row["OrderCateID_Chr"]).Trim();
                objDic.m_strChargeItemID = clsConverter.ToString(row["ItemID_Chr"]).Trim();
                objDic.m_intIsRich = clsConverter.ToInt(row["IsRich_Int"]);

                objDic.m_strSpec = clsConverter.ToString(row["ItemSpec_Vchr"]).Trim();//
                objDic.m_dmlPrice = clsConverter.ToDecimal(row["ItemPrice"]);//住院单价
                objDic.m_dmlDosageRate = clsConverter.ToDecimal(row["Dosage_Dec"]);//剂量
                objDic.m_intITEMSRCTYPE_INT = clsConverter.ToInt(row["itemsrctype_int"]);//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。

                #region 药房库存修改
                //int intItemsrctype = clsConverter.ToInt(row["itemsrctype_int"]);
                //objDic.m_intITEMSRCTYPE_INT = intItemsrctype; //项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
                //if (intItemsrctype == 1)
                //{
                //    //药房库存量 ，如果不为空，则取库存量，否即黙认为0
                //    if (!row["ipcurrentgross_num"].ToString().Trim().Equals(""))
                //    {
                //        objDic.m_dmlIPCURRENTGROSS_NUM = clsConverter.ToDecimal(row["ipcurrentgross_num"]);//库存量
                //    }
                //}
                //else
                //{
                //    objDic.m_dmlIPCURRENTGROSS_NUM = 0;
                //}

                #endregion

                objDic.m_intIPCHARGEFLG_INT = clsConverter.ToInt(row["IPCHARGEFLG_INT"]);//住院收费单位 0 －基本单位 1－最小单位
                objDic.m_strDosageUnit = clsConverter.ToString(row["DosageUnit_Chr"]).Trim();//剂量单位
                objDic.m_strITEMUNIT_CHR = clsConverter.ToString(row["ITEMUNIT_CHR"]).Trim();//项目单位(非药品)
                objDic.m_strITEMOPUNIT_CHR = clsConverter.ToString(row["ITEMOPUNIT_CHR"]).Trim();//项目门诊单位(基本单位)
                objDic.m_strUseUnit = clsConverter.ToString(row["UseUnit_Chr"]).Trim();//项目住院单位(最小单位)
                objDic.m_strUsageID_chr = clsConverter.ToString(row["USAGEID_CHR"]).Trim();//默认用法
                //objDic.m_strUsageName = clsConverter.ToString(row["UsageName"]).Trim();//默认用法	非字段	
                /* 加上检验样本*/
                objDic.m_strSAMPLE_NAME = clsConverter.ToString(row["sample_name"]).Trim();
                objDic.m_strSAMPLEID_VCHR = clsConverter.ToString(row["SAMPLEID_VCHR"]).Trim();
                /* 加上检查部位*/
                objDic.m_strPARTID_VCHR = clsConverter.ToString(row["PARTID_VCHR"]).Trim();
                objDic.m_strPART_NAME = clsConverter.ToString(row["partname"]).Trim();
                objDic.m_strFREQID_CHR = clsConverter.ToString(row["FREQID_CHR"]).Trim();
                objDic.m_decADULTDOSAGE_DEC = clsConverter.ToDecimal(row["ADULTDOSAGE_DEC"].ToString().Trim());
                objDic.m_decCHILDDOSAGE_DEC = clsConverter.ToDecimal(row["CHILDDOSAGE_DEC"].ToString().Trim());
                objDic.m_intITEMSRCTYPE_INT = clsConverter.ToInt(row["itemsrctype_int"].ToString().Trim());
                /*  添加医保信息*/
                objDic.m_strMedicareTypeID = clsConverter.ToString(row["MedicareTypeID"].ToString().Trim());
                objDic.m_strMedicareTypeName = clsConverter.ToString(row["MedicareTypeName"].ToString().Trim());
                objDic.m_intMEDICNETYPE_INT = clsConverter.ToInt(row["MEDICNETYPE_INT"].ToString().Trim());//药房类型分类(中/西药)

                /*<================================================*/
                objDic.m_strITEMCOMMNAME_VCHR = clsConverter.ToString(row["COMMNAME_VCHR"].ToString().Trim());


                objDic.m_strMedcineREMARK = clsConverter.ToString(row["medicineRemark"].ToString().Trim());//药典备注
                objDic.m_intIPNOQTYFLAG_INT = clsConverter.ToInt(row["IPNOQTYFLAG_INT"].ToString().Trim());//缺药标志
                //检查申请单元相关字段
                objDic.m_intCheckTypeID = clsConverter.ToInt(row["TYPEID"].ToString().Trim());//检查类型流水号(申请单类别)
                objDic.m_strCheckType = clsConverter.ToString(row["typetext"].ToString().Trim());//检查类型
                objDic.m_intDELETED = clsConverter.ToInt(row["DELETED"].ToString().Trim());//伪删除状态.1 - 已删除.0 - 未
                /*<========================================*/
                //检验申请单元
                objDic.m_strLISAPPLYUNITID_CHR = clsConverter.ToString(row["LISAPPLYUNITID_CHR"].ToString().Trim());
                /*<===============================*/
                //皮试标志 0--否 1--是
                objDic.m_intHYPE_INT = clsConverter.ToInt(row["HYPE_INT"].ToString().Trim());
                if (objDic.m_strChargeItemID.Trim().Equals(""))//当收费项目为空时，取诊疗项目的默认值
                {
                    //if (objDT.Columns.Contains("NULLITEMUSE_DEC") && objDT.Columns.Contains("NULLITEMUSEUNIT_CHR") && objDT.Columns.Contains("NULLITEMDOSETYPEID_CHR") && objDT.Columns.Contains("NULLITEMFREQID_VCHR"))
                    //{
                    objDic.m_dmlDosageRate = clsConverter.ToDecimal(row["NULLITEMUSE_DEC"]);//剂量
                    objDic.m_strDosageUnit = clsConverter.ToString(row["NULLITEMUSEUNIT_CHR"]).Trim();//剂量单位
                    objDic.m_strUsageID_chr = clsConverter.ToString(row["NULLITEMDOSETYPEID_CHR"]).Trim();//默认用法
                    objDic.m_strFREQID_CHR = clsConverter.ToString(row["NULLITEMFREQID_VCHR"]).Trim();//默认频率
                    objDic.m_strITEMUNIT_CHR = objDic.m_strDosageUnit;
                    //}
                }
                objDic.m_dmlPACKQTY_DEC = clsConverter.ToDecimal(row["PACKQTY_DEC"]);//包装量
                //常用项目名称，如果不为空，则取其名称取代原诊疗项目名称
                if (!row["CommonName"].ToString().Trim().Equals(""))
                {
                    objDic.m_strName = clsConverter.ToString(row["CommonName"]).Trim();
                    objDic.m_strITEMCOMMNAME_VCHR = clsConverter.ToString(row["CommonName"]).Trim();
                }
                /*<=================================================*/
                objDic.m_strMEDICINEPREPTYPENAME_VCHR = row["MEDICINEPREPTYPENAME_VCHR"].ToString().Trim();//药品制剂类型名称
                int.TryParse(row["MEDICINEPREPTYPE_FLAGE"].ToString().Trim(), out objDic.m_intMEDICINEPREPTYPE_FLAGE);//剂型分类 1-口服类 2-针剂类

                objDic.m_strYBTypeID = row["ybtypeid"].ToString().Trim();

                m_arrDic.Add(objDic);
            }
            if (m_arrDic.Count > 0)
            {
                arrDic = (clsBIHOrderDic[])(m_arrDic.ToArray(typeof(clsBIHOrderDic)));
            }
        }
        #endregion

        /// <summary>
        /// 按编码诊疗项目
        /// </summary>
        /// <param name="m_strOrderdicid_chr">诊疗项目ID</param>
        /// <param name="arrDic">诊疗项目VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderDicByID(string m_strOrderdicid_chr, string p_strMedDeptId, out clsBIHOrderDic[] arrDic)
        {
            arrDic = null;
            string strMedDeptId = "";
            string[] strMedDeptIdArr = p_strMedDeptId.Split('*');
            int intArrCount = strMedDeptIdArr.Length;
            for (int i = 0; i < intArrCount; i++)
            {
                strMedDeptId += "'" + strMedDeptIdArr[i] + "',";
            }
            strMedDeptId = strMedDeptId.TrimEnd(',');

            string strSql = @"
              SELECT distinct
                 m.TYPEID,
                 m.typetext,
                 m.DELETED,
                 c.partname,
                 d.sample_type_desc_vchr sample_name,
                a.partid_vchr, a.sampleid_vchr, a.orderdicid_chr, a.name_chr,
                a.des_vchr, a.usercode_chr, a.wbcode_chr, a.pycode_chr,a.COMMNAME_VCHR,
                a.execdept_chr, a.ordercateid_chr, a.itemid_chr, 
                a.NULLITEMUSE_DEC,a.NULLITEMUSEUNIT_CHR,a.NULLITEMDOSETYPEID_CHR,a.NULLITEMFREQID_VCHR,
                a.LISAPPLYUNITID_CHR,a.APPLYTYPEID_CHR,
                b.isrich_int,b.itemspec_vchr,b.IPCHARGEFLG_INT,b.ITEMOPUNIT_CHR,
                DECODE (b.ipchargeflg_int,
                        1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                        0, b.itemprice_mny,
                        ROUND (b.itemprice_mny / b.packqty_dec, 4)
                       ) itemprice,
                  DECODE (b.ipchargeflg_int,
                        1, ROUND (b.tradeprice_mny / b.packqty_dec, 4),
                        0, b.tradeprice_mny,
                        ROUND (b.tradeprice_mny / b.packqty_dec, 4)
                       ) itemtradeprice,
                b.ITEMUNIT_CHR,b.dosage_dec,b.dosageunit_chr, b.itemipunit_chr useunit_chr,
                b.usageid_chr,
                b.ITEMCOMMNAME_VCHR,
                b.FREQID_CHR,
                b.itemsrctype_int,
                b.PACKQTY_DEC,
                g.CHILDDOSAGE_DEC,
                g.ADULTDOSAGE_DEC,
                g.MEDICNETYPE_INT,
                g.HYPE_INT,
                h.typeid_chr MedicareTypeID,
                h.typename_vchr MedicareTypeName,
                L.remark_vchr medicineRemark,
                s.noqtyflag_int as IPNOQTYFLAG_INT,
                '' CommonName
                ,n.MEDICINEPREPTYPENAME_VCHR
                ,n.FLAGA_INT MEDICINEPREPTYPE_FLAGE,
                b.inpinsurancetype_vchr as ybtypeid
               ,s.ipcurrentgross_num,s.medicineid_chr
            FROM 
           t_bse_bih_orderdic a,
           t_bse_chargeitem b,
           ar_apply_partlist c,
           t_aid_lis_sampletype d,
           T_BSE_MEDICINE g,
           T_AID_MEDICARETYPE h,
           t_aid_lis_apply_unit k,
           t_bse_medicinestddesc L,
           AR_APPLY_TYPELIST m,
           T_AID_MEDICINEPREPTYPE n,
           (select j.medicineid_chr,
       j.drugstoreid_chr,j.noqtyflag_int,
       sum(k.iprealgross_int) as ipcurrentgross_num,
       sum(k.iprealgross_int) as opcurrentgross_num
  from t_ds_storage j, t_ds_storage_detail k
 where j.medicineid_chr = k.medicineid_chr
   and j.drugstoreid_chr = k.drugstoreid_chr and k.canprovide_int=1
 group by j.medicineid_chr,j.drugstoreid_chr,j.noqtyflag_int) s  
          WHERE 
             a.itemid_chr = b.itemid_chr(+)
            and a.PARTID_VCHR=c.partid(+)
            and a.SAMPLEID_VCHR=d.sample_type_id_chr(+)
            and b.ITEMSRCID_VCHR=g.medicineid_chr(+)
            and b.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
            and g.medicineid_chr=s.medicineid_chr(+)
            and g.medicinestdid_chr = L.medicinestdid_chr(+)
            and a.APPLYTYPEID_CHR=m.typeid(+)
            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
            and s.drugstoreid_chr in ([meddeptid])
            and a.orderdicid_chr=?
            and ROWNUM=1
             ";//10498 s.opcurrentgross_num,s.medicineid_chr,10517and g.medicineid_chr=s.medicineid_chr(+),10521and s.drugstoreid_chr=?,

            //10510           (select j.medicineid_chr,
            //      j.drugstoreid_chr,
            //      sum(k.ipavailablegross_num) as ipcurrentgross_num,
            //      sum(k.opavailablegross_num) as opcurrentgross_num
            // from t_ds_storage j, t_ds_storage_detail k
            //where j.medicineid_chr = k.medicineid_chr
            //  and j.drugstoreid_chr = k.drugstoreid_chr
            //group by j.medicineid_chr,j.drugstoreid_chr) s,
            System.Data.IDataParameter[] arrParams = null;
            clsHRPTableService HRPService = new clsHRPTableService();
            HRPService.CreateDatabaseParameter(1, out arrParams);//2改为1

            arrParams[0].Value = m_strOrderdicid_chr;

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                strSql = strSql.Replace("[meddeptid]", strMedDeptId);
                ret = 0;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);


                if ((ret > 0) && (objDT != null))
                {
                    bool m_blLessMedControl = true;
                    m_lngConvertOrderDicByTable(out arrDic, objDT, m_blLessMedControl);


                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        /// <summary>
        /// 常用诊疗项目
        /// </summary>
        /// <param name="p_strFindString">查询字符串</param>
        /// <param name="strEmpid_chr"></param>
        /// <param name="m_intClass">查询条件</param>
        /// <param name="m_strORDERCATEID_CHR">医嘱类型</param>
        /// <param name="arrDic">诊疗项目Vo</param>
        /// <param name="m_dsDicChargeSet">诊疗项目对应的收费DATASET</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCommonOrderDicChargeByCode(string p_strMedDeptId, string p_strFindString, string strEmpid_chr, int m_intClass, string m_strORDERCATEID_CHR, bool m_blLessMedControl, out clsBIHOrderDic[] arrDic, out DataSet m_dsDicChargeSet)
        {

            arrDic = null;
            m_dsDicChargeSet = new DataSet();
            string strMedDeptId = "";
            string[] strMedDeptIdArr = p_strMedDeptId.Split('*');
            int intArrCount = strMedDeptIdArr.Length;
            for (int i = 0; i < intArrCount; i++)
            {
                strMedDeptId += "'" + strMedDeptIdArr[i] + "',";
            }
            strMedDeptId = strMedDeptId.TrimEnd(',');
            string strSql = @"
           
                SELECT distinct 
                  m.TYPEID,
                m.typetext,
                m.DELETED,
                c.partname,
                 d.sample_type_desc_vchr sample_name,
                a.partid_vchr, a.sampleid_vchr, a.orderdicid_chr, a.name_chr,
                a.des_vchr, a.usercode_chr, a.wbcode_chr, a.pycode_chr,a.COMMNAME_VCHR,
                a.execdept_chr, a.ordercateid_chr, a.itemid_chr, 
                a.NULLITEMUSE_DEC,a.NULLITEMUSEUNIT_CHR,a.NULLITEMDOSETYPEID_CHR,a.NULLITEMFREQID_VCHR,
                a.LISAPPLYUNITID_CHR,a.APPLYTYPEID_CHR,
                b.isrich_int,b.itemspec_vchr,b.IPCHARGEFLG_INT,b.ITEMOPUNIT_CHR,
                DECODE (b.ipchargeflg_int,
                        1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                        0, b.itemprice_mny,
                        ROUND (b.itemprice_mny / b.packqty_dec, 4)
                       ) itemprice,
                DECODE (b.ipchargeflg_int,
                        1, ROUND (b.tradeprice_mny / b.packqty_dec, 4),
                        0, b.tradeprice_mny,
                        ROUND (b.tradeprice_mny / b.packqty_dec, 4)
                       ) itemtradeprice,
                b.ITEMUNIT_CHR,b.dosage_dec,b.dosageunit_chr, b.itemipunit_chr useunit_chr,
                b.usageid_chr,
                b.ITEMCOMMNAME_VCHR,
                b.FREQID_CHR,
                b.itemsrctype_int,
                b.PACKQTY_DEC,
                g.CHILDDOSAGE_DEC,
                g.ADULTDOSAGE_DEC,
                g.MEDICNETYPE_INT,
                g.HYPE_INT,
                h.typeid_chr MedicareTypeID,
                h.typename_vchr MedicareTypeName,
                L.remark_vchr medicineRemark,
                s.noqtyflag_int as IPNOQTYFLAG_INT,
                c1.DES_VCHR CommonName,
                n.MEDICINEPREPTYPENAME_VCHR,
                n.FLAGA_INT MEDICINEPREPTYPE_FLAGE,
                b.inpinsurancetype_vchr as ybtypeid,
                s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num
            FROM 
           t_bse_bih_orderdic a,
           t_bse_chargeitem b,
           ar_apply_partlist c,
           t_aid_lis_sampletype d,
           T_BSE_MEDICINE g,
           T_AID_MEDICARETYPE h,
           t_aid_lis_apply_unit k,
           t_bse_medicinestddesc l,
           t_aid_bih_comuseorderdic c1,
           AR_APPLY_TYPELIST m,
           T_AID_MEDICINEPREPTYPE n,
           (select t.noqtyflag_int,t.opcurrentgross_num, t.medicineid_chr, t.ipcurrentgross_num
          from t_ds_storage t
         where t.drugstoreid_chr in ([meddeptid])) s 

          WHERE 
             a.itemid_chr = b.itemid_chr(+)
            and a.PARTID_VCHR=c.partid(+)
            and a.SAMPLEID_VCHR=d.sample_type_id_chr(+)
            and b.ITEMSRCID_VCHR=g.medicineid_chr(+)
            and b.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
            and g.medicineid_chr=s.medicineid_chr(+)
            and g.medicinestdid_chr = L.medicinestdid_chr(+)
            AND a.orderdicid_chr = c1.orderdicid_chr(+)
            and a.APPLYTYPEID_CHR=m.typeid(+)
            and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
            --and s.drugstoreid_chr in ([meddeptid]) 
            and (LOWER(a.UserCode_Chr) like ? or [FindItem] like ? or [FindItem] is null) 
            and  ( IPNOQTYFLAG_INT IN ([IPNOQTYFLAG_INT]) or IPNOQTYFLAG_INT is null) 
            [ordercateid]
            AND a.status_int = 1
            AND c1.createrid_chr = ?
            
            order by [m_strClass]
             ";//10621s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,10634t_ds_storage s,10642  and g.medicineid_chr=s.medicineid_chr(+),


            //string strFind = " (( LOWER(UserCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(WBCode_Chr)	 like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(PYCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(Name_Chr) like '%" + p_strFindString.ToLower().Trim() + "%')) ";
            string strFind = "";
            string m_strClass = "a.UserCode_Chr";
            switch (m_intClass)
            {
                case -1:
                    strFind = "LOWER(a.PYCode_Chr)";
                    m_strClass = "a.PYCode_Chr";
                    break;
                case 0:
                    strFind = "LOWER(a.PYCode_Chr)";
                    m_strClass = "a.PYCode_Chr";
                    break;
                case 1:
                    strFind = "LOWER(a.WBCode_Chr)";
                    m_strClass = "a.WBCode_Chr";
                    break;
                case 2:
                    strFind = "LOWER(a.Name_Chr)";
                    m_strClass = "a.Name_Chr";
                    break;
                case 3:
                    strFind = "LOWER(a.UserCode_Chr)";
                    m_strClass = "a.UserCode_Chr";
                    break;
            }
            string m_strORDERCATEID = "";
            if (!m_strORDERCATEID_CHR.Trim().Equals(""))
            {
                m_strORDERCATEID = " and a.ordercateid_chr=? ";
            }
            strSql = strSql.Replace("[FindItem]", strFind);
            strSql = strSql.Replace("[ordercateid]", m_strORDERCATEID.Trim());
            strSql = strSql.Replace("[m_strClass]", m_strClass.Trim());
            strSql = strSql.Replace("[meddeptid]", strMedDeptId);
            if (m_blLessMedControl)//缺药查询
            {
                //strSql = strSql.Replace("[IPNOQTYFLAG_INT]", "0,1");
                strSql = strSql.Replace("[IPNOQTYFLAG_INT]", "?,?");
            }
            else
            {
                // strSql = strSql.Replace("[IPNOQTYFLAG_INT]", "0");
                strSql = strSql.Replace("[IPNOQTYFLAG_INT]", "?");
            }

            string strFind2 = p_strFindString.ToLower().Trim() + "%";
            if (m_intClass == 2)
            {
                strFind2 = "%" + p_strFindString.ToLower().Trim() + "%";
            }
            System.Data.IDataParameter[] arrParams = null;
            clsHRPTableService HRPService = new clsHRPTableService();
            if (m_strORDERCATEID_CHR.Trim().Equals(""))
            {
                if (m_blLessMedControl)
                {
                    HRPService.CreateDatabaseParameter(5, out arrParams);

                    arrParams[0].Value = strFind2;
                    arrParams[1].Value = strFind2;
                    arrParams[2].Value = 0;
                    arrParams[3].Value = 1;
                    arrParams[4].Value = strEmpid_chr;
                }
                else
                {
                    HRPService.CreateDatabaseParameter(4, out arrParams);

                    arrParams[0].Value = strFind2;
                    arrParams[1].Value = strFind2;
                    arrParams[2].Value = 0;
                    arrParams[3].Value = strEmpid_chr;
                }

            }
            else
            {

                if (m_blLessMedControl)
                {
                    HRPService.CreateDatabaseParameter(6, out arrParams);

                    arrParams[0].Value = strFind2;
                    arrParams[1].Value = strFind2;
                    arrParams[2].Value = 0;
                    arrParams[3].Value = 1;
                    arrParams[4].Value = m_strORDERCATEID_CHR;
                    arrParams[5].Value = strEmpid_chr;
                }
                else
                {
                    HRPService.CreateDatabaseParameter(5, out arrParams);

                    arrParams[0].Value = strFind2;
                    arrParams[1].Value = strFind2;
                    arrParams[2].Value = 0;
                    arrParams[3].Value = m_strORDERCATEID_CHR;
                    arrParams[4].Value = strEmpid_chr;
                }

            }
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                /*
                strSql = @"
                	SELECT  A.orderdicid_chr, trim(C.ITEMNAME_VCHR) as ItemName,decode(A.itemid_chr,B.itemid_chr,1,0 )IsChiefItem	
							,a.QTY_INT
							,ITEMIPUNIT_CHR
							,c.DOSAGE_DEC
							,c.DOSAGEUNIT_CHR
							,c.ITEMSPEC_VCHR
                            ,c.ITEMSRCTYPE_INT
							,decode(c.IPCHARGEFLG_INT,1,Round(c.ItemPrice_Mny/c.PackQty_Dec,4),0,c.ItemPrice_Mny,Round(c.ItemPrice_Mny/c.PackQty_Dec,4)) MinPrice
                            ,g.IPNOQTYFLAG_INT
                            ,h.typename_vchr MedicareTypeName
                            FROM
							T_AID_BIH_ORDERDIC_CHARGE A , 
                            (
                          select	
            a.* ,B.IsRich_Int
            from T_BSE_BIH_ORDERDIC A,T_BSE_CHARGEITEM B,t_aid_bih_comuseorderdic C
            where A.ItemID_Chr=B.ItemID_Chr(+) and a.status_int=1 
            and A.orderdicid_chr=C.orderdicid_chr and C.CREATERID_CHR=?
            and (LOWER(UserCode_Chr) like ? or [FindItem] like ? or [FindItem] is null)   order by a.UserCode_Chr,a.orderdicid_chr) B ,
                            T_BSE_CHARGEITEM C 
                            ,T_BSE_MEDICINE g
                            ,T_AID_MEDICARETYPE h
                            WHERE A.orderdicid_chr =B.orderdicid_chr AND A.itemid_chr =C.itemid_chr 
                            and c.ITEMSRCID_VCHR=g.medicineid_chr(+)
                            and c.INPINSURANCETYPE_VCHR=h.typeid_chr(+)
                            
                           ORDER BY B.USERCODE_CHR,B.orderdicid_chr,IsChiefItem DESC 
                       ";
                 */
                strSql = @"
                        SELECT   a.orderdicid_chr, TRIM (c.itemname_vchr) AS itemname,
                        DECODE (a.itemid_chr, m.itemid_chr, 1, 0) ischiefitem, a.qty_int,
                        c.itemipunit_chr, c.itemid_chr, c.ITEMCODE_VCHR, c.dosage_dec, c.dosageunit_chr, c.itemspec_vchr
                        ,c.itemsrctype_int
                        ,c.ITEMUNIT_CHR
					    ,c.ITEMIPUNIT_CHR
                        ,c.ITEMOPUNIT_CHR
                        ,c.IFSTOP_INT,
                        DECODE (c.ipchargeflg_int,
                        1, ROUND (c.itemprice_mny / c.packqty_dec, 4),
                        0, c.itemprice_mny,
                        ROUND (c.itemprice_mny / c.packqty_dec, 4)
                        ) minprice
                        ,DECODE (c.ipchargeflg_int,
                        1, ROUND (c.tradeprice_mny / c.packqty_dec, 4),
                        0, c.tradeprice_mny,
                        ROUND (c.tradeprice_mny / c.packqty_dec, 4)
                        ) itemtradeprice
                        ,s.noqtyflag_int as IPNOQTYFLAG_INT
                        ,g.IPCHARGEFLG_INT
                        ,h.typename_vchr medicaretypename
                        ,n.MEDICINEPREPTYPENAME_VCHR
                        ,n.FLAGA_INT MEDICINEPREPTYPE_FLAGE
                        ,s.ipcurrentgross_num,s.opcurrentgross_num,s.medicineid_chr,s.drugstoreid_chr, g.Expenselimit_Mny
                        FROM t_aid_bih_orderdic_charge a,
                        t_bse_chargeitem c,
                        t_bse_medicine g,
                        t_aid_medicaretype h,
                        t_aid_bih_comuseorderdic k,
                        t_bse_bih_orderdic m,
                        T_AID_MEDICINEPREPTYPE n,
                        (select j.medicineid_chr,
       j.drugstoreid_chr,j.noqtyflag_int,
       sum(j.ipcurrentgross_num) as ipcurrentgross_num,
       sum(j.opcurrentgross_num) as opcurrentgross_num
  from t_ds_storage j, t_ds_storage_detail k
 where j.medicineid_chr = k.medicineid_chr
   and j.drugstoreid_chr = k.drugstoreid_chr and k.canprovide_int=1 
   and j.drugstoreid_chr in ([meddeptid])
 group by j.medicineid_chr,j.drugstoreid_chr,j.noqtyflag_int) s
                         
  
                        WHERE a.orderdicid_chr = k.orderdicid_chr
                        AND k.orderdicid_chr = m.orderdicid_chr
                        AND a.itemid_chr = c.itemid_chr
                        AND c.itemsrcid_vchr = g.medicineid_chr(+)
                        and g.medicineid_chr=s.medicineid_chr(+)
                        AND c.inpinsurancetype_vchr = h.typeid_chr(+)
                        
                        and g.MEDICINEPREPTYPE_CHR=n.MEDICINEPREPTYPE_CHR(+)
                        AND m.status_int = 1
                        AND k.createrid_chr = ?
                        AND (LOWER(m.UserCode_Chr) like ? or [FindItem] like ? or [FindItem] is null)
                        ORDER BY m.usercode_chr, m.orderdicid_chr, ischiefitem DESC
                ";//10813s.opcurrentgross_num,s.medicineid_chr,s.ipcurrentgross_num,10821t_ds_storage s,10828and g.medicineid_chr=s.medicineid_chr(+),

                System.Data.IDataParameter[] arrParams2 = null;
                strSql = strSql.Replace("[FindItem]", strFind.Replace("a.", "m."));
                strSql = strSql.Replace("[meddeptid]", strMedDeptId);
                HRPService.CreateDatabaseParameter(3, out arrParams2);
                arrParams2[0].Value = strEmpid_chr;
                arrParams2[1].Value = strFind2.Replace("a.", "m.");
                arrParams2[2].Value = strFind2.Replace("a.", "m.");
                DataTable objDT2 = new DataTable("chargeList");
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT2, arrParams2);
                HRPService.Dispose();
                if (ret > 0)
                {
                    m_dsDicChargeSet.Tables.Add(objDT2);
                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                m_lngConvertOrderDicByTable(out arrDic, objDT, m_blLessMedControl);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #region 获取医生列表
        /// <summary>
        /// 通过模糊查询方式选择全院的医生,排列顺序默认先为本科室的医生
        /// </summary>
        /// <param name="p_strFindString"></param>
        /// <param name="m_strDeptid_chr"></param>
        /// <param name="p_dtbDoctors"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDoctorsList(string p_strFindString, string m_strDeptid_chr, out clsBIHDoctor[] m_objDoctorArr)
        {
            string strSQL = "";
            m_objDoctorArr = new clsBIHDoctor[0];
            strSQL = @"
            SELECT   *
    FROM (SELECT a.empid_chr,a.lastname_vchr,a.pycode_chr,a.EMPNO_CHR, 0 AS orderstr
            FROM t_bse_employee a, t_bse_deptemp b
           WHERE a.empid_chr = b.empid_chr(+)
             AND b.end_dat IS NULL
             AND (   lower(a.pycode_chr) LIKE ?
                  OR lower(a.lastname_vchr) LIKE ?
                  OR lower(a.empno_chr) LIKE ?
                 )
             AND a.status_int = 1
             AND a.hasprescriptionright_chr = 1
             and b.deptid_chr=?
          UNION
          SELECT a.empid_chr,a.lastname_vchr,a.pycode_chr,a.EMPNO_CHR, 1 AS orderstr
            FROM t_bse_employee a
           WHERE a.status_int = 1
             AND a.hasprescriptionright_chr = 1
             AND (   lower(a.pycode_chr) LIKE ?
                  OR lower(a.lastname_vchr) LIKE ?
                  OR lower(a.empno_chr) LIKE ?
                 ))
ORDER BY orderstr
            ";

            DataTable p_dtbDoctors = new DataTable();
            long lngRes = 0;
            try
            {
                lngRes = 0;
                string strFind2 = "";
                strFind2 = "%" + p_strFindString.ToLower().Trim() + "%";
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPService = new clsHRPTableService();
                HRPService.CreateDatabaseParameter(7, out arrParams);
                arrParams[0].Value = strFind2;
                arrParams[1].Value = strFind2;
                arrParams[2].Value = strFind2;
                arrParams[3].Value = m_strDeptid_chr;
                arrParams[4].Value = strFind2;
                arrParams[5].Value = strFind2;
                arrParams[6].Value = strFind2;

                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                lngRes = HRPService.lngGetDataTableWithParameters(strSQL, ref p_dtbDoctors, arrParams);
                if (lngRes > 0 && p_dtbDoctors.Rows.Count > 0)
                {
                    m_objDoctorArr = new clsBIHDoctor[p_dtbDoctors.Rows.Count];
                    for (int i = 0; i < p_dtbDoctors.Rows.Count; i++)
                    {
                        m_objDoctorArr[i] = new clsBIHDoctor();
                        m_objDoctorArr[i].m_strDoctorID = p_dtbDoctors.Rows[i]["empid_chr"].ToString().Trim();
                        m_objDoctorArr[i].m_strDoctorName = p_dtbDoctors.Rows[i]["lastname_vchr"].ToString().Trim();
                        m_objDoctorArr[i].m_strDoctorNo = p_dtbDoctors.Rows[i]["EMPNO_CHR"].ToString().Trim(); ;

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

        #region 功能开关用来控制是否允许修改医嘱诊疗项目名称 1017
        /// <summary>
        /// 功能开关用来控制是否允许修改医嘱诊疗项目名称 1017
        /// </summary>
        /// <param name="m_blnOpen"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihOrderNameControl(out bool m_blnOpen)
        {
            m_blnOpen = false;
            long lngRes = -1;
            string strSQL = "select a.setstatus_int from t_sys_setting a where a.setid_chr='1017'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0 && dtbResult.Rows[0][0] != System.DBNull.Value)
                {
                    m_blnOpen = (Int32.Parse(dtbResult.Rows[0][0].ToString()) == 1) ? true : false;
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

        #region 功能开关用来控制是否允许修改医嘱作废 1023
        /// <summary>
        /// 功能开关用来控制是否允许修改医嘱作废 1017
        /// </summary>
        /// <param name="m_blnOpen"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetm_cmdBlankOutControl(out bool m_blnOpen)
        {
            m_blnOpen = false;
            long lngRes = -1;
            string strSQL = "select a.setstatus_int from t_sys_setting a where a.setid_chr='1023'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0 && dtbResult.Rows[0][0] != System.DBNull.Value)
                {
                    m_blnOpen = (Int32.Parse(dtbResult.Rows[0][0].ToString()) == 1) ? true : false;
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

        /// <summary>
        /// 获取医嘱	根据病人和医嘱状态 --医嘱输入主界面列表用
        /// </summary>
        /// <param name="strRegisterID">入院登记流水号</param>
        /// <param name="blnOnlyToday">是否仅当天的医嘱</param>
        /// <param name="intFilterType">医嘱过滤</param>
        /// <param name="intCount">可提交的医嘱记录数目</param>
        /// <param name="MaxRecipeno">可录入的最大方号</param>
        /// <param name="arrOrder">医嘱Vo对象[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByPatientAndState(string strRegisterID, bool blnOnlyToday, int intFilterType, out int intCount, out int MaxRecipeno, out clsBIHOrder[] arrOrder)
        {
            long lngRes = -1;
            arrOrder = null;
            intCount = 0;
            MaxRecipeno = 1;
            /*
            string strSql = @"	
					  select k.*,a.INSURACEDESC_VCHR MedicareTypeName 
                      ,c.SIGN_GRP
                      from
                     (	
                       select d.partname,c.SAMPLE_TYPE_DESC_VCHR,A.*,B.ItemPrice,B.DosageRate,B.OrderCateID_Chr,B.viewname_vchr
								,(select REPLACE(trim(RECIPENO_INT || ' ' || NAME_VCHR),' ',' - ') from T_Opr_Bih_Order where T_Opr_Bih_Order.ORDERID_CHR = A.PARENTID_CHR) ParentName
						from T_Opr_Bih_Order A,t_aid_lis_sampletype c, ar_apply_partlist d ,
						(
							select TA.OrderDicID_Chr,TB.Dosage_Dec DosageRate,TA.OrderCateID_Chr,TA.VIEWNAME_VCHR
									,decode(TB.IPCHARGEFLG_INT,1,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4),0,TB.ItemPrice_Mny,Round(TB.ItemPrice_Mny/TB.PackQty_Dec,4)) ItemPrice 
							from (SELECT a.*, b.viewname_vchr
								  FROM t_bse_bih_orderdic a, t_aid_bih_ordercate b
								  WHERE a.ordercateid_chr = b.ordercateid_chr
								 ) TA,T_BSE_ChargeItem TB
							where TA.ItemID_chr=TB.itemid_chr(+)
						) B
						where a.SAMPLEID_VCHR=c.SAMPLE_TYPE_ID_CHR(+)
                        and a.partid_vchr=d.partid(+)
                        and A.OrderDicID_Chr=B.OrderDicID_Chr(+)
						and Trim(RegisterID_Chr)='[RegIDValue]' 
						[OnlyTodayCondition]
						[ExecuteFilter]
						
                    ) k,
T_OPR_BIH_ORDERCHARGEDEPT a,
t_bse_bih_orderdic b
,t_bse_empsign c
where k.orderid_chr=a.ORDERID_CHR(+)
and k.ORDERDICID_CHR=b.ORDERDICID_CHR(+)
and k.DOCTORID_CHR=c.EMPID_CHR(+)
and a.CHARGEITEMID_CHR=b.ITEMID_CHR
order by k.recipeno_int,k.PARENTID_CHR desc,k.ORDERID_CHR
			";
             */
            /*<====================================================================*/
            string strSql = @"
            select
            a1.name_vchr parentname,
            c.sample_type_desc_vchr,
            d.partname,
            e.ordercateid_chr,
            f.viewname_vchr,
            g.sign_grp,
            h.UNITPRICE_DEC  itemprice,
            h.INSURACEDESC_VCHR  MedicareTypeName,
            h.CHARGEITEMID_CHR ,
            h.CHARGEITEMNAME_CHR ,
            j.Dosage_Dec DosageRate,
            a.*
            from 
            t_opr_bih_order a,
            t_opr_bih_order a1,
            t_aid_lis_sampletype c,
            ar_apply_partlist d,
            t_bse_bih_orderdic e,
            t_aid_bih_ordercate f,
            t_bse_empsign g,
            (select * from t_opr_bih_orderchargedept h
             where h.flag_int=0
             ) h,
            T_BSE_ChargeItem j 
            where
            a.sampleid_vchr=c.sample_type_id_chr(+)
            and
            a.partid_vchr=d.partid(+)
            and
            a.orderdicid_chr=e.orderdicid_chr(+)
            and
            e.ordercateid_chr=f.ordercateid_chr(+)
            and
            a.parentid_chr=a1.orderid_chr(+)
            and
            a.doctorid_chr=g.empid_chr(+)
            and
            a.orderid_chr=h.orderid_chr(+)
            and
            e.ITEMID_CHR=j.ITEMID_CHR(+)
            and
            a.registerid_chr='[RegIDValue]'
            [OnlyTodayCondition]
            [ExecuteFilter]
            order by 
            a.recipeno_int,
            a.PARENTID_CHR desc
             ";
            #region 条件

            //医嘱类型 { "0-全部医嘱 (Ctrl+`)", "1-长期医嘱 (Ctrl+1)", "2-临时医嘱 (Ctrl+2)", "3-带药医嘱 (Ctrl+3)", "4-未停医嘱 (Ctrl+4)", "5-已停医嘱 (Ctrl+5)", "6-新开医嘱 (Ctrl+6)", "7-提交医嘱 (Ctrl+7)", "8-转抄医嘱 (Ctrl+8)", "9-执行医嘱 (Ctrl+9)", "10-作废医嘱 (Ctrl+10)" };
            string m_strExecuteFilter = "";
            switch (intFilterType)
            {
                case 0://"0-全部医嘱 (Ctrl+`)"
                    m_strExecuteFilter = "";
                    break;
                case 1:// "1-长期医嘱 (Ctrl+1)"
                    m_strExecuteFilter = " and  a.EXECUTETYPE_INT=1 ";
                    break;
                case 2://"2-临时医嘱 (Ctrl+2)"
                    m_strExecuteFilter = " and  a.EXECUTETYPE_INT=2 ";
                    break;
                case 3://"3-带药医嘱 (Ctrl+3)"
                    m_strExecuteFilter = " and  a.EXECUTETYPE_INT=3 ";
                    break;
                case 4://"4-未停医嘱 (Ctrl+4)"
                    //m_strExecuteFilter = " and  a.EXECUTETYPE_INT=1 and STATUS_INT!=3 ";
                    m_strExecuteFilter = " and (a.STATUS_INT=0 OR (a.EXECUTETYPE_INT=1 and a.STATUS_INT!=3 and a.STATUS_INT!=-1  and (a.STOPDATE_DAT>sysdate or a.STOPDATE_DAT is null) )) ";
                    // m_strExecuteFilter = " and  a.STATUS_INT!=3 ";
                    break;
                case 5://"5-已停医嘱 (Ctrl+5)"
                    m_strExecuteFilter = " and  a.EXECUTETYPE_INT=1 and (a.STATUS_INT=3 or a.STOPDATE_DAT<sysdate)";
                    break;
                case 6://"6-新开医嘱 (Ctrl+6)"
                    m_strExecuteFilter = " and (a.STATUS_INT=0 or a.STATUS_INT=7) ";
                    break;
                case 7://"7-提交医嘱 (Ctrl+7)"
                    m_strExecuteFilter = " and a.STATUS_INT=1 ";
                    break;
                case 8://"8-转抄医嘱 (Ctrl+8)"
                    m_strExecuteFilter = " and a.STATUS_INT=5 ";
                    break;
                case 9://"9-执行医嘱 (Ctrl+9)"
                    m_strExecuteFilter = " and a.STATUS_INT=2 ";
                    break;
                case 10://"10-作废医嘱 (Ctrl+10)" 
                    m_strExecuteFilter = " and a.STATUS_INT=-1 ";
                    break;

            }
            /*
            //医嘱类型 { "0-全部医嘱 (Ctrl+`)", "1-长期医嘱 (Ctrl+1)", "2-临时医嘱 (Ctrl+2)", "3-带药医嘱 (Ctrl+3)", "4-未停医嘱 (Ctrl+4)", "5-已停医嘱 (Ctrl+5)", "6-新开医嘱 (Ctrl+6)", "7-提交医嘱 (Ctrl+7)", "8-转抄医嘱 (Ctrl+8)", "9-执行医嘱 (Ctrl+9)", "10-作废医嘱 (Ctrl+10)" };
          
            */
            strSql = strSql.Replace("[ExecuteFilter]", m_strExecuteFilter);		//所有
            strSql = strSql.Replace("[RegIDValue]", strRegisterID);
            //是否当天
            if (blnOnlyToday)
            {
                string strNow = DateTime.Now.ToString("yyyy-MM-dd");
                string strStart = strNow + " 0:0:0";
                string strEnd = strNow + " 23:59:59";
                strSql = strSql.Replace("[OnlyTodayCondition]", "  and ( a.CreateDate_Dat between to_date('" + strStart + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEnd + "','yyyy-mm-dd hh24:mi:ss')  ) ");
            }
            else
            {
                strSql = strSql.Replace("[OnlyTodayCondition]", "");
            }
            #endregion

            try
            {
                clsHRPTableService HRPService = new clsHRPTableService();
                DataTable objDT = new DataTable();
                lngRes = 0;
                lngRes = HRPService.DoGetDataTable(strSql, ref objDT);

                if ((lngRes > 0) && (objDT != null) && objDT.Rows.Count > 0)
                {
                    lngRes = 0;
                    //lngRes = m_lngGetOrderArrFromDataTable(objDT, out arrOrder);
                    lngRes = m_lngGetOrderArrFromDataTableNew(objDT, out arrOrder);
                }
                // 可提交的医嘱数目及可录入的最大方号
                strSql = @"
                    select a.intCount, b.MaxRecipeno
                    from
                    (
                    select count(a.orderid_chr) intCount
                    from T_Opr_Bih_Order a
                    where
                    (a.status_int=0 or a.status_int=7)
                    and
                     a.registerid_chr=?) a,
                    (
                    select max(a.recipeno_int) MaxRecipeno
                    from T_Opr_Bih_Order a
                    where
                     a.registerid_chr=?) b
                     ";
                //strSql = strSql.Replace("[RegIDValue]", strRegisterID);
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = strRegisterID.Trim();
                arrParams[1].Value = strRegisterID.Trim();
                lngRes = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if (lngRes > 0 && (objDT != null) && objDT.Rows.Count > 0)
                {
                    if (!objDT.Rows[0]["intCount"].ToString().Trim().Equals(""))
                    {
                        intCount = int.Parse(objDT.Rows[0]["intCount"].ToString().Trim());
                    }
                    if (objDT.Rows[0]["MaxRecipeno"].ToString().Trim().Equals(""))
                    {
                        MaxRecipeno = 1;
                    }
                    else
                    {
                        MaxRecipeno = int.Parse(objDT.Rows[0]["MaxRecipeno"].ToString().Trim()) + 1;
                    }
                }
                /*<========================*/
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
        /// 获取医嘱	根据病人和医嘱状态 --医嘱输入主界面列表用
        /// </summary>
        /// <param name="strRegisterID">入院登记流水号</param>
        /// <param name="blnOnlyToday">是否仅当天的医嘱</param>
        /// <param name="intFilterType">医嘱过滤</param>
        /// <param name="intCount">可提交的医嘱记录数目</param>
        /// <param name="MaxRecipeno">可录入的最大方号</param>
        /// <param name="intBackCount">退回的医嘱数目</param>
        /// <param name="m_intOutHisCout">出院医嘱数目</param>
        /// <param name="arrOrder">医嘱Vo对象[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByPatientAndState2(string strRegisterID, string m_strEmpID, bool blnOnlyToday, int intFilterType, out int intCount, out int MaxRecipeno, out int intBackCount, out int m_intOutHisCout, out clsBIHOrder[] arrOrder)
        {
            long lngRes = -1;
            arrOrder = null;
            intCount = 0;
            MaxRecipeno = 1;
            intBackCount = 0;
            m_intOutHisCout = 0;
            #region 条件

            //医嘱类型 { "0-全部医嘱 (Ctrl+`)", "1-长期医嘱 (Ctrl+1)", "2-临时医嘱 (Ctrl+2)", "3-带药医嘱 (Ctrl+3)", "4-未停医嘱 (Ctrl+4)", "5-已停医嘱 (Ctrl+5)", "6-新开医嘱 (Ctrl+6)", "7-提交医嘱 (Ctrl+7)", "8-转抄医嘱 (Ctrl+8)", "9-执行医嘱 (Ctrl+9)", "10-作废医嘱 (Ctrl+10)" };
            string m_strExecuteFilter = "";
            switch (intFilterType)
            {
                case 0://"0-全部医嘱 (Ctrl+`)"
                    m_strExecuteFilter = "";
                    break;
                case 1:// "1-长期医嘱 (Ctrl+1)"
                    m_strExecuteFilter = " EXECUTETYPE_INT=1 ";
                    break;
                case 2://"2-临时医嘱 (Ctrl+2)"
                    m_strExecuteFilter = " EXECUTETYPE_INT=2 ";
                    break;
                case 3://"3-带药医嘱 (Ctrl+3)"
                    m_strExecuteFilter = " EXECUTETYPE_INT=3 ";
                    break;
                case 4://"4-未停医嘱 (Ctrl+4)"
                    m_strExecuteFilter = " (STATUS_INT=0 OR (EXECUTETYPE_INT=1 and STATUS_INT<>3 and STATUS_INT<>-1  and (STOPDATE_DAT>sysdate or STOPDATE_DAT is null) )) ";
                    break;
                case 5://"5-已停医嘱 (Ctrl+5)"
                    m_strExecuteFilter = " EXECUTETYPE_INT=1 and (STATUS_INT=3 or STOPDATE_DAT<sysdate)";
                    break;
                case 6://"6-新开医嘱 (Ctrl+6)"
                    m_strExecuteFilter = " (STATUS_INT=0 or STATUS_INT=7) ";
                    break;
                case 7://"7-提交医嘱 (Ctrl+7)"
                    m_strExecuteFilter = " STATUS_INT=1 ";
                    break;
                case 8://"8-转抄医嘱 (Ctrl+8)"
                    m_strExecuteFilter = " STATUS_INT=5 ";
                    break;
                case 9://"9-执行医嘱 (Ctrl+9)"
                    m_strExecuteFilter = " STATUS_INT=2 ";
                    break;
                case 10://"10-作废医嘱 (Ctrl+10)" 
                    m_strExecuteFilter = " STATUS_INT=-1 ";
                    break;
                case 11://"11-退回医嘱
                    m_strExecuteFilter = " STATUS_INT=7 ";
                    break;

            }
            //是否当天
            if (blnOnlyToday)
            {
                if (!m_strExecuteFilter.Trim().Equals(""))
                {
                    m_strExecuteFilter += " and ";
                }
                else
                {
                    m_strExecuteFilter += "";
                }
                m_strExecuteFilter += " today=creatday ";
            }

            #endregion



            //            string strSql = @"
            //            select
            //            sysdate,
            //            trunc(sysdate) today,
            //            trunc(a.createdate_dat) creatday, 
            //            c.sample_type_desc_vchr,
            //            d.partname,
            //            e.ordercateid_chr,
            //            e.ITEMID_CHR CHARGEITEMID_CHR,
            //            e.LISAPPLYUNITID_CHR,
            //            e.APPLYTYPEID_CHR,
            //            g.sign_grp,
            //            a.*
            //            from 
            //            t_opr_bih_order a,
            //            t_aid_lis_sampletype c,
            //            ar_apply_partlist d,
            //            t_bse_bih_orderdic e,
            //            t_bse_empsign g
            //            where
            //            a.sampleid_vchr=c.sample_type_id_chr(+)
            //            and
            //            a.partid_vchr=d.partid(+)
            //            and
            //            a.orderdicid_chr=e.orderdicid_chr(+)
            //            and
            //            a.doctorid_chr=g.empid_chr(+)
            //            and
            //            a.STATUS_INT<>-2
            //            and
            //            a.registerid_chr=?
            //             ";
            string strSql = @"select
                sysdate,
                trunc(sysdate) today,
                trunc(a.createdate_dat) creatday, 
                c.sample_type_desc_vchr,
                d.partname,
                e.ordercateid_chr,
                e.ITEMID_CHR CHARGEITEMID_CHR,
                e.LISAPPLYUNITID_CHR,
                e.APPLYTYPEID_CHR,
                e.NAME_CHR DicName,
                f.ipchargeflg_int,
                f.packqty_dec,
                g.mednormalname_vchr,
                a.*,
                (select t.sign_grp from t_bse_empsign t where t.empid_chr = a.creatorid_chr) as creatorsign,
                (select t.sign_grp from t_bse_empsign t where t.empid_chr = a.confirmerid_chr) as confirmersign,
                (select t.sign_grp from t_bse_empsign t where t.empid_chr = a.stoperid_chr) as stopersign,
                (select t.sign_grp from t_bse_empsign t where t.empid_chr = a.assessoridforstop_chr) as assessorsign
                from 
                t_opr_bih_order a,
                t_aid_lis_sampletype c,
                ar_apply_partlist d,
                t_bse_bih_orderdic e,
                t_bse_chargeitem f,
                t_bse_medicine g
                where
                a.sampleid_vchr=c.sample_type_id_chr(+)
                and
                a.partid_vchr=d.partid(+)
                and
                a.orderdicid_chr=e.orderdicid_chr(+)
                and
                e.itemid_chr = f.itemid_chr(+)
                and
                f.ITEMSRCID_VCHR=g.medicineid_chr(+)
                and
                a.STATUS_INT<>-2
                and
                a.registerid_chr=?
                 ";
            try
            {
                clsHRPTableService HRPService = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = strRegisterID.Trim();
                DataTable objDT = new DataTable();
                lngRes = 0;
                lngRes = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if (objDT.Rows.Count > 0)
                {
                    DataView myDataView = new DataView(objDT);
                    //统计可提交医嘱数目
                    /*<===========================*/
                    myDataView.RowFilter = "(status_int=0) and CREATORID_CHR='" + m_strEmpID.Trim() + "'";
                    intCount = myDataView.Count;
                    /*<=========================*/
                    //统计可退回的医嘱数目
                    /*<===========================*/
                    myDataView.RowFilter = "status_int=7";
                    intBackCount = myDataView.Count;
                    /*<=========================*/
                    /*<===========================*/
                    myDataView.RowFilter = "TYPE_INT=3 or TYPE_INT=4";
                    m_intOutHisCout = myDataView.Count;
                    /*<=========================*/
                    //获取最大的方号
                    MaxRecipeno = 0;
                    int Recipeno = 0;
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {

                        Recipeno = clsConverter.ToInt(objDT.Rows[i]["recipeno_int"].ToString());
                        if (MaxRecipeno > Recipeno)
                        {
                            continue;
                        }
                        else
                        {
                            MaxRecipeno = Recipeno;
                        }

                    }
                    MaxRecipeno++;
                    /*<============================*/
                    myDataView.RowFilter = m_strExecuteFilter;

                    myDataView.Sort = "recipeno_int,ORDERID_CHR";
                    if (myDataView.Count <= 0)
                    {
                        return lngRes;
                    }
                    DataTable m_dtOrder = myDataView.ToTable();

                    m_lngGetOrderArrFromDataTableNew2(m_dtOrder, out arrOrder);
                }

                HRPService.Dispose();

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
        /// 
        /// </summary>
        /// <param name="m_arrORDERID_CHR"></param>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetArrOrderByOrderID(ArrayList m_arrORDERID_CHR, out clsBIHOrder[] arrOrder)
        {
            long lngRes = -1;
            string m_strORDERID_CHR = "";
            ArrayList m_arrOrders = new ArrayList();
            arrOrder = null;

            for (int i = 0; i < m_arrORDERID_CHR.Count; i++)
            {
                if (!m_arrOrders.Contains(m_arrORDERID_CHR[i].ToString()))
                {
                    m_strORDERID_CHR += "'" + m_arrORDERID_CHR[i].ToString() + "',";
                    m_arrOrders.Add(m_arrORDERID_CHR[i].ToString());
                }

            }
            m_strORDERID_CHR = m_strORDERID_CHR.TrimEnd(",".ToCharArray());
            if (m_strORDERID_CHR.Trim().Length == 0)
            {
                return 0;
            }
            string strSql = @"
            select
            sysdate,
            trunc(sysdate) today,
            trunc(a.createdate_dat) creatday, 
            c.sample_type_desc_vchr,
            d.partname,
            e.ordercateid_chr,
            e.ITEMID_CHR CHARGEITEMID_CHR,
            e.LISAPPLYUNITID_CHR,
            e.APPLYTYPEID_CHR,
            e.NAME_CHR DicName,
            a.*
            from 
            t_opr_bih_order a,
            t_aid_lis_sampletype c,
            ar_apply_partlist d,
            t_bse_bih_orderdic e
            where
            a.sampleid_vchr=c.sample_type_id_chr(+)
            and
            a.partid_vchr=d.partid(+)
            and
            a.orderdicid_chr=e.orderdicid_chr(+)
            and
            a.ORDERID_CHR in ([m_strORDERID_CHR])
             ";
            try
            {
                clsHRPTableService HRPService = new clsHRPTableService();
                strSql = strSql.Replace("[m_strORDERID_CHR]", m_strORDERID_CHR);
                DataTable m_dtOrder = new DataTable();
                lngRes = 0;
                lngRes = HRPService.lngGetDataTableWithoutParameters(strSql, ref m_dtOrder);
                if (m_dtOrder.Rows.Count > 0)
                {
                    m_lngGetOrderArrFromDataTableNew(m_dtOrder, out arrOrder);
                }

                HRPService.Dispose();

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
        /// 根据流水号获取医嘱
        /// </summary>
        /// <param name="m_strORDERID_CHR">流水号</param>
        /// <param name="m_objOrder">返回的医嘱对象</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderByOrderIDs(ArrayList m_arrORDERID_CHR, out clsBIHOrder[] arrOrder)
        {

            long lngRes = -1;
            string m_strORDERID_CHR = m_arrORDERID_CHR[0].ToString();
            arrOrder = null;
            string strSql = @"
            select
            sysdate,
            trunc(sysdate) today,
            trunc(a.createdate_dat) creatday, 
            c.sample_type_desc_vchr,
            d.partname,
            e.ordercateid_chr,
            g.sign_grp,
            h.UNITPRICE_DEC  itemprice,
            h.INSURACEDESC_VCHR  MedicareTypeName,
            h.CHARGEITEMID_CHR ,
            h.CHARGEITEMNAME_CHR ,
            a.*
            from 
            t_opr_bih_order a,
            t_aid_lis_sampletype c,
            ar_apply_partlist d,
            t_bse_bih_orderdic e,
            t_bse_empsign g,
            (select 
            orderid_chr, UNITPRICE_DEC,INSURACEDESC_VCHR,CHARGEITEMID_CHR,CHARGEITEMNAME_CHR 
            from t_opr_bih_orderchargedept where flag_int=0) h
            where
            a.sampleid_vchr=c.sample_type_id_chr(+)
            and
            a.partid_vchr=d.partid(+)
            and
            a.orderdicid_chr=e.orderdicid_chr(+)
            and
            a.doctorid_chr=g.empid_chr(+)
            and
            a.orderid_chr=h.orderid_chr(+)
            and
            a.ORDERID_CHR=?
             ";
            try
            {
                clsHRPTableService HRPService = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strORDERID_CHR.Trim();
                DataTable objDT = new DataTable();
                lngRes = 0;
                lngRes = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if (objDT.Rows.Count > 0)
                {
                    DataView myDataView = new DataView(objDT);
                    //统计可提交医嘱数目
                    /*<===========================*/
                    myDataView.Sort = "recipeno_int,ORDERID_CHR";
                    if (myDataView.Count <= 0)
                    {
                        return lngRes;
                    }
                    DataTable m_dtOrder = myDataView.ToTable();

                    m_lngGetOrderArrFromDataTableNew(m_dtOrder, out arrOrder);

                }

                HRPService.Dispose();

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
        /// 查询已全区发送的病区信息
        /// </summary>
        /// <param name="m_strAreaID">病区ID</param>
        /// <param name="objDT"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindSendArea(string m_strAreaID, out DataTable objDT)
        {
            objDT = new DataTable();
            string strSql = @"
				select a.SEQ_INT,a.put_dat,b.deptid_chr,b.deptname_vchr,b.code_vchr from 
 t_opr_bih_areaputmedrecord a,T_BSE_DeptDesc b
 where 
 a.areaid_chr=b.deptid_chr
 and 
 trunc(a.put_dat)=trunc(sysdate)	
 and 
 a.status_int=1 
 and
 b.deptid_chr='[m_strAreaID]' 
			";


            strSql = strSql.Replace("[m_strAreaID]", m_strAreaID);


            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            /* <<============================== */
            return ret;
        }


        /// <summary>
        /// 将当前医嘱置为新开医嘱的修改(主要针对修改方号及父医嘱标志置为空   -- 该方法不再使用20180403
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyNewRecipenNoOrder(clsBIHOrder objOrder)
        {

            long lngRecEff = 0;
            string strSql = @"
				update T_Opr_Bih_Order
				set OrderDicID_Chr=?,RegisterID_Chr=?,PatientID_Chr=?,ExecuteType_Int=?,RecipeNo_Int=?,
					Name_VChr=?,Spec_VChr=?,ExecFreqID_Chr=?,ExecFreqName_Chr=?,Dosage_Dec=?,
                    DosageUnit_Chr=?,Get_Dec=?,GetUnit_Chr=?,Use_Dec=?,UseUnit_Chr=?,
                    DoseTypeID_Chr=?,DoseTypeName_Chr=?,Entrust_Vchr=?,ParentID_Chr=?,Status_Int=?,
                    IsRich_Int=?,RateType_Int=?,IsRepare_Int=? , CreatorID_Chr=?,Creator_Chr=?,
                    CreateDate_Dat=?,ISNEEDFEEL=?,OUTGETMEDDAYS_INT=?,STARTDATE_DAT=?,SAMPLEID_VCHR=?,
                    LISAPPID_VCHR=?,PARTID_VCHR=?,FINISHDATE_DAT=?,ATTACHTIMES_INT=?,DOCTORID_CHR=?,
                    DOCTOR_VCHR=?,STOPERID_CHR=?,STOPER_CHR=?,STOPDATE_DAT=?,REMARK_VCHR=?
				    where OrderID_Chr =?
             ";
            /*<=========================================================================*/
            //
            System.Data.IDataParameter[] arrParams = null;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            objHRPSvc.CreateDatabaseParameter(41, out arrParams);
            int n = -1;

            arrParams[++n].Value = objOrder.m_strOrderDicID;
            arrParams[++n].Value = objOrder.m_strRegisterID;
            arrParams[++n].Value = objOrder.m_strPatientID;
            arrParams[++n].Value = objOrder.m_intExecuteType;
            arrParams[++n].Value = objOrder.m_intRecipenNo;

            arrParams[++n].Value = objOrder.m_strName;
            arrParams[++n].Value = objOrder.m_strSpec;
            arrParams[++n].Value = objOrder.m_strExecFreqID;
            arrParams[++n].Value = objOrder.m_strExecFreqName;
            if (objOrder.m_dmlDosage > 0)
                arrParams[++n].Value = objOrder.m_dmlDosage;
            else
                arrParams[++n].Value = null;


            arrParams[++n].Value = objOrder.m_strDosageUnit;
            if (objOrder.m_dmlGet > 0)
                arrParams[++n].Value = objOrder.m_dmlGet;
            else
                arrParams[++n].Value = null;
            arrParams[++n].Value = objOrder.m_strGetunit;
            if (objOrder.m_dmlGet > 0)
                arrParams[++n].Value = objOrder.m_dmlUse;
            else
                arrParams[++n].Value = null;
            arrParams[++n].Value = objOrder.m_strUseunit;


            arrParams[++n].Value = objOrder.m_strDosetypeID;
            arrParams[++n].Value = objOrder.m_strDosetypeName;
            arrParams[++n].Value = objOrder.m_strEntrust;
            arrParams[++n].Value = objOrder.m_strParentID;
            arrParams[++n].Value = objOrder.m_intStatus;


            arrParams[++n].Value = objOrder.m_intIsRich;
            arrParams[++n].Value = objOrder.RateType;
            arrParams[++n].Value = objOrder.m_intIsRepare;
            arrParams[++n].Value = objOrder.m_strCreatorID;
            arrParams[++n].Value = objOrder.m_strCreator;


            arrParams[++n].Value = objOrder.m_dtCreatedate;
            arrParams[++n].Value = objOrder.m_intISNEEDFEEL;
            arrParams[++n].Value = objOrder.m_intOUTGETMEDDAYS_INT;
            if (objOrder.m_dtStartDate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtStartDate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            arrParams[++n].Value = objOrder.m_strSAMPLEID_VCHR;


            arrParams[++n].Value = objOrder.m_strLISAPPID_VCHR;
            arrParams[++n].Value = objOrder.m_strPARTID_VCHR;
            if (objOrder.m_dtFinishDate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtFinishDate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            if (objOrder.m_intExecuteType == 1)
            {
                arrParams[++n].Value = objOrder.m_intATTACHTIMES_INT;
            }
            else
            {
                arrParams[++n].Value = 0;
            }
            arrParams[++n].Value = objOrder.m_strDOCTORID_CHR;


            arrParams[++n].Value = objOrder.m_strDOCTOR_VCHR;
            arrParams[++n].Value = objOrder.m_strStoperID;
            arrParams[++n].Value = objOrder.m_strStoper;
            if (objOrder.m_dtStopdate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtStopdate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            arrParams[++n].Value = objOrder.m_strREMARK_VCHR;


            arrParams[++n].Value = objOrder.m_strOrderID;


            long lngAff = 0;
            long ret = 0;
            try
            {
                ret = 0;
                ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);
                if (ret > 0)
                {
                    strSql = @"
                    update t_opr_bih_order 
                    set
                    RECIPENO_INT=
                    decode(
                    (select max(a.recipeno_int) recipeno_int from t_opr_bih_order a where a.registerid_chr=?)
                    ,null,
                     1,
                     (select max(a.recipeno_int)+1 recipeno_int from t_opr_bih_order a where a.registerid_chr=?) 
                      )
                    where orderid_chr=?";
                    System.Data.IDataParameter[] Params3 = null;
                    objHRPSvc.CreateDatabaseParameter(3, out Params3);
                    Params3[0].Value = objOrder.m_strRegisterID.Trim();
                    Params3[1].Value = objOrder.m_strRegisterID.Trim();
                    Params3[2].Value = objOrder.m_strOrderID;

                    ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, Params3);
                    if (ret > 0)
                    {
                        if (objOrder.m_intExecuteType == 1)
                        {
                            strSql = @"
                            update t_opr_bih_order 
                            set
                            RECIPENO2_INT=
                            decode(
                            (select max(a.recipeno2_int) recipeno2_int from t_opr_bih_order a where  EXECUTETYPE_INT=1 and OPERATION_INT=0 and a.registerid_chr=? )
                            ,null,
                             1,
                             (select max(a.recipeno2_int)+1 recipeno2_int from t_opr_bih_order a where EXECUTETYPE_INT=1 and OPERATION_INT=0 and a.registerid_chr=?) 
                              )
                            where orderid_chr=?";
                            System.Data.IDataParameter[] Params4 = null;
                            objHRPSvc.CreateDatabaseParameter(3, out Params4);
                            Params4[0].Value = objOrder.m_strRegisterID.Trim();
                            Params4[1].Value = objOrder.m_strRegisterID.Trim();
                            Params4[2].Value = objOrder.m_strOrderID;
                            ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, Params4);
                        }
                        else
                        {
                            strSql = @"
                            update t_opr_bih_order 
                            set
                            RECIPENO2_INT=null
                            where orderid_chr=? ";
                            System.Data.IDataParameter[] Params4 = null;
                            objHRPSvc.CreateDatabaseParameter(1, out Params4);
                            Params4[0].Value = objOrder.m_strOrderID;
                            ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, Params4);
                        }
                    }
                }
                if (ret > 0)
                {
                    string strSQL = @"
                    delete from T_OPR_BIH_ORDERCHARGEDEPT where ORDERID_CHR=?
                    ";

                    arrParams = null;
                    objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                    arrParams[0].Value = objOrder.m_strOrderID;
                    long lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams);
                    objHRPSvc.Dispose();
                    //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT]
                    //clsBIHORDERCHARGEDService OrderCharge = new clsBIHORDERCHARGEDService();
                    //OrderCharge.ExecOrderToChargeItem(objOrder.m_strOrderID, objOrder.m_strCREATEAREA_ID);
                    //OrderCharge.UsageToChargeItem(objOrder.m_strOrderID, objOrder.m_strCREATEAREA_ID);
                    ExecOrderToChargeItem(objOrder);
                    UsageToChargeItem(objOrder);

                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            if (ret > 0)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 将当前医嘱置某子医嘱的修改(06-8-8)
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyCurrentSubOrder(clsBIHOrder objOrder)
        {


            string strSql = @"
				update T_Opr_Bih_Order
				set OrderDicID_Chr=?,RegisterID_Chr=?,PatientID_Chr=?,ExecuteType_Int=?,RecipeNo_Int=?,
					Name_VChr=?,Spec_VChr=?,ExecFreqID_Chr=?,ExecFreqName_Chr=?,Dosage_Dec=?,DosageUnit_Chr=?,
					Get_Dec=?,GetUnit_Chr=?,Use_Dec=?,UseUnit_Chr=?,DoseTypeID_Chr=?,DoseTypeName_Chr=?,
					Entrust_Vchr=?,ParentID_Chr=?,Status_Int=?,IsRich_Int=?,
					RateType_Int=?,IsRepare_Int=? , CreatorID_Chr=?,Creator_Chr=?,CreateDate_Dat=?,ISNEEDFEEL=?,OUTGETMEDDAYS_INT=?
					,STARTDATE_DAT=?,SAMPLEID_VCHR=?,LISAPPID_VCHR=?,PARTID_VCHR=?,FINISHDATE_DAT=?,ATTACHTIMES_INT=?
                    ,DOCTORID_CHR=?,DOCTOR_VCHR=?,STOPERID_CHR=?,STOPER_CHR=?,STOPDATE_DAT=?,REMARK_VCHR=?
				where OrderID_Chr =?
             ";
            /*<=========================================================================*/
            //
            int n = -1;
            System.Data.IDataParameter[] arrParams = null;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            objHRPSvc.CreateDatabaseParameter(41, out arrParams);

            arrParams[++n].Value = objOrder.m_strOrderDicID;
            arrParams[++n].Value = objOrder.m_strRegisterID;
            arrParams[++n].Value = objOrder.m_strPatientID;
            arrParams[++n].Value = objOrder.m_intExecuteType;
            arrParams[++n].Value = objOrder.m_intRecipenNo;

            arrParams[++n].Value = objOrder.m_strName;
            arrParams[++n].Value = objOrder.m_strSpec;
            arrParams[++n].Value = objOrder.m_strExecFreqID;
            arrParams[++n].Value = objOrder.m_strExecFreqName;
            if (objOrder.m_dmlDosage > 0)
                arrParams[++n].Value = objOrder.m_dmlDosage;
            else
                arrParams[++n].Value = null;


            arrParams[++n].Value = objOrder.m_strDosageUnit;
            if (objOrder.m_dmlGet > 0)
                arrParams[++n].Value = objOrder.m_dmlGet;
            else
                arrParams[++n].Value = null;
            arrParams[++n].Value = objOrder.m_strGetunit;
            if (objOrder.m_dmlGet > 0)
                arrParams[++n].Value = objOrder.m_dmlUse;
            else
                arrParams[++n].Value = null;
            arrParams[++n].Value = objOrder.m_strUseunit;


            arrParams[++n].Value = objOrder.m_strDosetypeID;
            arrParams[++n].Value = objOrder.m_strDosetypeName;
            arrParams[++n].Value = objOrder.m_strEntrust;
            arrParams[++n].Value = objOrder.m_strParentID;
            arrParams[++n].Value = objOrder.m_intStatus;


            arrParams[++n].Value = objOrder.m_intIsRich;
            arrParams[++n].Value = objOrder.RateType;
            arrParams[++n].Value = objOrder.m_intIsRepare;
            arrParams[++n].Value = objOrder.m_strCreatorID;
            arrParams[++n].Value = objOrder.m_strCreator;


            arrParams[++n].Value = objOrder.m_dtCreatedate;
            arrParams[++n].Value = objOrder.m_intISNEEDFEEL;
            arrParams[++n].Value = objOrder.m_intOUTGETMEDDAYS_INT;
            if (objOrder.m_dtStartDate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtStartDate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            arrParams[++n].Value = objOrder.m_strSAMPLEID_VCHR;


            arrParams[++n].Value = objOrder.m_strLISAPPID_VCHR;
            arrParams[++n].Value = objOrder.m_strPARTID_VCHR;
            if (objOrder.m_dtFinishDate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtFinishDate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            if (objOrder.m_intExecuteType == 1)
            {
                arrParams[++n].Value = objOrder.m_intATTACHTIMES_INT;
            }
            else
            {
                arrParams[++n].Value = 0;
            }
            arrParams[++n].Value = objOrder.m_strDOCTORID_CHR;


            arrParams[++n].Value = objOrder.m_strDOCTOR_VCHR;
            arrParams[++n].Value = objOrder.m_strStoperID;
            arrParams[++n].Value = objOrder.m_strStoper;
            if (objOrder.m_dtStopdate != DateTime.MinValue)
            {
                arrParams[++n].Value = objOrder.m_dtStopdate;
            }
            else
            {
                arrParams[++n].Value = null;
            }
            arrParams[++n].Value = objOrder.m_strREMARK_VCHR;

            arrParams[++n].Value = objOrder.m_strOrderID;


            long lngAff = 0;
            long ret = 0;
            try
            {
                ret = 0;

                ret = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);


                if (ret > 0)
                {
                    // 如果是增加子医嘱，则改变父医嘱的交医嘱标记
                    //if (objOrder.m_intIFPARENTID_INT == 0 && objOrder.m_strParentID != null && !objOrder.m_strParentID.ToString().Trim().Equals(""))
                    //{
                    //    strSql = "update T_Opr_Bih_Order a set a.IFPARENTID_INT=1 where a.ORDERID_CHR='" + objOrder.m_strParentID + "'";
                    //    ret = objHRPSvc.DoExcute(strSql);
                    //}
                    /*<=====================================================*/
                    // 如果是增加子医嘱，则改变父医嘱的父医嘱标记
                    long lngRes = 0, lngRecEff = 0;
                    if (objOrder.m_intIFPARENTID_INT == 0 && objOrder.m_strParentID != null && !objOrder.m_strParentID.ToString().Trim().Equals(""))
                    {
                        strSql = "update T_Opr_Bih_Order a set a.IFPARENTID_INT=1 where a.ORDERID_CHR=? ";
                        System.Data.IDataParameter[] Params2 = null;
                        objHRPSvc.CreateDatabaseParameter(1, out Params2);
                        Params2[0].Value = objOrder.m_strParentID;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, Params2);
                    }
                    /*<=====================================================*/
                    strSql = "update T_Opr_Bih_Order  set DOSETYPEID_CHR=?,DOSETYPENAME_CHR=?,EXECFREQID_CHR=?,EXECFREQNAME_CHR=? where REGISTERID_CHR=? and RECIPENO_INT=? ";
                    System.Data.IDataParameter[] Params3 = null;
                    objHRPSvc.CreateDatabaseParameter(6, out Params3);
                    Params3[0].Value = objOrder.m_strDosetypeID;
                    Params3[1].Value = objOrder.m_strDosetypeName;
                    Params3[2].Value = objOrder.m_strExecFreqID;
                    Params3[3].Value = objOrder.m_strExecFreqName;
                    Params3[4].Value = objOrder.m_strRegisterID;
                    Params3[5].Value = objOrder.m_intRecipenNo;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngRecEff, Params3);
                }
                if (ret > 0)
                {
                    string strSQL = @"
                    delete from T_OPR_BIH_ORDERCHARGEDEPT where ORDERID_CHR=?
                    ";

                    arrParams = null;
                    objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                    //Please change the datetime and reocrdid 
                    arrParams[0].Value = objOrder.m_strOrderID;
                    long lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams);
                    objHRPSvc.Dispose();
                    //添加收费项目到[住院诊疗项目收费项目执行客户表-T_OPR_BIH_ORDERCHARGEDEPT]
                    //clsBIHORDERCHARGEDService OrderCharge = new clsBIHORDERCHARGEDService();
                    //OrderCharge.ExecOrderToChargeItem(objOrder.m_strOrderID, objOrder.m_strCREATEAREA_ID);
                    //OrderCharge.UsageToChargeItem(objOrder.m_strOrderID, objOrder.m_strCREATEAREA_ID);
                    ExecOrderToChargeItem(objOrder);
                    UsageToChargeItem(objOrder);

                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            if (ret > 0)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 诊疗项目对应的频率,用法,补次等的界面控制
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAidOrderCateByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID, out clsT_aid_bih_ordercate_VO p_objResult)
        {
            p_objResult = new clsT_aid_bih_ordercate_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetAidOrderCateByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.ordercateid_chr, a.name_chr, a.des_vchr, a.sourcetable_vchr,
                                   a.tablepk_vchr, a.dllname_vchr, a.classname_vchr, a.opradd_vchr,
                                   a.oprupd_vchr, a.viewname_vchr, a.isattach_int, a.feqviewtype,
                                   a.usageviewtype, a.dosageviewtype, a.isattach, a.createchargetype,
                                   a.appendviewtype_int, a.qtyviewtype_int,
                                   decode (a.isattach_int, 1, '√', 0, '×', '') as isattach
                              from t_aid_bih_ordercate a
                             where a.ordercateid_chr = ?";

            try
            {
                DataTable dtbResult = new DataTable();
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strID.Trim();

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsT_aid_bih_ordercate_VO();
                    p_objResult.m_strORDERCATEID_CHR = dtbResult.Rows[0]["ORDERCATEID_CHR"].ToString().Trim();
                    p_objResult.m_strNAME_CHR = dtbResult.Rows[0]["NAME_CHR"].ToString().Trim();
                    p_objResult.m_strDES_VCHR = dtbResult.Rows[0]["DES_VCHR"].ToString().Trim();
                    p_objResult.m_strSOURCETABLE_VCHR = dtbResult.Rows[0]["SOURCETABLE_VCHR"].ToString().Trim();
                    p_objResult.m_strTABLEPK_VCHR = dtbResult.Rows[0]["TABLEPK_VCHR"].ToString().Trim();
                    p_objResult.m_strDLLNAME_VCHR = dtbResult.Rows[0]["DLLNAME_VCHR"].ToString().Trim();
                    p_objResult.m_strCLASSNAME_VCHR = dtbResult.Rows[0]["CLASSNAME_VCHR"].ToString().Trim();
                    p_objResult.m_strOPRADD_VCHR = dtbResult.Rows[0]["OPRADD_VCHR"].ToString().Trim();
                    p_objResult.m_strOPRUPD_VCHR = dtbResult.Rows[0]["OPRUPD_VCHR"].ToString().Trim();
                    p_objResult.m_strVIEWNAME_VCHR = dtbResult.Rows[0]["VIEWNAME_VCHR"].ToString().Trim();

                    if (dtbResult.Rows[0]["ISATTACH_INT"] != System.DBNull.Value)
                    {
                        p_objResult.m_intISATTACH_INT = Convert.ToInt32(dtbResult.Rows[0]["ISATTACH_INT"].ToString().Trim());
                    }
                    //是否显示频率{1/2}
                    if (dtbResult.Rows[0]["FEQVIEWTYPE"] != System.DBNull.Value)
                    {
                        p_objResult.m_intExecuFrenquenceType = Convert.ToInt32(dtbResult.Rows[0]["FEQVIEWTYPE"].ToString().Trim());
                    }
                    //是否显示用法{1/2}
                    if (dtbResult.Rows[0]["USAGEVIEWTYPE"] != System.DBNull.Value)
                    {
                        p_objResult.m_intUSAGEVIEWTYPE = Convert.ToInt32(dtbResult.Rows[0]["USAGEVIEWTYPE"].ToString().Trim());
                    }
                    //是否显示剂量{1/2}
                    if (dtbResult.Rows[0]["DOSAGEVIEWTYPE"] != System.DBNull.Value)
                    {
                        p_objResult.m_intDOSAGEVIEWTYPE = Convert.ToInt32(dtbResult.Rows[0]["DOSAGEVIEWTYPE"].ToString().Trim());
                    }
                    //非字段
                    p_objResult.m_strIsAttach = dtbResult.Rows[0]["IsAttach"].ToString();
                    //收费标志
                    if (dtbResult.Rows[0]["CREATECHARGETYPE"].ToString().Trim() != "")
                    {
                        p_objResult.m_intChargeType = int.Parse(dtbResult.Rows[0]["CREATECHARGETYPE"].ToString());
                    }
                    //是否显示补次 {1/2}
                    if (dtbResult.Rows[0]["APPENDVIEWTYPE_INT"] != System.DBNull.Value)
                    {
                        p_objResult.m_intAPPENDVIEWTYPE_INT = Convert.ToInt32(dtbResult.Rows[0]["APPENDVIEWTYPE_INT"].ToString().Trim());

                    }
                    //是否显示数量 {1/2}
                    if (dtbResult.Rows[0]["QTYVIEWTYPE_INT"] != System.DBNull.Value)
                    {
                        p_objResult.m_intQTYVIEWTYPE_INT = Convert.ToInt32(dtbResult.Rows[0]["QTYVIEWTYPE_INT"].ToString().Trim());

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

        #region 作废恢复医嘱
        /// <summary>
        /// 作废恢复医嘱
        /// </summary>
        /// <param name="strOrderIDs"></param>
        /// <param name="DELETERID_CHR"></param>
        /// <param name="DELETERNAME_VCHR"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBihOrderDrawBack(string strOrderIDs)
        {
            //string strSql=@"update T_Opr_Bih_Order set Status_Int = -1 where trim(OrderID_Chr) in ([OrderIDArr]) ";
            string strSql = @"UPDATE t_opr_bih_order SET status_int = 0,DELETERID_CHR=null,DELETERNAME_VCHR=null,DELETE_DAT=null WHERE (status_int=-1) AND TRIM(orderid_chr) IN ([ORDERIDARR]) ";
            strSql = strSql.Replace("[ORDERIDARR]", strOrderIDs);

            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoExcute(strSql);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        #endregion

        #region 医嘱医生签名
        /// <summary>
        /// 医嘱医生签名
        /// </summary>
        /// <param name="strOrderID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCurrentOrderDoctorSign(string strOrderID)
        {
            //string strSql=@"update T_Opr_Bih_Order set Status_Int = -1 where trim(OrderID_Chr) in ([OrderIDArr]) ";
            string strSql = @"UPDATE t_opr_bih_order SET SIGN_INT = 1 WHERE  TRIM(orderid_chr) IN ([ORDERIDARR]) ";
            strSql = strSql.Replace("[ORDERIDARR]", strOrderID);

            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoExcute(strSql);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        #endregion

        /// <summary>
        /// 返回当前收费项目是否片剂
        /// </summary>
        /// <param name="m_strItemid_chr"></param>
        /// <param name="m_blIsType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrepTypeP(string m_strOrderdicid_chr, out bool m_blIsType)
        {
            m_blIsType = false;
            DataTable objDT = new DataTable();
            string strSql = @"
            select count(a.itemid_chr) mCount from 
            t_bse_chargeitem a,
            t_bse_medicine b,
            t_aid_medicinepreptype c,
            t_bse_bih_orderdic d
            where
            a.itemsrcid_vchr=b.medicineid_chr
            and
            b.medicinepreptype_chr=c.medicinepreptype_chr
            and
            d.itemid_chr=a.itemid_chr
            and
            c.medicinepreptypename_vchr = '片剂'
            and
            d.orderdicid_chr=?
			";
            // strSql = strSql.Replace("[orderdicid_chr]", m_strOrderdicid_chr);
            long ret = 0;
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPService = new clsHRPTableService();
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strOrderdicid_chr;
                ret = 0;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if (ret > 0 && objDT.Rows.Count > 0)
                {
                    if (!objDT.Rows[0]["mCount"].ToString().Equals(""))
                    {
                        if (int.Parse(objDT.Rows[0]["mCount"].ToString()) > 0)
                        {
                            m_blIsType = true;
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

            /* <<============================== */
            return ret;
        }

        /// <summary>
        /// 返回药品制剂类型VO
        /// </summary>
        /// <param name="m_strOrderdicid_chr"></param>
        /// <param name="m_objMEDICINEPREPTYPE"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrepTypeP(string m_strOrderdicid_chr, out clsMEDICINEPREPTYPE_VO m_objMEDICINEPREPTYPE)
        {
            m_objMEDICINEPREPTYPE = null;
            DataTable objDT = new DataTable();
            string strSql = @"
            select c.medicinepreptype_chr,c.medicinepreptypename_vchr,c.flaga_int from 
            t_bse_chargeitem a,
            t_bse_medicine b,
            t_aid_medicinepreptype c,
            t_bse_bih_orderdic d
            where
            a.itemsrcid_vchr=b.medicineid_chr
            and
            b.medicinepreptype_chr=c.medicinepreptype_chr
            and
            d.itemid_chr=a.itemid_chr
            and
            a.ITEMSRCTYPE_INT=1
            and
            d.orderdicid_chr=?
			";
            // strSql = strSql.Replace("[orderdicid_chr]", m_strOrderdicid_chr);
            long ret = 0;
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPService = new clsHRPTableService();
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strOrderdicid_chr;
                ret = 0;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if (ret > 0 && objDT.Rows.Count > 0)
                {
                    m_objMEDICINEPREPTYPE = new clsMEDICINEPREPTYPE_VO();
                    m_objMEDICINEPREPTYPE.m_strMEDICINEPREPTYPE_CHR = Convert.ToString(objDT.Rows[0]["medicinepreptype_chr"].ToString().Trim());
                    m_objMEDICINEPREPTYPE.m_strMEDICINEPREPTYPENAME_VCHR = Convert.ToString(objDT.Rows[0]["medicinepreptypename_vchr"].ToString().Trim());
                    m_objMEDICINEPREPTYPE.m_intFLAGA_INT = int.Parse(objDT.Rows[0]["flaga_int"].ToString());
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            /* <<============================== */
            return ret;
        }

        /// <summary>
        /// 获取医嘱病床Vo信息
        /// </summary>
        /// <param name="strAreaID">病区ID</param>
        /// <param name="strInputCode">查询字符串</param>
        /// <param name="arrBed"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihBedByArea(string strAreaID, string strInputCode, out clsBIHBed[] arrBed)
        {

            string strSql = @"
                SELECT  distinct  d.registerid_chr,d.curbedid_chr, a.code_chr, d.curareaid_chr,e.deptname_vchr, b.lastname_vchr, b.sex_chr
                FROM t_bse_bed a, t_opr_bih_registerdetail b, t_opr_bih_register c,t_opr_bih_order d,t_bse_deptdesc e
                WHERE 
                d.registerid_chr=c.registerid_chr
                and d.curbedid_chr= a.bedid_chr(+)
                AND c.registerid_chr = b.registerid_chr
                and d.curareaid_chr=e.deptid_chr(+)
                AND TRIM (LOWER (a.code_chr)) LIKE ?
                AND d.CREATEAREAID_CHR = ?
                and d.status_int in (2,5)
                ORDER BY d.curareaid_chr, a.code_chr

			";
            string InputCode = strInputCode.ToLower().Trim() + "%";
            System.Data.IDataParameter[] arrParams = null;
            new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
            arrParams[0].Value = InputCode;
            arrParams[1].Value = strAreaID.Trim();
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                ret = new clsHRPTableService().lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            /*<--------------------------------------------------*/

            if ((ret > 0) && (objDT != null))
            {
                arrBed = new clsBIHBed[objDT.Rows.Count];
                for (int i = 0; i < arrBed.Length; i++)
                {
                    arrBed[i] = new clsBIHBed();
                    arrBed[i].m_strAreaID = clsConverter.ToString(objDT.Rows[i]["curareaid_chr"]).Trim();

                    arrBed[i].m_strBedID = clsConverter.ToString(objDT.Rows[i]["curbedid_chr"]).Trim();
                    arrBed[i].m_strBedName = clsConverter.ToString(objDT.Rows[i]["Code_Chr"]).Trim();
                    clsBIHPatientInfo patient = new clsBIHPatientInfo();
                    patient.m_strRegisterID = clsConverter.ToString(objDT.Rows[i]["registerid_chr"].ToString().Trim());
                    patient.m_strPatientName = clsConverter.ToString(objDT.Rows[i]["lastname_vchr"].ToString()).Trim();
                    patient.m_strSex = clsConverter.ToString(objDT.Rows[i]["sex_chr"].ToString()).Trim();
                    patient.m_strAreaID = clsConverter.ToString(objDT.Rows[i]["curareaid_chr"].ToString()).Trim();
                    patient.m_strAreaName = clsConverter.ToString(objDT.Rows[i]["deptname_vchr"].ToString()).Trim();
                    arrBed[i].m_objPatient = patient;
                }
                return 1;
            }
            else
            {
                arrBed = null;
                return 0;
            }

        }



        #region  查询当前新开医嘱费用合计

        [AutoComplete]
        public long m_lngMoneyCountNewOrder(string p_strRegisterID, out decimal m_decMoneySum)
        {

            long lngRes = 0;
            m_decMoneySum = 0;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            DataTable dtResult = new DataTable();

            string strSql = @"	
                select  sum(b.AMOUNT_DEC*b.unitprice_dec) money from t_opr_bih_order a,T_OPR_BIH_ORDERCHARGEDEPT b
                where a.orderid_chr=b.orderid_chr
                and
                a.status_int=0 and b.RATETYPE_INT=1
                and
                a.registerid_chr=?
			";

            System.Data.IDataParameter[] arrParams = null;
            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = p_strRegisterID;
            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                if (lngRes > 0)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        decimal.TryParse(dtResult.Rows[0]["money"].ToString(), out m_decMoneySum);
                    }
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
        #endregion

        //医嘱执行
        #region 医嘱收费信息(来源于T_OPR_BIH_ORDERCHARGEDEPT住院诊疗项目收费项目执行客户表)
        /// <summary>
        /// 医嘱收费信息(来源于T_OPR_BIH_ORDERCHARGEDEPT住院诊疗项目收费项目执行客户表)
        /// </summary>
        /// <param name="m_strOrderid_chr">医嘱ID</param>
        /// <param name="m_dtChargeList">费用信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBIHChargeFromDEPT(string m_strOrderid_chr, out DataTable m_dtChargeList)
        {
            long lngRes = -1;
            m_dtChargeList = new DataTable();

            string strSql = @"	
                        select 
                        c.seq_int, c.orderid_chr, c.orderdicid_chr, c.chargeitemid_chr, c.clacarea_chr, c.createarea_chr, 
	c.flag_int, c.chargeitemname_chr, c.spec_vchr, c.unit_vchr, c.amount_dec, c.unitprice_dec, c.creatorid_chr, 
	c.creator_vchr, c.createdate_dat, c.remark, c.insuracedesc_vchr, c.ratetype_int, c.poflag_int, 
	c.continueusetype_int, c.singleamount_dec, c.newdiscount_dec, c.continuefreqid_chr, c.continuechargetype_int,c.itemchargetype_vchr,
                        a.orderid_chr,
                        d.deptname_vchr,
                        e.itemcode_vchr
                        from
                        t_opr_bih_order  a,         
                        t_opr_bih_orderchargedept c,
                        t_bse_deptdesc d,
                        t_bse_chargeitem e             
                        where 
                        a.orderid_chr=c.orderid_chr
                        and
                        c.clacarea_chr=d.deptid_chr(+)
                        and
                        c.chargeitemid_chr=e.itemid_chr(+)
                        and 
                        a.orderid_chr=?
                        order by  flag_int 
                   ";
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                clsHRPTableService HRPService = new clsHRPTableService();
                HRPService.CreateDatabaseParameter(1, out arrParams);

                arrParams[0].Value = m_strOrderid_chr;
                lngRes = 0;
                // strSql = strSql.Replace("[orderid_chr]", m_strOrderid_chr);
                lngRes = HRPService.lngGetDataTableWithParameters(strSql, ref m_dtChargeList, arrParams);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_strFindString"></param>
        /// <param name="objDT"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetORDERDESCByCode(string p_strFindString, out DataTable objDT)
        {
            objDT = new DataTable();
            string strSql = @"
        select a.descid_int, a.desc_vchr, a.usercode_vchr, a.wbcode_vchr, a.pycode_chr, a.creatorid_chr, a.creat_dat, a.status_int, a.deleterid_chr, a.delete_dat 
 from t_opr_bih_orderdesc a
        where (lower(a.usercode_vchr) like ? or lower(wbcode_vchr) like ? or lower(pycode_chr) like ?)  order by a.usercode_vchr
             ";
            //string strFind = " (( LOWER(UserCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(WBCode_Chr)	 like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(PYCode_Chr) like '" + p_strFindString.ToLower().Trim() + "%') or ( LOWER(Name_Chr) like '%" + p_strFindString.ToLower().Trim() + "%')) ";
            string strFind = "";
            //switch (m_intClass)
            //{
            //    case -1:
            //        strFind = "LOWER(a.PYCode_Chr)";
            //        break;
            //    case 0:
            //        strFind = "LOWER(a.PYCode_Chr)";
            //        break;
            //    case 1:
            //        strFind = "LOWER(a.WBCode_Chr)";
            //        break;
            //    case 2:
            //        strFind = "LOWER(a.Name_Chr)";
            //        break;
            //    case 3:
            //        strFind = "LOWER(a.UserCode_Chr)";
            //        break;
            //}
            strFind = p_strFindString;

            System.Data.IDataParameter[] arrParams = null;
            clsHRPTableService HRPService = new clsHRPTableService();
            HRPService.CreateDatabaseParameter(3, out arrParams);

            arrParams[0].Value = "%" + strFind + "%";
            arrParams[1].Value = strFind + "%";
            arrParams[2].Value = strFind + "%";

            long ret = 0;
            try
            {
                ret = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        /// <summary>
        /// 获取需要停用或停药的待过滤的医嘱
        /// </summary>
        /// <param name="m_arrOrders"></param>
        /// <param name="m_dtOrderSign"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderStopSignByRegisterId(string registerid_chr, out DataTable m_dtOrderSign)
        {

            long lngRes = -1;
            m_dtOrderSign = null;

            string strSql = @"
            select a.RECIPENO_INT,a.orderid_chr,b.STATUS_INT,d.IFSTOP_INT,d.ITEMSRCTYPE_INT,e.IPNOQTYFLAG_INT from 
            t_opr_bih_order a,
            t_bse_bih_orderdic b,
            T_AID_BIH_ORDERDIC_CHARGE c,
            t_bse_chargeitem d,
            T_BSE_MEDICINE e
            where
            a.orderdicid_chr=b.orderdicid_chr
            and
            b.orderdicid_chr=c.orderdicid_chr(+)
            and
            c.itemid_chr=d.itemid_chr(+)
            and
            d.itemsrcid_vchr=e.medicineid_chr(+)
            and
            (a.status_int in (0,1,5) or (a.status_int=2 and a.executetype_int=1)) 
            and
            (b.status_int=0 or d.ifstop_int=1 or e.ipnoqtyflag_int=1) 
            and
            a.registerid_chr=?
            
            ";
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = registerid_chr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtOrderSign, arrParams);
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
        /// 获取需要停用或停药的待过滤的医嘱
        /// </summary>
        /// <param name="m_arrOrders"></param>
        /// <param name="m_dtOrderSign"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderStopByRECIPENO_INT(ArrayList m_arrRecipenNo, string registerid_chr, out clsBIHOrder[] arrOrder, out DataTable m_dtChargeList)
        {
            long lngRes = -1;
            arrOrder = null;
            m_dtChargeList = null;
            string m_RECIPENO_INT = "";
            for (int i = 0; i < m_arrRecipenNo.Count; i++)
            {
                m_RECIPENO_INT += m_arrRecipenNo[i].ToString() + ",";

            }
            m_RECIPENO_INT = m_RECIPENO_INT.TrimEnd(",".ToCharArray());
            if (m_RECIPENO_INT.Trim().Length == 0)
            {
                return 0;
            }
            string strSql = @"
                select
                sysdate,
                trunc(sysdate) today,
                trunc(a.createdate_dat) creatday, 
                c.sample_type_desc_vchr,
                d.partname,
                e.ordercateid_chr,
                e.ITEMID_CHR CHARGEITEMID_CHR,
                e.LISAPPLYUNITID_CHR,
                e.APPLYTYPEID_CHR,
                e.NAME_CHR DicName,
                a.orderid_chr,a.orderdicid_chr,a.registerid_chr,a.patientid_chr,a.executetype_int,a.recipeno_int,
       a.name_vchr,a.spec_vchr,a.execfreqid_chr,a.dosage_dec,a.execfreqname_chr,a.dosageunit_chr,
       a.get_dec,a.useunit_chr,a.getunit_chr,a.dosetypeid_chr,a.dosetypename_chr,a.startdate_dat,
       a.finishdate_dat,a.execdeptid_chr,a.execdeptname_chr,a.entrust_vchr,a.parentid_chr,a.status_int,
       a.creatorid_chr,a.creator_chr,a.createdate_dat,a.posterid_chr,a.poster_chr,a.postdate_dat,
       a.executorid_chr,a.executor_chr,a.executedate_dat,a.stoperid_chr,a.stoper_chr,a.stopdate_dat,
       a.retractorid_chr,a.retractor_chr,a.retractdate_dat,a.isrich_int,a.ratetype_int,a.isrepare_int,
       a.use_dec,a.isneedfeel,a.outgetmeddays_int,a.assessoridforexec_chr,a.assessorforexec_chr,
       a.assessorforexec_dat,a.assessoridforstop_chr,a.assessorforstop_chr,a.assessorforstop_dat,
       a.backreason,a.sendbackid_chr,a.sendbacker_chr,a.sendback_dat,a.isyb_int,a.sampleid_vchr,
       a.lisappid_vchr,a.partid_vchr,a.createareaid_chr,a.createareaname_vchr,a.ifparentid_int,a.confirmerid_chr,
       a.confirmer_vchr,a.confirm_dat,a.attachtimes_int,a.doctorid_chr,a.doctor_vchr,a.curareaid_chr,
       a.curbedid_chr,a.doctorgroupid_chr,a.deleterid_chr,a.deletername_vchr,a.delete_dat,a.sign_int,
       a.operation_int,a.remark_vchr,a.recipeno2_int,a.feelresult_vchr,a.feel_int,a.type_int,a.charge_int,
       a.singleamount_dec,a.sourcetype_int,a.chargedoctorgroupid_chr,a.itemchargetype_vchr
                from 
                t_opr_bih_order a,
                t_aid_lis_sampletype c,
                ar_apply_partlist d,
                t_bse_bih_orderdic e
                where
                a.sampleid_vchr=c.sample_type_id_chr(+)
                and
                a.partid_vchr=d.partid(+)
                and
                a.orderdicid_chr=e.orderdicid_chr(+)
                and
                a.STATUS_INT<>-2
                and
                a.RECIPENO_INT in ([RECIPENO_INT])
                and
                a.REGISTERID_CHR=?
                 ";
            try
            {
                clsHRPTableService HRPService = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = registerid_chr.Trim();
                DataTable objDT = new DataTable();
                lngRes = 0;
                strSql = strSql.Replace("[RECIPENO_INT]", m_RECIPENO_INT);
                lngRes = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);

                if (objDT.Rows.Count > 0)
                {
                    DataView myDataView = new DataView(objDT);

                    myDataView.Sort = "recipeno_int,ORDERID_CHR";
                    if (myDataView.Count <= 0)
                    {
                        return lngRes;
                    }
                    DataTable m_dtOrder = myDataView.ToTable();
                    m_lngGetOrderArrFromDataTableNew(m_dtOrder, out arrOrder);


                    //相应的费用中间表信息
                    //费用明细表
                    strSql = @"
                        select 
                        distinct
                        c.seq_int, c.orderid_chr, c.orderdicid_chr, c.chargeitemid_chr, c.clacarea_chr, c.createarea_chr, 
	c.flag_int, c.chargeitemname_chr, c.spec_vchr, c.unit_vchr, c.amount_dec, c.unitprice_dec, c.creatorid_chr, 
	c.creator_vchr, c.createdate_dat, c.remark, c.insuracedesc_vchr, c.ratetype_int, c.poflag_int, 
	c.continueusetype_int, c.singleamount_dec, c.newdiscount_dec, c.continuefreqid_chr, c.continuechargetype_int,c.itemchargetype_vchr,
                        a.orderid_chr,
                        a.registerid_chr,
                        a.recipeno_int,
                        d.deptname_vchr,
                        f.itemsrctype_int,
                        f.itemcode_vchr,
                        f.itemspec_vchr,
                        f.ifstop_int,
                        g.ipnoqtyflag_int
                        from
                        t_opr_bih_order  a,
                        t_opr_bih_register b,
                        t_opr_bih_orderchargedept c,
                        t_bse_deptdesc d,
                        t_bse_chargeitem f,
                        t_bse_medicine g
                        where 
                        a.orderid_chr=c.orderid_chr
                        and
                        a.registerid_chr=b.registerid_chr
                        and
                        c.chargeitemid_chr=f.itemid_chr
                        and
                        f.itemsrcid_vchr=g.medicineid_chr(+)
                        and
                        c.clacarea_chr=d.deptid_chr(+)
                         and
                        a.RECIPENO_INT in ([RECIPENO_INT])
                        and
                       a.REGISTERID_CHR=?
                        order by c.orderid_chr,c.SEQ_INT  ";
                    strSql = strSql.Replace("[RECIPENO_INT]", m_RECIPENO_INT);
                    System.Data.IDataParameter[] arrParams2 = null;
                    HRPService.CreateDatabaseParameter(1, out arrParams2);
                    arrParams2[0].Value = registerid_chr.Trim();
                    lngRes = HRPService.lngGetDataTableWithParameters(strSql, ref m_dtChargeList, arrParams2);
                    /*<================================*/
                }

                HRPService.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }


        #region  获取当前用户是否具有全院允许维护公共医嘱嘱套的角色
        /// <summary>
        /// 获取当前用户是否具有全院允许维护公共医嘱嘱套的角色
        /// </summary>
        /// <param name="m_strEmpID">当前员工号</param>
        /// <param name="m_blSystemRole"></param>
        [AutoComplete]
        public long GetTheSystemRole(string m_strEmpID, out bool m_blSystemRole)
        {
            m_blSystemRole = false;
            long lngRes = -1;
            string strSQL = @"
            select A.deptid_chr from T_Sys_Role A,t_sys_emprolemap B 
                   where A.roleid_chr=B.roleid_chr(+) AND A.name_vchr=? AND B.empid_chr=?
            ";
            //            string strSQL = @"
            //            select A.roleid_chr from T_Sys_Role A
            //			where A.name_vchr=?  AND A.deptid_chr=?
            //            ";
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = "编辑公用医嘱组套";
                arrParams[1].Value = m_strEmpID;
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_blSystemRole = true;
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

        #region 插入术后医嘱（医嘱输入界面）
        /// <summary>
        ///插入术后医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <param name="p_strHandlersID">操作人ID</param>
        /// <param name="p_strHandlers">操作人名称</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertOPERATIONOrder(clsBIHOrder order, string p_strHandlersID, string p_strHandlers)
        {
            long lngAff = 0;
            long lngRes = 0;
            try
            {
                string p_strRecordID = "";
                lngRes = m_lngAddNewOrderNotSubAdd(out p_strRecordID, order);
                if (lngRes > 0)
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                    string strSql = @"	
				update T_Opr_Bih_Order
				set Status_Int = 3 , StoperID_Chr=? , Stoper_Chr = ? ,StopDate_Dat =sysdate,FINISHDATE_DAT =sysdate
				where
                status_int IN (0,1,2,5,7)
                and   REGISTERID_CHR=? and EXECUTETYPE_INT=1
			   ";
                    System.Data.IDataParameter[] arrParams = null;
                    objHRPSvc.CreateDatabaseParameter(3, out arrParams);
                    arrParams[0].Value = p_strHandlersID;
                    arrParams[1].Value = p_strHandlers;
                    arrParams[2].Value = order.m_strRegisterID;

                    lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);

                    strSql = @"	
        				update T_Opr_Bih_Order
        				set OPERATION_INT=1
        				where
                        REGISTERID_CHR=?
        			    ";
                    System.Data.IDataParameter[] arrParams2 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out arrParams2);
                    arrParams2[0].Value = order.m_strRegisterID;

                    lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams2);
                    objHRPSvc.Dispose();
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

        #region 插入转科医嘱（医嘱输入界面）
        /// <summary>
        ///插入转科医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <param name="p_strHandlersID">操作人ID</param>
        /// <param name="p_strHandlers">操作人名称</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertChangeAreaOrder(clsBIHOrder order, string p_strHandlersID, string p_strHandlers)
        {
            long lngAff = 0;
            long lngRes = 0;
            try
            {
                string p_strRecordID = "";
                lngRes = m_lngAddNewOrderNotSubAdd(out p_strRecordID, order);
                if (lngRes > 0)
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    string strSql = @"	
				update T_Opr_Bih_Order
				set Status_Int = 3 , StoperID_Chr=? , Stoper_Chr = ? ,StopDate_Dat =sysdate,FINISHDATE_DAT =sysdate
				where
                ORDERID_CHR=?
                and EXECUTETYPE_INT=1
			   ";
                    System.Data.IDataParameter[] arrParams = null;
                    objHRPSvc.CreateDatabaseParameter(3, out arrParams);
                    arrParams[0].Value = p_strHandlersID;
                    arrParams[1].Value = p_strHandlers;
                    arrParams[2].Value = order.m_strOrderID;
                    lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);

                    strSql = @"	
        				update T_Opr_Bih_Order
        				set OPERATION_INT=1
        				where
                        REGISTERID_CHR=?
        			    ";
                    System.Data.IDataParameter[] arrParams2 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out arrParams2);
                    arrParams2[0].Value = order.m_strRegisterID;

                    lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams2);
                    objHRPSvc.Dispose();
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

        #region 插入出院医嘱（医嘱输入界面）
        /// <summary>
        ///插入出院医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <param name="p_strHandlersID">操作人ID</param>
        /// <param name="p_strHandlers">操作人名称</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertOutHisOrder(clsBIHOrder order, string p_strHandlersID, string p_strHandlers, bool m_blAuto)
        {
            long lngAff = 0;
            long lngRes = 0;
            try
            {
                string p_strRecordID = "";
                lngRes = m_lngAddNewOrderNotSubAdd(out p_strRecordID, order);
                if (lngRes > 0)
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    string strSql = @"	
				update T_Opr_Bih_Order
				set Status_Int = 3 , StoperID_Chr=? , Stoper_Chr = ? ,StopDate_Dat =sysdate,FINISHDATE_DAT =sysdate
				where
                ORDERID_CHR=?
                and EXECUTETYPE_INT=1
			   ";
                    System.Data.IDataParameter[] arrParams = null;
                    objHRPSvc.CreateDatabaseParameter(3, out arrParams);
                    arrParams[0].Value = p_strHandlersID;
                    arrParams[1].Value = p_strHandlers;
                    arrParams[2].Value = order.m_strOrderID;
                    lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);
                    //出院停止所有已执行过的长嘱
                    if (lngRes > 0 && m_blAuto == true)
                    {
                        m_lngStopOrderByRegID(order.m_strRegisterID, p_strHandlersID, p_strHandlers);
                    }
                    /*<===============================*/
                    objHRPSvc.Dispose();
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
        /// <summary>
        /// 出院时自动停止当前病人所有已执行过的长期医嘱
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strHandlersID"></param>
        /// <param name="p_strHandlers"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStopOrderByRegID(string p_strRegisterID, string p_strHandlersID, string p_strHandlers)
        {

            long lngRes = 0;
            long lngAff = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                //同步更新执行单表
                string strSql = @"	
			    update T_Opr_Bih_Order
			    set OPERATION_INT=1
			    where
                EXECUTETYPE_INT=1
                and
                REGISTERID_CHR=?
		        ";

                System.Data.IDataParameter[] arrParams3 = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams3);
                arrParams3[0].Value = p_strRegisterID;

                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams3);
                //同步更新执行单表
                strSql = @"
			    update t_opr_bih_orderexecute b
                set b.executedate_vchr='已停止'
                where
                b.orderid_chr in (
                select a.orderid_chr from  T_Opr_Bih_Order a
				where
                a.status_int =2
                and a.EXECUTETYPE_INT=1
                and a.REGISTERID_CHR=?)";

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strRegisterID;

                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);


                strSql = @"	
			    update T_Opr_Bih_Order
			    set Status_Int = 3 , StoperID_Chr=?, Stoper_Chr =? ,StopDate_Dat =sysdate,FINISHDATE_DAT =sysdate,OPERATION_INT=1
			    where
                status_int =2
                and EXECUTETYPE_INT=1
                and   REGISTERID_CHR=?
		        ";
                System.Data.IDataParameter[] arrParams2 = null;
                objHRPSvc.CreateDatabaseParameter(3, out arrParams2);
                arrParams2[0].Value = p_strHandlersID;
                arrParams2[1].Value = p_strHandlers;
                arrParams2[2].Value = p_strRegisterID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams2);

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

        #region 通过医嘱单记录添加收费项目到住院诊疗项目收费项目执行客户表(T_OPR_BIH_ORDERCHARGEDEPT)
        /// <summary> 
        /// 医嘱VO  收费项目到住院诊疗项目收费项目执行客户表
        /// </summary>
        /// <param name="order"></param>
        [AutoComplete]
        public void ExecOrderToChargeItem(clsBIHOrder order)
        {
            //保存新开医嘱状态下的检验收费项目使用范围=1的收费项目名称 {0=主项目;1=所有关联主项目}
            ArrayList m_arrTest = new ArrayList();

            long lngRes = 0;
            long lngAff = 0;

            int FLAG_INT = 1;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
            string strDefaultItemID = "";  //--主收费项目ID
            decimal dmlDefaultAmount = 0;  //-一次领量
            decimal dmlDefaultDOSAGE = 0;  //-一次剂量
            int intIsRich = 0;                  //--收费项目的贵重标志
            decimal dmlAmount = 0;              //领量
            decimal SINGLEAMOUNT_DEC = 0;       //补一次的领量
            int intExecuteType = 0;             //--医嘱执行类型{执行类型{1=长期;2=临时;3=出院带药}}
            string strCalcCateID = "";          //--项目住院核算类别
            string strINvCateID = "";           //--项目住院发票类别
            decimal dmlPrice = 0;          //--住院单价(=项目价格/包装量)
            int intTimes = 0;                   //--单位频率执行的次数
            int intOUTGETMEDDAYS_INT = 1;          //出院带药天数(当执行类型=3出院带药时可用)
            string SPEC_VCHR = "";             //规格
            string Unit_Vchr = "";//住院单位
            string ItemName_Vchr = "";//收费项目名称
            string ItemID_Chr = "";//收费项目ID
            int CONTINUEUSETYPE_INT = 0;//续用类型 {0=不续用;1=全部续用;2-长嘱续用}
            string ITEMUNIT_CHR = "";//项目单位(非药品)
            string ITEMOPUNIT_CHR = "";//项目门诊单位(基本单位)
            string ItemIPUnit_Chr = "";//项目住院单位(最小单位)
            int ITEMSRCTYPE_INT = 0;//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
            string ITEMSRCID_VCHR = "";//项目源ID。是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
            int IPCHARGEFLG_INT = 0;//住院收费单位 0 －基本单位 1－最小单位
            int type_int = 0;//{1=领量单位;2=剂量单位}
            // 医保信息
            string INSURACEDESC_VCHR = "";
            string CONTINUEFREQID_CHR = "";


            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            System.Data.IDataParameter[] arrParams = null;
            DataTable dtbResult = new DataTable();
            DataTable dtbResultTest = new DataTable();

            string strSQL = "";

            intExecuteType = order.m_intExecuteType;
            dmlDefaultAmount = decimal.Parse(order.m_dmlGet.ToString());
            //一次剂量
            dmlDefaultDOSAGE = decimal.Parse(order.m_dmlDosage.ToString());
            intTimes = order.m_intFreqTime;//
            intOUTGETMEDDAYS_INT = order.m_intOUTGETMEDDAYS_INT;
            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
            if (order.RateType != 0 && order.RateType != 2)
            {
                return;
            }
            //--单位频率执行的次数
            if (intTimes == 0)
            {
                intTimes = 1;
            }
            #region 对于检验进行特殊的处理
            /*  检验在输入多个检验医嘱时带出收费项目不正确，主要是没有考虑到各个收费项目的使用范围的标志位，例如开两个项目只需要一个静脉抽血，而目前依然带出两个静脉抽血。 */

            if (order.m_strOrderDicCateName.Trim().Equals("检验"))
            {
                strSQL = @"
                        select distinct c.itemid_chr from
                        t_opr_bih_order a,
                        t_bse_bih_orderdic b,
                        T_Aid_Bih_OrderDic_Charge c
                        where
                        a.orderdicid_chr=b.orderdicid_chr
                        and
                        b.orderdicid_chr=c.orderdicid_chr
                        and
                        b.ordercateid_chr=?
                        and
                        c.usescope_int=1
                        and
                        a.creatorid_chr=?
                        and
                        a.orderid_chr!=?
                        and
                        a.REGISTERID_CHR=?
                        and
                        a.status_int=0
                         ";
                objHRPSvc.CreateDatabaseParameter(4, out arrParams);
                arrParams[0].Value = order.m_strOrderDicCateID;
                arrParams[1].Value = order.m_strCreatorID;
                arrParams[2].Value = order.m_strOrderID;
                arrParams[3].Value = order.m_strRegisterID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResultTest, arrParams);
                for (int i = 0; i < dtbResultTest.Rows.Count; i++)
                {
                    m_arrTest.Add(dtbResultTest.Rows[i]["itemid_chr"].ToString());
                }
            }
            #endregion

            // 加上是否摆药及医保信息

            strSQL = @"select c.ITEMID_CHR DefaultItemID,
                               A.ItemID_Chr,
                               A.QTY_INT,
                               A.type_int,
                               A.CONTINUEUSETYPE_INT,
                               A.CONTINUEFREQID_CHR,
                               B.ITEMUNIT_CHR,
                               B.ITEMOPUNIT_CHR,
                               B.ItemIPUnit_Chr,
                               B.ItemName_Vchr,
                               B.ITEMSRCTYPE_INT,
                               B.ITEMSRCID_VCHR,
                               decode(b.IPCHARGEFLG_INT,
                                      1,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4),
                                      0,
                                      B.ItemPrice_Mny,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4)) ItemPriceA,
                               B.ItemIPCalcType_Chr,
                               B.ItemIpInvType_Chr,
                               B.IsRich_Int,
                               B.DOSAGE_DEC,
                               B.ITEMSPEC_VCHR,
                               B.IPCHARGEFLG_INT,
                               g.POFLAG_INT,
                               h.typename_vchr MedicareTypeName,
                               A.USESCOPE_INT
                          from T_Aid_Bih_OrderDic_Charge A,
                               T_Bse_ChargeItem          B,
                               t_bse_bih_orderdic        c,
                               T_BSE_MEDICINE            g,
                               T_AID_MEDICARETYPE        h
                         where a.OrderDicID_Chr = ?
                           and A.ItemID_Chr = B.ItemID_Chr
                           and a.orderdicid_chr = c.orderdicid_chr
                           and b.ITEMSRCID_VCHR = g.medicineid_chr(+)
                           and b.INPINSURANCETYPE_VCHR = h.typeid_chr(+)
                         order by B.ITEMCODE_VCHR ";


            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = order.m_strOrderDicID;
            DataTable dtbResult2 = new DataTable();
            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult2, arrParams);
            if (lngRes > 0 && dtbResult2.Rows.Count > 0)
            {
                for (int i = 0; i < dtbResult2.Rows.Count; i++)
                {

                    // --获取收费项目的贵重标志
                    intIsRich = clsConverter.ToInt(dtbResult2.Rows[i]["IsRich_Int"].ToString());
                    ItemID_Chr = clsConverter.ToString(dtbResult2.Rows[i]["ItemID_Chr"].ToString());
                    strDefaultItemID = clsConverter.ToString(dtbResult2.Rows[i]["DefaultItemID"].ToString());
                    CONTINUEUSETYPE_INT = clsConverter.ToInt(dtbResult2.Rows[i]["CONTINUEUSETYPE_INT"].ToString());

                    /*检验在输入多个检验医嘱时带出收费项目不正确，主要是没有考虑到各个收费项目的使用范围的标志位，例如开两个项目只需要一个静脉抽血，而目前依然带出两个静脉抽血。 */
                    if (m_arrTest.Contains(ItemID_Chr))
                    {
                        continue;
                    }
                    /*<======================*/

                    ItemName_Vchr = clsConverter.ToString(dtbResult2.Rows[i]["ItemName_Vchr"].ToString());
                    ITEMUNIT_CHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMUNIT_CHR"].ToString());//项目单位(非药品)
                    ITEMOPUNIT_CHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMOPUNIT_CHR"].ToString());//项目门诊单位(基本单位)
                    ItemIPUnit_Chr = clsConverter.ToString(dtbResult2.Rows[i]["ItemIPUnit_Chr"].ToString());//项目住院单位(最小单位)
                    ITEMSRCTYPE_INT = clsConverter.ToInt(dtbResult2.Rows[i]["ITEMSRCTYPE_INT"].ToString());//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
                    ITEMSRCID_VCHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMSRCID_VCHR"].ToString());//项目源ID。是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
                    IPCHARGEFLG_INT = clsConverter.ToInt(dtbResult2.Rows[i]["IPCHARGEFLG_INT"].ToString());//住院收费单位 0 －基本单位 1－最小单位

                    type_int = clsConverter.ToInt(dtbResult2.Rows[i]["type_int"].ToString());


                    int Qty_Int = clsConverter.ToInt(dtbResult2.Rows[i]["Qty_Int"].ToString());
                    decimal DOSAGE_DEC = clsConverter.ToDecimal(dtbResult2.Rows[i]["DOSAGE_DEC"].ToString());
                    //     --设置项目住院核算类别
                    strCalcCateID = clsConverter.ToString(dtbResult2.Rows[i]["ItemIPCalcType_Chr"].ToString());
                    //     --设置项目住院发票类别
                    strINvCateID = clsConverter.ToString(dtbResult2.Rows[i]["ItemIpInvType_Chr"].ToString());
                    //    --设置住院单价(=项目价格/包装量)
                    dmlPrice = clsConverter.ToDecimal(dtbResult2.Rows[i]["ItemPriceA"].ToString());
                    //规格
                    SPEC_VCHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMSPEC_VCHR"].ToString());
                    //是否摆药的标志从药品字典表中的“是否进入医嘱”中取出
                    int POFLAG_INT = clsConverter.ToInt(dtbResult2.Rows[i]["POFLAG_INT"].ToString());

                    // 医保信息
                    INSURACEDESC_VCHR = clsConverter.ToString(dtbResult2.Rows[i]["MedicareTypeName"].ToString().Trim());
                    CONTINUEFREQID_CHR = clsConverter.ToString(dtbResult2.Rows[i]["CONTINUEFREQID_CHR"].ToString().Trim());

                    //设置领量单位
                    if (ITEMSRCTYPE_INT == 1 && !ITEMSRCID_VCHR.Trim().Equals(""))//药品
                    {
                        if (IPCHARGEFLG_INT == 0)//住院收费单位 0 －基本单位 1－最小单位
                        {
                            Unit_Vchr = ITEMOPUNIT_CHR;
                        }
                        else
                        {
                            Unit_Vchr = ItemIPUnit_Chr;
                        }
                    }
                    else
                    {
                        Unit_Vchr = ITEMUNIT_CHR;
                    }
                    //--设置领量
                    if (ItemID_Chr.Equals(strDefaultItemID))
                    {
                        FLAG_INT = 0;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开                            
                        dmlAmount = dmlDefaultAmount;//--住收费项目
                        if (intExecuteType == 3)
                        {

                            dmlAmount = dmlAmount * intOUTGETMEDDAYS_INT;//领量＊天数
                        }
                        SINGLEAMOUNT_DEC = order.m_dmlOneUse;
                    }
                    else
                    {
                        //--计算非主收费项目的收费
                        /*
                         *业务描述：
                         *    if(TYPE_INT==1[领量单位]) then {=次数*领量}
                         *    if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目；医生下的剂量是默认的那个}
                         *       领量 = 周期用药次数 * 用量
                         *       用量 = 医生下的剂量/单位剂量
                         */
                        if (type_int == 1)
                        {
                            dmlAmount = intTimes * Qty_Int;
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = Qty_Int;
                        }
                        else
                        {
                            dmlAmount = intTimes * (Qty_Int / DOSAGE_DEC);
                            // 补一次的领量  
                            SINGLEAMOUNT_DEC = decimal.Ceiling(Qty_Int / DOSAGE_DEC);
                        }
                        if (intExecuteType == 3)
                        {
                            dmlAmount = dmlAmount * intOUTGETMEDDAYS_INT;//领量＊天数
                        }

                        FLAG_INT = 1;


                    }

                    // 获取收费项目对应的申请/执行科室
                    DataTable dtbResult3 = new DataTable();

                    string CLACAREA_CHR = "";//执行科室
                    strSQL = @"
                        select
                        b.CLACAREA_CHR,
                        c.CLACAREA_CHR CLACAREA_CHR2
                        from 
                        T_BSE_CHARGEITEM a,
                        (select ordercateid_chr,CLACAREA_CHR from t_aid_bih_ocdeptdefault where createarea_chr=?) b,
                        t_aid_bih_ocdeptlist c
                        where
                        a.ordercateid_chr=b.ordercateid_chr(+)
                        and
                        a.ordercateid_chr=c.ordercateid_chr(+)
                        and
                        rownum=1
                        and
                        a.itemid_chr=?
                        ";

                    objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                    arrParams[0].Value = order.m_strCREATEAREA_ID;
                    arrParams[1].Value = ItemID_Chr;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult3, arrParams);
                    if (lngRes > 0 && dtbResult3.Rows.Count > 0)
                    {
                        CLACAREA_CHR = clsConverter.ToString(dtbResult3.Rows[0]["CLACAREA_CHR"].ToString());
                        if (CLACAREA_CHR.Trim().Equals(""))
                        {
                            CLACAREA_CHR = clsConverter.ToString(dtbResult3.Rows[0]["CLACAREA_CHR2"].ToString());
                        }
                        if (CLACAREA_CHR.Trim().Equals(""))//都不存在时，用医嘱的开单科室
                        {
                            CLACAREA_CHR = order.m_strCREATEAREA_ID;
                        }
                    }
                    /*<----------------------------------------------------------*/


                    //    --插入费用明细记录
                    strSQL = @"
                        insert into T_OPR_BIH_ORDERCHARGEDEPT(                 
                        SEQ_INT,     ORDERID_CHR,   ORDERDICID_CHR,    CHARGEITEMID_CHR,
                        CLACAREA_CHR,CREATEAREA_CHR,CHARGEITEMNAME_CHR,SPEC_VCHR,
                        UNIT_VCHR,   AMOUNT_DEC,    UNITPRICE_DEC,     CREATORID_CHR,
                        CREATOR_VCHR,CREATEDATE_DAT,FLAG_INT,       SINGLEAMOUNT_DEC,
                        POFLAG_INT,RATETYPE_INT,INSURACEDESC_VCHR,CONTINUEUSETYPE_INT,
                        CONTINUEFREQID_CHR)
                        values
                        (
                        SEQ_PUBLIC.NEXTVAL,?,?,?,
                        ?,?,?,?,
                        ?,?,?,?,
                        ?,sysdate,?,?,
                        ?,?,?,?,
                        ?
                        )
                        ";
                    int n = -1;
                    objHRPSvc.CreateDatabaseParameter(19, out arrParams);
                    n++; arrParams[n].Value = order.m_strOrderID;//strOrderID;
                    n++; arrParams[n].Value = order.m_strOrderDicID;//strDicID;
                    n++; arrParams[n].Value = ItemID_Chr;

                    n++; arrParams[n].Value = CLACAREA_CHR;
                    n++; arrParams[n].Value = order.m_strCREATEAREA_ID;
                    n++; arrParams[n].Value = ItemName_Vchr;
                    n++; arrParams[n].Value = SPEC_VCHR;

                    n++; arrParams[n].Value = Unit_Vchr;//Unit_Vchr 住院单位{=收费项目.住院单位}
                    n++; arrParams[n].Value = dmlAmount;//AMount_Dec    领量
                    n++; arrParams[n].Value = dmlPrice;//UnitPrice_Dec  住院单价{=收费项目.住院单价}
                    n++; arrParams[n].Value = order.m_strCreatorID;//CREATORID_CHR;

                    n++; arrParams[n].Value = order.m_strCreator;//CREATOR_VCHR; 
                    n++; arrParams[n].Value = FLAG_INT;//FLAG_INT 创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
                    n++; arrParams[n].Value = SINGLEAMOUNT_DEC;//补一次的领量 
                    n++; arrParams[n].Value = POFLAG_INT;//是否摆药 0-不摆药 1-摆药
                    n++; arrParams[n].Value = 1;//是否计费 0-不计费 1-计费
                    n++; arrParams[n].Value = INSURACEDESC_VCHR;//医保信息
                    n++; arrParams[n].Value = CONTINUEUSETYPE_INT;//续用类型 {0=不续用;1=全部续用;2-长嘱续用}

                    n++; arrParams[n].Value = CONTINUEFREQID_CHR;//续用类型为连续用时,采用的频率ID 
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams);


                }
            }


            objHRPSvc.Dispose();

        }
        #endregion

        #region 通过医嘱单记录添加收费项目记录用法到住院诊疗项目收费项目执行客户表(T_OPR_BIH_ORDERCHARGEDEPT)
        /// <summary>
        /// 医嘱VO   用法到住院诊疗项目收费项目执行客户表
        /// </summary>
        /// <param name="order"></param>
        [AutoComplete]
        public void UsageToChargeItem(clsBIHOrder order)
        {

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            System.Data.IDataParameter[] arrParams = null;
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            long lngAff = 0;

            int FLAG_INT = 2;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
            // --补登:{1=计费-摆药;2=计费-不摆药;3=不计费-摆药;4=不计费-不摆药};只用于临时医嘱
            int intIsRich;       //       --收费项目的贵重标志
            string strChargeID;
            decimal dmlAmount;//     --量
            decimal SINGLEAMOUNT_DEC = 0;       //补一次的领量
            string strCalcCateID;//      --项目住院核算类别
            string strInvCateID;//       --项目住院发票类别
            int intTimes;//               --单位频率执行的次数
            int intTimesBak;//            --单位频率执行的次数
            string Unit_Vchr = "";//住院单位
            string ITEMUNIT_CHR = "";//项目单位(非药品)
            string ITEMOPUNIT_CHR = "";//项目门诊单位(基本单位)
            string ItemIPUnit_Chr = "";//项目住院单位(最小单位)
            int ITEMSRCTYPE_INT = 0;//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
            string ITEMSRCID_VCHR = "";//项目源ID。是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
            int IPCHARGEFLG_INT = 0;//住院收费单位 0 －基本单位 1－最小单位

            // 医保信息
            string INSURACEDESC_VCHR = "";
            string ItemName_Vchr = "";//收费项目名称

            decimal dblBihqty;
            decimal dblDosage;
            string SPEC_VCHR = "";             //规格
            DateTime CREATEDATE_DAT = DateTime.Now; //创建时间

            string strUsageID = "";            //用法ID 
            string strSQL = "";

            intTimes = order.m_intFreqTime;
            strUsageID = order.m_strDosetypeID;
            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
            if (order.RateType == 0 || order.RateType == 1 || order.RateType == 2)
            {
            }
            else
            {
                return;
            }
            if (intTimes == 0)
            {
                intTimes = 1;
            }
            strSQL = @"select A.ItemID_Chr,
                               A.BIHQTY_DEC,
                               A.BIHTYPE_INT,
                               A.ContinueUseType_Int,
                               B.ItemName_Vchr,
                               B.DOSAGE_DEC,
                               decode(b.IPCHARGEFLG_INT,
                                      0,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4),
                                      1,
                                      B.ItemPrice_Mny,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4)) ItemPriceA,
                               B.ItemIPCalcType_Chr,
                               B.ItemIpInvType_Chr,
                               B.IsRich_Int,
                               B.ITEMSPEC_VCHR,
                               B.IPCHARGEFLG_INT,
                               B.ITEMUNIT_CHR,
                               B.ITEMOPUNIT_CHR,
                               B.ItemIPUnit_Chr,
                               B.ITEMSRCTYPE_INT,
                               B.ITEMSRCID_VCHR,
                               g.POFLAG_INT,
                               h.typename_vchr MedicareTypeName
                          from T_BSE_ChargeItemUsageGroup A,
                               T_Bse_ChargeItem           B,
                               T_BSE_MEDICINE             g,
                               T_AID_MEDICARETYPE         h
                         where A.UsageID_Chr = ?
                           and A.ItemID_Chr = B.ItemID_Chr
                           and b.ITEMSRCID_VCHR = g.medicineid_chr(+)
                           and b.INPINSURANCETYPE_VCHR = h.typeid_chr(+)
                         order by B.ITEMCODE_VCHR";
            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = strUsageID;
            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);

            if (lngRes > 0)
            {
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                {

                    int CONTINUEUSETYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["ContinueUseType_Int"].ToString());
                    string ItemID_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemID_Chr"].ToString());
                    decimal BIHQTY_DEC = clsConverter.ToDecimal(dtbResult.Rows[i]["BIHQTY_DEC"].ToString());
                    decimal DOSAGE_DEC = clsConverter.ToDecimal(dtbResult.Rows[i]["DOSAGE_DEC"].ToString());
                    int BIHTYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["BIHTYPE_INT"].ToString());
                    string ItemIpInvType_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemIpInvType_Chr"].ToString());
                    ItemName_Vchr = clsConverter.ToString(dtbResult.Rows[i]["ItemName_Vchr"].ToString());

                    ITEMUNIT_CHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMUNIT_CHR"].ToString());//项目单位(非药品)
                    ITEMOPUNIT_CHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMOPUNIT_CHR"].ToString());//项目门诊单位(基本单位)
                    ItemIPUnit_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemIPUnit_Chr"].ToString());//项目住院单位(最小单位)
                    ITEMSRCTYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["ITEMSRCTYPE_INT"].ToString());//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
                    ITEMSRCID_VCHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMSRCID_VCHR"].ToString());//项目源ID。是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
                    IPCHARGEFLG_INT = clsConverter.ToInt(dtbResult.Rows[i]["IPCHARGEFLG_INT"].ToString());//住院收费单位 0 －基本单位 1－最小单位


                    decimal ItemPriceA = clsConverter.ToDecimal(dtbResult.Rows[i]["ItemPriceA"].ToString());
                    //规格
                    SPEC_VCHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMSPEC_VCHR"].ToString());

                    //是否摆药的标志从药品字典表中的“是否进入医嘱”中取出
                    int POFLAG_INT = clsConverter.ToInt(dtbResult.Rows[i]["POFLAG_INT"].ToString());
                    // 医保信息
                    INSURACEDESC_VCHR = clsConverter.ToString(dtbResult.Rows[i]["MedicareTypeName"].ToString().Trim());


                    intIsRich = clsConverter.ToInt(dtbResult.Rows[i]["IsRich_Int"].ToString());
                    intTimesBak = intTimes;

                    // --计算用法领量
                    /*
                    *业务描述：
                    *    if(TYPE_INT==1[领量单位]) then {=次数*领量}
                    *    if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目；医生下的剂量是默认的那个}
                    *       领量 = 周期用药次数 * 用量
                    *       用量 = 医生下的剂量/单位剂量
                    */
                    /*
                    */
                    if (BIHQTY_DEC == 0)
                    {
                        //dblBihqty = 1;
                        continue;//数量为0时不进行处理
                    }
                    else
                    {
                        dblBihqty = BIHQTY_DEC;
                    }
                    if (DOSAGE_DEC == 0)
                    {
                        dblDosage = 1;
                    }
                    else
                    {
                        dblDosage = DOSAGE_DEC;
                    }
                    //设置领量单位
                    if (ITEMSRCTYPE_INT == 1 && !ITEMSRCID_VCHR.Trim().Equals(""))//药品
                    {
                        if (IPCHARGEFLG_INT == 0)//住院收费单位 0 －基本单位 1－最小单位
                        {
                            Unit_Vchr = ITEMOPUNIT_CHR;
                        }
                        else
                        {
                            Unit_Vchr = ItemIPUnit_Chr;
                        }
                    }
                    else
                    {
                        Unit_Vchr = ITEMUNIT_CHR;
                    }

                    if (BIHTYPE_INT == 1)
                    {
                        if (CONTINUEUSETYPE_INT == 0)//续用
                        {
                            dmlAmount = intTimes * dblBihqty;
                        }
                        else
                        {
                            dmlAmount = dblBihqty;
                        }
                        // 补一次的领量 
                        SINGLEAMOUNT_DEC = dblBihqty;
                    }
                    else
                    {
                        if (CONTINUEUSETYPE_INT == 0)//续用
                        {
                            dmlAmount = intTimes * (dblBihqty / dblDosage);
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = decimal.Ceiling(dblBihqty / dblDosage);
                        }
                        else
                        {
                            dmlAmount = dblBihqty;
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = dblBihqty;
                        }
                    }
                    strCalcCateID = ItemIpInvType_Chr;
                    strInvCateID = ItemIpInvType_Chr;

                    // 获取收费项目对应的申请/执行科室
                    DataTable dtbResult3 = new DataTable();

                    string CLACAREA_CHR = "";//执行科室
                    strSQL = @"
                        select
                        b.CLACAREA_CHR,
                        c.CLACAREA_CHR CLACAREA_CHR2
                        from 
                        T_BSE_CHARGEITEM a,
                        (select ordercateid_chr,CLACAREA_CHR from t_aid_bih_ocdeptdefault where createarea_chr=?) b,
                        t_aid_bih_ocdeptlist c
                        where
                        a.ordercateid_chr=b.ordercateid_chr(+)
                        and
                        a.ordercateid_chr=c.ordercateid_chr(+)
                        and
                        rownum=1
                        and
                        a.itemid_chr=?
                        ";


                    objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                    arrParams[0].Value = order.m_strCREATEAREA_ID;
                    arrParams[1].Value = ItemID_Chr;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult3, arrParams);
                    if (lngRes > 0 && dtbResult3.Rows.Count > 0)
                    {
                        CLACAREA_CHR = clsConverter.ToString(dtbResult3.Rows[0]["CLACAREA_CHR"].ToString());
                        if (CLACAREA_CHR.Trim().Equals(""))
                        {
                            CLACAREA_CHR = clsConverter.ToString(dtbResult3.Rows[0]["CLACAREA_CHR2"].ToString());
                        }
                        if (CLACAREA_CHR.Trim().Equals(""))//都不存在时，用医嘱的开单科室
                        {
                            CLACAREA_CHR = order.m_strCREATEAREA_ID;
                        }
                    }
                    /*<----------------------------------------------------------*/

                    //    --插入费用明细记录
                    strSQL = @"
                        insert into T_OPR_BIH_ORDERCHARGEDEPT(                 
                        SEQ_INT,     ORDERID_CHR,   ORDERDICID_CHR,    CHARGEITEMID_CHR,
                        CLACAREA_CHR,CREATEAREA_CHR,CHARGEITEMNAME_CHR,SPEC_VCHR,
                        UNIT_VCHR,   AMOUNT_DEC,    UNITPRICE_DEC,     CREATORID_CHR,
                        CREATOR_VCHR,CREATEDATE_DAT,FLAG_INT,        SINGLEAMOUNT_DEC,
                        POFLAG_INT,RATETYPE_INT,INSURACEDESC_VCHR,CONTINUEUSETYPE_INT)
                        values
                        (
                        SEQ_PUBLIC.NEXTVAL,?,?,?,
                        ?,?,?,?,
                        ?,?,?,?,
                        ?,sysdate,?,?,
                        ?,?,?,?
                        )
                        ";
                    int n = -1;
                    objHRPSvc.CreateDatabaseParameter(18, out arrParams);
                    n++; arrParams[n].Value = order.m_strOrderID;
                    n++; arrParams[n].Value = order.m_strOrderDicID;
                    n++; arrParams[n].Value = ItemID_Chr;

                    n++; arrParams[n].Value = CLACAREA_CHR;
                    n++; arrParams[n].Value = order.m_strCREATEAREA_ID;
                    n++; arrParams[n].Value = ItemName_Vchr;
                    n++; arrParams[n].Value = SPEC_VCHR.Trim();

                    n++; arrParams[n].Value = Unit_Vchr;//Unit_Vchr 住院单位{=收费项目.住院单位}
                    n++; arrParams[n].Value = dmlAmount;//AMount_Dec    不续用领量（取医嘱的领量）
                    n++; arrParams[n].Value = ItemPriceA;//UnitPrice_Dec  住院单价{=收费项目.住院单价}
                    n++; arrParams[n].Value = order.m_strCreatorID;

                    n++; arrParams[n].Value = order.m_strCreator;
                    n++; arrParams[n].Value = FLAG_INT;//FLAG_INT 创建标志:收费项来源于 0-诊疗项目，1－带出的用法，2－自定义新开
                    n++; arrParams[n].Value = SINGLEAMOUNT_DEC;//补一次的领量

                    n++; arrParams[n].Value = POFLAG_INT;//是否摆药 0-不摆药 1-摆药
                    n++; arrParams[n].Value = 1;//是否计费 0-不计费 1-计费
                    n++; arrParams[n].Value = INSURACEDESC_VCHR;//医保信息
                    n++; arrParams[n].Value = CONTINUEUSETYPE_INT;//续用类型 {0=不续用;1=全部续用;2-长嘱续用} 
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams);

                }
            }
        }
        #endregion


        #region 通过医嘱单记录添加收费项目到住院诊疗项目收费项目执行客户表(T_OPR_BIH_ORDERCHARGEDEPT)
        /// <summary>
        /// 通过医嘱单记录添加收费项目到住院诊疗项目收费项目执行客户表(T_OPR_BIH_ORDERCHARGEDEPT)
        /// </summary>
        /// <param name="order">医嘱vo</param>
        /// <param name="m_arrORDERCHARGEDEPT"></param>
        [AutoComplete]
        public void ExecOrderToChargeItem(clsBIHOrder order, ref ArrayList m_arrORDERCHARGEDEPT)
        {
            //保存新开医嘱状态下的检验收费项目使用范围=1的收费项目名称 {0=主项目;1=所有关联主项目}
            ArrayList m_arrTest = new ArrayList();
            //clsORDERCHARGEDEPT_VO 
            long lngRes = 0;
            long lngAff = 0;

            //int FLAG2_INT = 0;//控制诊疗项目对应关联收费项目（一对多）是否摆药',  '0-不摆药 1-摆药'
            int FLAG_INT = 1;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
            string strDefaultItemID = "";  //--主收费项目ID
            decimal dmlDefaultAmount = 0;  //-一次领量
            decimal dmlDefaultDOSAGE = 0;  //-一次剂量
            int intIsRich = 0;                  //--收费项目的贵重标志
            decimal dmlAmount = 0;              //领量
            decimal SINGLEAMOUNT_DEC = 0;       //补一次的领量
            int intExecuteType = 0;             //--医嘱执行类型{执行类型{1=长期;2=临时;3=出院带药}}
            string strCalcCateID = "";          //--项目住院核算类别
            string strINvCateID = "";           //--项目住院发票类别
            decimal dmlPrice = 0;          //--住院单价(=项目价格/包装量)
            int intTimes = 0;                   //--单位频率执行的次数
            int intOUTGETMEDDAYS_INT = 1;          //出院带药天数(当执行类型=3出院带药时可用)
            string SPEC_VCHR = "";             //规格
            string Unit_Vchr = "";//住院单位
            string ItemName_Vchr = "";//收费项目名称
            string ItemID_Chr = "";//收费项目ID
            int CONTINUEUSETYPE_INT = 0;//续用类型 {0=不续用;1=全部续用;2-长嘱续用}
            string ITEMUNIT_CHR = "";//项目单位(非药品)
            string ITEMOPUNIT_CHR = "";//项目门诊单位(基本单位)
            string ItemIPUnit_Chr = "";//项目住院单位(最小单位)
            int ITEMSRCTYPE_INT = 0;//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
            string ITEMSRCID_VCHR = "";//项目源ID。是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
            int IPCHARGEFLG_INT = 0;//住院收费单位 0 －基本单位 1－最小单位
            int type_int = 0;//{1=领量单位;2=剂量单位}
            // 医保信息
            string INSURACEDESC_VCHR = "";
            string CONTINUEFREQID_CHR = "";
            string ORDERCATEID_LIS_CHR = "";//检验配置标识
            int CHANGETYPE_INT = 2;//医嘱类型 是否随主项量变{1/2}
            decimal m_decNewCount = 1;//医嘱类型 是否随主项量变{1/2} 如果=1，副助收费项目将剩以（主项目剂量/原剂量）

            int intMEDICINETYPEID = 0;//药品类型，中药，西药还是材料-1为西药，2为中药
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            System.Data.IDataParameter[] arrParams = null;
            DataTable dtbResult = new DataTable();
            DataTable dtbResultTest = new DataTable();

            string strSQL = "";

            intExecuteType = order.m_intExecuteType;
            dmlDefaultAmount = decimal.Parse(order.m_dmlGet.ToString());
            //一次剂量
            dmlDefaultDOSAGE = decimal.Parse(order.m_dmlDosage.ToString());
            intTimes = order.m_intFreqTime;//
            intOUTGETMEDDAYS_INT = order.m_intOUTGETMEDDAYS_INT;
            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
            if (order.RateType != 0 && order.RateType != 2)
            {
                return;
            }

            // 加上是否摆药及医保信息
            strSQL = @"select c.itemid_chr defaultitemid,
                               a.itemid_chr,
                               a.qty_int,
                               a.type_int,
                               a.continueusetype_int,
                               a.continuefreqid_chr,
                               b.itemunit_chr,
                               b.itemopunit_chr,
                               b.itemipunit_chr,
                               b.itemname_vchr,
                               b.itemsrctype_int,
                               b.itemsrcid_vchr,
                               decode(b.ipchargeflg_int,
                                      1,
                                      round(b.itemprice_mny / b.packqty_dec, 4),
                                      0,
                                      b.itemprice_mny,
                                      round(b.itemprice_mny / b.packqty_dec, 4)) itempricea,
                               b.itemipcalctype_chr,
                               b.itemipinvtype_chr,
                               b.isrich_int,
                               b.dosage_dec,
                               b.itemspec_vchr,
                               b.ipchargeflg_int,
                               b.packqty_dec,
                               g.putmedtype_int poflag_int,
                               h.typename_vchr medicaretypename,
                               a.usescope_int,
                               k.times_int,
                               c.ordercateid_chr ordercateid_lis_chr,
                               m.changetype_int
                          from t_aid_bih_orderdic_charge a,
                               t_bse_chargeitem          b,
                               t_bse_bih_orderdic        c,
                               t_bse_bih_specordercate   d,
                               t_bse_medicine            g,
                               t_aid_medicaretype        h,
                               t_aid_recipefreq          k,
                               t_aid_bih_ordercate       m
                         where a.itemid_chr = b.itemid_chr
                           and a.orderdicid_chr = c.orderdicid_chr
                           and b.itemsrcid_vchr = g.medicineid_chr(+)
                           and b.inpinsurancetype_vchr = h.typeid_chr(+)
                           and a.continuefreqid_chr = k.freqid_chr(+)
                           and c.ordercateid_chr = d.ordercateid_lis_chr(+)
                           and c.ordercateid_chr = m.ordercateid_chr(+)
                           and a.orderdicid_chr = ?
                         order by b.itemcode_vchr";

            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = order.m_strOrderDicID;
            DataTable dtbResult2 = new DataTable();
            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult2, arrParams);
            if (lngRes > 0 && dtbResult2.Rows.Count > 0)
            {
                for (int i = 0; i < dtbResult2.Rows.Count; i++)
                {

                    //ORDERCATEID_LIS_CHR
                    #region 对于检验进行特殊的处理
                    /*  检验在输入多个检验医嘱时带出收费项目不正确，主要是没有考虑到各个收费项目的使用范围的标志位，例如开两个项目只需要一个静脉抽血，而目前依然带出两个静脉抽血。 */
                    if (i == 0)
                    {
                        ORDERCATEID_LIS_CHR = dtbResult2.Rows[i]["ORDERCATEID_LIS_CHR"].ToString().Trim();

                        if (!ORDERCATEID_LIS_CHR.Equals(""))
                        {
                            strSQL = @"select distinct c.itemid_chr
                                          from t_opr_bih_order a, t_bse_bih_orderdic b, T_Aid_Bih_OrderDic_Charge c
                                         where a.orderdicid_chr = b.orderdicid_chr
                                           and b.orderdicid_chr = c.orderdicid_chr
                                           and b.ordercateid_chr = ?
                                           and c.usescope_int = 1
                                           and a.creatorid_chr = ?
                                           and a.orderid_chr <> ?
                                           and a.registerid_chr = ?
                                           and a.status_int = 0";
                            System.Data.IDataParameter[] arrParams2 = null;
                            objHRPSvc.CreateDatabaseParameter(4, out arrParams2);
                            arrParams2[0].Value = order.m_strOrderDicCateID;
                            arrParams2[1].Value = order.m_strCreatorID;
                            arrParams2[2].Value = order.m_strOrderID;
                            arrParams2[3].Value = order.m_strRegisterID;
                            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResultTest, arrParams2);
                            for (int j = 0; j < dtbResultTest.Rows.Count; j++)
                            {
                                m_arrTest.Add(dtbResultTest.Rows[j]["itemid_chr"].ToString());
                            }
                        }
                    }
                    #endregion

                    // 获取收费项目的贵重标志
                    intIsRich = clsConverter.ToInt(dtbResult2.Rows[i]["IsRich_Int"].ToString());
                    ItemID_Chr = clsConverter.ToString(dtbResult2.Rows[i]["ItemID_Chr"].ToString());
                    strDefaultItemID = clsConverter.ToString(dtbResult2.Rows[i]["DefaultItemID"].ToString());
                    CONTINUEUSETYPE_INT = clsConverter.ToInt(dtbResult2.Rows[i]["CONTINUEUSETYPE_INT"].ToString());

                    // 检验在输入多个检验医嘱时带出收费项目不正确，主要是没有考虑到各个收费项目的使用范围的标志位，例如开两个项目只需要一个静脉抽血，而目前依然带出两个静脉抽血。 
                    if (m_arrTest.Contains(ItemID_Chr))
                    {
                        continue;
                    }
                    ItemName_Vchr = clsConverter.ToString(dtbResult2.Rows[i]["ItemName_Vchr"].ToString());
                    ITEMUNIT_CHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMUNIT_CHR"].ToString());//项目单位(非药品)
                    ITEMOPUNIT_CHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMOPUNIT_CHR"].ToString());//项目门诊单位(基本单位)
                    ItemIPUnit_Chr = clsConverter.ToString(dtbResult2.Rows[i]["ItemIPUnit_Chr"].ToString());//项目住院单位(最小单位)
                    ITEMSRCTYPE_INT = clsConverter.ToInt(dtbResult2.Rows[i]["ITEMSRCTYPE_INT"].ToString());//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
                    ITEMSRCID_VCHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMSRCID_VCHR"].ToString());//项目源ID。是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
                    IPCHARGEFLG_INT = clsConverter.ToInt(dtbResult2.Rows[i]["IPCHARGEFLG_INT"].ToString());//住院收费单位 0 －基本单位 1－最小单位
                    int.TryParse(dtbResult2.Rows[i]["CHANGETYPE_INT"].ToString(), out CHANGETYPE_INT);
                    type_int = clsConverter.ToInt(dtbResult2.Rows[i]["type_int"].ToString());

                    decimal Qty_Int = clsConverter.ToDecimal(dtbResult2.Rows[i]["Qty_Int"].ToString());
                    decimal DOSAGE_DEC = clsConverter.ToDecimal(dtbResult2.Rows[i]["DOSAGE_DEC"].ToString());
                    if (DOSAGE_DEC == 0)
                    {
                        DOSAGE_DEC = 1;
                    }
                    //     --设置项目住院核算类别
                    strCalcCateID = clsConverter.ToString(dtbResult2.Rows[i]["ItemIPCalcType_Chr"].ToString());
                    //     --设置项目住院发票类别
                    strINvCateID = clsConverter.ToString(dtbResult2.Rows[i]["ItemIpInvType_Chr"].ToString());
                    //    --设置住院单价(=项目价格/包装量)
                    dmlPrice = clsConverter.ToDecimal(dtbResult2.Rows[i]["ItemPriceA"].ToString());
                    //规格
                    SPEC_VCHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMSPEC_VCHR"].ToString());
                    //是否摆药的标志从药品字典表中的“是否进入医嘱”中取出
                    int POFLAG_INT = clsConverter.ToInt(dtbResult2.Rows[i]["POFLAG_INT"].ToString());

                    // 医保信息
                    INSURACEDESC_VCHR = clsConverter.ToString(dtbResult2.Rows[i]["MedicareTypeName"].ToString().Trim());
                    CONTINUEFREQID_CHR = clsConverter.ToString(dtbResult2.Rows[i]["CONTINUEFREQID_CHR"].ToString().Trim());
                    if (!dtbResult2.Rows[i]["times_int"].ToString().Trim().Equals(""))
                    {
                        intTimes = clsConverter.ToInt(dtbResult2.Rows[i]["times_int"].ToString().Trim());
                    }
                    else
                    {
                        intTimes = order.m_intFreqTime;//
                    }
                    //--单位频率执行的次数
                    if (intTimes == 0)
                    {
                        intTimes = 1;
                    }
                    //设置领量单位
                    if (ITEMSRCTYPE_INT == 1 && !ITEMSRCID_VCHR.Trim().Equals(""))//药品
                    {
                        if (IPCHARGEFLG_INT == 0)//住院收费单位 0 －基本单位 1－最小单位
                        {
                            Unit_Vchr = ITEMOPUNIT_CHR;
                        }
                        else
                        {
                            Unit_Vchr = ItemIPUnit_Chr;
                        }
                    }
                    else
                    {
                        Unit_Vchr = ITEMUNIT_CHR;
                    }
                    //--设置领量
                    if (ItemID_Chr.Equals(strDefaultItemID))
                    {
                        FLAG_INT = 0;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开                            
                        dmlAmount = dmlDefaultAmount * Qty_Int;//--住收费项目

                        SINGLEAMOUNT_DEC = order.m_dmlOneUse * Qty_Int;
                        if (CHANGETYPE_INT == 1)
                        {
                            m_decNewCount = order.m_dmlDosage / DOSAGE_DEC;
                            m_decNewCount = decimal.Ceiling(m_decNewCount);
                        }
                    }
                    else
                    {
                        //--计算非主收费项目的收费
                        /*
                         *业务描述：
                         *    if(TYPE_INT==1[领量单位]) then {=次数*领量}
                         *    if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目；医生下的剂量是默认的那个}
                         *       领量 = 周期用药次数 * 用量
                         *       用量 = 医生下的剂量/单位剂量
                         */
                        if (type_int == 1)
                        {
                            dmlAmount = intTimes * Qty_Int;
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = Qty_Int;
                        }
                        else
                        {
                            dmlAmount = intTimes * (Qty_Int / DOSAGE_DEC);
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = decimal.Ceiling(Qty_Int / DOSAGE_DEC);
                        }
                        FLAG_INT = 1;
                    }

                    // 获取收费项目对应的申请/执行科室
                    string CLACAREA_CHR = order.m_strCREATEAREA_ID;//执行科室

                    clsORDERCHARGEDEPT_VO m_objDept_Vo = new clsORDERCHARGEDEPT_VO();
                    m_objDept_Vo.m_strOrderid_chr = order.m_strOrderID;//strOrderID;
                    m_objDept_Vo.m_strOrderdicid_chr = order.m_strOrderDicID;//strDicID;
                    m_objDept_Vo.m_strChargeitemid_chr = ItemID_Chr;

                    m_objDept_Vo.m_strClacarea_chr = CLACAREA_CHR;
                    m_objDept_Vo.m_strCreatearea_chr = order.m_strCREATEAREA_ID;
                    m_objDept_Vo.m_strChargeitemname_chr = ItemName_Vchr;
                    m_objDept_Vo.m_strSpec_vchr = SPEC_VCHR;

                    m_objDept_Vo.m_strUnit_vchr = Unit_Vchr;//Unit_Vchr 住院单位{=收费项目.住院单位}
                    m_objDept_Vo.m_decAmount_dec = dmlAmount;//AMount_Dec    领量
                    m_objDept_Vo.m_decUnitprice_dec = dmlPrice;//UnitPrice_Dec  住院单价{=收费项目.住院单价}
                    m_objDept_Vo.m_strCreatorid_chr = order.m_strCreatorID;//CREATORID_CHR;

                    m_objDept_Vo.m_strCreator_vchr = order.m_strCreator;//CREATOR_VCHR;
                    //n++; arrParams[n].Value = CREATEDATE_DAT;
                    m_objDept_Vo.m_intFLAG_INT = FLAG_INT;//FLAG_INT 创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
                    m_objDept_Vo.m_decSINGLEAMOUNT_DEC = SINGLEAMOUNT_DEC;//补一次的领量

                    m_objDept_Vo.m_intITEMSRCTYPE_INT = ITEMSRCTYPE_INT;
                    m_objDept_Vo.m_intMEDICNETYPE_INT = intMEDICINETYPEID;
                    m_objDept_Vo.m_dmlPackQty = clsConverter.ToDecimal(dtbResult2.Rows[i]["PackQty_Dec"].ToString());

                    m_objDept_Vo.m_intPOFLAG_INT = POFLAG_INT;//是否摆药 0-不摆药 1-摆药
                    m_objDept_Vo.m_intRATETYPE_INT = 1;//是否计费 0-不计费 1-计费
                    m_objDept_Vo.m_strINSURACEDESC_VCHR = INSURACEDESC_VCHR;//医保信息
                    m_objDept_Vo.m_intCONTINUEUSETYPE_INT = CONTINUEUSETYPE_INT;//续用类型 {0=不续用;1=全部续用;2-长嘱续用}

                    m_objDept_Vo.m_strCONTINUEFREQID_CHR = CONTINUEFREQID_CHR;//续用类型为连续用时,采用的频率ID 

                    m_arrORDERCHARGEDEPT.Add(m_objDept_Vo);
                }
                if (m_decNewCount > 1)
                {
                    for (int i = 0; i < m_arrORDERCHARGEDEPT.Count; i++)
                    {
                        if (((clsORDERCHARGEDEPT_VO)m_arrORDERCHARGEDEPT[i]).m_intFLAG_INT != 0)
                        {
                            ((clsORDERCHARGEDEPT_VO)m_arrORDERCHARGEDEPT[i]).m_decAmount_dec = ((clsORDERCHARGEDEPT_VO)m_arrORDERCHARGEDEPT[i]).m_decAmount_dec * m_decNewCount;
                        }
                    }
                }
            }
            objHRPSvc.Dispose();
        }
        #endregion

        #region 通过医嘱单记录添加收费项目记录用法到住院诊疗项目收费项目执行客户表(T_OPR_BIH_ORDERCHARGEDEPT)
        /// <summary>
        /// 医嘱VO   用法到住院诊疗项目收费项目执行客户表
        /// </summary>
        /// <param name="order">医嘱vo</param>
        /// <param name="m_arrORDERCHARGEDEPT"></param>
        [AutoComplete]
        public void UsageToChargeItem(clsBIHOrder order, ref ArrayList m_arrORDERCHARGEDEPT)
        {
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            System.Data.IDataParameter[] arrParams = null;
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            int FLAG_INT = 2;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
            // --补登:{1=计费-摆药;2=计费-不摆药;3=不计费-摆药;4=不计费-不摆药};只用于临时医嘱
            int intIsRich;       //       --收费项目的贵重标志
            decimal dmlAmount;//     --量
            decimal SINGLEAMOUNT_DEC = 0;       //补一次的领量
            string strCalcCateID;//      --项目住院核算类别
            string strInvCateID;//       --项目住院发票类别
            int intTimes;//               --单位频率执行的次数
            int intTimesBak;//            --单位频率执行的次数
            string Unit_Vchr = "";//住院单位
            string ITEMUNIT_CHR = "";//项目单位(非药品)
            string ITEMOPUNIT_CHR = "";//项目门诊单位(基本单位)
            string ItemIPUnit_Chr = "";//项目住院单位(最小单位)
            int ITEMSRCTYPE_INT = 0;//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
            string ITEMSRCID_VCHR = "";//项目源ID。是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
            int IPCHARGEFLG_INT = 0;//住院收费单位 0 －基本单位 1－最小单位
            int intMEDICINETYPEID = 0;//药品类型，中药，西药还是材料-1为西药，2为中药


            int m_intExecuteflag = 1;//住院执行科室标志
            string m_strExecDeptID = "";//指定执行科室

            // 医保信息
            string INSURACEDESC_VCHR = "";
            string ItemName_Vchr = "";//收费项目名称

            decimal dblBihqty;
            decimal dblDosage;
            string SPEC_VCHR = "";             //规格
            DateTime CREATEDATE_DAT = DateTime.Now; //创建时间

            string strUsageID = "";            //用法ID 
            string strSQL = "";

            intTimes = order.m_intFreqTime;
            strUsageID = order.m_strDosetypeID;
            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
            if (order.RateType == 0 || order.RateType == 1 || order.RateType == 2)
            {
            }
            else
            {
                return;
            }
            if (intTimes == 0)
            {
                intTimes = 1;
            }
            strSQL = @"select A.ItemID_Chr,
                               A.BIHQTY_DEC,
                               A.BIHTYPE_INT,
                               A.ContinueUseType_Int,
                               a.bihexecdeptflag_int,
                               a.bihexecdeptid_chr,
                               B.ItemName_Vchr,
                               B.DOSAGE_DEC,
                               decode(b.IPCHARGEFLG_INT,
                                      0,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4),
                                      1,
                                      B.ItemPrice_Mny,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4)) ItemPriceA,
                               B.ItemIPCalcType_Chr,
                               B.ItemIpInvType_Chr,
                               B.IsRich_Int,
                               B.ITEMSPEC_VCHR,
                               B.IPCHARGEFLG_INT,
                               B.PackQty_Dec,
                               B.ITEMUNIT_CHR,
                               B.ITEMOPUNIT_CHR,
                               B.ItemIPUnit_Chr,
                               B.ITEMSRCTYPE_INT,
                               B.ITEMSRCID_VCHR,
                               g.PUTMEDTYPE_INT POFLAG_INT,
                               g.MEDICINETYPEID_CHR,
                               h.typename_vchr MedicareTypeName
                          from T_BSE_ChargeItemUsageGroup A,
                               T_Bse_ChargeItem           B,
                               T_BSE_MEDICINE             g,
                               T_AID_MEDICARETYPE         h
                         where A.UsageID_Chr = ?
                           and A.ItemID_Chr = B.ItemID_Chr
                           and b.ITEMSRCID_VCHR = g.medicineid_chr(+)
                           and b.INPINSURANCETYPE_VCHR = h.typeid_chr(+)
                         order by B.ITEMCODE_VCHR ";
            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = strUsageID;
            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);

            if (lngRes > 0)
            {
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                {
                    int CONTINUEUSETYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["ContinueUseType_Int"].ToString());
                    string ItemID_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemID_Chr"].ToString());
                    decimal BIHQTY_DEC = clsConverter.ToDecimal(dtbResult.Rows[i]["BIHQTY_DEC"].ToString());
                    decimal DOSAGE_DEC = clsConverter.ToDecimal(dtbResult.Rows[i]["DOSAGE_DEC"].ToString());
                    int BIHTYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["BIHTYPE_INT"].ToString());
                    string ItemIpInvType_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemIpInvType_Chr"].ToString());
                    ItemName_Vchr = clsConverter.ToString(dtbResult.Rows[i]["ItemName_Vchr"].ToString());

                    ITEMUNIT_CHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMUNIT_CHR"].ToString());//项目单位(非药品)
                    ITEMOPUNIT_CHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMOPUNIT_CHR"].ToString());//项目门诊单位(基本单位)
                    ItemIPUnit_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemIPUnit_Chr"].ToString());//项目住院单位(最小单位)
                    ITEMSRCTYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["ITEMSRCTYPE_INT"].ToString());//项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
                    ITEMSRCID_VCHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMSRCID_VCHR"].ToString());//项目源ID。是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
                    IPCHARGEFLG_INT = clsConverter.ToInt(dtbResult.Rows[i]["IPCHARGEFLG_INT"].ToString());//住院收费单位 0 －基本单位 1－最小单位
                    intMEDICINETYPEID = clsConverter.ToInt(dtbResult.Rows[i]["MEDICINETYPEID_CHR"].ToString());//药品类型

                    decimal ItemPriceA = clsConverter.ToDecimal(dtbResult.Rows[i]["ItemPriceA"].ToString());
                    //规格
                    SPEC_VCHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMSPEC_VCHR"].ToString());

                    //是否摆药的标志从药品字典表中的“是否进入医嘱”中取出
                    int POFLAG_INT = clsConverter.ToInt(dtbResult.Rows[i]["POFLAG_INT"].ToString());
                    // (06-7-31)医保信息
                    INSURACEDESC_VCHR = clsConverter.ToString(dtbResult.Rows[i]["MedicareTypeName"].ToString().Trim());

                    m_intExecuteflag = clsConverter.ToInt(dtbResult.Rows[i]["bihexecdeptflag_int"].ToString().Trim());
                    m_strExecDeptID = clsConverter.ToString(dtbResult.Rows[i]["bihexecdeptid_chr"].ToString().Trim());

                    intIsRich = clsConverter.ToInt(dtbResult.Rows[i]["IsRich_Int"].ToString());
                    intTimesBak = intTimes;

                    // --计算用法领量
                    /*
                    *业务描述：
                    *    if(TYPE_INT==1[领量单位]) then {=次数*领量}
                    *    if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目；医生下的剂量是默认的那个}
                    *       领量 = 周期用药次数 * 用量
                    *       用量 = 医生下的剂量/单位剂量
                    */
                    /*
                    */
                    if (BIHQTY_DEC == 0)
                    {
                        continue;//数量为0时不进行处理
                    }
                    else
                    {
                        dblBihqty = BIHQTY_DEC;
                    }
                    if (DOSAGE_DEC == 0)
                    {
                        dblDosage = 1;
                    }
                    else
                    {
                        dblDosage = DOSAGE_DEC;
                    }
                    //设置领量单位
                    if (ITEMSRCTYPE_INT == 1 && !ITEMSRCID_VCHR.Trim().Equals(""))//药品
                    {
                        if (IPCHARGEFLG_INT == 0)//住院收费单位 0 －基本单位 1－最小单位
                        {
                            Unit_Vchr = ITEMOPUNIT_CHR;
                        }
                        else
                        {
                            Unit_Vchr = ItemIPUnit_Chr;
                        }
                    }
                    else
                    {
                        Unit_Vchr = ITEMUNIT_CHR;
                    }

                    if (BIHTYPE_INT == 1)
                    {
                        if (CONTINUEUSETYPE_INT == 0)//续用
                        {
                            dmlAmount = intTimes * dblBihqty;
                        }
                        else
                        {
                            dmlAmount = dblBihqty;
                        }
                        // 补一次的领量 
                        SINGLEAMOUNT_DEC = dblBihqty;
                    }
                    else
                    {
                        if (CONTINUEUSETYPE_INT == 0)//续用
                        {
                            dmlAmount = intTimes * (dblBihqty / dblDosage);
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = decimal.Ceiling(dblBihqty / dblDosage);
                        }
                        else
                        {
                            dmlAmount = dblBihqty;
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = dblBihqty;
                        }
                    }
                    strCalcCateID = ItemIpInvType_Chr;
                    strInvCateID = ItemIpInvType_Chr;

                    // 获取收费项目对应的申请/执行科室
                    string CLACAREA_CHR = order.m_strCREATEAREA_ID;//执行科室
                    clsORDERCHARGEDEPT_VO m_objDept_Vo = new clsORDERCHARGEDEPT_VO();

                    m_objDept_Vo.m_strOrderid_chr = order.m_strOrderID;
                    m_objDept_Vo.m_strOrderdicid_chr = order.m_strOrderDicID;
                    m_objDept_Vo.m_strChargeitemid_chr = ItemID_Chr;

                    m_objDept_Vo.m_strClacarea_chr = CLACAREA_CHR;
                    m_objDept_Vo.m_strCreatearea_chr = order.m_strCREATEAREA_ID;
                    m_objDept_Vo.m_strChargeitemname_chr = ItemName_Vchr;
                    m_objDept_Vo.m_strSpec_vchr = SPEC_VCHR.Trim();

                    m_objDept_Vo.m_strUnit_vchr = Unit_Vchr;//Unit_Vchr 住院单位{=收费项目.住院单位}
                    m_objDept_Vo.m_decAmount_dec = dmlAmount;//AMount_Dec    不续用领量（取医嘱的领量）
                    m_objDept_Vo.m_decUnitprice_dec = ItemPriceA;//UnitPrice_Dec  住院单价{=收费项目.住院单价}
                    m_objDept_Vo.m_strCreatorid_chr = order.m_strCreatorID;

                    m_objDept_Vo.m_strCreator_vchr = order.m_strCreator;
                    m_objDept_Vo.m_intFLAG_INT = FLAG_INT;//FLAG_INT 创建标志:收费项来源于 0-诊疗项目，1－带出的用法，2－自定义新开
                    m_objDept_Vo.m_intITEMSRCTYPE_INT = ITEMSRCTYPE_INT;//是否药品1为药品2为材料
                    m_objDept_Vo.m_intMEDICNETYPE_INT = intMEDICINETYPEID;//药品类型
                    m_objDept_Vo.m_decSINGLEAMOUNT_DEC = SINGLEAMOUNT_DEC;//补一次的领量
                    m_objDept_Vo.m_intIPCHARGEFLG = IPCHARGEFLG_INT;//住院单位
                    m_objDept_Vo.m_dmlPackQty = clsConverter.ToDecimal(dtbResult.Rows[i]["PackQty_Dec"].ToString());//包装量

                    m_objDept_Vo.m_intPOFLAG_INT = POFLAG_INT;//是否摆药 0-不摆药 1-摆药
                    m_objDept_Vo.m_intRATETYPE_INT = 1;//是否计费 0-不计费 1-计费
                    m_objDept_Vo.m_strINSURACEDESC_VCHR = INSURACEDESC_VCHR;//医保信息
                    m_objDept_Vo.m_intCONTINUEUSETYPE_INT = CONTINUEUSETYPE_INT;//续用类型 {0=不续用;1=全部续用;2-长嘱续用}

                    m_objDept_Vo.m_intExecuteflag = m_intExecuteflag;
                    m_objDept_Vo.m_strExecDeptID = m_strExecDeptID;
                    m_arrORDERCHARGEDEPT.Add(m_objDept_Vo);
                }
            }
        }
        #endregion

        #region 通过医嘱单记录添加收费项目到住院诊疗项目收费项目执行客户表(T_OPR_BIH_ORDERCHARGEDEPT)
        /// <summary> 
        /// 医嘱VO  收费项目到住院诊疗项目收费项目执行客户表
        /// </summary>
        /// <param name="order"></param>
        [AutoComplete]
        public long UpdateOrderToChargeItem(clsBIHOrder order, clsORDERCHARGEDEPT_VO[] m_arrDept_Vo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "";

            try
            {
                System.Data.IDataParameter[] arrParams = null;
                // 获取收费项目对应的申请/执行科室
                DataTable dtbResult3 = new DataTable();
                Hashtable m_htCLACAREA_CHR = new Hashtable();

                strSQL = @"select a.itemid_chr,
                                   b.clacarea_chr,
                                   (select c.clacarea_chr
                                      from t_aid_bih_ocdeptlist c
                                     where c.ordercateid_chr = a.ordercateid_chr
                                       and rownum = 1) clacarea_chr2
                              from t_bse_chargeitem a,
                                   (select ordercateid_chr, clacarea_chr
                                      from t_aid_bih_ocdeptdefault
                                     where createarea_chr = ?) b,
                                   t_aid_bih_orderdic_charge k
                             where k.itemid_chr = a.itemid_chr
                               and a.ordercateid_chr = b.ordercateid_chr(+)
                               and k.orderdicid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = order.m_strCREATEAREA_ID;
                arrParams[1].Value = order.m_strOrderDicID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult3, arrParams);
                if (lngRes > 0 && dtbResult3.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbResult3.Rows.Count; i++)
                    {
                        if (!m_htCLACAREA_CHR.Contains(dtbResult3.Rows[i]["itemid_chr"].ToString().Trim()))
                        {
                            m_htCLACAREA_CHR.Add(dtbResult3.Rows[i]["itemid_chr"].ToString().Trim(), dtbResult3.Rows[i]);
                        }
                    }
                    //医嘱的开单科室附值(如果都没有对应的执行科室，就保持原来的开单科室为执行科室)
                    for (int i = 0; i < m_arrDept_Vo.Length; i++)
                    {
                        if (m_arrDept_Vo[i].m_intExecuteflag == 2 && m_arrDept_Vo[i].m_intFLAG_INT == 2)//指定科室赋值
                        {
                            m_arrDept_Vo[i].m_strClacarea_chr = m_arrDept_Vo[i].m_strExecDeptID;
                        }
                        else
                        {
                            if (m_htCLACAREA_CHR.Contains(m_arrDept_Vo[i].m_strChargeitemid_chr.ToString()))
                            {
                                DataRow row1 = (DataRow)m_htCLACAREA_CHR[m_arrDept_Vo[i].m_strChargeitemid_chr.ToString()];
                                if (!row1["CLACAREA_CHR"].ToString().Equals(""))
                                {
                                    m_arrDept_Vo[i].m_strClacarea_chr = row1["CLACAREA_CHR"].ToString();
                                }
                                else if (!row1["CLACAREA_CHR2"].ToString().Equals(""))
                                {
                                    m_arrDept_Vo[i].m_strClacarea_chr = row1["CLACAREA_CHR2"].ToString();
                                }
                                else
                                {
                                    m_arrDept_Vo[i].m_strClacarea_chr = order.m_strCREATEAREA_ID;
                                }
                            }
                        }
                    }
                }

                if (!this.m_blnCheckOrderSubItemGross(m_arrDept_Vo))//判断带出项目库存
                {
                    return -3;//返回-3为带出项目库存不足
                }
                strSQL = @"insert into t_opr_bih_orderchargedept
                              (seq_int,
                               orderid_chr,
                               orderdicid_chr,
                               chargeitemid_chr,
                               clacarea_chr,
                               createarea_chr,
                               chargeitemname_chr,
                               spec_vchr,
                               unit_vchr,
                               amount_dec,
                               unitprice_dec,
                               creatorid_chr,
                               creator_vchr,
                               createdate_dat,
                               flag_int,
                               singleamount_dec,
                               poflag_int,
                               ratetype_int,
                               insuracedesc_vchr,
                               continueusetype_int,
                               continuefreqid_chr,
                               itemchargetype_vchr)
                            values
                              (seq_public.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                               ?, ?, sysdate, ?, ?, ?, ?, ?, ?, ?, ?)";
                DbType[] dbTypes = new DbType[] {DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Decimal, DbType.Decimal,
                                                 DbType.String, DbType.String, DbType.Int32, DbType.Decimal, DbType.Int32, DbType.Int32, DbType.String, DbType.Int32, DbType.String, DbType.String };
                object[][] objValues = new object[20][];
                if (m_arrDept_Vo.Length > 0)
                {
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[m_arrDept_Vo.Length];
                    }
                    int n = -1;
                    for (int k1 = 0; k1 < m_arrDept_Vo.Length; k1++)
                    {
                        n = -1;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strOrderid_chr;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strOrderdicid_chr;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strChargeitemid_chr;

                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strClacarea_chr;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strCreatearea_chr;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strChargeitemname_chr;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strSpec_vchr;

                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strUnit_vchr;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_decAmount_dec;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_decUnitprice_dec;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strCreatorid_chr;

                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strCreator_vchr;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_intFLAG_INT;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_decSINGLEAMOUNT_DEC;

                        objValues[++n][k1] = m_arrDept_Vo[k1].m_intPOFLAG_INT;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_intRATETYPE_INT;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strINSURACEDESC_VCHR;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_intCONTINUEUSETYPE_INT;
                        objValues[++n][k1] = m_arrDept_Vo[k1].m_strCONTINUEFREQID_CHR;
                        if (m_arrDept_Vo[k1].m_intFLAG_INT == 0)
                        {
                            objValues[++n][k1] = order.strShiying;
                        }
                        else
                        {
                            objValues[++n][k1] = "";
                        }
                    }
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }
            }
            catch (Exception objEx)
            {
                if (lngRes > 0)
                {
                    throw new Exception(objEx.Message);
                }
                else
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 带出项目的药品库存判断
        /// <summary>
        /// 医嘱出项目库存判断
        /// </summary>
        /// <param name="p_objOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        internal bool m_blnCheckOrderSubItemGross(clsORDERCHARGEDEPT_VO[] m_arrORDERCHARGEDEPT)
        {
            bool blnGross = true;
            string strNoGrossMessage = "";
            string strNoStoreMessage = "";
            int intcount = m_arrORDERCHARGEDEPT.Length;
            for (int i1 = 0; i1 < intcount; i1++)
            {
                if (m_arrORDERCHARGEDEPT[i1].m_intITEMSRCTYPE_INT == 1 && m_arrORDERCHARGEDEPT[i1].m_intPOFLAG_INT == 1)
                {
                    decimal fltUseMediconeCount = Convert.ToDecimal(m_arrORDERCHARGEDEPT[i1].m_decAmount_dec);
                    if (m_arrORDERCHARGEDEPT[i1].m_intPOFLAG_INT == 0)
                    {
                        fltUseMediconeCount = fltUseMediconeCount * m_arrORDERCHARGEDEPT[i1].m_dmlPackQty;
                    }
                    string m_strExecDeptID = "";
                    string m_strMedStore = m_arrORDERCHARGEDEPT[i1].m_strClacarea_chr;
                    if (!string.IsNullOrEmpty(m_strMedStore))
                    {

                        long l = -1;
                        l = this.m_lngGetMedStoreByDoctorWorkStation_subItem(m_strMedStore, m_arrORDERCHARGEDEPT[i1].m_strChargeitemid_chr, fltUseMediconeCount,
                                                            out blnGross, out m_strExecDeptID);


                        if (l < 0 || string.IsNullOrEmpty(m_strExecDeptID))
                        {
                            strNoStoreMessage += m_arrORDERCHARGEDEPT[i1].m_strChargeitemname_chr + "\r\n";
                        }
                        if (blnGross == false)
                        {
                            // MessageBox.Show(m_arrORDERCHARGEDEPT[i1].m_strChargeitemname_chr + "\r\n库存不足，不能保存医嘱？", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            strNoGrossMessage += m_arrORDERCHARGEDEPT[i1].m_strChargeitemname_chr + "\r\n";
                        }
                    }
                }

            }
            if (!string.IsNullOrEmpty(strNoGrossMessage))
            {
                throw new Exception(strNoGrossMessage + "\r\n带出项目库存不足，不能保存医嘱!");
                return false;
            }
            if (!string.IsNullOrEmpty(strNoStoreMessage))
            {
                throw new Exception(strNoStoreMessage + "带出项目药房没有该药品的可用库存，请重新选择。");
                return false;
            }
            return blnGross;
        }
        #endregion
        /// <summary>
        /// 获取住院默认中西药房
        /// </summary>
        /// <param name="strMedDeptId">住院西药房ID</param>
        /// <param name="strMidMedDeptId">中药房ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDrugStorge(out string strMedDeptId, out string strMidMedDeptId)
        {
            long lngRes = 0;
            strMedDeptId = "";
            strMidMedDeptId = "";
            string strMedDept = "";
            string[] strMedDeptArr = null;
            string strSQL = @"select a.parmvalue_vchr                                  
                              from t_bse_sysparm a
                             where a.status_int = 1 and a.parmcode_chr = '1009'";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                DataTable dtbResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    strMedDept = dtbResult.Rows[0]["parmvalue_vchr"].ToString();
                    strMedDeptArr = strMedDept.Split('*');
                    strMedDeptId = strMedDeptArr[0];//西药房
                    strMidMedDeptId = strMedDeptArr[1];//中药房
                    dtbResult.Dispose();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }

        #region  医生工作站对药品库存的检查
        /// <summary>
        /// 医生工作站对药品库存的检查
        /// </summary>
        /// <param name="m_strMedStordID"></param>
        /// <param name="m_strItemID"></param>
        /// <param name="m_dclGetMed"></param>
        /// <param name="blnFlag">是否够库存</param>
        /// <param name="m_strExecDeptID">返回科室ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreByDoctorWorkStation(string m_strMedStordID, string m_strItemID, decimal m_dclGetMed,
                                                        out bool blnFlag, out string m_strExecDeptID, out string medCode)
        {
            long lngRes = -1;
            string Sql = string.Empty;
            m_strExecDeptID = string.Empty;
            medCode = string.Empty;

            Sql = @"select b.medicineid_chr,
                           b.drugstoreid_chr,
                           f.assistcode_chr as medcode,
                           sum(b.iprealgross_int) as sumgross
                      from t_ds_storage        a,
                           t_ds_storage_detail b,
                           t_bse_chargeitem    d,
                           t_bse_bih_orderdic  e,
                           t_bse_medicine      f
                     where a.medicineid_chr = f.medicineid_chr
                       and a.medicineid_chr = b.medicineid_chr
                       and d.itemsrcid_vchr = a.medicineid_chr
                       and a.drugstoreid_chr = b.drugstoreid_chr
                       and e.itemid_chr = d.itemid_chr
                       and a.ifstop_int = 0
                       and a.noqtyflag_int = 0
                       and b.canprovide_int = 1
                       and a.drugstoreid_chr = ?
                       and e.orderdicid_chr = ? 
                     group by b.medicineid_chr, b.drugstoreid_chr, f.assistcode_chr
                    ";
            blnFlag = false;

            try
            {
                DataTable dt = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = m_strMedStordID;
                param[1].Value = m_strItemID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(Sql, ref dt, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (lngRes < 0)
                {
                    return lngRes;
                }
                if (dt.Rows.Count > 0)
                {
                    if (m_dclGetMed <= Convert.ToDecimal(dt.Rows[0]["sumgross"]))
                    {
                        blnFlag = true;
                    }
                    m_strExecDeptID = dt.Rows[0]["drugstoreid_chr"].ToString();
                    medCode = dt.Rows[0]["medcode"].ToString();
                }
                dt = null;
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
        /// 医生工作站对药品库存的检查
        /// </summary>
        /// <param name="m_strMedStordID"></param>
        /// <param name="m_strItemID"></param>
        /// <param name="m_dclGetMed"></param>
        /// <param name="blnFlag">是否够库存</param>
        /// <param name="m_strExecDeptID">返回科室ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreByDoctorWorkStation_subItem(string m_strMedStordID, string m_strItemID, decimal m_dclGetMed,
                                                        out bool blnFlag, out string m_strExecDeptID)
        {
            long lngRes = -1;
            m_strExecDeptID = "";
            string strSQL = @"select b.medicineid_chr,
       sum(b.iprealgross_int) as sumgross,
       b.drugstoreid_chr
  from t_ds_storage        a,
       t_ds_storage_detail b,
       t_bse_chargeitem    d,
       t_bse_medicine      f
 where a.medicineid_chr = f.medicineid_chr
   and a.medicineid_chr = b.medicineid_chr
   and d.itemsrcid_vchr = a.medicineid_chr
   and a.drugstoreid_chr = b.drugstoreid_chr
   and a.ifstop_int = 0
   and a.noqtyflag_int = 0
   and b.canprovide_int = 1
   and a.drugstoreid_chr = ?
   and d.itemid_chr = ?
 group by b.medicineid_chr, b.drugstoreid_chr";
            blnFlag = false;

            try
            {
                DataTable dt = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = m_strMedStordID;
                param[1].Value = m_strItemID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (lngRes < 0)
                {
                    return lngRes;
                }
                if (dt.Rows.Count > 0)
                {
                    if (m_dclGetMed <= Convert.ToDecimal(dt.Rows[0]["sumgross"]))
                    {
                        blnFlag = true;
                    }

                    m_strExecDeptID = dt.Rows[0]["drugstoreid_chr"].ToString();
                }

                dt = null;

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

        /// <summary>
        /// 医生工作站显示收费比例
        /// </summary>
        /// <param name="m_strItemID"></param>
        /// <param name="m_strPayType"></param>
        /// <param name="m_strPrecent"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeItemPrecent(string m_strItemID, string m_strPayType, out string m_strPrecent)
        {
            long lngRes = 0;
            m_strPrecent = "100";
            string strSQL = @"select t.precent_dec
                      from t_aid_inschargeitem t
                     where t.itemid_chr = ?
                       and t.copayid_chr = ?";
            try
            {
                DataTable dt = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = m_strItemID;
                param[1].Value = m_strPayType;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (dt.Rows.Count > 0)
                {
                    m_strPrecent = dt.Rows[0]["precent_dec"].ToString();
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }

        #region 根据员工ID查询员工签名
        /// <summary>
        /// 根据员工ID查询员工签名
        /// </summary>
        /// <param name="m_strEmpID"></param>
        /// <param name="m_objSign"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSignByEmpID(string m_strEmpID, ref object m_objSign)
        {
            long lngRes = 0;
            string strSQL = @"select t.sign_grp from t_bse_empsign t where t.empid_chr = ?";

            try
            {
                DataTable dt = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strEmpID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] != DBNull.Value)
                    {
                        m_objSign = dt.Rows[0][0];
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }
        #endregion

        #region GetMedInfoByOrderDicId
        /// <summary>
        /// GetMedInfoByOrderDicId
        /// </summary>
        /// <param name="orderDicId"></param>
        /// <returns></returns>
        [AutoComplete]
        public System.Collections.Generic.Dictionary<string, clsMedicine_VO> GetMedInfoByOrderDicId(string orderDicId)
        {
            //            string Sql = @"select a.orderdicid_chr, c.medicineid_chr, c.medicinename_vchr
            //                              from t_bse_bih_orderdic a, t_bse_chargeitem b, t_bse_medicine c
            //                             where a.itemid_chr = b.itemid_chr
            //                               and b.itemsrcid_vchr = c.medicineid_chr
            //                               and a.orderdicid_chr in ({0})";

            string Sql = @"select a.orderdicid_chr, a.itemid_chr, a.name_chr from t_bse_bih_orderdic a where a.orderdicid_chr in ({0})";

            Sql = string.Format(Sql, orderDicId);
            System.Collections.Generic.Dictionary<string, clsMedicine_VO> dicMed = new System.Collections.Generic.Dictionary<string, clsMedicine_VO>();

            try
            {
                DataTable dt = null;
                clsHRPTableService svc = new clsHRPTableService();
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                svc.Dispose();
                svc = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    clsMedicine_VO vo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!dicMed.ContainsKey(dr["orderdicid_chr"].ToString()))
                        {
                            vo = new clsMedicine_VO();
                            vo.m_strMedicineID = dr["itemid_chr"].ToString();
                            vo.m_strMedicineName = dr["name_chr"].ToString();
                            dicMed.Add(dr["orderdicid_chr"].ToString(), vo);
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dicMed;
        }
        #endregion

        #region 抗生素药品

        #region 判断是否抗生素药品
        /// <summary>
        /// 判断是否抗生素药品
        /// </summary>
        /// <param name="orderDicId"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool IsAutiMed(string orderDicId)
        {
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = orderDicId;
            try
            {
                Sql = @"select a.orderdicid_chr, c.medicineid_chr, c.pharmaid_chr
                          from t_bse_bih_orderdic a
                         inner join t_bse_chargeitem b
                            on a.itemid_chr = b.itemid_chr
                         inner join t_bse_medicine c
                            on b.itemsrcid_vchr = c.medicineid_chr
                         where a.itemid_chr = ?";
                DataTable dt = new DataTable();
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["pharmaid_chr"] != DBNull.Value && (dt.Rows[0]["pharmaid_chr"].ToString() == "00001" || dt.Rows[0]["pharmaid_chr"].ToString() == "00005" || dt.Rows[0]["pharmaid_chr"].ToString() == "00006" || dt.Rows[0]["pharmaid_chr"].ToString() == "00013"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return false;
        }
        #endregion

        #region 判断是否针剂(疗程预发药)
        /// <summary>
        /// 判断是否针剂(疗程预发药)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeId">1: t_bse_bih_orderdic.orderdicid_chr; 2: t_bse_bih_orderdic.itemid_chr</param>
        /// <returns></returns>
        [AutoComplete]
        public bool IsMedInjection(string id, int typeId)
        {
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = id;
            try
            {
                Sql = @"select a.orderdicid_chr,
                               c.medicineid_chr,
                               c.pharmaid_chr,
                               d.flaga_int as medproperty
                          from t_bse_bih_orderdic a
                         inner join t_bse_chargeitem b
                            on a.itemid_chr = b.itemid_chr
                         inner join t_bse_medicine c
                            on b.itemsrcid_vchr = c.medicineid_chr
                         inner join t_aid_medicinepreptype d
                            on c.medicinepreptype_chr = d.medicinepreptype_chr
                         where {0} = ?";

                if (typeId == 1)
                    Sql = string.Format(Sql, "a.orderdicid_chr");
                else if (typeId == 2)
                    Sql = string.Format(Sql, "a.itemid_chr");

                DataTable dt = new DataTable();
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["medproperty"] != DBNull.Value && Convert.ToInt32(dr["medproperty"]) == 2)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return false;
        }
        #endregion

        #region 判断是否中药饮片
        /// <summary>
        /// 判断是否中药饮片
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool IsMedPieces(string itemId)
        {
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = itemId;
            try
            {
                Sql = @"select 1
                          from t_bse_bih_orderdic a
                         inner join t_bse_chargeitem b
                            on a.itemid_chr = b.itemid_chr
                         inner join t_bse_medicine c
                            on b.itemsrcid_vchr = c.medicineid_chr
                         inner join t_aid_medicinepreptype d
                            on c.medicinepreptype_chr = d.medicinepreptype_chr
                         where c.medicinepreptype_chr = 12
                           and a.itemid_chr = ?";

                DataTable dt = new DataTable();
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return false;
        }
        #endregion

        #region 频率信息
        /// <summary>
        /// 频率信息
        /// </summary>
        /// <param name="freqId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetFreqDict(string freqId)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = freqId;
            try
            {
                Sql = @"select a.freqid_chr,
                               a.freqname_chr,
                               a.usercode_chr,
                               a.times_int,
                               a.days_int
                          from t_aid_recipefreq a
                         where a.freqid_chr = ?";

                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "freq";
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #endregion

        #region 住院手术申请

        #region 是否要分级管理
        /// <summary>
        /// 是否要分级管理
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public bool IsOpStepControl()
        {
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"select t.parmvalue_vchr from t_bse_sysparm t where t.parmcode_chr = '9005' and t.status_int = 1";
                DataTable dt = new DataTable();
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["parmvalue_vchr"] != DBNull.Value && dt.Rows[0]["parmvalue_vchr"].ToString() == "1")
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
            }
            return false;
        }
        #endregion

        #region 手术分级管理
        /// <summary>
        /// 手术分级管理
        /// </summary>
        /// <param name="opName"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetOpInfo(string opName)
        {
            DataTable dt = null;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = opName;
            try
            {
                Sql = @"select t.icdcode_chr, t.icdname_vchr, t.fopjb from t_aid_oprticd t where trim(t.icdname_vchr) = ?";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region 获取历史记录
        /// <summary>
        /// 获取历史记录
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetOpHistory(string patientId)
        {
            DataTable dt = null;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = patientId;
            try
            {
                Sql = @"select t.opendate_dat, t.anaid_int, t.status_int
                          from t_ana_requisition t
                         where t.patientid_chr = ?
                           and t.status_int >= -2
                         order by t.opendate_dat desc";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region 获取手术记录
        /// <summary>
        /// 获取手术记录
        /// </summary>
        /// <param name="anaId"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtSign"></param>
        [AutoComplete]
        public void GetOpRecord(decimal anaId, DateTime openDate, out DataTable dtMain, out DataTable dtSign)
        {
            string Sql = string.Empty;
            dtMain = new DataTable();
            dtSign = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select * from t_ana_requisition t where t.anaid_int = ?";   // and t.opendate_dat = ?";
                svc.CreateDatabaseParameter(1, out parm); //(2, out parm);
                parm[0].Value = anaId;
                //parm[1].Value = openDate;
                svc.lngGetDataTableWithParameters(Sql, ref dtMain, parm);

                if (dtMain != null && dtMain.Rows.Count > 0)
                {
                    Sql = @"select * from t_ana_sign t where t.sequenceid_int = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = dtMain.Rows[0]["signsequence_int"].ToString();
                    svc.lngGetDataTableWithParameters(Sql, ref dtSign, parm);
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
        }
        #endregion

        #region 获取签名信息
        /// <summary>
        /// 获取签名信息
        /// </summary>
        /// <param name="signSequence"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetOpRecordSign(decimal signSequence)
        {
            string Sql = string.Empty;
            DataTable dtSign = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select * from t_ana_sign t where t.sequenceid_int = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = signSequence;
                svc.lngGetDataTableWithParameters(Sql, ref dtSign, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dtSign;
        }
        #endregion

        #region 保存手术申请
        /// <summary>
        /// 保存手术申请
        /// </summary>
        /// <param name="patVo"></param>
        /// <param name="dicData"></param>
        /// <param name="anaId"></param>
        /// <param name="openDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SaveOpApply(clsBIHPatientInfo patVo, Dictionary<string, string> dicData, out decimal anaId, out DateTime openDate, bool isDelete)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            anaId = 0;
            openDate = DateTime.Now;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            DataTable dt = null;
            try
            {
                if (dicData["AnaId"] == string.Empty)
                {
                    Sql = "select seq_ana_id.nextval from dual";
                    svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                    anaId = Convert.ToDecimal(dt.Rows[0][0].ToString());
                }
                else
                {
                    anaId = Convert.ToDecimal(dicData["AnaId"]);
                    openDate = Convert.ToDateTime(dicData["OpenDate"]);
                    Sql = @"delete from t_ana_requisition where anaid_int = ?"; // and opendate_dat = ?";
                    svc.CreateDatabaseParameter(1, out parm); //(2, out parm);
                    parm[0].Value = anaId;
                    //parm[1].Value = openDate;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                    Sql = @"delete from  t_ana_sign t where t.sequenceid_int = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = Convert.ToDecimal(dicData["SignSequence"]);
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                    if (isDelete) return 1;
                }

                Sql = "select seq_ana_sign.nextval from dual";
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                decimal SignSequeue = Convert.ToDecimal(dt.Rows[0][0].ToString());

                #region 签名信息
                string empId = string.Empty;
                string empName = string.Empty;
                Sql = @"insert into t_ana_sign values (?, ?, ?, ?, sysdate, ?)";
                List<string> lstDoct = new List<string>() { "主刀医师", "开单医师", "主管医师", "一助", "二助", "三助", "审批医师" };
                foreach (string item in lstDoct)
                {
                    if (dicData[item] != string.Empty)
                    {
                        if (dicData[item].IndexOf("|") > 0)
                        {
                            empId = dicData[item].Split('|')[0];
                            empName = dicData[item].Split('|')[1];
                        }
                        else
                        {
                            empName = dicData[item];
                            empName = empName.Replace("副主任医师", "").Replace("主任医师", "").Replace("主治医师", "").Replace("住院医师", "").Replace("审批医师", "").Replace("医师", "").Trim();
                            string Sql1 = @"select t.empid_chr, t.lastname_vchr from t_bse_employee t where trim(t.lastname_vchr) = ?";
                            svc.CreateDatabaseParameter(1, out parm);
                            parm[0].Value = empName;
                            svc.lngGetDataTableWithParameters(Sql1, ref dt, parm);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                empId = dt.Rows[0]["empid_chr"].ToString();
                                empName = dt.Rows[0]["lastname_vchr"].ToString();
                            }
                            else
                            {
                                empId = string.Empty;
                                empName = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        empId = string.Empty;
                        empName = string.Empty;
                    }
                    if (string.IsNullOrEmpty(empId)) continue;
                    svc.CreateDatabaseParameter(5, out parm);
                    parm[0].Value = SignSequeue;
                    parm[1].Value = item;
                    parm[2].Value = empId;
                    parm[3].Value = "frmRequisition";
                    parm[4].Value = empName;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                }
                #endregion

                #region Sql2
                Sql = @"insert into t_ana_requisition
                          (anaid_int,
                           patientid_chr,
                           inpatientid_chr,
                           inpatientdate_dat,
                           patientcardid_chr,
                           registerid_chr,
                           deptid_chr,
                           createuserid_chr,
                           opendate_dat,                
                           modifydate_dat,                  -- 10
                           modifyuserid_chr,
                           status_int,
                           preoperativediagnosis_chr,
                           operationname_chr,
                           operationdate_dat,
                           operationroomid_chr,
                           sequence_chr,
                           weight_chr,
                           asalevel_chr,
                           isisolated_int,                  -- 20
                           isaxenic_int,
                           isemergency_int,
                           issignedicf,
                           iscontinuedoperation_int,
                           remark_chr,                     -- 25 
                           visitor_chr,
                           signsequence_int,
                           diseasename_chr,
                           specialcase_chr,
                           anamode_chr,                     -- 30
                           operationpart_chr,
                           continuedoperation_vchr,
                           anadeptid_chr,
                           from_int,
                           bedno_vchr,
                           sex_vchr,
                           age_vchr,
                           patientname_vchr,
                           emergency_chr)
                        values
                          (?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                           ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                           ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                           ?, ?, ?, ?, ?, ?, ?, ?, ?)
                        ";

                int n = -1;
                svc.CreateDatabaseParameter(39, out parm);
                parm[++n].Value = anaId;
                parm[++n].Value = patVo.m_strPatientID;
                parm[++n].Value = patVo.m_strInHospitalNo;
                parm[++n].Value = patVo.m_dtInHospital;
                parm[++n].Value = patVo.m_strPATIENTCARDID_CHR;
                parm[++n].Value = patVo.m_strRegisterID;
                parm[++n].Value = dicData["开单科室ID"];
                parm[++n].Value = dicData["开单医师ID"];
                parm[++n].Value = openDate;
                parm[++n].Value = DateTime.Now;           // 10
                parm[++n].Value = dicData["审批医师ID"];
                parm[++n].Value = dicData["Status"];
                parm[++n].Value = dicData["Diag"];
                parm[++n].Value = dicData["OpName"];
                parm[++n].Value = Convert.ToDateTime(dicData["OpDate"]);
                parm[++n].Value = dicData["OpLocation"];
                parm[++n].Value = null;                 // 台序
                parm[++n].Value = dicData["Weight"];
                parm[++n].Value = dicData["OpLevel"];
                parm[++n].Value = dicData["Isolation"];           // 20
                parm[++n].Value = dicData["Wjop"];
                parm[++n].Value = dicData["OpType"] == "急诊手术" ? 1 : 0;
                parm[++n].Value = dicData["Zqtys"];
                parm[++n].Value = dicData["LtFlag"];
                parm[++n].Value = dicData["Comment"];
                parm[++n].Value = dicData["DoctVisit"];
                parm[++n].Value = SignSequeue;
                parm[++n].Value = null;                 // 疾病名称
                parm[++n].Value = null;                 // 特殊情况
                parm[++n].Value = dicData["AnaType"];           // 30
                parm[++n].Value = dicData["OpPart"];
                parm[++n].Value = dicData["LtStr"];
                parm[++n].Value = dicData["OpLocation"];
                parm[++n].Value = "1";                  // 电子单
                parm[++n].Value = patVo.m_strBedName;
                parm[++n].Value = patVo.m_strSex;
                parm[++n].Value = patVo.m_strAge;
                parm[++n].Value = patVo.m_strPatientName;
                parm[++n].Value = dicData["OpType"];    // 39

                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                #endregion

            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 取消手术
        /// <summary>
        /// 取消手术
        /// </summary>
        /// <param name="anaId"></param>
        /// <param name="openDate"></param>
        /// <param name="cancelOperId"></param>
        /// <returns></returns>
        [AutoComplete]
        public int CancelOpApply(decimal anaId, DateTime openDate, string cancelOperId)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"update t_ana_requisition set status_int = ?, modifydate_dat = sysdate, modifyuserid_chr = ? where anaid_int = ? and opendate_dat = ?";
                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = -1;
                parm[1].Value = cancelOperId;
                parm[2].Value = anaId;
                parm[3].Value = openDate;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #endregion

        #region 临床路径-CP

        #region 获取科室编码
        /// <summary>
        /// 获取科室编码
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        [AutoComplete]
        public string GetCpDeptCode(string deptId)
        {
            string deptCode = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                DataTable dt = null;
                string Sql = "select t.code_vchr from t_bse_deptdesc t where t.deptid_chr = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = deptId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    deptCode = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return deptCode;
        }
        #endregion

        #region 路径列表
        /// <summary>
        /// 路径列表
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCpListByDeptCode(string deptCode)
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                Sql = @"select distinct a.cpid_int       as cpid,
                                        a.cpname_vchr    as cpname,
                                        a.pycode_vchr    as pycode,
                                        a.wbcode_vchr    as wbcode,
                                        c.deptid_int,
                                        c.deptcode_vchr,
                                        c.deptname_vchr,
                                        icd.icd_vchr     as icdcode,
                                        icd.icdname_vchr as icdname
                          from t_cp_flowdiagram a
                         inner join t_cp_defdept b
                            on a.cpid_int = b.cpid_int
                         inner join t_dic_department c
                            on b.deptid_int = c.deptid_int
                          left join t_cp_accessicd icd
                            on a.cpid_int = icd.cpid_int
                         where a.status_int = 1 
                           {0}";

                clsHRPTableService svc = new clsHRPTableService();
                if (deptCode == "")
                {
                    Sql = string.Format(Sql, "");
                    svc.m_mthSetDataBase_Selector(1, 18);
                    svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                }
                else
                {
                    Sql = string.Format(Sql, "and c.deptcode_vchr = ?");
                    svc.m_mthSetDataBase_Selector(1, 18);
                    IDataParameter[] parm = null;
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = deptCode;
                    svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                }
                svc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dt;
        }
        #endregion

        #region ICD10诊断
        /// <summary>
        /// ICD10诊断
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCpIcd10(bool isAll)
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                if (isAll)
                {
                    Sql = @"select 1                as typeid,
                                   a.icdcode_vchr   as icdcode,
                                   a.icdcnname_vchr as icdname,
                                   a.icdpycode_vchr as pycode,
                                   a.icdwbcode_vchr as wbcode
                              from t_dic_icd10 a
                            union all
                            select 2                as typeid,
                                   b.icdcode_vchr   as icdcode,
                                   b.icdname_vchr   as icdname,
                                   b.icdpycode_vchr as pycode,
                                   b.icdwbcode_vchr as wbcode
                              from t_dic_opicd b";
                }
                else
                {
                    Sql = @"select 1                as typeid,
                                   a.icdcode_vchr   as icdcode,
                                   a.icdcnname_vchr as icdname,
                                   a.icdpycode_vchr as pycode,
                                   a.icdwbcode_vchr as wbcode
                              from t_dic_icd10 a
                             inner join t_cp_accessicd i1 on a.icdcode_vchr = i1.icd_vchr  
                            union all
                            select 2                as typeid,
                                   b.icdcode_vchr   as icdcode,
                                   b.icdname_vchr   as icdname,
                                   b.icdpycode_vchr as pycode,
                                   b.icdwbcode_vchr as wbcode
                              from t_dic_opicd b
                            inner join t_cp_accessicd i2 on b.icdcode_vchr = i2.icd_vchr  ";
                }

                clsHRPTableService svc = new clsHRPTableService();
                svc.m_mthSetDataBase_Selector(1, 18);
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                svc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dt;
        }
        #endregion

        #region 获取中医症型
        /// <summary>
        /// 获取中医症型
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetSyndrome()
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                Sql = @"select distinct synname_vchr as synname from t_cp_syndrome";
                clsHRPTableService svc = new clsHRPTableService();
                svc.m_mthSetDataBase_Selector(1, 18);
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                svc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dt;
        }
        #endregion

        #region 获取变异信息
        /// <summary>
        /// 获取变异信息
        /// </summary>
        /// <param name="cpId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCpVariation(int cpId)
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                Sql = @"select t.varinfo_vchr as varinfo, t.scope_int as scope
                          from t_cp_variation t
                         where t.cpid_int = ?";
                clsHRPTableService svc = new clsHRPTableService();
                svc.m_mthSetDataBase_Selector(1, 18);
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = cpId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dt;
        }
        #endregion

        #region 获取出院评估标准
        /// <summary>
        /// 获取出院评估标准
        /// </summary>
        /// <param name="cpId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetOutCriterion(int cpId)
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                Sql = @"select t.criinfo_vchr as criinfo from t_cp_outcriterion t where t.cpid_int = ?";
                clsHRPTableService svc = new clsHRPTableService();
                svc.m_mthSetDataBase_Selector(1, 18);
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = cpId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dt;
        }
        #endregion

        #region 保存是否符合路径
        /// <summary>
        /// 保存是否符合路径
        /// </summary>
        /// <param name="registerId"></param>
        /// <param name="isFit"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SaveIsFitCp(string registerId, int isFit, string cpName)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = "update t_opr_bih_register set isFitCp = ?, cpName = ?, cpRecordDate = ? where registerid_chr = ?";
                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = isFit;
                parm[1].Value = cpName;
                parm[2].Value = DateTime.Now;
                parm[3].Value = registerId;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 入径
        /// <summary>
        /// 入径
        /// </summary>
        /// <param name="cpVo"></param>
        /// <returns></returns>
        [AutoComplete]
        public int CpIn(EntityCpExecPlan cpVo, ref decimal execId)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = "update t_opr_bih_register set cpname = ?, cpRecordDate = ?, cpstatus = 1 where registerid_chr = ?";
                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = cpVo.cpname;
                parm[1].Value = cpVo.begindate;
                parm[2].Value = cpVo.registerid;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                if (execId <= 0)
                {
                    DataTable dt = null;
                    Sql = @"select seq_cpexecid.nextval from dual";
                    svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                    execId = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                else
                {
                    Sql = @"delete from t_cp_execplan where execid = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = execId;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                }

                Sql = @"insert into t_cp_execplan
                          (execid,
                           registerid,
                           deptid,
                           areaid,
                           bedid,
                           doctid,
                           indesc,
                           currdate,
                           begindate,
                           status,
                           synname,
                           recorder,
                           recorddate,
                           othexam,
                           cpid,
                           cpname,
                           cpmainicdcode,
                           cpmainicdname)
                        values
                          (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                int n = -1;
                svc.CreateDatabaseParameter(18, out parm);
                parm[++n].Value = execId;
                parm[++n].Value = cpVo.registerid;
                parm[++n].Value = cpVo.deptid;
                parm[++n].Value = cpVo.areaid;
                parm[++n].Value = cpVo.bedid;
                parm[++n].Value = cpVo.doctid;
                parm[++n].Value = cpVo.indesc;
                parm[++n].Value = cpVo.currdate;
                parm[++n].Value = cpVo.begindate;
                parm[++n].Value = cpVo.status;
                parm[++n].Value = cpVo.synname;
                parm[++n].Value = cpVo.recorder;
                parm[++n].Value = cpVo.recorddate;
                parm[++n].Value = cpVo.othexam;
                parm[++n].Value = cpVo.cpid;
                parm[++n].Value = cpVo.cpname;
                parm[++n].Value = cpVo.cpmainicdcode;
                parm[++n].Value = cpVo.cpmainicdname;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 保存变异
        /// <summary>
        /// 保存变异
        /// </summary>
        /// <param name="varID"></param>
        /// <param name="voVar"></param>
        /// <param name="lstVardet"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SaveCpExecvariation(ref int varID, EntityCpExecPlanVar voVar, List<EntityCpExecPlanVarDetail> lstVardet)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                int n = -1;
                DateTime dtmNow = DateTime.Now;
                if (varID <= 0)
                {
                    DataTable dt = null;
                    Sql = @"select seq_cpvarid.nextval from dual";
                    svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                    varID = Convert.ToInt32(dt.Rows[0][0].ToString());

                    Sql = @" insert into t_cp_execplanvar
                               (varid,
                                execid,
                                registerid,
                                vardate,
                                vartype,
                                newcpid,
                                vareffect,
                                varcontent,
                                doctid,
                                doctdate,
                                nurseid,
                                nursedate,
                                operid,
                                operdate,
                                status)
                             values
                               (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    svc.CreateDatabaseParameter(15, out parm);
                    parm[++n].Value = varID;
                    parm[++n].Value = voVar.execid;
                    parm[++n].Value = voVar.registerid;
                    parm[++n].Value = voVar.vardate;
                    parm[++n].Value = voVar.vartype;
                    parm[++n].Value = voVar.newcpid;
                    parm[++n].Value = voVar.vareffect;
                    parm[++n].Value = voVar.varcontent;
                    parm[++n].Value = voVar.doctid;
                    parm[++n].Value = voVar.doctdate;
                    parm[++n].Value = voVar.nurseid;
                    parm[++n].Value = voVar.nursedate;
                    parm[++n].Value = voVar.operid;
                    parm[++n].Value = voVar.operdate;
                    parm[++n].Value = voVar.status;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                }
                else
                {
                    Sql = @"delete from t_cp_execplanvardetail where varid = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = varID;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                    Sql = @"update t_cp_execplanvar
                               set newcpid = ?, vardate = ?, vartype = ?, vareffect = ?, varcontent = ?, status = ?
                             where varid = ?";
                    svc.CreateDatabaseParameter(7, out parm);
                    parm[++n].Value = voVar.newcpid;
                    parm[++n].Value = voVar.vardate;
                    parm[++n].Value = voVar.vartype;
                    parm[++n].Value = voVar.vareffect;
                    parm[++n].Value = voVar.varcontent;
                    parm[++n].Value = voVar.status;
                    parm[++n].Value = varID;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                }

                if (lstVardet != null && lstVardet.Count > 0)
                {
                    Sql = @"insert into t_cp_execplanvardetail
                              (serno, varid, varcontent, sortno)
                            values
                              (seq_cpvardetserno.nextval, ?, ?, ?)";
                    for (int i = 0; i < lstVardet.Count; i++)
                    {
                        svc.CreateDatabaseParameter(3, out parm);
                        parm[0].Value = varID;
                        parm[1].Value = lstVardet[i].varcontent;
                        parm[2].Value = i;
                        svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                    }
                }

                // 2 新路径; 3 终止路径
                if (voVar.vartype == 2 || voVar.vartype == 3)
                {
                    Sql = "update t_opr_bih_register set cpstatus = 2 where registerid_chr = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = voVar.registerid;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                    Sql = @"update t_cp_execplan set enddate = ?, status = ? where execid = ?";
                    svc.CreateDatabaseParameter(3, out parm);
                    parm[0].Value = DateTime.Now;
                    parm[1].Value = 2;
                    parm[2].Value = voVar.execid;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                    Sql = @"delete from t_cp_out where outid = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = voVar.execid;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                    Sql = @"insert into t_cp_out
                              (outid,
                               doctid,
                               registerid,
                               outdate,
                               outtype,
                               evaluation,
                               outinfo,
                               operid,
                               operdate,
                               status)
                            values
                              (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    n = -1;
                    svc.CreateDatabaseParameter(10, out parm);
                    parm[++n].Value = voVar.execid;
                    parm[++n].Value = voVar.doctid;
                    parm[++n].Value = voVar.registerid;
                    parm[++n].Value = voVar.vardate;
                    parm[++n].Value = 2;    // 异常出径
                    parm[++n].Value = 4;    // 无效
                    if (voVar.vartype == 2)
                        parm[++n].Value = "新路径";
                    else if (voVar.vartype == 3)
                        parm[++n].Value = "终止路径";
                    parm[++n].Value = voVar.operid;
                    parm[++n].Value = voVar.operdate;
                    parm[++n].Value = 1;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 出径(评估表)
        /// <summary>
        /// 出径(评估表)
        /// </summary>
        /// <param name="outVo"></param>
        /// <param name="lstOutCri"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SaveCpOutEvaluation(EntityCpOut outVo, List<EntityCpOutCriDetail> lstOutCri)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = "update t_opr_bih_register set cpstatus = 2 where registerid_chr = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = outVo.registerid;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                Sql = @"update t_cp_execplan set enddate = ?, status = ? where execid = ?";
                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = DateTime.Now;
                parm[1].Value = 2;
                parm[2].Value = outVo.execid;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                Sql = @"delete from t_cp_out where outid = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = outVo.outid;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                Sql = @"delete from t_cp_outcridetail where outid = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = outVo.outid;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                Sql = @"insert into t_cp_out
                          (outid,
                           doctid,
                           registerid,
                           outdate,
                           outtype,
                           evaluation,
                           outinfo,
                           operid,
                           operdate,
                           status)
                        values
                          (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                int n = -1;
                svc.CreateDatabaseParameter(10, out parm);
                parm[++n].Value = outVo.outid;
                parm[++n].Value = outVo.doctid;
                parm[++n].Value = outVo.registerid;
                parm[++n].Value = outVo.outdate;
                parm[++n].Value = outVo.outtype;
                parm[++n].Value = outVo.evaluation;
                parm[++n].Value = outVo.outinfo;
                parm[++n].Value = outVo.operid;
                parm[++n].Value = outVo.operdate;
                parm[++n].Value = outVo.status;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                if (lstOutCri != null && lstOutCri.Count > 0)
                {
                    Sql = @"insert into t_cp_outcridetail
                              (serno, outid, cricontent, sortno)
                            values
                              (seq_cpoutcriserno.nextval, ?, ?, ?)";
                    for (int i = 0; i < lstOutCri.Count; i++)
                    {
                        svc.CreateDatabaseParameter(3, out parm);
                        parm[0].Value = outVo.outid;
                        parm[1].Value = lstOutCri[i].cricontent;
                        parm[2].Value = i;
                        svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                    }
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 获取在执行的路径记录
        /// <summary>
        /// 获取在执行的路径记录
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCpExecPlan(string registerId)
        {
            DataTable dt = null;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                string Sql = "select * from t_cp_execplan t where t.status = 1 and t.registerid = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = registerId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region 获取变异列表
        /// <summary>
        /// 获取变异列表
        /// </summary>
        /// <param name="execId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCpExecVarList(decimal execId)
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                Sql = @"select t.varid, t.vardate from t_cp_execplanvar t where t.execid = ?";
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = execId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dt;
        }
        #endregion

        #region 获取变异内容
        /// <summary>
        /// 获取变异内容
        /// </summary>
        /// <param name="varId"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        [AutoComplete]
        public void GetCpExecVarInfo(decimal varId, out DataTable dtMain, out DataTable dtDet)
        {
            string Sql = string.Empty;
            dtMain = null;
            dtDet = null;
            try
            {
                Sql = @"select t.* from t_cp_execplanvar t where t.varid = ?";
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = varId;
                svc.lngGetDataTableWithParameters(Sql, ref dtMain, parm);

                Sql = @"select t.* from t_cp_execplanvardetail t where t.varid = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = varId;
                svc.lngGetDataTableWithParameters(Sql, ref dtDet, parm);
                svc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
        }
        #endregion

        #region 全院路径实施统计
        /// <summary>
        /// 全院路径实施统计
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cpId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCpStat1(string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("col1", typeof(string));
            dtResult.Columns.Add("col2", typeof(string));
            dtResult.Columns.Add("col3", typeof(string));
            dtResult.Columns.Add("col4", typeof(string));
            dtResult.Columns.Add("col5", typeof(string));
            dtResult.Columns.Add("col6", typeof(string));
            dtResult.Columns.Add("col7", typeof(string));
            dtResult.Columns.Add("col8", typeof(string));
            dtResult.Columns.Add("col9", typeof(string));
            dtResult.Columns.Add("col10", typeof(string));
            dtResult.Columns.Add("col11", typeof(string));
            dtResult.Columns.Add("col12", typeof(string));
            dtResult.Columns.Add("col13", typeof(string));
            dtResult.Columns.Add("col14", typeof(string));
            dtResult.Columns.Add("col15", typeof(string));
            dtResult.Columns.Add("col16", typeof(string));
            dtResult.Columns.Add("col17", typeof(string));
            dtResult.Columns.Add("col18", typeof(string));
            dtResult.Columns.Add("col19", typeof(string));
            dtResult.Columns.Add("col20", typeof(string));
            dtResult.Columns.Add("col21", typeof(string));
            dtResult.Columns.Add("col22", typeof(string));
            dtResult.Columns.Add("col23", typeof(string));
            beginDate += " 00:00:00";
            endDate += " 23:59:59";
            try
            {
                //-- 本月符合入径数
                Sql = @"select a.cpname, count(1) as nums
                          from t_opr_bih_register a
                         where (a.cpRecordDate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                         group by a.cpname  ";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate;
                parm[1].Value = endDate;
                DataTable dt0 = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt0, parm);

                //--  本月入径数                        
                Sql = @"select a.cpname, count(1) as nums
                          from t_cp_execplan a
                         where (a.begindate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                         group by a.cpname  ";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate;
                parm[1].Value = endDate;
                DataTable dt1 = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt1, parm);

                //-- 全部入径数                        
                Sql = @"select a.cpname, count(1) as nums from t_cp_execplan a group by a.cpname ";

                DataTable dt2 = null;
                svc.lngGetDataTableWithoutParameters(Sql, ref dt2);

                //-- 本月变异数                       
                Sql = @" select a.cpname, count(1) as nums
                          from t_cp_execplan a
                         inner join t_cp_execplanvar b
                            on a.execid = b.execid
                         where (a.begindate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                         group by a.cpname ";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate;
                parm[1].Value = endDate;
                DataTable dt3 = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt3, parm);

                //-- 全部变异数                        
                Sql = @"select a.cpname, count(1) as nums
                          from t_cp_execplan a
                         inner join t_cp_execplanvar b
                            on a.execid = b.execid
                         group by a.cpname "; ;

                DataTable dt4 = null;
                svc.lngGetDataTableWithoutParameters(Sql, ref dt4);

                //-- 本月出径数                        
                Sql = @"select a.cpname, count(1) as nums
                          from t_cp_execplan a
                         inner join t_cp_out b
                            on a.execid = b.outid
                         where (b.outdate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss')) 
                         group by a.cpname ";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate;
                parm[1].Value = endDate;
                DataTable dt5 = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt5, parm);

                //-- 全部出径数
                Sql = @"select a.cpname, count(1) as nums
                          from t_cp_execplan a
                         inner join t_cp_out b
                            on a.execid = b.outid 
                         group by a.cpname ";
                DataTable dt6 = null;
                svc.lngGetDataTableWithoutParameters(Sql, ref dt6);

                if (dt0 != null && dt0.Rows.Count > 0)
                {
                    string cpName = string.Empty;
                    DataRow[] drr = null;
                    dtResult.BeginInit();
                    foreach (DataRow dr in dt0.Rows)
                    {
                        cpName = dr["cpname"].ToString();
                        DataRow drNew = dtResult.NewRow();
                        drNew["col1"] = cpName;
                        drNew["col2"] = dr["nums"];
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            drr = dt1.Select("cpname = '" + cpName + "'");
                            if (drr != null && drr.Length > 0)
                                drNew["col3"] = drr[0]["nums"].ToString();
                        }
                        drNew["col4"] = "";
                        drNew["col5"] = "";
                        if (dt2 != null && dt2.Rows.Count > 0)
                        {
                            drr = dt2.Select("cpname = '" + cpName + "'");
                            if (drr != null && drr.Length > 0)
                                drNew["col6"] = drr[0]["nums"].ToString();
                        }
                        drNew["col7"] = "";
                        if (dt3 != null && dt3.Rows.Count > 0)
                        {
                            drr = dt3.Select("cpname = '" + cpName + "'");
                            if (drr != null && drr.Length > 0)
                                drNew["col8"] = drr[0]["nums"].ToString();
                        }
                        drNew["col9"] = "";
                        if (dt4 != null && dt4.Rows.Count > 0)
                        {
                            drr = dt4.Select("cpname = '" + cpName + "'");
                            if (drr != null && drr.Length > 0)
                                drNew["col10"] = drr[0]["nums"].ToString();
                        }
                        drNew["col11"] = "";
                        if (dt5 != null && dt5.Rows.Count > 0)
                        {
                            drr = dt5.Select("cpname = '" + cpName + "'");
                            if (drr != null && drr.Length > 0)
                                drNew["col12"] = drr[0]["nums"].ToString();
                        }
                        drNew["col13"] = "";
                        if (dt6 != null && dt6.Rows.Count > 0)
                        {
                            drr = dt6.Select("cpname = '" + cpName + "'");
                            if (drr != null && drr.Length > 0)
                                drNew["col14"] = drr[0]["nums"].ToString();
                        }
                        drNew["col15"] = "";
                        drNew["col16"] = "";
                        drNew["col17"] = "";
                        drNew["col18"] = "";
                        drNew["col19"] = "";
                        drNew["col20"] = "";
                        drNew["col21"] = "";
                        drNew["col22"] = "";
                        drNew["col23"] = "";
                        dtResult.Rows.Add(drNew);
                    }
                    dtResult.EndInit();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dtResult;
        }
        #endregion

        #region 单路径统计
        /// <summary>
        /// 单路径统计
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cpId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCpStat2(string beginDate, string endDate, int cpId)
        {
            string Sql = string.Empty;
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("col1", typeof(string));
            dtResult.Columns.Add("col2", typeof(string));
            dtResult.Columns.Add("col3", typeof(string));
            dtResult.Columns.Add("col4", typeof(string));
            dtResult.Columns.Add("col5", typeof(string));
            dtResult.Columns.Add("col6", typeof(string));
            dtResult.Columns.Add("col7", typeof(string));
            dtResult.Columns.Add("col8", typeof(string));
            dtResult.Columns.Add("col9", typeof(string));
            dtResult.Columns.Add("col10", typeof(string));
            dtResult.Columns.Add("col11", typeof(string));
            dtResult.Columns.Add("col12", typeof(string));
            dtResult.Columns.Add("col13", typeof(string));
            dtResult.Columns.Add("col14", typeof(string));
            beginDate += " 00:00:00";
            endDate += " 23:59:59";
            try
            {
                Sql = @"select a.execid,
                               a.registerid,
                               b.inpatientid_chr as ipno,
                               b.cpstatus,
                               b.inareadate_dat as indate,
                               c.lastname_vchr as patname,
                               c.sex_chr as sex,
                               c.birth_dat as birthday,
                               '' as isvar,
                               d.outhospital_dat as outdate,
                               0 as indays,
                               0 as totalmny,
                               0 as medmny,
                               '' as medscale,
                               nvl(f.outinfo, '') as outdesc
                          from t_cp_execplan a
                         inner join t_opr_bih_register b
                            on a.registerid = b.registerid_chr
                         inner join t_opr_bih_registerdetail c
                            on a.registerid = c.registerid_chr
                          left join t_opr_bih_leave d
                            on a.registerid = d.registerid_chr
                           and d.status_int = 1
                          left join t_cp_out f
                            on a.execid = f.outid
                         where a.cpid = ?
                           and (a.begindate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = cpId;
                parm[1].Value = beginDate;
                parm[2].Value = endDate;
                DataTable dt1 = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt1, parm);

                Sql = @"select a.execid, a.registerid, b.varcontent
                          from t_cp_execplan a
                         inner join t_cp_execplanvar b
                            on a.execid = b.execid
                         where b.status = 1
                           and a.cpid = ? 
                           and (a.begindate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = cpId;
                parm[1].Value = beginDate;
                parm[2].Value = endDate;
                DataTable dt2 = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt2, parm);

                Sql = @"select a.registerid,
                               sum(round(b.amount_dec * b.unitprice_dec, 2) +
                                   round(nvl(b.totaldiffcostmoney_dec, 0), 2)) as totalmny
                          from t_cp_execplan a
                         inner join t_opr_bih_patientcharge b
                            on a.registerid = b.registerid_chr
                         where b.status_int = 1
                           and a.cpid = ? 
                           and (a.begindate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                        group by a.registerid";

                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = cpId;
                parm[1].Value = beginDate;
                parm[2].Value = endDate;
                DataTable dt3 = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt3, parm);

                Sql = @"select a.registerid,
                               sum(round(b.amount_dec * b.unitprice_dec, 2) +
                                   round(nvl(b.totaldiffcostmoney_dec, 0), 2)) as totalmny
                          from t_cp_execplan a
                         inner join t_opr_bih_patientcharge b
                            on a.registerid = b.registerid_chr
                         inner join t_bse_chargeitemextype c
                            on b.invcateid_chr = c.typeid_chr
                           and c.flag_int = 4
                         where b.status_int = 1
                           and c.typeid_chr in ('3008', '3010', '3012')
                           and a.cpid = ?
                           and (a.begindate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                        group by a.registerid";

                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = cpId;
                parm[1].Value = beginDate;
                parm[2].Value = endDate;
                DataTable dt4 = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt4, parm);

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    decimal decTotal = 0;
                    decimal decMed = 0;
                    DataRow[] drr = null;
                    clsBrithdayToAge calcAge = new clsBrithdayToAge();
                    dtResult.BeginInit();
                    foreach (DataRow dr in dt1.Rows)
                    {
                        decTotal = 0;
                        decMed = 0;
                        // 住院号  姓  名  性别  "年龄(岁)"  入径  （是/否）  变异    （是/否）  出径    （是/否）  出院日期  入院日期  "住院天数"  总费用  药费  药品比例  "出径及变异原因分析和说明"
                        DataRow drNew = dtResult.NewRow();
                        drNew["col1"] = dr["ipno"].ToString();
                        drNew["col2"] = dr["patname"].ToString();
                        drNew["col3"] = dr["sex"].ToString();
                        if (dr["birthday"] != DBNull.Value) drNew["col4"] = calcAge.m_strGetAge(Convert.ToDateTime(dr["birthday"].ToString()));
                        drNew["col5"] = "是";
                        drNew["col6"] = "否";
                        drNew["col7"] = Convert.ToInt32(dr["cpstatus"].ToString()) == 2 ? "是" : "否";
                        if (dr["outdate"] != DBNull.Value) drNew["col8"] = Convert.ToDateTime(dr["outdate"].ToString()).ToString("yyyy-MM-dd");
                        drNew["col9"] = Convert.ToDateTime(dr["indate"].ToString()).ToString("yyyy-MM-dd");
                        drNew["col10"] = dr["outdate"] != DBNull.Value ? Convert.ToDateTime(dr["outdate"].ToString()).Subtract(Convert.ToDateTime(dr["indate"].ToString())).Days.ToString() : DateTime.Now.Subtract(Convert.ToDateTime(dr["indate"].ToString())).Days.ToString();
                        if (dt3 != null && dt3.Rows.Count > 0)
                        {
                            drr = dt3.Select("registerid = '" + dr["registerid"].ToString() + "'");
                            if (drr != null && drr.Length > 0)
                            {
                                decTotal = Convert.ToDecimal(drr[0]["totalmny"].ToString());
                                drNew["col11"] = decTotal.ToString();
                            }
                            else
                                drNew["col11"] = "";
                        }
                        else
                        {
                            drNew["col11"] = "";
                        }
                        if (dt4 != null && dt4.Rows.Count > 0)
                        {
                            drr = dt4.Select("registerid = '" + dr["registerid"].ToString() + "'");
                            if (drr != null && drr.Length > 0)
                            {
                                decMed = Convert.ToDecimal(drr[0]["totalmny"].ToString());
                                drNew["col12"] = decMed.ToString();
                            }
                            else
                                drNew["col12"] = "";
                        }
                        else
                        {
                            drNew["col12"] = "";
                        }
                        if (decTotal > 0 && decMed > 0)
                        {
                            drNew["col13"] = Math.Round((decMed / decTotal) * 100, 2).ToString() + "%";
                        }
                        else
                        {
                            drNew["col13"] = "";
                        }
                        drNew["col14"] = dr["outdesc"].ToString();
                        // 变异
                        if (dt2 != null && dt2.Rows.Count > 0)
                        {
                            drr = dt2.Select("registerid = '" + dr["registerid"].ToString() + "'");
                            if (drr != null && drr.Length > 0)
                            {
                                drNew["col6"] = "是";
                                string varStr = string.Empty;
                                foreach (DataRow drVar in drr)
                                {
                                    varStr += drVar["varcontent"].ToString() + " ";
                                }
                                drNew["col14"] = varStr + dr["outdesc"].ToString();
                            }
                        }
                        dtResult.Rows.Add(drNew);
                    }
                    dtResult.EndInit();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return dtResult;
        }
        #endregion

        #region 获取出院带药医嘱
        /// <summary>
        /// 获取出院带药医嘱
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetOutMedicine(string registerId)
        {
            DataTable dt = null;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                string Sql = @"select  d.medicinetypeid_chr,
                                       b.amount_dec,
                                       b.unitprice_dec,
                                       a.dosageunit_chr,
                                       d.medicinename_vchr,
                                       d.mednormalname_vchr,
                                       d.isanaesthesia_chr,
                                       d.ischlorpromazine_chr,
                                       d.ischlorpromazine2_chr,
                                       d.ispoison_chr,
                                       a.orderid_chr, 
                                       a.get_dec,
                                       a.outgetmeddays_int,
                                       a.dosage_dec,
                                       a.execfreqname_chr,
                                       a.spec_vchr,
                                       round(b.amount_dec * b.unitprice_dec, 2) as totalmny,
                                       a.getunit_chr,
                                       a.dosetypename_chr,
                                       e.opusagedesc,
                                       f.opfredesc_vchr,
                                       f.days_int,
                                       f.times_int,
                                       a.dosageunit_chr,
                                       a.postdate_dat, 
                                       a.parentid_chr, 
                                       a.remark_vchr,
                                       a.recipeno_int, 
                                       a.poster_chr    
                                  from t_opr_bih_order a
                                 inner join t_opr_bih_orderchargedept b
                                    on a.orderid_chr = b.orderid_chr
                                 inner join t_bse_chargeitem c
                                    on b.chargeitemid_chr = c.itemid_chr
                                 inner join t_bse_medicine d
                                    on c.itemsrcid_vchr = d.medicineid_chr
                                 inner join t_bse_usagetype e
                                    on a.dosetypeid_chr = e.usageid_chr
                                 inner join t_aid_recipefreq f
                                    on a.execfreqid_chr = f.freqid_chr
                                 where a.registerid_chr = ?
                                   and a.executetype_int = 3
                                   and a.status_int >= 1 
                                order by a.orderid_chr ";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = registerId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region 获取出院带药人基本资料
        /// <summary>
        /// 获取出院带药人基本资料
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetOutPatient(string patientId)
        {
            DataTable dt = null;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                string Sql = @"select t.idcard_chr, t.homeaddress_vchr, t.insuranceid_vchr, t.govcard_chr from t_bse_patient t where t.patientid_chr = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = patientId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region 获取麻醉药品医嘱--处方打印数据
        /// <summary>
        /// 获取麻醉药品医嘱--处方打印数据
        /// </summary>
        /// <param name="orderIdArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetAneMedicine(string orderIdArr)
        {
            DataTable dt = null;
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                string Sql = @"select  d.medicinetypeid_chr,
                                       (b.amount_dec / nvl(f.times_int, 1)) as amount_dec,
                                       b.unitprice_dec,
                                       a.dosageunit_chr,
                                       d.medicinename_vchr,
                                       d.mednormalname_vchr,
                                       d.isanaesthesia_chr,
                                       d.ischlorpromazine_chr,
                                       d.ischlorpromazine2_chr,
                                       d.ispoison_chr,
                                       a.orderid_chr,
                                       (a.get_dec / nvl(f.times_int, 1)) as get_dec,
                                       a.outgetmeddays_int,
                                       a.dosage_dec,
                                       a.execfreqname_chr,
                                       a.spec_vchr,
                                       round((b.amount_dec / nvl(f.times_int, 1)) * b.unitprice_dec, 2) as totalmny,
                                       a.getunit_chr,
                                       a.dosetypename_chr,
                                       e.opusagedesc,
                                       f.opfredesc_vchr,
                                       f.days_int,
                                       f.times_int,
                                       a.dosageunit_chr,
                                       a.postdate_dat,
                                       a.parentid_chr,
                                       a.remark_vchr,
                                       a.recipeno_int,
                                       a.poster_chr
                                  from t_opr_bih_order a
                                 inner join t_opr_bih_orderchargedept b
                                    on a.orderid_chr = b.orderid_chr
                                 inner join t_bse_chargeitem c
                                    on b.chargeitemid_chr = c.itemid_chr
                                 inner join t_bse_medicine d
                                    on c.itemsrcid_vchr = d.medicineid_chr
                                 inner join t_bse_usagetype e
                                    on a.dosetypeid_chr = e.usageid_chr
                                 inner join t_aid_recipefreq f
                                    on a.execfreqid_chr = f.freqid_chr
                                 where a.orderid_chr in ({0})
                                   and a.status_int >= 1
                                   and d.isanaesthesia_chr = 'T'
                                 order by a.orderid_chr";

                svc.lngGetDataTableWithoutParameters(string.Format(Sql, orderIdArr), ref dt);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #endregion

        #region 特殊抗菌药物会诊

        #region 获取历史记录
        /// <summary>
        /// 获取历史记录
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetSadcHistory(string registerId)
        {
            DataTable dt = null;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = registerId;
            try
            {
                Sql = @"select t.applydate, t.applyid, t.status
                          from t_opr_bih_sadcapply t
                         where t.registerid = ?
                           and t.status >= 0
                         order by t.applydate desc";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region 获取抗菌药物会诊申请记录
        /// <summary>
        /// 获取抗菌药物会诊申请记录
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtResponse"></param>
        [AutoComplete]
        public void GetSadcRecord(decimal applyId, out DataTable dtMain, out DataTable dtResponse)
        {
            string Sql = string.Empty;
            dtMain = new DataTable();
            dtResponse = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select * from t_opr_bih_sadcapply t where t.applyid = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = applyId;
                svc.lngGetDataTableWithParameters(Sql, ref dtMain, parm);

                if (dtMain != null && dtMain.Rows.Count > 0)
                {
                    Sql = @"select * from t_opr_bih_sadcexperts t where t.applyid = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = applyId;
                    svc.lngGetDataTableWithParameters(Sql, ref dtResponse, parm);
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
        }
        #endregion

        #region 获取抗菌药物会诊回复记录
        /// <summary>
        /// 获取抗菌药物会诊回复记录
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="expertId"></param>
        /// <returns></returns>
        [AutoComplete]
        public EntityBihSadcExperts GetSadcResponse(decimal applyId, string expertId)
        {
            string Sql = string.Empty;
            EntityBihSadcExperts vo = null;
            DataTable dt = null;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select * from t_opr_bih_sadcexperts t where t.applyid = ? and t.expertid = ?";
                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = applyId;
                parm[1].Value = expertId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    vo = new EntityBihSadcExperts();
                    vo.applyid = Convert.ToDecimal(dr["applyid"].ToString());
                    vo.deptid = dr["deptid"].ToString();
                    vo.deptname = dr["deptname"].ToString();
                    vo.expertid = dr["expertid"].ToString();
                    vo.expertname = dr["expertname"].ToString();
                    vo.responsedesc = dr["responsedesc"].ToString();
                    if (dr["responsedate"] == DBNull.Value)
                        vo.responsedate = null;
                    else
                        vo.responsedate = Convert.ToDateTime(dr["responsedate"].ToString());
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return vo;
        }
        #endregion

        #region 保存申请
        /// <summary>
        /// 保存申请
        /// </summary>
        /// <param name="applyVo"></param>
        /// <param name="lstExperts"></param>
        /// <param name="applyId"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SaveSadcApply(EntityBihSadcApply applyVo, List<EntityBihSadcExperts> lstExperts, out decimal applyId)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            applyId = 0;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            DataTable dt = null;
            try
            {
                if (applyVo.applyid == 0)
                {
                    Sql = "select seq_sadcapplyid.nextval from dual";
                    svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                    applyId = Convert.ToDecimal(dt.Rows[0][0].ToString());
                }
                else
                {
                    applyId = applyVo.applyid;
                    Sql = @"delete from t_opr_bih_sadcapply where applyid = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = applyId;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);

                    Sql = @"delete from t_opr_bih_sadcexperts where applyid = ?";
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = applyId;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                }
                foreach (EntityBihSadcExperts item in lstExperts)
                {
                    item.applyid = applyId;
                }

                #region Sql-申请
                Sql = @"insert into t_opr_bih_sadcapply
                              (applyid,
                               registerid,
                               applyoperid,
                               applyopername,
                               applydeptid,
                               applydeptname,
                               applydate,
                               drugname,
                               pathcheck,
                               pathdesc,
                               clinicdiag,
                               medhistory,
                               applyreason,
                               directorid,
                               directorname,
                               directoropinion,
                               directorsigndate,
                               recorddate,
                               status)
                            values
                              (?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                               ?, ?, ?, ?, ?, ?, ?, ?, ?) ";

                int n = -1;
                svc.CreateDatabaseParameter(19, out parm);
                parm[++n].Value = applyId;
                parm[++n].Value = applyVo.registerid;
                parm[++n].Value = applyVo.applyoperid;
                parm[++n].Value = applyVo.applyopername;
                parm[++n].Value = applyVo.applydeptid;
                parm[++n].Value = applyVo.applydeptname;
                parm[++n].Value = applyVo.applydate;
                parm[++n].Value = applyVo.drugname;
                parm[++n].Value = applyVo.pathcheck;
                parm[++n].Value = applyVo.pathdesc;
                parm[++n].Value = applyVo.clinicdiag;
                parm[++n].Value = applyVo.medhistory;
                parm[++n].Value = applyVo.applyreason;
                parm[++n].Value = applyVo.directorid;
                parm[++n].Value = applyVo.directorname;
                parm[++n].Value = applyVo.directoropinion;
                if (applyVo.directorsigndate == null)
                    parm[++n].Value = null;
                else
                    parm[++n].Value = applyVo.directorsigndate.Value;
                parm[++n].Value = DateTime.Now;
                parm[++n].Value = applyVo.status;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                #endregion

                #region Sql-专家

                Sql = @"insert into t_opr_bih_sadcexperts
                              (applyid,
                               expertid,
                               expertname,
                               deptid,
                               deptname,
                               responsedesc,
                               responsedate)
                            values
                              (?, ?, ?, ?, ?, ?, ?)";
                foreach (EntityBihSadcExperts item in lstExperts)
                {
                    n = -1;
                    svc.CreateDatabaseParameter(7, out parm);
                    parm[++n].Value = applyId;
                    parm[++n].Value = item.expertid;
                    parm[++n].Value = item.expertname;
                    parm[++n].Value = item.deptid;
                    parm[++n].Value = item.deptname;
                    parm[++n].Value = item.responsedesc;
                    if (item.responsedate == null)
                        parm[++n].Value = null;
                    else
                        parm[++n].Value = item.responsedate.Value;
                    svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                }
                #endregion

            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 取消申请(删除)
        /// <summary>
        /// 取消申请(删除)
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        [AutoComplete]
        public int CancelSadcApply(decimal applyId)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"update t_opr_bih_sadcapply set status = ? where applyid = ? ";
                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = -1;
                parm[1].Value = applyId;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 保存回复内容
        /// <summary>
        /// 保存回复内容
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SaveSadcResponse(EntityBihSadcExperts vo)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"update t_opr_bih_sadcexperts
                           set responsedesc = ?, responsedate = ?
                         where applyid = ?
                           and expertid = ?";

                int n = -1;
                svc.CreateDatabaseParameter(4, out parm);
                parm[++n].Value = vo.responsedesc;
                parm[++n].Value = vo.responsedate.Value;
                parm[++n].Value = vo.applyid;
                parm[++n].Value = vo.expertid;
                svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 人员ID
        /// <summary>
        /// 人员ID
        /// </summary>
        /// <param name="empName"></param>
        /// <returns></returns>
        [AutoComplete]
        public string GetEmployeeId(string empName)
        {
            string empId = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            DataTable dt = null;
            string Sql = @"select t.empid_chr, t.lastname_vchr from t_bse_employee t where trim(t.lastname_vchr) = ?";
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = empName;
            svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            if (dt != null && dt.Rows.Count > 0)
            {
                empId = dt.Rows[0]["empid_chr"].ToString();
            }
            return empId;
        }
        #endregion

        #region 人员DataTable
        /// <summary>
        /// 人员DataTable
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetEmployeeByEmpId(string empId)
        {
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            DataTable dt = null;
            string Sql = @"select a.empid_chr,
                                   a.empno_chr,
                                   a.lastname_vchr,
                                   a.technicalrank_chr,
                                   a.status_int,
                                   c.deptid_chr,
                                   c.deptname_vchr
                              from t_bse_employee a
                             inner join t_bse_deptemp b
                                on a.empid_chr = b.empid_chr
                             inner join t_bse_deptdesc c
                                on b.deptid_chr = c.deptid_chr
                             where a.empid_chr = ? 
                               and a.status_int >= 0
                               and b.default_inpatient_dept_int = 1";
            svc.CreateDatabaseParameter(1, out parm);
            parm[0].Value = empId;
            svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
            if (dt != null) dt.TableName = "employee";
            return dt;
        }
        #endregion

        #endregion

        #region 疗程用药、预发药

        #region 获取预发药信息
        /// <summary>
        /// 获取预发药信息
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="areaId"></param>
        /// <returns></returns>
        [AutoComplete]
        public List<EntityPretestMed> GetPretestMed(string beginDate, string endDate, string areaId)
        {
            List<EntityPretestMed> data = new List<EntityPretestMed>();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                string Sql = @"select 0 as sortNo,
                                       a.areaid_chr as deptId, 
                                       a.putmeddetailid_chr as putMedId,
                                       (case b.status_int
                                         when -2 then
                                          '删除'
                                         when -1 then
                                          '作废'
                                         when 0 then
                                          '创建'
                                         when 1 then
                                          '提交'
                                         when 2 then
                                          '执行'
                                         when 3 then
                                          '停止'
                                         when 4 then
                                          '重整'
                                         when 5 then
                                          '审核提交'
                                         when 6 then
                                          '审核停止'
                                         when 7 then
                                          '退回'
                                       end) as orderStatus,
                                       d.deptname_vchr as deptName,
                                       e.bed_no as bedNo,
                                       c.lastname_vchr as patName,
                                       a.pubdate_dat as preDate,
                                       x.creator_chr as nurse,
                                       b.orderid_chr as orderId,  
                                       b.name_vchr as orderName,
                                       b.orderdicid_chr as orderDicId, 
                                       b.dosetypename_chr as usageName,
                                       f.freqname_chr as freqName,
                                       (a.get_dec * a.pretestdays / (a.pretestdays + 1)) as preAmount,
                                       a.unit_vchr as unit,
                                       (case p.status
                                         when -1 then
                                          '拒收'
                                         when 0 then
                                          '未回收'
                                         when 1 then
                                          '已回收'
                                         else
                                          ''
                                       end) as recStatus,
                                       m.lastname_vchr as recOperName,
                                       p.recorddate as recDate,
                                       p.remark as reMark
                                  from t_bih_opr_putmeddetail a
                                 inner join t_opr_bih_order b
                                    on a.orderid_chr = b.orderid_chr
                                 inner join t_opr_bih_orderexecute x
                                    on a.orderexecid_chr = x.orderexecid_chr
                                 inner join t_bse_patient c
                                    on a.paientid_chr = c.patientid_chr
                                 inner join t_bse_deptdesc d
                                    on a.areaid_chr = d.deptid_chr
                                 inner join t_bse_bed e
                                    on a.bedid_chr = e.bedid_chr
                                 inner join t_aid_recipefreq f
                                    on b.execfreqid_chr = f.freqid_chr
                                  left join t_pretestmed p
                                    on a.putmeddetailid_chr = p.putmeddetailid_chr
                                  left join t_bse_employee m
                                    on m.empid_chr = p.operid
                                 where (a.pubdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')) 
                                   {0}
                                   and a.pretestdays > 0";

                if (string.IsNullOrEmpty(areaId))
                {
                    Sql = string.Format(Sql, "");
                    svc.CreateDatabaseParameter(2, out parm);
                    parm[0].Value = beginDate;
                    parm[1].Value = endDate;
                }
                else
                {
                    Sql = string.Format(Sql, "and a.areaid_chr = ? ");
                    svc.CreateDatabaseParameter(3, out parm);
                    parm[0].Value = beginDate;
                    parm[1].Value = endDate;
                    parm[2].Value = areaId;
                }
                DataTable dt = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int no = 0;
                    EntityPretestMed vo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        vo = new EntityPretestMed();
                        vo.sortNo = ++no;
                        vo.orderStatus = dr["orderStatus"].ToString();
                        vo.deptId = dr["deptId"].ToString();
                        vo.deptName = dr["deptName"].ToString();
                        vo.bedNo = dr["bedNo"].ToString();
                        vo.patName = dr["patName"].ToString();
                        vo.preDate = Convert.ToDateTime(dr["preDate"]).ToString("yyyy-MM-dd HH:mm");
                        vo.nurse = dr["nurse"].ToString();
                        vo.orderId = dr["orderId"].ToString();
                        vo.orderName = dr["orderName"].ToString();
                        vo.usageName = dr["usageName"] == DBNull.Value ? "" : dr["usageName"].ToString().Trim();
                        vo.freqName = dr["freqName"] == DBNull.Value ? "" : dr["freqName"].ToString().Trim();
                        vo.preAmount = Convert.ToDecimal(dr["preAmount"].ToString());
                        vo.unit = dr["unit"].ToString();
                        vo.recStatus = dr["recStatus"].ToString();
                        vo.recOperName = dr["recOperName"].ToString();
                        vo.recDate = dr["recDate"] == DBNull.Value ? "" : Convert.ToDateTime(dr["recDate"]).ToString("yyyy-MM-dd HH:mm");
                        vo.recRemark = dr["reMark"].ToString();
                        vo.putMedId = dr["putMedId"].ToString();
                        vo.orderDicId = dr["orderDicId"].ToString();
                        data.Add(vo);
                    }
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return data;
        }
        #endregion

        #region 保存预发回收信息
        /// <summary>
        /// 保存预发回收信息
        /// </summary>
        /// <param name="lstRec"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SavePretestMedRec(List<EntityPretestMedRec> lstRec)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                DbType[] dbTypes = null;
                object[][] objValues = null;
                IDataParameter[] parm = null;

                #region 自动退药

                string putId = string.Empty;
                foreach (EntityPretestMedRec item in lstRec)
                {
                    putId += "'" + item.putMedId + "',";
                }

                Sql = @"select a.putmeddetailid_chr,
                               a.recipeno_int,
                               a.unitprice_mny,
                               a.unit_vchr,
                               a.get_dec,
                               (a.get_dec * nvl(a.pretestdays,0) / (nvl(a.pretestdays,0) + 1)) as preAmount,
                               a.isput_int,
                               a.pubdate_dat,
                               c.medicineid_chr,
                               c.medicinename_vchr,
                               c.medspec_vchr,
                               c.assistcode_chr,
                               c.packqty_dec,
                               c.ipchargeflg_int,
                               c.medicinetypeid_chr,
                               a.medstoreid_chr,
                               a.examreturnmed_int,
                               a.examreturnmed_dat,
                               a.registerid_chr,
                               a.areaid_chr,
                               a.registerid_chr,
                               d.deptid_chr as drugstoreid_chr
                          from t_bih_opr_putmeddetail a
                         inner join t_bse_medicine c
                            on a.medid_chr = c.medicineid_chr
                         inner join t_bse_medstore d
                            on a.medstoreid_chr = d.medstoreid_chr
                         where a.putmeddetailid_chr in ({0})";

                DataTable dtReturn = null;
                svc.lngGetDataTableWithoutParameters(string.Format(Sql, putId.TrimEnd(',')), ref dtReturn);

                // 1.
                Sql = @"select a.seriesid_int, a.iprealgross_int, a.oprealgross_int
                          from t_ds_storage_detail a
                         where a.drugstoreid_chr = ?
                           and a.medicineid_chr = ?
                         order by a.validperiod_dat desc";

                dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Int64 };
                objValues = new object[5][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[dtReturn.Rows.Count];
                }
                DataRow dr = null;
                DataTable dtTmp = null;
                for (int i = 0; i < dtReturn.Rows.Count; i++)
                {
                    dr = dtReturn.Rows[i];
                    if (dr["ipchargeflg_int"].ToString() == "0")
                    {
                        objValues[0][i] = Convert.ToDouble(dr["preAmount"]) * Convert.ToDouble(dr["packqty_dec"]);
                        objValues[1][i] = Convert.ToDouble(dr["preAmount"]);
                        objValues[2][i] = Convert.ToDouble(dr["preAmount"]) * Convert.ToDouble(dr["packqty_dec"]);
                        objValues[3][i] = Convert.ToDouble(dr["preAmount"]);
                    }
                    else
                    {
                        objValues[0][i] = Convert.ToDouble(dr["preAmount"]);
                        objValues[1][i] = Math.Round(Convert.ToDouble(dr["preAmount"]) / Convert.ToDouble(dr["packqty_dec"]), 4); ;
                        objValues[2][i] = Convert.ToDouble(dr["preAmount"]);
                        objValues[3][i] = Math.Round(Convert.ToDouble(dr["preAmount"]) / Convert.ToDouble(dr["packqty_dec"]), 4); ;
                    }

                    svc.CreateDatabaseParameter(2, out parm);
                    parm[0].Value = dr["drugstoreid_chr"].ToString();
                    parm[1].Value = dr["medicineid_chr"].ToString();
                    svc.lngGetDataTableWithParameters(Sql, ref dtTmp, parm);
                    objValues[4][i] = Convert.ToInt64(dtTmp.Rows[0]["seriesid_int"]);     // 库存补到最新有效期第一个药品
                }
                Sql = @"update t_ds_storage_detail a
                           set a.iprealgross_int      = a.iprealgross_int - ?,
                               a.oprealgross_int      = a.oprealgross_int - ?,
                               a.ipavailablegross_num = a.ipavailablegross_num - ?,
                               a.opavailablegross_num = a.opavailablegross_num - ?
                         where a.seriesid_int = ?";

                svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref affectRows, dbTypes);

                // 2.
                dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String };
                objValues = new object[4][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[dtReturn.Rows.Count];//初始化
                }

                for (int k1 = 0; k1 < dtReturn.Rows.Count; k1++)
                {
                    dr = dtReturn.Rows[k1];
                    if (dr["ipchargeflg_int"].ToString() == "0")
                    {
                        objValues[0][k1] = Convert.ToDouble(dr["preAmount"]) * Convert.ToDouble(dr["packqty_dec"]);
                        objValues[1][k1] = Convert.ToDouble(dr["preAmount"]);
                    }
                    else
                    {
                        objValues[0][k1] = Convert.ToDouble(dr["preAmount"]);
                        objValues[1][k1] = Math.Round(Convert.ToDouble(dr["preAmount"]) / Convert.ToDouble(dr["packqty_dec"]), 4);
                    }
                    objValues[2][k1] = dr["drugstoreid_chr"].ToString();
                    objValues[3][k1] = dr["medicineid_chr"].ToString();
                }
                Sql = @"update t_ds_storage a
                           set a.ipcurrentgross_num = a.ipcurrentgross_num - ?,
                               a.opcurrentgross_num = a.opcurrentgross_num - ?
                         where a.drugstoreid_chr = ?
                           and a.medicineid_chr = ?";

                svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref affectRows, dbTypes);

                #endregion

                // 3.
                Sql = @"insert into t_pretestmed (putmeddetailid_chr, operid, recorddate, remark, status)
                        values (?, ?, ?, ?, ?)";

                dbTypes = new DbType[] { DbType.String, DbType.String, DbType.Date, DbType.String, DbType.Int32 };
                objValues = new object[5][];

                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[lstRec.Count];
                }

                int n = 0;
                for (int i = 0; i < lstRec.Count; i++)
                {
                    n = -1;
                    objValues[++n][i] = lstRec[i].putMedId;
                    objValues[++n][i] = lstRec[i].recOperId;
                    objValues[++n][i] = Convert.ToDateTime(lstRec[i].recDate);
                    objValues[++n][i] = lstRec[i].recRemark;
                    objValues[++n][i] = lstRec[i].recStatus;
                }
                if (lstRec.Count > 0)
                {
                    affectRows = svc.m_lngSaveArrayWithParameters(Sql, objValues, dbTypes);
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 获取疗程用药信息
        /// <summary>
        /// 获取疗程用药信息
        /// </summary>
        /// <param name="orderIdArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public List<EntityCureMed> GetCureMed2(string orderIdArr)
        {
            List<EntityCureMed> data = new List<EntityCureMed>();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                string Sql = @"select a.registerid_chr as registerid,
                                       a.orderid_chr as orderId,
                                       a.name_vchr as orderName,
                                       (a.get_dec * a.curedays) as preAmount,
                                       oc.clacarea_chr as execDeptId
                                  from t_opr_bih_order a
                                 inner join t_bse_bih_orderdic ob
                                    on a.orderdicid_chr = ob.orderdicid_chr
                                 inner join t_opr_bih_orderchargedept oc
                                    on a.orderid_chr = oc.orderid_chr
                                   and ob.itemid_chr = oc.chargeitemid_chr
                                 where a.orderid_chr in ({0})
                                   and (a.checkstate is null or a.checkstate = 0)
                                   and a.curedays > 0";

                DataTable dt = null;
                svc.lngGetDataTableWithoutParameters(string.Format(Sql, orderIdArr), ref dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    EntityCureMed vo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        vo = new EntityCureMed();
                        vo.registerId = dr["registerid"].ToString();
                        vo.orderId = dr["orderId"].ToString();
                        vo.orderName = dr["orderName"].ToString();
                        vo.preAmount = Convert.ToDecimal(dr["preAmount"].ToString());
                        vo.execDeptId = dr["execDeptId"].ToString();
                        data.Add(vo);
                    }
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
            }
            return data;
        }
        #endregion

        #region 获取疗程用药信息
        /// <summary>
        /// 获取疗程用药信息
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public List<EntityCureMed> GetCureMed(string beginDate, string endDate)
        {
            List<EntityCureMed> data = new List<EntityCureMed>();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                string Sql = @"select 0 as sortNo,
                                   c.deptid_chr as deptId,
                                   c.deptname_vchr as deptName,
                                   d.bed_no as bedNo,
                                   b.lastname_vchr as patName,
                                   a.registerid_chr as registerid,
                                   a.postdate_dat as orderDate,
                                   a.orderid_chr as orderId,
                                   a.name_vchr as orderName,
                                   a.orderdicid_chr as orderDicId,
                                   a.dosetypename_chr as usageName,
                                   e.freqname_chr as freqName,
                                   a.curedays as cureDays,
                                   (a.get_dec * a.curedays) as preAmount,
                                   a.getunit_chr as unit,
                                   (case a.checkstate
                                     when -1 then
                                      '不通过'
                                     when 0 then
                                      '待审'
                                     when 1 then
                                      '通过'
                                   end) as checkState,
                                   f.lastname_vchr as checkOperName,
                                   a.checkdate as checkDate,
                                   oc.clacarea_chr as execDeptId
                              from t_opr_bih_order a
                             inner join t_bse_bih_orderdic ob
                                on a.orderdicid_chr = ob.orderdicid_chr
                             inner join t_opr_bih_orderchargedept oc
                                on a.orderid_chr = oc.orderid_chr
                               and ob.itemid_chr = oc.chargeitemid_chr
                             inner join t_bse_patient b
                                on a.patientid_chr = b.patientid_chr
                             inner join t_bse_deptdesc c
                                on a.curareaid_chr = c.deptid_chr
                             inner join t_bse_bed d
                                on a.curbedid_chr = d.bedid_chr
                             inner join t_aid_recipefreq e
                                on a.execfreqid_chr = e.freqid_chr
                              left join t_bse_employee f
                                on a.checkoperid = f.empid_chr
                             where (a.postdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                               and a.curedays > 0";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate;
                parm[1].Value = endDate;
                DataTable dt = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int no = 0;
                    EntityCureMed vo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        vo = new EntityCureMed();
                        vo.sortNo = ++no;
                        vo.registerId = dr["registerid"].ToString();
                        vo.deptId = dr["deptId"].ToString();
                        vo.deptName = dr["deptName"].ToString();
                        vo.bedNo = dr["bedNo"].ToString();
                        vo.patName = dr["patName"].ToString();
                        vo.orderDate = Convert.ToDateTime(dr["orderDate"]).ToString("yyyy-MM-dd HH:mm");
                        vo.orderId = dr["orderId"].ToString();
                        vo.orderName = dr["orderName"].ToString();
                        vo.usageName = dr["usageName"] == DBNull.Value ? "" : dr["usageName"].ToString().Trim();
                        vo.freqName = dr["freqName"] == DBNull.Value ? "" : dr["freqName"].ToString().Trim();
                        vo.cureDays = dr["cureDays"].ToString();
                        vo.preAmount = Convert.ToDecimal(dr["preAmount"].ToString());
                        vo.unit = dr["unit"].ToString();
                        vo.checkState = dr["checkState"].ToString();
                        vo.checkOperName = dr["checkOperName"].ToString();
                        vo.checkDate = dr["checkDate"] == DBNull.Value ? "" : Convert.ToDateTime(dr["checkDate"]).ToString("yyyy-MM-dd HH:mm");
                        vo.orderDicId = dr["orderDicId"].ToString();
                        vo.execDeptId = dr["execDeptId"].ToString();
                        data.Add(vo);
                    }
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return data;
        }
        #endregion

        #region 保存疗程用药审核信息
        /// <summary>
        /// 保存疗程用药审核信息
        /// </summary>
        /// <param name="lstMed"></param>
        /// <param name="lstSubStock"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SaveCureMedConfirm(List<EntityCureMed> lstMed, List<EntityCureSubStock> lstSubStock)
        {
            long affectRows = 0;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"update t_opr_bih_order t
                           set t.checkstate  = ?,
                               t.checkoperid = ?,
                               t.checkdate   = ?,
                               t.preamount   = ?,
                               t.preamount2  = ?
                         where t.orderid_chr = ?";

                DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.String, DbType.Date, DbType.Decimal, DbType.Decimal, DbType.String };
                object[][] objValues = new object[6][];
                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[lstMed.Count];
                }
                int n = 0;
                for (int i = 0; i < lstMed.Count; i++)
                {
                    n = -1;
                    objValues[++n][i] = lstMed[i].checkState;
                    objValues[++n][i] = lstMed[i].checkOperName;
                    objValues[++n][i] = Convert.ToDateTime(lstMed[i].checkDate);
                    objValues[++n][i] = lstMed[i].preAmount;    // 疗程天数.预扣数量
                    objValues[++n][i] = lstMed[i].preAmount;    // 疗程天数.预扣数量2(预扣量剩余)
                    objValues[++n][i] = lstMed[i].orderId;
                }
                if (lstMed.Count > 0)
                {
                    affectRows = svc.m_lngSaveArrayWithParameters(Sql, objValues, dbTypes);
                }

                Sql = @"update t_ds_storage_detail a
                           set a.iprealgross_int      = a.iprealgross_int - ?,
                               a.ipavailablegross_num = a.ipavailablegross_num - ?,
                               a.oprealgross_int      = a.oprealgross_int - ?,
                               a.opavailablegross_num = a.opavailablegross_num - ?
                         where a.seriesid_int = ?";

                dbTypes = new DbType[] { DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.Decimal };
                objValues = new object[5][];
                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[lstSubStock.Count];
                }
                n = 0;
                for (int i = 0; i < lstSubStock.Count; i++)
                {
                    n = -1;
                    objValues[++n][i] = lstSubStock[i].ipAmountReal;
                    objValues[++n][i] = lstSubStock[i].ipAmountVir;
                    objValues[++n][i] = lstSubStock[i].opAmountReal;
                    objValues[++n][i] = lstSubStock[i].opAmountVir;
                    objValues[++n][i] = lstSubStock[i].serSid;
                }
                if (lstSubStock.Count > 0)
                {
                    affectRows = svc.m_lngSaveArrayWithParameters(Sql, objValues, dbTypes);

                    List<string> lstTmpId = new List<string>();
                    EntityCureSubStock mainVo = null;
                    List<EntityCureSubStock> lstMainStock = new List<EntityCureSubStock>();
                    for (int i = 0; i < lstSubStock.Count; i++)
                    {
                        mainVo = new EntityCureSubStock();
                        mainVo.storeId = lstSubStock[i].storeId;
                        mainVo.medId = lstSubStock[i].medId;
                        mainVo.opAmountReal = lstSubStock[i].opAmountReal;
                        mainVo.ipAmountReal = lstSubStock[i].ipAmountReal;
                        if (lstTmpId.IndexOf(mainVo.storeId + mainVo) >= 0) continue;
                        for (int j = i + 1; j < lstSubStock.Count; j++)
                        {
                            if (mainVo.storeId == lstSubStock[j].storeId && mainVo.medId == lstSubStock[j].medId)
                            {
                                mainVo.opAmountReal += lstSubStock[j].opAmountReal;
                                mainVo.ipAmountReal += lstSubStock[j].ipAmountReal;
                            }
                        }
                        lstMainStock.Add(mainVo);
                        lstTmpId.Add(mainVo.storeId + mainVo.medId);
                    }

                    Sql = @"update t_ds_storage a
                               set a.ipcurrentgross_num = a.ipcurrentgross_num - ?,
                                   a.opcurrentgross_num = a.opcurrentgross_num - ?
                             where a.drugstoreid_chr = ?
                               and a.medicineid_chr = ?";

                    dbTypes = new DbType[] { DbType.Decimal, DbType.Decimal, DbType.String, DbType.String };
                    objValues = new object[4][];
                    for (int i = 0; i < objValues.Length; i++)
                    {
                        objValues[i] = new object[lstMainStock.Count];
                    }
                    n = 0;
                    for (int i = 0; i < lstMainStock.Count; i++)
                    {
                        n = -1;
                        objValues[++n][i] = lstMainStock[i].ipAmountReal;
                        objValues[++n][i] = lstMainStock[i].opAmountReal;
                        objValues[++n][i] = lstMainStock[i].storeId;
                        objValues[++n][i] = lstMainStock[i].medId;
                    }
                    affectRows = svc.m_lngSaveArrayWithParameters(Sql, objValues, dbTypes);

                    Sql = @"insert into t_curemedsubtract
                              (serno,
                               registerid,
                               orderid,
                               storeid,
                               medid,
                               seriesid,
                               ipamountreal,
                               opamountreal,
                               ipamountre,
                               opamountre)
                            values
                              (seq_curemedsubtract.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.Decimal };
                    objValues = new object[9][];
                    for (int i = 0; i < objValues.Length; i++)
                    {
                        objValues[i] = new object[lstSubStock.Count];
                    }
                    n = 0;
                    for (int i = 0; i < lstSubStock.Count; i++)
                    {
                        n = -1;
                        objValues[++n][i] = lstSubStock[i].registerId;
                        objValues[++n][i] = lstSubStock[i].orderId;
                        objValues[++n][i] = lstSubStock[i].storeId;
                        objValues[++n][i] = lstSubStock[i].medId;
                        objValues[++n][i] = lstSubStock[i].serSid;
                        objValues[++n][i] = lstSubStock[i].ipAmountReal;
                        objValues[++n][i] = lstSubStock[i].opAmountReal;
                        objValues[++n][i] = lstSubStock[i].ipAmountReal;
                        objValues[++n][i] = lstSubStock[i].opAmountReal;
                    }
                    affectRows = svc.m_lngSaveArrayWithParameters(Sql, objValues, dbTypes);
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
            }
            return (int)affectRows;
        }
        #endregion

        #region 根据OrderId查询药品Id
        /// <summary>
        /// 根据OrderId查询药品Id
        /// </summary>
        /// <param name="lstOrderId"></param>
        /// <returns></returns>
        [AutoComplete]
        public Dictionary<string, string> GetMedIdByOrderId(List<string> lstOrderId)
        {
            Dictionary<string, string> dicMedId = new Dictionary<string, string>();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                string Sql = @"select a.orderid_chr as orderId, d.medicineid_chr as medId
                                  from t_opr_bih_order a
                                 inner join t_bse_bih_orderdic b
                                    on a.orderdicid_chr = b.orderdicid_chr
                                 inner join t_bse_chargeitem c
                                    on b.itemid_chr = c.itemid_chr
                                 inner join t_bse_medicine d
                                    on c.itemsrcid_vchr = d.medicineid_chr
                                 where a.orderid_chr in ({0})";

                string orderId = string.Empty;
                foreach (string item in lstOrderId)
                {
                    orderId += "'" + item + "',";
                }
                Sql = string.Format(Sql, orderId.TrimEnd(','));
                DataTable dt = null;
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!dicMedId.ContainsKey(dr["orderId"].ToString()))
                        {
                            dicMedId.Add(dr["orderId"].ToString(), dr["medId"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(ex);
            }
            finally
            {
                svc = null;
            }
            return dicMedId;
        }
        #endregion

        #endregion

    }
    #endregion

}
