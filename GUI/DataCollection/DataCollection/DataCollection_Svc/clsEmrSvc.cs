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
    //Start====qinhong====住院信息查询（常平）==================
    /// <summary>
    /// 住院信息查询
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsEmrSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        /// <summary>
        /// 病案首页接口查询
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetFirstPageInfo(string p_strStartDate, string p_strEndDate, out List<clsFirstPageVO> p_lstFirstPage)
        {
            p_lstFirstPage = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strStartDate) || string.IsNullOrEmpty(p_strEndDate))
                return lngRes;

            clsHRPTableService objHRPServ = null;
            try
            {
                #region sql
                string strSQL = @"select 
t1.registerid_chr fid,
t1.inpatientid_chr fprn,
t1.inpatientcount_int ftimes,
'icd10' ficdversion,
t1.registerid_chr fzyid,
'' fage,
t2.lastname_vchr fname,
decode(t2.sex_chr,'男','1','女','2','3') fsexbh,
t2.sex_chr fsex,
t2.birth_dat fbirthday,
t2.birthplace_vchr fbirthplace,
t2.idcard_chr fidcard,
'' fcountrybh,
t2.nationality_vchr fcountry,
'' fnationalitybh,
t2.race_vchr fnationality,
t2.occupation_vchr fjob,
decode(t2.married_chr,'未婚','10','已婚','20','初婚','21','再婚','22','复婚','23','丧偶','30','离婚','40','99') fstatusbh,
t2.married_chr fstatus,
t2.employer_vchr fdwname,
t2.officeaddress_vchr fdwaddr,
t2.officephone_vchr fdwtele,
t2.officepc_vchr fdwpost,
t2.residenceplace_vchr fhkaddr,
'' fhkpost,
t2.contactpersonfirstname_vchr flxname,
t2.patientrelation_vchr frelate,
t2.contactpersonaddress_vchr flxaddr,
t2.contactpersonphone_vchr flxtele,
'' ffbbh,
t4.modeofpayment ffb,
t2.insuranceid_vchr fascard1,  
t2.insuranceid_vchr fascard2,  
t1.inpatient_dat frydate,
t1.inpatient_dat frytime,
t1.deptid_chr frytykh,      
t1.deptid_chr frydept,      
t1.areaid_chr frybs,
t.outhospital_dat fcydate,  
t.outhospital_dat fcytime, 
t.outdeptid_chr fcytykh,
t.outdeptid_chr fcydept,
t.outareaid_chr fcybs,
t.preouthospital_dat fdays,
t3.mzicd10 fmzzdbh,
t4.diagnosis fmzzd,
t4.doctor fmzdoctbh, 
f_getempnamebyid(t4.doctor) fmzdoct,   
t4.condictionwhenin fryinfobh,
decode(t4.condictionwhenin,'0','危','1','急','2','一般','9') fryinfo,
t4.inhospitaldiagnosis fryzdbh,
t4.inhospitaldiagnosis fryzd,
t4.confirmdiagnosisdate fqzdate,
t4.pathologydiagnosis fphzd,
t4.sensitive fgmyw,
t4.hbsag fhbsagbh,
decode(t4.hbsag,'0','未做','1','阴性','2','阳性','9') fhbsag,
t4.hcv_ab fhcvabbh,
decode(t4.hcv_ab,'0','未做','1','阴性','2','阳性','9') fhcvab,
t4.hiv_ab fhivabbh,
decode(t4.hiv_ab,'0','未做','1','阴性','2','阳性','9') fhivab,
t4.accordwithouthospital fmzcyaccobh,
decode(t4.accordwithouthospital,'0','未做','1','符合','2','不符合','3','不肯定','9') fmzcyacco,
t4.accordinwithout frycyaccobh,
decode(t4.accordinwithout,'0','未做','1','符合','2','不符合','3','不肯定','9') frycyacco,
t4.accordclinicwithpathology flcblaccobh,
decode(t4.accordclinicwithpathology,'0','未做','1','符合','2','不符合','3','不肯定','9') flcblacco,
t4.accordradiatewithpathology ffsblaccobh,
decode(t4.accordradiatewithpathology,'0','未做','1','符合','2','不符合','3','不肯定','9') ffsblacco,
t4.accordbeforeoperationwithafter fopaccobh,
decode(t4.accordbeforeoperationwithafter,'0','未做','1','符合','2','不符合','3','不肯定','9') fopacco,
t4.salvetimes fqjtimes,
t4.salvesuccess fqjsuctimes,
t4.directordt fkzrbh,
f_getempnamebyid(t4.directordt) fkzr,
t4.subdirectordt fzrdoctbh,
f_getempnamebyid(t4.subdirectordt) fzrdoctor,
t4.dt fzzdoctbh,
f_getempnamebyid(t4.dt) fzzdoct,
t4.inhospitaldt fzydoctbh,
f_getempnamebyid(t4.inhospitaldt) fzydoct,
t4.attendinforadvancesstudydt fjxdoctbh,
f_getempnamebyid(t4.attendinforadvancesstudydt) fjxdoct,
t4.graduatestudentintern fyjssxdoctbh,
f_getempnamebyid(t4.graduatestudentintern) fyjssxdoct,
t4.intern fsxdoctbh,
f_getempnamebyid(t4.intern) fsxdoct,
t4.coder fbmybh,
f_getempnamebyid(t4.coder) fbmy,
'' fzlrbh,
'' fzlr,
t4.quality fqualitybh,
f_getempnamebyid(t4.quality) fquality,
t4.qcdt fzkdoctbh,
f_getempnamebyid(t4.qcdt) fzkdoct,
t4.qcnurse fzknursebh,
f_getempnamebyid(t4.qcnurse) fzknurse,
t4.qctime fzkrq,
'' fmzdeadbh,
'' fmzdead,
'' fsum1,
'' fcwf,
'' fhlf,
'' fxyf,
'' fzyf,
'' fzchyf,
'' fzcyf,
'' ffsf,
'' fhyf,
'' fsyf,
'' fsxf,
'' fzlf,
'' fssf,
'' fjsf,
'' fjcf,
'' fmzf,
'' fyef,
'' fpcf,
'' fqtf,
t4.corpsecheck fbodybh,
decode(t4.corpsecheck,'1','是','2','否','否') fbody,
t4.firstcase fisopfirstbh,
decode(t4.follow,'1','是','0','否','') fisopfirst,
t4.firstcase fiszlfirstbh,
decode(t4.follow,'1','是','0','否','') fiszlfirst,
t4.firstcase fisjcfirstbh,
decode(t4.follow,'1','是','0','否','') fisjcfirst,
t4.firstcase fiszdfirstbh,
decode(t4.follow,'1','是','0','否','') fiszdfirst,
t4.follow fisszbh,
decode(t4.follow,'1','是','0','否','未随诊') fissz,
(decode(t4.follow_year,'','0','/','0',t4.follow_year)||'年'||decode(t4.follow_month,'','0','/','0',t4.follow_month)||'月'|| decode(t4.follow_month,'','0','/','0',t4.follow_week)||'周') fszqx,
t4.modelcase fsamplebh,
decode(t4.modelcase,'1','是','0','否','否') fsample,
t4.bloodtype fbloodbh,
decode(t4.bloodtype,'1','a','2','b','3','o','4','ab','5','不详','6','未查','未查') fblood,
t4.bloodrh frhbh,
decode(t4.bloodrh,'1','阴','2','阳','3','未查','未查') frh,
t4.bloodtransactoin fsxfybh,
decode(t4.bloodtransactoin,'1','有','2','无','3','未输血','未输血') fsxfy,
'' fsyfybh,
'' fsyfy,
t4.rbc fredcell,
t4.plt fplaque,
t4.plasm fserous,
t4.wholeblood fallblood,
t4.otherblood fotherblood,
t4.consultation fhzyj,
t4.longdistanctconsultation fhzyc,
t4.toplevel fhltj,
t4.nurseleveli fhl1,
t4.nurselevelii fhl2,
t4.nurseleveliii fhl3,
t4.icu fhlzz,
t4.specialnurse fhlts,
'' fbabynum, 
'' ftwill,
decode(t4.salvetimes,'','0','0','0','1') fqjbr,
t4.salvesuccess fqjsuc,
t4.confirmdiagnosisdate fthreqz,
decode(t4.readmitted31_int,'2','2','1','1','1') fback,
'' fifzdss,   
'' fifdbz,
'' fzlfzy,  
'' fzktykh,
f_getdeptnamebyid((select r.targetdeptid_chr from t_opr_bih_transfer r where r.modify_dat = (select min(modify_dat) from t_opr_bih_transfer where type_int = 3 and registerid_chr = t.registerid_chr) and r.type_int = 3 and  r.registerid_chr = t.registerid_chr)) fzkdept,
(select min(modify_dat) from t_opr_bih_transfer where type_int = 3 and registerid_chr = t.registerid_chr) fzkdate,
'' fzktime,
'' fsrybh,
'' fsry,
'' fworkrq,
'' fjbfxbh,
'' fjbfx,
'' ffhgdbh,
'' ffhgd,
t5.patientsources_vchr fsourcebh, 
t5.patientsources_vchr fsource,
t4.operation fifss,
'' fiffyk,
'' fbfz,
'' fyngr,
'' fflag,
'' fdatacheck,
'' fextend1,
'' fextend2,
'' fextend3,
'' fextend4,
'' fextend5,
'' fextend6,
'' fextend7,
'' fextend8,
'' fextend9,
'' fextend10,
'' fextend11,
'' fextend12,
'' fextend13,
'' fextend14,
'' fextend15,
t2.nativeplace_vchr fnative,
t2.homeaddress_vchr fcurraddr,
t2.homephone_vchr fcurrtele,
t2.homepc_chr fcurrpost,
'' fjobbh,
t4.newbabyweight fcstz,
t4.newbabyinhostpitalweight frytz,
t4.inhospitalway fryresourcebh,
t4.inhospitalway fryresource,
t4.path fycljbh,
decode(t4.path,'1','是','2','否','否') fyclj,
t4.blzd_jbbm fphzdbh,
t4.blzd_blh fphzdnum,
decode(t4.sensitive,'','0','1') fifgmywbh,
decode(t4.sensitive,'','否','是') fifgmyw,
t4.graduatestudentintern fnursebh,
f_getempnamebyid(t4.graduatestudentintern) fnurse,
t4.discharged_int flyfsbh,
t4.discharged_int flyfs,
t4.discharged_varh fyzouthostital,
t4.discharged_varh fsqouthostital,
t4.readmitted31_int fisagainrybh,
decode(t4.readmitted31_int,'1','无','2','有','无') fisagainry,
t4.readmitted31_varh fisagainrymd,
t4.inrnssday fryqhmdays,
t4.inrnsshour fryqhmhours,
t4.inrnssmin fryqhmmins,
'' fryqhmcounts,
t4.outrnssday fryhmdays,
t4.outrnsshour fryhmhours,
t4.outrnssmin  fryhmmins,
'' fryhmcounts, 
'' ffbbhnew,
'' ffbnew,
'' fzfje,
'' fzhfwlylf,
'' fzhfwlczf,
'' fzhfwlhlf,
'' fzhfwlqtf,
'' fzdlblf,
'' fzdlsssf,
'' fzdlyxf,
'' fzdllcf,
'' fzllffssf,
'' fzllfwlzwlf,
'' fzllfssf,
'' fzllfmzf,
'' fzllfsszlf,
'' fkflkff,
'' fzylzf,
'' fxylgjf,
'' fxylxf,
'' fxylbqbf,
'' fxylqdbf,
'' fxylyxyzf,
'' fxylxbyzf,
'' fhclcjf,
'' fhclzlf,
'' fhclssf,
'' fzhfwlylf01,
'' fzhfwlylf02,
'' fzylzdf,
'' fzylzlf,
''  fzylzlf01,
''  fzylzlf02,
''  fzylzlf03,
''  fzylzlf04,
''  fzylzlf05,
''  fzylzlf06,
''  fzylqtf,
''  fzylqtf01,
''  fzylqtf02,
''  fzcljgzjf
from t_opr_bih_leave t, t_opr_bih_register t1, t_opr_bih_registerdetail t2,
     inhospitalmainrecord t3, inhospitalmainrecord_content t4,t_bse_patient t5
where (t.registerid_chr = t1.registerid_chr(+) and t.status_int = '1' and t1.status_int = '1')
and t1.registerid_chr = t2.registerid_chr(+)
and (t1.inpatientid_chr = t3.inpatientid and t1.modify_dat = t3.inpatientdate and t3.status = '1')
and (t3.inpatientid = t4.inpatientid and  t3.opendate = t4.opendate and t1.modify_dat = t4.inpatientdate and t4.status = '1')
and t1.patientid_chr = t5.patientid_chr(+) 
and t.outhospital_dat between ? and ?";
                #endregion
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
                    clsFirstPageVO objTemp = null;
                    p_lstFirstPage = new List<clsFirstPageVO>();
                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        drTemp = dtResult.Rows[iRow];
                        objTemp = new clsFirstPageVO();
                        DateTime m_dTime;
                        int m_intNum = 0;
                        double m_DblNum = 0;
                        objTemp.m_strjgdm = "457226325"; //医院代码 茶山医院457226325  CP  457228806);
                        #region 赋值
                        objTemp.m_strfid = drTemp["fid"].ToString();
                        objTemp.m_strfprn = drTemp["fprn"].ToString();
                        objTemp.m_strftimes = drTemp["ftimes"].ToString();
                        objTemp.m_strficdversion = drTemp["ficdversion"].ToString();
                        objTemp.m_strfzyid = drTemp["fzyid"].ToString();
                        objTemp.m_strfage = drTemp["fage"].ToString();
                        objTemp.m_strfname = drTemp["fname"].ToString();
                        objTemp.m_strfsexbh = drTemp["fsexbh"].ToString();
                        objTemp.m_strfsex = drTemp["fsex"].ToString();
                        if (DateTime.TryParse(drTemp["fbirthday"].ToString(), out m_dTime))
                            objTemp.m_strfbirthday = m_dTime;
                        objTemp.m_strfbirthplace = drTemp["fbirthplace"].ToString();
                        objTemp.m_strfidcard = drTemp["fidcard"].ToString();
                        objTemp.m_strfcountrybh = drTemp["fcountrybh"].ToString();
                        objTemp.m_strfcountry = drTemp["fcountry"].ToString();
                        objTemp.m_strfnationalitybh = drTemp["fnationalitybh"].ToString();
                        objTemp.m_strfnationality = drTemp["fnationality"].ToString();
                        objTemp.m_strfjob = drTemp["fjob"].ToString();
                        objTemp.m_strfstatusbh = drTemp["fstatusbh"].ToString();
                        objTemp.m_strfstatus = drTemp["fstatus"].ToString();
                        objTemp.m_strfdwname = drTemp["fdwname"].ToString();
                        objTemp.m_strfdwaddr = drTemp["fdwaddr"].ToString();
                        objTemp.m_strfdwtele = drTemp["fdwtele"].ToString();
                        objTemp.m_strfdwpost = drTemp["fdwpost"].ToString();
                        objTemp.m_strfhkaddr = drTemp["fhkaddr"].ToString();
                        objTemp.m_strfhkpost = drTemp["fhkpost"].ToString();
                        objTemp.m_strflxname = drTemp["flxname"].ToString();
                        objTemp.m_strfrelate = drTemp["frelate"].ToString();
                        objTemp.m_strflxaddr = drTemp["flxaddr"].ToString();
                        objTemp.m_strflxtele = drTemp["flxtele"].ToString();
                        objTemp.m_strffbbh = drTemp["ffbbh"].ToString();
                        objTemp.m_strffb = drTemp["ffb"].ToString();
                        objTemp.m_strfascard1 = drTemp["fascard1"].ToString();
                        objTemp.m_strfascard2 = drTemp["fascard2"].ToString();
                        if (DateTime.TryParse(drTemp["frydate"].ToString(), out m_dTime))
                            objTemp.m_strfrydate = m_dTime;
                        objTemp.m_strfrytime = drTemp["frytime"].ToString();
                        objTemp.m_strfrytykh = drTemp["frytykh"].ToString();
                        objTemp.m_strfrydept = drTemp["frydept"].ToString();
                        objTemp.m_strfrybs = drTemp["frybs"].ToString();
                        if (DateTime.TryParse(drTemp["fcydate"].ToString(), out m_dTime))
                            objTemp.m_strfcydate = m_dTime;
                        objTemp.m_strfcytime = drTemp["fcytime"].ToString();
                        objTemp.m_strfcytykh = drTemp["fcytykh"].ToString();
                        objTemp.m_strfcydept = drTemp["fcydept"].ToString();
                        objTemp.m_strfcybs = drTemp["fcybs"].ToString();
                        TimeSpan ts = objTemp.m_strfcydate - objTemp.m_strfrydate;
                        objTemp.m_Intfdays = ts.Days;
                        objTemp.m_strfmzzdbh = drTemp["fmzzdbh"].ToString();
                        objTemp.m_strfmzzd0 = drTemp["fmzzd"].ToString();
                        objTemp.m_strfmzdoctbh = drTemp["fmzdoctbh"].ToString();
                        objTemp.m_strfmzdoct = drTemp["fmzdoct"].ToString();
                        objTemp.m_strfryinfobh = drTemp["fryinfobh"].ToString();
                        objTemp.m_strfryinfo = drTemp["fryinfo"].ToString();
                        objTemp.m_strfryzdbh = drTemp["fryzdbh"].ToString();
                        objTemp.m_strfryzd0 = drTemp["fryzd"].ToString();
                        if (DateTime.TryParse(drTemp["fqzdate"].ToString(), out m_dTime))
                            objTemp.m_strfqzdate = m_dTime;
                        objTemp.m_strfphzd0 = drTemp["fphzd"].ToString();
                        objTemp.m_strfgmyw0 = drTemp["fgmyw"].ToString();
                        objTemp.m_strfhbsagbh = drTemp["fhbsagbh"].ToString();
                        objTemp.m_strfhbsag = drTemp["fhbsag"].ToString();
                        objTemp.m_strfhcvabbh = drTemp["fhcvabbh"].ToString();
                        objTemp.m_strfhcvab = drTemp["fhcvab"].ToString();
                        objTemp.m_strfhivabbh = drTemp["fhivabbh"].ToString();
                        objTemp.m_strfhivab = drTemp["fhivab"].ToString();
                        objTemp.m_strfmzcyaccobh = drTemp["fmzcyaccobh"].ToString();
                        objTemp.m_strfmzcyacco = drTemp["fmzcyacco"].ToString();
                        objTemp.m_strfrycyaccobh = drTemp["frycyaccobh"].ToString();
                        objTemp.m_strfrycyacco = drTemp["frycyacco"].ToString();
                        objTemp.m_strflcblaccobh = drTemp["flcblaccobh"].ToString();
                        objTemp.m_strflcblacco = drTemp["flcblacco"].ToString();
                        objTemp.m_strffsblaccobh = drTemp["ffsblaccobh"].ToString();
                        objTemp.m_strffsblacco = drTemp["ffsblacco"].ToString();
                        objTemp.m_strfopaccobh = drTemp["fopaccobh"].ToString();
                        objTemp.m_strfopacco = drTemp["fopacco"].ToString();
                        if (Int32.TryParse(drTemp["fqjtimes"].ToString(), out m_intNum))
                            objTemp.m_Intfqjtimes = m_intNum;
                        if (Int32.TryParse(drTemp["fqjsuctimes"].ToString(), out m_intNum))
                            objTemp.m_Intfqjsuctimes = m_intNum;
                        objTemp.m_strfkzrbh = drTemp["fkzrbh"].ToString();
                        objTemp.m_strfkzr = drTemp["fkzr"].ToString();
                        objTemp.m_strfzrdoctbh = drTemp["fzrdoctbh"].ToString();
                        objTemp.m_strfzrdoctor = drTemp["fzrdoctor"].ToString();
                        objTemp.m_strfzzdoctbh = drTemp["fzzdoctbh"].ToString();
                        objTemp.m_strfzzdoct = drTemp["fzzdoct"].ToString();
                        objTemp.m_strfzydoctbh = drTemp["fzydoctbh"].ToString();
                        objTemp.m_strfzydoct = drTemp["fzydoct"].ToString();
                        objTemp.m_strfjxdoctbh = drTemp["fjxdoctbh"].ToString();
                        objTemp.m_strfjxdoct = drTemp["fjxdoct"].ToString();
                        objTemp.m_strfyjssxdoctbh = drTemp["fyjssxdoctbh"].ToString();
                        objTemp.m_strfyjssxdoct = drTemp["fyjssxdoct"].ToString();
                        objTemp.m_strfsxdoctbh = drTemp["fsxdoctbh"].ToString();
                        objTemp.m_strfsxdoct = drTemp["fsxdoct"].ToString();
                        objTemp.m_strfbmybh = drTemp["fbmybh"].ToString();
                        objTemp.m_strfbmy = drTemp["fbmy"].ToString();
                        objTemp.m_strfzlrbh = drTemp["fzlrbh"].ToString();
                        objTemp.m_strfzlr = drTemp["fzlr"].ToString();
                        objTemp.m_strfqualitybh = drTemp["fqualitybh"].ToString();
                        objTemp.m_strfquality = drTemp["fquality"].ToString();
                        objTemp.m_strfzkdoctbh = drTemp["fzkdoctbh"].ToString();
                        objTemp.m_strfzkdoct = drTemp["fzkdoct"].ToString();
                        objTemp.m_strfzknursebh = drTemp["fzknursebh"].ToString();
                        objTemp.m_strfzknurse = drTemp["fzknurse"].ToString();
                        if (DateTime.TryParse(drTemp["fzkrq"].ToString(), out m_dTime))
                            objTemp.m_strfzkrq = m_dTime;
                        objTemp.m_strfmzdeadbh = drTemp["fmzdeadbh"].ToString();
                        objTemp.m_strfmzdead = drTemp["fmzdead"].ToString();
                        if (Double.TryParse(drTemp["fsum1"].ToString(), out m_DblNum))
                            objTemp.m_Dblfsum1 = m_DblNum;
                        if (Double.TryParse(drTemp["fcwf"].ToString(), out m_DblNum))
                            objTemp.m_Dblfcwf = m_DblNum;
                        if (Double.TryParse(drTemp["fhlf"].ToString(), out m_DblNum))
                            objTemp.m_Dblfhlf = m_DblNum;
                        if (Double.TryParse(drTemp["fxyf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfxyf = m_DblNum;
                        if (Double.TryParse(drTemp["fzyf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzyf = m_DblNum;
                        if (Double.TryParse(drTemp["fzchyf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzchyf = m_DblNum;
                        if (Double.TryParse(drTemp["fzcyf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzcyf = m_DblNum;
                        if (Double.TryParse(drTemp["ffsf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblffsf = m_DblNum;
                        if (Double.TryParse(drTemp["fhyf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfhyf = m_DblNum;
                        if (Double.TryParse(drTemp["fsyf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfsyf = m_DblNum;
                        if (Double.TryParse(drTemp["fsxf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfsxf = m_DblNum;//13
                        if (Double.TryParse(drTemp["fzlf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzlf = m_DblNum;//14
                        if (Double.TryParse(drTemp["fssf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfssf = m_DblNum;
                        if (Double.TryParse(drTemp["fjsf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfjsf = m_DblNum;
                        if (Double.TryParse(drTemp["fjcf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfjcf = m_DblNum;
                        if (Double.TryParse(drTemp["fmzf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfmzf = m_DblNum;
                        if (Double.TryParse(drTemp["fyef"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfyef = m_DblNum;
                        if (Double.TryParse(drTemp["fpcf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfpcf = m_DblNum;
                        if (Double.TryParse(drTemp["fqtf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfqtf = m_DblNum;
                        objTemp.m_strfbodybh = drTemp["fbodybh"].ToString();
                        objTemp.m_strfbody = drTemp["fbody"].ToString();
                        objTemp.m_strfisopfirstbh = drTemp["fisopfirstbh"].ToString();
                        objTemp.m_strfisopfirst = drTemp["fisopfirst"].ToString();
                        objTemp.m_strfiszlfirstbh = drTemp["fiszlfirstbh"].ToString();
                        objTemp.m_strfiszlfirst = drTemp["fiszlfirst"].ToString();
                        objTemp.m_strfisjcfirstbh = drTemp["fisjcfirstbh"].ToString();
                        objTemp.m_strfisjcfirst = drTemp["fisjcfirst"].ToString();
                        objTemp.m_strfiszdfirstbh = drTemp["fiszdfirstbh"].ToString();
                        objTemp.m_strfiszdfirst = drTemp["fiszdfirst"].ToString();
                        objTemp.m_strfisszbh = drTemp["fisszbh"].ToString();
                        objTemp.m_strfissz = drTemp["fissz"].ToString();
                        objTemp.m_strfszqx = drTemp["fszqx"].ToString();
                        objTemp.m_strfsamplebh = drTemp["fsamplebh"].ToString();
                        objTemp.m_strfsample = drTemp["fsample"].ToString();
                        objTemp.m_strfbloodbh = drTemp["fbloodbh"].ToString();
                        objTemp.m_strfblood = drTemp["fblood"].ToString();
                        objTemp.m_strfrhbh = drTemp["frhbh"].ToString();
                        objTemp.m_strfrh = drTemp["frh"].ToString();
                        objTemp.m_strfsxfybh = drTemp["fsxfybh"].ToString();
                        objTemp.m_strfsxfy = drTemp["fsxfy"].ToString();
                        objTemp.m_strfsyfybh = drTemp["fsyfybh"].ToString();
                        objTemp.m_strfsyfy = drTemp["fsyfy"].ToString();
                        if (Double.TryParse(drTemp["fredcell"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfredcell = m_DblNum;
                        if (Double.TryParse(drTemp["fplaque"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfplaque = m_DblNum;
                        if (Double.TryParse(drTemp["fserous"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfserous = m_DblNum;
                        if (Double.TryParse(drTemp["fallblood"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfallblood = m_DblNum;
                        if (Double.TryParse(drTemp["fotherblood"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfotherblood = m_DblNum;
                        if (Int32.TryParse(drTemp["fhzyj"].ToString(), out	m_intNum))
                            objTemp.m_Intfhzyj = m_intNum;
                        if (Int32.TryParse(drTemp["fhzyc"].ToString(), out	m_intNum))
                            objTemp.m_Intfhzyc = m_intNum;
                        if (Int32.TryParse(drTemp["fhltj"].ToString(), out	m_intNum))
                            objTemp.m_Intfhltj = m_intNum;
                        if (Int32.TryParse(drTemp["fhl1"].ToString(), out	m_intNum))
                            objTemp.m_Intfhl1 = m_intNum;
                        if (Int32.TryParse(drTemp["fhl2"].ToString(), out	m_intNum))
                            objTemp.m_Intfhl2 = m_intNum;
                        if (Int32.TryParse(drTemp["fhl3"].ToString(), out	m_intNum))
                            objTemp.m_Intfhl3 = m_intNum;
                        if (Int32.TryParse(drTemp["fhlzz"].ToString(), out	m_intNum))
                            objTemp.m_Intfhlzz = m_intNum;
                        if (Int32.TryParse(drTemp["fhlts"].ToString(), out	m_intNum))
                            objTemp.m_Intfhlts = m_intNum;
                        if (Int32.TryParse(drTemp["fbabynum"].ToString(), out	m_intNum))
                            objTemp.m_Intfbabynum = m_intNum;
                        objTemp.m_strftwill = drTemp["ftwill"].ToString();
                        objTemp.m_strfqjbr = drTemp["fqjbr"].ToString();
                        objTemp.m_strfqjsuc = drTemp["fqjsuc"].ToString();

                        if (DateTime.TryParse(drTemp["fthreqz"].ToString(), out m_dTime))
                            objTemp.m_strfthreqz = m_dTime < objTemp.m_strfrydate.AddDays(3) ? "1" : "0";

                        objTemp.m_strfback = drTemp["fback"].ToString();
                        objTemp.m_strfifzdss = drTemp["fifzdss"].ToString();
                        objTemp.m_strfifdbz = drTemp["fifdbz"].ToString();
                        if (Double.TryParse(drTemp["fzlfzy"].ToString(), out m_DblNum))
                            objTemp.m_Dblfzlfzy = m_DblNum;
                        objTemp.m_strfzktykh = drTemp["fzktykh"].ToString();
                        objTemp.m_strfzkdept = drTemp["fzkdept"].ToString();
                        if (DateTime.TryParse(drTemp["fzkdate"].ToString(), out m_dTime))
                            objTemp.m_strfzkdate = m_dTime;
                        objTemp.m_strfzktime = drTemp["fzktime"].ToString();
                        objTemp.m_strfsrybh = drTemp["fsrybh"].ToString();
                        objTemp.m_strfsry = drTemp["fsry"].ToString();
                        if (DateTime.TryParse(drTemp["fworkrq"].ToString(), out m_dTime))
                            objTemp.m_strDateTime = m_dTime;
                        objTemp.m_strfjbfxbh = drTemp["fjbfxbh"].ToString();
                        objTemp.m_strfjbfx = drTemp["fjbfx"].ToString();
                        objTemp.m_strffhgdbh = drTemp["ffhgdbh"].ToString();
                        objTemp.m_strffhgd = drTemp["ffhgd"].ToString();
                        objTemp.m_strfsourcebh = drTemp["fsourcebh"].ToString();
                        objTemp.m_strfsource = drTemp["fsource"].ToString();
                        objTemp.m_strfifss = drTemp["fifss"].ToString();
                        objTemp.m_strfiffyk = drTemp["fiffyk"].ToString();
                        objTemp.m_strfbfz = drTemp["fbfz"].ToString();
                        if (Int32.TryParse(drTemp["fyngr"].ToString(), out	m_intNum))
                            objTemp.m_Intfyngr = m_intNum;
                        objTemp.m_strfflag = drTemp["fflag"].ToString();
                        objTemp.m_strfdatacheck = drTemp["fdatacheck"].ToString();
                        objTemp.m_strfextend1 = drTemp["fextend1"].ToString();
                        objTemp.m_strfextend2 = drTemp["fextend2"].ToString();
                        objTemp.m_strfextend3 = drTemp["fextend3"].ToString();
                        objTemp.m_strfextend4 = drTemp["fextend4"].ToString();
                        objTemp.m_strfextend5 = drTemp["fextend5"].ToString();
                        objTemp.m_strfextend6 = drTemp["fextend6"].ToString();
                        objTemp.m_strfextend7 = drTemp["fextend7"].ToString();
                        objTemp.m_strfextend8 = drTemp["fextend8"].ToString();
                        objTemp.m_strfextend9 = drTemp["fextend9"].ToString();
                        objTemp.m_strfextend10 = drTemp["fextend10"].ToString();
                        objTemp.m_strfextend11 = drTemp["fextend11"].ToString();
                        objTemp.m_strfextend12 = drTemp["fextend12"].ToString();
                        objTemp.m_strfextend13 = drTemp["fextend13"].ToString();
                        objTemp.m_strfextend14 = drTemp["fextend14"].ToString();
                        objTemp.m_strfextend15 = drTemp["fextend15"].ToString();
                        objTemp.m_strfnative = drTemp["fnative"].ToString();
                        objTemp.m_strfcurraddr = drTemp["fcurraddr"].ToString();
                        objTemp.m_strfcurrtele = drTemp["fcurrtele"].ToString();
                        objTemp.m_strfcurrpost = drTemp["fcurrpost"].ToString();
                        objTemp.m_strfjobbh = drTemp["fjobbh"].ToString();
                        objTemp.m_strfcstz = drTemp["fcstz"].ToString();
                        objTemp.m_strfrytz = drTemp["frytz"].ToString();
                        objTemp.m_strfryresourcebh = drTemp["fryresourcebh"].ToString();
                        objTemp.m_strfryresource = drTemp["fryresource"].ToString();
                        objTemp.m_strfycljbh = drTemp["fycljbh"].ToString();
                        objTemp.m_strfyclj = drTemp["fyclj"].ToString();
                        objTemp.m_strfphzdbh = drTemp["fphzdbh"].ToString();
                        objTemp.m_strfphzdnum = drTemp["fphzdnum"].ToString();
                        objTemp.m_strfifgmywbh = drTemp["fifgmywbh"].ToString();
                        objTemp.m_strfifgmyw = drTemp["fifgmyw"].ToString();
                        objTemp.m_strfnursebh = drTemp["fnursebh"].ToString();
                        objTemp.m_strfnurse = drTemp["fnurse"].ToString();
                        objTemp.m_strflyfsbh = drTemp["flyfsbh"].ToString();
                        objTemp.m_strflyfs0 = drTemp["flyfs"].ToString();
                        objTemp.m_strfyzouthostital0 = drTemp["fyzouthostital"].ToString();
                        objTemp.m_strfsqouthostital0 = drTemp["fsqouthostital"].ToString();
                        objTemp.m_strfisagainrybh = drTemp["fisagainrybh"].ToString();
                        objTemp.m_strfisagainry = drTemp["fisagainry"].ToString();
                        objTemp.m_strfisagainrymd0 = drTemp["fisagainrymd"].ToString();
                        if (Int32.TryParse(drTemp["fryqhmdays"].ToString(), out	m_intNum))
                            objTemp.m_Intfryqhmdays = m_intNum;
                        if (Int32.TryParse(drTemp["fryqhmhours"].ToString(), out	m_intNum))
                            objTemp.m_Intfryqhmhours = m_intNum;
                        if (Int32.TryParse(drTemp["fryqhmmins"].ToString(), out	m_intNum))
                            objTemp.m_Intfryqhmmins = m_intNum;
                        if (Int32.TryParse(drTemp["fryqhmcounts"].ToString(), out	m_intNum))
                            objTemp.m_Intfryqhmcounts = m_intNum;
                        if (Int32.TryParse(drTemp["fryhmdays"].ToString(), out	m_intNum))
                            objTemp.m_Intfryhmdays = m_intNum;
                        if (Int32.TryParse(drTemp["fryhmhours"].ToString(), out	m_intNum))
                            objTemp.m_Intfryhmhours = m_intNum;
                        if (Int32.TryParse(drTemp["fryhmmins"].ToString(), out	m_intNum))
                            objTemp.m_Intfryhmmins = m_intNum;
                        if (Int32.TryParse(drTemp["fryhmcounts"].ToString(), out	m_intNum))
                            objTemp.m_Intfryhmcounts = m_intNum;
                        objTemp.m_strffbbhnew = drTemp["ffbbhnew"].ToString();
                        objTemp.m_strffbnew = drTemp["ffbnew"].ToString();
                        if (Double.TryParse(drTemp["fzfje"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzfje = m_DblNum;
                        if (Double.TryParse(drTemp["fzhfwlylf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzhfwlylf = m_DblNum;
                        if (Double.TryParse(drTemp["fzhfwlczf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzhfwlczf = m_DblNum;
                        if (Double.TryParse(drTemp["fzhfwlhlf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzhfwlhlf = m_DblNum;
                        if (Double.TryParse(drTemp["fzhfwlqtf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzhfwlqtf = m_DblNum;
                        if (Double.TryParse(drTemp["fzdlblf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzdlblf = m_DblNum;
                        if (Double.TryParse(drTemp["fzdlsssf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzdlsssf = m_DblNum;
                        if (Double.TryParse(drTemp["fzdlyxf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzdlyxf = m_DblNum;
                        if (Double.TryParse(drTemp["fzdllcf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzdllcf = m_DblNum;
                        if (Double.TryParse(drTemp["fzllffssf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzllffssf = m_DblNum;
                        if (Double.TryParse(drTemp["fzllfwlzwlf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzllfwlzwlf = m_DblNum;
                        if (Double.TryParse(drTemp["fzllfssf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzllfssf = m_DblNum;
                        if (Double.TryParse(drTemp["fzllfmzf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzllfmzf = m_DblNum;
                        if (Double.TryParse(drTemp["fzllfsszlf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzllfsszlf = m_DblNum;
                        if (Double.TryParse(drTemp["fkflkff"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfkflkff = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzf = m_DblNum;
                        if (Double.TryParse(drTemp["fxylgjf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfxylgjf = m_DblNum;
                        if (Double.TryParse(drTemp["fxylxf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfxylxf = m_DblNum;
                        if (Double.TryParse(drTemp["fxylbqbf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfxylbqbf = m_DblNum;
                        if (Double.TryParse(drTemp["fxylqdbf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfxylqdbf = m_DblNum;
                        if (Double.TryParse(drTemp["fxylyxyzf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfxylyxyzf = m_DblNum;
                        if (Double.TryParse(drTemp["fxylxbyzf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfxylxbyzf = m_DblNum;
                        if (Double.TryParse(drTemp["fhclcjf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfhclcjf = m_DblNum;
                        if (Double.TryParse(drTemp["fhclzlf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfhclzlf = m_DblNum;
                        if (Double.TryParse(drTemp["fhclssf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfhclssf = m_DblNum;
                        if (Double.TryParse(drTemp["fzhfwlylf01"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzhfwlylf01 = m_DblNum;
                        if (Double.TryParse(drTemp["fzhfwlylf02"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzhfwlylf02 = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzdf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzdf = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzlf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzlf = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzlf01"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzlf01 = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzlf02"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzlf02 = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzlf03"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzlf03 = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzlf04"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzlf04 = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzlf05"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzlf05 = m_DblNum;
                        if (Double.TryParse(drTemp["fzylzlf06"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylzlf06 = m_DblNum;
                        if (Double.TryParse(drTemp["fzylqtf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylqtf = m_DblNum;
                        if (Double.TryParse(drTemp["fzylqtf01"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylqtf01 = m_DblNum;
                        if (Double.TryParse(drTemp["fzylqtf02"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzylqtf02 = m_DblNum;
                        if (Double.TryParse(drTemp["fzcljgzjf"].ToString(), out	m_DblNum))
                            objTemp.m_Dblfzcljgzjf = m_DblNum;
                        #endregion
                        p_lstFirstPage.Add(objTemp);
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {

            }

            return lngRes;
        }


        /// <summary>
        /// 关联产妇住院号获取婴儿流水号
        /// </summary>
        /// <param name="m_dtmUpdateDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable m_lngGetRgisterIDByInpatientID(string p_strRegisterid)
        {
            DataTable dtbResult = null;
            long lngRes = 0;
            string bbRegisterID = string.Empty;
            string strSQL = @"select registerid_chr
  from t_opr_bih_register
 where relateregisterid_chr = ?
";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strRegisterid;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            //返回
            return dtbResult;

        }

        /// <summary>
        /// 获取同步表费用信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">病人入院登记流水号</param>
        /// <param name="p_objRecordArr">记录列表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCHRCATE(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsInHospitalMainCharge[] p_objRecordArr)
        {
            p_objRecordArr = null;
            if (string.IsNullOrEmpty(p_strRegisterID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select sum(k.tolfee_mny) tolfee_mny, k.groupname_chr
  from (select b.totalmoney_dec   tolfee_mny,
               c.itembihctype_chr,
               d.typename_vchr    groupname_chr
          from t_opr_bih_patientcharge b,
               t_bse_chargeitem        c,
               t_bse_chargeitemextype  d
         where b.chargeitemid_chr = c.itemid_chr
           and b.status_int = 1
           --and b.pstatus_int in (1, 2)
           and c.itembihctype_chr = d.typeid_chr
           and d.flag_int = 5
           and b.registerid_chr = ?) k
 group by k.groupname_chr
";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strRegisterID;

                DataTable dtbResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

                if (lngRes > 0 && dtbResult != null)
                {
                    int intRowsCount = dtbResult.Rows.Count;
                    if (intRowsCount <= 0)
                    {
                        return 1;
                    }

                    DataRow drCurrent = null;
                    p_objRecordArr = new clsInHospitalMainCharge[intRowsCount];
                    double dblTemp = 0D;
                    for (int i = 0; i < intRowsCount; i++)
                    {
                        p_objRecordArr[i] = new clsInHospitalMainCharge();
                        drCurrent = dtbResult.Rows[i];
                        p_objRecordArr[i].m_strRegisterID = p_strRegisterID;
                        if (double.TryParse(drCurrent["tolfee_mny"].ToString(), out dblTemp))
                        {
                            p_objRecordArr[i].m_dblMoney = dblTemp;
                        }
                        else
                        {
                            p_objRecordArr[i].m_dblMoney = 0.00D;
                        }
                        p_objRecordArr[i].m_strTypeName = drCurrent["groupname_chr"].ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            //返回
            return lngRes;
        }

        /// <summary>
        /// 产科获取同步表费用信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">病人入院登记流水号</param>
        /// <param name="p_objRecordArr">记录列表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeChanKe(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, DataTable p_strbbReisterID, out clsInHospitalMainCharge[] p_objRecordArr)
        {
            p_objRecordArr = null;
            if (string.IsNullOrEmpty(p_strRegisterID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string parm = "?,";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                int length = p_strbbReisterID.Rows.Count + 1;
                objHRPServ.CreateDatabaseParameter(length, out objDPArr);
                objDPArr[0].Value = p_strRegisterID;
                if (p_strbbReisterID.Rows.Count > 0)
                {
                    for (int i1 = 0; i1 < p_strbbReisterID.Rows.Count; i1++)
                    {
                        parm = parm + "?,";
                        objDPArr[i1 + 1].Value = p_strbbReisterID.Rows[0][0].ToString();
                    }
                }
                parm = parm.Substring(0, parm.Length - 1);
                string strSQL = @"select sum(k.tolfee_mny) tolfee_mny, k.groupname_chr
  from (select b.totalmoney_dec   tolfee_mny,
               c.itembihctype_chr,
               d.typename_vchr    groupname_chr
          from t_opr_bih_patientcharge b,
               t_bse_chargeitem        c,
               t_bse_chargeitemextype  d
         where b.chargeitemid_chr = c.itemid_chr
           and b.status_int = 1
           --and b.pstatus_int in (1, 2)
           and c.itembihctype_chr = d.typeid_chr
           and d.flag_int = 5
           and b.registerid_chr in(" + parm + @"))k
 group by k.groupname_chr
";

                DataTable dtbResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

                if (lngRes > 0 && dtbResult != null)
                {
                    int intRowsCount = dtbResult.Rows.Count;
                    if (intRowsCount <= 0)
                    {
                        return 1;
                    }

                    DataRow drCurrent = null;
                    p_objRecordArr = new clsInHospitalMainCharge[intRowsCount];
                    double dblTemp = 0D;
                    for (int i = 0; i < intRowsCount; i++)
                    {
                        p_objRecordArr[i] = new clsInHospitalMainCharge();
                        drCurrent = dtbResult.Rows[i];
                        p_objRecordArr[i].m_strRegisterID = p_strRegisterID;
                        if (double.TryParse(drCurrent["tolfee_mny"].ToString(), out dblTemp))
                        {
                            p_objRecordArr[i].m_dblMoney = dblTemp;
                        }
                        else
                        {
                            p_objRecordArr[i].m_dblMoney = 0.00D;
                        }
                        p_objRecordArr[i].m_strTypeName = drCurrent["groupname_chr"].ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            //返回
            return lngRes;
        }

        /// <summary>
        /// 获取住院结算表里面病人自付金额部分
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_objRecordArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSelfPay(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientID, out string p_DblSelf)
        {
            p_DblSelf = "";
            if (string.IsNullOrEmpty(p_strInpatientID))
            {
                return -1;
            }
            long lngRes = 0;
            try
            {
                string strSQL = @"select sum(t.sbsum_mny) sbsum_mny
  from t_opr_bih_charge t, t_Opr_Bih_Register t2
 where t.registerid_chr = t2.registerid_chr  and t2.registerid_chr = ?";
                // and t2.inpatientid_chr = ?
                // and t2.inpatient_dat = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strInpatientID;
                //objDPArr[1].DbType = DbType.DateTime;
                //objDPArr[1].Value = p_dtmInhospitalDate;
                DataTable dtbValue = new DataTable();
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;

                if (lngRes > 0 && dtbValue.Rows.Count > 0)
                {
                    p_DblSelf = dtbValue.Rows[0]["sbsum_mny"].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            //返回
            return lngRes;
        }


        /// <summary>
        /// 手术查询
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOperationInfo(string p_strStartDate, string p_strEndDate, out List<clsOperationVO> p_lstFirstPage)
        {
            p_lstFirstPage = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strStartDate) || string.IsNullOrEmpty(p_strEndDate))
                return lngRes;

            clsHRPTableService objHRPServ = null;
            try
            {
                #region sql
                string strSQL = @"select 
'' jgdm,
t.registerid_chr fzyid,
f_getdeptnamebyid(t1.deptid_chr) opksname,
t1.deptid_chr optykh,
t.registerid_chr fid,
t1.inpatientid_chr fprn,
t1.inpatientcount_int ftimes,
t2.lastname_vchr fname,
(t3.seqid + 1) foptimes,
t3.operationid fopcode,
t3.operationname fop,
t3.operationdate fopdate,
'' fqiekoubh,
t3.cutlevel fqiekou,
'' fyuhebh,
'' fyuhe,
t3.operator fdocbh,
f_getempnamebyid(t3.operator) fdocname,
t3.aanaesthesiamodeid fmazuibh,
t3.operationaanaesthesiamodename fmazui,
'' fiffsop,
t3.assistant1 fopdoct1bh,
f_getempnamebyid(t3.assistant1) fopdoct1,
t3.assistant2 fopdoct2bh,
f_getempnamebyid(t3.assistant2) fopdoct2,
t3.anaesthetist fmzdoctbh,
f_getempnamebyid(t3.anaesthetist) fmzdoct,
t3.seqid fpx,
decode(t3.operationelective,'是','1','否','2','2') fzqssbh,
t3.operationelective fzqss,
decode(t3.operationelective,'一级手术','1','二级手术','2','三级手术','3','四级手术','4','0') fssjbbh,
t3.operationlevel fssjb
from t_opr_bih_leave t,t_opr_bih_register t1, t_opr_bih_registerdetail t2,inhospitalmainrecord t4,inhospitalmainrecord_operation t3
where (t.registerid_chr = t1.registerid_chr(+) and t.status_int = '1' and t1.status_int = '1')
and t1.registerid_chr = t2.registerid_chr(+)
and (t1.inpatientid_chr = t4.inpatientid and t1.modify_dat = t4.inpatientdate and t4.status = '1')
and (t4.inpatientid = t3.inpatientid and t4.opendate = t3.opendate and t3.status = '1')
and t.outhospital_dat between ? and ?";

                #endregion
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
                    clsOperationVO objTemp = null;
                    p_lstFirstPage = new List<clsOperationVO>();
                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        drTemp = dtResult.Rows[iRow];
                        objTemp = new clsOperationVO();
                        DateTime m_dTime;
                        int m_intNum = 0;
                        double m_DblNum = 0;
                        objTemp.m_strjgdm = "457226325"; //医院代码 茶山医院457226325  CP  457228806);
                        #region 赋值
                        objTemp.m_strfzyid = drTemp["fzyid"].ToString();
                        objTemp.m_stropksname = drTemp["opksname"].ToString();
                        objTemp.m_stroptykh = drTemp["optykh"].ToString();
                        objTemp.m_strfid = drTemp["fid"].ToString();
                        objTemp.m_strfprn = drTemp["fprn"].ToString();
                        if (Int32.TryParse(drTemp["ftimes"].ToString(), out	m_intNum))
                            objTemp.m_Intftimes = m_intNum;
                        objTemp.m_strfname = drTemp["fname"].ToString();
                        if (Int32.TryParse(drTemp["foptimes"].ToString(), out	m_intNum))
                            objTemp.m_Intfoptimes = m_intNum;
                        objTemp.m_strfopcode = drTemp["fopcode"].ToString();
                        objTemp.m_strfop = drTemp["fop"].ToString();
                        if (DateTime.TryParse(drTemp["fopdate"].ToString(), out	m_dTime))
                            objTemp.m_strfopdate = m_dTime;
                        objTemp.m_strfqiekoubh = drTemp["fqiekoubh"].ToString();
                        objTemp.m_strfqiekou = drTemp["fqiekou"].ToString();
                        objTemp.m_strfyuhebh = drTemp["fyuhebh"].ToString();
                        objTemp.m_strfyuhe = drTemp["fyuhe"].ToString();
                        objTemp.m_strfdocbh = drTemp["fdocbh"].ToString();
                        objTemp.m_strfdocname = drTemp["fdocname"].ToString();
                        objTemp.m_strfmazuibh = drTemp["fmazuibh"].ToString();
                        objTemp.m_strfmazui = drTemp["fmazui"].ToString();
                        objTemp.m_strfiffsop = drTemp["fiffsop"].ToString();
                        objTemp.m_strfopdoct1bh = drTemp["fopdoct1bh"].ToString();
                        objTemp.m_strfopdoct1 = drTemp["fopdoct1"].ToString();
                        objTemp.m_strfopdoct2bh = drTemp["fopdoct2bh"].ToString();
                        objTemp.m_strfopdoct2 = drTemp["fopdoct2"].ToString();
                        objTemp.m_strfmzdoctbh = drTemp["fmzdoctbh"].ToString();
                        objTemp.m_strfmzdoct = drTemp["fmzdoct"].ToString();
                        objTemp.m_strfpx = drTemp["fpx"].ToString();
                        objTemp.m_strfzqssbh = drTemp["fzqssbh"].ToString();
                        objTemp.m_strfzqss = drTemp["fzqss"].ToString();
                        objTemp.m_strfssjbbh = drTemp["fssjbbh"].ToString();
                        objTemp.m_strfssjb = drTemp["fssjb"].ToString();
                        #endregion
                        p_lstFirstPage.Add(objTemp);
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {

            }

            return lngRes;
        }

    }
    //End====qinhong====住院信息查询（常平）==================
}
