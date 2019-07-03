using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HI;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 门诊发药窗体控制
    /// Create by kong 2004-07-19
    /// </summary>
    public class clsControlOPMedStore : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        /// <summary>
        /// 门诊发药窗体控制
        /// </summary>
        public clsControlOPMedStore()
        {
            m_objManage = new clsDomainControlOPMedStore();
            m_objOperator = new clsEmployeeVO();
            PatientCharge = new clsCalcPatientCharge("", "", 0, this.m_objComInfo.m_strGetHospitalTitle(), 1, 0);
            this.m_objRecipeTable = new DataTable();
            DataColumn m_objTempColumn = new DataColumn("patientname", typeof(string));
            this.m_objRecipeTable.Columns.Add(m_objTempColumn);
            m_objTempColumn = new DataColumn("typename_vchr", typeof(string));
            this.m_objRecipeTable.Columns.Add(m_objTempColumn);
            m_objTempColumn = new DataColumn("serno_chr", typeof(string));
            this.m_objRecipeTable.Columns.Add(m_objTempColumn);
            this.m_objPatientList = new List<clsMedStorePatientListInfo>();
            this.m_strPatientListSortStyle = this.m_objComInfo.m_lonGetModuleInfo("0424");
            this.m_strIsModfilySendWinID = this.m_objComInfo.m_lonGetModuleInfo("0421");
            this.m_strCallGroupFlag = this.m_objComInfo.m_lonGetModuleInfo("0439");
            this.m_strQueuePatientType = this.m_objComInfo.m_lonGetModuleInfo("0438");
        }
        #endregion

        public frmSmallScreen m_objfrmSmallScreen;
        #region 变量
        internal string m_strCallGroupFlag = "";
        internal string m_strQueuePatientType = "";
        /// <summary>
        /// 配发药队列按序方式 0时间顺序 1 时间倒序
        /// </summary>
        private string m_strPatientListSortStyle = "0";
        /// <summary>
        /// 叫号是否更新窗口ID 0否 1是
        /// </summary>
        private string m_strIsModfilySendWinID = "0";
        private clsDomainControlMedStoreBseInfo m_objDomain = new clsDomainControlMedStoreBseInfo();
        /// <summary>
        /// 保存发药用户名
        /// </summary>
        public string strEmpName = "";
        /// <summary>
        /// 控制层变量
        /// </summary>
        private clsDomainControlOPMedStore m_objManage = null;
        /// <summary>
        /// 操作员
        /// </summary>
        private clsEmployeeVO m_objOperator;
        /// <summary>
        /// 窗口
        /// </summary>
        private clsOPMedStoreWin_VO[] objMedStoreWinArr = new clsOPMedStoreWin_VO[0];
        /// <summary>
        /// 保存处方记录
        /// </summary>
        private DataTable objItems = new DataTable();
        /// <summary>
        /// 保存挂号日期
        /// </summary>
        private string p_strDate = "";
        /// <summary>
        /// 保存处方医生
        /// </summary>
        private string p_strDoterman = "";
        /// <summary>
        /// 保存发货员
        /// </summary>
        private string p_strSentMan = "";
        /// <summary>
        /// 保存处方ID
        /// </summary>
        private string p_strpatRecipeID = "";
        /// <summary>
        /// 保存处方资料
        /// </summary>
        public clsOutpatientRecipe_VO objRecipe = new clsOutpatientRecipe_VO();
        /// <summary>
        /// 保存未发药病人资料
        /// </summary>
        private DataTable dtbResult = null;
        /// <summary>
        ///　保存病人队列信息
        /// </summary>
        private List<clsMedStorePatientListInfo> m_objPatientList = null;
        /// <summary>
        /// 收费类
        /// </summary>
        internal clsCalcPatientCharge PatientCharge = null;
        private System.Windows.Forms.RadioButton rad2 = new RadioButton();
        private System.Windows.Forms.RadioButton rad4 = new RadioButton();
        private System.Windows.Forms.RadioButton rad3 = new RadioButton();
        private System.Windows.Forms.RadioButton rad1 = new RadioButton();
        /// <summary>
        /// 保存收费项目数据
        /// </summary>
        private DataTable tbItem = new DataTable();

        /// <summary>
        /// 保存查找数据
        /// </summary>
        private DataTable tbItemFind = new DataTable();
        /// <summary>
        /// 是否打印新格式发药单 0-否;1-是
        /// </summary>
        private string m_strPrintSendMedBill = "0";
        /// <summary>
        /// 是否打印发药单
        /// </summary>
        private bool m_blnPrintSendMedBill = true;
        /// <summary>
        /// 保存刷新前的发药列表的人数
        /// </summary>
        private int intPatent = 0;
        /// <summary>
        /// 标志是否第一次进行页面
        /// </summary>
        private bool blFrist = true;
        /// <summary>
        /// 是否已经自动打印过0-否,1-是
        /// </summary>
        int intPrint = 0;
        /// <summary>
        /// 系统当前是否在自动打印
        /// </summary>
        bool isAutoPrint = false;
        /// <summary>
        /// 警告窗体
        /// </summary>
        public clsMedStorePublic publiClass = new clsMedStorePublic();
        /// <summary>
        /// 标志0-发药按钮1-配药按钮2-退处方3-门诊处方审核4-门诊审方处退方
        /// </summary>
        int intClick = 0;
        /// <summary>
        /// 保存当前选中病人信息
        /// </summary>
        public clsMedStorePatientListInfo m_objSeleRow = null;
        /// <summary>
        /// 保存处方数据
        /// </summary>
        clsOutpatientRecipe_VO[] objItemsVO = new clsOutpatientRecipe_VO[0];
        /// <summary>
        /// 保存其它普通药房指向当前急诊药房的信息
        /// </summary>
        DataTable Dutydt = new DataTable();
        /// <summary>
        /// 保存原始窗口，例如：真正配药窗口或发药窗口同原先分配的窗口不一样的时候
        /// </summary>
        string barbarismWinID = "";
        /// <summary>
        /// 保存原始药房ＩＤ，例如：真正配药药房或发药药房同原先分配的药房不一样的时候
        /// </summary>
        string barbarismStorageID = "";
        /// <summary>
        /// 处方审核模块使用，保存数据自动刷新前所选定的处方
        /// </summary>
        ArrayList SaveCheck = new ArrayList();
        /// <summary>
        /// 控制打印类
        /// </summary>
        clsFoShan2RecipeB printShow = new clsFoShan2RecipeB();
        /// <summary>
        /// 保存默认的员工信息
        /// </summary>
        public List<Emp> SaveEmp = new List<Emp>();
        /// <summary>
        /// 保存当前操作员工序号
        /// </summary>
        public int m_intSaveEmpOrder = 0;
        /// <summary>
        /// 保存默认的员工信息
        /// </summary>
        public class Emp
        {
            /// <summary>
            /// 员工ＩＤ
            /// </summary>
            public string empID = string.Empty;
            /// <summary>
            /// 员工名称
            /// </summary>
            public string empName = string.Empty;
            /// <summary>
            /// 员工工号
            /// </summary>
            public string empNo = string.Empty;
        }
        public void m_mthInitialSaveEmpList()
        {
            for (int i = 0; i < this.m_objViewer.m_intSettingCount; i++)
            {
                Emp TempSaveEmp = new Emp();
                this.SaveEmp.Add(TempSaveEmp);
            }
        }
        /// <summary>
        /// 预览电子屏的刷新时间,默认2秒
        /// </summary>
        public int m_intPreviewLEDRefreshTime = 2;

        #region 合理用药

        internal bool IsUseMedItf { get; set; }
        internal string DrugServiceUrl { get; set; }
        clsOutpatientRecipe_VO[] objRecipeMain = null;
        DataTable dtRecipeDetail { get; set; }

        #endregion

        /// <summary>
        /// 微信推送信息地址
        /// </summary>
        internal string WechatWebUrl { get; set; }

        /// <summary>
        /// 挂起处方ID
        /// </summary>
        internal static List<string> lstHungUpRecipeId { get; set; }

        #endregion
        /// <summary>
        /// 特殊处方窗口提示窗口
        /// </summary>
        public frmRecipeTypeWarning m_objfrmRecipeType = null;
        #region 设置窗体对象
        frmOPMedStoreWin m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOPMedStoreWin)frmMDI_Child_Base_in;
        }
        #endregion
        #region 按一定的时间间隔呼叫病人
        /// <summary>
        /// 按一定的时间间隔呼叫病人
        /// </summary>
        public void m_mthCallPatient()
        {
            try
            {
                string m_strMedStorID = this.m_objViewer.statusWindows.strStorageID.Trim();
                string m_strWindowID = this.m_objViewer.statusWindows.strWindowID.Trim();
                string m_strCallContent = "";
                long lngRes = -1;
                DataTable m_objTable;
                lngRes = this.m_objDomain.m_lngGetMedStoreCallInfoByID(m_strMedStorID, m_strWindowID, out m_objTable);
                if (lngRes > 0 && m_objTable.Rows.Count > 0)
                {
                    m_strCallContent = m_objTable.Rows[0]["CALLDESC_VCHR"].ToString().Trim();
                }
                if (m_strCallContent.Trim() != string.Empty)
                {
                    TTSClient.TTSClient.PlaySound(m_strCallContent);
                    lngRes = this.m_objDomain.m_lngDelMedStoreCallInfoByID(m_strMedStorID, m_strWindowID);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion
        #region 打处方方法 2006-7-31
        /// <summary>
        /// 发药窗口处方打印
        /// </summary>
        public void m_mthShowPrint()
        {
            try
            {
                if (this.m_objViewer.m_lsvOpRecDetail.Items.Count > 0)
                {
                    this.m_objViewer.m_PriviewDialogRecipe.PrintPreviewControl.Zoom = 1;
                    ((Form)this.m_objViewer.m_PriviewDialogRecipe).Icon = this.m_objViewer.Icon;
                    this.m_objViewer.m_PriviewDialogRecipe.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        public void m_mthAutoPrintRecipe(string m_strOutpatientRecipeID)
        {
            clsDomainControlMedStore Domain = new clsDomainControlMedStore();
            clsOutpatientPrintRecipe_VO m_objVO;
            clsRecipeType_VO m_objRTVO;
            Domain.m_lngGetOutpatientRecipeDetail(m_strOutpatientRecipeID, out m_objVO);
            Domain.m_lngGetRecipeTypeInfo(m_strOutpatientRecipeID, out m_objRTVO);
            if (m_objVO != null && m_objRTVO != null)
            {
                m_objVO.m_strHospitalName = GlobalParm.HospitalName;
                m_objVO.m_blnPrintBackgroudColor = this.m_objViewer.m_chkCorlor.Checked;
                PatientCharge.RecipeTypeInfo = m_objRTVO;
                PatientCharge.PrintRecipeVOInfo = m_objVO;
            }
        }
        /// <summary>
        /// 开始打印--获取打印数据
        /// </summary>
        public void m_mthBeginPrint()
        {
            if (isAutoPrint == true)
                return;
            if (this.m_objViewer.m_lsvOpRecDetail.Items.Count > 0)
            {
                string m_strRecipeID = "";
                m_strRecipeID = this.m_objViewer.m_lsvOpRecDetail.SelectedItems[0].Text.ToString().Trim();
                clsDomainControlMedStore Domain = new clsDomainControlMedStore();
                clsOutpatientPrintRecipe_VO m_objVO;
                clsRecipeType_VO m_objRTVO;
                Domain.m_lngGetOutpatientRecipeDetail(m_strRecipeID, out m_objVO);
                Domain.m_lngGetRecipeTypeInfo(m_strRecipeID, out m_objRTVO);
                if (m_objVO != null && m_objRTVO != null)
                {
                    m_objVO.m_strHospitalName = GlobalParm.HospitalName;
                    m_objVO.m_blnPrintBackgroudColor = this.m_objViewer.m_chkCorlor.Checked;
                    PatientCharge.RecipeTypeInfo = m_objRTVO;
                    PatientCharge.PrintRecipeVOInfo = m_objVO;
                }
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="e"></param>
        public void m_mthprint(System.Drawing.Printing.PrintPageEventArgs e)
        {

            #region 收集数据
            PatientCharge.m_mthPrintRecipe(e, "1");
            #endregion

        }
        #region 获取其它普通药房指向当前急诊药房的信息
        /// <summary>
        /// 获取其它普通药房指向当前急诊药房的信息
        /// </summary>
        public void m_mthGetMedStore()
        {
            m_objManage.m_longDutydt(this.m_objViewer.statusWindows.strStorageID, out Dutydt);
        }
        #endregion

        #region 锁住用户操作(当系统在自动打印的时候)
        /// <summary>
        /// 锁住用户操作
        /// </summary>
        public void m_mthFalseOrTrue(bool Value)
        {
            if (Value == true)
                m_mthGetPatientQueue();
            this.m_objViewer.panel5.Enabled = Value;
            this.m_objViewer.groupBox3.Enabled = Value;
            this.m_objViewer.panel1.Enabled = Value;
            this.m_objViewer.DateTimeMana.Enabled = Value;
            this.m_objViewer.m_timer.Enabled = Value;
            this.m_objViewer.m_lsvPatientDetial.Enabled = Value;

            this.m_objViewer.m_lsvOpRecDetail.Enabled = Value;
            this.m_objViewer.m_lsvMedicineDetail.Enabled = Value;
        }
        #endregion

        #region 填充科室信息
        /// <summary>
        /// 填充科室信息
        /// </summary>
        public void m_mthFillDep()
        {
            DataTable dtDep = new DataTable();
            long lngRes = m_objManage.m_lngGetOPDeptList(out dtDep);
            dtDep.Columns[0].ColumnName = "助 记 码";
            dtDep.Columns[1].ColumnName = "科　室　名　称";
            dtDep.Columns[2].ColumnName = "拼音码";
            dtDep.Columns[3].ColumnName = "五笔码";
            this.m_objViewer.m_txtDep.m_GetDataTable = dtDep;
        }
        #endregion

        #region 获取所有处方信息并填充到列表(审核处方模块使用）
        /// <summary>
        /// 获取所有处方信息并填充到列表(审核处方模块使用）
        /// </summary>
        public void m_mthGetAllOutpatrecipe()
        {
            this.m_objViewer.m_lsvMedicineDetail.Items.Clear();
            m_mthSaveCheck();
            string strOUTPATRECIPEID_CHR = "";
            if (this.m_objViewer.tab.SelectedIndex == 0 && this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0)
            {
                strOUTPATRECIPEID_CHR = ((clsOutpatientRecipe_VO)this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag).m_strOutpatRecipeID;
            }
            clsOutpatientRecipe_VO[] p_objResultArr = null;
            string strDepID = "";
            if (this.m_objViewer.m_txtDep.txtValuse != "" && this.m_objViewer.m_txtDep.Tag != null)
            {
                strDepID = (string)this.m_objViewer.m_txtDep.Tag;
            }
            long lngRes = m_objManage.m_lngGetRepiceListByRegID("", out p_objResultArr, this.m_objViewer.DateTimeMana.Value, this.m_objViewer.DateTimeMana.Value, 3, strDepID);
            this.m_objViewer.m_lsvPatientDetial.Items.Clear();
            this.m_objViewer.listViewok.Items.Clear();
            this.m_objViewer.lisvBreak.Items.Clear();
            if (p_objResultArr.Length > 0)
            {
                for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                {
                    m_mthFillLsv(p_objResultArr[i1]);
                }
            }
            if (strOUTPATRECIPEID_CHR != "")
                m_mthFindRow(strOUTPATRECIPEID_CHR);
            m_mthCount();
            m_mthSeleCheck();
        }
        #endregion

        #region 保存所有选定的行
        /// <summary>
        /// 保存所有选定的行
        /// </summary>
        private void m_mthSaveCheck()
        {
            SaveCheck.Clear();
            if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
            {
                for (int i1 = 0; i1 < this.m_objViewer.m_lsvPatientDetial.Items.Count; i1++)
                {
                    if (this.m_objViewer.m_lsvPatientDetial.Items[i1].Checked == true)
                    {
                        SaveCheck.Add(this.m_objViewer.m_lsvPatientDetial.Items[i1].SubItems[0].Text);
                    }
                }
            }
        }
        #endregion

        #region 选定刷新前的行
        /// <summary>
        /// 选定刷新前的行
        /// </summary>
        private void m_mthSeleCheck()
        {
            if (SaveCheck.Count > 0)
            {
                for (int f2 = 0; f2 < SaveCheck.Count; f2++)
                {
                    for (int i1 = 0; i1 < this.m_objViewer.m_lsvPatientDetial.Items.Count; i1++)
                    {
                        if (this.m_objViewer.m_lsvPatientDetial.Items[i1].SubItems[0].Text == SaveCheck[f2].ToString())
                        {
                            //this.m_objViewer.m_lsvPatientDetial.Items[i1].Checked = true;
                            this.m_objViewer.m_lsvPatientDetial.Items[i1].Checked = false;
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region 填充处方列表(审核处方模块使用）
        /// <summary>
        /// 填充处方列表(审核处方模块使用）
        /// </summary>
        private void m_mthFillLsv(clsOutpatientRecipe_VO currVO)
        {
            ListViewItem addItem = new ListViewItem(currVO.m_strOutpatRecipeID);
            addItem.SubItems.Add(currVO.m_objDiagDept.strDeptName);
            addItem.SubItems.Add(currVO.m_objDiagDr.strLastName);
            addItem.SubItems.Add(currVO.m_objPatient.strName);
            addItem.SubItems.Add(currVO.m_objPatient.strPatientCardID);
            addItem.SubItems.Add(currVO.strDIAG_VCHR);
            addItem.Tag = currVO;

            switch (currVO.CONFIRM_INT)
            {
                case 0:
                    this.m_objViewer.m_lsvPatientDetial.Items.Add(addItem);
                    this.SetHungUpBackColor();
                    break;
                case 1:
                    this.m_objViewer.listViewok.Items.Add(addItem);
                    break;
                case -1:
                    this.m_objViewer.lisvBreak.Items.Add(addItem);
                    break;
            }
        }
        #endregion
        private DataTable m_objRecipeTable;
        #region 获得所有的病人队列并真充到相应的窗体
        /// <summary>
        /// 获得所有的病人队列并真充到相应的窗体
        /// </summary>
        public void m_mthGetPatientQueue()
        {
            //自动打印期间，停止自动刷新
            if (isAutoPrint)
            {
                return;
            }
            intPatent = this.m_objViewer.m_lsvPatientDetial.Items.Count;
            long lngRes = 0;
            string m_strSid_int = string.Empty;
            string strDate = this.m_objViewer.DateTimeMana.Value.ToShortDateString();
            if (this.m_objViewer.tab.SelectedIndex == 0 && this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0)
            {
                if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                    this.m_objSeleRow = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index].Tag;
                m_strSid_int = this.m_objSeleRow.m_strSID_INT;
            }
            else if (this.m_objViewer.listViewok.SelectedItems.Count > 0)
            {
                this.m_objSeleRow = (clsMedStorePatientListInfo)this.m_objViewer.listViewok.Items[this.m_objViewer.listViewok.SelectedItems[0].Index].Tag;
                m_strSid_int = this.m_objSeleRow.m_strSID_INT;
            }
            else
            {
                m_objViewer.m_lsvOpRecDetail.Items.Clear();
                m_objViewer.m_lsvMedicineDetail.Items.Clear();
            }
            if (this.m_objViewer.checkBox1.Checked == true)
                this.m_objViewer.statusWindows.isBreakCheck = true;
            else
                this.m_objViewer.statusWindows.isBreakCheck = false;
            if (this.m_objViewer.statusWindows.m_intDiscriminateSendWindows == 1 && this.m_objViewer.statusWindows.statusTone == 2)
            {
                lngRes = m_objManage.m_lngGetPatientListNotByWinID(this.m_objViewer.statusWindows, strDate, out dtbResult, Dutydt);
            }
            else
            {
                lngRes = m_objManage.m_lngGetPatientListByWinID(this.m_objViewer.statusWindows, strDate, out dtbResult, Dutydt);
            }
            m_objViewer.m_lsvPatientDetial.Items.Clear();
            m_objViewer.listViewok.Items.Clear();
            this.m_objViewer.lisvBreak.Items.Clear();
            //备注:
            //quit_int=0是指病人被叫号,但未来取药时手动放弃,此时会将该病人放到电子屏队列的最后面，并不是真正的下屏
            //当quit_int为1时,called_int、recalled_int都为0
            //真正下屏的条件是called_int  recalled_int  quit_int  都为0
            if (lngRes > 0 && dtbResult != null)
            {
                m_objPatientList.Clear();
                DataView m_dv = dtbResult.DefaultView;
                if (this.m_objViewer.statusWindows.statusTone == 2 && this.m_strCallGroupFlag == "1")//发药窗口的待发药队列，已叫号和未叫号分开显示
                {
                    List<clsMedStorePatientListInfo> objtemp = new List<clsMedStorePatientListInfo>();
                    m_dv.RowFilter = "called_int=0 and quit_int=0";
                    dtbResult = m_dv.ToTable();
                    this.m_mthDataTableToList(dtbResult, ref objtemp);
                    m_objPatientList.AddRange(objtemp);
                    objtemp = null;
                    List<clsMedStorePatientListInfo> objtempCalled = new List<clsMedStorePatientListInfo>();
                    m_dv.RowFilter = "called_int=1 and quit_int=0";
                    dtbResult = m_dv.ToTable();
                    this.m_mthDataTableToList(dtbResult, ref objtempCalled);
                    m_objPatientList.AddRange(objtempCalled);
                    objtempCalled = null;
                    List<clsMedStorePatientListInfo> objtempQuit = new List<clsMedStorePatientListInfo>();
                    m_dv.RowFilter = "quit_int=1";
                    dtbResult = m_dv.ToTable();
                    this.m_mthDataTableToList(dtbResult, ref objtempQuit);
                    m_objPatientList.AddRange(objtempQuit);
                    objtempQuit = null;
                }
                else
                {
                    List<clsMedStorePatientListInfo> objtempNotQuit = new List<clsMedStorePatientListInfo>();
                    m_dv.RowFilter = "quit_int=0";
                    dtbResult = m_dv.ToTable();
                    this.m_mthDataTableToList(dtbResult, ref objtempNotQuit);
                    m_objPatientList.AddRange(objtempNotQuit);
                    objtempNotQuit = null;
                    List<clsMedStorePatientListInfo> objtempQuit = new List<clsMedStorePatientListInfo>();
                    m_dv.RowFilter = "quit_int=1";
                    dtbResult = m_dv.ToTable();
                    this.m_mthDataTableToList(dtbResult, ref objtempQuit);
                    m_objPatientList.AddRange(objtempQuit);
                    objtempQuit = null;
                    //this.m_mthDataTableToList(dtbResult, ref m_objPatientList);
                }
            }
            //保存未打印过的处方
            System.Collections.ArrayList ArrListPrint = new System.Collections.ArrayList();
            System.Collections.ArrayList ArrListPrintInjection = new System.Collections.ArrayList();
            List<string> lstYdSid = new List<string>();   // 药袋Sid
            if (m_objPatientList.Count > 0)
            {
                for (int i1 = m_objPatientList.Count - 1; i1 >= 0; i1--)
                {
                    m_mthFillListView(m_objPatientList[i1]);
                    if (this.m_objViewer.statusWindows.statusTone == 1 && (this.m_objViewer.checkBox2.Checked == true || this.m_objViewer.checkBox3.Checked == true || this.m_objViewer.checkBox4.Checked == true))
                    {  //旧的打印方式
                        if (this.m_blnPrintSendMedBill == true && this.m_strPrintSendMedBill.Trim() == "0")
                        {
                            if (m_objPatientList[i1].m_strAUTOPRINT_INT == "0" && m_objPatientList[i1].m_objRecipeList[0].m_strBREAKPSTATUS != "-2")
                            {
                                ArrListPrint.Add(m_objPatientList[i1].m_strSID_INT);
                            }
                        }
                        //只打印发药单，而且是打印标签的发药单
                        else if (this.m_blnPrintSendMedBill == true && this.m_strPrintSendMedBill == "1")
                        {
                            if (m_objPatientList[i1].m_strAUTOPRINT_INT == "0" && m_objPatientList[i1].m_objRecipeList[0].m_strBREAKPSTATUS != "-2")
                            {
                                ArrListPrint.Add(m_objPatientList[i1].m_strSID_INT);
                            }
                        }
                        //不打印发药单，只打印注射单等其他单
                        else if (this.m_blnPrintSendMedBill == false)
                        {
                            if (m_objPatientList[i1].m_strINJECTPRINT_INT == "0" && m_objPatientList[i1].m_objRecipeList[0].m_strBREAKPSTATUS != "-2")
                            {
                                ArrListPrintInjection.Add(m_objPatientList[i1].m_strSID_INT);
                            }
                        }
                    }
                    // 药袋.暂时屏蔽 2016.03.04
                    /*
                    if ((this.m_objViewer.statusWindows.statusTone == 1 || this.m_objViewer.statusWindows.statusTone == 2) && this.m_objViewer.m_chkMedBag.Checked)
                    {
                        if (m_objPatientList[i1].AutoPrintYD == 0 && m_objPatientList[i1].m_objRecipeList[0].m_strBREAKPSTATUS != "-2")
                        {
                            lstYdSid.Add(m_objPatientList[i1].m_strSID_INT);
                        }
                    } */
                }
                if (this.m_objViewer.tab.SelectedIndex == 0)
                {
                    m_mthFindRow(this.m_objViewer.m_lsvPatientDetial, m_strSid_int, false);
                }
                else
                {
                    m_mthFindRow(this.m_objViewer.listViewok, m_strSid_int, false);
                }
                if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count == 0 && this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                {
                    this.m_objSeleRow = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.Items[0].Tag;
                    this.m_objViewer.panel5.Tag = this.m_objSeleRow.m_objRecipeList[0].m_strRECIPETYPE_INT;

                    barbarismWinID = this.m_objSeleRow.m_strWINDOWID_CHR;
                    barbarismStorageID = this.m_objSeleRow.m_strMEDSTOREID_CHR;
                    m_mthSelPatientRow(0);
                    //this.m_objViewer.m_lsvPatientDetial.Items[0].Selected = true;
                    //this.m_objViewer.m_lsvPatientDetial.Items[0].Focused = true;
                    this.m_objViewer.m_lsvPatientDetial.Items[0].Selected = false;
                    this.m_objViewer.m_lsvPatientDetial.Items[0].Focused = false;
                    this.m_objViewer.PatientType.Text = this.m_objSeleRow.m_strPAYTYPENAME_VCHR;
                    this.m_objViewer.btnPrint.Tag = this.m_objSeleRow.m_strAUTOPRINT_INT;

                }
            }
            if (!blFrist && intPatent < this.m_objViewer.m_lsvPatientDetial.Items.Count)
            {
                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvOpRecDetail, "有新的发药单!", true);
            }
            #region 特殊类型处方记录
            if (this.dtbResult != null)
            {
                DataRow[] m_objDataRowArr = this.dtbResult.Select("recipetype_int in(2,3,4,5)");
                this.m_objRecipeTable.Clear();
                bool m_blnExisted = false;
                for (int i = 0; i < m_objDataRowArr.Length; i++)
                {
                    m_blnExisted = false;
                    for (int j = 0; j < this.m_objRecipeTable.Rows.Count; j++)
                    {
                        if (m_objDataRowArr[i]["serno_chr"].ToString().Trim() == this.m_objRecipeTable.Rows[j]["serno_chr"].ToString().Trim())
                        {
                            m_blnExisted = true;
                            break;
                        }
                    }
                    if (m_blnExisted == false)
                    {
                        DataRow m_objTempRow = this.m_objRecipeTable.NewRow();
                        m_objTempRow["patientname"] = m_objDataRowArr[i]["name_vchr"];
                        m_objTempRow["typename_vchr"] = m_objDataRowArr[i]["typename_vchr"];
                        m_objTempRow["serno_chr"] = m_objDataRowArr[i]["serno_chr"];
                        this.m_objRecipeTable.Rows.Add(m_objTempRow);
                    }
                }
            }
            #endregion
            if (this.m_objRecipeTable.Rows.Count > 0)
            {
                if (this.m_objfrmRecipeType == null)
                {
                    this.m_objfrmRecipeType = frmRecipeTypeWarning.RecipeTypeWaringForm();
                    this.m_objfrmRecipeType.m_objControlOPMedStore = this;
                }
                this.m_objfrmRecipeType.m_mthFillDataGridView(m_objRecipeTable);
            }
            else
            {
                if (this.m_objfrmRecipeType != null)
                    this.m_objfrmRecipeType.Close();
            }
            blFrist = false;
            //自动打印未打印过的发药单并且自动配药
            if (ArrListPrint.Count > 0 || ArrListPrintInjection.Count > 0 || lstYdSid.Count > 0)
            {
                this.m_mthPrintAll(ArrListPrint, ArrListPrintInjection, lstYdSid);
            }
            m_mthCount();

            if (this.m_objViewer.checkBox2.Checked && this.m_objViewer.statusWindows.m_intOmitDispense == 1 && this.m_objViewer.statusWindows.statusTone == 1)
            {

                this.m_mthInitDispenseTime();
                this.m_objViewer.m_timerDispense.Enabled = true;
            }

            if (this.m_objViewer.statusWindows.statusTone == 2 && this.m_objViewer.statusWindows.strWindowID != "0016")
            {
                //this.m_objViewer.m_txtSeqID.Focus();
                this.m_objViewer.txtWechatCode.Focus();
            }

        }
        #endregion
        /// <summary>
        /// 自动打印之后,经过设置时间段后自动配药
        /// </summary>
        public void m_mthAutoDispenseAfterAutoPrint()
        {
            if (SaveEmp[0].empID == null || SaveEmp[0].empID == string.Empty)
            {
                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "请先设置默认的操作员，以便进行自动配药！！");
                this.m_objViewer.m_timerDispense.Enabled = false;
                return;
            }
            int m_intCount = this.m_objViewer.m_lsvPatientDetial.Items.Count;
            if (m_intCount > 0)
            {
                //最先收费的最新配药
                this.m_objViewer.m_lsvPatientDetial.Items[m_intCount - 1].Selected = true;
                this.m_objViewer.m_lsvPatientDetial.Items[m_intCount - 1].Focused = true;
            }
            for (int i = 0; i < m_intCount; i++)
            {
                this.m_mthDosageData(SaveEmp[0].empID, SaveEmp[0].empName);
            }
            this.m_objViewer.m_timerDispense.Enabled = false;
        }
        #region 填充ListView
        /// <summary>
        /// 填充ListView
        /// </summary>
        /// <param name="m_objTemp"></param>
        private void m_mthFillListView(clsMedStorePatientListInfo m_objTemp)
        {
            ListViewItem lsvItem = new ListViewItem(m_objTemp.m_strNAME_VCHR);
            //状态 1-新建 2-已配药 3-已发药 -1-退回
            switch (m_objTemp.m_strPSTATUS_INT)
            {
                case "1":
                    if (m_objTemp.m_strSERNO_CHR != null && m_objTemp.m_strSERNO_CHR != string.Empty)
                    {

                        lsvItem.SubItems.Add(m_objTemp.m_strSERNO_CHR);
                    }
                    else
                    {
                        lsvItem.SubItems.Add("");
                    }
                    lsvItem.SubItems.Add(m_objTemp.m_objRecipeList[0].m_datRECORDDATE_DAT.ToString("HH:mm"));
                    lsvItem.SubItems.Add(m_objTemp.m_strPATIENTCARDID_CHR);
                    lsvItem.SubItems.Add(m_objTemp.m_strSID_INT);
                    lsvItem.Tag = m_objTemp;
                    if (m_objTemp.m_strIsGreen == "1")
                    {
                        lsvItem.BackColor = Color.Orange;
                    }
                    this.m_objViewer.m_lsvPatientDetial.Items.Add(lsvItem);
                    if (m_objTemp.m_objRecipeList[0].m_strBREAKPSTATUS == "-2")
                    {
                        this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].ForeColor = System.Drawing.Color.Red;
                    }
                    if (m_objTemp.SecuLevel > 0)
                    {
                        this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].ForeColor = Color.White;
                        this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].BackColor = Color.Red;
                    }
                    this.SetHungUpBackColor();
                    break;
                case "2":
                    if (m_objTemp.m_strSERNO_CHR != null && m_objTemp.m_strSERNO_CHR != string.Empty)
                    {

                        lsvItem.SubItems.Add(m_objTemp.m_strSERNO_CHR);
                    }
                    else
                    {
                        lsvItem.SubItems.Add("");
                    }
                    lsvItem.SubItems.Add(m_objTemp.m_objRecipeList[0].m_datRECORDDATE_DAT.ToString("HH:mm"));
                    lsvItem.SubItems.Add(m_objTemp.m_strPATIENTCARDID_CHR);
                    lsvItem.SubItems.Add(m_objTemp.m_strSID_INT);
                    if (m_objTemp.m_intQuit_int == 1)
                    {
                        lsvItem.BackColor = Color.Silver;//放弃叫号的变灰色
                    }
                    lsvItem.Tag = m_objTemp;
                    if (this.m_objViewer.statusWindows.statusTone == 1)
                    {
                        this.m_objViewer.listViewok.Items.Add(lsvItem);
                        if (m_objTemp.m_objRecipeList[0].m_strBREAKPSTATUS == "-2")
                        {
                            this.m_objViewer.listViewok.Items[this.m_objViewer.listViewok.Items.Count - 1].ForeColor = System.Drawing.Color.Red;
                        }
                        if (m_objTemp.SecuLevel > 0)
                        {
                            this.m_objViewer.listViewok.Items[this.m_objViewer.listViewok.Items.Count - 1].ForeColor = Color.White;
                            this.m_objViewer.listViewok.Items[this.m_objViewer.listViewok.Items.Count - 1].BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (m_objTemp.m_objRecipeList[0].m_strRECIPETYPE_INT == "2")
                        {
                            if (m_objTemp.m_intCalled == 0 && m_objTemp.m_intReCalled_int == 0)
                            {
                                this.m_objViewer.m_lsvPatientDetial.Items.Insert(0, lsvItem);
                                this.m_objViewer.m_lsvPatientDetial.Items[0].Font = new Font(this.m_objViewer.m_lsvPatientDetial.Font, FontStyle.Bold);
                                //this.m_objViewer.m_lsvPatientDetial.Items[0].ForeColor = System.Drawing.Color.Red;
                                if (m_objTemp.m_objRecipeList[0].m_strBREAKPSTATUS == "-2")
                                {
                                    this.m_objViewer.m_lsvPatientDetial.Items[0].ForeColor = System.Drawing.Color.Yellow;
                                }
                            }
                            else if (m_objTemp.m_intCalled == 1 || m_objTemp.m_intReCalled_int == 1)
                            {
                                this.m_objViewer.m_lsvPatientDetial.Items.Add(lsvItem);
                                this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].Font = new Font(this.m_objViewer.m_lsvPatientDetial.Font, FontStyle.Bold);
                                if (m_objTemp.m_objRecipeList[0].m_strBREAKPSTATUS == "-2")
                                {
                                    this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].ForeColor = System.Drawing.Color.Yellow;
                                }
                                this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                                if (m_objTemp.SecuLevel > 0)
                                {
                                    this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].ForeColor = Color.White;
                                    this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].BackColor = Color.Red;
                                }
                                this.SetHungUpBackColor();
                            }
                        }
                        else
                        {
                            if (m_strCallGroupFlag == "1")
                            {
                                this.m_objViewer.m_lsvPatientDetial.Items.Insert(0, lsvItem);
                                if (m_objTemp.m_intCalled == 1 || m_objTemp.m_intReCalled_int == 1)
                                {
                                    this.m_objViewer.m_lsvPatientDetial.Items[0].BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                                }
                            }
                            else
                            {
                                this.m_objViewer.m_lsvPatientDetial.Items.Add(lsvItem);
                                if (m_objTemp.m_intCalled == 1 || m_objTemp.m_intReCalled_int == 1)
                                {
                                    this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                                }
                                if (m_objTemp.SecuLevel > 0)
                                {
                                    this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].ForeColor = Color.White;
                                    this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].BackColor = Color.Red;
                                }
                                this.SetHungUpBackColor();
                            }

                            // this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].Font = new Font(this.m_objViewer.m_lsvPatientDetial.Font, FontStyle.Bold);

                            if (m_objTemp.m_objRecipeList[0].m_strBREAKPSTATUS == "-2")
                            {
                                this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.Items.Count - 1].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                    if (m_objTemp.m_strIsGreen == "1")
                    {
                        lsvItem.BackColor = Color.Orange;
                    }
                    this.SetHungUpBackColor();
                    break;
                case "3":
                    if (m_objTemp.m_strSERNO_CHR != null && m_objTemp.m_strSERNO_CHR != string.Empty)
                    {

                        lsvItem.SubItems.Add(m_objTemp.m_strSERNO_CHR);
                    }
                    else
                    {
                        lsvItem.SubItems.Add("");
                    }
                    lsvItem.SubItems.Add(m_objTemp.m_objRecipeList[0].m_datRECORDDATE_DAT.ToString("HH:mm"));
                    lsvItem.SubItems.Add(m_objTemp.m_strPATIENTCARDID_CHR);
                    lsvItem.SubItems.Add(m_objTemp.m_strSID_INT);
                    lsvItem.Tag = m_objTemp;
                    if (m_objTemp.m_strIsGreen == "1")
                    {
                        lsvItem.BackColor = Color.Orange;
                    }
                    this.m_objViewer.listViewok.Items.Add(lsvItem);
                    if (m_objTemp.m_objRecipeList[0].m_strBREAKPSTATUS == "-2")
                    {
                        this.m_objViewer.listViewok.Items[this.m_objViewer.listViewok.Items.Count - 1].ForeColor = System.Drawing.Color.Red;
                    }
                    if (m_objTemp.SecuLevel > 0)
                    {
                        this.m_objViewer.listViewok.Items[this.m_objViewer.listViewok.Items.Count - 1].ForeColor = Color.White;
                        this.m_objViewer.listViewok.Items[this.m_objViewer.listViewok.Items.Count - 1].BackColor = Color.Red;
                    }
                    break;
                case "-1":
                    if (m_objTemp.m_strSERNO_CHR != null && m_objTemp.m_strSERNO_CHR != string.Empty)
                    {

                        lsvItem.SubItems.Add(m_objTemp.m_strSERNO_CHR);
                    }
                    else
                    {
                        lsvItem.SubItems.Add("");
                    }
                    lsvItem.SubItems.Add(m_objTemp.m_objRecipeList[0].m_datRECORDDATE_DAT.ToString("HH:mm"));
                    lsvItem.SubItems.Add(m_objTemp.m_strPATIENTCARDID_CHR);
                    lsvItem.SubItems.Add(m_objTemp.m_strSID_INT);
                    lsvItem.Tag = m_objTemp;
                    if (m_objTemp.m_strIsGreen == "1")
                    {
                        lsvItem.BackColor = Color.Orange;
                    }
                    this.m_objViewer.lisvBreak.Items.Add(lsvItem);
                    if (m_objTemp.m_objRecipeList[0].m_strBREAKPSTATUS == "-2")
                    {
                        this.m_objViewer.lisvBreak.Items[this.m_objViewer.lisvBreak.Items.Count - 1].ForeColor = System.Drawing.Color.Red;
                    }
                    break;
            }
        }
        #endregion

        #region 查找刷新之前选中的项
        /// <summary>
        /// 查找刷新之前选中的项
        /// </summary>
        /// <param name="objView"></param>
        /// <param name="strFind">在刷新之前选中项的流水号</param>
        /// <param name="isReset"></param>
        public bool m_mthFindRow(ListView objView, string strFind, bool isReset)
        {
            bool isExist = false;
            for (int i1 = 0; i1 < objView.Items.Count; i1++)
            {
                this.m_objSeleRow = (clsMedStorePatientListInfo)objView.Items[i1].Tag;
                if (m_objSeleRow.m_strSID_INT.Trim() == strFind.Trim())
                {
                    //objView.Items[i1].Selected = true;
                    //objView.Items[i1].Focused = true;
                    objView.Items[i1].Selected = false;
                    objView.Items[i1].Focused = false;
                    this.m_objViewer.PatientType.Text = this.m_objSeleRow.m_strPAYTYPENAME_VCHR;
                    this.m_objViewer.btnPrint.Tag = this.m_objSeleRow.m_strAUTOPRINT_INT;
                    if (isReset == true)
                        m_mthSelPatient();
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }
        #endregion

        #region 判断工号是否正确
        /// <summary>
        /// 判断工号是否正确
        /// </summary>
        /// <param name="EmpNo">工号</param>
        /// <returns>员工ＩＤ</returns>
        public string m_mthEmpNo(string EmpNo)
        {
            string EmpID = "";
            clsDomainControlMedStore Domain = new clsDomainControlMedStore();
            string EmpName = "";
            Domain.m_lngfinedata(EmpNo, out EmpName, out  EmpID);
            return EmpID;
        }
        #endregion

        #region 查找刷新之前选中的项(门诊处方审核）
        /// <summary>
        /// 查找刷新之前选中的项
        /// </summary>
        /// <param name="strFind">在刷新之前选中项的流水号</param>
        private void m_mthFindRow(string strFind)
        {
            for (int i1 = 0; i1 < this.m_objViewer.m_lsvPatientDetial.Items.Count; i1++)
            {
                clsOutpatientRecipe_VO selevo = (clsOutpatientRecipe_VO)this.m_objViewer.m_lsvPatientDetial.Items[i1].Tag;
                if (selevo.m_strOutpatRecipeID == strFind)
                {
                    //this.m_objViewer.m_lsvPatientDetial.Items[i1].Selected = true;
                    //this.m_objViewer.m_lsvPatientDetial.Items[i1].Focused = true;
                    this.m_objViewer.m_lsvPatientDetial.Items[i1].Selected = false;
                    this.m_objViewer.m_lsvPatientDetial.Items[i1].Focused = false;
                    break;
                }
            }
        }
        #endregion

        #region 选中己发药病人显示处方
        /// <summary>
        /// 选中己发药病人显示处方
        /// </summary>
        public void m_mthSelPutOutPatient()
        {
            long lngRes = 0;
            clsOutpatientRecipe_VO[] objItems = new clsOutpatientRecipe_VO[0];

            if (m_objViewer.listViewok.SelectedItems.Count <= 0)
                return;

            object[] objItem = (object[])m_objViewer.listViewok.SelectedItems[0].Tag;
            string strRegID = objItem[1].ToString();
            p_strDate = objItem[5].ToString();
            lngRes = m_objManage.m_lngGetRepiceListByRegID(strRegID, out objItems, this.m_objViewer.DateTimeMana.Value, this.m_objViewer.DateTimeMana.Value, this.m_objViewer.statusWindows.statusTone, "");

            m_objViewer.m_lsvOpRecDetail.Items.Clear();
            m_objViewer.m_lsvMedicineDetail.Items.Clear();
            if (lngRes > 0 && objItems.Length > 0)
            {
                for (int i = 0; i < objItems.Length; i++)
                {
                    ListViewItem lsvItem = new ListViewItem(objItems[i].m_strOutpatRecipeID.Trim());
                    lsvItem.SubItems.Add(objItems[i].m_objDiagDr.strLastName.Trim());
                    lsvItem.SubItems.Add(objItems[i].m_objDiagDept.strDeptName.Trim());
                    lsvItem.SubItems.Add(objItems[i].m_objRecordEmp.strLastName.Trim());
                    lsvItem.SubItems.Add(objItems[i].m_objPatient.strName.Trim());
                    lsvItem.Tag = objItems[i];
                    m_objViewer.m_lsvOpRecDetail.Items.Add(lsvItem);
                }
                this.m_objViewer.m_lsvOpRecDetail.Focus();
                this.m_objViewer.m_lsvOpRecDetail.Items[0].Selected = true;
                m_mthSelRecipe();
            }
        }
        #endregion

        #region 选中指定的病人
        /// <summary>
        /// 选中指定的病人
        /// </summary>
        public void m_mthSelPatientRow(int intRow)
        {
            this.m_objViewer.gbItem.Visible = false;
            long lngRes = 0;
            clsOutpatientRecipe_VO[] objItems = new clsOutpatientRecipe_VO[0];
            string m_strSid = string.Empty;
            if (this.m_objViewer.tab.SelectedIndex == 0)
            {
                if (this.m_objViewer.m_lsvPatientDetial.Items.Count == 0)
                    return;
                this.m_objSeleRow = (clsMedStorePatientListInfo)m_objViewer.m_lsvPatientDetial.Items[intRow].Tag;
                barbarismWinID = this.m_objSeleRow.m_strWINDOWID_CHR;
                barbarismStorageID = this.m_objSeleRow.m_strMEDSTOREID_CHR;
                p_strDate = m_objViewer.m_lsvPatientDetial.Items[intRow].SubItems[2].Text.Trim();
                m_strSid = m_objViewer.m_lsvPatientDetial.Items[intRow].SubItems[4].Text.Trim();
                m_objViewer.m_lsvPatientDetial.Items[intRow].Selected = true;
                m_objViewer.m_lsvPatientDetial.Items[intRow].Focused = true;
            }
            else
            {
                if (this.m_objViewer.listViewok.Items.Count == 0)
                    return;
                this.m_objSeleRow = (clsMedStorePatientListInfo)m_objViewer.listViewok.Items[intRow].Tag;
                barbarismWinID = this.m_objSeleRow.m_strWINDOWID_CHR;
                barbarismStorageID = this.m_objSeleRow.m_strMEDSTOREID_CHR;
                p_strDate = m_objViewer.listViewok.Items[intRow].SubItems[2].Text.Trim();
                m_strSid = m_objViewer.listViewok.Items[intRow].SubItems[4].Text.Trim();
            }
            lngRes = m_objManage.m_lngGetRepiceListBySid(m_strSid, out objItems);
            m_objViewer.m_lsvOpRecDetail.Items.Clear();
            m_objViewer.m_lsvMedicineDetail.Items.Clear();
            if (lngRes > 0 && objItems.Length > 0)
            {
                for (int i = 0; i < objItems.Length; i++)
                {
                    ListViewItem lsvItem = new ListViewItem(objItems[i].m_strOutpatRecipeID.Trim());
                    lsvItem.SubItems.Add(objItems[i].m_objDiagDr.strLastName.Trim());
                    lsvItem.SubItems.Add(objItems[i].m_objDiagDept.strDeptName.Trim());
                    lsvItem.SubItems.Add(this.m_objSeleRow.m_strLASTNAME_VCHR);
                    lsvItem.SubItems.Add(this.m_objSeleRow.m_strSENDNAME);
                    lsvItem.SubItems.Add(objItems[i].stroutpatrecipeMoney);
                    clsDomainControlMedStore Domain = new clsDomainControlMedStore();
                    DataTable dtstroageMessage = null;
                    DataTable dtwindowsMessage = null;
                    #region 取得药房与窗口信息
                    lngRes = Domain.m_lngGetStorageMessage(this.m_objSeleRow.m_strMEDSTOREID_CHR, out dtstroageMessage, out dtwindowsMessage, 1);
                    if (lngRes > 0)
                    {
                        if (dtstroageMessage.Rows.Count > 0)
                        {
                            lsvItem.SubItems.Add(dtstroageMessage.Rows[0]["MEDSTORENAME_VCHR"].ToString());
                        }
                        else
                        {
                            lsvItem.SubItems.Add("");
                        }
                    }
                    lngRes = m_objManage.m_lngGetWindowInfo(out dtwindowsMessage, this.m_objSeleRow.m_strWINDOWID_CHR, this.m_objSeleRow.m_strMEDSTOREID_CHR);
                    if (lngRes > 0)
                    {
                        if (dtwindowsMessage.Rows.Count > 0)
                        {
                            lsvItem.SubItems.Add(dtwindowsMessage.Rows[0]["WINDOWNAME_VCHR"].ToString());
                        }
                        else
                        {
                            lsvItem.SubItems.Add("");
                        }
                    }
                    lngRes = m_objManage.m_lngGetWindowInfo(out dtwindowsMessage, this.m_objSeleRow.m_strSENDWINDOWID, this.m_objSeleRow.m_strMEDSTOREID_CHR);
                    if (lngRes > 0)
                    {
                        if (dtwindowsMessage.Rows.Count > 0)
                        {
                            lsvItem.SubItems.Add(dtwindowsMessage.Rows[0]["WINDOWNAME_VCHR"].ToString());
                        }
                        else
                        {
                            lsvItem.SubItems.Add("");
                        }
                    }
                    #endregion
                    lsvItem.Tag = objItems[i];
                    m_objViewer.m_lsvOpRecDetail.Items.Add(lsvItem);
                }
                //this.m_objViewer.m_lsvOpRecDetail.Items[0].Selected = true;
                this.m_objViewer.m_lsvOpRecDetail.Items[0].Selected = false;
                this.m_objViewer.m_lsvOpRecDetail.Items[0].Focused = false;
                m_mthSelRecipe();
            }
        }
        #endregion
        /// <summary>
        /// 保存流水号
        /// </summary>
        public string m_strServerNO = string.Empty;
        #region 选中病人显示处方
        /// <summary>
        /// 选中病人显示处方
        /// </summary>
        public void m_mthSelPatient()
        {
            if (this.m_objViewer.statusWindows.statusTone != 3)
            {
                this.m_objViewer.gbItem.Visible = false;
                long lngRes = 0;
                string strSID = "";
                switch (this.m_objViewer.tab.SelectedIndex)
                {
                    case 0:
                        if (m_objViewer.m_lsvPatientDetial.SelectedItems.Count <= 0)
                            return;
                        this.m_objSeleRow = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag;
                        barbarismStorageID = this.m_objSeleRow.m_strMEDSTOREID_CHR;
                        barbarismWinID = this.m_objSeleRow.m_strWINDOWID_CHR;
                        this.m_objViewer.PatientType.Text = this.m_objSeleRow.m_strPAYTYPENAME_VCHR;
                        strSID = m_objViewer.m_lsvPatientDetial.Items[m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index].SubItems[4].Text.Trim();
                        p_strDate = m_objViewer.m_lsvPatientDetial.Items[m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index].SubItems[2].Text.Trim();
                        m_strServerNO = m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[1].Text.Trim();
                        if (m_objViewer.statusWindows.statusTone == 2)
                        {
                            //处理放弃按钮,如果是叫号或重叫号,放弃按钮生效
                            if (this.m_objSeleRow.m_intCalled == 1 || this.m_objSeleRow.m_intReCalled_int == 1)
                            {
                                this.m_objViewer.btnDosage.Enabled = true;
                            }
                            else
                            {
                                this.m_objViewer.btnDosage.Enabled = false;
                            }
                        }
                        break;
                    case 1:
                        if (m_objViewer.listViewok.SelectedItems.Count <= 0)
                            return;
                        this.m_objSeleRow = (clsMedStorePatientListInfo)this.m_objViewer.listViewok.SelectedItems[0].Tag;
                        this.m_objViewer.PatientType.Text = this.m_objSeleRow.m_strPAYTYPENAME_VCHR;
                        barbarismWinID = this.m_objSeleRow.m_strWINDOWID_CHR;
                        barbarismStorageID = this.m_objSeleRow.m_strMEDSTOREID_CHR;
                        strSID = m_objViewer.listViewok.Items[m_objViewer.listViewok.SelectedItems[0].Index].SubItems[4].Text.Trim();
                        p_strDate = m_objViewer.listViewok.Items[m_objViewer.listViewok.SelectedItems[0].Index].SubItems[2].Text.Trim();
                        break;
                    case 2:
                        if (m_objViewer.lisvBreak.SelectedItems.Count <= 0)
                            return;
                        this.m_objSeleRow = (clsMedStorePatientListInfo)this.m_objViewer.lisvBreak.SelectedItems[0].Tag;
                        this.m_objViewer.PatientType.Text = this.m_objSeleRow.m_strPAYTYPENAME_VCHR;
                        barbarismWinID = this.m_objSeleRow.m_strWINDOWID_CHR;
                        barbarismStorageID = this.m_objSeleRow.m_strMEDSTOREID_CHR;
                        strSID = m_objViewer.lisvBreak.Items[m_objViewer.lisvBreak.SelectedItems[0].Index].SubItems[4].Text.Trim();
                        p_strDate = m_objViewer.lisvBreak.Items[m_objViewer.lisvBreak.SelectedItems[0].Index].SubItems[2].Text.Trim();
                        break;
                }
                objRecipeMain = null;
                this.m_objViewer.btnPrint.Tag = this.m_objSeleRow.m_strAUTOPRINT_INT;
                this.m_objViewer.panel5.Tag = this.m_objSeleRow.m_objRecipeList[0].m_strRECIPETYPE_INT;
                lngRes = m_objManage.m_lngGetRepiceListBySid(strSID, out objItemsVO);
                objRecipeMain = objItemsVO;
                m_objViewer.m_lsvOpRecDetail.Items.Clear();
                m_objViewer.m_lsvMedicineDetail.Items.Clear();
                if (lngRes > 0 && objItemsVO.Length > 0)
                {
                    for (int i = 0; i < objItemsVO.Length; i++)
                    {
                        ListViewItem lsvItem = new ListViewItem(objItemsVO[i].m_strOutpatRecipeID.Trim());
                        lsvItem.SubItems.Add(objItemsVO[i].m_objDiagDr.strLastName.Trim());
                        lsvItem.SubItems.Add(objItemsVO[i].m_objDiagDept.strDeptName.Trim());
                        lsvItem.SubItems.Add(this.m_objSeleRow.m_strLASTNAME_VCHR);
                        lsvItem.SubItems.Add(this.m_objSeleRow.m_strSENDNAME);
                        lsvItem.SubItems.Add(objItemsVO[i].stroutpatrecipeMoney);
                        clsDomainControlMedStore Domain = new clsDomainControlMedStore();
                        DataTable dtstroageMessage = null;
                        DataTable dtwindowsMessage = null;
                        #region 取得药房与窗口信息
                        lngRes = Domain.m_lngGetStorageMessage(this.m_objSeleRow.m_strMEDSTOREID_CHR, out dtstroageMessage, out dtwindowsMessage, 1);
                        if (lngRes > 0)
                        {
                            if (dtstroageMessage.Rows.Count > 0)
                            {
                                lsvItem.SubItems.Add(dtstroageMessage.Rows[0]["MEDSTORENAME_VCHR"].ToString());
                            }
                            else
                            {
                                lsvItem.SubItems.Add("");
                            }
                        }
                        lngRes = m_objManage.m_lngGetWindowInfo(out dtwindowsMessage, this.m_objSeleRow.m_strWINDOWID_CHR, this.m_objSeleRow.m_strMEDSTOREID_CHR);
                        if (lngRes > 0)
                        {
                            if (dtwindowsMessage.Rows.Count > 0)
                            {
                                lsvItem.SubItems.Add(dtwindowsMessage.Rows[0]["WINDOWNAME_VCHR"].ToString());
                            }
                            else
                            {
                                lsvItem.SubItems.Add("");
                            }
                        }
                        lngRes = m_objManage.m_lngGetWindowInfo(out dtwindowsMessage, this.m_objSeleRow.m_strSENDWINDOWID, this.m_objSeleRow.m_strMEDSTOREID_CHR);
                        if (lngRes > 0)
                        {
                            if (dtwindowsMessage.Rows.Count > 0)
                            {
                                lsvItem.SubItems.Add(dtwindowsMessage.Rows[0]["WINDOWNAME_VCHR"].ToString());
                            }
                            else
                            {
                                lsvItem.SubItems.Add("");
                            }
                        }
                        #endregion
                        lsvItem.Tag = objItemsVO[i];
                        m_objViewer.m_lsvOpRecDetail.Items.Add(lsvItem);
                    }
                    //this.m_objViewer.m_lsvOpRecDetail.Items[0].Selected = true;
                    //this.m_objViewer.m_lsvOpRecDetail.Items[0].Focused = true;
                    this.m_objViewer.m_lsvOpRecDetail.Items[0].Selected = true;
                    this.m_objViewer.m_lsvOpRecDetail.Items[0].Focused = false;
                    m_mthSelRecipe();
                }
            }
            else
            {
                m_mthSelRecipe();
            }
        }
        #endregion
        /// <summary>
        /// DataTable to List
        /// </summary>
        /// <param name="m_objTable"></param>
        public void m_mthDataTableToList(DataTable m_objTable, ref List<clsMedStorePatientListInfo> m_objPatientList)
        {
            //安排时间排序，相同的卡号排列一起河源也同意按此原则
            //区分配发药窗：发药窗以是否叫过号标志，再按时间排序，排序后仍然选中当前叫号记录相同卡号也要在一起

            DataView dvSort = m_objTable.DefaultView;
            DataTable dtCalled = m_objTable.Clone();
            DataTable dtUnCalled = m_objTable.Clone();
            if (m_strCallGroupFlag == "1")
            {
                if (this.m_strQueuePatientType == "1" && this.m_objViewer.statusWindows.statusTone == 2)
                {
                    dvSort.Sort = "treatdate_dat asc";
                }
                else
                {
                    if (this.m_strPatientListSortStyle == "1")
                    {
                        dvSort.Sort = "recorddate_dat desc";
                    }
                    else
                    {
                        dvSort.Sort = "recorddate_dat asc";

                    }
                }
            }


            Dictionary<string, List<DataRow>> m_gdicDt = new Dictionary<string, List<DataRow>>();
            foreach (DataRowView drv in dvSort)
            {
                if (m_gdicDt.ContainsKey(drv["PATIENTCARDID_CHR"].ToString()))
                {
                    m_gdicDt[drv["PATIENTCARDID_CHR"].ToString()].Add(drv.Row);
                }
                else
                {
                    List<DataRow> m_glstRow = new List<DataRow>();
                    m_glstRow.Add(drv.Row);
                    m_gdicDt.Add(drv["PATIENTCARDID_CHR"].ToString(), m_glstRow);
                }
            }

            DataTable dtResult = dvSort.Table.Clone();
            dtResult.BeginLoadData();
            foreach (string strKey in m_gdicDt.Keys)
            {
                foreach (DataRow drtmp in m_gdicDt[strKey])
                {
                    dtResult.Rows.Add(drtmp.ItemArray);
                }
            }
            dtResult.EndLoadData();
            dtResult.AcceptChanges();

            m_objTable = dtResult;
            m_gdicDt = null;
            m_objPatientList.Clear();
            clsMedStorePatientListInfo m_objTemp;
            clsOutPatientRecipeInfo m_objTempRecipeInfo;
            for (int i = 0; i < m_objTable.Rows.Count; i++)
            {
                m_strTempSid_int = m_objTable.Rows[i]["SID_INT"].ToString().Trim();
                if (m_objPatientList.Exists(this.m_mthJudgeExists))
                {
                    continue;
                }
                m_objTemp = new clsMedStorePatientListInfo();
                m_objTemp.m_objRecipeList = new List<clsOutPatientRecipeInfo>();
                if (m_objTable.Rows[i]["BIRTH_DAT"].ToString().Trim() != string.Empty)
                {
                    m_objTemp.m_datBIRTH_DAT = Convert.ToDateTime(m_objTable.Rows[i]["BIRTH_DAT"].ToString());
                }
                if (m_objTable.Rows[i]["GIVEDATE_DAT"].ToString().Trim() != string.Empty)
                {
                    m_objTemp.m_datGIVEDATE_DAT = Convert.ToDateTime(m_objTable.Rows[i]["GIVEDATE_DAT"].ToString());
                }
                if (m_objTable.Rows[i]["RETURNDATE_DAT"].ToString().Trim() != string.Empty)
                {
                    m_objTemp.m_datRETURNDATE_DAT = Convert.ToDateTime(m_objTable.Rows[i]["RETURNDATE_DAT"].ToString());
                }
                if (m_objTable.Rows[i]["TREATDATE_DAT"].ToString().Trim() != string.Empty)
                {
                    m_objTemp.m_datTREATDATE_DAT = Convert.ToDateTime(m_objTable.Rows[i]["TREATDATE_DAT"].ToString());
                }
                if (m_objTable.Rows[i]["REGISTERDATE_DAT"].ToString().Trim() != string.Empty)
                {
                    m_objTemp.m_datREGISTERDATE_DAT = Convert.ToDateTime(m_objTable.Rows[i]["REGISTERDATE_DAT"].ToString());
                }
                if (m_objTable.Rows[i]["quit_int"].ToString().Trim() != String.Empty)
                {
                    m_objTemp.m_intQuit_int = Convert.ToInt32(m_objTable.Rows[i]["quit_int"].ToString().Trim());
                }
                if (m_objTable.Rows[i]["recalled_int"].ToString().Trim() != String.Empty)
                {
                    m_objTemp.m_intReCalled_int = Convert.ToInt32(m_objTable.Rows[i]["recalled_int"].ToString().Trim());
                }
                m_objTemp.m_strAUTOPRINT_INT = m_objTable.Rows[i]["AUTOPRINT_INT"].ToString().Trim();
                m_objTemp.AutoPrintYD = clsPublic.ConvertObjToDecimal(m_objTable.Rows[i]["AUTOPRINTYD_INT"].ToString());
                m_objTemp.m_strGIVEEMP_CHR = m_objTable.Rows[i]["GIVEEMP_CHR"].ToString().Trim();
                m_objTemp.m_strHOMEPHONE_VCHR = m_objTable.Rows[i]["HOMEPHONE_VCHR"].ToString().Trim();
                m_objTemp.m_strIDCARD_CHR = m_objTable.Rows[i]["IDCARD_CHR"].ToString().Trim();
                m_objTemp.m_strINJECTPRINT_INT = m_objTable.Rows[i]["INJECTPRINT_INT"].ToString().Trim();
                m_objTemp.m_strLASTNAME_VCHR = m_objTable.Rows[i]["LASTNAME_VCHR"].ToString().Trim();
                m_objTemp.m_strMEDSTOREID_CHR = m_objTable.Rows[i]["MEDSTOREID_CHR"].ToString().Trim();
                m_objTemp.m_strNAME_VCHR = m_objTable.Rows[i]["NAME_VCHR"].ToString().Trim();
                m_objTemp.m_strPATIENTCARDID_CHR = m_objTable.Rows[i]["PATIENTCARDID_CHR"].ToString().Trim();
                m_objTemp.m_strPATIENTID_CHR = m_objTable.Rows[i]["PATIENTID_CHR"].ToString().Trim();
                m_objTemp.m_strPAYTYPENAME_VCHR = m_objTable.Rows[i]["PAYTYPENAME_VCHR"].ToString().Trim();
                m_objTemp.m_strPSTATUS_INT = m_objTable.Rows[i]["PSTATUS_INT"].ToString().Trim();
                m_objTemp.m_strREGISTERNO_CHR = m_objTable.Rows[i]["REGISTERNO_CHR"].ToString().Trim();
                m_objTemp.m_strRETURNEMP_CHR = m_objTable.Rows[i]["RETURNEMP_CHR"].ToString();
                m_objTemp.m_strSENDNAME = m_objTable.Rows[i]["SENDNAME"].ToString().Trim();
                m_objTemp.m_strSENDWINDOWID = m_objTable.Rows[i]["SENDWINDOWID"].ToString().Trim();
                m_objTemp.m_strSERNO_CHR = m_objTable.Rows[i]["SERNO_CHR"].ToString().Trim().Trim();
                m_objTemp.m_strSEX_CHR = m_objTable.Rows[i]["SEX_CHR"].ToString().Trim();
                m_objTemp.m_strSID_INT = m_objTable.Rows[i]["SID_INT"].ToString().Trim();
                m_objTemp.m_strTREATEMP_CHR = m_objTable.Rows[i]["TREATEMP_CHR"].ToString().Trim();
                m_objTemp.m_strWINDOWID_CHR = m_objTable.Rows[i]["WINDOWID_CHR"].ToString().Trim();
                m_objTemp.m_strPayTypeID = m_objTable.Rows[i]["PAYTYPEID_CHR"].ToString().Trim();
                m_objTemp.m_intCalled = (m_objTable.Rows[i]["called_int"].ToString().Trim() == "0" ? 0 : 1);
                m_objTemp.m_strIsGreen = m_objTable.Rows[i]["isgreen_int"].ToString().Trim();
                for (int j = i; j < m_objTable.Rows.Count; j++)
                {

                    if (m_objTemp.m_strSID_INT == m_objTable.Rows[j]["SID_INT"].ToString().Trim())
                    {
                        m_objTempRecipeInfo = new clsOutPatientRecipeInfo();
                        if (m_objTable.Rows[j]["RECORDDATE_DAT"].ToString() != string.Empty)
                        {
                            m_objTempRecipeInfo.m_datRECORDDATE_DAT = Convert.ToDateTime(m_objTable.Rows[j]["RECORDDATE_DAT"].ToString());
                        }
                        m_objTempRecipeInfo.m_strBREAKPSTATUS = m_objTable.Rows[j]["BREAKPSTATUS"].ToString().Trim();
                        m_objTempRecipeInfo.m_strCHECKNAME = m_objTable.Rows[j]["CHECKNAME"].ToString().Trim();
                        m_objTempRecipeInfo.m_strINTERNALNAME = m_objTable.Rows[j]["INTERNALNAME"].ToString().Trim();
                        m_objTempRecipeInfo.m_strINVOICENO_VCHR = m_objTable.Rows[j]["INVOICENO_VCHR"].ToString().Trim();
                        m_objTempRecipeInfo.m_strOPREMP_CHR = m_objTable.Rows[j]["OPREMP_CHR"].ToString().Trim();
                        m_objTempRecipeInfo.m_strOUTPATRECIPEID_CHR = m_objTable.Rows[j]["OUTPATRECIPEID_CHR"].ToString().Trim();
                        m_objTempRecipeInfo.m_strRECIPETYPE_INT = m_objTable.Rows[j]["RECIPETYPE_INT"].ToString().Trim();
                        m_objTempRecipeInfo.m_strSPLIT_INT = m_objTable.Rows[j]["SPLIT_INT"].ToString().Trim();
                        m_objTempRecipeInfo.m_strSTATUS_INT = m_objTable.Rows[j]["STATUS_INT"].ToString().Trim();
                        m_objTempRecipeInfo.m_strTYPENAME_VCHR = m_objTable.Rows[j]["TYPENAME_VCHR"].ToString().Trim();
                        m_objTemp.m_objRecipeList.Add(m_objTempRecipeInfo);

                    }
                }
                m_objTemp.SecuLevel = (m_objTable.Rows[i]["seculevel"] == DBNull.Value ? 0 : Convert.ToInt32(m_objTable.Rows[i]["seculevel"]));

                m_objPatientList.Add(m_objTemp);
            }
        }
        /// <summary>
        /// 保存临时的序列id进行比较
        /// </summary>
        private string m_strTempSid_int;
        /// <summary>
        /// 判断病人队列信息中是否存在已存在该记录
        /// </summary>
        /// <param name="m_objTemp"></param>
        /// <returns></returns>
        public bool m_mthJudgeExists(clsMedStorePatientListInfo m_objTemp)
        {
            if (m_objTemp.m_strSID_INT == m_strTempSid_int)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region 选中处方显示项目
        /// <summary>
        /// 选中处方显示项目
        /// </summary>
        public void m_mthSelRecipe()
        {
            long lngRes = 0;
            objItems = null;
            dtRecipeDetail = null;
            clsOutpatientRecipe_VO objRecipe = new clsOutpatientRecipe_VO();
            if (this.m_objViewer.statusWindows.statusTone == 3)
            {
                switch (this.m_objViewer.tab.SelectedIndex)
                {
                    case 0:
                        if (m_objViewer.m_lsvPatientDetial.SelectedItems.Count <= 0)
                            return;
                        objRecipe = (clsOutpatientRecipe_VO)this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag;
                        break;
                    case 1:
                        if (m_objViewer.listViewok.SelectedItems.Count <= 0)
                            return;
                        objRecipe = (clsOutpatientRecipe_VO)this.m_objViewer.listViewok.SelectedItems[0].Tag;
                        break;
                    case 2:
                        if (m_objViewer.lisvBreak.SelectedItems.Count <= 0)
                            return;
                        objRecipe = (clsOutpatientRecipe_VO)this.m_objViewer.lisvBreak.SelectedItems[0].Tag;
                        break;
                }
                barbarismWinID = "";
                barbarismStorageID = "";
            }
            else
            {
                objRecipe = (clsOutpatientRecipe_VO)m_objViewer.m_lsvOpRecDetail.Items[0].Tag;
            }
            p_strDoterman = objRecipe.m_objDiagDr.strLastName;
            p_strpatRecipeID = objRecipe.m_strOutpatRecipeID;
            string strMedicneType = "";
            if (this.m_objViewer.rdbWest.Checked == true)
                strMedicneType = "0001";
            else if (this.m_objViewer.rdbChina.Checked == true)
            {
                strMedicneType = "0002";
            }
            else
            {
                strMedicneType = "0005";
            }
            lngRes = m_objManage.m_lngGetOPRecipeListByWinAndOpRecAndType(this.m_objSeleRow.m_strSID_INT, barbarismWinID, out objItems, this.m_objViewer.statusWindows.statusTone);
            dtRecipeDetail = objItems;

            //DataTable m_objTempTable;
            //m_objTempTable = objItems.Clone();
            //bool m_blnExisted=false;
            //DataRow m_objTempRow;
            //for (int i = 0; i < objItems.Rows.Count; i++)
            //{  
            //    m_blnExisted=false;
            //    for (int j = 0; j < m_objTempTable.Rows.Count; j++)
            //    {
            //        if (m_objTempTable.Rows[j]["itemid_chr"].ToString().Trim() == objItems.Rows[i]["itemid_chr"].ToString().Trim() && m_objTempTable.Rows[j]["usageid_chr"].ToString().Trim() == objItems.Rows[i]["usageid_chr"].ToString().Trim() && m_objTempTable.Rows[j]["DOSAGEQTY"].ToString().Trim() == objItems.Rows[i]["DOSAGEQTY"].ToString().Trim() && m_objTempTable.Rows[j]["FREQNAME_CHR"].ToString().Trim() == objItems.Rows[i]["FREQNAME_CHR"].ToString().Trim())
            //        {
            //            m_blnExisted = true;
            //            if (objItems.Rows[i]["QTY_DEC"] != DBNull.Value && m_objTempTable.Rows[j]["QTY_DEC"]!=DBNull.Value)
            //            {
            //                m_objTempTable.Rows[j]["QTY_DEC"] = Convert.ToInt32(objItems.Rows[i]["QTY_DEC"]) + Convert.ToInt32(m_objTempTable.Rows[j]["QTY_DEC"]);
            //            }
            //            if (objItems.Rows[i]["TOLPRICE_MNY"] != DBNull.Value && m_objTempTable.Rows[j]["TOLPRICE_MNY"] != DBNull.Value)
            //            {
            //                m_objTempTable.Rows[j]["TOLPRICE_MNY"] = Convert.ToDouble(objItems.Rows[i]["TOLPRICE_MNY"]) + Convert.ToDouble(m_objTempTable.Rows[j]["TOLPRICE_MNY"]);
            //            }
            //            if (objItems.Rows[i]["DAYS_INT"] != DBNull.Value && m_objTempTable.Rows[j]["DAYS_INT"] != DBNull.Value)
            //            {
            //                m_objTempTable.Rows[j]["DAYS_INT"] = Convert.ToInt32(objItems.Rows[i]["DAYS_INT"]) + Convert.ToInt32(m_objTempTable.Rows[j]["DAYS_INT"]);
            //            }
            //            break;
            //        }
            //    }
            //    if (m_blnExisted == false)
            //    {
            //        m_objTempRow = m_objTempTable.NewRow();
            //        for (int k = 0; k < m_objTempTable.Columns.Count; k++)
            //        {
            //            m_objTempRow[k] = objItems.Rows[i][k];
            //        }
            //        m_objTempTable.Rows.Add(m_objTempRow);
            //    }
            //}

            //objItems=m_objTempTable;
            m_objViewer.m_lsvMedicineDetail.Items.Clear();
            this.m_objViewer.WestMoney.Text = "0";
            this.m_objViewer.ChinaMoney.Text = "0";
            this.m_objViewer.ChAndEN.Text = "0";
            this.m_objViewer.CheckMoney.Text = "0";
            double dbmedMoney = 0;

            if (lngRes > 0 && objItems.Rows.Count > 0)
            {
                string p_strUpRow = "";
                for (int i1 = 0; i1 < objItems.Rows.Count; i1++)
                {

                    ListViewItem lsvItem = new ListViewItem(objItems.Rows[i1]["itemname_vchr"].ToString().Trim());
                    lsvItem.SubItems.Add(objItems.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim());
                    if (strMedicneType == "0002")
                    {
                        if (objItems.Rows[i1]["TYPENAME_VCHR"].ToString().IndexOf("中成", 0) == 0)
                        {
                            lsvItem.SubItems.Add(objItems.Rows[i1]["DOSAGEQTY"].ToString().Trim());
                        }
                        else
                        {
                            if (objItems.Rows[i1]["MIN_QTY_DEC1"].ToString().Trim() != "")
                            {
                                lsvItem.SubItems.Add(objItems.Rows[i1]["MIN_QTY_DEC1"].ToString().Trim());
                            }
                            else
                            {
                                lsvItem.SubItems.Add(objItems.Rows[i1]["MIN_QTY_DEC"].ToString().Trim());
                            }
                        }
                    }
                    else
                    {
                        lsvItem.SubItems.Add(objItems.Rows[i1]["DOSAGEQTY"].ToString().Trim());
                    }
                    if (strMedicneType == "0005")
                    {
                        lsvItem.SubItems.Add(objItems.Rows[i1]["UNITID_CHR"].ToString().Trim());
                        lsvItem.SubItems.Add(objItems.Rows[i1]["PRICE_MNY"].ToString().Trim());
                        lsvItem.SubItems.Add(objItems.Rows[i1]["TOLPRICE_MNY"].ToString().Trim());
                    }
                    else
                    {
                        lsvItem.SubItems.Add(objItems.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim());
                        lsvItem.SubItems.Add(objItems.Rows[i1]["USAGENAME_VCHR"].ToString().Trim());
                        lsvItem.SubItems.Add(objItems.Rows[i1]["FREQNAME_CHR"].ToString().Trim());
                    }
                    if (strMedicneType == "0002")
                    {
                        if (objItems.Rows[i1]["TYPENAME_VCHR"].ToString().IndexOf("中成", 0) == 0)
                        {
                            lsvItem.SubItems.Add(objItems.Rows[i1]["DAYS_INT"].ToString().Trim());
                        }
                        else
                        {
                            lsvItem.SubItems.Add(objItems.Rows[i1]["TIMES_INT"].ToString().Trim());
                        }
                    }
                    else
                    {
                        lsvItem.SubItems.Add(objItems.Rows[i1]["DAYS_INT"].ToString().Trim());
                    }
                    lsvItem.SubItems.Add(objItems.Rows[i1]["qty_dec"].ToString().Trim());
                    lsvItem.SubItems.Add(objItems.Rows[i1]["unitid_chr"].ToString().Trim());
                    lsvItem.SubItems.Add(objItems.Rows[i1]["price_mny"].ToString().Trim());
                    lsvItem.SubItems.Add(objItems.Rows[i1]["tolprice_mny"].ToString().Trim());
                    lsvItem.SubItems.Add(objItems.Rows[i1]["itemcode_vchr"].ToString().Trim());
                    lsvItem.Tag = objItems.Rows[i1];
                    m_objViewer.m_lsvMedicineDetail.Items.Add(lsvItem);
                    if (objItems.Rows[i1]["ROWNO_CHR"].ToString().Trim() == p_strUpRow && objItems.Rows[i1]["ROWNO_CHR"].ToString().Trim() != "0")
                    {
                        switch (objItems.Rows[i1]["ROWNO_CHR"].ToString().Trim())
                        {
                            case "0":
                                break;
                            case "1":
                                Color newColor = System.Drawing.Color.FromArgb(((System.Byte)(250)), ((System.Byte)(255)), ((System.Byte)(200)));
                                m_objViewer.m_lsvMedicineDetail.Items[i1 - 1].BackColor = newColor;
                                m_objViewer.m_lsvMedicineDetail.Items[i1].BackColor = newColor;
                                break;
                            case "2":
                                Color newColor1 = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(255)), ((System.Byte)(255)));
                                m_objViewer.m_lsvMedicineDetail.Items[i1 - 1].BackColor = newColor1;
                                m_objViewer.m_lsvMedicineDetail.Items[i1].BackColor = newColor1;
                                break;
                            case "3":
                                Color newColor2 = System.Drawing.Color.FromArgb(((System.Byte)(184)), ((System.Byte)(228)), ((System.Byte)(255)));
                                m_objViewer.m_lsvMedicineDetail.Items[i1 - 1].BackColor = newColor2;
                                m_objViewer.m_lsvMedicineDetail.Items[i1].BackColor = newColor2;
                                break;
                            case "4":
                                Color newColor3 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(113)));
                                m_objViewer.m_lsvMedicineDetail.Items[i1 - 1].BackColor = newColor3;
                                m_objViewer.m_lsvMedicineDetail.Items[i1].BackColor = newColor3;
                                break;
                            case "5":
                                Color newColor4 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(169)), ((System.Byte)(113)));
                                m_objViewer.m_lsvMedicineDetail.Items[i1 - 1].BackColor = newColor4;
                                m_objViewer.m_lsvMedicineDetail.Items[i1].BackColor = newColor4;
                                break;
                            default:
                                Color newColor5 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(169)), ((System.Byte)(80)));
                                m_objViewer.m_lsvMedicineDetail.Items[i1 - 1].BackColor = newColor5;
                                m_objViewer.m_lsvMedicineDetail.Items[i1].BackColor = newColor5;
                                break;
                        }
                    }
                    p_strUpRow = objItems.Rows[i1]["ROWNO_CHR"].ToString().Trim();
                }
                double tolEnMoney = 0;
                double ChEnMoney = 0;
                double dbMatMoney = 0;
                double tolMoney = 0;
                #region 根据门诊发票分类统计各种费用
                if (objItems.Rows.Count > 0)
                {
                    for (int f2 = 0; f2 < objItems.Rows.Count; f2++)
                    {

                        if (objItems.Rows[f2]["TYPENAME_VCHR"].ToString().IndexOf("中草", 0) == 0)
                        {
                            tolEnMoney += Convert.ToDouble(objItems.Rows[f2]["tolprice_mny"].ToString().Trim());
                        }
                        if (objItems.Rows[f2]["TYPENAME_VCHR"].ToString().IndexOf("中成", 0) == 0)
                        {
                            ChEnMoney += Convert.ToDouble(objItems.Rows[f2]["tolprice_mny"].ToString().Trim());
                        }
                        if (objItems.Rows[f2]["TYPENAME_VCHR"].ToString().IndexOf("材料", 0) == 0)
                        {
                            dbMatMoney += Convert.ToDouble(objItems.Rows[f2]["tolprice_mny"].ToString().Trim());
                        }
                        if (objItems.Rows[f2]["TYPENAME_VCHR"].ToString().IndexOf("西药", 0) == 0)
                        {
                            tolMoney += Convert.ToDouble(objItems.Rows[f2]["tolprice_mny"].ToString().Trim());
                        }
                    }
                    this.m_objViewer.ChinaMoney.Text = tolEnMoney.ToString().Trim();
                    this.m_objViewer.ChAndEN.Text = ChEnMoney.ToString().Trim();
                    this.m_objViewer.CheckMoney.Text = dbMatMoney.ToString().Trim();
                    this.m_objViewer.WestMoney.Text = tolMoney.ToString().Trim();
                    dbmedMoney += tolMoney + ChEnMoney;
                    this.m_objViewer.groupBox4.Tag = dbmedMoney;
                }
                #endregion
            }
        }
        #endregion

        #region 清空明细资料
        /// <summary>
        ///清空明细资料 
        /// </summary>
        public void ClearDe()
        {
            this.m_objViewer.m_lsvOpRecDetail.Items.Clear();
            this.m_objViewer.m_lsvMedicineDetail.Items.Clear();
            switch (this.m_objViewer.tab.SelectedIndex)
            {
                case 0:
                    if (this.m_objViewer.statusWindows.statusTone == 1 || this.m_objViewer.statusWindows.statusTone == 3)
                    {
                        this.m_objViewer.btnDosage.Enabled = true;

                    }
                    this.m_objViewer.buttonXP5.Enabled = true;
                    this.m_objViewer.btnSendMed.Enabled = true;
                    this.m_objViewer.btnOther.Enabled = true;
                    this.m_objViewer.btnOtherSend.Enabled = true;
                    this.m_objViewer.btnPrint.Enabled = true;
                    this.m_objViewer.btnPrintqe.Enabled = true;
                    this.m_objViewer.buttonXP3.Enabled = true;
                    if (this.m_objViewer.statusWindows.statusTone == 2)
                    {
                        this.m_objViewer.m_btnPause.Enabled = true;
                        this.m_objViewer.m_btnCall.Enabled = true;
                    }
                    this.m_objViewer.m_btnTreat.Enabled = true;
                    this.m_objViewer.m_btnPrint.Enabled = true;
                    break;
                case 1:
                    this.m_objViewer.btnSendMed.Enabled = false;
                    this.m_objViewer.btnDosage.Enabled = false;
                    this.m_objViewer.buttonXP5.Enabled = false;
                    this.m_objViewer.btnOther.Enabled = true;
                    this.m_objViewer.btnOtherSend.Enabled = true;
                    this.m_objViewer.btnPrint.Enabled = true;
                    this.m_objViewer.btnPrintqe.Enabled = true;
                    this.m_objViewer.buttonXP3.Enabled = true;
                    this.m_objViewer.m_btnCall.Enabled = false;
                    this.m_objViewer.m_btnPause.Enabled = false;
                    this.m_objViewer.m_btnTreat.Enabled = true;
                    this.m_objViewer.m_btnPrint.Enabled = true;
                    break;
                case 2:
                    this.m_objViewer.btnSendMed.Enabled = false;
                    this.m_objViewer.btnDosage.Enabled = false;
                    this.m_objViewer.btnOther.Enabled = false;
                    this.m_objViewer.buttonXP5.Enabled = false;
                    this.m_objViewer.btnOtherSend.Enabled = false;
                    this.m_objViewer.btnPrint.Enabled = false;
                    this.m_objViewer.btnPrintqe.Enabled = false;
                    this.m_objViewer.buttonXP3.Enabled = false;
                    this.m_objViewer.m_btnCall.Enabled = false;
                    this.m_objViewer.m_btnPause.Enabled = false;
                    this.m_objViewer.m_btnTreat.Enabled = false;
                    this.m_objViewer.m_btnPrint.Enabled = false;
                    break;
            }
            this.m_objViewer.PatientType.Text = "";
            this.m_objViewer.WestMoney.Text = "0";
            this.m_objViewer.ChinaMoney.Text = "0";
            this.m_objViewer.CheckMoney.Text = "0";
            this.m_objViewer.ChAndEN.Text = "0";
        }
        #endregion

        #region 发药处理
        /// <summary>
        /// 发药处理
        /// </summary>
        public long m_mthSend(string employee, string employeeName, clsOutpatientRecipe_VO objRecipe)
        {
            try
            {
                if (this.m_objViewer.m_lsvOpRecDetail.Items.Count != 0 && this.m_objViewer.m_lsvMedicineDetail.Items.Count != 0)
                {
                    clsMedRecipeSend_VO objItem = new clsMedRecipeSend_VO();
                    m_objOperator.strEmpID = employee;
                    //原发药窗口ID
                    objItem.m_objWindow = new clsOPMedStoreWin_VO();
                    objItem.m_objWindow.m_strWindowID = barbarismWinID;
                    objItem.m_objTreatEmp = m_objOperator;
                    objItem.m_objSendEmp = m_objOperator;
                    objItem.m_intPStatus = 3;
                    objItem.m_intRecipeType = (int)this.m_objViewer.m_txtMedStore.Tag;
                    objItem.m_strOutpatRecipeID = objRecipe.m_strOutpatRecipeID;

                    objItem.m_intSID = int.Parse(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[4].Text);
                    objItem.m_AUTOPRINT_INT = int.Parse(this.m_objSeleRow.m_strAUTOPRINT_INT);
                    long lngRes = 0;
                    clst_opr_nurseexecute[] nurseexecuteArr = m_mthGetVo(m_objOperator.strEmpID);
                    // lngRes = m_objManage.m_lngUpdateMedRecipeListByID(this.m_objSeleRow.m_strSENDWINDOWID, objItem, objItems, this.m_objSeleRow.m_strMEDSTOREID_CHR, this.m_objViewer.groupBox4.Tag.ToString(), nurseexecuteArr);
                    string m_strPstatus = string.Empty;
                    lngRes = m_objManage.m_lngGetRecipeSendStatusBySid(Convert.ToInt64(objItem.m_intSID), out m_strPstatus);

                    if (lngRes > 0 && m_strPstatus == "2")
                    {
                        clsDS_Outstorage_Detail[] m_objOutStorageDetailVoArr = null;
                        clsDS_StorageDetail_VO[] m_objStorageDetailVoArr = null;
                        if (this.m_objViewer.m_strSecondLevelMode == "1" && this.m_objViewer.m_strSubtractMode == "1")
                        {
                            long lngTemp = this.m_mthSubtractStorage(employee, objRecipe, ref m_objStorageDetailVoArr, ref m_objOutStorageDetailVoArr);
                            if (lngTemp == -1)
                                return 0;
                            //MessageBox.Show("准备扣库存了...", "注意...");
                        }

                        string m_strStorageID = ""; //不同窗口的话需要进行重新的判断
                        if (this.m_objSeleRow.m_strMEDSTOREID_CHR != this.m_objViewer.statusWindows.strStorageID && this.m_objViewer.m_strSubtractMode == "1")
                        {
                            m_strStorageID = this.m_objViewer.statusWindows.strStorageID;
                        }

                        //-99 更新药房库存主表和明细表错误！ -100 插入处方流水表异常！
                        lngRes = m_objManage.m_lngUpdateMedRecipeListByID(this.m_objSeleRow.m_strSENDWINDOWID, objItem, objItems, m_strStorageID,
                            this.m_objViewer.groupBox4.Tag.ToString(), nurseexecuteArr, m_objStorageDetailVoArr, ref m_objOutStorageDetailVoArr, this.m_objViewer.m_strSubtractMode, this.m_objViewer.m_strSecondLevelMode);
                        if (lngRes == -99)
                        {
                            MessageBox.Show(this.m_objViewer, "更新药房库存主表和明细表错误，不能再进行发药！", "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            return 0;
                        }
                        else if (lngRes == -100)
                        {
                            MessageBox.Show(this.m_objViewer, "插入处方流水表异常，不能再进行发药！", "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            return 0;
                        }
                        m_objManage.m_lngCancelCalledFalg(objItem.m_intSID);
                    }
                    else
                    {
                        if (m_strPstatus == "1")
                            MessageBox.Show(this.m_objViewer, "该病人没有配药，不能再进行发药！", "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                        else if (m_strPstatus == "3")
                            MessageBox.Show(this.m_objViewer, "该病人已经发药，不能再进行发药！", "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                        else if (m_strPstatus == "-1")
                            MessageBox.Show(this.m_objViewer, "该病人已经退药，不能再进行发药！", "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                        return 0;
                    }
                    if (lngRes <= 0)
                    {
                        MessageBox.Show("发药失败！\n请重新发药或与系统管理员联系！", "icare！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return 0;
                    }
                    else
                    {
                        // 发药成功，自动下屏
                        this.LedSocketMsg(0, objRecipe.m_strOutpatRecipeID);
                        /////

                        publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "已成功发药！");
                        ClearDe();
                        if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                        {
                            clsMedStorePatientListInfo newRow;
                            newRow = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index].Tag;
                            newRow.m_datGIVEDATE_DAT = newRow.m_datTREATDATE_DAT = DateTime.Now;
                            newRow.m_strPSTATUS_INT = "3";
                            newRow.m_strSENDNAME = employeeName;
                            m_mthFillListView(newRow);
                            int m_intCurrentIndex = this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index;
                            if (m_intCurrentIndex == this.m_objViewer.m_lsvPatientDetial.Items.Count - 1)
                            {
                                m_intCurrentIndex--;
                            }
                            clsCallPatientVo m_objTempVo = new clsCallPatientVo();
                            m_objTempVo.m_strPatientName = this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Text.Trim();
                            m_objTempVo.m_strServerNo = this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[1].Text.Trim();
                            for (int i = 0; i < this.m_objViewer.m_objArrayList.Count; i++)
                            {
                                if (m_objTempVo.m_strServerNo == ((clsCallPatientVo)this.m_objViewer.m_objArrayList[i]).m_strServerNo)
                                {
                                    this.m_objViewer.m_objArrayList.RemoveAt(i);
                                    break;
                                }
                            }
                            m_objViewer.m_lsvPatientDetial.Items.RemoveAt(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index);

                            if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                            {
                                m_mthSelPatientRow(m_intCurrentIndex);
                                this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Selected = false;
                                //this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Focused = true;
                                this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Focused = false;
                            }

                            //int m_objBmpCount = (int)Math.Ceiling(double.Parse(this.m_objViewer.m_objArrayList.Count.ToString()) / 12);
                            #region 暂时屏蔽上发药上小屏
                            //m_objfrmSmallScreen = frmSmallScreen.SmallScreenForm(string.Empty);
                            //m_objfrmSmallScreen.m_objBmpArr = new Bitmap[m_objBmpCount];
                            //m_objfrmSmallScreen.m_blnShowPreviewLED = this.m_objViewer.m_chkShowScreen.Checked;
                            //m_objfrmSmallScreen.timer1.Interval = this.m_intPreviewLEDRefreshTime * 1000;
                            //m_objfrmSmallScreen.m_strMedStoreID = this.m_objViewer.statusWindows.strStorageID;
                            //m_objfrmSmallScreen.m_strWindowID = this.m_objViewer.statusWindows.strWindowID;
                            //m_objfrmSmallScreen.m_intIndex = 0;
                            //m_objfrmSmallScreen.m_mthShowContent(this.m_objViewer.cbWindows.Text.Trim(),this.m_objViewer.m_lsvPatientDetial, this.m_objViewer.m_objArrayList);
                            #endregion
                            m_mthCount();

                        }
                        return 1;
                    }

                }
                else
                {
                    long lngRes = m_objManage.m_lngSetNullityData(objRecipe.m_strOutpatRecipeID);
                    if (lngRes == 1)
                    {
                        MessageBox.Show("空处方！\n系统己进行无效处理请与系统管理员联系！", "icare！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        m_objViewer.m_lsvOpRecDetail.Items.Clear();
                        for (int i1 = 0; i1 < m_objViewer.m_lsvPatientDetial.Items.Count; i1++)
                        {
                            if (m_objViewer.m_lsvPatientDetial.Items[i1].SubItems[3].Text.Trim() == objRecipe.m_strOutpatRecipeID.ToString().Trim())
                            {
                                m_objViewer.m_lsvPatientDetial.Items.RemoveAt(i1);
                            }
                        }
                    }
                }
                m_mthCount();
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 取消叫号
        /// <summary>
        /// 取消叫号
        /// </summary>
        /// <returns></returns>
        public void m_lngCancleCalledFlag()
        {
            try
            {
                long p_lngSid = 0;
                if (this.m_objViewer.listViewok.SelectedItems.Count == 0 && this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择病人", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.m_objViewer.tab.SelectedTab.Text == "未发")
                {
                    clsMedStorePatientListInfo objvo = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag;
                    p_lngSid = Convert.ToInt64(objvo.m_strSID_INT);
                }
                else if (this.m_objViewer.tab.SelectedTab.Text == "已发")
                {
                    clsMedStorePatientListInfo objvo = (clsMedStorePatientListInfo)this.m_objViewer.listViewok.SelectedItems[0].Tag;
                    p_lngSid = Convert.ToInt64(objvo.m_strSID_INT);

                }
                m_objManage.m_lngCancelCalledFalg(p_lngSid);
                m_mthGetPatientQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "取消出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        #region 发药处理
        /// <summary>
        /// 发药处理
        /// </summary>
        /// <param name="m_objDispenseVo"></param>
        /// <param name="m_objSendMedicineVo"></param>
        /// <param name="objRecipe"></param>
        /// <returns></returns>
        public long m_mthSendMedicine(clsEmployeeVO m_objDispenseVo, clsEmployeeVO m_objSendMedicineVo, clsOutpatientRecipe_VO objRecipe)
        {
            try
            {
                if (this.m_objViewer.m_lsvOpRecDetail.Items.Count != 0 && this.m_objViewer.m_lsvMedicineDetail.Items.Count != 0)
                {
                    clsMedRecipeSend_VO objItem = new clsMedRecipeSend_VO();

                    //原发药窗口ＩＤ
                    objItem.m_objWindow = new clsOPMedStoreWin_VO();
                    objItem.m_objWindow.m_strWindowID = barbarismWinID;
                    objItem.m_objTreatEmp = m_objDispenseVo;
                    objItem.m_objSendEmp = m_objSendMedicineVo;
                    objItem.m_intPStatus = 3;
                    objItem.m_intRecipeType = (int)this.m_objViewer.m_txtMedStore.Tag;
                    objItem.m_strOutpatRecipeID = objRecipe.m_strOutpatRecipeID;
                    objItem.m_intSID = int.Parse(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[4].Text);
                    objItem.m_AUTOPRINT_INT = int.Parse(this.m_objSeleRow.m_strAUTOPRINT_INT);
                    long lngRes = 0;
                    clst_opr_nurseexecute[] nurseexecuteArr = m_mthGetVo(m_objSendMedicineVo.strEmpID);
                    lngRes = m_objManage.m_lngUpdateMedRecipeListByID(this.m_objSeleRow.m_strSENDWINDOWID, objItem, objItems, this.m_objSeleRow.m_strMEDSTOREID_CHR, this.m_objViewer.groupBox4.Tag.ToString(), nurseexecuteArr);
                    if (lngRes <= 0)
                    {
                        MessageBox.Show("发药失败！\n请重新发药或与系统管理员联系！", "icare！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return 0;
                    }
                    else
                    {
                        ClearDe();
                        if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                        {
                            clsMedStorePatientListInfo newRow;
                            newRow = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index].Tag;
                            newRow.m_datGIVEDATE_DAT = newRow.m_datTREATDATE_DAT = DateTime.Now;
                            newRow.m_strPSTATUS_INT = "3";
                            newRow.m_strSENDNAME = m_objSendMedicineVo.strName;
                            m_mthFillListView(newRow);
                            int m_intCurrentIndex = this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index;
                            if (m_intCurrentIndex == this.m_objViewer.m_lsvPatientDetial.Items.Count - 1)
                            {
                                m_intCurrentIndex--;
                            }
                            clsCallPatientVo m_objTempVo = new clsCallPatientVo();
                            m_objTempVo.m_strPatientName = this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Text.Trim();
                            m_objTempVo.m_strServerNo = this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[1].Text.Trim();
                            for (int i = 0; i < this.m_objViewer.m_objArrayList.Count; i++)
                            {
                                if (m_objTempVo.m_strServerNo == ((clsCallPatientVo)this.m_objViewer.m_objArrayList[i]).m_strServerNo)
                                {
                                    this.m_objViewer.m_objArrayList.RemoveAt(i);
                                    break;
                                }
                            }
                            m_objViewer.m_lsvPatientDetial.Items.RemoveAt(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index);
                            if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                            {
                                m_mthSelPatientRow(m_intCurrentIndex);
                                //this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Selected = true;
                                //this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Focused = true;
                                this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Selected = false;
                                this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Focused = false;
                            }
                            #region
                            //int m_objBmpCount = (int)Math.Ceiling(double.Parse(this.m_objViewer.m_objArrayList.Count.ToString()) / 12);

                            //m_objfrmSmallScreen = frmSmallScreen.SmallScreenForm(string.Empty);
                            //m_objfrmSmallScreen.m_objBmpArr = new Bitmap[m_objBmpCount];
                            //m_objfrmSmallScreen.m_blnShowPreviewLED = this.m_objViewer.m_chkShowScreen.Checked;
                            //m_objfrmSmallScreen.m_strMedStoreID = this.m_objViewer.statusWindows.strStorageID;
                            //m_objfrmSmallScreen.m_strWindowID = this.m_objViewer.statusWindows.strWindowID;
                            //m_objfrmSmallScreen.m_mthShowContent(this.m_objViewer.cbWindows.Text.Trim(), this.m_objViewer.m_lsvPatientDetial, this.m_objViewer.m_objArrayList);
                            #endregion
                            m_mthCount();

                        }
                        return 1;
                    }

                }
                else
                {
                    long lngRes = m_objManage.m_lngSetNullityData(objRecipe.m_strOutpatRecipeID);
                    if (lngRes == 1)
                    {
                        MessageBox.Show("空处方！\n系统己进行无效处理请与系统管理员联系！", "icare！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        m_objViewer.m_lsvOpRecDetail.Items.Clear();
                        for (int i1 = 0; i1 < m_objViewer.m_lsvPatientDetial.Items.Count; i1++)
                        {
                            if (m_objViewer.m_lsvPatientDetial.Items[i1].SubItems[3].Text.Trim() == objRecipe.m_strOutpatRecipeID.ToString().Trim())
                            {
                                m_objViewer.m_lsvPatientDetial.Items.RemoveAt(i1);
                            }
                        }
                    }
                }
                m_mthCount();
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 门诊审核处方处理
        /// <summary>
        /// 门诊审核处方处理
        /// </summary>
        private long m_mthOutpatrecipeManage(string employee, clsOutpatientRecipe_VO[] objRecipe, string strRemark, int status_int)
        {
            try
            {
                long lngRes = 0;
                lngRes = m_objManage.m_lngAuditing(objRecipe, status_int, strRemark, employee);
                string waring = "";
                if (status_int == 1)
                {
                    waring = "审核处方失败！\n请重新发药或与系统管理员联系！";
                }
                else
                {
                    waring = "退处方失败！\n请重新发药或与系统管理员联系！";
                }
                if (lngRes <= 0)
                {
                    MessageBox.Show(waring, "icare！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return 0;
                }
                else
                {
                    ClearDe();
                    if (objRecipe.Length > 0)
                    {
                        for (int i1 = 0; i1 < objRecipe.Length; i1++)
                        {
                            for (int f2 = 0; f2 < m_objViewer.m_lsvPatientDetial.Items.Count; f2++)
                            {
                                if (m_objViewer.m_lsvPatientDetial.Items[f2].SubItems[0].Text == objRecipe[i1].m_strOutpatRecipeID)
                                {
                                    objRecipe[i1].CONFIRM_INT = status_int;
                                    m_mthFillLsv(objRecipe[i1]);
                                    m_objViewer.m_lsvPatientDetial.Items.RemoveAt(f2);
                                    f2--;
                                    break;

                                }
                            }
                        }
                    }
                    if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                    {
                        this.m_objViewer.m_lsvPatientDetial.Items[0].Selected = true;
                        this.m_objViewer.m_lsvPatientDetial.Items[0].Focused = true;
                    }
                    m_mthCount();
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 退处方处理
        /// <summary>
        /// 退处方处理
        /// </summary>
        private void m_mthBreak(string employee)
        {
            clst_opr_nurseexecute[] DosageArr = m_mthGetVo(employee);
            long lngRes = m_objManage.m_lngBreak(DosageArr, int.Parse(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[4].Text));
            if (lngRes == 1)
            {
                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "已成功退处方！");
                //m_objViewer.m_lsvOpRecDetail.Items.Clear();
                //m_objViewer.m_lsvMedicineDetail.Items.Clear();
                //m_objViewer.m_lsvOpRecDetail.Items.Clear();
                ClearDe();
                clsMedStorePatientListInfo newRow;
                newRow = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index].Tag;
                newRow.m_datRETURNDATE_DAT = DateTime.Now;
                newRow.m_strPSTATUS_INT = "-1";

                m_mthFillListView(newRow);

                m_objViewer.m_lsvPatientDetial.Items.RemoveAt(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index);
                if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                {
                    m_mthSelPatientRow(0);
                    this.m_objViewer.m_lsvPatientDetial.Items[0].Selected = true;
                    this.m_objViewer.m_lsvPatientDetial.Items[0].Focused = true;
                }
                m_mthCount();
            }
            else
            {
                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "退处方失败！");
            }
        }
        #endregion

        #region 其它发药处理
        public void OtherSendMed()
        {
            if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0 && this.m_objViewer.m_DgMed.RowCount > 0)
            {
                DataRow seleRow = dtbResult.NewRow();
                seleRow = dtbResult.Rows[this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index];
                DataTable SaveTable = new DataTable();
                SaveTable.Columns.Add("MEDSTOREID_CHR");
                SaveTable.Columns.Add("ORDDATE_DAT");
                SaveTable.Columns.Add("TOLMNY_MNY");
                SaveTable.Columns.Add("PERIODID_CHR");
                SaveTable.Columns.Add("MEDSTOREORDTYPEID_CHR");
                SaveTable.Columns.Add("MEMO_VCHR");
                SaveTable.Columns.Add("CREATOR_CHR");
                SaveTable.Columns.Add("CREATEDATE_DAT");
                SaveTable.Columns.Add("ADUITEMP_CHR");
                SaveTable.Columns.Add("ADUITDATE_DAT");
                DataRow SavaRow = SaveTable.NewRow();
                #region 获得当前财务期
                clsPeriod_VO[] objPriodItems = clsPublicParm.s_GetPeriodList();
                string nowdate = clsPublicParm.s_datGetServerDate().Date.ToString();
                if (objPriodItems.Length > 0)
                {
                    int j2 = 0;
                    for (int i1 = 0; i1 < objPriodItems.Length; i1++)
                    {
                        if (Convert.ToDateTime(nowdate) >= Convert.ToDateTime(objPriodItems[i1].m_strStartDate) && Convert.ToDateTime(nowdate) <= Convert.ToDateTime(objPriodItems[i1].m_strEndDate))
                        {
                            SavaRow["PERIODID_CHR"] = objPriodItems[i1].m_strPeriodID;
                            break;
                        }
                        j2 = i1 + 1;
                    }
                #endregion
                    SavaRow["MEDSTOREORDTYPEID_CHR"] = "";
                    SavaRow["MEDSTOREID_CHR"] = "";
                    SavaRow["TOLMNY_MNY"] = this.m_objViewer.MedMoney.Text;
                    SavaRow["ORDDATE_DAT"] = clsPublicParm.s_datGetServerDate().Date.ToString();
                    SavaRow["MEMO_VCHR"] = "附加发药";
                    SavaRow["CREATOR_CHR"] = this.m_objViewer.LoginInfo.m_strEmpID;
                    SavaRow["CREATEDATE_DAT"] = clsPublicParm.s_datGetServerDate().Date.ToString();
                    SavaRow["ADUITEMP_CHR"] = this.m_objViewer.LoginInfo.m_strEmpID;
                    SavaRow["ADUITDATE_DAT"] = clsPublicParm.s_datGetServerDate().Date.ToString();
                    DataTable SaveTableDe = new DataTable();
                    SaveTableDe.Columns.Add("MEDICINEID_CHR");
                    SaveTableDe.Columns.Add("QTY_DEC");
                    SaveTableDe.Columns.Add("SALEUNITPRICE_DEC");
                    SaveTableDe.Columns.Add("SALETOLPRICE_DEC");
                    SaveTableDe.Columns.Add("UNITID_CHR");
                    for (int i1 = 0; i1 < this.m_objViewer.m_DgMed.RowCount; i1++)
                    {
                        if (this.m_objViewer.m_DgMed[i1, 8].ToString().Trim() != "")
                        {
                            DataRow newRow = SaveTableDe.NewRow();
                            newRow["MEDICINEID_CHR"] = this.m_objViewer.m_DgMed[i1, 8].ToString();
                            newRow["QTY_DEC"] = this.m_objViewer.m_DgMed[i1, 4].ToString();
                            newRow["SALEUNITPRICE_DEC"] = this.m_objViewer.m_DgMed[i1, 6].ToString();
                            newRow["SALETOLPRICE_DEC"] = this.m_objViewer.m_DgMed[i1, 7].ToString();
                            newRow["UNITID_CHR"] = this.m_objViewer.m_DgMed[i1, 5].ToString();
                            SaveTableDe.Rows.Add(newRow);
                        }
                    }
                    long lngRes = m_objManage.m_mthSaveData(SavaRow, SaveTableDe);
                    if (lngRes == 1)
                    {
                        MessageBox.Show("发药成功", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.m_objViewer.m_DgMed.m_mthDeleteAllRow();
                        this.m_objViewer.m_DgMed.CurrentCell = new DataGridCell(0, 0);
                        this.m_objViewer.MedMoney.Text = "0";
                        this.m_objViewer.multiMoney.Text = "0";
                        this.m_objViewer.CullMoney.Text = "0";
                    }
                }
            }
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthFind()
        {
            if (this.m_objViewer.cbWindows.Text == "")
                return;
            this.m_objViewer.checkBox1.Enabled = false;
            this.m_objViewer.cbWindows.Enabled = false;
            this.m_objViewer.m_timer.Enabled = false;
            this.m_objViewer.m_cmdRefersh.Enabled = false;
            this.m_objViewer.m_lsvPatientDetial.Items.Clear();
            this.m_objViewer.listViewok.Items.Clear();
            this.m_objViewer.m_lsvOpRecDetail.Items.Clear();
            this.m_objViewer.m_lsvMedicineDetail.Items.Clear();
            DataTable FTable = null;
            string strRegCardID = m_objViewer.m_txtPatientCard.Text.Trim();
            string strPatient = m_objViewer.m_txtPatient.Text.Trim();
            string strRegNo = m_objViewer.m_txtRegisterNo.Text.Trim();
            string strRegDate = this.m_objViewer.dateTimePicker1.Value.ToShortDateString();
            string strEndDate = this.m_objViewer.dateTimePicker2.Value.ToShortDateString();

            long lngRes = m_objManage.m_lngGetPatientList(this.m_objViewer.statusWindows.statusTone, this.m_objViewer.statusWindows.strStorageID, this.m_objViewer.statusWindows.strWindowID, strRegCardID, strPatient, strRegNo, strRegDate, strEndDate, this.m_objViewer.checkBox1.Checked, out FTable);
            if (lngRes > 0 && FTable.Rows.Count > 0)
            {
                List<clsMedStorePatientListInfo> m_objTempList = new List<clsMedStorePatientListInfo>();
                this.m_mthDataTableToList(FTable, ref m_objPatientList);
                for (int i1 = 0; i1 < m_objPatientList.Count; i1++)
                {
                    m_mthFillListView(m_objPatientList[i1]);
                }
                this.m_objViewer.textBox1.Text = Convert.ToDateTime(strRegDate).ToString("yyyy年MM月dd日") + "至" + Convert.ToDateTime(strEndDate).ToString("yyyy年MM月dd日");
                this.m_objViewer.textBox1.Visible = true;
                this.m_objViewer.tableLayoutPanel1.Dock = DockStyle.None;
                this.m_objViewer.tableLayoutPanel1.Visible = false;

            }
            else
            {
                this.m_objViewer.m_lsvMedicineDetail.Items.Clear();
                this.m_objViewer.m_lsvOpRecDetail.Items.Clear();
                MessageBox.Show("没有符合条件的记录！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            FindClear();
            m_mthCount();
        }
        #endregion

        #region 查找项目数据
        /// <summary>
        /// 查找项目数据
        /// </summary>
        /// <param name="strFind"></param>
        public void FindItemData(string strFind)
        {
            if (tbItem.Rows.Count == 0)
            {
                m_objManage.m_mthFindMedicine(out tbItem);
            }
            if (tbItem.Rows.Count > 0)
            {
                try
                {
                    tbItemFind = tbItem.Clone();
                }
                catch
                {
                }
                if (strFind == "")
                {
                    this.m_objViewer.DgItem.m_mthSetDataTable(tbItem);
                    this.m_objViewer.DgItem.Tag = "tbItem";
                    this.m_objViewer.DgItem.m_mthClearSelectedRow();
                    this.m_objViewer.DgItem.m_mthSelectARow(0);
                    this.m_objViewer.DgItem.CurrentCell = new DataGridCell(0, 0);
                    this.m_objViewer.DgItem.Width = this.m_objViewer.m_DgMed.Width;
                    this.m_objViewer.DgItem.Left = this.m_objViewer.m_DgMed.Left;
                    this.m_objViewer.DgItem.Visible = true;
                    this.m_objViewer.DgItem.Focus();
                    return;
                }
                tbItemFind.Rows.Clear();
                if (clsMedStorePublic.IsEngOrNumOrChina(strFind) == 1 || clsMedStorePublic.IsEngOrNumOrChina(strFind) == 3)
                {
                    for (int i1 = 0; i1 < tbItem.Rows.Count; i1++)
                    {
                        if (tbItem.Rows[i1]["ITEMCODE_VCHR"].ToString().IndexOf(strFind, 0) == 0 || tbItem.Rows[i1]["ITEMENGNAME_VCHR"].ToString().IndexOf(strFind, 0) == 0)
                        {
                            DataRow newRow = tbItemFind.NewRow();
                            newRow["ITEMCODE_VCHR"] = tbItem.Rows[i1]["ITEMCODE_VCHR"];
                            newRow["ItemType"] = tbItem.Rows[i1]["ItemType"];
                            newRow["ITEMNAME_VCHR"] = tbItem.Rows[i1]["ITEMNAME_VCHR"];
                            newRow["ITEMID_CHR"] = tbItem.Rows[i1]["ITEMID_CHR"];
                            newRow["ITEMSPEC_VCHR"] = tbItem.Rows[i1]["ITEMSPEC_VCHR"];
                            newRow["ITEMENGNAME_VCHR"] = tbItem.Rows[i1]["ITEMENGNAME_VCHR"];
                            newRow["ITEMOPUNIT_CHR"] = tbItem.Rows[i1]["ITEMOPUNIT_CHR"];
                            newRow["ITEMPRICE_MNY"] = tbItem.Rows[i1]["ITEMPRICE_MNY"];
                            newRow["ITEMOPINVTYPE_CHR"] = tbItem.Rows[i1]["ITEMOPINVTYPE_CHR"];
                            newRow["ITEMCATID_CHR"] = tbItem.Rows[i1]["ITEMCATID_CHR"];
                            newRow["SELFDEFINE_INT"] = tbItem.Rows[i1]["SELFDEFINE_INT"];
                            newRow["ITEMOPCALCTYPE_CHR"] = tbItem.Rows[i1]["ITEMOPCALCTYPE_CHR"];
                            newRow["NOQTYFLAG_INT"] = tbItem.Rows[i1]["NOQTYFLAG_INT"];
                            newRow["itemipunit_chr"] = tbItem.Rows[i1]["itemipunit_chr"];
                            newRow["submoney"] = tbItem.Rows[i1]["submoney"];
                            newRow["opchargeflg_int"] = tbItem.Rows[i1]["opchargeflg_int"];
                            tbItemFind.Rows.Add(newRow);
                        }
                    }

                }

                if (clsMedStorePublic.IsEngOrNumOrChina(strFind) == 2 || clsMedStorePublic.IsEngOrNumOrChina(strFind) == 4)
                {
                    for (int i1 = 0; i1 < tbItem.Rows.Count; i1++)
                    {
                        if (tbItem.Rows[i1]["ITEMNAME_VCHR"].ToString().IndexOf(strFind, 0) == 0)
                        {
                            DataRow newRow = tbItemFind.NewRow();
                            newRow["ITEMCODE_VCHR"] = tbItem.Rows[i1]["ITEMCODE_VCHR"];
                            newRow["ItemType"] = tbItem.Rows[i1]["ItemType"];
                            newRow["ITEMNAME_VCHR"] = tbItem.Rows[i1]["ITEMNAME_VCHR"];
                            newRow["ITEMID_CHR"] = tbItem.Rows[i1]["ITEMID_CHR"];
                            newRow["ITEMSPEC_VCHR"] = tbItem.Rows[i1]["ITEMSPEC_VCHR"];
                            newRow["ITEMENGNAME_VCHR"] = tbItem.Rows[i1]["ITEMENGNAME_VCHR"];
                            newRow["ITEMOPUNIT_CHR"] = tbItem.Rows[i1]["ITEMOPUNIT_CHR"];
                            newRow["ITEMPRICE_MNY"] = tbItem.Rows[i1]["ITEMPRICE_MNY"];
                            newRow["ITEMOPINVTYPE_CHR"] = tbItem.Rows[i1]["ITEMOPINVTYPE_CHR"];
                            newRow["ITEMCATID_CHR"] = tbItem.Rows[i1]["ITEMCATID_CHR"];
                            newRow["SELFDEFINE_INT"] = tbItem.Rows[i1]["SELFDEFINE_INT"];
                            newRow["ITEMOPCALCTYPE_CHR"] = tbItem.Rows[i1]["ITEMOPCALCTYPE_CHR"];
                            newRow["NOQTYFLAG_INT"] = tbItem.Rows[i1]["NOQTYFLAG_INT"];
                            newRow["itemipunit_chr"] = tbItem.Rows[i1]["itemipunit_chr"];
                            newRow["submoney"] = tbItem.Rows[i1]["submoney"];
                            newRow["opchargeflg_int"] = tbItem.Rows[i1]["opchargeflg_int"];
                            tbItemFind.Rows.Add(newRow);
                        }
                    }

                }
                if (clsMedStorePublic.IsEngOrNumOrChina(strFind) == 3)
                {
                    for (int i1 = 0; i1 < tbItem.Rows.Count; i1++)
                    {
                        if (tbItem.Rows[i1]["ITEMPYCODE_CHR"].ToString().IndexOf(strFind, 0) == 0 || tbItem.Rows[i1]["ITEMWBCODE_CHR"].ToString().IndexOf(strFind, 0) == 0)
                        {
                            DataRow newRow = tbItemFind.NewRow();
                            newRow["ITEMCODE_VCHR"] = tbItem.Rows[i1]["ITEMCODE_VCHR"];
                            newRow["ItemType"] = tbItem.Rows[i1]["ItemType"];
                            newRow["ITEMNAME_VCHR"] = tbItem.Rows[i1]["ITEMNAME_VCHR"];
                            newRow["ITEMSPEC_VCHR"] = tbItem.Rows[i1]["ITEMSPEC_VCHR"];
                            newRow["ITEMID_CHR"] = tbItem.Rows[i1]["ITEMID_CHR"];
                            newRow["ITEMENGNAME_VCHR"] = tbItem.Rows[i1]["ITEMENGNAME_VCHR"];
                            newRow["ITEMOPUNIT_CHR"] = tbItem.Rows[i1]["ITEMOPUNIT_CHR"];
                            newRow["ITEMPRICE_MNY"] = tbItem.Rows[i1]["ITEMPRICE_MNY"];
                            newRow["ITEMOPINVTYPE_CHR"] = tbItem.Rows[i1]["ITEMOPINVTYPE_CHR"];
                            newRow["ITEMCATID_CHR"] = tbItem.Rows[i1]["ITEMCATID_CHR"];
                            newRow["SELFDEFINE_INT"] = tbItem.Rows[i1]["SELFDEFINE_INT"];
                            newRow["ITEMOPCALCTYPE_CHR"] = tbItem.Rows[i1]["ITEMOPCALCTYPE_CHR"];
                            newRow["NOQTYFLAG_INT"] = tbItem.Rows[i1]["NOQTYFLAG_INT"];
                            newRow["itemipunit_chr"] = tbItem.Rows[i1]["itemipunit_chr"];
                            newRow["submoney"] = tbItem.Rows[i1]["submoney"];
                            newRow["opchargeflg_int"] = tbItem.Rows[i1]["opchargeflg_int"];
                            tbItemFind.Rows.Add(newRow);
                        }
                    }

                }
                if (tbItemFind.Rows.Count > 0)
                {
                    this.m_objViewer.DgItem.m_mthSetDataTable(tbItemFind);
                    this.m_objViewer.DgItem.Tag = "tbItemFind";
                    this.m_objViewer.DgItem.m_mthClearSelectedRow();
                    this.m_objViewer.DgItem.m_mthSelectARow(0);
                    this.m_objViewer.DgItem.CurrentCell = new DataGridCell(0, 0);
                    this.m_objViewer.DgItem.Width = this.m_objViewer.m_DgMed.Width;
                    this.m_objViewer.DgItem.Left = this.m_objViewer.m_DgMed.Left;
                    this.m_objViewer.DgItem.Visible = true;
                    this.m_objViewer.DgItem.Focus();
                }

            }

        }
        #endregion

        #region 选择项目数据
        public void SeleItems()
        {
            DataRow seleRow;
            if ((string)this.m_objViewer.DgItem.Tag == "tbItem")
            {
                seleRow = tbItem.NewRow();
                seleRow = tbItem.Rows[this.m_objViewer.DgItem.CurrentCell.RowNumber];
            }
            else
            {
                seleRow = tbItemFind.NewRow();
                seleRow = tbItemFind.Rows[this.m_objViewer.DgItem.CurrentCell.RowNumber];
            }
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 1] = seleRow["ITEMNAME_VCHR"];
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 2] = seleRow["ItemType"];
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 3] = seleRow["ITEMSPEC_VCHR"];
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 4] = "";
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 5] = seleRow["ITEMIPUNIT_CHR"];
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 6] = seleRow["submoney"];
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 7] = "";
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 8] = seleRow["ITEMID_CHR"];
            this.m_objViewer.m_DgMed[this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 9] = seleRow["ITEMSRCID_VCHR"];
            this.m_objViewer.m_DgMed.CurrentCell = new DataGridCell(this.m_objViewer.m_DgMed.CurrentCell.RowNumber, 4);
            this.m_objViewer.m_DgMed.Focus();
            this.m_objViewer.DgItem.Visible = false;
        }

        #endregion

        private bool CheckValues()
        {
            if (this.m_objViewer.m_txtPatientCard.Text.Trim() == "" && this.m_objViewer.m_txtPatient.Text.Trim() == "" && this.m_objViewer.m_txtRegisterNo.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #region 写入打印标志
        public void m_mthReadIN()
        {
            if ((string)this.m_objViewer.btnPrint.Tag == "0")
            {
                string WindowID = (string)this.m_objViewer.cbWindows.Tag;
                m_objManage.m_lngPrintSucc(WindowID, int.Parse(this.m_objSeleRow.m_strSID_INT));
                this.m_objSeleRow.m_strAUTOPRINT_INT = "1";
                if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                {
                    this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag = this.m_objSeleRow;
                }
                this.m_objViewer.btnPrint.Tag = "1";
            }
        }
        #endregion

        #region 打印按钮
        public void m_lngPrint(System.Windows.Forms.Control sender)
        {

            if (this.m_objViewer.tab.SelectedIndex == 0)
            {
                if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0)
                {
                    if (objItems != null && objItems.Rows.Count > 0)
                    {
                        if (this.m_strPrintSendMedBill.Trim() == "1")
                        {
                            this.m_objViewer.PrintDialog.Document.DefaultPageSettings.PaperSize = new PaperSize("标签格式", 275, 118);
                            this.m_objViewer.PrintDialog.PrintPreviewControl.Columns = 1;
                            this.m_objViewer.PrintDialog.PrintPreviewControl.AutoZoom = true;

                        }
                        ((Form)this.m_objViewer.PrintDialog).Icon = this.m_objViewer.Icon;
                        ((Form)this.m_objViewer.PrintDialog).StartPosition = FormStartPosition.CenterScreen;
                        this.m_objViewer.PrintDialog.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("没有可打印内容", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("请先选择要打印的内容！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (this.m_objViewer.tab.SelectedIndex == 1)
            {
                if (this.m_objViewer.listViewok.SelectedItems.Count > 0)
                {
                    if (objItems != null && objItems.Rows.Count > 0)
                    {
                        if (this.m_strPrintSendMedBill.Trim() == "1")
                        {
                            this.m_objViewer.PrintDialog.Document.DefaultPageSettings.PaperSize = new PaperSize("标签格式", 275, 118);
                            this.m_objViewer.PrintDialog.PrintPreviewControl.Columns = 1;
                            this.m_objViewer.PrintDialog.PrintPreviewControl.AutoZoom = true;
                        }

                        ((Form)this.m_objViewer.PrintDialog).Icon = this.m_objViewer.Icon;
                        ((Form)this.m_objViewer.PrintDialog).StartPosition = FormStartPosition.CenterScreen;
                        this.m_objViewer.PrintDialog.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("没有可打印内容", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择要打印的内容！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region 打印药袋
        /// <summary>
        /// 打印药袋
        /// </summary>
        /// <param name="sender"></param>
        public void m_lngPrintYD(System.Windows.Forms.Control sender)
        {

            if (this.m_objViewer.tab.SelectedIndex == 0)
            {
                if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0)
                {
                    if (objItems != null && objItems.Rows.Count > 0)
                    {
                        if (this.m_strPrintSendMedBill.Trim() == "1")
                        {
                            this.m_objViewer.PrintDialog.Document.DefaultPageSettings.PaperSize = new PaperSize("标签格式", 275, 118);
                            this.m_objViewer.PrintDialog.PrintPreviewControl.Columns = 1;
                            this.m_objViewer.PrintDialog.PrintPreviewControl.AutoZoom = true;

                        }
                        ((Form)this.m_objViewer.PrintDialog).Icon = this.m_objViewer.Icon;
                        ((Form)this.m_objViewer.PrintDialog).StartPosition = FormStartPosition.CenterScreen;
                        this.m_objViewer.PrintDialog.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("没有可打印内容", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("请先选择要打印的内容！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (this.m_objViewer.tab.SelectedIndex == 1)
            {
                if (this.m_objViewer.listViewok.SelectedItems.Count > 0)
                {
                    if (objItems != null && objItems.Rows.Count > 0)
                    {
                        if (this.m_strPrintSendMedBill.Trim() == "1")
                        {
                            this.m_objViewer.PrintDialog.Document.DefaultPageSettings.PaperSize = new PaperSize("标签格式", 275, 118);
                            this.m_objViewer.PrintDialog.PrintPreviewControl.Columns = 1;
                            this.m_objViewer.PrintDialog.PrintPreviewControl.AutoZoom = true;
                        }

                        ((Form)this.m_objViewer.PrintDialog).Icon = this.m_objViewer.Icon;
                        ((Form)this.m_objViewer.PrintDialog).StartPosition = FormStartPosition.CenterScreen;
                        this.m_objViewer.PrintDialog.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("没有可打印内容", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择要打印的内容！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region 打印治疗单按钮
        /// <summary>
        /// 打印治疗单按钮
        /// </summary>
        /// <param name="sender"></param>
        public void m_lngPrintTreatTip(System.Windows.Forms.Control sender)
        {

            if (this.m_objViewer.tab.SelectedIndex == 0)
            {
                if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0)
                {
                    if (objItems != null && objItems.Rows.Count > 0)
                    {
                        this.m_objViewer.m_PriviewTreatTip.PrintPreviewControl.AutoZoom = true;
                        this.m_objViewer.m_PriviewTreatTip.PrintPreviewControl.Zoom = 1;
                        ((Form)this.m_objViewer.m_PriviewTreatTip).Icon = this.m_objViewer.Icon;
                        this.m_objViewer.m_PriviewTreatTip.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("没有可打印内容", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("请先选择要打印的内容！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (this.m_objViewer.tab.SelectedIndex == 1)
            {
                if (this.m_objViewer.listViewok.SelectedItems.Count > 0)
                {
                    if (objItems != null && objItems.Rows.Count > 0)
                    {

                        this.m_objViewer.m_PriviewTreatTip.PrintPreviewControl.AutoZoom = true;
                        this.m_objViewer.m_PriviewTreatTip.PrintPreviewControl.Zoom = 1;
                        ((Form)this.m_objViewer.m_PriviewTreatTip).Icon = this.m_objViewer.Icon;
                        this.m_objViewer.m_PriviewTreatTip.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("没有可打印内容", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择要打印的内容！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region 打印病历单按钮
        public void m_mthPrintCaseHistory(System.Windows.Forms.Control sender)
        {

            if (this.m_objViewer.tab.SelectedIndex == 0)
            {
                if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0)
                {
                    if (objItems != null && objItems.Rows.Count > 0)
                    {
                        this.m_objViewer.m_PreDiagCaseHistory.PrintPreviewControl.AutoZoom = true;
                        ((Form)this.m_objViewer.m_PreDiagCaseHistory).Icon = this.m_objViewer.Icon;
                        ((Form)this.m_objViewer.m_PreDiagCaseHistory).StartPosition = FormStartPosition.CenterScreen;
                        this.m_objViewer.m_PreDiagCaseHistory.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("没有可打印内容", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("请先选择要打印的内容！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (this.m_objViewer.tab.SelectedIndex == 1)
            {
                if (this.m_objViewer.listViewok.SelectedItems.Count > 0)
                {
                    if (objItems != null && objItems.Rows.Count > 0)
                    {

                        this.m_objViewer.m_PreDiagCaseHistory.PrintPreviewControl.AutoZoom = true;
                        ((Form)this.m_objViewer.m_PreDiagCaseHistory).Icon = this.m_objViewer.Icon;
                        ((Form)this.m_objViewer.m_PreDiagCaseHistory).StartPosition = FormStartPosition.CenterScreen;
                        this.m_objViewer.m_PreDiagCaseHistory.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("没有可打印内容", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择要打印的内容！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region 获取打印表头信息
        /// <summary>
        /// 获取打印表头信息
        /// </summary>
        /// <param name="selePrintRow"></param>
        /// <returns></returns>
        private clsReportSendMedStart_VO m_GetTitMana(DataTable selePrintRow)
        {

            clsReportSendMedStart_VO ReportSendMedStart = new clsReportSendMedStart_VO();
            if (this.m_objViewer.rdbWest.Checked == true)
            {
                ReportSendMedStart.m_intFlag = 1;
                ReportSendMedStart.m_strInternalEN = selePrintRow.Rows[0]["internalname"].ToString();
            }
            else
            {
                ReportSendMedStart.m_intFlag = 2;
                ReportSendMedStart.m_strInternalEN = selePrintRow.Rows[0]["internalname"].ToString();
            }
            ReportSendMedStart.m_strPhoto = selePrintRow.Rows[0]["HOMEPHONE_VCHR"].ToString();
            ReportSendMedStart.m_strOUTPATRECIPEID_CHR = selePrintRow.Rows[0]["OUTPATRECIPEID_CHR"].ToString();
            ReportSendMedStart.m_intIsShow = 0;
            ReportSendMedStart.m_strID = selePrintRow.Rows[0]["PATIENTID_CHR"].ToString();
            ReportSendMedStart.m_strCheckOutdate = selePrintRow.Rows[0]["RECORDDATE_DAT"].ToString();
            ReportSendMedStart.strCheckOutName = selePrintRow.Rows[0]["OPREMP_CHR"].ToString().Trim() + " " + selePrintRow.Rows[0]["checkName"].ToString();

            ReportSendMedStart.m_strIDcardno = selePrintRow.Rows[0]["idcard_chr"].ToString();
            ReportSendMedStart.m_strRectype = selePrintRow.Rows[0]["typename_vchr"].ToString();
            ReportSendMedStart.m_intRecipeCount = selePrintRow.Rows.Count;
            ReportSendMedStart.strEMPName = selePrintRow.Rows[0]["LASTNAME_VCHR"].ToString();
            ReportSendMedStart.strSendName = selePrintRow.Rows[0]["sendName"].ToString().Trim();
            ReportSendMedStart.strSPLIT = selePrintRow.Rows[0]["SPLIT_INT"].ToString().Trim();
            ReportSendMedStart.strInvoiceNO = selePrintRow.Rows[0]["INVOICENO_VCHR"].ToString().Trim();
            ReportSendMedStart.m_strSerNO = selePrintRow.Rows[0]["SERNO_CHR"].ToString().Trim();
            // com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = new com.digitalwave.iCare.middletier.HIS.clsHisBase();
            com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
            if (selePrintRow.Rows[0]["BIRTH_DAT"].ToString() == "")
                ReportSendMedStart.m_strAge = "不详";
            else
            {
                try
                {
                    DateTime birth = Convert.ToDateTime(selePrintRow.Rows[0]["BIRTH_DAT"].ToString());
                    ReportSendMedStart.m_strAge = clsConvertDateTime.CalcAge(birth);
                }
                catch
                {
                    ReportSendMedStart.m_strAge = "不详";
                }
            }
            ReportSendMedStart.m_strDoctorName = selePrintRow.Rows[0]["lastname_vchr"].ToString().Trim();
            ReportSendMedStart.m_strname = selePrintRow.Rows[0]["name_vchr"].ToString().Trim();
            ReportSendMedStart.m_strPatCardID = selePrintRow.Rows[0]["PATIENTCARDID_CHR"].ToString().Trim();
            ReportSendMedStart.m_strPintdate = HisBase.s_GetServerDate().ToString();
            ReportSendMedStart.m_strRegisterdate = selePrintRow.Rows[0]["REGISTERDATE_DAT"].ToString().Trim();
            ReportSendMedStart.m_strsex = selePrintRow.Rows[0]["SEX_CHR"].ToString().Trim();
            double tolMoney = Convert.ToDouble(this.m_objViewer.WestMoney.Text.Trim()) + Convert.ToDouble(this.m_objViewer.ChAndEN.Text.Trim()) + Convert.ToDouble(this.m_objViewer.ChinaMoney.Text.Trim()) + Convert.ToDouble(this.m_objViewer.CheckMoney.Text.Trim());
            ReportSendMedStart.m_strTotalMoney = tolMoney.ToString().Trim();
            return ReportSendMedStart;
        }
        /// <summary>
        /// 获取打印表头信息
        /// </summary>
        /// <param name="selePrintRow"></param>
        /// <returns></returns>
        private clsReportSendMedStart_VO m_GetTitMana(clsMedStorePatientListInfo selePrintRow)
        {

            clsReportSendMedStart_VO ReportSendMedStart = new clsReportSendMedStart_VO();
            if (this.m_objViewer.rdbWest.Checked == true)
            {
                ReportSendMedStart.m_intFlag = 1;
                ReportSendMedStart.m_strInternalEN = selePrintRow.m_objRecipeList[0].m_strINTERNALNAME;
            }
            else
            {
                ReportSendMedStart.m_intFlag = 2;
                ReportSendMedStart.m_strInternalEN = selePrintRow.m_objRecipeList[0].m_strINTERNALNAME;
            }
            ReportSendMedStart.m_strPhoto = selePrintRow.m_strHOMEPHONE_VCHR;
            ReportSendMedStart.m_strOUTPATRECIPEID_CHR = selePrintRow.m_objRecipeList[0].m_strOUTPATRECIPEID_CHR;
            ReportSendMedStart.m_intIsShow = 0;
            ReportSendMedStart.m_strID = selePrintRow.m_strPATIENTID_CHR;
            ReportSendMedStart.m_strCheckOutdate = selePrintRow.m_objRecipeList[0].m_datRECORDDATE_DAT.ToString();
            ReportSendMedStart.strCheckOutName = selePrintRow.m_objRecipeList[0].m_strOPREMP_CHR + " " + selePrintRow.m_objRecipeList[0].m_strCHECKNAME;

            ReportSendMedStart.m_strIDcardno = selePrintRow.m_strIDCARD_CHR;
            ReportSendMedStart.m_strRectype = selePrintRow.m_objRecipeList[0].m_strTYPENAME_VCHR;
            ReportSendMedStart.m_intRecipeCount = selePrintRow.m_objRecipeList.Count;
            ReportSendMedStart.strEMPName = selePrintRow.m_strLASTNAME_VCHR;
            ReportSendMedStart.strSendName = selePrintRow.m_strSENDNAME;
            ReportSendMedStart.strSPLIT = selePrintRow.m_objRecipeList[0].m_strSPLIT_INT;
            ReportSendMedStart.strInvoiceNO = selePrintRow.m_objRecipeList[0].m_strINVOICENO_VCHR;
            ReportSendMedStart.m_strSerNO = selePrintRow.m_strSERNO_CHR;
            //com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = new com.digitalwave.iCare.middletier.HIS.clsHisBase();
            if (selePrintRow.m_datBIRTH_DAT.ToString() == "")
                ReportSendMedStart.m_strAge = "不详";
            else
            {
                try
                {
                    DateTime birth = selePrintRow.m_datBIRTH_DAT;
                    //ReportSendMedStart.m_strAge = clsConvertDateTime.CalcAge(birth);
                    ReportSendMedStart.m_strAge = new clsBrithdayToAge().m_strGetAge(birth);
                }
                catch
                {
                    ReportSendMedStart.m_strAge = "不详";
                }
            }
            ReportSendMedStart.m_strDoctorName = selePrintRow.m_strLASTNAME_VCHR;
            ReportSendMedStart.m_strname = selePrintRow.m_strNAME_VCHR;
            ReportSendMedStart.m_strPatCardID = selePrintRow.m_strPATIENTCARDID_CHR;
            ReportSendMedStart.m_strPintdate = DateTime.Now.ToString();//HisBase.s_GetServerDate().ToString();
            ReportSendMedStart.m_strRegisterdate = selePrintRow.m_datREGISTERDATE_DAT.ToString();
            ReportSendMedStart.m_strsex = selePrintRow.m_strSEX_CHR;

            if (objRecipeMain != null && objRecipeMain.Length > 0 && dtRecipeDetail != null && dtRecipeDetail.Rows.Count > 0)
            {
                string recipeId = dtRecipeDetail.Rows[0]["outpatrecipeid_chr"].ToString();
                foreach (clsOutpatientRecipe_VO item in objRecipeMain)
                {
                    if (item.m_strOutpatRecipeID == recipeId)
                    {
                        ReportSendMedStart.DeptName = item.m_objDiagDept.strDeptName;
                        break;
                    }
                }
            }

            double tolMoney = Convert.ToDouble(this.m_objViewer.WestMoney.Text.Trim()) + Convert.ToDouble(this.m_objViewer.ChAndEN.Text.Trim()) + Convert.ToDouble(this.m_objViewer.ChinaMoney.Text.Trim()) + Convert.ToDouble(this.m_objViewer.CheckMoney.Text.Trim());
            ReportSendMedStart.m_strTotalMoney = tolMoney.ToString().Trim();
            return ReportSendMedStart;
        }
        #endregion

        #region 采集打印内容
        /// <summary>
        /// 采集打印内容
        /// </summary>
        public clsReportSendMed_VO[] m_getPrintData(DataTable objItems, out double medMoney, ref clsReportSendMedStart_VO ReportSendMedStart, out double RecipeTotalMoney)
        {
            medMoney = 0;
            RecipeTotalMoney = 0;

            clsReportSendMed_VO[] ReportSendMed = new clsReportSendMed_VO[objItems.Rows.Count];
            for (int i1 = 0; i1 < objItems.Rows.Count; i1++)
            {
                ReportSendMed[i1] = new clsReportSendMed_VO();
                ReportSendMed[i1].m_strMedName = objItems.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
                ReportSendMed[i1].m_strMedSpace = objItems.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
                if (objItems.Rows[i1]["SUMUSAGE_VCHR"].ToString().Trim() != "")
                    ReportSendMedStart.m_strUseNameAll = objItems.Rows[i1]["SUMUSAGE_VCHR"].ToString().Trim();
                if (objItems.Rows[i1]["TIMES_INT"].ToString().Trim() != "0")
                    ReportSendMedStart.m_strSun = objItems.Rows[i1]["TIMES_INT"].ToString().Trim();
                ReportSendMed[i1].m_strMedUnit = objItems.Rows[i1]["UNITID_CHR"].ToString().Trim();
                ReportSendMed[i1].m_strdosageUnit = objItems.Rows[i1]["dosageunit_chr"].ToString().Trim();
                int comm = PatientCharge.m_mthIsMedicine(objItems.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim());
                ReportSendMed[i1].m_strMedType = comm.ToString();
                ReportSendMed[i1].m_strTotal = objItems.Rows[i1]["QTY_DEC"].ToString().Trim();
                ReportSendMed[i1].m_strBasicDosage = objItems.Rows[i1]["BasicDosage"].ToString().Trim();
                ReportSendMed[i1].m_strOPFreqDesc = objItems.Rows[i1]["FreqDesc"].ToString().Trim();
                ReportSendMed[i1].m_strOPUsageDesc = objItems.Rows[i1]["OPUSAGEDESC"].ToString().Trim();
                ReportSendMed[i1].m_strUsageID = objItems.Rows[i1]["usageid_chr"].ToString().Trim();
                ReportSendMed[i1].m_strDays = objItems.Rows[i1]["days_int"].ToString().Trim();
                if (objItems.Rows[i1]["PUTMED_INT"].ToString().Trim() == "0")
                {
                    ReportSendMed[i1].m_intPuted = 0;
                }
                ReportSendMed[i1].m_strUnitprce = objItems.Rows[i1]["PRICE_MNY"].ToString().Trim();
                ReportSendMed[i1].m_strItemIPUnit_chr = objItems.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
                ReportSendMed[i1].m_strTolPrce = objItems.Rows[i1]["TOLPRICE_MNY"].ToString().Trim();
                ReportSendMed[i1].m_strUseName = objItems.Rows[i1]["USAGENAME_VCHR"].ToString().Trim();
                ReportSendMed[i1].m_strFREQIDName = objItems.Rows[i1]["FREQNAME_CHR"].ToString().Trim();
                ReportSendMed[i1].m_strRowNo = objItems.Rows[i1]["ROWNO_CHR"].ToString().Trim();
                ReportSendMed[i1].m_strUseNameMakeup = objItems.Rows[i1]["DESC_VCHR"].ToString().Trim();
                ReportSendMed[i1].m_strMEDNORMALNAME = objItems.Rows[i1]["MEDNORMALNAME_VCHR"].ToString();
                ReportSendMed[i1].m_strFreqDays = objItems.Rows[i1]["DAYS_INT1"].ToString();
                ReportSendMed[i1].m_strFreqTimes = objItems.Rows[i1]["TIMES_INT1"].ToString();
                RecipeTotalMoney += Convert.ToDouble(objItems.Rows[i1]["tolprice_mny"].ToString().Trim());

                if (objItems.Rows[i1]["TYPENAME_VCHR"].ToString().IndexOf("中草", 0) == 0)
                {
                    medMoney += Convert.ToDouble(objItems.Rows[i1]["tolprice_mny"].ToString().Trim());
                    ReportSendMed[i1].m_strMedType = "3";
                }
                if (objItems.Rows[i1]["TYPENAME_VCHR"].ToString().IndexOf("中成", 0) == 0)
                {
                    medMoney += Convert.ToDouble(objItems.Rows[i1]["tolprice_mny"].ToString().Trim());
                    //中成药也是以西药的格式打印
                    ReportSendMed[i1].m_strMedType = "2";
                }
                if (objItems.Rows[i1]["TYPENAME_VCHR"].ToString().IndexOf("西药", 0) == 0 || objItems.Rows[i1]["TYPENAME_VCHR"].ToString().IndexOf("材料", 0) == 0)
                {
                    medMoney += Convert.ToDouble(objItems.Rows[i1]["tolprice_mny"].ToString().Trim());
                    ReportSendMed[i1].m_strMedType = "1";
                }
                if (ReportSendMed[i1].m_strMedType == "1" || ReportSendMed[i1].m_strMedType == "2")
                {
                    ReportSendMed[i1].m_strdosage = objItems.Rows[i1]["dosageqty"].ToString().Trim();
                }
                else
                {
                    if (objItems.Rows[i1]["MIN_QTY_DEC1"].ToString().Trim() != "")
                    {
                        ReportSendMed[i1].m_strdosage = objItems.Rows[i1]["MIN_QTY_DEC1"].ToString().Trim();
                    }
                    else
                    {
                        ReportSendMed[i1].m_strdosage = objItems.Rows[i1]["MIN_QTY_DEC"].ToString().Trim();
                    }
                }
            }
            return ReportSendMed;
        }

        #endregion

        #region VO转换(把慢病打印VO转成佛二打印VO)
        /// <summary>
        /// VO转换(把慢病打印VO转成佛二打印VO)
        /// </summary>
        /// <param name="ReportSendMedStart"></param>
        /// <param name="ReportSendMed"></param>
        /// <param name="RecipeVO"></param>
        /// <returns></returns>
        private clsOutpatientPrintRecipe_VO m_mthChangVo(clsReportSendMedStart_VO ReportSendMedStart, clsReportSendMed_VO[] ReportSendMed, clsOutpatientRecipe_VO RecipeVO, string tolMoney, string RecipeTotalMoney)
        {

            clsOutpatientPrintRecipe_VO vo = new clsOutpatientPrintRecipe_VO();
            ReportPrint = new com.digitalwave.iCare.middletier.HI.clsFoShanSendMedicinePrint();
            m_objTreatTipPrint = new clsFoshanTreatTipPrint();
            DataTable m_objUsageTable = null;
            vo.stroutpatrecipeMoney = RecipeVO.stroutpatrecipeMoney;
            if (this.m_objViewer.radMat.Checked == true)
            {
                vo.m_strMatCost = this.m_objViewer.CheckMoney.Text;
            }
            else
            {
                vo.m_strMatCost = "";
            }
            vo.m_strTimes = ReportSendMedStart.m_strSun;
            vo.m_strHerbalmedicineUsage = ReportSendMedStart.m_strUseNameAll;
            vo.strCheckName = ReportSendMedStart.strSendName;
            vo.strDosageName = ReportSendMedStart.strEMPName;
            vo.strMedMoney = tolMoney;
            vo.strInvoiceNO = ReportSendMedStart.strInvoiceNO;
            vo.m_strPhotoNo = ReportSendMedStart.m_strPhoto;
            vo.m_strAge = ReportSendMedStart.m_strAge;
            vo.m_strIDcardno = ReportSendMedStart.m_strIDcardno;
            vo.m_strRectype = ReportSendMedStart.m_strRectype;
            vo.strCheckOutName = ReportSendMedStart.strCheckOutName;
            vo.m_strCardID = ReportSendMedStart.m_strPatCardID;
            vo.m_strRecipePrice = RecipeTotalMoney;
            //vo.m_strRecipePrice = ReportSendMedStart.m_strTotalMoney;
            vo.m_strPatientType = ReportSendMedStart.m_strInternalCH;
            vo.m_strPrintDate = DateTime.Now.ToShortDateString();
            vo.m_strRecipeID = ReportSendMedStart.m_strOUTPATRECIPEID_CHR;
            vo.m_strSerNO = ReportSendMedStart.m_strSerNO;
            vo.m_intRecipeCount = ReportSendMedStart.m_intRecipeCount;
            #region 加
            //2008.7.07 chongkun.wu+ 生成条形码图片
            //取处方号前14位+当日流水号作为条形码号
            //
            //2009.10.23取消
            //string png = "";
            //string m_strBarCodeNo =vo.m_strRecipeID .Remove (14)+vo.m_strSerNO ;
            //Barcode.clsBarcode bcode = new Barcode.clsBarcode();
            //Barcode.clsBarcode bcodePng = new Barcode.clsBarcode();
            //bcodePng.GetBarcode(m_strBarCodeNo, out png);
            ////
            //bcode = null;
            #endregion

            #region 体重
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc svc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            vo.Weight = svc.GetPatientWeight(ReportSendMedStart.m_strID);
            svc = null;
            #endregion

            vo.m_strRecipeDate = DateTime.Parse(RecipeVO.m_strRecordDate).ToString("yyyy-MM-dd");
            vo.m_strSex = ReportSendMedStart.m_strsex;
            vo.m_strPatientName = ReportSendMedStart.m_strname;
            vo.m_strdiagnose = RecipeVO.strDIAG_VCHR;
            vo.m_strDiagDrName = RecipeVO.m_objDiagDr.strContactName;
            vo.m_strAddress = RecipeVO.strHOMEADDRESS_VCHR;
            vo.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
            vo.m_strGOVCARD = RecipeVO.m_objPatient.m_strGOVCARD_CHR;
            vo.m_strDiagDrName = RecipeVO.m_objDiagDr.strLastName;
            vo.m_strDiagDeptID = RecipeVO.m_objDiagDept.strDeptName;
            vo.m_strINSURANCEID = RecipeVO.m_objPatient.strInsuranceID;
            vo.m_strPatientType = RecipeVO.m_objPatient.objPatType.m_strPayTypeName;
            vo.objPRDArr = new System.Collections.ArrayList();
            vo.strSendMedStorage = this.m_objViewer.m_txtMedStore.Text;
            vo.m_strSendMedWindow = this.m_objViewer.m_lsvOpRecDetail.Items[0].SubItems[8].Text.Trim();
            vo.strOutpatrecipeNO = this.m_objManage.m_getOutpatientNO(ReportSendMedStart.m_strOUTPATRECIPEID_CHR, ReportSendMedStart.m_strCheckOutdate, ReportSendMedStart.m_strID);
            long lngRes = this.m_objManage.m_lngGetUsageIDByOrderID("3", out m_objUsageTable);
            if (ReportSendMedStart.strSPLIT == "1")
            {
                vo.strInvoiceNO = m_objManage.m_lngGetAllINVOICENO(vo.m_strRecipeID);
            }
            vo.objPRDArr2 = new System.Collections.ArrayList();
            vo.objPRDArr3 = new System.Collections.ArrayList();
            vo.objTreatArr = new ArrayList();

            for (int i1 = 0; i1 < ReportSendMed.Length; i1++)
            {
                if (ReportSendMed[i1].m_intPuted == 0)
                {
                    vo.m_intInjectionItemCount++;
                }
                #region 治疗单数据
                if (lngRes > 0 && m_objUsageTable != null)
                {
                    for (int j = 0; j < m_objUsageTable.Rows.Count; j++)
                    {
                        if (ReportSendMed[i1].m_strUsageID == m_objUsageTable.Rows[j]["USAGEID_CHR"].ToString().Trim())//治疗单
                        {
                            clsOutpatientPrintRecipeDetail_VO subItem = new clsOutpatientPrintRecipeDetail_VO();

                            subItem.m_strDosageUnit = ReportSendMed[i1].m_strdosageUnit;
                            subItem.m_strChargeName = ReportSendMed[i1].m_strMedName;
                            subItem.m_strMEDNORMALNAME = ReportSendMed[i1].m_strMEDNORMALNAME;
                            subItem.m_strCount = ReportSendMed[i1].m_strTotal;
                            subItem.m_strDays = ReportSendMed[i1].m_strDays;
                            subItem.m_strDosage = ReportSendMed[i1].m_strdosage;
                            subItem.m_strFrequency = ReportSendMed[i1].m_strFREQIDName;
                            subItem.m_strSpec = ReportSendMed[i1].m_strMedSpace;
                            subItem.m_strSumPrice = ReportSendMedStart.m_strTotalMoney;
                            subItem.m_strUnit = ReportSendMed[i1].m_strMedUnit;
                            subItem.m_strUsage = ReportSendMed[i1].m_strUseName;
                            subItem.m_strRowNo = ReportSendMed[i1].m_strRowNo;
                            subItem.m_strUsageDetail = ReportSendMed[i1].m_strUseNameMakeup;
                            subItem.m_strMedType = ReportSendMed[i1].m_strMedType.Trim();
                            subItem.m_strFreqDays = ReportSendMed[i1].m_strFreqDays.Trim();
                            subItem.m_strFreqTimes = ReportSendMed[i1].m_strFreqTimes.Trim();
                            subItem.m_strBasicDosage = ReportSendMed[i1].m_strBasicDosage.Trim();
                            subItem.m_strOPFreqDesc = ReportSendMed[i1].m_strOPFreqDesc.Trim();
                            subItem.m_strOPUsageDesc = ReportSendMed[i1].m_strOPUsageDesc.Trim();
                            subItem.m_strItemIPUnit_chr = ReportSendMed[i1].m_strItemIPUnit_chr.Trim();
                            vo.objTreatArr.Add(subItem);
                        }
                    }
                }
                #endregion
                if (this.m_strPrintSendMedBill.Trim() == "1")
                {
                    if (ReportSendMed[i1].m_strMedType.Trim() == "1" && ReportSendMed[i1].m_intPuted == 1)
                    {
                        clsOutpatientPrintRecipeDetail_VO subItem = new clsOutpatientPrintRecipeDetail_VO();

                        subItem.m_strDosageUnit = ReportSendMed[i1].m_strdosageUnit;
                        subItem.m_strChargeName = ReportSendMed[i1].m_strMedName;
                        subItem.m_strMEDNORMALNAME = ReportSendMed[i1].m_strMEDNORMALNAME;
                        subItem.m_strCount = ReportSendMed[i1].m_strTotal;
                        subItem.m_strDays = ReportSendMedStart.m_strSun;
                        subItem.m_strDosage = ReportSendMed[i1].m_strdosage;
                        subItem.m_strFrequency = ReportSendMed[i1].m_strFREQIDName;
                        subItem.m_strSpec = ReportSendMed[i1].m_strMedSpace;
                        subItem.m_strSumPrice = ReportSendMedStart.m_strTotalMoney;
                        subItem.m_strUnit = ReportSendMed[i1].m_strMedUnit;
                        subItem.m_strUsage = ReportSendMed[i1].m_strUseName;
                        subItem.m_strRowNo = ReportSendMed[i1].m_strRowNo;
                        subItem.m_strUsageDetail = ReportSendMed[i1].m_strUseNameMakeup;
                        subItem.m_strMedType = ReportSendMed[i1].m_strMedType.Trim();
                        subItem.m_strFreqDays = ReportSendMed[i1].m_strFreqDays.Trim();
                        subItem.m_strFreqTimes = ReportSendMed[i1].m_strFreqTimes.Trim();
                        subItem.m_strBasicDosage = ReportSendMed[i1].m_strBasicDosage.Trim();
                        subItem.m_strOPFreqDesc = ReportSendMed[i1].m_strOPFreqDesc.Trim();
                        subItem.m_strOPUsageDesc = ReportSendMed[i1].m_strOPUsageDesc.Trim();
                        subItem.m_strItemIPUnit_chr = ReportSendMed[i1].m_strItemIPUnit_chr.Trim();
                        vo.objPRDArr.Add(subItem);
                    }
                    if (ReportSendMed[i1].m_strMedType.Trim() == "2" || (ReportSendMed[i1].m_strMedType.Trim() == "1" && ReportSendMed[i1].m_intPuted == 1))
                    {
                        clsOutpatientPrintRecipeDetail_VO subItem = new clsOutpatientPrintRecipeDetail_VO();
                        subItem.m_strDosageUnit = ReportSendMed[i1].m_strdosageUnit;
                        subItem.m_strChargeName = ReportSendMed[i1].m_strMedName;
                        subItem.m_strMEDNORMALNAME = ReportSendMed[i1].m_strMEDNORMALNAME;
                        subItem.m_strCount = ReportSendMed[i1].m_strTotal;
                        subItem.m_strDays = ReportSendMedStart.m_strSun;
                        subItem.m_strDosage = ReportSendMed[i1].m_strdosage;
                        subItem.m_strFrequency = ReportSendMed[i1].m_strFREQIDName;
                        subItem.m_strSpec = ReportSendMed[i1].m_strMedSpace;
                        subItem.m_strSumPrice = ReportSendMedStart.m_strTotalMoney;
                        subItem.m_strUnit = ReportSendMed[i1].m_strMedUnit;
                        subItem.m_strUsage = ReportSendMed[i1].m_strUseName;
                        subItem.m_strRowNo = ReportSendMed[i1].m_strRowNo;
                        subItem.m_strUsageDetail = ReportSendMed[i1].m_strUseNameMakeup;
                        subItem.m_strMedType = ReportSendMed[i1].m_strMedType.Trim();
                        subItem.m_strFreqDays = ReportSendMed[i1].m_strFreqDays.Trim();
                        subItem.m_strFreqTimes = ReportSendMed[i1].m_strFreqTimes.Trim();
                        subItem.m_strBasicDosage = ReportSendMed[i1].m_strBasicDosage.Trim();
                        subItem.m_strOPFreqDesc = ReportSendMed[i1].m_strOPFreqDesc.Trim();
                        subItem.m_strOPUsageDesc = ReportSendMed[i1].m_strOPUsageDesc.Trim();
                        subItem.m_strItemIPUnit_chr = ReportSendMed[i1].m_strItemIPUnit_chr.Trim();
                        subItem.m_intPuted = ReportSendMed[i1].m_intPuted;
                        vo.objPRDArr3.Add(subItem);
                    }

                }
                else
                {
                    if (ReportSendMed[i1].m_strMedType.Trim() == "1")
                    {
                        clsOutpatientPrintRecipeDetail_VO subItem = new clsOutpatientPrintRecipeDetail_VO();

                        subItem.m_strDosageUnit = ReportSendMed[i1].m_strdosageUnit;
                        subItem.m_strChargeName = ReportSendMed[i1].m_strMedName;
                        subItem.m_strMEDNORMALNAME = ReportSendMed[i1].m_strMEDNORMALNAME;
                        subItem.m_strCount = ReportSendMed[i1].m_strTotal;
                        subItem.m_strDays = ReportSendMedStart.m_strSun;
                        subItem.m_strDosage = ReportSendMed[i1].m_strdosage;
                        subItem.m_strFrequency = ReportSendMed[i1].m_strFREQIDName;
                        subItem.m_strSpec = ReportSendMed[i1].m_strMedSpace;
                        subItem.m_strSumPrice = ReportSendMedStart.m_strTotalMoney;
                        subItem.m_strUnit = ReportSendMed[i1].m_strMedUnit;
                        subItem.m_strUsage = ReportSendMed[i1].m_strUseName;
                        subItem.m_strRowNo = ReportSendMed[i1].m_strRowNo;
                        subItem.m_strUsageDetail = ReportSendMed[i1].m_strUseNameMakeup;
                        subItem.m_strMedType = ReportSendMed[i1].m_strMedType.Trim();
                        subItem.m_strFreqDays = ReportSendMed[i1].m_strFreqDays.Trim();
                        subItem.m_strFreqTimes = ReportSendMed[i1].m_strFreqTimes.Trim();
                        subItem.m_strBasicDosage = ReportSendMed[i1].m_strBasicDosage.Trim();
                        subItem.m_strOPFreqDesc = ReportSendMed[i1].m_strOPFreqDesc.Trim();
                        subItem.m_strOPUsageDesc = ReportSendMed[i1].m_strOPUsageDesc.Trim();
                        subItem.m_strItemIPUnit_chr = ReportSendMed[i1].m_strItemIPUnit_chr.Trim();
                        vo.objPRDArr.Add(subItem);
                    }
                    if (ReportSendMed[i1].m_strMedType.Trim() == "2" || ReportSendMed[i1].m_strMedType.Trim() == "1")
                    {
                        clsOutpatientPrintRecipeDetail_VO subItem = new clsOutpatientPrintRecipeDetail_VO();
                        subItem.m_strDosageUnit = ReportSendMed[i1].m_strdosageUnit;
                        subItem.m_strChargeName = ReportSendMed[i1].m_strMedName;
                        subItem.m_strMEDNORMALNAME = ReportSendMed[i1].m_strMEDNORMALNAME;
                        subItem.m_strCount = ReportSendMed[i1].m_strTotal;
                        subItem.m_strDays = ReportSendMedStart.m_strSun;
                        subItem.m_strDosage = ReportSendMed[i1].m_strdosage;
                        subItem.m_strFrequency = ReportSendMed[i1].m_strFREQIDName;
                        subItem.m_strSpec = ReportSendMed[i1].m_strMedSpace;
                        subItem.m_strSumPrice = ReportSendMedStart.m_strTotalMoney;
                        subItem.m_strUnit = ReportSendMed[i1].m_strMedUnit;
                        subItem.m_strUsage = ReportSendMed[i1].m_strUseName;
                        subItem.m_strRowNo = ReportSendMed[i1].m_strRowNo;
                        subItem.m_strUsageDetail = ReportSendMed[i1].m_strUseNameMakeup;
                        subItem.m_strMedType = ReportSendMed[i1].m_strMedType.Trim();
                        subItem.m_strFreqDays = ReportSendMed[i1].m_strFreqDays.Trim();
                        subItem.m_strFreqTimes = ReportSendMed[i1].m_strFreqTimes.Trim();
                        subItem.m_strBasicDosage = ReportSendMed[i1].m_strBasicDosage.Trim();
                        subItem.m_strOPFreqDesc = ReportSendMed[i1].m_strOPFreqDesc.Trim();
                        subItem.m_strOPUsageDesc = ReportSendMed[i1].m_strOPUsageDesc.Trim();
                        subItem.m_strItemIPUnit_chr = ReportSendMed[i1].m_strItemIPUnit_chr.Trim();
                        subItem.m_intPuted = ReportSendMed[i1].m_intPuted;
                        vo.objPRDArr3.Add(subItem);
                    }
                }
                if (ReportSendMed[i1].m_strMedType.Trim() == "3")
                {
                    clsOutpatientPrintRecipeDetail_VO subItem = new clsOutpatientPrintRecipeDetail_VO();
                    subItem.m_strChargeName = ReportSendMed[i1].m_strMedName;
                    subItem.m_strCount = ReportSendMed[i1].m_strTotal;
                    subItem.m_strMEDNORMALNAME = ReportSendMed[i1].m_strMEDNORMALNAME;
                    subItem.m_strDays = ReportSendMedStart.m_strSun;
                    subItem.m_strDosage = ReportSendMed[i1].m_strdosage + ReportSendMed[i1].m_strdosageUnit;
                    subItem.m_strFrequency = ReportSendMed[i1].m_strFREQIDName;
                    subItem.m_strSpec = ReportSendMed[i1].m_strMedSpace;
                    subItem.m_strUnit = ReportSendMed[i1].m_strMedUnit;
                    subItem.m_strUsage = ReportSendMed[i1].m_strUseName;
                    subItem.m_strPrice = ReportSendMed[i1].m_strUnitprce;
                    subItem.m_strSumPrice = ReportSendMed[i1].m_strTolPrce;
                    subItem.m_strMedType = ReportSendMed[i1].m_strMedType.Trim();
                    subItem.m_strUsageDetail = ReportSendMed[i1].m_strUseNameMakeup;
                    subItem.m_strBasicDosage = ReportSendMed[i1].m_strBasicDosage.Trim();
                    subItem.m_strItemIPUnit_chr = ReportSendMed[i1].m_strItemIPUnit_chr.Trim();
                    subItem.m_strOPFreqDesc = ReportSendMed[i1].m_strOPFreqDesc.Trim();
                    subItem.m_strOPUsageDesc = ReportSendMed[i1].m_strOPUsageDesc.Trim();
                    vo.objPRDArr2.Add(subItem);
                }

            }
            return vo;


        }
        #endregion

        #region 打印所有未自动打印的发药单,治疗单,注射单、贴瓶单
        /// <summary>
        /// 打印所有未自动打印的发药单,治疗单,注射单、贴瓶单
        /// </summary>
        /// <param name="ListPrint"></param>
        /// <param name="InjectArrlist"></param>
        private void m_mthPrintAll(System.Collections.ArrayList ListPrint, ArrayList InjectArrlist, List<string> lstYdSid)
        {
            isAutoPrint = true;
            m_mthFalseOrTrue(false);
            //只打印新格式发药单
            if (this.m_blnPrintSendMedBill == true && this.m_strPrintSendMedBill.Trim() == "1")
            {
                if (ListPrint != null && ListPrint.Count > 0)
                {
                    //多用户下由于并发性，需将数据库操作放到打印前
                    m_objManage.m_lngUpdateMedRecipeListByID(this.m_objViewer.statusWindows.strWindowID, ListPrint, 0);
                    for (int i1 = 0; i1 < ListPrint.Count; i1++)
                    {
                        DataTable objItems = new DataTable();
                        DataTable dtOutPatrecipeid = new DataTable();
                        m_objManage.m_lngGetPrintItem(int.Parse(ListPrint[i1].ToString()), this.m_objViewer.statusWindows.strWindowID, out dtOutPatrecipeid, out objItems, this.m_objViewer.statusWindows.statusTone);
                        //this.m_mthDataTableToDataTable(ref objItems);
                        this.m_mthAutoPrint(dtOutPatrecipeid, objItems);
                        if (this.m_objViewer.m_strAutoPrintRecipe == "1")
                        {
                            for (int i = 0; i < dtOutPatrecipeid.Rows.Count; i++)
                            {
                                this.m_mthAutoPrintRecipe(dtOutPatrecipeid.Rows[i]["OUTPATRECIPEID_CHR"].ToString());
                                this.m_objViewer.m_printDocumentRecipe.Print();
                            }
                        }
                    }
                }
            }
            //不打印任何格式发药单
            else if (this.m_blnPrintSendMedBill == false)
            {
                if (InjectArrlist != null && InjectArrlist.Count > 0)
                {
                    //多用户下由于并非性，需将数据库操作放到打印前
                    m_objManage.m_lngUpdateRecipeSendTableByID(this.m_objViewer.statusWindows.strWindowID, InjectArrlist);
                    for (int i1 = 0; i1 < InjectArrlist.Count; i1++)
                    {
                        DataTable objItems = new DataTable();
                        DataTable dtOutPatrecipeid = new DataTable();
                        m_objManage.m_lngGetPrintItem(int.Parse(InjectArrlist[i1].ToString()), this.m_objViewer.statusWindows.strWindowID, out dtOutPatrecipeid, out objItems, this.m_objViewer.statusWindows.statusTone);
                        // this.m_mthDataTableToDataTable(ref objItems);
                        if (this.m_objViewer.checkBox3.Checked == true)
                        {
                            m_mthPrintQF(InjectArrlist[i1].ToString(), 1);
                        }
                        if (this.m_objViewer.m_chkTreatTip.Checked == true)
                        {
                            this.m_mthAutoPrintTreatTip(dtOutPatrecipeid, objItems);
                        }
                        if (this.m_objViewer.checkBox4.Checked == true)
                        {
                            m_mthGetTiepenData(dtOutPatrecipeid.Rows[0], objItems, 1);
                        }
                        //if (this.m_objViewer.m_chkMedBag.Checked == true)
                        //{
                        //    m_mthPrintYD(dtOutPatrecipeid, objItems);
                        //}
                        if (this.m_objViewer.m_chkHistory.Checked == true)
                        {

                            if (dtOutPatrecipeid.Rows.Count > 0)
                            {
                                this.m_mthAutoPrintCaseHistory(dtOutPatrecipeid.Rows[0]["OUTPATRECIPEID_CHR"].ToString());
                            }

                        }
                        if (this.m_objViewer.m_strAutoPrintRecipe == "1")
                        {
                            for (int i = 0; i < dtOutPatrecipeid.Rows.Count; i++)
                            {
                                this.m_mthAutoPrintRecipe(dtOutPatrecipeid.Rows[i]["OUTPATRECIPEID_CHR"].ToString());
                                this.m_objViewer.m_printDocumentRecipe.Print();
                            }
                        }
                    }
                }
            }
            //打印老格式发药单和其他单
            else if (this.m_strPrintSendMedBill.Trim() == "0" && this.m_blnPrintSendMedBill == true)
            {
                if (ListPrint != null && ListPrint.Count > 0)
                {
                    //多用户下由于并非性，需将数据库操作放到打印前
                    m_objManage.m_lngUpdateMedRecipeListByID(this.m_objViewer.statusWindows.strWindowID, ListPrint, 1);
                    for (int i1 = 0; i1 < ListPrint.Count; i1++)
                    {
                        DataTable dtItemDe = new DataTable();
                        DataTable dtOutPatrecipeid = new DataTable();
                        m_objManage.m_lngGetPrintItem(int.Parse(ListPrint[i1].ToString()), this.m_objViewer.statusWindows.strWindowID, out dtOutPatrecipeid, out dtItemDe, this.m_objViewer.statusWindows.statusTone);
                        //this.m_mthDataTableToDataTable(ref dtItemDe);
                        if (this.m_objViewer.checkBox2.Checked == true)
                        {
                            this.m_mthAutoPrint(dtOutPatrecipeid, dtItemDe);
                        }
                        if (this.m_objViewer.checkBox3.Checked == true)
                        {
                            m_mthPrintQF(ListPrint[i1].ToString(), 1);
                        }
                        if (this.m_objViewer.m_chkTreatTip.Checked == true)
                        {
                            this.m_mthAutoPrintTreatTip(dtOutPatrecipeid, dtItemDe);
                        }
                        if (this.m_objViewer.checkBox4.Checked == true)
                        {
                            m_mthGetTiepenData(dtOutPatrecipeid.Rows[0], dtItemDe, 1);
                        }
                        //if (this.m_objViewer.m_chkMedBag.Checked == true)
                        //{
                        //    m_mthPrintYD(dtOutPatrecipeid, objItems);
                        //}
                        if (this.m_objViewer.m_chkHistory.Checked == true)
                        {

                            if (dtOutPatrecipeid.Rows.Count > 0)
                            {
                                this.m_mthAutoPrintCaseHistory(dtOutPatrecipeid.Rows[0]["OUTPATRECIPEID_CHR"].ToString());
                            }

                        }
                        if (this.m_objViewer.m_strAutoPrintRecipe == "1")
                        {
                            for (int i = 0; i < dtOutPatrecipeid.Rows.Count; i++)
                            {
                                this.m_mthAutoPrintRecipe(dtOutPatrecipeid.Rows[i]["OUTPATRECIPEID_CHR"].ToString());
                                this.m_objViewer.m_printDocumentRecipe.Print();
                            }
                        }

                    }
                }
            }

            #region 2016.03.04 屏蔽
            /*
            if (lstYdSid != null && lstYdSid.Count > 0)
            {
                //多用户下由于并发性，需将数据库操作放到打印前
                ArrayList arr = new ArrayList();
                foreach (string sid in lstYdSid)
                {
                    arr.Add(sid);
                }
                m_objManage.m_lngUpdateMedRecipeListByID(this.m_objViewer.statusWindows.strWindowID, arr, 3);
                foreach (string sid in lstYdSid)
                {
                    DataTable dtItemDe = new DataTable();
                    DataTable dtOutPatrecipeid = new DataTable();
                    m_objManage.m_lngGetPrintItem(int.Parse(sid), this.m_objViewer.statusWindows.strWindowID, out dtOutPatrecipeid, out dtItemDe, this.m_objViewer.statusWindows.statusTone);
                    if (this.m_objViewer.m_chkMedBag.Checked == true)
                    {
                        m_mthPrintYD(dtOutPatrecipeid, dtItemDe);
                    }
                }
            } */
            #endregion

            isAutoPrint = false;
            m_mthFalseOrTrue(true);
        }
        #endregion

        private void m_mthWriteLog(string strFileName, ArrayList ErrArr)
        {
            StreamWriter objStream;
            if (!System.IO.File.Exists(strFileName))
            {
                objStream = System.IO.File.CreateText(strFileName);
            }
            else
            {
                objStream = new StreamWriter(strFileName);
            }
            if (ErrArr.Count > 0)
            {
                objStream.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "出现以下的错误!");
                for (int i1 = 0; i1 < ErrArr.Count; i1++)
                {
                    objStream.Write((string)ErrArr[i1]);
                }
            }

            objStream.Close();
        }

        #region 自动打印发药单
        /// <summary>
        /// 自动打印发药单
        /// </summary>
        /// <param name="m_objRecipeTable"></param>
        /// <param name="dtItemDe"></param>
        private void m_mthAutoPrint(DataTable m_objRecipeTable, DataTable dtItemDe)
        {
            clsReportSendMedStart_VO ReportSendMedStart = this.m_GetTitMana(m_objRecipeTable);
            clsOutpatientRecipe_VO RecipeVO = new clsOutpatientRecipe_VO();
            m_objManage.m_lngGetRepiceListBySid(m_objRecipeTable.Rows[0]["sid_int"].ToString(), out objItemsVO);
            Double meMoney = 0;
            double RecipeTotalMoney = 0;
            clsReportSendMed_VO[] ReportSendMed = m_getPrintData(dtItemDe, out meMoney, ref  ReportSendMedStart, out RecipeTotalMoney);
            clsOutpatientPrintRecipe_VO printVO = m_mthChangVo(ReportSendMedStart, ReportSendMed, objItemsVO[0], meMoney.ToString(), RecipeTotalMoney.ToString("0.00"));
            ReportPrint.PrintRecipeVOInfo = printVO;
            try
            {
                this.m_objViewer.PrintDocu.Print();
            }
            catch (Exception printEx)
            {
                MessageBox.Show(printEx.Message);
            }
        }
        #endregion
        #region 自动打印治疗单
        /// <summary>
        /// 自动打印治疗单
        /// </summary>
        /// <param name="CurrPrintRow">处方数据</param>
        /// <param name="dtItemDe">处方明细表</param>
        private void m_mthAutoPrintTreatTip(DataTable CurrPrintRow, DataTable dtItemDe)
        {
            clsReportSendMedStart_VO ReportSendMedStart = this.m_GetTitMana(CurrPrintRow);
            m_objManage.m_lngGetRepiceListBySid(CurrPrintRow.Rows[0]["sid_int"].ToString(), out objItemsVO);
            Double meMoney = 0;
            double RecipeTotalMoney = 0;
            clsReportSendMed_VO[] ReportSendMed = m_getPrintData(dtItemDe, out meMoney, ref  ReportSendMedStart, out RecipeTotalMoney);
            clsOutpatientPrintRecipe_VO printVO = m_mthChangVo(ReportSendMedStart, ReportSendMed, objItemsVO[0], meMoney.ToString(), RecipeTotalMoney.ToString("0.00"));
            this.m_objTreatTipPrint.PrintRecipeVOInfo = printVO;
            this.m_objViewer.m_pdTreatTip.Print();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        private clst_opr_nurseexecute[] m_mthGetVo(string strUser)
        {
            clst_opr_nurseexecute[] DosageArr = new clst_opr_nurseexecute[objItems.Rows.Count];
            for (int i1 = 0; i1 < objItems.Rows.Count; i1++)
            {
                DosageArr[i1] = new clst_opr_nurseexecute();
                if (intClick == 1)
                {
                    DosageArr[i1].m_intBUSINESS_INT = 6;
                    DosageArr[i1].m_intOPERATORTYPE_INT = 1;
                }
                else
                {
                    DosageArr[i1].m_intBUSINESS_INT = 7;
                    DosageArr[i1].m_intOPERATORTYPE_INT = 2;
                }
                DosageArr[i1].m_intEXECTIMES_INT = 1;
                DosageArr[i1].m_strFrom = this.m_objViewer.statusWindows.strStorageID;
                DosageArr[i1].m_intSTATUS_INT = 1;
                DosageArr[i1].m_strOPERATORID_CHR = strUser;
                DosageArr[i1].m_strTABLENAME_VCHR = objItems.Rows[i1]["FromTable"].ToString().Trim();
                DosageArr[i1].m_strITEMID_CHR = objItems.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                DosageArr[i1].m_strOUTPATRECIPEID_CHR = objItems.Rows[i1]["OUTPATRECIPEID_CHR"].ToString().Trim();
                DosageArr[i1].m_strROWNO_CHR = objItems.Rows[i1]["ROWNO_CHR"].ToString().Trim();
                DosageArr[i1].m_strWindow = this.m_objViewer.statusWindows.strWindowID;
                DosageArr[i1].m_strOUTPATRECIPETYPE = (string)this.m_objViewer.panel5.Tag;
            }
            return DosageArr;
        }


        #endregion
        #region  获取当前发药的药房出库主表vo
        /// <summary>
        /// 获取当前发药的药房出库主表vo
        /// </summary>
        /// <param name="m_strEmpID"></param>
        /// <param name="objRecipe"></param>
        /// <returns></returns>
        public clsDS_OutStorage_VO m_mthGetOutstorageVo(string m_strEmpID, clsOutpatientRecipe_VO objRecipe)
        {
            clsDS_OutStorage_VO MainVo = new clsDS_OutStorage_VO();
            MainVo.m_strMAKERID_CHR = objRecipe.m_objDiagDr.strEmpID;
            MainVo.m_strDRUGSTOREID_CHR = this.m_objViewer.statusWindows.m_strDeptid;
            MainVo.m_intFORMTYPE_INT = 1;
            MainVo.m_intSTATUS = 2;
            MainVo.m_strPatientid = objRecipe.m_objPatient.strPatientID;
            MainVo.m_datMAKEORDER_DAT = Convert.ToDateTime(objRecipe.m_strRecordDate);
            MainVo.m_datEXAM_DATE = DateTime.Now;
            MainVo.m_strEXAMID_CHR = m_strEmpID;
            return MainVo;
        }
        #endregion
        #region  扣减药房库存
        /// <summary>
        /// 扣减药房库存
        /// </summary>
        public long m_mthSubtractStorage(string m_strEmpID, clsOutpatientRecipe_VO objRecipe, ref  clsDS_StorageDetail_VO[] m_objStorageDetailVoArr, ref  clsDS_Outstorage_Detail[] m_objOutStorageDetailVoArr)
        {
            string m_strMsg = string.Empty;
            Hashtable ht = new Hashtable();
            //DataTable dtSendMedRecipeDetail = new DataTable();
            //long lngResult = this.m_objManage.m_lngGetSendMedRecipeDetailByid(Convert.ToInt32(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[5].Text), this.m_objViewer.statusWindows.m_strDeptid, out dtSendMedRecipeDetail);

            //string m_strDeptID = this.m_objViewer.statusWindows.m_strDeptid;
            //if (this.m_objSeleRow.m_strMEDSTOREID_CHR != this.m_objViewer.statusWindows.strStorageID)
            //{
            //    clsDomainControlOPMedStore objSvc = new clsDomainControlOPMedStore();
            //    DataTable dt = null;
            //    long lngRes = objSvc.m_lngGetMedStoreInfo(this.m_objSeleRow.m_strMEDSTOREID_CHR, out dt);
            //    m_strDeptID = dt.Rows[0]["deptid_chr"].ToString();
            //}
            bool m_blnHasEnoughStorage = this.m_objManage.m_lngJudgeHasEnoughStorage(this.m_objViewer.statusWindows.m_strDeptid, this.objItems, out m_strMsg, out  ht);
            if (m_blnHasEnoughStorage == false)
            {
                //this.publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, m_strMsg);
                MessageBox.Show(m_strMsg, "提示...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            List<clsPutMedicineDetailGroup> objList = new List<clsPutMedicineDetailGroup>();
            foreach (DictionaryEntry de in ht)
            {
                objList.AddRange(((clsPutMedicineDetailGroup)de.Value).m_listSubStorageDetail.ToArray());
            }
            clsDS_OutStorage_VO m_objMainVo = this.m_mthGetOutstorageVo(m_strEmpID, objRecipe);
            m_objOutStorageDetailVoArr = null;
            m_objStorageDetailVoArr = new clsDS_StorageDetail_VO[objList.Count];
            for (int m_intRow = 0; m_intRow < objList.Count; m_intRow++)
            {
                m_objStorageDetailVoArr[m_intRow] = new clsDS_StorageDetail_VO();
                m_objStorageDetailVoArr[m_intRow].m_lngSERIESID_INT = objList[m_intRow].m_lngStorageSerial;
                m_objStorageDetailVoArr[m_intRow].m_strDRUGSTOREID_CHR = this.m_objViewer.statusWindows.m_strDeptid;
                m_objStorageDetailVoArr[m_intRow].m_strMEDICINEID_CHR = objList[m_intRow].m_strMedicineid_chr;
                m_objStorageDetailVoArr[m_intRow].m_dblIPREALGROSS_INT = objList[m_intRow].m_dblIPAmount;
                m_objStorageDetailVoArr[m_intRow].m_dblOPREALGROSS_INT = objList[m_intRow].m_dblOPAmount;
                m_objStorageDetailVoArr[m_intRow].m_strOperatorid = m_strEmpID;
                m_objStorageDetailVoArr[m_intRow].m_intSubStorageType = 2;
                m_objStorageDetailVoArr[m_intRow].m_strOutPatientRecipeid = objRecipe.m_strOutpatRecipeID;

                m_objStorageDetailVoArr[m_intRow].m_dblOPCHARGEFLG_INT = objList[m_intRow].m_intIPChargeFlag;//此处是门诊单位                                

            }
            return 1;
        }
        #endregion

        #region 合理用药
        /// <summary>
        /// 合理用药
        /// </summary>
        internal void UseMedItf()
        {
            clsMedStorePatientListInfo pat = null;
            if (this.m_objViewer.tab.SelectedTab.Name == "tabPageNot")
            {
                if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count <= 0) return;
                pat = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag;
            }
            else if (this.m_objViewer.tab.SelectedTab.Name == "tabPageOk")
            {
                if (this.m_objViewer.listViewok.SelectedItems.Count <= 0) return;
                pat = (clsMedStorePatientListInfo)this.m_objViewer.listViewok.SelectedItems[0].Tag;
            }
            if (pat == null || pat.SecuLevel <= 0) return;

            Hisitf.EntityDrugUse patVo = new Hisitf.EntityDrugUse();
            Hisitf.EntityDrugUse drugVo = null;
            System.Collections.Generic.List<Hisitf.EntityDrugUse> lstDrug = new System.Collections.Generic.List<Hisitf.EntityDrugUse>();

            if (objRecipeMain != null && objRecipeMain.Length > 0 && dtRecipeDetail != null && dtRecipeDetail.Rows.Count > 0)
            {
                #region patInfo

                string recipeId = dtRecipeDetail.Rows[0]["outpatrecipeid_chr"].ToString();
                clsOutpatientRecipe_VO mainVo = null;
                foreach (clsOutpatientRecipe_VO item in objRecipeMain)
                {
                    if (item.m_strOutpatRecipeID == recipeId)
                    {
                        mainVo = item;
                        break;
                    }
                }
                patVo.departID = mainVo.m_objDiagDept.strDeptID;
                patVo.department = mainVo.m_objDiagDept.strDeptName;
                patVo.presType = string.Empty;
                patVo.presSource = "门诊";
                patVo.presDatetime = Convert.ToDateTime(mainVo.m_strRecordDate).ToString("yyyy-MM-dd HH:mm:ss");
                patVo.payType = mainVo.m_objPatient.objPatType.m_strPayTypeName;
                patVo.patientNo = mainVo.m_objPatient.strPatientCardID;
                patVo.presNo = recipeId;
                patVo.name = mainVo.m_objPatient.strName;
                patVo.diagnose = mainVo.strDIAG_VCHR;
                patVo.address = mainVo.strHOMEADDRESS_VCHR;
                patVo.IDCard = mainVo.strIDcard;
                patVo.phoneNo = mainVo.HOMEPHONE_VCHR;
                patVo.age = (mainVo.dtmAge == null ? "" : com.digitalwave.controls.clsArithmetic.CalcAge(mainVo.dtmAge.Value));
                patVo.sex = mainVo.strSex;
                patVo.allergyList = string.Empty;
                patVo.docID = mainVo.m_objDiagDr.strEmpID;
                patVo.docName = mainVo.m_objDiagDr.strLastName;
                patVo.docTitle = string.Empty;
                patVo.totalAmount = mainVo.stroutpatrecipeMoney;
                patVo.drugSensivity = "false";      // 菌检
                patVo.pharmChkId = string.Empty;    // strUser;
                patVo.pharmChkName = string.Empty;  // strUserName;

                #endregion

                #region use drug
                foreach (DataRow dr in dtRecipeDetail.Rows)
                {
                    drugVo = new Hisitf.EntityDrugUse();
                    drugVo.drug = dr["itemid_chr"].ToString();
                    drugVo.drugName = dr["itemname_vchr"].ToString();
                    drugVo.specification = dr["itemspec_vchr"].ToString();
                    drugVo.package = dr["packqty_dec"].ToString();
                    drugVo.quantity = dr["qty_dec"].ToString();
                    drugVo.packUnit = dr["unitid_chr"].ToString();
                    drugVo.unitPrice = dr["price_mny"].ToString();
                    drugVo.amount = dr["tolprice_mny"].ToString();
                    drugVo.groupNo = dr["rowno_chr"].ToString();
                    drugVo.firstUse = "false";   // ?
                    drugVo.prepForm = "";   // 剂型?
                    drugVo.adminRoute = dr["usagename_vchr"].ToString();
                    drugVo.adminFrequency = dr["freqname_chr"].ToString();
                    drugVo.adminDose = dr["dosageqty"].ToString() + dr["dosageunit_chr"].ToString();  // +单位? 

                    lstDrug.Add(drugVo);
                }
                #endregion
            }

            // 合理用药接口
            if (lstDrug.Count > 0 && this.IsUseMedItf)
            {
                using (Hisitf.RationalDrugUseItf itf = new Hisitf.RationalDrugUseItf())
                {
                    itf.CheckDrugUse(2, this.DrugServiceUrl, patVo, lstDrug);
                    this.m_objViewer.m_lsvPatientDetial.Select();
                }
            }
        }
        #endregion

        #region 配药处理
        /// <summary>
        ///配药处理 
        /// </summary>
        /// <returns></returns>
        public void m_mthDosageData(string strUser, string strUserName)
        {
            if (this.m_objViewer.m_lsvMedicineDetail.Items.Count == 0 && this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
            {
                long lngRes = m_objManage.m_lngSetNullityData(objRecipe.m_strOutpatRecipeID);
                if (lngRes == 1)
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "空处方！系统己进行无效处理请与系统管理员联系！");
                    ClearDe();
                    if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0)
                    {
                        m_objViewer.m_lsvPatientDetial.Items.RemoveAt(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index);
                    }
                    if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                    {
                        m_mthSelPatientRow(0);
                        this.m_objViewer.m_lsvPatientDetial.Items[0].Selected = true;
                        this.m_objViewer.m_lsvPatientDetial.Items[0].Focused = true;
                    }
                    m_mthCount();
                }
            }
            else
            {
                if (this.m_objViewer.m_lsvPatientDetial.SelectedItems.Count <= 0) return;
                clst_opr_nurseexecute[] DosageArr = m_mthGetVo(strUser);
                //try
                //{
                long lngRes = -1;
                string m_strPstatus = string.Empty;
                int m_intSid = int.Parse(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[4].Text.ToString());
                lngRes = m_objManage.m_lngGetRecipeSendStatusBySid(m_intSid, out m_strPstatus);
                if (lngRes > 0 && m_strPstatus == "1")
                {
                    clsDS_Outstorage_Detail[] m_objOutStorageDetailVoArr = null;
                    clsDS_StorageDetail_VO[] m_objStorageDetailVoArr = null;
                    if (this.m_objViewer.m_strSecondLevelMode == "1" && this.m_objViewer.m_strSubtractMode == "0")
                    {
                        long lngTemp = this.m_mthSubtractStorage(strUser, objRecipe, ref m_objStorageDetailVoArr, ref m_objOutStorageDetailVoArr);
                        if (lngTemp == -1)
                            return;
                        //MessageBox.Show("准备扣库存了...", "注意...");
                    }

                    string m_strStorageID = "";
                    if (this.m_objSeleRow.m_strMEDSTOREID_CHR != this.m_objViewer.statusWindows.strStorageID && this.m_objViewer.m_strSubtractMode == "0")
                    {
                        m_strStorageID = this.m_objViewer.statusWindows.strStorageID;
                    }

                    lngRes = m_objManage.m_lngDosage(DosageArr, this.m_objViewer.statusWindows.strWindowID,
                        ((clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag).m_strSENDWINDOWID,
                        m_intSid, m_objStorageDetailVoArr, ref m_objOutStorageDetailVoArr,
                        this.m_objViewer.m_strSubtractMode, this.m_objViewer.m_strSecondLevelMode, m_strStorageID);

                    // 打药袋
                    if (lngRes > 0 && this.m_objViewer.m_chkMedBag.Checked)
                    {
                        if (this.m_objViewer.isSeleItem())
                        {
                            this.m_mthPrintYD(true);
                        }
                    }

                    //自动叫号
                    m_lngUpdateRecipeSendCalledFlag(m_intSid, 0);
                }
                else
                {
                    if (m_strPstatus == "2")
                        publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "该病人已经配药，不能再进行配药！");
                    else if (m_strPstatus == "3")
                        publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "该病人已经发药，不能再进行配药！");

                    else if (m_strPstatus == "-1")
                        publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "该病人已经退药，不能再进行配药！");
                    return;
                }
                //  long lngRes = m_objManage.m_lngDosage(DosageArr, this.m_objViewer.statusWindows.strWindowID, barbarismStorageID, int.Parse(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[4].Text.ToString()));
                if (lngRes == 1)
                {
                    clsMedStorePatientListInfo newRow;
                    newRow = (clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.Items[this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index].Tag;

                    // 添加LED待上屏信息
                    ListViewItem lvItem = new ListViewItem("待上屏");
                    lvItem.SubItems.Add(newRow.m_strNAME_VCHR);
                    lvItem.SubItems.Add(newRow.m_strSID_INT);
                    lvItem.SubItems.Add(newRow.m_strPATIENTCARDID_CHR);
                    lvItem.Tag = newRow.m_strSID_INT;
                    this.m_objViewer.lvLED.Items.Add(lvItem);

                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "已成功配药！");
                    ClearDe();
                    newRow.m_datTREATDATE_DAT = DateTime.Now;
                    newRow.m_strPSTATUS_INT = "2";
                    newRow.m_strLASTNAME_VCHR = strUserName;
                    m_mthFillListView(newRow);
                    int m_intCurrentIndex = this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index;
                    if (m_intCurrentIndex == this.m_objViewer.m_lsvPatientDetial.Items.Count - 1)
                    {
                        m_intCurrentIndex--;
                    }
                    m_objViewer.m_lsvPatientDetial.Items.RemoveAt(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Index);
                    if (this.m_objViewer.m_lsvPatientDetial.Items.Count > 0)
                    {
                        m_mthSelPatientRow(0);

                        //m_mthSelPatientRow(m_intCurrentIndex);
                        //this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Selected = false;
                        //this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Focused = true;
                        //this.m_objViewer.m_lsvPatientDetial.Items[m_intCurrentIndex].Focused = false;
                    }
                    m_mthCount();
                }
                else
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "配药失败，请从新配药！");
                }
                //}
                //catch (System.Exception ex)
                //{
                //    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "配药失败！" + ex.ToString());
                //}
            }
        }
        #endregion

        #region 打印初始化(佛二)
        /// <summary>
        /// 打印初始化(佛二)
        /// </summary>
        public void m_ResetPage()
        {
            if (isAutoPrint == true)
                return;

            clsReportSendMedStart_VO ReportSendMedStart = this.m_GetTitMana(this.m_objSeleRow);
            if (m_objViewer.m_lsvOpRecDetail.Items.Count <= 0)
                return;
            clsOutpatientRecipe_VO RecipeVO = (clsOutpatientRecipe_VO)m_objViewer.m_lsvOpRecDetail.Items[0].Tag;
            Double deMoney = 0;
            double RecipeTotalMoney = 0;
            clsReportSendMed_VO[] ReportSendMed = m_getPrintData(objItems, out deMoney, ref ReportSendMedStart, out RecipeTotalMoney);
            clsOutpatientPrintRecipe_VO vo = m_mthChangVo(ReportSendMedStart, ReportSendMed, RecipeVO, deMoney.ToString(), RecipeTotalMoney.ToString("0.00"));
            if (this.m_objViewer.tab.SelectedIndex == 0)
            {
                if ((string)this.m_objViewer.btnPrint.Tag == "1")
                    vo.strRepeat = "重打";
                else
                    vo.strRepeat = "";
            }
            else
            {
                vo.strRepeat = "重打";
            }
            ReportPrint.PrintRecipeVOInfo = vo;
            m_objTreatTipPrint.PrintRecipeVOInfo = vo;
        }

        #endregion
        #region
        public void m_mthAutoPrintCaseHistory(string m_strOutpatientID)
        {
            m_objPrintCaseHistory = null;
            if (m_strOutpatientID.Trim() != string.Empty)
            {

                DataTable m_objTempTable;
                clsDomainControlMedStore m_objDomain = new clsDomainControlMedStore();
                long lngRes = -1;
                lngRes = m_objDomain.m_lngGetCaseHistoryByID(m_strOutpatientID, out m_objTempTable);
                if (lngRes > 0 && m_objTempTable.Rows.Count > 0)
                {
                    m_objCaseHisVo = new clsOutpatientPrintCaseHis_VO();
                    if (m_objTempTable.Rows[0]["BIRTH_DAT"] != DBNull.Value)
                    {
                        m_objCaseHisVo.m_strAge = clsConvertDateTime.CalcAge(Convert.ToDateTime(m_objTempTable.Rows[0]["BIRTH_DAT"]));
                    }
                    m_objCaseHisVo.m_strCardID = m_objTempTable.Rows[0]["PATIENTCARDID_CHR"].ToString();
                    m_objCaseHisVo.m_strDiagDeptID = m_objTempTable.Rows[0]["DEPTNAME_VCHR"].ToString();
                    m_objCaseHisVo.m_strDiagDrName = m_objTempTable.Rows[0]["LASTNAME_VCHR"].ToString();
                    m_objCaseHisVo.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
                    m_objCaseHisVo.m_strPatientName = m_objTempTable.Rows[0]["PATIENTNAME"].ToString();
                    m_objCaseHisVo.m_strPRIHIS_VCHR = m_objTempTable.Rows[0]["PRIHIS_VCHR"].ToString();
                    m_objCaseHisVo.m_strPrintDate = Convert.ToDateTime(m_objTempTable.Rows[0]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd");
                    m_objCaseHisVo.m_strRecipeID = m_objTempTable.Rows[0]["CASEHISID_CHR"].ToString();
                    m_objCaseHisVo.m_strRecordEmpID = m_objTempTable.Rows[0]["RECORDEMP_CHR"].ToString();
                    m_objCaseHisVo.m_strRegisterID = m_objTempTable.Rows[0]["REGISTERID_CHR"].ToString();
                    m_objCaseHisVo.m_strSex = m_objTempTable.Rows[0]["SEX_CHR"].ToString();
                    if (m_objTempTable.Rows[0]["SIGN_GRP"] != DBNull.Value)
                    {
                        MemoryStream m_objMS = new MemoryStream((byte[])m_objTempTable.Rows[0]["SIGN_GRP"]);
                        m_objCaseHisVo.objDocImage = new Bitmap(m_objMS);
                    }
                    m_objCaseHisVo.strAidCheck = m_objTempTable.Rows[0]["AIDCHECK_VCHR"].ToString();
                    m_objCaseHisVo.strAnaPhyLaXis = m_objTempTable.Rows[0]["ANAPHYLAXIS_VCHR"].ToString();
                    m_objCaseHisVo.strChangeDeparement = m_objTempTable.Rows[0]["CALDEPT_VCHR"].ToString();
                    m_objCaseHisVo.strDiag = m_objTempTable.Rows[0]["DIAG_VCHR"].ToString();
                    m_objCaseHisVo.strDiagCurr = m_objTempTable.Rows[0]["DIAGCURR_VCHR"].ToString();
                    m_objCaseHisVo.strDiagHis = m_objTempTable.Rows[0]["DIAGHIS_VCHR"].ToString();
                    m_objCaseHisVo.strDiagMain = m_objTempTable.Rows[0]["DIAGMAIN_VCHR"].ToString();
                    m_objCaseHisVo.strExamineResult = m_objTempTable.Rows[0]["BODYCHECK_VCHR"].ToString();
                    m_objCaseHisVo.strParentID = m_objTempTable.Rows[0]["PARCASEHISID_CHR"].ToString();
                    m_objCaseHisVo.strReMark = m_objTempTable.Rows[0]["REMARK_VCHR"].ToString();
                    m_objCaseHisVo.strTreatMent = m_objTempTable.Rows[0]["TREATMENT_VCHR"].ToString();
                    DataTable m_objTableTable;
                    m_objCaseHisVo.objItemArr = new ArrayList();
                    m_objCaseHisVo.objItemArr2 = new ArrayList();
                    lngRes = m_objDomain.m_lngGetItemsInformationByID(m_objCaseHisVo.m_strRecipeID, out m_objTableTable);
                    if (lngRes > 0 && m_objTableTable.Rows.Count > 0)
                    {
                        clsOutpatientPrintRecipeDetail_VO m_objTempVo;
                        for (int i = 0; i < m_objTableTable.Rows.Count; i++)
                        {
                            if (m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatientpwmrecipede" || m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatientcmrecipede" || m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatientopsrecipede")
                            {
                                m_objTempVo = new clsOutpatientPrintRecipeDetail_VO();
                                m_objTempVo.m_strChargeName = m_objTableTable.Rows[i]["ITEMNAME"].ToString();
                                m_objTempVo.m_strDays = m_objTableTable.Rows[i]["DAYS_INT"].ToString();
                                m_objTempVo.m_strCount = m_objTableTable.Rows[i]["QUANTITY"].ToString() + m_objTableTable.Rows[i]["UNIT"].ToString();
                                m_objTempVo.m_strUsage = m_objTableTable.Rows[i]["USAGENAME_VCHR"].ToString();
                                m_objTempVo.m_strFrequency = m_objTableTable.Rows[i]["FREQNAME_CHR"].ToString();
                                m_objTempVo.m_strDays = m_objTableTable.Rows[i]["DAYS_INT"].ToString();
                                m_objTempVo.m_strRowNo = m_objTableTable.Rows[i]["ROWNO_CHR"].ToString();
                                m_objTempVo.m_strSpec = m_objTableTable.Rows[i]["DEC"].ToString();
                                m_objTempVo.m_strDosage = m_objTableTable.Rows[i]["QTY_DEC"].ToString() + m_objTableTable.Rows[i]["DOSAGEUNIT_CHR"].ToString();
                                m_objCaseHisVo.objItemArr.Add(m_objTempVo);
                            }
                            else if (m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatienttestrecipede" || m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatientchkrecipede")
                            {
                                m_objTempVo = new clsOutpatientPrintRecipeDetail_VO();
                                m_objTempVo.m_strChargeName = m_objTableTable.Rows[i]["ITEMNAME"].ToString();
                                m_objTempVo.m_strDays = m_objTableTable.Rows[i]["DAYS_INT"].ToString();
                                m_objTempVo.m_strCount = m_objTableTable.Rows[i]["QUANTITY"].ToString() + m_objTableTable.Rows[i]["UNIT"].ToString();
                                m_objTempVo.m_strUsage = m_objTableTable.Rows[i]["USAGENAME_VCHR"].ToString();
                                m_objTempVo.m_strFrequency = m_objTableTable.Rows[i]["FREQNAME_CHR"].ToString();
                                m_objTempVo.m_strDays = m_objTableTable.Rows[i]["DAYS_INT"].ToString();
                                m_objTempVo.m_strRowNo = m_objTableTable.Rows[i]["ROWNO_CHR"].ToString();
                                m_objTempVo.m_strSpec = m_objTableTable.Rows[i]["DEC"].ToString();
                                m_objTempVo.m_strDosage = m_objTableTable.Rows[i]["QTY_DEC"].ToString() + m_objTableTable.Rows[i]["DOSAGEUNIT_CHR"].ToString();
                                m_objCaseHisVo.objItemArr2.Add(m_objTempVo);
                            }
                        }
                    }
                    m_objPrintCaseHistory = new clsPrintCaseHistory(m_objCaseHisVo);
                    this.m_objViewer.m_objPDHistoryCase.Print();

                }
            }
        }
        private clsOutpatientPrintCaseHis_VO m_objCaseHisVo;
        public void m_mthBeginPrintCaseHistory(System.Drawing.Printing.PrintEventArgs e)
        {
            if (isAutoPrint == true)
                return;
            if (this.m_objViewer.m_lsvOpRecDetail.Items.Count > 0)
            {
                string m_strRecipeID = "";
                m_strRecipeID = this.m_objViewer.m_lsvOpRecDetail.SelectedItems[0].Text.ToString().Trim();
                DataTable m_objTempTable;
                clsDomainControlMedStore m_objDomain = new clsDomainControlMedStore();
                long lngRes = -1;
                lngRes = m_objDomain.m_lngGetCaseHistoryByID(m_strRecipeID, out m_objTempTable);
                if (lngRes > 0 && m_objTempTable.Rows.Count > 0)
                {
                    m_objCaseHisVo = new clsOutpatientPrintCaseHis_VO();
                    if (m_objTempTable.Rows[0]["BIRTH_DAT"] != DBNull.Value)
                    {
                        m_objCaseHisVo.m_strAge = clsConvertDateTime.CalcAge(Convert.ToDateTime(m_objTempTable.Rows[0]["BIRTH_DAT"]));
                    }
                    m_objCaseHisVo.m_strCardID = m_objTempTable.Rows[0]["PATIENTCARDID_CHR"].ToString();
                    m_objCaseHisVo.m_strDiagDeptID = m_objTempTable.Rows[0]["DEPTNAME_VCHR"].ToString();
                    m_objCaseHisVo.m_strDiagDrName = m_objTempTable.Rows[0]["LASTNAME_VCHR"].ToString();
                    m_objCaseHisVo.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
                    m_objCaseHisVo.m_strPatientName = m_objTempTable.Rows[0]["PATIENTNAME"].ToString();
                    m_objCaseHisVo.m_strPRIHIS_VCHR = m_objTempTable.Rows[0]["PRIHIS_VCHR"].ToString();
                    m_objCaseHisVo.m_strPrintDate = Convert.ToDateTime(m_objTempTable.Rows[0]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd");
                    m_objCaseHisVo.m_strRecipeID = m_objTempTable.Rows[0]["CASEHISID_CHR"].ToString();
                    m_objCaseHisVo.m_strRecordEmpID = m_objTempTable.Rows[0]["RECORDEMP_CHR"].ToString();
                    m_objCaseHisVo.m_strRegisterID = m_objTempTable.Rows[0]["REGISTERID_CHR"].ToString();
                    m_objCaseHisVo.m_strSex = m_objTempTable.Rows[0]["SEX_CHR"].ToString();
                    if (m_objTempTable.Rows[0]["SIGN_GRP"] != DBNull.Value)
                    {
                        MemoryStream m_objMS = new MemoryStream((byte[])m_objTempTable.Rows[0]["SIGN_GRP"]);
                        m_objCaseHisVo.objDocImage = new Bitmap(m_objMS);
                    }
                    m_objCaseHisVo.strAidCheck = m_objTempTable.Rows[0]["AIDCHECK_VCHR"].ToString();
                    m_objCaseHisVo.strAnaPhyLaXis = m_objTempTable.Rows[0]["ANAPHYLAXIS_VCHR"].ToString();
                    m_objCaseHisVo.strChangeDeparement = m_objTempTable.Rows[0]["CALDEPT_VCHR"].ToString();
                    m_objCaseHisVo.strDiag = m_objTempTable.Rows[0]["DIAG_VCHR"].ToString();
                    m_objCaseHisVo.strDiagCurr = m_objTempTable.Rows[0]["DIAGCURR_VCHR"].ToString();
                    m_objCaseHisVo.strDiagHis = m_objTempTable.Rows[0]["DIAGHIS_VCHR"].ToString();
                    m_objCaseHisVo.strDiagMain = m_objTempTable.Rows[0]["DIAGMAIN_VCHR"].ToString();
                    m_objCaseHisVo.strExamineResult = m_objTempTable.Rows[0]["BODYCHECK_VCHR"].ToString();
                    m_objCaseHisVo.strParentID = m_objTempTable.Rows[0]["PARCASEHISID_CHR"].ToString();
                    m_objCaseHisVo.strReMark = m_objTempTable.Rows[0]["REMARK_VCHR"].ToString();
                    m_objCaseHisVo.strTreatMent = m_objTempTable.Rows[0]["TREATMENT_VCHR"].ToString();
                    DataTable m_objTableTable;
                    m_objCaseHisVo.objItemArr = new ArrayList();
                    m_objCaseHisVo.objItemArr2 = new ArrayList();
                    lngRes = m_objDomain.m_lngGetItemsInformationByID(m_objCaseHisVo.m_strRecipeID, out m_objTableTable);
                    if (lngRes > 0 && m_objTableTable.Rows.Count > 0)
                    {
                        clsOutpatientPrintRecipeDetail_VO m_objTempVo;
                        for (int i = 0; i < m_objTableTable.Rows.Count; i++)
                        {
                            if (m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatientpwmrecipede" || m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatientcmrecipede" || m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatientopsrecipede")
                            {
                                m_objTempVo = new clsOutpatientPrintRecipeDetail_VO();
                                m_objTempVo.m_strChargeName = m_objTableTable.Rows[i]["ITEMNAME"].ToString();
                                m_objTempVo.m_strDays = m_objTableTable.Rows[i]["DAYS_INT"].ToString();
                                m_objTempVo.m_strCount = m_objTableTable.Rows[i]["QUANTITY"].ToString() + m_objTableTable.Rows[i]["UNIT"].ToString();
                                m_objTempVo.m_strUsage = m_objTableTable.Rows[i]["USAGENAME_VCHR"].ToString();
                                m_objTempVo.m_strFrequency = m_objTableTable.Rows[i]["FREQNAME_CHR"].ToString();
                                m_objTempVo.m_strDays = m_objTableTable.Rows[i]["DAYS_INT"].ToString();
                                m_objTempVo.m_strRowNo = m_objTableTable.Rows[i]["ROWNO_CHR"].ToString();
                                m_objTempVo.m_strSpec = m_objTableTable.Rows[i]["DEC"].ToString();
                                m_objTempVo.m_strDosage = m_objTableTable.Rows[i]["QTY_DEC"].ToString() + m_objTableTable.Rows[i]["DOSAGEUNIT_CHR"].ToString();
                                m_objCaseHisVo.objItemArr.Add(m_objTempVo);
                            }
                            else if (m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatienttestrecipede" || m_objTableTable.Rows[i]["FROMTABLE"].ToString().Trim() == "t_tmp_outpatientchkrecipede")
                            {
                                m_objTempVo = new clsOutpatientPrintRecipeDetail_VO();
                                m_objTempVo.m_strChargeName = m_objTableTable.Rows[i]["ITEMNAME"].ToString();
                                m_objTempVo.m_strDays = m_objTableTable.Rows[i]["DAYS_INT"].ToString();
                                m_objTempVo.m_strCount = m_objTableTable.Rows[i]["QUANTITY"].ToString() + m_objTableTable.Rows[i]["UNIT"].ToString();
                                m_objTempVo.m_strUsage = m_objTableTable.Rows[i]["USAGENAME_VCHR"].ToString();
                                m_objTempVo.m_strFrequency = m_objTableTable.Rows[i]["FREQNAME_CHR"].ToString();
                                m_objTempVo.m_strDays = m_objTableTable.Rows[i]["DAYS_INT"].ToString();
                                m_objTempVo.m_strRowNo = m_objTableTable.Rows[i]["ROWNO_CHR"].ToString();
                                m_objTempVo.m_strSpec = m_objTableTable.Rows[i]["DEC"].ToString();
                                m_objTempVo.m_strDosage = m_objTableTable.Rows[i]["QTY_DEC"].ToString() + m_objTableTable.Rows[i]["DOSAGEUNIT_CHR"].ToString();
                                m_objCaseHisVo.objItemArr2.Add(m_objTempVo);
                            }
                        }
                    }
                    m_objPrintCaseHistory = new clsPrintCaseHistory(m_objCaseHisVo);
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }
        #endregion
        #region
        public void m_mthPrintCaseHistory(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (m_objPrintCaseHistory != null)
            {
                m_objPrintCaseHistory.m_mthBegionPrint(e);
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }
        #endregion
        #region 打印功能
        clsReportSendMed_VO[] ReportSendMed1 = new clsReportSendMed_VO[0];
        com.digitalwave.iCare.middletier.HI.clsFoShanSendMedicinePrint ReportPrint = null;
        internal com.digitalwave.iCare.middletier.HI.clsFoshanTreatTipPrint m_objTreatTipPrint = null;
        com.digitalwave.iCare.middletier.HI.clsContorlReportPrint ReportPrint1 = null;
        com.digitalwave.iCare.middletier.HI.clsPrintCaseHistory m_objPrintCaseHistory = null;
        System.Drawing.Printing.PrintPageEventArgs ex = null;
        public void m_lngPrintClick(System.Drawing.Printing.PrintPageEventArgs e)
        {
            ex = e;

            ReportPrint.DrawObject = e;
            ReportPrint.m_mthBegionPrint(this.m_strPrintSendMedBill.Trim());
        }
        /// <summary>
        /// 开始打印治疗单
        /// </summary>
        /// <param name="e"></param>
        public void m_mthPrintTreatTip(System.Drawing.Printing.PrintPageEventArgs e)
        {

            m_objTreatTipPrint.DrawObject = e;
            m_objTreatTipPrint.m_mthBeginPrint();

        }
        #region 佛二发药打印
        private void m_lngPrintFS(System.Drawing.Printing.PrintPageEventArgs e, DataTable objItems)
        {
            string Name = this.m_objComInfo.m_strGetHospitalTitle() + "发药单";
            float x1 = 100.0F;
            float x2 = 700.0F;
            float width = 100;
            float height = 100;
            Pen blackPen = new Pen(Color.Black, 1);
            blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            System.Drawing.Font TextFont = new Font("宋体", 10);//文字使用的字体
            SizeF szPerWord = e.Graphics.MeasureString("三", TextFont);//获取一个字符的宽度
            System.Drawing.Font DigFont = new Font("宋体", 16);
            System.Drawing.Font LFont = new Font("宋体", 1);
            int RowHight = 15;
            int StartRow = 18;
            e.Graphics.DrawString(Name, DigFont, Brushes.Black, 230, StartRow);
            StartRow += RowHight + 25;
            e.Graphics.DrawLine(blackPen, x1, StartRow, x2, StartRow);
            StartRow += RowHight - 5;
            e.Graphics.DrawString("就诊卡号：", TextFont, Brushes.Black, width, StartRow);
            DataRow seleRow = dtbResult.NewRow();
            if (this.m_objViewer.tab.SelectedIndex == 0)
                seleRow = (DataRow)this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag;
            else
                seleRow = (DataRow)this.m_objViewer.listViewok.SelectedItems[0].Tag;
            width += szPerWord.Width * 5;
            e.Graphics.DrawString(seleRow["PATIENTCARDID_CHR"].ToString().Trim(), TextFont, Brushes.Black, width, StartRow);
            width += (szPerWord.Width + 3) * 5;
            e.Graphics.DrawString("姓名：", TextFont, Brushes.Black, width, StartRow);
            width += szPerWord.Width * 3;
            e.Graphics.DrawString(seleRow["name_vchr"].ToString().Trim(), TextFont, Brushes.Black, width, StartRow);
            width += (szPerWord.Width + 1) * 3;
            e.Graphics.DrawString("医生：", TextFont, Brushes.Black, width, StartRow);
            width += (szPerWord.Width) * 3;
            e.Graphics.DrawString(p_strDoterman.Trim(), TextFont, Brushes.Black, width, StartRow);
            if (p_strDate != "")
                e.Graphics.DrawString("日期：" + Convert.ToDateTime(p_strDate).ToString("yyyy-MM-dd"), TextFont, Brushes.Black, 580, StartRow);
            else
                e.Graphics.DrawString("日期：", TextFont, Brushes.Black, 580, StartRow);
            StartRow += RowHight;
            e.Graphics.DrawLine(blackPen, x1, StartRow, x2, StartRow);
            width = 100;
            StartRow += RowHight;
            e.Graphics.DrawString("药品名称", TextFont, Brushes.Black, width, StartRow);
            e.Graphics.DrawString("剂量", TextFont, Brushes.Black, width + 180, StartRow);
            if (this.m_objViewer.rdbWest.Checked == true)
                e.Graphics.DrawString("频率", TextFont, Brushes.Black, width + 230, StartRow);
            else
                e.Graphics.DrawString("服数", TextFont, Brushes.Black, width + 230, StartRow);
            e.Graphics.DrawString("天数", TextFont, Brushes.Black, width + 300, StartRow);
            e.Graphics.DrawString("总数", TextFont, Brushes.Black, width + 340, StartRow);
            e.Graphics.DrawString("用法", TextFont, Brushes.Black, width + 390, StartRow);
            e.Graphics.DrawString("单价", TextFont, Brushes.Black, width + 480, StartRow);
            e.Graphics.DrawString("金额", TextFont, Brushes.Black, width + 550, StartRow);

            if (objItems.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < objItems.Rows.Count; i1++)
                {
                    if (objItems.Rows[i1]["itemname_vchr"].ToString().Trim().Length > 15)
                    {
                        string Startstr = objItems.Rows[i1]["itemname_vchr"].ToString().Trim().Substring(0, 12);
                        e.Graphics.DrawString(Startstr, TextFont, Brushes.Black, width, height + (i1 + 1) * 30 - 5);
                        string stepstr = objItems.Rows[i1]["itemname_vchr"].ToString().Trim().Substring(12);
                        e.Graphics.DrawString(stepstr, TextFont, Brushes.Black, width, height + (i1 + 1) * 30 + 10);
                    }
                    else
                    {
                        e.Graphics.DrawString(objItems.Rows[i1]["itemname_vchr"].ToString().Trim(), TextFont, Brushes.Black, width, height + (i1 + 1) * 30);
                    }

                    if (this.m_objViewer.rdbWest.Checked == true)
                    {
                        e.Graphics.DrawString(objItems.Rows[i1]["DOSAGE_DEC"].ToString().Trim(), TextFont, Brushes.Black, width + 180, height + (i1 + 1) * 30);
                        e.Graphics.DrawString(objItems.Rows[i1]["FREQNAME_CHR"].ToString().Trim(), TextFont, Brushes.Black, width + 230, height + (i1 + 1) * 30);
                        e.Graphics.DrawString(objItems.Rows[i1]["DAYS_INT"].ToString().Trim(), TextFont, Brushes.Black, width + 300, height + (i1 + 1) * 30);
                    }
                    else
                    {
                        if (objItems.Rows[i1]["TYPENAME_VCHR"].ToString().IndexOf("中成", 0) == 0)
                        {
                            e.Graphics.DrawString(objItems.Rows[i1]["DOSAGEQTY"].ToString().Trim(), TextFont, Brushes.Black, width + 180, height + (i1 + 1) * 30);
                            e.Graphics.DrawString(objItems.Rows[i1]["FREQNAME_CHR"].ToString().Trim(), TextFont, Brushes.Black, width + 230, height + (i1 + 1) * 30);
                            e.Graphics.DrawString(objItems.Rows[i1]["DAYS_INT"].ToString().Trim(), TextFont, Brushes.Black, width + 300, height + (i1 + 1) * 30);
                        }
                        else
                        {
                            if (objItems.Rows[i1]["MIN_QTY_DEC1"].ToString().Trim() != "")
                            {
                                e.Graphics.DrawString(objItems.Rows[i1]["MIN_QTY_DEC1"].ToString().Trim(), TextFont, Brushes.Black, width + 180, height + (i1 + 1) * 30);
                            }
                            else
                            {
                                e.Graphics.DrawString(objItems.Rows[i1]["MIN_QTY_DEC"].ToString().Trim(), TextFont, Brushes.Black, width + 180, height + (i1 + 1) * 30);
                            }
                            e.Graphics.DrawString(objItems.Rows[i1]["TIMES_INT"].ToString().Trim(), TextFont, Brushes.Black, width + 230, height + (i1 + 1) * 30);
                        }
                    }
                    e.Graphics.DrawString(objItems.Rows[i1]["qty_dec"].ToString().Trim() + objItems.Rows[i1]["unitid_chr"].ToString().Trim(), TextFont, Brushes.Black, width + 340, height + (i1 + 1) * 30);
                    e.Graphics.DrawString(objItems.Rows[i1]["USAGENAME_VCHR"].ToString().Trim(), TextFont, Brushes.Black, width + 390, height + (i1 + 1) * 30);
                    e.Graphics.DrawString(objItems.Rows[i1]["price_mny"].ToString().Trim(), TextFont, Brushes.Black, width + 480, height + (i1 + 1) * 30);
                    e.Graphics.DrawString(objItems.Rows[i1]["tolprice_mny"].ToString().Trim(), TextFont, Brushes.Black, width + 550, height + (i1 + 1) * 30);
                }
            }
            e.Graphics.DrawLine(blackPen, x1, 860, x2, 860);
            width = 100;
            e.Graphics.DrawString("西药费：", TextFont, Brushes.Black, width, 870);
            width = width + szPerWord.Width * 3;
            e.Graphics.DrawString(this.m_objViewer.WestMoney.Text.Trim(), TextFont, Brushes.Black, width, 870);
            width += this.m_objViewer.WestMoney.Text.Length * szPerWord.Width;
            e.Graphics.DrawString("中成药费：", TextFont, Brushes.Black, width, 870);
            width = width + szPerWord.Width * 4;
            e.Graphics.DrawString(this.m_objViewer.ChAndEN.Text.Trim(), TextFont, Brushes.Black, width, 870);

            width += this.m_objViewer.ChAndEN.Text.Length * szPerWord.Width;
            e.Graphics.DrawString("中药费：", TextFont, Brushes.Black, width, 870);
            width = width + szPerWord.Width * 3;
            e.Graphics.DrawString(this.m_objViewer.ChinaMoney.Text.Trim(), TextFont, Brushes.Black, width, 870);

            width += this.m_objViewer.ChinaMoney.Text.Length * szPerWord.Width;
            e.Graphics.DrawString("治疗费：", TextFont, Brushes.Black, width, 870);
            width = width + szPerWord.Width * 3;
            e.Graphics.DrawString(this.m_objViewer.CheckMoney.Text.Trim(), TextFont, Brushes.Black, width, 870);

            width += this.m_objViewer.CheckMoney.Text.Length * szPerWord.Width;
            e.Graphics.DrawString("总金额：", TextFont, Brushes.Black, width, 870);
            width += szPerWord.Width * 3;
            double tolMoney = Convert.ToDouble(this.m_objViewer.WestMoney.Text.Trim()) + Convert.ToDouble(this.m_objViewer.ChAndEN.Text.Trim()) + Convert.ToDouble(this.m_objViewer.ChinaMoney.Text.Trim()) + Convert.ToDouble(this.m_objViewer.CheckMoney.Text.Trim());
            e.Graphics.DrawString(tolMoney.ToString().Trim(), TextFont, Brushes.Black, width, 870);
            e.Graphics.DrawLine(blackPen, x1, 890, x2, 890);
        }
        #endregion

        #endregion

        #region 显示员工输入窗口
        /// <summary>
        /// 显示员工输入窗口
        /// </summary>
        /// <param name="intStatuc">0-发药，1-配药，2-退处方,3-门诊处方审核,4-门诊审方处退方</param>
        /// <param name="sender"></param>
        public void m_ShowInput(int intStatuc, object sender)
        {
            intClick = intStatuc;
            if (m_objViewer.m_lsvPatientDetial.Items.Count != 0)
            {
                if (m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0 || m_objViewer.m_lsvPatientDetial.CheckedItems.Count > 0)
                {
                    if (intStatuc < 3)
                    {
                        clsMedStorePatientListInfo seleRow;
                        seleRow = (clsMedStorePatientListInfo)m_objViewer.m_lsvPatientDetial.SelectedItems[0].Tag;
                        bool blRes = m_objManage.m_blCheckOut(seleRow.m_objRecipeList[0].m_strINVOICENO_VCHR);
                        if (!blRes)
                        {
                            if (intClick == 0)
                            {
                                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "该病人已经退钱不可以发药！");

                            }
                            else if (intClick == 1)
                            {
                                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "该病人已经退钱不可以配药！");

                            }
                            return;
                        }

                        if (m_objViewer.m_lsvOpRecDetail.SelectedItems.Count > 0)
                        {
                            objRecipe = null;
                            objRecipe = (clsOutpatientRecipe_VO)m_objViewer.m_lsvOpRecDetail.SelectedItems[0].Tag;
                            switch (intStatuc)
                            {
                                case 0:
                                    frmSendMedicineConfirm m_objSMC = new frmSendMedicineConfirm();
                                    m_objSMC.m_mthGetOPMedStoreControl(this);
                                    break;
                                case 1:
                                    frmInput objInfo2 = new frmInput();
                                    objInfo2.chbPrint.Visible = false;
                                    objInfo2.m_GetcontrolMetStore(this);
                                    if (this.m_objViewer.statusWindows.isAutoPrint && (string)this.m_objViewer.btnPrint.Tag == "0")
                                        objInfo2.chbPrint.Checked = true;
                                    else
                                        objInfo2.chbPrint.Checked = false;
                                    break;
                                case 2:
                                    frmBreakInput objInfo3 = new frmBreakInput();
                                    objInfo3.m_GetcontrolMetStore(this);
                                    break;
                            }
                        }
                        else
                        {
                            publiClass.m_mthShowWarning(this.m_objViewer.m_lsvOpRecDetail, "请选择处方号！");
                        }
                    }
                    else//门诊审核处方
                    {
                        if (intStatuc == 4)
                        {
                            frmBreakInput objInfo3 = new frmBreakInput();
                            objInfo3.m_GetcontrolMetStore(this);
                        }
                        else
                        {
                            frmInput objInfo2 = new frmInput();
                            objInfo2.chbPrint.Visible = false;
                            objInfo2.m_GetcontrolMetStore(this);
                            if (this.m_objViewer.statusWindows.isAutoPrint && (string)this.m_objViewer.btnPrint.Tag == "0")
                                objInfo2.chbPrint.Checked = true;
                            else
                                objInfo2.chbPrint.Checked = false;

                        }
                    }
                }
                else
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvPatientDetial, "请选择流水号！");
                }
            }
            else
            {
                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvPatientDetial, "当前没有要发的药！");
            }

        }
        #endregion

        #region 默认按钮事件
        /// <summary>
        /// 默认按钮事件
        /// </summary>
        public void m_mthClick()
        {
            if (SaveEmp[this.m_intSaveEmpOrder].empID != null && SaveEmp[this.m_intSaveEmpOrder].empID != "")
            {
                if (m_objViewer.m_lsvOpRecDetail.SelectedItems.Count == 0)
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvPatientDetial, "请先选择病人!");
                    this.m_objViewer.m_txtSeqID.Focus();
                    return;
                }
                if (m_objViewer.m_lsvOpRecDetail.SelectedItems.Count > 0)
                {
                    objRecipe = null;
                    objRecipe = (clsOutpatientRecipe_VO)m_objViewer.m_lsvOpRecDetail.SelectedItems[0].Tag;
                    if (m_objViewer.m_lsvPatientDetial.SelectedItems.Count > 0)
                    {
                        switch (this.m_objViewer.statusWindows.statusTone)
                        {
                            case 1:
                                if (m_objViewer.m_lsvPatientDetial.SelectedItems != null)
                                {
                                    m_mthDosageData(SaveEmp[this.m_intSaveEmpOrder].empID, SaveEmp[this.m_intSaveEmpOrder].empName);
                                }
                                break;
                            case 2:
                                long lngRes = m_mthSend(SaveEmp[this.m_intSaveEmpOrder].empID, SaveEmp[this.m_intSaveEmpOrder].empName, objRecipe);
                                this.m_objViewer.m_txtSeqID.Focus();
                                break;
                            case 3:
                                if (this.m_objViewer.m_lsvPatientDetial.CheckedItems.Count >= 0)
                                {
                                    clsOutpatientRecipe_VO[] AllcheckVO = new clsOutpatientRecipe_VO[this.m_objViewer.m_lsvPatientDetial.CheckedItems.Count];
                                    int currItem = 0;
                                    for (int i1 = 0; i1 < this.m_objViewer.m_lsvPatientDetial.Items.Count; i1++)
                                    {
                                        if (this.m_objViewer.m_lsvPatientDetial.Items[i1].Checked == true)
                                        {
                                            AllcheckVO[currItem] = (clsOutpatientRecipe_VO)this.m_objViewer.m_lsvPatientDetial.Items[i1].Tag;
                                            currItem++;
                                        }
                                    }
                                    m_mthOutpatrecipeManage(SaveEmp[this.m_intSaveEmpOrder].empID, AllcheckVO, "", 1);
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "请先设置默认的操作员！");
            }
            //if (this.m_objViewer.statusWindows.statusTone == 1)
            //{
            this.m_objViewer.txtWechatCode.Text = string.Empty;
            this.m_objViewer.txtWechatCode.Focus();
            //}
        }

        #endregion
        #region 获取配药和发药员工的信息
        /// <summary>
        ///  获取配药和发药员工的信息
        /// </summary>
        /// <param name="m_objDispenseVo"></param>
        /// <param name="m_objSendMedVo"></param>
        public void m_mthGetEmployeeData(clsEmployeeVO m_objDispenseVo, clsEmployeeVO m_objSendMedVo)
        {
            long lngRes = -1;
            lngRes = this.m_mthSendMedicine(m_objDispenseVo, m_objSendMedVo, objRecipe);
        }
        #endregion
        #region 接收员工工号
        /// <summary>
        /// 接收员工工号
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employName"></param>
        /// <param name="IsAutoPrint"></param>
        /// <param name="strRemark">退处方按扭的备注</param>
        public void m_getData(string employee, string employName, bool IsAutoPrint, string strRemark)
        {

            if (IsAutoPrint == true)
            {
                intPrint = 1;
            }
            p_strSentMan = employName;
            switch (intClick)
            {
                case 0:
                    long lngRes = m_mthSend(employee, employName, objRecipe);
                    if (IsAutoPrint && lngRes == 1)
                    {
                        try
                        {
                            strEmpName = employName;
                            this.m_objViewer.PrintDocu.Print();
                            string WindowID = (string)this.m_objViewer.cbWindows.Tag;
                            m_objManage.m_lngPrintSucc(WindowID, int.Parse(this.m_objViewer.m_lsvPatientDetial.SelectedItems[0].SubItems[5].Text.ToString()));
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.Message, "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            intPrint = 0;
                        }
                    }
                    this.m_objViewer.m_txtSeqID.Focus();
                    break;
                case 1:
                    m_mthDosageData(employee, employName);
                    break;
                case 2:
                    m_mthBreak(employee);
                    break;
                case 3:
                    if (this.m_objViewer.m_lsvPatientDetial.CheckedItems.Count >= 0)
                    {
                        clsOutpatientRecipe_VO[] AllcheckVO = new clsOutpatientRecipe_VO[this.m_objViewer.m_lsvPatientDetial.CheckedItems.Count];
                        int currItem = 0;
                        for (int i1 = 0; i1 < this.m_objViewer.m_lsvPatientDetial.Items.Count; i1++)
                        {
                            if (this.m_objViewer.m_lsvPatientDetial.Items[i1].Checked == true)
                            {
                                AllcheckVO[currItem] = (clsOutpatientRecipe_VO)this.m_objViewer.m_lsvPatientDetial.Items[i1].Tag;
                                currItem++;
                            }
                        }
                        m_mthOutpatrecipeManage(employee, AllcheckVO, strRemark, 1);
                    }
                    break;
                case 4:
                    if (this.m_objViewer.m_lsvPatientDetial.CheckedItems.Count >= 0)
                    {
                        clsOutpatientRecipe_VO[] AllcheckVO = new clsOutpatientRecipe_VO[this.m_objViewer.m_lsvPatientDetial.CheckedItems.Count];
                        int currItem = 0;
                        for (int i1 = 0; i1 < this.m_objViewer.m_lsvPatientDetial.Items.Count; i1++)
                        {
                            if (this.m_objViewer.m_lsvPatientDetial.Items[i1].Checked == true)
                            {
                                AllcheckVO[currItem] = (clsOutpatientRecipe_VO)this.m_objViewer.m_lsvPatientDetial.Items[i1].Tag;
                                currItem++;
                            }
                        }
                        m_mthOutpatrecipeManage(employee, AllcheckVO, strRemark, -1);
                    }
                    break;
            }
        }
        #endregion

        #region 诊断卡号自动补“0”
        public void m_lngAction()
        {
            double intVaues;
            try
            {
                intVaues = Convert.ToDouble(this.m_objViewer.m_txtPatientCard.Text.Trim());
            }
            catch
            {
                MessageBox.Show("错误的输入", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            this.m_objViewer.m_txtPatientCard.Text = intVaues.ToString("0000000000");
        }
        #endregion

        #region 清空查询输入
        private void FindClear()
        {
            this.m_objViewer.m_txtPatientCard.Clear();
            this.m_objViewer.m_txtPatient.Clear();
            this.m_objViewer.m_txtRegisterNo.Clear();
        }
        #endregion

        #region 显示项目的详细资料
        /// <summary>
        /// 显示项目的详细资料
        /// </summary>
        public void m_lngShow()
        {
            if (this.m_objViewer.m_lsvMedicineDetail.Items.Count == 0)
            {
                return;
            }
            if (this.m_objViewer.m_lsvMedicineDetail.Items.Count > 1 && this.m_objViewer.m_lsvMedicineDetail.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择一个项目！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string itemcode;
            if (this.m_objViewer.m_lsvMedicineDetail.Items.Count == 0)
                itemcode = this.m_objViewer.m_lsvMedicineDetail.Items[0].SubItems[0].Text.Trim();
        }
        #endregion

        #region 查找其它可以用来发药的明细
        /// <summary>
        /// 查找其它可以用来发药的明细
        /// </summary>
        public void findOtherDe()
        {
            int m_intCount = 0;//记录有多少个可用的费用
            DataTable btpatientcnkre = new DataTable();//检验费
            DataTable btpatientest = new DataTable();//检查费
            DataTable btpatienOpsre = new DataTable();//手术费
            DataTable btpatienothre = new DataTable();//其它费
            if (this.m_objViewer.m_lsvOpRecDetail.Items.Count == 0)
            {
                MessageBox.Show("当前没有可用的处方！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string p_strOUTPATRECIPEID = this.m_objViewer.m_lsvOpRecDetail.Items[0].SubItems[0].Text.Trim();
            long lngRes = m_objManage.m_lngGetAll(p_strOUTPATRECIPEID, out btpatientcnkre, out btpatientest, out btpatienOpsre, out btpatienothre);
            if (btpatientcnkre.Rows.Count > 0 || btpatientest.Rows.Count > 0 || btpatienOpsre.Rows.Count > 0 || btpatienothre.Rows.Count > 0)
            {
                if (btpatientcnkre.Rows.Count > 0)
                {
                    Double tolMoney = 0;
                    m_intCount++;
                    for (int i1 = 0; i1 < btpatientcnkre.Rows.Count; i1++)
                    {
                        try
                        {
                            tolMoney += Convert.ToDouble(btpatientcnkre.Rows[i1]["TOLPRICE_MNY"].ToString().Trim());
                        }
                        catch
                        {
                        }
                    }

                    rad1.Text = "检验费";
                    rad1.Tag = tolMoney.ToString().Trim();
                    this.m_objViewer.pnl1.Controls.Add(rad1);
                    rad1.Location = new System.Drawing.Point(0, 16);
                    rad1.Size = new Size(80, 23);
                    rad1.CheckedChanged += new EventHandler(rad1_CheckedChanged);
                }
                if (btpatientest.Rows.Count > 0)
                {
                    Double tolMoney = 0;
                    for (int i1 = 0; i1 < btpatientest.Rows.Count; i1++)
                    {
                        try
                        {
                            tolMoney += Convert.ToDouble(btpatientest.Rows[i1]["TOLPRICE_MNY"].ToString().Trim());
                        }
                        catch
                        {
                        }
                    }
                    rad2.Text = "检查费";
                    rad2.Tag = tolMoney.ToString().Trim();
                    this.m_objViewer.pnl1.Controls.Add(rad2);
                    int PrintX = 90 * m_intCount;
                    rad2.Size = new Size(80, 23);
                    rad2.Location = new System.Drawing.Point(PrintX, 16);
                    rad2.CheckedChanged += new EventHandler(rad2_CheckedChanged);
                    m_intCount++;
                }
                if (btpatienOpsre.Rows.Count > 0)
                {
                    Double tolMoney = 0;
                    for (int i1 = 0; i1 < btpatienOpsre.Rows.Count; i1++)
                    {
                        try
                        {
                            tolMoney += Convert.ToDouble(btpatienOpsre.Rows[i1]["TOLPRICE_MNY"].ToString().Trim());
                        }
                        catch
                        {
                        }
                    }

                    rad3.Text = "手术费";
                    rad3.Tag = tolMoney.ToString().Trim();
                    this.m_objViewer.pnl1.Controls.Add(rad3);
                    int PrintX = 90 * m_intCount;
                    rad3.Location = new System.Drawing.Point(PrintX, 16);
                    rad3.Size = new Size(80, 23);
                    rad3.CheckedChanged += new EventHandler(rad3_CheckedChanged);
                    m_intCount++;
                }
                if (btpatienothre.Rows.Count > 0)
                {
                    Double tolMoney = 0;
                    for (int i1 = 0; i1 < btpatienothre.Rows.Count; i1++)
                    {
                        try
                        {
                            tolMoney += Convert.ToDouble(btpatienothre.Rows[i1]["TOLPRICE_MNY"].ToString().Trim());
                        }
                        catch
                        {
                        }
                    }

                    rad4.Text = "其它费";
                    rad4.Tag = tolMoney.ToString().Trim();
                    this.m_objViewer.pnl1.Controls.Add(rad4);
                    int PrintX = 90 * m_intCount;
                    rad4.Location = new System.Drawing.Point(PrintX, 16);
                    rad4.Size = new Size(80, 23);
                    rad4.CheckedChanged += new EventHandler(rad4_CheckedChanged);
                    m_intCount++;
                }
                this.m_objViewer.pnlotherSend.Location = new Point(100, 100);
                this.m_objViewer.pnlotherSend.Visible = true;
            }
            else
            {
                MessageBox.Show("该处方没有可用的钱！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

        }
        #endregion

        #region 显示其它处方明细
        /// <summary>
        /// 显示其它处方明细
        /// </summary>
        public void m_lngShowAll()
        {
            this.m_objViewer.m_lsvMedicineDetail.Controls.Add(this.m_objViewer.gbItem);
            DataTable btpatientcnkre = new DataTable();
            DataTable btpatientest = new DataTable();
            DataTable btpatienOpsre = new DataTable();
            DataTable btpatienothre = new DataTable();
            if (this.m_objViewer.m_lsvOpRecDetail.Items.Count == 0)
            {
                MessageBox.Show("当前没有处方！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string p_strOUTPATRECIPEID = this.m_objViewer.m_lsvOpRecDetail.Items[0].SubItems[0].Text.Trim();
            long lngRes = m_objManage.m_lngGetAll(p_strOUTPATRECIPEID, out btpatientcnkre, out btpatientest, out btpatienOpsre, out btpatienothre);
            if (lngRes == 0)
                MessageBox.Show("获取数据出错！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
            string couTableName = "";
            int tolTable = 0;
            int tolheight = 0;
            this.m_objViewer.gbItem.Location = new System.Drawing.Point(200, this.m_objViewer.m_lsvMedicineDetail.Height);
            if (btpatientcnkre.Rows.Count != 0)
            {
                DataTable tbleReName1 = new DataTable();
                tbleReName1.Columns.Add("项目名称");
                tbleReName1.Columns.Add("价格");
                tbleReName1.Columns.Add("执行部门");
                tbleReName1.Columns.Add("折扣");
                tbleReName1.Columns.Add("总价");
                for (int i1 = 0; i1 < btpatientcnkre.Rows.Count; i1++)
                {
                    DataRow newRow = tbleReName1.NewRow();
                    newRow["项目名称"] = btpatientcnkre.Rows[i1]["ITEMNAME_VCHR"];
                    newRow["价格"] = btpatientcnkre.Rows[i1]["PRICE_MNY"];
                    newRow["执行部门"] = btpatientcnkre.Rows[i1]["OPRDEPT_CHR"];
                    newRow["折扣"] = btpatientcnkre.Rows[i1]["DISCOUNT_DEC"];
                    newRow["总价"] = btpatientcnkre.Rows[i1]["TOLPRICE_MNY"];
                    tbleReName1.Rows.Add(newRow);
                }
                this.m_objViewer.dgpatientcnkre.m_mthSetDataTable(tbleReName1);
                this.m_objViewer.gbItem.Controls.Add(this.m_objViewer.dgpatientcnkre);
                this.m_objViewer.dgpatientcnkre.Location = new System.Drawing.Point(3, 18);
                this.m_objViewer.dgpatientcnkre.Size = new Size(700, 90 + 20 * btpatientcnkre.Rows.Count);
                this.m_objViewer.dgpatientcnkre.Visible = true;
                couTableName = "dgpatientcnkre";
                tolheight += this.m_objViewer.dgpatientcnkre.Height;
                tolTable++;
            }

            if (btpatientest.Rows.Count != 0)
            {

                DataTable tbleReName2 = new DataTable();
                tbleReName2.Columns.Add("项目名称");
                tbleReName2.Columns.Add("价格");
                tbleReName2.Columns.Add("执行部门");
                tbleReName2.Columns.Add("折扣");
                tbleReName2.Columns.Add("总价");
                for (int i1 = 0; i1 < btpatientest.Rows.Count; i1++)
                {
                    DataRow newRow = tbleReName2.NewRow();
                    newRow["项目名称"] = btpatientest.Rows[i1]["ITEMNAME_VCHR"];
                    newRow["价格"] = btpatientest.Rows[i1]["PRICE_MNY"];
                    newRow["执行部门"] = btpatientest.Rows[i1]["OPRDEPT_CHR"];
                    newRow["折扣"] = btpatientest.Rows[i1]["DISCOUNT_DEC"];
                    newRow["总价"] = btpatientest.Rows[i1]["TOLPRICE_MNY"];
                    tbleReName2.Rows.Add(newRow);
                }
                this.m_objViewer.dgpatientest.m_mthSetDataTable(tbleReName2);
                this.m_objViewer.gbItem.Controls.Add(this.m_objViewer.dgpatientest);
                if (couTableName == "")
                {
                    this.m_objViewer.dgpatientest.Location = new System.Drawing.Point(3, 18);
                    this.m_objViewer.dgpatientest.Size = new Size(700, 90 + 20 * btpatientest.Rows.Count);
                    this.m_objViewer.dgpatientest.Visible = true;
                    couTableName = "dgpatientest";
                }
                else
                {
                    this.m_objViewer.dgpatientest.Location = new System.Drawing.Point(3, 12 + tolheight);
                    this.m_objViewer.dgpatientest.Size = new Size(700, 80 + 20 * btpatientest.Rows.Count);
                    this.m_objViewer.dgpatientest.Visible = true;
                    couTableName = "dgpatientest";
                }
                tolheight += this.m_objViewer.dgpatientest.Height;
                tolTable++;
            }

            if (btpatienOpsre.Rows.Count != 0)
            {
                DataTable tbleReName3 = new DataTable();
                tbleReName3.Columns.Add("项目名称");
                tbleReName3.Columns.Add("价格");
                tbleReName3.Columns.Add("执行部门");
                tbleReName3.Columns.Add("折扣");
                tbleReName3.Columns.Add("总价");
                for (int i1 = 0; i1 < btpatienOpsre.Rows.Count; i1++)
                {
                    DataRow newRow = tbleReName3.NewRow();
                    newRow["项目名称"] = btpatienOpsre.Rows[i1]["ITEMNAME_VCHR"];
                    newRow["价格"] = btpatienOpsre.Rows[i1]["PRICE_MNY"];
                    newRow["执行部门"] = btpatienOpsre.Rows[i1]["OPRDEPT_CHR"];
                    newRow["折扣"] = btpatienOpsre.Rows[i1]["DISCOUNT_DEC"];
                    newRow["总价"] = btpatienOpsre.Rows[i1]["TOLPRICE_MNY"];
                    tbleReName3.Rows.Add(newRow);
                }
                this.m_objViewer.dgpatienOpsre.m_mthSetDataTable(tbleReName3);
                this.m_objViewer.gbItem.Controls.Add(this.m_objViewer.dgpatienOpsre);
                if (couTableName == "")
                {
                    this.m_objViewer.dgpatienOpsre.Location = new System.Drawing.Point(3, 18);
                    this.m_objViewer.dgpatienOpsre.Size = new Size(700, 90 + 20 * btpatienOpsre.Rows.Count);
                    this.m_objViewer.dgpatienOpsre.Visible = true;
                    couTableName = "dgpatienOpsre";
                }
                else
                {
                    this.m_objViewer.dgpatienOpsre.Location = new System.Drawing.Point(3, 12 + tolheight);
                    this.m_objViewer.dgpatienOpsre.Size = new Size(700, 80 + 20 * btpatienOpsre.Rows.Count);
                    this.m_objViewer.dgpatienOpsre.Visible = true;
                    couTableName = "dgpatienOpsre";
                }
                tolheight += this.m_objViewer.dgpatienOpsre.Height;
                tolTable++;
            }
            if (btpatienothre.Rows.Count != 0)
            {
                DataTable tbleReName4 = new DataTable();
                tbleReName4.Columns.Add("项目名称");
                tbleReName4.Columns.Add("价格");
                tbleReName4.Columns.Add("数量");
                tbleReName4.Columns.Add("折扣");
                tbleReName4.Columns.Add("总价");
                for (int i1 = 0; i1 < btpatienothre.Rows.Count; i1++)
                {
                    DataRow newRow = tbleReName4.NewRow();
                    newRow["项目名称"] = btpatienothre.Rows[i1]["ITEMNAME_VCHR"];
                    newRow["价格"] = btpatienothre.Rows[i1]["UNITPRICE_MNY"];
                    newRow["数量"] = btpatienothre.Rows[i1]["QTY_DEC"];
                    newRow["折扣"] = btpatienothre.Rows[i1]["DISCOUNT_DEC"];
                    newRow["总价"] = btpatienothre.Rows[i1]["TOLPRICE_MNY"];
                    tbleReName4.Rows.Add(newRow);
                }
                this.m_objViewer.dgpatienothre.m_mthSetDataTable(tbleReName4);
                this.m_objViewer.gbItem.Controls.Add(this.m_objViewer.dgpatienothre);
                if (couTableName == "")
                {
                    this.m_objViewer.dgpatienothre.Location = new System.Drawing.Point(3, 20);
                    this.m_objViewer.dgpatienothre.Size = new Size(700, 90 + 20 * btpatienothre.Rows.Count);
                    this.m_objViewer.dgpatienothre.Visible = true;
                    couTableName = "dgpatienothre";
                }
                else
                {
                    this.m_objViewer.dgpatienothre.Location = new System.Drawing.Point(3, 12 + tolheight);
                    this.m_objViewer.dgpatienothre.Size = new Size(700, 80 + 20 * btpatienothre.Rows.Count);
                    this.m_objViewer.dgpatienothre.Visible = true;
                    couTableName = "dgpatienothre";
                }
                tolheight += this.m_objViewer.dgpatienothre.Height;
                tolTable++;
            }
            if (tolTable == 0)
            {
                this.m_objViewer.gbItem.Visible = false;
                MessageBox.Show("该处方没有其它收费明细！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                this.m_objViewer.gbItem.Visible = true;
                if (tolheight > this.m_objViewer.m_lsvMedicineDetail.Height - 20)
                    tolheight = this.m_objViewer.m_lsvMedicineDetail.Height - 20;
                tolheight += tolTable * 6;
                int with = this.m_objViewer.m_lsvMedicineDetail.Width;
                this.m_objViewer.gbItem.Size = new Size(with, tolheight);
                this.m_objViewer.gbItem.Location = new System.Drawing.Point(1, this.m_objViewer.m_lsvMedicineDetail.Height - tolheight);
                //				for(int i1=0;i1<=tolheight;i1++)
                //				{
                //					this.m_objViewer.gbItem.Location=new System.Drawing.Point(1,this.m_objViewer.m_lsvMedicineDetail.Height-i1);
                //					i1++;
                //				}
            }
        }
        #endregion

        private void rad2_CheckedChanged(object sender, EventArgs e)
        {
            if (rad2.Checked == true)
            {
                this.m_objViewer.CullMoney.Text = (string)rad2.Tag;
                this.m_objViewer.m_DgMed.m_mthDeleteAllRow();
                this.m_objViewer.MedMoney.Text = "0";
                this.m_objViewer.multiMoney.Text = "0";
                this.m_objViewer.m_DgMed.CurrentCell = new DataGridCell(0, 0);
                this.m_objViewer.m_DgMed.Focus();
            }
        }

        private void rad1_CheckedChanged(object sender, EventArgs e)
        {
            if (rad1.Checked == true)
            {
                this.m_objViewer.CullMoney.Text = (string)rad1.Tag;
                this.m_objViewer.m_DgMed.m_mthDeleteAllRow();
                this.m_objViewer.m_DgMed.CurrentCell = new DataGridCell(0, 0);
                this.m_objViewer.MedMoney.Text = "0";
                this.m_objViewer.multiMoney.Text = "0";
                this.m_objViewer.m_DgMed.Focus();
            }
        }

        private void rad3_CheckedChanged(object sender, EventArgs e)
        {
            if (rad3.Checked == true)
            {
                this.m_objViewer.CullMoney.Text = (string)rad3.Tag;
                this.m_objViewer.m_DgMed.m_mthDeleteAllRow();
                this.m_objViewer.m_DgMed.CurrentCell = new DataGridCell(0, 0);
                this.m_objViewer.MedMoney.Text = "0";
                this.m_objViewer.multiMoney.Text = "0";
                this.m_objViewer.m_DgMed.Focus();
            }
        }

        private void rad4_CheckedChanged(object sender, EventArgs e)
        {
            if (rad4.Checked == true)
            {
                this.m_objViewer.CullMoney.Text = (string)rad4.Tag;
                this.m_objViewer.m_DgMed.m_mthDeleteAllRow();
                this.m_objViewer.m_DgMed.CurrentCell = new DataGridCell(0, 0);
                this.m_objViewer.MedMoney.Text = "0";
                this.m_objViewer.multiMoney.Text = "0";
                this.m_objViewer.m_DgMed.Focus();
            }
        }

        #region 计算处方总数
        private void m_mthCount()
        {
            this.m_objViewer.label20.Text = "处方总数：" + this.m_objViewer.m_lsvPatientDetial.Items.Count.ToString();
            this.m_objViewer.label21.Text = "处方总数：" + this.m_objViewer.listViewok.Items.Count.ToString();
            this.m_objViewer.label22.Text = "处方总数：" + this.m_objViewer.lisvBreak.Items.Count.ToString();

        }

        #endregion

        #region 根据处方ID打印注射单
        /// <summary>
        /// 根据处方ID打印注射单
        /// </summary>
        /// <param name="strOutID">处方ID</param>
        public void m_mthPrintQF(string strOutID, int intstatus)
        {
            //com.digitalwave.iCare.middletier.HI.clsInjectPrint injectPrint = new com.digitalwave.iCare.middletier.HI.clsInjectPrint(strOutID, this.m_objComInfo.m_strGetHospitalTitle());
            //injectPrint.m_mthPrintQF(intstatus);

            Sybase.DataWindow.DataWindowChild m_objDwc1;
            Sybase.DataWindow.DataWindowChild m_objDwc2;
            Sybase.DataWindow.DataStore m_objDs = new Sybase.DataWindow.DataStore();
            m_objDs.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            m_objDs.DataWindowObject = "t_opinjectionandxunshika";
            ArrayList m_objList1, m_objList2, m_objListGroup;
            clsOutpatientPrintRecipe_VO m_objVo;
            long lngRes = -1;
            m_objDwc1 = m_objDs.GetChild("dw_1");
            m_objDwc2 = m_objDs.GetChild("dw_2");
            clsDomainControlMedStore m_objDomain = new clsDomainControlMedStore();
            lngRes = m_objDomain.m_lngGetInjectionInfoByID(strOutID, out m_objList1, out m_objList2, out m_objListGroup, out m_objVo);
            if (lngRes > 0 && (m_objVo.objinjectArr2.Count > 0 || m_objList2.Count > 0))
            {


                m_objDwc1.Modify("t_title.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "'");
                m_objDwc1.Modify("jzsj.text='" + m_objVo.m_strPrintDate + "'");
                m_objDwc1.Modify("brkh.text='" + m_objVo.m_strCardID + "'");
                m_objDwc1.Modify("xm.text='" + m_objVo.m_strPatientName + "'");
                m_objDwc1.Modify("xb.text='" + m_objVo.m_strSex + "'");
                m_objDwc1.Modify("nl.text='" + m_objVo.m_strAge + "'");
                m_objDwc1.Modify("zzys.text='" + m_objVo.m_strDiagDrName + "'");
                m_objDwc1.Modify("lsh.text='" + m_objVo.m_strSerNO + "'");
                m_objDwc1.Modify("diag.text='" + m_objVo.m_strdiagnose + "'");
                for (int i = 0; i < m_objVo.objinjectArr2.Count; i++)
                {
                    clsOutpatientPrintRecipeDetail_VO objTemp = m_objVo.objinjectArr2[i] as clsOutpatientPrintRecipeDetail_VO;
                    int row = m_objDwc1.InsertRow(0);
                    m_objDwc1.SetItemString(row, "fh", objTemp.m_strRowNo);
                    m_objDwc1.SetItemString(row, "xmbm", objTemp.m_strChargeName);
                    m_objDwc1.SetItemString(row, "gg", objTemp.m_strSpec);
                    m_objDwc1.SetItemString(row, "ul", objTemp.m_strDosage);
                    m_objDwc1.SetItemString(row, "uf", objTemp.m_strUsage);
                    m_objDwc1.SetItemString(row, "pl", objTemp.m_strFrequency);
                    m_objDwc1.SetItemString(row, "ts", objTemp.m_strDays);
                    m_objDwc1.SetItemString(row, "zsl", objTemp.m_strCount);
                }
                //m_objDwc2.Modify("t_title.text='" +this.m_objComInfo.m_strGetHospitalTitle()+ "'");
                //m_objDwc2.Modify("jzsj.text='" + m_objVo.m_strPrintDate + "'");
                //m_objDwc2.Modify("xm.text='" + m_objVo.m_strPatientName + "'");
                //m_objDwc2.Modify("xb.text='" + m_objVo.m_strSex + "'");
                //m_objDwc2.Modify("nl.text='" + m_objVo.m_strAge + "'");
                //m_objDwc2.Modify("zzys.text='" + m_objVo.m_strDiagDrName + "'");
                //for (int j = 0; j < m_objList2.Count; j++)
                //{
                //    int row1 = m_objDwc2.InsertRow(0);
                //    m_objDwc2.SetItemString(row1, "xmmc", m_objListGroup[j].ToString());

                //}
                if (intstatus == 2)
                {
                    clsPublic.PrintDialog(m_objDs);
                }
                else
                {
                    m_objDs.Print(false, false);
                }
            }
            else
            {
                if (intstatus == 2)
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "该病人没有注射单信息！");
                }
            }
        }
        #endregion

        #region DecDigits
        /// <summary>
        /// DecDigits
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        int DecDigits(decimal dec)
        {
            string str = dec.ToString();
            return str.Length - str.IndexOf(".") - 1;
        }
        #endregion

        #region GetMedPrepType
        /// <summary>
        /// GetMedPrepType
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        Dictionary<string, string> GetMedPrepType(DataTable dt, out Dictionary<string, string> dicPrepType, out Dictionary<string, string> dicIpUnit, out Dictionary<string, string> dicMedBagUnit)
        {
            dicPrepType = new Dictionary<string, string>();
            dicIpUnit = new Dictionary<string, string>();
            dicMedBagUnit = new Dictionary<string, string>();
            if (dt != null && dt.Rows.Count > 0)
            {
                List<string> lstMedId = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    lstMedId.Add(dr["medicineid_chr"].ToString());
                }
                if (lstMedId.Count > 0)
                {
                    clsDomainControlOPMedStore domain = new clsDomainControlOPMedStore();
                    domain.GetMedPrepType(lstMedId, out dicPrepType, out dicIpUnit, out dicMedBagUnit);
                    domain = null;
                }
            }
            return dicPrepType;
        }
        #endregion

        #region 打印口服药袋
        /// <summary>
        /// 打印口服药袋
        /// </summary>
        public void m_mthPrintYD(bool isAuto)
        {
            Sybase.DataWindow.DataStore m_objDs = new Sybase.DataWindow.DataStore();
            m_objDs.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            m_objDs.DataWindowObject = "d_op_printYD";

            clsReportSendMedStart_VO m_objReportSendMedStart = this.m_GetTitMana(this.m_objSeleRow);
            // 空走纸校验
            if (m_objReportSendMedStart == null) return;
            if (string.IsNullOrEmpty(m_objReportSendMedStart.m_strname)) return;
            if (m_objReportSendMedStart.m_strname.Trim() == string.Empty) return;

            m_objDs.Modify("t_name.text = '" + m_objReportSendMedStart.m_strname + "'");
            m_objDs.Modify("t_age.text = '" + m_objReportSendMedStart.m_strAge + "'");
            m_objDs.Modify("t_sex.text = '" + m_objReportSendMedStart.m_strsex + "'");
            m_objDs.Modify("t_card.text = '" + m_objReportSendMedStart.m_strPatCardID + "'");
            m_objDs.Modify("t_date.text = '" + DateTime.Now.ToString() + "'");
            // 新增
            m_objDs.Modify("t_deptname.text = '" + m_objReportSendMedStart.DeptName + "'");
            m_objDs.Modify("t_winno.text = '" + this.m_objViewer.cbWindows.Text + "'");

            string strMedUsageID = "0021";
            DataTable dtKFUsageID = new DataTable();
            clsDomainControlOPMedStore objDcl = new clsDomainControlOPMedStore();
            objDcl.GetMedUsageID(strMedUsageID, ref dtKFUsageID);
            objDcl = null;

            //string[] strKFUsageIDArr = null;
            List<string> lstKfUsageId = new List<string>();
            if (dtKFUsageID != null && dtKFUsageID.Rows.Count > 0)
            {
                string[] tempIdArr = dtKFUsageID.Rows[0][0].ToString().Split(';');
                foreach (string item in tempIdArr)
                {
                    lstKfUsageId.Add(item);
                }
            }
            else
            {
                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "没有设置口服类用药的系统参数！");
                return;
            }
            // 药品剂型
            Dictionary<string, string> dicPrepType = null;
            // 最小单位
            Dictionary<string, string> dicIpUnit = null;
            // 药袋单位
            Dictionary<string, string> dicMedBagUnit = null;
            GetMedPrepType(objItems, out dicPrepType, out dicIpUnit, out dicMedBagUnit);

            bool isNeedPrt = false;
            string strUsageID = "";
            string strNewPage = "-1";
            string medId = string.Empty;
            string textStr = string.Empty;
            Dictionary<string, int> dicFh = new Dictionary<string, int>();
            for (int i = 0; i < objItems.Rows.Count; i++)
            {
                medId = objItems.Rows[i]["medicineid_chr"].ToString();
                strUsageID = objItems.Rows[i]["usageid_chr"].ToString();
                decimal decPrep1_dosage = 0;
                decimal decBasicDosage = Convert.ToDecimal(objItems.Rows[i]["basicdosage"].ToString());
                decimal decDosage = Convert.ToDecimal(objItems.Rows[i]["dosage_dec"].ToString());
                decimal decResult = decDosage / decBasicDosage;
                if (DecDigits(decResult) > 2)
                {
                    decResult = Convert.ToDecimal(decResult.ToString("0.00"));
                }
                decPrep1_dosage = decResult;
                bool isEyeDrop = (dicPrepType.ContainsKey(medId) && dicPrepType[medId] == "滴眼剂" ? true : false);
                if ((lstKfUsageId.IndexOf(strUsageID) >= 0) || isEyeDrop)
                {
                    int row = m_objDs.InsertRow(0);
                    m_objDs.SetItemString(row, "ypmc", objItems.Rows[i]["itemname_vchr"].ToString());
                    m_objDs.SetItemString(row, "gg", objItems.Rows[i]["itemspec_vchr"].ToString());
                    m_objDs.SetItemString(row, "days", objItems.Rows[i]["days_int1"].ToString());
                    m_objDs.SetItemString(row, "times", objItems.Rows[i]["times_int1"].ToString());
                    textStr += objItems.Rows[i]["itemname_vchr"].ToString() + ":" + "禁喝酒，禁辛辣" + "\r\n";
                    if (dicPrepType.ContainsKey(medId) && (dicPrepType[medId] == "片剂" || dicPrepType[medId] == "胶囊"))
                    {
                        if (dicIpUnit.ContainsKey(medId))
                        {
                            m_objDs.SetItemString(row, "yl", decResult.ToString());
                            m_objDs.SetItemString(row, "dw", dicIpUnit[medId]);
                        }
                        else
                        {
                            m_objDs.SetItemString(row, "yl", decResult.ToString());
                            m_objDs.SetItemString(row, "dw", objItems.Rows[i]["unitid_chr"].ToString().Trim());
                        }
                    }
                    else
                    {
                        m_objDs.SetItemString(row, "yl", objItems.Rows[i]["dosage_dec"].ToString());
                        m_objDs.SetItemString(row, "dw", objItems.Rows[i]["dosageunit_chr"].ToString());
                    }

                    string strFh = objItems.Rows[i]["rowno_chr"].ToString().Trim();
                    if (objItems.Rows[i]["rowno_chr"].ToString().Trim() == "0")
                    {
                        m_objDs.SetItemString(row, "fh", "无");
                        m_objDs.SetItemString(row, "npage", strNewPage);
                        int intTmp = int.Parse(strNewPage) - 1;
                        strNewPage = intTmp.ToString();

                        if (dicFh.ContainsKey(strFh))
                        {
                            dicFh.Clear();
                        }
                    }
                    else
                    {
                        m_objDs.SetItemString(row, "fh", objItems.Rows[i]["rowno_chr"].ToString());
                    }
                    if (dicFh.ContainsKey(strFh))
                    {
                        dicFh[strFh] += 1;
                    }
                    else
                    {
                        dicFh.Add(strFh, 1);
                    }

                    // 2016.03.09
                    string strMc = string.Empty;
                    string strG = string.Empty;
                    string strUnit = string.Empty;
                    if (dicFh[strFh] > 1)
                    {
                        if (dicPrepType.ContainsKey(medId) && dicPrepType[medId] == "滴眼剂")
                        {
                            strMc = string.Empty;
                            strG = "【共" + objItems.Rows[i]["qty_dec"].ToString() + objItems.Rows[i]["unitid_chr"].ToString().Trim() + "】";
                        }
                        else
                        {
                            strMc = "1包";
                            strG = "【共" + Convert.ToString(clsPublic.ConvertObjToDecimal(objItems.Rows[i]["days_int"].ToString()) * clsPublic.ConvertObjToDecimal(objItems.Rows[i]["times_int1"].ToString())) + "包】";
                        }
                    }
                    else
                    {
                        if (dicMedBagUnit.ContainsKey(medId))
                        {
                            strG = "【共" + objItems.Rows[i]["qty_dec"].ToString() + objItems.Rows[i]["unitid_chr"].ToString().Trim() + "】";
                            strUnit = dicMedBagUnit[medId];
                            strMc = decPrep1_dosage + strUnit;
                        }
                        else
                        {
                            if (dicPrepType.ContainsKey(medId))
                            {
                                strG = "【共" + objItems.Rows[i]["qty_dec"].ToString() + objItems.Rows[i]["unitid_chr"].ToString().Trim() + "】";
                                if (dicPrepType[medId] == "胶囊" || dicPrepType[medId] == "片剂" || dicPrepType[medId] == "丸剂" || dicPrepType[medId] == "冲剂" || dicPrepType[medId] == "散剂")
                                {
                                    if (dicIpUnit.ContainsKey(medId))
                                        strUnit = dicIpUnit[medId];
                                    else
                                        strUnit = objItems.Rows[i]["unitid_chr"].ToString().Trim();
                                    strMc = decPrep1_dosage + strUnit;
                                }
                                else if (dicPrepType[medId] == "糖浆剂" || dicPrepType[medId] == "溶液剂" || dicPrepType[medId] == "滴剂" || dicPrepType[medId] == "合剂")
                                {
                                    strMc = objItems.Rows[i]["dosage_dec"].ToString() + objItems.Rows[i]["dosageunit_chr"].ToString();
                                }
                                //else if (dicPrepType[medId] == "散剂")
                                //{
                                //    strMc = "1包";
                                //}
                                else if (dicPrepType[medId] == "滴眼剂")
                                {
                                    strMc = string.Empty;
                                }
                            }
                        }
                    }
                    strMc = string.IsNullOrEmpty(strMc) ? string.Empty : (",每次" + strMc);
                    //m_objDs.SetItemString(row, "usagedesc", objItems.Rows[i]["opusagedesc"].ToString() + "," + objItems.Rows[i]["freqdesc"].ToString().Trim() + strMc);
                    m_objDs.SetItemString(row, "usagedesc", "滴双眼，每三小时滴一次，每次滴10ml，每三小时换另一只眼");
                    m_objDs.SetItemString(row, "amountdesc", strG);
                    m_objDs.SetItemString(row, "daydesc", "【共" + objItems.Rows[i]["days_int"].ToString() + "天】");
                    m_objDs.SetItemString(row, "ipunit", textStr);
                    isNeedPrt = true;

                    #region 2016.03.09
                    /*
                    // usagedesc + daydesc + amountdesc
                    if (dicFh[strFh] > 1)
                    {
                        string package = string.Empty;
                        if (isEyeDrop)
                        {
                            m_objDs.SetItemString(row, "usagedesc", objItems.Rows[i]["opusagedesc"].ToString() + "," + objItems.Rows[i]["freqdesc"].ToString().Trim());
                            package = "【共" + objItems.Rows[i]["qty_dec"].ToString() + objItems.Rows[i]["unitid_chr"].ToString().Trim() + "】";
                        }
                        else
                        {
                            m_objDs.SetItemString(row, "usagedesc", objItems.Rows[i]["opusagedesc"].ToString() + "," + objItems.Rows[i]["freqdesc"].ToString().Trim() + ",每次" + "1包");
                            package = "【共" + Convert.ToString(clsPublic.ConvertObjToDecimal(objItems.Rows[i]["days_int"].ToString()) * clsPublic.ConvertObjToDecimal(objItems.Rows[i]["times_int1"].ToString())) + "包】";
                        }                       
                        m_objDs.SetItemString(row, "amountdesc", package);
                    }
                    else
                    {
                        string tmpStr = string.Empty;
                        if (flagId == 1)
                            tmpStr = decResult + unitName;
                        else if (flagId == 2)
                            tmpStr = decResult + objItems.Rows[i]["unitid_chr"].ToString().Trim();
                        m_objDs.SetItemString(row, "usagedesc", objItems.Rows[i]["opusagedesc"].ToString() + "," + objItems.Rows[i]["freqdesc"].ToString().Trim() + ",每次" + tmpStr);
                        m_objDs.SetItemString(row, "amountdesc", "【共" + objItems.Rows[i]["qty_dec"].ToString() + objItems.Rows[i]["unitid_chr"].ToString().Trim() + "】");
                    }
                    m_objDs.SetItemString(row, "daydesc", "【共" + objItems.Rows[i]["days_int"].ToString() + "天】");
                    isNeedPrt = true;
                     */
                    #endregion
                }
            }
            if (isNeedPrt)
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + @"\MedBagPrinter.xml");
                    XmlNode xlnRoot = xmlDoc.SelectSingleNode("PrinterSet");
                    XmlElement xleOpPrinterName = (XmlElement)xlnRoot.SelectSingleNode("OpPrinterName");

                    m_objDs.PrintProperties.PrinterName = xleOpPrinterName.GetAttribute("value");
                    m_objDs.CalculateGroups();
                    if (isAuto)
                    {
                        m_objDs.Print();
                    }
                    else
                    {
                        clsPublic.ChoosePrintDialog(m_objDs, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        /// <summary>
        /// 重载，自动打药单时使用 -- 2016.03.07 暂停使用,不再与上面方法同步。
        /// </summary>
        public void m_mthPrintYD(DataTable p_dtBasicInfo, DataTable p_dtItemDetail)
        {
            Sybase.DataWindow.DataStore m_objDs = new Sybase.DataWindow.DataStore();
            m_objDs.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            m_objDs.DataWindowObject = "d_op_printYD";

            m_objDs.Modify("t_name.text = '" + p_dtBasicInfo.Rows[0]["name_vchr"].ToString() + "'");
            m_objDs.Modify("t_age.text = '" + clsConvertDateTime.s_strCalAge(Convert.ToDateTime(p_dtBasicInfo.Rows[0]["birth_dat"])) + "'");
            m_objDs.Modify("t_sex.text = '" + p_dtBasicInfo.Rows[0]["sex_chr"].ToString() + "'");
            m_objDs.Modify("t_card.text = '" + p_dtBasicInfo.Rows[0]["patientcardid_chr"].ToString() + "'");
            m_objDs.Modify("t_date.text = '" + DateTime.Now.ToString() + "'");
            // 新增
            m_objDs.Modify("t_deptname.text = '" + p_dtBasicInfo.Rows[0]["deptname_vchr"].ToString() + "'");
            m_objDs.Modify("t_winno.text = '" + this.m_objViewer.cbWindows.Text + "'");

            string strMedUsageID = "0021";
            DataTable dtKFUsageID = new DataTable();
            clsDomainControlOPMedStore objDcl = new clsDomainControlOPMedStore();
            objDcl.GetMedUsageID(strMedUsageID, ref dtKFUsageID);
            objDcl = null;

            //string[] strKFUsageIDArr = null;
            List<string> lstKfUsageId = new List<string>();
            if (dtKFUsageID != null && dtKFUsageID.Rows.Count > 0)
            {
                string[] tempIdArr = dtKFUsageID.Rows[0][0].ToString().Split(';');
                foreach (string item in tempIdArr)
                {
                    lstKfUsageId.Add(item);
                }
            }
            else
            {
                publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "没有设置口服类用药的系统参数！");
                return;
            }
            // 药品剂型
            Dictionary<string, string> dicPrepType = null;
            // 最小单位
            Dictionary<string, string> dicIpUnit = null;
            // 药袋单位
            Dictionary<string, string> dicMedBagUnit = null;
            GetMedPrepType(objItems, out dicPrepType, out dicIpUnit, out dicMedBagUnit);

            bool isNeedPrt = false;
            string strUsageID = "";
            string strNewPage = "-1";
            string medId = string.Empty;
            string ipunit = string.Empty;
            Dictionary<string, int> dicFh = new Dictionary<string, int>();
            for (int i = 0; i < p_dtItemDetail.Rows.Count; i++)
            {
                medId = p_dtItemDetail.Rows[i]["medicineid_chr"].ToString();
                strUsageID = p_dtItemDetail.Rows[i]["usageid_chr"].ToString();
                decimal decBasicDosage = Convert.ToDecimal(p_dtItemDetail.Rows[i]["basicdosage"].ToString());
                decimal decDosage = Convert.ToDecimal(p_dtItemDetail.Rows[i]["dosage_dec"].ToString());
                decimal decResult = decDosage / decBasicDosage;
                if (DecDigits(decResult) > 2)
                {
                    decResult = Convert.ToDecimal(decResult.ToString("0.00"));
                }
                if ((lstKfUsageId.IndexOf(strUsageID) >= 0) || (dicPrepType.ContainsKey(medId) && (dicPrepType[medId] == "滴眼剂")))
                {
                    int flagId = 0;
                    string unitName = string.Empty;
                    int row = m_objDs.InsertRow(0);
                    m_objDs.SetItemString(row, "ypmc", p_dtItemDetail.Rows[i]["itemname_vchr"].ToString());
                    m_objDs.SetItemString(row, "gg", p_dtItemDetail.Rows[i]["itemspec_vchr"].ToString());
                    m_objDs.SetItemString(row, "days", p_dtItemDetail.Rows[i]["days_int1"].ToString());
                    m_objDs.SetItemString(row, "times", p_dtItemDetail.Rows[i]["times_int1"].ToString());

                    if (dicPrepType.ContainsKey(medId) && (dicPrepType[medId] == "片剂" || dicPrepType[medId] == "胶囊"))
                    {
                        flagId = 1;
                        if (dicIpUnit.ContainsKey(medId))
                        {
                            unitName = dicIpUnit[medId];
                            m_objDs.SetItemString(row, "yl", decResult.ToString());
                            m_objDs.SetItemString(row, "dw", unitName);
                        }
                        else
                        {
                            unitName = p_dtItemDetail.Rows[i]["unitid_chr"].ToString().Trim();
                            m_objDs.SetItemString(row, "yl", decResult.ToString());
                            m_objDs.SetItemString(row, "dw", unitName);
                        }
                    }
                    else
                    {
                        flagId = 2;
                        decDosage = Convert.ToDecimal(p_dtItemDetail.Rows[i]["dosage_dec"].ToString());
                        unitName = p_dtItemDetail.Rows[i]["dosageunit_chr"].ToString();
                        m_objDs.SetItemString(row, "yl", decDosage.ToString());
                        m_objDs.SetItemString(row, "dw", unitName);
                        if (dicPrepType[medId] == "糖浆剂")
                        {
                            flagId = 1;
                            decResult = decDosage;
                        }
                    }

                    string strFh = p_dtItemDetail.Rows[i]["rowno_chr"].ToString().Trim();
                    int intCounter = 0;
                    for (int k = 0; k < p_dtItemDetail.Rows.Count; k++)
                    {
                        if (p_dtItemDetail.Rows[k]["rowno_chr"].ToString().Trim() == strFh && strFh != "0")
                        {
                            ++intCounter;
                        }
                    }
                    //if (intCounter < 2)
                    //{
                        //m_objDs.SetItemDecimal(row, "ycyl", decResult);
                        
                        ipunit += p_dtItemDetail.Rows[i]["itemname_vchr"].ToString() + ":" + "禁喝酒,禁辛辣" + Environment.NewLine;
                        
                        // usagedesc
                        //m_objDs.SetItemString(row, "usagedesc", p_dtItemDetail.Rows[i]["opusagedesc"].ToString() + "," + p_dtItemDetail.Rows[i]["freqdesc"].ToString() + ",每次" + p_dtItemDetail.Rows[i]["dosage_dec"].ToString() + p_dtItemDetail.Rows[i]["dosageunit_chr"].ToString());
                    //}

                    if (objItems.Rows[i]["rowno_chr"].ToString().Trim() == "0")
                    {
                        m_objDs.SetItemString(row, "fh", "无");
                        m_objDs.SetItemString(row, "npage", strNewPage);
                        int intTmp = int.Parse(strNewPage) - 1;
                        strNewPage = intTmp.ToString();
                    }
                    else
                    {
                        m_objDs.SetItemString(row, "fh", p_dtItemDetail.Rows[i]["rowno_chr"].ToString());
                    }
                    if (dicFh.ContainsKey(strFh))
                    {
                        dicFh[strFh] += 1;
                    }
                    else
                    {
                        dicFh.Add(strFh, 1);
                    }

                    // usagedesc + daydesc + amountdesc
                    if (dicFh[strFh] > 1)
                    {
                        m_objDs.SetItemString(row, "usagedesc", p_dtItemDetail.Rows[i]["opusagedesc"].ToString() + "," + p_dtItemDetail.Rows[i]["freqdesc"].ToString().Trim() + ",每次" + "1包");
                        string package = "【共" + Convert.ToString(clsPublic.ConvertObjToDecimal(p_dtItemDetail.Rows[i]["days_int"].ToString()) * clsPublic.ConvertObjToDecimal(p_dtItemDetail.Rows[i]["times_int1"].ToString())) + "包】";
                        m_objDs.SetItemString(row, "amountdesc", package);
                    }
                    else
                    {
                        string tmpStr = string.Empty;
                        if (flagId == 1)
                            tmpStr = decResult + unitName;
                        else if (flagId == 2)
                            tmpStr = decResult + p_dtItemDetail.Rows[i]["unitid_chr"].ToString().Trim();
                        m_objDs.SetItemString(row, "usagedesc", p_dtItemDetail.Rows[i]["opusagedesc"].ToString() + "," + p_dtItemDetail.Rows[i]["freqdesc"].ToString().Trim() + ",每次" + tmpStr);
                        m_objDs.SetItemString(row, "amountdesc", "【共" + p_dtItemDetail.Rows[i]["qty_dec"].ToString() + p_dtItemDetail.Rows[i]["unitid_chr"].ToString().Trim() + "】");
                    }
                    m_objDs.SetItemString(row, "ipunit", ipunit);
                    m_objDs.SetItemString(row, "daydesc", "【共" + p_dtItemDetail.Rows[i]["days_int"].ToString() + "天】");
                    isNeedPrt = true;
                }
            }
            if (isNeedPrt)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + @"\MedBagPrinter.xml");
                XmlNode xlnRoot = xmlDoc.SelectSingleNode("PrinterSet");
                XmlElement xleOpPrinterName = (XmlElement)xlnRoot.SelectSingleNode("OpPrinterName");

                m_objDs.PrintProperties.PrinterName = xleOpPrinterName.GetAttribute("value");
                m_objDs.CalculateGroups();
                m_objDs.Print();
            }
        }
        #endregion

        /// <summary>
        /// 开始打印
        /// </summary>
        /// <param name="e"></param>
        public void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                printShow.DrawObject = e;
                printShow.m_mthBegionPrint("2");
            }
            catch
            {

            }
        }
        public bool isAuto = true;

        #region 获取帖瓶单数据
        /// <summary>
        /// 获取帖瓶单数据
        /// </summary>
        public void m_mthGetData()
        {
            if (isAuto == false)
                m_mthGetTiepenData(this.m_objSeleRow, objItems, 2);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="currRow"></param>
        /// <param name="dtItem"></param>
        private void m_mthGetTiepenData(DataRow currRow, DataTable dtItem, int status)
        {
            clsRecipeType_VO[] PrintVO = new clsRecipeType_VO[objItems.Rows.Count];
            clsOutpatientPrintRecipe_VO printTit = new clsOutpatientPrintRecipe_VO();
            printTit.m_strPatientName = currRow["NAME_VCHR"].ToString();
            printTit.m_strSex = currRow["SEX_CHR"].ToString();
            printTit.m_strAge = clsConvertDateTime.CalcAge(DateTime.Parse(currRow["BIRTH_DAT"].ToString()));
            printTit.strbedNO = "";
            printTit.m_strPrintDate = DateTime.Now.ToShortDateString();
            printTit.objinjectArr3 = new ArrayList();
            if (objItems.Rows.Count > 0)
            {
                DataTable dtRecord = new DataTable();
                long l = this.m_objManage.m_lngGetUsagebyordertypeid("2", out dtRecord);
                for (int i1 = 0; i1 < dtItem.Rows.Count; i1++)
                {

                    string usageid = dtItem.Rows[i1]["usageid_chr"].ToString().Trim();
                    for (int j = 0; j < dtRecord.Rows.Count; j++)
                    {

                        if (dtRecord.Rows[j]["usageid_chr"].ToString().Trim() == usageid)
                        {
                            clsOutpatientPrintRecipeDetail_VO PrintDe = new clsOutpatientPrintRecipeDetail_VO();
                            PrintDe.m_strDosage = dtItem.Rows[i1]["dosageqty"].ToString();
                            PrintDe.m_strDosageUnit = dtItem.Rows[i1]["DOSAGEUNIT_CHR"].ToString();
                            PrintDe.m_strDays = dtItem.Rows[i1]["DAYS_INT"].ToString();
                            PrintDe.m_strFrequency = dtItem.Rows[i1]["FREQNAME_CHR"].ToString().Trim();
                            PrintDe.m_strRowNo = dtItem.Rows[i1]["ROWNO_CHR"].ToString();
                            PrintDe.m_strUsage = dtItem.Rows[i1]["USAGENAME_VCHR"].ToString().Trim();
                            PrintDe.m_strChargeName = dtItem.Rows[i1]["itemname_vchr"].ToString();
                            PrintDe.m_strMEDNORMALNAME = dtItem.Rows[i1]["MEDNORMALNAME_VCHR"].ToString();
                            printTit.objinjectArr3.Add(PrintDe);
                        }
                    }

                }
                printTit.objinjectArr3.Sort();
            }
            if (printTit.objinjectArr3.Count > 0)
            {
                Sybase.DataWindow.DataStore m_objDS = new Sybase.DataWindow.DataStore();
                m_objDS.LibraryList = Application.StartupPath + "\\pb_op.pbl";
                m_objDS.DataWindowObject = "d_optiepenbill";
                string m_strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "贴瓶单";
                m_objDS.Modify("t_title.text='" + m_strTitle + "'");
                m_objDS.Modify("t_name.text='" + printTit.m_strPatientName + "'");
                m_objDS.Modify("t_sex.text='" + printTit.m_strSex + "'");
                m_objDS.Modify("t_age.text='" + printTit.m_strAge + "'");
                clsOutpatientPrintRecipeDetail_VO objTemp = printTit.objinjectArr3[0] as clsOutpatientPrintRecipeDetail_VO;
                string m_strTemp = objTemp.m_strUsage + "," + objTemp.m_strFrequency + "," + objTemp.m_strDays + "天";
                m_objDS.Modify("t_usage.text='" + m_strTemp + "'");
                for (int i = 0; i < printTit.objinjectArr3.Count; i++)
                {
                    clsOutpatientPrintRecipeDetail_VO objTemp1 = printTit.objinjectArr3[i] as clsOutpatientPrintRecipeDetail_VO;
                    int row = m_objDS.InsertRow(0);
                    m_objDS.SetItemString(row, "ypmc", objTemp1.m_strChargeName);
                    m_objDS.SetItemString(row, "yl", objTemp1.m_strDosage + objTemp.m_strDosageUnit);
                }

                this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = m_GetPrintName();

                m_objDS.PrintProperties.PrinterName = this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.PrinterName.ToString();


                if (!this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.IsValid)
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "没有设置正确的打印机，请到LoginFile里面从新配置！");
                    return;
                }
                isAuto = true;
                if (status == 1)
                {
                    m_objDS.Print(false, false);
                }
                else
                {

                    clsPublic.PrintDialog(m_objDS);
                }


            }
            else
            {
                if (status == 2)
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "该病人没有贴瓶单信息！");
                }
            }


            //printShow.PrintRecipeVOInfo = printTit;
            //this.m_objViewer.printDocument1.DefaultPageSettings = PrtSetUp(this.m_objViewer.printDocument1);
            //this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = m_GetPrintName();
            //if (!this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.IsValid)
            //{
            //    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "没有设置正确的打印机，请到LoginFile里面从新配置！");
            //    return;
            //}
            //isAuto = true;
            //if (status == 1 && printTit.objinjectArr3.Count > 0)
            //    this.m_objViewer.printDocument1.Print();
        }
        #endregion

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="currRow"></param>
        /// <param name="dtItem"></param>
        private void m_mthGetTiepenData(clsMedStorePatientListInfo currRow, DataTable dtItem, int status)
        {
            clsRecipeType_VO[] PrintVO = new clsRecipeType_VO[objItems.Rows.Count];
            clsOutpatientPrintRecipe_VO printTit = new clsOutpatientPrintRecipe_VO();
            printTit.m_strPatientName = "姓名：" + currRow.m_strNAME_VCHR;
            printTit.m_strSex = "性别：" + currRow.m_strSEX_CHR;
            printTit.m_strAge = "年龄：" + clsConvertDateTime.CalcAge(currRow.m_datBIRTH_DAT);
            printTit.m_strPrintDate = DateTime.Now.ToShortDateString();
            printTit.objinjectArr3 = new ArrayList();
            if (objItems.Rows.Count > 0)
            {
                DataTable dtRecord = new DataTable();
                long l = this.m_objManage.m_lngGetUsagebyordertypeid("2", out dtRecord);
                for (int i1 = 0; i1 < dtItem.Rows.Count; i1++)
                {

                    string usageid = dtItem.Rows[i1]["usageid_chr"].ToString().Trim();
                    for (int j = 0; j < dtRecord.Rows.Count; j++)
                    {

                        if (dtRecord.Rows[j]["usageid_chr"].ToString().Trim() == usageid)
                        {
                            clsOutpatientPrintRecipeDetail_VO PrintDe = new clsOutpatientPrintRecipeDetail_VO();
                            PrintDe.m_strDosage = dtItem.Rows[i1]["dosageqty"].ToString();
                            PrintDe.m_strDosageUnit = dtItem.Rows[i1]["DOSAGEUNIT_CHR"].ToString();
                            PrintDe.m_strDays = dtItem.Rows[i1]["DAYS_INT"].ToString();
                            PrintDe.m_strFrequency = dtItem.Rows[i1]["FREQNAME_CHR"].ToString().Trim();
                            PrintDe.m_strRowNo = dtItem.Rows[i1]["ROWNO_CHR"].ToString();
                            PrintDe.m_strUsage = dtItem.Rows[i1]["USAGENAME_VCHR"].ToString().Trim();
                            PrintDe.m_strChargeName = dtItem.Rows[i1]["itemname_vchr"].ToString();
                            PrintDe.m_strMEDNORMALNAME = dtItem.Rows[i1]["MEDNORMALNAME_VCHR"].ToString();
                            printTit.objinjectArr3.Add(PrintDe);
                        }
                    }

                }
                printTit.objinjectArr3.Sort();
            }
            if (printTit.objinjectArr3.Count > 0)
            {
                Sybase.DataWindow.DataStore m_objDS = new Sybase.DataWindow.DataStore();
                m_objDS.LibraryList = Application.StartupPath + "\\pb_op.pbl";
                m_objDS.DataWindowObject = "d_optiepenbill";
                string m_strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "贴瓶单";
                m_objDS.Modify("t_title.text='" + m_strTitle + "'");
                m_objDS.Modify("t_name.text='" + printTit.m_strPatientName + "'");
                m_objDS.Modify("t_sex.text='" + printTit.m_strSex + "'");
                m_objDS.Modify("t_age.text='" + printTit.m_strAge + "'");
                clsOutpatientPrintRecipeDetail_VO objTemp = printTit.objinjectArr3[0] as clsOutpatientPrintRecipeDetail_VO;
                string m_strTemp = objTemp.m_strUsage + "," + objTemp.m_strFrequency + "," + objTemp.m_strDays + "天";
                m_objDS.Modify("t_usage.text='" + m_strTemp + "'");
                for (int i = 0; i < printTit.objinjectArr3.Count; i++)
                {
                    clsOutpatientPrintRecipeDetail_VO objTemp1 = printTit.objinjectArr3[i] as clsOutpatientPrintRecipeDetail_VO;
                    int row = m_objDS.InsertRow(0);
                    m_objDS.SetItemString(row, "ypmc", objTemp1.m_strChargeName);
                    m_objDS.SetItemString(row, "yl", objTemp1.m_strDosage + objTemp.m_strDosageUnit);
                }

                this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = m_GetPrintName();

                m_objDS.PrintProperties.PrinterName = this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.PrinterName.ToString();


                if (!this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.IsValid)
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "没有设置正确的打印机，请到LoginFile里面从新配置！");
                    return;
                }
                isAuto = true;
                if (status == 1)
                {
                    m_objDS.Print(false, false);
                }
                else
                {

                    clsPublic.PrintDialog(m_objDS);
                }


            }
            else
            {
                if (status == 2)
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "该病人任何贴瓶单信息！");
                }
            }
            //printShow.PrintRecipeVOInfo = printTit;
            //this.m_objViewer.printDocument1.DefaultPageSettings = PrtSetUp(this.m_objViewer.printDocument1);
            //this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = m_GetPrintName();
            //if (!this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.IsValid)
            //{
            //    publiClass.m_mthShowWarning(this.m_objViewer.m_lsvMedicineDetail, "没有设置正确的打印机，请到LoginFile里面从新配置！");
            //    return;
            //}
            //isAuto = true;
            //if (status == 1 && printTit.objinjectArr3.Count > 0)
            //    this.m_objViewer.printDocument1.Print();
        }


        #region 设置打印纸张
        /// <summary>
        /// 设置打印纸张
        /// </summary>
        /// <param name="printDocument"></param>
        /// <returns></returns>
        public PageSettings PrtSetUp(PrintDocument printDocument)
        {
            //声明返回值的PageSettings
            PageSettings ps = new PageSettings();
            //申明并实例化PageSetupDialog
            PageSetupDialog psDlg = new PageSetupDialog();
            //读取默认纸张宽度和高度 1cm = 0.3937inch
            int width = 0;
            int height = 0;
            string w = this.m_strReadXML("Printer", "tiepenPatientPrinterWidth", "AnyOne");
            string h = this.m_strReadXML("Printer", "tiepenPatientPrinterHeight", "AnyOne");
            if (w != "")
            {
                width = Convert.ToInt32((Convert.ToDouble(w) * 39.37));
            }
            if (h != "")
            {
                height = Convert.ToInt32((Convert.ToDouble(h) * 39.37));
            }
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("帖瓶单", width, height);
            try
            {
                //相关文档及文档页面默认设置
                psDlg.Document = printDocument;
                psDlg.PageSettings = printDocument.DefaultPageSettings;
                psDlg.PageSettings.PaperSize = size;
                ps = psDlg.PageSettings;
                printDocument.DefaultPageSettings = psDlg.PageSettings;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现打印错误");
            }
            finally
            {
                psDlg.Dispose();
                psDlg = null;
            }
            return ps;
        }
        #endregion

        #region 获取打印机
        /// <summary>
        /// 返回打印机名称
        /// </summary>
        /// <returns></returns>
        public string m_GetPrintName()
        {
            string strPrintName = "";
            string patXML = "LoginFile.xml";
            if (File.Exists(patXML))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(patXML);
                XmlNode xn = doc.DocumentElement.SelectNodes("//Printer")[0];
                XmlNode xnCurr = xn.SelectSingleNode("//tiepenPatientPrinter");
                if (xnCurr != null)
                {
                    strPrintName = xnCurr.Attributes["PrinterName"].Value.ToString();
                }
            }
            return strPrintName;
        }
        #endregion

        #region 用法匹配（筛选满足条件的单据数据）
        /// <summary>
        /// 用法匹配（筛选满足条件的单据数据）
        /// </summary>
        /// <param name="usageid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool m_mthSelectorder(string usageid, DataTable dt)
        {
            string exp = "usageid_chr = '" + usageid + "'";
            bool b = true;
            DataRow[] dr = null;

            if (dt == null || dt.Rows.Count == 0)
            {
                b = false;
            }
            else
            {
                dr = dt.Select(exp);
                if (dr == null || dr.Length == 0)
                {
                    b = false;
                }
            }

            return b;
        }
        #endregion

        #region 获取员工名称
        /// <summary>
        /// 获取员工名称
        /// </summary>
        public void m_mthGetName(int m_intFlage)
        {
            if (m_intFlage == 1)
            {

                if (this.m_objViewer.textBox2.Text != "")
                {
                    string empName = "";
                    string empID = "";
                    m_objManage.m_lngGetEmpName(this.m_objViewer.textBox2.Text, this.m_objViewer.textBox3.Text, out empName, out empID);
                    if (empName != "")
                    {
                        publiClass.m_mthShowWarning(this.m_objViewer.textBox2, "设置成功！");
                        SaveEmp[0].empID = empID;
                        SaveEmp[0].empName = empName;
                        SaveEmp[0].empNo = this.m_objViewer.textBox2.Text.Trim();
                        //this.m_objViewer.textBox2.Text = "";
                        this.m_objViewer.textBox3.Text = "";
                        this.m_objViewer.panel12.Visible = false;
                    }
                    else
                    {
                        publiClass.m_mthShowWarning(this.m_objViewer.textBox2, "工号或密码错误！");
                    }
                }
                else
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.textBox2, "请先输入工号！");
                    this.m_objViewer.textBox2.Focus();
                }
            }
            if (m_intFlage == 2)
            {

                if (this.m_objViewer.txtEmpNo2.Text != "")
                {
                    string empName = "";
                    string empID = "";
                    m_objManage.m_lngGetEmpName(this.m_objViewer.txtEmpNo2.Text.Trim(), this.m_objViewer.txtPsw2.Text.Trim(), out empName, out empID);
                    if (empName != "")
                    {
                        publiClass.m_mthShowWarning(this.m_objViewer.textBox2, "设置成功！");
                        SaveEmp[1].empID = empID;
                        SaveEmp[1].empName = empName;
                        SaveEmp[1].empNo = this.m_objViewer.txtEmpNo2.Text.Trim();
                        //this.m_objViewer.txtEmpNo2 .Text  = "";
                        this.m_objViewer.txtPsw2.Text = "";
                        this.m_objViewer.panel12.Visible = false;
                    }
                    else
                    {
                        publiClass.m_mthShowWarning(this.m_objViewer.txtEmpNo2, "工号或密码错误！");
                    }
                }
                else
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.txtEmpNo2, "请先输入工号！");
                    this.m_objViewer.txtEmpNo2.Focus();
                }
            }
            if (m_intFlage == 3)
            {

                if (this.m_objViewer.txtEmpNo3.Text != "")
                {
                    string empName = "";
                    string empID = "";
                    m_objManage.m_lngGetEmpName(this.m_objViewer.txtEmpNo3.Text.Trim(), this.m_objViewer.txtPsw3.Text.Trim(), out empName, out empID);
                    if (empName != "")
                    {
                        publiClass.m_mthShowWarning(this.m_objViewer.txtEmpNo3, "设置成功！");
                        SaveEmp[2].empID = empID;
                        SaveEmp[2].empName = empName;
                        SaveEmp[2].empNo = this.m_objViewer.txtEmpNo3.Text.Trim();
                        //this.m_objViewer.txtEmpNo3.Text = "";
                        this.m_objViewer.txtPsw3.Text = "";
                        this.m_objViewer.panel12.Visible = false;
                    }
                    else
                    {
                        publiClass.m_mthShowWarning(this.m_objViewer.txtEmpNo3, "工号或密码错误！");
                    }
                }
                else
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.txtEmpNo3, "请先输入工号！");
                    this.m_objViewer.txtEmpNo3.Focus();
                }
            }
            if (m_intFlage == 4)
            {

                if (this.m_objViewer.txtEmpNo4.Text != "")
                {
                    string empName = "";
                    string empID = "";
                    m_objManage.m_lngGetEmpName(this.m_objViewer.txtEmpNo4.Text.Trim(), this.m_objViewer.txtPsw4.Text.Trim(), out empName, out empID);
                    if (empName != "")
                    {
                        publiClass.m_mthShowWarning(this.m_objViewer.txtEmpNo4, "设置成功！");
                        SaveEmp[3].empID = empID;
                        SaveEmp[3].empName = empName;
                        SaveEmp[3].empNo = this.m_objViewer.txtEmpNo4.Text.Trim();
                        //this.m_objViewer.txtEmpNo4.Text = "";
                        this.m_objViewer.txtPsw4.Text = "";
                        this.m_objViewer.panel12.Visible = false;
                    }
                    else
                    {
                        publiClass.m_mthShowWarning(this.m_objViewer.txtEmpNo4, "工号或密码错误！");
                    }
                }
                else
                {
                    publiClass.m_mthShowWarning(this.m_objViewer.txtEmpNo4, "请先输入工号！");
                    this.m_objViewer.txtEmpNo4.Focus();
                }
            }
            switch (m_objViewer.m_intSettingCount)
            {
                case 1:
                    this.m_objViewer.Text = this.m_objViewer.m_strFormText + " " + string.Format("{0}", string.IsNullOrEmpty(SaveEmp[0].empName) ? string.Empty : "F1:" + SaveEmp[0].empName);
                    break;
                case 2:
                    this.m_objViewer.Text = this.m_objViewer.m_strFormText + " " + string.Format("{0}{1}", string.IsNullOrEmpty(SaveEmp[0].empName) ? string.Empty : "F1:" + SaveEmp[0].empName, string.IsNullOrEmpty(SaveEmp[1].empName) ? string.Empty : " F2:" + SaveEmp[1].empName);
                    break;
                case 3:
                    this.m_objViewer.Text = this.m_objViewer.m_strFormText + " " + string.Format("{0}{1}{2}", string.IsNullOrEmpty(SaveEmp[0].empName) ? string.Empty : "F1:" + SaveEmp[0].empName, string.IsNullOrEmpty(SaveEmp[1].empName) ? string.Empty : " F2:" + SaveEmp[1].empName, string.IsNullOrEmpty(SaveEmp[2].empName) ? string.Empty : " F3:" + SaveEmp[2].empName);
                    break;
                case 4:
                    this.m_objViewer.Text = this.m_objViewer.m_strFormText + " " + string.Format("{0}{1}{2}{3}", string.IsNullOrEmpty(SaveEmp[0].empName) ? string.Empty : "F1:" + SaveEmp[0].empName, string.IsNullOrEmpty(SaveEmp[1].empName) ? string.Empty : " F2:" + SaveEmp[1].empName, string.IsNullOrEmpty(SaveEmp[2].empName) ? string.Empty : " F3:" + SaveEmp[2].empName, string.IsNullOrEmpty(SaveEmp[3].empName) ? string.Empty : " F4:" + SaveEmp[3].empName);
                    break;
            }
        }
        #endregion

        #region 默认设置点击取消时
        public void m_mthCancelSetDefault(int m_intFlage)
        {
            if (m_intFlage == 1)
            {
                this.m_objViewer.textBox2.Text = SaveEmp[0].empNo;
                this.m_objViewer.textBox3.Text = "";
                this.m_objViewer.panel12.Visible = false;
            }
            if (m_intFlage == 2)
            {
                this.m_objViewer.txtEmpNo2.Text = SaveEmp[1].empNo;
                this.m_objViewer.txtPsw2.Text = "";
                this.m_objViewer.panel12.Visible = false;
            }
            if (m_intFlage == 3)
            {
                this.m_objViewer.txtEmpNo3.Text = SaveEmp[2].empNo;
                this.m_objViewer.txtPsw3.Text = "";
                this.m_objViewer.panel12.Visible = false;
            }
            if (m_intFlage == 4)
            {
                this.m_objViewer.txtEmpNo4.Text = SaveEmp[3].empNo;
                this.m_objViewer.txtPsw4.Text = "";
                this.m_objViewer.panel12.Visible = false;
            }
        }
        #endregion

        private void m_mthDataTableToDataTable(ref DataTable objItems)
        {
            DataTable m_objTempTable;
            m_objTempTable = objItems.Clone();
            bool m_blnExisted = false;
            DataRow m_objTempRow;
            for (int i = 0; i < objItems.Rows.Count; i++)
            {
                m_blnExisted = false;
                for (int j = 0; j < m_objTempTable.Rows.Count; j++)
                {
                    if (m_objTempTable.Rows[j]["itemid_chr"].ToString().Trim() == objItems.Rows[i]["itemid_chr"].ToString().Trim() && m_objTempTable.Rows[j]["usageid_chr"].ToString().Trim() == objItems.Rows[i]["usageid_chr"].ToString().Trim() && m_objTempTable.Rows[j]["DOSAGEQTY"].ToString().Trim() == objItems.Rows[i]["DOSAGEQTY"].ToString().Trim() && m_objTempTable.Rows[j]["FREQNAME_CHR"].ToString().Trim() == objItems.Rows[i]["FREQNAME_CHR"].ToString().Trim())
                    {
                        m_blnExisted = true;
                        if (objItems.Rows[i]["QTY_DEC"] != DBNull.Value && m_objTempTable.Rows[j]["QTY_DEC"] != DBNull.Value)
                        {
                            m_objTempTable.Rows[j]["QTY_DEC"] = Convert.ToDouble(objItems.Rows[i]["QTY_DEC"]) + Convert.ToDouble(m_objTempTable.Rows[j]["QTY_DEC"]);
                        }
                        if (objItems.Rows[i]["TOLPRICE_MNY"] != DBNull.Value && m_objTempTable.Rows[j]["TOLPRICE_MNY"] != DBNull.Value)
                        {
                            m_objTempTable.Rows[j]["TOLPRICE_MNY"] = Convert.ToDouble(objItems.Rows[i]["TOLPRICE_MNY"]) + Convert.ToDouble(m_objTempTable.Rows[j]["TOLPRICE_MNY"]);
                        }
                        if (objItems.Rows[i]["DAYS_INT"] != DBNull.Value && m_objTempTable.Rows[j]["DAYS_INT"] != DBNull.Value)
                        {
                            m_objTempTable.Rows[j]["DAYS_INT"] = Convert.ToDouble(objItems.Rows[i]["DAYS_INT"]) + Convert.ToDouble(m_objTempTable.Rows[j]["DAYS_INT"]);
                        }
                        break;
                    }
                }
                if (m_blnExisted == false)
                {
                    m_objTempRow = m_objTempTable.NewRow();
                    for (int k = 0; k < m_objTempTable.Columns.Count; k++)
                    {
                        m_objTempRow[k] = objItems.Rows[i][k];
                    }
                    m_objTempTable.Rows.Add(m_objTempRow);
                }
            }
            objItems = m_objTempTable;
        }
        #region 设置时间
        public void m_mthSetDate()
        {
            DateTime dtmOld = this.m_objViewer.DateTimeMana.Value;
            DateTime dtm = DateTime.Now;

            //long lng = m_objManage.m_lngGetServerDate(out dtm);
            //if (lng > 0)
            //{
            if (dtm.ToString("HH:mm:ss").CompareTo("00:00:01") == 0)
            {
                if (dtmOld.Date != dtm.Date)
                {
                    this.m_objViewer.DateTimeMana.Value = dtm;
                }
            }
            //}
        }
        /// <summary>
        /// 初始化刷新时间
        /// </summary>
        public void m_mthInitRefreshTime()
        {
            string numStr = "";
            numStr = m_strReadXML("register", "MedStoreRefreshTime", "AnyOne");
            if (numStr != "")
            {
                this.m_objViewer.m_nudRefershTime.Value = decimal.Parse(numStr);
            }
            else
            {
                this.m_objViewer.m_nudRefershTime.Value = 10;
            }
        }
        /// <summary>
        /// 初始化自动打印之后,经过多少秒自动配药.
        /// </summary>
        public void m_mthInitDispenseTime()
        {
            string m_strSeconds = "";
            m_strSeconds = m_strReadXML("MedicineStore", "MedStoreDispenseTime", "AnyOne");
            if (m_strSeconds != string.Empty)
            {
                this.m_objViewer.m_timerDispense.Interval = int.Parse(m_strSeconds) * 1000;
            }
            else
            {
                this.m_objViewer.m_timerDispense.Interval = 10000;
            }
        }
        /// <summary>
        /// 获取设置,是否打印新格式发药单
        /// </summary>
        public void m_mthInitPrintSendMedBillFlag()
        {

            this.m_strPrintSendMedBill = m_strReadXML("MedicineStore", "MedStoreSendMedicine", "AnyOne");


        }
        /// <summary>
        /// 获取设置,预览电子屏的刷新时间,默认2秒
        /// </summary>
        public void m_mthInitPreviewLEDRefreshTime()
        {

            this.m_intPreviewLEDRefreshTime = int.Parse(m_strReadXML("MedicineStore", "MedStorePreviewLEDRefreshTime", "AnyOne").Trim());

        }
        /// <summary>
        /// 是否打印发药单
        /// </summary>
        public void m_mthInitPrintSendMedBill()
        {
            string m_strPrintBill = m_strReadXML("MedicineStore", "MedStorePrintSendMedicineBill", "AnyOne");
            if (m_strPrintBill.Trim() == "0")
            {
                this.m_blnPrintSendMedBill = false;
            }
            else
            {
                this.m_blnPrintSendMedBill = true;
            }
        }
        /// <summary>
        /// 存时间
        /// </summary>
        public void m_mthWriteRefreshTime()
        {
            string numStr = "";
            bool bln = m_blnWriteXML("register", "MedStoreRefreshTime", "AnyOne", this.m_objViewer.m_nudRefershTime.Value.ToString(), XMLFile);

        }
        #endregion
        private string XMLFile = System.Windows.Forms.Application.StartupPath + "\\" + "LoginFile.xml";

        #region LoginFile.XML读写操作
        /// <summary>
        /// 读操作
        /// </summary>
        /// <param name="parentnode"></param>
        /// <param name="childnode"></param>
        /// <param name="key"></param>
        public string m_strReadXML(string parentnode, string childnode, string key)
        {
            string strRet = "";

            try
            {
                if (File.Exists(XMLFile))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(XMLFile);

                    XmlNode xndP = xdoc.DocumentElement.SelectNodes(@"//" + parentnode)[0];
                    XmlNode xndC = xndP.SelectSingleNode(@"//" + childnode + @"[@key='" + key + @"']");

                    if (xndP != null)
                    {
                        strRet = xndC.Attributes["value"].Value.ToString().Trim();
                    }
                }
            }
            catch
            {
                strRet = "";
            }
            return strRet;
        }
        /// <summary>
        /// 写操作
        /// </summary>
        /// <param name="parentnode"></param>
        /// <param name="childnode"></param>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public bool m_blnWriteXML(string parentnode, string childnode, string key, string val, string XMLFile)
        {
            bool blnRet = false;
            try
            {
                if (File.Exists(XMLFile))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(XMLFile);

                    XmlNode xndP = xdoc.DocumentElement.SelectNodes(@"//" + parentnode)[0];
                    XmlNode xndC = xndP.SelectSingleNode(@"//" + childnode + @"[@key='" + key + @"']");

                    if (xndP != null && xndC != null)
                    {
                        xndC.Attributes["value"].Value = val;
                        xdoc.Save(XMLFile);
                        blnRet = true;
                    }
                }
            }
            catch
            {
                blnRet = false;
            }
            return blnRet;
        }
        #endregion

        #region 修改药房发送表叫号标志
        //关于叫号规则更改后的说明，by dianliang.liang
        //发药窗口的叫号改为重叫号
        //当在发药窗叫号时，会修改t_opr_recipesend表中called_int  recalled_int  quit_int这三个字段，分别为0,1,0
        //当called_int=1,recalled_int=0,quit_int=0，表示正常叫号（配药时自动叫号）
        //当called_int=0,recalled_int=1,quit_int=0，表示重叫号（在发药房点击叫号）
        //当called_int=0,recalled_int=0,quit_int=1，表示已叫号，但病人不来取药，手功放弃叫号，会把该病人放到电子屏的队列最后面（并不是真正的下屏），并放到发药窗口待发药队列的最后面
        //当called_int=0,recalled_int=0,quit_int=0，才是真正的下屏


        /// <summary>
        /// 修改药房发送表叫号标志
        /// </summary>
        /// <param name="m_intSid">序列号</param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendCalledFlag2(long m_intSid)
        {
            long lngRes = 0;
            lngRes = this.m_objManage.m_lngUpdateRecipeSendCalledFlag2(m_intSid);
            return lngRes;

        }

        /// <summary>
        /// 修改药房发送表叫号标志
        /// </summary>
        /// <param name="m_intSid">序列号</param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendCalledFlag(long m_intSid, int p_IsReCall)
        {
            long lngRes = 0;
            lngRes = this.m_objManage.m_lngUpdateRecipeSendCalledFlag(m_intSid, p_IsReCall);
            return lngRes;

        }

        /// <summary>
        /// 放弃叫号（并不是真正下屏，只是放到队列的后面）
        /// </summary>
        /// <param name="m_intSid"></param>
        /// <returns></returns>
        public void m_lngRecipeSendQuit(long m_intSid)
        {
            this.m_objManage.m_lngRecipeSendQuit(m_intSid);
            m_mthGetPatientQueue();
        }
        #endregion

        #region 修改药房发送表当前叫号标志
        /// <summary>
        /// 修改药房发送表当前叫号标志
        /// </summary>
        /// <param name="m_intSid">序列号</param>
        /// <param name="m_strSendWindowid"></param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendCurrentCallFlag(long m_intSid, string m_strSendWindowid, int m_IsRecall)
        {
            long lngRes = 0;
            bool blnIsModfily = false;
            if (this.m_strIsModfilySendWinID == "1")
            {
                blnIsModfily = true;
            }
            lngRes = this.m_objManage.m_lngUpdateRecipeSendCurrentCallFlag(m_intSid, m_strSendWindowid, m_IsRecall, blnIsModfily);
            return lngRes;
        }
        #endregion
        /// <summary>
        /// 定义叫号信息发药队列
        /// </summary>
        private System.Messaging.MessageQueue queue = null;
        /// <summary>
        /// 初始化药房叫号MSMQ信息
        /// </summary>
        public void m_mthInitCallMSMQInfo()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                string filename = Application.StartupPath + @"\MsgDeliverList.xml";
                document.Load(filename);
                XmlNodeList elementsByTagName = document.GetElementsByTagName("List1");
                string m_strMQ = string.Empty;
                m_strMQ = elementsByTagName[0].ChildNodes[0].InnerText;
                queue = new System.Messaging.MessageQueue(m_strMQ);
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取语音MSMQ配置失败无法初始化队列！请联系管理员检查配置文件" + ex.Message, "语音叫号", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        /// <summary>
        /// 发送叫号MSMQ信息
        /// </summary>
        /// <returns></returns>
        public void m_mthSendMessage(clsMessage_VO objBody)
        {
            queue = null;
            m_mthInitCallMSMQInfo();
            System.Messaging.Message message = new System.Messaging.Message();
            message.Formatter = new System.Messaging.BinaryMessageFormatter();
            message.Body = objBody;
            queue.Send(message);
        }

        #region 根据身份证号或者社保号查询诊疗卡号
        /// <summary>
        /// 根据身份证号或者社保号查询诊疗卡号
        /// </summary>
        /// <param name="p_strPatientID"></param>
        /// <param name="p_strTable"></param>
        /// <returns></returns>
        public string m_strGetCardID(string p_strPatientID, string p_strTable)
        {
            return m_objManage.m_strGetCardID(p_strPatientID, p_strTable);
        }
        #endregion

        #region WechatPost
        /// <summary>
        /// WechatPost
        /// </summary>
        public void WechatPost()
        {
            if (string.IsNullOrEmpty(this.WechatWebUrl))
            {
                MessageBox.Show("未启用微信通知。");
                return;
            }
            string invoNo = m_objViewer.txtWechatCode.Text.Trim();
            if (invoNo == string.Empty)
            {
                MessageBox.Show("请输入发票号。");
                return;
            }
            DataTable dt = this.m_objManage.GetPatInfoByInvo(invoNo);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("查无数据。");
                return;
            }
            DataRow dr = dt.Rows[0];
            if (this.m_objManage.IsWechatBanding(dr["patientcardid_chr"].ToString()))
            {
                try
                {
                    string xmlData = string.Empty;
                    xmlData += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine;
                    xmlData += "<req>" + Environment.NewLine;
                    xmlData += string.Format("<eventNo>{0}</eventNo>", "41332004416") + Environment.NewLine;
                    xmlData += string.Format("<eventType>{0}</eventType>", "sendDrugReminder") + Environment.NewLine;
                    xmlData += "<eventData>" + Environment.NewLine;
                    xmlData += string.Format("<patientId>{0}</patientId>", dr["patientid_chr"].ToString()) + Environment.NewLine;
                    xmlData += string.Format("<patientName>{0}</patientName>", dr["patientname_chr"].ToString().Trim()) + Environment.NewLine;
                    xmlData += string.Format("<healthCardNo>{0}</healthCardNo>", dr["patientcardid_chr"].ToString()) + Environment.NewLine;
                    xmlData += string.Format("<prescriptionId>{0}</prescriptionId>", dr["seqid_chr"].ToString()) + Environment.NewLine;
                    xmlData += string.Format("<sendTime>{0}</sendTime>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + Environment.NewLine;
                    xmlData += "</eventData>" + Environment.NewLine;
                    xmlData += "</req>" + Environment.NewLine;

                    byte[] dataArray = System.Text.Encoding.Default.GetBytes(xmlData);
                    //创建请求
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.WechatWebUrl);
                    request.Method = "POST";
                    request.ContentLength = dataArray.Length;
                    //创建输入流
                    Stream dataStream = null;
                    try
                    {
                        dataStream = request.GetRequestStream();
                    }
                    catch
                    {
                        return;
                    }
                    //发送请求
                    dataStream.Write(dataArray, 0, dataArray.Length);
                    dataStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("诊疗卡未进行微信绑定。");
            }
        }
        #endregion

        #region Led

        #region 从本地配置文件读取参数值
        /// <summary>
        /// 从本地配置文件读取参数值
        /// </summary>
        /// <param name="p_strNode"></param>
        /// <param name="p_strKey"></param>
        /// <returns></returns>
        string ReadConfigXml(string node)
        {
            string strValue = string.Empty;
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                string strFile = Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName + @"\OpMedStoreLed.xml";
                if (!System.IO.File.Exists(strFile))
                {
                    try
                    {
                        strFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\OpMedStoreLed.xml";
                        if (!System.IO.File.Exists(strFile))
                        {
                            strFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\OpMedStoreLed.xml";
                        }
                    }
                    catch
                    {

                        strFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\OpMedStoreLed.xml";
                    }
                }
                if (!System.IO.File.Exists(strFile)) return string.Empty;
                System.Xml.XmlElement element = null;
                doc.Load(strFile);

                element = doc["configuration"]["Client"][node];
                if (element != null)
                {
                    strValue = element.InnerText.Trim();
                }
            }
            catch (Exception ex)
            {
                strValue = string.Empty;
            }
            finally
            {
                doc = null;
            }
            return strValue;
        }
        #endregion

        #region 初始化Led

        /// <summary>
        /// IP地址
        /// </summary>
        string socketServerIp { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        string socketServerPort { get; set; }

        /// <summary>
        /// 初始化Led
        /// </summary>
        internal void InitLed()
        {
            if (File.Exists(Application.StartupPath + "\\OpMedStoreLed.xml"))
            {
                socketServerIp = ReadConfigXml("socketServerIp");
                socketServerPort = ReadConfigXml("socketServerPort");
                m_objViewer.lblWechatCode.Text = m_objViewer.statusWindows.statusTone == 1 ? "配药上屏扫码处:" : "发药下屏扫码处:";
            }
        }
        #endregion

        #region Led.SocketMsg
        /// <summary>
        /// Led.SocketMsg
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="recipeId"></param>
        internal void LedSocketMsg(int typeId, string recipeId)
        {
            if (!string.IsNullOrEmpty(socketServerIp) && !string.IsNullOrEmpty(recipeId))
            {
                clsMedStorePatientListInfo patVo = null;
                DataTable dtMed = m_objManage.GetSendMedInfo(recipeId);
                if (dtMed == null || dtMed.Rows.Count == 0) return;
                if (patVo == null)
                {
                    DataRow[] drr = dtMed.Select("medstoreid = '" + this.m_objViewer.statusWindows.strStorageID + "'");
                    if (drr == null || drr.Length == 0) return;
                    patVo = new clsMedStorePatientListInfo();
                    patVo.m_strSID_INT = drr[0]["sid_int"].ToString();
                    patVo.m_strSENDWINDOWID = drr[0]["sendwindowid"].ToString();
                    patVo.m_strMEDSTOREID_CHR = drr[0]["medstoreid"].ToString();
                    patVo.m_datBIRTH_DAT = Convert.ToDateTime(drr[0]["birthday"].ToString());
                }
                if (this.m_objViewer.cbWindows.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("当前配发药窗口不能为空，请选择。");
                    this.m_objViewer.cbWindows.Focus();
                    return;
                }
                string winNo = this.m_objViewer.cbWindows.Text.Replace("配药", "").Replace("发药", "").Trim();

                string funcCode = string.Empty;
                if (typeId == 1)    // 挂起
                {
                    funcCode = "2";
                }
                else
                {
                    funcCode = m_objViewer.statusWindows.statusTone == 1 ? "1" : "0";

                    // 配药上屏检查，防止药已发但扔上屏，导致不能下屏
                    if (funcCode == "1" && !string.IsNullOrEmpty(patVo.m_strSID_INT))
                    {
                        if (m_objManage.IsSendMed(patVo.m_strSID_INT))  // 已发药
                        {
                            return;
                        }
                    }
                }
                // 特殊人群判断
                int isSpec = 0;
                // 条件1:60岁以上人群
                if (((DateTime.Now.Subtract(patVo.m_datBIRTH_DAT)).TotalDays / 365) >= 60)
                {
                    isSpec = 1;
                }
                StringBuilder takeXml = new StringBuilder();
                takeXml.AppendLine("<request>");
                takeXml.AppendLine(string.Format("<aFn>{0}</aFn>", funcCode));     // 功能码: 0 发药下屏; 1 配药上屏; 2 挂起
                takeXml.AppendLine(string.Format("<cardNo>{0}</cardNo>", recipeId));
                takeXml.AppendLine(string.Format("<name>{0}</name>", dtMed.Rows[0]["patname"].ToString()));
                takeXml.AppendLine(string.Format("<recipeId>{0}</recipeId>", dtMed.Rows[0]["recipeid"].ToString()));
                takeXml.AppendLine(string.Format("<windNo>{0}</windNo>", winNo));
                takeXml.AppendLine(string.Format("<isSpec>{0}</isSpec>", isSpec));
                takeXml.AppendLine("</request>");

                try
                {
                    //连接到的目标IP
                    IPAddress ip = IPAddress.Parse(this.socketServerIp);
                    //连接到目标IP的哪个应用(端口号)
                    IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(this.socketServerPort));
                    //连接到服务器
                    using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        client.Connect(point);
                        byte[] buffer = Encoding.UTF8.GetBytes(takeXml.ToString());
                        client.Send(buffer);
                    }
                    if (funcCode == "1")
                    {
                        // 更新LED上屏信息
                        for (int i = 0; i < this.m_objViewer.lvLED.Items.Count; i++)
                        {
                            if (this.m_objViewer.lvLED.Items[i].Tag.ToString() == patVo.m_strSID_INT)
                            {
                                this.m_objViewer.lvLED.Items[i].SubItems[0].Text = "已上屏";
                                this.m_objViewer.lvLED.Items[i].BackColor = Color.DarkOrange;
                            }
                        }
                    }
                    //if (funcCode == "0")
                    //{
                    this.m_objViewer.txtWechatCode.Text = string.Empty;
                    //}
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("发药屏异常信息：\r\n" + ex.Message);
                }
            }
        }
        #endregion

        #region Barcode2Sendmed
        /// <summary>
        /// Barcode2Sendmed
        /// </summary>
        /// <param name="recipeId"></param>
        internal void Barcode2Sendmed(string recipeId)
        {
            DataTable dtMed = m_objManage.GetSendMedInfo(recipeId);
            if (dtMed == null || dtMed.Rows.Count == 0) return;
            DataRow[] drr = dtMed.Select("medstoreid = '" + this.m_objViewer.statusWindows.strStorageID + "'");
            if (drr == null || drr.Length == 0) return;
            string sid = drr[0]["sid_int"].ToString();
            bool isSelected = false;
            for (int j = 0; j < this.m_objViewer.m_lsvPatientDetial.Items.Count; j++)
            {
                if (this.m_objViewer.m_lsvPatientDetial.Items[j].SubItems[4].Text == sid)
                {
                    this.m_objViewer.m_lsvPatientDetial.Items[j].Selected = true;
                    isSelected = true;
                    break;
                }
            }
            if (isSelected)
            {
                clsOutpatientRecipe_VO[] recipeVoArr = new clsOutpatientRecipe_VO[0];
                m_objManage.m_lngGetRepiceListBySid(sid, out recipeVoArr);
                if (recipeVoArr == null || recipeVoArr.Length == 0) return;
                foreach (clsOutpatientRecipe_VO recipeVo in recipeVoArr)
                {
                    objRecipe = recipeVo;
                    this.m_mthSend(this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName, objRecipe);
                }
            }
        }
        #endregion

        #region SetHungUpBackColor
        /// <summary>
        /// SetHungUpBackColor
        /// </summary>
        internal void SetHungUpBackColor()
        {
            if (clsControlOPMedStore.lstHungUpRecipeId == null || clsControlOPMedStore.lstHungUpRecipeId.Count == 0) return;
            string recipeId = string.Empty;
            for (int i = 0; i < this.m_objViewer.m_lsvPatientDetial.Items.Count; i++)
            {
                if (this.m_objViewer.m_lsvPatientDetial.Items[i].Tag != null && this.m_objViewer.m_lsvPatientDetial.Items[i].Tag is clsMedStorePatientListInfo)
                {
                    recipeId = ((clsMedStorePatientListInfo)this.m_objViewer.m_lsvPatientDetial.Items[i].Tag).m_objRecipeList[0].m_strOUTPATRECIPEID_CHR;
                    if (clsControlOPMedStore.lstHungUpRecipeId.IndexOf(recipeId) >= 0)
                    {
                        this.m_objViewer.m_lsvPatientDetial.Items[i].ForeColor = System.Drawing.Color.DodgerBlue;
                    }
                }
            }
        }
        #endregion

        #endregion

    }
    /// <summary>
    /// 计算年龄
    /// </summary>
    public class clsConvertDateTime
    {
        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="dteBirth">出生日期</param>
        /// <returns></returns>
        public static string CalcAge(DateTime dteBirth)
        {
            return s_strCalAge(dteBirth);
        }

        #region 根据出生日期计算截止到当前日期的年龄
        /// <summary>
        /// 根据出生日期计算截止到当前日期的年龄
        /// </summary>
        /// <param name="p_strBirthDate"></param>
        /// <param name="p_intAge"></param>
        /// <param name="p_intMonth"></param>
        /// <param name="p_intDay"></param>
        /// <param name="p_intHour"></param>
        /// <param name="p_intMinute"></param>
        /// <returns></returns>
        public static string s_strCalAge(DateTime p_strBirthDate, out int p_intAge, out int p_intMonth, out int p_intDay, out int p_intHour, out int p_intMinute)
        {
            p_intAge = 0;
            p_intMonth = 0;
            p_intDay = 0;
            p_intHour = 0;
            p_intMinute = 0;

            string strAge = "未知";

            if (p_strBirthDate < DateTime.Now)
            {
                clsDomainControlOPMedStore objDcl = new clsDomainControlOPMedStore();
                DateTime dtmTime = objDcl.m_datGetServerDate();
                DateTime m_dtmBirth = p_strBirthDate;

                #region
                //描述：
                //1）、以当前时间－生日作为年龄；
                //2）、大于等于15岁的年龄，只算到岁，取整，剩余不足一年的月份丢掉；（如21岁XX月，则显示年龄为21岁即可）
                //3）、1岁以内的按xx月xx天算，取整；（如实际显示年龄为10月20天）
                //4）、1月以内的按xx天xx小时算；（如20天23小时）
                //5)、1天以内的按xx小时xx分钟算；（如23小时59分钟）
                //6)、1小时内的算到分钟（如59分钟）

                int intYear = -1;
                int intMonth = -1;
                int intDay = -1;
                int intHour = -1;
                int intMinute = -1;

                System.TimeSpan diffTS = dtmTime.Subtract(m_dtmBirth);
                if (diffTS.TotalMinutes < 60)
                {
                    intMinute = (int)diffTS.TotalMinutes;
                    if (intMinute > 0)
                    {
                        strAge = intMinute.ToString() + "分钟";
                        p_intMinute = intMinute;
                    }
                    else
                    {
                        strAge = "0分钟";
                        p_intMinute = 0;
                    }
                }
                else if (diffTS.TotalHours < 24)
                {
                    intHour = (int)diffTS.TotalHours;
                    intMinute = (int)((diffTS.TotalHours - intHour) * 60);
                    strAge = intHour.ToString() + "小时";
                    p_intHour = intHour;
                    if (intMinute > 0)
                    {
                        strAge += intMinute.ToString() + "分钟";
                        p_intMinute = intMinute;
                    }
                }
                else
                {
                    intYear = dtmTime.Year;
                    intMonth = dtmTime.Month;
                    intDay = dtmTime.Day;

                    if (intDay >= m_dtmBirth.Day)
                        intDay -= m_dtmBirth.Day;
                    else
                    {
                        if (dtmTime.Month == 1)
                        {
                            intDay += DateTime.DaysInMonth(dtmTime.Year - 1, 12) - m_dtmBirth.Day;
                            intMonth = 12;
                            intYear--;
                        }
                        else
                        {
                            intDay += DateTime.DaysInMonth(dtmTime.Year, dtmTime.Month - 1) - m_dtmBirth.Day;
                            intMonth--;
                        }
                    }
                    if (intMonth >= m_dtmBirth.Month)
                        intMonth -= m_dtmBirth.Month;
                    else
                    {
                        intMonth += 12 - m_dtmBirth.Month;
                        intYear--;
                    }
                    if (intYear >= m_dtmBirth.Year)
                        intYear -= m_dtmBirth.Year;

                    if (intYear >= 0 && intYear < 1)
                    {
                        if (intMonth == 0)
                        {
                            if (dtmTime.Hour - m_dtmBirth.Hour > 0)
                            {
                                strAge = intDay.ToString() + "天" + (dtmTime.Hour - m_dtmBirth.Hour).ToString() + "小时";
                                p_intHour = dtmTime.Hour - m_dtmBirth.Hour;
                            }
                            else
                            {
                                intDay--;
                                strAge = (intDay <= 0 ? "" : intDay.ToString() + "天") + (dtmTime.Hour + 24 - m_dtmBirth.Hour).ToString() + "小时";
                                p_intHour = dtmTime.Hour + 24 - m_dtmBirth.Hour;
                            }
                        }
                        else
                        {
                            strAge = intMonth.ToString() + "月" + (intDay == 0 ? "" : intDay.ToString() + "天");
                        }
                    }
                    else if (intYear >= 1 && intYear < 15)
                    {
                        strAge = intYear.ToString() + "岁" + intMonth.ToString() + "月";
                    }
                    else if (intYear >= 15)
                    {
                        strAge = intYear.ToString() + "岁";
                    }
                    p_intAge = intYear;
                    p_intMonth = intMonth;
                    p_intDay = intDay;
                }
                #endregion
            }
            else
            {
                strAge = "出生日期大于当前日期";
            }
            return strAge;
        }
        /// <summary>
        /// 重载，转换年龄为指定格式
        /// </summary>
        /// <param name="p_strBirthDate"></param>
        /// <returns></returns>
        public static string s_strCalAge(DateTime p_strBirthDate)
        {
            int age, mouth, day, hour, minute;
            s_strCalAge(p_strBirthDate, out age, out mouth, out day, out hour, out minute);
            if (age != 0)
            {
                return age + "岁";
            }
            else if (mouth != 0)
            {
                return mouth + "月";
            }
            else
            {
                return day + "天";
            }
        }
        #endregion
    }
}
