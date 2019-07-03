using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
using iCareData;
using Microsoft.VisualBasic;
using com.digitalwave.DiseaseTrackService;

namespace iCare
{
    /// <summary>
    /// 通用ICU护理记录表单具体内容
    /// </summary>
    public partial class frmICUNurseRecordContent : frmDiseaseTrackBase
    {

        #region 字段
        public bool blnEdit = false;
        /// <summary>
        /// 当前病人的入院登记号
        /// </summary>
        public string mstrRegisterID;
        /// <summary>
        /// 当前记录的创建时间
        /// </summary>
        public DateTime dtCreatedate;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;

        /// <summary>
        /// 显示方式 0 显示记录 1 显示呼吸记录 2显示病程内容
        /// </summary>
        public int intDisplayMode = 0;

        /// <summary>
        /// 术后天数
        /// </summary>
        public string strAfterdays;
        public string strWeight;
        public string strOperationName;

        /// <summary>
        /// 液体设定 辅助
        /// </summary>
        public string strLIQUID1;
        public string strLIQUID2;
        public string strLIQUID3;
        public string strLIQUID4;
        public string strLIQUID5;

        /// <summary>
        /// 引液设定 辅助
        /// </summary>
        public string strDRAIN1;
        public string strDRAIN2;
        public string strDRAIN3;
        public string strDRAIN4;
        public string strDRAIN5;

        /// <summary>
        /// 当前转科流水号
        /// </summary>
        private string m_strTransferID = string.Empty;
        /// <summary>
        /// 是否新添记录
        /// </summary>
        public bool m_blnIsAddNew = true;
        /// <summary>
        /// 以前的入量累计
        /// </summary>
        private double m_dblCountINBefore = 0;
        /// <summary>
        /// 以前的出量累计
        /// </summary>
        private double m_dblCountOUTBefore = 0;
        /// <summary>
        /// 以前的小便总量
        /// </summary>
        private double m_dblPissTotalBefore = 0;
        /// <summary>
        /// 以前的大便总量
        /// </summary>
        private double m_dblStoolTotalBefore = 0;
        /// <summary>
        /// 当天第一条记录的记录时间
        /// </summary>
        private DateTime m_dtmFirstRecordDate = DateTime.MinValue;
        #endregion

        #region 构造函数
       /// <summary>
        /// 构造函数
       /// </summary>
        /// <param name="p_strTransferID">当前转科流水号</param>
        /// <param name="p_dtmFirstRecord">当天第一条记录的记录时间</param>
        public frmICUNurseRecordContent(string p_strTransferID,DateTime p_dtmFirstRecord)
        {
            InitializeComponent();

            m_strTransferID = p_strTransferID;
            m_dtmFirstRecordDate = p_dtmFirstRecord;
            //指明护士工作站表单
            intFormType = 2;
            //绑定richtextbox信息
            m_mthSetRichTextBoxAttribInControl(this);

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_mthSetComboBoxItem();
            m_mthThisAddRichTextInfo(this);
        } 
        #endregion

        /// <summary>
        /// 设置界面上固定选项的ComboBOx
        /// </summary>
        private void m_mthSetComboBoxItem()
        {
            m_cboCONSCIOUSNESS.AddRangeItems(new string[] { "清醒", "嗜睡", "朦胧", "浅昏迷", "深昏迷", "昏迷" });
            m_cboPupilSizeLeft.AddRangeItems(new string[] { "1", "2", "3", "4", "5" });
            m_cboPupilSizeRight.AddRangeItems(new string[] { "1", "2", "3", "4", "5" });
            m_cboReflectLeft.AddRangeItems(new string[] { "消失", "灵敏", "迟钝" });
            m_cboReflectRight.AddRangeItems(new string[] { "消失", "灵敏", "迟钝" });
        }

        #region 保存记录
        /// <summary>
        ///  保存记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (m_dtmFirstRecordDate != DateTime.MinValue && m_dtpCreateDate.Value.Date != m_dtmFirstRecordDate.Date)
            {
                DialogResult dr = MessageBox.Show("当前选定记录日期" + m_dtpCreateDate.Value.ToString("yyyy年MM月dd日") + "与当天第一条记录的记录日期" + m_dtmFirstRecordDate.ToString("yyyy年MM月dd日") + "不同，是否继续保存？", "通用ICU护理记录", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        } 
        #endregion

        #region 退出记录
        /// <summary>
        /// 退出记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            Close();
        } 
        #endregion

        #region 事件
        /// <summary>
        /// 窗体启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmICUNurseRecordContent_Load(object sender, EventArgs e)
        {
            lblAfterDays.Text = strAfterdays;
            if (intDisplayMode == 2)
            {
                m_tabMain.TabPages.Remove(tabPage1);
                m_tabMain.TabPages.Remove(tabPage2);

            }

            if (m_BlnIsAddNew)
            {
                m_mthGetTotalBefore(DateTime.MinValue);
                m_mthCountIN();
                m_mthCountOUT();
            }
            
            //if ( blnEdit)
            //{
            //  //获取记录
            //    try
            //    {
            //        this.Cursor = Cursors.WaitCursor;
            //        clsICUNurseService objservice = new clsICUNurseService();
            //         clsICUNurseRecord objContent = new clsICUNurseRecord();
            //         objservice.m_lngGetRecordContent(null, mstrRegisterID, dtCreatedate.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), out m_objCurrentRecordContent);
            //         m_mthSetGUIFromContent(m_objCurrentRecordContent);

            //    }
            //    finally
            //    {
            //        this.Cursor = Cursors.Default;

            //    }
            //}
        } 
        #endregion

        #region 重写方法

        public override clsTrackRecordContent m_objGetRecordContent(clsPatient p_objSelectedPatient, string p_strOpenDate)
        {
            //获取记录
            try
            {
                this.Cursor = Cursors.WaitCursor;

                clsICUNurseService objservice =
                    (clsICUNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseService));

                clsICUNurseRecord objContent = new clsICUNurseRecord();
                objservice.m_lngGetRecordContent(null, mstrRegisterID, dtCreatedate.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), out m_objCurrentRecordContent);

            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
            return m_objCurrentRecordContent;
        }
        /// <summary>
        /// 获取记录信息
        /// 用于在列表中处理。该表单可以忽略
        /// </summary>
        /// <returns></returns>
        public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            
            return null;
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

            //清空具体记录内容

