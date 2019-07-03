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
    /// 出入量登记表
    /// </summary>
    public partial class frmIntakeAndOutputVolume : frmRecordsBase
    {
        #region 全局变量
        /// <summary>
        /// 设置初始的比较日期
        /// </summary>
        private DateTime m_dtmPreRecordDate;
        private string m_strPreRecordTime_vchr = string.Empty;
        private string m_strCurrentOpenDate = "";
        private string m_strCreateUserID = "";
        /// <summary>
        /// 是否新添子窗体
        /// </summary>
        private bool m_blnIsAddNew = true;
        /// <summary>
        /// 出量>>其他标头文字
        /// </summary>
        private string m_strCustomColumn1 = "";
        /// <summary>
        /// 入量>>其他标头文字
        /// </summary>
        private string m_strCustomColumn2 = "";
        private string m_strTempColumnName = "";
        #endregion

        #region 构造函数
        /// <summary>
        /// 出入量登记表
        /// </summary>
        public frmIntakeAndOutputVolume()
        {
            InitializeComponent();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_dtcRecordDate_chr,
																										 this.m_dtcRecordTime_vchr,
																										 this.m_dtcStool_vchr,
																										 this.m_dtcUrine_vchr,
																										 this.m_dtcGastricJuice_vchr,
																										 this.m_dtcBile_vchr,
																										 this.m_dtcIntestinalJuice_vchr,
																										 this.m_dtcChestFluid_vchr,
																										 this.m_dtcOtherOutput_vchr,
																										 this.m_dtcDrinkingWater_vchr,
																										 this.m_dtcFood_vchr,
																										 this.m_dtcTransfusion_vchr,
																										 this.m_dtcSugarWater_vchr,
																										 this.m_dtcSalineWater_vchr,
                                                                                                         this.m_dtcOtherIntake_vchr,
                                                                                                         this.m_dtcSign_chr});
            this.dgtsStyles.RowHeaderWidth = 15;
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
            m_blnIsAddNew = true;
            m_mthAddNewRecord((int)enmDiseaseTrackType.EMR_IntakeAndOutputVolume);
        }
        
        private void m_dtgRecordDetail_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_objCurrentPatient == null)
                return;
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                System.Windows.Forms.DataGrid.HitTestInfo myHitTest = m_dtgRecordDetail.HitTest(e.X, e.Y);
                if (myHitTest.Column == 8 || myHitTest.Column == 14)
                {
                    m_strTempColumnName = "";
                    m_mthSetCustomColumn(myHitTest.Column);
                }
            }
        }

        private void frmIntakeAndOutputVolume_Load(object sender, EventArgs e)
        {
            #region 添加右键菜单
            System.Windows.Forms.MenuItem mniContentAdd = new System.Windows.Forms.MenuItem();
            mniContentAdd.Index = 10;
            mniContentAdd.Text = "添加总结";
            mniContentAdd.Click += new System.EventHandler(mniContentAdd_Click);
            System.Windows.Forms.MenuItem mniContentModify = new System.Windows.Forms.MenuItem();
            mniContentModify.Index = 11;
            mniContentModify.Text = "修改总结";
            mniContentModify.Click += new System.EventHandler(mniContentModify_Click);
            System.Windows.Forms.MenuItem mniContentDelete = new System.Windows.Forms.MenuItem();
            mniContentDelete.Index = 12;
            mniContentDelete.Text = "删除总结";
            mniContentDelete.Click += new System.EventHandler(mniContentDelete_Click);
            this.ctmRecordControl.MenuItems.Add(mniContentAdd);
            this.ctmRecordControl.MenuItems.Add(mniContentModify);
            this.ctmRecordControl.MenuItems.Add(mniContentDelete);

            #endregion ;
            m_dtmPreRecordDate = DateTime.MinValue;
            m_dtgRecordDetail.Focus();
            m_mniAddBlank.Visible = false;
            m_mniDeleteBlank.Visible = false;
        }

        /// <summary>
        /// 添加总结
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void mniContentAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                //打开窗体	
                if (this.m_FrmCurrentSub != null)
                {
                    this.m_FrmCurrentSub.Activate();
                    this.m_FrmCurrentSub.WindowState = FormWindowState.Normal;
                    return;
                }

                frmIntakeAndOutputVolumeSummary frm = new frmIntakeAndOutputVolumeSummary(true,DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")));
                frm.FormClosed += new FormClosedEventHandler(m_mthSubFormClosed);

                //frm.TopMost = true;
                this.m_FrmCurrentSub = frm;
                frm.Show();

                if (m_objCurrentPatient != null)
                {
                    frm.m_mthSetPatient(m_objCurrentPatient);
                    frm.m_mthCountAndSetToUI(m_objCurrentPatient);
                }
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }

        /// <summary>
        /// 修改总结
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void mniContentModify_Click(object sender, System.EventArgs e)
        {
            try
            {
                //打开窗体	
                if (this.m_FrmCurrentSub != null)
                {
                    this.m_FrmCurrentSub.Activate();
                    this.m_FrmCurrentSub.WindowState = FormWindowState.Normal;
                    return;
                }

                int intSelectedSummaryRow = m_intGetSummaryRow(m_dtgRecordDetail.CurrentCell.RowNumber);

                if (intSelectedSummaryRow < 0)
                {
                    return;
                }

                DateTime dtmCreateTime = Convert.ToDateTime(m_dtbRecords.Rows[intSelectedSummaryRow][2]);
                DateTime dtmRecordDate = Convert.ToDateTime(m_dtbRecords.Rows[intSelectedSummaryRow][21]);

                frmIntakeAndOutputVolumeSummary frm = new frmIntakeAndOutputVolumeSummary(false, dtmRecordDate);
                frm.FormClosed += new FormClosedEventHandler(m_mthSubFormClosed);
                this.m_FrmCurrentSub = frm;

                frm.Show();

                frm.m_mthSetDiseaseTrackInfo(m_objCurrentPatient, dtmCreateTime);
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }

        /// <summary>
        /// 删除总结
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void mniContentDelete_Click(object sender, System.EventArgs e)
        {
            int intSelectedSummaryRow = m_intGetSummaryRow(m_dtgRecordDetail.CurrentCell.RowNumber);

            if (intSelectedSummaryRow < 0)
            {
                return;
            }
            string strDetailSign = (m_dtbRecords.Rows[intSelectedSummaryRow][20]).ToString();

            if (!string.IsNullOrEmpty(strDetailSign))
            {
                string strDeptIDTemp = ((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID;
                bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, strDetailSign, clsEMRLogin.LoginEmployee, intFormType);
                if (!blnIsAllow)
                    return;
            }

            string strRecordTime = (m_dtbRecords.Rows[intSelectedSummaryRow][2]).ToString();
            if (strRecordTime.Trim().Length == 0)
                return;
            //确认
            if (MessageBox.Show("确认要删除选中的总结？", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            clsEMR_IntakeAndOutputVolumeSum objContent = new clsEMR_IntakeAndOutputVolumeSum();

            if (m_objCurrentPatient != null)
                objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            else
            {
                clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
                return;
            }

            objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
            objContent.m_dtmCreateDate = DateTime.Parse(strRecordTime);
            objContent.m_strCreateUserID = strDetailSign;
            objContent.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
            objContent.m_strDeActivedOperatorID = MDIParent.OperatorID;
            objContent.m_dtmDeActivedDate = DateTime.Parse(new clsPublicDomain().m_strGetServerTime());

            com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeSumServ objServ =
                    (com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeSumServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeSumServ));

            long lngRes = objServ.m_lngDeleteSummaryRecord(objContent);

            if (lngRes > 0)
            {
                TreeNode trvTemp = m_trvInPatientDate.SelectedNode;
                m_trvInPatientDate.SelectedNode = null;
                m_trvInPatientDate.SelectedNode = trvTemp;
            }
        }

        private void m_mthSubFormClosed(object p_objSender, EventArgs p_objArg)
        {
            frmIntakeAndOutputVolumeSummary frmAddNewForm = (frmIntakeAndOutputVolumeSummary)p_objSender;
            //显示窗体

            if (frmAddNewForm.DialogResult == DialogResult.Yes)
            {
                TreeNode trvTemp = m_trvInPatientDate.SelectedNode;
                m_trvInPatientDate.SelectedNode = null;
                m_trvInPatientDate.SelectedNode = trvTemp;
            }
            m_FrmCurrentSub = null;
        }

        /// <summary>
        /// 获取总结所在行
        /// </summary>
        /// <param name="p_intSelectRowIndex"></param>
        /// <returns></returns>
        private int m_intGetSummaryRow(int p_intSelectRowIndex)
        {
            //从选择行开始向下循环，当索引[1]为空时即为总结所在行
            for (int i1 = p_intSelectRowIndex; i1 < m_dtbRecords.Rows.Count; i1++)
            {
                if (m_dtbRecords.Rows[i1][1].ToString() == "")
                {
                    return i1;
                }
            }
            return -1;
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

            p_dtbRecordTable.Columns.Add("RecordTime_vchr", typeof(clsDSTRichTextBoxValue));//5

            p_dtbRecordTable.Columns.Add("Stool_vchr", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("Urine_vchr", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("GastricJuice_vchr", typeof(clsDSTRichTextBoxValue));//8
            p_dtbRecordTable.Columns.Add("Bile_vchr", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("IntestinalJuice_vchr", typeof(clsDSTRichTextBoxValue));//10	
            p_dtbRecordTable.Columns.Add("ChestFluid_vchr", typeof(clsDSTRichTextBoxValue));//11
            p_dtbRecordTable.Columns.Add("OtherOutput_vchr", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("DrinkingWater_vchr", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("Food_vchr", typeof(clsDSTRichTextBoxValue));//14
            p_dtbRecordTable.Columns.Add("Transfusion_vchr", typeof(clsDSTRichTextBoxValue));//15
            p_dtbRecordTable.Columns.Add("SugarWater_vchr", typeof(clsDSTRichTextBoxValue));//16
            p_dtbRecordTable.Columns.Add("SalineWater_vchr", typeof(clsDSTRichTextBoxValue));//17
            p_dtbRecordTable.Columns.Add("OtherIntake_vchr", typeof(clsDSTRichTextBoxValue));//18
            DataColumn dcSign = p_dtbRecordTable.Columns.Add("Sign_chr");//19
            dcSign.DefaultValue = "";
            p_dtbRecordTable.Columns.Add("CreateUserID");//20
            p_dtbRecordTable.Columns.Add("RecordTimeForSearch");//21

            m_mthSetControl(m_dtcRecordDate_chr);
            m_mthSetControl(m_dtcRecordTime_vchr);
            m_mthSetControl(m_dtcStool_vchr);
            m_mthSetControl(m_dtcUrine_vchr);
            m_mthSetControl(m_dtcGastricJuice_vchr);
            m_mthSetControl(m_dtcBile_vchr);
            m_mthSetControl(m_dtcIntestinalJuice_vchr);
            m_mthSetControl(m_dtcChestFluid_vchr);
            m_mthSetControl(m_dtcOtherOutput_vchr);
            m_mthSetControl(m_dtcDrinkingWater_vchr);
            m_mthSetControl(m_dtcFood_vchr);
            m_mthSetControl(m_dtcTransfusion_vchr);
            m_mthSetControl(m_dtcSugarWater_vchr);
            m_mthSetControl(m_dtcSalineWater_vchr);
            m_mthSetControl(m_dtcOtherIntake_vchr);
            m_mthSetControl(m_dtcSign_chr);

            //设置文字栏
            this.m_dtcRecordDate_chr.HeaderText = "日\r\n\r\n\r\n\r\n\r\n\r\n期";
            this.m_dtcRecordTime_vchr.HeaderText = "时\r\n\r\n\r\n\r\n\r\n\r\n间";
            this.m_dtcStool_vchr.HeaderText = "出\r\n\r\n量\r\n\r\n大\r\n\r\n便";
            this.m_dtcUrine_vchr.HeaderText = "出\r\n\r\n量\r\n\r\n小\r\n\r\n便";
            this.m_dtcGastricJuice_vchr.HeaderText = "出\r\n\r\n量\r\n\r\n胃\r\n\r\n液";
            this.m_dtcBile_vchr.HeaderText = "出\r\n\r\n量\r\n\r\n胆\r\n\r\n汁";
            this.m_dtcIntestinalJuice_vchr.HeaderText = "出\r\n\r\n量\r\n\r\n肠\r\n\r\n液";
            this.m_dtcChestFluid_vchr.HeaderText = "出\r\n\r\n量\r\n\r\n胸\r\n\r\n液";
            this.m_dtcOtherOutput_vchr.HeaderText = "出\r\n\r\n量\r\n\r\n其\r\n\r\n他";
            this.m_dtcDrinkingWater_vchr.HeaderText = "入\r\n\r\n量\r\n\r\n饮\r\n\r\n水";
            this.m_dtcFood_vchr.HeaderText = "入\r\n\r\n量\r\n\r\n食\r\n\r\n物";
            this.m_dtcTransfusion_vchr.HeaderText = "入\r\n\r\n量\r\n\r\n输\r\n\r\n血";
            this.m_dtcSugarWater_vchr.HeaderText = "入\r\n\r\n量\r\n\r\n糖\r\n\r\n水";
            this.m_dtcSalineWater_vchr.HeaderText = "入\r\n\r\n量\r\n\r\n盐\r\n\r\n水";
            this.m_dtcOtherIntake_vchr.HeaderText = "入\r\n\r\n量\r\n\r\n其\r\n\r\n他";
            this.m_dtcSign_chr.HeaderText = "签\r\n\r\n\r\n\r\n\r\n\r\n名";
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

        #region 获取完全正确的文本
		/// <summary>
        /// 获取完全正确的文本
        /// </summary>
        /// <param name="p_strText"></param>
        /// <param name="p_stXML"></param>
        /// <returns></returns>
        private string m_strGetRightText(string p_strText,string p_stXML)
        {
            return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strGetRightText(p_strText, p_stXML);
        } 
	    #endregion

        #region 获取病程记录的领域层实例
        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsRecordsDomain m_objGetRecordsDomain()
        {
            return new clsRecordsDomain(enmRecordsType.EMR_IntakeAndOutputVolume);
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
                    objContent = new clsEMR_IntakeAndOutputVolumeValue();
                    break;
            }

            if (objContent == null)
                objContent = new clsEMR_IntakeAndOutputVolumeValue();

            if (m_objCurrentPatient != null)
                objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            else
            {
                clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
                return null;
            }
            int intSelectedRecordStartRow = m_dtgRecordDetail.CurrentCell.RowNumber;

            objContent.m_dtmInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate;
            objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[2]);
            objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);
            objContent.m_strCreateUserID = (string)p_objDataArr[20];
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
                case enmDiseaseTrackType.EMR_IntakeAndOutputVolume:
                    frmIntakeAndOutputVolumeCon frmCon = new frmIntakeAndOutputVolumeCon();
                    frmCon.m_strOtherIntake_Name = m_strCustomColumn2;
                    frmCon.m_strOtherOutput_Name = m_strCustomColumn1;
                    return frmCon;
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
            m_mthSetPatientFormInfo(m_objCurrentPatient);
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
            m_blnIsAddNew = false;
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
                Hashtable hstSummary = new Hashtable();

                clsEMR_IntakeAndOutputVolumeDataInfo objInfo = null;

                objInfo = p_objTransDataInfo as clsEMR_IntakeAndOutputVolumeDataInfo;

                if (objInfo == null || objInfo.m_objRecordArr == null)
                    return null;

                if (objInfo.m_objRecordArr.Length > 0)
                {
                    clsEMR_IntakeAndOutputVolumeValue objVO = objInfo.m_objRecordArr[0];
                    if (objVO != null)
                    {
                        m_strCustomColumn1 = "出量其他";
                        m_strCustomColumn2 = "入量其他";
                        if (!string.IsNullOrEmpty(objVO.m_strOTHERINTAKE_NAME))
                        {
                            m_strCustomColumn2 = objVO.m_strOTHERINTAKE_NAME;
                        }
                        if (!string.IsNullOrEmpty(objVO.m_strOTHEROUTPUT_NAME))
                        {
                            m_strCustomColumn1 = objVO.m_strOTHEROUTPUT_NAME;
                        }
                        m_mthSetCustomColumnName();
                    }
                }
                if (objInfo.m_objSummaryInfo != null)
	            {
            		 for (int j1 = 0; j1 < objInfo.m_objSummaryInfo.Length; j1++)
			        {
        			    hstSummary.Add(objInfo.m_objSummaryInfo[j1].m_dtmRecordDate,objInfo.m_objSummaryInfo[j1]);
			        }
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
                    clsEMR_IntakeAndOutputVolumeValue objCurrent = objInfo.m_objRecordArr[i];
                    clsEMR_IntakeAndOutputVolumeValue objNext = null;//下一条记录
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
                        objData[1] = (int)enmRecordsType.EMR_IntakeAndOutputVolume;//存放记录类型的int值
                        objData[2] = objCurrent.m_dtmCreateDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   

                        //同一个则只在第一行显示日期
                        if (objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd");//日期字符串
                        }

                        objData[20] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   

                    }
                    #endregion ;

                    #region 存放单项信息
                    if (objCurrent.m_strRECORDTIME_VCHR != m_strPreRecordTime_vchr
                        || (objCurrent.m_strRECORDTIME_VCHR == m_strPreRecordTime_vchr && objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString()))
	                {
                        //时间
                        strText = objCurrent.m_strRECORDTIME_VCHR;
                        strXml = "<root />";
                        if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                            && objNext.m_strRECORDTIME_VCHR != objCurrent.m_strRECORDTIME_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                        {
                            strXml = m_strGetDSTTextXML(objCurrent.m_strRECORDTIME_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                        }
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objData[5] = objclsDSTRichTextBoxValue;                		 
	                }
                    else
                    {
                        objData[5] = null;
                    }
                    m_strPreRecordTime_vchr = objCurrent.m_strRECORDTIME_VCHR;
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;

                    //大便
                    strText = objCurrent.m_strSTOOL_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strSTOOL_RIGHT != objCurrent.m_strSTOOL_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strSTOOL_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;

                    //小便
                    strText = objCurrent.m_strURINE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strURINE_RIGHT != objCurrent.m_strURINE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strURINE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[7] = objclsDSTRichTextBoxValue;
                    //胃液
                    strText = objCurrent.m_strGASTRICJUICE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strGASTRICJUICE_RIGHT != objCurrent.m_strGASTRICJUICE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strGASTRICJUICE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[8] = objclsDSTRichTextBoxValue;
                    //胆汁
                    strText = objCurrent.m_strBILE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strBILE_RIGHT != objCurrent.m_strBILE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBILE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;
                    //肠液
                    strText = objCurrent.m_strINTESTINALJUICE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strINTESTINALJUICE_RIGHT != objCurrent.m_strINTESTINALJUICE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strINTESTINALJUICE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[10] = objclsDSTRichTextBoxValue;
                    //胸液
                    strText = objCurrent.m_strCHESTFLUID_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strCHESTFLUID_RIGHT != objCurrent.m_strCHESTFLUID_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strCHESTFLUID_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[11] = objclsDSTRichTextBoxValue;
                    //其他出量
                    strText = objCurrent.m_strOTHEROUTPUT_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strOTHEROUTPUT_RIGHT != objCurrent.m_strOTHEROUTPUT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strOTHEROUTPUT_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;
                    //饮水
                    strText = objCurrent.m_strDRINKINGWATER_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strDRINKINGWATER_RIGHT != objCurrent.m_strDRINKINGWATER_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strDRINKINGWATER_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[13] = objclsDSTRichTextBoxValue;
                    //食物
                    strText = objCurrent.m_strFOOD_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strFOOD_RIGHT != objCurrent.m_strFOOD_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strFOOD_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[14] = objclsDSTRichTextBoxValue;
                    //输血
                    strText = objCurrent.m_strTRANSFUSION_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strTRANSFUSION_RIGHT != objCurrent.m_strTRANSFUSION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strTRANSFUSION_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[15] = objclsDSTRichTextBoxValue;
                    //糖水
                    strText = objCurrent.m_strSUGARWATER_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strSUGARWATER_RIGHT != objCurrent.m_strSUGARWATER_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strSUGARWATER_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[16] = objclsDSTRichTextBoxValue;
                    //盐水
                    strText = objCurrent.m_strSALINEWATER_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strSALINEWATER_RIGHT != objCurrent.m_strSALINEWATER_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strSALINEWATER_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[17] = objclsDSTRichTextBoxValue;
                    //其他
                    strText = objCurrent.m_strOTHERINTAKE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strOTHERINTAKE_RIGHT != objCurrent.m_strOTHERINTAKE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strOTHERINTAKE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[18] = objclsDSTRichTextBoxValue;

                    if (objCurrent.objSignerArr != null)
                    {
                        //签名
                        strText = string.Empty;
                        for (int j = 0; j < objCurrent.objSignerArr.Length; j++)
                        {
                            strText += objCurrent.objSignerArr[j].objEmployee.m_strLASTNAME_VCHR + " ";
                        }
                        objData[19] = strText;
                    }
                    objData[21] = objCurrent.m_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss") + "&" + objCurrent.m_strRECORDTIME_VCHR;
                    #endregion
                    objReturnData.Add(objData);

                    #region 总结
		            if (objNext == null 
                        || (objNext != null && objCurrent.m_dtmRecordDate != objNext.m_dtmRecordDate))
	                {
    		             if (hstSummary[objCurrent.m_dtmRecordDate] != null)
                        {
                             clsEMR_IntakeAndOutputVolumeSum objSum = hstSummary[objCurrent.m_dtmRecordDate] as clsEMR_IntakeAndOutputVolumeSum;
                    		 object[] objSumData = new object[22];
                             objSumData[2] = objSum.m_dtmCreateDate;
                             strText = "总    结";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[5] = objclsDSTRichTextBoxValue;   
                             strText = "其中";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[8] = objclsDSTRichTextBoxValue;    
                             strText = "尿总量";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[9] = objclsDSTRichTextBoxValue; 
    
                             strText = m_strGetRightText(objSum.m_strALLURINE,objSum.m_strALLURINEXML);
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[10] = objclsDSTRichTextBoxValue;    
                             strText = "毫升";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[11] = objclsDSTRichTextBoxValue;

                             objSumData[20] = objCurrent.m_strCreateUserID;
                             objSumData[21] = objCurrent.m_dtmRecordDate.ToString("yyyy-MM-dd 00:00:00");
                             objReturnData.Add(objSumData);

                             objSumData = new object[22];
                             objSumData[2] = objSum.m_dtmCreateDate;
                             strText = "总出量";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[6] = objclsDSTRichTextBoxValue;
 
                             strText = m_strGetRightText(objSum.m_strALLOUTPUT,objSum.m_strALLOUTPUTXML);
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[7] = objclsDSTRichTextBoxValue;    
                             strText = "毫升";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[8] = objclsDSTRichTextBoxValue;
                             strText = "比重";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[10] = objclsDSTRichTextBoxValue; 

                             strText = m_strGetRightText(objSum.m_strSPECIFICGRAVITY,objSum.m_strSPECIFICGRAVITYXML);
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[11] = objclsDSTRichTextBoxValue; 
                             strText = "总入量";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[13] = objclsDSTRichTextBoxValue; 

                             strText = m_strGetRightText(objSum.m_strALLINTAKE,objSum.m_strALLINTAKEXML);
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[14] = objclsDSTRichTextBoxValue;
                             strText = "毫升。";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[15] = objclsDSTRichTextBoxValue; 

                             strText = "签名:";
                             strXml = "<root />";
                             objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                             objclsDSTRichTextBoxValue.m_strText = strText;
                             objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                             objSumData[18] = objclsDSTRichTextBoxValue;

                             if (objSum.objSignerArr != null && objSum.objSignerArr.Length > 0)
                            {
                                //签名
                                strText = string.Empty;
                                for (int j = 0; j < objCurrent.objSignerArr.Length; j++)
                                {
                                    strText += objCurrent.objSignerArr[j].objEmployee.m_strLASTNAME_VCHR + " ";
                                }
                                objSumData[19] = strText;
                            }
                            objSumData[20] = objCurrent.m_strCreateUserID;
                            objSumData[21] = objCurrent.m_dtmRecordDate.ToString("yyyy-MM-dd 00:00:00");
                            objReturnData.Add(objSumData);
                        }
	                } 
	                #endregion
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

        #region 设置自定义列标头
        /// <summary>
        /// 设置自定义列标头
        /// </summary>
        /// <param name="p_intColumn"></param>
        private void m_mthSetCustomColumn(int p_intColumn)
        {
            string strHeaderText = m_dtgRecordDetail.TableStyles[0].GridColumnStyles[p_intColumn].HeaderText.Replace("\r\n", "");
            frmSetCustomDataGridColumn frm = new frmSetCustomDataGridColumn(strHeaderText);
            m_strTempColumnName = "";
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                m_strTempColumnName = frm.m_StrSetName;
            }
            else
                return;
            switch (p_intColumn)
            {
                case 8:
                    m_strCustomColumn1 = m_strTempColumnName;
                    m_mthSaveColumnNameToDB("OTHEROUTPUT_NAME", m_strCustomColumn1);
                    break;
                case 14:
                    m_strCustomColumn2 = m_strTempColumnName;
                    m_mthSaveColumnNameToDB("OTHERINTAKE_NAME", m_strCustomColumn2);
                    break;
            }
            m_mthSetCustomColumnName();
        }

        /// <summary>
        /// 保存至数据库
        /// </summary>
        /// <param name="p_strColumnIndex"></param>
        /// <param name="p_strColumnName"></param>
        private void m_mthSaveColumnNameToDB(string p_strColumnIndex, string p_strColumnName)
        {
            long lngRes = 0;

            com.digitalwave.clsRecordsService.clsEMR_IntakeAndOutputVolumeMainServ objServ =
                (com.digitalwave.clsRecordsService.clsEMR_IntakeAndOutputVolumeMainServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsEMR_IntakeAndOutputVolumeMainServ));

            lngRes = objServ.m_lngSetCustomColumnName(m_objCurrentPatient.m_StrRegisterId, p_strColumnIndex, p_strColumnName);
        }

        /// <summary>
        /// 将标头文字设置到界面
        /// </summary>
        private void m_mthSetCustomColumnName()
        {
            string strColumnName = string.Empty;
            if (!string.IsNullOrEmpty(m_strCustomColumn1))
            {
                int intColumnNameLength = m_strCustomColumn1.Length;
                for (int i = 0; i < intColumnNameLength; i++)
                {
                    if (i == 0)
                        strColumnName += m_strCustomColumn1[i].ToString();
                    else
                        strColumnName += "\r\n" + m_strCustomColumn1[i].ToString();
                }
            }
            m_dtcOtherOutput_vchr.HeaderText = strColumnName;

            strColumnName = string.Empty;
            if (!string.IsNullOrEmpty(m_strCustomColumn2))
            {
                int intColumnNameLength = m_strCustomColumn2.Length;
                for (int i = 0; i < intColumnNameLength; i++)
                {
                    if (i == 0)
                        strColumnName += m_strCustomColumn2[i].ToString();
                    else
                        strColumnName += "\r\n" + m_strCustomColumn2[i].ToString();
                }
            }
            m_dtcOtherIntake_vchr.HeaderText = strColumnName;
        } 
        #endregion

        #endregion
    }
}