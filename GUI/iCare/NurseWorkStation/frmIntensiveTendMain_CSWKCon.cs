using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.clsGeneralNurseRecord_CSService;
using com.digitalwave.Utility.Controls;
using iCare.iCareBaseForm;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.clsGeneralNurseRecordWK_CSService;
using com.digitalwave.clsIntensiveTendMain_CSWKService;

namespace iCare
{
    /// <summary>
    ///危重患者护理记录单/病程记录（茶山,外科）
    /// </summary>
    public partial class frmIntensiveTendMain_CSWKCon : iCare.frmDiseaseTrackBase
    {
        private string m_strRegisterid = string.Empty;
        private bool blnNewRecord;
        private string strRecordInPatientID;
        private string strRecordInPatientDate;
        private string strRecordCreateDate;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        public frmIntensiveTendMain_CSWKCon()
        {
            InitializeComponent(); 
        }
        public frmIntensiveTendMain_CSWKCon(bool blnNew, string p_strInPatientID, string p_strInPatientDate, string p_strCreateDate)
            : this()
        {
            blnNewRecord = blnNew;
            strRecordInPatientID = p_strInPatientID;
            strRecordInPatientDate = p_strInPatientDate;
            strRecordCreateDate = p_strCreateDate;
            m_mthSetRichTextBoxAttribInControl(this);
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmbsign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
        }
        public string m_strSetRegisterId
        {
            set { m_strRegisterid = value; }
        }
        public override int m_IntFormID
        {
            get
            {
                return 104;
            }
        }

