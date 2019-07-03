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
    /// 妊娠糖尿病治疗表
    /// </summary>
    public partial class frmEMR_GestationDiabetesCure : frmRecordsBase
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
        /// 妊娠糖尿病治疗表
        /// </summary>
        public frmEMR_GestationDiabetesCure()
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
            int i1 = (int)enmDiseaseTrackType.EMR_GestationDiabetesCure;
            m_mthAddNewRecord((int)enmDiseaseTrackType.EMR_GestationDiabetesCure);
        }
        #endregion

        #region 调用打印
        /// <summary>
        /// 调用打印
        /// </summary>
        /// <returns></returns>
        protected override infPrintRecord m_objGetPrintTool()
        {
            if (this.m_dtgRecordDetail.DataSource == null)
            {
                MessageBox.Show("沒有数据不能打印");
                return null;
            }
            else
            {
                clsEMR_GestationDiabetesCure_PrintTool_1 frmwcon = new clsEMR_GestationDiabetesCure_PrintTool_1();
                return frmwcon;
            }
        }
        #endregion
        /// <summary>
        ///  开始打印。
        /// </summary>
        protected override void m_mthStartPrint()
        {
            if (m_blnDirectPrint)
            {
                m_pdcPrintDocument.Print();
            }
            else
            {
              // ((clsEMR_GestationDiabetesCure_PrintTool_1)objPrintTool).m_mthPrintPage();

            }
           			base.m_mthStartPrint();
        }

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

            p_dtbRecordTable.Columns.Add("m_dtcGestationWeeks_vchr", typeof(clsDSTRichTextBoxValue));//5
            p_dtbRecordTable.Columns.Add("m_dtcAvoirdupois_vchr", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("m_dtcStapleMeasure_vchr", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("m_dtcInsulinLong_vchr", typeof(clsDSTRichTextBoxValue));//8
            p_dtbRecordTable.Columns.Add("m_dtcInsulinShortMorning_vchr", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("m_dtcInsulinShortNoon_vchr", typeof(clsDSTRichTextBoxValue));//10
            p_dtbRecordTable.Columns.Add("m_dtcInsulinShortNight_vchr", typeof(clsDSTRichTextBoxValue));//11
            p_dtbRecordTable.Columns.Add("m_dtcBloodSugarlimosis_vchr", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("m_dtcBloodSugarBe_BF_vchr", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("m_dtcBloodSugarAf_BF_vchr", typeof(clsDSTRichTextBoxValue));//14
            p_dtbRecordTable.Columns.Add("m_dtcBloodSugarBe_Lun_vchr", typeof(clsDSTRichTextBoxValue));//15
            p_dtbRecordTable.Columns.Add("m_dtcBloodSugarAf_Lun_vchr", typeof(clsDSTRichTextBoxValue));//16
            p_dtbRecordTable.Columns.Add("m_dtcBloodSugarBe_Sup_vchr", typeof(clsDSTRichTextBoxValue));//17
            p_dtbRecordTable.Columns.Add("m_dtcBloodSugarAf_Sup_vchr", typeof(clsDSTRichTextBoxValue));//18
            p_dtbRecordTable.Columns.Add("m_dtcUreaketone_vchr", typeof(clsDSTRichTextBoxValue));//19
            p_dtbRecordTable.Columns.Add("Sign_chr", typeof(clsDSTRichTextBoxValue));//20
            p_dtbRecordTable.Columns.Add("CreateUserID");//21

            m_mthSetControl(m_dtcRecordDate_chr);
            ////
            m_mthSetControl(m_dtcGestationWeeks_vchr);
            m_mthSetControl(m_dtcAvoirdupois_vchr);
            m_mthSetControl(m_dtcStapleMeasure_vchr);
            m_mthSetControl(m_dtcInsulinLong_vchr);
            m_mthSetControl(m_dtcInsulinShortMorning_vchr);
            m_mthSetControl(m_dtcInsulinShortNoon_vchr);
            m_mthSetControl(m_dtcInsulinShortNight_vchr);
            m_mthSetControl(m_dtcBloodSugarlimosis_vchr);
            m_mthSetControl(m_dtcBloodSugarBe_BF_vchr);
            m_mthSetControl(m_dtcBloodSugarAf_BF_vchr);
            m_mthSetControl(m_dtcBloodSugarBe_Lun_vchr);
            m_mthSetControl(m_dtcBloodSugarAf_Lun_vchr);
            m_mthSetControl(m_dtcBloodSugarBe_Sup_vchr);
            m_mthSetControl(m_dtcBloodSugarAf_Sup_vchr);
            m_mthSetControl(m_dtcUreaketone_vchr);
            ////
            m_mthSetControl(m_dtcSign_chr);

            //设置文字栏
            this.m_dtcRecordDate_chr.HeaderText = "\r\n\r\n日\r\n\r\n期\r\n";
            this.m_dtcGestationWeeks_vchr.HeaderText = "\r\n\r\n孕\r\n\r\n周\r\n";
            this.m_dtcAvoirdupois_vchr.HeaderText = "\r\n体\r\n重\r\n单\r\n位\r\n(kg)\r\n";
            m_dtcStapleMeasure_vchr.HeaderText = "\r\n主\r\n食\r\n量\r\n(两)\r\n";
            m_dtcInsulinLong_vchr.HeaderText = "\r\n胰\r\n素\r\n岛\r\n用\r\n量\r\nIU\r\n（长效）\r\n";
            m_dtcInsulinShortMorning_vchr.HeaderText = "\r\n胰\r\n岛\r\n素\r\n用\r\n量\r\nIU\r\n（短效）\r\n早\r\n";
            m_dtcInsulinShortNoon_vchr.HeaderText = "\r\n胰\r\n岛\r\n素\r\n用\r\n量\r\nIU\r\n（短效）\r\n中\r\n";
            m_dtcInsulinShortNight_vchr.HeaderText = "\r\n胰\r\n岛\r\n素\r\n用\r\n量\r\nIU\r\n（短效）\r\n晚\r\n";
            m_dtcBloodSugarlimosis_vchr.HeaderText = "\r\n血\r\n糖\r\n定\r\n量\r\nmmol/L\r\n（空腹）\r\n";
            m_dtcBloodSugarBe_BF_vchr.HeaderText = "\r\n血\r\n糖\r\n定\r\n量\r\nmmol/L\r\n（早饭前）\r\n";
            m_dtcBloodSugarAf_BF_vchr.HeaderText = "\r\n血\r\n糖\r\n定\r\n量\r\nmmol/L\r\n（早饭后）\r\n";
            m_dtcBloodSugarBe_Lun_vchr.HeaderText = "\r\n血\r\n糖\r\n定\r\n量\r\nmmol/L\r\n（午饭前）\r\n";
            m_dtcBloodSugarAf_Lun_vchr.HeaderText = "\r\n血\r\n糖\r\n定\r\n量\r\nmmol/L\r\n（午饭后）\r\n";
            m_dtcBloodSugarBe_Sup_vchr.HeaderText = "\r\n血\r\n糖\r\n定\r\n量\r\nmmol/L\r\n（晚饭前）\r\n";
            m_dtcBloodSugarAf_Sup_vchr.HeaderText = "\r\n血\r\n糖\r\n定\r\n量\r\nmmol/L\r\n（晚饭后）\r\n";
            m_dtcUreaketone_vchr.HeaderText = "\r\n\r\n尿\r\n\r\n酮\r\n";
            this.m_dtcSign_chr.HeaderText = "\r\n监\r\n人\r\n测\r\n签\r\n名\r\n";
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
        /// <summary>
        /// 清空特殊记录信息
        /// </summary>
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
            return new clsRecordsDomain(enmRecordsType.EMR_GestationDiabetesCure);
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
                case enmDiseaseTrackType.EMR_GestationDiabetesCure:
                    objContent = new clsEMR_GestationDiabetesCureValue();
                    break;
            }

            if (objContent == null)
                objContent = new clsEMR_GestationDiabetesCureValue();

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
            objContent.m_strCreateUserID = (string)p_objDataArr[21];
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
                case enmDiseaseTrackType.EMR_GestationDiabetesCure:
                    return new frmEMR_GestationDiabetesCureCon();
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
                clsEMR_GestationDiabetesCureDataInfo objInfo = null;
                objInfo = p_objTransDataInfo as clsEMR_GestationDiabetesCureDataInfo;
                if (objInfo == null || objInfo.m_objRecordArr == null)
                {
                    return null;
                }
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
                    objData = new object[22];
                    clsEMR_GestationDiabetesCureValue objCurrent = objInfo.m_objRecordArr[i];
                    clsEMR_GestationDiabetesCureValue objNext = new clsEMR_GestationDiabetesCureValue();//下一条记录
                    if (i < intRecordCount - 1)
                    {
                        objNext = objInfo.m_objRecordArr[i + 1];
                    }
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
                        objData[1] = (int)enmRecordsType.EMR_GestationDiabetesCure;//存放记录类型的int值
                        objData[2] = objCurrent.m_dtmCreateDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
                        //同一个则只在第一行显示日期
                        if (objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd");//日期字符串
                        }
                        objData[21] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   
                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;
                    #endregion ;

                    #region 存放单项信息
                    //妊周
                    strText = objCurrent.m_strGestationWeeks_right.ToString(); 
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strGestationWeeks_right != objCurrent.m_strGestationWeeks_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strGestationWeeks_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[5] = objclsDSTRichTextBoxValue;
                    //体重 单位kg
                    strText = objCurrent.m_strAvoirdupois_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strAvoirdupois_right != objCurrent.m_strAvoirdupois_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strAvoirdupois_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;

                    //主食量 (两)
                    strText = objCurrent.m_strStapleMeasure_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strStapleMeasure_right != objCurrent.m_strStapleMeasure_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strStapleMeasure_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[7] = objclsDSTRichTextBoxValue;

                    //胰岛素用量IU（长效）
                    strText = objCurrent.m_strInsulinLong_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strInsulinLong_right != objCurrent.m_strInsulinLong_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strInsulinLong_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[8] = objclsDSTRichTextBoxValue;

                    //胰岛素用量IU（短效） 早
                    strText = objCurrent.m_strInsulinShortMorning_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strInsulinShortMorning_right != objCurrent.m_strInsulinShortMorning_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strInsulinShortMorning_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;

                    //胰岛素用量IU（短效） 中
                    strText = objCurrent.m_strInsulinShortNoon_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strInsulinShortNoon_right != objCurrent.m_strInsulinShortNoon_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strInsulinShortNoon_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[10] = objclsDSTRichTextBoxValue;

                    //胰岛素用量IU（短效） 晚
                    strText = objCurrent.m_strInsulinShortNight_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strInsulinShortNight_right != objCurrent.m_strInsulinShortNight_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strInsulinShortNight_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[11] = objclsDSTRichTextBoxValue;

                    //血糖定量 mmol/L   （空腹）
                    strText = objCurrent.m_strBloodSugarLimosis_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBloodSugarLimosis_right != objCurrent.m_strBloodSugarLimosis_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBloodSugarLimosis_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;

                    //血糖定量 mmol/L   （早饭  前）
                    strText = objCurrent.m_strBloodSugarBe_BF_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBloodSugarBe_BF_right != objCurrent.m_strBloodSugarBe_BF_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBloodSugarBe_BF_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[13] = objclsDSTRichTextBoxValue;

                    //血糖定量 mmol/L   （早饭  后）
                    strText = objCurrent.m_strBloodSugarAf_BF_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBloodSugarAf_BF_right != objCurrent.m_strBloodSugarAf_BF_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBloodSugarAf_BF_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[14] = objclsDSTRichTextBoxValue;

                    //血糖定量 mmol/L   （午饭  前）
                    strText = objCurrent.m_strBloodSugarBe_Lun_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBloodSugarBe_Lun_right != objCurrent.m_strBloodSugarBe_Lun_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBloodSugarBe_Lun_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[15] = objclsDSTRichTextBoxValue;

                    //血糖定量 mmol/L   （午饭  后）
                    strText = objCurrent.m_strBloodSugarAf_Lun_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBloodSugarAf_Lun_right != objCurrent.m_strBloodSugarAf_Lun_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBloodSugarAf_Lun_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[16] = objclsDSTRichTextBoxValue;

                    //血糖定量 mmol/L   （晚饭  前）
                    strText = objCurrent.m_strBloodSugarBe_Sup_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBloodSugarBe_Sup_right != objCurrent.m_strBloodSugarBe_Sup_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBloodSugarBe_Sup_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[17] = objclsDSTRichTextBoxValue;

                    //血糖定量 mmol/L   （晚饭  后）
                    strText = objCurrent.m_strBloodSugarAf_Sup_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBloodSugarAf_Sup_right != objCurrent.m_strBloodSugarAf_Sup_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBloodSugarAf_Sup_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[18] = objclsDSTRichTextBoxValue;

                    //尿酮
                    strText = objCurrent.m_strUreaketone_right.ToString();
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strUreaketone_right != objCurrent.m_strUreaketone_right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strUreaketone_right.ToString(), objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[19] = objclsDSTRichTextBoxValue;
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
                        objData[20] = objclsDSTRichTextBoxValue;
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
                            objData[20] = objclsDSTRichTextBoxValue;
                        }
                        objDomain = null;
                    }
                    #endregion
                    objReturnData.Add(objData);
                }
                object[][] m_objRe = new object[objReturnData.Count][];

                for (int m = 0; m < objReturnData.Count; m++)
                {
                    m_objRe[m] = (object[])objReturnData[m];
                }
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