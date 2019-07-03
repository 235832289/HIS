using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 操作类
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsDoctorChargeSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 5.6	自助缴费确认 保存数据(统一保存) HISReg_SVC->clsOPChargeSvc里的方法
        /// <summary>
        /// 自助缴费确认 保存数据(统一保存)
        /// </summary>
        /// <param name="clsVO">主处方信息</param>
        /// <param name="strRecipeNo"></param>
        /// <param name="objRD_VO"></param>
        /// <param name="times"></param>
        /// <param name="objRD_VO"></param>
        /// <param name="objInvoice_VOArr"></param>
        /// <param name="objArr1"></param>
        /// <param name="objArr2"></param>
        /// <returns>-3代表配药,发药窗口停止</returns>
        public long m_mthSaveAllData(ArrayList objVOMainArr, out string strRecipeNo,
            clsRecipeDetail_VO[] objRD_VO, decimal times, clsInvoice_VO[] objInvoice_VOArr, ArrayList[] objArr1, ArrayList[] objArr2, ArrayList objMedicineSend, out ArrayList m_objMedicineSend, string strOpChargeDeptId)
        {
            long lngRes = 0, lngAffects = 0;
            m_objMedicineSend = new ArrayList();
            strRecipeNo = "";
            try
            {
                #region 保存处方主表
                string strGroupID = "";
                DataTable tempDt;
                string strSQL = "";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                DataTable dt = new DataTable();
                foreach (clsOutPatientRecipe_VO objTempMain in objVOMainArr)
                {
                    lngRes = this.m_lngGetGroupEmp(objHRPSvc, objTempMain.m_strDoctorID, out tempDt);
                    if (lngRes > 0 && tempDt.Rows.Count > 0)
                    {
                        strGroupID = tempDt.Rows[0]["groupid_chr"].ToString();
                    }
                    this.m_mthDeleteRecipeDetail(objTempMain.m_strOutpatRecipeID.Trim());

                    //处方号关联表                   
                    strSQL = @"select seqid, outpatrecipeid_chr from t_opr_reciperelation where seqid = ? and outpatrecipeid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                    ParamArr[1].Value = objTempMain.m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                    if (dt.Rows.Count > 0)
                    {
                        strSQL = @"update t_opr_reciperelation set mcflag_int = 1 where seqid = ? and outpatrecipeid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ((clsOutPatientRecipe_VO)objVOMainArr[0]).m_strOutpatRecipeID;
                        ParamArr[1].Value = objTempMain.m_strOutpatRecipeID;

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
                                             groupid_chr, casehisid_chr, type_int, createtype_int, deptmed_int,chargedeptid_chr,isgreen_int
                                            )
                                     values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
                                             ?, ?, ?, ?,
                                             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?,
                                             ?, ?, ?, ?, ?, ?,?
                                            )";

                    objHRPSvc.CreateDatabaseParameter(18, out ParamArr);
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
                    ParamArr[17].Value = 1;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //根据处方号更新检验、检查等项目收费标志(已收费)
                    strSQL = @"update t_opr_attachrelation set status_int = 1 where sourceitemid_vchr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    //收费中间表 -- need modify
                    //                    strSQL = @"update t_mid_pechargeinfo
                    //   set pstauts_int = 2
                    // where mid_charginfo_id_chr =?";
                    //                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    //                    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID;

                    //                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    //申请单中间表 -- need modify
                    //                    strSQL = @"update t_patientpe
                    //   set charged = 1
                    // where mid_charginfo_id_chr =? ";
                    //                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    //                    ParamArr[0].Value = objTempMain.m_strOutpatRecipeID.Trim();

                    //                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);


                    //------------------------------------------------------
                    //增加检验申请的时间处理
                    DateTime objDtmp = DateTime.Parse(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //by huafeng.xiao 2010年1月6日14:35:11
                    strSQL = @"update t_opr_lis_application a
   set a.application_dat = ?
 where a.pstatus_int = 2
   and exists (select 1
          from t_opr_attachrelation c
         where c.sysfrom_int = 1
           and c.attachtype_int = 3
           and c.attachid_vchr = a.application_id_chr
           and c.sourceitemid_vchr = ?) ";
                    ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].DbType = DbType.DateTime;
                    ParamArr[0].Value = objDtmp;
                    ParamArr[1].DbType = DbType.String;
                    ParamArr[1].Value = objTempMain.m_strOutpatRecipeID;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    //---------------------------------------------------------

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
                    Hashtable hasRecipe = new Hashtable();
                    foreach (clsMedrecipesend_VO item3 in objMedicineSend)
                    {
                        string strWindowID = item3.m_strSendWINDOWID_CHR;

                        if (item3.m_strSendWINDOWID_CHR == null || item3.m_strSendWINDOWID_CHR.Trim() == "")
                        {
                            throw (new System.Exception("还没有设置相应的发药窗口，或当前所有的发药窗口都不在工作中！"));
                            //回滚事务
                            //-3代表配药,发药窗口停止
                            return -3;
                        }
                        item3.m_strOUTPATRECIPEID_CHR = objTempMain.m_strOutpatRecipeID;
                        strSQL = @"insert into t_opr_medrecipesend
                                                (outpatrecipeid_chr, recipetype_int, medstoreid_chr,
                                                 windowid_chr, pstatus_int, senddate_dat, sendemp_chr,sendwindowid
                                                )
                                         values (?, ?, ?,
                                                 ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?,?
                                                )";

                        objHRPSvc.CreateDatabaseParameter(8, out ParamArr);
                        ParamArr[0].Value = item3.m_strOUTPATRECIPEID_CHR;
                        ParamArr[1].Value = item3.m_strRECIPETYPE_INT;
                        ParamArr[2].Value = item3.m_strMedstroeID_CHR;
                        ParamArr[3].Value = item3.m_strWINDOWID_CHR;
                        ParamArr[4].Value = item3.m_intPSTATUS_INT;
                        ParamArr[5].Value = item3.m_strSENDDATE_DAT;
                        ParamArr[6].Value = item3.m_strSENDEMP_CHR;
                        ParamArr[7].Value = item3.m_strSendWINDOWID_CHR;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                        clsMedrecipesend_VO obj = new clsMedrecipesend_VO();
                        obj.m_intPSTATUS_INT = item3.m_intPSTATUS_INT;
                        obj.m_intSID = item3.m_intSID;
                        obj.m_strFlag = item3.m_strFlag;
                        obj.m_strMedstroeID_CHR = item3.m_strMedstroeID_CHR;
                        obj.m_strOUTPATRECIPEID_CHR = item3.m_strOUTPATRECIPEID_CHR;
                        obj.m_strRECIPETYPE_INT = item3.m_strRECIPETYPE_INT;
                        obj.m_strSENDDATE_DAT = item3.m_strSENDDATE_DAT;
                        obj.m_strSENDEMP_CHR = item3.m_strSENDEMP_CHR;
                        obj.m_strSendWINDOWID_CHR = item3.m_strSendWINDOWID_CHR;
                        obj.m_strSendWINDOWName_VCHR = item3.m_strSendWINDOWName_VCHR;
                        obj.m_strSerNO = item3.m_strSerNO;
                        obj.m_strTREATDATE_DAT = item3.m_strTREATDATE_DAT;
                        obj.m_strTREATEMP_CHR = item3.m_strTREATEMP_CHR;
                        obj.m_strWINDOWID_CHR = item3.m_strWINDOWID_CHR;
                        obj.Sortno = item3.Sortno;

                        m_objMedicineSend.Add(obj);
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
                //                                       select ?, substr (to_char(seq_recipesendnum.nextval), -4), ?, ?, ?, ?, 1, 0
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
                //                                                                 values (seq_medstore.nextval, ?, ?, ?, ?, ?, ?, ?)";

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

                Hashtable hasInvoCat = new Hashtable();

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

                    DataTable dtTmp = new DataTable();
                    strSQL = @"select t.itemopinvtype_chr from t_bse_chargeitem t where t.itemid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = objRD_VO[i].strCharegeItemID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTmp, ParamArr);
                    if (lngRes > 0)
                    {
                        if (dtTmp.Rows.Count == 1)
                        {
                            if (hasInvoCat.ContainsKey(dtTmp.Rows[0][0].ToString()))
                            {
                                hasInvoCat[dtTmp.Rows[0][0].ToString()] = decimal.Parse(hasInvoCat[dtTmp.Rows[0][0].ToString()].ToString()) + objRD_VO[i].decSumMoney * objRD_VO[i].decDiscount / 100;
                            }
                            else
                            {
                                hasInvoCat.Add(dtTmp.Rows[0][0].ToString(), objRD_VO[i].decSumMoney * objRD_VO[i].decDiscount / 100);
                            }
                        }
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
                                             baseseqid_chr, groupid_chr, confirmdeptid_chr, split_int,isvouchers_int,chargedeptid_chr
                                            )
                                     values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?,
                                             ?, ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
                                             ?, ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?,
                                             ?, ?, ?, ?,?,?
                                            )";

                    objHRPSvc.CreateDatabaseParameter(27, out ParamArr);
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
                    //  ParamArr[25].Value = objInvoice_VOArr[i2].m_decYOUFUSUM_MNY;
                    ParamArr[25].Value = 1;//凭证
                    ParamArr[26].Value = strOpChargeDeptId;

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

                    ArrayList objTmp1 = new ArrayList();
                    Hashtable hasTmp1 = new Hashtable();

                    foreach (clsInvoiceTypeDetail_VO item in objArr1[i2])
                    {
                        objTmp1.Add(int.Parse(item.m_strITEMCATID_CHR));
                        hasTmp1.Add(item.m_strITEMCATID_CHR, item);
                    }

                    objTmp1.Sort();

                    string key = "";
                    for (int k = objTmp1.Count - 1; k >= 0; k--)
                    {
                        key = objTmp1[k].ToString().PadLeft(4, '0');

                        clsInvoiceTypeDetail_VO item = (clsInvoiceTypeDetail_VO)hasTmp1[key];

                        if (split == "1")
                        {
                            itemMoney = m_mthGetSelfPayMoney(objInvoice_VOArr[i2].m_decTOTALSUM_MNY, item.m_decSUM_MNY, objInvoice_VOArr[i2].m_decSBSUM_MNY);
                        }
                        else
                        {
                            if (hasInvoCat.ContainsKey(key))
                            {
                                itemMoney = decimal.Parse(hasInvoCat[key].ToString());
                            }
                        }

                        decSumMoney += decimal.Parse(itemMoney.ToString("0.00"));

                        if (k == 0)
                        {
                            if (decSumMoney != objInvoice_VOArr[i2].m_decSBSUM_MNY)
                            {
                                itemMoney += objInvoice_VOArr[i2].m_decSBSUM_MNY - decSumMoney;
                            }
                        }

                        item.m_strID = objInvoice_VOArr[i2].m_strSEQID_CHR;
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

        #region 获取员工隶属组
        /// <summary>
        /// 根据员工获取员工所在组
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="dtbResult">返回DataTable,groupid_chr组ID</param>
        /// <returns></returns>
        private long m_lngGetGroupEmp(com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc, string EmpID, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = new DataTable();
            string strSQL = @"select a.empid_chr, b.groupid_chr, b.groupname_vchr,b.memo_vchr
  from t_bse_groupemp a, t_bse_groupdesc b
 where a.groupid_chr = b.groupid_chr and a.empid_chr =? and end_dat is null";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = EmpID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
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
        /// <summary>
        /// 删除处方明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
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

        #region 插入药品发送表
        /// <summary>
        /// 插入药品发送表
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="objVOMainArr"></param>
        /// <param name="objWMedicineSend"></param>
        /// <param name="objCMedicineSend"></param>
        /// <returns></returns>
        public long m_mthSaveMedicineSend(ref ArrayList objVOMainArr, ref ArrayList objWMedicineSend, ref ArrayList objCMedicineSend)
        {
            long lngRes = 0;
            string m_strWSid = string.Empty;
            string strSQL = string.Empty;
            DataTable dt = new DataTable();
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
                        //string strSendWindowID = string.Empty;
                        //int waiterNO = 0;
                        //clsWindowsCortrol windCortrol = new clsWindowsCortrol();
                        //clsMedStoreWindowsVo objMedWinVO = new clsMedStoreWindowsVo();
                        //windCortrol.lngGetSendWindowInfoByWindowid(p_objPrincipal, objs.m_strMedstroeID_CHR, objs.m_strWINDOWID_CHR, ref objMedWinVO);
                        //strSendWindowID = objMedWinVO.m_strSendWindowID;
                        //waiterNO = objMedWinVO.m_intSendWindowOrderNo;
                        //qishui.wu 2010-09-10
                        //windCortrol.m_lngGetGiveWindID(p_objPrincipal, objs.m_strWINDOWID_CHR, out strSendWindowID, out waiterNO);
                        if (objs.m_strSendWINDOWID_CHR == null || objs.m_strSendWINDOWID_CHR.Trim() == "")
                            throw (new System.Exception("还没有设置相应的发药窗口，或当前所有的发药窗口都不在工作中！"));
                        string sid = dt.Rows[0][0].ToString();

                        strSQL = @"insert into t_opr_recipesend
                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int,sendwindowid_chr)
                                       select ?, substr (to_char(seq_recipesendnum.nextval), -4), ?, ?, ?, ?, 1, 0,?
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
                    clsMedrecipesend_VO objs = objWMedicineSend[0] as clsMedrecipesend_VO;
                    //string strSendWindowID = string.Empty;
                    //int waiterNO = 0;
                    //clsWindowsCortrol windCortrol = new clsWindowsCortrol();
                    //clsMedStoreWindowsVo objMedWinVO = new clsMedStoreWindowsVo();
                    //windCortrol.lngGetSendWindowInfoByWindowid(p_objPrincipal, objs.m_strMedstroeID_CHR, objs.m_strWINDOWID_CHR, ref objMedWinVO);
                    //strSendWindowID = objMedWinVO.m_strSendWindowID;
                    //waiterNO = objMedWinVO.m_intSendWindowOrderNo;
                    if (objs.m_strSendWINDOWID_CHR == null || objs.m_strSendWINDOWID_CHR.Trim() == "")
                        throw (new System.Exception("还没有设置相应的发药窗口，或当前所有的发药窗口都不在工作中！"));

                    strSQL = @"insert into t_opr_recipesend
                                                (sid_int, serno_chr, patientid_chr, createdate_chr,
                                                 medstoreid_chr, windowid_chr, pstatus_int, autoprint_int,sendwindowid_chr)
                                                 values(?,?,?,?,?,?,1,0,?)";
                    //select ?, substr (to_char(seq_recipesendnum.nextval), -4), ?, ?, ?, ?, 1, 0
                    //  from dual";

                    objHRPSvc.CreateDatabaseParameter(7, out ParamArr);
                    ParamArr[0].Value = m_strWSid;
                    ParamArr[1].Value = ((clsMedrecipesend_VO)objWMedicineSend[0]).m_strSerNO;
                    ParamArr[2].Value = pid;
                    ParamArr[3].Value = date;
                    ParamArr[4].Value = objs.m_strMedstroeID_CHR;
                    ParamArr[5].Value = objs.m_strWINDOWID_CHR;
                    ParamArr[6].Value = objs.m_strSendWINDOWID_CHR;
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
    }
}