        #region 方法
        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.IntensiveTendMain_CSWK);
        }
        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //清空记录内容			
            m_txtRecordContent.m_mthClearText();
            m_dtpCreateDate.Value = DateTime.Now;
            lsvSign.Items.Clear();
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(lsvSign);
            m_cmdModifyPatientInfo.Visible = false;
            m_mthSetModifyControl(null, true);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private new long m_lngSave()
        {
            long lngRes = 0;
            try
            {
                //获取服务器时间
                string strTimeNow = new clsPublicDomain().m_strGetServerTime();
                //从界面获取表单值		
                clsGeneralNurseRecordContent_CSDetail objContent = new clsGeneralNurseRecordContent_CSDetail();
                objContent.m_strINPATIENTID = strRecordInPatientID;
                objContent.m_dtmINPATIENTDATE = DateTime.Parse(strRecordInPatientDate);
                objContent.m_dtmOPENDATE = DateTime.Parse(strTimeNow);
                objContent.m_dtmMODIFYDATE = DateTime.Parse(strTimeNow);
                objContent.m_dtmRECORDDATE = DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                objContent.m_dtmCREATERECORDDATE = DateTime.Parse(strTimeNow);
                objContent.m_strRECORDCONTENTAll = m_txtRecordContent.Text;
                objContent.m_strRECORDCONTENT_RIGHT = m_txtRecordContent.m_strGetRightText();
                objContent.m_strRECORDCONTENTXML = m_txtRecordContent.m_strGetXmlText();

                if (objContent.m_strRECORDCONTENT_RIGHT == null || objContent.m_strRECORDCONTENT_RIGHT == string.Empty)
                {
                    MDIParent.ShowInformationMessageBox("请填写病情记录内容");
                    return 0;
                }
                //获取签名
                objContent.m_strMODIFYRECORDUSERID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
                objContent.m_strCREATERECORDUSERID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);

              clsIntensiveTendMain_CSWKService objserv =
                    (clsIntensiveTendMain_CSWKService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendMain_CSWKService));

                #region 多签名时验证所有签名者
                //数字签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strINPATIENTID.Trim() + "-" + objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_strRegisterid;
                if (objContent.objSignerArr != null)
                {
                    ArrayList objSignerArr = new ArrayList();
                    for (int i = 0; i < objContent.objSignerArr.Length; i++)
                    {
                        if (objContent.objSignerArr[i].controlName == "lsvSign" || objContent.objSignerArr[i].controlName == "txtSign")
                            objSignerArr.Add(objContent.objSignerArr[i].objEmployee);
                    }
                    clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                    if (objCheck.CheckSigner(objContent, objSign_VO) == -1)
                        return -1;
                }
                else
                {
                    objContent.m_strModifyUserID = MDIParent.OperatorID;
                    clsCheckSignersController objCheck = new clsCheckSignersController();
                    if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                        return -1;
                }
                #endregion

                lngRes = objserv.m_lngAddNewDetail(objContent);
            }
            catch (Exception ex)
            {
                new com.digitalwave.Utility.clsLogText().LogDetailError(ex, false);
            }
            return lngRes;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        private long m_lngModify()
        {
            long lngRes = 0;
            try
            {
                //从界面获取表单值
                string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                clsGeneralNurseRecordContent_CSDetail objContent = new clsGeneralNurseRecordContent_CSDetail();
                objContent.m_strINPATIENTID = strRecordInPatientID;
                objContent.m_dtmINPATIENTDATE = DateTime.Parse(strRecordInPatientDate);
                objContent.m_dtmMODIFYDATE = DateTime.Parse(strNow);
                objContent.m_dtmRECORDDATE = m_dtpCreateDate.Value;
                objContent.m_dtmCREATERECORDDATE = DateTime.Parse(strRecordCreateDate);
                objContent.m_strRECORDCONTENTAll = m_txtRecordContent.Text;
                objContent.m_strRECORDCONTENT_RIGHT = m_txtRecordContent.m_strGetRightText();
                objContent.m_strRECORDCONTENTXML = m_txtRecordContent.m_strGetXmlText();
                objContent.m_dtmOPENDATE = DateTime.Parse(strNow);

                if (objContent.m_strRECORDCONTENT_RIGHT == null || objContent.m_strRECORDCONTENT_RIGHT == string.Empty)
                {
                    MDIParent.ShowInformationMessageBox("请填写病情观察、护理措施、效果的内容");
                    return 0;
                }

                //获取签名
                if (lsvSign.Items.Count > 0)
                {
                    objContent.m_strRecordSignNameArr = new string[lsvSign.Items.Count];
                    objContent.m_strRecordSignIDArr = new string[lsvSign.Items.Count];
                    for (int i = 0; i < lsvSign.Items.Count; i++)
                    {
                        objContent.m_strRecordSignNameArr[i] = lsvSign.Items[i].SubItems[0].Text;
                        objContent.m_strRecordSignIDArr[i] = lsvSign.Items[i].SubItems[1].Text;
                    }
                }
                //获取签名
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
                /*
                objContent.m_strMODIFYRECORDUSERID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                objContent.objSignerArr = new clsEmrSigns_VO[1];
                objContent.objSignerArr[0] = new clsEmrSigns_VO();
                objContent.objSignerArr[0].objEmployee = new clsEmrEmployeeBase_VO();
                objContent.objSignerArr[0].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
                objContent.objSignerArr[0].controlName = "txtSign";
                objContent.objSignerArr[0].m_strFORMID_VCHR = "frmGeneralNurseRecord_CSCon";//注意大小写
                objContent.objSignerArr[0].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
                */
                clsIntensiveTendMain_CSWKService objserv =
                    (clsIntensiveTendMain_CSWKService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendMain_CSWKService));

                #region 多签名时验证所有签名者
                //电子签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strINPATIENTID.Trim() + "-" + objContent.m_dtmINPATIENTDATE.ToString("yyyy-MM-dd HH:mm:ss");
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_strRegisterid;
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                    return -1;

                #endregion

                lngRes = objserv.m_lngModifyDetail(objContent);
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
            return lngRes;
        }
        /// <summary>
        /// 获取
        /// </summary>
        private void m_GetDataFromDB()
        {
            long lngRes = 0;
            try
            {
                clsGeneralNurseRecordContent_CSDetail objDetail = null;
                clsIntensiveTendMain_CSWKService objserv =
                    (clsIntensiveTendMain_CSWKService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendMain_CSWKService));

                lngRes = objserv.m_lngGetRecordContent(strRecordInPatientID, strRecordInPatientDate, strRecordCreateDate, out objDetail);
                //objserv.Dispose();
                if (objDetail == null)
                    return;
                //赋值到表单
                m_txtRecordContent.m_mthSetNewText(objDetail.m_strRECORDCONTENTAll, objDetail.m_strRECORDCONTENTXML);
                m_dtpCreateDate.Value = objDetail.m_dtmRECORDDATE;
                m_mthAddSignToListView(lsvSign, objDetail.objSignerArr);
                //if (objDetail.m_strRecordSignIDArr != null)
                //{
                //    for (int i = 0; i < objDetail.m_strRecordSignIDArr.Length; i++)
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(new string[] { objDetail.m_strRecordSignNameArr[i], objDetail.m_strRecordSignIDArr[i] });
                //        lsvSign.Items.Add(lviNewItem);
                //    }
                //}
                m_mthSetModifyControl(objDetail.m_strCREATERECORDUSERID, false);
                this.m_dtpCreateDate.Enabled = false;
                m_cmdModifyPatientInfo.Visible = false;
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }

        #endregion ;

        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdOK_Click(object sender, System.EventArgs e)
        {
            if (blnNewRecord)
            {
                if (this.m_lngSave() > 0)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }

            }
            else
            {
                if (m_lngModify() > 0)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }

        }
        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        /// <summary>
        /// 设置窗体中控件输入文本的颜色
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_clrColor"></param>
        private void m_mthSetRichTextModifyColor(Control p_ctlControl, System.Drawing.Color p_clrColor)
        {
            #region 设置控件输入文本的颜色,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;

            if (p_ctlControl.HasChildren && strTypeName != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextModifyColor(subcontrol, p_clrColor);
                }
            }
            #endregion
        }


        private void m_mthSetRichTextCanModifyLast(Control p_ctlControl, bool p_blnCanModifyLast)
        {
            #region 设置控件输入文本的是否最后修改,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
            {
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
            }

            if (p_ctlControl.HasChildren && strTypeName != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextCanModifyLast(subcontrol, p_blnCanModifyLast);
                }
            }
            #endregion
        }
        private void frmIntensiveTendMain_CSWKCon_Load(object sender, System.EventArgs e)
        {

            if (blnNewRecord)
            {
                //初始化
                m_mthClearRecordInfo();
                //左上端空几格
                m_txtRecordContent.m_mthInsertText("    ", 0);
            }
            else
                m_GetDataFromDB();
        }

        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset"></param>
        protected void m_mthSetModifyControl(string p_strModifyUserID,
            bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制，由子窗体重载实现
            if (p_strModifyUserID != null)
            {
                m_mthSetRichTextModifyColor(this, Color.Red);
                m_mthSetRichTextCanModifyLast(this, m_blnGetCanModifyLast(p_strModifyUserID));
            }
        }

        private bool m_blnGetCanModifyLast(string p_strModifyUserID)
        {
            if (p_strModifyUserID != null && p_strModifyUserID.Trim() == clsEMRLogin.LoginEmployee.m_strEMPID_CHR)
                return true;
            else
                return false;
        }

        #region OverRide Function

        protected override bool m_BlnCanTextChanged
        {
            get
            {
                return true;
            }
        }

        protected override enmFormState m_EnmCurrentFormState
        {
            get
            {
                return enmFormState.NowUser;
            }
        }


        protected override long m_lngSubAddNew()
        {
            return (long)enmOperationResult.DB_Succeed;
        }

        protected override bool m_BlnIsAddNew
        {
            get
            {
                return false;
            }
        }

        protected override long m_lngSubModify()
        {
            return (long)enmOperationResult.DB_Succeed;
        }
        protected override long m_lngSubDelete()
        {
            return (long)enmOperationResult.DB_Succeed;
        }
        #endregion

        protected override void m_mthSetSelectedDeletedRecord(clsPatient p_objSelectedPatient,
            string p_strOpenDate)
        {
            //检查参数
            if (p_objSelectedPatient == null || p_strOpenDate == null || p_strOpenDate == "")
                return;

            clsGeneralNurseRecordContent_CSDetail objContent;

            clsIntensiveTendMain_CSWKService objITRServ =
                (clsIntensiveTendMain_CSWKService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendMain_CSWKService));

            //获取记录
            long lngRes = objITRServ.m_lngGetDelRecordContentWithInpatient(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_strOpenDate, out objContent);
            //objITRServ.Dispose();
            if (lngRes <= 0 || objContent == null)
                return;


            //设置当前记录及记录时间 
            m_objCurrentPatient = p_objSelectedPatient;
            txtInPatientID.Text = this.m_objCurrentPatient.m_StrHISInPatientID;

            m_mthSetDeletedGUIFromContent(objContent);

        }

        protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsGeneralNurseRecordContent_CSDetail objContent = (clsGeneralNurseRecordContent_CSDetail)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现			

            this.m_mthClearRecordInfo();
            //赋值到表单
            m_txtRecordContent.m_mthSetNewText(objContent.m_strRECORDCONTENTAll, objContent.m_strRECORDCONTENTXML);
            m_dtpCreateDate.Value = objContent.m_dtmCREATERECORDDATE;
            //m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] {objContent.m_strCREATERECORDUSERID }, new bool[] { false });
            if (objContent.m_strRecordSignIDArr != null)
            {
                for (int i = 0; i < objContent.m_strRecordSignIDArr.Length; i++)
                {
                    ListViewItem lviNewItem = new ListViewItem(new string[] { objContent.m_strRecordSignNameArr[i], objContent.m_strRecordSignIDArr[i] });
                    lsvSign.Items.Add(lviNewItem);
                }
            }
            this.m_dtpCreateDate.Enabled = false;
            m_cmdModifyPatientInfo.Visible = false;
        }


    }
}

