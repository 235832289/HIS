using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using com.digitalwave.emr.BEDExplorer;

namespace iCare
{
    /// <summary>
    /// 产程记录
    /// </summary>
    public partial class frmWaitLayRecord_Acad_GX : iCare.frmRecordsBase
    {
        #region 全局变量
        /// <summary>
        /// 设置初始的比较日期

        /// </summary>
        private DateTime m_dtmPreRecordDate;
        private string m_strCurrentOpenDate = "";
        private string m_strCreateUserID = "";
        #endregion

        #region 构造函数


        public frmWaitLayRecord_Acad_GX()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件
        private void mniAppend_Click(object sender, EventArgs e)
        {
            PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF), this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
            m_mthAddNewRecord((int)enmDiseaseTrackType.EMR_WAITLAYRECORD_GX);
        } 
        #endregion

        #region 方法、属性


        #region DataGrid标头字体
        /// <summary>
        /// DataGrid标头字体
        /// </summary>
        protected override Font m_FntHeaderFont
        {
            get
            {
                return new System.Drawing.Font("SimSun", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            }
        }
         #endregion

        #region 初始化具体表单的DataTable
        // 初始化具体表单的DataTable。(需要改动)
        // 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
        protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
        {
            //存放记录时间的字符串
            p_dtbRecordTable.Columns.Add("RecordDate");//0
            //存放记录类型的int值


            DataColumn dcRecordType = new DataColumn("RecordType", typeof(int));
            p_dtbRecordTable.Columns.Add(dcRecordType);//1
            //存放记录的OpenDate字符串


            p_dtbRecordTable.Columns.Add("OpenDate");  //2
            //存放记录的ModifyDate字符串


            p_dtbRecordTable.Columns.Add("ModifyDate"); //3

            DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDate_Day");//4
            dc1.DefaultValue = "";
            DataColumn dc2 = p_dtbRecordTable.Columns.Add("RecordDate_Time");//5
            dc2.DefaultValue = "";

            p_dtbRecordTable.Columns.Add("BloodPressure", typeof(clsDSTRichTextBoxValue));//6

            p_dtbRecordTable.Columns.Add("EmbryoHeart_chr", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("Intermission_chr", typeof(clsDSTRichTextBoxValue));//8
            p_dtbRecordTable.Columns.Add("Persist_chr", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("Intensity_chr", typeof(clsDSTRichTextBoxValue));//10	
            p_dtbRecordTable.Columns.Add("PalaceMouth_chr", typeof(clsDSTRichTextBoxValue));//11
            p_dtbRecordTable.Columns.Add("Show_chr", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("Caul_chr", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("AnusCheck_chr", typeof(clsDSTRichTextBoxValue));//14
            p_dtbRecordTable.Columns.Add("Remark_chr", typeof(clsDSTRichTextBoxValue));//15
            p_dtbRecordTable.Columns.Add("Scrutator_chr", typeof(clsDSTRichTextBoxValue));//16
            p_dtbRecordTable.Columns.Add("CreateUserID");//17

            m_mthSetControl(m_dtcRecordDate_chr);
            m_mthSetControl(m_dtcTime_chr);

            m_mthSetControl(m_dtcBloodPressure);

            m_mthSetControl(m_dtcEmbryoHeart_chr);
            m_mthSetControl(m_dtcIntermission_chr);
            m_mthSetControl(m_dtcPersist_chr);
            m_mthSetControl(m_dtcIntensity_chr);
            m_mthSetControl(m_dtcPalaceMouth_chr);
            m_mthSetControl(m_dtcShow_chr);
            m_mthSetControl(m_dtcCaul_chr);
            m_mthSetControl(m_dtcAnusCheck_chr);
            m_mthSetControl(m_dtcRemark_chr);
            m_mthSetControl(m_dtcScrutator_chr);

            //设置文字栏


            this.m_dtcRecordDate_chr.HeaderText = "日\r\n\r\n\r\n\r\n\r\n\r\n期";
            this.m_dtcTime_chr.HeaderText = "时\r\n\r\n\r\n\r\n\r\n\r\n间";
            this.m_dtcBloodPressure.HeaderText = "血\r\n\r\n压\r\n\r\nmmHg";


            this.m_dtcEmbryoHeart_chr.HeaderText = "胎\r\n\r\n\r\n\r\n心\r\n\r\n(次/分)";
            this.m_dtcIntermission_chr.HeaderText = "宫\r\n缩\r\n间\r\n歇\r\n\r\n(分)";
            this.m_dtcPersist_chr.HeaderText = "宫\r\n缩\r\n持\r\n续\r\n\r\n(秒)";
            this.m_dtcIntensity_chr.HeaderText = "宫\r\n缩\r\n强\r\n度";
            this.m_dtcPalaceMouth_chr.HeaderText = "宫\r\n\r\n\r\n\r\n口\r\n\r\n(cm)";
            this.m_dtcShow_chr.HeaderText = "先\r\n\r\n\r\n\r\n露\r\n\r\n(S)";
            this.m_dtcCaul_chr.HeaderText = "胎\r\n\r\n\r\n\r\n\r\n\r\n膜";
            this.m_dtcAnusCheck_chr.HeaderText = "肛\r\n\r\n\r\n\r\n\r\n\r\n查";
            this.m_dtcRemark_chr.HeaderText = "附\r\n\r\n\r\n\r\n\r\n\r\n注";
            this.m_dtcScrutator_chr.HeaderText = "检\r\n\r\n查\r\n\r\n者";
        }
        #endregion

        #region 属性


        /// <summary>
        /// 当前入院时间
        /// </summary>
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

        //(需要改动)
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.Nurses; }
        }
        /// <summary>
        /// 记录者ID?
        /// </summary>
        protected override string m_StrRecorder_ID
        {
            get
            {
                return m_strCreateUserID;
            }
        }
        #endregion 属性



        #region 清空特殊记录信息
        // 清空特殊记录信息，并重置记录控制状态为不控制

        protected override void m_mthClearRecordInfo()
        {
            m_dtmPreRecordDate = DateTime.MinValue;
            m_dtgRecordDetail.CurrentRowIndex = 0;
            m_dtbRecords.Rows.Clear();

            m_txtLayTimes.Clear();
            m_dtpLayDate.Clear();
        }
        #endregion

        #region 获取痕迹保留
        /// <summary>
        /// 获取痕迹保留
        /// </summary>
        /// <param name="p_strText"></param>
        /// <param name="p_strModifyUserID"></param>
        /// <param name="p_strModifyUserName"></param>
        /// <returns></returns>
        private string m_strGetDSTTextXML(string p_strText, string p_strModifyUserID, string p_strModifyUserName)
        {
            return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText, p_strModifyUserID, p_strModifyUserName, Color.Black, Color.White);
        }
        #endregion

        #region 获取病程记录的领域层实例
        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsRecordsDomain m_objGetRecordsDomain()
        {
            return new clsRecordsDomain(enmRecordsType.EMR_WAITLAYRECORD_GX);
        }
        #endregion

        #region 获取记录的主要信息


        /// <summary>
        /// 获取记录的主要信息（必须获取的是CreateDate,LastModifyDate）
        /// </summary>
        /// <param name="p_intRecordType"></param>
        /// <param name="p_objDataArr"></param>
        /// <returns></returns>
        protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
            object[] p_objDataArr)
        {
            //根据 p_intRecordType 获取对应的 clsTrackRecordContent
            clsTrackRecordContent objContent = null;
            switch ((enmDiseaseTrackType)p_intRecordType)
            {
                case enmDiseaseTrackType.EMR_WAITLAYRECORD_GX:
                    objContent = new clsEMR_WAITLAYRECORD_GX();
                    break;
            }

            if (objContent == null)
                objContent = new clsEMR_WAITLAYRECORD_GX();

            if (m_objCurrentPatient != null)
                objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            else
            {
                clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
                return null;
            }
            int intSelectedRecordStartRow = m_dtgRecordDetail.CurrentCell.RowNumber;

            objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
            objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[2]);
            objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);
            objContent.m_strCreateUserID = (string)p_objDataArr[17];
            if (frmHRPExplorer.objpCurrentPatient == null)
                objContent.m_strRegisterID = frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

