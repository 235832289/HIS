using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;
using iCare.iCareBaseForm;
using System.Collections;
using com.digitalwave.Utility.SQLConvert;
using iCare.RecordSearch;

namespace iCare
{
    public partial class frmCaseHistorySearch_Combin : frmBaseForm
    {
        #region 全局变量
        /// <summary>
        /// HashTable保存对应的查询语句
        /// </summary>
        private Hashtable m_hstMainSql = new Hashtable();
        private Hashtable m_hasPatientID = new Hashtable();
        private Hashtable m_hasPatientIDAndDate = new Hashtable();
        #endregion

        #region 构造方法
        /// <summary>
        /// 住院病案首页组合查询
        /// </summary>
        public frmCaseHistorySearch_Combin()
        {
            InitializeComponent();

            m_mthInitTreeContent();
            m_mthInitArray();
            m_mthAddComboItem();

            m_cboConn.SelectedIndex = 0;
        } 
        #endregion

        #region 初始化树结点
        /// <summary>
        /// 初始化树结点
        /// </summary>
        private void m_mthInitTreeContent()
        {
            clsKeyAndFormName objKeyAndFormName;
            TreeNode baseNode = new TreeNode("基本资料", 0, 0);
            objKeyAndFormName = new clsKeyAndFormName("S1", "", "");
            baseNode.Tag = objKeyAndFormName;
            TreeNode baseNodeChild;
            TreeNode childNodeChild;
            TreeNode ccNodeChild;

            #region 基本资料
            baseNodeChild = new TreeNode("住院号", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>住院号", "(b.INPATIENTID_CHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("入院次序", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>入院次序", "(b.INPATIENTCOUNT_INT<CONDITION>)", "INT");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("姓名", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>姓名", "(a.LASTNAME_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("年龄", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>年龄", "(" + clsDatabaseSQLConvert.s_strGetAgeSQL("a.BIRTH_DAT") + "<CONDITION>)", "INT");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("性别", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>性别", "(a.SEX_CHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("出生日期", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>出生日期", "(a.BIRTH_DAT<CONDITION>)", "DATE");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("婚姻状况", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("已婚", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "婚姻状况>>已婚", "((select count(a.MARRIED_CHR) from T_BSE_PATIENT where PATIENTID_CHR = a.PATIENTID_CHR and MARRIED_CHR='已婚')<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("未婚", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "婚姻状况>>未婚", "((select count(a.MARRIED_CHR) from T_BSE_PATIENT where PATIENTID_CHR = a.PATIENTID_CHR and MARRIED_CHR='未婚')<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("职业", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>职业", "(a.OCCUPATION_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("出生地", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>出生地", "(a.BIRTHPLACE_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("民族", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>民族", "(a.RACE_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("国籍", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>国籍", "(a.NATIONALITY_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("身份证号", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>身份证号", "(a.IDCARD_CHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("工作地址", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>工作地址", "(a.OFFICEADDRESS_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("工作单位", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>工作单位", "(a.EMPLOYER_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("工作电话", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>工作电话", "(a.OFFICEPHONE_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("工作邮编", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>工作邮编", "(a.OFFICEPC_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("户口地址", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>户口地址", "(a.HOMEADDRESS_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("联系人姓名", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>联系人姓名", "(a.CONTACTPERSONLASTNAME_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("联系人与患者关系", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>联系人与患者关系", "(a.PATIENTRELATION_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("联系人地址", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>联系人地址", "(a.CONTACTPERSONADDRESS_VCHR<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("入院科别", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>入院科别", "(e.deptname_vchr<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("入院日期", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>入院日期", "(b.INPATIENT_DAT<CONDITION>)", "DATE");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("出院科别", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>出院科别", "(d.deptname_vchr<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("出院日期", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>出院日期", "(d.MODIFY_DAT<CONDITION>)", "DATE");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("转科日期", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>转科日期", "(f.MODIFY_DAT<CONDITION>)", "DATE");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("转入科别", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>转入科别", "(f.deptname_vchr<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("住院天数", 0, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>住院天数", "(" + clsDatabaseSQLConvert.s_strGetDaysBetween2DateSQL("b.INPATIENT_DAT", "d.modify_dat") + "<CONDITION>)", "INT");
            baseNode.Nodes.Add(baseNodeChild);

            m_mthSetCanSearchNodeColor(baseNode);
            m_trvMain.Nodes.Add(baseNode); 
            #endregion

            #region 住院病案首页(广西)
            baseNode = new TreeNode("住院病案首页内容", 2, 2);
            objKeyAndFormName = new clsKeyAndFormName("S1", "frmInHospitalMainRecord_GXForCH", "");
            baseNode.Tag = objKeyAndFormName;

            baseNodeChild = new TreeNode("入院诊断", 2, 3);
            objKeyAndFormName = new clsKeyAndFormName("S12", "", "");
            baseNodeChild.Tag = objKeyAndFormName;
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("诊断内容", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("txtInHospitalDiagnosis", "住院病案首页>>入院诊断", "(IHMI.DIAGNOSISDESC<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("统计码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFINHOSPITALDIA", "住院病案首页>>入院诊断统计码", "(IHMI.STATCODE<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("ICD码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFINHOSPITALDIA", "住院病案首页>>入院诊断ICD码", "(IHMI.ICD10<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("入院情况", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("危", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入院情况>>危", "((select count(CONDICTIONWHENIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CONDICTIONWHENIN=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("急", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入院情况>>急", "((select count(CONDICTIONWHENIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CONDICTIONWHENIN=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("一般", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入院情况>>一般", "((select count(CONDICTIONWHENIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CONDICTIONWHENIN=3)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("入院确诊日期", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入院确诊日期", "(IHMC.CONFIRMDIAGNOSISDATE<CONDITION>)", "DATE");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("门诊诊断", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("诊断内容", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("txtDiagnosis", "住院病案首页>>门诊诊断", "(IHMC.DIAGNOSIS<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("统计码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFDIAGNOSIS", "住院病案首页>>门(急)诊诊断统计码", "(IHMC.STATCODEOFDIAGNOSIS<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("ICD码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFDIAGNOSIS", "住院病案首页>>门(急)诊诊断ICD码", "(IHMC.ICD_10OFDIAGNOSIS<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("出院主要诊断", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("诊断内容", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtMainDiagnosis", "住院病案首页>>出院主要诊断", "(IHMC.MAINDIAGNOSIS<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("疗效", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("治愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院主要诊断>>治愈", "((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("好转", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院主要诊断>>好转", "((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("未愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院主要诊断>>未愈", "((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("死亡", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院主要诊断>>死亡", "((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("其他", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院主要诊断>>其他", "(IHMC.OTHERMAINCONDITION<CONDITION>)", "STRING");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("正常分娩", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院主要诊断>>正常分娩", "((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=5)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("统计码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFMAIN", "住院病案首页>>出院主要诊断统计码", "(IHMC.STATCODEOFMAIN<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("ICD码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFMAIN", "住院病案首页>>出院主要诊断ICD码", "(IHMC.ICD_10OFMAIN<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("出院其他诊断", 2, 3);
            objKeyAndFormName = new clsKeyAndFormName("S10", "frmInHospitalMainRecord_GXForCH", "");
            baseNodeChild.Tag = objKeyAndFormName;
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("诊断内容", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断", "(IHMD.DIAGNOSISDESC<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("疗效", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("治愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断>>治愈", "((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("好转", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断>>好转", "((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("未愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断>>未愈", "((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("死亡", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断>>死亡", "((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("其他", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断>>其他", "(IHMD.OTHERCONDITION<CONDITION>)", "STRING");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("正常分娩", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断>>正常分娩", "((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=5)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("统计码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断统计码", "(IHMD.STATCODE<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("ICD码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院其他诊断ICD码", "(IHMD.ICD10<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("并发症(含手术麻醉)", 2, 3);
            objKeyAndFormName = new clsKeyAndFormName("S9", "frmInHospitalMainRecord_GXForCH", "");
            baseNodeChild.Tag = objKeyAndFormName;
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("并发症(含手术麻醉)", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtCOMPLICATION", "住院病案首页>>并发症(含手术麻醉)", "(IHMC.COMPLICATION<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("疗效", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("治愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>并发症(含手术麻醉)>>治愈", "((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("好转", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>并发症(含手术麻醉)>>好转", "((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("未愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>并发症(含手术麻醉)>>未愈", "((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("死亡", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>并发症(含手术麻醉)>>死亡", "((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("其他", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>并发症(含手术麻醉)>>其他", "(IHMC.OTHERCOMPLICATION<CONDITION>)", "STRING");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("正常分娩", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>并发症(含手术麻醉)>>正常分娩", "((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=5)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("统计码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFCOMPLICATION", "住院病案首页>>并发症(含手术麻醉)统计码", "(IHMC.STATCODEOFCOMPLICATION<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("ICD码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFCOMPLICATION", "住院病案首页>>并发症(含手术麻醉)ICD码", "(IHMC.ICD_10OFCOMPLICATION<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("院内感染名称", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("院内感染名称", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtINFECTIONDIAGNOSIS", "住院病案首页>>院内感染名称", "(IHMC.INFECTIONDIAGNOSIS<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("疗效", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("治愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>院内感染名称>>治愈", "((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("好转", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>院内感染名称>>好转", "((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("未愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>院内感染名称>>未愈", "((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("死亡", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>院内感染名称>>死亡", "((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("其他", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>院内感染名称>>其他", "(IHMC.OTHERINFECTIONCONDICTION<CONDITION>)", "STRING");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("正常分娩", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>院内感染名称>>正常分娩", "((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=5)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("统计码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFINFECTION", "住院病案首页>>院内感染名称统计码", "(IHMC.STATCODEOFINFECTION<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("ICD码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFINFECTION", "住院病案首页>>院内感染名称ICD码", "(IHMC.ICD_10OFINFECTION<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("病理诊断", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("诊断内容", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtPATHOLOGYDIAGNOSIS", "住院病案首页>>病理诊断", "(IHMC.PATHOLOGYDIAGNOSIS<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("疗效", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("治愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病理诊断>>治愈", "((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("好转", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病理诊断>>好转", "((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("未愈", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病理诊断>>未愈", "((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("死亡", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病理诊断>>死亡", "((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("其他", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病理诊断>>其他", "(IHMC.OTHERPATHOLOGYDIAGNOSIS<CONDITION>)", "STRING");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("正常分娩", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病理诊断>>正常分娩", "((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=5)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("统计码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFPATHOLOGYDIA", "住院病案首页>>病理诊断统计码", "(IHMC.STATCODEOFPATHOLOGYDIA<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("ICD码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFPATHOLOGYDIA", "住院病案首页>>病理诊断ICD码", "(IHMC.ICD_10OFPATHOLOGYDIA<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("损伤和中毒的外部原因", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("m_txtScacheSource", "住院病案首页>>损伤和中毒的外部原因", "(IHMC.SCACHESOURCE<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("新五病", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("是", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>新五病>>是", "((select count(NEW5DISEASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and NEW5DISEASE=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("否", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>新五病>>否", "((select count(NEW5DISEASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and NEW5DISEASE=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("二级转诊", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("有", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>二级转诊>>有", "((select count(SECONDLEVELTRANSFER) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and SECONDLEVELTRANSFER=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("无", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>二级转诊>>无", "((select count(SECONDLEVELTRANSFER) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and SECONDLEVELTRANSFER=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("过敏药物", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("HBsAg", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("未做", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HBsAg>>未做", "((select count(HBSAG) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HBSAG=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("阴性", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HBsAg>>阴性", "((select count(HBSAG) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HBSAG=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("阳性", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HBsAg>>阳性", "((select count(HBSAG) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HBSAG=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("HCV-Ab", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("未做", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HCV-Ab>>未做", "((select count(HCV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HCV_AB=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("阴性", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HCV-Ab>>阴性", "((select count(HCV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HCV_AB=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("阳性", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HCV-Ab>>阳性", "((select count(HCV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HCV_AB=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("HIV-Ab", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("未做", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HIV-Ab>>未做", "((select count(HIV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HIV_AB=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("阴性", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HIV-Ab>>阴性", "((select count(HIV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HIV_AB=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("阳性", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>HIV-Ab>>阳性", "((select count(HIV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HIV_AB=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            baseNodeChild = new TreeNode("手术情况", 2, 3);
            objKeyAndFormName = new clsKeyAndFormName("S11", "frmInHospitalMainRecord_GXForCH", "");
            baseNodeChild.Tag = objKeyAndFormName;
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("手术、操作日期", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>手术、操作日期", "(IHMO.OPERATIONDATE<CONDITION>)", "DATE");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("手术、操作编码", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>手术、操作编码", "(IHMO.OPERATIONID<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("手术、操作名称", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>手术、操作名称", "(IHMO.OPERATIONNAME<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("术者ID", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>术者", "(IHMO.OPERATOR<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("术者", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>术者", "(IHMO.OPERATOR in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("Ⅰ助ID", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>Ⅰ助", "(IHMO.ASSISTANT1<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("Ⅰ助", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>Ⅰ助", "(IHMO.ASSISTANT1 in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("Ⅱ助ID", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>Ⅱ助", "(IHMO.ASSISTANT2<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("Ⅱ助", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>Ⅱ助", "(IHMO.ASSISTANT2 in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("麻醉方式ID", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>麻醉方式", "(IHMO.AANAESTHESIAMODEID<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("麻醉方式", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>麻醉方式", "(IHMO.AANAESTHESIAMODEID in (select AANAESTHESIAMODEID from AnaesthesiaMode where AnaesthesiaModeName<CONDITION>))", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("切口愈合等级", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>切口愈合等级", "(IHMO.CUTLEVEL<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("麻醉医师ID", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>麻醉医师", "(IHMO.ANAESTHETIST<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("麻醉医师", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术情况>>麻醉医师", "(IHMO.ANAESTHETIST in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("新生儿疾病诊断", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>新生儿疾病诊断", "(IHMC.NEONATEDISEASE1<CONDITION> or IHMC.NEONATEDISEASE2<CONDITION> or IHMC.NEONATEDISEASE3<CONDITION> or IHMC.NEONATEDISEASE4<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("抢救次数", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("m_txtSALVETIMES", "住院病案首页>>抢救次数", "(IHMC.SALVETIMES<CONDITION>)", "INT");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("抢救成功次数", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("m_txtSALVESUCCESS", "住院病案首页>>抢救成功次数", "(IHMC.SALVESUCCESS<CONDITION>)", "INT");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("随诊", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("是", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>随诊>>是", "((select count(HASREMIND) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HASREMIND=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("否", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>随诊>>否", "((select count(HASREMIND) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HASREMIND=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("随诊期限", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("m_txtREMINDTERM", "住院病案首页>>随诊期限", "(IHMC.REMINDTERM<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("随诊期限单位", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("年", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>随诊期限单位>>年", "((select count(REMINDTERMTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and REMINDTERMTYPE=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("月", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>随诊期限单位>>月", "((select count(REMINDTERMTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and REMINDTERMTYPE=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("日", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>随诊期限单位>>日", "((select count(REMINDTERMTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and REMINDTERMTYPE=3)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("诊断符合情况", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("门诊-出院", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("无", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>门诊-出院>>无", "((select count(ACCORDWITHOUTHOSPITAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDWITHOUTHOSPITAL=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("符合", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>门诊-出院>>符合", "((select count(ACCORDWITHOUTHOSPITAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDWITHOUTHOSPITAL=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("不符", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>门诊-出院>>不符", "((select count(ACCORDWITHOUTHOSPITAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDWITHOUTHOSPITAL=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("待查", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>门诊-出院>>待查", "((select count(ACCORDWITHOUTHOSPITAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDWITHOUTHOSPITAL=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("入院-出院", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("无", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入院-出院>>无", "((select count(ACCORDINWITHOUT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDINWITHOUT=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("符合", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入院-出院>>符合", "((select count(ACCORDINWITHOUT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDINWITHOUT=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("不符", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入院-出院>>不符", "((select count(ACCORDINWITHOUT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDINWITHOUT=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("待查", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入院-出院>>待查", "((select count(ACCORDINWITHOUT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDINWITHOUT=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("术前-术后", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("无", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>术前-术后>>无", "((select count(ACCORDBFOPRWITHAF) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDBFOPRWITHAF=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("符合", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>术前-术后>>符合", "((select count(ACCORDBFOPRWITHAF) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDBFOPRWITHAF=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("不符", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>术前-术后>>不符", "((select count(ACCORDBFOPRWITHAF) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDBFOPRWITHAF=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("待查", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>术前-术后>>待查", "((select count(ACCORDBFOPRWITHAF) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDBFOPRWITHAF=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("临床-病理", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("无", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>临床-病理>>无", "((select count(ACCORDCLINICWITHPATHOLOGY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHPATHOLOGY=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("符合", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>临床-病理>>符合", "((select count(ACCORDCLINICWITHPATHOLOGY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHPATHOLOGY=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("不符", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>临床-病理>>不符", "((select count(ACCORDCLINICWITHPATHOLOGY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHPATHOLOGY=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("待查", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>临床-病理>>待查", "((select count(ACCORDCLINICWITHPATHOLOGY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHPATHOLOGY=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("死亡-尸检", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("无", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>死亡-尸检>>无", "((select count(ACCORDDEATHWITHBODYCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDDEATHWITHBODYCHECK=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("符合", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>死亡-尸检>>符合", "((select count(ACCORDDEATHWITHBODYCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDDEATHWITHBODYCHECK=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("不符", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>死亡-尸检>>不符", "((select count(ACCORDDEATHWITHBODYCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDDEATHWITHBODYCHECK=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("待查", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>死亡-尸检>>待查", "((select count(ACCORDDEATHWITHBODYCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDDEATHWITHBODYCHECK=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            childNodeChild = new TreeNode("临床-放射", 2, 3);
            baseNodeChild.Nodes.Add(childNodeChild);

            ccNodeChild = new TreeNode("无", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>临床-放射>>无", "((select count(ACCORDCLINICWITHRADIATE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHRADIATE=0)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("符合", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>临床-放射>>符合", "((select count(ACCORDCLINICWITHRADIATE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHRADIATE=1)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("不符", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>临床-放射>>不符", "((select count(ACCORDCLINICWITHRADIATE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHRADIATE=2)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            ccNodeChild = new TreeNode("待查", 2, 3);
            ccNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>临床-放射>>待查", "((select count(ACCORDCLINICWITHRADIATE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHRADIATE=3)<CONDITION>)", "BOOL");
            childNodeChild.Nodes.Add(ccNodeChild);

            baseNodeChild = new TreeNode("示教病例", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("是", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>示教病例>>是", "((select count(MODELCASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MODELCASE=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("否", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>示教病例>>否", "((select count(MODELCASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MODELCASE=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("手术、治疗、检查、诊断为本院第一例", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("是", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术、治疗、检查、诊断为本院第一例>>是", "((select count(FIRSTCASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and FIRSTCASE=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("否", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>手术、治疗、检查、诊断为本院第一例>>否", "((select count(FIRSTCASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and FIRSTCASE=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("病案质量", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("甲", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病案质量>>甲", "((select count(QUALITY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and QUALITY=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("乙", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病案质量>>乙", "((select count(QUALITY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and QUALITY=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("丙", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病案质量>>丙", "((select count(QUALITY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and QUALITY=3)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("抗菌药物使用", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("是", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>抗菌药物使用>>是", "((select count(ANTIBACTERIAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ANTIBACTERIAL=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("否", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>抗菌药物使用>>否", "((select count(ANTIBACTERIAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ANTIBACTERIAL=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("病原学送检", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("是", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病原学送检>>是", "((select count(PATHOGENY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOGENY=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("否", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病原学送检>>否", "((select count(PATHOGENY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOGENY=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("病原学送检结果", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("阳性", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病原学送检结果>>阳性", "((select count(PATHOGENYRESULT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOGENYRESULT=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("阴性", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>病原学送检结果>>阴性", "((select count(PATHOGENYRESULT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOGENYRESULT=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("输血反应", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("有", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>输血反应>>有", "((select count(BLOODTRANSACTOIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTRANSACTOIN=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("无", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>输血反应>>无", "((select count(BLOODTRANSACTOIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTRANSACTOIN=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("输液反应", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("有", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>输液反应>>有", "((select count(TRANSFUSIONSACTION) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and TRANSFUSIONSACTION=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("无", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>输液反应>>无", "((select count(TRANSFUSIONSACTION) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and TRANSFUSIONSACTION=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("CT检查", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("有", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>CT检查>>有", "((select count(CTCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CTCHECK=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("无", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>CT检查>>无", "((select count(CTCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CTCHECK=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("MRI检查", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("有", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>MRI检查>>有", "((select count(MRICHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MRICHECK=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("无", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>MRI检查>>无", "((select count(MRICHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MRICHECK=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("血型", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("不详", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>血型>>不详", "((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=0)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("A", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>血型>>A", "((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("B", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>血型>>B", "((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("AB", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>血型>>AB", "((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=3)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("O", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>血型>>O", "((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=4)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("Rh", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("不详", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>Rh>>不详", "((select count(BLOODRH) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODRH=0)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("阴", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>Rh>>阴", "((select count(BLOODRH) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODRH=1)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("阳", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>Rh>>阳", "((select count(BLOODRH) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODRH=2)<CONDITION>)", "BOOL");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("输血品种", 2, 3);
            baseNode.Nodes.Add(baseNodeChild);

            childNodeChild = new TreeNode("红细胞", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>红细胞", "(IHMC.RBC<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("血小板", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>血小板", "(IHMC.PLT<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("血浆", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>血浆", "(IHMC.PLASM<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("全血", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>全血", "(IHMC.WHOLEBLOOD<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            childNodeChild = new TreeNode("其它", 2, 3);
            childNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>其它", "(IHMC.OTHERBLOOD<CONDITION>)", "STRING");
            baseNodeChild.Nodes.Add(childNodeChild);

            baseNodeChild = new TreeNode("科主任ID", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>科主任", "(IHMC.DEPTDIRECTORDT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("科主任", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>科主任", "(IHMC.DEPTDIRECTORDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("主任医师ID", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>主任医师", "(IHMC.DIRECTORDT<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("主任医师", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>主任医师", "(IHMC.DIRECTORDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("副主任医师ID", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>主（副主）任医师", "(IHMC.SUBDIRECTORDT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("主（副主）任医师", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>主（副主）任医师", "(IHMC.SUBDIRECTORDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("主治医师ID", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>主治医师", "(IHMC.DT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("主治医师", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>主治医师", "(IHMC.DT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("入院医师ID", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>住院医师", "(IHMC.INHOSPITALDOC<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("入院医师", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>住院医师", "(IHMC.INHOSPITALDOC in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("出院医师ID", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院医师", "(IHMC.OUTHOSPITALDOC<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("出院医师", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>出院医师", "(IHMC.OUTHOSPITALDOC in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("进修医师ID", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>进修医师", "(IHMC.ATTENDINFORADVANCESSTUDYDT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("进修医师", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>进修医师", "(IHMC.ATTENDINFORADVANCESSTUDYDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("研究生实习医师", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>研究生实习医师", "(IHMC.GRADUATESTUDENTINTERN<CONDITION>))", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("实习医师", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>实习医师", "(IHMC.INTERN<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("住院费用总计", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtTotalAmt", "住院病案首页>>住院费用总计", "(IHMC.TOTALAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("床位费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtBedAmt", "住院病案首页>>床费", "(IHMC.BEDAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("护理费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtNurseAmt", "住院病案首页>>护理费", "(IHMC.NURSEAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("西药费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtWMAmt", "住院病案首页>>西药费", "(IHMC.WMAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("中成药费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtCMFinishedAmt", "住院病案首页>>中成药费", "(IHMC.CMFINISHEDAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("中草药费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtCMSemiFinishedAmt", "住院病案首页>>中草药费", "(IHMC.CMSEMIFINISHEDAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("放射费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtRadiationAmt", "住院病案首页>>放射费", "(IHMC.RADIATIONAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("化验费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtAssayAmt", "住院病案首页>>化验费", "(IHMC.ASSAYAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("输氧费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtO2Amt", "住院病案首页>>输氧费", "(IHMC.O2AMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("输血费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtBloodAmt", "住院病案首页>>输血费", "(IHMC.BLOODAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("诊疗费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtTreatmentAmt", "住院病案首页>>诊疗费", "(IHMC.TREATMENTAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("手术费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtOperationAmt", "住院病案首页>>手术费", "(IHMC.OPERATIONAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("检查费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtCheckAmt", "住院病案首页>>检查费", "(IHMC.CHECKAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("麻醉费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtAnaethesiaAmt", "住院病案首页>>麻醉费", "(IHMC.ANAETHESIAAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("接生费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtDeliveryChildAmt", "住院病案首页>>接生费", "(IHMC.DELIVERYCHILDAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("婴儿费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtBabyAmt", "住院病案首页>>婴儿费", "(IHMC.BABYAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("陪床费", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtAccompanyAmt", "住院病案首页>>陪床费", "(IHMC.ACCOMPANYAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("其他费用", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("txtOtherAmt", "住院病案首页>>其他费", "(IHMC.OTHERAMT<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("编码者", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>编码者", "(IHMC.CODINGNAME<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("整理者", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>整理者", "(IHMC.NEATENNAME<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("入机者", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>入机者", "(IHMC.INPUTMACHINENAME<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            baseNodeChild = new TreeNode("统计者", 2, 3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "住院病案首页>>统计者", "(IHMC.STATISTICNAME<CONDITION>)", "STRING");
            baseNode.Nodes.Add(baseNodeChild);

            m_mthSetCanSearchNodeColor(baseNode);
            //m_mthFoundAndSetTemplate2Node(baseNode, "frmInHospitalMainRecord_GXForCH");
            m_trvMain.Nodes.Add(baseNode);
            #endregion

            m_trvMain.Nodes[0].Expand();

            m_trvMain.SelectedNode = m_trvMain.Nodes[0].FirstNode;
        } 
        #endregion

        #region 设置树结点颜色
        /// <summary>
        /// 设置树结点颜色
        /// </summary>
        /// <param name="p_trnParent">结点</param>
        private void m_mthSetCanSearchNodeColor(TreeNode p_trnParent)
        {
            foreach (TreeNode node in p_trnParent.Nodes)
                node.ForeColor = Color.Blue;
        } 
        #endregion

        #region 添加条件类型项目
        /// <summary>
        /// 添加条件类型项目
        /// </summary>
        private void m_mthAddComboItem()
        {
            m_cboDateConditionType.AddRangeItems(m_objGetExpItemArr("DATE"));
            m_cboDateConditionType.SelectedIndex = 0;

            m_cboLongTextConditionType.AddRangeItems(m_objGetExpItemArr("STRING"));
            m_cboLongTextConditionType.SelectedIndex = 0;

            m_cboNumberConditionType.AddRangeItems(m_objGetExpItemArr("INT"));
            m_cboNumberConditionType.SelectedIndex = 0;
        } 
        #endregion

        #region 设置查询类型
        /// <summary>
        /// 设置查询类型
        /// </summary>
        /// <param name="p_strControlName">控件名</param>
        /// <param name="p_strControlDesc">控件描述</param>
        /// <param name="p_strFieldName">查询条件</param>
        /// <param name="p_strDataType">数据类型</param>
        /// <returns></returns>
        private clsDataSearchesType m_objGetDateSearchesType(string p_strControlName, string p_strControlDesc, string p_strFieldName, string p_strDataType)
        {
            clsDataSearchesType objSearchesType = new clsDataSearchesType();
            objSearchesType.m_strDataType = p_strDataType;
            objSearchesType.m_strFieldName = p_strFieldName;

            objSearchesType.m_strItemID = p_strControlName;
            objSearchesType.m_strItemDesc = p_strControlDesc;
            if (p_strControlName != "")
                objSearchesType.m_strItemType = "ctlRichTextBox";
            return objSearchesType;
        } 
        #endregion

        #region 实现bool类型查询的checkbox单选
        private void m_chkTrueFalseFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkTrueFalseFalse.Checked)
            {
                m_chkTrueFalseTrue.Checked = false;
            }
        }

        private void m_chkTrueFalseTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkTrueFalseTrue.Checked)
            {
                m_chkTrueFalseFalse.Checked = false;
            }
        } 
        #endregion

        #region 条件列表DoubleClick删除选中item
        private void m_lstConditionList_DoubleClick(object sender, EventArgs e)
        {
            if (m_lstConditionList.SelectedItems.Count > 0)
                m_lstConditionList.Items.Remove(m_lstConditionList.SelectedItems[0]);
        } 
        #endregion

        #region 清空条件列表
        private void m_cmdClearCondition_Click(object sender, EventArgs e)
        {
            m_lstConditionList.Items.Clear();
        } 
        #endregion

        #region 添加条件至条件列表
        private void m_cmdAddCondition_Click(object sender, EventArgs e)
        {
            if (m_trvMain.SelectedNode == null)
                return;
            clsDataSearchesType objSearchesType = m_trvMain.SelectedNode.Tag as clsDataSearchesType;
            if (objSearchesType == null)
            {
                return;
            }
            clsDateSearchesCondition objCondition = m_objSetInputCondition();
            if (objCondition == null)
                return;
            for (int i = 0; i < m_lstConditionList.Items.Count; i++)
            {
                //控制不能插入重复条件
                if (((clsDateSearchesCondition)m_lstConditionList.Items[i]).m_strSearchesSQL == objCondition.m_strSearchesSQL)
                    return;
            }

            m_lstConditionList.Items.Add(objCondition);
        } 
        #endregion

        #region 获得查询条件
        /// <summary>
        /// 获得查询条件
        /// </summary>
        private clsDateSearchesCondition m_objSetInputCondition()
        {
            clsDataSearchesType objSearchesType = m_trvMain.SelectedNode.Tag as clsDataSearchesType;
            clsKeyAndFormName objKeyAndFormName = m_objGetParnetTag(m_trvMain.SelectedNode.Parent);
            if (objSearchesType == null || objKeyAndFormName == null)
                return null;

            clsDateSearchesCondition objCondition = new clsDateSearchesCondition();

            string strConn = "并且:";
            string strConnType = " and ";
            if (m_cboConn.SelectedIndex == 1)
            {
                strConnType = " or ";
                strConn = "  或:";
            }

            if (m_pnlLongText.Visible)
            {
                if (m_txtLongTextContent.Text.TrimEnd() == "")
                {
                    MDIParent.ShowInformationMessageBox("条件不能都为空！请填写合适的条件。");
                    m_txtLongTextContent.Focus();
                    return null;
                }
                clsExpressionInfo obj = m_cboLongTextConditionType.SelectedItem as clsExpressionInfo;

                objCondition.m_strName = objSearchesType.m_strItemDesc;
                objCondition.m_objSelectedItem = (clsExpressionInfo)m_cboLongTextConditionType.SelectedItem;
                objCondition.m_strFirstValue = m_txtLongTextContent.Text.TrimEnd();
                objCondition.m_strSQLKey = objKeyAndFormName.m_strSQLKey;
                objCondition.m_strSearchesSQL = strConnType + objSearchesType.m_strFieldName.Replace("<CONDITION>", obj.m_strExpressionArr.Replace("<CONTENT>", m_txtLongTextContent.Text.TrimEnd()));
                objCondition.m_strConnTypeDesc = strConn;
            }
            else if (m_pnlDate.Visible)
            {
                clsExpressionInfo obj = m_cboDateConditionType.SelectedItem as clsExpressionInfo;

                objCondition.m_strName = objSearchesType.m_strItemDesc;
                objCondition.m_objSelectedItem = (clsExpressionInfo)m_cboDateConditionType.SelectedItem;
                objCondition.m_strFirstValue = "<FIRST>" + m_dtpFirst.Value.ToString("yyyy年MM月dd日 HH时");
                objCondition.m_strSecondValue = (m_dtpSecond.Visible ? "<SECOND>" + m_dtpSecond.Value.ToString("yyyy年MM月dd日 HH时") : "");
                objCondition.m_strSQLKey = objKeyAndFormName.m_strSQLKey;
                objCondition.m_strSearchesSQL = strConnType + objSearchesType.m_strFieldName.Replace("<CONDITION>", obj.m_strExpressionArr.Replace("<FIRSTDATE>", clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_dtpFirst.Value)).Replace("<ENDDATE>", clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_dtpSecond.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"))));
                objCondition.m_strConnTypeDesc = strConn;
            }
            else if (m_pnlTrueFalse.Visible)
            {
                if (m_chkTrueFalseTrue.Checked == false && m_chkTrueFalseFalse.Checked == false)
                {
                    MDIParent.ShowInformationMessageBox("条件不能都为空！请选择一个。");
                    return null;
                }

                objCondition.m_strName = objSearchesType.m_strItemDesc;
                objCondition.m_blnBoolValue = m_chkTrueFalseTrue.Checked;
                objCondition.m_strSQLKey = objKeyAndFormName.m_strSQLKey;
                objCondition.m_strSearchesSQL = strConnType + objSearchesType.m_strFieldName.Replace("<CONDITION>", (m_chkTrueFalseTrue.Checked ? " > 0 " : " <= 0 "));
                objCondition.m_strConnTypeDesc = strConn;
            }
            else if (m_pnlNumber.Visible)
            {
                if ((m_txtNumberFrom.Text.Trim() == "" && m_txtNumberTo.Visible && m_txtNumberTo.Text.Trim() == "") || (m_txtNumberFrom.Text.Trim() == "" && !m_txtNumberTo.Visible))
                {
                    MDIParent.ShowInformationMessageBox("条件不能都为空！请填写合适的条件。");
                    m_txtNumberFrom.Focus();
                    return null;
                }
                clsExpressionInfo obj = m_cboNumberConditionType.SelectedItem as clsExpressionInfo;

                objCondition.m_strName = objSearchesType.m_strItemDesc;
                objCondition.m_objSelectedItem = (clsExpressionInfo)m_cboNumberConditionType.SelectedItem;
                objCondition.m_strFirstValue = "<FIRST>" + m_txtNumberFrom.Text.Trim();
                objCondition.m_strSecondValue = (m_txtNumberTo.Visible ? "<SECOND>" + m_txtNumberTo.Text.Trim() : "");
                objCondition.m_strSQLKey = objKeyAndFormName.m_strSQLKey;
                objCondition.m_strSearchesSQL = strConnType + objSearchesType.m_strFieldName.Replace("<CONDITION>", obj.m_strExpressionArr.Replace("<FIRSTNUMBER>", m_txtNumberFrom.Text.Trim()).Replace("<ENDNUMBER>", m_txtNumberTo.Text.Trim()));
                objCondition.m_strConnTypeDesc = strConn;
            }
            return objCondition;
        } 
        #endregion

        #region 返回结点Tag是clsKeyAndFormName的类
        /// <summary>
        /// 返回结点Tag是clsKeyAndFormName的类
        /// </summary>
        /// <param name="p_trnParent">结点</param>
        /// <returns></returns>
        private clsKeyAndFormName m_objGetParnetTag(TreeNode p_trnParent)
        {
            if (p_trnParent != null)
            {
                if (p_trnParent.Tag is clsKeyAndFormName)
                    return (clsKeyAndFormName)p_trnParent.Tag;
                else
                    return m_objGetParnetTag(p_trnParent.Parent);
            }
            else
                return null;
        } 
        #endregion

        #region 查询记录
        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            m_lsvResultList.Items.Clear();
            m_mthQuery();
        } 
        #endregion

        #region 弹出搜索中的窗体，查询记录
        /// <summary>
        /// 弹出搜索中的窗体，查询记录
        /// </summary>
        private void m_mthQuery()
        {
            frmBusynessForm frm = new frmBusynessForm("正在搜索，请稍候...");
            frm.BusynessEvent += new iCare.frmBusynessForm.BusynessHandler(frm_BusynessEvent);
            frm.ShowDialog();
        } 

        private void frm_BusynessEvent(object sender, BusynessEventArgs e)
        {
            try
            {
                Hashtable hasKey = new Hashtable();
                string strMainSql = @"select distinct <S1>.PatientName,<S1>.inpatientid,<S1>.inpatientdate,<S1>.InDept,<S1>.OutDate,<S1>.PatientSex from ";
                if (m_lstConditionList.Items.Count <= 0)
                {
                    return;
                }
                else
                {
                    bool blnCanReturn = true;
                    //默认添加，否则没有姓名
                    hasKey.Add("S1", m_strGetMainSQL("S1"));
                    for (int j = 0; j < m_lstConditionList.Items.Count; j++)
                    {
                        blnCanReturn = false;
                        clsDateSearchesCondition objCondition = m_lstConditionList.Items[j] as clsDateSearchesCondition;
                        if (hasKey.ContainsKey(objCondition.m_strSQLKey))
                        {
                            //如果为同一主SQL，则只添加Where条件
                            string strTemp = (string)hasKey[objCondition.m_strSQLKey];
                            strTemp += objCondition.m_strSearchesSQL;
                            hasKey[objCondition.m_strSQLKey] = strTemp;
                        }
                        else
                        {
                            string strSql = m_strGetMainSQL(objCondition.m_strSQLKey) + objCondition.m_strSearchesSQL;
                            hasKey.Add(objCondition.m_strSQLKey, strSql);
                        }
                    }
                    if (blnCanReturn)
                    {
                        if (m_lsvResultList.Items.Count > 0)
                            m_lsvResultList.Items[0].Selected = true;
                        e.EndMessage = "搜索完成";
                        e.Closing = true;
                        m_mthAddResultToListView();
                        m_mthClear();
                        return;
                    }
                    if (hasKey.Count > 0)//连接全部条件成最终可执行SQL
                    {
                        string[] strKeysArr = new string[hasKey.Count];
                        hasKey.Keys.CopyTo(strKeysArr, 0);
                        for (int k = 0; k < hasKey.Count; k++)
                        {
                            strMainSql += (k == 0 ? "(" + hasKey[strKeysArr[k]] + ") " + strKeysArr[k] : " inner join (" + hasKey[strKeysArr[k]] + ") " + strKeysArr[k]);
                            if (k > 0)
                                strMainSql += " on " + strKeysArr[k - 1] + ".inpatientid = " + strKeysArr[k] + ".inpatientid and " + strKeysArr[k - 1] + ".inpatientdate = " + strKeysArr[k] + ".inpatientdate ";
                        }
                        strMainSql += " order by <S1>.inpatientid";
                        strMainSql = strMainSql.Replace("<S1>", strKeysArr[0]);
                    }
                }
                DataTable dtValue = new DataTable();
                clsRecordSearchDomain objDomain = new clsRecordSearchDomain();
                objDomain.m_lngSearchesBySQL(strMainSql, ref dtValue);
                e.Messages = "正在添加到列表...";
                //添加查找结果列表
                if (dtValue.Rows.Count > 0)
                {
                    if (m_hasPatientIDAndDate.Count > 0)
                    {
                        string[] strKeysArr2 = new string[m_hasPatientIDAndDate.Count];
                        m_hasPatientIDAndDate.Keys.CopyTo(strKeysArr2, 0);
                        foreach (string key in strKeysArr2)
                        {
                            bool blnIsFound = false;
                            foreach (DataRow row in dtValue.Rows)
                            {
                                if (key == row["INPATIENTID"].ToString().Trim() + DateTime.Parse(row["INPATIENTDATE"].ToString()).ToString("yyyy年MM月dd日"))
                                {
                                    blnIsFound = true;
                                    break;
                                }
                            }
                            if (!blnIsFound)
                            {
                                m_hasPatientIDAndDate.Remove(key);
                                string[] strKeysArr3 = new string[m_hasPatientID.Count];
                                m_hasPatientID.Keys.CopyTo(strKeysArr3, 0);
                                foreach (string key1 in strKeysArr2)
                                {
                                    blnIsFound = false;
                                    foreach (DataRow row in dtValue.Rows)
                                    {
                                        if (key1 == row["INPATIENTID"].ToString().Trim())
                                        {
                                            blnIsFound = true;
                                            break;
                                        }
                                    }
                                    if (!blnIsFound)
                                        m_hasPatientID.Remove(key1);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtValue.Rows.Count; i++)
                        {
                            string strPatientID = dtValue.Rows[i]["INPATIENTID"].ToString().Trim();
                            string strInPatientDate = DateTime.Parse(dtValue.Rows[i]["INPATIENTDATE"].ToString()).ToString("yyyy年MM月dd日");
                            if (m_hasPatientIDAndDate.ContainsKey(strPatientID + strInPatientDate))
                            {
                                continue;
                            }
                            m_hasPatientIDAndDate.Add(strPatientID + strInPatientDate, dtValue.Rows[i]);
                            if (!m_hasPatientID.ContainsKey(strPatientID))
                                m_hasPatientID.Add(strPatientID, "");
                        }
                    }
                }
                e.EndMessage = "搜索完成";
                e.Closing = true;
            }
            catch
            {
                e.EndMessage = "搜索失败";
                e.Closing = false;
            }
            finally
            {
                m_mthAddResultToListView();
                m_mthClear();
            }
        }
        #endregion

        #region 显示结果至ListView
        /// <summary>
        /// 显示结果至ListView
        /// </summary>
        private void m_mthAddResultToListView()
        {
            try
            {
                m_lsvResultList.Items.Clear();
                m_lsvResultList.BeginUpdate();
                if (m_hasPatientIDAndDate.Count > 0)
                {
                    string[] strKeysArr = new string[m_hasPatientIDAndDate.Count];
                    m_hasPatientIDAndDate.Keys.CopyTo(strKeysArr, 0);
                    foreach (string key in strKeysArr)
                    {
                        DataRow drList = m_hasPatientIDAndDate[key] as DataRow;
                        if (drList != null)
                        {
                            ListViewItem item = new ListViewItem(new string[] { drList["INPATIENTID"].ToString().Trim(), 
                            drList["PatientName"].ToString(), 
                            drList["PatientSex"].ToString(), 
                            DateTime.Parse(drList["inpatientdate"].ToString()).ToString("yyyy年MM月dd日"), 
                            DateTime.Parse(drList["OutDate"].ToString()).ToString("yyyy年MM月dd日") });
                            item.Tag = drList;
                            m_lsvResultList.Items.Add(item);
                        }
                    }
                }
            }
            finally
            {
                m_lsvResultList.EndUpdate();
                m_lblResultNums.Text = "共检索出" + m_lsvResultList.Items.Count.ToString() + "条记录";
            }
            if (m_lsvResultList.Items.Count > 0)
            {
                m_lsvResultList.Focus();
                m_lsvResultList.Items[0].Selected = true;
            }
        } 
        #endregion

        #region 清空HashTable
        /// <summary>
        /// 清空HashTable
        /// </summary>
        private void m_mthClear()
        {
            m_hasPatientID.Clear();
            m_hasPatientIDAndDate.Clear();
        } 
        #endregion

        #region 清空查询所得记录列表
        private void m_cmdClearResult_Click(object sender, EventArgs e)
        {
            m_lsvResultList.Items.Clear();
        } 
        #endregion

        #region 初始化主体的查询语句
        private void m_mthInitArray()
        {
            #region 查询病人基本资料
            string strSql = @"select distinct a.INPATIENTID_CHR inpatientid,
                                            b.INPATIENT_DAT   inpatientdate,
                                            e.deptname_vchr   InDept,
                                            a.LASTNAME_VCHR   PatientName,
                                            d.modify_dat      OutDate,
                                            d.deptname_vchr   OutDept,
                                            a.SEX_CHR         PatientSex
							from T_BSE_PATIENT a
							inner join T_OPR_BIH_REGISTER b on a.PATIENTID_CHR = b.PATIENTID_CHR
							inner join (select l.REGISTERID_CHR,
                                                l.MODIFY_DAT,
                                                l.status_int,
                                                td1.deptname_vchr
                                           from T_OPR_BIH_LEAVE l, T_BSE_DEPTDESC td1
                                          where l.outdeptid_chr = td1.DEPTID_CHR) d on d.status_int = 1
                                                                                  and d.REGISTERID_CHR =
                                                                                      b.REGISTERID_CHR
                             inner join (select tl.REGISTERID_CHR, td2.deptname_vchr
                                           from T_OPR_BIH_TRANSFER tl, T_BSE_DEPTDESC td2
                                          where tl.TARGETDEPTID_CHR = td2.DEPTID_CHR
                                            and tl.modify_dat =
                                                (select min(modify_dat)
                                                   from T_OPR_BIH_TRANSFER
                                                  where tl.registerid_chr = registerid_chr)) e on e.registerid_chr =
                                                                                                  b.registerid_chr
                            inner join T_EMR_INHOSPITALMAINREC_GXCON IHMC on IHMC.registerid_chr = b.registerid_chr
                                                                         and IHMC.CATALOG_DATE is NOT NULL
                          left outer join (select tl2.TARGETDEPTID_CHR,
                                                  tl2.MODIFY_DAT,
                                                  td3.deptname_vchr,
                                                  tl2.registerid_chr
                                             from T_OPR_BIH_TRANSFER tl2, T_BSE_DEPTDESC td3
                                            where tl2.sourcedeptid_chr is not null
                                              and tl2.targetdeptid_chr is not null
                                              and tl2.targetdeptid_chr = td3.deptid_chr) f on f.registerid_chr =
                                                                                              b.registerid_chr
                             where 1 = 1";
            m_hstMainSql.Add("S1", strSql); 
            #endregion

            #region 病案首页其他诊断
            strSql = @"select distinct IHMD.inpatientid, IHMD.inpatientdate
						from T_EMR_INHOSPITALMAINREC_GXOD IHMD,T_EMR_INHOSPITALMAINREC_GXCON IHMC
						where IHMD.EMR_SEQ = IHMC.EMR_SEQ 
                        and IHMC.CATALOG_DATE is NOT NULL";
            m_hstMainSql.Add("S10", strSql); 
            #endregion

            #region 病案首页手术信息
            strSql = @"select distinct IHMO.inpatientid, IHMO.inpatientdate
						from T_EMR_INHOSPITALMAINREC_GXOP IHMO ,T_EMR_INHOSPITALMAINREC_GXCON IHMC
						where IHMO.EMR_SEQ = IHMC.EMR_SEQ 
                        and IHMC.CATALOG_DATE is NOT NULL";
            m_hstMainSql.Add("S11", strSql);            
            #endregion

            #region 病案首页入院诊断
            strSql = @"select distinct IHMI.inpatientid, IHMI.inpatientdate
						from T_EMR_INHOSPITALMAINREC_GXID IHMI ,T_EMR_INHOSPITALMAINREC_GXCON IHMC
						where IHMI.EMR_SEQ = IHMC.EMR_SEQ 
                        and IHMC.CATALOG_DATE is NOT NULL";
            m_hstMainSql.Add("S12", strSql); 
            #endregion
        } 
        #endregion

        #region 根据HashTable键值获取主体查询语句
        /// <summary>
        /// 根据HashTable键值获取主体查询语句
        /// </summary>
        /// <param name="p_strKey">键值</param>
        /// <returns></returns>
        private string m_strGetMainSQL(string p_strKey)
        {
            if (m_hstMainSql.Contains(p_strKey))
                return m_hstMainSql[p_strKey] as string;
            return null;
        } 
        #endregion

        #region 根据数据类型返回表达式
        /// <summary>
        /// 根据数据类型返回表达式
        /// </summary>
        /// <param name="p_strType">数据类型描述</param>
        /// <returns></returns>
        private clsExpressionInfo[] m_objGetExpItemArr(string p_strType)
        {
            clsExpressionInfo[] obj = null;
            string[] strItemArr = null;
            string[] strConditionArr = null;
            switch (p_strType)
            {
                case "STRING":
                    strItemArr = new string[] { "内容包含", "内容是", "内容开头是", "内容结尾是" };
                    strConditionArr = new String[strItemArr.Length];
                    strConditionArr[0] = @" like '%<CONTENT>%'";
                    strConditionArr[1] = @" = '<CONTENT>'";
                    strConditionArr[2] = @" like '<CONTENT>%'";
                    strConditionArr[3] = @" like '%<CONTENT>'";
                    obj = new clsExpressionInfo[strItemArr.Length];
                    for (int i = 0; i < strItemArr.Length; i++)
                    {
                        obj[i] = new clsExpressionInfo();
                        obj[i].m_strType = strItemArr[i];
                        obj[i].m_strExpressionArr = strConditionArr[i];
                    }
                    return obj;
                case "INT":
                    strItemArr = new string[] { "范围", "大于", "大于等于", "小于", "小于等于", "等于", "不等于" };
                    strConditionArr = new String[strItemArr.Length];
                    strConditionArr[0] = @" between <FIRSTNUMBER> and <ENDNUMBER> ";
                    strConditionArr[1] = @" > <FIRSTNUMBER>";
                    strConditionArr[2] = @" >= <FIRSTNUMBER>";
                    strConditionArr[3] = @" < <FIRSTNUMBER>";
                    strConditionArr[4] = @" <= <FIRSTNUMBER>";
                    strConditionArr[5] = @" = <FIRSTNUMBER>";
                    strConditionArr[6] = @"<> <FIRSTNUMBER>";
                    obj = new clsExpressionInfo[strItemArr.Length];
                    for (int k = 0; k < strItemArr.Length; k++)
                    {
                        obj[k] = new clsExpressionInfo();
                        obj[k].m_strType = strItemArr[k];
                        obj[k].m_strExpressionArr = strConditionArr[k];
                    }
                    return obj;
                case "DATE":
                    strItemArr = new string[] { "日期范围", "日期是" };
                    strConditionArr = new String[strItemArr.Length];
                    strConditionArr[0] = " between <FIRSTDATE> and <ENDDATE> ";
                    strConditionArr[1] = " = <FIRSTDATE> ";
                    obj = new clsExpressionInfo[strItemArr.Length];
                    for (int j = 0; j < strItemArr.Length; j++)
                    {
                        obj[j] = new clsExpressionInfo();
                        obj[j].m_strType = strItemArr[j];
                        obj[j].m_strExpressionArr = strConditionArr[j];
                    }
                    return obj;
                default:
                    break;
            }
            return null;
        } 
        #endregion

        #region 选择m_trvMain结点激发事件
        private void m_trvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_trvMain.SelectedNode == null || m_trvMain.SelectedNode.Tag == null || m_trvMain.SelectedNode.Parent == null)
            {
                m_cmdAddCondition.Enabled = false;
                return;
            }
            string strType = "";
            clsDataSearchesType objSearchesType = m_trvMain.SelectedNode.Tag as clsDataSearchesType;
            if (objSearchesType != null)
                strType = objSearchesType.m_strDataType;
            m_mthSetInputVisible(strType);
        } 
        #endregion

        #region 显示查询条件输入
        /// <summary>
        /// 显示查询条件输入
        /// </summary>
        /// <param name="p_strType">条件类型</param>
        private void m_mthSetInputVisible(string p_strType)
        {
            m_txtLongTextContent.Text = "";
            m_txtNumberFrom.Text = "";
            m_txtNumberTo.Text = "";
            m_pnlLongText.Visible = (p_strType == "STRING");
            m_pnlTrueFalse.Visible = (p_strType == "BOOL");
            m_pnlDate.Visible = (p_strType == "DATE");
            m_pnlNumber.Visible = (p_strType == "INT");
            m_cmdAddCondition.Enabled = (m_pnlLongText.Visible || m_pnlDate.Visible || m_pnlTrueFalse.Visible || m_pnlNumber.Visible);
        } 
        #endregion

        #region 根据m_cboDateConditionType选择项不同显示不同输入控件
        private void m_cboDateConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cboDateConditionType.SelectedIndex < 0)
                return;
            bool blnVisible = (m_cboDateConditionType.SelectedIndex == 0);
            m_lblDateFrom.Visible = blnVisible;
            m_lblDateTo.Visible = blnVisible;
            m_dtpSecond.Visible = blnVisible;
            if (blnVisible)//控制初始条件为当前月
            {
                m_dtpFirst.Text = DateTime.Now.ToString("yyyy-MM-01 00:00:00");
                m_dtpSecond.Text = m_dtpFirst.Value.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd 00:00:00");
            }
        } 
        #endregion

        #region 根据m_cboNumberConditionType选择项不同显示不同输入控件
        private void m_cboNumberConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cboNumberConditionType.SelectedIndex < 0)
                return;
            bool blnVisible = (m_cboNumberConditionType.SelectedIndex == 0);
            m_lblNumberTo.Visible = blnVisible;
            m_txtNumberTo.Visible = blnVisible;
        } 
        #endregion

        #region 双击m_lsvResultList选中Item打开病案首页窗体
        private void m_lsvResultList_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvResultList.Items.Count > 0 && m_lsvResultList.SelectedItems.Count > 0)
            {
                clsPatient objPa = new clsPatient(m_lsvResultList.SelectedItems[0].SubItems[0].Text.Trim());

                frmInHospitalMainRecord_GXForCH frmRecord = new frmInHospitalMainRecord_GXForCH();
                frmRecord.MdiParent = this.MdiParent;
                frmRecord.Show();
                frmRecord.m_mthSetSelectedPatient(objPa);
            }
        } 
        #endregion
    }
}