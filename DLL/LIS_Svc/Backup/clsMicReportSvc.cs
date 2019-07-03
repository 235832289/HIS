using System;
using System.Data;
using System.EnterpriseServices;
using System.Security.Principal;
using System.Collections;
using System.Text;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsMicReportSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsMicReportSvc()
        {
        }
        #region 获取所有抗生素
        /// <summary>
        /// 获取所有抗生素
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAllAnti(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;

            string strSQL = @"select t.antiid as 抗生素ID,t.cname as 抗生素名称,t.ename as 英文名称 from t_atb_anti t  order by antiid ";
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;

        }
        #endregion

        #region 模糊查询抗生素
        /// <summary>
        /// 模糊查询抗生素
        /// </summary>
        /// <param name="micName"></param>
        /// <param name="IsEnglish"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetFuzzyQueryAnti(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = null;
            if (IsEnglish)
            {
                strSQL = @"select t.antiid as 抗生素ID,t.cname as 抗生素名称,t.ename as 英文名称 from t_atb_anti t where instr(t.antiid,?)> 0 order by antiid ";
            }
            else
            {
                strSQL = @"select t.antiid as 抗生素ID,t.cname as 抗生素名称,t.ename as 英文名称 from t_atb_anti t where instr(t.cname,?)> 0 order by antiid ";
            }

            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].DbType = DbType.String;
                objDPArr[0].Value = micName;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取所有细菌
        /// <summary>
        /// 获取所有细菌
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
       
        public long lngGetAllMic(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;

            string strSQL = @"select t.germid as 细菌ID,t.cname as 细菌名称,t.ename as 英文名称 from t_atb_germ t order by germid ";
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 模糊查询细菌
        /// <summary>
        /// 模糊查询细菌
        /// </summary>
        /// <param name="micName"></param>
        /// <param name="IsEnglish"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetFuzzyQueryMic(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = null;
            if (IsEnglish)
            {
                strSQL = @"select t.germid as 细菌ID,t.cname as 细菌名称,t.ename as 英文名称 
from t_atb_germ t where instr(t.germid,?)> 0 order by germid ";
            }
            else
            {
                strSQL = @"select t.germid as 细菌ID,t.cname as 细菌名称,t.ename as 英文名称 
from t_atb_germ t where instr(t.cname,?)> 0 order by germid ";
            }

            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].DbType = DbType.String;
                objDPArr[0].Value = micName;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 细菌分布报告统计报表
        /// <summary>
        /// 细菌分布报告统计报表
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetBacteriaDistribution(string micname,DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, out DataTable dtbResult)
        {
            dtbResult=null;
            long lngRes = 0;
          
                      string strSQL = @"select t1.micname,count(*) as miccount
            from t_atb_ResultExe t1
            where t1.exedate between ? and ? ";
            if(!string.IsNullOrEmpty(micname))
            {
                strSQL +=" and t1.micname='"+micname+"' ";
            }
               strSQL +=@"
            and t1.reqno in(
                  select t2.reqno from t_atb_AntiResultBill t2 where t2.samno in(
                        select distinct trim(t3.device_sampleid_chr)  from t_opr_lis_device_relation t3 ,t_opr_lis_app_sample t4,t_opr_lis_application t5
                         where  t3.deviceid_chr='000032' and t3.sample_id_chr=t4.sample_id_chr 
                                and t4.application_id_chr=t5.application_id_chr ";

            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(SamtNo) && string.IsNullOrEmpty(DisNo)&& string.IsNullOrEmpty(Sex) && string.IsNullOrEmpty(AgeFrom) && string.IsNullOrEmpty(AgeTo) && string.IsNullOrEmpty(TestMethod))
                {
                    //没有病人信息的查询
                    strSQL = @"select t1.micname,count(*) as miccount
  from t_atb_ResultExe t1
  where t1.exedate between ? and ? ";
                    if (!string.IsNullOrEmpty(micname))
                    {
                        strSQL += " and t1.micname='" + micname + "' ";
                    }
                    strSQL += @"group by micname order by micname";
                    objHRPServ = new clsHRPTableService();

                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = p_dtDateFrom;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtDateTO;
                }
                else
                {

                    ArrayList arrlParm = new ArrayList();
                    arrlParm.Add(p_dtDateFrom);
                    arrlParm.Add(p_dtDateTO);
                    if (!string.IsNullOrEmpty(Sex))
                    {
                        strSQL += " and trim(t5.sex_chr)=? ";
                        arrlParm.Add(Sex);
                    }
                    if (!string.IsNullOrEmpty(AgeFrom) && !string.IsNullOrEmpty(AgeTo))
                    {
                        strSQL += " and substr(regexp_replace(t5.age_chr,'[^0-9]'),1,3) between ? and ? ";
                        arrlParm.Add(AgeFrom);
                        arrlParm.Add(AgeTo);
                    }
                    if (!string.IsNullOrEmpty(DisNo))
                    {
                        strSQL += " and t5.patient_type_id_chr=? ";
                        arrlParm.Add(DisNo);
                    }
                    if (!string.IsNullOrEmpty(SamtNo))
                    {
                        strSQL += " and t5.sample_type_vchr=? ";
                        arrlParm.Add(SamtNo);
                    }

                    strSQL += "  ))group by micname order by micname ";
                    objHRPServ = new clsHRPTableService();
                    objHRPServ.CreateDatabaseParameter(arrlParm.Count, out objDPArr);
                    for (int i = 0; i < arrlParm.Count; i++)
                    {
                        objDPArr[i].Value = arrlParm[i];
                    }
                }
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }            


            return lngRes;
        }
        #endregion

        #region 累计敏感性报表
        /// <summary>
        /// 累计敏感性报表
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetMicSensitive(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;

            string strSQL = @"   select antiname,count(micexplain) as miccount ,
       sum(case when micexplain='S' then 1 else 0 end) as sensitive,
       sum(case when micexplain='I' then 1 else 0 end) as intermediary,
       sum(case when micexplain='R' then 1 else 0 end) as resistance
    from(
        SELECT a.reqno,a.antiname,a.micexplain,b.micname
        FROM  t_atb_ResultMic a, t_atb_ResultExe b
        where a.reqno=b.reqno and a.exeno=b.exeno ";
            if(!string.IsNullOrEmpty(strTempAntiID))
            {
              strSQL +=" and a.antiid='"+strTempAntiID+"' ";
            }
         strSQL +=@" and b.exedate between ? and ?
         and b.micname=?
         and b.reqno in(
               select t2.reqno from t_atb_AntiResultBill t2 where t2.samno in(
                  select trim(t3.device_sampleid_chr)  from t_opr_lis_device_relation t3 ,t_opr_lis_app_sample t4,t_opr_lis_application t5
                   where  t3.deviceid_chr='000032' and t3.sample_id_chr=t4.sample_id_chr 
                          and t4.application_id_chr=t5.application_id_chr ";
            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(SamtNo) && string.IsNullOrEmpty(DisNo) && string.IsNullOrEmpty(Sex) && string.IsNullOrEmpty(AgeFrom) && string.IsNullOrEmpty(AgeTo) && string.IsNullOrEmpty(TestMethod))
                {
                    //没有病人信息的查询
                    strSQL = @"   select antiname,count(micexplain) as miccount ,
       sum(case when micexplain='S' then 1 else 0 end) as sensitive,
       sum(case when micexplain='I' then 1 else 0 end) as intermediary,
       sum(case when micexplain='R' then 1 else 0 end) as resistance
    from(
        SELECT a.reqno,a.antiname,a.micexplain,b.micname
        FROM  t_atb_ResultMic a, t_atb_ResultExe b
        where a.reqno=b.reqno and a.exeno=b.exeno ";
                    if (!string.IsNullOrEmpty(strTempAntiID))
                    {
                        strSQL += " and a.antiid='" + strTempAntiID + "' ";
                    }
                    strSQL +=@" and b.exedate between ? and ?
         and b.micname=?)group by antiname order by antiname";
                    objHRPServ = new clsHRPTableService();

                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = p_dtDateFrom;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtDateTO;
                    objDPArr[2].DbType = DbType.String;
                    objDPArr[2].Value = micname;
                }
                else
                {
                    ArrayList arrlParm = new ArrayList();
                    arrlParm.Add(p_dtDateFrom);
                    arrlParm.Add(p_dtDateTO);
                    arrlParm.Add(micname);
                    if (!string.IsNullOrEmpty(Sex))
                    {
                        strSQL += " and trim(t5.sex_chr)=? ";
                        arrlParm.Add(Sex);
                    }
                    if (!string.IsNullOrEmpty(AgeFrom) && !string.IsNullOrEmpty(AgeTo))
                    {
                        strSQL += " and substr(regexp_replace(t5.age_chr,'[^0-9]'),1,3) between ? and ? ";
                        arrlParm.Add(AgeFrom);
                        arrlParm.Add(AgeTo);
                    }
                    if (!string.IsNullOrEmpty(DisNo))
                    {
                        strSQL += " and t5.patient_type_id_chr=? ";
                        arrlParm.Add(DisNo);
                    }
                    if (!string.IsNullOrEmpty(SamtNo))
                    {
                        strSQL += " and t5.sample_type_vchr=? ";
                        arrlParm.Add(SamtNo);
                    }
                    strSQL += "))";
                    if (!string.IsNullOrEmpty(TestMethod) && !TestMethod.Contains("ALL"))
                    {
                        strSQL += "  and a.testno=? ";
                        arrlParm.Add(TestMethod);
                    }

                    strSQL += " )group by antiname order by antiname ";


                    objHRPServ = new clsHRPTableService();
                    objHRPServ.CreateDatabaseParameter(arrlParm.Count, out objDPArr);
                    for (int i = 0; i < arrlParm.Count; i++)
                    {
                        objDPArr[i].Value = arrlParm[i];
                    }
                }
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }            

            return lngRes;
        }
        #endregion

        #region 细菌分布趋势报告
        /// <summary>
        /// 细菌分布
        /// </summary>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetMicdistributionTend(string micname,DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            bool flag=false;
            DateTime datefrom = DateTime.Parse(p_dtDateTO.AddMonths(-2).ToString("yyyy-MM-01 00:00:00"));

            string strSQL = @"select micname,count(*) as total,
       sum(case when trunc(a.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end) as month1,
       sum(case when trunc(a.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end) as month2,
       sum(case when trunc(a.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end) as month3 
  from t_atb_resultexe a
 where a.exedate between ? and ? ";
            if (!string.IsNullOrEmpty(micname))
            {
               strSQL +=" and a.micname=? ";
               flag=true;
            }
            strSQL +=@"
and a.reqno in(
     select t2.reqno from t_atb_AntiResultBill t2 where t2.samno in(
              select distinct trim(t3.device_sampleid_chr)  from t_opr_lis_device_relation t3 ,t_opr_lis_app_sample t4,t_opr_lis_application t5
               where  t3.deviceid_chr='000032' and t3.sample_id_chr=t4.sample_id_chr 
                        and t4.application_id_chr=t5.application_id_chr ";

            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(SamtNo) && string.IsNullOrEmpty(DisNo) && string.IsNullOrEmpty(Sex) && string.IsNullOrEmpty(AgeFrom) && string.IsNullOrEmpty(AgeTo) && string.IsNullOrEmpty(TestMethod))
                {
                    //没有病人信息的查询
                     strSQL = @"select micname,count(*) as total,
       sum(case when trunc(a.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end) as month1,
       sum(case when trunc(a.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end) as month2,
       sum(case when trunc(a.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end) as month3 
  from t_atb_resultexe a
 where a.exedate between ? and ?";
                    if(!string.IsNullOrEmpty(micname))
                    {
                         strSQL +=" and a.micname= '"+micname+"'";
                    }
                    strSQL+=" group by micname order by micname";

                    objHRPServ = new clsHRPTableService();
                    
                    objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = p_dtDateTO.AddMonths(-2); ;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtDateTO.AddMonths(-1); ;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtDateTO;
                    objDPArr[3].DbType = DbType.DateTime;
                    objDPArr[3].Value = datefrom;
                    objDPArr[4].DbType = DbType.DateTime;
                    objDPArr[4].Value = p_dtDateTO;
                }
                else
                {               
                        ArrayList arrlParm = new ArrayList();
                        arrlParm.Add(datefrom);
                        arrlParm.Add(datefrom.AddMonths(1));
                        arrlParm.Add(p_dtDateTO);
                        arrlParm.Add(datefrom);
                        arrlParm.Add(p_dtDateTO);
                        if (flag)
                        {
                            arrlParm.Add(micname);
                        }
                        if (!string.IsNullOrEmpty(Sex))
                        {
                            strSQL += " and trim(t5.sex_chr)=? ";
                            arrlParm.Add(Sex);
                        }
                        if (!string.IsNullOrEmpty(AgeFrom) && !string.IsNullOrEmpty(AgeTo))
                        {
                            strSQL += " and substr(regexp_replace(t5.age_chr,'[^0-9]'),1,3) between ? and ? ";
                            arrlParm.Add(AgeFrom);
                            arrlParm.Add(AgeTo);
                        }
                        if (!string.IsNullOrEmpty(DisNo))
                        {
                            strSQL += " and t5.patient_type_id_chr=? ";
                            arrlParm.Add(DisNo);
                        }
                        if (!string.IsNullOrEmpty(SamtNo))
                        {
                            strSQL += " and t5.sample_type_vchr=? ";
                            arrlParm.Add(SamtNo);
                        }
                 
                        strSQL += " ))group by micname order by micname ";

 
                        objHRPServ = new clsHRPTableService();
                        objHRPServ.CreateDatabaseParameter(arrlParm.Count, out objDPArr);
                        for (int i = 0; i < arrlParm.Count; i++)
                        {
                            objDPArr[i].Value = arrlParm[i];
                        }
                }
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();

                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;

        }
        #endregion

        #region 敏感率趋势报告
        /// <summary>
        /// 敏感率趋势报告
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetSensitiveTend(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod,string strTempAntiID, out DataTable dtbResult)
        {
             dtbResult = null;
            long lngRes = 0;
            DateTime datefrom = DateTime.Parse(p_dtDateTO.AddMonths(-3).ToString("yyyy-MM-01 00:00:00"));

            string strSQL = @"select antiname,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm')
         then (case when a.micexplain='S' then 1 else 0 end)else 0 end)as sen1,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end)as num1,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') 
         then (case when a.micexplain='S' then 1 else 0 end) else 0 end)as sen2,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end)as num2,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') 
         then (case when a.micexplain='S' then 1 else 0 end) else 0 end)as sen3,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end)as num3,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') 
         then (case when a.micexplain='S' then 1 else 0 end)  else 0 end)as sen4,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end)as num4           
