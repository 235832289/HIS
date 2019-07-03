using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
using iCareData;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.controls;

namespace iCare
{
    /// <summary>
    /// 催产素静脉点滴观察表
    /// </summary>
    public partial class frmOXTIntravenousDripCon : frmDiseaseTrackBase
    {
        #region 全局变量
        /// <summary>
        /// 定义签名类
        /// </summary>
        private clsEmrSignToolCollection m_objSign = null;
        #endregion

        #region 构造函数

        /// <summary>
        /// 催产素静脉点滴观察表(编辑窗体)
        /// </summary>
        public frmOXTIntravenousDripCon()
        {
            InitializeComponent();

            //签名常用值

            m_dtpCreateDate.Enabled = true;

            m_objSign = new clsEmrSignToolCollection();
            //可以指定员工ID如

            m_objSign.m_mthBindEmployeeSign(m_cmdSign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_mthSetRichTextBoxAttribInControl(this);
            m_mthThisAddRichTextInfo(this);
        } 
        #endregion

        #region 事件
        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        } 
        #endregion

        #region 方法、属性


        #region 窗体ID
        public override int m_IntFormID
        {
            get
            {
                return 157;
            }
        }
        #endregion

        #region 窗体标题
        /// <summary>
        /// 窗体标题
        /// </summary>
        /// <returns></returns>
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现

            return "催产素静脉点滴观察表";
        }
        #endregion

