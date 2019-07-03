using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.Emr.Signature_gui;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;


namespace iCare
{
	/// <summary>
	/// （阶段小结---新疆）病程记录子窗体的实现,SGH-2008-1-21
	/// </summary>
    public partial class frmDiseaseSummary_XJ : iCare.frmDiseaseTrackBase
	{
        private clsEmployeeSignTool m_objSignTool;

        //定义签名类
        private clsEmrSignToolCollection m_objSign;

        public frmDiseaseSummary_XJ()
        {
            InitializeComponent();

            //指明医生工作站表单
            intFormType = 1;
            //			m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee_New);
            //			m_objSignTool.m_mthAddControl(m_txtSign);

            cmdConfirm.Visible = false;

            m_mthSetRichTextBoxAttribInControl(this);

            this.Text = "阶段小结";
            lblCreateDateTitle.Text = "接班时间:";
            this.m_lblForTitle.Text = this.Text;
            if (m_trnRoot != null)
                m_trnRoot.Text = "接班时间";

            //			m_lblSign.Text=MDIParent.OperatorName;	


            //			//签名常用值
            //			m_objCUTC = new clsCommonUseToolCollection(this);
            //			m_objCUTC.m_mthBindEmployeeSign(new Control[]{this.m_cmdEmployeeSign },
            //				new Control[]{this.m_txtSign },new int[]{1});

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

        }


        public override int m_IntFormID
        {
            get
            {
                return 207;
            }
        }

        /// <summary>
        /// 获取当前的特殊病程记录信息
        /// </summary>
        /// <returns></returns>
        public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsDiseaseSummaryInfo_XJ objTrackInfo = new clsDiseaseSummaryInfo_XJ(m_objCurrentPatient);

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = "阶段小结";

            //设置m_strTitle和m_dtmRecordTime
            if (objTrackInfo.m_ObjRecordContent != null)
            {
                m_dtpCreateDate.Value = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
            }
            return objTrackInfo;
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(lsvSign);


            //清空具体记录内容			
            txtruyuanqingkuang.m_mthClearText();
            txtzhongyiruyuan.m_mthClearText();
            txtxiyiruyuan.m_mthClearText();
            txtzhenliaojingguo.m_mthClearText();
            txtmuqianqingkuang.m_mthClearText();
            txtzhongyimuqian.m_mthClearText();
            txtxiyimuqian.m_mthClearText();
            txtzhuyishixiang.m_mthClearText();
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

                //lblCreateDateTitle.Left=lblOriginalDiagnoseTitle.Left;//=16;
                //lblCreateDateTitle.Top=15;	
                //m_dtpCreateDate.Left=lblCreateDateTitle.Right+5;
                //m_dtpCreateDate.Top=lblCreateDateTitle.Top;				
            }
            //this.MaximizeBox=false;
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
            clsDiseaseSummaryRecordContent_XJ objContent = new clsDiseaseSummaryRecordContent_XJ();
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
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmHandOver";//注意大小写
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

            objContent.m_strRuYuanQingKuang_Right = txtruyuanqingkuang.m_strGetRightText();
            objContent.m_strRuYuanQingKuang = txtruyuanqingkuang.Text;
            objContent.m_strRuYuanQingKuangXML = txtruyuanqingkuang.m_strGetXmlText();

            objContent.m_strZhongYiRuYuan_Right = txtzhongyiruyuan.m_strGetRightText();
            objContent.m_strZhongYiRuYuan = txtzhongyiruyuan.Text;
            objContent.m_strZhongYiRuYuanXML = txtzhongyiruyuan.m_strGetXmlText();

            objContent.m_strXiYiRuYuan_Right = txtxiyiruyuan.m_strGetRightText();
            objContent.m_strXiYiRuYuan = txtxiyiruyuan.Text;
            objContent.m_strXiYiRuYuanXML = txtxiyiruyuan.m_strGetXmlText();

            objContent.m_strZhenLiaoJingGuo_Right = txtzhenliaojingguo.m_strGetRightText();
            objContent.m_strZhenLiaoJingGuo = txtzhenliaojingguo.Text;
            objContent.m_strZhenLiaoJingGuoXML = txtzhenliaojingguo.m_strGetXmlText();

            objContent.m_strMuQianQingKuang_Right = txtmuqianqingkuang.m_strGetRightText();
            objContent.m_strMuQianQingKuang = txtmuqianqingkuang.Text;
            objContent.m_strMuQianQingKuangXML = txtmuqianqingkuang.m_strGetXmlText();

