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
    /// 产程记录(编辑窗体)
    /// </summary>
    public partial class frmWaitLayRecord_AcadCon_GX : frmDiseaseTrackBase
    {
        #region 全局变量
        /// <summary>
        /// 定义签名类
        /// </summary>
        private clsEmrSignToolCollection m_objSign = null; 
        #endregion

        #region 构造函数



        /// <summary>
        /// 产程记录
        /// </summary>
        public frmWaitLayRecord_AcadCon_GX()
        {
            InitializeComponent();

            //签名常用值



            m_objSign = new clsEmrSignToolCollection();
            //可以指定员工ID如



            m_objSign.m_mthBindEmployeeSign(m_cmdSign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_mthSetRichTextBoxAttribInControl(this);
        }

        /// <summary>
        /// 产程记录
        /// </summary>
        /// <param name="p_strLayTimes">孕/产次</param>
        /// <param name="p_strLayDate">预产期</param>
        public frmWaitLayRecord_AcadCon_GX(string p_strLayTimes, string p_strLayDate)
            : this()
        {
            this.m_lblLayTimes.Text = p_strLayTimes;
            this.m_lblLayDate.Text = p_strLayDate;

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
                return 156;
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

            return "产程记录";
        } 
        #endregion

        #region 获取护理记录的领域层实例
        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现



            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_WAITLAYRECORD_GX);
        } 
        #endregion

        #region 把选择时间记录内容重新整理为完全正确的内容
        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现


            clsEMR_WAITLAYRECORD_GX objContent = (clsEMR_WAITLAYRECORD_GX)p_objRecordContent;
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
            clsEMR_WAITLAYRECORD_GX objContent = new clsEMR_WAITLAYRECORD_GX();
            try
            {
                string StrNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objContent.m_dtmCreateDate = Convert.ToDateTime(StrNow);
                objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_dtmModifyDate = Convert.ToDateTime(StrNow);
                objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_strRegisterID = frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

                objContent.m_strLAYCOUNT_CHR = m_lblLayTimes.Text;
                DateTime dtmTemp = DateTime.MinValue;
                if (DateTime.TryParse(m_lblLayDate.Text,out dtmTemp))
                    objContent.m_dtmBEFOREHAND = dtmTemp;
                else
                    objContent.m_dtmBEFOREHAND = DateTime.MinValue;

                objContent.m_dtmRecordDate = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                objContent.m_strBLOODPRESSURE_S_CHR = m_txtBloodPressure_chr1.Text;
                objContent.m_strBLOODPRESSURE_S_CHR_RIGHT = m_txtBloodPressure_chr1.m_strGetRightText();
                objContent.m_strBLOODPRESSURE_S_CHRXML = m_txtBloodPressure_chr1.m_strGetXmlText();

                objContent.m_strBLOODPRESSURE_A_CHR = m_txtBloodPressure_chr2.Text;
                objContent.m_strBLOODPRESSURE_A_CHR_RIGHT = m_txtBloodPressure_chr2.m_strGetRightText();
                objContent.m_strBLOODPRESSURE_A_CHRXML = m_txtBloodPressure_chr2.m_strGetXmlText();

                objContent.m_strEMBRYOHEART_CHR = m_txtEmbryoHeart_chr.Text;
                objContent.m_strEMBRYOHEART_CHR_RIGHT = m_txtEmbryoHeart_chr.m_strGetRightText();
                objContent.m_strEMBRYOHEART_CHRXML = m_txtEmbryoHeart_chr.m_strGetXmlText();

                objContent.m_strINTERMISSION_CHR = m_txtIntermission_chr.Text;
                objContent.m_strINTERMISSION_CHR_RIGHT = m_txtIntermission_chr.m_strGetRightText();
                objContent.m_strINTERMISSION_CHRXML = m_txtIntermission_chr.m_strGetXmlText();

                objContent.m_strPERSIST_CHR = m_txtPersist_chr.Text;
                objContent.m_strPERSIST_CHR_RIGHT = m_txtPersist_chr.m_strGetRightText();
                objContent.m_strPERSIST_CHRXML = m_txtPersist_chr.m_strGetXmlText();

                objContent.m_strINTENSITY_CHR = m_cboIntensity_chr.Text;
                objContent.m_strINTENSITY_CHR_RIGHT = m_cboIntensity_chr.Text;
                objContent.m_strINTENSITY_CHRXML = "<root />";

                objContent.m_strPALACEMOUTH_CHR = m_txtPalaceMouth_chr.Text;
                objContent.m_strPALACEMOUTH_CHR_RIGHT = m_txtPalaceMouth_chr.m_strGetRightText();
                objContent.m_strPALACEMOUTH_CHRXML = m_txtPalaceMouth_chr.m_strGetXmlText();

                objContent.m_strSHOW_CHR = m_cboShow_chr.Text;
                objContent.m_strSHOW_CHR_RIGHT = m_cboShow_chr.Text;
                objContent.m_strSHOW_CHRXML = "<root />";

                objContent.m_strCAUL_CHR = m_cboCaul_chr.Text;
                objContent.m_strCAUL_CHR_RIGHT = m_cboCaul_chr.Text;
                objContent.m_strCAUL_CHRXML = "<root />";

                objContent.m_strANUSCHECK_CHR = m_cboAnusCheck_chr.Text;
                objContent.m_strANUSCHECK_CHR_RIGHT = m_cboAnusCheck_chr.Text;
                objContent.m_strANUSCHECK_CHRXML = "<root />";

                objContent.m_strREMARK_CHR = m_txtRemark.Text;
                objContent.m_strREMARK_CHR_RIGHT = m_txtRemark.m_strGetRightText();
                objContent.m_strREMARK_CHRXML = m_txtRemark.m_strGetXmlText();

                objContent.m_strCHECKEMP_CHR = m_txtCheckEMP.Text;
                objContent.m_strCHECKEMP_RIGHT = m_txtCheckEMP.m_strGetRightText();
                objContent.m_strCHECKEMP_XML = m_txtCheckEMP.m_strGetXmlText();

                #region 获取签名
                objContent.objSignerArr = null;
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
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
                //        objContent.objSignerArr[j].m_strFORMID_VCHR = "frmWaitLayRecord_AcadCon_GX";//注意大小写



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
            clsEMR_WAITLAYRECORD_GX objContent = p_objContent as clsEMR_WAITLAYRECORD_GX;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
            if (objContent.m_dtmBEFOREHAND == DateTime.MinValue)
            {
                m_lblLayDate.Text = string.Empty;
            }
            else
            {
                m_lblLayDate.Text = objContent.m_dtmBEFOREHAND.ToString("yyyy年MM月dd日");
            }
            m_lblLayTimes.Text = objContent.m_strLAYCOUNT_CHR;

            m_txtBloodPressure_chr1.Text = objContent.m_strBLOODPRESSURE_S_CHR_RIGHT;
            m_txtBloodPressure_chr2.Text = objContent.m_strBLOODPRESSURE_A_CHR_RIGHT;
            m_txtEmbryoHeart_chr.Text = objContent.m_strEMBRYOHEART_CHR_RIGHT;
            m_txtIntermission_chr.Text = objContent.m_strINTERMISSION_CHR_RIGHT;
            m_txtPersist_chr.Text = objContent.m_strPERSIST_CHR_RIGHT;
            m_cboIntensity_chr.Text = objContent.m_strINTENSITY_CHR_RIGHT;
            m_txtPalaceMouth_chr.Text = objContent.m_strPALACEMOUTH_CHR_RIGHT;
            m_cboShow_chr.Text = objContent.m_strSHOW_CHR_RIGHT;
            m_cboCaul_chr.Text = objContent.m_strCAUL_CHR_RIGHT;
            m_cboAnusCheck_chr.Text = objContent.m_strANUSCHECK_CHR_RIGHT;
            m_txtRemark.Text = objContent.m_strREMARK_CHR_RIGHT;
            m_txtCheckEMP.Text = objContent.m_strCHECKEMP_RIGHT;

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
            this.m_dtpCreateDate.Enabled = false;
        } 
        #endregion

        #region 把特殊记录的值显示到界面上



        /// <summary>
        /// 把特殊记录的值显示到界面上

        /// </summary>
        /// <param name="p_objContent">VO</param>
        protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsEMR_WAITLAYRECORD_GX objContent = p_objContent as clsEMR_WAITLAYRECORD_GX;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
            if (objContent.m_dtmBEFOREHAND == DateTime.MinValue)
            {
                m_lblLayDate.Text = string.Empty;
            }
            else
            {
                m_lblLayDate.Text = objContent.m_dtmBEFOREHAND.ToString("yyyy年MM月dd日");
            }
            m_lblLayTimes.Text = objContent.m_strLAYCOUNT_CHR;

            m_txtBloodPressure_chr1.m_mthSetNewText(objContent.m_strBLOODPRESSURE_S_CHR, objContent.m_strBLOODPRESSURE_S_CHRXML);
            m_txtBloodPressure_chr2.m_mthSetNewText(objContent.m_strBLOODPRESSURE_A_CHR, objContent.m_strBLOODPRESSURE_A_CHRXML);
           
            m_txtEmbryoHeart_chr.m_mthSetNewText(objContent.m_strEMBRYOHEART_CHR, objContent.m_strEMBRYOHEART_CHRXML);
            m_txtIntermission_chr.m_mthSetNewText(objContent.m_strINTERMISSION_CHR, objContent.m_strINTERMISSION_CHRXML);
            m_txtPersist_chr.m_mthSetNewText(objContent.m_strPERSIST_CHR, objContent.m_strPERSIST_CHRXML);
            m_cboIntensity_chr.Text = objContent.m_strINTENSITY_CHR_RIGHT;
            m_txtPalaceMouth_chr.m_mthSetNewText(objContent.m_strPALACEMOUTH_CHR, objContent.m_strPALACEMOUTH_CHRXML);
            m_cboShow_chr.Text = objContent.m_strSHOW_CHR_RIGHT;
            m_cboCaul_chr.Text = objContent.m_strCAUL_CHR_RIGHT;
            m_cboAnusCheck_chr.Text = objContent.m_strANUSCHECK_CHR_RIGHT;
            m_txtRemark.m_mthSetNewText(objContent.m_strREMARK_CHR, objContent.m_strREMARK_CHRXML);
            m_txtCheckEMP.m_mthSetNewText(objContent.m_strCHECKEMP_CHR,objContent.m_strCHECKEMP_XML);
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
            this.m_dtpCreateDate.Enabled = false;
        } 
        #endregion

        #region 控制是否可以选择病人和记录时间列表


        /// <summary>
        /// 控制是否可以选择病人和记录时间列
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
        /// <param name="p_blnEnable">是否允许修改特殊记录的记录信息</param>
        protected override void m_mthEnableModifySub(bool p_blnEnable)
        {

        } 
        #endregion

        #region 设置是否控制修改(不实现)
        /// <summary>
        /// 设置是否控制修改(修改留痕迹)
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset">是否重置控制修改(修改留痕迹)
        ///如果为true，忽略记录内容，把界面控制设置为不控制


        ///否则根据记录内容进行设置
        ///</param>
        protected override void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
            bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制




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
        /// 清空特殊记录信息，并重置记录控制状态为不控制

        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

            //m_lblLayDate.Text = string.Empty;
            //m_lblLayTimes.Text = string.Empty;
            m_dtpCreateDate.Value = DateTime.Now;

            m_txtBloodPressure_chr1.m_mthClearText();
            m_txtBloodPressure_chr2.m_mthClearText();
            m_txtEmbryoHeart_chr.m_mthClearText();
            m_txtIntermission_chr.m_mthClearText();
            m_txtPersist_chr.m_mthClearText();
            m_cboIntensity_chr.Text = string.Empty;
            m_txtPalaceMouth_chr.m_mthClearText();
            m_cboShow_chr.Text = string.Empty;
            m_cboCaul_chr.Text = string.Empty;
            m_cboAnusCheck_chr.Text = string.Empty;
            m_txtRemark.m_mthClearText();
            m_txtCheckEMP.m_mthClearText();
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
                new Control[] { m_txtBloodPressure_chr1, m_txtBloodPressure_chr2, m_txtEmbryoHeart_chr, m_txtIntermission_chr ,
                m_txtPersist_chr,m_cboIntensity_chr,m_txtPalaceMouth_chr,m_cboShow_chr,m_cboCaul_chr,m_cboAnusCheck_chr,
                    m_txtRemark,m_txtCheckEMP}, Keys.Enter);
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