using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.HIS;
using System.Text;

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    /// <summary>
    /// 
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsReportTreatRecipeSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 配药处方信息报表
        /// <summary>
        /// 1.配药处方信息报表
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectTreatRecipe(DateTime strBeginDat, DateTime strEndDat,string strMedstoreid,string p_strTreatEmp,int p_intMedicineType, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            //DataTable dtTemp = new DataTable();
            m_dtbReport = new DataTable();
            string strSql = "";
            if (p_intMedicineType == 2)
            {
                if (strMedstoreid == "10000")
                {
                    if (p_strTreatEmp == "10000")
                    {
                        strSql = @"select empno_chr,
			 lastname_vchr,
			 sum(totalrecipenum) totalrecipenum,
			 sum(totaltreatnum) totaltreatnum,
			 sum(totaltimesnum) totaltimesnum,
			 sum(totalrecipenum) * sum(totaltimesnum) totalmedicinenum
	from (select t4.empno_chr,
							 t4.lastname_vchr,
							 count(distinct t3.outpatrecipeid_chr) totalrecipenum,
							 count(distinct t1.medicineid_chr) totaltreatnum,
							 0 totaltimesnum
					from t_opr_recipesend t2
					left join t_bse_employee t4 on t2.treatemp_chr = t4.empid_chr
					join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
					left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr =
																						 t1.outpatrecipeid_chr
				 where t2.treatdate_dat between ? and ?
				 group by t4.empno_chr, t4.lastname_vchr
				union
				select d.empno_chr,
							 d.lastname_vchr,
							 0 totalrecipenum,
							 0 totaltreatnum,
							 sum(c.times_int) times_int
					from t_opr_recipesend a,
							 t_opr_recipesendentry b,
							 (select distinct outpatrecipeid_chr, times_int
									from t_opr_outpatientcmrecipede) c,
							 t_bse_employee d
				 where a.sid_int = b.sid_int
					 and a.treatemp_chr = d.empid_chr
					 and b.outpatrecipeid_chr = c.outpatrecipeid_chr
					 and a.treatdate_dat between ? and ?
				 group by d.empno_chr, d.lastname_vchr
				 order by empno_chr)
 where empno_chr is not null
 group by empno_chr, lastname_vchr
 order by empno_chr";
                    }
                    else
                    {
                        strSql = @"select empno_chr,
			 lastname_vchr,
			 sum(totalrecipenum) totalrecipenum,
			 sum(totaltreatnum) totaltreatnum,
			 sum(totaltimesnum) totaltimesnum,
			 sum(totalrecipenum) * sum(totaltimesnum) totalmedicinenum
	from (select t4.empno_chr,
							 t4.lastname_vchr,
							 count(distinct t3.outpatrecipeid_chr) totalrecipenum,
							 count(distinct t1.medicineid_chr) totaltreatnum,
							 0 totaltimesnum
					from t_opr_recipesend t2
					left join t_bse_employee t4 on t2.treatemp_chr = t4.empid_chr
					join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
					left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr =
																						 t1.outpatrecipeid_chr
				 where t4.empid_chr = ?
                 and t2.treatdate_dat between ? and ?
				 group by t4.empno_chr, t4.lastname_vchr
				union
				select d.empno_chr,
							 d.lastname_vchr,
							 0 totalrecipenum,
							 0 totaltreatnum,
							 sum(c.times_int) times_int
					from t_opr_recipesend a,
							 t_opr_recipesendentry b,
							 (select distinct outpatrecipeid_chr, times_int
									from t_opr_outpatientcmrecipede) c,
							 t_bse_employee d
				 where a.sid_int = b.sid_int
					 and a.treatemp_chr = d.empid_chr
					 and d.empid_chr = ? 
                     and a.treatdate_dat between ? and ?
					 and b.outpatrecipeid_chr = c.outpatrecipeid_chr
				 group by d.empno_chr, d.lastname_vchr
				 order by empno_chr)
 where empno_chr is not null
 group by empno_chr, lastname_vchr
 order by empno_chr";
                    }
                }
                else
                {
                    if (p_strTreatEmp == "10000")
                    {
                        strSql = @"select empno_chr,
			 lastname_vchr,
			 sum(totalrecipenum) totalrecipenum,
			 sum(totaltreatnum) totaltreatnum,
			 sum(totaltimesnum) totaltimesnum,
			 sum(totalrecipenum) * sum(totaltimesnum) totalmedicinenum
	from (select t4.empno_chr,
							 t4.lastname_vchr,
							 count(distinct t3.outpatrecipeid_chr) totalrecipenum,
							 count(distinct t1.medicineid_chr) totaltreatnum,
							 0 totaltimesnum
					from t_opr_recipesend t2
					left join t_bse_employee t4 on t2.treatemp_chr = t4.empid_chr
					join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
					left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr =
																						 t1.outpatrecipeid_chr
				 where t2.medstoreid_chr = ?
					 and t2.treatdate_dat between ? and ?
				 group by t4.empno_chr, t4.lastname_vchr
				union
				select d.empno_chr,
							 d.lastname_vchr,
							 0 totalrecipenum,
							 0 totaltreatnum,
							 sum(c.times_int) times_int
					from t_opr_recipesend a,
							 t_opr_recipesendentry b,
							 (select distinct outpatrecipeid_chr, times_int
									from t_opr_outpatientcmrecipede) c,
							 t_bse_employee d
				 where a.sid_int = b.sid_int
					 and a.treatemp_chr = d.empid_chr
					 and a.medstoreid_chr = ?
					 and b.outpatrecipeid_chr = c.outpatrecipeid_chr
					 and a.treatdate_dat between ? and ?
				 group by d.empno_chr, d.lastname_vchr
				 order by empno_chr)
 where empno_chr is not null
 group by empno_chr, lastname_vchr
 order by empno_chr";
                    }
                    else
                    {
                        strSql = @"select empno_chr,
			 lastname_vchr,
			 sum(totalrecipenum) totalrecipenum,
			 sum(totaltreatnum) totaltreatnum,
			 sum(totaltimesnum) totaltimesnum,
			 sum(totalrecipenum) * sum(totaltimesnum) totalmedicinenum
	from (select t4.empno_chr,
							 t4.lastname_vchr,
							 count(distinct t3.outpatrecipeid_chr) totalrecipenum,
							 count(distinct t1.medicineid_chr) totaltreatnum,
							 0 totaltimesnum
					from t_opr_recipesend t2
					left join t_bse_employee t4 on t2.treatemp_chr = t4.empid_chr
					join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
					left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr =
																						 t1.outpatrecipeid_chr
				 where t4.empid_chr = ?
					 and t2.medstoreid_chr = ?
					 and t2.treatdate_dat between ? and ?
				 group by t4.empno_chr, t4.lastname_vchr
				union
				select d.empno_chr,
							 d.lastname_vchr,
							 0 totalrecipenum,
							 0 totaltreatnum,
							 sum(c.times_int) times_int
					from t_opr_recipesend a,
							 t_opr_recipesendentry b,
							 (select distinct outpatrecipeid_chr, times_int
									from t_opr_outpatientcmrecipede) c,
							 t_bse_employee d
				 where a.sid_int = b.sid_int
					 and a.treatemp_chr = d.empid_chr
					 and d.empid_chr = ?
					 and a.medstoreid_chr = ?
					 and b.outpatrecipeid_chr = c.outpatrecipeid_chr
					 and a.treatdate_dat between ? and ?
				 group by d.empno_chr, d.lastname_vchr
				 order by empno_chr)
 where empno_chr is not null
 group by empno_chr, lastname_vchr
 order by empno_chr";
                    }
                }
            }
            else
            {
                if (strMedstoreid == "10000")
                {
                    if (p_strTreatEmp == "10000")
                    {
                        strSql = @"select t4.empno_chr,
			 t4.lastname_vchr,
			 count(distinct t3.outpatrecipeid_chr) totalrecipenum,
			 count(distinct t1.medicineid_chr) totaltreatnum
	from t_opr_recipesend t2
	left join t_bse_employee t4 on t2.treatemp_chr = t4.empid_chr
	left join t_bse_deptemp a on t4.empid_chr = a.empid_chr
	left join t_bse_deptdesc b on a.deptid_chr = b.deptid_chr
	join t_bse_medstore c on b.deptid_chr = c.deptid_chr
	join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
	left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr =
																		 t1.outpatrecipeid_chr
	left join t_bse_medstore t5 on t2.medstoreid_chr = t5.medstoreid_chr
                               where t2.treatdate_dat between ? and ? group by t4.empno_chr, t4.lastname_vchr
 order by t4.empno_chr";
                    }
                    else
                    {
                        strSql = @"select t4.empno_chr,
			 t4.lastname_vchr,
			 count(distinct t3.outpatrecipeid_chr) totalrecipenum,
			 count(distinct t1.medicineid_chr) totaltreatnum
	from t_opr_recipesend t2
	left join t_bse_employee t4 on t2.treatemp_chr = t4.empid_chr
	left join t_bse_deptemp a on t4.empid_chr = a.empid_chr
	left join t_bse_deptdesc b on a.deptid_chr = b.deptid_chr
	join t_bse_medstore c on b.deptid_chr = c.deptid_chr
	join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
	left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr =
																		 t1.outpatrecipeid_chr
	left join t_bse_medstore t5 on t2.medstoreid_chr = t5.medstoreid_chr
                               where t4.empid_chr=?
                                 and t2.treatdate_dat between ? and ? group by t4.empno_chr, t4.lastname_vchr
 order by t4.empno_chr";
                    }
                }
                else
                {
                    if (p_strTreatEmp == "10000")
                    {
                        strSql = @"select t4.empno_chr,
			 t4.lastname_vchr,
			 count(distinct t3.outpatrecipeid_chr) totalrecipenum,
			 count(distinct t1.medicineid_chr) totaltreatnum
	from t_opr_recipesend t2
	left join t_bse_employee t4 on t2.treatemp_chr = t4.empid_chr
	left join t_bse_deptemp a on t4.empid_chr = a.empid_chr
	left join t_bse_deptdesc b on a.deptid_chr = b.deptid_chr
	join t_bse_medstore c on b.deptid_chr = c.deptid_chr
	join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
	left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr =
																		 t1.outpatrecipeid_chr
	left join t_bse_medstore t5 on t2.medstoreid_chr = t5.medstoreid_chr
                               where t5.medstoreid_chr=?
                                 and t2.treatdate_dat between ? and ? group by t4.empno_chr, t4.lastname_vchr
 order by t4.empno_chr";
                    }
                    else
                    {
                        strSql = @"select t4.empno_chr,
			 t4.lastname_vchr,
			 count(distinct t3.outpatrecipeid_chr) totalrecipenum,
			 count(distinct t1.medicineid_chr) totaltreatnum
	from t_opr_recipesend t2
	left join t_bse_employee t4 on t2.treatemp_chr = t4.empid_chr
	left join t_bse_deptemp a on t4.empid_chr = a.empid_chr
	left join t_bse_deptdesc b on a.deptid_chr = b.deptid_chr
	join t_bse_medstore c on b.deptid_chr = c.deptid_chr
	join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
	left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr =
																		 t1.outpatrecipeid_chr
	left join t_bse_medstore t5 on t2.medstoreid_chr = t5.medstoreid_chr
                               where t4.empid_chr=?
                                 and t5.medstoreid_chr=?
                                 and t2.treatdate_dat between ? and ? group by t4.empno_chr, t4.lastname_vchr
 order by t4.empno_chr";
                    }
                }
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                int n = -1;
                if (p_intMedicineType == 2)
                {
                    if (strMedstoreid == "10000")
                    {
                        if (p_strTreatEmp == "10000")
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out arrParams);
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(6, out arrParams);
                            arrParams[++n].Value = p_strTreatEmp;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = p_strTreatEmp;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                    else
                    {
                        if (p_strTreatEmp == "10000")
                        {
                            objHRPSvc.CreateDatabaseParameter(6, out arrParams);
                            arrParams[++n].Value = strMedstoreid;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = strMedstoreid;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(8, out arrParams);
                            arrParams[++n].Value = p_strTreatEmp;
                            arrParams[++n].Value = strMedstoreid;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = p_strTreatEmp;
                            arrParams[++n].Value = strMedstoreid;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                }
                else
                {
                    if (strMedstoreid == "10000")
                    {
                        if (p_strTreatEmp == "10000")
                        {
                            objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out arrParams);
                            arrParams[++n].Value = p_strTreatEmp;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                    else
                    {
                        if (p_strTreatEmp == "10000")
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out arrParams);
                            arrParams[++n].Value = strMedstoreid;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out arrParams);
                            arrParams[++n].Value = p_strTreatEmp;
                            arrParams[++n].Value = strMedstoreid;
                            arrParams[++n].Value = Convert.ToDateTime(strBeginDat.ToString("yyyy-MM-dd HH:mm:ss"));
                            arrParams[++n].Value = Convert.ToDateTime(strEndDat.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbReport, arrParams);

                objHRPSvc.Dispose();

                //m_dtbReport.Columns.Add("empno_chr", typeof(string));
                //m_dtbReport.Columns.Add("lastname_vchr", typeof(string));
                //m_dtbReport.Columns.Add("totalrecipenum", typeof(int));
                //m_dtbReport.Columns.Add("totaltreatnum", typeof(int));
                //if (p_intMedicineType == 2)
                //{
                //    m_dtbReport.Columns.Add("totaltimesnum", typeof(int));
                //    m_dtbReport.Columns.Add("totalmedicinenum", typeof(int));
                //}

                //if (dtTemp.Rows.Count > 0)
                //{
                //    DataRow[] drArr = dtTemp.Select("", "empno_chr asc");
                //    DataRow drTemp = null;
                //    int totalrecipenum = 0;
                //    int totaltreatnum = 0;
                //    int totaltimesnum = 0;
                //    int intRowCount = drArr.Length;
                //    for (int i = 0; i < intRowCount; i++)
                //    {
                //        totalrecipenum = 0;
                //        totaltreatnum = 0;
                //        totaltimesnum = 0;
                //        drTemp = m_dtbReport.NewRow();
                //        if (m_blnExist(drArr[i]["empno_chr"].ToString().Trim(), ref m_dtbReport))
                //        {
                //            continue;
                //        }
                //        drTemp["empno_chr"] = drArr[i]["empno_chr"];
                //        drTemp["lastname_vchr"] = drArr[i]["lastname_vchr"];
                //        //totalrecipenum += 1;
                //        //totaltreatnum += 1;

                //        for (int j = i; j < intRowCount; j++)
                //        {
                //            if (drArr[i]["empno_chr"].ToString().Trim() == drArr[j]["empno_chr"].ToString().Trim())
                //            {
                //                //if (drArr[i]["outpatrecipeid_chr"].ToString().Trim() != drArr[j]["outpatrecipeid_chr"].ToString().Trim())
                //                if (!m_blnExistArr(0, j, drArr[i]["empno_chr"].ToString().Trim(), drArr[j]["outpatrecipeid_chr"].ToString().Trim(), ref drArr))
                //                {
                //                    totalrecipenum += 1;
                //                }
                //                //if (drArr[i]["medicineid_chr"].ToString().Trim() != drArr[j]["medicineid_chr"].ToString().Trim())
                //                if (!m_blnExistArr(1, j, drArr[i]["empno_chr"].ToString().Trim(), drArr[j]["medicineid_chr"].ToString().Trim(), ref drArr))
                //                {
                //                    totaltreatnum += 1;
                //                }
                //                if (p_intMedicineType == 2)
                //                {
                //                    totaltimesnum += Convert.ToInt32(drArr[i]["times_int"]);
                //                }
                //            }
                //        }
                //        drTemp["totalrecipenum"] = totalrecipenum;
                //        drTemp["totaltreatnum"] = totaltreatnum;
                //        if (p_intMedicineType == 2)
                //        {
                //            drTemp["totaltimesnum"] = totaltimesnum;
                //            drTemp["totalmedicinenum"] = totaltimesnum * totaltreatnum;
                //        }

                //        m_dtbReport.Rows.Add(drTemp.ItemArray);
                //    }
                //    m_dtbReport.AcceptChanges();
                //    drArr = null;
                //}
                //dtTemp = null;


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
        /// 获取不同的处方号/药品id
        /// </summary>
        /// <param name="intType"></param>
        /// <param name="intj">drArr的第几条数据</param>
        /// <param name="strno">员工号</param>
        /// <param name="p_strid">处方号/药品id</param>
        /// <param name="drArr"></param>
        /// <returns></returns>
        private bool m_blnExistArr(int intType, int intj, string strno, string p_strid, ref DataRow[] drArr)
        {
            bool blnExist = false;
            //int iLength = drArr.Length;
            for (int i = 0; i < intj; i++)
            {
                if (drArr[i]["empno_chr"].ToString().Trim() == strno)
                {
                    if (intType == 0)
                    {
                        if (drArr[i]["outpatrecipeid_chr"].ToString().Trim() == p_strid)
                        {
                            blnExist = true;
                            break;
                        }
                    }
                    else
                    {
                        if (drArr[i]["medicineid_chr"].ToString().Trim() == p_strid)
                        {
                            blnExist = true;
                            break;
                        }
                    }
                }
            }
            return blnExist;
        }

        private bool m_blnExist(string p_empno, ref DataTable m_dtbReport)
        {
            bool blnIsExist = false;
            DataRow dr = null;
            int iRowCount = m_dtbReport.Rows.Count;
            for (int iRow = 0; iRow < iRowCount; iRow++)
            {
                dr = m_dtbReport.Rows[iRow];

                if (dr["empno_chr"].ToString().Trim() == p_empno)
                {
                    blnIsExist = true;
                    break;
                }
            }
            return blnIsExist;
        }
        #endregion

        #region 获取药房名称
        /// <summary>
        /// 1.获取药房名称
        /// </summary>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTreatRecipe(out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();

            string strSql = @"select t1.medstoreid_chr,
                                     t1.medstorename_vchr
                                from t_bse_medstore t1";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_dtbReport);

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

        #region 获取药房对应的类型：1西药；2中药，3材料
        /// <summary>
        /// 获取药房对应的类型：1西药；2中药，3材料
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="m_intMedicineType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineType(string p_strDrugStoreID, out int m_intMedicineType)
        {
            m_intMedicineType = 0;
            long lngRes = -1;
            DataTable m_dtbReport = new DataTable();

            string strSql = @"select a.medicnetype_int
  from t_bse_medstore a
 where a.medstoreid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strDrugStoreID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbReport, ParamArr);
                if (m_dtbReport != null && m_dtbReport.Rows.Count > 0)
                {
                    m_intMedicineType = Convert.ToInt32(m_dtbReport.Rows[0][0]);
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
    }
}