FROM t_atb_ResultMic a, t_atb_ResultExe b
where ";
            if(!string.IsNullOrEmpty(strTempAntiID))
            {
              strSQL +=" a.antiid='"+strTempAntiID+"' and ";
            }
            strSQL += @" a.reqno=b.reqno and a.exeno=b.exeno and b.exedate between ? and ? and b.micname=? 
and a.reqno in(
      select t2.reqno from t_atb_AntiResultBill t2 where t2.samno in(
                  select trim(t3.device_sampleid_chr)  from t_opr_lis_device_relation t3 ,t_opr_lis_app_sample t4,t_opr_lis_application t5
                  where  t3.deviceid_chr='000032' and t3.sample_id_chr=t4.sample_id_chr 
                          and t4.application_id_chr=t5.application_id_chr ";

            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(SamtNo) && string.IsNullOrEmpty(DisNo) && string.IsNullOrEmpty(Sex) && string.IsNullOrEmpty(AgeFrom) && string.IsNullOrEmpty(AgeTo) && string.IsNullOrEmpty(TestMethod))
                {

                    strSQL = @"select antiname,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm')
         then (case when a.micexplain='S' then 1 else 0 end)else 0 end)as sen1,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end)as num1,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') 
         then (case when a.micexplain='S' then 1 else 0 end) else 0 end)as sen2,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end)as num2,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') 
         then (case when a.micexplain='S' then 1 else 0 end) else 0 end)as sen3,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end)as num3,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') 
         then (case when a.micexplain='S' then 1 else 0 end)  else 0 end)as sen4,
