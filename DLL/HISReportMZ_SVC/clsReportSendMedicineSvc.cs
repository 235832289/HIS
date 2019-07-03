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
    public class clsReportSendMedicineSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 发送药品信息
        /// <summary>
        /// 1.发送药品信息
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectSendMedicine(DateTime strBeginDat, DateTime strEndDat, string strMedstoreid,string p_strTreatEmp, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            DataTable dtTemp = new DataTable();
            m_dtbReport = new DataTable();
            string strSql = "";
            if (strMedstoreid == "10000")
            {
                if (p_strTreatEmp == "10000")
                {
                    strSql = @"select t4.empno_chr,
                                  t4.lastname_vchr,
                                  t3.outpatrecipeid_chr,
                                  t1.medicineid_chr
                             from t_opr_recipesend t2
                                  left join t_bse_employee t4 on t2.sendemp_chr = t4.empid_chr
                                  left join t_bse_deptemp a on t4.empid_chr=a.empid_chr
                                  left join t_bse_deptdesc b on a.deptid_chr=b.deptid_chr
                                  join t_bse_medstore c on b.deptid_chr=c.deptid_chr
                                  join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
                                  left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr = t1.outpatrecipeid_chr
                                  left join t_bse_medstore t5 on t2.medstoreid_chr=t5.medstoreid_chr
                            where t2.pstatus_int=3 
                              and t2.senddate_dat between ? and ?";
                }
                else
                {
                    strSql = @"select t4.empno_chr,
                                  t4.lastname_vchr,
                                  t3.outpatrecipeid_chr,
                                  t1.medicineid_chr
                             from t_opr_recipesend t2
                                  left join t_bse_employee t4 on t2.sendemp_chr = t4.empid_chr
                                  left join t_bse_deptemp a on t4.empid_chr=a.empid_chr
                                  left join t_bse_deptdesc b on a.deptid_chr=b.deptid_chr
                                  join t_bse_medstore c on b.deptid_chr=c.deptid_chr
                                  join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
                                  left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr = t1.outpatrecipeid_chr
                                  left join t_bse_medstore t5 on t2.medstoreid_chr=t5.medstoreid_chr
                            where t2.pstatus_int=3 
                              and t4.empid_chr=?
                              and t2.senddate_dat between ? and ?";
                }
            }
            else
            {
                if (p_strTreatEmp == "10000")
                {
                    strSql = @"select t4.empno_chr,
                                  t4.lastname_vchr,
                                  t3.outpatrecipeid_chr,
                                  t1.medicineid_chr
                             from t_opr_recipesend t2
                                  left join t_bse_employee t4 on t2.sendemp_chr = t4.empid_chr
                                  left join t_bse_deptemp a on t4.empid_chr=a.empid_chr
                                  left join t_bse_deptdesc b on a.deptid_chr=b.deptid_chr
                                  join t_bse_medstore c on b.deptid_chr=c.deptid_chr
                                  join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
                                  left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr = t1.outpatrecipeid_chr
                                  left join t_bse_medstore t5 on t2.medstoreid_chr=t5.medstoreid_chr
                            where t2.pstatus_int=3 
                              and t2.medstoreid_chr=?
                              and t2.treatdate_dat between ? and ?";
                }
                else
                {
                    strSql = @"select t4.empno_chr,
                                  t4.lastname_vchr,
                                  t3.outpatrecipeid_chr,
                                  t1.medicineid_chr
                             from t_opr_recipesend t2
                                  left join t_bse_employee t4 on t2.sendemp_chr = t4.empid_chr
                                  left join t_bse_deptemp a on t4.empid_chr=a.empid_chr
                                  left join t_bse_deptdesc b on a.deptid_chr=b.deptid_chr
                                  join t_bse_medstore c on b.deptid_chr=c.deptid_chr
                                  join t_opr_recipesendentry t3 on t2.sid_int = t3.sid_int
                                  left join t_opr_recipededuct t1 on t3.outpatrecipeid_chr = t1.outpatrecipeid_chr
                                  left join t_bse_medstore t5 on t2.medstoreid_chr=t5.medstoreid_chr
                            where t2.pstatus_int=3 
                              and t4.empid_chr=?
                              and t2.medstoreid_chr=?
                              and t2.treatdate_dat between ? and ?";
                }
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                int n = -1;
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

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtTemp, arrParams);

                objHRPSvc.Dispose();

                m_dtbReport.Columns.Add("empno_chr", typeof(string));
                m_dtbReport.Columns.Add("lastname_vchr", typeof(string));
                m_dtbReport.Columns.Add("totalrecipenum", typeof(int));
                m_dtbReport.Columns.Add("totaltreatnum", typeof(int));

                if (dtTemp.Rows.Count > 0)
                {
                    DataRow[] drArr = dtTemp.Select("", "empno_chr asc");
                    DataRow drTemp = null;
                    int totalrecipenum = 0;
                    int totaltreatnum = 0;

                    int intRowCount = drArr.Length;
                    for (int i = 0; i < intRowCount; i++)
                    {
                        totalrecipenum = 0;
                        totaltreatnum = 0;
                        drTemp = m_dtbReport.NewRow();
                        if (m_blnExist(drArr[i]["empno_chr"].ToString().Trim(), ref m_dtbReport))
                        {
                            continue;
                        }
                        drTemp["empno_chr"] = drArr[i]["empno_chr"];
                        drTemp["lastname_vchr"] = drArr[i]["lastname_vchr"];
                        //totalrecipenum += 1;
                        //totaltreatnum += 1;

                        for (int j = i; j < intRowCount; j++)
                        {
                            if (drArr[i]["empno_chr"].ToString().Trim() == drArr[j]["empno_chr"].ToString().Trim())
                            {
                                //if (drArr[i]["outpatrecipeid_chr"].ToString().Trim() != drArr[j]["outpatrecipeid_chr"].ToString().Trim())
                                if (!m_blnExistArr(0, j, drArr[i]["empno_chr"].ToString().Trim(), drArr[j]["outpatrecipeid_chr"].ToString().Trim(), ref drArr))
                                {
                                    totalrecipenum += 1;
                                }
                                //if (drArr[i]["medicineid_chr"].ToString().Trim() != drArr[j]["medicineid_chr"].ToString().Trim())
                                if (!m_blnExistArr(1, j, drArr[i]["empno_chr"].ToString().Trim(), drArr[j]["medicineid_chr"].ToString().Trim(), ref drArr))
                                {
                                    totaltreatnum += 1;
                                }
                            }
                        }
                        drTemp["totalrecipenum"] = totalrecipenum;
                        drTemp["totaltreatnum"] = totaltreatnum;

                        m_dtbReport.Rows.Add(drTemp.ItemArray);
                    }
                    m_dtbReport.AcceptChanges();
                    drArr = null;
                }
                dtTemp = null;
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
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSendMedicine(out DataTable m_dtbReport)
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
    }
}
