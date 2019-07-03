using System;
using System.Data;
using System.Collections.Generic;
using System.EnterpriseServices;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 危急值业务组件
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class bizCriticalValue : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取申请单信息
        /// <summary>
        /// 获取申请单信息
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        [AutoComplete]
        public EntityCriticalMain GetLisApplication(string applyId)
        {
            EntityCriticalMain mainVo = new EntityCriticalMain();
            string Sql = string.Empty;

            try
            {
                Sql = @"select application_id_chr,
                               patientid_chr,
                               application_dat,
                               sex_chr,
                               patient_name_vchr,
                               patient_subno_chr,
                               age_chr,
                               patient_type_id_chr,
                               diagnose_vchr,
                               bedno_chr,
                               icdcode_chr,
                               patientcardid_chr,
                               application_form_no_chr,
                               modify_dat,
                               operator_id_chr,
                               appl_empid_chr,
                               appl_deptid_chr,
                               summary_vchr,
                               pstatus_int,
                               emergency_int,
                               special_int,
                               form_int,
                               patient_inhospitalno_chr,
                               sample_type_id_chr,
                               check_content_vchr,
                               sample_type_vchr,
                               oringin_dat,
                               charge_info_vchr,
                               printed_num,
                               orderunitrelation_vchr,
                               printed_date,
                               samplestatus
                          from t_opr_lis_application
                         where application_id_chr = ?";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = applyId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    mainVo.applyid = applyId;
                    mainVo.pattypeid = dr["patient_type_id_chr"].ToString();
                    mainVo.cardno = dr["patientcardid_chr"].ToString();
                    mainVo.patientid = dr["patientid_chr"].ToString();
                    mainVo.patname = dr["patient_name_vchr"].ToString();
                    mainVo.patsex = dr["sex_chr"].ToString();
                    mainVo.patage = dr["age_chr"].ToString();
                    mainVo.patsubno = dr["patient_subno_chr"].ToString();
                    mainVo.ipno = dr["patient_inhospitalno_chr"].ToString();
                    mainVo.bedno = dr["bedno_chr"].ToString();
                    mainVo.applytypeid = 1;
                    mainVo.applyitem = dr["check_content_vchr"].ToString();
                    mainVo.modifydate = Convert.ToDateTime(dr["modify_dat"].ToString());
                    mainVo.applydate = Convert.ToDateTime(dr["application_dat"].ToString());
                    mainVo.applyempid = dr["appl_empid_chr"].ToString();
                    mainVo.applydeptid = dr["appl_deptid_chr"].ToString();
                    mainVo.applypatdeptid = dr["summary_vchr"].ToString();
                    mainVo.status = 0;
                }
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return mainVo;
        }
        #endregion

        #region 保存检验危急值
        /// <summary>
        /// 保存检验危急值
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="confirmOperID"></param>
        /// <param name="confirmDate"></param>
        /// <param name="lstItem"></param>
        /// <returns></returns>
        [AutoComplete]
        public int SaveCriticalValue(string applyId, string confirmOperID, DateTime confirmDate, List<EntityCriticalLis> lstItem, bool isYG, bool isValid)
        {
            long ret = 0;
            long affectRows = 0;
            string Sql = string.Empty;

            try
            {
                // 申请单信息
                EntityCriticalMain mainVo = GetLisApplication(applyId);

                int n = -1;
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;

                #region main.sql
                Sql = @"insert into t_criticalvalue_main
                              (cvmid,
                               pattypeid,
                               cardno,
                               patientid,
                               patname,
                               patsex,
                               patage,
                               patsubno,
                               ipno,
                               iptimes,
                               bedno,
                               applytypeid,
                               applyid,
                               applyitem,
                               modifydate,
                               applydate,
                               applyempid,
                               applydeptid,
                               applypatdeptid,
                               recorderid,
                               recorddeptid,
                               recorddate,
                               responseempid,
                               responsedeptid,
                               responsemsg,
                               responsedate,
                               status,
                               doctadvicemsg,
                               doctadvicedate)
                            values
                              (?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                               ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                               ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                #endregion

                #region main.parm

                DataTable dt = null;
                string Sql1 = @"select seq_criticalMain.nextval from dual";
                svc.lngGetDataTableWithoutParameters(Sql1, ref dt);
                mainVo.cvmid = Convert.ToDecimal(dt.Rows[0][0].ToString());

                svc.CreateDatabaseParameter(29, out parm);
                parm[++n].Value = mainVo.cvmid;
                parm[++n].Value = mainVo.pattypeid;
                parm[++n].Value = mainVo.cardno;
                parm[++n].Value = mainVo.patientid;
                parm[++n].Value = mainVo.patname;
                parm[++n].Value = mainVo.patsex;
                parm[++n].Value = mainVo.patage;
                parm[++n].Value = (isYG ? "YG" : mainVo.patsubno);
                parm[++n].Value = mainVo.ipno;
                parm[++n].Value = mainVo.iptimes;
                parm[++n].Value = mainVo.bedno;
                parm[++n].Value = mainVo.applytypeid;
                parm[++n].Value = mainVo.applyid;
                parm[++n].Value = mainVo.applyitem;
                parm[++n].Value = mainVo.modifydate;
                parm[++n].Value = mainVo.applydate;
                parm[++n].Value = mainVo.applyempid;
                parm[++n].Value = mainVo.applydeptid;
                parm[++n].Value = mainVo.applypatdeptid;
                parm[++n].Value = confirmOperID;
                parm[++n].Value = "检验科";
                parm[++n].Value = confirmDate;
                parm[++n].Value = mainVo.responseempid;
                parm[++n].Value = mainVo.responsedeptid;
                parm[++n].Value = mainVo.responsemsg;
                parm[++n].Value = mainVo.responsedate;
                parm[++n].Value = (isValid ? mainVo.status : -1);
                parm[++n].Value = mainVo.DoctAdviceMsg;
                parm[++n].Value = null;

                ret = svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                if (ret < 0)
                {
                    throw new Exception("保存危急值主信息失败。");
                }
                #endregion

                #region lis.detail.sql
                Sql = @"insert into t_criticalvalue_lis
                          (seqid,
                           cvmid,
                           checkitemid,
                           checkitemname,
                           checkitemengname,
                           unit,
                           alarmlowval,
                           alarmupval,
                           resultval,
                           alertflag)
                        values
                          (seq_criticalLis.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                #endregion

                #region lis.detail.parm
                foreach (EntityCriticalLis item in lstItem)
                {
                    n = -1;
                    if (string.IsNullOrEmpty(item.checkitemname))
                        item.checkitemname = item.checkitemengname;
                    if (string.IsNullOrEmpty(item.checkitemname))
                        item.checkitemname = item.checkitemid;

                    svc.CreateDatabaseParameter(9, out parm);
                    parm[++n].Value = mainVo.cvmid;
                    parm[++n].Value = item.checkitemid;
                    parm[++n].Value = item.checkitemname;
                    parm[++n].Value = item.checkitemengname;
                    parm[++n].Value = item.unit;
                    parm[++n].Value = item.alarmlowval;
                    parm[++n].Value = item.alarmupval;
                    parm[++n].Value = item.resultvalue;
                    parm[++n].Value = item.alertflag;

                    ret = svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                    if (ret < 0)
                    {
                        throw new Exception("保存危急值检验信息失败。");
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return (int)ret;
        }
        #endregion

        #region 删除检验危急值
        /// <summary>
        /// 删除检验危急值
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        [AutoComplete]
        public int DelCriticalValue(string applyId)
        {
            long ret = 0;
            long affectRows = 0;
            string Sql = string.Empty;

            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                Sql = @"select cvmid from t_criticalvalue_main where applyid = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = applyId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);

                if (dt != null && dt.Rows.Count > 0)
                {
                    decimal cvMid = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        cvMid = Convert.ToDecimal(dr["cvmid"].ToString());

                        Sql = @"delete from t_criticalvalue_lis where cvmid = ?";
                        svc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = cvMid;
                        ret = svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                        if (ret < 0)
                        {
                            throw new Exception("删除危急值检验信息失败。");
                        }

                        Sql = @"delete from t_criticalvalue_main where cvmid = ?";
                        svc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = cvMid;
                        ret = svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                        if (ret < 0)
                        {
                            throw new Exception("删除危急值主信息失败。");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ret = -1;
                new clsLogText().LogError(ex);
            }
            return (int)ret;
        }
        #endregion

        #region 获取危急值列表
        /// <summary>
        /// 获取危急值列表
        /// </summary>
        /// <param name="typeId">1 门诊; 2 住院</param>
        /// <param name="qid"></param>
        /// <param name="lstMain"></param>
        /// <param name="lstDet"></param>
        [AutoComplete]
        public void GetCriticalvalList(int typeId, string qid, out List<EntityCriticalMain> lstMain, out List<EntityCriticalLis> lstDet)
        {
            lstMain = new List<EntityCriticalMain>();
            lstDet = new List<EntityCriticalLis>();
            string Sql = string.Empty;

            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                #region main
                Sql = @"select cvmid,
                               pattypeid,
                               cardno,
                               patientid,
                               patname,
                               patsex,
                               patage,
                               patsubno,
                               ipno,
                               iptimes,
                               applytypeid,
                               applyid,
                               applyitem,
                               modifydate,
                               applydate,
                               applyempid,
                               applydeptid,
                               applypatdeptid,
                               responseempid,
                               responsedeptid,
                               responsemsg,
                               responsedate,
                               status,
                               doctadvicemsg,
                               doctadvicedate  
                          from t_criticalvalue_main
                         where ";

                if (typeId == 1)
                {
                    Sql += " status >= 0 and doctadvicedate is null and applyempid = ?";
                }
                else if (typeId == 2)
                {
                    Sql += " status = 0 and applydeptid = ?";
                }
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = qid;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    EntityCriticalMain mainVo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        mainVo = new EntityCriticalMain();
                        mainVo.cvmid = Convert.ToDecimal(dr["cvmid"].ToString());
                        mainVo.patname = dr["patname"].ToString();
                        mainVo.patsex = dr["patsex"].ToString();
                        mainVo.patage = dr["patage"].ToString();
                        mainVo.applydate = Convert.ToDateTime(dr["applydate"].ToString());
                        mainVo.applyitem = dr["applyitem"].ToString();
                        mainVo.applytypeid = Convert.ToInt32(dr["applytypeid"].ToString());
                        mainVo.applyempid = dr["applyempid"].ToString();
                        mainVo.responseempid = dr["responseempid"].ToString();
                        mainVo.responsemsg = dr["responsemsg"].ToString();
                        if (dr["responsedate"] != DBNull.Value) mainVo.responsedate = Convert.ToDateTime(dr["responsedate"]);
                        mainVo.DoctAdviceMsg = dr["doctadvicemsg"].ToString();
                        if (dr["doctadvicedate"] != DBNull.Value) mainVo.DoctAdviceDate = Convert.ToDateTime(dr["doctadvicedate"]);
                        lstMain.Add(mainVo);
                    }
                }
                #endregion

                #region Detail

                if (lstMain.Count == 0) return;

                Sql = @"select a.seqid,
                               a.cvmid,
                               a.checkitemid,
                               a.checkitemname,
                               a.checkitemengname,
                               a.unit,
                               a.alarmlowval,
                               a.alarmupval,
                               a.resultval,
                               a.alertflag
                          from t_criticalvalue_lis a
                         inner join t_criticalvalue_main b
                            on a.cvmid = b.cvmid
                         where ";

                if (typeId == 1)
                {
                    Sql += " b.status >= 0 and b.doctadvicedate is null and b.applyempid = ?";
                }
                else if (typeId == 2)
                {
                    Sql += " b.status = 0 and b.applydeptid = ?";
                }
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = qid;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    EntityCriticalLis detVo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        detVo = new EntityCriticalLis();
                        detVo.seqid = Convert.ToDecimal(dr["seqid"].ToString());
                        detVo.cvmid = Convert.ToDecimal(dr["cvmid"].ToString());
                        detVo.checkitemid = dr["checkitemid"].ToString();
                        detVo.checkitemname = dr["checkitemname"].ToString();
                        detVo.checkitemengname = dr["checkitemengname"].ToString();
                        detVo.unit = dr["unit"].ToString();
                        detVo.alarmlowval = dr["alarmlowval"].ToString();
                        detVo.alarmupval = dr["alarmupval"].ToString();
                        detVo.resultvalue = dr["resultval"].ToString();
                        detVo.alertflag = dr["alertflag"].ToString();
                        lstDet.Add(detVo);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
        }
        #endregion

        #region 临床应答
        /// <summary>
        /// 临床应答
        /// </summary>
        /// <param name="respVo"></param>
        /// <returns></returns>
        [AutoComplete]
        public int ResponseCriticalValue(EntityCriResponse respVo)
        {
            long ret = 0;
            long affectRows = 0;
            string Sql = string.Empty;

            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                Sql = @"select status, doctadvicedate from t_criticalvalue_main where cvmid = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = respVo.cvmid;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["status"] != DBNull.Value && dt.Rows[0]["doctadvicedate"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["status"].ToString()) == -1)         // 危急值记录已无效
                            return -98;
                        else if (Convert.ToInt32(dt.Rows[0]["status"].ToString()) == 1)     // 危急值记录已应答
                            return -99;
                    }
                }

                Sql = @" update t_criticalvalue_main
                            set responseempid  = ?,
                                responsedeptid = ?,
                                responsemsg    = ?,
                                responsedate   = ?,
                                status         = ?,
                                doctadvicemsg  = ?,
                                doctadvicedate = ?,
                                doctid         = ? 
                          where cvmid = ?";

                svc.CreateDatabaseParameter(9, out parm);
                int n = -1;
                parm[++n].Value = respVo.responseempid;
                parm[++n].Value = respVo.responsedeptid;
                parm[++n].Value = respVo.responsemsg;
                parm[++n].Value = respVo.responsedate;
                parm[++n].Value = 1;
                parm[++n].Value = respVo.doctadvicemsg;
                if (string.IsNullOrEmpty(respVo.doctadvicemsg))
                {
                    parm[++n].Value = null;
                    parm[++n].Value = null;
                }
                else
                {
                    parm[++n].Value = DateTime.Now;
                    parm[++n].Value = respVo.responseempid;
                }
                parm[++n].Value = respVo.cvmid;
                ret = svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                if (ret < 0)
                {
                    throw new Exception("临床应答失败。");
                }
            }
            catch (Exception ex)
            {
                ret = -1;
                new clsLogText().LogError(ex);
            }
            return (int)ret;
        }
        #endregion

        #region 检验科认证
        /// <summary>
        /// 检验科认证
        /// </summary>
        /// <param name="cvmId"></param>
        /// <param name="empId"></param>
        /// <param name="desc"></param>
        [AutoComplete]
        public int LisVerify(decimal cvmId, string empId, string desc)
        {
            long ret = 0;
            long affectRows = 0;
            string Sql = string.Empty;

            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                Sql = @"select status, lisverifydate from t_criticalvalue_main where cvmid = ?";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = cvmId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["status"] != DBNull.Value && dt.Rows[0]["lisverifydate"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["status"].ToString()) == -1)         // 危急值记录已无效
                            return -98;
                        else if (Convert.ToInt32(dt.Rows[0]["status"].ToString()) == 1)     // 危急值记录已认证
                            return -99;
                    }
                }

                Sql = @" update t_criticalvalue_main
                            set lisverifierid  = ?,
                                lisverifydate  = ?,
                                lisverifymsg   = ? 
                          where cvmid = ?";

                svc.CreateDatabaseParameter(4, out parm);
                int n = -1;
                parm[++n].Value = empId;
                parm[++n].Value = DateTime.Now;
                parm[++n].Value = desc;
                parm[++n].Value = cvmId;
                ret = svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                if (ret < 0)
                {
                    throw new Exception("检验科室认证失败。");
                }
            }
            catch (Exception ex)
            {
                ret = -1;
                new clsLogText().LogError(ex);
            }
            return (int)ret;
        }
        #endregion

        #region 获取危急值监控类型
        /// <summary>
        /// 获取危急值监控类型
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="lstDeptId"></param>
        /// <returns></returns>
        [AutoComplete]
        public EntityCriMonitorType GetCriMonitorType(string empId, List<string> lstDeptId)
        {
            EntityCriMonitorType typeVo = new EntityCriMonitorType();
            string Sql = string.Empty;

            try
            {
                Sql = @"select t.deptid_chr,
                               t.deptname_vchr,
                               t.category_int,
                               t.inpatientoroutpatient_int
                          from t_bse_deptdesc t
                         where t.status_int = 1
                           and t.deptid_chr in ({0})";

                string deptId = string.Empty;
                foreach (string item in lstDeptId)
                {
                    deptId += "'" + item + "',";
                }
                Sql = string.Format(Sql, deptId.TrimEnd(','));

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    bool isCisDept = false;
                    bool isOpDept = false;
                    bool isIpDept = false;
                    string ipDeptId = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["category_int"] != DBNull.Value && Convert.ToInt32(dr["category_int"].ToString()) == 0)
                        {
                            isCisDept = true;
                        }
                        if (dr["inpatientoroutpatient_int"] != DBNull.Value)
                        {
                            if (Convert.ToInt32(dr["inpatientoroutpatient_int"].ToString()) == 0)
                                isOpDept = true;
                            else if (Convert.ToInt32(dr["inpatientoroutpatient_int"].ToString()) == 1)
                            {
                                isIpDept = true;
                                ipDeptId = dr["deptid_chr"].ToString();
                            }
                        }
                    }
                    if (isCisDept)
                    {
                        Sql = @"select t.empid_chr, t.hasprescriptionright_chr
                                      from t_bse_employee t
                                     where t.empid_chr = ?";
                        svc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = empId;
                        svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //if (dt.Rows[0]["hasprescriptionright_chr"] != DBNull.Value && Convert.ToInt32(dt.Rows[0]["hasprescriptionright_chr"].ToString()) == 1)
                            //{
                            //    typeVo.empId = empId;
                            //}
                            //if (isOpDept && !isIpDept)
                            //{
                            //    typeVo.mtypeId = 1;
                            //}
                            //if (!isOpDept && isIpDept)
                            //{
                            //    typeVo.mtypeId = 2;
                            //    typeVo.deptId = ipDeptId;
                            //}
                            //if (isOpDept && isIpDept)
                            //{
                            //    typeVo.mtypeId = 3;
                            //    typeVo.deptId = ipDeptId;
                            //}

                            if (dt.Rows[0]["hasprescriptionright_chr"] != DBNull.Value && Convert.ToInt32(dt.Rows[0]["hasprescriptionright_chr"].ToString()) == 1)
                            {
                                typeVo.mtypeId = 1;
                                typeVo.empId = empId;
                            }
                            else
                            {
                                if (isIpDept)
                                {
                                    if (typeVo.mtypeId == 1)
                                        typeVo.mtypeId = 3;
                                    else
                                        typeVo.mtypeId = 2;
                                    typeVo.deptId = ipDeptId;
                                }
                            }

                        }

                        #region 门诊开单+住院全区
                        /*
                        if (isOpDept)
                        {
                            Sql = @"select t.empid_chr, t.hasprescriptionright_chr
                                      from t_bse_employee t
                                     where t.empid_chr = ?";
                            svc.CreateDatabaseParameter(1, out parm);
                            parm[0].Value = empId;
                            svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["hasprescriptionright_chr"] != DBNull.Value && Convert.ToInt32(dt.Rows[0]["hasprescriptionright_chr"].ToString()) == 1)
                                {
                                    typeVo.mtypeId = 1;
                                    typeVo.empId = empId;
                                }
                            }
                        }
                        if (isIpDept)
                        {
                            if (typeVo.mtypeId == 1)
                                typeVo.mtypeId = 3;
                            else
                                typeVo.mtypeId = 2;
                            typeVo.deptId = ipDeptId;
                        } */
                        #endregion
                    }
                    else
                    {
                        typeVo.mtypeId = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return typeVo;
        }
        #endregion

        #region 获取危急值监控循环时间
        /// <summary>
        /// 获取危急值监控循环时间
        /// </summary>
        /// <returns>毫秒, 0 -- 不监控</returns>
        [AutoComplete]
        public int GetCriTime()
        {
            int sencond = 0;
            string Sql = string.Empty;

            try
            {
                Sql = @"select parmvalue_vchr
                          from t_bse_sysparm
                         where status_int = 1
                           and parmcode_chr = ?";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = "0081";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["parmvalue_vchr"] != DBNull.Value)
                    {
                        sencond = Convert.ToInt32(Convert.ToDecimal(dt.Rows[0]["parmvalue_vchr"].ToString()) * 60000);
                    }
                }
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return sencond;
        }
        #endregion

        #region 获取危急值条目
        /// <summary>
        /// 获取危急值条目
        /// </summary>
        /// <param name="typeId">1 门诊; 2 住院</param>
        /// <param name="qid"></param>
        /// <returns></returns>
        [AutoComplete]
        public List<EntityCriticalMain> GetCriList(int typeId, string qid)
        {
            List<EntityCriticalMain> lstMain = new List<EntityCriticalMain>();
            string Sql = string.Empty;

            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                #region main
                Sql = @"select cvmid,
                               pattypeid,
                               cardno,
                               patientid,
                               patname,
                               patsex,
                               patage,
                               patsubno,
                               ipno,
                               iptimes,
                               applytypeid,
                               applyid,
                               applyitem,
                               modifydate,
                               applydate,
                               applyempid,
                               applydeptid,
                               applypatdeptid,
                               responseempid,
                               responsedeptid,
                               responsemsg,
                               responsedate,
                               status,
                               doctadvicemsg,
                               doctadvicedate  
                          from t_criticalvalue_main
                         where ";

                //if (typeId == 1)
                //{
                //    Sql += " doctadvicedate is null and applyempid = ?";
                //}
                //else 
                if (typeId == 2)
                {
                    Sql += " status = 0 and applydeptid = ?";
                }
                else if (typeId == 1)
                {
                    #region Sql
                    Sql = @"select a.cvmid,
                                   a.pattypeid,
                                   a.cardno,
                                   a.patientid,
                                   a.patname,
                                   a.patsex,
                                   a.patage,
                                   a.patsubno,
                                   a.ipno,
                                   a.iptimes,
                                   a.applytypeid,
                                   a.applyid,
                                   a.applyitem,
                                   a.modifydate,
                                   a.applydate,
                                   a.applyempid,
                                   a.applydeptid,
                                   a.applypatdeptid,
                                   a.responseempid,
                                   a.responsedeptid,
                                   a.responsemsg,
                                   a.responsedate,
                                   a.status,
                                   a.doctadvicemsg,
                                   a.doctadvicedate
                              from t_criticalvalue_main a
                             where a.doctadvicedate is null
                               and a.status >= 0 
                               and a.applyempid = ?
                            union all
                            select distinct a.cvmid,
                                            a.pattypeid,
                                            a.cardno,
                                            a.patientid,
                                            a.patname,
                                            a.patsex,
                                            a.patage,
                                            a.patsubno,
                                            a.ipno,
                                            a.iptimes,
                                            a.applytypeid,
                                            a.applyid,
                                            a.applyitem,
                                            a.modifydate,
                                            a.applydate,
                                            a.applyempid,
                                            a.applydeptid,
                                            a.applypatdeptid,
                                            a.responseempid,
                                            a.responsedeptid,
                                            a.responsemsg,
                                            a.responsedate,
                                            a.status,
                                            a.doctadvicemsg,
                                            a.doctadvicedate
                              from t_criticalvalue_main a
                             inner join t_bse_deptemp b
                                on a.applydeptid = b.deptid_chr
                             inner join t_bse_employee c
                                on b.empid_chr = c.empid_chr
                             where a.doctadvicedate is null
                               and a.status >= 0 
                               and a.applyempid <> ?
                               and b.default_inpatient_dept_int = 1 
                               and c.technicalrank_chr in ('主任医师', '副主任医师', '主治医师', '医师')
                               and c.empid_chr = ?
                            ";
                    #endregion
                    svc.CreateDatabaseParameter(3, out parm);
                    parm[0].Value = qid;
                    parm[1].Value = qid;
                    parm[2].Value = qid;
                    svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                }
                else if (typeId == 5)
                {
                    #region Sql
                    Sql = @"select a.cvmid,
                                   a.pattypeid,
                                   a.cardno,
                                   a.patientid,
                                   a.patname,
                                   a.patsex,
                                   a.patage,
                                   a.patsubno,
                                   a.ipno,
                                   a.iptimes,
                                   a.applytypeid,
                                   a.applyid,
                                   a.applyitem,
                                   a.modifydate,
                                   a.applydate,
                                   a.applyempid,
                                   a.applydeptid,
                                   a.applypatdeptid,
                                   a.responseempid,
                                   a.responsedeptid,
                                   a.responsemsg,
                                   a.responsedate,
                                   a.status,
                                   a.doctadvicemsg,
                                   a.doctadvicedate
                              from t_criticalvalue_main a
                             where a.doctadvicedate is null
                               and a.status >= 0 
                               and a.applyempid = ?";
                    #endregion
                }
                else if (typeId == 8)   // 检验科认证
                {
                    #region Sql
                    Sql = @"select a.cvmid,
                                   a.pattypeid,
                                   a.cardno,
                                   a.patientid,
                                   a.patname,
                                   a.patsex,
                                   a.patage,
                                   a.patsubno,
                                   a.ipno,
                                   a.iptimes,
                                   a.applytypeid,
                                   a.applyid,
                                   a.applyitem,
                                   a.modifydate,
                                   a.applydate,
                                   a.applyempid,
                                   a.applydeptid,
                                   a.applypatdeptid,
                                   a.responseempid,
                                   a.responsedeptid,
                                   a.responsemsg,
                                   a.responsedate,
                                   a.status,
                                   a.doctadvicemsg,
                                   a.doctadvicedate
                              from t_criticalvalue_main a
                             where a.status >= 0
                               and a.applytypeid = 1  
                               and (a.applydate >= sysdate - 7)
                               and a.responsedate is null  
                               and a.lisverifydate is null";
                    #endregion
                    svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                }
                if (/*typeId == 1 ||*/ typeId == 2 || typeId == 5)
                {
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = qid;
                    svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    EntityCriticalMain mainVo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (typeId == 8)
                        {
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(dr["applydate"].ToString());
                            if (ts.Minutes <= 10) continue; // 10分钟
                        }

                        mainVo = new EntityCriticalMain();
                        mainVo.cvmid = Convert.ToDecimal(dr["cvmid"].ToString());
                        mainVo.cardno = dr["cardno"].ToString();
                        mainVo.ipno = dr["ipno"].ToString();
                        mainVo.patname = dr["patname"].ToString();
                        mainVo.patsex = dr["patsex"].ToString();
                        mainVo.patage = dr["patage"].ToString();
                        mainVo.applydate = Convert.ToDateTime(dr["applydate"].ToString());
                        mainVo.applyitem = dr["applyitem"].ToString();
                        mainVo.applytypeid = Convert.ToInt32(dr["applytypeid"].ToString());     // 1. LIS; 2. PACS
                        mainVo.applyempid = dr["applyempid"].ToString();
                        mainVo.responseempid = dr["responseempid"].ToString();
                        mainVo.responsemsg = dr["responsemsg"].ToString();
                        if (dr["responsedate"] != DBNull.Value) mainVo.responsedate = Convert.ToDateTime(dr["responsedate"]);
                        mainVo.DoctAdviceMsg = dr["doctadvicemsg"].ToString();
                        if (dr["doctadvicedate"] != DBNull.Value) mainVo.DoctAdviceDate = Convert.ToDateTime(dr["doctadvicedate"]);

                        lstMain.Add(mainVo);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return lstMain;
        }
        #endregion

        #region 获取危急值明细
        /// <summary>
        /// 获取危急值明细
        /// </summary>
        /// <param name="cvmId"></param>
        /// <returns></returns>
        [AutoComplete]
        public List<EntityCriticalLis> GetCriDetail(decimal cvmId)
        {
            List<EntityCriticalLis> lstDet = new List<EntityCriticalLis>();
            string Sql = string.Empty;

            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                #region main
                Sql = @"select a.seqid,
                               a.cvmid,
                               a.checkitemid,
                               a.checkitemname,
                               a.checkitemengname,
                               a.unit,
                               a.alarmlowval,
                               a.alarmupval,
                               a.resultval,
                               a.alertflag
                          from t_criticalvalue_lis a
                         where a.cvmid = ?";

                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = cvmId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    EntityCriticalLis detVo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        detVo = new EntityCriticalLis();
                        detVo.seqid = Convert.ToDecimal(dr["seqid"].ToString());
                        detVo.cvmid = Convert.ToDecimal(dr["cvmid"].ToString());
                        detVo.checkitemid = dr["checkitemid"].ToString();
                        detVo.checkitemname = dr["checkitemname"].ToString();
                        detVo.checkitemengname = dr["checkitemengname"].ToString();
                        detVo.unit = dr["unit"].ToString();
                        detVo.alarmlowval = dr["alarmlowval"].ToString();
                        detVo.alarmupval = dr["alarmupval"].ToString();
                        detVo.resultvalue = dr["resultval"].ToString();
                        detVo.alertflag = dr["alertflag"].ToString();
                        lstDet.Add(detVo);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return lstDet;
        }
        #endregion

        #region 获取pacs危急值
        /// <summary>
        /// 获取pacs危急值
        /// </summary>
        /// <param name="cvmId"></param>
        /// <returns></returns>
        [AutoComplete]
        public EntityCriticalPacs GetCriPacs(decimal cvmId)
        {
            EntityCriticalPacs vo = new EntityCriticalPacs();
            string Sql = string.Empty;
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                Sql = @"select a.seqid,
                               a.cvmid,
                               a.examid,
                               a.examitem,
                               a.examresult,
                               a.examdiag,
                               a.cricode,
                               a.cridesc
                          from t_criticalvalue_pacs a
                         where a.cvmid = ?";

                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = cvmId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    vo.cricode = dr["cricode"].ToString();
                    vo.cridesc = dr["cridesc"].ToString();
                    vo.cvmid = Convert.ToDecimal(dr["cvmid"].ToString());
                    vo.examdiag = dr["examdiag"].ToString();
                    vo.examid = dr["examid"].ToString();
                    vo.examitem = dr["examitem"].ToString();
                    vo.examresult = dr["examresult"].ToString();
                    vo.seqid = Convert.ToDecimal(dr["seqid"].ToString());

                    clsHRPTableService svcPacs = new clsHRPTableService();
                    svcPacs.m_mthSetDataBase_Selector(1, 16);

                    Sql = @"select v.exid, v.mzh, v.zyh, v.jclx, v.bgsj, v.bgdz
                              from pacstohispwoer v
                             where bgdz is not null
                               and v.exid = ?";

                    svcPacs.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = vo.examid;
                    svcPacs.lngGetDataTableWithParameters(Sql, ref dt, parm);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        vo.uri = dt.Rows[0]["bgdz"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return vo;
        }
        #endregion

        #region 危急值汇总报表
        /// <summary>
        /// 危急值汇总报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="deptIdArr"></param>
        /// <param name="isYG">是否院感</param>
        /// <returns></returns>
        [AutoComplete]
        public List<EntityCriReport> GetCriReport(DateTime startDate, DateTime endDate, string deptIdArr, bool isYG)
        {
            Dictionary<decimal, EntityCriReport> dicRpt = new Dictionary<decimal, EntityCriReport>();
            string Sql = string.Empty;
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                #region main
                Sql = @"select a.cvmid,
                               a.recorddate,
                               a.pattypeid,
                               a.patname,
                               a.ipno,
                               a.cardno,
                               b.deptname_vchr   as appdeptname,
                               a.bedno,
                               c.lastname_vchr   as recorder,
                               a.recorddeptid,
                               d.lastname_vchr   as responseopername,
                               a.responsedate,
                               a.responsemsg,
                               a.doctadvicemsg,
                               lis.checkitemid,
                               lis.checkitemname,
                               lis.unit,
                               lis.resultval,
                               a.applytypeid 
                          from t_criticalvalue_main a
                          left join t_bse_deptdesc b
                            on a.applydeptid = b.deptid_chr
                          left join t_bse_employee c
                            on a.recorderid = c.empid_chr
                          left join t_bse_employee d
                            on a.responseempid = d.empid_chr
                          left join t_criticalvalue_lis lis
                            on a.cvmid = lis.cvmid
                         where (a.recorddate between ? and ?)
                           and (a.status = 0 or a.status = 1)
                           and a.applytypeid = 1 
                           {0} 
                        union all
                        select a.cvmid,
                               a.recorddate,
                               a.pattypeid,
                               a.patname,
                               a.ipno,
                               a.cardno,
                               b.deptname_vchr as appdeptname,
                               a.bedno,
                               c.lastname_vchr as recorder,
                               a.recorddeptid,
                               d.lastname_vchr as responseopername,
                               a.responsedate,
                               a.responsemsg,
                               a.doctadvicemsg,
                               pacs.examid as checkitemid,
                               pacs.examitem as checkitemname,
                               '' as unit,
                               pacs.cridesc as resultval,
                               a.applytypeid 
                          from t_criticalvalue_main a
                          left join t_bse_deptdesc b
                            on a.applydeptid = b.deptid_chr
                          left join t_bse_employee c
                            on a.recorderid = c.empid_chr
                          left join t_bse_employee d
                            on a.responseempid = d.empid_chr
                          left join t_criticalvalue_pacs pacs
                            on a.cvmid = pacs.cvmid
                         where (a.recorddate between ? and ?)
                           and (a.status = 0 or a.status = 1)
                           and a.applytypeid = 2 
                           {1} ";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = startDate;
                parm[1].Value = endDate;
                parm[2].Value = startDate;
                parm[3].Value = endDate;
                if (string.IsNullOrEmpty(deptIdArr))
                {
                    if (isYG)
                        Sql = string.Format(Sql, "and a.patsubno = 'YG'", "and a.patsubno = 'YG'");
                    else
                        Sql = string.Format(Sql, "", "");
                }
                else
                {
                    if (isYG)
                        Sql = string.Format(Sql, "and a.patsubno = 'YG' and a.applydeptid in (" + deptIdArr + ")", "and a.patsubno = 'YG' and a.applydeptid in (" + deptIdArr + ")");
                    else
                        Sql = string.Format(Sql, " and a.applydeptid in (" + deptIdArr + ")", " and a.applydeptid in (" + deptIdArr + ")");
                }
                //(new clsLogText()).LogError(Sql);
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataView dv = new DataView(dt);
                    dv.Sort = "recorddate asc";
                    DataTable dt2 = dv.ToTable();

                    decimal cvmid = 0;
                    string criValue = string.Empty;
                    EntityCriReport rptVo = null;
                    foreach (DataRow dr in dt2.Rows)
                    {
                        cvmid = Convert.ToDecimal(dr["cvmid"].ToString());
                        if (dr["applytypeid"].ToString() == "2")
                        {
                            criValue = dr["resultval"].ToString();
                        }
                        else
                        {
                            criValue = dr["checkitemname"].ToString() + ": " + dr["resultval"].ToString() + dr["unit"].ToString();
                        }
                        if (dicRpt.ContainsKey(cvmid))
                        {
                            dicRpt[cvmid].crivalue += ";" + criValue;
                        }
                        else
                        {
                            rptVo = new EntityCriReport();
                            rptVo.cvmid = cvmid;
                            rptVo.recorddata = Convert.ToDateTime(dr["recorddate"]).ToString("yyyy-MM-dd");
                            rptVo.patname = dr["patname"].ToString();
                            rptVo.ipno = dr["ipno"].ToString();
                            rptVo.deptname = dr["appdeptname"].ToString();
                            rptVo.bedno = dr["bedno"].ToString();
                            rptVo.reportname = dr["recorder"].ToString();
                            rptVo.reportdept = dr["recorddeptid"].ToString();
                            rptVo.reportmin = Convert.ToDateTime(dr["recorddate"]).ToString("HH:mm");
                            rptVo.responser = dr["responseopername"].ToString();
                            if (dr["responsedate"] != DBNull.Value) rptVo.responsedate = Convert.ToDateTime(dr["responsedate"]).ToString("yyyy-MM-dd HH:mm");
                            rptVo.crivalue = criValue;
                            rptVo.responsemsg = dr["responsemsg"].ToString();
                            if (dr["pattypeid"].ToString() != "1")
                            {
                                rptVo.ipno = dr["cardno"].ToString();
                                rptVo.bedno = "门诊";
                            }
                            rptVo.doctadvicemsg = dr["doctadvicemsg"].ToString();
                            dicRpt.Add(cvmid, rptVo);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            List<EntityCriReport> data = new List<EntityCriReport>();
            data.AddRange(dicRpt.Values);
            return data;
        }
        #endregion

        #region 获取指定病人的危急值记录
        /// <summary>
        /// 获取指定病人的危急值记录
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [AutoComplete]
        public List<EntityCriticalMain> GetCriListByPid(string pid)
        {
            List<EntityCriticalMain> lstMain = new List<EntityCriticalMain>();
            string Sql = string.Empty;

            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;

                #region main
                Sql = @"select cvmid,
                               pattypeid,
                               cardno,
                               patientid,
                               patname,
                               patsex,
                               patage,
                               patsubno,
                               ipno,
                               iptimes,
                               applytypeid,
                               applyid,
                               applyitem,
                               modifydate,
                               applydate,
                               applyempid,
                               applydeptid,
                               applypatdeptid,
                               responseempid,
                               responsedeptid,
                               responsemsg,
                               responsedate,
                               status,
                               doctadvicemsg,
                               doctadvicedate 
                          from t_criticalvalue_main
                         where patientid = ?
                           and applytypeid = 1 
                           and status >= 0 ";

                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = pid;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    EntityCriticalMain mainVo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        mainVo = new EntityCriticalMain();
                        mainVo.cvmid = Convert.ToDecimal(dr["cvmid"].ToString());
                        mainVo.cardno = dr["cardno"].ToString();
                        mainVo.ipno = dr["ipno"].ToString();
                        mainVo.patname = dr["patname"].ToString();
                        mainVo.patsex = dr["patsex"].ToString();
                        mainVo.patage = dr["patage"].ToString();
                        mainVo.applydate = Convert.ToDateTime(dr["applydate"].ToString());
                        mainVo.applyitem = dr["applyitem"].ToString();

                        mainVo.applyempid = dr["applyempid"].ToString();
                        mainVo.responseempid = dr["responseempid"].ToString();
                        mainVo.responsemsg = dr["responsemsg"].ToString();
                        if (dr["responsedate"] != DBNull.Value) mainVo.responsedate = Convert.ToDateTime(dr["responsedate"]);
                        mainVo.DoctAdviceMsg = dr["doctadvicemsg"].ToString();
                        if (dr["doctadvicedate"] != DBNull.Value) mainVo.DoctAdviceDate = Convert.ToDateTime(dr["doctadvicedate"]);

                        lstMain.Add(mainVo);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return lstMain;
        }
        #endregion

        #region 取消危急值
        /// <summary>
        /// 取消危急值
        /// </summary>
        /// <param name="cancelVo"></param>
        /// <returns></returns>
        [AutoComplete]
        public int CancelCriticalValue(EntityCriCancel cancelVo)
        {
            long ret = 0;
            long affectRows = 0;
            string Sql = string.Empty;

            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;

                Sql = @" update t_criticalvalue_main
                            set cancelempid  = ?,
                                cancelreason   = ?,
                                canceldate   = ?,
                                status = ?
                          where cvmid = ?";

                svc.CreateDatabaseParameter(5, out parm);
                int n = -1;
                parm[++n].Value = cancelVo.cancelempid;
                parm[++n].Value = cancelVo.cancelreason;
                parm[++n].Value = cancelVo.canceldate;
                parm[++n].Value = -2;
                parm[++n].Value = cancelVo.cvmid;
                ret = svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                if (ret < 0)
                {
                    throw new Exception("取消危急值失败。");
                }
            }
            catch (Exception ex)
            {
                ret = -1;
                new clsLogText().LogError(ex);
            }
            return (int)ret;
        }
        #endregion

        #region 获取体检申请项目
        /// <summary>
        /// 获取体检申请项目
        /// </summary>
        /// <param name="regNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetAppItem(string regNo)
        {
            string Sql = string.Empty;
            DataTable dt = null;
            clsHRPTableService svcPe = null;
            try
            {
                #region def_comb_tj_as
                Sql = @"select t.pat_code,
                               t.reg_time,
                               t.reg_no,
                               w.comb_code,
                               h.oper_code,
                               a.comb_code, 
                               a.comb_name,
                               a.as_group
                          from tj_pat_item_work w, tj_register t, tj_patient h, def_comb_tj_as a
                         where t.reg_no = w.reg_no
                           and t.reg_times =
                               (select max(a.reg_times) from tj_register a where a.reg_no = t.reg_no)
                           and t.pat_code = h.pat_code
                           and t.reg_times = h.reg_times
                           and a.comb_code = w.comb_code
                           and t.reg_no = ?
                        union all
                        select t.pat_code,
                               t.reg_time,
                               t.reg_no,
                               w.comb_code,
                               h.oper_code,
                               a.comb_code, 
                               a.comb_name,
                               a.as_group
                          from tj_pat_item w, tj_register t, tj_patient h, def_comb_tj_as a
                         where t.reg_no = w.reg_no
                           and t.reg_times =
                               (select max(a.reg_times) from tj_register a where a.reg_no = t.reg_no)
                           and t.pat_code = h.pat_code
                           and t.reg_times = h.reg_times
                           and a.comb_code = w.comb_code
                           and t.reg_no = ?";
                #endregion

                svcPe = new clsHRPTableService();
                svcPe.m_mthSetDataBase_Selector(1, 15);
                IDataParameter[] parm = null;
                svcPe.CreateDatabaseParameter(2, out parm);
                parm[0].Value = regNo;
                parm[1].Value = regNo;
                svcPe.lngGetDataTableWithParameters(Sql, ref dt, parm);
                dt.TableName = "pe";
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

        #region 获取院感危急值
        /// <summary>
        /// 获取院感危急值
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCriYG()
        {
            DataTable dt = null;
            string Sql = string.Empty;
            try
            {
                Sql = @"select refId, refDesc from t_criticalvalue_ref_yg";
                clsHRPTableService svc = new clsHRPTableService();
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return dt;
        }
        #endregion

        #region 保存院感危急值
        /// <summary>
        /// 保存院感危急值
        /// </summary>
        /// <param name="lstRefDesc"></param>
        /// <returns></returns>
        public int SaveCriYG(List<string> lstRefDesc)
        {
            long ret = 0;
            long affectRows = 0;
            string Sql = string.Empty;
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;

                Sql = @"delete from t_criticalvalue_ref_yg";
                ret = svc.DoExcute(Sql);
                if (lstRefDesc.Count > 0)
                {
                    int n = 0;
                    foreach (string val in lstRefDesc)
                    {
                        Sql = @"insert into t_criticalvalue_ref_yg values (?, ?)";
                        svc.CreateDatabaseParameter(2, out parm);
                        parm[0].Value = ++n;
                        parm[1].Value = val;
                        ret = svc.lngExecuteParameterSQL(Sql, ref affectRows, parm);
                    }
                }
                if (ret < 0)
                {
                    throw new Exception("保存院感危急值失败。");
                }
            }
            catch (Exception ex)
            {
                ret = -1;
                new clsLogText().LogError(ex);
            }
            return (int)ret;
        }
        #endregion

        #region 获取检验科室电脑IP
        /// <summary>
        /// 获取检验科室电脑IP
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public List<string> GetLisPC()
        {
            List<string> lstPc = new List<string>();
            DataTable dtPc = null;
            try
            {
                string Sql = @"select ipaddr from t_opr_pcip where flag = '1'";
                clsHRPTableService svc = new clsHRPTableService();
                svc.lngGetDataTableWithoutParameters(Sql, ref dtPc);
                if (dtPc != null && dtPc.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtPc.Rows)
                    {
                        lstPc.Add(dr["ipaddr"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
            return lstPc;
        }
        #endregion
    }
}