            return objContent;
        }
        #endregion

        #region 获取处理（添加和修改）记录的窗体
        /// <summary>
        /// 获取处理（添加和修改）记录的窗体
        /// </summary>
        /// <param name="p_intRecordType"></param>
        /// <returns></returns>
        protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
        {
            switch ((enmDiseaseTrackType)p_intRecordType)
            {
                case enmDiseaseTrackType.EMR_WAITLAYRECORD_GX:
                    return new frmWaitLayRecord_AcadCon_GX(this.m_txtLayTimes.Text, this.m_dtpLayDate.Text);
            }

            return null;
        }
        #endregion

        #region 处理子窗体


        /// <summary>
        /// 处理子窗体
        /// </summary>
        /// <param name="p_frmSubForm"></param>
        protected override void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
        {
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
        }
        #endregion

        #region 从Table删除数据
        /// <summary>
        /// 从Table删除数据
        /// </summary>
        /// <param name="p_intRecordType"></param>
        /// <param name="p_dtmCreateRecordTime"></param>
        protected override void m_mthRemoveDataFromDataTable(int p_intRecordType,
            DateTime p_dtmCreateRecordTime)
        {
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
        }
        #endregion

        #region 获取当前病人的作废内容


        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            m_mthGetDeletedRecord(p_intFormID, p_dtmRecordDate);
        }
        #endregion

        #region 修改选定记录
        /// <summary>
        /// 修改选定记录
        /// </summary>
        /// <param name="p_intRecordType"></param>
        /// <param name="p_dtmCreateRecordTime"></param>
        protected override void m_mthModifyRecord(int p_intRecordType,
            DateTime p_dtmCreateRecordTime)
        {
            PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF), this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
            //获取添加记录的窗体


            frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType);
            frmAddNewForm.m_mthSetDiseaseTrackInfo(m_objCurrentPatient, p_dtmCreateRecordTime);

            m_mthShowSubForm(frmAddNewForm, p_intRecordType, true);
        }
        #endregion

        #region 清空记录
        /// <summary>
        /// 清空记录
        /// </summary>
        protected override void m_mthClearPatientRecordInfo()
        {
            m_mthSetDataGridFirstRowFocus();
            m_dtgRecordDetail.CurrentRowIndex = 0;
            m_dtbRecords.Rows.Clear();
            //清空记录内容                       
            m_mthClearRecordInfo();

            m_txtLayTimes.Clear();
            m_dtpLayDate.Clear();
        }
        #endregion

        #region 从数据库中查找数据


        /// <summary>
        /// 从数据库中查找数据
        /// </summary>
        /// <param name="p_objTansDataInfoArr"></param>
        protected override void m_mthGetTransDataInfoArr(out clsTransDataInfo[] p_objTansDataInfoArr)
        {
            m_objRecordsDomain.m_lngGetTransDataInfoArr(m_objCurrentPatient.m_StrRegisterId, out p_objTansDataInfoArr);

        } 
        #endregion

        #region 获取显示到DataGrid的数据


        /// <summary>
        /// 获取显示到DataGrid的数据
        /// </summary>
        /// <param name="p_objTransDataInfo"></param>
        /// <returns></returns>
        protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
        {
            #region 显示记录到DataGrid
            try
            {
                object[] objData;
                ArrayList objReturnData = new ArrayList();

                clsEMR_WAITLAYRECORD_GXDataInfo objInfo = null;

                objInfo = p_objTransDataInfo as clsEMR_WAITLAYRECORD_GXDataInfo;

                if (objInfo == null || objInfo.m_objRecordArr == null)
                    return null;

                int intRecordCount = objInfo.m_objRecordArr.Length;
                clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
                string strText, strXml;

                #region 获取修改限定时间
                int intCanModifyTime = 0;
                try
                {
                    intCanModifyTime = int.Parse(m_strCanModifyTime);
                }
                catch
                {
                    intCanModifyTime = 6;
                }
                #endregion

                for (int i = 0; i < intRecordCount; i++)
                {
                    objData = new object[18];
                    clsEMR_WAITLAYRECORD_GX objCurrent = objInfo.m_objRecordArr[i];
                    clsEMR_WAITLAYRECORD_GX objNext = new clsEMR_WAITLAYRECORD_GX();//下一条记录


                    if (i < intRecordCount - 1)
                        objNext = objInfo.m_objRecordArr[i + 1];

                    //如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim())
                    {
                        TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                        if ((int)tsModify.TotalHours < intCanModifyTime)
                        {
                            continue;
                        }
                    }

                    m_txtLayTimes.Text = objCurrent.m_strLAYCOUNT_CHR;
                    if (objCurrent.m_dtmBEFOREHAND != DateTime.MinValue)
                        m_dtpLayDate.Text = objCurrent.m_dtmBEFOREHAND.ToString("yyyy年MM月dd日");
                    #region 存放关键字段
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        objData[0] = objCurrent.m_dtmRecordDate;//存放记录时间的字符串
                        objData[1] = (int)enmRecordsType.EMR_WAITLAYRECORD_GX;//存放记录类型的int值


                        objData[2] = objCurrent.m_dtmCreateDate;//存放记录的OpenDate字符串


                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   

                        //同一个则只在第一行显示日期


                        if (objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd");//日期字符串


                        }
                        //修改后带有痕迹的记录不再显示时间
                        if (m_dtmPreRecordDate != objCurrent.m_dtmRecordDate)
                            objData[5] = objCurrent.m_dtmRecordDate.ToString("HH:mm");//时间字符串



                        objData[17] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   

                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;
                    #endregion ;

                    #region 存放单项信息
                    //血压


                    strText = objCurrent.m_strBLOODPRESSURE_S_CHR_RIGHT + "/" + objCurrent.m_strBLOODPRESSURE_A_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && (objNext.m_strBLOODPRESSURE_S_CHR_RIGHT + "/" + objNext.m_strBLOODPRESSURE_A_CHR_RIGHT) != (objCurrent.m_strBLOODPRESSURE_S_CHR_RIGHT + "/" + objCurrent.m_strBLOODPRESSURE_A_CHR_RIGHT))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(strText, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;
                    //胎心
                    strText = objCurrent.m_strEMBRYOHEART_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strEMBRYOHEART_CHR_RIGHT != objCurrent.m_strEMBRYOHEART_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strEMBRYOHEART_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[7] = objclsDSTRichTextBoxValue;
                    //宫缩>>间歇
                    strText = objCurrent.m_strINTERMISSION_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strINTERMISSION_CHR_RIGHT != objCurrent.m_strINTERMISSION_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strINTERMISSION_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[8] = objclsDSTRichTextBoxValue;
                    //宫缩>>持续
                    strText = objCurrent.m_strPERSIST_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strPERSIST_CHR_RIGHT != objCurrent.m_strPERSIST_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strPERSIST_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;
                    //宫缩>>强度
                    strText = objCurrent.m_strINTENSITY_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strINTENSITY_CHR_RIGHT != objCurrent.m_strINTENSITY_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strINTENSITY_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[10] = objclsDSTRichTextBoxValue;
                    //宫口
                    strText = objCurrent.m_strPALACEMOUTH_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strPALACEMOUTH_CHR_RIGHT != objCurrent.m_strPALACEMOUTH_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strPALACEMOUTH_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[11] = objclsDSTRichTextBoxValue;
                    //先露
                    strText = objCurrent.m_strSHOW_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strSHOW_CHR_RIGHT != objCurrent.m_strSHOW_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strSHOW_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;
                    //胎膜
                    strText = objCurrent.m_strCAUL_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strCAUL_CHR_RIGHT != objCurrent.m_strCAUL_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strCAUL_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[13] = objclsDSTRichTextBoxValue;
                    //肛(阴)查

                    strText = objCurrent.m_strANUSCHECK_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strANUSCHECK_CHR_RIGHT != objCurrent.m_strANUSCHECK_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strANUSCHECK_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[14] = objclsDSTRichTextBoxValue;
                    //附注
                    strText = objCurrent.m_strREMARK_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strREMARK_CHR_RIGHT != objCurrent.m_strREMARK_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strREMARK_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[15] = objclsDSTRichTextBoxValue;

                    strText = string.Empty;
                    if (objCurrent.objSignerArr != null)
                    {
                        //签名
                        for (int j = 0; j < objCurrent.objSignerArr.Length; j++)
                        {
                            strText += objCurrent.objSignerArr[j].objEmployee.m_strGetTechnicalRankAndName + " ";
                        }
                    }
                    if (objCurrent.m_strCHECKEMP_RIGHT != null)
                    {
                        strText += " " + objCurrent.m_strCHECKEMP_RIGHT;
                    }
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[16] = objclsDSTRichTextBoxValue;
                    #endregion
                    objReturnData.Add(objData);
                }
                object[][] m_objRe = new object[objReturnData.Count][];

                for (int m = 0; m < objReturnData.Count; m++)
                    m_objRe[m] = (object[])objReturnData[m];
                return m_objRe;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            #endregion
        }
        #endregion 

        #region 更新孕／产次及预产期至数据库
        /// <summary>
        /// 更新孕／产次及预产期至数据库
        /// </summary>
        protected override void m_mthSave()
        {
            if (m_objCurrentPatient == null)
            {
                return;
            }
            DateTime dtmLayTime = DateTime.MinValue;
            if (DateTime.TryParse(m_dtpLayDate.Text, out dtmLayTime))
            {
                dtmLayTime = Convert.ToDateTime(dtmLayTime.ToString("yyyy-MM-dd"));
            }
            else
            {
                dtmLayTime = Convert.ToDateTime(DateTime.MinValue.ToString("yyyy-MM-dd"));
            }

            com.digitalwave.clsRecordsService.clsEMR_WAITLAYRECORD_GXMainServ objServ =
                    (com.digitalwave.clsRecordsService.clsEMR_WAITLAYRECORD_GXMainServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsEMR_WAITLAYRECORD_GXMainServ));

            long lngRes = objServ.m_lngSaveLayInfo(m_objCurrentPatient.m_StrRegisterId, m_txtLayTimes.Text, dtmLayTime);

            if (lngRes > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("保存成功");
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("未成功更新孕／产次及预产期至数据库。");
            }
        } 
        #endregion
        #endregion
    }
}