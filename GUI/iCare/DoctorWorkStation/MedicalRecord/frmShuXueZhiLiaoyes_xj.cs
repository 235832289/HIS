using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.emr.BEDExplorer;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.AssistModuleVO;

namespace iCare
{
    /// <summary>
    /// 输血治疗同意书----新疆 
    /// </summary>
    public partial class frmShuXueZhiLiaoyes_xj : iCare.frmDiseaseTrackBase
    {
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

        public frmShuXueZhiLiaoyes_xj()
        {
            InitializeComponent();

            m_mthSetRichTextBoxAttribInControl(this);
            //指明医生工作站表单
            intFormType = 1;
            this.Text = "输血治疗同意书";
            this.m_lblForTitle.Text = this.Text;

            m_objSign = new clsEmrSignToolCollection();

            //医师
            m_objSign.m_mthBindEmployeeSign(m_cmdRecord, m_txtRecorder, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
           
        }


        /// <summary>
        /// 获取当前的特殊病程记录信息
        /// </summary>
        /// <returns></returns>
        public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsShuXueZhiLiaoyesInfo_xj objTrackInfo = new clsShuXueZhiLiaoyesInfo_xj();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
            //设置m_strTitle和m_dtmRecordTime
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = "输血治疗同意书";

            return objTrackInfo;
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //清空具体记录内容	
            m_strCurrentOpenDate = "";
            txt_alt.Text = "";
            txt_beizhu.Text = "";
            txt_chan.Text = "";
            txt_chengfen.Text = "";
            txt_hbc.Text = "";
            txt_hbe.Text = "";
            txt_hbeag.Text = "";
            txt_hbs.Text = "";
            txt_hbsag.Text = "";
            txt_hcv.Text = "";
            txt_hivi.Text = "";
            txt_meidu.Text = "";
            txt_mudi.Text = "";
            txt_yun.Text = "";
            txt_zduan.Text = "";           

            //m_lsvAttendeeList.Items.Clear();
            //m_txtCompere.Clear();
            //m_txtCompere.Tag = null;

            m_txtRecorder.Clear();
            m_txtRecorder.Tag = null;

            
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
        /// 提示没有该病人
        /// </summary>
        protected override void m_mthShowNoPatient()
        {
            clsPublicFunction.ShowInformationMessageBox("对不起，没有此病人！");
        }

        protected override void m_mthSetPatientBaseInfo(clsPatient p_objSelectedPatient)
        {
            if (p_objSelectedPatient.m_ObjPeopleInfo == null)
            {
                m_mthShowNoPatient();
                return;
            }
            //这个开关的作用是以防对m_cboArea赋值后触发其SelectedIndexChanged事件
            m_blnCanTextChanged = false;

            if (p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo != null)
            {
                //				m_cboDept.ClearItem();
                //				m_cboArea.ClearItem();
                //				m_cboDept.AddItem(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept);
                //				m_cboDept.SelectedIndex=0;
                //				clsInPatientArea objInPatientArea =new clsInPatientArea(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName);
                //				m_cboArea.AddItem(objInPatientArea);
                //				m_cboArea.SelectedIndex=0;
                //				m_txtBedNO.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;				
                //使用新表 modified by tfzhang at 2005年10月17日 16:02:29
                //清空
                m_cboDept.ClearItem();

                //获取科室
                string str1 = p_objSelectedPatient.m_strDeptNewID;
                string str2;
                clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                clsEmrDept_VO objDeptNew;
                objDomain.m_lngGetSpecialDeptInfo(str1, out objDeptNew);
                str1 = objDeptNew.m_strSHORTNO_CHR.Trim();
                str2 = objDeptNew.m_strDEPTNAME_VCHR.Trim();
                string str11 = objDeptNew.m_strDEPTID_CHR.Trim();
                clsDepartment objDeptTemp = new clsDepartment(str1, str2);
                //转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
                objDeptTemp.m_strDeptNewID = str11;
                m_cboDept.AddItem(objDeptTemp);
                m_cboDept.SelectedIndex = 0;

                //获取病区
                m_cboArea.ClearItem();
                string str3 = p_objSelectedPatient.m_strAreaNewID;
                if (str3.Trim().Length != 0)//病区不为空
                {
                    string str4;
                    clsEmrDept_VO objAreNew;
                    objDomain.m_lngGetSpecialAreaInfo(str3, out objAreNew);
                    str3 = objAreNew.m_strSHORTNO_CHR;
                    str4 = objAreNew.m_strDEPTNAME_VCHR;
                    clsInPatientArea objInPatientArea = new clsInPatientArea(str3, str4, str3);
                    //转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
                    objInPatientArea.m_strAreaNewID = objAreNew.m_strDEPTID_CHR;
                    m_cboArea.AddItem(objInPatientArea);
                    m_cboArea.SelectedIndex = 0;
                }

                m_txtBedNO.Text = p_objSelectedPatient.m_strBedCode;
            }
            else
            {
                m_txtBedNO.Text = "";
            }

            m_objCurrentPatient = p_objSelectedPatient;

            txtInPatientID.Text = m_objCurrentPatient.m_StrHISInPatientID;
            m_txtPatientName.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
            lblSex.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
            lblAge.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
            m_blnCanTextChanged = true;
        }

        /// <summary>
        /// 从界面获取特殊记录的值。如果界面值出错，返回null。
        /// </summary>
        /// <returns></returns>
        protected override clsTrackRecordContent m_objGetContentFromGUI()
        {
            //界面参数校验
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return null;

            //从界面获取表单值
            clsShuXueZhiLiaoyesContent_xj objContent = new clsShuXueZhiLiaoyesContent_xj();
            objContent.m_dtmCreateDate = m_dtpCreateDate.Value;
            objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
            //   objContent.m_dtmDeadDate = m_dtpDeadDate.Value;
            //objContent.m_dtmDiscussDate = m_dtpDiscussTime.Value;
            objContent.m_dtmDoctorDate = dtpriqi.Value;
            objContent.m_dtmHuanzheDate = dtprihuan.Value;

            //objContent.m_strDiscussAddress = m_txtDiscussAddress.Text;
            objContent.m_strShuXueMuDi = txt_mudi.Text;
            objContent.m_strShuXueMuDiXML = txt_mudi.m_strGetXmlText();
            objContent.m_strYun = txt_yun.Text;
            objContent.m_strChan = txt_chan.Text;
            if (rdb_wu.Checked == true)
            {
                objContent.m_strShuXueShi = "1"; 
            }

            if (rdb_you.Checked == true)
            {
                objContent.m_strShuXueShi = "2";
            }

            objContent.m_strShuXueChengFen = txt_chengfen.Text;
            objContent.m_strShuXueChengFenXML = txt_chengfen.m_strGetXmlText();

            objContent.m_strZhenDuan = txt_zduan.Text;
            objContent.m_strZhenDuanXML = txt_zduan.m_strGetXmlText();

            objContent.m_strBeiZhu = txt_beizhu.Text;
            objContent.m_strBeiZhuXML = txt_beizhu.m_strGetXmlText();

            objContent.m_strALT = txt_alt.Text;
            objContent.m_strHBsAg = txt_hbsag.Text;
            objContent.m_strHBs = txt_hbs.Text;
            objContent.m_strHBeAg = txt_hbeag.Text;
            objContent.m_strHBe = txt_hbe.Text;
            objContent.m_strHCV = txt_hcv.Text;
            objContent.m_strHBc = txt_hbc.Text;
            objContent.m_strHIVI = txt_hivi.Text;
            objContent.m_strMeiDu = txt_meidu.Text;

            //objContent.m_strExperience = m_txtExperience.Text;
            //objContent.m_strExperienceXML = m_txtExperience.m_strGetXmlText();

            //参加人员
            //if (m_lsvAttendeeList.Items.Count > 0)
            //{
            //    objContent.m_strAttendeeIDArr = new string[m_lsvAttendeeList.Items.Count];
            //    objContent.m_strAttendeeNameArr = new string[m_lsvAttendeeList.Items.Count];
            //    for (int i = 0; i < m_lsvAttendeeList.Items.Count; i++)
            //    {
            //        objContent.m_strAttendeeIDArr[i] = ((clsEmrEmployeeBase_VO)m_lsvAttendeeList.Items[i].Tag).m_strEMPNO_CHR.Trim();
            //        objContent.m_strAttendeeNameArr[i] = ((clsEmrEmployeeBase_VO)m_lsvAttendeeList.Items[i].Tag).m_strLASTNAME_VCHR.Trim() + ((clsEmrEmployeeBase_VO)m_lsvAttendeeList.Items[i].Tag).m_strTECHNICALRANK_CHR.Trim();
            //    }
            //}
            //else
            //{
            //    clsPublicFunction.ShowInformationMessageBox("请至少一个参加人员签名!");
            //    return null;
            //}

            //麻醉医师
            //if (m_txtCompere.Tag != null && m_txtCompere.Text.Trim() != "")
            //{
            //    objContent.m_strCompereID = ((clsEmrEmployeeBase_VO)m_txtCompere.Tag).m_strEMPNO_CHR;

            //    clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            //    objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCompereID, out objEmpVO);
            //    // m_txtDoctorSign.Text = objEmpVO.ToString();
            //    objContent.m_strCompereName = objEmpVO.ToString();

            //    // objContent.m_strCompereName=m_txtCompere.Text;
            //}
            //else
            //{
            //    clsPublicFunction.ShowInformationMessageBox("请麻醉医师签名!");
            //    return null;
            //}
            //记录者
            if (m_txtRecorder.Tag != null && m_txtRecorder.Text.Trim() != "")
            {
                objContent.m_strRecordID = ((clsEmrEmployeeBase_VO)m_txtRecorder.Tag).m_strEMPNO_CHR.Trim();
                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(objContent.m_strRecordID, out objEmpVO);
                // m_txtDoctorSign.Text = objEmpVO.ToString();
                objContent.m_strRecordName = objEmpVO.ToString();

                //objContent.m_strRecorderName = m_txtRecorder.Text.Trim();
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("请医师签名!");
                return null;
            }

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
            clsShuXueZhiLiaoyesContent_xj objContent = (clsShuXueZhiLiaoyesContent_xj)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

            //   m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
           // m_dtpDiscussTime.Value = objContent.m_dtmDiscussDate;
            dtpriqi.Value = objContent.m_dtmDoctorDate;

            dtprihuan.Value = objContent.m_dtmHuanzheDate;
            //  m_txtDiscussAddress.Text = objContent.m_strDiscussAddress;

            txt_mudi.m_mthSetNewText(objContent.m_strShuXueMuDi, objContent.m_strShuXueMuDiXML);
            txt_chengfen.m_mthSetNewText(objContent.m_strShuXueChengFen, objContent.m_strShuXueChengFenXML);
            txt_zduan.m_mthSetNewText(objContent.m_strZhenDuan, objContent.m_strZhenDuanXML);
            txt_beizhu.m_mthSetNewText(objContent.m_strBeiZhu, objContent.m_strBeiZhuXML);
            if (objContent.m_strShuXueShi =="1")
            {
                rdb_wu.Checked = true;
            }
            if (objContent.m_strShuXueShi == "2")
            {
                rdb_you.Checked = true;
            }
            txt_yun.Text = objContent.m_strYun;
            txt_chan.Text = objContent.m_strChan;
            txt_alt.Text = objContent.m_strALT;
            txt_hbsag.Text = objContent.m_strHBsAg;
            txt_hbc.Text = objContent.m_strHBc;
            txt_hbs.Text = objContent.m_strHBs;
            txt_hbeag.Text = objContent.m_strHBeAg;
            txt_hbe.Text = objContent.m_strHBe;
            txt_hcv.Text = objContent.m_strHCV;
            txt_hivi.Text = objContent.m_strHIVI;
            txt_meidu.Text = objContent.m_strMeiDu;
            //m_txtDeadReason.m_mthSetNewText(objContent.m_strDeadReason, objContent.m_strDeadReasonXML);
            //m_txtExperience.m_mthSetNewText(objContent.m_strExperience, objContent.m_strExperienceXML);

            #region 签名
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            //if (objContent.m_strAttendeeIDArr != null)
            //{
            //    for (int i = 0; i < objContent.m_strAttendeeIDArr.Length; i++)
            //    {
            //        ListViewItem lviNewItem = new ListViewItem(new string[] { objContent.m_strAttendeeNameArr[i].Trim(), objContent.m_strAttendeeIDArr[i].Trim() });
            //        //tag均为对象
            //        objEmployeeSign.m_lngGetEmpByNO(objContent.m_strAttendeeIDArr[i].Trim(), out objEmpVO);
            //        lviNewItem.SubItems.Add(objEmpVO.m_strLEVEL_CHR);
            //        lviNewItem.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTechnicalRank;
            //        lviNewItem.Tag = objEmpVO;
            //        //是按顺序保存故获取顺序也一样
            //        m_lsvAttendeeList.Items.Add(lviNewItem);
            //        //m_lsvAttendeeList.Items.Add(objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTechnicalRank);
            //    }
            //}

            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCompereID, out objEmpVO);
            //if (objEmpVO != null)
            //{
            //    m_txtCompere.Tag = objEmpVO;
            //    //  m_txtCompere.Text = objContent..m_strCompereName;
            //    m_txtCompere.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTECHNICALRANK_CHR;
            //}

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strRecordID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtRecorder.Tag = objEmpVO;
                //  m_txtRecorder.Text = objContent.m_strRecorderName;
                m_txtRecorder.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTECHNICALRANK_CHR;
            }

