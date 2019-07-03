using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.middletier.HIS
{
    #region 门诊收费中间件
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
						A.ITEMOPUNIT_CHR,A.ITEMPRICE_MNY,A.ITEMOPINVTYPE_CHR,A.ITEMCATID_CHR,A.SELFDEFINE_INT,A.ITEMCODE_VCHR,A.ITEMOPCALCTYPE_CHR,A.DOSAGE_DEC,A.DOSAGEUNIT_CHR,f.precent_dec ,b.medicinetypeid_chr,
						B.NOQTYFLAG_INT,A." + strType + @" type,a.itemipunit_chr, ROUND (a.itemprice_mny / a.packqty_dec, 4) submoney, a.opchargeflg_int,a.ITEMUNIT_CHR as Unit,a.tradeprice_mny,round (a.tradeprice_mny / a.packqty_dec, 4) subtrademoney from t_bse_chargeitem A ,T_BSE_MEDICINE B,  (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f
				where  trim(A.ITEMSRCID_VCHR)=trim(B.MEDICINEID_CHR(+)) and a.IFSTOP_INT =0 AND ( Upper(A." + strType + ") LIKE ? or upper(A.ITEMCODE_VCHR) LIKE ? or upper(A.ITEMOPCODE_CHR) LIKE ?) and a.itemid_chr =f.itemid_chr(+)  order by  A.ITEMCODE_VCHR";
            if (ID.StartsWith(@"/"))//查找常用药
            {
                strSQL = @"
				select	a.itemid_chr,a.itemname_vchr,a.itemspec_vchr,a.itemengname_vchr,a.itemcode_vchr as tempitemcode, a.insuranceid_chr, 
						a.itemopunit_chr,a.itemprice_mny,a.itemopinvtype_chr,a.itemcatid_chr,a.selfdefine_int,a.itemcode_vchr,a.itemopcalctype_chr,a.dosage_dec,a.dosageunit_chr,f.precent_dec ,
						b.noqtyflag_int,a." + strType + @" type,a.itemipunit_chr, ROUND (a.itemprice_mny / a.packqty_dec, 4) submoney, a.opchargeflg_int,a.ITEMUNIT_CHR as Unit,a.tradeprice_mny,round (a.tradeprice_mny / a.packqty_dec, 4) subtrademoney from t_bse_chargeitem A ,T_BSE_MEDICINE B, 
						(select precent_dec,itemid_chr,copayid_chr from t_aid_inschargeitem where copayid_chr = ?) f,
						(select seqid_chr, create_dat, deptid_chr, itemid_chr, createrid_chr, privilege_int, type_int from t_aid_comusechargeitem  WHERE createrid_chr = ? AND type_int = 1
						UNION
						select a.seqid_chr, a.create_dat, a.deptid_chr, a.itemid_chr, a.createrid_chr, a.privilege_int, a.type_int from t_aid_comusechargeitem a,
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

            string strSQL = @"
							SELECT  a.itemid_chr,
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
       a.lastchange_dat,b.noqtyflag_int,b.ifstop_int,
       round (a.itemprice_mny / a.packqty_dec,4) submoney,
       a.tradeprice_mny,
       round (a.tradeprice_mny / a.packqty_dec, 4) subtrademoney
								from t_bse_chargeitem a, t_bse_medicine b
							where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
								and a.ifstop_int = 0
								and ( (lower (a.itemname_vchr) like ?)
									  or(lower (a.itemcode_vchr) like ?)
									  or(lower (a.itempycode_chr) like ?)
									  or(lower (a.itemwbcode_chr) like ?)
									)
							order by a.itemcatid_chr";

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

                string strSQL = @"Insert Into t_opr_outpatientrecipe(OUTPATRECIPEID_CHR,PATIENTID_CHR,CREATEDATE_DAT,REGISTERID_CHR,DIAGDR_CHR,DIAGDEPT_CHR,RECORDEMP_CHR,RECORDDATE_DAT,PSTAUTS_INT,PAYTYPEID_CHR,RECIPEFLAG_INT, ISPROXYBOILMED) Values(
                                                                ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?)";

                objHRPSvc.CreateDatabaseParameter(12, out ParamArr);
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
                ParamArr[11].Value = clsVO.IsProxyBoilMed;

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

            string strSQL = @"select substr (to_char(seq_recipesendnum.NEXTVAL), -4) from dual ";

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
                foreach (clsMedrecipesend_VO objs in objCMedicineSend)
                {
                    strSQL = @"select seq_recipesendid.NEXTVAL from dual";
                    recipeid = objs.m_strOUTPATRECIPEID_CHR;
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                    if (lngRes > 0)
                    {
                        string sid = dt.Rows[0][0].ToString();

                        strSQL = @"insert into t_opr_recipesend
                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int,sendwindowid_chr)
                                       select ?, substr (to_char(seq_recipesendnum.NEXTVAL), -4), ?, ?, ?, ?, 1, 0,?
                                         from dual";

                        objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                        ParamArr[0].Value = sid;
                        ParamArr[1].Value = pid;
                        ParamArr[2].Value = date;
                        ParamArr[3].Value = objs.m_strMedstroeID_CHR;
                        ParamArr[4].Value = objs.m_strWINDOWID_CHR;
                        ParamArr[5].Value = objs.m_strSendWINDOWID_CHR;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        strSQL = @"insert into t_opr_recipesendentry (sid_int, outpatrecipeid_chr) values (?, ?)";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = sid;
                        ParamArr[1].Value = recipeid;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        strSQL = @"insert into t_opr_medstorewinque (seq_int, windowid_chr, windowtype_int, medstoreid_chr, outpatrecipeid_chr, recipetype_chr, order_int, sid_int) 
                                                                 values (seq_medstore.NEXTVAL, ?, ?, ?, ?, ?, ?, ?)";

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
                    strSQL = @"select seq_recipesendid.NEXTVAL from dual";
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
                                                                 values (seq_medstore.NEXTVAL, ?, ?, ?, ?, ?, ?, ?)";

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
                                      (sid_int, serno_chr, patientid_chr, createdate_chr, medstoreid_chr,
                                       windowid_chr, pstatus_int, autoprint_int, sendwindowid_chr)
                                    values
                                      (?,substr (to_char(seq_recipesendnum.NEXTVAL), -4), ?, ?, ?, ?, 1, 0, ?)";
                    //select ?, substr (to_char(seq_recipesendnum.NEXTVAL), -4), ?, ?, ?, ?, 1, 0
                    //  from dual";
                    clsMedrecipesend_VO objs = objWMedicineSend[0] as clsMedrecipesend_VO;
                    objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                    ParamArr[0].Value = m_strWSid;
                    //ParamArr[1].Value = ((clsMedrecipesend_VO)objWMedicineSend[0]).m_strSerNO;
                    ParamArr[1].Value = pid;
                    ParamArr[2].Value = date;
                    ParamArr[3].Value = objs.m_strMedstroeID_CHR;
                    ParamArr[4].Value = objs.m_strWINDOWID_CHR;
                    ParamArr[5].Value = objs.m_strSendWINDOWID_CHR;
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

        #region 获取员工隶属组
        /// <summary>
        /// 根据员工获取员工所在组
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="dtbResult">返回DataTable,groupid_chr组ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGroupEmp(string EmpID, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = new DataTable();
            string strSQL = @"select a.empid_chr, b.groupid_chr, b.groupname_vchr,b.memo_vchr
  from t_bse_groupemp a, t_bse_groupdesc b
 where a.groupid_chr = b.groupid_chr and a.empid_chr =? and end_dat is null";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = EmpID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                //objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                //objHRPSvc.Dispose();
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
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
            clsRecipeDetail_VO[] objRD_VO, decimal times, clsInvoice_VO[] objInvoice_VOArr, ArrayList[] objArr1, ArrayList[] objArr2, ArrayList objMedicineSend, string strOpChargeDeptId, bool blnFlag)
        {
            long lngRes = 0, lngAffects = 0;
            strRecipeNo = "";
            //m_objMedicineSend = new ArrayList();
            try
            {
                #region 保存处方主表
                //com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc objEmployeeSvc =new com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc();
                //com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc objEmployeeSvc = (com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc)
                //    com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc));
                string strGroupID = "";
                DataTable tempDt;
                string strSQL = "";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                DataTable dt = new DataTable();

                int secuLevel = 0;
                foreach (clsOutPatientRecipe_VO objTempMain in objVOMainArr)
                {
                    strSQL = @"select seculevel from t_opr_outpatientrecipe where outpatrecipeid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                    if (dt.Rows.Count > 0 && dt.Rows[0]["seculevel"] != DBNull.Value)
                    {
                        secuLevel = Convert.ToInt32(dt.Rows[0]["seculevel"]);
                    }
                    else
                    {
                        secuLevel = 0;
                    }

                    //lngRes =objEmployeeSvc.m_lngGetGroupEmp(objTempMain.m_strDoctorID,out tempDt);
                    lngRes = this.m_lngGetGroupEmp(objTempMain.m_strDoctorID, out tempDt);
                    if (lngRes > 0 && tempDt.Rows.Count > 0)
                    {
                        strGroupID = tempDt.Rows[0]["groupid_chr"].ToString();
                    }
                    //if (!blnFlag)
                    //{
                    this.m_mthDeleteRecipeDetail(objTempMain.m_strOutpatRecipeID.Trim());
                    //}
                    //else
                    //{
                    //    strSQL = @"DELETE FROM t_opr_outpatientrecipe t WHERE t.outpatrecipeid_chr = ?";
                    //    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    //    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID.Trim();
                    //    long lngeff = -1;
                    //    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngeff, ParamArr);
                    //    if (lngRes < 0)
                    //    {
                    //        return lngRes;
                    //    }
                    //}

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
                        strSQL = @"insert into t_opr_reciperelation(seqid,outpatrecipeid_chr) values(?, ?)";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                        ParamArr[1].Value = objTempMain.m_strOutpatRecipeID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }

                    //处方主表
                    strSQL = @"insert into t_opr_outpatientrecipe(outpatrecipeid_chr,patientid_chr,createdate_dat,registerid_chr,diagdr_chr,diagdept_chr,recordemp_chr,
                                                                  recorddate_dat,pstauts_int,paytypeid_chr,recipeflag_int,groupid_chr,casehisid_chr,type_int, createtype_int, deptmed_int,chargedeptid_chr, seculevel, isproxyboilmed) values(
                                                                  ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(19, out ParamArr);
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
                    ParamArr[16].Value = strOpChargeDeptId;
                    ParamArr[17].Value = secuLevel;
                    ParamArr[18].Value = objTempMain.IsProxyBoilMed;
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
                    //ArrayList m_objMedicineSend;
                    //中药处方发送信息
                    ArrayList m_objCMSendList = new ArrayList();
                    //西药处方发送信息
                    ArrayList m_objWMSendList = new ArrayList();
                    foreach (clsMedrecipesend_VO item3 in objMedicineSend)
                    {
                        //						item3.m_strOUTPATRECIPEID_CHR =((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                        item3.m_strOUTPATRECIPEID_CHR = objTempMain.m_strOutpatRecipeID;
                        strSQL = @"Insert Into t_opr_medrecipesend(OUTPATRECIPEID_CHR,RECIPETYPE_INT, MEDSTOREID_CHR, WINDOWID_CHR,PSTATUS_INT,SENDDATE_DAT,SENDEMP_CHR) Values( 
                                                                   ?, ?, ?, ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?)";

                        objHRPSvc.CreateDatabaseParameter(7, out ParamArr);
                        ParamArr[0].Value = item3.m_strOUTPATRECIPEID_CHR;
                        ParamArr[1].Value = item3.m_strRECIPETYPE_INT;
                        ParamArr[2].Value = item3.m_strMedstroeID_CHR;
                        ParamArr[3].Value = item3.m_strWINDOWID_CHR;
                        ParamArr[4].Value = item3.m_intPSTATUS_INT;
                        ParamArr[5].Value = item3.m_strSENDDATE_DAT;
                        ParamArr[6].Value = item3.m_strSENDEMP_CHR;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                        //m_objMedicineSend.Add(item3);
                        if (item3.m_strFlag == "0")
                        {
                            //objSvc.m_mthGetSerNO(out m_strSerNO);
                            //m_objTemp.m_strSerNO = m_strSerNO;
                            m_objWMSendList.Add(item3);
                        }
                        else
                        {
                            m_objCMSendList.Add(item3);
                        }
                        //发药队列
                        //objmedwin.m_strWINDOWID_CHR = item3.m_strWINDOWID_CHR;
                        //objmedwin.m_intWaitNO = Convert.ToInt32(item3.Sortno);
                        //objmedwin.m_intWINDOWTYPE_INT = 1;
                        //objmedwin.m_strMEDSTOREID_CHR = item3.m_strMedstroeID_CHR;
                        //objmedwin.m_strOUTPATRECIPEID_CHR = item3.m_strOUTPATRECIPEID_CHR;
                        //objmedwin.m_strRECIPETYPE_CHR = item3.m_strRECIPETYPE_INT;
                        //lngRes = objwin.m_lngAddNewWinque(objPri, objmedwin);                        
                    }
                    this.m_mthSaveMedicineSend(objPri, ref objVOMainArr, ref m_objWMSendList, ref m_objCMSendList);
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
                //                        strSQL = @"select seq_recipesendid.NEXTVAL from dual";

                //                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                //                        if (lngRes > 0)
                //                        {
                //                           string sid = dt.Rows[0][0].ToString();

                //                           #region 由于出现重号暂停用
                //                           /*
                //                           strSQL = @"insert into t_opr_recipesend
                //                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                //                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int)
                //                                       select ?, lpad (nvl (to_number (max (a.serno_chr)), 0) + 1, 4, '0'), ?, ?, ?, ?, 1, 0
                //                                         from t_opr_recipesend a
                //                                        where a.createdate_chr = ?";

                //                           objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                //                           ParamArr[0].Value = sid;
                //                           ParamArr[1].Value = pid;
                //                           ParamArr[2].Value = date;
                //                           ParamArr[3].Value = objs.m_strMedstroeID_CHR;
                //                           ParamArr[4].Value = objs.m_strWINDOWID_CHR;
                //                           ParamArr[5].Value = date;
                //                           */
                //                           #endregion

                //                           strSQL = @"insert into t_opr_recipesend
                //                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                //                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int)
                //                                       select ?, substr (to_char(seq_recipesendnum.NEXTVAL), -4), ?, ?, ?, ?, 1, 0
                //                                         from dual";

                //                           objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                //                           ParamArr[0].Value = sid;
                //                           ParamArr[1].Value = pid;
                //                           ParamArr[2].Value = date;
                //                           ParamArr[3].Value = objs.m_strMedstroeID_CHR;
                //                           ParamArr[4].Value = objs.m_strWINDOWID_CHR;

                //                           lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                //                            strSQL = @"insert into t_opr_recipesendentry (sid_int, outpatrecipeid_chr) values (?, ?)";

                //                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                //                            ParamArr[0].Value = sid;
                //                            ParamArr[1].Value = recipeid;

                //                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                //                            strSQL = @"insert into t_opr_medstorewinque (seq_int, windowid_chr, windowtype_int, medstoreid_chr, outpatrecipeid_chr, recipetype_chr, order_int, sid_int) 
                //                                                                 values (seq_medstore.NEXTVAL, ?, ?, ?, ?, ?, ?, ?)";

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

                    // objRD_VO[i].m_strOutpatRecipeID=strRecipeNo;//保存项目明细
                    strSQL = @"insert into t_opr_oprecipeitemde
                                  (outpatrecipeid_chr,
                                   itemid_chr,
                                   qty_dec,
                                   unitid_chr,
                                   price_mny,
                                   tolprice_mny,
                                   discount_dec,
                                   recipetype_int,
                                   buyprice_dec)
                                values
                                  (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    objHRPSvc.CreateDatabaseParameter(9, out ParamArr);
                    ParamArr[0].Value = objRD_VO[i].m_strOutpatRecipeID;
                    ParamArr[1].Value = objRD_VO[i].strCharegeItemID;
                    ParamArr[2].Value = objRD_VO[i].decQuantity;
                    ParamArr[3].Value = objRD_VO[i].strUint;
                    ParamArr[4].Value = objRD_VO[i].decPrice;
                    ParamArr[5].Value = objRD_VO[i].decSumMoney;
                    ParamArr[6].Value = objRD_VO[i].decDiscount / 100;
                    ParamArr[7].Value = objRD_VO[i].strType;
                    ParamArr[8].Value = (objRD_VO[i].BuyPrice == 0 && objRD_VO[i].decPrice > 0 ? objRD_VO[i].decPrice : objRD_VO[i].BuyPrice);

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    switch (objRD_VO[i].strType)
                    {
                        case "0001":
                            strSQL = @"insert into t_opr_outpatientpwmrecipede(outpatrecipeid_chr,rowno_chr,itemid_chr,unitid_chr,tolqty_dec,unitprice_mny,tolprice_mny,outpatrecipedeid_chr,discount_dec,medstoreid_chr,
							                     windowid_chr,usageid_chr,freqid_chr,qty_dec,days_int,hypetest_int,desc_vchr, itemspec_vchr, dosage_dec, dosageunit_chr, attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, deptmed_int,toldiffprice_mny) values(
                                                 ?, ?, ?, ?, ?, ?, ?, seq_recipeid.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                            objHRPSvc.CreateDatabaseParameter(26, out ParamArr);
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
                            ParamArr[25].Value = objRD_VO[i].m_decTolDiffPrice;// 总让利金额

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0002":
                            strSQL = @"insert into t_opr_outpatientcmrecipede(outpatrecipeid_chr,rowno_chr,itemid_chr,unitid_chr,min_qty_dec,unitprice_mny,tolprice_mny,outpatrecipedeid_chr,discount_dec,
                                                 times_int,medstoreid_chr,windowid_chr,usageid_chr,qty_dec,sumusage_vchr, itemname_vchr, itemspec_vchr, deptmed_int, usagedetail_vchr,toldiffprice_mny) values(
                                                 ?, ?, ?, ?, ?, ?, ?, seq_recipeid.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                            objHRPSvc.CreateDatabaseParameter(19, out ParamArr);
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
                            ParamArr[18].Value = objRD_VO[i].m_decTolDiffPrice;// 总让利金额

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0003":
                            strSQL = @"insert into t_opr_outpatientchkrecipede(outpatrecipeid_chr,rowno_chr,itemid_chr,qty_dec,price_mny,tolprice_mny,outpatrecipedeid_chr, attachid_vchr,discount_dec,medstoreid_chr,windowid_chr, 
                                       attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, orderid_vchr, orderbasenum_dec) values(
                                       ?, ?, ?, ?, ?, ?, seq_recipeid.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                            strSQL = @"insert into t_opr_outpatienttestrecipede(outpatrecipeid_chr,rowno_chr,itemid_chr,qty_dec,price_mny,tolprice_mny,outpatrecipedeid_chr, attachid_vchr,discount_dec,medstoreid_chr,windowid_chr, 
                                       attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, orderid_vchr, orderbasenum_dec) values(
                                       ?, ?, ?, ?, ?, ?, seq_recipeid.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                            strSQL = @"insert into t_opr_outpatientothrecipede(outpatrecipeid_chr,rowno_chr,itemid_chr,unitid_chr,qty_dec,unitprice_mny,tolprice_mny,outpatrecipedeid_chr, attachid_vchr,discount_dec,medstoreid_chr,
                                       windowid_chr, attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int, toldiffprice_mny) values(
                                       ?, ?, ?, ?, ?, ?, ?, seq_recipeid.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                            objHRPSvc.CreateDatabaseParameter(21, out ParamArr);
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
                            ParamArr[20].Value = objRD_VO[i].m_decTolDiffPrice;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0006":
                            strSQL = @"insert into t_opr_outpatientopsrecipede(outpatrecipeid_chr,rowno_chr,itemid_chr,qty_dec,price_mny,tolprice_mny,outpatrecipedeid_chr,attachid_vchr,discount_dec,medstoreid_chr,windowid_chr, attachparentid_vchr,  
                                       attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int, orderid_vchr, orderbasenum_dec) values(
                                       ?, ?, ?, ?, ?, ?, seq_recipeid.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                    strSQL = @"Insert Into t_opr_outpatientrecipeinv(INVOICENO_VCHR,OUTPATRECIPEID_CHR,INVDATE_DAT,ACCTSUM_MNY,SBSUM_MNY,OPREMP_CHR,RECORDEMP_CHR,RECORDDATE_DAT,
                                                                STATUS_INT,SEQID_CHR,TOTALSUM_MNY,PAYTYPE_INT,PATIENTID_CHR,PATIENTNAME_CHR,DEPTID_CHR,DEPTNAME_CHR,
                                                                DOCTORID_CHR,DOCTORNAME_CHR,CONFIRMEMP_CHR,PAYTYPEID_CHR,INTERNALFLAG_INT,BASESEQID_CHR,GROUPID_CHR, CONFIRMDEPTID_CHR, SPLIT_INT, regno_chr,chargedeptid_chr,totaldiffcost_mny) Values(
                                                                ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?)";

                    objHRPSvc.CreateDatabaseParameter(28, out ParamArr);
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
                    ParamArr[25].Value = objInvoice_VOArr[i2].RegNo;
                    ParamArr[26].Value = strOpChargeDeptId;
                    ParamArr[27].Value = objInvoice_VOArr[i2].m_decTolDiffPrice; // 总让利金额
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //临时： 一张发票只能一种支付方式的情况
                    //以后： 应该还包括多种方式一张发票的情况
                    strSQL = @"insert into t_opr_payment(chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr, paysum_mny, refusum_mny) values(
                                                         ?, ?, ?, ?, ?, 0)";

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
                        strSQL = @"Insert Into t_opr_outpatientrecipeinvde(ITEMCATID_CHR,TOLFEE_MNY,INVOICENO_VCHR,SBSUM_MNY,SEQID_CHR) Values(?, ?, ?, ?, ?)";

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
                        strSQL = @"Insert Into T_OPR_OUTPATIENTRECIPESUMDE(ITEMCATID_CHR,TOLFEE_MNY,INVOICENO_VCHR,SBSUM_MNY,SEQID_CHR) Values(?, ?, ?, ?, ?)";

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
            // 核算分类总金额 * 自费占总金额的比例 = 核算分类自费金额
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
                        strSQL = @"Insert Into T_OPR_RECIPERELATION(SEQID,OUTPATRECIPEID_CHR) Values(?, ?)";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                        ParamArr[1].Value = objTempMain.m_strOutpatRecipeID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }

                    //处方主表
                    strSQL = @"Insert Into t_opr_outpatientrecipe(OUTPATRECIPEID_CHR,PATIENTID_CHR,CREATEDATE_DAT,REGISTERID_CHR,DIAGDR_CHR,DIAGDEPT_CHR,RECORDEMP_CHR,
                                                                  RECORDDATE_DAT,PSTAUTS_INT,PAYTYPEID_CHR,RECIPEFLAG_INT,GROUPID_CHR,CASEHISID_CHR,TYPE_INT, createtype_int, deptmed_int, isproxyboilmed) Values(
                                                                  ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(17, out ParamArr);
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
                    ParamArr[16].Value = objTempMain.IsProxyBoilMed;

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
                            strSQL = @"Insert Into t_opr_outpatientpwmrecipede(outpatrecipeid_chr,rowno_chr,itemid_chr,unitid_chr,tolqty_dec,unitprice_mny,tolprice_mny,outpatrecipedeid_chr,discount_dec,medstoreid_chr,
							                     windowid_chr,usageid_chr,freqid_chr,qty_dec,days_int,hypetest_int,desc_vchr, itemspec_vchr, dosage_dec, dosageunit_chr, attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, deptmed_int,toldiffprice_mny) Values(
                                                 ?, ?, ?, ?, ?, ?, ?, seq_recipeid.NEXTVAL, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                            objHRPSvc.CreateDatabaseParameter(26, out ParamArr);
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
                            ParamArr[25].Value = objRD_VO[i].m_decTolDiffPrice;// 总让利金额

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0002":
                            strSQL = @"Insert Into T_OPR_OUTPATIENTCMRECIPEDE(OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,UNITID_CHR,MIN_QTY_DEC,UNITPRICE_MNY,TOLPRICE_MNY,OUTPATRECIPEDEID_CHR,DISCOUNT_DEC,
                                                 TIMES_INT,MEDSTOREID_CHR,WINDOWID_CHR,USAGEID_CHR,QTY_DEC,SUMUSAGE_VCHR, itemname_vchr, itemspec_vchr, deptmed_int, UsageDetail_vchr,toldiffprice_mny) Values(
                                                 ?, ?, ?, ?, ?, ?, ?, seq_recipeid.NEXTVAL, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                            objHRPSvc.CreateDatabaseParameter(19, out ParamArr);
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
                            ParamArr[18].Value = objRD_VO[i].m_decTolDiffPrice;// 总让利金额

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                            break;
                        case "0003":
                            strSQL = @"Insert Into t_opr_outpatientchkrecipede(OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,QTY_DEC,PRICE_MNY,TOLPRICE_MNY,OUTPATRECIPEDEID_CHR, ATTACHID_VCHR,DISCOUNT_DEC,MEDSTOREID_CHR,WINDOWID_CHR, 
                                       attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, orderid_vchr, orderbasenum_dec) Values(
                                       ?, ?, ?, ?, ?, ?, seq_recipeid.NEXTVAL, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                            strSQL = @"Insert Into t_opr_outpatienttestrecipede(OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,QTY_DEC,PRICE_MNY,TOLPRICE_MNY,OUTPATRECIPEDEID_CHR, ATTACHID_VCHR,DISCOUNT_DEC,MEDSTOREID_CHR,WINDOWID_CHR, 
                                       attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, orderid_vchr, orderbasenum_dec) Values(
                                       ?, ?, ?, ?, ?, ?, seq_recipeid.NEXTVAL, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                            strSQL = @"Insert Into t_opr_outpatientothrecipede(OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,UNITID_CHR,QTY_DEC,UNITPRICE_MNY,TOLPRICE_MNY,OUTPATRECIPEDEID_CHR, ATTACHID_VCHR,DISCOUNT_DEC,MEDSTOREID_CHR,
                                       WINDOWID_CHR, attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int) Values(
                                       ?, ?, ?, ?, ?, ?, ?, seq_recipeid.NEXTVAL, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                            strSQL = @"Insert Into T_OPR_OUTPATIENTOPSRECIPEDE(OUTPATRECIPEID_CHR,ROWNO_CHR,ITEMID_CHR,QTY_DEC,PRICE_MNY,TOLPRICE_MNY,OUTPATRECIPEDEID_CHR,ATTACHID_VCHR,DISCOUNT_DEC,MEDSTOREID_CHR,WINDOWID_CHR, attachparentid_vchr,  
                                       attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int, orderid_vchr, orderbasenum_dec) Values(
                                       ?, ?, ?, ?, ?, ?, seq_recipeid.NEXTVAL, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                                                                        HYPETEST_INT,DESC_VCHR, itemspec_vchr, dosage_dec, dosageunit_chr, attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, deptmed_int) Values(seq_recipeid.NEXTVAL, '" +
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
                                                                       WINDOWID_CHR,USAGEID_CHR,QTY_DEC,SUMUSAGE_VCHR, itemname_vchr, itemspec_vchr, deptmed_int, UsageDetail_vchr) Values(seq_recipeid.NEXTVAL, '" +
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
                                       attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, orderid_vchr, orderbasenum_dec) Values(seq_recipeid.NEXTVAL, '" +
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
                                       attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, orderid_vchr, orderbasenum_dec) Values(seq_recipeid.NEXTVAL, '" +
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
                                       WINDOWID_CHR, attachparentid_vchr, attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int) Values(seq_recipeid.NEXTVAL, '" +
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
                                       attachitembasenum_dec, usageparentid_vchr, usageitembasenum_dec, itemname_vchr, itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int, orderid_vchr, orderbasenum_dec) Values(seq_recipeid.NEXTVAL, '" +
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

            string strSQL = @"SELECT outpatrecipeid_chr, a.createdate_dat, a.diagdr_chr, a.diagdept_chr,
       a.pstauts_int, a.recipeflag_int, a.paytypeid_chr, a.type_int, b.deptname_vchr,
       c.lastname_vchr, c.empno_chr, d.paytypename_vchr,d.INTERNALFLAG_INT,d.CHARGEPERCENT_DEC,d.PAYLIMIT_MNY
  FROM t_opr_outpatientrecipe a,
       t_bse_deptdesc b,
       t_bse_employee c,
       t_bse_patientpaytype d
 WHERE a.diagdr_chr = c.empid_chr(+) AND a.diagdept_chr = b.deptid_chr(+)
       AND a.paytypeid_chr = d.paytypeid_chr(+)  and  a.PATIENTID_CHR = ? ";

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
        public long m_mthFindRecipeByID(string ID, out DataTable dt, System.Security.Principal.IPrincipal objPri, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strflag = "OPR";
            if (flag)
            {
                strflag = "TMP";
            }
            string strSQL = @"SELECT * FROM (SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.unitid_chr UNIT, a.tolqty_dec quantity,
       a.unitprice_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,a.USAGEID_CHR,a.FREQID_CHR,a.QTY_DEC,a.DAYS_INT, 
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (1000 + to_number(nvl(a.rowno_vchr2,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times, b.itemipunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,
b.opchargeflg_int,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,'' as ATTACHID_VCHR,a.HYPETEST_INT,a.DESC_VCHR, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, '' as orderid, 0 as ordernum,a.toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney  
  FROM t_" + strflag + @"_outpatientpwmrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION  all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.unitid_chr UNIT, a.MIN_QTY_DEC quantity,
       a.unitprice_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,a.USAGEID_CHR,'' as FREQID_CHR,MIN_QTY_DEC as QTY_DEC,1 as DAYS_INT, 
       b.itemname_vchr itemname, b.itemspec_vchr Dec,a.SUMUSAGE_VCHR, (2000 + to_number(nvl(a.rowno_vchr2,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, a.times_int Times,'',1,0,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,'' as ATTACHID_VCHR,0, a.UsageDetail_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, '' as orderid, 0 as ordernum,a.toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney  
  FROM t_" + strflag + @"_outpatientcmrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.itemunit_vchr UNIT, a.qty_dec quantity,
       a.price_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,'' as USAGEID_CHR,'' as FREQID_CHR,0 as QTY_DEC,1 as DAYS_INT,
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (3000 + to_number(nvl(a.rowno_chr,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times,'',1,0,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,a.ATTACHID_VCHR,0,a.itemusagedetail_vchr as desc_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,0 as toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney   
  FROM t_" + strflag + @"_outpatientchkrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.itemunit_vchr UNIT, a.qty_dec quantity,
       a.price_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,a.USAGEID_CHR,'' as FREQID_CHR,0 as QTY_DEC,1 as DAYS_INT,
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (4000 + to_number(nvl(a.rowno_chr,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times,'',1,0,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,a.ATTACHID_VCHR,0,a.itemusagedetail_vchr as desc_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,0 as toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney    
  FROM t_" + strflag + @"_outpatienttestrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.itemunit_vchr UNIT, a.qty_dec quantity,
       a.unitprice_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,'' as USAGEID_CHR,'' as FREQID_CHR,0 as QTY_DEC,1 as DAYS_INT,
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (6000 + to_number(nvl(a.rowno_chr,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times,'',1,0,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,a.ATTACHID_VCHR,0,a.itemusagedetail_vchr as desc_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, '' as orderid, 0 as ordernum,0 as toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney   
  FROM t_" + strflag + @"_outpatientothrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.itemunit_vchr UNIT, a.qty_dec quantity,
       a.price_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,a.USAGEID_CHR,'' as FREQID_CHR,0 as QTY_DEC,1 as DAYS_INT,
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (5000 + to_number(nvl(a.rowno_chr,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times,'',1,0,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,a.ATTACHID_VCHR,0,a.itemusagedetail_vchr as desc_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,0 as toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney    
  FROM t_" + strflag + @"_outpatientopsrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
		) t1,t_opr_outpatientrecipe t2 WHERE t1.outpatrecipeid_chr = t2.outpatrecipeid_chr order by t1.sortno";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = ID;
                ParamArr[1].Value = ID;
                ParamArr[2].Value = ID;
                ParamArr[3].Value = ID;
                ParamArr[4].Value = ID;
                ParamArr[5].Value = ID;

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
            string strSQL = @"select a.outpatrecipeid_chr,
       a.patientid_chr,
       a.createdate_dat,
       a.registerid_chr,
       a.diagdr_chr,
       a.diagdept_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.pstauts_int,
       a.recipeflag_int,
       a.outpatrecipeno_vchr,
       a.paytypeid_chr,
       a.casehisid_chr,
       a.groupid_chr,
       a.type_int,
       a.confirm_int,
       a.confirmdesc_vchr,
       a.createtype_int,
       a.deptmed_int,
       a.archtakeflag_int,
       a.printed_int,
       a.chargedeptid_chr,b.coalitionrecipeflag_int from t_opr_outpatientrecipe a,t_bse_patientpaytype b where a.paytypeid_chr =b.paytypeid_chr(+) and (a.pstauts_int = 1 or a.pstauts_int = 4) and a.patientid_chr = ? and  a.recorddate_dat between 
                            to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') order by a.recipeflag_int asc, a.recorddate_dat desc";
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
            string SQL = @"select a.outpatrecipeid_chr,
       a.patientid_chr,
       a.createdate_dat,
       a.registerid_chr,
       a.diagdr_chr,
       a.diagdept_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.pstauts_int,
       a.recipeflag_int,
       a.outpatrecipeno_vchr,
       a.paytypeid_chr,
       a.casehisid_chr,
       a.groupid_chr,
       a.type_int,
       a.confirm_int,
       a.confirmdesc_vchr,
       a.createtype_int,
       a.deptmed_int,
       a.archtakeflag_int,
       a.printed_int,
       a.chargedeptid_chr from t_opr_outpatientrecipe a
                           where (a.pstauts_int = 1 or a.pstauts_int = 4)
                             and a.patientid_chr = ?  
                             and to_char(a.recorddate_dat, 'yyyy-mm-dd') = ?";

            long lngRes = 0;
            DataTable dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = pid;
                ParamArr[1].Value = DateTime.Now.ToString("yyyy-MM-dd");

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
            string strSQL = @"select INVOICENO_VCHR as invono 
                                from T_OPR_OUTPATIENTRECIPEINV 
                               where INVOICENO_VCHR = ? 
                             
                            union all   
                            
                              select repprninvono_vchr as invono
                                from t_opr_invoicerepeatprint
                               where type_chr = '1' 
                                 and repprninvono_vchr = ?";

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

            string strSQL = @"select mapid_chr,groupid_chr,catid_chr,internalflag_int from t_bse_chargecatmap  where internalflag_int=1";
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

                SQL = @"select a.isselfhelp, a.flag_int,a.diagdoctor_chr,a.diagdept_chr from t_opr_patientregister a where a.registerid_chr= ?";
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRegID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtTmp, ParamArr);
                string strRegDept = null;
                if (lngRes > 0 && dtTmp.Rows.Count > 0)
                {
                    strRegDept = dtTmp.Rows[0]["diagdept_chr"].ToString();

                    if (dtTmp.Rows[0][0].ToString().Trim() == "3")
                    {
                        intArchTakeFlag = 2;//（自助挂号未收费）带出挂号费
                    }
                    else
                    {
                        intArchTakeFlag = 1;
                    }
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
            string strSQL = @"select paytypeid_chr, itemid_chr, qty_dec, register_int, recipeflag_int, expert_int from t_aid_chargepaytype 
								where (paytypeid_chr = ? or paytypeid_chr = '0000') 
								  and (register_int = ? or register_int = 0)  
								  and (recipeflag_int = ? or recipeflag_int = 0) 
								  and (expert_int = ? or expert_int = 0)";
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
        /// <param name="strPatType"></param>
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
                              where a.itemsrcid_vchr = b.medicineid_chr(+)
                                and a.ifstop_int = 0
                                and a.itemid_chr = ?
                                and a.itemid_chr = f.itemid_chr(+)
                                and a.itemid_chr = c.itemid_chr
                           order by a.itemcode_vchr";

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
            string strSQL = @"select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr from t_sys_setting where setid_chr ='0005'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dt = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() == "1")
                    {
                        strSQL = @"select internalflag_int,internaldesc_vchr from t_opr_outpatientrecipeinv_itl order by internalflag_int";
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
            string strSQL = @"select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr from t_sys_setting where setid_chr = ?";
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
            string SQL = @"select count(*) nums from t_bse_chargeitem a, t_aid_chargemderla b 
						   where a.itemcatid_chr = b.itemcatid_chr and b.medicinetypeid_chr = '5' and a.itemid_chr = ?";

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

                int DateInterval = 0;
                DataTable dt = new DataTable();
                SQL = @"select setstatus_int from t_sys_setting where setid_chr = '0058'";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (lngRes > 0 && dt.Rows.Count == 1)
                {
                    string s = dt.Rows[0][0].ToString().Trim();
                    if (s != "" && Convert.ToInt32(s) > 0)
                    {
                        DateInterval = Convert.ToInt32(s) - 1;
                    }
                }

                SQL = @"select count(*) nums 
                             from t_opr_patientregister 
						   where registerid_chr = ?  
                             and pstatus_int <> 3 
                             and flag_int <> 3
                             and (to_char(registerdate_dat, 'yyyy-mm-dd') between to_char(sysdate - ?, 'yyyy-mm-dd') and to_char(sysdate, 'yyyy-mm-dd'))";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strRegID;
                ParamArr[1].Value = DateInterval.ToString();

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
								  (select precent_dec,itemid_chr,copayid_chr from t_aid_inschargeitem where copayid_chr = ?) c,
								  (select itemid_chr, subitemid_chr, qty_int, usageid_chr, freqid_chr, days_int, totalqty_dec, usescope_int, continueusetype_int from t_bse_subchargeitem where itemid_chr = ?) d 
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

            string strSQL = @"select paycardtype_int,paycarddesc_vchr from t_bse_paycardtype order by paycardtype_int";
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

            string strSQL = @"select patientid_chr,modify_dat,paycardtype_int,paycardno_vchr,paycardstatus_int from t_bse_patientcardtype where paycardstatus_int = 1 and patientid_chr = ?";
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

            string SQL = @" select a.outpatrecipeid_chr, a.recipetype_int, a.windowid_chr, a.pstatus_int,
       a.senddate_dat, a.sendemp_chr, a.treatdate_dat, a.treatemp_chr,
       a.autoprint_int, a.medstoreid_chr, a.finallysendwindowid,
       a.finallywindowid, a.sendwindowid, a.givedate_dat, a.giveemp_chr,
       a.returndate_dat, a.returnemp_chr, a.remark_vchr, a.autoprintyd_int, 
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

                    //Oldinvono = repinvono;
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
        public void m_mthGetbalancerepeatinvoinfo(string BalanceEmp, string BalanceTime, out string[] InvonoArr, int status)
        {
            InvonoArr = null;
            DataTable dt = new DataTable();
            long lngRes = 0;
            string SQL = "";

            //未结帐
            if (status == 0)
            {
                SQL = @"select b.repprninvono_vchr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_invoicerepeatprint b
                     where a.seqid_chr = b.seqid_chr 
                       and a.balanceflag_int = 0 
                       and b.type_chr = '1' 
                       and a.recordemp_chr = ? 
                       and a.recorddate_dat < to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                    order by b.repprninvono_vchr";
            }
            //已结帐
            else if (status == 1)
            {
                SQL = @"select b.repprninvono_vchr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_invoicerepeatprint b
                     where a.seqid_chr = b.seqid_chr 
                       and a.balanceflag_int = 1 
                       and b.type_chr = '1' 
                       and a.balanceemp_chr = ?
                       and a.balance_dat = to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                    order by b.repprninvono_vchr";
            }
            else
            {
                return;
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BalanceEmp;
                ParamArr[1].Value = BalanceTime;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region (体检)获取体检登记操作者信息
        /// <summary>
        /// (体检)获取体检登记操作者信息
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="EmpVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPEDoctor(string CardNo, out clsEmployeeVO EmpVO)
        {
            long lngRes = 0;
            DataTable dtValues = new DataTable();
            string strSQL = @"select   c.empid_chr, c.lastname_vchr, c.empno_chr, c.pycode_chr,
                                       c.isexpert_chr, c.isexternalexpert_chr, 1 as orderstr
                                  from t_pe_register a, t_bse_patientcard b, t_bse_employee c
                                 where a.patientid_chr = b.patientid_chr
                                   and a.regoper_chr = c.empid_chr
                                   and a.chargeflag_int = 0
                                   and rownum = 1
                                   and b.patientcardid_chr = ? ";
            EmpVO = null;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = CardNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValues, param);
                if (dtValues.Rows.Count != 1)
                {
                    objHRPSvc.Dispose();
                    return -1;
                }

                EmpVO = new clsEmployeeVO();
                EmpVO.strEmpID = dtValues.Rows[0]["empid_chr"].ToString();
                EmpVO.strName = dtValues.Rows[0]["lastname_vchr"].ToString();
                EmpVO.strEmpNO = dtValues.Rows[0]["EMPNO_CHR"].ToString();
                EmpVO.strPYCode = dtValues.Rows[0]["PYCODE_CHR"].ToString();
                EmpVO.strIsExpert = dtValues.Rows[0]["ISEXPERT_CHR"].ToString();
                EmpVO.strIsExternalExpert = dtValues.Rows[0]["ISEXTERNALEXPERT_CHR"].ToString();
                EmpVO.strOfficePhone = dtValues.Rows[0]["ORDERSTR"].ToString().Trim();//用表示排序号

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

        #region (体检)获取体检人收费项目
        /// <summary>
        /// (体检)获取体检人收费项目
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPEChargeItem(string CardNo, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select   d.groupcode_chr, f.itemcode_vchr, f.itemid_chr, r.regno_chr
                                    from t_pe_patientitem a, 
                                         t_pe_itemgroup d,
                                         t_pe_itemgroup_entry e,
                                         t_pe_item f,
                                         t_pe_register r,
                                         t_bse_patientcard p
                                   where a.itemcode_vchr=d.groupcode_chr
                                    and  d.groupcode_chr = e.groupcode_chr
                                     and e.itemid_chr = f.itemid_chr
                                     and d.instflag_chr = '1'
                                     and f.instflag_chr = '1'
                                     and f.chargeflag_chr = '1'
                                     and a.type_int = 2
                                     and r.regno_chr = a.regno_chr
                                     and r.patientid_chr = p.patientid_chr
                                     and r.chargeflag_int = 0
                                     and (p.status_int = 1 or p.status_int = 3)
                                     and p.patientcardid_chr = ?
                                order by d.groupcode_chr, f.itemcode_vchr ";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = CardNo;

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

        #region (体检)根据体检收费项目ID获取相关收费信息
        /// <summary>
        /// (体检)根据体检收费项目ID获取相关收费信息
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="PatType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPEChargeItemInfo(string ItemID, string PatType, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select distinct a.itemid_chr, a.itemname_vchr, a.itemspec_vchr,
                                    a.itemengname_vchr, a.itemcode_vchr as tempitemcode,
                                    a.insuranceid_chr, a.itemopunit_chr, a.itemprice_mny,
                                    a.itemopinvtype_chr, a.itemcatid_chr, a.selfdefine_int,
                                    a.itemcode_vchr, a.itemopcalctype_chr, a.dosage_dec,
                                    a.dosageunit_chr, f.precent_dec, 1 as itemnum,
                                    b.noqtyflag_int, a.itemipunit_chr,
                                    round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                    a.opchargeflg_int, a.itemunit_chr as unit
                               from t_bse_chargeitem a,
                                    t_bse_medicine b,
                                    (select itemid_chr, precent_dec 
                                       from t_aid_inschargeitem
                                      where copayid_chr = ?) f
                              where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
                                and a.itemid_chr = f.itemid_chr(+)
                                and a.ifstop_int = 0
                                and a.itemid_chr = ?
                           order by a.itemcode_vchr";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = PatType;
                ParamArr[1].Value = ItemID;

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

        #region (体检)获取体检人检验申请单元
        /// <summary>
        /// (体检)获取体检人检验申请单元
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPELisItem(string CardNo, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select d.lisappgroupid_vchr, d.lissampleid_vchr, d.groupcode_chr,
                                       d.groupname_vchr, d.price_dec,r.regno_chr
                                  from t_pe_patientitem a, 
                                       t_pe_itemgroup d,
                                       t_pe_register r,
                                       t_bse_patientcard p
                                 where a.itemcode_vchr = d.groupcode_chr
                                   and d.instflag_chr = '1'
                                   and a.type_int = 2
                                   and d.lisappgroupid_vchr is not null
                                   and r.regno_chr = a.regno_chr
                                   and r.patientid_chr = p.patientid_chr
                                   and r.chargeflag_int = 0
                                   and (p.status_int = 1 or p.status_int = 3)
                                   and p.patientcardid_chr = ? ";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = CardNo;

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

        #region (体检)更新体检收费标志
        /// <summary>
        /// (体检)更新体检收费标志
        /// </summary>
        /// <param name="RegNoArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdatePEChargeFlag(ArrayList RegNoArr, ArrayList objAttach, System.Collections.Generic.List<clsPERegGroup_VO> glstRegGroup)
        {
            long lngRes = 0;
            long lngAffects = 0;
            string SQL = "";
            string strSub = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                for (int i = 0; i < RegNoArr.Count; i++)
                {
                    strSub += " a.regno_chr = '" + RegNoArr[i].ToString() + "' or";
                }
                strSub = strSub.Substring(0, strSub.Length - 2);

                SQL = @"update t_pe_register a
                           set a.chargeflag_int = 1
                         where " + strSub;

                lngRes = objHRPSvc.DoExcute(SQL);

                for (int i = 0; i < objAttach.Count; i++)
                {
                    clsATTACHRELATION_VO obj = objAttach[i] as clsATTACHRELATION_VO;

                    SQL = @"insert into t_opr_attachrelation
                                        (attarelaid_chr, sysfrom_int, attachtype_int, sourceitemid_vchr,
                                         attachid_vchr, urgency_int, status_int
                                        )
                                 values (seq_attachrelation.nextval, ?, ?, ?,
                                         ?, ?, 1
                                        )";

                    objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                    ParamArr[0].Value = obj.strSYSFROM_INT;
                    ParamArr[1].Value = obj.strATTACHTYPE_INT;
                    ParamArr[2].Value = obj.strSOURCEITEMID_VCHR;
                    ParamArr[3].Value = obj.strATTACHID_VCHR;
                    ParamArr[4].Value = obj.strURGENCY_INT;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

                SQL = @"update t_pe_patientitem
                           set status_int = 2
                         where regno_chr = ?
                           and itemcode_vchr = ?
                           and modfytime_dat = (select ta.regdate_dat
                                                  from t_pe_register ta
                                                 where ta.regno_chr = ?) ";
                DbType[] dbtypes = new DbType[3] { DbType.String, DbType.String, DbType.String };
                object[][] objValues = new object[3][];
                for (int i1 = 0; i1 < objValues.Length; i1++)
                {
                    objValues[i1] = new object[glstRegGroup.Count];
                }

                clsPERegGroup_VO objTmp;
                for (int i1 = 0; i1 < glstRegGroup.Count; i1++)
                {
                    objTmp = glstRegGroup[i1];
                    int n = 0;
                    objValues[n++][i1] = objTmp.RegNo;
                    objValues[n++][i1] = objTmp.Itemcode;
                    objValues[n++][i1] = objTmp.RegNo;
                }
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbtypes);
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
        #region 根据收费项目ID查出刻收费项目的收费比例
        /// <summary>
        /// 根据收费项目ID查出刻收费项目的收费比例
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="strPatientTypeID"></param>
        /// <returns></returns>
        public decimal m_mthGetDiscountByID(string ID, string strPatientTypeID)
        {
            decimal tempDiscount = 100;
            long lngRes = 0;
            DataTable dtbResult = null;
            string strSQL = @"select precent_dec
                              from t_aid_inschargeitem
                             where itemid_chr = ? and copayid_chr = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = ID;
                objParamArr[1].Value = strPatientTypeID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    //tempDiscount = m_mthConvertObjToDecimal(dtbResult.Rows[0]["PRECENT_DEC"]);
                    string strDiscount = dtbResult.Rows[0]["PRECENT_DEC"].ToString().Trim();
                    if (strDiscount != string.Empty)
                    {
                        tempDiscount = Convert.ToDecimal(strDiscount);
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objParamArr = null;
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return tempDiscount;
        }
        #endregion

        #region 根据发票号获取当日序号
        /// <summary>
        /// 根据发票号获取当日序号
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <returns></returns>
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
        #region 根据发票号产生发收费项目明细
        /// <summary>
        /// 根据发票号产生发收费项目明细,然后填充listView
        /// </summary>
        /// <param name="ID">发票号</param>
        /// <param name="lv">listView</param>
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
        #region 根据内部序列号取得发票信息
        /// <summary>
        /// 根据内部序列号取得发票信息
        /// </summary>
        /// <param name="ID">内部序列号</param>
        /// <param name="obj"></param>
        /// <returns>成功1 ,0</returns>
        [AutoComplete]
        public long m_mthGetInvoiceInfoByID(string ID, string pstatus, out DataTable dtbResult, out DataTable m_objTempTable, out DataTable dtDept)
        {

            long lngRes = 0;
            string status = "1";
            dtbResult = null;
            m_objTempTable = null;
            dtDept = null;
            string strSQL = @"select a.invoiceno_vchr,
                                   a.outpatrecipeid_chr,
                                   a.invdate_dat,
                                   a.acctsum_mny,
                                   a.sbsum_mny,
                                   a.opremp_chr,
                                   a.recordemp_chr,
                                   a.recorddate_dat,
                                   a.status_int,
                                   a.seqid_chr,
                                   a.balanceemp_chr,
                                   a.balance_dat,
                                   a.balanceflag_int,
                                   a.totalsum_mny,
                                   a.paytype_int,
                                   a.patientid_chr,
                                   a.patientname_chr,
                                   a.deptid_chr,
                                   a.deptname_chr,
                                   a.doctorid_chr,
                                   a.doctorname_chr,
                                   a.confirmemp_chr,
                                   a.paytypeid_chr,
                                   a.internalflag_int,
                                   a.baseseqid_chr,
                                   a.groupid_chr,
                                   a.confirmdeptid_chr,
                                   a.split_int,
                                   a.regno_chr,
                                   a.chargedeptid_chr,
                                   b.paytypename_vchr,
                                   c.empno_chr a,
                                   d.empno_chr b,
                                   e.patientcardid_chr,
                                   f.shortno_chr confdept,
                                   g.empno_chr confemp,
                                   c.lastname_vchr,
                                   h.lastname_vchr patientname,
                                   h.sex_chr,
                                   h.insuranceid_vchr,
                                   '0' bcyltczf1,
                                   '0' bcyltczf2,
                                   '0' bcyltczf3,
                                   '0' bcyltczf4,
                                   '0' qtzhifu,
                                   '0' ybjzfpje,
                                   a.totaldiffcost_mny,
                                   r.repprninvono_vchr
                              from t_opr_outpatientrecipeinv a
                              left join t_bse_patientpaytype b
                                on a.paytypeid_chr = b.paytypeid_chr
                              left join t_bse_employee c
                                on a.recordemp_chr = c.empid_chr
                              left join t_bse_employee d
                                on a.doctorid_chr = d.empid_chr
                              left join t_bse_patientcard e
                                on a.patientid_chr = e.patientid_chr
                               and (e.status_int = 1 or e.status_int = 3)
                              left join t_bse_deptdesc f
                                on a.confirmdeptid_chr = f.deptid_chr
                              left join t_bse_employee g
                                on a.confirmemp_chr = g.empid_chr
                              left join t_bse_patient h
                                on e.patientid_chr = h.patientid_chr
                              left join t_opr_invoicerepeatprint r
                                on a.seqid_chr = r.seqid_chr
                               and r.type_chr = '1'
                             where a.seqid_chr = '{0}'";
            strSQL = string.Format(strSQL, ID);

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult != null)
                {
                    if (dtbResult.Rows.Count > 0)
                    {
                        DataTable dtTemp = new DataTable();
                        strSQL = @"select t.bcyltczf1,t.bcyltczf2,t.bcyltczf3,t.bcyltczf4,t.qtzhifu,t.ybjzfpje from t_ins_chargemz_csyb t where t.cfh = '" + dtbResult.Rows[0]["outpatrecipeid_chr"].ToString().Trim() + "'";
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtTemp);
                        if (lngRes > 0 && dtTemp.Rows.Count > 0)
                        {
                            dtbResult.Rows[0]["bcyltczf1"] = dtTemp.Rows[0]["bcyltczf1"].ToString();
                            dtbResult.Rows[0]["bcyltczf2"] = dtTemp.Rows[0]["bcyltczf2"].ToString();
                            dtbResult.Rows[0]["bcyltczf3"] = dtTemp.Rows[0]["bcyltczf3"].ToString();
                            dtbResult.Rows[0]["bcyltczf4"] = dtTemp.Rows[0]["bcyltczf4"].ToString();
                            dtbResult.Rows[0]["qtzhifu"] = dtTemp.Rows[0]["qtzhifu"].ToString();
                            dtbResult.Rows[0]["ybjzfpje"] = dtTemp.Rows[0]["ybjzfpje"].ToString();
                        }
                    }
                }

                strSQL = "select a.setstatus_int from t_sys_setting a where a.setid_chr='9009'";
                objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTempTable);

                //if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                //{
                //    status = dtbResult.Rows[0]["STATUS_INT"].ToString().Trim();
                //    obj.m_strDateOfReception = Convert.ToDateTime(dtbResult.Rows[0]["INVDATE_DAT"].ToString()).ToString("yyyy-MM-dd");
                //    obj.m_decChargeUpCost = Convert.ToDecimal(dtbResult.Rows[0]["ACCTSUM_MNY"].ToString());
                //    obj.m_decPersonCost = Convert.ToDecimal(dtbResult.Rows[0]["SBSUM_MNY"].ToString());
                //    if (status == "2")
                //    {
                //        obj.m_decTotalCost = Convert.ToDecimal(dtbResult.Rows[0]["TOTALSUM_MNY"].ToString()) * -1;
                //    }
                //    else
                //    {
                //        obj.m_decTotalCost = Convert.ToDecimal(dtbResult.Rows[0]["TOTALSUM_MNY"].ToString());
                //    }

                //    if (pstatus == "1" || pstatus == "2")
                //    {
                //        obj.m_decChargeUpCost = Convert.ToDecimal(dtbResult.Rows[0]["ACCTSUM_MNY"].ToString()) * -1;
                //        obj.m_decPersonCost = Convert.ToDecimal(dtbResult.Rows[0]["SBSUM_MNY"].ToString()) * -1;
                //    }
                //    if (m_objTempTable.Rows.Count > 0)
                //    {
                //        if (m_objTempTable.Rows[0][0].ToString().Trim() == "1")
                //        {
                //            obj.m_strCollector = dtbResult.Rows[0]["A"].ToString() + "(" + dtbResult.Rows[0]["lastname_vchr"].ToString() + ")";
                //        }
                //        else
                //        {
                //            obj.m_strCollector = dtbResult.Rows[0]["A"].ToString();
                //        }
                //    }
                //    else
                //    {
                //        obj.m_strCollector = dtbResult.Rows[0]["A"].ToString();
                //    }
                //    obj.m_strAssessor = "(" + dtbResult.Rows[0]["confdept"].ToString().Trim() + ")" + dtbResult.Rows[0]["confemp"].ToString().Trim();
                //    obj.m_strPatientName = dtbResult.Rows[0]["PATIENTNAME_CHR"].ToString();
                //    obj.m_strHospitalName = this.HopitalName;
                //    obj.m_strDocNo = dtbResult.Rows[0]["B"].ToString();
                //    obj.m_strInvoiceNO = dtbResult.Rows[0]["INVOICENO_VCHR"].ToString();
                //    obj.m_strPatientTypeName = dtbResult.Rows[0]["PAYTYPENAME_VCHR"].ToString();
                //    obj.m_strSeriesNumber = dtbResult.Rows[0]["SEQID_CHR"].ToString();
                //    obj.m_strPatientCardID = dtbResult.Rows[0]["patientcardid_chr"].ToString();//卡号
                //    if (dtbResult.Rows[0]["PAYTYPE_INT"].ToString().Trim() == "0")
                //    {
                //        obj.m_strBalanceMode = "现金";
                //    }
                //    else if (dtbResult.Rows[0]["PAYTYPE_INT"].ToString().Trim() == "1")
                //    {
                //        obj.m_strBalanceMode = "银行卡";
                //    }
                //    else if (dtbResult.Rows[0]["PAYTYPE_INT"].ToString().Trim() == "2")
                //    {
                //        obj.m_strBalanceMode = "支票";
                //    }
                //    else if (dtbResult.Rows[0]["PAYTYPE_INT"].ToString().Trim() == "3")
                //    {
                //        obj.m_strBalanceMode = "IC卡";
                //    }
                //}
                //else
                //{
                //    return -1;
                //}
                dtbResult.Dispose();

                strSQL = @"SELECT ITEMCATID_CHR, TOLFEE_MNY as TOLFEE_MNY FROM T_OPR_OUTPATIENTRECIPEINVDE WHERE SEQID_CHR = '" + ID.Trim() + "'";
                if (pstatus == "1" || pstatus == "2")
                {
                    strSQL = @"SELECT ITEMCATID_CHR, -TOLFEE_MNY as TOLFEE_MNY FROM T_OPR_OUTPATIENTRECIPEINVDE WHERE SEQID_CHR = '" + ID.Trim() + "'";
                }
                long ret = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtDept);
                objHRPSvc.Dispose();
                //if (ret > 0 && dtbResult != null)
                //{
                //    for (int i = 0; i < dtbResult.Rows.Count; i++)
                //    {
                //        string cat = dtbResult.Rows[i]["ITEMCATID_CHR"].ToString();
                //        decimal val = Convert.ToDecimal(dtbResult.Rows[i]["TOLFEE_MNY"].ToString());

                //        if (cat == "0001")
                //        {
                //            obj.m_decXyf += val;
                //        }
                //        else if (cat == "0002")
                //        {
                //            obj.m_decZchyf += val;
                //        }
                //        else if (cat == "0003")
                //        {
                //            obj.m_decZcayf += val;
                //        }
                //        else if (cat == "0004")
                //        {
                //            obj.m_decZjf += val;
                //        }
                //        else if (cat == "0005")
                //        {
                //            obj.m_decLgcwf += val;
                //        }
                //        else if (cat == "0006")
                //        {
                //            obj.m_decCTf += val;
                //        }
                //        else if (cat == "0007")
                //        {
                //            obj.m_decMRIf += val;
                //        }
                //        else if (cat == "0008")
                //        {
                //            obj.m_decSxf += val;
                //        }
                //        else if (cat == "0009")
                //        {
                //            obj.m_decSyf += val;
                //        }
                //        else if (cat == "0010")
                //        {
                //            obj.m_decSsf += val;
                //        }
                //        else if (cat == "0011")
                //        {
                //            obj.m_decQtf += val;
                //        }
                //        else if (cat == "0012")
                //        {
                //            obj.m_decTxfwf += val;
                //        }
                //        else if (cat == "0013")
                //        {
                //            obj.m_decClf += val;
                //        }
                //        else if (cat == "0014")
                //        {
                //            //B超费归属检查费
                //            //obj.m_decBCf += val;
                //            obj.m_decJcf += val;
                //        }
                //        else if (cat == "0015")
                //        {
                //            obj.m_decGHf += val;
                //        }
                //        else if (cat == "0016")
                //        {
                //            obj.m_decPgjf += val;
                //        }
                //        else if (cat == "0017")
                //        {
                //            obj.m_decJcf += val;
                //        }
                //        else if (cat == "0018")
                //        {
                //            obj.m_decJyf += val;
                //        }
                //        else if (cat == "0019")
                //        {
                //            obj.m_decZlf += val;
                //        }
                //        else if (cat == "0020")
                //        {
                //            obj.m_decHlf += val;
                //        }
                //        else if (cat == "0021")
                //        {
                //            obj.m_decSngjf += val;
                //        }
                //        else
                //        {
                //            obj.m_decQtf += val;
                //        }
                //    }
                //}
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

        #region 获取项目住院发票分类
        /// <summary>
        /// 获取项目住院发票分类
        /// </summary>
        /// <param name="p_strItemID"></param>
        /// <param name="p_hasCat"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetIPInvoCat(string p_strItemID, out Hashtable p_hasCat)
        {
            long lngRes = 0;

            p_hasCat = new Hashtable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                string SQL = @"select t.itemid_chr, t.itemipinvtype_chr from t_bse_chargeitem t where t.itemid_chr in (" + p_strItemID + ")";

                DataTable dt = new DataTable();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (lngRes > 0)
                {
                    string strItemID = string.Empty;
                    DataRow dr = null;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];

                        strItemID = dr["itemid_chr"].ToString();

                        if (!p_hasCat.ContainsKey(strItemID))
                        {
                            p_hasCat.Add(strItemID, dr["itemipinvtype_chr"].ToString().Substring(2, 2));
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

        #region 更新医保结算号
        /// <summary>
        /// 更新医保结算号
        /// </summary>
        /// <param name="p_strRecipeID"></param>
        /// <param name="p_strChargeNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateYBChargeNo(string p_strRecipeID, string p_strChargeNo)
        {
            long lngRes = 0, lngAffects = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @"update t_opr_reciperelation set billno_chr = ? where outpatrecipeid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = p_strChargeNo;
                ParamArr[1].Value = p_strRecipeID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
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

        #region 处理选择性交费 先诊疗后结算
        /// <summary>
        /// 处理选择性交费
        /// </summary>
        /// <param name="p_dicItemID"></param>
        /// <param name="p_oprVO"></param>
        /// <param name="p_strOriginalRepiceId"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectFeeDispose(Dictionary<string, List<string>> p_dicItemID, clsOutPatientRecipe_VO p_oprVO, string p_strOriginalRepiceId)
        {
            /*
            * 1.生成一条新的主处方表记录,并把原来的处方表的pstauts_int状态改变 
            * 2.插入数据进入6个表中,如果有的话
            * 3.update检验检查的申请单，如果有的话,
            * 4.药品的如何处理
            * 5.新建一个表，记录本次修改信息的记录
            * 6.门诊处手术申请单没有发送（为实现还是...）
            * *
            */

            long lngRes = -1;
            long lngAffects = 0;
            try
            {
                #region 保存处方主表
                com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc objEmployeeSvc = new com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc();
                string strGroupID = "";
                DataTable tempDt;
                string strSQL = "";
                DataTable dt = new DataTable();
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                #region 记录选择性交费操作的主表

                clsSelectFeeDispose_VO selFeeDisposeVO = new clsSelectFeeDispose_VO();
                selFeeDisposeVO.m_strModifyEmpId = p_oprVO.m_strOperatorID;
                selFeeDisposeVO.m_strOutpatRecipeIdNew = p_oprVO.m_strOutpatRecipeID;
                selFeeDisposeVO.m_strOutpatRecipeIdOld = p_strOriginalRepiceId;
                selFeeDisposeVO.m_dtmModifyDate = DateTime.Now;

                strSQL = @"select to_char( seq_recipeid.nextval ) as recordid from dual";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    selFeeDisposeVO.m_strRecordId = dt.Rows[0]["recordid"].ToString();
                }

                lngRes = m_lngRecordSelectFeeDispose(selFeeDisposeVO);

                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
                dt = new DataTable();
                #endregion

                IDataParameter[] ParamArr = null;

                lngRes = objEmployeeSvc.m_lngGetGroupEmp(p_oprVO.m_strDoctorID, out tempDt);
                if (lngRes > 0 && tempDt.Rows.Count > 0)
                {
                    strGroupID = tempDt.Rows[0]["groupid_chr"].ToString();
                }
                this.m_mthDeleteRecipeDetail(p_oprVO.m_strOutpatRecipeID.Trim());

                //处方号关联表                   
                strSQL = @"select seqid, outpatrecipeid_chr from t_opr_reciperelation where seqid = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_oprVO.m_strOutpatRecipeID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (dt.Rows.Count > 0)
                {
                    strSQL = @"update t_opr_reciperelation set mcflag_int = 1 where seqid = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_oprVO.m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                else
                {
                    strSQL = @"insert into t_opr_reciperelation(seqid,outpatrecipeid_chr) values(?, ?)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = p_oprVO.m_strOutpatRecipeID;
                    ParamArr[1].Value = p_oprVO.m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }

                //处方主表
                //                strSQL = @"insert into t_opr_outpatientrecipe(outpatrecipeid_chr,patientid_chr,createdate_dat,registerid_chr,diagdr_chr,diagdept_chr,recordemp_chr,
                //                                                                  recorddate_dat,pstauts_int,paytypeid_chr,recipeflag_int,groupid_chr,casehisid_chr,type_int, createtype_int, deptmed_int) values(
                //                                                                  ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, to_date(?,'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, ?, ?, ?, ?)";

                strSQL = @"insert into t_opr_outpatientrecipe
                              (outpatrecipeid_chr,
                               patientid_chr,
                               createdate_dat,
                               registerid_chr,
                               diagdr_chr,
                               diagdept_chr,
                               recordemp_chr,
                               recorddate_dat,
                               pstauts_int,
                               recipeflag_int,
                               outpatrecipeno_vchr,
                               paytypeid_chr,
                               casehisid_chr,
                               groupid_chr,
                               type_int,
                               confirm_int,
                               confirmdesc_vchr,
                               createtype_int,
                               deptmed_int,
                               archtakeflag_int,
                               printed_int,
                               chargedeptid_chr,
                               isgreen_int)
                              select '" + p_oprVO.m_strOutpatRecipeID + @"',
                                     patientid_chr,
                                     createdate_dat,
                                     registerid_chr,
                                     diagdr_chr,
                                     diagdept_chr,
                                     recordemp_chr,
                                     to_date(?,'yyyy-mm-dd hh24:mi:ss'),
                                     1,
                                     recipeflag_int,
                                     outpatrecipeno_vchr,
                                     paytypeid_chr,
                                     casehisid_chr,
                                     groupid_chr,
                                     type_int,
                                     confirm_int,
                                     confirmdesc_vchr,
                                     createtype_int,
                                     deptmed_int,
                                     archtakeflag_int,
                                     printed_int,
                                     chargedeptid_chr,
                                     0
                                from t_opr_outpatientrecipe t
                                where t.outpatrecipeid_chr = ?"; //pstauts_int = 1收费处创建

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = DateTime.Now.ToString();
                ParamArr[1].Value = p_strOriginalRepiceId;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                #endregion

                #region 改变原来的主主方信息

                strSQL = @"update t_opr_outpatientrecipe t
                               set t.pstauts_int = 5
                             where t.outpatrecipeid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strOriginalRepiceId;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                //记录修改操作信息
                selFeeDisposeVO.m_strModifyTable = "t_opr_outpatientrecipe";
                selFeeDisposeVO.m_strOperationExplain = "update处方状态为5";

                lngRes = m_lngRecordSelectFeeDisposeDetail(selFeeDisposeVO);
                #endregion

                #region 保存明细

                List<string> lstWMItemId = p_dicItemID["wm"];
                List<string> lstCMItemId = p_dicItemID["cm"];
                List<string> lstCheckItemId = p_dicItemID["check"];
                List<string> lstTestItemId = p_dicItemID["test"];
                List<string> lstOpsItemId = p_dicItemID["ops"];
                List<string> lstOthItemId = p_dicItemID["oth"];
                //诊疗项目id
                List<string> lstOrderDicItemId = p_dicItemID["orderdic"];
                //西药
                #region
                StringBuilder sbSubSql = new StringBuilder(4 * lstWMItemId.Count);
                if (lstWMItemId != null && lstWMItemId.Count > 0)
                {
                    foreach (string strTemp in lstWMItemId)
                    {
                        if (sbSubSql.Length > 0)
                        {
                            sbSubSql.Append(",");
                        }
                        sbSubSql.Append("'").Append(strTemp).Append("'");
                    }

                    strSQL = @"insert into t_opr_outpatientpwmrecipede
                              (outpatrecipeid_chr,
                               rowno_chr,
                               itemid_chr,
                               unitid_chr,
                               usageid_chr,
                               tolqty_dec,
                               unitprice_mny,
                               tolprice_mny,
                               outpatrecipedeid_chr,
                               days_int,
                               qty_dec,
                               discount_dec,
                               freqid_chr,
                               treat_dat,
                               treatemp_chr,
                               return_dat,
                               returnemp_chr,
                               medstoreid_chr,
                               windowid_chr,
                               hypetest_int,
                               desc_vchr,
                               usageparentid_vchr,
                               attachparentid_vchr,
                               itemspec_vchr,
                               dosage_dec,
                               dosageunit_chr,
                               attachitembasenum_dec,
                               usageitembasenum_dec,
                               itemname_vchr,
                               deptmed_int,
                               rowno_vchr2)
                            select
                               '" + p_oprVO.m_strOutpatRecipeID + @"',
                               rowno_chr,
                               itemid_chr,
                               unitid_chr,
                               usageid_chr,
                               tolqty_dec,
                               unitprice_mny,
                               tolprice_mny,
                               to_char(seq_recipeid.nextval),
                               days_int,
                               qty_dec,
                               discount_dec,
                               freqid_chr,
                               treat_dat,
                               treatemp_chr,
                               return_dat,
                               returnemp_chr,
                               medstoreid_chr,
                               windowid_chr,
                               hypetest_int,
                               desc_vchr,
                               usageparentid_vchr,
                               attachparentid_vchr,
                               itemspec_vchr,
                               dosage_dec,
                               dosageunit_chr,
                               attachitembasenum_dec,
                               usageitembasenum_dec,
                               itemname_vchr,
                               deptmed_int,
                               rowno_vchr2
                               from t_opr_outpatientpwmrecipede t 
                            where t.outpatrecipeid_chr = ? and t.itemid_chr in (" + sbSubSql.ToString() + ")";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                #endregion

                //中药
                #region
                if (lstCMItemId != null && lstCMItemId.Count > 0)
                {
                    sbSubSql = null;
                    sbSubSql = new StringBuilder(4 * lstCMItemId.Count);

                    foreach (string strTmp in lstCMItemId)
                    {
                        if (sbSubSql.Length > 0)
                        {
                            sbSubSql.Append(",");
                        }
                        sbSubSql.Append("'").Append(strTmp).Append("'");
                    }

                    strSQL = @"insert into t_opr_outpatientcmrecipede
                              (outpatrecipeid_chr,
                               rowno_chr,
                               itemid_chr,
                               unitid_chr,
                               usageid_chr,
                               qty_dec,
                               unitprice_mny,
                               tolprice_mny,
                               outpatrecipedeid_chr,
                               discount_dec,
                               treat_dat,
                               treatemp_chr,
                               return_dat,
                               returnemp_chr,
                               times_int,
                               min_qty_dec,
                               medstoreid_chr,
                               windowid_chr,
                               sumusage_vchr,
                               usageparentid_vchr,
                               attachparentid_vchr,
                               attachitembasenum_dec,
                               usageitembasenum_dec,
                               itemname_vchr,
                               itemspec_vchr,
                               deptmed_int,
                               usagedetail_vchr,
                               rowno_vchr2)
                              select '" + p_oprVO.m_strOutpatRecipeID + @"',
                                     rowno_chr,
                                     itemid_chr,
                                     unitid_chr,
                                     usageid_chr,
                                     qty_dec,
                                     unitprice_mny,
                                     tolprice_mny,
                                     to_char(seq_recipeid.nextval),
                                     discount_dec,
                                     treat_dat,
                                     treatemp_chr,
                                     return_dat,
                                     returnemp_chr,
                                     times_int,
                                     min_qty_dec,
                                     medstoreid_chr,
                                     windowid_chr,
                                     sumusage_vchr,
                                     usageparentid_vchr,
                                     attachparentid_vchr,
                                     attachitembasenum_dec,
                                     usageitembasenum_dec,
                                     itemname_vchr,
                                     itemspec_vchr,
                                     deptmed_int,
                                     usagedetail_vchr,
                                     rowno_vchr2
                                from t_opr_outpatientcmrecipede t
                               where t.outpatrecipeid_chr = ?
                                 and t.itemid_chr in (" + sbSubSql.ToString() + ")";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                #endregion

                //检验
                #region
                if (lstCheckItemId != null && lstCheckItemId.Count > 0)
                {
                    sbSubSql = null;
                    sbSubSql = new StringBuilder(4 * lstCheckItemId.Count);

                    foreach (string strTmp in lstCheckItemId)
                    {
                        if (sbSubSql.Length > 0)
                        {
                            sbSubSql.Append(",");
                        }
                        sbSubSql.Append("'").Append(strTmp).Append("'");
                    }

                    strSQL = @"insert into t_opr_outpatientchkrecipede
                              (outpatrecipeid_chr,
                               rowno_chr,
                               itemid_chr,
                               price_mny,
                               outpatrecipedeid_chr,
                               oprdept_chr,
                               discount_dec,
                               tolprice_mny,
                               qty_dec,
                               attachid_vchr,
                               sampleid_vchr,
                               usageparentid_vchr,
                               attachparentid_vchr,
                               medstoreid_chr,
                               windowid_chr,
                               quickflag_int,
                               attachitembasenum_dec,
                               usageitembasenum_dec,
                               itemname_vchr,
                               itemspec_vchr,
                               itemunit_vchr,
                               itemusagedetail_vchr,
                               deptmed_int,
                               orderid_vchr,
                               orderbasenum_dec,
                               orderid_int)
                              select '" + p_oprVO.m_strOutpatRecipeID + @"',
                                     rowno_chr,
                                     itemid_chr,
                                     price_mny,
                                     to_char(seq_recipeid.nextval),
                                     oprdept_chr,
                                     discount_dec,
                                     tolprice_mny,
                                     qty_dec,
                                     attachid_vchr,
                                     sampleid_vchr,
                                     usageparentid_vchr,
                                     attachparentid_vchr,
                                     medstoreid_chr,
                                     windowid_chr,
                                     quickflag_int,
                                     attachitembasenum_dec,
                                     usageitembasenum_dec,
                                     itemname_vchr,
                                     itemspec_vchr,
                                     itemunit_vchr,
                                     itemusagedetail_vchr,
                                     deptmed_int,
                                     orderid_vchr,
                                     orderbasenum_dec,
                                     orderid_int
                                from t_opr_outpatientchkrecipede t
                               where t.outpatrecipeid_chr = ?
                                 and t.itemid_chr in (" + sbSubSql.ToString() + ")";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                #endregion

                //检查
                #region
                if (lstTestItemId != null && lstTestItemId.Count > 0)
                {
                    sbSubSql = null;
                    sbSubSql = new StringBuilder(4 * lstTestItemId.Count);

                    foreach (string strTmp in lstTestItemId)
                    {
                        if (sbSubSql.Length > 0)
                        {
                            sbSubSql.Append(",");
                        }
                        sbSubSql.Append("'").Append(strTmp).Append("'");
                    }

                    strSQL = @"insert into t_opr_outpatienttestrecipede
                              (outpatrecipeid_chr,
                               rowno_chr,
                               itemid_chr,
                               price_mny,
                               outpatrecipedeid_chr,
                               oprdept_chr,
                               discount_dec,
                               tolprice_mny,
                               qty_dec,
                               attachid_vchr,
                               checkpartid_vchr,
                               usageparentid_vchr,
                               attachparentid_vchr,
                               medstoreid_chr,
                               windowid_chr,
                               attachitembasenum_dec,
                               usageitembasenum_dec,
                               itemname_vchr,
                               itemspec_vchr,
                               itemunit_vchr,
                               itemusagedetail_vchr,
                               deptmed_int,
                               usageid_chr,
                               orderid_vchr,
                               orderbasenum_dec,
                               orderid_int)
                              select '" + p_oprVO.m_strOutpatRecipeID + @"',
                                     rowno_chr,
                                     itemid_chr,
                                     price_mny,
                                     to_char(seq_recipeid.nextval),
                                     oprdept_chr,
                                     discount_dec,
                                     tolprice_mny,
                                     qty_dec,
                                     attachid_vchr,
                                     checkpartid_vchr,
                                     usageparentid_vchr,
                                     attachparentid_vchr,
                                     medstoreid_chr,
                                     windowid_chr,
                                     attachitembasenum_dec,
                                     usageitembasenum_dec,
                                     itemname_vchr,
                                     itemspec_vchr,
                                     itemunit_vchr,
                                     itemusagedetail_vchr,
                                     deptmed_int,
                                     usageid_chr,
                                     orderid_vchr,
                                     orderbasenum_dec,
                                     orderid_int
                                from t_opr_outpatienttestrecipede t
                               where t.outpatrecipeid_chr = ?
                                 and t.itemid_chr in (" + sbSubSql.ToString() + ")";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                #endregion

                //手术
                #region
                if (lstOpsItemId != null && lstOpsItemId.Count > 0)
                {
                    sbSubSql = null;
                    sbSubSql = new StringBuilder(4 * lstOpsItemId.Count);

                    foreach (string strTmp in lstOpsItemId)
                    {
                        if (sbSubSql.Length > 0)
                        {
                            sbSubSql.Append(",");
                        }
                        sbSubSql.Append("'").Append(strTmp).Append("'");
                    }

                    strSQL = @"insert into t_opr_outpatientopsrecipede
                              (outpatrecipeid_chr,
                               rowno_chr,
                               itemid_chr,
                               price_mny,
                               outpatrecipedeid_chr,
                               oprdept_chr,
                               discount_dec,
                               tolprice_mny,
                               qty_dec,
                               attachid_vchr,
                               usageparentid_vchr,
                               attachparentid_vchr,
                               medstoreid_chr,
                               windowid_chr,
                               attachitembasenum_dec,
                               usageitembasenum_dec,
                               itemname_vchr,
                               itemspec_vchr,
                               itemunit_vchr,
                               itemusagedetail_vchr,
                               deptmed_int,
                               usageid_chr,
                               orderid_vchr,
                               orderbasenum_dec,
                               orderid_int)
                              select '" + p_oprVO.m_strOutpatRecipeID + @"',
                                     rowno_chr,
                                     itemid_chr,
                                     price_mny,
                                     to_char(seq_recipeid.nextval),
                                     oprdept_chr,
                                     discount_dec,
                                     tolprice_mny,
                                     qty_dec,
                                     attachid_vchr,
                                     usageparentid_vchr,
                                     attachparentid_vchr,
                                     medstoreid_chr,
                                     windowid_chr,
                                     attachitembasenum_dec,
                                     usageitembasenum_dec,
                                     itemname_vchr,
                                     itemspec_vchr,
                                     itemunit_vchr,
                                     itemusagedetail_vchr,
                                     deptmed_int,
                                     usageid_chr,
                                     orderid_vchr,
                                     orderbasenum_dec,
                                     orderid_int
                                from t_opr_outpatientopsrecipede t
                               where t.outpatrecipeid_chr = ?
                                 and t.itemid_chr in (" + sbSubSql + ")";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                #endregion

                // 其他
                #region

                if (lstOthItemId != null && lstOthItemId.Count > 0)
                {
                    sbSubSql = null;
                    sbSubSql = new StringBuilder(4 * lstOthItemId.Count);

                    foreach (string strTmp in lstOthItemId)
                    {
                        if (sbSubSql.Length > 0)
                        {
                            sbSubSql.Append(",");
                        }
                        sbSubSql.Append("'").Append(strTmp).Append("'");
                    }

                    strSQL = @"insert into t_opr_outpatientothrecipede
                              (outpatrecipeid_chr,
                               rowno_chr,
                               itemid_chr,
                               unitid_chr,
                               qty_dec,
                               unitprice_mny,
                               tolprice_mny,
                               outpatrecipedeid_chr,
                               discount_dec,
                               attachid_vchr,
                               medstoreid_chr,
                               windowid_chr,
                               usageparentid_vchr,
                               attachparentid_vchr,
                               attachitembasenum_dec,
                               usageitembasenum_dec,
                               itemname_vchr,
                               itemspec_vchr,
                               itemunit_vchr,
                               itemusagedetail_vchr,
                               deptmed_int)
                              select '" + p_oprVO.m_strOutpatRecipeID + @"',
                                     rowno_chr,
                                     itemid_chr,
                                     unitid_chr,
                                     qty_dec,
                                     unitprice_mny,
                                     tolprice_mny,
                                     to_char(seq_recipeid.nextval),
                                     discount_dec,
                                     attachid_vchr,
                                     medstoreid_chr,
                                     windowid_chr,
                                     usageparentid_vchr,
                                     attachparentid_vchr,
                                     attachitembasenum_dec,
                                     usageitembasenum_dec,
                                     itemname_vchr,
                                     itemspec_vchr,
                                     itemunit_vchr,
                                     itemusagedetail_vchr,
                                     deptmed_int
                                from t_opr_outpatientothrecipede t
                               where t.outpatrecipeid_chr = ?
                                 and t.itemid_chr in (" + sbSubSql + ")";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                #endregion

                #endregion

                #region 保存新的诊疗项目

                if (lstOrderDicItemId != null && lstOrderDicItemId.Count > 0)
                {
                    sbSubSql = null;
                    sbSubSql = new StringBuilder(4 * lstOrderDicItemId.Count);

                    foreach (string strTmp in lstOrderDicItemId)
                    {
                        if (sbSubSql.Length > 0)
                        {
                            sbSubSql.Append(",");
                        }

                        sbSubSql.Append("'").Append(strTmp).Append("'");
                    }

                    strSQL = @"insert into t_opr_outpatient_orderdic
                                  (orderid_int,
                                   outpatrecipeid_chr,
                                   tableindex_int,
                                   orderque_int,
                                   orderdicid_chr,
                                   orderdicname_vchr,
                                   spec_vchr,
                                   qty_dec,
                                   attachid_vchr,
                                   sampleid_vchr,
                                   checkpartid_vchr,
                                   sbbasemny_dec,
                                   usageid_chr,
                                   pricemny_dec,
                                   totalmny_dec,
                                   attachorderid_vchr,
                                   attachorderbasenum_dec)
                                  select to_char(seq_recipeorderid.nextval),
                                         '" + p_oprVO.m_strOutpatRecipeID + @"',
                                         tableindex_int,
                                         orderque_int,
                                         orderdicid_chr,
                                         orderdicname_vchr,
                                         spec_vchr,
                                         qty_dec,
                                         attachid_vchr,
                                         sampleid_vchr,
                                         checkpartid_vchr,
                                         sbbasemny_dec,
                                         usageid_chr,
                                         pricemny_dec,
                                         totalmny_dec,
                                         attachorderid_vchr,
                                         attachorderbasenum_dec
                                    from t_opr_outpatient_orderdic t
                                   where t.outpatrecipeid_chr = ?
                                     and t.orderdicid_chr in (" + sbSubSql + ")";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }

                #endregion

                #region 改变发药单

                if (lstWMItemId.Count > 0 || lstCMItemId.Count > 0)
                {

                    //修改发送药品
                    strSQL = @"update t_opr_medrecipesend t
                            set t.outpatrecipeid_chr = ?
                            where t.outpatrecipeid_chr = ? ";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = p_oprVO.m_strOutpatRecipeID;
                    ParamArr[1].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //记录修改操作信息
                    selFeeDisposeVO.m_strModifyTable = "t_opr_medrecipesend";
                    selFeeDisposeVO.m_strOperationExplain = "把原来的发送药品处方号，修改为新的处方号";

                    lngRes = m_lngRecordSelectFeeDisposeDetail(selFeeDisposeVO);

                    //修改发送处方单
                    strSQL = @"update t_opr_recipesendentry t 
                            set t.outpatrecipeid_chr = ?
                            where t.outpatrecipeid_chr = ?";


                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = p_oprVO.m_strOutpatRecipeID;
                    ParamArr[1].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //记录修改操作信息
                    selFeeDisposeVO.m_strModifyTable = "t_opr_recipesendentry";
                    selFeeDisposeVO.m_strOperationExplain = "把原来的发送处方号，修改为新的处方号";

                    lngRes = m_lngRecordSelectFeeDisposeDetail(selFeeDisposeVO);
                }
                #endregion

                #region  改变申请单
                if (lstCheckItemId.Count > 0 || lstTestItemId.Count > 0)
                {

                    //update检验、检查申请单表的处方对应号
                    //                    strSQL = @"update t_opr_attachrelation t
                    //                               set t.sourceitemid_vchr  = ?
                    //                             where t.sourceitemid_vchr = ?";
                    strSQL = @"update t_opr_attachrelation a
                                   set a.sourceitemid_vchr = ?
                                 where a.attachid_vchr in
                                       (select t.attachid_vchr
                                          from t_opr_outpatient_orderdic t
                                         where t.outpatrecipeid_chr = ? )";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = p_oprVO.m_strOutpatRecipeID;
                    ParamArr[1].Value = p_oprVO.m_strOutpatRecipeID;
                    //ParamArr[1].Value = p_strOriginalRepiceId;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //记录修改操作信息
                    selFeeDisposeVO.m_strModifyTable = "t_opr_attachrelation";
                    selFeeDisposeVO.m_strOperationExplain = "把原来的检验、检查处方号，修改为新的处方号";
                    lngRes = m_lngRecordSelectFeeDisposeDetail(selFeeDisposeVO);
                }
                #endregion

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }


        #region 插入操作记录详细
        /// <summary>
        /// 插入操作记录详细
        /// </summary>
        /// <param name="p_objSelFeeDispose"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRecordSelectFeeDisposeDetail(clsSelectFeeDispose_VO p_objSelFeeDispose)
        {
            long lngRes = -1;
            long lngAffects = -1;

            clsHRPTableService objHRPSvc = null;

            try
            {
                string strSQL = @"insert into t_opr_recordselfeeoperdetail
                                      (recorddetailid, recordid, modifytable, modifydate, operationexplain)
                                    values
                                      (seq_recipeid.nextval,?,?,?,?)";
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;

                objHRPSvc.CreateDatabaseParameter(4, out objParamArr);

                objParamArr[0].Value = p_objSelFeeDispose.m_strRecordId;
                objParamArr[1].Value = p_objSelFeeDispose.m_strModifyTable;
                objParamArr[2].Value = p_objSelFeeDispose.m_dtmModifyDate;
                objParamArr[3].Value = p_objSelFeeDispose.m_strOperationExplain;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }

            return lngRes;
        }
        #endregion

        #region 插入操作记录主表
        /// <summary>
        /// 插入操作记录主表
        /// </summary>
        /// <param name="p_objSelFeeDispose"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRecordSelectFeeDispose(clsSelectFeeDispose_VO p_objSelFeeDispose)
        {
            long lngRes = -1;
            long lngAffects = -1;

            clsHRPTableService objHRPSvc = null;

            try
            {
                string strSQL = @"insert into t_opr_recordselectfeeoperation
                              (recordid,
                               outpatrecipedeid_old_chr,
                               outpatrecipedeid_new_chr,
                               operationempid)
                            values
                              ( ?, ?, ?, ?)";
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;

                objHRPSvc.CreateDatabaseParameter(4, out objParamArr);

                objParamArr[0].Value = p_objSelFeeDispose.m_strRecordId;
                objParamArr[1].Value = p_objSelFeeDispose.m_strOutpatRecipeIdOld;
                objParamArr[2].Value = p_objSelFeeDispose.m_strOutpatRecipeIdNew;
                objParamArr[3].Value = p_objSelFeeDispose.m_strModifyEmpId;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }

            return lngRes;
        }
        #endregion

        #endregion

        #region 判断是某个药品的药品类型是否在9003中
        /// <summary>
        /// 判断是某个药品的药品类型是否在9003中
        /// </summary>
        /// <param name="p_strMedId"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool blMedicine9003(string p_strMedId)
        {
            long lngRes = 0;
            bool blMedicine = false;
            clsHRPTableService objHRPSvc = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @"select t.medicinetypeid_chr
                                  from t_bse_chargeitem a, t_bse_medicine t
                                 where a.itemsrcid_vchr = t.medicineid_chr
                                   and a.itemid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strMedId;
                DataTable dtTemp = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                string MedTypeID = string.Empty;
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    MedTypeID = dtTemp.Rows[0]["medicinetypeid_chr"].ToString();

                    strSQL = @"select t.parmvalue_vchr from t_bse_sysparm t where t.parmcode_chr = '9003'";
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtTemp);
                    if (dtTemp.Rows.Count > 0)
                    {
                        string[] arr9003 = dtTemp.Rows[0]["parmvalue_vchr"].ToString().Split(new char[] { ';', '；' });
                        for (int i = 0; i < arr9003.Length; i++)
                        {
                            if (arr9003[i].ToString() == MedTypeID)
                            {
                                blMedicine = true;
                                break;
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
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return blMedicine;
        }
        #endregion

        #region 社保患者写入当日就诊编号
        /// <summary>
        /// 社保患者写入当日就诊编号
        /// </summary>
        /// <param name="regNo"></param>
        /// <param name="regDate"></param>
        /// <param name="pid"></param>
        /// <param name="deptId"></param>
        /// <param name="doctId"></param>
        /// <param name="diagCode"></param>
        /// <returns></returns>
        public long SaveOpRegNo(string regNo, string regDate, string pid, string deptId, string doctId, string diagCode)
        {
            long lngRes = 0, lngAffects = 0;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            try
            {

                string strSQL = @"insert into opRegNo
                                      (regNo, regDate, pid, deptId, doctId, diagCode)
                                    values
                                      (?, ?, ?, ?, ?, ?)";

                int n = -1;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[++n].Value = regNo;
                ParamArr[++n].Value = regDate;
                ParamArr[++n].Value = pid;
                ParamArr[++n].Value = deptId;
                ParamArr[++n].Value = doctId;
                ParamArr[++n].Value = diagCode;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            finally
            {
                objHRPSvc.Dispose();
            }
            return lngRes;
        }
        #endregion
    }
    #endregion

    #region 门诊收费中间件[纯查询]
    /// <summary>
    /// 门诊收费中间件[纯查询]
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsOPChargeQuerySvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsOPChargeQuerySvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 查找药品
        [AutoComplete]
        public long m_mthFindMedicineByID(string strType, string ID, string strPatientTypeID, out DataTable dt, System.Security.Principal.IPrincipal p_objPrincipal, string strEmployID, string p_strMedTypeID)
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

            //            string strSQL = @"
            //				select	a.itemid_chr,a.itemname_vchr,a.itemspec_vchr,a.itemengname_vchr,a.itemcode_vchr as tempitemcode, a.insuranceid_chr, 
            //						a.itemopunit_chr,a.itemprice_mny,a.itemopinvtype_chr,a.itemcatid_chr,a.selfdefine_int,a.itemcode_vchr,a.itemopcalctype_chr,a.dosage_dec,a.dosageunit_chr,f.precent_dec ,
            //						b.noqtyflag_int,a." + strType + @" type,a.itemipunit_chr, round (a.itemprice_mny / a.packqty_dec, 4) submoney, a.opchargeflg_int,a.itemunit_chr as unit from t_bse_chargeitem a ,t_bse_medicine b,  (select * from t_aid_inschargeitem where copayid_chr = ?) f
            //				where  trim(a.itemsrcid_vchr)=trim(b.medicineid_chr(+)) and a.ifstop_int =0 and ( upper(a." + strType + ") LIKE ? or upper(a.itemcode_vchr) like ? or upper(a.itemopcode_chr) like ?) and a.itemid_chr =f.itemid_chr(+)  order by  a.itemcode_vchr";
            string strSQL = @"select a.itemid_chr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.itemengname_vchr,
       a.itemcode_vchr as tempitemcode,
       a.insuranceid_chr,
       a.itemopunit_chr,
       a.itemprice_mny,
       a.itemopinvtype_chr,
       a.itemcatid_chr,
       a.selfdefine_int,
       a.itemcode_vchr,
       a.itemopcalctype_chr,
       a.dosage_dec,
       a.dosageunit_chr,
       f.precent_dec,
       b.noqtyflag_int,
       a." + strType + @" type,
       a.itemipunit_chr,
       round(a.itemprice_mny / a.packqty_dec, 4) submoney,
       a.opchargeflg_int,
       a.itemunit_chr as unit,
       a.tradeprice_mny,
        round(a.tradeprice_mny / a.packqty_dec, 4) subtrademoney
  from t_bse_chargeitem a,
       t_bse_medicine b,
       (select precent_dec, itemid_chr, copayid_chr
          from t_aid_inschargeitem
         where copayid_chr = ?) f
 where a.itemsrcid_vchr = b.medicineid_chr(+)
   and a.ifstop_int = 0
   and (upper(a." + strType + @") like ? or upper(a.itemcode_vchr) like ? or
       upper(a.itemopcode_chr) like ?)
   and a.itemid_chr = f.itemid_chr(+)
   and (not exists (select 1
                      from t_bse_medicine k
                     where k.medicineid_chr = b.medicineid_chr
                       and k.medicinetypeid_chr in (" + p_strMedTypeID + @")) or
        b.medicinetypeid_chr is null)
union all
select a.itemid_chr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.itemengname_vchr,
       a.itemcode_vchr as tempitemcode,
       a.insuranceid_chr,
       a.itemopunit_chr,
       a.itemprice_mny,
       a.itemopinvtype_chr,
       a.itemcatid_chr,
       a.selfdefine_int,
       a.itemcode_vchr,
       a.itemopcalctype_chr,
       a.dosage_dec,
       a.dosageunit_chr,
       f.precent_dec,
       b.noqtyflag_int,
       a." + strType + @" type,
       a.itemipunit_chr,
       round(a.itemprice_mny / a.packqty_dec, 4) submoney,
       a.opchargeflg_int,
       a.itemunit_chr as unit,
       a.tradeprice_mny,
       round(a.tradeprice_mny / a.packqty_dec, 4) subtrademoney
  from t_bse_chargeitem a,
       t_bse_medicine b,
       (select precent_dec, itemid_chr, copayid_chr
          from t_aid_inschargeitem
         where copayid_chr = ?) f
 where a.itemsrcid_vchr = b.medicineid_chr(+)
   and a.ifstop_int = 0
   and (upper(a." + strType + @") like ? or upper(a.itemcode_vchr) like ? or
       upper(a.itemopcode_chr) like ?)
   and a.itemid_chr = f.itemid_chr(+)
   and exists (select 1
          from t_bse_medicine k
         where k.medicineid_chr = b.medicineid_chr
           and k.medicinetypeid_chr in (" + p_strMedTypeID + @"))
   and exists (select 1
          from t_ds_storage t1, t_ds_storage_detail t2
         where t1.medicineid_chr = t2.medicineid_chr
           and t1.drugstoreid_chr=t2.drugstoreid_chr
           and t1.medicineid_chr = b.medicineid_chr
           and t1.noqtyflag_int = 0
           and t1.ifstop_int = 0
           and t2.canprovide_Int = 1
           and t2.iprealgross_Int > 0)
";
            if (ID.StartsWith(@"/"))//查找常用药
            {
                strSQL = @"
				select	a.itemid_chr,a.itemname_vchr,a.itemspec_vchr,a.itemengname_vchr,a.itemcode_vchr as TempItemCode, a.insuranceid_chr, 
						a.itemopunit_chr,a.itemprice_mny,a.itemopinvtype_chr,a.itemcatid_chr,a.selfdefine_int,a.itemcode_vchr,a.itemopcalctype_chr,a.dosage_dec,a.dosageunit_chr,f.precent_dec ,
						b.noqtyflag_int,a." + strType + @" type,a.itemipunit_chr, round (a.itemprice_mny / a.packqty_dec, 4) submoney, a.opchargeflg_int,a.itemunit_chr as unit from t_bse_chargeitem a ,t_bse_medicine b, 
						(select precent_dec,itemid_chr,copayid_chr from t_aid_inschargeitem where copayid_chr = ?) f,
						(select seqid_chr, create_dat, deptid_chr, itemid_chr, createrid_chr, privilege_int, type_int from t_aid_comusechargeitem where createrid_chr = ? and type_int = 1
						union
						select a.seqid_chr, a.create_dat, a.deptid_chr, a.itemid_chr, a.createrid_chr, a.privilege_int, a.type_int from t_aid_comusechargeitem a,
						(select a.deptid_chr from t_bse_deptemp a  where a.end_dat is null and a.empid_chr = ?) b
						where a.deptid_chr = b.deptid_chr and type_int = 1) g
				where  trim(a.itemsrcid_vchr)=trim(b.medicineid_chr(+)) and a.ifstop_int =0  
						and a.itemid_chr = g.itemid_chr
						and upper(a." + strType + @") like ? 
						and a.itemid_chr =f.itemid_chr(+)  order by  a.itemcode_vchr";

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = strEmployID;
                ParamArr[2].Value = strEmployID;
                ParamArr[3].Value = ID.Replace("/", "") + "%";
            }
            else
            {
                objHRPSvc.CreateDatabaseParameter(8, out ParamArr);
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = ID + "%";
                ParamArr[2].Value = ID + "%";
                ParamArr[3].Value = ID + "%";
                ParamArr[4].Value = strPatientTypeID;
                ParamArr[5].Value = ID + "%";
                ParamArr[6].Value = ID + "%";
                ParamArr[7].Value = ID + "%";
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (lngRes > 0 && dt != null && dt.Rows.Count > 0)
                {
                    DataView objDv = new DataView(dt);
                    objDv.Sort = "itemcode_vchr";
                    dt = objDv.ToTable();
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

            string strSQL = @"
							select  a.*
									,b.noqtyflag_int,b.ifstop_int
									,round (a.itemprice_mny / a.packqty_dec,4) submoney,round(a.tradeprice_mny / a.packqty_dec, 4) subtrademoney
								from t_bse_chargeitem a, t_bse_medicine b
							where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
								and a.ifstop_int = 0
								and ( (lower (a.itemname_vchr) like ?)
									  or(lower (a.itemcode_vchr) like ?)
									  or(lower (a.itempycode_chr) like ?)
									  or(lower (a.itemwbcode_chr) like ?)
									)
							order by a.itemcatid_chr";

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

            string strSQL = @"select substr (to_char(seq_recipesendnum.NEXTVAL), -4) from dual ";

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

        #region 获取员工隶属组
        /// <summary>
        /// 根据员工获取员工所在组
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="dtbResult">返回DataTable,groupid_chr组ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGroupEmp(string EmpID, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = new DataTable();
            string strSQL = @"select a.empid_chr, b.groupid_chr, b.groupname_vchr,b.memo_vchr
  from t_bse_groupemp a, t_bse_groupdesc b
 where a.groupid_chr = b.groupid_chr and a.empid_chr =? and end_dat is null";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = EmpID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                //objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                //objHRPSvc.Dispose();
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
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

            string strSQL = @"SELECT outpatrecipeid_chr, a.createdate_dat, a.diagdr_chr, a.diagdept_chr,
       a.pstauts_int, a.recipeflag_int, a.paytypeid_chr, a.type_int, b.deptname_vchr,
       c.lastname_vchr, c.empno_chr, d.paytypename_vchr,d.INTERNALFLAG_INT,d.CHARGEPERCENT_DEC,d.PAYLIMIT_MNY,a.isgreen_int
  FROM t_opr_outpatientrecipe a,
       t_bse_deptdesc b,
       t_bse_employee c,
       t_bse_patientpaytype d
 WHERE a.diagdr_chr = c.empid_chr(+) AND a.diagdept_chr = b.deptid_chr(+)
       AND a.paytypeid_chr = d.paytypeid_chr(+)  and  a.PATIENTID_CHR = ? ";

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
                        if (objdt.Rows[i]["isgreen_int"].ToString() == "1")
                        {
                            objRI_VO[i].m_intPSTATUS_INT = 5;
                        }
                        else
                        {
                            objRI_VO[i].m_intPSTATUS_INT = int.Parse(objdt.Rows[i]["PSTAUTS_INT"].ToString());
                        }
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
                        objRI_VO[i].m_strIsGreen = objdt.Rows[i]["isgreen_int"].ToString();
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
        public long m_mthFindRecipeByID(string ID, out DataTable dt, System.Security.Principal.IPrincipal objPri, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strflag = "OPR";
            if (flag)
            {
                strflag = "TMP";
            }
            string strSQL = @"SELECT * FROM (SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.unitid_chr UNIT, a.tolqty_dec quantity,
       a.unitprice_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,a.USAGEID_CHR,a.FREQID_CHR,a.QTY_DEC,a.DAYS_INT, 
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (1000 + to_number(nvl(a.rowno_vchr2,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times, b.itemipunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,
b.opchargeflg_int  as opchargeflg_int,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,'' as ATTACHID_VCHR,a.HYPETEST_INT,a.DESC_VCHR, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, '' as orderid, 0 as ordernum,a.toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney 
  FROM t_" + strflag + @"_outpatientpwmrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION  all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.unitid_chr UNIT, a.MIN_QTY_DEC quantity,
       a.unitprice_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,a.USAGEID_CHR,'' as FREQID_CHR,MIN_QTY_DEC as QTY_DEC,1 as DAYS_INT, 
       b.itemname_vchr itemname, b.itemspec_vchr Dec,a.SUMUSAGE_VCHR, (2000 + to_number(nvl(a.rowno_vchr2,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, a.times_int Times,b.itemipunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,b.opchargeflg_int as opchargeflg_int,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,'' as ATTACHID_VCHR,0, a.UsageDetail_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, '' as orderid, 0 as ordernum,a.toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney 
  FROM t_" + strflag + @"_outpatientcmrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.itemunit_vchr UNIT, a.qty_dec quantity,
       a.price_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,'' as USAGEID_CHR,'' as FREQID_CHR,0 as QTY_DEC,1 as DAYS_INT,
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (3000 + to_number(nvl(a.rowno_chr,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times,b.itemipunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,b.opchargeflg_int as opchargeflg_int,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,a.ATTACHID_VCHR,0,a.itemusagedetail_vchr as desc_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum, 0 as toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney 
  FROM t_" + strflag + @"_outpatientchkrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.itemunit_vchr UNIT, a.qty_dec quantity,
       a.price_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,a.USAGEID_CHR,'' as FREQID_CHR,0 as QTY_DEC,1 as DAYS_INT,
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (4000 + to_number(nvl(a.rowno_chr,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times,b.itemipunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,b.opchargeflg_int as opchargeflg_int,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,a.ATTACHID_VCHR,0,a.itemusagedetail_vchr as desc_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,0 as toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney 
  FROM t_" + strflag + @"_outpatienttestrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.itemunit_vchr UNIT, a.qty_dec quantity,
       a.unitprice_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,'' as USAGEID_CHR,'' as FREQID_CHR,0 as QTY_DEC,1 as DAYS_INT,
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (6000 + to_number(nvl(a.rowno_chr,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times,b.itemipunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,b.opchargeflg_int as opchargeflg_int,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,a.ATTACHID_VCHR,0,a.itemusagedetail_vchr as desc_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, '' as orderid, 0 as ordernum,0 as toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney  
  FROM t_" + strflag + @"_outpatientothrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
UNION all
SELECT a.outpatrecipeid_chr,a.itemid_chr ItemID, a.itemunit_vchr UNIT, a.qty_dec quantity,
       a.price_mny price, a.tolprice_mny SumMoney,a.ROWNO_CHR,a.USAGEID_CHR,'' as FREQID_CHR,0 as QTY_DEC,1 as DAYS_INT,
       a.itemname_vchr itemname, a.itemspec_vchr Dec,'' as SUMUSAGE_VCHR, (5000 + to_number(nvl(a.rowno_chr,0))) AS sortno,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,b.DOSAGEUNIT_CHR, b.insuranceid_chr, 
       b.selfdefine_int SELFDEFINE, 1 Times,b.itemipunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,b.opchargeflg_int as opchargeflg_int,b.ITEMOPCALCTYPE_CHR,a.DISCOUNT_DEC, b.itemcode_vchr,a.ATTACHID_VCHR,0,a.itemusagedetail_vchr as desc_vchr, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.USAGEPARENTID_VCHR, a.usageitembasenum_dec, a.deptmed_int, a.orderid_vchr as orderid, a.orderbasenum_dec as ordernum,0 as toldiffprice_mny,b.tradeprice_mny,round (b.tradeprice_mny / b.packqty_dec, 4) subtrademoney 
  FROM t_" + strflag + @"_outpatientopsrecipede a, t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.outpatrecipeid_chr = ? 
		) t1,t_opr_outpatientrecipe t2 WHERE t1.outpatrecipeid_chr = t2.outpatrecipeid_chr order by t1.sortno";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = ID;
                ParamArr[1].Value = ID;
                ParamArr[2].Value = ID;
                ParamArr[3].Value = ID;
                ParamArr[4].Value = ID;
                ParamArr[5].Value = ID;

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

        #region  按病人ID查找最近一次没有收费的处方号
        [AutoComplete]
        public long m_mthFindMaxRecipeNoByPatientID(string ID, out string strRecipeNo, out string strSeqid, out string strstatus, out int RecipeCount, out DataTable dt, out string strISgreen)
        {
            strRecipeNo = "";
            strstatus = "";
            strSeqid = "";
            strISgreen = "";
            long lngRes = 0;
            RecipeCount = 0;
            dt = null;
            DataTable objdt = new DataTable();
            DataTable dtTemp = new DataTable();
            DataTable dtResult = new DataTable();
            string strSQL = @"select a.outpatrecipeid_chr,
                                       a.patientid_chr,
                                       a.createdate_dat,
                                       a.registerid_chr,
                                       a.diagdr_chr,
                                       a.diagdept_chr,
                                       a.recordemp_chr,
                                       a.recorddate_dat,
                                       a.pstauts_int,
                                       a.recipeflag_int,
                                       a.outpatrecipeno_vchr,
                                       a.paytypeid_chr,
                                       a.casehisid_chr,
                                       a.groupid_chr,
                                       a.type_int,
                                       a.confirm_int,
                                       a.confirmdesc_vchr,
                                       a.createtype_int,
                                       a.deptmed_int,
                                       a.archtakeflag_int,
                                       a.printed_int,
                                       a.chargedeptid_chr,
                                       b.coalitionrecipeflag_int,
                                       '' as seqid_chr,
                                       a.isgreen_int,
                                       a.isproxyboilmed 
                                  from t_opr_outpatientrecipe a, t_bse_patientpaytype b
                                 where a.paytypeid_chr = b.paytypeid_chr(+)
                                   and (a.pstauts_int = 1 or a.pstauts_int = 4)
                                   and a.patientid_chr = ?
                                   and a.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                 order by a.recipeflag_int asc, a.recorddate_dat desc";

            string strSQL1 = @"select a.outpatrecipeid_chr,
                                       a.patientid_chr,
                                       a.createdate_dat,
                                       a.registerid_chr,
                                       a.diagdr_chr,
                                       a.diagdept_chr,
                                       a.recordemp_chr,
                                       a.recorddate_dat,
                                       a.pstauts_int,
                                       a.recipeflag_int,
                                       a.outpatrecipeno_vchr,
                                       a.paytypeid_chr,
                                       a.casehisid_chr,
                                       a.groupid_chr,
                                       a.type_int,
                                       a.confirm_int,
                                       a.confirmdesc_vchr,
                                       a.createtype_int,
                                       a.deptmed_int,
                                       a.archtakeflag_int,
                                       a.printed_int,
                                       a.chargedeptid_chr,
                                       b.coalitionrecipeflag_int,
                                       c.seqid_chr,
                                       a.isgreen_int,
                                       a.isproxyboilmed
                                  from t_opr_outpatientrecipe    a,
                                       t_bse_patientpaytype      b,
                                       t_opr_outpatientrecipeinv c
                                 where a.paytypeid_chr = b.paytypeid_chr(+)
                                   and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                                   and a.pstauts_int = 2
                                   and a.patientid_chr = ?
                                   and a.isgreen_int = 1
                                   and a.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = ID;
                ParamArr[1].Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                ParamArr[2].Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, ParamArr);
                if (lngRes > 0)
                {
                    ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = ID;
                    ParamArr[1].Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                    ParamArr[2].Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtTemp, ParamArr);
                    if (lngRes > 0 && dtTemp.Rows.Count > 0)
                    {

                        if (dtTemp.Rows.Count > 0)
                        {
                            objdt = dtResult.Copy();
                            dtResult.Merge(dtTemp);
                            DataView dv = dtResult.DefaultView;
                            dv.Sort = "recipeflag_int asc, recorddate_dat desc";
                            objdt = dv.ToTable();
                        }
                    }
                    else
                    {
                        objdt = dtResult;
                    }
                }
                objHRPSvc.Dispose();
                if (lngRes > 0 && objdt.Rows.Count > 0)
                {
                    RecipeCount = objdt.Rows.Count;
                    strRecipeNo = objdt.Rows[0]["OUTPATRECIPEID_CHR"].ToString();
                    strstatus = objdt.Rows[0]["pstauts_int"].ToString();
                    string strTempDocID = objdt.Rows[0]["DIAGDR_CHR"].ToString().Trim();
                    string strTempPatientTypeID = objdt.Rows[0]["PAYTYPEID_CHR"].ToString().Trim();
                    strISgreen = objdt.Rows[0]["isgreen_int"].ToString();
                    strSeqid = objdt.Rows[0]["seqid_chr"].ToString();
                    bool tempFlag = false;
                    int TempCount = 0;
                    for (int i = 0; i < objdt.Rows.Count; i++)
                    {
                        if (strTempDocID == objdt.Rows[i]["DIAGDR_CHR"].ToString().Trim() && strTempPatientTypeID == objdt.Rows[i]["PAYTYPEID_CHR"].ToString().Trim())
                        {
                            TempCount++;
                            if (strISgreen == "1")
                            {
                                tempFlag = strstatus == "2";
                            }
                            else
                            {
                                tempFlag = strstatus == "4";
                            }
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

        #region  按病人ID查找最近一次先诊疗后结算的处方号
        /// <summary>
        /// 按病人ID查找最近一次先诊疗后结算的处方号
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="strRecipeNo"></param>
        /// <param name="strstatus"></param>
        /// <param name="RecipeCount"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindTreatRecipeNoByPatientID(string ID, out string strRecipeNo, out string strSeqid, out string strstatus, out int RecipeCount, out DataTable dt)
        {
            strRecipeNo = "";
            strSeqid = "";
            strstatus = "";
            long lngRes = 0;
            RecipeCount = 0;
            dt = null;
            DataTable objdt = new DataTable();
            string strSQL = @"select a.outpatrecipeid_chr,
                                       a.patientid_chr,
                                       a.createdate_dat,
                                       a.registerid_chr,
                                       a.diagdr_chr,
                                       a.diagdept_chr,
                                       a.recordemp_chr,
                                       a.recorddate_dat,
                                       a.pstauts_int,
                                       a.recipeflag_int,
                                       a.outpatrecipeno_vchr,
                                       a.paytypeid_chr,
                                       a.casehisid_chr,
                                       a.groupid_chr,
                                       a.type_int,
                                       a.confirm_int,
                                       a.confirmdesc_vchr,
                                       a.createtype_int,
                                       a.deptmed_int,
                                       a.archtakeflag_int,
                                       a.printed_int,
                                       a.chargedeptid_chr,
                                       b.coalitionrecipeflag_int,c.seqid_chr
                                  from t_opr_outpatientrecipe a, t_bse_patientpaytype b,t_opr_outpatientrecipeinv c 
                                 where a.paytypeid_chr = b.paytypeid_chr(+)
                                    and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                                   and a.pstauts_int = 2
                                   and a.patientid_chr = ?
                                   and a.isgreen_int = 1
                                   and a.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')       
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
                    strSeqid = objdt.Rows[0]["seqid_chr"].ToString();
                    string strTempDocID = objdt.Rows[0]["DIAGDR_CHR"].ToString().Trim();
                    string strTempPatientTypeID = objdt.Rows[0]["PAYTYPEID_CHR"].ToString().Trim();
                    bool tempFlag = false;
                    int TempCount = 0;
                    for (int i = 0; i < objdt.Rows.Count; i++)
                    {
                        if (strTempDocID == objdt.Rows[i]["DIAGDR_CHR"].ToString().Trim() && strTempPatientTypeID == objdt.Rows[i]["PAYTYPEID_CHR"].ToString().Trim())
                        {
                            TempCount++;
                            tempFlag = strstatus == "2";
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
            string SQL = @"select a.outpatrecipeid_chr,
       a.patientid_chr,
       a.createdate_dat,
       a.registerid_chr,
       a.diagdr_chr,
       a.diagdept_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.pstauts_int,
       a.recipeflag_int,
       a.outpatrecipeno_vchr,
       a.paytypeid_chr,
       a.casehisid_chr,
       a.groupid_chr,
       a.type_int,
       a.confirm_int,
       a.confirmdesc_vchr,
       a.createtype_int,
       a.deptmed_int,
       a.archtakeflag_int,
       a.printed_int,
       a.chargedeptid_chr,a.isgreen_int
                            from t_opr_outpatientrecipe a
                           where (a.pstauts_int = 1 or a.pstauts_int = 4)
                             and a.patientid_chr = ?  
                             and to_char(a.recorddate_dat, 'yyyy-mm-dd') = ?";
            string strSQL1 = @"select a.outpatrecipeid_chr,a.isgreen_int,
       a.patientid_chr,
       a.createdate_dat,
       a.registerid_chr,
       a.diagdr_chr,
       a.diagdept_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.pstauts_int,
       a.recipeflag_int,
       a.outpatrecipeno_vchr,
       a.paytypeid_chr,
       a.casehisid_chr,
       a.groupid_chr,
       a.type_int,
       a.confirm_int,
       a.confirmdesc_vchr,
       a.createtype_int,
       a.deptmed_int,
       a.archtakeflag_int,
       a.printed_int,
       a.chargedeptid_chr,a.isgreen_int from t_opr_outpatientrecipe a
                           where a.pstauts_int = 2
                             and a.patientid_chr = ?
                             and a.isgreen_int = 1
                             and to_char(a.recorddate_dat, 'yyyy-mm-dd') = ?";

            long lngRes = 0;
            DataTable dt = new DataTable();
            DataTable dtResult1 = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = pid;
                ParamArr[1].Value = DateTime.Now.ToString("yyyy-MM-dd");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0)
                {
                    ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = pid;
                    ParamArr[1].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtResult1, ParamArr);
                    if (lngRes > 0 && dtResult1.Rows.Count > 0)
                    {
                        dt.Merge(dtResult1);
                    }
                }
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    recsum = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string recno = dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim();
                        string status = dt.Rows[i]["pstauts_int"].ToString();
                        string strISgreen = dt.Rows[i]["isgreen_int"].ToString();
                        bool flag = false;
                        if (strISgreen == "1")
                        {
                            flag = (status == "2");
                        }
                        else
                        {
                            flag = (status == "4");
                        }
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

        #region 根据患者ID统计该病人所有先诊疗后结算的处方信息
        /// <summary>
        /// 根据患者ID统计该病人所有先诊疗后结算的处方信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="recsum"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTreatRecinfoBypid(string pid, out int recsum, out DataTable dtRecord)
        {
            recsum = 0;
            dtRecord = null;
            string SQL = @"select a.outpatrecipeid_chr,a.isgreen_int,
       a.patientid_chr,
       a.createdate_dat,
       a.registerid_chr,
       a.diagdr_chr,
       a.diagdept_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.pstauts_int,
       a.recipeflag_int,
       a.outpatrecipeno_vchr,
       a.paytypeid_chr,
       a.casehisid_chr,
       a.groupid_chr,
       a.type_int,
       a.confirm_int,
       a.confirmdesc_vchr,
       a.createtype_int,
       a.deptmed_int,
       a.archtakeflag_int,
       a.printed_int,
       a.chargedeptid_chr from t_opr_outpatientrecipe a
                           where a.pstauts_int = 2
                             and a.patientid_chr = ?
                             and a.isgreen_int = 1
                             and to_char(a.recorddate_dat, 'yyyy-mm-dd') = ?";

            long lngRes = 0;
            DataTable dt = new DataTable();
            clsHRPTableService objHRPSvc = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = pid;
                ParamArr[1].Value = DateTime.Now.ToString("yyyy-MM-dd");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    recsum = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string recno = dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim();
                        string status = dt.Rows[i]["pstauts_int"].ToString();
                        bool flag = (status == "2");
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
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
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
            string strSQL = @"select INVOICENO_VCHR as invono 
                                from T_OPR_OUTPATIENTRECIPEINV 
                               where INVOICENO_VCHR = ? 
                             
                            union all   
                            
                              select repprninvono_vchr as invono
                                from t_opr_invoicerepeatprint
                               where type_chr = '1' 
                                 and repprninvono_vchr = ?";

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

            string strSQL = @"select mapid_chr,groupid_chr,catid_chr,internalflag_int from t_bse_chargecatmap  where internalflag_int=1";
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
        public long m_mthGetDefaultItem(out DataTable dt, string strPatientTypeID, string strRecipeflag, string strDuty, string strRecipeID, string strRegID, string strDeptID)
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

                SQL = @"select a.isselfhelp, a.flag_int,a.diagdoctor_chr,a.diagdept_chr from t_opr_patientregister a where a.registerid_chr= ?";
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRegID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtTmp, ParamArr);
                string strRegDept = null;
                if (lngRes > 0 && dtTmp.Rows.Count > 0)
                {
                    strRegDept = dtTmp.Rows[0]["diagdept_chr"].ToString();

                    if (dtTmp.Rows[0][0].ToString().Trim() == "3")
                    {
                        intArchTakeFlag = 2;//（自助挂号未收费）带出挂号费
                    }
                    else
                    {
                        intArchTakeFlag = 1;
                    }
                }

                SQL = @"select a.paytypeid_chr, a.itemid_chr, a.qty_dec, a.regflag_int, a.recflag_int,
                               a.dutyname_vchr, a.begintime_chr, a.endtime_chr, a.deptid_chr
                          from t_aid_outpatientdefaultadditem a
                         where (a.paytypeid_chr = ? or a.paytypeid_chr = '0000')
                           and (a.regflag_int = ? or a.regflag_int = 0)
                           and (a.recflag_int = ? or a.recflag_int = 0)
                           and (a.dutyname_vchr = ? or a.dutyname_vchr = '全部')
                           and (to_char (sysdate, 'hh24:mi') between a.begintime_chr and a.endtime_chr)
                           and (a.deptid_chr = ? or a.deptid_chr = '0')";

                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = intArchTakeFlag;
                ParamArr[2].Value = strRecipeflag;
                ParamArr[3].Value = strDuty;
                ParamArr[4].Value = strDeptID;

                DataTable dtbTemp = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbTemp, ParamArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;
                DataView dv = dtbTemp.DefaultView;
                dv.RowFilter = "deptid_chr='" + strDeptID + "'";
                if (dv.Count > 0)//大于0说明是特定科室，则只取该科室的项目，科室ID为0的项目不取
                {
                    dtbTemp = dv.ToTable();
                    dtbTemp.Columns.Remove("deptid_chr");
                    dt = dtbTemp;
                    dtbTemp.Dispose();
                    dtbTemp = null;
                    dv.Dispose();
                    dv = null;
                }
                else//否则不是特定科室，取科室ID为0的项目
                {
                    dtbTemp.Columns.Remove("deptid_chr");
                    dt = dtbTemp;
                    dtbTemp.Dispose();
                    dtbTemp = null;
                    dv.Dispose();
                    dv = null;
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
            string strSQL = @"select paytypeid_chr, itemid_chr, qty_dec, register_int, recipeflag_int, expert_int from t_aid_chargepaytype 
								where (paytypeid_chr = ? or paytypeid_chr = '0000') 
								  and (register_int = ? or register_int = 0)  
								  and (recipeflag_int = ? or recipeflag_int = 0) 
								  and (expert_int = ? or expert_int = 0)";
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
        /// <param name="strPatType"></param>
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
                                    a.opchargeflg_int, a.itemunit_chr as unit, a.tradeprice_mny,round (a.tradeprice_mny / a.packqty_dec, 4) subtrademoney
                               from t_bse_chargeitem a,
                                    t_bse_medicine b,
                                    (select precent_dec, itemid_chr, copayid_chr
                                       from t_aid_inschargeitem
                                      where copayid_chr = ?) f,
                                    t_aid_outpatientdefaultadditem c
                              where a.itemsrcid_vchr = b.medicineid_chr(+)
                                and a.ifstop_int = 0
                                and a.itemid_chr = ?
                                and a.itemid_chr = f.itemid_chr(+)
                                and a.itemid_chr = c.itemid_chr
                           order by a.itemcode_vchr";

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
            string strSQL = @"select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr from t_sys_setting where setid_chr ='0005'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dt = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() == "1")
                    {
                        strSQL = @"select internalflag_int,internaldesc_vchr from t_opr_outpatientrecipeinv_itl order by internalflag_int";
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
            string strSQL = @"select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr from t_sys_setting where setid_chr = ?";
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
            string SQL = @"select count(*) nums from t_bse_chargeitem a, t_aid_chargemderla b 
						   where a.itemcatid_chr = b.itemcatid_chr and b.medicinetypeid_chr = '5' and a.itemid_chr = ?";

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

                int DateInterval = 0;
                DataTable dt = new DataTable();
                SQL = @"select setstatus_int from t_sys_setting where setid_chr = '0058'";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (lngRes > 0 && dt.Rows.Count == 1)
                {
                    string s = dt.Rows[0][0].ToString().Trim();
                    if (s != "" && Convert.ToInt32(s) > 0)
                    {
                        DateInterval = Convert.ToInt32(s) - 1;
                    }
                }

                SQL = @"select count(*) nums 
                             from t_opr_patientregister 
						   where registerid_chr = ?  
                             and pstatus_int <> 3 
                             and flag_int <> 3
                             and (to_char(registerdate_dat, 'yyyy-mm-dd') between to_char(sysdate - ?, 'yyyy-mm-dd') and to_char(sysdate, 'yyyy-mm-dd'))";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strRegID;
                ParamArr[1].Value = DateInterval.ToString();

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
								  (select precent_dec,itemid_chr,copayid_chr from t_aid_inschargeitem where copayid_chr = ?) c,
								  (select itemid_chr, subitemid_chr, qty_int, usageid_chr, freqid_chr, days_int, totalqty_dec, usescope_int, continueusetype_int from t_bse_subchargeitem where itemid_chr = ?) d 
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

            string strSQL = @"select paycardtype_int,paycarddesc_vchr from t_bse_paycardtype order by paycardtype_int";
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

            string strSQL = @"select patientid_chr,modify_dat,paycardtype_int,paycardno_vchr,paycardstatus_int from t_bse_patientcardtype where paycardstatus_int = 1 and patientid_chr = ?";
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

            string SQL = @" select a.outpatrecipeid_chr, a.recipetype_int, a.windowid_chr, a.pstatus_int,
       a.senddate_dat, a.sendemp_chr, a.treatdate_dat, a.treatemp_chr,
       a.autoprint_int, a.medstoreid_chr, a.finallysendwindowid,
       a.finallywindowid, a.sendwindowid, a.givedate_dat, a.giveemp_chr,
       a.returndate_dat, a.returnemp_chr, a.remark_vchr, a.autoprintyd_int, 
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

        #region 根据结帐人、结帐时间获取相应的重打发票信息
        /// <summary>
        /// 根据结帐人、结帐时间获取相应的重打发票信息
        /// </summary>
        /// <param name="BalanceEmp"></param>
        /// <param name="BalanceTime"></param>
        /// <returns></returns>
        [AutoComplete]
        public void m_mthGetbalancerepeatinvoinfo(string BalanceEmp, string BalanceTime, out string[] InvonoArr, int status)
        {
            InvonoArr = null;
            DataTable dt = new DataTable();
            long lngRes = 0;
            string SQL = "";

            //未结帐
            if (status == 0)
            {
                SQL = @"select b.repprninvono_vchr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_invoicerepeatprint b
                     where a.seqid_chr = b.seqid_chr 
                       and a.balanceflag_int = 0 
                       and b.type_chr = '1' 
                       and a.recordemp_chr = ? 
                       and a.recorddate_dat < to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                    order by b.repprninvono_vchr";
            }
            //已结帐
            else if (status == 1)
            {
                SQL = @"select b.repprninvono_vchr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_invoicerepeatprint b
                     where a.seqid_chr = b.seqid_chr 
                       and a.balanceflag_int = 1 
                       and b.type_chr = '1' 
                       and a.balanceemp_chr = ?
                       and a.balance_dat = to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                    order by b.repprninvono_vchr";
            }
            else
            {
                return;
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BalanceEmp;
                ParamArr[1].Value = BalanceTime;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region (体检)获取体检登记操作者信息
        /// <summary>
        /// (体检)获取体检登记操作者信息
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="EmpVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPEDoctor(string CardNo, out clsEmployeeVO EmpVO)
        {
            long lngRes = 0;
            DataTable dtValues = new DataTable();
            string strSQL = @"select   c.empid_chr, c.lastname_vchr, c.empno_chr, c.pycode_chr,
                                       c.isexpert_chr, c.isexternalexpert_chr, 1 as orderstr
                                  from t_pe_register a, t_bse_patientcard b, t_bse_employee c
                                 where a.patientid_chr = b.patientid_chr
                                   and a.regoper_chr = c.empid_chr
                                   and a.chargeflag_int = 0
                                   and rownum = 1
                                   and b.patientcardid_chr = ? ";
            EmpVO = null;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = CardNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValues, param);
                if (dtValues.Rows.Count != 1)
                {
                    objHRPSvc.Dispose();
                    return -1;
                }

                EmpVO = new clsEmployeeVO();
                EmpVO.strEmpID = dtValues.Rows[0]["empid_chr"].ToString();
                EmpVO.strName = dtValues.Rows[0]["lastname_vchr"].ToString();
                EmpVO.strEmpNO = dtValues.Rows[0]["EMPNO_CHR"].ToString();
                EmpVO.strPYCode = dtValues.Rows[0]["PYCODE_CHR"].ToString();
                EmpVO.strIsExpert = dtValues.Rows[0]["ISEXPERT_CHR"].ToString();
                EmpVO.strIsExternalExpert = dtValues.Rows[0]["ISEXTERNALEXPERT_CHR"].ToString();
                EmpVO.strOfficePhone = dtValues.Rows[0]["ORDERSTR"].ToString().Trim();//用表示排序号

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

        #region (体检)获取体检人收费项目
        /// <summary>
        /// (体检)获取体检人收费项目
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPEChargeItem(string CardNo, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select   d.groupcode_chr, f.itemcode_vchr, f.itemid_chr, r.regno_chr
                                    from t_pe_patientitem a, 
                                         t_pe_itemgroup d,
                                         t_pe_itemgroup_entry e,
                                         t_pe_item f,
                                         t_pe_register r,
                                         t_bse_patientcard p
                                   where a.itemcode_vchr=d.groupcode_chr
                                    and  d.groupcode_chr = e.groupcode_chr
                                     and e.itemid_chr = f.itemid_chr
                                     and d.instflag_chr = '1'
                                     and f.instflag_chr = '1'
                                     and f.chargeflag_chr = '1'
                                     and a.type_int = 2
                                     and r.regno_chr = a.regno_chr
                                     and r.patientid_chr = p.patientid_chr
                                     and r.chargeflag_int = 0
                                     and (p.status_int = 1 or p.status_int = 3)
                                     and p.patientcardid_chr = ?
                                order by d.groupcode_chr, f.itemcode_vchr ";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = CardNo;

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

        #region (体检)根据体检收费项目ID获取相关收费信息
        /// <summary>
        /// (体检)根据体检收费项目ID获取相关收费信息
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="PatType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPEChargeItemInfo(string ItemID, string PatType, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select distinct a.itemid_chr, a.itemname_vchr, a.itemspec_vchr,
                                    a.itemengname_vchr, a.itemcode_vchr as tempitemcode,
                                    a.insuranceid_chr, a.itemopunit_chr, a.itemprice_mny,
                                    a.itemopinvtype_chr, a.itemcatid_chr, a.selfdefine_int,
                                    a.itemcode_vchr, a.itemopcalctype_chr, a.dosage_dec,
                                    a.dosageunit_chr, f.precent_dec, 1 as itemnum,
                                    b.noqtyflag_int, a.itemipunit_chr,
                                    round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                    a.opchargeflg_int, a.itemunit_chr as unit,a.tradeprice_mny, round (a.tradeprice_mny / a.packqty_dec, 4) subtrademoney
                               from t_bse_chargeitem a,
                                    t_bse_medicine b,
                                    (select itemid_chr, precent_dec 
                                       from t_aid_inschargeitem
                                      where copayid_chr = ?) f
                              where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
                                and a.itemid_chr = f.itemid_chr(+)
                                and a.ifstop_int = 0
                                and a.itemid_chr = ?
                           order by a.itemcode_vchr";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = PatType;
                ParamArr[1].Value = ItemID;

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

        #region (体检)获取体检人检验申请单元
        /// <summary>
        /// (体检)获取体检人检验申请单元
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPELisItem(string CardNo, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select d.lisappgroupid_vchr, d.lissampleid_vchr, d.groupcode_chr,
                                       d.groupname_vchr, d.price_dec,r.regno_chr
                                  from t_pe_patientitem a, 
                                       t_pe_itemgroup d,
                                       t_pe_register r,
                                       t_bse_patientcard p
                                 where a.itemcode_vchr = d.groupcode_chr
                                   and d.instflag_chr = '1'
                                   and a.type_int = 2
                                   and d.lisappgroupid_vchr is not null
                                   and r.regno_chr = a.regno_chr
                                   and r.patientid_chr = p.patientid_chr
                                   and r.chargeflag_int = 0
                                   and (p.status_int = 1 or p.status_int = 3)
                                   and p.patientcardid_chr = ? ";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = CardNo;

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

        #region 根据收费项目ID查出刻收费项目的收费比例
        /// <summary>
        /// 根据收费项目ID查出刻收费项目的收费比例
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="strPatientTypeID"></param>
        /// <returns></returns>
        public decimal m_mthGetDiscountByID(string ID, string strPatientTypeID)
        {
            decimal tempDiscount = 100;
            long lngRes = 0;
            DataTable dtbResult = null;
            string strSQL = @"select precent_dec
                              from t_aid_inschargeitem
                             where itemid_chr = ? and copayid_chr = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = ID;
                objParamArr[1].Value = strPatientTypeID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    //tempDiscount = m_mthConvertObjToDecimal(dtbResult.Rows[0]["PRECENT_DEC"]);
                    string strDiscount = dtbResult.Rows[0]["PRECENT_DEC"].ToString().Trim();
                    if (strDiscount != string.Empty)
                    {
                        tempDiscount = Convert.ToDecimal(strDiscount);
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objParamArr = null;
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return tempDiscount;
        }
        #endregion

        #region 根据发票号获取当日序号
        /// <summary>
        /// 根据发票号获取当日序号
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <returns></returns>
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

        #region 根据发票号产生发收费项目明细
        /// <summary>
        /// 根据发票号产生发收费项目明细,然后填充listView
        /// </summary>
        /// <param name="ID">发票号</param>
        /// <param name="lv">listView</param>
        public long m_lngGetChargeItemByInvoiceID(string ID, string p_status, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            string strSQL = @"select d.name,d.dec,d.count,d.price,d.pdcarea_vchr,d.uint,c.doctorname_chr  from t_opr_outpatientrecipeinv c,
        				(select a.outpatrecipeid_chr id,b.itemname_vchr name,b.itemopunit_chr uint,
        				b.itemspec_vchr dec,a.tolqty_dec count,b.pdcarea_vchr ,a.unitprice_mny price
        				from t_opr_outpatientpwmrecipede a,t_bse_chargeitem b
        				where a.itemid_chr=b.itemid_chr(+)
        				union all
        				select a.outpatrecipeid_chr id,b.itemname_vchr name,b.itemopunit_chr uint,
        				b.itemspec_vchr dec,a.qty_dec count,b.pdcarea_vchr ,a.unitprice_mny price
        				from t_opr_outpatientcmrecipede a,t_bse_chargeitem b
        				where a.itemid_chr=b.itemid_chr(+)
        				union all
        				select a.outpatrecipeid_chr id,b.itemname_vchr name,b.itemunit_chr uint,
        				b.itemspec_vchr dec,a.qty_dec count,b.pdcarea_vchr ,a.price_mny price
        				from t_opr_outpatientchkrecipede a,t_bse_chargeitem b
        				where a.itemid_chr=b.itemid_chr(+)
        				union all
        				select a.outpatrecipeid_chr id,b.itemname_vchr name,b.itemunit_chr uint,
        				b.itemspec_vchr dec,a.qty_dec count,b.pdcarea_vchr ,a.price_mny price
        				from t_opr_outpatienttestrecipede a,t_bse_chargeitem b
        				where a.itemid_chr=b.itemid_chr(+)
        				union all
        				select a.outpatrecipeid_chr id, b.itemname_vchr name, b.itemunit_chr uint,
        					b.itemspec_vchr dec, a.qty_dec count,b.pdcarea_vchr, a.price_mny price
        				from t_opr_outpatientopsrecipede a, t_bse_chargeitem b
        				where a.itemid_chr = b.itemid_chr(+)
        				union  all
        				select a.outpatrecipeid_chr id,b.itemname_vchr name,b.itemunit_chr uint,
        				b.itemspec_vchr dec,a.qty_dec count,b.pdcarea_vchr ,a.unitprice_mny price
        				from t_opr_outpatientothrecipede a,t_bse_chargeitem b
        				where a.itemid_chr=b.itemid_chr(+)) d
        				where c.outpatrecipeid_chr=d.id(+)
        				and c.seqid_chr= ?  and status_int = ? ";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = null;
            try
            {
                objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = ID.Trim();
                objParamArr[1].Value = p_status;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objHRPSvc = null;
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

        #region 根据内部序列号取得发票信息
        /// <summary>
        /// 根据内部序列号取得发票信息
        /// </summary>
        /// <param name="ID">内部序列号</param>
        /// <param name="obj"></param>
        /// <returns>成功1 ,0</returns>
        [AutoComplete]
        public long m_mthGetInvoiceInfoByID(string ID, string pstatus, out DataTable dtbResult, out DataTable m_objTempTable, out DataTable dtDept)
        {

            long lngRes = 0;
            string status = "1";
            dtbResult = null;
            m_objTempTable = null;
            dtDept = null;
            string strSQL = @"select a.invoiceno_vchr,
       a.outpatrecipeid_chr,
       a.invdate_dat,
       a.acctsum_mny,
       a.sbsum_mny,
       a.opremp_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.status_int,
       a.seqid_chr,
       a.balanceemp_chr,
       a.balance_dat,
       a.balanceflag_int,
       a.totalsum_mny,
       a.paytype_int,
       a.patientid_chr,
       a.patientname_chr,
       a.deptid_chr,
       a.deptname_chr,
       a.doctorid_chr,
       a.doctorname_chr,
       a.confirmemp_chr,
       a.paytypeid_chr,
       a.internalflag_int,
       a.baseseqid_chr,
       a.groupid_chr,
       a.confirmdeptid_chr,
       a.split_int,
       a.regno_chr, b.paytypename_vchr, c.empno_chr a, d.empno_chr b,
       e.patientcardid_chr, f.shortno_chr confdept, g.empno_chr confemp,
       c.lastname_vchr
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
   and a.seqid_chr = ? ";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = null;
            try
            {
                objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = ID.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);


                strSQL = "select a.setstatus_int from t_sys_setting a where a.setid_chr = '9009'";
                objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTempTable);

                //if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                //{
                //    status = dtbResult.Rows[0]["STATUS_INT"].ToString().Trim();
                //    obj.m_strDateOfReception = Convert.ToDateTime(dtbResult.Rows[0]["INVDATE_DAT"].ToString()).ToString("yyyy-MM-dd");
                //    obj.m_decChargeUpCost = Convert.ToDecimal(dtbResult.Rows[0]["ACCTSUM_MNY"].ToString());
                //    obj.m_decPersonCost = Convert.ToDecimal(dtbResult.Rows[0]["SBSUM_MNY"].ToString());
                //    if (status == "2")
                //    {
                //        obj.m_decTotalCost = Convert.ToDecimal(dtbResult.Rows[0]["TOTALSUM_MNY"].ToString()) * -1;
                //    }
                //    else
                //    {
                //        obj.m_decTotalCost = Convert.ToDecimal(dtbResult.Rows[0]["TOTALSUM_MNY"].ToString());
                //    }

                //    if (pstatus == "1" || pstatus == "2")
                //    {
                //        obj.m_decChargeUpCost = Convert.ToDecimal(dtbResult.Rows[0]["ACCTSUM_MNY"].ToString()) * -1;
                //        obj.m_decPersonCost = Convert.ToDecimal(dtbResult.Rows[0]["SBSUM_MNY"].ToString()) * -1;
                //    }
                //    if (m_objTempTable.Rows.Count > 0)
                //    {
                //        if (m_objTempTable.Rows[0][0].ToString().Trim() == "1")
                //        {
                //            obj.m_strCollector = dtbResult.Rows[0]["A"].ToString() + "(" + dtbResult.Rows[0]["lastname_vchr"].ToString() + ")";
                //        }
                //        else
                //        {
                //            obj.m_strCollector = dtbResult.Rows[0]["A"].ToString();
                //        }
                //    }
                //    else
                //    {
                //        obj.m_strCollector = dtbResult.Rows[0]["A"].ToString();
                //    }
                //    obj.m_strAssessor = "(" + dtbResult.Rows[0]["confdept"].ToString().Trim() + ")" + dtbResult.Rows[0]["confemp"].ToString().Trim();
                //    obj.m_strPatientName = dtbResult.Rows[0]["PATIENTNAME_CHR"].ToString();
                //    obj.m_strHospitalName = this.HopitalName;
                //    obj.m_strDocNo = dtbResult.Rows[0]["B"].ToString();
                //    obj.m_strInvoiceNO = dtbResult.Rows[0]["INVOICENO_VCHR"].ToString();
                //    obj.m_strPatientTypeName = dtbResult.Rows[0]["PAYTYPENAME_VCHR"].ToString();
                //    obj.m_strSeriesNumber = dtbResult.Rows[0]["SEQID_CHR"].ToString();
                //    obj.m_strPatientCardID = dtbResult.Rows[0]["patientcardid_chr"].ToString();//卡号
                //    if (dtbResult.Rows[0]["PAYTYPE_INT"].ToString().Trim() == "0")
                //    {
                //        obj.m_strBalanceMode = "现金";
                //    }
                //    else if (dtbResult.Rows[0]["PAYTYPE_INT"].ToString().Trim() == "1")
                //    {
                //        obj.m_strBalanceMode = "银行卡";
                //    }
                //    else if (dtbResult.Rows[0]["PAYTYPE_INT"].ToString().Trim() == "2")
                //    {
                //        obj.m_strBalanceMode = "支票";
                //    }
                //    else if (dtbResult.Rows[0]["PAYTYPE_INT"].ToString().Trim() == "3")
                //    {
                //        obj.m_strBalanceMode = "IC卡";
                //    }
                //}
                //else
                //{
                //    return -1;
                //}
                dtbResult.Dispose();

                strSQL = @"select itemcatid_chr, tolfee_mny as tolfee_mny from t_opr_outpatientrecipeinvde where seqid_chr = ? ";
                if (pstatus == "1" || pstatus == "2")
                {
                    strSQL = @"select itemcatid_chr, -tolfee_mny as tolfee_mny from t_opr_outpatientrecipeinvde where seqid_chr = ? ";
                }
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = ID.Trim();
                long ret = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtDept, objParamArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;
                //if (ret > 0 && dtbResult != null)
                //{
                //    for (int i = 0; i < dtbResult.Rows.Count; i++)
                //    {
                //        string cat = dtbResult.Rows[i]["ITEMCATID_CHR"].ToString();
                //        decimal val = Convert.ToDecimal(dtbResult.Rows[i]["TOLFEE_MNY"].ToString());

                //        if (cat == "0001")
                //        {
                //            obj.m_decXyf += val;
                //        }
                //        else if (cat == "0002")
                //        {
                //            obj.m_decZchyf += val;
                //        }
                //        else if (cat == "0003")
                //        {
                //            obj.m_decZcayf += val;
                //        }
                //        else if (cat == "0004")
                //        {
                //            obj.m_decZjf += val;
                //        }
                //        else if (cat == "0005")
                //        {
                //            obj.m_decLgcwf += val;
                //        }
                //        else if (cat == "0006")
                //        {
                //            obj.m_decCTf += val;
                //        }
                //        else if (cat == "0007")
                //        {
                //            obj.m_decMRIf += val;
                //        }
                //        else if (cat == "0008")
                //        {
                //            obj.m_decSxf += val;
                //        }
                //        else if (cat == "0009")
                //        {
                //            obj.m_decSyf += val;
                //        }
                //        else if (cat == "0010")
                //        {
                //            obj.m_decSsf += val;
                //        }
                //        else if (cat == "0011")
                //        {
                //            obj.m_decQtf += val;
                //        }
                //        else if (cat == "0012")
                //        {
                //            obj.m_decTxfwf += val;
                //        }
                //        else if (cat == "0013")
                //        {
                //            obj.m_decClf += val;
                //        }
                //        else if (cat == "0014")
                //        {
                //            //B超费归属检查费
                //            //obj.m_decBCf += val;
                //            obj.m_decJcf += val;
                //        }
                //        else if (cat == "0015")
                //        {
                //            obj.m_decGHf += val;
                //        }
                //        else if (cat == "0016")
                //        {
                //            obj.m_decPgjf += val;
                //        }
                //        else if (cat == "0017")
                //        {
                //            obj.m_decJcf += val;
                //        }
                //        else if (cat == "0018")
                //        {
                //            obj.m_decJyf += val;
                //        }
                //        else if (cat == "0019")
                //        {
                //            obj.m_decZlf += val;
                //        }
                //        else if (cat == "0020")
                //        {
                //            obj.m_decHlf += val;
                //        }
                //        else if (cat == "0021")
                //        {
                //            obj.m_decSngjf += val;
                //        }
                //        else
                //        {
                //            obj.m_decQtf += val;
                //        }
                //    }
                //}
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objHRPSvc = null;
            }
            return lngRes;
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

        #region 获取项目住院发票分类
        /// <summary>
        /// 获取项目住院发票分类
        /// </summary>
        /// <param name="p_strItemID"></param>
        /// <param name="p_hasCat"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetIPInvoCat(string p_strItemID, out Hashtable p_hasCat)
        {
            long lngRes = 0;

            p_hasCat = new Hashtable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                string SQL = @"select t.itemid_chr, t.itemipinvtype_chr from t_bse_chargeitem t where t.itemid_chr in (" + p_strItemID + ")";

                DataTable dt = new DataTable();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (lngRes > 0)
                {
                    string strItemID = string.Empty;
                    DataRow dr = null;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];

                        strItemID = dr["itemid_chr"].ToString();

                        if (!p_hasCat.ContainsKey(strItemID))
                        {
                            p_hasCat.Add(strItemID, dr["itemipinvtype_chr"].ToString().Substring(2, 2));
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

        #region 验证某一医生当天是否给某一病人开过处方
        /// <summary>
        /// 验证某一医生当天是否给某一病人开过处方
        /// </summary>
        /// <param name="p_strPatientId"></param>
        /// <param name="p_strDoctorId"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnValidatePatientRecipeByDoctor(string p_strPatientId, string p_strDoctorId)
        {
            bool blnResult = false;

            com.digitalwave.iCare.middletier.common.clsGetCurrentTime objCurTime = new com.digitalwave.iCare.middletier.common.clsGetCurrentTime();
            DateTime dtNow = objCurTime.m_mthGetCurrentDateTime();
            objCurTime.Dispose();
            objCurTime = null;

            string strSQL = @"select 1
                              from t_opr_outpatientrecipe t
                             where t.patientid_chr = ?
                               and t.diagdr_chr = ?
                               and t.recorddate_dat between ? and ?
                               and t.pstauts_int = 2";
            clsHRPTableService objHRPServ = null;
            DataTable dtbTemp = null;
            long lngRes = 0;
            try
            {
                IDataParameter[] objParamArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = p_strPatientId;
                objParamArr[1].Value = p_strDoctorId;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = Convert.ToDateTime(dtNow.ToString("yyyy-MM-dd 00:00:00"));
                objParamArr[3].DbType = DbType.DateTime;
                objParamArr[3].Value = Convert.ToDateTime(dtNow.ToString("yyyy-MM-dd 23:59:59"));
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParamArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objHRPServ = null;
            }
            if (lngRes > 0 && dtbTemp != null && dtbTemp.Rows.Count > 0)
            {
                blnResult = true;
            }

            return blnResult;
        }
        #endregion

        #region 验证发票是否是当前医生所领
        /// <summary>
        /// 验证发票是否是当前医生所领
        /// </summary>
        /// <param name="p_strEmpId"></param>
        /// <param name="p_strInvoiceNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckInvoice(string p_strEmpId, string p_strInvoiceNo)
        {
            bool blnResult = false;
            string strLetter = System.Text.RegularExpressions.Regex.Replace(p_strInvoiceNo, @"[^A-Za-z]*", "");
            Int64 intNumeric = 0;
            Int64.TryParse(System.Text.RegularExpressions.Regex.Replace(p_strInvoiceNo, @"^[A-Za-z]*", ""), out intNumeric);
            com.digitalwave.iCare.middletier.common.clsGetCurrentTime objCurTime = new com.digitalwave.iCare.middletier.common.clsGetCurrentTime();
            DateTime dtNow = objCurTime.m_mthGetCurrentDateTime();
            objCurTime.Dispose();
            objCurTime = null;

            string strSQL = @"select appid_chr, invoicenofrom_vchr, invoicenoto_vchr, apply_dat,
                                       appuserid_chr, operatorid_chr, canceluserid_chr, status_int,
                                       cancel_dat, invoicetypeid_int
                                  from t_opr_opinvoiceman
                                 where invoicenofrom_vchr like ?
                                   and appuserid_chr = ?
                                   and status_int = 0
                                   and invoicetypeid_int = 0";
            clsHRPTableService objHRPServ = null;
            DataTable dtbTemp = null;
            long lngRes = 0;
            try
            {
                IDataParameter[] objParamArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = strLetter + "%";
                objParamArr[1].Value = p_strEmpId;
                //objParamArr[2].Value = p_strEmpId;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParamArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objHRPServ = null;
            }
            if (lngRes > 0 && dtbTemp != null)
            {
                DataRow dr = null;
                Int64 intfrom = 0;
                Int64 intto = 0;
                for (int i1 = 0; i1 < dtbTemp.Rows.Count; i1++)
                {
                    dr = dtbTemp.Rows[i1];
                    Int64.TryParse(System.Text.RegularExpressions.Regex.Replace(dr["invoicenofrom_vchr"].ToString().Trim(), "^[A-Za-z]*", ""), out intfrom);
                    Int64.TryParse(System.Text.RegularExpressions.Regex.Replace(dr["invoicenoto_vchr"].ToString().Trim(), "^[A-Za-z]*", ""), out intto);
                    if (intNumeric >= intfrom && intNumeric <= intto)
                    {
                        blnResult = true;
                        break;
                    }
                }
            }

            return blnResult;
        }
        #endregion

        #region 获取特殊门诊身份id
        /// <summary>
        /// </summary>
        /// <param name="strParmcode">参数代码</param>
        /// <param name="lstSpecialOpTypeid">身份数组</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSpecialOpTypeid(string strParmcode, ref System.Collections.Generic.List<string> lstSpecialOpTypeid)
        {
            long lngRes = 0;
            string strSQL = @"select syscode_chr,
                                       parmcode_chr,
                                       parmdesc_vchr,
                                       parmvalue_vchr,
                                       status_int,
                                       note_vchr
                                  from t_bse_sysparm a
                                 where a.parmcode_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = strParmcode;
                DataTable dtbTemp = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objDPArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbTemp != null)
                {
                    if (dtbTemp.Rows.Count > 0)
                    {
                        string[] strTypeid = dtbTemp.Rows[0]["parmvalue_vchr"].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (strTypeid == null || strTypeid.Length == 0)
                        {
                            // TODO: null
                        }
                        else
                        {
                            lstSpecialOpTypeid = new System.Collections.Generic.List<string>(strTypeid);
                        }
                    }
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

        #region 获取发票记帐金额
        /// <summary>
        /// 获取发票记帐金额
        /// </summary>
        /// <param name="p_strSeqID"></param>
        /// <param name="p_decAcctSum"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInvoAcctSumBySeqID(string p_strSeqID, ref decimal p_decAcctSum)
        {
            long lngRes = 0;
            string SQL = @"select t.acctsum_mny from t_opr_outpatientrecipeinv t where t.seqid_chr = ?";
            p_decAcctSum = 0;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strSeqID;

                DataTable dt = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != string.Empty)
                    {
                        p_decAcctSum = decimal.Parse(dt.Rows[0][0].ToString());
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

        #region 茶山查询自助机尚未打印的发票列表
        /// <summary>
        /// 茶山查询自助机尚未打印的发票列表
        /// </summary>
        /// <param name="p_blnHavePrint">查看已打印</param>
        /// <param name="p_dtInvo_Start"></param>
        /// <param name="p_dtInvo_End"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetSelfHelpInvo_NotPrint(bool p_blnHavePrint, DateTime p_dtInvo_Start, DateTime p_dtInvo_End, string strEmpNo, out DataTable p_dtbResult)
        {
            p_dtbResult = null;
            long lngRes = -1;
            clsHRPTableService objSvc = null;
            try
            {
                objSvc = new clsHRPTableService();
                string strSQL = "";
                System.Collections.Generic.List<string> lstParam = new System.Collections.Generic.List<string>();
                string sqlSub = "";
                if (!string.IsNullOrEmpty(strEmpNo))
                {
                    sqlSub = "and a.empno_chr = '" + strEmpNo + "'";
                }
                if (p_blnHavePrint)
                {
                    strSQL = @"select t.seqid_chr as seqid, 
       t.recorddate_dat    as invodate,
       t.invoiceno_vchr    as invono,
       t.patientid_chr     as patientid,
       t.patientname_chr   as patientname,
       t.totalsum_mny      as invomoney,
       t.opremp_chr        as chargeempid,
       t.paytypeid_chr     as paytpeid,
       a.lastname_vchr     as chargeempname,
       b.patientcardid_chr as patientcard,
       c.paytypename_vchr  as paytpyename,
       t2.repprninvono_vchr as repinvono
  from t_opr_outpatientrecipeinv t,
       t_opr_invoicerepeatprint t2,
       t_bse_employee            a,
       t_bse_patientcard         b,
       t_bse_patientpaytype      c
 where t.opremp_chr = a.empid_chr(+)
   and t.patientid_chr = b.patientid_chr(+)
   and t.paytypeid_chr = c.paytypeid_chr(+)
   and t2.seqid_chr = t.seqid_chr
   and t2.sourceinvono_vchr = t.invoiceno_vchr
   and t2.type_chr = '1'
   and t2.printstatus_int >= 0
   and t.isvouchers_int = 1 " + sqlSub + @"
   and not exists (select 1
          from t_opr_outpatientrecipeinv t1
         where t1.invoiceno_vchr = t.invoiceno_vchr
         and (t1.status_int = 0 or t1.status_int = 2))
   and t.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss') 
 order by t.recorddate_dat";
                    lstParam.Add(p_dtInvo_Start.ToString("yyyy-MM-dd HH:mm:ss"));
                    lstParam.Add(p_dtInvo_End.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    strSQL = @"select t.seqid_chr as seqid, 
       t.recorddate_dat    as invodate,
       t.invoiceno_vchr    as invono,
       t.patientid_chr     as patientid,
       t.patientname_chr   as patientname,
       t.totalsum_mny      as invomoney,
       t.opremp_chr        as chargeempid,
       t.paytypeid_chr     as paytpeid,
       a.lastname_vchr     as chargeempname,
       b.patientcardid_chr as patientcard,
       c.paytypename_vchr  as paytpyename,
       '' as repinvono
  from t_opr_outpatientrecipeinv t,
       t_bse_employee            a,
       t_bse_patientcard         b,
       t_bse_patientpaytype      c
 where t.opremp_chr = a.empid_chr(+)
   and t.patientid_chr = b.patientid_chr(+)
   and t.paytypeid_chr = c.paytypeid_chr(+)
   and t.isvouchers_int = 1 " + sqlSub + @"
   and not exists (select 1
          from t_opr_outpatientrecipeinv t1
         where t1.invoiceno_vchr = t.invoiceno_vchr
         and (t1.status_int = 0 or t1.status_int = 2))
   and not exists
 (select 1
          from t_opr_invoicerepeatprint t2
         where t2.seqid_chr = t.seqid_chr
           and t2.sourceinvono_vchr = t.invoiceno_vchr
           and t2.type_chr = '1'
           and t2.printstatus_int >= 0)
   {0} 
 order by t.recorddate_dat";
                    string strSubSql = "";
                    if (p_dtInvo_Start != DateTime.MinValue && p_dtInvo_End != DateTime.MinValue)
                    {
                        strSubSql = @" and t.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss') ";
                        lstParam.Add(p_dtInvo_Start.ToString("yyyy-MM-dd HH:mm:ss"));
                        lstParam.Add(p_dtInvo_End.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    strSQL = string.Format(strSQL, strSubSql);
                }
                int intParamCount = lstParam.Count;
                if (intParamCount > 0)
                {
                    IDataParameter[] objParamArr = null;
                    objSvc.CreateDatabaseParameter(intParamCount, out objParamArr);
                    for (int i1 = 0; i1 < intParamCount; i1++)
                    {
                        objParamArr[i1].Value = lstParam[i1];
                    }
                    lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objParamArr);
                }
                else
                {
                    lngRes = objSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                if (objSvc != null)
                {
                    objSvc.Dispose();
                    objSvc = null;
                }
            }
            return lngRes;
        }
        #endregion

        #region 检查发票号是否已用
        /// <summary>
        /// 检查发票号是否已用
        /// </summary>
        /// <param name="strInvoiceNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckInvoice(string strInvoiceNo)
        {
            bool b = false;
            long lngRes = 0;
            string strSQL = @"select invoiceno_vchr as invono
  from t_opr_outpatientrecipeinv
 where invoiceno_vchr = ?
union all
select repprninvono_vchr as invono
  from t_opr_invoicerepeatprint
 where /*type_chr = '1'
   and*/ repprninvono_vchr = ?
union all
select invno_chr as invono
  from t_opr_patientregister
 where invno_chr = ?";

            DataTable dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = strInvoiceNo;
                ParamArr[1].Value = strInvoiceNo;
                ParamArr[2].Value = strInvoiceNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    b = true;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return b;
        }
        #endregion

        #region 获取医院的名称
        /// <summary>
        /// 获取医院的名称
        /// </summary>
        /// <param name="strInvoiceNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_mthGetHospitalName()
        {
            long lngRes = 0;
            string HospitalName = string.Empty;
            string strSQL = @"select hospital_name_chr from t_bse_hospitalinfo";

            DataTable dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    HospitalName = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return HospitalName;
        }
        #endregion

        #region 查询口服类用药用法ID
        /// <summary>
        /// 查询口服类用药用法ID
        /// </summary>
        /// <param name="p_strParmCode"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetMedUsageID(string p_strParmCode, ref DataTable dtResult)
        {
            long lngRes = 0;

            string strSQL = @"select t.parmvalue_vchr, t.note_vchr, t.status_int from t_bse_sysparm t where t.parmcode_chr = ?";
            HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                System.Data.IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strParmCode;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }

            return lngRes;
        }
        #endregion

        #region 先诊疗后结算病人，调处方缴费时，找出以前缴费的流水号
        /// <summary>
        /// 先诊疗后结算病人，调处方缴费时，找出以前缴费的流水号
        /// </summary>
        /// <param name="strRecipeNo"></param>
        /// <param name="strSeqid"></param>
        /// <returns></returns>
        public long m_lngGetRecipeByRecipeNo(string strRecipeNo, out string strSeqid)
        {
            long lngRes = -1;
            strSeqid = string.Empty;
            string strSQL = @"select a.outpatrecipeid_chr,
                                       a.patientid_chr,
                                       a.createdate_dat,
                                       a.registerid_chr,
                                       a.diagdr_chr,
                                       a.diagdept_chr,
                                       a.recordemp_chr,
                                       a.recorddate_dat,
                                       a.pstauts_int,
                                       a.recipeflag_int,
                                       a.outpatrecipeno_vchr,
                                       a.paytypeid_chr,
                                       a.casehisid_chr,
                                       a.groupid_chr,
                                       a.type_int,
                                       a.confirm_int,
                                       a.confirmdesc_vchr,
                                       a.createtype_int,
                                       a.deptmed_int,
                                       a.archtakeflag_int,
                                       a.printed_int,
                                       a.chargedeptid_chr,
                                       b.coalitionrecipeflag_int,c.seqid_chr,a.isgreen_int
                                  from t_opr_outpatientrecipe a, t_bse_patientpaytype b,t_opr_outpatientrecipeinv c 
                                 where a.paytypeid_chr = b.paytypeid_chr(+)
                                    and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                                   and a.pstauts_int = 2
                                   and a.outpatrecipeid_chr = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objPara = null;
            DataTable dtResult = new DataTable();
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objPara);
                objPara[0].Value = strRecipeNo;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objPara);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    strSeqid = dtResult.Rows[0]["seqid_chr"].ToString();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEx);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return lngRes;
        }
        #endregion

        #region 根据病人ID查询病人是否符合先诊疗后结算
        /// <summary>
        /// 根据病人ID查询病人是否符合先诊疗后结算
        /// </summary>
        /// <param name="p_strPatientID"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetIfVipByPatientID(string p_strPatientID, ref DataTable dtResult)
        {
            long lngRes = 0;

            string strSQL = @"select t.isvip_int
                                from t_bse_patient t
                               where t.patientid_chr = ?";
            HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                System.Data.IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strPatientID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }

            return lngRes;
        }
        #endregion

        #region 社保患者查找当日就诊编号
        /// <summary>
        /// 社保患者查找当日就诊编号
        /// </summary>
        /// <param name="regDate"></param>
        /// <param name="deptId"></param>
        /// <param name="doctId"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetOpRegNo(string regDate, string deptId, string doctId, string pid)
        {
            DataTable dtResult = null;
            string strSQL = @"select regNo, regDate, pid, deptId, doctId, diagCode
                                  from opRegNo t
                                 where t.regdate = ?
                                   and t.deptid = ?
                                   and t.doctid = ?
                                   and t.pid = ?";
            HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = regDate;
                objParamArr[1].Value = deptId;
                objParamArr[2].Value = doctId;
                objParamArr[3].Value = pid;
                objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return dtResult;
        }
        #endregion
        
        #region 根据处方号判断一张处方是否已收费
        /// <summary>
        /// 根据处方号判断一张处方是否已收费
        /// </summary>
        /// <param name="recno"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool CheckRecipeIsCharge(string recno)
        {
            long lngRes = 0;
            bool blnRet = false;

            string SQL = @"select count(a.outpatrecipeid_chr) as nums
                           from t_opr_outpatientrecipe a                              
                           where (a.pstauts_int = 2 or a.pstauts_int = 3)
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

        #region 获取体检套餐信息
        /// <summary>
        /// 获取体检套餐信息
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetPeCluster()
        {
            string Sql = string.Empty;
            DataTable dt = null;
            clsHRPTableService svcPe = null;
            try
            {
                Sql = @"select clus_code, clus_name, '' as py_code, '' as wb_code from code_cluster";
                svcPe = new clsHRPTableService();
                svcPe.m_mthSetDataBase_Selector(1, 15);
                svcPe.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "peCluster";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                svcPe.Dispose();
                svcPe = null;
            }
            return dt;
        }
        #endregion

        #region 获取体检组合信息
        /// <summary>
        /// 获取体检组合信息
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetPeComb()
        {
            string Sql = string.Empty;
            DataTable dt = null;
            clsHRPTableService svcPe = null;
            try
            {
                Sql = @"select comb_code, comb_name, '' as py_code, '' as wb_code from code_itemcomb";
                svcPe = new clsHRPTableService();
                svcPe.m_mthSetDataBase_Selector(1, 15);
                svcPe.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "peComb";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                svcPe.Dispose();
                svcPe = null;
            }
            return dt;
        }
        #endregion

    }
    #endregion

}
