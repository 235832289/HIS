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
using Serv = com.digitalwave.DiseaseTrackService;
using System.Text.RegularExpressions;

namespace iCare
{
    public partial class frmIntakeAndOutputVolumeSummary : frmDiseaseTrackBase
    {
        #region 全局变量
        private bool m_blnIsAddNew = true;
        private DateTime m_dtmRecordDate = DateTime.MinValue; 
        /// <summary>
        /// 定义签名类
        /// </summary>
        private clsEmrSignToolCollection m_objSign = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 出入量登记表
        /// </summary>
        public frmIntakeAndOutputVolumeSummary()
        {
            InitializeComponent();
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_mthSetRichTextBoxAttribInControl(this);
        }

        /// <summary>
        /// 出入量登记表
        /// </summary>
        /// <param name="p_blnIsAddNew">是否新增记录</param>
        /// <param name="p_dtmRecordDate">记录日期</param>
        public frmIntakeAndOutputVolumeSummary(bool p_blnIsAddNew, DateTime p_dtmRecordDate)
            : this()
        {
            m_blnIsAddNew = p_blnIsAddNew;
            m_dtmRecordDate = p_dtmRecordDate;
        } 
        #endregion

        #region 事件
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (m_blnIsAddNew)
            {
                bool blnHasSame = false;

                Serv::clsEMR_IntakeAndOutputVolumeSumServ objServ =
                    (Serv::clsEMR_IntakeAndOutputVolumeSumServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(Serv::clsEMR_IntakeAndOutputVolumeSumServ));

                long lngRes = objServ.m_lngCheckHasSameSummary(m_objCurrentPatient.m_StrRegisterId,
                    Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd 00:00:00")), out blnHasSame);

                if (blnHasSame)
                {
                    clsPublicFunction.ShowInformationMessageBox("已对" + m_dtpCreateDate.Value.ToString("yyyy年MM月dd日")
                        + "的出入量进行过总结，请重新选择另一个时间。");
                    return;
                }
            }            

            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        } 
        #endregion

        #region 方法、属性
        #region 获取记录内容
        /// <summary>
        /// 获取记录内容
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

        #region Jump Control
        /// <summary>
        /// 控制跳转控制
        /// </summary>
        /// <param name="p_objJump"></param>
        protected override void m_mthInitJump(clsJumpControl p_objJump)
        {
            p_objJump = new clsJumpControl(this,
                new Control[] { m_txtAllUrine, m_txtAllOutput, m_txtSpecificGravity, m_txtAllIntake }, Keys.Enter);
        }
        #endregion

        #region 清空特殊记录信息
        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

            m_txtAllUrine.m_mthClearText();
            m_txtAllOutput.m_mthClearText();
            m_txtSpecificGravity.m_mthClearText();
            m_txtAllIntake.m_mthClearText();
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

                btnConfirm.Visible = true;

                this.CenterToParent();
            }