            #endregion 签名
        }

        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期，此处表示CreateDate</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            if (m_objBaseCurrentPatient == null || m_objBaseCurrentPatient.m_StrInPatientID == null || m_objBaseCurrentPatient.m_DtmSelectedInDate == DateTime.MinValue || p_dtmRecordDate == DateTime.MinValue)
            {
                clsPublicFunction.ShowInformationMessageBox("参数错误！");
                return;
            }

            clsTrackRecordContent objContent = null;
            long lngRes = m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
            if (lngRes > 0 && objContent != null)
            {
                m_mthSetDeletedGUIFromContent(objContent);
            }

        }

        public override int m_IntFormID
        {
            get
            {
                return 199;
            }
        }


        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsShuXueZhiLiaoyesContent_xj objContent = (clsShuXueZhiLiaoyesContent_xj)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            //m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
           // m_dtpDiscussTime.Value = objContent.m_dtmDiscussDate;
            dtpriqi.Value = objContent.m_dtmDoctorDate;
            dtprihuan.Value = objContent.m_dtmHuanzheDate;
            //m_txtDiscussAddress.Text = objContent.m_strDiscussAddress;

            txt_mudi.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strShuXueMuDi, objContent.m_strShuXueMuDiXML);
            txt_chengfen.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strShuXueChengFen, objContent.m_strShuXueChengFenXML);
            txt_zduan.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strZhenDuan, objContent.m_strZhenDuanXML);
            txt_beizhu.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBeiZhu, objContent.m_strBeiZhuXML);

            if (objContent.m_strShuXueShi == "1")
            {
                rdb_wu.Checked = true;
            }
            if (objContent.m_strShuXueShi == "2")
            {
                rdb_you.Checked = true;
            }
            txt_yun.Text = objContent.m_strYun;
            txt_chan.Text = objContent.m_strChan;
            txt_alt.Text = objContent.m_strALT;
            txt_hbsag.Text = objContent.m_strHBsAg;
            txt_hbs.Text = objContent.m_strHBs;
            txt_hbc.Text = objContent.m_strHBc;
            txt_hbeag.Text = objContent.m_strHBeAg;
            txt_hbe.Text = objContent.m_strHBe;
            txt_hcv.Text = objContent.m_strHCV;
            txt_hivi.Text = objContent.m_strHIVI;
            txt_meidu.Text = objContent.m_strMeiDu;
            //   m_txtExperience.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strExperience, objContent.m_strExperienceXML);
            //m_txtYiBao.Text = objContent.m_strYiBao;

        }

        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.ShuXueZhiLiaoyes_xj);
        }


        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsShuXueZhiLiaoyesContent_xj objContent = (clsShuXueZhiLiaoyesContent_xj)p_objRecordContent;
            //把表单值赋值到界面，由子窗体重载实现
           // m_dtpDiscussTime.Value = objContent.m_dtmDiscussDate;
            dtpriqi.Value = objContent.m_dtmDoctorDate;
            dtprihuan.Value = objContent.m_dtmHuanzheDate;
            //  m_txtDiscussAddress.Text = objContent.m_strDiscussAddress;

            //m_txtInHospitalDiagnose.m_mthSetNewText(objContent.m_strShuQian, objContent.m_strShuQianXML);
            //m_txtSpeakRecord.m_mthSetNewText(objContent.m_strNiShi, objContent.m_strNiShiXML);
            //m_txtYiJian.m_mthSetNewText(objContent.m_strMaZui, objContent.m_strMaZuiXML);
            //m_txtYiBao.Text = objContent.m_strYiBao;
            txt_mudi.m_mthSetNewText(objContent.m_strShuXueMuDi, objContent.m_strShuXueMuDiXML);
            txt_chengfen.m_mthSetNewText(objContent.m_strShuXueChengFen, objContent.m_strShuXueChengFenXML);
            txt_zduan.m_mthSetNewText(objContent.m_strZhenDuan, objContent.m_strZhenDuanXML);
            txt_beizhu.m_mthSetNewText(objContent.m_strBeiZhu, objContent.m_strBeiZhuXML);
            if (objContent.m_strShuXueShi == "1")
            {
                rdb_wu.Checked = true;
            }
            if (objContent.m_strShuXueShi == "2")
            {
                rdb_you.Checked = true;
            }
            txt_yun.Text = objContent.m_strYun;
            txt_chan.Text = objContent.m_strChan;
            txt_alt.Text = objContent.m_strALT;
            txt_hbsag.Text = objContent.m_strHBsAg;
            txt_hbs.Text = objContent.m_strHBs;
            txt_hbeag.Text = objContent.m_strHBeAg;
            txt_hbe.Text = objContent.m_strHBe;
            txt_hbc.Text = objContent.m_strHBc;
            txt_hcv.Text = objContent.m_strHCV;
            txt_hivi.Text = objContent.m_strHIVI;
            txt_meidu.Text = objContent.m_strMeiDu;

            #region 签名
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            //if (objContent.m_strAttendeeIDArr != null)
            //{
            //    for (int i = 0; i < objContent.m_strAttendeeIDArr.Length; i++)
            //    {
            //        ListViewItem lviNewItem = new ListViewItem(new string[] { objContent.m_strAttendeeNameArr[i].Trim(), objContent.m_strAttendeeIDArr[i] });
            //        //tag均为对象
            //        objEmployeeSign.m_lngGetEmpByNO(objContent.m_strAttendeeIDArr[i], out objEmpVO);
            //        lviNewItem.SubItems.Add(objEmpVO.m_strLEVEL_CHR);
            //        lviNewItem.Tag = objEmpVO;
            //        //是按顺序保存故获取顺序也一样
            //        m_lsvAttendeeList.Items.Add(lviNewItem);
            //    }
            //}

            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCompereID, out objEmpVO);
            //if (objEmpVO != null)
            //{
            //    m_txtCompere.Tag = objEmpVO;
            //    m_txtCompere.Text = objContent.m_strCompereName;
            //}
            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strRecordID, out objEmpVO);
            //if (objEmpVO != null)
            //{
            //    m_txtRecorder.Tag = objEmpVO;
            //    //  m_txtRecorder.Text = objContent.m_strRecorderName;
            //    m_txtRecorder.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTECHNICALRANK_CHR;
            //}

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strRecordID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtRecorder.Tag = objEmpVO;
                m_txtRecorder.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTECHNICALRANK_CHR;
            }


            #endregion 签名
        }


        // 获取选择已经删除记录的窗体标题  
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "输血治疗同意书";
        }

        /// <summary>
        /// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
        /// </summary>
        protected override void m_mthSelectRootNode()
        {
            if (m_objCurrentPatient != null)
            {
                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
                {
                   txt_mudi.Text = objInPatientCaseHisoryDefaultValueArr[0].m_strPrimaryDiagnose;
                }
            }
        }


        #region 签名
        private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:// enter
                    break;

                case 38:
                case 40:
                    break;
                case 46://Keys.Delete
                    break;
            }
        }

        #endregion 签名

        #region 添加键盘快捷键
        private void m_mthSetQuickKeys()
        {
            m_mthSetControlEvent(this);
        }

        private void m_mthSetControlEvent(Control p_ctlControl)
        {
            #region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName != "Lable" && strTypeName != "Button")
            {
                p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
                if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker" && strTypeName != "ctlComboBox")
                {
                    foreach (Control subcontrol in p_ctlControl.Controls)
                    {
                        m_mthSetControlEvent(subcontrol);
                    }
                }
            }
            #endregion
        }
        #endregion

        /// <summary>
        /// 清空除当前控件以外的所有窗体内容,(可覆盖提供新的实现)
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_blnReadOnly"></param>
        protected override void m_mthClearAllInfo(Control p_ctlControl)
        {
            if (p_ctlControl == null)// || m_lblInHospitalTime == null)
                return;
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
            {
                if (p_ctlControl is iCare.CustomForm.ctlRichTextBox)//自定义表单中的cltRichTextBox
                    ((iCare.CustomForm.ctlRichTextBox)p_ctlControl).Text = "";
                else
                    ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();
            }
            else if (strTypeName == "ctlBorderTextBox" && p_ctlControl.Name != "txtInPatientID" && p_ctlControl.Name != "m_txtPatientName" && p_ctlControl.Name != "m_txtBedNO" && p_ctlControl.Name != "m_txtRecorder")
                ((ctlBorderTextBox)p_ctlControl).Text = "";
            else if (strTypeName == "TreeView")
            {
                if (((TreeView)p_ctlControl).Nodes.Count > 0)
                    ((TreeView)p_ctlControl).Nodes[0].Nodes.Clear();
            }
            else if (strTypeName == "ListView")
                ((ListView)p_ctlControl).Items.Clear();
            else if (strTypeName == "DateTimePicker")
                ((DateTimePicker)p_ctlControl).Value = DateTime.Now;
            //m_lblInHospitalTime.Text = "";
            if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthClearAllInfo(subcontrol);
                }
            }
        }

        private void frmShuXueZhiLiaoyes_xj_Load(object sender, EventArgs e)
        {
              m_mthfrmLoad();
            //if(m_objCurrentPatient !=null)
            //{
            //    m_lblInHospitalTime.Text=m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日");
            //}
            this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            this.m_dtpCreateDate.m_mthResetSize();

            m_trvCreateDate.Focus();
        }

        protected override void m_mthSetPatientInHospitalDate(clsPatient p_objSelectedPatient)
        {
            //判断病人信息是否为null，如果是，直接返回。
            if (p_objSelectedPatient == null)
                return;

            //记录病人信息
            m_objCurrentPatient = p_objSelectedPatient;
            //m_lblInHospitalTime.Text=m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日");

        }


        /// <summary>
        /// 数据复用
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
        {
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_DtmSelectedInDate.ToString());
            if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
            {
                this.txt_mudi.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
            }
        }


        #region 审核
        private string m_strCurrentOpenDate = "";
        protected override string m_StrCurrentOpenDate
        {
            get
            {
                if (m_strCurrentOpenDate == "")
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                    return "";
                }
                return m_strCurrentOpenDate;

            }
        }

        protected override bool m_BlnCanApprove
        {
            get
            {
                return true;
            }
        }
        #endregion

        #region 属性
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.CaseHistory; }
        }
        protected override string m_StrRecorder_ID
        {
            get
            {
                if (m_txtRecorder.Tag != null)
                    return ((clsEmrEmployeeBase_VO)m_txtRecorder.Tag).m_strEMPNO_CHR.Trim();
                return "";
            }
        }

        #endregion 属性


        #region 外部打印.

        //System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private void m_mthfrmLoad()
        {
            if (m_pdcPrintDocument == null)
                this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        }
        private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
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

        //		private bool m_blnHasInitPrintTool=false;
        clsShuXueZhiLiaoyesPrintTool_xj objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            //			if(m_blnHasInitPrintTool==false)
            //			{
            objPrintTool = new clsShuXueZhiLiaoyesPrintTool_xj();
            objPrintTool.m_mthInitPrintTool(null);
            //				m_blnHasInitPrintTool=true;
            //			}
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                if (m_objCurrentRecordContent == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, m_objCurrentRecordContent.m_dtmOpenDate);
            }
            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint_this();
        }

        private void m_mthStartPrint_this()
        {
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

        protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
        {
            m_mthDemoPrint_FromDataSource();
            return 1;
        }
        #endregion 外部打印.


        #region 作废重做

        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsTrackRecordContent m_objContent = new clsShuXueZhiLiaoyesContent_xj();

                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objContent);
                if (lngRes <= 0 || m_objContent == null)
                {
                    switch (lngRes)
                    {
                        case (long)(iCareData.enmOperationResult.Not_permission):
                            m_mthShowNotPermitted(); break;
                        case (long)(iCareData.enmOperationResult.DB_Fail):
                            m_mthShowDBError(); break;
                    }
                    return blnIsOK;
                }
                clsShuXueZhiLiaoyesContent_xj p_objContent = (clsShuXueZhiLiaoyesContent_xj)m_objContent;

               // this.m_dtpDiscussTime.Text = p_objContent.m_dtmDiscussDate.ToString("yyyy-MM-dd hh:mm:ss");
                //   this.m_txtDiscussAddress.Text = p_objContent.m_strDiscussAddress;
               // this.m_txtCompere.Text = p_objContent.m_strCompereName;
                //this.m_lsvAttendeeList= p_objContent.m_strAttendeeNameArr
                //this.m_lsvAttendeeList.Items.Clear();
                //string[] strAttendeeName = p_objContent.m_strAttendeeNameArr;
                //ListViewItem lviAttendeeName = null;
                //foreach (string i in strAttendeeName)
                //{
                //    lviAttendeeName = new ListViewItem();
                //    lviAttendeeName.Text = i.ToString();
                //    this.m_lsvAttendeeList.Items.Add(lviAttendeeName);
                //}
                txt_yun.Text = p_objContent.m_strYun;
                txt_chan.Text = p_objContent.m_strChan;
                txt_alt.Text = p_objContent.m_strALT;
                txt_hbsag.Text = p_objContent.m_strHBsAg;
                txt_hbs.Text = p_objContent.m_strHBs;
                txt_hbeag.Text = p_objContent.m_strHBeAg;
                txt_hbe.Text = p_objContent.m_strHBe;
                txt_hcv.Text = p_objContent.m_strHCV;
                txt_hivi.Text = p_objContent.m_strHIVI;
                txt_meidu.Text = p_objContent.m_strMeiDu;

                this.txt_mudi.Text = p_objContent.m_strShuXueMuDi;
                this.txt_chengfen.Text = p_objContent.m_strShuXueChengFen;
                this.txt_zduan.Text = p_objContent.m_strZhenDuan;
                this.txt_beizhu.Text = p_objContent.m_strBeiZhu;
                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strRecordID, out objEmpVO);
                if (objEmpVO != null)
                {
                    m_txtRecorder.Tag = objEmpVO;
                    m_txtRecorder.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTECHNICALRANK_CHR;
                }
                if (p_objContent.m_strShuXueShi == "1")
                {
                    rdb_wu.Checked = true;
                }
                if (p_objContent.m_strShuXueShi == "2")
                {
                    rdb_you.Checked = true;
                }
             //  this.m_txtRecorder.Text = p_objContent.m_strRecordName;

                //clsEmrSignToolCollection m_objSign = new clsEmrSignToolCollection();

                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsShuXueZhiLiaoyesPrintTool_xj();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);
                clsPrintInfo_ShuXueZhiLiaoyes_xj objPrintInfo = new clsPrintInfo_ShuXueZhiLiaoyes_xj();


                //objPrintInfo.m_dtmHISInDate = p_objSelectedValue.m_DtmInpatientDate;  //???BEFOREOPERATION
                objPrintInfo.m_dtmInPatientDate = p_objSelectedValue.m_DtmInpatientDate;
                objPrintInfo.m_dtmOpenDate = p_objSelectedValue.m_DtmOpenDate;
                //objPrintInfo.m_strAge = p_objSelectedValue;           
                //objPrintInfo.m_strAreaName
                //objPrintInfo.m_strBedName
                //objPrintInfo.m_strDeptName=
                //objPrintInfo.m_strHISInPatientID=
                objPrintInfo.m_strInPatentID = p_objSelectedValue.m_StrInpatientId;
                //objPrintInfo.m_strPatientName =
                //objPrintInfo.m_strSex=


                clsTrackRecordContent p_objContent = new clsShuXueZhiLiaoyesContent_xj();
                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
                clsShuXueZhiLiaoyesContent_xj objContent = (clsShuXueZhiLiaoyesContent_xj)p_objContent;
                //objPrintInfo.m_objContent = objContent;
                objPrintInfo.m_objRecordContent = objContent;
                //objPrintInfo.m_blnIsFirstPrint = false;

                objPrintTool.m_mthSetPrintContent(objPrintInfo);



                m_mthStartPrint();
                //ppdPrintPreview.Document = m_pdcPrintDocument;
                //ppdPrintPreview.ShowDialog(p_infOwner);
            }
        }

        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;

            new clsInPatientCaseHistoryDomain().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做


    }
}