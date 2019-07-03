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
    /// 内分泌科血糖观察表
    /// </summary>
    public partial class frmEMR_IntBloodSugarWatch : frmRecordsBase            
    {
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
        //private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcTime_chr;
        //private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcResult_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcAbdomen_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcAfterBreakfast_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBeforeLunch_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcTwoafterLunch_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBeforeDinner_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcTwoDinner_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBeforeSleep_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBeizhu_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSign_chr;

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
        public frmEMR_IntBloodSugarWatch()
        {
            
            InitializeComponent();
        } 
        #endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMR_IntBloodSugarWatch));
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcAbdomen_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcAfterBreakfast_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBeforeLunch_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTwoafterLunch_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBeforeDinner_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTwoDinner_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBeforeSleep_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBeizhu_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSign_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_dtcRecordDate_chr,
																										 this.m_dtcAbdomen_chr,
                                                                                                         this.m_dtcAfterBreakfast_chr,
																										  this.m_dtcBeforeLunch_chr,
                                                                                                         this.m_dtcTwoafterLunch_chr,
                                                                                                           this.m_dtcBeforeDinner_chr,
                                                                                                         this.m_dtcTwoDinner_chr,
                                                                                                            this.m_dtcBeforeSleep_chr,
                                                                                                         this.m_dtcBeizhu_chr,
																										 this.m_dtcSign_chr});
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.Color.Gray;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecordDetail.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(8, 72);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(793, 525);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(543, 97);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(718, 82);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(682, 82);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(626, 93);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(637, 95);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(670, 92);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(652, 75);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(757, 103);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(757, 102);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(655, 37);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(674, 58);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(685, 66);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(596, 79);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(607, 79);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(552, 58);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(625, 44);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(607, 79);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(637, 84);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(646, 58);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(291, 89);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(321, 85);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(796, 110);
            this.m_lblForTitle.Visible = false;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(661, 87);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(791, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(789, 29);
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_Day";
            this.m_dtcSign_chr.Width =110;
            // 
            // m_dtcAbdomen_chr
            // 
            this.m_dtcAbdomen_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcAbdomen_chr.m_BlnGobleSet = true;
            this.m_dtcAbdomen_chr.m_BlnUnderLineDST = false;
            this.m_dtcAbdomen_chr.MappingName = "Abdomen_chr";
            this.m_dtcAbdomen_chr.Width = 75;
            // 
            // m_dtcAfterBreakfast_chr
            // 
            this.m_dtcAfterBreakfast_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcAfterBreakfast_chr.m_BlnGobleSet = true;
            this.m_dtcAfterBreakfast_chr.m_BlnUnderLineDST = false;
            this.m_dtcAfterBreakfast_chr.MappingName = "AfterBreakfast_chr";
            this.m_dtcAfterBreakfast_chr.Width = 75;
            // 
            // m_dtcBeforeLunch_chr
            // 
            this.m_dtcBeforeLunch_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBeforeLunch_chr.m_BlnGobleSet = true;
            this.m_dtcBeforeLunch_chr.m_BlnUnderLineDST = false;
            this.m_dtcBeforeLunch_chr.MappingName = "BeforeLunch_chr";
            this.m_dtcBeforeLunch_chr.Width = 75;
            // 
            // m_dtcTwoafterLunch_chr
            // 
            this.m_dtcTwoafterLunch_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTwoafterLunch_chr.m_BlnGobleSet = true;
            this.m_dtcTwoafterLunch_chr.m_BlnUnderLineDST = false;
            this.m_dtcTwoafterLunch_chr.MappingName = "TwoafterLunch_chr";
            this.m_dtcTwoafterLunch_chr.Width = 75;
            // 
            // m_dtcBeforeDinner_chr
            // 
            this.m_dtcBeforeDinner_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBeforeDinner_chr.m_BlnGobleSet = true;
            this.m_dtcBeforeDinner_chr.m_BlnUnderLineDST = false;
            this.m_dtcBeforeDinner_chr.MappingName = "BeforeDinner_chr";
            this.m_dtcBeforeDinner_chr.Width = 75;
            // 
            // m_dtcTwoDinner_chr
            // 
            this.m_dtcTwoDinner_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTwoDinner_chr.m_BlnGobleSet = true;
            this.m_dtcTwoDinner_chr.m_BlnUnderLineDST = false;
            this.m_dtcTwoDinner_chr.MappingName = "TwoDinner_chr";
            this.m_dtcTwoDinner_chr.Width = 75;
            // 
            // m_dtcBeforeSleep_chr
            // 
            this.m_dtcBeforeSleep_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBeforeSleep_chr.m_BlnGobleSet = true;
            this.m_dtcBeforeSleep_chr.m_BlnUnderLineDST = false;
            this.m_dtcBeforeSleep_chr.MappingName = "BeforeSleep_chr";
            this.m_dtcBeforeSleep_chr.Width =75;
            // 
            // m_dtcBeizhu_chr
            // 
            this.m_dtcBeizhu_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBeizhu_chr.m_BlnGobleSet = true;
            this.m_dtcBeizhu_chr.m_BlnUnderLineDST = false;
            this.m_dtcBeizhu_chr.MappingName = "Beizhu_chr";
            this.m_dtcBeizhu_chr.Width = 75;
            // 
            // m_dtcSign_chr
            // 
            this.m_dtcSign_chr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSign_chr.m_BlnGobleSet = true;
            this.m_dtcSign_chr.m_BlnUnderLineDST = false;
            this.m_dtcSign_chr.MappingName = "Sign_chr";
            this.m_dtcSign_chr.Width = 128;
            // 
            // frmEMR_IntBloodSugarWatch
            // 
            this.ClientSize = new System.Drawing.Size(822, 620);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEMR_IntBloodSugarWatch";
            this.Text = "内分泌科血糖观察表";
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
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
            m_mthAddNewRecord((int)enmDiseaseTrackType.EMR_IntBloodSugarWatch);
        }
        #endregion
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

            //p_dtbRecordTable.Columns.Add("Time_chr", typeof(clsDSTRichTextBoxValue));//5
            //p_dtbRecordTable.Columns.Add("Result_chr", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("Abdomen_chr", typeof(clsDSTRichTextBoxValue));//5
            p_dtbRecordTable.Columns.Add("AfterBreakfast_chr", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("BeforeLunch_chr", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("TwoafterLunch_chr", typeof(clsDSTRichTextBoxValue));//8
            p_dtbRecordTable.Columns.Add("BeforeDinner_chr", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("TwoDinner_chr", typeof(clsDSTRichTextBoxValue));//10
            p_dtbRecordTable.Columns.Add("BeforeSleep_chr", typeof(clsDSTRichTextBoxValue));//11
            p_dtbRecordTable.Columns.Add("Beizhu_chr", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("Sign_chr", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("CreateUserID");//14

            m_mthSetControl(m_dtcRecordDate_chr);
            //m_mthSetControl(m_dtcTime_chr);
            //m_mthSetControl(m_dtcResult_chr);
            m_mthSetControl(m_dtcAbdomen_chr);
            m_mthSetControl(m_dtcAfterBreakfast_chr);
            m_mthSetControl(m_dtcBeforeLunch_chr);
            m_mthSetControl(m_dtcTwoafterLunch_chr);
            m_mthSetControl(m_dtcBeforeDinner_chr);
            m_mthSetControl(m_dtcTwoDinner_chr);
            m_mthSetControl(m_dtcBeforeSleep_chr);
            m_mthSetControl(m_dtcBeizhu_chr);

            m_mthSetControl(m_dtcSign_chr);

            //设置文字栏



            this.m_dtcRecordDate_chr.HeaderText = "\r\r\n\r\n日期";
            //this.m_dtcTime_chr.HeaderText = "\r\n\r\r\n监测时间";
            //this.m_dtcResult_chr.HeaderText = "\r\r\n\r\n监测结果\r\nmmol/L";
            this.m_dtcAbdomen_chr.HeaderText = "\r\n\r\r\n空腹";
            this.m_dtcAfterBreakfast_chr.HeaderText = "\r\r\n\r\n早餐后\r\n2小时";
            this.m_dtcBeforeLunch_chr.HeaderText = "\r\n\r\r\n中餐前";
            this.m_dtcTwoafterLunch_chr.HeaderText = "\r\r\n\r\n中餐后\r\n2小时";
            this.m_dtcBeforeDinner_chr.HeaderText = "\r\n\r\r\n晚餐前";
            this.m_dtcTwoDinner_chr.HeaderText = "\r\r\n\r\n晚餐后\r\n2小时";
            this.m_dtcBeforeSleep_chr.HeaderText = "\r\n\r\r\n睡前";
            this.m_dtcBeizhu_chr.HeaderText = "\r\r\n\r\n备注";
            this.m_dtcSign_chr.HeaderText = "\r\r\n\r\n\r\r监测人签名\r\r\r";
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
            return new clsRecordsDomain(enmRecordsType.EMR_IntBloodSugarWatch);
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
                case enmDiseaseTrackType.EMR_IntBloodSugarWatch:
                    objContent = new clsEMR_intbloodsugarwatchValue();
                    break;
            }

            if (objContent == null)
                objContent = new clsEMR_intbloodsugarwatchValue();

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
            objContent.m_strCreateUserID = (string)p_objDataArr[14];
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
                case enmDiseaseTrackType.EMR_IntBloodSugarWatch:
                    return new frmEMR_IntBloodSugarWatchcon();
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
            //当前处于新增记录状态
            MDIParent.m_mthChangeFormText(frmAddNewForm, MDIParent.enmFormEditStatus.Modify);
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
        ///// <summary>
        ///// 连到打印类
        ///// </summary>
        ///// <returns></returns>
        //protected override long m_lngSubPrint()
        //{
        //    clsIntBloodSugarWatchPrintTool objPrintTool = new clsIntBloodSugarWatchPrintTool();
        //    objPrintTool.m_mthInitPrintTool(null);
        //    if (m_objBaseCurrentPatient == null)
        //        objPrintTool.m_mthSetPrintInfo(null);
        //    else
        //        objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient);

        //    objPrintTool.m_mthInitPrintContent();
        //    objPrintTool.m_mthPrintPage();
        //    return 1;
        //}
        protected override infPrintRecord m_objGetPrintTool()
        {
            return new clsIntBloodSugarWatchPrintTool(m_objCurrentPatient.m_StrRegisterId);
        }
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

                clsEMR_intbloodsugarwatchDataInfo objInfo = null;

                objInfo = p_objTransDataInfo as clsEMR_intbloodsugarwatchDataInfo;

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
                    objData = new object[15];
                    clsEMR_intbloodsugarwatchValue objCurrent = objInfo.m_objRecordArr[i];
                    clsEMR_intbloodsugarwatchValue objNext = new clsEMR_intbloodsugarwatchValue();//下一条记录



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
                        objData[1] = (int)enmRecordsType.EMR_IntBloodSugarWatch;//存放记录类型的int值



                        objData[2] = objCurrent.m_dtmCreateDate;//存放记录的OpenDate字符串



                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   

                        //同一个则只在第一行显示日期



                        if (objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd");//日期字符串

                        }

                        objData[14] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   

                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;
                    #endregion ;

                    #region 存放单项信息
                    ////监测时间
                    //strText = objCurrent.m_strCHECKTIME_RIGHT;
                    //strXml = "<root />";
                    //if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                    //    && objNext.m_strCHECKTIME_RIGHT != objCurrent.m_strCHECKTIME_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strCHECKTIME_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    //}
                    //objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    //objclsDSTRichTextBoxValue.m_strText = strText;
                    //objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    //objData[5] = objclsDSTRichTextBoxValue;
                    ////监测结果
                    //strText = objCurrent.m_strCHECKRESULT_RIGHT;
                    //strXml = "<root />";
                    //if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                    //    && objNext.m_strCHECKRESULT_RIGHT != objCurrent.m_strCHECKRESULT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strCHECKRESULT_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    //}
                    //objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    //objclsDSTRichTextBoxValue.m_strText = strText;
                    //objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    //objData[6] = objclsDSTRichTextBoxValue;
                    //空腹
                    strText = objCurrent.m_strNULLABDOMEN_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strNULLABDOMEN_RIGHT != objCurrent.m_strNULLABDOMEN_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strNULLABDOMEN_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[5] = objclsDSTRichTextBoxValue;
                    //早餐后2小时
                    strText = objCurrent.m_strTWOBREAKFAST_RIGTH;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strTWOBREAKFAST_RIGTH != objCurrent.m_strTWOBREAKFAST_RIGTH)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strTWOBREAKFAST_RIGTH, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;
                    //中餐前
                    strText = objCurrent.m_strBEFORELUNCH_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBEFORELUNCH_RIGHT != objCurrent.m_strBEFORELUNCH_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBEFORELUNCH_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[7] = objclsDSTRichTextBoxValue;
                    //中餐2小时
                    strText = objCurrent.m_strTWOAFTERLUNCH_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strTWOAFTERLUNCH_RIGHT != objCurrent.m_strTWOAFTERLUNCH_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strTWOAFTERLUNCH_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[8] = objclsDSTRichTextBoxValue;
                    //晚餐前
                    strText = objCurrent.m_strBEFOREDINNER_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBEFOREDINNER_RIGHT != objCurrent.m_strBEFOREDINNER_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBEFOREDINNER_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;
                    //晚餐后2小时
                    strText = objCurrent.m_strTWOAFTERDINNER_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strTWOAFTERDINNER_RIGHT != objCurrent.m_strTWOAFTERDINNER_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strTWOAFTERDINNER_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[10] = objclsDSTRichTextBoxValue;
                    //睡前
                    strText = objCurrent.m_strBEFORESLEEP_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBEFORESLEEP_RIGHT != objCurrent.m_strBEFORESLEEP_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBEFORESLEEP_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[11] = objclsDSTRichTextBoxValue;
                    //备注
                    strText = objCurrent.m_strBEIZHU_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBEIZHU_RIGHT != objCurrent.m_strBEIZHU_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBEIZHU_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;

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
                        objData[13] = objclsDSTRichTextBoxValue;
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
                            objData[13] = objclsDSTRichTextBoxValue;
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

       
    }
}