            #region MyRegion
            // 体温
            this.m_txtTEMPERATURE.m_mthClearText();
            //末体温
            this.m_txtENDTEMPERATURE.m_mthClearText();
            //心率
            this.m_txtHR.m_mthClearText();
            //心律
            this.m_txtRHYTHM.m_mthClearText();
            //血压s
            this.m_txtBPS.m_mthClearText();
            //血压D
            this.m_txtBPD.m_mthClearText();
            //ABP
            this.m_txtABP.m_mthClearText();
            //CVP
            this.m_txtCVP.m_mthClearText();
            //sp02
            this.m_txtSpo2.m_mthClearText();
            //意识
            this.m_cboCONSCIOUSNESS.Text="";
            //瞳孔　左
            //this.m_cboPupilSizeLeft.SelectedIndex = -1;
            this.m_cboPupilSizeLeft.Text = "";
            //瞳孔　右
            //this.m_cboPupilSizeRight.SelectedIndex = -1;
            this.m_cboPupilSizeRight.Text = "";
            //对光反射左
            //this.m_cboReflectLeft.SelectedIndex = -1;
            this.m_cboReflectLeft.Text = "";
            //对光反射右
            //this.m_cboReflectRight.SelectedIndex = -1;
            this.m_cboReflectRight.Text = "";
            // 血管活性药物
            //this.m_cboVASOAACTIVE.SelectedIndex = -1;
            this.m_cboVASOAACTIVE.Text = "";
            //强心利尿药
            //this.m_cboCARDIACDIURETIC.SelectedIndex = -1;
            this.m_cboCARDIACDIURETIC.Text = "";
            //液体1
            this.m_txtLIQUID1.m_mthClearText();
            //液体2
            this.m_txtLIQUID2.m_mthClearText();
            //液体3
            this.m_txtLIQUID3.m_mthClearText();
            //液体4
            this.m_txtLIQUID4.m_mthClearText();
            //液体5
            this.m_txtLIQUID5.m_mthClearText();
            //全血
            this.m_txtFullBlood.m_mthClearText();
            ///血浆
            this.m_txtPLASMA.m_mthClearText();
            //鼻饲
            this.m_txtNOSE1.m_mthClearText();
            //鼻进
            this.m_txtNOSE2.m_mthClearText();
            //每小时总量
            this.m_txtInperhour.m_mthClearText();
            //累计总量
            this.m_txtIntotalAll.m_mthClearText();
            //小便
            this.m_txtstool.m_mthClearText();
            //小便累计
            this.m_txtStooltoalall.m_mthClearText();
            //大便
            this.m_txtPISS.m_mthClearText();
            //大便累计
            this.m_txtPISStoal.m_mthClearText();
            //引液1
            this.m_txtDRAIN1.m_mthClearText();
            //引液2
            this.m_txtDRAIN2.m_mthClearText();
            //引液3
            this.m_txtDRAIN3.m_mthClearText();
            //引液4
            this.m_txtDRAIN4.m_mthClearText();
            //引液5
            this.m_txtDRAIN5.m_mthClearText();
            //每小时引液累计
            this.m_txtouthour.m_mthClearText();
            //引液总量累计
            this.m_txtouttoalall.m_mthClearText();
            //体位
            this.cmbPOSTURE.Text = "";
            //皮肤
            this.cmbskin.Text = "";
            //痰色
            this.cmbSPUTUM.Text = "";
            //痰量
            this.cmbSPUTUM1.Text = "";
            //吸痰
            this.cmbSUCKER.Text = "";
            //口腔护理
            this.cmbORAL.Text = "";
            //会阴冲洗
            this.cmbPERINEUM.Text = "";
            //体疗
            this.cmbGESTICULATION.Text = "";
            //擦浴
            this.cmbSPONGEBATH.Text = "";
            //PT
            this.m_txtPT.m_mthClearText();
            //ACT
            this.m_txtACT.m_mthClearText();
            //GlU
            this.m_txtglu.m_mthClearText();
            //K
            this.m_txtKplus.m_mthClearText();
            //Na＋
            this.m_txtNa.m_mthClearText();
            //CL-
            this.m_txtCI.m_mthClearText();
            //Ca＋＋
            this.m_txtcaplus.m_mthClearText();
            //通气模式
            this.m_cboBREATHMACHINE.Text = "";
            //PEE
            this.m_txtPEE.m_mthClearText();
            //TV/Ti
            this.m_txtTVTi.m_mthClearText();
            //频率
            this.m_txtFREQUENCY.m_mthClearText();
            //氧浓度
            this.m_txto2.m_mthClearText();
            //灵敏度
            this.m_txtSENSEIIVE.m_mthClearText();
            //流速
            this.m_txtSPEED.m_mthClearText();
            //I:E
            this.m_txtIE.m_mthClearText();
            //气道压力
            this.m_txtGASPRESS.m_mthClearText();
            //TV
            this.m_txtTV.m_mthClearText();
            //MV
            this.m_txtMV.m_mthClearText();
            //管道压力
            this.m_txtPIPEDEPTH.m_mthClearText();
            //气囊压力
            this.m_txtAIRCELLPRESS.m_mthClearText();
            //ETCO2
            this.m_txtETCO2.m_mthClearText();
            //PH
            this.m_txtPH.m_mthClearText();
            //m_txtPCO2
            this.m_txtPCO2.m_mthClearText();
            //m_txtPAO2
            this.m_txtPAO2.m_mthClearText();
            //m_txtHCO3
            this.m_txtHCO3.m_mthClearText();
            //m_txtBE
            this.m_txtBE.m_mthClearText();
            //护理内容
            this.m_txtContent.m_mthClearText();
            //呼吸
            this.m_txtRespiration.m_mthClearText();
            #endregion

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
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsICUNurseRecord objContent = (clsICUNurseRecord)p_objContent;

            this.m_mthClearRecordInfo();

