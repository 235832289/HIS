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
    /// 快速微量血糖检测记录表
    /// </summary>
    public partial class frmEMR_MicroBooldSugarCheck : frmRecordsBase
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
        /// <summary>
        /// 快速微量血糖检测记录表
        /// </summary>
        public frmEMR_MicroBooldSugarCheck()
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
            m_mthAddNewRecord((int)enmDiseaseTrackType.EMR_MicroBooldSugarCheck);
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

            p_dtbRecordTable.Columns.Add("Time_chr", typeof(clsDSTRichTextBoxValue));//5
            p_dtbRecordTable.Columns.Add("Result_chr", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("Sign_chr", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("CreateUserID");//8

            m_mthSetControl(m_dtcRecordDate_chr);
            m_mthSetControl(m_dtcTime_chr);

            m_mthSetControl(m_dtcResult_chr);

            m_mthSetControl(m_dtcSign_chr);

            //设置文字栏


            this.m_dtcRecordDate_chr.HeaderText = "\r\n\r\n\r\n监测日期";
            this.m_dtcTime_chr.HeaderText = "\r\n\r\n\r\n监测时间";
            this.m_dtcResult_chr.HeaderText = "\r\n\r\n\r\n监测结果\r\nmmol/L";
            this.m_dtcSign_chr.HeaderText = "\r\n\r\n\r\n监测人签名";
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
            return new clsRecordsDomain(enmRecordsType.EMR_MicroBooldSugarCheck);
        }
        #endregion

        #region 获取记录的主要信息
        /// <summary>
        /// 获取记录的主要信息(必须获取的是CreateDate,LastModifyDate)
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
                case enmDiseaseTrackType.EMR_MicroBooldSugarCheck:
                    objContent = new clsEMR_MicroBooldSugarCheckValue();
                    break;
            }

            if (objContent == null)
                objContent = new clsEMR_MicroBooldSugarCheckValue();

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
            objContent.m_strCreateUserID = (string)p_objDataArr[8];
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
                case enmDiseaseTrackType.EMR_MicroBooldSugarCheck:
                    return new frmEMR_MicroBooldSugarCheckCon();
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

                clsEMR_MicroBooldSugarCheckDataInfo objInfo = null;

                objInfo = p_objTransDataInfo as clsEMR_MicroBooldSugarCheckDataInfo;

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
                    objData = new object[9];
                    clsEMR_MicroBooldSugarCheckValue objCurrent = objInfo.m_objRecordArr[i];
                    clsEMR_MicroBooldSugarCheckValue objNext = new clsEMR_MicroBooldSugarCheckValue();//下一条记录


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
                    #region 存放关键字段
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        objData[0] = objCurrent.m_dtmRecordDate;//存放记录时间的字符串
                        objData[1] = (int)enmRecordsType.EMR_MicroBooldSugarCheck;//存放记录类型的int值


                        objData[2] = objCurrent.m_dtmCreateDate;//存放记录的OpenDate字符串


                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   

                        //同一个则只在第一行显示日期


                        if (objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd");//日期字符串
                        }

                        objData[8] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   

                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;
                    #endregion ;

                    #region 存放单项信息
                    //监测时间
                    strText = objCurrent.m_strCHECKTIME_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strCHECKTIME_RIGHT != objCurrent.m_strCHECKTIME_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strCHECKTIME_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[5] = objclsDSTRichTextBoxValue;
                    //监测结果
                    strText = objCurrent.m_strCHECKRESULT_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strCHECKRESULT_RIGHT != objCurrent.m_strCHECKRESULT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strCHECKRESULT_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;

                    if (objCurrent.objSignerArr != null)
                    {
                        //签名
                        strText = string.Empty;
                        for (int j = 0; j < objCurrent.objSignerArr.Length; j++)
                        {
                            strText += objCurrent.objSignerArr[j].objEmployee.m_strGetTechnicalRankAndName + " ";
                        }
                        strXml = "<root />";
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objData[7] = objclsDSTRichTextBoxValue;
                    }
                    else //从旧表导过来的数据没有电子签名
                    {
                        clsEmrEmployeeBase_VO objEMP = null;
                        clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                        long lngRes = objDomain.m_lngGetEmpByID(objCurrent.m_strCreateUserID, out objEMP);
                        if (objEMP != null)
                        {
                            strText = objEMP.m_strLASTNAME_VCHR;
                            strXml = "<root />";
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objData[7] = objclsDSTRichTextBoxValue;
                        }
                        objDomain = null;
                    }
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

        #endregion
    }
}