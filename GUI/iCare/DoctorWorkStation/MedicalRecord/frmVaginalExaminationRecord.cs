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
    /// 阴道检查记录表
    /// </summary>
    public partial class frmVaginalExaminationRecord : frmDiseaseTrackBase
    {
        #region 全局变量
        /// <summary>
        /// 定义签名类
        /// </summary>
        private clsEmrSignToolCollection m_objSign = null;
        #endregion

        #region 构造函数

        /// <summary>
        /// 阴道检查记录表
        /// </summary>
        public frmVaginalExaminationRecord()
        {
            InitializeComponent();

            //签名常用值

            m_objSign = new clsEmrSignToolCollection();
            //可以指定员工ID如

            m_objSign.m_mthBindEmployeeSign(m_cmdSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_mthSetRichTextBoxAttribInControl(this);
        } 
        #endregion

        #region 属性、方法

        #region 窗体ID
        public override int m_IntFormID
        {
            get
            {
                return 159;
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

            return "阴道检查记录表";
        }
        #endregion

        #region 获取护理记录的领域层实例
        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现

            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_VaginalExamination);
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

            clsEMR_VaginalExaminationValue objContent = (clsEMR_VaginalExaminationValue)p_objRecordContent;
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
            clsEMR_VaginalExaminationValue objContent = new clsEMR_VaginalExaminationValue();
            try
            {
                string StrNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objContent.m_dtmCreateDate = Convert.ToDateTime(StrNow);
                objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_dtmModifyDate = Convert.ToDateTime(StrNow);
                objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_strRegisterID = frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

                objContent.m_dtmRecordDate = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                objContent.m_dtmEXAMINATIONTIME_DAT = Convert.ToDateTime(m_dtpExaminationTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                objContent.m_strEXAMINATIONREASON_VCHR = m_txtExaminationReason.Text;
                objContent.m_strEXAMINATIONREASON_RIGHT = m_txtExaminationReason.m_strGetRightText();
                objContent.m_strEXAMINATIONREASON_XML = m_txtExaminationReason.m_strGetXmlText();

                objContent.m_strMETREURYSIS_VCHR = m_txtMetreurysis.Text;
                objContent.m_strMETREURYSIS_RIGHT = m_txtMetreurysis.m_strGetRightText();
                objContent.m_strMETREURYSIS_XML = m_txtMetreurysis.m_strGetXmlText();

                objContent.m_strPRESENTATION_VCHR = m_txtPresentation.Text;
                objContent.m_strPRESENTATION_RIGHT = m_txtPresentation.m_strGetRightText();
                objContent.m_strPRESENTATION_XML = m_txtPresentation.m_strGetXmlText();

                objContent.m_strPRESENTATIONHEIGHT_VCHR = m_txtPresentationHeight.Text;
                objContent.m_strPRESENTATIONHEIGHT_RIGHT = m_txtPresentationHeight.m_strGetRightText();
                objContent.m_strPRESENTATIONHEIGHT_XML = m_txtPresentationHeight.m_strGetXmlText();

                objContent.m_strPRESENTATIONORIENTATION_VCHR = m_txtPresentationOrientation.Text;
                objContent.m_strPRESENTATIONORIENTATION_RIGHT = m_txtPresentationOrientation.m_strGetRightText();
                objContent.m_strPRESENTATIONORIENTATION_XML = m_txtPresentationOrientation.m_strGetXmlText();

                objContent.m_strSKULL_VCHR = m_txtSkull.Text;
                objContent.m_strSKULL_RIGHT = m_txtSkull.m_strGetRightText();
                objContent.m_strSKULL_XML = m_txtSkull.m_strGetXmlText();

                objContent.m_strOVERLAPPING_VCHR = m_txtOverlapping.Text;
                objContent.m_strOVERLAPPING_RIGHT = m_txtOverlapping.m_strGetRightText();
                objContent.m_strOVERLAPPING_XML = m_txtOverlapping.m_strGetXmlText();

                objContent.m_strCAPUTSUCCEDANEUM_VCHR = m_txtCaputSuccedaneum.Text;
                objContent.m_strCAPUTSUCCEDANEUM_RIGHT = m_txtCaputSuccedaneum.m_strGetRightText();
                objContent.m_strCAPUTSUCCEDANEUM_XML = m_txtCaputSuccedaneum.m_strGetXmlText();

                objContent.m_strRUPTUREDFETALMEMBRANES_CHR = m_strNum(m_chkRupturedFetalMembranes.Checked)
                    + m_strNum(m_chkUnrupturedFetalMembranes.Checked);
                objContent.m_strRUPTUREDMODE_CHR = m_strNum(m_chkNatureRuptured.Checked) + m_strNum(m_chkManualRuptured.Checked);

                if (!m_dtpRuptureTime.Enabled)
                {
                    objContent.m_dtmRUPTURETIME_DAT = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                else
                    objContent.m_dtmRUPTURETIME_DAT = Convert.ToDateTime(m_dtpRuptureTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                objContent.m_strAMNIOTICFLUID_VCHR = m_txtAmnioticFluid.Text;
                objContent.m_strAMNIOTICFLUID_RIGHT = m_txtAmnioticFluid.m_strGetRightText();
                objContent.m_strAMNIOTICFLUID_XML = m_txtAmnioticFluid.m_strGetXmlText();

                objContent.m_strAMNIOTICFLUIDCHARACTER_VCHR = m_txtAmnioticFluidCharacter.Text;
                objContent.m_strAMNIOTICFLUIDCHARACTER_RIGHT = m_txtAmnioticFluidCharacter.m_strGetRightText();
                objContent.m_strAMNIOTICFLUIDCHARACTER_XML = m_txtAmnioticFluidCharacter.m_strGetXmlText();

                objContent.m_strFHR_VCHR = m_txtFHR.Text;
                objContent.m_strFHR_RIGHT = m_txtFHR.m_strGetRightText();
                objContent.m_strFHR_XML = m_txtFHR.m_strGetXmlText();

                objContent.m_strISCHIALSPINE_VCHR = m_txtIschialSpine.Text;
                objContent.m_strISCHIALSPINE_RIGHT = m_txtIschialSpine.m_strGetRightText();
                objContent.m_strISCHIALSPINE_XML = m_txtIschialSpine.m_strGetXmlText();

                objContent.m_strCOCCYX_CHR = m_strNum(m_chkCoccyx1.Checked) + m_strNum(m_chkCoccyx2.Checked) + m_strNum(m_chkCoccyx3.Checked);

                objContent.m_strSACRALBONE_VCHR = m_txtSacralBone.Text;
                objContent.m_strSACRALBONE_RIGHT = m_txtSacralBone.m_strGetRightText();
                objContent.m_strSACRALBONE_XML = m_txtSacralBone.m_strGetXmlText();

                objContent.m_strPUBICARCH_VCHR = m_txtPubicArch.Text;
                objContent.m_strPUBICARCH_RIGHT = m_txtPubicArch.m_strGetRightText();
                objContent.m_strPUBICARCH_XML = m_txtPubicArch.m_strGetXmlText();

                objContent.m_strDC_VCHR = m_txtDC.Text;
                objContent.m_strDC_RIGHT = m_txtDC.m_strGetRightText();
                objContent.m_strDC_XML = m_txtDC.m_strGetXmlText();

                objContent.m_strISCHIUMNOTCH_VCHR = m_txtIschiumNotch.Text;
                objContent.m_strISCHIUMNOTCH_RIGHT = m_txtIschiumNotch.m_strGetRightText();
                objContent.m_strISCHIUMNOTCH_XML = m_txtIschiumNotch.m_strGetXmlText();

                objContent.m_strURETHRALCATHETERIZATION_CHR = m_strNum(m_chkUrethralCatheterization1.Checked) + m_strNum(m_chkUrethralCatheterization2.Checked);

                objContent.m_strPISS_VCHR = m_txtPiss.Text;
                objContent.m_strPISS_RIGHT = m_txtPiss.m_strGetRightText();
                objContent.m_strPISS_XML = m_txtPiss.m_strGetXmlText();

                objContent.m_strUCCHARACTER_VCHR = m_txtUCCharacter.Text;
                objContent.m_strUCCHARACTER_RIGHT = m_txtUCCharacter.m_strGetRightText();
                objContent.m_strUCCHARACTER_XML = m_txtUCCharacter.m_strGetXmlText();

                objContent.m_strPROJECT_RIGHT = m_txtProject.m_strGetRightText();
                objContent.m_strPROJECT_VCHR = m_txtProject.Text;
                objContent.m_strPROJECT_XML = m_txtProject.m_strGetXmlText();
                #region 获取签名
                objContent.objSignerArr = null;
                string strRecorderIDList = string.Empty;
                if (lsvSign.Items.Count > 0)
                {
                    objContent.objSignerArr = new clsEmrSigns_VO[lsvSign.Items.Count];
                    for (int j = 0; j < lsvSign.Items.Count; j++)
                    {
                        objContent.objSignerArr[j] = new clsEmrSigns_VO();
                        objContent.objSignerArr[j].objEmployee = new clsEmrEmployeeBase_VO();
                        objContent.objSignerArr[j].objEmployee = (clsEmrEmployeeBase_VO)(lsvSign.Items[j].Tag);
                        objContent.objSignerArr[j].controlName = "lsvSign";
                        objContent.objSignerArr[j].m_strFORMID_VCHR = "frmVaginalExaminationRecord";//注意大小写

                        objContent.objSignerArr[j].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

                        if (j < lsvSign.Items.Count - 1)
                        {
                            strRecorderIDList += objContent.objSignerArr[j].objEmployee.m_strEMPID_CHR + ",";
                        }
                        else
                        {
                            strRecorderIDList += objContent.objSignerArr[j].objEmployee.m_strEMPID_CHR;
                        }
                    }
                }
                objContent.m_strRecordUserID = strRecorderIDList;
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

        #region 将"0","1"转换为相应布尔值

        /// <summary>
        /// 将"0","1"转换为相应布尔值
        /// </summary>
        /// <param name="p_strNum">字符</param>
        /// <returns></returns>
        private bool m_blnCheck(string p_strNum)
        {
            if (p_strNum == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 将布尔值转换为相应的字符"0","1"
        /// <summary>
        /// 将布尔值转换为相应的字符"0","1"
        /// </summary>
        /// <param name="p_blnCheck">布尔值</param>
        /// <returns></returns>
        private string m_strNum(bool p_blnCheck)
        {
            if (p_blnCheck)
                return "1";
            else
                return "0";
        }
        #endregion

        #region 显示已删除记录至界面
        /// <summary>
        /// 显示已删除记录至界面
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsEMR_VaginalExaminationValue objContent = p_objContent as clsEMR_VaginalExaminationValue;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            m_dtpExaminationTime.Value = objContent.m_dtmEXAMINATIONTIME_DAT;

            m_txtExaminationReason.Text = objContent.m_strEXAMINATIONREASON_RIGHT;

            m_txtMetreurysis.Text = objContent.m_strMETREURYSIS_RIGHT;

            m_txtPresentation.Text = objContent.m_strPRESENTATION_RIGHT;

            m_txtPresentationHeight.Text = objContent.m_strPRESENTATIONHEIGHT_RIGHT;

            m_txtPresentationOrientation.Text = objContent.m_strPRESENTATIONORIENTATION_RIGHT;

            m_txtSkull.Text = objContent.m_strSKULL_RIGHT;

            m_txtOverlapping.Text = objContent.m_strOVERLAPPING_RIGHT;

            m_txtCaputSuccedaneum.Text = objContent.m_strCAPUTSUCCEDANEUM_RIGHT;

            if (!string.IsNullOrEmpty(objContent.m_strRUPTUREDFETALMEMBRANES_CHR))
            {
                m_chkRupturedFetalMembranes.Checked = m_blnCheck(objContent.m_strRUPTUREDFETALMEMBRANES_CHR[0].ToString());
                m_chkUnrupturedFetalMembranes.Checked = m_blnCheck(objContent.m_strRUPTUREDFETALMEMBRANES_CHR[1].ToString());
            }
            if (!string.IsNullOrEmpty(objContent.m_strRUPTUREDMODE_CHR))
            {
                m_chkNatureRuptured.Checked = m_blnCheck(objContent.m_strRUPTUREDMODE_CHR[0].ToString());
                m_chkManualRuptured.Checked = m_blnCheck(objContent.m_strRUPTUREDMODE_CHR[1].ToString());
            }

            if (objContent.m_dtmRUPTURETIME_DAT == new DateTime(1900, 1, 1, 0, 0, 0))
            {
                m_dtpRuptureTime.Value = DateTime.Now;
            }
            else
                m_dtpRuptureTime.Value = objContent.m_dtmRUPTURETIME_DAT;

            m_txtAmnioticFluid.Text = objContent.m_strAMNIOTICFLUID_RIGHT;

            m_txtAmnioticFluidCharacter.Text = objContent.m_strAMNIOTICFLUIDCHARACTER_RIGHT;

            m_txtFHR.Text = objContent.m_strFHR_RIGHT;

            m_txtIschialSpine.Text = objContent.m_strISCHIALSPINE_RIGHT;

            if (!string.IsNullOrEmpty(objContent.m_strCOCCYX_CHR))
            {
                m_chkCoccyx1.Checked = m_blnCheck(objContent.m_strCOCCYX_CHR[0].ToString());
                m_chkCoccyx2.Checked = m_blnCheck(objContent.m_strCOCCYX_CHR[1].ToString());
                m_chkCoccyx3.Checked = m_blnCheck(objContent.m_strCOCCYX_CHR[2].ToString());
            }

            m_txtSacralBone.Text = objContent.m_strSACRALBONE_RIGHT;

            m_txtPubicArch.Text = objContent.m_strPUBICARCH_RIGHT;

            m_txtDC.Text = objContent.m_strDC_RIGHT;

            m_txtIschiumNotch.Text = objContent.m_strISCHIUMNOTCH_RIGHT;

            if (!string.IsNullOrEmpty(objContent.m_strURETHRALCATHETERIZATION_CHR))
            {
                m_chkUrethralCatheterization1.Checked = m_blnCheck(objContent.m_strURETHRALCATHETERIZATION_CHR[0].ToString());
                m_chkUrethralCatheterization2.Checked = m_blnCheck(objContent.m_strURETHRALCATHETERIZATION_CHR[1].ToString());
            }

            m_txtPiss.Text = objContent.m_strPISS_RIGHT;

            m_txtUCCharacter.Text = objContent.m_strUCCHARACTER_RIGHT;

            m_txtProject.Text = objContent.m_strPROJECT_RIGHT;

            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                lsvSign.Items.Clear();
                for (int i = 0; i < objContent.objSignerArr.Length; i++)
                {
                    if (objContent.objSignerArr[i].controlName == "lsvSign")
                    {
                        ListViewItem lviNewItem = new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                        //ID 检查重复用
                        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                        //级别 排序用

                        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                        //tag均为对象
                        lviNewItem.Tag = objContent.objSignerArr[i].objEmployee;
                        //是按顺序保存故获取顺序也一样

                        lsvSign.Items.Add(lviNewItem);

                    }
                }
            }
            #endregion 签名

            this.lsvSign.Enabled = false;
            this.m_cmdSign.Enabled = false;
            this.m_dtpCreateDate.Enabled = false;
        }
        #endregion

        #region 把特殊记录的值显示到界面上

        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent">VO</param>
        protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsEMR_VaginalExaminationValue objContent = p_objContent as clsEMR_VaginalExaminationValue;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            m_dtpExaminationTime.Value = objContent.m_dtmEXAMINATIONTIME_DAT;

            m_txtExaminationReason.m_mthSetNewText(objContent.m_strEXAMINATIONREASON_VCHR, objContent.m_strEXAMINATIONREASON_XML);

            m_txtMetreurysis.m_mthSetNewText(objContent.m_strMETREURYSIS_VCHR, objContent.m_strMETREURYSIS_XML);

            m_txtPresentation.m_mthSetNewText(objContent.m_strPRESENTATION_VCHR, objContent.m_strPRESENTATION_XML);

            m_txtPresentationHeight.m_mthSetNewText(objContent.m_strPRESENTATIONHEIGHT_VCHR, objContent.m_strPRESENTATIONHEIGHT_XML);

            m_txtPresentationOrientation.m_mthSetNewText(objContent.m_strPRESENTATIONORIENTATION_VCHR, objContent.m_strPRESENTATIONORIENTATION_XML);

            m_txtSkull.m_mthSetNewText(objContent.m_strSKULL_VCHR, objContent.m_strSKULL_XML);

            m_txtOverlapping.m_mthSetNewText(objContent.m_strOVERLAPPING_VCHR, objContent.m_strOVERLAPPING_XML);

            m_txtCaputSuccedaneum.m_mthSetNewText(objContent.m_strCAPUTSUCCEDANEUM_VCHR, objContent.m_strCAPUTSUCCEDANEUM_XML);

            if (!string.IsNullOrEmpty(objContent.m_strRUPTUREDFETALMEMBRANES_CHR))
            {
                m_chkRupturedFetalMembranes.Checked = m_blnCheck(objContent.m_strRUPTUREDFETALMEMBRANES_CHR[0].ToString());
                m_chkUnrupturedFetalMembranes.Checked = m_blnCheck(objContent.m_strRUPTUREDFETALMEMBRANES_CHR[1].ToString());
            }
            if (!string.IsNullOrEmpty(objContent.m_strRUPTUREDMODE_CHR))
            {
                m_chkNatureRuptured.Checked = m_blnCheck(objContent.m_strRUPTUREDMODE_CHR[0].ToString());
                m_chkManualRuptured.Checked = m_blnCheck(objContent.m_strRUPTUREDMODE_CHR[1].ToString());
            }

            if (objContent.m_dtmRUPTURETIME_DAT == new DateTime(1900, 1, 1, 0, 0, 0))
            {
                m_dtpRuptureTime.Value = DateTime.Now;
            }
            else
                m_dtpRuptureTime.Value = objContent.m_dtmRUPTURETIME_DAT;

            m_txtAmnioticFluid.m_mthSetNewText(objContent.m_strAMNIOTICFLUID_VCHR, objContent.m_strAMNIOTICFLUID_XML);

            m_txtAmnioticFluidCharacter.m_mthSetNewText(objContent.m_strAMNIOTICFLUIDCHARACTER_VCHR, objContent.m_strAMNIOTICFLUIDCHARACTER_XML);

            m_txtFHR.m_mthSetNewText(objContent.m_strFHR_VCHR, objContent.m_strFHR_XML);

            m_txtIschialSpine.m_mthSetNewText(objContent.m_strISCHIALSPINE_VCHR, objContent.m_strISCHIALSPINE_XML);

            if (!string.IsNullOrEmpty(objContent.m_strCOCCYX_CHR))
            {
                m_chkCoccyx1.Checked = m_blnCheck(objContent.m_strCOCCYX_CHR[0].ToString());
                m_chkCoccyx2.Checked = m_blnCheck(objContent.m_strCOCCYX_CHR[1].ToString());
                m_chkCoccyx3.Checked = m_blnCheck(objContent.m_strCOCCYX_CHR[2].ToString());
            }

            m_txtSacralBone.m_mthSetNewText(objContent.m_strSACRALBONE_VCHR, objContent.m_strSACRALBONE_XML);

            m_txtPubicArch.m_mthSetNewText(objContent.m_strPUBICARCH_VCHR, objContent.m_strPUBICARCH_XML);

            m_txtDC.m_mthSetNewText(objContent.m_strDC_VCHR, objContent.m_strDC_XML);

            m_txtIschiumNotch.m_mthSetNewText(objContent.m_strISCHIUMNOTCH_VCHR, objContent.m_strISCHIUMNOTCH_XML);

            if (!string.IsNullOrEmpty(objContent.m_strURETHRALCATHETERIZATION_CHR))
            {
                m_chkUrethralCatheterization1.Checked = m_blnCheck(objContent.m_strURETHRALCATHETERIZATION_CHR[0].ToString());
                m_chkUrethralCatheterization2.Checked = m_blnCheck(objContent.m_strURETHRALCATHETERIZATION_CHR[1].ToString());
            }

            m_txtPiss.m_mthSetNewText(objContent.m_strPISS_VCHR, objContent.m_strPISS_XML);

            m_txtUCCharacter.m_mthSetNewText(objContent.m_strUCCHARACTER_VCHR, objContent.m_strUCCHARACTER_XML);

            m_txtProject.m_mthSetNewText(objContent.m_strPROJECT_VCHR, objContent.m_strPROJECT_XML);

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
        /// 控制是否可以选择病人和记录时间列表。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
        {
            if (p_blnEnable == false)
            {
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


        }
        #endregion

        #region 获取记录单传递信息内容

        /// <summary>
        /// 获取记录单传递信息内容
        /// </summary>
        /// <returns></returns>
        public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            return null;
        }
        #endregion

        #region 清空特殊记录信息
        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

            DateTime dtNow = DateTime.Now;
            m_dtpCreateDate.Value = dtNow;

            m_dtpExaminationTime.Value = dtNow;

            m_txtExaminationReason.m_mthClearText();

            m_txtMetreurysis.m_mthClearText();

            m_txtPresentation.m_mthClearText();

            m_txtPresentationHeight.m_mthClearText();

            m_txtPresentationOrientation.m_mthClearText();

            m_txtSkull.m_mthClearText();

            m_txtOverlapping.m_mthClearText();

            m_txtCaputSuccedaneum.m_mthClearText();

            m_chkRupturedFetalMembranes.Checked = false;
            m_chkUnrupturedFetalMembranes.Checked = false;

            m_chkNatureRuptured.Checked = false;
            m_chkManualRuptured.Checked = false;

            m_dtpRuptureTime.Value = dtNow;

            m_txtAmnioticFluid.m_mthClearText();

            m_txtAmnioticFluidCharacter.m_mthClearText();

            m_txtFHR.m_mthClearText();

            m_txtIschialSpine.m_mthClearText();

            m_chkCoccyx1.Checked = false;
            m_chkCoccyx2.Checked = false;
            m_chkCoccyx3.Checked = false;

            m_txtSacralBone.m_mthClearText();

            m_txtPubicArch.m_mthClearText();

            m_txtDC.m_mthClearText();

            m_txtIschiumNotch.m_mthClearText();

            m_chkUrethralCatheterization1.Checked = false;
            m_chkUrethralCatheterization2.Checked = false;

            m_txtPiss.m_mthClearText();

            m_txtUCCharacter.m_mthClearText();

            m_txtProject.m_mthClearText();
            this.m_cmdSign.Enabled = true;
            this.lsvSign.Enabled = true;
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
                new Control[] {m_dtpExaminationTime, m_txtExaminationReason, m_txtMetreurysis, m_txtPresentation, m_txtPresentationHeight, m_txtPresentationOrientation ,
                m_txtSkull,m_txtOverlapping,m_txtCaputSuccedaneum,m_chkRupturedFetalMembranes,m_chkUnrupturedFetalMembranes,m_chkNatureRuptured,m_chkManualRuptured,m_dtpRuptureTime,
                m_txtAmnioticFluid,m_txtAmnioticFluidCharacter,m_txtFHR,m_txtIschialSpine,m_chkCoccyx1,m_chkCoccyx2,m_chkCoccyx3,m_txtSacralBone,m_txtPubicArch,m_txtDC,
                    m_txtIschiumNotch,m_chkUrethralCatheterization1,m_chkUrethralCatheterization2,m_txtPiss,m_txtUCCharacter,m_txtProject}, Keys.Enter);
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

        #region 获取病人记录列表
        /// <summary>
        /// 获取病人记录列表
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="strCreateTimeListArr"></param>
        /// <param name="strOpenTimeListArr"></param>
        /// <returns></returns>
        protected override void m_mthGetTimeList(clsPatient p_objSelectedPatient, out string[] strCreateTimeListArr, out string[] strRecordTimeListArr)
        {
            strCreateTimeListArr = null;
            strRecordTimeListArr = null;
            if (p_objSelectedPatient == null || m_objDiseaseTrackDomain == null)
                return ;

            long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordTimeList(p_objSelectedPatient.m_StrRegisterId, out strCreateTimeListArr, out strRecordTimeListArr);

            if (lngRes <= 0 || strCreateTimeListArr == null || strRecordTimeListArr == null || strRecordTimeListArr.Length != strCreateTimeListArr.Length)
            {
                m_mthSetNodeSelected();
                return;
            }

            //添加查询到的时间到时间树上 
            for (int i = strCreateTimeListArr.Length - 1; i >= 0; i--)
            {
                TreeNode trnRecordDate = new TreeNode(strRecordTimeListArr[i]);
                trnRecordDate.Tag = strCreateTimeListArr[i];
                m_trnRoot.Nodes.Add(trnRecordDate);
            }
        } 
        #endregion

        #region 设置创建时间
        /// <summary>
        /// 设置创建时间
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetSubCreatedDateInfo(ref clsTrackRecordContent p_objContent, bool p_blnIsAddNew)
        {
            if (p_objContent != null)
            {
                string strTimeNow = new clsPublicDomain().m_strGetServerTime();
                if (p_blnIsAddNew)
                {
                    p_objContent.m_dtmCreateDate = DateTime.Parse(strTimeNow);
                }
                p_objContent.m_dtmModifyDate = DateTime.Parse(strTimeNow);
                p_objContent.m_bytIfConfirm = 0;
                p_objContent.m_bytStatus = 0;
                p_objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
                p_objContent.m_strConfirmReason = "";
                p_objContent.m_strConfirmReasonXML = "";
                p_objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                p_objContent.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
            }
        } 
        #endregion

        #region 添加节点到时间列表树,并选中
        /// <summary>
        /// 添加节点到时间列表树,并选中
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthAddNode(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
            {
                return;
            }
            string strRecordDate = p_objContent.m_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss");
            TreeNode trnNode = new TreeNode(strRecordDate);
            trnNode.Tag = p_objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");

            m_blnCanTreeNodeAfterSelectEventTakePlace = false;

            if (m_trnRoot.Nodes.Count == 0 || trnNode.Text.CompareTo(m_trnRoot.LastNode.Text) < 0)
            {
                m_trnRoot.Nodes.Add(trnNode);
                m_trvCreateDate.SelectedNode = m_trnRoot.LastNode;//
            }
            else
            {
                for (int i = 0; i < m_trnRoot.Nodes.Count; i++)
                {
                    if (trnNode.Text.CompareTo(m_trnRoot.Nodes[i].Text) > 0)
                    {
                        m_trnRoot.Nodes.Insert(i, trnNode);
                        m_trvCreateDate.SelectedNode = m_trnRoot.Nodes[i];//
                        break;
                    }
                }
            }
            m_blnCanTreeNodeAfterSelectEventTakePlace = true;
            m_dtpCreateDate.Enabled = false;
        } 
        #endregion
        #endregion

        #region 事件
        private void m_chkRupturedFetalMembranes_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkRupturedFetalMembranes.Checked)
            {
                panel1.Enabled = true;
                m_dtpRuptureTime.Enabled = true;
                m_chkUnrupturedFetalMembranes.Checked = false;
            }

            if (!m_chkRupturedFetalMembranes.Checked && !m_chkUnrupturedFetalMembranes.Checked)
            {
                panel1.Enabled = false;
                m_chkNatureRuptured.Checked = false;
                m_chkManualRuptured.Checked = false;
                m_dtpRuptureTime.Enabled = false;
            }
        }

        private void m_chkUnrupturedFetalMembranes_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkUnrupturedFetalMembranes.Checked)
            {
                panel1.Enabled = false;
                m_chkNatureRuptured.Checked = false;
                m_chkManualRuptured.Checked = false;
                m_dtpRuptureTime.Enabled = false;
                m_chkRupturedFetalMembranes.Checked = false;
            }
        }

        private void m_chkNatureRuptured_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkNatureRuptured.Checked)
            {
                m_chkManualRuptured.Checked = false;
            }
        }

        private void m_chkManualRuptured_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkManualRuptured.Checked)
            {
                m_chkNatureRuptured.Checked = false;
            }
        }

        private void m_chkCoccyx1_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkCoccyx1.Checked)
            {
                m_chkCoccyx2.Checked = false;
                m_chkCoccyx3.Checked = false;
            }
        }

        private void m_chkCoccyx2_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkCoccyx2.Checked)
            {
                m_chkCoccyx1.Checked = false;
                m_chkCoccyx3.Checked = false;
            }
        }

        private void m_chkCoccyx3_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkCoccyx3.Checked)
            {
                m_chkCoccyx2.Checked = false;
                m_chkCoccyx1.Checked = false;
            }
        }

        private void m_chkUrethralCatheterization1_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkUrethralCatheterization1.Checked)
            {
                m_txtPiss.Enabled = false;
                m_txtUCCharacter.Enabled = false;
                m_chkUrethralCatheterization2.Checked = false;

                m_txtPiss.m_mthClearText();
                m_txtUCCharacter.m_mthClearText();
            }
        }

        private void m_chkUrethralCatheterization2_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkUrethralCatheterization2.Checked)
            {
                m_txtPiss.Enabled = true;
                m_txtUCCharacter.Enabled = true;
                m_chkUrethralCatheterization1.Checked = false;
            }

            if (!m_chkUrethralCatheterization2.Checked && !m_chkUrethralCatheterization1.Checked)
            {
                m_txtPiss.Enabled = false;
                m_txtUCCharacter.Enabled = false;

                m_txtPiss.m_mthClearText();
                m_txtUCCharacter.m_mthClearText();
            }
        }

        private void frmVaginalExaminationRecord_Load(object sender, EventArgs e)
        {
            m_mthfrmLoad();
        }
        #endregion

        #region 外部打印.

        System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private void m_mthfrmLoad()
        {
            this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        }
        private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
                objPrintTool.m_mthPrintPage(e);

                if (ppdPrintPreview != null)
                    while (!ppdPrintPreview.m_blnHandlePrint(e))
                        objPrintTool.m_mthPrintPage(e);
            
        }

        private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
             objPrintTool.m_mthBeginPrint(e);
        }

        private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
             objPrintTool.m_mthEndPrint(e);
        }

        private clsEMR_VaginalExaminationRecordPrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            try
            {
                objPrintTool = new clsEMR_VaginalExaminationRecordPrintTool();
                objPrintTool.m_mthInitPrintTool(null);
                if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);

                objPrintTool.m_mthInitPrintContent();

                m_mthStartPrint();
            }
            catch (Exception objExc)
            {
                MessageBox.Show(objExc.Message + "\r\n" + objExc.StackTrace);
            }
        }

        private PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();

        private void m_mthStartPrint()
        {
            if (m_blnDirectPrint)
            {
               
                    //objPrintTool.m_BlnPreview = false;
                    //objPrintTool.m_BlnIsDummy = false;
                    m_pdcPrintDocument.Print();
                    //if (clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strPromptForPrint, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    //    //objPrintTool.m_BlnIsDummy = true;
                    //    m_pdcPrintDocument.Print();
                    //}
                
                //				m_pdcPrintDocument.Print();
            }
            else
            {
                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog();
            }
        }

        protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
        {
            m_mthDemoPrint_FromDataSource();
            return 1;
        }
        #endregion 外部打印

        private void m_txtOverlapping_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}