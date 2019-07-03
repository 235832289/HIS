using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Diagnostics;
using com.digitalwave.GUI_Base;
using com.digitalwave.Utility;
using com.digitalwave.controls;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.Template.Client;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 检验结果录入界面
    /// </summary>
    internal class frmHandInputReport : frmMDI_Child_Base
    {

        #region 私有成员

        private bool m_blnUseValueTemplate = false;
        private frmValueTemplate m_frmValue = new frmValueTemplate(); //值模板

        DataRow m_dtrCurValueTemplateRow; //使用值模板时记录当前检验项目的 Row
        private int m_intRowIndex; //使用值模板时记录当前检验项目的 RowIndex
        private string m_strSubmitDoctorId = string.Empty; //审核医生

        private static string c_strMessageBoxTitle = "iCare-整合报告处理";
        private static string c_strMessageDataErr = "操作失败!";

        private ArrayList m_arlDataColumn = new ArrayList(); //变更结果 DataGrid 的样式时作记录用.
        private clsCheckNODecoder m_objDecoder = new clsCheckNODecoder(); //进行 检验编号解码用的解码器

        private clsPreferenceReportInput m_objPreferenceStyle = new clsPreferenceReportInput(); //用户首选风格
        private clsController_HandInputReport m_objController;
        private clsTemplateClient m_objTemplate;
        private TextBox m_txtInHospitalNo;
        private Label label30;
        private TextBox m_txtSampleSearch;
        private Label label31;
        private ListView m_lsvSampleSearch;
        private ColumnHeader columnHeader1;
        private Label label32;
        private PinkieControls.ButtonXP m_cmdLogOn;
        private Label m_lblSubmitDoctor;
        private Panel panel3; //模板控件

        private DataTable dtbList; //报告单列表的数据源 

        #endregion

        #region 属  性
        /// <summary>
        /// 静态变量
        /// 用于其它窗口更新结果，激活本窗口执行刷新操作的标识值
        /// </summary>
        public static bool WYH = false;

        public bool m_blnCanModifyAcceptDat = false;

        /// <summary>
        /// 指示当前是否能使用值模板
        /// </summary>
        private bool m_BlnUseValueTemplate
        {
            set
            {
                this.m_blnUseValueTemplate = value;
                if (!this.m_blnUseValueTemplate)
                {
                    this.m_frmValue.Hide();
                }
                else
                {
                    DataView dtv = (DataView)this.m_dtgResultList.DataSource;
                    if (dtv.Count == 0)
                        return;
                    int intCurrRow = this.m_dtgResultList.CurrentCell.RowNumber;
                    if (intCurrRow < 0)
                        return;
                    int intColumn = this.m_dtgResultList.CurrentCell.ColumnNumber;
                    if (intColumn < 0)
                        return;
                    string strItemID = dtv[intCurrRow]["check_item_id_chr"].ToString().Trim();
                    string strCheckCategoryID = dtv[intCurrRow]["check_category_id_chr"].ToString().Trim();
                    string strSampleTypeID = dtv[intCurrRow]["sampletype_vchr"].ToString().Trim();
                    string strItemName = dtv[intCurrRow]["rptno_chr"].ToString().Trim();


                    if (m_dtgResultList.TableStyles[0].GridColumnStyles[intColumn].MappingName.ToLower() == "result_vchr")
                    {
                        if ((dtv[intCurrRow]["samplestatus"].ToString().Trim() == "3"
                            || dtv[intCurrRow]["samplestatus"].ToString().Trim() == "5")
                            )//&& dtv[intRow]["is_calculated_chr"].ToString().Trim() != "1" 
                        {
                            this.m_intRowIndex = intCurrRow;
                            if (!m_frmValue.m_mthShowTemplate(strItemID))
                            {
                                m_frmValue.m_mthNewTemplate(strCheckCategoryID, strSampleTypeID, strItemID, strItemName);
                            }
                        }
                    }
                }
            }
            get
            {
                return this.m_blnUseValueTemplate;
            }
        }

        #endregion

        #region FormControl

        internal System.Windows.Forms.Label lbApplDept;
        internal System.Windows.Forms.Label lbDiagnose;
        internal System.Windows.Forms.Label lbApplEmp;
        internal System.Windows.Forms.GroupBox m_grpPatientInfo;
        internal System.Windows.Forms.RichTextBox m_rtbDiagnose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal ctlLISPatientTextBox m_txtInhospNO;
        internal System.Windows.Forms.TextBox m_txtBedNO;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox m_cboAgeUnit;
        internal System.Windows.Forms.ComboBox m_cboSex;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtAge;
        internal System.Windows.Forms.TextBox m_txtPatientName;
        internal System.Windows.Forms.Label m_lblAgeTitle;
        internal System.Windows.Forms.Label lbSex;
        internal System.Windows.Forms.Label m_lblPatientName;
        internal System.Windows.Forms.TextBox m_txtAppNO;
        internal com.digitalwave.controls.ctlRichTextBox m_rtbCheckSummary;
        internal System.Windows.Forms.DataGrid m_dtgResultList;
        internal PinkieControls.ButtonXP m_btnSelectCheck;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.CheckBox m_chkEmergency;
        internal System.Windows.Forms.CheckBox m_chkSpecial;
        internal System.Windows.Forms.Label label15;
        internal PinkieControls.ButtonXP m_btnPrintReport;
        internal PinkieControls.ButtonXP m_btnSaveReport;
        internal PinkieControls.ButtonXP m_btnPreviewReport;
        internal com.digitalwave.iCare.gui.LIS.ctlLISPatientTypeComboBox m_cboPatientType;
        internal PinkieControls.ButtonXP m_btnNewApp;
        internal System.Windows.Forms.DateTimePicker m_dtpReportDate;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtAppDoct;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtReportDoct;
        internal com.digitalwave.Utility.ctlDeptTextBox m_txtAppDept;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.RichTextBox m_rtbAppSummary;
        internal System.Windows.Forms.Panel m_palReportInfo;
        internal System.Windows.Forms.DateTimePicker m_dtpAppDate;
        internal System.Windows.Forms.Panel m_palButtom;
        internal PinkieControls.ButtonXP m_btnDelete;
        internal PinkieControls.ButtonXP m_btnConfirmReport;
        private System.Windows.Forms.ContextMenu m_ctmnuRichTextBox;
        private System.Windows.Forms.MenuItem m_mnuCopy;
        private System.Windows.Forms.MenuItem m_mnuDelete;
        private System.Windows.Forms.MenuItem m_mnuCut;
        private System.Windows.Forms.MenuItem m_mnuPaste;
        private System.Windows.Forms.MenuItem m_mnuNewTemplate;
        private System.Windows.Forms.MenuItem m_mnuDoubleDelete;
        private System.Windows.Forms.MenuItem m_mnuSpDelete;
        private System.Windows.Forms.MenuItem m_mnuSpNewTemplate;
        private System.Windows.Forms.MenuItem m_mnuUndo;
        private System.Windows.Forms.MenuItem m_mnuSelectAll;
        private System.Windows.Forms.MenuItem m_mnuSpUndo;
        private System.Windows.Forms.MenuItem m_mnuSpSelectAll;
        private System.Windows.Forms.MenuItem m_mnuSpDoubleDelete;
        internal System.Windows.Forms.GroupBox m_grpQry;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox m_txtPatientNameQuery;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker m_dtpFromDate;
        internal System.Windows.Forms.DateTimePicker m_dtpToDate;
        internal PinkieControls.ButtonXP m_btnQuery;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel m_palMRL;
        internal PinkieControls.ButtonXP m_btnPreference;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox m_txtBarCodeQuery;
        internal System.Windows.Forms.TextBox m_txtCheckNO;
        private System.Windows.Forms.Label label27;
        internal PinkieControls.ButtonXP m_btnModiryApp;
        internal PinkieControls.ButtonXP m_btnSaveApp;
        internal System.Windows.Forms.ContextMenu m_ctmnuGrid;
        private System.Windows.Forms.MenuItem m_mnuValueTemplate;
        internal System.Windows.Forms.ListView m_lsvSampleGroupQuery;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        internal System.Windows.Forms.Panel m_palRight;
        internal System.Windows.Forms.Panel m_palMiddle;
        internal System.Windows.Forms.Panel m_pal_SampleList;
        internal System.Windows.Forms.TabControl m_tabSampleInfo;
        internal System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.Panel m_pal_SampleInfo;
        internal System.Windows.Forms.GroupBox m_grbRelation;
        internal PinkieControls.ButtonXP m_btnSyncretize;
        internal PinkieControls.ButtonXP m_btnModifyBind;
        internal System.Windows.Forms.TextBox m_txtBindSate;
        internal System.Windows.Forms.Label label25;
        internal System.Windows.Forms.TextBox m_txtDeviceSampleID;
        internal com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox m_cboCheckDeviceList;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.DateTimePicker m_dtpCheckDate;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label19;
        internal PinkieControls.ButtonXP m_btnConfirmBind;
        private System.Windows.Forms.Label label23;
        internal com.digitalwave.iCare.gui.LIS.ctlLISSampleTypeComboBox m_cboSampleType;
        internal System.Windows.Forms.TextBox m_txtBarCode;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox m_txtAuditingStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TabControl m_tabControlSample;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TabControl m_tabControlFunc;
        internal System.Windows.Forms.TabPage m_tabAppList;
        internal System.Windows.Forms.TabPage m_tabQuery;
        internal System.Windows.Forms.TabControl m_tabControlWorkArea;
        internal System.Windows.Forms.TabPage m_tabCheckResult;
        internal System.Windows.Forms.TabPage m_tabReport;
        internal System.Windows.Forms.Panel m_palLeft;
        internal System.Windows.Forms.Panel m_palBaseInfoInput;
        private System.Windows.Forms.Panel m_palBindInput;
        private System.Windows.Forms.Panel m_palSampleControl;
        private System.Windows.Forms.Button m_btnAddDeviceSample;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button m_btnDeleteDeviceSample;
        private System.Windows.Forms.Panel m_palAddSample;
        internal PinkieControls.ButtonXP m_btnExtEditModel;
        internal PinkieControls.ButtonXP m_btnInputGroup;
        private System.Windows.Forms.Panel m_palExtEdit;
        internal System.Windows.Forms.CheckBox m_chkUseDefault;
        internal PinkieControls.ButtonXP m_btnImportNewResult;
        internal PinkieControls.ButtonXP m_btnImportData;
        private System.Windows.Forms.TreeView m_trvSampleGroup;
        internal PinkieControls.ButtonXP buttonXP1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        internal com.digitalwave.controls.ctlRichTextBox m_rtbAnnotation;
        private System.Windows.Forms.Panel m_palSummary;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox m_txtPatientID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage m_tabGraph;
        private System.Windows.Forms.Panel m_palGraph;

        internal System.Windows.Forms.ListView m_lsvGraph;
        internal System.Windows.Forms.ImageList m_imgGraphList;
        internal PinkieControls.ButtonXP m_btnSendMessage;
        internal System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label28;
        internal System.Windows.Forms.TextBox m_txtChargeState;
        private System.Windows.Forms.Label label26;
        internal System.Windows.Forms.ComboBox m_cboConfirmState;
        private PinkieControls.ButtonXP btnBlankOut;
        private TextBox m_txtPatientCheckNO;
        internal Label label29;
        internal DataGridView m_dtgReportList;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn CheckNO;
        private DataGridViewTextBoxColumn PatientName;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn PatientCardNO;
        private DataGridViewTextBoxColumn AcceptDate;
        private DataGridViewTextBoxColumn Tag;
        private PinkieControls.ButtonXP m_cmdLogOff;
        private PinkieControls.ButtonXP btnExit;
        internal DateTimePicker m_dtpAcceptDate;
        private PinkieControls.ButtonXP m_btnCancelConfim;
        internal ComboBox m_cboCheckCategory;
        private Label label33;
        internal clsCardTextBox m_txtPatientCardNO;
        internal clsCardTextBox m_txtPatientCard;
        private PinkieControls.ButtonXP btnCriHistory;
        internal BackgroundWorker backgroundWorker;
        internal PinkieControls.ButtonXP btnQuery;
        private TabPage pageHistory;
        internal DataGridView gvHistory;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn CheckNO2;
        private DataGridViewTextBoxColumn PatientName2;
        private DataGridViewTextBoxColumn Status2;
        private DataGridViewTextBoxColumn ItemName2;
        private DataGridViewTextBoxColumn PatientCardNO2;
        private DataGridViewTextBoxColumn AcceptDate2;
        private DataGridViewTextBoxColumn Tag2;

        private System.ComponentModel.IContainer components;

        #endregion

        #region 构造函数

        public frmHandInputReport()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            m_objController = (clsController_HandInputReport)this.objController;

            #region 值模板

            m_frmValue.evtValueReturn += new dlgValueReturnEventHandler(m_frmValue_evtValueReturn);
            m_frmValue.Location = new Point(620, 50);
            m_frmValue.Owner = this;

            #endregion

            dtbList = new DataTable("ReportList");
            dtbList.Columns.Add("CheckNO", typeof(string));
            dtbList.Columns.Add("PatientName", typeof(string));
            dtbList.Columns.Add("Status", typeof(string));
            dtbList.Columns.Add("ItemName", typeof(string));
            dtbList.Columns.Add("PatientCardNO", typeof(string));
            dtbList.Columns.Add("AcceptDate", typeof(string));
            dtbList.Columns.Add("Tag", typeof(object));

            m_dtgReportList.DataSource = dtbList;
        }

        #endregion

        #region Override

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.LIS.clsController_HandInputReport();
            this.objController.Set_GUI_Apperance(this);
        }

        #endregion

        #region Windows Form Designer generated code



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHandInputReport));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("445", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("4545", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("", 2);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_ctmnuGrid = new System.Windows.Forms.ContextMenu();
            this.m_mnuValueTemplate = new System.Windows.Forms.MenuItem();
            this.m_imgGraphList = new System.Windows.Forms.ImageList(this.components);
            this.m_ctmnuRichTextBox = new System.Windows.Forms.ContextMenu();
            this.m_mnuUndo = new System.Windows.Forms.MenuItem();
            this.m_mnuSpUndo = new System.Windows.Forms.MenuItem();
            this.m_mnuCut = new System.Windows.Forms.MenuItem();
            this.m_mnuCopy = new System.Windows.Forms.MenuItem();
            this.m_mnuPaste = new System.Windows.Forms.MenuItem();
            this.m_mnuDelete = new System.Windows.Forms.MenuItem();
            this.m_mnuSpDelete = new System.Windows.Forms.MenuItem();
            this.m_mnuSelectAll = new System.Windows.Forms.MenuItem();
            this.m_mnuSpSelectAll = new System.Windows.Forms.MenuItem();
            this.m_mnuDoubleDelete = new System.Windows.Forms.MenuItem();
            this.m_mnuSpDoubleDelete = new System.Windows.Forms.MenuItem();
            this.m_mnuNewTemplate = new System.Windows.Forms.MenuItem();
            this.m_mnuSpNewTemplate = new System.Windows.Forms.MenuItem();
            this.m_palMiddle = new System.Windows.Forms.Panel();
            this.m_palMRL = new System.Windows.Forms.Panel();
            this.m_btnInputGroup = new PinkieControls.ButtonXP();
            this.m_palExtEdit = new System.Windows.Forms.Panel();
            this.m_btnExtEditModel = new PinkieControls.ButtonXP();
            this.m_tabControlWorkArea = new System.Windows.Forms.TabControl();
            this.m_tabCheckResult = new System.Windows.Forms.TabPage();
            this.btnBlankOut = new PinkieControls.ButtonXP();
            this.m_txtPatientID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_dtgResultList = new System.Windows.Forms.DataGrid();
            this.m_tabGraph = new System.Windows.Forms.TabPage();
            this.m_palGraph = new System.Windows.Forms.Panel();
            this.m_lsvGraph = new System.Windows.Forms.ListView();
            this.m_tabReport = new System.Windows.Forms.TabPage();
            this.m_palSummary = new System.Windows.Forms.Panel();
            this.m_rtbCheckSummary = new com.digitalwave.controls.ctlRichTextBox();
            this.m_rtbAnnotation = new com.digitalwave.controls.ctlRichTextBox();
            this.m_palLeft = new System.Windows.Forms.Panel();
            this.m_txtChargeState = new System.Windows.Forms.TextBox();
            this.m_dtpAcceptDate = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.m_grpPatientInfo = new System.Windows.Forms.GroupBox();
            this.m_txtCheckNO = new System.Windows.Forms.TextBox();
            this.m_chkUseDefault = new System.Windows.Forms.CheckBox();
            this.m_palBaseInfoInput = new System.Windows.Forms.Panel();
            this.m_txtPatientCard = new com.digitalwave.controls.clsCardTextBox();
            this.m_txtAppDoct = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_rtbAppSummary = new System.Windows.Forms.RichTextBox();
            this.m_dtpAppDate = new System.Windows.Forms.DateTimePicker();
            this.m_txtAge = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtBedNO = new System.Windows.Forms.TextBox();
            this.m_cboSex = new System.Windows.Forms.ComboBox();
            this.m_txtInhospNO = new com.digitalwave.iCare.gui.LIS.ctlLISPatientTextBox();
            this.m_txtPatientName = new System.Windows.Forms.TextBox();
            this.m_txtAppDept = new com.digitalwave.Utility.ctlDeptTextBox();
            this.m_chkEmergency = new System.Windows.Forms.CheckBox();
            this.m_cboSampleType = new com.digitalwave.iCare.gui.LIS.ctlLISSampleTypeComboBox();
            this.m_chkSpecial = new System.Windows.Forms.CheckBox();
            this.m_cboAgeUnit = new System.Windows.Forms.ComboBox();
            this.m_rtbDiagnose = new System.Windows.Forms.RichTextBox();
            this.m_btnSelectCheck = new PinkieControls.ButtonXP();
            this.m_cboPatientType = new com.digitalwave.iCare.gui.LIS.ctlLISPatientTypeComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDiagnose = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.m_btnModiryApp = new PinkieControls.ButtonXP();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_btnSaveApp = new PinkieControls.ButtonXP();
            this.lbApplEmp = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbApplDept = new System.Windows.Forms.Label();
            this.m_lblPatientName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbSex = new System.Windows.Forms.Label();
            this.m_lblAgeTitle = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.m_palReportInfo = new System.Windows.Forms.Panel();
            this.m_txtReportDoct = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtAuditingStatus = new System.Windows.Forms.TextBox();
            this.m_txtBarCode = new System.Windows.Forms.TextBox();
            this.m_txtAppNO = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_palRight = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtBarCodeQuery = new System.Windows.Forms.TextBox();
            this.m_tabControlFunc = new System.Windows.Forms.TabControl();
            this.m_tabQuery = new System.Windows.Forms.TabPage();
            this.m_grpQry = new System.Windows.Forms.GroupBox();
            this.btnQuery = new PinkieControls.ButtonXP();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.btnCriHistory = new PinkieControls.ButtonXP();
            this.m_txtPatientCardNO = new com.digitalwave.controls.clsCardTextBox();
            this.m_cboCheckCategory = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.m_lsvSampleSearch = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSampleSearch = new System.Windows.Forms.TextBox();
            this.m_txtInHospitalNo = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.m_btnSendMessage = new PinkieControls.ButtonXP();
            this.label29 = new System.Windows.Forms.Label();
            this.m_txtPatientCheckNO = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_cboConfirmState = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_trvSampleGroup = new System.Windows.Forms.TreeView();
            this.m_lsvSampleGroupQuery = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtPatientNameQuery = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.m_tabAppList = new System.Windows.Forms.TabPage();
            this.m_dtgReportList = new System.Windows.Forms.DataGridView();
            this.CheckNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientCardNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcceptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_pal_SampleList = new System.Windows.Forms.Panel();
            this.m_palSampleControl = new System.Windows.Forms.Panel();
            this.m_tabControlSample = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_palAddSample = new System.Windows.Forms.Panel();
            this.m_btnDeleteDeviceSample = new System.Windows.Forms.Button();
            this.m_btnAddDeviceSample = new System.Windows.Forms.Button();
            this.m_tabSampleInfo = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_pal_SampleInfo = new System.Windows.Forms.Panel();
            this.m_grbRelation = new System.Windows.Forms.GroupBox();
            this.m_btnImportNewResult = new PinkieControls.ButtonXP();
            this.m_palBindInput = new System.Windows.Forms.Panel();
            this.m_cboCheckDeviceList = new com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox();
            this.m_dtpCheckDate = new System.Windows.Forms.DateTimePicker();
            this.m_txtDeviceSampleID = new System.Windows.Forms.TextBox();
            this.m_btnSyncretize = new PinkieControls.ButtonXP();
            this.m_btnModifyBind = new PinkieControls.ButtonXP();
            this.label25 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_btnConfirmBind = new PinkieControls.ButtonXP();
            this.m_txtBindSate = new System.Windows.Forms.TextBox();
            this.m_btnImportData = new PinkieControls.ButtonXP();
            this.pageHistory = new System.Windows.Forms.TabPage();
            this.gvHistory = new System.Windows.Forms.DataGridView();
            this.CheckNO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientCardNO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcceptDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_palButtom = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_btnCancelConfim = new PinkieControls.ButtonXP();
            this.btnExit = new PinkieControls.ButtonXP();
            this.m_cmdLogOff = new PinkieControls.ButtonXP();
            this.m_btnDelete = new PinkieControls.ButtonXP();
            this.m_cmdLogOn = new PinkieControls.ButtonXP();
            this.label32 = new System.Windows.Forms.Label();
            this.m_btnPreviewReport = new PinkieControls.ButtonXP();
            this.m_btnNewApp = new PinkieControls.ButtonXP();
            this.m_lblSubmitDoctor = new System.Windows.Forms.Label();
            this.m_btnPrintReport = new PinkieControls.ButtonXP();
            this.m_btnConfirmReport = new PinkieControls.ButtonXP();
            this.m_btnSaveReport = new PinkieControls.ButtonXP();
            this.m_btnPreference = new PinkieControls.ButtonXP();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_palMiddle.SuspendLayout();
            this.m_palMRL.SuspendLayout();
            this.m_tabControlWorkArea.SuspendLayout();
            this.m_tabCheckResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgResultList)).BeginInit();
            this.m_tabGraph.SuspendLayout();
            this.m_palGraph.SuspendLayout();
            this.m_tabReport.SuspendLayout();
            this.m_palSummary.SuspendLayout();
            this.m_palLeft.SuspendLayout();
            this.m_grpPatientInfo.SuspendLayout();
            this.m_palBaseInfoInput.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_palReportInfo.SuspendLayout();
            this.m_palRight.SuspendLayout();
            this.m_tabControlFunc.SuspendLayout();
            this.m_tabQuery.SuspendLayout();
            this.m_grpQry.SuspendLayout();
            this.m_tabAppList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgReportList)).BeginInit();
            this.m_pal_SampleList.SuspendLayout();
            this.m_palSampleControl.SuspendLayout();
            this.m_tabControlSample.SuspendLayout();
            this.m_palAddSample.SuspendLayout();
            this.m_tabSampleInfo.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.m_pal_SampleInfo.SuspendLayout();
            this.m_grbRelation.SuspendLayout();
            this.m_palBindInput.SuspendLayout();
            this.pageHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).BeginInit();
            this.m_palButtom.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ctmnuGrid
            // 
            this.m_ctmnuGrid.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mnuValueTemplate});
            // 
            // m_mnuValueTemplate
            // 
            this.m_mnuValueTemplate.Index = 0;
            this.m_mnuValueTemplate.Text = "值模板";
            this.m_mnuValueTemplate.Click += new System.EventHandler(this.m_mnuValueTemplate_Click);
            // 
            // m_imgGraphList
            // 
            this.m_imgGraphList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgGraphList.ImageStream")));
            this.m_imgGraphList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imgGraphList.Images.SetKeyName(0, "");
            this.m_imgGraphList.Images.SetKeyName(1, "");
            this.m_imgGraphList.Images.SetKeyName(2, "");
            // 
            // m_ctmnuRichTextBox
            // 
            this.m_ctmnuRichTextBox.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mnuUndo,
            this.m_mnuSpUndo,
            this.m_mnuCut,
            this.m_mnuCopy,
            this.m_mnuPaste,
            this.m_mnuDelete,
            this.m_mnuSpDelete,
            this.m_mnuSelectAll,
            this.m_mnuSpSelectAll,
            this.m_mnuDoubleDelete,
            this.m_mnuSpDoubleDelete,
            this.m_mnuNewTemplate,
            this.m_mnuSpNewTemplate});
            this.m_ctmnuRichTextBox.Popup += new System.EventHandler(this.m_ctmnuRichTextBox_Popup);
            // 
            // m_mnuUndo
            // 
            this.m_mnuUndo.Index = 0;
            this.m_mnuUndo.Text = "撤消(&Z)";
            this.m_mnuUndo.Click += new System.EventHandler(this.m_mnuUndo_Click);
            // 
            // m_mnuSpUndo
            // 
            this.m_mnuSpUndo.Index = 1;
            this.m_mnuSpUndo.Text = "-";
            // 
            // m_mnuCut
            // 
            this.m_mnuCut.Index = 2;
            this.m_mnuCut.Text = "剪切(&X)";
            this.m_mnuCut.Click += new System.EventHandler(this.m_mnuCut_Click);
            // 
            // m_mnuCopy
            // 
            this.m_mnuCopy.Index = 3;
            this.m_mnuCopy.Text = "复制(&C)";
            this.m_mnuCopy.Click += new System.EventHandler(this.m_mnuCopy_Click);
            // 
            // m_mnuPaste
            // 
            this.m_mnuPaste.Index = 4;
            this.m_mnuPaste.Text = "粘贴(&V)";
            this.m_mnuPaste.Click += new System.EventHandler(this.m_mnuPaste_Click);
            // 
            // m_mnuDelete
            // 
            this.m_mnuDelete.Index = 5;
            this.m_mnuDelete.Text = "删除(&D)";
            this.m_mnuDelete.Click += new System.EventHandler(this.m_mnuDelete_Click);
            // 
            // m_mnuSpDelete
            // 
            this.m_mnuSpDelete.Index = 6;
            this.m_mnuSpDelete.Text = "-";
            // 
            // m_mnuSelectAll
            // 
            this.m_mnuSelectAll.Index = 7;
            this.m_mnuSelectAll.Text = "全选(&A)";
            this.m_mnuSelectAll.Click += new System.EventHandler(this.m_mnuSelectAll_Click);
            // 
            // m_mnuSpSelectAll
            // 
            this.m_mnuSpSelectAll.Index = 8;
            this.m_mnuSpSelectAll.Text = "-";
            // 
            // m_mnuDoubleDelete
            // 
            this.m_mnuDoubleDelete.Index = 9;
            this.m_mnuDoubleDelete.Text = "双划线删除";
            this.m_mnuDoubleDelete.Click += new System.EventHandler(this.m_mnuDoubleDelete_Click);
            // 
            // m_mnuSpDoubleDelete
            // 
            this.m_mnuSpDoubleDelete.Index = 10;
            this.m_mnuSpDoubleDelete.Text = "-";
            // 
            // m_mnuNewTemplate
            // 
            this.m_mnuNewTemplate.Index = 11;
            this.m_mnuNewTemplate.Text = "新增模板";
            this.m_mnuNewTemplate.Click += new System.EventHandler(this.m_mnuNewTemplate_Click);
            // 
            // m_mnuSpNewTemplate
            // 
            this.m_mnuSpNewTemplate.Index = 12;
            this.m_mnuSpNewTemplate.Text = "-";
            // 
            // m_palMiddle
            // 
            this.m_palMiddle.Controls.Add(this.m_palMRL);
            this.m_palMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palMiddle.Location = new System.Drawing.Point(216, 0);
            this.m_palMiddle.Name = "m_palMiddle";
            this.m_palMiddle.Size = new System.Drawing.Size(484, 557);
            this.m_palMiddle.TabIndex = 10;
            // 
            // m_palMRL
            // 
            this.m_palMRL.Controls.Add(this.m_btnInputGroup);
            this.m_palMRL.Controls.Add(this.m_palExtEdit);
            this.m_palMRL.Controls.Add(this.m_btnExtEditModel);
            this.m_palMRL.Controls.Add(this.m_tabControlWorkArea);
            this.m_palMRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palMRL.Location = new System.Drawing.Point(0, 0);
            this.m_palMRL.Name = "m_palMRL";
            this.m_palMRL.Size = new System.Drawing.Size(484, 557);
            this.m_palMRL.TabIndex = 11;
            // 
            // m_btnInputGroup
            // 
            this.m_btnInputGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnInputGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnInputGroup.DefaultScheme = true;
            this.m_btnInputGroup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnInputGroup.Font = new System.Drawing.Font("宋体", 10F);
            this.m_btnInputGroup.Hint = "";
            this.m_btnInputGroup.Location = new System.Drawing.Point(263, 0);
            this.m_btnInputGroup.Name = "m_btnInputGroup";
            this.m_btnInputGroup.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnInputGroup.Size = new System.Drawing.Size(82, 21);
            this.m_btnInputGroup.TabIndex = 22;
            this.m_btnInputGroup.Text = "录入组合";
            this.m_btnInputGroup.Click += new System.EventHandler(this.m_btnInputGroup_Click);
            // 
            // m_palExtEdit
            // 
            this.m_palExtEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_palExtEdit.Location = new System.Drawing.Point(306, 2);
            this.m_palExtEdit.Name = "m_palExtEdit";
            this.m_palExtEdit.Size = new System.Drawing.Size(22, 16);
            this.m_palExtEdit.TabIndex = 11;
            this.m_palExtEdit.Visible = false;
            // 
            // m_btnExtEditModel
            // 
            this.m_btnExtEditModel.AccessibleDescription = "Normal";
            this.m_btnExtEditModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExtEditModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnExtEditModel.DefaultScheme = true;
            this.m_btnExtEditModel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExtEditModel.Hint = "";
            this.m_btnExtEditModel.Location = new System.Drawing.Point(410, 2);
            this.m_btnExtEditModel.Name = "m_btnExtEditModel";
            this.m_btnExtEditModel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExtEditModel.Size = new System.Drawing.Size(64, 18);
            this.m_btnExtEditModel.TabIndex = 11;
            this.m_btnExtEditModel.Text = ">>";
            this.m_btnExtEditModel.Click += new System.EventHandler(this.m_btnExtEditModel_Click);
            // 
            // m_tabControlWorkArea
            // 
            this.m_tabControlWorkArea.Controls.Add(this.m_tabCheckResult);
            this.m_tabControlWorkArea.Controls.Add(this.m_tabGraph);
            this.m_tabControlWorkArea.Controls.Add(this.m_tabReport);
            this.m_tabControlWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControlWorkArea.Location = new System.Drawing.Point(0, 0);
            this.m_tabControlWorkArea.Name = "m_tabControlWorkArea";
            this.m_tabControlWorkArea.SelectedIndex = 0;
            this.m_tabControlWorkArea.Size = new System.Drawing.Size(484, 557);
            this.m_tabControlWorkArea.TabIndex = 21;
            // 
            // m_tabCheckResult
            // 
            this.m_tabCheckResult.Controls.Add(this.btnBlankOut);
            this.m_tabCheckResult.Controls.Add(this.m_txtPatientID);
            this.m_tabCheckResult.Controls.Add(this.label14);
            this.m_tabCheckResult.Controls.Add(this.m_dtgResultList);
            this.m_tabCheckResult.Location = new System.Drawing.Point(4, 24);
            this.m_tabCheckResult.Name = "m_tabCheckResult";
            this.m_tabCheckResult.Size = new System.Drawing.Size(476, 529);
            this.m_tabCheckResult.TabIndex = 0;
            this.m_tabCheckResult.Text = "项目结果";
            // 
            // btnBlankOut
            // 
            this.btnBlankOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnBlankOut.DefaultScheme = true;
            this.btnBlankOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBlankOut.Hint = "";
            this.btnBlankOut.Location = new System.Drawing.Point(221, 521);
            this.btnBlankOut.Name = "btnBlankOut";
            this.btnBlankOut.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnBlankOut.Size = new System.Drawing.Size(100, 29);
            this.btnBlankOut.TabIndex = 5;
            this.btnBlankOut.Text = "作废样本";
            this.btnBlankOut.Visible = false;
            this.btnBlankOut.Click += new System.EventHandler(this.btnBlankOut_Click);
            // 
            // m_txtPatientID
            // 
            this.m_txtPatientID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPatientID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPatientID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtPatientID.Location = new System.Drawing.Point(79, 524);
            this.m_txtPatientID.MaxLength = 30;
            this.m_txtPatientID.Name = "m_txtPatientID";
            this.m_txtPatientID.Size = new System.Drawing.Size(136, 23);
            this.m_txtPatientID.TabIndex = 120;
            this.m_txtPatientID.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 528);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 121;
            this.label14.Text = "病人ID";
            this.label14.Visible = false;
            // 
            // m_dtgResultList
            // 
            this.m_dtgResultList.AllowNavigation = false;
            this.m_dtgResultList.AllowSorting = false;
            this.m_dtgResultList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgResultList.CaptionVisible = false;
            this.m_dtgResultList.ContextMenu = this.m_ctmnuGrid;
            this.m_dtgResultList.DataMember = "";
            this.m_dtgResultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgResultList.FlatMode = true;
            this.m_dtgResultList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtgResultList.Location = new System.Drawing.Point(0, 0);
            this.m_dtgResultList.Name = "m_dtgResultList";
            this.m_dtgResultList.ReadOnly = true;
            this.m_dtgResultList.Size = new System.Drawing.Size(476, 529);
            this.m_dtgResultList.TabIndex = 10;
            // 
            // m_tabGraph
            // 
            this.m_tabGraph.Controls.Add(this.m_palGraph);
            this.m_tabGraph.Location = new System.Drawing.Point(4, 22);
            this.m_tabGraph.Name = "m_tabGraph";
            this.m_tabGraph.Size = new System.Drawing.Size(476, 531);
            this.m_tabGraph.TabIndex = 2;
            this.m_tabGraph.Text = "图形结果";
            // 
            // m_palGraph
            // 
            this.m_palGraph.BackColor = System.Drawing.SystemColors.Control;
            this.m_palGraph.Controls.Add(this.m_lsvGraph);
            this.m_palGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palGraph.Location = new System.Drawing.Point(0, 0);
            this.m_palGraph.Name = "m_palGraph";
            this.m_palGraph.Size = new System.Drawing.Size(476, 531);
            this.m_palGraph.TabIndex = 0;
            // 
            // m_lsvGraph
            // 
            this.m_lsvGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvGraph.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.m_lsvGraph.LargeImageList = this.m_imgGraphList;
            this.m_lsvGraph.Location = new System.Drawing.Point(0, 0);
            this.m_lsvGraph.Name = "m_lsvGraph";
            this.m_lsvGraph.Size = new System.Drawing.Size(476, 531);
            this.m_lsvGraph.TabIndex = 0;
            this.m_lsvGraph.UseCompatibleStateImageBehavior = false;
            // 
            // m_tabReport
            // 
            this.m_tabReport.Controls.Add(this.m_palSummary);
            this.m_tabReport.Location = new System.Drawing.Point(4, 22);
            this.m_tabReport.Name = "m_tabReport";
            this.m_tabReport.Size = new System.Drawing.Size(476, 531);
            this.m_tabReport.TabIndex = 1;
            this.m_tabReport.Text = "检验意见及附注";
            // 
            // m_palSummary
            // 
            this.m_palSummary.Controls.Add(this.m_rtbCheckSummary);
            this.m_palSummary.Controls.Add(this.m_rtbAnnotation);
            this.m_palSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palSummary.Location = new System.Drawing.Point(0, 0);
            this.m_palSummary.Name = "m_palSummary";
            this.m_palSummary.Size = new System.Drawing.Size(476, 531);
            this.m_palSummary.TabIndex = 12;
            // 
            // m_rtbCheckSummary
            // 
            this.m_rtbCheckSummary.AccessibleDescription = "检验意见";
            this.m_rtbCheckSummary.ContextMenu = this.m_ctmnuRichTextBox;
            this.m_rtbCheckSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_rtbCheckSummary.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_rtbCheckSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_rtbCheckSummary.Location = new System.Drawing.Point(0, 0);
            this.m_rtbCheckSummary.m_BlnIgnoreUserInfo = false;
            this.m_rtbCheckSummary.m_BlnPartControl = false;
            this.m_rtbCheckSummary.m_BlnReadOnly = false;
            this.m_rtbCheckSummary.m_BlnUnderLineDST = false;
            this.m_rtbCheckSummary.m_ClrDST = System.Drawing.Color.Red;
            this.m_rtbCheckSummary.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_rtbCheckSummary.m_IntCanModifyTime = 6;
            this.m_rtbCheckSummary.m_IntPartControlLength = 0;
            this.m_rtbCheckSummary.m_IntPartControlStartIndex = 0;
            this.m_rtbCheckSummary.m_StrUserID = "";
            this.m_rtbCheckSummary.m_StrUserName = "";
            this.m_rtbCheckSummary.MaxLength = 1000;
            this.m_rtbCheckSummary.Name = "m_rtbCheckSummary";
            this.m_rtbCheckSummary.Size = new System.Drawing.Size(476, 479);
            this.m_rtbCheckSummary.TabIndex = 10;
            this.m_rtbCheckSummary.Text = "";
            // 
            // m_rtbAnnotation
            // 
            this.m_rtbAnnotation.AccessibleDescription = "检验附注";
            this.m_rtbAnnotation.ContextMenu = this.m_ctmnuRichTextBox;
            this.m_rtbAnnotation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_rtbAnnotation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_rtbAnnotation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_rtbAnnotation.Location = new System.Drawing.Point(0, 479);
            this.m_rtbAnnotation.m_BlnIgnoreUserInfo = false;
            this.m_rtbAnnotation.m_BlnPartControl = false;
            this.m_rtbAnnotation.m_BlnReadOnly = false;
            this.m_rtbAnnotation.m_BlnUnderLineDST = false;
            this.m_rtbAnnotation.m_ClrDST = System.Drawing.Color.Red;
            this.m_rtbAnnotation.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_rtbAnnotation.m_IntCanModifyTime = 6;
            this.m_rtbAnnotation.m_IntPartControlLength = 0;
            this.m_rtbAnnotation.m_IntPartControlStartIndex = 0;
            this.m_rtbAnnotation.m_StrUserID = "";
            this.m_rtbAnnotation.m_StrUserName = "";
            this.m_rtbAnnotation.MaxLength = 1000;
            this.m_rtbAnnotation.Name = "m_rtbAnnotation";
            this.m_rtbAnnotation.Size = new System.Drawing.Size(476, 52);
            this.m_rtbAnnotation.TabIndex = 11;
            this.m_rtbAnnotation.Text = "";
            // 
            // m_palLeft
            // 
            this.m_palLeft.Controls.Add(this.m_txtChargeState);
            this.m_palLeft.Controls.Add(this.m_dtpAcceptDate);
            this.m_palLeft.Controls.Add(this.label28);
            this.m_palLeft.Controls.Add(this.m_grpPatientInfo);
            this.m_palLeft.Controls.Add(this.label23);
            this.m_palLeft.Controls.Add(this.m_palReportInfo);
            this.m_palLeft.Controls.Add(this.label10);
            this.m_palLeft.Controls.Add(this.label1);
            this.m_palLeft.Controls.Add(this.label15);
            this.m_palLeft.Controls.Add(this.label12);
            this.m_palLeft.Controls.Add(this.m_txtAuditingStatus);
            this.m_palLeft.Controls.Add(this.m_txtBarCode);
            this.m_palLeft.Controls.Add(this.m_txtAppNO);
            this.m_palLeft.Controls.Add(this.label11);
            this.m_palLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_palLeft.Location = new System.Drawing.Point(0, 0);
            this.m_palLeft.Name = "m_palLeft";
            this.m_palLeft.Size = new System.Drawing.Size(216, 557);
            this.m_palLeft.TabIndex = 0;
            this.m_palLeft.TabStop = true;
            // 
            // m_txtChargeState
            // 
            this.m_txtChargeState.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtChargeState.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtChargeState.Location = new System.Drawing.Point(72, 560);
            this.m_txtChargeState.Name = "m_txtChargeState";
            this.m_txtChargeState.ReadOnly = true;
            this.m_txtChargeState.Size = new System.Drawing.Size(136, 23);
            this.m_txtChargeState.TabIndex = 4;
            this.m_txtChargeState.TabStop = false;
            // 
            // m_dtpAcceptDate
            // 
            this.m_dtpAcceptDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dtpAcceptDate.Enabled = false;
            this.m_dtpAcceptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpAcceptDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_dtpAcceptDate.Location = new System.Drawing.Point(72, 463);
            this.m_dtpAcceptDate.Name = "m_dtpAcceptDate";
            this.m_dtpAcceptDate.Size = new System.Drawing.Size(136, 23);
            this.m_dtpAcceptDate.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 564);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 14);
            this.label28.TabIndex = 121;
            this.label28.Text = "收费状态";
            // 
            // m_grpPatientInfo
            // 
            this.m_grpPatientInfo.Controls.Add(this.m_txtCheckNO);
            this.m_grpPatientInfo.Controls.Add(this.m_chkUseDefault);
            this.m_grpPatientInfo.Controls.Add(this.m_palBaseInfoInput);
            this.m_grpPatientInfo.Controls.Add(this.panel2);
            this.m_grpPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_grpPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.m_grpPatientInfo.Name = "m_grpPatientInfo";
            this.m_grpPatientInfo.Size = new System.Drawing.Size(216, 408);
            this.m_grpPatientInfo.TabIndex = 0;
            this.m_grpPatientInfo.TabStop = false;
            this.m_grpPatientInfo.Tag = "病人基本信息";
            // 
            // m_txtCheckNO
            // 
            this.m_txtCheckNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtCheckNO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCheckNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtCheckNO.Location = new System.Drawing.Point(72, 37);
            this.m_txtCheckNO.MaxLength = 30;
            this.m_txtCheckNO.Name = "m_txtCheckNO";
            this.m_txtCheckNO.Size = new System.Drawing.Size(136, 23);
            this.m_txtCheckNO.TabIndex = 0;
            this.m_txtCheckNO.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtCheckNO_Validating);
            // 
            // m_chkUseDefault
            // 
            this.m_chkUseDefault.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkUseDefault.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_chkUseDefault.Location = new System.Drawing.Point(192, 376);
            this.m_chkUseDefault.Name = "m_chkUseDefault";
            this.m_chkUseDefault.Size = new System.Drawing.Size(16, 24);
            this.m_chkUseDefault.TabIndex = 16;
            this.m_chkUseDefault.TabStop = false;
            this.m_chkUseDefault.Text = "使用历史";
            this.m_chkUseDefault.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_chkUseDefault.CheckedChanged += new System.EventHandler(this.m_chkUseDefault_CheckedChanged);
            // 
            // m_palBaseInfoInput
            // 
            this.m_palBaseInfoInput.Controls.Add(this.m_txtPatientCard);
            this.m_palBaseInfoInput.Controls.Add(this.m_txtAppDoct);
            this.m_palBaseInfoInput.Controls.Add(this.m_rtbAppSummary);
            this.m_palBaseInfoInput.Controls.Add(this.m_dtpAppDate);
            this.m_palBaseInfoInput.Controls.Add(this.m_txtAge);
            this.m_palBaseInfoInput.Controls.Add(this.m_txtBedNO);
            this.m_palBaseInfoInput.Controls.Add(this.m_cboSex);
            this.m_palBaseInfoInput.Controls.Add(this.m_txtInhospNO);
            this.m_palBaseInfoInput.Controls.Add(this.m_txtPatientName);
            this.m_palBaseInfoInput.Controls.Add(this.m_txtAppDept);
            this.m_palBaseInfoInput.Controls.Add(this.m_chkEmergency);
            this.m_palBaseInfoInput.Controls.Add(this.m_cboSampleType);
            this.m_palBaseInfoInput.Controls.Add(this.m_chkSpecial);
            this.m_palBaseInfoInput.Controls.Add(this.m_cboAgeUnit);
            this.m_palBaseInfoInput.Controls.Add(this.m_rtbDiagnose);
            this.m_palBaseInfoInput.Controls.Add(this.m_btnSelectCheck);
            this.m_palBaseInfoInput.Controls.Add(this.m_cboPatientType);
            this.m_palBaseInfoInput.Location = new System.Drawing.Point(68, 14);
            this.m_palBaseInfoInput.Name = "m_palBaseInfoInput";
            this.m_palBaseInfoInput.Size = new System.Drawing.Size(144, 390);
            this.m_palBaseInfoInput.TabIndex = 1;
            // 
            // m_txtPatientCard
            // 
            this.m_txtPatientCard.Location = new System.Drawing.Point(4, 1);
            this.m_txtPatientCard.MaxLength = 50;
            this.m_txtPatientCard.Name = "m_txtPatientCard";
            this.m_txtPatientCard.PatientCard = "";
            this.m_txtPatientCard.PatientFlag = 0;
            this.m_txtPatientCard.Size = new System.Drawing.Size(136, 23);
            this.m_txtPatientCard.TabIndex = 0;
            this.m_txtPatientCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPatientCard.YBCardText = "";
            this.m_txtPatientCard.CardKeyDown += new com.digitalwave.controls.clsCardTextBox.TxtKeyDownHandle(this.m_txtPatientCard1_CardKeyDown);
            this.m_txtPatientCard.TextChanged += new System.EventHandler(this.m_txtPatientCard1_TextChanged);
            // 
            // m_txtAppDoct
            // 
            this.m_txtAppDoct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtAppDoct.EnableAutoValidation = true;
            this.m_txtAppDoct.EnableEnterKeyValidate = true;
            this.m_txtAppDoct.EnableEscapeKeyUndo = true;
            this.m_txtAppDoct.EnableLastValidValue = true;
            this.m_txtAppDoct.ErrorProvider = null;
            this.m_txtAppDoct.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDoct.ForceFormatText = true;
            this.m_txtAppDoct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppDoct.Location = new System.Drawing.Point(4, 238);
            this.m_txtAppDoct.m_intShowOtherEmp = 0;
            this.m_txtAppDoct.m_StrDeptID = "*";
            this.m_txtAppDoct.m_StrEmployeeID = null;
            this.m_txtAppDoct.m_StrEmployeeName = null;
            this.m_txtAppDoct.MaxLength = 20;
            this.m_txtAppDoct.Name = "m_txtAppDoct";
            this.m_txtAppDoct.Size = new System.Drawing.Size(136, 23);
            this.m_txtAppDoct.TabIndex = 10;
            // 
            // m_rtbAppSummary
            // 
            this.m_rtbAppSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rtbAppSummary.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_rtbAppSummary.Location = new System.Drawing.Point(4, 310);
            this.m_rtbAppSummary.MaxLength = 200;
            this.m_rtbAppSummary.Name = "m_rtbAppSummary";
            this.m_rtbAppSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.m_rtbAppSummary.Size = new System.Drawing.Size(136, 24);
            this.m_rtbAppSummary.TabIndex = 13;
            this.m_rtbAppSummary.TabStop = false;
            this.m_rtbAppSummary.Text = "";
            // 
            // m_dtpAppDate
            // 
            this.m_dtpAppDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_dtpAppDate.CalendarForeColor = System.Drawing.SystemColors.WindowText;
            this.m_dtpAppDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dtpAppDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpAppDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_dtpAppDate.Location = new System.Drawing.Point(4, 262);
            this.m_dtpAppDate.Name = "m_dtpAppDate";
            this.m_dtpAppDate.Size = new System.Drawing.Size(136, 23);
            this.m_dtpAppDate.TabIndex = 11;
            this.m_dtpAppDate.TabStop = false;
            // 
            // m_txtAge
            // 
            this.m_txtAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtAge.EnableAutoValidation = true;
            this.m_txtAge.EnableEnterKeyValidate = true;
            this.m_txtAge.EnableEscapeKeyUndo = true;
            this.m_txtAge.EnableLastValidValue = true;
            this.m_txtAge.ErrorProvider = null;
            this.m_txtAge.ErrorProviderMessage = "Invalid value";
            this.m_txtAge.ForceFormatText = true;
            this.m_txtAge.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAge.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtAge.Location = new System.Drawing.Point(4, 118);
            this.m_txtAge.MaxLength = 3;
            this.m_txtAge.Name = "m_txtAge";
            this.m_txtAge.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtAge.Size = new System.Drawing.Size(64, 23);
            this.m_txtAge.TabIndex = 4;
            this.m_txtAge.Text = "0";
            this.m_txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtBedNO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBedNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtBedNO.Location = new System.Drawing.Point(4, 214);
            this.m_txtBedNO.MaxLength = 4;
            this.m_txtBedNO.Name = "m_txtBedNO";
            this.m_txtBedNO.Size = new System.Drawing.Size(136, 23);
            this.m_txtBedNO.TabIndex = 9;
            // 
            // m_cboSex
            // 
            this.m_cboSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未知",
            "未明"});
            this.m_cboSex.Location = new System.Drawing.Point(4, 94);
            this.m_cboSex.Name = "m_cboSex";
            this.m_cboSex.Size = new System.Drawing.Size(136, 22);
            this.m_cboSex.TabIndex = 3;
            // 
            // m_txtInhospNO
            // 
            this.m_txtInhospNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtInhospNO.EnableAutoValidation = true;
            this.m_txtInhospNO.EnableEnterKeyValidate = true;
            this.m_txtInhospNO.EnableEscapeKeyUndo = true;
            this.m_txtInhospNO.EnableLastValidValue = true;
            this.m_txtInhospNO.ErrorProvider = null;
            this.m_txtInhospNO.ErrorProviderMessage = "Invalid value";
            this.m_txtInhospNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInhospNO.ForceFormatText = true;
            this.m_txtInhospNO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtInhospNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtInhospNO.Location = new System.Drawing.Point(4, 46);
            this.m_txtInhospNO.MaxLength = 12;
            this.m_txtInhospNO.Name = "m_txtInhospNO";
            this.m_txtInhospNO.Size = new System.Drawing.Size(136, 23);
            this.m_txtInhospNO.TabIndex = 1;
            this.m_txtInhospNO.evtValueChanged += new com.digitalwave.Utility.dlgExValueChangedEventHandler(this.m_txtInhospNO_evtValueChanged);
            this.m_txtInhospNO.TextChanged += new System.EventHandler(this.m_txtInhospNO_TextChanged);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtPatientName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPatientName.Location = new System.Drawing.Point(4, 70);
            this.m_txtPatientName.MaxLength = 50;
            this.m_txtPatientName.Name = "m_txtPatientName";
            this.m_txtPatientName.Size = new System.Drawing.Size(136, 23);
            this.m_txtPatientName.TabIndex = 2;
            // 
            // m_txtAppDept
            // 
            this.m_txtAppDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtAppDept.EnableAutoValidation = true;
            this.m_txtAppDept.EnableEnterKeyValidate = true;
            this.m_txtAppDept.EnableEscapeKeyUndo = true;
            this.m_txtAppDept.EnableLastValidValue = true;
            this.m_txtAppDept.ErrorProvider = null;
            this.m_txtAppDept.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDept.ForceFormatText = true;
            this.m_txtAppDept.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppDept.Location = new System.Drawing.Point(4, 190);
            this.m_txtAppDept.m_StrDeptID = null;
            this.m_txtAppDept.m_StrDeptName = null;
            this.m_txtAppDept.MaxLength = 20;
            this.m_txtAppDept.Name = "m_txtAppDept";
            this.m_txtAppDept.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
            this.m_txtAppDept.Size = new System.Drawing.Size(136, 23);
            this.m_txtAppDept.TabIndex = 8;
            // 
            // m_chkEmergency
            // 
            this.m_chkEmergency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkEmergency.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkEmergency.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_chkEmergency.Location = new System.Drawing.Point(0, 338);
            this.m_chkEmergency.Name = "m_chkEmergency";
            this.m_chkEmergency.Size = new System.Drawing.Size(56, 24);
            this.m_chkEmergency.TabIndex = 14;
            this.m_chkEmergency.TabStop = false;
            this.m_chkEmergency.Text = "急诊";
            this.m_chkEmergency.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_cboSampleType
            // 
            this.m_cboSampleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cboSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
            this.m_cboSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSampleType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboSampleType.Location = new System.Drawing.Point(4, 142);
            this.m_cboSampleType.Name = "m_cboSampleType";
            this.m_cboSampleType.Size = new System.Drawing.Size(136, 22);
            this.m_cboSampleType.TabIndex = 6;
            this.m_cboSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
            // 
            // m_chkSpecial
            // 
            this.m_chkSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkSpecial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkSpecial.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_chkSpecial.Location = new System.Drawing.Point(52, 338);
            this.m_chkSpecial.Name = "m_chkSpecial";
            this.m_chkSpecial.Size = new System.Drawing.Size(88, 24);
            this.m_chkSpecial.TabIndex = 15;
            this.m_chkSpecial.TabStop = false;
            this.m_chkSpecial.Text = "特殊处理";
            this.m_chkSpecial.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_cboAgeUnit
            // 
            this.m_cboAgeUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cboAgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboAgeUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboAgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.m_cboAgeUnit.Location = new System.Drawing.Point(68, 118);
            this.m_cboAgeUnit.Name = "m_cboAgeUnit";
            this.m_cboAgeUnit.Size = new System.Drawing.Size(72, 22);
            this.m_cboAgeUnit.TabIndex = 5;
            // 
            // m_rtbDiagnose
            // 
            this.m_rtbDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rtbDiagnose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_rtbDiagnose.Location = new System.Drawing.Point(4, 286);
            this.m_rtbDiagnose.MaxLength = 255;
            this.m_rtbDiagnose.Name = "m_rtbDiagnose";
            this.m_rtbDiagnose.Size = new System.Drawing.Size(136, 24);
            this.m_rtbDiagnose.TabIndex = 12;
            this.m_rtbDiagnose.Text = "";
            // 
            // m_btnSelectCheck
            // 
            this.m_btnSelectCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnSelectCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnSelectCheck.DefaultScheme = true;
            this.m_btnSelectCheck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSelectCheck.Hint = "";
            this.m_btnSelectCheck.Location = new System.Drawing.Point(8, 362);
            this.m_btnSelectCheck.Name = "m_btnSelectCheck";
            this.m_btnSelectCheck.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSelectCheck.Size = new System.Drawing.Size(116, 24);
            this.m_btnSelectCheck.TabIndex = 15;
            this.m_btnSelectCheck.Text = "检验项目(F4)";
            this.m_btnSelectCheck.Click += new System.EventHandler(this.m_btnSelectCheck_Click);
            // 
            // m_cboPatientType
            // 
            this.m_cboPatientType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cboPatientType.DisplayMember = "DICTNAME_VCHR";
            this.m_cboPatientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPatientType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboPatientType.Location = new System.Drawing.Point(4, 166);
            this.m_cboPatientType.Name = "m_cboPatientType";
            this.m_cboPatientType.Size = new System.Drawing.Size(136, 22);
            this.m_cboPatientType.TabIndex = 7;
            this.m_cboPatientType.ValueMember = "DICTID_CHR";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbDiagnose);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.m_btnModiryApp);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.m_btnSaveApp);
            this.panel2.Controls.Add(this.lbApplEmp);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.lbApplDept);
            this.panel2.Controls.Add(this.m_lblPatientName);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lbSex);
            this.panel2.Controls.Add(this.m_lblAgeTitle);
            this.panel2.Location = new System.Drawing.Point(4, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(68, 388);
            this.panel2.TabIndex = 122;
            // 
            // lbDiagnose
            // 
            this.lbDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDiagnose.AutoSize = true;
            this.lbDiagnose.Location = new System.Drawing.Point(4, 288);
            this.lbDiagnose.Name = "lbDiagnose";
            this.lbDiagnose.Size = new System.Drawing.Size(63, 14);
            this.lbDiagnose.TabIndex = 84;
            this.lbDiagnose.Text = "临床诊断";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 89;
            this.label4.Text = "住院号";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 90;
            this.label5.Text = "床号";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "标本类型";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(4, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 14);
            this.label27.TabIndex = 117;
            this.label27.Text = "检验编号";
            // 
            // m_btnModiryApp
            // 
            this.m_btnModiryApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnModiryApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnModiryApp.DefaultScheme = true;
            this.m_btnModiryApp.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnModiryApp.Enabled = false;
            this.m_btnModiryApp.Hint = "";
            this.m_btnModiryApp.Location = new System.Drawing.Point(2, 336);
            this.m_btnModiryApp.Name = "m_btnModiryApp";
            this.m_btnModiryApp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnModiryApp.Size = new System.Drawing.Size(63, 24);
            this.m_btnModiryApp.TabIndex = 3;
            this.m_btnModiryApp.Text = "修改";
            this.m_btnModiryApp.Click += new System.EventHandler(this.m_btnModiryApp_Click);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 264);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 14);
            this.label22.TabIndex = 115;
            this.label22.Text = "申请日期";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 312);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 14);
            this.label20.TabIndex = 113;
            this.label20.Text = "附加备注";
            // 
            // m_btnSaveApp
            // 
            this.m_btnSaveApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnSaveApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnSaveApp.DefaultScheme = true;
            this.m_btnSaveApp.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveApp.Enabled = false;
            this.m_btnSaveApp.Hint = "";
            this.m_btnSaveApp.Location = new System.Drawing.Point(2, 360);
            this.m_btnSaveApp.Name = "m_btnSaveApp";
            this.m_btnSaveApp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveApp.Size = new System.Drawing.Size(63, 24);
            this.m_btnSaveApp.TabIndex = 2;
            this.m_btnSaveApp.Text = "保存(F1)";
            this.m_btnSaveApp.Click += new System.EventHandler(this.m_btnSaveApp_Click);
            // 
            // lbApplEmp
            // 
            this.lbApplEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbApplEmp.AutoSize = true;
            this.lbApplEmp.Location = new System.Drawing.Point(4, 240);
            this.lbApplEmp.Name = "lbApplEmp";
            this.lbApplEmp.Size = new System.Drawing.Size(63, 14);
            this.lbApplEmp.TabIndex = 80;
            this.lbApplEmp.Text = "申请医生";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 114;
            this.label17.Text = "病人类型";
            // 
            // lbApplDept
            // 
            this.lbApplDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbApplDept.AutoSize = true;
            this.lbApplDept.Location = new System.Drawing.Point(4, 192);
            this.lbApplDept.Name = "lbApplDept";
            this.lbApplDept.Size = new System.Drawing.Size(63, 14);
            this.lbApplDept.TabIndex = 82;
            this.lbApplDept.Text = "申请科室";
            // 
            // m_lblPatientName
            // 
            this.m_lblPatientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblPatientName.AutoSize = true;
            this.m_lblPatientName.Location = new System.Drawing.Point(4, 72);
            this.m_lblPatientName.Name = "m_lblPatientName";
            this.m_lblPatientName.Size = new System.Drawing.Size(63, 14);
            this.m_lblPatientName.TabIndex = 106;
            this.m_lblPatientName.Text = "病人姓名";
            this.m_lblPatientName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 119;
            this.label9.Text = "病人卡号";
            // 
            // lbSex
            // 
            this.lbSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSex.AutoSize = true;
            this.lbSex.Location = new System.Drawing.Point(32, 96);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(35, 14);
            this.lbSex.TabIndex = 107;
            this.lbSex.Text = "性别";
            // 
            // m_lblAgeTitle
            // 
            this.m_lblAgeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblAgeTitle.AutoSize = true;
            this.m_lblAgeTitle.Location = new System.Drawing.Point(25, 122);
            this.m_lblAgeTitle.Name = "m_lblAgeTitle";
            this.m_lblAgeTitle.Size = new System.Drawing.Size(42, 14);
            this.m_lblAgeTitle.TabIndex = 108;
            this.m_lblAgeTitle.Text = "年 龄";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 468);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 14);
            this.label23.TabIndex = 104;
            this.label23.Text = "送检时间";
            // 
            // m_palReportInfo
            // 
            this.m_palReportInfo.Controls.Add(this.m_txtReportDoct);
            this.m_palReportInfo.Controls.Add(this.m_dtpReportDate);
            this.m_palReportInfo.Location = new System.Drawing.Point(68, 410);
            this.m_palReportInfo.Name = "m_palReportInfo";
            this.m_palReportInfo.Size = new System.Drawing.Size(144, 52);
            this.m_palReportInfo.TabIndex = 0;
            // 
            // m_txtReportDoct
            // 
            this.m_txtReportDoct.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtReportDoct.EnableAutoValidation = true;
            this.m_txtReportDoct.EnableEnterKeyValidate = true;
            this.m_txtReportDoct.EnableEscapeKeyUndo = true;
            this.m_txtReportDoct.EnableLastValidValue = true;
            this.m_txtReportDoct.ErrorProvider = null;
            this.m_txtReportDoct.ErrorProviderMessage = "Invalid value";
            this.m_txtReportDoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReportDoct.ForceFormatText = true;
            this.m_txtReportDoct.Location = new System.Drawing.Point(4, 4);
            this.m_txtReportDoct.m_intShowOtherEmp = 0;
            this.m_txtReportDoct.m_StrDeptID = "*";
            this.m_txtReportDoct.m_StrEmployeeID = null;
            this.m_txtReportDoct.m_StrEmployeeName = null;
            this.m_txtReportDoct.MaxLength = 20;
            this.m_txtReportDoct.Name = "m_txtReportDoct";
            this.m_txtReportDoct.ReadOnly = true;
            this.m_txtReportDoct.Size = new System.Drawing.Size(136, 23);
            this.m_txtReportDoct.TabIndex = 0;
            // 
            // m_dtpReportDate
            // 
            this.m_dtpReportDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpReportDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_dtpReportDate.Location = new System.Drawing.Point(4, 28);
            this.m_dtpReportDate.Name = "m_dtpReportDate";
            this.m_dtpReportDate.Size = new System.Drawing.Size(136, 23);
            this.m_dtpReportDate.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 516);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 103;
            this.label10.Text = "样本条码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 120;
            this.label1.Text = "报告时间";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 420);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 106;
            this.label15.Text = "报告医师";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(7, 539);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "处理状态";
            // 
            // m_txtAuditingStatus
            // 
            this.m_txtAuditingStatus.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtAuditingStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAuditingStatus.Location = new System.Drawing.Point(72, 536);
            this.m_txtAuditingStatus.Name = "m_txtAuditingStatus";
            this.m_txtAuditingStatus.ReadOnly = true;
            this.m_txtAuditingStatus.Size = new System.Drawing.Size(136, 23);
            this.m_txtAuditingStatus.TabIndex = 3;
            this.m_txtAuditingStatus.TabStop = false;
            // 
            // m_txtBarCode
            // 
            this.m_txtBarCode.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtBarCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBarCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtBarCode.Location = new System.Drawing.Point(72, 512);
            this.m_txtBarCode.MaxLength = 100;
            this.m_txtBarCode.Name = "m_txtBarCode";
            this.m_txtBarCode.ReadOnly = true;
            this.m_txtBarCode.Size = new System.Drawing.Size(136, 23);
            this.m_txtBarCode.TabIndex = 2;
            this.m_txtBarCode.TabStop = false;
            // 
            // m_txtAppNO
            // 
            this.m_txtAppNO.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtAppNO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtAppNO.Location = new System.Drawing.Point(72, 488);
            this.m_txtAppNO.MaxLength = 18;
            this.m_txtAppNO.Name = "m_txtAppNO";
            this.m_txtAppNO.ReadOnly = true;
            this.m_txtAppNO.Size = new System.Drawing.Size(136, 23);
            this.m_txtAppNO.TabIndex = 1;
            this.m_txtAppNO.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 492);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 105;
            this.label11.Text = "申请单号";
            // 
            // m_palRight
            // 
            this.m_palRight.Controls.Add(this.label18);
            this.m_palRight.Controls.Add(this.m_txtBarCodeQuery);
            this.m_palRight.Controls.Add(this.m_tabControlFunc);
            this.m_palRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_palRight.Location = new System.Drawing.Point(700, 0);
            this.m_palRight.Name = "m_palRight";
            this.m_palRight.Size = new System.Drawing.Size(316, 557);
            this.m_palRight.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 9F);
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(168, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 116;
            this.label18.Text = "#";
            // 
            // m_txtBarCodeQuery
            // 
            this.m_txtBarCodeQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtBarCodeQuery.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtBarCodeQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.m_txtBarCodeQuery.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtBarCodeQuery.Location = new System.Drawing.Point(180, 0);
            this.m_txtBarCodeQuery.MaxLength = 30;
            this.m_txtBarCodeQuery.Name = "m_txtBarCodeQuery";
            this.m_txtBarCodeQuery.Size = new System.Drawing.Size(132, 21);
            this.m_txtBarCodeQuery.TabIndex = 0;
            this.m_txtBarCodeQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBarCodeQuery_KeyDown);
            this.m_txtBarCodeQuery.Enter += new System.EventHandler(this.m_txtBarCodeQuery_Enter);
            this.m_txtBarCodeQuery.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_txtBarCodeQuery_MouseUp);
            // 
            // m_tabControlFunc
            // 
            this.m_tabControlFunc.Controls.Add(this.m_tabQuery);
            this.m_tabControlFunc.Controls.Add(this.m_tabAppList);
            this.m_tabControlFunc.Controls.Add(this.pageHistory);
            this.m_tabControlFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControlFunc.Location = new System.Drawing.Point(0, 0);
            this.m_tabControlFunc.Name = "m_tabControlFunc";
            this.m_tabControlFunc.SelectedIndex = 0;
            this.m_tabControlFunc.Size = new System.Drawing.Size(316, 557);
            this.m_tabControlFunc.TabIndex = 22;
            // 
            // m_tabQuery
            // 
            this.m_tabQuery.Controls.Add(this.m_grpQry);
            this.m_tabQuery.Location = new System.Drawing.Point(4, 24);
            this.m_tabQuery.Name = "m_tabQuery";
            this.m_tabQuery.Size = new System.Drawing.Size(308, 529);
            this.m_tabQuery.TabIndex = 1;
            this.m_tabQuery.Text = "查询";
            this.m_tabQuery.UseVisualStyleBackColor = true;
            // 
            // m_grpQry
            // 
            this.m_grpQry.Controls.Add(this.btnQuery);
            this.m_grpQry.Controls.Add(this.m_btnQuery);
            this.m_grpQry.Controls.Add(this.btnCriHistory);
            this.m_grpQry.Controls.Add(this.m_txtPatientCardNO);
            this.m_grpQry.Controls.Add(this.m_cboCheckCategory);
            this.m_grpQry.Controls.Add(this.label33);
            this.m_grpQry.Controls.Add(this.m_lsvSampleSearch);
            this.m_grpQry.Controls.Add(this.m_txtSampleSearch);
            this.m_grpQry.Controls.Add(this.m_txtInHospitalNo);
            this.m_grpQry.Controls.Add(this.label30);
            this.m_grpQry.Controls.Add(this.m_btnSendMessage);
            this.m_grpQry.Controls.Add(this.label29);
            this.m_grpQry.Controls.Add(this.m_txtPatientCheckNO);
            this.m_grpQry.Controls.Add(this.label26);
            this.m_grpQry.Controls.Add(this.m_cboConfirmState);
            this.m_grpQry.Controls.Add(this.label24);
            this.m_grpQry.Controls.Add(this.label8);
            this.m_grpQry.Controls.Add(this.label2);
            this.m_grpQry.Controls.Add(this.buttonXP1);
            this.m_grpQry.Controls.Add(this.m_trvSampleGroup);
            this.m_grpQry.Controls.Add(this.m_lsvSampleGroupQuery);
            this.m_grpQry.Controls.Add(this.label21);
            this.m_grpQry.Controls.Add(this.m_txtPatientNameQuery);
            this.m_grpQry.Controls.Add(this.label7);
            this.m_grpQry.Controls.Add(this.label3);
            this.m_grpQry.Controls.Add(this.m_dtpFromDate);
            this.m_grpQry.Controls.Add(this.m_dtpToDate);
            this.m_grpQry.Controls.Add(this.label31);
            this.m_grpQry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grpQry.Location = new System.Drawing.Point(0, 0);
            this.m_grpQry.Name = "m_grpQry";
            this.m_grpQry.Size = new System.Drawing.Size(308, 529);
            this.m_grpQry.TabIndex = 2;
            this.m_grpQry.TabStop = false;
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnQuery.DefaultScheme = true;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuery.Hint = "";
            this.btnQuery.Location = new System.Drawing.Point(196, 64);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnQuery.Size = new System.Drawing.Size(112, 32);
            this.btnQuery.TabIndex = 209;
            this.btnQuery.TabStop = false;
            this.btnQuery.Text = "查询(F2)@历史";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(196, 20);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(112, 32);
            this.m_btnQuery.TabIndex = 8;
            this.m_btnQuery.TabStop = false;
            this.m_btnQuery.Text = "查询(F3)@列表";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // btnCriHistory
            // 
            this.btnCriHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCriHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCriHistory.DefaultScheme = true;
            this.btnCriHistory.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCriHistory.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnCriHistory.Hint = "";
            this.btnCriHistory.Location = new System.Drawing.Point(204, 485);
            this.btnCriHistory.Name = "btnCriHistory";
            this.btnCriHistory.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCriHistory.Size = new System.Drawing.Size(84, 32);
            this.btnCriHistory.TabIndex = 208;
            this.btnCriHistory.Text = "历史危急值";
            this.btnCriHistory.Click += new System.EventHandler(this.btnCriHistory_Click);
            // 
            // m_txtPatientCardNO
            // 
            this.m_txtPatientCardNO.Location = new System.Drawing.Point(80, 139);
            this.m_txtPatientCardNO.MaxLength = 50;
            this.m_txtPatientCardNO.Name = "m_txtPatientCardNO";
            this.m_txtPatientCardNO.PatientCard = "";
            this.m_txtPatientCardNO.PatientFlag = 0;
            this.m_txtPatientCardNO.Size = new System.Drawing.Size(116, 23);
            this.m_txtPatientCardNO.TabIndex = 5;
            this.m_txtPatientCardNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPatientCardNO.YBCardText = "";
            // 
            // m_cboCheckCategory
            // 
            this.m_cboCheckCategory.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckCategory.Location = new System.Drawing.Point(81, 190);
            this.m_cboCheckCategory.Name = "m_cboCheckCategory";
            this.m_cboCheckCategory.Size = new System.Drawing.Size(116, 22);
            this.m_cboCheckCategory.TabIndex = 207;
            this.m_cboCheckCategory.TabStop = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(16, 193);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 14);
            this.label33.TabIndex = 206;
            this.label33.Text = "检验类别";
            // 
            // m_lsvSampleSearch
            // 
            this.m_lsvSampleSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvSampleSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_lsvSampleSearch.FullRowSelect = true;
            this.m_lsvSampleSearch.GridLines = true;
            this.m_lsvSampleSearch.HideSelection = false;
            this.m_lsvSampleSearch.Location = new System.Drawing.Point(80, 257);
            this.m_lsvSampleSearch.MultiSelect = false;
            this.m_lsvSampleSearch.Name = "m_lsvSampleSearch";
            this.m_lsvSampleSearch.Size = new System.Drawing.Size(116, 132);
            this.m_lsvSampleSearch.TabIndex = 205;
            this.m_lsvSampleSearch.UseCompatibleStateImageBehavior = false;
            this.m_lsvSampleSearch.View = System.Windows.Forms.View.Details;
            this.m_lsvSampleSearch.Visible = false;
            this.m_lsvSampleSearch.DoubleClick += new System.EventHandler(this.m_lsvSampleSearch_DoubleClick);
            this.m_lsvSampleSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvSampleSearch_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "样本组名称";
            this.columnHeader1.Width = 88;
            // 
            // m_txtSampleSearch
            // 
            this.m_txtSampleSearch.Location = new System.Drawing.Point(80, 232);
            this.m_txtSampleSearch.Name = "m_txtSampleSearch";
            this.m_txtSampleSearch.Size = new System.Drawing.Size(116, 23);
            this.m_txtSampleSearch.TabIndex = 7;
            this.m_txtSampleSearch.TextChanged += new System.EventHandler(this.m_txtSampleSearch_TextChanged);
            this.m_txtSampleSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSampleSearch_KeyDown);
            this.m_txtSampleSearch.Enter += new System.EventHandler(this.m_txtSampleSearch_Enter);
            // 
            // m_txtInHospitalNo
            // 
            this.m_txtInHospitalNo.Location = new System.Drawing.Point(80, 163);
            this.m_txtInHospitalNo.Name = "m_txtInHospitalNo";
            this.m_txtInHospitalNo.Size = new System.Drawing.Size(116, 23);
            this.m_txtInHospitalNo.TabIndex = 6;
            this.m_txtInHospitalNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtInHospitalNo_KeyDown);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(30, 167);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 14);
            this.label30.TabIndex = 201;
            this.label30.Text = "住院号";
            // 
            // m_btnSendMessage
            // 
            this.m_btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnSendMessage.DefaultScheme = true;
            this.m_btnSendMessage.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSendMessage.Hint = "";
            this.m_btnSendMessage.Location = new System.Drawing.Point(212, 367);
            this.m_btnSendMessage.Name = "m_btnSendMessage";
            this.m_btnSendMessage.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSendMessage.Size = new System.Drawing.Size(84, 33);
            this.m_btnSendMessage.TabIndex = 4;
            this.m_btnSendMessage.Text = "发送短信";
            this.m_btnSendMessage.Visible = false;
            this.m_btnSendMessage.Click += new System.EventHandler(this.m_btnSendMessage_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(16, 143);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 14);
            this.label29.TabIndex = 132;
            this.label29.Text = "诊疗卡号";
            // 
            // m_txtPatientCheckNO
            // 
            this.m_txtPatientCheckNO.Location = new System.Drawing.Point(80, 115);
            this.m_txtPatientCheckNO.Name = "m_txtPatientCheckNO";
            this.m_txtPatientCheckNO.Size = new System.Drawing.Size(116, 23);
            this.m_txtPatientCheckNO.TabIndex = 4;
            this.m_txtPatientCheckNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatientCheckNO_KeyDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 96);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 14);
            this.label26.TabIndex = 130;
            this.label26.Text = "审核状态";
            this.label26.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_cboConfirmState
            // 
            this.m_cboConfirmState.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboConfirmState.Items.AddRange(new object[] {
            "全  部",
            "未审核",
            "已审核"});
            this.m_cboConfirmState.Location = new System.Drawing.Point(80, 92);
            this.m_cboConfirmState.Name = "m_cboConfirmState";
            this.m_cboConfirmState.Size = new System.Drawing.Size(116, 22);
            this.m_cboConfirmState.TabIndex = 3;
            this.m_cboConfirmState.TabStop = false;
            this.m_cboConfirmState.Text = "全  部";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(16, 120);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 126;
            this.label24.Text = "检验编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(225, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 124;
            this.label8.Text = "选定列表";
            this.label8.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 123;
            this.label2.Text = "样本组列表";
            this.label2.Visible = false;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(249, 85);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(48, 19);
            this.buttonXP1.TabIndex = 122;
            this.buttonXP1.TabStop = false;
            this.buttonXP1.Text = "<<";
            this.buttonXP1.Visible = false;
            // 
            // m_trvSampleGroup
            // 
            this.m_trvSampleGroup.CheckBoxes = true;
            this.m_trvSampleGroup.Location = new System.Drawing.Point(217, 141);
            this.m_trvSampleGroup.Name = "m_trvSampleGroup";
            this.m_trvSampleGroup.Size = new System.Drawing.Size(76, 79);
            this.m_trvSampleGroup.TabIndex = 121;
            this.m_trvSampleGroup.Visible = false;
            // 
            // m_lsvSampleGroupQuery
            // 
            this.m_lsvSampleGroupQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvSampleGroupQuery.BackColor = System.Drawing.SystemColors.Info;
            this.m_lsvSampleGroupQuery.CheckBoxes = true;
            this.m_lsvSampleGroupQuery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.m_lsvSampleGroupQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lsvSampleGroupQuery.FullRowSelect = true;
            this.m_lsvSampleGroupQuery.GridLines = true;
            this.m_lsvSampleGroupQuery.Location = new System.Drawing.Point(16, 253);
            this.m_lsvSampleGroupQuery.Name = "m_lsvSampleGroupQuery";
            this.m_lsvSampleGroupQuery.Size = new System.Drawing.Size(180, 264);
            this.m_lsvSampleGroupQuery.TabIndex = 200;
            this.m_lsvSampleGroupQuery.UseCompatibleStateImageBehavior = false;
            this.m_lsvSampleGroupQuery.View = System.Windows.Forms.View.Details;
            this.m_lsvSampleGroupQuery.MouseEnter += new System.EventHandler(this.m_lsvSampleGroupQuery_MouseEnter);
            this.m_lsvSampleGroupQuery.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvSampleGroupQuery_ColumnClick);
            this.m_lsvSampleGroupQuery.MouseLeave += new System.EventHandler(this.m_lsvSampleGroupQuery_MouseLeave);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "样本组";
            this.columnHeader4.Width = 147;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 14);
            this.label21.TabIndex = 112;
            this.label21.Text = "修改日期";
            // 
            // m_txtPatientNameQuery
            // 
            this.m_txtPatientNameQuery.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtPatientNameQuery.Location = new System.Drawing.Point(80, 68);
            this.m_txtPatientNameQuery.MaxLength = 50;
            this.m_txtPatientNameQuery.Name = "m_txtPatientNameQuery";
            this.m_txtPatientNameQuery.Size = new System.Drawing.Size(116, 23);
            this.m_txtPatientNameQuery.TabIndex = 2;
            this.m_txtPatientNameQuery.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 108;
            this.label7.Text = "病人姓名";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "至";
            // 
            // m_dtpFromDate
            // 
            this.m_dtpFromDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpFromDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_dtpFromDate.Location = new System.Drawing.Point(80, 20);
            this.m_dtpFromDate.Name = "m_dtpFromDate";
            this.m_dtpFromDate.Size = new System.Drawing.Size(116, 23);
            this.m_dtpFromDate.TabIndex = 0;
            // 
            // m_dtpToDate
            // 
            this.m_dtpToDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpToDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_dtpToDate.Location = new System.Drawing.Point(80, 44);
            this.m_dtpToDate.Name = "m_dtpToDate";
            this.m_dtpToDate.Size = new System.Drawing.Size(116, 23);
            this.m_dtpToDate.TabIndex = 1;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(14, 236);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(70, 14);
            this.label31.TabIndex = 204;
            this.label31.Text = "查找(F11)";
            // 
            // m_tabAppList
            // 
            this.m_tabAppList.Controls.Add(this.m_dtgReportList);
            this.m_tabAppList.Controls.Add(this.m_pal_SampleList);
            this.m_tabAppList.Location = new System.Drawing.Point(4, 24);
            this.m_tabAppList.Name = "m_tabAppList";
            this.m_tabAppList.Size = new System.Drawing.Size(308, 529);
            this.m_tabAppList.TabIndex = 0;
            this.m_tabAppList.Text = "列表";
            this.m_tabAppList.UseVisualStyleBackColor = true;
            // 
            // m_dtgReportList
            // 
            this.m_dtgReportList.AllowUserToAddRows = false;
            this.m_dtgReportList.AllowUserToDeleteRows = false;
            this.m_dtgReportList.AllowUserToResizeRows = false;
            this.m_dtgReportList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgReportList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dtgReportList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dtgReportList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtgReportList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckNO,
            this.PatientName,
            this.Status,
            this.ItemName,
            this.PatientCardNO,
            this.AcceptDate,
            this.Tag});
            this.m_dtgReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgReportList.Location = new System.Drawing.Point(0, 0);
            this.m_dtgReportList.MultiSelect = false;
            this.m_dtgReportList.Name = "m_dtgReportList";
            this.m_dtgReportList.ReadOnly = true;
            this.m_dtgReportList.RowHeadersVisible = false;
            this.m_dtgReportList.RowTemplate.Height = 20;
            this.m_dtgReportList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtgReportList.Size = new System.Drawing.Size(308, 357);
            this.m_dtgReportList.StandardTab = true;
            this.m_dtgReportList.TabIndex = 1;
            this.m_dtgReportList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgReportList_RowsAdded);
            this.m_dtgReportList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.m_dtgReportList_DataBindingComplete);
            this.m_dtgReportList.SelectionChanged += new System.EventHandler(this.m_dtgReportList_SelectionChanged);
            // 
            // CheckNO
            // 
            this.CheckNO.DataPropertyName = "CheckNO";
            this.CheckNO.HeaderText = "检验编号";
            this.CheckNO.Name = "CheckNO";
            this.CheckNO.ReadOnly = true;
            this.CheckNO.Width = 88;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "患者姓名";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            this.PatientName.Width = 88;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 60;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "项目";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 200;
            // 
            // PatientCardNO
            // 
            this.PatientCardNO.DataPropertyName = "PatientCardNO";
            this.PatientCardNO.HeaderText = "诊疗卡号";
            this.PatientCardNO.Name = "PatientCardNO";
            this.PatientCardNO.ReadOnly = true;
            this.PatientCardNO.Width = 88;
            // 
            // AcceptDate
            // 
            this.AcceptDate.DataPropertyName = "AcceptDate";
            this.AcceptDate.HeaderText = "送检时间";
            this.AcceptDate.Name = "AcceptDate";
            this.AcceptDate.ReadOnly = true;
            this.AcceptDate.Width = 106;
            // 
            // Tag
            // 
            this.Tag.DataPropertyName = "Tag";
            this.Tag.HeaderText = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            this.Tag.Visible = false;
            // 
            // m_pal_SampleList
            // 
            this.m_pal_SampleList.Controls.Add(this.m_palSampleControl);
            this.m_pal_SampleList.Controls.Add(this.m_tabSampleInfo);
            this.m_pal_SampleList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pal_SampleList.Location = new System.Drawing.Point(0, 357);
            this.m_pal_SampleList.Name = "m_pal_SampleList";
            this.m_pal_SampleList.Size = new System.Drawing.Size(308, 172);
            this.m_pal_SampleList.TabIndex = 21;
            // 
            // m_palSampleControl
            // 
            this.m_palSampleControl.Controls.Add(this.m_tabControlSample);
            this.m_palSampleControl.Controls.Add(this.m_palAddSample);
            this.m_palSampleControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_palSampleControl.Location = new System.Drawing.Point(0, 0);
            this.m_palSampleControl.Name = "m_palSampleControl";
            this.m_palSampleControl.Size = new System.Drawing.Size(308, 24);
            this.m_palSampleControl.TabIndex = 11;
            // 
            // m_tabControlSample
            // 
            this.m_tabControlSample.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.m_tabControlSample.Controls.Add(this.tabPage1);
            this.m_tabControlSample.Controls.Add(this.tabPage2);
            this.m_tabControlSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControlSample.ItemSize = new System.Drawing.Size(20, 22);
            this.m_tabControlSample.Location = new System.Drawing.Point(0, 0);
            this.m_tabControlSample.Name = "m_tabControlSample";
            this.m_tabControlSample.SelectedIndex = 0;
            this.m_tabControlSample.Size = new System.Drawing.Size(268, 24);
            this.m_tabControlSample.TabIndex = 1;
            this.m_tabControlSample.SelectedIndexChanged += new System.EventHandler(this.m_tabControlSample_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(260, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(260, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            // 
            // m_palAddSample
            // 
            this.m_palAddSample.Controls.Add(this.m_btnDeleteDeviceSample);
            this.m_palAddSample.Controls.Add(this.m_btnAddDeviceSample);
            this.m_palAddSample.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_palAddSample.Location = new System.Drawing.Point(268, 0);
            this.m_palAddSample.Name = "m_palAddSample";
            this.m_palAddSample.Size = new System.Drawing.Size(40, 24);
            this.m_palAddSample.TabIndex = 4;
            // 
            // m_btnDeleteDeviceSample
            // 
            this.m_btnDeleteDeviceSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnDeleteDeviceSample.Enabled = false;
            this.m_btnDeleteDeviceSample.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnDeleteDeviceSample.Font = new System.Drawing.Font("宋体", 15.25F, System.Drawing.FontStyle.Bold);
            this.m_btnDeleteDeviceSample.ForeColor = System.Drawing.Color.Red;
            this.m_btnDeleteDeviceSample.Location = new System.Drawing.Point(0, 0);
            this.m_btnDeleteDeviceSample.Name = "m_btnDeleteDeviceSample";
            this.m_btnDeleteDeviceSample.Size = new System.Drawing.Size(20, 24);
            this.m_btnDeleteDeviceSample.TabIndex = 3;
            this.m_btnDeleteDeviceSample.Text = "-";
            this.m_btnDeleteDeviceSample.Click += new System.EventHandler(this.m_btnDeleteDeviceSample_Click);
            // 
            // m_btnAddDeviceSample
            // 
            this.m_btnAddDeviceSample.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnAddDeviceSample.Enabled = false;
            this.m_btnAddDeviceSample.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnAddDeviceSample.Font = new System.Drawing.Font("宋体", 15.25F, System.Drawing.FontStyle.Bold);
            this.m_btnAddDeviceSample.ForeColor = System.Drawing.Color.Red;
            this.m_btnAddDeviceSample.Location = new System.Drawing.Point(20, 0);
            this.m_btnAddDeviceSample.Name = "m_btnAddDeviceSample";
            this.m_btnAddDeviceSample.Size = new System.Drawing.Size(20, 24);
            this.m_btnAddDeviceSample.TabIndex = 2;
            this.m_btnAddDeviceSample.Text = "+";
            this.m_btnAddDeviceSample.Click += new System.EventHandler(this.m_btnAddDeviceSample_Click);
            // 
            // m_tabSampleInfo
            // 
            this.m_tabSampleInfo.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.m_tabSampleInfo.Controls.Add(this.tabPage3);
            this.m_tabSampleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabSampleInfo.ItemSize = new System.Drawing.Size(1, 0);
            this.m_tabSampleInfo.Location = new System.Drawing.Point(0, 0);
            this.m_tabSampleInfo.Multiline = true;
            this.m_tabSampleInfo.Name = "m_tabSampleInfo";
            this.m_tabSampleInfo.SelectedIndex = 0;
            this.m_tabSampleInfo.Size = new System.Drawing.Size(308, 172);
            this.m_tabSampleInfo.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.m_pal_SampleInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(300, 141);
            this.tabPage3.TabIndex = 0;
            // 
            // m_pal_SampleInfo
            // 
            this.m_pal_SampleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_pal_SampleInfo.Controls.Add(this.m_grbRelation);
            this.m_pal_SampleInfo.Location = new System.Drawing.Point(0, 0);
            this.m_pal_SampleInfo.Name = "m_pal_SampleInfo";
            this.m_pal_SampleInfo.Size = new System.Drawing.Size(300, 206);
            this.m_pal_SampleInfo.TabIndex = 1;
            // 
            // m_grbRelation
            // 
            this.m_grbRelation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_grbRelation.Controls.Add(this.m_btnImportNewResult);
            this.m_grbRelation.Controls.Add(this.m_palBindInput);
            this.m_grbRelation.Controls.Add(this.m_btnSyncretize);
            this.m_grbRelation.Controls.Add(this.m_btnModifyBind);
            this.m_grbRelation.Controls.Add(this.label25);
            this.m_grbRelation.Controls.Add(this.label16);
            this.m_grbRelation.Controls.Add(this.label13);
            this.m_grbRelation.Controls.Add(this.label19);
            this.m_grbRelation.Controls.Add(this.m_btnConfirmBind);
            this.m_grbRelation.Controls.Add(this.m_txtBindSate);
            this.m_grbRelation.Controls.Add(this.m_btnImportData);
            this.m_grbRelation.Location = new System.Drawing.Point(4, 12);
            this.m_grbRelation.Name = "m_grbRelation";
            this.m_grbRelation.Size = new System.Drawing.Size(288, 120);
            this.m_grbRelation.TabIndex = 10;
            this.m_grbRelation.TabStop = false;
            this.m_grbRelation.Text = "绑定";
            // 
            // m_btnImportNewResult
            // 
            this.m_btnImportNewResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnImportNewResult.DefaultScheme = true;
            this.m_btnImportNewResult.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnImportNewResult.Hint = "";
            this.m_btnImportNewResult.Location = new System.Drawing.Point(190, 66);
            this.m_btnImportNewResult.Name = "m_btnImportNewResult";
            this.m_btnImportNewResult.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnImportNewResult.Size = new System.Drawing.Size(88, 24);
            this.m_btnImportNewResult.TabIndex = 12;
            this.m_btnImportNewResult.Text = "导入新数据 ";
            this.m_btnImportNewResult.Click += new System.EventHandler(this.m_btnImportNewResult_Click);
            // 
            // m_palBindInput
            // 
            this.m_palBindInput.Controls.Add(this.m_cboCheckDeviceList);
            this.m_palBindInput.Controls.Add(this.m_dtpCheckDate);
            this.m_palBindInput.Controls.Add(this.m_txtDeviceSampleID);
            this.m_palBindInput.Location = new System.Drawing.Point(76, 14);
            this.m_palBindInput.Name = "m_palBindInput";
            this.m_palBindInput.Size = new System.Drawing.Size(104, 78);
            this.m_palBindInput.TabIndex = 0;
            // 
            // m_cboCheckDeviceList
            // 
            this.m_cboCheckDeviceList.DisplayMember = "DEVICENAME_VCHR";
            this.m_cboCheckDeviceList.DropDownWidth = 96;
            this.m_cboCheckDeviceList.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_cboCheckDeviceList.Location = new System.Drawing.Point(4, 4);
            this.m_cboCheckDeviceList.Name = "m_cboCheckDeviceList";
            this.m_cboCheckDeviceList.Size = new System.Drawing.Size(96, 22);
            this.m_cboCheckDeviceList.TabIndex = 1;
            this.m_cboCheckDeviceList.ValueMember = "DEVICEID_CHR";
            this.m_cboCheckDeviceList.Validating += new System.ComponentModel.CancelEventHandler(this.m_cboCheckDeviceList_Validating);
            this.m_cboCheckDeviceList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboCheckDeviceList_KeyDown);
            // 
            // m_dtpCheckDate
            // 
            this.m_dtpCheckDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCheckDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_dtpCheckDate.Location = new System.Drawing.Point(4, 52);
            this.m_dtpCheckDate.Name = "m_dtpCheckDate";
            this.m_dtpCheckDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpCheckDate.TabIndex = 1;
            // 
            // m_txtDeviceSampleID
            // 
            this.m_txtDeviceSampleID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtDeviceSampleID.Location = new System.Drawing.Point(4, 28);
            this.m_txtDeviceSampleID.MaxLength = 20;
            this.m_txtDeviceSampleID.Name = "m_txtDeviceSampleID";
            this.m_txtDeviceSampleID.Size = new System.Drawing.Size(96, 23);
            this.m_txtDeviceSampleID.TabIndex = 0;
            // 
            // m_btnSyncretize
            // 
            this.m_btnSyncretize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnSyncretize.DefaultScheme = true;
            this.m_btnSyncretize.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSyncretize.Hint = "";
            this.m_btnSyncretize.Location = new System.Drawing.Point(190, 90);
            this.m_btnSyncretize.Name = "m_btnSyncretize";
            this.m_btnSyncretize.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSyncretize.Size = new System.Drawing.Size(88, 24);
            this.m_btnSyncretize.TabIndex = 13;
            this.m_btnSyncretize.Text = "融合";
            this.m_btnSyncretize.Visible = false;
            this.m_btnSyncretize.Click += new System.EventHandler(this.m_btnSyncretize_Click);
            // 
            // m_btnModifyBind
            // 
            this.m_btnModifyBind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnModifyBind.DefaultScheme = true;
            this.m_btnModifyBind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnModifyBind.Enabled = false;
            this.m_btnModifyBind.Hint = "";
            this.m_btnModifyBind.Location = new System.Drawing.Point(190, 18);
            this.m_btnModifyBind.Name = "m_btnModifyBind";
            this.m_btnModifyBind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnModifyBind.Size = new System.Drawing.Size(44, 24);
            this.m_btnModifyBind.TabIndex = 1;
            this.m_btnModifyBind.Text = "修改";
            this.m_btnModifyBind.Click += new System.EventHandler(this.m_btnModifyBind_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(16, 96);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 14);
            this.label25.TabIndex = 3;
            this.label25.Text = "绑定状态";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 14);
            this.label16.TabIndex = 2;
            this.label16.Text = "检验日期";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 2;
            this.label13.Text = "检验仪器";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 14);
            this.label19.TabIndex = 5;
            this.label19.Text = "仪器标本号";
            // 
            // m_btnConfirmBind
            // 
            this.m_btnConfirmBind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnConfirmBind.DefaultScheme = true;
            this.m_btnConfirmBind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnConfirmBind.Enabled = false;
            this.m_btnConfirmBind.Hint = "";
            this.m_btnConfirmBind.Location = new System.Drawing.Point(234, 18);
            this.m_btnConfirmBind.Name = "m_btnConfirmBind";
            this.m_btnConfirmBind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnConfirmBind.Size = new System.Drawing.Size(44, 24);
            this.m_btnConfirmBind.TabIndex = 2;
            this.m_btnConfirmBind.Text = "确定";
            this.m_btnConfirmBind.Click += new System.EventHandler(this.m_btnConfirmBind_Click);
            // 
            // m_txtBindSate
            // 
            this.m_txtBindSate.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtBindSate.Location = new System.Drawing.Point(80, 92);
            this.m_txtBindSate.MaxLength = 20;
            this.m_txtBindSate.Name = "m_txtBindSate";
            this.m_txtBindSate.ReadOnly = true;
            this.m_txtBindSate.Size = new System.Drawing.Size(96, 23);
            this.m_txtBindSate.TabIndex = 4;
            // 
            // m_btnImportData
            // 
            this.m_btnImportData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnImportData.DefaultScheme = true;
            this.m_btnImportData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnImportData.Hint = "";
            this.m_btnImportData.Location = new System.Drawing.Point(190, 42);
            this.m_btnImportData.Name = "m_btnImportData";
            this.m_btnImportData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnImportData.Size = new System.Drawing.Size(88, 24);
            this.m_btnImportData.TabIndex = 11;
            this.m_btnImportData.Text = "导入数据";
            this.m_btnImportData.Click += new System.EventHandler(this.m_btnImportData_Click);
            // 
            // pageHistory
            // 
            this.pageHistory.Controls.Add(this.gvHistory);
            this.pageHistory.Location = new System.Drawing.Point(4, 22);
            this.pageHistory.Name = "pageHistory";
            this.pageHistory.Size = new System.Drawing.Size(308, 531);
            this.pageHistory.TabIndex = 2;
            this.pageHistory.Text = "历史";
            this.pageHistory.UseVisualStyleBackColor = true;
            // 
            // gvHistory
            // 
            this.gvHistory.AllowUserToAddRows = false;
            this.gvHistory.AllowUserToDeleteRows = false;
            this.gvHistory.AllowUserToResizeRows = false;
            this.gvHistory.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckNO2,
            this.PatientName2,
            this.Status2,
            this.ItemName2,
            this.PatientCardNO2,
            this.AcceptDate2,
            this.Tag2});
            this.gvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvHistory.Location = new System.Drawing.Point(0, 0);
            this.gvHistory.MultiSelect = false;
            this.gvHistory.Name = "gvHistory";
            this.gvHistory.ReadOnly = true;
            this.gvHistory.RowHeadersVisible = false;
            this.gvHistory.RowTemplate.Height = 20;
            this.gvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvHistory.Size = new System.Drawing.Size(308, 531);
            this.gvHistory.StandardTab = true;
            this.gvHistory.TabIndex = 2;
            this.gvHistory.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgReportList_RowsAdded);
            this.gvHistory.SelectionChanged += new System.EventHandler(this.gvHistory_SelectionChanged);
            // 
            // CheckNO2
            // 
            this.CheckNO2.DataPropertyName = "CheckNO";
            this.CheckNO2.HeaderText = "检验编号";
            this.CheckNO2.Name = "CheckNO2";
            this.CheckNO2.ReadOnly = true;
            this.CheckNO2.Width = 88;
            // 
            // PatientName2
            // 
            this.PatientName2.DataPropertyName = "PatientName";
            this.PatientName2.HeaderText = "患者姓名";
            this.PatientName2.Name = "PatientName2";
            this.PatientName2.ReadOnly = true;
            this.PatientName2.Width = 88;
            // 
            // Status2
            // 
            this.Status2.DataPropertyName = "Status";
            this.Status2.HeaderText = "状态";
            this.Status2.Name = "Status2";
            this.Status2.ReadOnly = true;
            this.Status2.Width = 60;
            // 
            // ItemName2
            // 
            this.ItemName2.DataPropertyName = "ItemName";
            this.ItemName2.HeaderText = "项目";
            this.ItemName2.Name = "ItemName2";
            this.ItemName2.ReadOnly = true;
            this.ItemName2.Width = 200;
            // 
            // PatientCardNO2
            // 
            this.PatientCardNO2.DataPropertyName = "PatientCardNO";
            this.PatientCardNO2.HeaderText = "诊疗卡号";
            this.PatientCardNO2.Name = "PatientCardNO2";
            this.PatientCardNO2.ReadOnly = true;
            this.PatientCardNO2.Width = 88;
            // 
            // AcceptDate2
            // 
            this.AcceptDate2.DataPropertyName = "AcceptDate";
            this.AcceptDate2.HeaderText = "送检时间";
            this.AcceptDate2.Name = "AcceptDate2";
            this.AcceptDate2.ReadOnly = true;
            this.AcceptDate2.Width = 106;
            // 
            // Tag2
            // 
            this.Tag2.DataPropertyName = "Tag";
            this.Tag2.HeaderText = "Tag";
            this.Tag2.Name = "Tag2";
            this.Tag2.ReadOnly = true;
            this.Tag2.Visible = false;
            // 
            // m_palButtom
            // 
            this.m_palButtom.Controls.Add(this.panel3);
            this.m_palButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_palButtom.Location = new System.Drawing.Point(0, 557);
            this.m_palButtom.Name = "m_palButtom";
            this.m_palButtom.Size = new System.Drawing.Size(1016, 52);
            this.m_palButtom.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_btnCancelConfim);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.m_cmdLogOff);
            this.panel3.Controls.Add(this.m_btnDelete);
            this.panel3.Controls.Add(this.m_cmdLogOn);
            this.panel3.Controls.Add(this.label32);
            this.panel3.Controls.Add(this.m_btnPreviewReport);
            this.panel3.Controls.Add(this.m_btnNewApp);
            this.panel3.Controls.Add(this.m_lblSubmitDoctor);
            this.panel3.Controls.Add(this.m_btnPrintReport);
            this.panel3.Controls.Add(this.m_btnConfirmReport);
            this.panel3.Controls.Add(this.m_btnSaveReport);
            this.panel3.Controls.Add(this.m_btnPreference);
            this.panel3.Location = new System.Drawing.Point(-7, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 44);
            this.panel3.TabIndex = 124;
            // 
            // m_btnCancelConfim
            // 
            this.m_btnCancelConfim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancelConfim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnCancelConfim.DefaultScheme = true;
            this.m_btnCancelConfim.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCancelConfim.Hint = "";
            this.m_btnCancelConfim.Location = new System.Drawing.Point(314, 5);
            this.m_btnCancelConfim.Name = "m_btnCancelConfim";
            this.m_btnCancelConfim.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCancelConfim.Size = new System.Drawing.Size(76, 33);
            this.m_btnCancelConfim.TabIndex = 125;
            this.m_btnCancelConfim.Text = "取消审核";
            this.m_btnCancelConfim.Click += new System.EventHandler(this.m_blnCancelConfim_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(939, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(76, 33);
            this.btnExit.TabIndex = 124;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // m_cmdLogOff
            // 
            this.m_cmdLogOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdLogOff.DefaultScheme = true;
            this.m_cmdLogOff.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdLogOff.Hint = "";
            this.m_cmdLogOff.Location = new System.Drawing.Point(249, 5);
            this.m_cmdLogOff.Name = "m_cmdLogOff";
            this.m_cmdLogOff.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdLogOff.Size = new System.Drawing.Size(59, 33);
            this.m_cmdLogOff.TabIndex = 123;
            this.m_cmdLogOff.Text = "退出(&Q)";
            this.m_cmdLogOff.Click += new System.EventHandler(this.m_cmdLogOff_Click);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnDelete.DefaultScheme = true;
            this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelete.Hint = "";
            this.m_btnDelete.Location = new System.Drawing.Point(628, 5);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelete.Size = new System.Drawing.Size(80, 33);
            this.m_btnDelete.TabIndex = 111;
            this.m_btnDelete.TabStop = false;
            this.m_btnDelete.Text = "删除(F12)";
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_cmdLogOn
            // 
            this.m_cmdLogOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdLogOn.DefaultScheme = true;
            this.m_cmdLogOn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdLogOn.Hint = "";
            this.m_cmdLogOn.Location = new System.Drawing.Point(187, 5);
            this.m_cmdLogOn.Name = "m_cmdLogOn";
            this.m_cmdLogOn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdLogOn.Size = new System.Drawing.Size(59, 33);
            this.m_cmdLogOn.TabIndex = 122;
            this.m_cmdLogOn.Text = "登录(&W)";
            this.m_cmdLogOn.Click += new System.EventHandler(this.m_cmdLogOn_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.label32.ForeColor = System.Drawing.Color.Crimson;
            this.label32.Location = new System.Drawing.Point(11, 14);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(90, 14);
            this.label32.TabIndex = 112;
            this.label32.Text = "登录审核人:";
            // 
            // m_btnPreviewReport
            // 
            this.m_btnPreviewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPreviewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnPreviewReport.DefaultScheme = true;
            this.m_btnPreviewReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPreviewReport.Hint = "";
            this.m_btnPreviewReport.Location = new System.Drawing.Point(553, 5);
            this.m_btnPreviewReport.Name = "m_btnPreviewReport";
            this.m_btnPreviewReport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPreviewReport.Size = new System.Drawing.Size(72, 33);
            this.m_btnPreviewReport.TabIndex = 1;
            this.m_btnPreviewReport.Text = "预览(F6)";
            this.m_btnPreviewReport.Click += new System.EventHandler(this.m_btnPreviewReport_Click);
            // 
            // m_btnNewApp
            // 
            this.m_btnNewApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNewApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnNewApp.DefaultScheme = true;
            this.m_btnNewApp.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNewApp.Hint = "";
            this.m_btnNewApp.Location = new System.Drawing.Point(710, 5);
            this.m_btnNewApp.Name = "m_btnNewApp";
            this.m_btnNewApp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNewApp.Size = new System.Drawing.Size(72, 33);
            this.m_btnNewApp.TabIndex = 4;
            this.m_btnNewApp.Text = "新增(F8)";
            this.m_btnNewApp.Click += new System.EventHandler(this.m_btnNewApp_Click);
            // 
            // m_lblSubmitDoctor
            // 
            this.m_lblSubmitDoctor.AutoSize = true;
            this.m_lblSubmitDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_lblSubmitDoctor.Location = new System.Drawing.Point(97, 14);
            this.m_lblSubmitDoctor.Name = "m_lblSubmitDoctor";
            this.m_lblSubmitDoctor.Size = new System.Drawing.Size(38, 14);
            this.m_lblSubmitDoctor.TabIndex = 113;
            this.m_lblSubmitDoctor.Text = "(空)";
            // 
            // m_btnPrintReport
            // 
            this.m_btnPrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPrintReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnPrintReport.DefaultScheme = true;
            this.m_btnPrintReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrintReport.Hint = "";
            this.m_btnPrintReport.Location = new System.Drawing.Point(478, 5);
            this.m_btnPrintReport.Name = "m_btnPrintReport";
            this.m_btnPrintReport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrintReport.Size = new System.Drawing.Size(72, 33);
            this.m_btnPrintReport.TabIndex = 2;
            this.m_btnPrintReport.Text = "打印(F5)";
            this.m_btnPrintReport.Click += new System.EventHandler(this.m_btnPrintReport_Click);
            // 
            // m_btnConfirmReport
            // 
            this.m_btnConfirmReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnConfirmReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnConfirmReport.DefaultScheme = true;
            this.m_btnConfirmReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnConfirmReport.Hint = "";
            this.m_btnConfirmReport.Location = new System.Drawing.Point(785, 5);
            this.m_btnConfirmReport.Name = "m_btnConfirmReport";
            this.m_btnConfirmReport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnConfirmReport.Size = new System.Drawing.Size(72, 33);
            this.m_btnConfirmReport.TabIndex = 0;
            this.m_btnConfirmReport.Text = "审核(F9)";
            this.m_btnConfirmReport.Click += new System.EventHandler(this.m_btnConfirmReport_Click);
            // 
            // m_btnSaveReport
            // 
            this.m_btnSaveReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSaveReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnSaveReport.DefaultScheme = true;
            this.m_btnSaveReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveReport.Hint = "";
            this.m_btnSaveReport.Location = new System.Drawing.Point(860, 5);
            this.m_btnSaveReport.Name = "m_btnSaveReport";
            this.m_btnSaveReport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveReport.Size = new System.Drawing.Size(76, 33);
            this.m_btnSaveReport.TabIndex = 0;
            this.m_btnSaveReport.Text = "存盘(F10)";
            this.m_btnSaveReport.Click += new System.EventHandler(this.m_btnSaveReport_Click);
            // 
            // m_btnPreference
            // 
            this.m_btnPreference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPreference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnPreference.DefaultScheme = true;
            this.m_btnPreference.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPreference.Hint = "";
            this.m_btnPreference.Location = new System.Drawing.Point(396, 5);
            this.m_btnPreference.Name = "m_btnPreference";
            this.m_btnPreference.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPreference.Size = new System.Drawing.Size(79, 33);
            this.m_btnPreference.TabIndex = 3;
            this.m_btnPreference.Text = "设置(F7)";
            this.m_btnPreference.Click += new System.EventHandler(this.m_btnPreference_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CheckNO";
            this.dataGridViewTextBoxColumn1.HeaderText = "检验编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 88;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PatientName";
            this.dataGridViewTextBoxColumn2.HeaderText = "患者姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 88;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn3.HeaderText = "状态";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn4.HeaderText = "项目";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PatientCardNO";
            this.dataGridViewTextBoxColumn5.HeaderText = "诊疗卡号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 88;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "AcceptDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "送检时间";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 106;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Tag";
            this.dataGridViewTextBoxColumn7.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CheckNO";
            this.dataGridViewTextBoxColumn8.HeaderText = "检验编号";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 88;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PatientName";
            this.dataGridViewTextBoxColumn9.HeaderText = "患者姓名";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 88;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn10.HeaderText = "状态";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 60;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "AcceptDate";
            this.dataGridViewTextBoxColumn11.HeaderText = "送检时间";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 106;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn12.HeaderText = "项目";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "PatientCardNO";
            this.dataGridViewTextBoxColumn13.HeaderText = "诊疗卡号";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 88;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Tag";
            this.dataGridViewTextBoxColumn14.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // frmHandInputReport
            // 
            this.AccessibleName = "frmHandInputReport";
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1016, 609);
            this.Controls.Add(this.m_palMiddle);
            this.Controls.Add(this.m_palLeft);
            this.Controls.Add(this.m_palRight);
            this.Controls.Add(this.m_palButtom);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmHandInputReport";
            this.Text = "检验报告录入";
            this.Load += new System.EventHandler(this.frmHandInputReport_Load);
            this.Closed += new System.EventHandler(this.frmHandInputReport_Closed);
            this.Activated += new System.EventHandler(this.frmHandInputReport_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEnterHandler);
            this.m_palMiddle.ResumeLayout(false);
            this.m_palMRL.ResumeLayout(false);
            this.m_tabControlWorkArea.ResumeLayout(false);
            this.m_tabCheckResult.ResumeLayout(false);
            this.m_tabCheckResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgResultList)).EndInit();
            this.m_tabGraph.ResumeLayout(false);
            this.m_palGraph.ResumeLayout(false);
            this.m_tabReport.ResumeLayout(false);
            this.m_palSummary.ResumeLayout(false);
            this.m_palLeft.ResumeLayout(false);
            this.m_palLeft.PerformLayout();
            this.m_grpPatientInfo.ResumeLayout(false);
            this.m_grpPatientInfo.PerformLayout();
            this.m_palBaseInfoInput.ResumeLayout(false);
            this.m_palBaseInfoInput.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.m_palReportInfo.ResumeLayout(false);
            this.m_palReportInfo.PerformLayout();
            this.m_palRight.ResumeLayout(false);
            this.m_palRight.PerformLayout();
            this.m_tabControlFunc.ResumeLayout(false);
            this.m_tabQuery.ResumeLayout(false);
            this.m_grpQry.ResumeLayout(false);
            this.m_grpQry.PerformLayout();
            this.m_tabAppList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgReportList)).EndInit();
            this.m_pal_SampleList.ResumeLayout(false);
            this.m_palSampleControl.ResumeLayout(false);
            this.m_tabControlSample.ResumeLayout(false);
            this.m_palAddSample.ResumeLayout(false);
            this.m_tabSampleInfo.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.m_pal_SampleInfo.ResumeLayout(false);
            this.m_grbRelation.ResumeLayout(false);
            this.m_grbRelation.PerformLayout();
            this.m_palBindInput.ResumeLayout(false);
            this.m_palBindInput.PerformLayout();
            this.pageHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit();
            this.m_palButtom.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region 一般设置

        #region 快捷键设置
        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            //if (p_eumKeyCode == Keys.F2)
            //{
            //    //				if(this.m_btnEmergencyInterpose.Enabled == true 
            //    //					&& this.m_btnEmergencyInterpose.Visible == true)
            //    //				{
            //    //					this.m_btnEmergencyInterpose_Click(this.m_btnEmergencyInterpose,null);
            //    //				}
            //}
            if (p_eumKeyCode == Keys.F2 && this.btnQuery.Enabled)
            {
                btnQuery_Click(null, EventArgs.Empty);
            }
            else if (p_eumKeyCode == Keys.F3 && this.m_btnQuery.Enabled)
            {
                m_btnQuery_Click(null, EventArgs.Empty);
            }
            else if (p_eumKeyCode == Keys.F4)
            {
                if (this.m_btnSelectCheck.Enabled == true
                    && this.m_btnSelectCheck.Visible == true)
                {
                    this.m_btnSelectCheck_Click(this.m_btnSelectCheck, null);
                }
            }
            else if (p_eumKeyCode == Keys.F7 && this.m_btnPreference.Enabled && m_btnPreference.Visible)//保存
            {
                this.m_btnPreference_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F5 && this.m_btnPrintReport.Enabled && m_btnPrintReport.Visible)//读卡
            {
                this.m_btnPrintReport_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F6 && this.m_btnPreviewReport.Enabled && m_btnPreviewReport.Visible)		//退出
            {
                this.m_btnPreviewReport_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F9 && this.m_btnConfirmReport.Enabled && m_btnConfirmReport.Visible)		//清除
            {
                this.m_btnConfirmReport_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F10 && this.m_btnSaveReport.Enabled && m_btnSaveReport.Visible)//手输和读卡机切换
            {
                this.m_btnSaveReport_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F12 && this.m_btnDelete.Enabled && m_btnDelete.Visible)//手输和读卡机切换
            {
                this.m_btnDelete_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F8 && this.m_btnNewApp.Enabled && m_btnNewApp.Visible)//手输和读卡机切换
            {
                this.m_btnNewApp_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F11)
            {
                this.m_txtSampleSearch.Focus();
            }
            else if (p_eumKeyCode == Keys.F1)
            {
                m_btnSaveApp_Click(null, null);
            }
            //			else if(p_eumKeyCode==Keys.F12 && this.m_btnInputSwitch.Enabled && m_btnInputSwitch.Visible)//手输和读卡机切换
            //			{
            //				this.m_btnInputSwitch_Click(null,null);
            //			}
        }
        #endregion

        #region Enter 键选择下一个
        private void m_mthEnterHandler(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthShortCutKey(e.KeyCode);
            this.m_mthSetKeyTab(e);
        }

        #endregion

        #endregion

        #region 初始化

        private void frmHandInputReport_Load(object sender, System.EventArgs e)
        {
            this.m_dtpAppDate.Value = DateTime.Now;
            this.m_dtpCheckDate.Value = DateTime.Now;
            this.m_dtpFromDate.Value = DateTime.Now;
            this.m_dtpReportDate.Value = DateTime.Now;
            this.m_dtpToDate.Value = DateTime.Now;

            this.m_dtpAcceptDate.Value = DateTime.Now;
            try
            {
                m_blnCanModifyAcceptDat = clsLisSetting.BlnCanModifyAcceptDat();
            }
            catch (Exception objEx)
            {
                MessageBox.Show("未设置4012参数，请与管理员联系！", c_strMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_blnCanModifyAcceptDat = false;
            }
            //if (m_blnCanModifyAcceptDat)
            //{
            //    m_dtpAcceptDate.Enabled = true;
            //}
            //else
            //{
            //    m_dtpAcceptDate.Enabled = false;
            //}

            m_mthInitRichTextBox();
            InitializeTemplate();

            m_mthInitPreferences();
            this.Controls.Add(this.m_palExtEdit);
            this.m_mthSetFormControlCanBeNull(this);
            this.m_mthSetEnter2Tab(new Control[]{this.m_rtbAppSummary,this.m_rtbCheckSummary,this.m_rtbAnnotation,this.m_btnConfirmReport,
													this.m_btnNewApp,this.m_btnPreviewReport,this.m_btnPrintReport,this.m_btnQuery,this.m_btnSaveReport,this.m_txtInhospNO,
													this.m_btnSelectCheck,this.m_txtAppDept,this.m_txtAppDoct,this.m_txtReportDoct});
            this.m_objController.m_mthInit();
            this.m_mthInitSampleGroupLsv();
            this.m_mthInitDtgResultList();
            this.m_mthResetAll();

            LoadSearchSampleGroup();

            this.m_txtBarCodeQuery.FindForm().Focus();
            this.m_txtBarCodeQuery.Focus();
            this.m_txtBarCodeQuery.Select();
        }

        private void m_mthInitPreferences()
        {
            try
            {
                string strConfigFilePath = Application.ExecutablePath + ".config";
                System.Configuration.ConfigXmlDocument appConfig = new System.Configuration.ConfigXmlDocument();
                appConfig.Load(strConfigFilePath);

                m_objPreferenceStyle.m_blnBatchConfirmStyle = bool.Parse(appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"Preference_frmReportInput_BatchConfirmStyle\"]").Attributes["value"].Value);
                m_objPreferenceStyle.m_blnAutoPrint = bool.Parse(appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"Preference_frmReportInput_AutoPrint\"]").Attributes["value"].Value);
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex.Message);
            }
        }

        private void m_mthInitSampleGroupLsv()
        {
            clsSampleGroup_VO[] objSampleGroupArr = null;
            new clsDomainController_SampleGroupManage().m_lngGetAllSampleGroup(out objSampleGroupArr);
            if (objSampleGroupArr != null)
            {
                for (int i = 0; i < objSampleGroupArr.Length; i++)
                {
                    ListViewItem lvt = new ListViewItem(objSampleGroupArr[i].strSampleGroupName);
                    lvt.Tag = objSampleGroupArr[i];
                    this.m_lsvSampleGroupQuery.Items.Add(lvt);
                }
            }

            //			clsDomainController_SampleGroupManage objSampleManage = new clsDomainController_SampleGroupManage();
            //			TreeNode[] trnArr = null;
            //			objSampleManage.m_mthGetSampleGroupTreeNodes(out trnArr);
            //			if(trnArr != null)
            //			{
            //				this.m_trvSampleGroup.Nodes.AddRange(trnArr);
            //			}
        }

        ctlDataGridTextBoxColumn m_objColumnResult;
        private void m_mthInitDtgResultList()
        {
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgResultList)).BeginInit();

            this.m_mthSetTableStyle();
            DataView dtv = new DataView(this.m_objController.m_dtbResult);
            dtv.Sort = "group_seq,item_seq";
            dtv.RowFilter = "invisible = 0";
            this.m_dtgResultList.DataSource = dtv;
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgResultList)).EndInit();
            this.ResumeLayout(false);
        }

        private void m_mthSetTableStyle()
        {
            System.Windows.Forms.DataGridTableStyle objTableStyle = new DataGridTableStyle();
            objTableStyle.MappingName = "dtbCheckResult";
            this.m_mthSetColumnStyle(objTableStyle, "检验项目", "rptno_chr", 120, true, "");
            //			this.m_mthSetColumnStyle(objTableStyle,"检验项目英文名","CHECK_ITEM_ENGLISH_NAME_VCHR",60,true,"");
            //			this.m_mthSetColumnStyle(objTableStyle,"仪器项目名称","DEVICE_CHECK_ITEM_NAME_VCHR",60,true,"");
            this.m_mthSetColumnStyle(objTableStyle, "仪器结果", "RAW_RESULT_VCHR", 80, true, "");
            //			this.m_mthSetColumnStyle(objTableStyle,"项目结果","RESULT_VCHR",80,false,"");

            m_objColumnResult = new ctlDataGridTextBoxColumn();
            m_objColumnResult.HeaderText = "项目结果";
            m_objColumnResult.MappingName = "RESULT_VCHR";
            m_objColumnResult.Width = 80;
            m_objColumnResult.ReadOnly = false;
            m_objColumnResult.NullText = "";
            objTableStyle.GridColumnStyles.Add(m_objColumnResult);

            //			this.m_mthSetColumnStyle(objTableStyle,"标志","ABNORMAL_FLAG_CHR",40,true,"");
            //			this.m_mthSetColumnStyle(objTableStyle,"最小值","MIN_VAL_DEC",60,true,"");
            //			this.m_mthSetColumnStyle(objTableStyle,"最大值","MAX_VAL_DEC",60,true,"");
            this.m_mthSetColumnStyle(objTableStyle, "参考区间", "REFRANGE_VCHR", 100, true, "");
            this.m_mthSetColumnStyle(objTableStyle, "单位", "UNIT_VCHR", 75, true, "");
            //			this.m_mthSetColumnStyle(objTableStyle,"检验日期","CHECK_DAT",60,true,"");
            //			this.m_mthSetColumnStyle(objTableStyle,"临床解释","CLINICAPP_VCHR",60,true,"");
            //			this.m_mthSetColumnStyle(objTableStyle,"备注","MEMO_VCHR",100,true,"");
            //			this.m_mthSetColumnStyle(objTableStyle,"计算公式","FORMULA_VCHR",100,true,"");
            //			this.m_mthSetColumnStyle(objTableStyle,"修改标志","ISDIRTY",60,true,"");


            //回车事件
            //			DataGridTextBoxColumn tbc=(DataGridTextBoxColumn)objTableStyle.GridColumnStyles[4];
            //			tbc.TextBox.KeyDown += new KeyEventHandler(m_mthCellKeyDown);
            //			tbc.TextBox.TextChanged += new System.EventHandler(this.m_mthCellTextChanged);

            m_objColumnResult.evtColumnPaintEvent += new dlgColumnPaintEventHandler(m_objColumnResult_evtColumnPaintEvent);
            m_objColumnResult.evtCellQueryEditable += new dlgCellQueryEditableEventHandler(m_objColumnResult_evtCellQueryEditable);
            m_objColumnResult.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            //			m_objColumnResult.TextBox.ContextMenu = a;
            this.m_dtgResultList.CurrentCellChanged += new EventHandler(m_dtgResultList_CurrentCellChanged);
            this.m_dtgResultList.Leave += new EventHandler(m_dtgResultList_Leave);

            objTableStyle.AllowSorting = false;
            objTableStyle.ReadOnly = false;
            objTableStyle.RowHeadersVisible = false;
            this.m_dtgResultList.TableStyles.Add(objTableStyle);
            m_arlDataColumn.Add(objTableStyle.GridColumnStyles[1]);
            m_arlDataColumn.Add(objTableStyle.GridColumnStyles[3]);
            m_arlDataColumn.Add(objTableStyle.GridColumnStyles[4]);
        }

        private void m_dtgResultList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.m_dtgResultList.CurrentCell.ColumnNumber != 2)
                this.m_frmValue.Hide();
        }

        private void m_dtgResultList_Leave(object sender, EventArgs e)
        {
            this.m_frmValue.Hide();
        }

        private void m_objColumnResult_evtColumnPaintEvent(Object p_objSender, clsColumnPaintEventArgs e)
        {
            DataView dtv = (DataView)this.m_dtgResultList.DataSource;
            if (dtv.Count <= e.RowNum)
                return;
            #region 危险指示
            if (dtv[e.RowNum]["alert_flag"].ToString().Trim() == "H")
            {
                e.BackBrush = System.Drawing.Brushes.Pink;
            }
            else if (dtv[e.RowNum]["alert_flag"].ToString().Trim() == "L")
            {
                e.BackBrush = System.Drawing.Brushes.LightSteelBlue;
            }
            else
            {
                //				e.ForeBrush = System.Drawing.Brushes.White;
            }
            #endregion

            #region 参考指示
            if (dtv[e.RowNum]["ABNORMAL_FLAG_CHR"].ToString().Trim() == "H")
            {
                e.ForeBrush = System.Drawing.Brushes.Red;
            }
            else if (dtv[e.RowNum]["ABNORMAL_FLAG_CHR"].ToString().Trim() == "L")
            {
                e.ForeBrush = System.Drawing.Brushes.Blue;
            }
            else
            {
                e.ForeBrush = System.Drawing.Brushes.Black;
            }
            #endregion

        }

        private void m_objColumnResult_evtCellQueryEditable(Object p_sender, clsCellQueryEditableArgs e)
        {
            DataView dtv = (DataView)this.m_dtgResultList.DataSource;
            #region ReadOnly
            int intRow = e.RowNum;
            if ((dtv[intRow]["samplestatus"].ToString().Trim() == "3"
                || dtv[intRow]["samplestatus"].ToString().Trim() == "5"
                || (dtv[intRow]["samplestatus"].ToString().Trim() == "6" && GetConfirmDays() <= clsPreferenceReportInput.c_intConfirmDays)
                )
                && (!(dtv[intRow]["resulttype_chr"].ToString().Trim() == "3")))//&& dtv[intRow]["is_calculated_chr"].ToString().Trim() != "1" 
            {
                e.ReadOnly = false;
            }
            else
            {
                e.ReadOnly = true;
            }
            #endregion
            if (!this.m_blnUseValueTemplate)
                return;
            if (e.ReadOnly)
            {
                this.m_frmValue.Hide();
                return;
            }
            #region ValueTemple
            int intCurrRow = this.m_dtgResultList.CurrentRowIndex;
            this.m_dtrCurValueTemplateRow = dtv[intCurrRow].Row;
            this.m_intRowIndex = intCurrRow;
            string strItemID = dtv[intCurrRow]["check_item_id_chr"].ToString().Trim();
            string strCheckCategoryID = dtv[intCurrRow]["check_category_id_chr"].ToString().Trim();
            string strSampleTypeID = dtv[intCurrRow]["sampletype_vchr"].ToString().Trim();
            string strItemName = dtv[intCurrRow]["rptno_chr"].ToString().Trim();

            if (!m_frmValue.m_mthShowTemplate(strItemID))
            {
                m_frmValue.m_mthNewTemplate(strCheckCategoryID, strSampleTypeID, strItemID, strItemName);
            }
            #endregion

        }

        private void m_mthSetColumnStyle(DataGridTableStyle p_objTableStyle, string p_strTheName, string p_strTheMember, int p_intTheWidth, bool p_blnReadOnly, string p_strNullText)
        {
            DataGridTextBoxColumn objColumnStyle = new DataGridTextBoxColumn();
            objColumnStyle.HeaderText = p_strTheName;
            objColumnStyle.MappingName = p_strTheMember;
            objColumnStyle.Width = p_intTheWidth;
            objColumnStyle.ReadOnly = p_blnReadOnly;
            objColumnStyle.NullText = p_strNullText;
            p_objTableStyle.GridColumnStyles.Add(objColumnStyle);
        }

        #endregion

        #region 查询

        private void m_btnQuery_Click(object sender, System.EventArgs e)
        {
            this.m_btnQuery.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            this.m_mthQuery(1);

            this.m_btnQuery.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_mthBarcodeQuery()
        {
            string strDateBegin = null;
            string strDateEnd = null;
            string strAppID = null;
            string[] strSampleGroupIDArr = null;

            string strBarCode = this.m_txtBarCodeQuery.Text.Trim();

            string strPatientName = null;
            string strConfirmed = "3";

            clsLisApplMainVO[] objAppVOArr = null;

            clsLISApplicationSchVO objSchVO = new clsLISApplicationSchVO();
            objSchVO.m_strApplicationID = strAppID;
            objSchVO.m_strBarCode = strBarCode;
            objSchVO.m_strConfirmedDateBegin = strDateBegin;
            objSchVO.m_strConfirmedDateEnd = strDateEnd;
            objSchVO.m_strConfirmState = strConfirmed;
            objSchVO.m_strPatientName = strPatientName;
            objSchVO.m_strSampleGroupIDArr = strSampleGroupIDArr;
            string m_strCheckCategory = m_cboCheckCategory.SelectedValue.ToString();

            long lngRes = this.m_objController.m_lngQuery(objSchVO, m_strCheckCategory, out objAppVOArr);

            if (lngRes == 0)
            {
                MessageBox.Show(this, "操作失败!", c_strMessageBoxTitle);
            }
            else if (objAppVOArr == null || objAppVOArr.Length == 0)
            {
                MessageBox.Show(this, "没有找到符合条件的记录!", c_strMessageBoxTitle);
            }
            else
            {
                this.m_tabControlFunc.SelectedTab = this.m_tabAppList;
                for (int i = 0; i < objAppVOArr.Length; i++)
                {
                    bool blnHadItem = false;
                    for (int j = 0; j < this.dtbList.Rows.Count; j++)
                    {
                        if (((clsLisApplMainVO)dtbList.Rows[j]["Tag"]).m_strAPPLICATION_ID == objAppVOArr[i].m_strAPPLICATION_ID)
                        {
                            blnHadItem = true;
                            this.m_dtgReportList.Rows[j].Selected = true;
                        }
                    }
                    if (!blnHadItem)
                    {
                        m_objReportTableNewRow(objAppVOArr[i]);
                    }
                }
            }
        }

        #region	根据病人住院号查询

        private void m_mthInHospitalNOQuery()
        {
            string strDateBegin = null;
            string strDateEnd = null;
            string strAppID = null;
            string[] strSampleGroupIDArr = null;

            string strBarCode = null;

            string strPatientName = null;
            string strConfirmed = "3";

            string strInHospitalNO = this.m_txtBarCodeQuery.Text;

            clsLisApplMainVO[] objAppVOArr = null;

            clsLISApplicationSchVO objSchVO = new clsLISApplicationSchVO();
            objSchVO.m_strApplicationID = strAppID;
            objSchVO.m_strBarCode = strBarCode;
            objSchVO.m_strConfirmedDateBegin = strDateBegin;
            objSchVO.m_strConfirmedDateEnd = strDateEnd;
            objSchVO.m_strConfirmState = strConfirmed;
            objSchVO.m_strPatientName = strPatientName;
            objSchVO.m_strSampleGroupIDArr = strSampleGroupIDArr;

            long lngRes = this.m_objController.m_lngQueryByInHospitalNO(objSchVO, strInHospitalNO, out objAppVOArr);

            if (lngRes == 0)
            {
                MessageBox.Show(this, "操作失败!", c_strMessageBoxTitle);
            }
            else if (objAppVOArr == null || objAppVOArr.Length == 0)
            {
                MessageBox.Show(this, "没有找到符合条件的记录!", c_strMessageBoxTitle);
            }
            else
            {
                this.m_tabControlFunc.SelectedTab = this.m_tabAppList;
                for (int i = 0; i < objAppVOArr.Length; i++)
                {
                    bool blnHadItem = false;
                    for (int j = 0; j < this.dtbList.Rows.Count; j++)
                    {
                        if (((clsLisApplMainVO)dtbList.Rows[j]["Tag"]).m_strAPPLICATION_ID == objAppVOArr[i].m_strAPPLICATION_ID)
                        {
                            blnHadItem = true;
                        }
                    }
                    if (!blnHadItem)
                    {
                        m_objReportTableNewRow(objAppVOArr[i]);
                    }
                }
                //this.m_tabControlFunc.SelectedTab = this.m_tabAppList;
                //for(int i=0;i<objAppVOArr.Length;i++)
                //{
                //    this.m_lsvReportList.BeginUpdate();
                //    bool blnHadItem = false;
                //    for ( int j = 0; j < this.m_lsvReportList.Items.Count; j++ )
                //    {
                //        if ( ((clsLisApplMainVO)this.m_lsvReportList.Items[j].Tag).m_strAPPLICATION_ID == objAppVOArr[i].m_strAPPLICATION_ID )
                //        {
                //            blnHadItem = true;
                //        }
                //    }
                //    if ( !blnHadItem )
                //    {           
                //        m_objReportListAddReport(objAppVOArr[i]);
                //    }
                //    this.m_lsvReportList.EndUpdate();
                //}
                //this.m_lsvReportList.Focus();
                //if(this.m_lsvReportList.Items.Count != 0)
                //{
                //    this.m_lsvReportList.Items[this.m_lsvReportList.Items.Count -1].Focused = true;
                //    this.m_lsvReportList.Items[this.m_lsvReportList.Items.Count -1].Selected = true;
                //    this.m_mthReportListItemSelected(this.m_lsvReportList.Items[this.m_lsvReportList.Items.Count -1]);
                //}
            }
        }

        #endregion

        private void m_grpQry_Leave(object sender, System.EventArgs e)
        {
            this.m_lsvSampleGroupQuery.TabStop = false;
            this.m_dtpFromDate.TabStop = false;
            this.m_dtpToDate.TabStop = false;
            this.m_btnQuery.TabStop = false;
            this.m_txtPatientNameQuery.TabStop = false;
            this.m_lsvSampleGroupQuery.TabStop = false;
            this.m_txtBarCode.TabStop = false;
            this.m_cboConfirmState.TabStop = false;
        }

        private void m_grpQry_Enter(object sender, System.EventArgs e)
        {
            this.m_lsvSampleGroupQuery.TabStop = true;
            this.m_dtpFromDate.TabStop = true;
            this.m_dtpToDate.TabStop = true;
            this.m_btnQuery.TabStop = true;
            this.m_txtPatientNameQuery.TabStop = true;
            this.m_lsvSampleGroupQuery.TabStop = true;
            this.m_txtBarCode.TabStop = true;
            this.m_cboConfirmState.TabStop = true;
        }

        private void m_txtBarCodeQuery_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strConfig = "";
                long lngRes = 0;
                // 是否跳过样本采集与核收:1-跳过 0-不跳过 2-跳过采集不跳过核收
                lngRes = this.m_objController.m_lngGetCollocate(out strConfig, "4002");
                if (lngRes > 0)
                {
                    //if (blnConfig)
                    //{
                    //    m_mthInHospitalNOQuery();
                    //}
                    //else
                    //{
                    m_mthBarcodeQuery();
                    //}
                }

            }
        }

        #endregion

        #region 查 询
        /// <summary>
        /// 查 询
        /// </summary>
        /// <param name="typeId">1 列表(当天); 2 历史</param>
        private void m_mthQuery(int typeId)
        {
            string strDateBegin = null;
            string strDateEnd = null;
            string strAppID = null;

            string[] strSampleGroupIDArr = new string[0];
            int checkGroupCount = m_lsvSampleGroupQuery.CheckedItems.Count;
            if (checkGroupCount > 0)
            {
                strSampleGroupIDArr = new string[checkGroupCount];
                for (int i = 0; i < checkGroupCount; i++)
                {
                    clsSampleGroup_VO sampleGroup = (clsSampleGroup_VO)this.m_lsvSampleGroupQuery.CheckedItems[i].Tag;
                    strSampleGroupIDArr[i] = sampleGroup.strSampleGroupID;
                }
            }

            //if (this.m_txtAppIDQuery.Text.Trim() != "")
            //{
            //    strAppID = this.m_txtAppIDQuery.Text.Trim().PadLeft(18, '0');
            //}
            //else
            //{
            //    strAppID = null;
            //}


            string strConfirmed = "3";
            if (this.m_cboConfirmState.Text == "未审核")
            {
                strConfirmed = "1";
            }
            else if (this.m_cboConfirmState.Text == "已审核")
            {
                strConfirmed = "2";
            }

            strDateBegin = this.m_dtpFromDate.Value.ToString("yyyy-MM-dd 00:00:00");
            strDateEnd = this.m_dtpToDate.Value.ToString("yyyy-MM-dd 23:59:59");

            string strPatientName = null;
            strPatientName = this.m_txtPatientNameQuery.Text.Trim();

            string strPatientCardNO = this.m_txtPatientCardNO.Text.Trim();

            clsLisApplMainVO[] objAppVOArr = null;

            clsLISApplicationSchVO objSchVO = new clsLISApplicationSchVO();
            objSchVO.m_strApplicationID = strAppID;
            objSchVO.m_strPatientCardNO = strPatientCardNO;
            objSchVO.m_strConfirmedDateBegin = strDateBegin;
            objSchVO.m_strConfirmedDateEnd = strDateEnd;
            objSchVO.m_strConfirmState = strConfirmed;
            objSchVO.m_strPatientName = strPatientName;
            objSchVO.m_strSampleGroupIDArr = strSampleGroupIDArr;
            objSchVO.m_strInhospNO = this.m_txtInHospitalNo.Text.Trim();
            objSchVO.m_strPatientCheckNO = this.m_txtPatientCheckNO.Text.Trim() + "%";
            objSchVO.m_strLoginEmpNo = this.LoginInfo.m_strEmpID;
            string m_strCheckCategory = m_cboCheckCategory.SelectedValue.ToString();

            long lngRes = this.m_objController.m_lngQuery(objSchVO, m_strCheckCategory, out objAppVOArr);

            if (lngRes == 0)
            {
                ShowMessage("操作失败!");
            }
            else if (objAppVOArr == null || objAppVOArr.Length == 0)
            {
                ShowMessage("没有找到符合条件的记录!");
            }
            else
            {
                if (typeId == 1)
                {
                    this.m_tabControlFunc.SelectedTab = this.m_tabAppList;
                    this.dtbList.Rows.Clear();

                    this.m_dtgReportList.RowsAdded -= new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgReportList_RowsAdded);
                    for (int i = 0; i < objAppVOArr.Length; i++)
                    {
                        m_objReportTableNewRow(objAppVOArr[i]);
                    }
                    this.m_dtgReportList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgReportList_RowsAdded);
                }
                else if (typeId == 2)
                {
                    this.m_tabControlFunc.SelectedTab = this.pageHistory;
                    this.gvHistory.Rows.Clear();
                    this.gvHistory.RowsAdded -= new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgReportList_RowsAdded);
                    for (int i = 0; i < objAppVOArr.Length; i++)
                    {
                        m_objReportTableNewRow2(objAppVOArr[i], this.gvHistory);
                    }
                    this.gvHistory.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgReportList_RowsAdded);
                }
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(this, message, c_strMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region 申请基本资料

        private void m_chkUseDefault_CheckedChanged(object sender, System.EventArgs e)
        {
            this.m_objController.m_BlnUseDefault = this.m_chkUseDefault.Checked;
        }

        private void m_btnSelectCheck_Click(object sender, System.EventArgs e)
        {
            clsLisApplMainVO objAppVO = null;
            long lngRes = this.m_objController.m_lngNewApp(out objAppVO);
            if (lngRes == 1)
            {
                #region 自动生成绑定
                clsT_LIS_DeviceRelationVO[] objDRVOArr = null;
                lngRes = this.m_objDecoder.m_lngDecode(objAppVO.m_strApplication_Form_NO, out objDRVOArr);
                if (lngRes == 1 && objDRVOArr != null && objDRVOArr.Length != 0)
                {
                    string strCurTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    for (int i = 0; i < objDRVOArr.Length; i++)
                    {
                        objDRVOArr[i].m_strCHECK_DAT = strCurTime;
                        objDRVOArr[i].m_strRECEPTION_DAT = strCurTime;
                        objDRVOArr[i].m_strSAMPLE_ID_CHR = objAppVO.m_strSampleID;
                        lngRes = this.m_objController.m_lngAddDeviceRelation(objDRVOArr[i]);
                    }
                }
                #endregion

                this.m_objReportTableNewRow(objAppVO);
                this.m_dtgReportList.Rows[addedRowIndex].Selected = true;
            }
        }

        private void m_btnModiryApp_Click(object sender, System.EventArgs e)
        {
            if (this.m_dtgReportList.SelectedRows.Count == 0)
            {
                return;
            }
            clsLisApplMainVO objCurrApp = (clsLisApplMainVO)m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;
            if (this.m_btnModiryApp.Text == "取消")
            {
                //this.m_mthShowAppInfo(objCurrApp);
                this.m_txtCheckNO.Enabled = false;
                this.m_palBaseInfoInput.Enabled = false;
                this.m_btnSelectCheck.Enabled = true;
                this.m_btnSaveApp.Enabled = false;

                m_dtpAcceptDate.Enabled = false;

                this.m_btnModiryApp.Text = "修改";
                return;
            }
            if (objCurrApp.m_intForm_int == 1)
            {
                this.m_txtCheckNO.Enabled = true;
            }
            else
            {
                this.m_txtCheckNO.Enabled = true;
                this.m_palBaseInfoInput.Enabled = true;
                this.m_btnSelectCheck.Enabled = false;
            }

            if (m_blnCanModifyAcceptDat && objCurrApp.m_intReportStatus == 1)
            {
                m_dtpAcceptDate.Enabled = true;
            }
            else
            {
                m_dtpAcceptDate.Enabled = false;
            }

            this.m_btnSaveApp.Enabled = true;
            this.m_btnModiryApp.Text = "取消";
            this.m_txtCheckNO.Focus();
        }

        private void m_btnSaveApp_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            m_mthSaveApp();
            this.m_txtBarCodeQuery.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void m_mthSaveApp()
        {
            if (this.m_dtgReportList.SelectedRows.Count == 0)
            {
                return;
            }

            clsLisApplMainVO objCurrApp = (clsLisApplMainVO)m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;

            clsLisApplMainVO objApp = new clsLisApplMainVO();
            this.m_mthGetAppInfoFromView(objApp);

            if (objCurrApp.m_intForm_int == 1)
            {
                if (objCurrApp.m_strPatient_Name != objApp.m_strPatient_Name || objCurrApp.m_strAppl_Dat != objApp.m_strAppl_Dat)
                {
                    MessageBox.Show(this, "检测到不相符的数据，请再次选择报告后重新输入！", "iCare-LIS");
                    return;
                }
            }

            objApp.m_intForm_int = objCurrApp.m_intForm_int;
            objApp.m_intPStatus_int = objCurrApp.m_intPStatus_int;
            objApp.m_intReportStatus = objCurrApp.m_intReportStatus;
            objApp.m_intSampleStatus = objCurrApp.m_intSampleStatus;
            objApp.m_strAPPLICATION_ID = objCurrApp.m_strAPPLICATION_ID;
            objApp.m_strCheckContent = objCurrApp.m_strCheckContent;
            objApp.m_strChargeInfo = objCurrApp.m_strChargeInfo;
            objApp.m_strICD = objCurrApp.m_strICD;
            objApp.m_strOriginDate = objCurrApp.m_strOriginDate;
            objApp.m_strPatient_SubNO = objCurrApp.m_strPatient_SubNO;
            objApp.m_strPatientcardID = objCurrApp.m_strPatientcardID;
            objApp.m_strPatientID = objCurrApp.m_strPatientID;
            objApp.m_strReportDate = objCurrApp.m_strReportDate;
            objApp.m_strReportGroupID = objCurrApp.m_strReportGroupID;
            objApp.m_strSampleID = objCurrApp.m_strSampleID;

            objApp.m_strAcceptDate = m_dtpAcceptDate.Value.ToString("yyyy-MM-dd HH:mm");
            objApp.m_strPrintDate = objCurrApp.m_strPrintDate;
            objApp.m_isPrinted = objCurrApp.m_isPrinted;

            bool blnCheckNOIsModified = false;
            if (objApp.m_strApplication_Form_NO != objCurrApp.m_strApplication_Form_NO)
            {
                blnCheckNOIsModified = true;
            }

            long lngRes = this.m_objController.m_lngSaveAppAndModifySample(objApp);
            if (lngRes > 0)
            {
                m_dtgReportList.SelectedRows[0].Cells["Tag"].Value = objApp;
                m_dtgReportList.SelectedRows[0].Cells["CheckNO"].Value = objApp.m_strApplication_Form_NO;
                m_dtgReportList.SelectedRows[0].Cells["PatientName"].Value = objApp.m_strPatient_Name;

                this.m_txtCheckNO.Enabled = false;
                this.m_palBaseInfoInput.Enabled = false;
                this.m_btnSelectCheck.Enabled = true;
                this.m_btnSaveApp.Enabled = false;
                this.m_btnModiryApp.Text = "修改";

                m_dtpAcceptDate.Enabled = false;

                #region 更改仪器绑定
                if (blnCheckNOIsModified)
                {
                    lngRes = this.m_objController.m_lngDeleteCurrAppDR();
                    if (lngRes > 0)
                    {
                        m_mthResetDeviceRelation();
                        clsT_LIS_DeviceRelationVO[] objDRVOArr = null;
                        lngRes = this.m_objDecoder.m_lngDecode(objApp.m_strApplication_Form_NO, out objDRVOArr);
                        if (lngRes == 1 && objDRVOArr != null && objDRVOArr.Length != 0)
                        {
                            string strCurTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            for (int i = 0; i < objDRVOArr.Length; i++)
                            {
                                objDRVOArr[i].m_strCHECK_DAT = strCurTime;
                                objDRVOArr[i].m_strRECEPTION_DAT = strCurTime;
                                objDRVOArr[i].m_strSAMPLE_ID_CHR = this.m_objController.m_objLISInfoVO.m_objSampleVO.m_strSAMPLE_ID_CHR;
                                if (string.IsNullOrEmpty(objDRVOArr[i].m_strBARCODE_VCHR))
                                    objDRVOArr[i].m_strBARCODE_VCHR = this.m_objController.m_objLISInfoVO.m_objSampleVO.m_strBARCODE_VCHR;
                                lngRes = 0;
                                lngRes = this.m_objController.m_lngAddDeviceRelation(objDRVOArr[i]);
                                if (lngRes > 0)
                                {
                                    this.m_mthShowDeviceRelation(this.m_objController.m_objLISInfoVO, true);
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                MessageBox.Show(this, c_strMessageDataErr, c_strMessageBoxTitle);
            }
        }

        private void m_mthGetAppInfoFromView(clsLisApplMainVO p_objAppVO)
        {
            if (p_objAppVO == null)
                return;
            if (this.m_txtPatientID.Text.Trim() != "")
            {
                p_objAppVO.m_strPatientID = this.m_txtPatientID.Text.Trim();
            }
            p_objAppVO.m_strPatient_inhospitalno_chr = this.m_txtInhospNO.Text.Trim();
            p_objAppVO.m_strPatient_Name = this.m_txtPatientName.Text.Trim();
            p_objAppVO.m_strSex = this.m_cboSex.Text.Trim();
            if (this.m_txtAge.Text.Trim() != null)
            {
                p_objAppVO.m_strAge = this.m_txtAge.Text.Trim() + " " + this.m_cboAgeUnit.Text.Trim();
            }
            else
            {
                p_objAppVO.m_strAge = null;
            }
            p_objAppVO.m_strAppl_EmpID = this.m_txtAppDoct.m_StrEmployeeID;
            p_objAppVO.m_strAppl_DeptID = this.m_txtAppDept.m_StrDeptID;
            p_objAppVO.m_strBedNO = this.m_txtBedNO.Text.Trim();
            p_objAppVO.m_strPatientType = this.m_cboPatientType.SelectedValue.ToString().Trim();
            if (this.m_chkEmergency.Checked)
            {
                p_objAppVO.m_intEmergency = 1;
            }
            else
            {
                p_objAppVO.m_intEmergency = 0;
            }
            if (this.m_chkSpecial.Checked)
            {
                p_objAppVO.m_intSpecial = 1;
            }
            else
            {
                p_objAppVO.m_intSpecial = 0;
            }
            p_objAppVO.m_strDiagnose = this.m_rtbDiagnose.Text.Trim();
            p_objAppVO.m_strSummary = this.m_rtbAppSummary.Text.Trim();
            p_objAppVO.m_strApplication_Form_NO = this.m_txtCheckNO.Text.Trim();
            p_objAppVO.m_strSampleType = this.m_cboSampleType.Text;
            if (this.m_cboSampleType.SelectedValue == null)
            {
                MessageBox.Show("请注意--当前标本类型为空！", "iCare-LIS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_objAppVO.m_strSampleTypeID = this.m_cboSampleType.SelectedValue.ToString().Trim();
            }
            p_objAppVO.m_strOperator_ID = this.LoginInfo.m_strEmpID;

            p_objAppVO.m_strAppl_Dat = this.m_dtpAppDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //			p_objAppVO.m_IntForm = 0;
            //			p_objAppVO.m_IntPStatus = 2;

        }

        private void m_txtCheckNO_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this.m_objDecoder.m_blnIsRegularCheckNO(this.m_txtCheckNO.Text))
                e.Cancel = true;
        }

        #endregion

        #region 主体功能按键

        private void m_btnSaveReport_Click(object sender, System.EventArgs e)
        {
            this.m_btnSaveReport.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            string applicationId = string.Empty;
            this.m_blnSaveReport(out applicationId);
            System.Threading.Thread.Sleep(1000);

            this.m_btnSaveReport.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_btnConfirmReport_Click(object sender, System.EventArgs e)
        {
            // 系统设置：4004 
            bool isNeedLoginIn = clsLisSetting.IsComfirmNeedLoginIn();

            if (isNeedLoginIn)
            {
                if (string.IsNullOrEmpty(m_strSubmitDoctorId))
                {
                    SubmitLogin();

                    if (string.IsNullOrEmpty(m_strSubmitDoctorId))
                    {
                        return;
                    }
                }
            }

            bool isSubmit = MessageBox.Show(this, "注意:审核之后将无法修改!", "iCare-报告录入", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK;
            if (isSubmit)
            {
                m_btnConfirmReport.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                this.m_mthConfirmReport();
                Cursor.Current = Cursors.Default;
            }
        }

        private void m_btnDelete_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(this, "确定要删除本报告?", "iCare-报告录入", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.m_btnDelete.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                clsLisApplMainVO objLisApplVo = (clsLisApplMainVO)m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;
                long lngRes = 0;
                DataTable dtResult = null;
                DataTable dtUnitResult = null;
                lngRes = m_objController.m_lnqQueryConfirmReport(objLisApplVo.m_strAPPLICATION_ID, out dtResult, out dtUnitResult);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    if (dtResult.Rows[0]["status_int"].ToString().Trim() == "6")
                    {
                        m_mthVoidReport(objLisApplVo.m_strAPPLICATION_ID, dtResult);
                    }
                    else
                    {
                        this.m_mthDelete();
                    }
                }

                this.m_btnDelete.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void m_btnNewApp_Click(object sender, System.EventArgs e)
        {
            this.m_tabControlFunc.SelectedTab = this.m_tabAppList;
            this.m_btnNewApp.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            this.m_mthNew();

            Cursor.Current = Cursors.Default;
        }

        private void m_btnPreviewReport_Click(object sender, System.EventArgs e)
        {
            this.m_objController.m_mthPreview();
        }

        private void m_btnPrintReport_Click(object sender, System.EventArgs e)
        {
            this.m_btnPrintReport.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            this.m_objController.m_mthPrint();

            this.m_btnPrintReport.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_btnPreference_Click(object sender, System.EventArgs e)          //设置按钮
        {
            frmHandInputReportPreferences frmPre = new frmHandInputReportPreferences();
            if (frmPre.ShowDialog() == DialogResult.OK)
            {
                this.m_objPreferenceStyle.m_blnBatchConfirmStyle = frmPre.m_chkUseBatchConfirmStyle.Checked;
                this.m_objPreferenceStyle.m_blnAutoPrint = frmPre.m_chkAutoPrint.Checked;
            }
        }

        private void m_mthDelete()
        {
            if (this.m_dtgReportList.SelectedRows.Count == 0)
                return;
            int idx = this.m_dtgReportList.SelectedRows[0].Index;
            long lngRes = this.m_objController.m_lngDelete(((clsLisApplMainVO)m_dtgReportList.SelectedRows[0].Cells["Tag"].Value).m_strAPPLICATION_ID);
            if (lngRes <= 0)
            {
                MessageBox.Show(this, "删除申请单失败!", c_strMessageBoxTitle);
            }
            else
            {
                this.m_dtgReportList.Rows.Remove(this.m_dtgReportList.SelectedRows[0]);
                if (this.m_dtgReportList.Rows.Count > 0)
                {
                    if (idx > 0 && idx < this.m_dtgReportList.Rows.Count)
                    {
                        this.m_dtgReportList.Rows[idx].Selected = true;
                    }
                    else if (idx - 1 > 0)
                    {
                        this.m_dtgReportList.Rows[idx - 1].Selected = true;
                    }
                    else
                    {
                        this.m_dtgReportList.Rows[0].Selected = true;
                    }
                }
                else
                {
                    m_mthResetAll();
                }
            }
        }

        private void m_mthNew()
        {
            this.m_mthResetAll();

            //			this.m_cboPatientType.SelectedIndex = 0;
            this.m_cboAgeUnit.SelectedIndex = 0;
            this.m_cboSex.SelectedIndex = 0;
            this.m_dtpAppDate.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            this.m_palBaseInfoInput.Enabled = true;
            this.m_txtCheckNO.Enabled = true;
            this.m_txtPatientCard.Enabled = true;

            this.m_btnConfirmReport.Enabled = false;
            this.m_btnSaveReport.Enabled = false;
            this.m_btnPreviewReport.Enabled = false;
            this.m_btnPrintReport.Enabled = false;
            this.m_btnNewApp.Enabled = true;
            this.m_btnDelete.Enabled = false;

            if (this.m_dtgReportList.Rows.Count > 0)
            {
                string strLastNO = this.m_dtgReportList.Rows[this.m_dtgReportList.Rows.Count - 1].Cells["CheckNO"].Value.ToString();
                string strNextCheckNO = null;
                this.m_objDecoder.m_mthGetNextCheckNO(strLastNO, out strNextCheckNO);
                this.m_txtCheckNO.Text = strNextCheckNO;

            }
            this.m_txtCheckNO.Focus();
            this.m_txtCheckNO.SelectionStart = this.m_txtCheckNO.Text.Length;
            this.m_txtCheckNO.SelectionLength = 0;
        }


        #endregion

        #region 仪器绑定

        private void m_btnModifyBind_Click(object sender, System.EventArgs e)
        {
            if (this.m_btnModifyBind.Text == "修改")
            {
                this.m_btnModifyBind.Text = "取消";
                this.m_palBindInput.Enabled = true;
                this.m_btnConfirmBind.Enabled = true;
                this.m_btnImportData.Enabled = false;
                this.m_btnImportNewResult.Enabled = false;
                this.m_btnSyncretize.Enabled = false;
                this.m_txtBindSate.Clear();
                this.m_cboCheckDeviceList.Focus();
            }
            else
            {
                clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag;
                this.m_mthSetRelation(objDRVO, this.m_objController.m_objLISInfoVO.m_objSampleVO.m_intSTATUS_INT);

            }
        }

        private void m_btnConfirmBind_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_mthConfirmBind(true);
            Cursor.Current = Cursors.Default;
        }

        private void m_btnSyncretize_Click(object sender, System.EventArgs e)
        {
            clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag;

            string strDeviceID = objDRVO.m_strDEVICEID_CHR;
            int intImportReq = objDRVO.m_intIMPORT_REQ_INT;
            frmSampleUnite frm = new frmSampleUnite();
            DialogResult objDlgR = frm.m_objShowDialog(strDeviceID, intImportReq);
            if (objDlgR == DialogResult.OK)
            {
                clsDeviceReslutVO[] objDeviceResultArr = frm.m_objGetSyncretizedResults();
                this.m_objController.m_mthSetDeviceData(this.m_objController.m_dtbResult, objDeviceResultArr);
            }
        }

        private void m_btnAddDeviceSample_Click(object sender, System.EventArgs e)
        {
            m_mthAddDeviceSample();
        }

        private void m_btnDeleteDeviceSample_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_mthDeleteDeviceSample();
            Cursor.Current = Cursors.Default;
        }

        private void m_btnImportNewResult_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_mthConfirmBind(false);
            Cursor.Current = Cursors.Default;
        }

        private void m_btnImportData_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnImportData.Enabled = false;
            clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag;
            this.m_objController.m_mthImportData(objDRVO);
            this.m_btnImportData.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_cboCheckDeviceList_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ctlLISDeviceComboBox cboDeviceList = (ctlLISDeviceComboBox)sender;
            if (cboDeviceList.SelectedItem != null
                && ((DataRowView)cboDeviceList.SelectedItem)["DEVICENAME_VCHR"].ToString() == cboDeviceList.Text)
            {
                return;
            }
            string strInput = this.m_cboCheckDeviceList.Text;
            clsT_LIS_DeviceRelationVO[] objDRVOArr = null;
            this.m_objDecoder.m_lngDecode(strInput, out objDRVOArr);
            if (objDRVOArr != null && objDRVOArr.Length == 1 && objDRVOArr[0] != null)
            {
                if (objDRVOArr[0].m_strDEVICE_SAMPLEID_CHR == null || objDRVOArr[0].m_strDEVICE_SAMPLEID_CHR.Trim() == "")
                {
                    this.m_cboCheckDeviceList.SelectedValue = objDRVOArr[0].m_strDEVICEID_CHR;
                    return;
                }
                this.m_cboCheckDeviceList.SelectedValue = objDRVOArr[0].m_strDEVICEID_CHR;
                this.m_txtDeviceSampleID.Text = objDRVOArr[0].m_strDEVICE_SAMPLEID_CHR;
                return;
            }
            e.Cancel = true;
        }

        private void m_cboCheckDeviceList_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void m_mthDeleteDeviceSample()
        {
            if (this.m_tabControlSample.SelectedTab == null)
                return;

            clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag;
            if (objDRVO.m_intSTATUS_INT == -1)
            {
                this.m_tabControlSample.TabPages.Remove(this.m_tabControlSample.SelectedTab);
                this.m_btnAddDeviceSample.Enabled = true;
            }
            else
            {
                string strMessage;
                bool blnRes;
                //				if(MessageBox.Show(this,"确定作废数据绑定吗?",c_strMessageBoxTitle,MessageBoxButtons.OKCancel,MessageBoxIcon.Question) != DialogResult.OK)
                //				{
                //					return;
                //				}
                blnRes = this.m_objController.m_blnDeleteRelation(objDRVO, out strMessage);
                if (!blnRes)
                {
                    MessageBox.Show(this, strMessage, c_strMessageBoxTitle);
                    return;
                }
                else
                {
                    this.m_tabControlSample.TabPages.Remove(this.m_tabControlSample.SelectedTab);
                    //					DataTable dtbResult = ((DataView)this.m_objViewer.m_dtgResultList.DataSource).Table;
                    //					this.m_mthSetDeviceDataNull(dtbResult,objAppSampleGroup);
                }
            }
            //			this.m_mthResignBind();
            if (this.m_tabControlSample.TabPages.Count == 0)
            {
                this.m_grbRelation.Visible = false;
                this.m_btnDeleteDeviceSample.Enabled = false;
                this.m_btnAddDeviceSample.Enabled = true;
            }
        }

        private void m_mthAddDeviceSample()
        {

            int intIdx = this.m_tabControlSample.TabPages.Count + 1;
            TabPage tab = new TabPage(intIdx.ToString());
            clsT_LIS_DeviceRelationVO objDRVO = new clsT_LIS_DeviceRelationVO();
            tab.Tag = objDRVO;
            this.m_tabControlSample.TabPages.Add(tab);
            this.m_tabControlSample.SelectedTab = tab;

            try
            {
                this.m_cboCheckDeviceList.SelectedIndex = 0;
            }
            catch { }
            this.m_txtDeviceSampleID.Clear();
            this.m_dtpCheckDate.Value = DateTime.Now;
            this.m_txtBindSate.Clear();

            this.m_grbRelation.Visible = true;
            this.m_palBindInput.Enabled = true;

            this.m_btnConfirmBind.Enabled = true;
            this.m_btnModifyBind.Enabled = false;
            this.m_btnImportData.Enabled = false;
            this.m_btnImportNewResult.Enabled = false;
            this.m_btnSyncretize.Enabled = false;
            this.m_btnAddDeviceSample.Enabled = false;
            this.m_btnDeleteDeviceSample.Enabled = true;

            this.m_cboCheckDeviceList.Focus();
        }

        private void m_mthConfirmBind(bool p_blnCehckModified)
        {
            if (this.m_txtDeviceSampleID.Text.Trim() == "")
            {
                this.m_txtDeviceSampleID.Focus();
                return;
            }
            if (m_blnDeviceIsOver(this.m_cboCheckDeviceList.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show(this, "仪器不可重复!", c_strMessageBoxTitle);
                return;
            }
            clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag;
            long lngRes = 0;
            if (objDRVO.m_intSTATUS_INT == -1)//新增
            {
                objDRVO.m_strCHECK_DAT = this.m_dtpCheckDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                objDRVO.m_strDEVICE_SAMPLEID_CHR = this.m_txtDeviceSampleID.Text.Trim();
                objDRVO.m_strDEVICEID_CHR = this.m_cboCheckDeviceList.SelectedValue.ToString().Trim();
                objDRVO.m_strRECEPTION_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objDRVO.m_strSAMPLE_ID_CHR = this.m_objController.m_objLISInfoVO.m_objSampleVO.m_strSAMPLE_ID_CHR;
                lngRes = this.m_objController.m_lngAddNewDeviceRelation(objDRVO);
                if (lngRes == 1)
                    this.m_btnAddDeviceSample.Enabled = true;
            }
            else//修改
            {
                clsT_LIS_DeviceRelationVO objTargetVO = new clsT_LIS_DeviceRelationVO();
                objTargetVO.m_strDEVICEID_CHR = this.m_cboCheckDeviceList.SelectedValue.ToString().Trim();
                objTargetVO.m_strCHECK_DAT = this.m_dtpCheckDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                objTargetVO.m_strDEVICE_SAMPLEID_CHR = this.m_txtDeviceSampleID.Text.Trim();
                objTargetVO.m_strRECEPTION_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objTargetVO.m_strSAMPLE_ID_CHR = this.m_objController.m_objLISInfoVO.m_objSampleVO.m_strSAMPLE_ID_CHR;

                if (p_blnCehckModified
                    && objTargetVO.m_strDEVICEID_CHR == objDRVO.m_strDEVICEID_CHR
                    && objTargetVO.m_strDEVICE_SAMPLEID_CHR == objDRVO.m_strDEVICE_SAMPLEID_CHR
                    && DateTime.Parse(objTargetVO.m_strCHECK_DAT).ToLongDateString() == DateTime.Parse(objDRVO.m_strCHECK_DAT).ToLongDateString())
                {
                    lngRes = 1;
                }
                else
                {
                    lngRes = this.m_objController.m_lngModifyBind(objDRVO, objTargetVO);
                    if (lngRes == 1)
                    {
                        this.m_tabControlSample.SelectedTab.Tag = objTargetVO;
                    }
                }
            }
            if (lngRes == 1)
            {
                m_mthSetRelation((clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag, this.m_objController.m_objLISInfoVO.m_objSampleVO.m_intSTATUS_INT);
            }
        }

        private bool m_blnDeviceIsOver(string p_strDeviceID)
        {
            clsT_LIS_DeviceRelationVO objCurrDRVO = (clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag;
            string strOldDeviceID = objCurrDRVO.m_strDEVICEID_CHR;
            objCurrDRVO.m_strDEVICEID_CHR = this.m_cboCheckDeviceList.SelectedValue.ToString().Trim();

            int intCount = 0;
            foreach (TabPage tp in this.m_tabControlSample.TabPages)
            {
                clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)tp.Tag;
                if (objDRVO.m_strDEVICEID_CHR == p_strDeviceID)
                    intCount++;
            }
            objCurrDRVO.m_strDEVICEID_CHR = strOldDeviceID;

            if (intCount >= 2)
                return true;
            else
                return false;
        }

        private bool m_blnIsNewRelation()
        {
            clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag;
            if (objDRVO.m_intSTATUS_INT == -1)
                return true;
            return false;
        }

        #endregion

        #region 仪器绑定列表

        private void m_tabControlSample_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.m_tabControlSample.SelectedTab != null && this.m_tabControlSample.SelectedTab.Tag != null)
            {
                this.m_tabControlSample.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                clsT_LIS_DeviceRelationVO objDRVO = ((clsT_LIS_DeviceRelationVO)this.m_tabControlSample.SelectedTab.Tag);
                this.m_mthSetRelation(objDRVO, this.m_objController.m_objLISInfoVO.m_objSampleVO.m_intSTATUS_INT);

                this.m_tabControlSample.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void m_mthSetRelation(clsT_LIS_DeviceRelationVO p_objRelation, int p_intSampleStatus)
        {

            if (p_objRelation == null)
                return;


            this.m_btnModifyBind.Text = "修改";

            this.m_mthRelation2View(p_objRelation);

            this.m_tabControlSample.SelectedTab.Text = this.m_cboCheckDeviceList.Text;

            if (p_intSampleStatus == 3
                || p_intSampleStatus == 5)
            {
                if (p_objRelation.m_intSTATUS_INT == -1)
                {
                    this.m_palBindInput.Enabled = true;

                    this.m_btnConfirmBind.Enabled = true;
                    this.m_btnModifyBind.Enabled = false;
                    this.m_btnSyncretize.Enabled = false;
                    this.m_btnAddDeviceSample.Enabled = false;
                    this.m_btnImportNewResult.Enabled = false;
                    this.m_btnImportData.Enabled = false;

                    this.m_cboCheckDeviceList.SelectedIndex = 1;
                    this.m_cboCheckDeviceList.Focus();
                }
                else
                {
                    this.m_palBindInput.Enabled = false;
                    this.m_btnConfirmBind.Enabled = false;
                    this.m_btnModifyBind.Enabled = true;
                    this.m_btnSyncretize.Enabled = true;
                    this.m_btnImportNewResult.Enabled = true;
                    this.m_btnImportData.Enabled = true;
                }
            }
            else if (p_intSampleStatus == 6 && this.GetConfirmDays() <= 7)
            {
                if (p_objRelation.m_intSTATUS_INT == -1)
                {
                    this.m_palBindInput.Enabled = true;

                    this.m_btnConfirmBind.Enabled = true;
                    this.m_btnModifyBind.Enabled = false;
                    this.m_btnSyncretize.Enabled = false;
                    this.m_btnAddDeviceSample.Enabled = false;
                    this.m_btnImportNewResult.Enabled = false;
                    this.m_btnImportData.Enabled = false;

                    this.m_cboCheckDeviceList.SelectedIndex = 1;
                    this.m_cboCheckDeviceList.Focus();
                }
                else
                {
                    this.m_palBindInput.Enabled = false;
                    this.m_btnConfirmBind.Enabled = false;
                    this.m_btnModifyBind.Enabled = true;
                    this.m_btnSyncretize.Enabled = true;
                    this.m_btnImportNewResult.Enabled = true;
                    this.m_btnImportData.Enabled = true;
                }
            }
            else
            {
                this.m_btnImportNewResult.Enabled = false;
                this.m_btnImportData.Enabled = false;
                this.m_palBindInput.Enabled = false;
                this.m_btnConfirmBind.Enabled = false;
                this.m_btnModifyBind.Enabled = false;
                this.m_btnSyncretize.Enabled = false;
            }

        }

        private void m_mthRelation2View(clsT_LIS_DeviceRelationVO p_objRelation)
        {
            if (p_objRelation != null)
            {
                #region DeviceRelation 到界面

                this.m_txtDeviceSampleID.Text = p_objRelation.m_strDEVICE_SAMPLEID_CHR;
                try
                {
                    this.m_cboCheckDeviceList.SelectedValue = p_objRelation.m_strDEVICEID_CHR;
                    this.m_cboCheckDeviceList.SelectedValue = p_objRelation.m_strDEVICEID_CHR;
                    this.m_cboCheckDeviceList.SelectedValue = p_objRelation.m_strDEVICEID_CHR;
                    this.m_cboCheckDeviceList.Refresh();
                }
                catch
                {
                    this.m_cboCheckDeviceList.SelectedItem = null;
                    this.m_cboCheckDeviceList.SelectedItem = null;
                    this.m_cboCheckDeviceList.SelectedItem = null;
                    this.m_cboCheckDeviceList.Refresh();
                }
                if (Microsoft.VisualBasic.Information.IsDate(p_objRelation.m_strCHECK_DAT))
                {
                    this.m_dtpCheckDate.Value = DateTime.Parse(p_objRelation.m_strCHECK_DAT);
                }
                else
                {
                    this.m_dtpCheckDate.Value = DateTime.Now;
                }
                if (p_objRelation.m_intSTATUS_INT == 1)
                {
                    this.m_txtBindSate.Text = "未绑定";
                }
                else if (p_objRelation.m_intSTATUS_INT == 2)
                {
                    this.m_txtBindSate.Text = "已绑定";
                }
                else
                {
                    this.m_txtBindSate.Clear();
                }
                #endregion
            }
        }

        #endregion

        #region 项目结果列表

        private void m_mnuValueTemplate_Click(object sender, System.EventArgs e)
        {
            this.m_mnuValueTemplate.Checked = !this.m_mnuValueTemplate.Checked;
            this.m_BlnUseValueTemplate = this.m_mnuValueTemplate.Checked;
        }

        private void m_btnExtEditModel_Click(object sender, System.EventArgs e)
        {
            if (this.m_btnExtEditModel.AccessibleDescription == "Normal")
            {
                this.m_btnExtEditModel.AccessibleDescription = "Extend";
                this.m_btnExtEditModel.Text = "<<";
                this.m_palExtEdit.Location = new Point(60, 22);
                this.m_palExtEdit.Size = new Size(644, 574);
                this.m_palExtEdit.Controls.Add(this.m_dtgResultList);
                this.m_dtgResultList.Width = 225;
                this.m_dtgResultList.Dock = DockStyle.Left;
                foreach (object obj in this.m_arlDataColumn)
                {
                    this.m_dtgResultList.TableStyles[0].GridColumnStyles.Remove((DataGridColumnStyle)obj);
                }
                this.m_palExtEdit.Controls.Add(this.m_palSummary);
                this.m_palSummary.Dock = DockStyle.Fill;
                this.m_palSummary.BringToFront();
                this.m_palExtEdit.Visible = true;
                this.m_palExtEdit.BringToFront();
            }
            else//this.m_btnExtEditModel.AccessibleDescription == "Extend"
            {
                this.m_btnExtEditModel.AccessibleDescription = "Normal";
                this.m_btnExtEditModel.Text = ">>";
                this.m_tabCheckResult.Controls.Add(this.m_dtgResultList);
                this.m_dtgResultList.Dock = DockStyle.Fill;
                DataGridColumnStyle objColumn = this.m_dtgResultList.TableStyles[0].GridColumnStyles[1];
                this.m_dtgResultList.TableStyles[0].GridColumnStyles.Remove(objColumn);
                this.m_dtgResultList.TableStyles[0].GridColumnStyles.Add((DataGridColumnStyle)this.m_arlDataColumn[0]);
                this.m_dtgResultList.TableStyles[0].GridColumnStyles.Add(objColumn);
                this.m_dtgResultList.TableStyles[0].GridColumnStyles.Add((DataGridColumnStyle)this.m_arlDataColumn[1]);
                this.m_dtgResultList.TableStyles[0].GridColumnStyles.Add((DataGridColumnStyle)this.m_arlDataColumn[2]);
                this.m_tabReport.Controls.Add(this.m_palSummary);
                this.m_palSummary.Dock = DockStyle.Fill;
                this.m_palExtEdit.Visible = false;
            }
        }

        #endregion

        #region 申请单列表

        private void m_dtgReportList_SelectionChanged(object sender, EventArgs e)
        {
            if (this.m_dtgReportList.SelectedRows.Count == 0)
            {
                return;
            }

            clsLisApplMainVO objApp = (clsLisApplMainVO)m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;
            string strAppID = objApp.m_strAPPLICATION_ID;
            string strOriginDate = objApp.m_strOriginDate;
            m_mthResetAll();

            clsLISInfoVO objInfo = null;
            long lngRes = this.m_objController.m_lngSelectReport(strAppID, strOriginDate, out objInfo);
            if (lngRes <= 0)
            {
                MessageBox.Show(this, c_strMessageDataErr, c_strMessageBoxTitle);
                return;
            }
            if (objInfo != null)
            {
                #region 取得收费信息

                if (objInfo.m_objAppMainVO.m_strPatientType != "1")
                {
                    long lngRes2 = clsDomainController_ApplicationManage.m_lngGetChargeState(objInfo.m_objAppMainVO.m_strAPPLICATION_ID);
                    switch (lngRes2)
                    {
                        case 0:
                            MessageBox.Show(this, "不能联接到收费系统，请与管理员联系！", c_strMessageBoxTitle);
                            objInfo.m_objAppMainVO.m_intChargeState = 0;
                            break;
                        case 1:
                            objInfo.m_objAppMainVO.m_intChargeState = 1;
                            break;
                        case 2:
                            objInfo.m_objAppMainVO.m_intChargeState = 2;
                            break;
                        default:
                            objInfo.m_objAppMainVO.m_intChargeState = 0;
                            break;
                    }
                }
                #endregion

                #region AppInfo
                m_mthShowAppInfo(objInfo.m_objAppMainVO);

                #endregion

                #region ReportInfo
                if ((objInfo.m_objReportVO.m_strREPORTOR_ID_CHR == null
                    || objInfo.m_objReportVO.m_strREPORTOR_ID_CHR.Trim() == "")
                    && (objInfo.m_objSampleVO.m_intSTATUS_INT == 3
                    || objInfo.m_objSampleVO.m_intSTATUS_INT == 5))
                {
                    if (this.LoginInfo == null || this.LoginInfo.m_strEmpID == null || this.LoginInfo.m_strEmpID.Trim() == "")
                    {
                        this.m_txtReportDoct.m_mthClear();
                    }
                    else
                    {
                        this.m_txtReportDoct.m_StrEmployeeID = this.LoginInfo.m_strEmpID;
                    }
                }
                else
                {
                    this.m_txtReportDoct.m_StrEmployeeID = objInfo.m_objReportVO.m_strREPORTOR_ID_CHR;
                }
                try
                {
                    this.m_dtpReportDate.Value = DateTime.Parse(objInfo.m_objReportVO.m_strREPORT_DAT);
                }
                catch { this.m_dtpReportDate.Value = DateTime.Now; }
                this.m_rtbCheckSummary.m_mthSetNewText(objInfo.m_objReportVO.m_strSUMMARY_VCHR, objInfo.m_objReportVO.m_strXML_SUMMARY_VCHR);
                this.m_rtbAnnotation.m_mthSetNewText(objInfo.m_objReportVO.m_strANNOTATION_VCHR, objInfo.m_objReportVO.m_strXML_ANNOTATION_VCHR);
                this.m_txtBarCode.Text = objInfo.m_objSampleVO.m_strBARCODE_VCHR;


                int intStatus = objInfo.m_objReportVO.m_intSTATUS_INT;

                try
                {
                    m_dtpAcceptDate.Value = DateTime.Parse(objInfo.m_objSampleVO.m_strACCEPT_DAT);
                }
                catch
                {
                    m_dtpAcceptDate.Value = DateTime.Now;
                }

                switch (intStatus)
                {
                    case 1:
                        this.m_txtAuditingStatus.Text = "未审核";
                        break;
                    case 2:
                        this.m_txtAuditingStatus.Text = "已审核";
                        break;
                    default:
                        break;
                }
                #endregion

                #region Result
                lngRes = 0;
                lngRes = this.m_objController.m_lngGetCheckItemResults(objInfo.m_objAppMainVO.m_intSampleStatus,
                    objInfo.m_objAppMainVO.m_strAPPLICATION_ID, objInfo.m_objAppMainVO.m_strOriginDate);
                if (lngRes <= 0)
                {
                    MessageBox.Show(this, c_strMessageDataErr, c_strMessageBoxTitle);
                }
                //				this.m_dtgResultList.Refresh();
                #endregion

                #region 仪器关联
                m_mthShowDeviceRelation(objInfo, false);
                #endregion

            }
            this.m_mthSetUI(objApp);
            if (objInfo.m_objAppMainVO.m_intReportStatus == 1
                && objInfo.m_objAppMainVO.m_intForm_int == 1
                && (objInfo.m_objAppMainVO.m_strApplication_Form_NO == null
                || objInfo.m_objAppMainVO.m_strApplication_Form_NO.Trim() == ""))
            {
                this.m_btnModiryApp_Click(null, null);
                if (objInfo.m_objAppMainVO.m_intSampleStatus == 3 && objInfo.m_objAppMainVO.m_intForm_int == 1)
                {
                    if (this.m_dtgReportList.SelectedRows[0].Index >= 1)
                    {
                        string strLastNO = this.m_dtgReportList.Rows[this.m_dtgReportList.SelectedRows[0].Index - 1].Cells["CheckNO"].Value.ToString();
                        string strNextCheckNO = null;
                        this.m_objDecoder.m_mthGetNextCheckNO(strLastNO, out strNextCheckNO);
                        this.m_txtCheckNO.Text = strNextCheckNO;

                    }
                    this.m_txtCheckNO.Focus();
                    this.m_txtCheckNO.SelectionStart = this.m_txtCheckNO.Text.Length;
                    this.m_txtCheckNO.SelectionLength = 0;
                    this.m_txtCheckNO.Focus();
                }
            }
        }

        private DataRow m_objReportTableNewRow(clsLisApplMainVO objCheckReport)
        {
            if (objCheckReport == null)
            {
                return null;
            }

            return dtbList.Rows.Add(objCheckReport.m_strApplication_Form_NO,
                objCheckReport.m_strPatient_Name,
                objCheckReport.m_intReportStatus == 2 ? "√" : "",
                objCheckReport.m_strCheckContent,
                objCheckReport.m_strPatientcardID,
                objCheckReport.m_strAcceptDate,
                objCheckReport);
        }

        private void m_objReportTableNewRow2(clsLisApplMainVO objCheckReport, DataGridView gv)
        {
            if (objCheckReport == null)
            {
                return;
            }

            object[] objs = new object[7];
            int n = -1;
            objs[++n] = objCheckReport.m_strApplication_Form_NO;
            objs[++n] = objCheckReport.m_strPatient_Name;
            objs[++n] = objCheckReport.m_intReportStatus == 2 ? "√" : "";
            objs[++n] = objCheckReport.m_strCheckContent;
            objs[++n] = objCheckReport.m_strPatientcardID;
            objs[++n] = objCheckReport.m_strAcceptDate;
            objs[++n] = objCheckReport;
            gv.Rows.Add(objs);
        }

        //###################################################
        //#######################################################

        private void m_mthShowAppInfo(clsLisApplMainVO p_objApp)
        {
            this.m_txtCheckNO.Text = p_objApp.m_strApplication_Form_NO;
            this.m_txtInhospNO.Text = p_objApp.m_strPatient_inhospitalno_chr;
            this.m_txtPatientName.Text = p_objApp.m_strPatient_Name;
            this.m_cboSex.Text = p_objApp.m_strSex;
            this.m_txtAge.Text = clsAgeConverter.m_strGetAgeNum(p_objApp.m_strAge);
            this.m_cboAgeUnit.Text = clsAgeConverter.m_strGetAgeUnit(p_objApp.m_strAge);
            this.m_txtPatientCard.Text = p_objApp.m_strPatientcardID;
            try
            {
                this.m_cboSampleType.SelectedValue = p_objApp.m_strSampleTypeID;
            }
            catch { };
            this.m_cboSampleType.Text = p_objApp.m_strSampleType;

            this.m_txtAppDept.m_StrDeptID = p_objApp.m_strAppl_DeptID;
            this.m_txtBedNO.Text = p_objApp.m_strBedNO;
            this.m_txtAppDoct.m_StrEmployeeID = p_objApp.m_strAppl_EmpID;
            try
            {
                this.m_dtpAppDate.Value = DateTime.Parse(p_objApp.m_strAppl_Dat.Trim());
            }
            catch
            {
                this.m_dtpAppDate.Value = DateTime.Parse("1900-01-01 00:00:00");
            }
            this.m_rtbDiagnose.Text = p_objApp.m_strDiagnose;
            this.m_rtbAppSummary.Text = p_objApp.m_strSummary;

            this.m_txtAppNO.Text = p_objApp.m_strAPPLICATION_ID.Substring(10, 8);

            if (p_objApp.m_strPatientType == null)
            {
                this.m_cboPatientType.SelectedItem = null;
            }
            else
            {
                try
                {
                    this.m_cboPatientType.SelectedValue = p_objApp.m_strPatientType;
                }
                catch
                {
                    this.m_cboPatientType.SelectedItem = null;
                }
            }
            if (p_objApp.m_intEmergency == 1)
            {
                this.m_chkEmergency.Checked = true;
            }
            else
            {
                this.m_chkEmergency.Checked = false;
            }
            if (p_objApp.m_intSpecial == 1)
            {
                this.m_chkSpecial.Checked = true;
            }
            else
            {
                this.m_chkSpecial.Checked = false;
            }

            //switch(p_objApp.m_intChargeState)
            //{
            //    case 0:
            //        this.m_txtChargeState.Text = "";
            //        break;
            //    case 1:
            //        this.m_txtChargeState.Text = "未收费";
            //        this.m_txtChargeState.ForeColor = System.Drawing.Color.Red;
            //        break;
            //    case 2:
            //        this.m_txtChargeState.Text = "已收费";
            //        this.m_txtChargeState.ForeColor = System.Drawing.Color.Black;
            //        break;
            //    default:
            //        this.m_txtChargeState.Text = "";
            //        break;
            //}

            if (IsPay(p_objApp.m_strAPPLICATION_ID))
            {
                this.m_txtChargeState.Text = "已收费";
                this.m_txtChargeState.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                if (p_objApp.m_strPatientType == "2")
                {
                    this.m_txtChargeState.Text = "未收费";
                    this.m_txtChargeState.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        /// <summary>
        /// 获取收费状态
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        private bool IsPay(string applicationId)
        {
            clsChargeStatusVO chargeStatusVO = null;
            clsChargeInfoStatusSmp.s_obj.m_lngFind(applicationId, out chargeStatusVO);
            if (chargeStatusVO == null)
            {
                return false;
            }

            if (chargeStatusVO.m_intChargeStatus == 1)
            {
                return true;
            }

            return false;
        }

        private void m_mthShowDeviceRelation(clsLISInfoVO p_objInfo, bool p_blnForceImportData)
        {
            if (p_objInfo == null) return;
            clsLISInfoVO objInfo = p_objInfo;
            objInfo.m_objDRVOArr = new ArrayList();

            List<clsT_LIS_DeviceRelationVO> data = null;
            clsT_LIS_DeviceRelationVO[] objDRVOArr = null;
            if (!string.IsNullOrEmpty(objInfo.m_objAppMainVO.m_strApplication_Form_NO) && objInfo.m_objAppMainVO.m_strApplication_Form_NO.StartsWith("57"))     // HJ500  
            {
                data = this.m_objController.GetHJ500DeviceResult(p_objInfo.m_objAppMainVO.m_strBarcode, objInfo.m_objSampleVO.m_intSTATUS_INT, p_blnForceImportData);
                if (data != null && data.Count > 0) objDRVOArr = data.ToArray();
            }
            else if (!string.IsNullOrEmpty(objInfo.m_objAppMainVO.m_strApplication_Form_NO) && (objInfo.m_objAppMainVO.m_strApplication_Form_NO.StartsWith("59") || objInfo.m_objAppMainVO.m_strApplication_Form_NO.EndsWith("+59")))     // Ottoman
            {
                data = this.m_objController.GetOttomanDeviceResult(p_objInfo.m_objAppMainVO.m_strBarcode, objInfo.m_objSampleVO.m_intSTATUS_INT, p_blnForceImportData);
                if (data != null && data.Count > 0) objDRVOArr = data.ToArray();

                string formNo = objInfo.m_objAppMainVO.m_strApplication_Form_NO;
                if (formNo.StartsWith("59") && formNo.IndexOf('+') > 0)
                {
                    int pos1 = formNo.IndexOf('+');
                    formNo = formNo.Substring(pos1 + 1);
                }
                if (formNo.EndsWith("+59"))
                {
                    formNo = formNo.Replace("+59", "");
                }
                if (formNo != string.Empty)
                {
                    clsT_LIS_DeviceRelationVO[] objDRVOArr2 = null;
                    if (this.m_objController.m_lngGetDeviceRelationAndData(objInfo.m_objAppMainVO.m_strAPPLICATION_ID, objInfo.m_objSampleVO.m_intSTATUS_INT, p_blnForceImportData, out objDRVOArr2) <= 0)
                    {
                        MessageBox.Show(this, c_strMessageDataErr, c_strMessageBoxTitle);
                    }
                    if (objDRVOArr2 != null && objDRVOArr2.Length > 0)
                    {
                        if (data == null) data = new List<clsT_LIS_DeviceRelationVO>();
                        data.AddRange(objDRVOArr2);
                        objDRVOArr = data.ToArray();
                    }
                }
            }
            else
            {
                long lngRes = this.m_objController.m_lngGetDeviceRelationAndData(objInfo.m_objAppMainVO.m_strAPPLICATION_ID, objInfo.m_objSampleVO.m_intSTATUS_INT, p_blnForceImportData, out objDRVOArr);
                if (lngRes <= 0)
                {
                    MessageBox.Show(this, c_strMessageDataErr, c_strMessageBoxTitle);
                }
            }
            if (objDRVOArr != null)
            {
                objInfo.m_objDRVOArr.AddRange(objDRVOArr);
            }
            this.m_dtgResultList.Refresh();

            #region 显示关联
            if (objInfo.m_objDRVOArr.Count != 0)
            {
                for (int i = 0; i < objInfo.m_objDRVOArr.Count; i++)
                {
                    clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)objInfo.m_objDRVOArr[i];
                    TabPage tab = new TabPage(this.m_cboCheckDeviceList.m_strGetDeviceName(objDRVO.m_strDEVICEID_CHR));
                    tab.Tag = objInfo.m_objDRVOArr[i];
                    this.m_tabControlSample.TabPages.Add(tab);
                }
                this.m_mthSetRelation((clsT_LIS_DeviceRelationVO)objInfo.m_objDRVOArr[0], objInfo.m_objSampleVO.m_intSTATUS_INT);
                this.m_grbRelation.Visible = true;
            }
            else
            {
                this.m_grbRelation.Visible = false;
            }
            if (objInfo.m_objSampleVO.m_intSTATUS_INT == 3 || objInfo.m_objSampleVO.m_intSTATUS_INT == 5)
            {
                this.m_btnAddDeviceSample.Enabled = true;
                if (objInfo.m_objDRVOArr.Count != 0)
                {
                    this.m_btnDeleteDeviceSample.Enabled = true;
                }
                else
                {
                    this.m_btnDeleteDeviceSample.Enabled = false;
                }
            }
            else if (objInfo.m_objSampleVO.m_intSTATUS_INT == 6 && this.GetConfirmDays() <= 7)
            {
                this.m_btnAddDeviceSample.Enabled = true;
                if (objInfo.m_objDRVOArr.Count != 0)
                {
                    this.m_btnDeleteDeviceSample.Enabled = true;
                }
                else
                {
                    this.m_btnDeleteDeviceSample.Enabled = false;
                }
            }
            else
            {
                this.m_btnAddDeviceSample.Enabled = false;
                this.m_btnDeleteDeviceSample.Enabled = false;
            }
            #endregion
        }

        #endregion

        #region 重置控件

        private void m_mthResetAll()
        {
            this.m_txtPatientCard.Enabled = false;
            m_mthResetAppInfo();
            m_mthResetResult();
            m_mthResetReportInfo();
            m_mthResetDeviceRelation();

            this.m_btnNewApp.Enabled = true;
            this.m_btnConfirmReport.Enabled = false;
            this.m_btnSaveReport.Enabled = false;
            this.m_btnPrintReport.Enabled = false;
            this.m_btnPreviewReport.Enabled = false;
            this.m_btnDelete.Enabled = false;
            m_btnCancelConfim.Enabled = false;
        }

        private void m_mthResetAppInfo()
        {
            new com.digitalwave.Utility.clsControlCleanUpUtil().m_mthCleanUp(this.m_palBaseInfoInput);
            this.m_txtCheckNO.Clear();
            this.m_txtAge.Clear();
            this.m_txtInhospNO.m_mthClear();
            this.m_txtAppDept.m_mthClear();
            this.m_txtAppDoct.m_mthClear();
            this.m_palBaseInfoInput.Enabled = false;
            this.m_txtCheckNO.Enabled = false;
            this.m_btnSelectCheck.Enabled = true;
            this.m_btnModiryApp.Enabled = false;
            this.m_btnModiryApp.Text = "修改";
            this.m_btnSaveApp.Enabled = false;
            this.m_txtPatientCard.Clear();
            this.m_txtPatientID.Clear();
            this.m_txtChargeState.Clear();
        }

        private void m_mthResetReportInfo()
        {
            this.m_txtAppNO.Clear();
            this.m_txtAuditingStatus.Clear();
            //this.m_txtAcceptDate.Clear();
            this.m_txtBarCode.Clear();
            this.m_txtReportDoct.m_mthClear();
            this.m_rtbCheckSummary.m_mthClearText();
            this.m_rtbAnnotation.m_mthClearText();
            this.m_dtpReportDate.Value = DateTime.Now;
            this.m_palReportInfo.Enabled = false;
            this.m_rtbCheckSummary.m_BlnReadOnly = true;
            this.m_rtbAnnotation.m_BlnReadOnly = true;

            m_dtpAcceptDate.Value = DateTime.Now;
            m_dtpAcceptDate.Enabled = false;
        }

        private void m_mthResetResult()
        {
            ((DataView)this.m_dtgResultList.DataSource).Table.Rows.Clear();
            this.m_lsvGraph.Items.Clear();
            this.m_imgGraphList.Images.Clear();
        }

        private void m_mthResetDeviceRelation()
        {
            this.m_tabControlSample.TabPages.Clear();
            this.m_btnModifyBind.Text = "修改";
            this.m_grbRelation.Visible = false;
        }

        #endregion

        //=============================================

        #region 模板和双划线

        private void InitializeTemplate()
        {
            m_objTemplate = new com.digitalwave.iCare.Template.Client.clsTemplateClient(this, this.LoginInfo.m_strEmpID, "0000153");
        }

        public void CreateTemplate()
        {
            m_objTemplate.m_mthCreateTemplate();
        }

        private void m_mthInitRichTextBox()
        {

            ctlRichTextBox.m_ClrDefaultViewText = Color.Black;
            ctlRichTextBox[] rtbArr = new ctlRichTextBox[] { m_rtbCheckSummary, m_rtbAnnotation };
            foreach (ctlRichTextBox objRTB in rtbArr)
            {
                objRTB.m_StrUserID = this.LoginInfo.m_strEmpID;
                objRTB.m_StrUserName = this.LoginInfo.m_strEmpName;
                objRTB.m_BlnIgnoreUserInfo = true;
                objRTB.m_BlnPartControl = true;
                //objRTB.m_BlnPartControl=false;

                objRTB.m_ClrOldPartInsertText = Color.Red;
                objRTB.m_BlnCanModifyLast = true;
                //objRTB.m_BlnCanModifyLast=true;

                //objRTB.MouseLeave += new System.EventHandler(this.m_mthHandleMouseLeaveControl);
                //objRTB.m_evtMouseEnterInsertText += new System.EventHandler(this.m_mthHandleMouseEnterInsertText);
                //objRTB.m_evtMouseEnterDeleteText += new System.EventHandler(this.m_mthHandleMouseEnterDeleteText);
                //objRTB.m_evtMouseLeaveInsertText += new System.EventHandler(this.m_txtExamineDesc_m_evtMouseLeaveText);

                objRTB.m_mthSetNewText("", "<root/>");
            }

        }

        private void m_mnuNewTemplate_Click(object sender, System.EventArgs e)
        {
            CreateTemplate();
        }

        private void m_ctmnuRichTextBox_Popup(object sender, System.EventArgs e)
        {
            bool blnIsCtlRichTextBox = false;
            if (this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
                blnIsCtlRichTextBox = true;
            else
                blnIsCtlRichTextBox = false;

            if (blnIsCtlRichTextBox)
            {
                //				this.m_mnuDoubleDelete.Visible = true;
                //				this.m_mnuNewTemplate.Visible = true;
                //				this.m_mnuSpDoubleDelete.Visible = true;
                //				this.m_mnuSpNewTemplate.Visible = true;
                if (((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).SelectedText != null
                    && ((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).SelectedText != "")
                {
                    this.m_mnuDoubleDelete.Enabled = false;//
                }
                else
                {
                    this.m_mnuDoubleDelete.Enabled = false;
                }
            }
            else
            {
                //				this.m_mnuDoubleDelete.Visible = false;
                //				this.m_mnuNewTemplate.Visible = false;
                //				this.m_mnuSpDoubleDelete.Visible = false;
                //				this.m_mnuSpNewTemplate.Visible = false;
            }


            if (System.Windows.Forms.Clipboard.GetDataObject() != null
                && System.Windows.Forms.Clipboard.GetDataObject().GetDataPresent(DataFormats.StringFormat, true))
            {
                this.m_mnuPaste.Enabled = true;
            }
            else
            {
                this.m_mnuPaste.Enabled = false;
            }

            //xing.chen add 2006/03/14
            if (this.ActiveControl is RichTextBox)
            {
                //do nothing
            }
            else
            {
                this.m_rtbCheckSummary.Focus();
            }

            if (((RichTextBox)this.ActiveControl).CanUndo)
            {
                this.m_mnuUndo.Enabled = true;

            }
            else
            {
                this.m_mnuUndo.Enabled = false;
            }
            if (((RichTextBox)this.ActiveControl).SelectedText != null
                && ((RichTextBox)this.ActiveControl).SelectedText != "")
            {
                this.m_mnuCopy.Enabled = true;
                this.m_mnuDelete.Enabled = true;
                this.m_mnuCut.Enabled = true;
            }
            else
            {
                this.m_mnuCopy.Enabled = false;
                this.m_mnuDelete.Enabled = false;
                this.m_mnuCut.Enabled = false;
            }
            #region HideItem
            foreach (MenuItem objItem in this.m_ctmnuRichTextBox.MenuItems)
            {
                objItem.Visible = true;
                if (blnIsCtlRichTextBox)
                {
                    m_mnuSpDoubleDelete.Visible = false;
                    if (objItem.Text == "双划线删除")
                    {
                        objItem.Visible = false;

                    }
                    if (objItem.Text == "上下标")
                    {
                        objItem.Visible = false;
                    }
                    if (objItem.Text == "数据复用格式")
                    {
                        objItem.Visible = false;
                    }
                }
                else
                {
                    m_mnuSpDoubleDelete.Visible = false;
                    if (objItem.Text == "双划线删除")
                    {
                        objItem.Visible = false;

                    }
                    if (objItem.Text == "上下标")
                    {
                        objItem.Visible = false;
                    }
                    if (objItem.Text == "数据复用格式")
                    {
                        objItem.Visible = false;
                    }
                    if (objItem.Text == "新增模板")
                    {
                        objItem.Visible = false;

                    }
                    if (objItem.Text == "模板")
                    {
                        objItem.Visible = false;
                    }
                }
            #endregion
            }
        }

        private void m_mnuCopy_Click(object sender, System.EventArgs e)
        {
            SendKeys.Send("^C");
        }

        private void m_mnuPaste_Click(object sender, System.EventArgs e)
        {
            SendKeys.Send("^V");
        }

        private void m_mnuDelete_Click(object sender, System.EventArgs e)
        {
            SendKeys.Send("{Delete}");
        }

        private void m_mnuCut_Click(object sender, System.EventArgs e)
        {
            SendKeys.Send("^X");
        }

        private void m_mnuUndo_Click(object sender, System.EventArgs e)
        {
            if (this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
            {
                ((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).m_mthUndo();
            }
            else if (this.ActiveControl is System.Windows.Forms.RichTextBox)
            {
                ((RichTextBox)(this.ActiveControl)).Undo();
                //				this.ActiveControl.Focus();
            }
        }

        private void m_mnuSelectAll_Click(object sender, System.EventArgs e)
        {
            if (this.ActiveControl is System.Windows.Forms.RichTextBox)
            {
                ((RichTextBox)(this.ActiveControl)).SelectAll(); ;
                //				this.ActiveControl.Focus();
            }
        }

        private void m_mnuDoubleDelete_Click(object sender, System.EventArgs e)
        {
            if (this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
            {
                ((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).m_mthSelectionDoubleStrikeThough(true);
            }
        }

        #endregion

        #region 病人查询

        private void m_txtInhospNO_evtValueChanged(object sender, clsExValueChangedEventArgs e)
        {
            if (e.m_ObjCurrValue != null)
            {
                clsPatientTextBoxValue dtrPatient = this.m_txtInhospNO.m_dtrPatient;

                if (dtrPatient.strSepcial == "1")
                {
                    this.m_chkSpecial.Checked = true;
                }
                else
                {
                    this.m_chkSpecial.Checked = false;
                }

                this.m_txtAge.Text = clsAgeConverter.m_strGetAgeNum(dtrPatient.strAge);
                this.m_cboAgeUnit.Text = clsAgeConverter.m_strGetAgeUnit(dtrPatient.strAge);
                this.m_txtBedNO.Text = dtrPatient.strPatientBedNO;
                this.m_rtbDiagnose.Text = dtrPatient.strDiagnose;
                this.m_txtPatientName.Text = dtrPatient.strPatientName;
                this.m_cboSex.Text = dtrPatient.strSex;

                if (string.IsNullOrEmpty(dtrPatient.strInpatientNo))
                {
                    this.m_cboPatientType.SelectedItem = null;
                }
                else
                {
                    try
                    {
                        if (dtrPatient.strInpatientNo.Length > 8)
                        {
                            this.m_cboPatientType.SelectedIndex = 1;
                        }
                        else
                        {
                            this.m_cboPatientType.SelectedIndex = 0;
                        }
                    }
                    catch
                    {
                        this.m_cboPatientType.SelectedItem = null;
                    }
                }
                m_txtPatientID.Text = dtrPatient.strPatientID;
                this.m_txtAppDept.m_StrDeptID = dtrPatient.strDeptID;
                this.m_txtAppDoct.m_StrEmployeeID = dtrPatient.strEmpID;
                this.m_cboSampleType.Focus();

                #region 体检接口
                // 暂时屏蔽
                if (1 != 1 && this.m_cboPatientType.Text.Trim() == "体检" && this.m_txtAppDept.Text.Trim().Contains("体检") && m_txtInhospNO.Text.Trim() != string.Empty)
                {
                    if (MessageBox.Show("是否导入体检申请项目？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsLisApplMainVO patVo = new clsLisApplMainVO();
                        patVo.m_strPatient_inhospitalno_chr = dtrPatient.strInpatientNo;
                        patVo.m_strPatientID = dtrPatient.strPatientID;
                        patVo.m_strSex = dtrPatient.strSex;
                        patVo.m_strPatient_Name = dtrPatient.strPatientName;
                        patVo.m_strAge = dtrPatient.strAge;
                        patVo.m_strPatientType = "3"; // 1 住院; 2 门诊; 3 体检
                        patVo.m_strOperator_ID = this.LoginInfo.m_strEmpID;
                        patVo.m_intPStatus_int = 2;
                        patVo.m_intEmergency = 0;
                        patVo.m_intSpecial = 0;
                        patVo.m_strAppl_DeptID = dtrPatient.strDeptID;
                        patVo.m_strAppl_EmpID = dtrPatient.strEmpID;

                        clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                        DataTable dtPe = domain.GetAppItem(dtrPatient.strInpatientNo);
                        if (dtPe == null || dtPe.Rows.Count == 0)
                        {
                            MessageBox.Show("找不到体检申请项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string info = string.Empty;
                        foreach (DataRow dr in dtPe.Rows)
                        {
                            if (dr["comb_code"] != DBNull.Value && !string.IsNullOrEmpty(dr["comb_code"].ToString()) &&
                                (dr["as_group"] == DBNull.Value || string.IsNullOrEmpty(dr["as_group"].ToString())))
                            {
                                info += "体检申请项目: " + dr["comb_name"].ToString() + " \r\n\r\n";
                            }
                        }
                        if (info != string.Empty)
                        {
                            MessageBox.Show(info + "没有对应的检验项目组合。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            List<clsLisApplMainVO> lstApp = new List<clsLisApplMainVO>();
                            if (domain.PEItf(patVo, dtPe, out lstApp))
                            {
                                this.m_dtgReportList.RowsAdded -= new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgReportList_RowsAdded);
                                foreach (clsLisApplMainVO item in lstApp)
                                {
                                    m_objReportTableNewRow(item);
                                }
                                this.m_dtgReportList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgReportList_RowsAdded);
                            }
                            else
                            {
                                MessageBox.Show("导入体检申请失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        finally
                        {
                            domain = null;
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
                #endregion
            }
        }
        #endregion

        #region 样本组查询控件定位

        private void m_lsvSampleGroupQuery_MouseEnter(object sender, System.EventArgs e)
        {
            //			Point objScreenPoint = this.m_grpQry.PointToScreen(this.m_lsvSampleGroupQuery.Location);
            //			Point objFormPoint = this.PointToClient(objScreenPoint);
            //			this.m_lsvSampleGroupQuery.Visible = false;
            //			this.m_lsvSampleGroupQuery.Parent = this;
            //			this.m_lsvSampleGroupQuery.BringToFront();
            //			this.m_lsvSampleGroupQuery.Location = objFormPoint;
            //			this.m_lsvSampleGroupQuery.Width = 132;
            //			this.m_lsvSampleGroupQuery.Height = 500;
            //			this.m_lsvSampleGroupQuery.Visible = true;
        }

        private void m_lsvSampleGroupQuery_MouseLeave(object sender, System.EventArgs e)
        {
            //			this.m_lsvSampleGroupQuery.Parent = this.m_grpQry;
            //			this.m_lsvSampleGroupQuery.BringToFront();
            //			this.m_lsvSampleGroupQuery.Location = new Point(204,44);
            //			this.m_lsvSampleGroupQuery.Width = 132;
            //			this.m_lsvSampleGroupQuery.Height = 100;
            m_lsvSampleGroupQuery.Sorting = SortOrder.None;
            foreach (ListViewItem lvt in this.m_lsvSampleGroupQuery.CheckedItems)
            {
                m_lsvSampleGroupQuery.Items.Remove(lvt);
                m_lsvSampleGroupQuery.Items.Insert(0, lvt);
            }
            if (this.m_lsvSampleGroupQuery.Items.Count > 0)
            {
                this.m_lsvSampleGroupQuery.Items[0].EnsureVisible();
            }
        }


        #endregion

        #region valueTemplate

        private void m_frmValue_evtValueReturn(object sender, clsValueReturnArgs e)
        {
            if (this.m_dtrCurValueTemplateRow != null)
            {
                this.m_dtrCurValueTemplateRow["result_vchr"] = e.StrValue;
                this.m_dtgResultList.Focus();
                this.m_dtgResultList.BeginEdit(this.m_objColumnResult, this.m_intRowIndex);
                this.m_objColumnResult.TextBox.SelectionStart = this.m_objColumnResult.TextBox.Text.Length;
                this.m_objColumnResult.TextBox.SelectionLength = 0;
            }
        }

        private void frmHandInputReport_Closed(object sender, System.EventArgs e)
        {
            this.m_frmValue.m_blnIsClose = true;
            this.m_frmValue.Close();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)28 && Form.ModifierKeys == Keys.Control)
            {
                this.m_frmValue.m_mthFoucsItem();
            }
        }

        #endregion

        #region 事件实现

        private void m_txtPatientCard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void m_btnSendMessage_Click(object sender, System.EventArgs e)
        {
            frmSendMessage frm = new frmSendMessage("");
            frm.ShowDialog();
        }

        private void m_txtBarCodeQuery_Enter(object sender, System.EventArgs e)
        {
            this.m_txtBarCodeQuery.SelectAll();
        }

        private void m_txtBarCodeQuery_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.m_txtBarCodeQuery.SelectAll();
        }

        private void btnBlankOut_Click(object sender, EventArgs e)
        {
            frmBlankOut frm = new frmBlankOut();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (this.m_dtgReportList.SelectedRows.Count <= 0)
                {
                    MessageBox.Show(this, "请选择申请", "检验信息提示");
                    return;
                }
                clsLisApplMainVO objApplMainVO = (clsLisApplMainVO)this.m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;

                clsBlankOutApplicationVO objBlankOutInfo = new clsBlankOutApplicationVO();
                objBlankOutInfo.m_strBLANKOUTAPPID = objApplMainVO.m_strAPPLICATION_ID;
                objBlankOutInfo.m_strBLANKOUTSAMPLEID = objApplMainVO.m_strSampleID;
                objBlankOutInfo.m_strBLANKOUTOPRID = this.LoginInfo.m_strEmpID;
                objBlankOutInfo.m_strBLANKOUTREASON = frm.txtBlankOutReason.Text;
                objBlankOutInfo.m_strBLANKOUTDATE = frm.dtpBlankOutDate.Value.ToString();
                long lngRes = this.m_objController.m_lngBlankOutApplication(objApplMainVO, objBlankOutInfo);
                if (lngRes < 0)
                {
                    MessageBox.Show(this, "作废失败", "检验信息提示");
                    return;
                }
                else
                {
                    this.m_dtgReportList.Rows.RemoveAt(this.m_dtgReportList.SelectedRows[0].Index);
                }
            }
        }

        private void m_btnInputGroup_Click(object sender, EventArgs e)
        {
            if (this.m_objController.m_objLISInfoVO != null
                && this.m_objController.m_objLISInfoVO.m_strApplyUnitArr != null
                && this.m_btnSaveReport.Enabled == true)
            {
                frmInputGroup frm = new frmInputGroup(this.m_objController.m_objLISInfoVO.m_strApplyUnitArr);
                if (frm.ShowDialog() == DialogResult.OK && frm.strSelectedCheckItems != null)
                {
                    this.m_dtgResultList.SuspendLayout();
                    foreach (DataRow dtr in this.m_objController.m_dtbResult.Rows)
                    {
                        bool blnSelected = false;
                        foreach (string str in frm.strSelectedCheckItems)
                        {
                            if (dtr["check_item_id_chr"].ToString() == str)
                            {
                                blnSelected = true;
                                break;
                            }
                        }
                        if (blnSelected)
                        {
                            dtr["invisible"] = 0;
                        }
                        else
                        {
                            dtr["invisible"] = 1;
                            dtr["RESULT_VCHR"] = "\\";
                        }
                    }
                    this.m_dtgResultList.ResumeLayout(true);
                    this.m_dtgResultList.Refresh();
                }
            }
        }

        int addedRowIndex;
        private void m_dtgReportList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            addedRowIndex = e.RowIndex;
            this.m_dtgReportList.Rows[addedRowIndex].Selected = true;
        }

        private void m_txtPatientCheckNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_btnQuery_Click(null, EventArgs.Empty);
            }
        }

        private void m_txtInHospitalNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_btnQuery_Click(null, EventArgs.Empty);
            }
        }


        #endregion

        #region 样本组查询

        private void LoadSearchSampleGroup()
        {
            this.m_lsvSampleSearch.Items.Clear();
            this.m_lsvSampleSearch.BeginUpdate();

            foreach (clsSampleGroup_VO sampleGroupVO in this.m_objController.SampleGroups)
            {
                ListViewItem item = new ListViewItem(sampleGroupVO.strSampleGroupName);
                item.Tag = sampleGroupVO;

                m_lsvSampleSearch.Items.Add(item);
            }

            this.m_lsvSampleSearch.EndUpdate();
        }

        private void m_txtSampleSearch_TextChanged(object sender, EventArgs e)
        {

            string searchText = m_txtSampleSearch.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                m_lsvSampleSearch.Visible = false;
                return;
            }

            m_lsvSampleSearch.Visible = true;
            m_lsvSampleSearch.Items.Clear();
            m_lsvSampleSearch.BeginUpdate();

            bool isMatch = false;
            foreach (clsSampleGroup_VO sampleGroupVO in m_objController.SampleGroups)
            {
                isMatch = sampleGroupVO.strSampleGroupName.IndexOf(searchText.ToLower()) > -1 || sampleGroupVO.strSampleGroupName.IndexOf(searchText.ToUpper()) > -1
                                || sampleGroupVO.strPYCode.IndexOf(searchText.ToLower()) > -1 || sampleGroupVO.strPYCode.IndexOf(searchText.ToUpper()) > -1
                                || sampleGroupVO.strWBCode.IndexOf(searchText.ToLower()) > -1 || sampleGroupVO.strWBCode.IndexOf(searchText.ToUpper()) > -1;

                if (isMatch)
                {
                    ListViewItem item = new ListViewItem(sampleGroupVO.strSampleGroupName);
                    item.Tag = sampleGroupVO;

                    m_lsvSampleSearch.Items.Add(item);
                }
            }

            this.m_lsvSampleSearch.EndUpdate();

            if (m_lsvSampleSearch.Items.Count > 0)
            {
                m_lsvSampleSearch.Items[0].Focused = true;
                m_lsvSampleSearch.Items[0].Selected = true;
            }
        }

        private void m_txtSampleSearch_Enter(object sender, EventArgs e)
        {
            string searchText = this.m_txtSampleSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                this.m_lsvSampleSearch.Visible = false;
            }
            else
            {
                m_lsvSampleSearch.Visible = true;
                m_txtSampleSearch_TextChanged(null, EventArgs.Empty);
            }

            if (m_lsvSampleSearch.Items.Count > 0)
            {
                m_lsvSampleSearch.Items[0].Focused = true;
                m_lsvSampleSearch.Items[0].Selected = true;
            }
        }

        private void m_txtSampleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (m_lsvSampleSearch.Items.Count > 0)
                {
                    m_lsvSampleSearch.Focus();
                    m_lsvSampleSearch.Items[0].Selected = true;
                    m_lsvSampleSearch.Items[0].Focused = true;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(m_txtSampleSearch.Text.Trim()))
                {
                    return;
                }

                if (m_lsvSampleSearch.Items.Count > 0)
                {
                    clsSampleGroup_VO sampleGroup = (clsSampleGroup_VO)m_lsvSampleSearch.Items[0].Tag;

                    m_lsvSampleSearch.Visible = false;
                    m_txtSampleSearch.Text = string.Empty;

                    CheckedSampleGroupItem(sampleGroup.strSampleGroupID);

                    m_txtSampleSearch.Focus();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.m_lsvSampleSearch.Visible = false;
            }
        }

        private void m_lsvSampleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_lsvSampleSearch.SelectedItems.Count == 0)
                {
                    return;
                }

                GetSelectedItem();
            }
            if (e.KeyCode == Keys.Escape)
            {
                m_lsvSampleSearch.Visible = false;
            }
        }

        private void GetSelectedItem()
        {
            clsSampleGroup_VO sampleGroup = (clsSampleGroup_VO)m_lsvSampleSearch.SelectedItems[0].Tag;

            m_lsvSampleSearch.Visible = false;
            m_txtSampleSearch.Text = string.Empty;

            CheckedSampleGroupItem(sampleGroup.strSampleGroupID);

            m_txtSampleSearch.Focus();

            Debug.Write(sampleGroup.strSampleGroupName);
        }

        private void m_lsvSampleSearch_DoubleClick(object sender, EventArgs e)
        {

            if (m_lsvSampleSearch.SelectedItems.Count == 0)
            {
                return;
            }

            GetSelectedItem();
        }

        private void CheckedSampleGroupItem(string sampleGroupId)
        {
            foreach (ListViewItem item in m_lsvSampleGroupQuery.Items)
            {
                clsSampleGroup_VO sampleGroup = item.Tag as clsSampleGroup_VO;
                if (sampleGroup != null && sampleGroup.strSampleGroupID == sampleGroupId)
                {
                    item.Checked = true;
                    m_lsvSampleGroupQuery.Items.Remove(item);
                    m_lsvSampleGroupQuery.Items.Insert(0, item);

                    break;
                }
            }
        }

        private void m_lsvSampleGroupQuery_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            bool isAsc = false;
            ListView lsvTemp = m_lsvSampleGroupQuery;
            if (lsvTemp.Sorting == SortOrder.Ascending)
            {
                lsvTemp.Sorting = SortOrder.Descending;
            }
            else
            {
                lsvTemp.Sorting = SortOrder.Ascending;
                isAsc = true;
            }
            lsvTemp.ListViewItemSorter = new ListViewItemComparer(e.Column, isAsc, lsvTemp);
            lsvTemp.Sort();
        }

        #endregion

        #region 辅助函数

        private int GetConfirmDays()
        {
            try
            {
                DateTime timConfirm = DateTime.Parse(this.m_objController.m_objLISInfoVO.m_objReportVO.m_strCONFIRM_DAT);
                TimeSpan ts = DateTime.Now - timConfirm;
                int intDays = ts.Days;
                return intDays;
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        //=============================================

        #region 审核报告

        string applicationId = string.Empty;

        private void m_mthConfirmReport()
        {
            if (this.m_txtReportDoct.m_StrEmployeeID == null || !this.m_objController.m_BlnResultIsFull())
            {
                ShowMessage("请先确认结果完整,并选择报告人员!");
                this.m_btnConfirmReport.Enabled = true;
                return;
            }

            applicationId = string.Empty;
            if (!this.m_blnSaveReport(out applicationId))
            {
                this.m_btnConfirmReport.Enabled = true;
                return;
            }

            // 检验报告审核时如果检验者和审核者为同一个人，提示：“是否已登陆审核者”，选择“否”时，进行登陆。
            DataTable dt = (new clsDomainController_ApplicationManage()).GetApplicationOperInfo(applicationId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string comfirmId = string.IsNullOrEmpty(this.m_strSubmitDoctorId) ? this.LoginInfo.m_strEmpID : this.m_strSubmitDoctorId;
                //if (dt.Rows[0]["checker_id_chr"] != DBNull.Value && dt.Rows[0]["checker_id_chr"].ToString() == comfirmId)
                if (this.LoginInfo.m_strEmpID == comfirmId)
                {
                    if (MessageBox.Show("是否已登陆审核者?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        SubmitLogin();
                    }
                }
            }

            long lngRes = 0;
            //如果没有审核人，默认当前登录人为审核人
            if (string.IsNullOrEmpty(this.m_strSubmitDoctorId))
            {
                lngRes = this.m_objController.m_lngConfirmReport(this.LoginInfo.m_strEmpID, this.m_dtpCheckDate.Value);
            }
            else
            {
                lngRes = this.m_objController.m_lngConfirmReport(this.m_strSubmitDoctorId, this.m_dtpCheckDate.Value);
            }
            if (lngRes <= 0)
            {
                this.m_btnConfirmReport.Enabled = true;
                return;
            }
            else
            {
                // 改异步
                if (backgroundWorker.IsBusy == false)
                {
                    backgroundWorker.RunWorkerAsync();
                }
                //this.m_objController.WechatPost(applicationId);
            }

            #region 移除未绑定的仪器设备关联

            if (this.m_tabControlSample.TabPages.Count > 0)
            {
                int i = 0;
                while (i < this.m_tabControlSample.TabPages.Count)
                {
                    clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)this.m_tabControlSample.TabPages[i].Tag;
                    if (objDRVO.m_intSTATUS_INT == 1)
                    {
                        this.m_tabControlSample.TabPages.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }

                if (this.m_tabControlSample.TabPages.Count == 0)
                {
                    this.m_grbRelation.Visible = false;
                }
            }
            #endregion

            clsLisApplMainVO objTem = (clsLisApplMainVO)this.m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;
            objTem.m_intReportStatus = 2;
            objTem.m_intSampleStatus = 6;
            this.m_dtgReportList.SelectedRows[0].Cells["Status"].Value = "√";
            this.m_txtAuditingStatus.Text = "已审核";
            this.m_mthSetUI(objTem);

            // 自动打印
            if (this.m_objPreferenceStyle.m_blnAutoPrint)
            {
                this.m_objController.m_mthPrint();
            }

            //是否自动跳到下一个报告
            if (this.m_objPreferenceStyle.m_blnBatchConfirmStyle)
            {
                if (this.m_dtgReportList.SelectedRows.Count > 0)
                {
                    int intCurApp = this.m_dtgReportList.SelectedRows[0].Index;
                    if (intCurApp < this.m_dtgReportList.Rows.Count - 1)
                    {
                        this.m_dtgReportList.ClearSelection();
                        this.m_dtgReportList.CurrentCell = this.m_dtgReportList.Rows[intCurApp + 1].Cells[0];
                        this.m_dtgReportList.Rows[intCurApp + 1].Selected = true;
                        this.m_dtgReportList_SelectionChanged(null, null);
                    }
                }
            }
        }

        private bool m_blnSaveReport(out string applicationId)
        {
            applicationId = string.Empty;
            clsLisApplMainVO objLisApplVo = (clsLisApplMainVO)m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;
            applicationId = objLisApplVo.m_strAPPLICATION_ID;
            long lngRes = 0;
            DataTable dtResult = null;
            DataTable dtUnitResult = null;
            lngRes = m_objController.m_lnqQueryConfirmReport(objLisApplVo.m_strAPPLICATION_ID, out dtResult, out dtUnitResult);
            if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
            {
                if (dtResult.Rows[0]["status_int"].ToString().Trim() == "6")
                {
                    string strCommitDoctorID = null;
                    string strEmpid = null;
                    string strEmpName = null;
                    lngRes = 0;
                    DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out strEmpid, out strEmpName);
                    if (dlg == DialogResult.Yes)
                    {
                        strCommitDoctorID = strEmpid;
                    }
                    if (string.IsNullOrEmpty(strCommitDoctorID))
                        return false;
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        if (strCommitDoctorID == dtResult.Rows[0]["operator_id_chr"].ToString().Trim())
                        {
                        }
                        else
                        {
                            string strParmValue = "";
                            lngRes = m_objController.m_lngGetSysParm("6003", out strParmValue);
                            if (lngRes > 0 && !string.IsNullOrEmpty(strParmValue))
                            {
                                string[] strParmArr = strParmValue.Split(new char[] { ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                bool blnSure = false;
                                if (strParmArr != null)
                                {
                                    for (int i = 0; i < strParmArr.Length; i++)
                                    {
                                        if (strCommitDoctorID == strParmArr[i])
                                        {
                                            blnSure = true;
                                            break;
                                        }
                                    }
                                }
                                if (!blnSure)
                                {
                                    MessageBox.Show(this, "您不能修改该报告结果", "结果修改提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            clsT_OPR_LIS_APP_REPORT_VO objReport = m_mthView2ReportVO();
            lngRes = this.m_objController.m_lngSaveReport(objReport);
            if (lngRes <= 0)
            {
                MessageBox.Show(this, "保存报告失败!", c_strMessageBoxTitle);
                return false;
            }
            return true;
        }

        private clsT_OPR_LIS_APP_REPORT_VO m_mthView2ReportVO()
        {
            clsT_OPR_LIS_APP_REPORT_VO objReport = new clsT_OPR_LIS_APP_REPORT_VO();

            objReport.m_strREPORTOR_ID_CHR = this.m_txtReportDoct.m_StrEmployeeID;
            objReport.m_strSUMMARY_VCHR = this.m_rtbCheckSummary.Text;
            objReport.m_strXML_SUMMARY_VCHR = this.m_rtbCheckSummary.m_strGetXmlText();
            objReport.m_strANNOTATION_VCHR = this.m_rtbAnnotation.Text;
            objReport.m_strXML_ANNOTATION_VCHR = this.m_rtbAnnotation.m_strGetXmlText();

            objReport.m_strREPORT_DAT = this.m_dtpReportDate.Value.ToString("yyyy-MM-dd HH:mm:ss");


            objReport.m_intSTATUS_INT = this.m_objController.m_objLISInfoVO.m_objReportVO.m_intSTATUS_INT;
            objReport.m_strAPPLICATION_ID_CHR = this.m_objController.m_objLISInfoVO.m_objReportVO.m_strAPPLICATION_ID_CHR;
            objReport.m_strCONFIRM_DAT = this.m_objController.m_objLISInfoVO.m_objReportVO.m_strCONFIRM_DAT;
            objReport.m_strCONFIRMER_ID_CHR = this.m_objController.m_objLISInfoVO.m_objReportVO.m_strCONFIRMER_ID_CHR;
            objReport.m_strOPERATOR_ID_CHR = this.m_objController.m_strGetOprator();
            objReport.m_strREPORT_GROUP_ID_CHR = this.m_objController.m_objLISInfoVO.m_objReportVO.m_strREPORT_GROUP_ID_CHR;
            return objReport;
        }

        #endregion

        #region 审核者登录

        private void m_cmdLogOn_Click(object sender, EventArgs e)
        {
            SubmitLogin();
        }

        private void m_cmdLogOff_Click(object sender, EventArgs e)
        {
            this.m_strSubmitDoctorId = string.Empty;
            this.m_lblSubmitDoctor.Text = "(空)";
            SubmitLogin();
        }

        /// <summary>
        /// 审核者登录
        /// </summary>
        private void SubmitLogin()
        {
            string empid = "";

            DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out empid);
            if (dlg == DialogResult.Yes)
            {
                this.m_strSubmitDoctorId = empid;
                ctlEmpTextBox emp = new ctlEmpTextBox();
                emp.m_StrEmployeeID = m_strSubmitDoctorId;
                this.m_lblSubmitDoctor.Text = emp.m_StrEmployeeName;
            }


            //frmConfirmLogin login = frmConfirmLogin.SubmitLogin;
            //if (login.ShowDialog() == DialogResult.OK)
            //{
            //    this.m_strSubmitDoctorId = login.SubmitId;
            //    ctlEmpTextBox emp = new ctlEmpTextBox();
            //    emp.m_StrEmployeeID = m_strSubmitDoctorId;
            //    this.m_lblSubmitDoctor.Text = emp.m_StrEmployeeName;
            //}
        }
        #endregion

        #region 根据申请单设置界面控件

        private void m_mthSetUI(clsLisApplMainVO objApp)
        {
            if (objApp.m_intReportStatus == 1)
            {
                this.m_palReportInfo.Enabled = true;
                this.m_rtbCheckSummary.m_BlnReadOnly = false;
                this.m_rtbAnnotation.m_BlnReadOnly = false;

                this.m_btnNewApp.Enabled = true;
                this.m_btnConfirmReport.Enabled = true;
                this.m_btnSaveReport.Enabled = true;
                this.m_btnPrintReport.Enabled = false;
                this.m_btnPreviewReport.Enabled = false;
                this.m_btnDelete.Enabled = true;
                this.m_btnModiryApp.Enabled = true;
                m_btnCancelConfim.Enabled = false;
            }
            else if (objApp.m_intReportStatus == 2)
            {
                if (GetConfirmDays() >= clsPreferenceReportInput.c_intConfirmDays)
                {
                    this.m_palReportInfo.Enabled = false;
                    this.m_rtbCheckSummary.m_BlnReadOnly = true;
                    this.m_rtbAnnotation.m_BlnReadOnly = true;

                    this.m_btnNewApp.Enabled = true;
                    this.m_btnConfirmReport.Enabled = false;
                    this.m_btnSaveReport.Enabled = false;
                    this.m_btnPrintReport.Enabled = true;
                    this.m_btnPreviewReport.Enabled = true;
                    this.m_btnDelete.Enabled = false;
                    this.m_btnModiryApp.Enabled = false;
                    m_btnCancelConfim.Enabled = false;
                }
                else
                {
                    this.m_palReportInfo.Enabled = true;
                    this.m_rtbCheckSummary.m_BlnReadOnly = false;
                    this.m_rtbAnnotation.m_BlnReadOnly = false;

                    this.m_btnNewApp.Enabled = true;
                    this.m_btnConfirmReport.Enabled = false;
                    this.m_btnSaveReport.Enabled = true;
                    this.m_btnPrintReport.Enabled = true;
                    this.m_btnPreviewReport.Enabled = true;
                    this.m_btnDelete.Enabled = true;
                    this.m_btnModiryApp.Enabled = true;
                    m_btnCancelConfim.Enabled = true;
                }
            }
            else
            {
                this.m_palReportInfo.Enabled = false;
                this.m_rtbCheckSummary.m_BlnReadOnly = true;
                this.m_rtbAnnotation.m_BlnReadOnly = true;

                this.m_btnNewApp.Enabled = true;
                this.m_btnConfirmReport.Enabled = false;
                this.m_btnSaveReport.Enabled = false;
                this.m_btnPrintReport.Enabled = false;
                this.m_btnPreviewReport.Enabled = false;
                this.m_btnDelete.Enabled = false;
            }
            /*     if (objApp.m_intForm_int == 1)
               {
                   this.m_btnDelete.Enabled = false;
               }    */
            //xiushan.chen修改—————注释掉————————————————
        }

        #endregion

        private void m_txtPatientCardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string m_strPatientCard = "";
                m_strPatientCard = this.m_txtPatientCardNO.Text.Trim();
                if (m_strPatientCard.Equals(""))
                {
                    return;
                }
                this.m_txtPatientCardNO.Text = m_strPatientCard.PadLeft(10, '0');

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHandInputReport_Activated(object sender, EventArgs e)
        {
            if (WYH)
            {
                this.m_dtgReportList_SelectionChanged(null, null);
                WYH = false;
            }
        }

        /// <summary>
        /// 出生年月转年龄(汉字终止)
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string m_mthGetAge(string strInput)
        {
            string strAge = new clsBrithdayToAge().m_strGetAge(strInput);
            System.Text.ASCIIEncoding objAscii = new System.Text.ASCIIEncoding();
            byte[] s = objAscii.GetBytes(strAge);
            for (int i1 = 0; i1 < s.Length; i1++)
            {
                if ((int)s[i1] == 63)
                {
                    if (strAge.Substring(i1, 1) == "小")   // 年龄小于一天，单位为小时的
                    {
                        strAge = strAge.Substring(0, i1) + " " + strAge.Substring(i1, 2);
                    }
                    else
                    {
                        strAge = strAge.Substring(0, i1) + " " + strAge.Substring(i1, 1);
                    }
                    break;
                }
            }
            return strAge;
        }

        #region 作废申请单
        /// <summary>
        /// 作废申请单
        /// </summary>
        /// <param name="p_strAppID"></param>
        public void m_mthVoidReport(string p_strAppID, DataTable p_dtResult)
        {
            string strCommitDoctorID = null;
            string strEmpid = null;
            string strEmpName = null;
            long lngRes = 0;
            DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out strEmpid, out strEmpName);
            if (dlg == DialogResult.Yes)
            {
                strCommitDoctorID = strEmpid;
            }
            if (string.IsNullOrEmpty(strCommitDoctorID))
                return;
            if (p_dtResult != null && p_dtResult.Rows.Count > 0)
            {
                if (strCommitDoctorID == p_dtResult.Rows[0]["operator_id_chr"].ToString().Trim())
                {
                }
                else
                {
                    string m_strDoctorID = null;
                    //long lngRes = 0;
                    lngRes = m_objController.m_lngGetSysParm("6005", out m_strDoctorID);
                    if (lngRes > 0 && m_strDoctorID != null)
                    {
                        string[] m_strDoctorIDArr = m_strDoctorID.Split(new char[] { ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        if (m_strDoctorIDArr != null)
                        {
                            bool blnSure = false;
                            for (int i = 0; i < m_strDoctorIDArr.Length; i++)
                            {
                                if (m_strDoctorIDArr[i] == strCommitDoctorID)
                                {
                                    blnSure = true;
                                    break;
                                }
                            }
                            if (!blnSure)
                            {
                                MessageBox.Show("您不能删除该申请单", "删除申请单信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            lngRes = m_objController.m_lngUpdateVoidApply(p_strAppID, strCommitDoctorID);
            if (lngRes > 0)
            {
                MessageBox.Show("删除成功", "删除申请单信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_dtgReportList.Rows.Remove(m_dtgReportList.CurrentRow);
            }
        }
        #endregion

        private void m_txtPatientCard_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtPatientCard.Text))
            {
                m_txtPatientID.Clear();
            }
        }

        private void m_txtInhospNO_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtInhospNO.Text))
            {
                m_txtPatientID.Clear();
            }
        }

        private void m_blnCancelConfim_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定要取消审核此本报告?", "iCare-报告录入", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.m_btnCancelConfim.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                clsLisApplMainVO objLisApplVo = (clsLisApplMainVO)m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;
                long lngRes = 0;
                DataTable dtResult = null;
                DataTable dtUnitResult = null;
                lngRes = m_objController.m_lnqQueryConfirmReport(objLisApplVo.m_strAPPLICATION_ID, out dtResult, out dtUnitResult);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    if (dtResult.Rows[0]["status_int"].ToString().Trim() == "6")
                    {
                        m_mthCancelReport(objLisApplVo.m_strAPPLICATION_ID, dtResult);
                    }
                }

                this.m_btnCancelConfim.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
        }

        #region 取消审核申请单
        /// <summary>
        /// 取消审核申请单
        /// </summary>
        /// <param name="p_strAppID"></param>
        public void m_mthCancelReport(string p_strAppID, DataTable p_dtResult)
        {
            string strCommitDoctorID = null;
            string strEmpid = null;
            string strEmpName = null;
            long lngRes = 0;
            DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out strEmpid, out strEmpName);
            if (dlg == DialogResult.Yes)
            {
                strCommitDoctorID = strEmpid;
            }
            if (string.IsNullOrEmpty(strCommitDoctorID))
                return;
            if (p_dtResult != null && p_dtResult.Rows.Count > 0)
            {
                if (strCommitDoctorID == p_dtResult.Rows[0]["operator_id_chr"].ToString().Trim())
                {
                }
                else
                {
                    string m_strDoctorID = null;
                    //long lngRes = 0;
                    lngRes = m_objController.m_lngGetSysParm("6005", out m_strDoctorID);
                    if (lngRes > 0 && m_strDoctorID != null)
                    {
                        string[] m_strDoctorIDArr = m_strDoctorID.Split(new char[] { ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        if (m_strDoctorIDArr != null)
                        {
                            bool blnSure = false;
                            for (int i = 0; i < m_strDoctorIDArr.Length; i++)
                            {
                                if (m_strDoctorIDArr[i] == strCommitDoctorID)
                                {
                                    blnSure = true;
                                    break;
                                }
                            }
                            if (!blnSure)
                            {
                                MessageBox.Show("您不能取消审核该申请单", "取消审核申请单信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            lngRes = m_objController.m_lngCancelConfimReport(p_strAppID, strCommitDoctorID);
            if (lngRes > 0)
            {
                // 危急值检查
                bizCriticalValue svc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
                svc.DelCriticalValue(p_strAppID);
                svc = null;

                MessageBox.Show("取消审核成功", "取消审核申请单信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //m_dtgReportList.Rows.Remove(m_dtgReportList.CurrentRow);
                clsLisApplMainVO objTem = (clsLisApplMainVO)this.m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;
                objTem.m_intReportStatus = 1;
                objTem.m_intSampleStatus = 5;
                this.m_dtgReportList.SelectedRows[0].Cells["Status"].Value = "";
                this.m_txtAuditingStatus.Text = "未审核";
                this.m_mthSetUI(objTem);
            }
        }
        #endregion

        private void m_txtPatientCard1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtPatientCard.Text))
            {
                m_txtPatientID.Clear();
            }
        }

        private void m_txtPatientCard1_CardKeyDown(object sender, EventArgs e)
        {
            string m_strPatientCard = "";
            m_strPatientCard = this.m_txtPatientCard.Text.Trim();
            if (m_strPatientCard.Equals(""))
            {
                return;
            }
            this.m_txtPatientCard.Text = m_strPatientCard.PadLeft(10, '0');
            com.digitalwave.iCare.middletier.PatientSvc.clsPatientInfo objPatient = (com.digitalwave.iCare.middletier.PatientSvc.clsPatientInfo)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.PatientSvc.clsPatientInfo));
            clsPatient_VO objPatientVO = objPatient.GetPatientInfoByCardID(this.m_txtPatientCard.Text.Trim());
            if (objPatientVO != null)
            {
                this.m_txtPatientName.Text = objPatientVO.m_strLASTNAME_VCHR;
                this.m_cboSex.Text = objPatientVO.m_strSEX_CHR;
                try
                {
                    string strAge = m_mthGetAge(objPatientVO.m_strBIRTH_DAT);
                    //string strAge = clsAgeConverter.s_strToAge(DateTime.Parse(objPatientVO.m_strBIRTH_DAT), " 岁| 月| 天");
                    this.m_txtAge.Text = clsAgeConverter.m_strGetAgeNum(strAge);
                    this.m_cboAgeUnit.Text = clsAgeConverter.m_strGetAgeUnit(strAge);
                }
                catch { }
                this.m_txtInhospNO.Text = objPatientVO.m_strINPATIENTID_CHR;
                try
                {
                    this.m_cboPatientType.SelectedValue = 2;
                }
                catch
                {
                    this.m_cboPatientType.SelectedValue = null;
                }
                this.m_txtPatientID.Text = objPatientVO.m_strPATIENTID_CHR;
                //this.m_txtCheckNO.Focus();
            }

        }

        private void m_dtgReportList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            clsLisApplMainVO objMainVO = null;

            foreach (DataGridViewRow objDGV in m_dtgReportList.Rows)
            {
                objMainVO = (clsLisApplMainVO)objDGV.Cells["Tag"].Value;
                if (objMainVO.m_intIsGreen == 1)
                {
                    objDGV.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }

        private void btnCriHistory_Click(object sender, EventArgs e)
        {
            string pid = this.m_txtPatientID.Text.Trim();
            if (pid == string.Empty)
            {
                MessageBox.Show("请先调出病人资料。", "系统提示", MessageBoxButtons.OK);
                return;
            }
            EntityCriMonitorType criMonitorTypeVo = new EntityCriMonitorType();
            criMonitorTypeVo.empId = LoginInfo.m_strEmpID;
            criMonitorTypeVo.empNo = LoginInfo.m_strEmpNo;

            bizCriticalValue svc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
            List<EntityCriticalMain> lstMain = svc.GetCriListByPid(pid);
            svc = null;
            if (lstMain != null && lstMain.Count > 0)
            {
                frmCancelCritalVal frm = new frmCancelCritalVal(criMonitorTypeVo, lstMain);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("该病人无危急值记录。", "系统提示", MessageBoxButtons.OK);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.m_objController.WechatPost(applicationId);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.btnQuery.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            this.m_mthQuery(2);

            this.btnQuery.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void gvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvHistory.SelectedRows.Count == 0)
            {
                return;
            }

            clsLisApplMainVO objApp = (clsLisApplMainVO)gvHistory.SelectedRows[0].Cells["Tag2"].Value;
            string strAppID = objApp.m_strAPPLICATION_ID;
            string strOriginDate = objApp.m_strOriginDate;
            m_mthResetAll();

            clsLISInfoVO objInfo = null;
            long lngRes = this.m_objController.m_lngSelectReport(strAppID, strOriginDate, out objInfo);
            if (lngRes <= 0)
            {
                MessageBox.Show(this, c_strMessageDataErr, c_strMessageBoxTitle);
                return;
            }
            if (objInfo != null)
            {
                #region 取得收费信息

                if (objInfo.m_objAppMainVO.m_strPatientType != "1")
                {
                    long lngRes2 = clsDomainController_ApplicationManage.m_lngGetChargeState(objInfo.m_objAppMainVO.m_strAPPLICATION_ID);
                    switch (lngRes2)
                    {
                        case 0:
                            MessageBox.Show(this, "不能联接到收费系统，请与管理员联系！", c_strMessageBoxTitle);
                            objInfo.m_objAppMainVO.m_intChargeState = 0;
                            break;
                        case 1:
                            objInfo.m_objAppMainVO.m_intChargeState = 1;
                            break;
                        case 2:
                            objInfo.m_objAppMainVO.m_intChargeState = 2;
                            break;
                        default:
                            objInfo.m_objAppMainVO.m_intChargeState = 0;
                            break;
                    }
                }
                #endregion

                #region AppInfo
                m_mthShowAppInfo(objInfo.m_objAppMainVO);

                #endregion

                #region ReportInfo
                if ((objInfo.m_objReportVO.m_strREPORTOR_ID_CHR == null
                    || objInfo.m_objReportVO.m_strREPORTOR_ID_CHR.Trim() == "")
                    && (objInfo.m_objSampleVO.m_intSTATUS_INT == 3
                    || objInfo.m_objSampleVO.m_intSTATUS_INT == 5))
                {
                    if (this.LoginInfo == null || this.LoginInfo.m_strEmpID == null || this.LoginInfo.m_strEmpID.Trim() == "")
                    {
                        this.m_txtReportDoct.m_mthClear();
                    }
                    else
                    {
                        this.m_txtReportDoct.m_StrEmployeeID = this.LoginInfo.m_strEmpID;
                    }
                }
                else
                {
                    this.m_txtReportDoct.m_StrEmployeeID = objInfo.m_objReportVO.m_strREPORTOR_ID_CHR;
                }
                try
                {
                    this.m_dtpReportDate.Value = DateTime.Parse(objInfo.m_objReportVO.m_strREPORT_DAT);
                }
                catch { this.m_dtpReportDate.Value = DateTime.Now; }
                this.m_rtbCheckSummary.m_mthSetNewText(objInfo.m_objReportVO.m_strSUMMARY_VCHR, objInfo.m_objReportVO.m_strXML_SUMMARY_VCHR);
                this.m_rtbAnnotation.m_mthSetNewText(objInfo.m_objReportVO.m_strANNOTATION_VCHR, objInfo.m_objReportVO.m_strXML_ANNOTATION_VCHR);
                this.m_txtBarCode.Text = objInfo.m_objSampleVO.m_strBARCODE_VCHR;


                int intStatus = objInfo.m_objReportVO.m_intSTATUS_INT;

                try
                {
                    m_dtpAcceptDate.Value = DateTime.Parse(objInfo.m_objSampleVO.m_strACCEPT_DAT);
                }
                catch
                {
                    m_dtpAcceptDate.Value = DateTime.Now;
                }

                switch (intStatus)
                {
                    case 1:
                        this.m_txtAuditingStatus.Text = "未审核";
                        break;
                    case 2:
                        this.m_txtAuditingStatus.Text = "已审核";
                        break;
                    default:
                        break;
                }
                #endregion

                #region Result
                lngRes = 0;
                lngRes = this.m_objController.m_lngGetCheckItemResults(objInfo.m_objAppMainVO.m_intSampleStatus,
                    objInfo.m_objAppMainVO.m_strAPPLICATION_ID, objInfo.m_objAppMainVO.m_strOriginDate);
                if (lngRes <= 0)
                {
                    MessageBox.Show(this, c_strMessageDataErr, c_strMessageBoxTitle);
                }
                #endregion

            }
            this.m_mthSetUI(objApp);

        }


    }

    #region clsPreferenceReportInput

    public class clsPreferenceReportInput
    {
        public bool m_blnBatchConfirmStyle;
        public bool m_blnAutoPrint;

        public static int c_intConfirmDays
        {
            get
            {
                try
                {
                    string strDay = System.Configuration.ConfigurationManager.AppSettings["ConfirmDay"];
                    int intDay = int.Parse(strDay);
                    return intDay;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }

    #endregion
}