            #region 把表单值赋值到界面
            m_mthGetTotalBefore(objContent.m_dtmRecordDate);
            m_strTransferID = objContent.m_strTRANSFERID;
            this.lblAfterDays.Text=objContent.m_strAFTEROPDAYS;
            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
            // 体温
            this.m_txtTEMPERATURE.m_mthSetNewText(objContent.m_strTEMPERATURE, objContent.m_strTEMPERATUREXML);
            //末体温
            this.m_txtENDTEMPERATURE.m_mthSetNewText(objContent.m_strENDTEMPERATURE, objContent.m_strENDTEMPERATUREXML);
            //心率
            this.m_txtHR.m_mthSetNewText(objContent.m_strHR, objContent.m_strHRXML);
            //心律
            this.m_txtRHYTHM.m_mthSetNewText(objContent.m_strRHYTHM, objContent.m_strRHYTHMXML);
            //呼吸
            this.m_txtRespiration.m_mthSetNewText(objContent.m_strRESPIRATION, objContent.m_strRESPIRATIONXML);
            //血压s
            this.m_txtBPS.m_mthSetNewText(objContent.m_strBPS, objContent.m_strBPSXML);
            //血压D
            this.m_txtBPD.m_mthSetNewText(objContent.m_strBPD, objContent.m_strBPDXML);
            //ABP
            this.m_txtABP.m_mthSetNewText(objContent.m_strABP, objContent.m_strABPXML);
            //CVP
            this.m_txtCVP.m_mthSetNewText(objContent.m_strCVP, objContent.m_strCVPXML);
            //sp02
            this.m_txtSpo2.m_mthSetNewText(objContent.m_strSPO2, objContent.m_strSPO2XML);
            //意识
            this.m_cboCONSCIOUSNESS.Text=objContent.m_strCONSCIOUSNESS;
            //瞳孔　左
            this.m_cboPupilSizeLeft.Text=objContent.m_strPUPIL;
            //瞳孔　右
            this.m_cboPupilSizeRight.Text=objContent.m_strPUPIR;
            //对光反射左
            this.m_cboReflectLeft.Text=objContent.m_strLIGHTREFLEXL;
            //对光反射右
            this.m_cboReflectRight.Text=objContent.m_strLIGHTREFLEXR;
            // 血管活性药物
            this.m_cboVASOAACTIVE.Text=objContent.m_strVASOAACTIVE;
            //强心利尿药
            this.m_cboCARDIACDIURETIC.Text=objContent.m_strCARDIACDIURETIC;
            //液体1
            this.m_txtLIQUID1.m_mthSetNewText(objContent.m_strLIQUID1, objContent.m_strLIQUID1XML);
            //液体2
            this.m_txtLIQUID2.m_mthSetNewText(objContent.m_strLIQUID2, objContent.m_strLIQUID2XML);
            //液体3
            this.m_txtLIQUID3.m_mthSetNewText(objContent.m_strLIQUID3, objContent.m_strLIQUID3XML);
            //液体4
            this.m_txtLIQUID4.m_mthSetNewText(objContent.m_strLIQUID4, objContent.m_strLIQUID4XML);
            //液体5
            this.m_txtLIQUID5.m_mthSetNewText(objContent.m_strLIQUID5, objContent.m_strLIQUID5XML);
            //全血
            this.m_txtFullBlood.m_mthSetNewText(objContent.m_strFBOOL, objContent.m_strFBOOLXML);
            ///血浆
            this.m_txtPLASMA.m_mthSetNewText(objContent.m_strPLASMA, objContent.m_strPLASMAXML);
            //鼻饲
            this.m_txtNOSE1.m_mthSetNewText(objContent.m_strNOSE1, objContent.m_strNOSE1XML);
            //鼻进
            this.m_txtNOSE2.m_mthSetNewText(objContent.m_strNOSE2, objContent.m_strNOSE2XML);
            //每小时总量
            this.m_txtInperhour.m_mthSetNewText(objContent.m_strINPERHOUR, objContent.m_strINPERHOURXML);
            //累计总量
            this.m_txtIntotalAll.m_mthSetNewText(objContent.m_strINTOTAL, objContent.m_strINTOTALXML);
            //小便
            this.m_txtstool.m_mthSetNewText(objContent.m_strSTOOL, objContent.m_strSTOOLXML);
            //小便累计
            this.m_txtStooltoalall.m_mthSetNewText(objContent.m_strSTOOLTOTAL, objContent.m_strSTOOLTOTALXML);
            //大便
            this.m_txtPISS.m_mthSetNewText(objContent.m_strPISS, objContent.m_strPISSXML);
            //大便累计
            this.m_txtPISStoal.m_mthSetNewText(objContent.m_strPISSTOTAL, objContent.m_strPISSTOTALXML);
            //引液1
            this.m_txtDRAIN1.m_mthSetNewText(objContent.m_strDRAIN1, objContent.m_strDRAIN1XML);
            //引液2
            this.m_txtDRAIN2.m_mthSetNewText(objContent.m_strDRAIN2, objContent.m_strDRAIN2XML);
            //引液3
            this.m_txtDRAIN3.m_mthSetNewText(objContent.m_strDRAIN3, objContent.m_strDRAIN3XML);
            //引液4
            this.m_txtDRAIN4.m_mthSetNewText(objContent.m_strDRAIN4, objContent.m_strDRAIN4XML);
            //引液5
            this.m_txtDRAIN5.m_mthSetNewText(objContent.m_strDRAIN5, objContent.m_strDRAIN5XML);
            //每小时引液累计
            this.m_txtouthour.m_mthSetNewText(objContent.m_strOUTPERHOUR, objContent.m_strOUTPERHOURXML);
            //引液总量累计
            this.m_txtouttoalall.m_mthSetNewText(objContent.m_strOUTTOTAL, objContent.m_strOUTTOTALXML);
            //体位
            this.cmbPOSTURE.Text = objContent.m_strPOSTURE;
            //皮肤
            this.cmbskin.Text = objContent.m_strSKIN;
            //痰色
            this.cmbSPUTUM.Text = objContent.m_strSPUTUM;
            //痰量
            this.cmbSPUTUM1.Text = objContent.m_strSPUTUM1;
            //吸痰
            this.cmbSUCKER.Text = objContent.m_strSUCKER;
            //口腔护理
            this.cmbORAL.Text = objContent.m_strORAL;
            //会阴冲洗
            this.cmbPERINEUM.Text = objContent.m_strPERINEUM;
            //体疗
            this.cmbGESTICULATION.Text = objContent.m_strGESTICULATION;
            //擦浴
            this.cmbSPONGEBATH.Text = objContent.m_strSPONGEBATH;
            //PT
            this.m_txtPT.m_mthSetNewText(objContent.m_strPT, objContent.m_strPTXML);
            //ACT
            this.m_txtACT.m_mthSetNewText(objContent.m_strACT, objContent.m_strACTXML);
            //GlU
            this.m_txtglu.m_mthSetNewText(objContent.m_strGLU, objContent.m_strGLUXML);
            //K
            this.m_txtKplus.m_mthSetNewText(objContent.m_strK, objContent.m_strKXML);
            //Na＋
            this.m_txtNa.m_mthSetNewText(objContent.m_strNAPLUS, objContent.m_strNAPLUSXML);
            //CL-
            this.m_txtCI.m_mthSetNewText(objContent.m_strCL, objContent.m_strCLXML);
            //Ca＋＋
            this.m_txtcaplus.m_mthSetNewText(objContent.m_strCAPLUS2, objContent.m_strCAPLUS2XML);
            //通气模式
            this.m_cboBREATHMACHINE.Text=objContent.m_strMMODEL;
            //PEE
            this.m_txtPEE.m_mthSetNewText(objContent.m_strPEE, objContent.m_strPEEXML);
            //TV/Ti
            this.m_txtTVTi.m_mthSetNewText(objContent.m_strTVTI, objContent.m_strTVTIXML);
            //频率
            this.m_txtFREQUENCY.m_mthSetNewText(objContent.m_strFREQUENCY, objContent.m_strFREQUENCYXML);
            //氧浓度
            this.m_txto2.m_mthSetNewText(objContent.m_strO2, objContent.m_strO2XML);
            //灵敏度
            this.m_txtSENSEIIVE.m_mthSetNewText(objContent.m_strSENSEIIVE, objContent.m_strSENSEIIVEXML);
            //流速
            this.m_txtSPEED.m_mthSetNewText(objContent.m_strSPEED, objContent.m_strSPEEDXML);
            //I:E
            this.m_txtIE.m_mthSetNewText(objContent.m_strIE, objContent.m_strIEXML);
            //气道压力
            this.m_txtGASPRESS.m_mthSetNewText(objContent.m_strGASPRESS, objContent.m_strGASPRESSXML);
            //TV
            this.m_txtTV.m_mthSetNewText(objContent.m_strTV, objContent.m_strTVXML);
            //MV
            this.m_txtMV.m_mthSetNewText(objContent.m_strMV, objContent.m_strMVXML);
            //管道压力
            this.m_txtPIPEDEPTH.m_mthSetNewText(objContent.m_strPIPEDEPTH, objContent.m_strPIPEDEPTHXML);
            //气囊压力
            this.m_txtAIRCELLPRESS.m_mthSetNewText(objContent.m_strAIRCELLPRESS, objContent.m_strAIRCELLPRESSXML);
            //ETCO2
            this.m_txtETCO2.m_mthSetNewText(objContent.m_strETCO2, objContent.m_strETCO2XML);
            //PH
            this.m_txtPH.m_mthSetNewText(objContent.m_strPH, objContent.m_strPHXML);
            //m_txtPCO2
            this.m_txtPCO2.m_mthSetNewText(objContent.m_strPCO2, objContent.m_strPCO2XML);
            //m_txtPAO2
            this.m_txtPAO2.m_mthSetNewText(objContent.m_strPAO2, objContent.m_strPAO2XML);
            //m_txtHCO3
            this.m_txtHCO3.m_mthSetNewText(objContent.m_strHCO3, objContent.m_strHCO3XML);
            //m_txtBE
            this.m_txtBE.m_mthSetNewText(objContent.m_strBE, objContent.m_strBEXML);
            //护理内容
            this.m_txtContent.m_mthSetNewText(objContent.objRecordContent.m_strCONTENT, objContent.objRecordContent.m_strCONTENTXML);

