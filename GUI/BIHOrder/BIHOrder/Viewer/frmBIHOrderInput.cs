using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using com.digitalwave.CustomFromService;//申请单用到
using com.digitalwave.GUI_Base;			//申请单用到
using com.digitalwave.iCare.BIHOrder.Control;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.gui.HIS;	//申请单用到
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;
using iCare;
using iCare.CustomForm;					//申请单用到
using iCareData;						//申请单用到
using iCare.Anaesthesia.Requisition;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 医嘱录入表示层
    /// </summary>
    public class frmBIHOrderInput : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 窗口变量
        frmListDoctor fl = new frmListDoctor();
        frmOrderTemplate fo = new frmOrderTemplate();
        //		int intParentRow=-1;
        string CurrentPatientInhospitalNo;
        /// <summary>
        /// 医生所在工作组ID
        /// </summary>
        public string m_strDOCTORGROUPID_CHR = "";
        /// <summary>
        /// 是否医保病人
        /// </summary>
        public bool m_blnISMedicareMan = false;
        /// <summary>
        /// //0-普通情况，1－来源于床位调用
        /// </summary>
        public int m_intInvoSrc = 0;

        //长嘱/临嘱界面开关
        /// <summary>
        /// 长嘱/临嘱界面 开关 -1-特殊科室开的医嘱, 0-长/临,1-长,2-临,3-由电子病历打开
        /// </summary>
        public string m_strView = "0";
        /// <summary>
        /// 医嘱源类型(0-普通录入,1-特别科室录入)
        /// </summary>
        public int m_intSOURCETYPE_INT = 0;
        #region 开关
        /// <summary>
        /// 片剂计算的公式开关(0-领量＝用量* 频率*天数/包装量)，1－领量＝用量/包装量*频率*天数))
        /// </summary>
        public int m_intTypePControl = 0;
        /// <summary>
        /// 是否片剂
        /// </summary>
        public bool m_blTypeP = false;
        /// <summary>
        /// 医嘱输入作废控制开关
        /// </summary>
        public bool m_blBlankOutControl = false;
        /// <summary>
        /// 缺药显示控制开关
        /// </summary>
        public bool m_blLessMedControl = false;
        /// <summary>
        /// 医生签名控制开关
        /// </summary>
        public bool m_blDoctorSign = false;
        /// <summary>
        /// 医生自动签名
        /// </summary>
        public int m_intDoctorAutoSign = 0;
        /// <summary>
        ///跳过医嘱转抄这个流程，0false－不跳过，1true－跳过
        /// </summary>
        public bool m_blZCaoControl = false;
        /// <summary>
        ///跳过医嘱提交时是否审核提示
        /// </summary>
        public bool m_blCommitControl = false;
        /// <summary>
        /// 跳过医嘱提交时是否审核提示（1032参数） ---- 按佛二的要求 值为2 弹出不能修改工号的提交确认窗口
        /// </summary>
        public int m_intCommitControl2 = -1;
        /// <summary>
        /// 医嘱录入权限费用上限开关1003 0-关，1-开
        /// </summary>
        public bool m_blUpControl = false;
        /// <summary>
        /// 医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037
        /// </summary>
        public bool m_blStopControl = false;
        /// <summary>
        /// 医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036
        /// </summary>
        public bool m_blDeableMedControl = false;
        /// <summary>
        /// 是否显示药典备注窗口 '0059' 
        /// </summary>
        public bool IsShowCodexRemarkFrm = false;
        /// <summary>
        /// 是否允许其它医生修改非本人开的转抄前的医嘱', '0-不可以；1-可以'
        /// </summary>
        public bool m_blCanChangeOrder = false;
        /// <summary>
        /// 查看当前操作是否有处方权
        /// </summary>
        bool m_blAccess = false;
        /// <summary>
        ///医生停医嘱时是否审核提示
        /// </summary>
        public bool m_blStopTipControl = false;
        /// <summary>
        /// 医生工作站药典备注窗口显示时间 单位：妙 '0060'
        /// </summary>
        public int ShowCodexRemarkFrmTimerinterval = 1;
        /// <summary>
        /// 提交时是否对检验的项目进行申请单发送(true-可以,false-不可以)
        /// </summary>
        public bool m_blSendLisBill = false;
        /// <summary>
        /// 医生修改下嘱时间的时间限制 0-不限制,>0为限制的时间,如24,即为下嘱后24小时内可以修改  1054
        /// </summary>
        public int m_intStartTimeSwitth = 0;
        /// <summary>
        /// 医生修改停嘱时间的时间限制 0-不限制,>0为限制的时间,如24,即为下嘱后24小时内可以修改  1051
        /// </summary>
        public int m_intStopTimeSwitth = 0;
        /// <summary>
        /// 4006设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能
        /// </summary>
        public int m_intLisDiscountNum = 0;
        /// <summary>
        /// 4007设置启用打折功能时，检验收费项目的打折比例。80，则打八折
        /// </summary>
        public decimal m_decLisDiscountMount = 0;
        /// <summary>
        /// 4008  0-false不打折 1-true 允许打折
        /// </summary>
        public bool m_blLisDiscount = false;
        /// <summary>
        ///'1053', '住院医嘱录入界面是否自动提示当前病人存在停用或缺药的未停医嘱', '0-否；1-是', 1, '0010' 
        /// </summary>
        public bool m_blAutoStopAlert = false;
        /// <summary>
        /// 病人门诊未结处方费用时控制出院结算与医嘱录入(医嘱录入1、2状态都为提示选择)0-关闭;1-提示选择，2-卡住
        /// </summary>
        internal int m_intParm1068 = 0;
        /// <summary>
        /// 系统参数表(ICARE公用) 0013 检验组合打折发票类型 多种类型以身份隔开
        /// </summary>
        public string m_strLisPARMVALUE_VCHR = "";
        /// <summary>
        /// 住院中心药房ID(0009)参数
        /// </summary>
        public string m_strMedDeptId = "";
        /// <summary>
        /// 住院药品库存判断药房设置
        /// </summary>
        public string m_strMedDeptGross = "";
        #endregion
        /// <summary>
        /// 是否响应datagridview 的cellchanged 事件
        /// </summary>
        public bool m_blnCurrentCellChanged = false;

        /// <summary>
        ///  当前操作状态(0-新增普通医嘱,1-新增子医嘱,2-修改普通医嘱,3-修改子医嘱,4-,5-,6-,7-)
        /// </summary>
        public int m_intOperateStatus = 0;
        /// <summary>
        /// 医嘱类型列表
        /// </summary>
        public Hashtable m_htOrderCate = new Hashtable();
        /// <summary>
        /// 住院基本配置表VO
        /// </summary>
        public clsSPECORDERCATE m_objSpecateVo;

        public Color selectOldColor;


        /// <summary>
        ///开始时间点击次数
        /// </summary>
        public int m_intStarClickCout = 1;
        /// <summary>
        ///结束时间点击次数
        /// </summary>
        public int m_intFinishClickCout = 1;

        /// <summary>
        /// 药品库存量
        /// </summary>
        public float m_fotOpcurrentgross_num = 0;
        /// <summary>
        /// 是否是药品
        /// </summary>
        public int m_intITEMSRCTYPE_INT = 0;
        /// <summary>
        /// 是否是修改嘱  false为新增  true为修改医嘱
        /// </summary>
        public bool m_blIsChange = false;
        /// <summary>
        /// 住院西药房ID
        /// </summary>
        public string m_strMedCineStorgeId = "";
        /// <summary>
        /// 中药房ID
        /// </summary>
        public string m_strMidMedCineSorgeId = "";
        /// <summary>
        /// 住院医保病人身份ID
        /// 0008参数内容控制
        /// </summary>
        public List<string> m_lstSocialSecurity = new List<string>();
        #endregion

        #region 控件变量申明
        private PinkieControls.ButtonXP m_cmdAdd;
        internal PinkieControls.ButtonXP m_cmdSave;
        internal PinkieControls.ButtonXP m_cmdCommitAll;
        internal PinkieControls.ButtonXP m_cmdStop;
        internal PinkieControls.ButtonXP m_cmdRetract;
        private System.Windows.Forms.ContextMenu m_ctxGridMenu;
        private System.Windows.Forms.MenuItem m_mnuStop;
        private System.Windows.Forms.MenuItem m_mnuRetract;
        private System.Windows.Forms.MenuItem m_mnuCommitAll;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.RadioButton m_rdoAllDay;
        private System.Windows.Forms.RadioButton m_rdoToday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public RadioButton m_rdoTempType;
        public RadioButton m_rdoLongType;
        public RadioButton m_rdoAllType;
        public Panel m_plControls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private PinkieControls.ButtonXP m_cmdClose;
        private System.Windows.Forms.CheckBox m_chkStatus0;
        private System.Windows.Forms.CheckBox m_chkStatus1;
        private System.ComponentModel.IContainer components;
        //internal clsBIHOrderService m_objService;
        internal ArrayList m_arlOrder;
        internal com.digitalwave.iCare.BIHOrder.Control.ctlBIHPatientInfo m_ctlPatient;
        /// <summary>
        /// 当前医生
        /// </summary>
        internal clsBIHDoctor m_objCurrentDoctor = null;
        internal PinkieControls.ButtonXP m_cmdToCommit;
        public System.Windows.Forms.LinkLabel m_lblOtherBill;
        public System.Windows.Forms.ContextMenu m_ctxOtherBill;

        private com.digitalwave.iCare.BIHOrder.Control.clsTextFocusHighlight m_objHighlight = null;
        internal com.digitalwave.iCare.BIHOrder.Control.ctlBIHOrderDetail m_ctlOrderDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox m_chkStatus2;
        private System.Windows.Forms.CheckBox m_chkStatus3;
        private System.Windows.Forms.CheckBox m_chkNeedFeel;
        internal PinkieControls.ButtonXP m_cmdBlankOut;
        private System.Windows.Forms.MenuItem m_mnuBlankOut;
        internal PinkieControls.ButtonXP m_cmdDelete;
        private System.Windows.Forms.MenuItem m_mnuDelete;
        private PinkieControls.ButtonXP cmdRefurbish;
        private PinkieControls.ButtonXP cmdPrintOrder;
        internal System.Windows.Forms.ComboBox m_cobOrderCate;
        internal System.Windows.Forms.ToolTip toolTip1;
        public clsBIHOrderInputDomain m_objDomain;
        /// <summary>
        /// 是否显示ToolTip
        /// </summary>
        private static bool m_IsDisPlayToolTip = false;
        internal System.Windows.Forms.Label m_lblEditState;
        internal System.Windows.Forms.ListView m_lsvToolTip;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        /// <summary>
        /// ToolTip显示的文本内容
        /// </summary>
        //string m_strToolTip ="";
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.MenuItem m_mnuCopy;
        private System.Windows.Forms.Panel pnTabs;
        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.Panel pnSel;
        internal PinkieControls.ButtonXP m_cmdSub;
        internal PinkieControls.ButtonXP btCreatBill;
        internal System.Windows.Forms.ComboBox cmbApply;
        private System.Windows.Forms.Label label14;
        internal PinkieControls.ButtonXP m_btnAddBills;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        internal System.Windows.Forms.TextBox m_lblOrderStatus;
        internal System.Windows.Forms.TextBox m_txtBackReason;
        private System.Windows.Forms.MenuItem menuItem2;
        internal com.digitalwave.controls.AlertLight alertLight1;
        private System.Windows.Forms.Label lbePriceInfo;
        internal System.Windows.Forms.ToolTip toolTip2;
        private CheckBox m_chkStatus4;
        public ComboBox seachClass;
        private Label label16;
        /// <summary>
        /// 是否是窗体第一次LOAD入来标志，为了控制不执行当前行选中事件　
        /// </summary>

        private com.digitalwave.Utility.Controls.CollapsibleSplitter collapsibleSplitter1;
        public DataGridView m_dtvOrder;
        private Label label1;
        private MenuItem menuItem3;
        private ContextMenuStrip m_ctxGridMenu2;
        private ToolStripMenuItem m_mnuDelete2;
        private ToolStripMenuItem m_mnuBlankOut2;
        private ToolStripMenuItem m_mnuStop2;
        private ToolStripMenuItem m_mnuRetract2;
        private ToolStripMenuItem m_mnuCommitAll2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem m_mnuCopy2;
        private ToolStripMenuItem m_mnuCopyBihorder2;
        internal PinkieControls.ButtonXP m_cmdChgView;
        private Label label2;
        private Label label17;
        private GroupBox groupBox4;
        public RadioButton radioButton1;
        private Label label4;
        internal PictureBox pictureBox6;
        internal PictureBox pictureBox3;
        private PinkieControls.ButtonXP m_cmdChange;
        private Label label10;
        public com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox m_txtCREATEAREA;
        private ToolStripMenuItem TSMenuTurnBack;
        internal PinkieControls.ButtonXP m_cmdDelete2;
        private ToolStripMenuItem m_mnuDoctorSign;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private ToolStripMenuItem menuItem7;
        private ToolStripMenuItem menuItem8;
        internal ToolStripMenuItem menuItemStopAll;
        internal ToolStripMenuItem m_MenuCopy;
        internal ToolStripMenuItem m_MenuPase;
        internal ToolStripMenuItem m_MenuATTACHTIMES_INT;
        internal ToolStripMenuItem m_MenuOPERATION;
        internal ToolStripMenuItem m_MenuOrderTemp;
        internal ToolStripMenuItem m_MenuOrderNornal;
        internal ToolStripMenuItem m_MenuChangeArea;
        internal ToolStripMenuItem m_MenuReSortOrderNO;
        internal ToolStripMenuItem m_MenuOrderSTsign;
        protected ToolStripMenuItem m_MenuCheckBill;
        private ToolStripMenuItem m_MenuCheckBillEdit;
        private ToolStripMenuItem m_MenuCheckBillView;
        internal ToolStripMenuItem m_MenuViewBackReasion;
        internal PictureBox m_imgBackAlert;
        public ComboBox m_cboOrderList;
        internal ToolStripMenuItem m_MenuOutHis;
        internal ToolStripMenuItem m_MenuOutTomorrow;
        internal ToolStripMenuItem m_MenuOutToday;
        internal ToolStripMenuItem m_MenuCHNAGEAMOUNT_INT;
        internal ToolStripMenuItem m_MenuMoneyCount;
        private ToolStripMenuItem m_MenuSeeBill;
        private ToolStripMenuItem m_MenuSurgery;
        internal PictureBox m_pcBoxAlert;
        private ToolStripMenuItem tsmiDrugInfo;
        private ToolStripMenuItem tsbOpApplyNew;
        internal ComboBox cboPrintType;
        private ToolStripMenuItem tsmiTskjyhz_response;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem tsmiTskjyhz_apply;
        private ToolStripMenuItem tsmiTskjyhz_check;
        private Label label5;
        private DataGridViewTextBoxColumn dtv_ExecuteType;
        private DataGridViewTextBoxColumn m_dtPOSTDATE_DAT;
        private DataGridViewTextBoxColumn CREATOR_CHR;
        private DataGridViewTextBoxColumn ASSESSORFOREXEC_CHR;
        private DataGridViewTextBoxColumn dtv_RecipeNo;
        private DataGridViewTextBoxColumn dtv_Name;
        private DataGridViewTextBoxColumn dtv_Dosage;
        private DataGridViewTextBoxColumn dtv_UseType;
        private DataGridViewTextBoxColumn dtv_Freq;
        private DataGridViewTextBoxColumn dtv_REMARK;
        private DataGridViewTextBoxColumn dtv_FinishDate;
        private DataGridViewTextBoxColumn dtv_Stoper;
        private DataGridViewTextBoxColumn ASSESSORFORSTOP_CHR;
        private DataGridViewTextBoxColumn ATTACHTIMES_INT;
        private DataGridViewTextBoxColumn STATUS_INT;
        private DataGridViewTextBoxColumn RATETYPE_INT;
        private DataGridViewTextBoxColumn isOps;
        private DataGridViewTextBoxColumn MedicareTypeName;
        private DataGridViewTextBoxColumn dtv_Get;
        private DataGridViewTextBoxColumn dtv_Sum;
        private DataGridViewTextBoxColumn dtv_StartDate;
        private DataGridViewTextBoxColumn dtv_Executor;
        private DataGridViewTextBoxColumn dtv_DELETE_DAT;
        private DataGridViewTextBoxColumn dtv_DELETERNAME_VCHR;
        private DataGridViewTextBoxColumn viewname_vchr;
        private DataGridViewTextBoxColumn dtv_method;
        private DataGridViewTextBoxColumn dtv_NO;
        private DataGridViewTextBoxColumn dtv_OUTGETMEDDAYS_INT;
        private DataGridViewTextBoxColumn dtv_CREATEAREA_Name;
        private DataGridViewTextBoxColumn dtv_DOCTOR_VCHR;
        private DataGridViewImageColumn dtv_DOCTOR_SIGN;
        private DataGridViewTextBoxColumn CREATEDATE_DAT;
        private DataGridViewTextBoxColumn dtv_ChangedID;
        private DataGridViewTextBoxColumn dtv_ChangedDate;
        private DataGridViewTextBoxColumn m_dtStartDate;
        private DataGridViewTextBoxColumn m_dtvSENDBACKER_CHR;
        /// <summary>
        /// 显示ToopTip的位置
        /// </summary>
        System.Drawing.Point m_poToolTip = new Point(0, 0);
        #endregion
        #region 构造函数
        public frmBIHOrderInput()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            m_arlOrder = new ArrayList();

            m_objHighlight = new com.digitalwave.iCare.BIHOrder.Control.clsTextFocusHighlight();

            m_objDomain = new clsBIHOrderInputDomain(this);

            this.objController = new clsController_Base();

            //m_objService=m_objDomain.m_objService;
        }
        /// <summary>
        /// 构造函数m_intSrc   0-普通情况，1－来源于床位调用
        /// </summary>
        /// <param name="m_intSrc"></param>
        public frmBIHOrderInput(int m_intSrc)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            m_arlOrder = new ArrayList();

            m_objHighlight = new com.digitalwave.iCare.BIHOrder.Control.clsTextFocusHighlight();

            m_objDomain = new clsBIHOrderInputDomain(this);

            this.objController = new clsController_Base();
            m_intInvoSrc = m_intSrc;
            //m_objService=m_objDomain.m_objService;
        }
        /// <summary>
        /// 清理所有正在使用的资源。
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

        #endregion
        #region 设置医生、病区、病人
        /// <summary>
        /// 设置当前医生
        /// </summary>
        /// <param name="strDoctorID"></param>
        /// <param name="strDoctorName"></param>
        public void m_mthSetCurrentDoctor(string strDoctorID, string strDoctorName)
        {
            m_objCurrentDoctor = new clsBIHDoctor();
            m_objCurrentDoctor.m_strDoctorID = strDoctorID;
            m_objCurrentDoctor.m_strDoctorName = strDoctorName;
            m_ctlOrderDetail.m_mthSetDoctor(m_objCurrentDoctor.m_strDoctorID, m_objCurrentDoctor.m_strDoctorName);
        }

        /// <summary>
        /// 设置当前病区
        /// </summary>
        /// <param name="strAreaID"></param>
        public void m_mthSetCurrentArea(string strAreaID)
        {
            m_ctlPatient.m_mthSetArea(strAreaID);
        }

        /// <summary>
        /// 设置当前病人
        /// </summary>
        /// <param name="strInHospitalNo"></param>
        public void m_mthSetCurrentPatient(string strInHospitalNo)
        {
            m_ctlPatient.m_mthSetPatient(strInHospitalNo);
            this.CurrentPatientInhospitalNo = strInHospitalNo;
        }
        #endregion
        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBIHOrderInput));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_ctxGridMenu = new System.Windows.Forms.ContextMenu();
            this.m_mnuDelete = new System.Windows.Forms.MenuItem();
            this.m_mnuBlankOut = new System.Windows.Forms.MenuItem();
            this.m_mnuStop = new System.Windows.Forms.MenuItem();
            this.m_mnuRetract = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.m_mnuCommitAll = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.m_mnuCopy = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.m_ctxOtherBill = new System.Windows.Forms.ContextMenu();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdPrintOrder = new PinkieControls.ButtonXP();
            this.m_cmdStop = new PinkieControls.ButtonXP();
            this.m_lblOrderStatus = new System.Windows.Forms.TextBox();
            this.m_chkStatus3 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus4 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus2 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus1 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus0 = new System.Windows.Forms.CheckBox();
            this.m_imgBackAlert = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.m_ctxGridMenu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mnuDelete2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuBlankOut2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuStop2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuRetract2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_mnuCommitAll2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_mnuCopy2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuPase = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuCopyBihorder2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuSeeBill = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuTurnBack = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuDoctorSign = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuChangeArea = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuOPERATION = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuATTACHTIMES_INT = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuCHNAGEAMOUNT_INT = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuOrderTemp = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuOrderNornal = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuReSortOrderNO = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuOrderSTsign = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuCheckBill = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuCheckBillEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuCheckBillView = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuViewBackReasion = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuOutHis = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuOutToday = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuOutTomorrow = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuMoneyCount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOpApplyNew = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuSurgery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDrugInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTskjyhz_apply = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTskjyhz_check = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTskjyhz_response = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.collapsibleSplitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboOrderList = new System.Windows.Forms.ComboBox();
            this.m_lblEditState = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_cobOrderCate = new System.Windows.Forms.ComboBox();
            this.seachClass = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdoToday = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.m_rdoAllDay = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.alertLight1 = new com.digitalwave.controls.AlertLight();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_rdoTempType = new System.Windows.Forms.RadioButton();
            this.m_rdoLongType = new System.Windows.Forms.RadioButton();
            this.m_rdoAllType = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chkNeedFeel = new System.Windows.Forms.CheckBox();
            this.cmbApply = new System.Windows.Forms.ComboBox();
            this.m_txtBackReason = new System.Windows.Forms.TextBox();
            this.btCreatBill = new PinkieControls.ButtonXP();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_dtvOrder = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnSel = new System.Windows.Forms.Panel();
            this.pnTabs = new System.Windows.Forms.Panel();
            this.lbePriceInfo = new System.Windows.Forms.Label();
            this.lblBoard = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboPrintType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_plControls = new System.Windows.Forms.Panel();
            this.m_cmdDelete2 = new PinkieControls.ButtonXP();
            this.m_cmdChange = new PinkieControls.ButtonXP();
            this.m_cmdToCommit = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdAdd = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdRetract = new PinkieControls.ButtonXP();
            this.m_cmdBlankOut = new PinkieControls.ButtonXP();
            this.cmdRefurbish = new PinkieControls.ButtonXP();
            this.m_cmdSub = new PinkieControls.ButtonXP();
            this.m_cmdCommitAll = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdChgView = new PinkieControls.ButtonXP();
            this.label14 = new System.Windows.Forms.Label();
            this.m_btnAddBills = new PinkieControls.ButtonXP();
            this.m_lsvToolTip = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.label13 = new System.Windows.Forms.Label();
            this.m_lblOtherBill = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.m_pcBoxAlert = new System.Windows.Forms.PictureBox();
            this.m_ctlOrderDetail = new com.digitalwave.iCare.BIHOrder.Control.ctlBIHOrderDetail();
            this.m_txtCREATEAREA = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_ctlPatient = new com.digitalwave.iCare.BIHOrder.Control.ctlBIHPatientInfo();
            this.dtv_ExecuteType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtPOSTDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATOR_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASSESSORFOREXEC_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_RecipeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_UseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_FinishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Stoper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASSESSORFORSTOP_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATTACHTIMES_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RATETYPE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isOps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicareTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Get = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Executor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_DELETE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_DELETERNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_OUTGETMEDDAYS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_CREATEAREA_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_DOCTOR_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_DOCTOR_SIGN = new System.Windows.Forms.DataGridViewImageColumn();
            this.CREATEDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_ChangedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_ChangedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvSENDBACKER_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgBackAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.m_ctxGridMenu2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrder)).BeginInit();
            this.panel5.SuspendLayout();
            this.pnTabs.SuspendLayout();
            this.panel3.SuspendLayout();
            this.m_plControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pcBoxAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ctxGridMenu
            // 
            this.m_ctxGridMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mnuDelete,
            this.m_mnuBlankOut,
            this.m_mnuStop,
            this.m_mnuRetract,
            this.menuItem1,
            this.m_mnuCommitAll,
            this.menuItem2,
            this.m_mnuCopy,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5});
            this.m_ctxGridMenu.Popup += new System.EventHandler(this.m_ctxGridMenu_Popup);
            // 
            // m_mnuDelete
            // 
            this.m_mnuDelete.Index = 0;
            this.m_mnuDelete.Text = "删除";
            this.m_mnuDelete.Click += new System.EventHandler(this.m_mnuDelete_Click);
            // 
            // m_mnuBlankOut
            // 
            this.m_mnuBlankOut.Index = 1;
            this.m_mnuBlankOut.Text = "作废";
            this.m_mnuBlankOut.Click += new System.EventHandler(this.m_mnuBlankOut_Click);
            // 
            // m_mnuStop
            // 
            this.m_mnuStop.Index = 2;
            this.m_mnuStop.Text = "停止";
            this.m_mnuStop.Click += new System.EventHandler(this.m_mnuStop_Click);
            // 
            // m_mnuRetract
            // 
            this.m_mnuRetract.Index = 3;
            this.m_mnuRetract.Text = "重整";
            this.m_mnuRetract.Click += new System.EventHandler(this.m_mnuRetract_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
            // 
            // m_mnuCommitAll
            // 
            this.m_mnuCommitAll.Index = 5;
            this.m_mnuCommitAll.Text = "提交所有新建医嘱";
            this.m_mnuCommitAll.Click += new System.EventHandler(this.m_mnuCommitAll_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 6;
            this.menuItem2.Text = "-";
            // 
            // m_mnuCopy
            // 
            this.m_mnuCopy.Index = 7;
            this.m_mnuCopy.Text = "复制到临时模板";
            this.m_mnuCopy.Click += new System.EventHandler(this.m_mnuCopy_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 8;
            this.menuItem3.Text = "复制医嘱";
            this.menuItem3.Click += new System.EventHandler(this.m_mnuCopyBihOrder_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 9;
            this.menuItem4.Text = "修改下嘱时间";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 10;
            this.menuItem5.Text = "修改停嘱时间";
            // 
            // m_ctxOtherBill
            // 
            this.m_ctxOtherBill.Popup += new System.EventHandler(this.m_ctxOtherBill_Popup);
            // 
            // cmdPrintOrder
            // 
            this.cmdPrintOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdPrintOrder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmdPrintOrder.DefaultScheme = true;
            this.cmdPrintOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdPrintOrder.Font = new System.Drawing.Font("宋体", 9.5F);
            this.cmdPrintOrder.Hint = "";
            this.cmdPrintOrder.Location = new System.Drawing.Point(4, 64);
            this.cmdPrintOrder.Name = "cmdPrintOrder";
            this.cmdPrintOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdPrintOrder.Size = new System.Drawing.Size(61, 29);
            this.cmdPrintOrder.TabIndex = 47;
            this.cmdPrintOrder.Text = "打印";
            this.toolTip1.SetToolTip(this.cmdPrintOrder, "快捷键[Ctrl + P]");
            this.cmdPrintOrder.Click += new System.EventHandler(this.cmdPrintOrder_Click);
            // 
            // m_cmdStop
            // 
            this.m_cmdStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdStop.DefaultScheme = true;
            this.m_cmdStop.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdStop.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_cmdStop.Hint = "";
            this.m_cmdStop.Location = new System.Drawing.Point(125, 33);
            this.m_cmdStop.Name = "m_cmdStop";
            this.m_cmdStop.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdStop.Size = new System.Drawing.Size(61, 29);
            this.m_cmdStop.TabIndex = 45;
            this.m_cmdStop.Text = "停嘱 X";
            this.toolTip1.SetToolTip(this.m_cmdStop, "按Ctrl键在新页面操作");
            this.m_cmdStop.Click += new System.EventHandler(this.m_cmdStop_Click);
            // 
            // m_lblOrderStatus
            // 
            this.m_lblOrderStatus.BackColor = System.Drawing.Color.Wheat;
            this.m_lblOrderStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblOrderStatus.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_lblOrderStatus.Location = new System.Drawing.Point(589, 25);
            this.m_lblOrderStatus.Multiline = true;
            this.m_lblOrderStatus.Name = "m_lblOrderStatus";
            this.m_lblOrderStatus.ReadOnly = true;
            this.m_lblOrderStatus.Size = new System.Drawing.Size(191, 33);
            this.m_lblOrderStatus.TabIndex = 58;
            this.m_lblOrderStatus.TabStop = false;
            this.toolTip1.SetToolTip(this.m_lblOrderStatus, "医嘱状态");
            this.m_lblOrderStatus.Visible = false;
            // 
            // m_chkStatus3
            // 
            this.m_chkStatus3.AutoSize = true;
            this.m_chkStatus3.Checked = true;
            this.m_chkStatus3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkStatus3.Location = new System.Drawing.Point(333, 12);
            this.m_chkStatus3.Name = "m_chkStatus3";
            this.m_chkStatus3.Size = new System.Drawing.Size(68, 18);
            this.m_chkStatus3.TabIndex = 8;
            this.m_chkStatus3.Text = "已停止";
            this.toolTip1.SetToolTip(this.m_chkStatus3, "停止、审核停止状态的医嘱");
            this.m_chkStatus3.CheckedChanged += new System.EventHandler(this.m_mthShowStatusChange);
            // 
            // m_chkStatus4
            // 
            this.m_chkStatus4.Location = new System.Drawing.Point(267, 9);
            this.m_chkStatus4.Name = "m_chkStatus4";
            this.m_chkStatus4.Size = new System.Drawing.Size(68, 24);
            this.m_chkStatus4.TabIndex = 7;
            this.m_chkStatus4.Text = "已作废";
            this.toolTip1.SetToolTip(this.m_chkStatus4, "执行状态的医嘱");
            this.m_chkStatus4.CheckedChanged += new System.EventHandler(this.m_mthShowStatusChange);
            // 
            // m_chkStatus2
            // 
            this.m_chkStatus2.Checked = true;
            this.m_chkStatus2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus2.Location = new System.Drawing.Point(202, 9);
            this.m_chkStatus2.Name = "m_chkStatus2";
            this.m_chkStatus2.Size = new System.Drawing.Size(68, 25);
            this.m_chkStatus2.TabIndex = 6;
            this.m_chkStatus2.Text = "已执行";
            this.toolTip1.SetToolTip(this.m_chkStatus2, "执行状态的医嘱");
            this.m_chkStatus2.CheckedChanged += new System.EventHandler(this.m_mthShowStatusChange);
            // 
            // m_chkStatus1
            // 
            this.m_chkStatus1.Checked = true;
            this.m_chkStatus1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus1.Location = new System.Drawing.Point(136, 9);
            this.m_chkStatus1.Name = "m_chkStatus1";
            this.m_chkStatus1.Size = new System.Drawing.Size(68, 24);
            this.m_chkStatus1.TabIndex = 5;
            this.m_chkStatus1.Text = "已提交";
            this.toolTip1.SetToolTip(this.m_chkStatus1, "提交、审核提交状态的医嘱");
            this.m_chkStatus1.CheckedChanged += new System.EventHandler(this.m_mthShowStatusChange);
            // 
            // m_chkStatus0
            // 
            this.m_chkStatus0.Checked = true;
            this.m_chkStatus0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus0.Location = new System.Drawing.Point(70, 10);
            this.m_chkStatus0.Name = "m_chkStatus0";
            this.m_chkStatus0.Size = new System.Drawing.Size(78, 23);
            this.m_chkStatus0.TabIndex = 4;
            this.m_chkStatus0.Text = "未提交";
            this.toolTip1.SetToolTip(this.m_chkStatus0, "新建、退回状态的医嘱");
            this.m_chkStatus0.CheckedChanged += new System.EventHandler(this.m_mthShowStatusChange);
            // 
            // m_imgBackAlert
            // 
            this.m_imgBackAlert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imgBackAlert.Image = ((System.Drawing.Image)(resources.GetObject("m_imgBackAlert.Image")));
            this.m_imgBackAlert.Location = new System.Drawing.Point(212, 6);
            this.m_imgBackAlert.Name = "m_imgBackAlert";
            this.m_imgBackAlert.Size = new System.Drawing.Size(17, 20);
            this.m_imgBackAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_imgBackAlert.TabIndex = 121;
            this.m_imgBackAlert.TabStop = false;
            this.toolTip1.SetToolTip(this.m_imgBackAlert, "有退回的医嘱!");
            this.m_imgBackAlert.Visible = false;
            this.m_imgBackAlert.Click += new System.EventHandler(this.m_imgBackAlert_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(977, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 24);
            this.pictureBox6.TabIndex = 117;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, "有新医嘱 请注意刷新 ！！");
            this.pictureBox6.Visible = false;
            this.pictureBox6.DoubleClick += new System.EventHandler(this.pictureBox6_DoubleClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(958, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 24);
            this.pictureBox3.TabIndex = 116;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "有新医嘱 请注意刷新 ！！");
            this.pictureBox3.Visible = false;
            this.pictureBox3.DoubleClick += new System.EventHandler(this.pictureBox3_DoubleClick);
            // 
            // m_ctxGridMenu2
            // 
            this.m_ctxGridMenu2.BackColor = System.Drawing.Color.White;
            this.m_ctxGridMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuDelete2,
            this.m_mnuBlankOut2,
            this.m_mnuStop2,
            this.m_mnuRetract2,
            this.toolStripSeparator1,
            this.m_mnuCommitAll2,
            this.toolStripSeparator2,
            this.m_mnuCopy2,
            this.m_MenuCopy,
            this.m_MenuPase,
            this.m_mnuCopyBihorder2,
            this.m_MenuSeeBill,
            this.TSMenuTurnBack,
            this.m_mnuDoctorSign,
            this.menuItem7,
            this.menuItem8,
            this.menuItemStopAll,
            this.m_MenuChangeArea,
            this.m_MenuOPERATION,
            this.m_MenuATTACHTIMES_INT,
            this.m_MenuCHNAGEAMOUNT_INT,
            this.m_MenuOrderTemp,
            this.m_MenuOrderNornal,
            this.m_MenuReSortOrderNO,
            this.m_MenuOrderSTsign,
            this.m_MenuCheckBill,
            this.m_MenuViewBackReasion,
            this.m_MenuOutHis,
            this.m_MenuMoneyCount,
            this.tsbOpApplyNew,
            this.m_MenuSurgery,
            this.tsmiDrugInfo,
            this.toolStripSeparator4,
            this.tsmiTskjyhz_apply,
            this.tsmiTskjyhz_check,
            this.tsmiTskjyhz_response});
            this.m_ctxGridMenu2.Name = "m_ctxGridMenu2";
            this.m_ctxGridMenu2.Size = new System.Drawing.Size(222, 748);
            this.m_ctxGridMenu2.Opening += new System.ComponentModel.CancelEventHandler(this.m_ctxGridMenu2_Opening);
            // 
            // m_mnuDelete2
            // 
            this.m_mnuDelete2.Image = global::Order.Properties.Resources.delete;
            this.m_mnuDelete2.Name = "m_mnuDelete2";
            this.m_mnuDelete2.ShortcutKeyDisplayString = "F6";
            this.m_mnuDelete2.Size = new System.Drawing.Size(221, 22);
            this.m_mnuDelete2.Text = "删除";
            this.m_mnuDelete2.Click += new System.EventHandler(this.m_mnuDelete_Click);
            // 
            // m_mnuBlankOut2
            // 
            this.m_mnuBlankOut2.Image = global::Order.Properties.Resources.warning;
            this.m_mnuBlankOut2.Name = "m_mnuBlankOut2";
            this.m_mnuBlankOut2.ShortcutKeyDisplayString = "";
            this.m_mnuBlankOut2.Size = new System.Drawing.Size(221, 22);
            this.m_mnuBlankOut2.Text = "作废";
            this.m_mnuBlankOut2.Click += new System.EventHandler(this.m_mnuBlankOut_Click);
            // 
            // m_mnuStop2
            // 
            this.m_mnuStop2.Image = global::Order.Properties.Resources.stoporder;
            this.m_mnuStop2.Name = "m_mnuStop2";
            this.m_mnuStop2.ShortcutKeyDisplayString = "Ctrl+X";
            this.m_mnuStop2.Size = new System.Drawing.Size(221, 22);
            this.m_mnuStop2.Text = "停止";
            this.m_mnuStop2.Click += new System.EventHandler(this.m_mnuStop_Click);
            // 
            // m_mnuRetract2
            // 
            this.m_mnuRetract2.Image = global::Order.Properties.Resources.resort;
            this.m_mnuRetract2.Name = "m_mnuRetract2";
            this.m_mnuRetract2.ShortcutKeyDisplayString = "F9";
            this.m_mnuRetract2.Size = new System.Drawing.Size(221, 22);
            this.m_mnuRetract2.Text = "重整";
            this.m_mnuRetract2.Click += new System.EventHandler(this.m_mnuRetract_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // m_mnuCommitAll2
            // 
            this.m_mnuCommitAll2.Image = global::Order.Properties.Resources.yes;
            this.m_mnuCommitAll2.Name = "m_mnuCommitAll2";
            this.m_mnuCommitAll2.ShortcutKeyDisplayString = "Ctrl+A";
            this.m_mnuCommitAll2.Size = new System.Drawing.Size(221, 22);
            this.m_mnuCommitAll2.Text = "提交所有新建医嘱";
            this.m_mnuCommitAll2.Click += new System.EventHandler(this.m_mnuCommitAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // m_mnuCopy2
            // 
            this.m_mnuCopy2.Image = global::Order.Properties.Resources.databaseLarge;
            this.m_mnuCopy2.Name = "m_mnuCopy2";
            this.m_mnuCopy2.Size = new System.Drawing.Size(221, 22);
            this.m_mnuCopy2.Text = "复制到临时模板";
            this.m_mnuCopy2.Click += new System.EventHandler(this.m_mnuCopy_Click);
            // 
            // m_MenuCopy
            // 
            this.m_MenuCopy.Image = global::Order.Properties.Resources.copy1;
            this.m_MenuCopy.Name = "m_MenuCopy";
            this.m_MenuCopy.ShortcutKeyDisplayString = "";
            this.m_MenuCopy.Size = new System.Drawing.Size(221, 22);
            this.m_MenuCopy.Text = "复制";
            this.m_MenuCopy.Click += new System.EventHandler(this.m_MenuCopy_Click);
            // 
            // m_MenuPase
            // 
            this.m_MenuPase.Image = global::Order.Properties.Resources.parse;
            this.m_MenuPase.Name = "m_MenuPase";
            this.m_MenuPase.ShortcutKeyDisplayString = "";
            this.m_MenuPase.Size = new System.Drawing.Size(221, 22);
            this.m_MenuPase.Text = "粘贴";
            this.m_MenuPase.Click += new System.EventHandler(this.m_MenuPase_Click);
            // 
            // m_mnuCopyBihorder2
            // 
            this.m_mnuCopyBihorder2.Image = global::Order.Properties.Resources.copyorder;
            this.m_mnuCopyBihorder2.Name = "m_mnuCopyBihorder2";
            this.m_mnuCopyBihorder2.Size = new System.Drawing.Size(221, 22);
            this.m_mnuCopyBihorder2.Text = "复制医嘱";
            this.m_mnuCopyBihorder2.Visible = false;
            this.m_mnuCopyBihorder2.Click += new System.EventHandler(this.m_mnuCopyBihOrder_Click);
            // 
            // m_MenuSeeBill
            // 
            this.m_MenuSeeBill.Name = "m_MenuSeeBill";
            this.m_MenuSeeBill.ShortcutKeyDisplayString = "Ctrl+S";
            this.m_MenuSeeBill.Size = new System.Drawing.Size(221, 22);
            this.m_MenuSeeBill.Text = "病人报告查询";
            this.m_MenuSeeBill.Click += new System.EventHandler(this.m_MenuSeeBill_Click);
            // 
            // TSMenuTurnBack
            // 
            this.TSMenuTurnBack.Image = global::Order.Properties.Resources.restore;
            this.TSMenuTurnBack.Name = "TSMenuTurnBack";
            this.TSMenuTurnBack.Size = new System.Drawing.Size(221, 22);
            this.TSMenuTurnBack.Text = "作废恢复";
            this.TSMenuTurnBack.Click += new System.EventHandler(this.TSMenuTurnBack_Click);
            // 
            // m_mnuDoctorSign
            // 
            this.m_mnuDoctorSign.Image = global::Order.Properties.Resources.sign;
            this.m_mnuDoctorSign.Name = "m_mnuDoctorSign";
            this.m_mnuDoctorSign.Size = new System.Drawing.Size(221, 22);
            this.m_mnuDoctorSign.Text = "医生签名";
            this.m_mnuDoctorSign.Click += new System.EventHandler(this.m_mnuDoctorSign_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Image = global::Order.Properties.Resources.stoptime;
            this.menuItem7.Name = "menuItem7";
            this.menuItem7.Size = new System.Drawing.Size(221, 22);
            this.menuItem7.Text = "修改下嘱时间";
            this.menuItem7.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Image = global::Order.Properties.Resources.starttime;
            this.menuItem8.Name = "menuItem8";
            this.menuItem8.Size = new System.Drawing.Size(221, 22);
            this.menuItem8.Text = "修改停嘱时间";
            this.menuItem8.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItemStopAll
            // 
            this.menuItemStopAll.Name = "menuItemStopAll";
            this.menuItemStopAll.Size = new System.Drawing.Size(221, 22);
            this.menuItemStopAll.Text = "停止所有医嘱";
            this.menuItemStopAll.Click += new System.EventHandler(this.menuItemStopAll_Click);
            // 
            // m_MenuChangeArea
            // 
            this.m_MenuChangeArea.Name = "m_MenuChangeArea";
            this.m_MenuChangeArea.Size = new System.Drawing.Size(221, 22);
            this.m_MenuChangeArea.Text = "转科医嘱";
            this.m_MenuChangeArea.Click += new System.EventHandler(this.m_MenuChangeArea_Click);
            // 
            // m_MenuOPERATION
            // 
            this.m_MenuOPERATION.Image = global::Order.Properties.Resources.operate;
            this.m_MenuOPERATION.Name = "m_MenuOPERATION";
            this.m_MenuOPERATION.Size = new System.Drawing.Size(221, 22);
            this.m_MenuOPERATION.Text = "术后医嘱";
            this.m_MenuOPERATION.Click += new System.EventHandler(this.m_MenuOPERATION_Click);
            // 
            // m_MenuATTACHTIMES_INT
            // 
            this.m_MenuATTACHTIMES_INT.Checked = true;
            this.m_MenuATTACHTIMES_INT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_MenuATTACHTIMES_INT.Image = global::Order.Properties.Resources.editone;
            this.m_MenuATTACHTIMES_INT.Name = "m_MenuATTACHTIMES_INT";
            this.m_MenuATTACHTIMES_INT.Size = new System.Drawing.Size(221, 22);
            this.m_MenuATTACHTIMES_INT.Text = "修改补次";
            this.m_MenuATTACHTIMES_INT.Click += new System.EventHandler(this.m_MenuATTACHTIMES_INT_Click);
            // 
            // m_MenuCHNAGEAMOUNT_INT
            // 
            this.m_MenuCHNAGEAMOUNT_INT.Name = "m_MenuCHNAGEAMOUNT_INT";
            this.m_MenuCHNAGEAMOUNT_INT.Size = new System.Drawing.Size(221, 22);
            this.m_MenuCHNAGEAMOUNT_INT.Text = "修改数量";
            this.m_MenuCHNAGEAMOUNT_INT.Click += new System.EventHandler(this.m_MenuCHNAGEAMOUNT_INT_Click);
            // 
            // m_MenuOrderTemp
            // 
            this.m_MenuOrderTemp.Name = "m_MenuOrderTemp";
            this.m_MenuOrderTemp.Size = new System.Drawing.Size(221, 22);
            this.m_MenuOrderTemp.Text = "新增到医嘱模板";
            this.m_MenuOrderTemp.Click += new System.EventHandler(this.m_MenuOrderTemp_Click);
            // 
            // m_MenuOrderNornal
            // 
            this.m_MenuOrderNornal.Name = "m_MenuOrderNornal";
            this.m_MenuOrderNornal.Size = new System.Drawing.Size(221, 22);
            this.m_MenuOrderNornal.Text = "增加到常用项目";
            this.m_MenuOrderNornal.Click += new System.EventHandler(this.m_MenuOrderNornal_Click);
            // 
            // m_MenuReSortOrderNO
            // 
            this.m_MenuReSortOrderNO.Name = "m_MenuReSortOrderNO";
            this.m_MenuReSortOrderNO.Size = new System.Drawing.Size(221, 22);
            this.m_MenuReSortOrderNO.Text = "方号重整";
            this.m_MenuReSortOrderNO.Click += new System.EventHandler(this.m_MenuReSortOrderNO_Click);
            // 
            // m_MenuOrderSTsign
            // 
            this.m_MenuOrderSTsign.Name = "m_MenuOrderSTsign";
            this.m_MenuOrderSTsign.Size = new System.Drawing.Size(221, 22);
            this.m_MenuOrderSTsign.Text = "立即执行医嘱(st标识)";
            this.m_MenuOrderSTsign.Click += new System.EventHandler(this.m_MenuOrderSTsign_Click);
            // 
            // m_MenuCheckBill
            // 
            this.m_MenuCheckBill.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MenuCheckBillEdit,
            this.m_MenuCheckBillView});
            this.m_MenuCheckBill.Name = "m_MenuCheckBill";
            this.m_MenuCheckBill.Size = new System.Drawing.Size(221, 22);
            this.m_MenuCheckBill.Text = "检查申请单";
            // 
            // m_MenuCheckBillEdit
            // 
            this.m_MenuCheckBillEdit.Name = "m_MenuCheckBillEdit";
            this.m_MenuCheckBillEdit.Size = new System.Drawing.Size(100, 22);
            this.m_MenuCheckBillEdit.Text = "编辑";
            this.m_MenuCheckBillEdit.Click += new System.EventHandler(this.m_MenuCheckBillEdit_Click);
            // 
            // m_MenuCheckBillView
            // 
            this.m_MenuCheckBillView.Name = "m_MenuCheckBillView";
            this.m_MenuCheckBillView.Size = new System.Drawing.Size(100, 22);
            this.m_MenuCheckBillView.Text = "查看";
            this.m_MenuCheckBillView.Click += new System.EventHandler(this.m_MenuCheckBillView_Click);
            // 
            // m_MenuViewBackReasion
            // 
            this.m_MenuViewBackReasion.Name = "m_MenuViewBackReasion";
            this.m_MenuViewBackReasion.Size = new System.Drawing.Size(221, 22);
            this.m_MenuViewBackReasion.Text = "查看退回原因";
            this.m_MenuViewBackReasion.Click += new System.EventHandler(this.m_MenuViewBackReasion_Click);
            // 
            // m_MenuOutHis
            // 
            this.m_MenuOutHis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MenuOutToday,
            this.m_MenuOutTomorrow});
            this.m_MenuOutHis.Name = "m_MenuOutHis";
            this.m_MenuOutHis.Size = new System.Drawing.Size(221, 22);
            this.m_MenuOutHis.Text = "出院医嘱";
            // 
            // m_MenuOutToday
            // 
            this.m_MenuOutToday.Name = "m_MenuOutToday";
            this.m_MenuOutToday.Size = new System.Drawing.Size(124, 22);
            this.m_MenuOutToday.Text = "今天出院";
            this.m_MenuOutToday.Click += new System.EventHandler(this.m_MenuOutToday_Click);
            // 
            // m_MenuOutTomorrow
            // 
            this.m_MenuOutTomorrow.Name = "m_MenuOutTomorrow";
            this.m_MenuOutTomorrow.Size = new System.Drawing.Size(124, 22);
            this.m_MenuOutTomorrow.Text = "明天出院";
            this.m_MenuOutTomorrow.Click += new System.EventHandler(this.m_MenuOutTomorrow_Click);
            // 
            // m_MenuMoneyCount
            // 
            this.m_MenuMoneyCount.Name = "m_MenuMoneyCount";
            this.m_MenuMoneyCount.ShortcutKeyDisplayString = "Ctrl+W";
            this.m_MenuMoneyCount.Size = new System.Drawing.Size(221, 22);
            this.m_MenuMoneyCount.Text = "新开医嘱费用合计";
            this.m_MenuMoneyCount.Click += new System.EventHandler(this.m_MenuMoneyCount_Click);
            // 
            // tsbOpApplyNew
            // 
            this.tsbOpApplyNew.Name = "tsbOpApplyNew";
            this.tsbOpApplyNew.Size = new System.Drawing.Size(221, 22);
            this.tsbOpApplyNew.Text = "手术申请单-新";
            this.tsbOpApplyNew.Click += new System.EventHandler(this.tsbOpApplyNew_Click);
            // 
            // m_MenuSurgery
            // 
            this.m_MenuSurgery.Name = "m_MenuSurgery";
            this.m_MenuSurgery.Size = new System.Drawing.Size(221, 22);
            this.m_MenuSurgery.Text = "手术申请单-旧";
            this.m_MenuSurgery.Click += new System.EventHandler(this.m_MenuSurgery_Click);
            // 
            // tsmiDrugInfo
            // 
            this.tsmiDrugInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDrugInfo.Image")));
            this.tsmiDrugInfo.Name = "tsmiDrugInfo";
            this.tsmiDrugInfo.Size = new System.Drawing.Size(221, 22);
            this.tsmiDrugInfo.Text = "药品说明书";
            this.tsmiDrugInfo.Click += new System.EventHandler(this.tsmiDrugInfo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(218, 6);
            // 
            // tsmiTskjyhz_apply
            // 
            this.tsmiTskjyhz_apply.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTskjyhz_apply.Image")));
            this.tsmiTskjyhz_apply.Name = "tsmiTskjyhz_apply";
            this.tsmiTskjyhz_apply.Size = new System.Drawing.Size(221, 22);
            this.tsmiTskjyhz_apply.Text = "特殊抗菌药会诊-申请";
            this.tsmiTskjyhz_apply.Click += new System.EventHandler(this.tsmiTskjyhz_apply_Click);
            // 
            // tsmiTskjyhz_check
            // 
            this.tsmiTskjyhz_check.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTskjyhz_check.Image")));
            this.tsmiTskjyhz_check.Name = "tsmiTskjyhz_check";
            this.tsmiTskjyhz_check.Size = new System.Drawing.Size(221, 22);
            this.tsmiTskjyhz_check.Text = "特殊抗菌药会诊-审核";
            this.tsmiTskjyhz_check.Click += new System.EventHandler(this.tsmiTskjyhz_check_Click);
            // 
            // tsmiTskjyhz_response
            // 
            this.tsmiTskjyhz_response.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTskjyhz_response.Image")));
            this.tsmiTskjyhz_response.Name = "tsmiTskjyhz_response";
            this.tsmiTskjyhz_response.Size = new System.Drawing.Size(221, 22);
            this.tsmiTskjyhz_response.Text = "特殊抗菌药会诊-回复";
            this.tsmiTskjyhz_response.Click += new System.EventHandler(this.tsmiTskjyhz_response_Click);
            // 
            // toolTip2
            // 
            this.toolTip2.AutoPopDelay = 1000;
            this.toolTip2.InitialDelay = 200;
            this.toolTip2.ReshowDelay = 100;
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.AnimationDelay = 20;
            this.collapsibleSplitter1.AnimationStep = 20;
            this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.collapsibleSplitter1.ControlToHide = this.panel2;
            this.collapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(0, 547);
            this.collapsibleSplitter1.MinExtra = 200;
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.Size = new System.Drawing.Size(1023, 8);
            this.collapsibleSplitter1.TabIndex = 59;
            this.collapsibleSplitter1.TabStop = false;
            this.toolTip2.SetToolTip(this.collapsibleSplitter1, "显示\\隐藏医嘱编辑区");
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.m_imgBackAlert);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.m_txtCREATEAREA);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.m_cboOrderList);
            this.panel2.Controls.Add(this.m_lblEditState);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.m_lblOrderStatus);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.m_chkNeedFeel);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 555);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1023, 36);
            this.panel2.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label10.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label10.Location = new System.Drawing.Point(468, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 120;
            this.label10.Text = "开单科室:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label4.Location = new System.Drawing.Point(236, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "状 态:";
            // 
            // m_cboOrderList
            // 
            this.m_cboOrderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboOrderList.FormattingEnabled = true;
            this.m_cboOrderList.Location = new System.Drawing.Point(285, 6);
            this.m_cboOrderList.MaxDropDownItems = 12;
            this.m_cboOrderList.Name = "m_cboOrderList";
            this.m_cboOrderList.Size = new System.Drawing.Size(181, 22);
            this.m_cboOrderList.TabIndex = 60;
            this.m_cboOrderList.SelectionChangeCommitted += new System.EventHandler(this.m_cboOrderList_SelectionChangeCommitted);
            // 
            // m_lblEditState
            // 
            this.m_lblEditState.AutoSize = true;
            this.m_lblEditState.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_lblEditState.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_lblEditState.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.m_lblEditState.ForeColor = System.Drawing.Color.Red;
            this.m_lblEditState.Location = new System.Drawing.Point(708, 7);
            this.m_lblEditState.Name = "m_lblEditState";
            this.m_lblEditState.Size = new System.Drawing.Size(63, 13);
            this.m_lblEditState.TabIndex = 44;
            this.m_lblEditState.Text = "医嘱状态";
            this.m_lblEditState.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_cobOrderCate);
            this.groupBox4.Controls.Add(this.seachClass);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(1, -7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 38);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // m_cobOrderCate
            // 
            this.m_cobOrderCate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_cobOrderCate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobOrderCate.Location = new System.Drawing.Point(37, 32);
            this.m_cobOrderCate.Name = "m_cobOrderCate";
            this.m_cobOrderCate.Size = new System.Drawing.Size(110, 22);
            this.m_cobOrderCate.TabIndex = 2;
            this.m_cobOrderCate.Visible = false;
            this.m_cobOrderCate.SelectedIndexChanged += new System.EventHandler(this.m_mthShowStatusChange);
            // 
            // seachClass
            // 
            this.seachClass.Cursor = System.Windows.Forms.Cursors.Default;
            this.seachClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seachClass.FormattingEnabled = true;
            this.seachClass.Items.AddRange(new object[] {
            "拼音码",
            "五笔码",
            "项目名称",
            "用户编码"});
            this.seachClass.Location = new System.Drawing.Point(59, 12);
            this.seachClass.Name = "seachClass";
            this.seachClass.Size = new System.Drawing.Size(133, 22);
            this.seachClass.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label16.Location = new System.Drawing.Point(7, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "查  询:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdoToday);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_rdoAllDay);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(787, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 37);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // m_rdoToday
            // 
            this.m_rdoToday.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_rdoToday.Location = new System.Drawing.Point(102, 9);
            this.m_rdoToday.Name = "m_rdoToday";
            this.m_rdoToday.Size = new System.Drawing.Size(53, 24);
            this.m_rdoToday.TabIndex = 101;
            this.m_rdoToday.Text = "当天";
            this.m_rdoToday.CheckedChanged += new System.EventHandler(this.m_mthShowConditionChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "范围";
            // 
            // m_rdoAllDay
            // 
            this.m_rdoAllDay.Checked = true;
            this.m_rdoAllDay.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_rdoAllDay.Location = new System.Drawing.Point(44, 9);
            this.m_rdoAllDay.Name = "m_rdoAllDay";
            this.m_rdoAllDay.Size = new System.Drawing.Size(53, 24);
            this.m_rdoAllDay.TabIndex = 100;
            this.m_rdoAllDay.TabStop = true;
            this.m_rdoAllDay.Text = "所有";
            this.m_rdoAllDay.CheckedChanged += new System.EventHandler(this.m_mthShowConditionChange);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.alertLight1);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_rdoTempType);
            this.groupBox2.Controls.Add(this.m_rdoLongType);
            this.groupBox2.Controls.Add(this.m_rdoAllType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(769, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 38);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // alertLight1
            // 
            this.alertLight1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.alertLight1.IsTabu = true;
            this.alertLight1.Location = new System.Drawing.Point(17, -7);
            this.alertLight1.Name = "alertLight1";
            this.alertLight1.Size = new System.Drawing.Size(33, 21);
            this.alertLight1.TabIndex = 3;
            this.alertLight1.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(153, 15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 18);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Text = "带药";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_chkStatus3);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.m_chkStatus4);
            this.groupBox3.Controls.Add(this.m_chkStatus2);
            this.groupBox3.Controls.Add(this.m_chkStatus1);
            this.groupBox3.Controls.Add(this.m_chkStatus0);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(218, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(411, 37);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 5;
            this.label17.Text = "状    态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "类型";
            // 
            // m_rdoTempType
            // 
            this.m_rdoTempType.Location = new System.Drawing.Point(111, 12);
            this.m_rdoTempType.Name = "m_rdoTempType";
            this.m_rdoTempType.Size = new System.Drawing.Size(36, 24);
            this.m_rdoTempType.TabIndex = 3;
            this.m_rdoTempType.Text = "临";
            this.m_rdoTempType.CheckedChanged += new System.EventHandler(this.m_mthShowConditionChange);
            // 
            // m_rdoLongType
            // 
            this.m_rdoLongType.Location = new System.Drawing.Point(75, 12);
            this.m_rdoLongType.Name = "m_rdoLongType";
            this.m_rdoLongType.Size = new System.Drawing.Size(35, 24);
            this.m_rdoLongType.TabIndex = 2;
            this.m_rdoLongType.Text = "长";
            this.m_rdoLongType.CheckedChanged += new System.EventHandler(this.m_mthShowConditionChange);
            // 
            // m_rdoAllType
            // 
            this.m_rdoAllType.Checked = true;
            this.m_rdoAllType.Location = new System.Drawing.Point(41, 12);
            this.m_rdoAllType.Name = "m_rdoAllType";
            this.m_rdoAllType.Size = new System.Drawing.Size(34, 24);
            this.m_rdoAllType.TabIndex = 1;
            this.m_rdoAllType.TabStop = true;
            this.m_rdoAllType.Text = "全";
            this.m_rdoAllType.CheckedChanged += new System.EventHandler(this.m_mthShowConditionChange);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(1, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 89);
            this.label3.TabIndex = 0;
            // 
            // m_chkNeedFeel
            // 
            this.m_chkNeedFeel.AutoSize = true;
            this.m_chkNeedFeel.Location = new System.Drawing.Point(786, 16);
            this.m_chkNeedFeel.Name = "m_chkNeedFeel";
            this.m_chkNeedFeel.Size = new System.Drawing.Size(68, 18);
            this.m_chkNeedFeel.TabIndex = 3;
            this.m_chkNeedFeel.Text = "仅皮试";
            this.m_chkNeedFeel.Visible = false;
            this.m_chkNeedFeel.CheckedChanged += new System.EventHandler(this.m_mthShowConditionChange);
            // 
            // cmbApply
            // 
            this.cmbApply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApply.Location = new System.Drawing.Point(771, 80);
            this.cmbApply.Name = "cmbApply";
            this.cmbApply.Size = new System.Drawing.Size(112, 22);
            this.cmbApply.TabIndex = 68;
            this.cmbApply.Visible = false;
            this.cmbApply.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbApply_KeyDown);
            // 
            // m_txtBackReason
            // 
            this.m_txtBackReason.BackColor = System.Drawing.Color.Snow;
            this.m_txtBackReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBackReason.Location = new System.Drawing.Point(184, 216);
            this.m_txtBackReason.Multiline = true;
            this.m_txtBackReason.Name = "m_txtBackReason";
            this.m_txtBackReason.ReadOnly = true;
            this.m_txtBackReason.Size = new System.Drawing.Size(292, 48);
            this.m_txtBackReason.TabIndex = 44;
            this.m_txtBackReason.Visible = false;
            // 
            // btCreatBill
            // 
            this.btCreatBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btCreatBill.DefaultScheme = true;
            this.btCreatBill.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btCreatBill.Font = new System.Drawing.Font("新宋体", 7F);
            this.btCreatBill.Hint = "";
            this.btCreatBill.Location = new System.Drawing.Point(884, 80);
            this.btCreatBill.Name = "btCreatBill";
            this.btCreatBill.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btCreatBill.Size = new System.Drawing.Size(24, 22);
            this.btCreatBill.TabIndex = 69;
            this.btCreatBill.Text = ">>";
            this.btCreatBill.Visible = false;
            this.btCreatBill.Click += new System.EventHandler(this.btCreatBill_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_dtvOrder);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1023, 377);
            this.panel4.TabIndex = 66;
            // 
            // m_dtvOrder
            // 
            this.m_dtvOrder.AllowUserToAddRows = false;
            this.m_dtvOrder.AllowUserToDeleteRows = false;
            this.m_dtvOrder.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dtvOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dtvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtv_ExecuteType,
            this.m_dtPOSTDATE_DAT,
            this.CREATOR_CHR,
            this.ASSESSORFOREXEC_CHR,
            this.dtv_RecipeNo,
            this.dtv_Name,
            this.dtv_Dosage,
            this.dtv_UseType,
            this.dtv_Freq,
            this.dtv_REMARK,
            this.dtv_FinishDate,
            this.dtv_Stoper,
            this.ASSESSORFORSTOP_CHR,
            this.ATTACHTIMES_INT,
            this.STATUS_INT,
            this.RATETYPE_INT,
            this.isOps,
            this.MedicareTypeName,
            this.dtv_Get,
            this.dtv_Sum,
            this.dtv_StartDate,
            this.dtv_Executor,
            this.dtv_DELETE_DAT,
            this.dtv_DELETERNAME_VCHR,
            this.viewname_vchr,
            this.dtv_method,
            this.dtv_NO,
            this.dtv_OUTGETMEDDAYS_INT,
            this.dtv_CREATEAREA_Name,
            this.dtv_DOCTOR_VCHR,
            this.dtv_DOCTOR_SIGN,
            this.CREATEDATE_DAT,
            this.dtv_ChangedID,
            this.dtv_ChangedDate,
            this.m_dtStartDate,
            this.m_dtvSENDBACKER_CHR});
            this.m_dtvOrder.ContextMenuStrip = this.m_ctxGridMenu2;
            this.m_dtvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtvOrder.Location = new System.Drawing.Point(0, 0);
            this.m_dtvOrder.Name = "m_dtvOrder";
            this.m_dtvOrder.ReadOnly = true;
            this.m_dtvOrder.RowHeadersVisible = false;
            this.m_dtvOrder.RowTemplate.Height = 28;
            this.m_dtvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvOrder.Size = new System.Drawing.Size(527, 377);
            this.m_dtvOrder.TabIndex = 43;
            this.m_dtvOrder.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dtvOrder_CellMouseClick);
            this.m_dtvOrder.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dtvOrder_ColumnHeaderMouseClick);
            this.m_dtvOrder.CurrentCellChanged += new System.EventHandler(this.m_dtgOrder_m_evtCurrentCellChanged);
            this.m_dtvOrder.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dtvOrder_DataError);
            this.m_dtvOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtvOrder_KeyDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnSel);
            this.panel5.Controls.Add(this.pnTabs);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(527, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(496, 377);
            this.panel5.TabIndex = 41;
            // 
            // pnSel
            // 
            this.pnSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnSel.Location = new System.Drawing.Point(24, 0);
            this.pnSel.Name = "pnSel";
            this.pnSel.Size = new System.Drawing.Size(472, 377);
            this.pnSel.TabIndex = 3;
            this.pnSel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnSel_MouseMove);
            // 
            // pnTabs
            // 
            this.pnTabs.Controls.Add(this.lbePriceInfo);
            this.pnTabs.Controls.Add(this.lblBoard);
            this.pnTabs.Controls.Add(this.lblLeft);
            this.pnTabs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnTabs.Location = new System.Drawing.Point(0, 0);
            this.pnTabs.Name = "pnTabs";
            this.pnTabs.Size = new System.Drawing.Size(24, 377);
            this.pnTabs.TabIndex = 2;
            // 
            // lbePriceInfo
            // 
            this.lbePriceInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lbePriceInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbePriceInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbePriceInfo.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lbePriceInfo.ForeColor = System.Drawing.Color.Black;
            this.lbePriceInfo.Location = new System.Drawing.Point(0, 192);
            this.lbePriceInfo.Name = "lbePriceInfo";
            this.lbePriceInfo.Size = new System.Drawing.Size(24, 92);
            this.lbePriceInfo.TabIndex = 0;
            this.lbePriceInfo.Text = "收费信息";
            this.lbePriceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbePriceInfo.Click += new System.EventHandler(this.lbePriceInfo_Click);
            // 
            // lblBoard
            // 
            this.lblBoard.BackColor = System.Drawing.SystemColors.Control;
            this.lblBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBoard.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblBoard.ForeColor = System.Drawing.Color.Black;
            this.lblBoard.Location = new System.Drawing.Point(0, 92);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(24, 100);
            this.lblBoard.TabIndex = 2;
            this.lblBoard.Text = "临时模板";
            this.lblBoard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBoard.Click += new System.EventHandler(this.lblBoard_Click);
            // 
            // lblLeft
            // 
            this.lblLeft.BackColor = System.Drawing.SystemColors.Control;
            this.lblLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeft.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblLeft.ForeColor = System.Drawing.Color.Black;
            this.lblLeft.Location = new System.Drawing.Point(0, 0);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(24, 92);
            this.lblLeft.TabIndex = 1;
            this.lblLeft.Text = "选择病人";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeft.Click += new System.EventHandler(this.lblLeft_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboPrintType);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.m_plControls);
            this.panel3.Controls.Add(this.m_ctlOrderDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 445);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1023, 102);
            this.panel3.TabIndex = 20;
            // 
            // cboPrintType
            // 
            this.cboPrintType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrintType.FormattingEnabled = true;
            this.cboPrintType.Items.AddRange(new object[] {
            "医嘱单",
            "带药处方",
            "麻醉药品处方"});
            this.cboPrintType.Location = new System.Drawing.Point(680, 72);
            this.cboPrintType.Name = "cboPrintType";
            this.cboPrintType.Size = new System.Drawing.Size(107, 22);
            this.cboPrintType.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label5.Location = new System.Drawing.Point(619, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 122;
            this.label5.Text = "打印选项:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_plControls
            // 
            this.m_plControls.BackColor = System.Drawing.SystemColors.Control;
            this.m_plControls.Controls.Add(this.m_cmdDelete2);
            this.m_plControls.Controls.Add(this.m_cmdChange);
            this.m_plControls.Controls.Add(this.m_cmdToCommit);
            this.m_plControls.Controls.Add(this.m_cmdDelete);
            this.m_plControls.Controls.Add(this.cmdPrintOrder);
            this.m_plControls.Controls.Add(this.m_cmdAdd);
            this.m_plControls.Controls.Add(this.m_cmdSave);
            this.m_plControls.Controls.Add(this.m_cmdStop);
            this.m_plControls.Controls.Add(this.m_cmdRetract);
            this.m_plControls.Controls.Add(this.m_cmdBlankOut);
            this.m_plControls.Controls.Add(this.cmdRefurbish);
            this.m_plControls.Controls.Add(this.m_cmdSub);
            this.m_plControls.Controls.Add(this.m_cmdCommitAll);
            this.m_plControls.Controls.Add(this.m_cmdClose);
            this.m_plControls.Controls.Add(this.m_cmdChgView);
            this.m_plControls.Location = new System.Drawing.Point(832, 3);
            this.m_plControls.Name = "m_plControls";
            this.m_plControls.Size = new System.Drawing.Size(189, 97);
            this.m_plControls.TabIndex = 300;
            // 
            // m_cmdDelete2
            // 
            this.m_cmdDelete2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdDelete2.DefaultScheme = true;
            this.m_cmdDelete2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete2.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_cmdDelete2.Hint = "";
            this.m_cmdDelete2.Location = new System.Drawing.Point(4, 33);
            this.m_cmdDelete2.Name = "m_cmdDelete2";
            this.m_cmdDelete2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete2.Size = new System.Drawing.Size(61, 29);
            this.m_cmdDelete2.TabIndex = 43;
            this.m_cmdDelete2.Text = "删除 F6";
            this.m_cmdDelete2.Click += new System.EventHandler(this.m_cmdDelete2_Click);
            // 
            // m_cmdChange
            // 
            this.m_cmdChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdChange.DefaultScheme = true;
            this.m_cmdChange.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChange.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_cmdChange.Hint = "";
            this.m_cmdChange.Location = new System.Drawing.Point(125, 2);
            this.m_cmdChange.Name = "m_cmdChange";
            this.m_cmdChange.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChange.Size = new System.Drawing.Size(61, 29);
            this.m_cmdChange.TabIndex = 42;
            this.m_cmdChange.Text = "修改 M";
            this.m_cmdChange.Click += new System.EventHandler(this.m_cmdChange_Click);
            // 
            // m_cmdToCommit
            // 
            this.m_cmdToCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdToCommit.DefaultScheme = true;
            this.m_cmdToCommit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToCommit.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_cmdToCommit.Hint = "";
            this.m_cmdToCommit.Location = new System.Drawing.Point(64, 33);
            this.m_cmdToCommit.Name = "m_cmdToCommit";
            this.m_cmdToCommit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToCommit.Size = new System.Drawing.Size(61, 29);
            this.m_cmdToCommit.TabIndex = 44;
            this.m_cmdToCommit.Text = "提交 A";
            this.m_cmdToCommit.Click += new System.EventHandler(this.m_cmdToCommit_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Enabled = false;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(3, 152);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(71, 26);
            this.m_cmdDelete.TabIndex = 43;
            this.m_cmdDelete.Text = "删除 F6";
            this.m_cmdDelete.Visible = false;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdAdd
            // 
            this.m_cmdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdAdd.DefaultScheme = true;
            this.m_cmdAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAdd.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_cmdAdd.Hint = "";
            this.m_cmdAdd.Location = new System.Drawing.Point(4, 2);
            this.m_cmdAdd.Name = "m_cmdAdd";
            this.m_cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_cmdAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAdd.Size = new System.Drawing.Size(61, 29);
            this.m_cmdAdd.TabIndex = 40;
            this.m_cmdAdd.Text = "添加 F2";
            this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(64, 2);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(61, 29);
            this.m_cmdSave.TabIndex = 41;
            this.m_cmdSave.Text = "保存 F12";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdRetract
            // 
            this.m_cmdRetract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdRetract.DefaultScheme = true;
            this.m_cmdRetract.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRetract.Hint = "";
            this.m_cmdRetract.Location = new System.Drawing.Point(146, 152);
            this.m_cmdRetract.Name = "m_cmdRetract";
            this.m_cmdRetract.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRetract.Size = new System.Drawing.Size(63, 26);
            this.m_cmdRetract.TabIndex = 47;
            this.m_cmdRetract.Text = "重整 S";
            this.m_cmdRetract.Visible = false;
            this.m_cmdRetract.Click += new System.EventHandler(this.m_cmdRetract_Click);
            // 
            // m_cmdBlankOut
            // 
            this.m_cmdBlankOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdBlankOut.DefaultScheme = true;
            this.m_cmdBlankOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdBlankOut.Enabled = false;
            this.m_cmdBlankOut.Hint = "";
            this.m_cmdBlankOut.Location = new System.Drawing.Point(80, 152);
            this.m_cmdBlankOut.Name = "m_cmdBlankOut";
            this.m_cmdBlankOut.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdBlankOut.Size = new System.Drawing.Size(62, 26);
            this.m_cmdBlankOut.TabIndex = 44;
            this.m_cmdBlankOut.Text = "作废 F6";
            this.m_cmdBlankOut.Visible = false;
            this.m_cmdBlankOut.Click += new System.EventHandler(this.m_cmdBlankOut_Click);
            // 
            // cmdRefurbish
            // 
            this.cmdRefurbish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdRefurbish.DefaultScheme = true;
            this.cmdRefurbish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRefurbish.Font = new System.Drawing.Font("宋体", 9.5F);
            this.cmdRefurbish.Hint = "";
            this.cmdRefurbish.Location = new System.Drawing.Point(64, 64);
            this.cmdRefurbish.Name = "cmdRefurbish";
            this.cmdRefurbish.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRefurbish.Size = new System.Drawing.Size(61, 29);
            this.cmdRefurbish.TabIndex = 46;
            this.cmdRefurbish.Text = "刷新 F10";
            this.cmdRefurbish.Click += new System.EventHandler(this.cmdRefurbish_Click);
            // 
            // m_cmdSub
            // 
            this.m_cmdSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdSub.DefaultScheme = true;
            this.m_cmdSub.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSub.Enabled = false;
            this.m_cmdSub.Hint = "";
            this.m_cmdSub.Location = new System.Drawing.Point(149, 120);
            this.m_cmdSub.Name = "m_cmdSub";
            this.m_cmdSub.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSub.Size = new System.Drawing.Size(56, 26);
            this.m_cmdSub.TabIndex = 41;
            this.m_cmdSub.Text = "子医嘱(F9)";
            this.m_cmdSub.Click += new System.EventHandler(this.m_cmdSub_Click);
            // 
            // m_cmdCommitAll
            // 
            this.m_cmdCommitAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdCommitAll.DefaultScheme = true;
            this.m_cmdCommitAll.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCommitAll.Hint = "";
            this.m_cmdCommitAll.Location = new System.Drawing.Point(77, 120);
            this.m_cmdCommitAll.Name = "m_cmdCommitAll";
            this.m_cmdCommitAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCommitAll.Size = new System.Drawing.Size(71, 26);
            this.m_cmdCommitAll.TabIndex = 70;
            this.m_cmdCommitAll.Text = "提交所有";
            this.m_cmdCommitAll.Visible = false;
            this.m_cmdCommitAll.Click += new System.EventHandler(this.m_cmdCommitAll_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(125, 64);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(61, 29);
            this.m_cmdClose.TabIndex = 48;
            this.m_cmdClose.Text = "退出 Esc";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdChgView
            // 
            this.m_cmdChgView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdChgView.DefaultScheme = true;
            this.m_cmdChgView.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChgView.Hint = "";
            this.m_cmdChgView.Location = new System.Drawing.Point(-1, 120);
            this.m_cmdChgView.Name = "m_cmdChgView";
            this.m_cmdChgView.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChgView.Size = new System.Drawing.Size(71, 26);
            this.m_cmdChgView.TabIndex = 50;
            this.m_cmdChgView.Tag = "0";
            this.m_cmdChgView.Text = "长/临嘱";
            this.m_cmdChgView.Visible = false;
            this.m_cmdChgView.Click += new System.EventHandler(this.m_cmdChgView_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(707, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 71;
            this.label14.Text = "检查申请:";
            this.label14.Visible = false;
            // 
            // m_btnAddBills
            // 
            this.m_btnAddBills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnAddBills.DefaultScheme = true;
            this.m_btnAddBills.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddBills.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_btnAddBills.Hint = "";
            this.m_btnAddBills.Location = new System.Drawing.Point(872, 34);
            this.m_btnAddBills.Name = "m_btnAddBills";
            this.m_btnAddBills.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddBills.Size = new System.Drawing.Size(136, 28);
            this.m_btnAddBills.TabIndex = 72;
            this.m_btnAddBills.Text = "附加单据";
            this.m_btnAddBills.Visible = false;
            // 
            // m_lsvToolTip
            // 
            this.m_lsvToolTip.BackColor = System.Drawing.SystemColors.Window;
            this.m_lsvToolTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvToolTip.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7});
            this.m_lsvToolTip.Font = new System.Drawing.Font("宋体", 10F);
            this.m_lsvToolTip.FullRowSelect = true;
            this.m_lsvToolTip.GridLines = true;
            this.m_lsvToolTip.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvToolTip.HoverSelection = true;
            this.m_lsvToolTip.Location = new System.Drawing.Point(-44, 276);
            this.m_lsvToolTip.Name = "m_lsvToolTip";
            this.m_lsvToolTip.ShowItemToolTips = true;
            this.m_lsvToolTip.Size = new System.Drawing.Size(528, 97);
            this.m_lsvToolTip.TabIndex = 60;
            this.m_lsvToolTip.UseCompatibleStateImageBehavior = false;
            this.m_lsvToolTip.View = System.Windows.Forms.View.Details;
            this.m_lsvToolTip.Visible = false;
            this.m_lsvToolTip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvToolTip_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "项目编码";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "项目名称";
            this.columnHeader3.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "费用类型";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单价";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "数量";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "总金额";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "续用类型";
            this.columnHeader7.Width = 90;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(324, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(609, 182);
            this.label13.TabIndex = 62;
            this.label13.Text = resources.GetString("label13.Text");
            // 
            // m_lblOtherBill
            // 
            this.m_lblOtherBill.Enabled = false;
            this.m_lblOtherBill.Location = new System.Drawing.Point(935, 48);
            this.m_lblOtherBill.Name = "m_lblOtherBill";
            this.m_lblOtherBill.Size = new System.Drawing.Size(64, 16);
            this.m_lblOtherBill.TabIndex = 55;
            this.m_lblOtherBill.TabStop = true;
            this.m_lblOtherBill.Text = "附加单据";
            this.m_lblOtherBill.Visible = false;
            this.m_lblOtherBill.Click += new System.EventHandler(this.m_lblOtherBill_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(968, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 20);
            this.button1.TabIndex = 61;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_pcBoxAlert
            // 
            this.m_pcBoxAlert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_pcBoxAlert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_pcBoxAlert.Image = ((System.Drawing.Image)(resources.GetObject("m_pcBoxAlert.Image")));
            this.m_pcBoxAlert.Location = new System.Drawing.Point(959, 34);
            this.m_pcBoxAlert.Name = "m_pcBoxAlert";
            this.m_pcBoxAlert.Size = new System.Drawing.Size(30, 30);
            this.m_pcBoxAlert.TabIndex = 102;
            this.m_pcBoxAlert.TabStop = false;
            this.m_pcBoxAlert.Visible = false;
            this.m_pcBoxAlert.Click += new System.EventHandler(this.m_pcBoxAlert_Click);
            // 
            // m_ctlOrderDetail
            // 
            this.m_ctlOrderDetail.DoctorEditable = true;
            this.m_ctlOrderDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctlOrderDetail.IsMedicareMan = false;
            this.m_ctlOrderDetail.Location = new System.Drawing.Point(0, 0);
            this.m_ctlOrderDetail.Name = "m_ctlOrderDetail";
            this.m_ctlOrderDetail.ReadOnly = false;
            this.m_ctlOrderDetail.Size = new System.Drawing.Size(832, 100);
            this.m_ctlOrderDetail.TabIndex = 30;
            this.m_ctlOrderDetail.m_evtInputNO += new System.EventHandler(this.m_ctlOrderDetail_m_evtInputNO);
            this.m_ctlOrderDetail.evtInputOrder += new System.EventHandler(this.m_ctlOrderDetail_evtInputOrder);
            this.m_ctlOrderDetail.m_evtInputEnd += new System.EventHandler(this.m_ctlOrderDetail_m_evtInputEnd);
            // 
            // m_txtCREATEAREA
            // 
            this.m_txtCREATEAREA.Location = new System.Drawing.Point(535, 6);
            this.m_txtCREATEAREA.Name = "m_txtCREATEAREA";
            this.m_txtCREATEAREA.Size = new System.Drawing.Size(157, 23);
            this.m_txtCREATEAREA.TabIndex = 119;
            this.m_txtCREATEAREA.DoubleClick += new System.EventHandler(this.m_txtCREATEAREA_DoubleClick);
            this.m_txtCREATEAREA.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtCREATEAREA_m_evtSelectItem);
            this.m_txtCREATEAREA.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtCREATEAREA_m_evtFindItem);
            this.m_txtCREATEAREA.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtCREATEAREA_m_evtInitListView);
            // 
            // m_ctlPatient
            // 
            this.m_ctlPatient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_ctlPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_ctlPatient.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_ctlPatient.Location = new System.Drawing.Point(0, 0);
            this.m_ctlPatient.Name = "m_ctlPatient";
            this.m_ctlPatient.Size = new System.Drawing.Size(1023, 68);
            this.m_ctlPatient.TabIndex = 1;
            this.m_ctlPatient.TabStop = false;
            this.m_ctlPatient.m_evtPatientFromBedAdmin += new System.EventHandler(this.m_ctlPatient_m_evtPatientFromBedAdmin);
            this.m_ctlPatient.m_evtPatientChanged += new System.EventHandler(this.ctlBIHPatientInfo1_m_evtPatientChanged);
            // 
            // dtv_ExecuteType
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtv_ExecuteType.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtv_ExecuteType.HeaderText = "类型";
            this.dtv_ExecuteType.Name = "dtv_ExecuteType";
            this.dtv_ExecuteType.ReadOnly = true;
            this.dtv_ExecuteType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_ExecuteType.Width = 42;
            // 
            // m_dtPOSTDATE_DAT
            // 
            this.m_dtPOSTDATE_DAT.HeaderText = "下嘱时间";
            this.m_dtPOSTDATE_DAT.Name = "m_dtPOSTDATE_DAT";
            this.m_dtPOSTDATE_DAT.ReadOnly = true;
            this.m_dtPOSTDATE_DAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dtPOSTDATE_DAT.Width = 85;
            // 
            // CREATOR_CHR
            // 
            this.CREATOR_CHR.HeaderText = "开嘱者";
            this.CREATOR_CHR.Name = "CREATOR_CHR";
            this.CREATOR_CHR.ReadOnly = true;
            this.CREATOR_CHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CREATOR_CHR.Width = 55;
            // 
            // ASSESSORFOREXEC_CHR
            // 
            this.ASSESSORFOREXEC_CHR.HeaderText = "过嘱者";
            this.ASSESSORFOREXEC_CHR.Name = "ASSESSORFOREXEC_CHR";
            this.ASSESSORFOREXEC_CHR.ReadOnly = true;
            this.ASSESSORFOREXEC_CHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ASSESSORFOREXEC_CHR.Width = 55;
            // 
            // dtv_RecipeNo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10F);
            this.dtv_RecipeNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtv_RecipeNo.HeaderText = "方";
            this.dtv_RecipeNo.Name = "dtv_RecipeNo";
            this.dtv_RecipeNo.ReadOnly = true;
            this.dtv_RecipeNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_RecipeNo.Width = 30;
            // 
            // dtv_Name
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dtv_Name.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtv_Name.HeaderText = "医嘱内容";
            this.dtv_Name.Name = "dtv_Name";
            this.dtv_Name.ReadOnly = true;
            this.dtv_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Name.Width = 365;
            // 
            // dtv_Dosage
            // 
            this.dtv_Dosage.HeaderText = "用量";
            this.dtv_Dosage.Name = "dtv_Dosage";
            this.dtv_Dosage.ReadOnly = true;
            this.dtv_Dosage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Dosage.Visible = false;
            this.dtv_Dosage.Width = 60;
            // 
            // dtv_UseType
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtv_UseType.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtv_UseType.HeaderText = "用法";
            this.dtv_UseType.Name = "dtv_UseType";
            this.dtv_UseType.ReadOnly = true;
            this.dtv_UseType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_UseType.Visible = false;
            this.dtv_UseType.Width = 60;
            // 
            // dtv_Freq
            // 
            this.dtv_Freq.HeaderText = "频率";
            this.dtv_Freq.Name = "dtv_Freq";
            this.dtv_Freq.ReadOnly = true;
            this.dtv_Freq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Freq.Visible = false;
            this.dtv_Freq.Width = 60;
            // 
            // dtv_REMARK
            // 
            this.dtv_REMARK.HeaderText = "说明";
            this.dtv_REMARK.Name = "dtv_REMARK";
            this.dtv_REMARK.ReadOnly = true;
            this.dtv_REMARK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_REMARK.Width = 80;
            // 
            // dtv_FinishDate
            // 
            this.dtv_FinishDate.HeaderText = "停嘱时间";
            this.dtv_FinishDate.Name = "dtv_FinishDate";
            this.dtv_FinishDate.ReadOnly = true;
            this.dtv_FinishDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_FinishDate.Width = 85;
            // 
            // dtv_Stoper
            // 
            this.dtv_Stoper.HeaderText = "停嘱者";
            this.dtv_Stoper.Name = "dtv_Stoper";
            this.dtv_Stoper.ReadOnly = true;
            this.dtv_Stoper.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Stoper.Width = 55;
            // 
            // ASSESSORFORSTOP_CHR
            // 
            this.ASSESSORFORSTOP_CHR.HeaderText = "过嘱者";
            this.ASSESSORFORSTOP_CHR.Name = "ASSESSORFORSTOP_CHR";
            this.ASSESSORFORSTOP_CHR.ReadOnly = true;
            this.ASSESSORFORSTOP_CHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ASSESSORFORSTOP_CHR.Width = 55;
            // 
            // ATTACHTIMES_INT
            // 
            this.ATTACHTIMES_INT.HeaderText = "补次";
            this.ATTACHTIMES_INT.Name = "ATTACHTIMES_INT";
            this.ATTACHTIMES_INT.ReadOnly = true;
            this.ATTACHTIMES_INT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ATTACHTIMES_INT.Width = 30;
            // 
            // STATUS_INT
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STATUS_INT.DefaultCellStyle = dataGridViewCellStyle6;
            this.STATUS_INT.HeaderText = "医嘱状态";
            this.STATUS_INT.Name = "STATUS_INT";
            this.STATUS_INT.ReadOnly = true;
            this.STATUS_INT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STATUS_INT.Width = 70;
            // 
            // RATETYPE_INT
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RATETYPE_INT.DefaultCellStyle = dataGridViewCellStyle7;
            this.RATETYPE_INT.HeaderText = "药品来源";
            this.RATETYPE_INT.Name = "RATETYPE_INT";
            this.RATETYPE_INT.ReadOnly = true;
            this.RATETYPE_INT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RATETYPE_INT.Width = 45;
            // 
            // isOps
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.isOps.DefaultCellStyle = dataGridViewCellStyle8;
            this.isOps.HeaderText = "口头医嘱";
            this.isOps.Name = "isOps";
            this.isOps.ReadOnly = true;
            this.isOps.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.isOps.Width = 42;
            // 
            // MedicareTypeName
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MedicareTypeName.DefaultCellStyle = dataGridViewCellStyle9;
            this.MedicareTypeName.HeaderText = "医保分类";
            this.MedicareTypeName.Name = "MedicareTypeName";
            this.MedicareTypeName.ReadOnly = true;
            this.MedicareTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MedicareTypeName.Width = 45;
            // 
            // dtv_Get
            // 
            this.dtv_Get.HeaderText = "数量";
            this.dtv_Get.Name = "dtv_Get";
            this.dtv_Get.ReadOnly = true;
            this.dtv_Get.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Get.Width = 60;
            // 
            // dtv_Sum
            // 
            this.dtv_Sum.HeaderText = "总量";
            this.dtv_Sum.Name = "dtv_Sum";
            this.dtv_Sum.ReadOnly = true;
            this.dtv_Sum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Sum.Width = 60;
            // 
            // dtv_StartDate
            // 
            this.dtv_StartDate.HeaderText = "执行时间";
            this.dtv_StartDate.Name = "dtv_StartDate";
            this.dtv_StartDate.ReadOnly = true;
            this.dtv_StartDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_StartDate.Width = 120;
            // 
            // dtv_Executor
            // 
            this.dtv_Executor.HeaderText = "执行人";
            this.dtv_Executor.Name = "dtv_Executor";
            this.dtv_Executor.ReadOnly = true;
            this.dtv_Executor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Executor.Width = 55;
            // 
            // dtv_DELETE_DAT
            // 
            this.dtv_DELETE_DAT.HeaderText = "作废时间";
            this.dtv_DELETE_DAT.Name = "dtv_DELETE_DAT";
            this.dtv_DELETE_DAT.ReadOnly = true;
            this.dtv_DELETE_DAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_DELETE_DAT.Width = 120;
            // 
            // dtv_DELETERNAME_VCHR
            // 
            this.dtv_DELETERNAME_VCHR.HeaderText = "作废人";
            this.dtv_DELETERNAME_VCHR.Name = "dtv_DELETERNAME_VCHR";
            this.dtv_DELETERNAME_VCHR.ReadOnly = true;
            this.dtv_DELETERNAME_VCHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_DELETERNAME_VCHR.Width = 55;
            // 
            // viewname_vchr
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.viewname_vchr.DefaultCellStyle = dataGridViewCellStyle10;
            this.viewname_vchr.HeaderText = "类别";
            this.viewname_vchr.Name = "viewname_vchr";
            this.viewname_vchr.ReadOnly = true;
            this.viewname_vchr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.viewname_vchr.Width = 45;
            // 
            // dtv_method
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtv_method.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtv_method.HeaderText = "方法";
            this.dtv_method.Name = "dtv_method";
            this.dtv_method.ReadOnly = true;
            this.dtv_method.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_method.Width = 45;
            // 
            // dtv_NO
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtv_NO.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtv_NO.HeaderText = "序号";
            this.dtv_NO.Name = "dtv_NO";
            this.dtv_NO.ReadOnly = true;
            this.dtv_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_NO.Width = 45;
            // 
            // dtv_OUTGETMEDDAYS_INT
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtv_OUTGETMEDDAYS_INT.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtv_OUTGETMEDDAYS_INT.HeaderText = "天数";
            this.dtv_OUTGETMEDDAYS_INT.Name = "dtv_OUTGETMEDDAYS_INT";
            this.dtv_OUTGETMEDDAYS_INT.ReadOnly = true;
            this.dtv_OUTGETMEDDAYS_INT.Visible = false;
            this.dtv_OUTGETMEDDAYS_INT.Width = 60;
            // 
            // dtv_CREATEAREA_Name
            // 
            this.dtv_CREATEAREA_Name.HeaderText = "开单科室";
            this.dtv_CREATEAREA_Name.Name = "dtv_CREATEAREA_Name";
            this.dtv_CREATEAREA_Name.ReadOnly = true;
            this.dtv_CREATEAREA_Name.Visible = false;
            // 
            // dtv_DOCTOR_VCHR
            // 
            this.dtv_DOCTOR_VCHR.HeaderText = "医生名称 ";
            this.dtv_DOCTOR_VCHR.Name = "dtv_DOCTOR_VCHR";
            this.dtv_DOCTOR_VCHR.ReadOnly = true;
            this.dtv_DOCTOR_VCHR.Visible = false;
            this.dtv_DOCTOR_VCHR.Width = 60;
            // 
            // dtv_DOCTOR_SIGN
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dtv_DOCTOR_SIGN.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtv_DOCTOR_SIGN.HeaderText = "签名";
            this.dtv_DOCTOR_SIGN.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dtv_DOCTOR_SIGN.Name = "dtv_DOCTOR_SIGN";
            this.dtv_DOCTOR_SIGN.ReadOnly = true;
            this.dtv_DOCTOR_SIGN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtv_DOCTOR_SIGN.Width = 60;
            // 
            // CREATEDATE_DAT
            // 
            this.CREATEDATE_DAT.HeaderText = "录入时间";
            this.CREATEDATE_DAT.Name = "CREATEDATE_DAT";
            this.CREATEDATE_DAT.ReadOnly = true;
            this.CREATEDATE_DAT.Width = 120;
            // 
            // dtv_ChangedID
            // 
            this.dtv_ChangedID.HeaderText = "修改人";
            this.dtv_ChangedID.Name = "dtv_ChangedID";
            this.dtv_ChangedID.ReadOnly = true;
            this.dtv_ChangedID.Width = 80;
            // 
            // dtv_ChangedDate
            // 
            this.dtv_ChangedDate.HeaderText = "修改时间";
            this.dtv_ChangedDate.Name = "dtv_ChangedDate";
            this.dtv_ChangedDate.ReadOnly = true;
            this.dtv_ChangedDate.Width = 120;
            // 
            // m_dtStartDate
            // 
            this.m_dtStartDate.HeaderText = "下嘱时间";
            this.m_dtStartDate.Name = "m_dtStartDate";
            this.m_dtStartDate.ReadOnly = true;
            this.m_dtStartDate.Visible = false;
            this.m_dtStartDate.Width = 85;
            // 
            // m_dtvSENDBACKER_CHR
            // 
            this.m_dtvSENDBACKER_CHR.HeaderText = "退回人";
            this.m_dtvSENDBACKER_CHR.Name = "m_dtvSENDBACKER_CHR";
            this.m_dtvSENDBACKER_CHR.ReadOnly = true;
            this.m_dtvSENDBACKER_CHR.Width = 80;
            // 
            // frmBIHOrderInput
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1023, 591);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_pcBoxAlert);
            this.Controls.Add(this.cmbApply);
            this.Controls.Add(this.m_txtBackReason);
            this.Controls.Add(this.btCreatBill);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.collapsibleSplitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.m_btnAddBills);
            this.Controls.Add(this.m_lsvToolTip);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_lblOtherBill);
            this.Controls.Add(this.m_ctlPatient);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBIHOrderInput";
            this.Text = "医嘱医生工作站";
            this.Load += new System.EventHandler(this.frmBIHOrderInput_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBIHOrderInput_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBIHOrderInput_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgBackAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.m_ctxGridMenu2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrder)).EndInit();
            this.panel5.ResumeLayout(false);
            this.pnTabs.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.m_plControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pcBoxAlert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        //1067 医嘱录入时检查医嘱是否必须填写申请单
        /// <summary>
        /// 1067 医嘱录入时检查医嘱是否必须填写申请单 true 是 false 否
        /// </summary>
        internal bool blnFillApplyBill = false;

        /// <summary>
        /// 大查房天数
        /// </summary>
        internal int dayGrandRounds = 0;

        /// <summary>
        /// 平均住院日
        /// </summary>
        internal int dayAverageStay = 0;

        #region 当前医嘱
        /// <summary>
        /// 当前医嘱Vo对象
        /// </summary>
        internal clsBIHOrder m_objCurrentOrderValue = null;
        /// <summary>
        /// 获取或设置当前医嘱Vo对象
        /// </summary>
        public clsBIHOrder m_objCurrentOrder
        {
            get
            {
                return m_objCurrentOrderValue;
            }
            set
            {
                m_objCurrentOrderValue = value;
            }
        }

        #endregion
        #region 方法
        private string m_strGetStatusMessage(int intStatus)
        {
            return m_objDomain.m_strGetStatusMessage(intStatus);
        }

        private string m_strGetOrderMessage(clsBIHOrder objOrder)
        {
            return m_objDomain.m_strGetOrderMessage(objOrder);
        }

        private void m_mthOnlyNumber(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = false;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            { }
            else if ((e.KeyChar == 8) || (e.KeyChar == 13))
            { }
            else if ((e.KeyChar == '.'))
            { }
            else
            {
                e.Handled = true;
            }
        }


        internal void m_mthShowCurrentOrder(clsBIHOrder objOrder)
        {
            m_ctlOrderDetail.m_mthSetOrder(objOrder);

            if (objOrder != null && objOrder.m_intStatus == 7)
            {
                m_lblOrderStatus.Tag = objOrder;
                string strTool = "退回原因：" + ((objOrder.m_strBACKREASON == null) ? ("") : (objOrder.m_strBACKREASON.Trim()));
                strTool += "\r\n退回护士：" + ((objOrder.m_strSENDBACKER_CHR == null) ? ("") : (objOrder.m_strSENDBACKER_CHR.Trim()));
                strTool += "\r\n退回时间：" + ((objOrder.m_strSENDBACK_DAT == null) ? ("") : (objOrder.m_strSENDBACK_DAT.Trim()));
                toolTip1.SetToolTip(m_lblOrderStatus, strTool);
            }
            else
            {
                m_lblOrderStatus.Tag = null;
                try
                {
                    toolTip1.SetToolTip(m_lblOrderStatus, "医嘱状态");
                }
                catch
                {
                }
            }
            m_lblOrderStatus.Text = m_objDomain.m_strGetOrderMessage(objOrder);
        }

        internal clsBIHOrder m_objGetOrder(clsBIHOrder objOrder)
        {
            if (m_ctlPatient.m_objPatient == null) return null;
            return m_ctlOrderDetail.m_objGetOrder(m_ctlPatient.m_objPatient, objOrder);
        }
        #endregion
        #region 事件
        private void frmBIHOrderInput_Load(object sender, System.EventArgs e)
        {

            //帮助窗口LABEL
            this.label13.Visible = false;
            button1_Click(null, null);
            this.label13.Visible = false;
            //长/临界面控制 
            if (m_strView.Equals("1"))
            {
                LongBihorderSet();
                m_cmdChgView.Tag = m_strView;
                setTheChgViewButton();
            }
            else if (m_strView.Equals("2"))
            {
                ShortBihorderSet();
                m_cmdChgView.Tag = m_strView;
                setTheChgViewButton();
            }
            selectOldColor = this.m_dtvOrder.DefaultCellStyle.SelectionForeColor;

            if (m_objLoginInfo != null)
            {
                m_mthSetCurrentDoctor(m_objLoginInfo.m_strEmpID, m_objLoginInfo.m_strEmpName);
            }
            else if (com.digitalwave.GUI_Base.frmMDI_Child_Base.CurrentLoginInfo != null)
            {
                this.LoginInfo = com.digitalwave.GUI_Base.frmMDI_Child_Base.CurrentLoginInfo;
            }
            this.m_ctlPatient.LoginInfo = this.LoginInfo;
            //查看当前操作是否有处方权
            m_objDomain.m_lngAddGetAccessPower(this.LoginInfo.m_strEmpID, out m_blAccess);
            if (m_blAccess == false)
            {
                m_plControls.Enabled = false;
                m_ctlOrderDetail.Enabled = false;
            }
            m_ctlOrderDetail.cboShiying.SelectedIndex = 0;
            /*<=============================*/
            // 载入医嘱类型     
            m_objDomain.m_Loadm_lngGetOrderCate();
            this.m_objDomain.m_Loadm_lngGetcboOrderList();
            //载入特殊配置表
            m_objDomain.m_LoadGetSPECORDERCATE();
            // 医嘱名称修改开关
            SetTheOrderPowerControls();
            //读取系统表 -检验打折
            if (m_blLisDiscount)
            {
                LoadThePARMVALUE();
            }
            //主医嘱列表界面控制－是否显示医生签名列
            if (m_blDoctorSign)
            {
                this.m_dtvOrder.Columns["dtv_DOCTOR_VCHR"].Visible = false;
                this.m_dtvOrder.Columns["dtv_DOCTOR_SIGN"].Visible = true;
            }
            else
            {
                this.m_dtvOrder.Columns["dtv_DOCTOR_VCHR"].Visible = true;
                this.m_dtvOrder.Columns["dtv_DOCTOR_SIGN"].Visible = false;
            }
            if (m_ctlOrderDetail.m_mthGetDoctor(this.LoginInfo.m_strEmpID) == 0)
            {
                m_mthSetCurrentDoctor(this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName);
            }
            //右边列表的控制
            lblLeft.BackColor = SystemColors.Control;
            lblLeft.ForeColor = Color.Black;
            pnSel.Hide();
            fl.Visible = false;
            m_IsDisPlayToolTip = false;
            lblLeft.Parent.Parent.Width = lblLeft.Width;

            fl.setLoginDoctor(this.LoginInfo);
            //在导入时默认科室为当前员工所在科室 
            clsBIHArea area1 = new clsBIHArea();
            area1.m_strAreaID = this.LoginInfo.m_strInpatientAreaID;
            area1.m_strAreaName = this.LoginInfo.m_strInpatientAreaName;
            if (this.LoginInfo.m_strInpatientAreaID.Trim().Equals(""))
            {
                area1.m_strAreaID = this.LoginInfo.m_strDepartmentID;
                area1.m_strAreaName = this.LoginInfo.m_strdepartmentName;
            }
            m_ctlPatient.m_txtArea.Text = area1.m_strAreaName;
            m_ctlPatient.m_txtArea.Tag = area1;

            //m_ctlOrderDetail.m_txtArea.Text = area1.m_strAreaName;
            //m_ctlOrderDetail.m_txtArea.Tag = area1;
            //开单科室设置
            m_txtCREATEAREA.Tag = area1.m_strAreaID;
            m_txtCREATEAREA.Text = area1.m_strAreaName;
            /*<=========================================*/
            //医生所在工作组ＩＤ
            m_strDOCTORGROUPID_CHR = GetDOCTORGROUPID();
            /*<================================================*/

            if (m_strView.Equals("3") && m_intInvoSrc != 1 && this.m_ctlPatient.m_objPatient == null && ((com.digitalwave.iCare.gui.frmMain)this.MdiParent).m_StrPatientID != null && !((com.digitalwave.iCare.gui.frmMain)this.MdiParent).m_StrPatientID.Trim().Equals(""))
            {
                m_intInvoSrc = 0;
                m_ctlPatient.m_mthGetPatientByPATIENTID(((com.digitalwave.iCare.gui.frmMain)this.MdiParent).m_StrPatientID);

                m_ctlOrderDetail.Focus();
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
            }
            else if (m_intInvoSrc != 1 && this.m_ctlPatient.m_objPatient == null)
            {

                m_intInvoSrc = 0;
                m_ctlPatient.Focus();
                m_ctlPatient.m_txtArea.Focus();
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
            }
            m_mthGetAllStorgeId();//查询各药房ID并赋值
            #region 根据全局变量自动医嘱
            //if (GlobalData.clsPublic.m_ObjGlobalPatient != null)
            //{
            //    this.m_objDomain.m_mthLoadOrderList();
            //}            
            #endregion
            blnFillApplyBill = (com.digitalwave.iCare.gui.HIS.clsPublic.m_intGetSysParm("1067") == 1 ? true : false);

            string p1013 = com.digitalwave.iCare.gui.HIS.clsPublic.m_strGetSysparm("1013");
            string p1014 = com.digitalwave.iCare.gui.HIS.clsPublic.m_strGetSysparm("1014");
            int.TryParse(p1013, out this.dayGrandRounds);
            int.TryParse(p1014, out this.dayAverageStay);

            this.cboPrintType.SelectedIndex = 0;
        }

        /// <summary>
        /// 查询各药房ID并赋值
        /// </summary>
        private void m_mthGetAllStorgeId()
        {
            string strMedDeptId = "";
            string[] strMedDeptIdArr = m_strMedDeptGross.Split('*');
            int intArrCount = strMedDeptIdArr.Length;
            for (int i = 0; i < intArrCount; i++)
            {
                if (i == 0)
                {
                    m_strMedCineStorgeId = strMedDeptIdArr[i];
                }
                else if (i == 1)
                {
                    m_strMidMedCineSorgeId = strMedDeptIdArr[i];
                }
            }
        }

        /// <summary>
        /// 系统参数表(ICARE公用)
        /// </summary>
        internal long LoadThePARMVALUE()
        {

            ArrayList PARMCODE_CHR = new ArrayList();
            DataTable m_dtPARMVALUE_VCHR = new DataTable();
            // PARMCODE_CHR.Add("1008");//1008 住院确认记帐流程对应的身份ID 多种类型以身份隔开
            PARMCODE_CHR.Add("0013");//0013 检验组合打折发票类型 多种类型以身份隔开
            PARMCODE_CHR.Add("0008");//0008参数设置，设置为医保病人身份ID（目用于出院带药不超过7天）
            PARMCODE_CHR.Add("0009");//0009住院中心药房科室ID
            PARMCODE_CHR.Add("1009");//住院库存药房判断
            //long lngRes = m_objManage.LoadThePARMVALUE(PARMCODE_CHR, out m_strPARMVALUE_VCHR);
            long lngRes = m_objDomain.LoadThePARMVALUE(PARMCODE_CHR, out m_dtPARMVALUE_VCHR);
            if (lngRes > 0 && m_dtPARMVALUE_VCHR != null)
            {
                string m_strPARMCODE = "";
                string m_strPARMVALUE = "";
                for (int i = 0; i < m_dtPARMVALUE_VCHR.Rows.Count; i++)
                {
                    m_strPARMCODE = m_dtPARMVALUE_VCHR.Rows[i]["PARMCODE_CHR"].ToString().Trim();
                    m_strPARMVALUE = m_dtPARMVALUE_VCHR.Rows[i]["PARMVALUE_VCHR"].ToString().Trim();

                    switch (m_strPARMCODE)
                    {
                        //case "1008":
                        //    m_strPARMVALUE_VCHR = m_strPARMVALUE;
                        //    break;
                        case "0013":
                            m_strLisPARMVALUE_VCHR = m_strPARMVALUE;
                            break;
                        case "0009":
                            m_strMedDeptId = m_strPARMVALUE;
                            break;
                        case "1009":
                            m_strMedDeptGross = m_strPARMVALUE;
                            break;
                        case "0008":
                            string[] strTemp = m_strPARMVALUE.Split(';');
                            for (int i2 = 0; i2 < strTemp.Length; i2++)
                            {
                                m_lstSocialSecurity.Add(strTemp[i2]);
                            }
                            strTemp = null;
                            break;
                    }
                }
            }
            return lngRes;
        }

        private void SetTheOrderPowerControls()
        {
            //m_intShowCodexRemarkFrm 医生工作站是否显示药典备注 0 不显示 1 显示 0059
            //ShowCodexRemarkFrmTimerinterval 医生工作站药典备注窗口显示时间 0060
            //m_intUpControl 医嘱录入权限费用上限开关1003 0-关，1-开
            //m_intBihNameOpen 功能开关用来控制是否允许修改医嘱诊疗项目名称 1017
            //m_intBihBlankOutOpen 功能开关用来控制是否允许修改医嘱作废 1023
            //m_intTypePControl 片剂数量计算开关1024
            //m_intLessMedControl 缺药显示控制开关
            //m_intDoctorSign 医生签名控制开关
            //m_intZCaoControl 跳过医嘱转抄这个流程，0－不跳过，1－跳过
            //m_intCommitControl 提交时是否需要输入工号及密码 1032
            //m_intDeableMedControl 医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036
            //m_intStopControl 医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037
            //m_intStopTipControl 住院医嘱停医嘱是否需要认证 0-不需要；1-需要 1044
            //m_intCanChangeOrder 是否允许其它医生修改非本人开的转抄前的医嘱 1045
            //m_intSendLisBill 提交时是否发送检验申请单 1050
            //m_intStopTimeSwitth 医生修改停嘱时间的时间限制 0-不限制,>0为限制的时间,如24,即为下嘱后24小时内可以修改  1051</param>
            //m_intLisDiscountNum  4006设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能
            //m_decLisDiscountMount 4007设置启用打折功能时，检验收费项目的打折比例。80，则打八折
            //m_intLisDiscount 4008  0-false不打折 1-true 允许打折
            //m_intAutoStopAlert '1053', '住院医嘱录入界面是否自动提示当前病人存在停用或缺药的未停医嘱', '0-否；1-是', 1, '0010' 
            //m_intStartTimeSwitth 医生修改下嘱时间的时间限制 0-不限制,>0为限制的时间,如24,即为下嘱后24小时内可以修改  1054
            int m_intBihNameOpen, m_intBihBlankOutOpen, m_intShowCodexRemarkFrm, m_intLessMedControl, m_intDoctorSign, m_intZCaoControl, m_intCommitControl, m_intUpControl, m_intStopControl, m_intDeableMedControl, m_intStopTipControl, m_intCanChangeOrder, m_intSendLisBill, m_intLisDiscount, m_intAutoStopAlert, p_intParm1068;
            m_objDomain.m_lngGetBihOrderControls(out m_intBihNameOpen, out m_intBihBlankOutOpen, out m_intTypePControl, out m_intShowCodexRemarkFrm, out ShowCodexRemarkFrmTimerinterval, out  m_intLessMedControl, out  m_intDoctorSign, out m_intZCaoControl, out m_intCommitControl, out  m_intUpControl, out  m_intStopControl, out m_intDeableMedControl, out m_intStopTipControl, out m_intCanChangeOrder, out m_intSendLisBill, out m_intStopTimeSwitth, out m_intLisDiscount, out m_intLisDiscountNum, out m_decLisDiscountMount, out m_intAutoStopAlert, out m_intStartTimeSwitth, out p_intParm1068);
            if (m_intCommitControl == 1)
            {
                m_blCommitControl = true;
            }
            else
            {
                m_blCommitControl = false;
            }
            m_intCommitControl2 = com.digitalwave.iCare.gui.HIS.clsPublic.m_intGetSysParm("1032");
            if (m_intZCaoControl == 0)
            {
                m_blZCaoControl = false;
            }
            else
            {
                m_blZCaoControl = true;
            }
            if (m_intBihNameOpen == 0)
            {
                m_ctlOrderDetail.m_blOrderName2ReadOnly = true;
            }
            else if (m_intBihNameOpen == 1)
            {
                m_ctlOrderDetail.m_blOrderName2ReadOnly = false;
            }
            if (m_intBihBlankOutOpen == 1)
            {
                m_blBlankOutControl = true;
                m_cmdBlankOut.Enabled = true;
            }
            else if (m_intBihBlankOutOpen == 0)
            {
                m_blBlankOutControl = false;
                m_cmdBlankOut.Enabled = false;
            }
            if (m_intShowCodexRemarkFrm == 0)
            {
                IsShowCodexRemarkFrm = false;
            }
            else
            {
                IsShowCodexRemarkFrm = true;
            }
            if (m_intLessMedControl == 1)
            {
                m_blLessMedControl = true;
            }
            else
            {
                m_blLessMedControl = false;
            }
            if (m_intDoctorSign == 1)
            {
                m_blDoctorSign = true;
            }
            else if (m_intDoctorSign == 2)
            {
                m_blDoctorSign = true;
                m_intDoctorAutoSign = 1;
            }
            else
            {
                m_blDoctorSign = false;
            }
            if (m_intUpControl == 0)
            {
                m_blUpControl = false;
            }
            else
            {
                m_blUpControl = true;
            }
            if (m_intStopControl == 0)
            {
                m_blStopControl = false;
            }
            else
            {
                m_blStopControl = true;
            }
            if (m_intDeableMedControl == 0)
            {
                m_blDeableMedControl = false;
            }
            else
            {
                m_blDeableMedControl = true;
            }
            if (m_intStopTipControl == 1)
            {
                m_blStopTipControl = true;
            }
            else
            {
                m_blStopTipControl = false;
            }
            if (m_intCanChangeOrder == 1)
            {
                m_blCanChangeOrder = true;
            }
            else
            {
                m_blCanChangeOrder = false;
            }
            if (m_intSendLisBill == 1)
            {
                m_blSendLisBill = true;
            }
            else
            {
                m_blSendLisBill = false;
            }
            if (m_intLisDiscount == 1)
            {
                m_blLisDiscount = true;
            }
            else
            {
                m_blLisDiscount = false;

            }
            if (m_intAutoStopAlert == 1)
            {
                m_blAutoStopAlert = true;
            }
            else
            {
                m_blAutoStopAlert = false;
            }
            m_intParm1068 = p_intParm1068;
        }

        private string GetDOCTORGROUPID()
        {
            string m_strGroupID = "";
            DataTable dtbResult = new DataTable();
            long m_lngRet = 0;

            com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc EmpSvc =
                                                           (com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc));

            m_lngRet = EmpSvc.m_lngGetGroupEmp(this.LoginInfo.m_strEmpID, out dtbResult);
            if (m_lngRet > 0 && dtbResult.Rows.Count > 0)
            {
                m_strGroupID = dtbResult.Rows[0]["groupid_chr"].ToString().Trim();
            }
            return m_strGroupID;

        }

        private void frmBIHOrderInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //处方权
            if (m_blAccess == false)
            {

                return;
            }
            //组合快捷键
            if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        if (m_ctlOrderDetail.m_dtFinishTime2.Enabled == true)
                        {
                            m_ctlOrderDetail.m_dtFinishTime2.Text = DateTime.Now.ToString("yyyy年MM月dd日HH时") + "00分";
                        }
                        break;
                    case Keys.S:
                        if (m_ctlOrderDetail.m_dtFinishTime2.Enabled == true)
                        {
                            m_ctlOrderDetail.m_dtFinishTime2.Text = "";
                        }
                        break;
                    case Keys.Q://复制当前所有医嘱到组套模板
                        // m_mnuCopytoFoAll();
                        break;
                }
            }
            else if (e.Modifiers == Keys.Control)
            {

                switch (e.KeyCode)
                {
                    case Keys.P://打印医嘱 [Ctrl + P] 
                        if (cmdPrintOrder.Enabled && cmdPrintOrder.Visible)
                        {
                            cmdPrintOrder_Click(sender, e);
                        }
                        break;
                    case Keys.D0:
                        this.m_cboOrderList.SelectedIndex = 10;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D1:
                        this.m_cboOrderList.SelectedIndex = 1;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D2:
                        this.m_cboOrderList.SelectedIndex = 2;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D3:
                        this.m_cboOrderList.SelectedIndex = 3;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D4:
                        this.m_cboOrderList.SelectedIndex = 4;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D5:
                        this.m_cboOrderList.SelectedIndex = 5;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D6:
                        this.m_cboOrderList.SelectedIndex = 6;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D7:
                        this.m_cboOrderList.SelectedIndex = 7;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D8:
                        this.m_cboOrderList.SelectedIndex = 8;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.D9:
                        this.m_cboOrderList.SelectedIndex = 9;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;

                    case Keys.Oemplus:
                        this.m_rdoAllDay.Checked = true;
                        break;

                    case Keys.OemMinus:
                        this.m_rdoToday.Checked = true;
                        break;

                    case Keys.Oemtilde:
                        this.m_cboOrderList.SelectedIndex = 0;
                        m_cboOrderList_SelectionChangeCommitted(null, null);
                        break;
                    case Keys.M:
                        this.m_cmdChange_Click(null, null);
                        break;
                    case Keys.X://停止(&X)
                        this.m_cmdStop_Click(null, null);
                        break;
                    case Keys.A://提交(&A)
                        this.m_cmdToCommit_Click(null, null);
                        break;
                    //case Keys.S://重整(&S)
                    //    this.m_cmdRetract_Click(null, null);
                    //    break;
                    //case Keys.C://复制(&C)
                    //    //this.m_cmdChange_Click(null, null);
                    //    if (this.m_dtvOrder.Focus())
                    //    {
                    //        if (m_MenuCopy.Enabled == true)
                    //        {
                    //            m_MenuCopy_Click(null, null);
                    //        }
                    //    }
                    //    break;
                    //case Keys.V://粘贴(&V)
                    //    //this.m_cmdChange_Click(null, null);
                    //    if (this.m_dtvOrder.Focus())
                    //    {
                    //        if (m_MenuPase.Enabled == true)
                    //        {
                    //            m_MenuPase_Click(null, null);
                    //        }
                    //    }
                    //    break;
                    case Keys.W://新开医嘱费用统计
                        m_cmdMoneyCount_Click(null, null);
                        break;
                    case Keys.Q://生成组套
                        CopytoGroup();
                        break;
                    case Keys.S://病人报告查询
                        m_MenuSeeBill_Click(null, null);
                        break;
                }

            }
            else
            {
                switch (e.KeyCode)
                {
                    #region 快捷键
                    case Keys.Escape:
                        //帮助的关闭
                        if (this.label13.Visible == true)
                        {
                            this.label13.Visible = false;
                            break;
                        }
                        /*<=================*/
                        if (pnSel.Visible == true)
                        {
                            if (fo.Visible)
                            {
                                lblBoard_Click(null, null);

                            }
                            else if (m_lsvToolTip.Visible)
                            {
                                lbePriceInfo_Click(null, null);
                            }
                            else if (fl.Visible)
                            {
                                lblLeft_Click(null, null);
                            }
                            break;
                        }
                        if (m_cmdClose.Enabled && m_cmdClose.Visible)
                        {
                            //if(ActiveControl.ToString()!=m_dtgOrder.ToString())
                            m_cmdClose_Click(null, null);
                        }
                        break;
                    case Keys.F1://显示帮助
                        if (this.label13.Visible == false)
                        {
                            this.label13.Show();
                        }

                        break;
                    case Keys.F2://添加
                        if (m_cmdAdd.Enabled && m_cmdAdd.Visible)
                        {
                            m_cmdAdd_Click(sender, e);
                        }
                        break;

                    case Keys.F12://保存
                        if (m_cmdSave.Enabled && m_cmdSave.Visible)
                        {
                            m_cmdSave_Click(sender, e);
                        }
                        break;
                    case Keys.F4://使用法输入控件可用
                        //if (m_cobOrderCate.SelectedIndex < m_cobOrderCate.Items.Count - 1)
                        //{
                        //    m_cobOrderCate.SelectedIndex = m_cobOrderCate.SelectedIndex + 1;
                        //}
                        //else
                        //{
                        //    m_cobOrderCate.SelectedIndex = 0;
                        //}
                        // this.m_ctlOrderDetail.m_lblDosageType_Click(null, null);
                        break;
                    case Keys.F5://更改查询码方式
                        if (seachClass.SelectedIndex < seachClass.Items.Count - 1)
                        {
                            seachClass.SelectedIndex = seachClass.SelectedIndex + 1;
                        }
                        else
                        {
                            seachClass.SelectedIndex = 0;
                        }
                        break;
                    case Keys.F6://删除
                        //if (this.m_dtvOrder.SelectedRows.Count <= 0)
                        //{
                        //    MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        //clsBIHOrder BihOrder = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
                        //if (BihOrder != null && (BihOrder.m_intStatus == 0 || BihOrder.m_intStatus == 7))
                        //{
                        //    m_cmdDelete_Click(sender, e);
                        //}
                        //else if ((BihOrder.m_intStatus == 1))//作废
                        //{
                        //    m_cmdBlankOut_Click(sender, e);
                        //}
                        m_cmdDelete2_Click(null, null);
                        break;

                    case Keys.F7://停止 取系统时间
                        if (m_cmdStop.Enabled && m_cmdStop.Visible)
                        {
                            m_cmdStop_Click(sender, e);
                        }
                        break;
                    case Keys.F8://停止 人工输入时间
                        if (m_objCurrentOrder != null && (m_objCurrentOrder.m_intStatus == 2))
                        {
                            m_ctlOrderDetail.m_dtFinishTime2.Enabled = true;
                            m_ctlOrderDetail.m_dtFinishTime2.Focus();
                        }
                        break;
                    case Keys.F9://添加
                        m_mthShowMedicineInfo();
                        break;
                    case Keys.F10://刷新
                        //显示医嘱费用
                        //刷新
                        if (cmdRefurbish.Enabled && cmdRefurbish.Visible)
                        {
                            cmdRefurbish_Click(sender, e);
                        }
                        break;
                        //暂时注释 2005-10-11 by gphuang
                        //					if(m_IsDisPlayToolTip)
                        //					{
                        //						#region Label 控件
                        //						//						m_lblToolTip.Visible =false;
                        //						//						m_IsDisPlayToolTip =false;
                        //						//						m_strToolTip ="";
                        //						#endregion
                        //						#region ListView 控件
                        //						m_lsvToolTip.Visible =false;
                        //						m_IsDisPlayToolTip =false;
                        //						#endregion
                        //					}
                        //					else
                        //					{
                        //						if(m_objCurrentOrder!=null)
                        //						{
                        //							DisplayToolTip(new Point(100,m_poToolTip.Y));
                        //						}
                        //						m_IsDisPlayToolTip =true;
                        //					}
                        break;

                    case Keys.F11:
                        lblLeft_Click(null, null);
                        break;

                    case Keys.PageUp:
                        if (this.m_dtvOrder.SelectedRows.Count > 0)
                        {
                            if (this.m_dtvOrder.SelectedRows[0].Index > 0)
                            {
                                this.m_dtvOrder.Rows[this.m_dtvOrder.SelectedRows[0].Index - 1].Selected = true;
                                m_dtgOrder_m_evtCurrentCellChanged(null, null);

                            }
                        }
                        break;
                    case Keys.PageDown:
                        if (this.m_dtvOrder.SelectedRows.Count > 0)
                        {
                            if (this.m_dtvOrder.SelectedRows[0].Index < this.m_dtvOrder.RowCount - 1)
                            {
                                this.m_dtvOrder.Rows[this.m_dtvOrder.SelectedRows[0].Index + 1].Selected = true;
                                m_dtgOrder_m_evtCurrentCellChanged(null, null);

                            }
                        }
                        break;
                    #endregion
                }

            }
        }

        #region 显示药品详细信息
        /// <summary>
        /// 关联药品基本信息表和药典表显示药品的信息。弹出一个窗口显示
        /// </summary>
        private void m_mthShowMedicineInfo()
        {
            // 1 西药 2 中药 3 检验
            clsBIHOrder order;
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
            }
            else
            {
                return;
            }
            clsDcl_DoctorWorkstation objSvc = new clsDcl_DoctorWorkstation();
            int Flag = 0;
            string strText = "";
            string strRemark = "";
            string ID = order.m_strCHARGEITEMID_CHR;
            if (m_objSpecateVo.m_strORDERCATEID_MEDICINE_CHR.Trim().Equals(order.m_strOrderDicCateID.Trim()))//西药判断
            {
                Flag = 1;
            }
            else if (m_objSpecateVo.m_strMID_MEDICINE_CHR.Trim().Equals(order.m_strOrderDicCateID.Trim()))//中药判断
            {
                Flag = 2;
            }
            else if (m_objSpecateVo.m_strORDERCATEID_LIS_CHR.Trim().Equals(order.m_strOrderDicCateID.Trim()))//检验判断
            {
                Flag = 3;
            }
            if (Flag == 1 || Flag == 2)
            {
                objSvc.m_mthGetMedicineInfo(ID, out strText, out strRemark);
            }
            else if (Flag == 3)
            {
                DataTable dt;
                long l = objSvc.m_lngGetLisItemClinicMeaning(ID, out dt);
                if (l > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strText += "【" + dt.Rows[i]["check_item_name_vchr"].ToString().Trim() + "】 " + dt.Rows[i]["clinic_meaning_vchr"].ToString().Trim() + "\r\n\r\n";
                    }
                }
            }

            frmMedicineInfo obj = new frmMedicineInfo();
            obj.SetText = strText;
            obj.ShowDialog();
        }
        #endregion

        #region 生成组套
        /// <summary>
        /// 生成组套 当前界面所有医嘱
        /// </summary>
        private void CopytoGroup()
        {
            ArrayList m_arrBihOrder = null;

            if (this.m_dtvOrder.RowCount > 0)
            {
                m_arrBihOrder = new ArrayList();
                for (int i = 0; i < m_dtvOrder.RowCount; i++)
                {
                    //医嘱类型为文字医嘱或为特殊医嘱的不允许生成
                    clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                    if (!CanCopyToGroup(order))
                    {
                        continue;
                    }
                    m_arrBihOrder.Add((clsBIHOrder)m_dtvOrder.Rows[i].Tag);
                }

            }
            if (m_arrBihOrder.Count > 0)
            {
                frmOrderTemplate_Group_Add m_frmGroupAdd = new frmOrderTemplate_Group_Add((clsBIHOrder[])(m_arrBihOrder.ToArray(typeof(clsBIHOrder))), m_htOrderCate, m_objSpecateVo);
                m_frmGroupAdd.ShowDialog();
            }

        }

        public bool CanCopyToGroup(clsBIHOrder order)
        {
            bool m_blCan = true;
            //医嘱类型为特殊医嘱的不允许生成
            if (order.m_intTYPE_INT != 0)
            {
                m_blCan = false;
            }
            /*<==============================*/
            return m_blCan;
        }

        /// <summary>
        /// 生成组套 当前界面选中的医嘱
        /// </summary>
        private void CopySelectItemtoGroup()
        {

            ArrayList m_arrBihOrder = GetTheSelectItemWithSon();

            frmOrderTemplate_Group_Add m_frmGroupAdd = new frmOrderTemplate_Group_Add((clsBIHOrder[])(m_arrBihOrder.ToArray(typeof(clsBIHOrder))), m_htOrderCate, m_objSpecateVo);
            m_frmGroupAdd.m_htOrderCate = m_htOrderCate;
            m_frmGroupAdd.ShowDialog();
        }
        #endregion

        private void m_cmdToCommit_Click(object sender, System.EventArgs e)
        {
            if (this.m_ctlPatient.m_txtDiagnose.Text.Trim() == string.Empty)
            {
                MessageBox.Show("病人诊断不能为空，请填写。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_ctlPatient.m_txtDiagnose.Focus();
                return;
            }
            m_objDomain.m_mthShowCommitForm();
        }

        private void m_ctxOtherBill_Popup(object sender, System.EventArgs e)
        {
            m_objDomain.m_ctxOtherBill_Popup(m_ctxOtherBill);
        }

        private void m_lblOtherBill_Click(object sender, System.EventArgs e)
        {
            m_objDomain.m_lblOtherBill_Click(sender, e);
        }

        private void m_cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void m_ctlOrderDetail_m_evtInputEnd(object sender, System.EventArgs e)
        {
            m_cmdSave.Focus();
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="strMessage">显示内容串</param>
        internal void m_mthShowMessage(string strMessage)
        {
            MessageBox.Show(this, strMessage, "医嘱管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 更新菜单状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_ctxGridMenu_Popup(object sender, System.EventArgs e)
        {
            m_mnuBlankOut.Enabled = false;
            m_mnuDelete.Enabled = false;
            m_mnuStop.Enabled = false;
            m_mnuRetract.Enabled = false;
            m_mnuCommitAll.Enabled = false;

            if (m_objDomain.m_blnExistCurrentOrder())
            {
                int intStatus = m_objCurrentOrder.m_intStatus;
                int intType = m_objCurrentOrder.m_intExecuteType;
                switch (intStatus)
                {
                    case 0:
                        m_mnuDelete.Enabled = true;
                        break;
                    case 1:
                        m_mnuBlankOut.Enabled = true;
                        break;
                    case 2:
                        m_mnuStop.Enabled = true;
                        m_mnuRetract.Enabled = true;
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                m_mnuCommitAll.Enabled = true;
            }
            else
            {
                m_mnuCommitAll.Enabled = true;
            }
        }

        public void cmdRefurbish_Click(object sender, System.EventArgs e)
        {
            //m_objDomain.m_mthLoadOrderList();
            //刷新病人数据
            m_ctlPatient.m_mthGetPatientByAreaBed();
            //清空缓存数据
            m_objDomain.m_ClearBuffer();
        }

        #endregion
        #region 病人改变时,加载医嘱
        private void ctlBIHPatientInfo1_m_evtPatientChanged(object sender, System.EventArgs e)
        {
            m_objDomain.HintInfo();
            m_objDomain.m_mthLoadOrderList();
        }

        #endregion
        #region 增加,修改
        /// <summary>
        /// 新增,仅清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void m_cmdAdd_Click(object sender, System.EventArgs e)
        {
            // 当前是否已选定病人
            if (m_ConfirmPatient() == 0)
            {
                return;
            }
            m_ctlOrderDetail.m_lblSaveOrderID.Text = "医嘱内容";
            m_ctlOrderDetail.m_txtOrderName2.ReadOnly = true;
            m_ctlOrderDetail.m_dtStartTime2.Text = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分");
            m_ctlOrderDetail.m_dtFinishTime2.Text = "";
            m_objCurrentOrder = null;
            m_intCurrentRow = -1;
            //初始化医嘱输入界面
            //m_ctlOrderDetail.EmptyInput();
            //显示医嘱明细界面信息
            m_mthShowCurrentOrder(m_objCurrentOrder);

            m_ctlOrderDetail.IsSubOrder = false;//子医嘱标志
            m_ctlOrderDetail.ParentOrder = null;
            /*<===================================*/
            m_ctlOrderDetail.m_mthStartInput();
            if (m_objCurrentDoctor != null)
            {
                m_ctlOrderDetail.m_mthSetDoctor(m_objCurrentDoctor.m_strDoctorID, m_objCurrentDoctor.m_strDoctorName);
            }
            //医嘱类型改变时的控制(长嘱/临嘱/出院带药)
            int m_intExecuteType = clsConverter.ToInt(m_ctlOrderDetail.m_cboExecuteType.m_strGetID(m_ctlOrderDetail.m_cboExecuteType.SelectedIndex));
            m_ctlOrderDetail.m_cboExecuteTypeChanged(m_intExecuteType);
            m_cmdSave.Enabled = true;

            m_ctlOrderDetail.m_txtSample.Enabled = true;
            m_ctlOrderDetail.m_txtCheck.Enabled = true;

            // 设置方号
            if (this.m_dtvOrder.RowCount > 0)
            {
                m_ctlOrderDetail.m_txtRecipeNo.Text = m_objDomain.m_intBigRecipeNo.ToString();
            }
            // 设置默认病人的主治医生
            if (m_ctlPatient.m_objPatient != null)
            {
                m_ctlOrderDetail.m_txtDoctorList.Tag = m_ctlPatient.m_objPatient.m_strDOCTORID_CHR;
                m_ctlOrderDetail.m_txtDoctorList.Text = m_ctlPatient.m_objPatient.m_strDOCTOR_VCHR;
            }
            m_objDomain.m_SetDisplayOrderEditState(1);
        }

        #region 是否儿童.是则采用儿童价格
        /// <summary>
        /// 是否儿童.是则采用儿童价格
        /// </summary>
        internal bool IsChildPrice
        {
            get
            {
                if (m_ctlPatient.m_objPatient == null)
                {
                    return false;
                }
                else
                {
                    return new clsBrithdayToAge().IsChild(m_ctlPatient.m_objPatient.m_dtBorn);
                }
            }
        }
        #endregion

        #region 界面操作条件判断

        // 当前是否已选定病人
        /// <summary>
        /// 当前是否已选定病人
        /// </summary>
        /// <returns>0-无病人,1－有病人</returns>
        public int m_ConfirmPatient()
        {
            int m_intP = 1;
            if (m_ctlPatient.m_objPatient == null)
            {
                m_mthShowMessage("请先指定病人!");
                m_intP = 0;
                m_ctlPatient.Focus();

            }
            return m_intP;
        }

        // 当前是否已选定医嘱－如果没有，则选当前最后一条。
        /// <summary>
        /// 当前是否已选定医嘱
        /// </summary>
        /// <returns>0-无选定,1－有选定</returns>
        public int m_ConfirmHaveOrder()
        {
            int m_intP = 1;

            if (this.m_dtvOrder.RowCount <= 0)
            {
                m_mthShowMessage("请选定医嘱!");
                m_intP = 0;

            }
            else
            {
                if (this.m_dtvOrder.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请先选择一条医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_intP = 0;
                }
            }
            return m_intP;
        }
        #endregion

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.m_ctlPatient.m_txtDiagnose.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("病人诊断不能为空，请填写。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_ctlPatient.m_txtDiagnose.Focus();
                    return;
                }
                if (this.m_ctlOrderDetail.cboKJ.Enabled && this.m_ctlOrderDetail.cboKJ.SelectedIndex == 0)
                {
                    MessageBox.Show("抗菌药物必须选择用途.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_ctlOrderDetail.cboKJ.Focus();
                    return;
                }

                m_cmdSave.Enabled = false;
                if (m_ConfirmPatient() == 0)
                {
                    return;
                }
                ////医保病人: 超额时不能录入，需要重新设定该病人费用下限。
                //if(m_blnISMedicareMan)
                //{
                //    double dblPrePayMoney =0;
                //    double dblLIMITRATE_MNY =m_ctlPatient.m_objPatient.m_dblLIMITRATE_MNY;
                //    try{dblPrePayMoney =double.Parse(m_ctlPatient.m_txtPrePayMoney.Text.ToString());}
                //    catch{}

                //    if(dblLIMITRATE_MNY>dblPrePayMoney)
                //    {
                //        MessageBox.Show("预交金余额,超过费用下限,不能开医嘱！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                //连续性验证
                //if(this.m_ctlOrderDetail.m_txtExecuteFreq.Tag==null) this.m_ctlOrderDetail.m_txtExecuteFreq.Tag ="";
                //if(!m_objDomain.PassConOrder(this.m_ctlOrderDetail.m_txtExecuteFreq.Tag.ToString())) 
                //{
                //    return;
                //}
                // 医嘱数据录入检查
                if (!CheckTheOrderDetailData())
                {
                    return;
                }
                bool IsSubOrder = m_ctlOrderDetail.m_txtFatherOrder.Text.Trim() != "";
                int intParentIndex = -1;
                if (IsSubOrder)
                {
                    intParentIndex = (int)m_lngGetParentOrderIndex(m_objCurrentOrder.m_intRecipenNo.ToString().Trim());
                }
                this.Cursor = Cursors.WaitCursor;
                int iSaveRes = 0;
                //新增或修改后的医嘱流水号
                ArrayList m_arrOrderId = new ArrayList();
                try
                {
                    m_objDomain.m_mthSave(out iSaveRes, ref m_arrOrderId);
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (iSaveRes < 0)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                this.m_objDomain.m_mthLoadOrderList();
                this.Cursor = Cursors.Default;

                m_ctlOrderDetail.m_txtExecuteFreq.Enabled = true;
                m_ctlOrderDetail.m_txtExecuteFreq.BackColor = Color.White;
                m_ctlOrderDetail.m_txtDosageType.Enabled = true;
                m_ctlOrderDetail.m_txtDosageType.BackColor = Color.White;

                this.Cursor = Cursors.Default;
            }
            finally
            {
                m_cmdSave.Enabled = true;
            }
        }

        public bool CheckTheOrderDetailData()
        {
            #region 医嘱名称
            if (this.m_ctlOrderDetail.m_txtOrderName2.Tag == null)
            {
                MessageBox.Show("请先输入医嘱", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_ctlOrderDetail.m_txtOrderName.Focus();
                return false;
            }
            if (this.m_ctlOrderDetail.m_txtOrderName.Text.Trim().Equals(""))
            {
                MessageBox.Show("请先输入医嘱", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_ctlOrderDetail.m_txtOrderName.Focus();
                return false;
            }
            #endregion

            #region 剂量必须大于0
            double dbl1 = -1;
            if (m_ctlOrderDetail.m_txtDosage.Enabled == true && m_ctlOrderDetail.m_txtDosage.Visible == true)
            {
                try
                {
                    dbl1 = double.Parse(m_ctlOrderDetail.m_txtDosage.Text.Trim());
                }
                catch
                {

                }

                if (dbl1 <= 0)
                {
                    MessageBox.Show("剂量必须大于0！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_ctlOrderDetail.m_txtDosage.Focus();
                    return false;
                }
            }
            #endregion

            #region 用法
            if (m_ctlOrderDetail.m_txtDosageType.Enabled == true && m_ctlOrderDetail.m_txtDosageType.Visible == true)
            {
                if (m_ctlOrderDetail.m_txtDosageType.Tag == null)
                {
                    MessageBox.Show("用法不能为空！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    m_ctlOrderDetail.m_txtDosageType.Focus();
                    return false;
                }
                else if (((string)m_ctlOrderDetail.m_txtDosageType.Tag).Equals("") || m_ctlOrderDetail.m_txtDosageType.Text.Trim().Equals(""))
                {
                    MessageBox.Show("用法不能为空！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    m_ctlOrderDetail.m_txtDosageType.Focus();
                    return false;
                }
            }
            #endregion

            #region 领量必须大于0
            /*
            dbl1 = -1;
            if (m_ctlOrderDetail.m_txtGet.Enabled == true)
            {
                try
                {
                    dbl1 = double.Parse(m_ctlOrderDetail.m_txtGet.Text.Trim());
                }
                catch
                {

                }

                if (dbl1 <= 0)
                {
                    MessageBox.Show("领量必须大于0！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    m_ctlOrderDetail.m_txtGet.Focus();
                    return false;
                }
            }
             */
            #endregion

            #region 长嘱的开始时间不能为空
            /*
            if(int.Parse(m_ctlOrderDetail.m_cboExecuteType.m_strGetID(m_ctlOrderDetail.m_cboExecuteType.SelectedIndex))==1)
            {
             
                try
                {
                 DateTime dt=Convert.ToDateTime( m_ctlOrderDetail.m_dtStartTime2.Text.Trim());
                }
                catch
                {
                  MessageBox.Show("请输入开始日期", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                m_ctlOrderDetail.m_dtStartTime2.Focus();
                return false;
                }
             
            }
             */
            #endregion

            #region 主治医生
            /*
            if(m_ctlOrderDetail.m_txtDoctorList.Tag==null||((string)m_ctlOrderDetail.m_txtDoctorList.Tag).Equals("")||m_ctlOrderDetail.m_txtDoctorList.Text.Trim().Equals(""))
            {
                  MessageBox.Show("主治医生不能为空", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                m_ctlOrderDetail.m_txtDoctorList.Focus();
                return false;
              
            }
             */
            #endregion

            #region 频率
            string freqId = string.Empty;
            if (m_ctlOrderDetail.m_txtExecuteFreq.Enabled == true && m_ctlOrderDetail.m_txtExecuteFreq.Visible == true)
            {
                if (m_ctlOrderDetail.m_txtExecuteFreq.Tag == null)
                {
                    MessageBox.Show("频率不能为空", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_ctlOrderDetail.m_txtExecuteFreq.Focus();
                    return false;
                }
                else if (((string)m_ctlOrderDetail.m_txtExecuteFreq.Tag).Equals("") || m_ctlOrderDetail.m_txtExecuteFreq.Text.Trim().Equals(""))
                {
                    MessageBox.Show("频率不能为空", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    m_ctlOrderDetail.m_txtExecuteFreq.Focus();
                    return false;
                }
                freqId = clsConverter.ToString(m_ctlOrderDetail.m_txtExecuteFreq.Tag);
            }
            #endregion

            #region 天数必须大于0
            dbl1 = -1;
            if (m_ctlOrderDetail.m_txtDays.Enabled == true && m_ctlOrderDetail.m_txtDays.Visible == true)
            {
                try
                {
                    dbl1 = double.Parse(m_ctlOrderDetail.m_txtDays.Text.Trim());
                }
                catch
                {
                }
                if (dbl1 <= 0)
                {
                    MessageBox.Show(m_ctlOrderDetail.m_lblDay.Text + "数不能为空!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_ctlOrderDetail.m_txtDays.Focus();
                    return false;
                }

                //医保病人出院带药所开的天数不能超过7天
                if (this.m_ctlOrderDetail.m_cboExecuteType.SelectedIndex == 2)
                {
                    if (m_lstSocialSecurity.Contains(m_ctlPatient.m_objPatient.m_strPayTypeID))
                    {
                        if (dbl1 > 7)
                        {
                            MessageBox.Show("该病人为" + m_ctlPatient.m_objPatient.m_strPayTypeName + "身份，出院带药不能超过7天!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            m_ctlOrderDetail.m_txtDays.Focus();
                            return false;

                        }
                    }
                }
            }
            #endregion

            #region 疗程用药天数

            //if (this.m_ctlOrderDetail.txtCureDays.Enabled && this.m_ctlOrderDetail.txtCureDays.Text.Trim() != "")
            //{
            //    int days = Convert.ToInt32(this.m_ctlOrderDetail.txtCureDays.Text.Trim());
            //    if (days > 0)
            //    {
            //        if (string.IsNullOrEmpty(freqId))
            //        {
            //            MessageBox.Show("频率不能为空");
            //            this.m_ctlOrderDetail.txtCureDays.Focus();
            //            return false;
            //        }
            //        using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
            //        {
            //            DataTable dt = svc.GetFreqDict(freqId);
            //            if (dt != null && dt.Rows.Count == 1)
            //            {
            //                int freqDay = dt.Rows[0]["days_int"] == DBNull.Value ? 1 : Convert.ToInt32(dt.Rows[0]["days_int"]);
            //                if (freqDay == 0) freqDay = 1;
            //                int mod = days % freqDay;
            //                if (mod != 0)
            //                {
            //                    MessageBox.Show("疗程天数必须是频率天数的倍数");
            //                    this.m_ctlOrderDetail.txtCureDays.Focus();
            //                    return false;
            //                }
            //            }
            //        }
            //        if (days > 15)
            //        {
            //            MessageBox.Show("疗程天数不能大于15天");
            //            this.m_ctlOrderDetail.txtCureDays.Focus();
            //            return false;
            //        }
            //    }
            //}
            #endregion

            return true;
        }
        #endregion

        #region 提交所有医嘱
        private void m_mnuCommitAll_Click(object sender, System.EventArgs e)
        {
            this.m_cmdToCommit_Click(sender, e);
        }

        private void m_cmdCommitAll_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(this, "是否提交所有新建医嘱?", "提交医嘱", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            m_objDomain.m_mthCommitAll();
        }
        #endregion
        #region 停止医嘱
        private void m_mnuStop_Click(object sender, System.EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count <= 0)
            {
                m_mthShowMessage("请先选择医嘱!");
                return;
            }
            m_lngStopOrder();
        }

        public void m_cmdStop_Click(object sender, System.EventArgs e)
        {
            if (m_ConfirmHaveOrder() == 0)
            {
                return;
            }

            m_lngStopOrder();
            //按Ctrl键打开新页面重整
            //if(System.Windows.Forms.Control.ModifierKeys==Keys.Control || System.Windows.Forms.Control.ModifierKeys==Keys.ControlKey)
            //{
            //    clsBIHPatientInfo objPatient =m_ctlPatient.m_objPatient;
            //    if(objPatient!=null)
            //    {	
            //        string strRegisterID =objPatient.m_strRegisterID;
            //        frmReformingOrder objfrmReformingOrder =new frmReformingOrder(strRegisterID,3);
            //        objfrmReformingOrder.m_txbPatientName.Text =m_ctlPatient.m_objPatient.m_strPatientName;
            //        objfrmReformingOrder.ShowDialog();
            //        //刷新数据
            //        m_objDomain.m_mthLoadOrderList();
            //    }
            //}
            //else
            //{
            //    //单条停止
            //    if (this.m_dtvOrder.SelectedRows.Count <= 0)
            //    {
            //        m_mthShowMessage("请先选择医嘱!");
            //        return;
            //    }
            //    clsBIHOrder BihOrder = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
            //    m_objDomain.m_mthStopCurrentOrder(true, BihOrder);

            //}
        }
        #endregion
        #region 重整医嘱
        private void m_mnuRetract_Click(object sender, System.EventArgs e)
        {
            m_cmdRetract_Click(sender, e);
            //m_objDomain.m_mthRetractCurrentOrder(false);
        }

        private void m_cmdRetract_Click(object sender, System.EventArgs e)
        {
            if (m_ConfirmHaveOrder() == 0)
            {
                return;
            }
            //按Ctrl键打开新页面重整
            //if(System.Windows.Forms.Control.ModifierKeys==Keys.Control || System.Windows.Forms.Control.ModifierKeys==Keys.ControlKey)
            //{
            clsBIHPatientInfo objPatient = m_ctlPatient.m_objPatient;
            if (objPatient != null)
            {
                string strRegisterID = objPatient.m_strRegisterID;
                frmReformingOrder objfrmReformingOrder = new frmReformingOrder(strRegisterID, 4, this.IsChildPrice);
                objfrmReformingOrder.m_txbPatientName.Text = m_ctlPatient.m_objPatient.m_strPatientName;
                objfrmReformingOrder.ShowDialog();
                //刷新数据
                m_objDomain.m_mthLoadOrderList();
            }
            //}
            //else
            //{
            //单条重整
            //m_objDomain.m_mthRetractCurrentOrder(true);
            //}
        }
        #endregion
        #region 作废医嘱
        private void m_mnuBlankOut_Click(object sender, System.EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count <= 0)
            {

                MessageBox.Show("请先选择一条医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //m_objDomain.m_mthBlankOutCurrentOrder(true,(clsBIHOrder) this.m_dtvOrder.SelectedRows[0].Tag);
            m_lngBlankOut();
        }

        private void m_cmdBlankOut_Click(object sender, System.EventArgs e)
        {
            if (m_ConfirmHaveOrder() == 0)
            {
                return;
            }
            clsBIHOrder BihOrder = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;

            if (BihOrder.m_strCreatorID == this.LoginInfo.m_strEmpID || BihOrder.m_strDOCTORID_CHR == this.LoginInfo.m_strEmpID)
            {

            }
            else
            {
                MessageBox.Show("只能作废录入员是自己或开方医生是自己的医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            m_objDomain.m_mthBlankOutCurrentOrder(true, BihOrder);
        }

        #endregion
        #region 删除医嘱
        private void m_cmdDelete_Click(object sender, System.EventArgs e)
        {

            if (m_ConfirmHaveOrder() == 0)
            {
                return;
            }
            clsBIHOrder BihOrder = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
            if (BihOrder.m_strCreatorID == this.LoginInfo.m_strEmpID || BihOrder.m_strDOCTORID_CHR == this.LoginInfo.m_strEmpID)
            {

            }
            else
            {
                MessageBox.Show(" {当前医嘱：" + BihOrder.m_strName + "} " + "只能删除录入员是自己或开方医生是自己的医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            m_objDomain.m_mthDeleteCurrentOrder(true, BihOrder);
            this.alertLight1.m_mthClear();
            //医嘱类型改变时的控制(长嘱/临嘱/出院带药)
            m_ctlOrderDetail.m_cboExecuteType_SelectedIndexChanged(null, null);
            if (!m_ctlOrderDetail.IsSubOrder)
            {

                m_ctlOrderDetail.m_txtDosageType.Enabled = true;
                m_ctlOrderDetail.m_txtDosageType.BackColor = Color.White;
            }
        }

        private void m_mnuDelete_Click(object sender, System.EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //m_objDomain.m_mthDeleteCurrentOrder(true,(clsBIHOrder) this.m_dtvOrder.SelectedRows[0].Tag);		
            m_cmdDelete2_Click(null, null);

        }
        #endregion
        #region Grid
        /// <summary>
        /// 当前行
        /// </summary>
        internal int m_intCurrentRow = -1;
        private void m_dtgOrder_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            //作废及删除控制

            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                clsBIHOrder BihOrder = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
                if (m_blDoctorSign)
                {
                    if (BihOrder.SIGN_INT == 0)
                    {
                        this.m_dtvOrder.DefaultCellStyle.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        this.m_dtvOrder.DefaultCellStyle.SelectionForeColor = selectOldColor;
                    }
                }
                ///选中的方号列表为了同步选中
                ArrayList m_arrRecipenNo = new ArrayList();
                for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                    if (m_arrRecipenNo.Contains(order.m_intRecipenNo.ToString()) == false)
                    {
                        m_arrRecipenNo.Add(BihOrder.m_intRecipenNo.ToString());
                    }

                }
                for (int i = 0; i < this.m_dtvOrder.Rows.Count; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                    if (m_arrRecipenNo.Contains(order.m_intRecipenNo.ToString()))
                    {
                        this.m_dtvOrder.Rows[i].Selected = true;
                    }
                }
                /*<====================================*/
            }
            //刷新缓存的信息	{费用}
            if (m_lsvToolTip.Visible == true)
            {
                m_dtvOrder_CellMouseClick(null, null);
            }
        }

        public void CurrentBihOrderChanged()
        {
            // 检验值初始化
            m_ctlOrderDetail.m_blSampleItem = false;
            m_ctlOrderDetail.m_blCheckItem = false;
            m_ctlOrderDetail.m_lblDosageType.Visible = true;
            m_ctlOrderDetail.m_txtDosageType.Visible = true;
            this.m_txtBackReason.Visible = false;

            #region 医嘱明细显示
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                m_objCurrentOrder = this.m_dtvOrder.SelectedRows[0].Tag as clsBIHOrder;

                #region 刷新当前医嘱数据，然后再判断
                ArrayList m_arrORDERID_CHR = new ArrayList();
                m_arrORDERID_CHR.Add(m_objCurrentOrder.m_strOrderID);
                clsBIHOrder[] arrOrder = null;
                m_objService.m_lngGetArrOrderByOrderID(m_arrORDERID_CHR, out arrOrder);
                if (arrOrder != null && arrOrder.Length > 0)
                {
                    m_objCurrentOrder = arrOrder[0];
                    DataGridViewRow row = GetTheGridRowByOrder(m_objCurrentOrder.m_strOrderID);
                    this.m_objDomain.m_objGetDataViewRow(m_objCurrentOrder, row, row.Index + 1);
                    this.m_objDomain.m_mthRefreshSameReqNoColor();
                }
                else
                {
                    DataGridViewRow row = GetTheGridRowByOrder(m_objCurrentOrder.m_strOrderID);
                    m_dtvOrder.Rows.Remove(row);
                    MessageBox.Show("本条医嘱已不存在!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                if (!alertFromTheStatue(m_objCurrentOrder))
                {
                    m_objCurrentOrder = null;
                    return;
                }
                //初始化医嘱输入界面
                m_ctlOrderDetail.EmptyInput();

                //根据当前诊疗ID设置当前诊疗项目
                clsBIHOrderDic[] arrDic = null;
                m_objService.m_lngGetOrderDicByID(m_objCurrentOrder.m_strOrderDicID.ToString().Trim(), m_strMedDeptGross, out arrDic);
                if (arrDic.Length > 0)
                {
                    m_ctlOrderDetail.m_txtOrderName.Tag = arrDic[0];
                    m_objCurrentOrder.m_dmlDosageRate = arrDic[0].m_dmlDosageRate;
                    //记录该医嘱的药品库存量
                    this.m_fotOpcurrentgross_num = Convert.ToSingle(arrDic[0].m_dmlIPCURRENTGROSS_NUM);

                    //记录是否是药品标志 1是药品 2为材料
                    this.m_intITEMSRCTYPE_INT = arrDic[0].m_intITEMSRCTYPE_INT;
                    //修改医嘱标志
                    this.m_blIsChange = true;
                    m_objCurrentOrder.m_dmlPrice = arrDic[0].m_dmlPrice;
                    m_objCurrentOrder.m_dmlPACKQTY_DEC = arrDic[0].m_dmlPACKQTY_DEC;
                    m_objCurrentOrder.m_intIPCHARGEFLG_INT = arrDic[0].m_intIPCHARGEFLG_INT;
                    if (!m_ctlOrderDetail.m_htMEDICINEPREPTYPE.ContainsKey(arrDic[0].m_strOrderDicID))
                    {
                        m_ctlOrderDetail.m_htMEDICINEPREPTYPE.Add(arrDic[0].m_strOrderDicID, arrDic[0].m_strMEDICINEPREPTYPENAME_VCHR);
                    }
                }
                //显示医嘱明细界面信息
                m_mthShowCurrentOrder(m_objCurrentOrder);

                //显示费用信息 
                m_objDomain.m_DisPlayToolTipListView(m_objCurrentOrder, m_lsvToolTip);
                m_objDomain.SetButtonToEnable();
                //显示用药方式、显示剂量问题逻辑
                if (m_objCurrentOrder != null)
                {
                    m_ctlOrderDetail.IsSubOrder = false;
                    m_ctlOrderDetail.ParentOrder = null;
                    if (GetTheSameNoOrders(m_objCurrentOrder.m_intRecipenNo).Count > 1)
                    {
                        m_ctlOrderDetail.IsSubOrder = true;
                    }

                    clsT_aid_bih_ordercate_VO p_objItem;
                    string p_strOrdercateID = m_objCurrentOrder.m_strOrderDicCateID;
                    p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[p_strOrdercateID];

                    //启用医嘱录入界面控件
                    EnableTheBihDetailControl(true);
                    //医嘱录入方式界面控制
                    //m_ctlOrderDetail.m_cboExecuteTypeChanged();
                    m_ctlOrderDetail.m_cboExecuteType_SelectedIndexChanged(null, null);
                    //医嘱类型界面控制
                    m_ctlOrderDetail.OrdercateLogic(p_objItem);
                    //医嘱特殊界面控制(如频率是否可以修改)
                    m_ctlOrderDetail.OrderSpecialLogic(m_objCurrentOrder);
                    //新价表逻辑
                    if (m_ctlOrderDetail.m_txtOrderName.Tag is clsBIHOrderDic)
                    {
                        clsBIHOrderDic m_objDic = (clsBIHOrderDic)m_ctlOrderDetail.m_txtOrderName.Tag;
                        if (m_objDic.m_intCheckTypeID != -1 && m_objDic.m_strCheckType.Trim().Length > 0 && m_objDic.m_intDELETED == 0)
                        {
                            m_ctlOrderDetail.m_blCheckItem = true;
                        }
                        else
                        {
                            m_ctlOrderDetail.m_blCheckItem = false;
                        }
                        //新价类检查控制逻辑--检验申请单元逻辑
                        if (!m_objDic.m_strLISAPPLYUNITID_CHR.Trim().Equals("") && m_objDic.m_strOrderCateID.Trim().Equals(m_objSpecateVo.m_strORDERCATEID_LIS_CHR.Trim()))
                        {
                            m_ctlOrderDetail.m_blSampleItem = true;
                        }
                        else
                        {
                            m_ctlOrderDetail.m_blSampleItem = false;
                        }
                    }
                    //连续性医嘱界面控制
                    if (m_objSpecateVo.m_strCONFREQID_CHR.Trim().Equals(m_objCurrentOrder.m_strExecFreqID.Trim()))
                    {
                        m_ctlOrderDetail.m_txtDosageControl(false);
                        m_ctlOrderDetail.m_txtDosageTypeControl(false);
                    }
                    //同方医嘱修改时的界面控制
                    bool m_blParentOrder, m_blSubOrder;
                    TheChangedOrderParentOrSub(m_objCurrentOrder, out m_blParentOrder, out m_blSubOrder);
                    if (m_blParentOrder == false && m_blSubOrder == true)
                    {
                        //启用或禁用 子医嘱录入界面的控件
                        EnableTheBihDetailControl(false);
                    }
                    m_objDomain.m_SetDisplayOrderEditState(2);
                }
            }
            #endregion
            // 检验控制
            m_ctlOrderDetail.setTheSampleBox();
            // 检查控制
            m_ctlOrderDetail.setTheCheckBox();
            // 适应症
            string strShiying = string.Empty;
            long lngRes1 = this.m_objDomain.m_lngGetShiying(m_objCurrentOrder.m_strOrderID, m_objCurrentOrder.m_strCHARGEITEMID_CHR, out strShiying);
            if (lngRes1 > 0)
            {
                if (strShiying == "3")
                {
                    m_ctlOrderDetail.cboShiying.SelectedIndex = 1;
                }
                else
                {
                    m_ctlOrderDetail.cboShiying.SelectedIndex = 0;
                }
            }

            //if (m_ctlOrderDetail.txtCureDays.Text.Trim() != "") m_ctlOrderDetail.txtCureDays.Enabled = true;
            if (m_ctlOrderDetail.cboEmer.SelectedIndex > 0) m_ctlOrderDetail.cboEmer.Enabled = true;
            if (m_ctlOrderDetail.cboKJ.SelectedIndex > 0) m_ctlOrderDetail.cboKJ.Enabled = true;
            if (m_ctlOrderDetail.cboQK.SelectedIndex > 0) m_ctlOrderDetail.cboQK.Enabled = true;
            if (m_ctlOrderDetail.cboProxyBoil.SelectedIndex > 0) m_ctlOrderDetail.cboProxyBoil.Enabled = true;
        }

        /// <summary>
        /// 禁止医嘱输入界面控件
        /// </summary>
        public void DeableTheDetailControl()
        {
            //初始化界面控件
            m_ctlOrderDetail.m_cboExecuteType.Enabled = false;
            m_ctlOrderDetail.m_txtRecipeNo.Enabled = false;
            m_ctlOrderDetail.m_txtOrderName.Enabled = false;
            m_ctlOrderDetail.m_txtOrderName2.Enabled = false;
            m_ctlOrderDetail.m_txtDosage.Enabled = false;
            m_ctlOrderDetail.m_txtDosageType.Enabled = false;
            m_ctlOrderDetail.m_txtExecuteFreq.Enabled = false;
            m_ctlOrderDetail.m_txtGet.Enabled = false;
            m_ctlOrderDetail.m_txtDays.Enabled = false;
            m_ctlOrderDetail.m_txtATTACHTIMES_INT.Enabled = false;
            m_ctlOrderDetail.m_txtDoctorList.Enabled = false;
            m_ctlOrderDetail.m_txtDoctorList.BackColor = SystemColors.Control;
            m_ctlOrderDetail.m_cboRateType.Enabled = false;
            m_ctlOrderDetail.m_txtEntrust.Enabled = false;
            m_ctlOrderDetail.m_dtStartTime2.Enabled = false;
            m_ctlOrderDetail.m_dtStartTime2.BackColor = SystemColors.Control;
            m_ctlOrderDetail.m_dtFinishTime2.Enabled = false;
            m_ctlOrderDetail.m_dtFinishTime2.BackColor = SystemColors.Control;
            //m_ctlOrderDetail.txtCureDays.Enabled = false;
            m_ctlOrderDetail.cboKJ.Enabled = false;
            m_ctlOrderDetail.cboQK.Enabled = false;
            m_ctlOrderDetail.cboProxyBoil.Enabled = false;
            m_ctlOrderDetail.cboEmer.Enabled = false;
        }

        /// <summary>
        /// 判断当前医嘱是父医嘱还是子医嘱（在存在同方的情况下）
        /// </summary>
        /// <param name="m_objCurrentOrder">当前医嘱</param>
        /// <param name="m_blParentOrder">当前医嘱是父医嘱(true-是,false-不是)</param>
        /// <param name="m_blSubOrder">当前医嘱是子医嘱(true-是,false-不是)</param>
        public void TheChangedOrderParentOrSub(clsBIHOrder m_objCurrentOrder, out bool m_blParentOrder, out bool m_blSubOrder)
        {
            int Count = 0;
            m_blParentOrder = false;
            m_blSubOrder = false;
            for (int i = 0; i < this.m_dtvOrder.Rows.Count; i++)
            {
                clsBIHOrder bihOrder = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                //if (bihOrder.m_strOrderID == m_objCurrentOrder.m_strOrderID)
                //{
                //    continue;
                //}
                if (bihOrder.m_intRecipenNo == m_objCurrentOrder.m_intRecipenNo)
                {
                    Count++;
                }
                if (Count > 0 && bihOrder.m_intRecipenNo == m_objCurrentOrder.m_intRecipenNo)
                {
                    if (Count == 1)
                    {
                        m_blParentOrder = true;
                        if (bihOrder.m_strOrderID == m_objCurrentOrder.m_strOrderID)
                        {
                            return;
                        }
                    }
                    else
                    {
                        m_blParentOrder = false;
                    }

                }

            }
            if (Count > 1)
            {
                m_blSubOrder = true;

            }
        }

        /// <summary>
        /// 当前医嘱下是否可以修改医嘱的警告
        /// </summary>
        /// <param name="m_objCurrentOrder"></param>
        /// <returns></returns>
        private bool alertFromTheStatue(clsBIHOrder m_objCurrentOrder)
        {
            if (m_objCurrentOrder.m_intStatus == 0 || m_objCurrentOrder.m_intStatus == 1 || m_objCurrentOrder.m_intStatus == 7)
            {
            }
            else
            {
                MessageBox.Show("转抄后的医嘱不能进行修改!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (m_objCurrentOrder.m_strCREATEAREA_ID != this.LoginInfo.m_strInpatientAreaID)
            //{
            //    MessageBox.Show("该医嘱非本区医嘱，不可以进行修改!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (!m_blUsePowerHander(m_objCurrentOrder))
            {
                MessageBox.Show("没有足够权限处理当前医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public bool m_blUsePowerHander(clsBIHOrder m_objCurrentOrder)
        {
            bool m_blHander = true;
            if (!m_objCurrentOrder.m_strCreatorID.Equals(this.LoginInfo.m_strEmpID))
            {
                if (!m_objCurrentOrder.m_strDOCTORID_CHR.Equals(this.LoginInfo.m_strEmpID))
                {
                    m_blHander = false;
                }
            }
            return m_blHander;
        }

        /// <summary>
        /// 让DataGrid鼠标左键也能选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dtgOrder_m_evtMouseDownCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMousePressEventArgs e)
        {
            //m_dtgOrder.CurrentCell=new DataGridCell(e.m_intRowNumber,e.m_intColNumber);
            System.Drawing.Point pt = new Point(e.X, e.Y);
            pt.Offset(this.m_dtvOrder.Location.X, this.m_dtvOrder.Location.Y);
            System.Drawing.Point po;
            m_poToolTip = new System.Drawing.Point(pt.X, pt.Y + 20 + 66);
            if (m_IsDisPlayToolTip)
            {
                DisplayToolTip(m_poToolTip);
            }
            #region ToolTip Lable控件显示
            //			//m_strToolTip =m_objDomain.strGetToolTipText(m_objCurrentOrder);
            //			if(!m_IsDisPlayToolTip || m_strToolTip.Trim()=="") return;
            //			#region 显示ToolTip
            //			m_lblToolTip.Text = m_strToolTip + "温馨提示：{F10键---开关医嘱费用提示信息！}";
            //			m_lblToolTip.Visible =true;
            //			System.Drawing.Point pt=new Point(e.X,e.Y);
            //			pt.Offset(m_dtgOrder.Location.X,m_dtgOrder.Location.Y);
            //			System.Drawing.Point po;		
            //			po =new System.Drawing.Point(pt.X,pt.Y + 20);
            //			m_lblToolTip.Location =po;
            //			#endregion
            #endregion
        }

        private void m_dtgOrder_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            DisplayBackReason(m_poToolTip);
        }

        /// <summary>
        /// 显示ToolTip	ListView控件
        /// </summary>
        /// <param name="po">已经算好的</param>
        private void DisplayToolTip(System.Drawing.Point po)
        {
            //m_objDomain.m_DisPlayToolTipListView(m_objCurrentOrder,m_lsvToolTip);
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
                m_objDomain.m_DisPlayToolTipListView(order, m_lsvToolTip);
            }
            m_lsvToolTip.Visible = true;
            m_lsvToolTip.Location = po;
        }
        /// <summary>
        /// 显示退回原因
        /// </summary>
        /// <param name="po">已经算好的</param>
        private void DisplayBackReason(System.Drawing.Point po)
        {
            if (m_objCurrentOrder == null || m_objCurrentOrder.m_intStatus != 7) return;
            string strTem = "";
            strTem += "退回原因：" + ((m_objCurrentOrder.m_strBACKREASON == null) ? ("") : (m_objCurrentOrder.m_strBACKREASON.Trim()));
            strTem += "\r\n退回护士：" + m_objCurrentOrder.m_strSENDBACKER_CHR;
            strTem += "\r\n退回时间：" + m_objCurrentOrder.m_strSENDBACK_DAT;
            this.m_txtBackReason.Text = strTem;
            this.m_txtBackReason.Visible = true;
            this.m_txtBackReason.Location = po;
        }
        #endregion
        #region 显示过滤
        /// <summary>
        /// 仅显示当天
        /// </summary>
        internal bool m_blnShowOnlyToday = false;
        /// <summary>
        /// 显示医嘱的类型
        /// </summary>
        internal int m_intShowOrderExecuteType = 0;
        /// <summary>
        /// 是否仅显示皮试的医嘱
        /// </summary>
        internal bool m_blnNeedFeel = false;
        internal void m_mthShowConditionChange(object sender, EventArgs e)
        {
            bool blnOnlyToday = m_rdoToday.Checked;
            int intExecuteType = 0;
            if (m_rdoLongType.Checked)
                intExecuteType = 1;
            else if (m_rdoTempType.Checked)
                intExecuteType = 2;
            bool blnNeedFeel = m_chkNeedFeel.Checked;

            if ((m_blnShowOnlyToday != blnOnlyToday) || (m_intShowOrderExecuteType != intExecuteType) || (m_blnNeedFeel != blnNeedFeel))
            {
                m_blnShowOnlyToday = blnOnlyToday;
                //m_intShowOrderExecuteType=intExecuteType;
                m_blnNeedFeel = blnNeedFeel;
                this.Cursor = Cursors.WaitCursor;
                m_objDomain.m_mthLoadOrderList();
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;}
        /// </summary>
        internal int[] m_arrStatus = new int[] { 0, 1, 2, 3 };		//允许显示出来的医嘱的状态
        internal void m_mthShowStatusChange(object sender, EventArgs e)
        {	//执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;}
            //ArrayList arlStatus=new ArrayList();
            //if(m_chkStatus0.Checked) 
            //{
            //    arlStatus.Add(0);
            //    arlStatus.Add(7);
            //}
            //if(m_chkStatus1.Checked) 
            //{
            //    arlStatus.Add(1);
            //    arlStatus.Add(5);
            //}
            //if(m_chkStatus2.Checked) arlStatus.Add(2);
            //if(m_chkStatus3.Checked) 
            //{
            //    arlStatus.Add(3);
            //    arlStatus.Add(6);
            //} 
            //if (m_chkStatus4.Checked)
            //{
            //    arlStatus.Add(-1);
            //}
            ///*<-----------------------------------*/

            //m_arrStatus=(int[])(arlStatus.ToArray(typeof(int)));
            //this.Cursor =Cursors.WaitCursor;
            //m_objDomain.m_mthLoadOrderList();
            //this.Cursor =Cursors.Default;
        }

        #endregion
        #region iLoginInfo 成员
        internal com.digitalwave.iCare.ValueObject.clsLoginInfo m_objLoginInfo = null;
        public new com.digitalwave.iCare.ValueObject.clsLoginInfo LoginInfo
        {
            get
            {
                // TODO:  添加 frmBIHOrderInput.LoginInfo getter 实现
                return m_objLoginInfo;
            }
            set
            {
                // TODO:  添加 frmBIHOrderInput.LoginInfo setter 实现
                m_objLoginInfo = value;
                if ((m_objCurrentDoctor == null) && (m_objLoginInfo != null))
                {
                    m_objCurrentDoctor = new clsBIHDoctor();
                    m_objCurrentDoctor.m_strDoctorID = m_objLoginInfo.m_strEmpID;
                    m_objCurrentDoctor.m_strDoctorName = m_objLoginInfo.m_strEmpName;
                }
            }
        }

        #endregion
        #region	方法
        /// <summary>
        /// 获取医嘱颜色描述	根据类型、执行状态；
        /// 注意：
        ///		clrBack		医嘱类型	{1=长期;2=临时}
        ///		clrFore		执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
        /// </summary>
        /// <param name="intType">医嘱类型	{1=长期;2=临时}</param>
        /// <param name="intStatus">执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}</param>
        /// <param name="clrBack">[用于区别医嘱类型]</param>
        /// <param name="clrFore">[用于区别执行状态]</param>
        public void m_mthGetColorByStatus(int intType, int intStatus, out Color clrBack, out Color clrFore)
        {
            clsOrderStatus.s_mthGetColorByStatus(intType, intStatus, out clrBack, out clrFore);
        }
        #endregion
        #region 属性
        /// <summary>
        /// 是否显示ToolTip提示信息		{只读}
        /// </summary>
        public bool IsDisPlayToolTip
        {
            get { return m_IsDisPlayToolTip; }
        }
        #endregion
        #region 打印医嘱
        private void cmdPrintOrder_Click(object sender, System.EventArgs e)
        {
            if (this.cboPrintType.SelectedIndex == 0)
            {
                m_objDomain.m_PrintOrder();
            }
            else if (this.cboPrintType.SelectedIndex == 1)
            {
                clsBIHPatientInfo patVo = this.m_ctlPatient.m_objPatient;
                if (patVo == null)
                {
                    m_mthShowMessage("请先选择病人!");
                    this.m_ctlPatient.Focus();
                    return;
                }
                string registerId = this.m_ctlPatient.m_objPatient.m_strRegisterID;
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                DataTable dtMed = svc.GetOutMedicine(registerId);
                if (dtMed == null || dtMed.Rows.Count == 0)
                {
                    m_mthShowMessage("无出院带药项目");
                    return;
                }
                frmChooseRecipe frm = new frmChooseRecipe(patVo, dtMed);
                frm.ShowDialog();
            }
            else if (this.cboPrintType.SelectedIndex == 2)
            {
                clsBIHPatientInfo patVo = this.m_ctlPatient.m_objPatient;
                if (patVo == null)
                {
                    m_mthShowMessage("请先选择病人。");
                    this.m_ctlPatient.Focus();
                    return;
                }
                if (this.m_dtvOrder.SelectedRows.Count == 0)
                {
                    m_mthShowMessage("请选择要打印的麻醉药品医嘱。");
                    return;
                }
                string orderIdArr = string.Empty;
                if (this.m_dtvOrder.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
                    {
                        clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                        orderIdArr += "'" + order.m_strOrderID + "',";
                    }
                }
                if (orderIdArr != string.Empty) orderIdArr = orderIdArr.TrimEnd(',');

                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                DataTable dtMed = svc.GetAneMedicine(orderIdArr);
                if (dtMed == null || dtMed.Rows.Count == 0)
                {
                    m_mthShowMessage("无麻醉药品，请重新选择。");
                    return;
                }
                frmChooseRecipe frm = new frmChooseRecipe(patVo, dtMed);
                frm.ShowDialog();
            }
        }
        #endregion

        #region Find the parent order's index of grid.Add by jli in 2005-03-30
        private long m_lngGetParentOrderIndex(string p_strRecipeNO)
        {
            for (int i = 0; i < m_arlOrder.Count; i++)
            {
                if (((clsBIHOrder)m_arlOrder[i]).m_intRecipenNo.ToString().Trim() == p_strRecipeNO && ((clsBIHOrder)m_arlOrder[i]).m_strParentID.Trim() == "")
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region 申请单相关
        #region 载入申请单
        private clsCustom_SubmitValue[] objCSVOArr = null;
        private void m_mthLoadApplyBill()
        {
            clsCustomFormServ obj = new clsCustomFormServ();
            clsDepartmentVO[] dpvo = new clsDepartmentVO[0];
            new clsController_Base().m_objComInfo.m_mthGetDepartmentByUserID(m_objLoginInfo.m_strEmpID, out dpvo);
            string[] strDpArr = new string[1];
            if (dpvo != null)
            {
                strDpArr = new string[dpvo.Length];
                for (int ii = 0; ii < dpvo.Length; ii++)
                {
                    strDpArr[ii] = dpvo[ii].strDeptID;
                }
            }
            else
            {
                strDpArr[0] = "";
            }

            long l = obj.m_lngGetSubmitForms(this.LoginInfo.m_strEmpID, strDpArr, out objCSVOArr);
            if (objCSVOArr != null && objCSVOArr.Length > 0)
            {
                this.cmbApply.Items.Clear();
                for (int i = 0; i < objCSVOArr.Length; i++)
                {
                    this.cmbApply.Items.Add(objCSVOArr[i].m_strFormName);
                }
            }
            //this.cmbApply.Items.Add("检验申请单");
        }
        private void cmbApply_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthShowApplyBill();
            }
        }
        private void btCreatBill_Click(object sender, System.EventArgs e)
        {
            this.m_mthShowApplyBill();
        }
        #endregion
        #region 打开申请单
        private void m_mthShowApplyBill()
        {
            if (m_ctlPatient.m_objPatient == null || m_ctlPatient.m_objPatient.m_strPatientID == null)
            {
                m_mthShowMessage("请先指定病人!");
                m_ctlPatient.Focus();
                return;
            }
            //获取病人ID、病人诊疗卡号
            string strPatientID = m_ctlPatient.m_objPatient.m_strPatientID;
            string strPatientCardID = m_strPatientCardID;
            if (this.cmbApply.SelectedIndex < 0)
            {
                return;
            }
            if (this.objCSVOArr == null || this.cmbApply.SelectedIndex == this.objCSVOArr.Length)
            {
            }
            else
            {
                frmCustomFormBase objfrm = new frmCustomFormBase(strPatientID, strPatientCardID, this.objCSVOArr[this.cmbApply.SelectedIndex], this);
                //frmCustomFormBase objfrm =new frmCustomFormBase(this.m_PatInfo.PatientID,this.m_PatInfo.PatientCardID,this.objCSVOArr[this.cmbApply.SelectedIndex],this);
                objfrm.ShowDialog();
            }
        }
        #endregion
        #region 公共属性
        /// <summary>
        /// 病人姓名	[只读]
        /// </summary>
        public string PatientName
        {
            get
            {
                if (m_ctlPatient.m_objPatient == null || m_ctlPatient.m_objPatient.m_strPatientName == null)
                {
                    return "";
                }
                else
                {
                    return m_ctlPatient.m_objPatient.m_strPatientName;
                }
            }
        }
        /// <summary>
        /// 病人ＩＤ	[只读]
        /// </summary>
        public string PatientID
        {
            get
            {
                if (m_ctlPatient.m_objPatient == null || m_ctlPatient.m_objPatient.m_strPatientID == null)
                {
                    return "";
                }
                else
                {
                    return m_ctlPatient.m_objPatient.m_strPatientID;
                }
            }
        }
        /// <summary>
        /// 病人性别	[只读]
        /// </summary>
        public string PatientSex
        {
            get
            {
                if (m_ctlPatient.m_objPatient == null || m_ctlPatient.m_objPatient.m_strSex == null)
                {
                    return "";
                }
                else
                {
                    return m_ctlPatient.m_objPatient.m_strSex;
                }
            }
        }
        /// <summary>
        /// 病人年龄	[只读]	
        /// </summary>
        public string PatientAge
        {
            get
            {
                if (m_ctlPatient.m_objPatient == null || m_ctlPatient.m_objPatient.m_dtBorn < System.DateTime.Now.AddYears(120) || m_ctlPatient.m_objPatient.m_dtBorn > System.DateTime.Now)
                {
                    return "";
                }
                else
                {
                    return strGetAge(m_ctlPatient.m_objPatient.m_dtBorn);
                }
            }
        }
        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="p_dtBorn"></param>
        /// <returns></returns>
        private string strGetAge(DateTime p_dtBorn)
        {
            //change zhu.w.t 2007.4.23
            //if(p_dtBorn.Year==DateTime.Now.Year)
            //{
            //    if(p_dtBorn.Month==DateTime.Now.Month)
            //    {
            //        return (DateTime.Now.Day - p_dtBorn.Day).ToString() + "天";
            //    }
            //    else
            //    {
            //        return (DateTime.Now.Month - p_dtBorn.Month).ToString() + "月";				
            //    }
            //}
            //else
            //{
            //    return (DateTime.Now.Year - p_dtBorn.Year).ToString() + "年";
            //}
            //=================================>>
            string strAge = com.digitalwave.iCare.gui.LIS.clsAgeConverter.s_strGetAge(p_dtBorn);
            return strAge;
            /*<<================================*/
        }
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        string m_strPatientCardID = "";
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        public string PatientCardID
        {
            get
            {
                return m_strPatientCardID;
            }
            set
            {
                m_strPatientCardID = value;
            }
        }
        /// <summary>
        /// 住院号	[只读]
        /// </summary>
        public string InHospitalNo
        {
            get
            {
                if (m_ctlPatient.m_objPatient == null || m_ctlPatient.m_objPatient.m_strInHospitalNo == null)
                {
                    return "";
                }
                else
                {
                    return m_ctlPatient.m_objPatient.m_strInHospitalNo;
                }
            }
        }
        /// <summary>
        /// 病区名称	[只读]
        /// </summary>
        public string AreaName
        {
            get
            {
                if (m_ctlPatient.m_objPatient == null || m_ctlPatient.m_objPatient.m_strAreaName == null)
                {
                    return "";
                }
                else
                {
                    return m_ctlPatient.m_objPatient.m_strAreaName;
                }
            }
        }
        /// <summary>
        /// 床号	[只读]
        /// </summary>
        public string BedNo
        {
            get
            {
                if (m_ctlPatient.m_objPatient == null || m_ctlPatient.m_objPatient.m_strBedName == null)
                {
                    return "";
                }
                else
                {
                    return m_ctlPatient.m_objPatient.m_strBedName;
                }
            }
        }
        /// <summary>
        /// 操作人姓名	[只读]
        /// </summary>
        public string OperatorName
        {
            get
            {
                if (m_objLoginInfo == null || m_objLoginInfo.m_strEmpName == null)
                {
                    return "";
                }
                else
                {
                    return m_objLoginInfo.m_strEmpName;
                }
            }
        }
        /// <summary>
        /// 操作人工号	[只读]
        /// </summary>
        public string OperatorNo
        {
            get
            {
                if (m_objLoginInfo == null || m_objLoginInfo.m_strEmpNo == null)
                {
                    return "";
                }
                else
                {
                    return m_objLoginInfo.m_strEmpNo;
                }
            }
        }
        #endregion
        #endregion

        private void label13_Click(object sender, System.EventArgs e)
        {
            this.label13.Visible = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (this.label13.Visible == true)
            {
                this.label13.Visible = false;
            }
            else
            {

                this.label13.Show();
                this.label13.BringToFront();
            }
        }

        private void m_dtgOrder_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            System.Drawing.Point pt = new Point(0, 0);
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                m_lsvToolTip.Visible = false;
            }
            cmbApply_KeyDown(null, e);
        }

        internal void lblLeft_Click()
        {
            lblLeft_Click(null, null);
        }
        private void lblLeft_Click(object sender, System.EventArgs e)
        {
            m_IsDisPlayToolTip = false;
            if (m_ctlOrderDetail.m_txtDoctor.Tag != null)
            {
                frmListDoctor.DoctorID = m_ctlOrderDetail.m_txtDoctor.Tag.ToString();
                frmListDoctor.DoctorName = m_ctlOrderDetail.m_txtDoctor.Text;
            }
            else
            {
                frmListDoctor.DoctorID = "";
                frmListDoctor.DoctorName = "";
            }
            if (!fl.Visible)
            {
                lblLeft.BackColor = Color.DarkGray;
                lblLeft.ForeColor = Color.White;
                lblBoard.BackColor = SystemColors.Control;
                lblBoard.ForeColor = Color.Black;
                lbePriceInfo.BackColor = SystemColors.Control;
                lbePriceInfo.ForeColor = Color.Black;
                fo.Hide();
                this.m_lsvToolTip.Hide();
                fl.TopLevel = false;
                fl.Visible = true;
                fl.FormBorderStyle = FormBorderStyle.None;
                fl.Parent = this.pnSel;
                fl.Show();
                pnSel.Show();
                lblLeft.Parent.Parent.Width = lblLeft.Width + 500;
                fl.lsvPatientItemSelected();
                fl.SetPatient(this.CurrentPatientInhospitalNo);
            }
            else
            {
                lblLeft.BackColor = SystemColors.Control;
                lblLeft.ForeColor = Color.Black;
                pnSel.Hide();
                fl.Visible = false;
                lblLeft.Parent.Parent.Width = lblLeft.Width;
            }
        }

        private void m_mnuCopy_Click(object sender, System.EventArgs e)
        {

            if (!fo.Visible)
            {
                lblBoard_Click(sender, e);
            }
            ArrayList m_arrOrder = GetTheSelectItemWithSon();
            //检查医嘱是否停用
            ArrayList m_arrOrderIDs = new ArrayList();
            for (int i = 0; i < m_arrOrder.Count; i++)
            {
                if (!m_arrOrderIDs.Contains(((clsBIHOrder)m_arrOrder[i]).m_strOrderID))
                {
                    m_arrOrderIDs.Add(((clsBIHOrder)m_arrOrder[i]).m_strOrderID);
                }
            }
            ArrayList m_strOrders = GetTheStopOrders(m_arrOrderIDs);
            if (m_strOrders != null && m_arrOrder.Count > 0)
            {
                string m_strErrMessage = "";
                for (int i = 0; i < m_arrOrder.Count; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)m_arrOrder[i];
                    if (m_strOrders.Contains(order.m_strOrderID))
                    {
                        m_strErrMessage += order.m_strName + "\r\n";
                    }
                }
                if (!m_strErrMessage.Trim().Equals(""))
                {
                    m_strErrMessage = "以下医嘱因相关收费项目停用或药品停药,不能进行复制!" + "\r\n" + m_strErrMessage;
                    MessageBox.Show(m_strErrMessage, "医嘱复制", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            fo.m_lngAddOrderGroupList(m_arrOrder);

        }

        private void m_mnuPaste_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataObject dob = (DataObject)Clipboard.GetDataObject();
                object[] objPaste = ((object[])(dob.GetData(typeof(object[]))));
            }
            catch
            {
            }
        }

        private void lblBoard_Click(object sender, System.EventArgs e)
        {
            m_IsDisPlayToolTip = false;

            if (!fo.Visible)
            {
                lblLeft.BackColor = SystemColors.Control;
                lblLeft.ForeColor = Color.Black;
                lblBoard.BackColor = Color.DarkGray;
                lblBoard.ForeColor = Color.White;
                lbePriceInfo.BackColor = SystemColors.Control;
                lbePriceInfo.ForeColor = Color.Black;
                fl.Hide();
                this.m_lsvToolTip.Hide();
                fo.frmParent = (frmBIHOrderInput)panel4.Parent;
                fo.TopLevel = false;
                fo.FormBorderStyle = FormBorderStyle.None;
                fo.Parent = this.pnSel;
                fo.Visible = true;
                fo.Show();
                pnSel.Show();
                lblLeft.Parent.Parent.Width = lblLeft.Width + 500;
            }
            else
            {
                lblBoard.BackColor = SystemColors.Control;
                lblBoard.ForeColor = Color.Black;
                pnSel.Hide();
                fo.Visible = false;
                lblLeft.Parent.Parent.Width = lblLeft.Width;
            }
        }

        private void pnTabs_Leave(object sender, System.EventArgs e)
        {
            lblLeft_Click(null, null);
        }

        private void pnSel_Leave(object sender, System.EventArgs e)
        {
            lblLeft_Click(null, null);
        }

        private void pnSel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.X < pnSel.Location.X && e.Y < pnSel.Location.Y) && (e.X > pnSel.Location.X + pnSel.Size.Width && e.Y > pnSel.Location.Y + pnSel.Size.Height))
            {
                lblLeft_Click(null, null);
            }
        }

        private void m_cmdSub_Click(object sender, System.EventArgs e)
        {
            if (m_ConfirmPatient() == 0)
            {
                return;
            }
            if (m_ConfirmHaveOrder() == 0)
            {
                return;
            }
            if (m_objCurrentOrder == null)
            {
                m_objCurrentOrder = (clsBIHOrder)m_dtvOrder.Rows[this.m_dtvOrder.RowCount - 1].Tag;
            }
            if (m_objCurrentOrder.m_intStatus != 0 && m_objCurrentOrder.m_intStatus != 7)
            {
                m_mthShowMessage("只能对新开的医嘱进行子医嘱操作!");
                return;
            }
            if (m_objCurrentOrder.m_strCreatorID != this.LoginInfo.m_strEmpID)
            {
                m_mthShowMessage("只能对自己新开的医嘱进行子医嘱操作!");
                return;
            }
            m_ctlOrderDetail.IsSubOrder = true;

            int currentrow = m_intCurrentRow;
            clsBIHOrder ParentOrder = (clsBIHOrder)m_arlOrder[m_intCurrentRow];
            m_ctlOrderDetail.IsSubOrder = true;
            m_ctlOrderDetail.ParentOrder = ParentOrder;
            m_objCurrentOrder = new clsBIHOrder();

            m_objCurrentOrder.m_intExecuteType = ParentOrder.m_intExecuteType;
            m_objCurrentOrder.m_intRecipenNo = ParentOrder.m_intRecipenNo;
            m_objCurrentOrder.m_strDosetypeID = ParentOrder.m_strDosetypeID;

            //如果当前医嘱是子医嘱,取其父医嘱作为父医嘱
            if (ParentOrder.m_strParentID.Trim() != "")
            {
                m_objCurrentOrder.m_strParentID = ParentOrder.m_strParentID;
                m_objCurrentOrder.m_strParentName = ParentOrder.m_strParentName;
            }
            else
            {
                m_objCurrentOrder.m_strParentID = ParentOrder.m_strOrderID;
                m_objCurrentOrder.m_strParentName = ParentOrder.m_strName;
            }

            m_objCurrentOrder.m_strDosetypeName = ParentOrder.m_strDosetypeName;
            m_objCurrentOrder.m_strExecFreqID = ParentOrder.m_strExecFreqID;
            m_objCurrentOrder.m_strExecFreqName = ParentOrder.m_strExecFreqName;
            /* 检验*/
            m_objCurrentOrder.m_strSAMPLEName_VCHR = ParentOrder.m_strSAMPLEName_VCHR.ToString().Trim();
            m_objCurrentOrder.m_strSAMPLEID_VCHR = ParentOrder.m_strSAMPLEID_VCHR.ToString().Trim();
            /*<==============================================*/
            /* 检查*/
            m_objCurrentOrder.m_strPARTNAME_VCHR = ParentOrder.m_strPARTNAME_VCHR.ToString().Trim();
            m_objCurrentOrder.m_strPARTID_VCHR = ParentOrder.m_strPARTID_VCHR.ToString().Trim();
            m_objCurrentOrder.m_strPatientID = ParentOrder.m_strPatientID;

            //医嘱类型改变时的控制(长嘱/临嘱/出院带药)
            m_ctlOrderDetail.m_cboExecuteType_SelectedIndexChanged(null, null);
            m_mthShowCurrentOrder(m_objCurrentOrder);

            m_ctlOrderDetail.m_txtExecuteFreq.Enabled = false;
            m_ctlOrderDetail.m_txtExecuteFreq.BackColor = SystemColors.Control;
            m_ctlOrderDetail.m_txtDosageType.Enabled = false;
            m_ctlOrderDetail.m_txtDosageType.BackColor = SystemColors.Control;
            m_ctlOrderDetail.m_mthSetDoctor(m_objCurrentDoctor.m_strDoctorID, m_objCurrentDoctor.m_strDoctorName);

            m_ctlOrderDetail.m_txtOrderName.Enabled = true;
            m_ctlOrderDetail.m_txtOrderName.BackColor = System.Drawing.Color.White;
            m_ctlOrderDetail.m_txtOrderName.Focus();
            // 处理(已提交/执行医嘱的)子医嘱不能保存问题
            this.m_cmdSave.Enabled = true;
            this.m_cmdDelete.Enabled = false;
            m_cmdBlankOut.Enabled = false;
            m_cmdStop.Enabled = false;
            m_cmdSub.Enabled = false;
        }

        private void lbePriceInfo_Click(object sender, System.EventArgs e)
        {
            if (!m_lsvToolTip.Visible)
            {
                if (m_IsDisPlayToolTip == false)
                {
                    m_IsDisPlayToolTip = true;
                    m_dtvOrder_CellMouseClick(null, null);
                }

                lbePriceInfo.BackColor = Color.DarkGray;
                lbePriceInfo.ForeColor = Color.White;
                lblBoard.BackColor = SystemColors.Control;
                lblBoard.ForeColor = Color.Black;
                lblLeft.BackColor = SystemColors.Control;
                lblLeft.ForeColor = Color.Black;
                foreach (System.Windows.Forms.Control c in this.pnSel.Controls)
                {
                    c.Visible = false;
                }
                this.pnSel.Controls.Add(this.m_lsvToolTip);
                this.m_lsvToolTip.Dock = DockStyle.Fill;
                this.m_lsvToolTip.Show();
                this.m_lsvToolTip.BringToFront();
                pnSel.Show();
                lbePriceInfo.Parent.Parent.Width = lbePriceInfo.Width + 500;
            }
            else
            {
                m_IsDisPlayToolTip = false;
                lblLeft.BackColor = SystemColors.Control;
                lblLeft.ForeColor = Color.Black;
                pnSel.Hide();
                m_lsvToolTip.Hide();
                lbePriceInfo.Parent.Parent.Width = lbePriceInfo.Width;
            }
        }

        #region	显示药品详细信息	glzhang	2005.10.13
        private void m_lsvToolTip_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //case Keys.F9:
                //    if(m_lsvToolTip.SelectedItems.Count>0)
                //    {
                //        string strMedicineInfo;
                //        clsDcl_InputOrder m_input = new clsDcl_InputOrder();
                //        m_input.m_mthGetMedicineInfo(((clsChargeForDisplay)m_lsvToolTip.SelectedItems[0].Tag).m_strChargeID,out strMedicineInfo);
                //        frmShowMedicineInfo m_frmTemp = new frmShowMedicineInfo(strMedicineInfo);
                //        m_frmTemp.ShowDialog();
                //        m_frmTemp.Dispose();
                //    }
                //    break;
                case Keys.Enter:
                    if (m_lsvToolTip.SelectedItems.Count > 0)
                    {
                        string strMedicineInfo;
                        clsDcl_InputOrder m_input = new clsDcl_InputOrder();
                        m_input.m_mthGetMedicineInfo(((clsChargeForDisplay)m_lsvToolTip.SelectedItems[0].Tag).m_strChargeID, out strMedicineInfo);
                        frmShowMedicineInfo m_frmTemp = new frmShowMedicineInfo(strMedicineInfo);
                        m_frmTemp.ShowDialog();
                        m_frmTemp.Dispose();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 医嘱录入基本前提信息检查
        /// </summary>
        public bool m_OrderInputPreCheck()
        {
            clsBIHPatientInfo objPatient = m_ctlPatient.m_objPatient;
            if (objPatient == null)
            {
                m_mthShowMessage("请先指定病人!");
                m_ctlPatient.Focus();
                return false;
            }
            //医保病人: 超额时不能录入，需要重新设定该病人费用下限。
            //if (m_blnISMedicareMan)
            //{
            //    double dblPrePayMoney = 0;
            //    double dblLIMITRATE_MNY = m_ctlPatient.m_objPatient.m_dblLIMITRATE_MNY;
            //    try { dblPrePayMoney = double.Parse(m_ctlPatient.m_txtPrePayMoney.Text.ToString()); }
            //    catch { }

            //    if (dblLIMITRATE_MNY > dblPrePayMoney)
            //    {
            //        MessageBox.Show("预交金余额,超过费用下限,不能开医嘱！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }
            //}
            return true;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = !this.panel3.Visible;
        }

        private void alertLight1_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = !this.panel3.Visible;
        }

        private void m_mnuCopyBihOrder_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[] p_strRecordIDArr = null;
            ArrayList m_arrOrderSameNo = GetTheSelectItemWithSon();
            m_objDomain.m_lngAddNewOrderByGroup(out p_strRecordIDArr, m_arrOrderSameNo);
            this.m_objDomain.m_mthLoadOrderList();
        }

        /// <summary>
        ///获得当前选中的医嘱列表(包括父子医嘱)
        /// </summary>
        /// <returns></returns>
        internal ArrayList GetTheSelectItemWithSon()
        {
            //保存已存在的医嘱号
            ArrayList m_arrOrderHave = new ArrayList();
            ArrayList m_arrOrderSameNo = new ArrayList();
            int m_intRecipenNo = -1;

            for (int i = 0; i < this.m_dtvOrder.Rows.Count; i++)
            {
                if (this.m_dtvOrder.Rows[i].Selected == true)
                {
                    m_intRecipenNo = ((clsBIHOrder)this.m_dtvOrder.Rows[i].Tag).m_intRecipenNo;
                    for (int j = 0; j < this.m_dtvOrder.Rows.Count; j++)
                    {
                        //医嘱类型为文字医嘱或为特殊医嘱的不允许生成组套模板
                        clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.Rows[j].Tag;
                        if (!CanCopyToGroup(order))
                        {
                            continue;
                        }
                        if (m_intRecipenNo == order.m_intRecipenNo)
                        {
                            if (m_arrOrderHave.Contains(order.m_strOrderID))
                            {
                                continue;
                            }
                            m_arrOrderSameNo.Add(CopyNewOrder(order));
                            m_arrOrderHave.Add(order.m_strOrderID);
                        }
                    }
                }

            }

            //设置第一条医嘱为父医嘱（如果存在父子的情况下）
            if (m_arrOrderSameNo.Count > 0)
            {
                ArrayList m_arrParentSet = new ArrayList();
                for (int i = 0; i < m_arrOrderSameNo.Count; i++)
                {
                    SetTheCurrentOrder((clsBIHOrder)m_arrOrderSameNo[i]);
                    if (i < m_arrOrderSameNo.Count - 1)
                    {
                        if (m_arrParentSet.Contains(((clsBIHOrder)m_arrOrderSameNo[i]).m_intRecipenNo))
                        {
                            continue;
                        }
                        if (((clsBIHOrder)m_arrOrderSameNo[i]).m_intRecipenNo == ((clsBIHOrder)m_arrOrderSameNo[i + 1]).m_intRecipenNo)
                        {
                            ((clsBIHOrder)m_arrOrderSameNo[i]).m_intIFPARENTID_INT = 1;
                            m_arrParentSet.Add(((clsBIHOrder)m_arrOrderSameNo[i]).m_intRecipenNo);
                        }
                    }
                }

            }
            return m_arrOrderSameNo;
        }

        /// <summary>
        /// 复制新的医嘱(原有医嘱到新医嘱)
        /// </summary>
        /// <param name="clsBIHOrder"></param>
        /// <returns></returns>
        public clsBIHOrder CopyNewOrder(clsBIHOrder clsBIHOrder)
        {
            clsBIHOrder order = new clsBIHOrder();
            order.m_dmlDosage = clsBIHOrder.m_dmlDosage;
            order.m_dmlDosageRate = clsBIHOrder.m_dmlDosageRate;
            order.m_dmlGet = clsBIHOrder.m_dmlGet;
            order.m_dmlPrice = clsBIHOrder.m_dmlPrice;
            order.m_dmlUse = clsBIHOrder.m_dmlUse;
            order.m_intATTACHTIMES_INT = clsBIHOrder.m_intATTACHTIMES_INT;
            order.m_intExecuteType = clsBIHOrder.m_intExecuteType;
            order.m_intIFPARENTID_INT = clsBIHOrder.m_intIFPARENTID_INT;
            order.m_intOUTGETMEDDAYS_INT = clsBIHOrder.m_intOUTGETMEDDAYS_INT;
            order.RateType = clsBIHOrder.RateType;
            order.m_intRecipenNo = clsBIHOrder.m_intRecipenNo;
            order.m_intRecipenNo2 = clsBIHOrder.m_intRecipenNo2;
            order.m_intStatus = 0;
            order.m_intCHARGE_INT = clsBIHOrder.m_intCHARGE_INT;
            order.m_strCHARGEITEMID_CHR = clsBIHOrder.m_strCHARGEITEMID_CHR;
            order.m_strCHARGEITEMNAME_CHR = clsBIHOrder.m_strCHARGEITEMNAME_CHR;
            order.m_strDosageUnit = clsBIHOrder.m_strDosageUnit;
            order.m_strDosetypeID = clsBIHOrder.m_strDosetypeID;
            order.m_strDosetypeName = clsBIHOrder.m_strDosetypeName;
            order.m_strEntrust = clsBIHOrder.m_strEntrust;
            order.m_strExecFreqID = clsBIHOrder.m_strExecFreqID;
            order.m_strExecFreqName = clsBIHOrder.m_strExecFreqName;
            clsAIDRecipeFreq m_objTempFreq = this.m_ctlOrderDetail.GetFreqVoByFreqID(clsBIHOrder.m_strExecFreqID);
            if (m_objTempFreq != null)
            {
                order.m_intFreqTime = m_objTempFreq.m_intTimes;
                order.m_intFreqDays = m_objTempFreq.m_intDays;
            }
            order.m_strGetunit = clsBIHOrder.m_strGetunit;
            order.m_strLISAPPID_VCHR = clsBIHOrder.m_strLISAPPID_VCHR;
            order.m_strMedicareTypeName = clsBIHOrder.m_strMedicareTypeName;
            //取诊疗项目名称，如果是特殊的医嘱将取回原来的医嘱名称---->
            //医嘱类型
            clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[clsBIHOrder.m_strOrderDicCateID];
            if (p_objItem != null && p_objItem.m_strVIEWNAME_VCHR.Trim().Equals("文字医嘱"))
            {
                order.m_strName = clsBIHOrder.m_strName;
            }
            else if (clsBIHOrder.m_intTYPE_INT != 0)
            {
                order.m_strName = clsBIHOrder.m_strName;
            }
            else
            {
                if (clsBIHOrder.m_strName.Trim().Equals(clsBIHOrder.m_strDicName.Trim()) || clsBIHOrder.m_strDicName.Trim().Equals(""))
                {
                    order.m_strName = clsBIHOrder.m_strName;
                }
                else
                {
                    order.m_strName = clsBIHOrder.m_strDicName;
                }
            }
            order.m_strOrderDicCateID = clsBIHOrder.m_strOrderDicCateID;
            order.m_strOrderDicCateName = clsBIHOrder.m_strOrderDicCateName;
            order.m_strOrderDicID = clsBIHOrder.m_strOrderDicID;
            order.m_strOrderID = clsBIHOrder.m_strOrderID;
            order.m_strPARTID_VCHR = clsBIHOrder.m_strPARTID_VCHR;
            order.m_strPARTNAME_VCHR = clsBIHOrder.m_strPARTNAME_VCHR;
            order.m_strSAMPLEID_VCHR = clsBIHOrder.m_strSAMPLEID_VCHR;
            order.m_strSAMPLEName_VCHR = clsBIHOrder.m_strSAMPLEName_VCHR;
            order.m_strSpec = clsBIHOrder.m_strSpec;
            order.m_strUseunit = clsBIHOrder.m_strUseunit;
            order.m_intISNEEDFEEL = clsBIHOrder.m_intISNEEDFEEL;

            order.m_strRegisterID = this.m_ctlPatient.m_objPatient.m_strRegisterID;
            order.m_strPatientID = this.m_ctlPatient.m_objPatient.m_strPatientID;
            order.m_strREMARK_VCHR = clsBIHOrder.m_strREMARK_VCHR;
            //医生所在工作组ID
            order.m_strDOCTORGROUPID_CHR = m_strDOCTORGROUPID_CHR;
            //下医嘱时病人所在病区ID
            order.m_strCURAREAID_CHR = this.m_ctlPatient.m_objPatient.m_strAreaID;
            //下医嘱时病人所在病床ID
            order.m_strCURBEDID_CHR = this.m_ctlPatient.m_objPatient.m_strBedID;
            //设置领量
            order.m_dmlGet = clsBIHOrder.m_dmlGet;
            order.m_dmlOneUse = clsBIHOrder.m_dmlOneUse;//补一次的量
            //医嘱来源
            order.m_intSOURCETYPE_INT = m_intSOURCETYPE_INT;
            //连续性医嘱的医嘱，领量强制为单位的量，频率次数为1
            if (order.m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))
            {
                order.m_dmlGet = 1;
                order.m_dmlOneUse = 1;
                order.m_intFreqTime = 1;
                order.m_intFreqDays = 1;
                order.m_dmlDosage = 1;
            }
            order.m_intIPCHARGEFLG_INT = clsBIHOrder.m_intIPCHARGEFLG_INT;
            order.m_dmlPACKQTY_DEC = clsBIHOrder.m_dmlPACKQTY_DEC;
            order.IsProxyBoilMed = clsBIHOrder.IsProxyBoilMed;
            return order;
        }

        /// <summary>
        /// 为当前医嘱加上附加的信息
        /// </summary>
        /// <param name="clsBIHOrder"></param>
        public void SetTheCurrentOrder(clsBIHOrder objOrder)
        {
            //诊疗项目信息
            objOrder.m_intStatus = 0;
            objOrder.m_strPosterId = "";
            objOrder.m_strPoster = "";

            objOrder.m_strExecutorID = "";
            objOrder.m_strExecutor = "";

            objOrder.m_strStoperID = "";
            objOrder.m_strStoper = "";
            objOrder.m_dtStopdate = DateTime.MinValue;

            objOrder.m_strRetractorID = "";
            objOrder.m_strRetractor = "";

            //父级医嘱
            //开始和结束时间 
            try
            {
                objOrder.m_dtStartDate = Convert.ToDateTime(this.m_ctlOrderDetail.m_dtStartTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtStartDate = DateTime.MinValue;
            }

            objOrder.m_strCreatorID = this.LoginInfo.m_strEmpID;
            objOrder.m_strCreator = this.LoginInfo.m_strEmpName;
            objOrder.m_strDOCTORID_CHR = clsConverter.ToString(this.m_ctlOrderDetail.m_txtDoctorList.Tag);
            objOrder.m_strDOCTOR_VCHR = this.m_ctlOrderDetail.m_txtDoctorList.Text.Trim();

            // 添加开单科室信息
            objOrder.m_strCREATEAREA_ID = Convert.ToString(m_txtCREATEAREA.Tag);
            objOrder.m_strCREATEAREA_Name = Convert.ToString(m_txtCREATEAREA.Text.Trim());

            //医生所在工作组ID
            objOrder.m_strDOCTORGROUPID_CHR = m_strDOCTORGROUPID_CHR;
            objOrder.m_strCHARGEDOCTORGROUPID = this.LoginInfo.m_strGroupID;

            //下医嘱时病人所在病区ID
            objOrder.m_strCURAREAID_CHR = this.m_ctlPatient.m_objPatient.m_strAreaID;
            //下医嘱时病人所在病床ID
            objOrder.m_strCURBEDID_CHR = this.m_ctlPatient.m_objPatient.m_strBedID;
            //病人登记号
            objOrder.m_strRegisterID = this.m_ctlPatient.m_objPatient.m_strRegisterID;
            //病人住院号
            objOrder.m_strParentID = this.m_ctlPatient.m_objPatient.m_strPatientID;
            objOrder.m_dtCreatedate = DateTime.Now;
        }

        private void m_ctxGridMenu_Popup(object sender, CancelEventArgs e)
        {

        }

        private void m_ctxGridMenu2_Opening(object sender, CancelEventArgs e)
        {
            m_mnuBlankOut2.Enabled = false;//作废
            m_mnuDelete2.Enabled = false;//删除
            m_mnuStop2.Enabled = false;//停止
            m_mnuRetract2.Enabled = false;//重整
            m_mnuCommitAll2.Enabled = false;//提交所有新建医嘱
            m_mnuCopyBihorder2.Enabled = false;//复制医嘱
            TSMenuTurnBack.Enabled = false;//作废恢复
            m_mnuDoctorSign.Enabled = false;//医生签名
            menuItem7.Enabled = false;//修改下嘱时间
            menuItem8.Enabled = false;//修改停嘱时间
            this.m_MenuPase.Enabled = false;//粘贴
            this.m_mnuCopy.Enabled = false;//复制到临时模板
            this.m_MenuOrderTemp.Enabled = false;//新增到医嘱模板
            this.m_MenuATTACHTIMES_INT.Enabled = false;//修改补次
            this.m_MenuOrderSTsign.Enabled = false;//立即执行医嘱(st标识)
            this.m_MenuCheckBill.Enabled = false;//检查申请单
            this.m_MenuViewBackReasion.Enabled = false;//查看退回原因
            this.m_MenuOutHis.Enabled = false;//出院医嘱
            //处方权
            if (m_blAccess == false)
            {
                this.m_ctxGridMenu2.Enabled = false;
                return;
            }
            /*<===========================*/
            if (fo.getTheTempCout() > 0)
            {
                this.m_MenuPase.Enabled = true;
            }
            if (m_blDoctorSign == false)
            {
                m_mnuDoctorSign.Visible = false;
            }
            //出院医嘱
            if (m_objDomain.m_intOutHisCout == 0)
            {
                this.m_MenuOutHis.Enabled = true;
            }
            /*<===============================*/
            m_mnuCommitAll2.Enabled = true;
            //存在选择医嘱后菜单
            if (m_dtvOrder.SelectedRows.Count <= 0)
            {
                return;
            }
            this.m_mnuDelete2.Enabled = true;//删除
            this.m_mnuBlankOut2.Enabled = true;//作废
            this.m_MenuOrderTemp.Enabled = true;//COPY 到临时模板
            this.m_mnuStop2.Enabled = true;//停止
            m_mnuCopyBihorder2.Enabled = true;
            m_mnuCopy2.Enabled = true;
            this.m_mnuCopy.Enabled = true;

            clsBIHOrder order = (clsBIHOrder)m_dtvOrder.SelectedRows[0].Tag;
            //医嘱类型
            clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[order.m_strOrderDicCateID];

            if (order.SIGN_INT == 0)
            {
                m_mnuDoctorSign.Enabled = true;
            }
            //查看退回
            if (order.m_intStatus == 7)
            {
                this.m_MenuViewBackReasion.Enabled = true;
            }

            int intStatus = order.m_intStatus;
            int intType = order.m_intExecuteType;


            if (m_blBlankOutControl == false) m_mnuBlankOut2.Enabled = false;
            if (m_dtvOrder.SelectedRows.Count > 0)
            {
                if (order.m_intStatus == 0 || order.m_intStatus == 1 || order.m_intStatus == 5 || order.m_intStatus == 7)
                {
                    m_MenuOrderSTsign.Enabled = true;
                    //下嘱时间菜单控制
                    TimeSpan span = DateTime.Now - order.m_dtCreatedate;
                    bool m_blTime = false;
                    if (m_intStartTimeSwitth != 0)
                    {
                        if (span.Days * 24 + span.Hours > m_intStartTimeSwitth)
                        {
                            m_blTime = false;//修改停嘱时间
                        }
                        else
                        {
                            m_blTime = true;
                        }
                    }
                    else
                    {
                        m_blTime = true;
                    }
                    menuItem7.Enabled = m_blTime;//修改下嘱时间
                    if (!((clsBIHOrder)m_dtvOrder.SelectedRows[0].Tag).m_strAPPLYTYPEID_CHR.Trim().Equals("") && !((clsBIHOrder)m_dtvOrder.SelectedRows[0].Tag).m_strPARTID_VCHR.Trim().Equals(""))
                    {
                        m_MenuCheckBill.Enabled = true;
                    }

                }
                if (order.m_intStatus == 0 || order.m_intStatus == 1 || order.m_intStatus == 5 || order.m_intStatus == 7 || (order.m_intExecuteType == 1 && order.m_intStatus == 2))
                {
                    TimeSpan span = DateTime.Now - order.m_dtCreatedate;
                    bool m_blTime = false;
                    if (m_intStopTimeSwitth != 0)
                    {
                        if (span.Days * 24 + span.Hours > m_intStopTimeSwitth)
                        {
                            m_blTime = false;//修改停嘱时间
                        }
                        else
                        {
                            m_blTime = true;
                        }
                    }
                    else
                    {
                        m_blTime = true;
                    }
                    menuItem8.Enabled = m_blTime;//修改停嘱时间
                }
                //当所选的都适合时才能补次
                bool m_blCan = false;
                for (int i = 0; i < m_dtvOrder.SelectedRows.Count; i++)
                {
                    m_blCan = m_getCanAPPENDVIEWTYPE((clsBIHOrder)m_dtvOrder.SelectedRows[i].Tag);
                    if (m_blCan == false)
                    {
                        break;
                    }

                }
                m_MenuATTACHTIMES_INT.Enabled = m_blCan;
                /*<==============================*/
            }
            //出院医嘱判断,已存在的不能再插入。
        }

        private bool m_getCanAPPENDVIEWTYPE(clsBIHOrder order)
        {
            bool m_blCan = false;
            clsBIHOrder m_objOrder = GetTheFaterOrder(order.m_intRecipenNo);
            //医嘱类型
            clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[m_objOrder.m_strOrderDicCateID];
            if (!m_blUsePowerHander(m_objOrder))
            {
                m_blCan = false;
                return m_blCan;
            }
            p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[m_objOrder.m_strOrderDicCateID];
            if (m_objOrder.m_intExecuteType == 1 && p_objItem != null && p_objItem.m_intAPPENDVIEWTYPE_INT == 1)
            {
                if ((order.m_intStatus == 0 || order.m_intStatus == 1))
                {
                    m_blCan = true;
                }
            }
            return m_blCan;

        }

        /// <summary>
        /// 方号控制是否进行子医嘱设置
        /// </summary>
        private void m_cmdSubOrderByRecipeNo()
        {
            //当前是否已选定病人
            if (m_ConfirmPatient() == 0)
            {
                return;
            }

            //初始化===========================================>
            m_ctlOrderDetail.IsSubOrder = false; //子医嘱操作标志　
            m_ctlOrderDetail.ParentOrder = null;
            //启用医嘱录入界面控件
            EnableTheBihDetailControl(true);
            /*<===============================================*/

            //对于正在进行子医嘱操作的再次子医嘱操作的初始化
            if (this.m_objCurrentOrder != null && this.m_objCurrentOrder.m_strOrderID == "")
            {
                this.m_objCurrentOrder = null;
            }
            int Count = 0;//同方医嘱的数目
            int m_intIsParent = 0;//0-不是父医嘱，１－是父医嘱
            clsBIHOrder ParentOrder = new clsBIHOrder();
            int m_intRecipeNo = 0;
            try
            {
                m_intRecipeNo = int.Parse(m_ctlOrderDetail.m_txtRecipeNo.Text.ToString().Trim());
            }
            catch
            {

                m_ctlOrderDetail.m_txtRecipeNo.Text = "";
                m_ctlOrderDetail.m_txtRecipeNo.Focus();
                return;
            }
            /*  如果同当前选中的医嘱方号相同,即不作任何处理*/
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                clsBIHOrder Order = (clsBIHOrder)m_arlOrder[this.m_dtvOrder.SelectedRows[0].Index];
            }
            bool m_blOrders = false;
            if (this.m_objCurrentOrder == null)//当前不存在当前医嘱时的子医嘱控制
            {
                for (int i = 0; i < m_arlOrder.Count; i++)//判断当前医嘱是否是可进行子医嘱操作的状态（新开或退回时）
                {
                    if (((clsBIHOrder)m_arlOrder[i]).m_intRecipenNo == m_intRecipeNo)
                    {
                        ParentOrder = (clsBIHOrder)m_arlOrder[i];
                        if (ParentOrder.m_intStatus != 0 && ParentOrder.m_intStatus != 7)
                        {
                            MessageBox.Show("不能为当前方号进行子医嘱操作!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            m_blOrders = false;
                            break;
                        }
                        m_blOrders = true;
                        break;
                    }
                }
                if (m_blOrders == false)
                {
                    m_cmdAdd_Click(null, null);
                    return;
                }
                //
                m_ctlOrderDetail.IsSubOrder = true; //子医嘱操作标志　
                m_ctlOrderDetail.ParentOrder = ParentOrder;
                SetTheNewSubOrder();
            }
            else if (this.m_objCurrentOrder.m_intRecipenNo != m_intRecipeNo)//如果方号文本框录入不是当前医嘱的方号
            {
                int i = 0;
                while (i < this.m_arlOrder.Count)
                {
                    if (((clsBIHOrder)this.m_arlOrder[i]).m_intRecipenNo == this.m_objCurrentOrder.m_intRecipenNo)
                    {
                        Count++;
                    }
                    //如果当前方号医嘱是父医嘱且存在子医嘱记录
                    if (((clsBIHOrder)this.m_arlOrder[i]).m_strParentID == this.m_objCurrentOrder.m_strOrderID)
                    {
                        m_intIsParent = 1;
                        if (Count > 0)
                            break;
                    }
                    i++;
                }
                if ((Count > 0) && (m_intIsParent == 1))
                {
                    MessageBox.Show("存在子医嘱的父医嘱方号不允许修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.m_ctlOrderDetail.m_txtRecipeNo.Text = this.m_objCurrentOrder.m_intRecipenNo.ToString();
                    this.m_ctlOrderDetail.m_txtRecipeNo.Focus();
                }
                else
                {
                    m_blOrders = false;//新增子医嘱的操作(false-不是，true-是　)
                    for (i = 0; i < this.m_arlOrder.Count; i++)
                    {
                        //当前医嘱是否是进行（新增的子医嘱操作）
                        if ((((clsBIHOrder)this.m_arlOrder[i]).m_strOrderID != this.m_objCurrentOrder.m_strOrderID) && (((clsBIHOrder)this.m_arlOrder[i]).m_intRecipenNo == m_intRecipeNo))
                        {
                            ParentOrder = (clsBIHOrder)this.m_arlOrder[i];
                            m_blOrders = true;
                            break;
                        }
                    }
                    if (!m_blOrders)//不做其它处理
                    {

                    }
                    else//当前医嘱为新增子医嘱的操作
                    {
                        m_ctlOrderDetail.IsSubOrder = true; //子医嘱操作标志　
                        m_ctlOrderDetail.ParentOrder = ParentOrder;
                        SetTheOldSubOrder();
                    }
                }
            }

        }

        /// <summary>
        /// 方号控制是否进行子医嘱设置
        /// </summary>
        private void m_cmdSubOrderByRecipeNo2()
        {
            //当前是否已选定病人
            if (m_ConfirmPatient() == 0)
            {
                return;
            }

            //初始化===========================================>
            if (m_ctlOrderDetail.m_objCurrentOrder != null)//修改操作，非子医嘱操作将返回
            {
                return;
            }
            m_ctlOrderDetail.IsSubOrder = false; //子医嘱操作标志　
            m_ctlOrderDetail.ParentOrder = null;
            int m_intRecipeNo = 0;
            try
            {
                m_intRecipeNo = int.Parse(m_ctlOrderDetail.m_txtRecipeNo.Text.ToString().Trim());
            }
            catch
            {

                m_ctlOrderDetail.m_txtRecipeNo.Text = m_objDomain.m_intBigRecipeNo.ToString();
                return;
            }
            //判断当前医嘱是否是可进行子医嘱操作的状态（新开或退回时）并设置父医嘱
            bool m_blOrders = IsSudOrderManager(m_intRecipeNo);

            if (m_blOrders == false)//不能进行子医嘱操作，作新医嘱操作
            {
                return;
            }
            #region 子医嘱操作


            SetTheNewSubOrder();//设置父医嘱的到界面的内容
            //医嘱录入方式界面控制
            int m_intExecuteType = clsConverter.ToInt(m_ctlOrderDetail.m_cboExecuteType.m_strGetID(m_ctlOrderDetail.m_cboExecuteType.SelectedIndex));
            m_ctlOrderDetail.m_cboExecuteTypeChanged(m_intExecuteType);
            //中药界面控制
            //中药服数显示(即天数控件的控制显示，共用字段)
            if (m_ctlOrderDetail.ParentOrder != null)
            {
                clsT_aid_bih_ordercate_VO p_objItem;
                p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[m_ctlOrderDetail.ParentOrder.m_strOrderDicCateID];

                if (p_objItem.m_strORDERCATEID_CHR.Equals(m_objSpecateVo.m_strMID_MEDICINE_CHR))
                {
                    m_ctlOrderDetail.m_txtMid_MedicineControl(true);

                }
            }
            /*<============================================*/

            /*<=============================*/
            //同方医嘱修改时的界面控制
            EnableTheBihDetailControl(false);
            m_objDomain.m_SetDisplayOrderEditState(3);
            //跳转定位
            m_ctlOrderDetail.setTheControlOrder("m_cboExecuteType");
            SendKeys.Send("{Enter}");
            /*<================*/
            #endregion

            //子医嘱对医嘱LABEL的控制
            if (m_ctlOrderDetail.IsSubOrder == true)
            {
                m_ctlOrderDetail.m_lblSaveOrderID.Text = "同方医嘱";
            }

        }

        /// <summary>
        ///判断当前医嘱是否是可进行子医嘱操作的状态（新开或退回时）
        /// </summary>
        /// <returns></returns>
        public bool IsSudOrderManager(int m_intRecipeNo)
        {
            clsBIHOrder ParentOrder = null;
            bool m_blOrders = false;
            for (int i = 0; i < this.m_dtvOrder.RowCount; i++)//判断当前医嘱是否是可进行子医嘱操作的状态（新开或退回时）
            {
                ParentOrder = (clsBIHOrder)m_dtvOrder.Rows[i].Tag;
                if (ParentOrder.m_intRecipenNo == m_intRecipeNo)
                {
                    m_blOrders = true;
                    break;
                }
            }
            m_ctlOrderDetail.IsSubOrder = true; //子医嘱操作标志　
            m_ctlOrderDetail.ParentOrder = ParentOrder;
            return m_blOrders;
        }

        /// <summary>
        /// 启用或禁用 子医嘱录入界面的控件
        /// </summary>
        public void EnableTheBihDetailControl(bool m_blTag)
        {
            if (m_blTag)//启用
            {
                this.m_ctlOrderDetail.m_cboExecuteType.Enabled = true;//医嘱方式
                //this.m_ctlOrderDetail.m_txtExecuteFreq.Enabled = true;//频率输入
                //this.m_ctlOrderDetail.m_txtExecuteFreq.BackColor = Color.White;
                //this.m_ctlOrderDetail.m_txtDosageType.Enabled = true;//用法输入
                //this.m_ctlOrderDetail.m_txtDosageType.BackColor = Color.White;
                //this.m_ctlOrderDetail.m_dtStartTime2.Enabled = true;//开始时间
                //this.m_ctlOrderDetail.m_dtFinishTime2.Enabled = true;//结束时间
                //this.m_ctlOrderDetail.m_txtDoctorList.Enabled = true;//医生录入
                //this.m_ctlOrderDetail.m_txtDoctorList.BackColor = Color.White;
                //this.m_ctlOrderDetail.m_txtATTACHTIMES_INT.Enabled = true;//补次
                //this.m_ctlOrderDetail.m_txtREMARK_VCHR.Enabled = true;//说明
                //this.m_ctlOrderDetail.m_txtREMARK_VCHR.BackColor = Color.White;
            }
            else//禁用
            {
                this.m_ctlOrderDetail.m_cboExecuteType.Enabled = false;//医嘱方式
                //this.m_ctlOrderDetail.m_txtExecuteFreq.Enabled = false;//频率输入
                //this.m_ctlOrderDetail.m_txtExecuteFreq.BackColor = SystemColors.Control;
                //this.m_ctlOrderDetail.m_txtDosageType.Enabled = false;//用法输入
                //this.m_ctlOrderDetail.m_txtDosageType.BackColor = SystemColors.Control;
                //this.m_ctlOrderDetail.m_dtStartTime2.Enabled = false;//开始时间
                //this.m_ctlOrderDetail.m_dtStartTime2.BackColor = SystemColors.Control;
                //this.m_ctlOrderDetail.m_dtFinishTime2.Enabled = false;//结束时间
                //this.m_ctlOrderDetail.m_dtFinishTime2.BackColor = SystemColors.Control;
                //this.m_ctlOrderDetail.m_txtDoctorList.Enabled = false;//医生录入
                //this.m_ctlOrderDetail.m_txtDoctorList.BackColor = SystemColors.Control;
                //this.m_ctlOrderDetail.m_txtATTACHTIMES_INT.Enabled = false;//补次
                //this.m_ctlOrderDetail.m_txtREMARK_VCHR.Enabled = false;//说明
                //this.m_ctlOrderDetail.m_txtREMARK_VCHR.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// 新开子医嘱的界面控制
        /// </summary>
        /// <param name="ParentOrder"></param>
        private void SetTheNewSubOrder()
        {
            //子医嘱操作的初始化界面  
            //初始化医嘱输入界面
            m_ctlOrderDetail.EmptyInput();
            ////医嘱类型改变时的控制(长嘱/临嘱/出院带药)
            //this.m_ctlOrderDetail.m_cboExecuteType_SelectedIndexChanged(null, null);

            m_objCurrentOrder = new clsBIHOrder();
            clsBIHOrder ParentOrder = m_ctlOrderDetail.ParentOrder;
            m_objCurrentOrder.m_intExecuteType = ParentOrder.m_intExecuteType;
            m_objCurrentOrder.m_intRecipenNo = ParentOrder.m_intRecipenNo;//方号
            m_objCurrentOrder.m_intRecipenNo2 = ParentOrder.m_intRecipenNo2;//显示的方号
            m_objCurrentOrder.m_strDosetypeID = ParentOrder.m_strDosetypeID;
            m_objCurrentOrder.m_dtStartDate = ParentOrder.m_dtStartDate;
            m_objCurrentOrder.m_dtFinishDate = ParentOrder.m_dtFinishDate;
            m_objCurrentOrder.m_strEntrust = ParentOrder.m_strEntrust;
            ////如果当前医嘱是子医嘱,取其父医嘱作为父医嘱
            //if (ParentOrder.m_strParentID.Trim() != "")
            //{
            //    m_objCurrentOrder.m_strParentID = ParentOrder.m_strParentID;
            //    m_objCurrentOrder.m_strParentName = ParentOrder.m_strParentName;
            //}
            //else
            //{
            //    m_objCurrentOrder.m_strParentID = ParentOrder.m_strOrderID;
            //    m_objCurrentOrder.m_strParentName = ParentOrder.m_strName;
            //}
            //如果当前医嘱是子医嘱,取其父医嘱作为父医嘱
            if (ParentOrder.m_strParentID.Trim() != "" && ParentIDOrderHave(ParentOrder))
            {
                this.m_ctlOrderDetail.m_txtFatherOrder.Text = ParentOrder.m_strParentName;
                this.m_ctlOrderDetail.m_txtFatherOrder.Tag = ParentOrder.m_strParentID;
                this.m_objCurrentOrder.m_strParentID = ParentOrder.m_strParentID;
                this.m_objCurrentOrder.m_strParentName = ParentOrder.m_strParentName;
            }
            else
            {
                this.m_ctlOrderDetail.m_txtFatherOrder.Text = ParentOrder.m_strName;
                this.m_ctlOrderDetail.m_txtFatherOrder.Tag = ParentOrder.m_strOrderID;
                this.m_objCurrentOrder.m_strParentID = ParentOrder.m_strOrderID;
                this.m_objCurrentOrder.m_strParentName = ParentOrder.m_strName;

            }
            m_objCurrentOrder.m_strDosetypeName = ParentOrder.m_strDosetypeName;
            m_objCurrentOrder.m_strExecFreqID = ParentOrder.m_strExecFreqID;
            m_objCurrentOrder.m_strExecFreqName = ParentOrder.m_strExecFreqName;
            /* 检验*/
            m_objCurrentOrder.m_strSAMPLEName_VCHR = ParentOrder.m_strSAMPLEName_VCHR.ToString().Trim();
            m_objCurrentOrder.m_strSAMPLEID_VCHR = ParentOrder.m_strSAMPLEID_VCHR.ToString().Trim();
            /* 检查*/
            m_objCurrentOrder.m_strPARTNAME_VCHR = ParentOrder.m_strPARTNAME_VCHR.ToString().Trim();
            m_objCurrentOrder.m_strPARTID_VCHR = ParentOrder.m_strPARTID_VCHR.ToString().Trim();
            //天数/服数
            m_objCurrentOrder.m_intOUTGETMEDDAYS_INT = ParentOrder.m_intOUTGETMEDDAYS_INT;
            m_objCurrentOrder.m_strPatientID = ParentOrder.m_strPatientID;
            //补次
            m_objCurrentOrder.m_intATTACHTIMES_INT = ParentOrder.m_intATTACHTIMES_INT;
            //主治医生
            m_objCurrentOrder.m_strDOCTORID_CHR = ParentOrder.m_strDOCTORID_CHR;
            m_objCurrentOrder.m_strDOCTOR_VCHR = ParentOrder.m_strDOCTOR_VCHR;

            m_intCurrentRow = -1;
            //显示医嘱明细界面信息
            m_mthShowCurrentOrder(m_objCurrentOrder);
            m_ctlOrderDetail.m_mthSetDoctor(m_objCurrentDoctor.m_strDoctorID, m_objCurrentDoctor.m_strDoctorName);

            m_ctlOrderDetail.m_txtOrderName.Enabled = true;
            m_ctlOrderDetail.m_txtOrderName.BackColor = System.Drawing.Color.White;

            this.m_cmdSave.Enabled = true;
        }

        /// <summary>
        /// 对已有医嘱进行方号改变成另一医嘱的子医嘱时的界面控制
        /// </summary>
        /// <param name="ParentOrder"></param>
        private void SetTheOldSubOrder()
        {
            //子医嘱操作的初始化界面 ===========================>
            //医嘱类型改变时的控制(长嘱/临嘱/出院带药)
            this.m_ctlOrderDetail.m_cboExecuteType_SelectedIndexChanged(null, null);
            //禁用 子医嘱录入界面的控件
            //EnableTheBihDetailControl(false);
            /*<==================================================*/
            clsBIHOrder ParentOrder = m_ctlOrderDetail.ParentOrder;
            //如果当前医嘱是子医嘱,取其父医嘱作为父医嘱
            if (ParentOrder.m_strParentID.Trim() != "" && ParentIDOrderHave(ParentOrder))
            {
                this.m_ctlOrderDetail.m_txtFatherOrder.Text = ParentOrder.m_strParentName;
                this.m_ctlOrderDetail.m_txtFatherOrder.Tag = ParentOrder.m_strParentID;
                this.m_objCurrentOrder.m_strParentID = ParentOrder.m_strParentID;
                this.m_objCurrentOrder.m_strParentName = ParentOrder.m_strParentName;
            }
            else
            {
                this.m_ctlOrderDetail.m_txtFatherOrder.Text = ParentOrder.m_strName;
                this.m_ctlOrderDetail.m_txtFatherOrder.Tag = ParentOrder.m_strOrderID;
                this.m_objCurrentOrder.m_strParentID = ParentOrder.m_strOrderID;
                this.m_objCurrentOrder.m_strParentName = ParentOrder.m_strName;
            }

            this.m_ctlOrderDetail.m_cboExecuteType.SelectedIndex = ParentOrder.m_intExecuteType - 1;
            this.m_ctlOrderDetail.m_txtDosageType.Tag = ParentOrder.m_strDosetypeID;
            this.m_ctlOrderDetail.m_txtDosageType.Text = ParentOrder.m_strDosetypeName;
            this.m_ctlOrderDetail.m_txtExecuteFreq.Tag = ParentOrder.m_strExecFreqID;
            this.m_ctlOrderDetail.m_txtExecuteFreq.Text = ParentOrder.m_strExecFreqName;
            //补次
            this.m_ctlOrderDetail.m_txtATTACHTIMES_INT.Text = ParentOrder.m_intATTACHTIMES_INT.ToString();
            //主治医生
            this.m_ctlOrderDetail.m_txtDoctorList.Text = ParentOrder.m_strDOCTOR_VCHR;
            this.m_ctlOrderDetail.m_txtDoctorList.Tag = ParentOrder.m_strDOCTORID_CHR;


            if (ParentOrder.m_dtStartDate != DateTime.MinValue)
            {
                this.m_ctlOrderDetail.m_dtStartTime2.Text = ParentOrder.m_dtStartDate.ToString("yyyy年MM月dd日HH时mm分");
            }
            else
            {
                this.m_ctlOrderDetail.m_dtStartTime2.Text = "";
            }
            if (ParentOrder.m_dtFinishDate != DateTime.MinValue)
            {
                this.m_ctlOrderDetail.m_dtFinishTime2.Text = ParentOrder.m_dtFinishDate.ToString("yyyy年MM月dd日HH时mm分");
            }
            else
            {
                this.m_ctlOrderDetail.m_dtFinishTime2.Text = "";
            }
            //this.m_ctlOrderDetail.m_cboExecuteType.Enabled = false;
            //this.m_ctlOrderDetail.m_txtExecuteFreq.Enabled = false;
            //this.m_ctlOrderDetail.m_txtExecuteFreq.BackColor = SystemColors.Control;
            //this.m_ctlOrderDetail.m_txtDosageType.Enabled = false;
            //this.m_ctlOrderDetail.m_txtDosageType.BackColor = SystemColors.Control;
            //this.m_ctlOrderDetail.m_dtStartTime2.Enabled = false;
            //this.m_ctlOrderDetail.m_dtFinishTime2.Enabled = false;



        }

        /// <summary>
        /// 当前医嘱的父医嘱是否存在当前医嘱列表中
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        private bool ParentIDOrderHave(clsBIHOrder Order)
        {
            bool m_blHave = false;
            for (int i = 0; i < this.m_dtvOrder.RowCount; i++)
            {
                if (((clsBIHOrder)this.m_dtvOrder.Rows[i].Tag).m_strOrderID == Order.m_strParentID)
                {
                    m_blHave = true;
                    break;
                }
            }
            return m_blHave;
        }

        private void m_ctlOrderDetail_m_evtInputNO(object sender, EventArgs e)
        {
            m_cmdSubOrderByRecipeNo2();
        }

        #region 折分医嘱界面
        /* add by wjwqin(06-7-21)*/
        public void m_mthShow(string m_strClass)
        {
            switch (m_strClass)
            {
                case "-1"://长嘱/临嘱界面m_strView
                    //MessageBox.Show("-1");
                    m_strView = "0";
                    m_intSOURCETYPE_INT = 1;
                    break;
                case "0"://长嘱/临嘱界面m_strView
                    //MessageBox.Show("0");
                    m_strView = "0";
                    break;
                case "1"://长嘱界面
                    //MessageBox.Show("1");
                    m_strView = "1";

                    break;
                case "2"://临嘱界面
                    //MessageBox.Show("2");
                    m_strView = "2";
                    break;
                case "3"://医嘱由电子病历打开
                    m_strView = "3";
                    break;
            }

            this.Show();


        }


        #endregion

        /// <summary>
        /// 长嘱界面控制
        /// </summary>
        public void LongBihorderSet()
        {
            m_rdoAllType.Checked = false;
            m_rdoLongType.Checked = true;
            m_rdoAllType.Enabled = false;
            m_rdoTempType.Enabled = false;
            m_ctlOrderDetail.m_cboExecuteType.SelectedIndex = 0;
            m_ctlOrderDetail.m_cboExecuteType.Enabled = false;
        }
        /*<===========================================*/
        /// <summary>
        /// 临嘱界面控制
        /// </summary>
        public void ShortBihorderSet()
        {
            m_rdoAllType.Checked = false;
            m_rdoLongType.Checked = false;

            m_rdoLongType.Enabled = false;
            m_rdoAllType.Enabled = false;

            m_rdoTempType.Enabled = true;
            m_rdoTempType.Checked = true;

            m_ctlOrderDetail.m_cboExecuteType.SelectedIndex = 1;
            m_ctlOrderDetail.m_cboExecuteType.Enabled = false;
        }

        private void m_cmdChgView_Click(object sender, EventArgs e)
        {
            //长/临界面控制 
            if (m_cmdChgView.Tag == null)
            {
                m_cmdChgView.Tag = "0";
            }
            string m_strState = (string)m_cmdChgView.Tag;
            if (m_strState.Equals("1") || m_strState.Equals("0"))
            {
                m_strView = "1";
                LongBihorderSet();

            }
            else if (m_strState.Equals("2"))
            {
                m_strView = "2";
                ShortBihorderSet();

            }

            /*<========================*/
            cmdRefurbish_Click(null, null);
            setTheChgViewButton();
        }

        public void setTheChgViewButton()
        {
            if (m_cmdChgView.Tag == null)
            {
                m_cmdChgView.Tag = "0";
            }
            switch ((string)m_cmdChgView.Tag)
            {
                case "0":
                    m_cmdChgView.Text = "转到临嘱";
                    m_cmdChgView.Tag = "2";
                    break;
                case "1":
                    m_cmdChgView.Text = "转到临嘱";
                    m_cmdChgView.Tag = "2";
                    break;
                case "2":
                    m_cmdChgView.Text = "转到长嘱";
                    m_cmdChgView.Tag = "1";
                    break;
                default:
                    m_cmdChgView.Text = "长/临嘱";
                    m_cmdChgView.Tag = "0";
                    break;
            }
        }


        private void frmBIHOrderInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_blAccess == false)
            {
                e.Cancel = false;
                return;
            }
            for (int i1 = 0; i1 < m_dtvOrder.RowCount; i1++)
            {
                clsBIHOrder order1 = (clsBIHOrder)m_dtvOrder.Rows[i1].Tag;
                if (order1.m_intStatus == 0 && order1.m_strCreatorID.Trim().Equals(this.LoginInfo.m_strEmpID))
                {
                    if (MessageBox.Show("有医嘱尚未提交，是否提交医嘱？", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        e.Cancel = true;

                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (e.Cancel == true)
            {
                m_cmdToCommit_Click(null, null);
            }
            if (e.Cancel == false)
            {
                if (MessageBox.Show("确定要退出当前医嘱输入吗？", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;

                }
                else
                {
                    e.Cancel = true;

                }
            }

        }

        private void m_cboOrderList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.m_objDomain.m_mthLoadOrderList();
            this.Cursor = Cursors.Default;
            //同步医嘱类型操作
            if (m_ctlOrderDetail.m_objCurrentOrder == null)//修改操作，非子医嘱操作将返回
            {
                if (m_cboOrderList.SelectedIndex >= 1 && m_cboOrderList.SelectedIndex <= 3)
                {
                    m_ctlOrderDetail.m_cboExecuteType.SelectedIndex = m_cboOrderList.SelectedIndex - 1;
                }
            }
        }

        private void m_cmdChange_Click(object sender, EventArgs e)
        {
            CurrentBihOrderChanged();
        }

        #region 病区事件

        private void m_txtCREATEAREA_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            clsBIHArea[] arrArea;
            long ret = m_objService.m_lngFindArea(strFindCode, out arrArea);
            if ((ret > 0) && (arrArea != null))
            {
                //获取有权限访问的病区ID集合
                if (this.m_objLoginInfo != null)
                {
                    IList ilUsableAreaID = this.m_objLoginInfo.m_ilUsableAreaID;
                    clsDcl_InputOrder objInputOrder = new clsDcl_InputOrder();
                    arrArea = (clsBIHArea[])(objInputOrder.GetUsableAreaObject(arrArea, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < arrArea.Length; i++)
                {
                    /** @update by xzf (05-09-20)
                     * 
                     */
                    ListViewItem lvi = lvwList.Items.Add(arrArea[i].code);
                    lvi.SubItems.Add(arrArea[i].m_strAreaName);
                    /* <<================================== */
                    lvi.Tag = arrArea[i].m_strAreaID;
                }
            }
        }

        private void m_txtCREATEAREA_m_evtInitListView(ListView lvwList)
        {
            //@lvwList.Columns.Add("",120,HorizontalAlignment.Left);
            //@lvwList.Width=140;
            /** update by xzf (05-09-20) */
            lvwList.Columns.Add("病区编号", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("病区名称", 100, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 180;
            /* <<================================= */
        }

        private void m_txtCREATEAREA_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_txtCREATEAREA.Text = lviSelected.SubItems[1].Text;
                m_txtCREATEAREA.Tag = lviSelected.Tag;


            }
        }

        #endregion

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            this.m_cboOrderList.SelectedIndex = 6;
            m_cboOrderList_SelectionChangeCommitted(null, null);
        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            this.m_cboOrderList.SelectedIndex = 6;
            m_cboOrderList_SelectionChangeCommitted(null, null);
        }

        private void m_dtvOrder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    m_dtgOrder_m_evtCurrentCellChanged(null, null);
                    e.Handled = true;
                    break;
                case Keys.PageDown:
                    m_dtgOrder_m_evtCurrentCellChanged(null, null);
                    e.Handled = true;
                    break;
            }

        }

        public void m_dtvOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (m_IsDisPlayToolTip)
            {
                System.Drawing.Point pt = new Point();
                pt.Offset(this.m_dtvOrder.Location.X, this.m_dtvOrder.Location.Y);
                System.Drawing.Point po;
                m_poToolTip = new System.Drawing.Point(pt.X, pt.Y + 20 + 66);
                //费用信息
                DisplayToolTip(m_poToolTip);
            }
        }

        private void TSMenuTurnBack_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            m_objDomain.BihOrderDrawBack(((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag).m_strOrderID);
        }

        internal void m_objGetChangedOrder(ref clsBIHOrder objOrder)
        {
            m_ctlOrderDetail.m_objGetChangedOrder(m_ctlPatient.m_objPatient, ref objOrder);
        }

        internal void m_cmdMoneyCount_Click(object sender, EventArgs e)
        {
            decimal m_decMoney = 0;
            clsBIHPatientInfo objPatient = m_ctlPatient.m_objPatient;
            if (objPatient == null)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            long m_lngRef = m_objDomain.m_lngMoneyCountNewOrder(objPatient.m_strRegisterID, out m_decMoney);
            this.Cursor = Cursors.Default;
            if (m_lngRef > 0)
            {
                frmSelectBox selectBox = new frmSelectBox(m_decMoney, 7);
                selectBox.ShowDialog();
            }
        }

        internal void m_cmdDelete2_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string m_strMessage = "";
            ArrayList m_arrOrderSameNo;
            m_blComfirmDeleteMessage(out m_strMessage, out m_arrOrderSameNo);
            if (!m_strMessage.Trim().Equals(""))
            {
                MessageBox.Show(m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //删除医嘱
            if (m_arrOrderSameNo.Count <= 0)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("确认进行删除操作吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    ArrayList m_arrOrderIDs = new ArrayList();//连续性医嘱要删除费用
                    ArrayList m_arrContinue = new ArrayList();//连续性医嘱要删除费用
                    List<string> lstOrderId_Lis = new List<string>(); //删除检验申请单
                    for (int i = 0; i < m_arrOrderSameNo.Count; i++)
                    {
                        m_arrOrderIDs.Add(((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderID);
                        if (m_objSpecateVo.m_strCONFREQID_CHR.Trim().Equals(((clsBIHOrder)m_arrOrderSameNo[i]).m_strExecFreqID.Trim()))
                        {
                            m_arrContinue.Add(((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderID);
                        }

                        if (((clsBIHOrder)m_arrOrderSameNo[i]).m_intStatus != 0 && m_objSpecateVo.m_strORDERCATEID_LIS_CHR.Trim().Equals(((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderDicCateID))
                        {
                            lstOrderId_Lis.Add(((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderID);
                        }
                    }
                    List<string> lstSameGroupOrderId = new List<string>();
                    if (lstOrderId_Lis.Count > 0)
                    {
                        List<string> lstTmpId = new List<string>();
                        using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                        {
                            foreach (string orderId in lstOrderId_Lis)
                            {
                                lstTmpId = svc.GetSameGroupLisOrderId(orderId);
                                if (lstTmpId.Count > 0)
                                {
                                    lstSameGroupOrderId.AddRange(lstTmpId);
                                }
                            }
                        }
                        if (lstSameGroupOrderId.Count > 0)
                        {
                            string orderName = string.Empty;
                            for (int i = 0; i < this.m_dtvOrder.RowCount; i++)
                            {
                                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                                if (lstSameGroupOrderId.IndexOf(order.m_strOrderID) >= 0)
                                {
                                    orderName += order.m_strName + Environment.NewLine;
                                }
                            }
                            if (MessageBox.Show("本次删除将同时删除以下同组检验申请项目：" + Environment.NewLine + orderName + Environment.NewLine + Environment.NewLine + "是否继续（需要手工再录入此医嘱）？？", "警告！！！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                            lstOrderId_Lis.AddRange(lstSameGroupOrderId);
                        }
                        //删除检验申请单
                        clsBIHLis obj = new clsBIHLis();
                        bool m_blOK = false;
                        foreach (string orderId in lstOrderId_Lis)
                        {
                            m_blOK = obj.m_mthDeleteApp(orderId, out m_strMessage);
                            if (!m_blOK)
                            {
                                m_arrContinue.Remove(orderId);
                                m_arrOrderIDs.Remove(orderId);
                                MessageBox.Show("操作失败! " + m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }

                    string[] m_strOrderID = null;
                    List<string> lstOrderId = new List<string>();
                    if (m_arrOrderIDs.Count > 0)
                    {
                        //m_strOrderID = (string[])m_arrOrderIDs.ToArray(typeof(string));
                        lstOrderId.AddRange((string[])m_arrOrderIDs.ToArray(typeof(string)));
                    }
                    if (lstSameGroupOrderId.Count > 0)
                    {
                        lstOrderId.AddRange(lstSameGroupOrderId);
                    }

                    string[] m_strOrderID2 = null;
                    if (m_arrContinue.Count > 0)
                    {
                        m_strOrderID2 = (string[])m_arrContinue.ToArray(typeof(string));
                    }

                    if (lstOrderId.Count > 0) m_strOrderID = lstOrderId.ToArray();
                    long m_lngRef = m_objDomain.m_lngDeleteOrder(m_strOrderID, m_strOrderID2);
                    this.Cursor = Cursors.Default;
                    if (m_lngRef > 0)
                    {
                        //MessageBox.Show("操作成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objDomain.m_mthLoadOrderList();
                    }
                }
            }
        }

        /// <summary>
        /// 作废医嘱
        /// </summary>
        internal void m_lngBlankOut()
        {
            if (this.m_dtvOrder.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string m_strMessage = "";
            ArrayList m_arrOrderSameNo;
            string m_strAlert = m_blComfirmBlankOutMessage(out m_strMessage, out m_arrOrderSameNo);
            if (!m_strMessage.Trim().Equals(""))
            {
                MessageBox.Show(m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //作废医嘱
            if (m_arrOrderSameNo.Count <= 0)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("确认进行作废操作吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ArrayList m_arrOrderIDs = new ArrayList();//连续性医嘱要删除费用
                    ArrayList m_arrLis = new ArrayList();//删除检验申请单
                    for (int i = 0; i < m_arrOrderSameNo.Count; i++)
                    {
                        m_arrOrderIDs.Add(((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderID);
                        if (((clsBIHOrder)m_arrOrderSameNo[i]).m_intStatus != 0 && m_objSpecateVo.m_strORDERCATEID_LIS_CHR.Trim().Equals(((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderDicCateID))
                        {
                            m_arrLis.Add(((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderID);
                        }
                    }

                    //删除检验申请单
                    clsBIHLis obj = new clsBIHLis();
                    bool m_blOK = false;
                    for (int i = 0; i < m_arrLis.Count; i++)
                    {
                        m_blOK = obj.m_mthDeleteApp((string)m_arrLis[i], out m_strMessage);
                        if (!m_blOK)
                        {
                            m_arrOrderIDs.Remove((string)m_arrLis[i]);
                            MessageBox.Show("操作失败! " + m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    string[] m_strOrderID = null;
                    if (m_arrOrderIDs.Count > 0)
                    {
                        m_strOrderID = (string[])m_arrOrderIDs.ToArray(typeof(string));
                    }
                    if (m_strOrderID == null)
                    {
                        return;
                    }
                    long m_lngRef = m_objDomain.m_lngBlankOutOrder(m_strOrderID, this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName);
                    if (m_lngRef > 0)
                    {
                        if (!m_strAlert.Trim().Equals(""))//对于已执行医嘱的作废后的退费提示
                        {
                            m_strAlert = "对于下列医嘱须进行退费,请通知人员进行退费操作!" + m_strAlert;
                        }
                        m_strAlert = "操作成功!" + "\r\n" + m_strAlert;
                        MessageBox.Show(m_strAlert, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objDomain.m_mthLoadOrderList();
                    }
                }
            }
        }

        /// <summary>
        /// 停止医嘱
        /// </summary>
        internal void m_lngStopOrder()
        {
            if (this.m_dtvOrder.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string m_strMessage = "";
            ArrayList m_arrOrderSameNo;
            m_blComfirmStopOrderMessage(out m_strMessage, out m_arrOrderSameNo);
            if (!m_strMessage.Trim().Equals(""))
            {
                MessageBox.Show(m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //停止医嘱
            if (m_arrOrderSameNo.Count <= 0)
            {
                return;
            }
            else
            {
                bool m_blComfirm = false;
                string m_strComfirmId = "";
                string m_strComfirmer = "";

                if (m_blStopTipControl == true)
                {
                    #region 员工号输入审核提示

                    string empid = "";
                    string empname = "";

                    DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(this.LoginInfo.m_strEmpNo, out empid, out empname);
                    if (dlg == DialogResult.Yes)
                    {
                        m_strComfirmId = empid;
                        m_strComfirmer = empname;
                        m_blComfirm = true;
                    }
                    else
                    {
                        return;
                    }

                    //DotorComfirmBox comfirmBox1 = new DotorComfirmBox();
                    //comfirmBox1.m_txtName.Text = this.LoginInfo.m_strEmpNo;
                    //comfirmBox1.m_txtPassword.Focus();
                    //if (comfirmBox1.ShowDialog() == DialogResult.OK)
                    //{
                    //    m_strComfirmId = comfirmBox1.empid_chr;//更改当前录入人ID
                    //    m_strComfirmer = comfirmBox1.lastname_vchr;//更改当前录入人名称
                    //    m_blComfirm = true;
                    //}

                    #endregion
                }
                else
                {
                    if (MessageBox.Show("确认进行停止操作吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        m_strComfirmId = this.LoginInfo.m_strEmpID;//更改当前录入人ID
                        m_strComfirmer = this.LoginInfo.m_strEmpName;//更改当前录入人名称
                        m_blComfirm = true;
                    }
                }
                if (m_blComfirm == true)
                {
                    string[] m_strOrderID = new string[m_arrOrderSameNo.Count];
                    ArrayList m_arrOrderID = new ArrayList();
                    for (int i = 0; i < m_arrOrderSameNo.Count; i++)
                    {
                        m_strOrderID[i] = ((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderID;
                        m_arrOrderID.Add(m_strOrderID[i]);
                    }
                    long m_lngRef = m_objDomain.m_lngStopOrder(m_strOrderID, m_strComfirmId, m_strComfirmer);
                    if (m_lngRef > 0)
                    {
                        MessageBox.Show("操作成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int i = 0; i < this.m_dtvOrder.Rows.Count; i++)
                        {
                            if (m_arrOrderID.Contains(((clsBIHOrder)this.m_dtvOrder.Rows[i].Tag).m_strOrderID))
                            {
                                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                                order.m_intStatus = 3;
                                order.m_dtFinishDate = DateTime.Now;
                                order.m_dtStopdate = DateTime.Now;
                                order.m_strStoperID = m_strComfirmId;
                                order.m_strStoper = m_strComfirmer;
                                this.m_objDomain.m_objGetDataViewRow(order, this.m_dtvOrder.Rows[i], i + 1);
                            }
                        }
                        //刷新同方医嘱的方号颜色
                        this.m_objDomain.m_mthRefreshSameReqNoColor();
                    }
                }
            }

        }
        /// <summary>
        ///  判断当前选中的医嘱是否可以进行删除操作
        /// </summary>
        /// <returns></returns>
        private void m_blComfirmDeleteMessage(out string m_strMessage, out ArrayList m_arrOrderSameNo)
        {
            m_arrOrderSameNo = new ArrayList();
            m_arrOrderSameNo = getSelectRowItemWithSon();

            #region 刷新当前医嘱数据，然后再判断

            ArrayList m_arrORDERID_CHR = new ArrayList();
            string m_strOrderID = "";
            for (int i = 0; i < m_arrOrderSameNo.Count; i++)
            {
                m_strOrderID = ((clsBIHOrder)m_arrOrderSameNo[i]).m_strOrderID;
                if (!m_arrORDERID_CHR.Contains(m_strOrderID))
                {
                    m_arrORDERID_CHR.Add(m_strOrderID);
                }
            }

            clsBIHOrder[] arrOrder = null;
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            m_objService.m_lngGetArrOrderByOrderID(m_arrORDERID_CHR, out arrOrder);
            if (arrOrder != null && arrOrder.Length > 0)
            {
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    clsBIHOrder order = arrOrder[i];
                    DataGridViewRow row = GetTheGridRowByOrder(order.m_strOrderID);
                    this.m_objDomain.m_objGetDataViewRow(order, row, row.Index + 1);
                }
                m_arrOrderSameNo = new ArrayList();
                m_arrOrderSameNo = getSelectRowItemWithSon();
            }

            this.m_objDomain.m_mthRefreshSameReqNoColor();
            #endregion

            m_strMessage = "";
            string m_strMessage2 = "", m_strMessage3 = "";
            for (int i = 0; i < m_arrOrderSameNo.Count; i++)
            {
                clsBIHOrder BihOrder = (clsBIHOrder)m_arrOrderSameNo[i];
                if (BihOrder.m_strCreatorID == this.LoginInfo.m_strEmpID || BihOrder.m_strDOCTORID_CHR == this.LoginInfo.m_strEmpID)
                {

                }
                else
                {
                    m_strMessage2 += "\r\n" + "  { " + BihOrder.m_strName + " }";
                }
                if (BihOrder.m_intStatus == 0 || BihOrder.m_intStatus == 1 || BihOrder.m_intStatus == 7)
                {

                }
                else if (BihOrder.m_intTYPE_INT == 3 || BihOrder.m_intTYPE_INT == 4 || BihOrder.m_intTYPE_INT == 2 || BihOrder.m_intTYPE_INT == 1)
                {
                }
                else
                {
                    m_strMessage3 += "\r\n" + "  { " + BihOrder.m_strName + " }";
                }
            }
            if (!m_strMessage2.Trim().Equals(""))
            {
                m_strMessage2 = "\r\n" + " 没有足够权限删除以下医嘱" + m_strMessage2;
            }
            if (!m_strMessage3.Trim().Equals(""))
            {
                m_strMessage3 = "\r\n" + " 不能删除当前状态的医嘱" + m_strMessage3;
            }
            m_strMessage = m_strMessage2 + m_strMessage3;
        }

        /// <summary>
        ///  判断当前选中的医嘱是否可以进行作废操作
        /// </summary>
        /// <returns></returns>
        private string m_blComfirmBlankOutMessage(out string m_strMessage, out ArrayList m_arrOrderSameNo)
        {
            m_arrOrderSameNo = new ArrayList();
            m_arrOrderSameNo = getSelectRowItemWithSon();
            m_strMessage = "";
            string m_strMessage2 = "", m_strMessage3 = "", m_strMessage4 = "";
            // 已报告/有条形码检验医嘱不能作废
            clsBIHLis obj = new clsBIHLis();
            clsT_OPR_LIS_SAMPLE_VO objSample = new clsT_OPR_LIS_SAMPLE_VO();

            for (int i = 0; i < m_arrOrderSameNo.Count; i++)
            {
                clsBIHOrder BihOrder = (clsBIHOrder)m_arrOrderSameNo[i];
                objSample = null;
                if (!string.IsNullOrEmpty(BihOrder.m_strLISAPPLYUNITID_CHR) && !string.IsNullOrEmpty(BihOrder.m_strOrderID))
                {
                    obj.m_mthGetLisSample(BihOrder.m_strOrderID, out objSample);
                }

                if (objSample != null)
                {
                    if (objSample.m_intSTATUS_INT > 2 && objSample.m_intSTATUS_INT < 7 && !string.IsNullOrEmpty(objSample.m_strBARCODE_VCHR))
                    {
                        m_strMessage3 += "\r\n" + "  { " + BihOrder.m_strName + " }";//不能作废
                        continue;
                    }
                    else
                    { }
                }
                if (BihOrder.m_intStatus == 0 || BihOrder.m_intStatus == 1 || BihOrder.m_intStatus == 5 || BihOrder.m_intStatus == 7 || (BihOrder.m_intStatus == 2 && BihOrder.m_intExecuteType == 2))
                {
                    if (BihOrder.m_intStatus == 2)
                    {
                        m_strMessage4 += "\r\n" + "  { " + BihOrder.m_strName + " }";
                    }
                }
                else
                {
                    m_strMessage3 += "\r\n" + "  { " + BihOrder.m_strName + " }";
                }
            }
            if (!m_strMessage2.Trim().Equals(""))
            {
                m_strMessage2 = "\r\n" + " 没有足够权限作废以下医嘱" + m_strMessage2;
            }
            if (!m_strMessage3.Trim().Equals(""))
            {
                m_strMessage3 = "\r\n" + " 只能作废新开,提交,退回或临嘱已执行的医嘱,已核收标本或已报告的检验医嘱不能作废" + m_strMessage3;
            }
            m_strMessage = m_strMessage2 + m_strMessage3;
            return m_strMessage4;
        }

        /// <summary>
        ///  判断当前选中的医嘱是否可以进行停止操作
        /// </summary>
        /// <returns></returns>
        private void m_blComfirmStopOrderMessage(out string m_strMessage, out ArrayList m_arrOrderSameNo)
        {
            m_arrOrderSameNo = new ArrayList();
            m_arrOrderSameNo = getSelectRowItemWithSon();
            m_strMessage = "";
            string m_strMessage2 = "", m_strMessage3 = "";
            for (int i = 0; i < m_arrOrderSameNo.Count; i++)
            {
                clsBIHOrder BihOrder = (clsBIHOrder)m_arrOrderSameNo[i];
                if (m_blCanChangeOrder == false)
                {
                    if (BihOrder.m_strCreatorID == this.LoginInfo.m_strEmpID || BihOrder.m_strDOCTORID_CHR == this.LoginInfo.m_strEmpID)
                    {
                    }
                    else
                    {
                        m_strMessage2 += "\r\n" + "  { " + BihOrder.m_strName + " }";
                    }
                }
                if (BihOrder.m_intStatus == 2 && BihOrder.m_intExecuteType == 1)
                {
                }
                else
                {
                    m_strMessage3 += "\r\n" + "  { " + BihOrder.m_strName + " }";
                }
            }
            if (!m_strMessage2.Trim().Equals(""))
            {
                m_strMessage2 = "\r\n" + " 没有足够权限处理以下医嘱" + m_strMessage2;
            }
            if (!m_strMessage3.Trim().Equals(""))
            {
                m_strMessage3 = "\r\n" + " 只能对未停的长嘱进行此操作,以下医嘱不符合条件 " + m_strMessage3;
            }
            m_strMessage = m_strMessage2 + m_strMessage3;
        }

        /// <summary>
        /// 得到选中的医嘱（包括父子医嘱）
        /// </summary>
        /// <returns></returns>
        public ArrayList getSelectRowItemWithSon()
        {
            ArrayList m_arrOrderSameNo = new ArrayList();
            ArrayList m_arrRecipenNo = new ArrayList();
            for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                if (m_arrRecipenNo.Contains(order.m_intRecipenNo.ToString()) == false)
                {
                    m_arrRecipenNo.Add(order.m_intRecipenNo.ToString());
                }
            }
            bool m_blCan = true;//对于中药的，选中的才做删除处理，同方但没有选中的不处理
            for (int i = 0; i < this.m_dtvOrder.RowCount; i++)
            {
                m_blCan = true;
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                if (!this.m_dtvOrder.Rows[i].Selected)
                {
                    m_blCan = false;
                }
                if (m_arrRecipenNo.Contains(order.m_intRecipenNo.ToString()) && m_blCan)
                {
                    m_arrOrderSameNo.Add(order);
                }
            }
            return m_arrOrderSameNo;
        }




        public void m_mnuDoctorSign_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string empid = "";
            string empname = "";

            DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out empid, out empname);
            if (dlg == DialogResult.Yes)
            {
                if (!((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag).m_strDOCTORID_CHR.Equals(empid))
                {
                    MessageBox.Show("只能是本医嘱的医生进行签名!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                long lngRes = m_objDomain.m_mthCurrentOrderDoctorSign((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag, empid, empname);
                if (lngRes > 0)
                {
                    MessageBox.Show("签名成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag).SIGN_INT = 1;
                    clsBIHOrder objOrder = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
                    if (objOrder.SIGN_INT == 1)
                    {
                        this.m_dtvOrder.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Black;
                        this.m_dtvOrder.DefaultCellStyle.SelectionForeColor = selectOldColor;
                    }
                    if (objOrder.SIGN_GRP != null && objOrder.SIGN_INT == 1)
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(objOrder.SIGN_GRP);
                        Bitmap m_bpSign = new Bitmap(ms);
                        this.m_dtvOrder.SelectedRows[0].Cells["dtv_DOCTOR_SIGN"].Value = m_bpSign;

                        ms.Close();
                    }
                    else
                    {
                        this.m_dtvOrder.SelectedRows[0].Cells["dtv_DOCTOR_SIGN"].Style.NullValue = null;
                        this.m_dtvOrder.SelectedRows[0].Cells["dtv_DOCTOR_SIGN"].Value = null;
                    }
                }
            }

            #region
            //DotorComfirmBox comfirmBox1 = new DotorComfirmBox();
            //if (comfirmBox1.ShowDialog() == DialogResult.OK)
            //{
            //    if (!((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag).m_strDOCTORID_CHR.Equals(comfirmBox1.empid_chr))
            //    {
            //        MessageBox.Show("只能是本医嘱的医生进行签名!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        return;
            //    }
            //    long lngRes = m_objDomain.m_mthCurrentOrderDoctorSign((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag, comfirmBox1.empid_chr, comfirmBox1.lastname_vchr);
            //    if (lngRes > 0)
            //    {
            //        MessageBox.Show("签名成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag).SIGN_INT = 1;
            //        clsBIHOrder objOrder=(clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
            //        if (objOrder.SIGN_INT == 1)
            //        {
            //            this.m_dtvOrder.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Black;
            //            this.m_dtvOrder.DefaultCellStyle.SelectionForeColor = selectOldColor;
            //        }
            //        if (objOrder.SIGN_GRP != null && objOrder.SIGN_INT == 1)
            //        {
            //            System.IO.MemoryStream ms = new System.IO.MemoryStream(objOrder.SIGN_GRP);
            //            Bitmap m_bpSign = new Bitmap(ms);
            //            this.m_dtvOrder.SelectedRows[0].Cells["dtv_DOCTOR_SIGN"].Value = m_bpSign;

            //            ms.Close();
            //        }
            //        else
            //        {
            //            this.m_dtvOrder.SelectedRows[0].Cells["dtv_DOCTOR_SIGN"].Style.NullValue = null;
            //            this.m_dtvOrder.SelectedRows[0].Cells["dtv_DOCTOR_SIGN"].Value = null;
            //        }
            //     }
            //}
            //comfirmBox1.Close();
            #endregion
        }

        private void m_dtvOrder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void m_mthFillApplyInfo(out clsApplyRecord objApplyVO)
        {
            objApplyVO = new clsApplyRecord();
            objApplyVO.m_datApplyDate = DateTime.Now;
            objApplyVO.m_strAddress = "";
            objApplyVO.m_strAge = m_ctlPatient.m_objPatient.m_intAge.ToString();
            objApplyVO.m_strCardNO = m_ctlPatient.m_objPatient.m_strPATIENTCARDID_CHR;
            objApplyVO.m_strDiagnose = m_ctlPatient.m_objPatient.m_strDiagnose;
            objApplyVO.m_strDoctorName = m_ctlPatient.m_objPatient.m_strDOCTOR_VCHR;
            objApplyVO.m_strDoctorNO = m_ctlPatient.m_objPatient.m_strDOCTORNO_CHR;
            objApplyVO.m_strDoctorID = m_ctlPatient.m_objPatient.m_strDOCTORID_CHR;
            objApplyVO.m_strName = m_ctlPatient.m_objPatient.m_strPatientName;
            objApplyVO.m_strSex = m_ctlPatient.m_objPatient.m_strSex;
            objApplyVO.m_strTel = m_ctlPatient.m_objPatient.m_strHOMEPHONE_VCHR;
            objApplyVO.m_objAttachRelation.m_intSysFrom = 2;
            objApplyVO.m_strDeptID = m_ctlPatient.m_objPatient.m_strDeptID;
            objApplyVO.m_strArea = m_ctlPatient.m_objPatient.m_strAreaName;
            objApplyVO.m_strAreaID = m_ctlPatient.m_objPatient.m_strAreaID;
            objApplyVO.m_intSubmitted = 1;

        }

        /// <summary>
        /// 同步病人从床位管理转入时的病区及床位界面同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_ctlPatient_m_evtPatientFromBedAdmin(object sender, EventArgs e)
        {
            clsBIHPatientInfo objPatient = m_ctlPatient.m_objPatient;
            // )年龄
            if (objPatient != null)
            {
                clsBIHArea clsArea = new clsBIHArea();
                clsArea.m_strAreaID = objPatient.m_strAreaID;
                clsArea.m_strAreaName = objPatient.m_strAreaName;

                clsBIHBed clsBed = new clsBIHBed();
                clsBed.m_strBedID = objPatient.m_strBedID;
                clsBed.m_strBedName = objPatient.m_strBedName;

                m_ctlOrderDetail.m_txtArea.Tag = clsArea;
                m_ctlOrderDetail.m_txtArea.Text = clsArea.m_strAreaName;

                m_ctlOrderDetail.m_txtBedNo.Tag = clsBed;
                m_ctlOrderDetail.m_txtBedNo.Text = clsBed.m_strBedName;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改医嘱开始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem4_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                ArrayList m_arrOrder = new ArrayList();//待修改补次的数组
                for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                    if (!m_blUsePowerHander(order))
                    {
                        continue;
                    }
                    if (order.m_intStatus == 0 || order.m_intStatus == 1 || order.m_intStatus == 5 || order.m_intStatus == 7)
                    {
                        m_arrOrder.Add(order);
                    }
                }
                if (m_arrOrder.Count > 0)
                {
                    frmSelectBox selectBox = new frmSelectBox(((clsBIHOrder)m_arrOrder[0]), 0);
                    if (selectBox.ShowDialog() == DialogResult.Yes)
                    {

                        DateTime m_dtPostdate = selectBox.m_datValue;
                        for (int i = 0; i < m_arrOrder.Count; i++)
                        {
                            if (((clsBIHOrder)m_arrOrder[i]).m_dtFinishDate > DateTime.MinValue && m_dtPostdate > ((clsBIHOrder)m_arrOrder[i]).m_dtFinishDate)
                            {
                                MessageBox.Show("下嘱时间不能大于停嘱时间!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        for (int i = 0; i < m_arrOrder.Count; i++)
                        {
                            ((clsBIHOrder)m_arrOrder[i]).m_dtPostdate = m_dtPostdate;
                        }
                        clsBIHORDERCHARGEDService m_objManager = new clsDcl_GetSvcObject().m_GetBIHORDERCHARGEDSvc();
                        long lngRef = m_objManager.m_lngUpdateOrderBeginDate((clsBIHOrder[])(m_arrOrder.ToArray(typeof(clsBIHOrder))));
                        if (lngRef > 0)
                        {
                            MessageBox.Show("更改成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int k = 0; k < m_arrOrder.Count; k++)
                            {
                                ArrayList m_arrOrders = GetTheSameNoOrders(((clsBIHOrder)m_arrOrder[k]).m_intRecipenNo);
                                for (int i = 0; i < m_arrOrders.Count; i++)
                                {

                                    clsBIHOrder m_objOrder = (clsBIHOrder)m_arrOrders[i];
                                    m_objOrder.m_dtPostdate = m_dtPostdate;
                                    DataGridViewRow row = GetTheGridRowByOrder(m_objOrder.m_strOrderID);
                                    this.m_objDomain.m_objGetDataViewRow(m_objOrder, row, row.Index + 1);
                                    if (m_intStarClickCout % 2 == 0)//显示年
                                    {
                                        row.Cells["m_dtPOSTDATE_DAT"].Value = DateTimeToShortDateString(m_objOrder.m_dtPostdate);
                                    }
                                    else//不显示年
                                    {
                                        row.Cells["m_dtPOSTDATE_DAT"].Value = DateTimeToCutYearDateString(m_objOrder.m_dtPostdate);
                                    }
                                }
                            }
                            //刷新同方医嘱的方号颜色
                            this.m_objDomain.m_mthRefreshSameReqNoColor();
                            /*<======================*/
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有可修改下嘱时间的医嘱!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        public string DateTimeToString(DateTime dtValue)
        {
            if (dtValue.Date == DateTime.MinValue)
                return "";
            else
                return dtValue.ToString("yyyy-MM-dd HH:mm");
        }

        public string DateTimeToShortDateString(DateTime dtValue)
        {
            if (dtValue.Date == DateTime.MinValue)
                return "";
            else
                return dtValue.ToString("yy-MM-dd HH:mm");
        }

        public string DateTimeToCutYearDateString(DateTime dtValue)
        {
            if (dtValue.Date == DateTime.MinValue)
                return "";
            else
                return dtValue.ToString("MM-dd HH:mm");
        }

        /// <summary>
        /// 修改停嘱时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem5_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                ArrayList m_arrOrder = new ArrayList();//待修改补次的数组

                for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                    if (!m_blUsePowerHander(order))
                    {
                        continue;
                    }
                    if (order.m_intStatus == 0 || order.m_intStatus == 1 || order.m_intStatus == 5 || order.m_intStatus == 7 || (order.m_intExecuteType == 1 && order.m_intStatus == 2))
                    {
                        m_arrOrder.Add(order);
                    }
                }
                if (m_arrOrder.Count > 0)
                {
                    frmSelectBox selectBox = new frmSelectBox(((clsBIHOrder)m_arrOrder[0]), 1);
                    if (selectBox.ShowDialog() == DialogResult.Yes)
                    {

                        DateTime m_dtFinishDate = selectBox.m_datValue;
                        for (int i = 0; i < m_arrOrder.Count; i++)
                        {
                            if (m_dtFinishDate < ((clsBIHOrder)m_arrOrder[i]).m_dtStartDate && ((clsBIHOrder)m_arrOrder[i]).m_intStatus != 2)
                            {
                                MessageBox.Show("结束时间不能少于开始时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else if (m_dtFinishDate < ((clsBIHOrder)m_arrOrder[i]).m_dtExecutedate && ((clsBIHOrder)m_arrOrder[i]).m_intStatus == 2)
                            {
                                MessageBox.Show("已执行的医嘱　结束时间不能少于执行的时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        for (int i = 0; i < m_arrOrder.Count; i++)
                        {

                            ((clsBIHOrder)m_arrOrder[i]).m_dtFinishDate = m_dtFinishDate;
                        }
                        clsBIHORDERCHARGEDService m_objManager = new clsDcl_GetSvcObject().m_GetBIHORDERCHARGEDSvc();
                        long lngRef = m_objManager.m_lngUpdateOrderEndDate((clsBIHOrder[])(m_arrOrder.ToArray(typeof(clsBIHOrder))));
                        if (lngRef > 0)
                        {
                            MessageBox.Show("更改成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int k = 0; k < m_arrOrder.Count; k++)
                            {
                                ArrayList m_arrOrders = GetTheSameNoOrders(((clsBIHOrder)m_arrOrder[k]).m_intRecipenNo);
                                for (int i = 0; i < m_arrOrders.Count; i++)
                                {

                                    clsBIHOrder m_objOrder = (clsBIHOrder)m_arrOrders[i];
                                    m_objOrder.m_dtFinishDate = m_dtFinishDate;
                                    DataGridViewRow row = GetTheGridRowByOrder(m_objOrder.m_strOrderID);
                                    this.m_objDomain.m_objGetDataViewRow(m_objOrder, row, row.Index + 1);
                                    if (m_intStarClickCout % 2 == 0)//显示年
                                    {
                                        row.Cells["dtv_FinishDate"].Value = DateTimeToShortDateString(m_objOrder.m_dtFinishDate);
                                    }
                                    else//不显示年
                                    {
                                        row.Cells["dtv_FinishDate"].Value = DateTimeToCutYearDateString(m_objOrder.m_dtFinishDate);
                                    }

                                }
                            }
                            //刷新同方医嘱的方号颜色
                            this.m_objDomain.m_mthRefreshSameReqNoColor();
                            /*<======================*/
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有可修改停嘱时间的医嘱!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void menuItemStopAll_Click(object sender, EventArgs e)
        {
            if (this.m_ctlPatient.m_objPatient != null)
            {
                int m_intCount = 0;
                m_objDomain.m_lngGetNotExecuteOrderByRegID(this.m_ctlPatient.m_objPatient.m_strRegisterID, out m_intCount);
                if (m_intCount > 0)
                {
                    MessageBox.Show("当前病人有未执行的医嘱，请处理后再停所有医嘱?", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("确定停止所有医嘱（提醒：该病人所有医嘱将会被停止）吗?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (m_objDomain.m_lngStopAllOrderByRegID(this.m_ctlPatient.m_objPatient.m_strRegisterID, this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName))
                    {
                        this.m_objDomain.m_mthLoadOrderList();
                    }
                }
            }

        }

        private void m_MenuCopy_Click(object sender, EventArgs e)
        {
            //if (!this.m_dtvOrder.Focus())
            //{
            //    return;
            //}
            if (fo.frmParent == null)
            {
                fo.frmParent = (frmBIHOrderInput)panel4.Parent;
            }
            ArrayList m_arrOrder = GetTheSelectItemWithSon();
            if (m_arrOrder.Count > 0)
            {
                //检查医嘱是否停用
                ArrayList m_arrOrderIDs = new ArrayList();
                for (int i = 0; i < m_arrOrder.Count; i++)
                {
                    if (!m_arrOrderIDs.Contains(((clsBIHOrder)m_arrOrder[i]).m_strOrderID))
                    {
                        m_arrOrderIDs.Add(((clsBIHOrder)m_arrOrder[i]).m_strOrderID);
                    }
                }
                ArrayList m_strOrders = GetTheStopOrders(m_arrOrderIDs);
                if (m_strOrders != null && m_arrOrder.Count > 0)
                {
                    string m_strErrMessage = "";
                    for (int i = 0; i < m_arrOrder.Count; i++)
                    {
                        clsBIHOrder order = (clsBIHOrder)m_arrOrder[i];
                        if (m_strOrders.Contains(order.m_strOrderID))
                        {
                            m_strErrMessage += order.m_strName + "\r\n";
                        }
                    }
                    if (!m_strErrMessage.Trim().Equals(""))
                    {
                        m_strErrMessage = "以下医嘱因相关收费项目停用或药品停药,不能进行复制!" + "\r\n" + m_strErrMessage;
                        MessageBox.Show(m_strErrMessage, "医嘱复制", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                /*<==================================*/
                fo.m_lngAddOrderGroupTempList(m_arrOrder);
            }
        }

        /// <summary>
        /// 返回当前停用或停药的医嘱流水数组
        /// </summary>
        /// <param name="m_arrOrderIDs"></param>
        /// <returns></returns>
        private ArrayList GetTheStopOrders(ArrayList m_arrOrderIDs)
        {
            ArrayList m_arrStopOrderIds = new ArrayList();
            if (m_arrOrderIDs.Count <= 0)
            {
                return m_arrStopOrderIds;
            }
            string[] m_strOrders = (string[])m_arrOrderIDs.ToArray(typeof(string));
            DataTable m_dtOrderSign = null;
            m_objDomain.m_lngGetOrderStopSign(m_strOrders, out m_dtOrderSign);
            if (m_dtOrderSign != null)
            {
                string orderid_chr = "";
                string STATUS_INT = "";//(诊疗项目状态 0-停用 1-正常)
                string IFSTOP_INT = "";//停用标志 1-停用 0-正常
                string ITEMSRCTYPE_INT = "";//项目来源类型1－药品表
                string IPNOQTYFLAG_INT = "";//中心药房缺药标志 0-有药 1－缺药
                bool m_blStop = false;
                for (int i = 0; i < m_dtOrderSign.Rows.Count; i++)
                {
                    m_blStop = false;
                    DataRow row = m_dtOrderSign.Rows[i];
                    orderid_chr = row["orderid_chr"].ToString().Trim();
                    STATUS_INT = row["STATUS_INT"].ToString().Trim();//(诊疗项目状态 0-停用 1-正常)
                    IFSTOP_INT = row["IFSTOP_INT"].ToString().Trim();//停用标志 1-停用 0-正常
                    ITEMSRCTYPE_INT = row["ITEMSRCTYPE_INT"].ToString().Trim();//项目来源类型1－药品表
                    IPNOQTYFLAG_INT = row["IPNOQTYFLAG_INT"].ToString().Trim();//中心药房缺药标志 0-有药 1－缺药
                    if ((STATUS_INT.Equals("0") || IFSTOP_INT.Equals("1")))
                    {
                        if (!m_blStopControl)
                        {
                            m_blStop = true;
                        }
                    }

                    if (!m_blDeableMedControl)
                    {
                        if (ITEMSRCTYPE_INT.Equals("1") && IPNOQTYFLAG_INT.Equals("1"))
                        {
                            m_blStop = true;
                        }
                    }


                    if (m_blStop)
                    {
                        if (!m_arrStopOrderIds.Contains(orderid_chr))
                        {
                            m_arrStopOrderIds.Add(orderid_chr);
                        }
                    }

                }

            }
            return m_arrStopOrderIds;

        }



        private void m_MenuPase_Click(object sender, EventArgs e)
        {
            if (!this.m_dtvOrder.Focus())
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            fo.m_cmdParseOrder();
            this.Cursor = Cursors.Default;
        }

        private void m_MenuATTACHTIMES_INT_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                ArrayList m_arrOrder = new ArrayList();//待修改补次的数组

                for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
                {
                    //clsBIHOrder order = GetTheFaterOrder(((clsBIHOrder)m_dtvOrder.SelectedRows[i].Tag).m_intRecipenNo);

                    //  // clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                    //   if (!m_blUsePowerHander(order))
                    //   {
                    //       continue;
                    //   }
                    //   p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[order.m_strOrderDicCateID];
                    //   if (m_objOrder.m_intExecuteType == 1 && p_objItem != null && p_objItem.m_intAPPENDVIEWTYPE_INT == 1)

                    //   if (order.m_intExecuteType==1&&(order.m_intStatus == 0 || order.m_intStatus == 1 || order.m_intStatus == 5))
                    //   {
                    //       m_arrOrder.Add(order);
                    //   }
                    clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                    if (m_getCanAPPENDVIEWTYPE(order) == true)
                    {
                        m_arrOrder.Add(order);
                    }
                }
                if (m_arrOrder.Count > 0)
                {

                    frmSelectBox selectBox = new frmSelectBox(((clsBIHOrder)m_arrOrder[0]).m_intATTACHTIMES_INT, 4);
                    if (selectBox.ShowDialog() == DialogResult.Yes)
                    {

                        int m_intATTACHTIMES_INT = selectBox.m_intATTACHTIMES_INT;
                        for (int i = 0; i < m_arrOrder.Count; i++)
                        {
                            ((clsBIHOrder)m_arrOrder[i]).m_intATTACHTIMES_INT = m_intATTACHTIMES_INT;
                        }
                        //clsBIHORDERCHARGEDService m_objManager = clsGenerator.CreateObject(typeof(clsBIHORDERCHARGEDService)) as clsBIHORDERCHARGEDService;
                        clsBIHORDERCHARGEDService m_objManager = new clsDcl_GetSvcObject().m_GetBIHORDERCHARGEDSvc();
                        long lngRef = m_objManager.m_lngUpdateOrderATTACHTIMES((clsBIHOrder[])(m_arrOrder.ToArray(typeof(clsBIHOrder))));
                        if (lngRef > 0)
                        {
                            MessageBox.Show("更改成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int k = 0; k < m_arrOrder.Count; k++)
                            {
                                ArrayList m_arrOrders = GetTheSameNoOrders(((clsBIHOrder)m_arrOrder[k]).m_intRecipenNo);
                                for (int i = 0; i < m_arrOrders.Count; i++)
                                {

                                    clsBIHOrder m_objOrder = (clsBIHOrder)m_arrOrders[i];
                                    m_objOrder.m_intATTACHTIMES_INT = m_intATTACHTIMES_INT;
                                    DataGridViewRow row = GetTheGridRowByOrder(m_objOrder.m_strOrderID);
                                    this.m_objDomain.m_objGetDataViewRow(m_objOrder, row, row.Index + 1);

                                }
                            }
                            //刷新同方医嘱的方号颜色
                            this.m_objDomain.m_mthRefreshSameReqNoColor();
                            /*<======================*/
                        }
                        else if (lngRef == -10)
                        {
                            MessageBox.Show(this, "该医嘱已经核对转抄，不能修改补次的数量。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.cmdRefurbish_Click(null, null);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有可补次的医嘱!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        /// <summary>
        /// 根据方号返回同方医嘱数组
        /// </summary>
        /// <param name="m_intRecipenNo">方号</param>
        /// <returns></returns>
        private ArrayList GetTheSameNoOrders(int m_intRecipenNo)
        {
            ArrayList m_arrOrders = new ArrayList();
            for (int i = 0; i < this.m_dtvOrder.Rows.Count; i++)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                if (order.m_intRecipenNo == m_intRecipenNo)
                {
                    m_arrOrders.Add(order);
                }
            }
            return m_arrOrders;
        }



        private void m_MenuOPERATION_Click(object sender, EventArgs e)
        {
            if (this.m_ctlPatient.m_objPatient != null)
            {
                int m_intCount = 0;
                m_objDomain.m_lngGetNotExecuteOrderByRegID(this.m_ctlPatient.m_objPatient.m_strRegisterID, out m_intCount);
                if (m_intCount > 0)
                {
                    MessageBox.Show("当前病人有未执行的医嘱，请处理后再添加术后医嘱?", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("当前操作将插入一条术后医嘱,并停止该病人所有的医嘱,确定执行?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    clsBIHOrder order = new clsBIHOrder();
                    //为当前医嘱加上附加的信息
                    order.m_intExecuteType = 1;
                    order.m_strName = "术后医嘱";
                    order.m_intTYPE_INT = 1;
                    SetTheCurrentOrder(order);

                    if (m_objDomain.m_lngInsertOPERATIONOrder(order, this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName) > 0)
                    {
                        this.m_objDomain.m_mthLoadOrderList();
                    }

                }
            }

        }


        private void m_dtvOrder_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (this.m_dtvOrder.Columns[e.ColumnIndex].Name.Trim().Equals("m_dtPOSTDATE_DAT"))
            {
                m_intStarClickCout++;
                if (m_intStarClickCout % 2 == 0)//显示年
                {
                    for (int i = 0; i < m_dtvOrder.RowCount; i++)
                    {
                        clsBIHOrder order = (clsBIHOrder)m_dtvOrder.Rows[i].Tag;
                        if (this.m_dtvOrder.Rows[i].Cells["m_dtPOSTDATE_DAT"].Value != null && !this.m_dtvOrder.Rows[i].Cells["m_dtPOSTDATE_DAT"].Value.ToString().Trim().Equals(""))
                        {
                            this.m_dtvOrder.Rows[i].Cells["m_dtPOSTDATE_DAT"].Value = this.DateTimeToShortDateString(order.m_dtPostdate);
                        }
                    }
                }
                else//不显示年
                {
                    for (int i = 0; i < m_dtvOrder.RowCount; i++)
                    {
                        clsBIHOrder order = (clsBIHOrder)m_dtvOrder.Rows[i].Tag;
                        if (this.m_dtvOrder.Rows[i].Cells["m_dtPOSTDATE_DAT"].Value != null && !this.m_dtvOrder.Rows[i].Cells["m_dtPOSTDATE_DAT"].Value.ToString().Trim().Equals(""))
                        {
                            this.m_dtvOrder.Rows[i].Cells["m_dtPOSTDATE_DAT"].Value = this.DateTimeToCutYearDateString(order.m_dtPostdate);
                        }
                    }
                }
            }
            else if (this.m_dtvOrder.Columns[e.ColumnIndex].Name.Trim().Equals("dtv_FinishDate"))
            {

                m_intFinishClickCout++;
                if (m_intFinishClickCout % 2 == 0)//显示年
                {
                    for (int i = 0; i < m_dtvOrder.RowCount; i++)
                    {
                        clsBIHOrder order = (clsBIHOrder)m_dtvOrder.Rows[i].Tag;
                        if (this.m_dtvOrder.Rows[i].Cells["dtv_FinishDate"].Value != null && !this.m_dtvOrder.Rows[i].Cells["dtv_FinishDate"].Value.ToString().Trim().Equals(""))
                        {
                            this.m_dtvOrder.Rows[i].Cells["dtv_FinishDate"].Value = this.DateTimeToShortDateString(order.m_dtFinishDate);
                        }
                    }
                }
                else//不显示年
                {
                    for (int i = 0; i < m_dtvOrder.RowCount; i++)
                    {
                        clsBIHOrder order = (clsBIHOrder)m_dtvOrder.Rows[i].Tag;
                        if (this.m_dtvOrder.Rows[i].Cells["dtv_FinishDate"].Value != null && !this.m_dtvOrder.Rows[i].Cells["dtv_FinishDate"].Value.ToString().Trim().Equals(""))
                        {
                            this.m_dtvOrder.Rows[i].Cells["dtv_FinishDate"].Value = this.DateTimeToCutYearDateString(order.m_dtFinishDate);
                        }
                    }
                }
            }
        }

        private void m_MenuOrderTemp_Click(object sender, EventArgs e)
        {
            //生成组套
            CopySelectItemtoGroup();
        }

        private void m_MenuOrderNornal_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            clsComuseorderdic m_arrOrderdic = null;
            ArrayList OrderdicList = new ArrayList();
            for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
            {

                //医嘱类型为特殊医嘱的不允许生成
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                if (!CanCopyToGroup(order))
                {
                    continue;
                }
                /*<==============================*/
                m_arrOrderdic = new clsComuseorderdic();
                m_arrOrderdic.m_strSEQID_CHR = "";
                m_arrOrderdic.m_intPRIVILEGE_INT = 0;
                m_arrOrderdic.m_intTYPE_INT = 0;
                m_arrOrderdic.m_strDEPTID_CHR = this.LoginInfo.m_strInpatientAreaID;
                m_arrOrderdic.m_strORDERDICID_CHR = order.m_strOrderDicID;
                m_arrOrderdic.m_strCREATERID_CHR = this.LoginInfo.m_strEmpID;
                //医嘱类型
                clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[order.m_strOrderDicCateID];
                if (p_objItem != null && p_objItem.m_strVIEWNAME_VCHR.Trim().Equals("文字医嘱"))
                {
                    m_arrOrderdic.m_strDES_VCHR = order.m_strName;
                }
                if (!m_arrOrderdic.m_strORDERDICID_CHR.ToString().Trim().Equals(""))
                {
                    OrderdicList.Add(m_arrOrderdic);
                }

            }
            if (OrderdicList.Count > 0)
            {
                long m_lngRef = m_objDomain.m_cmdAddOrderNornal((clsComuseorderdic[])(OrderdicList.ToArray(typeof(clsComuseorderdic))));
                if (m_lngRef > 0)
                {
                    MessageBox.Show("添加成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有合适的待添加项!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }

        private void m_MenuChangeArea_Click(object sender, EventArgs e)
        {
            if (this.m_ctlPatient.m_objPatient != null)
            {
                int m_intCount = 0;
                m_objDomain.m_lngGetNotStopOrderByRegID(this.m_ctlPatient.m_objPatient.m_strRegisterID, out m_intCount);
                if (m_intCount > 0)
                {
                    MessageBox.Show("当前病人有未停医嘱，请处理后再插入转科医嘱?", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("当前操作将插入一条转科医嘱,确定执行?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    clsBIHOrder order = new clsBIHOrder();
                    //为当前医嘱加上附加的信息
                    order.m_intExecuteType = 1;
                    order.m_strName = "转科医嘱";
                    order.m_intTYPE_INT = 2;
                    SetTheCurrentOrder(order);

                    if (m_objDomain.m_lngInsertChangeAreaOrder(order, this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName) > 0)
                    {
                        this.m_objDomain.m_mthLoadOrderList();
                    }

                }
            }
        }

        private void m_MenuReSortOrderNO_Click(object sender, EventArgs e)
        {
            if (this.m_ctlPatient.m_objPatient != null)
            {
                long ret = m_objDomain.m_lngReSortOrderNO(this.m_ctlPatient.m_objPatient.m_strRegisterID);
                if (ret > 0)
                {
                    this.m_objDomain.m_mthLoadOrderList();
                }
            }
        }

        private void m_MenuOrderSTsign_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
                if (order.m_intStatus == 0 || order.m_intStatus == 1 || order.m_intStatus == 5 || order.m_intStatus == 7)
                {
                    clsBIHOrder m_objOrder = GetTheFaterOrder(order.m_intRecipenNo);
                    if (m_objOrder != null)
                    {
                        m_objOrder.m_strREMARK_VCHR = "st " + m_objOrder.m_strREMARK_VCHR;
                        //clsBIHORDERCHARGEDService m_objManager = clsGenerator.CreateObject(typeof(clsBIHORDERCHARGEDService)) as clsBIHORDERCHARGEDService;
                        clsBIHORDERCHARGEDService m_objManager = new clsDcl_GetSvcObject().m_GetBIHORDERCHARGEDSvc();
                        long lngRef = m_objManager.m_lngUpdateOrderREMARK_VCHR(m_objOrder);
                        if (lngRef > 0)
                        {
                            MessageBox.Show("操作成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //说明
                            DataGridViewRow row = GetTheGridRowByOrder(m_objOrder.m_strOrderID);
                            if (row != null)
                            {
                                row.Cells["dtv_REMARK"].Value = m_objOrder.m_strREMARK_VCHR;
                            }

                        }
                    }
                }
            }

        }

        /// <summary>
        /// 根据当前医嘱号获得所在的行
        /// </summary>
        /// <param name="m_strOrderID"></param>
        /// <returns></returns>
        public DataGridViewRow GetTheGridRowByOrder(string m_strOrderID)
        {
            DataGridViewRow row = null;
            for (int i = 0; i < this.m_dtvOrder.RowCount; i++)
            {
                if (((clsBIHOrder)this.m_dtvOrder.Rows[i].Tag).m_strOrderID.Equals(m_strOrderID))
                {
                    row = this.m_dtvOrder.Rows[i];
                }
            }
            return row;
        }



        /// <summary>
        /// 返回父医嘱（同方下），非同方下，返回本条方号医嘱
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public clsBIHOrder GetTheFaterOrder(int m_intRecipenNo)
        {
            clsBIHOrder order = null;
            for (int i = 0; i < this.m_dtvOrder.RowCount; i++)
            {
                if (((clsBIHOrder)this.m_dtvOrder.Rows[i].Tag).m_intRecipenNo == m_intRecipenNo)
                {
                    order = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                    break;
                }
            }
            return order;
        }

        private void m_MenuCheckBillEdit_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
                if (order.m_intStatus == 0 || order.m_intStatus == 1 || order.m_intStatus == 5 || order.m_intStatus == 7)
                {
                    //clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[order.m_strOrderDicCateID];
                    //if (p_objItem.m_strVIEWNAME_VCHR.Trim().Equals("检查"))
                    //{
                    clsEMR_HIS_CheckRequisition CheckRequest = new clsEMR_HIS_CheckRequisition(order.m_strRegisterID, order.m_strOrderID);
                    CheckRequest.m_mthShowCheckRequisitionForm();
                    // }
                }
            }
        }

        private void m_MenuCheckBillView_Click(object sender, EventArgs e)
        {
            int m_intTag = 0;
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                //if (!((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag).m_strOrderDicCateName.Trim().Equals("检查"))
                //{
                //    m_intTag = 0;
                //}
                //else if (((clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag).m_intStatus != 0)
                //{
                //    m_intTag = 1;
                //}
                //else
                //{
                string m_strChargeDetail = "";
                clsBIHOrder order1 = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
                m_objDomain.m_DisPlayToolTipListView(order1, m_lsvToolTip);
                if (m_objDomain.m_htbToolTip.ContainsKey(order1.m_strOrderID.Trim()))
                {
                    ArrayList alItem = new ArrayList();
                    alItem = (m_objDomain.m_htbToolTip[order1.m_strOrderID.Trim()] as ArrayList);
                    if (alItem != null && alItem.Count > 0)
                    {
                        clsChargeForDisplay[] objItemArr = (clsChargeForDisplay[])(alItem.ToArray(typeof(clsChargeForDisplay)));
                        //加一行统计金额
                        //合计金额
                        double m_dblSum = 0;
                        for (int i = 0; i < objItemArr.Length; i++)
                        {
                            if (!double.IsInfinity(objItemArr[i].m_dblMoney))
                                m_dblSum += objItemArr[i].m_dblMoney;

                            m_strChargeDetail += objItemArr[i].m_strName + " 单价:" + objItemArr[i].m_dblPrice + " 元 " + objItemArr[i].m_dblDrawAmount + objItemArr[i].m_strUNIT_VCHR + " 合计:" + objItemArr[i].m_dblMoney + " 元";
                            m_strChargeDetail += "\r\n";
                            //if (objItemArr.Length > 0)
                            //{

                            //    ListViewItem item1 = new ListViewItem("");
                            //    item1.SubItems.Add("");
                            //    item1.SubItems.Add("");
                            //    item1.SubItems.Add("");
                            //    item1.SubItems.Add("合计:");
                            //    item1.SubItems.Add(m_dblSum.ToString("0.00"));
                            //    item1.ForeColor = Color.Red;
                            //    p_lsvToolTip.Items.Add(item1);
                            //}
                            /*<===============*/
                        }
                    }
                }
                clsEMR_HIS_CheckRequisition CheckRequest = new clsEMR_HIS_CheckRequisition(order1.m_strRegisterID, order1.m_strOrderID);
                clsEMR_HIS_CheckRequisitionValue CheckMessage = CheckRequest.m_objGetCheckRequisition();


                clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();

                clsDcl_InputOrder objInputOrder = new clsDcl_InputOrder();
                DataTable dt;
                string strTypeID = "";
                string strPartName = "";
                long l = objInputOrder.m_mthGetApplyTypeByID(order1.m_strCHARGEITEMID_CHR, out dt);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    strTypeID = dt.Rows[0]["APPLY_TYPE_INT"].ToString().Trim();
                }
                // item_VO.m_decDiscount = 0;
                item_VO.m_decPrice = order1.m_dmlPrice;
                item_VO.m_decQty = order1.m_dmlUse;
                item_VO.m_decTolPrice = order1.m_dmlGet * order1.m_dmlPrice;
                item_VO.m_strItemID = order1.m_strCHARGEITEMID_CHR;
                item_VO.m_strItemName = order1.m_strCHARGEITEMNAME_CHR;
                item_VO.m_strSpec = order1.m_strSpec;
                item_VO.m_strUnit = order1.m_strUseunit;
                item_VO.m_strOutpatRecipeID = "";
                // item_VO.m_strRowNo = p_row.ToString();
                item_VO.m_strOprDeptID = "";
                com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();
                clsApplyRecord objApplyVO;
                m_mthFillApplyInfo(out objApplyVO);
                objApplyVO.m_strTypeID = strTypeID;
                objApplyVO.m_objChargeItem = item_VO;
                objApplyVO.m_intChargeStatus = 1;
                objApplyVO.m_strDiagnosePart = order1.m_strPARTNAME_VCHR;
                objApplyVO.m_objAttachRelation.m_strSourceItemID = order1.m_strOrderID;
                ///病历摘要
                if (CheckMessage != null)
                {
                    objApplyVO.m_strSummary = CheckMessage.m_strCASESUMMARY_VCHR + "\r\n" + CheckMessage.m_strPHYSEXAM_VCHR;
                    objApplyVO.m_strDiagnose = CheckMessage.m_strADMISSIONDIAGNOSIS_VCHR;
                }
                objApplyVO.m_strDoctorID = order1.m_strCreatorID;
                objApplyVO.m_strDoctorName = order1.m_strCreator;
                objApplyVO.m_strBIHNO = m_ctlPatient.m_objPatient.m_strInHospitalNo;
                objApplyVO.m_strArea = m_ctlPatient.m_objPatient.m_strAreaName;
                objApplyVO.m_strAreaID = m_ctlPatient.m_objPatient.m_strAreaID;
                objApplyVO.m_strBedNO = m_ctlPatient.m_objPatient.m_strBedName;
                objApplyVO.m_strDeptID = m_ctlPatient.m_objPatient.m_strDeptID;
                objApplyVO.m_strDepartment = m_ctlPatient.m_objPatient.m_strDeptName;
                objfrm.mainForm.m_intFlag = 1;
                objfrm.mainForm.m_strFormTitle = "住院申请单";
                objApplyVO.m_strChargeDetail = m_strChargeDetail;
                clsCheckType[] objCTArr = objfrm.OpenWithVO(objApplyVO);

                m_intTag = -1;


                //}

            }
            //switch (m_intTag)
            //{
            //    case 0:
            //        MessageBox.Show("请先选择检查项目!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        break;
            //    case 1:
            //        MessageBox.Show("止项目已开申请单!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        break;
            //}
        }

        private void m_MenuViewBackReasion_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[0].Tag;
                frmSelectBox selectBox = new frmSelectBox(order.m_strBACKREASON, 5);
                if (selectBox.ShowDialog() == DialogResult.Yes)
                {

                }

            }
        }

        private void m_imgBackAlert_Click(object sender, EventArgs e)
        {
            this.m_cboOrderList.SelectedIndex = 11;
            m_cboOrderList_SelectionChangeCommitted(null, null);
        }

        private void m_MenuOutToday_Click(object sender, EventArgs e)
        {
            if (this.m_ctlPatient.m_objPatient != null)
            {
                //int m_intCount = 0;
                //m_objDomain.m_lngGetNotExecuteOrderByRegID(this.m_ctlPatient.m_objPatient.m_strRegisterID, out m_intCount);
                //if (m_intCount > 0)
                //{
                //    MessageBox.Show("当前病人有未执行的医嘱，请处理后再添加出院医嘱!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}


                clsBIHOrder order = new clsBIHOrder();
                //为当前医嘱加上附加的信息
                order.m_intExecuteType = 1;
                order.m_strName = "今天出院";
                order.m_intTYPE_INT = 3;
                SetTheCurrentOrder(order);

                com.digitalwave.iCare.gui.HIS.frmDiagnoses frmDialog = new frmDiagnoses("", order.m_strRegisterID, 1);
                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    bool m_blAuto = false;
                    if (MessageBox.Show("插入出院医嘱时,要自动停止该病人所有的已执行过的长期医嘱吗?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        m_blAuto = true;
                    }

                    if (m_objDomain.m_lngInsertOutHisOrder(order, this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName, m_blAuto) > 0)
                    {
                        this.m_objDomain.m_mthLoadOrderList();
                    }
                }


            }
        }

        private void m_MenuOutTomorrow_Click(object sender, EventArgs e)
        {
            if (this.m_ctlPatient.m_objPatient != null)
            {
                //int m_intCount = 0;
                //m_objDomain.m_lngGetNotExecuteOrderByRegID(this.m_ctlPatient.m_objPatient.m_strRegisterID, out m_intCount);
                //if (m_intCount > 0)
                //{
                //    MessageBox.Show("当前病人有未执行的医嘱，请处理后再添加出院医嘱!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}


                clsBIHOrder order = new clsBIHOrder();
                //为当前医嘱加上附加的信息
                order.m_intExecuteType = 1;
                order.m_strName = "明天出院";
                order.m_intTYPE_INT = 4;
                SetTheCurrentOrder(order);

                com.digitalwave.iCare.gui.HIS.frmDiagnoses frmDialog = new frmDiagnoses("", order.m_strRegisterID, 1);
                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    bool m_blAuto = false;
                    if (MessageBox.Show("插入出院医嘱时,要自动停止该病人所有的已执行过的长期医嘱吗?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        m_blAuto = true;
                    }

                    if (m_objDomain.m_lngInsertOutHisOrder(order, this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName, m_blAuto) > 0)
                    {
                        this.m_objDomain.m_mthLoadOrderList();
                    }
                }

            }
        }

        private void m_MenuCHNAGEAMOUNT_INT_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                ArrayList m_arrOrder = new ArrayList();//待修改补次的数组

                for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                    if (!m_blUsePowerHander(order))
                    {
                        continue;
                    }

                    if (order.m_intStatus == 0 || order.m_intStatus == 1 || order.m_intStatus == 5 || order.m_intStatus == 7)
                    {
                        m_arrOrder.Add(order);
                    }
                }
                if (m_arrOrder.Count > 0)
                {

                    frmSelectBox selectBox = new frmSelectBox(int.Parse(((clsBIHOrder)m_arrOrder[0]).m_dmlGet.ToString()), 6);
                    if (selectBox.ShowDialog() == DialogResult.Yes)
                    {

                        int m_intAMOUNT = selectBox.m_intATTACHTIMES_INT;
                        for (int i = 0; i < m_arrOrder.Count; i++)
                        {
                            ((clsBIHOrder)m_arrOrder[i]).m_dmlGet = decimal.Parse(m_intAMOUNT.ToString());
                        }
                        //clsBIHORDERCHARGEDService m_objManager = clsGenerator.CreateObject(typeof(clsBIHORDERCHARGEDService)) as clsBIHORDERCHARGEDService;
                        clsBIHORDERCHARGEDService m_objManager = new clsDcl_GetSvcObject().m_GetBIHORDERCHARGEDSvc();
                        long lngRef = m_objManager.m_lngUpdateOrderAmount((clsBIHOrder[])(m_arrOrder.ToArray(typeof(clsBIHOrder))));
                        if (lngRef > 0)
                        {
                            MessageBox.Show("更改成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ArrayList m_arrChangeOrderID = new ArrayList();
                            for (int k = 0; k < m_arrOrder.Count; k++)
                            {
                                ArrayList m_arrOrders = GetTheSameNoOrders(((clsBIHOrder)m_arrOrder[k]).m_intRecipenNo);
                                for (int i = 0; i < m_arrOrders.Count; i++)
                                {

                                    clsBIHOrder m_objOrder = (clsBIHOrder)m_arrOrders[i];
                                    //m_objOrder.m_intATTACHTIMES_INT = m_intATTACHTIMES_INT;
                                    DataGridViewRow row = GetTheGridRowByOrder(m_objOrder.m_strOrderID);
                                    this.m_objDomain.m_objGetDataViewRow(m_objOrder, row, row.Index + 1);
                                    m_arrChangeOrderID.Add(m_objOrder.m_strOrderID);
                                }
                            }
                            //刷新同方医嘱的方号颜色
                            this.m_objDomain.m_mthRefreshSameReqNoColor();
                            /*<======================*/
                            //刷新医嘱相关的费用信息
                            if (m_arrChangeOrderID.Count > 0)
                            {
                                this.m_objDomain.lngRefreshChargePool(m_arrChangeOrderID);
                            }
                        }
                        else if (lngRef == -10)
                        {
                            MessageBox.Show(this, "该医嘱已经执行，不能修改其数量。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.cmdRefurbish_Click(null, null);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有可修改数量的医嘱!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void m_MenuMoneyCount_Click(object sender, EventArgs e)
        {
            //if (this.m_dtvOrder.SelectedRows.Count <= 0)
            //{
            //    MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //m_objDomain.m_mthDeleteCurrentOrder(true,(clsBIHOrder) this.m_dtvOrder.SelectedRows[0].Tag);		
            m_cmdMoneyCount_Click(null, null);
        }

        private void m_MenuSeeBill_Click(object sender, EventArgs e)
        {
            if (m_ctlPatient.m_objPatient != null)
            {
                string m_strPATIENTCARDID_CHR = m_ctlPatient.m_objPatient.m_strPATIENTCARDID_CHR;
                if (!m_strPATIENTCARDID_CHR.Trim().Equals(""))
                {
                    frmShowReports frm = new frmShowReports(m_strPATIENTCARDID_CHR);
                    frm.ShowDialog();
                }
            }
        }



        private void m_txtCREATEAREA_DoubleClick(object sender, EventArgs e)
        {
            m_txtCREATEAREA.Text = "";
            SendKeys.Send("{Enter}");

        }

        private void m_pcBoxAlert_Click(object sender, EventArgs e)
        {
            if (m_ctlPatient.m_objPatient == null)
            {
                return;
            }
            frmStopOrderConfirm m_frmAlert = new frmStopOrderConfirm(m_ctlPatient.m_objPatient.m_strRegisterID);
            m_frmAlert.m_htOrderCate = this.m_htOrderCate;
            m_frmAlert.m_objSpecateVo = this.m_objSpecateVo;
            m_frmAlert.m_blStopControl = this.m_blStopControl;
            m_frmAlert.m_blDeableMedControl = this.m_blDeableMedControl;
            m_frmAlert.ShowDialog();
            cmdRefurbish_Click(null, null);
        }

        private void m_MenuSurgery_Click(object sender, EventArgs e)
        {
            Assembly assem = Assembly.LoadFrom(Application.StartupPath + @"\ANA_Requisition.dll");
            object obj = assem.CreateInstance("iCare.Anaesthesia.Requisition.frmRequisition", true);
            Type typ = obj.GetType();

            MethodInfo med = typ.GetMethod("Show", new Type[0]);


            med.Invoke(obj, null);
            if (m_ctlPatient.m_objPatient != null)
            {

                FieldInfo fld = typ.GetField("m_ctlAppDept", BindingFlags.NonPublic | BindingFlags.Instance);
                object objbutton = fld.GetValue(obj);


                PropertyInfo propInfo = typ.GetProperty("M_strAppDeptID");

                propInfo.SetValue(obj, m_ctlPatient.m_objPatient.m_strAreaID, null);
            }
        }

        private void tsmiDrugInfo_Click(object sender, EventArgs e)
        {
            if (this.m_dtvOrder.SelectedRows.Count > 0)
            {
                for (int i = 0; i < this.m_dtvOrder.SelectedRows.Count; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.SelectedRows[i].Tag;
                    m_objDomain.GetDrugInfo(order.m_strOrderDicID);
                    return;
                }
            }
        }

        private void tsbOpApplyNew_Click(object sender, EventArgs e)
        {
            if (m_ctlPatient.m_objPatient == null || string.IsNullOrEmpty(m_ctlPatient.m_objPatient.m_strRegisterID)) return;
            frmOpsApply frm = new frmOpsApply(m_ctlPatient.m_objPatient);
            frm.ShowDialog();
        }

        #region 特殊抗菌药会诊

        private void tsmiTskjyhz_apply_Click(object sender, EventArgs e)
        {
            if (m_ctlPatient.m_objPatient == null || string.IsNullOrEmpty(m_ctlPatient.m_objPatient.m_strRegisterID)) return;
            frmAntiApply frm = new frmAntiApply(m_ctlPatient.m_objPatient, 0);
            frm.ShowDialog();
        }

        private void tsmiTskjyhz_check_Click(object sender, EventArgs e)
        {
            if (m_ctlPatient.m_objPatient == null || string.IsNullOrEmpty(m_ctlPatient.m_objPatient.m_strRegisterID)) return;
            frmAntiApply frm = new frmAntiApply(m_ctlPatient.m_objPatient, 1);
            frm.ShowDialog();
        }

        private void tsmiTskjyhz_response_Click(object sender, EventArgs e)
        {
            if (m_ctlPatient.m_objPatient == null || string.IsNullOrEmpty(m_ctlPatient.m_objPatient.m_strRegisterID)) return;
            frmAntiConsultation frm = new frmAntiConsultation(m_ctlPatient.m_objPatient);
            frm.ShowDialog();
        }

        #endregion

        #region InputOrder 事件

        private void m_ctlOrderDetail_evtInputOrder(object sender, EventArgs e)
        {
            int recipeNo = 0;
            try
            {
                recipeNo = Int32.Parse(m_ctlOrderDetail.m_txtRecipeNo.Text);
            }
            catch
            {
                recipeNo = 0;

            }
            // 外送代煎判断
            bool isOk = false;
            for (int i = 0; i < this.m_dtvOrder.RowCount; i++)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_dtvOrder.Rows[i].Tag;
                if (order.m_intRecipenNo == recipeNo)
                {
                    m_ctlOrderDetail.cboProxyBoil.SelectedIndex = order.IsProxyBoilMed;
                    isOk = true;
                    break;
                }
            }
            if (isOk == false)
            {
                m_ctlOrderDetail.cboProxyBoil.SelectedIndex = (m_ctlOrderDetail.m_cboExecuteType.Text.Contains("带药") ? 0 : 1);
            }
        }
        #endregion

    }

    #region 类-医嘱输入Domain
    /// <summary>
    /// 医嘱输入Domain
    /// </summary>
    public class clsBIHOrderInputDomain : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 全局变量申明
        private frmBIHOrderInput m_frmInput;
        public clsBIHOrderService m_objService;
        private clsDcl_InputOrder m_objInputOrder;
        internal System.Drawing.Printing.PrintDocument printDoc = null;

        /// <summary>
        /// 连续性频率
        /// </summary>
        string m_strConfreqID = "";

        /// <summary>
        /// 医嘱类型数组
        /// </summary>
        public string[] m_arrOrderList = new string[] { "0-全部医嘱", "1-长期医嘱", "2-临时医嘱", "3-带药医嘱", "4-未停医嘱", "5-已停医嘱", "6-新开医嘱", "7-提交医嘱", "8-转抄医嘱", "9-执行医嘱", "10-作废医嘱", "11-退回医嘱" };

        /// <summary>
        /// 当前最大方号加1
        /// </summary>
        public int m_intBigRecipeNo = 1;
        /// <summary>
        /// 出院医嘱数目
        /// </summary>
        public int m_intOutHisCout = 0;
        /// <summary>
        /// 返回的数组包括(intCount-可提交的医嘱记录数目,MaxRecipeno-可录入的最大方号,intBackCount-退回的医嘱数目)
        /// </summary>
        public ArrayList m_arrCount = new ArrayList();
        #endregion
        #region 构造函数
        public clsBIHOrderInputDomain()
        {

        }
        public clsBIHOrderInputDomain(frmBIHOrderInput frmInput)
        {
            m_frmInput = frmInput;
            //m_objService=(clsBIHOrderService)(clsGenerator.CreateObject(typeof(clsBIHOrderService)));
            m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            m_objInputOrder = new clsDcl_InputOrder();
        }

        #endregion
        #region 清空
        public void m_mthClearOrderList()
        {
            m_frmInput.m_arlOrder.Clear();
            //m_frmInput.m_dtgOrder.m_mthDeleteAllRow();
            m_frmInput.m_dtvOrder.Rows.Clear();
            m_frmInput.m_objCurrentOrder = null;
            m_frmInput.m_intCurrentRow = -1;
            m_frmInput.m_mthShowCurrentOrder(m_frmInput.m_objCurrentOrder);
            m_mthRefreshOtherBillInfo();
            if (m_frmInput.LoginInfo != null)
            {
                m_frmInput.m_ctlOrderDetail.m_mthSetDoctor(m_frmInput.LoginInfo.m_strEmpID, m_frmInput.LoginInfo.m_strEmpName);
            }
        }
        #endregion

        #region 提醒
        /// <summary>
        /// 提醒
        /// </summary>
        internal void HintInfo()
        {
            if (m_frmInput.m_ctlPatient.m_objPatient != null)
            {
                string dayS = string.Empty;
                int dayI = 0;
                dayS = m_frmInput.m_ctlPatient.m_txtInDays.Text.Trim();
                int.TryParse(dayS, out dayI);
                if (dayI > 0)
                {
                    bool b1 = false;
                    bool b2 = false;
                    if (m_frmInput.dayGrandRounds > 0 && m_frmInput.dayGrandRounds < dayI) b1 = true;
                    if (m_frmInput.dayAverageStay > 0 && m_frmInput.dayAverageStay < dayI) b2 = true;
                    if (b1 && b2)
                    {
                        MessageBox.Show("患者姓名: " + m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName + "\r\n住院天数: " + dayS + "\r\n请安排大查房!!!\r\n\r\n" + " 超出了院平均住院天数(" + m_frmInput.dayAverageStay.ToString() + "天)\r\n请及时书写病程记录!!!", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (b1) MessageBox.Show("患者姓名: " + m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName + "\r\n住院天数: " + dayS + "\r\n请安排大查房!!!", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (b2) MessageBox.Show("患者姓名: " + m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName + "\r\n住院天数: " + dayS + " 超出了院平均住院天数(" + m_frmInput.dayAverageStay.ToString() + "天)\r\n请及时书写病程记录!!!", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion

        #region 载入 患者医嘱信息(医嘱输入主界面)
        /// <summary>
        /// 载入患者医嘱信息
        /// </summary>
        public void m_mthLoadOrderList()
        {
            if (m_frmInput.m_ctlPatient.m_objPatient == null && GlobalData.clsPublic.m_ObjGlobalPatient != null)
            {
                if (GlobalData.clsPublic.m_ObjGlobalPatient.m_strInPatientID.Trim() != "")
                {
                    m_frmInput.m_ctlPatient.m_txtInHospitalNo.Text = GlobalData.clsPublic.m_ObjGlobalPatient.m_strInPatientID;
                    m_frmInput.m_ctlPatient.m_mthGetPatientByInHospitalNo();
                    return;
                }
            }

            m_frmInput.m_blnCurrentCellChanged = false;

            //清空
            m_frmInput.Cursor = Cursors.WaitCursor;
            //刷新时先清空病人费用信息表 
            m_frmInput.m_lsvToolTip.Items.Clear();
            m_mthClearOrderList();
            clsBIHPatientInfo objPatient = m_frmInput.m_ctlPatient.m_objPatient;

            clsPatientBaseInfo_VO obj = new clsPatientBaseInfo_VO();
            obj.m_strPatientCardNO = objPatient.m_strPATIENTCARDID_CHR;
            obj.m_strPatientID = objPatient.m_strPatientID;
            obj.m_strRegisterID = objPatient.m_strRegisterID;
            obj.m_strInPatientID = objPatient.m_strInHospitalNo;
            obj.m_strDeptID = objPatient.m_strDeptID;
            obj.m_strName = objPatient.m_strPatientName;
            obj.m_strAge = objPatient.m_strAge;
            GlobalData.clsPublic.m_ObjGlobalPatient = obj;

            // 年龄
            if (objPatient != null && !m_frmInput.m_ctlPatient.m_txtBedNo.Text.Trim().Equals("") && !m_frmInput.m_ctlPatient.m_txtArea.Text.Trim().Equals(""))
            {
                m_frmInput.m_ctlOrderDetail.m_intAge = objPatient.m_intAge;
            }
            else
            {
                m_frmInput.Cursor = Cursors.Default;
                return;
            }
            if (objPatient != null)
            {
                //先初始化当前方号起始值
                m_intBigRecipeNo = 1;
                //是否医保病人
                m_frmInput.m_blnISMedicareMan = m_frmInput.m_ctlPatient.m_chkIsMedicareMan.Checked;
                m_frmInput.m_ctlOrderDetail.PatientID = objPatient.m_strPatientID;
                m_frmInput.m_ctlOrderDetail.RegisterID = objPatient.m_strRegisterID;
                m_frmInput.m_ctlOrderDetail.IsMedicareMan = m_frmInput.m_blnISMedicareMan;
                clsBIHOrderInputDomain m_objDomain = new clsBIHOrderInputDomain();
                ArrayList PARMCODE_CHR = new ArrayList();
                PARMCODE_CHR.Add("0008");
                DataTable m_dtPARMVALUE_VCHR = new DataTable();
                string str = string.Empty;
                long lngRes = m_objDomain.LoadThePARMVALUE(PARMCODE_CHR, out m_dtPARMVALUE_VCHR);
                if (m_dtPARMVALUE_VCHR.Rows.Count > 0)
                {
                    str = m_dtPARMVALUE_VCHR.Rows[0]["PARMVALUE_VCHR"].ToString();
                }
                if (str.Contains(objPatient.m_strPayTypeID))
                {
                    this.m_frmInput.m_ctlOrderDetail.cboShiying.Enabled = true;
                }
                else
                {
                    this.m_frmInput.m_ctlOrderDetail.cboShiying.Enabled = false;
                }
                int intCount = 0;//可提交的医嘱记录数目
                int intBackCount = 0;//退回的医嘱数目
                int[] arrStatus = m_frmInput.m_arrStatus;
                clsBIHOrder[] arrOrder;
                //获取医嘱	根据病人和医嘱状态 
                //long ret = this.m_objService.m_lngGetOrderByPatientAndState(objPatient.m_strRegisterID, this.m_frmInput.m_blnShowOnlyToday, this.m_frmInput.m_cboOrderList.SelectedIndex, out intCount, out m_intBigRecipeNo, out arrOrder);
                long ret = this.m_objService.m_lngGetOrderByPatientAndState2(objPatient.m_strRegisterID, this.m_frmInput.LoginInfo.m_strEmpID, this.m_frmInput.m_blnShowOnlyToday, this.m_frmInput.m_cboOrderList.SelectedIndex, out  intCount, out m_intBigRecipeNo, out  intBackCount, out m_intOutHisCout, out arrOrder);
                if ((ret > 0) && (arrOrder != null))
                {
                    //上一个医嘱的方号
                    int m_intNo = 0;
                    for (int i = 0; i < arrOrder.Length; i++)
                    {
                        m_frmInput.m_arlOrder.Add(arrOrder[i]);
                        // 同方号的子医嘱不用再显示：长/临、类别、用法、频率、状态、下嘱医生
                        this.m_frmInput.m_dtvOrder.Rows.Add();
                        DataGridViewRow objRow = this.m_frmInput.m_dtvOrder.Rows[this.m_frmInput.m_dtvOrder.RowCount - 1];
                        m_intNo = this.m_frmInput.m_dtvOrder.RowCount;
                        m_objGetDataViewRow(arrOrder[i], objRow, m_intNo);
                    }
                    //m_mthRefreshGridColor();
                    //刷新同方医嘱的方号颜色
                    m_mthRefreshSameReqNoColor();
                }
                //在最后增加一条空白的医嘱
                //this.m_frmInput.m_dtvOrder.Rows.Add();
                /*<=============================*/
                //灯显示状态可提交的医嘱数目
                if (intCount > 0)
                {
                    this.m_frmInput.pictureBox3.Visible = true;
                    this.m_frmInput.pictureBox6.Visible = true;
                    this.m_frmInput.m_cmdToCommit.Enabled = true;
                }
                else
                {
                    this.m_frmInput.pictureBox3.Visible = false;
                    this.m_frmInput.pictureBox6.Visible = false;
                    this.m_frmInput.m_cmdToCommit.Enabled = false;
                }
                //退回医嘱提示灯
                if (intBackCount > 0)
                {
                    this.m_frmInput.m_imgBackAlert.Visible = true;

                }
                else
                {
                    this.m_frmInput.m_imgBackAlert.Visible = false;
                }
                /*<========================================*/
                //诊疗卡号
                //m_frmInput.PatientCardID =m_objInputOrder.m_strGetCardIDByID(objPatient.m_strPatientID);
                //在医嘱界面切换病人后，系统也自动记录新切换的病人为选中病人。 同电子病历同步  
                ((com.digitalwave.iCare.gui.frmMain)this.m_frmInput.MdiParent).m_StrPatientID = objPatient.m_strPatientID;
            }
            ResetButtonToEnable();
            m_frmInput.m_cmdSave.Enabled = true;
            //m_mthRefreshOtherBillInfo();//附加单据

            if (this.m_frmInput.m_dtvOrder.RowCount > 0)
            {
                m_frmInput.m_dtvOrder.CurrentCell = m_frmInput.m_dtvOrder[1, this.m_frmInput.m_dtvOrder.RowCount - 1];
            }
            m_frmInput.m_cmdAdd_Click(null, null);
            m_frmInput.m_ctlOrderDetail.m_txtRecipeNo.Text = m_intBigRecipeNo.ToString();

            /*转到医嘱输入焦点*/
            // m_frmInput.m_ctlOrderDetail.m_txtOrderName.Focus();
            // m_frmInput.m_ctlOrderDetail.m_txtRecipeNo.Focus();
            m_frmInput.m_ctlOrderDetail.m_cboExecuteType.Focus();
            /*<-----------------*/
            m_frmInput.Cursor = Cursors.Default;
            m_frmInput.m_blnCurrentCellChanged = true;
            m_SetDisplayOrderEditState(0);
            //根据当前诊疗项目停用或缺药提醒
            if (m_frmInput.m_blAutoStopAlert)
            {
                OrderStopSignByRegisterId();
            }


        }

        /// <summary>
        /// 根据当前诊疗项目停用或缺药提醒
        /// </summary>
        public void OrderStopSignByRegisterId()
        {
            //停用项目，或停药项目列表
            DataTable m_dtOrderSign = null;
            ArrayList m_arrRecipenNo = new ArrayList();
            long ret = this.m_objService.m_lngGetOrderStopSignByRegisterId(m_frmInput.m_ctlPatient.m_objPatient.m_strRegisterID, out m_dtOrderSign);
            if (m_dtOrderSign != null && m_dtOrderSign.Rows.Count > 0)
            {
                ArrayList m_arrStopOrderIds = GetTheAllStopOrders(m_dtOrderSign);
                if (m_arrStopOrderIds.Count > 0)
                {

                    //if (MessageBox.Show("当前有未停医嘱已被停用或停药,要自动选中这些医嘱吗!", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    for (int i = 0; i < this.m_frmInput.m_dtvOrder.RowCount; i++)
                    //    {
                    //        if (m_arrStopOrderIds.Contains(((clsBIHOrder)this.m_frmInput.m_dtvOrder.Rows[i].Tag).m_strOrderID))
                    //        {
                    //            //this.m_frmInput.m_dtvOrder.Rows[i].Selected = true;
                    //            if (!m_arrRecipenNo.Contains(((clsBIHOrder)this.m_frmInput.m_dtvOrder.Rows[i].Tag).m_intRecipenNo.ToString()))
                    //            {
                    //                m_arrRecipenNo.Add(((clsBIHOrder)this.m_frmInput.m_dtvOrder.Rows[i].Tag).m_intRecipenNo.ToString());
                    //            }
                    //        }
                    //        else
                    //        {
                    //            //this.m_frmInput.m_dtvOrder.Rows[i].Selected = false;
                    //        }
                    //    }
                    //    //选中该病人要处理的医嘱方号
                    //    ArrayList m_arrRow = new ArrayList();
                    //    for (int i = 0; i < this.m_frmInput.m_dtvOrder.RowCount; i++)
                    //    {
                    //        this.m_frmInput.m_dtvOrder.Rows[i].Selected = false;
                    //        if (m_arrRecipenNo.Contains(((clsBIHOrder)this.m_frmInput.m_dtvOrder.Rows[i].Tag).m_intRecipenNo.ToString()))
                    //        {
                    //            clsBIHOrder order1 = (clsBIHOrder)this.m_frmInput.m_dtvOrder.Rows[i].Tag;
                    //            this.m_frmInput.m_dtvOrder.Rows.Remove(this.m_frmInput.m_dtvOrder.Rows[i]);
                    //            i--;
                    //            m_arrRow.Add(order1);
                    //        }

                    //    }
                    //    if (this.m_frmInput.m_dtvOrder.RowCount > 0)
                    //    {
                    //        this.m_frmInput.m_dtvOrder.Rows[this.m_frmInput.m_dtvOrder.RowCount - 1].Selected = false;
                    //    }

                    //    //在最后重新加上这些行，并选中
                    //    if (m_arrRow.Count > 0)
                    //    {
                    //        for (int i = 0; i < m_arrRow.Count; i++)
                    //        {
                    //            this.m_frmInput.m_dtvOrder.Rows.Add();
                    //            DataGridViewRow row = this.m_frmInput.m_dtvOrder.Rows[this.m_frmInput.m_dtvOrder.RowCount - 1];
                    //            m_objGetDataViewRow((clsBIHOrder)m_arrRow[i], row, row.Index + 1);
                    //            row.Selected = true;
                    //            if (i== 0)
                    //            {
                    //                m_frmInput.m_dtvOrder.CurrentCell = m_frmInput.m_dtvOrder[1, this.m_frmInput.m_dtvOrder.RowCount - 1];
                    //            }
                    //        }
                    //    }
                    //    //刷新同方医嘱的方号颜色
                    //    m_mthRefreshSameReqNoColor();
                    //    /*<=======================*/

                    //}
                    if (MessageBox.Show("当前有未停医嘱已被停用或停药,现在处理这些医嘱吗!", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmStopOrderConfirm m_frmAlert = new frmStopOrderConfirm(m_frmInput.m_ctlPatient.m_objPatient.m_strRegisterID);
                        m_frmAlert.m_htOrderCate = m_frmInput.m_htOrderCate;
                        m_frmAlert.m_objSpecateVo = m_frmInput.m_objSpecateVo;
                        m_frmAlert.m_blStopControl = m_frmInput.m_blStopControl;
                        m_frmAlert.m_blDeableMedControl = m_frmInput.m_blDeableMedControl;
                        m_frmAlert.ShowDialog();
                        m_frmInput.cmdRefurbish_Click(null, null);
                    }
                    m_frmInput.m_pcBoxAlert.Visible = true;
                }
                else
                {
                    m_frmInput.m_pcBoxAlert.Visible = false;
                }
            }
            /*<=============================*/
            //选中该病人要处理的医嘱方号
        }

        /// <summary>
        /// 返回当前所有停用或停药的医嘱流水数组
        /// </summary>
        /// <param name="m_arrOrderIDs"></param>
        /// <returns></returns>
        private ArrayList GetTheAllStopOrders(DataTable m_dtOrderSign)
        {
            ArrayList m_arrStopOrderIds = new ArrayList();
            ArrayList m_arrOrderIDs = new ArrayList();
            if (m_dtOrderSign != null)
            {
                string orderid_chr = "";
                string STATUS_INT = "";//(诊疗项目状态 0-停用 1-正常)
                string IFSTOP_INT = "";//停用标志 1-停用 0-正常
                string ITEMSRCTYPE_INT = "";//项目来源类型1－药品表
                string IPNOQTYFLAG_INT = "";//中心药房缺药标志 0-有药 1－缺药
                bool m_blStop = false;
                for (int i = 0; i < m_dtOrderSign.Rows.Count; i++)
                {
                    m_blStop = false;
                    DataRow row = m_dtOrderSign.Rows[i];
                    orderid_chr = row["orderid_chr"].ToString().Trim();
                    STATUS_INT = row["STATUS_INT"].ToString().Trim();//(诊疗项目状态 0-停用 1-正常)
                    IFSTOP_INT = row["IFSTOP_INT"].ToString().Trim();//停用标志 1-停用 0-正常
                    ITEMSRCTYPE_INT = row["ITEMSRCTYPE_INT"].ToString().Trim();//项目来源类型1－药品表
                    IPNOQTYFLAG_INT = row["IPNOQTYFLAG_INT"].ToString().Trim();//中心药房缺药标志 0-有药 1－缺药
                    if ((STATUS_INT.Equals("0") || IFSTOP_INT.Equals("1")))
                    {
                        if (!this.m_frmInput.m_blStopControl)
                        {
                            m_blStop = true;
                        }
                    }

                    if (!this.m_frmInput.m_blDeableMedControl)
                    {
                        if (ITEMSRCTYPE_INT.Equals("1") && IPNOQTYFLAG_INT.Equals("1"))
                        {
                            m_blStop = true;
                        }
                    }


                    if (m_blStop)
                    {
                        if (!m_arrStopOrderIds.Contains(orderid_chr))
                        {
                            m_arrStopOrderIds.Add(orderid_chr);
                        }
                    }

                }
                //if (m_arrStopOrderIds.Count > 0)
                //{
                //    m_strStopOrderIds = (string[])m_arrStopOrderIds.ToArray(typeof(string));
                //}
            }
            return m_arrStopOrderIds;

        }


        /// <summary>
        /// 刷新同方医嘱的方号颜色并隐藏相同性质的字段
        /// </summary>
        public void m_mthRefreshSameReqNoColor()
        {
            for (int i = 1; i < m_frmInput.m_dtvOrder.Rows.Count; i++)
            {
                clsBIHOrder order = (clsBIHOrder)m_frmInput.m_dtvOrder.Rows[i - 1].Tag;
                DataGridViewRow objRow = m_frmInput.m_dtvOrder.Rows[i];

                if (order.m_intRecipenNo == ((clsBIHOrder)m_frmInput.m_dtvOrder.Rows[i].Tag).m_intRecipenNo)
                {
                    //m_frmInput.m_dtvOrder.Rows[i - 1].Cells["dtv_RecipeNo"].Style.ForeColor = Color.SkyBlue;
                    //objRow.Cells["dtv_RecipeNo"].Style.ForeColor = Color.SkyBlue;
                    //隐藏的字段
                    //方号dtv_RecipeNo
                    objRow.Cells["dtv_RecipeNo"].Value = "";
                    //类型dtv_ExecuteType
                    objRow.Cells["dtv_ExecuteType"].Value = "";
                    //下嘱时间m_dtStartDate
                    //objRow.Cells["m_dtStartDate"].Value = "";
                    objRow.Cells["m_dtPOSTDATE_DAT"].Value = "";
                    //开医嘱者CREATOR_CHR
                    objRow.Cells["CREATOR_CHR"].Value = "";
                    //过医嘱者ASSESSORFOREXEC_CHR
                    objRow.Cells["ASSESSORFOREXEC_CHR"].Value = "";
                    //中药的同方也显示用法
                    if (this.m_frmInput.m_objSpecateVo.m_strMID_MEDICINE_CHR.Trim().Equals(((clsBIHOrder)objRow.Tag).m_strOrderDicCateID))//中药类型逻辑
                    {
                        //用法dtv_UseType
                        objRow.Cells["dtv_UseType"].Value = ((clsBIHOrder)objRow.Tag).m_strDosetypeName;
                        objRow.Cells["dtv_REMARK"].Value = "";
                    }
                    else
                    {
                        //用法dtv_UseType
                        objRow.Cells["dtv_UseType"].Value = "";

                    }


                    // 频率dtv_Freq
                    objRow.Cells["dtv_Freq"].Value = "";
                    //说明dtv_ENTRUST
                    //objRow.Cells["dtv_ENTRUST"].Value = "";
                    //停嘱时间dtv_FinishDate
                    objRow.Cells["dtv_FinishDate"].Value = "";
                    //停医嘱者dtv_Stoper
                    objRow.Cells["dtv_Stoper"].Value = "";
                    //过医嘱者 
                    //objRow.Cells[""].Value = "";
                    //补次ATTACHTIMES_INT
                    objRow.Cells["ATTACHTIMES_INT"].Value = "";
                    //医嘱状态STATUS_INT
                    objRow.Cells["STATUS_INT"].Value = "";
                    //执行时间dtv_StartDate
                    objRow.Cells["dtv_StartDate"].Value = "";

                    //执行人dtv_Executor
                    objRow.Cells["dtv_Executor"].Value = "";
                    //作废时间dtv_DELETE_DAT
                    objRow.Cells["dtv_DELETE_DAT"].Value = "";
                    //作废时间dtv_DELETE_DAT
                    objRow.Cells["dtv_DELETE_DAT"].Value = "";
                    //作废人dtv_DELETERNAME_VCHR
                    objRow.Cells["dtv_DELETERNAME_VCHR"].Value = "";

                    /*<=================================*/
                    //皮试
                    string m_strFeel = "";
                    if (((clsBIHOrder)objRow.Tag).m_intISNEEDFEEL == 1)
                    {

                        switch (((clsBIHOrder)objRow.Tag).m_intFEEL_INT)
                        {
                            case 0:
                                m_strFeel = " AST( ) ";
                                break;
                            case 1:
                                m_strFeel = " AST(-) ";
                                break;
                            case 2:
                                m_strFeel = " AST(+) ";
                                break;
                        }

                    }

                    //名称  同一方号的医嘱，子医嘱的用法与频率不用显示
                    objRow.Cells["dtv_Name"].Value = ((clsBIHOrder)objRow.Tag).m_strName + " " + objRow.Cells["dtv_Dosage"].Value.ToString() + "  " + objRow.Cells["dtv_UseType"].Value.ToString() + " " + m_strFeel;


                }

                //已停或正在停的医嘱,已执行过的临嘱用红色显示(包括执行出院带药)

                if (order.m_intStatus == 3 || order.m_intStatus == 6 || (order.m_intExecuteType == 2 && order.m_intStatus == 2) || (order.m_intExecuteType == 3 && order.m_intStatus == 2))
                {
                    m_frmInput.m_dtvOrder.Rows[i - 1].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (order.m_intStatus == -1)
                {
                    m_frmInput.m_dtvOrder.Rows[i - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));

                }

            }
            if (m_frmInput.m_dtvOrder.RowCount > 0)
            {
                //已停或正在停的医嘱,已执行过的临嘱用红色显示(最后一条的处理)
                clsBIHOrder order2 = (clsBIHOrder)m_frmInput.m_dtvOrder.Rows[m_frmInput.m_dtvOrder.RowCount - 1].Tag;
                if (order2.m_intStatus == 3 || order2.m_intStatus == 6 || (order2.m_intExecuteType == 2 && order2.m_intStatus == 2) || (order2.m_intExecuteType == 3 && order2.m_intStatus == 2))
                {
                    m_frmInput.m_dtvOrder.Rows[m_frmInput.m_dtvOrder.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (order2.m_intStatus == -1)
                {
                    m_frmInput.m_dtvOrder.Rows[m_frmInput.m_dtvOrder.RowCount - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));

                }
            }
        }

        /// <summary>
        /// 医嘱填充DATAGRIDVIEW
        /// </summary>
        /// <param name="objOrder">医嘱对像</param>
        /// <param name="m_intRecipenNoUp">上一条医嘱的方号(同方号的子医嘱不用再显示：长/临、类别、用法、频率、状态、下嘱医生)</param>
        public void m_objGetDataViewRow(clsBIHOrder objOrder, DataGridViewRow objRow, int m_intNo)
        {
            objRow.Height = 20;
            decimal m_dmlOneUse = 0;//补一次的领量
            //序
            objRow.Cells["dtv_NO"].Value = m_intNo;
            //医嘱类型
            clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)this.m_frmInput.m_htOrderCate[objOrder.m_strOrderDicCateID];
            if (p_objItem == null)
            {
                //if (objOrder.m_strName.ToString().Trim().Equals("术后医嘱"))
                //{
                //    objRow.Cells["dtv_Name"].Value = objOrder.m_strName.ToString();
                //    objRow.Cells["dtv_Name"].Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                //    objRow.Tag = objOrder;
                //    return;
                //}
                //else if (objOrder.m_strName.ToString().Trim().Equals("转科医嘱"))
                //{
                //    objRow.Cells["dtv_Name"].Value = objOrder.m_strName.ToString();
                //    objRow.Cells["dtv_Name"].Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                //    objRow.Tag = objOrder;
                //    return;
                //}
                if (objOrder.m_intTYPE_INT > 0)
                {
                    objRow.Cells["dtv_Name"].Value = objOrder.m_strName.ToString();
                    objRow.Cells["dtv_Name"].Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    objRow.Tag = objOrder;
                    return;
                }
            }
            if (objOrder.m_intExecuteType == 1)
            {
                //方
                objRow.Cells["dtv_RecipeNo"].Value = " " + objOrder.m_intRecipenNo2.ToString();
            }
            //价格
            //objRow["Price"] =objOrder.m_dmlPrice.ToString("0.0000");

            //“方法”列。用于显示检验医嘱的样本类型，和检查医嘱的部位信息
            if (!objOrder.m_strPARTID_VCHR.Trim().Equals(""))
            {
                objRow.Cells["dtv_method"].Value = objOrder.m_strPARTNAME_VCHR;
            }
            else if (!objOrder.m_strSAMPLEID_VCHR.Trim().Equals(""))
            {
                objRow.Cells["dtv_method"].Value = objOrder.m_strSAMPLEName_VCHR;
            }



            //开始执行时间
            objRow.Cells["dtv_StartDate"].Value = DateTimeToString(objOrder.m_dtExecutedate);
            //停嘱者
            objRow.Cells["dtv_Stoper"].Value = objOrder.m_strStoper;
            //审核停止者
            objRow.Cells["ASSESSORFORSTOP_CHR"].Value = objOrder.m_strASSESSORFORSTOP_CHR;
            //停嘱时间
            objRow.Cells["dtv_FinishDate"].Value = this.m_frmInput.DateTimeToCutYearDateString(objOrder.m_dtFinishDate);
            //objRow.Cells["dtv_ParentName"].Value = objOrder.m_strParentName;
            //执行时间/嘱托
            objRow.Cells["dtv_REMARK"].Value = objOrder.m_strREMARK_VCHR;
            if (objOrder.IsOps == 1) objRow.Cells["isOps"].Value = "是";

            //校对护士
            objRow.Cells["ASSESSORFOREXEC_CHR"].Value = objOrder.m_strASSESSORFOREXEC_CHR;
            //录入时间
            objRow.Cells["CREATEDATE_DAT"].Value = DateTimeToString(objOrder.m_dtCreatedate);
            //下嘱时间(开始时间）
            objRow.Cells["m_dtPOSTDATE_DAT"].Value = this.m_frmInput.DateTimeToCutYearDateString(objOrder.m_dtPostdate);
            objRow.Cells["m_dtStartDate"].Value = this.m_frmInput.DateTimeToCutYearDateString(objOrder.m_dtStartDate);
            //皮试
            string m_strFeel = "";
            if (objOrder.m_intISNEEDFEEL == 1)
            {

                switch (objOrder.m_intFEEL_INT)
                {
                    case 0:
                        m_strFeel = " AST( ) ";
                        break;
                    case 1:
                        m_strFeel = " AST(-) ";
                        break;
                    case 2:
                        m_strFeel = " AST(+) ";
                        break;
                }

            }

            #region 医嘱类型控制列表界面
            if (p_objItem != null)
            {
                objOrder.m_strOrderDicCateName = p_objItem.m_strVIEWNAME_VCHR;

                if (!objOrder.m_strExecFreqID.Trim().Equals(this.m_frmInput.m_objSpecateVo.m_strCONFREQID_CHR.Trim()))//连续性医嘱不显示剂量
                {
                    if (p_objItem.m_intDOSAGEVIEWTYPE == 1)
                    {
                        //用量
                        if (objOrder.m_dmlDosage > 0)
                        {
                            objRow.Cells["dtv_Dosage"].Value = objOrder.m_dmlDosage.ToString() + "" + objOrder.m_strDosageUnit;
                        }
                        else
                        {
                            objRow.Cells["dtv_Dosage"].Value = "";

                        }
                    }
                    else
                    {
                        objRow.Cells["dtv_Dosage"].Value = "";
                    }
                }
                else
                {
                    objRow.Cells["dtv_Dosage"].Value = "";
                }
                if (!objOrder.m_strExecFreqID.Trim().Equals(this.m_frmInput.m_objSpecateVo.m_strCONFREQID_CHR.Trim()))//连续性医嘱不显示用法
                {
                    if (p_objItem.m_intUSAGEVIEWTYPE == 1)
                    {
                        //用法
                        objRow.Cells["dtv_UseType"].Value = objOrder.m_strDosetypeName;
                    }
                    else
                    {
                        //用法
                        objRow.Cells["dtv_UseType"].Value = "";
                    }
                }
                else
                {
                    //用法
                    objRow.Cells["dtv_UseType"].Value = "";
                }
                if (objOrder.m_intExecuteType == 1 || objOrder.m_intExecuteType == 2)//长临才显示频率，出院带药不显示
                //if (objOrder.m_intExecuteType == 1)//长临才显示频率，临嘱不显示
                {
                    if (p_objItem.m_intExecuFrenquenceType == 1)
                    {
                        //频率
                        objRow.Cells["dtv_Freq"].Value = objOrder.m_strExecFreqName;
                    }
                    else
                    {
                        //当不显示时，医嘱表中的为修改标志=1时也显示出来 (0-普通状态,1-频率修改)
                        if (objOrder.m_intCHARGE_INT == 1)
                        {
                            objRow.Cells["dtv_Freq"].Value = objOrder.m_strExecFreqName;//频率
                        }
                        else
                        {
                            objRow.Cells["dtv_Freq"].Value = "";//频率
                        }
                    }
                }
                else
                {
                    //当不显示时，医嘱表中的为修改标志=1时也显示出来 (0-普通状态,1-频率修改)
                    if (objOrder.m_intCHARGE_INT == 1)
                    {
                        objRow.Cells["dtv_Freq"].Value = objOrder.m_strExecFreqName;//频率
                    }
                    else
                    {
                        objRow.Cells["dtv_Freq"].Value = "";//频率
                    }

                }

                if (p_objItem.m_intAPPENDVIEWTYPE_INT == 1)
                {
                    //补次
                    objRow.Cells["ATTACHTIMES_INT"].Value = objOrder.m_intATTACHTIMES_INT;
                    m_dmlOneUse = objOrder.m_dmlOneUse * objOrder.m_intATTACHTIMES_INT;
                }
                else
                {
                    //补次
                    objRow.Cells["ATTACHTIMES_INT"].Value = "";
                    m_dmlOneUse = 0;
                }
                //领量
                if (p_objItem.m_intQTYVIEWTYPE_INT == 1)
                {
                    if (objOrder.m_dmlGet > 0)
                    {
                        objRow.Cells["dtv_Get"].Value = objOrder.m_dmlGet.ToString() + " " + objOrder.m_strGetunit;

                    }
                    else
                    {
                        objRow.Cells["dtv_Get"].Value = "";

                    }
                }
                else
                {
                    //领量
                    objRow.Cells["dtv_Get"].Value = "";
                }
            }
            else
            {
                //用量
                objRow.Cells["dtv_Dosage"].Value = "";
                //频率
                objRow.Cells["dtv_Freq"].Value = "";
                //用法
                objRow.Cells["dtv_UseType"].Value = "";
                //补次
                objRow.Cells["ATTACHTIMES_INT"].Value = "";
                //领量
                objRow.Cells["dtv_Get"].Value = "";

            }
            #endregion

            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药) 
            if (objOrder.m_strOrderDicCateName != null && objOrder.m_strOrderDicCateName.ToString().Trim() == "药疗")
            {
                switch (objOrder.RateType)
                {
                    //case 0:
                    //    objRow.Cells["RATETYPE_INT"].Value = "否";
                    //    break;
                    //case 1:
                    //    objRow.Cells["RATETYPE_INT"].Value = "是";
                    //    break;
                    //case 2:
                    //    objRow.Cells["RATETYPE_INT"].Value = "";
                    //    break;
                    case 0:
                        objRow.Cells["RATETYPE_INT"].Value = "药房";
                        break;
                    case 1:
                        objRow.Cells["RATETYPE_INT"].Value = "自备";
                        break;
                    case 2:
                        objRow.Cells["RATETYPE_INT"].Value = "基数";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                objRow.Cells["RATETYPE_INT"].Value = "";
            }

            //出院带药天数
            string m_strOUTGETMEDDAYS_INT = "";
            //总量字段的控制
            if (objOrder.m_strOrderDicCateID.Equals(this.m_frmInput.m_objSpecateVo.m_strMID_MEDICINE_CHR))//中药类型逻辑
            {
                objRow.Cells["dtv_sum"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "服共" + Convert.ToString(objOrder.m_dmlGet + m_dmlOneUse) + objOrder.m_strGetunit;
                m_strOUTGETMEDDAYS_INT = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "服"; ;
            }
            else
            {

                if (objOrder.m_intExecuteType == 3)
                {
                    objRow.Cells["dtv_sum"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天共" + Convert.ToString(objOrder.m_dmlGet + m_dmlOneUse) + objOrder.m_strGetunit;
                    m_strOUTGETMEDDAYS_INT = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天";
                    //objRow.Cells["dtv_OUTGETMEDDAYS_INT"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天";
                }
                else
                {
                    objRow.Cells["dtv_sum"].Value = "共" + Convert.ToString(objOrder.m_dmlGet + m_dmlOneUse) + objOrder.m_strGetunit;
                    m_strOUTGETMEDDAYS_INT = "";
                    //objRow.Cells["dtv_OUTGETMEDDAYS_INT"].Value = "";
                }
                objRow.Cells["dtv_OUTGETMEDDAYS_INT"].Value = m_strOUTGETMEDDAYS_INT;
            }

            //名称
            objRow.Cells["dtv_Name"].Value = objOrder.m_strName + " " + objRow.Cells["dtv_Dosage"].Value.ToString() + " " + objRow.Cells["dtv_UseType"].Value.ToString() + " " + objRow.Cells["dtv_Freq"].Value.ToString() + m_strFeel + " " + m_strOUTGETMEDDAYS_INT;
            //名称格式控制
            if (p_objItem != null)
            {
                if (p_objItem.m_strVIEWNAME_VCHR.ToString().Trim() == "文字医嘱")
                {
                    objRow.Cells["dtv_Name"].Value = "   " + objRow.Cells["dtv_Name"].Value.ToString();

                }
            }

            /*<=====================================================================*/
            //医保
            objRow.Cells["MedicareTypeName"].Value = objOrder.m_strMedicareTypeName;
            //医生名称 
            objRow.Cells["dtv_DOCTOR_VCHR"].Value = objOrder.m_strDOCTOR_VCHR;
            //开单科室 
            objRow.Cells["dtv_CREATEAREA_Name"].Value = objOrder.m_strCREATEAREA_Name;
            //作废人 
            objRow.Cells["dtv_DELETERNAME_VCHR"].Value = objOrder.m_strDELETERNAME_VCHR;
            //作废时间 
            objRow.Cells["dtv_DELETE_DAT"].Value = objOrder.m_strDELETE_DAT;
            //修改人姓名
            objRow.Cells["dtv_ChangedID"].Value = objOrder.m_strChangedName_CHR;
            //修改人时间
            objRow.Cells["dtv_ChangedDate"].Value = DateTimeToString(objOrder.m_dtChanged_DAT);
            // 同方号的子医嘱不用再显示：长/临、类别、用法、频率、状态、下嘱医生
            //长/临
            if (objOrder.m_intExecuteType == 1)
            {
                objRow.Cells["dtv_ExecuteType"].Value = "长期";

            }
            else if (objOrder.m_intExecuteType == 2)
            {
                objRow.Cells["dtv_ExecuteType"].Value = "临时";

            }
            else if (objOrder.m_intExecuteType == 3)
            {
                objRow.Cells["dtv_ExecuteType"].Value = "带药";

            }
            else
            {
                objRow.Cells["dtv_ExecuteType"].Value = "";
            }


            //医嘱类型名称
            objRow.Cells["viewname_vchr"].Value = objOrder.m_strOrderDicCateName.ToString().Trim();
            //医嘱状态 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
            switch (objOrder.m_intStatus)
            {
                case -2:
                    objRow.Cells["STATUS_INT"].Value = "已删除";
                    break;
                case -1:
                    objRow.Cells["STATUS_INT"].Value = "作废";
                    break;
                case 0:
                    objRow.Cells["STATUS_INT"].Value = "新开";
                    break;
                case 1:
                    objRow.Cells["STATUS_INT"].Value = "提交";
                    break;
                case 2:
                    objRow.Cells["STATUS_INT"].Value = "执行";
                    break;
                case 3:
                    objRow.Cells["STATUS_INT"].Value = "停止";
                    break;
                case 4:
                    objRow.Cells["STATUS_INT"].Value = "重整";
                    break;
                case 5:
                    objRow.Cells["STATUS_INT"].Value = "转抄";
                    break;
                case 6:
                    objRow.Cells["STATUS_INT"].Value = "审核停止";
                    break;
                case 7:
                    objRow.Cells["STATUS_INT"].Value = "退回";
                    break;
                default:
                    objRow.Cells["STATUS_INT"].Value = "";
                    break;
            }
            //下嘱医生
            objRow.Cells["CREATOR_CHR"].Value = objOrder.m_strCreator;
            //执行人
            objRow.Cells["dtv_Executor"].Value = objOrder.m_strExecutor;
            ////医生签名dtv_DOCTOR_SIGN
            //if (this.m_frmInput.m_blDoctorSign)
            //{
            //    if (objOrder.SIGN_GRP != null && objOrder.SIGN_INT == 1)
            //    {
            //        System.IO.MemoryStream ms = new System.IO.MemoryStream(objOrder.SIGN_GRP);
            //        Bitmap m_bpSign = new Bitmap(ms);
            //        objRow.Cells["dtv_DOCTOR_SIGN"].Value = m_bpSign;
            //        ms.Close();
            //    }
            //    else if (objOrder.SIGN_INT == 0)
            //    {

            //        Bitmap m_bpSign = new Bitmap("Picture//unsign.bmp");
            //        objRow.Cells["dtv_DOCTOR_SIGN"].Value = m_bpSign;

            //    }
            //    else
            //    {

            //        objRow.Cells["dtv_DOCTOR_SIGN"].Style.NullValue = null;
            //    }

            //    if (this.m_frmInput.m_blDoctorSign && objOrder.SIGN_INT != 1)
            //    {
            //        objRow.DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //}
            //退回人
            objRow.Cells["m_dtvSENDBACKER_CHR"].Value = objOrder.m_strSENDBACKER_CHR;

            objRow.Tag = objOrder;
        }

        private void m_objGetDataViewRow2(int intNo, clsBIHOrder objOrder, object p_3)
        {
            string[] m_arrValue = new string[this.m_frmInput.m_dtvOrder.ColumnCount];
            int k = 0;

            //objRow.Cells["dtv_NO"].Value = intNo;
            m_arrValue[k++] = intNo.ToString();
            //objRow.Cells["dtv_RecipeNo"].Value = objOrder.m_intRecipenNo;
            m_arrValue[k++] = objOrder.m_intRecipenNo.ToString();
            //价格
            //objRow["Price"] =objOrder.m_dmlPrice.ToString("0.0000");
            if (objOrder.m_intExecuteType == 1)
            {
                //  objRow.Cells["dtv_ExecuteType"].Value = "长";
                m_arrValue[k++] = "长";
            }
            else
            {
                if (objOrder.m_intExecuteType == 2)
                {
                    // objRow.Cells["dtv_ExecuteType"].Value = "临";
                    m_arrValue[k++] = "临";
                }
                else
                {
                    //objRow.Cells["dtv_ExecuteType"].Value = "";
                    m_arrValue[k++] = "";
                }
            }
            //objRow.Cells["dtv_Name"].Value = objOrder.m_strName;
            m_arrValue[k++] = objOrder.m_strName;

            if (objOrder.m_dmlDosage > 0)
            {
                //objRow.Cells["dtv_Dosage"].Value = objOrder.m_dmlDosage.ToString() + " " + objOrder.m_strDosageUnit;
                m_arrValue[k++] = objOrder.m_dmlDosage.ToString() + " " + objOrder.m_strDosageUnit;
            }
            else
            {
                //objRow.Cells["dtv_Dosage"].Value = "";
                m_arrValue[k++] = "";
            }
            if (objOrder.m_dmlGet > 0)
            {
                //objRow.Cells["dtv_Get"].Value = objOrder.m_dmlGet.ToString() + " " + objOrder.m_strGetunit;
                m_arrValue[k++] = objOrder.m_dmlGet.ToString() + " " + objOrder.m_strGetunit;
            }
            else
            {
                //objRow.Cells["dtv_Get"].Value = "";
                m_arrValue[k++] = "";
            }
            //合计
            //objRow["TotalMoney"] =(double.Parse(objOrder.m_dmlGet.ToString()) * double.Parse(objOrder.m_dmlPrice.ToString())).ToString("0.00");
            //objRow.Cells["dtv_Freq"].Value = objOrder.m_strExecFreqName;
            m_arrValue[k++] = objOrder.m_strExecFreqName;
            //objRow.Cells["dtv_UseType"].Value = objOrder.m_strDosetypeName;
            m_arrValue[k++] = objOrder.m_strDosetypeName;
            if (objOrder.m_intISNEEDFEEL == 1)
            {
                //objRow.Cells["dtv_ISNEEDFEEL"].Value = "√";
                m_arrValue[k++] = "√";
            }
            else
            {
                //objRow.Cells["dtv_ISNEEDFEEL"].Value = "";//×
                m_arrValue[k++] = "";
            }
            //objRow.Cells["dtv_StartDate"].Value = DateTimeToString(objOrder.m_dtStartDate);
            m_arrValue[k++] = DateTimeToString(objOrder.m_dtStartDate);
            //objRow.Cells["dtv_Stoper"].Value = objOrder.m_strStoper;
            m_arrValue[k++] = objOrder.m_strStoper;
            //objRow.Cells["dtv_StopDate"].Value = DateTimeToString(objOrder.m_dtStopdate);
            m_arrValue[k++] = DateTimeToString(objOrder.m_dtStopdate);
            //objRow.Cells["dtv_ParentName"].Value = objOrder.m_strParentName;
            m_arrValue[k++] = objOrder.m_strParentName;

            this.m_frmInput.m_dtvOrder.Rows.Add(m_arrValue);
            //if (m_frmInput.m_blLoad)
            //{
            //    this.m_frmInput.m_dtvOrder.CurrentCell = null;
            //    this.m_frmInput.m_blLoad = false;


            //}

        }

        /// <summary>
        /// 载入医嘱类型
        /// </summary>
        public void m_Loadm_lngGetOrderCate()
        {
            long lngRes = 0;
            clsT_aid_bih_ordercate_VO[] p_objItemArr = null;
            lngRes = m_objInputOrder.m_lngGetAidOrderCate(out p_objItemArr);
            this.m_frmInput.m_htOrderCate.Clear();
            for (int i = 0; i < p_objItemArr.Length; i++)
            {
                if (!this.m_frmInput.m_htOrderCate.Contains(p_objItemArr[i].m_strORDERCATEID_CHR))
                {
                    this.m_frmInput.m_htOrderCate.Add(p_objItemArr[i].m_strORDERCATEID_CHR, p_objItemArr[i]);
                }
            }

            //DelItems(ref p_objItemArr);
            if (lngRes > 0 && p_objItemArr != null && p_objItemArr.Length > 0)
            {
                m_frmInput.m_ctlOrderDetail.m_cobOrderCate.Items.Clear();
                //载入医嘱类型对象
                clsOrderCate objItem2 = new clsOrderCate();
                objItem2.m_objOrderCate.m_strVIEWNAME_VCHR = "全部";
                objItem2.m_objOrderCate.m_strORDERCATEID_CHR = "";

                //医嘱输入区的默认类型查询条件
                m_frmInput.m_ctlOrderDetail.m_txtOrderCate.Text = objItem2.m_objOrderCate.m_strVIEWNAME_VCHR;
                m_frmInput.m_ctlOrderDetail.m_txtOrderCate.Tag = objItem2.m_objOrderCate.m_strORDERCATEID_CHR;
                /*<================================*/

                String CatName = "";
                for (int i1 = 0; i1 < p_objItemArr.Length; i1++)
                {
                    clsOrderCate objItem = new clsOrderCate();
                    objItem.m_objOrderCate = p_objItemArr[i1];
                    if (objItem.m_objOrderCate.m_intORDERSELECT_INT == 1)
                    {
                        m_frmInput.m_ctlOrderDetail.m_cobOrderCate.Items.Add(objItem);
                    }

                    CatName = objItem.m_objOrderCate.m_strVIEWNAME_VCHR.Trim();
                    if (CatName != "" && !m_frmInput.m_ctlOrderDetail.hasAppendViewType.ContainsKey(CatName))
                    {
                        m_frmInput.m_ctlOrderDetail.hasAppendViewType.Add(CatName, objItem.m_objOrderCate.m_intAPPENDVIEWTYPE_INT.ToString());
                    }
                }
                m_frmInput.m_ctlOrderDetail.m_cobOrderCate.Items.Insert(0, objItem2);
            }
        }
        private void DelItems(ref clsT_aid_bih_ordercate_VO[] p_objItemArr)
        {
            System.Collections.ArrayList aa = new ArrayList();
            for (int i = 0; i < p_objItemArr.Length; i++)
            {
                if (!aa.Contains(p_objItemArr[i].m_strVIEWNAME_VCHR))
                {
                    aa.Add(p_objItemArr[i].m_strVIEWNAME_VCHR);
                }
            }
            p_objItemArr = new clsT_aid_bih_ordercate_VO[aa.Count];
            for (int i = 0; i < aa.Count; i++)
            {
                p_objItemArr[i] = new clsT_aid_bih_ordercate_VO();
                p_objItemArr[i].m_strVIEWNAME_VCHR = aa[i].ToString();
            }
        }
        #endregion
        #region 事件	{提交医嘱、提交所有医嘱、停止医嘱、重整医嘱、作废医嘱}
        #region 提交医嘱
        /// <summary>
        /// 提交医嘱
        /// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
        ///  业务说明：	只针对状态：0-创建;
        /// </summary>
        public void m_mthShowCommitForm()
        {
            int count = 0;
            if (m_frmInput.m_blDoctorSign)
            {
                count = CountTheSignOrder();
                if (count > 0)
                {
                    MessageBox.Show("有没签名的医嘱，不能进行提交!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }
            count = 0;
            //当前操作员可提交的医嘱数目
            count = CountTheAdminOrder();
            if (count <= 0)
            {
                return;
            }
            if (MessageBox.Show("是否提交新开医嘱?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                frmBIHOrderCommit objForm = new frmBIHOrderCommit(this.m_frmInput.m_blCommitControl, this.m_frmInput.m_blSendLisBill, this.m_frmInput.m_htOrderCate, this.m_frmInput.m_ctlPatient.m_objPatient.m_strDiagnose);
                objForm.LoginInfo = m_frmInput.LoginInfo;
                objForm.m_blnCloseAfterCommit = true;
                if (m_frmInput.m_ctlPatient.m_objPatient != null)
                {
                }
                else
                {
                    m_mthShowMessage("请先选择待提交医嘱的病人!");
                    m_frmInput.m_ctlOrderDetail.m_txtBedNo.Focus();
                    return;
                }
                //根据当前诊疗项目停用或缺药提醒
                if (m_frmInput.m_blAutoStopAlert)
                {
                    OrderStopSignByRegisterId();
                }
                // 4006设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能
                objForm.m_intLisDiscountNum = m_frmInput.m_intLisDiscountNum;
                // 4007设置启用打折功能时，检验收费项目的打折比例。80，则打八折
                objForm.m_decLisDiscountMount = m_frmInput.m_decLisDiscountMount;
                // 4008  0-false不打折 1-true 允许打折
                objForm.m_blLisDiscount = m_frmInput.m_blLisDiscount;
                // 系统参数表(ICARE公用) 0013 检验组合打折发票类型 多种类型以身份隔开
                objForm.m_strLisPARMVALUE_VCHR = m_frmInput.m_strLisPARMVALUE_VCHR;
                //特殊配置表
                objForm.m_objSpecateVo = m_frmInput.m_objSpecateVo;
                //1067
                objForm.blnFillApplyBill = m_frmInput.blnFillApplyBill;
                // 1032
                objForm.m_intComfirm = m_frmInput.m_intCommitControl2;
                this.m_frmInput.Cursor = Cursors.WaitCursor;
                objForm.Find_Order2(m_frmInput.LoginInfo.m_strEmpID, m_frmInput.m_ctlPatient.m_objPatient.m_strRegisterID);
                if (objForm.m_dtvOrder.RowCount <= 0)
                {
                    this.m_frmInput.Cursor = Cursors.Default;
                    return;
                }
                objForm.m_cmdCommit_Click(null, null);
                this.m_frmInput.Cursor = Cursors.Default;
                m_mthLoadOrderList();
                this.m_frmInput.m_ctlOrderDetail.m_txtBedNo.Focus();
            }
        }

        private int CountTheAdminOrder()
        {
            int count = 0;
            for (int i = 0; i < this.m_frmInput.m_dtvOrder.RowCount; i++)
            {
                clsBIHOrder order = (clsBIHOrder)m_frmInput.m_dtvOrder.Rows[i].Tag;
                if (order.m_strCreatorID == this.m_frmInput.LoginInfo.m_strEmpID && (order.m_intStatus == 0 || order.m_intStatus == 7))
                {
                    count++;
                }
            }
            return count;
        }
        private int CountTheSignOrder()
        {
            int count = 0;
            for (int i = 0; i < this.m_frmInput.m_dtvOrder.RowCount; i++)
            {
                clsBIHOrder order = (clsBIHOrder)m_frmInput.m_dtvOrder.Rows[i].Tag;
                if (order.m_strCreatorID == this.m_frmInput.LoginInfo.m_strEmpID && order.m_intStatus == 0 && order.SIGN_INT == 0)
                {
                    count++;
                }
            }
            return count;
        }
        #endregion
        #region 提交所有医嘱	不用
        /// <summary>
        /// 提交所有医嘱
        /// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
        ///  业务说明：	只针对状态：0-创建;
        /// </summary>
        public void m_mthCommitAll()
        {
            ArrayList arlOrder = new ArrayList();
            for (int i = 0; i < m_frmInput.m_arlOrder.Count; i++)
            {
                if ((m_frmInput.m_arlOrder[i] as clsBIHOrder).m_intStatus == 0 || (m_frmInput.m_arlOrder[i] as clsBIHOrder).m_intStatus == 7)
                    arlOrder.Add(m_frmInput.m_arlOrder[i]);
            }
            clsBIHOrder[] arrOrder = (arlOrder.ToArray(typeof(clsBIHOrder))) as clsBIHOrder[];
            long ret = m_objService.m_lngPostOrder(arrOrder, m_frmInput.m_objCurrentDoctor.m_strDoctorID, m_frmInput.m_objCurrentDoctor.m_strDoctorName);
            if (ret > 0)
            {
                m_mthRefreshGridColor();

                if ((m_frmInput.m_objCurrentOrder != null) && (m_frmInput.m_objCurrentOrder.m_intStatus != 0) && (m_frmInput.m_objCurrentOrder.m_intStatus != 7))
                {
                    m_frmInput.m_ctlOrderDetail.ReadOnly = true;
                }
                //m_mthShowMessage("操作成功！");
            }
            else
            {
                m_mthShowMessage("提交失败!");
            }
            m_mthRefreshOtherBillInfo();
        }
        #endregion
        #region 停止医嘱
        /// <summary>
        /// 停止长期医嘱	
        /// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：2-执行
        /// </summary>
        /// <param name="blnPrompt"></param>
        public void m_mthStopCurrentOrder(bool blnPrompt, clsBIHOrder BihOrder)
        {
            //if (m_frmInput.m_objCurrentOrder == null)
            //{
            //    int intCurRow =m_frmInput.m_dtgOrder.CurrentCell.RowNumber;
            //    if ((intCurRow >= 0) && (intCurRow < m_frmInput.m_arlOrder.Count))
            //    {

            //        m_frmInput.m_intCurrentRow = intCurRow;
            //        m_frmInput.m_objCurrentOrder = m_frmInput.m_arlOrder[intCurRow] as clsBIHOrder;
            //    }
            //    else
            //    {
            //        MessageBox.Show("请先选择一条医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}
            /*<=====================================================*/

            if (BihOrder.m_intExecuteType == 2 || BihOrder.m_intStatus != 2)
            {
                m_mthShowMessage("只能停止“正在执行长期医嘱”！");
                return;
            }
            clsBIHOrder objOrder = BihOrder;
            DateTime m_dtStopTime = DateTime.MinValue;
            if (m_frmInput.m_ctlOrderDetail.m_dtFinishTime2.Enabled == true)
            {
                try
                {
                    m_dtStopTime = Convert.ToDateTime(m_frmInput.m_ctlOrderDetail.m_dtFinishTime2.Text.ToString().Trim());
                }
                catch
                {
                    m_dtStopTime = DateTime.MinValue;
                }
            }
            /*
            long ret =0;
            if(blnPrompt)
            {
                #region 提示
                //是否为父级目录	
                if(!IsHaveSonOrder(m_frmInput.m_objCurrentOrder.m_strOrderID))
                {
                    if(MessageBox.Show(m_frmInput,"是否确定停止医嘱“" + m_frmInput.m_objCurrentOrder.m_strName + " ”？","提示框！",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                    {
                        return;
                    }
                    else
                    {					
                        ret=m_objService.m_lngStopOrder(new clsBIHOrder[]{objOrder},m_frmInput.m_objCurrentDoctor.m_strDoctorID,m_frmInput.m_objCurrentDoctor.m_strDoctorName);
                    }
                }
                else
                {
                    frmConfirmOrderOperate objfrmConfirmOrderOperate =new frmConfirmOrderOperate("停止",m_frmInput.m_objCurrentOrder.m_strOrderID);
                    objfrmConfirmOrderOperate.m_txbPatientName.Text =m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName;
                    objfrmConfirmOrderOperate.m_txbOrderName.Text =m_frmInput.m_objCurrentOrder.m_strName;
                   
                    objfrmConfirmOrderOperate.ShowDialog();
                   
                    if(objfrmConfirmOrderOperate.m_intResult==0) 
                    {
                        return;
                    }
                    else
                    {
                        //梯归停止医嘱
                        try
                        {
                            ret=m_objService.m_lngStopOrder(m_frmInput.m_objCurrentOrder,m_frmInput.m_objCurrentDoctor.m_strDoctorID,m_frmInput.m_objCurrentDoctor.m_strDoctorName,true);
                        }
                        catch(System.Exception e)
                        {
                            m_mthShowMessage(e.Message);
                            return;
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 不提示
                //是否为父级目录	
                if(!IsHaveSonOrder(m_frmInput.m_objCurrentOrder.m_strOrderID))
                {
                    ret=m_objService.m_lngStopOrder(new clsBIHOrder[]{m_frmInput.m_objCurrentOrder},m_frmInput.m_objCurrentDoctor.m_strDoctorID,m_frmInput.m_objCurrentDoctor.m_strDoctorName);
                }
                else
                {
                    //梯归停止医嘱
                    try
                    {
                        ret=m_objService.m_lngStopOrder(objOrder,m_frmInput.m_objCurrentDoctor.m_strDoctorID,m_frmInput.m_objCurrentDoctor.m_strDoctorName,true);
                    }
                    catch(System.Exception e)
                    {
                        m_mthShowMessage(e.Message);
                        return;
                    }
                }
                #endregion
            }
             */
            long ret = 0;
            bool have_parent = false;//当前选取中医嘱是否有父医嘱(true-有,false-无)
            bool first = false;
            int sign = 0;//0,选中了父医嘱，1，选中了有父医嘱的子医嘱
            if (blnPrompt)
            {
                #region 提示
                //是否为父级目录	
                if (!IsHaveSonOrder(BihOrder.m_strOrderID))
                {

                    if (BihOrder.m_strParentID != null)
                    {
                        if (!BihOrder.m_strParentID.ToString().Trim().Equals(""))
                        {
                            first = false;
                            if (IsHaveSonOrder(BihOrder.m_strParentID.ToString().Trim()))
                            {
                                have_parent = true;
                                sign = 1;
                            }
                        }
                        else
                        {
                            first = true;
                        }
                    }
                    if (first)
                    {
                        if (MessageBox.Show(m_frmInput, "是否确定停止医嘱“" + BihOrder.m_strName + " ”？", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            ret = m_objService.m_lngStopOrder(new clsBIHOrder[] { objOrder }, m_frmInput.m_objCurrentDoctor.m_strDoctorID, m_frmInput.m_objCurrentDoctor.m_strDoctorName, m_dtStopTime);
                        }
                    }
                }
                else
                {
                    have_parent = true;
                }
                if (have_parent)
                {
                    if (sign == 1)
                    {
                        clsBIHOrder objResult = new clsBIHOrder();
                        clsBIHOrderService m_objManage = new clsBIHOrderService();
                        m_objManage.m_lngGetOrderByOrderID(BihOrder.m_strParentID.ToString().Trim(), out objResult );
                        if (objResult == null)
                        {
                            return;
                        }
                        frmConfirmOrderOperate objfrmConfirmOrderOperate = new frmConfirmOrderOperate("停止", objResult.m_strOrderID, m_frmInput.IsChildPrice);
                        objfrmConfirmOrderOperate.m_txbPatientName.Text = m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName;
                        objfrmConfirmOrderOperate.m_txbOrderName.Text = objResult.m_strName;

                        objfrmConfirmOrderOperate.ShowDialog();

                        if (objfrmConfirmOrderOperate.m_intResult == 0)
                        {
                            return;
                        }
                        else
                        {
                            //梯归停止医嘱
                            try
                            {
                                ret = m_objService.m_lngStopOrder(objResult, m_frmInput.m_objCurrentDoctor.m_strDoctorID, m_frmInput.m_objCurrentDoctor.m_strDoctorName, true, m_dtStopTime, m_frmInput.IsChildPrice);
                            }
                            catch (System.Exception e)
                            {
                                m_mthShowMessage(e.Message);
                                return;
                            }
                        }
                    }
                    else
                    {
                        frmConfirmOrderOperate objfrmConfirmOrderOperate = new frmConfirmOrderOperate("停止", BihOrder.m_strOrderID, m_frmInput.IsChildPrice);
                        objfrmConfirmOrderOperate.m_txbPatientName.Text = m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName;
                        objfrmConfirmOrderOperate.m_txbOrderName.Text = BihOrder.m_strName;

                        objfrmConfirmOrderOperate.ShowDialog();

                        if (objfrmConfirmOrderOperate.m_intResult == 0)
                        {
                            return;
                        }
                        else
                        {
                            //梯归停止医嘱
                            try
                            {
                                ret = m_objService.m_lngStopOrder(BihOrder, m_frmInput.m_objCurrentDoctor.m_strDoctorID, m_frmInput.m_objCurrentDoctor.m_strDoctorName, true, m_dtStopTime, m_frmInput.IsChildPrice);
                            }
                            catch (System.Exception e)
                            {
                                m_mthShowMessage(e.Message);
                                return;
                            }
                        }
                    }
                }
                #endregion
            }

            /*<==============================================================================*/
            if (ret > 0)
            {
                m_mthLoadOrderList();
                //m_mthUpdateOrderByStatus();
                //m_mthShowMessage("操作成功！");
            }
            else
            {
                m_mthShowMessage("停止失败!");
            }

            m_mthRefreshOtherBillInfo();
        }
        #endregion
        #region 重整医嘱
        /// <summary>
        /// 重整医嘱
        /// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：6-审核停止
        /// </summary>
        /// <param name="blnPrompt"></param>
        public void m_mthRetractCurrentOrder(bool blnPrompt)
        {
            if (!m_blnExistCurrentOrder()) return;

            if (m_frmInput.m_objCurrentOrder.m_intStatus != 6)
            {
                m_mthShowMessage("只能重整“审核停止”状态的医嘱！");
                return;

            }
            long ret = 0;
            if (blnPrompt)
            {
                #region 提示
                if (!IsHaveSonOrder(m_frmInput.m_objCurrentOrder.m_strOrderID))
                {
                    if (MessageBox.Show(this.m_frmInput, "是否重整医嘱: " + m_frmInput.m_objCurrentOrder.m_strName + " ?", "重整医嘱", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        ret = m_objService.m_lngRetractOrder(new clsBIHOrder[] { m_frmInput.m_objCurrentOrder }, m_frmInput.m_objCurrentDoctor.m_strDoctorID, m_frmInput.m_objCurrentDoctor.m_strDoctorName);
                    }
                }
                else
                {
                    frmConfirmOrderOperate objfrmConfirmOrderOperate = new frmConfirmOrderOperate("重整", m_frmInput.m_objCurrentOrder.m_strOrderID, m_frmInput.IsChildPrice);
                    objfrmConfirmOrderOperate.m_txbPatientName.Text = m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName;
                    objfrmConfirmOrderOperate.m_txbOrderName.Text = m_frmInput.m_objCurrentOrder.m_strName;
                    objfrmConfirmOrderOperate.ShowDialog();
                    if (objfrmConfirmOrderOperate.m_intResult == 0)
                    {
                        return;
                    }
                    else
                    {
                        //梯归重整医嘱
                        try
                        {
                            ret = m_objService.m_lngRetractOrder(m_frmInput.m_objCurrentOrder, m_frmInput.m_objCurrentDoctor.m_strDoctorID, m_frmInput.m_objCurrentDoctor.m_strDoctorName, true, m_frmInput.IsChildPrice);
                        }
                        catch (System.Exception e)
                        {
                            m_mthShowMessage(e.Message);
                            return;
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 不提示
                if (!IsHaveSonOrder(m_frmInput.m_objCurrentOrder.m_strOrderID))
                {
                    ret = m_objService.m_lngRetractOrder(new clsBIHOrder[] { m_frmInput.m_objCurrentOrder }, m_frmInput.m_objCurrentDoctor.m_strDoctorID, m_frmInput.m_objCurrentDoctor.m_strDoctorName);
                }
                else
                {
                    //梯归重整医嘱
                    try
                    {
                        ret = m_objService.m_lngRetractOrder(m_frmInput.m_objCurrentOrder, m_frmInput.m_objCurrentDoctor.m_strDoctorID, m_frmInput.m_objCurrentDoctor.m_strDoctorName, true, m_frmInput.IsChildPrice);
                    }
                    catch (System.Exception e)
                    {
                        m_mthShowMessage(e.Message);
                        return;
                    }
                }
                #endregion
            }

            //报告操作结果
            if (ret > 0)
            {
                //m_mthUpdateOrderByStatus();
                m_mthLoadOrderList();
                //m_mthShowMessage("操作成功！");
            }
            else
            {
                m_mthShowMessage("重整失败!");
            }
            m_mthRefreshOtherBillInfo();
        }
        #endregion
        #region 作废医嘱
        /// <summary>
        /// 作废当前医嘱	
        /// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：1-提交;
        /// </summary>
        /// <param name="blnPrompt"></param>
        public void m_mthBlankOutCurrentOrder(bool blnPrompt, clsBIHOrder BihOrder)
        {
            if (m_frmInput.m_blBlankOutControl == false) return;
            if (BihOrder.m_intExecuteType == 1)
            {
                if (BihOrder.m_intStatus == 3 || BihOrder.m_intStatus == 6)
                {
                    if (MessageBox.Show("该医嘱已经执行，是否强制作废?", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    m_mthShowMessage("长嘱只能先停止才能进行作废!");
                    return;
                }
            }
            else
            {
                if (BihOrder.m_intStatus == 2)
                {
                    if (MessageBox.Show("该医嘱已经执行，是否强制作废?", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    m_mthShowMessage("只有执行过的医嘱才能进行作废!");
                    return;
                }
            }
            //存在附加单据的不可作废
            if (m_objInputOrder.m_blnExistAttchOrder(BihOrder.m_strOrderID))
            {
                //MessageBox.Show(m_frmInput,"此医嘱有附加单据，请先删除附加单据！","警告！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            long ret = 0;
            if (blnPrompt)
            {
                #region 提示
                if (!IsHaveSonOrder(BihOrder.m_strOrderID))
                {
                    //if(MessageBox.Show(m_frmInput,"是否作废医嘱: " + BihOrder.m_strName + " ?","作废医嘱",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                    //{
                    //    return;
                    //}
                    //else
                    //{
                    ret = m_objService.m_lngBlankOutOrder(new string[] { BihOrder.m_strOrderID }, this.m_frmInput.LoginInfo.m_strEmpID, this.m_frmInput.LoginInfo.m_strEmpName);
                    //}
                }
                else
                {
                    frmConfirmOrderOperate objfrmConfirmOrderOperate = new frmConfirmOrderOperate("作废", BihOrder.m_strOrderID, m_frmInput.IsChildPrice);
                    objfrmConfirmOrderOperate.m_txbPatientName.Text = m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName;
                    objfrmConfirmOrderOperate.m_txbOrderName.Text = BihOrder.m_strName;
                    objfrmConfirmOrderOperate.ShowDialog();
                    if (objfrmConfirmOrderOperate.m_intResult == 0)
                    {
                        return;
                    }
                    else
                    {
                        //梯归作废医嘱
                        try
                        {
                            ret = m_objService.m_lngBlankOutOrder(BihOrder.m_strOrderID, true, this.m_frmInput.LoginInfo.m_strEmpID, this.m_frmInput.LoginInfo.m_strEmpName, m_frmInput.IsChildPrice);
                        }
                        catch (System.Exception e)
                        {
                            m_mthShowMessage(e.Message);
                            return;
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 不提示
                if (!IsHaveSonOrder(BihOrder.m_strOrderID))
                {
                    ret = m_objService.m_lngBlankOutOrder(new string[] { BihOrder.m_strOrderID }, this.m_frmInput.LoginInfo.m_strEmpID, this.m_frmInput.LoginInfo.m_strEmpName);
                }
                else
                {
                    //梯归作废医嘱
                    try
                    {
                        ret = m_objService.m_lngBlankOutOrder(BihOrder.m_strOrderID, true, this.m_frmInput.LoginInfo.m_strEmpID, this.m_frmInput.LoginInfo.m_strEmpName, m_frmInput.IsChildPrice);
                    }
                    catch (System.Exception e)
                    {
                        m_mthShowMessage(e.Message);
                        return;
                    }
                }
                #endregion
            }

            //报告操作结果
            if (ret > 0)
            {
                //m_mthShowMessage("操作成功！");
                BihOrder.m_intStatus = -1;
                m_mthLoadOrderList();
                //m_mthUpdateOrderByStatus();
            }
            else
            {
                m_mthShowMessage("作废医嘱失败!");
            }
            m_mthRefreshOtherBillInfo();
        }
        #endregion

        #region 删除医嘱
        /// <summary>
        /// 删除当前医嘱	
        /// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：0-创建;
        /// </summary>
        /// <param name="blnPrompt"></param>
        public void m_mthDeleteCurrentOrder(bool blnPrompt, clsBIHOrder BihOrder)
        {
            if (BihOrder.m_intStatus != 0 && BihOrder.m_intStatus != 7 && BihOrder.m_intStatus != 1 && BihOrder.m_intStatus != 5)
            {
                MessageBox.Show(" {当前医嘱：" + BihOrder.m_strName + "} " + "只有新开，退回，提交，和转抄三种状态的医嘱可以删除医嘱！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BihOrder.m_intStatus == 0)
            {
                if (MessageBox.Show(" {当前医嘱：" + BihOrder.m_strName + "} " + "该医嘱是新开的医嘱，是否删除?", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }
            if (BihOrder.m_intStatus == 7)
            {
                if (MessageBox.Show(" {当前医嘱：" + BihOrder.m_strName + "} " + "该医嘱是退回的医嘱，是否删除?", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }
            if (BihOrder.m_intStatus == 1)
            {
                if (MessageBox.Show(" {当前医嘱：" + BihOrder.m_strName + "} " + "该医嘱是已提交的医嘱，是否删除?", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }
            if (BihOrder.m_intStatus == 5)
            {
                if (MessageBox.Show(" {当前医嘱：" + BihOrder.m_strName + "} " + "该医嘱是已转抄的医嘱，是否删除?", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }
            //存在附加单据的不可删除
            if (m_objInputOrder.m_blnExistAttchOrder(BihOrder.m_strOrderID))
            {
                if (MessageBox.Show(" {当前医嘱：" + BihOrder.m_strName + "} " + "此医嘱有附加单据，请先删除附加单据！", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }
            long ret = 0;
            if (blnPrompt)
            {
                #region 提示
                if (!IsHaveSonOrder(BihOrder.m_strOrderID))
                {
                    ret = m_objService.m_lngDeleteOrder(new string[] { BihOrder.m_strOrderID });
                }
                else
                {
                    frmConfirmOrderOperate objfrmConfirmOrderOperate = new frmConfirmOrderOperate("删除", BihOrder.m_strOrderID, m_frmInput.IsChildPrice);
                    objfrmConfirmOrderOperate.m_txbPatientName.Text = m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName;
                    objfrmConfirmOrderOperate.m_txbOrderName.Text = BihOrder.m_strName;
                    objfrmConfirmOrderOperate.ShowDialog();
                    if (objfrmConfirmOrderOperate.m_intResult == 0)
                    {
                        return;
                    }
                    else
                    {
                        //梯归删除医嘱
                        try
                        {
                            ret = m_objService.m_lngDeleteOrder(BihOrder.m_strOrderID, true);
                        }
                        catch (System.Exception e)
                        {
                            m_mthShowMessage(e.Message);
                            return;
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 不提示
                if (!IsHaveSonOrder(BihOrder.m_strOrderID))
                {
                    ret = m_objService.m_lngBlankOutOrder(new string[] { BihOrder.m_strOrderID }, this.m_frmInput.LoginInfo.m_strEmpID, this.m_frmInput.LoginInfo.m_strEmpName);
                }
                else
                {
                    //梯归删除医嘱
                    try
                    {
                        ret = m_objService.m_lngBlankOutOrder(BihOrder.m_strOrderID, true, this.m_frmInput.LoginInfo.m_strEmpID, this.m_frmInput.LoginInfo.m_strEmpName, m_frmInput.IsChildPrice);
                    }
                    catch (System.Exception e)
                    {
                        m_mthShowMessage(e.Message);
                        return;
                    }
                }
                #endregion
            }

            //报告操作结果
            if (ret > 0)
            {
                //m_mthShowMessage("操作成功！");
                m_mthLoadOrderList();
                //m_mthUpdateOrderByStatus();
            }
            else
            {
                m_mthShowMessage("删除医嘱失败!");
            }
            m_mthRefreshOtherBillInfo();
        }
        #endregion

        /// <summary>
        /// 增加当前医嘱到剪贴板
        /// </summary>
        /// <returns></returns>
        public long m_lngAddCurrentOrderToClipBoard()
        {
            try
            {
                if (!m_blnExistCurrentOrder()) return -1;
                if (m_frmInput.m_objCurrentOrder.m_strParentID != null && m_frmInput.m_objCurrentOrder.m_strParentID.Trim() != "")
                {
                    Clipboard.SetDataObject(m_frmInput.m_objCurrentOrder, false);
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }


        public long m_lngIfIsGroupOrder()
        {
            try
            {
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region 增、删、改医嘱
        /// <summary>
        /// 保存医嘱信息
        /// </summary>
        public void m_mthSave()
        {
            clsBIHPatientInfo objPatient = m_frmInput.m_ctlPatient.m_objPatient;
            if (objPatient == null)
            {
                m_mthShowMessage("请先指定病人!");
                m_frmInput.m_ctlPatient.Focus();
                return;
            }

            long lngRes = -1;
            if (m_frmInput.m_objCurrentOrder == null)
            {
                #region 新增
                if (m_frmInput.m_ctlOrderDetail.CurrentItemIsGroup)
                {
                    #region 组套
                    clsBIHOrder[] arrOrder = m_frmInput.m_ctlOrderDetail.m_objGetOrderGroup(objPatient);
                    if ((arrOrder == null) || (arrOrder.Length <= 0)) return;

                    //检测是否方号一致
                    bool blnIsSameNO = false;
                    string strGroupID = "";
                    string[] strRecordIDArr;
                    //clsBIHOrderGroupService objTem =new clsBIHOrderGroupService();
                    clsBIHOrderGroupService objTem = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
                    try
                    {
                        strGroupID = ((clsBIHOrderGroup)m_frmInput.m_ctlOrderDetail.m_txtOrderName.Tag).m_strGroupID;
                    }
                    catch { }
                    if (strGroupID == string.Empty)
                    {
                        m_mthShowMessage("新增医嘱失败！");
                        return;
                    }
                    lngRes = objTem.m_lngCheckIsSameNOByGroupID(strGroupID, out blnIsSameNO);
                    if (lngRes > 0)
                    {
                        try
                        {
                            #region Add by jli in 2005-04-28 保存连续性组合医嘱
                            if (arrOrder[0].m_strExecFreqID.Trim() == new clsDcl_ExecuteOrder().m_strGetConfreqID().Trim())
                            {
                                for (int i = 0; i < arrOrder.Length; i++)
                                {
                                    if (arrOrder[i].m_dtStartDate == DateTime.MinValue)
                                    {
                                        arrOrder[i].m_dtStartDate = DateTime.Now;
                                    }
                                }
                            }
                            #endregion
                            lngRes = m_objService.m_lngAddNewOrder(out strRecordIDArr, arrOrder, blnIsSameNO, m_frmInput.IsChildPrice);
                        }
                        catch (System.Exception ex)
                        {
                            m_mthShowMessage(ex.Message);
                            return;
                        }
                    }
                    if (lngRes > 0)
                    {
                        //m_mthShowMessage("保存成功！");
                        //刷新数据
                        m_frmInput.Cursor = Cursors.WaitCursor;
                        m_mthLoadOrderList();
                        m_frmInput.Cursor = Cursors.Default;
                    }
                    else
                    {
                        m_mthShowMessage("新增医嘱失败！");
                    }
                    #endregion //end 组套
                }
                else
                {
                    #region 诊疗项目
                    clsBIHOrder objOrder = m_frmInput.m_objGetOrder(null);
                    if (objOrder == null) return;
                    //验证输入数据
                    if (!ValidateInput(objOrder)) return;

                    if (m_blnAddNew(objOrder))
                    {
                    }
                    else
                    {
                        m_mthShowMessage("保存失败!");
                    }
                    #endregion
                }
                #endregion
            }
            else if (m_frmInput.m_objCurrentOrder.m_strParentID.Trim() != ""
                && m_frmInput.m_objCurrentOrder.m_strOrderID.Trim() == ""
                && (m_frmInput.m_objCurrentOrder.m_intStatus == 0
                    || m_frmInput.m_objCurrentOrder.m_intStatus == 7))
            {
                #region 新增
                if (m_frmInput.m_ctlOrderDetail.CurrentItemIsGroup)
                {
                    #region 组套
                    clsBIHOrder[] arrOrder = m_frmInput.m_ctlOrderDetail.m_objGetOrderGroup(objPatient);
                    if ((arrOrder == null) || (arrOrder.Length <= 0)) return;

                    //检测是否方号一致
                    bool blnIsSameNO = false;
                    string strGroupID = "";
                    string[] strRecordIDArr;
                    clsBIHOrderGroupService objTem = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
                    try
                    {
                        strGroupID = ((clsBIHOrderGroup)m_frmInput.m_ctlOrderDetail.m_txtOrderName.Tag).m_strGroupID;
                    }
                    catch { }
                    if (strGroupID == string.Empty)
                    {
                        m_mthShowMessage("新增医嘱失败！");
                        return;
                    }
                    lngRes = objTem.m_lngCheckIsSameNOByGroupID(strGroupID, out blnIsSameNO);
                    if (lngRes > 0)
                    {
                        try
                        {
                            lngRes = m_objService.m_lngAddNewOrder(out strRecordIDArr, arrOrder, blnIsSameNO, m_frmInput.IsChildPrice);
                        }
                        catch (System.Exception ex)
                        {
                            m_mthShowMessage(ex.Message);
                            return;
                        }
                    }
                    if (lngRes > 0)
                    {
                        //m_mthShowMessage("保存成功！");
                        //刷新数据
                        m_frmInput.Cursor = Cursors.WaitCursor;
                        m_mthLoadOrderList();
                        m_frmInput.Cursor = Cursors.Default;
                    }
                    else
                    {
                        m_mthShowMessage("新增医嘱失败！");
                    }
                    #endregion //end 组套
                }
                else
                {
                    #region 诊疗项目
                    clsBIHOrder objOrder = m_frmInput.m_objGetOrder(null);
                    if (objOrder == null) return;
                    //验证输入数据
                    if (!ValidateInput(objOrder)) return;

                    if (m_blnAddNew(objOrder))
                    {
                        //m_frmInput.m_objCurrentOrder=objOrder;
                        //m_frmInput.m_arlOrder.Add(objOrder);
                        //m_frmInput.m_dtgOrder.m_mthAppendRow(m_objGetDataRow(m_frmInput.m_arlOrder.Count,objOrder,null));
                        //m_frmInput.m_dtgOrder.CurrentCell=new DataGridCell(m_frmInput.m_arlOrder.Count-1,0);

                        //m_mthUpdateOrderByStatus();

                        //m_frmInput.m_cmdAdd_Click(null,null);
                        //刷新

                        //Modify by jli in 2004-05-06
                        //						m_frmInput.Cursor =Cursors.WaitCursor;
                        //						m_mthLoadOrderList();
                        //						m_frmInput.Cursor =Cursors.Default;

                        //Modify End

                    }
                    else
                    {
                        m_mthShowMessage("保存失败!");
                    }
                    #endregion //end 组套
                }
                #endregion
            }
            else if (m_frmInput.m_objCurrentOrder != null && m_frmInput.m_objCurrentOrder.m_strOrderID != null && (m_frmInput.m_objCurrentOrder.m_intStatus == 0 || m_frmInput.m_objCurrentOrder.m_intStatus == 7))
            {
                #region 修改
                clsBIHOrder objOrder = m_frmInput.m_objGetOrder(m_frmInput.m_objCurrentOrder);
                if (objOrder.m_strCreatorID.Trim() != m_frmInput.LoginInfo.m_strEmpID.Trim())
                {
                    MessageBox.Show(m_frmInput, "只能修改自己创建的医嘱！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //验证输入数据
                int intIsFather = 0;//是否为父级医嘱 {0=不是父级医嘱，1=是父级医嘱}
                if (!ValidateInput(objOrder, out intIsFather)) return;
                long ret = 0;
                if (intIsFather == 0)
                    ret = m_objInputOrder.m_lngModifyOrder(objOrder);
                else
                    ret = m_objInputOrder.m_lngModifyOrderWithSon(objOrder);
                if (ret > 0)
                {
                    if (intIsFather == 0)
                    { }
                    else
                    {
                        m_mthLoadOrderList();
                    }
                }
                else
                {
                    m_mthShowMessage("保存失败!");
                }
                #endregion
            }
            else if (m_frmInput.m_objCurrentOrder.m_intStatus == 2)//执行状态
            {
                #region 修改连续性医嘱的停止时间
                clsBIHOrder objOrder = m_frmInput.m_objGetOrder(m_frmInput.m_objCurrentOrder);
                if (m_strConfreqID.Trim() == "") m_strConfreqID = new clsDcl_ExecuteOrder().m_strGetConfreqID();
                if (objOrder.m_strExecFreqID.Trim() == m_strConfreqID.Trim())
                {
                    if (objOrder.m_dtStopdate > objOrder.m_dtStartDate)
                    {
                        long ret = m_objInputOrder.m_lngFillConOrderStopTime(objOrder.m_strOrderID, objOrder.m_dtStopdate);
                        m_mthLoadOrderList();
                        return;
                    }
                    else
                    {
                        m_mthShowMessage("停止时间必须在开始之后!");
                    }
                }
                else
                {
                    m_mthShowMessage("医嘱状态提示: 不能更改!");
                }
                #endregion
            }
            else
            {
                m_mthShowMessage("医嘱状态提示: 不能更改!");
            }
            //刷新缓存的信息	{费用}
            if (m_frmInput.m_objCurrentOrder != null && m_frmInput.m_objCurrentOrder.m_strOrderID != null)
            {
                if (m_htbToolTip.Contains(m_frmInput.m_objCurrentOrder.m_strOrderID))
                {
                    m_htbToolTip.Remove(m_frmInput.m_objCurrentOrder.m_strOrderID);
                }
                if (m_frmInput.m_lsvToolTip.Visible)
                {
                    m_DisPlayToolTipListView(m_frmInput.m_objCurrentOrder, m_frmInput.m_lsvToolTip);
                    m_frmInput.m_lsvToolTip.Refresh();
                }
            }
            m_mthRefreshOtherBillInfo();
            m_frmInput.m_ctlOrderDetail.m_mthStartInput();
        }

        /// <summary>
        /// 保存医嘱信息返回保存状态  p_intResult(1-新增医嘱,2-修改医嘱)
        /// </summary>
        public void m_mthSave(out int p_intResult, ref ArrayList m_arrOrderId)
        {
            p_intResult = 0;
            clsBIHPatientInfo objPatient = m_frmInput.m_ctlPatient.m_objPatient;
            if (objPatient == null)
            {
                m_mthShowMessage("请先指定病人!");
                m_frmInput.m_ctlPatient.Focus();
                return;
            }
            clsBIHOrderGroupService objTem = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
            /*  判断是否有大处方*/
            if (m_frmInput.m_blUpControl == true)
            {
                int MaxValue = 0;//当前用户权限的药品费用上限
                MaxValue = getMaxValue();//取当前用户权限的药品费用上限
                bool m_blPass = true;
                m_blPass = CheckTheUp(MaxValue);
                if (!m_blPass)
                {
                    p_intResult = -1;
                    return;
                }
            }
            if (m_frmInput.m_objCurrentOrder == null)
            {
                string[] m_arrPartID = null;
                string[] m_arrPartName = null;
                if (m_frmInput.m_ctlOrderDetail.m_txtCheck.Tag != null)
                {
                    m_arrPartID = ((string)m_frmInput.m_ctlOrderDetail.m_txtCheck.Tag).Split(",".ToCharArray());
                    m_arrPartName = m_frmInput.m_ctlOrderDetail.m_txtCheck.Text.Trim().Split(",".ToCharArray());
                }
                if (m_arrPartID == null || m_arrPartID.Length <= 1)//非多部位下生成一条医嘱
                {
                    #region 新增医嘱（在新增状态下，非子医嘱,非多部位下生成一条医嘱）
                    clsBIHOrder objOrder = m_frmInput.m_objGetOrder(null);
                    if (objOrder == null)
                    {
                        return;
                    }
                    lngAddNewNOSubOrder(ref objOrder);
                    m_arrOrderId.Add(objOrder.m_strOrderID);
                    #endregion
                }
                else//多部位下生成多条医嘱
                {
                    for (int i = 0; i < m_arrPartID.Length; i++)
                    {
                        #region 新增医嘱（在新增状态下，非子医嘱,多部位下生成多条医嘱）
                        clsBIHOrder objOrder = m_frmInput.m_objGetOrder(null);
                        if (objOrder == null)
                        {
                            return;
                        }

                        objOrder.m_strPARTID_VCHR = m_arrPartID[i];
                        if (m_arrPartName.Length > i)
                        {
                            objOrder.m_strPARTNAME_VCHR = m_arrPartName[i];
                        }
                        lngAddNewNOSubOrder(ref objOrder);
                        m_arrOrderId.Add(objOrder.m_strOrderID);
                        #endregion
                    }
                }
            }
            else if (m_frmInput.m_objCurrentOrder.m_strParentID.Trim() != "" && m_frmInput.m_objCurrentOrder.m_strOrderID.Trim() == "" && (m_frmInput.m_objCurrentOrder.m_intStatus == 0 || m_frmInput.m_objCurrentOrder.m_intStatus == 7))
            {
                #region 新增医嘱（在新增状态下，新增子医嘱）
                clsBIHOrder objOrder = m_frmInput.m_objGetOrder(null);
                if (objOrder == null)
                {
                    return;
                }
                #region 外送代煎判断

                for (int i = 0; i < this.m_frmInput.m_dtvOrder.RowCount; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)this.m_frmInput.m_dtvOrder.Rows[i].Tag;
                    if (order.m_intRecipenNo == objOrder.m_intRecipenNo)
                    {
                        if (order.IsProxyBoilMed != objOrder.IsProxyBoilMed)
                        {
                            string bmedInfo = string.Empty;
                            if (objOrder.IsProxyBoilMed == 0)
                                bmedInfo = "门诊中药房";
                            else if (objOrder.IsProxyBoilMed == 1)
                                bmedInfo = "代煎代送";
                            else if (objOrder.IsProxyBoilMed == 2)
                                bmedInfo = "中药代送";
                            DialogResult dialog = MessageBox.Show("子医嘱的【院外代送】属性与主医嘱不一致，是否继续保存？" + Environment.NewLine + Environment.NewLine + "选择【是】同方医嘱都将调整为--" + bmedInfo + ", 选择【否】将不保存返回重新录入医嘱。", "请注意", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialog == DialogResult.Yes)
                            {
                                break;
                            }
                            else if (dialog == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }
                #endregion
                ////验证输入数据
                //if (!ValidateInput(objOrder))
                //{
                //    p_intResult = -1;
                //    return;
                //}
                lngAddNewSubOrder(ref objOrder);
                m_arrOrderId.Add(objOrder.m_strOrderID);
                #endregion
            }
            else if (m_frmInput.m_objCurrentOrder != null && m_frmInput.m_objCurrentOrder.m_strOrderID != null && (m_frmInput.m_objCurrentOrder.m_intStatus == 0 || m_frmInput.m_objCurrentOrder.m_intStatus == 1 || m_frmInput.m_objCurrentOrder.m_intStatus == 5 || m_frmInput.m_objCurrentOrder.m_intStatus == 7 || (m_frmInput.m_objCurrentOrder.m_intStatus == 2 && m_frmInput.m_objCurrentOrder.m_intExecuteType == 1)))
            {
                #region 修改医嘱
                clsBIHOrder objOrder = m_frmInput.m_objCurrentOrder;
                m_frmInput.m_objGetChangedOrder(ref objOrder);
                lngChangedOrder(ref objOrder);
                m_arrOrderId.Add(objOrder.m_strOrderID);
                //验证输入数据
                //int intIsFather = 0;//是否为父级医嘱 {0=不是父级医嘱，1=是父级医嘱}
                //if (!ValidateInput(objOrder, out intIsFather))
                //{
                //    p_intResult = -8;
                //    return;
                //}

                /*<===================================*/
                //long ret = 0;
                //if (intIsFather == 0)//单条医嘱的修改
                //{
                //    //验查医嘱方号是否存在当前医嘱列表中，如不存在就置医嘱方号为０，并进行当前医嘱的新增方号的修改操作
                //    SetOrderByRecipenNo(objOrder);
                //    if (objOrder.m_intRecipenNo == 0)//加设方号 用于医嘱类型的转换医嘱的修改
                //    {
                //        ret = m_objInputOrder.m_lngModifyNewRecipenNoOrder(objOrder);
                //    }
                //    else
                //    {
                //        if (CheckTheSubOrder(objOrder))
                //        {
                //            //存在父医嘱时单条子医嘱的修改
                //            ret = m_objInputOrder.m_lngModifyCurrentSubOrder(objOrder);
                //        }
                //        else
                //        {
                //            //一般情况下的修改(不修改方号）
                //           ret = m_objInputOrder.m_lngModifyOrder(objOrder);
                //        }
                //    }
                //}
                //else//多条医嘱的修改(父子医嘱的修改)
                //{
                //    ret = m_objInputOrder.m_lngModifyOrderWithSon(objOrder);
                //}


                #endregion //end 修改
            }

            m_frmInput.m_objCurrentOrder = null;//重置当前 医嘱对象
            m_mthRefreshOtherBillInfo();
            m_frmInput.m_ctlOrderDetail.m_mthStartInput();

            /*转到医嘱输入焦点*/
            m_frmInput.m_ctlOrderDetail.m_txtOrderName.Focus();
        }

        /// <summary>
        /// //刷新缓存的信息	{费用}
        /// </summary>
        /// <param name="m_arrChangeOrderID">待刷新的医嘱流水号</param>
        public void lngRefreshChargePool(ArrayList m_arrChangeOrderID)
        {
            //刷新缓存的信息	{费用}
            for (int i = 0; i < m_arrChangeOrderID.Count; i++)
            {
                m_htbToolTip.Remove(m_arrChangeOrderID[i].ToString());
            }
            if (m_frmInput.m_lsvToolTip.Visible == true)
            {
                m_frmInput.m_dtvOrder_CellMouseClick(null, null);
            }
            /*<==============================*/
        }

        #region 医嘱的新增/修改
        /// <summary>
        /// 新增医嘱(单条非子医嘱)
        /// </summary>
        /// <param name="objOrder"></param>
        public void lngAddNewNOSubOrder(ref clsBIHOrder objOrder)
        {
            //设置医嘱的特殊字段 如领量，皮试，界面修改标志
            this.m_frmInput.m_ctlOrderDetail.SetTheOrderSpecial(ref objOrder);
            //判断领取药物数量是否大于库存量
            if (m_blChcekOpcurrentgross(ref objOrder) == false)
            {
                this.m_frmInput.m_ctlOrderDetail.m_txtOrderName.Focus();
                return;
            }
            if (m_blnAddNew(objOrder))
            {
            }

        }
        /// <summary>
        /// 判断领取药物数量是否大于库存量
        /// </summary>
        /// <param name="p_objOrder"></param>
        /// <returns>true 药品库存足 false 药品库存不足</returns>
        private bool m_blChcekOpcurrentgross(clsBIHOrder p_objOrder)
        {
            bool bl = true;
            //医嘱用药用量（一次领量与补次领量）
            float fltUseMediconeCount = Convert.ToSingle(p_objOrder.m_dmlGet + p_objOrder.m_intATTACHTIMES_INT * p_objOrder.m_dmlOneUse);
            if (p_objOrder.m_intIPCHARGEFLG_INT == 0)
            {
                fltUseMediconeCount = fltUseMediconeCount * Convert.ToSingle(p_objOrder.m_dmlPACKQTY_DEC);
            }
            if (p_objOrder.m_strOrderDicCateID == this.m_frmInput.m_objSpecateVo.m_strORDERCATEID_MEDICINE_CHR || p_objOrder.m_strOrderDicCateID == this.m_frmInput.m_objSpecateVo.m_strMID_MEDICINE_CHR)
            {
                //m_blIsChange为true时即是修改医嘱标记 false为新加医嘱标记
                if (this.m_frmInput.m_blIsChange == true)
                {
                    if ((this.m_frmInput.m_fotOpcurrentgross_num < fltUseMediconeCount) && this.m_frmInput.m_intITEMSRCTYPE_INT == 1)
                    {
                        MessageBox.Show(p_objOrder.m_strName + "库存不足，不能保存医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bl = false;
                    }
                    this.m_frmInput.m_blIsChange = false;
                    this.m_frmInput.m_fotOpcurrentgross_num = 0;
                    this.m_frmInput.m_intITEMSRCTYPE_INT = 0;
                }
                else
                {
                    if ((this.m_frmInput.m_ctlOrderDetail.m_fotOpcurrentgross_num < fltUseMediconeCount) && this.m_frmInput.m_ctlOrderDetail.m_intITEMSRCTYPE_INT == 1)
                    {
                        MessageBox.Show(p_objOrder.m_strName + "库存不足，不能保存医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bl = false;
                    }
                }
            }
            return bl;
        }

        /// <summary>
        /// 判断领取药物数量是否大于库存量
        /// </summary>
        /// <param name="p_objOrder"></param>
        /// <returns>true 药品库存足 false 药品库存不足</returns>
        internal bool m_blChcekOpcurrentgross(ref clsBIHOrder p_objOrder)
        {
            bool bl = true;
            //医嘱用药用量（一次领量与补次领量）
            decimal fltUseMediconeCount = Convert.ToDecimal(p_objOrder.m_dmlGet + p_objOrder.m_dmlOneUse * p_objOrder.m_intATTACHTIMES_INT);
            // 疗程用药
            if (p_objOrder.CureDays > 0) fltUseMediconeCount += p_objOrder.m_dmlGet * p_objOrder.CureDays;

            if (p_objOrder.m_intIPCHARGEFLG_INT == 0)
            {
                fltUseMediconeCount = fltUseMediconeCount * p_objOrder.m_dmlPACKQTY_DEC;
            }
            string m_strMedStore = "";
            //根据医嘱类型判断药房ID
            if (p_objOrder.m_strOrderDicCateID == this.m_frmInput.m_objSpecateVo.m_strORDERCATEID_MEDICINE_CHR)
            {
                m_strMedStore = this.m_frmInput.m_strMedCineStorgeId;
            }
            else if (p_objOrder.m_strOrderDicCateID == this.m_frmInput.m_objSpecateVo.m_strMID_MEDICINE_CHR)
            {
                m_strMedStore = this.m_frmInput.m_strMidMedCineSorgeId;
            }
            string m_strExecDeptID = "";
            if (!string.IsNullOrEmpty(m_strMedStore))
            {
                if (p_objOrder.RateType == 0 && this.m_frmInput.m_ctlOrderDetail.cboProxyBoil.SelectedIndex == 0)
                {
                    long l = -1;
                    string medCode = string.Empty;
                    l = this.m_lngGetMedStoreByDoctorWorkStation(m_strMedStore, p_objOrder.m_strOrderDicID, fltUseMediconeCount, out bl, out m_strExecDeptID, out medCode);

                    if (l < 0 || string.IsNullOrEmpty(m_strExecDeptID))
                    {
                        MessageBox.Show("药房没有药品(" + medCode + " " + p_objOrder.m_strName + ")的可用库存，请重新选择。", "提示框！");
                        return false;
                    }

                    if (bl == false)
                    {
                        MessageBox.Show(medCode + " " + p_objOrder.m_strName + "\r\n库存不足，不能保存医嘱？", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }

            // bl = this.m_blnCheckOrderSubItemGross(p_objOrder);//判断用法带出和辅助项目
            return bl;
        }

        /// <summary>
        ///  新增医嘱(单条子医嘱)
        /// </summary>
        /// <param name="objOrder"></param>
        /// <param name="m_arrChangeOrderID">费用缓存刷新受影响的流水号</param>
        public void lngAddNewSubOrder(ref clsBIHOrder objOrder)
        {
            //费用缓存刷新受影响的流水号
            ArrayList m_arrChangeOrderID = new ArrayList();
            //设置医嘱的特殊字段 如领量，皮试，界面修改标志
            this.m_frmInput.m_ctlOrderDetail.SetTheOrderSpecial(ref objOrder);
            //判断领取药物数量是否大于库存量
            if (m_blChcekOpcurrentgross(ref objOrder) == false)
            {
                this.m_frmInput.m_ctlOrderDetail.m_txtOrderName.Focus();
                return;
            }
            //获得要修改的相应同方医嘱
            ArrayList m_arrChangeList = getChangeListWithSonAdd(objOrder);
            clsBIHOrder[] arrOrder = null;
            if (m_arrChangeList.Count > 0)
            {
                arrOrder = (clsBIHOrder[])(m_arrChangeList.ToArray(typeof(clsBIHOrder)));
            }
            //设置同方医嘱的皮试
            SetTheGroupFeel(ref objOrder, ref arrOrder);
            /*<=======================================*/
            if (m_blnAddNew(objOrder, arrOrder))
            {
                if (arrOrder != null && arrOrder.Length > 0)
                {
                    for (int i = 0; i < arrOrder.Length; i++)
                    {
                        m_arrChangeOrderID.Add(arrOrder[i].m_strOrderID);
                    }
                }

            }
            lngRefreshChargePool(m_arrChangeOrderID);

        }

        /// <summary>
        ///  修改医嘱
        /// </summary>
        /// <param name="objOrder"></param>
        /// <param name="m_arrChangeOrderID">费用缓存刷新受影响的流水号</param>
        public void lngChangedOrder(ref clsBIHOrder objOrder)
        {
            //费用缓存刷新受影响的流水号
            ArrayList m_arrChangeOrderID = new ArrayList();
            //设置医嘱的特殊字段 如领量，皮试，界面修改标志
            this.m_frmInput.m_ctlOrderDetail.SetTheOrderSpecial(ref objOrder);
            //判断领取药物数量是否大于库存量
            if (m_blChcekOpcurrentgross(ref objOrder) == false)
            {
                this.m_frmInput.m_ctlOrderDetail.m_txtOrderName.Focus();
                return;
            }
            //获得要修改的相应同方医嘱  //得到同方的医嘱，一个或多个
            ArrayList m_arrChangeList = getChangeListWithSonAdd(objOrder);
            clsBIHOrder[] arrOrder = null;
            if (m_arrChangeList.Count > 0)
            {
                arrOrder = (clsBIHOrder[])(m_arrChangeList.ToArray(typeof(clsBIHOrder)));
            }
            //设置同方医嘱的皮试
            SetTheGroupFeel(ref objOrder, ref arrOrder);
            if (m_frmInput.m_objCurrentOrder == null)
            {
                return;
            }
            objOrder = m_frmInput.m_objCurrentOrder;
            if (!string.IsNullOrEmpty(m_frmInput.m_objCurrentOrder.m_strLISAPPLYUNITID_CHR) && m_frmInput.m_objCurrentOrder.m_intStatus == 1)
            {
                clsBIHLis objLis = new clsBIHLis();
                if (this.m_frmInput.m_blSendLisBill == true)
                {
                    clsCommitOrder objCommitLis = new clsCommitOrder();
                    clsDcl_CommitOrder m_objManage = new clsDcl_CommitOrder();
                    string strAp = "";
                    int intSampleFlag = 1;
                    long lngRes = m_objManage.m_lngGetOrderCommitByOrderID(ref strAp, objOrder.m_strOrderDicID, ref intSampleFlag, objOrder.m_strOrderID);

                    if (lngRes == -10)
                    {
                        MessageBox.Show(this.m_frmInput, "当前的医嘱状态已经改变，不能修改。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (intSampleFlag > 1)
                    {
                        MessageBox.Show(this.m_frmInput, "当前检验项目的标本已经采集，不能修改。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (intSampleFlag < 1)
                    {
                        MessageBox.Show(this.m_frmInput, "当前检验项目状态已经改变，不能修改。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool m_blnOK = false;
                    string message = "";
                    m_blnOK = objLis.m_mthDeleteApp(objOrder.m_strOrderID, out message);
                    if (m_blnOK == false)
                    {
                        MessageBox.Show(this.m_frmInput, "检验单修改失败！\r\n" + message, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    objCommitLis.m_strLISAPPLYUNITID_CHR = strAp;
                    this.m_frmInput.m_ctlOrderDetail.m_objGetCommitOrder(this.m_frmInput.m_ctlPatient.m_objPatient, objOrder, ref objCommitLis);

                    ArrayList m_arrHadSend = new ArrayList();
                    ArrayList m_arrAllNeedSend = new ArrayList();
                    ArrayList SendCheckArr = new ArrayList();

                    bool isHave = false;
                    if (this.m_frmInput.m_objSpecateVo != null && this.m_frmInput.m_objSpecateVo.m_strORDERCATEID_LIS_CHR.Trim().Equals(objCommitLis.m_strOrderDicCateID))
                    {
                        isHave = true;
                    }
                    if (isHave)
                    {
                        m_arrAllNeedSend.Add(objCommitLis);
                    }
                    SendCheckArr.Clear();
                    m_arrHadSend.Clear();
                    SendCheckArr.Add(objCommitLis);
                    m_arrHadSend.Add(objCommitLis.m_strLISAPPLYUNITID_CHR);
                    m_arrAllNeedSend.Remove(objCommitLis);
                    frmBIHOrderCommit objForm = new frmBIHOrderCommit();
                    if (SendCheckArr.Count > 0)
                    {
                        ArrayList m_arrLisOrder = null;
                        objForm.SetThePrice(ref SendCheckArr);


                        if (!objForm.sendTheCheck(ref SendCheckArr, out m_arrLisOrder))
                        {
                            MessageBox.Show(this.m_frmInput, "检验申请单发送失败。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            // 合理用药判断
            if (DrugUseItf(objOrder, arrOrder) == false) return;

            long ret = m_objInputOrder.m_lngModifyOrder(objOrder, arrOrder, m_frmInput.IsChildPrice);
            if (ret == -10)
            {
                MessageBox.Show(this.m_frmInput, "所修改的医嘱状态已经改变，不能再进行修改。", "医嘱录入", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.m_frmInput.cmdRefurbish_Click(null, null);
                return;
            }
            if (arrOrder != null && arrOrder.Length > 0)
            {
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    m_arrChangeOrderID.Add(arrOrder[i].m_strOrderID);
                }
            }
            lngRefreshChargePool(m_arrChangeOrderID);
        }
        #endregion



        /// <summary>
        /// 设置同方医嘱的皮试
        /// </summary>
        /// <param name="objOrder"></param>
        /// <param name="arrOrder"></param>
        public void SetTheGroupFeel(ref clsBIHOrder objOrder, ref clsBIHOrder[] arrOrder)
        {
            if (arrOrder == null || arrOrder.Length == 0)
            {
                return;
            }
            if (objOrder.m_intISNEEDFEEL == 0)//说明当前用法不用皮试，即同方的医嘱也不用皮试
            {
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    arrOrder[i].m_intISNEEDFEEL = 0;
                }
                return;
            }
            /*<======================================*/
            //************** 如果当前用法是皮试用去下的皮试处理逻辑   ************************===>

            //本条医嘱是皮试药品标志
            bool m_blSelf = false;
            //其它同方医嘱是皮试药品标志
            bool m_blOther = false;
            ArrayList m_arrOrderDic = new ArrayList();
            m_arrOrderDic.Add(objOrder.m_strOrderDicID);
            for (int i = 0; i < arrOrder.Length; i++)
            {
                if (!m_arrOrderDic.Contains(arrOrder[i].m_strOrderDicID))
                {
                    m_arrOrderDic.Add(arrOrder[i].m_strOrderDicID);
                }
            }
            ArrayList m_arrFeelList = new ArrayList();
            //查询诊疗项目对应的主收费项目是否需要皮试
            m_objInputOrder.m_lngGetFeelListbyOrderDic(m_arrOrderDic, out m_arrFeelList);
            /*<====================================*/
            if (m_arrFeelList != null && m_arrFeelList.Count > 0)
            {
                //如果是新增子医嘱操作时使用,因为arrOrder不包括新增的子医嘱
                if (m_arrFeelList.Contains(objOrder.m_strOrderDicID))
                {
                    objOrder.m_intISNEEDFEEL = 1;
                    m_blSelf = true;
                }
                /*<===============================*/
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    if (m_arrFeelList.Contains(arrOrder[i].m_strOrderDicID))
                    {
                        arrOrder[i].m_intISNEEDFEEL = 1;
                        if (arrOrder[i].m_strOrderDicID.Equals(objOrder.m_strOrderDicID))
                        {
                            m_blSelf = true;
                        }
                        else
                        {
                            m_blOther = true;
                        }
                    }
                    else
                    {
                        arrOrder[i].m_intISNEEDFEEL = 0;
                    }
                }
            }
            /*皮试情况，1.当前的本条医嘱及同方数组都不是皮试药时，就认同方医嘱的父医嘱为皮试，其它不是。
                        2.当前的同方医嘱数组中有皮试药时，认有皮试药的为皮试医嘱，非皮试药的同方医嘱为非皮试医嘱
                        
             */
            if (m_blSelf == false && m_blOther == false)//所有同方医嘱都不是皮试药
            {

                for (int i = 0; i < arrOrder.Length; i++)
                {
                    arrOrder[i].m_intISNEEDFEEL = 0;//同方的医嘱都设为不皮试
                }
                if (arrOrder.Length > 0)//第设父为皮试
                {
                    objOrder.m_intISNEEDFEEL = 0;//将本条医嘱设为非皮试
                    arrOrder[0].m_intISNEEDFEEL = 1;//如果是自身即为父医嘱
                }
            }
            else if (m_blSelf == false && m_blOther == true)//当前医嘱不是皮试药，但同方中有皮试药 
            {
                objOrder.m_intISNEEDFEEL = 0;//将本条医嘱设为非皮试
            }



        }

        /// <summary>
        /// 新增子医嘱及修改相应的父医嘱
        /// </summary>
        /// <param name="objOrder"></param>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        private bool m_blnAddNew(clsBIHOrder objOrder, clsBIHOrder[] arrOrder)
        {
            objOrder.m_intStatus = 0;
            // 当前是否是子医嘱操作
            if (this.m_frmInput.m_ctlOrderDetail.IsSubOrder == true)
            {
                objOrder.m_intIsSubOrderAdd = 1;
                objOrder.m_intIFPARENTID_INT = 0;
            }

            // 合理用药判断
            if (DrugUseItf(objOrder, arrOrder) == false) return false;

            /*<==============================*/
            //long ret=m_objService.m_lngCreateOrder(objOrder);
            string strRecordID = "";
            //long ret = m_objService.m_lngAddNewOrder(out strRecordID, objOrder);
            long ret = m_objService.m_lngAddNewOrderAndChanged(objOrder, arrOrder);
            if (ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得跟当前新增医嘱相关的待修改的同方医嘱(同组医嘱)
        /// </summary>
        /// <param name="m_intRecipenNo"></param>
        /// <returns></returns>
        private ArrayList getChangeListWithSonAdd(clsBIHOrder objOrder)
        {
            ArrayList m_arrChangeList = new ArrayList();
            bool m_blNeedChange = false;//true为需要修改，false为不需要修改
            for (int i = 0; i < this.m_frmInput.m_dtvOrder.RowCount; i++)
            {
                m_blNeedChange = false;
                clsBIHOrder order = (clsBIHOrder)this.m_frmInput.m_dtvOrder.Rows[i].Tag;
                if (order.m_intRecipenNo == objOrder.m_intRecipenNo)
                {
                    if (objOrder.m_intISNEEDFEEL == 0)//如果是要皮试的情况下，要父子全部进行再处理即用法为需要皮试时
                    {

                        if (!order.m_strOrderID.Equals(objOrder.m_strOrderID) && order.m_intExecuteType == objOrder.m_intExecuteType && order.m_strExecFreqID.Equals(objOrder.m_strExecFreqID) && order.m_strDosetypeID.Equals(objOrder.m_strDosetypeID) && order.m_intOUTGETMEDDAYS_INT == objOrder.m_intOUTGETMEDDAYS_INT)
                        {
                            m_blNeedChange = false;
                            //中药说明特殊处理
                            if (objOrder.m_strOrderDicCateID.Trim().Equals(this.m_frmInput.m_objSpecateVo.m_strMID_MEDICINE_CHR.Trim()))//中药判断
                            {
                                if (!order.m_strREMARK_VCHR.Trim().Equals(objOrder.m_strREMARK_VCHR.Trim()))
                                {
                                    m_blNeedChange = true;
                                }
                            }
                            if (order.IsProxyBoilMed != objOrder.IsProxyBoilMed)
                            {
                                m_blNeedChange = true;
                            }
                        }
                        else
                        {
                            m_blNeedChange = true;
                        }
                    }
                    else
                    {
                        m_blNeedChange = true;
                    }
                    if (m_blNeedChange == true)
                    {
                        if (!order.m_strOrderID.Equals(objOrder.m_strOrderID))
                        {
                            //重置同方医嘱
                            order.m_intExecuteType = objOrder.m_intExecuteType;//医嘱类型
                            order.m_strExecFreqID = objOrder.m_strExecFreqID;//医嘱频率
                            order.m_strExecFreqName = objOrder.m_strExecFreqName;
                            order.m_strEXECTIME_VCHR = objOrder.m_strEXECTIME_VCHR;
                            order.m_intATTACHTIMES_INT = objOrder.m_intATTACHTIMES_INT;//补次
                            order.m_intFreqTime = objOrder.m_intFreqTime;//频率次数
                            //中药的同方医嘱用法可不同
                            if (objOrder.m_strOrderDicCateID.Trim().Equals(this.m_frmInput.m_objSpecateVo.m_strMID_MEDICINE_CHR.Trim()))//中药判断
                            {
                                order.m_strREMARK_VCHR = objOrder.m_strREMARK_VCHR;
                            }
                            else
                            {
                                //医嘱用法
                                order.m_strDosetypeID = objOrder.m_strDosetypeID;
                                order.m_strDosetypeName = objOrder.m_strDosetypeName;
                            }
                            //天数/服数
                            order.m_intOUTGETMEDDAYS_INT = objOrder.m_intOUTGETMEDDAYS_INT;
                            // 院外代送
                            order.IsProxyBoilMed = objOrder.IsProxyBoilMed; 
                            //设置领量
                            this.m_frmInput.m_ctlOrderDetail.SetTheOrderGetMoust(ref order);
                            //设置皮试
                            this.m_frmInput.m_ctlOrderDetail.SetTheOrderNeelFeel(ref objOrder);

                            m_arrChangeList.Add(order);
                            this.m_frmInput.m_dtvOrder.Rows[i].Tag = order;
                        }
                        else
                        {
                            m_arrChangeList.Add(order);
                        }
                    }
                }
            }
            return m_arrChangeList;
        }

        /// <summary>
        /// 检查当前医嘱的方号是否等于其父医嘱的方号
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        private bool CheckTheSubOrder(clsBIHOrder objOrder)
        {
            bool m_blHave = false;
            for (int i = 0; i < m_frmInput.m_dtvOrder.RowCount; i++)
            {
                if (((clsBIHOrder)m_frmInput.m_dtvOrder.Rows[i].Tag).m_intRecipenNo == objOrder.m_intRecipenNo && ((clsBIHOrder)m_frmInput.m_dtvOrder.Rows[i].Tag).m_strOrderID == objOrder.m_strParentID)
                {
                    m_blHave = true;
                    break;
                }

            }
            return m_blHave;
        }

        /// <summary>
        /// 验查医嘱方号是否存在当前医嘱列表中，如不存在就置医嘱方号为０，并进行当前医嘱的新增方号的修改操作
        /// </summary>
        /// <param name="objOrder"></param>
        private void SetOrderByRecipenNo(clsBIHOrder objOrder)
        {
            bool m_blHave = false;
            for (int i = 0; i < m_frmInput.m_dtvOrder.RowCount; i++)
            {
                if (((clsBIHOrder)m_frmInput.m_dtvOrder.Rows[i].Tag).m_intRecipenNo == objOrder.m_intRecipenNo)
                {
                    m_blHave = true;
                    break;
                }

            }
            if (m_blHave == false)
            {
                objOrder.m_intRecipenNo = 0;
                objOrder.m_strParentID = "";
                objOrder.m_strParentName = "";
            }
        }

        /// <summary>
        /// 检验申请
        /// </summary>
        public bool sendTheCheck(ref clsBIHOrder objOrder)
        {

            string m_strSampleid = ((string)m_frmInput.m_ctlOrderDetail.m_txtSample.Tag).ToString().Trim();
            frmLisAppl obj = new frmLisAppl();
            clsLisApplMainVO objLMVO;
            clsTestApplyItme_VO[] itemArr_VO;
            DataTable p_dtResultArr;
            m_objService.m_lngAddNewCheckByOrderID(objOrder, out p_dtResultArr);
            m_objService.m_mthSendTestApplyBill(p_dtResultArr, m_strSampleid, objOrder, out objLMVO, out itemArr_VO);
            if (obj.m_mthNewAppInpatient(objLMVO, itemArr_VO, false) == System.Windows.Forms.DialogResult.OK)
            {
                //暂时注释
                clsLISAppResults[] objAppResult = obj.m_objGetMutiResults();
                if (objAppResult.Length > 0)
                {
                    objOrder.m_strLISAPPID_VCHR = objAppResult[0].m_StrApplicationID.ToString().Trim();
                    objOrder.m_strSAMPLEID_VCHR = m_strSampleid;
                }
            }
            else
            {

                return false;
            }
            return true;

        }

        #region 获取当前用户的药品上限值
        /// <summary>
        /// 获取当前用户的药品上限值
        /// </summary>
        /// <returns></returns>
        public int getMaxValue()
        {
            string strEmpID_chr = m_frmInput.LoginInfo.m_strEmpID.ToString().Trim();
            int maxvalue = 0;

            //clsBIHOrderGroupService objTem = new clsBIHOrderGroupService();
            clsBIHOrderGroupService objTem = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
            objTem.getMaxValue(strEmpID_chr, out maxvalue);
            return maxvalue;
        }
        #endregion

        #region 检验当前用户是否超过费用上限
        /// <summary>
        /// 检验当前用户是否超过费用上限
        /// </summary>
        /// <param name="MaxValue"></param>
        /// <returns></returns>
        public bool CheckTheUp(int MaxValue)
        {
            //clsBIHOrderGroupService objTem = new clsBIHOrderGroupService();
            clsBIHOrderGroupService objTem = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
            DataTable m_dtTable = new DataTable();
            if (m_frmInput.m_ctlOrderDetail.m_txtOrderName.Tag is clsBIHOrderGroup)
            {
                clsBIHOrderGroup bihGroup = (clsBIHOrderGroup)m_frmInput.m_ctlOrderDetail.m_txtOrderName.Tag;

                long m_lng = objTem.m_lngCheckGroupMoney(bihGroup.m_strGroupID.ToString().Trim(), MaxValue, out m_dtTable);
                if (m_lng > 0)
                {
                    if (m_dtTable.Rows.Count > 0)
                    {

                        frmOrderSaveCheck thefrmCheck = new frmOrderSaveCheck();
                        thefrmCheck.m_dtTable = m_dtTable;
                        thefrmCheck.m_strMessage = "[所选医嘱组套中有项目费用达到当前用户角色费用上限]";
                        if (thefrmCheck.ShowDialog() == DialogResult.OK)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }

            }
            else if (!((string)m_frmInput.m_ctlOrderDetail.m_txtOrderName.Tag).Equals(""))
            {
                double get_dec = 0.0;
                if (!m_frmInput.m_ctlOrderDetail.m_txtGet.Text.Trim().Equals(""))
                {
                    get_dec = System.Convert.ToDouble(m_frmInput.m_ctlOrderDetail.m_txtGet.Text.ToString().Trim());
                }
                else
                {
                    get_dec = 1;
                }
                string BIHOrderDic = (string)m_frmInput.m_ctlOrderDetail.m_txtOrderName.Tag;

                long m_lng = objTem.m_lngCheckMoneyByorderdicid(BIHOrderDic.ToString().Trim(), MaxValue, get_dec, out m_dtTable);
                if (m_lng > 0)
                {
                    if (m_dtTable.Rows.Count > 0)
                    {

                        frmOrderSaveCheck thefrmCheck = new frmOrderSaveCheck();
                        thefrmCheck.m_dtTable = m_dtTable;
                        thefrmCheck.m_strMessage = "[所选医嘱有项目费用达到当前用户角色费用上限]";
                        if (thefrmCheck.ShowDialog() == DialogResult.OK)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }

                //string m_decPrice = m_frmInput.m_ctlOrderDetail.m_txtPrice.Text.ToString().Trim();
                //double m_dblPrice = 0.0;
                //if (!m_decPrice.Equals(""))
                //{
                //    m_dblPrice = Convert.ToDouble(m_decPrice);
                //}
                //double dblNumber = 0.0;
                //if (!m_frmInput.m_ctlOrderDetail.m_txtGet.Text.Trim().Equals(""))
                //{
                //    dblNumber = System.Convert.ToDouble(m_frmInput.m_ctlOrderDetail.m_txtGet.Text.ToString().Trim());
                //}
                ////合计金额
                //double m_dbMoney = m_dblPrice * dblNumber;
                //if (m_dbMoney > MaxValue)
                //{
                //    m_dtTable.Columns.AddRange(new DataColumn[]
                //                                             {
                //                                            new DataColumn("NAME_CHR"),
                //                                            new DataColumn("ItemPrice"),
                //                                            new DataColumn("get_dec"),
                //                                            new DataColumn("pricesum") 
                //                                             });
                //    DataRow row1 = m_dtTable.NewRow();
                //    row1["NAME_CHR"] = m_frmInput.m_ctlOrderDetail.m_txtOrderName.Text.ToString().Trim();
                //    row1["ItemPrice"] = m_decPrice.ToString().Trim();
                //    row1["get_dec"] = dblNumber.ToString().Trim();
                //    row1["pricesum"] = m_dbMoney.ToString();
                //    m_dtTable.Rows.Add(row1);

                //    frmOrderSaveCheck thefrmCheck = new frmOrderSaveCheck();
                //    thefrmCheck.m_dtTable = m_dtTable;
                //    thefrmCheck.m_strMessage = "[所选医嘱项目费用达到当前用户角色费用上限]";
                //    if (thefrmCheck.ShowDialog() == DialogResult.OK)
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}

            }

            return true;
        }
        #endregion

        /// <summary>
        /// 增加医嘱
        /// </summary>
        /// <param name="objOrder">医嘱记录Vo对象</param>
        /// <returns>返回是否操作成功</returns>
        public bool m_blnAddNew(clsBIHOrder objOrder)
        {
            objOrder.m_intStatus = 0;
            // 当前是否是子医嘱操作
            if (this.m_frmInput.m_ctlOrderDetail.IsSubOrder == true)
            {
                objOrder.m_intIsSubOrderAdd = 1;
                objOrder.m_intIFPARENTID_INT = 0;
            }
            else
            {
                objOrder.m_intIFPARENTID_INT = 1;
            }

            // 合理用药判断
            if (DrugUseItf(objOrder) == false) return false;
            string strRecordID = "";
            long ret = m_objService.m_lngAddNewOrder(out strRecordID, objOrder);
            if (ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 合理用药
        /// <summary>
        /// 合理用药.服务地址
        /// </summary>
        string DrugServiceUrl { get; set; }
        /// <summary>
        /// 是否使用合理用药接口
        /// </summary>
        bool IsUseMedItf { get; set; }
        /// <summary>
        /// 合理用药.接口
        /// </summary>
        /// <param name="orderVo"></param>
        /// <returns></returns>
        bool DrugUseItf(clsBIHOrder orderVo)
        {
            return DrugUseItf(orderVo, null);
        }
        /// <summary>
        /// 合理用药.接口
        /// </summary>
        /// <returns></returns>
        bool DrugUseItf(clsBIHOrder orderMain, clsBIHOrder[] orderArr)
        {
            if (string.IsNullOrEmpty(DrugServiceUrl))
            {
                DrugServiceUrl = com.digitalwave.iCare.gui.HIS.clsPublic.m_strGetSysparm("0080");
                IsUseMedItf = (Convert.ToDecimal(com.digitalwave.iCare.gui.HIS.clsPublic.m_strGetSysparm("0082")) == 1 ? true : false);
            }

            List<clsBIHOrder> lstDeptMed = new List<clsBIHOrder>();
            Hisitf.EntityDrugUse patVo = new Hisitf.EntityDrugUse();
            Hisitf.EntityDrugUse drugVo = null;
            System.Collections.Generic.List<Hisitf.EntityDrugUse> lstDrug = new System.Collections.Generic.List<Hisitf.EntityDrugUse>();

            #region pat
            patVo.bedNo = m_frmInput.m_ctlPatient.m_objPatient.m_strBedID;
            //patVo.presType
            patVo.presSource = "住院";
            patVo.presDatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            patVo.payType = "";// ? 
            patVo.patientNo = m_frmInput.m_ctlPatient.m_objPatient.m_strPATIENTCARDID_CHR;
            patVo.presNo = "Z0";
            patVo.name = m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName;
            patVo.diagnose = m_frmInput.m_ctlPatient.m_objPatient.m_strDiagnose;
            patVo.age = m_frmInput.m_ctlPatient.m_objPatient.m_strAge;
            patVo.sex = (m_frmInput.m_ctlPatient.m_objPatient.m_strSex == "男" ? "M" : "F");  // ? M F 男
            patVo.drugSensivity = "false";      // 菌检

            #endregion

            #region use drug

            List<clsBIHOrder> lstOrder = new List<clsBIHOrder>();
            if (orderMain != null) lstOrder.Add(orderMain);
            if (orderArr != null) lstOrder.AddRange(orderArr);
            bool isSkipLevel = false;   // 越级使用抗生素(提一级): 初级 -> 中级 -> 副高
            DateTime dtmNow = DateTime.Now;
            if ((Convert.ToDateTime(dtmNow.ToString("yyyy-MM-dd") + " 17:30:00") < dtmNow && dtmNow < Convert.ToDateTime(dtmNow.ToString("yyyy-MM-dd") + " 23:59:59")) ||
                 (Convert.ToDateTime(dtmNow.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00") < dtmNow && dtmNow < Convert.ToDateTime(dtmNow.AddDays(1).ToString("yyyy-MM-dd") + " 07:59:59")))
            {
                isSkipLevel = true;
            }
            foreach (clsBIHOrder orderVo in lstOrder)
            {
                // 01 -- 药疗; 17 -- 中药
                if (orderVo.m_strOrderDicCateID == "01" || orderVo.m_strOrderDicCateID == "17")
                {
                    drugVo = new Hisitf.EntityDrugUse();
                    drugVo.drug = orderVo.m_strOrderDicID;
                    drugVo.drugName = orderVo.m_strName;
                    drugVo.specification = orderVo.m_strSpec;
                    drugVo.package = orderVo.m_dmlPACKQTY_DEC.ToString();
                    drugVo.quantity = orderVo.m_dmlGet.ToString();
                    drugVo.packUnit = orderVo.m_strGetunit;
                    drugVo.unitPrice = orderVo.m_dmlPrice.ToString();
                    drugVo.amount = com.digitalwave.iCare.gui.HIS.clsPublic.Round(orderVo.m_dmlPrice * orderVo.m_dmlGet, 2).ToString();
                    drugVo.groupNo = orderVo.m_intRecipenNo.ToString();
                    drugVo.firstUse = "false";
                    drugVo.adminRoute = orderVo.m_strDosetypeName;
                    drugVo.adminFrequency = orderVo.m_strExecFreqName;
                    drugVo.adminDose = orderVo.m_dmlDosage.ToString() + orderVo.m_strDosageUnit;    // +单位? 
                    //drugVo.adminMethod
                    if (orderVo.m_intExecuteType == 1)
                        drugVo.type1 = "长期";
                    else if (orderVo.m_intExecuteType == 2)
                        drugVo.type1 = "临时";
                    else if (orderVo.m_intExecuteType == 3)
                        drugVo.type1 = "带药";
                    //drugVo.adminGoal
                    drugVo.docID1 = orderVo.m_strCreatorID;
                    drugVo.docName1 = orderVo.m_strCreator;
                    if (isSkipLevel && !string.IsNullOrEmpty(m_frmInput.m_objLoginInfo.m_strTechnicalRank))
                    {
                        if (m_frmInput.m_objLoginInfo.m_strTechnicalRank.Trim() == "住院医师")
                            drugVo.docTitle1 = "主治医师";
                        else if (m_frmInput.m_objLoginInfo.m_strTechnicalRank.Trim() == "主治医师")
                            drugVo.docTitle1 = "副主任医师";
                        else if (m_frmInput.m_objLoginInfo.m_strTechnicalRank.Trim() == "副主任医师")
                            drugVo.docTitle1 = "主任医师";
                        else
                            drugVo.docTitle1 = m_frmInput.m_objLoginInfo.m_strTechnicalRank;

                        // 24小时后不能重新越级开具同一抗菌药物  -- 改为 -->  24小时后患者住院期间都不能再越级开同一抗菌
                        using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                        {
                            DataTable dt = svc.GetSkipLevelAntiMedcine(m_frmInput.m_ctlPatient.m_objPatient.m_strRegisterID, orderVo.m_strOrderDicID);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                DateTime dtmPost = Convert.ToDateTime(dt.Rows[0]["postdate_dat"].ToString());
                                DateTime dtmTmp = Convert.ToDateTime(dtmNow.ToString("yyyy-MM-dd") + " " + dtmPost.ToString("HH:mm:ss"));
                                TimeSpan ts = dtmNow.Subtract(dtmPost);
                                // 24小时以后且属于 越级时间段开具的
                                if (ts.Hours >= 24 && ((Convert.ToDateTime(dtmNow.ToString("yyyy-MM-dd") + " 17:30:00") < dtmTmp && dtmTmp < Convert.ToDateTime(dtmNow.ToString("yyyy-MM-dd") + " 23:59:59")) ||
                                                       (Convert.ToDateTime(dtmNow.ToString("yyyy-MM-dd") + " 00:00:00") < dtmTmp && dtmTmp < Convert.ToDateTime(dtmNow.ToString("yyyy-MM-dd") + " 07:59:59"))))
                                {
                                    MessageBox.Show("24小时后不能重新越级开具同一抗菌药物");
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        drugVo.docTitle1 = m_frmInput.m_objLoginInfo.m_strTechnicalRank;
                    }
                    drugVo.departID1 = orderVo.m_strCREATEAREA_ID;
                    drugVo.department1 = orderVo.m_strCREATEAREA_Name;
                    if (string.IsNullOrEmpty(drugVo.department1)) drugVo.department1 = m_frmInput.m_objLoginInfo.m_strdepartmentName;
                    //drugVo.nurseName
                    drugVo.startTime = orderVo.m_dtStartDate.ToString("yyyy-MM-dd HH:mm:ss");
                    drugVo.endTime = orderVo.m_dtFinishDate.ToString("yyyy-MM-dd HH:mm:ss");
                    if (drugVo.endTime.StartsWith("0001-01-01")) drugVo.endTime = string.Empty;
                    lstDrug.Add(drugVo);

                    // 科室药
                    if (orderVo.RateType == 2)
                    {
                        lstDeptMed.Add(orderVo);
                    }
                }
            }
            if (lstDrug.Count > 0)
            {
                patVo.docID = lstDrug[0].docID1;
                patVo.docName = lstDrug[0].docName1;
                patVo.docTitle = lstDrug[0].docTitle1;
            }

            #region 附加:非注射剂不能有执行本科这项操作
            if (lstDeptMed.Count > 0)
            {
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                foreach (clsBIHOrder item in lstDeptMed)
                {
                    if (svc.IsMedInjection(item.m_strOrderDicID, 1) == false)
                    {
                        MessageBox.Show("科室药(执行本科)只能是注射剂药品，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            #endregion

            #endregion

            // 合理用药接口
            if (lstDrug.Count > 0 && IsUseMedItf)
            {
                string orderDicID = string.Empty;
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                foreach (Hisitf.EntityDrugUse item in lstDrug)
                {
                    orderDicID += "'" + item.drug + "',";
                }
                Dictionary<string, clsMedicine_VO> dicMed = svc.GetMedInfoByOrderDicId(orderDicID.TrimEnd(','));
                svc = null;
                foreach (Hisitf.EntityDrugUse item in lstDrug)
                {
                    orderDicID = item.drug;
                    if (dicMed.ContainsKey(orderDicID))
                    {
                        item.drug = dicMed[orderDicID].m_strMedicineID;
                        item.drugName = dicMed[orderDicID].m_strMedicineName;
                    }
                }
                using (Hisitf.RationalDrugUseItf itf = new Hisitf.RationalDrugUseItf())
                {
                    return itf.CheckDrugUse(3, DrugServiceUrl, patVo, lstDrug);
                }
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 增加医嘱(复制一组医嘱，同方或不同方的情况下）
        /// </summary>
        /// <param name="p_strRecordIDArr"></param>
        /// <param name="objOrder">医嘱记录Vo对象</param>
        /// <returns>返回是否操作成功</returns>
        public long m_lngAddNewOrderByGroup(out string[] p_strRecordIDArr, ArrayList p_RecordArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngAddNewOrderByGroup(out p_strRecordIDArr, p_RecordArr, m_frmInput.IsChildPrice);
            return lngRes;

        }

        /// <summary>
        /// 获取医嘱(根据医嘱流水号)
        /// </summary>
        /// <param name="p_strRecordIDArr"></param>
        /// <param name="objOrder">医嘱记录Vo对象</param>
        /// <returns>返回是否操作成功</returns>
        public long m_lngGetOrderByOrderIDs(string m_strORDERID_CHR, out clsBIHOrder[] m_objOrder)
        {
            long lngRes = 0;
            m_objOrder = null;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            //lngRes = objSvc.m_lngGetOrderByOrderIDs( m_strORDERID_CHR, out  m_objOrder);
            return lngRes;

        }

        /// <summary>
        /// 根据住院登记流水号停医嘱
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strHandlersID"></param>
        /// <param name="p_strHandlers"></param>
        /// <returns></returns>
        public bool m_lngStopANDAuditingOrderByRegID(string p_strRegisterID, string p_strHandlersID, string p_strHandlers)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngStopANDAuditingOrderByRegID(objPrincipal, p_strRegisterID, p_strHandlersID, p_strHandlers);
            if (lngRes > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据住院登记流水号停医嘱
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strHandlersID"></param>
        /// <param name="p_strHandlers"></param>
        /// <returns></returns>
        public bool m_lngStopAllOrderByRegID(string p_strRegisterID, string p_strHandlersID, string p_strHandlers)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngStopAllOrderByRegID(p_strRegisterID, p_strHandlersID, p_strHandlers);
            if (lngRes > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public long m_lngGetOrderStopSign(string[] m_arrOrders, out DataTable m_dtOrderSign)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngGetOrderStopSign(m_arrOrders, out  m_dtOrderSign);
            return lngRes;
        }

        /// <summary>
        /// 增加医嘱 [这里没有用事务]
        /// </summary>
        /// <param name="arrOrder">医嘱记录Vo对象 [数组]</param>
        /// <returns>返回是否操作成功</returns>
        public bool m_blnAddNew(clsBIHOrder[] arrOrder)
        {
            if ((arrOrder == null) || (arrOrder.Length <= 0)) return true;

            for (int i = 0; i < arrOrder.Length; i++) arrOrder[i].m_intStatus = 0;

            string strParentID = "";
            string strRecordID = "";
            //long ret=m_objService.m_lngCreateOrder(arrOrder[0]);
            long ret = m_objService.m_lngAddNewOrder(out strRecordID, arrOrder[0]);

            if (ret > 0)
            {
                strParentID = arrOrder[0].m_strOrderID;
            }
            else
            {
                return false;
            }
            for (int i = 1; i < arrOrder.Length; i++)
            {
                arrOrder[i].m_strParentID = strParentID;
                long ret2 = m_objService.m_lngCreateOrder(arrOrder[i]);
            }
            return true;
        }
        /// <summary>
        /// 验证医嘱录入数据是否合法
        /// </summary>
        /// <param name="objOrder">医嘱Vo对象</param>
        /// <returns></returns>
        public bool ValidateInput(clsBIHOrder objOrder)
        {
            int intIsFather = 0;
            return ValidateInput(objOrder, out intIsFather);
        }
        /// <summary>
        /// 验证医嘱录入数据是否合法
        /// </summary>
        /// <param name="objOrder"></param>
        /// <param name="p_intIsFather">是否为父级医嘱 {0=不是父级医嘱，1=是父级医嘱}</param>
        /// <returns></returns>
        public bool ValidateInput(clsBIHOrder objOrder, out int p_intIsFather)
        {
            long lngRes = 0;
            p_intIsFather = 0;
            if (objOrder == null) return false;
            //执行频率
            if (m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.Enabled == true)
            {
                if (objOrder.m_strExecFreqID == null || objOrder.m_strExecFreqID.Trim() == "")
                {
                    m_mthShowMessage("执行频率不能少!");
                    m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.Focus();
                    return false;
                }
            }
            else
            {
                if (objOrder.m_strExecFreqID == null || objOrder.m_strExecFreqID.Trim() == "")
                {
                    objOrder.m_strExecFreqID = "15";
                }
            }
            //用药方式验证	{根据医嘱类型ID：用法显示类型{1=正常;2=无},=2时不计费}
            clsT_aid_bih_ordercate_VO p_objOrdercate = null;
            if (objOrder.m_strDosetypeID == null || objOrder.m_strDosetypeID.Trim() == "")
            {
                lngRes = m_objInputOrder.m_lngGetAidOrderCateByID(objOrder.m_strOrderDicCateID, out p_objOrdercate);
                if (lngRes > 0 && p_objOrdercate != null && p_objOrdercate.m_intUSAGEVIEWTYPE != 2)
                {
                    m_mthShowMessage("用药方式不能少!");
                    m_frmInput.m_ctlOrderDetail.m_txtDosageType.Focus();
                    return false;
                }
            }
            //诊疗项目
            if (objOrder.m_strOrderDicID == null || objOrder.m_strOrderDicID.Trim() == "")
            {
                m_mthShowMessage("医嘱录入数据不合法,请刷新后重新输入!");
                m_frmInput.m_ctlOrderDetail.m_txtOrderName.Focus();
                return false;
            }
            //同方号则，用法和频率必须相同
            //if(!PassSameRecipeNO(objOrder))
            //{
            //    if(objOrder.m_strParentID!=null && objOrder.m_strParentID.Trim()!="")
            //    { //子医嘱同方号则，用法和频率必须相同
            //        m_mthShowMessage("同方号则，用法和频率必须相同!");
            //        return false;
            //    }
            //    else
            //    {
            //        p_intIsFather =1;
            //    }
            //}
            //同方医嘱修改时的界面控制
            bool m_blParentOrder, m_blSubOrder;
            m_frmInput.TheChangedOrderParentOrSub(objOrder, out m_blParentOrder, out m_blSubOrder);
            if (m_blParentOrder == true)
            {
                p_intIsFather = 1;
            }
            //[非连续性、剂量显示类型为正常的医嘱]剂量、用量、领量 必须大于0			
            if (objOrder.m_dmlDosage <= 0 || objOrder.m_dmlGet <= 0 || objOrder.m_dmlUse <= 0)
            {
                if (m_strConfreqID.Trim() == "") m_strConfreqID = new clsDcl_ExecuteOrder().m_strGetConfreqID();
                if (p_objOrdercate == null)
                {
                    lngRes = m_objInputOrder.m_lngGetAidOrderCateByID(objOrder.m_strOrderDicCateID, out p_objOrdercate);
                }
                if (objOrder.m_strExecFreqID.Trim() != m_strConfreqID.Trim() && p_objOrdercate.m_intDOSAGEVIEWTYPE != 2)
                {
                    //m_mthShowMessage("剂量、用量、领量 必须大于0！");
                    //m_frmInput.m_ctlOrderDetail.m_txtDosage.Focus();
                    //return false;
                }
            }
            //连续性医嘱: 开始时间	{最多当前时间前6小时}
            if (m_strConfreqID.Trim() == "") m_strConfreqID = new clsDcl_ExecuteOrder().m_strGetConfreqID();
            if (objOrder.m_strExecFreqID.Trim() == m_strConfreqID.Trim())
            {
                if (objOrder.m_dtStartDate < System.DateTime.Now.AddHours(-6))
                {
                    m_mthShowMessage("开始时间最多比当前时间前6小时！");
                    return false;
                }
            }
            return true;
        }
        #endregion
        #region 附加单据
        private void m_mthRefreshOtherBillInfo()
        {
            m_arlOtherBillInfo.Clear();

            clsBIHOrder[] arrOrder = (clsBIHOrder[])(m_frmInput.m_arlOrder.ToArray(typeof(clsBIHOrder)));
            clsOrderDicCates.Cate_tag = false;
            for (int i = 0; i < arrOrder.Length; i++)
            {
                if (clsOrderDicCates.IsMedOrder(arrOrder[i].m_strOrderDicCateID))
                {
                    clsBIHOrderCate objCate = clsOrderDicCates.m_objGetCate(arrOrder[i].m_strOrderDicCateID);
                    clsOtherBillInfo objInfo = new clsOtherBillInfo();
                    objInfo.m_objOrder = arrOrder[i];
                    objInfo.m_objOrderCate = objCate;
                    objInfo.m_objService = this.m_objService;
                    objInfo.m_ParentForm = this.m_frmInput;
                    objInfo.m_ParentForm.objController = this.m_frmInput.objController;
                    m_arlOtherBillInfo.Add(objInfo);
                }
            }

            m_frmInput.m_lblOtherBill.Text = "附加单据(" + m_arlOtherBillInfo.Count.ToString() + ")";
            if (m_arlOtherBillInfo.Count <= 0)
            {
                this.m_frmInput.m_btnAddBills.Enabled = false;
            }
            else
            {
                this.m_frmInput.m_btnAddBills.Enabled = true;
            }
        }

        //保存当前附加单据信息
        public ArrayList m_arlOtherBillInfo = new ArrayList();
        public class clsOtherBillInfo
        {
            public clsBIHOrder m_objOrder;
            public clsBIHOrderCate m_objOrderCate;
            public clsBIHOrderService m_objService;

            public string m_strRelationID = "";

            public iCareData.clsApplyReport_T_VO m_objART = new iCareData.clsApplyReport_T_VO();
            public com.digitalwave.GUI_Base.frmMDI_Child_Base m_ParentForm;

            public static clsBIHPatientInfo s_objPatient;

            #region 附加单据数目
            private int m_intAttachOrderCount = -1;
            /// <summary>
            /// 附加单据数目
            /// </summary>
            private void m_mthRefreshAttachOrderCount()
            {
                string[] arrID;
                long ret = m_objService.m_lngGetAttachOrder(m_objOrder.m_strOrderID, out arrID);
                if ((ret > 0) && (arrID != null))
                    m_intAttachOrderCount = arrID.Length;
                else
                    m_intAttachOrderCount = -1;
            }
            /// <summary>
            /// 获取附加单据数目
            /// </summary>
            public int AttachOrderCount
            {
                get
                {
                    if (m_intAttachOrderCount < 0) m_mthRefreshAttachOrderCount();
                    return m_intAttachOrderCount;
                }
            }

            #endregion

            #region 显示附加单据窗口
            /// <summary>
            /// 显示附加单据窗口
            /// </summary>
            /// <param name="objEmp">登陆信息</param>
            public void m_mthShowUI(clsLoginInfo objEmp)
            {
                //医嘱类型ID
                string strOrderCateID = m_objOrderCate.m_strOrderCateID.Trim();
                //病人ID
                string strPatientID = m_objOrder.m_strPatientID;
                //医嘱单ID
                string strOrderID = m_objOrder.m_strOrderID;
                //附加单据ID
                string strAttachID = GetAttachID(strOrderID);

                int intEditState = 0;
                long lngRes = 0;

                //加入查询附加单据的代码.
                DataTable dtbAddBills = null;
                lngRes = m_lngGetAddBillByOrderID(strOrderID.Trim(), out dtbAddBills);
                if (lngRes >= 0 && dtbAddBills.Rows.Count > 0)
                {
                    intEditState = 1;
                    m_objART.m_StrRecordID = dtbAddBills.Rows[0]["ATTACHID_VCHR"].ToString().Trim();
                }
                else
                {
                    intEditState = 0;
                }

                //编辑状态{0=增加;1=编辑;2=只读;}
                //				if(m_objOrder.m_intStatus==0 || m_objOrder.m_intStatus==7)//只能编辑创建状态的附加单据
                //				{
                //					if(strAttachID.Trim()!="")
                //						intEditState =1;
                //					else
                //						intEditState =0;
                //				}
                //				else
                //				{
                //					if(strAttachID.Trim()!="")
                //						intEditState =2;
                //					else
                //					{	//执行状态不为“0=创建”并且没有附加单据，则不显示！
                //						//不显示就不显示,干嘛这么激动? by jli in 2005-04-12
                //						return;
                //					}
                //				}

                //获取医嘱类型Vo
                clsT_aid_bih_ordercate_VO objResult = null;
                clsDcl_InputOrder objTem = new clsDcl_InputOrder();
                lngRes = objTem.m_lngGetAidOrderCateByID(strOrderCateID, out objResult);
                if (lngRes <= 0 || objResult == null) return;

                try
                {
                    m_mthOpenEditAidOrderForm(dtbAddBills, objResult, strAttachID.Trim());
                    m_mthRefreshAttachOrderCount();
                }
                catch (Exception err)
                {
                    string strMsg = err.Message.ToString();
                    try
                    {
                        com.digitalwave.Utility.clsLogText objText = new com.digitalwave.Utility.clsLogText();
                        objText.Log2File("d:\\code\\log.txt", err.Message.ToString() + "\r\n" + err.InnerException.Message.ToString() + "\r\n" + err.StackTrace.ToString());
                    }
                    catch
                    { }
                    MessageBox.Show("加载附加单据失败!");
                }
            }
            /// <summary>
            /// 获取医嘱附加单据ID
            /// </summary>
            /// <param name="strOrderID">医嘱ID</param>
            /// <returns>附加单据ID</returns>
            private string GetAttachID(string strOrderID)
            {
                //附加表单id
                string[] strAttachIDArr;
                long ret = m_objService.m_lngGetAttachOrder(strOrderID, out strAttachIDArr);
                if (ret > 0 && strAttachIDArr != null && strAttachIDArr.Length > 0)
                    return strAttachIDArr[0];
                else
                    return "";
            }
            #region 显示附加单据窗口编辑窗口-保存编辑后的数据
            /// <summary>
            /// 显示附加单据窗口编辑窗口
            /// </summary>
            /// <param name="strPatientID">病人ID</param>
            /// <param name="strOrderID">医嘱单ID</param>
            /// <param name="strAttachID">附加单据ID</param>
            /// <param name="intEditState">编辑状态{0=增加;1=编辑;2=只读;}</param>
            /// <param name="objResult">医嘱类型Vo</param>
            private void OpenEditAidOrderForm(string strPatientID, string strOrderID, string strAttachID, int intEditState, clsT_aid_bih_ordercate_VO objResult)
            {
                string strDllName = objResult.m_strDLLNAME_VCHR;
                string strClassName = objResult.m_strCLASSNAME_VCHR;
                string strInsertName = objResult.m_strOPRADD_VCHR;
                string strUpdateName = objResult.m_strOPRUPD_VCHR;

                System.Reflection.Assembly objAsm = System.Reflection.Assembly.LoadFrom(strDllName);
                if (objAsm == null) return;
                //设置参数
                object[] objParams = new object[4];
                objParams[0] = strPatientID;
                objParams[1] = strOrderID;
                objParams[2] = strAttachID;
                objParams[3] = intEditState;
                object obj;
                try
                {
                    obj = objAsm.CreateInstance(strClassName, true, System.Reflection.BindingFlags.Default, null, objParams, null, new object[0] { });
                }
                catch (System.Exception err)
                {
                    string strMsg = err.Message.ToString();
                    MessageBox.Show(strMsg);
                    return;
                }
                if (obj == null) return;
                //打开窗体
                Type objType = obj.GetType();
                System.Reflection.MethodInfo objMi = objType.GetMethod("ShowDialog", new Type[0]);
                if (objMi == null) return;
                objMi.Invoke(obj, new object[0] { });
            }
            #endregion
            #endregion

            #region 显示附加单据编辑窗口:保存编辑后的数据 Add by jli in 2005-04-11
            private void m_mthOpenEditAidOrderForm(DataTable p_dtbAddBill, clsT_aid_bih_ordercate_VO objResult, string p_strAttachID)
            {
                string strDllName = objResult.m_strDLLNAME_VCHR;
                string strClassName = objResult.m_strCLASSNAME_VCHR;
                string strInsertName = objResult.m_strOPRADD_VCHR;
                string strUpdateName = objResult.m_strOPRUPD_VCHR;

                System.Reflection.Assembly objAsm = System.Reflection.Assembly.LoadFrom(strDllName);

                if (objAsm == null) return;
                //设置参数

                #region 调用参数赋值

                //病区ID
                if (s_objPatient.m_strAreaID != null)
                {
                    m_objART.m_StrAreaID = s_objPatient.m_strAreaID;
                }
                else
                {
                    m_objART.m_StrAreaID = "";
                }

                //送检医生ID
                if (m_ParentForm.LoginInfo.m_strEmpID != null)
                {
                    m_objART.m_StrDeliverDoctorID = m_ParentForm.LoginInfo.m_strEmpID;
                }
                else
                {
                    m_objART.m_StrDeliverDoctorID = "";
                }

                //病区名称
                if (s_objPatient.m_strAreaName != null)
                {
                    m_objART.m_StrAreaName = s_objPatient.m_strAreaName;
                }
                else
                {
                    m_objART.m_StrAreaName = "";
                }

                //床号
                if (s_objPatient.m_strBedID != null)
                {
                    m_objART.m_StrBedID = s_objPatient.m_strBedID;
                }
                else
                {
                    m_objART.m_StrBedID = "";
                }

                //床名称
                if (s_objPatient.m_strBedName != null)
                {
                    m_objART.m_StrBedName = s_objPatient.m_strBedName;
                }
                else
                {
                    m_objART.m_StrBedName = "";
                }

                //科室ID
                if (s_objPatient.m_strDeptID != null)
                {
                    m_objART.m_StrDeptID = s_objPatient.m_strDeptID;
                }
                else
                {
                    m_objART.m_StrDeptID = "";
                }

                //科室名称
                if (s_objPatient.m_strBedID != null)
                {
                    try
                    {
                        clsDepartmentVO[] m_objDeptArr = new clsDepartmentVO[] { new clsDepartmentVO() };
                        m_ParentForm.objController.m_objComInfo.m_mthGetDepInfoByDepID(m_objART.m_StrDeptID, out m_objDeptArr);
                        m_objART.m_StrDeptName = m_objDeptArr[0].strDeptName;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    m_objART.m_StrDeptName = "";
                }

                //住院号
                if (s_objPatient.m_strInHospitalNo != null)
                {
                    m_objART.m_StrInPatientID = s_objPatient.m_strInHospitalNo;
                }
                else
                {
                    m_objART.m_StrInPatientID = "";
                }

                if (s_objPatient.m_dtBorn != DateTime.MinValue)
                {
                    //change 2007.4.13
                    //TimeSpan ts=DateTime.Now-s_objPatient.m_dtBorn;
                    //string strAge="";
                    //strAge = com.digitalwave.iCare.gui.LIS.clsAgeConverter.s_strToAge(s_objPatient.m_dtBorn);
                    //=====================>>
                    string strAge = "";
                    strAge = com.digitalwave.iCare.gui.LIS.clsAgeConverter.s_strGetAge(s_objPatient.m_dtBorn);
                    /*<<====================*/
                    //					if(ts.TotalDays>365d)
                    //					{
                    //						strAge=((int)(ts.TotalDays/365d)).ToString()+"岁";
                    //					}
                    //					else
                    //					{
                    //						strAge=((int)(ts.TotalDays/30d)).ToString()+"月";
                    //					}
                    //					m_objART.m_StrInPatientID=s_objPatient.m_strInHospitalNo;
                }
                else
                {
                    m_objART.m_StrInPatientID = "";
                }

                //临床诊断
                //Add by jli in 2005-06-17
                DataTable dtbRegister = new DataTable();
                if (new clsAddBillsOperate().m_lngGetRegisterInfoByFilter(" INPATIENTID_CHR='" + s_objPatient.m_strInHospitalNo.Trim() + "'", out dtbRegister) > 0)
                {
                    m_objART.m_StrClinicDiagnose = dtbRegister.Rows[0]["DIAGNOSEID_CHR"].ToString().Trim();
                }
                else
                {
                    m_objART.m_StrClinicDiagnose = "";
                }
                //Add end

                //病人ID
                if (s_objPatient.m_strPatientID != null)
                {
                    m_objART.m_StrPatientID = s_objPatient.m_strPatientID;
                }
                else
                {
                    m_objART.m_StrPatientID = "";
                }

                //卡号

                if (s_objPatient.m_strPatientID != null)
                {
                    try
                    {
                        clsPatientVO[] objPatient = new clsPatientVO[0];
                        m_ParentForm.objController.m_objComInfo.m_mthGetPatientInfo(s_objPatient.m_strPatientID, out objPatient, true);
                        //卡号
                        m_objART.m_StrPatientCardID = ((frmBIHOrderInput)m_ParentForm).PatientCardID.Trim();
                        //籍贯
                        m_objART.m_StrNation = objPatient[0].strNationality.Trim();
                        //职业
                        m_objART.m_StrOccupy = objPatient[0].strOccupation.Trim();
                        //门诊号
                    }
                    catch
                    {
                    }
                }
                else
                {
                    m_objART.m_StrPatientCardID = "";
                    m_objART.m_StrNation = "";
                    m_objART.m_StrOccupy = "";

                }



                //病人姓名
                if (s_objPatient.m_strPatientName != null)
                {
                    m_objART.m_StrPatientName = s_objPatient.m_strPatientName;
                }
                else
                {
                    m_objART.m_StrPatientName = "";
                }

                //病人性别
                if (s_objPatient.m_strSex != null)
                {
                    m_objART.m_StrPatientSex = s_objPatient.m_strSex;
                }
                else
                {
                    m_objART.m_StrPatientSex = "";
                }

                #endregion

                object[] objParams = new object[1];

                if (p_strAttachID.Trim() == "")
                {
                    objParams[0] = m_objART;
                    m_strRelationID = "";
                }
                else
                {
                    objParams[0] = p_strAttachID.Trim();
                    m_strRelationID = p_dtbAddBill.Rows[0]["ATTARELAID_CHR"].ToString().Trim();
                }

                object obj;
                try
                {

                    obj = objAsm.CreateInstance(strClassName, true, System.Reflection.BindingFlags.Default, null, objParams, null, new object[0] { });
                }
                catch (System.Exception err)
                {
                    string strMsg = err.Message.ToString();
                    MessageBox.Show(strMsg);
                    return;
                }
                if (obj == null) return;
                //打开窗体
                ((Form)obj).ShowDialog();
                Type objType = obj.GetType();
                System.Reflection.PropertyInfo objMi = objType.GetProperty("m_StrRecordID");
                string strAddBillRecordID = objMi.GetValue(obj, null).ToString();
                if (strAddBillRecordID.Trim() != "")
                {
                    m_lngSaveAddBill(strAddBillRecordID.Trim());
                }
                return;
            }
            #endregion

            /// <summary>
            /// 保存附加单据
            /// </summary>
            /// <param name="p_strAddBillRecordID">附加单据ID</param>
            /// <returns></returns>
            private long m_lngSaveAddBill(string p_strAddBillRecordID)
            {
                clsRelation_StrArr objAddBill = new clsRelation_StrArr();

                objAddBill.m_strValues = new string[1, 5];

                objAddBill.m_strValues[0, 0] = m_strRelationID.Trim();
                objAddBill.m_strValues[0, 1] = "2";
                objAddBill.m_strValues[0, 2] = "";
                objAddBill.m_strValues[0, 3] = this.m_objOrder.m_strOrderID.Trim();
                objAddBill.m_strValues[0, 4] = p_strAddBillRecordID.Trim();

                try
                {
                    clsRelationService_STR objAddBillSRV = new clsRelationService_STR();
                    long lngRes = 0;
                    if (m_strRelationID.Trim() != "")
                    {
                        lngRes = objAddBill.m_lngUpdate();

                    }
                    else
                    {
                        lngRes = objAddBill.m_lngInsertRelation();
                    }
                    return lngRes;
                }
                catch
                {
                    return -1;
                }
            }

            /// <summary>
            /// 查询医嘱的附加单据
            /// </summary>
            /// <param name="p_strOrderID">医嘱ID</param>
            /// <param name="dtbAddBills">附加单据列表</param>
            /// <returns></returns>
            public long m_lngGetAddBillByOrderID(string p_strOrderID, out DataTable dtbCurrAddBill)
            {
                dtbCurrAddBill = new DataTable();
                try
                {
                    clsRelation_DTable dtbRes = new clsRelation_DTable();
                    long lngRes = dtbRes.m_lngGetRelation(" sourceitemid_vchr='" + p_strOrderID.Trim() + "'");
                    dtbCurrAddBill = dtbRes.m_dtbValues;
                    return lngRes;
                }
                catch
                {
                    return -1;
                }
            }

            public override string ToString()
            {
                //return m_objOrderCate.m_strName + " : " + m_objOrder.m_intRecipenNo + "-" + m_objOrder.m_strName;
                return m_objOrder.m_intRecipenNo + ":" + m_objOrder.m_strName + "\n[" + m_objOrderCate.m_strName + "]";
            }

        }

        public void m_ctxOtherBill_Popup(ContextMenu objMenu)
        {
            clsOtherBillInfo.s_objPatient = this.m_frmInput.m_ctlPatient.m_objPatient;

            objMenu.MenuItems.Clear();
            for (int i = 0; i < m_arlOtherBillInfo.Count; i++)
            {
                string strText = ((int)(i + 1)).ToString() + "\t" + (m_arlOtherBillInfo[i] as clsOtherBillInfo).ToString();
                MenuItem objItem = new MenuItem(strText);
                objItem.Checked = ((m_arlOtherBillInfo[i] as clsOtherBillInfo).AttachOrderCount > 0);
                objItem.Click += new EventHandler(objItem_Click);
                objItem.Index = i;

                objMenu.MenuItems.Add(objItem);
            }
        }
        private void objItem_Click(object sender, EventArgs e)
        {
            MenuItem objItem = sender as MenuItem;
            if (objItem == null) return;
            int intIndex = objItem.Index;
            if ((intIndex >= 0) && (intIndex < m_arlOtherBillInfo.Count))
            {
                clsOtherBillInfo objBillInfo = ((clsOtherBillInfo)m_arlOtherBillInfo[intIndex]);
                objBillInfo.m_ParentForm = this.m_frmInput;
                objBillInfo.m_ParentForm.objController = this.m_frmInput.objController;
                objBillInfo.m_mthShowUI(m_frmInput.LoginInfo);
            }
        }

        public void m_lblOtherBill_Click(object sender, System.EventArgs e)
        {
            if (m_arlOtherBillInfo.Count > 0)
            {
                try
                {
                    m_frmInput.m_ctxOtherBill.Show(m_frmInput.m_lblOtherBill, new Point(m_frmInput.m_lblOtherBill.Location.X, 0));
                }
                catch//(System.Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
        #region 方法
        public void m_mthSetGridRowColor(int intType, int intStatus, int intRow)
        {
            Color clrBack, clrFore;
            m_frmInput.m_mthGetColorByStatus(intType, intStatus, out clrBack, out clrFore);
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            style1.ForeColor = clrFore;
            style1.BackColor = clrBack;
            m_frmInput.m_dtvOrder.Rows[intRow].DefaultCellStyle = style1;
        }
        public void m_mthRefreshGridColor()
        {
            try
            {
                for (int i = 0; i < m_frmInput.m_arlOrder.Count; i++)
                {
                    int intStatus = (m_frmInput.m_arlOrder[i] as clsBIHOrder).m_intStatus;
                    int intType = (m_frmInput.m_arlOrder[i] as clsBIHOrder).m_intExecuteType;
                    m_mthSetGridRowColor(intType, intStatus, i);
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 验证连续性医嘱
        /// 业务说明: 连续性医嘱其剂量/用量/领量单位必须都是“小时”!
        /// </summary>
        /// <param name="p_strFreqID"></param>
        /// <returns></returns>
        public bool PassConOrder(string p_strFreqID)
        {
            bool blnRes = true;
            if (m_strConfreqID == "") m_strConfreqID = new clsDcl_ExecuteOrder().m_strGetConfreqID();
            if (m_strConfreqID == p_strFreqID.Trim())
            {
                if (blnRes && m_frmInput.m_ctlOrderDetail.m_txtDosageUnit.Text.Trim() != "小时")
                {
                    MessageBox.Show("连续性医嘱剂量、用量、领量单位必须为“小时”!", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnRes = false;
                }
                if (blnRes && m_frmInput.m_ctlOrderDetail.m_txtUseUnit.Text.Trim() != "小时")
                {
                    MessageBox.Show("连续性医嘱剂量、用量、领量单位必须为“小时”!", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnRes = false;
                }
                if (blnRes && m_frmInput.m_ctlOrderDetail.m_txtGetUnit.Text.Trim() != "小时")
                {
                    MessageBox.Show("连续性医嘱剂量、用量、领量单位必须为“小时”!", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnRes = false;
                }
            }
            return blnRes;
        }
        /// <summary>
        /// 时间输入转换
        /// </summary>
        /// <param name="dtValue"></param>
        /// <returns></returns>
        public string DateTimeToString(DateTime dtValue)
        {
            //if(dtValue.Date==clsBIHOrder.m_dtNullDate.Date)
            if (dtValue.Date == DateTime.MinValue)
                return "";
            else
                return dtValue.ToString("yy-MM-dd HH:mm");
        }
        /// <summary>
        /// 刷新列表的医嘱
        /// </summary>
        /// <param name="intRow"></param>
        public void m_mthRefreshGrid(int intRow)
        {
            //if((intRow>=0) && (intRow<m_frmInput.m_arlOrder.Count) && (intRow<m_frmInput.m_dtgOrder.RowCount))
            //{
            //    System.Data.DataRow objRow=new com.digitalwave.controls.datagrid.clsDataGridProxy(m_frmInput.m_dtgOrder).m_objDataTable.Rows[intRow];
            //    clsBIHOrder objOrder=(m_frmInput.m_arlOrder[intRow] as clsBIHOrder);

            //    objRow=m_objGetDataRow(intRow+1,objOrder,objRow);

            //}
        }

        /// <summary>
        /// 获取当前是否存在医嘱
        /// </summary>
        /// <returns></returns>
        public bool m_blnExistCurrentOrder()
        {
            //if((m_frmInput.m_objCurrentOrder!=null) && (m_frmInput.m_intCurrentRow>=0) && (m_frmInput.m_intCurrentRow<m_frmInput.m_arlOrder.Count))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            if (this.m_frmInput.m_dtvOrder.SelectedRows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 提示对话框
        /// </summary>
        /// <param name="strMsg">提示信息内容串</param>
        private void m_mthShowMessage(string strMsg)
        {
            m_frmInput.m_mthShowMessage(strMsg);
        }

        /// <summary>
        /// 是否存在子医嘱
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <returns></returns>
        private bool IsHaveSonOrder(string p_strOrderID)
        {
            clsBIHOrder[] objResultArr;
            clsBIHOrderService m_objManage = new clsBIHOrderService();
            long lngRes = m_objManage.m_lngGetOrderByParentID(p_strOrderID, out objResultArr );
            if (lngRes <= 0 || objResultArr == null || objResultArr.Length <= 0) return false;
            return true;
        }

        //Add By jli in 2005-03-14
        /// <summary>
        /// 获取同方号的医嘱数组
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_SameOrdersArr">返回的同方号的医嘱数组</param>
        /// <returns></returns>
        public long GetSameOrders(string p_strOrderID, out clsBIHOrder[] p_SameOrdersArr)
        {
            p_SameOrdersArr = new clsBIHOrder[0];
            return 0;
        }

        //Add End

        /// <summary>
        /// 方号验证
        /// 业务说明：同方号则，用法和频率必须相同；[只针对没有提交的新建、退回的医嘱而言]
        /// </summary>
        /// <param name="intRecipeNO">医嘱记录Vo</param>
        /// <returns></returns>
        private bool PassSameRecipeNO(clsBIHOrder p_objBIHOrder)
        {
            if (p_objBIHOrder == null) return true;
            clsBIHOrder[] objBIHOrderArr = null;
            int[] intArr = { 0 };
            long lngRes = m_objService.m_lngGetOrderByPatient(p_objBIHOrder.m_strRegisterID, p_objBIHOrder.m_strPatientID, intArr, false, 0, false, out objBIHOrderArr );
            if (lngRes > 0 && objBIHOrderArr != null)
            {
                for (int i = 0; i < objBIHOrderArr.Length; i++)
                {
                    if (objBIHOrderArr[i].m_strOrderID != p_objBIHOrder.m_strOrderID && (objBIHOrderArr[i].m_intStatus == 0 || objBIHOrderArr[i].m_intStatus == 7) && objBIHOrderArr[i].m_intRecipenNo == p_objBIHOrder.m_intRecipenNo)
                    {
                        if (objBIHOrderArr[i].m_strDosetypeID != p_objBIHOrder.m_strDosetypeID || objBIHOrderArr[i].m_strExecFreqID != p_objBIHOrder.m_strExecFreqID)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 重置Button
        /// </summary>
        private void ResetButtonToEnable()
        {
            /*------------------------------------------------------------------------>
            m_frmInput.m_cmdDelete.Enabled =false;
            m_frmInput.m_cmdSave.Enabled =false;
            //m_frmInput.m_cmdStop.Enabled =false;
            //Add by jli in 2005-03-24
            //			m_frmInput.m_ctlOrderDetail.m_txbFinishTime.Enabled=false;
            //			m_frmInput.m_ctlOrderDetail.m_txbFinishTime.ReadOnly=true;
            //			m_frmInput.m_ctlOrderDetail.m_txbFinishTime.Text="";
            //			m_frmInput.m_ctlOrderDetail.m_txbFinishTime.BackColor=SystemColors.Control;
            //			m_frmInput.m_cmdStop.Text=@"停止(F4)";
            //Add End
            //m_frmInput.m_cmdRetract.Enabled =false;
            m_frmInput.m_cmdBlankOut.Enabled =false;
            m_frmInput.m_cmdSub.Enabled=false;
            ---------------------------------------------------------------------------------*/
            m_frmInput.m_cmdDelete.Enabled = true;
            m_frmInput.m_cmdSave.Enabled = true;
            m_frmInput.m_cmdBlankOut.Enabled = true;
            m_frmInput.m_cmdSub.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtSample.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtCheck.Enabled = true;
        }
        /// <summary>
        /// 设置Button
        /// </summary>
        public void SetButtonToEnable()
        {
            ResetButtonToEnable();
            if (m_frmInput.m_objCurrentOrderValue == null) return;
            //执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
            //初始化医嘱输入界面控件
            //ResetTheDetailControl();
            /*<==========================*/
            //Add by jli in 2005-03-21
            //if(m_frmInput.m_objCurrentOrderValue.m_strParentID.Trim()!="")
            //{
            //    if(m_frmInput.m_objCurrentOrderValue.m_intStatus==0 || m_frmInput.m_objCurrentOrderValue.m_intStatus==7)
            //    {
            //        m_frmInput.m_ctlOrderDetail.m_txtOrderName.Enabled=true;
            //        m_frmInput.m_ctlOrderDetail.m_txtOrderName.BackColor=Color.White;
            //    }
            //    else
            //    {
            //        m_frmInput.m_ctlOrderDetail.m_txtOrderName.Enabled=false;
            //        m_frmInput.m_ctlOrderDetail.m_txtOrderName.BackColor=SystemColors.Control;
            //    }
            //    m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.Enabled=false;
            //    m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.BackColor=SystemColors.Control;
            //    m_frmInput.m_ctlOrderDetail.m_txtDosageType.Enabled=false;
            //    m_frmInput.m_ctlOrderDetail.m_txtDosageType.BackColor=SystemColors.Control;
            //    m_frmInput.m_cmdSub.Enabled=false;
            //}
            //else if(m_frmInput.m_objCurrentOrderValue.m_intStatus==0 || m_frmInput.m_objCurrentOrderValue.m_intStatus==7)
            //{
            //    m_frmInput.m_cmdSub.Enabled=true;
            //    m_frmInput.m_ctlOrderDetail.m_txtOrderName.Enabled=true;
            //    m_frmInput.m_ctlOrderDetail.m_txtOrderName.BackColor=Color.White;
            //    m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.Enabled=true;
            //    m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.BackColor=Color.White;
            //    m_frmInput.m_ctlOrderDetail.m_txtDosageType.Enabled=true;
            //    m_frmInput.m_ctlOrderDetail.m_txtDosageType.BackColor=Color.White;
            //}
            //else if(m_frmInput.m_objCurrentOrderValue.m_intStatus==1
            //    || m_frmInput.m_objCurrentOrderValue.m_intStatus==2
            //    || m_frmInput.m_objCurrentOrderValue.m_intStatus==5)
            //{
            //    m_frmInput.m_ctlOrderDetail.m_cboExecuteType.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtRecipeNo.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtOrderName.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtOrderName2.Enabled = false;
            //    //m_txtOrderName2
            //    m_frmInput.m_ctlOrderDetail.m_txtDosage.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtDosageType.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtGet.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtDays.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtATTACHTIMES_INT.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtDoctorList.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_cboRateType.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtEntrust.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_dtStartTime2.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_dtFinishTime2.Enabled = false;
            //}
            //else
            //{
            //    m_frmInput.m_ctlOrderDetail.m_cboExecuteType.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtRecipeNo.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtOrderName.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtOrderName2.Enabled = false;
            //    //m_txtOrderName2
            //    m_frmInput.m_ctlOrderDetail.m_txtDosage.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtDosageType.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtGet.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtDays.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtATTACHTIMES_INT.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtDoctorList.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_cboRateType.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_txtEntrust.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_dtStartTime2.Enabled = false;
            //    m_frmInput.m_ctlOrderDetail.m_dtFinishTime2.Enabled = false;
            //}
            //Add End  
            m_frmInput.m_cmdSub.Enabled = false;//子医嘱(F3)
            m_frmInput.m_cmdDelete.Enabled = false;//删除(Del)
            m_frmInput.m_cmdBlankOut.Enabled = false;//作废(F5)
            m_frmInput.m_cmdSave.Enabled = false;//保存(F4)
            //子医嘱按钮状态
            //1、子医嘱可以在“新建”状态下录入；2、当“退回”的医嘱是子医嘱时不能再增加子医嘱，其它可增加子医嘱。
            if (m_frmInput.m_objCurrentOrderValue.m_intStatus == 0)
            {
                m_frmInput.m_cmdSub.Enabled = true;//子医嘱(F3)
            }
            else if (m_frmInput.m_objCurrentOrderValue.m_intStatus == 7)
            {
                m_frmInput.m_cmdSub.Enabled = true;//子医嘱(F3)
                if (m_frmInput.m_objCurrentOrderValue.m_strParentID != null)
                {
                    if (!m_frmInput.m_objCurrentOrderValue.m_strParentID.ToString().Trim().Equals(""))
                    {
                        m_frmInput.m_cmdSub.Enabled = false;//子医嘱(F3)
                    }
                }

            }


            switch (m_frmInput.m_objCurrentOrderValue.m_intStatus)
            {
                case -1:

                    m_frmInput.m_cmdDelete.Enabled = false;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = false;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = false;//保存(F4)

                    break;
                case 0:

                    m_frmInput.m_cmdDelete.Enabled = true;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = true;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = true;//保存(F4)
                    break;
                case 1:

                    m_frmInput.m_cmdDelete.Enabled = false;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = true;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = true;//保存(F4)
                    break;
                case 2://临嘱不用停
                    if (m_frmInput.m_objCurrentOrderValue.m_intExecuteType == 1)
                    {
                        m_frmInput.m_cmdStop.Enabled = true;
                    }

                    m_frmInput.m_cmdDelete.Enabled = false;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = false;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = false;//保存(F4)
                    break;
                case 3:

                    m_frmInput.m_cmdDelete.Enabled = false;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = false;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = false;//保存(F4)
                    break;
                case 4:

                    m_frmInput.m_cmdDelete.Enabled = false;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = false;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = false;//保存(F4)
                    break;
                case 5:

                    m_frmInput.m_cmdDelete.Enabled = false;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = false;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = true;//保存(F4)
                    m_frmInput.m_cmdBlankOut.Enabled = true;
                    break;
                case 6:

                    m_frmInput.m_cmdDelete.Enabled = false;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = false;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = false;//保存(F4)
                    break;
                case 7:
                    //m_frmInput.m_cmdSub.Enabled = false;//子医嘱(F3)
                    m_frmInput.m_cmdDelete.Enabled = true;//删除(Del)
                    m_frmInput.m_cmdBlankOut.Enabled = true;//作废(F5)
                    m_frmInput.m_cmdSave.Enabled = true;//保存(F4)
                    break;
                default:

                    break;
            }

            //作废开关
            if (m_frmInput.m_blBlankOutControl == false)
            {
                m_frmInput.m_cmdBlankOut.Enabled = false;
            }

        }
        /// <summary>
        /// 初始化医嘱输入界面控件
        /// </summary>
        public void ResetTheDetailControl()
        {
            //初始化界面控件
            m_frmInput.m_ctlOrderDetail.m_cboExecuteType.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtRecipeNo.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtOrderName.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtOrderName2.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtDosage.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtDosageType.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtExecuteFreq.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtGet.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtDays.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtATTACHTIMES_INT.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtDoctorList.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_cboRateType.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_txtEntrust.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_dtStartTime2.Enabled = true;
            m_frmInput.m_ctlOrderDetail.m_dtFinishTime2.Enabled = true;
        }

        /// <summary>
        /// 设置医嘱编辑状态信息	{0=不显示；1=新增；2=编辑；3=新增子医嘱　；}
        /// </summary>
        /// <param name="p_intState">编辑状态值{0=不显示；1=新增；2=编辑；3=新增子医嘱；}</param>
        public void m_SetDisplayOrderEditState(int p_intState)
        {
            switch (p_intState)
            {
                case 0://不显示
                    m_frmInput.m_lblEditState.Visible = false;
                    break;
                case 1://新增
                    m_frmInput.m_lblEditState.Visible = true;
                    if (m_frmInput.m_ctlOrderDetail.m_txtFatherOrder.Text.Trim() != "")
                    {
                        m_frmInput.m_lblEditState.Text = "添加子医嘱";
                    }
                    else
                    {
                        m_frmInput.m_lblEditState.Text = "添加医嘱";
                    }
                    break;
                case 2://编辑					
                    m_frmInput.m_lblEditState.Visible = true;
                    if (m_frmInput.m_ctlOrderDetail.m_txtFatherOrder.Text.Trim() != "")
                    {
                        m_frmInput.m_lblEditState.Text = "修改子医嘱";
                    }
                    else
                    {
                        m_frmInput.m_lblEditState.Text = "修改医嘱";
                    }
                    break;
                case 3://只读
                    m_frmInput.m_lblEditState.Visible = true;
                    m_frmInput.m_lblEditState.Text = "新增子医嘱";
                    break;
                default://不显示
                    m_frmInput.m_lblEditState.Visible = false;
                    break;
            }
        }
        #region 设置ToolTip
        #region Label 控件
        //		/// <summary>
        //		/// 设置ToolTip
        //		/// </summary>
        //		/// <param name="p_objItem">医嘱记录对象</param>
        //		public void m_mthSetToolTips(clsBIHOrder p_objItem)
        //		{
        //			if(p_objItem==null) return;
        //			string strToolTip =strGetToolTipText(p_objItem);
        //			m_frmInput.m_lblToolTip.Text =strToolTip;
        //			m_frmInput.m_lblToolTip.Visible =true;
        //			//m_frmInput.toolTip1.SetToolTip(m_frmInput.m_dtgOrder,strGetToolTipText(p_objItem));
        //			//m_frmInput.toolTip1.Active =true;
        //		}
        //		/// <summary>
        //		/// 获取ToolTip显示的文本
        //		/// </summary>
        //		/// <param name="p_objItem">医嘱记录对象</param>
        //		/// <returns></returns>
        //		public string strGetToolTipText(clsBIHOrder p_objItem)
        //		{
        //			string strResult ="",strRow ="",strTem ="";
        //			clsT_aid_bih_orderdic_charge_VO[] objItemArr;
        //			clsDcl_CommitOrder objTem =new clsDcl_CommitOrder();
        //			long lngRes =objTem.m_lngGetOrderdicChargeByOrderID(p_objItem.m_strOrderID,out objItemArr);
        //			double dblNumber =0;
        //			dblNumber =System.Convert.ToDouble(p_objItem.m_dmlGet);
        //			if(lngRes>0 && objItemArr!=null && objItemArr.Length>0)
        //			{
        //				for(int i=0;i<objItemArr.Length;i++)
        //				{					
        //					strTem ="项目名称：" + objItemArr[i].m_strItemName;
        //					strRow =strTem;//.PadRight(50,' ');
        //					strTem ="\r\n    主收费项目：" + objItemArr[i].m_strIsChiefItem;
        //					strRow +=strTem;
        //					double dblNum =0;//数量
        //					if(objItemArr[i].m_objChargeItem.m_strITEMID_CHR.Trim()==objItemArr[i].m_strChiefItemID.Trim())//是否主收费项目
        //					{
        //						dblNum =dblNumber;						
        //					}
        //					else
        //					{
        //						dblNum = System.Convert.ToDouble(m_objInputOrder.m_dmlGetChargeNotMainItem(p_objItem.m_strExecFreqID,objItemArr[i]));
        //					}
        //					strTem ="\r\n    数量：" + dblNum.ToString();
        //					strRow +=strTem;//.PadRight(15,' ');
        //					strTem ="\r\n    单价：" + objItemArr[i].m_objChargeItem.m_dblMinPrice.ToString("0.0000");
        //					strRow +=strTem;//.PadRight(15,' ');
        //					strTem ="\r\n    总金额：" + (objItemArr[i].m_objChargeItem.m_dblMinPrice * dblNum).ToString("0.00");
        //					strRow +=strTem;
        //					strResult +=strRow +"\r\n";
        //					strResult +="\r\n";
        //				}
        //			}
        //			return strResult;
        //		}
        #endregion
        #region ListViw 控件
        /// <summary>
        /// 存储费用信息	[缓存作用] {医嘱ID[关键字],费用对象(ArrayList)}
        /// </summary>
        public System.Collections.Hashtable m_htbToolTip = new Hashtable();
        /// <summary>
        /// 绑定ListView的信息ToolTip
        /// </summary>
        /// <param name="p_objItem">医嘱记录对象</param>
        /// <param name="p_lsvToolTip">ListView 控件</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务说明：
        ///		1、自备等不收取病人费用的医嘱，在医生或护士处查看收费明细时，都不应该显示出来；
        /// </remarks>
        public void m_DisPlayToolTipListView(clsBIHOrder p_objItem, System.Windows.Forms.ListView p_lsvToolTip)
        {
            p_lsvToolTip.Items.Clear();
            if (p_objItem == null || p_objItem.m_strOrderID == null || p_objItem.m_strOrderID.Trim() == "") return;
            if ((p_objItem.m_intExecuteType == 2 && p_objItem.m_intIsRepare >= 3 && p_objItem.m_intIsRepare <= 4))
            {
                if (m_htbToolTip.ContainsKey(p_objItem.m_strOrderID.Trim()))
                {
                    m_htbToolTip.Remove(p_objItem.m_strOrderID.Trim());
                }
                p_lsvToolTip.Visible = true;
                return;
            }
            else
            {
                if (!m_htbToolTip.ContainsKey(p_objItem.m_strOrderID.Trim()))
                {
                    FillToolTipHashtable(p_objItem);
                }
            }
            if (m_htbToolTip.ContainsKey(p_objItem.m_strOrderID.Trim()))
            {
                ArrayList alItem = new ArrayList();
                alItem = (m_htbToolTip[p_objItem.m_strOrderID.Trim()] as ArrayList);
                if (alItem != null && alItem.Count > 0)
                {
                    clsChargeForDisplay[] objItemArr = (clsChargeForDisplay[])(alItem.ToArray(typeof(clsChargeForDisplay)));
                    //显示ListView
                    m_objInputOrder.DisplayCharge(objItemArr, p_lsvToolTip);
                    //加一行统计金额
                    //合计金额
                    double m_dblSum = 0;
                    for (int i = 0; i < objItemArr.Length; i++)
                    {
                        if (!double.IsInfinity(objItemArr[i].m_dblMoney))
                            m_dblSum += objItemArr[i].m_dblMoney;
                    }

                    if (objItemArr.Length > 0)
                    {

                        ListViewItem item1 = new ListViewItem("");
                        item1.SubItems.Add("");
                        item1.SubItems.Add("");
                        item1.SubItems.Add("");
                        item1.SubItems.Add("合计:");
                        item1.SubItems.Add(m_dblSum.ToString("0.00"));
                        item1.ForeColor = Color.Red;
                        p_lsvToolTip.Items.Add(item1);
                    }
                    /*<===============*/
                }
            }

            /* 医保状态分类显示（用颜色代表）*/

            //for(int i1=0;i1<p_lsvToolTip.Items.Count;i1++)
            //{
            //    if(((clsChargeForDisplay)p_lsvToolTip.Items[i1].Tag).m_strYBClass.ToString().Trim().Equals(""))//非医保
            //    {
            //        p_lsvToolTip.Items[i1].BackColor=Color.White;	
            //    }
            //    else if(((clsChargeForDisplay)p_lsvToolTip.Items[i1].Tag).m_strYBClass.ToString().Trim().Equals("甲类"))
            //    {
            //        p_lsvToolTip.Items[i1].BackColor=Color.SkyBlue;	
            //    }
            //    else if(((clsChargeForDisplay)p_lsvToolTip.Items[i1].Tag).m_strYBClass.ToString().Trim().Equals("乙类"))
            //    {
            //        p_lsvToolTip.Items[i1].BackColor=Color.Yellow;
            //    }
            //    else if(((clsChargeForDisplay)p_lsvToolTip.Items[i1].Tag).m_strYBClass.ToString().Trim().Equals("其他"))
            //    {
            //        p_lsvToolTip.Items[i1].BackColor=Color.Green;
            //    }

            //}
            /* <<======================================= */
            //p_lsvToolTip.Visible =true;
        }
        /// <summary>
        /// 给哈希表填值 ToopTip
        /// </summary>
        /// <param name="p_objItem">医嘱记录对象</param>
        /// <returns></returns>
        private void FillToolTipHashtable(clsBIHOrder p_objItem)
        {


            long lngRes = 0;
            if (p_objItem == null || p_objItem.m_strOrderID == null || p_objItem.m_strOrderID.Trim() == "") return;
            //获取医嘱ID
            string strOrderID = p_objItem.m_strOrderID;
            ////主收费的领量
            //double dblNumber =System.Convert.ToDouble(p_objItem.m_dmlGet);
            //clsT_aid_bih_ordercate_VO objOrdercate;
            //lngRes =m_objInputOrder.m_lngGetAidOrderCateByID(p_objItem.m_strOrderDicCateID,out objOrdercate);
            //if(lngRes>0 && objOrdercate!=null && objOrdercate.m_intDOSAGEVIEWTYPE==2) dblNumber =1;
            ////执行频率ID
            //string strFreqID =p_objItem.m_strExecFreqID;
            ////用法ID
            //string strUsageID =p_objItem.m_strDosetypeID;
            ////是否子级医嘱	{0=非子级医嘱;1=子级医嘱}
            //int intIsSonOrder =0;
            //if(p_objItem.m_strParentID!=null && p_objItem.m_strParentID.Trim()!="")
            //    intIsSonOrder =1;

            clsChargeForDisplay[] objItemArr;
            //lngRes =m_objInputOrder.m_lngGetBIHCharge(strOrderID,intIsSonOrder,dblNumber,strFreqID,strUsageID,out objItemArr);
            DataTable m_dtChargeList;
            m_objInputOrder.m_lngGetBIHChargeFromDEPT(strOrderID, out m_dtChargeList);
            m_mthGetChargeListFromDateTable(m_dtChargeList, out objItemArr);
            if (objItemArr != null && objItemArr.Length > 0)
            {
                ArrayList alItem = new ArrayList();
                for (int i1 = 0; i1 < objItemArr.Length; i1++)
                {
                    alItem.Add(objItemArr[i1]);
                }
                if (alItem != null && alItem.Count > 0 && (!m_htbToolTip.ContainsKey(strOrderID)))
                {
                    m_htbToolTip.Add(strOrderID, alItem);
                }
            }
        }

        /// <summary>
        /// 费用表转换为费用明细对象
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="m_arrObjItem"></param>
        public void m_mthGetChargeListFromDateTable(DataTable m_dtChargeList, out clsChargeForDisplay[] m_arrObjItem)
        {

            m_arrObjItem = new clsChargeForDisplay[m_dtChargeList.Rows.Count];
            for (int i = 0; i < m_dtChargeList.Rows.Count; i++)
            {
                DataRow objRow = m_dtChargeList.Rows[i];

                m_arrObjItem[i] = new clsChargeForDisplay();
                m_arrObjItem[i].m_strChargeID = clsConverter.ToString(objRow["CHARGEITEMID_CHR"]).Trim();
                m_arrObjItem[i].m_strITEMCODE_VCHR = clsConverter.ToString(objRow["ITEMCODE_VCHR"]).Trim();
                //收费项目名称
                m_arrObjItem[i].m_strName = clsConverter.ToString(objRow["CHARGEITEMNAME_CHR"]).Trim();
                double dblNum = 0;
                //if (objMedicineItemArr[i1].m_objChargeItem.m_strITEMID_CHR.Trim() == objMedicineItemArr[i1].m_strChiefItemID.Trim())//是否主收费项目
                //{
                //    dblNum = p_dblDraw;
                //    //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                //    m_arrObjItem[i].m_intType = 2;
                //}
                //else
                //{
                //    dblNum = System.Convert.ToDouble(m_dmlGetChargeNotMainItem(objRecipeFreq, objMedicineItemArr[i1]));
                //    //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                //    m_arrObjItem[i].m_intType = 1;
                //}
                //单价
                if (!objRow["UNITPRICE_DEC"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_dblPrice = double.Parse(clsConverter.ToString(objRow["UNITPRICE_DEC"]).Trim());
                }
                if (!objRow["AMOUNT_DEC"].ToString().Trim().Equals(""))
                {
                    dblNum = double.Parse(clsConverter.ToString(objRow["AMOUNT_DEC"]).Trim());
                }
                /*<---------------------------------*/
                //领量
                m_arrObjItem[i].m_dblDrawAmount = dblNum;

                //合计金额
                m_arrObjItem[i].m_dblMoney = m_arrObjItem[i].m_dblPrice * dblNum;
                //续用类型 {-1=非用法收费（药品收费等）;0=不续用;1=全部续用;2-长嘱续用}
                if (!objRow["CONTINUEUSETYPE_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intCONTINUEUSETYPE_INT = int.Parse(objRow["CONTINUEUSETYPE_INT"].ToString().Trim());
                }

                //是否连续性医嘱	{0=否；1=是} 连续性医嘱不提示药品费用信息；
                // m_arrObjItem[i].m_intIsContinueOrder = (blnIsConOrder) ? (1) : (0);
                //是否缺药
                // m_arrObjItem[i].m_strNoqtyFLag = objMedicineItemArr[i1].m_strNoqtyFLag;
                // 加上科室名称
                m_arrObjItem[i].m_strClacarea_chr = clsConverter.ToString(objRow["CLACAREA_CHR"]).Trim();
                m_arrObjItem[i].m_strClacareaName_chr = clsConverter.ToString(objRow["deptname_vchr"]).Trim();
                //暂存住院诊疗项目收费项目执行客户表的流水号
                m_arrObjItem[i].m_strSeq_int = clsConverter.ToString(objRow["SEQ_INT"]).Trim(); ;
                m_arrObjItem[i].m_strYBClass = clsConverter.ToString(objRow["INSURACEDESC_VCHR"]).Trim();
                m_arrObjItem[i].m_strUNIT_VCHR = clsConverter.ToString(objRow["UNIT_VCHR"]).Trim();
                //收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
                if (!objRow["FLAG_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intType = clsConverter.ToInt(objRow["FLAG_INT"].ToString().Trim());
                // 住院诊疗项目收费项目执行客户表VO
                //objItem.m_objORDERCHARGEDEPT_VO = objMedicineItemArr[i1].m_objORDERCHARGEDEPT_VO;
            }
        }

        /// <summary>
        /// 清空缓存数据
        /// </summary>
        public void m_ClearBuffer()
        {
            m_htbToolTip.Clear();
        }
        #endregion


        #endregion
        #region m_strGetStatusMessage
        /// <summary>
        /// 获取医嘱的执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}
        /// </summary>
        /// <param name="intStatus">执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;7-退回;}</param>
        /// <returns>执行状态描述</returns>
        public string m_strGetStatusMessage(int intStatus)
        {
            string strMessage = "";
            switch (intStatus)
            {
                case 0:
                    strMessage = "新建";
                    break;
                case 1:
                    strMessage = "已提交";
                    break;
                case 2:
                    strMessage = "已执行";
                    break;
                case 3:
                    strMessage = "已停止";
                    break;
                case 4:
                    strMessage = "已重整";
                    break;
                case 5:
                    strMessage = "已审核提交";
                    break;
                case 6:
                    strMessage = "已审核停止";
                    break;
                case -1:
                    strMessage = "已作废";
                    break;
                default:
                    strMessage = "未知";
                    break;
            }
            return strMessage;

        }
        #endregion
        #region m_strGetOrderMessage
        /// <summary>
        /// 获取医嘱的状态信息	[格式：“长期 已提交”]
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns>描述信息</returns>
        public string m_strGetOrderMessage(clsBIHOrder objOrder)
        {
            string strType = "";
            if (objOrder == null)
                strType = "";
            else if (objOrder.m_intExecuteType == 1)
                strType = "长期";
            else if (objOrder.m_intExecuteType == 2)
                strType = "临时";
            else
                strType = "";

            string strStatus = "";
            if (objOrder == null)
            {
                strStatus = "";
            }
            else
            {
                strStatus = objOrder.m_strStatusName; //m_strGetStatusMessage(objOrder.m_intStatus);
            }
            string strBackReason = "";
            if (objOrder != null && objOrder.m_intStatus == 7)
            {
                strBackReason = "原因:" + ((objOrder.m_strBACKREASON == null) ? ("") : (objOrder.m_strBACKREASON.Trim()));
            }
            return strType + "  " + strStatus + " " + strBackReason;
        }
        #endregion
        #region m_objGetDataRow
        /// <summary>
        /// 从Order创建DataRow,intNO只是指定编号
        /// </summary>
        public DataRow m_objGetDataRow(int intNo, clsBIHOrder objOrder, DataRow objRow)
        {
            if (objRow == null)
            {
                //objRow =m_frmInput.m_dtgOrder.NewRow();
            }

            objRow["NO"] = intNo;
            objRow["RecipeNo"] = objOrder.m_intRecipenNo;
            objRow["Name"] = objOrder.m_strName;
            //价格
            //objRow["Price"] =objOrder.m_dmlPrice.ToString("0.0000");
            if (objOrder.m_intExecuteType == 1)
            {
                objRow["ExecuteType"] = "长";
            }
            else
            {
                if (objOrder.m_intExecuteType == 2)
                    objRow["ExecuteType"] = "临";
                else
                    objRow["ExecuteType"] = "";
            }
            if (objOrder.m_dmlDosage > 0)
            {
                objRow["Dosage"] = objOrder.m_dmlDosage.ToString() + " " + objOrder.m_strDosageUnit;
            }
            else
            {
                objRow["Dosage"] = "";
            }
            if (objOrder.m_dmlGet > 0)
            {
                objRow["Get"] = objOrder.m_dmlGet.ToString() + " " + objOrder.m_strGetunit;
            }
            else
            {
                objRow["Get"] = "";
            }
            //合计
            //objRow["TotalMoney"] =(double.Parse(objOrder.m_dmlGet.ToString()) * double.Parse(objOrder.m_dmlPrice.ToString())).ToString("0.00");
            objRow["Freq"] = objOrder.m_strExecFreqName;
            objRow["UseType"] = objOrder.m_strDosetypeName;
            if (objOrder.m_intISNEEDFEEL == 1)
                objRow["ISNEEDFEEL"] = "√";
            else
                objRow["ISNEEDFEEL"] = "";//×
            objRow["StartDate"] = DateTimeToString(objOrder.m_dtStartDate);
            objRow["Stoper"] = objOrder.m_strStoper;
            objRow["StopDate"] = DateTimeToString(objOrder.m_dtStopdate);
            objRow["ParentName"] = objOrder.m_strParentName;
            return objRow;
        }
        #endregion
        #endregion
        #region 打印医嘱
        /// <summary>
        /// 打印临时医嘱
        /// </summary>
        public void m_PrintOrder()
        {
            clsBIHPatientInfo objPatient = m_frmInput.m_ctlPatient.m_objPatient;
            if (objPatient == null)
            {
                m_mthShowMessage("请先指定病人!");
                m_frmInput.m_ctlPatient.Focus();
                return;
            }
            string strRegisterID = m_frmInput.m_ctlPatient.m_objPatient.m_strRegisterID;
            int intCount = 0, m_intBigRecipeNo = 0, intBackCout = 0;
            clsBIHOrder[] arrOrder = null;
            long ret = this.m_objService.m_lngGetOrderByPatientAndState2(objPatient.m_strRegisterID, this.m_frmInput.LoginInfo.m_strEmpID, false, 0, out intCount, out m_intBigRecipeNo, out intBackCout, out m_intOutHisCout, out arrOrder);

            if (strRegisterID.Trim() == "") return;
            DataTable dtPatient = new DataTable();
            dtPatient.Columns.Add("PATIENTNAME");
            dtPatient.Columns.Add("PATIENTSEX");
            dtPatient.Columns.Add("PATIENTAGE");
            dtPatient.Columns.Add("CURRENTAREANAME");
            dtPatient.Columns.Add("CURRENTBEDNO");
            dtPatient.Columns.Add("INPATIENTID");
            DataRow row = dtPatient.NewRow();
            TimeSpan ts = DateTime.Now - m_frmInput.m_ctlPatient.m_objPatient.m_dtBorn;
            row["PATIENTNAME"] = m_frmInput.m_ctlPatient.m_objPatient.m_strPatientName;
            row["PATIENTSEX"] = m_frmInput.m_ctlPatient.m_objPatient.m_strSex;
            if (ts.Days < 30)
            {
                row["PATIENTAGE"] = "新";
            }
            else
            {
                row["PATIENTAGE"] = m_frmInput.m_ctlPatient.m_objPatient.m_strAge;
            }
            row["CURRENTAREANAME"] = m_frmInput.m_ctlPatient.m_objPatient.m_strAreaName;
            row["CURRENTBEDNO"] = m_frmInput.m_ctlPatient.m_objPatient.m_strBedName;
            row["INPATIENTID"] = m_frmInput.m_ctlPatient.m_objPatient.m_strInHospitalNo;
            dtPatient.Rows.Add(row);
            //显示打印设置页面
            frmPrintOrder objPrintOrder = new frmPrintOrder(strRegisterID, dtPatient, this.m_frmInput.m_htOrderCate, arrOrder, this.m_frmInput.m_objSpecateVo);
            objPrintOrder.m_strClass = m_frmInput.m_strView;
            objPrintOrder.ShowDialog();
        }
        #endregion
        #region 加载系统设置
        internal bool IsTabu = false;
        public void m_mthLoadSysConfig()
        {
            DataTable dt;
            long ret = this.m_objService.m_mthGetSysConfig(out dt, "");
            if (dt.Rows.Count > 0)
            {
                IsTabu = dt.Rows[0]["ISCHECKMED"].ToString().Trim() == "1";
            }
        }
        #endregion

        #region 发送检验申请单
        /// <summary>
        /// 获得检验的收费相关参数
        /// </summary>
        /// <param name="p_objBIHOrder"></param>
        /// <param name="p_dtResultArr"></param>
        /// <returns></returns>
        public bool m_lngAddNewCheckByOrderID(clsBIHOrder p_objBIHOrder, out DataTable p_dtResultArr)
        {
            p_dtResultArr = new DataTable();
            long ret = m_objService.m_lngAddNewCheckByOrderID(p_objBIHOrder, out p_dtResultArr);
            if (ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 给检验申请单参数填值
        /// </summary>
        private bool m_mthSendTestApplyBill(DataTable p_dtResultArr, string strTypeID, clsBIHOrder p_objBIHOrder, out clsLisApplMainVO objLMVO, out clsTestApplyItme_VO[] itemArr_VO)
        {

            long ret = m_objService.m_mthSendTestApplyBill(p_dtResultArr, strTypeID, p_objBIHOrder, out objLMVO, out itemArr_VO);
            if (ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据当前诊疗项目ID判断是否是可自动发送的检验项目
        /// </summary>
        /// <param name="m_strOrderDicID"></param>
        /// <param name="m_blHave"></param>
        /// <returns></returns>
        public long m_mthGegCheckByID(string m_strOrderDicID, out bool m_blHave)
        {
            long ret = m_objService.m_mthGegCheckByID(m_strOrderDicID, out m_blHave);
            return ret;
        }
        #endregion

        #region GetDrugInfo
        /// <summary>
        /// GetDrugInfo
        /// </summary>
        internal void GetDrugInfo(string orderDicId)
        {
            if (string.IsNullOrEmpty(DrugServiceUrl))
            {
                DrugServiceUrl = com.digitalwave.iCare.gui.HIS.clsPublic.m_strGetSysparm("0080");
                IsUseMedItf = (Convert.ToDecimal(com.digitalwave.iCare.gui.HIS.clsPublic.m_strGetSysparm("0082")) == 1 ? true : false);
            }
            if (IsUseMedItf == false) return;
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            Dictionary<string, clsMedicine_VO> dicMed = svc.GetMedInfoByOrderDicId(orderDicId);
            svc = null;
            using (Hisitf.RationalDrugUseItf itf = new Hisitf.RationalDrugUseItf())
            {
                if (dicMed.ContainsKey(orderDicId))
                {
                    itf.GetMedInfo(DrugServiceUrl, dicMed[orderDicId].m_strMedicineID);
                }
            }
        }
        #endregion

        internal bool m_lngGetBihOrderNameControl()
        {
            long lngRes = 0;
            bool m_blOpen;
            lngRes = m_objInputOrder.m_lngGetBihOrderNameControl(out m_blOpen);
            return m_blOpen;
        }

        internal bool m_lngGetm_cmdBlankOutControl()
        {
            long lngRes = 0;
            bool m_blOpen;
            lngRes = m_objInputOrder.m_lngGetm_cmdBlankOutControl(out m_blOpen);
            return m_blOpen;
        }

        public void m_Loadm_lngGetcboOrderList()
        {
            this.m_frmInput.m_cboOrderList.Items.AddRange(this.m_arrOrderList);
            this.m_frmInput.m_cboOrderList.SelectedIndex = 0;
            this.m_frmInput.seachClass.SelectedIndex = 0;
        }

        /// <summary>
        /// 作废恢复
        /// </summary>
        internal void BihOrderDrawBack(string m_strOrderID)
        {
            m_objService.m_lngBihOrderDrawBack(m_strOrderID);
        }

        /// <summary>
        /// 医嘱录入界面开关
        /// </summary>
        /// <param name="m_intBihNameOpen">功能开关用来控制是否允许修改医嘱诊疗项目名称 1017</param>
        /// <param name="m_intBihBlankOutOpen">功能开关用来控制是否允许修改医嘱作废</param>
        /// <param name="m_intTypePControl">片剂数量计算开关1024</param>
        /// <param name="m_intShowCodexRemarkFrm">医生工作站是否显示药典备注 0 不显示 1 显示 0059</param>
        /// <param name="ShowCodexRemarkFrmTimerinterval">医生工作站药典备注窗口显示时间 0060</param>
        /// <param name="m_intLessMedControl">缺药显示控制开关</param>
        /// <param name="m_intDoctorSign">医生签名控制开关</param>
        /// <param name="m_intZCaoControl">跳过医嘱转抄这个流程，0－不跳过，1－跳过</param>
        /// <param name="m_intCommitControl">提交时是否需要输入工号及密码 1032</param>
        /// <param name="m_intUpControl">医嘱录入权限费用上限开关1003 0-关，1-开</param>
        /// <param name="m_intStopControl">医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037</param>
        /// <param name="m_intDeableMedControl">医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036</param>
        ///<param name="m_intStopTipControl">住院医嘱停医嘱是否需要认证 0-不需要；1-需要 1044</param>
        ///<param name="m_intCanChangeOrder">是否允许其它医生修改非本人开的转抄前的医嘱  0-不可以；1-可以 1045</param>
        ///<param name="m_intSendLisBill"> 提交时是否发送检验申请单 0-不可以；1-可以  1050</param>
        ///<param name="m_intStopTimeSwitth">医生修改停嘱时间的时间限制 0-不限制,>0为限制的时间,如24,即为下嘱后24小时内可以修改  1051</param>
        ///<param name="m_intLisDiscount">4008  0-false不打折 1-true 允许打折</param>
        ///<param name="m_intLisDiscountNum">4006设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能</param>
        ///<param name="m_decLisDiscountMount">4007设置启用打折功能时，检验收费项目的打折比例。80，则打八折</param>
        ///<param name="m_intAutoStopAlert">m_intAutoStopAlert '1053', '住院医嘱录入界面是否自动提示当前病人存在停用或缺药的未停医嘱', '0-否；1-是', 1 </param>
        ///<param name="m_intStartTimeSwitth">医生修改下嘱时间的时间限制 0-不限制,>0为限制的时间,如24,即为下嘱后24小时内可以修改  1054</param>
        internal void m_lngGetBihOrderControls(out int m_intBihNameOpen, out int m_intBihBlankOutOpen, out int m_intTypePControl, out int m_intShowCodexRemarkFrm, out int ShowCodexRemarkFrmTimerinterval, out int m_intLessMedControl, out int m_intDoctorSign, out int m_intZCaoControl, out int m_intCommitControl, out int m_intUpControl, out int m_intStopControl, out int m_intDeableMedControl, out int m_intStopTipControl, out int m_intCanChangeOrder, out int m_intSendLisBill, out int m_intStopTimeSwitth, out int m_intLisDiscount, out int m_intLisDiscountNum, out decimal m_decLisDiscountMount, out int m_intAutoStopAlert, out int m_intStartTimeSwitth, out int m_intParm1068)
        {

            m_intBihNameOpen = -1;
            m_intBihBlankOutOpen = -1;
            m_intTypePControl = -1;
            m_intShowCodexRemarkFrm = -1;
            ShowCodexRemarkFrmTimerinterval = -1;//跳过医嘱转抄这个流程，0－不跳过，1－跳过
            m_intZCaoControl = -1;
            m_intLessMedControl = -1;
            m_intDoctorSign = -1;
            m_intCommitControl = -1;
            m_intUpControl = -1;
            m_intStopControl = -1;
            m_intDeableMedControl = -1;
            m_intStopTipControl = -1;
            m_intCanChangeOrder = -1;
            m_intSendLisBill = -1;
            m_intStopTimeSwitth = -1;
            m_intLisDiscount = -1;
            m_intLisDiscountNum = -1;
            m_decLisDiscountMount = -1;
            m_intAutoStopAlert = -1;
            m_intStartTimeSwitth = -1;
            m_intParm1068 = 0;
            //使用ArrayList
            //ArrayList m_arrControl = new ArrayList();
            //改用List<T>
            System.Collections.Generic.List<string> m_arrControl = new System.Collections.Generic.List<string>();
            m_arrControl.Add("0059");//医生工作站是否显示药典备注 0 不显示 1 显示 0059
            m_arrControl.Add("0060");//医生工作站药典备注窗口显示时间 0060
            m_arrControl.Add("1003");//医嘱录入权限费用上限开关1003 0-关，1-开
            m_arrControl.Add("1017");//功能开关用来控制是否允许修改医嘱诊疗项目名称 1017
            m_arrControl.Add("1023");//功能开关用来控制是否允许修改医嘱作废 1023
            m_arrControl.Add("1024");//片剂数量计算开关1024
            m_arrControl.Add("1025");//缺药显示控制开关
            m_arrControl.Add("1026");//医生签名控制开关
            m_arrControl.Add("1027");//跳过医嘱转抄这个流程，0－不跳过，1－跳过
            m_arrControl.Add("1032");//提交时是否需要输入工号及密码 1032
            m_arrControl.Add("1036");//医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036
            m_arrControl.Add("1037");//医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037
            m_arrControl.Add("1044");//住院医嘱停医嘱是否需要认证 0-不需要；1-需要 1044
            m_arrControl.Add("1045");//是否允许其它医生修改非本人开的转抄前的医嘱  0-不可以；1-可以 1045
            m_arrControl.Add("1050");//提交时是否发送检验申请单 0-不可以；1-可以  1050
            m_arrControl.Add("1051");//医生修改停嘱时间的时间限制 0-不限制,>0为限制的时间,如24,即为下嘱后24小时内可以修改  1051
            m_arrControl.Add("4006");//4006设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能
            m_arrControl.Add("4007");//4007设置启用打折功能时，检验收费项目的打折比例。80，则打八折
            m_arrControl.Add("4008");//检验组合4008  0-false不打折 1-true 允许打折
            m_arrControl.Add("1053");//'1053', '住院医嘱录入界面是否自动提示当前病人存在停用或缺药的未停医嘱', '0-否；1-是', 1
            m_arrControl.Add("1054");//医生修改下嘱时间的时间限制 0-不限制,>0为限制的时间,如24,即为下嘱后24小时内可以修改  1054
            m_arrControl.Add("1068");//病人门诊未结处方费用时控制出院结算与医嘱录入(医嘱录入1、2状态都为提示选择)''0-关闭;1-提示选择，2-卡住'
            DataTable dtbResult = null;
            long lngRes = m_objInputOrder.GetTheHisControl(m_arrControl, out  dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                {
                    switch (dtbResult.Rows[i]["setid_chr"].ToString().TrimEnd())
                    {
                        case "1003":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                            {
                                m_intUpControl = 0;
                            }
                            else
                            {
                                m_intUpControl = 1;
                            }
                            break;
                        case "1017":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                            {
                                m_intBihNameOpen = 0;
                            }
                            else
                            {
                                m_intBihNameOpen = 1;
                            }
                            break;
                        case "1023":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                            {
                                m_intBihBlankOutOpen = 0;
                            }
                            else
                            {
                                m_intBihBlankOutOpen = 1;
                            }
                            break;
                        case "1024":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                            {
                                m_intTypePControl = 0;
                            }
                            else
                            {
                                m_intTypePControl = 1;
                            }
                            break;
                        case "1025":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                            {
                                m_intLessMedControl = 0;
                            }
                            else
                            {
                                m_intLessMedControl = 1;
                            }
                            break;
                        case "1026":
                            if (!dtbResult.Rows[i]["setstatus_int"].ToString().Equals(""))
                            {
                                m_intDoctorSign = int.Parse(dtbResult.Rows[i]["setstatus_int"].ToString());
                            }
                            break;
                        case "0059":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("0"))
                            {
                                m_intShowCodexRemarkFrm = 0;
                            }
                            else
                            {
                                m_intShowCodexRemarkFrm = 1;
                            }
                            break;
                        case "0060":
                            if (!dtbResult.Rows[i]["setstatus_int"].ToString().Equals(""))
                            {
                                ShowCodexRemarkFrmTimerinterval = int.Parse(dtbResult.Rows[i]["setstatus_int"].ToString());
                            }
                            else
                            {
                                ShowCodexRemarkFrmTimerinterval = 0;
                            }
                            break;
                        case "1027":
                            if (!dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intZCaoControl = 1;
                            }
                            else
                            {
                                m_intZCaoControl = 0;
                            }
                            break;
                        case "1032":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intCommitControl = 1;
                            }
                            else
                            {
                                m_intCommitControl = 0;
                            }
                            break;
                        case "1036":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intDeableMedControl = 1;
                            }
                            else
                            {
                                m_intDeableMedControl = 0;
                            }
                            break;
                        case "1037":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intStopControl = 1;
                            }
                            else
                            {
                                m_intStopControl = 0;
                            }
                            break;
                        case "1044":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intStopTipControl = 1;
                            }
                            else
                            {
                                m_intStopTipControl = 0;
                            }
                            break;
                        case "1045":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intCanChangeOrder = 1;
                            }
                            else
                            {
                                m_intCanChangeOrder = 0;
                            }
                            break;
                        case "1050":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intSendLisBill = 1;
                            }
                            else
                            {
                                m_intSendLisBill = 0;
                            }
                            break;
                        case "1051":
                            int.TryParse(dtbResult.Rows[i]["setstatus_int"].ToString(), out m_intStopTimeSwitth);
                            break;
                        case "4006":
                            int.TryParse(dtbResult.Rows[i]["setstatus_int"].ToString().Trim(), out m_intLisDiscountNum);
                            break;
                        case "4007":
                            decimal.TryParse(dtbResult.Rows[i]["setstatus_int"].ToString().Trim(), out m_decLisDiscountMount);
                            break;
                        case "4008":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intLisDiscount = 1;
                            }
                            else
                            {
                                m_intLisDiscount = 0;
                            }
                            break;
                        case "1053":
                            if (dtbResult.Rows[i]["setstatus_int"].ToString().Equals("1"))
                            {
                                m_intAutoStopAlert = 1;
                            }
                            else
                            {
                                m_intAutoStopAlert = 0;
                            }
                            break;
                        case "1054":
                            int.TryParse(dtbResult.Rows[i]["setstatus_int"].ToString(), out m_intStartTimeSwitth);
                            break;
                        case "1068":
                            int.TryParse(dtbResult.Rows[i]["setstatus_int"].ToString(), out m_intParm1068);
                            break;
                    }
                }
            }
        }

        #region 医嘱医生签名

        internal long m_mthCurrentOrderDoctorSign(clsBIHOrder clsBIHOrder, string empid_chr, string lastname_vchr)
        {

            long ret = m_objService.m_lngCurrentOrderDoctorSign(clsBIHOrder.m_strOrderID);
            return ret;
        }

        #endregion

        internal long m_lngGetNotExecuteOrderByRegID(string m_strRegisterID, out int m_intCount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngGetNotExecuteOrderByRegID(objPrincipal, m_strRegisterID, out m_intCount);
            return lngRes;
        }

        internal long m_lngGetNotStopOrderByRegID(string m_strRegisterID, out int m_intCount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngGetNotStopOrderByRegID(objPrincipal, m_strRegisterID, out m_intCount);
            return lngRes;
        }

        internal long m_lngDeleteOrder(string[] p_strDeleteOrderIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngDeleteOrder(p_strDeleteOrderIDArr);
            return lngRes;
        }

        internal long m_lngDeleteOrder(string[] p_strDeleteOrderIDArr, string[] p_strDeleteContinueIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngDeleteOrder(p_strDeleteOrderIDArr, p_strDeleteContinueIDArr);
            return lngRes;
        }


        internal long m_lngBlankOutOrder(string[] p_strBlankOutOrderIDArr, string DELETERID_CHR, string DELETERNAME_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngBlankOutOrder(p_strBlankOutOrderIDArr, DELETERID_CHR, DELETERNAME_VCHR);
            return lngRes;
        }

        internal long m_lngStopOrder(string[] p_strBlankOutOrderIDArr, string strDoctorID, string strDoctorName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngStopOrder(p_strBlankOutOrderIDArr, strDoctorID, strDoctorName);
            return lngRes;
        }

        /// <summary>
        /// 插入术后医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <param name="p_strHandlersID"></param>
        /// <param name="p_strHandlers"></param>
        /// <returns></returns>
        internal long m_lngInsertOPERATIONOrder(clsBIHOrder order, string p_strHandlersID, string p_strHandlers)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngInsertOPERATIONOrder(order, p_strHandlersID, p_strHandlers);
            return lngRes;
        }

        /// <summary>
        /// 插入转科医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        internal long m_lngInsertChangeAreaOrder(clsBIHOrder order, string p_strHandlersID, string p_strHandlers)
        {
            long lngRes = 0;
            string p_strRecordID = "";
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngInsertChangeAreaOrder(order, p_strHandlersID, p_strHandlers);
            return lngRes;
        }

        /// <summary>
        /// 插入出院医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        internal long m_lngInsertOutHisOrder(clsBIHOrder order, string p_strHandlersID, string p_strHandlers, bool m_blAuto)
        {
            long lngRes = 0;
            string p_strRecordID = "";
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngInsertOutHisOrder(order, p_strHandlersID, p_strHandlers, m_blAuto);
            return lngRes;
        }

        internal long m_cmdAddOrderNornal(clsComuseorderdic[] m_arrOrderdic)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngAddOrderNornal(objPrincipal, m_arrOrderdic);
            return lngRes;
        }

        internal long m_lngReSortOrderNO(string m_strRegisterid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngReSortOrderNO(objPrincipal, m_strRegisterid);
            return lngRes;
        }

        /// <summary>
        /// 载入特殊配置表
        /// </summary>
        internal void m_LoadGetSPECORDERCATE()
        {
            long lngRes = 0;
            lngRes = m_objInputOrder.m_lngAddGetSPECORDERCATE(out this.m_frmInput.m_objSpecateVo);
        }

        /// <summary>
        /// 查看是否当前操作人是否有处方权
        /// </summary>
        internal long m_lngAddGetAccessPower(string m_strEmpID, out bool m_blAccess)
        {
            long lngRes = 0;
            lngRes = m_objInputOrder.m_lngAddGetAccessPower(m_strEmpID, out m_blAccess);
            return lngRes;
        }

        internal long m_lngMoneyCountNewOrder(string m_strRegisterID, out decimal m_decMoneySum)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngMoneyCountNewOrder(m_strRegisterID, out m_decMoneySum);
            return lngRes;
        }

        internal long LoadThePARMVALUE(ArrayList PARMCODE_CHR, out DataTable m_dtPARMVALUE_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.LoadThePARMVALUE(PARMCODE_CHR, out  m_dtPARMVALUE_VCHR);
            return lngRes;
        }

        /// <summary>
        /// 医生工作站对药品库存的检查
        /// </summary>
        /// <param name="m_strMedStordID"></param>
        /// <param name="m_strItemID"></param>
        /// <param name="m_dclGetMed"></param>
        /// <param name="blnFlag">是否够库存</param>
        /// <param name="m_strExecDeptID">返回科室ID</param>
        /// <returns></returns>

        internal long m_lngGetMedStoreByDoctorWorkStation(string m_strMedStordID, string m_strItemID, decimal m_dclGetMed,
                                                        out bool blnFlag, out string m_strExecDeptID, out string medCode)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetMedStoreByDoctorWorkStation(m_strMedStordID, m_strItemID, m_dclGetMed, out  blnFlag, out m_strExecDeptID, out medCode);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #region 是否适应症药品
        /// <summary>
        /// 是否适应症药品
        /// </summary>
        /// <param name="strOrderID"></param>
        /// <returns></returns>
        internal bool m_blnShiying(string strOrderID, out string strRemark, out string strItemName)
        {
            bool blnRes = false;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            blnRes = objSvc.m_blnShiying(strOrderID, out strRemark, out strItemName);
            objSvc.Dispose();
            objSvc = null;
            return blnRes;
        }
        #endregion

        #region  单条医嘱适应症
        /// <summary>
        /// 单条医嘱适应症
        /// </summary>
        /// <param name="strOrderID"></param>
        /// <param name="strItemID"></param>
        /// <param name="strShiying"></param>
        /// <returns></returns>
        public long m_lngGetShiying(string strOrderID, string strItemID, out string strShiying)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngGetShiying(strOrderID, strItemID, out strShiying);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
    }
    #endregion

    #region 类-诊疗项目类型clsOrderCate
    /// <summary>
    /// 诊疗项目类型类	用于下拉框
    /// </summary>
    public class clsOrderCate
    {
        public clsT_aid_bih_ordercate_VO m_objOrderCate = new clsT_aid_bih_ordercate_VO();
        public clsOrderCate()
        { }
        public override string ToString()
        {
            if (m_objOrderCate != null && m_objOrderCate.m_strVIEWNAME_VCHR != null)
                return m_objOrderCate.m_strVIEWNAME_VCHR;
            else
                return "";
        }
    }
    #endregion

}
