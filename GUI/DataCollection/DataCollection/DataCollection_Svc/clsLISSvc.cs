using System;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.DataCollection;
using System.Data.OracleClient;
using System.Collections;

namespace com.digitalwave.iCare.middletier.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsLISQuerySvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        /// <summary>
        /// ��ѯ�������뵥��Ϣ(δ�ϵ������뵥�������������סԺ��Ϣ,����ȥ������,ȡ���������뵥��Ϣ)-No.1
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryLISAppByDate(string p_strStartDate, string p_strEndDate, out clsLISAppl_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strStartDate) || string.IsNullOrEmpty(p_strEndDate))
            {
                return lngRes;
            }

            clsHRPTableService objHRPServ = null;
            //Hashtable objHsTable = new Hashtable();
            try
            {
                string strSQL = @"select
                                '' organcode,
                                t.application_id_chr observationid,--���鵥��
                                patientcardid_chr visitno, --������ˮ��
                                '' inhosseqno,--סԺ��ˮ��
                                t3.paytypeid_chr kind, --�������ʴ���
                                t1.sample_type_id_chr proveswatchcode,--�����������
                                t1.sample_type_vchr proveswatchname, --������������
                                t1.sample_type_id_chr provetype, --����������
                                t.modify_dat observationdatetime,--��������
                                t1.application_dat createobservationdatetime,--����ʱ��
                                t1.appl_empid_chr createcliniciancode, --����ҽ������
                                f_getempnamebyid(t1.appl_empid_chr) createclinicianname, --����ҽ������
                                t2.operator_id_chr observationoptcode, --������Ա����
                                f_getempnamebyid(t2.operator_id_chr) observationoptname, --������Ա����
                                '' observationway,  --���鷽��
                                t1.appl_deptid_chr observationdeptcode, --�������Ҵ���
                                f_getdeptnamebyid(t1.appl_deptid_chr) observationdeptname, --������������
                                '' observationoptdeptcode, --ִ�п��Ҵ���
                                '' observationoptdeptname, --ִ�п�������
                                '0' flag, --���ϱ�־����
                                t4.registerid_chr,
                                t5.attarelaid_chr,   --��Ӧ��ˮ��
                                t5.sourceitemid_vchr, --Դid (����) = ����id; (סԺ) = ҽ��id 
                                t5.sysfrom_int  --��Դ 1=����;2=סԺ
                                from 
                                (select a.modify_dat,a1.application_id_chr,a1.sample_id_chr
                                from t_opr_lis_check_result a left join t_opr_lis_app_sample a1 
                                on a.sample_id_chr = a1.sample_id_chr and a.groupid_chr = a1.sample_group_id_chr 
                                where a.modify_dat between ? and ?
                                and a.status_int = 1) t
                                left join t_opr_lis_application t1 
                                on t.application_id_chr = t1.application_id_chr and t1.pstatus_int > 0 and t1.orderunitrelation_vchr in null
                                left join t_opr_lis_app_report t2 
                                on t1.application_id_chr = t2.application_id_chr and t2.status_int = 2
                                left outer join t_bse_patient t3 
                                on t1.patientid_chr = t3.patientid_chr
                                left outer join (select b.patientid_chr,max(b.registerid_chr) as registerid_chr
                                                     from t_opr_bih_register b group by b.patientid_chr) t4 
                                on t4.patientid_chr = t3.patientid_chr
                                left outer join (select d.attarelaid_chr,d.sysfrom_int,d.sourceitemid_vchr,d.attachid_vchr 
                                from t_opr_attachrelation d where d.attarelaid_chr in (select max(c.attarelaid_chr) 
                                from t_opr_attachrelation c group by c.attachid_vchr)) t5
                                           on t.application_id_chr = t5.attachid_vchr";

                IDataParameter[] objDPArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = Convert.ToDateTime(p_strStartDate);
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = Convert.ToDateTime(p_strEndDate);

                List<clsLISAppl_VO> objList = new List<clsLISAppl_VO>();
                DataTable dtResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objHRPServ.Dispose();
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    int iRowCount = dtResult.Rows.Count;

                    clsLISAppl_VO objTemp = null;
                    p_objResultArr = new clsLISAppl_VO[iRowCount];
                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        drTemp = dtResult.Rows[iRow];
                        objTemp = new clsLISAppl_VO();
                        objTemp.m_strOBSERVATIONID = drTemp["observationid"].ToString().Trim();
                        if (drTemp["sysfrom_int"].ToString().Trim() == "1")
                        {
                            objTemp.m_strVISITNO = drTemp["sourceitemid_vchr"].ToString().Trim();
                        }
                        if (drTemp["sysfrom_int"].ToString().Trim() == "2")
                        {
                            objTemp.m_strINHOSSEQNO = drTemp["registerid_chr"].ToString().Trim();
                        }
                      
                        objTemp.m_strKIND = clsDataUpload_Svc.m_strConvertValue("kind", drTemp["paytypeid_chr"].ToString().Trim(), "");

                        objTemp.m_strPROVESWATCHCODE = drTemp["proveswatchcode"].ToString().Trim();
                        objTemp.m_strPROVESWATCHNAME = drTemp["proveswatchname"].ToString().Trim();
                        objTemp.m_strPROVETYPE = drTemp["proveswatchcode"].ToString().Trim();

                        objTemp.m_strOBSERVATIONDATETIM = Convert.ToDateTime(drTemp["modify_dat"]).ToString("yyyy-MM-dd HH:mm:ss");
                        objTemp.m_strCREATEOBSERVATIONDATETIME = drTemp["createobservationdatetime"] != DBNull.Value ? Convert.ToDateTime(drTemp["createobservationdatetime"]).ToString("yyyy-MM-dd HH:mm:ss") : "";

                        objTemp.m_strCREATECLINICIANCODE = drTemp["createcliniciancode"].ToString().Trim();
                        if (string.IsNullOrEmpty(objTemp.m_strCREATECLINICIANCODE))
                        {
                            objTemp.m_strCREATECLINICIANCODE = "*";
                        }
                        objTemp.m_strCREATECLINICIANNAME = drTemp["createclinicianname"].ToString().Trim();
                        if (string.IsNullOrEmpty(objTemp.m_strCREATECLINICIANNAME))
                        {
                            objTemp.m_strCREATECLINICIANNAME = "*";
                        }
                        objTemp.m_strOBSERVATIONOPTCODE = drTemp["observationoptcode"].ToString().Trim();
                        objTemp.m_strOBSERVATIONOPTNAME = drTemp["observationoptname"].ToString().Trim();
                        objTemp.m_strOBSERVATIONWAY = drTemp["checkmonth"].ToString().Trim();

                        objTemp.m_strOBSERVATIONDEPTCODE = drTemp["observationdeptcode"].ToString().Trim();
                        if (string.IsNullOrEmpty(objTemp.m_strOBSERVATIONDEPTCODE))
                        {
                            objTemp.m_strOBSERVATIONDEPTCODE = "*";
                        }
                        objTemp.m_strOBSERVATIONDEPTNAME = drTemp["observationdeptname"].ToString().Trim();


                        objTemp.m_strOBSERVATIONOPTDEPTCODE = "*";
                        objTemp.m_strOBSERVATIONOPTDEPTNAME = "*";

                        objTemp.m_strFLAG = drTemp["flag"].ToString().Trim();

                        if (string.IsNullOrEmpty(objTemp.m_strOBSERVATIONDEPTNAME))
                        {
                            objTemp.m_strOBSERVATIONDEPTNAME = "*";
                        }


                        try
                        {
                            //objHsTable.Add(objTemp.m_strVISITNO + objTemp.m_strINHOSSEQNO + objTemp.m_strOBSERVATIONID, "");
                            objList.Add(objTemp);
                        }
                        catch { }
                    }
                    p_objResultArr = objList.ToArray();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
                p_strEndDate = null;
                p_strStartDate = null;
                //objHsTable.Clear();
            }
            return lngRes;
        }

        /// <summary>
        /// ��ѯ ������ϸ��Ϣ
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryLISAppItemByDate(string p_strStartDate, string p_strEndDate, out clsLISApplItem_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strStartDate) || string.IsNullOrEmpty(p_strEndDate))
                return lngRes;

            clsHRPTableService objHRPServ = null;
            //Hashtable objHsTable = new Hashtable();
            try
            {
                string strSQL = @"--���뵥��ϸ��
select
'' organcode,
seq_ygyylis_id.nextval list_seq,
t4.check_category_id_chr recordtype, --�������
t4.check_category_desc_vchr,         --��������
t.application_id_chr observationid,   --���鵥��
t1.check_item_id_chr observationsubid, --������Ŀ����
t2.check_item_english_name_vchr provename, --����Ӣ������
t2.check_item_name_vchr observationsubname, --������Ŀ����
t2.resulttype_chr resulttype, --�������
t.result_vchr observationvalue,  --������Ŀֵ
t2.unit_chr units, --��λ
t2.ref_value_range_vchr referencesrange, --�ο���Χ
'' observationresultstatus, --����ָ��
t.summary_vchr demo, --��ע
t6.devicename_vchr apparatus, --��������
t.abnormal_flag_chr singularity --�쳣��ʾ
from 
(select a.modify_dat,a.result_vchr,a1.application_id_chr,a1.sample_id_chr,a.groupid_chr,a.check_item_id_chr,a.summary_vchr,a.abnormal_flag_chr
from t_opr_lis_check_result a left join t_opr_lis_app_sample a1 on a.sample_id_chr = a1.sample_id_chr and a.groupid_chr = a1.sample_group_id_chr 
where a.modify_dat between ? and ?  and a.status_int = 1) t
left outer join t_opr_lis_app_check_item t1 on t1.application_id_chr = t.application_id_chr and t1.sample_group_id_chr = t.groupid_chr and t1.check_item_id_chr = t.check_item_id_chr
left outer join t_bse_lis_check_item t2 on t1.check_item_id_chr = t2.check_item_id_chr and t2.resulttype_chr <> 1
left outer join t_aid_lis_sample_group t3 on t3.sample_group_id_chr = t1.sample_group_id_chr
left outer join t_bse_lis_check_category t4 on t4.check_category_id_chr = t3.check_category_id_chr
left outer join t_opr_lis_device_relation t5 on t5.sample_id_chr = t.sample_id_chr and t5.status_int = 2
left outer join t_bse_lis_device t6 on t6.deviceid_chr = t5.deviceid_chr";

                IDataParameter[] objDPArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = Convert.ToDateTime(p_strStartDate);
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = Convert.ToDateTime(p_strEndDate);

                DataTable dtResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objHRPServ.Dispose();
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    int iRowCount = dtResult.Rows.Count;
                    clsLISApplItem_VO objTemp = null;
                    p_objResultArr = new clsLISApplItem_VO[iRowCount];
                    List<clsLISApplItem_VO> objList = new List<clsLISApplItem_VO>();
                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        drTemp = dtResult.Rows[iRow];
                        objTemp = new clsLISApplItem_VO();
                        DateTime dt = DateTime.MinValue;

                        objTemp.m_strLIST_SEQ = drTemp["list_seq"].ToString().Trim();
                        objTemp.m_strRECORDTYPE = clsDataUpload_Svc.m_strConvertValue("checkcategory", drTemp["recordtype"].ToString().Trim(), "");
                        objTemp.m_strOBSERVATIONID = drTemp["observationid"].ToString().Trim();

                        objTemp.m_strOBSERVATIONSUBID = drTemp["observationsubid"].ToString().Trim();
                        objTemp.m_strPROVENAME = drTemp["provename"].ToString().Trim();
                        objTemp.m_strOBSERVATIONSUBNAME = drTemp["observationsubname"].ToString().Trim();

                        objTemp.m_strRESULTTYPE = clsDataUpload_Svc.m_strConvertValue("resulttype_chr", drTemp["resulttype"].ToString().Trim(), "");
                        objTemp.m_strOBSERVATIONVALUE = drTemp["observationvalue"].ToString().Trim();
                        objTemp.m_strUNITS = drTemp["units"].ToString().Trim();
                        objTemp.m_strREFERENCESRANGE = drTemp["referencesrange"].ToString().Trim();

                        objTemp.m_strOBSERVATIONRESULTSTATUS = drTemp["observationresultstatus"].ToString().Trim();
                        objTemp.m_strDEMO = drTemp["demo"].ToString().Trim();

                        objTemp.m_strAPPARATUS = drTemp["apparatus"].ToString().Trim();
                        if (string.IsNullOrEmpty(objTemp.m_strAPPARATUS))
                        {
                            objTemp.m_strAPPARATUS = "�ֹ�";
                        }
                        objTemp.m_strSINGULARITY = drTemp["singularity"].ToString().Trim();

                        try
                        {
                            //objHsTable.Add(objTemp.m_strOBSERVATIONID + objTemp.m_strOBSERVATIONSUBID, "");
                            objList.Add(objTemp);
                        }
                        catch { }
                    }
                    p_objResultArr = objList.ToArray();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
                p_strEndDate = null;
                p_strStartDate = null;
            }

            return lngRes;
        }

        /// <summary>
        /// ��������ϸ��Ϣ
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryLISAppDetialByDate(string p_strStartDate, string p_strEndDate, out clsLISApplDetial_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strStartDate) || string.IsNullOrEmpty(p_strEndDate))
                return lngRes;

            clsHRPTableService objHRPServ = null;
            //Hashtable objHsTable = new Hashtable();
            try
            {
                string strSQL = @"select 
'' organcode,--organcode
seq_ygyylis_idsub.nextval sublist_seq,
t.application_id_chr observationid, --���鵥��
'*' observationsub_id, --������Ŀ����t1.apply_unit_id_chr
t.check_item_id_chr observationcode, --��������Ŀ����
t2.rptno_chr observationname, --�������Ŀ����
t2.check_item_english_name_vchr observationenname, --�������Ŀ����(Ӣ��)
t.result_vchr observationvalue --������
from 
(select a.modify_dat,a.result_vchr,a1.application_id_chr,a1.sample_id_chr,a.groupid_chr,a.check_item_id_chr,a.summary_vchr,a.abnormal_flag_chr,a.deviceid_chr
from t_opr_lis_check_result a left join t_opr_lis_app_sample a1 on a.sample_id_chr = a1.sample_id_chr and a.groupid_chr = a1.sample_group_id_chr 
where a.modify_dat between ? and ? and a.status_int = 1) t
left join t_bse_lis_check_item t2 on t2.check_item_id_chr = t.check_item_id_chr and t2.resulttype_chr <> 1";

                IDataParameter[] objDPArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = Convert.ToDateTime(p_strStartDate);
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = Convert.ToDateTime(p_strEndDate);

                DataTable dtResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objHRPServ.Dispose();
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    int iRowCount = dtResult.Rows.Count;
                    clsLISApplDetial_VO objTemp = null;
                    p_objResultArr = new clsLISApplDetial_VO[iRowCount];
                    List<clsLISApplDetial_VO> objList = new List<clsLISApplDetial_VO>();
                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        drTemp = dtResult.Rows[iRow];
                        objTemp = new clsLISApplDetial_VO();
                        objTemp.m_strOBSERVATIONID = drTemp["observationid"].ToString().Trim();
                        objTemp.m_strOBSERVATIONSUB_ID = drTemp["observationsub_id"].ToString().Trim();
                        objTemp.m_strOBSERVATIONCODE = drTemp["observationcode"].ToString().Trim();
                        objTemp.m_strOBSERVATIONNAME = drTemp["observationname"].ToString().Trim();
                        if (string.IsNullOrEmpty(objTemp.m_strOBSERVATIONNAME))
                        {
                            objTemp.m_strOBSERVATIONNAME = "*";
                        }
                        objTemp.m_strOBSERVATIONENNAME = drTemp["observationenname"].ToString().Trim();
                        if (string.IsNullOrEmpty(objTemp.m_strOBSERVATIONENNAME))
                        {
                            objTemp.m_strOBSERVATIONENNAME = "*";
                        }
                        objTemp.m_strOBSERVATIONVALUE = drTemp["observationvalue"].ToString().Trim();
                        if (string.IsNullOrEmpty(objTemp.m_strOBSERVATIONVALUE))
                        {
                            objTemp.m_strOBSERVATIONVALUE = "*";
                        }
                        //objTemp.m_strSUBLIST_SEQ = drTemp["application_id_chr"].ToString().Trim() + "-" + objTemp.m_strOBSERVATIONSUB_ID + "-" + objTemp.m_strOBSERVATIONCODE;
                        //��ʱ��
                        objTemp.m_strSUBLIST_SEQ = drTemp["sublist_seq"].ToString().Trim();

                        try
                        {
                            //objHsTable.Add(objTemp.m_strOBSERVATIONID + objTemp.m_strOBSERVATIONSUB_ID + objTemp.m_strOBSERVATIONCODE, "");
                            objList.Add(objTemp);
                        }
                        catch { }
                    }
                    p_objResultArr = objList.ToArray();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
                p_strEndDate = null;
                p_strStartDate = null;
            }

            return lngRes;
        }







        /// <summary>
        /// ��ѯסԺ���뵥��Ϣ
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryLISAppHISByDate(string p_strStartDate, string p_strEndDate, out clsLISAppl_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strStartDate) || string.IsNullOrEmpty(p_strEndDate))
                return lngRes;

            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select '' as outrester,
       c.registerid_chr as inrester,
       t.application_id_chr,t.modify_dat,
       a.confirm_dat,
       t.application_dat,
       t.appl_empid_chr,
       d.lastname_vchr as applempname,
       a.confirmer_id_chr as checkerid,
       e.lastname_vchr as checkername,
       '' as checkmonth,
       t.appl_deptid_chr,
       f.deptname_vchr
  from t_opr_lis_application t
 inner join t_opr_lis_sample a on a.application_id_chr =
                                  t.application_id_chr
                              and a.status_int = 6
  inner join t_opr_attachrelation b on b.attarelaid_chr = t.application_id_chr
                                        and b.sysfrom_int = 2
                                        and b.status_int = 1
                                        and b.attachtype_int = 3
  left outer join t_opr_bih_order c on c.orderid_chr = b.sourceitemid_vchr
  left outer join t_bse_employee d on t.appl_empid_chr = d.empid_chr
  left outer join t_bse_employee e on a.confirmer_id_chr = e.empid_chr
  left outer join t_bse_deptdesc f on f.deptid_chr = t.appl_deptid_chr
 where t.pstatus_int > 0
   and a.confirm_dat between ? and ?";

                IDataParameter[] objDPArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = Convert.ToDateTime(p_strStartDate);
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = Convert.ToDateTime(p_strEndDate);

                DataTable dtResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objHRPServ.Dispose();
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    int iRowCount = dtResult.Rows.Count;

                    clsLISAppl_VO objTemp = null;
                    p_objResultArr = new clsLISAppl_VO[iRowCount];
                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        drTemp = dtResult.Rows[iRow];
                        objTemp = new clsLISAppl_VO();

                        objTemp.m_strVISITNO = drTemp["outrester"].ToString().Trim();
                        objTemp.m_strINHOSSEQNO = drTemp["inrester"].ToString().Trim();
                        objTemp.m_strOBSERVATIONID = drTemp["application_id_chr"].ToString().Trim();
                        objTemp.m_strOBSERVATIONDATETIM = drTemp["confirm_dat"] != DBNull.Value ? Convert.ToDateTime(drTemp["confirm_dat"]).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        objTemp.m_strCREATEOBSERVATIONDATETIME = drTemp["application_dat"] != DBNull.Value ? Convert.ToDateTime(drTemp["application_dat"]).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        objTemp.m_strCREATECLINICIANCODE = drTemp["appl_empid_chr"].ToString().Trim();
                        objTemp.m_strCREATECLINICIANNAME = drTemp["applempname"].ToString().Trim();
                        objTemp.m_strOBSERVATIONOPTCODE = drTemp["checkerid"].ToString().Trim();
                        objTemp.m_strOBSERVATIONOPTNAME = drTemp["checkername"].ToString().Trim();
                        objTemp.m_strOBSERVATIONWAY = drTemp["checkmonth"].ToString().Trim();
                        objTemp.m_strOBSERVATIONDEPTCODE = drTemp["appl_deptid_chr"].ToString().Trim();
                        objTemp.m_strOBSERVATIONDEPTNAME = drTemp["deptname_vchr"].ToString().Trim();

                        //// ִ�п��Ҵ��� + ִ�п�������
                        //objTemp.m_strOBSERVATIONOPTDEPTCODE = drTemp[""].ToString().Trim(); 
                        //objTemp.m_strOBSERVATIONOPTDEPTNAME = drTemp[""].ToString().Trim();

                        p_objResultArr[iRow] = objTemp;
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
    }
}
