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
using MainServ = com.digitalwave.clsRecordsService;

namespace iCare
{
    /// <summary>
    /// 催产素静脉点滴观察表
    /// </summary>
    public partial class frmOXTIntravenousDrip : frmRecordsBase
    {
        #region 全局变量
        /// <summary>
        /// 设置初始的比较日期


        /// </summary>
        private DateTime m_dtmPreRecordDate;
        private string m_strCurrentOpenDate = "";
        private string m_strCreateUserID = "";
        /// <summary>
        /// 当前主记录信息


        /// </summary>
        private clsEMR_OXTIntravenousDrip_BASE m_objCurrentBaseVO = null;
        #endregion

        #region 构造函数



        /// <summary>
        /// 催产素静脉点滴观察表
        /// </summary>
        public frmOXTIntravenousDrip()
        {
            InitializeComponent();

            m_mthSetRichTextBoxAttribInControl(this);
        } 
        #endregion

        #region 事件
        private void mniAppend_Click(object sender, EventArgs e)
        {
            if (!m_blnCheckBaseChange())
            {
                return;
            }
            PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF), this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
            m_mthAddNewRecord((int)enmDiseaseTrackType.EMR_OXTIntravenousDrip);
        }

        #region 重写选择住院日期事件，显示主记录
        protected override void m_trvInPatientDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            m_objCurrentBaseVO = null;

            base.m_trvInPatientDate_AfterSelect(sender, e);

