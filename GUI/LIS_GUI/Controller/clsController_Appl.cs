using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.middletier.LIS; //LisApplSvr.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// Summary description for clsController_Appl.
    /// </summary>
    public class clsController_Appl : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmLisAppl m_frmViewer;
        private System.Collections.Hashtable m_hasSampleGroup = new Hashtable();

        #region 构造函数
        public clsController_Appl()
        {
            m_mthInitSampleGroupHas();
        }
        private void m_mthInitSampleGroupHas()
        {
            clsSampleGroup_VO[] objSampleGroupVOArr = null;
            new clsDomainController_SampleGroupManage().m_lngGetAllSampleGroup(out objSampleGroupVOArr);
            if (objSampleGroupVOArr != null && objSampleGroupVOArr.Length != 0)
            {
                for (int i = 0; i < objSampleGroupVOArr.Length; i++)
                {
                    this.m_hasSampleGroup.Add(objSampleGroupVOArr[i].strSampleGroupID, objSampleGroupVOArr[i].strSampleGroupName);
                }
            }

        }
        #endregion

        #region override Set_GUI_Apperance&&Save
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_frmViewer = (frmLisAppl)frmMDI_Child_Base_in;
        }

        public override void Save(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_In)
        {

        }

        #endregion

        #region 设置检验内容描述
        public string m_strSetCheckContent(clsLIS_App objAppInfo)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (clsLIS_AppApplyUnit obj in objAppInfo.m_ObjAppApplyUnits)
            {

                if (obj.m_ObjApplyUnit.m_ObjDataVO.strApplUnitName != null && obj.m_ObjApplyUnit.m_ObjDataVO.strApplUnitName.Trim() != "")
                {
                    sb.Append(obj.m_ObjApplyUnit.m_ObjDataVO.strApplUnitName + ",");
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            string strCheckContent = sb.ToString();

            objAppInfo.m_ObjDataVO.m_strCheckContent = strCheckContent;
            return strCheckContent;
        }
        #endregion

        #region 申请单操作
        //保存申请单
        public bool m_blnSaveApp(out string p_strMessage)
        {
            p_strMessage = "";
            clsLIS_App objApp = this.m_frmViewer.m_objCurrApp;

            #region 构造保存参数
            ArrayList arlRep = new ArrayList();
            ArrayList arlSam = new ArrayList();
            ArrayList arlItem = new ArrayList();
            ArrayList arlUnit = new ArrayList();
            ArrayList arlUnitItem = new ArrayList();

            foreach (clsLIS_AppCheckReport objRep in objApp.m_ObjAppReports)
            {
                arlRep.Add(objRep.m_ObjDataVO);
                foreach (clsLIS_AppSampleGroup objSam in objRep.m_ObjAppSampleGroups)
                {
                    arlSam.Add(objSam.m_ObjDataVO);
                    foreach (clsLIS_AppCheckItem objItem in objSam.m_ObjAppCheckItems)
                    {
                        arlItem.Add(objItem.m_ObjDataVO);
                    }
                }
            }
            foreach (clsLIS_AppApplyUnit objUnit in objApp.m_ObjAppApplyUnits)
            {
                arlUnit.Add(objUnit.m_ObjDataVO);
                arlUnitItem.AddRange(objUnit.m_ObjItemArr);
            }

            clsT_OPR_LIS_APP_REPORT_VO[] objRepArr = (clsT_OPR_LIS_APP_REPORT_VO[])arlRep.ToArray(typeof(clsT_OPR_LIS_APP_REPORT_VO));
            clsT_OPR_LIS_APP_SAMPLE_VO[] objSamArr = (clsT_OPR_LIS_APP_SAMPLE_VO[])arlSam.ToArray(typeof(clsT_OPR_LIS_APP_SAMPLE_VO));
            clsT_OPR_LIS_APP_CHECK_ITEM_VO[] objItemArr = (clsT_OPR_LIS_APP_CHECK_ITEM_VO[])arlItem.ToArray(typeof(clsT_OPR_LIS_APP_CHECK_ITEM_VO));
            clsT_OPR_LIS_APP_APPLY_UNIT_VO[] objUnitArr = (clsT_OPR_LIS_APP_APPLY_UNIT_VO[])arlUnit.ToArray(typeof(clsT_OPR_LIS_APP_APPLY_UNIT_VO));
            clsLisAppUnitItemVO[] objUnitItemArr = (clsLisAppUnitItemVO[])arlUnitItem.ToArray(typeof(clsLisAppUnitItemVO));

            #endregion

            if (objApp.m_StrAppID == null)
            {
                //获取检验配置信息		
                string strConfig = "";
                long lngRes = new clsDomainController_ApplicationManage().m_lngGetCollocate(out strConfig, "4002");
                if (lngRes < 0)
                {
                    return false;
                }

                //根据配置信息选择流程		
                switch (strConfig.Trim())
                {
                    case "1":
                        lngRes = 0;
                        this.m_frmViewer.m_objCurrApp.m_ObjDataVO.m_intPStatus_int = 2;
                        lngRes = new clsDomainController_ApplicationManage().m_lngAddNewAppAndSampleInfoWithBarcode(this.m_frmViewer.m_objCurrApp.m_ObjDataVO, objRepArr, objSamArr, objItemArr, objUnitArr, objUnitItemArr);
                        break;
                    case "2":   //跳过采集不跳过核收		
                        lngRes = 0;
                        this.m_frmViewer.m_objCurrApp.m_ObjDataVO.m_intPStatus_int = 2;
                        lngRes = new clsDomainController_ApplicationManage().m_lngAddAppInfoWithoutReceive(this.m_frmViewer.m_objCurrApp.m_ObjDataVO, objRepArr, objSamArr, objItemArr, objUnitArr, objUnitItemArr);
                        break;
                    default:
                        lngRes = 0;
                        lngRes = new clsDomainController_ApplicationManage().m_lngAddNewAppInfo(this.m_frmViewer.m_objCurrApp.m_ObjDataVO, objRepArr, objSamArr, objItemArr, objUnitArr, objUnitItemArr);
                        break;
                }
                if (lngRes > 0)
                {
                    this.m_frmViewer.m_objCurrApp.m_mthAcceptChanges();
                    return true;
                }
            }
            else if (objApp.m_ObjAppApplyUnits.Count > 0)
            {
                long lngRes = new clsDomainController_ApplicationManage().m_lngModifyAppInfo(this.m_frmViewer.m_objCurrApp.m_ObjDataVO,
                    objRepArr, objSamArr, objItemArr, objUnitArr, objUnitItemArr);
                if (lngRes > 0)
                {
                    this.m_frmViewer.m_objCurrApp.m_mthAcceptChanges();
                    return true;
                }
            }
            else
            {
                long lngRes = new clsDomainController_ApplicationManage().m_lngAddNewApplication(objApp.m_ObjDataVO);
                if (lngRes > 0)
                {
                    this.m_frmViewer.m_objCurrApp.m_mthAcceptChanges();
                    return true;
                }
            }
            p_strMessage = "操作失败!";
            return false;
        }
        //删除申请单
        public bool m_blnDeleteApp(out string p_strMessage)
        {
            p_strMessage = "";
            long lngRes = new clsDomainController_ApplicationManage().m_lngAddNewApplication(this.m_frmViewer.m_objCurrApp.m_ObjDataVO);
            if (lngRes > 0)
                return true;
            p_strMessage = "操作失败!";
            return false;
        }
        //发送申请单
        public bool m_blnSendApp(out string p_strMessage)
        {
            p_strMessage = "";
            if (this.m_frmViewer.m_objCurrApp.m_StrAppID == null || this.m_frmViewer.m_objCurrApp.m_StrAppID == "")
            {
                p_strMessage = "请先保存申请!";
                return false;
            }
            this.m_frmViewer.m_objCurrApp.m_IntPStatus = 2;
            this.m_frmViewer.m_objCurrApp.m_StrOperatorID = this.m_frmViewer.m_strGetOp();
            long lngRes = new clsDomainController_ApplicationManage().m_lngAddNewApplication(this.m_frmViewer.m_objCurrApp.m_ObjDataVO);
            if (lngRes > 0)
            {
                this.m_frmViewer.m_objCurrApp.m_mthAcceptChanges();
                return true;
            }
            this.m_frmViewer.m_objCurrApp.m_IntPStatus = 1;
            this.m_frmViewer.m_objCurrApp.m_StrOperatorID = this.m_frmViewer.m_objCurrApp.m_ObjOriginalDataVO.m_strOperator_ID;
            p_strMessage = "操作失败!";
            return false;
        }
        #endregion

        #region 模糊查询病人信息 谢成鸿 2004-2-12
        public void m_mthFussQueryPat(com.digitalwave.iCare.gui.LIS.frmLisAppl p_frmLisAppl, System.Windows.Forms.Control p_objControl)
        {
            p_frmLisAppl.m_lsvPatFussQuery.Items.Clear();
            p_frmLisAppl.m_lsvPatFussQuery.Left = p_frmLisAppl.m_grpPatientInfo.Left + p_objControl.Left;
            p_frmLisAppl.m_lsvPatFussQuery.Top = p_frmLisAppl.m_grpPatientInfo.Top + p_objControl.Top + p_objControl.Height;

            string strControlName = p_objControl.Name;
            string p_strFussField = null;
            string p_strFussValue = null;
            string p_strOrderField = "patientid_chr";
            int intQueryType = 0;

            switch (strControlName)
            {
                case "m_txtPatCardID":
                    p_strFussField = "PATIENTCARDID_CHR";
                    p_strFussValue = p_frmLisAppl.m_txtPatCardID.Text;
                    intQueryType = 1;
                    break;
                case "m_txtPatName":
                    p_strFussField = "name_vchr";
                    p_strFussValue = p_frmLisAppl.m_txtPatName.Text;
                    break;
                case "m_txtInhospNO":
                    p_strFussField = "inpatientid_chr";
                    p_strFussValue = p_frmLisAppl.m_txtInhospNO.Text;
                    break;
            }

            com.digitalwave.iCare.middletier.PatientSvc.clsPatientSvc objPatSvc = null;
            objPatSvc = (com.digitalwave.iCare.middletier.PatientSvc.clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.PatientSvc.clsPatientSvc));
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            long lngRes = 0;
            com.digitalwave.iCare.ValueObject.clsPatientVO[] objPatList = null;

            lngRes = objPatSvc.m_lngGetPatientListByFuzzyCriteria(p_objPrincipal, intQueryType, p_strFussField, p_strFussValue, p_strOrderField, false, out objPatList);

            if (lngRes == 1 && objPatList != null)
            {
                if (objPatList.Length > 1)
                {
                    for (int i = 0; i < objPatList.Length; i++)
                    {
                        System.Windows.Forms.ListViewItem objListViewItem = new System.Windows.Forms.ListViewItem();
                        objListViewItem.Text = objPatList[i].strPatientID;
                        objListViewItem.SubItems.Add(objPatList[i].strPatientCardID);
                        objListViewItem.SubItems.Add(objPatList[i].strInPatientID);
                        objListViewItem.SubItems.Add(objPatList[i].strName);
                        objListViewItem.Tag = objPatList[i];
                        p_frmLisAppl.m_lsvPatFussQuery.Items.Add(objListViewItem);
                    }
                    p_frmLisAppl.m_lsvPatFussQuery.Select();
                    p_frmLisAppl.m_lsvPatFussQuery.Visible = true;
                    p_frmLisAppl.m_lsvPatFussQuery.Focus();
                    p_frmLisAppl.m_lsvPatFussQuery.Items[0].Selected = true;
                    p_frmLisAppl.m_lsvPatFussQuery.Items[0].Focused = true;
                }
                else if (objPatList.Length == 1)
                {
                    p_frmLisAppl.m_txtPatCardID.Text = objPatList[0].strPatientCardID;
                    p_frmLisAppl.m_txtPatName.Text = objPatList[0].strName;
                    p_frmLisAppl.m_cboSex.Text = objPatList[0].strSex;
                    p_frmLisAppl.m_txtInhospNO.Text = objPatList[0].strInPatientID;
                    p_frmLisAppl.m_txtPatientID.Text = objPatList[0].strPatientID;
                    if (objPatList[0].strBirthDate != null && Microsoft.VisualBasic.Information.IsDate(objPatList[0].strBirthDate))
                    {
                        string strAge = clsAgeConverter.s_strToAge(DateTime.Parse(objPatList[0].strBirthDate), " 岁| 月| 天");

                        p_frmLisAppl.m_txtAge.Text = clsAgeConverter.m_strGetAgeNum(strAge);
                        p_frmLisAppl.m_cboAgeUnit.Text = clsAgeConverter.m_strGetAgeUnit(strAge);
                    }

                }
            }
        }
        #endregion

        #region 获取病人信息  谢成鸿 2004-2-12
        public void m_mthPickPatInfo(com.digitalwave.iCare.gui.LIS.frmLisAppl p_frmLisApp_In)
        {
            com.digitalwave.iCare.ValueObject.clsPatientVO objPatientVO = (clsPatientVO)p_frmLisApp_In.m_lsvPatFussQuery.SelectedItems[0].Tag;
            p_frmLisApp_In.m_txtPatCardID.Text = objPatientVO.strPatientCardID;
            if (objPatientVO.strName != null)
                p_frmLisApp_In.m_txtPatName.Text = objPatientVO.strName;
            if (objPatientVO.strSex != null)
                p_frmLisApp_In.m_cboSex.Text = objPatientVO.strSex;
            p_frmLisApp_In.m_txtInhospNO.Text = objPatientVO.strInPatientID;
            p_frmLisApp_In.m_txtPatientID.Text = objPatientVO.strPatientID;

            if (objPatientVO.strBirthDate != null && Microsoft.VisualBasic.Information.IsDate(objPatientVO.strBirthDate))
            {
                string strAge = clsAgeConverter.s_strToAge(DateTime.Parse(objPatientVO.strBirthDate), " 岁| 月| 天");

                p_frmLisApp_In.m_txtAge.Text = clsAgeConverter.m_strGetAgeNum(strAge);
                p_frmLisApp_In.m_cboAgeUnit.Text = clsAgeConverter.m_strGetAgeUnit(strAge);

            }
        }
        #endregion

        #region 按申请日期，发送状态查询检验单序列 刘彬 2004.07.1
        public void m_mthGetAppl(com.digitalwave.iCare.gui.LIS.frmLisAppl p_frmLisAppl)
        {
            long lngRes = 0;
            //string strFromDate = p_frmLisAppl.m_dtpApplBegin.Value.ToString("yyyy-MM-dd");
            //string strToDate = p_frmLisAppl.m_dtpApplEnd.Value.AddDays(1).ToString("yyyy-MM-dd");
            string strFromDate = p_frmLisAppl.m_dtpApplBegin.Value.ToShortDateString() + " 00:00:00";
            string strToDate = p_frmLisAppl.m_dtpApplEnd.Value.ToShortDateString() + " 23:59:59";
            bool blnSend = false;
            bool blnUnsend = false;

            if (p_frmLisAppl.m_rdbNotSend.Checked)
                blnUnsend = true;
            else if (p_frmLisAppl.m_rdbHaveSended.Checked)
                blnSend = true;
            else if (p_frmLisAppl.m_rdbAll.Checked)
            {
                blnUnsend = true;
                blnSend = true;
            }
            clsLisApplMainVO[] objAppVOArr = null;

            lngRes = new clsDomainController_ApplicationManage().m_lngGetApplicationVOArrByCondition(strFromDate, strToDate, blnSend, blnUnsend, out objAppVOArr);
            p_frmLisAppl.m_lsvAppl.Items.Clear();
            if ((lngRes > 0) && (objAppVOArr != null))
            {

                for (int i = 0; i < objAppVOArr.Length; i++)
                {
                    System.Windows.Forms.ListViewItem objListViewItem = new System.Windows.Forms.ListViewItem();

                    if (objAppVOArr[i].m_strAPPLICATION_ID != null)
                    {
                        objListViewItem.Text = objAppVOArr[i].m_strAPPLICATION_ID.Substring(8, 10); ;
                        objListViewItem.SubItems.Add(objAppVOArr[i].m_strPatient_Name);
                        if (objAppVOArr[i].m_intPStatus_int == 1)
                        {
                            objListViewItem.SubItems.Add("未发送");
                        }
                        else if (objAppVOArr[i].m_intPStatus_int > 1)
                        {
                            objListViewItem.SubItems.Add("已发送");
                        }
                        else if (objAppVOArr[i].m_intPStatus_int == 0)
                        {
                            objListViewItem.SubItems.Add("已作废");
                        }

                        //先诊疗后交费的判断，和显示的颜色设置
                        if (objAppVOArr[i].m_intIsGreen == 1)
                        {
                            objListViewItem.BackColor = Color.Orange;
                        }

                        objListViewItem.Tag = objAppVOArr[i];
                        p_frmLisAppl.m_lsvAppl.Items.Add(objListViewItem);
                    }
                }
            }
            if (p_frmLisAppl.m_lsvAppl.Items.Count > 0)
            {
                p_frmLisAppl.m_lsvAppl.Items[0].Selected = true;
            }
            else
            {
                p_frmLisAppl.m_mthEnterInitStatus();//清空数据
            }
        }
        #endregion

        #region 根据申请单ID得到申请检验项目信息 刘彬 2004.07.1
        public void m_mthGetAppCheckInfo(string p_strAppID, out clsLISAppCheckInfoItem[] p_objItemArr)
        {
            long lngRes = 0;
            p_objItemArr = null;
            clsT_OPR_LIS_APP_APPLY_UNIT_VO[] objAppUnitVOArr = null;

            lngRes = new clsDomainController_ApplicationManage().m_lngGetAppApplyUnitVOByApplicationID(p_strAppID, out objAppUnitVOArr);

            if (lngRes > 0 && objAppUnitVOArr != null && objAppUnitVOArr.Length > 0)
            {
                p_objItemArr = new clsLISAppCheckInfoItem[objAppUnitVOArr.Length];
                for (int i = 0; i < objAppUnitVOArr.Length; i++)
                {
                    p_objItemArr[i] = new clsLISAppCheckInfoItem();
                    long lngRes1 = 0;
                    clsApplUnit_VO objUintVO = null;
                    lngRes1 = new clsDomainController_ApplyUnitManage().m_lngGetApplyUnitVOByApplyUnitID(objAppUnitVOArr[i].m_strAPPLY_UNIT_ID_CHR, out objUintVO);
                    if (lngRes1 > 0 && objUintVO != null)
                    {
                        p_objItemArr[i].m_StrAppGroupName = objUintVO.strApplUnitName;
                        if (objUintVO.strIsNoFoodRequired == "1")
                        {
                            p_objItemArr[i].m_StrFood = "需要";
                        }
                        else if (objUintVO.strIsNoFoodRequired == "0")
                        {
                            p_objItemArr[i].m_StrFood = "不需要";
                        }
                        if (objUintVO.strIsPhysicsExamRequired == "1")
                        {
                            p_objItemArr[i].m_StrMedicalExam = "需要";
                        }
                        else if (objUintVO.strIsPhysicsExamRequired == "0")
                        {
                            p_objItemArr[i].m_StrMedicalExam = "不需要";
                        }
                        if (objUintVO.strIsReservationRequired == "1")
                        {
                            p_objItemArr[i].m_StrReservation = "需要";
                        }
                        else if (objUintVO.strIsReservationRequired == "0")
                        {
                            p_objItemArr[i].m_StrReservation = "不需要";
                        }
                    }
                    else
                    {
                        p_objItemArr[i].m_StrAppGroupName = "未知";
                    }
                }
            }
        }
        #endregion

    }

    public class clsLISAppCheckInfoItem
    {
        public string m_StrAppGroupName;
        public string m_StrFood;
        public string m_StrReservation;
        public string m_StrMedicalExam;
    }

}