            objContent.m_strZhongYiMuQian_Right = txtzhongyimuqian.m_strGetRightText();
            objContent.m_strZhongYiMuQian = txtzhongyimuqian.Text;
            objContent.m_strZhongYiMuQianXML = txtzhongyimuqian.m_strGetXmlText();

            objContent.m_strXiYiMuQian_Right = txtxiyimuqian.m_strGetRightText();
            objContent.m_strXiYiMuQian = txtxiyimuqian.Text;
            objContent.m_strXiYiMuQianXML = txtxiyimuqian.m_strGetXmlText();

            objContent.m_strZhenLiaoJiHua_Right = txtzhuyishixiang.m_strGetRightText();
            objContent.m_strZhenLiaoJiHua = txtzhuyishixiang.Text;
            objContent.m_strZhenLiaoJiHuaXML = txtzhuyishixiang.m_strGetXmlText();
            
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
            clsDiseaseSummaryRecordContent_XJ objContent = (clsDiseaseSummaryRecordContent_XJ)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            txtruyuanqingkuang.m_mthSetNewText(objContent.m_strRuYuanQingKuang, objContent.m_strRuYuanQingKuangXML);
            txtzhongyiruyuan.m_mthSetNewText(objContent.m_strZhongYiRuYuan, objContent.m_strZhongYiRuYuanXML);
            txtxiyiruyuan.m_mthSetNewText(objContent.m_strXiYiRuYuan, objContent.m_strXiYiRuYuanXML);