            this.MaximizeBox = false;
        }
        #endregion

        #region 把特殊记录的值显示到界面上
        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent">VO</param>
        protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsEMR_IntakeAndOutputVolumeSum objContent = p_objContent as clsEMR_IntakeAndOutputVolumeSum;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            m_txtAllUrine.m_mthSetNewText(objContent.m_strALLURINE, objContent.m_strALLURINEXML);
            m_txtAllIntake.m_mthSetNewText(objContent.m_strALLINTAKE, objContent.m_strALLINTAKEXML);
            m_txtAllOutput.m_mthSetNewText(objContent.m_strALLOUTPUT, objContent.m_strALLOUTPUTXML);
            m_txtSpecificGravity.m_mthSetNewText(objContent.m_strSPECIFICGRAVITY, objContent.m_strSPECIFICGRAVITYXML);
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
            this.m_cmdEmployeeSign.Enabled = false;
            this.m_dtpCreateDate.Enabled = false;
        }
        #endregion

        #region 显示已删除记录至界面
        /// <summary>
        /// 显示已删除记录至界面
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsEMR_IntakeAndOutputVolumeSum objContent = p_objContent as clsEMR_IntakeAndOutputVolumeSum;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            m_txtAllIntake.Text = m_strGetRightText(objContent.m_strALLINTAKE, objContent.m_strALLINTAKEXML);
            m_txtAllOutput.Text = m_strGetRightText(objContent.m_strALLOUTPUT, objContent.m_strALLOUTPUTXML);
            m_txtAllUrine.Text = m_strGetRightText(objContent.m_strALLURINE, objContent.m_strALLURINEXML);
            m_txtSpecificGravity.Text = m_strGetRightText(objContent.m_strSPECIFICGRAVITY, objContent.m_strSPECIFICGRAVITYXML);
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
            this.m_cmdEmployeeSign.Enabled = false;
            this.m_dtpCreateDate.Enabled = false;
        }
        #endregion

        #region 获取正确文本
        /// <summary>
        /// 获取正确文本
        /// </summary>
        /// <param name="m_strTest"></param>
        /// <param name="m_strXML"></param>
        /// <returns></returns>
        private string m_strGetRightText(string m_strText, string m_strXML)
        {
            return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strGetRightText(m_strText, m_strXML);
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
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return null;

            //从界面获取表单值		
            clsEMR_IntakeAndOutputVolumeSum objContent = new clsEMR_IntakeAndOutputVolumeSum();
            try
            {
                string StrNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objContent.m_dtmCreateDate = Convert.ToDateTime(StrNow);
                objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_dtmModifyDate = Convert.ToDateTime(StrNow);
                objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_strRegisterID = frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

                objContent.m_dtmRecordDate = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd 00:00:00"));

                objContent.m_strSPECIFICGRAVITY = m_txtSpecificGravity.Text;
                objContent.m_strSPECIFICGRAVITYXML = m_txtSpecificGravity.m_strGetXmlText();

                objContent.m_strALLURINE = m_txtAllUrine.Text;
                objContent.m_strALLURINEXML = m_txtAllUrine.m_strGetXmlText();

                objContent.m_strALLOUTPUT = m_txtAllOutput.Text;
                objContent.m_strALLOUTPUTXML = m_txtAllOutput.m_strGetXmlText();

                objContent.m_strALLINTAKE = m_txtAllIntake.Text;
                objContent.m_strALLINTAKEXML = m_txtAllIntake.m_strGetXmlText();

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
                        objContent.objSignerArr[j].m_strFORMID_VCHR = "frmIntakeAndOutputVolumeSummary";//注意大小写
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

        #region 把选择时间记录内容重新整理为完全正确的内容
        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsEMR_IntakeAndOutputVolumeSum objContent = (clsEMR_IntakeAndOutputVolumeSum)p_objRecordContent;
        }
        #endregion

        #region 获取护理记录的领域层实例
        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_IntakeAndOutputVolumeSum);
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

            return "出入量登记表总结";
        }
        #endregion

        #region 窗体ID
        public override int m_IntFormID
        {
            get
            {
                return 161;
            }
        }
        #endregion

        #region 计算总出入量并设置到界面
        /// <summary>
        /// 计算总出入量并设置到界面
        /// </summary>
        /// <param name="p_objValue">出入量情况</param>
        internal void m_mthCountAndSetToUI(clsPatient p_objPatient)
        {
            if (p_objPatient == null)
            {
                return;
            }

            Serv::clsEMR_IntakeAndOutputVolumeSumServ objServ =
                (Serv::clsEMR_IntakeAndOutputVolumeSumServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(Serv::clsEMR_IntakeAndOutputVolumeSumServ));

            clsEMR_IntakeAndOutputVolumeValue[] objValue = null;
            long lngRes = objServ.m_lngGetSpecifyInfo(p_objPatient.m_StrRegisterId, m_dtmRecordDate, out objValue);

            if (objValue == null || objValue.Length <= 0)
            {
                return;
            }

            string RegexText = @"^(-?\d+)(\.\d+)?$";
            double dblAllIn = 0;
            double dblAllUrine = 0;
            double dblAllOut = 0;

            for (int i = 0; i < objValue.Length; i++)
            {
                if (Regex.IsMatch(objValue[i].m_strSTOOL_RIGHT, RegexText))
                {
                    dblAllOut += double.Parse(objValue[i].m_strSTOOL_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strURINE_RIGHT, RegexText))
                {
                    dblAllOut += double.Parse(objValue[i].m_strURINE_RIGHT);
                    dblAllUrine += double.Parse(objValue[i].m_strURINE_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strGASTRICJUICE_RIGHT, RegexText))
                {
                    dblAllOut += double.Parse(objValue[i].m_strGASTRICJUICE_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strBILE_RIGHT, RegexText))
                {
                    dblAllOut += double.Parse(objValue[i].m_strBILE_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strINTESTINALJUICE_RIGHT, RegexText))
                {
                    dblAllOut += double.Parse(objValue[i].m_strINTESTINALJUICE_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strCHESTFLUID_RIGHT, RegexText))
                {
                    dblAllOut += double.Parse(objValue[i].m_strCHESTFLUID_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strOTHEROUTPUT_RIGHT, RegexText))
                {
                    dblAllOut += double.Parse(objValue[i].m_strOTHEROUTPUT_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strDRINKINGWATER_RIGHT, RegexText))
                {
                    dblAllIn += double.Parse(objValue[i].m_strDRINKINGWATER_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strFOOD_RIGHT, RegexText))
                {
                    dblAllIn += double.Parse(objValue[i].m_strFOOD_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strTRANSFUSION_RIGHT, RegexText))
                {
                    dblAllIn += double.Parse(objValue[i].m_strTRANSFUSION_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strSUGARWATER_RIGHT, RegexText))
                {
                    dblAllIn += double.Parse(objValue[i].m_strSUGARWATER_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strSALINEWATER_RIGHT, RegexText))
                {
                    dblAllIn += double.Parse(objValue[i].m_strSALINEWATER_RIGHT);
                }
                if (Regex.IsMatch(objValue[i].m_strOTHERINTAKE_RIGHT, RegexText))
                {
                    dblAllIn += double.Parse(objValue[i].m_strOTHERINTAKE_RIGHT);
                }
            }

            m_txtAllIntake.Text = dblAllIn.ToString();
            m_txtAllOutput.Text = dblAllOut.ToString();
            m_txtAllUrine.Text = dblAllUrine.ToString();
        } 
        #endregion
        #endregion
    }
}