            m_mthSetBaseInfoToUI();
        }
        #endregion

        #region 获取BiShop评分
        private void m_chkBiShop00_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop00.Checked)
            {
                m_chkBiShop10.Checked = false;
                m_chkBiShop20.Checked = false;
                m_chkBiShop30.Checked = false;
            }

            m_mthGetBiShop0Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop10_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop10.Checked)
            {
                m_chkBiShop00.Checked = false;
                m_chkBiShop20.Checked = false;
                m_chkBiShop30.Checked = false;
            }

            m_mthGetBiShop0Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop20_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop20.Checked)
            {
                m_chkBiShop00.Checked = false;
                m_chkBiShop10.Checked = false;
                m_chkBiShop30.Checked = false;
            }

            m_mthGetBiShop0Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop30_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop30.Checked)
            {
                m_chkBiShop00.Checked = false;
                m_chkBiShop10.Checked = false;
                m_chkBiShop20.Checked = false;
            }

            m_mthGetBiShop0Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop01_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop01.Checked)
            {
                m_chkBiShop11.Checked = false;
                m_chkBiShop21.Checked = false;
                m_chkBiShop31.Checked = false;
            }

            m_mthGetBiShop1Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop11_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop11.Checked)
            {
                m_chkBiShop01.Checked = false;
                m_chkBiShop21.Checked = false;
                m_chkBiShop31.Checked = false;
            }

            m_mthGetBiShop1Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop21_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop21.Checked)
            {
                m_chkBiShop01.Checked = false;
                m_chkBiShop11.Checked = false;
                m_chkBiShop31.Checked = false;
            }

            m_mthGetBiShop1Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop31_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop31.Checked)
            {
                m_chkBiShop01.Checked = false;
                m_chkBiShop21.Checked = false;
                m_chkBiShop11.Checked = false;
            }

            m_mthGetBiShop1Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop02_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop02.Checked)
            {
                m_chkBiShop12.Checked = false;
                m_chkBiShop22.Checked = false;
                m_chkBiShop32.Checked = false;
            }

            m_mthGetBiShop2Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop12_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop12.Checked)
            {
                m_chkBiShop02.Checked = false;
                m_chkBiShop22.Checked = false;
                m_chkBiShop32.Checked = false;
            }

            m_mthGetBiShop2Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop22_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop22.Checked)
            {
                m_chkBiShop02.Checked = false;
                m_chkBiShop12.Checked = false;
                m_chkBiShop32.Checked = false;
            }

            m_mthGetBiShop2Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop32_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop32.Checked)
            {
                m_chkBiShop02.Checked = false;
                m_chkBiShop22.Checked = false;
                m_chkBiShop12.Checked = false;
            }

            m_mthGetBiShop2Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop03_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop03.Checked)
            {
                m_chkBiShop13.Checked = false;
                m_chkBiShop23.Checked = false;
            }

            m_mthGetBiShop3Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop13_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop13.Checked)
            {
                m_chkBiShop03.Checked = false;
                m_chkBiShop23.Checked = false;
            }

            m_mthGetBiShop3Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop23_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop23.Checked)
            {
                m_chkBiShop13.Checked = false;
                m_chkBiShop03.Checked = false;
            }

            m_mthGetBiShop3Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop04_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop04.Checked)
            {
                m_chkBiShop14.Checked = false;
                m_chkBiShop24.Checked = false;
            }

            m_mthGetBiShop4Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop14_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop14.Checked)
            {
                m_chkBiShop04.Checked = false;
                m_chkBiShop24.Checked = false;
            }

            m_mthGetBiShop4Count();
            m_mthGetBiShopCount();
        }

        private void m_chkBiShop24_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBiShop24.Checked)
            {
                m_chkBiShop14.Checked = false;
                m_chkBiShop04.Checked = false;
            }

            m_mthGetBiShop4Count();
            m_mthGetBiShopCount();
        }
        #endregion
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

            p_dtbRecordTable.Columns.Add("OXTDENSITY", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("OXTDROPCOUNT", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("UTERINECONTRACTION", typeof(clsDSTRichTextBoxValue));//8
            p_dtbRecordTable.Columns.Add("FETALHEART", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("METREURYNT", typeof(clsDSTRichTextBoxValue));//10
            p_dtbRecordTable.Columns.Add("PRESENTATION", typeof(clsDSTRichTextBoxValue));//11	
            p_dtbRecordTable.Columns.Add("BP", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("SPECIALINFO", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("Sign", typeof(clsDSTRichTextBoxValue));//14
            p_dtbRecordTable.Columns.Add("CreateUserID");//15

            m_mthSetControl(m_dtcRecordDate_chr);
            m_mthSetControl(m_dtcTime_chr);
            m_mthSetControl(m_dtcOXTDENSITY);
            m_mthSetControl(m_dtcOXTDROPCOUNT);
            m_mthSetControl(m_dtcUTERINECONTRACTION);
            m_mthSetControl(m_dtcFETALHEART);
            m_mthSetControl(m_dtcMETREURYNT);
            m_mthSetControl(m_dtcPRESENTATION);
            m_mthSetControl(m_dtcBP);
            m_mthSetControl(m_dtcSPECIALINFO);
            m_mthSetControl(m_dtcSign);

            //设置文字栏



            this.m_dtcRecordDate_chr.HeaderText = "日\r\n\r\n\r\n期";
            this.m_dtcTime_chr.HeaderText = "时\r\n\r\n\r\n间";
            this.m_dtcOXTDENSITY.HeaderText = "催产素\r\n浓度\r\n(U/500ml)";
            this.m_dtcOXTDROPCOUNT.HeaderText = "滴数\r\n(滴/分)";
            this.m_dtcUTERINECONTRACTION.HeaderText = "宫\r\n\r\n\r\n缩";
            this.m_dtcFETALHEART.HeaderText = "胎\r\n\r\n\r\n心";
            this.m_dtcMETREURYNT.HeaderText = "宫口\r\n\r\n扩张";
            this.m_dtcPRESENTATION.HeaderText = "先露\r\n\r\n高低";
            this.m_dtcBP.HeaderText = "血\r\n\r\n\r\n压";
            this.m_dtcSPECIALINFO.HeaderText = "特殊\r\n情况\r\n及\r\n处理";
            this.m_dtcSign.HeaderText = "签\r\n\r\n\r\n名";
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
        // 清空特殊记录信息，并重置记录控制状态为不控制。



        protected override void m_mthClearRecordInfo()
        {
            m_dtmPreRecordDate = DateTime.MinValue;
            m_dtgRecordDetail.CurrentRowIndex = 0;
            m_dtbRecords.Rows.Clear();

            m_mthClearMainInfo();
        }
        #endregion

        #region 清空界面主记录



        /// <summary>
        /// 清空界面主记录

        /// </summary>
        private void m_mthClearMainInfo()
        {
            m_txtGravidity.m_mthClearText();
            m_txtGestationalPeriod.m_mthClearText();

            m_chkBiShop00.Checked = false;
            m_chkBiShop01.Checked = false;
            m_chkBiShop02.Checked = false;
            m_chkBiShop03.Checked = false;
            m_chkBiShop04.Checked = false;
            m_chkBiShop10.Checked = false;
            m_chkBiShop11.Checked = false;
            m_chkBiShop12.Checked = false;
            m_chkBiShop13.Checked = false;
            m_chkBiShop14.Checked = false;
            m_chkBiShop20.Checked = false;
            m_chkBiShop21.Checked = false;
            m_chkBiShop22.Checked = false;
            m_chkBiShop23.Checked = false;
            m_chkBiShop24.Checked = false;
            m_chkBiShop30.Checked = false;
            m_chkBiShop31.Checked = false;
            m_chkBiShop32.Checked = false;

            m_txtOXTIntravenousDripInfo.m_mthClearText();
            m_txtOXTIndication.m_mthClearText();
            m_txtOXTAll.m_mthClearText();

            m_lblBiShop0.Tag = null;
            m_lblBiShop1.Tag = null;
            m_lblBiShop2.Tag = null;
            m_lblBiShop3.Tag = null;
            m_lblBiShop4.Tag = null;

            m_txtBiShopCount.m_mthClearText();
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
            return new clsRecordsDomain(enmRecordsType.EMR_OXTIntravenousDrip);
        }
        #endregion

        #region 获取记录的主要信息



        /// <summary>
        /// 获取记录的主要信息（必须获取的是CreateDate,LastModifyDate
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
                case enmDiseaseTrackType.EMR_OXTIntravenousDrip:
                    objContent = new clsEMR_OXTIntravenousDripCon();
                    break;
            }

            if (objContent == null)
                objContent = new clsEMR_OXTIntravenousDripCon();

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
            objContent.m_strCreateUserID = (string)p_objDataArr[15];
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
                case enmDiseaseTrackType.EMR_OXTIntravenousDrip:
                    return new frmOXTIntravenousDripCon();
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
            if (!m_blnCheckBaseChange())
            {
                return;
            }
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

                clsEMR_OXTIntravenousDripDataInfo objInfo = p_objTransDataInfo as clsEMR_OXTIntravenousDripDataInfo;

                if (objInfo != null && objInfo.m_objBaseInfo != null)
                {
                    m_objCurrentBaseVO = objInfo.m_objBaseInfo;
                }

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
                    objData = new object[16];
                    clsEMR_OXTIntravenousDripCon objCurrent = objInfo.m_objRecordArr[i];
                    clsEMR_OXTIntravenousDripCon objNext = new clsEMR_OXTIntravenousDripCon();//下一条记录



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
                        objData[1] = (int)enmRecordsType.EMR_OXTIntravenousDrip;//存放记录类型的int值



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




                        objData[15] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   

                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;
                    #endregion ;

                    #region 存放单项信息
                    //催产素浓度



                    strText = objCurrent.m_strOXTDENSITY_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strOXTDENSITY_RIGHT != objCurrent.m_strOXTDENSITY_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(strText, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;
                    //滴数
                    strText = objCurrent.m_strOXTDROPCOUNT_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strOXTDROPCOUNT_RIGHT != objCurrent.m_strOXTDROPCOUNT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strOXTDROPCOUNT_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[7] = objclsDSTRichTextBoxValue;
                    //宫缩
                    strText = objCurrent.m_strUTERINECONTRACTION_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strUTERINECONTRACTION_RIGHT != objCurrent.m_strUTERINECONTRACTION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strUTERINECONTRACTION_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[8] = objclsDSTRichTextBoxValue;
                    //胎心
                    strText = objCurrent.m_strFETALHEART_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strFETALHEART_RIGHT != objCurrent.m_strFETALHEART_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strFETALHEART_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;
                    //宫口扩张
                    strText = objCurrent.m_strMETREURYNT_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strMETREURYNT_RIGHT != objCurrent.m_strMETREURYNT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strMETREURYNT_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[10] = objclsDSTRichTextBoxValue;
                    //先露高低
                    strText = objCurrent.m_strPRESENTATION_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strPRESENTATION_RIGHT != objCurrent.m_strPRESENTATION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strPRESENTATION_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[11] = objclsDSTRichTextBoxValue;
                    //血压



                    strText = objCurrent.m_strBP_S_RIGHT + "/" + objCurrent.m_strBP_A_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && (objNext.m_strBP_S_RIGHT + "/" + objNext.m_strBP_A_RIGHT) != (objCurrent.m_strBP_S_RIGHT + "/" + objCurrent.m_strBP_A_RIGHT))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(strText, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;
                    //特殊情况及处理



                    strText = objCurrent.m_strSPECIALINFO_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strSPECIALINFO_RIGHT != objCurrent.m_strSPECIALINFO_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strSPECIALINFO_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[13] = objclsDSTRichTextBoxValue;

                    if (objCurrent.objSignerArr != null)
                    {
                        //签名
                        strText = string.Empty;
                        for (int j = 0; j < objCurrent.objSignerArr.Length; j++)
                        {
                            strText += objCurrent.objSignerArr[j].objEmployee.m_strLASTNAME_VCHR + " ";
                        }
                        strXml = "<root />";
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objData[14] = objclsDSTRichTextBoxValue;
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

        #region 保存主记录至数据库



        /// <summary>
        /// 保存主记录至数据库


        /// </summary>
        protected override void m_mthSave()
        {
            clsEMR_OXTIntravenousDrip_BASE objBaseInfo = new clsEMR_OXTIntravenousDrip_BASE();

            objBaseInfo.m_strLAYCOUNT_CHR = m_txtGravidity.Text;
            objBaseInfo.m_strLAYCOUNT_CHRXML = m_txtGravidity.m_strGetXmlText();

            objBaseInfo.m_strGESTATIONALPERIOD = m_txtGestationalPeriod.Text;
            objBaseInfo.m_strGESTATIONALPERIODXML = m_txtGestationalPeriod.m_strGetXmlText();

            objBaseInfo.m_strBISHOPCOUNT = m_txtBiShopCount.Text;
            objBaseInfo.m_strBISHOPCOUNTXML = m_txtBiShopCount.m_strGetXmlText();

            objBaseInfo.m_strBISHOP0 = m_strNum(m_chkBiShop00.Checked) + m_strNum(m_chkBiShop10.Checked) 
                + m_strNum(m_chkBiShop20.Checked) + m_strNum(m_chkBiShop30.Checked);
            objBaseInfo.m_strBISHOP1 = m_strNum(m_chkBiShop01.Checked) + m_strNum(m_chkBiShop11.Checked)
                + m_strNum(m_chkBiShop21.Checked) + m_strNum(m_chkBiShop31.Checked);
            objBaseInfo.m_strBISHOP2 = m_strNum(m_chkBiShop02.Checked) + m_strNum(m_chkBiShop12.Checked)
                + m_strNum(m_chkBiShop22.Checked) + m_strNum(m_chkBiShop32.Checked);
            objBaseInfo.m_strBISHOP3 = m_strNum(m_chkBiShop03.Checked) + m_strNum(m_chkBiShop13.Checked)
                + m_strNum(m_chkBiShop23.Checked);
            objBaseInfo.m_strBISHOP4 = m_strNum(m_chkBiShop04.Checked) + m_strNum(m_chkBiShop14.Checked)
                + m_strNum(m_chkBiShop24.Checked);

            objBaseInfo.m_strOXTINTRAVENOUSDRIPINFO = m_txtOXTIntravenousDripInfo.Text;
            objBaseInfo.m_strOXTINTRAVENOUSDRIPINFOXML = m_txtOXTIntravenousDripInfo.m_strGetXmlText();

            objBaseInfo.m_strOXTINDICATION = m_txtOXTIndication.Text;
            objBaseInfo.m_strOXTINDICATIONXML = m_txtOXTIndication.m_strGetXmlText();

            objBaseInfo.m_strOXTALL = m_txtOXTAll.Text;
            objBaseInfo.m_strOXTALLXML = m_txtOXTAll.m_strGetXmlText();

            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            objBaseInfo.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
            objBaseInfo.m_dtmModifyDate = Convert.ToDateTime(strNow);
            objBaseInfo.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;

            long lngRes = 0;

            MainServ::clsEMR_OXTIntravenousDripMainService objServ =
                (MainServ::clsEMR_OXTIntravenousDripMainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(MainServ::clsEMR_OXTIntravenousDripMainService));

            if (m_objCurrentBaseVO == null)
            {
                objBaseInfo.m_dtmCreateDate = Convert.ToDateTime(strNow);
                objBaseInfo.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
                lngRes = objServ.m_lngAddNewBase2DB(objBaseInfo);
            }
            else
            {
                lngRes = objServ.m_lngModifyBase2DB(objBaseInfo);
            }

            if (lngRes > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
                m_objCurrentBaseVO = objBaseInfo;
                m_mthSetBaseInfoToUI();
                m_mthAddFormStatusForClosingSave();
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("保存失败！");
            }
        } 
        #endregion

        #region 删除主记录



        /// <summary>
        /// 删除主记录


        /// </summary>
        protected override void m_mthDelete()
        {
            if (m_objCurrentBaseVO == null)
                return;

            if (m_dtbRecords.Rows.Count > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("已记录催产素静脉点滴情况，此记录不允许删除！");
                return;
            }
            MainServ::clsEMR_OXTIntravenousDripMainService objServ =
                (MainServ::clsEMR_OXTIntravenousDripMainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(MainServ::clsEMR_OXTIntravenousDripMainService));


            long lngRes = objServ.m_lngDeleteBase2DB(m_objCurrentBaseVO);

            if (lngRes > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("删除成功！");
                m_mthClearMainInfo();
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("删除失败！");
            }
        } 
        #endregion

        #region 显示主记录至界面
        /// <summary>
        /// 显示主记录至界面
        /// </summary>
        private void m_mthSetBaseInfoToUI()
        {
            if (m_objCurrentBaseVO == null)
            {
                return;
            }

            m_txtGravidity.m_mthSetNewText(m_objCurrentBaseVO.m_strLAYCOUNT_CHR, m_objCurrentBaseVO.m_strLAYCOUNT_CHRXML);
            m_txtGestationalPeriod.m_mthSetNewText(m_objCurrentBaseVO.m_strGESTATIONALPERIOD, m_objCurrentBaseVO.m_strGESTATIONALPERIODXML);
            m_txtBiShopCount.m_mthSetNewText(m_objCurrentBaseVO.m_strBISHOPCOUNT, m_objCurrentBaseVO.m_strBISHOPCOUNTXML);

            #region 设置BiShop评分表选择情况
            if (!string.IsNullOrEmpty(m_objCurrentBaseVO.m_strBISHOP0))
            {
                m_chkBiShop00.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP0[0].ToString());
                m_chkBiShop10.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP0[1].ToString());
                m_chkBiShop20.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP0[2].ToString());
                m_chkBiShop30.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP0[3].ToString());
            }

            if (!string.IsNullOrEmpty(m_objCurrentBaseVO.m_strBISHOP1))
            {
                m_chkBiShop01.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP1[0].ToString());
                m_chkBiShop11.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP1[1].ToString());
                m_chkBiShop21.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP1[2].ToString());
                m_chkBiShop31.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP1[3].ToString());
            }

            if (!string.IsNullOrEmpty(m_objCurrentBaseVO.m_strBISHOP2))
            {
                m_chkBiShop02.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP2[0].ToString());
                m_chkBiShop12.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP2[1].ToString());
                m_chkBiShop22.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP2[2].ToString());
                m_chkBiShop32.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP2[3].ToString());
            }

            if (!string.IsNullOrEmpty(m_objCurrentBaseVO.m_strBISHOP3))
            {
                m_chkBiShop03.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP3[0].ToString());
                m_chkBiShop13.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP3[1].ToString());
                m_chkBiShop23.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP3[2].ToString());
            }
            if (!string.IsNullOrEmpty(m_objCurrentBaseVO.m_strBISHOP4))
            {
                m_chkBiShop04.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP4[0].ToString());
                m_chkBiShop14.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP4[1].ToString());
                m_chkBiShop24.Checked = m_blnCheck(m_objCurrentBaseVO.m_strBISHOP4[2].ToString());
            } 
            #endregion

            m_txtOXTIntravenousDripInfo.m_mthSetNewText(m_objCurrentBaseVO.m_strOXTINTRAVENOUSDRIPINFO,m_objCurrentBaseVO.m_strOXTINTRAVENOUSDRIPINFOXML);
            m_txtOXTIndication.m_mthSetNewText(m_objCurrentBaseVO.m_strOXTINDICATION, m_objCurrentBaseVO.m_strOXTINDICATIONXML);
            m_txtOXTAll.m_mthSetNewText(m_objCurrentBaseVO.m_strOXTALL, m_objCurrentBaseVO.m_strOXTALLXML);
        } 
        #endregion

        #region 将"0","1"转换为相应布尔值

        /// <summary>
        /// 将"0","1"转换为相应布尔值

        /// </summary>
        /// <param name="p_strNum">字符</param>
        /// <returns></returns>
        private bool m_blnCheck(string p_strNum)
        {
            if (p_strNum == "1")
                return true;
            else
                return false;
        } 
        #endregion

        #region 将布尔值转换为相应的字符"0","1"
        /// <summary>
        /// 将布尔值转换为相应的字符"0","1"
        /// </summary>
        /// <param name="p_blnCheck">布尔值</param>
        /// <returns></returns>
        private string m_strNum(bool p_blnCheck)
        {
            if (p_blnCheck)
                return "1";
            else
                return "0";
        } 
        #endregion

        #region 获取BiShop累积评分
        /// <summary>
        /// 获取BiShop累积评分
        /// </summary>
        private void m_mthGetBiShopCount()
        {
            if (m_lblBiShop0.Tag == null && m_lblBiShop1.Tag == null && m_lblBiShop2.Tag == null
                && m_lblBiShop3.Tag == null && m_lblBiShop4.Tag == null)
            {
                m_txtBiShopCount.Text = "";
                return;
            }

            int intCount = 0;
            int intSelected = 0;
            if (m_lblBiShop0.Tag != null && int.TryParse(m_lblBiShop0.Tag.ToString(), out intSelected))
            {
                intCount += intSelected;
            }

            if (m_lblBiShop1.Tag != null && int.TryParse(m_lblBiShop1.Tag.ToString(), out intSelected))
            {
                intCount += intSelected;
            }

            if (m_lblBiShop2.Tag != null && int.TryParse(m_lblBiShop2.Tag.ToString(), out intSelected))
            {
                intCount += intSelected;
            }

            if (m_lblBiShop3.Tag != null && int.TryParse(m_lblBiShop3.Tag.ToString(), out intSelected))
            {
                intCount += intSelected;
            }

            if (m_lblBiShop4.Tag != null && int.TryParse(m_lblBiShop4.Tag.ToString(), out intSelected))
            {
                intCount += intSelected;
            }
            m_txtBiShopCount.Text = intCount.ToString();
        } 
        #endregion

        #region 获取BiShop宫颈扩张评分
        /// <summary>
        /// 获取BiShop宫颈扩张评分
        /// </summary>
        private void m_mthGetBiShop0Count()
        {
            m_lblBiShop0.Tag = null;

            if (m_chkBiShop00.Checked)
            {
                m_lblBiShop0.Tag = 0;
            }
            else if (m_chkBiShop10.Checked)
            {
                m_lblBiShop0.Tag = 1;
            }
            else if (m_chkBiShop20.Checked)
            {
                m_lblBiShop0.Tag = 2;
            }
            else if (m_chkBiShop30.Checked)
            {
                m_lblBiShop0.Tag = 3;
            }
        } 
        #endregion

        #region 获取BiShop宫颈管消失评分

        /// <summary>
        /// 获取BiShop宫颈管消失评分

        /// </summary>
        private void m_mthGetBiShop1Count()
        {
            m_lblBiShop1.Tag = null;

            if (m_chkBiShop01.Checked)
            {
                m_lblBiShop1.Tag = 0;
            }
            else if (m_chkBiShop11.Checked)
            {
                m_lblBiShop1.Tag = 1;
            }
            else if (m_chkBiShop21.Checked)
            {
                m_lblBiShop1.Tag = 2;
            }
            else if (m_chkBiShop31.Checked)
            {
                m_lblBiShop1.Tag = 3;
            }
        } 
        #endregion

        #region 获取BiShop先露高低评分
        /// <summary>
        /// 获取BiShop先露高低评分
        /// </summary>
        private void m_mthGetBiShop2Count()
        {
            m_lblBiShop2.Tag = null;

            if (m_chkBiShop02.Checked)
            {
                m_lblBiShop2.Tag = 0;
            }
            else if (m_chkBiShop12.Checked)
            {
                m_lblBiShop2.Tag = 1;
            }
            else if (m_chkBiShop22.Checked)
            {
                m_lblBiShop2.Tag = 2;
            }
            else if (m_chkBiShop32.Checked)
            {
                m_lblBiShop2.Tag = 3;
            }
        } 
        #endregion

        #region 获取BiShop宫颈软硬度评分



        /// <summary>
        /// 获取BiShop宫颈软硬度评分

        /// </summary>
        private void m_mthGetBiShop3Count()
        {
            m_lblBiShop3.Tag = null;

            if (m_chkBiShop03.Checked)
            {
                m_lblBiShop3.Tag = 0;
            }
            else if (m_chkBiShop13.Checked)
            {
                m_lblBiShop3.Tag = 1;
            }
            else if (m_chkBiShop23.Checked)
            {
                m_lblBiShop3.Tag = 2;
            }
        } 
        #endregion


        #region 获取BiShop宫颈口位置评分



        /// <summary>
        /// 获取BiShop宫颈口位置评分

        /// </summary>
        private void m_mthGetBiShop4Count()
        {
            m_lblBiShop4.Tag = null;

            if (m_chkBiShop04.Checked)
            {
                m_lblBiShop4.Tag = 0;
            }
            else if (m_chkBiShop14.Checked)
            {
                m_lblBiShop4.Tag = 1;
            }
            else if (m_chkBiShop24.Checked)
            {
                m_lblBiShop4.Tag = 2;
            }
        } 
        #endregion

        #region 记录设置窗体当前状态

        /// <summary>
        /// 记录设置窗体当前状态，以在窗体关闭时有保存提示
        /// </summary>
        protected override void m_mthAddFormStatusForClosingSave()
        {
            //记录设置窗体当前状态


            MDIParent.s_ObjSaveCue.m_mthAddFormStatus(this);
        } 
        #endregion

        #region 打开子窗体前检查基本信息是否作了改动

        /// <summary>
        /// 打开子窗体前检查基本信息是否作了改动

        /// </summary>
        private bool m_blnCheckBaseChange()
        {
            if (!MDIParent.s_ObjSaveCue.m_blnCheckStatusSame(this))
            {
                DialogResult dlgResult = clsPublicFunction.ShowQuestionMessageBox("BiShop评分或其它基本信息作了改动，是否保存？", MessageBoxButtons.YesNoCancel);
                if (dlgResult == DialogResult.Yes)
                {
                    this.m_mthSave();
                    return true;
                }
                else if (dlgResult == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        } 
        #endregion

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null)
            {
                return;
            }
            m_objCurrentBaseVO = null;

            base.m_mthPerformSessionChanged(p_objSelectedSession, p_intIndex);

            m_mthSetBaseInfoToUI();
        }
        #endregion       

        #region 打印

        protected override infPrintRecord m_objGetPrintTool()
        {
            clsEMR_OXTIntravenousDripPrintTool m_objPt = new clsEMR_OXTIntravenousDripPrintTool();
            return m_objPt;
        }
        #endregion
    }
}