            #endregion

            #region 签名集合
            lsvSign.Clear();
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

            this.m_dtpCreateDate.Enabled = false;
        }

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

        /// <summary>
        /// 获取护理记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.ICUNurseRecord);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsCardiovascularTend_GX objContent = (clsCardiovascularTend_GX)p_objRecordContent;
        }
        /// <summary>
        /// 从界面获取值for save
        /// </summary>
        /// <returns></returns>
        protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
        {
            //界面参数校验
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return null;

            #region 从界面获取表单值
            clsICUNurseRecord objContent = new clsICUNurseRecord();
            objContent.objRecordContent = new clsICUNurseRecordContent();
            try
            {
                objContent.objRecordContent.m_strRegisterID = mstrRegisterID;
                objContent.m_strRegisterID = mstrRegisterID;
                objContent.m_dtmCreateDate = dtCreatedate;//此时间中间端会重新赋值 取中间件端时间
                objContent.m_strCreateUserID =  clsEMRLogin.LoginInfo.m_strEmpID;//取的登录者ID
                objContent.objRecordContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;//取的登录者ID
                objContent.objRecordContent.m_dtmCreateDate = dtCreatedate;//此时间中间端会重新赋值 取中间件端时间
                objContent.m_dtmDeActivedDate = DateTime.Now;//默认，没有删除 则操作者为空
                objContent.m_strDeActivedOperatorID = "";
                objContent.m_dtmFirstPrintDate = DateTime.Now;//默认;
                objContent.m_bytStatus =1;//表明新建有效单
                objContent.objRecordContent.m_bytStatus = 1;//表明新建有效单
                objContent.objRecordContent.m_intMarkStatus = 0;//表明新建可以无痕迹修改
                objContent.m_dtmRecordDate =m_dtpCreateDate.Value;//记录时间 取界面时间
                objContent.objRecordContent.m_dtmRecordDate = m_dtpCreateDate.Value;//记录时间 取界面时间
                objContent.m_bytIfConfirm =0;//默认未审核
                objContent.objRecordContent.m_bytIfConfirm = 0;//默认未审核
                objContent.m_strTRANSFERID = m_strTransferID;
                objContent.objRecordContent.m_strTRANSFERID = m_strTransferID;

                #region 是否可以无痕迹修改
                if (chkModifyWithoutMatk.Checked)
                {
                    objContent.m_intMarkStatus = 0;//表明新建可以无痕迹修改
                    objContent.objRecordContent.m_intMarkStatus = 0;
                }
                else
                {
                    objContent.m_intMarkStatus = 1;
                    objContent.objRecordContent.m_intMarkStatus = 1;
                }
                #endregion

                #region 获取预设值
                objContent.m_strOPNAME = strOperationName;
                objContent.m_strWEIGHT = strWeight;
                objContent.m_strAFTEROPDAYS = strAfterdays;
                //液体
                objContent.m_strLIQUID1D = strLIQUID1;
                objContent.m_strLIQUID2D = strLIQUID2;
                objContent.m_strLIQUID3D = strLIQUID3;
                objContent.m_strLIQUID4D = strLIQUID4;
                objContent.m_strLIQUID5D = strLIQUID5;
                //引液
                objContent.m_strDRAIN1D = strDRAIN1;
                objContent.m_strDRAIN2D = strDRAIN2;
                objContent.m_strDRAIN3D = strDRAIN3;
                objContent.m_strDRAIN4D = strDRAIN4;
                objContent.m_strDRAIN5D = strDRAIN5;
                #endregion

                #region 获取签名
                int intSignCount=lsvSign.Items.Count;
 			    //获取lsvsign签名
			    objContent.objSignerArr=new clsEmrSigns_VO[intSignCount];
			    strUserIDList="";
			    strUserNameList="";
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
                //for (int i = 0; i < intSignCount; i++)
                //{
                //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
                //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
                //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
                //    objContent.objSignerArr[i].controlName="lsvSign";
                //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmICUNurseRecordContent";//注意大小写
                //    objContent.objSignerArr[i].m_strREGISTERID_CHR=mstrRegisterID;
                //    //痕迹格式 0972,0324,

                //    strUserIDList=strUserIDList+objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim()+",";
                //    strUserNameList=strUserNameList+objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim()+",";
                //}
			    objContent.m_strModifyUserID=strUserIDList;
                objContent.m_strRecordUserID=strUserIDList; //记录第一次操作者信息 
                objContent.m_dtmRecordDate = this.m_dtpCreateDate.Value;
                objContent.objRecordContent.m_dtmRecordDate= this.m_dtpCreateDate.Value;
                objContent.objRecordContent.m_strRecordUserID= strUserIDList;
	            #endregion

                #region 重新设置Richtextbox的用户 【此步骤必须放在获取签名后】
                //设置Richtextbox的modifyuserID 和modifyuserName
                m_mthSetRichTextBoxAttribInControlWithIDandName(this); 
	            #endregion

                #region 获取数据
                objContent.m_strAFTEROPDAYS = this.lblAfterDays.Text.Trim();
                objContent.objRecordContent.m_strAFTEROPDAYS = this.lblAfterDays.Text.Trim();
                // 体温
                objContent.m_strTEMPERATURE = this.m_txtTEMPERATURE.Text.Trim();
                objContent.m_strTEMPERATUREXML = this.m_txtTEMPERATURE.m_strGetXmlText();
                objContent.m_strTEMPERATURE_RIGHT = this.m_txtTEMPERATURE.m_strGetRightText();
                //末体温
                objContent.m_strENDTEMPERATURE = this.m_txtENDTEMPERATURE.Text.Trim();
                objContent.m_strENDTEMPERATUREXML = this.m_txtENDTEMPERATURE.m_strGetXmlText();
                objContent.m_strENDTEMPERATURE_RIGHT = this.m_txtENDTEMPERATURE.m_strGetRightText();
                //心率
                objContent.m_strHR = this.m_txtHR.Text.Trim();
                objContent.m_strHRXML = this.m_txtHR.m_strGetXmlText();
                objContent.m_strHR_RIGHT = this.m_txtHR.m_strGetRightText();
                //心律
                objContent.m_strRHYTHM = this.m_txtRHYTHM.Text.Trim();
                objContent.m_strRHYTHMXML = this.m_txtRHYTHM.m_strGetXmlText();
                objContent.m_strRHYTHM_RIGHT = this.m_txtRHYTHM.m_strGetRightText();
                //呼吸
                objContent.m_strRESPIRATION = this.m_txtRespiration.Text.Trim();
                objContent.m_strRESPIRATIONXML = this.m_txtRespiration.m_strGetXmlText();
                objContent.m_strRESPIRATION_RIGHT = this.m_txtRespiration.m_strGetRightText();
                //血压s
                objContent.m_strBPS = this.m_txtBPS.Text.Trim();
                objContent.m_strBPSXML = this.m_txtBPS.m_strGetXmlText();
                objContent.m_strBPS_RIGHT = this.m_txtBPS.m_strGetRightText();

                //血压D
                objContent.m_strBPD = this.m_txtBPD.Text.Trim();
                objContent.m_strBPDXML = this.m_txtBPD.m_strGetXmlText();
                objContent.m_strBPD_RIGHT = this.m_txtBPD.m_strGetRightText();
                //ABP
                objContent.m_strABP = this.m_txtABP.Text.Trim();
                objContent.m_strABPXML = this.m_txtABP.m_strGetXmlText();
                objContent.m_strABP_RIGHT = this.m_txtABP.m_strGetRightText();
                //CVP
                objContent.m_strCVP = this.m_txtCVP.Text.Trim();
                objContent.m_strCVPXML = this.m_txtCVP.m_strGetXmlText();
                objContent.m_strCVP_RIGHT = this.m_txtCVP.m_strGetRightText();
                //sp02
                objContent.m_strSPO2 = this.m_txtSpo2.Text.Trim();
                objContent.m_strSPO2XML = this.m_txtSpo2.m_strGetXmlText();
                objContent.m_strSPO2_RIGHT = this.m_txtSpo2.m_strGetRightText();
                //意识
                objContent.m_strCONSCIOUSNESS = this.m_cboCONSCIOUSNESS.Text.Trim();
                objContent.m_strCONSCIOUSNESSXML = "";
                objContent.m_strCONSCIOUSNESS_RIGHT = this.m_cboCONSCIOUSNESS.Text.Trim();
                //瞳孔　左
                objContent.m_strPUPIL = this.m_cboPupilSizeLeft.Text;
                objContent.m_strPUPIL_RIGHT = this.m_cboPupilSizeLeft.Text;
                //瞳孔　右
                objContent.m_strPUPIR = this.m_cboPupilSizeRight.Text;
                objContent.m_strPUPIR_RIGHT = this.m_cboPupilSizeRight.Text;
                //对光反射左
                objContent.m_strLIGHTREFLEXL = this.m_cboReflectLeft.Text;
                objContent.m_strLIGHTREFLEXL_RIGHT = this.m_cboReflectLeft.Text;
                //对光反射右
                objContent.m_strLIGHTREFLEXR = this.m_cboReflectRight.Text;
                objContent.m_strLIGHTREFLEXR_RIGHT = this.m_cboReflectRight.Text;
                // 血管活性药物
                objContent.m_strVASOAACTIVE = this.m_cboVASOAACTIVE.Text;
                objContent.m_strVASOAACTIVE_RIGHT = this.m_cboVASOAACTIVE.Text;
                //强心利尿药
                objContent.m_strCARDIACDIURETIC = this.m_cboCARDIACDIURETIC.Text;
                objContent.m_strCARDIACDIURETIC_RIGHT = this.m_cboCARDIACDIURETIC.Text;

                //液体1
                objContent.m_strLIQUID1 = this.m_txtLIQUID1.Text.Trim();
                objContent.m_strLIQUID1XML = this.m_txtLIQUID1.m_strGetXmlText();
                objContent.m_strLIQUID1_RIGHT = this.m_txtLIQUID1.m_strGetRightText();
                //液体2
                objContent.m_strLIQUID2 = this.m_txtLIQUID2.Text.Trim();
                objContent.m_strLIQUID2XML = this.m_txtLIQUID2.m_strGetXmlText();
                objContent.m_strLIQUID2_RIGHT = this.m_txtLIQUID2.m_strGetRightText();
                //液体3
                objContent.m_strLIQUID3 = this.m_txtLIQUID3.Text.Trim();
                objContent.m_strLIQUID3XML = this.m_txtLIQUID3.m_strGetXmlText();
                objContent.m_strLIQUID3_RIGHT = this.m_txtLIQUID3.m_strGetRightText();
                //液体4
                objContent.m_strLIQUID4 = this.m_txtLIQUID4.Text.Trim();
                objContent.m_strLIQUID4XML = this.m_txtLIQUID4.m_strGetXmlText();
                objContent.m_strLIQUID4_RIGHT = this.m_txtLIQUID4.m_strGetRightText();
                //液体5
                objContent.m_strLIQUID5 = this.m_txtLIQUID5.Text.Trim();
                objContent.m_strLIQUID5XML = this.m_txtLIQUID5.m_strGetXmlText();
                objContent.m_strLIQUID5_RIGHT = this.m_txtLIQUID5.m_strGetRightText();
                //全血
                objContent.m_strFBOOL = this.m_txtFullBlood.Text.Trim();
                objContent.m_strFBOOLXML = this.m_txtFullBlood.m_strGetXmlText();
                objContent.m_strFBOOL_RIGHT = this.m_txtFullBlood.m_strGetRightText();
                ///血浆
                objContent.m_strPLASMA = this.m_txtPLASMA.Text.Trim();
                objContent.m_strPLASMAXML = this.m_txtPLASMA.m_strGetXmlText();
                objContent.m_strPLASMA_RIGHT = this.m_txtPLASMA.m_strGetRightText();
                //鼻饲
                objContent.m_strNOSE1 = this.m_txtNOSE1.Text.Trim();
                objContent.m_strNOSE1XML = this.m_txtNOSE1.m_strGetXmlText();
                objContent.m_strNOSE1_RIGHT = this.m_txtNOSE1.m_strGetRightText();
                //鼻进
                objContent.m_strNOSE2 = this.m_txtNOSE2.Text.Trim();
                objContent.m_strNOSE2XML = this.m_txtNOSE2.m_strGetXmlText();
                objContent.m_strNOSE2_RIGHT = this.m_txtNOSE2.m_strGetRightText();
                //每小时总量
                objContent.m_strINPERHOUR = this.m_txtInperhour.Text.Trim();
                objContent.m_strINPERHOURXML = this.m_txtInperhour.m_strGetXmlText();
                objContent.m_strINPERHOUR_RIGHT = this.m_txtInperhour.m_strGetRightText();
                //累计总量
                objContent.m_strINTOTAL = this.m_txtIntotalAll.Text.Trim();
                objContent.m_strINTOTALXML = this.m_txtIntotalAll.m_strGetXmlText();
                objContent.m_strINTOTAL_RIGHT = this.m_txtIntotalAll.m_strGetRightText();
                //小便
                objContent.m_strSTOOL = this.m_txtPISS.Text.Trim();
                objContent.m_strSTOOLXML = this.m_txtPISS.m_strGetXmlText();
                objContent.m_strSTOOL_RIGHT = this.m_txtPISS.m_strGetRightText();
                //小便累计
                objContent.m_strSTOOLTOTAL = this.m_txtPISStoal.Text.Trim();
                objContent.m_strSTOOLTOTALXML = this.m_txtPISStoal.m_strGetXmlText();
                objContent.m_strSTOOLTOTAL_RIGHT = this.m_txtPISStoal.m_strGetRightText();
                //大便
                objContent.m_strPISS = this.m_txtstool.Text.Trim();
                objContent.m_strPISSXML = this.m_txtstool.m_strGetXmlText();
                objContent.m_strPISS_RIGHT = this.m_txtstool.m_strGetRightText();

                //大便累计
                objContent.m_strPISSTOTAL = this.m_txtStooltoalall.Text.Trim();
                objContent.m_strPISSTOTALXML = this.m_txtStooltoalall.m_strGetXmlText();
                objContent.m_strPISSTOTAL_RIGHT = this.m_txtStooltoalall.m_strGetRightText();

                //引液1
                objContent.m_strDRAIN1 = this.m_txtDRAIN1.Text.Trim();
                objContent.m_strDRAIN1XML = this.m_txtDRAIN1.m_strGetXmlText();
                objContent.m_strDRAIN1_RIGHT = this.m_txtDRAIN1.m_strGetRightText();
                //引液2
                objContent.m_strDRAIN2 = this.m_txtDRAIN2.Text.Trim();
                objContent.m_strDRAIN2XML = this.m_txtDRAIN2.m_strGetXmlText();
                objContent.m_strDRAIN2_RIGHT = this.m_txtDRAIN2.m_strGetRightText();
                //引液3
                objContent.m_strDRAIN3 = this.m_txtDRAIN3.Text.Trim();
                objContent.m_strDRAIN3XML = this.m_txtDRAIN3.m_strGetXmlText();
                objContent.m_strDRAIN3_RIGHT = this.m_txtDRAIN3.m_strGetRightText();
                //引液4
                objContent.m_strDRAIN4 = this.m_txtDRAIN4.Text.Trim();
                objContent.m_strDRAIN4XML = this.m_txtDRAIN4.m_strGetXmlText();
                objContent.m_strDRAIN4_RIGHT = this.m_txtDRAIN4.m_strGetRightText();
                //引液5
                objContent.m_strDRAIN5 = this.m_txtDRAIN5.Text.Trim();
                objContent.m_strDRAIN5XML = this.m_txtDRAIN5.m_strGetXmlText();
                objContent.m_strDRAIN5_RIGHT = this.m_txtDRAIN5.m_strGetRightText();
                //每小时引液累计
                objContent.m_strOUTPERHOUR = this.m_txtouthour.Text.Trim();
                objContent.m_strOUTPERHOURXML = this.m_txtouthour.m_strGetXmlText();
                objContent.m_strOUTPERHOUR_RIGHT = this.m_txtouthour.m_strGetRightText();
                //引液总量累计
                objContent.m_strOUTTOTAL = this.m_txtouttoalall.Text.Trim();
                objContent.m_strOUTTOTALXML = this.m_txtouttoalall.m_strGetXmlText();
                objContent.m_strOUTTOTAL_RIGHT = this.m_txtouttoalall.m_strGetRightText();
                //体位
                objContent.m_strPOSTURE = this.cmbPOSTURE.Text.Trim();
                objContent.m_strPOSTUREXML = "";
                objContent.m_strPOSTURE_RIGHT = this.cmbPOSTURE.Text.Trim();
                //皮肤
                objContent.m_strSKIN = this.cmbskin.Text.Trim();
                objContent.m_strSKINXML = "";
                objContent.m_strSKIN_RIGHT = this.cmbskin.Text.Trim();
                //痰色
                objContent.m_strSPUTUM = this.cmbSPUTUM.Text.Trim();
                objContent.m_strSPUTUMXML = "";
                objContent.m_strSPUTUM_RIGHT = this.cmbSPUTUM.Text.Trim();
                //痰量
                objContent.m_strSPUTUM1 = this.cmbSPUTUM1.Text.Trim();
                objContent.m_strSPUTUM1XML = "";
                objContent.m_strSPUTUM1_RIGHT = this.cmbSPUTUM1.Text.Trim();
                //吸痰
                objContent.m_strSUCKER = this.cmbSUCKER.Text.Trim();
                objContent.m_strSUCKERXML = "";
                objContent.m_strSUCKER_RIGHT = this.cmbSUCKER.Text.Trim();
                //口腔护理
                objContent.m_strORAL = this.cmbORAL.Text.Trim();
                objContent.m_strORALXML = "";
                objContent.m_strORAL_RIGHT = this.cmbORAL.Text.Trim();
                //会阴冲洗
                objContent.m_strPERINEUM = this.cmbPERINEUM.Text.Trim();
                objContent.m_strPERINEUMXML = "";
                objContent.m_strPERINEUM_RIGHT = this.cmbPERINEUM.Text.Trim();
                //体疗
                objContent.m_strGESTICULATION = this.cmbGESTICULATION.Text.Trim();
                objContent.m_strGESTICULATIONXML = "";
                objContent.m_strGESTICULATION_RIGHT = this.cmbGESTICULATION.Text.Trim();
                //擦浴
                objContent.m_strSPONGEBATH = this.cmbSPONGEBATH.Text.Trim();
                objContent.m_strSPONGEBATHXML = "";
                objContent.m_strSPONGEBATH_RIGHT = this.cmbSPONGEBATH.Text.Trim();
                //PT
                objContent.m_strPT = this.m_txtPT.Text.Trim();
                objContent.m_strPTXML = this.m_txtPT.m_strGetXmlText();
                objContent.m_strPT_RIGHT = this.m_txtPT.m_strGetRightText();
                //ACT
                objContent.m_strACT = this.m_txtACT.Text.Trim();
                objContent.m_strACTXML = this.m_txtACT.m_strGetXmlText();
                objContent.m_strACT_RIGHT = this.m_txtACT.m_strGetRightText();
                //GlU
                objContent.m_strGLU = this.m_txtglu.Text.Trim();
                objContent.m_strGLUXML = this.m_txtglu.m_strGetXmlText();
                objContent.m_strGLU_RIGHT = this.m_txtglu.m_strGetRightText();
                //K
                objContent.m_strK = this.m_txtKplus.Text.Trim();
                objContent.m_strKXML = this.m_txtKplus.m_strGetXmlText();
                objContent.m_strK_RIGHT = this.m_txtKplus.m_strGetRightText();
                //Na＋
                objContent.m_strNAPLUS = this.m_txtNa.Text.Trim();
                objContent.m_strNAPLUSXML = this.m_txtNa.m_strGetXmlText();
                objContent.m_strNAPLUS_RIGHT = this.m_txtNa.m_strGetRightText();
                //CL-
                objContent.m_strCL = this.m_txtCI.Text.Trim();
                objContent.m_strCLXML = this.m_txtCI.m_strGetXmlText();
                objContent.m_strCL_RIGHT = this.m_txtCI.m_strGetRightText();
                //Ca＋＋
                objContent.m_strCAPLUS2 = this.m_txtcaplus.Text.Trim();
                objContent.m_strCAPLUS2XML = this.m_txtcaplus.m_strGetXmlText();
                objContent.m_strCAPLUS2_RIGHT = this.m_txtcaplus.m_strGetRightText();
                //通气模式
                objContent.m_strMMODEL = this.m_cboBREATHMACHINE.Text.Trim();
                objContent.m_strMMODELXML = "";
                objContent.m_strMMODEL_RIGHT = this.m_cboBREATHMACHINE.Text.Trim();
                //PEE
                objContent.m_strPEE = this.m_txtPEE.Text.Trim();
                objContent.m_strPEEXML = this.m_txtPEE.m_strGetXmlText();
                objContent.m_strPEE_RIGHT = this.m_txtPEE.m_strGetRightText();
                //TV/Ti
                objContent.m_strTVTI = this.m_txtTVTi.Text.Trim();
                objContent.m_strTVTIXML = this.m_txtTVTi.m_strGetXmlText();
                objContent.m_strTVTI_RIGHT = this.m_txtTVTi.m_strGetRightText();
                //频率
                objContent.m_strFREQUENCY = this.m_txtFREQUENCY.Text.Trim();
                objContent.m_strFREQUENCYXML = this.m_txtFREQUENCY.m_strGetXmlText();
                objContent.m_strFREQUENCY_RIGHT = this.m_txtFREQUENCY.m_strGetRightText();
                //氧浓度
                objContent.m_strO2 = this.m_txto2.Text.Trim();
                objContent.m_strO2XML = this.m_txto2.m_strGetXmlText();
                objContent.m_strO2_RIGHT = this.m_txto2.m_strGetRightText();
                //灵敏度
                objContent.m_strSENSEIIVE = this.m_txtSENSEIIVE.Text.Trim();
                objContent.m_strSENSEIIVEXML = this.m_txtSENSEIIVE.m_strGetXmlText();
                objContent.m_strSENSEIIVE_RIGHT = this.m_txtSENSEIIVE.m_strGetRightText();
                //流速
                objContent.m_strSPEED = this.m_txtSPEED.Text.Trim();
                objContent.m_strSPEEDXML = this.m_txtSPEED.m_strGetXmlText();
                objContent.m_strSPEED_RIGHT = this.m_txtSPEED.m_strGetRightText();
                //I:E
                objContent.m_strIE = this.m_txtIE.Text.Trim();
                objContent.m_strIEXML = this.m_txtIE.m_strGetXmlText();
                objContent.m_strIE_RIGHT = this.m_txtIE.m_strGetRightText();
                //气道压力
                objContent.m_strGASPRESS = this.m_txtGASPRESS.Text.Trim();
                objContent.m_strGASPRESSXML = this.m_txtGASPRESS.m_strGetXmlText();
                objContent.m_strGASPRESS_RIGHT = this.m_txtGASPRESS.m_strGetRightText();
                //TV
                objContent.m_strTV = this.m_txtTV.Text.Trim();
                objContent.m_strTVXML = this.m_txtTV.m_strGetXmlText();
                objContent.m_strTV_RIGHT = this.m_txtTV.m_strGetRightText();
                //MV
                objContent.m_strMV = this.m_txtMV.Text.Trim();
                objContent.m_strMVXML = this.m_txtMV.m_strGetXmlText();
                objContent.m_strMV_RIGHT = this.m_txtMV.m_strGetRightText();
                //管道压力
                objContent.m_strPIPEDEPTH = this.m_txtPIPEDEPTH.Text.Trim();
                objContent.m_strPIPEDEPTHXML = this.m_txtPIPEDEPTH.m_strGetXmlText();
                objContent.m_strPIPEDEPTH_RIGHT = this.m_txtPIPEDEPTH.m_strGetRightText();
                //气囊压力
                objContent.m_strAIRCELLPRESS = this.m_txtAIRCELLPRESS.Text.Trim();
                objContent.m_strAIRCELLPRESSXML = this.m_txtAIRCELLPRESS.m_strGetXmlText();
                objContent.m_strAIRCELLPRESS_RIGHT = this.m_txtAIRCELLPRESS.m_strGetRightText();
                //ETCO2
                objContent.m_strETCO2 = this.m_txtETCO2.Text.Trim();
                objContent.m_strETCO2XML = this.m_txtETCO2.Text.Trim();
                objContent.m_strETCO2_RIGHT = this.m_txtETCO2.m_strGetRightText();
                //PH
                objContent.m_strPH = this.m_txtPH.Text.Trim();
                objContent.m_strPHXML = this.m_txtPH.m_strGetXmlText();
                objContent.m_strPH_RIGHT = this.m_txtPH.m_strGetRightText();
                //m_txtPCO2
                objContent.m_strPCO2 = this.m_txtPCO2.Text.Trim();
                objContent.m_strPCO2XML = this.m_txtPCO2.m_strGetXmlText();
                objContent.m_strPCO2_RIGHT = this.m_txtPCO2.m_strGetRightText();
                //m_txtPAO2
                objContent.m_strPAO2 = this.m_txtPAO2.Text.Trim();
                objContent.m_strPAO2XML = this.m_txtPAO2.m_strGetXmlText();
                objContent.m_strPAO2_RIGHT = this.m_txtPAO2.m_strGetRightText();
                //m_txtHCO3
                objContent.m_strHCO3 = this.m_txtHCO3.Text.Trim();
                objContent.m_strHCO3XML = this.m_txtHCO3.m_strGetXmlText();
                objContent.m_strHCO3_RIGHT = this.m_txtHCO3.m_strGetRightText();
                //m_txtBE
                objContent.m_strBE = this.m_txtBE.Text.Trim();
                objContent.m_strBEXML = this.m_txtBE.m_strGetXmlText();
                objContent.m_strBE_RIGHT = this.m_txtBE.m_strGetRightText();
                //护理内容
                objContent.objRecordContent.m_strCONTENT = this.m_txtContent.Text.Trim();
                objContent.objRecordContent.m_strCONTENTXML = this.m_txtContent.m_strGetXmlText();
                objContent.objRecordContent.m_strCONTENT_RIGHT = this.m_txtContent.m_strGetRightText(); 
                #endregion

           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"iCare Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            #endregion

            return (objContent);
        }

        /// <summary>
        /// 仅从界面获取护理内容
        /// </summary>
        /// <returns></returns>
        protected clsICUNurseRecordContent m_objGetRecordContentFromGUI()
        {
            //界面参数校验
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return null;
            clsICUNurseRecordContent objContent = new clsICUNurseRecordContent();
            objContent.m_strRegisterID = mstrRegisterID;
            objContent.m_dtmCreateDate = DateTime.Now;//此时间中间端会重新赋值 取中间件端时间
            objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;//取的登录者ID
            objContent.m_dtmDeActivedDate = DateTime.Now;//默认，没有删除 则操作者为空
            objContent.m_strDeActivedOperatorID = "";
            objContent.m_dtmFirstPrintDate = DateTime.Now;//默认;
            objContent.m_bytStatus = 2;//表明新建允许无痕迹修改
            objContent.m_dtmRecordDate = m_dtpCreateDate.Value;//取界面时间
            objContent.m_bytIfConfirm = 0;//默认未审核
            objContent.m_strTRANSFERID = m_strTransferID;

            #region 获取签名
            int intSignCount = lsvSign.Items.Count;
            //获取lsvsign签名
            objContent.objSignerArr = new clsEmrSigns_VO[intSignCount];
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i] = new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee = (clsEmrEmployeeBase_VO)(lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName = "lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR = "frmICUNurseRecordContent";//注意大小写
            //    objContent.objSignerArr[i].m_strREGISTERID_CHR = mstrRegisterID;
            //    //痕迹格式 0972,0324,

            //    strUserIDList = strUserIDList + objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim() + ",";
            //    strUserNameList = strUserNameList + objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim() + ",";
            //}
            objContent.m_strModifyUserID = strUserIDList;
            objContent.m_strRecordUserID = strUserIDList; //记录第一次操作者信息 
            objContent.m_dtmRecordDate = this.m_dtpCreateDate.Value;
            #endregion

            //护理内容
            objContent.m_strCONTENT = this.m_txtContent.Text.Trim();
            objContent.m_strCONTENTXML = this.m_txtContent.m_strGetXmlText();
            objContent.m_strCONTENT_RIGHT = this.m_txtContent.m_strGetRightText();

            return (objContent);
            
        }

        /// <summary>
        /// 将护理内容显示到界面
        /// </summary>
        /// <param name="p_objContent"></param>
        protected void m_mthSetRecordContentToGUI(iCareData.clsICUNurseRecordContent p_objContent)
        {
            //界面参数校验
            if (p_objContent == null )
                return ;
            clsICUNurseRecordContent objContent = p_objContent;

            this.lblAfterDays.Text = objContent.m_strAFTEROPDAYS;
            //护理内容
            this.m_txtContent.m_mthSetNewText(objContent.m_strCONTENT, objContent.m_strCONTENTXML);

            #region 签名集合
            lsvSign.Clear();
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName == "lsvSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR + "(" + objContent.objSignerArr[i].objEmployee.m_strTECHNICALRANK_CHR + ");");
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

 
        }

        /// <summary>
        /// 将删除的数据显示到界面
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsICUNurseRecordContent objContent = (clsICUNurseRecordContent)p_objContent;

            this.m_mthClearRecordInfo();

            this.m_dtpCreateDate.Enabled = false;
        }

        /// <summary>
        /// 返回窗体的ID
        /// </summary>
        public override int m_IntFormID
        {
            get
            {
                return 135;
            }
        }

        /// <summary>
        /// 返回窗体的标题
        /// </summary>
        /// <returns></returns>
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现

            return "ICU护理记录";
        }

       
        #endregion

        private void m_txtCountIN_TextChanged(object sender, EventArgs e)
        {
            com.digitalwave.controls.ctlRichTextBox ctlBox = sender as com.digitalwave.controls.ctlRichTextBox;
            if (ctlBox == null)
            {
                return;
            }
            
            bool blnIsRight = true;
            double dblTemp = 0;
            if (!double.TryParse(ctlBox.Text,out dblTemp))
            {
                if (!string.IsNullOrEmpty(ctlBox.Text))
                {
                    blnIsRight = false;
                }
                ctlBox.Text = "0";
            }

            m_mthCountIN();

            if (!blnIsRight)
            {
                clsPublicFunction.ShowInformationMessageBox("出入量累计项目只能输入数字！");
            }
        }

        private void m_txtCountOUT_TextChanged(object sender, EventArgs e)
        {
            com.digitalwave.controls.ctlRichTextBox ctlBox = sender as com.digitalwave.controls.ctlRichTextBox;
            if (ctlBox == null)
            {
                return;
            }

            bool blnIsRight = true;
            double dblTemp = 0;
            if (!double.TryParse(ctlBox.Text, out dblTemp))
            {
                if (!string.IsNullOrEmpty(ctlBox.Text))
                {
                    blnIsRight = false;
                }
                ctlBox.Text = "0";
            }

            m_mthCountOUT();

            if (!blnIsRight)
            {
                clsPublicFunction.ShowInformationMessageBox("出入量累计项目只能输入数字！");
            }
        }

        #region 计算出入量
        /// <summary>
        /// 计算入量
        /// </summary>
        private void m_mthCountIN()
        {
            double dblIN = 0;
            double dblTemp = 0;
            if (double.TryParse(m_txtLIQUID1.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            if (double.TryParse(m_txtLIQUID2.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            if (double.TryParse(m_txtLIQUID3.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            if (double.TryParse(m_txtLIQUID4.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            if (double.TryParse(m_txtLIQUID5.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            if (double.TryParse(m_txtFullBlood.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            if (double.TryParse(m_txtPLASMA.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            if (double.TryParse(m_txtNOSE1.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            if (double.TryParse(m_txtNOSE2.Text, out dblTemp))
            {
                dblIN += dblTemp;
            }

            m_txtInperhour.Text = dblIN.ToString();
            m_txtIntotalAll.Text = (dblIN + m_dblCountINBefore).ToString();
        }

        /// <summary>
        /// 计算出量
        /// </summary>
        private void m_mthCountOUT()
        {
            double dblOUT = 0;
            double dblTemp = 0;

            if (double.TryParse(m_txtDRAIN1.Text,out dblTemp))
            {
                dblOUT += dblTemp;
            }

            if (double.TryParse(m_txtDRAIN2.Text,out dblTemp))
            {
                dblOUT += dblTemp;
            }

            if (double.TryParse(m_txtDRAIN3.Text,out dblTemp))
            {
                dblOUT += dblTemp;
            }

            if (double.TryParse(m_txtDRAIN4.Text,out dblTemp))
            {
                dblOUT += dblTemp;
            }

            if (double.TryParse(m_txtDRAIN5.Text,out dblTemp))
            {
                dblOUT += dblTemp;
            }

            if (double.TryParse(m_txtPISS.Text,out dblTemp))
            {
                dblOUT += dblTemp;
                m_txtPISStoal.Text = (dblTemp + m_dblStoolTotalBefore).ToString();
            }

            if (double.TryParse(m_txtstool.Text,out dblTemp))
            {
                dblOUT += dblTemp;
                m_txtStooltoalall.Text = (dblTemp + m_dblPissTotalBefore).ToString();
            }

            m_txtouthour.Text = dblOUT.ToString();
            m_txtouttoalall.Text = (dblOUT + m_dblCountOUTBefore).ToString();
        } 
        #endregion

       /// <summary>
        /// 获取指定时间之前的总量
        /// 如果为DateTime.MinValue，则获取最后一条记录的总量
       /// </summary>
       /// <param name="p_dtmSpecify"></param>
        private void m_mthGetTotalBefore(DateTime p_dtmSpecify)
        {
            try
            {
                clsICUNurseService objServ =
                    (clsICUNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseService));

                long lngRes = objServ.m_lngGetLastGross(mstrRegisterID, m_strTransferID, p_dtmSpecify, out m_dblCountINBefore, out m_dblCountOUTBefore, out m_dblStoolTotalBefore, out m_dblPissTotalBefore);
                objServ = null;
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }            
        }
    }
}