using System;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.Template.Client;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.gui.LIS
{
    #region clsApp

    /// <summary>
    /// clsApp【申请单Biz】
    /// </summary>
    public class clsApp
    {

        //#region 私有成员
       
        //private enmObjectOperationState m_enmOprState;
        //private clsLisApplMainVO m_objDataVO;
        //private clsLisApplMainVO m_objOriginalDataVO;
        //private clsAppCheckReportCollection m_objAppReports;
        //private clsAppApplyUnitCollection m_objAppApplyUnits;
        //private string m_strAppID;

        //#endregion

        //#region 构造函数

        //public clsApp(clsLisApplMainVO p_objDataVO)
        //{
        //    this.m_objDataVO = p_objDataVO;
        //    m_enmOprState = enmObjectOperationState.New;

        //    m_objAppReports = new clsAppCheckReportCollection();
        //    m_objAppApplyUnits = new clsAppApplyUnitCollection();
        //    m_objAppReports.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppReports_evtItemAdded);
        //    m_objAppApplyUnits.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppApplyUnits_evtItemAdded);
        //    m_objAppReports.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppReports_evtItemRemoved);
        //    m_objAppApplyUnits.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppApplyUnits_evtItemRemoved);
        //}

        //public clsApp(clsLisApplMainVO appMainVO, bool isOriginal)
        //{
        //    if (isOriginal)
        //    {
        //        this.m_objDataVO = appMainVO;
        //        this.m_objOriginalDataVO = new clsLisApplMainVO();

        //        m_mthDataTransfer(appMainVO, m_objOriginalDataVO);

        //        m_enmOprState = enmObjectOperationState.Original;
        //    }
        //    else
        //    {
        //        this.m_objDataVO = appMainVO;
        //        m_enmOprState = enmObjectOperationState.New;
        //    }

        //    m_objAppReports = new clsAppCheckReportCollection();
        //    m_objAppApplyUnits = new clsAppApplyUnitCollection();
        //    m_objAppReports.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppReports_evtItemAdded);
        //    m_objAppApplyUnits.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppApplyUnits_evtItemAdded);
        //    m_objAppReports.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppReports_evtItemRemoved);
        //    m_objAppApplyUnits.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppApplyUnits_evtItemRemoved);

        //}

        //#endregion

        //#region VOManage

        ///// <summary>
        ///// 申请单号
        ///// </summary>
        //public string m_StrAppID
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strAPPLICATION_ID;
        //    }
        //    set
        //    {
        //        if (this.m_objDataVO.m_strAPPLICATION_ID != value || this.m_strAppID != value)
        //        {
        //            this.m_objDataVO.m_strAPPLICATION_ID = value;
        //            this.m_strAppID = value;
        //            foreach (clsLIS_AppApplyUnit objUnit in this.m_ObjAppApplyUnits)
        //            {
        //                objUnit.m_StrAppID = value;
        //            }
        //            foreach (clsLIS_AppCheckReport objAppReport in this.m_ObjAppReports)
        //            {
        //                objAppReport.m_StrAppID = value;
        //            }
        //            if (this.evtApplicationIDChanged != null)
        //            {
        //                evtApplicationIDChanged(this, new EventArgs());
        //            }

        //        }
        //    }
        //}

        ///// <summary>
        ///// 修改时间
        ///// </summary>
        //public string m_StrMODIFY_DAT
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strMODIFY_DAT;
        //    }
        //}
        ///// <summary>
        ///// 病人编号：每个病人的维一编号
        ///// </summary>
        //public string m_StrPatientID
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strPatientID;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strPatientID = value;
        //    }
        //}
        ///// <summary>
        ///// 申请日期
        ///// </summary>
        //public string m_StrAppDat
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strAppl_Dat;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strAppl_Dat = value;
        //    }
        //}
        ///// <summary>
        ///// 病人性别
        ///// </summary>
        //public string m_StrSex
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strSex;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strSex = value;
        //    }
        //}
        ///// <summary>
        ///// 病人姓名
        ///// </summary>
        //public string m_StrPatientName
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strPatient_Name;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strPatient_Name = value;
        //    }
        //}
        ///// <summary>
        ///// 作废
        ///// </summary>
        //public string m_StrPatientSubNO
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strPatient_SubNO;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strPatient_SubNO = value;
        //    }
        //}
        ///// <summary>
        ///// 病人年龄
        ///// </summary>
        //public string m_StrAge
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strAge;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strAge = value;
        //    }
        //}
        ///// <summary>
        ///// 病人类别 分门诊、住院、急诊、体检等
        ///// </summary>
        //public string m_StrPatientType
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strPatientType;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strPatientType = value;
        //    }
        //}
        ///// <summary>
        ///// 临床诊断
        ///// </summary>
        //public string m_StrDiagnose
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strDiagnose;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strDiagnose = value;
        //    }
        //}
        ///// <summary>
        ///// 病人床号
        ///// </summary>
        //public string m_StrBedNO
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strBedNO;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strBedNO = value;
        //    }
        //}
        ///// <summary>
        ///// 临床诊断ICD码
        ///// </summary>
        //public string m_StrICD
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strICD;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strICD = value;
        //    }
        //}
        ///// <summary>
        ///// 就诊卡号
        ///// </summary>
        //public string m_StrPatientCardID
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strPatientcardID;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strPatientcardID = value;
        //    }
        //}
        ///// <summary>
        ///// 申请表编号
        ///// </summary>
        //public string m_StrApplicationFormNO
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strApplication_Form_NO;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strApplication_Form_NO = value;
        //    }
        //}
        ///// <summary>
        ///// 操作员工ID
        ///// </summary>
        //public string m_StrOperatorID
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strOperator_ID;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strOperator_ID = value;
        //    }
        //}
        ///// <summary>
        ///// 申请医生的员工ID
        ///// </summary>
        //public string m_StrApplEmpID
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strAppl_EmpID;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strAppl_EmpID = value;
        //    }
        //}
        ///// <summary>
        ///// 申请检验的科室部门ID
        ///// </summary>
        //public string m_StrApplDeptID
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strAppl_DeptID;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strAppl_DeptID = value;
        //    }
        //}
        ///// <summary>
        ///// 检验结果建议
        ///// </summary>
        //public string m_StrSummary
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strSummary;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strSummary = value;
        //    }
        //}
        ///// <summary>
        ///// 过程状态标识
        ///// </summary>
        //public int m_IntPStatus
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_intPStatus_int;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_intPStatus_int = value;
        //    }
        //}
        ///// <summary>
        ///// 急诊状态
        ///// </summary>
        //public int m_IntEmergency
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_intEmergency;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_intEmergency = value;
        //    }
        //}
        ///// <summary>
        ///// 特殊状态
        ///// </summary>
        //public int m_IntSpecial
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_intSpecial;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_intSpecial = value;
        //    }
        //}
        ///// <summary>
        ///// 0-正式申请,1-后补申请
        ///// </summary>
        //public int m_IntForm
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_intForm_int;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_intForm_int = value;
        //    }
        //}
        ///// <summary>
        ///// 病人住院号
        ///// </summary>
        //public string m_StrPatientInhospNO
        //{
        //    get
        //    {
        //        return this.m_objDataVO.m_strPatient_inhospitalno_chr;
        //    }
        //    set
        //    {
        //        this.m_objDataVO.m_strPatient_inhospitalno_chr = value;
        //    }
        //}

        //#endregion

        //#region 事件申明

        ///// <summary>
        ///// 申请单元Id改变事件
        ///// </summary>
        //private event EventHandler evtApplicationIDChanged;

        //#endregion

        //#region 属 性

        ///// <summary>
        ///// 当前的状态
        ///// </summary>
        //private enmObjectOperationState m_EnuOprState
        //{
        //    get
        //    {
        //        return this.m_enmOprState;
        //    }
        //}

        ///// <summary>
        ///// 修改前的原数据
        ///// </summary>
        //public clsLisApplMainVO m_ObjOriginalDataVO
        //{
        //    get
        //    {
        //        return m_objOriginalDataVO;
        //    }
        //}

        ///// <summary>
        ///// 修改以后的数据
        ///// </summary>
        //public clsLisApplMainVO m_ObjDataVO
        //{
        //    get
        //    {
        //        return this.m_objDataVO;
        //    }
        //}

        ///// <summary>
        ///// 获取检验报告集合
        ///// </summary>
        //public clsAppCheckReportCollection m_ObjAppReports
        //{
        //    get { return this.m_objAppReports; }
        //}

        ///// <summary>
        ///// 获取申请单元集合
        ///// </summary>
        //public clsAppApplyUnitCollection m_ObjAppApplyUnits
        //{
        //    get { return this.m_objAppApplyUnits; }
        //}

        //#endregion

        //#region 辅助方法

        ///// <summary>
        ///// 【删除App操作】只有 Original,Modified 状态的使用本方法才有效
        ///// </summary>
        //private void m_mthDelete()
        //{
        //    if (this.m_enmOprState != enmObjectOperationState.New)
        //    {
        //        this.m_mthDataTransfer(this.m_objOriginalDataVO, this.m_objDataVO);
        //        this.m_objDataVO.m_intPStatus_int = 0;
        //        this.m_enmOprState = enmObjectOperationState.Deleted;
        //    }
        //}

        //public void m_mthMatchOpState()
        //{
        //    if (this.m_EnuOprState != (enmObjectOperationState.New | enmObjectOperationState.Deleted))
        //    {
        //        if (m_objOriginalDataVO.m_intEmergency == m_objDataVO.m_intEmergency &&
        //            m_objOriginalDataVO.m_intForm_int == m_objDataVO.m_intForm_int &&
        //            m_objOriginalDataVO.m_intPStatus_int == m_objDataVO.m_intPStatus_int &&
        //            m_objOriginalDataVO.m_intSpecial == m_objDataVO.m_intSpecial &&
        //            m_objOriginalDataVO.m_strAge == m_objDataVO.m_strAge &&
        //            m_objOriginalDataVO.m_strAppl_Dat == m_objDataVO.m_strAppl_Dat &&
        //            m_objOriginalDataVO.m_strAppl_DeptID == m_objDataVO.m_strAppl_DeptID &&
        //            m_objOriginalDataVO.m_strAppl_EmpID == m_objDataVO.m_strAppl_EmpID &&
        //            m_objOriginalDataVO.m_strApplication_Form_NO == m_objDataVO.m_strApplication_Form_NO &&
        //            m_objOriginalDataVO.m_strAPPLICATION_ID == m_objDataVO.m_strAPPLICATION_ID &&
        //            m_objOriginalDataVO.m_strBedNO == m_objDataVO.m_strBedNO &&
        //            m_objOriginalDataVO.m_strDiagnose == m_objDataVO.m_strDiagnose &&
        //            m_objOriginalDataVO.m_strICD == m_objDataVO.m_strICD &&
        //            m_objOriginalDataVO.m_strMODIFY_DAT == m_objDataVO.m_strMODIFY_DAT &&
        //            m_objOriginalDataVO.m_strOperator_ID == m_objDataVO.m_strOperator_ID &&
        //            m_objOriginalDataVO.m_strPatient_inhospitalno_chr == m_objDataVO.m_strPatient_inhospitalno_chr &&
        //            m_objOriginalDataVO.m_strPatient_Name == m_objDataVO.m_strPatient_Name &&
        //            m_objOriginalDataVO.m_strPatient_SubNO == m_objDataVO.m_strPatient_SubNO &&
        //            m_objOriginalDataVO.m_strPatientcardID == m_objDataVO.m_strPatientcardID &&
        //            m_objOriginalDataVO.m_strPatientID == m_objDataVO.m_strPatientID &&
        //            m_objOriginalDataVO.m_strPatientType == m_objDataVO.m_strPatientType &&
        //            m_objOriginalDataVO.m_strSex == m_objDataVO.m_strSex &&
        //            m_objOriginalDataVO.m_strSummary == m_objDataVO.m_strSummary)
        //        {
        //            m_enmOprState = enmObjectOperationState.Original;
        //        }
        //        else
        //        {
        //            m_enmOprState = enmObjectOperationState.Modified;
        //        }
        //    }
        //}

        //public void m_mthAcceptChanges()
        //{
        //    if (this.m_objOriginalDataVO == null)
        //    {
        //        this.m_objOriginalDataVO = new clsLisApplMainVO();
        //    }
        //    this.m_mthDataTransfer(this.m_objDataVO, this.m_objOriginalDataVO);
        //    this.m_enmOprState = enmObjectOperationState.Original;
        //}

        //public void m_mthSetPatientInfoFromPatient(clsLIS_Patient p_objPatient)
        //{
        //    this.m_StrAge = p_objPatient.m_StrAge;
        //    this.m_StrBedNO = p_objPatient.m_StrBedNO;
        //    this.m_StrPatientCardID = p_objPatient.m_StrCardID;
        //    this.m_StrDiagnose = p_objPatient.m_StrDiagnose;
        //    this.m_StrICD = p_objPatient.m_StrICD;
        //    this.m_StrPatientInhospNO = p_objPatient.m_StrInhospNO;
        //    this.m_StrPatientID = p_objPatient.m_StrPatientID;
        //    this.m_StrPatientName = p_objPatient.m_StrPatientName;
        //    this.m_StrPatientType = p_objPatient.m_StrPatientTypeID;
        //    this.m_StrSex = p_objPatient.m_StrSex;
        //    this.m_StrPatientSubNO = p_objPatient.m_StrSubNO;

        //}

        //public void m_mthDataTransfer(clsLisApplMainVO p_objSource, clsLisApplMainVO p_objTarget)
        //{
        //    p_objTarget.m_intEmergency = p_objSource.m_intEmergency;
        //    p_objTarget.m_intForm_int = p_objSource.m_intForm_int;
        //    p_objTarget.m_intPStatus_int = p_objSource.m_intPStatus_int;
        //    p_objTarget.m_intSpecial = p_objSource.m_intSpecial;
        //    p_objTarget.m_strAge = p_objSource.m_strAge;
        //    p_objTarget.m_strAppl_Dat = p_objSource.m_strAppl_Dat;
        //    p_objTarget.m_strAppl_DeptID = p_objSource.m_strAppl_DeptID;
        //    p_objTarget.m_strAppl_EmpID = p_objSource.m_strAppl_EmpID;
        //    p_objTarget.m_strApplication_Form_NO = p_objSource.m_strApplication_Form_NO;
        //    p_objTarget.m_strAPPLICATION_ID = p_objSource.m_strAPPLICATION_ID;
        //    p_objTarget.m_strBedNO = p_objSource.m_strBedNO;
        //    p_objTarget.m_strDiagnose = p_objSource.m_strDiagnose;
        //    p_objTarget.m_strICD = p_objSource.m_strICD;
        //    p_objTarget.m_strMODIFY_DAT = p_objSource.m_strMODIFY_DAT;
        //    p_objTarget.m_strOperator_ID = p_objSource.m_strOperator_ID;
        //    p_objTarget.m_strPatient_inhospitalno_chr = p_objSource.m_strPatient_inhospitalno_chr;
        //    p_objTarget.m_strPatient_Name = p_objSource.m_strPatient_Name;
        //    p_objTarget.m_strPatient_SubNO = p_objSource.m_strPatient_SubNO;
        //    p_objTarget.m_strPatientcardID = p_objSource.m_strPatientcardID;
        //    p_objTarget.m_strPatientID = p_objSource.m_strPatientID;
        //    p_objTarget.m_strPatientType = p_objSource.m_strPatientType;
        //    p_objTarget.m_strSex = p_objSource.m_strSex;
        //    p_objTarget.m_strSummary = p_objSource.m_strSummary;
        //    p_objTarget.m_strSampleType = p_objSource.m_strSampleType;
        //    p_objTarget.m_strSampleTypeID = p_objSource.m_strSampleTypeID;
        //    p_objTarget.m_strCheckContent = p_objSource.m_strCheckContent;
        //}

        //#endregion

        //#region 事  件

        //private void m_objAppReports_evtItemAdded(object sender, clsObjectArrEventArgs e)
        //{
        //    if (e.m_ObjContentsArr != null)
        //    {
        //        for (int i = 0; i < e.m_ObjContentsArr.Length; i++)
        //        {
        //            if (((clsLIS_AppCheckReport)e.m_ObjContentsArr[i]).m_ObjApp != this)
        //            {
        //                ((clsLIS_AppCheckReport)e.m_ObjContentsArr[i]).m_ObjApp = this;
        //            }
        //        }
        //    }
        //}

        //private void m_objAppApplyUnits_evtItemAdded(object sender, clsObjectArrEventArgs e)
        //{
        //    if (e.m_ObjContentsArr != null)
        //    {
        //        for (int i = 0; i < e.m_ObjContentsArr.Length; i++)
        //        {
        //            if (((clsLIS_AppApplyUnit)e.m_ObjContentsArr[i]).m_ObjApp != this)
        //            {
        //                ((clsLIS_AppApplyUnit)e.m_ObjContentsArr[i]).m_ObjApp = this;
        //            }
        //        }
        //    }
        //}

        //private void m_objAppReports_evtItemRemoved(object sender, clsObjectArrEventArgs e)
        //{
        //    if (e.m_ObjContentsArr != null)
        //    {
        //        for (int i = 0; i < e.m_ObjContentsArr.Length; i++)
        //        {
        //            if (((clsLIS_AppCheckReport)e.m_ObjContentsArr[i]).m_ObjApp == this)
        //            {
        //                ((clsLIS_AppCheckReport)e.m_ObjContentsArr[i]).m_ObjApp = null;
        //            }
        //        }
        //    }
        //}

        //private void m_objAppApplyUnits_evtItemRemoved(object sender, clsObjectArrEventArgs e)
        //{
        //    if (e.m_ObjContentsArr != null)
        //    {
        //        for (int i = 0; i < e.m_ObjContentsArr.Length; i++)
        //        {
        //            if (((clsLIS_AppApplyUnit)e.m_ObjContentsArr[i]).m_ObjApp == this)
        //            {
        //                ((clsLIS_AppApplyUnit)e.m_ObjContentsArr[i]).m_ObjApp = null;
        //            }
        //        }
        //    }
        //}

        //#endregion

    }

    #endregion
}
