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
   /// 内分泌科血糖观察表
   /// </summary>
    public partial class frmEMR_IntBloodSugarWatchcon : frmDiseaseTrackBase
    {
        #region 全局变量
        /// <summary>
        /// 定义签名类

        /// </summary>
        private clsEmrSignToolCollection m_objSign = null;
        #endregion
        public frmEMR_IntBloodSugarWatchcon()
        {
            InitializeComponent();
            m_objSign = new clsEmrSignToolCollection();

            //可以指定员工ID
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_mthSetRichTextBoxAttribInControl(this);
            m_mthThisAddRichTextInfo(this);
        }

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
        #region 方法、属性
        #region 窗体ID
        public override int m_IntFormID
        {
            get
            {
                return 191;
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

            return "内分泌科血糖观察表";
        }
        #endregion

        #region 获取护理记录的领域层实例
        /// <summary>
        /// 获取护理记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现

            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_IntBloodSugarWatch);
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

            clsEMR_intbloodsugarwatchValue objContent = (clsEMR_intbloodsugarwatchValue)p_objRecordContent;
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
            clsEMR_intbloodsugarwatchValue objContent = new clsEMR_intbloodsugarwatchValue();
            try
            {
                string StrNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objContent.m_dtmCreateDate = Convert.ToDateTime(StrNow);
                objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_dtmModifyDate = Convert.ToDateTime(StrNow);
                objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                objContent.m_strRegisterID = frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

                objContent.m_dtmRecordDate = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                //objContent.m_strCHECKRESULT_RIGHT = m_txtCheckResult.m_strGetRightText();
                //objContent.m_strCHECKRESULT_VCHR = m_txtCheckResult.Text;
                //objContent.m_strCHECKRESULT_XML = m_txtCheckResult.m_strGetXmlText();

                //objContent.m_strCHECKTIME_RIGHT = m_cboCheckTime.Text;
                //objContent.m_strCHECKTIME_VCHR = m_cboCheckTime.Text;
                //objContent.m_strCHECKTIME_XML = "<root />";

                objContent.m_strNULLABDOMEN_RIGHT = m_txtnullAbdon.m_strGetRightText();
                objContent.m_strNULLABDOMEN_VCHR = m_txtnullAbdon.Text;
                objContent.m_strNULLABDOMEN_XML = m_txtnullAbdon.m_strGetXmlText();

                objContent.m_strTWOBREAKFAST_RIGTH = m_txttwoBreakfast.m_strGetRightText();
                objContent.m_strTWOBREAKFAST_VCHR = m_txttwoBreakfast.Text;
                objContent.m_strTWOBREAKFAST_XML = m_txttwoBreakfast.m_strGetXmlText();

                objContent.m_strBEFORELUNCH_RIGHT = m_txtBeforeLunch.m_strGetRightText();
                objContent.m_strBEFORELUNCH_VCHR = m_txtBeforeLunch.Text;
                objContent.m_strBEFORELUNCH_XML = m_txtBeforeLunch.m_strGetXmlText();

                objContent.m_strTWOAFTERLUNCH_RIGHT = m_txttwoLunch.m_strGetRightText();
                objContent.m_strTWOAFTERLUNCH_VCHR = m_txttwoLunch.Text;
                objContent.m_strTWOAFTERLUNCH_XML = m_txttwoLunch.m_strGetXmlText();

                objContent.m_strBEFOREDINNER_RIGHT = m_txtBeforeDinner.m_strGetRightText();
                objContent.m_strBEFOREDINNER_VCHR = m_txtBeforeDinner.Text;
                objContent.m_strBEFOREDINNER_XML = m_txtBeforeDinner.m_strGetXmlText();


                objContent.m_strTWOAFTERDINNER_RIGHT = m_txttwoDinner.m_strGetRightText();
                objContent.m_strTWOAFTERDINNER_VCHR = m_txttwoDinner.Text;
                objContent.m_strTWOAFTERDINNER_XML = m_txttwoDinner.m_strGetXmlText();

                objContent.m_strBEFORESLEEP_RIGHT = m_txtBeforeSleep.m_strGetRightText();
                objContent.m_strBEFORESLEEP_VCHR = m_txtBeforeSleep.Text;
                objContent.m_strBEFORESLEEP_XML = m_txtBeforeSleep.m_strGetXmlText();

                objContent.m_strBEIZHU_RIGHT = m_txtBeizhu.m_strGetRightText();
                objContent.m_strBEIZHU_VCHR = m_txtBeizhu.Text;
                objContent.m_strBEIZHU_XML = m_txtBeizhu.m_strGetXmlText();

                #region 获取签名
                objContent.objSignerArr = null;
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);

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
            clsEMR_intbloodsugarwatchValue objContent = p_objContent as clsEMR_intbloodsugarwatchValue;

            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;

            //m_txtCheckResult.Text = objContent.m_strCHECKRESULT_RIGHT;
            //m_cboCheckTime.Text = objContent.m_strCHECKTIME_RIGHT;
            m_txtnullAbdon.Text = objContent.m_strNULLABDOMEN_RIGHT;
            m_txttwoBreakfast.Text = objContent.m_strTWOBREAKFAST_RIGTH;
            m_txtBeforeLunch.Text = objContent.m_strBEFORELUNCH_RIGHT;
            m_txttwoLunch.Text = objContent.m_strTWOAFTERLUNCH_RIGHT;
            m_txtBeforeDinner.Text = objContent.m_strBEFOREDINNER_RIGHT;
            m_txttwoDinner.Text = objContent.m_strTWOAFTERDINNER_RIGHT;
            m_txtBeforeSleep.Text = objContent.m_strBEFORESLEEP_RIGHT;
            m_txtBeizhu.Text = objContent.m_strBEIZHU_RIGHT;


            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }
            else
            {
                clsEmrEmployeeBase_VO objEMP = null;
                clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                long lngRes = objDomain.m_lngGetEmpByID(objContent.m_strCreateUserID, out objEMP);
                if (objEMP != null)
                {
                    ListViewItem lviNewItem = new ListViewItem(objEMP.m_strGetTechnicalRankAndName);
                    lviNewItem.SubItems.Add(objEMP.m_strEMPID_CHR);
                    lviNewItem.SubItems.Add(objEMP.m_StrHistroyLevel);
                    lviNewItem.Tag = objEMP;
                    lsvSign.Items.Add(lviNewItem);
                }
                objDomain = null;
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
            clsEMR_intbloodsugarwatchValue objContent = p_objContent as clsEMR_intbloodsugarwatchValue;
            m_cmdModifyPatientInfo.Visible = false;
            if (objContent == null)
                return;

            this.m_mthClearRecordInfo();

            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
            //m_txtCheckResult.m_mthSetNewText(objContent.m_strCHECKRESULT_VCHR, objContent.m_strCHECKRESULT_XML);
            //m_cboCheckTime.Text = objContent.m_strCHECKTIME_RIGHT;
            m_txtnullAbdon.m_mthSetNewText(objContent.m_strNULLABDOMEN_VCHR, objContent.m_strNULLABDOMEN_XML);
            m_txttwoBreakfast.m_mthSetNewText(objContent.m_strTWOBREAKFAST_VCHR, objContent.m_strTWOBREAKFAST_XML);
            m_txtBeforeLunch.m_mthSetNewText(objContent.m_strBEFORELUNCH_VCHR, objContent.m_strBEFORELUNCH_XML);
            m_txttwoLunch.m_mthSetNewText(objContent.m_strTWOAFTERLUNCH_VCHR, objContent.m_strTWOAFTERLUNCH_XML);
            m_txtBeforeDinner.m_mthSetNewText(objContent.m_strBEFOREDINNER_VCHR, objContent.m_strBEFOREDINNER_XML);
            m_txttwoDinner.m_mthSetNewText(objContent.m_strTWOAFTERDINNER_VCHR, objContent.m_strTWOAFTERDINNER_XML);
            m_txtBeforeSleep.m_mthSetNewText(objContent.m_strBEFORESLEEP_VCHR, objContent.m_strBEFORESLEEP_XML);
            m_txtBeizhu.m_mthSetNewText(objContent.m_strBEIZHU_VCHR, objContent.m_strBEIZHU_XML);

            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }
            else
            {
                lsvSign.Items.Clear();
                clsEmrEmployeeBase_VO objEMP = null;
                clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                long lngRes = objDomain.m_lngGetEmpByID(objContent.m_strCreateUserID, out objEMP);
                if (objEMP != null)
                {
                    ListViewItem lviNewItem = new ListViewItem(objEMP.m_strGetTechnicalRankAndName);
                    lviNewItem.SubItems.Add(objEMP.m_strEMPID_CHR);
                    lviNewItem.SubItems.Add(objEMP.m_StrHistroyLevel);
                    lviNewItem.Tag = objEMP;
                    lsvSign.Items.Add(lviNewItem);
                }
                objDomain = null;
            }
            #endregion 签名

            this.lsvSign.Enabled = false;
            this.m_cmdSign.Enabled = false;
        }
        #endregion

        #region 控制是否可以选择病人和记录时间列表

        /// <summary>
        /// 控制是否可以选择病人和记录时间列表

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

        #region 具体记录的特殊控制

        /// <summary>
        /// 具体记录的特殊控制,根据子窗体的需要重载实现

        /// </summary>
        /// <param name="p_blnEnable">是否允许修改特殊记录的记录信息</param>
        protected override void m_mthEnableModifySub(bool p_blnEnable)
        {
            m_dtpCreateDate.Enabled = true;
        }
        #endregion

        #region 设置是否控制修改(不实现)
        /// <summary>
        /// 设置是否控制修改(修改留痕迹)
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset">是否重置控制修改(修改留痕迹)
        ///如果为true,忽略记录内容,把界面控制设置为不控制

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
            m_dtpCreateDate.Value = DateTime.Now;

            //m_txtCheckResult.m_mthClearText();
            //m_cboCheckTime.Text = string.Empty;
            //m_cboCheckTime.SelectedIndex = -1;
            m_txtnullAbdon.m_mthClearText();
            m_txttwoBreakfast.m_mthClearText();
            m_txtBeforeLunch.m_mthClearText();
            m_txttwoLunch.m_mthClearText();
            m_txtBeforeDinner.m_mthClearText();
            m_txttwoDinner.m_mthClearText();
            m_txtBeforeSleep.m_mthClearText();
            m_txtBeizhu.m_mthClearText();
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
                new Control[] { m_txtnullAbdon, m_txttwoBreakfast, m_txtBeforeLunch, m_txttwoLunch, m_txtBeforeDinner, m_txttwoDinner, m_txtBeforeSleep, m_txtBeizhu }, Keys.Enter);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        #endregion

        private void frmEMR_IntBloodSugarWatchcon_Load(object sender, EventArgs e)
        {
            m_cmdModifyPatientInfo.Visible = false;
        }
    }
}