using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
using iCareData;
using com.digitalwave.clsMiniBloodSugarChk_GXServ;
namespace iCare
{
    /// <summary>
    /// 微量血糖检测结果记录录入界面
    /// </summary>
    public partial class frmMiniBooldSugarContent : iCare.frmDiseaseTrackBase
    {

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMiniBooldSugarContent(bool blnAdd)
        {
            InitializeComponent();
            //指明护士工作站表单
            intFormType = 2;
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();

            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse,登录员工);
            m_objSign.m_mthBindEmployeeSign(m_cmbsign, txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

            //标识表单操作
            blnAddRecord = blnAdd;

            //初始化richtextbox控件
            m_mthSetRichTextBoxAttribInControl(this);

        } 
        #endregion

        #region 字段
        /// <summary>
        /// 病人记录住院号
        /// </summary>
        public string strRecordInPatientID;        
        /// <summary>
        /// 病人记录入院时间
        /// </summary>
        public string strRecordInPatientDate;
        /// <summary>
        /// 病人记录创建时间
        /// </summary>
        public string strRecordCreateDate;
        /// <summary>
        /// 定义签名类
        /// </summary>
        private clsEmrSignToolCollection m_objSign;
        /// <summary>
        /// 当前操作记录
        /// </summary>
        private clsMiniBloodSugarChkValue_GX m_objRecord;

        /// <summary>
        /// 标识当前记录操作是新增还是修改
        /// true＝新增；false＝修改；
        /// 默认新增
        /// </summary>
        private bool blnAddRecord = true;

        #endregion

        #region 属性
        /// <summary>
        /// 是否新添加记录。true，新添加；false，修改。
        /// </summary>
        protected override bool m_BlnIsAddNew
        {
            get
            {
                return blnAddRecord;
            }
        }
        #endregion

        #region 方法
        // <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        private void m_mthClearRecordInfo()
        {
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);
            //清空记录内容
            cmbMealType.Text = "";
            m_txtValue.m_mthClearText();
            m_txtDesription.Text = "";
            m_dtpCreateDate.Value = DateTime.Now;
            //默认控件输入痕迹
            m_mthSetModifyControl(null, true);
        }

 
        /// <summary>
        /// 当打开窗体时load数据
        /// </summary>
        private void m_mthLoad()
        {
            clsMiniBloodSugarChk_GXServ objservice =
                (clsMiniBloodSugarChk_GXServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMiniBloodSugarChk_GXServ));

            //检查参数
            if (strRecordInPatientID==null|| strRecordInPatientID==string.Empty)
            {
                MessageBox.Show("未指定记录", "iCare message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                long lngRes = objservice.m_lngGetRecoedByInPatient(null, strRecordInPatientID, DateTime.Parse(strRecordInPatientDate), DateTime.Parse(strRecordCreateDate), out m_objRecord);
                if (m_objRecord!=null)
                {
                    m_mthSetGUIFromContent(m_objRecord);

                    m_mthEnableModify(false);

                    m_mthSetModifyControl(m_objRecord, false);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objservice = null;
            }
 
        }
        /// <summary>
        /// 将指定的记录数据load到窗体上
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsMiniBloodSugarChkValue_GX objContent = (clsMiniBloodSugarChkValue_GX)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_dtpCreateDate.Value = objContent.m_dtmOpenDate;
            cmbMealType.Text = objContent.m_strMeatType;
            m_txtValue.Text = objContent.m_strBloodSugar;
            m_txtValue.m_mthSetNewText(objContent.m_strBloodSugar, objContent.m_strBloodSugarXML);
            m_txtDesription.Text = objContent.m_strDescription;

            #region 签名集合
            m_mthAddSignToTextBoxBase(new TextBoxBase[] { txtSign }, p_objContent.objSignerArr, new bool[] { true }, false);
            //txtSign.Clear();
            //if (objContent.objSignerArr != null)
            //{
            //    for (int i = 0; i < objContent.objSignerArr.Length; i++)
            //    {
            //        if (objContent.objSignerArr[i].controlName == "txtSign")
            //        {
            //            txtSign.Text = objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
            //            txtSign.Tag = objContent.objSignerArr[i].objEmployee; ;
            //        }
            //    }
            //}
            #endregion 签名		
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubAddNew()
        {
            long lngRes=0;

            clsMiniBloodSugarChk_GXServ objservice =
                (clsMiniBloodSugarChk_GXServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMiniBloodSugarChk_GXServ));

            try
            {

                #region 获取内容
                //获取内容
                m_objRecord.m_strInPatientID = strRecordInPatientID;
                m_objRecord.m_dtmInPatientDate = DateTime.Parse(strRecordInPatientDate);
                m_objRecord.m_dtmOpenDate = m_dtpCreateDate.Value; //记录时间取窗体上控件值
                m_objRecord.m_dtmCreateDate = DateTime.Now;          //创建时间取当前时间
                m_objRecord.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                m_objRecord.m_strMeatType = cmbMealType.Text;
                m_objRecord.m_strBloodSugar_Right = m_txtValue.m_strGetRightText();
                m_objRecord.m_strBloodSugar = m_txtValue.Text;
                m_objRecord.m_strBloodSugarXML = m_txtValue.m_strGetXmlText();
                m_objRecord.m_strDescription = m_txtDesription.Text;

                //获取lsvsign签名
                m_objRecord.objSignerArr = new clsEmrSigns_VO[1];
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref m_objRecord.objSignerArr, ref strUserIDList, ref strUserNameList);
                //for (int i = 0; i < 1; i++)
                //{
                //    m_objRecord.objSignerArr[i] = new clsEmrSigns_VO();
                //    m_objRecord.objSignerArr[i].objEmployee = new clsEmrEmployeeBase_VO();
                //    m_objRecord.objSignerArr[i].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
                //    m_objRecord.objSignerArr[i].controlName = "txtSign";
                //    m_objRecord.objSignerArr[i].m_strFORMID_VCHR = "frmMiniBooldSugarContent";//注意大小写
                //    m_objRecord.objSignerArr[i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
                //    //痕迹格式 0972,0324,

                //    strUserIDList = strUserIDList + m_objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim() + ",";
                //    strUserNameList = strUserNameList + m_objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim() + ",";
                //}
                m_objRecord.m_strModifyUserID = strUserIDList;
                #endregion

                ArrayList objSignerArr = new ArrayList();
                for (int i = 0; i < m_objRecord.objSignerArr.Length; i++)
                {
                    if (m_objRecord.objSignerArr[i].controlName == "lsvSign" || m_objRecord.objSignerArr[i].controlName == "txtSign")
                        objSignerArr.Add(m_objRecord.objSignerArr[i].objEmployee);
                }
                //数字签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = m_objRecord.m_strInPatientID.Trim() + "-" + m_objRecord.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
                clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                if (objCheck.CheckSigner(m_objRecord, objSign_VO) == -1)
                    return -1;
                //保存记录
                clsPreModifyInfo objModifyInfo = null;
                lngRes = objservice.m_lngAddNewRecoed(null, m_objRecord);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objservice = null;
            }

