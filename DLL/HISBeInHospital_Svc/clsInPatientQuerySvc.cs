using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.middletier.HIS
{
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsInPatientQuerySvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
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
				where ATTRIBUTEID = '0000003'
					and Status_Int = 1 [FindCondition]
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
                    arrArea[i].m_strAreaID = Convert.ToString(objDT.Rows[i]["DeptID_Chr"]).Trim();
                    arrArea[i].m_strAreaName = Convert.ToString(objDT.Rows[i]["DeptName_VChr"]).Trim();
                    arrArea[i].code = Convert.ToString(objDT.Rows[i]["code_vchr"].ToString().Trim());

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

        #region 查询病人信息
        [AutoComplete]
        public long m_lngGetPatientByCondition(string InPatientID_Chr,string Name_VChr,string AreaID_Chr,string DOCTORID_CHR,string PSTATUS_INT,string STATE_INT,string PayTypeID_Chr,string REMARKID_CHR,DateTime m_dtStart,DateTime m_dtFinish,out clsBIHPatientInfo[] m_ArrobjPatient)
        {
           
            m_ArrobjPatient = new clsBIHPatientInfo[0];
            string strSql = @"
            select * from (
                select  
                a.RegisterID_Chr,a.PatientID_Chr,a.InPatientID_Chr,a.InPatient_Dat,
                a.DeptID_Chr,a.AreaID_Chr,a.BedID_Chr,a.Diagnose_Vchr,a.InPatientCount_Int,a.ICD10DIAGTEXT_VCHR,
                b.Name_VChr,b.Sex_Chr,b.Birth_Dat,
                a.PayTypeID_Chr,
                c.Code_Chr BedName,d.DeptName_VChr AreaName,a.limitrate_mny
                ,e.flgname_vchr  AS PSTATUS_Name
                ,e2.flgname_vchr AS state_Name
                ,mzdiagnose_vchr
                ,f.PAYTYPENAME_VCHR PayTypeName_VChr
                ,sysdate today
                ,g.REMARKNAME_VCHR
                ,a.DES_VCHR
                ,a.CASEDOCTOR_CHR DOCTORID_CHR
                ,h.LastName_Vchr  DOCTOR_VCHR
                ,g.REMARKID_CHR
                ,a.STATE_INT
                ,a.PSTATUS_INT
            ,(SELECT h.name_chr AS eatdiccate
            FROM t_bse_bih_orderdic h,
                 t_opr_bih_order i,
                 t_bse_bih_specordercate j
           WHERE h.orderdicid_chr = i.orderdicid_chr
             AND h.ordercateid_chr = j.nursecate
             AND i.status_int = 2
             AND ROWNUM = 1
             AND i.registerid_chr = b.registerid_chr) nursecate
             ,(SELECT h.name_chr AS eatdiccate
            FROM t_bse_bih_orderdic h,
                 t_opr_bih_order i,
                 t_bse_bih_specordercate j
           WHERE h.orderdicid_chr = i.orderdicid_chr
             AND h.ordercateid_chr = j.eatdiccate
             AND i.status_int = 2
             AND ROWNUM = 1
             AND i.registerid_chr = b.registerid_chr) eatdiccate
                from T_Opr_BIH_Register a,
                t_opr_bih_registerdetail b ,
                T_BSE_Bed c,
                T_BSE_DeptDesc d,
                (select flg_int,flgname_vchr from  t_sys_flg_table where tablename_vchr = 't_opr_bih_register' and columnname_vchr = 'PSTATUS_INT') e,
                 (select flg_int,flgname_vchr from  t_sys_flg_table where tablename_vchr = 't_opr_bih_register' and columnname_vchr = 'STATE_INT') e2,
                ( select tf.* from T_BSE_PatientPayType tf where tf.isusing_num=1 and tf.payflag_dec!=1)  f,
                T_OPR_BIH_PATSPECREMARK g,
                 t_bse_employee h
                where a.REGISTERID_CHR=b.REGISTERID_CHR(+)
                and a.Status_Int=1
                
                --and c.BedID_Chr='[BedIDValue]'
                and a.REGISTERID_CHR=c.BIHREGISTERID_CHR(+)
                and a.AreaID_Chr=d.DeptID_Chr(+)
                AND a.pstatus_int = e.flg_int(+)
                AND a.STATE_INT = e2.flg_int(+)
                and a.PayTypeID_Chr=f.PayTypeID_Chr(+)
                and a.REGISTERID_CHR=g.REGISTERID_CHR(+)
                and a.CASEDOCTOR_CHR=h.EMPID_CHR(+)
                order by a.InPatientCount_Int desc
                ) 
                where
                1=1
                and LOWER(Name_VChr) like ?
                and LOWER(InPatientID_Chr) like ?
                
                [AreaID_Chr]
                [DOCTORID_CHR]
                [PSTATUS_INT]
                [STATE_INT]
                [PayTypeID_Chr]
                [REMARKID_CHR]
                [INPATIENT_DAT]
                ";
            /*<----------------------------------------------*/
         
           
           
            if (!AreaID_Chr.Trim().Equals(""))
            {
                strSql = strSql.Replace("[AreaID_Chr]", " and AreaID_Chr='" + AreaID_Chr.Trim() + "' ");
            }
            else
            {
                strSql = strSql.Replace("[AreaID_Chr]", "");
            }
            if (!DOCTORID_CHR.Trim().Equals(""))
            {
                strSql = strSql.Replace("[DOCTORID_CHR]", " and DOCTORID_CHR='" + DOCTORID_CHR.Trim() + "' ");
            }
            else
            {
                strSql = strSql.Replace("[DOCTORID_CHR]", "");
            }
            if (!PSTATUS_INT.Trim().Equals(""))
            {
                strSql = strSql.Replace("[PSTATUS_INT]", " and PSTATUS_INT='" + PSTATUS_INT.Trim() + "' ");
            }
            else
            {
                strSql = strSql.Replace("[PSTATUS_INT]", "");
            }
            if (!STATE_INT.Trim().Equals(""))
            {
                strSql = strSql.Replace("[STATE_INT]", " and STATE_INT='" + STATE_INT.Trim() + "' ");
            }
            else
            {
                strSql = strSql.Replace("[STATE_INT]", "");
            }
            if (!PayTypeID_Chr.Trim().Equals(""))
            {
                strSql = strSql.Replace("[PayTypeID_Chr]", " and PayTypeID_Chr='" + PayTypeID_Chr.Trim() + "' ");
            }
            else
            {
                strSql = strSql.Replace("[PayTypeID_Chr]", "");
            }
            if (!REMARKID_CHR.Trim().Equals(""))
            {
                strSql = strSql.Replace("[REMARKID_CHR]", " and REMARKID_CHR='" + REMARKID_CHR.Trim() + "' ");
            }
            else
            {
                strSql = strSql.Replace("[REMARKID_CHR]", "");

            }
            if (m_dtStart != DateTime.MinValue && m_dtFinish != DateTime.MinValue)
            {
                strSql = strSql.Replace("[INPATIENT_DAT]", " and (round(INPATIENT_DAT)>=round(to_date('" + m_dtStart.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')) and round(INPATIENT_DAT)<=round(to_date('" + m_dtFinish.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'))) ");
            }
            else
            {
                strSql = strSql.Replace("[INPATIENT_DAT]", "");
            }
           
           


            DataTable objDT = new DataTable();
            clsHRPTableService HRPService = new clsHRPTableService();
            long ret = 0;
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = "%" + Name_VChr.ToLower().Trim() + "%";
                arrParams[1].Value = "%"+InPatientID_Chr.ToLower().Trim()+"%";

                ret = 0;
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                if ((ret > 0) && (objDT != null) && (objDT.Rows.Count > 0))
                {
                    m_ArrobjPatient = new clsBIHPatientInfo[objDT.Rows.Count];
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        m_mthGetPatientInfoFromDateTable(objDT.Rows[i], out m_ArrobjPatient[i]);
                    }
                    //add by wjqin()加上相应的预交金,已用金等状态.
                    //--PreMoney 预交金额
                    //-- PreUseMoney 已用金额(发生的所有费用)
                    //--ClearMoney已清金额
                    //-- 结余金额=可用预交金(NotUsePreMoney)-已用金额(发生的所有费用)

//                    strSql = @"
//                    select * from 
//                    (select sum(round(a.money_dec,2)) PreMoney from t_opr_bih_prepay a where a.registerid_chr='[registerid]')a,
//                    --(select sum(a.money_dec) PreUseMoney from t_opr_bih_prepay a where a.registerid_chr='[registerid]' and a.isclear_int=1)b,
//                    (select sum(round(a.money_dec,2)) NotUsePreMoney from t_opr_bih_prepay a where a.registerid_chr='[registerid]' and a.isclear_int=0)c,
//                    (select sum(round(a.unitprice_dec,2)*round(a.amount_dec,2)) WaitMoney  from t_opr_bih_patientcharge a where  a.registerid_chr='[registerid]' and a.pstatus_int=1) d,
//                    (select sum(round(a.unitprice_dec,2)*round(a.amount_dec,2)) WaitClearMoney from t_opr_bih_patientcharge a where a.registerid_chr='[registerid]' and a.pstatus_int=2) e,
//                    (select sum(round(a.unitprice_dec,2)*round(a.amount_dec,2)) ClearMoney from t_opr_bih_patientcharge a where a.registerid_chr='[registerid]' and a.pstatus_int=3) f,
//                    (select sum(round(a.unitprice_dec,2)*round(a.amount_dec,2)) PreUseMoney from t_opr_bih_patientcharge a where a.registerid_chr='[registerid]' and a.pstatus_int!=0) b
//                  
//                    ";
                 
//                    strSql = strSql.Replace("[registerid]", objPatient.m_strRegisterID.ToString().Trim());
//                    ret = HRPService.DoGetDataTable(strSql, ref objDT);
//                    decimal PreMoney = 0, PreUseMoney = 0, NotUsePreMoney = 0, WaitMoney = 0, WaitClearMoney = 0, ClearMoney = 0;
//                    if (objDT.Rows.Count > 0)
//                    {
//                        if (!objDT.Rows[0]["PreMoney"].ToString().Trim().Equals(""))
//                        {
//                            PreMoney = decimal.Parse(objDT.Rows[0]["PreMoney"].ToString().Trim());
//                        }
//                        if (!objDT.Rows[0]["PreUseMoney"].ToString().Trim().Equals(""))
//                        {
//                            PreUseMoney = decimal.Parse(objDT.Rows[0]["PreUseMoney"].ToString().Trim());
//                        }
//                        if (!objDT.Rows[0]["NotUsePreMoney"].ToString().Trim().Equals(""))
//                        {
//                            NotUsePreMoney = decimal.Parse(objDT.Rows[0]["NotUsePreMoney"].ToString().Trim());
//                        }
//                        if (!objDT.Rows[0]["WaitMoney"].ToString().Trim().Equals(""))
//                        {
//                            WaitMoney = decimal.Parse(objDT.Rows[0]["WaitMoney"].ToString().Trim());
//                        }
//                        if (!objDT.Rows[0]["WaitClearMoney"].ToString().Trim().Equals(""))
//                        {
//                            WaitClearMoney = decimal.Parse(objDT.Rows[0]["WaitClearMoney"].ToString().Trim());
//                        }
//                        if (!objDT.Rows[0]["ClearMoney"].ToString().Trim().Equals(""))
//                        {
//                            ClearMoney = decimal.Parse(objDT.Rows[0]["ClearMoney"].ToString().Trim());
//                        }
//                        objPatient.m_decPreMoney = PreMoney;
//                        objPatient.m_decPreUseMoney = PreUseMoney;
//                        objPatient.m_decClearMoney = ClearMoney;

//                        //objPatient.m_decPrePayMoney = PreMoney - PreUseMoney;
//                        objPatient.m_decPrePayMoney = NotUsePreMoney - WaitMoney - WaitClearMoney;

                    //}

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
        private void m_mthGetPatientInfoFromDateTable(DataRow objRow, out clsBIHPatientInfo objPatient)
        {
            objPatient = null;
            if (objRow == null) return;

            objPatient = new clsBIHPatientInfo();
            objPatient.m_strRegisterID = Convert.ToString(objRow["RegisterID_Chr"]).Trim();
            objPatient.m_strPatientID = Convert.ToString(objRow["PatientID_Chr"]).Trim();
            objPatient.m_strInHospitalNo = Convert.ToString(objRow["InPatientID_Chr"]).Trim();
            if (!objRow["InPatient_Dat"].ToString().Trim().Equals(""))
            objPatient.m_dtInHospital = Convert.ToDateTime(objRow["InPatient_Dat"]);
            objPatient.m_strDeptID = Convert.ToString(objRow["DeptID_Chr"]).Trim();
            objPatient.m_strAreaID = Convert.ToString(objRow["AreaID_Chr"]).Trim();

            objPatient.m_strAreaName = Convert.ToString(objRow["AreaName"]).Trim();
            objPatient.m_strBedID = Convert.ToString(objRow["BedID_Chr"]).Trim();
            objPatient.m_strBedName = Convert.ToString(objRow["BedName"]).Trim();
            /** update by xzf (05-09-29) */
            //@ objPatient.m_strDiagnose=Convert.ToString(objRow["Diagnose_Vchr"]).Trim();
            objPatient.m_strDiagnose = Convert.ToString(objRow["ICD10DIAGTEXT_VCHR"]).Trim();
            /* <<============================= */
            if(!objRow["InPatientCount_Int"].ToString().Trim().Equals(""))
            objPatient.m_intInTimes = int.Parse(objRow["InPatientCount_Int"].ToString());
            objPatient.m_strPatientName = Convert.ToString(objRow["Name_VChr"]).Trim();

            objPatient.m_strSex = Convert.ToString(objRow["Sex_Chr"]).Trim();
            if (!objRow["Birth_Dat"].ToString().Trim().Equals(""))
            objPatient.m_dtBorn = Convert.ToDateTime(objRow["Birth_Dat"]);
            objPatient.m_strPayTypeID = Convert.ToString(objRow["PayTypeID_Chr"]).Trim();
            objPatient.m_strPayTypeName = Convert.ToString(objRow["PayTypeName_VChr"]).Trim();
            objPatient.m_strInpatientState = Convert.ToString(objRow["PSTATUS_Name"]).Trim();
            objPatient.m_strSTATE_INT = Convert.ToString(objRow["state_Name"]).Trim();
            
            objPatient.m_strMzdiagnose_vchr = Convert.ToString(objRow["mzdiagnose_vchr"]).Trim();
            objPatient.m_strDiagnose_vchr = Convert.ToString(objRow["diagnose_vchr"]).Trim();
            if (objRow["limitrate_mny"] != System.DBNull.Value)
            {
                objPatient.m_dblLIMITRATE_MNY = double.Parse(objRow["limitrate_mny"].ToString());
            }
            TimeSpan span1 = Convert.ToDateTime(objRow["today"].ToString().Trim()) - objPatient.m_dtBorn;
            objPatient.m_intAge = span1.Days / 365;
            objPatient.m_strREMARKNAME_VCHR = objRow["REMARKNAME_VCHR"].ToString().Trim();
            objPatient.m_strDES_VCHR = objRow["DES_VCHR"].ToString().Trim();
            objPatient.m_strDOCTORID_CHR = objRow["DOCTORID_CHR"].ToString().Trim();
            objPatient.m_strDOCTOR_VCHR = objRow["DOCTOR_VCHR"].ToString().Trim();
            objPatient.m_strEatdiccate=objRow["eatdiccate"].ToString().Trim();
            objPatient.m_strNursecate=objRow["nursecate"].ToString().Trim();
        }

        #endregion

    }
}
