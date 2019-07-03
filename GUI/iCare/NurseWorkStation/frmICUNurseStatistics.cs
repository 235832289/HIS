using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.DiseaseTrackService;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    public partial class frmICUNurseStatistics : frmDiseaseTrackBase
    {
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        /// <summary>
        /// 入院登记流水号
        /// </summary>
        private string m_strRegisterID = string.Empty;
        /// <summary>
        /// 转科流水号
        /// </summary>
        private string m_strTransferID = string.Empty;
        /// <summary>
        /// 入ICU后天数
        /// </summary>
        private string m_strAfterDays = string.Empty;
        /// <summary>
        /// 是否新添统计
        /// </summary>
        private bool m_blnIsAddNewStatistics = true;
        /// <summary>
        /// 当前记录创建日期
        /// </summary>
        private string m_strCreateDate = string.Empty;

        /// <summary>
        /// 通用ICU护理记录24小时统计
        /// </summary>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <param name="p_strTransferID">转科流水号</param>
        /// <param name="p_strAfterDays">入ICU后天数</param>
        /// <param name="p_strCreateDate">创建日期，修改统计时必须赋值</param>
        /// <param name="p_blnIsAddNew">是否新添统计</param>
        public frmICUNurseStatistics(string p_strRegisterID, string p_strTransferID, string p_strAfterDays, string p_strCreateDate, bool p_blnIsAddNew)
        {
            InitializeComponent();

            m_strTransferID = p_strTransferID;
            m_strAfterDays = p_strAfterDays;
            m_blnIsAddNewStatistics = p_blnIsAddNew;
            m_strCreateDate = p_strCreateDate;
            m_strRegisterID = p_strRegisterID;
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

            m_mthSetRichTextBoxAttribInControl(this);
        }

        private void frmICUNurseStatistics_Load(object sender, EventArgs e)
        {
            m_mthClearRecordInfo();
            if (m_blnIsAddNewStatistics)
            {
                m_mthSetDateTimeValue();
                m_mthStatistics(Convert.ToDateTime(m_dtpLastStatTime.Value.ToString("yyyy-MM-dd HH:mm:ss")), Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                m_GetDataFromDB();
            }
            MDIParent.s_ObjSaveCue.m_mthRemoveForm(this);
        }

        public override int m_IntFormID
        {
            get
            {
                return 164;
            }
        }

        #region 清空特殊记录信息
		/// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        private void m_mthClearRecordInfo()
        {
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

            m_dtpCreateDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:00:00"));
            m_txtIN1.m_mthClearText();
            m_txtIN2.m_mthClearText();
            m_txtIN3.m_mthClearText();
            m_txtIN4.m_mthClearText();
            m_txtIN5.m_mthClearText();
            m_txtIN6.m_mthClearText();
            m_txtIN7.m_mthClearText();
            m_txtIN8.m_mthClearText();
            m_txtIN9.m_mthClearText();
            m_txtIN10.m_mthClearText();

            m_txtOUT1.m_mthClearText();
            m_txtOUT2.m_mthClearText();
            m_txtOUT3.m_mthClearText();
            m_txtOUT4.m_mthClearText();
            m_txtOUT5.m_mthClearText();
            m_txtOUT6.m_mthClearText();
            m_txtOUT7.m_mthClearText();
            m_txtOUT8.m_mthClearText();
        } 
	#endregion

        /// <summary>
        /// 从界面获取特殊记录的值。如果界面值出错，返回null。
        /// </summary>
        /// <returns></returns>
        protected clsICUNurseStatisticsValue m_objGetContentFromGUI()
        {
            clsICUNurseStatisticsValue objValue = new clsICUNurseStatisticsValue();

            objValue.m_strLIQUID1 = m_txtIN1.Text;
            objValue.m_strLIQUID1_RIGHT = m_txtIN1.m_strGetRightText();
            objValue.m_strLIQUID1XML = m_txtIN1.m_strGetXmlText();

            objValue.m_strLIQUID2 = m_txtIN2.Text;
            objValue.m_strLIQUID2_RIGHT = m_txtIN2.m_strGetRightText();
            objValue.m_strLIQUID2XML = m_txtIN2.m_strGetXmlText();

            objValue.m_strLIQUID3 = m_txtIN3.Text;
            objValue.m_strLIQUID3_RIGHT = m_txtIN3.m_strGetRightText();
            objValue.m_strLIQUID3XML = m_txtIN3.m_strGetXmlText();

            objValue.m_strLIQUID4 = m_txtIN4.Text;
            objValue.m_strLIQUID4_RIGHT = m_txtIN4.m_strGetRightText();
            objValue.m_strLIQUID4XML = m_txtIN4.m_strGetXmlText();

            objValue.m_strLIQUID5 = m_txtIN5.Text;
            objValue.m_strLIQUID5_RIGHT = m_txtIN5.m_strGetRightText();
            objValue.m_strLIQUID5XML = m_txtIN5.m_strGetXmlText();

            objValue.m_strFBOOL = m_txtIN6.Text;
            objValue.m_strFBOOL_RIGHT = m_txtIN6.m_strGetRightText();
            objValue.m_strFBOOLXML = m_txtIN6.m_strGetXmlText();

            objValue.m_strPLASMA = m_txtIN7.Text;
            objValue.m_strPLASMA_RIGHT = m_txtIN7.m_strGetRightText();
            objValue.m_strPLASMAXML = m_txtIN7.m_strGetXmlText();

            objValue.m_strNOSE1 = m_txtIN8.Text;
            objValue.m_strNOSE1_RIGHT = m_txtIN8.m_strGetRightText();
            objValue.m_strNOSE1XML = m_txtIN8.m_strGetXmlText();

            objValue.m_strNOSE2 = m_txtIN9.Text;
            objValue.m_strNOSE2_RIGHT = m_txtIN9.m_strGetRightText();
            objValue.m_strNOSE2XML = m_txtIN9.m_strGetXmlText();

            objValue.m_strINTOTAL = m_txtIN10.Text;
            objValue.m_strINTOTAL_RIGHT = m_txtIN10.m_strGetRightText();
            objValue.m_strINTOTALXML = m_txtIN10.m_strGetXmlText();

            objValue.m_strDRAIN1 = m_txtOUT1.Text;
            objValue.m_strDRAIN1_RIGHT = m_txtOUT1.m_strGetRightText();
            objValue.m_strDRAIN1XML = m_txtOUT1.m_strGetXmlText();

            objValue.m_strDRAIN2 = m_txtOUT2.Text;
            objValue.m_strDRAIN2_RIGHT = m_txtOUT2.m_strGetRightText();
            objValue.m_strDRAIN2XML = m_txtOUT2.m_strGetXmlText();

            objValue.m_strDRAIN3 = m_txtOUT3.Text;
            objValue.m_strDRAIN3_RIGHT = m_txtOUT3.m_strGetRightText();
            objValue.m_strDRAIN3XML = m_txtOUT3.m_strGetXmlText();

            objValue.m_strDRAIN4 = m_txtOUT4.Text;
            objValue.m_strDRAIN4_RIGHT = m_txtOUT4.m_strGetRightText();
            objValue.m_strDRAIN4XML = m_txtOUT4.m_strGetXmlText();

            objValue.m_strDRAIN5 = m_txtOUT5.Text;
            objValue.m_strDRAIN5_RIGHT = m_txtOUT5.m_strGetRightText();
            objValue.m_strDRAIN5XML = m_txtOUT5.m_strGetXmlText();

            objValue.m_strSTOOL = m_txtOUT6.Text;
            objValue.m_strSTOOL_RIGHT = m_txtOUT6.m_strGetRightText();
            objValue.m_strSTOOLXML = m_txtOUT6.m_strGetXmlText();

            objValue.m_strPISS = m_txtOUT7.Text;
            objValue.m_strPISS_RIGHT = m_txtOUT7.m_strGetRightText();
            objValue.m_strPISSXML = m_txtOUT7.m_strGetXmlText();

            objValue.m_strOUTTOTAL = m_txtOUT8.Text;
            objValue.m_strOUTTOTAL_RIGHT = m_txtOUT8.m_strGetRightText();
            objValue.m_strOUTTOTALXML = m_txtOUT8.m_strGetXmlText();

            objValue.m_dtmSTATISTICSEND_DAT = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            objValue.m_dtmSTATISTICSSTART_DAT = Convert.ToDateTime(m_dtpLastStatTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            if (chkModifyWithoutMatk.Checked)
                objValue.m_intMarkStatus = 0;
            else
                objValue.m_intMarkStatus = 1;

            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { lsvSign }, ref objValue.objSignerArr, ref strUserIDList, ref strUserNameList);

            #region 多签名时验证所有签名者 并保存
            //数字签名 
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_objBaseCurrentPatient.m_StrInPatientID.Trim() + "-" + m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;

            if (objValue.objSignerArr != null)
            {
                ArrayList objSignerArr = new ArrayList();
                for (int i = 0; i < objValue.objSignerArr.Length; i++)
                {
                    if (objValue.objSignerArr[i].controlName == "lsvSign")
                        objSignerArr.Add(objValue.objSignerArr[i].objEmployee);
                }
                clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                if (objCheck.CheckSigner(objValue, objSign_VO) == -1)
                    return null;

            }
            else
            {
                objValue.m_strModifyUserID = MDIParent.OperatorID;
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objValue, objSign_VO) == -1)
                    return null;
            }
            #endregion

            return objValue;
        }

        private new long m_lngSave()
        {
            long lngRes = 0;
            try
            {
                //获取服务器时间
                string strTimeNow = new clsPublicDomain().m_strGetServerTime();

                clsICUNurseStatisticsValue objValue = m_objGetContentFromGUI();
                if (objValue == null)
                {
                    return -1;
                }
                objValue.m_strRegisterID = m_objBaseCurrentPatient.m_StrRegisterId;
                objValue.m_dtmCreateDate = Convert.ToDateTime(strTimeNow);
                objValue.m_strCreateUserID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
                objValue.m_dtmModifyDate = Convert.ToDateTime(strTimeNow);

                objValue.m_strTRANSFERID_CHR = m_strTransferID;
                objValue.m_strAFTEROPDAYS = m_strAfterDays;

                clsICUNurseService objServ =
                    (clsICUNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseService));

                lngRes = objServ.m_lngAddStatistics(objValue);
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
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
                string strNow = new clsPublicDomain().m_strGetServerTime();

                clsICUNurseStatisticsValue objValue = m_objGetContentFromGUI();
                if (objValue == null)
                {
                    return -1;
                }
                objValue.m_strRegisterID = m_objBaseCurrentPatient.m_StrRegisterId;
                objValue.m_dtmModifyDate = DateTime.Parse(strNow);
                objValue.m_dtmCreateDate = m_objCurrentRecordContent.m_dtmCreateDate;

                objValue.m_strTRANSFERID_CHR = m_strTransferID;
                objValue.m_strAFTEROPDAYS = m_strAfterDays;

                clsICUNurseService objServ =
                    (clsICUNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseService));

                lngRes = objServ.m_lngModifyStatistics(objValue);
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
            return lngRes;
        }

        /// <summary>
        /// 设置统计信息至界面
        /// </summary>
        /// <param name="p_objValue">统计信息</param>
        private void m_mthSetStatisticsValueToUI(clsICUNurseStatisticsValue p_objValue)
        {
            if (p_objValue == null)
            {
                return;
            }

            m_txtIN1.m_mthSetNewText(p_objValue.m_strLIQUID1,p_objValue.m_strLIQUID1XML);
            m_txtIN2.m_mthSetNewText(p_objValue.m_strLIQUID2,p_objValue.m_strLIQUID2XML);
            m_txtIN3.m_mthSetNewText(p_objValue.m_strLIQUID3,p_objValue.m_strLIQUID3XML);
            m_txtIN4.m_mthSetNewText(p_objValue.m_strLIQUID4,p_objValue.m_strLIQUID4XML);
            m_txtIN5.m_mthSetNewText(p_objValue.m_strLIQUID5,p_objValue.m_strLIQUID5XML);
            m_txtIN6.m_mthSetNewText(p_objValue.m_strFBOOL,p_objValue.m_strFBOOLXML);
            m_txtIN7.m_mthSetNewText(p_objValue.m_strPLASMA,p_objValue.m_strPLASMAXML);
            m_txtIN8.m_mthSetNewText(p_objValue.m_strNOSE1,p_objValue.m_strNOSE1XML);
            m_txtIN9.m_mthSetNewText(p_objValue.m_strNOSE2,p_objValue.m_strNOSE2XML);
            m_txtIN10.m_mthSetNewText(p_objValue.m_strINTOTAL,p_objValue.m_strINTOTALXML);

            m_txtOUT1.m_mthSetNewText(p_objValue.m_strDRAIN1,p_objValue.m_strDRAIN1XML);
            m_txtOUT2.m_mthSetNewText(p_objValue.m_strDRAIN2,p_objValue.m_strDRAIN2XML);
            m_txtOUT3.m_mthSetNewText(p_objValue.m_strDRAIN3,p_objValue.m_strDRAIN3XML);
            m_txtOUT4.m_mthSetNewText(p_objValue.m_strDRAIN4,p_objValue.m_strDRAIN4XML);
            m_txtOUT5.m_mthSetNewText(p_objValue.m_strDRAIN5,p_objValue.m_strDRAIN5XML);
            m_txtOUT6.m_mthSetNewText(p_objValue.m_strSTOOL,p_objValue.m_strSTOOLXML);
            m_txtOUT7.m_mthSetNewText(p_objValue.m_strPISS,p_objValue.m_strPISSXML);
            m_txtOUT8.m_mthSetNewText(p_objValue.m_strOUTTOTAL, p_objValue.m_strOUTTOTALXML);

            if (p_objValue.m_intMarkStatus != 0)
            {
                chkModifyWithoutMatk.Checked = false;
                chkModifyWithoutMatk.Visible = false;
            }
            else
            {
                chkModifyWithoutMatk.Checked = true;
                chkModifyWithoutMatk.Visible = true;
            }

            m_dtpCreateDate.Value = p_objValue.m_dtmSTATISTICSEND_DAT;
            m_dtpLastStatTime.Value = p_objValue.m_dtmSTATISTICSSTART_DAT;
            //根据工号获取签名信息
            m_mthAddSignToListView(lsvSign, p_objValue.objSignerArr);
            m_mthSetModifyControl(p_objValue, false);
            this.m_dtpCreateDate.Enabled = false;
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        private void m_GetDataFromDB()
        {
            long lngRes = 0;
            try
            {
                string[] DataArr;
                clsICUNurseService objserv =
                    (clsICUNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseService));

                clsICUNurseStatisticsValue objValue = null;
                lngRes = objserv.m_lngGetStatisticsValue(m_strRegisterID, Convert.ToDateTime(m_strCreateDate), out objValue);
                //赋值到表单
                m_mthSetStatisticsValueToUI(objValue);

                m_objCurrentRecordContent = objValue;
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }

        /// <summary>
        /// 设置默认统计时间
        /// </summary>
        private void m_mthSetDateTimeValue()
        {
            if (DateTime.Now.Hour <= 8)
            {
                m_dtpLastStatTime.Value = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 08:00:00"));
                m_dtpCreateDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 08:00:00"));
            }
            else
            {
                m_dtpLastStatTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 08:00:00"));
                m_dtpCreateDate.Value = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 08:00:00"));
            }
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            if (m_blnIsAddNewStatistics)
            {
                if (this.m_lngSave() > 0)
                {
                    this.Close();
                }

            }
            else
            {
                if (m_lngModify() > 0)
                {
                    this.Close();
                }
            }
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdStatistics_Click(object sender, EventArgs e)
        {
            if (m_dtpLastStatTime.Value > m_dtpCreateDate.Value)
            {
                clsPublicFunction.ShowInformationMessageBox("统计起始时间不能大于结束时间");
                return;
            }

            m_mthStatistics(Convert.ToDateTime(m_dtpLastStatTime.Value.ToString("yyyy-MM-dd HH:mm:ss")), Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        /// <summary>
        /// 统计时间段内的出入量
        /// </summary>
        /// <param name="p_dtmStart"></param>
        /// <param name="p_dtmEnd"></param>
        private void m_mthStatistics(DateTime p_dtmStart, DateTime p_dtmEnd)
        {
            if (m_objBaseCurrentPatient == null)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsICUNurseStatisticsValue[] objValueArr = null;

                clsICUNurseService objServ =
                    (clsICUNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseService));

                long lngRes = objServ.m_lngStasticsInSpecifyTime(m_objBaseCurrentPatient.m_StrRegisterId, m_strTransferID, p_dtmStart, p_dtmEnd, out objValueArr);

                if (objValueArr != null)
                {
                    #region 计算各项出入量
                    double dblIN1 = 0;
                    double dblIN2 = 0;
                    double dblIN3 = 0;
                    double dblIN4 = 0;
                    double dblIN5 = 0;
                    double dblIN6 = 0;
                    double dblIN7 = 0;
                    double dblIN8 = 0;
                    double dblIN9 = 0;
                    double dblIN10 = 0;

                    double dblOUT1 = 0;
                    double dblOUT2 = 0;
                    double dblOUT3 = 0;
                    double dblOUT4 = 0;
                    double dblOUT5 = 0;
                    double dblOUT6 = 0;
                    double dblOUT7 = 0;
                    double dblOUT8 = 0;

                    for (int i = 0; i < objValueArr.Length; i++)
                    {
                        double dblTemp = 0D;
                        if (double.TryParse(objValueArr[i].m_strLIQUID1_RIGHT, out dblTemp))
                        {
                            dblIN1 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strLIQUID2_RIGHT, out dblTemp))
                        {
                            dblIN2 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strLIQUID3_RIGHT, out dblTemp))
                        {
                            dblIN3 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strLIQUID4_RIGHT, out dblTemp))
                        {
                            dblIN4 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strLIQUID5_RIGHT, out dblTemp))
                        {
                            dblIN5 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strFBOOL_RIGHT, out dblTemp))
                        {
                            dblIN6 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strPLASMA_RIGHT, out dblTemp))
                        {
                            dblIN7 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strNOSE1_RIGHT, out dblTemp))
                        {
                            dblIN8 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strNOSE2_RIGHT, out dblTemp))
                        {
                            dblIN9 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strDRAIN1_RIGHT, out dblTemp))
                        {
                            dblOUT1 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strDRAIN2_RIGHT, out dblTemp))
                        {
                            dblOUT2 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strDRAIN3_RIGHT, out dblTemp))
                        {
                            dblOUT3 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strDRAIN4_RIGHT, out dblTemp))
                        {
                            dblOUT4 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strDRAIN5_RIGHT, out dblTemp))
                        {
                            dblOUT5 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strSTOOL_RIGHT, out dblTemp))
                        {
                            dblOUT6 += dblTemp;
                        }

                        if (double.TryParse(objValueArr[i].m_strPISS_RIGHT, out dblTemp))
                        {
                            dblOUT7 += dblTemp;
                        }
                    }

                    dblIN10 = dblIN1 + dblIN2 + dblIN3 + dblIN4 + dblIN5 + dblIN6 + dblIN7 + dblIN8 + dblIN9;
                    dblOUT8 = dblOUT1 + dblOUT2 + dblOUT3 + dblOUT4 + dblOUT5 + dblOUT6 + dblOUT7;
                    #endregion

                    #region 将统计结果赋值至界面
                    m_txtIN1.Text = dblIN1.ToString();
                    m_txtIN2.Text = dblIN2.ToString();
                    m_txtIN3.Text = dblIN3.ToString();
                    m_txtIN4.Text = dblIN4.ToString();
                    m_txtIN5.Text = dblIN5.ToString();
                    m_txtIN6.Text = dblIN6.ToString();
                    m_txtIN7.Text = dblIN7.ToString();
                    m_txtIN8.Text = dblIN8.ToString();
                    m_txtIN9.Text = dblIN9.ToString();
                    m_txtIN10.Text = dblIN10.ToString();

                    m_txtOUT1.Text = dblOUT1.ToString();
                    m_txtOUT2.Text = dblOUT2.ToString();
                    m_txtOUT3.Text = dblOUT3.ToString();
                    m_txtOUT4.Text = dblOUT4.ToString();
                    m_txtOUT5.Text = dblOUT5.ToString();
                    m_txtOUT6.Text = dblOUT6.ToString();
                    m_txtOUT7.Text = dblOUT7.ToString();
                    m_txtOUT8.Text = dblOUT8.ToString();
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
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
    }
}