        #region 获取护理记录的领域层实例
        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现

            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_OXTIntravenousDrip);
        }
        #endregion

        #region 把选择时间记录内容重新整理为完全正确的内容
        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。

            clsEMR_OXTIntravenousDripCon objContent = (clsEMR_OXTIntravenousDripCon)p_objRecordContent;
        }
        #endregion

        #region 从界面获取记录内容        


        /// <summary>
        /// 从界面获取记录内容
        /// </summary>
        /// <returns></returns>
        protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
        {

            //界面参数校验
            if (m_objCurrentPatient == null)// || this.txtInPatientID.Text != this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text == "")
                return null;

            //从界面获取表单值		
            clsEMR_OXTIntravenousDripCon objContent = new clsEMR_OXTIntravenousDripCon();
            try
            {
                string StrNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objContent.m_dtmCreateDate = Convert.ToDateTime(StrNow);
                objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_dtmModifyDate = Convert.ToDateTime(StrNow);
                objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_strRegisterID = frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

                objContent.m_dtmRecordDate = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                objContent.m_strOXTDENSITY = m_txtOXTDensity.Text;
                objContent.m_strOXTDENSITY_RIGHT = m_txtOXTDensity.m_strGetRightText();
                objContent.m_strOXTDENSITYXML = m_txtOXTDensity.m_strGetXmlText();

                objContent.m_strOXTDROPCOUNT = m_txtOXTDropCount.Text;
                objContent.m_strOXTDROPCOUNT_RIGHT = m_txtOXTDropCount.m_strGetRightText();
                objContent.m_strOXTDROPCOUNTXML = m_txtOXTDropCount.m_strGetXmlText();

                objContent.m_strUTERINECONTRACTION = m_txtUterineContraction.Text;
                objContent.m_strUTERINECONTRACTION_RIGHT = m_txtUterineContraction.m_strGetRightText();
                objContent.m_strUTERINECONTRACTIONXML = m_txtUterineContraction.m_strGetXmlText();

                objContent.m_strFETALHEART = m_txtFetalHeart.Text;
                objContent.m_strFETALHEART_RIGHT = m_txtFetalHeart.m_strGetRightText();
                objContent.m_strFETALHEARTXML = m_txtFetalHeart.m_strGetXmlText();

                objContent.m_strMETREURYNT = m_txtMetreurynt.Text;
                objContent.m_strMETREURYNT_RIGHT = m_txtMetreurynt.m_strGetRightText();
                objContent.m_strMETREURYNTXML = m_txtMetreurynt.m_strGetXmlText();

                objContent.m_strPRESENTATION = m_txtPresentation.Text;
                objContent.m_strPRESENTATION_RIGHT = m_txtPresentation.m_strGetRightText();
                objContent.m_strPRESENTATIONXML = m_txtPresentation.m_strGetXmlText();

                objContent.m_strBP_S = m_txtBP_S.Text;
                objContent.m_strBP_S_RIGHT = m_txtBP_S.m_strGetRightText();
                objContent.m_strBP_SXML = m_txtBP_S.m_strGetXmlText();

                objContent.m_strBP_A = m_txtBP_A.Text;
                objContent.m_strBP_A_RIGHT = m_txtBP_A.m_strGetRightText();
                objContent.m_strBP_AXML = m_txtBP_A.m_strGetXmlText();

                objContent.m_strSPECIALINFO = m_txtSpecialInfo.Text;
                objContent.m_strSPECIALINFO_RIGHT = m_txtSpecialInfo.m_strGetRightText();
                objContent.m_strSPECIALINFOXML = m_txtSpecialInfo.m_strGetXmlText();
                #region 获取签名
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
                //objContent.objSignerArr = null;
                //string strRecorderIDList = string.Empty;
                //if (lsvSign.Items.Count > 0)
                //{
                //    objContent.objSignerArr = new clsEmrSigns_VO[lsvSign.Items.Count];
                //    for (int j = 0; j < lsvSign.Items.Count; j++)
                //    {
                //        objContent.objSignerArr[j] = new clsEmrSigns_VO();
                //        objContent.objSignerArr[j].objEmployee = new clsEmrEmployeeBase_VO();
                //        objContent.objSignerArr[j].objEmployee = (clsEmrEmployeeBase_VO)(lsvSign.Items[j].Tag);
                //        objContent.objSignerArr[j].controlName = "lsvSign";
                //        objContent.objSignerArr[j].m_strFORMID_VCHR = "frmOXTIntravenousDripCon";//注意大小写


                //        objContent.objSignerArr[j].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

                //        if (j < lsvSign.Items.Count - 1)
                //        {
                //            strRecorderIDList += objContent.objSignerArr[j].objEmployee.m_strEMPID_CHR + ",";
                //        }
                //        else
                //        {
                //            strRecorderIDList += objContent.objSignerArr[j].objEmployee.m_strEMPID_CHR;
                //        }
                //    }
                //}
                objContent.m_strRecordUserID = strUserIDList;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return objContent;
        }
        #endregion

        #region 显示已删除记录至界面
        /// <summary>
        /// 显示已删除记录至界面
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsEMR_OXTIntravenousDripCon objContent = p_objContent as clsEMR_OXTIntravenousDripCon;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            m_txtOXTDensity.Text = objContent.m_strOXTDENSITY_RIGHT;
            m_txtOXTDropCount.Text = objContent.m_strOXTDROPCOUNT_RIGHT;
            m_txtUterineContraction.Text = objContent.m_strUTERINECONTRACTION_RIGHT;
            m_txtFetalHeart.Text = objContent.m_strFETALHEART;
            m_txtMetreurynt.Text = objContent.m_strMETREURYNT_RIGHT;
            m_txtPresentation.Text = objContent.m_strPRESENTATION_RIGHT;
            m_txtBP_S.Text = objContent.m_strBP_S_RIGHT;
            m_txtBP_A.Text = objContent.m_strBP_A_RIGHT;
            m_txtSpecialInfo.Text = objContent.m_strSPECIALINFO_RIGHT;

            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName == "lsvSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用


                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objContent.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样


                //        lsvSign.Items.Add(lviNewItem);

                //    }
                //}
            }
            #endregion 签名

            this.lsvSign.Enabled = false;
            this.m_cmdSign.Enabled = false;
           // this.m_dtpCreateDate.Enabled = false;
            this.m_dtpCreateDate.Enabled = true;  
        }
        #endregion

        #region 把特殊记录的值显示到界面上


        /// <summary>
        /// 把特殊记录的值显示到界面上。     
        /// </summary>
        /// <param name="p_objContent">VO</param>
        protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsEMR_OXTIntravenousDripCon objContent = p_objContent as clsEMR_OXTIntravenousDripCon;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            m_txtOXTDensity.m_mthSetNewText(objContent.m_strOXTDENSITY, objContent.m_strOXTDENSITYXML);
            m_txtOXTDropCount.m_mthSetNewText(objContent.m_strOXTDROPCOUNT, objContent.m_strOXTDROPCOUNTXML);
            m_txtUterineContraction.m_mthSetNewText(objContent.m_strUTERINECONTRACTION, objContent.m_strUTERINECONTRACTIONXML);
            m_txtFetalHeart.m_mthSetNewText(objContent.m_strFETALHEART, objContent.m_strFETALHEARTXML);
            m_txtMetreurynt.m_mthSetNewText(objContent.m_strMETREURYNT, objContent.m_strMETREURYNTXML);
            m_txtPresentation.m_mthSetNewText(objContent.m_strPRESENTATION, objContent.m_strPRESENTATIONXML);
            m_txtBP_S.m_mthSetNewText(objContent.m_strBP_S, objContent.m_strBP_SXML);
            m_txtBP_A.m_mthSetNewText(objContent.m_strBP_A, objContent.m_strBP_AXML);
            m_txtSpecialInfo.m_mthSetNewText(objContent.m_strSPECIALINFO, objContent.m_strSPECIALINFOXML);

            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName == "lsvSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用                
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objContent.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        lsvSign.Items.Add(lviNewItem);

                //    }
                //}
            }
            #endregion 签名

            this.lsvSign.Enabled = false;
            this.m_cmdSign.Enabled = false;
           // this.m_dtpCreateDate.Enabled = false;
            m_dtpCreateDate.Enabled = true;
        }
        #endregion

        #region 控制是否可以选择病人和记录时间列表

        /// <summary>
        /// 控制是否可以选择病人和记录时间列表。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
        {
            if (p_blnEnable == false)
            {

                m_cmdOK.Visible = true;

                this.CenterToParent();
            }

            this.MaximizeBox = false;
        }
        #endregion

        #region 具体记录的特殊控制(不实现)
        /// <summary>
        /// 具体记录的特殊控制,根据子窗体的需要重载实现
        /// </summary>
        /// <param name="p_blnEnable">是否允许修改特殊记录的记录信息。</param>
        protected override void m_mthEnableModifySub(bool p_blnEnable)
        {
          //  m_dtpCreateDate.Enabled = true;
        }
        #endregion

        #region 设置是否控制修改(不实现)
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

         //   m_dtpCreateDate.Enabled = true;


        }
        #endregion

        #region 获取记录单传递信息内容

        /// <summary>
        /// 获取记录单传递信息内容
        /// </summary>
        /// <returns></returns>
        public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsIntensiveRecordInfo objTrackInfo = new clsIntensiveRecordInfo();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = this.m_lblForTitle.Text;

            //设置m_dtmRecordTime
            if (objTrackInfo.m_ObjRecordContent != null)
            {
                m_dtpCreateDate.Value = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
            }
            return objTrackInfo;
        }
        #endregion

        #region 清空特殊记录信息
        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

            m_dtpCreateDate.Value = DateTime.Now;

            m_txtOXTDensity.m_mthClearText();
            m_txtOXTDropCount.m_mthClearText();
            m_txtUterineContraction.m_mthClearText();
            m_txtFetalHeart.m_mthClearText();
            m_txtMetreurynt.m_mthClearText();
            m_txtPresentation.m_mthClearText();
            m_txtBP_S.m_mthClearText();
            m_txtBP_A.m_mthClearText();
            m_txtSpecialInfo.m_mthClearText();
        }
        #endregion

        #region Jump Control
        /// <summary>
        /// 控制跳转控制
        /// </summary>
        /// <param name="p_objJump"></param>
        protected override void m_mthInitJump(clsJumpControl p_objJump)
        {
            p_objJump = new clsJumpControl(this,
                new Control[] { m_txtOXTDensity, m_txtOXTDropCount, m_txtUterineContraction, m_txtFetalHeart, m_txtMetreurynt ,
                m_txtPresentation,m_txtBP_S,m_txtBP_A,m_txtSpecialInfo}, Keys.Enter);
        }
        #endregion

        #region 获取记录
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        public override clsTrackRecordContent m_objGetRecordContent(clsPatient p_objSelectedPatient, string p_strOpenDate)
        {
            clsTrackRecordContent objContent;
            //获取记录
            m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrRegisterId, p_strOpenDate, out objContent);
            return objContent;
        }
        #endregion
        #endregion
    }
}