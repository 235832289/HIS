using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    ////////////////////////////加上继承代码//////////////////
    /// <summary>
    /// 门诊收费中间件
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsOPChargeSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsOPChargeSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 查找药品
        [AutoComplete]
        public long m_mthFindMedicineByID(string strType, string ID, string strPatientTypeID, out DataTable dt, System.Security.Principal.IPrincipal p_objPrincipal, string strEmployID)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindMedicineByID");
            if (lngRes < 0)
            {
                return -1;
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"
				select	A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,A.ITEMENGNAME_VCHR,A.ITEMCODE_VCHR as TempItemCode, a.insuranceid_chr, 
						A.ITEMOPUNIT_CHR,A.ITEMPRICE_MNY,A.ITEMOPINVTYPE_CHR,A.ITEMCATID_CHR,A.SELFDEFINE_INT,A.ITEMCODE_VCHR,A.ITEMOPCALCTYPE_CHR,A.DOSAGE_DEC,A.DOSAGEUNIT_CHR,f.precent_dec ,
						B.NOQTYFLAG_INT,A." + strType + @" type,a.itemipunit_chr, ROUND (a.itemprice_mny / a.packqty_dec, 4) submoney, a.opchargeflg_int,a.ITEMUNIT_CHR as Unit from t_bse_chargeitem A ,T_BSE_MEDICINE B,  (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f
				where  trim(A.ITEMSRCID_VCHR)=trim(B.MEDICINEID_CHR(+)) and a.IFSTOP_INT =0 AND ( Upper(A." + strType + ") LIKE ? or upper(A.ITEMCODE_VCHR) LIKE ? or upper(A.ITEMOPCODE_CHR) LIKE ?) and a.itemid_chr =f.itemid_chr(+)  order by  A.ITEMCODE_VCHR";
            if (ID.StartsWith(@"/"))//查找常用药
            {
                strSQL = @"
				select	A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,A.ITEMENGNAME_VCHR,A.ITEMCODE_VCHR as TempItemCode, a.insuranceid_chr, 
						A.ITEMOPUNIT_CHR,A.ITEMPRICE_MNY,A.ITEMOPINVTYPE_CHR,A.ITEMCATID_CHR,A.SELFDEFINE_INT,A.ITEMCODE_VCHR,A.ITEMOPCALCTYPE_CHR,A.DOSAGE_DEC,A.DOSAGEUNIT_CHR,f.precent_dec ,
						B.NOQTYFLAG_INT,A." + strType + @" type,a.itemipunit_chr, ROUND (a.itemprice_mny / a.packqty_dec, 4) submoney, a.opchargeflg_int,a.ITEMUNIT_CHR as Unit from t_bse_chargeitem A ,T_BSE_MEDICINE B, 
						(SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f,
						(SELECT * FROM t_aid_comusechargeitem  WHERE createrid_chr = ? AND type_int = 1
						UNION
						SELECT a.*  FROM t_aid_comusechargeitem a,
						(SELECT a.deptid_chr FROM t_bse_deptemp a  WHERE a.end_dat IS NULL AND a.empid_chr = ?) b
						WHERE a.deptid_chr = b.deptid_chr AND type_int = 1) g
				where  trim(A.ITEMSRCID_VCHR)=trim(B.MEDICINEID_CHR(+)) and a.IFSTOP_INT =0  
						AND a.itemid_chr = g.itemid_chr
						and upper(a." + strType + @") like ? 
						and a.itemid_chr =f.itemid_chr(+)  order by  A.ITEMCODE_VCHR";

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = strEmployID;
                ParamArr[2].Value = strEmployID;
                ParamArr[3].Value = ID.Replace("/", "") + "%";
            }
            else
            {
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = ID + "%";
                ParamArr[2].Value = ID + "%";
                ParamArr[3].Value = ID + "%";
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        public long m_mthFindMedicineByID(string p_strFindString, out DataTable p_dtResult, System.Security.Principal.IPrincipal p_objPrincipal)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindMedicineByID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select   a.*, b.noqtyflag_int, b.ifstop_int,
         round (a.itemprice_mny / a.packqty_dec, 4) submoney
    from t_bse_chargeitem a, t_bse_medicine b
   where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
     and a.ifstop_int = 0
     and (   (lower (a.itemname_vchr) like ?)
          or (lower (a.itemcode_vchr) like ?)
          or (lower (a.itempycode_chr) like ?)
          or (lower (a.itemwbcode_chr) like ?)
         )
order by a.itemcatid_chr
							";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = "%" + p_strFindString.Trim().ToLower() + "%";
                ParamArr[1].Value = "%" + p_strFindString.Trim().ToLower() + "%";
                ParamArr[2].Value = "%" + p_strFindString.Trim().ToLower() + "%";
                ParamArr[3].Value = "%" + p_strFindString.Trim().ToLower() + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, ParamArr);
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

        #region  保存处方主表
        /// <summary>
        /// 保存处方主表
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="clsVO"></param>
        /// <param name="p_strID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthAddRecipeMain(System.Security.Principal.IPrincipal objPri, clsOutPatientRecipe_VO clsVO, out string p_strID)
        {
            if (clsVO.m_strOutpatRecipeID.Trim() != "")
            {
                m_mthDeleteRecipeDetail(clsVO.m_strOutpatRecipeID.Trim());
                p_strID = clsVO.m_strOutpatRecipeID;
            }
            else
            {
                p_strID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                clsVO.m_strOutpatRecipeID = p_strID;
            }

            long lngRes = 0, lngAffects = 0;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthAddRecipeMain");
            if (lngRes < 0)
                return lngRes;

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            try
            {

                string strSQL = @"insert into t_opr_outpatientrecipe
            (outpatrecipeid_chr, patientid_chr, createdate_dat,
             registerid_chr, diagdr_chr, diagdept_chr, recordemp_chr,
             recorddate_dat, pstauts_int, paytypeid_chr, recipeflag_int
            )
           values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
             ?, ?, ?, ?,
             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?
            )";

                objHRPSvc.CreateDatabaseParameter(11, out ParamArr);
                ParamArr[0].Value = clsVO.m_strOutpatRecipeID;
                ParamArr[1].Value = clsVO.m_strPatientID;
                ParamArr[2].Value = clsVO.m_strCreateDate;
                ParamArr[3].Value = clsVO.m_strRegisterID;
                ParamArr[4].Value = clsVO.m_strDoctorID;
                ParamArr[5].Value = clsVO.m_strDepID;
                ParamArr[6].Value = clsVO.m_strOperatorID;
                ParamArr[7].Value = clsVO.m_strRecordDate;
                ParamArr[8].Value = clsVO.m_intPStatus;
                ParamArr[9].Value = clsVO.m_strPatientType;
                ParamArr[10].Value = clsVO.m_intType;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                //更改身份证号
                strSQL = @"update t_bse_patient 
								set idcard_chr = ? 								
							where patientid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = clsVO.strIDcard;
                ParamArr[1].Value = clsVO.m_strPatientID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                //处理患者身份对应号表
                if (clsVO.m_strPatientType.Trim() != "")
                {
                    if (clsVO.strInsuranceID.Trim() == "")
                    {
                        clsVO.strInsuranceID = " ";
                    }

                    strSQL = "delete from t_bse_patientidentityno where patientid_chr = ? and paytypeid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = clsVO.m_strPatientID;
                    ParamArr[1].Value = clsVO.m_strPatientType;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    strSQL = @"insert into t_bse_patientidentityno(patientid_chr, paytypeid_chr, idno_vchr)
                                                    values (?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = clsVO.m_strPatientID;
                    ParamArr[1].Value = clsVO.m_strPatientType;
                    ParamArr[2].Value = clsVO.strInsuranceID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;

        }
        #endregion
        #region 获取当日流水号
        /// <summary>
        /// 获取当日流水号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strSerNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetSerNO(System.Security.Principal.IPrincipal p_objPrincipal, out string m_strSerNo)
        {
            DataTable p_dtResult = new DataTable();
            long lngRes = 0;
            m_strSerNo = string.Empty;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthGetSerNO");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select substr (to_char(seq_recipesendnum.nextval), -4) from dual ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                if (lngRes > 0 && p_dtResult.Rows.Count > 0)
                {
                    m_strSerNo = p_dtResult.Rows[0][0].ToString();
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
        #region 插入药品发送表
        /// <summary>
        /// 插入药品发送表
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="objVOMainArr"></param>
        /// <param name="objWMedicineSend"></param>
        /// <param name="objCMedicineSend"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSaveMedicineSend(System.Security.Principal.IPrincipal p_objPrincipal, ref ArrayList objVOMainArr, ref ArrayList objWMedicineSend, ref ArrayList objCMedicineSend)
        {
            long lngRes = 0;
            string m_strWSid = string.Empty;
            string strSQL = string.Empty;
            DataTable dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveMedicineSend");
            if (lngRes < 0)
                return -1;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            string pid = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strPatientID;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string recipeid = string.Empty;
            IDataParameter[] ParamArr = null;
            long lngAffects = -1;
            try
            {
                if (objCMedicineSend.Count >= 2)
                {
                    ArrayList m_objList = new ArrayList();
                    bool blnExisted = false;
                    for (int i = 0; i < objCMedicineSend.Count; i++)
                    {
                        blnExisted = false;
                        clsMedrecipesend_VO obj = objCMedicineSend[i] as clsMedrecipesend_VO;
                        if (i == 0)
                        {
                            m_objList.Add(obj);
                        }
                        else
                        {
                            for (int j = 0; j < m_objList.Count; j++)
                            {
                                clsMedrecipesend_VO objtemp = m_objList[j] as clsMedrecipesend_VO;
                                if (objtemp.m_strOUTPATRECIPEID_CHR == obj.m_strOUTPATRECIPEID_CHR && objtemp.m_strMedstroeID_CHR == obj.m_strMedstroeID_CHR && objtemp.m_strWINDOWID_CHR == obj.m_strWINDOWID_CHR)
                                {
                                    blnExisted = true;
                                    break;
                                }
                            }
                            if (blnExisted == false)
                            {
                                m_objList.Add(obj);
                            }
                        }

                    }
                    objCMedicineSend = m_objList;
                }
                foreach (clsMedrecipesend_VO objs in objCMedicineSend)
                {
                    strSQL = @"select seq_recipesendid.nextval from dual";
                    recipeid = objs.m_strOUTPATRECIPEID_CHR;
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                    if (lngRes > 0)
                    {
                        string sid = dt.Rows[0][0].ToString();

                        strSQL = @"insert into t_opr_recipesend
                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int)
                                       select ?, substr (to_char(seq_recipesendnum.nextval), -4), ?, ?, ?, ?, 1, 0
                                         from dual";

                        objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                        ParamArr[0].Value = sid;
                        ParamArr[1].Value = pid;
                        ParamArr[2].Value = date;
                        ParamArr[3].Value = objs.m_strMedstroeID_CHR;
                        ParamArr[4].Value = objs.m_strWINDOWID_CHR;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        strSQL = @"insert into t_opr_recipesendentry (sid_int, outpatrecipeid_chr) values (?, ?)";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = sid;
                        ParamArr[1].Value = recipeid;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        strSQL = @"insert into t_opr_medstorewinque (seq_int, windowid_chr, windowtype_int, medstoreid_chr, outpatrecipeid_chr, recipetype_chr, order_int, sid_int) 
                                                                 values (seq_medstore.nextval, ?, ?, ?, ?, ?, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(7, out ParamArr);
                        ParamArr[0].Value = objs.m_strWINDOWID_CHR;
                        ParamArr[1].Value = 1;
                        ParamArr[2].Value = objs.m_strMedstroeID_CHR;
                        ParamArr[3].Value = recipeid;
                        ParamArr[4].Value = objs.m_strRECIPETYPE_INT;
                        ParamArr[5].Value = Convert.ToInt32(objs.Sortno);
                        ParamArr[6].Value = sid;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }
                }
                if (objWMedicineSend.Count > 0)
                {
                    strSQL = @"select seq_recipesendid.nextval
                               from dual
                              ";
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                    if (lngRes > 0)
                    {
                        m_strWSid = dt.Rows[0][0].ToString();
                    }
                }
                foreach (clsMedrecipesend_VO objs in objWMedicineSend)
                {
                    recipeid = objs.m_strOUTPATRECIPEID_CHR;
                    strSQL = @"insert into t_opr_recipesendentry (sid_int, outpatrecipeid_chr) values (?, ?)";
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = m_strWSid;
                    ParamArr[1].Value = recipeid;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    strSQL = @"insert into t_opr_medstorewinque (seq_int, windowid_chr, windowtype_int, medstoreid_chr, outpatrecipeid_chr, recipetype_chr, order_int, sid_int) 
                                                                 values (seq_medstore.nextval, ?, ?, ?, ?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(7, out ParamArr);
                    ParamArr[0].Value = objs.m_strWINDOWID_CHR;
                    ParamArr[1].Value = 1;
                    ParamArr[2].Value = objs.m_strMedstroeID_CHR;
                    ParamArr[3].Value = recipeid;
                    ParamArr[4].Value = objs.m_strRECIPETYPE_INT;
                    ParamArr[5].Value = Convert.ToInt32(objs.Sortno);
                    ParamArr[6].Value = m_strWSid;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                }
                if (objWMedicineSend.Count > 0)
                {

                    strSQL = @"insert into t_opr_recipesend
                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int)
                                                 values(?,?,?,?,?,?,1,0)";
                    //select ?, substr (to_char(seq_recipesendnum.nextval), -4), ?, ?, ?, ?, 1, 0
                    //  from dual";
                    clsMedrecipesend_VO objs = objWMedicineSend[0] as clsMedrecipesend_VO;
                    objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                    ParamArr[0].Value = m_strWSid;
                    ParamArr[1].Value = ((clsMedrecipesend_VO)objWMedicineSend[0]).m_strSerNO;
                    ParamArr[2].Value = pid;
                    ParamArr[3].Value = date;
                    ParamArr[4].Value = objs.m_strMedstroeID_CHR;
                    ParamArr[5].Value = objs.m_strWINDOWID_CHR;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
            }
            catch (Exception objEx)
            {
                objVOMainArr.Clear();
                objWMedicineSend.Clear();
                objCMedicineSend.Clear();
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        #endregion

        #region 保存数据(统一保存)
        /// <summary>
        /// 保存数据(统一保存)
        /// </summary>
        /// <param name="objPri">权限</param>
        /// <param name="clsVO">主处方信息</param>
        /// <param name="strRecipeNo"></param>
        /// <param name="objRD_VO"></param>
        /// <param name="times"></param>
        /// <param name="objRD_VO"></param>
        /// <param name="objInvoice_VOArr"></param>
        /// <param name="objArr1"></param>
        /// <param name="objArr2"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSaveAllData(System.Security.Principal.IPrincipal objPri, ArrayList objVOMainArr, out string strRecipeNo,
            clsRecipeDetail_VO[] objRD_VO, decimal times, clsInvoice_VO[] objInvoice_VOArr, ArrayList[] objArr1, ArrayList[] objArr2, ArrayList objMedicineSend, out ArrayList m_objMedicineSend)
        {
            long lngRes = 0, lngAffects = 0;
            m_objMedicineSend = new ArrayList();
            strRecipeNo = "";
            try
            {
                #region 保存处方主表
                com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc objEmployeeSvc = new com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc();
                string strGroupID = "";
                DataTable tempDt;
                string strSQL = "";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                DataTable dt = new DataTable();

                foreach (clsOutPatientRecipe_VO objTempMain in objVOMainArr)
                {
                    lngRes = objEmployeeSvc.m_lngGetGroupEmp(objTempMain.m_strDoctorID, out tempDt);
                    if (lngRes > 0 && tempDt.Rows.Count > 0)
                    {
                        strGroupID = tempDt.Rows[0]["groupid_chr"].ToString();
                    }
                    this.m_mthDeleteRecipeDetail(objTempMain.m_strOutpatRecipeID.Trim());

                    com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
                    lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveAllData");
                    if (lngRes < 0)
                    {
                        return lngRes;
                    }

                    //处方号关联表                   
                    strSQL = @"select seqid, outpatrecipeid_chr from t_opr_reciperelation where seqid = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                    if (dt.Rows.Count > 0)
                    {
                        strSQL = @"update t_opr_reciperelation set mcflag_int = 1 where seqid = ?";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }
                    else
                    {
                        strSQL = @"insert into t_opr_reciperelation
                                                (seqid, outpatrecipeid_chr
                                                )
                                         values (?, ?
                                                )";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                        ParamArr[1].Value = objTempMain.m_strOutpatRecipeID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }

                    //处方主表
                    strSQL = @"insert into t_opr_outpatientrecipe
                                            (outpatrecipeid_chr, patientid_chr, createdate_dat,
                                             registerid_chr, diagdr_chr, diagdept_chr, recordemp_chr,
                                             recorddate_dat, pstauts_int, paytypeid_chr, recipeflag_int,
                                             groupid_chr, casehisid_chr, type_int, createtype_int, deptmed_int
                                            )
                                     values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
                                             ?, ?, ?, ?,
                                             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?,
                                             ?, ?, ?, ?, ?
                                            )";

                    objHRPSvc.CreateDatabaseParameter(16, out ParamArr);
                    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID;
                    ParamArr[1].Value = objTempMain.m_strPatientID;
                    ParamArr[2].Value = objTempMain.m_strCreateDate;
                    ParamArr[3].Value = objTempMain.m_strRegisterID;
                    ParamArr[4].Value = objTempMain.m_strDoctorID;
                    ParamArr[5].Value = objTempMain.m_strDepID;
                    ParamArr[6].Value = objTempMain.m_strOperatorID;
                    ParamArr[7].Value = DateTime.Now.ToString();
                    ParamArr[8].Value = objTempMain.m_intPStatus;
                    ParamArr[9].Value = objTempMain.m_strPatientType;
                    ParamArr[10].Value = objTempMain.m_intType;
                    ParamArr[11].Value = strGroupID;
                    ParamArr[12].Value = objTempMain.m_strCaseHistoryID;
                    ParamArr[13].Value = objTempMain.m_strRecipeType;
                    ParamArr[14].Value = objTempMain.intCreatetype;
                    ParamArr[15].Value = objTempMain.intDeptmed;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //根据处方号更新检验、检查等项目收费标志(已收费)
                    strSQL = @"update t_opr_attachrelation set status_int = 1 where sourceitemid_vchr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //更新患者身份证号、医保卡号
                    strSQL = @"update t_bse_patient 
								set idcard_chr = ?, 
									insuranceid_vchr = ?  
							where patientid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = objTempMain.strIDcard;
                    ParamArr[1].Value = objTempMain.strInsuranceID;
                    ParamArr[2].Value = objTempMain.m_strPatientID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //处理患者身份对应号表
                    if (objTempMain.m_strPatientType.Trim() != "")
                    {
                        if (objTempMain.strInsuranceID.Trim() == "")
                        {
                            objTempMain.strInsuranceID = " ";
                        }

                        strSQL = "delete from t_bse_patientidentityno where patientid_chr = ? and paytypeid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = objTempMain.m_strPatientID;
                        ParamArr[1].Value = objTempMain.m_strPatientType;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        strSQL = @"insert into t_bse_patientidentityno(patientid_chr, paytypeid_chr, idno_vchr) values (?, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                        ParamArr[0].Value = objTempMain.m_strPatientID;
                        ParamArr[1].Value = objTempMain.m_strPatientType;
                        ParamArr[2].Value = objTempMain.strInsuranceID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }

                    #region 保存药品发送表(旧)

                    //clsmedstorewinque objmedwin = new clsmedstorewinque();
                    //clsWindowsCortrol objwin = new clsWindowsCortrol();
                    foreach (clsMedrecipesend_VO item3 in objMedicineSend)
                    {
                        //						item3.m_strOUTPATRECIPEID_CHR =((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                        item3.m_strOUTPATRECIPEID_CHR = objTempMain.m_strOutpatRecipeID;
                        strSQL = @"insert into t_opr_medrecipesend
                                                (outpatrecipeid_chr, recipetype_int, medstoreid_chr,
                                                 windowid_chr, pstatus_int, senddate_dat, sendemp_chr
                                                )
                                         values (?, ?, ?,
                                                 ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?
                                                )";

                        objHRPSvc.CreateDatabaseParameter(7, out ParamArr);
                        ParamArr[0].Value = item3.m_strOUTPATRECIPEID_CHR;
                        ParamArr[1].Value = item3.m_strRECIPETYPE_INT;
                        ParamArr[2].Value = item3.m_strMedstroeID_CHR;
                        ParamArr[3].Value = item3.m_strWINDOWID_CHR;
                        ParamArr[4].Value = item3.m_intPSTATUS_INT;
                        ParamArr[5].Value = item3.m_strSENDDATE_DAT;
                        ParamArr[6].Value = item3.m_strSENDEMP_CHR;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                        m_objMedicineSend.Add(item3);
                        //发药队列
                        //objmedwin.m_strWINDOWID_CHR = item3.m_strWINDOWID_CHR;
                        //objmedwin.m_intWaitNO = Convert.ToInt32(item3.Sortno);
                        //objmedwin.m_intWINDOWTYPE_INT = 1;
                        //objmedwin.m_strMEDSTOREID_CHR = item3.m_strMedstroeID_CHR;
                        //objmedwin.m_strOUTPATRECIPEID_CHR = item3.m_strOUTPATRECIPEID_CHR;
                        //objmedwin.m_strRECIPETYPE_CHR = item3.m_strRECIPETYPE_INT;
                        //lngRes = objwin.m_lngAddNewWinque(objPri, objmedwin);                        
                    }
                    #endregion
                }

                #region 保存药品发送表(新)-按1对多设计，暂按1对1写CODE
                //                string pid = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strPatientID;
                //                string date = DateTime.Now.ToString("yyyy-MM-dd");

                //                foreach (clsOutPatientRecipe_VO obj in objVOMainArr)
                //                {
                //                    string recipeid = obj.m_strOutpatRecipeID;

                //                    foreach (clsMedrecipesend_VO objs in objMedicineSend)
                //                    {
                //                        strSQL = @"select seq_recipesendid.nextval from dual";

                //                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                //                        if (lngRes > 0)
                //                        {
                //                            string sid = dt.Rows[0][0].ToString();

                //                            #region 由于出现重号暂停用
                //                            /*
                //                                           strSQL = @"insert into t_opr_recipesend
                //                                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                //                                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int)
                //                                                       select ?, lpad (nvl (to_number (max (a.serno_chr)), 0) + 1, 4, '0'), ?, ?, ?, ?, 1, 0
                //                                                         from t_opr_recipesend a
                //                                                        where a.createdate_chr = ?";

                //                                           objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                //                                           ParamArr[0].Value = sid;
                //                                           ParamArr[1].Value = pid;
                //                                           ParamArr[2].Value = date;
                //                                           ParamArr[3].Value = objs.m_strMedstroeID_CHR;
                //                                           ParamArr[4].Value = objs.m_strWINDOWID_CHR;
                //                                           ParamArr[5].Value = date;
                //                                           */
                //                            #endregion

                //                            strSQL = @"insert into t_opr_recipesend
                //                                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                //                                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int)
                //                                                       select ?, substr (to_char(seq_recipesendnum.nextval), -4), ?, ?, ?, ?, 1, 0
                //                                                         from dual";

                //                            objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                //                            ParamArr[0].Value = sid;
                //                            ParamArr[1].Value = pid;
                //                            ParamArr[2].Value = date;
                //                            ParamArr[3].Value = objs.m_strMedstroeID_CHR;
                //                            ParamArr[4].Value = objs.m_strWINDOWID_CHR;

                //                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                //                            strSQL = @"insert into t_opr_recipesendentry (sid_int, outpatrecipeid_chr) values (?, ?)";

                //                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                //                            ParamArr[0].Value = sid;
                //                            ParamArr[1].Value = recipeid;

                //                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                //                            strSQL = @"insert into t_opr_medstorewinque (seq_int, windowid_chr, windowtype_int, medstoreid_chr, outpatrecipeid_chr, recipetype_chr, order_int, sid_int) 
                //                                                                                 values (seq_medstore.nextval, ?, ?, ?, ?, ?, ?, ?)";

                //                            objHRPSvc.CreateDatabaseParameter(7, out ParamArr);
                //                            ParamArr[0].Value = objs.m_strWINDOWID_CHR;
                //                            ParamArr[1].Value = 1;
                //                            ParamArr[2].Value = objs.m_strMedstroeID_CHR;
                //                            ParamArr[3].Value = recipeid;
                //                            ParamArr[4].Value = objs.m_strRECIPETYPE_INT;
                //                            ParamArr[5].Value = Convert.ToInt32(objs.Sortno);
                //                            ParamArr[6].Value = sid;

                //                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                //                        }
                //                    }
                //                }
                #endregion

                #endregion

                #region 保存明细
                for (int i = 0; i < objRD_VO.Length; i++)
                {
                    if (objRD_VO[i].strCharegeItemID == "")
                    {
                        continue;
                    }

                    //					objRD_VO[i].m_strOutpatRecipeID=strRecipeNo;//保存项目明细
                    strSQL = @"insert into t_opr_oprecipeitemde
                                            (outpatrecipeid_chr, itemid_chr, qty_dec, unitid_chr, price_mny,
                                             tolprice_mny, discount_dec, recipetype_int
                                            )
                                     values (?, ?, ?, ?, ?,
                                             ?, ?, ?
                                            )";

                    objHRPSvc.CreateDatabaseParameter(8, out ParamArr);
                    ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                    ParamArr[1].Value = objRD_VO[i].strCharegeItemID;
                    ParamArr[2].Value = objRD_VO[i].decQuantity;
                    ParamArr[3].Value = objRD_VO[i].strUint;
                    ParamArr[4].Value = objRD_VO[i].decPrice;
                    ParamArr[5].Value = objRD_VO[i].decSumMoney;
                    ParamArr[6].Value = objRD_VO[i].decDiscount / 100;
                    ParamArr[7].Value = objRD_VO[i].strType;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    switch (objRD_VO[i].strType)
                    {
                        case "0001":
                            strSQL = @"insert into t_opr_outpatientpwmrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr,
                                                     tolqty_dec, unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
                                                     discount_dec, medstoreid_chr, windowid_chr, usageid_chr,
                                                     freqid_chr, qty_dec, days_int, hypetest_int, desc_vchr,
                                                     itemspec_vchr, dosage_dec, dosageunit_chr, attachparentid_vchr,
                                                     attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
                                                     itemname_vchr, deptmed_int
                                                    )
                                             values (?, ?, ?, ?,
                                                     ?, ?, ?, seq_recipeid.nextval,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?, ?, ?,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?
                                                    )";

                            objHRPSvc.CreateDatabaseParameter(25, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].strUint;
                            ParamArr[4].Value = objRD_VO[i].decQuantity;
                            ParamArr[5].Value = objRD_VO[i].decPrice;
                            ParamArr[6].Value = objRD_VO[i].decSumMoney;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[9].Value = objRD_VO[i].strWindowsID;
                            ParamArr[10].Value = objRD_VO[i].strUsageID;
                            ParamArr[11].Value = objRD_VO[i].strFrequencyID;
                            ParamArr[12].Value = objRD_VO[i].strDosage;
                            ParamArr[13].Value = objRD_VO[i].strDays;
                            ParamArr[14].Value = objRD_VO[i].strHYPETEST_INT;
                            ParamArr[15].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[16].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[17].Value = objRD_VO[i].m_decDosage;
                            ParamArr[18].Value = objRD_VO[i].m_strDosageunit;
                            ParamArr[19].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[20].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[21].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[22].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[23].Value = objRD_VO[i].m_strItemname;
                            ParamArr[24].Value = objRD_VO[i].m_intDeptmed;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0002":
                            strSQL = @"insert into t_opr_outpatientcmrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr,
                                                     min_qty_dec, unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
                                                     discount_dec, times_int, medstoreid_chr, windowid_chr,
                                                     usageid_chr, qty_dec, sumusage_vchr, itemname_vchr,
                                                     itemspec_vchr, deptmed_int, usagedetail_vchr
                                                    )
                                             values (?, ?, ?, ?,
                                                     ?, ?, ?, seq_recipeid.nextval,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?
                                                    )";

                            objHRPSvc.CreateDatabaseParameter(18, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].strUint;
                            ParamArr[4].Value = objRD_VO[i].decQuantity;
                            ParamArr[5].Value = objRD_VO[i].decPrice;
                            ParamArr[6].Value = objRD_VO[i].decSumMoney;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = times;
                            ParamArr[9].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[10].Value = objRD_VO[i].strWindowsID;
                            ParamArr[11].Value = objRD_VO[i].strUsageID;
                            ParamArr[12].Value = objRD_VO[i].decQuantity;
                            ParamArr[13].Value = objRD_VO[i].strCMedicineUsage;
                            ParamArr[14].Value = objRD_VO[i].m_strItemname;
                            ParamArr[15].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[16].Value = objRD_VO[i].m_intDeptmed;
                            ParamArr[17].Value = objRD_VO[i].strDESC_VCHR;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0003":
                            strSQL = @"insert into t_opr_outpatientchkrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
                                                     tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
                                                     medstoreid_chr, windowid_chr, attachparentid_vchr,
                                                     attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
                                                     itemname_vchr, itemspec_vchr, itemunit_vchr,
                                                     itemusagedetail_vchr, orderid_vchr, orderbasenum_dec
                                                    )
                                             values (?, ?, ?, ?, ?,
                                                     ?, seq_recipeid.nextval, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?
                                                    )";

                            objHRPSvc.CreateDatabaseParameter(20, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].decQuantity;
                            ParamArr[4].Value = objRD_VO[i].decPrice;
                            ParamArr[5].Value = objRD_VO[i].decSumMoney;
                            ParamArr[6].Value = objRD_VO[i].strApplyID;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[9].Value = objRD_VO[i].strWindowsID;
                            ParamArr[10].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[11].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[12].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[13].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[14].Value = objRD_VO[i].m_strItemname;
                            ParamArr[15].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[16].Value = objRD_VO[i].strUint;
                            ParamArr[17].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[18].Value = objRD_VO[i].m_strOrderID;
                            ParamArr[19].Value = objRD_VO[i].m_decOrderBaseNum;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0004":
                            strSQL = @"insert into t_opr_outpatienttestrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
                                                     tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
                                                     medstoreid_chr, windowid_chr, attachparentid_vchr,
                                                     attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
                                                     itemname_vchr, itemspec_vchr, itemunit_vchr,
                                                     itemusagedetail_vchr, orderid_vchr, orderbasenum_dec
                                                    )
                                             values (?, ?, ?, ?, ?,
                                                     ?, seq_recipeid.nextval, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?
                                                    )";

                            objHRPSvc.CreateDatabaseParameter(20, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].decQuantity;
                            ParamArr[4].Value = objRD_VO[i].decPrice;
                            ParamArr[5].Value = objRD_VO[i].decSumMoney;
                            ParamArr[6].Value = objRD_VO[i].strApplyID;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[9].Value = objRD_VO[i].strWindowsID;
                            ParamArr[10].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[11].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[12].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[13].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[14].Value = objRD_VO[i].m_strItemname;
                            ParamArr[15].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[16].Value = objRD_VO[i].strUint;
                            ParamArr[17].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[18].Value = objRD_VO[i].m_strOrderID;
                            ParamArr[19].Value = objRD_VO[i].m_decOrderBaseNum;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0005":
                            strSQL = @"insert into t_opr_outpatientothrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr, qty_dec,
                                                     unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
                                                     attachid_vchr, discount_dec, medstoreid_chr, windowid_chr,
                                                     attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr,
                                                     usageitembasenum_dec, itemname_vchr, itemspec_vchr,
                                                     itemunit_vchr, itemusagedetail_vchr, deptmed_int
                                                    )
                                             values (?, ?, ?, ?, ?,
                                                     ?, ?, seq_recipeid.nextval,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?
                                                    )";

                            objHRPSvc.CreateDatabaseParameter(20, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].strUint;
                            ParamArr[4].Value = objRD_VO[i].decQuantity;
                            ParamArr[5].Value = objRD_VO[i].decPrice;
                            ParamArr[6].Value = objRD_VO[i].decSumMoney;
                            ParamArr[7].Value = objRD_VO[i].strApplyID;
                            ParamArr[8].Value = objRD_VO[i].decDiscount;
                            ParamArr[9].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[10].Value = objRD_VO[i].strWindowsID;
                            ParamArr[11].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[12].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[13].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[14].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[15].Value = objRD_VO[i].m_strItemname;
                            ParamArr[16].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[17].Value = objRD_VO[i].strUint;
                            ParamArr[18].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[19].Value = objRD_VO[i].m_intDeptmed;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0006":
                            strSQL = @"insert into t_opr_outpatientopsrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
                                                     tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
                                                     medstoreid_chr, windowid_chr, attachparentid_vchr,
                                                     attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
                                                     itemname_vchr, itemspec_vchr, itemunit_vchr,
                                                     itemusagedetail_vchr, deptmed_int, orderid_vchr, orderbasenum_dec
                                                    )
                                             values (?, ?, ?, ?, ?,
                                                     ?, seq_recipeid.nextval, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?, ?
                                                    )";

                            objHRPSvc.CreateDatabaseParameter(21, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].decQuantity;
                            ParamArr[4].Value = objRD_VO[i].decPrice;
                            ParamArr[5].Value = objRD_VO[i].decSumMoney;
                            ParamArr[6].Value = objRD_VO[i].strApplyID;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[9].Value = objRD_VO[i].strWindowsID;
                            ParamArr[10].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[11].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[12].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[13].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[14].Value = objRD_VO[i].m_strItemname;
                            ParamArr[15].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[16].Value = objRD_VO[i].strUint;
                            ParamArr[17].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[18].Value = objRD_VO[i].m_intDeptmed;
                            ParamArr[19].Value = objRD_VO[i].m_strOrderID;
                            ParamArr[20].Value = objRD_VO[i].m_decOrderBaseNum;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                    }

                }
                #endregion

                #region 保存发票主表
                /*业务说明:
				//发票核算分类比较特殊，要把所有发票的总额合计起来计算。
				*/
                decimal decAllMoney = 0;
                decimal decChargeMoney = 0;
                for (int intall = 0; intall < objInvoice_VOArr.Length; intall++)
                {
                    decAllMoney += objInvoice_VOArr[intall].m_decTOTALSUM_MNY;
                    decChargeMoney += objInvoice_VOArr[intall].m_decSBSUM_MNY;
                }

                //分票标识 0 正常 1 分票
                string split = "0";
                //分票组号
                string splitgroupid = "";
                if (objInvoice_VOArr.Length > 1)
                {
                    split = "1";
                    splitgroupid = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                }

                for (int i2 = 0; i2 < objInvoice_VOArr.Length; i2++)
                {
                    if (split == "1")
                    {
                        objInvoice_VOArr[i2].m_strBASESEQID_CHR = splitgroupid;
                    }

                    objInvoice_VOArr[i2].m_strOUTPATRECIPEID_CHR = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                    strSQL = @"insert into t_opr_outpatientrecipeinv
                                            (invoiceno_vchr, outpatrecipeid_chr, invdate_dat, acctsum_mny,
                                             sbsum_mny, opremp_chr, recordemp_chr, recorddate_dat,
                                             status_int, seqid_chr, totalsum_mny, paytype_int, patientid_chr,
                                             patientname_chr, deptid_chr, deptname_chr, doctorid_chr,
                                             doctorname_chr, confirmemp_chr, paytypeid_chr, internalflag_int,
                                             baseseqid_chr, groupid_chr, confirmdeptid_chr, split_int
                                            )
                                     values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?,
                                             ?, ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
                                             ?, ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?
                                            )";

                    objHRPSvc.CreateDatabaseParameter(25, out ParamArr);
                    ParamArr[0].Value = objInvoice_VOArr[i2].m_strINVOICENO_VCHR;
                    ParamArr[1].Value = objInvoice_VOArr[i2].m_strOUTPATRECIPEID_CHR;
                    ParamArr[2].Value = objInvoice_VOArr[i2].m_strINVDATE_DAT;
                    ParamArr[3].Value = objInvoice_VOArr[i2].m_decACCTSUM_MNY;
                    ParamArr[4].Value = objInvoice_VOArr[i2].m_decSBSUM_MNY;
                    ParamArr[5].Value = objInvoice_VOArr[i2].m_strOPREMP_CHR;
                    ParamArr[6].Value = objInvoice_VOArr[i2].m_strRECORDEMP_CHR;
                    ParamArr[7].Value = objInvoice_VOArr[i2].m_strRECORDDATE_DAT;
                    ParamArr[8].Value = objInvoice_VOArr[i2].m_intSTATUS_INT;
                    ParamArr[9].Value = objInvoice_VOArr[i2].m_strSEQID_CHR;
                    ParamArr[10].Value = objInvoice_VOArr[i2].m_decTOTALSUM_MNY;
                    ParamArr[11].Value = objInvoice_VOArr[i2].m_intPAYTYPE_INT;
                    ParamArr[12].Value = objInvoice_VOArr[i2].m_strPATIENTID_CHR;
                    ParamArr[13].Value = objInvoice_VOArr[i2].m_strPATIENTNAME_CHR;
                    ParamArr[14].Value = objInvoice_VOArr[i2].m_strDEPTID_CHR;
                    ParamArr[15].Value = objInvoice_VOArr[i2].m_strDEPTNAME_CHR.Trim();
                    ParamArr[16].Value = objInvoice_VOArr[i2].m_strDOCTORID_CHR;
                    ParamArr[17].Value = objInvoice_VOArr[i2].m_strDOCTORNAME_CHR.Trim();
                    ParamArr[18].Value = objInvoice_VOArr[i2].m_strCONFIRMEMP_CHR;
                    ParamArr[19].Value = objInvoice_VOArr[i2].m_strPAYTYPEID_CHR;
                    ParamArr[20].Value = objInvoice_VOArr[i2].m_strHospitalID_CHR;
                    ParamArr[21].Value = objInvoice_VOArr[i2].m_strBASESEQID_CHR;
                    ParamArr[22].Value = strGroupID;
                    ParamArr[23].Value = objInvoice_VOArr[i2].m_strCONFIRMDEPT_CHR;
                    ParamArr[24].Value = split;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //临时： 一张发票只能一种支付方式的情况
                    //以后： 应该还包括多种方式一张发票的情况
                    strSQL = @"insert into t_opr_payment
                                            (chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr,
                                             paysum_mny, refusum_mny
                                            )
                                     values (?, ?, ?, ?,
                                             ?, 0
                                            )";

                    objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                    ParamArr[0].Value = objInvoice_VOArr[i2].m_strSEQID_CHR;
                    ParamArr[1].Value = objInvoice_VOArr[i2].m_intPAYTYPE_INT;
                    ParamArr[2].Value = objInvoice_VOArr[i2].Paycardtype;
                    ParamArr[3].Value = objInvoice_VOArr[i2].Paycardno;
                    ParamArr[4].Value = objInvoice_VOArr[i2].m_decTOTALSUM_MNY;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    decimal decSumMoney = 0;
                    decimal itemMoney = 0;
                    int i = 0;
                    foreach (clsInvoiceTypeDetail_VO item in objArr1[i2])
                    {
                        //计算发票分类单项记帐部分金额
                        if (i == objArr1[i2].Count - 1)
                        {
                            itemMoney = objInvoice_VOArr[i2].m_decSBSUM_MNY - decSumMoney;
                        }
                        else
                        {
                            itemMoney = m_mthGetSelfPayMoney(objInvoice_VOArr[i2].m_decTOTALSUM_MNY, item.m_decSUM_MNY, objInvoice_VOArr[i2].m_decSBSUM_MNY);
                        }

                        item.m_strID = objInvoice_VOArr[i2].m_strSEQID_CHR; ;
                        strSQL = @"insert into t_opr_outpatientrecipeinvde
                                                (itemcatid_chr, tolfee_mny, invoiceno_vchr, sbsum_mny, seqid_chr
                                                )
                                         values (?, ?, ?, ?, ?
                                                )";

                        objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                        ParamArr[0].Value = item.m_strITEMCATID_CHR;
                        ParamArr[1].Value = item.m_decSUM_MNY;
                        ParamArr[2].Value = item.m_strINVOICENO_VCHR;
                        ParamArr[3].Value = itemMoney.ToString("0.00");
                        ParamArr[4].Value = item.m_strID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        decSumMoney += decimal.Parse(itemMoney.ToString("0.00"));
                        i++;
                    }

                    decSumMoney = 0;
                    itemMoney = 0;
                    i = 0;
                    foreach (clsInvoiceTypeDetail_VO item2 in objArr2[i2])
                    {
                        if (i == objArr2[i2].Count - 1)
                        {
                            itemMoney = decChargeMoney - decSumMoney;
                        }
                        else
                        {
                            itemMoney = m_mthGetSelfPayMoney(decAllMoney, item2.m_decSUM_MNY, decChargeMoney);
                        }
                        if (item2.m_decSUM_MNY == 0)//表示分发票时，第二张是插入0
                        {
                            itemMoney = 0;
                        }
                        item2.m_strID = objInvoice_VOArr[i2].m_strSEQID_CHR; ;
                        strSQL = @"insert into t_opr_outpatientrecipesumde
                                                (itemcatid_chr, tolfee_mny, invoiceno_vchr, sbsum_mny, seqid_chr
                                                )
                                         values (?, ?, ?, ?, ?
                                                )";

                        objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                        ParamArr[0].Value = item2.m_strITEMCATID_CHR;
                        ParamArr[1].Value = item2.m_decSUM_MNY;
                        ParamArr[2].Value = item2.m_strINVOICENO_VCHR;
                        ParamArr[3].Value = itemMoney.ToString("0.00");
                        ParamArr[4].Value = item2.m_strID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        decSumMoney += itemMoney;
                        i++;
                    }
                }
                #endregion
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;

        }
        private decimal m_mthGetSelfPayMoney(decimal TotalMoney, decimal calMoney, decimal selfMoney)
        {
            decimal ret = 0;
            ret = (calMoney * selfMoney) / TotalMoney;
            return decimal.Parse(ret.ToString("0.00"));
        }
        #endregion

        #region 独立保存处方
        /// <summary>
        /// 独立保存处方
        /// </summary>
        /// <param name="objVOMainArr"></param>
        /// <param name="objRD_VO"></param>
        /// <param name="times"></param>        
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveRecipe(ArrayList objVOMainArr, clsRecipeDetail_VO[] objRD_VO, decimal times)
        {
            long lngRes = 0, lngAffects = 0;
            try
            {
                #region 保存处方主表
                com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc objEmployeeSvc = new com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc();
                string strGroupID = "";
                DataTable tempDt;
                string strSQL = "";
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                DataTable dt = new DataTable();

                foreach (clsOutPatientRecipe_VO objTempMain in objVOMainArr)
                {
                    lngRes = objEmployeeSvc.m_lngGetGroupEmp(objTempMain.m_strDoctorID, out tempDt);
                    if (lngRes > 0 && tempDt.Rows.Count > 0)
                    {
                        strGroupID = tempDt.Rows[0]["groupid_chr"].ToString();
                    }
                    this.m_mthDeleteRecipeDetail(objTempMain.m_strOutpatRecipeID.Trim());

                    //处方号关联表                   
                    strSQL = @"select seqid, outpatrecipeid_chr from t_opr_reciperelation where seqid = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                    if (dt.Rows.Count > 0)
                    {
                        strSQL = @"update t_opr_reciperelation set mcflag_int = 1 where seqid = ?";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }
                    else
                    {
                        strSQL = @"insert into t_opr_reciperelation
                                                (seqid, outpatrecipeid_chr
                                                )
                                         values (?, ?
                                                )";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                        ParamArr[1].Value = objTempMain.m_strOutpatRecipeID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }

                    //处方主表
                    strSQL = @"insert into t_opr_outpatientrecipe
                                            (outpatrecipeid_chr, patientid_chr, createdate_dat,
                                             registerid_chr, diagdr_chr, diagdept_chr, recordemp_chr,
                                             recorddate_dat, pstauts_int, paytypeid_chr, recipeflag_int,
                                             groupid_chr, casehisid_chr, type_int, createtype_int, deptmed_int
                                            )
                                     values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
                                             ?, ?, ?, ?,
                                             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?,
                                             ?, ?, ?, ?, ?
                                            )";

                    objHRPSvc.CreateDatabaseParameter(16, out ParamArr);
                    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID;
                    ParamArr[1].Value = objTempMain.m_strPatientID;
                    ParamArr[2].Value = objTempMain.m_strCreateDate;
                    ParamArr[3].Value = objTempMain.m_strRegisterID;
                    ParamArr[4].Value = objTempMain.m_strDoctorID;
                    ParamArr[5].Value = objTempMain.m_strDepID;
                    ParamArr[6].Value = objTempMain.m_strOperatorID;
                    ParamArr[7].Value = DateTime.Now.ToString();
                    ParamArr[8].Value = objTempMain.m_intPStatus;
                    ParamArr[9].Value = objTempMain.m_strPatientType;
                    ParamArr[10].Value = objTempMain.m_intType;
                    ParamArr[11].Value = strGroupID;
                    ParamArr[12].Value = objTempMain.m_strCaseHistoryID;
                    ParamArr[13].Value = objTempMain.m_strRecipeType;
                    ParamArr[14].Value = objTempMain.intCreatetype;
                    ParamArr[15].Value = objTempMain.intDeptmed;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //根据处方号更新检验、检查等项目收费标志(已收费)
                    strSQL = @"update t_opr_attachrelation set status_int = 1 where sourceitemid_vchr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //更新患者身份证号、医保卡号
                    strSQL = @"update t_bse_patient 
								set idcard_chr = ?, 
									insuranceid_vchr = ?  
							where patientid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = objTempMain.strIDcard;
                    ParamArr[1].Value = objTempMain.strInsuranceID;
                    ParamArr[2].Value = objTempMain.m_strPatientID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //处理患者身份对应号表
                    if (objTempMain.m_strPatientType.Trim() != "")
                    {
                        if (objTempMain.strInsuranceID.Trim() == "")
                        {
                            objTempMain.strInsuranceID = " ";
                        }

                        strSQL = "delete from t_bse_patientidentityno where patientid_chr = ? and paytypeid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = objTempMain.m_strPatientID;
                        ParamArr[1].Value = objTempMain.m_strPatientType;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        strSQL = @"insert into t_bse_patientidentityno(patientid_chr, paytypeid_chr, idno_vchr) values (?, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                        ParamArr[0].Value = objTempMain.m_strPatientID;
                        ParamArr[1].Value = objTempMain.m_strPatientType;
                        ParamArr[2].Value = objTempMain.strInsuranceID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }
                }
                #endregion

                #region 保存明细
                for (int i = 0; i < objRD_VO.Length; i++)
                {
                    if (objRD_VO[i].strCharegeItemID == "")
                    {
                        continue;
                    }

                    switch (objRD_VO[i].strType)
                    {
                        case "0001":
                            strSQL = @"insert into t_opr_outpatientpwmrecipede
            (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr,
             tolqty_dec, unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
             discount_dec, medstoreid_chr, windowid_chr, usageid_chr,
             freqid_chr, qty_dec, days_int, hypetest_int, desc_vchr,
             itemspec_vchr, dosage_dec, dosageunit_chr, attachparentid_vchr,
             attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
             itemname_vchr, deptmed_int
            )
     values (?, ?, ?, ?,
             ?, ?, ?, seq_recipeid.nextval,
             ?, ?, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?
            )";

                            objHRPSvc.CreateDatabaseParameter(25, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].strUint;
                            ParamArr[4].Value = objRD_VO[i].decQuantity;
                            ParamArr[5].Value = objRD_VO[i].decPrice;
                            ParamArr[6].Value = objRD_VO[i].decSumMoney;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[9].Value = objRD_VO[i].strWindowsID;
                            ParamArr[10].Value = objRD_VO[i].strUsageID;
                            ParamArr[11].Value = objRD_VO[i].strFrequencyID;
                            ParamArr[12].Value = objRD_VO[i].strDosage;
                            ParamArr[13].Value = objRD_VO[i].strDays;
                            ParamArr[14].Value = objRD_VO[i].strHYPETEST_INT;
                            ParamArr[15].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[16].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[17].Value = objRD_VO[i].m_decDosage;
                            ParamArr[18].Value = objRD_VO[i].m_strDosageunit;
                            ParamArr[19].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[20].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[21].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[22].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[23].Value = objRD_VO[i].m_strItemname;
                            ParamArr[24].Value = objRD_VO[i].m_intDeptmed;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0002":
                            strSQL = @"insert into t_opr_outpatientcmrecipede
            (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr,
             min_qty_dec, unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
             discount_dec, times_int, medstoreid_chr, windowid_chr,
             usageid_chr, qty_dec, sumusage_vchr, itemname_vchr,
             itemspec_vchr, deptmed_int, usagedetail_vchr
            )
     values (?, ?, ?, ?,
             ?, ?, ?, seq_recipeid.nextval,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?
            )
";

                            objHRPSvc.CreateDatabaseParameter(18, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].strUint;
                            ParamArr[4].Value = objRD_VO[i].decQuantity;
                            ParamArr[5].Value = objRD_VO[i].decPrice;
                            ParamArr[6].Value = objRD_VO[i].decSumMoney;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = times;
                            ParamArr[9].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[10].Value = objRD_VO[i].strWindowsID;
                            ParamArr[11].Value = objRD_VO[i].strUsageID;
                            ParamArr[12].Value = objRD_VO[i].decQuantity;
                            ParamArr[13].Value = objRD_VO[i].strCMedicineUsage;
                            ParamArr[14].Value = objRD_VO[i].m_strItemname;
                            ParamArr[15].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[16].Value = objRD_VO[i].m_intDeptmed;
                            ParamArr[17].Value = objRD_VO[i].strDESC_VCHR;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0003":
                            strSQL = @"insert into t_opr_outpatientchkrecipede
            (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
             tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
             medstoreid_chr, windowid_chr, attachparentid_vchr,
             attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
             itemname_vchr, itemspec_vchr, itemunit_vchr,
             itemusagedetail_vchr, orderid_vchr, orderbasenum_dec
            )
     values (?, ?, ?, ?, ?,
             ?, seq_recipeid.nextval, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?
            )";

                            objHRPSvc.CreateDatabaseParameter(20, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].decQuantity;
                            ParamArr[4].Value = objRD_VO[i].decPrice;
                            ParamArr[5].Value = objRD_VO[i].decSumMoney;
                            ParamArr[6].Value = objRD_VO[i].strApplyID;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[9].Value = objRD_VO[i].strWindowsID;
                            ParamArr[10].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[11].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[12].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[13].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[14].Value = objRD_VO[i].m_strItemname;
                            ParamArr[15].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[16].Value = objRD_VO[i].strUint;
                            ParamArr[17].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[18].Value = objRD_VO[i].m_strOrderID;
                            ParamArr[19].Value = objRD_VO[i].m_decOrderBaseNum;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0004":
                            strSQL = @"insert into t_opr_outpatienttestrecipede
            (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
             tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
             medstoreid_chr, windowid_chr, attachparentid_vchr,
             attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
             itemname_vchr, itemspec_vchr, itemunit_vchr,
             itemusagedetail_vchr, orderid_vchr, orderbasenum_dec
            )
     values (?, ?, ?, ?, ?,
             ?, seq_recipeid.nextval, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?
            )";

                            objHRPSvc.CreateDatabaseParameter(20, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].decQuantity;
                            ParamArr[4].Value = objRD_VO[i].decPrice;
                            ParamArr[5].Value = objRD_VO[i].decSumMoney;
                            ParamArr[6].Value = objRD_VO[i].strApplyID;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[9].Value = objRD_VO[i].strWindowsID;
                            ParamArr[10].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[11].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[12].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[13].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[14].Value = objRD_VO[i].m_strItemname;
                            ParamArr[15].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[16].Value = objRD_VO[i].strUint;
                            ParamArr[17].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[18].Value = objRD_VO[i].m_strOrderID;
                            ParamArr[19].Value = objRD_VO[i].m_decOrderBaseNum;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0005":
                            strSQL = @"insert into t_opr_outpatientothrecipede
            (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr, qty_dec,
             unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
             attachid_vchr, discount_dec, medstoreid_chr, windowid_chr,
             attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr,
             usageitembasenum_dec, itemname_vchr, itemspec_vchr,
             itemunit_vchr, itemusagedetail_vchr, deptmed_int
            )
     values (?, ?, ?, ?, ?,
             ?, ?, seq_recipeid.nextval,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?
            )";

                            objHRPSvc.CreateDatabaseParameter(20, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].strUint;
                            ParamArr[4].Value = objRD_VO[i].decQuantity;
                            ParamArr[5].Value = objRD_VO[i].decPrice;
                            ParamArr[6].Value = objRD_VO[i].decSumMoney;
                            ParamArr[7].Value = objRD_VO[i].strApplyID;
                            ParamArr[8].Value = objRD_VO[i].decDiscount;
                            ParamArr[9].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[10].Value = objRD_VO[i].strWindowsID;
                            ParamArr[11].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[12].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[13].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[14].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[15].Value = objRD_VO[i].m_strItemname;
                            ParamArr[16].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[17].Value = objRD_VO[i].strUint;
                            ParamArr[18].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[19].Value = objRD_VO[i].m_intDeptmed;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0006":
                            strSQL = @"insert into t_opr_outpatientopsrecipede
            (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
             tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
             medstoreid_chr, windowid_chr, attachparentid_vchr,
             attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
             itemname_vchr, itemspec_vchr, itemunit_vchr,
             itemusagedetail_vchr, deptmed_int, orderid_vchr, orderbasenum_dec
            )
     values (?, ?, ?, ?, ?,
             ?, seq_recipeid.nextval, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?
            )";

                            objHRPSvc.CreateDatabaseParameter(21, out ParamArr);
                            ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                            ParamArr[1].Value = objRD_VO[i].strRowNO;
                            ParamArr[2].Value = objRD_VO[i].strCharegeItemID;
                            ParamArr[3].Value = objRD_VO[i].decQuantity;
                            ParamArr[4].Value = objRD_VO[i].decPrice;
                            ParamArr[5].Value = objRD_VO[i].decSumMoney;
                            ParamArr[6].Value = objRD_VO[i].strApplyID;
                            ParamArr[7].Value = objRD_VO[i].decDiscount;
                            ParamArr[8].Value = objRD_VO[i].strMedstroeID;
                            ParamArr[9].Value = objRD_VO[i].strWindowsID;
                            ParamArr[10].Value = objRD_VO[i].m_strATTACHPARENTID_VCHR;
                            ParamArr[11].Value = objRD_VO[i].m_decAttachitembasenum;
                            ParamArr[12].Value = objRD_VO[i].m_strUSAGEPARENTID_VCHR;
                            ParamArr[13].Value = objRD_VO[i].m_decUsageitembasenum;
                            ParamArr[14].Value = objRD_VO[i].m_strItemname;
                            ParamArr[15].Value = objRD_VO[i].m_strItemspec;
                            ParamArr[16].Value = objRD_VO[i].strUint;
                            ParamArr[17].Value = objRD_VO[i].strDESC_VCHR;
                            ParamArr[18].Value = objRD_VO[i].m_intDeptmed;
                            ParamArr[19].Value = objRD_VO[i].m_strOrderID;
                            ParamArr[20].Value = objRD_VO[i].m_decOrderBaseNum;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                    }
                }
                #endregion

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region  保存处方明细
        [AutoComplete]
        public void m_mthSaveRecipeDetial(System.Security.Principal.IPrincipal objPri, string strRecipeNo, clsRecipeDetail_VO[] objRD_VO, decimal times)
        {
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveRecipeDetial");
            if (lngRes < 0)
                return;

            //			int row1=0;
            //			int row2=0;
            //			int row3=0;
            //			int row4=0;
            //			int row5=0;
            //			int row6=0;
            for (int i = 0; i < objRD_VO.Length; i++)
            {
                if (objRD_VO[i].strCharegeItemID == "")
                {
                    continue;
                }
                objRD_VO[i].m_strOutpatRecipeID = strRecipeNo;
                switch (objRD_VO[i].strType)
                {
                    case "0001":
                        //						objRD_VO[i].strRowNO=row1.ToString();
                        this.m_mthAddWestDrug(objRD_VO[i]);
                        //						row1++;
                        break;
                    case "0002":
                        //						objRD_VO[i].strRowNO=row2.ToString();
                        this.m_mthAddPatientDrug(objRD_VO[i], times);
                        //						row2++;
                        break;
                    case "0003":
                        //						objRD_VO[i].strRowNO=row3.ToString();
                        this.m_mthAddInspect(objRD_VO[i]);
                        //						row3++;
                        break;
                    case "0004":
                        //						objRD_VO[i].strRowNO=row4.ToString();
                        this.m_mthAddCure(objRD_VO[i]);
                        //						row4++;
                        break;
                    case "0005":
                        //						objRD_VO[i].strRowNO=row5.ToString();
                        this.m_mthAddOther(objRD_VO[i]);
                        //						row5++;
                        break;
                    case "0006":
                        //						objRD_VO[i].strRowNO=row6.ToString();
                        this.m_mthAddOPS(objRD_VO[i]);
                        //						row6++;
                        break;
                }


            }

        }
        [AutoComplete]
        private void m_mthAddWestDrug(clsRecipeDetail_VO clsVO)//西药
        {
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL = @"Insert Into t_opr_outpatientpwmrecipede(OUTPATRECIPEDEID_CHR, OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,UNITID_CHR,TOLQTY_DEC,UNITPRICE_MNY,TOLPRICE_MNY, DISCOUNT_DEC,MEDSTOREID_CHR,WINDOWID_CHR,USAGEID_CHR,FREQID_CHR,QTY_DEC,DAYS_INT,
                                                                        HYPETEST_INT,DESC_VCHR, itemspec_vchr, dosage_dec, dosageunit_chr, attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, deptmed_int) Values(seq_recipeid.nextval, '" +
                    clsVO.m_strOutpatRecipeID + "','" +
                    clsVO.strRowNO + "','" +
                    clsVO.strCharegeItemID + "','" +
                    clsVO.strUint + "','" +
                    clsVO.decQuantity + "','" +
                    clsVO.decPrice + "','" +
                    clsVO.decSumMoney + "','" +
                    clsVO.decDiscount + "','" +
                    clsVO.strMedstroeID + "','" +
                    clsVO.strWindowsID + "','" +
                    clsVO.strUsageID + "','" +
                    clsVO.strFrequencyID + "','" +
                    clsVO.strDosage + "','" +
                    clsVO.strDays + "', '" +
                    clsVO.strHYPETEST_INT + "', '" +
                    clsVO.strDESC_VCHR + "', '" +
                    clsVO.m_strItemspec + "', '" +
                    clsVO.m_decDosage + "', '" +
                    clsVO.m_strDosageunit + "', '" +
                    clsVO.m_strATTACHPARENTID_VCHR + "', '" +
                    clsVO.m_decAttachitembasenum + "', '" +
                    clsVO.m_strUSAGEPARENTID_VCHR + "', '" +
                    clsVO.m_decUsageitembasenum + "', '" +
                    clsVO.m_strItemname + "', '" +
                    clsVO.m_intDeptmed + "')";
                long lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        [AutoComplete]
        private void m_mthAddPatientDrug(clsRecipeDetail_VO clsVO, decimal times)//中药
        {
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL = @"Insert Into T_OPR_OUTPATIENTCMRECIPEDE(OUTPATRECIPEDEID_CHR, OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,UNITID_CHR,MIN_QTY_DEC,UNITPRICE_MNY,TOLPRICE_MNY, DISCOUNT_DEC, TIMES_INT,MEDSTOREID_CHR,
                                                                       WINDOWID_CHR,USAGEID_CHR,QTY_DEC,SUMUSAGE_VCHR, itemname_vchr, itemspec_vchr, deptmed_int, UsageDetail_vchr) Values(seq_recipeid.nextval, '" +
                    clsVO.m_strOutpatRecipeID + "','" +
                    clsVO.strRowNO + "','" +
                    clsVO.strCharegeItemID + "','" +
                    clsVO.strUint + "','" +
                    clsVO.decQuantity + "','" +
                    clsVO.decPrice + "','" +
                    clsVO.decSumMoney + "','" +
                    clsVO.decDiscount + "','" +
                    times + "','" +
                    clsVO.strMedstroeID + "','" +
                    clsVO.strWindowsID + "','" +
                    clsVO.strUsageID + "','" +
                    clsVO.decQuantity + "','" +
                    clsVO.strCMedicineUsage + "', '" +
                    clsVO.m_strItemname + "', '" +
                    clsVO.m_strItemspec + "', '" +
                    clsVO.m_intDeptmed + "', '" +
                    clsVO.strDESC_VCHR + "')";
                long lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        [AutoComplete]
        private void m_mthAddInspect(clsRecipeDetail_VO clsVO)//检验
        {
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL = @"Insert Into t_opr_outpatientchkrecipede(OUTPATRECIPEDEID_CHR, OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,QTY_DEC,PRICE_MNY,TOLPRICE_MNY, ATTACHID_VCHR,DISCOUNT_DEC, MEDSTOREID_CHR,WINDOWID_CHR, 
                                       attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, orderid_vchr, orderbasenum_dec) Values(seq_recipeid.nextval, '" +
                    clsVO.m_strOutpatRecipeID + "','" +
                    clsVO.strRowNO + "','" +
                    clsVO.strCharegeItemID + "','" +
                    clsVO.decQuantity + "','" +
                    clsVO.decPrice + "','" +
                    clsVO.decSumMoney + "','" +
                    clsVO.strApplyID + "','" +
                    clsVO.decDiscount + "', '" +
                    clsVO.strMedstroeID + "', '" +
                    clsVO.strWindowsID + "', '" +
                    clsVO.m_strATTACHPARENTID_VCHR + "', '" +
                    clsVO.m_decAttachitembasenum + "', '" +
                    clsVO.m_strUSAGEPARENTID_VCHR + "', '" +
                    clsVO.m_decUsageitembasenum + "', '" +
                    clsVO.m_strItemname + "', '" +
                    clsVO.m_strItemspec + "', '" +
                    clsVO.strUint + "', '" +
                    clsVO.strDESC_VCHR + "', '" +
                    clsVO.m_strOrderID + "', '" +
                    clsVO.m_decOrderBaseNum + "')";
                long lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        [AutoComplete]
        private void m_mthAddCure(clsRecipeDetail_VO clsVO)//治疗
        {
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL = @"Insert Into t_opr_outpatienttestrecipede(OUTPATRECIPEDEID_CHR, OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,QTY_DEC,PRICE_MNY,TOLPRICE_MNY,ATTACHID_VCHR,DISCOUNT_DEC,MEDSTOREID_CHR,WINDOWID_CHR, 
                                       attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, orderid_vchr, orderbasenum_dec) Values(seq_recipeid.nextval, '" +
                    clsVO.m_strOutpatRecipeID + "','" +
                    clsVO.strRowNO + "','" +
                    clsVO.strCharegeItemID + "','" +
                    clsVO.decQuantity + "','" +
                    clsVO.decPrice + "','" +
                    clsVO.decSumMoney + "','" +
                    clsVO.strApplyID + "', '" +
                    clsVO.decDiscount + "', '" +
                    clsVO.strMedstroeID + "', '" +
                    clsVO.strWindowsID + "', '" +
                    clsVO.m_strATTACHPARENTID_VCHR + "', '" +
                    clsVO.m_decAttachitembasenum + "', '" +
                    clsVO.m_strUSAGEPARENTID_VCHR + "', '" +
                    clsVO.m_decUsageitembasenum + "', '" +
                    clsVO.m_strItemname + "', '" +
                    clsVO.m_strItemspec + "', '" +
                    clsVO.strUint + "', '" +
                    clsVO.strDESC_VCHR + "', '" +
                    clsVO.m_strOrderID + "', '" +
                    clsVO.m_decOrderBaseNum + "')";
                long lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        [AutoComplete]
        private void m_mthAddOther(clsRecipeDetail_VO clsVO)//其他
        {
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL = @"Insert Into t_opr_outpatientothrecipede(OUTPATRECIPEDEID_CHR, OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,UNITID_CHR,QTY_DEC,UNITPRICE_MNY,TOLPRICE_MNY,ATTACHID_VCHR,DISCOUNT_DEC,MEDSTOREID_CHR,
                                       WINDOWID_CHR, attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int) Values(seq_recipeid.nextval, '" +
                    clsVO.m_strOutpatRecipeID + "','" +
                    clsVO.strRowNO + "','" +
                    clsVO.strCharegeItemID + "','" +
                    clsVO.strUint + "','" +
                    clsVO.decQuantity + "','" +
                    clsVO.decPrice + "','" +
                    clsVO.decSumMoney + "','" +
                    clsVO.strApplyID + "','" +
                    clsVO.decDiscount + "', '" +
                    clsVO.strMedstroeID + "', '" +
                    clsVO.strWindowsID + "', '" +
                    clsVO.m_strATTACHPARENTID_VCHR + "', '" +
                    clsVO.m_decAttachitembasenum + "', '" +
                    clsVO.m_strUSAGEPARENTID_VCHR + "', '" +
                    clsVO.m_decUsageitembasenum + "', '" +
                    clsVO.m_strItemname + "', '" +
                    clsVO.m_strItemspec + "', '" +
                    clsVO.strUint + "', '" +
                    clsVO.strDESC_VCHR + "', '" +
                    clsVO.m_intDeptmed + "')";
                long lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        [AutoComplete]
        private void m_mthAddOPS(clsRecipeDetail_VO clsVO)//手术
        {
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL = @"Insert Into T_OPR_OUTPATIENTOPSRECIPEDE(OUTPATRECIPEDEID_CHR, OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,QTY_DEC,PRICE_MNY,TOLPRICE_MNY,ATTACHID_VCHR,DISCOUNT_DEC,MEDSTOREID_CHR,WINDOWID_CHR, attachparentid_vchr,  
                                       attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int, orderid_vchr, orderbasenum_dec) Values(seq_recipeid.nextval, '" +
                    clsVO.m_strOutpatRecipeID + "','" +
                    clsVO.strRowNO + "','" +
                    clsVO.strCharegeItemID + "','" +
                    clsVO.decQuantity + "','" +
                    clsVO.decPrice + "','" +
                    clsVO.decSumMoney + "','" +
                    clsVO.strApplyID + "','" +
                    clsVO.decDiscount + "', '" +
                    clsVO.strMedstroeID + "', '" +
                    clsVO.strWindowsID + "', '" +
                    clsVO.m_strATTACHPARENTID_VCHR + "', '" +
                    clsVO.m_decAttachitembasenum + "', '" +
                    clsVO.m_strUSAGEPARENTID_VCHR + "', '" +
                    clsVO.m_decUsageitembasenum + "', '" +
                    clsVO.m_strItemname + "', '" +
                    clsVO.m_strItemspec + "', '" +
                    clsVO.strUint + "', '" +
                    clsVO.strDESC_VCHR + "', '" +
                    clsVO.m_intDeptmed + "', '" +
                    clsVO.m_strOrderID + "', '" +
                    clsVO.m_decOrderBaseNum + "')";
                long lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        #endregion

        #region  保存处方收费明细表
        [AutoComplete]
        public void m_mthSaveRecipeChargeItemDetial(System.Security.Principal.IPrincipal objPri, string strRecipeNo, clsRecipeDetail_VO[] objRD_VO)
        {
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveRecipeChargeItemDetial");
            if (lngRes < 0)
                return;
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                for (int i = 0; i < objRD_VO.Length; i++)
                {
                    if (objRD_VO[i].strCharegeItemID == "")
                    {
                        continue;
                    }
                    strSQL = @"Insert Into t_opr_oprecipeitemde(OUTPATRECIPEID_CHR,ITEMID_CHR,QTY_DEC,UNITID_CHR,PRICE_MNY,TOLPRICE_MNY,DISCOUNT_DEC,RECIPETYPE_INT) Values('" +
                        objRD_VO[i].m_strOutpatRecipeID + "','" +
                        objRD_VO[i].strCharegeItemID + "','" +
                        objRD_VO[i].decQuantity + "','" +
                        objRD_VO[i].strUint + "','" +
                        objRD_VO[i].decPrice + "','" +
                        objRD_VO[i].decSumMoney + "','" +
                        objRD_VO[i].decDiscount + "','" +
                        objRD_VO[i].strType + "')";
                    lngRes = objHRPSvc.DoExcute(strSQL);
                    objHRPSvc.Dispose();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        /// <summary>
        /// 获得发票流水号
        /// </summary>
        /// <returns></returns>
        public string m_mthGetInvoiceSEQID()
        {
            DataTable dt = null;
            string strSQL = "select substr(max(SEQID_CHR),9,6) ID from t_opr_outpatientrecipeinv where substr(SEQID_CHR,1,8)='" + DateTime.Now.ToString("yyyyMMdd") + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dt != null)
                {
                    int i = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    i += 1;
                    return DateTime.Now.ToString("yyyyMMdd") + i.ToString().PadLeft(6, '0');
                }
                return DateTime.Now.ToString("yyyyMMdd") + "000001";
            }
            catch
            {
                return DateTime.Now.ToString("yyyyMMdd") + "000001";
            }
        }
        #endregion

        #region  保存发票主表
        [AutoComplete]
        public long m_mthSaveInvoicInfo(System.Security.Principal.IPrincipal objPri, clsInvoice_VO obj)
        {
            //			obj.m_strSEQID_CHR=this.m_mthGetInvoiceSEQID();
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveInvoicInfo");
            if (lngRes < 0)
                return -1;

            try
            {
                string strSQL = @"Insert Into t_opr_outpatientrecipeinv(INVOICENO_VCHR,OUTPATRECIPEID_CHR,INVDATE_DAT,ACCTSUM_MNY,SBSUM_MNY,OPREMP_CHR,RECORDEMP_CHR,RECORDDATE_DAT,
STATUS_INT,SEQID_CHR,BALANCEEMP_CHR,BALANCE_DAT,BALANCEFLAG_INT,TOTALSUM_MNY,PAYTYPE_INT,PATIENTID_CHR,PATIENTNAME_CHR,DEPTID_CHR,DEPTNAME_CHR,
DOCTORID_CHR,DOCTORNAME_CHR,CONFIRMEMP_CHR,PAYTYPEID_CHR,INTERNALFLAG_INT,BASESEQID_CHR) Values('" +
                    obj.m_strINVOICENO_VCHR + "','" +
                    obj.m_strOUTPATRECIPEID_CHR + "',to_date('" +
                    obj.m_strINVDATE_DAT + "','yyyy-mm-dd hh24:mi:ss'),'" +
                    obj.m_decACCTSUM_MNY + "','" +
                    obj.m_decSBSUM_MNY + "','" +
                    obj.m_strOPREMP_CHR + "','" +
                    obj.m_strRECORDEMP_CHR + "',to_date('" +
                    obj.m_strRECORDDATE_DAT + "','yyyy-mm-dd hh24:mi:ss'),'" +
                    obj.m_intSTATUS_INT + "','" +
                    obj.m_strSEQID_CHR + "','" +
                    obj.m_strBALANCEEMP_CHR + "',to_date('" +
                    obj.m_strBALANCE_DAT + "','yyyy-mm-dd hh24:mi:ss'),'" +
                    obj.m_intBALANCEFLAG_INT + "','" +
                    obj.m_decTOTALSUM_MNY + "','" +
                    obj.m_intPAYTYPE_INT + "','" +
                    obj.m_strPATIENTID_CHR + "','" +
                    obj.m_strPATIENTNAME_CHR + "','" +
                    obj.m_strDEPTID_CHR + "','" +
                    obj.m_strDEPTNAME_CHR + "','" +
                    obj.m_strDOCTORID_CHR + "','" +
                    obj.m_strDOCTORNAME_CHR + "','" +
                    obj.m_strCONFIRMEMP_CHR + "','" +
                    obj.m_strPAYTYPEID_CHR + "','" +
                    obj.m_strHospitalID_CHR + "','" +
                    obj.m_strBASESEQID_CHR + "')";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region  保存发票明细
        [AutoComplete]
        public void m_mthSaveInvoiceDetail(System.Security.Principal.IPrincipal objPri, ArrayList objArr)
        {
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string ID;
                string strSQL = "";
                foreach (clsInvoiceTypeDetail_VO item in objArr)
                {

                    strSQL = @"Insert Into t_opr_outpatientrecipeinvde(ITEMCATID_CHR,TOLFEE_MNY,INVOICENO_VCHR,SEQID_CHR) Values('" +
                        item.m_strITEMCATID_CHR + "','" +
                        item.m_decSUM_MNY + "','" +
                        item.m_strINVOICENO_VCHR + "','" +
                        item.m_strID + "')";
                    objHRPSvc.DoExcute(strSQL);
                    objHRPSvc.Dispose();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        [AutoComplete]
        public void m_mthSaveInvoiceDetail2(System.Security.Principal.IPrincipal objPri, ArrayList objArr)
        {
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL = "";
                string ID;
                foreach (clsInvoiceTypeDetail_VO item in objArr)
                {
                    //					long l =objHRPSvc.m_lngGenerateNewID(15,"SEQID_CHR","T_OPR_OUTPATIENTRECIPESUMDE",out ID);
                    strSQL = @"Insert Into T_OPR_OUTPATIENTRECIPESUMDE(ITEMCATID_CHR,TOLFEE_MNY,INVOICENO_VCHR,SEQID_CHR) Values('" +
                        item.m_strITEMCATID_CHR + "','" +
                        item.m_decSUM_MNY + "','" +
                        item.m_strINVOICENO_VCHR + "','" +
                        item.m_strID + "')";
                    objHRPSvc.DoExcute(strSQL);

                    objHRPSvc.Dispose();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        #endregion

        #region 保存处方发送记录
        [AutoComplete]
        public void m_mthSaveRecipeSend(System.Security.Principal.IPrincipal objPri, clsMedrecipesend_VO obj)
        {
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveRecipeSend");
            if (lngRes < 0)
                return;
            try
            {
                //				obj.m_strRECIPETYPE_INT="0001";
                string strSQL = @"Insert Into t_opr_medrecipesend(OUTPATRECIPEID_CHR,RECIPETYPE_INT,WINDOWID_CHR,PSTATUS_INT,SENDDATE_DAT,SENDEMP_CHR) Values('" +
                    obj.m_strOUTPATRECIPEID_CHR + "','" +
                    obj.m_strRECIPETYPE_INT + "','" +
                    obj.m_strWINDOWID_CHR + "','" +
                    obj.m_intPSTATUS_INT + "',to_date('" +
                    obj.m_strSENDDATE_DAT + "','yyyy-mm-dd hh24:mi:ss'),'" +
                    obj.m_strSENDEMP_CHR + "')";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

        }
        #endregion

        #region  按病人ID查找处方号(包含部分信息)
        [AutoComplete]
        public long m_mthFindRecipeNoByPatientID(System.Security.Principal.IPrincipal objPri, string ID, out clsRecipeInfo_VO[] objRI_VO, string strID, int flag)
        {
            objRI_VO = null;

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeNoByPatientID");
            if (lngRes < 0)
            {
                return -1;
            }
            DataTable objdt = new DataTable();

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"select outpatrecipeid_chr, a.createdate_dat, a.diagdr_chr, a.diagdept_chr,
       a.pstauts_int, a.recipeflag_int, a.paytypeid_chr, a.type_int,
       b.deptname_vchr, c.lastname_vchr, c.empno_chr, d.paytypename_vchr,
       d.internalflag_int, d.chargepercent_dec, d.paylimit_mny
  from t_opr_outpatientrecipe a,
       t_bse_deptdesc b,
       t_bse_employee c,
       t_bse_patientpaytype d
 where a.diagdr_chr = c.empid_chr(+)
   and a.diagdept_chr = b.deptid_chr(+)
   and a.paytypeid_chr = d.paytypeid_chr(+)
   and a.patientid_chr = ?";

            if (flag == 1)
            {
                strSQL += " and a.pstauts_int <>-1 and a.pstauts_int<>0";
            }
            else
            {
                strSQL += " and a.pstauts_int <>-1 and a.pstauts_int <> 1 and a.createtype_int = 0 ";
            }

            if (strID.Trim() != "")
            {
                strSQL += " and  a.OUTPATRECIPEID_CHR like ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = ID;
                ParamArr[1].Value = strID + "%";
            }
            else
            {
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ID;
            }

            strSQL += "  order by a.createdate_dat desc,a.OUTPATRECIPEID_CHR desc";
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref objdt, ParamArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && objdt.Rows.Count > 0)
                {
                    objRI_VO = new clsRecipeInfo_VO[objdt.Rows.Count];
                    for (int i = 0; i < objdt.Rows.Count; i++)
                    {
                        objRI_VO[i] = new clsRecipeInfo_VO();
                        objRI_VO[i].m_intPSTATUS_INT = int.Parse(objdt.Rows[i]["PSTAUTS_INT"].ToString());
                        objRI_VO[i].m_strOUTPATRECIPEID_CHR = objdt.Rows[i]["OUTPATRECIPEID_CHR"].ToString();
                        objRI_VO[i].m_strRECIPEFLAG_INT = objdt.Rows[i]["RECIPEFLAG_INT"].ToString();
                        objRI_VO[i].m_strCreatTime = objdt.Rows[i]["CREATEDATE_DAT"].ToString();
                        objRI_VO[i].m_strDepID = objdt.Rows[i]["DIAGDEPT_CHR"].ToString();
                        objRI_VO[i].m_strDepName = objdt.Rows[i]["DEPTNAME_VCHR"].ToString();
                        objRI_VO[i].m_strDoctorName = objdt.Rows[i]["LASTNAME_VCHR"].ToString();
                        objRI_VO[i].m_strDoctorID = objdt.Rows[i]["DIAGDR_CHR"].ToString();
                        objRI_VO[i].m_strDoctorNo = objdt.Rows[i]["EMPNO_CHR"].ToString();
                        objRI_VO[i].m_strPatientTypeID = objdt.Rows[i]["PAYTYPEID_CHR"].ToString();
                        objRI_VO[i].m_strPatientTypeName = objdt.Rows[i]["PAYTYPENAME_VCHR"].ToString();
                        objRI_VO[i].m_intRecipetypeid = int.Parse(objdt.Rows[i]["type_int"].ToString());
                        if (objdt.Rows[i]["INTERNALFLAG_INT"] != null && objdt.Rows[i]["INTERNALFLAG_INT"].ToString().Trim() != "")
                        {
                            objRI_VO[i].m_intINTERNALFLAG_INT = int.Parse(objdt.Rows[i]["INTERNALFLAG_INT"].ToString());
                        }
                        else
                        {
                            objRI_VO[i].m_intINTERNALFLAG_INT = 0;
                        }
                        if (objdt.Rows[i]["PAYLIMIT_MNY"] != null && objdt.Rows[i]["PAYLIMIT_MNY"].ToString().Trim() != "")
                        {
                            objRI_VO[i].decLimint = decimal.Parse(objdt.Rows[i]["PAYLIMIT_MNY"].ToString());
                        }
                        else
                        {
                            objRI_VO[i].decLimint = 0;
                        }
                        if (objdt.Rows[i]["CHARGEPERCENT_DEC"] != null && objdt.Rows[i]["CHARGEPERCENT_DEC"].ToString().Trim() != "")
                        {
                            objRI_VO[i].decDiscount = decimal.Parse(objdt.Rows[i]["CHARGEPERCENT_DEC"].ToString());
                        }
                        else
                        {
                            objRI_VO[i].decDiscount = 0;
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

        #region 按处方ID查找以往处方明细
        [AutoComplete]
        public long m_mthFindRecipeByID(string ID, out DataTable p_dtItemDe, System.Security.Principal.IPrincipal objPri, bool flag)
        {
            p_dtItemDe = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            if (flag)
            {
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                    DataTable p_dtTemp = new DataTable();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    strSQL = @"select a.outpatrecipeid_chr, a.itemid_chr itemid, a.unitid_chr unit,
                 a.tolqty_dec quantity, a.unitprice_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
                 a.freqid_chr, a.qty_dec, a.days_int,
                 a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (1000 + to_number (nvl (a.rowno_vchr2, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, b.itemipunit_chr,
                 round (b.itemprice_mny / b.packqty_dec, 4) submoney,
                 b.opchargeflg_int, b.itemopcalctype_chr, a.discount_dec,
                 b.itemcode_vchr, '' as attachid_vchr, a.hypetest_int,
                 a.desc_vchr, a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 '' as orderid, 0 as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr,c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_tmp_outpatientpwmrecipede a, t_bse_chargeitem b,
            t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";

                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    object[] m_objItemArr;
                    p_dtItemDe = p_dtTemp.Clone();
                    DataRow m_objTempDr;
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @" select a.outpatrecipeid_chr, a.itemid_chr itemid, a.unitid_chr unit,
                 a.min_qty_dec quantity, a.unitprice_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
                 '' as freqid_chr, min_qty_dec as qty_dec, 1 as days_int,
                 b.itemname_vchr itemname, b.itemspec_vchr dec,
                 a.sumusage_vchr,
                 (2000 + to_number (nvl (a.rowno_vchr2, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, a.times_int times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 '' as attachid_vchr, 0, a.usagedetail_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 '' as orderid, 0 as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_tmp_outpatientcmrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @" select a.outpatrecipeid_chr, a.itemid_chr itemid,
                 a.itemunit_vchr unit, a.qty_dec quantity, a.price_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, '' as usageid_chr,
                 '' as freqid_chr, 0 as qty_dec, 1 as days_int,
                 a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (3000 + to_number (nvl (a.rowno_chr, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 a.attachid_vchr, 0, a.itemusagedetail_vchr as desc_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_tmp_outpatientchkrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select a.outpatrecipeid_chr, a.itemid_chr itemid,
                 a.itemunit_vchr unit, a.qty_dec quantity, a.price_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
                 '' as freqid_chr, 0 as qty_dec, 1 as days_int,
                 a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (4000 + to_number (nvl (a.rowno_chr, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 a.attachid_vchr, 0, a.itemusagedetail_vchr as desc_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_tmp_outpatienttestrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select a.outpatrecipeid_chr, a.itemid_chr itemid,
                 a.itemunit_vchr unit, a.qty_dec quantity,
                 a.unitprice_mny price, a.tolprice_mny summoney, a.rowno_chr,
                 '' as usageid_chr, '' as freqid_chr, 0 as qty_dec,
                 1 as days_int, a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (6000 + to_number (nvl (a.rowno_chr, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 a.attachid_vchr, 0, a.itemusagedetail_vchr as desc_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 '' as orderid, 0 as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_tmp_outpatientothrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select a.outpatrecipeid_chr, a.itemid_chr itemid,
                 a.itemunit_vchr unit, a.qty_dec quantity, a.price_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
                 '' as freqid_chr, 0 as qty_dec, 1 as days_int,
                 a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (5000 + to_number (nvl (a.rowno_chr, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 a.attachid_vchr, 0, a.itemusagedetail_vchr as desc_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_tmp_outpatientopsrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
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
            else
            {
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                    DataTable p_dtTemp = new DataTable();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    strSQL = @"select a.outpatrecipeid_chr, a.itemid_chr itemid, a.unitid_chr unit,
                 a.tolqty_dec quantity, a.unitprice_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
                 a.freqid_chr, a.qty_dec, a.days_int,
                 a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (1000 + to_number (nvl (a.rowno_vchr2, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, b.itemipunit_chr,
                 round (b.itemprice_mny / b.packqty_dec, 4) submoney,
                 b.opchargeflg_int, b.itemopcalctype_chr, a.discount_dec,
                 b.itemcode_vchr, '' as attachid_vchr, a.hypetest_int,
                 a.desc_vchr, a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 '' as orderid, 0 as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_opr_outpatientpwmrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";

                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    object[] m_objItemArr;
                    p_dtItemDe = p_dtTemp.Clone();
                    DataRow m_objTempDr;
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @" select a.outpatrecipeid_chr, a.itemid_chr itemid, a.unitid_chr unit,
                 a.min_qty_dec quantity, a.unitprice_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
                 '' as freqid_chr, min_qty_dec as qty_dec, 1 as days_int,
                 b.itemname_vchr itemname, b.itemspec_vchr dec,
                 a.sumusage_vchr,
                 (2000 + to_number (nvl (a.rowno_vchr2, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, a.times_int times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 '' as attachid_vchr, 0, a.usagedetail_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 '' as orderid, 0 as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_opr_outpatientcmrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @" select a.outpatrecipeid_chr, a.itemid_chr itemid,
                 a.itemunit_vchr unit, a.qty_dec quantity, a.price_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, '' as usageid_chr,
                 '' as freqid_chr, 0 as qty_dec, 1 as days_int,
                 a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (3000 + to_number (nvl (a.rowno_chr, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 a.attachid_vchr, 0, a.itemusagedetail_vchr as desc_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr,c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_opr_outpatientchkrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select a.outpatrecipeid_chr, a.itemid_chr itemid,
                 a.itemunit_vchr unit, a.qty_dec quantity, a.price_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
                 '' as freqid_chr, 0 as qty_dec, 1 as days_int,
                 a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (4000 + to_number (nvl (a.rowno_chr, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 a.attachid_vchr, 0, a.itemusagedetail_vchr as desc_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_opr_outpatienttestrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select a.outpatrecipeid_chr, a.itemid_chr itemid,
                 a.itemunit_vchr unit, a.qty_dec quantity,
                 a.unitprice_mny price, a.tolprice_mny summoney, a.rowno_chr,
                 '' as usageid_chr, '' as freqid_chr, 0 as qty_dec,
                 1 as days_int, a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (6000 + to_number (nvl (a.rowno_chr, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 a.attachid_vchr, 0, a.itemusagedetail_vchr as desc_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 '' as orderid, 0 as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_opr_outpatientothrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select a.outpatrecipeid_chr, a.itemid_chr itemid,
                 a.itemunit_vchr unit, a.qty_dec quantity, a.price_mny price,
                 a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
                 '' as freqid_chr, 0 as qty_dec, 1 as days_int,
                 a.itemname_vchr itemname, a.itemspec_vchr dec,
                 '' as sumusage_vchr,
                 (5000 + to_number (nvl (a.rowno_chr, 0))) as sortno,
                 b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
                 b.dosageunit_chr, b.insuranceid_chr,
                 b.selfdefine_int selfdefine, 1 times, '', 1, 0,
                 b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr,
                 a.attachid_vchr, 0, a.itemusagedetail_vchr as desc_vchr,
                 a.attachparentid_vchr, a.attachitembasenum_dec,
                 a.usageparentid_vchr, a.usageitembasenum_dec, a.deptmed_int,
                 a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,
       c.outpatrecipeid_chr, c.patientid_chr, c.createdate_dat,
       c.registerid_chr, c.diagdr_chr, c.diagdept_chr, c.recordemp_chr,
       c.recorddate_dat, c.pstauts_int, c.recipeflag_int,
       c.outpatrecipeno_vchr, c.paytypeid_chr, c.casehisid_chr, c.groupid_chr,
       c.type_int, c.confirm_int, c.confirmdesc_vchr, c.createtype_int,
       c.deptmed_int
            from t_opr_outpatientopsrecipede a, t_bse_chargeitem b,
       t_opr_outpatientrecipe c
           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?  and a.outpatrecipeid_chr = c.outpatrecipeid_chr order by sortno";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = ID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
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

            return lngRes;
        }
        #endregion

        #region  按病人ID查找最近一次没有收费的处方号
        [AutoComplete]
        public long m_mthFindMaxRecipeNoByPatientID(string ID, out string strRecipeNo, out string strstatus, out int RecipeCount, out DataTable dt)
        {
            strRecipeNo = "";
            strstatus = "";
            long lngRes = 0;
            RecipeCount = 0;
            dt = null;
            DataTable objdt = new DataTable();
            string strSQL = @"select   a.outpatrecipeid_chr, a.patientid_chr, a.createdate_dat,
         a.registerid_chr, a.diagdr_chr, a.diagdept_chr, a.recordemp_chr,
         a.recorddate_dat, a.pstauts_int, a.recipeflag_int,
         a.outpatrecipeno_vchr, a.paytypeid_chr, a.casehisid_chr,
         a.groupid_chr, a.type_int, a.confirm_int, a.confirmdesc_vchr,
         a.createtype_int, a.deptmed_int, b.coalitionrecipeflag_int
     from t_opr_outpatientrecipe a, t_bse_patientpaytype b
     where a.paytypeid_chr = b.paytypeid_chr(+)
     and (a.pstauts_int = 1 or a.pstauts_int = 4)
     and a.patientid_chr = ?
     and a.recorddate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                              and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
     order by a.recipeflag_int asc, a.recorddate_dat desc";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = ID;
                ParamArr[1].Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                ParamArr[2].Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref objdt, ParamArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && objdt.Rows.Count > 0)
                {
                    RecipeCount = objdt.Rows.Count;
                    strRecipeNo = objdt.Rows[0]["OUTPATRECIPEID_CHR"].ToString();
                    strstatus = objdt.Rows[0]["pstauts_int"].ToString();
                    string strTempDocID = objdt.Rows[0]["DIAGDR_CHR"].ToString().Trim();
                    string strTempPatientTypeID = objdt.Rows[0]["PAYTYPEID_CHR"].ToString().Trim();
                    bool tempFlag = false;
                    int TempCount = 0;
                    for (int i = 0; i < objdt.Rows.Count; i++)
                    {
                        if (strTempDocID == objdt.Rows[i]["DIAGDR_CHR"].ToString().Trim() && strTempPatientTypeID == objdt.Rows[i]["PAYTYPEID_CHR"].ToString().Trim())
                        {
                            TempCount++;
                            tempFlag = strstatus == "4";
                            DataTable tmepTable;
                            m_mthFindRecipeByID(objdt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim(), out tmepTable, null, tempFlag);
                            if (dt == null)
                            {
                                dt = tmepTable.Clone();
                            }
                            for (int i2 = 0; i2 < tmepTable.Rows.Count; i2++)
                            {
                                dt.Rows.Add(tmepTable.Rows[i2].ItemArray);
                            }
                            dt.AcceptChanges();
                            if (objdt.Rows[0]["coalitionrecipeflag_int"].ToString().Trim() == "0")//如果病人身份定义了不能合并则退出
                            {
                                break;
                            }
                        }
                    }
                    strstatus = TempCount.ToString();
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

        #region 根据患者ID统计当天内所有未收费处方信息
        /// <summary>
        /// 根据患者ID统计当天内所有未收费处方信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="recsum"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllrecinfoBypid(string pid, out int recsum, out DataTable dtRecord)
        {
            recsum = 0;
            dtRecord = null;
            string SQL = @"select a.outpatrecipeid_chr, a.patientid_chr, a.createdate_dat,
                                   a.registerid_chr, a.diagdr_chr, a.diagdept_chr, a.recordemp_chr,
                                   a.recorddate_dat, a.pstauts_int, a.recipeflag_int,
                                   a.outpatrecipeno_vchr, a.paytypeid_chr, a.casehisid_chr, a.groupid_chr,
                                   a.type_int, a.confirm_int, a.confirmdesc_vchr, a.createtype_int,
                                   a.deptmed_int
                              from t_opr_outpatientrecipe a
                             where (a.pstauts_int = 1 or a.pstauts_int = 4)
                               and a.patientid_chr = ?
                               and trunc(a.recorddate_dat) = trunc(?)";

            long lngRes = 0;
            DataTable dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = pid;
                ParamArr[1].Value = DateTime.Now;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    recsum = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string recno = dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim();
                        string status = dt.Rows[i]["pstauts_int"].ToString();
                        bool flag = (status == "4");
                        DataTable dt2 = new DataTable();

                        m_mthFindRecipeByID(recno, out dt2, null, flag);

                        if (dtRecord == null)
                        {
                            dtRecord = dt2.Clone();
                        }
                        if (dt != null)
                        {
                            for (int j = 0; j < dt2.Rows.Count; j++)
                            {
                                dtRecord.Rows.Add(dt2.Rows[j].ItemArray);
                            }
                            dtRecord.AcceptChanges();
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

        #region 删除处方明细
        [AutoComplete]
        public long m_mthDeleteRecipeDetail(string ID)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {

                string strSQL = "P_DELETEOPRRECIPEBYID ";
                com.digitalwave.iCare.ValueObject.clsSQLParamDefinitionVO[] objParams = new clsSQLParamDefinitionVO[1];

                objParams[0] = new clsSQLParamDefinitionVO();
                objParams[0].objParameter_Value = ID;
                objParams[0].strParameter_Type = clsOracleDbType.strChar;
                objParams[0].strParameter_Name = "RecipeID";
                lngRes = objHRPSvc.lngExecuteParameterProc(strSQL, objParams);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion

        #region 检查发票号是否已用
        [AutoComplete]
        public bool m_mthCheckInvoice(System.Security.Principal.IPrincipal p_objPrincipal, string strInvoiceNo)
        {
            bool b = false;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthCheckInvoice");
            if (lngRes < 0)
            {
                return b;
            }
            string strSQL = @"select invoiceno_vchr as invono
  from t_opr_outpatientrecipeinv
 where invoiceno_vchr = ?
union all
select repprninvono_vchr as invono
  from t_opr_invoicerepeatprint
 where type_chr = '1' and repprninvono_vchr = ?";

            DataTable dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strInvoiceNo;
                ParamArr[1].Value = strInvoiceNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    b = true;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return b;
        }
        #endregion

        #region 查找对应表信息
        [AutoComplete]
        public long m_mthRelationInfo(out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"select a.mapid_chr, a.groupid_chr, a.catid_chr, a.internalflag_int
                              from t_bse_chargecatmap a
                              where a.internalflag_int = 1";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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

        #region 获取发票表的流水号
        //		public static string m_mthGetSEQID(DateTime date)
        //		{
        //			DataTable dt=new DataTable();
        //			string str="";
        //			string strSQL = @"select count(*)+1   from T_OPR_OUTPATIENTRECIPEINV where INVDATE_DAT between 
        //to_date('"+date.ToString("yyyy-MM-dd 00:00:00")+@"','yyyy-mm-dd hh24:mi:ss') and to_date('"+date.ToString("yyyy-MM-dd 23:59:59")+@"','yyyy-mm-dd hh24:mi:ss')";
        //			try
        //			{
        //				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //			long lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
        //				if(lngRes>0&&dt.Rows.Count>0)
        //				{
        //				str=dt.Rows[0][0].ToString().PadLeft(6,'0');
        //				str=date.ToString("yyyyMMdd")+str;
        //				}
        //				objHRPSvc.Dispose();
        //			}
        //			catch(Exception objEx)
        //			{
        //				string strTmp=objEx.Message;
        //				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //				bool blnRes = objLogger.LogError(objEx);
        //			}
        //			return str;
        //		}
        #endregion

        #region 带出默认项目
        /// <summary>
        /// 带出默认项目
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strPatientTypeID"></param>
        /// <param name="strRecipeflag"></param>
        /// <param name="strDuty"></param>
        /// <param name="strRecipeID"></param>
        /// <returns></returns>     
        [AutoComplete]
        public long m_mthGetDefaultItem(out DataTable dt, string strPatientTypeID, string strRecipeflag, string strDuty, string strRecipeID, string strRegID)
        {
            dt = new DataTable();
            long lngRes = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select a.archtakeflag_int from t_opr_outpatientrecipe a where a.outpatrecipeid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRecipeID;

                int intArchTakeFlag = 2;
                DataTable dtTmp = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtTmp, ParamArr);
                if (lngRes > 0 && dtTmp.Rows.Count > 0)
                {
                    if (dtTmp.Rows[0][0].ToString().Trim() != "")
                    {
                        intArchTakeFlag = (int.Parse(dtTmp.Rows[0][0].ToString()) == 1 ? 1 : 2);
                    }
                }
                if (strRecipeID.Trim() == "" && strRegID.Trim() != "")
                {
                    intArchTakeFlag = 1;
                }

                SQL = @"select a.paytypeid_chr, a.itemid_chr, a.qty_dec, a.regflag_int, a.recflag_int,
                               a.dutyname_vchr, a.begintime_chr, a.endtime_chr
                          from t_aid_outpatientdefaultadditem a
                         where (a.paytypeid_chr = ? or a.paytypeid_chr = '0000')
                           and (a.regflag_int = ? or a.regflag_int = 0)
                           and (a.recflag_int = ? or a.recflag_int = 0)
                           and (a.dutyname_vchr = ? or a.dutyname_vchr = '全部')
                           and (to_char (sysdate, 'hh24:mi') between a.begintime_chr and a.endtime_chr)";

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = intArchTakeFlag;
                ParamArr[2].Value = strRecipeflag;
                ParamArr[3].Value = strDuty;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 带出默认项目
        /// <summary>
        /// 带出默认项目
        /// </summary>
        /// <param name="strPatientTypeID"></param>
        /// <param name="strRegister"></param>
        /// <param name="strRecipeflag"></param>
        /// <param name="strExpert"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetDefaultItem(string strPatientTypeID, string strRegister, string strRecipeflag, string strExpert, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            string strSQL = @"select a.paytypeid_chr, a.itemid_chr, a.qty_dec, a.register_int,
                                   a.recipeflag_int, a.expert_int
                              from t_aid_chargepaytype a
                             where (a.paytypeid_chr = ? or a.paytypeid_chr = '0000')
                               and (a.register_int = ? or a.register_int = 0)
                               and (a.recipeflag_int = ? or a.recipeflag_int = 0)
                               and (a.expert_int = ? or a.expert_int = 0)";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = strRegister;
                ParamArr[2].Value = strRecipeflag;
                ParamArr[3].Value = strExpert;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 带出默认项目
        /// <summary>
        /// 带出默认项目
        /// </summary>
        /// <param name="strItemID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetDefaultItem(string strItemID, string strPatType, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string strSQL = @"select distinct a.itemid_chr, a.itemname_vchr, a.itemspec_vchr,
                                    a.itemengname_vchr, a.itemcode_vchr as tempitemcode,
                                    a.insuranceid_chr, a.itemopunit_chr, a.itemprice_mny,
                                    a.itemopinvtype_chr, a.itemcatid_chr, a.selfdefine_int,
                                    a.itemcode_vchr, a.itemopcalctype_chr, a.dosage_dec,
                                    a.dosageunit_chr, f.precent_dec, c.qty_dec as itemnum,
                                    b.noqtyflag_int, a.itemipunit_chr,
                                    round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                    a.opchargeflg_int, a.itemunit_chr as unit
                               from t_bse_chargeitem a,
                                    t_bse_medicine b,
                                    (select precent_dec, itemid_chr, copayid_chr
                                       from t_aid_inschargeitem
                                      where copayid_chr = ?) f,
                                    t_aid_outpatientdefaultadditem c
                              where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
                                and a.ifstop_int = 0
                                and a.itemid_chr = ?
                                and a.itemid_chr = f.itemid_chr(+)
                                and a.itemid_chr = c.itemid_chr
                           order by a.itemcode_vchr ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strPatType;
                ParamArr[1].Value = strItemID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 查出收费医院选项
        [AutoComplete]
        public void m_mthGetChooseHospitalInfo(out clsChargeHospitalInfoVO[] objCHInfoVOArr)
        {
            objCHInfoVOArr = null;
            string strSQL = @"select a.setid_chr, a.setname_vchr, a.setdesc_vchr, a.setstatus_int,
                                   a.moduleid_chr
                              from t_sys_setting a where a.setid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = "0005";

                DataTable dt = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() == "1")
                    {
                        strSQL = @"select   a.internalflag_int, a.internaldesc_vchr
                                        from t_opr_outpatientrecipeinv_itl a
                                    order by a.internalflag_int
                                    ";
                        dt = new DataTable();
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                        if (lngRes > 0 && dt.Rows.Count > 0)
                        {
                            objCHInfoVOArr = new clsChargeHospitalInfoVO[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                objCHInfoVOArr[i] = new clsChargeHospitalInfoVO();
                                objCHInfoVOArr[i].strID = dt.Rows[i]["INTERNALFLAG_INT"].ToString().Trim();
                                objCHInfoVOArr[i].strName = dt.Rows[i]["INTERNALDESC_VCHR"].ToString().Trim();
                            }

                        }
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

        }
        #endregion

        #region 查出能否做一些系统设置的操作
        [AutoComplete]
        public int m_mthIsCanDo(string p_flag)
        {
            int ret = 0;
            string strSQL = @"select a.setid_chr, a.setname_vchr, a.setdesc_vchr, a.setstatus_int,
       a.moduleid_chr
  from t_sys_setting a where a.setid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_flag;

                DataTable dt = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() != "")
                    {
                        ret = int.Parse(dt.Rows[0]["SETSTATUS_INT"].ToString());
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

        #region 获取科室编号
        /// <summary>
        /// 获取科室编号
        /// </summary>
        /// <param name="p_strDeptID"></param>
        /// <param name="dt"></param>
        [AutoComplete]
        public void m_mthGetDeptNO(string p_strDeptID, out DataTable dt)
        {
            dt = new DataTable();

            string strSQL = "select ShortNO_Chr from t_bse_DeptDesc where DeptID_Chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strDeptID;

                objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        #endregion

        #region 判断是否材料项目
        /// <summary>
        /// 判断是否材料项目
        /// </summary>
        /// <param name="strChrgItem"></param>
        /// <returns></returns>		
        [AutoComplete]
        public bool m_blnCheckMaterial(string strChrgItem)
        {
            long lngRes = 0;
            bool blnRet = false;
            string SQL = @"select count (*) nums
  from t_bse_chargeitem a, t_aid_chargemderla b
 where a.itemcatid_chr = b.itemcatid_chr
   and b.medicinetypeid_chr = '5'
   and a.itemid_chr = ?";

            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strChrgItem;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows[0][0].ToString() != "0")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }
        #endregion

        #region 判断是否专家或外来专家
        /// <summary>
        /// 判断是否专家或外来专家
        /// </summary>
        /// <param name="strEmpID"></param>
        /// <returns></returns>		
        [AutoComplete]
        public bool m_blnCheckExpert(string strEmpID)
        {
            long lngRes = 0;
            bool blnRet = false;
            string SQL = @"select count(empid_chr) nums from t_bse_employee 
						   where empid_chr = ? and (isexpert_chr = '1' or isexternalexpert_chr = '1')";

            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strEmpID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows[0][0].ToString() != "0")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }
        #endregion

        #region 根据挂号ID判断是否为正常挂号
        /// <summary>
        /// 根据挂号ID判断是否为正常挂号
        /// </summary>
        /// <param name="strRegID"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckNormalReg(string strRegID)
        {
            long lngRes = 0;
            bool blnRet = false;
            string SQL = "";
            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                int TimeInterval = 0;
                DataTable dt = new DataTable();
                SQL = @"select setstatus_int from t_sys_setting where setid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = "0067";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count == 1)
                {
                    string s = dt.Rows[0][0].ToString().Trim();
                    if (s != "" && Convert.ToInt32(s) > 0)
                    {
                        TimeInterval = Convert.ToInt32(s);
                    }
                }

                SQL = @"select count(registerid_chr) as nums 
                             from t_opr_patientregister 
						   where registerid_chr = ?  
                             and pstatus_int <> 3 
                             and flag_int <> 3
                             and (sysdate between recorddate_dat and (recorddate_dat + ?/24))";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strRegID;
                ParamArr[1].Value = TimeInterval;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows[0][0].ToString() != "0")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }

        #endregion

        #region 根据收费项目ID获取该项目药房分类
        /// <summary>
        /// 根据收费项目ID获取该项目药房分类
        /// </summary>
        /// <param name="strChrgItem"></param>
        [AutoComplete]
        public string m_strGetOutSendMedStoretype(string strChrgItem)
        {
            long lngRes = 0;
            string strMedStoretype = "";
            DataTable dtRecord = new DataTable();

            //          string SQL = @"select b.OutMedStoreID_CHR from t_bse_chargeitem a, t_aid_chargemderla b, t_bse_medicine c 
            //			    		   where a.itemcatid_chr = b.itemcatid_chr and a.itemsrcid_vchr = c.medicineid_chr and a.itemid_chr = '" + strChrgItem + "'";

            string SQL = @"select a.medicnetype_int 
                             from t_bse_medicine a,
                                  t_bse_chargeitem b
                            where a.medicineid_chr = b.itemsrcid_vchr
                              and b.itemid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strChrgItem;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtRecord.Rows.Count == 1)
            {
                strMedStoretype = dtRecord.Rows[0][0].ToString().Trim();
                if (strMedStoretype == null)
                {
                    strMedStoretype = "";
                }
            }
            return strMedStoretype;
        }
        #endregion

        #region 获取收费项目关联的子项目
        /// <summary>
        /// 获取收费项目关联的子项目
        /// </summary>
        /// <param name="p_strPatientTypeID"></param>
        /// <param name="p_strChargeItem"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSubChargeItem(string p_strPatientTypeID, string p_strChargeItem, out DataTable dtRecord)
        {
            long lngRes = 0;
            string SQL = @"select a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr, a.itemcode_vchr, a.itemopunit_chr, a.itemprice_mny, 
								  a.itemopinvtype_chr, a.itemcatid_chr, a.selfdefine_int, a.itemopcalctype_chr, a.dosage_dec, a.dosageunit_chr, c.precent_dec,  
								  b.noqtyflag_int, a.itemipunit_chr, Round(a.itemprice_mny / a.packqty_dec, 4) as submoney, a.opchargeflg_int, a.itemunit_chr as unit, a.ifstop_int, 
								  d.totalqty_dec 
							 from t_bse_chargeitem a, 
								  t_bse_medicine b,
								  (select * from t_aid_inschargeitem where copayid_chr = ?) c,
								  (select * from t_bse_subchargeitem where itemid_chr = ?) d 
							where a.itemsrcid_vchr = b.medicineid_chr(+) 
							  and a.itemid_chr = c.itemid_chr(+)
							  and a.itemid_chr = d.subitemid_chr ";

            dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = p_strPatientTypeID;
                ParamArr[1].Value = p_strChargeItem;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 获取支付卡类型列表
        /// <summary>
        /// 获取支付卡类型列表
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPaycardtype(out DataTable dtRecord)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            string strSQL = @"select a.paycardtype_int,a.paycarddesc_vchr from t_bse_paycardtype a  order by a.paycardtype_int";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtRecord);
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

        #region 获取患者结算卡卡号列表
        /// <summary>
        /// 获取患者结算卡卡号列表
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPaycardno(out DataTable dtRecord, string pid)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            string strSQL = @"select a.patientid_chr,a.modify_dat,a.paycardtype_int,a.paycardtype_int,a.paycardno_vchr,a.paycardstatus_int  from t_bse_patientcardtype a where a.paycardstatus_int = 1 and patientid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = pid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecord, ParamArr);
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

        #region 根据PID获取患者当天发药信息
        /// <summary>
        /// 根据PID获取患者当天发药信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetsendmedinfoBypid(string pid, string medid, out DataTable dtRecord)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            string SQL = @"select a.outpatrecipeid_chr, a.recipetype_int, a.windowid_chr, a.pstatus_int,
       a.senddate_dat, a.sendemp_chr, a.treatdate_dat, a.treatemp_chr,
       a.autoprint_int, a.medstoreid_chr, a.finallysendwindowid,
       a.finallywindowid, a.sendwindowid, a.givedate_dat, a.giveemp_chr,
       a.returndate_dat, a.returnemp_chr, a.remark_vchr,
       decode (d.order_int, null, 0, d.order_int) as order_int
  from t_opr_medrecipesend a,
       t_opr_outpatientrecipe b,
       t_bse_medstorewin c,
       t_opr_medstorewinque d
 where a.outpatrecipeid_chr = b.outpatrecipeid_chr
   and a.pstatus_int <> -1
   and b.pstauts_int = 2
   and c.windowtype_int = 1
   and c.workstatus_int = 1
   and a.medstoreid_chr = c.medstoreid_chr
   and a.windowid_chr = c.windowid_chr
   and a.medstoreid_chr = d.medstoreid_chr
   and a.windowid_chr = d.windowid_chr
   and a.outpatrecipeid_chr=d.outpatrecipeid_chr
   and to_char (a.senddate_dat, 'yyyy-mm-dd') =to_char (sysdate, 'yyyy-mm-dd')
   and b.patientid_chr = ?
   and a.medstoreid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = pid;
                ParamArr[1].Value = medid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 保存发票重打信息
        /// <summary>
        /// 保存发票重打信息
        /// </summary>
        /// <param name="TypeID"> '1' 收费发票 '2' 挂号发票</param>
        /// <param name="Seqid"></param>
        /// <param name="Oldinvono"></param>
        /// <param name="Newinvono"></param>
        /// <param name="Empid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveinvorepeatprninfo(string TypeID, string Seqid, string Oldinvono, string Newinvono, string Empid)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";
            string repinvono = this.m_strGetrepeatprninvono(TypeID, Seqid, Oldinvono);

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (repinvono != "")
                {
                    SQL = @"update t_opr_invoicerepeatprint
                            set printstatus_int = 1   
                          where type_chr = ? 
                            and trim(seqid_chr) = ? 
                            and repprninvono_vchr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = TypeID;
                    ParamArr[1].Value = Seqid.Trim();
                    ParamArr[2].Value = repinvono;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    Oldinvono = repinvono;
                }

                SQL = @"insert into t_opr_invoicerepeatprint(seqid_chr, sourceinvono_vchr, repprninvono_vchr, printemp_chr, printdate_dat, printstatus_int, type_chr)
                        values(?, ?, ?, ?, sysdate, 0, ?)";

                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                ParamArr[0].Value = Seqid;
                ParamArr[1].Value = Oldinvono;
                ParamArr[2].Value = Newinvono;
                ParamArr[3].Value = Empid;
                ParamArr[4].Value = TypeID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        [AutoComplete]
        private string m_strGetrepeatprninvono(string TypeID, string Seqid, string Oldinvono)
        {
            long lngRes = 0;
            string invono = "";
            string SQL = @" select repprninvono_vchr
                              from t_opr_invoicerepeatprint
                             where type_chr = ?  
                               and printstatus_int = 0
                               and trim(seqid_chr) = ? 
                               and sourceinvono_vchr = ?";

            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = TypeID;
                ParamArr[1].Value = Seqid.Trim();
                ParamArr[2].Value = Oldinvono;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dt.Rows.Count == 1)
            {
                invono = dt.Rows[0][0].ToString().Trim();
            }

            return invono;
        }
        #endregion

        #region 根据结帐人、结帐时间获取相应的重打发票信息
        /// <summary>
        /// 根据结帐人、结帐时间获取相应的重打发票信息
        /// </summary>
        /// <param name="BalanceEmp"></param>
        /// <param name="BalanceTime"></param>
        /// <returns></returns>
        [AutoComplete]
        public void m_mthGetbalancerepeatinvoinfo(string BalanceEmp, string BalanceTime, out string[] InvonoArr, int status, out decimal[] invoMoneyArr)
        {
            InvonoArr = null;
            invoMoneyArr = null;
            DataTable dt = new DataTable();
            long lngRes = 0;

            string strSQL1 = @"select distinct max(balance_dat)
                                  from t_opr_outpatientrecipeinv
                                 where balanceemp_chr = ?
                                   and balance_dat < to_date(?,'yyyy-mm-dd hh24:mi:ss')
                                   and balanceflag_int = 1
                                 order by balance_dat";


            string strSQL2 = @"select b.repprninvono_vchr, b.sourceinvono_vchr, a.totalsum_mny, a.totaldiffcost_mny  
                      from t_opr_outpatientrecipeinv a,
                           t_opr_invoicerepeatprint b
                     where a.seqid_chr = b.seqid_chr 
                       and b.type_chr = '1' 
                       and a.recordemp_chr = ? 
                       and b.printdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                       and (a.isvouchers_int < 2 or a.isvouchers_int is null)
                    order by b.repprninvono_vchr";


            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] ParamArr1 = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr1);
                ParamArr1[0].Value = BalanceEmp;
                ParamArr1[1].Value = Convert.ToDateTime(BalanceTime).ToString("yyyy-MM-dd HH:mm:ss");
                DataTable dtResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtResult, ParamArr1);

                string strBeginDate = "";
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    strBeginDate = dtResult.Rows[0][0].ToString();
                }
                if (strBeginDate == "")
                    strBeginDate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss");

                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = BalanceEmp;
                ParamArr[1].Value = strBeginDate;
                ParamArr[2].Value = Convert.ToDateTime(BalanceTime).ToString("yyyy-MM-dd HH:mm:ss");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref dt, ParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                InvonoArr = new string[dt.Rows.Count];
                invoMoneyArr = new decimal[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    InvonoArr[i] = dt.Rows[i]["repprninvono_vchr"].ToString() + "(" + dt.Rows[i]["sourceinvono_vchr"].ToString() + ")";

                    decimal d1 = 0;
                    decimal d2 = 0;
                    decimal.TryParse(dt.Rows[i]["totalsum_mny"].ToString(), out d1);
                    decimal.TryParse(dt.Rows[i]["totaldiffcost_mny"].ToString(), out d2);
                    invoMoneyArr[i] = d1 - d2;
                }
            }
        }
        /// <summary>
        /// 根据结帐人、结帐时间获取相应的重打发票信息
        /// </summary>
        /// <param name="BalanceEmp">结帐人ID</param>
        /// <param name="strBeginDate">开始时间</param>
        /// <param name="strEndDate">结束时间</param>
        /// <param name="InvonoArr">返回结果</param>
        /// <param name="intMode">0为发票时间，1为结算时间</param>
        /// <returns></returns>
        [AutoComplete]
        public void m_mthGetbalancerepeatinvoinfo(string BalanceEmp, string strBeginDate, string strEndDate, out string[] InvonoArr, int intMode)
        {
            InvonoArr = null;
            DataTable dt = new DataTable();
            long lngRes = 0;
            string SQL = @"select b.repprninvono_vchr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_invoicerepeatprint b
                     where a.seqid_chr = b.seqid_chr 
                       and a.balanceflag_int = 0 
                       and b.type_chr = '1' 
                       {emp}
                       and a.{date} between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                    order by b.repprninvono_vchr";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                if (BalanceEmp != "1000")
                {
                    SQL = SQL.Replace("{emp}", "a.recordemp_chr = ?");
                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = BalanceEmp;
                    ParamArr[1].Value = strBeginDate;
                    ParamArr[2].Value = strEndDate;
                }
                else
                {
                    SQL = SQL.Replace("{emp}", "");
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = strBeginDate;
                    ParamArr[1].Value = strEndDate;
                }
                if (intMode == 0)
                {
                    SQL = SQL.Replace("{date}", "recorddate_dat");
                }
                else
                {
                    SQL = SQL.Replace("{date}", "balance_dat");
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                InvonoArr = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    InvonoArr[i] = dt.Rows[i][0].ToString();
                }
            }
        }
        #endregion

        #region 根据处方号判断一张处方是否是医生工作站所开并且为已收费(或退票)处方
        /// <summary>
        /// 根据处方号判断一张处方是否是医生工作站所开并且为已收费(或退票)处方
        /// </summary>
        /// <param name="recno"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckRecipeProperty(string recno)
        {
            long lngRes = 0;
            bool blnRet = false;

            string SQL = @"select count(a.outpatrecipeid_chr) as nums
                           from t_opr_outpatientrecipe a                              
                           where a.createtype_int = 0
                             and (a.pstauts_int = -2 or a.pstauts_int = 2 or a.pstauts_int = 3)
                             and a.outpatrecipeid_chr = ?";

            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = recno;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
                if (lngRes > 0)
                {
                    if (dtRecord.Rows[0][0].ToString() != "0")
                    {
                        blnRet = true;
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return blnRet;
        }
        #endregion

        #region 根据接诊科室、药房获取专用窗口信息
        /// <summary>
        /// 根据接诊科室、药房获取专用窗口信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="medin"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetespecialwin(string deptid, string medid, out string winid, out int waitno)
        {
            winid = "";
            waitno = 1;
            DataTable dt = new DataTable();
            long lngRes = 0;

            string Recdate = DateTime.Now.ToString("yyyyMMdd");

            string SQL = @"select t1.windowid_chr, nvl(t3.ordermax,0) as ordermax, nvl(t3.ordercount,0) as ordercount
                             from t_bse_medstorewin t1,                                  
                                   (select windowid_chr
                                      from t_bse_medstorewindeptdef 
                                     where deptid_chr = ? and medstoreid_chr = ?) t2,                              
                                   (select a.medstoreid_chr, a.windowid_chr, b.ordercount, a.ordermax      
                                      from (select medstoreid_chr, windowid_chr, max(order_int) as ordermax
                                              from t_opr_medstorewinque
                                             where windowtype_int = 1
                                               and medstoreid_chr = ?
                                               and outpatrecipeid_chr like ? 
                                            group by medstoreid_chr, windowid_chr) a,
                                           (select medstoreid_chr, windowid_chr, count(order_int) as ordercount
                                              from t_opr_medstorewinque
                                             where windowtype_int = 1
                                               and medstoreid_chr = ? 
                                               and outpatrecipeid_chr like ? 
                                            group by medstoreid_chr, windowid_chr) b
                                     where a.medstoreid_chr = b.medstoreid_chr
                                       and a.windowid_chr = b.windowid_chr) t3
                              where t1.winproperty_int = 1
                                and t1.windowtype_int = 1
                                and t1.workstatus_int = 1
                                and t1.windowid_chr = t2.windowid_chr
                                and t1.windowid_chr = t3.windowid_chr(+)
                                and t1.medstoreid_chr = t3.medstoreid_chr(+)
                            order by ordercount";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = deptid;
                ParamArr[1].Value = medid;
                ParamArr[2].Value = medid;
                ParamArr[3].Value = Recdate + "%";
                ParamArr[4].Value = medid;
                ParamArr[5].Value = Recdate + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    winid = dt.Rows[0]["windowid_chr"].ToString();
                    waitno = Convert.ToInt32(dt.Rows[0]["ordermax"]) + 1;
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

        #region 根据发票表.发票号获取医保记帐单号
        /// <summary>
        /// 根据发票表.发票号获取医保记帐单号
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetBillNoByInvoNo(string InvoNo)
        {
            long lngRes = 0;
            string BillNo = "";
            string SQL = @"select distinct a.billno_chr 
                            from t_opr_reciperelation a, 
                                 t_opr_outpatientrecipeinv b                                
                           where a.seqid = b.outpatrecipeid_chr 
                             and a.billno_chr is not null 
                             and b.invoiceno_vchr = ?";

            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = InvoNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dt.Rows.Count == 1)
            {
                BillNo = dt.Rows[0][0].ToString().Trim();
            }

            return BillNo;
        }
        #endregion

        #region (医保)根据处方号获取记帐单号
        /// <summary>
        /// (医保)根据处方号获取记帐单号
        /// </summary>
        /// <param name="Recno"></param>
        /// <param name="Billno"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetybbillno(string Recno, ref string Billno)
        {
            DataTable dt = new DataTable();
            long lngRes = 0;

            string SQL = @"select billno_chr 
                             from t_opr_reciperelation 
                            where outpatrecipeid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = Recno;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count == 1)
                {
                    Billno = dt.Rows[0][0].ToString();
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

        #region (医保)传送门诊收费数据到医保前置机
        /// <summary>
        /// (医保)传送门诊收费数据到医保前置机
        /// </summary>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSendybdata(ArrayList objRecipeArr, string BillNO)
        {
            long lngRes = 0, lngAffects = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string Sql2 = @"delete from t_opr_reciperelation where seqid = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = objRecipeArr[0].ToString();

                lngRes = objHRPSvc.lngExecuteParameterSQL(Sql2, ref lngAffects, ParamArr);

                for (int j = 0; j < objRecipeArr.Count; j++)
                {
                    string Sql3 = @"insert into t_opr_reciperelation(seqid, outpatrecipeid_chr, billno_chr) values(?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = objRecipeArr[0].ToString();
                    ParamArr[1].Value = objRecipeArr[j].ToString();
                    ParamArr[2].Value = BillNO;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(Sql3, ref lngAffects, ParamArr);
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

        #region (医保)生成新的记帐单号
        /// <summary>
        /// (医保)生成新的记帐单号
        /// </summary>
        /// <param name="BillNo"></param>
        [AutoComplete]
        public void m_mthGenBillNo(out string BillNo)
        {
            BillNo = "";

            try
            {
                long l = 0;
                string Sql = "";
                bool b = true;

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                do
                {
                    Sql = @"select seq_billno.nextval from dual";
                    DataTable dt = new DataTable();
                    l = objHRPSvc.lngGetDataTableWithoutParameters(Sql, ref dt);
                    if (l > 0)
                    {
                        BillNo = dt.Rows[0][0].ToString();
                    }

                    Sql = @"select count(billno_chr) from t_opr_reciperelation where billno_chr = ?";

                    dt = new DataTable();

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = BillNo;

                    l = objHRPSvc.lngGetDataTableWithParameters(Sql, ref dt, ParamArr);

                    if (l > 0)
                    {
                        if (int.Parse(dt.Rows[0][0].ToString()) == 0)
                        {
                            b = false;
                        }
                    }
                    else
                    {
                        b = false;
                    }

                } while (b);
            }
            catch (Exception objEx)
            {
                BillNo = "";
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        #endregion

        #region (医保)手工更新记帐单号
        /// <summary>
        /// (医保)手工更新记帐单号
        /// </summary>
        /// <param name="OldBillNo"></param>
        /// <param name="NewBillNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBillNo(string OldBillNo, string NewBillNo)
        {
            long lngRes = 0, lngAffects = 0;

            try
            {
                string Sql = @"update t_opr_reciperelation set billno_chr = ? where billno_chr = ?";

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = NewBillNo;
                ParamArr[1].Value = OldBillNo;

                lngRes = objHRPSvc.lngExecuteParameterSQL(Sql, ref lngAffects, ParamArr);

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

        #region 获取凑整费项目
        /// <summary>
        /// 获取凑整费项目
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRoundingItem(string ItemID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                      a.itemcode_vchr as tempitemcode, a.insuranceid_chr, a.itemopunit_chr,
                                      a.itemprice_mny, a.itemopinvtype_chr, a.itemcatid_chr, a.selfdefine_int, 
                                      a.itemcode_vchr, a.itemopcalctype_chr, a.dosage_dec, a.dosageunit_chr, 
                                      100 as precent_dec, 0 as noqtyflag_int, a.opchargeflg_int, a.itemunit_chr  
                                 from t_bse_chargeitem a 
                                where a.itemid_chr = ? ";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ItemID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 根据时间门诊医生绩效业务信息
        /// <summary>
        /// 根据时间门诊医生绩效业务信息
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="flag">0按发票日期，1按结算日期</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetDrFeeByDate(string beginTime, string endTime, string m_strDoctorID, string m_strStatType, out DataTable dtRes)
        {
            beginTime += " 00:00:00";
            endTime += " 23:59:59";
            dtRes = new DataTable();
            long lngRes = 0;
            string strSQL;
            strSQL = @"SELECT t1.typeid_chr,
             t1.typename_vchr,
             t1.empno_chr, 
             t1.lastname_vchr,
             t2.zfs,
             t3.cfs,
             t1.code_vchr,
             t1.deptname_vchr,
             sum (t1.tolfee_mny) as tolfee_mny,
             sum (t1.jxywl) as jxywl
 FROM (SELECT    g.typeid_chr,g.typename_vchr,a.doctorid_chr, e.empno_chr, e.lastname_vchr,e.code_vchr,e.deptname_vchr,
                           SUM (b.tolfee_mny) tolfee_mny,sum(b.tolfee_mny*f.PERCENTAGE) jxywl
                      FROM t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           t_opr_outpatientrecipe c,
                           t_opr_reciperelation d,
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, T_BSE_DEPTEMP r, T_bse_DeptDesc d
                                 where r.deptid_chr = d.deptid_chr
                                   and e.empid_chr = r.empid_chr
                                   and r.default_dept_int = 1
                                union all
                                select e2.empid_chr,
                                       e2.empno_chr,
                                       e2.lastname_vchr,
                                       '' deptid_chr,
                                       '' code_vchr,
                                       '' deptname_vchr
                                  from t_bse_employee e2
                                 where not exists (select ''
                                          from T_BSE_DEPTEMP r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e,
                            t_opr_drachformula  f,
                            t_bse_chargeitemextype g
                     WHERE a.seqid_chr = b.seqid_chr(+)
                       and b.itemcatid_chr = g.typeid_chr
                       and b.itemcatid_chr = f.typeid_chr(+)
                       AND g.flag_int = 1
                       AND a.balanceflag_int = 1
                       AND a.outpatrecipeid_chr = d.seqid
                       AND d.outpatrecipeid_chr = c.outpatrecipeid_chr
                       AND a.doctorid_chr = e.empid_chr
                       AND a.balance_dat
                              BETWEEN TO_DATE (?,
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  AND TO_DATE (?,
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                  GROUP BY  g.typeid_chr,g.typename_vchr,a.doctorid_chr, e.empno_chr, e.lastname_vchr,e.code_vchr,e.deptname_vchr) t1,
         
     
       (SELECT   a.doctorid_chr,
                 sum (CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS zfs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND a.balanceflag_int = 1
             AND c.recipeflag_int = 1
             AND a.balance_dat BETWEEN TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        GROUP BY a.doctorid_chr) t2,
       (SELECT   a.doctorid_chr,
                 sum (CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS cfs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND a.balanceflag_int = 1
             AND a.balance_dat BETWEEN TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        GROUP BY a.doctorid_chr) t3
 WHERE t1.doctorid_chr = t2.doctorid_chr(+) AND t1.doctorid_chr = t3.doctorid_chr(+)
group by t1.typeid_chr,
             t1.typename_vchr,
             t1.empno_chr, 
             t1.lastname_vchr,
             t2.zfs,
             t3.cfs,
             t1.code_vchr,
             t1.deptname_vchr";
            if (m_strDoctorID != string.Empty)
            {
                strSQL = @"SELECT t1.typeid_chr,
             t1.typename_vchr,
             t1.empno_chr, 
             t1.lastname_vchr,
             t2.zfs,
             t3.cfs,
             t1.code_vchr,
             t1.deptname_vchr,
             sum (t1.tolfee_mny) as tolfee_mny,
             sum (t1.jxywl) as jxywl
 FROM (SELECT    g.typeid_chr,g.typename_vchr,a.doctorid_chr, e.empno_chr, e.lastname_vchr,e.code_vchr,e.deptname_vchr,
                           SUM (b.tolfee_mny) tolfee_mny,sum(b.tolfee_mny*f.PERCENTAGE) jxywl
                      FROM t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           t_opr_outpatientrecipe c,
                           t_opr_reciperelation d,
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, T_BSE_DEPTEMP r, T_bse_DeptDesc d
                                 where r.deptid_chr = d.deptid_chr
                                   and e.empid_chr = r.empid_chr
                                   and r.default_dept_int = 1
                                union all
                                select e2.empid_chr,
                                       e2.empno_chr,
                                       e2.lastname_vchr,
                                       '' deptid_chr,
                                       '' code_vchr,
                                       '' deptname_vchr
                                  from t_bse_employee e2
                                 where not exists (select ''
                                          from T_BSE_DEPTEMP r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e,
                            t_opr_drachformula  f,
                            t_bse_chargeitemextype g
                     WHERE a.seqid_chr = b.seqid_chr(+)
                       and b.itemcatid_chr = g.typeid_chr
                       and b.itemcatid_chr = f.typeid_chr(+)
                       AND g.flag_int = 1
                       AND a.balanceflag_int = 1
                       AND a.outpatrecipeid_chr = d.seqid
                       AND d.outpatrecipeid_chr = c.outpatrecipeid_chr
                       AND a.doctorid_chr = e.empid_chr
                       and a.doctorid_chr in (" + m_strDoctorID + @")
                       AND a.balance_dat
                              BETWEEN TO_DATE (?,
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  AND TO_DATE (?,
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                  GROUP BY  g.typeid_chr,g.typename_vchr,a.doctorid_chr, e.empno_chr, e.lastname_vchr,e.code_vchr,e.deptname_vchr) t1,
         
     
       (SELECT   a.doctorid_chr,
                 sum (CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS zfs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND a.balanceflag_int = 1
             AND c.recipeflag_int = 1
             AND a.balance_dat BETWEEN TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        GROUP BY a.doctorid_chr) t2,
       (SELECT   a.doctorid_chr,
                 sum (CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS cfs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND a.balanceflag_int = 1
             AND a.balance_dat BETWEEN TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        GROUP BY a.doctorid_chr) t3
 WHERE t1.doctorid_chr = t2.doctorid_chr(+) AND t1.doctorid_chr = t3.doctorid_chr(+)
group by t1.typeid_chr,
             t1.typename_vchr,
             t1.empno_chr, 
             t1.lastname_vchr,
             t2.zfs,
             t3.cfs,
             t1.code_vchr,
             t1.deptname_vchr";
            }
            if (m_strStatType == "0")
            {
                strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = beginTime;
                ParamArr[1].Value = endTime;
                ParamArr[2].Value = beginTime;
                ParamArr[3].Value = endTime;
                ParamArr[4].Value = beginTime;
                ParamArr[5].Value = endTime;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRes, ParamArr);
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

        #region 获取凑整费项目
        /// <summary>
        /// 获取凑整费项目
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetDayNo(string InvoNo)
        {
            string DayNo = "";
            try
            {
                string SQL = @"select a.serno_chr 
                                 from t_opr_recipesend a, 
                                      t_opr_recipesendentry b,
                                      t_opr_outpatientrecipeinv c  
                                where a.sid_int = b.sid_int 
                                  and b.outpatrecipeid_chr = c.outpatrecipeid_chr  
                                  and c.invoiceno_vchr = ?";

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = InvoNo;

                DataTable dt = new DataTable();

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    DayNo = dt.Rows[0][0].ToString().Trim();
                }

                objHRPSvc = null;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return DayNo;
        }
        #endregion

        #region 根据收费项目ID查出刻收费项目的收费比例
        /// <summary>
        /// 根据收费项目ID查出刻收费项目的收费比例
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [AutoComplete]
        public decimal m_mthGetDiscountByID(string ID, string PatientTypeID)
        {
            decimal tempDiscount = 100;
            long lngRes = 0;
            DataTable dtbResult = null;
            string strSQL = @"select precent_dec
  from t_aid_inschargeitem
 where itemid_chr = ? and copayid_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = ID;
                param[1].Value = PatientTypeID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, param);

                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    if (dtbResult.Rows[0]["PRECENT_DEC"].ToString().Trim() != "")
                    {
                        tempDiscount = Convert.ToDecimal(dtbResult.Rows[0]["PRECENT_DEC"].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return tempDiscount;
        }
        #endregion

        #region 将对象转换为数字
        /// <summary>
        /// 将对象转换为数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public decimal ConvertObjToDecimal(object obj)
        {
            try
            {
                if (obj != null && obj.ToString() != "")
                {
                    return ConvertObjToDecimal(obj.ToString());

                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 根据发票号产生发收费项目明细
        /// <summary>
        /// 根据发票号产生发收费项目明细,然后填充listView
        /// </summary>
        /// <param name="ID">发票号</param>
        [AutoComplete]
        public long m_lngGetChargeItemByInvoiceID(string ID, string p_status, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            string strSQL = @"select D.NAME,D.DEC,D.COUNT,D.PRICE,d.pdcarea_vchr,d.UINT,C.DOCTORNAME_CHR  From t_opr_outpatientrecipeinv C,
				(select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME,B.ITEMOPUNIT_CHR UINT,
				B.ITEMSPEC_VCHR DEC,A.TOLQTY_DEC COUNT,b.PDCAREA_VCHR ,A.UNITPRICE_MNY PRICE
				from t_opr_outpatientpwmrecipede A,t_bse_chargeitem B
				where A.ITEMID_CHR=B.itemid_chr(+)
				union all
				select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME,B.ITEMOPUNIT_CHR UINT,
				B.ITEMSPEC_VCHR DEC,A.QTY_DEC COUNT,b.PDCAREA_VCHR ,A.UNITPRICE_MNY PRICE
				from t_opr_outpatientcmrecipede A,t_bse_chargeitem B
				where A.ITEMID_CHR=B.itemid_chr(+)
				union all
				select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME,B.itemunit_chr UINT,
				B.ITEMSPEC_VCHR DEC,A.QTY_DEC COUNT,b.PDCAREA_VCHR ,A.PRICE_MNY PRICE
				from t_opr_outpatientchkrecipede A,t_bse_chargeitem B
				where A.ITEMID_CHR=B.itemid_chr(+)
				union all
				select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME,B.itemunit_chr UINT,
				B.ITEMSPEC_VCHR DEC,A.QTY_DEC COUNT,b.PDCAREA_VCHR ,A.PRICE_MNY PRICE
				from t_opr_outpatienttestrecipede A,t_bse_chargeitem B
				where A.ITEMID_CHR=B.itemid_chr(+)
				UNION ALL
				SELECT a.outpatrecipeid_chr ID, b.itemname_vchr NAME, b.itemunit_chr uint,
					b.itemspec_vchr DEC, a.qty_dec COUNT,b.PDCAREA_VCHR, a.price_mny price
				FROM t_opr_outpatientopsrecipede a, t_bse_chargeitem b
				WHERE a.itemid_chr = b.itemid_chr(+)
				union  all
				select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME,B.itemunit_chr UINT,
				B.ITEMSPEC_VCHR DEC,A.QTY_DEC COUNT,b.PDCAREA_VCHR ,A.UNITPRICE_MNY PRICE
				from t_opr_outpatientothrecipede A,t_bse_chargeitem B
				where A.ITEMID_CHR=B.itemid_chr(+)) D
				where C.OUTPATRECIPEID_CHR=D.ID(+)
				AND C.SEQID_CHR= '" + ID.Trim() + "'  and STATUS_INT =" + p_status;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 注射单的页
        /// <summary>
        /// 注射单的页
        /// </summary>
        /// <param name="m_strID"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_mthGetSetting(string m_strID)
        {
            DataTable m_objTable = new DataTable();
            string m_strStatus = "";
            string strSQL = @"select a.setstatus_int from t_sys_setting  a where a.setid_chr=?";
            long lngRes = -1;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, objLisAddItemRefArr);
                if (lngRes > 0 && m_objTable.Rows.Count > 0)
                {
                    m_strStatus = m_objTable.Rows[0]["setstatus_int"].ToString();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return m_strStatus;
        }
        #endregion

        #region 根据内部序列号取得发票信息
        /// <summary>
        /// 根据内部序列号取得发票信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="p_status"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInvoiceInfoByID(string ID, string p_status, out DataTable dtMain, out DataTable dtDet)
        {
            long lngRes = 0;
            string SQL = "";
            dtMain = null;
            dtDet = null;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();

                SQL = @"select a.invoiceno_vchr, a.outpatrecipeid_chr, a.invdate_dat, a.acctsum_mny,
                               a.sbsum_mny, a.opremp_chr, a.recordemp_chr, a.recorddate_dat,
                               a.status_int, a.seqid_chr, a.balanceemp_chr, a.balance_dat,
                               a.balanceflag_int, a.totalsum_mny, a.paytype_int, a.patientid_chr,
                               a.patientname_chr, a.deptid_chr, a.deptname_chr, a.doctorid_chr,
                               a.doctorname_chr, a.confirmemp_chr, a.paytypeid_chr,
                               a.internalflag_int, a.baseseqid_chr, a.groupid_chr,
                               a.confirmdeptid_chr, a.split_int, b.paytypename_vchr, c.empno_chr a,
                               d.empno_chr b, e.patientcardid_chr, f.shortno_chr confdept,
                               g.empno_chr confemp
                          from t_opr_outpatientrecipeinv a,
                               t_bse_patientpaytype b,
                               t_bse_employee c,
                               t_bse_employee d,
                               t_bse_patientcard e,
                               t_bse_deptdesc f,
                               t_bse_employee g
                         where a.paytypeid_chr = b.paytypeid_chr(+)
                           and a.patientid_chr = e.patientid_chr(+)
                           and a.recordemp_chr = c.empid_chr(+)
                           and a.doctorid_chr = d.empid_chr(+)
                           and a.confirmemp_chr = g.empid_chr(+)
                           and a.confirmdeptid_chr = f.deptid_chr(+)
                           and (e.status_int = 1 or e.status_int = 3)
                           and a.seqid_chr = ?";

                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = ID.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, param);


                SQL = @"select itemcatid_chr, tolfee_mny as tolfee_mny
                          from t_opr_outpatientrecipeinvde
                         where seqid_chr = ?";
                if (p_status == "1" || p_status == "2")
                {
                    SQL = @"select itemcatid_chr, -tolfee_mny as tolfee_mny
                              from t_opr_outpatientrecipeinvde
                             where seqid_chr = ?";
                }

                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = ID.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtDet, param);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 当一次挂号开多张处方的时候,获取最大的处方号
        /// <summary>
        /// 当一次挂号开多张处方的时候,获取最大的处方号
        /// </summary>
        /// <param name="m_strRegisterID"></param>
        /// <param name="m_strMaxRecipeID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetMaxRecipeID(string m_strRegisterID, ref string m_strMaxRecipeID)
        {
            string strSQL = @"select max(a.outpatrecipeid_chr) as outpatrecipeid_chr from t_opr_outPatientrecipe a where a.registerid_chr ='" + m_strRegisterID + "'";
            long lngRes = 0;
            DataTable m_objTable = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService m_objService = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            try
            {
                lngRes = m_objService.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                if (m_objTable.Rows.Count > 0 && lngRes > 0)
                {
                    m_strMaxRecipeID = m_objTable.Rows[0]["outpatrecipeid_chr"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取挂号诊金
        /// <summary>
        /// 获取挂号诊金
        /// </summary>
        /// <param name="m_strRegisterID"></param>
        /// <param name="m_strRegisterMoney"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetRegisterMoney(string m_strRegisterID, ref string m_strRegisterMoney)
        {
            string strSQL = @"select a.registerid_chr, a.chargeid_chr, a.payment_mny, a.discount_dec
  from t_opr_patientregdetail a
 where a.registerid_chr = ?";
            long lngRes = 0;
            DataTable m_objTable = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService m_objService = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            try
            {
                // lngRes = m_objService.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);

                System.Data.IDataParameter[] param = null;
                m_objService.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strRegisterID;
                lngRes = m_objService.lngGetDataTableWithParameters(strSQL, ref m_objTable, param);
                if (m_objTable.Rows.Count > 0 && lngRes > 0)
                {
                    decimal m_decRegisterMoney = 0;
                    for (int i = 0; i < m_objTable.Rows.Count; i++)
                    {
                        if (m_objTable.Rows[i]["PAYMENT_MNY"].ToString().Trim() != string.Empty && m_objTable.Rows[i]["DISCOUNT_DEC"].ToString().Trim() != string.Empty)
                        {
                            m_decRegisterMoney += decimal.Parse(m_objTable.Rows[i]["PAYMENT_MNY"].ToString()) * decimal.Parse(m_objTable.Rows[i]["DISCOUNT_DEC"].ToString());
                        }
                    }
                    m_strRegisterMoney = m_decRegisterMoney.ToString();

                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取sid_int
        /// <summary>
        /// 获取sid_int
        /// </summary>
        /// <param name="m_strOutpatientRecipeID"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_mthGetsid_int(string m_strOutpatientRecipeID)
        {
            string strSQL = @"select sid_int from t_opr_recipesendentry a where a.OUTPATRECIPEID_CHR='" + m_strOutpatientRecipeID + "'";
            long lngRes = 0;
            DataTable m_objTable = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService m_objService = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            try
            {
                lngRes = m_objService.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                if (m_objTable.Rows.Count > 0 && lngRes > 0)
                {
                    return m_objTable.Rows[0]["sid_int"].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return string.Empty;
        }
        #endregion

        #region  门诊获取注射单打印数据 1
        /// <summary>
        /// 门诊获取注射单打印数据 1
        /// </summary>
        /// <param name="m_strSid_int"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetPrintData1(string m_strSid_int, out DataTable dtbResult)
        {
            long lngRes = 0;
            string strSQL = @"SELECT   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
                                     b.itemid_chr, b.unitid_chr, b.usageid_chr, b.tolqty_dec,
                                     b.unitprice_mny, b.tolprice_mny,
                                     CASE b.rowno_chr
                                        WHEN '0'
                                           THEN ''
                                        ELSE b.rowno_chr
                                     END AS rowno_chr, b.days_int, b.qty_dec, b.discount_dec,
                                     b.freqid_chr, b.itemname_vchr, b.dosageunit_chr, b.itemspec_vchr,
                                     h.usagename_vchr, k.freqname_chr, b.dosage_dec, c.birth_dat,
                                     a.recorddate_dat, g.lastname_vchr AS doctorname_chr, c.lastname_vchr,
                                     c.sex_chr, j.patientcardid_chr, b.desc_vchr,m1.SERNO_CHR
                                FROM t_opr_recipesend m1,
                                     t_opr_recipesendentry n1,
                                     t_opr_outpatientrecipe a,
                                     t_opr_outpatientpwmrecipede b,
                                     t_bse_chargeitem d,
                                     (SELECT DISTINCT (usageid_chr)
                                                 FROM t_opr_setusage
                                                WHERE orderid_vchr = 1 OR orderid_vchr = 0) f,
                                     t_bse_usagetype h,
                                     t_aid_recipefreq k,
                                     t_bse_patient c,
                                     t_bse_employee g,
                                     t_bse_medicine m,
                                     t_bse_patientcard j
                               WHERE m1.sid_int = n1.sid_int
                                 AND m1.sid_int = ?
                                 AND a.outpatrecipeid_chr = n1.outpatrecipeid_chr
                                 AND a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
                                 AND b.itemid_chr = d.itemid_chr(+)
                                 AND b.freqid_chr = k.freqid_chr
                                 AND b.usageid_chr = f.usageid_chr
                                 AND b.usageid_chr = h.usageid_chr
                                 AND a.patientid_chr = c.patientid_chr
                                 AND a.diagdr_chr = g.empid_chr(+)
                                 AND d.itemsrcid_vchr = m.medicineid_chr
                                 AND a.patientid_chr = j.patientid_chr
                            UNION ALL
                            SELECT   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
                                     b.itemid_chr, b.unitid_chr, b.usageid_chr, 0 AS tolqty_dec,
                                     b.unitprice_mny, b.tolprice_mny,
                                     CASE b.rowno_chr
                                        WHEN '0'
                                           THEN ''
                                        ELSE b.rowno_chr
                                     END AS rowno_chr, 0 AS days_int, b.qty_dec, b.discount_dec,
                                     '' AS freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
                                     h.usagename_vchr, '' AS freqname_chr, d.dosage_dec, c.birth_dat,
                                     a.recorddate_dat, g.lastname_vchr AS doctorname_chr, c.lastname_vchr,
                                     c.sex_chr, j.patientcardid_chr, n.desc_vchr,m1.SERNO_CHR
                                FROM t_opr_recipesend m1,
                                     t_opr_recipesendentry n1,
                                     t_opr_outpatientrecipe a,
                                     t_opr_outpatientcmrecipede b,
                                     t_bse_chargeitem d,
                                     t_opr_outpatientpwmrecipede n,
                                     (SELECT DISTINCT (usageid_chr)
                                                 FROM t_opr_setusage
                                                WHERE orderid_vchr = 1 OR orderid_vchr = 0) f,
                                     t_bse_usagetype h,
                                     t_bse_patient c,
                                     t_bse_employee g,
                                     t_bse_medicine m,
                                     t_bse_patientcard j
                               WHERE m1.sid_int = n1.sid_int
                                 AND m1.sid_int = ?
                                 AND a.outpatrecipeid_chr = n1.outpatrecipeid_chr
                                 AND a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
                                 AND b.itemid_chr = d.itemid_chr(+)
                                 AND b.usageid_chr = f.usageid_chr
                                 AND b.usageid_chr = h.usageid_chr
                                 AND a.patientid_chr = c.patientid_chr
                                 AND a.diagdr_chr = g.empid_chr(+)
                                 AND d.itemsrcid_vchr = m.medicineid_chr
                                 AND a.patientid_chr = j.patientid_chr
                                 AND a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
                            UNION ALL
                            SELECT   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
                                     b.itemid_chr, b.itemunit_vchr AS unitid_chr, '' AS usageid_chr,
                                     0 AS tolqty_dec, 0 AS unitprice_mny, b.tolprice_mny,
                                     CASE b.rowno_chr
                                        WHEN '0'
                                           THEN ''
                                        ELSE b.rowno_chr
                                     END AS rowno_chr, 0 AS days_int, b.qty_dec, b.discount_dec,
                                     '' AS freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
                                     '' AS usagename_vchr, '' AS freqname_chr, d.dosage_dec, c.birth_dat,
                                     a.recorddate_dat, g.lastname_vchr AS doctorname_chr, c.lastname_vchr,
                                     c.sex_chr, j.patientcardid_chr, n.desc_vchr,m1.SERNO_CHR
                                FROM t_opr_recipesend m1,
                                     t_opr_recipesendentry n1,
                                     t_opr_outpatientrecipe a,
                                     t_opr_outpatientchkrecipede b,
                                     t_opr_outpatientpwmrecipede n,
                                     t_bse_chargeitem d,
                                     (SELECT DISTINCT (usageid_chr)
                                                 FROM t_opr_setusage
                                                WHERE orderid_vchr = 1 OR orderid_vchr = 0) f,
                                     t_bse_patient c,
                                     t_bse_employee g,
                                     t_bse_medicine m,
                                     t_bse_patientcard j
                               WHERE m1.sid_int = n1.sid_int
                                 AND m1.sid_int = ?
                                 AND a.outpatrecipeid_chr = n1.outpatrecipeid_chr
                                 AND a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
                                 AND b.itemid_chr = d.itemid_chr(+)
                                 AND d.usageid_chr = f.usageid_chr
                                 AND a.patientid_chr = c.patientid_chr
                                 AND a.diagdr_chr = g.empid_chr(+)
                                 AND d.itemsrcid_vchr = m.medicineid_chr
                                 AND a.patientid_chr = j.patientid_chr
                                 AND a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
                            UNION ALL
                            SELECT   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
                                     b.itemid_chr, b.itemunit_vchr AS unitid_chr, '' AS usageid_chr,
                                     0 AS tolqty_dec, 0 AS unitprice_mny, b.tolprice_mny,
                                     CASE b.rowno_chr
                                        WHEN '0'
                                           THEN ''
                                        ELSE b.rowno_chr
                                     END AS rowno_chr, 0 AS days_int, b.qty_dec, b.discount_dec,
                                     '' AS freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
                                     '' AS usagename_vchr, '' AS freqname_chr, d.dosage_dec, c.birth_dat,
                                     a.recorddate_dat, g.lastname_vchr AS doctorname_chr, c.lastname_vchr,
                                     c.sex_chr, j.patientcardid_chr, n.desc_vchr,m1.SERNO_CHR
                                FROM t_opr_recipesend m1,
                                     t_opr_recipesendentry n1,
                                     t_opr_outpatientrecipe a,
                                     t_opr_outpatienttestrecipede b,
                                     t_opr_outpatientpwmrecipede n,
                                     t_bse_chargeitem d,
                                     (SELECT DISTINCT (usageid_chr)
                                                 FROM t_opr_setusage
                                                WHERE orderid_vchr = 1 OR orderid_vchr = 0) f,
                                     t_bse_patient c,
                                     t_bse_employee g,
                                     t_bse_medicine m,
                                     t_bse_patientcard j
                               WHERE m1.sid_int = n1.sid_int
                                 AND m1.sid_int = ?
                                 AND a.outpatrecipeid_chr = n1.outpatrecipeid_chr
                                 AND a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
                                 AND b.itemid_chr = d.itemid_chr(+)
                                 AND d.usageid_chr = f.usageid_chr
                                 AND a.patientid_chr = c.patientid_chr
                                 AND a.diagdr_chr = g.empid_chr(+)
                                 AND d.itemsrcid_vchr = m.medicineid_chr
                                 AND a.patientid_chr = j.patientid_chr
                                 AND a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
                            UNION ALL
                            SELECT   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
                                     b.itemid_chr, b.itemunit_vchr AS unitid_chr, '' AS usageid_chr,
                                     0 AS tolqty_dec, 0 AS unitprice_mny, b.tolprice_mny,
                                     CASE b.rowno_chr
                                        WHEN '0'
                                           THEN ''
                                        ELSE b.rowno_chr
                                     END AS rowno_chr, 0 AS days_int, b.qty_dec, b.discount_dec,
                                     '' AS freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
                                     '' AS usagename_vchr, '' AS freqname_chr, d.dosage_dec, c.birth_dat,
                                     a.recorddate_dat, g.lastname_vchr AS doctorname_chr, c.lastname_vchr,
                                     c.sex_chr, j.patientcardid_chr, n.desc_vchr,m1.SERNO_CHR
                                FROM t_opr_recipesend m1,
                                     t_opr_recipesendentry n1,
                                     t_opr_outpatientrecipe a,
                                     t_opr_outpatientopsrecipede b,
                                     t_opr_outpatientpwmrecipede n,
                                     t_bse_chargeitem d,
                                     (SELECT DISTINCT (usageid_chr)
                                                 FROM t_opr_setusage
                                                WHERE orderid_vchr = 1 OR orderid_vchr = 0) f,
                                     t_bse_patient c,
                                     t_bse_employee g,
                                     t_bse_medicine m,
                                     t_bse_patientcard j
                               WHERE m1.sid_int = n1.sid_int
                                 AND m1.sid_int = ?
                                 AND a.outpatrecipeid_chr = n1.outpatrecipeid_chr
                                 AND a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
                                 AND b.itemid_chr = d.itemid_chr(+)
                                 AND d.usageid_chr = f.usageid_chr
                                 AND a.patientid_chr = c.patientid_chr
                                 AND a.diagdr_chr = g.empid_chr(+)
                                 AND d.itemsrcid_vchr = m.medicineid_chr
                                 AND a.patientid_chr = j.patientid_chr
                                 AND a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
                            UNION ALL
                            SELECT   c.homephone_vchr, a.pstauts_int, b.outpatrecipedeid_chr,
                                     b.itemid_chr, b.itemunit_vchr AS unitid_chr, '' AS usageid_chr,
                                     0 AS tolqty_dec, 0 AS unitprice_mny, b.tolprice_mny,
                                     CASE b.rowno_chr
                                        WHEN '0'
                                           THEN ''
                                        ELSE b.rowno_chr
                                     END AS rowno_chr, 0 AS days_int, b.qty_dec, b.discount_dec,
                                     '' AS freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
                                     '' AS usagename_vchr, '' AS freqname_chr, d.dosage_dec, c.birth_dat,
                                     a.recorddate_dat, g.lastname_vchr AS doctorname_chr, c.lastname_vchr,
                                     c.sex_chr, j.patientcardid_chr, n.desc_vchr,m1.SERNO_CHR
                                FROM t_opr_recipesend m1,
                                     t_opr_recipesendentry n1,
                                     t_opr_outpatientrecipe a,
                                     t_opr_outpatientothrecipede b,
                                     t_opr_outpatientpwmrecipede n,
                                     t_bse_chargeitem d,
                                     (SELECT DISTINCT (usageid_chr)
                                                 FROM t_opr_setusage
                                                WHERE orderid_vchr = 1 OR orderid_vchr = 0) f,
                                     t_bse_patient c,
                                     t_bse_employee g,
                                     t_bse_medicine m,
                                     t_bse_patientcard j
                               WHERE m1.sid_int = n1.sid_int
                                 AND m1.sid_int = ?
                                 AND a.outpatrecipeid_chr = n1.outpatrecipeid_chr
                                 AND a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
                                 AND b.itemid_chr = d.itemid_chr(+)
                                 AND d.usageid_chr = f.usageid_chr
                                 AND a.patientid_chr = c.patientid_chr
                                 AND a.outpatrecipeid_chr = n.outpatrecipeid_chr(+)
                                 AND a.diagdr_chr = g.empid_chr(+)
                                 AND d.itemsrcid_vchr = m.medicineid_chr
                                 AND a.patientid_chr = j.patientid_chr
                            ORDER BY rowno_chr";

            dtbResult = new DataTable();
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
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region  门诊获取注射单打印数据 2
        /// <summary>
        /// 门诊获取注射单打印数据 2
        /// </summary>
        /// <param name="m_strSid_int"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetPrintData2(string m_strSid_int, out DataTable dtbResult)
        {
            long lngRes = 0;
            string strSQL = @"SELECT   a.itemid_chr, a.operatorid_chr, a.exectime_dat, a.operatortype_int,
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

            dtbResult = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();

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

            return lngRes;
        }
        #endregion

        #region  门诊获取注射单打印数据 3
        /// <summary>
        /// 门诊获取注射单打印数据 3
        /// </summary>
        /// <param name="m_strSid_int"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetPrintData3(string m_strSid_int, out DataTable dtbResult)
        {
            long lngRes = 0;
            string strSQL = @"SELECT a.itemid_chr, d.itemname_vchr, a.rowno_chr, a.operatorid_chr,
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
                            ORDER BY a.seq_int DESC";

            dtbResult = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();

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

            return lngRes;
        }
        #endregion

        #region  门诊获取注射单打印数据 4
        /// <summary>
        /// 门诊获取注射单打印数据 4
        /// </summary>
        /// <param name="m_strSid_int"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetPrintData4(string m_strSid_int, out DataTable dtbResult)
        {
            long lngRes = 0;
            string strSQL = @"select   a.itemid_chr, d.itemname_vchr, a.rowno_chr, a.operatorid_chr,
         a.exectime_dat, a.operatortype_int, b.lastname_vchr, a.remark1_vchr
    from t_opr_recipesend m1,
         t_opr_recipesendentry n1,
         t_opr_nurseexecute a,
         t_bse_employee b,
         t_bse_chargeitem d
   where m1.sid_int = n1.sid_int
     and n1.outpatrecipeid_chr = a.outpatrecipeid_chr
     and m1.sid_int = ?
     and (   a.operatortype_int = 10
          or a.operatortype_int = 3
          or a.operatortype_int = 4
         )
     and a.status_int = 1
     and a.rowno_chr <= 0
     and a.operatorid_chr = b.empid_chr
     and a.itemid_chr = d.itemid_chr(+)
order by a.seq_int desc";

            dtbResult = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();

            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strSid_int;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 门诊获取注射单打印数据 5
        /// <summary>
        ///  门诊获取注射单打印数据 5
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetPrintData5(out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();

            string strSQL = @"select usageid_chr
                              from t_opr_setusage
                             where orderid_vchr='1'";

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 根据医生ID获取其职称
        /// <summary>
        /// 根据医生ID获取其职称
        /// </summary>
        /// <param name="DoctID"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetTechnicalRank(string DoctID)
        {
            string ret = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = DoctID;

                string SQL = @"select technicalrank_chr from t_bse_employee where empid_chr = ?";

                DataTable dt = new DataTable();

                long l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (l > 0 && dt.Rows.Count == 1)
                {
                    ret = dt.Rows[0][0].ToString();
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

        /*********************************************************************/
        /*********************************************************************/
        /*********************************************************************/

        #region 新收费

        #region 结账
        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="OutPatientRecipe_VOArr"></param>
        /// <param name="RecipeDetail_VOArr"></param>
        /// <param name="MedicineSendArr"></param>
        /// <param name="CMFs"></param>
        /// <param name="OPCharge_VO"></param>
        /// <param name="CalcCatArr"></param>
        /// <param name="Invoice_VOArr"></param>
        /// <param name="InvoCatArr"></param>
        /// <param name="PaymentArr"></param>
        /// <param name="ChargeNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReckoning(clsOutPatientRecipe_VO[] OutPatientRecipe_VOArr, clsRecipeDetail_VO[] RecipeDetail_VOArr, ArrayList MedicineSendArr, decimal CMFs,
                                   clsOPCharge_VO OPCharge_VO, ArrayList CalcCatArr, clsInvoice_VO[] Invoice_VOArr, ArrayList[] InvoCatArr, ArrayList PaymentArr, out string ChargeNo)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            //根据时间生成结算号
            ChargeNo = DateTime.Now.ToString("yyyyMMddHHmmssffffff");

            try
            {
                com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc objEmployeeSvc = new com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                #region 处方主表
                string GroupID = "";
                DataTable dt = null;
                DataTable dtTmp = null;

                foreach (clsOutPatientRecipe_VO objRecipe in OutPatientRecipe_VOArr)
                {
                    lngRes = objEmployeeSvc.m_lngGetGroupEmp(objRecipe.m_strDoctorID, out dtTmp);
                    if (lngRes > 0 && dtTmp.Rows.Count > 0)
                    {
                        GroupID = dtTmp.Rows[0]["groupid_chr"].ToString();
                    }

                    this.m_mthDeleteRecipeDetail(objRecipe.m_strOutpatRecipeID.Trim());

                    //处方号关联表                   
                    SQL = @"select seqid, outpatrecipeid_chr from t_opr_reciperelation where seqid = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ((clsOutPatientRecipe_VO)OutPatientRecipe_VOArr[0]).m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                    if (dt.Rows.Count > 0)
                    {
                        SQL = @"update t_opr_reciperelation set mcflag_int = 1, chargeno_chr = ? where seqid = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                        ParamArr[1].Value = ((clsOutPatientRecipe_VO)OutPatientRecipe_VOArr[0]).m_strOutpatRecipeID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                    else
                    {
                        SQL = @"insert into t_opr_reciperelation (seqid, outpatrecipeid_chr, chargeno_chr)                                                              
                                                              values (?, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                        ParamArr[0].Value = ((clsOutPatientRecipe_VO)OutPatientRecipe_VOArr[0]).m_strOutpatRecipeID;
                        ParamArr[1].Value = objRecipe.m_strOutpatRecipeID;
                        ParamArr[2].Value = ChargeNo;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }

                    //处方主表
                    SQL = @"insert into t_opr_outpatientrecipe
                                            (outpatrecipeid_chr, patientid_chr, createdate_dat,
                                             registerid_chr, diagdr_chr, diagdept_chr, recordemp_chr,
                                             recorddate_dat, pstauts_int, paytypeid_chr, recipeflag_int,
                                             groupid_chr, casehisid_chr, type_int, createtype_int, deptmed_int
                                            )
                                     values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
                                             ?, ?, ?, ?,
                                             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?,
                                             ?, ?, ?, ?, ?
                                            )";

                    objHRPSvc.CreateDatabaseParameter(16, out ParamArr);
                    ParamArr[0].Value = objRecipe.m_strOutpatRecipeID;
                    ParamArr[1].Value = objRecipe.m_strPatientID;
                    ParamArr[2].Value = objRecipe.m_strCreateDate;
                    ParamArr[3].Value = objRecipe.m_strRegisterID;
                    ParamArr[4].Value = objRecipe.m_strDoctorID;
                    ParamArr[5].Value = objRecipe.m_strDepID;
                    ParamArr[6].Value = objRecipe.m_strOperatorID;
                    ParamArr[7].Value = DateTime.Now.ToString();
                    ParamArr[8].Value = objRecipe.m_intPStatus;
                    ParamArr[9].Value = objRecipe.m_strPatientType;
                    ParamArr[10].Value = objRecipe.m_intType;
                    ParamArr[11].Value = GroupID;
                    ParamArr[12].Value = objRecipe.m_strCaseHistoryID;
                    ParamArr[13].Value = objRecipe.m_strRecipeType;
                    ParamArr[14].Value = objRecipe.intCreatetype;
                    ParamArr[15].Value = objRecipe.intDeptmed;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //根据处方号更新检验、检查等项目收费标志(已收费)
                    SQL = @"update t_opr_attachrelation set status_int = 1 where sourceitemid_vchr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = objRecipe.m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //更新患者身份证号、医保卡号
                    SQL = @"update t_bse_patient 
								set idcard_chr = ?, 
									insuranceid_vchr = ?  
							where patientid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = objRecipe.strIDcard;
                    ParamArr[1].Value = objRecipe.strInsuranceID;
                    ParamArr[2].Value = objRecipe.m_strPatientID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //处理患者身份对应号表
                    if (objRecipe.m_strPatientType.Trim() != "")
                    {
                        if (objRecipe.strInsuranceID.Trim() == "")
                        {
                            objRecipe.strInsuranceID = " ";
                        }

                        SQL = "delete from t_bse_patientidentityno where patientid_chr = ? and paytypeid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = objRecipe.m_strPatientID;
                        ParamArr[1].Value = objRecipe.m_strPatientType;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                        SQL = @"insert into t_bse_patientidentityno(patientid_chr, paytypeid_chr, idno_vchr) values (?, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                        ParamArr[0].Value = objRecipe.m_strPatientID;
                        ParamArr[1].Value = objRecipe.m_strPatientType;
                        ParamArr[2].Value = objRecipe.strInsuranceID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }

                    #region 保存药品发送表(旧)
                    foreach (clsMedrecipesend_VO Medrecipesend_VO in MedicineSendArr)
                    {
                        Medrecipesend_VO.m_strOUTPATRECIPEID_CHR = objRecipe.m_strOutpatRecipeID;
                        SQL = @"insert into t_opr_medrecipesend
                                                (outpatrecipeid_chr, recipetype_int, medstoreid_chr,
                                                 windowid_chr, pstatus_int, senddate_dat, sendemp_chr
                                                )
                                         values (?, ?, ?,
                                                 ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?
                                                )";

                        objHRPSvc.CreateDatabaseParameter(7, out ParamArr);
                        ParamArr[0].Value = Medrecipesend_VO.m_strOUTPATRECIPEID_CHR;
                        ParamArr[1].Value = Medrecipesend_VO.m_strRECIPETYPE_INT;
                        ParamArr[2].Value = Medrecipesend_VO.m_strMedstroeID_CHR;
                        ParamArr[3].Value = Medrecipesend_VO.m_strWINDOWID_CHR;
                        ParamArr[4].Value = Medrecipesend_VO.m_intPSTATUS_INT;
                        ParamArr[5].Value = Medrecipesend_VO.m_strSENDDATE_DAT;
                        ParamArr[6].Value = Medrecipesend_VO.m_strSENDEMP_CHR;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                    #endregion
                }

                #endregion

                #region 处方明细
                int n = 0;

                if (RecipeDetail_VOArr.Length > 0)
                {
                    ArrayList WmArr = new ArrayList();
                    ArrayList CmArr = new ArrayList();
                    ArrayList LisArr = new ArrayList();
                    ArrayList ChkArr = new ArrayList();
                    ArrayList OpsArr = new ArrayList();
                    ArrayList OthArr = new ArrayList();

                    #region 0. 费用明细
                    //0. 费用明细
                    SQL = @"insert into t_opr_oprecipeitemde
                                            (outpatrecipeid_chr, itemid_chr, qty_dec, unitid_chr, price_mny,
                                             tolprice_mny, discount_dec, recipetype_int
                                            )
                                     values (?, ?, ?, ?, ?,
                                             ?, ?, ?
                                            )";

                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.Decimal, DbType.String, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.String };

                    object[][] objValues = new object[8][];

                    for (int i = 0; i < objValues.Length; i++)
                    {
                        objValues[i] = new object[RecipeDetail_VOArr.Length];
                    }

                    for (int i = 0; i < RecipeDetail_VOArr.Length; i++)
                    {
                        switch (RecipeDetail_VOArr[i].strType)
                        {
                            case "0001":
                                WmArr.Add(RecipeDetail_VOArr[i]);
                                break;
                            case "0002":
                                CmArr.Add(RecipeDetail_VOArr[i]);
                                break;
                            case "0003":
                                LisArr.Add(RecipeDetail_VOArr[i]);
                                break;
                            case "0004":
                                ChkArr.Add(RecipeDetail_VOArr[i]);
                                break;
                            case "0005":
                                OpsArr.Add(RecipeDetail_VOArr[i]);
                                break;
                            case "0006":
                                OthArr.Add(RecipeDetail_VOArr[i]);
                                break;
                        }

                        n = -1;

                        objValues[++n][i] = RecipeDetail_VOArr[i].m_strOutpatRecipeID;
                        objValues[++n][i] = RecipeDetail_VOArr[i].strCharegeItemID;
                        objValues[++n][i] = RecipeDetail_VOArr[i].decQuantity;
                        objValues[++n][i] = RecipeDetail_VOArr[i].strUint;
                        objValues[++n][i] = RecipeDetail_VOArr[i].decPrice;
                        objValues[++n][i] = RecipeDetail_VOArr[i].decSumMoney;
                        objValues[++n][i] = RecipeDetail_VOArr[i].decDiscount / 100;
                        objValues[++n][i] = RecipeDetail_VOArr[i].strType;
                    }

                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbTypes);

                    #endregion

                    clsRecipeDetail_VO objRecipeDetail_VO = null;

                    #region 1. 西药
                    //1. 西药
                    if (WmArr.Count > 0)
                    {
                        SQL = @"insert into t_opr_outpatientpwmrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr,
                                                     tolqty_dec, unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
                                                     discount_dec, medstoreid_chr, windowid_chr, usageid_chr,
                                                     freqid_chr, qty_dec, days_int, hypetest_int, desc_vchr,
                                                     itemspec_vchr, dosage_dec, dosageunit_chr, attachparentid_vchr,
                                                     attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
                                                     itemname_vchr, deptmed_int
                                                    )
                                             values (?, ?, ?, ?,
                                                     ?, ?, ?, seq_recipeid.nextval,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?, ?, ?,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?
                                                    )";

                        dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String,
                                                  DbType.Decimal, DbType.Decimal, DbType.Decimal, 
                                                  DbType.Decimal, DbType.String, DbType.String, DbType.String, 
                                                  DbType.String, DbType.String, DbType.String, DbType.String, DbType.String,
                                                  DbType.String, DbType.Decimal, DbType.String, DbType.String, 
                                                  DbType.Decimal, DbType.String, DbType.Decimal, DbType.String, DbType.Int32};

                        objValues = new object[25][];

                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[WmArr.Count];
                        }

                        for (int j = 0; j < WmArr.Count; j++)
                        {
                            objRecipeDetail_VO = WmArr[j] as clsRecipeDetail_VO;

                            n = -1;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOutpatRecipeID;
                            objValues[++n][j] = objRecipeDetail_VO.strRowNO;
                            objValues[++n][j] = objRecipeDetail_VO.strCharegeItemID;
                            objValues[++n][j] = objRecipeDetail_VO.strUint;
                            objValues[++n][j] = objRecipeDetail_VO.decQuantity;
                            objValues[++n][j] = objRecipeDetail_VO.decPrice;
                            objValues[++n][j] = objRecipeDetail_VO.decSumMoney;
                            objValues[++n][j] = objRecipeDetail_VO.decDiscount;
                            objValues[++n][j] = objRecipeDetail_VO.strMedstroeID;
                            objValues[++n][j] = objRecipeDetail_VO.strWindowsID;
                            objValues[++n][j] = objRecipeDetail_VO.strUsageID;
                            objValues[++n][j] = objRecipeDetail_VO.strFrequencyID;
                            objValues[++n][j] = objRecipeDetail_VO.strDosage;
                            objValues[++n][j] = objRecipeDetail_VO.strDays;
                            objValues[++n][j] = objRecipeDetail_VO.strHYPETEST_INT;
                            objValues[++n][j] = objRecipeDetail_VO.strDESC_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemspec;
                            objValues[++n][j] = objRecipeDetail_VO.m_decDosage;
                            objValues[++n][j] = objRecipeDetail_VO.m_strDosageunit;
                            objValues[++n][j] = objRecipeDetail_VO.m_strATTACHPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decAttachitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strUSAGEPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decUsageitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemname;
                            objValues[++n][j] = objRecipeDetail_VO.m_intDeptmed;
                        }

                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbTypes);
                    }
                    #endregion

                    #region 2. 中药
                    //2. 中药
                    if (CmArr.Count > 0)
                    {
                        SQL = @"insert into t_opr_outpatientcmrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr,
                                                     min_qty_dec, unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
                                                     discount_dec, times_int, medstoreid_chr, windowid_chr,
                                                     usageid_chr, qty_dec, sumusage_vchr, itemname_vchr,
                                                     itemspec_vchr, deptmed_int, usagedetail_vchr
                                                    )
                                             values (?, ?, ?, ?,
                                                     ?, ?, ?, seq_recipeid.nextval,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?
                                                    )";

                        dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String,
                                                  DbType.Decimal, DbType.Decimal, DbType.Decimal, 
                                                  DbType.Decimal, DbType.Int32, DbType.String, DbType.String, 
                                                  DbType.String, DbType.Decimal, DbType.String, DbType.String,
                                                  DbType.String, DbType.Int32, DbType.String};

                        objValues = new object[18][];

                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[CmArr.Count];
                        }

                        for (int j = 0; j < CmArr.Count; j++)
                        {
                            objRecipeDetail_VO = CmArr[j] as clsRecipeDetail_VO;

                            n = -1;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOutpatRecipeID;
                            objValues[++n][j] = objRecipeDetail_VO.strRowNO;
                            objValues[++n][j] = objRecipeDetail_VO.strCharegeItemID;
                            objValues[++n][j] = objRecipeDetail_VO.strUint;
                            objValues[++n][j] = objRecipeDetail_VO.decQuantity;
                            objValues[++n][j] = objRecipeDetail_VO.decPrice;
                            objValues[++n][j] = objRecipeDetail_VO.decSumMoney;
                            objValues[++n][j] = objRecipeDetail_VO.decDiscount;
                            objValues[++n][j] = CMFs;
                            objValues[++n][j] = objRecipeDetail_VO.strMedstroeID;
                            objValues[++n][j] = objRecipeDetail_VO.strWindowsID;
                            objValues[++n][j] = objRecipeDetail_VO.strUsageID;
                            objValues[++n][j] = objRecipeDetail_VO.decQuantity;
                            objValues[++n][j] = objRecipeDetail_VO.strCMedicineUsage;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemname;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemspec;
                            objValues[++n][j] = objRecipeDetail_VO.m_intDeptmed;
                            objValues[++n][j] = objRecipeDetail_VO.strDESC_VCHR;
                        }

                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbTypes);
                    }
                    #endregion

                    #region 3. 检验
                    if (LisArr.Count > 0)
                    {
                        SQL = @"insert into t_opr_outpatientchkrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
                                                     tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
                                                     medstoreid_chr, windowid_chr, attachparentid_vchr,
                                                     attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
                                                     itemname_vchr, itemspec_vchr, itemunit_vchr,
                                                     itemusagedetail_vchr, orderid_vchr, orderbasenum_dec
                                                    )
                                             values (?, ?, ?, ?, ?,
                                                     ?, seq_recipeid.nextval, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?
                                                    )";

                        dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.Decimal, DbType.Decimal,
                                                  DbType.Decimal, DbType.String, DbType.Decimal,
                                                  DbType.String, DbType.String, DbType.String, 
                                                  DbType.Decimal, DbType.String, DbType.Decimal, 
                                                  DbType.String, DbType.String, DbType.String, 
                                                  DbType.String, DbType.String, DbType.Decimal};

                        objValues = new object[20][];

                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[LisArr.Count];
                        }

                        for (int j = 0; j < LisArr.Count; j++)
                        {
                            objRecipeDetail_VO = LisArr[j] as clsRecipeDetail_VO;

                            n = -1;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOutpatRecipeID;
                            objValues[++n][j] = objRecipeDetail_VO.strRowNO;
                            objValues[++n][j] = objRecipeDetail_VO.strCharegeItemID;
                            objValues[++n][j] = objRecipeDetail_VO.decQuantity;
                            objValues[++n][j] = objRecipeDetail_VO.decPrice;
                            objValues[++n][j] = objRecipeDetail_VO.decSumMoney;
                            objValues[++n][j] = objRecipeDetail_VO.strApplyID;
                            objValues[++n][j] = objRecipeDetail_VO.decDiscount;
                            objValues[++n][j] = objRecipeDetail_VO.strMedstroeID;
                            objValues[++n][j] = objRecipeDetail_VO.strWindowsID;
                            objValues[++n][j] = objRecipeDetail_VO.m_strATTACHPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decAttachitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strUSAGEPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decUsageitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemname;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemspec;
                            objValues[++n][j] = objRecipeDetail_VO.strUint;
                            objValues[++n][j] = objRecipeDetail_VO.strDESC_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOrderID;
                            objValues[++n][j] = objRecipeDetail_VO.m_decOrderBaseNum;
                        }

                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbTypes);
                    }
                    #endregion

                    #region 4. 检查
                    if (ChkArr.Count > 0)
                    {
                        SQL = @"insert into t_opr_outpatienttestrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
                                                     tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
                                                     medstoreid_chr, windowid_chr, attachparentid_vchr,
                                                     attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
                                                     itemname_vchr, itemspec_vchr, itemunit_vchr,
                                                     itemusagedetail_vchr, orderid_vchr, orderbasenum_dec
                                                    )
                                             values (?, ?, ?, ?, ?,
                                                     ?, seq_recipeid.nextval, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?
                                                    )";

                        dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.Decimal, DbType.Decimal,
                                                  DbType.Decimal, DbType.String, DbType.Decimal,
                                                  DbType.String, DbType.String, DbType.String, 
                                                  DbType.Decimal, DbType.String, DbType.Decimal, 
                                                  DbType.String, DbType.String, DbType.String, 
                                                  DbType.String, DbType.String, DbType.Decimal};

                        objValues = new object[20][];

                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[ChkArr.Count];
                        }

                        for (int j = 0; j < ChkArr.Count; j++)
                        {
                            objRecipeDetail_VO = ChkArr[j] as clsRecipeDetail_VO;

                            n = -1;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOutpatRecipeID;
                            objValues[++n][j] = objRecipeDetail_VO.strRowNO;
                            objValues[++n][j] = objRecipeDetail_VO.strCharegeItemID;
                            objValues[++n][j] = objRecipeDetail_VO.decQuantity;
                            objValues[++n][j] = objRecipeDetail_VO.decPrice;
                            objValues[++n][j] = objRecipeDetail_VO.decSumMoney;
                            objValues[++n][j] = objRecipeDetail_VO.strApplyID;
                            objValues[++n][j] = objRecipeDetail_VO.decDiscount;
                            objValues[++n][j] = objRecipeDetail_VO.strMedstroeID;
                            objValues[++n][j] = objRecipeDetail_VO.strWindowsID;
                            objValues[++n][j] = objRecipeDetail_VO.m_strATTACHPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decAttachitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strUSAGEPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decUsageitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemname;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemspec;
                            objValues[++n][j] = objRecipeDetail_VO.strUint;
                            objValues[++n][j] = objRecipeDetail_VO.strDESC_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOrderID;
                            objValues[++n][j] = objRecipeDetail_VO.m_decOrderBaseNum;
                        }

                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbTypes);
                    }
                    #endregion

                    #region 5. 治疗
                    //5. 治疗
                    if (OpsArr.Count > 0)
                    {
                        SQL = @"insert into t_opr_outpatientothrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, unitid_chr, qty_dec,
                                                     unitprice_mny, tolprice_mny, outpatrecipedeid_chr,
                                                     attachid_vchr, discount_dec, medstoreid_chr, windowid_chr,
                                                     attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr,
                                                     usageitembasenum_dec, itemname_vchr, itemspec_vchr,
                                                     itemunit_vchr, itemusagedetail_vchr, deptmed_int
                                                    )
                                             values (?, ?, ?, ?, ?,
                                                     ?, ?, seq_recipeid.nextval,
                                                     ?, ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?
                                                    )";

                        dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.Decimal,
                                                  DbType.Decimal, DbType.Decimal, 
                                                  DbType.String, DbType.Decimal, DbType.String, DbType.String,
                                                  DbType.String, DbType.Decimal, DbType.String, 
                                                  DbType.Decimal, DbType.String, DbType.String, 
                                                  DbType.String, DbType.String, DbType.Int32};

                        objValues = new object[20][];

                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[OpsArr.Count];
                        }

                        for (int j = 0; j < OpsArr.Count; j++)
                        {
                            objRecipeDetail_VO = OpsArr[j] as clsRecipeDetail_VO;

                            n = -1;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOutpatRecipeID;
                            objValues[++n][j] = objRecipeDetail_VO.strRowNO;
                            objValues[++n][j] = objRecipeDetail_VO.strCharegeItemID;
                            objValues[++n][j] = objRecipeDetail_VO.strUint;
                            objValues[++n][j] = objRecipeDetail_VO.decQuantity;
                            objValues[++n][j] = objRecipeDetail_VO.decPrice;
                            objValues[++n][j] = objRecipeDetail_VO.decSumMoney;
                            objValues[++n][j] = objRecipeDetail_VO.strApplyID;
                            objValues[++n][j] = objRecipeDetail_VO.decDiscount;
                            objValues[++n][j] = objRecipeDetail_VO.strMedstroeID;
                            objValues[++n][j] = objRecipeDetail_VO.strWindowsID;
                            objValues[++n][j] = objRecipeDetail_VO.m_strATTACHPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decAttachitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strUSAGEPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decUsageitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemname;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemspec;
                            objValues[++n][j] = objRecipeDetail_VO.strUint;
                            objValues[++n][j] = objRecipeDetail_VO.strDESC_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_intDeptmed;
                        }

                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbTypes);
                    }
                    #endregion

                    #region 6. 其他
                    if (OthArr.Count > 0)
                    {
                        SQL = @"insert into t_opr_outpatientopsrecipede
                                                    (outpatrecipeid_chr, rowno_chr, itemid_chr, qty_dec, price_mny,
                                                     tolprice_mny, outpatrecipedeid_chr, attachid_vchr, discount_dec,
                                                     medstoreid_chr, windowid_chr, attachparentid_vchr,
                                                     attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec,
                                                     itemname_vchr, itemspec_vchr, itemunit_vchr,
                                                     itemusagedetail_vchr, deptmed_int, orderid_vchr, orderbasenum_dec
                                                    )
                                             values (?, ?, ?, ?, ?,
                                                     ?, seq_recipeid.nextval, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?,
                                                     ?, ?, ?, ?
                                                    )";

                        dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.Decimal, DbType.Decimal,
                                                  DbType.Decimal, DbType.String, DbType.Decimal, 
                                                  DbType.String, DbType.String, DbType.String,
                                                  DbType.Decimal, DbType.String, DbType.Decimal, 
                                                  DbType.String, DbType.String, DbType.String, 
                                                  DbType.String, DbType.Int32, DbType.String, DbType.Decimal};

                        objValues = new object[21][];

                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[OthArr.Count];
                        }

                        for (int j = 0; j < OthArr.Count; j++)
                        {
                            objRecipeDetail_VO = OthArr[j] as clsRecipeDetail_VO;

                            n = -1;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOutpatRecipeID;
                            objValues[++n][j] = objRecipeDetail_VO.strRowNO;
                            objValues[++n][j] = objRecipeDetail_VO.strCharegeItemID;
                            objValues[++n][j] = objRecipeDetail_VO.decQuantity;
                            objValues[++n][j] = objRecipeDetail_VO.decPrice;
                            objValues[++n][j] = objRecipeDetail_VO.decSumMoney;
                            objValues[++n][j] = objRecipeDetail_VO.strApplyID;
                            objValues[++n][j] = objRecipeDetail_VO.decDiscount;
                            objValues[++n][j] = objRecipeDetail_VO.strMedstroeID;
                            objValues[++n][j] = objRecipeDetail_VO.strWindowsID;
                            objValues[++n][j] = objRecipeDetail_VO.m_strATTACHPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decAttachitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strUSAGEPARENTID_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_decUsageitembasenum;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemname;
                            objValues[++n][j] = objRecipeDetail_VO.m_strItemspec;
                            objValues[++n][j] = objRecipeDetail_VO.strUint;
                            objValues[++n][j] = objRecipeDetail_VO.strDESC_VCHR;
                            objValues[++n][j] = objRecipeDetail_VO.m_intDeptmed;
                            objValues[++n][j] = objRecipeDetail_VO.m_strOrderID;
                            objValues[++n][j] = objRecipeDetail_VO.m_decOrderBaseNum;
                        }

                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbTypes);
                    }
                    #endregion
                }
                #endregion

                #region 结算主表
                SQL = @"insert into t_opr_charge(chargeno_chr, patientid_chr, paytypeid_chr, totalsum_mny, sbsum_mny, acctsum_mny, operemp_chr, operdate_dat,  
                                                 recflag_int, recemp_chr, recdate_dat, type_int, status_int, doctorid_chr, deptid_chr, groupid_chr) 
                                         values (?, ?, ?, ?, ?, ?, ?, sysdate, 0, null, null, 1, 1, ?, ?, ?)";

                objHRPSvc.CreateDatabaseParameter(10, out ParamArr);
                ParamArr[0].Value = ChargeNo;
                ParamArr[1].Value = OPCharge_VO.PatientID;
                ParamArr[2].Value = OPCharge_VO.PayTypeID;
                ParamArr[3].Value = OPCharge_VO.TotalSum;
                ParamArr[4].Value = OPCharge_VO.SbSum;
                ParamArr[5].Value = OPCharge_VO.AcctSum;
                ParamArr[6].Value = OPCharge_VO.OperEmp;
                ParamArr[7].Value = OPCharge_VO.DoctID;
                ParamArr[8].Value = OPCharge_VO.DeptID;
                ParamArr[9].Value = GroupID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                #endregion

                #region 核算分类表
                for (int i = 0; i < CalcCatArr.Count; i++)
                {
                    clsBihChargeCat_VO ChargeCat_VO = CalcCatArr[i] as clsBihChargeCat_VO;

                    if (ChargeCat_VO.TotalSum == 0)
                    {
                        continue;
                    }

                    SQL = @"insert into t_opr_outpatientrecipesumde(itemcatid_chr, tolfee_mny, invoiceno_vchr, seqid_chr, sbsum_mny, chargeno_chr, deptid_chr) 
                                                             values(?, ?, null, null, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                    ParamArr[0].Value = ChargeCat_VO.ItemCatID;
                    ParamArr[1].Value = ChargeCat_VO.TotalSum;
                    ParamArr[2].Value = ChargeCat_VO.TotalSum - ChargeCat_VO.AcctSum;
                    ParamArr[3].Value = ChargeNo;
                    ParamArr[4].Value = ChargeCat_VO.DeptID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                #endregion

                #region 发票主表
                //分票标识 0 正常 1 分票
                string split = "0";
                //分票组号
                string splitgroupid = "";
                if (Invoice_VOArr.Length > 1)
                {
                    split = "1";
                    splitgroupid = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                }

                for (int i = 0; i < Invoice_VOArr.Length; i++)
                {
                    #region 结算发票对应表
                    SQL = "insert into t_opr_chargedefinv(chargeno_chr, invoiceno_vchr) values(?, ?)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = Invoice_VOArr[i].m_strINVOICENO_VCHR;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    #endregion

                    if (split == "1")
                    {
                        Invoice_VOArr[i].m_strBASESEQID_CHR = splitgroupid;
                    }

                    Invoice_VOArr[i].m_strOUTPATRECIPEID_CHR = ((clsOutPatientRecipe_VO)OutPatientRecipe_VOArr[0]).m_strOutpatRecipeID;
                    SQL = @"insert into t_opr_outpatientrecipeinv
                                            (invoiceno_vchr, outpatrecipeid_chr, invdate_dat, acctsum_mny,
                                             sbsum_mny, opremp_chr, recordemp_chr, recorddate_dat,
                                             status_int, seqid_chr, totalsum_mny, paytype_int, patientid_chr,
                                             patientname_chr, deptid_chr, deptname_chr, doctorid_chr,
                                             doctorname_chr, confirmemp_chr, paytypeid_chr, internalflag_int,
                                             baseseqid_chr, groupid_chr, confirmdeptid_chr, split_int
                                            )
                                     values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?,
                                             ?, ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
                                             ?, ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?
                                            )";

                    objHRPSvc.CreateDatabaseParameter(25, out ParamArr);
                    ParamArr[0].Value = Invoice_VOArr[i].m_strINVOICENO_VCHR;
                    ParamArr[1].Value = Invoice_VOArr[i].m_strOUTPATRECIPEID_CHR;
                    ParamArr[2].Value = Invoice_VOArr[i].m_strINVDATE_DAT;
                    ParamArr[3].Value = Invoice_VOArr[i].m_decACCTSUM_MNY;
                    ParamArr[4].Value = Invoice_VOArr[i].m_decSBSUM_MNY;
                    ParamArr[5].Value = Invoice_VOArr[i].m_strOPREMP_CHR;
                    ParamArr[6].Value = Invoice_VOArr[i].m_strRECORDEMP_CHR;
                    ParamArr[7].Value = Invoice_VOArr[i].m_strRECORDDATE_DAT;
                    ParamArr[8].Value = Invoice_VOArr[i].m_intSTATUS_INT;
                    ParamArr[9].Value = Invoice_VOArr[i].m_strSEQID_CHR;
                    ParamArr[10].Value = Invoice_VOArr[i].m_decTOTALSUM_MNY;
                    ParamArr[11].Value = Invoice_VOArr[i].m_intPAYTYPE_INT;
                    ParamArr[12].Value = Invoice_VOArr[i].m_strPATIENTID_CHR;
                    ParamArr[13].Value = Invoice_VOArr[i].m_strPATIENTNAME_CHR;
                    ParamArr[14].Value = Invoice_VOArr[i].m_strDEPTID_CHR;
                    ParamArr[15].Value = Invoice_VOArr[i].m_strDEPTNAME_CHR.Trim();
                    ParamArr[16].Value = Invoice_VOArr[i].m_strDOCTORID_CHR;
                    ParamArr[17].Value = Invoice_VOArr[i].m_strDOCTORNAME_CHR.Trim();
                    ParamArr[18].Value = Invoice_VOArr[i].m_strCONFIRMEMP_CHR;
                    ParamArr[19].Value = Invoice_VOArr[i].m_strPAYTYPEID_CHR;
                    ParamArr[20].Value = Invoice_VOArr[i].m_strHospitalID_CHR;
                    ParamArr[21].Value = Invoice_VOArr[i].m_strBASESEQID_CHR;
                    ParamArr[22].Value = GroupID;
                    ParamArr[23].Value = Invoice_VOArr[i].m_strCONFIRMDEPT_CHR;
                    ParamArr[24].Value = split;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    #region 发票分类表
                    for (int i1 = 0; i1 < InvoCatArr.Length; i1++)
                    {
                        for (int i2 = 0; i2 < InvoCatArr[i1].Count; i2++)
                        {
                            clsBihInvoiceCat_VO InvoiceCat_VO = InvoCatArr[i1][i2] as clsBihInvoiceCat_VO;

                            if (InvoiceCat_VO.TotalSum == 0)
                            {
                                continue;
                            }

                            SQL = "insert into t_opr_outpatientrecipeinvde(itemcatid_chr, tolfee_mny, invoiceno_vchr, seqid_chr, sbsum_mny) values(?, ?, ?, ?, ?)";

                            objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                            ParamArr[0].Value = InvoiceCat_VO.ItemCatID;
                            ParamArr[1].Value = InvoiceCat_VO.TotalSum;
                            ParamArr[2].Value = Invoice_VOArr[i].m_strINVOICENO_VCHR;
                            ParamArr[3].Value = Invoice_VOArr[i].m_strSEQID_CHR;
                            ParamArr[4].Value = InvoiceCat_VO.TotalSum - InvoiceCat_VO.AcctSum;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                        }
                    }

                    #endregion
                }

                #endregion

                #region 支付表
                for (int i = 0; i < PaymentArr.Count; i++)
                {
                    clsBihPayment_VO Payment_VO = PaymentArr[i] as clsBihPayment_VO;

                    SQL = @"insert into t_opr_payment(chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr, paysum_mny, refusum_mny) 
                                               values(?, ?, ?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = Payment_VO.PayType;
                    ParamArr[2].Value = Payment_VO.PayCardType;
                    ParamArr[3].Value = Payment_VO.PayCardNo;
                    ParamArr[4].Value = Payment_VO.PaySum;
                    ParamArr[5].Value = Payment_VO.RefuSum;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                #endregion
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }

            return lngRes;

        }
        #endregion

        #endregion

        #region 通过日期查询欠费病人
        /// <summary>
        /// 通过日期查询欠费病人
        /// </summary>
        /// <param name="objPrincipal"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryArrearsPatientByDate(System.Security.Principal.IPrincipal objPrincipal, string p_strStartDate, string p_strEndDate, out DataTable p_dtResult, bool p_blnALL)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();

            clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            lngRes = clsSec.m_lngCheckCallPrivilege(objPrincipal, "com.digitalwave.iCare.middletier.HIS.Reports.clsOPChargeSvc", "m_lngQueryArrearsPatientByDate");
            if (lngRes < 0)
                return lngRes;
            clsHRPTableService objSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                string strSQL = string.Empty;
                if (p_blnALL)
                {
                    strSQL = @"select a.patientname_chr,a.invoiceno_vchr,
                                   d.patientcardid_chr,
                                   b.sex_chr,
                                   a.outpatrecipeid_chr,
                                   b.idcard_chr,
                                   a.deptname_chr,
                                   b.homephone_vchr,
                                   a.totalsum_mny
                              from t_opr_outpatientrecipeinv a,
                                   t_bse_patient b,
                                   t_bse_patientcard d
                             where a.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                               and a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = d.patientid_chr
                               and a.isvouchers_int = 2
                               and not exists
                               (select t.invoiceno_vchr
                                  from t_opr_outpatientrecipeinv t
                                 where t.isvouchers_int = 2
                                   and t.status_int = 2
                                   and a.invoiceno_vchr = t.invoiceno_vchr)";
                    objSvc = new clsHRPTableService();
                    objSvc.CreateDatabaseParameter(2, out objParamArr);
                    objParamArr[0].Value = p_strStartDate;
                    objParamArr[1].Value = p_strEndDate;
                    lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objParamArr);
                }
                else
                {
                    strSQL = @"select m.outpatrecipeid_chr id, m.tolprice_mny --药品类
                  from (select a.tolprice_mny,
                               a.outpatrecipeid_chr,
                               'WM' medtype
                          from t_tmp_outpatientpwmrecipede a,
                               t_opr_outpatientrecipeinv   b
                         where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                           and b.recorddate_dat between
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss')
                               and b.recorddate_dat between  ? and  ?
                               and b.isvouchers_int = 2
                        union all
                        select a.tolprice_mny,
                               a.outpatrecipeid_chr,
                               'CM' medtype
                          from t_tmp_outpatientcmrecipede a,
                               t_opr_outpatientrecipeinv  b
                         where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                           and b.recorddate_dat between
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss')
                               and b.recorddate_dat between  ? and  ?
                               and b.isvouchers_int = 2
                        union all
                        select a.tolprice_mny,
                               a.outpatrecipeid_chr,
                               'QTH' medtype
                          from t_tmp_outpatientothrecipede a,
                               t_opr_outpatientrecipeinv   b
                         where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                           and b.recorddate_dat between
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss')
                           and b.recorddate_dat between  ? and  ?
                           and b.isvouchers_int = 2) m,
                       (select a.outpatrecipeid_chr,
                               c.medicnetype_int,
                               decode(c.medicnetype_int,
                                      1,
                                      'WM',
                                      2,
                                      'CM',
                                      3,
                                      'QTH',
                                      4,
                                      '') as medtype,
                               decode(b.pstatus_int, 3, 1, 0) as issendmed
                          from t_opr_recipesendentry a,
                               t_opr_recipesend      b,
                               t_bse_medstore        c
                         where a.sid_int = b.sid_int
                           and b.medstoreid_chr = c.medstoreid_chr
                           and not exists (select t.outpatrecipeid_chr
                                  from t_opr_returnmed t
                                 where t.outpatrecipeid_chr = a.outpatrecipeid_chr)) n
                 where m.outpatrecipeid_chr = n.outpatrecipeid_chr
                   and m.medtype = n.medtype
                   and n.issendmed = 1
                union all
                select c.id, c.price totalsum_mny --检验、检查、手术、材料
                  from (select trim(a.orderid_int) outpatrecipedeid_chr,
                               a.outpatrecipeid_chr ID,
                               a.qty_dec * a.pricemny_dec price
                          from t_opr_outpatient_orderdic a,
                          t_opr_outpatientrecipeinv      b
                         where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                          and b.recorddate_dat between
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss')
                          and b.recorddate_dat between  ? and  ?
                          and b.isvouchers_int = 2
                        union all
                        select a.outpatrecipedeid_chr,
                               a.outpatrecipeid_chr   id,
                               a.unitprice_mny        price
                          from t_tmp_outpatientothrecipede a,
                               t_opr_outpatientrecipeinv   b
                         where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                           and (a.usageparentid_vchr like '[PK]%' or
                               a.usageparentid_vchr is null)
                                and b.recorddate_dat between
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?,
                                       'yyyy-mm-dd hh24:mi:ss')
                               and b.recorddate_dat between  ? and  ?
                               and b.isvouchers_int = 2) c,
                       (select *
                          from t_opr_itemconfirm t
                         where t.status_int = 1) d
                 where c.id = d.outpatrecipeid_chr
                   and c.outpatrecipedeid_chr = d.outpatrecipedeid_chr(+)";
                    objSvc = new clsHRPTableService();
                    objSvc.CreateDatabaseParameter(20, out objParamArr);
                    objParamArr[0].Value = p_strStartDate;
                    objParamArr[1].Value = p_strEndDate;
                    objParamArr[2].Value = Convert.ToDateTime(p_strStartDate);
                    objParamArr[3].Value = Convert.ToDateTime(p_strEndDate);
                    objParamArr[4].Value = p_strStartDate;
                    objParamArr[5].Value = p_strEndDate;
                    objParamArr[6].Value = Convert.ToDateTime(p_strStartDate);
                    objParamArr[7].Value = Convert.ToDateTime(p_strEndDate);
                    objParamArr[8].Value = p_strStartDate;
                    objParamArr[9].Value = p_strEndDate;
                    objParamArr[10].Value = Convert.ToDateTime(p_strStartDate);
                    objParamArr[11].Value = Convert.ToDateTime(p_strEndDate);
                    objParamArr[12].Value = p_strStartDate;
                    objParamArr[13].Value = p_strEndDate;
                    objParamArr[14].Value = Convert.ToDateTime(p_strStartDate);
                    objParamArr[15].Value = Convert.ToDateTime(p_strEndDate);
                    objParamArr[16].Value = p_strStartDate;
                    objParamArr[17].Value = p_strEndDate;
                    objParamArr[18].Value = Convert.ToDateTime(p_strStartDate);
                    objParamArr[19].Value = Convert.ToDateTime(p_strEndDate);
                    DataTable dtTemp = new DataTable();
                    lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, objParamArr);
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    if (lngRes > 0 && dtTemp.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            if (!dic.ContainsKey(dr["id"].ToString()))
                            {
                                dic.Add(dr["id"].ToString(), dtTemp.Compute("sum(tolprice_mny)", "id =" + dr["id"].ToString()).ToString());
                            }
                        }
                    }
                    else
                    {
                        return lngRes;
                    }
                    strSQL = @"select a.patientname_chr,
                                       a.invoiceno_vchr,
                                       d.patientcardid_chr,
                                       b.sex_chr,
                                       a.outpatrecipeid_chr,
                                       b.idcard_chr,
                                       a.deptname_chr,
                                       b.homephone_vchr,
                                       0 totalsum_mny
                                  from t_opr_outpatientrecipeinv a,
                                       t_bse_patient b,
                                       t_bse_patientcard d
                                 where a.patientid_chr = b.patientid_chr
                                   and a.patientid_chr = d.patientid_chr
                                   and a.isvouchers_int = 2
                                   and a.recorddate_dat between
                                                               to_date(?,
                                                                       'yyyy-mm-dd hh24:mi:ss') and
                                                               to_date(?,
                                                                       'yyyy-mm-dd hh24:mi:ss')
                                   and a.recorddate_dat between  ? and  ?
                                   and not exists (select t.invoiceno_vchr
                                          from t_opr_outpatientrecipeinv t
                                         where t.isvouchers_int = 2
                                           and t.status_int = 2
                                           and a.invoiceno_vchr = t.invoiceno_vchr)";
                    objParamArr = null;
                    objSvc.CreateDatabaseParameter(4, out objParamArr);
                    objParamArr[0].Value = p_strStartDate;
                    objParamArr[1].Value = p_strEndDate;
                    objParamArr[2].Value = Convert.ToDateTime(p_strStartDate);
                    objParamArr[3].Value = Convert.ToDateTime(p_strEndDate);
                    lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objParamArr);
                    if (lngRes > 0 && p_dtResult.Rows.Count > 0)
                    {
                        foreach (DataRow dr in p_dtResult.Rows)
                        {
                            foreach (KeyValuePair<string, string> kvp in dic)
                            {
                                if (dr["outpatrecipeid_chr"].ToString() == kvp.Key.ToString())
                                {
                                    dr["totalsum_mny"] = Convert.ToDecimal(kvp.Value.ToString());
                                }
                            }
                        }
                    }
                    DataView dv = p_dtResult.DefaultView;
                    dv.RowFilter = "totalsum_mny > 0";
                    p_dtResult = dv.ToTable();
                }

            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            finally
            {
                objSvc.Dispose();
                objSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 通过日期查询缴费病人
        /// <summary>
        /// 通过日期查询缴费病人
        /// </summary>
        /// <param name="objPrincipal"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryPayedPatientByDate(System.Security.Principal.IPrincipal objPrincipal, string p_strStartDate, string p_strEndDate, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();

            clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            lngRes = clsSec.m_lngCheckCallPrivilege(objPrincipal, "com.digitalwave.iCare.middletier.HIS.Reports.clsOPChargeSvc", "m_lngQueryArrearsPatientByDate");
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"select a.patientname_chr,a.invoiceno_vchr,
                                       d.patientcardid_chr,
                                       b.sex_chr,
                                       a.outpatrecipeid_chr,
                                       b.idcard_chr,
                                       a.deptname_chr,
                                       b.homephone_vchr,
                                       a.totalsum_mny
                                  from t_opr_outpatientrecipeinv a, t_bse_patient b, t_bse_patientcard d
                                 where a.recorddate_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                   and a.patientid_chr = b.patientid_chr
                                   and a.patientid_chr = d.patientid_chr
                                   and exists (select t.outpatrecipeid_chr
                                          from t_opr_outpatientrecipeinv t
                                         where t.isvouchers_int = 2
                                           and t.status_int = 2
                                           and a.outpatrecipeid_chr = t.outpatrecipeid_chr)
                                   and not exists (select t.invoiceno_vchr
                                          from t_opr_outpatientrecipeinv t
                                         where t.isvouchers_int = 2
                                           and t.status_int = 2
                                           and a.invoiceno_vchr = t.invoiceno_vchr)";
            string strSQL1 = @"select a.patientname_chr,
                                       a.invoiceno_vchr,
                                       a.isvouchers_int,
                                       d.patientcardid_chr,
                                       b.sex_chr,
                                       a.outpatrecipeid_chr,
                                       b.idcard_chr,
                                       a.deptname_chr,
                                       b.homephone_vchr,
                                       a.totalsum_mny
                                  from t_opr_outpatientrecipeinv a, t_bse_patient b, t_bse_patientcard d
                                 where a.recorddate_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                   and a.patientid_chr = b.patientid_chr
                                   and a.patientid_chr = d.patientid_chr
                                   and exists
                                 (select m.outpatrecipedeid_old_chr
                                          from t_opr_recordselectfeeoperation m
                                         where a.outpatrecipeid_chr = m.outpatrecipedeid_new_chr)";

            clsHRPTableService objSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objSvc = new clsHRPTableService();
                objSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = p_strStartDate;
                objParamArr[1].Value = p_strEndDate;
                lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objParamArr);

                objParamArr = null;
                objSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = p_strStartDate;
                objParamArr[1].Value = p_strEndDate;
                DataTable dtTemp = new DataTable();
                lngRes = objSvc.lngGetDataTableWithParameters(strSQL1, ref dtTemp, objParamArr);
                if (lngRes > 0 && dtTemp.Rows.Count > 0)
                {
                    p_dtResult.Merge(dtTemp);
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            finally
            {
                objSvc.Dispose();
                objSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取系统时间
        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime m_datGetSeverDate()
        {
            return DateTime.Now;
        }
        #endregion
    }
}