            txtzhenliaojingguo.m_mthSetNewText(objContent.m_strZhenLiaoJingGuo, objContent.m_strZhenLiaoJingGuoXML);
            txtmuqianqingkuang.m_mthSetNewText(objContent.m_strMuQianQingKuang, objContent.m_strMuQianQingKuangXML);
            txtzhongyimuqian.m_mthSetNewText(objContent.m_strZhongYiMuQian, objContent.m_strZhongYiMuQianXML);
            txtxiyimuqian.m_mthSetNewText(objContent.m_strXiYiMuQian, objContent.m_strXiYiMuQianXML);
            txtzhuyishixiang.m_mthSetNewText(objContent.m_strZhenLiaoJiHua, objContent.m_strZhenLiaoJiHuaXML);
           // m_txtReferral.m_mthSetNewText(objContent.m_strReferral, objContent.m_strReferralXML);


            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName=="lsvSign")
                //    {
                //        ListViewItem lviNewItem=new 						 ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
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


            #region 入院原因(主诉)
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
            {
                m_lblInHospitalReason.Text = objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
            }
            #endregion 入院原因(主诉)
        }


        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsDiseaseSummaryRecordContent_XJ objContent = (clsDiseaseSummaryRecordContent_XJ)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            txtruyuanqingkuang.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strRuYuanQingKuang, objContent.m_strRuYuanQingKuangXML);
            txtzhongyiruyuan.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiRuYuan, objContent.m_strZhongYiRuYuanXML);
            txtxiyiruyuan.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiRuYuan, objContent.m_strXiYiRuYuanXML);            
            txtzhenliaojingguo.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhenLiaoJingGuo, objContent.m_strZhenLiaoJingGuoXML);

            txtmuqianqingkuang.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMuQianQingKuang, objContent.m_strMuQianQingKuangXML);
            txtzhongyimuqian.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiMuQian, objContent.m_strZhongYiMuQianXML);
            txtxiyimuqian.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiMuQian, objContent.m_strXiYiMuQianXML);
            txtzhuyishixiang.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhenLiaoJiHua, objContent.m_strZhenLiaoJiHuaXML);
            //txtzhenliaojingguo.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhenLiaoJingGuo, objContent.m_strZhenLiaoJingGuoXML);


            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }

            #region 入院原因(主诉)
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
            {
                m_lblInHospitalReason.Text = objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
            }
            #endregion 入院原因(主诉)
        }

        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.DiseaseSummary_XJ);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsDiseaseSummaryRecordContent_XJ objContent = (clsDiseaseSummaryRecordContent_XJ)p_objRecordContent;
            //把表单值赋值到界面，由子窗体重载实现
            txtruyuanqingkuang.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strRuYuanQingKuang, objContent.m_strRuYuanQingKuangXML);
            txtzhongyiruyuan.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiRuYuan, objContent.m_strZhongYiRuYuanXML);
            txtxiyiruyuan.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiRuYuan, objContent.m_strXiYiRuYuanXML);
            txtzhenliaojingguo.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhenLiaoJingGuo, objContent.m_strZhenLiaoJingGuoXML);

            txtmuqianqingkuang.Text =  com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMuQianQingKuang, objContent.m_strMuQianQingKuangXML);
            txtzhongyimuqian.Text =  com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhongYiMuQian, objContent.m_strZhongYiMuQianXML);
            txtxiyimuqian.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXiYiMuQian, objContent.m_strXiYiMuQianXML);
            txtzhuyishixiang.Text = com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhenLiaoJiHua, objContent.m_strZhenLiaoJiHuaXML);
        }

        #region 打印(在子弹出窗体中不需要提供实现)
        /// <summary>
        ///  设置打印内容。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetPrintContent(clsTrackRecordContent p_objContent, DateTime p_dtmFirstPrintDate)
        {
            //缺省不做任何动作，子窗体重载以提供操作。
        }

        /// <summary>
        /// 初始化打印变量
        /// </summary>
        protected override void m_mthInitPrintTool()
        {
            //缺省不做任何动作，子窗体重载以提供操作
            //初始化内容包括所有打印使用到的变量：字体、画笔、画刷、打印类等。
        }

        /// <summary>
        /// 释放打印变量
        /// </summary>
        protected override void m_mthDisposePrintTools()
        {
            //缺省不做任何动作，子窗体重载以提供操作
            //释放内容包括打印使用到的字体、画笔、画刷等使用系统资源的变量。
        }

        /// <summary>
        /// 开始打印。
        /// </summary>
        protected override void m_mthStartPrint()
        {
            //缺省使用打印预览，子窗体重载提供新的实现
            if (m_blnDirectPrint)
            {
                m_pdcPrintDocument.Print();
            }
            else
            {
                PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog();
            }
        }

        /// <summary>
        /// 打印开始后，在打印页之前的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        protected override void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {
            //缺省不做任何动作，子窗体重载以提供操作
        }

        /// <summary>
        /// 打印页
        /// </summary>
        /// <param name="p_objPrintPageArg"></param>
        protected override void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {

        }

        /// <summary>
        /// 打印结束时的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        protected override void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            //由子窗体重载以提供操作
        }
        #endregion 打印

        // 获取选择已经删除记录的窗体标题
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "阶段小结";
        }

        /// <summary>
        /// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
        /// </summary>
        protected override void m_mthSelectRootNode()
        {
            #region 初步诊断默认值
            if (m_objCurrentPatient != null && m_ObjLastEmrPatientSession != null)
            {
                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
                {
                    //m_txtOriginalDiagnose.Text = objInPatientCaseHisoryDefaultValueArr[0].m_strPrimaryDiagnose;
                }
            }
            #endregion 初步诊断默认值
        }

        private void cmdConfirm_Click(object sender, System.EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

     

        private void m_cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 数据复用
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
        {
            //			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmLastInDate.ToString());
            //			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
            //			{
            //				this.m_txtOriginalDiagnose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
            //				this.m_txtCurrentDiagnose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
            //			}
        }

        //private void frmHandOver_XJ_Load(object sender, EventArgs e)
        //{
        //    if (m_objCurrentPatient != null && m_ObjLastEmrPatientSession != null)
        //    {
        //        m_lblInHospitalDate.Text = m_ObjLastEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy年MM月dd日 HH:mm");
        //        #region 入院原因(主诉)
        //        clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
        //        if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
        //        {
        //            m_lblInHospitalReason.Text = objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
        //        }
        //        #endregion 入院原因(主诉)
        //    }

        //    this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
        //    this.m_dtpCreateDate.m_mthResetSize();

        //    txtruyuanqingkuang.Focus();
        //}

        private void frmDiseaseSummary_XJ_Load(object sender, EventArgs e)
        {
            if (m_objCurrentPatient != null && m_ObjLastEmrPatientSession != null)
            {
                m_lblInHospitalDate.Text = m_ObjLastEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy年MM月dd日 HH:mm");
                #region 入院原因(主诉)
                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
                {
                    m_lblInHospitalReason.Text = objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
                }
                #endregion 入院原因(主诉)
            }

            this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            this.m_dtpCreateDate.m_mthResetSize();

            txtruyuanqingkuang.Focus();
        }
        

    }
}