            return lngRes;

        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubModify()
        {
            long lngRes = 0;

            clsMiniBloodSugarChk_GXServ objservice =
                (clsMiniBloodSugarChk_GXServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMiniBloodSugarChk_GXServ));

            try
            {

                #region 获取内容
                //获取内容
                m_objRecord.m_strInPatientID = strRecordInPatientID;
                m_objRecord.m_dtmInPatientDate = DateTime.Parse(strRecordInPatientDate);
                m_objRecord.m_dtmOpenDate = m_dtpCreateDate.Value; //记录时间取窗体上控件值
                m_objRecord.m_dtmCreateDate = DateTime.Now;          //创建时间取当前时间
                m_objRecord.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                m_objRecord.m_dtmModifyDate = DateTime.Now;
                m_objRecord.m_strMeatType = cmbMealType.Text;
                m_objRecord.m_strBloodSugar_Right = m_txtValue.m_strGetRightText();
                m_objRecord.m_strBloodSugar = m_txtValue.Text;
                m_objRecord.m_strBloodSugarXML = m_txtValue.m_strGetXmlText();
                m_objRecord.m_strDescription = m_txtDesription.Text;

                //获取lsvsign签名
                m_objRecord.objSignerArr = new clsEmrSigns_VO[1];
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref m_objRecord.objSignerArr, ref strUserIDList, ref strUserNameList);
                //for (int i = 0; i < 1; i++)
                //{
                //    m_objRecord.objSignerArr[i] = new clsEmrSigns_VO();
                //    m_objRecord.objSignerArr[i].objEmployee = new clsEmrEmployeeBase_VO();
                //    m_objRecord.objSignerArr[i].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
                //    m_objRecord.objSignerArr[i].controlName = "txtSign";
                //    m_objRecord.objSignerArr[i].m_strFORMID_VCHR = "frmMiniBooldSugarContent";//注意大小写
                //    m_objRecord.objSignerArr[i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
                //    //痕迹格式 0972,0324,

                //    strUserIDList = strUserIDList + m_objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim() + ",";
                //    strUserNameList = strUserNameList + m_objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim() + ",";
                //}
                m_objRecord.m_strModifyUserID = strUserIDList;
                #endregion

                ArrayList objSignerArr = new ArrayList();
                for (int i = 0; i < m_objRecord.objSignerArr.Length; i++)
                {
                    if (m_objRecord.objSignerArr[i].controlName == "lsvSign" || m_objRecord.objSignerArr[i].controlName == "txtSign")
                        objSignerArr.Add(m_objRecord.objSignerArr[i].objEmployee);
                }
                //数字签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = m_objRecord.m_strInPatientID.Trim() + "-" + m_objRecord.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
                clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                if (objCheck.CheckSigner(m_objRecord, objSign_VO) == -1)
                    return -1;
                //保存记录
                clsPreModifyInfo objModifyInfo = null;
                lngRes = objservice.m_lngModifyRecoed(null, m_objRecord);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objservice = null;
            }

            return lngRes;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubDelete()
        {
            //return base.m_lngSubDelete();
            return 1;
        }
         #endregion

        #region 事件

        /// <summary>
        /// 窗体load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMiniBooldSugarContent_Load(object sender, EventArgs e)
        {
            if (blnAddRecord != null)
            {
                m_mthLoad();
            }
            else 
            {
                m_mthClearRecordInfo();
            }
        }
        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConfirm_Click(object sender, EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

      
    }
}