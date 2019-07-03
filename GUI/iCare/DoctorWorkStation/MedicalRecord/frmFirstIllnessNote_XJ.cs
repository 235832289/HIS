using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.Emr.Signature_gui;//多签名
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;

namespace iCare
{
    /// <summary>
    /// 首次病程记录---新疆
    /// </summary>
    public partial class frmFirstIllnessNote_XJ : iCare.frmDiseaseTrackBase
    {

        //定义签名类
        private clsEmrSignToolCollection m_objSign;


        public frmFirstIllnessNote_XJ()
        {
            InitializeComponent();

            //指明医生工作站表单
            intFormType = 1;
            cmdConfirm.Visible = false;
            // 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、输入字体颜色，双画线颜色）
            m_mthSetRichTextBoxAttribInControl(this);
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "440605001")
                lblCaseHistoryTitle.Text = "诊断依据与鉴别诊断:";

        }

        public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsDiseaseSummaryInfo objTrackInfo = new clsDiseaseSummaryInfo();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = "首次病程记录";

            //设置m_strTitle和m_dtmRecordTime
            if (objTrackInfo.m_ObjRecordContent != null)
            {
                m_dtpCreateDate.Value = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
                m_dtpCreateDate.Refresh();
            }
            return objTrackInfo;
        }
        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {

            //清空具体记录内容			
            //m_txtMostlyContent.m_mthClearText();
            //m_txtOriginalDiagnose.m_mthClearText();
            //m_txtDiagnoseThe.m_mthClearText();
            //m_txtCurePlan.m_mthClearText();
            txtbingliteidian.m_mthClearText();
            txtzhongyibianbingyiju.m_mthClearText();
            txtxiyizhenduanyiju.m_mthClearText();
            txtzhongyijianbiezhenduan.m_mthClearText();
            txtxiyijianbiezhenduan.m_mthClearText();
            txtzhongyichubu.m_mthClearText(); 
            txtxiyichubu.m_mthClearText();
            txtzhenliaojihua.m_mthClearText();

            //默认签名
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

        }

        /// <summary>
        /// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
        {
            if (p_blnEnable == false)
            {
                //foreach(Control control in this.Controls)
                //{					
                //    if(control.Name!="m_dtpCreateDate")
                //        control.Top=control.Top-105;				
                //}

                cmdConfirm.Visible = true;

                //this.Size=new Size(this.Size.Width, this.Size.Height-105);
                this.CenterToParent();

                //m_dtpCreateDate.Left=lblCreateDateTitle.Right+5;
                //m_dtpCreateDate.Top=lblCreateDateTitle.Top;
                //m_dtpCreateDate.Refresh();
            }
            this.MaximizeBox = false;
        }


        /// <summary>
        /// 具体记录的特殊控制,根据子窗体的需要重载实现
        /// </summary>
        /// <param name="p_blnEnable">是否允许修改特殊记录的记录信息。</param>
        protected override void m_mthEnableModifySub(bool p_blnEnable)
        {

        }

        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset">是否重置控制修改（修改留痕迹）。
        ///如果为true，忽略记录内容，把界面控制设置为不控制；
        ///否则根据记录内容进行设置。
        ///</param>
        protected override void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
            bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制

        }

        /// <summary>
        /// 从界面获取特殊记录的值。如果界面值出错，返回null。
        /// </summary>
        /// <returns></returns>
        protected override clsTrackRecordContent m_objGetContentFromGUI()
        {
            //界面参数校验
            int intSignCount = lsvSign.Items.Count;

            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null || intSignCount == 0)
                return null;
            //从界面获取表单值
            clsFirstIllnessNoteRecordContent_XJ objContent = new clsFirstIllnessNoteRecordContent_XJ();
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
            //获取lsvsign签名
            objContent.objSignerArr = new clsEmrSigns_VO[intSignCount];
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName="lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmFirstIllnessNote";
            //    objContent.objSignerArr[i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    //痕迹格式 0972,0324,
            //    strUserIDList=strUserIDList+objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim()+",";
            //    strUserNameList=strUserNameList+objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim()+",";
            //}
            objContent.m_strModifyUserID = strUserIDList;

            //设置Richtextbox的modifyuserID 和modifyuserName
            m_mthSetRichTextBoxAttribInControlWithIDandName(this);
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
            objContent.m_dtmCreateDate = m_dtpCreateDate.Value;
            //中医辩病辨证依据
            objContent.m_strZhongYiBianBing_Right = txtzhongyibianbingyiju.m_strGetRightText();
            objContent.m_strZhongYiBianBing = txtzhongyibianbingyiju.Text;
            objContent.m_strZhongYiBianBingXML = txtzhongyibianbingyiju.m_strGetXmlText();
            //(一)病例特点
            objContent.m_strBingLiTeDian_Right = txtbingliteidian.m_strGetRightText();
            objContent.m_strBingLiTeDian = txtbingliteidian.Text;
            objContent.m_strBingLiTeDianXML = txtbingliteidian.m_strGetXmlText();
            //(二)西医诊断依据
            objContent.m_strXiYiZhenDuanYiJu_Right = txtxiyizhenduanyiju.m_strGetRightText();
            objContent.m_strXiYiZhenDuanYiJu = txtxiyizhenduanyiju.Text;
            objContent.m_strXiYiZhenDuanYiJuXML = txtxiyizhenduanyiju.m_strGetXmlText();
            //（三）诊疗计划
            objContent.m_strZhenLiaoJiHua_Right = txtzhenliaojihua.m_strGetRightText();
            objContent.m_strZhenLiaoJiHua = txtzhenliaojihua.Text;
            objContent.m_strZhenLiaoJiHuaXML = txtzhenliaojihua.m_strGetXmlText();
            //中医鉴别诊断
            objContent.m_strZhongYiJianBie_Right = txtzhongyijianbiezhenduan.m_strGetRightText();
            objContent.m_strZhongYiJianBie = txtzhongyijianbiezhenduan.Text;
            objContent.m_strZhongYiJianBieXML = txtzhongyijianbiezhenduan.m_strGetXmlText();
            //西医鉴别诊断
            objContent.m_strXiYiJianBie_Right = txtxiyijianbiezhenduan.m_strGetRightText();
            objContent.m_strXiYiJianBie = txtxiyijianbiezhenduan.Text;
            objContent.m_strXiYiJianBieXML = txtxiyijianbiezhenduan.m_strGetXmlText();

            //中医初步诊断
            objContent.m_strZhongYiChuBu_Right = txtzhongyichubu.m_strGetRightText();
            objContent.m_strZhongYiChuBu = txtzhongyichubu.Text;
            objContent.m_strZhongYiChuBuXML = txtzhongyichubu.m_strGetXmlText();
            //西医初步诊断
            objContent.m_strXiYiChuBu_Right = txtxiyichubu.m_strGetRightText();
            objContent.m_strXiYiChuBu = txtxiyichubu.Text;
            objContent.m_strXiYiChuBuXML = txtxiyichubu.m_strGetXmlText();

            return objContent;
        }

        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsFirstIllnessNoteRecordContent_XJ objContent = (clsFirstIllnessNoteRecordContent_XJ)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现

            //m_txtMostlyContent.m_mthSetNewText(objContent.m_strMostlyContent, objContent.m_strMostlyContentXML);
            //m_txtOriginalDiagnose.m_mthSetNewText(objContent.m_strOriginalDiagnose, objContent.m_strOriginalDiagnoseXML);
            //m_txtDiagnoseThe.m_mthSetNewText(objContent.m_strDiagnoseDiffe, objContent.m_strDiagnoseDiffeXML);
            //m_txtCurePlan.m_mthSetNewText(objContent.m_strCurePlan, objContent.m_strCurePlanXML);
            txtbingliteidian.m_mthSetNewText(objContent.m_strBingLiTeDian, objContent.m_strBingLiTeDianXML );
            txtzhongyibianbingyiju.m_mthSetNewText(objContent.m_strZhongYiBianBing, objContent.m_strZhongYiBianBingXML);
            txtxiyizhenduanyiju.m_mthSetNewText(objContent.m_strXiYiZhenDuanYiJu, objContent.m_strXiYiZhenDuanYiJuXML);
            txtzhongyijianbiezhenduan.m_mthSetNewText(objContent.m_strZhongYiJianBie, objContent.m_strZhongYiJianBieXML);
            txtxiyijianbiezhenduan.m_mthSetNewText(objContent.m_strXiYiJianBie, objContent.m_strXiYiJianBieXML);
            txtzhongyichubu.m_mthSetNewText(objContent.m_strZhongYiChuBu, objContent.m_strZhongYiChuBuXML);
            txtxiyichubu.m_mthSetNewText(objContent.m_strXiYiChuBu, objContent.m_strXiYiChuBuXML);
            txtzhenliaojihua.m_mthSetNewText(objContent.m_strZhenLiaoJiHua, objContent.m_strZhenLiaoJiHuaXML);
            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName=="lsvSign")
                //    {
                //        ListViewItem lviNewItem=new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        lsvSign.Items.Add(lviNewItem);

                //    }
                //}
            }
            #endregion 签名

        }

        public override int m_IntFormID
        {
            get
            {
                return 201;
            }
        }


        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsFirstIllnessNoteRecordContent_XJ objContent = (clsFirstIllnessNoteRecordContent_XJ)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现

            //m_txtMostlyContent.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMostlyContent, objContent.m_strMostlyContentXML);
            //m_txtOriginalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOriginalDiagnose, objContent.m_strOriginalDiagnoseXML);
            //m_txtDiagnoseThe.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseDiffe, objContent.m_strDiagnoseDiffeXML);
            //m_txtCurePlan.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurePlan, objContent.m_strCurePlanXML);
            txtbingliteidian.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBingLiTeDian, objContent.m_strBingLiTeDianXML);
            txtzhongyibianbingyiju.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiBianBing, objContent.m_strZhongYiBianBingXML);
            txtxiyizhenduanyiju.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiZhenDuanYiJu, objContent.m_strXiYiZhenDuanYiJuXML);
            txtzhongyijianbiezhenduan.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiJianBie, objContent.m_strZhongYiJianBieXML);
            txtxiyijianbiezhenduan.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiJianBie, objContent.m_strXiYiJianBieXML);
            txtzhongyichubu.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiChuBu, objContent.m_strZhongYiChuBuXML);
            txtxiyichubu.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiChuBu, objContent.m_strXiYiChuBuXML);
            txtzhenliaojihua.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhenLiaoJiHua, objContent.m_strZhenLiaoJiHuaXML);

            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }
        }

        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.FirstIllnessNote_XJ);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsFirstIllnessNoteRecordContent_XJ objContent = (clsFirstIllnessNoteRecordContent_XJ)p_objRecordContent;
            //把表单值赋值到界面，由子窗体重载实现
            txtbingliteidian.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBingLiTeDian, objContent.m_strBingLiTeDianXML);
            txtzhongyibianbingyiju.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiBianBing, objContent.m_strZhongYiBianBingXML);
            txtxiyizhenduanyiju.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiZhenDuanYiJu, objContent.m_strXiYiZhenDuanYiJuXML);
            txtzhongyijianbiezhenduan.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiJianBie , objContent.m_strZhongYiJianBieXML);

            txtxiyijianbiezhenduan.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiJianBie, objContent.m_strXiYiJianBieXML);
            txtzhongyichubu.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiChuBu, objContent.m_strZhongYiChuBuXML);
            txtxiyichubu.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiChuBu, objContent.m_strXiYiChuBuXML);
            txtzhenliaojihua.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhenLiaoJiHua, objContent.m_strZhenLiaoJiHuaXML);

        }


        // 获取选择已经删除记录的窗体标题
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "首次病程记录";
        }

        /// <summary>
        /// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
        /// </summary>
        protected override void m_mthSelectRootNode()
        {

        }
            

        private void m_cmdClose_Click(object sender, System.EventArgs e)
        {            
            this.Close();
        }

        private void frmDiseaseSummary_Load(object sender, System.EventArgs e)
        {
            //			m_cmdNewTemplate.Visible = true;
            this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            this.m_dtpCreateDate.m_mthResetSize();

            //m_txtMostlyContent.Focus();
        }


        /// <summary>
        /// 数据复用
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
        {
        }

        protected override void m_mthSetDefaultValue(clsPatient p_objPatient)
        {
            //记录时间跟住院病历
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString());
            if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
            {
                m_dtpCreateDate.Value = DateTime.Parse(objInPatientCaseDefaultValue[0].m_strCreateDate);
                m_dtpCreateDate.Refresh();
            }

            //默认值
            new clsDefaultValueTool(this, p_objPatient).m_mthSetDefaultValue();
            //左上端空几格
            //m_txtMostlyContent.m_mthInsertText("    ", 0);

            //自动调用模板
            m_mthSetSpecialPatientTemplateSet(p_objPatient);

            if (m_blnHaveAssociateTemplate)
            {
                //				int intIndex1 = m_txtRecordContent.Text.IndexOf("鉴别诊断");
                //				int intIndex2 = m_txtRecordContent.Text.LastIndexOf("鉴别诊断");
                //				if(intIndex1 != -1 && intIndex2 > intIndex1)
                //					m_txtRecordContent.Text = m_txtRecordContent.Text.Remove(intIndex1,intIndex2 - intIndex1);
            }


            //			//记住关联了哪个手术名称
            //			string strTemplateSetID = m_objTemplateDomain.m_strGetPatientHaveDisease_TemplateSetID(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmLastInDate.ToString(),this.Name,(int)enmAssociate.Disease);
            //			m_txtRecordContent.Tag = m_objTemplateDomain.m_strGetAssociateIDBySetID(strTemplateSetID,(int)enmAssociate.Operation);
        }

        private void frmFirstIllnessNote_XJ_Load(object sender, EventArgs e)
        {
            //			m_cmdNewTemplate.Visible = true;
            this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            this.m_dtpCreateDate.m_mthResetSize();

            //m_txtMostlyContent.Focus();
        }

        private void cmdConfirm_Click(object sender, EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }







         

    }
}