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

namespace iCare
{
    /// <summary>
    /// 出入量登记表(编辑窗体)
    /// </summary>
    public partial class frmIntakeAndOutputVolumeCon : frmDiseaseTrackBase
    {
        #region 全局变量
        /// <summary>
        /// 定义签名类
        /// </summary>
        private clsEmrSignToolCollection m_objSign = null;
        public string m_strOtherOutput_Name = string.Empty;
        public string m_strOtherIntake_Name = string.Empty;
        #endregion

        #region 构造函数
        /// <summary>
        /// 出入量登记表
        /// </summary>
        public frmIntakeAndOutputVolumeCon()
        {
            InitializeComponent();

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_mthSetRichTextBoxAttribInControl(this);
            string[] strTimeItems = new string[] { "上午七时至下午三时","下午三时至下午六时","下午六时至凌晨二时","凌晨二时至上午七时"};
            m_cboRecordTime.AddRangeItems(strTimeItems);
            m_mthThisAddRichTextInfo(this);
        }
        #endregion

        #region 事件
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (m_BlnIsAddNew)
            {
                if (m_blnCheckHasSameRecord())
                {
                    clsPublicFunction.ShowInformationMessageBox("已存在"+m_dtpCreateDate.Value.ToString("yyyy年MM月dd日")
                        +m_cboRecordTime.Text+"的记录，请选择其它时间段。");
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

        #region 检查是否已保存相同时间段的记录
        /// <summary>
        /// 检查是否已保存相同时间段的记录
        /// </summary>
        /// <returns></returns>
        private bool m_blnCheckHasSameRecord()
        {
            bool blnIsSame = false;
            Serv::clsEMR_IntakeAndOutputVolumeServ objServ =
                (Serv::clsEMR_IntakeAndOutputVolumeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(Serv::clsEMR_IntakeAndOutputVolumeServ));

            long lngRes = objServ.m_lngCheckHasSameRecord(m_objCurrentPatient.m_StrRegisterId,
                Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd 00:00:00")), m_cboRecordTime.Text, out blnIsSame);
            objServ = null;
            return blnIsSame;
        } 
        #endregion

        #region 窗体ID
        public override int m_IntFormID
        {
            get
            {
                return 160;
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

            return "出入量登记表";
        }
        #endregion

        #region 获取护理记录的领域层实例
        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_IntakeAndOutputVolume);
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
            clsEMR_IntakeAndOutputVolumeValue objContent = (clsEMR_IntakeAndOutputVolumeValue)p_objRecordContent;
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

            if (m_cboRecordTime.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("请选择一个时间段");
                return null;
            }
            //从界面获取表单值		
            clsEMR_IntakeAndOutputVolumeValue objContent = new clsEMR_IntakeAndOutputVolumeValue();
            try
            {
                string StrNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objContent.m_dtmCreateDate = Convert.ToDateTime(StrNow);
                objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_dtmModifyDate = Convert.ToDateTime(StrNow);
                objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_strRegisterID = frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

                objContent.m_dtmRecordDate = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd 00:00:00"));

                objContent.m_strRECORDTIME_VCHR = m_cboRecordTime.Text;

                objContent.m_strSTOOL_VCHR = m_txtStool.Text;
                objContent.m_strSTOOL_RIGHT = m_txtStool.m_strGetRightText();
                objContent.m_strSTOOL_XML = m_txtStool.m_strGetXmlText();

                objContent.m_strURINE_VCHR = m_txtUrine.Text;
                objContent.m_strURINE_RIGHT = m_txtUrine.m_strGetRightText();
                objContent.m_strURINE_XML = m_txtUrine.m_strGetXmlText();

                objContent.m_strGASTRICJUICE_VCHR = m_txtGastrisJuice.Text;
                objContent.m_strGASTRICJUICE_RIGHT = m_txtGastrisJuice.m_strGetRightText();
                objContent.m_strGASTRICJUICE_XML = m_txtGastrisJuice.m_strGetXmlText();

                objContent.m_strBILE_VCHR = m_txtBile.Text;
                objContent.m_strBILE_RIGHT = m_txtBile.m_strGetRightText();
                objContent.m_strBILE_XML = m_txtBile.m_strGetXmlText();

                objContent.m_strINTESTINALJUICE_VCHR = m_txtIntestinalJuice.Text;
                objContent.m_strINTESTINALJUICE_RIGHT = m_txtIntestinalJuice.m_strGetRightText();
                objContent.m_strINTESTINALJUICE_XML = m_txtIntestinalJuice.m_strGetXmlText();

                objContent.m_strCHESTFLUID_VCHR = m_txtChestFluid.Text;
                objContent.m_strCHESTFLUID_RIGHT = m_txtChestFluid.m_strGetRightText();
                objContent.m_strCHESTFLUID_XML = m_txtChestFluid.m_strGetXmlText();

                objContent.m_strOTHEROUTPUT_VCHR = m_txtOtherOutput.Text;
                objContent.m_strOTHEROUTPUT_RIGHT = m_txtOtherOutput.m_strGetRightText();
                objContent.m_strOTHEROUTPUT_XML = m_txtOtherOutput.m_strGetXmlText();

                objContent.m_strDRINKINGWATER_VCHR = m_txtDrinkingWater.Text;
                objContent.m_strDRINKINGWATER_RIGHT = m_txtDrinkingWater.m_strGetRightText();
                objContent.m_strDRINKINGWATER_XML = m_txtDrinkingWater.m_strGetXmlText();

                objContent.m_strFOOD_VCHR = m_txtFood.Text;
                objContent.m_strFOOD_RIGHT = m_txtFood.m_strGetRightText();
                objContent.m_strFOOD_XML = m_txtFood.m_strGetXmlText();

                objContent.m_strTRANSFUSION_VCHR = m_txtTransfusion.Text;
                objContent.m_strTRANSFUSION_RIGHT = m_txtTransfusion.m_strGetRightText();
                objContent.m_strTRANSFUSION_XML = m_txtTransfusion.m_strGetXmlText();

                objContent.m_strSUGARWATER_VCHR = m_txtSugarWater.Text;
                objContent.m_strSUGARWATER_RIGHT = m_txtSugarWater.m_strGetRightText();
                objContent.m_strSUGARWATER_XML = m_txtSugarWater.m_strGetXmlText();

                objContent.m_strSALINEWATER_VCHR = m_txtSalineWater.Text;
                objContent.m_strSALINEWATER_RIGHT = m_txtSalineWater.m_strGetRightText();
                objContent.m_strSALINEWATER_XML = m_txtSalineWater.m_strGetXmlText();

                objContent.m_strOTHERINTAKE_VCHR = m_txtOtherIntake.Text;
                objContent.m_strOTHERINTAKE_RIGHT = m_txtOtherIntake.m_strGetRightText();
                objContent.m_strOTHERINTAKE_XML = m_txtOtherIntake.m_strGetXmlText();

                objContent.m_intINDEX_INT = m_cboRecordTime.SelectedIndex;
                #region 获取签名
                objContent.objSignerArr = null;
                string strRecorderIDList = string.Empty;
                string strUserNameList = string.Empty;
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strRecorderIDList, ref strUserNameList);
                
                objContent.m_strRecordUserID = strRecorderIDList;
                #endregion

                if (!string.IsNullOrEmpty(m_strOtherOutput_Name) && m_strOtherOutput_Name != "出量其他")
                {
                    objContent.m_strOTHEROUTPUT_NAME = m_strOtherOutput_Name;
                }
                if (!string.IsNullOrEmpty(m_strOtherIntake_Name) && m_strOtherIntake_Name != "入量其他")
                {
                    objContent.m_strOTHERINTAKE_NAME = m_strOtherIntake_Name;
                }
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
            clsEMR_IntakeAndOutputVolumeValue objContent = p_objContent as clsEMR_IntakeAndOutputVolumeValue;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            m_txtStool.Text = objContent.m_strSTOOL_RIGHT;
            m_txtUrine.Text = objContent.m_strURINE_RIGHT;
            m_txtGastrisJuice.Text = objContent.m_strGASTRICJUICE_RIGHT;
            m_txtBile.Text = objContent.m_strBILE_RIGHT;
            m_txtIntestinalJuice.Text = objContent.m_strINTESTINALJUICE_RIGHT;
            m_txtChestFluid.Text = objContent.m_strCHESTFLUID_RIGHT;
            m_txtOtherOutput.Text = objContent.m_strOTHEROUTPUT_RIGHT;
            m_txtDrinkingWater.Text = objContent.m_strDRINKINGWATER_RIGHT;
            m_txtFood.Text = objContent.m_strFOOD_RIGHT;
            m_txtTransfusion.Text = objContent.m_strTRANSFUSION_RIGHT;
            m_txtSugarWater.Text = objContent.m_strSUGARWATER_RIGHT;
            m_txtSalineWater.Text = objContent.m_strSALINEWATER_RIGHT;
            m_txtOtherIntake.Text = objContent.m_strOTHERINTAKE_RIGHT;

            m_cboRecordTime.SelectedIndex = objContent.m_intINDEX_INT;
            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }
            #endregion 签名

            this.lsvSign.Enabled = false;
            this.m_cmdSign.Enabled = false;
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
            clsEMR_IntakeAndOutputVolumeValue objContent = p_objContent as clsEMR_IntakeAndOutputVolumeValue;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            m_txtStool.m_mthSetNewText(objContent.m_strSTOOL_VCHR,objContent.m_strSTOOL_XML);
            m_txtUrine.m_mthSetNewText(objContent.m_strURINE_VCHR,objContent.m_strURINE_XML);
            m_txtGastrisJuice.m_mthSetNewText(objContent.m_strGASTRICJUICE_VCHR,objContent.m_strGASTRICJUICE_XML);
            m_txtBile.m_mthSetNewText(objContent.m_strBILE_VCHR,objContent.m_strBILE_XML);
            m_txtIntestinalJuice.m_mthSetNewText(objContent.m_strINTESTINALJUICE_VCHR,objContent.m_strINTESTINALJUICE_XML);
            m_txtChestFluid.m_mthSetNewText(objContent.m_strCHESTFLUID_VCHR,objContent.m_strCHESTFLUID_XML);
            m_txtOtherOutput.m_mthSetNewText(objContent.m_strOTHEROUTPUT_VCHR,objContent.m_strOTHEROUTPUT_XML);
            m_txtDrinkingWater.m_mthSetNewText(objContent.m_strDRINKINGWATER_VCHR,objContent.m_strDRINKINGWATER_XML);
            m_txtFood.m_mthSetNewText(objContent.m_strFOOD_VCHR,objContent.m_strFOOD_XML);
            m_txtTransfusion.m_mthSetNewText(objContent.m_strTRANSFUSION_VCHR,objContent.m_strTRANSFUSION_XML);
            m_txtSugarWater.m_mthSetNewText(objContent.m_strSUGARWATER_VCHR,objContent.m_strSUGARWATER_XML);
            m_txtSalineWater.m_mthSetNewText(objContent.m_strSALINEWATER_VCHR,objContent.m_strSALINEWATER_XML);
            m_txtOtherIntake.m_mthSetNewText(objContent.m_strOTHERINTAKE_VCHR,objContent.m_strOTHERINTAKE_XML);

            m_cboRecordTime.SelectedIndex = objContent.m_intINDEX_INT;
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
            this.m_dtpCreateDate.Enabled = true;
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
        #region 具体记录的特殊控制(不实现)
        /// <summary>
        /// 具体记录的特殊控制,根据子窗体的需要重载实现
        /// </summary>
        /// <param name="p_blnEnable">是否允许修改特殊记录的记录信息。</param>
        protected override void m_mthEnableModifySub(bool p_blnEnable)
        {
            m_dtpCreateDate.Enabled = true;
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

            m_txtStool.m_mthClearText();
            m_txtUrine.m_mthClearText();
            m_txtGastrisJuice.m_mthClearText();
            m_txtBile.m_mthClearText();
            m_txtIntestinalJuice.m_mthClearText();
            m_txtChestFluid.m_mthClearText();
            m_txtOtherOutput.m_mthClearText();
            m_txtDrinkingWater.m_mthClearText();
            m_txtFood.m_mthClearText();
            m_txtTransfusion.m_mthClearText();
            m_txtSugarWater.m_mthClearText();
            m_txtSalineWater.m_mthClearText();
            m_txtOtherIntake.m_mthClearText();
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
                new Control[] { m_txtStool, m_txtUrine, m_txtGastrisJuice, m_txtBile, m_txtIntestinalJuice, m_txtChestFluid ,
                m_txtOtherOutput,m_txtDrinkingWater,m_txtFood,m_txtTransfusion,m_txtSugarWater,m_txtSalineWater,m_txtOtherIntake}, Keys.Enter);
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