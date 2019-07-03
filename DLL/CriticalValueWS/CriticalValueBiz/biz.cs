using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace CriticalValueService
{
    #region 业务类
    /// <summary>
    /// 业务类
    /// </summary>
    public class Biz : IDisposable
    {
        #region Register
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public string Register(string Request)
        {
            bool ret = false;
            string error = string.Empty;
            string Response = string.Empty;
            Response += "<Response>" + Environment.NewLine;
            Response += "<resultCode>{0}</resultCode>" + Environment.NewLine;
            Response += "<resultMessage>{1}</resultMessage>" + Environment.NewLine;
            Response += "</Response>";

            Dictionary<string, string> dicKey = this.ReadXmlNodes(Request, "Request");
            ret = CheckRequest(dicKey, ref error);
            if (ret == false)
            {
                Response = string.Format(Response, "0", error);
            }
            else
            {
                ret = SaveCriticalValue(dicKey, ref error);
                Response = string.Format(Response, (ret ? "1" : "0"), (ret ? dicKey["examId"] + " 交易成功" : error));
            }
            return Response;
        }
        #endregion

        #region 检查入参
        /// <summary>
        /// 检查入参
        /// </summary>
        /// <param name="dicKey"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        bool CheckRequest(Dictionary<string, string> dicKey, ref string error)
        {
            if (dicKey["patType"].Trim() == string.Empty)
            {
                error = "病人类型不能为空";
                return false;
            }
            if (dicKey["patType"].Trim() == "门诊")
                dicKey["patType"] = "1";
            else if (dicKey["patType"].Trim() == "住院")
                dicKey["patType"] = "2";
            else if (dicKey["patType"].Trim() == "体检")
                dicKey["patType"] = "3";
            if (dicKey["opNo"].Trim() == string.Empty && dicKey["ipNo"].Trim() == string.Empty)
            {
                error = "门诊号、住院号不能同时为空";
                return false;
            }
            if (dicKey["examType"].Trim() == string.Empty)
            {
                error = "检查类型不能为空";
                return false;
            }
            if (dicKey["applyId"].Trim() == string.Empty)
            {
                error = "申请单ID不能为空";
                return false;
            }
            if (dicKey["examId"].Trim() == string.Empty)
            {
                error = "检查ID不能为空";
                return false;
            }
            if (dicKey["examItem"].Trim() == string.Empty)
            {
                error = "检查项目不能为空";
                return false;
            }
            if (dicKey["examResult"].Trim() == string.Empty)
            {
                error = "检查结果不能为空";
                return false;
            }
            if (dicKey["examDiag"].Trim() == string.Empty)
            {
                error = "检查诊断不能为空";
                return false;
            }
            if (dicKey["criCode"].Trim() == string.Empty)
            {
                error = "危急值编码不能为空";
                return false;
            }
            if (dicKey["doctNo"].Trim() == string.Empty)
            {
                error = "检查医生工号不能为空";
                return false;
            }
            if (dicKey["doctName"].Trim() == string.Empty)
            {
                error = "检查医生姓名不能为空";
                return false;
            }
            if (dicKey["prtTime"].Trim() == string.Empty)
            {
                error = "报告打印时间不能为空";
                return false;
            }
            return true;
        }
        #endregion

        #region 保存PACS危急值
        /// <summary>
        /// 保存PACS危急值
        /// </summary>
        /// <param name="dicKey"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        bool SaveCriticalValue(Dictionary<string, string> dicKey, ref string error)
        {
            int n = -1;
            int affectRows = 0;
            string Sql = string.Empty;
            bool ret = false;
            SqlHelper svc = new SqlHelper();
            IDataParameter[] parm = null;
            try
            {
                #region main.sql
                Sql = @"insert into icare.t_criticalvalue_main
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
                               status)
                            values
                              (?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                               ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                               ?, ?, ?, ?, ?, ?, ?)";

                #endregion

                #region main.parm
                // 申请单信息
                EntityCriticalMain mainVo = new EntityCriticalMain();
                mainVo.pattypeid = dicKey["patType"];
                mainVo.cardno = dicKey["opNo"];

                #region 参数
                DataTable dt = null;
                string Sql1 = @"select icare.seq_criticalMain.nextval from dual";
                dt = svc.GetDataTable(Sql1);
                mainVo.cvmid = Convert.ToDecimal(dt.Rows[0][0].ToString());

                if (dicKey["examType"].Trim() == "病理")
                {
                    Sql1 = @"select a.patientcardid_chr as cardno,
                                       a.patient_name_vchr as name,
                                       a.sex_chr           as sex,
                                       a.age_chr           as age,
                                       a.bedno_chr         as bedno,
                                       a.appl_dat          as applydate,
                                       a.appl_deptid_chr   as deptid_chr,
                                       a.appl_empid_chr    as doctorid_chr,
                                       a.patientid_chr
                                  from t_opr_lis_sample a
                                 where a.application_id_chr = ?";
                    parm = svc.CreateParm(1);
                    parm[0].Value = dicKey["applyId"];
                    dt = svc.GetDataTable(Sql1, parm);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    Sql1 = @"select a.cardno,
                                   a.name,
                                   a.sex,
                                   a.age,
                                   a.bedno,
                                   a.applydate,
                                   a.deptid_chr,
                                   a.doctorid_chr,
                                   b.patientid_chr
                              from icare.ar_common_apply a
                             inner join icare.t_bse_patientcard b
                                on a.cardno = b.patientcardid_chr
                             where a.applyid = ?";
                    parm = svc.CreateParm(1);
                    parm[0].Value = dicKey["applyId"];
                    dt = svc.GetDataTable(Sql1, parm);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        Sql1 = @"select a.patientcardid_chr as cardno,
                                       a.patient_name_vchr as name,
                                       a.sex_chr           as sex,
                                       a.age_chr           as age,
                                       a.bedno_chr         as bedno,
                                       a.appl_dat          as applydate,
                                       a.appl_deptid_chr   as deptid_chr,
                                       a.appl_empid_chr    as doctorid_chr,
                                       a.patientid_chr
                                  from t_opr_lis_sample a
                                 where a.application_id_chr = ?";
                        parm = svc.CreateParm(1);
                        parm[0].Value = dicKey["applyId"];
                        dt = svc.GetDataTable(Sql1, parm);
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            return false;
                        }
                    }
                }
                DataRow dr = dt.Rows[0];
                mainVo.patientid = dr["patientid_chr"].ToString();
                mainVo.patname = dr["name"].ToString();
                mainVo.patsex = dr["sex"].ToString();
                mainVo.patage = dr["age"].ToString();
                mainVo.ipno = dicKey["ipNo"];
                mainVo.bedno = dr["bedno"].ToString();
                mainVo.applytypeid = 2; // 检查
                mainVo.applyid = dicKey["applyId"];
                //mainVo.applyitem = ;
                //mainVo.modifydate = ;
                mainVo.applydate = dr["applydate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["applydate"]);
                mainVo.applyempid = dr["doctorid_chr"].ToString();
                mainVo.applydeptid = dr["deptid_chr"].ToString();
                //mainVo.applypatdeptid = ;
                mainVo.recorderid = dicKey["doctNo"];   // 工号
                //mainVo.recorddeptid = ;
                mainVo.recorddate = Convert.ToDateTime(dicKey["prtTime"]);

                // 补.
                Sql1 = @"select a.empid_chr, a.lastname_vchr, b.deptid_chr, c.deptname_vchr
                          from icare.t_bse_employee a
                         inner join icare.t_bse_deptemp b
                            on a.empid_chr = b.empid_chr
                          left join icare.t_bse_deptdesc c
                            on b.deptid_chr = c.deptid_chr
                         where (b.default_dept_int = 1 or b.default_inpatient_dept_int = 1)
                           and a.lastname_vchr = ?";
                parm = svc.CreateParm(1);
                parm[0].Value = dicKey["doctName"];
                dt = svc.GetDataTable(Sql1, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    mainVo.recorderid = dt.Rows[0]["empid_chr"].ToString();
                    mainVo.recorddeptid = dt.Rows[0]["deptname_vchr"].ToString();
                }
                #endregion

                parm = svc.CreateParm(27);
                parm[++n].Value = mainVo.cvmid;
                parm[++n].Value = mainVo.pattypeid;
                parm[++n].Value = mainVo.cardno;
                parm[++n].Value = mainVo.patientid;
                parm[++n].Value = mainVo.patname;
                parm[++n].Value = mainVo.patsex;
                parm[++n].Value = mainVo.patage;
                parm[++n].Value = mainVo.patsubno;
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
                parm[++n].Value = mainVo.recorderid;
                parm[++n].Value = mainVo.recorddeptid;
                parm[++n].Value = mainVo.recorddate;
                parm[++n].Value = mainVo.responseempid;
                parm[++n].Value = mainVo.responsedeptid;
                parm[++n].Value = mainVo.responsemsg;
                parm[++n].Value = mainVo.responsedate;
                parm[++n].Value = mainVo.status;

                affectRows = svc.ExecSql(Sql, parm);
                if (affectRows <= 0)
                {
                    error = "保存危急值主信息失败";
                    return false;
                }
                #endregion

                #region pacs.detail.sql
                Sql = @"insert into icare.t_criticalvalue_pacs
                          (seqid, cvmid, examid, examitem, examresult, examdiag, cricode, cridesc)
                        values
                          (icare.seq_criticalPacs.nextval, ?, ?, ?, ?, ?, ?, ?)";

                Sql1 = @"select t.refcode, t.refdesc from icare.t_criticalvalue_ref t where t.refcode = ?";
                parm = svc.CreateParm(1);
                parm[0].Value = dicKey["criCode"];
                dt = svc.GetDataTable(Sql1, parm);
                #endregion

                n = -1;
                parm = svc.CreateParm(7);
                parm[++n].Value = mainVo.cvmid;
                parm[++n].Value = dicKey["examId"];
                parm[++n].Value = dicKey["examItem"];
                parm[++n].Value = dicKey["examResult"];
                parm[++n].Value = dicKey["examDiag"];
                parm[++n].Value = dicKey["criCode"];
                parm[++n].Value = dt.Rows[0]["refdesc"].ToString(); ;

                affectRows = svc.ExecSql(Sql, parm);
                if (affectRows <= 0)
                {
                    Sql = @"delete from icare.t_criticalvalue_main where cvmid = ?";
                    parm = svc.CreateParm(1);
                    parm[0].Value = mainVo.cvmid;
                    svc.ExecSql(Sql, parm);

                    error = "保存检查结果危急值失败";
                    return false;
                }
                ret = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                ret = false;
            }
            return ret;
        }
        #endregion

        #region 获取消息推送参数
        /// <summary>
        /// 获取消息推送参数
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="webUrl"></param>
        /// <returns></returns>
        public bool GetNoticeParm(string cardNo, out string pid, out string webUrl)
        {
            string Sql = string.Empty;
            SqlHelper svc = new SqlHelper();
            IDataParameter[] parm = null;

            pid = string.Empty;
            webUrl = string.Empty;
            try
            {
                Sql = @"select a.cardno, b.patientid_chr from icare.opRegWeChatBinding a, icare.t_bse_patientcard b where a.cardno = b.patientcardid_chr and a.cardno = ? and a.status = 1";
                parm = svc.CreateParm(1);
                parm[0].Value = cardNo;
                DataTable dt = svc.GetDataTable(Sql, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    pid = dt.Rows[0]["patientid_chr"].ToString();
                    // 存在绑定
                    Sql = @"select parmvalue_vchr from icare.t_bse_sysparm where status_int = 1 and parmcode_chr = ?";
                    parm = svc.CreateParm(1);
                    parm[0].Value = "1010";
                    dt = svc.GetDataTable(Sql, parm);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0] != DBNull.Value)
                        {
                            webUrl = dt.Rows[0][0].ToString().Trim();
                            if (webUrl != string.Empty) return true;
                        }
                    }
                    else
                    {
                        Log.OutPut("1010 没数据");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutPut(ex.Message);
            }
            return false;
        }
        #endregion

        #region 读取XML片段
        /// <summary>
        /// 读取XML片段
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public Dictionary<string, string> ReadXmlNodes(string xml, string nodeName)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            XmlElement element = document[nodeName];
            document = null;

            if (element == null) return null;
            Dictionary<string, string> dicVal = new Dictionary<string, string>();
            foreach (XmlNode node in element.ChildNodes)
            {
                if (!dicVal.ContainsKey(node.Name))
                {
                    dicVal.Add(node.Name, node.InnerText);
                }
            }
            return dicVal;
        }
        #endregion

        #region PACS接口
        /// <summary>
        /// PacsApp
        /// </summary>
        /// <param name="xmlIn"></param>
        /// <returns></returns>
        public string PacsApp(string xmlIn)
        {
            string Sql = string.Empty;
            string xmlOut = string.Empty;
            SqlHelper svc = new SqlHelper();
            try
            {
                Dictionary<string, string> dicKey = this.ReadXmlNodes("req", xmlIn);
                int opIp = 0;   // 1 门诊; 2 住院
                if (dicKey.ContainsKey("opIp"))
                {
                    opIp = Convert.ToInt32(dicKey["opIp"]);
                }
                if (opIp == 1)
                {
                    #region Sql.op
                    Sql = @"select b.patientcardid_chr as CardNumber, -- 卡号  非必填(医院有刷卡，则该卡号必填)
                                   d.orderid_int as RequisitionID, -- 申请单ID 必填 Int类型 唯一
                                   c.outpatrecipeid_chr as DoctorAdviceID, -- 医嘱ID  非必填
                                   a.lastname_vchr as patientName, -- 病人姓名  必填
                                   trunc((to_char(sysdate, 'yyyyMMdd') -
                                         to_char(a.birth_dat, 'yyyyMMdd')) / 10000) as patientAge, -- 病人年龄  非必填
                                   to_char(a.birth_dat, 'yyyy-mm-dd') as patientBirthday, -- 出生日期  必填（yyyy-MM-dd根据出生日期得到年龄）
                                   a.sex_chr as patientSex, -- 性别  必填(男、女、其他)
                                   a.homephone_vchr as patientTelephone, -- 电话  非必填
                                   '' as patientUnit, -- 工作单位  非必填
                                   a.homeaddress_vchr as patientAddress, -- 病人住址  非必填
                                   '' as patientNation, -- 民族  非必填
                                   '' as bedNum, -- 床位号 非必填
                                   '' as clinicalDiagnosis, -- 临床诊断  非必填
                                   b.patientcardid_chr as clinicalNum, -- 门诊号 必填
                                   '' as inHospitalNum, -- 住院号 非必填
                                   '' as Patient_uid, -- 影像号 非必填     
                                   f.partname as examineParts, -- 检查部位  必填
                                   g.typedesc as examineType, -- 检查类型  必填(详见检查类型设定.txt)
                                   '' as hospitalDistrictNum, -- 病区  非必填
                                   '门诊' as patientFrom, -- 病人来源  '门诊'
                                   h.deptname_vchr as sentByDepartment, -- 送检科室  必填     
                                   i.lastname_vchr as sentByDoctor, -- 送检医生  必填
                                   (j.totalsum_mny + j.totaldiffcost_mny) as fee,
                                   c.createdate_dat as OrderEntryTime, -- 医嘱开立时间  必填 格式”yyyy-MM-dd hh24:mi:ss” 或者”yyyy.MM.dd hh24:mi:ss”
                                   j.invdate_dat as DoctorChargesTime, -- 医嘱收费时间  必填 格式”yyyy-MM-dd hh24:mi:ss” 或者”yyyy.MM.dd hh24:mi:ss”
                                   '平诊' as AcuteLevelDiagnosis, -- 急平诊 非必填
                                   j.invoiceno_vchr as BalanceSheetNo, -- 结算号 非必填
                                   1 as chargeStatus, -- 0-未收费 1-已收费 2-已退费
                                   '' as chargedesc, g.typetext, a.patientid_chr, c.outpatrecipeid_chr  
                              from icare.t_bse_patient a
                             inner join icare.t_bse_patientcard b
                                on a.patientid_chr = b.patientid_chr
                             inner join icare.t_opr_outpatientrecipe c
                                on a.patientid_chr = c.patientid_chr
                             inner join icare.t_opr_outpatient_orderdic d
                                on c.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and d.tableindex_int = 4
                               and d.checkpartid_vchr is not null
                             inner join icare.t_bse_bih_orderdic e
                                on e.orderdicid_chr = d.orderdicid_chr
                             inner join icare.ar_apply_partlist f
                                on d.checkpartid_vchr = f.partid
                             inner join icare.ar_apply_typelist g
                                on e.applytypeid_chr = g.typeid
                             inner join icare.t_bse_deptdesc h
                                on c.diagdept_chr = h.deptid_chr
                             inner join icare.t_bse_employee i
                                on c.diagdr_chr = i.empid_chr
                             inner join icare.t_opr_outpatientrecipeinv j
                                on c.outpatrecipeid_chr = j.outpatrecipeid_chr
                             where c.pstauts_int = 2
                               and g.typedesc is not null
                           ";
                    #endregion
                }
                else if (opIp == 2)
                {
                    #region Sql.ip
                    Sql = @"select b.patientcardid_chr as CardNumber, -- 卡号  非必填(医院有刷卡，则该卡号必填)
                                   to_number(substr(c.orderid_chr, 3)) as RequisitionID, -- 申请单ID 必填 Int类型 唯一
                                   c.orderid_chr as DoctorAdviceID, -- 医嘱ID
                                   a.lastname_vchr as patientName, -- 病人姓名  必填
                                   trunc((to_char(sysdate, 'yyyyMMdd') -
                                         to_char(a.birth_dat, 'yyyyMMdd')) / 10000) as patientAge, -- 病人年龄  非必填
                                   to_char(a.birth_dat, 'yyyy-mm-dd') as patientBirthday, -- 出生日期  必填（yyyy-MM-dd根据出生日期得到年龄）
                                   a.sex_chr as patientSex, -- 性别  必填(男、女、其他)
                                   a.homephone_vchr as patientTelephone, -- 电话  非必填
                                   '' as patientUnit, -- 工作单位  非必填
                                   a.homeaddress_vchr as patientAddress, -- 病人住址  非必填
                                   '' as patientNation, -- 民族  非必填
                                   l.bed_no as bedNum, -- 床位号 非必填
                                   '' as clinicalDiagnosis, -- 临床诊断  非必填
                                   b.patientcardid_chr as clinicalNum, -- 门诊号 非必填
                                   k.inpatientid_chr as inHospitalNum, -- 住院号 必填
                                   '' as Patient_uid, -- 影像号 非必填   
                                   f.partname as examineParts, -- 检查部位  必填
                                   g.typedesc as examineType, -- 检查类型  必填(详见检查类型设定.txt)
                                   h.deptname_vchr as hospitalDistrictNum, -- 病区  非必填
                                   '住院' as patientFrom, -- 病人来源  '住院'
                                   c.createareaname_vchr as sentByDepartment, -- 送检科室  必填    
                                   c.creator_chr as sentByDoctor, -- 送检医生  必填
                                   0 as fee,
                                   c.createdate_dat as OrderEntryTime, -- 医嘱开立时间  必填 格式”yyyy-MM-dd hh24:mi:ss” 或者”yyyy.MM.dd hh24:mi:ss”
                                   c.executedate_dat as DoctorChargesTime, -- 医嘱收费时间  必填 格式”yyyy-MM-dd hh24:mi:ss” 或者”yyyy.MM.dd hh24:mi:ss”
                                   '平诊' as AcuteLevelDiagnosis, -- 急平诊 非必填
                                   '' as BalanceSheetNo, -- 结算号 非必填
                                   1 as chargeStatus, -- 0-未收费 1-已收费 2-已退费
                                   '' as chargedesc, g.typetext, c.executedate_dat, c.registerid_chr   
                              from icare.t_bse_patient a
                             inner join icare.t_bse_patientcard b
                                on a.patientid_chr = b.patientid_chr
                             inner join icare.t_opr_bih_order c
                                on a.patientid_chr = c.patientid_chr
                             inner join icare.t_bse_bih_orderdic e
                                on e.orderdicid_chr = c.orderdicid_chr
                             inner join icare.ar_apply_partlist f
                                on c.partid_vchr = f.partid
                             inner join icare.ar_apply_typelist g
                                on e.applytypeid_chr = g.typeid
                             inner join icare.t_bse_deptdesc h
                                on c.curareaid_chr = h.deptid_chr
                             inner join icare.t_bse_employee i
                                on c.doctorid_chr = i.empid_chr
                             inner join icare.t_opr_bih_register k
                                on c.registerid_chr = k.registerid_chr
                             inner join icare.t_bse_bed l
                                on k.bedid_chr = l.bedid_chr
                             where c.status_int in (2, 4, 5)
                               and g.typedesc is not null
                               ";
                    #endregion
                }

                #region where
                string where = string.Empty;
                if (opIp == 1)
                {
                    if (dicKey.ContainsKey("beginDate") && !string.IsNullOrEmpty(dicKey["beginDate"]))
                    {
                        where += string.Format("and c.createdate_dat >= to_date({0}, 'yyyy-mm-dd hh24:mi:ss') ", dicKey["beginDate"]);
                    }
                    if (dicKey.ContainsKey("endDate") && !string.IsNullOrEmpty(dicKey["endDate"]))
                    {
                        where += string.Format("and c.createdate_dat <= to_date({0}, 'yyyy-mm-dd hh24:mi:ss') ", dicKey["endDate"]);
                    }
                    if (dicKey.ContainsKey("cardNumber") && !string.IsNullOrEmpty(dicKey["cardNumber"]))
                    {
                        where += string.Format("and b.patientcardid_chr = '{0}' ", dicKey["cardNumber"]);
                    }
                    if (dicKey.ContainsKey("patientName") && !string.IsNullOrEmpty(dicKey["patientName"]))
                    {
                        where += string.Format("and a.lastname_vchr = '{0}' ", dicKey["patientName"]);
                    }
                }
                else if (opIp == 2)
                {
                    if (dicKey.ContainsKey("beginDate") && !string.IsNullOrEmpty(dicKey["beginDate"]))
                    {
                        where += string.Format("and c.createdate_dat >= to_date({0}, 'yyyy-mm-dd hh24:mi:ss') ", dicKey["beginDate"]);
                    }
                    if (dicKey.ContainsKey("endDate") && !string.IsNullOrEmpty(dicKey["endDate"]))
                    {
                        where += string.Format("and c.createdate_dat <= to_date({0}, 'yyyy-mm-dd hh24:mi:ss') ", dicKey["endDate"]);
                    }
                    if (dicKey.ContainsKey("cardNumber") && !string.IsNullOrEmpty(dicKey["cardNumber"]))
                    {
                        where += string.Format("and b.patientcardid_chr = '{0}' ", dicKey["cardNumber"]);
                    }
                    if (dicKey.ContainsKey("patientName") && !string.IsNullOrEmpty(dicKey["patientName"]))
                    {
                        where += string.Format("and a.lastname_vchr = '{0}' ", dicKey["patientName"]);
                    }
                    if (dicKey.ContainsKey("inHospitalNum") && !string.IsNullOrEmpty(dicKey["inHospitalNum"]))
                    {
                        where += string.Format("and k.inpatientid_chr = '{0}' ", dicKey["inHospitalNum"]);
                    }
                }
                Sql += where;
                #endregion

                #region result
                DataTable dt = svc.GetDataTable(Sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string key = string.Empty;
                    string checkColumn1 = string.Empty;
                    string checkColumn2 = string.Empty;
                    string checkColumn3 = string.Empty;

                    if (opIp == 1)
                    {
                        checkColumn1 = "outpatrecipeid_chr";
                        checkColumn2 = "typetext";
                        checkColumn3 = "patientid_chr";
                    }
                    else if (opIp == 2)
                    {
                        checkColumn1 = "executedate_dat";
                        checkColumn2 = "typetext";
                        checkColumn3 = "registerid_chr";
                    }

                    Dictionary<string, string> dicCheck = new Dictionary<string, string>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        key = dr[checkColumn1].ToString() + dr[checkColumn2].ToString() + dr[checkColumn3].ToString();

                        if (dicCheck.ContainsKey(key))
                        {
                            dicCheck[key] = dicCheck[key] + " " + dr["examineParts"].ToString();
                            continue;
                        }
                        else
                        {
                            dicCheck.Add(key, dr["examineParts"].ToString());
                        }
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        key = dr[checkColumn1].ToString() + dr[checkColumn2].ToString() + dr[checkColumn3].ToString();
                        if (dicCheck.ContainsKey(key))
                        {
                            dr["examineParts"] = dicCheck[key];
                        }
                    }

                    List<string> lstField = new List<string>();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        lstField.Add(dt.Columns[i].ColumnName);
                    }
                    dicCheck.Clear();

                    xmlOut += "<res>" + Environment.NewLine;
                    foreach (DataRow dr in dt.Rows)
                    {
                        key = dr[checkColumn1].ToString() + dr[checkColumn2].ToString() + dr[checkColumn3].ToString();
                        if (dicCheck.ContainsKey(key))
                            continue;
                        else
                            dicCheck.Add(key, string.Empty);

                        xmlOut += "<row>" + Environment.NewLine;
                        foreach (string fieldName in lstField)
                        {
                            if (fieldName == checkColumn1 || fieldName == checkColumn2 || fieldName == checkColumn3) continue;
                            xmlOut += string.Format("<{0}>{1}</{2}>", fieldName, dr[fieldName].ToString(), fieldName) + Environment.NewLine;
                        }
                        xmlOut += "</row>" + Environment.NewLine;
                    }
                    xmlOut += "</res>" + Environment.NewLine;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Log.OutPut(ex.Message);
            }
            return xmlOut;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    #endregion

    #region EntityCriticalMain
    /// <summary>
    /// EntityCriticalMain
    /// </summary>
    [Serializable]
    public class EntityCriticalMain
    {
        public decimal cvmid { get; set; }
        /// <summary>
        /// 病人类型: 1 门诊; 2 住院; 3 急诊;  4 体检
        /// </summary>
        public string pattypeid { get; set; }
        public string cardno { get; set; }
        public string patientid { get; set; }
        public string patname { get; set; }
        public string patsex { get; set; }
        public string patage { get; set; }
        public string patsubno { get; set; }
        public string ipno { get; set; }
        public int? iptimes { get; set; }
        public string bedno { get; set; }
        /// <summary>
        /// 申请类型: 1 LIS; 
        /// </summary>
        public int applytypeid { get; set; }
        public string applyid { get; set; }
        public string applyitem { get; set; }
        public DateTime modifydate { get; set; }
        public DateTime applydate { get; set; }
        public string applyempid { get; set; }
        public string applydeptid { get; set; }
        public string applypatdeptid { get; set; }
        public string recorderid { get; set; }
        public string recorddeptid { get; set; }
        public DateTime recorddate { get; set; }
        public string responseempid { get; set; }
        public string responsedeptid { get; set; }
        public string responsemsg { get; set; }
        public DateTime? responsedate { get; set; }
        /// <summary>
        /// 状态: -1 无效; 0 无应答; 1 已应答
        /// </summary>
        public int status { get; set; }
    }
    #endregion

    #region EntityApplication
    /// <summary>
    /// EntityApplication
    /// </summary>
    [Serializable]
    public class EntityApplication
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// 申请单ID
        /// </summary>
        public string RequisitionID { get; set; }
        /// <summary>
        /// 医嘱ID
        /// </summary>
        public string DoctorAdviceID { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string patientName { get; set; }
        /// <summary>
        /// 病人年龄
        /// </summary>
        public string patientAge { get; set; }
        /// <summary>
        /// 出生日期  必填（yyyy-MM-dd根据出生日期得到年龄）
        /// </summary>
        public string patientBirthday { get; set; }
        /// <summary>
        /// 性别  必填(男、女、其他)
        /// </summary>
        public string patientSex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string patientTelephone { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string patientUnit { get; set; }
        /// <summary>
        /// 病人住址
        /// </summary>
        public string patientAddress { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string patientNation { get; set; }
        /// <summary>
        /// 床位号
        /// </summary>
        public string bedNum { get; set; }
        /// <summary>
        /// 临床诊断
        /// </summary>
        public string clinicalDiagnosis { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary>
        public string clinicalNum { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string inHospitalNum { get; set; }
        /// <summary>
        /// 影像号 非必填 
        /// </summary>
        public string Patient_uid { get; set; }
        /// <summary>
        /// 检查部位  必填
        /// </summary>
        public string examineParts { get; set; }
        /// <summary>
        /// 检查类型  必填(详见检查类型设定.txt)
        /// </summary>
        public string examineType { get; set; }
        /// <summary>
        /// 病区
        /// </summary>
        public string hospitalDistrictNum { get; set; }
        /// <summary>
        /// 病人来源
        /// </summary>
        public string patientFrom { get; set; }
        /// <summary>
        /// 送检科室
        /// </summary>
        public string sentByDepartment { get; set; }
        /// <summary>
        /// 送检医生
        /// </summary>
        public string sentByDoctor { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string fee { get; set; }
        /// <summary>
        /// 医嘱开立时间
        /// </summary>
        public string OrderEntryTime { get; set; }
        /// <summary>
        /// 医嘱收费时间
        /// </summary>
        public string DoctorChargesTime { get; set; }
        /// <summary>
        /// 急平诊
        /// </summary>
        public string AcuteLevelDiagnosis { get; set; }
        /// <summary>
        /// 结算号
        /// </summary>
        public string BalanceSheetNo { get; set; }
        /// <summary>
        /// 0-未收费 1-已收费 2-已退费
        /// </summary>
        public string chargeStatus { get; set; }
        /// <summary>
        /// 收费描述
        /// </summary>
        public string chargedesc { get; set; }
    }
    #endregion
}