sum(case when trunc(b.exedate, 'mm') = trunc(?, 'mm') then 1 else 0 end)as num4           
FROM t_atb_ResultMic a, t_atb_ResultExe b
where ";
            if(!string.IsNullOrEmpty(strTempAntiID))
            {
              strSQL +=" a.antiid='"+strTempAntiID+"' and ";
            }
            strSQL += @"  a.reqno=b.reqno and a.exeno=b.exeno and b.exedate between ? and ? and b.micname=? group by antiname order by antiname";
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(11, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtDateTO.AddMonths(-3); ;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtDateTO.AddMonths(-3); ;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtDateTO.AddMonths(-2);
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_dtDateTO.AddMonths(-2);
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_dtDateTO.AddMonths(-1);
                objDPArr[5].DbType = DbType.DateTime;
                objDPArr[5].Value = p_dtDateTO.AddMonths(-1);
                objDPArr[6].DbType = DbType.DateTime;
                objDPArr[6].Value = p_dtDateTO;
                objDPArr[7].DbType = DbType.DateTime;
                objDPArr[7].Value = p_dtDateTO;
                objDPArr[8].DbType = DbType.DateTime;
                objDPArr[8].Value = datefrom;
                objDPArr[9].DbType = DbType.DateTime;
                objDPArr[9].Value = p_dtDateTO;
                objDPArr[10].DbType = DbType.String;
                objDPArr[10].Value = micname;
                }
                else
                {
                    ArrayList arrlParm = new ArrayList();
                    arrlParm.Add(datefrom);
                    arrlParm.Add(datefrom);
                    arrlParm.Add(datefrom.AddMonths(1));
                    arrlParm.Add(datefrom.AddMonths(1));
                    arrlParm.Add(datefrom.AddMonths(2));
                    arrlParm.Add(datefrom.AddMonths(2));
                    arrlParm.Add(p_dtDateTO);
                    arrlParm.Add(p_dtDateTO);
                    arrlParm.Add(datefrom);
                    arrlParm.Add(p_dtDateTO);
                    arrlParm.Add(micname);

                    if (!string.IsNullOrEmpty(Sex))
                    {
                        strSQL += " and trim(t5.sex_chr)=? ";
                        arrlParm.Add(Sex);
                    }
                    if (!string.IsNullOrEmpty(AgeFrom) && !string.IsNullOrEmpty(AgeTo))
                    {
                        strSQL += " and substr(regexp_replace(t5.age_chr,'[^0-9]'),1,3) between ? and ? ";
                        arrlParm.Add(AgeFrom);
                        arrlParm.Add(AgeTo);
                    }
                    if (!string.IsNullOrEmpty(DisNo))
                    {
                        strSQL += " and t5.patient_type_id_chr=? ";
                        arrlParm.Add(DisNo);
                    }
                    if (!string.IsNullOrEmpty(SamtNo))
                    {
                        strSQL += " and t5.sample_type_vchr=? ";
                        arrlParm.Add(SamtNo);
                    }
                    strSQL += "))";
                    if (!string.IsNullOrEmpty(TestMethod) && !TestMethod.Contains("ALL"))
                    {
                        strSQL += "  and a.testno=? ";
                        arrlParm.Add(TestMethod);
                    }

                    strSQL += " group by antiname order by antiname ";


                    objHRPServ = new clsHRPTableService();
                    objHRPServ.CreateDatabaseParameter(arrlParm.Count, out objDPArr);
                    for (int i = 0; i < arrlParm.Count; i++)
                    {
                        objDPArr[i].Value = arrlParm[i];
                    }
                }
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 累计MIC报告
        /// <summary>
        /// 累计MIC
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetMicCumulative(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = @"select antiname,count(*) as tested,
sum(case when instr(a.resshow,'0.25')>0 then 1 else 0 end) as p_2,
sum(case when instr(a.resshow,'0.5')>0 then 1 else 0 end)as p_3,
sum(case when a.resshow='≤1' then 1 
         else(case when (substr(a.resshow,0,2)='1<')
              then 1 else 0 end) 
         end) as p_4,
sum(case when substr(a.resshow,0,2)='≤2' then 1 
         else(case when substr(a.resshow,0,2)='2<'
                   then 1 else 0 end) 
         end) as p_5,
sum(case when substr(a.resshow,0,2)='≤4' then 1 
         else(case when substr(a.resshow,0,2)='4<'
                   then 1 else 0 end )
         end) as p_6,
sum(case when substr(a.resshow,0,2)='≤8' then 1 
         else(case when substr(a.resshow,0,2)='8<'
                   then 1 else 0 end )
         end) as p_7,
sum(case when instr(substr(a.resshow,0,3),'16')>0 then 1 else 0 end) as p_8,
sum(case when instr(substr(a.resshow,0,3),'32')>0 then 1 else 0 end) as p_9,
sum(case when instr(substr(a.resshow,0,3),'64')>0 then 1 else 0 end) as p_10,
sum(case when instr(a.resshow,0,6,'128')>0 then 1 else 0 end) as p_11,
sum(case when instr(a.resshow,0,6,'256')>0 then 1 else 0 end) as p_12
FROM t_atb_ResultMic a, t_atb_ResultExe b
where a.reqno=b.reqno  and a.exeno=b.exeno  ";
            if (!string.IsNullOrEmpty(strTempAntiID))
            {
                strSQL += " and a.antiid='" + strTempAntiID + "' ";
            }
            strSQL +=@"
and  b.exedate between ? and ? and b.micname=?  
and b.reqno in(
      select t2.reqno from t_atb_AntiResultBill t2 where t2.samno in(
                  select trim(t3.device_sampleid_chr)  from t_opr_lis_device_relation t3 ,t_opr_lis_app_sample t4,t_opr_lis_application t5
                   where  t3.deviceid_chr='000032' and t3.sample_id_chr=t4.sample_id_chr 
                          and t4.application_id_chr=t5.application_id_chr ";

            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(SamtNo) && string.IsNullOrEmpty(DisNo) && string.IsNullOrEmpty(Sex) && string.IsNullOrEmpty(AgeFrom) && string.IsNullOrEmpty(AgeTo) && string.IsNullOrEmpty(TestMethod))
                {
                    strSQL = @"select antiname,count(*) as tested,
sum(case when instr(a.resshow,'0.25')>0 then 1 else 0 end) as p_2,
sum(case when instr(a.resshow,'0.5')>0 then 1 else 0 end)as p_3,
sum(case when a.resshow='≤1' then 1 
         else(case when (substr(a.resshow,0,2)='1<')
              then 1 else 0 end) 
         end) as p_4,
sum(case when substr(a.resshow,0,2)='≤2' then 1 
         else(case when substr(a.resshow,0,2)='2<'
                   then 1 else 0 end) 
         end) as p_5,
sum(case when substr(a.resshow,0,2)='≤4' then 1 
         else(case when substr(a.resshow,0,2)='4<'
                   then 1 else 0 end )
         end) as p_6,
sum(case when substr(a.resshow,0,2)='≤8' then 1 
         else(case when substr(a.resshow,0,2)='8<'
                   then 1 else 0 end )
         end) as p_7,
sum(case when instr(substr(a.resshow,0,3),'16')>0 then 1 else 0 end) as p_8,
sum(case when instr(substr(a.resshow,0,3),'32')>0 then 1 else 0 end) as p_9,
sum(case when instr(substr(a.resshow,0,3),'64')>0 then 1 else 0 end) as p_10,
sum(case when instr(a.resshow,0,6,'128')>0 then 1 else 0 end) as p_11,
sum(case when instr(a.resshow,0,6,'256')>0 then 1 else 0 end) as p_12
FROM t_atb_ResultMic a, t_atb_ResultExe b
where a.reqno=b.reqno and a.exeno=b.exeno ";
                    if (!string.IsNullOrEmpty(strTempAntiID))
                    {
                        strSQL += "  and a.antiid='" + strTempAntiID + "' ";
                    }
                    strSQL +=@"
and  b.exedate between ? and ? and b.micname=?  group by antiname order by antiname";

                objHRPServ = new clsHRPTableService();

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtDateFrom;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtDateTO;
                objDPArr[2].DbType = DbType.String;
                objDPArr[2].Value = micname;
                }
                else
                {

                    ArrayList arrlParm = new ArrayList();
                    arrlParm.Add(p_dtDateFrom);
                    arrlParm.Add(p_dtDateTO);
                    arrlParm.Add(micname);
                    if (!string.IsNullOrEmpty(Sex))
                    {
                        strSQL += " and trim(t5.sex_chr)=?  ";
                        arrlParm.Add(Sex);
                    }
                    if (!string.IsNullOrEmpty(AgeFrom) && !string.IsNullOrEmpty(AgeTo))
                    {
                        strSQL += " and substr(regexp_replace(t5.age_chr,'[^0-9]'),1,3) between ? and ? ";
                        arrlParm.Add(AgeFrom);
                        arrlParm.Add(AgeTo);
                    }
                    if (!string.IsNullOrEmpty(DisNo))
                    {
                        strSQL += " and t5.patient_type_id_chr=? ";
                        arrlParm.Add(DisNo);
                    }
                    if (!string.IsNullOrEmpty(SamtNo))
                    {
                        strSQL += " and t5.sample_type_vchr=? ";
                        arrlParm.Add(SamtNo);
                    }
                    strSQL += "))";
                    if (!string.IsNullOrEmpty(TestMethod) && !TestMethod.Contains("ALL"))
                    {
                        strSQL += "  and a.testno=? ";
                        arrlParm.Add(TestMethod);
                    }

                    strSQL += "group by antiname order by antiname";

                    objHRPServ = new clsHRPTableService();
                    objHRPServ.CreateDatabaseParameter(arrlParm.Count, out objDPArr);
                    for (int i = 0; i < arrlParm.Count; i++)
                    {
                        objDPArr[i].Value = arrlParm[i];
                    }
                }
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 敏感率统计报表
        /// <summary>
        /// 敏感率统计
        /// </summary>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetSensitiveRate(string micname,DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod,string strTempAntiID, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = @"select antiname,micname,
          count(*) total,sum(case micexplain when 'S' then 1 else 0 end)as s_num
           from(
              SELECT a.antiname,a.micexplain,b.micname
                FROM t_atb_ResultMic a, t_atb_ResultExe b
              where a.reqno=b.reqno  and a.exeno=b.exeno
              and  a.antidate between ? and ? ";
            if(!string.IsNullOrEmpty(strTempAntiID))
            {
              strSQL +=" and a.antiid='"+strTempAntiID+"'";
            }
            if (!string.IsNullOrEmpty(micname))
            {
                strSQL += " and b.micname='" + micname + "'";
            }
            strSQL +=@"
              and a.reqno in(
                     select t2.reqno from t_atb_AntiResultBill t2 where t2.samno in(
                       select trim(t3.device_sampleid_chr)  from t_opr_lis_device_relation t3 ,t_opr_lis_app_sample t4,t_opr_lis_application t5
                       where  t3.deviceid_chr='000032' and t3.sample_id_chr=t4.sample_id_chr 
                              and t4.application_id_chr=t5.application_id_chr ";

            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(SamtNo) && string.IsNullOrEmpty(DisNo) && string.IsNullOrEmpty(Sex) && string.IsNullOrEmpty(AgeFrom) && string.IsNullOrEmpty(AgeTo) && string.IsNullOrEmpty(TestMethod))
                {
                    strSQL = @"select antiname,micname,
          count(*) total,sum(case micexplain when 'S' then 1 else 0 end)as s_num
           from(
              SELECT a.antiname,a.micexplain,b.micname
                FROM t_atb_ResultMic a, t_atb_ResultExe b
              where a.reqno=b.reqno  and a.exeno=b.exeno
              and  a.antidate between ? and ? ";
                if(!string.IsNullOrEmpty(strTempAntiID))
                {
                  strSQL +=" and a.antiid='"+strTempAntiID+"'";
                }
                if (!string.IsNullOrEmpty(micname))
                {
                    strSQL += " and b.micname='" + micname + "'";
                }
              strSQL +=@"
                ) group by antiname,micname order by antiname,micname";

                objHRPServ = new clsHRPTableService();
    
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtDateFrom;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtDateTO;
                }
                else
                {
                    ArrayList arrlParm = new ArrayList();
                    arrlParm.Add(p_dtDateFrom);
                    arrlParm.Add(p_dtDateTO);

                    if (!string.IsNullOrEmpty(Sex))
                    {
                        strSQL += " and trim(t5.sex_chr)=? ";
                        arrlParm.Add(Sex);
                    }
                    if (!string.IsNullOrEmpty(AgeFrom) && !string.IsNullOrEmpty(AgeTo))
                    {
                        strSQL += " and substr(regexp_replace(t5.age_chr,'[^0-9]'),1,3) between ? and ? ";
                        arrlParm.Add(AgeFrom);
                        arrlParm.Add(AgeTo);
                    }
                    if (!string.IsNullOrEmpty(DisNo))
                    {
                        strSQL += " and t5.patient_type_id_chr=? ";
                        arrlParm.Add(DisNo);
                    }
                    if (!string.IsNullOrEmpty(SamtNo))
                    {
                        strSQL += " and t5.sample_type_vchr=? ";
                        arrlParm.Add(SamtNo);
                    }
                    strSQL += "))";
                    if (!string.IsNullOrEmpty(TestMethod) && !TestMethod.Contains("ALL"))
                    {
                        strSQL += "  and a.testno=? ";
                        arrlParm.Add(TestMethod);
                    }

                    strSQL += " )group by antiname,micname order by antiname,micname";


                    objHRPServ = new clsHRPTableService();
                    objHRPServ.CreateDatabaseParameter(arrlParm.Count, out objDPArr);
                    for (int i = 0; i < arrlParm.Count; i++)
                    {
                        objDPArr[i].Value = arrlParm[i];
                    }
                }
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 取得病区
        /// <summary>
        /// 获取病区
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetDeptName( out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = "select dictid_chr,dictname_vchr from t_aid_dict where trim(dictid_chr) <> '0' and dictkind_chr = '61'";
            clsHRPTableService objHRPServ = null; 
            try
            {
                
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion 

        #region 取得样本类型
        /// <summary>
        /// 取得样本类型
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetSamType(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = " select sample_type_id_chr, sample_type_desc_vchr from t_aid_lis_sampletype order by sample_type_id_chr ";
            clsHRPTableService objHRPServ = null; 
            try
            {
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion
    }
 }
