using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.Utility.Controls;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.BIHOrder.Control
{
    /// <summary>
    /// ctlBIHOrderDetail 的摘要说明。
    /// </summary>
    public class ctlBIHOrderDetail : System.Windows.Forms.UserControl
    {
        #region 自定义变量
        /// <summary>
        /// 是否是子医嘱,当录入子医嘱时不能输入组套
        /// </summary>
        public bool IsSubOrder = false;
        /// <summary>
        /// 年龄
        /// </summary>
        public int m_intAge = 0;
        /// <summary>
        /// 父医嘱
        /// </summary>
        public clsBIHOrder ParentOrder;
        /*<========================*/
        /// <summary>
        /// 医嘱名称修改标志
        /// </summary>
        public bool m_blOrderName2ReadOnly = false;
        /// <summary>
        /// 药房类型分类ID 1-西药 2-中药 3-材料
        /// </summary>
        public int m_intMEDICNETYPE_INT = 0;
        /// <summary>
        /// 用法VO集
        /// </summary>
        public clsBSEUsageType[] m_arrUsage = null;
        /// <summary>
        /// 频率VO集
        /// </summary>
        public clsAIDRecipeFreq[] m_arrFreq = null;
        /// <summary>
        /// 已查询过的药品制剂类型key-orderdic_id,value-制剂类型名称
        /// </summary>
        public Hashtable m_htMEDICINEPREPTYPE = new Hashtable();
        /// <summary>
        /// 药品库存量
        /// </summary>
        public float m_fotOpcurrentgross_num = 0;
        /// <summary>
        /// 记录是否是药品 1是药品  2为材料
        /// </summary>
        public int m_intITEMSRCTYPE_INT = 0;
        #endregion

        #region 控件申明

        private System.Windows.Forms.Label label3;
        public TextBox m_txtRecipeNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox m_txtExecDept;
        internal System.Windows.Forms.TextBox m_txtGetUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal Label m_lblDosage;
        private System.Windows.Forms.Label label8;
        internal Label m_lblExecuteFreq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public Label m_lblDosageType;
        private System.Windows.Forms.CheckBox m_chkIsRepare;
        private System.Windows.Forms.TextBox m_txtOrderSpec;
        private System.Windows.Forms.TextBox m_txtPackage;
        internal System.Windows.Forms.TextBox m_txtDosage;
        internal System.Windows.Forms.TextBox m_txtUse;
        internal System.Windows.Forms.TextBox m_txtGet;
        /// <summary>
        /// 医生嘱托
        /// </summary>
        public System.Windows.Forms.TextBox m_txtEntrust;
        private System.Windows.Forms.CheckBox m_chkIsRich;
        internal System.Windows.Forms.TextBox m_txtUseUnit;
        internal System.Windows.Forms.TextBox m_txtDosageUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblBackground;
        public System.Windows.Forms.TextBox m_txtPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox m_txtInputDate;
        private System.Windows.Forms.PictureBox m_picInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList m_imgIcons;
        private System.ComponentModel.IContainer components;
        private clsTextFocusHighlight m_objHighlight;
        /// <summary>
        /// 费用标志
        /// </summary>
        public com.digitalwave.controls.ctlQComboBox m_cboRateType;
        private System.Windows.Forms.CheckBox m_chkISNEEDFEEL;
        internal System.Windows.Forms.Label m_lblDay;
        public System.Windows.Forms.TextBox m_txtDays;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox m_TxbStartTime;
        private System.Windows.Forms.TextBox m_txbFinishTime;
        private com.digitalwave.controls.ctlQComboBox m_cboRepare;
        //private clsBIHOrderService m_objService;
        internal com.digitalwave.controls.ctlQComboBox m_cboExecuteType;
        //private clsBIHOrderGroupService m_objService2;	//组套Service
        /// <summary>
        /// 输入完毕事件
        /// </summary>
        public event EventHandler m_evtInputEnd;
        public event EventHandler m_evtInputNO;
        /// <summary>
        /// 执行频率
        /// </summary>
        internal com.digitalwave.controls.ctlFindTextBox m_txtExecuteFreq;
        public com.digitalwave.controls.ctlFindTextBox m_txtDosageType;
        /// <summary>
        /// 父级医嘱
        /// </summary>
        internal com.digitalwave.controls.ctlFindTextBox m_txtFatherOrder;
        /// <summary>
        /// 录入医生
        /// </summary>
        internal com.digitalwave.controls.ctlFindTextBox m_txtDoctor;
        /// <summary>
        /// 医嘱名称
        /// </summary>
        internal com.digitalwave.controls.ctlFindTextBox m_txtOrderName;
        private clsBIHOrderGroup m_objCurrentGroup = null;
        /// <summary>
        /// 保存频率信息的临时对象,仅为提升性能.
        /// </summary>
        private clsAIDRecipeFreq m_objTempFreq = null;
        /// <summary>
        /// 保存频率信息
        /// </summary>
        public Hashtable m_htTempFreq = null;
        /// <summary>
        /// 保存用法信息
        /// </summary>
        public Hashtable m_htTempUsage = null;
        /// <summary>
        ///	Once频率信息对象
        /// </summary>
        private clsAIDRecipeFreq m_objOnceFreq = null;
        /// <summary>
        /// 编码类型 0用户编码   1五笔码	2拼音码
        /// </summary>
        private int m_intInputType = 0;
        /// <summary>
        /// 指定当前录入项目是否是组套
        /// </summary>
        private bool m_blnCurrentItemIsGroup = false;
        private clsBIHOrderDic m_objCurrentDic = null;
        //private clsBIHPatientInfo m_objPatient;
        public clsBIHOrder m_objCurrentOrder;
        private clsBIHDoctor m_objCurrentDoctor;
        public string m_strDeptID = "";
        private bool m_blnReadOnly;
        private const int c_intItem_Group = 0;
        private System.Windows.Forms.TextBox m_txtISNEEDFEEL;
        private const int c_intItem_Order = 1;
        /// <summary>
        /// 病人ID
        /// </summary>
        private string m_strPatientID_Chr = "";
        internal System.Windows.Forms.Label m_lblSaveOrderID;
        /// <summary>
        /// 入院登记流水号
        /// </summary>
        private string m_strRegisterID = "";
        private System.Windows.Forms.DateTimePicker m_dtStartTime;
        private System.Windows.Forms.DateTimePicker m_dtFinishTime;
        private System.Windows.Forms.Label m_lblSaveConOrderFreqID;
        internal System.Windows.Forms.Label m_lblxmclsa;
        internal System.Windows.Forms.CheckBox m_chkIsMedicare;
        internal com.digitalwave.controls.ctlFindTextBox m_txtSample;
        private Label m_lblSample;
        clsDcl_InputOrder m_objInputOrder = null;
        public com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox m_txtCheck;
        public Label m_lblCheck;

        /// <summary>
        /// 检验标志(true-是，false-否)
        /// </summary>
        public bool m_blSampleItem = false;
        public TextBox m_txtOrderName2;
        private Label label1;
        private Button m_btnBedList;
        public ctlFindTextBox m_txtBedNo;
        public ctlFindTextBox m_txtArea;
        private Label label19;
        private Label label10;
        private CheckBox checkBox1;
        private Label label14;
        public TextBox m_txtATTACHTIMES_INT;
        private Label label20;
        public ctlFindTextBox m_txtDoctorList;
        internal Label m_txtMedicareType;
        private Label label22;
        internal NullableDateControls.MaskDateEdit m_dtStartTime2;
        internal NullableDateControls.MaskDateEdit m_dtFinishTime2;
        internal TextBox m_txtGetUnit2;
        internal TextBox m_txtGet2;
        internal ComboBox m_cobOrderCate;
        private Label label17;
        internal com.digitalwave.controls.ctlFindTextBox m_txtOrderCate;
        public TextBox m_txtREMARK_VCHR;
        internal ContextMenuStrip m_MenuStripSelect;
        internal ToolStripMenuItem m_mnuCommonItems;
        internal ToolStripMenuItem m_mnuGroupItems;
        internal ToolStripMenuItem m_mnuNormalItems;
        private ToolStripMenuItem m_mnuNewPriceItems;
        internal ContextMenuStrip m_MenuStripREMARK;
        private ToolStripMenuItem m_mnuNormalRemark;
        internal ToolStripMenuItem m_mnuNormalAdd;
        internal TextBox m_hideDosage;
        internal TextBox m_hideDosageUnit;
        public com.digitalwave.controls.ctlFindTextBox m_hideDosageType;
        internal com.digitalwave.controls.ctlFindTextBox m_hideExecuteFreq;
        public TextBox m_hideDays;
        /// <summary>
        /// 检查标志(true-是，false－否)
        /// </summary>
        public bool m_blCheckItem = false;
        public Label label7;
        public com.digitalwave.controls.ctlQComboBox cboShiying;
        private TextBox m_txtItemTradePrice;
        public Label lblKJ;
        public ComboBox cboKJ;
        public ComboBox cboQK;
        public Label lblQK;
        internal Label label9;
        internal TextBox txtCureDays;
        internal Label label15;
        internal Label label21;
        public ComboBox cboProxyBoil;
        /*<=====================================*/
        /// <summary>
        /// 补次哈希表
        /// </summary>
        internal Hashtable hasAppendViewType = new Hashtable();

        #endregion
        #region 构造函数
        public ctlBIHOrderDetail()
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;

            // TODO: 在 InitializeComponent 调用后添加任何初始化
            //m_objService=clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
            //m_objService2=clsGenerator.CreateObject(typeof(clsBIHOrderGroupService)) as clsBIHOrderGroupService;

            m_objHighlight = new clsTextFocusHighlight();
            m_objInputOrder = new clsDcl_InputOrder();

            timer1.Enabled = false;
            m_picInfo.Visible = false;
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
        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlBIHOrderDetail));
            this.m_cboExecuteType = new com.digitalwave.controls.ctlQComboBox();
            this.m_lblSaveOrderID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtRecipeNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtExecDept = new System.Windows.Forms.TextBox();
            this.m_txtGetUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lblDosage = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblExecuteFreq = new System.Windows.Forms.Label();
            this.m_lblSaveConOrderFreqID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lblDosageType = new System.Windows.Forms.Label();
            this.m_chkIsRepare = new System.Windows.Forms.CheckBox();
            this.m_txtOrderSpec = new System.Windows.Forms.TextBox();
            this.m_txtPackage = new System.Windows.Forms.TextBox();
            this.m_txtDosage = new System.Windows.Forms.TextBox();
            this.m_txtUse = new System.Windows.Forms.TextBox();
            this.m_txtGet = new System.Windows.Forms.TextBox();
            this.m_cboRateType = new com.digitalwave.controls.ctlQComboBox();
            this.m_txtEntrust = new System.Windows.Forms.TextBox();
            this.m_chkIsRich = new System.Windows.Forms.CheckBox();
            this.m_txtUseUnit = new System.Windows.Forms.TextBox();
            this.m_txtDosageUnit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblBackground = new System.Windows.Forms.Label();
            this.m_txtPrice = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtInputDate = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_picInfo = new System.Windows.Forms.PictureBox();
            this.m_txtItemTradePrice = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.m_imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.m_cboRepare = new com.digitalwave.controls.ctlQComboBox();
            this.m_chkISNEEDFEEL = new System.Windows.Forms.CheckBox();
            this.m_txtDays = new System.Windows.Forms.TextBox();
            this.m_lblDay = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtISNEEDFEEL = new System.Windows.Forms.TextBox();
            this.m_TxbStartTime = new System.Windows.Forms.TextBox();
            this.m_txbFinishTime = new System.Windows.Forms.TextBox();
            this.m_txtFatherOrder = new com.digitalwave.controls.ctlFindTextBox();
            this.m_txtOrderName = new com.digitalwave.controls.ctlFindTextBox();
            this.m_MenuStripSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mnuCommonItems = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuGroupItems = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuNormalItems = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuNewPriceItems = new System.Windows.Forms.ToolStripMenuItem();
            this.m_txtExecuteFreq = new com.digitalwave.controls.ctlFindTextBox();
            this.m_txtDoctor = new com.digitalwave.controls.ctlFindTextBox();
            this.m_txtDosageType = new com.digitalwave.controls.ctlFindTextBox();
            this.m_dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.m_dtFinishTime = new System.Windows.Forms.DateTimePicker();
            this.m_lblxmclsa = new System.Windows.Forms.Label();
            this.m_chkIsMedicare = new System.Windows.Forms.CheckBox();
            this.m_txtSample = new com.digitalwave.controls.ctlFindTextBox();
            this.m_lblSample = new System.Windows.Forms.Label();
            this.m_lblCheck = new System.Windows.Forms.Label();
            this.m_txtOrderName2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnBedList = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtATTACHTIMES_INT = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtMedicareType = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtGetUnit2 = new System.Windows.Forms.TextBox();
            this.m_txtGet2 = new System.Windows.Forms.TextBox();
            this.m_dtFinishTime2 = new NullableDateControls.MaskDateEdit();
            this.m_dtStartTime2 = new NullableDateControls.MaskDateEdit();
            this.m_cobOrderCate = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtOrderCate = new com.digitalwave.controls.ctlFindTextBox();
            this.m_txtREMARK_VCHR = new System.Windows.Forms.TextBox();
            this.m_MenuStripREMARK = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mnuNormalRemark = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuNormalAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.m_hideDosage = new System.Windows.Forms.TextBox();
            this.m_hideDosageUnit = new System.Windows.Forms.TextBox();
            this.m_hideDosageType = new com.digitalwave.controls.ctlFindTextBox();
            this.m_hideExecuteFreq = new com.digitalwave.controls.ctlFindTextBox();
            this.m_hideDays = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboShiying = new com.digitalwave.controls.ctlQComboBox();
            this.lblKJ = new System.Windows.Forms.Label();
            this.cboKJ = new System.Windows.Forms.ComboBox();
            this.cboQK = new System.Windows.Forms.ComboBox();
            this.lblQK = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCureDays = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtCheck = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_txtDoctorList = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_txtBedNo = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_txtArea = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboProxyBoil = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_picInfo)).BeginInit();
            this.m_MenuStripSelect.SuspendLayout();
            this.m_MenuStripREMARK.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cboExecuteType
            // 
            this.m_cboExecuteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboExecuteType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboExecuteType.Location = new System.Drawing.Point(63, 10);
            this.m_cboExecuteType.Name = "m_cboExecuteType";
            this.m_cboExecuteType.Size = new System.Drawing.Size(79, 22);
            this.m_cboExecuteType.TabIndex = 7;
            this.m_cboExecuteType.SelectedIndexChanged += new System.EventHandler(this.m_cboExecuteType_SelectedIndexChanged);
            this.m_cboExecuteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboExecuteType_KeyDown);
            // 
            // m_lblSaveOrderID
            // 
            this.m_lblSaveOrderID.AutoSize = true;
            this.m_lblSaveOrderID.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_lblSaveOrderID.Location = new System.Drawing.Point(274, 12);
            this.m_lblSaveOrderID.Name = "m_lblSaveOrderID";
            this.m_lblSaveOrderID.Size = new System.Drawing.Size(66, 13);
            this.m_lblSaveOrderID.TabIndex = 37;
            this.m_lblSaveOrderID.Text = "医嘱内容:";
            this.m_lblSaveOrderID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 44;
            this.label3.Text = "方  号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtRecipeNo
            // 
            this.m_txtRecipeNo.Location = new System.Drawing.Point(51, 127);
            this.m_txtRecipeNo.Name = "m_txtRecipeNo";
            this.m_txtRecipeNo.Size = new System.Drawing.Size(87, 23);
            this.m_txtRecipeNo.TabIndex = 6;
            this.m_txtRecipeNo.TabStop = false;
            this.m_txtRecipeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRecipeNo_KeyDown);
            this.m_txtRecipeNo.Leave += new System.EventHandler(this.m_txtRecipeNo_Leave);
            this.m_txtRecipeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtRecipeNo_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label13.Location = new System.Drawing.Point(1, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "医嘱类型:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtExecDept
            // 
            this.m_txtExecDept.Location = new System.Drawing.Point(135, 358);
            this.m_txtExecDept.Name = "m_txtExecDept";
            this.m_txtExecDept.ReadOnly = true;
            this.m_txtExecDept.Size = new System.Drawing.Size(100, 23);
            this.m_txtExecDept.TabIndex = 69;
            // 
            // m_txtGetUnit
            // 
            this.m_txtGetUnit.Location = new System.Drawing.Point(386, 179);
            this.m_txtGetUnit.Name = "m_txtGetUnit";
            this.m_txtGetUnit.ReadOnly = true;
            this.m_txtGetUnit.Size = new System.Drawing.Size(38, 23);
            this.m_txtGetUnit.TabIndex = 21;
            this.m_txtGetUnit.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 46;
            this.label4.Text = "数量";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 47;
            this.label5.Text = "合计用量:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label6.Location = new System.Drawing.Point(1, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "药品来源:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDosage
            // 
            this.m_lblDosage.AutoSize = true;
            this.m_lblDosage.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_lblDosage.Location = new System.Drawing.Point(472, 12);
            this.m_lblDosage.Name = "m_lblDosage";
            this.m_lblDosage.Size = new System.Drawing.Size(40, 13);
            this.m_lblDosage.TabIndex = 49;
            this.m_lblDosage.Text = "用量:";
            this.m_lblDosage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblDosage.DoubleClick += new System.EventHandler(this.m_lblDosage_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(644, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 50;
            this.label8.Text = "规格";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblExecuteFreq
            // 
            this.m_lblExecuteFreq.AutoSize = true;
            this.m_lblExecuteFreq.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_lblExecuteFreq.Location = new System.Drawing.Point(696, 12);
            this.m_lblExecuteFreq.Name = "m_lblExecuteFreq";
            this.m_lblExecuteFreq.Size = new System.Drawing.Size(40, 13);
            this.m_lblExecuteFreq.TabIndex = 51;
            this.m_lblExecuteFreq.Text = "频率:";
            this.m_lblExecuteFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblExecuteFreq.DoubleClick += new System.EventHandler(this.m_lblExecuteFreq_DoubleClick);
            // 
            // m_lblSaveConOrderFreqID
            // 
            this.m_lblSaveConOrderFreqID.AutoSize = true;
            this.m_lblSaveConOrderFreqID.Location = new System.Drawing.Point(162, 133);
            this.m_lblSaveConOrderFreqID.Name = "m_lblSaveConOrderFreqID";
            this.m_lblSaveConOrderFreqID.Size = new System.Drawing.Size(63, 14);
            this.m_lblSaveConOrderFreqID.TabIndex = 52;
            this.m_lblSaveConOrderFreqID.Text = "开嘱时间";
            this.m_lblSaveConOrderFreqID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblSaveConOrderFreqID.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(527, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 53;
            this.label11.Text = "停嘱时间";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label12.Location = new System.Drawing.Point(272, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "嘱托|说明";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDosageType
            // 
            this.m_lblDosageType.AutoSize = true;
            this.m_lblDosageType.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_lblDosageType.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_lblDosageType.Location = new System.Drawing.Point(601, 12);
            this.m_lblDosageType.Name = "m_lblDosageType";
            this.m_lblDosageType.Size = new System.Drawing.Size(40, 13);
            this.m_lblDosageType.TabIndex = 55;
            this.m_lblDosageType.Text = "用法:";
            this.m_lblDosageType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblDosageType.DoubleClick += new System.EventHandler(this.m_lblDosageType_DoubleClick);
            // 
            // m_chkIsRepare
            // 
            this.m_chkIsRepare.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkIsRepare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIsRepare.Location = new System.Drawing.Point(19, 237);
            this.m_chkIsRepare.Name = "m_chkIsRepare";
            this.m_chkIsRepare.Size = new System.Drawing.Size(86, 24);
            this.m_chkIsRepare.TabIndex = 22;
            this.m_chkIsRepare.TabStop = false;
            this.m_chkIsRepare.Text = "是否补登:";
            this.m_chkIsRepare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkIsRepare.CheckedChanged += new System.EventHandler(this.m_chkIsRepare_CheckedChanged);
            this.m_chkIsRepare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_chkIsRepare_KeyDown);
            // 
            // m_txtOrderSpec
            // 
            this.m_txtOrderSpec.Location = new System.Drawing.Point(684, 233);
            this.m_txtOrderSpec.Name = "m_txtOrderSpec";
            this.m_txtOrderSpec.ReadOnly = true;
            this.m_txtOrderSpec.Size = new System.Drawing.Size(102, 23);
            this.m_txtOrderSpec.TabIndex = 25;
            this.m_txtOrderSpec.TabStop = false;
            this.toolTip1.SetToolTip(this.m_txtOrderSpec, "规格");
            // 
            // m_txtPackage
            // 
            this.m_txtPackage.Location = new System.Drawing.Point(24, 358);
            this.m_txtPackage.Name = "m_txtPackage";
            this.m_txtPackage.ReadOnly = true;
            this.m_txtPackage.Size = new System.Drawing.Size(50, 23);
            this.m_txtPackage.TabIndex = 26;
            this.m_txtPackage.TabStop = false;
            this.toolTip1.SetToolTip(this.m_txtPackage, "包装");
            // 
            // m_txtDosage
            // 
            this.m_txtDosage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDosage.ForeColor = System.Drawing.Color.Red;
            this.m_txtDosage.Location = new System.Drawing.Point(507, 10);
            this.m_txtDosage.MaxLength = 6;
            this.m_txtDosage.Name = "m_txtDosage";
            this.m_txtDosage.Size = new System.Drawing.Size(56, 23);
            this.m_txtDosage.TabIndex = 10;
            this.m_txtDosage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDosage_KeyDown);
            this.m_txtDosage.Leave += new System.EventHandler(this.m_txtDosage_Leave);
            this.m_txtDosage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthOnlyNumber);
            // 
            // m_txtUse
            // 
            this.m_txtUse.Location = new System.Drawing.Point(379, 233);
            this.m_txtUse.MaxLength = 9;
            this.m_txtUse.Name = "m_txtUse";
            this.m_txtUse.ReadOnly = true;
            this.m_txtUse.Size = new System.Drawing.Size(76, 23);
            this.m_txtUse.TabIndex = 18;
            this.m_txtUse.TabStop = false;
            this.m_txtUse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtUse_KeyDown);
            this.m_txtUse.Leave += new System.EventHandler(this.m_txtUse_Leave);
            this.m_txtUse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthOnlyNumber);
            // 
            // m_txtGet
            // 
            this.m_txtGet.ForeColor = System.Drawing.Color.Red;
            this.m_txtGet.Location = new System.Drawing.Point(322, 179);
            this.m_txtGet.MaxLength = 6;
            this.m_txtGet.Name = "m_txtGet";
            this.m_txtGet.Size = new System.Drawing.Size(61, 23);
            this.m_txtGet.TabIndex = 12;
            this.m_txtGet.TabStop = false;
            this.m_txtGet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtGet_KeyDown);
            this.m_txtGet.Leave += new System.EventHandler(this.m_txtGet_Leave);
            this.m_txtGet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthOnlyNumber);
            // 
            // m_cboRateType
            // 
            this.m_cboRateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRateType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRateType.Location = new System.Drawing.Point(63, 41);
            this.m_cboRateType.Name = "m_cboRateType";
            this.m_cboRateType.Size = new System.Drawing.Size(79, 22);
            this.m_cboRateType.TabIndex = 14;
            this.m_cboRateType.SelectionChangeCommitted += new System.EventHandler(this.m_cboRateType_SelectionChangeCommitted);
            this.m_cboRateType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboRateType_KeyDown);
            // 
            // m_txtEntrust
            // 
            this.m_txtEntrust.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEntrust.Location = new System.Drawing.Point(281, 158);
            this.m_txtEntrust.MaxLength = 100;
            this.m_txtEntrust.Name = "m_txtEntrust";
            this.m_txtEntrust.Size = new System.Drawing.Size(129, 23);
            this.m_txtEntrust.TabIndex = 13;
            this.m_txtEntrust.TabStop = false;
            this.m_txtEntrust.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtEntrust_KeyDown);
            // 
            // m_chkIsRich
            // 
            this.m_chkIsRich.BackColor = System.Drawing.SystemColors.Control;
            this.m_chkIsRich.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkIsRich.Enabled = false;
            this.m_chkIsRich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIsRich.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_chkIsRich.Location = new System.Drawing.Point(201, 237);
            this.m_chkIsRich.Name = "m_chkIsRich";
            this.m_chkIsRich.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_chkIsRich.Size = new System.Drawing.Size(86, 24);
            this.m_chkIsRich.TabIndex = 24;
            this.m_chkIsRich.TabStop = false;
            this.m_chkIsRich.Text = "是否贵重:";
            this.m_chkIsRich.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkIsRich.UseVisualStyleBackColor = false;
            this.m_chkIsRich.CheckedChanged += new System.EventHandler(this.m_chkIsRich_CheckedChanged);
            this.m_chkIsRich.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_chkIsRich_KeyDown);
            // 
            // m_txtUseUnit
            // 
            this.m_txtUseUnit.Location = new System.Drawing.Point(457, 233);
            this.m_txtUseUnit.Name = "m_txtUseUnit";
            this.m_txtUseUnit.ReadOnly = true;
            this.m_txtUseUnit.Size = new System.Drawing.Size(38, 23);
            this.m_txtUseUnit.TabIndex = 19;
            this.m_txtUseUnit.TabStop = false;
            // 
            // m_txtDosageUnit
            // 
            this.m_txtDosageUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDosageUnit.Location = new System.Drawing.Point(562, 10);
            this.m_txtDosageUnit.Name = "m_txtDosageUnit";
            this.m_txtDosageUnit.ReadOnly = true;
            this.m_txtDosageUnit.Size = new System.Drawing.Size(38, 23);
            this.m_txtDosageUnit.TabIndex = 17;
            this.m_txtDosageUnit.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 78;
            this.label2.Text = "下嘱医生:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // m_lblBackground
            // 
            this.m_lblBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblBackground.Location = new System.Drawing.Point(30, 405);
            this.m_lblBackground.Name = "m_lblBackground";
            this.m_lblBackground.Size = new System.Drawing.Size(24, 12);
            this.m_lblBackground.TabIndex = 79;
            // 
            // m_txtPrice
            // 
            this.m_txtPrice.Location = new System.Drawing.Point(892, 168);
            this.m_txtPrice.Name = "m_txtPrice";
            this.m_txtPrice.ReadOnly = true;
            this.m_txtPrice.Size = new System.Drawing.Size(56, 23);
            this.m_txtPrice.TabIndex = 27;
            this.m_txtPrice.TabStop = false;
            this.toolTip1.SetToolTip(this.m_txtPrice, "单价");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(476, 292);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 81;
            this.label16.Text = "录入时间:";
            this.label16.Visible = false;
            // 
            // m_txtInputDate
            // 
            this.m_txtInputDate.Location = new System.Drawing.Point(552, 289);
            this.m_txtInputDate.Name = "m_txtInputDate";
            this.m_txtInputDate.ReadOnly = true;
            this.m_txtInputDate.Size = new System.Drawing.Size(187, 23);
            this.m_txtInputDate.TabIndex = 34;
            this.m_txtInputDate.TabStop = false;
            this.m_txtInputDate.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            // 
            // m_picInfo
            // 
            this.m_picInfo.Image = ((System.Drawing.Image)(resources.GetObject("m_picInfo.Image")));
            this.m_picInfo.Location = new System.Drawing.Point(566, 325);
            this.m_picInfo.Name = "m_picInfo";
            this.m_picInfo.Size = new System.Drawing.Size(24, 24);
            this.m_picInfo.TabIndex = 101;
            this.m_picInfo.TabStop = false;
            this.toolTip1.SetToolTip(this.m_picInfo, "dfssd");
            this.m_picInfo.MouseEnter += new System.EventHandler(this.m_picInfo_MouseEnter);
            // 
            // m_txtItemTradePrice
            // 
            this.m_txtItemTradePrice.Location = new System.Drawing.Point(442, 200);
            this.m_txtItemTradePrice.Name = "m_txtItemTradePrice";
            this.m_txtItemTradePrice.ReadOnly = true;
            this.m_txtItemTradePrice.Size = new System.Drawing.Size(50, 23);
            this.m_txtItemTradePrice.TabIndex = 803;
            this.m_txtItemTradePrice.TabStop = false;
            this.toolTip1.SetToolTip(this.m_txtItemTradePrice, "批发价");
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // m_imgIcons
            // 
            this.m_imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgIcons.ImageStream")));
            this.m_imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imgIcons.Images.SetKeyName(0, "");
            this.m_imgIcons.Images.SetKeyName(1, "");
            this.m_imgIcons.Images.SetKeyName(2, "");
            this.m_imgIcons.Images.SetKeyName(3, "");
            this.m_imgIcons.Images.SetKeyName(4, "");
            this.m_imgIcons.Images.SetKeyName(5, "");
            // 
            // m_cboRepare
            // 
            this.m_cboRepare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRepare.Enabled = false;
            this.m_cboRepare.Location = new System.Drawing.Point(114, 238);
            this.m_cboRepare.Name = "m_cboRepare";
            this.m_cboRepare.Size = new System.Drawing.Size(82, 22);
            this.m_cboRepare.TabIndex = 23;
            this.m_cboRepare.TabStop = false;
            this.m_cboRepare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboRepare_KeyDown);
            // 
            // m_chkISNEEDFEEL
            // 
            this.m_chkISNEEDFEEL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkISNEEDFEEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkISNEEDFEEL.Location = new System.Drawing.Point(18, 260);
            this.m_chkISNEEDFEEL.Name = "m_chkISNEEDFEEL";
            this.m_chkISNEEDFEEL.Size = new System.Drawing.Size(86, 24);
            this.m_chkISNEEDFEEL.TabIndex = 28;
            this.m_chkISNEEDFEEL.TabStop = false;
            this.m_chkISNEEDFEEL.Text = "是否皮试:";
            this.m_chkISNEEDFEEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkISNEEDFEEL.Visible = false;
            this.m_chkISNEEDFEEL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_chkISNEEDFEEL_KeyDown);
            // 
            // m_txtDays
            // 
            this.m_txtDays.Location = new System.Drawing.Point(786, 10);
            this.m_txtDays.MaxLength = 2;
            this.m_txtDays.Name = "m_txtDays";
            this.m_txtDays.Size = new System.Drawing.Size(24, 23);
            this.m_txtDays.TabIndex = 13;
            this.m_txtDays.Visible = false;
            this.m_txtDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDays_KeyDown);
            this.m_txtDays.Leave += new System.EventHandler(this.m_txtDays_Leave);
            this.m_txtDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthOnlyNumber);
            // 
            // m_lblDay
            // 
            this.m_lblDay.AutoSize = true;
            this.m_lblDay.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_lblDay.Location = new System.Drawing.Point(810, 12);
            this.m_lblDay.Name = "m_lblDay";
            this.m_lblDay.Size = new System.Drawing.Size(20, 13);
            this.m_lblDay.TabIndex = 54;
            this.m_lblDay.Text = "天";
            this.m_lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblDay.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 292);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 14);
            this.label18.TabIndex = 104;
            this.label18.Text = "父级医嘱:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.Visible = false;
            // 
            // m_txtISNEEDFEEL
            // 
            this.m_txtISNEEDFEEL.Location = new System.Drawing.Point(113, 262);
            this.m_txtISNEEDFEEL.Name = "m_txtISNEEDFEEL";
            this.m_txtISNEEDFEEL.ReadOnly = true;
            this.m_txtISNEEDFEEL.Size = new System.Drawing.Size(84, 23);
            this.m_txtISNEEDFEEL.TabIndex = 29;
            this.m_txtISNEEDFEEL.Visible = false;
            this.m_txtISNEEDFEEL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtISNEEDFEEL_KeyDown);
            // 
            // m_TxbStartTime
            // 
            this.m_TxbStartTime.Location = new System.Drawing.Point(272, 261);
            this.m_TxbStartTime.Name = "m_TxbStartTime";
            this.m_TxbStartTime.ReadOnly = true;
            this.m_TxbStartTime.Size = new System.Drawing.Size(187, 23);
            this.m_TxbStartTime.TabIndex = 30;
            this.m_TxbStartTime.TabStop = false;
            this.m_TxbStartTime.Visible = false;
            // 
            // m_txbFinishTime
            // 
            this.m_txbFinishTime.Location = new System.Drawing.Point(552, 263);
            this.m_txbFinishTime.Name = "m_txbFinishTime";
            this.m_txbFinishTime.ReadOnly = true;
            this.m_txbFinishTime.Size = new System.Drawing.Size(187, 23);
            this.m_txbFinishTime.TabIndex = 31;
            this.m_txbFinishTime.TabStop = false;
            this.m_txbFinishTime.Visible = false;
            // 
            // m_txtFatherOrder
            // 
            this.m_txtFatherOrder.Enabled = false;
            this.m_txtFatherOrder.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtFatherOrder.Location = new System.Drawing.Point(89, 288);
            this.m_txtFatherOrder.Name = "m_txtFatherOrder";
            this.m_txtFatherOrder.ReadOnly = true;
            this.m_txtFatherOrder.Size = new System.Drawing.Size(109, 23);
            this.m_txtFatherOrder.TabIndex = 15;
            this.m_txtFatherOrder.TabStop = false;
            this.m_txtFatherOrder.Visible = false;
            this.m_txtFatherOrder.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtFatherOrder_m_evtSelectItem);
            this.m_txtFatherOrder.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtFatherOrder_m_evtFindItem);
            this.m_txtFatherOrder.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtFatherOrder_m_evtInitListView);
            // 
            // m_txtOrderName
            // 
            this.m_txtOrderName.ContextMenuStrip = this.m_MenuStripSelect;
            this.m_txtOrderName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOrderName.Location = new System.Drawing.Point(336, 10);
            this.m_txtOrderName.MaxLength = 25;
            this.m_txtOrderName.Name = "m_txtOrderName";
            this.m_txtOrderName.Size = new System.Drawing.Size(134, 23);
            this.m_txtOrderName.TabIndex = 9;
            this.m_txtOrderName.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtOrderName_m_evtSelectItem);
            this.m_txtOrderName.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtOrderName_m_evtFindItem);
            this.m_txtOrderName.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtOrderName_m_evtInitListView);
            // 
            // m_MenuStripSelect
            // 
            this.m_MenuStripSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuCommonItems,
            this.m_mnuGroupItems,
            this.m_mnuNormalItems,
            this.m_mnuNewPriceItems});
            this.m_MenuStripSelect.Name = "m_MenuStripSelect";
            this.m_MenuStripSelect.Size = new System.Drawing.Size(125, 92);
            // 
            // m_mnuCommonItems
            // 
            this.m_mnuCommonItems.Name = "m_mnuCommonItems";
            this.m_mnuCommonItems.Size = new System.Drawing.Size(124, 22);
            this.m_mnuCommonItems.Text = "常用项目";
            this.m_mnuCommonItems.Click += new System.EventHandler(this.m_mnuCommonItems_Click);
            // 
            // m_mnuGroupItems
            // 
            this.m_mnuGroupItems.Name = "m_mnuGroupItems";
            this.m_mnuGroupItems.Size = new System.Drawing.Size(124, 22);
            this.m_mnuGroupItems.Text = "组套模板";
            this.m_mnuGroupItems.Click += new System.EventHandler(this.m_mnuGroupItems_Click);
            // 
            // m_mnuNormalItems
            // 
            this.m_mnuNormalItems.Name = "m_mnuNormalItems";
            this.m_mnuNormalItems.Size = new System.Drawing.Size(124, 22);
            this.m_mnuNormalItems.Text = "普通项目";
            this.m_mnuNormalItems.Click += new System.EventHandler(this.m_mnuNormalItems_Click);
            // 
            // m_mnuNewPriceItems
            // 
            this.m_mnuNewPriceItems.Name = "m_mnuNewPriceItems";
            this.m_mnuNewPriceItems.Size = new System.Drawing.Size(124, 22);
            this.m_mnuNewPriceItems.Text = "新价项目";
            this.m_mnuNewPriceItems.Click += new System.EventHandler(this.m_mnuNewPriceItems_Click);
            // 
            // m_txtExecuteFreq
            // 
            this.m_txtExecuteFreq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExecuteFreq.Location = new System.Drawing.Point(731, 10);
            this.m_txtExecuteFreq.MaxLength = 20;
            this.m_txtExecuteFreq.Name = "m_txtExecuteFreq";
            this.m_txtExecuteFreq.Size = new System.Drawing.Size(54, 23);
            this.m_txtExecuteFreq.TabIndex = 12;
            this.m_txtExecuteFreq.EnabledChanged += new System.EventHandler(this.m_txtExecuteFreq_EnabledChanged);
            this.m_txtExecuteFreq.DoubleClick += new System.EventHandler(this.m_txtExecuteFreq_DoubleClick);
            this.m_txtExecuteFreq.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtExecuteFreq_m_evtSelectItem);
            this.m_txtExecuteFreq.Leave += new System.EventHandler(this.m_txtExecuteFreq_Leave);
            this.m_txtExecuteFreq.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtExecuteFreq_m_evtFindItem);
            this.m_txtExecuteFreq.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtExecuteFreq_m_evtInitListView);
            // 
            // m_txtDoctor
            // 
            this.m_txtDoctor.Enabled = false;
            this.m_txtDoctor.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtDoctor.Location = new System.Drawing.Point(271, 288);
            this.m_txtDoctor.MaxLength = 9;
            this.m_txtDoctor.Name = "m_txtDoctor";
            this.m_txtDoctor.ReadOnly = true;
            this.m_txtDoctor.Size = new System.Drawing.Size(190, 23);
            this.m_txtDoctor.TabIndex = 33;
            this.m_txtDoctor.Visible = false;
            this.m_txtDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDoctor_KeyDown);
            this.m_txtDoctor.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtDoctor_m_evtSelectItem);
            this.m_txtDoctor.Enter += new System.EventHandler(this.m_txtDoctor_Enter);
            this.m_txtDoctor.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtDoctor_m_evtFindItem);
            this.m_txtDoctor.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtDoctor_m_evtInitListView);
            // 
            // m_txtDosageType
            // 
            this.m_txtDosageType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDosageType.Location = new System.Drawing.Point(636, 10);
            this.m_txtDosageType.MaxLength = 20;
            this.m_txtDosageType.Name = "m_txtDosageType";
            this.m_txtDosageType.Size = new System.Drawing.Size(60, 23);
            this.m_txtDosageType.TabIndex = 11;
            this.m_txtDosageType.EnabledChanged += new System.EventHandler(this.m_txtDosageType_EnabledChanged);
            this.m_txtDosageType.DoubleClick += new System.EventHandler(this.m_txtDosageType_DoubleClick);
            this.m_txtDosageType.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtDosageType_m_evtSelectItem);
            this.m_txtDosageType.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtDosageType_m_evtFindItem);
            this.m_txtDosageType.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtDosageType_m_evtInitListView);
            // 
            // m_dtStartTime
            // 
            this.m_dtStartTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.m_dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtStartTime.Location = new System.Drawing.Point(30, 317);
            this.m_dtStartTime.Name = "m_dtStartTime";
            this.m_dtStartTime.Size = new System.Drawing.Size(187, 23);
            this.m_dtStartTime.TabIndex = 107;
            this.m_dtStartTime.TabStop = false;
            // 
            // m_dtFinishTime
            // 
            this.m_dtFinishTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.m_dtFinishTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtFinishTime.Location = new System.Drawing.Point(240, 317);
            this.m_dtFinishTime.Name = "m_dtFinishTime";
            this.m_dtFinishTime.Size = new System.Drawing.Size(187, 23);
            this.m_dtFinishTime.TabIndex = 107;
            this.m_dtFinishTime.TabStop = false;
            this.m_dtFinishTime.Leave += new System.EventHandler(this.m_dtFinishTime_Leave);
            // 
            // m_lblxmclsa
            // 
            this.m_lblxmclsa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblxmclsa.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lblxmclsa.Location = new System.Drawing.Point(702, 325);
            this.m_lblxmclsa.Name = "m_lblxmclsa";
            this.m_lblxmclsa.Size = new System.Drawing.Size(42, 20);
            this.m_lblxmclsa.TabIndex = 108;
            this.m_lblxmclsa.Text = "甲类";
            this.m_lblxmclsa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_chkIsMedicare
            // 
            this.m_chkIsMedicare.Enabled = false;
            this.m_chkIsMedicare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIsMedicare.Location = new System.Drawing.Point(479, 325);
            this.m_chkIsMedicare.Name = "m_chkIsMedicare";
            this.m_chkIsMedicare.Size = new System.Drawing.Size(60, 24);
            this.m_chkIsMedicare.TabIndex = 109;
            this.m_chkIsMedicare.TabStop = false;
            this.m_chkIsMedicare.Text = "医保";
            this.m_chkIsMedicare.CheckedChanged += new System.EventHandler(this.m_chkIsMedicare_CheckedChanged);
            // 
            // m_txtSample
            // 
            this.m_txtSample.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtSample.Location = new System.Drawing.Point(196, 210);
            this.m_txtSample.MaxLength = 10;
            this.m_txtSample.Name = "m_txtSample";
            this.m_txtSample.Size = new System.Drawing.Size(60, 23);
            this.m_txtSample.TabIndex = 11;
            this.m_txtSample.Tag = "13";
            this.m_txtSample.Visible = false;
            this.m_txtSample.DoubleClick += new System.EventHandler(this.m_txtSample_DoubleClick);
            this.m_txtSample.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtSample_m_evtSelectItem);
            this.m_txtSample.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtSample_m_evtFindItem);
            this.m_txtSample.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtSample_m_evtInitListView);
            // 
            // m_lblSample
            // 
            this.m_lblSample.AutoSize = true;
            this.m_lblSample.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblSample.Location = new System.Drawing.Point(150, 216);
            this.m_lblSample.Name = "m_lblSample";
            this.m_lblSample.Size = new System.Drawing.Size(35, 14);
            this.m_lblSample.TabIndex = 111;
            this.m_lblSample.Text = "样本";
            this.m_lblSample.Visible = false;
            // 
            // m_lblCheck
            // 
            this.m_lblCheck.AutoSize = true;
            this.m_lblCheck.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblCheck.Location = new System.Drawing.Point(148, 186);
            this.m_lblCheck.Name = "m_lblCheck";
            this.m_lblCheck.Size = new System.Drawing.Size(35, 14);
            this.m_lblCheck.TabIndex = 113;
            this.m_lblCheck.Text = "部位";
            this.m_lblCheck.Visible = false;
            // 
            // m_txtOrderName2
            // 
            this.m_txtOrderName2.Location = new System.Drawing.Point(508, 233);
            this.m_txtOrderName2.MaxLength = 50;
            this.m_txtOrderName2.Name = "m_txtOrderName2";
            this.m_txtOrderName2.Size = new System.Drawing.Size(116, 23);
            this.m_txtOrderName2.TabIndex = 8;
            this.m_txtOrderName2.TabStop = false;
            this.m_txtOrderName2.DoubleClick += new System.EventHandler(this.m_txtOrderName2_DoubleClick);
            this.m_txtOrderName2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtOrderName2_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 120;
            this.label1.Text = "下嘱医生";
            this.label1.Visible = false;
            // 
            // m_btnBedList
            // 
            this.m_btnBedList.Location = new System.Drawing.Point(254, 154);
            this.m_btnBedList.Name = "m_btnBedList";
            this.m_btnBedList.Size = new System.Drawing.Size(19, 23);
            this.m_btnBedList.TabIndex = 3;
            this.m_btnBedList.Text = "↓";
            this.m_btnBedList.UseVisualStyleBackColor = true;
            this.m_btnBedList.Click += new System.EventHandler(this.m_btnBedList_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label19.Location = new System.Drawing.Point(157, 159);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 14);
            this.label19.TabIndex = 117;
            this.label19.Text = "床号";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label10.Location = new System.Drawing.Point(11, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 118;
            this.label10.Text = "病区";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(597, 325);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 24);
            this.checkBox1.TabIndex = 122;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "是否补次:";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(491, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 125;
            this.label14.Text = "补次";
            // 
            // m_txtATTACHTIMES_INT
            // 
            this.m_txtATTACHTIMES_INT.Location = new System.Drawing.Point(526, 178);
            this.m_txtATTACHTIMES_INT.MaxLength = 1;
            this.m_txtATTACHTIMES_INT.Name = "m_txtATTACHTIMES_INT";
            this.m_txtATTACHTIMES_INT.Size = new System.Drawing.Size(30, 23);
            this.m_txtATTACHTIMES_INT.TabIndex = 14;
            this.m_txtATTACHTIMES_INT.TabStop = false;
            this.m_txtATTACHTIMES_INT.Text = "0";
            this.m_txtATTACHTIMES_INT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtATTACHTIMES_INT_KeyDown);
            this.m_txtATTACHTIMES_INT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthOnlyNumber);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(950, 172);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 14);
            this.label20.TabIndex = 127;
            this.label20.Text = "元";
            // 
            // m_txtMedicareType
            // 
            this.m_txtMedicareType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtMedicareType.Font = new System.Drawing.Font("宋体", 9F);
            this.m_txtMedicareType.ForeColor = System.Drawing.Color.Red;
            this.m_txtMedicareType.Location = new System.Drawing.Point(850, 263);
            this.m_txtMedicareType.Name = "m_txtMedicareType";
            this.m_txtMedicareType.Size = new System.Drawing.Size(56, 20);
            this.m_txtMedicareType.TabIndex = 131;
            this.m_txtMedicareType.Text = "       ";
            this.m_txtMedicareType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(811, 266);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 14);
            this.label22.TabIndex = 132;
            this.label22.Text = "医保";
            // 
            // m_txtGetUnit2
            // 
            this.m_txtGetUnit2.Location = new System.Drawing.Point(291, 201);
            this.m_txtGetUnit2.Name = "m_txtGetUnit2";
            this.m_txtGetUnit2.ReadOnly = true;
            this.m_txtGetUnit2.Size = new System.Drawing.Size(38, 23);
            this.m_txtGetUnit2.TabIndex = 133;
            this.m_txtGetUnit2.TabStop = false;
            // 
            // m_txtGet2
            // 
            this.m_txtGet2.Location = new System.Drawing.Point(442, 179);
            this.m_txtGet2.MaxLength = 6;
            this.m_txtGet2.Name = "m_txtGet2";
            this.m_txtGet2.ReadOnly = true;
            this.m_txtGet2.Size = new System.Drawing.Size(41, 23);
            this.m_txtGet2.TabIndex = 134;
            this.m_txtGet2.Visible = false;
            // 
            // m_dtFinishTime2
            // 
            this.m_dtFinishTime2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_dtFinishTime2.Location = new System.Drawing.Point(593, 177);
            this.m_dtFinishTime2.Mask = "yyyy年MM月dd日HH时mm分";
            this.m_dtFinishTime2.Name = "m_dtFinishTime2";
            this.m_dtFinishTime2.Size = new System.Drawing.Size(188, 23);
            this.m_dtFinishTime2.TabIndex = 19;
            this.m_dtFinishTime2.TabStop = false;
            this.m_dtFinishTime2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtFinishTime2_KeyDown);
            this.m_dtFinishTime2.Leave += new System.EventHandler(this.m_dtFinishTime2_Leave);
            // 
            // m_dtStartTime2
            // 
            this.m_dtStartTime2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_dtStartTime2.Location = new System.Drawing.Point(235, 129);
            this.m_dtStartTime2.Mask = "yyyy年MM月dd日HH时mm分";
            this.m_dtStartTime2.Name = "m_dtStartTime2";
            this.m_dtStartTime2.Size = new System.Drawing.Size(175, 23);
            this.m_dtStartTime2.TabIndex = 15;
            this.m_dtStartTime2.TabStop = false;
            this.m_dtStartTime2.Visible = false;
            this.m_dtStartTime2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtStartTime2_KeyDown);
            // 
            // m_cobOrderCate
            // 
            this.m_cobOrderCate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_cobOrderCate.Location = new System.Drawing.Point(14, 183);
            this.m_cobOrderCate.Name = "m_cobOrderCate";
            this.m_cobOrderCate.Size = new System.Drawing.Size(109, 22);
            this.m_cobOrderCate.TabIndex = 800;
            this.m_cobOrderCate.TabStop = false;
            this.m_cobOrderCate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cobOrderCate_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label17.Location = new System.Drawing.Point(157, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 136;
            this.label17.Text = "分类:";
            // 
            // m_txtOrderCate
            // 
            this.m_txtOrderCate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOrderCate.Location = new System.Drawing.Point(192, 11);
            this.m_txtOrderCate.MaxLength = 20;
            this.m_txtOrderCate.Name = "m_txtOrderCate";
            this.m_txtOrderCate.Size = new System.Drawing.Size(79, 23);
            this.m_txtOrderCate.TabIndex = 8;
            this.m_txtOrderCate.DoubleClick += new System.EventHandler(this.m_txtOrderCate_DoubleClick);
            this.m_txtOrderCate.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtOrderCate_m_evtSelectItem);
            this.m_txtOrderCate.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtOrderCate_m_evtFindItem);
            this.m_txtOrderCate.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtOrderCate_m_evtInitListView);
            // 
            // m_txtREMARK_VCHR
            // 
            this.m_txtREMARK_VCHR.ContextMenuStrip = this.m_MenuStripREMARK;
            this.m_txtREMARK_VCHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtREMARK_VCHR.Location = new System.Drawing.Point(336, 40);
            this.m_txtREMARK_VCHR.MaxLength = 100;
            this.m_txtREMARK_VCHR.Name = "m_txtREMARK_VCHR";
            this.m_txtREMARK_VCHR.Size = new System.Drawing.Size(449, 23);
            this.m_txtREMARK_VCHR.TabIndex = 15;
            this.m_txtREMARK_VCHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtREMARK_VCHR_KeyDown);
            // 
            // m_MenuStripREMARK
            // 
            this.m_MenuStripREMARK.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuNormalRemark,
            this.m_mnuNormalAdd});
            this.m_MenuStripREMARK.Name = "m_MenuStripREMARK";
            this.m_MenuStripREMARK.Size = new System.Drawing.Size(125, 48);
            // 
            // m_mnuNormalRemark
            // 
            this.m_mnuNormalRemark.Name = "m_mnuNormalRemark";
            this.m_mnuNormalRemark.Size = new System.Drawing.Size(124, 22);
            this.m_mnuNormalRemark.Text = "常用说明";
            this.m_mnuNormalRemark.Click += new System.EventHandler(this.m_mnuNormalRemark_Click);
            // 
            // m_mnuNormalAdd
            // 
            this.m_mnuNormalAdd.Name = "m_mnuNormalAdd";
            this.m_mnuNormalAdd.Size = new System.Drawing.Size(124, 22);
            this.m_mnuNormalAdd.Text = "新增常用";
            this.m_mnuNormalAdd.Click += new System.EventHandler(this.m_mnuNormalAdd_Click);
            // 
            // m_hideDosage
            // 
            this.m_hideDosage.BackColor = System.Drawing.SystemColors.Control;
            this.m_hideDosage.Enabled = false;
            this.m_hideDosage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_hideDosage.ForeColor = System.Drawing.Color.Red;
            this.m_hideDosage.Location = new System.Drawing.Point(461, 124);
            this.m_hideDosage.MaxLength = 6;
            this.m_hideDosage.Name = "m_hideDosage";
            this.m_hideDosage.Size = new System.Drawing.Size(56, 23);
            this.m_hideDosage.TabIndex = 139;
            this.m_hideDosage.Visible = false;
            // 
            // m_hideDosageUnit
            // 
            this.m_hideDosageUnit.Enabled = false;
            this.m_hideDosageUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_hideDosageUnit.Location = new System.Drawing.Point(523, 124);
            this.m_hideDosageUnit.Name = "m_hideDosageUnit";
            this.m_hideDosageUnit.ReadOnly = true;
            this.m_hideDosageUnit.Size = new System.Drawing.Size(38, 23);
            this.m_hideDosageUnit.TabIndex = 140;
            this.m_hideDosageUnit.TabStop = false;
            this.m_hideDosageUnit.Visible = false;
            // 
            // m_hideDosageType
            // 
            this.m_hideDosageType.BackColor = System.Drawing.SystemColors.Control;
            this.m_hideDosageType.Enabled = false;
            this.m_hideDosageType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_hideDosageType.Location = new System.Drawing.Point(564, 124);
            this.m_hideDosageType.MaxLength = 20;
            this.m_hideDosageType.Name = "m_hideDosageType";
            this.m_hideDosageType.Size = new System.Drawing.Size(60, 23);
            this.m_hideDosageType.TabIndex = 141;
            this.m_hideDosageType.Visible = false;
            // 
            // m_hideExecuteFreq
            // 
            this.m_hideExecuteFreq.BackColor = System.Drawing.SystemColors.Control;
            this.m_hideExecuteFreq.Enabled = false;
            this.m_hideExecuteFreq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_hideExecuteFreq.Location = new System.Drawing.Point(637, 124);
            this.m_hideExecuteFreq.MaxLength = 20;
            this.m_hideExecuteFreq.Name = "m_hideExecuteFreq";
            this.m_hideExecuteFreq.Size = new System.Drawing.Size(54, 23);
            this.m_hideExecuteFreq.TabIndex = 142;
            this.m_hideExecuteFreq.Visible = false;
            // 
            // m_hideDays
            // 
            this.m_hideDays.BackColor = System.Drawing.SystemColors.Control;
            this.m_hideDays.Enabled = false;
            this.m_hideDays.Location = new System.Drawing.Point(698, 124);
            this.m_hideDays.MaxLength = 2;
            this.m_hideDays.Name = "m_hideDays";
            this.m_hideDays.Size = new System.Drawing.Size(24, 23);
            this.m_hideDays.TabIndex = 143;
            this.m_hideDays.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label7.Location = new System.Drawing.Point(144, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 801;
            this.label7.Text = "适应症:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboShiying
            // 
            this.cboShiying.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShiying.Enabled = false;
            this.cboShiying.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboShiying.Items.AddRange(new object[] {
            "2符合",
            "3不符合"});
            this.cboShiying.Location = new System.Drawing.Point(192, 41);
            this.cboShiying.Name = "cboShiying";
            this.cboShiying.Size = new System.Drawing.Size(79, 22);
            this.cboShiying.TabIndex = 802;
            this.cboShiying.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboShiying_KeyDown);
            // 
            // lblKJ
            // 
            this.lblKJ.AutoSize = true;
            this.lblKJ.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblKJ.Location = new System.Drawing.Point(157, 72);
            this.lblKJ.Name = "lblKJ";
            this.lblKJ.Size = new System.Drawing.Size(40, 13);
            this.lblKJ.TabIndex = 804;
            this.lblKJ.Text = "用途:";
            this.lblKJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboKJ
            // 
            this.cboKJ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKJ.FormattingEnabled = true;
            this.cboKJ.Items.AddRange(new object[] {
            "",
            "治疗用药",
            "预防用药",
            "预防类别"});
            this.cboKJ.Location = new System.Drawing.Point(192, 70);
            this.cboKJ.Name = "cboKJ";
            this.cboKJ.Size = new System.Drawing.Size(79, 22);
            this.cboKJ.TabIndex = 16;
            this.cboKJ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKJ_KeyDown);
            // 
            // cboQK
            // 
            this.cboQK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQK.FormattingEnabled = true;
            this.cboQK.Items.AddRange(new object[] {
            "",
            "I类切口",
            "II类切口",
            "III类切口",
            "其他"});
            this.cboQK.Location = new System.Drawing.Point(336, 70);
            this.cboQK.Name = "cboQK";
            this.cboQK.Size = new System.Drawing.Size(134, 22);
            this.cboQK.TabIndex = 805;
            this.cboQK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboQK_KeyDown);
            // 
            // lblQK
            // 
            this.lblQK.AutoSize = true;
            this.lblQK.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblQK.Location = new System.Drawing.Point(274, 72);
            this.lblQK.Name = "lblQK";
            this.lblQK.Size = new System.Drawing.Size(66, 13);
            this.lblQK.TabIndex = 806;
            this.lblQK.Text = "切口分类:";
            this.lblQK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label9.Location = new System.Drawing.Point(1, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 807;
            this.label9.Text = "疗程天数:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCureDays
            // 
            this.txtCureDays.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCureDays.ForeColor = System.Drawing.Color.Red;
            this.txtCureDays.Location = new System.Drawing.Point(63, 70);
            this.txtCureDays.MaxLength = 6;
            this.txtCureDays.Name = "txtCureDays";
            this.txtCureDays.Size = new System.Drawing.Size(62, 23);
            this.txtCureDays.TabIndex = 808;
            this.txtCureDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCureDays_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label15.Location = new System.Drawing.Point(126, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 809;
            this.label15.Text = "天";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtCheck
            // 
            this.m_txtCheck.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtCheck.Location = new System.Drawing.Point(196, 179);
            this.m_txtCheck.MaxLength = 10;
            this.m_txtCheck.Name = "m_txtCheck";
            this.m_txtCheck.Size = new System.Drawing.Size(60, 23);
            this.m_txtCheck.TabIndex = 11;
            this.m_txtCheck.Visible = false;
            this.m_txtCheck.DoubleClick += new System.EventHandler(this.m_txtCheck_DoubleClick);
            this.m_txtCheck.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtCheck_m_evtSelectItem);
            this.m_txtCheck.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtCheck_m_evtFindItem);
            this.m_txtCheck.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtCheck_m_evtInitListView);
            // 
            // m_txtDoctorList
            // 
            this.m_txtDoctorList.Location = new System.Drawing.Point(527, 152);
            this.m_txtDoctorList.Name = "m_txtDoctorList";
            this.m_txtDoctorList.Size = new System.Drawing.Size(227, 23);
            this.m_txtDoctorList.TabIndex = 16;
            this.m_txtDoctorList.TabStop = false;
            this.m_txtDoctorList.Visible = false;
            this.m_txtDoctorList.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtDoctorList_m_evtSelectItem);
            this.m_txtDoctorList.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtDoctorList_m_evtFindItem);
            this.m_txtDoctorList.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtDoctorList_m_evtInitListView);
            // 
            // m_txtBedNo
            // 
            this.m_txtBedNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBedNo.Location = new System.Drawing.Point(191, 155);
            this.m_txtBedNo.Name = "m_txtBedNo";
            this.m_txtBedNo.Size = new System.Drawing.Size(63, 23);
            this.m_txtBedNo.TabIndex = 2;
            this.m_txtBedNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBedNo_KeyDown);
            this.m_txtBedNo.DoubleClick += new System.EventHandler(this.m_txtBedNo_DoubleClick);
            this.m_txtBedNo.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtBedNo2_m_evtSelectItem);
            this.m_txtBedNo.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtBedNo2_m_evtInitListView);
            // 
            // m_txtArea
            // 
            this.m_txtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtArea.Location = new System.Drawing.Point(47, 155);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(108, 23);
            this.m_txtArea.TabIndex = 1;
            this.m_txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtArea_KeyDown);
            this.m_txtArea.DoubleClick += new System.EventHandler(this.m_txtArea_DoubleClick);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            this.m_txtArea.Leave += new System.EventHandler(this.m_txtArea_Leave);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label21.Location = new System.Drawing.Point(472, 72);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 13);
            this.label21.TabIndex = 810;
            this.label21.Text = "院外代送:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboProxyBoil
            // 
            this.cboProxyBoil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProxyBoil.FormattingEnabled = true;
            this.cboProxyBoil.ItemHeight = 14;
            this.cboProxyBoil.Items.AddRange(new object[] {
            "",
            "代煎代送",
            "中药代送"});
            this.cboProxyBoil.Location = new System.Drawing.Point(536, 70);
            this.cboProxyBoil.Name = "cboProxyBoil";
            this.cboProxyBoil.Size = new System.Drawing.Size(72, 22);
            this.cboProxyBoil.TabIndex = 811;
            this.cboProxyBoil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboProxyBoil_KeyDown);
            // 
            // ctlBIHOrderDetail
            // 
            this.Controls.Add(this.cboProxyBoil);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_txtDosageUnit);
            this.Controls.Add(this.m_txtDosage);
            this.Controls.Add(this.cboKJ);
            this.Controls.Add(this.m_cboRateType);
            this.Controls.Add(this.m_cboExecuteType);
            this.Controls.Add(this.cboQK);
            this.Controls.Add(this.txtCureDays);
            this.Controls.Add(this.m_txtItemTradePrice);
            this.Controls.Add(this.lblQK);
            this.Controls.Add(this.lblKJ);
            this.Controls.Add(this.cboShiying);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_hideDays);
            this.Controls.Add(this.m_hideExecuteFreq);
            this.Controls.Add(this.m_hideDosageUnit);
            this.Controls.Add(this.m_hideDosage);
            this.Controls.Add(this.m_hideDosageType);
            this.Controls.Add(this.m_txtREMARK_VCHR);
            this.Controls.Add(this.m_txtOrderCate);
            this.Controls.Add(this.m_txtCheck);
            this.Controls.Add(this.m_txtSample);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.m_txtGet2);
            this.Controls.Add(this.m_cobOrderCate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_lblDosage);
            this.Controls.Add(this.m_txtGetUnit2);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.m_txtMedicareType);
            this.Controls.Add(this.m_dtFinishTime2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.m_dtStartTime2);
            this.Controls.Add(this.m_txtATTACHTIMES_INT);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.m_txtDoctorList);
            this.Controls.Add(this.m_btnBedList);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.m_txtBedNo);
            this.Controls.Add(this.m_txtArea);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtDosageType);
            this.Controls.Add(this.m_txtOrderName2);
            this.Controls.Add(this.m_lblCheck);
            this.Controls.Add(this.m_picInfo);
            this.Controls.Add(this.m_lblDosageType);
            this.Controls.Add(this.m_dtStartTime);
            this.Controls.Add(this.m_lblSample);
            this.Controls.Add(this.m_txtEntrust);
            this.Controls.Add(this.m_lblxmclsa);
            this.Controls.Add(this.m_chkIsMedicare);
            this.Controls.Add(this.m_dtFinishTime);
            this.Controls.Add(this.m_txbFinishTime);
            this.Controls.Add(this.m_TxbStartTime);
            this.Controls.Add(this.m_txtDoctor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtExecuteFreq);
            this.Controls.Add(this.m_txtOrderName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_txtFatherOrder);
            this.Controls.Add(this.m_txtISNEEDFEEL);
            this.Controls.Add(this.m_lblSaveConOrderFreqID);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.m_cboRepare);
            this.Controls.Add(this.m_txtInputDate);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.m_txtPrice);
            this.Controls.Add(this.m_txtGetUnit);
            this.Controls.Add(this.m_txtGet);
            this.Controls.Add(this.m_txtPackage);
            this.Controls.Add(this.m_txtUse);
            this.Controls.Add(this.m_txtUseUnit);
            this.Controls.Add(this.m_txtRecipeNo);
            this.Controls.Add(this.m_chkIsRepare);
            this.Controls.Add(this.m_txtOrderSpec);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_lblExecuteFreq);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_chkIsRich);
            this.Controls.Add(this.m_lblSaveOrderID);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_chkISNEEDFEEL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txtDays);
            this.Controls.Add(this.m_lblDay);
            this.Controls.Add(this.m_lblBackground);
            this.Controls.Add(this.m_txtExecDept);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ctlBIHOrderDetail";
            this.Size = new System.Drawing.Size(875, 101);
            this.Load += new System.EventHandler(this.ctlBIHOrderDetail_Load);
            this.Resize += new System.EventHandler(this.ctlBIHOrderDetail_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.m_picInfo)).EndInit();
            this.m_MenuStripSelect.ResumeLayout(false);
            this.m_MenuStripREMARK.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 清空
        /// <summary>
        /// 清空重置输入
        /// </summary>
        public void EmptyInput()
        {
            #region 清空控件
            //医嘱类型:
            if (((frmBIHOrderInput)this.ParentForm).m_strView.Equals("0") || ((frmBIHOrderInput)this.ParentForm).m_strView.Equals("3"))
            {
                m_cboExecuteType.Enabled = true;
            }
            else
            {
                m_cboExecuteType.Enabled = false;
            }
            //方号
            m_txtRecipeNo.Enabled = true;
            //医嘱类型:
            //			m_cboExecuteType.m_blnFindItem("1");
            //m_cboExecuteType_SelectedIndexChanged(null,null);
            //m_cboExecuteType.Enabled=true;
            //医嘱名称:
            m_txtOrderName.Text = "";
            m_txtOrderName.Tag = "";
            m_txtOrderName.Enabled = true;
            m_txtOrderName.ReadOnly = false;
            m_txtOrderName.Text = "";
            m_txtOrderName.Tag = "";
            m_txtOrderName2.Text = "";
            m_txtOrderName2.Tag = "";
            m_txtOrderName2.Enabled = true;
            m_lblSaveOrderID.Tag = "";
            //医保相关
            this.m_chkIsMedicare.Checked = false;
            this.m_lblxmclsa.Text = "";
            this.m_lblxmclsa.Visible = false;
            //编组方号:
            //m_txtRecipeNo.Text="";
            //执行频率
            m_txtExecuteFreq.Tag = "";
            m_txtExecuteFreq.Text = "";
            m_txtExecuteFreq.Enabled = true;
            m_txtExecuteFreq.ReadOnly = false;
            //给药方式
            m_txtDosageType.Tag = "";
            m_txtDosageType.Text = "";
            m_txtDosageType.Enabled = true;
            m_txtDosageType.ReadOnly = false;
            //药品规格:
            m_txtOrderSpec.Text = "";
            //包装
            m_txtPackage.Text = "";
            m_txtPackage.Tag = 0;
            //住院单价
            m_txtPrice.Text = "";
            m_txtPrice.Tag = 1;
            //费用标志:
            m_cboRateType.m_blnFindItem("0");
            m_cboRateType.Enabled = true;
            //出院带药天数
            m_txtDays.Text = "";
            m_txtDays.Enabled = true;
            m_lblDay.Text = "天";
            //m_txtDays.ReadOnly =true;
            //一次剂量:
            m_txtDosage.Text = "";
            m_txtDosageUnit.Text = "";
            m_txtDosage.Enabled = true;
            m_txtDosage.ReadOnly = false;
            //一次用量
            m_txtUse.Text = "";
            m_txtUseUnit.Text = "";
            //一次领量
            m_txtGetUnit.Text = "";
            m_txtGetUnit2.Text = "";
            m_txtGet.Text = "";
            m_txtGet2.Text = "";
            m_txtGet.Enabled = true;
            m_txtGet.ReadOnly = false;
            //贵重		
            m_chkIsRich.Checked = false;
            //补登
            m_chkIsRepare.Checked = false;
            m_cboRepare.SelectedIndex = -1;
            m_cboRepare.Enabled = false;
            //开始时间:停止时间
            m_TxbStartTime.Text = "";
            m_txbFinishTime.Text = "";
            m_dtStartTime.Visible = false;
            m_dtFinishTime.Visible = false;
            m_dtStartTime2.Enabled = true;
            m_dtStartTime2.BackColor = Color.White;
            m_dtStartTime2.ReadOnly = false;
            m_dtFinishTime2.Enabled = true;
            m_dtFinishTime2.BackColor = Color.White;
            m_dtFinishTime2.ReadOnly = false;
            //皮试
            m_chkISNEEDFEEL.Checked = false;
            m_chkISNEEDFEEL.Enabled = true;
            m_txtISNEEDFEEL.Text = "";
            m_chkISNEEDFEEL.Tag = null;		//保存药品医嘱类型ID
            m_txtISNEEDFEEL.Enabled = false;
            //医生嘱托:
            m_txtEntrust.Text = "";
            m_txtEntrust.Enabled = true;
            //录入时间
            m_txtInputDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            //医生
            m_txtDoctor.Tag = "";
            m_txtDoctor.Text = "";
            m_txtDoctor.Enabled = true;
            m_txtDoctorList.Tag = "";
            m_txtDoctorList.Text = "";
            m_txtDoctorList.Enabled = true;
            m_txtDoctorList.ReadOnly = false;
            m_txtDoctorList.BackColor = Color.White;
            //父级医嘱
            m_txtFatherOrder.Text = "";
            m_txtFatherOrder.Tag = "";
            //图标
            m_picInfo.Tag = "";
            m_txtExecDept.Tag = "";
            m_txtExecDept.Text = "";
            //说明
            m_txtREMARK_VCHR.Text = "";
            m_txtREMARK_VCHR.Enabled = true;
            m_txtREMARK_VCHR.BackColor = Color.White;
            // 检验值检查控件初始化
            m_txtSample.Visible = false;
            m_lblSample.Visible = false;
            m_lblCheck.Visible = false;
            m_txtCheck.Visible = false;
            m_lblDosageType.Visible = true;
            m_txtDosageType.Visible = true;
            m_txtCheck.Text = "";
            m_txtCheck.Tag = "";
            m_txtSample.Text = "";
            m_txtSample.Tag = "";
            //用量，用法，频率的遮盖初始化
            m_hideDosage.Visible = false;
            m_hideDosageUnit.Visible = false;
            m_hideDosageType.Visible = false;
            m_hideExecuteFreq.Visible = false;
            this.cboShiying.SelectedIndex = 0;

            #region 抗菌药用途
            this.cboKJ.SelectedIndex = 0;
            this.cboKJ.Enabled = false;
            this.cboQK.SelectedIndex = 0;
            this.cboQK.Enabled = false;
            #endregion

            // 预发药
            this.txtCureDays.Text = string.Empty;
            this.txtCureDays.Enabled = false;

            // 外送代煎
            this.cboProxyBoil.SelectedIndex = 0;
            this.cboProxyBoil.Enabled = false;

            #endregion
        }
        #endregion
        #region ListViewTextBox输入[医嘱名称、执行频率、给药方式、父级医嘱、录入医生]
        #region 医嘱名称
        private void m_txtOrderName_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Width = 690;
            lvwList.Height = 160;
            lvwList.HeaderStyle = ColumnHeaderStyle.Clickable;
            lvwList.SmallImageList = this.m_imgIcons;
            //添加列头
            lvwList.Columns.Add("编    码", 80, HorizontalAlignment.Center);
            lvwList.Columns.Add("名    称", 240, HorizontalAlignment.Left);
            lvwList.Columns.Add("规    格", 150, HorizontalAlignment.Left);
            lvwList.Columns.Add("包    装", 120, HorizontalAlignment.Left);
            lvwList.Columns.Add("住院单价", 80, HorizontalAlignment.Right);
        }

        private void m_txtOrderName_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            //医嘱类型
            string m_strORDERCATEID_CHR = "";
            m_strORDERCATEID_CHR = (string)m_txtOrderCate.Tag;
            //文字医嘱则取所有
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[m_strORDERCATEID_CHR];
            if (p_objItem != null && p_objItem.m_intAUTOSHOW_INT == 1)
            {

            }
            else if (strFindCode.Trim().Equals(""))
            {
                return;
            }

            if (strFindCode.Trim().StartsWith(@"/"))
            {
                //常用项目
                m_lngCommonItems(strFindCode.TrimStart(@"/".ToCharArray()));

            }
            else if (strFindCode.Trim().StartsWith(@"\"))
            {
                //组套
                m_lngGroupItems(strFindCode.TrimStart(@"\".ToCharArray()));

            }
            else if (strFindCode.Trim().StartsWith(@"?"))
            {
                //新价表
                m_lngNewPriceItems(strFindCode.TrimStart(@"?".ToCharArray()));

                /*<======================================*/
            }
            else //一般项目查询
            {
                m_lngNormalItems(strFindCode.Trim());

            }
        }

        /// <summary>
        /// 诊疗项目列表窗体
        /// </summary>
        /// <param name="arrDic"></param>
        public void m_OrderDicListView(clsBIHOrderDic[] arrDic, DataSet m_dsDicChargeSet)
        {
            ArrayList m_arlItems = new ArrayList();
            int m_intClass = ((frmBIHOrderInput)this.ParentForm).seachClass.SelectedIndex;
            //医嘱类型
            string m_strORDERCATEID_CHR = "";
            m_strORDERCATEID_CHR = (string)m_txtOrderCate.Tag;

            if (arrDic.Length > 0)
            {
                for (int i = 0; i < arrDic.Length; i++)
                {
                    string strDicCode = arrDic[i].m_strUserCode;
                    switch (m_intClass)
                    {
                        case -1:
                            strDicCode = arrDic[i].m_strPYCode;
                            break;
                        case 0:
                            strDicCode = arrDic[i].m_strPYCode;
                            break;
                        case 1:
                            strDicCode = arrDic[i].m_strWBCode;
                            break;
                        case 2:
                            strDicCode = arrDic[i].m_strName;
                            break;
                        case 3:
                            strDicCode = arrDic[i].m_strUserCode;
                            break;
                    }
                    //用户编码
                    ListViewItem objItem = new ListViewItem((i + 1).ToString(), c_intItem_Order);
                    objItem.SubItems.Add(arrDic[i].m_strUserCode);
                    //objItem.SubItems.Add(arrDic[i].m_strUserCode);
                    objItem.SubItems.Add(strDicCode);
                    //项目名称(商用名）
                    objItem.SubItems.Add(arrDic[i].m_strName);
                    //项目名称(药品常用名称)
                    objItem.SubItems.Add(arrDic[i].m_strITEMCOMMNAME_VCHR);
                    //项目规格
                    objItem.SubItems.Add(arrDic[i].m_strSpec);
                    //包装
                    //objItem.SubItems.Add(arrDic[i].m_StrPackage);
                    //住院单价
                    //objItem.SubItems.Add(arrDic[i].m_dmlPrice.ToString("0.0000"));
                    //单位
                    //objItem.SubItems.Add(arrDic[i].m_strDosageUnit);
                    //药库提示
                    if (arrDic[i].m_intITEMSRCTYPE_INT == 1 && arrDic[i].m_intIPNOQTYFLAG_INT == 1)
                    {
                        objItem.SubItems.Add("缺药");
                        objItem.ForeColor = Color.Red;
                    }
                    else
                    {
                        //医保项目->绿色
                        if (arrDic[i].m_strYBTypeID.Trim() != "")
                        {
                            objItem.SubItems.Add("医保类");
                            objItem.ForeColor = Color.Green;
                        }
                        else
                        {
                            objItem.SubItems.Add("");
                        }
                    }
                    //剂型
                    objItem.SubItems.Add(arrDic[i].m_strMEDICINEPREPTYPENAME_VCHR);

                    objItem.Tag = arrDic[i];
                    m_arlItems.Add(objItem);
                }
            }
            ListViewItem[] arrItem = new ListViewItem[0];
            if (m_arlItems.Count > 0)
            {
                arrItem = (ListViewItem[])(m_arlItems.ToArray(typeof(ListViewItem)));
            }
            //lvwList.Visible = false;
            frmChargeList m_frmCList = new frmChargeList(this.m_txtOrderName.Text, m_strORDERCATEID_CHR, ((frmBIHOrderInput)this.ParentForm).m_blLessMedControl, m_intClass, ((frmBIHOrderInput)this.ParentForm).m_htOrderCate, ((frmBIHOrderInput)this.ParentForm).m_blStopControl, ((frmBIHOrderInput)this.ParentForm).m_blDeableMedControl);
            m_frmCList.m_strMedDeptId = ((frmBIHOrderInput)this.ParentForm).m_strMedDeptGross;
            m_frmCList.strPayType = ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strPayTypeID;
            if (m_intClass == 3)
            {
                m_frmCList.m_lvwList.Columns[1].Width = 0;
            }
            m_frmCList.arrItem = arrItem;
            if (m_dsDicChargeSet != null && m_dsDicChargeSet.Tables.Count > 0)
            {
                m_frmCList.m_dsDicChargeSet = m_dsDicChargeSet;
            }
            m_frmCList.WindowState = FormWindowState.Maximized;
            DialogResult result = m_frmCList.ShowDialog(this);
            try
            {

                if (result == DialogResult.OK)
                {
                    //记录药品库存量
                    this.m_fotOpcurrentgross_num = m_frmCList.m_dmlOpcurrentgross_num;
                    //记录录药品标致 1为药品 2为材料
                    this.m_intITEMSRCTYPE_INT = m_frmCList.m_intITEMSRCTYPE_INT;
                    m_frmCList.Hide();
                    m_txtOrderName_m_evtSelectItem(null, m_frmCList.m_lviSItem);

                }
                else if (result == DialogResult.Yes)//批生成医嘱
                {
                    m_frmCList.Hide();
                    this.Cursor = Cursors.WaitCursor;
                    for (int i = 0; i < m_frmCList.m_lviSItemArr.Length; i++)
                    {
                        clsBIHOrderDic m_objOrderDic = (clsBIHOrderDic)(m_frmCList.m_lviSItemArr[i].Tag);
                        clsBIHOrder objOrder = m_objGetOrderByOrderDic(((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient, m_objOrderDic);
                        //记录药品库存量
                        this.m_fotOpcurrentgross_num = m_frmCList.m_dmlOpcurrentgross_num;
                        //记录录药品标致 1为药品 2为材料
                        this.m_intITEMSRCTYPE_INT = m_frmCList.m_intITEMSRCTYPE_INT;
                        objOrder.m_intCHARGE_INT = -1;//特殊处理
                        if (IsSubOrder == true)//子医嘱操作
                        {
                            //新增医嘱（在新增状态下，新增子医嘱）
                            ((frmBIHOrderInput)this.ParentForm).m_objDomain.lngAddNewSubOrder(ref objOrder);
                        }
                        else
                        {
                            //新增医嘱（在新增状态下，新增非子医嘱）
                            ((frmBIHOrderInput)this.ParentForm).m_objDomain.lngAddNewNOSubOrder(ref objOrder);
                        }
                    }
                    this.Cursor = Cursors.Default;
                    ((frmBIHOrderInput)this.ParentForm).cmdRefurbish_Click(null, null);

                }
                else
                {
                    m_frmCList.Hide();
                    return;
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void m_txtOrderName_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            m_blSampleItem = false;
            m_blCheckItem = false;
            /*<===================================*/
            if (lviSelected != null)
            {
                if (lviSelected.Tag == null) return;

                if (lviSelected.Tag is clsBIHOrderDic)
                {
                    clsBIHOrderDic m_objDicItem = (clsBIHOrderDic)lviSelected.Tag;
                    if (!m_htMEDICINEPREPTYPE.ContainsKey(m_objDicItem.m_strOrderDicID))
                    {
                        m_htMEDICINEPREPTYPE.Add(m_objDicItem.m_strOrderDicID, m_objDicItem.m_strMEDICINEPREPTYPENAME_VCHR);
                    }
                    m_mthShowOrderDic(m_objDicItem);
                    // 界面控制逻辑(医嘱类型逻辑)
                    ExecuteType_SelectedIndexChanged();
                }
            }

            RateTypeOldIndex = m_cboRateType.SelectedIndex;
            setTheControlOrder("m_txtOrderName");
        }

        /// <summary>
        /// 医嘱界面诊疗项目界面控制
        /// </summary>
        /// <param name="m_objDicItem"></param>
        public void OrderCateViewControl(clsBIHOrderDic m_objDicItem)
        {
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[m_objDicItem.m_strOrderCateID];
            OrdercateLogic(p_objItem);

            if (m_objDicItem.m_intCheckTypeID != -1 && m_objDicItem.m_strCheckType.Trim().Length > 0 && m_objDicItem.m_intDELETED == 0)
            {
                m_blCheckItem = true;
            }
            else
            {
                m_blCheckItem = false;
            }
            //新价类检查控制逻辑--检验申请单元逻辑
            if (!m_objDicItem.m_strLISAPPLYUNITID_CHR.Trim().Equals("") && m_objDicItem.m_strOrderCateID.Trim().Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strORDERCATEID_LIS_CHR.Trim()))
            {
                m_blSampleItem = true;
            }
            else
            {
                m_blSampleItem = false;
            }
            if (((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strCONFREQID_CHR.Trim().Equals(m_objDicItem.m_strFREQID_CHR))
            {
                m_txtDosageControl(false);
                m_txtDosageTypeControl(false);

            }
            //中药服数显示(即天数控件的控制显示，共用字段)
            if (p_objItem.m_strORDERCATEID_CHR.Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strMID_MEDICINE_CHR))
            {
                m_txtMid_MedicineControl(true);
            }
            /*<============================================*/
            //-------------------------->中西药用法控制
            this.m_intMEDICNETYPE_INT = m_objDicItem.m_intMEDICNETYPE_INT;
            /*<===================================*/
            //药品信息窗体提示
            if (((frmBIHOrderInput)this.ParentForm).IsShowCodexRemarkFrm)
            {
                string Remark = m_objDicItem.m_strMedcineREMARK;
                if (!Remark.Equals(""))
                {
                    int ShowCodexRemarkFrmTimerinterval = ((frmBIHOrderInput)this.ParentForm).ShowCodexRemarkFrmTimerinterval;
                    frmCodexRemark frmRemark = new frmCodexRemark(Remark, ShowCodexRemarkFrmTimerinterval);
                    frmRemark.StartPosition = FormStartPosition.CenterScreen;
                    frmRemark.Show();
                }
            }
            // 检验控制
            setTheSampleBox();
            // 检查控制
            setTheCheckBox();
        }

        private void SubChangeControl()
        {
            if (this.IsSubOrder)
            {
                if (this.ParentOrder != null)
                {
                    // 频率
                    m_txtExecuteFreq.Tag = ParentOrder.m_strExecFreqID;
                    m_txtExecuteFreq.Text = ParentOrder.m_strExecFreqName;

                    m_txtDosageType.Text = ParentOrder.m_strDosetypeName;
                    m_txtDosageType.Tag = ParentOrder.m_strDosetypeID;

                    m_txtExecuteFreq.Enabled = false;
                    m_txtExecuteFreq.ReadOnly = true;
                    m_txtDosageType.Enabled = false;
                    m_txtDosageType.ReadOnly = true;

                    m_txtDays.Text = ParentOrder.m_intOUTGETMEDDAYS_INT.ToString();
                }
            }
        }
        /// <summary>
        /// 检验控制  TRUE：显示检验输入，FALSE：隐藏输入
        /// </summary>
        public void setTheSampleBox()
        {
            if (m_blSampleItem)
            {
                //m_txtSample_m_evtFindItem(null, "", new ListView());
                m_lblDosageType.Visible = false;
                m_txtDosageType.Visible = false;
                m_lblCheck.Visible = false;
                m_txtCheck.Visible = false;
                m_lblSample.Location = m_lblDosageType.Location;
                m_txtSample.Location = m_txtDosageType.Location;
                m_hideDosageType.Visible = false;
                m_lblSample.Visible = true;
                m_txtSample.Visible = true;
            }
            else
            {

                m_lblSample.Visible = false;
                m_txtSample.Visible = false;

            }
        }

        /// <summary>
        /// 检查控制  TRUE：显示检验输入，FALSE：隐藏输入
        /// </summary>
        public void setTheCheckBox()
        {
            if (m_blCheckItem)
            {
                //m_txtCheck_m_evtFindItem(null, "", new ListView());
                m_lblDosageType.Visible = false;
                m_txtDosageType.Visible = false;
                m_lblSample.Visible = false;
                m_txtSample.Visible = false;
                m_lblCheck.Location = m_lblDosageType.Location;
                m_txtCheck.Location = m_txtDosageType.Location;
                m_hideDosageType.Visible = false;
                m_lblCheck.Visible = true;
                m_txtCheck.Visible = true;

            }
            else
            {

                m_lblCheck.Visible = false;
                m_txtCheck.Visible = false;

            }
            if (!m_blCheckItem && !m_blSampleItem)
            {
                m_lblDosageType.Visible = true;
                m_txtDosageType.Visible = true;
            }
        }

        /// <summary>
        /// 显示诊疗项目信息
        ///		业务说明：
        ///			1、选择是转区、出院则只能是临时医嘱；
        /// </summary>
        /// <param name="objDic"></param>
        private void m_mthShowOrderDic(clsBIHOrderDic objDic)
        {
            if (objDic == null) return;
            m_blnCurrentItemIsGroup = false;
            m_objCurrentDic = objDic;
            //频率VO,用法VO
            clsAIDRecipeFreq m_objTempFreq = GetFreqVoByFreqID(objDic.m_strFREQID_CHR);
            clsBSEUsageType m_objUsage = GetUsageVoByUsageID(objDic.m_strUsageID_chr);
            /*<============================*/
            // 频率
            if (!IsSubOrder)
            {
                m_txtExecuteFreq.Tag = m_objTempFreq.m_strFreqID;
                m_txtExecuteFreq.Text = m_objTempFreq.m_strFreqName;
                //默认给药方试
                m_txtDosageType.Tag = m_objUsage.m_strUsageID;
                m_txtDosageType.Text = m_objUsage.m_strUsageName;
            }
            /*<====================*/

            // 剂量
            if (objDic.m_intITEMSRCTYPE_INT == 1)//如果是药(不是药的情况下,就保存原业值不变)
            {
                if (m_intAge >= 12)
                {
                    m_txtDosage.Text = objDic.m_decADULTDOSAGE_DEC.ToString();
                }
                else
                {
                    m_txtDosage.Text = objDic.m_decCHILDDOSAGE_DEC.ToString();
                }

            }
            else
            {
                m_txtDosage.Text = objDic.m_dmlDosageRate.ToString();
            }
            //隐"0"值
            if (m_txtDosage.Text.ToString().Trim().Equals("0"))
            {
                m_txtDosage.Text = "";
            }
            /*<========================*/
            m_picInfo.Tag = objDic.m_strOrderCateID;//医嘱类型ID
            m_txtOrderName2.Tag = objDic.m_strOrderDicID;
            m_txtOrderName.Text = objDic.m_strName;
            m_txtOrderName.Tag = objDic;
            /*<=======================================*/
            m_txtOrderSpec.Text = objDic.m_strSpec;//项目规格			
            m_txtPackage.Text = objDic.m_dmlPACKQTY_DEC.ToString();//包装量   //objDic.m_StrPackage;//包装=[剂量 剂量单位 / 住院单位]
            m_txtPackage.Tag = objDic.m_intIPCHARGEFLG_INT;//住院收费单位 0 －基本单位 1－最小单位
            m_txtPrice.Text = clsConverter.ToString(objDic.m_dmlPrice);//住院单价
            m_txtPrice.Tag = objDic.m_dmlDosageRate;//剂量
            m_txtItemTradePrice.Text = clsConverter.ToString(objDic.m_dmlTradePrice);//住院批发单价 
            m_txtDosageUnit.Text = objDic.m_strDosageUnit.Trim();
            if (objDic.m_intITEMSRCTYPE_INT == 1)//如果是药
            {
                if (objDic.m_intIPCHARGEFLG_INT == 1)
                {
                    m_txtUseUnit.Text = objDic.m_strUseUnit.Trim();
                    m_txtGetUnit.Text = objDic.m_strUseUnit.Trim();
                    m_txtGetUnit2.Text = objDic.m_strUseUnit.Trim();
                }
                else
                {
                    m_txtUseUnit.Text = objDic.m_strITEMOPUNIT_CHR;
                    m_txtGetUnit.Text = objDic.m_strITEMOPUNIT_CHR;
                    m_txtGetUnit2.Text = objDic.m_strITEMOPUNIT_CHR;
                }
            }
            else
            {
                m_txtUseUnit.Text = objDic.m_strITEMUNIT_CHR;
                m_txtGetUnit.Text = objDic.m_strITEMUNIT_CHR;
                m_txtGetUnit2.Text = objDic.m_strITEMUNIT_CHR;
            }
            m_chkIsRich.Checked = (objDic.m_intIsRich == 1);
            m_txtExecDept.Text = objDic.m_strExecDept;	//名称无用,不显示则不取
            m_txtExecDept.Tag = objDic.m_strExecDept;
            // 添加检验样品到控件
            m_txtSample.Tag = objDic.m_strSAMPLEID_VCHR.ToString().Trim();
            m_txtSample.Text = objDic.m_strSAMPLE_NAME.ToString().Trim();
            /*<==============================================*/
            //  添加检查部位到控件
            m_txtCheck.Tag = objDic.m_strPARTID_VCHR.ToString().Trim();
            m_txtCheck.Text = objDic.m_strPART_NAME.ToString().Trim();
            /*<==============================================*/
            // 添加医保信息
            m_txtMedicareType.Text = objDic.m_strMedicareTypeName.ToString().Trim();
            m_txtMedicareType.Tag = objDic.m_strMedicareTypeID.ToString().Trim();
            /*<=========================================*/
            if (objDic.m_intHYPE_INT == 1)
            {
                m_chkISNEEDFEEL.Checked = true;
            }
            else
            {
                m_chkISNEEDFEEL.Checked = false;
            }
            /*<================================*/

            #region 抗菌药、预发药、中药饮片
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            if (svc.IsAutiMed(objDic.m_strChargeItemID))
            {
                this.cboKJ.Enabled = true;
                this.cboQK.Enabled = true;
            }
            else
            {
                this.cboKJ.Enabled = false;
                this.cboQK.Enabled = false;
            }

            // 药品.针剂
            if (svc.IsMedInjection(objDic.m_strChargeItemID, 2) && m_cboExecuteType.Text.Contains("长期"))
            {
                this.txtCureDays.Enabled = true;
                this.txtCureDays.BackColor = Color.White;
            }
            else
            {
                this.txtCureDays.Enabled = false;
                this.txtCureDays.BackColor = this.label9.BackColor;
            }

            // 中药.饮片
            if (svc.IsMedPieces(objDic.m_strChargeItemID))
            {
                this.cboProxyBoil.Enabled = true;
                this.cboProxyBoil.SelectedIndex = (m_cboExecuteType.Text.Contains("带药") ? 0 : 1);
            }
            else
            {
                this.cboProxyBoil.Enabled = false;
                this.cboProxyBoil.SelectedIndex = 0;
            }

            svc = null;
            #endregion

            m_mthRefreshTipInfo();
        }
        /// <summary>
        /// 显示组套信息
        /// </summary>
        /// <param name="objGroup"></param>
        private void m_mthShowOrderGroup(clsBIHOrderGroup objGroup)
        {
            if (objGroup == null) return;
            m_blnCurrentItemIsGroup = true;
            m_objCurrentGroup = objGroup;

            m_txtOrderName.Tag = objGroup;
            m_txtOrderName.Text = objGroup.m_strName;
            m_txtOrderSpec.Text = objGroup.m_strDes;
            m_mthRefreshTipInfo();
            m_txtExecuteFreq.Focus();
        }
        #endregion
        #region 执行频率
        private void m_txtExecuteFreq_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Clear();
            ColumnHeader ch1 = lvwList.Columns.Add("No", 60, HorizontalAlignment.Left);
            ColumnHeader ch2 = lvwList.Columns.Add("Name", 100, HorizontalAlignment.Left);
            lvwList.Width = 180;
        }
        private void m_txtExecuteFreq_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            // 获取临时医嘱类型ID 
            clsAIDRecipeFreq[] arrFreq;
            m_lngGetRecipeFreq(strFindCode, out arrFreq);
            long ret = 1;
            string m_strOldFreq = "";
            if (m_txtExecuteFreq.Tag != null)
            {
                m_strOldFreq = m_txtExecuteFreq.Tag.ToString().Trim();
            }
            if ((ret > 0) && (arrFreq != null) && (arrFreq.Length > 0))
            {
                string m_strCONFREQID_CHR = ((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strCONFREQID_CHR.Trim();
                for (int i = 0; i < arrFreq.Length; i++)
                {
                    //诊疗默认带出的是连续性频率,如果不是将过滤掉这连续性用法
                    if (m_strOldFreq.Equals(m_strCONFREQID_CHR))
                    {
                    }
                    else if (arrFreq[i].m_strFreqID.Trim().Equals(m_strCONFREQID_CHR))
                    {
                        continue;
                    }
                    /*<===================*/
                    ListViewItem lvi = lvwList.Items.Add(arrFreq[i].m_strUserCode);
                    lvi.SubItems.Add(arrFreq[i].m_strFreqName);
                    lvi.Tag = arrFreq[i];

                    //检查是否已经有选好的	{Text和Vlue都对}
                    if (m_txtExecuteFreq.Tag != null && m_txtExecuteFreq.Tag.ToString() != null)
                    {
                        if (m_txtExecuteFreq.Text.Trim() == arrFreq[i].m_strFreqName.Trim() && m_txtExecuteFreq.Tag.ToString().Trim() == arrFreq[i].m_strFreqID.Trim())
                        {
                            lvwList.Items.Clear();
                            lvi = lvwList.Items.Add(arrFreq[i].m_strUserCode);
                            lvi.SubItems.Add(arrFreq[i].m_strFreqName);
                            lvi.Tag = arrFreq[i];
                            //焦点转移
                            m_txtDosageType.Focus();
                            return;
                        }
                    }
                }
                m_txtExecuteFreq.Tag = null;
            }
            else
            {
                MessageBox.Show("没有找到对应的执行频率，请输入其它的查询条件", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtExecuteFreq.Tag = "";
                m_txtExecuteFreq.SelectAll();
                m_txtExecuteFreq.Focus();
            }
        }



        private void m_txtExecuteFreq_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null && lviSelected.Tag is clsAIDRecipeFreq)
            {
                //临时医嘱时，频率必须为once
                if (m_cboExecuteType.SelectedIndex == 0)//不是临嘱
                {
                    m_objTempFreq = lviSelected.Tag as clsAIDRecipeFreq;//备用.				

                    //连续性医嘱
                    //DisplayDateTimePicker(m_objTempFreq.m_strFreqID,0);
                    m_txtExecuteFreq.Text = m_objTempFreq.m_strFreqName;
                    m_txtExecuteFreq.Tag = m_objTempFreq.m_strFreqID;
                    // 长期医嘱执行时间
                    m_txtEntrust.Text = m_objTempFreq.m_strLExecTime;
                }
                else
                {
                    //出院带药的临时医嘱,则频率可以编辑,否则频率就是once且不可以编辑;
                    m_txtExecuteFreq.Text = lviSelected.SubItems[1].Text;
                    m_txtExecuteFreq.Tag = (lviSelected.Tag as clsAIDRecipeFreq).m_strFreqID;
                    m_objTempFreq = lviSelected.Tag as clsAIDRecipeFreq;//备用.
                    // 临时医嘱执行时间
                    m_txtEntrust.Text = m_objTempFreq.m_strTExecTime;

                }
                setTheControlOrder("m_txtExecuteFreq");
            }
        }

        /// <summary>
        /// 设置执行频率为Once
        /// </summary>
        private void m_mthSetOnceFreq()
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            //获取临时医嘱类型ID
            string strTemOrderRecipefreqID = new clsDcl_ExecuteOrder().m_strGetTemOrderRecipefreqID();
            if (m_objOnceFreq == null)
            {
                long ret = m_objService.m_lngGetRecipeFreqByID(strTemOrderRecipefreqID, out m_objOnceFreq);
            }
            if (m_objOnceFreq == null) return;
            m_txtExecuteFreq.Text = m_objOnceFreq.m_strFreqName;
            m_txtExecuteFreq.Tag = m_objOnceFreq.m_strFreqID;
            m_objTempFreq = m_objOnceFreq;

            //频率改变,更新领量数据
            if (m_txtUse.Text.Trim() != "")
            {
                decimal dmlUse = clsConverter.ToDecimal(m_txtUse.Text);
                decimal dmlGet = m_dmlComputeGet(dmlUse);
                m_txtGet.Text = clsConverter.ToString(dmlGet);
            }
        }
        #endregion
        #region 给药方式
        private void m_txtDosageType_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBSEUsageType[] arrType;
            m_lngGetUsageType(strFindCode, out arrType, this.m_intMEDICNETYPE_INT);
            long ret = 1;
            if ((ret > 0) && (arrType != null) && (arrType.Length > 0))
            {
                for (int i = 0; i < arrType.Length; i++)
                {
                    ListViewItem lvi = lvwList.Items.Add(arrType[i].m_strUserCode);
                    lvi.SubItems.Add(arrType[i].m_strUsageName);
                    lvi.Tag = arrType[i];
                    //检查是否已经有选好的	{Text和Vlue都对}
                    #region
                    if (m_txtDosageType.Tag != null && m_txtDosageType.Tag.ToString() != null)
                    {
                        if (m_txtDosageType.Text.Trim() == arrType[i].m_strUsageName.Trim() && m_txtDosageType.Tag.ToString().Trim() == arrType[i].m_strUsageID.Trim())
                        {
                            lvwList.Items.Clear();
                            lvi = lvwList.Items.Add(arrType[i].m_strUserCode);
                            lvi.SubItems.Add(arrType[i].m_strUsageName);
                            lvi.Tag = arrType[i];
                            //m_cboRateType.Focus();
                            return;
                        }
                    }
                    #endregion
                }
                m_txtDosageType.Tag = null;
            }
            else
            {
                MessageBox.Show("没有找到对应的给药方式，请输入其它的查询条件", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //m_txtDosageType.Tag ="";
                //m_txtDosageType.SelectAll();
                //m_txtDosageType.Focus();
            }
        }

        /// <summary>
        /// 获取经过过滤的用法VO数组
        /// </summary>
        /// <param name="strFindCode"></param>
        /// <param name="arrType"></param>
        /// <param name="p"></param>
        public void m_lngGetUsageType(string strFindCode, out clsBSEUsageType[] arrType, int MEDICNETYPE_INT)
        {
            arrType = null;
            if (m_arrUsage == null)
            {
                //clsBIHOrderService m_objService = clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
                clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                long lngRes = m_objService.m_lngGetUsageType("", out  m_arrUsage);
            }
            ArrayList UsageType = new ArrayList();
            bool m_blCan = false;
            bool m_blScope = false;
            for (int i = 0; i < m_arrUsage.Length; i++)
            {
                m_blCan = false;
                m_blScope = false;
                switch (MEDICNETYPE_INT)
                {
                    case 1:
                        if (m_arrUsage[i].m_intSCOPE_INT == 0 || m_arrUsage[i].m_intSCOPE_INT == 1)
                        {
                            m_blScope = true;
                        }
                        break;
                    case 2:
                        if (m_arrUsage[i].m_intSCOPE_INT == 0 || m_arrUsage[i].m_intSCOPE_INT == 2)
                        {
                            m_blScope = true;
                        }
                        break;
                    default:
                        m_blScope = true;
                        break;
                }
                if (m_blScope == false)
                {
                    continue;
                }
                if (m_arrUsage[i].m_strUserCode.ToUpper().Contains(strFindCode.Trim().ToUpper()) || m_arrUsage[i].m_strUsageName.ToUpper().Contains(strFindCode.Trim().ToUpper()) || m_arrUsage[i].m_strPYCODE_VCHR.ToUpper().Contains(strFindCode.Trim().ToUpper()) || m_arrUsage[i].m_strWBCODE_VCHR.ToUpper().Contains(strFindCode.Trim().ToUpper()))
                {
                    m_blCan = true;
                }
                if (m_blCan == true)
                {
                    UsageType.Add(m_arrUsage[i]);
                }
            }
            if (UsageType.Count > 0)
            {
                arrType = (clsBSEUsageType[])(UsageType.ToArray(typeof(clsBSEUsageType)));

            }

        }

        /// <summary>
        /// 获取经过过滤的频率VO数组
        /// </summary>
        /// <param name="strFindCode"></param>
        /// <param name="arrFreq"></param>
        public void m_lngGetRecipeFreq(string strFindCode, out clsAIDRecipeFreq[] arrFreq)
        {
            arrFreq = null;
            if (m_arrFreq == null)
            {
                //clsBIHOrderService m_objService = clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
                clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                m_objService.m_lngGetRecipeFreq("", out m_arrFreq);
            }
            ArrayList FreqType = new ArrayList();
            bool m_blCan = false;
            for (int i = 0; i < m_arrFreq.Length; i++)
            {
                m_blCan = false;

                if (m_arrFreq[i].m_strUserCode.ToUpper().Contains(strFindCode.Trim().ToUpper()) || m_arrFreq[i].m_strFreqName.ToUpper().Contains(strFindCode.Trim().ToUpper()))
                {
                    m_blCan = true;
                }
                if (m_blCan == true)
                {
                    FreqType.Add(m_arrFreq[i]);
                }
            }
            if (FreqType.Count > 0)
            {
                arrFreq = (clsAIDRecipeFreq[])(FreqType.ToArray(typeof(clsAIDRecipeFreq)));

            }

        }

        private void m_txtDosageType_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Clear();
            ColumnHeader ch1 = lvwList.Columns.Add("No", 50, HorizontalAlignment.Left);
            ColumnHeader ch2 = lvwList.Columns.Add("Name", 160, HorizontalAlignment.Left);
            lvwList.Width = 230;
        }

        private void m_txtDosageType_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_txtDosageType.Text = lviSelected.SubItems[1].Text;
                m_txtDosageType.Tag = (lviSelected.Tag as clsBSEUsageType).m_strUsageID;

                /*=================>*/
                setTheControlOrder("m_txtDosageType");
                /*<============================*/
            }

        }
        private void m_txtDosageType_EnabledChanged(object sender, System.EventArgs e)
        {
            if (m_txtDosageType.Enabled)
                m_txtDosageType.BackColor = Color.White;
            else
                m_txtDosageType.BackColor = SystemColors.Control;
        }
        #endregion
        #region 父级医嘱
        private void m_txtFatherOrder_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Width = 455;
            lvwList.Height = 150;
            lvwList.HeaderStyle = ColumnHeaderStyle.Clickable;
            lvwList.SmallImageList = this.m_imgIcons;
            //添加列头
            lvwList.Columns.Add("  方号", 80, HorizontalAlignment.Left);
            lvwList.Columns.Add("    类型", 120, HorizontalAlignment.Left);
            lvwList.Columns.Add("    医嘱名称", 120, HorizontalAlignment.Left);
            lvwList.Columns.Add("    用法", 150, HorizontalAlignment.Left);
            lvwList.Columns.Add("    执行频率", 100, HorizontalAlignment.Left);
        }

        private void m_txtFatherOrder_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            //组套禁止多层嵌套:如果一条医嘱已属于其他医嘱的子医嘱,则不能设为父医嘱.(在选择父医嘱列表框中不显示)
            lvwList.Items.Clear();
            if (m_strPatientID_Chr == string.Empty || m_strRegisterID == string.Empty) return;
            clsBIHOrder[] arrOrder;
            long ret = m_objService.m_lngGetOrderByPatient(m_strRegisterID, m_strPatientID_Chr, out arrOrder);
            if ((ret > 0) && (arrOrder != null) && (arrOrder.Length > 0))
            {
                ListViewItem objItem;
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    if (arrOrder[i].m_intStatus == 0 || arrOrder[i].m_intStatus == 7)//只有新建状态的医嘱才能设置为子医嘱
                    {
                        objItem = new ListViewItem(arrOrder[i].m_intRecipenNo.ToString());//方号
                        if (arrOrder[i].m_intExecuteType == 1)//类型
                            objItem.SubItems.Add("长期医嘱");
                        else if (arrOrder[i].m_intExecuteType == 2)
                            objItem.SubItems.Add("临时医嘱");
                        else
                            objItem.SubItems.Add("");
                        objItem.SubItems.Add(arrOrder[i].m_strName);//医嘱名称
                        objItem.SubItems.Add(arrOrder[i].m_strDosetypeName);//用法
                        objItem.SubItems.Add(arrOrder[i].m_strExecFreqName);//执行频率
                        objItem.Tag = arrOrder[i];
                        lvwList.Items.Add(objItem);
                    }
                }
            }
            else
            {
                //如果没有值则，报告没有查到，否则调转焦点
                if (m_txtFatherOrder.Tag == null || m_txtFatherOrder.Tag.ToString() == "")
                {
                    MessageBox.Show("没有医嘱可供设为父级医嘱！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_txtDoctor.Focus();
                }
                else
                {
                    m_txtDoctor.Focus();
                }
            }
        }

        private void m_txtFatherOrder_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                if (lviSelected.Tag == null) return;
                clsBIHOrder objBIHOrder = new clsBIHOrder();
                try
                {
                    objBIHOrder = lviSelected.Tag as clsBIHOrder;
                }
                catch
                { }
                if (objBIHOrder != null)
                {
                    if (m_lblSaveOrderID.Tag.ToString().Trim() != objBIHOrder.m_strOrderID.Trim())
                    {
                        m_txtFatherOrder.Text = objBIHOrder.m_strName;
                        m_txtFatherOrder.Tag = objBIHOrder.m_strOrderID;
                        //父子医嘱默认同方号	{以父为准}
                        try
                        {
                            m_txtRecipeNo.Text = objBIHOrder.m_intRecipenNo.ToString();
                        }
                        catch { }
                    }
                    else
                    {
                        MessageBox.Show("不能设置自己为父级医嘱！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            m_txtDoctor.Focus();
        }
        #endregion
        #region 录入医生
        private void m_txtDoctor_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            clsBIHDoctor[] arrDoctor;
            long ret = m_objService.m_lngFindDoctor(strFindCode, out arrDoctor);
            if ((ret > 0) && (arrDoctor != null) && (arrDoctor.Length > 0))
            {
                for (int i = 0; i < arrDoctor.Length; i++)
                {
                    ListViewItem lvi = lvwList.Items.Add(arrDoctor[i].m_strDoctorNo);
                    lvi.SubItems.Add(arrDoctor[i].m_strDoctorName);
                    lvi.Tag = arrDoctor[i];
                }
            }
            else
            {
                //如果没有值则，报告没有查到，否则调转焦点
                if (m_txtDoctor.Tag == null || m_txtDoctor.Tag.ToString() == "")
                {
                    MessageBox.Show("没有找到对应的录入医生，请输入其它的查询条件!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_txtDoctor.SelectAll();
                }
                else
                {
                    m_mthEndInput();
                }
            }
        }

        private void m_txtDoctor_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            m_txtDoctor.Text = lviSelected.SubItems[1].Text;
            m_txtDoctor.Tag = (lviSelected.Tag as clsBIHDoctor).m_strDoctorID;
            m_mthEndInput();
        }

        private void m_txtDoctor_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Clear();
            ColumnHeader ch1 = lvwList.Columns.Add("No", 60, HorizontalAlignment.Left);
            ColumnHeader ch2 = lvwList.Columns.Add("Name", 60, HorizontalAlignment.Left);
            lvwList.Width = 140;
        }

        /// <summary>
        /// 设置医生
        /// </summary>
        /// <param name="strDoctorID"></param>
        /// <param name="strDoctorName"></param>
        public void m_mthSetDoctor(string strDoctorID, string strDoctorName)
        {
            m_txtDoctor.Text = strDoctorName;
            m_txtDoctor.Tag = strDoctorID;
            m_objCurrentDoctor = new clsBIHDoctor();
            m_objCurrentDoctor.m_strDoctorID = strDoctorID;
            m_objCurrentDoctor.m_strDoctorName = strDoctorName;


        }

        /// <summary>
        /// 医生是否可以编辑
        /// </summary>
        public bool DoctorEditable
        {
            get
            {
                return m_txtDoctor.ReadOnly;
            }
            set
            {
                //m_txtDoctor.ReadOnly=value;
                m_txtDoctor.ReadOnly = true;//屏蔽 {需求变更}
            }
        }
        #endregion
        #endregion
        #region 事件
        #region Load

        //1066 医嘱录入时默认录医嘱者为管床医生
        /// <summary>
        /// 1066 医嘱录入时默认录医嘱者为管床医生 true 管床医生 false 当前登录人
        /// </summary>
        private bool blnInputIsDoctor = false;

        private void ctlBIHOrderDetail_Load(object sender, System.EventArgs e)
        {
            if (DesignMode) return;
            m_cboExecuteType.m_intAddItem("1", "1-长期", "1");
            m_cboExecuteType.m_intAddItem("2", "2-临时", "2");
            m_cboExecuteType.m_intAddItem("3", "3-带药", "3");
            m_cboExecuteType.SelectedIndex = 0;
            //补登:{1=计费-摆药;2=计费-不摆药;3=不计费-摆药;4=不计费-不摆药};只用于临时医嘱
            m_cboRepare.Items.Add("摆药");
            m_cboRepare.Items.Add("不摆药");
            m_cboRepare.SelectedIndex = -1;
            SetComboBoxRepare();
            m_cboRepare.Enabled = false;
            //m_objHighlight.m_mthBindForm(this);
            #region 当前界面控件输入的背景色控制
            Color m_BackColor = Color.FromArgb(222, 239, 165);
            ctlCtl_HighLightFocus highLight = new ctlCtl_HighLightFocus(m_BackColor);
            highLight.m_mthAddControlInContainer(this);
            #endregion

            blnInputIsDoctor = (clsPublic.m_intGetSysParm("1066") == 1 ? true : false);
        }
        /// <summary>
        /// 设置费用类别
        /// 业务说明：长嘱没有出院带药，临嘱有出院带药；
        /// </summary>
        private void SetComboBoxRepare()
        {
            m_cboRateType.Items.Clear();
            /*
            m_cboRateType.m_intAddItem("0","正常","0");
            m_cboRateType.m_intAddItem("1","自备","1");
            m_cboRateType.m_intAddItem("2","嘱托","2");
            m_cboRateType.m_intAddItem("3","基数药","3");
            if(m_cboExecuteType.SelectedIndex==1)//临时
            {
                m_cboRateType.m_intAddItem("4","出院带药","4");
            }
             */
            m_cboRateType.m_intAddItem("0", "药房", "1");
            m_cboRateType.m_intAddItem("1", "患者自备", "2");
            m_cboRateType.m_intAddItem("2", "科室基数", "3");

            m_cboRateType.SelectedIndex = 0;
        }
        #endregion
        #region Resize
        private void ctlBIHOrderDetail_Resize(object sender, System.EventArgs e)
        {
            m_lblBackground.Location = new Point(0, 0);
            m_lblBackground.Size = new Size(this.Width - 1, this.Height - 1);
        }
        #endregion
        #region 剂量
        private void m_txtDosage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 剂量必须大于0
                double dbl1 = -1;
                if (m_txtDosage.Text.Trim() != "")
                {
                    try
                    {
                        dbl1 = double.Parse(m_txtDosage.Text.Trim());
                    }
                    catch { }
                }
                if (dbl1 <= 0)
                {
                    //MessageBox.Show("必须大于0！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //m_txtDosage.Focus();
                    //m_txtDosage.SelectAll();
                    m_txtDosage.Focus();
                    return;
                }
                #endregion
                AutoFillData();
                //if(m_txtGet.Enabled && m_txtGet.Visible)
                //    m_txtGet.Focus();
                //else if(m_chkIsRepare.Enabled && m_chkIsRepare.Visible)
                //    m_chkIsRepare.Focus();
                //else if(m_chkISNEEDFEEL.Enabled && m_chkISNEEDFEEL.Visible)
                //    m_chkISNEEDFEEL.Focus();
                //else if(m_dtStartTime.Enabled && m_dtStartTime.Visible)
                //    m_dtStartTime.Focus();
                //else if(m_dtFinishTime.Enabled && m_dtFinishTime.Visible)
                //    m_dtFinishTime.Focus();
                //else if(m_txtDoctor.Enabled && m_txtDoctor.Visible)
                //    m_txtDoctor.Focus();
                //else
                //    m_mthEndInput();
            }

            if (e.KeyCode == Keys.Enter)
            {

                /*=================>*/
                setTheControlOrder(((TextBox)sender).Name);
                /*<============================*/
            }

        }


        private int AutoFillPZData()
        {
            int intDays = 1;		 //天数-出院带药
            decimal dmlDosage = -1;//医生下的剂量[一次剂量]
            decimal dmlUse = -1;	 //用量
            decimal dmlGet = -1;	 //领量
            decimal dmlUnitDosage = -1;//剂量 [收费项目表中的剂量“DOSAGE_DEC”]
            bool m_blIsType;

            try { dmlDosage = decimal.Parse(m_txtDosage.Text); }
            catch { }
            try { dmlUnitDosage = decimal.Parse(m_txtPrice.Tag.ToString()); }
            catch { }

            intDays = 1;
            if (dmlDosage < 0 || dmlUnitDosage <= 0) { ; return 1; }
            string strFreqID = "";
            if (m_txtExecuteFreq.Tag != null)
                strFreqID = m_txtExecuteFreq.Tag.ToString();
            if (strFreqID == string.Empty) return -1;
            long lngRes = 1;

            m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
            if (m_objTempFreq == null) return -1;
            if (((frmBIHOrderInput)this.ParentForm).m_intTypePControl == 0)
            {
                dmlGet = (dmlDosage * m_objTempFreq.m_intTimes * intDays) / dmlUnitDosage;	//  领量＝(用量*次数*天数/包装量)
            }
            else
            {

                dmlGet = decimal.Ceiling(dmlDosage / dmlUnitDosage) * m_objTempFreq.m_intTimes * intDays;	//  领量＝(用量*次数*天数/包装量)
            }
            //取整
            dmlGet = decimal.Ceiling(dmlGet);

            if (dmlGet < 0) { ; return -1; }

            m_txtGet.Text = Convert.ToString(dmlGet);
            return 1;

        }

        /// <summary>
        /// 出院带药总数合计
        /// </summary>
        public void AutoFillData2()
        {
            int intDays = 1;		 //天数-出院带药
            decimal dmlGet = 1;
            if (m_txtDays.Enabled == true && m_txtDays.ReadOnly == false)
            {
                try
                {
                    intDays = int.Parse(m_txtDays.Text.Trim());
                }
                catch
                {
                }
                try
                {
                    dmlGet = int.Parse(m_txtGet.Text.Trim());
                }
                catch
                {
                }
                m_txtGet2.Text = Convert.ToString(dmlGet * intDays) + m_txtGetUnit.Text;
            }
            else
            {
                m_txtGet2.Text = "";
            }

        }
        #endregion
        #region 用量
        //用量不能更改
        private void m_txtUse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //				if(m_txtUse.Text.Trim()=="") return;
                //				decimal dmlUse=decimal.Parse(m_txtUse.Text);
                //				decimal dmlGet=m_dmlComputeGet(dmlUse);
                //				if(dmlGet<0)
                //					m_txtGet.Text =clsConverter.ToString(dmlGet);
                //				else
                //					m_txtGet.Text ="";
                //				e.Handled=true;
                m_txtGet.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                m_txtDosage.Focus();
            }
        }
        private void m_txtUse_Leave(object sender, System.EventArgs e)
        {
            //			if(m_txtUse.Text.Trim()=="") return;
            //			decimal dmlUse=decimal.Parse(m_txtUse.Text);
            //			decimal dmlGet=m_dmlComputeGet(dmlUse);
            //			if(dmlGet<0)
            //				m_txtGet.Text =clsConverter.ToString(dmlGet);
            //			else
            //				m_txtGet.Text ="";
        }
        #endregion
        #region 领量
        /// <summary>
        /// 领量输入完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtGet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double db1 = double.Parse(m_txtGet.Text.ToString().Trim());
                    if (db1 <= 0)
                    {
                        m_txtGet.Focus();
                        return;
                    }
                }
                catch
                {
                    m_txtGet.Focus();
                    return;
                }


            }

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((TextBox)sender).Name);
                /*<============================*/
            }
        }
        #endregion
        #region 费用标志
        private void m_cboRateType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if((e.KeyCode==Keys.Enter)||(e.KeyCode==Keys.Right))
            //{
            //    //费用标志：{0、"";1、自备;2、嘱托;3、基数药;4、出院带药;}
            //    if(m_cboRateType.SelectedIndex==4)
            //        m_txtDays.Focus();
            //    else if(m_txtDosage.Enabled && m_txtDosage.Visible)
            //        m_txtDosage.Focus();
            //    else if(m_txtGet.Enabled && m_txtGet.Visible)
            //        m_txtGet.Focus();
            //    else if(m_chkIsRepare.Enabled && m_chkIsRepare.Visible)
            //        m_chkIsRepare.Focus();
            //    else if(m_chkISNEEDFEEL.Enabled && m_chkISNEEDFEEL.Visible)
            //        m_chkISNEEDFEEL.Focus();
            //    else if(m_dtStartTime.Enabled && m_dtStartTime.Visible)
            //        m_dtStartTime.Focus();
            //    else if(m_dtFinishTime.Enabled && m_dtFinishTime.Visible)
            //        m_dtFinishTime.Focus();
            //    else if(m_txtDoctor.Enabled && m_txtDoctor.Visible)
            //        m_txtDoctor.Focus();
            //    else
            //        m_mthEndInput();
            //}
            //else if(e.KeyCode==Keys.Left)
            //{
            //    m_txtDosageType.Focus();
            //}
            //else
            //{
            //    m_cboRateType.Focus();
            //}
            if (e.KeyCode == Keys.Enter)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((com.digitalwave.controls.ctlQComboBox)sender).Name);
                /*<============================*/
            }
        }

        int RateTypeOldIndex = -1;
        private void m_cboRateType_Leave(object sender, System.EventArgs e)
        {
            //if (m_cboRateType.SelectedIndex != RateTypeOldIndex)
            //{
            //    if (MessageBox.Show("确实要更改当前费用标志吗？", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        m_cboRateType.SelectedIndex = RateTypeOldIndex;
            //        m_cboRateType.Focus();
            //        return;
            //    }
            //}
        }
        private void m_cboRateType_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            //m_cboRateType_Leave(sender,e);
        }
        private void m_txtDays_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (m_txtDays.Enabled))
            {
                try
                {
                    int i1 = int.Parse(m_txtDays.Text.ToString().Trim());
                }
                catch
                {
                    m_txtDays.Focus();
                    return;
                }
                AutoFillData2();
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((TextBox)sender).Name);
                /*<============================*/
            }
            /*
			if(e.KeyCode==Keys.Enter && (!m_txtDays.ReadOnly))
			{
				AutoFillData();
				if(m_txtDosage.Enabled && m_txtDosage.Visible)
					m_txtDosage.Focus();
				else if(m_txtGet.Enabled && m_txtGet.Visible)
					m_txtGet.Focus();
				else if(m_chkIsRepare.Enabled && m_chkIsRepare.Visible)
					m_chkIsRepare.Focus();
				else if(m_chkISNEEDFEEL.Enabled && m_chkISNEEDFEEL.Visible)
					m_chkISNEEDFEEL.Focus();
				else if(m_dtStartTime.Enabled && m_dtStartTime.Visible)
					m_dtStartTime.Focus();
				else if(m_dtFinishTime.Enabled && m_dtFinishTime.Visible)
					m_dtFinishTime.Focus();
				else if(m_txtDoctor.Enabled && m_txtDoctor.Visible)
					m_txtDoctor.Focus();
				else
					m_mthEndInput();
			}
			else if(e.KeyCode==Keys.Left)
			{
				m_cboRateType.Focus();
			}
             */
        }
        private void m_txtDays_Leave(object sender, System.EventArgs e)
        {
            if (m_txtDays.Enabled)
            {
                AutoFillData2();
            }
        }
        #endregion
        #region 医嘱类型
        private void m_cboExecuteType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((com.digitalwave.controls.ctlQComboBox)sender).Name);
                /*<============================*/
            }
            else if (e.KeyCode == Keys.Space)
            {
                //EmptyInput();
                if (((frmBIHOrderInput)this.ParentForm).m_dtvOrder.SelectedRows.Count > 0)
                {
                    clsBIHOrder order = (clsBIHOrder)((frmBIHOrderInput)this.ParentForm).m_dtvOrder.SelectedRows[0].Tag;
                    //医嘱类型
                    clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[((clsBIHOrder)((frmBIHOrderInput)this.ParentForm).GetTheFaterOrder(order.m_intRecipenNo)).m_strOrderDicCateID];
                    if (p_objItem != null && p_objItem.m_intSAMEORDER_INT == 2)
                    {
                        MessageBox.Show("不能为当前方号进行子医嘱操作!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (order.m_intStatus != 0 && order.m_intStatus != 7)
                    {

                        MessageBox.Show("不能为当前方号进行子医嘱操作!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (!order.m_strCreatorID.Equals(((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID))
                    {
                        MessageBox.Show("不能为别人的医嘱进行子医嘱操作!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        return;
                    }
                    else if (order.m_intSOURCETYPE_INT != ((frmBIHOrderInput)this.ParentForm).m_intSOURCETYPE_INT)
                    {
                        MessageBox.Show("医嘱录入类别界面不同的医嘱不能进行子医嘱操作!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    m_txtRecipeNo.Text = ((clsBIHOrder)((frmBIHOrderInput)this.ParentForm).m_dtvOrder.SelectedRows[0].Tag).m_intRecipenNo.ToString().Trim();
                    //m_objCurrentOrder = null;//将当前医嘱初始化，已进行新增子医嘱的操作
                    m_txtRecipeNo.Focus();
                    SendKeys.Send("{Enter}");
                }


            }

        }
        /// <summary>
        /// 控制跳动
        /// </summary>
        /// <param name="m_strName">控件名</param>
        public void setTheControlOrder(string m_strName)
        {
            switch (m_strName)
            {
                case "m_cboExecuteType":
                    if (m_txtOrderCate.Enabled)
                    {
                        m_txtOrderCate.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtOrderCate.Name);
                    }
                    break;
                case "m_txtOrderCate":
                    if (m_txtRecipeNo.Enabled)
                    {
                        m_txtRecipeNo.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtRecipeNo.Name);
                    }
                    break;
                case "m_txtRecipeNo":
                    if (m_txtOrderName.Enabled)
                    {
                        m_txtOrderName.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtOrderName.Name);
                    }
                    break;
                case "m_txtOrderName":
                    if (m_txtOrderName2.Enabled && m_txtOrderName2.ReadOnly)
                    {
                        m_txtOrderName2.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtOrderName2.Name);
                    }
                    break;
                case "m_txtOrderName2":
                    if (m_txtDosage.Enabled)
                    {
                        m_txtDosage.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtDosage.Name);
                    }
                    break;
                case "m_txtDosage":
                    if (m_txtDosageType.Enabled && m_txtDosageType.Visible)
                    {
                        m_txtDosageType.Focus();
                    }
                    else
                    {
                        if (m_txtCheck.Enabled && m_txtCheck.Visible)
                        {
                            m_txtCheck.Focus();
                        }
                        if (m_txtSample.Enabled && m_txtSample.Visible)
                        {
                            m_txtSample.Focus();
                        }
                        else
                        {
                            setTheControlOrder(m_txtDosageType.Name);
                        }
                    }
                    break;
                case "m_txtDosageType":
                    if (m_txtExecuteFreq.Enabled)
                    {
                        m_txtExecuteFreq.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtExecuteFreq.Name);
                    }
                    break;
                case "m_txtExecuteFreq":
                    if (m_txtDays.Enabled)
                    {
                        m_txtDays.Focus();
                    }
                    if (m_cboRateType.Enabled)
                    {
                        m_cboRateType.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_cboRateType.Name);
                    }
                    break;
                case "m_txtGet":
                    if (m_txtDays.Enabled)
                    {
                        m_txtDays.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtDays.Name);
                    }
                    break;
                case "m_txtDays":
                    if (m_cboRateType.Enabled)
                    {
                        m_cboRateType.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_cboRateType.Name);
                    }
                    break;
                case "m_txtATTACHTIMES_INT":
                    if (m_txtDoctorList.Enabled)
                    {
                        m_txtDoctorList.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtDoctorList.Name);
                    }
                    break;
                case "m_txtDoctorList":
                    m_mthEndInput();
                    break;
                case "m_cboRateType":
                    if (cboShiying.Enabled)
                    {
                        this.cboShiying.Focus();
                    }
                    else
                    {
                        setTheControlOrder(cboShiying.Name);
                    }

                    break;
                case "cboShiying":
                    if (m_txtREMARK_VCHR.Enabled)
                    {
                        this.m_txtREMARK_VCHR.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtREMARK_VCHR.Name);
                    }

                    break;
                case "m_txtREMARK_VCHR":
                    if (this.txtCureDays.Enabled)
                        this.txtCureDays.Focus();
                    else if (this.cboKJ.Enabled)
                        this.cboKJ.Focus();
                    else if (this.cboProxyBoil.Enabled)
                        this.cboProxyBoil.Focus();
                    else
                        m_mthEndInput();
                    break;
                case "m_dtStartTime2":
                    if (m_txtDoctorList.Enabled)
                    {
                        m_txtDoctorList.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtDoctorList.Name);
                    }
                    break;
                case "m_txtSample":
                    if (m_txtExecuteFreq.Enabled)
                    {
                        m_txtExecuteFreq.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtExecuteFreq.Name);
                    }
                    break;
                case "m_txtCheck":
                    if (m_txtExecuteFreq.Enabled)
                    {
                        m_txtExecuteFreq.Focus();
                    }
                    else
                    {
                        setTheControlOrder(m_txtExecuteFreq.Name);
                    }
                    break;
                case "txtCureDays":
                    if (cboKJ.Enabled)
                        cboKJ.Focus();
                    else if (cboProxyBoil.Enabled)
                        cboProxyBoil.Focus();
                    else
                        m_mthEndInput();
                    break;
                case "end":
                    m_mthEndInput();
                    break;
                case "cboKJ":
                    if (cboKJ.SelectedIndex == 2)   // 预防
                        cboQK.Focus();
                    else if (cboProxyBoil.Enabled)
                        cboProxyBoil.Focus();
                    else
                        m_mthEndInput();
                    break;
                case "cboQK":
                    m_mthEndInput();
                    break;
                case "cboProxyBoil":
                    m_mthEndInput();
                    break;
                default:
                    m_mthEndInput();
                    break;
            }
        }

        /// <summary>
        /// 医嘱录入方式界面控制
        /// 业务说明：
        ///	if(长期医嘱-1) then 是否补登不可用
        /// </summary>
        public void m_cboExecuteType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ExecuteType_SelectedIndexChanged();
        }

        public void ExecuteType_SelectedIndexChanged()
        {
            int m_intExecuteType = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));

            //中药特殊显示出天数/服控件
            if (IsSubOrder == true && ParentOrder != null)
            {
                clsT_aid_bih_ordercate_VO p_objItem;
                p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[ParentOrder.m_strOrderDicCateID];
                //中药服数显示(即天数控件的控制显示，共用字段)
                if (p_objItem.m_strORDERCATEID_CHR.Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strMID_MEDICINE_CHR))
                {
                    m_intExecuteType = 3;
                }
                /*<============================================*/
            }
            /*<====================================*/

            m_cboExecuteTypeChanged(m_intExecuteType);
            // 医嘱类型界面控制
            if (this.m_txtOrderName.Tag != null && this.m_txtOrderName.Tag is clsBIHOrderDic)
            {
                clsBIHOrderDic objDic = (clsBIHOrderDic)this.m_txtOrderName.Tag;
                OrderCateViewControl(objDic);
            }
        }

        /// <summary>
        /// 医嘱录入方式界面控制
        /// </summary>
        public void m_cboExecuteTypeChanged(int m_intExecuteType)
        {

            /*长期医嘱:禁用天数.补次数量默认为1. 
         临时医嘱:禁用天数,补次,开始时间,停止时间.补次数量默认为0. 
         出院带药:禁用补次,开始时间,停止时间.补次数量默认为0*/

            //switch (clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex)))
            switch (m_intExecuteType)
            {
                case 1:
                    //m_txtATTACHTIMES_INT.Text = "1"; //补次                 
                    m_txtATTACHTIMES_INT.Enabled = true;
                    m_txtDays.Enabled = false;
                    m_dtStartTime2.Enabled = true;
                    m_dtStartTime2.BackColor = Color.White;
                    m_dtFinishTime2.Enabled = true;
                    m_dtFinishTime2.BackColor = Color.White;
                    //频率 
                    m_txtExecuteFreqControl(true);
                    // 显示／隐藏天数控件
                    m_txtDays.Visible = false;
                    m_txtDays.Enabled = false;
                    m_lblDay.Visible = false;
                    m_txtGet2.Visible = false;

                    break;

                case 2:
                    m_txtATTACHTIMES_INT.Text = "0"; //补次
                    m_txtATTACHTIMES_INT.Enabled = false;
                    m_dtStartTime2.Enabled = false;
                    m_dtStartTime2.BackColor = SystemColors.Control;
                    m_dtFinishTime2.Enabled = false;
                    m_dtFinishTime2.BackColor = SystemColors.Control;
                    //频率
                    //m_txtExecuteFreq.Enabled = false;
                    //m_txtExecuteFreq.BackColor = SystemColors.Control;
                    // 显示／隐藏天数控件
                    m_txtDays.Visible = false;
                    m_txtDays.Enabled = false;
                    m_lblDay.Visible = false;
                    m_txtGet2.Visible = false;
                    m_txtDays.Enabled = false;

                    break;
                case 3:
                    m_txtATTACHTIMES_INT.Text = "0"; //补次
                    m_txtATTACHTIMES_INT.Enabled = false;
                    m_dtStartTime2.Enabled = false;
                    m_dtStartTime2.BackColor = SystemColors.Control;
                    m_dtFinishTime2.Enabled = false;
                    m_dtFinishTime2.BackColor = SystemColors.Control;
                    //频率 
                    m_txtExecuteFreqControl(true);
                    // 显示／隐藏天数控件
                    m_txtDays.Visible = true;
                    m_txtDays.Enabled = true;
                    m_lblDay.Visible = true;
                    m_txtGet2.Visible = true;
                    m_txtDays.Enabled = true;
                    break;
            }
        }

        #endregion
        #region 医生嘱托
        private void m_txtEntrust_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((TextBox)sender).Name);
                /*<============================*/
            }
        }
        #endregion
        #region 是否补登
        private void m_chkIsRepare_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if((e.KeyCode==Keys.Enter)||(e.KeyCode==Keys.Right))
            //{
            //    if(m_chkIsRepare.Checked)
            //    {
            //        m_cboRepare.Focus();
            //        m_cboRepare.DroppedDown =true;
            //    }
            //    else if(m_chkISNEEDFEEL.Enabled && m_chkISNEEDFEEL.Visible)
            //        m_chkISNEEDFEEL.Focus();
            //    else if(m_dtStartTime.Enabled && m_dtStartTime.Visible)
            //        m_dtStartTime.Focus();
            //    else if(m_dtFinishTime.Enabled && m_dtFinishTime.Visible)
            //        m_dtFinishTime.Focus();
            //    else if(m_txtDoctor.Enabled && m_txtDoctor.Visible)
            //        m_txtDoctor.Focus();
            //    else
            //        m_mthEndInput();
            //}
            //else if(e.KeyCode==Keys.Left)
            //{
            //    m_txtGet.Focus();
            //}
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((CheckBox)sender).Name);
                /*<============================*/
            }
        }
        private void m_chkIsRepare_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_cboExecuteType.SelectedIndex == 0)//长期医嘱
            {
                if (m_chkIsRepare.Checked) m_chkIsRepare.Checked = false;
                m_cboRepare.SelectedIndex = -1;
                m_chkIsRepare.Enabled = false;
                m_cboRepare.Enabled = false;
                return;
            }
            if (m_chkIsRepare.Checked)
            {
                m_cboRepare.Enabled = true;
                if (m_cboRepare.Items.Count > 0) m_cboRepare.SelectedIndex = 0;
            }
            else
            {
                m_cboRepare.SelectedIndex = -1;
                m_cboRepare.Enabled = false;
            }
        }
        private void m_cboRepare_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if((e.KeyCode==Keys.Enter)||(e.KeyCode==Keys.Right))
            //{
            //    if(m_chkISNEEDFEEL.Enabled && m_chkISNEEDFEEL.Visible)
            //        m_chkISNEEDFEEL.Focus();
            //    else if(m_dtStartTime.Enabled && m_dtStartTime.Visible)
            //        m_dtStartTime.Focus();
            //    else if(m_dtFinishTime.Enabled && m_dtFinishTime.Visible)
            //        m_dtFinishTime.Focus();
            //    else if(m_txtDoctor.Enabled && m_txtDoctor.Visible)
            //        m_txtDoctor.Focus();
            //    else
            //        m_mthEndInput();

            //}
            //else if(e.KeyCode==Keys.Left)
            //{
            //    m_cboRepare.Focus();
            //}
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((com.digitalwave.controls.ctlQComboBox)sender).Name);
                /*<============================*/
            }
        }
        #endregion
        #region 是否皮试
        private void m_chkISNEEDFEEL_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if((e.KeyCode==Keys.Enter)||(e.KeyCode==Keys.Right))
            //{	
            //    if(m_txtDoctor.Enabled && m_txtDoctor.Visible)
            //        m_txtDoctor.Focus();
            //    else
            //        m_mthEndInput();
            //}
            //else if(e.KeyCode==Keys.Left)
            //{
            //    if(m_chkIsRepare.Enabled)
            //        m_chkIsRepare.Focus();
            //    else if(m_txtDoctor.Enabled && m_txtDoctor.Visible)
            //        m_txtDoctor.Focus();
            //    else
            //        m_mthEndInput();
            //}
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((CheckBox)sender).Name);
                /*<============================*/
            }
        }
        private void m_txtISNEEDFEEL_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if((e.KeyCode==Keys.Enter)||(e.KeyCode==Keys.Right))
            //{
            //    if(m_txtDoctor.Enabled && m_txtDoctor.Visible)
            //        m_txtDoctor.Focus();
            //    else
            //        m_mthEndInput();
            //}
            //else if(e.KeyCode==Keys.Left)
            //{
            //    m_chkISNEEDFEEL.Focus();
            //}
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                /*=================>*/
                setTheControlOrder(((TextBox)sender).Name);
                /*<============================*/
            }
        }
        #endregion
        #region 是否贵重
        private void m_chkIsRich_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Right))
            {
                m_chkISNEEDFEEL.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                m_chkIsRepare.Focus();
            }
        }
        private void m_chkIsRich_CheckedChanged(object sender, System.EventArgs e)
        {
            /** @update by xzf (05-09-20) */
            if (m_chkIsRich.Checked)
            {
                //@m_chkIsRich.BackColor =SystemColors.Highlight;
                //@m_chkIsRich.ForeColor =SystemColors.HighlightText;
                m_chkIsRich.BackColor = SystemColors.Desktop;
            }
            else
            {
                m_chkIsRich.BackColor = SystemColors.Control;
            }
            /* <<=============================================== */
        }
        #endregion
        #region 停止时间
        private void m_dtFinishTime_Leave(object sender, System.EventArgs e)
        {
            if (m_lblSaveConOrderFreqID.Tag == null)
                m_lblSaveConOrderFreqID.Tag = new clsDcl_ExecuteOrder().m_strGetConfreqID();
            if (m_lblSaveConOrderFreqID.Tag.ToString().Trim() == m_txtExecuteFreq.Tag.ToString())
            {
                if (m_dtFinishTime.Value < m_dtStartTime.Value)
                {
                    m_dtFinishTime.Value = (System.DateTime.Now > m_dtStartTime.Value) ? (System.DateTime.Now) : (m_dtStartTime.Value);
                    m_dtFinishTime.Refresh();
                    MessageBox.Show("停止时间必须大于起始时间！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        #endregion
        #region 下嘱医生
        private void m_txtDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthEndInput();
        }

        private void m_txtDoctor_Enter(object sender, System.EventArgs e)
        {
            if (!m_txtDoctor.Enabled)
            {
                m_mthEndInput();
            }
        }
        #endregion
        #endregion
        #region 刷新附加单据信息
        /// <summary>
        /// 刷新附加单据信息
        /// </summary>
        private void m_mthRefreshTipInfo()
        {
            string strCateID = clsConverter.ToString(m_picInfo.Tag);

            string strInfo = "";
            if (strCateID == "")
            {
                strInfo = "";
            }
            else
            {
                clsBIHOrderCate objCate = clsOrderDicCates.m_objGetCate(strCateID);
                if (objCate.IsMedicineCate || objCate.m_intISATTACH_INT == 0)//如果为药或没有附加单据则不显示图标
                    strInfo = "";
                else
                    strInfo = "附加单据:" + objCate.m_strName;
            }
            this.toolTip1.SetToolTip(this.m_picInfo, strInfo);

            if (strInfo.Trim() == "")
            {
                timer1.Enabled = false;
                m_picInfo.Visible = false;
            }
            else
            {
                m_intCount = 0;
                m_picInfo.Visible = true;
                timer1.Enabled = true;
            }
        }

        private void m_picInfo_MouseEnter(object sender, System.EventArgs e)
        {
            toolTip1.Active = true;
        }

        private int m_intCount = 0;
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            m_picInfo.Visible = !(m_picInfo.Visible);
            m_intCount++;
            if ((m_intCount > 3) && (m_picInfo.Visible)) timer1.Enabled = false;
        }

        #endregion
        #region 剂量, 用量,领量
        #region 获取用量
        /// <summary>
        /// 获取用量	根据医生下的剂量和剂量单位 [失败返回-1]
        /// </summary>
        /// <param name="dmlDosage">医生下的剂量</param>
        /// <param name="dmlUnitDosage">剂量单位</param>
        /// <returns>用量 [失败返回-1]</returns>
        private decimal dmlComputeUse(decimal dmlDosage, decimal dmlUnitDosage)
        {
            decimal dmlUse = -1;
            try { dmlUse = dmlDosage / dmlUnitDosage; }
            catch { }
            return dmlUse;
        }
        #endregion
        #region 获取单位频率天数的领量
        /// <summary>
        /// 获取单位频率天数的领量	根据用量，没有考虑出院带药.[不能计算则返回-1]
        /// </summary>
        /// <param name="dmlUse">用量</param>
        /// <param name="strFreqID">频率ID</param>
        /// <returns>返回领量,如果计算错误则返回-1;</returns>
        /// <remarks>
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如:用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        private decimal m_dmlComputeGet(decimal dmlUse, string strFreqID)
        {

            decimal dmlGet = dmlUse;
            if (strFreqID == string.Empty) return -1;
            long lngRes = 1;
            //if(m_objTempFreq==null || m_objTempFreq.m_strFreqID.Trim()!=strFreqID.Trim())
            //{
            //    lngRes =m_objService.m_lngGetRecipeFreqByID(strFreqID,out m_objTempFreq);	//获取当前频率信息			
            //}

            m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
            if (m_objTempFreq == null) return -1;
            dmlGet = dmlUse * m_objTempFreq.m_intTimes;	//用量*次数

            //取整
            dmlGet = Decimal.Negate(decimal.Floor(decimal.Negate(dmlGet)));
            return dmlGet;
        }
        /// <summary>
        /// 获取单位频率天数的领量	根据用量，没有考虑出院带药.[不能计算则返回-1]
        /// </summary>
        /// <param name="dmlUse">用量</param>
        /// <returns>返回领量,如果计算错误则返回-1;</returns>
        /// <remarks>
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如:用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        private decimal m_dmlComputeGet(decimal dmlUse)
        {
            if (m_txtExecuteFreq.Tag != null)
            {
                string strFreqID = m_txtExecuteFreq.Tag.ToString();
                return m_dmlComputeGet(dmlUse, strFreqID);
            }
            else
                return -1;
        }
        #endregion
        #region 自动计算并填充 [剂量,用量,领量]文本框
        /// <summary>
        /// 自动计算并填充 [剂量,用量,领量]文本框
        /// </summary>
        /// <remarks>
        /// 业务描述:
        ///		if(费用标志="出院带药") then 考虑出院带药;else 不考虑出院带药;
        ///		if(相关费用计算失败) then 保持文本框为空;else 填充相关数据;
        ///		if(不能计算 || 计算失败) then m_txtUse.Text="";m_txtGet.Text="";
        ///		用户输入框,经过整理后要,重新赋值给文本框;(取整等)
        /// </remarks>
        private void AutoFillData()
        {
            int intDays = 1;		 //天数-出院带药
            decimal dmlDosage = -1;//医生下的剂量[一次剂量]
            decimal dmlUse = -1;	 //用量
            decimal dmlGet = -1;	 //领量
            decimal dmlUnitDosage = -1;//剂量 [收费项目表中的剂量“DOSAGE_DEC”]
            bool m_blIsType;
            #region 获取-计算值

            try { dmlDosage = decimal.Parse(m_txtDosage.Text); }
            catch { }
            try { dmlUnitDosage = decimal.Parse(m_txtPrice.Tag.ToString()); }
            catch { }
            if (dmlDosage < 0 || dmlUnitDosage <= 0) { ; return; }
            dmlUse = dmlComputeUse(dmlDosage, dmlUnitDosage);
            if (dmlUse < 0) { ;return; }
            dmlGet = m_dmlComputeGet(dmlUse);
            if (dmlGet < 0) { ; return; }

            #endregion
            #region 赋值给文本控件

            intDays = 1;
            m_txtGet.Text = Convert.ToString(dmlGet * intDays);
            #endregion
        }
        #endregion
        #endregion
        #region 属性
        /// <summary>
        /// 获取医嘱项目是否为组套
        /// </summary>
        public bool CurrentItemIsGroup
        {
            get
            {
                return m_blnCurrentItemIsGroup;
            }
        }
        /// <summary>
        /// 获取或设置是否只读
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return m_blnReadOnly;
            }
            set
            {
                /*
				m_blnReadOnly=value;
				m_txtOrderName.ReadOnly =m_blnReadOnly;
				//m_cboExecuteType.Enabled=(!m_blnReadOnly);
				//				m_txtRecipeNo.ReadOnly=m_blnReadOnly;
				m_txtExecuteFreq.ReadOnly=m_blnReadOnly;				
				m_txtDosageType.ReadOnly=m_blnReadOnly;
				m_txtDosage.ReadOnly=m_blnReadOnly;
				//m_txtUse.ReadOnly=m_blnReadOnly;//用量不能编辑
				m_txtGet.ReadOnly=m_blnReadOnly;				
				m_chkIsRepare.AutoCheck=(!m_blnReadOnly);
				if(m_chkIsRepare.Checked)
					m_cboRepare.Enabled =(!m_blnReadOnly);
				else
					m_cboRepare.Enabled =false;
				m_chkISNEEDFEEL.AutoCheck =(!m_blnReadOnly);
				m_txtEntrust.ReadOnly=m_blnReadOnly;
				m_cboRateType.Enabled=(!m_blnReadOnly);
				if(m_cboRateType.SelectedIndex==4)
					m_txtDays.ReadOnly =m_blnReadOnly;
				else
					m_txtDays.ReadOnly =true;
				m_txtFatherOrder.ReadOnly=m_blnReadOnly;
				DoctorEditable=m_blnReadOnly;
                 */
            }
        }
        /// <summary>
        /// 设置病人ID
        /// </summary>
        public string PatientID
        {
            set { m_strPatientID_Chr = value; }
        }
        /// <summary>
        /// 设置病人入院登记流水号
        /// </summary>
        public string RegisterID
        {
            set { m_strRegisterID = value; }
        }
        #endregion
        #region 方法
        /// <summary>
        /// 显示医嘱内容
        /// </summary>
        /// <param name="objOrder">医嘱记录VO对象</param>
        public void m_mthSetOrder(clsBIHOrder objOrder)
        {
            m_objCurrentOrder = objOrder;
            //EmptyInput();
            if (objOrder != null)
            {
                #region 显示
                RateTypeOldIndex = -1;
                m_txtRecipeNo.Text = objOrder.m_intRecipenNo.ToString();//方号
                //显示的方号要特别处理，如果是临嘱就将方号置为0，如果是长嘱就将方号保持不变
                if (objOrder.m_intExecuteType == 1)
                {
                    m_txtRecipeNo.Tag = objOrder.m_intRecipenNo2;//显示的方号
                }
                else
                {
                    m_txtRecipeNo.Tag = 0;
                }
                m_cboExecuteType.m_blnFindItem(objOrder.m_intExecuteType.ToString().Trim());
                // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
                m_cboRateType.m_blnFindItem(objOrder.RateType.ToString().Trim());
                //病人 
                m_picInfo.Tag = objOrder.m_strOrderDicCateID;
                m_txtOrderName2.Text = objOrder.m_strName;
                m_txtOrderName2.Tag = objOrder.m_strOrderDicID;
                m_txtOrderName.Text = objOrder.m_strName;
                //m_txtOrderName.Tag 用来保存诊疗项目VO 
                m_lblSaveOrderID.Tag = objOrder.m_strOrderID;
                m_txtOrderSpec.Text = objOrder.m_strSpec;
                m_txtDosageUnit.Text = objOrder.m_strDosageUnit;
                m_txtUseUnit.Text = objOrder.m_strUseunit;
                m_txtGetUnit.Text = objOrder.m_strGetunit;
                m_txtGetUnit2.Text = objOrder.m_strGetunit;
                m_txtPackage.Text = objOrder.m_dmlPACKQTY_DEC.ToString();//包装量   //objDic.m_StrPackage;//包装=[剂量 剂量单位 / 住院单位]
                m_txtPackage.Tag = objOrder.m_intIPCHARGEFLG_INT;//住院收费单位 0 －基本单位 1－最小单位

                m_txtExecDept.Tag = objOrder.m_strExecDeptID;
                m_txtExecDept.Text = objOrder.m_strExecDeptID;

                m_chkIsRich.Checked = (objOrder.m_intIsRich == 1);
                m_txtPrice.Text = objOrder.m_dmlPrice.ToString();
                m_txtPrice.Tag = objOrder.m_dmlDosageRate;//保存剂量

                //
                m_txtDosage.Text = objOrder.m_dmlDosage.ToString();
                //剂量显示为0时，不显示0
                if (m_txtDosage.Text.Trim().Equals("0"))
                {
                    m_txtDosage.Text = "";
                }
                /*<================================*/
                m_txtUse.Text = objOrder.m_dmlUse.ToString();
                m_txtGet.Text = objOrder.m_dmlGet.ToString();
                m_txtGet2.Text = "";
                //
                m_txtExecuteFreq.Tag = objOrder.m_strExecFreqID;
                m_txtExecuteFreq.Text = objOrder.m_strExecFreqName;

                m_txtDosageType.Tag = objOrder.m_strDosetypeID;
                m_txtDosageType.Text = objOrder.m_strDosetypeName;

                // 为检验样本输入框赋值
                m_txtSample.Text = objOrder.m_strSAMPLEName_VCHR.ToString().Trim();
                m_txtSample.Tag = objOrder.m_strSAMPLEID_VCHR.ToString().Trim();
                // 为检验样本输入框赋值
                m_txtCheck.Text = objOrder.m_strPARTNAME_VCHR.ToString().Trim();
                m_txtCheck.Tag = objOrder.m_strPARTID_VCHR.ToString().Trim();
                m_TxbStartTime.Text = DateTimeToString(objOrder.m_dtStartDate);
                m_txbFinishTime.Text = DateTimeToString(objOrder.m_dtStopdate);
                m_txtInputDate.Text = DateTimeToString(objOrder.m_dtCreatedate);
                m_txtEntrust.Text = objOrder.m_strEntrust;
                //出院带药天数 
                m_txtDays.Text = objOrder.m_intOUTGETMEDDAYS_INT.ToString();
                AutoFillData2();//出院带药总数合计

                //医保
                m_txtMedicareType.Text = objOrder.m_strMedicareTypeName;
                //补次
                m_txtATTACHTIMES_INT.Text = objOrder.m_intATTACHTIMES_INT.ToString();
                //开始／结束时间
                if (objOrder.m_dtStartDate != DateTime.MinValue)
                {
                    m_dtStartTime2.Text = objOrder.m_dtStartDate.ToString("yyyy年MM月dd日HH时mm分");
                }
                else
                {
                    m_dtStartTime2.Text = "";
                }
                if (objOrder.m_dtFinishDate != DateTime.MinValue)
                {
                    m_dtFinishTime2.Text = objOrder.m_dtFinishDate.ToString("yyyy年MM月dd日HH时mm分");
                }
                else
                {
                    m_dtFinishTime2.Text = "";
                }
                //补登:{0=不补登；1=计费-摆药;2=计费-不摆药;3=不计费-摆药;4=不计费-不摆药};只用于临时医嘱
                if (objOrder.m_intIsRepare > 0)
                {
                    m_chkIsRepare.Checked = true;
                    if (objOrder.m_intIsRepare <= 4) m_cboRepare.SelectedIndex = objOrder.m_intIsRepare - 1;
                }
                else
                {
                    m_chkIsRepare.Checked = false;
                    m_cboRepare.SelectedIndex = -1;
                    m_cboRepare.Enabled = false;
                }
                //是否皮试
                if (objOrder.m_intISNEEDFEEL == 1)
                {
                    m_chkISNEEDFEEL.Checked = true;
                    //填充皮试结果
                    //clsT_Opr_Bih_OrderFeel_VO objResult;
                    //clsDcl_ExecuteOrder objTem =new clsDcl_ExecuteOrder();
                    //objTem.m_lngGetOrderFeelByOrderID(objOrder.m_strOrderID,out objResult);
                    //m_txtISNEEDFEEL.Text =objResult.m_strResultTypeName;
                }
                else
                {
                    m_chkISNEEDFEEL.Checked = false;
                    //m_txtISNEEDFEEL.Text ="";
                }
                //if(m_chkISNEEDFEEL.Tag==null || m_chkISNEEDFEEL.Tag.ToString().Trim()=="")
                //{	//保存药品医嘱类型ID
                //    m_chkISNEEDFEEL.Tag =new clsDcl_ExecuteOrder().m_strGetMedicineOrderTypeID().Trim();
                //}
                //if(m_chkISNEEDFEEL.Tag.ToString().Trim()==objOrder.m_strOrderDicCateID.Trim())
                //{
                //    m_chkISNEEDFEEL.Enabled =true;
                //}
                //else
                //{
                //    m_chkISNEEDFEEL.Enabled =false;
                //}
                m_txtDoctor.Tag = objOrder.m_strCreatorID;
                m_txtDoctor.Text = objOrder.m_strCreator;
                m_txtDoctorList.Text = objOrder.m_strDOCTOR_VCHR;
                m_txtDoctorList.Tag = objOrder.m_strDOCTORID_CHR;
                //父级医嘱
                m_txtFatherOrder.Text = objOrder.m_strParentName;
                m_txtFatherOrder.Tag = objOrder.m_strParentID;

                //医嘱说明
                m_txtREMARK_VCHR.Text = objOrder.m_strREMARK_VCHR;
                #endregion

                RateTypeOldIndex = 0;

                #region 抗菌药用途

                this.cboKJ.SelectedIndex = objOrder.AntiUse;
                this.cboQK.SelectedIndex = objOrder.AntiUse_YFLX;
                if (objOrder.AntiUse > 0)
                {
                    this.cboKJ.Enabled = true;
                    this.cboQK.Enabled = true;
                }
                if (objOrder.CureDays == 0)
                {
                    this.txtCureDays.Text = string.Empty;
                    this.txtCureDays.Enabled = false;
                    this.txtCureDays.BackColor = this.label9.BackColor;
                }
                else
                {
                    this.txtCureDays.Text = objOrder.CureDays.ToString();
                    this.txtCureDays.Enabled = true;
                    this.txtCureDays.BackColor = Color.White;
                }

                #endregion

                // 外送代煎
                this.cboProxyBoil.SelectedIndex = objOrder.IsProxyBoilMed;
                this.cboProxyBoil.Enabled = (objOrder.IsProxyBoilMed > 0 ? true : false);

            }
            m_blnCurrentItemIsGroup = false;
            m_mthRefreshTipInfo();
        }

        /// <summary>
        /// 获取医嘱-根据诊疗项目
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        public clsBIHOrder m_objGetOrder(clsBIHPatientInfo objPatient, clsBIHOrder objOrder)
        {
            if (m_blnCurrentItemIsGroup) return null;

            if (objOrder == null)
            {
                objOrder = new clsBIHOrder();
                objOrder.m_strOrderID = "";
            }
            else
            {
                //流水号
                objOrder.m_strOrderID = m_lblSaveOrderID.Tag.ToString();
            }
            //方号
            try
            {
                objOrder.m_intRecipenNo = Int32.Parse(m_txtRecipeNo.Text);
            }
            catch
            {
                objOrder.m_intRecipenNo = 0;

            }
            //显示的方号
            try
            {
                objOrder.m_intRecipenNo2 = Int32.Parse(m_txtRecipeNo.Tag.ToString());
            }
            catch
            {
                objOrder.m_intRecipenNo2 = 0;

            }

            //长期医嘱1 临时医嘱2 出院带药3
            objOrder.m_intExecuteType = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));

            //当前病人
            objOrder.m_strRegisterID = objPatient.m_strRegisterID;
            objOrder.m_strPatientID = objPatient.m_strPatientID;

            //诊疗项目信息 
            objOrder.m_strOrderDicID = clsConverter.ToString(m_txtOrderName2.Tag);

            objOrder.m_strName = m_txtOrderName.Text;
            objOrder.m_strSpec = m_txtOrderSpec.Text;
            objOrder.m_strDosageUnit = m_txtDosageUnit.Text;
            objOrder.m_strUseunit = m_txtUseUnit.Text;
            objOrder.m_strGetunit = m_txtGetUnit.Text;
            objOrder.m_strExecDeptID = clsConverter.ToString(m_txtExecDept.Tag);		//执行科室
            objOrder.m_strExecDeptName = m_txtExecDept.Text;
            objOrder.m_intIsRich = (m_chkIsRich.Checked ? 1 : 0);
            objOrder.m_intISNEEDFEEL = (m_chkISNEEDFEEL.Checked ? 1 : 0);
            objOrder.m_dmlPrice = clsConverter.ToDecimal(m_txtPrice.Text);
            objOrder.m_dmlTradePrice = clsConverter.ToDecimal(this.m_txtItemTradePrice.Text);
            objOrder.m_dmlDosageRate = clsConverter.ToDecimal(m_txtPrice.Tag);
            objOrder.m_dmlPACKQTY_DEC = clsConverter.ToDecimal(m_txtPackage.Text);//包装量   
            objOrder.m_intIPCHARGEFLG_INT = clsConverter.ToInt(m_txtPackage.Tag);//住院收费单位 0 －基本单位 1－最小单位
            //数量
            objOrder.m_dmlDosage = clsConverter.ToDecimal(m_txtDosage.Text);
            objOrder.m_dmlUse = clsConverter.ToDecimal(m_txtUse.Text);
            if (m_txtGet.Text.ToString().Equals("0") || m_txtGet.Text.Trim().Equals(""))
            {
                m_txtGet.Text = "1";
            }
            objOrder.m_dmlGet = clsConverter.ToDecimal(m_txtGet.Text);

            //频率
            if (m_txtExecuteFreq.Text.Trim() != "" && m_txtExecuteFreq.Tag != null && m_txtExecuteFreq.Tag.ToString().Trim() != "")
            {
                objOrder.m_strExecFreqID = clsConverter.ToString(m_txtExecuteFreq.Tag);
                m_objTempFreq = GetFreqVoByFreqID(objOrder.m_strExecFreqID);
                if (m_objTempFreq != null)
                {
                    objOrder.m_strExecFreqName = m_objTempFreq.m_strFreqName;
                    objOrder.m_intFreqTime = m_objTempFreq.m_intTimes;
                    objOrder.m_intFreqDays = m_objTempFreq.m_intDays;
                }
                m_txtExecuteFreq.Text = objOrder.m_strExecFreqName;
            }
            else
            {
                objOrder.m_strExecFreqID = "";
                objOrder.m_strExecFreqName = "";
                m_txtExecuteFreq.Text = "";
                m_txtExecuteFreq.Tag = "";
            }

            //用法
            if (m_txtDosageType.Text.Trim() != "" && m_txtDosageType.Tag != null && m_txtDosageType.Tag.ToString().Trim() != "")
            {
                objOrder.m_strDosetypeID = clsConverter.ToString(m_txtDosageType.Tag);
                clsBSEUsageType m_objUsage = GetUsageVoByUsageID(objOrder.m_strDosetypeID);
                objOrder.m_strDosetypeName = m_objUsage.m_strUsageName;
            }
            else
            {
                objOrder.m_strDosetypeID = "";
                objOrder.m_strDosetypeName = "";
                m_txtDosageType.Text = "";
                m_txtDosageType.Tag = "";
            }
            //嘱托
            //objOrder.m_strEntrust=m_txtEntrust.Text.Trim();

            objOrder.m_strParentID = "";
            objOrder.m_intStatus = 0;

            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
            objOrder.RateType = clsConverter.ToInt(m_cboRateType.m_strGetID(m_cboRateType.SelectedIndex));

            if (blnInputIsDoctor)
            {
                objOrder.m_strCreatorID = clsConverter.ToString(m_txtDoctorList.Tag);
                objOrder.m_strCreator = m_txtDoctorList.Text;
            }
            else
            {
                objOrder.m_strCreatorID = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID;
                objOrder.m_strCreator = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpName;
            }

            objOrder.m_strDOCTORID_CHR = clsConverter.ToString(m_txtDoctorList.Tag);
            objOrder.m_strDOCTOR_VCHR = m_txtDoctorList.Text;

            objOrder.m_strCHARGEDOCTORGROUPID = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strGroupID;

            objOrder.m_dtCreatedate = DateTime.Now;
            m_txtInputDate.Text = objOrder.m_dtCreatedate.ToString("yyyy-MM-dd HH:mm");

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
            objOrder.m_strParentName = m_txtFatherOrder.Text;
            if (objOrder.m_strParentName.Trim() != "")
                objOrder.m_strParentID = clsConverter.ToString(m_txtFatherOrder.Tag);
            else
                objOrder.m_strParentID = "";

            objOrder.m_strOrderDicCateID = clsConverter.ToString(m_picInfo.Tag);
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[objOrder.m_strOrderDicCateID];
            if (p_objItem != null)
            {
                objOrder.m_strOrderDicCateName = p_objItem.m_strVIEWNAME_VCHR;
            }
            try
            {
                objOrder.m_dtStartDate = Convert.ToDateTime(m_dtStartTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtStartDate = DateTime.MinValue;
            }
            try
            {
                objOrder.m_dtFinishDate = DateTime.Parse(m_dtFinishTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtFinishDate = DateTime.MinValue;
            }
            // 如果当前录入了停止时间，就置当前操作人为停止人
            if (objOrder.m_dtFinishDate != DateTime.MinValue)
            {
                objOrder.m_strStoperID = objOrder.m_strCreatorID;
                objOrder.m_strStoper = objOrder.m_strCreator;
                objOrder.m_dtStopdate = DateTime.Now;
            }
            objOrder.isYB_int = (m_chkIsMedicare.Checked) ? "1" : "0";
            if (!string.IsNullOrEmpty(m_txtSample.Tag.ToString()))
            {
                #region 修改医嘱检验项目样本
                //莫宝健 2007.9.14 modify
                long lngRes = 0;
                DataTable dtbResult = null;

                clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                lngRes = m_objService.m_lngGetSampleByFindString(m_txtSample.Text, out dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    //m_txtSample.Tag = dtbResult.Rows[0]["sample_code"].ToString().Trim();
                    //m_txtSample.Text = dtbResult.Rows[0]["sample_name"].ToString().Trim();
                    //objOrder.m_strSAMPLEID_VCHR = (string)m_txtSample.Tag;
                    //objOrder.m_strSAMPLEName_VCHR = m_txtSample.Text;

                    //2014-3-17 选择样本分泌物时的错误
                    string temp = m_txtSample.Text.ToString();
                    foreach (DataRow dtr in dtbResult.Rows)
                    {
                        if (dtr["sample_name"].ToString() == temp.Trim())
                        {
                            m_txtSample.Tag = dtr["sample_code"].ToString().Trim();
                            m_txtSample.Text = dtr["sample_name"].ToString().Trim();
                            objOrder.m_strSAMPLEID_VCHR = (string)m_txtSample.Tag;
                            objOrder.m_strSAMPLEName_VCHR = m_txtSample.Text;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("样本修改失败，请确认检验科是否存在该样本信息！");
                    objOrder.m_strSAMPLEID_VCHR = (string)m_txtSample.Tag;
                    objOrder.m_strSAMPLEName_VCHR = m_txtSample.Text;
                }
                #endregion
            }
            if (m_txtCheck.Tag != null)
            {
                objOrder.m_strPARTID_VCHR = (string)m_txtCheck.Tag;
                objOrder.m_strPARTNAME_VCHR = m_txtCheck.Text;
            }
            // 添加开单科室信息
            objOrder.m_strCREATEAREA_ID = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Tag;
            objOrder.m_strCREATEAREA_Name = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Text;
            //天数 
            if (m_txtDays.Enabled == true && m_txtDays.Visible == true)
            {
                try
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = int.Parse(m_txtDays.Text.ToString().Trim());
                }
                catch
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = 0;
                }
            }
            else
            {
                objOrder.m_intOUTGETMEDDAYS_INT = 0;
            }
            //补次
            if (objOrder.m_intExecuteType == 1)
            {
                try
                {
                    string CateName = objOrder.m_strOrderDicCateName.Trim();
                    if (this.hasAppendViewType.ContainsKey(CateName))
                    {
                        if (this.hasAppendViewType[CateName].ToString().Trim() == "1")
                        {
                            objOrder.m_intATTACHTIMES_INT = 1;
                        }
                        else
                        {
                            objOrder.m_intATTACHTIMES_INT = 0;
                        }
                    }
                    else
                    {
                        objOrder.m_intATTACHTIMES_INT = 0;
                    }
                }
                catch
                {
                    objOrder.m_intATTACHTIMES_INT = 0;
                }
            }
            else
            {
                objOrder.m_intATTACHTIMES_INT = 0;
            }

            //医生所在工作组ID
            objOrder.m_strDOCTORGROUPID_CHR = (string)((frmBIHOrderInput)this.ParentForm).m_strDOCTORGROUPID_CHR;
            //下医嘱时病人所在病区ID
            objOrder.m_strCURAREAID_CHR = objPatient.m_strAreaID;
            //下医嘱时病人所在病床ID
            objOrder.m_strCURBEDID_CHR = objPatient.m_strBedID;
            //医生签名
            if (((frmBIHOrderInput)this.ParentForm).m_intDoctorAutoSign == 1)
            {
                objOrder.SIGN_INT = 1;
            }
            else
            {
                objOrder.SIGN_INT = 0;
            }
            //医嘱说明
            objOrder.m_strREMARK_VCHR = m_txtREMARK_VCHR.Text.Trim();
            if (m_objTempFreq != null)
            {
                if (objOrder.m_intExecuteType == 1)
                {
                    objOrder.m_strEntrust = m_objTempFreq.m_strLExecTime;
                }
                else
                {
                    objOrder.m_strEntrust = m_objTempFreq.m_strTExecTime;
                }
            }
            //医嘱来源
            objOrder.m_intSOURCETYPE_INT = ((frmBIHOrderInput)this.ParentForm).m_intSOURCETYPE_INT;
            if (clsPublic.m_strGetSysparm("0008").Contains(objPatient.m_strPayTypeID))
            {
                if (this.cboShiying.Text.Trim() != "")
                {
                    objOrder.strShiying = this.cboShiying.Text.Substring(0, 1);
                }
            }
            else
            {
                objOrder.strShiying = "";
            }
            objOrder.AntiUse = this.cboKJ.SelectedIndex;
            objOrder.AntiUse_YFLX = this.cboQK.SelectedIndex;
            objOrder.CureDays = (this.txtCureDays.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txtCureDays.Text.Trim()));
            if (this.cboKJ.Enabled && this.cboKJ.SelectedIndex == 0)
            {
                MessageBox.Show("抗菌药物必须选择用途.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboKJ.Focus();
                return null;
            }
            objOrder.IsProxyBoilMed = this.cboProxyBoil.SelectedIndex;
            return objOrder;
        }

        /// <summary>
        /// 根据频率id获取频率VO
        /// </summary>
        /// <param name="m_strExecFreqID"></param>
        /// <returns></returns>
        public clsAIDRecipeFreq GetFreqVoByFreqID(string m_strExecFreqID)
        {
            if (m_htTempFreq == null)
            {
                m_htTempFreq = new Hashtable();
                if (m_arrFreq == null)
                {
                    clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                    m_objService.m_lngGetRecipeFreq("", out m_arrFreq);
                }
                for (int i = 0; i < m_arrFreq.Length; i++)
                {
                    m_htTempFreq.Add(m_arrFreq[i].m_strFreqID, m_arrFreq[i]);
                }
            }
            clsAIDRecipeFreq m_objTemp = (clsAIDRecipeFreq)m_htTempFreq[m_strExecFreqID];
            if (m_objTemp == null)
            {
                m_objTemp = new clsAIDRecipeFreq();
            }
            return m_objTemp;
        }

        /// <summary>
        /// 根据用法id获取用法VO
        /// </summary>
        /// <param name="m_strExecFreqID"></param>
        /// <returns></returns>
        public clsBSEUsageType GetUsageVoByUsageID(string m_strUsageID)
        {
            if (m_htTempUsage == null)
            {
                m_htTempUsage = new Hashtable();
                if (m_arrUsage == null)
                {
                    clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                    long lngRes = m_objService.m_lngGetUsageType("", out  m_arrUsage);
                }
                for (int i = 0; i < m_arrUsage.Length; i++)
                {
                    m_htTempUsage.Add(m_arrUsage[i].m_strUsageID, m_arrUsage[i]);
                }

            }
            clsBSEUsageType m_objUsage = (clsBSEUsageType)m_htTempUsage[m_strUsageID];
            if (m_objUsage == null)
            {
                m_objUsage = new clsBSEUsageType();
            }
            return m_objUsage;
        }

        /// <summary>
        /// 获取医嘱-(诊疗项目转医嘱)
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        public clsBIHOrder m_objGetOrderByOrderDic(clsBIHPatientInfo objPatient, clsBIHOrderDic objDic)
        {
            clsBIHOrder objOrder = new clsBIHOrder();
            objOrder.m_strOrderID = "";//医嘱流水号
            //方号
            try
            {
                objOrder.m_intRecipenNo = Int32.Parse(m_txtRecipeNo.Text);

            }
            catch
            {
                objOrder.m_intRecipenNo = 0;

            }
            //显示的方号
            try
            {
                objOrder.m_intRecipenNo2 = Int32.Parse(m_txtRecipeNo.Tag.ToString());
            }
            catch
            {
                objOrder.m_intRecipenNo2 = 0;

            }
            //长期医嘱1 临时医嘱2 出院带药3
            objOrder.m_intExecuteType = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));
            if (objOrder.m_intExecuteType == 3)
            {
                try
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = Int32.Parse(m_txtDays.Text);
                }
                catch
                { }
            }
            //当前病人
            objOrder.m_strRegisterID = objPatient.m_strRegisterID;
            objOrder.m_strPatientID = objPatient.m_strPatientID;

            //诊疗项目信息  
            objOrder.m_strOrderDicID = objDic.m_strOrderDicID;
            objOrder.m_strName = objDic.m_strName;// 医嘱名称 

            objOrder.m_strSpec = objDic.m_strSpec;//项目规格	
            objOrder.m_strDosageUnit = objDic.m_strDosageUnit.Trim();//剂量单位
            if (objDic.m_intITEMSRCTYPE_INT == 1)//如果是药
            {
                if (objDic.m_intIPCHARGEFLG_INT == 1)
                {
                    objOrder.m_strUseunit = objDic.m_strUseUnit.Trim();
                    objOrder.m_strGetunit = objDic.m_strUseUnit.Trim();

                }
                else
                {
                    objOrder.m_strUseunit = objDic.m_strITEMOPUNIT_CHR;
                    objOrder.m_strGetunit = objDic.m_strITEMOPUNIT_CHR;

                }
            }
            else
            {
                objOrder.m_strUseunit = objDic.m_strITEMUNIT_CHR;
                objOrder.m_strGetunit = objDic.m_strITEMUNIT_CHR;
            }
            objOrder.m_strExecDeptID = objDic.m_strExecDept;	//执行科室
            objOrder.m_strExecDeptName = m_txtExecDept.Text;
            objOrder.m_dmlPrice = objDic.m_dmlPrice;//住院单价;
            objOrder.m_dmlDosageRate = objDic.m_dmlDosageRate;//剂量
            //objOrder.m_dmlPACKQTY_DEC = clsConverter.ToDecimal(m_txtPackage.Text);//包装量   
            //objOrder.m_intIPCHARGEFLG_INT = clsConverter.ToInt(m_txtPackage.Tag);//住院收费单位 0 －基本单位 1－最小单位
            objOrder.m_dmlPACKQTY_DEC = objDic.m_dmlPACKQTY_DEC;//包装量   
            objOrder.m_intIPCHARGEFLG_INT = objDic.m_intIPCHARGEFLG_INT;//住院收费单位 0 －基本单位 1－最小单位

            // 剂量
            string m_strDosage = "";
            if (objDic.m_intITEMSRCTYPE_INT == 1)//如果是药(不是药的情况下,就保存原业值不变)
            {
                if (m_intAge >= 12)
                {
                    m_strDosage = objDic.m_decADULTDOSAGE_DEC.ToString();
                }
                else
                {
                    m_strDosage = objDic.m_decCHILDDOSAGE_DEC.ToString();
                }

            }
            else
            {
                m_strDosage = objDic.m_dmlDosageRate.ToString();
            }
            //数量
            objOrder.m_dmlDosage = clsConverter.ToDecimal(m_strDosage);

            //频率
            m_objTempFreq = GetFreqVoByFreqID(objDic.m_strFREQID_CHR);
            objOrder.m_strExecFreqID = m_objTempFreq.m_strFreqID;
            objOrder.m_strExecFreqName = m_objTempFreq.m_strFreqName;

            objOrder.m_intFreqTime = m_objTempFreq.m_intTimes;
            objOrder.m_intFreqDays = m_objTempFreq.m_intDays;
            //用法
            clsBSEUsageType m_objUsage = GetUsageVoByUsageID(objDic.m_strUsageID_chr);
            objOrder.m_strDosetypeID = m_objUsage.m_strUsageID;
            objOrder.m_strDosetypeName = m_objUsage.m_strUsageName;

            //嘱托
            //objOrder.m_strEntrust = m_txtEntrust.Text.Trim();

            objOrder.m_strParentID = "";
            objOrder.m_intStatus = 0;

            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药) 
            objOrder.RateType = clsConverter.ToInt(m_cboRateType.m_strGetID(m_cboRateType.SelectedIndex));
            objOrder.m_strCreatorID = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID;
            objOrder.m_strCreator = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpName;
            objOrder.m_strDOCTORID_CHR = clsConverter.ToString(m_txtDoctorList.Tag);
            objOrder.m_strDOCTOR_VCHR = m_txtDoctorList.Text;

            objOrder.m_strCHARGEDOCTORGROUPID = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strGroupID;

            objOrder.m_dtCreatedate = DateTime.Now;
            m_txtInputDate.Text = objOrder.m_dtCreatedate.ToString("yyyy-MM-dd HH:mm");

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
            objOrder.m_strParentName = m_txtFatherOrder.Text;
            if (objOrder.m_strParentName.Trim() != "")
                objOrder.m_strParentID = clsConverter.ToString(m_txtFatherOrder.Tag);
            else
                objOrder.m_strParentID = "";

            objOrder.m_strOrderDicCateID = objDic.m_strOrderCateID;
            //得到当前的医嘱类型
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[objDic.m_strOrderCateID];
            if (p_objItem != null)
            {
                objOrder.m_strOrderDicCateName = p_objItem.m_strVIEWNAME_VCHR;
            }
            //开始和结束时间  
            try
            {
                objOrder.m_dtStartDate = Convert.ToDateTime(m_dtStartTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtStartDate = DateTime.MinValue;
            }


            try
            {
                objOrder.m_dtFinishDate = DateTime.Parse(m_dtFinishTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtFinishDate = DateTime.MinValue;
            }
            // 如果当前录入了停止时间，就置当前操作人为停止人
            if (objOrder.m_dtFinishDate != DateTime.MinValue)
            {
                objOrder.m_strStoperID = objOrder.m_strCreatorID;
                objOrder.m_strStoper = objOrder.m_strCreator;
                objOrder.m_dtStopdate = DateTime.Now;
            }
            if (m_txtSample.Tag != null)
            {
                objOrder.m_strSAMPLEID_VCHR = objDic.m_strSAMPLEID_VCHR;
                objOrder.m_strSAMPLEName_VCHR = objDic.m_strSAMPLE_NAME;
            }
            if (m_txtCheck.Tag != null)
            {
                objOrder.m_strPARTID_VCHR = objDic.m_strPARTID_VCHR;
                objOrder.m_strPARTNAME_VCHR = objDic.m_strPART_NAME;
            }
            // 添加开单科室信息
            objOrder.m_strCREATEAREA_ID = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Tag;
            objOrder.m_strCREATEAREA_Name = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Text;
            // 天数，补次，开始及结束时间
            //天数
            if (objOrder.m_intExecuteType == 3)
            {
                try
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = int.Parse(m_txtDays.Text.ToString().Trim());
                }
                catch
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = 0;
                }
            }
            else
            {
                objOrder.m_intOUTGETMEDDAYS_INT = 0;
            }
            //补次
            if (objOrder.m_intExecuteType == 1)
            {
                try
                {
                    //补次
                    string CateName = objOrder.m_strOrderDicCateName.Trim();
                    if (this.hasAppendViewType.ContainsKey(CateName))
                    {
                        if (this.hasAppendViewType[CateName].ToString().Trim() == "1")
                        {
                            objOrder.m_intATTACHTIMES_INT = 1;
                        }
                        else
                        {
                            objOrder.m_intATTACHTIMES_INT = 0;
                        }
                    }
                    else
                    {
                        objOrder.m_intATTACHTIMES_INT = 0;
                    }
                }
                catch
                {
                    objOrder.m_intATTACHTIMES_INT = 0;
                }
            }
            else
            {
                objOrder.m_intATTACHTIMES_INT = 0;
            }

            //医生所在工作组ID
            objOrder.m_strDOCTORGROUPID_CHR = (string)((frmBIHOrderInput)this.ParentForm).m_strDOCTORGROUPID_CHR;
            //下医嘱时病人所在病区ID
            objOrder.m_strCURAREAID_CHR = objPatient.m_strAreaID;
            //下医嘱时病人所在病床ID
            objOrder.m_strCURBEDID_CHR = objPatient.m_strBedID;
            //医生签名
            if (((frmBIHOrderInput)this.ParentForm).m_intDoctorAutoSign == 1)
            {
                objOrder.SIGN_INT = 1;
            }
            else
            {
                objOrder.SIGN_INT = 0;
            }
            //医嘱说明
            objOrder.m_strREMARK_VCHR = m_txtREMARK_VCHR.Text.Trim();

            if (m_objTempFreq != null)
            {
                if (objOrder.m_intExecuteType == 1)
                {
                    objOrder.m_strEntrust = m_objTempFreq.m_strLExecTime;
                }
                else
                {
                    objOrder.m_strEntrust = m_objTempFreq.m_strTExecTime;
                }
            }
            //医嘱来源
            objOrder.m_intSOURCETYPE_INT = ((frmBIHOrderInput)this.ParentForm).m_intSOURCETYPE_INT;
            return objOrder;
        }

        /// <summary>
        /// 为当前医嘱进行领量设置及一次的领量,补次
        /// </summary>
        /// <param name="objOrder"></param>
        public void SetTheOrderGetMoust(ref clsBIHOrder objOrder)
        {
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[objOrder.m_strOrderDicCateID];

            ((frmBIHOrderInput)this.ParentForm).m_blTypeP = false;
            string m_strMEDICINEPREPTYPENAME_VCHR = "";//药品制剂类型
            if (m_htMEDICINEPREPTYPE.ContainsKey(objOrder.m_strOrderDicID))
            {
                m_strMEDICINEPREPTYPENAME_VCHR = (string)m_htMEDICINEPREPTYPE[objOrder.m_strOrderDicID];
                if (m_strMEDICINEPREPTYPENAME_VCHR.Trim().Equals("片剂"))
                {
                    ((frmBIHOrderInput)this.ParentForm).m_blTypeP = true;
                }
                else
                {
                    ((frmBIHOrderInput)this.ParentForm).m_blTypeP = false;
                }
            }
            else
            {
                clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                clsMEDICINEPREPTYPE_VO m_objMEDICINEPREPTYPE;
                m_objService.m_lngGetPrepTypeP(objOrder.m_strOrderDicID, out m_objMEDICINEPREPTYPE);

                if (m_objMEDICINEPREPTYPE == null)
                {
                    ((frmBIHOrderInput)this.ParentForm).m_blTypeP = false;
                }
                else
                {
                    if (m_objMEDICINEPREPTYPE.m_strMEDICINEPREPTYPENAME_VCHR.Trim().Contains("片剂"))
                    {
                        ((frmBIHOrderInput)this.ParentForm).m_blTypeP = true;
                    }

                }
            }
            //补次  如果是药品且为口服类及频率不为1日1次的默认为不补次（作废）
            //补次  如果是药品且为用法为非注射类频率为1日1次的默认为不补次，其它补
            clsBSEUsageType UsageVo = GetUsageVoByUsageID(objOrder.m_strDosetypeID);
            if (objOrder.m_intATTACHTIMES_INT == 1 && UsageVo.m_intPUTMED_INT == 1)//长嘱的且类型为补次可见的，已设为1次
            {
                if (objOrder.m_intFreqDays == 1 && objOrder.m_intFreqTime == 1)//一日一次
                {
                    objOrder.m_intATTACHTIMES_INT = 1;
                }
                else
                {
                    objOrder.m_intATTACHTIMES_INT = 0;
                }
            }
            //同步父子医嘱的补次
            if (IsSubOrder == true && ParentOrder != null)
            {
                objOrder.m_intATTACHTIMES_INT = ParentOrder.m_intATTACHTIMES_INT;
            }
            /*<========================*/
            decimal dmlGet = 0;	 //领量
            decimal m_dmlSigle = 0;//补一次的领量
            int intDays = 1;		 //天数-出院带药
            decimal dmlDosage = objOrder.m_dmlDosage;//医生下的剂量[一次剂量]
            decimal dmlUse = -1;	 //用量

            //decimal dmlUnitDosage = objOrder.m_dmlDosageRate;//剂量 [收费项目表中的剂量“DOSAGE_DEC”/医嘱表中的use_dec]
            decimal dmlUnitDosage = objOrder.m_dmlPACKQTY_DEC;//包装量
            decimal m_dmlDosageRate = objOrder.m_dmlDosageRate;//原来带出的剂量

            if (dmlUnitDosage <= 0 || objOrder.m_intIPCHARGEFLG_INT == 1)//住院收费单位m_intIPCHARGEFLG_INT 0 －基本单位 1－最小单位
            {
                dmlUnitDosage = 1;
            }
            if (m_dmlDosageRate == 0)
            {
                m_dmlDosageRate = 1;
            }

            if (((frmBIHOrderInput)this.ParentForm).m_blTypeP == true)//是否片剂的开关
            {

                bool m_blIsType;
                if (objOrder.m_intExecuteType == 3 || (p_objItem != null && p_objItem.m_strORDERCATEID_CHR.Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strMID_MEDICINE_CHR)))
                {
                    intDays = objOrder.m_intOUTGETMEDDAYS_INT;
                }

                string strFreqID = "";
                strFreqID = objOrder.m_strExecFreqID;
                if (strFreqID == string.Empty)
                {
                    dmlGet = 0;
                }
                long lngRes = 1;
                if (m_objTempFreq == null)
                {
                    m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
                }
                else if (m_objTempFreq.m_strFreqID.Trim() != strFreqID.Trim())
                {
                    m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
                }
                if (lngRes <= 0 || m_objTempFreq == null)
                {
                    dmlGet = 1;
                    m_dmlSigle = 1;
                }
                if (((frmBIHOrderInput)this.ParentForm).m_intTypePControl == 0)
                {
                    dmlUse = dmlDosage * m_objTempFreq.m_intTimes * intDays / m_dmlDosageRate;
                    //dmlGet = (dmlUse * m_objTempFreq.m_intTimes * intDays) / dmlUnitDosage;	//  领量＝(用量*次数*天数/包装量)
                    dmlGet = dmlUse / dmlUnitDosage;	//  领量＝(用量*次数*天数/包装量)

                }
                else
                {
                    // dmlGet = decimal.Ceiling(dmlUse / dmlUnitDosage) * m_objTempFreq.m_intTimes * intDays;	//  领量＝(用量*次数*天数/包装量)
                    dmlUse = decimal.Ceiling(dmlDosage / m_dmlDosageRate);
                    dmlUse = dmlUse * m_objTempFreq.m_intTimes * intDays;
                    dmlGet = dmlUse / dmlUnitDosage;
                }
                //取整
                dmlGet = decimal.Ceiling(dmlGet);
                m_dmlSigle = decimal.Ceiling((dmlDosage / m_dmlDosageRate) / dmlUnitDosage);	//  补一次的量 
            }
            else
            {

                if (objOrder.m_intExecuteType == 3 || (p_objItem != null && p_objItem.m_strORDERCATEID_CHR.Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strMID_MEDICINE_CHR)))
                {
                    intDays = objOrder.m_intOUTGETMEDDAYS_INT;
                }
                if (dmlDosage < 0 || dmlUnitDosage <= 0) { dmlGet = 1; }
                string strFreqID = "";
                strFreqID = objOrder.m_strExecFreqID;
                if (strFreqID == string.Empty)
                {
                    dmlUse = 0;
                }
                long lngRes = 1;
                if (m_objTempFreq == null || m_objTempFreq.m_strFreqID.Trim() != strFreqID.Trim())
                {
                    m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
                }
                if (lngRes <= 0 || m_objTempFreq == null)
                {
                    dmlUse = 1;
                    dmlGet = dmlUse * intDays;
                }
                else
                {
                    dmlUse = decimal.Ceiling(dmlDosage / m_dmlDosageRate);
                    dmlGet = dmlUse * m_objTempFreq.m_intTimes * intDays / dmlUnitDosage;	//用量*次数
                }

                //取整
                dmlGet = Decimal.Negate(decimal.Floor(decimal.Negate(dmlGet)));
                m_dmlSigle = Decimal.Negate(decimal.Floor(decimal.Negate(dmlUse / dmlUnitDosage))); ;	//  补一次的量

            }
            if (dmlGet <= 0)
            {
                dmlGet = 1;
            }
            if (m_dmlSigle <= 0)
            {
                m_dmlSigle = 1;
            }
            objOrder.m_dmlGet = dmlGet;
            objOrder.m_dmlOneUse = m_dmlSigle;//补一次的量
            //连续性医嘱的医嘱，领量强制为单位的量，频率次数为1
            if (objOrder.m_strExecFreqID.Trim().Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strCONFREQID_CHR.Trim()))
            {
                objOrder.m_dmlGet = 1;
                objOrder.m_dmlOneUse = 1;
                objOrder.m_intFreqTime = 1;
                objOrder.m_intFreqDays = 1;
                objOrder.m_dmlDosage = 1;

            }
            else
            {
                objOrder.m_strExecFreqName = m_objTempFreq.m_strFreqName;
                objOrder.m_intFreqTime = m_objTempFreq.m_intTimes;
                objOrder.m_intFreqDays = m_objTempFreq.m_intDays;
            }
        }

        /// <summary>
        /// 为当前医嘱进行一次的领量设置(主要用于组套生成的医嘱的一次领量的计算)
        /// </summary>
        /// <param name="objOrder"></param>
        public void SetTheOrderGetOneUseMoust(ref clsBIHOrder objOrder)
        {
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[objOrder.m_strOrderDicCateID];

            ((frmBIHOrderInput)this.ParentForm).m_blTypeP = false;
            string m_strMEDICINEPREPTYPENAME_VCHR = "";//药品制剂类型
            if (m_htMEDICINEPREPTYPE.ContainsKey(objOrder.m_strOrderDicID))
            {
                m_strMEDICINEPREPTYPENAME_VCHR = (string)m_htMEDICINEPREPTYPE[objOrder.m_strOrderDicID];
                if (m_strMEDICINEPREPTYPENAME_VCHR.Trim().Equals("片剂"))
                {
                    ((frmBIHOrderInput)this.ParentForm).m_blTypeP = true;
                }
                else
                {
                    ((frmBIHOrderInput)this.ParentForm).m_blTypeP = false;
                }
            }
            else
            {
                clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                clsMEDICINEPREPTYPE_VO m_objMEDICINEPREPTYPE;
                m_objService.m_lngGetPrepTypeP(objOrder.m_strOrderDicID, out m_objMEDICINEPREPTYPE);
                if (m_objMEDICINEPREPTYPE == null)
                {
                    ((frmBIHOrderInput)this.ParentForm).m_blTypeP = false;
                }
                else
                {
                    if (m_objMEDICINEPREPTYPE.m_strMEDICINEPREPTYPENAME_VCHR.Trim().Contains("片剂"))
                    {
                        ((frmBIHOrderInput)this.ParentForm).m_blTypeP = true;
                    }
                }
            }
            decimal dmlGet = 0;	 //领量
            decimal m_dmlSigle = 0;//补一次的领量
            int intDays = 1;		 //天数-出院带药
            decimal dmlDosage = objOrder.m_dmlDosage;//医生下的剂量[一次剂量]
            decimal dmlUse = -1;	 //用量

            //decimal dmlUnitDosage = objOrder.m_dmlDosageRate;//剂量 [收费项目表中的剂量“DOSAGE_DEC”/医嘱表中的use_dec]
            decimal dmlUnitDosage = objOrder.m_dmlPACKQTY_DEC;//包装量
            decimal m_dmlDosageRate = objOrder.m_dmlDosageRate;//原来带出的剂量

            if (dmlUnitDosage <= 0 || objOrder.m_intIPCHARGEFLG_INT == 1)//住院收费单位m_intIPCHARGEFLG_INT 0 －基本单位 1－最小单位
            {
                dmlUnitDosage = 1;
            }
            if (m_dmlDosageRate == 0)
            {
                m_dmlDosageRate = 1;
            }

            if (((frmBIHOrderInput)this.ParentForm).m_blTypeP == true)//是否片剂的开关
            {

                bool m_blIsType;
                if (objOrder.m_intExecuteType == 3 || (p_objItem != null && p_objItem.m_strORDERCATEID_CHR.Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strMID_MEDICINE_CHR)))
                {
                    intDays = objOrder.m_intOUTGETMEDDAYS_INT;
                }

                string strFreqID = "";
                strFreqID = objOrder.m_strExecFreqID;
                if (strFreqID == string.Empty)
                {
                    dmlGet = 0;
                }
                long lngRes = 1;
                if (m_objTempFreq == null)
                {
                    m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
                }
                else if (m_objTempFreq.m_strFreqID.Trim() != strFreqID.Trim())
                {
                    m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
                }
                if (lngRes <= 0 || m_objTempFreq == null)
                {
                    dmlGet = 1;
                    m_dmlSigle = 1;
                }
                if (((frmBIHOrderInput)this.ParentForm).m_intTypePControl == 0)
                {
                    dmlUse = dmlDosage * m_objTempFreq.m_intTimes * intDays / m_dmlDosageRate;
                    //dmlGet = (dmlUse * m_objTempFreq.m_intTimes * intDays) / dmlUnitDosage;	//  领量＝(用量*次数*天数/包装量)
                    dmlGet = dmlUse / dmlUnitDosage;	//  领量＝(用量*次数*天数/包装量)

                }
                else
                {
                    // dmlGet = decimal.Ceiling(dmlUse / dmlUnitDosage) * m_objTempFreq.m_intTimes * intDays;	//  领量＝(用量*次数*天数/包装量)
                    dmlUse = decimal.Ceiling(dmlDosage / m_dmlDosageRate);
                    dmlUse = dmlUse * m_objTempFreq.m_intTimes * intDays;
                    dmlGet = dmlUse / dmlUnitDosage;
                }
                //取整
                dmlGet = decimal.Ceiling(dmlGet);
                m_dmlSigle = decimal.Ceiling((dmlDosage / m_dmlDosageRate) / dmlUnitDosage);	//  补一次的量 
            }
            else
            {

                if (objOrder.m_intExecuteType == 3 || (p_objItem != null && p_objItem.m_strORDERCATEID_CHR.Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strMID_MEDICINE_CHR)))
                {
                    intDays = objOrder.m_intOUTGETMEDDAYS_INT;
                }
                if (dmlDosage < 0 || dmlUnitDosage <= 0) { dmlGet = 1; }
                string strFreqID = "";
                strFreqID = objOrder.m_strExecFreqID;
                if (strFreqID == string.Empty)
                {
                    dmlUse = 0;
                }
                long lngRes = 1;
                if (m_objTempFreq == null || m_objTempFreq.m_strFreqID.Trim() != strFreqID.Trim())
                {
                    m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
                }
                if (lngRes <= 0 || m_objTempFreq == null)
                {
                    dmlUse = 1;
                    dmlGet = dmlUse * intDays;
                }
                else
                {
                    dmlUse = decimal.Ceiling(dmlDosage / m_dmlDosageRate);
                    dmlGet = dmlUse * m_objTempFreq.m_intTimes * intDays / dmlUnitDosage;	//用量*次数
                }

                //取整
                dmlGet = Decimal.Negate(decimal.Floor(decimal.Negate(dmlGet)));
                m_dmlSigle = Decimal.Negate(decimal.Floor(decimal.Negate(dmlUse / dmlUnitDosage))); ;	//  补一次的量

            }
            if (dmlGet <= 0)
            {
                dmlGet = 1;
            }
            if (m_dmlSigle <= 0)
            {
                m_dmlSigle = 1;
            }
            objOrder.m_dmlOneUse = m_dmlSigle;//补一次的量
            //连续性医嘱的医嘱，领量强制为单位的量，频率次数为1
            if (objOrder.m_strExecFreqID.Trim().Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strCONFREQID_CHR.Trim()))
            {
                objOrder.m_dmlGet = objOrder.m_dmlOneUse;
                objOrder.m_dmlOneUse = 1;
                objOrder.m_intFreqTime = 1;
                objOrder.m_intFreqDays = 1;
                objOrder.m_dmlDosage = 1;
            }
            else
            {
                objOrder.m_strExecFreqName = m_objTempFreq.m_strFreqName;
                objOrder.m_intFreqTime = m_objTempFreq.m_intTimes;
                objOrder.m_intFreqDays = m_objTempFreq.m_intDays;
            }
        }

        /// <summary>
        /// 获取医嘱-根据医嘱组套
        /// </summary>
        public clsBIHOrder[] m_objGetOrderGroup(clsBIHPatientInfo objPatient)
        {
            clsBIHOrderGroupService m_objService2 = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
            if (!m_blnCurrentItemIsGroup) return null;

            string strGroupID = m_objCurrentGroup.m_strGroupID.Trim();
            clsBIHOrder[] arrOrder;
            long ret = m_objService2.m_lngGetGroupItems(strGroupID, out arrOrder);
            if ((ret > 0) && (arrOrder != null))
            {
                int intExecType = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));
                //费用标志：{0、"";1、自备;2、嘱托;3、基数药;4、出院带药;}	        ||      药品来源: 1 药房; 2 患者自备; 3 科室基数 			
                int intRateType = clsConverter.ToInt(m_cboRateType.m_strGetID(m_cboRateType.SelectedIndex));
                int intDays = 0;
                if (intRateType == 4)
                {
                    try
                    {
                        intDays = Int32.Parse(m_txtDays.Text);
                    }
                    catch
                    { }
                }
                //补登:{1=计费-摆药;2=计费-不摆药;3=不计费-摆药;4=不计费-不摆药};只用于临时医嘱
                int intIsRepare = 0;
                if (m_chkIsRepare.Checked)
                {
                    //如果没有选择，则默认为1=计费-摆药;
                    intIsRepare = 1;
                    intIsRepare = m_cboRepare.SelectedIndex + 1;
                }

                string strDocID = clsConverter.ToString(m_txtDoctor.Tag).Trim();
                string strDocName = m_txtDoctor.Text.Trim();
                DateTime dtCreate = DateTime.Now;
                m_txtInputDate.Text = dtCreate.ToString("yyyy-MM-dd HH:mm");

                for (int i = 0; i < arrOrder.Length; i++)
                {
                    arrOrder[i].m_strOrderID = "";
                    arrOrder[i].m_intRecipenNo = 0;
                    arrOrder[i].m_strRegisterID = objPatient.m_strRegisterID;
                    arrOrder[i].m_strPatientID = objPatient.m_strPatientID;

                    arrOrder[i].m_intExecuteType = intExecType;

                    arrOrder[i].m_intExecuteType = intExecType;
                    arrOrder[i].m_intIsRepare = intIsRepare;

                    arrOrder[i].RateType = intRateType;
                    arrOrder[i].m_intOUTGETMEDDAYS_INT = intDays;

                    arrOrder[i].m_strCreator = strDocName;
                    arrOrder[i].m_strCreatorID = strDocID;
                    arrOrder[i].m_dtCreatedate = dtCreate;
                    arrOrder[i].m_strCHARGEDOCTORGROUPID = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strGroupID;
                    //是否皮试
                    arrOrder[i].m_intISNEEDFEEL = m_chkISNEEDFEEL.Checked ? 1 : 0;
                    arrOrder[i].AntiUse = this.cboKJ.SelectedIndex;
                    arrOrder[i].AntiUse_YFLX = this.cboQK.SelectedIndex;
                    arrOrder[i].CureDays = (this.txtCureDays.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txtCureDays.Text.Trim()));
                    if (this.cboKJ.Enabled && this.cboKJ.SelectedIndex == 0)
                    {
                        MessageBox.Show("抗菌药物必须选择用途.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cboKJ.Focus();
                        return null;
                    }
                    arrOrder[i].IsProxyBoilMed = this.cboProxyBoil.SelectedIndex;
                }
                return arrOrder;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 开始输入
        /// </summary>
        public void m_mthStartInput()
        {
            EmptyInput();
            m_cboExecuteType.Focus();
        }
        /// <summary>
        /// 输入完毕,触发事件
        /// </summary>
        private void m_mthEndInput()
        {
            if (m_evtInputEnd != null)
            {
                m_evtInputEnd(this, new EventArgs());
            }
        }

        private void m_mthInputNO()
        {
            if (m_evtInputNO != null)
            {
                m_evtInputNO(this, new EventArgs());
            }
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
        /// <summary>
        /// 时间输入转换
        /// </summary>
        /// <param name="dtValue"></param>
        /// <returns></returns>
        private string DateTimeToString(DateTime dtValue)
        {
            if (dtValue.Date == clsBIHOrder.m_dtNullDate.Date)
                return "";
            else
                return dtValue.ToString("yyyy-MM-dd HH:mm");
        }

        public long m_mthGetDoctor(string p_strDoctorID)
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            return m_objService.m_lngGetHASPRESCRIPTIONRIGHT(p_strDoctorID);
        }

        /// <summary>
        /// 设置是否现实开始、停止时间录入控件
        /// </summary>
        /// <param name="p_strFreqID">执行频率ID</param>
        private void DisplayDateTimePicker(string p_strFreqID, int p_intStatus)
        {
            if (m_lblSaveConOrderFreqID.Tag == null)
                m_lblSaveConOrderFreqID.Tag = new clsDcl_ExecuteOrder().m_strGetConfreqID();
            if (m_lblSaveConOrderFreqID.Tag.ToString().Trim() == p_strFreqID.Trim())
            {
                DateTime dtStart = System.DateTime.Now;
                DateTime dtEnd = System.DateTime.Now;
                if (m_TxbStartTime.Text.Trim() != "")
                {
                    try
                    {
                        dtStart = System.Convert.ToDateTime(m_TxbStartTime.Text);
                    }
                    catch { }
                }
                if (m_txbFinishTime.Text.Trim() != "")
                {
                    try
                    {
                        dtEnd = System.Convert.ToDateTime(m_txbFinishTime.Text);
                    }
                    catch { }
                }
                m_dtStartTime.Value = dtStart;
                m_dtFinishTime.Value = dtEnd;
                if (p_intStatus == 0) m_dtStartTime.Visible = true;//新建医嘱可以输入开始时间
                if (p_intStatus == 2) m_dtFinishTime.Visible = true;//停止医嘱可以输入停止时间
                //写死剂量和用量
                m_txtDosage.Text = "1";
                m_txtDosage.Enabled = false;
                m_txtGet.Text = "1";
                m_txtGet2.Text = "";
                m_txtGet.Enabled = false;
                m_txtUse.Text = "1";
            }
            else
            {
                m_dtStartTime.Visible = false;
                m_dtFinishTime.Visible = false;
                if (m_txtDosage.Text.Trim() == "1") m_txtDosage.Enabled = true;
                if (m_txtGet.Text.Trim() == "1") m_txtGet.Enabled = true;
            }
        }
        /// <summary>
        /// 设置开始、停止时间
        /// </summary>
        /// <param name="p_strFreqID"></param>
        /// <param name="p_objItem"></param>
        private void SetStartAndEndTime(string p_strFreqID, ref clsBIHOrder p_objItem)
        {
            if (m_lblSaveConOrderFreqID.Tag == null)
                m_lblSaveConOrderFreqID.Tag = new clsDcl_ExecuteOrder().m_strGetConfreqID();
            if (m_lblSaveConOrderFreqID.Tag.ToString().Trim() == p_strFreqID.Trim())
            {
                //开始时间
                if (m_dtStartTime.Visible)
                {
                    p_objItem.m_dtStartDate = m_dtStartTime.Value;
                }
                //停止时间
                if (m_dtFinishTime.Visible)
                {
                    p_objItem.m_dtStopdate = m_dtFinishTime.Value;
                }
            }
        }
        /// <summary>
        /// 验证连续性医嘱
        /// 业务说明: 连续性医嘱其剂量/用量/领量单位必须都是“小时”!
        /// </summary>
        /// <param name="p_strFreqID"></param>
        /// <returns></returns>
        private bool PassConOrder(string p_strFreqID)
        {
            bool blnRes = true;
            if (m_lblSaveConOrderFreqID.Tag == null)
                m_lblSaveConOrderFreqID.Tag = new clsDcl_ExecuteOrder().m_strGetConfreqID();
            if (m_lblSaveConOrderFreqID.Tag.ToString().Trim() == p_strFreqID.Trim())
            {
                if (blnRes && m_txtDosageUnit.Text.Trim() != "小时")
                {
                    MessageBox.Show("连续性医嘱剂量、用量、领量单位必须为“小时”!", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnRes = false;
                }
                if (blnRes && m_txtUseUnit.Text.Trim() != "小时")
                {
                    MessageBox.Show("连续性医嘱剂量、用量、领量单位必须为“小时”!", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnRes = false;
                }
                if (blnRes && m_txtGetUnit.Text.Trim() != "小时")
                {
                    MessageBox.Show("连续性医嘱剂量、用量、领量单位必须为“小时”!", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnRes = false;
                }
            }
            return blnRes;
        }
        /// <summary>
        /// 医嘱类型逻辑
        /// </summary>
        /// <param name="p_strOrdercateID">医嘱类型ID</param>
        /// <remarks>
        /// 业务说明：
        ///		1、用法显示类型{1=正常;2=无},=2时不计费；
        ///		2、剂量显示类型{1=正常;2=无},=2时计费时取领量为1；
        ///		3、只有药品类型医嘱，才有皮试；
        /// </remarks>
        public void OrdercateLogic(clsT_aid_bih_ordercate_VO p_objItem)
        {
            long lngRes = 1;
            if (lngRes <= 0 || p_objItem == null) return;
            //长期医嘱 m_intType=1
            //临时医嘱 m_intType=2
            //出院带药 m_intType=3
            int m_intType = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));
            //补次显示类型{1=正常;2=无},=2时不计费；
            if (p_objItem.m_intAPPENDVIEWTYPE_INT == 2)
            {
                m_txtATTACHTIMES_INT.Text = "0";
                m_txtATTACHTIMES_INT.Enabled = false;
            }
            else if (m_intType == 1)
            {
                m_txtATTACHTIMES_INT.Enabled = true;
            }
            //用法显示类型{1=正常;2=无},=2时不计费；
            if (p_objItem.m_intUSAGEVIEWTYPE == 2 && IsSubOrder == false)
            {
                m_txtDosageTypeControl(false);
            }
            else
            {
                m_txtDosageTypeControl(true);
            }
            //执行频率显示类型{1=正常;2=无}
            if (p_objItem.m_intExecuFrenquenceType == 2 && IsSubOrder == false)
            {
                m_txtExecuteFreqControl(false);
            }
            else
            {
                m_txtExecuteFreqControl(true);

            }
            //临嘱显示的修改
            if (clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex)) == 2)
            {
                if (IsSubOrder == false)
                {
                    //如果没有默认的频率就取系统频率
                    clsAIDRecipeFreq m_objfreq = GetFreqVoByFreqID(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strFREQID_CHR);
                    m_txtExecuteFreq.Tag = m_objfreq.m_strFreqID;
                    m_txtExecuteFreq.Text = m_objfreq.m_strFreqName;
                    this.m_txtExecuteFreq.Enabled = false;
                    this.m_txtExecuteFreq.ReadOnly = true;
                    m_hideExecuteFreq.Site = m_txtExecuteFreq.Site;
                    m_hideExecuteFreq.Location = m_txtExecuteFreq.Location;
                    m_hideExecuteFreq.Visible = true;
                }
                else
                {
                    this.m_txtExecuteFreq.Enabled = false;
                    this.m_txtExecuteFreq.ReadOnly = true;
                    m_hideExecuteFreq.Site = m_txtExecuteFreq.Site;
                    m_hideExecuteFreq.Location = m_txtExecuteFreq.Location;
                    m_hideExecuteFreq.Visible = true;
                    if (ParentOrder != null)
                    {
                        OrderSpecialLogic(ParentOrder);
                    }
                }
            }
            //剂量显示类型{1=正常;2=无},=2时计费时取领量为1；
            if (p_objItem.m_intDOSAGEVIEWTYPE == 2 && IsSubOrder == false)
            {
                m_txtDosageControl(false);
            }
            else
            {
                m_txtDosageControl(true);
            }

            //剂量显示类型{1=正常;2=无},=2时计费时取领量为1；
            if (p_objItem.m_intQTYVIEWTYPE_INT == 2)
            {
                m_txtGet.Enabled = false;
                m_txtGet.Text = "1";
            }
            else
            {
                m_txtGet.Enabled = true;
            }
        }

        /// <summary>
        /// 执行频率控件的显示或禁用控制
        /// </summary>
        /// <param name="m_blView">true-显示,false-不显示</param>
        public void m_txtExecuteFreqControl(bool m_blView)
        {
            if (m_blView == true)
            {
                this.m_txtExecuteFreq.Enabled = true;
                this.m_txtExecuteFreq.ReadOnly = false;
                m_hideExecuteFreq.Visible = false;
            }
            else
            {
                this.m_txtExecuteFreq.Enabled = false;
                this.m_txtExecuteFreq.ReadOnly = true;
                m_hideExecuteFreq.Site = m_txtExecuteFreq.Site;
                m_hideExecuteFreq.Location = m_txtExecuteFreq.Location;
                m_hideExecuteFreq.Visible = true;
            }
        }

        /// <summary>
        /// 剂量控件的显示或禁用控制
        /// </summary>
        /// <param name="m_blView">true-显示,false-不显示</param>
        public void m_txtDosageControl(bool m_blView)
        {
            if (m_blView == true)
            {
                m_txtDosage.Enabled = true;
                m_hideDosage.Visible = false;
                m_hideDosageUnit.Visible = false;

            }
            else
            {
                m_txtDosage.Enabled = false;
                m_hideDosage.Site = m_txtDosage.Site;
                m_hideDosage.Location = m_txtDosage.Location;
                m_hideDosage.Visible = true;

                m_hideDosageUnit.Site = m_txtDosageUnit.Site;
                m_hideDosageUnit.Location = m_txtDosageUnit.Location;
                m_hideDosageUnit.Visible = true;
            }
        }

        /// <summary>
        /// 用法控件的显示或禁用控制
        /// </summary>
        /// <param name="m_blView">true-显示,false-不显示</param>
        public void m_txtDosageTypeControl(bool m_blView)
        {
            if (m_blView == true)
            {
                m_txtDosageType.Enabled = true;
                m_txtDosageType.ReadOnly = false;
                m_hideDosageType.Visible = false;
            }
            else
            {
                m_txtDosageType.Enabled = false;
                m_txtDosageType.ReadOnly = true;
                m_hideDosageType.Site = m_txtDosageType.Site;
                m_hideDosageType.Location = m_txtDosageType.Location;
                m_hideDosageType.Visible = true;
            }
        }


        /// <summary>
        /// 中药用法控件的显示或禁用控制
        /// </summary>
        /// <param name="m_blView">true-显示,false-不显示</param>
        public void m_txtMid_MedicineControl(bool m_blView)
        {
            if (m_blView == true)
            {
                m_txtDays.Visible = true;
                m_txtDays.Enabled = true;
                m_lblDay.Visible = true;
                m_lblDay.Text = "服";
            }

        }

        /// <summary>
        /// 特殊医嘱界面控制逻辑
        /// </summary>
        /// <param name="order"></param>
        public void OrderSpecialLogic(clsBIHOrder order)
        {

            //执行频率显示类型{1=正常;2=无}   频率是否显示
            if (order.m_intCHARGE_INT == 1)
            {
                this.m_txtExecuteFreq.Enabled = true;
                this.m_txtExecuteFreq.ReadOnly = false;
                m_hideExecuteFreq.Visible = false;

                this.m_txtExecuteFreq.Tag = order.m_strExecFreqID;
                this.m_txtExecuteFreq.Text = order.m_strExecFreqName;
            }

        }
        /// <summary>
        /// 是否医保病人
        /// </summary>
        private bool m_blnISMedicareMan = false;
        /// <summary>
        /// 是否医保病人
        /// </summary>
        public bool IsMedicareMan
        {
            get
            {
                return m_blnISMedicareMan;
            }
            set
            {
                m_blnISMedicareMan = value;
            }
        }
        /// <summary>
        /// 显示甲乙药
        /// 业务说明: 
        ///		1、对医保病人录入非医保药品，费用自动设为“自备”;
        ///		2、超额时不能录入，需要重新设定该病人费用下限;
        ///		3、提示甲、乙类； 
        ///		4、提示是否医保类目 
        /// </summary>
        /// <param name="p_strOrderdicID"></param>
        public void DisplayXmclsa(string p_strUserCode)
        {
            string str = strGetXmclsa(p_strUserCode).Trim();
            if (str == "999")
            {
                this.m_chkIsMedicare.Checked = false;
                this.m_lblxmclsa.Text = "";
                this.m_lblxmclsa.Visible = false;
                //费用标志：{0、"";1、自备;2、嘱托;3、基数药;4、出院带药(带几天);}
                if (m_blnISMedicareMan)
                {
                    m_cboRateType.SelectedIndex = 1;//若不是医保药则默认为自备药
                }
                m_cboRateType.Enabled = true;
            }
            else
            {
                this.m_chkIsMedicare.Checked = true;
                this.m_lblxmclsa.Text = str;
                this.m_lblxmclsa.Visible = true;
                //费用标志：{0、"";1、自备;2、嘱托;3、基数药;4、出院带药(带几天);}
                m_cboRateType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 根据诊疗项目id,显示医保属性
        /// </summary>
        /// <param name="orderDicId"></param>
        public void displayYB(string orderDicId)
        {
            string userCode = "";
            userCode = m_objInputOrder.getOrderDicUserCodeById(orderDicId);
            string str = strGetXmclsa(userCode);
            if (str == "999")
            {
                this.m_chkIsMedicare.Checked = false;
                this.m_lblxmclsa.Text = "";
                this.m_lblxmclsa.Visible = false;
            }
            else
            {
                this.m_chkIsMedicare.Checked = true;
                this.m_lblxmclsa.Text = str;
                this.m_lblxmclsa.Visible = true;
            }
        }
        /// <summary>
        /// 获取甲、乙类药
        /// 返回999 ,则不是医保项目
        /// </summary>
        /// <param name="p_strOrderdicID">诊疗项目ID</param>
        /// <returns></returns>
        private string strGetXmclsa(string p_strUserCode)
        {
            long lngRes = 0;
            string strRes = "999";
            DataTable dt = new DataTable();
            lngRes = m_objInputOrder.m_lngGetMedicareByUserCode(p_strUserCode, out dt);
            if (lngRes > 0 && dt != null && dt.Rows.Count > 0)
            {
                switch (dt.Rows[0]["xmclsa"].ToString().Trim().ToUpper())
                {
                    case "F":
                        strRes = "乙类";
                        break;
                    case "O":
                        strRes = "其他";
                        break;
                    case "T":
                        strRes = "甲类";
                        break;
                    default:
                        strRes = "";
                        break;
                }
            }
            return strRes;
        }
        /// <summary>
        /// 皮试是否可用
        /// </summary>
        /// <param name="p_strOrderTypeID">医嘱类型ID</param>
        private void IsEnableNeedFeel(string p_strOrderTypeID)
        {
            if (p_strOrderTypeID == null)
            {
                this.m_chkISNEEDFEEL.Enabled = false;
                return;
            }

            string strMedicineOrderTypeID = "";
            if (this.m_chkISNEEDFEEL.Tag == null)
            {
                strMedicineOrderTypeID = new clsDcl_ExecuteOrder().m_strGetMedicineOrderTypeID().Trim();
                this.m_chkISNEEDFEEL.Tag = strMedicineOrderTypeID;
            }
            else
            {
                strMedicineOrderTypeID = this.m_chkISNEEDFEEL.Tag.ToString().Trim();
            }

            if (p_strOrderTypeID.Trim() == strMedicineOrderTypeID)
            {
                this.m_chkISNEEDFEEL.Enabled = true;
            }
            else
            {
                this.m_chkISNEEDFEEL.Enabled = false;
            }
        }
        #endregion

        private void m_chkIsMedicare_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_chkIsMedicare.Checked)
            {
                m_chkIsMedicare.BackColor = SystemColors.Desktop;
            }
            else
            {
                m_chkIsMedicare.BackColor = SystemColors.Control;
            }
        }

        private void m_txtExecuteFreq_EnabledChanged(object sender, EventArgs e)
        {
            if (m_txtExecuteFreq.Enabled)
                m_txtExecuteFreq.BackColor = Color.White;
            else
                m_txtExecuteFreq.BackColor = SystemColors.Control;
        }

        private void m_txtSample_m_evtInitListView(ListView lvwList)
        {
            lvwList.Columns.Clear();
            lvwList.Width = 420;
            lvwList.Height = 360;
            lvwList.HeaderStyle = ColumnHeaderStyle.Clickable;
            //添加列头
            lvwList.Columns.Add("编码", 100, HorizontalAlignment.Center);
            lvwList.Columns.Add("样本名称", 300, HorizontalAlignment.Center);
        }


        private void m_txtSample_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            lvwList.Items.Clear();
            DataTable m_dtTemArr = null;
            if (!m_blSampleItem)
            {
                return;
            }
            long lngRes = m_objService.m_lngGetSampleByFindString(strFindCode, out m_dtTemArr);
            //加列
            ListViewItem lsvItem = null;
            for (int iRow = 0; iRow < m_dtTemArr.Rows.Count; iRow++)
            {
                lsvItem = null;
                lsvItem = new ListViewItem(m_dtTemArr.Rows[iRow]["sample_code"].ToString().Trim());
                lsvItem.SubItems.Add(m_dtTemArr.Rows[iRow]["sample_name"].ToString());
                lsvItem.Tag = m_dtTemArr.Rows[iRow]["sample_code"].ToString();
                lvwList.Items.Add(lsvItem);
            }
        }

        private void m_txtSample_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            if (lviSelected == null) return;
            m_txtSample.Text = lviSelected.SubItems[1].Text;
            m_txtSample.Tag = lviSelected.Tag.ToString();
            setTheControlOrder("m_txtSample");
        }

        private void m_txtCheck_m_evtInitListView(ListView lvwList)
        {
            lvwList.Columns.Clear();
            lvwList.Width = 420;
            lvwList.Height = 360;
            lvwList.HeaderStyle = ColumnHeaderStyle.Clickable;
            if (((frmBIHOrderInput)this.ParentForm).m_objCurrentOrder == null)
            {
                lvwList.CheckBoxes = true;
            }
            else
            {
                lvwList.CheckBoxes = false;
            }
            //添加列头
            lvwList.Columns.Add("编码", 100, HorizontalAlignment.Center);
            lvwList.Columns.Add("样本名称", 300, HorizontalAlignment.Center);
        }

        private void m_txtCheck_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            lvwList.Items.Clear();
            this.m_txtCheck.m_CheckItem = null;
            DataTable m_dtTemArr = null;
            if (!m_blCheckItem)
            {
                return;
            }
            long lngRes = m_objService.m_lngGetCheckByFindString(strFindCode, out m_dtTemArr);
            //加列
            ListViewItem lsvItem = null;
            clsBIHOrderDic m_objDic = null;
            if (m_txtOrderName.Tag is clsBIHOrderDic)
            {
                m_objDic = (clsBIHOrderDic)m_txtOrderName.Tag;
            }
            //存在检查申请单元时进行部位过滤
            if (m_objDic.m_intCheckTypeID != -1 && m_objDic.m_strCheckType.Trim().Length > 0 && m_objDic.m_intDELETED == 0)
            {
            }
            else
            {
                m_objDic = null;
            }

            for (int iRow = 0; iRow < m_dtTemArr.Rows.Count; iRow++)
            {
                lsvItem = null;
                lsvItem = new ListViewItem(m_dtTemArr.Rows[iRow]["assistcode_chr"].ToString().Trim());
                lsvItem.SubItems.Add(m_dtTemArr.Rows[iRow]["partname"].ToString());
                lsvItem.Tag = m_dtTemArr.Rows[iRow]["partid"].ToString();
                if (m_objDic != null)
                {
                    if (m_objDic.m_intCheckTypeID.ToString().Equals(m_dtTemArr.Rows[iRow]["TYPEID"].ToString()))
                    {
                        lvwList.Items.Add(lsvItem);
                    }
                }
                else
                {
                    lvwList.Items.Add(lsvItem);
                }
            }
            if (m_txtCheck.Tag != null)
            {
                string m_strChecks = m_txtCheck.Tag.ToString();
                for (int i = 0; i < lvwList.Items.Count; i++)
                {
                    if (m_strChecks.Contains((string)lvwList.Items[i].Tag))
                    {
                        lvwList.Items[i].Checked = true;
                    }
                }
            }

        }

        private void m_txtCheck_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            m_txtCheck.Text = "";
            m_txtCheck.Tag = "";
            if (m_txtCheck.m_CheckItem != null && m_txtCheck.m_CheckItem.Length > 0)
            {
                for (int i = 0; i < m_txtCheck.m_CheckItem.Length; i++)
                {
                    if (i > 0)
                    {
                        m_txtCheck.Text += ",";
                        m_txtCheck.Tag += ",";
                    }
                    m_txtCheck.Text += m_txtCheck.m_CheckItem[i].SubItems[1].Text;
                    m_txtCheck.Tag += m_txtCheck.m_CheckItem[i].Tag.ToString();
                }
            }
            else
            {
                if (lviSelected == null) return;
                m_txtCheck.Text = lviSelected.SubItems[1].Text;
                m_txtCheck.Tag = lviSelected.Tag.ToString();
            }
            setTheControlOrder("m_txtCheck");

        }

        #region 已注释
        //		private void m_txbFinishTime_Leave(object sender, System.EventArgs e)
        //		{
        ////			if(m_txbFinishTime.ReadOnly==false)
        ////			{
        ////				if(m_txbFinishTime.Text.Trim()!="")
        ////				{
        ////					((frmBIHOrderInput)this.Parent.Parent).m_cmdStop_Click(null,null);
        ////				}
        ////				else
        ////				{
        ////					m_txbFinishTime.Focus();
        ////					m_txbFinishTime.Text="请输入停止时间";
        ////					m_txbFinishTime.SelectAll();
        ////				}
        ////			}
        //	}
        //
        //		private void m_txbFinishTime_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //		{
        //			if(e.KeyCode==Keys.Enter)
        //			{
        //				if(m_txbFinishTime.ReadOnly==false)
        //				{
        //					((frmBIHOrderInput)this.Parent.Parent).m_cmdStop_Click(null,null);
        //				}
        //			}
        //		}
        #endregion

        /// <summary>
        /// 焦点转移
        /// </summary>
        public void SetTheButtonTab()
        {
            if (m_txtDosageType.Enabled && m_txtDosageType.Visible)
            {
                m_txtDosageType.Focus();
            }
            else if (m_txtSample.Enabled && m_txtSample.Visible)
            {
                m_txtSample.Focus();
            }
            else if (m_txtCheck.Enabled && m_txtCheck.Visible)
            {
                m_txtCheck.Focus();
            }
            else
            {
                m_cboRateType.Focus();//SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// 将医嘱所需的公共信息存一个医嘱VO中，为父医嘱窗体传递值使用
        /// </summary>
        /// <param name="order"></param>
        private void SetTheBaseOrder(out clsBIHOrder order)
        {
            order = new clsBIHOrder();

            int intExecType = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));
            //费用标志：{0、"";1、自备;2、嘱托;3、基数药;4、出院带药;}	        ||      药品来源: 1 药房; 2 患者自备; 3 科室基数 			
            int intRateType = clsConverter.ToInt(m_cboRateType.m_strGetID(m_cboRateType.SelectedIndex));
            string strDocID = clsConverter.ToString(m_txtDoctor.Tag).Trim();
            string strDocName = m_txtDoctor.Text.Trim();
            DateTime dtCreate = DateTime.Now;
            m_txtInputDate.Text = dtCreate.ToString("yyyy-MM-dd HH:mm");

            order.m_strOrderID = "";
            order.m_intRecipenNo = 0;
            order.m_strRegisterID = ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strRegisterID;
            order.m_strPatientID = ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strPatientID;

            order.m_strCREATEAREA_ID = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Tag;
            order.m_strCREATEAREA_Name = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Text;

            order.m_intExecuteType = intExecType;
            order.RateType = intRateType;

            order.m_strCreator = strDocName;
            order.m_strCreatorID = strDocID;
            order.m_dtCreatedate = dtCreate;
            order.m_strCHARGEDOCTORGROUPID = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strGroupID;
            //是否皮试
            order.m_intISNEEDFEEL = m_chkISNEEDFEEL.Checked ? 1 : 0;

            // 天数，补次，开始及结束时间
            //天数
            if (order.m_intExecuteType == 3)
            {
                try
                {
                    order.m_intOUTGETMEDDAYS_INT = int.Parse(m_txtDays.Text.ToString().Trim());
                }
                catch
                {
                    order.m_intOUTGETMEDDAYS_INT = 0;
                }
            }
            else
            {
                order.m_intOUTGETMEDDAYS_INT = 0;
            }
            //补次
            if (order.m_intExecuteType == 1)
            {
                try
                {
                    order.m_intATTACHTIMES_INT = int.Parse(m_txtATTACHTIMES_INT.Text.ToString().Trim());
                }
                catch
                {
                    order.m_intATTACHTIMES_INT = 0;
                }
            }
            else
            {
                order.m_intATTACHTIMES_INT = 0;
            }

            try
            {
                order.m_dtStartDate = DateTime.Parse(m_dtStartTime2.Text.ToString().Trim());
            }
            catch
            {
                order.m_dtStartDate = DateTime.MinValue;
            }
            try
            {
                order.m_dtFinishDate = DateTime.Parse(m_dtFinishTime2.Text.ToString().Trim());
            }
            catch
            {
                order.m_dtFinishDate = DateTime.MinValue;
            }

            //医生所在工作组ID
            order.m_strDOCTORGROUPID_CHR = (string)((frmBIHOrderInput)this.ParentForm).m_strDOCTORGROUPID_CHR;

            order.m_strDOCTORID_CHR = clsConverter.ToString(m_txtDoctorList.Tag);
            order.m_strDOCTOR_VCHR = m_txtDoctorList.Text;
            //下医嘱时病人所在病区ID
            order.m_strCURAREAID_CHR = (string)((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strAreaID;
            //下医嘱时病人所在病床ID
            order.m_strCURBEDID_CHR = (string)((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strBedID;

            //医生签名
            if (((frmBIHOrderInput)this.ParentForm).m_intDoctorAutoSign == 1)
            {
                order.SIGN_INT = 1;
            }
            else
            {
                order.SIGN_INT = 0;
            }
        }

        private void m_txtRecipeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            { }
            else if ((e.KeyChar == 8) || (e.KeyChar == 13))
            { }
            else
            {
                e.Handled = true;
            }
        }

        private void m_txtRecipeNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int k = int.Parse(m_txtRecipeNo.Text);
            }
            catch
            {
                m_txtRecipeNo.Text = "";
                m_txtRecipeNo.Focus();
            }
        }

        private void m_txtRecipeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                setTheControlOrder(((TextBox)sender).Name);
            }
        }

        private void m_txtRecipeNo_Leave(object sender, EventArgs e)
        {
            m_mthInputNO();
        }

        private void m_txtOrderName2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                setTheControlOrder(((TextBox)sender).Name);
            }
        }

        #region 病区事件
        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            m_txtArea.Tag = null;
            m_txtBedNo.Tag = null;
            m_txtBedNo.Text = "";
            clsBIHArea[] arrArea;
            long ret = m_objService.m_lngFindArea(strFindCode, out arrArea);
            if ((ret > 0) && (arrArea != null))
            {
                //获取有权限访问的病区ID集合
                if (((frmBIHOrderInput)this.ParentForm).m_objLoginInfo != null)
                {
                    IList ilUsableAreaID = ((frmBIHOrderInput)this.ParentForm).m_objLoginInfo.m_ilUsableAreaID;
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
                    lvi.Tag = arrArea[i];
                }
            }
        }

        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
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

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_txtArea.Text = lviSelected.SubItems[1].Text;
                m_txtArea.Tag = lviSelected.Tag;

                m_txtBedNo.Text = "";
                m_txtBedNo.Tag = null;

                m_txtBedNo.Focus();
            }
        }
        #endregion

        #region 床位号事件
        private void m_txtBedNo2_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            for (int i1 = 0; i1 < ((frmBIHOrderInput)this.ParentForm).m_dtvOrder.RowCount; i1++)
            {
                clsBIHOrder order1 = (clsBIHOrder)((frmBIHOrderInput)this.ParentForm).m_dtvOrder.Rows[i1].Tag;
                if (order1.m_intStatus == 0)
                {
                    if (MessageBox.Show("当前有未提交的医嘱,确实要更改当前病人吗？", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        //if (!oldBedNoValue.Trim().Equals(""))
                        //{

                        //    m_txtBedNo.Text = oldBedNoValue;
                        //    oldBedNoValue = "";
                        //}
                        if (m_txtBedNo.Tag != null)
                        {
                            m_txtBedNo.Text = ((clsBIHBed)this.m_txtBedNo.Tag).m_strBedName;
                        }
                        return;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            this.m_txtBedNo.Tag = null;
            //clsBIHOrderService m_objService = new clsBIHOrderService();
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            /*<----------------------------------------*/

            if (m_txtArea.Tag == null)
            {
                //if (m_blnPrompt) MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtArea.Text = "";
                m_txtArea.Tag = null;
                m_txtArea.Focus();
                return;
            }
            string strAreaID = (m_txtArea.Tag as clsBIHArea).m_strAreaID;
            clsBIHBed[] arrBed;
            string strBedNo = m_txtBedNo.Text.Trim();
            long ret = m_objService.m_lngGetBedByArea(strAreaID, strBedNo, out arrBed);
            if ((ret > 0) && (arrBed != null))
            {
                if (arrBed.Length == 0)
                {
                    MessageBox.Show("当前科室没有床位，请重新选病区", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_txtBedNo.Focus();
                    return;
                }
                for (int i = 0; i < arrBed.Length; i++)
                {
                    ListViewItem objItem = new ListViewItem(arrBed[i].m_strBedName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strPatientName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strSex);
                    objItem.Tag = arrBed[i];
                    lvwList.Items.Add(objItem);
                }
            }
        }

        private void m_txtBedNo2_m_evtInitListView(ListView lvwList)
        {
            lvwList.Columns.Add("床　号", 40, HorizontalAlignment.Left);
            lvwList.Columns.Add("姓　名", 80, HorizontalAlignment.Left);
            lvwList.Columns.Add("性　别", 40, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 180;
        }

        private void m_txtBedNo2_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {

                m_txtBedNo.Text = lviSelected.SubItems[0].Text;
                m_txtBedNo.Tag = lviSelected.Tag;
                ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_txtArea.Tag = m_txtArea.Tag;
                ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_txtBedNo.Tag = m_txtBedNo.Tag;
                ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_mthGetPatientByAreaBed();

            }

        }
        #endregion

        string oldBedNoValue = "";
        private void m_txtBedNo_DoubleClick(object sender, EventArgs e)
        {
            oldBedNoValue = m_txtBedNo.Text;
            m_txtBedNo.Text = "";
            SendKeys.Send("{ENTER}");
        }

        private void m_txtArea_DoubleClick(object sender, EventArgs e)
        {
            oldBedNoValue = m_txtBedNo.Text;
            m_txtArea.Text = "";
            SendKeys.Send("{ENTER}");
        }

        private void m_btnBedList_Click(object sender, EventArgs e)
        {
            m_txtBedNo.Focus();
            m_txtBedNo_DoubleClick(null, null);
        }

        private void m_txtDoctorList_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            clsBIHDoctor[] m_objDoctorArr;
            long ret = m_objService.m_lngGetDoctorsList(strFindCode, m_objCurrentDoctor.m_strDoctorID, out m_objDoctorArr);
            if ((ret > 0))
            {
                for (int i = 0; i < m_objDoctorArr.Length; i++)
                {
                    ListViewItem lvi = lvwList.Items.Add(m_objDoctorArr[i].m_strDoctorNo);
                    lvi.SubItems.Add(m_objDoctorArr[i].m_strDoctorName);
                    lvi.Tag = m_objDoctorArr[i].m_strDoctorID;
                }
            }
        }

        private void m_txtDoctorList_m_evtInitListView(ListView lvwList)
        {
            lvwList.Columns.Add("编号", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("医生姓名", 100, HorizontalAlignment.Left);
            //lvwList.Columns.Add("拼音码", 60, HorizontalAlignment.Left);

            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
        }

        private void m_txtDoctorList_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_txtDoctorList.Text = lviSelected.SubItems[1].Text;
                m_txtDoctorList.Tag = lviSelected.Tag;

                setTheControlOrder("m_txtDoctorList");
                // 当选择了一医生后，接着的操作就默认为当前医嘱
                ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strDOCTORID_CHR = (string)lviSelected.Tag;
                ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strDOCTOR_VCHR = lviSelected.SubItems[1].Text;
            }
        }

        private void m_txtATTACHTIMES_INT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                try
                {
                    int i1 = int.Parse(m_txtATTACHTIMES_INT.Text.ToString().Trim());
                }
                catch
                {
                    m_txtATTACHTIMES_INT.Focus();
                    return;
                }
                setTheControlOrder(((TextBox)sender).Name);
            }
        }

        private void m_dtStartTime2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                int i = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));
                if (i == 1)
                {
                    setTheControlOrder("m_dtFinishTime2");
                }
                else
                {
                    setTheControlOrder("m_dtStartTime2");
                }
            }
        }

        private void m_dtFinishTime2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                m_dtFinishTime2_Leave(null, null);
            }
        }

        private void m_txtOrderName2_DoubleClick(object sender, EventArgs e)
        {
            m_txtOrderName2.ReadOnly = m_blOrderName2ReadOnly;
        }

        internal void m_objGetCommitOrder(clsBIHPatientInfo objPatient, clsBIHOrder objBihOrder, ref clsCommitOrder objOrder)
        {
            /*可以修改的字段为：
            objOrder.m_intRecipenNo  m_intExecuteType m_strOrderDicID m_strName m_strSpec
            m_strDosageUnit m_strUseunit m_strGetunit m_strExecDeptID m_strExecDeptName
            m_intIsRich m_dmlPrice m_dmlDosageRate m_dmlDosage m_dmlUse
            m_dmlGet m_strExecFreqID m_strExecFreqName m_strDosetypeID m_strDosetypeName
            m_strEntrust m_intRateType m_strDOCTORID_CHR m_strDOCTOR_VCHR m_strParentName
            m_strParentID m_strOrderDicCateID m_strSAMPLEID_VCHR m_strSAMPLEName_VCHR m_strPARTID_VCHR
            m_strPARTNAME_VCHR m_strCREATEAREA_ID  m_strCREATEAREA_Name m_intOUTGETMEDDAYS_INT m_intATTACHTIMES_INT
            m_dtStartDate m_dtFinishDate m_strDOCTORGROUPID_CHR  m_strCURAREAID_CHR m_strCURBEDID_CHR
            *<==================================================*/

            objOrder.m_strOrderID = objBihOrder.m_strOrderID;
            objOrder.m_strAge = objPatient.m_strAge;
            objOrder.m_strAreaID = objPatient.m_strAreaID;
            objOrder.m_strAreaName = objPatient.m_strAreaName;
            objOrder.m_strPatientID = objPatient.m_strPatientID;
            objOrder.m_strPatientName = objPatient.m_strPatientName;
            objOrder.m_strsex_chr = objPatient.m_strSex;
            objOrder.m_strDIAGNOSE_VCHR = objPatient.m_strDiagnose;

            //方号
            try
            {
                objOrder.m_intRecipenNo = Int32.Parse(m_txtRecipeNo.Text);
            }
            catch
            {
                objOrder.m_intRecipenNo = 0;
            }
            //显示的方号
            try
            {
                objOrder.m_intRecipenNo2 = Int32.Parse(m_txtRecipeNo.Tag.ToString());
            }
            catch
            {
                objOrder.m_intRecipenNo2 = 0;
            }

            //长期医嘱1 临时医嘱2 出院带药3
            objOrder.m_intExecuteType = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));

            //当前病人
            //诊疗项目信息
            objOrder.m_strOrderDicID = clsConverter.ToString(m_txtOrderName2.Tag);
            objOrder.m_strName = m_txtOrderName.Text;//可以修改。
            objOrder.m_strSpec = m_txtOrderSpec.Text;
            objOrder.m_strDosageUnit = m_txtDosageUnit.Text;
            objOrder.m_strUseunit = m_txtUseUnit.Text;
            objOrder.m_strGetunit = m_txtGetUnit.Text;
            objOrder.m_strExecDeptID = clsConverter.ToString(m_txtExecDept.Tag);		//执行科室
            objOrder.m_strExecDeptName = m_txtExecDept.Text;
            objOrder.m_intIsRich = (m_chkIsRich.Checked ? 1 : 0);
            objOrder.m_intISNEEDFEEL = (m_chkISNEEDFEEL.Checked ? 1 : 0);
            objOrder.m_dmlPrice = clsConverter.ToDecimal(m_txtPrice.Text);
            objOrder.m_dmlDosageRate = clsConverter.ToDecimal(m_txtPrice.Tag);
            objOrder.m_dmlPACKQTY_DEC = clsConverter.ToDecimal(m_txtPackage.Text);//包装量   
            objOrder.m_intIPCHARGEFLG_INT = clsConverter.ToInt(m_txtPackage.Tag);//住院收费单位 0 －基本单位 1－最小单位
            //数量
            objOrder.m_dmlDosage = clsConverter.ToDecimal(m_txtDosage.Text);
            objOrder.m_dmlUse = clsConverter.ToDecimal(m_txtUse.Text);
            objOrder.m_dmlGet = clsConverter.ToDecimal(m_txtGet.Text);

            //频率
            if (m_txtExecuteFreq.Text.Trim() != "" && m_txtExecuteFreq.Tag != null && m_txtExecuteFreq.Tag.ToString().Trim() != "")
            {
                objOrder.m_strExecFreqID = clsConverter.ToString(m_txtExecuteFreq.Tag);
                m_objTempFreq = GetFreqVoByFreqID(objOrder.m_strExecFreqID);
                objOrder.m_strExecFreqName = m_objTempFreq.m_strFreqName;
                objOrder.m_intFreqTime = m_objTempFreq.m_intTimes;
                objOrder.m_intFreqDays = m_objTempFreq.m_intDays;
            }
            else
            {
                objOrder.m_strExecFreqID = "";
                objOrder.m_strExecFreqName = "";
            }
            //用法
            if (m_txtDosageType.Text.Trim() != "" && m_txtDosageType.Tag != null && m_txtDosageType.Tag.ToString().Trim() != "")
            {
                objOrder.m_strDosetypeID = clsConverter.ToString(m_txtDosageType.Tag);
                clsBSEUsageType m_objUsage = GetUsageVoByUsageID(objOrder.m_strDosetypeID);
                objOrder.m_strDosetypeName = m_objUsage.m_strUsageName;
            }
            else
            {
                objOrder.m_strDosetypeID = "";
                objOrder.m_strDosetypeName = "";
            }
            //嘱托
            objOrder.m_strEntrust = m_txtEntrust.Text.Trim();

            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
            objOrder.RateType = clsConverter.ToInt(m_cboRateType.m_strGetID(m_cboRateType.SelectedIndex));
            objOrder.m_strDOCTORID_CHR = clsConverter.ToString(m_txtDoctorList.Tag);
            objOrder.m_strDOCTOR_VCHR = m_txtDoctorList.Text;

            //父级医嘱
            objOrder.m_strParentName = m_txtFatherOrder.Text;
            if (objOrder.m_strParentName.Trim() != "")
                objOrder.m_strParentID = clsConverter.ToString(m_txtFatherOrder.Tag);
            else
                objOrder.m_strParentID = "";

            objOrder.m_strOrderDicCateID = clsConverter.ToString(m_picInfo.Tag);
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[objOrder.m_strOrderDicCateID];
            if (p_objItem != null)
            {
                objOrder.m_strOrderDicCateName = p_objItem.m_strVIEWNAME_VCHR;
            }
            if (m_txtSample.Tag != null)
            {
                objOrder.m_strSAMPLEID_VCHR = (string)m_txtSample.Tag;
                objOrder.m_strSAMPLEName_VCHR = m_txtSample.Text;
            }
            if (m_txtCheck.Tag != null)
            {
                objOrder.m_strPARTID_VCHR = (string)m_txtCheck.Tag;
                objOrder.m_strPARTNAME_VCHR = m_txtCheck.Text;
            }
            // 添加开单科室信息
            objOrder.m_strCREATEAREA_ID = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Tag;
            objOrder.m_strCREATEAREA_Name = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Text;
            // 天数，补次，开始及结束时间
            //天数 
            if (m_txtDays.Enabled == true && m_txtDays.Visible == true)
            {
                try
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = int.Parse(m_txtDays.Text.ToString().Trim());
                }
                catch
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = 0;
                }
            }
            else
            {
                objOrder.m_intOUTGETMEDDAYS_INT = 0;
            }
            //补次
            if (objOrder.m_intExecuteType == 1)
            {
                try
                {
                    objOrder.m_intATTACHTIMES_INT = int.Parse(m_txtATTACHTIMES_INT.Text.ToString().Trim());
                }
                catch
                {
                    objOrder.m_intATTACHTIMES_INT = 0;
                }
            }
            else
            {
                objOrder.m_intATTACHTIMES_INT = 0;
            }
            //开始及结束时间
            try
            {
                objOrder.m_dtStartDate = DateTime.Parse(m_dtStartTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtStartDate = DateTime.MinValue;
            }
            try
            {
                objOrder.m_dtFinishDate = DateTime.Parse(m_dtFinishTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtFinishDate = DateTime.MinValue;
            }

            // 如果当前录入了停止时间，就置当前操作人为停止人
            if (objOrder.m_dtFinishDate != DateTime.MinValue)
            {
                objOrder.m_strStoperID = objOrder.m_strCreatorID;
                objOrder.m_strStoper = objOrder.m_strCreator;
                objOrder.m_dtStopdate = DateTime.Now;
            }
            else
            {
                objOrder.m_strStoperID = "";
                objOrder.m_strStoper = "";
                objOrder.m_dtStopdate = DateTime.MinValue;
            }
            //医生所在工作组ID
            objOrder.m_strDOCTORGROUPID_CHR = (string)((frmBIHOrderInput)this.ParentForm).m_strDOCTORGROUPID_CHR;
            //下医嘱时病人所在病区ID
            objOrder.m_strCURAREAID_CHR = objPatient.m_strAreaID;
            //下医嘱时病人所在病床ID
            objOrder.m_strCURBEDID_CHR = objPatient.m_strBedID;
            //说明
            objOrder.m_strREMARK_VCHR = m_txtREMARK_VCHR.Text.Trim();
            //修改人ID
            objOrder.m_strChangedID_CHR = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID;
            //修改人姓名
            objOrder.m_strChangedName_CHR = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpName;

            // 修改检验医嘱时申请单丢失
            objOrder.m_strBedID = (string)((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strBedID;
            objOrder.m_strBedName = (string)((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strBedName;
            objOrder.m_strINPATIENTID_CHR = (string)((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strInHospitalNo;
            objOrder.m_strCreatorID = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID;

            objOrder.AntiUse = this.cboKJ.SelectedIndex;
            objOrder.AntiUse_YFLX = this.cboQK.SelectedIndex;
            objOrder.CureDays = (this.txtCureDays.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txtCureDays.Text.Trim()));
            if (this.cboKJ.Enabled && this.cboKJ.SelectedIndex == 0)
            {
                MessageBox.Show("抗菌药物必须选择用途.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboKJ.Focus();
            }
            objOrder.IsProxyBoilMed = this.cboProxyBoil.SelectedIndex;
        }

        internal void m_objGetChangedOrder(clsBIHPatientInfo objPatient, ref clsBIHOrder objOrder)
        {
            /*可以修改的字段为：
            objOrder.m_intRecipenNo  m_intExecuteType m_strOrderDicID m_strName m_strSpec
            m_strDosageUnit m_strUseunit m_strGetunit m_strExecDeptID m_strExecDeptName
            m_intIsRich m_dmlPrice m_dmlDosageRate m_dmlDosage m_dmlUse
            m_dmlGet m_strExecFreqID m_strExecFreqName m_strDosetypeID m_strDosetypeName
            m_strEntrust m_intRateType m_strDOCTORID_CHR m_strDOCTOR_VCHR m_strParentName
            m_strParentID m_strOrderDicCateID m_strSAMPLEID_VCHR m_strSAMPLEName_VCHR m_strPARTID_VCHR
            m_strPARTNAME_VCHR m_strCREATEAREA_ID  m_strCREATEAREA_Name m_intOUTGETMEDDAYS_INT m_intATTACHTIMES_INT
            m_dtStartDate m_dtFinishDate m_strDOCTORGROUPID_CHR  m_strCURAREAID_CHR m_strCURBEDID_CHR
            *<==================================================*/

            //方号
            try
            {
                objOrder.m_intRecipenNo = Int32.Parse(m_txtRecipeNo.Text);
            }
            catch
            {
                objOrder.m_intRecipenNo = 0;
            }
            //显示的方号
            try
            {
                objOrder.m_intRecipenNo2 = Int32.Parse(m_txtRecipeNo.Tag.ToString());
            }
            catch
            {
                objOrder.m_intRecipenNo2 = 0;
            }

            //长期医嘱1 临时医嘱2 出院带药3
            objOrder.m_intExecuteType = clsConverter.ToInt(m_cboExecuteType.m_strGetID(m_cboExecuteType.SelectedIndex));

            //当前病人
            //诊疗项目信息
            objOrder.m_strOrderDicID = clsConverter.ToString(m_txtOrderName2.Tag);
            objOrder.m_strName = m_txtOrderName.Text;//可以修改。
            objOrder.m_strSpec = m_txtOrderSpec.Text;
            objOrder.m_strDosageUnit = m_txtDosageUnit.Text;
            objOrder.m_strUseunit = m_txtUseUnit.Text;
            objOrder.m_strGetunit = m_txtGetUnit.Text;
            objOrder.m_strExecDeptID = clsConverter.ToString(m_txtExecDept.Tag);		//执行科室
            objOrder.m_strExecDeptName = m_txtExecDept.Text;
            objOrder.m_intIsRich = (m_chkIsRich.Checked ? 1 : 0);
            objOrder.m_intISNEEDFEEL = (m_chkISNEEDFEEL.Checked ? 1 : 0);
            objOrder.m_dmlPrice = clsConverter.ToDecimal(m_txtPrice.Text);
            objOrder.m_dmlDosageRate = clsConverter.ToDecimal(m_txtPrice.Tag);
            objOrder.m_dmlPACKQTY_DEC = clsConverter.ToDecimal(m_txtPackage.Text);//包装量   
            objOrder.m_intIPCHARGEFLG_INT = clsConverter.ToInt(m_txtPackage.Tag);//住院收费单位 0 －基本单位 1－最小单位
            //数量
            objOrder.m_dmlDosage = clsConverter.ToDecimal(m_txtDosage.Text);
            objOrder.m_dmlUse = clsConverter.ToDecimal(m_txtUse.Text);
            objOrder.m_dmlGet = clsConverter.ToDecimal(m_txtGet.Text);

            //频率
            if (m_txtExecuteFreq.Text.Trim() != "" && m_txtExecuteFreq.Tag != null && m_txtExecuteFreq.Tag.ToString().Trim() != "")
            {
                objOrder.m_strExecFreqID = clsConverter.ToString(m_txtExecuteFreq.Tag);
                m_objTempFreq = GetFreqVoByFreqID(objOrder.m_strExecFreqID);
                objOrder.m_strExecFreqName = m_objTempFreq.m_strFreqName;
                objOrder.m_intFreqTime = m_objTempFreq.m_intTimes;
                objOrder.m_intFreqDays = m_objTempFreq.m_intDays;
            }
            else
            {
                objOrder.m_strExecFreqID = "";
                objOrder.m_strExecFreqName = "";
            }
            //用法
            if (m_txtDosageType.Text.Trim() != "" && m_txtDosageType.Tag != null && m_txtDosageType.Tag.ToString().Trim() != "")
            {
                objOrder.m_strDosetypeID = clsConverter.ToString(m_txtDosageType.Tag);
                clsBSEUsageType m_objUsage = GetUsageVoByUsageID(objOrder.m_strDosetypeID);
                objOrder.m_strDosetypeName = m_objUsage.m_strUsageName;
            }
            else
            {
                objOrder.m_strDosetypeID = "";
                objOrder.m_strDosetypeName = "";
            }
            //嘱托
            objOrder.m_strEntrust = m_txtEntrust.Text.Trim();

            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药) 
            objOrder.RateType = clsConverter.ToInt(m_cboRateType.m_strGetID(m_cboRateType.SelectedIndex));
            objOrder.m_strDOCTORID_CHR = clsConverter.ToString(m_txtDoctorList.Tag);
            objOrder.m_strDOCTOR_VCHR = m_txtDoctorList.Text;

            //父级医嘱
            objOrder.m_strParentName = m_txtFatherOrder.Text;
            if (objOrder.m_strParentName.Trim() != "")
                objOrder.m_strParentID = clsConverter.ToString(m_txtFatherOrder.Tag);
            else
                objOrder.m_strParentID = "";

            objOrder.m_strOrderDicCateID = clsConverter.ToString(m_picInfo.Tag);
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[objOrder.m_strOrderDicCateID];
            if (p_objItem != null)
            {
                objOrder.m_strOrderDicCateName = p_objItem.m_strVIEWNAME_VCHR;
            }
            if (m_txtSample.Tag != null)
            {
                objOrder.m_strSAMPLEID_VCHR = (string)m_txtSample.Tag;
                objOrder.m_strSAMPLEName_VCHR = m_txtSample.Text;
            }
            if (m_txtCheck.Tag != null)
            {
                objOrder.m_strPARTID_VCHR = (string)m_txtCheck.Tag;
                objOrder.m_strPARTNAME_VCHR = m_txtCheck.Text;
            }
            // 添加开单科室信息
            objOrder.m_strCREATEAREA_ID = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Tag;
            objOrder.m_strCREATEAREA_Name = (string)((frmBIHOrderInput)this.ParentForm).m_txtCREATEAREA.Text;
            // 天数，补次，开始及结束时间
            //天数 
            if (m_txtDays.Enabled == true && m_txtDays.Visible == true)
            {
                try
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = int.Parse(m_txtDays.Text.ToString().Trim());
                }
                catch
                {
                    objOrder.m_intOUTGETMEDDAYS_INT = 0;
                }
            }
            else
            {
                objOrder.m_intOUTGETMEDDAYS_INT = 0;
            }
            //补次
            if (objOrder.m_intExecuteType == 1)
            {
                try
                {
                    objOrder.m_intATTACHTIMES_INT = int.Parse(m_txtATTACHTIMES_INT.Text.ToString().Trim());
                }
                catch
                {
                    objOrder.m_intATTACHTIMES_INT = 0;
                }
            }
            else
            {
                objOrder.m_intATTACHTIMES_INT = 0;
            }
            //开始及结束时间

            try
            {
                objOrder.m_dtStartDate = DateTime.Parse(m_dtStartTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtStartDate = DateTime.MinValue;
            }
            try
            {
                objOrder.m_dtFinishDate = DateTime.Parse(m_dtFinishTime2.Text.ToString().Trim());
            }
            catch
            {
                objOrder.m_dtFinishDate = DateTime.MinValue;
            }

            // 如果当前录入了停止时间，就置当前操作人为停止人
            if (objOrder.m_dtFinishDate != DateTime.MinValue)
            {
                objOrder.m_strStoperID = objOrder.m_strCreatorID;
                objOrder.m_strStoper = objOrder.m_strCreator;
                objOrder.m_dtStopdate = DateTime.Now;
            }
            else
            {
                objOrder.m_strStoperID = "";
                objOrder.m_strStoper = "";
                objOrder.m_dtStopdate = DateTime.MinValue;

            }
            //医生所在工作组ID
            objOrder.m_strDOCTORGROUPID_CHR = (string)((frmBIHOrderInput)this.ParentForm).m_strDOCTORGROUPID_CHR;
            //下医嘱时病人所在病区ID
            objOrder.m_strCURAREAID_CHR = objPatient.m_strAreaID;
            //下医嘱时病人所在病床ID
            objOrder.m_strCURBEDID_CHR = objPatient.m_strBedID;
            //说明
            objOrder.m_strREMARK_VCHR = m_txtREMARK_VCHR.Text.Trim();
            //修改人ID
            objOrder.m_strChangedID_CHR = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID;
            //修改人姓名
            objOrder.m_strChangedName_CHR = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpName;
            objOrder.strShiying = this.cboShiying.Text.Substring(0, 1).ToString();

            objOrder.AntiUse = this.cboKJ.SelectedIndex;
            objOrder.AntiUse_YFLX = this.cboQK.SelectedIndex;
            objOrder.CureDays = (this.txtCureDays.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txtCureDays.Text.Trim()));
            if (this.cboKJ.Enabled && this.cboKJ.SelectedIndex == 0)
            {
                MessageBox.Show("抗菌药物必须选择用途.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboKJ.Focus();
            }
            objOrder.IsProxyBoilMed = this.cboProxyBoil.SelectedIndex;
        }

        private void m_txtGet_Leave(object sender, EventArgs e)
        {
            //总量的计算
            m_txtDays_Leave(null, null);
        }

        private void m_dtFinishTime2_Leave(object sender, EventArgs e)
        {
            DateTime m_StopTime = DateTime.MinValue;
            DateTime m_StartTime = DateTime.MinValue;
            try
            {
                m_StartTime = Convert.ToDateTime(this.m_dtStartTime2.Text.ToString().Trim());

            }
            catch
            {
                m_StartTime = DateTime.MinValue;
            }
            try
            {
                m_StopTime = Convert.ToDateTime(m_dtFinishTime2.Text.ToString().Trim());

            }
            catch
            {
                m_StopTime = DateTime.MinValue;
            }
            if (m_StartTime > m_StopTime && m_StopTime != DateTime.MinValue)
            {

                MessageBox.Show("结束时间不能少于开始时间!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                m_dtFinishTime2.Focus();
                return;
            }
            if (((frmBIHOrderInput)this.ParentForm).m_objCurrentOrder != null && m_StopTime < ((frmBIHOrderInput)this.ParentForm).m_objCurrentOrder.m_dtExecutedate && m_StopTime != DateTime.MinValue)
            {

                MessageBox.Show("结束时间不能少于执行时间!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                m_dtFinishTime2.Focus();
                return;
            }
            setTheControlOrder("m_dtFinishTime2");
        }



        private void m_txtArea_Leave(object sender, EventArgs e)
        {
            ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_txtArea.Focus();

        }

        private void m_cobOrderCate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                //m_txtOrderName.Focus();
                //m_txtRecipeNo.Focus();
                /*=================>*/
                setTheControlOrder(((System.Windows.Forms.ComboBox)sender).Name);
                /*<============================*/
            }
        }

        private void m_txtOrderCate_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            if (m_cobOrderCate.Items.Count > 0)
            {
                //clsOrderCate
                for (int i = 0; i < m_cobOrderCate.Items.Count; i++)
                {

                    clsOrderCate p_objItem = (clsOrderCate)m_cobOrderCate.Items[i];
                    if (p_objItem != null && p_objItem.m_objOrderCate.m_strUSERCODE_VCHR.ToUpper().Contains(strFindCode.ToUpper().Trim()) || p_objItem.m_objOrderCate.m_strVIEWNAME_VCHR.ToUpper().Contains(strFindCode.ToUpper().Trim()))
                    {
                        ListViewItem lvi = lvwList.Items.Add(p_objItem.m_objOrderCate.m_strUSERCODE_VCHR);
                        lvi.SubItems.Add(p_objItem.m_objOrderCate.m_strVIEWNAME_VCHR);
                        lvi.Tag = p_objItem;
                    }
                }
            }
        }

        private void m_txtOrderCate_m_evtInitListView(ListView lvwList)
        {
            lvwList.Columns.Clear();
            lvwList.Width = 180;
            lvwList.Height = 260;
            ColumnHeader ch1 = lvwList.Columns.Add("USERCODE", 60, HorizontalAlignment.Left);
            ColumnHeader ch2 = lvwList.Columns.Add("Name", 100, HorizontalAlignment.Left);


        }

        private void m_txtOrderCate_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {

            if (lviSelected != null)
            {
                m_txtOrderCate.Text = lviSelected.SubItems[1].Text;
                m_txtOrderCate.Tag = ((clsOrderCate)lviSelected.Tag).m_objOrderCate.m_strORDERCATEID_CHR;
                for (int i = 0; i < this.m_cobOrderCate.Items.Count; i++)
                {
                    if (((clsOrderCate)this.m_cobOrderCate.Items[i]).m_objOrderCate.m_strORDERCATEID_CHR == ((clsOrderCate)lviSelected.Tag).m_objOrderCate.m_strORDERCATEID_CHR)
                    {
                        this.m_cobOrderCate.SelectedIndex = i;
                        break;
                    }

                }
                //自动显示窗体
                if (((clsOrderCate)lviSelected.Tag).m_objOrderCate.m_intAUTOSHOW_INT == 1)
                {
                    setTheControlOrder("m_txtRecipeNo");
                    m_txtOrderName.Text = "%";
                    SendKeys.Send("{Enter}");
                }
                else
                {
                    setTheControlOrder("m_txtRecipeNo");
                }
            }


        }

        private void m_txtOrderCate_DoubleClick(object sender, EventArgs e)
        {
            m_txtOrderCate.Text = "";
            SendKeys.Send("{Enter}");
        }


        internal void m_lblDosageType_Click(object sender, EventArgs e)
        {
            m_txtDosageType.Enabled = true;
            m_txtDosageType.Focus();
        }

        #region 特注信息查询
        private void m_lngREMARK_VCHR(string m_strFindCode)
        {
            DataTable objDT;
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            m_objService.m_lngGetORDERDESCByCode(m_strFindCode, out  objDT);
            frmORDERDESC frm = new frmORDERDESC(objDT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.m_txtREMARK_VCHR.Text = frm.getTheORDERDESC();
                this.m_txtREMARK_VCHR.SelectAll();
                SendKeys.Send("{Right}");
            }

        }
        #endregion
        private void m_txtREMARK_VCHR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && m_txtREMARK_VCHR.Text.Trim().StartsWith(@"/"))
            {
                string m_strFindCode = this.m_txtREMARK_VCHR.Text.TrimStart(@"/".ToCharArray());
                m_lngREMARK_VCHR(m_strFindCode);
                return;
            }
            else if (e.KeyCode == Keys.Enter && m_txtREMARK_VCHR.Text.Trim().StartsWith(@"\"))
            {
                int m_intStatue = 1;
                frmORDERDESC frm = new frmORDERDESC(m_intStatue, ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID, ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpName);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                setTheControlOrder(((TextBox)sender).Name);
            }
        }

        /// <summary>
        /// 常用项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mnuCommonItems_Click(object sender, EventArgs e)
        {
            string strFindCode = m_txtOrderName.Text.Trim().TrimStart(@"/".ToCharArray());
            m_lngCommonItems(strFindCode);
        }
        #region 各类诊疗项目查询
        /// <summary>
        /// 常用项目
        /// </summary>
        /// <param name="strFindCode"></param>
        private void m_lngCommonItems(string strFindCode)
        {

            //clsBIHOrderService m_objService = clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            //医嘱录入检查
            if (!((frmBIHOrderInput)this.ParentForm).m_OrderInputPreCheck())
            {
                return;
            }

            ArrayList m_arlItems = new ArrayList();

            // 得到诊疗对应的收费列表
            DataSet m_dsDicChargeSet = new DataSet();
            //查询类型
            int m_intClass = ((frmBIHOrderInput)this.ParentForm).seachClass.SelectedIndex;
            //医嘱类型
            string m_strORDERCATEID_CHR = "";
            m_strORDERCATEID_CHR = (string)m_txtOrderCate.Tag;

            //常用诊疗项目 组套 基本项目
            #region 常用诊疗项目 组套 基本项目
            clsBIHOrderDic[] arrDic = null;
            long ret2 = 0;
            string strEmpid_chr = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID;
            //基本项目
            m_strORDERCATEID_CHR = "";//不进行类型过滤
            ret2 = m_objService.m_lngGetCommonOrderDicChargeByCode(((frmBIHOrderInput)this.ParentForm).m_strMedDeptGross, strFindCode, strEmpid_chr, m_intClass, m_strORDERCATEID_CHR, ((frmBIHOrderInput)this.ParentForm).m_blLessMedControl, out arrDic, out m_dsDicChargeSet);

            //显示诊疗项目列表窗体
            if ((ret2 > 0) && (arrDic != null))
            {
                m_OrderDicListView(arrDic, m_dsDicChargeSet);
            }
            #endregion

        }
        /// <summary>
        /// 组套项目
        /// </summary>
        /// <param name="strFindCode"></param>
        private void m_lngGroupItems(string strFindCode)
        {

            //医嘱录入检查
            if (!((frmBIHOrderInput)this.ParentForm).m_OrderInputPreCheck())
            {
                return;
            }
            // 将医嘱所需的公共信息存一个医嘱VO中，为父医嘱窗体传递值使用
            clsBIHOrder bihOrder;
            SetTheBaseOrder(out bihOrder);
            //查询类型
            int m_intClass = ((frmBIHOrderInput)this.ParentForm).seachClass.SelectedIndex;

            long ret2 = 0;
            //组套 
            clsBIHOrderGroupService m_objService2 = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
            string strEmpid_chr = ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID;

            clsBIHOrderGroup[] arrGroup;
            long ret1 = m_objService2.m_lngFindGroup(strFindCode, (m_objCurrentDoctor == null ? "" : m_objCurrentDoctor.m_strDoctorID), ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strInpatientAreaID, m_intClass, out arrGroup);
            if ((ret1 > 0) && (arrGroup != null))
            {
                com.digitalwave.iCare.BIHOrder.frmBIHOrderGroupInput frmGroup = new frmBIHOrderGroupInput(arrGroup, bihOrder, ((frmBIHOrderInput)this.ParentForm).m_htOrderCate, ((frmBIHOrderInput)this.ParentForm).m_dtvOrder, ((frmBIHOrderInput)this.ParentForm).m_objSpecateVo, strFindCode, m_intClass, 0, ((frmBIHOrderInput)this.ParentForm).m_blStopControl, ((frmBIHOrderInput)this.ParentForm).m_blDeableMedControl, this);
                frmGroup.strPayType = ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient.m_strPayTypeID;
                if (frmGroup.ShowDialog() == DialogResult.OK)
                {
                    if (frmGroup.m_arrGroupOrder.Count > 0)
                    {
                        Hashtable m_htTable = new Hashtable();
                        for (int i = 0; i < frmGroup.m_arrGroupOrder.Count; i++)
                        {
                            ////设置领量
                            clsBIHOrder order = (clsBIHOrder)frmGroup.m_arrGroupOrder[i];
                            /*<=========================*/
                            //医嘱来源
                            order.m_intSOURCETYPE_INT = ((frmBIHOrderInput)this.ParentForm).m_intSOURCETYPE_INT;
                            /*<=========================================*/
                            //SetTheOrderGetOneUseMoust(ref order);
                            if (!m_htTable.Contains(order.m_intRecipenNo.ToString()))
                            {
                                order.m_intIFPARENTID_INT = 1;
                                m_htTable.Add(order.m_intRecipenNo.ToString(), order);
                            }

                        }
                        //同步同方医嘱的相关数据
                        for (int i = 0; i < frmGroup.m_arrGroupOrder.Count; i++)
                        {
                            //设置领量
                            clsBIHOrder order = (clsBIHOrder)frmGroup.m_arrGroupOrder[i];

                            if (m_htTable.Contains(order.m_intRecipenNo.ToString()))
                            {
                                clsBIHOrder order2 = (clsBIHOrder)m_htTable[order.m_intRecipenNo.ToString()];
                                order.m_intExecuteType = order2.m_intExecuteType;
                                order.m_strDosetypeID = order2.m_strDosetypeID;
                                order.m_strDosetypeName = order2.m_strDosetypeName;
                                order.m_strExecFreqID = order2.m_strExecFreqID;
                                order.m_strExecFreqName = order2.m_strExecFreqName;
                                order.m_intOUTGETMEDDAYS_INT = order2.m_intOUTGETMEDDAYS_INT;
                                order.m_intATTACHTIMES_INT = order2.m_intATTACHTIMES_INT;

                            }
                            SetTheOrderGetOneUseMoust(ref order);

                        }
                        /*<============================================*/
                        //clsBIHOrderService m_objService = clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
                        clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                        string[] strRecordIDArr = null;
                        try
                        {
                            m_objService.m_lngAddNewOrderByGroup(out strRecordIDArr, frmGroup.m_arrGroupOrder);
                            ((frmBIHOrderInput)this.ParentForm).cmdRefurbish_Click(null, null);
                        }
                        catch (Exception objEx)
                        {
                            MessageBox.Show(objEx.Message, "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                return;

            }


        }
        /// <summary>
        /// 新价查询
        /// </summary>
        /// <param name="strFindCode"></param>
        private void m_lngNewPriceItems(string strFindCode)
        {

            //医嘱录入检查
            if (!((frmBIHOrderInput)this.ParentForm).m_OrderInputPreCheck())
            {
                return;
            }
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            clsBIHOrderDic[] arrDic = null;
            long ret2 = 0;

            // 新价表
            frmItemStandardPrice price1 = new frmItemStandardPrice();
            if (price1.ShowDialog() == DialogResult.OK)
            {
                ret2 = m_objService.m_lngGetOrderDicByID(price1.m_strOrderDicId.ToString().Trim(), ((frmBIHOrderInput)this.ParentForm).m_strMedDeptGross, out arrDic);
                ListViewItem m_lviItem = new ListViewItem();
                m_lviItem.Tag = arrDic[0];
                clsCheckPart[] m_objPark = price1.m_checkPart;
                if (m_objPark != null && m_objPark.Length > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    for (int i = 0; i < m_objPark.Length; i++)
                    {
                        clsBIHOrderDic m_objOrderDic = (clsBIHOrderDic)(m_lviItem.Tag);
                        clsBIHOrder m_objOrder = m_objGetOrderByOrderDic(((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_objPatient, m_objOrderDic);
                        m_objOrder.m_strPARTID_VCHR = m_objPark[i].m_strPartID;
                        m_objOrder.m_strPARTNAME_VCHR = m_objPark[i].m_strPartName;
                        ((frmBIHOrderInput)this.ParentForm).m_objDomain.m_blnAddNew(m_objOrder);
                    }
                    this.Cursor = Cursors.Default;
                    ((frmBIHOrderInput)this.ParentForm).cmdRefurbish_Click(null, null);
                }
                else
                {
                    m_txtOrderName_m_evtSelectItem(null, m_lviItem);
                }
                return;
            }

            /*<======================================*/

        }
        /// <summary>
        /// 一般项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_lngNormalItems(string strFindCode)
        {

            //clsBIHOrderService m_objService = clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            //医嘱录入检查
            if (!((frmBIHOrderInput)this.ParentForm).m_OrderInputPreCheck())
            {
                return;
            }
            ArrayList m_arlItems = new ArrayList();
            DataSet m_dsDicChargeSet = new DataSet();
            /*<==========================*/
            //查询类型
            int m_intClass = ((frmBIHOrderInput)this.ParentForm).seachClass.SelectedIndex;
            //医嘱类型
            string m_strORDERCATEID_CHR = "";
            //m_strORDERCATEID_CHR = ((clsOrderCate)m_cobOrderCate.SelectedItem).m_objOrderCate.m_strORDERCATEID_CHR.ToString().Trim();
            m_strORDERCATEID_CHR = (string)m_txtOrderCate.Tag;
            clsBIHOrderDic[] arrDic = null;
            long ret2 = 0;
            ret2 = m_objService.m_lngGetOrderDicChargeByCode(strFindCode, m_intClass, m_strORDERCATEID_CHR, ((frmBIHOrderInput)this.ParentForm).m_blLessMedControl, ((frmBIHOrderInput)this.ParentForm).m_strMedDeptGross, out arrDic, out m_dsDicChargeSet);
            //ret2 = m_objService.m_lngGetOrderDicChargeByCode(strFindCode, m_intClass, m_strORDERCATEID_CHR, ((frmBIHOrderInput)this.ParentForm).m_blLessMedControl, out arrDic, out m_dsDicChargeSet);
            //显示诊疗项目列表窗体
            if ((ret2 > 0) && (arrDic != null))
            {
                m_OrderDicListView(arrDic, m_dsDicChargeSet);
            }


        }
        #endregion

        private void m_mnuGroupItems_Click(object sender, EventArgs e)
        {
            string strFindCode = m_txtOrderName.Text.Trim().TrimStart(@"\".ToCharArray());
            m_lngGroupItems(strFindCode); ;
        }

        /// <summary>
        /// 一般项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mnuNormalItems_Click(object sender, EventArgs e)
        {
            string strFindCode = m_txtOrderName.Text.Trim();
            m_lngNormalItems(strFindCode);


        }
        /// <summary>
        /// 新价项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mnuNewPriceItems_Click(object sender, EventArgs e)
        {

            string strFindCode = m_txtOrderName.Text.Trim().TrimStart(@"?".ToCharArray());
            m_lngNewPriceItems(strFindCode);

        }

        private void m_mnuNormalRemark_Click(object sender, EventArgs e)
        {
            //m_txtREMARK_VCHR.Text=@"/"+m_txtREMARK_VCHR.Text.Trim().TrimStart(@"/".ToCharArray());
            //m_txtREMARK_VCHR.Focus();
            //SendKeys.Send("{Enter}");
            string m_strFindCode = this.m_txtREMARK_VCHR.Text.TrimStart(@"/".ToCharArray());
            m_lngREMARK_VCHR(m_strFindCode);
        }

        private void m_mnuNormalAdd_Click(object sender, EventArgs e)
        {
            //string m_strOld = m_txtREMARK_VCHR.Text;
            //m_txtREMARK_VCHR.Text=@"\";
            //m_txtREMARK_VCHR.Focus();
            //SendKeys.Send("{Enter}");
            //m_txtREMARK_VCHR.Text = m_strOld;
            int m_intStatue = 1;
            frmORDERDESC frm = new frmORDERDESC(m_intStatue, ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID, ((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpName);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void m_txtCheck_DoubleClick(object sender, EventArgs e)
        {
            m_txtCheck.Text = "";
            SendKeys.Send("{Enter}");
        }

        private void m_txtSample_DoubleClick(object sender, EventArgs e)
        {
            m_txtSample.Text = "";
            SendKeys.Send("{Enter}");
        }



        private void m_txtDosageType_DoubleClick(object sender, EventArgs e)
        {

            m_txtDosageType.Text = "";
            SendKeys.Send("{Enter}");

        }

        private void m_txtExecuteFreq_DoubleClick(object sender, EventArgs e)
        {

            m_txtExecuteFreq.Text = "";
            SendKeys.Send("{Enter}");
        }


        private void m_lblExecuteFreq_DoubleClick(object sender, EventArgs e)
        {
            m_txtExecuteFreq.Enabled = true;
            m_txtExecuteFreq.ReadOnly = false;
            m_txtExecuteFreq.BackColor = Color.White;
            m_hideExecuteFreq.Visible = false;
        }

        private void m_lblDosageType_DoubleClick(object sender, EventArgs e)
        {
            m_txtDosageType.Enabled = true;
            m_txtDosageType.ReadOnly = false;
            m_txtDosageType.BackColor = Color.White;
            m_hideDosageType.Visible = false;
        }

        private void m_lblDosage_DoubleClick(object sender, EventArgs e)
        {
            m_txtDosage.Enabled = true;
            m_txtDosage.BackColor = Color.White;
            m_hideDosage.Visible = false;
            m_hideDosageUnit.Visible = false;
        }

        /// <summary>
        /// 设置皮试(用法是否需要其皮试)
        /// </summary>
        /// <param name="objOrder"></param>
        internal void SetTheOrderNeelFeel(ref clsBIHOrder objOrder)
        {
            // if (objOrder.m_intISNEEDFEEL == 1)
            // {
            if ((GetUsageVoByUsageID(objOrder.m_strDosetypeID)).m_intTEST_INT == 1)
            {
                objOrder.m_intISNEEDFEEL = 1;
            }
            else
            {
                objOrder.m_intISNEEDFEEL = 0;
            }
            // }
        }

        /// <summary>
        ///  //设置医嘱的特殊字段 如领量，皮试，界面修改标志
        /// </summary>
        /// <param name="objOrder"></param>
        internal void SetTheOrderSpecial(ref clsBIHOrder objOrder)
        {
            //设置领量
            SetTheOrderGetMoust(ref objOrder);
            //设置皮试
            SetTheOrderNeelFeel(ref objOrder);
            //设置修改标志
            SetTheOrderChargeTag(ref objOrder);
        }

        internal void SetTheOrderChargeTag(ref clsBIHOrder objOrder)
        {
            //特殊情况处理：如直接生成的医嘱不进行止方法
            if (objOrder.m_intCHARGE_INT == -1)
            {
                objOrder.m_intCHARGE_INT = 0;
                return;
            }
            /*<=========================*/
            objOrder.m_intCHARGE_INT = 0;
            clsT_aid_bih_ordercate_VO p_objItem;
            p_objItem = (clsT_aid_bih_ordercate_VO)((frmBIHOrderInput)this.ParentForm).m_htOrderCate[objOrder.m_strOrderDicCateID];
            if (p_objItem != null && p_objItem.m_intExecuFrenquenceType == 2 && m_hideExecuteFreq.Visible == false)
            {
                if (this.m_txtExecuteFreq.Enabled == true && this.m_txtExecuteFreq.ReadOnly == false)
                {
                    // 修改标志(0-普通状态,1-频率修改)
                    objOrder.m_intCHARGE_INT = 1;
                }
            }
            else if (objOrder.m_intExecuteType != 1 && m_txtExecuteFreq.Enabled == true && m_txtExecuteFreq.ReadOnly == false)
            {
                // 修改标志(0-普通状态,1-频率修改)
                objOrder.m_intCHARGE_INT = 1;
            }
        }

        private void m_txtExecuteFreq_Leave(object sender, EventArgs e)
        {
            //连续性频率界面处理
            if (m_txtExecuteFreq.Tag != null)
            {
                SetTheContinueFreqView(m_txtExecuteFreq.Tag.ToString());

            }
        }

        /// <summary>
        ///  //连续性频率界面处理
        /// </summary>
        /// <param name="m_strFREQID_CHR">频率ID</param>
        public void SetTheContinueFreqView(string m_strFREQID_CHR)
        {
            if (((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strCONFREQID_CHR.Trim().Equals(m_strFREQID_CHR))
            {
                m_txtDosageControl(false);
                m_txtDosageTypeControl(false);
                //写死剂量和用量
                //m_txtDosage.Text = "1";
                //m_txtDosage.Enabled = false;
                //m_txtGet.Text = "1";
                //m_txtGet2.Text = "";
                //m_txtGet.Enabled = false;
                //m_txtUse.Text = "1";
            }


        }

        private void m_txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_txtArea.Focus();
            }
        }

        private void m_txtBedNo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                ((frmBIHOrderInput)this.ParentForm).m_ctlPatient.m_txtArea.Focus();
            }
        }

        private void m_txtDosage_Leave(object sender, EventArgs e)
        {

            #region 剂量控制
            double dbl1 = -1;
            if (m_txtDosage.Text.Trim() != "")
            {
                try
                {
                    dbl1 = double.Parse(m_txtDosage.Text.Trim());
                }
                catch { }
            }
            string strFreqID = clsConverter.ToString(m_txtExecuteFreq.Tag);
            if (m_objTempFreq == null)
            {
                m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
            }
            else if (m_objTempFreq.m_strFreqID.Trim() != strFreqID.Trim())
            {
                m_objTempFreq = GetFreqVoByFreqID(strFreqID.Trim());
            }

            #endregion
            //连续性医嘱的医嘱，领量强制为单位的量，频率次数为1
            if (dbl1 != 1 && m_objTempFreq != null && m_objTempFreq.m_strFreqID.Trim().Equals(((frmBIHOrderInput)this.ParentForm).m_objSpecateVo.m_strCONFREQID_CHR.Trim()))
            {
                MessageBox.Show("连续性医嘱剂量只能是1", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtDosage.Text = "1";
                m_txtDosage.Focus();
                m_txtDosage.SelectAll();
                return;
            }
        }

        private void cboShiying_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setTheControlOrder(((com.digitalwave.controls.ctlQComboBox)sender).Name);
            }
        }

        private void cboKJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setTheControlOrder("cboKJ");
            }
        }

        private void cboQK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setTheControlOrder("cboQK");
            }
        }

        private void txtCureDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setTheControlOrder("txtCureDays");
            }
        }

        private void cboProxyBoil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setTheControlOrder("cboProxyBoil");
            }
        }

    }
}

