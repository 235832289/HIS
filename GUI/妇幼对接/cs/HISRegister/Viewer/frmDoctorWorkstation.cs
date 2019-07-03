using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HI;
//using com.digitalwave.iCare.Template.Client;
using com.digitalwave.iCare.ValueObject;
//using com.digitalwave.CustomFormService;
using iCareData;
using iCare.CustomForm;
using System.Drawing.Printing;
using iCare;
using System.Reflection;
using System.Data;
using com.digitalwave.controls.DGCS;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// frmDoctorWorkstation 门诊医生工作站。
    /// </summary>
    public class frmDoctorWorkstation : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary> 
        /// 处理快捷键输入 true 取消,false输入
        /// </summary>
        internal bool HandleInput = false;
        /// <summary>
        /// 记录中文输入法
        /// </summary>
        private InputLanguage myInputLanguage = InputLanguage.DefaultInputLanguage;
        /// <summary>
        /// 是否开分门诊西药房和急诊药房，0为合并，1为分开
        /// </summary>
        public int IsDetachWMedStore = 0;
        #region 全局变量,保存datagrid输入数据时的行号,为了不回车也能计算金额,-1代表不计算
        public int intRowNo1 = -1;//西药
        public int intRowNo2 = -1;//中药
        public int intRowNo3 = -1;//检验
        public int intRowNo4 = -1;//检查
        public int intRowNo5 = -1;//手术
        public int intRowNo6 = -1;//其他
        public int intRowNoLis = -1;//检验诊疗项目
        public int intRowNoTest = -1;//检查诊疗项目
        public int intRowNoOps = -1;//手术治疗诊疗项目
        #endregion
        //		private clsTemplateClient m_objTemplate;
        private System.Windows.Forms.Panel panel1;
        internal com.digitalwave.controls.ctlPatientBasicInfo m_PatInfo;
        internal Panel panel2;
        internal System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Splitter splitter1;
        internal System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        internal TabPage tabPage5;
        internal TabPage tabPage6;
        internal TabPage tabPage7;
        internal TabPage tabPage8;
        private System.Windows.Forms.Panel panel3;
        internal TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.GroupBox groupBox1;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid1;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid2;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid3;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid4;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid5;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid6;
        internal System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label lbeSumMoney;
        internal com.digitalwave.controls.ctlCooking cmbCooking;
        internal PinkieControls.ButtonXP BtExit;
        internal PinkieControls.ButtonXP btClear;
        internal PinkieControls.ButtonXP btSave;
        internal System.Windows.Forms.ComboBox m_cmbFind;
        internal System.Windows.Forms.ComboBox m_cmbRecipeType;
        internal System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        internal System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        internal PinkieControls.ButtonXP btPrint;
        internal PinkieControls.ButtonXP btDel;
        internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgWaitReg;
        internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgTake;
        internal System.Windows.Forms.Label lbeChargeUp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIsVip;
        internal System.Windows.Forms.Label lbeSelfPay;
        private System.Windows.Forms.Label label23;
        internal PinkieControls.ButtonXP m_btnEndTake;
        internal PinkieControls.ButtonXP m_btnBackWait;
        internal PinkieControls.ButtonXP m_btnRefReg;
        internal System.Windows.Forms.ComboBox cmbFindAccordRecipe;
        internal System.Windows.Forms.TextBox txtFindAccordRecipe;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        internal System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        internal com.digitalwave.controls.AlertLight alertLight1;
        private System.Windows.Forms.GroupBox groupBox6;
        internal System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btAssistantDiagnose;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        internal PinkieControls.ButtonXP btReUse;
        internal com.digitalwave.controls.DGCS.txtLoadRecipeNo txtLoadRecipeNo1;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Label FF;
        internal System.Windows.Forms.Label EE;
        internal System.Windows.Forms.Label DD;
        internal System.Windows.Forms.Label CC;
        internal System.Windows.Forms.Label BB;
        internal System.Windows.Forms.Label AA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        internal System.Windows.Forms.Label lbeTimes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal PinkieControls.ButtonXP btCaseyHistory;
        internal System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        internal PinkieControls.ButtonXP btInject;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        internal PinkieControls.ButtonXP btNew;
        internal PinkieControls.ButtonXP btReGroup;
        internal frmCaseHistory objCaseHistory;
        internal PinkieControls.ButtonXP btCaseHistory;
        internal PinkieControls.ButtonXP btPutIn;
        internal System.Windows.Forms.ComboBox cmbRecipeType;
        internal System.Windows.Forms.Label lbeFlag;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ToolTip toolTip1;
        internal com.digitalwave.iCare.gui.HIS.exComboBox cmbDeparment;
        internal System.Windows.Forms.RadioButton ra_Person;
        internal System.Windows.Forms.RadioButton ra_department;
        internal System.Windows.Forms.RadioButton ra_both;
        internal PinkieControls.ButtonXP btSelect;
        internal System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.Label lblFunction;
        internal System.Windows.Forms.ContextMenu ctmDel;
        private System.Windows.Forms.MenuItem mniDelAll;
        private System.Windows.Forms.MenuItem mniDelCash;
        private System.Windows.Forms.MenuItem muiDelRec;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.ComponentModel.IContainer components;
        private clsDcl_DoctorWorkstation objDclDoctor;

        #region 列参
        private int intURGENCY_INT = 0;

        #endregion

        internal System.Windows.Forms.ContextMenu ctmPat;
        internal System.Windows.Forms.MenuItem muiInfo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.LinkLabel llblDate;
        private System.Windows.Forms.Label lblToday;
        internal PinkieControls.ButtonXP btnSelect;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.DateTimePicker dtpEnd;
        internal System.Windows.Forms.DateTimePicker dtpBegin;
        internal System.Windows.Forms.Label lblEnd;
        internal System.Windows.Forms.Label lblBegin;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label lblPersonTimes;

        private int intMedDays = 0;
        private System.Windows.Forms.Timer timer;
        internal frmAllergichint frmAllergich;
        internal PictureBox picops;
        internal PictureBox picris;
        internal PictureBox piclis;
        internal Label label13;
        internal Label label12;
        internal Label label11;
        private Timer timerrec;
        internal frmAllergiclist frmAllergicl;
        internal ComboBox cboquick;
        private ColumnHeader columnHeader26;
        internal PinkieControls.ButtonXP btnRecalc;
        internal ComboBox cboDeptmed1;
        internal ComboBox cboDeptmed2;
        internal ComboBox cboDeptmed6;
        private Timer timerRecpur;
        private Label label16;
        private Label label15;
        private Label label14;
        private GroupBox groupBox3;
        private ColumnHeader columnHeader27;
        internal frmRecipeconfirmfalllist frmRecconf;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGridLis;
        internal Panel plLis;
        private Label label17;
        private PictureBox pictureBox2;
        internal ListView lvLis;
        private ColumnHeader columnHeader28;
        private ColumnHeader columnHeader29;
        private ColumnHeader columnHeader30;
        private ColumnHeader columnHeader31;
        private ColumnHeader columnHeader32;
        private Label label18;
        private Panel panel5;
        private Panel panel6;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGridTest;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGridOps;
        internal Panel panel7;
        private Panel panel8;
        private Label label19;
        private ColumnHeader columnHeader33;
        private ColumnHeader columnHeader34;
        private ColumnHeader columnHeader35;
        private ColumnHeader columnHeader36;
        private ColumnHeader columnHeader37;
        internal Panel panel9;
        private Panel panel10;
        private Label label25;
        internal Panel plTest;
        private Panel panel12;
        private Label label20;
        internal ListView lvTest;
        private ColumnHeader columnHeader43;
        private ColumnHeader columnHeader44;
        private ColumnHeader columnHeader45;
        private ColumnHeader columnHeader46;
        private ColumnHeader columnHeader47;
        private Panel panel13;
        private Label label28;
        private PictureBox pictureBox3;
        internal Panel plOps;
        private Panel panel14;
        private Label label27;
        internal ListView lvOps;
        private ColumnHeader columnHeader38;
        private ColumnHeader columnHeader39;
        private ColumnHeader columnHeader40;
        private ColumnHeader columnHeader41;
        private ColumnHeader columnHeader42;
        private Panel panel15;
        private Label label29;
        private PictureBox pictureBox4;
        private ColumnHeader columnHeader48;
        private ColumnHeader columnHeader49;
        private ColumnHeader columnHeader50;
        private ColumnHeader columnHeader51;
        private ColumnHeader columnHeader52;
        private ColumnHeader columnHeader53;
        private DiagnoseClient.frmDiagClientMain frmDiag = null;
        private Label label30;
        internal Label lbeSbAccPay;
        internal PinkieControls.ButtonXP btnPrefer;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiDrugInfo;
        private Label label31;
        internal TextBox txtWeight;
        internal ComboBox cboProxyBoilMed;
        private Label label32;
        internal PinkieControls.ButtonXP btnBooking;
        internal PinkieControls.ButtonXP btnWAC;
        private bool DelRecGroupFlag = false;

        public frmDoctorWorkstation()
        {

            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            this.m_PatInfo.HotKey = "F2";

            this.tabControl1_SelectedIndexChanged(null, null);
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            objCaseHistory = new frmCaseHistory();
            objCaseHistory.TopLevel = false;
            this.groupBox1.Controls.Add(objCaseHistory);
            objCaseHistory.Dock = DockStyle.Fill;
            objCaseHistory.Show();
            objCaseHistory.BringToFront();

            objDclDoctor = new clsDcl_DoctorWorkstation();
            frmAllergich = new frmAllergichint();
            frmAllergicl = new frmAllergiclist();
            frmRecconf = new frmRecipeconfirmfalllist();
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

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoctorWorkstation));
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo6 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo7 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo8 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo9 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo10 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo11 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo12 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo13 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo14 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo15 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo16 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo17 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo18 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo19 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo20 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo21 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo22 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo23 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo24 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo25 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo26 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo27 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo28 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo29 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo30 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo31 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo32 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo33 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo34 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo35 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo36 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo37 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo38 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo39 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo40 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo41 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo42 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo43 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo44 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo45 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo46 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo47 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo48 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo49 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo50 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo51 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo52 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo53 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo54 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo55 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo56 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo57 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo58 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo59 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo60 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo61 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo62 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo63 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo64 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo65 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo66 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo67 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo68 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo69 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo70 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo71 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo72 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo73 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo74 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo75 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo76 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo77 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo78 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo79 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo80 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo81 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo82 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo83 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo84 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo85 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo86 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo87 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo88 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo89 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo90 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo91 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo92 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo93 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo94 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo95 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo96 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo97 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo98 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo99 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo100 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo101 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo102 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo103 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo104 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo105 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo106 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo107 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo108 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo109 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo110 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo111 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo112 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo113 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo114 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo115 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo116 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo117 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo118 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo119 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo120 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo121 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo122 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo123 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo124 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo125 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo126 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo127 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo128 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo129 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo130 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo131 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo132 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo133 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo134 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo135 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo136 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo137 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo138 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo139 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo140 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo141 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo142 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo143 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo144 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo145 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo146 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo147 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo148 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo149 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo150 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo151 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo152 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo153 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo154 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo155 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo156 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo157 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo158 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo159 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo160 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo161 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo162 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo163 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo164 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo165 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo166 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo167 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo168 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo169 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo170 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo171 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo172 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo173 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo174 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo175 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo176 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo177 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo178 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo179 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo180 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo181 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo182 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo183 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo184 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo185 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo186 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo187 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo188 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo189 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo190 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo191 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo192 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo193 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo194 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo195 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo196 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo197 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo198 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo199 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo200 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo201 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo202 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo203 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo204 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo205 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo206 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo207 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo208 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo209 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo210 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo211 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo212 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo213 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo214 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo215 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo216 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo217 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo218 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo219 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo220 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo221 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo222 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo223 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo224 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo225 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo226 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo227 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo228 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo229 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo230 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo231 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo232 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo233 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo234 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo235 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo236 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo237 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo238 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo239 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo240 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo241 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo242 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo243 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo244 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo245 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo246 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo247 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo248 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo249 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo250 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo251 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo252 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo253 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo254 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo255 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo256 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo257 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo258 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo259 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo260 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo261 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo262 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo263 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo264 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo265 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo266 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo267 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo268 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo269 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.ctmPat = new System.Windows.Forms.ContextMenu();
            this.muiInfo = new System.Windows.Forms.MenuItem();
            this.cboquick = new System.Windows.Forms.ComboBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbDeparment = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.ra_both = new System.Windows.Forms.RadioButton();
            this.ra_department = new System.Windows.Forms.RadioButton();
            this.ra_Person = new System.Windows.Forms.RadioButton();
            this.cmbCooking = new com.digitalwave.controls.ctlCooking();
            this.txtLoadRecipeNo1 = new com.digitalwave.controls.DGCS.txtLoadRecipeNo();
            this.m_cmbFind = new System.Windows.Forms.ComboBox();
            this.btnRecalc = new PinkieControls.ButtonXP();
            this.picops = new System.Windows.Forms.PictureBox();
            this.picris = new System.Windows.Forms.PictureBox();
            this.piclis = new System.Windows.Forms.PictureBox();
            this.m_cmbRecipeType = new System.Windows.Forms.ComboBox();
            this.ctmDel = new System.Windows.Forms.ContextMenu();
            this.mniDelAll = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mniDelCash = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.muiDelRec = new System.Windows.Forms.MenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerrec = new System.Windows.Forms.Timer(this.components);
            this.columnHeader33 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader34 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader35 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader36 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader37 = new System.Windows.Forms.ColumnHeader();
            this.cboDeptmed1 = new System.Windows.Forms.ComboBox();
            this.cboDeptmed2 = new System.Windows.Forms.ComboBox();
            this.cboDeptmed6 = new System.Windows.Forms.ComboBox();
            this.timerRecpur = new System.Windows.Forms.Timer(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.lbeTimes = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.alertLight1 = new com.digitalwave.controls.AlertLight();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_dtgWaitReg = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btSelect = new PinkieControls.ButtonXP();
            this.m_btnRefReg = new PinkieControls.ButtonXP();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_dtgTake = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblPersonTimes = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSelect = new PinkieControls.ButtonXP();
            this.lblToday = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblBegin = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.llblDate = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAssistantDiagnose = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.ctlDataGrid1 = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDrugInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.ctlDataGrid2 = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.listView5 = new System.Windows.Forms.ListView();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.ctlDataGridLis = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.ctlDataGrid3 = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.plLis = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.lvLis = new System.Windows.Forms.ListView();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader32 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader48 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader51 = new System.Windows.Forms.ColumnHeader();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.plTest = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.lvTest = new System.Windows.Forms.ListView();
            this.columnHeader43 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader44 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader45 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader46 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader47 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader49 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader52 = new System.Windows.Forms.ColumnHeader();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.ctlDataGridTest = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.ctlDataGrid4 = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.plOps = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.lvOps = new System.Windows.Forms.ListView();
            this.columnHeader38 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader39 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader40 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader41 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader42 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader50 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader53 = new System.Windows.Forms.ColumnHeader();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.ctlDataGridOps = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.ctlDataGrid5 = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.ctlDataGrid6 = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.FF = new System.Windows.Forms.Label();
            this.EE = new System.Windows.Forms.Label();
            this.DD = new System.Windows.Forms.Label();
            this.CC = new System.Windows.Forms.Label();
            this.BB = new System.Windows.Forms.Label();
            this.AA = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnWAC = new PinkieControls.ButtonXP();
            this.btnBooking = new PinkieControls.ButtonXP();
            this.cboProxyBoilMed = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.btnPrefer = new PinkieControls.ButtonXP();
            this.lbeSbAccPay = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbRecipeType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbeFlag = new System.Windows.Forms.Label();
            this.btPutIn = new PinkieControls.ButtonXP();
            this.btCaseHistory = new PinkieControls.ButtonXP();
            this.btReGroup = new PinkieControls.ButtonXP();
            this.btNew = new PinkieControls.ButtonXP();
            this.btInject = new PinkieControls.ButtonXP();
            this.btCaseyHistory = new PinkieControls.ButtonXP();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbeSelfPay = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbeChargeUp = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtExit = new PinkieControls.ButtonXP();
            this.btClear = new PinkieControls.ButtonXP();
            this.lbeSumMoney = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btSave = new PinkieControls.ButtonXP();
            this.m_btnEndTake = new PinkieControls.ButtonXP();
            this.btPrint = new PinkieControls.ButtonXP();
            this.m_btnBackWait = new PinkieControls.ButtonXP();
            this.btDel = new PinkieControls.ButtonXP();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtFindAccordRecipe = new System.Windows.Forms.TextBox();
            this.cmbFindAccordRecipe = new System.Windows.Forms.ComboBox();
            this.btReUse = new PinkieControls.ButtonXP();
            this.lblIsVip = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.m_PatInfo = new com.digitalwave.controls.ctlPatientBasicInfo();
            ((System.ComponentModel.ISupportInitialize)(this.picops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclis)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgWaitReg)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgTake)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid2)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGridLis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid3)).BeginInit();
            this.plLis.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.plTest.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGridTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid4)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.plOps.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGridOps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid5)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid6)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctmPat
            // 
            this.ctmPat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muiInfo});
            // 
            // muiInfo
            // 
            this.muiInfo.Index = 0;
            this.muiInfo.Text = "既往就诊资料";
            this.muiInfo.Click += new System.EventHandler(this.muiInfo_Click);
            // 
            // cboquick
            // 
            this.cboquick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboquick.Font = new System.Drawing.Font("宋体", 11F);
            this.cboquick.FormattingEnabled = true;
            this.cboquick.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cboquick.Location = new System.Drawing.Point(764, 52);
            this.cboquick.Name = "cboquick";
            this.cboquick.Size = new System.Drawing.Size(56, 23);
            this.cboquick.TabIndex = 37;
            this.cboquick.SelectedIndexChanged += new System.EventHandler(this.cboquick_SelectedIndexChanged);
            this.cboquick.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboquick_KeyDown);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // cmbDeparment
            // 
            this.cmbDeparment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeparment.Enabled = false;
            this.cmbDeparment.Location = new System.Drawing.Point(288, 17);
            this.cmbDeparment.Name = "cmbDeparment";
            this.cmbDeparment.Size = new System.Drawing.Size(192, 22);
            this.cmbDeparment.TabIndex = 24;
            this.toolTip1.SetToolTip(this.cmbDeparment, "选择科室后可直接回车");
            this.cmbDeparment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDeparment_KeyDown);
            // 
            // ra_both
            // 
            this.ra_both.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ra_both.Location = new System.Drawing.Point(176, 18);
            this.ra_both.Name = "ra_both";
            this.ra_both.Size = new System.Drawing.Size(96, 24);
            this.ra_both.TabIndex = 2;
            this.ra_both.Text = "个人和科室";
            this.toolTip1.SetToolTip(this.ra_both, "只显示挂号到当前登陆医生和科室的病人");
            this.ra_both.CheckedChanged += new System.EventHandler(this.ra_Person_CheckedChanged);
            // 
            // ra_department
            // 
            this.ra_department.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ra_department.Location = new System.Drawing.Point(104, 18);
            this.ra_department.Name = "ra_department";
            this.ra_department.Size = new System.Drawing.Size(88, 24);
            this.ra_department.TabIndex = 1;
            this.ra_department.Text = "科室";
            this.toolTip1.SetToolTip(this.ra_department, "显示挂号到当前登陆医生所属科室的病人");
            this.ra_department.CheckedChanged += new System.EventHandler(this.ra_Person_CheckedChanged);
            // 
            // ra_Person
            // 
            this.ra_Person.Checked = true;
            this.ra_Person.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ra_Person.Location = new System.Drawing.Point(32, 18);
            this.ra_Person.Name = "ra_Person";
            this.ra_Person.Size = new System.Drawing.Size(72, 24);
            this.ra_Person.TabIndex = 0;
            this.ra_Person.TabStop = true;
            this.ra_Person.Text = "个人";
            this.toolTip1.SetToolTip(this.ra_Person, "只显示挂号到当前登陆医生的病人");
            this.ra_Person.CheckedChanged += new System.EventHandler(this.ra_Person_CheckedChanged);
            // 
            // cmbCooking
            // 
            this.cmbCooking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCooking.CookID = "";
            this.cmbCooking.CookName = "";
            this.cmbCooking.Location = new System.Drawing.Point(47, 378);
            this.cmbCooking.MaxLength = 200;
            this.cmbCooking.Name = "cmbCooking";
            this.cmbCooking.Size = new System.Drawing.Size(665, 22);
            this.cmbCooking.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cmbCooking, "中药整剂用法");
            // 
            // txtLoadRecipeNo1
            // 
            this.txtLoadRecipeNo1.Location = new System.Drawing.Point(8, 76);
            this.txtLoadRecipeNo1.Name = "txtLoadRecipeNo1";
            this.txtLoadRecipeNo1.Size = new System.Drawing.Size(151, 25);
            this.txtLoadRecipeNo1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtLoadRecipeNo1, "输入处方号或直接回车选择处方号");
            this.txtLoadRecipeNo1.RecipeSelected += new System.EventHandler(this.txtLoadRecipeNo1_RecipeSelected);
            // 
            // m_cmbFind
            // 
            this.m_cmbFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFind.Items.AddRange(new object[] {
            "编号",
            "项目名称",
            "拼音码",
            "五笔码",
            "英文名"});
            this.m_cmbFind.Location = new System.Drawing.Point(8, 26);
            this.m_cmbFind.Name = "m_cmbFind";
            this.m_cmbFind.Size = new System.Drawing.Size(151, 22);
            this.m_cmbFind.TabIndex = 0;
            this.toolTip1.SetToolTip(this.m_cmbFind, "查询项目条件");
            this.m_cmbFind.SelectedIndexChanged += new System.EventHandler(this.m_cmbFind_SelectedIndexChanged);
            // 
            // btnRecalc
            // 
            this.btnRecalc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRecalc.DefaultScheme = true;
            this.btnRecalc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRecalc.Hint = "";
            this.btnRecalc.Location = new System.Drawing.Point(6, 406);
            this.btnRecalc.Name = "btnRecalc";
            this.btnRecalc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRecalc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRecalc.Size = new System.Drawing.Size(73, 32);
            this.btnRecalc.TabIndex = 47;
            this.btnRecalc.Text = "重算(&C)";
            this.toolTip1.SetToolTip(this.btnRecalc, "重新计算检验项目带出的子项目费用");
            this.btnRecalc.Click += new System.EventHandler(this.btnRecalc_Click);
            // 
            // picops
            // 
            this.picops.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picops.Image = ((System.Drawing.Image)(resources.GetObject("picops.Image")));
            this.picops.Location = new System.Drawing.Point(104, 21);
            this.picops.Name = "picops";
            this.picops.Size = new System.Drawing.Size(30, 30);
            this.picops.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picops.TabIndex = 6;
            this.picops.TabStop = false;
            this.toolTip1.SetToolTip(this.picops, "手术申请单");
            this.picops.Visible = false;
            this.picops.MouseLeave += new System.EventHandler(this.picops_MouseLeave);
            this.picops.Click += new System.EventHandler(this.picops_Click);
            this.picops.MouseEnter += new System.EventHandler(this.picops_MouseEnter);
            // 
            // picris
            // 
            this.picris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picris.Image = ((System.Drawing.Image)(resources.GetObject("picris.Image")));
            this.picris.Location = new System.Drawing.Point(58, 21);
            this.picris.Name = "picris";
            this.picris.Size = new System.Drawing.Size(30, 30);
            this.picris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picris.TabIndex = 5;
            this.picris.TabStop = false;
            this.toolTip1.SetToolTip(this.picris, "检查申请单");
            this.picris.Visible = false;
            this.picris.MouseLeave += new System.EventHandler(this.picris_MouseLeave);
            this.picris.Click += new System.EventHandler(this.picris_Click);
            this.picris.MouseEnter += new System.EventHandler(this.picris_MouseEnter);
            // 
            // piclis
            // 
            this.piclis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.piclis.Image = ((System.Drawing.Image)(resources.GetObject("piclis.Image")));
            this.piclis.Location = new System.Drawing.Point(12, 21);
            this.piclis.Name = "piclis";
            this.piclis.Size = new System.Drawing.Size(30, 30);
            this.piclis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piclis.TabIndex = 4;
            this.piclis.TabStop = false;
            this.toolTip1.SetToolTip(this.piclis, "检验申请单");
            this.piclis.Visible = false;
            this.piclis.MouseLeave += new System.EventHandler(this.piclis_MouseLeave);
            this.piclis.Click += new System.EventHandler(this.piclis_Click);
            this.piclis.MouseEnter += new System.EventHandler(this.piclis_MouseEnter);
            // 
            // m_cmbRecipeType
            // 
            this.m_cmbRecipeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRecipeType.Items.AddRange(new object[] {
            "正方",
            "副方"});
            this.m_cmbRecipeType.Location = new System.Drawing.Point(89, 106);
            this.m_cmbRecipeType.Name = "m_cmbRecipeType";
            this.m_cmbRecipeType.Size = new System.Drawing.Size(60, 22);
            this.m_cmbRecipeType.TabIndex = 1;
            this.toolTip1.SetToolTip(this.m_cmbRecipeType, "选择处方的类型");
            this.m_cmbRecipeType.Visible = false;
            this.m_cmbRecipeType.SelectedIndexChanged += new System.EventHandler(this.m_cmbRecipeType_SelectedIndexChanged);
            // 
            // ctmDel
            // 
            this.ctmDel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniDelAll,
            this.menuItem4,
            this.mniDelCash,
            this.menuItem5,
            this.muiDelRec});
            // 
            // mniDelAll
            // 
            this.mniDelAll.Index = 0;
            this.mniDelAll.Text = "删除病历和处方";
            this.mniDelAll.Click += new System.EventHandler(this.mniDelAll_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // mniDelCash
            // 
            this.mniDelCash.Index = 2;
            this.mniDelCash.Text = "删除病历";
            this.mniDelCash.Click += new System.EventHandler(this.mniDelCash_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "-";
            // 
            // muiDelRec
            // 
            this.muiDelRec.Index = 4;
            this.muiDelRec.Text = "删除处方";
            this.muiDelRec.Click += new System.EventHandler(this.muiDelRec_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerrec
            // 
            this.timerrec.Tick += new System.EventHandler(this.timerrec_Tick);
            // 
            // columnHeader33
            // 
            this.columnHeader33.Width = 28;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Width = 137;
            // 
            // columnHeader35
            // 
            this.columnHeader35.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader35.Width = 54;
            // 
            // columnHeader36
            // 
            this.columnHeader36.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader36.Width = 55;
            // 
            // columnHeader37
            // 
            this.columnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader37.Width = 64;
            // 
            // cboDeptmed1
            // 
            this.cboDeptmed1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptmed1.Font = new System.Drawing.Font("宋体", 11F);
            this.cboDeptmed1.FormattingEnabled = true;
            this.cboDeptmed1.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cboDeptmed1.Location = new System.Drawing.Point(604, 168);
            this.cboDeptmed1.Name = "cboDeptmed1";
            this.cboDeptmed1.Size = new System.Drawing.Size(56, 23);
            this.cboDeptmed1.TabIndex = 36;
            this.cboDeptmed1.SelectedIndexChanged += new System.EventHandler(this.cboDeptmed1_SelectedIndexChanged);
            this.cboDeptmed1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDeptmed1_KeyDown);
            // 
            // cboDeptmed2
            // 
            this.cboDeptmed2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptmed2.Font = new System.Drawing.Font("宋体", 11F);
            this.cboDeptmed2.FormattingEnabled = true;
            this.cboDeptmed2.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cboDeptmed2.Location = new System.Drawing.Point(432, 256);
            this.cboDeptmed2.Name = "cboDeptmed2";
            this.cboDeptmed2.Size = new System.Drawing.Size(56, 23);
            this.cboDeptmed2.TabIndex = 38;
            this.cboDeptmed2.SelectedIndexChanged += new System.EventHandler(this.cboDeptmed2_SelectedIndexChanged);
            this.cboDeptmed2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDeptmed2_KeyDown);
            // 
            // cboDeptmed6
            // 
            this.cboDeptmed6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptmed6.Font = new System.Drawing.Font("宋体", 11F);
            this.cboDeptmed6.FormattingEnabled = true;
            this.cboDeptmed6.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cboDeptmed6.Location = new System.Drawing.Point(336, 172);
            this.cboDeptmed6.Name = "cboDeptmed6";
            this.cboDeptmed6.Size = new System.Drawing.Size(56, 23);
            this.cboDeptmed6.TabIndex = 36;
            this.cboDeptmed6.SelectedIndexChanged += new System.EventHandler(this.cboDeptmed6_SelectedIndexChanged);
            this.cboDeptmed6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDeptmed6_KeyDown);
            // 
            // timerRecpur
            // 
            this.timerRecpur.Tick += new System.EventHandler(this.timerRecpur_Tick);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(787, 101);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 12);
            this.label26.TabIndex = 32;
            this.label26.Text = "次就诊";
            // 
            // lbeTimes
            // 
            this.lbeTimes.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.lbeTimes.ForeColor = System.Drawing.Color.Black;
            this.lbeTimes.Location = new System.Drawing.Point(770, 100);
            this.lbeTimes.Name = "lbeTimes";
            this.lbeTimes.Size = new System.Drawing.Size(18, 14);
            this.lbeTimes.TabIndex = 31;
            this.lbeTimes.Text = "1";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(752, 101);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 30;
            this.label24.Text = "第";
            // 
            // alertLight1
            // 
            this.alertLight1.IsTabu = true;
            this.alertLight1.Location = new System.Drawing.Point(704, 97);
            this.alertLight1.Name = "alertLight1";
            this.alertLight1.Size = new System.Drawing.Size(32, 16);
            this.alertLight1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 503);
            this.panel2.TabIndex = 25;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.tabControl1.Location = new System.Drawing.Point(0, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 440);
            this.tabControl1.TabIndex = 34;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_dtgWaitReg);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(842, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "[0]候诊";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_dtgWaitReg
            // 
            this.m_dtgWaitReg.AllowAddNew = false;
            this.m_dtgWaitReg.AllowDelete = false;
            this.m_dtgWaitReg.AutoAppendRow = false;
            this.m_dtgWaitReg.AutoScroll = true;
            this.m_dtgWaitReg.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgWaitReg.CaptionText = "";
            this.m_dtgWaitReg.CaptionVisible = false;
            this.m_dtgWaitReg.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "WAITDIAGLISTID_CHR";
            clsColumnInfo1.ColumnWidth = 0;
            clsColumnInfo1.Enabled = false;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "候诊ID";
            clsColumnInfo1.ReadOnly = true;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "REGISTERNO_CHR";
            clsColumnInfo2.ColumnWidth = 100;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "流水号";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "ORDER_INT";
            clsColumnInfo3.ColumnWidth = 100;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "候诊队号";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "PATIENTCARDID_CHR";
            clsColumnInfo4.ColumnWidth = 100;
            clsColumnInfo4.Enabled = false;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "诊疗卡号";
            clsColumnInfo4.ReadOnly = true;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo5.BackColor = System.Drawing.Color.White;
            clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo5.ColumnIndex = 4;
            clsColumnInfo5.ColumnName = "LASTNAME_VCHR";
            clsColumnInfo5.ColumnWidth = 100;
            clsColumnInfo5.Enabled = false;
            clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo5.HeadText = "病人名称";
            clsColumnInfo5.ReadOnly = true;
            clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo6.BackColor = System.Drawing.Color.White;
            clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo6.ColumnIndex = 5;
            clsColumnInfo6.ColumnName = "SEX_CHR";
            clsColumnInfo6.ColumnWidth = 50;
            clsColumnInfo6.Enabled = false;
            clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo6.HeadText = "性别";
            clsColumnInfo6.ReadOnly = true;
            clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo7.BackColor = System.Drawing.Color.White;
            clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo7.ColumnIndex = 6;
            clsColumnInfo7.ColumnName = "BIRTH_DAT";
            clsColumnInfo7.ColumnWidth = 60;
            clsColumnInfo7.Enabled = false;
            clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo7.HeadText = "年龄";
            clsColumnInfo7.ReadOnly = true;
            clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo8.BackColor = System.Drawing.Color.White;
            clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo8.ColumnIndex = 7;
            clsColumnInfo8.ColumnName = "PAYTYPENAME_VCHR";
            clsColumnInfo8.ColumnWidth = 100;
            clsColumnInfo8.Enabled = false;
            clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo8.HeadText = "病人类型";
            clsColumnInfo8.ReadOnly = true;
            clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo9.BackColor = System.Drawing.Color.White;
            clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo9.ColumnIndex = 8;
            clsColumnInfo9.ColumnName = "DEPTNAME_VCHR";
            clsColumnInfo9.ColumnWidth = 100;
            clsColumnInfo9.Enabled = false;
            clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo9.HeadText = "挂号科室";
            clsColumnInfo9.ReadOnly = true;
            clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo10.BackColor = System.Drawing.Color.White;
            clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo10.ColumnIndex = 9;
            clsColumnInfo10.ColumnName = "DOCNAME";
            clsColumnInfo10.ColumnWidth = 90;
            clsColumnInfo10.Enabled = false;
            clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo10.HeadText = "挂号医生";
            clsColumnInfo10.ReadOnly = true;
            clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo11.BackColor = System.Drawing.Color.White;
            clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo11.ColumnIndex = 10;
            clsColumnInfo11.ColumnName = "registerid_chr";
            clsColumnInfo11.ColumnWidth = 0;
            clsColumnInfo11.Enabled = true;
            clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo11.HeadText = "registerid_chr";
            clsColumnInfo11.ReadOnly = true;
            clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo1);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo2);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo3);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo4);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo5);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo6);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo7);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo8);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo9);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo10);
            this.m_dtgWaitReg.Columns.Add(clsColumnInfo11);
            this.m_dtgWaitReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgWaitReg.Font = new System.Drawing.Font("宋体", 11F);
            this.m_dtgWaitReg.FullRowSelect = true;
            this.m_dtgWaitReg.Location = new System.Drawing.Point(0, 0);
            this.m_dtgWaitReg.MultiSelect = false;
            this.m_dtgWaitReg.Name = "m_dtgWaitReg";
            this.m_dtgWaitReg.ReadOnly = true;
            this.m_dtgWaitReg.RowHeadersVisible = true;
            this.m_dtgWaitReg.RowHeaderWidth = 20;
            this.m_dtgWaitReg.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.m_dtgWaitReg.SelectedRowForeColor = System.Drawing.Color.White;
            this.m_dtgWaitReg.Size = new System.Drawing.Size(842, 361);
            this.m_dtgWaitReg.TabIndex = 35;
            this.m_dtgWaitReg.m_evtCurrentCellChanged += new System.EventHandler(this.m_dtgWaitReg_m_evtCurrentCellChanged);
            this.m_dtgWaitReg.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.m_dtgWaitReg_m_evtDoubleClickCell);
            this.m_dtgWaitReg.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtgWaitReg_m_evtDataGridKeyDown);
            this.m_dtgWaitReg.DoubleClick += new System.EventHandler(this.m_dtgWaitReg_DoubleClick);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cmbDeparment);
            this.groupBox8.Controls.Add(this.btSelect);
            this.groupBox8.Controls.Add(this.ra_both);
            this.groupBox8.Controls.Add(this.ra_department);
            this.groupBox8.Controls.Add(this.ra_Person);
            this.groupBox8.Controls.Add(this.m_btnRefReg);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox8.Location = new System.Drawing.Point(0, 361);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(842, 48);
            this.groupBox8.TabIndex = 36;
            this.groupBox8.TabStop = false;
            // 
            // btSelect
            // 
            this.btSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btSelect.DefaultScheme = true;
            this.btSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSelect.Hint = "把西药处方按方号重新排列";
            this.btSelect.Location = new System.Drawing.Point(508, 12);
            this.btSelect.Name = "btSelect";
            this.btSelect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btSelect.Size = new System.Drawing.Size(73, 30);
            this.btSelect.TabIndex = 14;
            this.btSelect.Text = "确定(&S)";
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // m_btnRefReg
            // 
            this.m_btnRefReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnRefReg.DefaultScheme = true;
            this.m_btnRefReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnRefReg.Hint = "刷新候诊列表";
            this.m_btnRefReg.Location = new System.Drawing.Point(608, 12);
            this.m_btnRefReg.Name = "m_btnRefReg";
            this.m_btnRefReg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_btnRefReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnRefReg.Size = new System.Drawing.Size(73, 30);
            this.m_btnRefReg.TabIndex = 8;
            this.m_btnRefReg.Text = "刷新(&R)";
            this.m_btnRefReg.Click += new System.EventHandler(this.m_btnRefReg_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_dtgTake);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(842, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "[1]就诊";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // m_dtgTake
            // 
            this.m_dtgTake.AllowAddNew = false;
            this.m_dtgTake.AllowDelete = false;
            this.m_dtgTake.AutoAppendRow = false;
            this.m_dtgTake.AutoScroll = true;
            this.m_dtgTake.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgTake.CaptionText = "";
            this.m_dtgTake.CaptionVisible = false;
            this.m_dtgTake.ColumnHeadersVisible = true;
            clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo12.BackColor = System.Drawing.Color.White;
            clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo12.ColumnIndex = 0;
            clsColumnInfo12.ColumnName = "TAKEDIAGRECID_CHR";
            clsColumnInfo12.ColumnWidth = 0;
            clsColumnInfo12.Enabled = false;
            clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo12.HeadText = "接诊ID";
            clsColumnInfo12.ReadOnly = true;
            clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo13.BackColor = System.Drawing.Color.White;
            clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo13.ColumnIndex = 1;
            clsColumnInfo13.ColumnName = "REGISTERID_CHR";
            clsColumnInfo13.ColumnWidth = 0;
            clsColumnInfo13.Enabled = false;
            clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo13.HeadText = "挂号ID";
            clsColumnInfo13.ReadOnly = true;
            clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo14.BackColor = System.Drawing.Color.White;
            clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo14.ColumnIndex = 2;
            clsColumnInfo14.ColumnName = "PATIENTCARDID_CHR";
            clsColumnInfo14.ColumnWidth = 100;
            clsColumnInfo14.Enabled = false;
            clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo14.HeadText = "诊疗卡号";
            clsColumnInfo14.ReadOnly = true;
            clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo15.BackColor = System.Drawing.Color.White;
            clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo15.ColumnIndex = 3;
            clsColumnInfo15.ColumnName = "LASTNAME_VCHR";
            clsColumnInfo15.ColumnWidth = 100;
            clsColumnInfo15.Enabled = false;
            clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo15.HeadText = "病人名称";
            clsColumnInfo15.ReadOnly = true;
            clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo16.BackColor = System.Drawing.Color.White;
            clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo16.ColumnIndex = 4;
            clsColumnInfo16.ColumnName = "SEX_CHR";
            clsColumnInfo16.ColumnWidth = 55;
            clsColumnInfo16.Enabled = false;
            clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo16.HeadText = "性别";
            clsColumnInfo16.ReadOnly = true;
            clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo17.BackColor = System.Drawing.Color.White;
            clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo17.ColumnIndex = 5;
            clsColumnInfo17.ColumnName = "BIRTH_DAT";
            clsColumnInfo17.ColumnWidth = 60;
            clsColumnInfo17.Enabled = false;
            clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo17.HeadText = "年龄";
            clsColumnInfo17.ReadOnly = true;
            clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo18.BackColor = System.Drawing.Color.White;
            clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo18.ColumnIndex = 6;
            clsColumnInfo18.ColumnName = "PAYTYPENAME_VCHR";
            clsColumnInfo18.ColumnWidth = 100;
            clsColumnInfo18.Enabled = false;
            clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo18.HeadText = "病人类型";
            clsColumnInfo18.ReadOnly = true;
            clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo19.BackColor = System.Drawing.Color.White;
            clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo19.ColumnIndex = 7;
            clsColumnInfo19.ColumnName = "TAKEDIAGTIME_DAT";
            clsColumnInfo19.ColumnWidth = 150;
            clsColumnInfo19.Enabled = false;
            clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo19.HeadText = "接诊时间";
            clsColumnInfo19.ReadOnly = true;
            clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo20.BackColor = System.Drawing.Color.White;
            clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo20.ColumnIndex = 8;
            clsColumnInfo20.ColumnName = "ENDTIME_DAT";
            clsColumnInfo20.ColumnWidth = 150;
            clsColumnInfo20.Enabled = false;
            clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo20.HeadText = "结束时间";
            clsColumnInfo20.ReadOnly = true;
            clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo21.BackColor = System.Drawing.Color.White;
            clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo21.ColumnIndex = 9;
            clsColumnInfo21.ColumnName = "state";
            clsColumnInfo21.ColumnWidth = 85;
            clsColumnInfo21.Enabled = false;
            clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo21.HeadText = "状态";
            clsColumnInfo21.ReadOnly = true;
            clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo22.BackColor = System.Drawing.Color.White;
            clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo22.ColumnIndex = 10;
            clsColumnInfo22.ColumnName = "PSTATUS_INT";
            clsColumnInfo22.ColumnWidth = 0;
            clsColumnInfo22.Enabled = false;
            clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo22.HeadText = "状态值";
            clsColumnInfo22.ReadOnly = true;
            clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 11F);
            this.m_dtgTake.Columns.Add(clsColumnInfo12);
            this.m_dtgTake.Columns.Add(clsColumnInfo13);
            this.m_dtgTake.Columns.Add(clsColumnInfo14);
            this.m_dtgTake.Columns.Add(clsColumnInfo15);
            this.m_dtgTake.Columns.Add(clsColumnInfo16);
            this.m_dtgTake.Columns.Add(clsColumnInfo17);
            this.m_dtgTake.Columns.Add(clsColumnInfo18);
            this.m_dtgTake.Columns.Add(clsColumnInfo19);
            this.m_dtgTake.Columns.Add(clsColumnInfo20);
            this.m_dtgTake.Columns.Add(clsColumnInfo21);
            this.m_dtgTake.Columns.Add(clsColumnInfo22);
            this.m_dtgTake.ContextMenu = this.ctmPat;
            this.m_dtgTake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgTake.Font = new System.Drawing.Font("宋体", 11F);
            this.m_dtgTake.FullRowSelect = true;
            this.m_dtgTake.Location = new System.Drawing.Point(0, 0);
            this.m_dtgTake.MultiSelect = false;
            this.m_dtgTake.Name = "m_dtgTake";
            this.m_dtgTake.ReadOnly = true;
            this.m_dtgTake.RowHeadersVisible = true;
            this.m_dtgTake.RowHeaderWidth = 20;
            this.m_dtgTake.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.m_dtgTake.SelectedRowForeColor = System.Drawing.Color.White;
            this.m_dtgTake.Size = new System.Drawing.Size(842, 361);
            this.m_dtgTake.TabIndex = 36;
            this.m_dtgTake.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.m_dtgTake_m_evtDoubleClickCell);
            this.m_dtgTake.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtgTake_m_evtDataGridKeyDown);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblPersonTimes);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Controls.Add(this.btnSelect);
            this.groupBox5.Controls.Add(this.lblToday);
            this.groupBox5.Controls.Add(this.lblEnd);
            this.groupBox5.Controls.Add(this.lblBegin);
            this.groupBox5.Controls.Add(this.dtpEnd);
            this.groupBox5.Controls.Add(this.dtpBegin);
            this.groupBox5.Controls.Add(this.llblDate);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(0, 361);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(842, 48);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            // 
            // lblPersonTimes
            // 
            this.lblPersonTimes.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPersonTimes.ForeColor = System.Drawing.Color.Black;
            this.lblPersonTimes.Location = new System.Drawing.Point(312, 20);
            this.lblPersonTimes.Name = "lblPersonTimes";
            this.lblPersonTimes.Size = new System.Drawing.Size(60, 16);
            this.lblPersonTimes.TabIndex = 12;
            this.lblPersonTimes.Text = "00000";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(236, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "就诊人次:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSelect.DefaultScheme = true;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelect.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnSelect.Hint = "";
            this.btnSelect.Location = new System.Drawing.Point(773, 14);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSelect.Size = new System.Drawing.Size(56, 28);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "查询";
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblToday
            // 
            this.lblToday.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToday.ForeColor = System.Drawing.Color.Black;
            this.lblToday.Location = new System.Drawing.Point(89, 20);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(130, 16);
            this.lblToday.TabIndex = 8;
            this.lblToday.Text = "0000年00月00日";
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(622, 21);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(16, 16);
            this.lblEnd.TabIndex = 7;
            this.lblEnd.Text = "到";
            this.lblEnd.Visible = false;
            // 
            // lblBegin
            // 
            this.lblBegin.Location = new System.Drawing.Point(473, 21);
            this.lblBegin.Name = "lblBegin";
            this.lblBegin.Size = new System.Drawing.Size(16, 16);
            this.lblBegin.TabIndex = 6;
            this.lblBegin.Text = "从";
            this.lblBegin.Visible = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(645, 17);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(122, 23);
            this.dtpEnd.TabIndex = 4;
            this.dtpEnd.Visible = false;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(496, 17);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(122, 23);
            this.dtpBegin.TabIndex = 3;
            this.dtpBegin.Visible = false;
            // 
            // llblDate
            // 
            this.llblDate.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.llblDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblDate.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.llblDate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblDate.LinkColor = System.Drawing.Color.Black;
            this.llblDate.Location = new System.Drawing.Point(387, 21);
            this.llblDate.Name = "llblDate";
            this.llblDate.Size = new System.Drawing.Size(108, 16);
            this.llblDate.TabIndex = 2;
            this.llblDate.TabStop = true;
            this.llblDate.Text = "按时间段查询>>";
            this.llblDate.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llblDate.Click += new System.EventHandler(this.llblDate_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(42, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "今天:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(842, 409);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "[2]病历";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btAssistantDiagnose);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 410);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btAssistantDiagnose
            // 
            this.btAssistantDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAssistantDiagnose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAssistantDiagnose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAssistantDiagnose.Location = new System.Drawing.Point(600, 372);
            this.btAssistantDiagnose.Name = "btAssistantDiagnose";
            this.btAssistantDiagnose.Size = new System.Drawing.Size(96, 32);
            this.btAssistantDiagnose.TabIndex = 26;
            this.btAssistantDiagnose.Text = "辅助诊疗";
            this.btAssistantDiagnose.Visible = false;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listView3);
            this.tabPage5.Controls.Add(this.listView2);
            this.tabPage5.Controls.Add(this.ctlDataGrid1);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(842, 409);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "[3]西药";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView3.Location = new System.Drawing.Point(376, 168);
            this.listView3.MultiSelect = false;
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(208, 128);
            this.listView3.TabIndex = 35;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.Visible = false;
            this.listView3.DoubleClick += new System.EventHandler(this.listView3_DoubleClick);
            this.listView3.Leave += new System.EventHandler(this.listView3_Leave);
            this.listView3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView3_KeyDown);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "频率ID";
            this.columnHeader14.Width = 0;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "助记码";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "名称";
            this.columnHeader16.Width = 120;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "次数";
            this.columnHeader17.Width = 0;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "天数";
            this.columnHeader18.Width = 0;
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader11});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.Location = new System.Drawing.Point(152, 168);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(208, 128);
            this.listView2.TabIndex = 29;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Visible = false;
            this.listView2.Leave += new System.EventHandler(this.listView2_Leave);
            this.listView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView2_KeyDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "频率ID";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "助记码";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "名称";
            this.columnHeader11.Width = 120;
            // 
            // ctlDataGrid1
            // 
            this.ctlDataGrid1.AllowAddNew = true;
            this.ctlDataGrid1.AllowDelete = true;
            this.ctlDataGrid1.AutoAppendRow = false;
            this.ctlDataGrid1.AutoScroll = true;
            this.ctlDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGrid1.CaptionText = "";
            this.ctlDataGrid1.CaptionVisible = false;
            this.ctlDataGrid1.ColumnHeadersVisible = true;
            clsColumnInfo23.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo23.BackColor = System.Drawing.Color.White;
            clsColumnInfo23.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo23.ColumnIndex = 0;
            clsColumnInfo23.ColumnName = "Column32";
            clsColumnInfo23.ColumnWidth = 40;
            clsColumnInfo23.Enabled = true;
            clsColumnInfo23.ForeColor = System.Drawing.Color.Blue;
            clsColumnInfo23.HeadText = "方号";
            clsColumnInfo23.ReadOnly = false;
            clsColumnInfo23.TextFont = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            clsColumnInfo24.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo24.BackColor = System.Drawing.Color.White;
            clsColumnInfo24.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo24.ColumnIndex = 1;
            clsColumnInfo24.ColumnName = "Column1";
            clsColumnInfo24.ColumnWidth = 60;
            clsColumnInfo24.Enabled = true;
            clsColumnInfo24.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo24.HeadText = "查询";
            clsColumnInfo24.ReadOnly = false;
            clsColumnInfo24.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo25.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo25.BackColor = System.Drawing.Color.White;
            clsColumnInfo25.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo25.ColumnIndex = 2;
            clsColumnInfo25.ColumnName = "Column2";
            clsColumnInfo25.ColumnWidth = 50;
            clsColumnInfo25.Enabled = true;
            clsColumnInfo25.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo25.HeadText = "用量";
            clsColumnInfo25.ReadOnly = false;
            clsColumnInfo25.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo26.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo26.BackColor = System.Drawing.Color.White;
            clsColumnInfo26.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo26.ColumnIndex = 3;
            clsColumnInfo26.ColumnName = "Column5";
            clsColumnInfo26.ColumnWidth = 45;
            clsColumnInfo26.Enabled = false;
            clsColumnInfo26.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo26.HeadText = "单位";
            clsColumnInfo26.ReadOnly = true;
            clsColumnInfo26.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo27.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo27.BackColor = System.Drawing.Color.White;
            clsColumnInfo27.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo27.ColumnIndex = 4;
            clsColumnInfo27.ColumnName = "Column3";
            clsColumnInfo27.ColumnWidth = 110;
            clsColumnInfo27.Enabled = false;
            clsColumnInfo27.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo27.HeadText = "项目名称";
            clsColumnInfo27.ReadOnly = true;
            clsColumnInfo27.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo28.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo28.BackColor = System.Drawing.Color.White;
            clsColumnInfo28.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo28.ColumnIndex = 5;
            clsColumnInfo28.ColumnName = "Column4";
            clsColumnInfo28.ColumnWidth = 70;
            clsColumnInfo28.Enabled = true;
            clsColumnInfo28.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo28.HeadText = "规格";
            clsColumnInfo28.ReadOnly = true;
            clsColumnInfo28.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo29.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo29.BackColor = System.Drawing.Color.White;
            clsColumnInfo29.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo29.ColumnIndex = 6;
            clsColumnInfo29.ColumnName = "Column14";
            clsColumnInfo29.ColumnWidth = 70;
            clsColumnInfo29.Enabled = true;
            clsColumnInfo29.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo29.HeadText = "用法";
            clsColumnInfo29.ReadOnly = false;
            clsColumnInfo29.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo30.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo30.BackColor = System.Drawing.Color.White;
            clsColumnInfo30.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo30.ColumnIndex = 7;
            clsColumnInfo30.ColumnName = "Column15";
            clsColumnInfo30.ColumnWidth = 50;
            clsColumnInfo30.Enabled = true;
            clsColumnInfo30.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo30.HeadText = "频率";
            clsColumnInfo30.ReadOnly = false;
            clsColumnInfo30.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo31.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo31.BackColor = System.Drawing.Color.White;
            clsColumnInfo31.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo31.ColumnIndex = 8;
            clsColumnInfo31.ColumnName = "Column22";
            clsColumnInfo31.ColumnWidth = 40;
            clsColumnInfo31.Enabled = true;
            clsColumnInfo31.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo31.HeadText = "天";
            clsColumnInfo31.ReadOnly = false;
            clsColumnInfo31.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo32.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo32.BackColor = System.Drawing.Color.White;
            clsColumnInfo32.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo32.ColumnIndex = 9;
            clsColumnInfo32.ColumnName = "Column6";
            clsColumnInfo32.ColumnWidth = 50;
            clsColumnInfo32.Enabled = true;
            clsColumnInfo32.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo32.HeadText = "单价";
            clsColumnInfo32.ReadOnly = false;
            clsColumnInfo32.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo33.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo33.BackColor = System.Drawing.Color.White;
            clsColumnInfo33.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo33.ColumnIndex = 10;
            clsColumnInfo33.ColumnName = "Column7";
            clsColumnInfo33.ColumnWidth = 52;
            clsColumnInfo33.Enabled = true;
            clsColumnInfo33.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo33.HeadText = "总价";
            clsColumnInfo33.ReadOnly = true;
            clsColumnInfo33.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo34.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo34.BackColor = System.Drawing.Color.White;
            clsColumnInfo34.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo34.ColumnIndex = 11;
            clsColumnInfo34.ColumnName = "Column10";
            clsColumnInfo34.ColumnWidth = 0;
            clsColumnInfo34.Enabled = true;
            clsColumnInfo34.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo34.HeadText = "ID";
            clsColumnInfo34.ReadOnly = true;
            clsColumnInfo34.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo35.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo35.BackColor = System.Drawing.Color.White;
            clsColumnInfo35.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo35.ColumnIndex = 12;
            clsColumnInfo35.ColumnName = "Column16";
            clsColumnInfo35.ColumnWidth = 0;
            clsColumnInfo35.Enabled = true;
            clsColumnInfo35.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo35.HeadText = "包装量";
            clsColumnInfo35.ReadOnly = true;
            clsColumnInfo35.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo36.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo36.BackColor = System.Drawing.Color.White;
            clsColumnInfo36.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo36.ColumnIndex = 13;
            clsColumnInfo36.ColumnName = "Column17";
            clsColumnInfo36.ColumnWidth = 43;
            clsColumnInfo36.Enabled = true;
            clsColumnInfo36.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo36.HeadText = "总数";
            clsColumnInfo36.ReadOnly = false;
            clsColumnInfo36.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo37.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo37.BackColor = System.Drawing.Color.White;
            clsColumnInfo37.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo37.ColumnIndex = 14;
            clsColumnInfo37.ColumnName = "Column18";
            clsColumnInfo37.ColumnWidth = 0;
            clsColumnInfo37.Enabled = true;
            clsColumnInfo37.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo37.HeadText = "频率天数";
            clsColumnInfo37.ReadOnly = true;
            clsColumnInfo37.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo38.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo38.BackColor = System.Drawing.Color.White;
            clsColumnInfo38.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo38.ColumnIndex = 15;
            clsColumnInfo38.ColumnName = "Column19";
            clsColumnInfo38.ColumnWidth = 0;
            clsColumnInfo38.Enabled = true;
            clsColumnInfo38.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo38.HeadText = "频率次数";
            clsColumnInfo38.ReadOnly = true;
            clsColumnInfo38.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo39.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo39.BackColor = System.Drawing.Color.White;
            clsColumnInfo39.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo39.ColumnIndex = 16;
            clsColumnInfo39.ColumnName = "Column20";
            clsColumnInfo39.ColumnWidth = 0;
            clsColumnInfo39.Enabled = true;
            clsColumnInfo39.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo39.HeadText = "用法ID";
            clsColumnInfo39.ReadOnly = true;
            clsColumnInfo39.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo40.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo40.BackColor = System.Drawing.Color.White;
            clsColumnInfo40.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo40.ColumnIndex = 17;
            clsColumnInfo40.ColumnName = "Column21";
            clsColumnInfo40.ColumnWidth = 0;
            clsColumnInfo40.Enabled = true;
            clsColumnInfo40.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo40.HeadText = "频率ID";
            clsColumnInfo40.ReadOnly = true;
            clsColumnInfo40.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo41.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo41.BackColor = System.Drawing.Color.White;
            clsColumnInfo41.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo41.ColumnIndex = 18;
            clsColumnInfo41.ColumnName = "Column23";
            clsColumnInfo41.ColumnWidth = 45;
            clsColumnInfo41.Enabled = true;
            clsColumnInfo41.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo41.HeadText = "单位";
            clsColumnInfo41.ReadOnly = true;
            clsColumnInfo41.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo42.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo42.BackColor = System.Drawing.Color.White;
            clsColumnInfo42.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo42.ColumnIndex = 19;
            clsColumnInfo42.ColumnName = "Column24";
            clsColumnInfo42.ColumnWidth = 0;
            clsColumnInfo42.Enabled = false;
            clsColumnInfo42.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo42.HeadText = "行号";
            clsColumnInfo42.ReadOnly = true;
            clsColumnInfo42.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo43.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo43.BackColor = System.Drawing.Color.White;
            clsColumnInfo43.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo43.ColumnIndex = 20;
            clsColumnInfo43.ColumnName = "Column25";
            clsColumnInfo43.ColumnWidth = 45;
            clsColumnInfo43.Enabled = true;
            clsColumnInfo43.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo43.HeadText = "比例";
            clsColumnInfo43.ReadOnly = true;
            clsColumnInfo43.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo44.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo44.BackColor = System.Drawing.Color.White;
            clsColumnInfo44.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo44.ColumnIndex = 21;
            clsColumnInfo44.ColumnName = "Column26";
            clsColumnInfo44.ColumnWidth = 0;
            clsColumnInfo44.Enabled = true;
            clsColumnInfo44.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo44.HeadText = "比例值";
            clsColumnInfo44.ReadOnly = true;
            clsColumnInfo44.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo45.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo45.BackColor = System.Drawing.Color.White;
            clsColumnInfo45.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo45.ColumnIndex = 22;
            clsColumnInfo45.ColumnName = "Column27";
            clsColumnInfo45.ColumnWidth = 0;
            clsColumnInfo45.Enabled = true;
            clsColumnInfo45.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo45.HeadText = "大小单位标记";
            clsColumnInfo45.ReadOnly = true;
            clsColumnInfo45.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo46.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo46.BackColor = System.Drawing.Color.White;
            clsColumnInfo46.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo46.ColumnIndex = 23;
            clsColumnInfo46.ColumnName = "Column28";
            clsColumnInfo46.ColumnWidth = 0;
            clsColumnInfo46.Enabled = true;
            clsColumnInfo46.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo46.HeadText = "常用量";
            clsColumnInfo46.ReadOnly = true;
            clsColumnInfo46.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo47.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo47.BackColor = System.Drawing.Color.White;
            clsColumnInfo47.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo47.ColumnIndex = 24;
            clsColumnInfo47.ColumnName = "Column29";
            clsColumnInfo47.ColumnWidth = 0;
            clsColumnInfo47.Enabled = true;
            clsColumnInfo47.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo47.HeadText = "上限";
            clsColumnInfo47.ReadOnly = true;
            clsColumnInfo47.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo48.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo48.BackColor = System.Drawing.Color.White;
            clsColumnInfo48.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo48.ColumnIndex = 25;
            clsColumnInfo48.ColumnName = "Column30";
            clsColumnInfo48.ColumnWidth = 0;
            clsColumnInfo48.Enabled = true;
            clsColumnInfo48.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo48.HeadText = "下艰";
            clsColumnInfo48.ReadOnly = true;
            clsColumnInfo48.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo49.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo49.BackColor = System.Drawing.Color.White;
            clsColumnInfo49.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo49.ColumnIndex = 26;
            clsColumnInfo49.ColumnName = "Column31";
            clsColumnInfo49.ColumnWidth = 0;
            clsColumnInfo49.Enabled = false;
            clsColumnInfo49.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo49.HeadText = "是否计算";
            clsColumnInfo49.ReadOnly = true;
            clsColumnInfo49.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo50.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo50.BackColor = System.Drawing.Color.White;
            clsColumnInfo50.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo50.ColumnIndex = 27;
            clsColumnInfo50.ColumnName = "Column33";
            clsColumnInfo50.ColumnWidth = 0;
            clsColumnInfo50.Enabled = false;
            clsColumnInfo50.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo50.HeadText = "发票分类";
            clsColumnInfo50.ReadOnly = true;
            clsColumnInfo50.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo51.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo51.BackColor = System.Drawing.Color.White;
            clsColumnInfo51.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo51.ColumnIndex = 28;
            clsColumnInfo51.ColumnName = "Column34";
            clsColumnInfo51.ColumnWidth = 0;
            clsColumnInfo51.Enabled = false;
            clsColumnInfo51.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo51.HeadText = "附加项目ID";
            clsColumnInfo51.ReadOnly = true;
            clsColumnInfo51.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo52.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo52.BackColor = System.Drawing.Color.White;
            clsColumnInfo52.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo52.ColumnIndex = 29;
            clsColumnInfo52.ColumnName = "Column35";
            clsColumnInfo52.ColumnWidth = 0;
            clsColumnInfo52.Enabled = false;
            clsColumnInfo52.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo52.HeadText = "组标志";
            clsColumnInfo52.ReadOnly = true;
            clsColumnInfo52.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo53.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo53.BackColor = System.Drawing.Color.White;
            clsColumnInfo53.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo53.ColumnIndex = 30;
            clsColumnInfo53.ColumnName = "Column36";
            clsColumnInfo53.ColumnWidth = 0;
            clsColumnInfo53.Enabled = false;
            clsColumnInfo53.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo53.HeadText = "附加项目原数量";
            clsColumnInfo53.ReadOnly = true;
            clsColumnInfo53.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo54.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo54.BackColor = System.Drawing.Color.White;
            clsColumnInfo54.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo54.ColumnIndex = 31;
            clsColumnInfo54.ColumnName = "Column37";
            clsColumnInfo54.ColumnWidth = 0;
            clsColumnInfo54.Enabled = false;
            clsColumnInfo54.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo54.HeadText = "是否有附项目(1有)";
            clsColumnInfo54.ReadOnly = true;
            clsColumnInfo54.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo55.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo55.BackColor = System.Drawing.Color.White;
            clsColumnInfo55.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo55.ColumnIndex = 32;
            clsColumnInfo55.ColumnName = "Column38";
            clsColumnInfo55.ColumnWidth = 0;
            clsColumnInfo55.Enabled = false;
            clsColumnInfo55.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo55.HeadText = "英文名";
            clsColumnInfo55.ReadOnly = true;
            clsColumnInfo55.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo56.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo56.BackColor = System.Drawing.Color.White;
            clsColumnInfo56.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo56.ColumnIndex = 33;
            clsColumnInfo56.ColumnName = "Column39";
            clsColumnInfo56.ColumnWidth = 0;
            clsColumnInfo56.Enabled = false;
            clsColumnInfo56.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo56.HeadText = "皮试";
            clsColumnInfo56.ReadOnly = true;
            clsColumnInfo56.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo57.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo57.BackColor = System.Drawing.Color.White;
            clsColumnInfo57.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo57.ColumnIndex = 34;
            clsColumnInfo57.ColumnName = "Column40";
            clsColumnInfo57.ColumnWidth = 0;
            clsColumnInfo57.Enabled = false;
            clsColumnInfo57.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo57.HeadText = "详细用法";
            clsColumnInfo57.ReadOnly = true;
            clsColumnInfo57.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo58.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo58.BackColor = System.Drawing.Color.White;
            clsColumnInfo58.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo58.ColumnIndex = 35;
            clsColumnInfo58.ColumnName = "Column41";
            clsColumnInfo58.ColumnWidth = 0;
            clsColumnInfo58.Enabled = false;
            clsColumnInfo58.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo58.HeadText = "皮试标志";
            clsColumnInfo58.ReadOnly = true;
            clsColumnInfo58.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo59.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo59.BackColor = System.Drawing.Color.White;
            clsColumnInfo59.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo59.ColumnIndex = 36;
            clsColumnInfo59.ColumnName = "Column42";
            clsColumnInfo59.ColumnWidth = 0;
            clsColumnInfo59.Enabled = false;
            clsColumnInfo59.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo59.HeadText = "关联项目ID";
            clsColumnInfo59.ReadOnly = true;
            clsColumnInfo59.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo60.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo60.BackColor = System.Drawing.Color.White;
            clsColumnInfo60.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo60.ColumnIndex = 37;
            clsColumnInfo60.ColumnName = "Column43";
            clsColumnInfo60.ColumnWidth = 0;
            clsColumnInfo60.Enabled = false;
            clsColumnInfo60.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo60.HeadText = "主项默认用量";
            clsColumnInfo60.ReadOnly = true;
            clsColumnInfo60.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo61.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo61.BackColor = System.Drawing.Color.White;
            clsColumnInfo61.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo61.ColumnIndex = 38;
            clsColumnInfo61.ColumnName = "Column44";
            clsColumnInfo61.ColumnWidth = 55;
            clsColumnInfo61.Enabled = true;
            clsColumnInfo61.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo61.HeadText = "科备药";
            clsColumnInfo61.ReadOnly = false;
            clsColumnInfo61.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo62.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo62.BackColor = System.Drawing.Color.White;
            clsColumnInfo62.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo62.ColumnIndex = 39;
            clsColumnInfo62.ColumnName = "Column45";
            clsColumnInfo62.ColumnWidth = 0;
            clsColumnInfo62.Enabled = false;
            clsColumnInfo62.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo62.HeadText = "科备药ID";
            clsColumnInfo62.ReadOnly = true;
            clsColumnInfo62.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo63.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo63.BackColor = System.Drawing.Color.White;
            clsColumnInfo63.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo63.ColumnIndex = 40;
            clsColumnInfo63.ColumnName = "Column46";
            clsColumnInfo63.ColumnWidth = 120;
            clsColumnInfo63.Enabled = false;
            clsColumnInfo63.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo63.HeadText = "总让利金额";
            clsColumnInfo63.ReadOnly = true;
            clsColumnInfo63.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo64.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo64.BackColor = System.Drawing.Color.White;
            clsColumnInfo64.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo64.ColumnIndex = 41;
            clsColumnInfo64.ColumnName = "Column47";
            clsColumnInfo64.ColumnWidth = 0;
            clsColumnInfo64.Enabled = false;
            clsColumnInfo64.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo64.HeadText = "最小让利金额";
            clsColumnInfo64.ReadOnly = true;
            clsColumnInfo64.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo23);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo24);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo25);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo26);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo27);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo28);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo29);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo30);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo31);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo32);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo33);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo34);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo35);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo36);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo37);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo38);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo39);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo40);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo41);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo42);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo43);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo44);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo45);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo46);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo47);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo48);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo49);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo50);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo51);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo52);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo53);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo54);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo55);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo56);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo57);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo58);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo59);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo60);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo61);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo62);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo63);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo64);
            this.ctlDataGrid1.ContextMenuStrip = this.contextMenuStrip1;
            this.ctlDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGrid1.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGrid1.FullRowSelect = false;
            this.ctlDataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGrid1.MultiSelect = true;
            this.ctlDataGrid1.Name = "ctlDataGrid1";
            this.ctlDataGrid1.ReadOnly = false;
            this.ctlDataGrid1.RowHeadersVisible = false;
            this.ctlDataGrid1.RowHeaderWidth = 35;
            this.ctlDataGrid1.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGrid1.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid1.Size = new System.Drawing.Size(842, 409);
            this.ctlDataGrid1.TabIndex = 34;
            this.ctlDataGrid1.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid1_m_evtCurrentCellChanged);
            this.ctlDataGrid1.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGrid1_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGrid1.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGrid1_m_evtDataGridKeyDown);
            this.ctlDataGrid1.Leave += new System.EventHandler(this.ctlDataGrid1_Leave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDrugInfo});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 26);
            // 
            // tsmiDrugInfo
            // 
            this.tsmiDrugInfo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiDrugInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDrugInfo.Image")));
            this.tsmiDrugInfo.Name = "tsmiDrugInfo";
            this.tsmiDrugInfo.Size = new System.Drawing.Size(140, 22);
            this.tsmiDrugInfo.Text = "药品说明书";
            this.tsmiDrugInfo.Click += new System.EventHandler(this.tsmiDrugInfo_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.numericUpDown1);
            this.tabPage6.Controls.Add(this.cmbCooking);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Controls.Add(this.label1);
            this.tabPage6.Controls.Add(this.listView4);
            this.tabPage6.Controls.Add(this.ctlDataGrid2);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(842, 409);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "[4]中药";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(766, 378);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 23);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(720, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 24);
            this.label9.TabIndex = 37;
            this.label9.Text = "服数:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(3, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "用法:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView4
            // 
            this.listView4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader10,
            this.columnHeader13});
            this.listView4.FullRowSelect = true;
            this.listView4.GridLines = true;
            this.listView4.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView4.Location = new System.Drawing.Point(336, 96);
            this.listView4.MultiSelect = false;
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(208, 128);
            this.listView4.TabIndex = 33;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            this.listView4.Visible = false;
            this.listView4.DoubleClick += new System.EventHandler(this.listView4_DoubleClick);
            this.listView4.Leave += new System.EventHandler(this.listView4_Leave);
            this.listView4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView4_KeyDown);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "频率ID";
            this.columnHeader6.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "助记码";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "名称";
            this.columnHeader13.Width = 120;
            // 
            // ctlDataGrid2
            // 
            this.ctlDataGrid2.AllowAddNew = true;
            this.ctlDataGrid2.AllowDelete = true;
            this.ctlDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlDataGrid2.AutoAppendRow = false;
            this.ctlDataGrid2.AutoScroll = true;
            this.ctlDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGrid2.CaptionText = "";
            this.ctlDataGrid2.CaptionVisible = false;
            this.ctlDataGrid2.ColumnHeadersVisible = true;
            clsColumnInfo65.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo65.BackColor = System.Drawing.Color.White;
            clsColumnInfo65.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo65.ColumnIndex = 0;
            clsColumnInfo65.ColumnName = "Column1";
            clsColumnInfo65.ColumnWidth = 75;
            clsColumnInfo65.Enabled = true;
            clsColumnInfo65.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo65.HeadText = "查询";
            clsColumnInfo65.ReadOnly = false;
            clsColumnInfo65.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo66.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo66.BackColor = System.Drawing.Color.White;
            clsColumnInfo66.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo66.ColumnIndex = 1;
            clsColumnInfo66.ColumnName = "Column2";
            clsColumnInfo66.ColumnWidth = 60;
            clsColumnInfo66.Enabled = true;
            clsColumnInfo66.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo66.HeadText = "数量";
            clsColumnInfo66.ReadOnly = false;
            clsColumnInfo66.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo67.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo67.BackColor = System.Drawing.Color.White;
            clsColumnInfo67.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo67.ColumnIndex = 2;
            clsColumnInfo67.ColumnName = "Column5";
            clsColumnInfo67.ColumnWidth = 45;
            clsColumnInfo67.Enabled = false;
            clsColumnInfo67.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo67.HeadText = "单位";
            clsColumnInfo67.ReadOnly = true;
            clsColumnInfo67.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo68.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo68.BackColor = System.Drawing.Color.White;
            clsColumnInfo68.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo68.ColumnIndex = 3;
            clsColumnInfo68.ColumnName = "Column3";
            clsColumnInfo68.ColumnWidth = 180;
            clsColumnInfo68.Enabled = false;
            clsColumnInfo68.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo68.HeadText = "项目名称";
            clsColumnInfo68.ReadOnly = true;
            clsColumnInfo68.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo69.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo69.BackColor = System.Drawing.Color.White;
            clsColumnInfo69.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo69.ColumnIndex = 4;
            clsColumnInfo69.ColumnName = "Column4";
            clsColumnInfo69.ColumnWidth = 110;
            clsColumnInfo69.Enabled = false;
            clsColumnInfo69.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo69.HeadText = "规格";
            clsColumnInfo69.ReadOnly = true;
            clsColumnInfo69.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo70.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo70.BackColor = System.Drawing.Color.White;
            clsColumnInfo70.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo70.ColumnIndex = 5;
            clsColumnInfo70.ColumnName = "Column23";
            clsColumnInfo70.ColumnWidth = 86;
            clsColumnInfo70.Enabled = true;
            clsColumnInfo70.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo70.HeadText = "用法";
            clsColumnInfo70.ReadOnly = false;
            clsColumnInfo70.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo71.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo71.BackColor = System.Drawing.Color.White;
            clsColumnInfo71.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo71.ColumnIndex = 6;
            clsColumnInfo71.ColumnName = "Column6";
            clsColumnInfo71.ColumnWidth = 60;
            clsColumnInfo71.Enabled = false;
            clsColumnInfo71.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo71.HeadText = "单价";
            clsColumnInfo71.ReadOnly = true;
            clsColumnInfo71.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo72.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo72.BackColor = System.Drawing.Color.White;
            clsColumnInfo72.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo72.ColumnIndex = 7;
            clsColumnInfo72.ColumnName = "Column7";
            clsColumnInfo72.ColumnWidth = 60;
            clsColumnInfo72.Enabled = false;
            clsColumnInfo72.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo72.HeadText = "总价";
            clsColumnInfo72.ReadOnly = true;
            clsColumnInfo72.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo73.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo73.BackColor = System.Drawing.Color.White;
            clsColumnInfo73.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo73.ColumnIndex = 8;
            clsColumnInfo73.ColumnName = "Column10";
            clsColumnInfo73.ColumnWidth = 0;
            clsColumnInfo73.Enabled = false;
            clsColumnInfo73.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo73.HeadText = "ID";
            clsColumnInfo73.ReadOnly = true;
            clsColumnInfo73.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo74.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo74.BackColor = System.Drawing.Color.White;
            clsColumnInfo74.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo74.ColumnIndex = 9;
            clsColumnInfo74.ColumnName = "Column11";
            clsColumnInfo74.ColumnWidth = 0;
            clsColumnInfo74.Enabled = false;
            clsColumnInfo74.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo74.HeadText = "行号";
            clsColumnInfo74.ReadOnly = true;
            clsColumnInfo74.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo75.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo75.BackColor = System.Drawing.Color.White;
            clsColumnInfo75.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo75.ColumnIndex = 10;
            clsColumnInfo75.ColumnName = "Column12";
            clsColumnInfo75.ColumnWidth = 74;
            clsColumnInfo75.Enabled = false;
            clsColumnInfo75.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo75.HeadText = "收费比例";
            clsColumnInfo75.ReadOnly = true;
            clsColumnInfo75.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo76.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo76.BackColor = System.Drawing.Color.White;
            clsColumnInfo76.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo76.ColumnIndex = 11;
            clsColumnInfo76.ColumnName = "Column13";
            clsColumnInfo76.ColumnWidth = 0;
            clsColumnInfo76.Enabled = true;
            clsColumnInfo76.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo76.HeadText = "比例值";
            clsColumnInfo76.ReadOnly = true;
            clsColumnInfo76.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo77.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo77.BackColor = System.Drawing.Color.White;
            clsColumnInfo77.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo77.ColumnIndex = 12;
            clsColumnInfo77.ColumnName = "Column14";
            clsColumnInfo77.ColumnWidth = 0;
            clsColumnInfo77.Enabled = true;
            clsColumnInfo77.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo77.HeadText = "常量";
            clsColumnInfo77.ReadOnly = true;
            clsColumnInfo77.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo78.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo78.BackColor = System.Drawing.Color.White;
            clsColumnInfo78.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo78.ColumnIndex = 13;
            clsColumnInfo78.ColumnName = "Column15";
            clsColumnInfo78.ColumnWidth = 0;
            clsColumnInfo78.Enabled = true;
            clsColumnInfo78.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo78.HeadText = "上限";
            clsColumnInfo78.ReadOnly = true;
            clsColumnInfo78.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo79.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo79.BackColor = System.Drawing.Color.White;
            clsColumnInfo79.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo79.ColumnIndex = 14;
            clsColumnInfo79.ColumnName = "Column16";
            clsColumnInfo79.ColumnWidth = 0;
            clsColumnInfo79.Enabled = true;
            clsColumnInfo79.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo79.HeadText = "下限";
            clsColumnInfo79.ReadOnly = true;
            clsColumnInfo79.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo80.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo80.BackColor = System.Drawing.Color.White;
            clsColumnInfo80.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo80.ColumnIndex = 15;
            clsColumnInfo80.ColumnName = "Column17";
            clsColumnInfo80.ColumnWidth = 0;
            clsColumnInfo80.Enabled = true;
            clsColumnInfo80.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo80.HeadText = "总数";
            clsColumnInfo80.ReadOnly = true;
            clsColumnInfo80.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo81.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo81.BackColor = System.Drawing.Color.White;
            clsColumnInfo81.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo81.ColumnIndex = 16;
            clsColumnInfo81.ColumnName = "Column18";
            clsColumnInfo81.ColumnWidth = 0;
            clsColumnInfo81.Enabled = true;
            clsColumnInfo81.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo81.HeadText = "大单价";
            clsColumnInfo81.ReadOnly = true;
            clsColumnInfo81.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo82.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo82.BackColor = System.Drawing.Color.White;
            clsColumnInfo82.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo82.ColumnIndex = 17;
            clsColumnInfo82.ColumnName = "Column19";
            clsColumnInfo82.ColumnWidth = 0;
            clsColumnInfo82.Enabled = true;
            clsColumnInfo82.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo82.HeadText = "大小单位标志";
            clsColumnInfo82.ReadOnly = true;
            clsColumnInfo82.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo83.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo83.BackColor = System.Drawing.Color.White;
            clsColumnInfo83.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo83.ColumnIndex = 18;
            clsColumnInfo83.ColumnName = "Column20";
            clsColumnInfo83.ColumnWidth = 0;
            clsColumnInfo83.Enabled = true;
            clsColumnInfo83.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo83.HeadText = "包装量";
            clsColumnInfo83.ReadOnly = true;
            clsColumnInfo83.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo84.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo84.BackColor = System.Drawing.Color.White;
            clsColumnInfo84.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo84.ColumnIndex = 19;
            clsColumnInfo84.ColumnName = "Column21";
            clsColumnInfo84.ColumnWidth = 0;
            clsColumnInfo84.Enabled = false;
            clsColumnInfo84.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo84.HeadText = "颜色";
            clsColumnInfo84.ReadOnly = true;
            clsColumnInfo84.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo85.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo85.BackColor = System.Drawing.Color.White;
            clsColumnInfo85.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo85.ColumnIndex = 20;
            clsColumnInfo85.ColumnName = "Column22";
            clsColumnInfo85.ColumnWidth = 0;
            clsColumnInfo85.Enabled = false;
            clsColumnInfo85.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo85.HeadText = "发票分类";
            clsColumnInfo85.ReadOnly = true;
            clsColumnInfo85.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo86.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo86.BackColor = System.Drawing.Color.White;
            clsColumnInfo86.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo86.ColumnIndex = 21;
            clsColumnInfo86.ColumnName = "用法ID";
            clsColumnInfo86.ColumnWidth = 0;
            clsColumnInfo86.Enabled = false;
            clsColumnInfo86.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo86.HeadText = "用法ID";
            clsColumnInfo86.ReadOnly = true;
            clsColumnInfo86.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo87.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo87.BackColor = System.Drawing.Color.White;
            clsColumnInfo87.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo87.ColumnIndex = 22;
            clsColumnInfo87.ColumnName = "Column24";
            clsColumnInfo87.ColumnWidth = 0;
            clsColumnInfo87.Enabled = false;
            clsColumnInfo87.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo87.HeadText = "附加项目ID";
            clsColumnInfo87.ReadOnly = true;
            clsColumnInfo87.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo88.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo88.BackColor = System.Drawing.Color.White;
            clsColumnInfo88.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo88.ColumnIndex = 23;
            clsColumnInfo88.ColumnName = "Column25";
            clsColumnInfo88.ColumnWidth = 0;
            clsColumnInfo88.Enabled = false;
            clsColumnInfo88.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo88.HeadText = "附加项目原数量";
            clsColumnInfo88.ReadOnly = true;
            clsColumnInfo88.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo89.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo89.BackColor = System.Drawing.Color.White;
            clsColumnInfo89.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo89.ColumnIndex = 24;
            clsColumnInfo89.ColumnName = "Column26";
            clsColumnInfo89.ColumnWidth = 0;
            clsColumnInfo89.Enabled = false;
            clsColumnInfo89.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo89.HeadText = "英文名";
            clsColumnInfo89.ReadOnly = true;
            clsColumnInfo89.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo90.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo90.BackColor = System.Drawing.Color.White;
            clsColumnInfo90.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo90.ColumnIndex = 25;
            clsColumnInfo90.ColumnName = "Column27";
            clsColumnInfo90.ColumnWidth = 0;
            clsColumnInfo90.Enabled = false;
            clsColumnInfo90.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo90.HeadText = "关联项目ID";
            clsColumnInfo90.ReadOnly = true;
            clsColumnInfo90.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo91.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo91.BackColor = System.Drawing.Color.White;
            clsColumnInfo91.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo91.ColumnIndex = 26;
            clsColumnInfo91.ColumnName = "Column28";
            clsColumnInfo91.ColumnWidth = 0;
            clsColumnInfo91.Enabled = false;
            clsColumnInfo91.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo91.HeadText = "主项默认用量";
            clsColumnInfo91.ReadOnly = true;
            clsColumnInfo91.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo92.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo92.BackColor = System.Drawing.Color.White;
            clsColumnInfo92.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo92.ColumnIndex = 27;
            clsColumnInfo92.ColumnName = "Column29";
            clsColumnInfo92.ColumnWidth = 60;
            clsColumnInfo92.Enabled = true;
            clsColumnInfo92.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo92.HeadText = "科备药";
            clsColumnInfo92.ReadOnly = false;
            clsColumnInfo92.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo93.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo93.BackColor = System.Drawing.Color.White;
            clsColumnInfo93.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo93.ColumnIndex = 28;
            clsColumnInfo93.ColumnName = "Column30";
            clsColumnInfo93.ColumnWidth = 0;
            clsColumnInfo93.Enabled = false;
            clsColumnInfo93.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo93.HeadText = "科备药ID";
            clsColumnInfo93.ReadOnly = true;
            clsColumnInfo93.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo94.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo94.BackColor = System.Drawing.Color.White;
            clsColumnInfo94.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo94.ColumnIndex = 29;
            clsColumnInfo94.ColumnName = "Column31";
            clsColumnInfo94.ColumnWidth = 0;
            clsColumnInfo94.Enabled = true;
            clsColumnInfo94.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo94.HeadText = "详细用法";
            clsColumnInfo94.ReadOnly = true;
            clsColumnInfo94.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo95.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo95.BackColor = System.Drawing.Color.White;
            clsColumnInfo95.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo95.ColumnIndex = 30;
            clsColumnInfo95.ColumnName = "Column32";
            clsColumnInfo95.ColumnWidth = 120;
            clsColumnInfo95.Enabled = false;
            clsColumnInfo95.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo95.HeadText = "总让利金额";
            clsColumnInfo95.ReadOnly = true;
            clsColumnInfo95.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo96.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo96.BackColor = System.Drawing.Color.White;
            clsColumnInfo96.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo96.ColumnIndex = 31;
            clsColumnInfo96.ColumnName = "Column33";
            clsColumnInfo96.ColumnWidth = 0;
            clsColumnInfo96.Enabled = false;
            clsColumnInfo96.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo96.HeadText = "最小让利金额";
            clsColumnInfo96.ReadOnly = true;
            clsColumnInfo96.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo97.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo97.BackColor = System.Drawing.Color.White;
            clsColumnInfo97.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo97.ColumnIndex = 32;
            clsColumnInfo97.ColumnName = "Column34";
            clsColumnInfo97.ColumnWidth = 0;
            clsColumnInfo97.Enabled = false;
            clsColumnInfo97.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo97.HeadText = "大批发单价";
            clsColumnInfo97.ReadOnly = true;
            clsColumnInfo97.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo65);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo66);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo67);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo68);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo69);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo70);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo71);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo72);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo73);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo74);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo75);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo76);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo77);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo78);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo79);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo80);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo81);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo82);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo83);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo84);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo85);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo86);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo87);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo88);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo89);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo90);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo91);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo92);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo93);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo94);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo95);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo96);
            this.ctlDataGrid2.Columns.Add(clsColumnInfo97);
            this.ctlDataGrid2.ContextMenuStrip = this.contextMenuStrip1;
            this.ctlDataGrid2.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGrid2.FullRowSelect = false;
            this.ctlDataGrid2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGrid2.MultiSelect = true;
            this.ctlDataGrid2.Name = "ctlDataGrid2";
            this.ctlDataGrid2.ReadOnly = false;
            this.ctlDataGrid2.RowHeadersVisible = false;
            this.ctlDataGrid2.RowHeaderWidth = 35;
            this.ctlDataGrid2.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGrid2.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid2.Size = new System.Drawing.Size(842, 372);
            this.ctlDataGrid2.TabIndex = 35;
            this.ctlDataGrid2.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid2_m_evtCurrentCellChanged);
            this.ctlDataGrid2.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGrid2_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGrid2.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGrid2_m_evtDataGridKeyDown);
            this.ctlDataGrid2.Leave += new System.EventHandler(this.ctlDataGrid2_Leave);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.listView5);
            this.tabPage7.Controls.Add(this.ctlDataGridLis);
            this.tabPage7.Controls.Add(this.ctlDataGrid3);
            this.tabPage7.Controls.Add(this.plLis);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(842, 409);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "[5]检验";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // listView5
            // 
            this.listView5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23});
            this.listView5.FullRowSelect = true;
            this.listView5.GridLines = true;
            this.listView5.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView5.Location = new System.Drawing.Point(304, 120);
            this.listView5.MultiSelect = false;
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(208, 128);
            this.listView5.TabIndex = 36;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.Details;
            this.listView5.Visible = false;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "频率ID";
            this.columnHeader21.Width = 0;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "助记码";
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "名称";
            this.columnHeader23.Width = 120;
            // 
            // ctlDataGridLis
            // 
            this.ctlDataGridLis.AllowAddNew = true;
            this.ctlDataGridLis.AllowDelete = true;
            this.ctlDataGridLis.AutoAppendRow = false;
            this.ctlDataGridLis.AutoScroll = true;
            this.ctlDataGridLis.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGridLis.CaptionText = "";
            this.ctlDataGridLis.CaptionVisible = false;
            this.ctlDataGridLis.ColumnHeadersVisible = true;
            clsColumnInfo98.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo98.BackColor = System.Drawing.Color.White;
            clsColumnInfo98.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo98.ColumnIndex = 0;
            clsColumnInfo98.ColumnName = "Column1";
            clsColumnInfo98.ColumnWidth = 75;
            clsColumnInfo98.Enabled = true;
            clsColumnInfo98.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo98.HeadText = "查询";
            clsColumnInfo98.ReadOnly = false;
            clsColumnInfo98.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo99.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo99.BackColor = System.Drawing.Color.White;
            clsColumnInfo99.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo99.ColumnIndex = 1;
            clsColumnInfo99.ColumnName = "Column2";
            clsColumnInfo99.ColumnWidth = 50;
            clsColumnInfo99.Enabled = true;
            clsColumnInfo99.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo99.HeadText = "数量";
            clsColumnInfo99.ReadOnly = false;
            clsColumnInfo99.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo100.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo100.BackColor = System.Drawing.Color.White;
            clsColumnInfo100.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo100.ColumnIndex = 2;
            clsColumnInfo100.ColumnName = "Column3";
            clsColumnInfo100.ColumnWidth = 200;
            clsColumnInfo100.Enabled = true;
            clsColumnInfo100.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo100.HeadText = "项目名称";
            clsColumnInfo100.ReadOnly = true;
            clsColumnInfo100.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo101.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo101.BackColor = System.Drawing.Color.White;
            clsColumnInfo101.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo101.ColumnIndex = 3;
            clsColumnInfo101.ColumnName = "Column4";
            clsColumnInfo101.ColumnWidth = 100;
            clsColumnInfo101.Enabled = false;
            clsColumnInfo101.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo101.HeadText = "规格";
            clsColumnInfo101.ReadOnly = true;
            clsColumnInfo101.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo102.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo102.BackColor = System.Drawing.Color.White;
            clsColumnInfo102.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo102.ColumnIndex = 4;
            clsColumnInfo102.ColumnName = "Column21";
            clsColumnInfo102.ColumnWidth = 75;
            clsColumnInfo102.Enabled = true;
            clsColumnInfo102.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo102.HeadText = "样本类型";
            clsColumnInfo102.ReadOnly = false;
            clsColumnInfo102.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo103.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo103.BackColor = System.Drawing.Color.White;
            clsColumnInfo103.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo103.ColumnIndex = 5;
            clsColumnInfo103.ColumnName = "Column5";
            clsColumnInfo103.ColumnWidth = 60;
            clsColumnInfo103.Enabled = true;
            clsColumnInfo103.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo103.HeadText = "单位";
            clsColumnInfo103.ReadOnly = true;
            clsColumnInfo103.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo104.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo104.BackColor = System.Drawing.Color.White;
            clsColumnInfo104.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo104.ColumnIndex = 6;
            clsColumnInfo104.ColumnName = "Column6";
            clsColumnInfo104.ColumnWidth = 65;
            clsColumnInfo104.Enabled = true;
            clsColumnInfo104.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo104.HeadText = "单价";
            clsColumnInfo104.ReadOnly = false;
            clsColumnInfo104.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo105.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo105.BackColor = System.Drawing.Color.White;
            clsColumnInfo105.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo105.ColumnIndex = 7;
            clsColumnInfo105.ColumnName = "Column7";
            clsColumnInfo105.ColumnWidth = 65;
            clsColumnInfo105.Enabled = true;
            clsColumnInfo105.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo105.HeadText = "总价";
            clsColumnInfo105.ReadOnly = true;
            clsColumnInfo105.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo106.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo106.BackColor = System.Drawing.Color.White;
            clsColumnInfo106.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo106.ColumnIndex = 8;
            clsColumnInfo106.ColumnName = "Column10";
            clsColumnInfo106.ColumnWidth = 0;
            clsColumnInfo106.Enabled = true;
            clsColumnInfo106.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo106.HeadText = "ID";
            clsColumnInfo106.ReadOnly = false;
            clsColumnInfo106.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo107.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo107.BackColor = System.Drawing.Color.White;
            clsColumnInfo107.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo107.ColumnIndex = 9;
            clsColumnInfo107.ColumnName = "Column11";
            clsColumnInfo107.ColumnWidth = 0;
            clsColumnInfo107.Enabled = true;
            clsColumnInfo107.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo107.HeadText = "是否自定义价格";
            clsColumnInfo107.ReadOnly = true;
            clsColumnInfo107.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo108.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo108.BackColor = System.Drawing.Color.White;
            clsColumnInfo108.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo108.ColumnIndex = 10;
            clsColumnInfo108.ColumnName = "Column12";
            clsColumnInfo108.ColumnWidth = 0;
            clsColumnInfo108.Enabled = true;
            clsColumnInfo108.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo108.HeadText = "行号";
            clsColumnInfo108.ReadOnly = true;
            clsColumnInfo108.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo109.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo109.BackColor = System.Drawing.Color.White;
            clsColumnInfo109.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo109.ColumnIndex = 11;
            clsColumnInfo109.ColumnName = "Column13";
            clsColumnInfo109.ColumnWidth = 70;
            clsColumnInfo109.Enabled = true;
            clsColumnInfo109.ForeColor = System.Drawing.Color.Green;
            clsColumnInfo109.HeadText = "收费比例";
            clsColumnInfo109.ReadOnly = true;
            clsColumnInfo109.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo110.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo110.BackColor = System.Drawing.Color.White;
            clsColumnInfo110.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo110.ColumnIndex = 12;
            clsColumnInfo110.ColumnName = "Column14";
            clsColumnInfo110.ColumnWidth = 0;
            clsColumnInfo110.Enabled = true;
            clsColumnInfo110.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo110.HeadText = "比例值";
            clsColumnInfo110.ReadOnly = true;
            clsColumnInfo110.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo111.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo111.BackColor = System.Drawing.Color.White;
            clsColumnInfo111.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo111.ColumnIndex = 13;
            clsColumnInfo111.ColumnName = "Column15";
            clsColumnInfo111.ColumnWidth = 0;
            clsColumnInfo111.Enabled = false;
            clsColumnInfo111.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo111.HeadText = "发票分类";
            clsColumnInfo111.ReadOnly = true;
            clsColumnInfo111.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo112.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo112.BackColor = System.Drawing.Color.White;
            clsColumnInfo112.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo112.ColumnIndex = 14;
            clsColumnInfo112.ColumnName = "Column16";
            clsColumnInfo112.ColumnWidth = 0;
            clsColumnInfo112.Enabled = false;
            clsColumnInfo112.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo112.HeadText = "附加项目ID";
            clsColumnInfo112.ReadOnly = true;
            clsColumnInfo112.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo113.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo113.BackColor = System.Drawing.Color.White;
            clsColumnInfo113.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo113.ColumnIndex = 15;
            clsColumnInfo113.ColumnName = "Column17";
            clsColumnInfo113.ColumnWidth = 0;
            clsColumnInfo113.Enabled = false;
            clsColumnInfo113.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo113.HeadText = "附加项目原数量";
            clsColumnInfo113.ReadOnly = true;
            clsColumnInfo113.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo114.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo114.BackColor = System.Drawing.Color.White;
            clsColumnInfo114.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo114.ColumnIndex = 16;
            clsColumnInfo114.ColumnName = "Column18";
            clsColumnInfo114.ColumnWidth = 0;
            clsColumnInfo114.Enabled = false;
            clsColumnInfo114.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo114.HeadText = "英文名";
            clsColumnInfo114.ReadOnly = true;
            clsColumnInfo114.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo115.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo115.BackColor = System.Drawing.Color.White;
            clsColumnInfo115.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo115.ColumnIndex = 17;
            clsColumnInfo115.ColumnName = "Column19";
            clsColumnInfo115.ColumnWidth = 0;
            clsColumnInfo115.Enabled = false;
            clsColumnInfo115.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo115.HeadText = "样本ID";
            clsColumnInfo115.ReadOnly = true;
            clsColumnInfo115.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo116.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo116.BackColor = System.Drawing.Color.White;
            clsColumnInfo116.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo116.ColumnIndex = 18;
            clsColumnInfo116.ColumnName = "Column20";
            clsColumnInfo116.ColumnWidth = 0;
            clsColumnInfo116.Enabled = false;
            clsColumnInfo116.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo116.HeadText = "申请单ID";
            clsColumnInfo116.ReadOnly = true;
            clsColumnInfo116.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo117.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo117.BackColor = System.Drawing.Color.White;
            clsColumnInfo117.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo117.ColumnIndex = 19;
            clsColumnInfo117.ColumnName = "Column22";
            clsColumnInfo117.ColumnWidth = 0;
            clsColumnInfo117.Enabled = false;
            clsColumnInfo117.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo117.HeadText = "关联项目ID";
            clsColumnInfo117.ReadOnly = true;
            clsColumnInfo117.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo118.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo118.BackColor = System.Drawing.Color.White;
            clsColumnInfo118.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo118.ColumnIndex = 20;
            clsColumnInfo118.ColumnName = "Column23";
            clsColumnInfo118.ColumnWidth = 0;
            clsColumnInfo118.Enabled = false;
            clsColumnInfo118.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo118.HeadText = "主项默认用量";
            clsColumnInfo118.ReadOnly = true;
            clsColumnInfo118.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo119.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo119.BackColor = System.Drawing.Color.White;
            clsColumnInfo119.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo119.ColumnIndex = 21;
            clsColumnInfo119.ColumnName = "Column24";
            clsColumnInfo119.ColumnWidth = 50;
            clsColumnInfo119.Enabled = true;
            clsColumnInfo119.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo119.HeadText = "速诊";
            clsColumnInfo119.ReadOnly = false;
            clsColumnInfo119.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo120.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo120.BackColor = System.Drawing.Color.White;
            clsColumnInfo120.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo120.ColumnIndex = 22;
            clsColumnInfo120.ColumnName = "Column25";
            clsColumnInfo120.ColumnWidth = 0;
            clsColumnInfo120.Enabled = false;
            clsColumnInfo120.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo120.HeadText = "速诊ID";
            clsColumnInfo120.ReadOnly = true;
            clsColumnInfo120.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo121.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo121.BackColor = System.Drawing.Color.White;
            clsColumnInfo121.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo121.ColumnIndex = 23;
            clsColumnInfo121.ColumnName = "Column26";
            clsColumnInfo121.ColumnWidth = 0;
            clsColumnInfo121.Enabled = false;
            clsColumnInfo121.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo121.HeadText = "详细用法";
            clsColumnInfo121.ReadOnly = true;
            clsColumnInfo121.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo98);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo99);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo100);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo101);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo102);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo103);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo104);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo105);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo106);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo107);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo108);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo109);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo110);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo111);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo112);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo113);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo114);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo115);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo116);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo117);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo118);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo119);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo120);
            this.ctlDataGridLis.Columns.Add(clsColumnInfo121);
            this.ctlDataGridLis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGridLis.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGridLis.FullRowSelect = false;
            this.ctlDataGridLis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGridLis.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGridLis.MultiSelect = false;
            this.ctlDataGridLis.Name = "ctlDataGridLis";
            this.ctlDataGridLis.ReadOnly = false;
            this.ctlDataGridLis.RowHeadersVisible = false;
            this.ctlDataGridLis.RowHeaderWidth = 35;
            this.ctlDataGridLis.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGridLis.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGridLis.Size = new System.Drawing.Size(842, 409);
            this.ctlDataGridLis.TabIndex = 37;
            this.ctlDataGridLis.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGridLis_m_evtCurrentCellChanged);
            this.ctlDataGridLis.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDataGridLis_m_evtDoubleClickCell);
            this.ctlDataGridLis.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGridLis_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGridLis.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGridLis_m_evtDataGridKeyDown);
            this.ctlDataGridLis.Leave += new System.EventHandler(this.ctlDataGridLis_Leave);
            // 
            // ctlDataGrid3
            // 
            this.ctlDataGrid3.AllowAddNew = true;
            this.ctlDataGrid3.AllowDelete = true;
            this.ctlDataGrid3.AutoAppendRow = false;
            this.ctlDataGrid3.AutoScroll = true;
            this.ctlDataGrid3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGrid3.CaptionText = "";
            this.ctlDataGrid3.CaptionVisible = false;
            this.ctlDataGrid3.ColumnHeadersVisible = true;
            clsColumnInfo122.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo122.BackColor = System.Drawing.Color.White;
            clsColumnInfo122.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo122.ColumnIndex = 0;
            clsColumnInfo122.ColumnName = "Column1";
            clsColumnInfo122.ColumnWidth = 75;
            clsColumnInfo122.Enabled = true;
            clsColumnInfo122.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo122.HeadText = "查询";
            clsColumnInfo122.ReadOnly = false;
            clsColumnInfo122.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo123.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo123.BackColor = System.Drawing.Color.White;
            clsColumnInfo123.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo123.ColumnIndex = 1;
            clsColumnInfo123.ColumnName = "Column2";
            clsColumnInfo123.ColumnWidth = 50;
            clsColumnInfo123.Enabled = true;
            clsColumnInfo123.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo123.HeadText = "数量";
            clsColumnInfo123.ReadOnly = false;
            clsColumnInfo123.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo124.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo124.BackColor = System.Drawing.Color.White;
            clsColumnInfo124.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo124.ColumnIndex = 2;
            clsColumnInfo124.ColumnName = "Column3";
            clsColumnInfo124.ColumnWidth = 200;
            clsColumnInfo124.Enabled = true;
            clsColumnInfo124.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo124.HeadText = "项目名称";
            clsColumnInfo124.ReadOnly = true;
            clsColumnInfo124.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo125.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo125.BackColor = System.Drawing.Color.White;
            clsColumnInfo125.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo125.ColumnIndex = 3;
            clsColumnInfo125.ColumnName = "Column4";
            clsColumnInfo125.ColumnWidth = 100;
            clsColumnInfo125.Enabled = false;
            clsColumnInfo125.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo125.HeadText = "规格";
            clsColumnInfo125.ReadOnly = true;
            clsColumnInfo125.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo126.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo126.BackColor = System.Drawing.Color.White;
            clsColumnInfo126.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo126.ColumnIndex = 4;
            clsColumnInfo126.ColumnName = "Column21";
            clsColumnInfo126.ColumnWidth = 75;
            clsColumnInfo126.Enabled = true;
            clsColumnInfo126.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo126.HeadText = "样本类型";
            clsColumnInfo126.ReadOnly = false;
            clsColumnInfo126.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo127.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo127.BackColor = System.Drawing.Color.White;
            clsColumnInfo127.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo127.ColumnIndex = 5;
            clsColumnInfo127.ColumnName = "Column5";
            clsColumnInfo127.ColumnWidth = 60;
            clsColumnInfo127.Enabled = true;
            clsColumnInfo127.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo127.HeadText = "单位";
            clsColumnInfo127.ReadOnly = true;
            clsColumnInfo127.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo128.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo128.BackColor = System.Drawing.Color.White;
            clsColumnInfo128.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo128.ColumnIndex = 6;
            clsColumnInfo128.ColumnName = "Column6";
            clsColumnInfo128.ColumnWidth = 65;
            clsColumnInfo128.Enabled = true;
            clsColumnInfo128.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo128.HeadText = "单价";
            clsColumnInfo128.ReadOnly = false;
            clsColumnInfo128.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo129.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo129.BackColor = System.Drawing.Color.White;
            clsColumnInfo129.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo129.ColumnIndex = 7;
            clsColumnInfo129.ColumnName = "Column7";
            clsColumnInfo129.ColumnWidth = 65;
            clsColumnInfo129.Enabled = true;
            clsColumnInfo129.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo129.HeadText = "总价";
            clsColumnInfo129.ReadOnly = true;
            clsColumnInfo129.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo130.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo130.BackColor = System.Drawing.Color.White;
            clsColumnInfo130.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo130.ColumnIndex = 8;
            clsColumnInfo130.ColumnName = "Column10";
            clsColumnInfo130.ColumnWidth = 0;
            clsColumnInfo130.Enabled = true;
            clsColumnInfo130.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo130.HeadText = "ID";
            clsColumnInfo130.ReadOnly = false;
            clsColumnInfo130.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo131.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo131.BackColor = System.Drawing.Color.White;
            clsColumnInfo131.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo131.ColumnIndex = 9;
            clsColumnInfo131.ColumnName = "Column11";
            clsColumnInfo131.ColumnWidth = 0;
            clsColumnInfo131.Enabled = true;
            clsColumnInfo131.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo131.HeadText = "是否自定义价格";
            clsColumnInfo131.ReadOnly = true;
            clsColumnInfo131.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo132.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo132.BackColor = System.Drawing.Color.White;
            clsColumnInfo132.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo132.ColumnIndex = 10;
            clsColumnInfo132.ColumnName = "Column12";
            clsColumnInfo132.ColumnWidth = 0;
            clsColumnInfo132.Enabled = true;
            clsColumnInfo132.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo132.HeadText = "行号";
            clsColumnInfo132.ReadOnly = true;
            clsColumnInfo132.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo133.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo133.BackColor = System.Drawing.Color.White;
            clsColumnInfo133.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo133.ColumnIndex = 11;
            clsColumnInfo133.ColumnName = "Column13";
            clsColumnInfo133.ColumnWidth = 70;
            clsColumnInfo133.Enabled = true;
            clsColumnInfo133.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo133.HeadText = "收费比例";
            clsColumnInfo133.ReadOnly = true;
            clsColumnInfo133.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo134.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo134.BackColor = System.Drawing.Color.White;
            clsColumnInfo134.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo134.ColumnIndex = 12;
            clsColumnInfo134.ColumnName = "Column14";
            clsColumnInfo134.ColumnWidth = 0;
            clsColumnInfo134.Enabled = true;
            clsColumnInfo134.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo134.HeadText = "比例值";
            clsColumnInfo134.ReadOnly = true;
            clsColumnInfo134.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo135.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo135.BackColor = System.Drawing.Color.White;
            clsColumnInfo135.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo135.ColumnIndex = 13;
            clsColumnInfo135.ColumnName = "Column15";
            clsColumnInfo135.ColumnWidth = 0;
            clsColumnInfo135.Enabled = false;
            clsColumnInfo135.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo135.HeadText = "发票分类";
            clsColumnInfo135.ReadOnly = true;
            clsColumnInfo135.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo136.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo136.BackColor = System.Drawing.Color.White;
            clsColumnInfo136.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo136.ColumnIndex = 14;
            clsColumnInfo136.ColumnName = "Column16";
            clsColumnInfo136.ColumnWidth = 0;
            clsColumnInfo136.Enabled = false;
            clsColumnInfo136.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo136.HeadText = "附加项目ID";
            clsColumnInfo136.ReadOnly = true;
            clsColumnInfo136.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo137.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo137.BackColor = System.Drawing.Color.White;
            clsColumnInfo137.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo137.ColumnIndex = 15;
            clsColumnInfo137.ColumnName = "Column17";
            clsColumnInfo137.ColumnWidth = 0;
            clsColumnInfo137.Enabled = false;
            clsColumnInfo137.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo137.HeadText = "附加项目原数量";
            clsColumnInfo137.ReadOnly = true;
            clsColumnInfo137.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo138.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo138.BackColor = System.Drawing.Color.White;
            clsColumnInfo138.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo138.ColumnIndex = 16;
            clsColumnInfo138.ColumnName = "Column18";
            clsColumnInfo138.ColumnWidth = 0;
            clsColumnInfo138.Enabled = false;
            clsColumnInfo138.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo138.HeadText = "英文名";
            clsColumnInfo138.ReadOnly = true;
            clsColumnInfo138.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo139.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo139.BackColor = System.Drawing.Color.White;
            clsColumnInfo139.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo139.ColumnIndex = 17;
            clsColumnInfo139.ColumnName = "Column19";
            clsColumnInfo139.ColumnWidth = 0;
            clsColumnInfo139.Enabled = false;
            clsColumnInfo139.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo139.HeadText = "样本ID";
            clsColumnInfo139.ReadOnly = true;
            clsColumnInfo139.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo140.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo140.BackColor = System.Drawing.Color.White;
            clsColumnInfo140.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo140.ColumnIndex = 18;
            clsColumnInfo140.ColumnName = "Column20";
            clsColumnInfo140.ColumnWidth = 0;
            clsColumnInfo140.Enabled = false;
            clsColumnInfo140.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo140.HeadText = "申请单ID";
            clsColumnInfo140.ReadOnly = true;
            clsColumnInfo140.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo141.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo141.BackColor = System.Drawing.Color.White;
            clsColumnInfo141.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo141.ColumnIndex = 19;
            clsColumnInfo141.ColumnName = "Column22";
            clsColumnInfo141.ColumnWidth = 0;
            clsColumnInfo141.Enabled = false;
            clsColumnInfo141.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo141.HeadText = "关联项目ID";
            clsColumnInfo141.ReadOnly = true;
            clsColumnInfo141.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo142.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo142.BackColor = System.Drawing.Color.White;
            clsColumnInfo142.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo142.ColumnIndex = 20;
            clsColumnInfo142.ColumnName = "Column23";
            clsColumnInfo142.ColumnWidth = 0;
            clsColumnInfo142.Enabled = false;
            clsColumnInfo142.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo142.HeadText = "主项默认用量";
            clsColumnInfo142.ReadOnly = true;
            clsColumnInfo142.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo143.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo143.BackColor = System.Drawing.Color.White;
            clsColumnInfo143.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo143.ColumnIndex = 21;
            clsColumnInfo143.ColumnName = "Column24";
            clsColumnInfo143.ColumnWidth = 50;
            clsColumnInfo143.Enabled = true;
            clsColumnInfo143.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo143.HeadText = "速诊";
            clsColumnInfo143.ReadOnly = false;
            clsColumnInfo143.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo144.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo144.BackColor = System.Drawing.Color.White;
            clsColumnInfo144.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo144.ColumnIndex = 22;
            clsColumnInfo144.ColumnName = "Column25";
            clsColumnInfo144.ColumnWidth = 0;
            clsColumnInfo144.Enabled = false;
            clsColumnInfo144.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo144.HeadText = "速诊ID";
            clsColumnInfo144.ReadOnly = true;
            clsColumnInfo144.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo145.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo145.BackColor = System.Drawing.Color.White;
            clsColumnInfo145.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo145.ColumnIndex = 23;
            clsColumnInfo145.ColumnName = "Column26";
            clsColumnInfo145.ColumnWidth = 0;
            clsColumnInfo145.Enabled = false;
            clsColumnInfo145.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo145.HeadText = "详细用法";
            clsColumnInfo145.ReadOnly = true;
            clsColumnInfo145.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo146.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo146.BackColor = System.Drawing.Color.White;
            clsColumnInfo146.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo146.ColumnIndex = 24;
            clsColumnInfo146.ColumnName = "Column27";
            clsColumnInfo146.ColumnWidth = 0;
            clsColumnInfo146.Enabled = false;
            clsColumnInfo146.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo146.HeadText = "主诊疗项目ID";
            clsColumnInfo146.ReadOnly = true;
            clsColumnInfo146.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo147.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo147.BackColor = System.Drawing.Color.White;
            clsColumnInfo147.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo147.ColumnIndex = 25;
            clsColumnInfo147.ColumnName = "Column28";
            clsColumnInfo147.ColumnWidth = 0;
            clsColumnInfo147.Enabled = false;
            clsColumnInfo147.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo147.HeadText = "主诊疗项目原数量";
            clsColumnInfo147.ReadOnly = true;
            clsColumnInfo147.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo148.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo148.BackColor = System.Drawing.Color.White;
            clsColumnInfo148.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo148.ColumnIndex = 26;
            clsColumnInfo148.ColumnName = "Column29";
            clsColumnInfo148.ColumnWidth = 0;
            clsColumnInfo148.Enabled = false;
            clsColumnInfo148.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo148.HeadText = "法定打折比例";
            clsColumnInfo148.ReadOnly = true;
            clsColumnInfo148.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo122);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo123);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo124);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo125);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo126);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo127);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo128);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo129);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo130);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo131);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo132);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo133);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo134);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo135);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo136);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo137);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo138);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo139);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo140);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo141);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo142);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo143);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo144);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo145);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo146);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo147);
            this.ctlDataGrid3.Columns.Add(clsColumnInfo148);
            this.ctlDataGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGrid3.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGrid3.FullRowSelect = false;
            this.ctlDataGrid3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGrid3.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGrid3.MultiSelect = false;
            this.ctlDataGrid3.Name = "ctlDataGrid3";
            this.ctlDataGrid3.ReadOnly = false;
            this.ctlDataGrid3.RowHeadersVisible = false;
            this.ctlDataGrid3.RowHeaderWidth = 35;
            this.ctlDataGrid3.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGrid3.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid3.Size = new System.Drawing.Size(842, 409);
            this.ctlDataGrid3.TabIndex = 35;
            this.ctlDataGrid3.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid3_m_evtCurrentCellChanged);
            this.ctlDataGrid3.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDataGrid3_m_evtDoubleClickCell);
            this.ctlDataGrid3.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGrid3_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGrid3.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGrid3_m_evtDataGridKeyDown);
            this.ctlDataGrid3.Leave += new System.EventHandler(this.ctlDataGrid3_Leave);
            // 
            // plLis
            // 
            this.plLis.AutoScroll = true;
            this.plLis.BackColor = System.Drawing.Color.White;
            this.plLis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plLis.Controls.Add(this.panel5);
            this.plLis.Controls.Add(this.panel6);
            this.plLis.Dock = System.Windows.Forms.DockStyle.Right;
            this.plLis.Location = new System.Drawing.Point(842, 0);
            this.plLis.Name = "plLis";
            this.plLis.Size = new System.Drawing.Size(0, 409);
            this.plLis.TabIndex = 38;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.lvLis);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(0, 381);
            this.panel5.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 16);
            this.label18.TabIndex = 3;
            this.label18.Text = "序号  名称                     单价    数量      金额   自付  自付金额";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvLis
            // 
            this.lvLis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader48,
            this.columnHeader51});
            this.lvLis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLis.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvLis.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lvLis.Location = new System.Drawing.Point(0, 0);
            this.lvLis.MultiSelect = false;
            this.lvLis.Name = "lvLis";
            this.lvLis.Size = new System.Drawing.Size(0, 381);
            this.lvLis.TabIndex = 2;
            this.lvLis.UseCompatibleStateImageBehavior = false;
            this.lvLis.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Width = 28;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Width = 137;
            // 
            // columnHeader30
            // 
            this.columnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader30.Width = 54;
            // 
            // columnHeader31
            // 
            this.columnHeader31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader31.Width = 55;
            // 
            // columnHeader32
            // 
            this.columnHeader32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader32.Width = 64;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Width = 40;
            // 
            // columnHeader51
            // 
            this.columnHeader51.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.pictureBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 28);
            this.panel6.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label17.Location = new System.Drawing.Point(32, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "费用明细";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.plTest);
            this.tabPage8.Controls.Add(this.panel7);
            this.tabPage8.Controls.Add(this.ctlDataGridTest);
            this.tabPage8.Controls.Add(this.ctlDataGrid4);
            this.tabPage8.Location = new System.Drawing.Point(4, 27);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(842, 409);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "[6]检查";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // plTest
            // 
            this.plTest.AutoScroll = true;
            this.plTest.BackColor = System.Drawing.Color.White;
            this.plTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plTest.Controls.Add(this.panel12);
            this.plTest.Controls.Add(this.panel13);
            this.plTest.Dock = System.Windows.Forms.DockStyle.Right;
            this.plTest.Location = new System.Drawing.Point(842, 0);
            this.plTest.Name = "plTest";
            this.plTest.Size = new System.Drawing.Size(0, 409);
            this.plTest.TabIndex = 40;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label20);
            this.panel12.Controls.Add(this.lvTest);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 28);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(0, 381);
            this.panel12.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 16);
            this.label20.TabIndex = 3;
            this.label20.Text = "序号  名称                     单价    数量      金额   自付  自付金额";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvTest
            // 
            this.lvTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader49,
            this.columnHeader52});
            this.lvTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTest.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvTest.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lvTest.Location = new System.Drawing.Point(0, 0);
            this.lvTest.MultiSelect = false;
            this.lvTest.Name = "lvTest";
            this.lvTest.Size = new System.Drawing.Size(0, 381);
            this.lvTest.TabIndex = 2;
            this.lvTest.UseCompatibleStateImageBehavior = false;
            this.lvTest.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Width = 28;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Width = 137;
            // 
            // columnHeader45
            // 
            this.columnHeader45.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader45.Width = 54;
            // 
            // columnHeader46
            // 
            this.columnHeader46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader46.Width = 55;
            // 
            // columnHeader47
            // 
            this.columnHeader47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader47.Width = 64;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Width = 40;
            // 
            // columnHeader52
            // 
            this.columnHeader52.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label28);
            this.panel13.Controls.Add(this.pictureBox3);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(0, 28);
            this.panel13.TabIndex = 5;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label28.Location = new System.Drawing.Point(32, 8);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 12);
            this.label28.TabIndex = 1;
            this.label28.Text = "费用明细";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.AutoScroll = true;
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(842, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 409);
            this.panel7.TabIndex = 39;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label19);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(0, 409);
            this.panel8.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 16);
            this.label19.TabIndex = 3;
            this.label19.Text = "序号  名称                     单价    数量      金额";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctlDataGridTest
            // 
            this.ctlDataGridTest.AllowAddNew = true;
            this.ctlDataGridTest.AllowDelete = true;
            this.ctlDataGridTest.AutoAppendRow = false;
            this.ctlDataGridTest.AutoScroll = true;
            this.ctlDataGridTest.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGridTest.CaptionText = "";
            this.ctlDataGridTest.CaptionVisible = false;
            this.ctlDataGridTest.ColumnHeadersVisible = true;
            clsColumnInfo149.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo149.BackColor = System.Drawing.Color.White;
            clsColumnInfo149.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo149.ColumnIndex = 0;
            clsColumnInfo149.ColumnName = "Column1";
            clsColumnInfo149.ColumnWidth = 75;
            clsColumnInfo149.Enabled = true;
            clsColumnInfo149.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo149.HeadText = "查询";
            clsColumnInfo149.ReadOnly = false;
            clsColumnInfo149.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo150.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo150.BackColor = System.Drawing.Color.White;
            clsColumnInfo150.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo150.ColumnIndex = 1;
            clsColumnInfo150.ColumnName = "Column2";
            clsColumnInfo150.ColumnWidth = 60;
            clsColumnInfo150.Enabled = true;
            clsColumnInfo150.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo150.HeadText = "数量";
            clsColumnInfo150.ReadOnly = false;
            clsColumnInfo150.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo151.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo151.BackColor = System.Drawing.Color.White;
            clsColumnInfo151.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo151.ColumnIndex = 2;
            clsColumnInfo151.ColumnName = "Column3";
            clsColumnInfo151.ColumnWidth = 225;
            clsColumnInfo151.Enabled = true;
            clsColumnInfo151.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo151.HeadText = "项目名称";
            clsColumnInfo151.ReadOnly = true;
            clsColumnInfo151.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo152.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo152.BackColor = System.Drawing.Color.White;
            clsColumnInfo152.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo152.ColumnIndex = 3;
            clsColumnInfo152.ColumnName = "Column4";
            clsColumnInfo152.ColumnWidth = 110;
            clsColumnInfo152.Enabled = true;
            clsColumnInfo152.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo152.HeadText = "规格";
            clsColumnInfo152.ReadOnly = true;
            clsColumnInfo152.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo153.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo153.BackColor = System.Drawing.Color.White;
            clsColumnInfo153.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo153.ColumnIndex = 4;
            clsColumnInfo153.ColumnName = "Column21";
            clsColumnInfo153.ColumnWidth = 75;
            clsColumnInfo153.Enabled = true;
            clsColumnInfo153.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo153.HeadText = "检查部位";
            clsColumnInfo153.ReadOnly = false;
            clsColumnInfo153.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo154.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo154.BackColor = System.Drawing.Color.White;
            clsColumnInfo154.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo154.ColumnIndex = 5;
            clsColumnInfo154.ColumnName = "Column5";
            clsColumnInfo154.ColumnWidth = 60;
            clsColumnInfo154.Enabled = true;
            clsColumnInfo154.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo154.HeadText = "单位";
            clsColumnInfo154.ReadOnly = true;
            clsColumnInfo154.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo155.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo155.BackColor = System.Drawing.Color.White;
            clsColumnInfo155.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo155.ColumnIndex = 6;
            clsColumnInfo155.ColumnName = "Column6";
            clsColumnInfo155.ColumnWidth = 65;
            clsColumnInfo155.Enabled = true;
            clsColumnInfo155.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo155.HeadText = "单价";
            clsColumnInfo155.ReadOnly = false;
            clsColumnInfo155.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo156.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo156.BackColor = System.Drawing.Color.White;
            clsColumnInfo156.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo156.ColumnIndex = 7;
            clsColumnInfo156.ColumnName = "Column7";
            clsColumnInfo156.ColumnWidth = 65;
            clsColumnInfo156.Enabled = true;
            clsColumnInfo156.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo156.HeadText = "总价";
            clsColumnInfo156.ReadOnly = true;
            clsColumnInfo156.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo157.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo157.BackColor = System.Drawing.Color.White;
            clsColumnInfo157.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo157.ColumnIndex = 8;
            clsColumnInfo157.ColumnName = "Column10";
            clsColumnInfo157.ColumnWidth = 0;
            clsColumnInfo157.Enabled = true;
            clsColumnInfo157.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo157.HeadText = "ID";
            clsColumnInfo157.ReadOnly = false;
            clsColumnInfo157.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo158.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo158.BackColor = System.Drawing.Color.White;
            clsColumnInfo158.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo158.ColumnIndex = 9;
            clsColumnInfo158.ColumnName = "Column11";
            clsColumnInfo158.ColumnWidth = 0;
            clsColumnInfo158.Enabled = true;
            clsColumnInfo158.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo158.HeadText = "是否自定义价格";
            clsColumnInfo158.ReadOnly = true;
            clsColumnInfo158.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo159.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo159.BackColor = System.Drawing.Color.White;
            clsColumnInfo159.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo159.ColumnIndex = 10;
            clsColumnInfo159.ColumnName = "Column12";
            clsColumnInfo159.ColumnWidth = 0;
            clsColumnInfo159.Enabled = true;
            clsColumnInfo159.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo159.HeadText = "行号";
            clsColumnInfo159.ReadOnly = true;
            clsColumnInfo159.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo160.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo160.BackColor = System.Drawing.Color.White;
            clsColumnInfo160.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo160.ColumnIndex = 11;
            clsColumnInfo160.ColumnName = "Column13";
            clsColumnInfo160.ColumnWidth = 75;
            clsColumnInfo160.Enabled = true;
            clsColumnInfo160.ForeColor = System.Drawing.Color.Green;
            clsColumnInfo160.HeadText = "收费比例";
            clsColumnInfo160.ReadOnly = true;
            clsColumnInfo160.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo161.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo161.BackColor = System.Drawing.Color.White;
            clsColumnInfo161.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo161.ColumnIndex = 12;
            clsColumnInfo161.ColumnName = "Column14";
            clsColumnInfo161.ColumnWidth = 0;
            clsColumnInfo161.Enabled = true;
            clsColumnInfo161.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo161.HeadText = "比例值";
            clsColumnInfo161.ReadOnly = true;
            clsColumnInfo161.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo162.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo162.BackColor = System.Drawing.Color.White;
            clsColumnInfo162.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo162.ColumnIndex = 13;
            clsColumnInfo162.ColumnName = "Column15";
            clsColumnInfo162.ColumnWidth = 0;
            clsColumnInfo162.Enabled = false;
            clsColumnInfo162.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo162.HeadText = "发票分类";
            clsColumnInfo162.ReadOnly = true;
            clsColumnInfo162.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo163.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo163.BackColor = System.Drawing.Color.White;
            clsColumnInfo163.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo163.ColumnIndex = 14;
            clsColumnInfo163.ColumnName = "Column16";
            clsColumnInfo163.ColumnWidth = 0;
            clsColumnInfo163.Enabled = false;
            clsColumnInfo163.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo163.HeadText = "附加项目ID";
            clsColumnInfo163.ReadOnly = true;
            clsColumnInfo163.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo164.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo164.BackColor = System.Drawing.Color.White;
            clsColumnInfo164.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo164.ColumnIndex = 15;
            clsColumnInfo164.ColumnName = "Column17";
            clsColumnInfo164.ColumnWidth = 0;
            clsColumnInfo164.Enabled = false;
            clsColumnInfo164.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo164.HeadText = "附加项目原数量";
            clsColumnInfo164.ReadOnly = true;
            clsColumnInfo164.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo165.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo165.BackColor = System.Drawing.Color.White;
            clsColumnInfo165.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo165.ColumnIndex = 16;
            clsColumnInfo165.ColumnName = "Column18";
            clsColumnInfo165.ColumnWidth = 0;
            clsColumnInfo165.Enabled = false;
            clsColumnInfo165.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo165.HeadText = "英文名";
            clsColumnInfo165.ReadOnly = true;
            clsColumnInfo165.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo166.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo166.BackColor = System.Drawing.Color.White;
            clsColumnInfo166.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo166.ColumnIndex = 17;
            clsColumnInfo166.ColumnName = "Column19";
            clsColumnInfo166.ColumnWidth = 0;
            clsColumnInfo166.Enabled = false;
            clsColumnInfo166.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo166.HeadText = "预留";
            clsColumnInfo166.ReadOnly = true;
            clsColumnInfo166.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo167.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo167.BackColor = System.Drawing.Color.White;
            clsColumnInfo167.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo167.ColumnIndex = 18;
            clsColumnInfo167.ColumnName = "Column20";
            clsColumnInfo167.ColumnWidth = 0;
            clsColumnInfo167.Enabled = false;
            clsColumnInfo167.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo167.HeadText = "申请单ID";
            clsColumnInfo167.ReadOnly = true;
            clsColumnInfo167.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo168.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo168.BackColor = System.Drawing.Color.White;
            clsColumnInfo168.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo168.ColumnIndex = 19;
            clsColumnInfo168.ColumnName = "Column22";
            clsColumnInfo168.ColumnWidth = 0;
            clsColumnInfo168.Enabled = false;
            clsColumnInfo168.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo168.HeadText = "关联项目ID";
            clsColumnInfo168.ReadOnly = true;
            clsColumnInfo168.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo169.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo169.BackColor = System.Drawing.Color.White;
            clsColumnInfo169.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo169.ColumnIndex = 20;
            clsColumnInfo169.ColumnName = "Column23";
            clsColumnInfo169.ColumnWidth = 0;
            clsColumnInfo169.Enabled = false;
            clsColumnInfo169.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo169.HeadText = "主项默认用量";
            clsColumnInfo169.ReadOnly = true;
            clsColumnInfo169.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo170.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo170.BackColor = System.Drawing.Color.White;
            clsColumnInfo170.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo170.ColumnIndex = 21;
            clsColumnInfo170.ColumnName = "Column24";
            clsColumnInfo170.ColumnWidth = 0;
            clsColumnInfo170.Enabled = false;
            clsColumnInfo170.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo170.HeadText = "详细用法";
            clsColumnInfo170.ReadOnly = true;
            clsColumnInfo170.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo171.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo171.BackColor = System.Drawing.Color.White;
            clsColumnInfo171.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo171.ColumnIndex = 22;
            clsColumnInfo171.ColumnName = "Column25";
            clsColumnInfo171.ColumnWidth = 0;
            clsColumnInfo171.Enabled = false;
            clsColumnInfo171.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo171.HeadText = "用法ID";
            clsColumnInfo171.ReadOnly = true;
            clsColumnInfo171.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo172.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo172.BackColor = System.Drawing.Color.White;
            clsColumnInfo172.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo172.ColumnIndex = 23;
            clsColumnInfo172.ColumnName = "Column26";
            clsColumnInfo172.ColumnWidth = 0;
            clsColumnInfo172.Enabled = false;
            clsColumnInfo172.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo172.HeadText = "费用明细";
            clsColumnInfo172.ReadOnly = true;
            clsColumnInfo172.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo149);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo150);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo151);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo152);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo153);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo154);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo155);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo156);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo157);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo158);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo159);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo160);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo161);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo162);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo163);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo164);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo165);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo166);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo167);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo168);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo169);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo170);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo171);
            this.ctlDataGridTest.Columns.Add(clsColumnInfo172);
            this.ctlDataGridTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGridTest.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGridTest.FullRowSelect = false;
            this.ctlDataGridTest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGridTest.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGridTest.MultiSelect = false;
            this.ctlDataGridTest.Name = "ctlDataGridTest";
            this.ctlDataGridTest.ReadOnly = false;
            this.ctlDataGridTest.RowHeadersVisible = false;
            this.ctlDataGridTest.RowHeaderWidth = 35;
            this.ctlDataGridTest.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGridTest.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGridTest.Size = new System.Drawing.Size(842, 409);
            this.ctlDataGridTest.TabIndex = 36;
            this.ctlDataGridTest.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGridTest_m_evtCurrentCellChanged);
            this.ctlDataGridTest.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDataGridTest_m_evtDoubleClickCell);
            this.ctlDataGridTest.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGridTest_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGridTest.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGridTest_m_evtDataGridKeyDown);
            this.ctlDataGridTest.Leave += new System.EventHandler(this.ctlDataGridTest_Leave);
            // 
            // ctlDataGrid4
            // 
            this.ctlDataGrid4.AllowAddNew = true;
            this.ctlDataGrid4.AllowDelete = true;
            this.ctlDataGrid4.AutoAppendRow = false;
            this.ctlDataGrid4.AutoScroll = true;
            this.ctlDataGrid4.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGrid4.CaptionText = "";
            this.ctlDataGrid4.CaptionVisible = false;
            this.ctlDataGrid4.ColumnHeadersVisible = true;
            clsColumnInfo173.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo173.BackColor = System.Drawing.Color.White;
            clsColumnInfo173.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo173.ColumnIndex = 0;
            clsColumnInfo173.ColumnName = "Column1";
            clsColumnInfo173.ColumnWidth = 75;
            clsColumnInfo173.Enabled = true;
            clsColumnInfo173.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo173.HeadText = "查询";
            clsColumnInfo173.ReadOnly = false;
            clsColumnInfo173.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo174.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo174.BackColor = System.Drawing.Color.White;
            clsColumnInfo174.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo174.ColumnIndex = 1;
            clsColumnInfo174.ColumnName = "Column2";
            clsColumnInfo174.ColumnWidth = 60;
            clsColumnInfo174.Enabled = true;
            clsColumnInfo174.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo174.HeadText = "数量";
            clsColumnInfo174.ReadOnly = false;
            clsColumnInfo174.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo175.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo175.BackColor = System.Drawing.Color.White;
            clsColumnInfo175.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo175.ColumnIndex = 2;
            clsColumnInfo175.ColumnName = "Column3";
            clsColumnInfo175.ColumnWidth = 225;
            clsColumnInfo175.Enabled = true;
            clsColumnInfo175.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo175.HeadText = "项目名称";
            clsColumnInfo175.ReadOnly = true;
            clsColumnInfo175.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo176.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo176.BackColor = System.Drawing.Color.White;
            clsColumnInfo176.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo176.ColumnIndex = 3;
            clsColumnInfo176.ColumnName = "Column4";
            clsColumnInfo176.ColumnWidth = 110;
            clsColumnInfo176.Enabled = true;
            clsColumnInfo176.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo176.HeadText = "规格";
            clsColumnInfo176.ReadOnly = true;
            clsColumnInfo176.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo177.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo177.BackColor = System.Drawing.Color.White;
            clsColumnInfo177.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo177.ColumnIndex = 4;
            clsColumnInfo177.ColumnName = "Column21";
            clsColumnInfo177.ColumnWidth = 75;
            clsColumnInfo177.Enabled = true;
            clsColumnInfo177.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo177.HeadText = "检查部位";
            clsColumnInfo177.ReadOnly = false;
            clsColumnInfo177.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo178.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo178.BackColor = System.Drawing.Color.White;
            clsColumnInfo178.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo178.ColumnIndex = 5;
            clsColumnInfo178.ColumnName = "Column5";
            clsColumnInfo178.ColumnWidth = 60;
            clsColumnInfo178.Enabled = true;
            clsColumnInfo178.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo178.HeadText = "单位";
            clsColumnInfo178.ReadOnly = true;
            clsColumnInfo178.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo179.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo179.BackColor = System.Drawing.Color.White;
            clsColumnInfo179.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo179.ColumnIndex = 6;
            clsColumnInfo179.ColumnName = "Column6";
            clsColumnInfo179.ColumnWidth = 65;
            clsColumnInfo179.Enabled = true;
            clsColumnInfo179.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo179.HeadText = "单价";
            clsColumnInfo179.ReadOnly = false;
            clsColumnInfo179.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo180.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo180.BackColor = System.Drawing.Color.White;
            clsColumnInfo180.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo180.ColumnIndex = 7;
            clsColumnInfo180.ColumnName = "Column7";
            clsColumnInfo180.ColumnWidth = 65;
            clsColumnInfo180.Enabled = true;
            clsColumnInfo180.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo180.HeadText = "总价";
            clsColumnInfo180.ReadOnly = true;
            clsColumnInfo180.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo181.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo181.BackColor = System.Drawing.Color.White;
            clsColumnInfo181.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo181.ColumnIndex = 8;
            clsColumnInfo181.ColumnName = "Column10";
            clsColumnInfo181.ColumnWidth = 0;
            clsColumnInfo181.Enabled = true;
            clsColumnInfo181.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo181.HeadText = "ID";
            clsColumnInfo181.ReadOnly = false;
            clsColumnInfo181.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo182.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo182.BackColor = System.Drawing.Color.White;
            clsColumnInfo182.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo182.ColumnIndex = 9;
            clsColumnInfo182.ColumnName = "Column11";
            clsColumnInfo182.ColumnWidth = 0;
            clsColumnInfo182.Enabled = true;
            clsColumnInfo182.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo182.HeadText = "是否自定义价格";
            clsColumnInfo182.ReadOnly = true;
            clsColumnInfo182.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo183.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo183.BackColor = System.Drawing.Color.White;
            clsColumnInfo183.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo183.ColumnIndex = 10;
            clsColumnInfo183.ColumnName = "Column12";
            clsColumnInfo183.ColumnWidth = 0;
            clsColumnInfo183.Enabled = true;
            clsColumnInfo183.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo183.HeadText = "行号";
            clsColumnInfo183.ReadOnly = true;
            clsColumnInfo183.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo184.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo184.BackColor = System.Drawing.Color.White;
            clsColumnInfo184.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo184.ColumnIndex = 11;
            clsColumnInfo184.ColumnName = "Column13";
            clsColumnInfo184.ColumnWidth = 75;
            clsColumnInfo184.Enabled = true;
            clsColumnInfo184.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo184.HeadText = "收费比例";
            clsColumnInfo184.ReadOnly = true;
            clsColumnInfo184.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo185.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo185.BackColor = System.Drawing.Color.White;
            clsColumnInfo185.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo185.ColumnIndex = 12;
            clsColumnInfo185.ColumnName = "Column14";
            clsColumnInfo185.ColumnWidth = 0;
            clsColumnInfo185.Enabled = true;
            clsColumnInfo185.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo185.HeadText = "比例值";
            clsColumnInfo185.ReadOnly = true;
            clsColumnInfo185.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo186.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo186.BackColor = System.Drawing.Color.White;
            clsColumnInfo186.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo186.ColumnIndex = 13;
            clsColumnInfo186.ColumnName = "Column15";
            clsColumnInfo186.ColumnWidth = 0;
            clsColumnInfo186.Enabled = false;
            clsColumnInfo186.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo186.HeadText = "发票分类";
            clsColumnInfo186.ReadOnly = true;
            clsColumnInfo186.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo187.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo187.BackColor = System.Drawing.Color.White;
            clsColumnInfo187.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo187.ColumnIndex = 14;
            clsColumnInfo187.ColumnName = "Column16";
            clsColumnInfo187.ColumnWidth = 0;
            clsColumnInfo187.Enabled = false;
            clsColumnInfo187.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo187.HeadText = "附加项目ID";
            clsColumnInfo187.ReadOnly = true;
            clsColumnInfo187.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo188.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo188.BackColor = System.Drawing.Color.White;
            clsColumnInfo188.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo188.ColumnIndex = 15;
            clsColumnInfo188.ColumnName = "Column17";
            clsColumnInfo188.ColumnWidth = 0;
            clsColumnInfo188.Enabled = false;
            clsColumnInfo188.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo188.HeadText = "附加项目原数量";
            clsColumnInfo188.ReadOnly = true;
            clsColumnInfo188.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo189.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo189.BackColor = System.Drawing.Color.White;
            clsColumnInfo189.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo189.ColumnIndex = 16;
            clsColumnInfo189.ColumnName = "Column18";
            clsColumnInfo189.ColumnWidth = 0;
            clsColumnInfo189.Enabled = false;
            clsColumnInfo189.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo189.HeadText = "英文名";
            clsColumnInfo189.ReadOnly = true;
            clsColumnInfo189.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo190.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo190.BackColor = System.Drawing.Color.White;
            clsColumnInfo190.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo190.ColumnIndex = 17;
            clsColumnInfo190.ColumnName = "Column19";
            clsColumnInfo190.ColumnWidth = 0;
            clsColumnInfo190.Enabled = false;
            clsColumnInfo190.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo190.HeadText = "预留";
            clsColumnInfo190.ReadOnly = true;
            clsColumnInfo190.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo191.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo191.BackColor = System.Drawing.Color.White;
            clsColumnInfo191.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo191.ColumnIndex = 18;
            clsColumnInfo191.ColumnName = "Column20";
            clsColumnInfo191.ColumnWidth = 0;
            clsColumnInfo191.Enabled = false;
            clsColumnInfo191.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo191.HeadText = "申请单ID";
            clsColumnInfo191.ReadOnly = true;
            clsColumnInfo191.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo192.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo192.BackColor = System.Drawing.Color.White;
            clsColumnInfo192.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo192.ColumnIndex = 19;
            clsColumnInfo192.ColumnName = "Column22";
            clsColumnInfo192.ColumnWidth = 0;
            clsColumnInfo192.Enabled = false;
            clsColumnInfo192.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo192.HeadText = "关联项目ID";
            clsColumnInfo192.ReadOnly = true;
            clsColumnInfo192.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo193.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo193.BackColor = System.Drawing.Color.White;
            clsColumnInfo193.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo193.ColumnIndex = 20;
            clsColumnInfo193.ColumnName = "Column23";
            clsColumnInfo193.ColumnWidth = 0;
            clsColumnInfo193.Enabled = false;
            clsColumnInfo193.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo193.HeadText = "主项默认用量";
            clsColumnInfo193.ReadOnly = true;
            clsColumnInfo193.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo194.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo194.BackColor = System.Drawing.Color.White;
            clsColumnInfo194.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo194.ColumnIndex = 21;
            clsColumnInfo194.ColumnName = "Column24";
            clsColumnInfo194.ColumnWidth = 0;
            clsColumnInfo194.Enabled = false;
            clsColumnInfo194.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo194.HeadText = "详细用法";
            clsColumnInfo194.ReadOnly = true;
            clsColumnInfo194.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo195.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo195.BackColor = System.Drawing.Color.White;
            clsColumnInfo195.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo195.ColumnIndex = 22;
            clsColumnInfo195.ColumnName = "Column25";
            clsColumnInfo195.ColumnWidth = 0;
            clsColumnInfo195.Enabled = false;
            clsColumnInfo195.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo195.HeadText = "用法ID";
            clsColumnInfo195.ReadOnly = true;
            clsColumnInfo195.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo196.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo196.BackColor = System.Drawing.Color.White;
            clsColumnInfo196.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo196.ColumnIndex = 23;
            clsColumnInfo196.ColumnName = "Column26";
            clsColumnInfo196.ColumnWidth = 0;
            clsColumnInfo196.Enabled = false;
            clsColumnInfo196.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo196.HeadText = "主诊疗项目ID";
            clsColumnInfo196.ReadOnly = true;
            clsColumnInfo196.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo197.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo197.BackColor = System.Drawing.Color.White;
            clsColumnInfo197.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo197.ColumnIndex = 24;
            clsColumnInfo197.ColumnName = "Column27";
            clsColumnInfo197.ColumnWidth = 0;
            clsColumnInfo197.Enabled = false;
            clsColumnInfo197.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo197.HeadText = "主诊疗项目带出时基数";
            clsColumnInfo197.ReadOnly = true;
            clsColumnInfo197.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo198.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo198.BackColor = System.Drawing.Color.White;
            clsColumnInfo198.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo198.ColumnIndex = 25;
            clsColumnInfo198.ColumnName = "Column28";
            clsColumnInfo198.ColumnWidth = 0;
            clsColumnInfo198.Enabled = false;
            clsColumnInfo198.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo198.HeadText = "费用明细";
            clsColumnInfo198.ReadOnly = true;
            clsColumnInfo198.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo173);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo174);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo175);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo176);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo177);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo178);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo179);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo180);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo181);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo182);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo183);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo184);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo185);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo186);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo187);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo188);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo189);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo190);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo191);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo192);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo193);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo194);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo195);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo196);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo197);
            this.ctlDataGrid4.Columns.Add(clsColumnInfo198);
            this.ctlDataGrid4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGrid4.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGrid4.FullRowSelect = false;
            this.ctlDataGrid4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGrid4.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGrid4.MultiSelect = false;
            this.ctlDataGrid4.Name = "ctlDataGrid4";
            this.ctlDataGrid4.ReadOnly = false;
            this.ctlDataGrid4.RowHeadersVisible = false;
            this.ctlDataGrid4.RowHeaderWidth = 35;
            this.ctlDataGrid4.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGrid4.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid4.Size = new System.Drawing.Size(842, 409);
            this.ctlDataGrid4.TabIndex = 35;
            this.ctlDataGrid4.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid4_m_evtCurrentCellChanged);
            this.ctlDataGrid4.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDataGrid4_m_evtDoubleClickCell);
            this.ctlDataGrid4.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGrid4_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGrid4.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGrid4_m_evtDataGridKeyDown);
            this.ctlDataGrid4.Leave += new System.EventHandler(this.ctlDataGrid4_Leave);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.plOps);
            this.tabPage9.Controls.Add(this.panel9);
            this.tabPage9.Controls.Add(this.ctlDataGridOps);
            this.tabPage9.Controls.Add(this.ctlDataGrid5);
            this.tabPage9.Location = new System.Drawing.Point(4, 27);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(842, 409);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "[7]手术/治疗";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // plOps
            // 
            this.plOps.AutoScroll = true;
            this.plOps.BackColor = System.Drawing.Color.White;
            this.plOps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plOps.Controls.Add(this.panel14);
            this.plOps.Controls.Add(this.panel15);
            this.plOps.Dock = System.Windows.Forms.DockStyle.Right;
            this.plOps.Location = new System.Drawing.Point(842, 0);
            this.plOps.Name = "plOps";
            this.plOps.Size = new System.Drawing.Size(0, 409);
            this.plOps.TabIndex = 41;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label27);
            this.panel14.Controls.Add(this.lvOps);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(0, 28);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(0, 381);
            this.panel14.TabIndex = 4;
            // 
            // label27
            // 
            this.label27.Dock = System.Windows.Forms.DockStyle.Top;
            this.label27.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label27.Location = new System.Drawing.Point(0, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(0, 16);
            this.label27.TabIndex = 3;
            this.label27.Text = "序号  名称                     单价    数量      金额   自付  自付金额";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvOps
            // 
            this.lvOps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader50,
            this.columnHeader53});
            this.lvOps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOps.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvOps.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lvOps.Location = new System.Drawing.Point(0, 0);
            this.lvOps.MultiSelect = false;
            this.lvOps.Name = "lvOps";
            this.lvOps.Size = new System.Drawing.Size(0, 381);
            this.lvOps.TabIndex = 2;
            this.lvOps.UseCompatibleStateImageBehavior = false;
            this.lvOps.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Width = 28;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Width = 137;
            // 
            // columnHeader40
            // 
            this.columnHeader40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader40.Width = 54;
            // 
            // columnHeader41
            // 
            this.columnHeader41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader41.Width = 55;
            // 
            // columnHeader42
            // 
            this.columnHeader42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader42.Width = 64;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Width = 40;
            // 
            // columnHeader53
            // 
            this.columnHeader53.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label29);
            this.panel15.Controls.Add(this.pictureBox4);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(0, 28);
            this.panel15.TabIndex = 5;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label29.Location = new System.Drawing.Point(32, 8);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 1;
            this.label29.Text = "费用明细";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(8, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.AutoScroll = true;
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(842, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(0, 409);
            this.panel9.TabIndex = 40;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label25);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(0, 409);
            this.panel10.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Top;
            this.label25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 16);
            this.label25.TabIndex = 3;
            this.label25.Text = "序号  名称                     单价    数量      金额";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctlDataGridOps
            // 
            this.ctlDataGridOps.AllowAddNew = true;
            this.ctlDataGridOps.AllowDelete = true;
            this.ctlDataGridOps.AutoAppendRow = false;
            this.ctlDataGridOps.AutoScroll = true;
            this.ctlDataGridOps.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGridOps.CaptionText = "";
            this.ctlDataGridOps.CaptionVisible = false;
            this.ctlDataGridOps.ColumnHeadersVisible = true;
            clsColumnInfo199.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo199.BackColor = System.Drawing.Color.White;
            clsColumnInfo199.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo199.ColumnIndex = 0;
            clsColumnInfo199.ColumnName = "Column1";
            clsColumnInfo199.ColumnWidth = 75;
            clsColumnInfo199.Enabled = true;
            clsColumnInfo199.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo199.HeadText = "查询";
            clsColumnInfo199.ReadOnly = false;
            clsColumnInfo199.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo200.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo200.BackColor = System.Drawing.Color.White;
            clsColumnInfo200.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo200.ColumnIndex = 1;
            clsColumnInfo200.ColumnName = "Column2";
            clsColumnInfo200.ColumnWidth = 65;
            clsColumnInfo200.Enabled = true;
            clsColumnInfo200.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo200.HeadText = "数量";
            clsColumnInfo200.ReadOnly = false;
            clsColumnInfo200.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo201.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo201.BackColor = System.Drawing.Color.White;
            clsColumnInfo201.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo201.ColumnIndex = 2;
            clsColumnInfo201.ColumnName = "Column3";
            clsColumnInfo201.ColumnWidth = 242;
            clsColumnInfo201.Enabled = true;
            clsColumnInfo201.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo201.HeadText = "项目名称";
            clsColumnInfo201.ReadOnly = true;
            clsColumnInfo201.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo202.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo202.BackColor = System.Drawing.Color.White;
            clsColumnInfo202.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo202.ColumnIndex = 3;
            clsColumnInfo202.ColumnName = "Column4";
            clsColumnInfo202.ColumnWidth = 148;
            clsColumnInfo202.Enabled = true;
            clsColumnInfo202.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo202.HeadText = "规格";
            clsColumnInfo202.ReadOnly = true;
            clsColumnInfo202.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo203.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo203.BackColor = System.Drawing.Color.White;
            clsColumnInfo203.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo203.ColumnIndex = 4;
            clsColumnInfo203.ColumnName = "Column5";
            clsColumnInfo203.ColumnWidth = 55;
            clsColumnInfo203.Enabled = true;
            clsColumnInfo203.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo203.HeadText = "单位";
            clsColumnInfo203.ReadOnly = true;
            clsColumnInfo203.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo204.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo204.BackColor = System.Drawing.Color.White;
            clsColumnInfo204.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo204.ColumnIndex = 5;
            clsColumnInfo204.ColumnName = "Column6";
            clsColumnInfo204.ColumnWidth = 75;
            clsColumnInfo204.Enabled = true;
            clsColumnInfo204.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo204.HeadText = "单价";
            clsColumnInfo204.ReadOnly = false;
            clsColumnInfo204.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo205.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo205.BackColor = System.Drawing.Color.White;
            clsColumnInfo205.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo205.ColumnIndex = 6;
            clsColumnInfo205.ColumnName = "Column7";
            clsColumnInfo205.ColumnWidth = 75;
            clsColumnInfo205.Enabled = true;
            clsColumnInfo205.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo205.HeadText = "总价";
            clsColumnInfo205.ReadOnly = true;
            clsColumnInfo205.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo206.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo206.BackColor = System.Drawing.Color.White;
            clsColumnInfo206.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo206.ColumnIndex = 7;
            clsColumnInfo206.ColumnName = "Column10";
            clsColumnInfo206.ColumnWidth = 0;
            clsColumnInfo206.Enabled = true;
            clsColumnInfo206.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo206.HeadText = "ID";
            clsColumnInfo206.ReadOnly = false;
            clsColumnInfo206.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo207.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo207.BackColor = System.Drawing.Color.White;
            clsColumnInfo207.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo207.ColumnIndex = 8;
            clsColumnInfo207.ColumnName = "Column11";
            clsColumnInfo207.ColumnWidth = 0;
            clsColumnInfo207.Enabled = true;
            clsColumnInfo207.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo207.HeadText = "是否自定义价格";
            clsColumnInfo207.ReadOnly = true;
            clsColumnInfo207.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo208.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo208.BackColor = System.Drawing.Color.White;
            clsColumnInfo208.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo208.ColumnIndex = 9;
            clsColumnInfo208.ColumnName = "Column12";
            clsColumnInfo208.ColumnWidth = 0;
            clsColumnInfo208.Enabled = true;
            clsColumnInfo208.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo208.HeadText = "行号";
            clsColumnInfo208.ReadOnly = true;
            clsColumnInfo208.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo209.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo209.BackColor = System.Drawing.Color.White;
            clsColumnInfo209.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo209.ColumnIndex = 10;
            clsColumnInfo209.ColumnName = "Column13";
            clsColumnInfo209.ColumnWidth = 75;
            clsColumnInfo209.Enabled = true;
            clsColumnInfo209.ForeColor = System.Drawing.Color.Green;
            clsColumnInfo209.HeadText = "收费比例";
            clsColumnInfo209.ReadOnly = true;
            clsColumnInfo209.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo210.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo210.BackColor = System.Drawing.Color.White;
            clsColumnInfo210.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo210.ColumnIndex = 11;
            clsColumnInfo210.ColumnName = "Column14";
            clsColumnInfo210.ColumnWidth = 0;
            clsColumnInfo210.Enabled = true;
            clsColumnInfo210.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo210.HeadText = "比例值";
            clsColumnInfo210.ReadOnly = true;
            clsColumnInfo210.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo211.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo211.BackColor = System.Drawing.Color.White;
            clsColumnInfo211.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo211.ColumnIndex = 12;
            clsColumnInfo211.ColumnName = "Column15";
            clsColumnInfo211.ColumnWidth = 0;
            clsColumnInfo211.Enabled = false;
            clsColumnInfo211.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo211.HeadText = "发票分类";
            clsColumnInfo211.ReadOnly = true;
            clsColumnInfo211.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo212.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo212.BackColor = System.Drawing.Color.White;
            clsColumnInfo212.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo212.ColumnIndex = 13;
            clsColumnInfo212.ColumnName = "Column16";
            clsColumnInfo212.ColumnWidth = 0;
            clsColumnInfo212.Enabled = false;
            clsColumnInfo212.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo212.HeadText = "附加项目ID";
            clsColumnInfo212.ReadOnly = true;
            clsColumnInfo212.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo213.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo213.BackColor = System.Drawing.Color.White;
            clsColumnInfo213.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo213.ColumnIndex = 14;
            clsColumnInfo213.ColumnName = "Column17";
            clsColumnInfo213.ColumnWidth = 0;
            clsColumnInfo213.Enabled = false;
            clsColumnInfo213.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo213.HeadText = "附加项目原数量";
            clsColumnInfo213.ReadOnly = true;
            clsColumnInfo213.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo214.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo214.BackColor = System.Drawing.Color.White;
            clsColumnInfo214.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo214.ColumnIndex = 15;
            clsColumnInfo214.ColumnName = "Column18";
            clsColumnInfo214.ColumnWidth = 0;
            clsColumnInfo214.Enabled = false;
            clsColumnInfo214.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo214.HeadText = "英文名";
            clsColumnInfo214.ReadOnly = true;
            clsColumnInfo214.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo215.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo215.BackColor = System.Drawing.Color.White;
            clsColumnInfo215.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo215.ColumnIndex = 16;
            clsColumnInfo215.ColumnName = "Column19";
            clsColumnInfo215.ColumnWidth = 0;
            clsColumnInfo215.Enabled = false;
            clsColumnInfo215.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo215.HeadText = "预留";
            clsColumnInfo215.ReadOnly = true;
            clsColumnInfo215.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo216.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo216.BackColor = System.Drawing.Color.White;
            clsColumnInfo216.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo216.ColumnIndex = 17;
            clsColumnInfo216.ColumnName = "Column20";
            clsColumnInfo216.ColumnWidth = 0;
            clsColumnInfo216.Enabled = false;
            clsColumnInfo216.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo216.HeadText = "申请单号";
            clsColumnInfo216.ReadOnly = true;
            clsColumnInfo216.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo217.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo217.BackColor = System.Drawing.Color.White;
            clsColumnInfo217.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo217.ColumnIndex = 18;
            clsColumnInfo217.ColumnName = "Column21";
            clsColumnInfo217.ColumnWidth = 0;
            clsColumnInfo217.Enabled = false;
            clsColumnInfo217.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo217.HeadText = "关联项目ID";
            clsColumnInfo217.ReadOnly = true;
            clsColumnInfo217.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo218.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo218.BackColor = System.Drawing.Color.White;
            clsColumnInfo218.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo218.ColumnIndex = 19;
            clsColumnInfo218.ColumnName = "Column22";
            clsColumnInfo218.ColumnWidth = 0;
            clsColumnInfo218.Enabled = false;
            clsColumnInfo218.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo218.HeadText = "主项默认用量";
            clsColumnInfo218.ReadOnly = true;
            clsColumnInfo218.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo219.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo219.BackColor = System.Drawing.Color.White;
            clsColumnInfo219.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo219.ColumnIndex = 20;
            clsColumnInfo219.ColumnName = "Column23";
            clsColumnInfo219.ColumnWidth = 0;
            clsColumnInfo219.Enabled = false;
            clsColumnInfo219.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo219.HeadText = "申请单标志";
            clsColumnInfo219.ReadOnly = true;
            clsColumnInfo219.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo220.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo220.BackColor = System.Drawing.Color.White;
            clsColumnInfo220.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo220.ColumnIndex = 21;
            clsColumnInfo220.ColumnName = "Column24";
            clsColumnInfo220.ColumnWidth = 0;
            clsColumnInfo220.Enabled = false;
            clsColumnInfo220.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo220.HeadText = "详细用法";
            clsColumnInfo220.ReadOnly = true;
            clsColumnInfo220.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo221.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo221.BackColor = System.Drawing.Color.White;
            clsColumnInfo221.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo221.ColumnIndex = 22;
            clsColumnInfo221.ColumnName = "Column25";
            clsColumnInfo221.ColumnWidth = 0;
            clsColumnInfo221.Enabled = false;
            clsColumnInfo221.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo221.HeadText = "用法ID";
            clsColumnInfo221.ReadOnly = true;
            clsColumnInfo221.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo199);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo200);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo201);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo202);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo203);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo204);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo205);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo206);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo207);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo208);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo209);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo210);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo211);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo212);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo213);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo214);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo215);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo216);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo217);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo218);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo219);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo220);
            this.ctlDataGridOps.Columns.Add(clsColumnInfo221);
            this.ctlDataGridOps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGridOps.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGridOps.FullRowSelect = false;
            this.ctlDataGridOps.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGridOps.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGridOps.MultiSelect = false;
            this.ctlDataGridOps.Name = "ctlDataGridOps";
            this.ctlDataGridOps.ReadOnly = false;
            this.ctlDataGridOps.RowHeadersVisible = false;
            this.ctlDataGridOps.RowHeaderWidth = 35;
            this.ctlDataGridOps.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGridOps.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGridOps.Size = new System.Drawing.Size(842, 409);
            this.ctlDataGridOps.TabIndex = 36;
            this.ctlDataGridOps.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGridOps_m_evtCurrentCellChanged);
            this.ctlDataGridOps.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDataGridOps_m_evtDoubleClickCell);
            this.ctlDataGridOps.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGridOps_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGridOps.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGridOps_m_evtDataGridKeyDown);
            this.ctlDataGridOps.Leave += new System.EventHandler(this.ctlDataGridOps_Leave);
            // 
            // ctlDataGrid5
            // 
            this.ctlDataGrid5.AllowAddNew = true;
            this.ctlDataGrid5.AllowDelete = true;
            this.ctlDataGrid5.AutoAppendRow = false;
            this.ctlDataGrid5.AutoScroll = true;
            this.ctlDataGrid5.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGrid5.CaptionText = "";
            this.ctlDataGrid5.CaptionVisible = false;
            this.ctlDataGrid5.ColumnHeadersVisible = true;
            clsColumnInfo222.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo222.BackColor = System.Drawing.Color.White;
            clsColumnInfo222.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo222.ColumnIndex = 0;
            clsColumnInfo222.ColumnName = "Column1";
            clsColumnInfo222.ColumnWidth = 75;
            clsColumnInfo222.Enabled = true;
            clsColumnInfo222.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo222.HeadText = "查询";
            clsColumnInfo222.ReadOnly = false;
            clsColumnInfo222.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo223.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo223.BackColor = System.Drawing.Color.White;
            clsColumnInfo223.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo223.ColumnIndex = 1;
            clsColumnInfo223.ColumnName = "Column2";
            clsColumnInfo223.ColumnWidth = 65;
            clsColumnInfo223.Enabled = true;
            clsColumnInfo223.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo223.HeadText = "数量";
            clsColumnInfo223.ReadOnly = false;
            clsColumnInfo223.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo224.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo224.BackColor = System.Drawing.Color.White;
            clsColumnInfo224.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo224.ColumnIndex = 2;
            clsColumnInfo224.ColumnName = "Column3";
            clsColumnInfo224.ColumnWidth = 242;
            clsColumnInfo224.Enabled = true;
            clsColumnInfo224.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo224.HeadText = "项目名称";
            clsColumnInfo224.ReadOnly = true;
            clsColumnInfo224.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo225.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo225.BackColor = System.Drawing.Color.White;
            clsColumnInfo225.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo225.ColumnIndex = 3;
            clsColumnInfo225.ColumnName = "Column4";
            clsColumnInfo225.ColumnWidth = 148;
            clsColumnInfo225.Enabled = true;
            clsColumnInfo225.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo225.HeadText = "规格";
            clsColumnInfo225.ReadOnly = true;
            clsColumnInfo225.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo226.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo226.BackColor = System.Drawing.Color.White;
            clsColumnInfo226.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo226.ColumnIndex = 4;
            clsColumnInfo226.ColumnName = "Column5";
            clsColumnInfo226.ColumnWidth = 55;
            clsColumnInfo226.Enabled = true;
            clsColumnInfo226.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo226.HeadText = "单位";
            clsColumnInfo226.ReadOnly = true;
            clsColumnInfo226.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo227.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo227.BackColor = System.Drawing.Color.White;
            clsColumnInfo227.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo227.ColumnIndex = 5;
            clsColumnInfo227.ColumnName = "Column6";
            clsColumnInfo227.ColumnWidth = 75;
            clsColumnInfo227.Enabled = true;
            clsColumnInfo227.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo227.HeadText = "单价";
            clsColumnInfo227.ReadOnly = false;
            clsColumnInfo227.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo228.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo228.BackColor = System.Drawing.Color.White;
            clsColumnInfo228.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo228.ColumnIndex = 6;
            clsColumnInfo228.ColumnName = "Column7";
            clsColumnInfo228.ColumnWidth = 75;
            clsColumnInfo228.Enabled = true;
            clsColumnInfo228.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo228.HeadText = "总价";
            clsColumnInfo228.ReadOnly = true;
            clsColumnInfo228.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo229.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo229.BackColor = System.Drawing.Color.White;
            clsColumnInfo229.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo229.ColumnIndex = 7;
            clsColumnInfo229.ColumnName = "Column10";
            clsColumnInfo229.ColumnWidth = 0;
            clsColumnInfo229.Enabled = true;
            clsColumnInfo229.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo229.HeadText = "ID";
            clsColumnInfo229.ReadOnly = false;
            clsColumnInfo229.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo230.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo230.BackColor = System.Drawing.Color.White;
            clsColumnInfo230.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo230.ColumnIndex = 8;
            clsColumnInfo230.ColumnName = "Column11";
            clsColumnInfo230.ColumnWidth = 0;
            clsColumnInfo230.Enabled = true;
            clsColumnInfo230.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo230.HeadText = "是否自定义价格";
            clsColumnInfo230.ReadOnly = true;
            clsColumnInfo230.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo231.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo231.BackColor = System.Drawing.Color.White;
            clsColumnInfo231.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo231.ColumnIndex = 9;
            clsColumnInfo231.ColumnName = "Column12";
            clsColumnInfo231.ColumnWidth = 0;
            clsColumnInfo231.Enabled = true;
            clsColumnInfo231.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo231.HeadText = "行号";
            clsColumnInfo231.ReadOnly = true;
            clsColumnInfo231.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo232.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo232.BackColor = System.Drawing.Color.White;
            clsColumnInfo232.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo232.ColumnIndex = 10;
            clsColumnInfo232.ColumnName = "Column13";
            clsColumnInfo232.ColumnWidth = 75;
            clsColumnInfo232.Enabled = true;
            clsColumnInfo232.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo232.HeadText = "收费比例";
            clsColumnInfo232.ReadOnly = true;
            clsColumnInfo232.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo233.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo233.BackColor = System.Drawing.Color.White;
            clsColumnInfo233.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo233.ColumnIndex = 11;
            clsColumnInfo233.ColumnName = "Column14";
            clsColumnInfo233.ColumnWidth = 0;
            clsColumnInfo233.Enabled = true;
            clsColumnInfo233.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo233.HeadText = "比例值";
            clsColumnInfo233.ReadOnly = true;
            clsColumnInfo233.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo234.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo234.BackColor = System.Drawing.Color.White;
            clsColumnInfo234.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo234.ColumnIndex = 12;
            clsColumnInfo234.ColumnName = "Column15";
            clsColumnInfo234.ColumnWidth = 0;
            clsColumnInfo234.Enabled = false;
            clsColumnInfo234.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo234.HeadText = "发票分类";
            clsColumnInfo234.ReadOnly = true;
            clsColumnInfo234.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo235.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo235.BackColor = System.Drawing.Color.White;
            clsColumnInfo235.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo235.ColumnIndex = 13;
            clsColumnInfo235.ColumnName = "Column16";
            clsColumnInfo235.ColumnWidth = 0;
            clsColumnInfo235.Enabled = false;
            clsColumnInfo235.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo235.HeadText = "附加项目ID";
            clsColumnInfo235.ReadOnly = true;
            clsColumnInfo235.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo236.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo236.BackColor = System.Drawing.Color.White;
            clsColumnInfo236.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo236.ColumnIndex = 14;
            clsColumnInfo236.ColumnName = "Column17";
            clsColumnInfo236.ColumnWidth = 0;
            clsColumnInfo236.Enabled = false;
            clsColumnInfo236.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo236.HeadText = "附加项目原数量";
            clsColumnInfo236.ReadOnly = true;
            clsColumnInfo236.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo237.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo237.BackColor = System.Drawing.Color.White;
            clsColumnInfo237.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo237.ColumnIndex = 15;
            clsColumnInfo237.ColumnName = "Column18";
            clsColumnInfo237.ColumnWidth = 0;
            clsColumnInfo237.Enabled = false;
            clsColumnInfo237.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo237.HeadText = "英文名";
            clsColumnInfo237.ReadOnly = true;
            clsColumnInfo237.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo238.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo238.BackColor = System.Drawing.Color.White;
            clsColumnInfo238.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo238.ColumnIndex = 16;
            clsColumnInfo238.ColumnName = "Column19";
            clsColumnInfo238.ColumnWidth = 0;
            clsColumnInfo238.Enabled = false;
            clsColumnInfo238.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo238.HeadText = "预留";
            clsColumnInfo238.ReadOnly = true;
            clsColumnInfo238.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo239.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo239.BackColor = System.Drawing.Color.White;
            clsColumnInfo239.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo239.ColumnIndex = 17;
            clsColumnInfo239.ColumnName = "Column20";
            clsColumnInfo239.ColumnWidth = 0;
            clsColumnInfo239.Enabled = false;
            clsColumnInfo239.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo239.HeadText = "申请单号";
            clsColumnInfo239.ReadOnly = true;
            clsColumnInfo239.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo240.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo240.BackColor = System.Drawing.Color.White;
            clsColumnInfo240.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo240.ColumnIndex = 18;
            clsColumnInfo240.ColumnName = "Column21";
            clsColumnInfo240.ColumnWidth = 0;
            clsColumnInfo240.Enabled = false;
            clsColumnInfo240.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo240.HeadText = "关联项目ID";
            clsColumnInfo240.ReadOnly = true;
            clsColumnInfo240.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo241.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo241.BackColor = System.Drawing.Color.White;
            clsColumnInfo241.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo241.ColumnIndex = 19;
            clsColumnInfo241.ColumnName = "Column22";
            clsColumnInfo241.ColumnWidth = 0;
            clsColumnInfo241.Enabled = false;
            clsColumnInfo241.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo241.HeadText = "主项默认用量";
            clsColumnInfo241.ReadOnly = true;
            clsColumnInfo241.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo242.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo242.BackColor = System.Drawing.Color.White;
            clsColumnInfo242.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo242.ColumnIndex = 20;
            clsColumnInfo242.ColumnName = "Column23";
            clsColumnInfo242.ColumnWidth = 0;
            clsColumnInfo242.Enabled = false;
            clsColumnInfo242.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo242.HeadText = "申请单标志";
            clsColumnInfo242.ReadOnly = true;
            clsColumnInfo242.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo243.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo243.BackColor = System.Drawing.Color.White;
            clsColumnInfo243.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo243.ColumnIndex = 21;
            clsColumnInfo243.ColumnName = "Column24";
            clsColumnInfo243.ColumnWidth = 0;
            clsColumnInfo243.Enabled = false;
            clsColumnInfo243.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo243.HeadText = "详细用法";
            clsColumnInfo243.ReadOnly = true;
            clsColumnInfo243.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo244.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo244.BackColor = System.Drawing.Color.White;
            clsColumnInfo244.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo244.ColumnIndex = 22;
            clsColumnInfo244.ColumnName = "Column25";
            clsColumnInfo244.ColumnWidth = 0;
            clsColumnInfo244.Enabled = false;
            clsColumnInfo244.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo244.HeadText = "用法ID";
            clsColumnInfo244.ReadOnly = true;
            clsColumnInfo244.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo245.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo245.BackColor = System.Drawing.Color.White;
            clsColumnInfo245.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo245.ColumnIndex = 23;
            clsColumnInfo245.ColumnName = "Column26";
            clsColumnInfo245.ColumnWidth = 0;
            clsColumnInfo245.Enabled = false;
            clsColumnInfo245.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo245.HeadText = "主诊疗项目ID";
            clsColumnInfo245.ReadOnly = true;
            clsColumnInfo245.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo246.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo246.BackColor = System.Drawing.Color.White;
            clsColumnInfo246.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo246.ColumnIndex = 24;
            clsColumnInfo246.ColumnName = "Column27";
            clsColumnInfo246.ColumnWidth = 0;
            clsColumnInfo246.Enabled = false;
            clsColumnInfo246.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo246.HeadText = "主诊疗项目带出时原基数";
            clsColumnInfo246.ReadOnly = true;
            clsColumnInfo246.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo222);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo223);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo224);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo225);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo226);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo227);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo228);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo229);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo230);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo231);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo232);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo233);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo234);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo235);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo236);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo237);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo238);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo239);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo240);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo241);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo242);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo243);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo244);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo245);
            this.ctlDataGrid5.Columns.Add(clsColumnInfo246);
            this.ctlDataGrid5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGrid5.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGrid5.FullRowSelect = false;
            this.ctlDataGrid5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGrid5.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGrid5.MultiSelect = false;
            this.ctlDataGrid5.Name = "ctlDataGrid5";
            this.ctlDataGrid5.ReadOnly = false;
            this.ctlDataGrid5.RowHeadersVisible = false;
            this.ctlDataGrid5.RowHeaderWidth = 35;
            this.ctlDataGrid5.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGrid5.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid5.Size = new System.Drawing.Size(842, 409);
            this.ctlDataGrid5.TabIndex = 35;
            this.ctlDataGrid5.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid5_m_evtCurrentCellChanged);
            this.ctlDataGrid5.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDataGrid5_m_evtDoubleClickCell);
            this.ctlDataGrid5.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGrid5_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGrid5.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGrid5_m_evtDataGridKeyDown);
            this.ctlDataGrid5.Leave += new System.EventHandler(this.ctlDataGrid5_Leave);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.ctlDataGrid6);
            this.tabPage10.Location = new System.Drawing.Point(4, 27);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(842, 409);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "[8]其他";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // ctlDataGrid6
            // 
            this.ctlDataGrid6.AllowAddNew = true;
            this.ctlDataGrid6.AllowDelete = true;
            this.ctlDataGrid6.AutoAppendRow = false;
            this.ctlDataGrid6.AutoScroll = true;
            this.ctlDataGrid6.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGrid6.CaptionText = "";
            this.ctlDataGrid6.CaptionVisible = false;
            this.ctlDataGrid6.ColumnHeadersVisible = true;
            clsColumnInfo247.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo247.BackColor = System.Drawing.Color.White;
            clsColumnInfo247.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo247.ColumnIndex = 0;
            clsColumnInfo247.ColumnName = "Column1";
            clsColumnInfo247.ColumnWidth = 75;
            clsColumnInfo247.Enabled = true;
            clsColumnInfo247.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo247.HeadText = "查询";
            clsColumnInfo247.ReadOnly = false;
            clsColumnInfo247.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo248.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo248.BackColor = System.Drawing.Color.White;
            clsColumnInfo248.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo248.ColumnIndex = 1;
            clsColumnInfo248.ColumnName = "Column2";
            clsColumnInfo248.ColumnWidth = 60;
            clsColumnInfo248.Enabled = true;
            clsColumnInfo248.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo248.HeadText = "数量";
            clsColumnInfo248.ReadOnly = false;
            clsColumnInfo248.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo249.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo249.BackColor = System.Drawing.Color.White;
            clsColumnInfo249.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo249.ColumnIndex = 2;
            clsColumnInfo249.ColumnName = "Column3";
            clsColumnInfo249.ColumnWidth = 222;
            clsColumnInfo249.Enabled = true;
            clsColumnInfo249.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo249.HeadText = "项目名称";
            clsColumnInfo249.ReadOnly = true;
            clsColumnInfo249.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo250.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo250.BackColor = System.Drawing.Color.White;
            clsColumnInfo250.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo250.ColumnIndex = 3;
            clsColumnInfo250.ColumnName = "Column4";
            clsColumnInfo250.ColumnWidth = 130;
            clsColumnInfo250.Enabled = true;
            clsColumnInfo250.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo250.HeadText = "规格";
            clsColumnInfo250.ReadOnly = true;
            clsColumnInfo250.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo251.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo251.BackColor = System.Drawing.Color.White;
            clsColumnInfo251.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo251.ColumnIndex = 4;
            clsColumnInfo251.ColumnName = "Column5";
            clsColumnInfo251.ColumnWidth = 50;
            clsColumnInfo251.Enabled = true;
            clsColumnInfo251.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo251.HeadText = "单位";
            clsColumnInfo251.ReadOnly = true;
            clsColumnInfo251.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo252.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo252.BackColor = System.Drawing.Color.White;
            clsColumnInfo252.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo252.ColumnIndex = 5;
            clsColumnInfo252.ColumnName = "Column6";
            clsColumnInfo252.ColumnWidth = 69;
            clsColumnInfo252.Enabled = true;
            clsColumnInfo252.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo252.HeadText = "单价";
            clsColumnInfo252.ReadOnly = false;
            clsColumnInfo252.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo253.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo253.BackColor = System.Drawing.Color.White;
            clsColumnInfo253.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo253.ColumnIndex = 6;
            clsColumnInfo253.ColumnName = "Column7";
            clsColumnInfo253.ColumnWidth = 69;
            clsColumnInfo253.Enabled = true;
            clsColumnInfo253.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo253.HeadText = "总价";
            clsColumnInfo253.ReadOnly = true;
            clsColumnInfo253.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo254.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo254.BackColor = System.Drawing.Color.White;
            clsColumnInfo254.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo254.ColumnIndex = 7;
            clsColumnInfo254.ColumnName = "Column10";
            clsColumnInfo254.ColumnWidth = 0;
            clsColumnInfo254.Enabled = true;
            clsColumnInfo254.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo254.HeadText = "ID";
            clsColumnInfo254.ReadOnly = false;
            clsColumnInfo254.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo255.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo255.BackColor = System.Drawing.Color.White;
            clsColumnInfo255.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo255.ColumnIndex = 8;
            clsColumnInfo255.ColumnName = "Column11";
            clsColumnInfo255.ColumnWidth = 0;
            clsColumnInfo255.Enabled = true;
            clsColumnInfo255.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo255.HeadText = "是否自定义价格";
            clsColumnInfo255.ReadOnly = true;
            clsColumnInfo255.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo256.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo256.BackColor = System.Drawing.Color.White;
            clsColumnInfo256.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo256.ColumnIndex = 9;
            clsColumnInfo256.ColumnName = "Column12";
            clsColumnInfo256.ColumnWidth = 0;
            clsColumnInfo256.Enabled = true;
            clsColumnInfo256.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo256.HeadText = "行号";
            clsColumnInfo256.ReadOnly = true;
            clsColumnInfo256.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo257.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo257.BackColor = System.Drawing.Color.White;
            clsColumnInfo257.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo257.ColumnIndex = 10;
            clsColumnInfo257.ColumnName = "Column13";
            clsColumnInfo257.ColumnWidth = 75;
            clsColumnInfo257.Enabled = true;
            clsColumnInfo257.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo257.HeadText = "收费比例";
            clsColumnInfo257.ReadOnly = true;
            clsColumnInfo257.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo258.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo258.BackColor = System.Drawing.Color.White;
            clsColumnInfo258.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo258.ColumnIndex = 11;
            clsColumnInfo258.ColumnName = "Column14";
            clsColumnInfo258.ColumnWidth = 0;
            clsColumnInfo258.Enabled = true;
            clsColumnInfo258.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo258.HeadText = "比例值";
            clsColumnInfo258.ReadOnly = true;
            clsColumnInfo258.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo259.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo259.BackColor = System.Drawing.Color.White;
            clsColumnInfo259.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo259.ColumnIndex = 12;
            clsColumnInfo259.ColumnName = "Column15";
            clsColumnInfo259.ColumnWidth = 0;
            clsColumnInfo259.Enabled = false;
            clsColumnInfo259.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo259.HeadText = "发票分类";
            clsColumnInfo259.ReadOnly = true;
            clsColumnInfo259.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo260.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo260.BackColor = System.Drawing.Color.White;
            clsColumnInfo260.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo260.ColumnIndex = 13;
            clsColumnInfo260.ColumnName = "Column16";
            clsColumnInfo260.ColumnWidth = 0;
            clsColumnInfo260.Enabled = false;
            clsColumnInfo260.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo260.HeadText = "附加项目ID";
            clsColumnInfo260.ReadOnly = true;
            clsColumnInfo260.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo261.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo261.BackColor = System.Drawing.Color.White;
            clsColumnInfo261.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo261.ColumnIndex = 14;
            clsColumnInfo261.ColumnName = "Column17";
            clsColumnInfo261.ColumnWidth = 0;
            clsColumnInfo261.Enabled = false;
            clsColumnInfo261.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo261.HeadText = "附加项目原数量";
            clsColumnInfo261.ReadOnly = true;
            clsColumnInfo261.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo262.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo262.BackColor = System.Drawing.Color.White;
            clsColumnInfo262.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo262.ColumnIndex = 15;
            clsColumnInfo262.ColumnName = "Column18";
            clsColumnInfo262.ColumnWidth = 0;
            clsColumnInfo262.Enabled = false;
            clsColumnInfo262.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo262.HeadText = "英文名";
            clsColumnInfo262.ReadOnly = true;
            clsColumnInfo262.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo263.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo263.BackColor = System.Drawing.Color.White;
            clsColumnInfo263.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo263.ColumnIndex = 16;
            clsColumnInfo263.ColumnName = "Column19";
            clsColumnInfo263.ColumnWidth = 0;
            clsColumnInfo263.Enabled = false;
            clsColumnInfo263.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo263.HeadText = "预留";
            clsColumnInfo263.ReadOnly = true;
            clsColumnInfo263.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo264.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo264.BackColor = System.Drawing.Color.White;
            clsColumnInfo264.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo264.ColumnIndex = 17;
            clsColumnInfo264.ColumnName = "Column20";
            clsColumnInfo264.ColumnWidth = 0;
            clsColumnInfo264.Enabled = false;
            clsColumnInfo264.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo264.HeadText = "申请单ID";
            clsColumnInfo264.ReadOnly = true;
            clsColumnInfo264.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo265.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo265.BackColor = System.Drawing.Color.White;
            clsColumnInfo265.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo265.ColumnIndex = 18;
            clsColumnInfo265.ColumnName = "Column21";
            clsColumnInfo265.ColumnWidth = 0;
            clsColumnInfo265.Enabled = false;
            clsColumnInfo265.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo265.HeadText = "关联项目ID";
            clsColumnInfo265.ReadOnly = true;
            clsColumnInfo265.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo266.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo266.BackColor = System.Drawing.Color.White;
            clsColumnInfo266.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo266.ColumnIndex = 19;
            clsColumnInfo266.ColumnName = "Column22";
            clsColumnInfo266.ColumnWidth = 0;
            clsColumnInfo266.Enabled = false;
            clsColumnInfo266.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo266.HeadText = "主项默认用量";
            clsColumnInfo266.ReadOnly = true;
            clsColumnInfo266.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo267.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo267.BackColor = System.Drawing.Color.White;
            clsColumnInfo267.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo267.ColumnIndex = 20;
            clsColumnInfo267.ColumnName = "Column23";
            clsColumnInfo267.ColumnWidth = 0;
            clsColumnInfo267.Enabled = false;
            clsColumnInfo267.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo267.HeadText = "详细用法";
            clsColumnInfo267.ReadOnly = true;
            clsColumnInfo267.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo268.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo268.BackColor = System.Drawing.Color.White;
            clsColumnInfo268.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo268.ColumnIndex = 21;
            clsColumnInfo268.ColumnName = "Column24";
            clsColumnInfo268.ColumnWidth = 60;
            clsColumnInfo268.Enabled = true;
            clsColumnInfo268.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo268.HeadText = "科备药";
            clsColumnInfo268.ReadOnly = false;
            clsColumnInfo268.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo269.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo269.BackColor = System.Drawing.Color.White;
            clsColumnInfo269.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo269.ColumnIndex = 22;
            clsColumnInfo269.ColumnName = "Column25";
            clsColumnInfo269.ColumnWidth = 0;
            clsColumnInfo269.Enabled = false;
            clsColumnInfo269.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo269.HeadText = "科备药ID";
            clsColumnInfo269.ReadOnly = true;
            clsColumnInfo269.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo247);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo248);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo249);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo250);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo251);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo252);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo253);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo254);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo255);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo256);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo257);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo258);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo259);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo260);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo261);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo262);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo263);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo264);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo265);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo266);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo267);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo268);
            this.ctlDataGrid6.Columns.Add(clsColumnInfo269);
            this.ctlDataGrid6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGrid6.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGrid6.FullRowSelect = false;
            this.ctlDataGrid6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlDataGrid6.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGrid6.MultiSelect = false;
            this.ctlDataGrid6.Name = "ctlDataGrid6";
            this.ctlDataGrid6.ReadOnly = false;
            this.ctlDataGrid6.RowHeadersVisible = false;
            this.ctlDataGrid6.RowHeaderWidth = 35;
            this.ctlDataGrid6.SelectedRowBackColor = System.Drawing.Color.Navy;
            this.ctlDataGrid6.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid6.Size = new System.Drawing.Size(842, 409);
            this.ctlDataGrid6.TabIndex = 35;
            this.ctlDataGrid6.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid6_m_evtCurrentCellChanged);
            this.ctlDataGrid6.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGrid6_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGrid6.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGrid6_m_evtDataGridKeyDown);
            this.ctlDataGrid6.Leave += new System.EventHandler(this.ctlDataGrid6_Leave);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 446);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(850, 1);
            this.splitter1.TabIndex = 33;
            this.splitter1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader2,
            this.columnHeader26,
            this.columnHeader24,
            this.columnHeader20,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader19,
            this.columnHeader27,
            this.columnHeader12,
            this.columnHeader25});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Font = new System.Drawing.Font("宋体", 12F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 447);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(850, 24);
            this.listView1.TabIndex = 32;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.Leave += new System.EventHandler(this.listView1_Leave);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "查询码";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "商品名";
            this.columnHeader2.Width = 155;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "通用名";
            this.columnHeader26.Width = 100;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "英文名";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "类型";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "规格";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "常用量";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "单位";
            this.columnHeader4.Width = 45;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单价";
            this.columnHeader5.Width = 71;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "比例";
            this.columnHeader19.Width = 45;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "医保";
            this.columnHeader27.Width = 45;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "";
            this.columnHeader12.Width = 45;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "发票分类";
            this.columnHeader25.Width = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 6);
            this.panel3.TabIndex = 35;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.FF);
            this.panel4.Controls.Add(this.EE);
            this.panel4.Controls.Add(this.DD);
            this.panel4.Controls.Add(this.CC);
            this.panel4.Controls.Add(this.BB);
            this.panel4.Controls.Add(this.AA);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.panel4.Location = new System.Drawing.Point(0, 471);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(850, 32);
            this.panel4.TabIndex = 36;
            // 
            // FF
            // 
            this.FF.AutoSize = true;
            this.FF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FF.ForeColor = System.Drawing.Color.Black;
            this.FF.Location = new System.Drawing.Point(749, 6);
            this.FF.Name = "FF";
            this.FF.Size = new System.Drawing.Size(24, 16);
            this.FF.TabIndex = 11;
            this.FF.Text = "FF";
            // 
            // EE
            // 
            this.EE.AutoSize = true;
            this.EE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EE.ForeColor = System.Drawing.Color.Black;
            this.EE.Location = new System.Drawing.Point(629, 6);
            this.EE.Name = "EE";
            this.EE.Size = new System.Drawing.Size(24, 16);
            this.EE.TabIndex = 10;
            this.EE.Text = "EE";
            // 
            // DD
            // 
            this.DD.AutoSize = true;
            this.DD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DD.ForeColor = System.Drawing.Color.Black;
            this.DD.Location = new System.Drawing.Point(462, 6);
            this.DD.Name = "DD";
            this.DD.Size = new System.Drawing.Size(24, 16);
            this.DD.TabIndex = 9;
            this.DD.Text = "DD";
            // 
            // CC
            // 
            this.CC.AutoSize = true;
            this.CC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CC.ForeColor = System.Drawing.Color.Black;
            this.CC.Location = new System.Drawing.Point(330, 6);
            this.CC.Name = "CC";
            this.CC.Size = new System.Drawing.Size(24, 16);
            this.CC.TabIndex = 8;
            this.CC.Text = "CC";
            // 
            // BB
            // 
            this.BB.AutoSize = true;
            this.BB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB.ForeColor = System.Drawing.Color.Black;
            this.BB.Location = new System.Drawing.Point(203, 6);
            this.BB.Name = "BB";
            this.BB.Size = new System.Drawing.Size(24, 16);
            this.BB.TabIndex = 7;
            this.BB.Text = "BB";
            // 
            // AA
            // 
            this.AA.AutoSize = true;
            this.AA.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AA.ForeColor = System.Drawing.Color.Black;
            this.AA.Location = new System.Drawing.Point(70, 6);
            this.AA.Name = "AA";
            this.AA.Size = new System.Drawing.Size(24, 16);
            this.AA.TabIndex = 6;
            this.AA.Text = "AA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(692, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "其他费:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "手术/治疗费:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "检查费:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "检验费:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "中药费:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 14);
            this.label22.TabIndex = 0;
            this.label22.Text = "西药费:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btnWAC);
            this.panel1.Controls.Add(this.btnBooking);
            this.panel1.Controls.Add(this.cboProxyBoilMed);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.txtWeight);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.btnPrefer);
            this.panel1.Controls.Add(this.lbeSbAccPay);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cmbRecipeType);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtLoadRecipeNo1);
            this.panel1.Controls.Add(this.m_cmbFind);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btnRecalc);
            this.panel1.Controls.Add(this.lbeFlag);
            this.panel1.Controls.Add(this.btPutIn);
            this.panel1.Controls.Add(this.btCaseHistory);
            this.panel1.Controls.Add(this.btReGroup);
            this.panel1.Controls.Add(this.btNew);
            this.panel1.Controls.Add(this.btInject);
            this.panel1.Controls.Add(this.btCaseyHistory);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.lbeSelfPay);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.lbeChargeUp);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.BtExit);
            this.panel1.Controls.Add(this.btClear);
            this.panel1.Controls.Add(this.lbeSumMoney);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.m_btnEndTake);
            this.panel1.Controls.Add(this.btPrint);
            this.panel1.Controls.Add(this.m_btnBackWait);
            this.panel1.Controls.Add(this.btDel);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.m_cmbRecipeType);
            this.panel1.Controls.Add(this.btReUse);
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.panel1.Location = new System.Drawing.Point(853, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 598);
            this.panel1.TabIndex = 0;
            // 
            // btnWAC
            // 
            this.btnWAC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnWAC.DefaultScheme = true;
            this.btnWAC.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnWAC.Hint = "先诊后结通道";
            this.btnWAC.Location = new System.Drawing.Point(84, 304);
            this.btnWAC.Name = "btnWAC";
            this.btnWAC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnWAC.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnWAC.Size = new System.Drawing.Size(73, 31);
            this.btnWAC.TabIndex = 131;
            this.btnWAC.Text = "妇幼平台";
            this.btnWAC.Click += new System.EventHandler(this.btnWAC_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnBooking.DefaultScheme = true;
            this.btnBooking.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBooking.Hint = "先诊后结通道";
            this.btnBooking.Location = new System.Drawing.Point(6, 304);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBooking.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnBooking.Size = new System.Drawing.Size(73, 31);
            this.btnBooking.TabIndex = 130;
            this.btnBooking.Text = "诊间预约";
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // cboProxyBoilMed
            // 
            this.cboProxyBoilMed.DropDownHeight = 125;
            this.cboProxyBoilMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProxyBoilMed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboProxyBoilMed.ForeColor = System.Drawing.Color.Blue;
            this.cboProxyBoilMed.FormattingEnabled = true;
            this.cboProxyBoilMed.IntegralHeight = false;
            this.cboProxyBoilMed.ItemHeight = 14;
            this.cboProxyBoilMed.Items.AddRange(new object[] {
            "",
            "代煎代送",
            "中药代送"});
            this.cboProxyBoilMed.Location = new System.Drawing.Point(80, 191);
            this.cboProxyBoilMed.Name = "cboProxyBoilMed";
            this.cboProxyBoilMed.Size = new System.Drawing.Size(79, 22);
            this.cboProxyBoilMed.TabIndex = 129;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.ForeColor = System.Drawing.Color.Blue;
            this.label32.Location = new System.Drawing.Point(6, 195);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(86, 16);
            this.label32.TabIndex = 128;
            this.label32.Text = "院外代送:";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(80, 161);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(79, 23);
            this.txtWeight.TabIndex = 126;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label31.Location = new System.Drawing.Point(6, 164);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(86, 16);
            this.label31.TabIndex = 125;
            this.label31.Text = "体重(KG):";
            // 
            // btnPrefer
            // 
            this.btnPrefer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPrefer.DefaultScheme = true;
            this.btnPrefer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrefer.Hint = "先诊后结通道";
            this.btnPrefer.Location = new System.Drawing.Point(6, 337);
            this.btnPrefer.Name = "btnPrefer";
            this.btnPrefer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrefer.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrefer.Size = new System.Drawing.Size(151, 31);
            this.btnPrefer.TabIndex = 124;
            this.btnPrefer.Text = "先 诊 后 结 通 道";
            this.btnPrefer.Click += new System.EventHandler(this.btnPrefer_Click);
            // 
            // lbeSbAccPay
            // 
            this.lbeSbAccPay.AutoSize = true;
            this.lbeSbAccPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbeSbAccPay.ForeColor = System.Drawing.Color.Black;
            this.lbeSbAccPay.Location = new System.Drawing.Point(88, 253);
            this.lbeSbAccPay.Name = "lbeSbAccPay";
            this.lbeSbAccPay.Size = new System.Drawing.Size(0, 20);
            this.lbeSbAccPay.TabIndex = 53;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 10F);
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(10, 253);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(70, 14);
            this.label30.TabIndex = 52;
            this.label30.Text = "社保记账:";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(124, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(27, 13);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 16);
            this.label16.TabIndex = 50;
            this.label16.Text = "处方类型:";
            // 
            // cmbRecipeType
            // 
            this.cmbRecipeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipeType.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbRecipeType.ItemHeight = 14;
            this.cmbRecipeType.Location = new System.Drawing.Point(8, 130);
            this.cmbRecipeType.Name = "cmbRecipeType";
            this.cmbRecipeType.Size = new System.Drawing.Size(151, 22);
            this.cmbRecipeType.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 16);
            this.label15.TabIndex = 49;
            this.label15.Text = "调处方:";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 16);
            this.label14.TabIndex = 48;
            this.label14.Text = "查找方式:";
            // 
            // lbeFlag
            // 
            this.lbeFlag.Location = new System.Drawing.Point(8, 664);
            this.lbeFlag.Name = "lbeFlag";
            this.lbeFlag.Size = new System.Drawing.Size(80, 24);
            this.lbeFlag.TabIndex = 46;
            this.lbeFlag.Text = "lalbe";
            this.lbeFlag.Visible = false;
            this.lbeFlag.TextChanged += new System.EventHandler(this.lbeFlag_TextChanged);
            // 
            // btPutIn
            // 
            this.btPutIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btPutIn.DefaultScheme = true;
            this.btPutIn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPutIn.Hint = "提交已开的处方,提交后不能修改";
            this.btPutIn.Location = new System.Drawing.Point(84, 406);
            this.btPutIn.Name = "btPutIn";
            this.btPutIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btPutIn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPutIn.Size = new System.Drawing.Size(73, 32);
            this.btPutIn.TabIndex = 1;
            this.btPutIn.Text = "提交(&T)";
            this.btPutIn.Click += new System.EventHandler(this.btPutIn_Click);
            // 
            // btCaseHistory
            // 
            this.btCaseHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btCaseHistory.DefaultScheme = true;
            this.btCaseHistory.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btCaseHistory.Hint = "查看病人的历史病史";
            this.btCaseHistory.Location = new System.Drawing.Point(6, 543);
            this.btCaseHistory.Name = "btCaseHistory";
            this.btCaseHistory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btCaseHistory.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btCaseHistory.Size = new System.Drawing.Size(73, 32);
            this.btCaseHistory.TabIndex = 12;
            this.btCaseHistory.Text = "查病历(&B)";
            this.btCaseHistory.Click += new System.EventHandler(this.btCaseHistory_Click);
            // 
            // btReGroup
            // 
            this.btReGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btReGroup.DefaultScheme = true;
            this.btReGroup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btReGroup.Enabled = false;
            this.btReGroup.Hint = "把西药处方按方号重新排列";
            this.btReGroup.Location = new System.Drawing.Point(6, 577);
            this.btReGroup.Name = "btReGroup";
            this.btReGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btReGroup.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btReGroup.Size = new System.Drawing.Size(73, 32);
            this.btReGroup.TabIndex = 13;
            this.btReGroup.Text = "重组(&M)";
            this.btReGroup.Click += new System.EventHandler(this.btReGroup_Click);
            // 
            // btNew
            // 
            this.btNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btNew.DefaultScheme = true;
            this.btNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btNew.Hint = "开一张新的处方";
            this.btNew.Location = new System.Drawing.Point(6, 370);
            this.btNew.Name = "btNew";
            this.btNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btNew.Size = new System.Drawing.Size(73, 32);
            this.btNew.TabIndex = 7;
            this.btNew.Text = "新建(&N)";
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btInject
            // 
            this.btInject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btInject.DefaultScheme = true;
            this.btInject.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btInject.Hint = "打印治疗注射单";
            this.btInject.Location = new System.Drawing.Point(84, 509);
            this.btInject.Name = "btInject";
            this.btInject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btInject.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btInject.Size = new System.Drawing.Size(73, 32);
            this.btInject.TabIndex = 4;
            this.btInject.Text = "注射单(&I)";
            this.btInject.Click += new System.EventHandler(this.btInject_Click);
            // 
            // btCaseyHistory
            // 
            this.btCaseyHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btCaseyHistory.DefaultScheme = true;
            this.btCaseyHistory.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btCaseyHistory.Hint = "打印病历";
            this.btCaseyHistory.Location = new System.Drawing.Point(84, 475);
            this.btCaseyHistory.Name = "btCaseyHistory";
            this.btCaseyHistory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btCaseyHistory.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btCaseyHistory.Size = new System.Drawing.Size(73, 32);
            this.btCaseyHistory.TabIndex = 3;
            this.btCaseyHistory.Text = "打病历(&P)";
            this.btCaseyHistory.Click += new System.EventHandler(this.btCaseyHistory_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.picops);
            this.groupBox7.Controls.Add(this.picris);
            this.groupBox7.Controls.Add(this.piclis);
            this.groupBox7.Font = new System.Drawing.Font("新宋体", 9F);
            this.groupBox7.Location = new System.Drawing.Point(-172, 194);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(151, 56);
            this.groupBox7.TabIndex = 44;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "开检验检查手术申请";
            this.groupBox7.Visible = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("新宋体", 10F);
            this.label13.Location = new System.Drawing.Point(104, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 16);
            this.label13.TabIndex = 9;
            this.label13.Text = "手术";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("新宋体", 10F);
            this.label12.Location = new System.Drawing.Point(58, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "检查";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("新宋体", 10F);
            this.label11.Location = new System.Drawing.Point(12, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "检验";
            // 
            // lbeSelfPay
            // 
            this.lbeSelfPay.AutoSize = true;
            this.lbeSelfPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbeSelfPay.ForeColor = System.Drawing.Color.Black;
            this.lbeSelfPay.Location = new System.Drawing.Point(88, 224);
            this.lbeSelfPay.Name = "lbeSelfPay";
            this.lbeSelfPay.Size = new System.Drawing.Size(0, 20);
            this.lbeSelfPay.TabIndex = 33;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10F);
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(80, 228);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 14);
            this.label23.TabIndex = 32;
            this.label23.Text = "记账金额:";
            this.label23.Visible = false;
            // 
            // lbeChargeUp
            // 
            this.lbeChargeUp.AutoSize = true;
            this.lbeChargeUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbeChargeUp.ForeColor = System.Drawing.Color.Black;
            this.lbeChargeUp.Location = new System.Drawing.Point(158, 255);
            this.lbeChargeUp.Name = "lbeChargeUp";
            this.lbeChargeUp.Size = new System.Drawing.Size(0, 20);
            this.lbeChargeUp.TabIndex = 31;
            this.lbeChargeUp.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 30;
            this.label8.Text = "自付金额:";
            // 
            // BtExit
            // 
            this.BtExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BtExit.DefaultScheme = true;
            this.BtExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtExit.Hint = "退出系统";
            this.BtExit.Location = new System.Drawing.Point(84, 577);
            this.BtExit.Name = "BtExit";
            this.BtExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BtExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.BtExit.Size = new System.Drawing.Size(73, 32);
            this.BtExit.TabIndex = 6;
            this.BtExit.Text = "退出(ESC)";
            this.BtExit.Click += new System.EventHandler(this.BtExit_Click);
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btClear.DefaultScheme = true;
            this.btClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btClear.Hint = "清空病历和处方内容";
            this.btClear.Location = new System.Drawing.Point(6, 509);
            this.btClear.Name = "btClear";
            this.btClear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btClear.Size = new System.Drawing.Size(73, 32);
            this.btClear.TabIndex = 11;
            this.btClear.Text = "清空(&Q)";
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // lbeSumMoney
            // 
            this.lbeSumMoney.AutoSize = true;
            this.lbeSumMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbeSumMoney.ForeColor = System.Drawing.Color.Black;
            this.lbeSumMoney.Location = new System.Drawing.Point(88, 278);
            this.lbeSumMoney.Name = "lbeSumMoney";
            this.lbeSumMoney.Size = new System.Drawing.Size(0, 20);
            this.lbeSumMoney.TabIndex = 20;
            this.lbeSumMoney.TextChanged += new System.EventHandler(this.lbeSumMoney_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(10, 279);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 14);
            this.label21.TabIndex = 19;
            this.label21.Text = "总    额:";
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btSave.DefaultScheme = true;
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSave.Hint = "保存所有数据";
            this.btSave.Location = new System.Drawing.Point(84, 370);
            this.btSave.Name = "btSave";
            this.btSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btSave.Size = new System.Drawing.Size(73, 32);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "保存(F3)";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // m_btnEndTake
            // 
            this.m_btnEndTake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnEndTake.DefaultScheme = true;
            this.m_btnEndTake.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnEndTake.Hint = "把当前病人结论诊";
            this.m_btnEndTake.Location = new System.Drawing.Point(6, 441);
            this.m_btnEndTake.Name = "m_btnEndTake";
            this.m_btnEndTake.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_btnEndTake.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnEndTake.Size = new System.Drawing.Size(73, 32);
            this.m_btnEndTake.TabIndex = 9;
            this.m_btnEndTake.Text = "结诊(&O)";
            this.m_btnEndTake.Click += new System.EventHandler(this.m_btnEndTake_Click);
            // 
            // btPrint
            // 
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "打印处方";
            this.btPrint.Location = new System.Drawing.Point(84, 441);
            this.btPrint.Name = "btPrint";
            this.btPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(73, 32);
            this.btPrint.TabIndex = 2;
            this.btPrint.Text = "打处方(&L)";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // m_btnBackWait
            // 
            this.m_btnBackWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnBackWait.DefaultScheme = true;
            this.m_btnBackWait.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnBackWait.Hint = "把病人退回候诊列表";
            this.m_btnBackWait.Location = new System.Drawing.Point(6, 475);
            this.m_btnBackWait.Name = "m_btnBackWait";
            this.m_btnBackWait.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_btnBackWait.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnBackWait.Size = new System.Drawing.Size(73, 32);
            this.m_btnBackWait.TabIndex = 10;
            this.m_btnBackWait.Text = "候诊(&W)";
            this.m_btnBackWait.Click += new System.EventHandler(this.m_btnBackWait_Click);
            // 
            // btDel
            // 
            this.btDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btDel.DefaultScheme = true;
            this.btDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btDel.Hint = "作废处方,已收费处方不能作废";
            this.btDel.Location = new System.Drawing.Point(84, 543);
            this.btDel.Name = "btDel";
            this.btDel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btDel.Size = new System.Drawing.Size(73, 32);
            this.btDel.TabIndex = 5;
            this.btDel.Text = "作废(&Z)";
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtFindAccordRecipe);
            this.groupBox6.Controls.Add(this.cmbFindAccordRecipe);
            this.groupBox6.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(-168, 202);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(146, 16);
            this.groupBox6.TabIndex = 43;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "处方模板";
            this.groupBox6.Visible = false;
            // 
            // txtFindAccordRecipe
            // 
            this.txtFindAccordRecipe.Location = new System.Drawing.Point(8, 44);
            this.txtFindAccordRecipe.Name = "txtFindAccordRecipe";
            this.txtFindAccordRecipe.Size = new System.Drawing.Size(136, 23);
            this.txtFindAccordRecipe.TabIndex = 39;
            this.txtFindAccordRecipe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFindAccordRecipe_KeyDown);
            // 
            // cmbFindAccordRecipe
            // 
            this.cmbFindAccordRecipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindAccordRecipe.Items.AddRange(new object[] {
            "按名称查找",
            "按助记码查找",
            "按拼音码查找",
            "按五笔码查找"});
            this.cmbFindAccordRecipe.Location = new System.Drawing.Point(8, 20);
            this.cmbFindAccordRecipe.Name = "cmbFindAccordRecipe";
            this.cmbFindAccordRecipe.Size = new System.Drawing.Size(136, 22);
            this.cmbFindAccordRecipe.TabIndex = 0;
            this.cmbFindAccordRecipe.SelectedIndexChanged += new System.EventHandler(this.cmbFindAccordRecipe_SelectedIndexChanged);
            // 
            // btReUse
            // 
            this.btReUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btReUse.DefaultScheme = true;
            this.btReUse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btReUse.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.btReUse.Hint = "重新使用当前处方内容";
            this.btReUse.Location = new System.Drawing.Point(108, 88);
            this.btReUse.Name = "btReUse";
            this.btReUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btReUse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btReUse.Size = new System.Drawing.Size(38, 15);
            this.btReUse.TabIndex = 1;
            this.btReUse.Text = "复用";
            this.btReUse.Visible = false;
            this.btReUse.Click += new System.EventHandler(this.btReUse_Click);
            // 
            // lblIsVip
            // 
            this.lblIsVip.BackColor = System.Drawing.Color.Transparent;
            this.lblIsVip.Enabled = false;
            this.lblIsVip.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIsVip.ForeColor = System.Drawing.Color.Blue;
            this.lblIsVip.Location = new System.Drawing.Point(527, 40);
            this.lblIsVip.Name = "lblIsVip";
            this.lblIsVip.Size = new System.Drawing.Size(119, 13);
            this.lblIsVip.TabIndex = 123;
            this.lblIsVip.Text = "符合先诊疗后结算";
            this.lblIsVip.Click += new System.EventHandler(this.lblIsVip_Click);
            // 
            // lblFunction
            // 
            this.lblFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFunction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFunction.Location = new System.Drawing.Point(851, 7);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(168, 600);
            this.lblFunction.TabIndex = 33;
            // 
            // m_PatInfo
            // 
            this.m_PatInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PatInfo.Charge = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_PatInfo.CurrentDeptID = "";
            this.m_PatInfo.CurrentDeptName = "";
            this.m_PatInfo.CurrentDoctorID = "";
            this.m_PatInfo.CurrentDoctorName = "";
            this.m_PatInfo.CurrentDoctorNo = "";
            this.m_PatInfo.CurrentDoctTechnicalRank = "";
            this.m_PatInfo.DeptID = "";
            this.m_PatInfo.DeptName = "";
            this.m_PatInfo.Discount = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_PatInfo.DoctorID = "";
            this.m_PatInfo.DoctorName = "";
            this.m_PatInfo.DoctorNo = "";
            this.m_PatInfo.DoctTechnicalRank = "";
            this.m_PatInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_PatInfo.HotKey = "F3";
            this.m_PatInfo.Hypersusceptibility = "";
            this.m_PatInfo.IDcard = "";
            this.m_PatInfo.Limit = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_PatInfo.Location = new System.Drawing.Point(0, 0);
            this.m_PatInfo.m_strIsVip = "";
            this.m_PatInfo.Name = "m_PatInfo";
            this.m_PatInfo.PatientAge = "";
            this.m_PatInfo.PatientBirth = "";
            this.m_PatInfo.PatientCardID = "";
            this.m_PatInfo.PatientHomeAddress = "";
            this.m_PatInfo.PatientID = "";
            this.m_PatInfo.PatientName = "";
            this.m_PatInfo.PatientSex = "";
            this.m_PatInfo.PatientTelephoneNo = "";
            this.m_PatInfo.PatientType = 0;
            this.m_PatInfo.PayTypeID = "";
            this.m_PatInfo.PayTypeName = "";
            this.m_PatInfo.RegisterID = "";
            this.m_PatInfo.RegisterNo = "";
            this.m_PatInfo.RegTypeID = "";
            this.m_PatInfo.Size = new System.Drawing.Size(848, 96);
            this.m_PatInfo.TabIndex = 24;
            this.m_PatInfo.TakeDiagRecID = "";
            this.m_PatInfo.PatientChanged += new com.digitalwave.controls.TextChangeEvent(this.m_PatInfo_PatientChanged);
            this.m_PatInfo.PatientEnd += new System.EventHandler(this.m_PatInfo_PatientEnd);
            this.m_PatInfo.SelectDoctor += new System.EventHandler(this.m_PatInfo_SelectDoctor);
            this.m_PatInfo.PatientTypeChanged += new com.digitalwave.controls.HandlePatientTypeChange(this.m_PatInfo_PatientTypeChanged);
            // 
            // frmDoctorWorkstation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1028, 611);
            this.Controls.Add(this.lblIsVip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lbeTimes);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.alertLight1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_PatInfo);
            this.Controls.Add(this.lblFunction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDoctorWorkstation";
            this.Text = "医生工作站";
            this.Load += new System.EventHandler(this.frmDoctorWorkstation_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmDoctorWorkstation_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDoctorWorkstation_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclis)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgWaitReg)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgTake)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid2)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGridLis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid3)).EndInit();
            this.plLis.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.plTest.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGridTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid4)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.plOps.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGridOps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid5)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid6)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_DoctorWorkstation();
            objController.Set_GUI_Apperance(this);
        }

        #region 公共属性
        //
        public string PatientTypeName
        {
            get
            {
                return this.m_PatInfo.txtType.Text;
            }
        }
        public string PatientTypeID
        {
            get
            {
                return this.m_PatInfo.PayTypeID;
            }
        }
        public string DoctorName
        {
            get
            {
                return this.m_PatInfo.txtRegisterDoctor.Text;
            }
        }
        public string DoctorID
        {
            get
            {
                return this.m_PatInfo.DoctorID;
            }
        }
        public string DepName
        {
            get
            {
                return this.m_PatInfo.txtRegisterDept.Text;
            }
        }
        public string DepID
        {
            get
            {
                return this.m_PatInfo.DeptID;
            }
        }
        /////////////
        public string ExamineResult
        {
            get
            {
                return this.objCaseHistory.ExamineResult;
            }
        }
        public string AidCheck
        {
            get
            {
                return this.objCaseHistory.AidCheck;
            }
        }
        public string Anaphylaxis
        {
            get
            {
                return this.objCaseHistory.Anaphylaxis;
            }
        }
        public string Treatment
        {
            get
            {
                return this.objCaseHistory.Treatment;
            }
        }
        public string ReMark
        {
            get
            {
                return this.objCaseHistory.ReMark;
            }
        }
        /// ///////////////////////////
        public string PatientName
        {
            get
            {
                return this.m_PatInfo.PatientName;
            }
        }
        public string PatientID
        {
            get
            {
                return this.m_PatInfo.PatientID;
            }
        }
        public string PatientSex
        {
            get
            {
                return this.m_PatInfo.PatientSex;
            }
        }
        public string PatientAge
        {
            get
            {
                return this.m_PatInfo.PatientAge;
            }
        }
        public string PatientCardID
        {
            get
            {
                return this.m_PatInfo.PatientCardID;
            }
        }
        public string DiagMain
        {
            get
            {
                return this.objCaseHistory.DiagMain;
            }
        }
        public string DiagCurr
        {
            get
            {
                return this.objCaseHistory.DiagCurr;
            }
        }
        public string DiagHis
        {
            get
            {
                return this.objCaseHistory.DiagHis;
            }
        }
        public string Diag
        {
            get
            {
                return this.objCaseHistory.Diag;
            }
        }
        public string ChargeItemName
        {
            get
            {
                string temp = "";
                int int_Count = 1;
                for (int i = 0; i < this.ctlDataGrid1.RowCount; i++)
                {
                    if (objUsageArr.IndexOf(ctlDataGrid1[i, 16].ToString().Trim()) > -1)
                    {
                        temp += int_Count.ToString() + "、" + ctlDataGrid1[i, 4].ToString().Trim() + "\n";
                        int_Count++;
                    }
                }
                return temp;
            }
        }

        public string ChargeItemCount
        {
            get
            {
                string temp = "";
                int int_Count = 1;
                for (int i = 0; i < this.ctlDataGrid1.RowCount; i++)
                {
                    if (objUsageArr.IndexOf(ctlDataGrid1[i, 16].ToString().Trim()) > -1)
                    {
                        temp += int_Count.ToString() + "、" + ctlDataGrid1[i, 2].ToString().Trim() + "\n";
                        int_Count++;
                    }
                }
                return temp;
            }
        }
        public string ChargeItemUsage
        {
            get
            {
                string temp = "";
                int int_Count = 1;
                for (int i = 0; i < this.ctlDataGrid1.RowCount; i++)
                {
                    if (objUsageArr.IndexOf(ctlDataGrid1[i, 16].ToString().Trim()) > -1)
                    {
                        temp += int_Count.ToString() + "、" + ctlDataGrid1[i, 6].ToString().Trim() + "\n";
                        int_Count++;
                    }
                }
                return temp;
            }
        }

        public int URGENCY_INT
        {
            get
            {
                return intURGENCY_INT;
            }
        }

        /// <summary>
        /// 记录注射用法的ID
        /// </summary>
        public ArrayList objUsageArr;

        /// <summary>
        /// 当前操作员无处方权限时直接退出该窗体
        /// </summary>
        private bool noopen = false;
        #endregion

        #region 控制DataGrid列
        private void m_mthHandleDataGridInput()
        {
            foreach (System.Windows.Forms.Control cc in this.tabControl1.Controls)
            {
                foreach (System.Windows.Forms.Control c in cc.Controls)
                {
                    com.digitalwave.controls.datagrid.ctlDataGrid dategrid = c as com.digitalwave.controls.datagrid.ctlDataGrid;
                    if (dategrid != null)
                    {
                        for (int i = 0; i < dategrid.Columns.Count; i++)
                        {
                            if (((com.digitalwave.controls.datagrid.clsColumnInfo)dategrid.Columns[i]).DataGridTextBoxColumn.TextBox.Enabled == false || ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[i]).DataGridTextBoxColumn.TextBox.MaxLength < 10)
                            {
                                continue;
                            }
                            ((com.digitalwave.controls.datagrid.clsColumnInfo)dategrid.Columns[i]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                        }
                    }
                }
            }

        }
        private void m_mthSetDataGridFormat()
        {
            m_mthHandleDataGridInput();
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[2]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[13]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[8]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress2);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress2);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress3);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(RecipeTextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(RecipeTextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);

            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[2]).DataGridTextBoxColumn.TextBox.MaxLength = 7;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 2;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 4;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 4;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 4;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 4;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 4;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[2]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[8]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;

            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = CharacterCasing.Upper;

            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 20;

        }
        #endregion

        private void frmDoctorWorkstation_Load(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_DoctorWorkstation)this.objController).m_mthIniComponent();
            if (((clsCtl_DoctorWorkstation)this.objController).Recpur == "0")
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("对不起，您暂时无处方权限。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                noopen = true;
                this.Hide();
                this.timerRecpur.Enabled = true;
                this.timerRecpur.Interval = 2000;
                return;
            }
            this.m_mthSetDataGridFormat();
            m_mthLoadApplyBill();
            //读取是否合并门、急诊药房
            IsDetachWMedStore = ((clsCtl_DoctorWorkstation)this.objController).m_strReadXML("register", "IsDetachWMedStore", "AnyOne") != "" ? int.Parse(((clsCtl_DoctorWorkstation)this.objController).m_strReadXML("register", "IsDetachWMedStore", "AnyOne")) : 0;
            ((clsCtl_DoctorWorkstation)this.objController).m_mthGetinjectInfo(out objUsageArr);
            if (this.LoginInfo.m_strDepartmentID != null && this.LoginInfo.m_strDepartmentID.Trim() != "")
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_GetWaitReg(this.LoginInfo.m_strEmpID, this.LoginInfo.m_strDepartmentID, this.LoginInfo.m_strdepartmentName);
            }
            //药品天数参数
            intMedDays = ((clsCtl_DoctorWorkstation)this.objController).m_intGetMedDays();
            //当天日期
            lblToday.Text = DateTime.Now.Date.ToString("yyyy年MM月dd日");
            //过敏提示窗口坐标
            frmAllergich.DesktopLocation = new Point(630, 620);
            //设置记时器(过敏)		
            int ti = ((clsCtl_DoctorWorkstation)this.objController).Timerinterval;
            if (ti != 0)
            {
                this.timer.Enabled = true;
                this.timer.Interval = ti * 60 * 1000;
            }
            //护士工作站：过敏人员列表窗口
            frmAllergicl.StartPosition = FormStartPosition.Manual;
            frmAllergicl.Location = new Point(10, 208);

            //设置记时器(审核未通过处方)		
            int tirec = ((clsCtl_DoctorWorkstation)this.objController).Timerinterval_rec;
            if (tirec != 0)
            {
                this.timerrec.Enabled = true;
                this.timerrec.Interval = tirec * 60 * 1000;
            }

            //处方审核未通过列表窗口
            frmRecconf.StartPosition = FormStartPosition.Manual;
            frmRecconf.Location = new Point(10, 208);

            //绑定速诊CBO控件
            TextBox tb = ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[((clsCtl_DoctorWorkstation)this.objController).t_quick]).DataGridTextBoxColumn.TextBox;
            if (tb != null)
            {
                this.ctlDataGrid3.Controls.Add(this.cboquick);
                tb.Enter += new EventHandler(TB_Enter);
            }

            //控制修改医生姓名
            this.m_PatInfo.txtRegisterDoctor.Enabled = !(((clsCtl_DoctorWorkstation)this.objController).isCanChangeDoctor);

            #region 明细处方栏绑定科备药标志
            if (((clsCtl_DoctorWorkstation)this.objController).Isdeptmed)
            {
                //西药
                tb = ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[((clsCtl_DoctorWorkstation)this.objController).c_Deptmed]).DataGridTextBoxColumn.TextBox;
                if (tb != null)
                {
                    this.ctlDataGrid1.Controls.Add(this.cboDeptmed1);
                    tb.Enter += new EventHandler(cboDeptmed1_Enter);
                }
                //中药
                tb = ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[((clsCtl_DoctorWorkstation)this.objController).cm_Deptmed]).DataGridTextBoxColumn.TextBox;
                if (tb != null)
                {
                    this.ctlDataGrid2.Controls.Add(this.cboDeptmed2);
                    tb.Enter += new EventHandler(cboDeptmed2_Enter);
                }
                //其他
                tb = ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[((clsCtl_DoctorWorkstation)this.objController).o_Deptmed]).DataGridTextBoxColumn.TextBox;
                if (tb != null)
                {
                    this.ctlDataGrid6.Controls.Add(this.cboDeptmed6);
                    tb.Enter += new EventHandler(cboDeptmed6_Enter);
                }
            }
            #endregion

            if (((clsCtl_DoctorWorkstation)this.objController).m_strReadXML("register", "UseCall", "AnyOne") == "1")
            {
                frmDiag = new DiagnoseClient.frmDiagClientMain();
                frmDiag.ShowTopLevel();
                DiagnoseClient.frmDiagClientMain.PatientCalled += new DiagnoseClient.PatientCalledEventHandler(frmDiagClientMain_PatientCalled);
            }

            m_PatInfo.m_strUserCall = ((clsCtl_DoctorWorkstation)this.objController).m_strReadXML("register", "EnableCallMSMQ", "AnyOne");
            this.btnPrefer.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        private delegate void v1(string id);
        private void frmDiagClientMain_PatientCalled(object sender, DiagnoseClient.PatientCalledArgs e)
        {
            this.m_PatInfo.Invoke(new v1(this.m_PatInfo.m_mthGetPatientInfoByCard), e.CardNo);
        }

        private void m_cmbFind_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (m_cmbFind.SelectedIndex)
            {
                case 0://项目编码
                    m_cmbFind.Tag = "ITEMCODE_VCHR";
                    cmbFindAccordRecipe.Tag = "USERCODE_CHR";
                    this.groupBox3.Tag = "";
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                    break;
                case 1://项目名称
                    m_cmbFind.Tag = "ITEMNAME_VCHR";
                    cmbFindAccordRecipe.Tag = "RECIPENAME_CHR";
                    this.groupBox3.Tag = "%";
                    break;
                case 2://项目拼音
                    m_cmbFind.Tag = "ITEMPYCODE_CHR";
                    cmbFindAccordRecipe.Tag = "PYCODE_CHR";
                    this.groupBox3.Tag = "";
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                    break;
                case 3://项目五笔
                    m_cmbFind.Tag = "ITEMWBCODE_CHR";
                    cmbFindAccordRecipe.Tag = "WBCODE_CHR";
                    this.groupBox3.Tag = "";
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                    break;
                case 4:
                    m_cmbFind.Tag = "ITEMENGNAME_VCHR";
                    this.groupBox3.Tag = "";
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                    break;
            }

        }

        private void m_cmbRecipeType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (m_cmbRecipeType.SelectedIndex == 0)
            {
                m_cmbRecipeType.Tag = 1;//正方
            }
            else
            {
                m_cmbRecipeType.Tag = 2;//副方
            }
        }



        private void listView1_Leave(object sender, System.EventArgs e)
        {
            listView1.Height = 0;
            listView1.Visible = false;
        }

        private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthListViewKeyDown(e);
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthListViewDoubleClick();
        }
        #region DataGrid回车事件
        private void ctlDataGrid1_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            //			((clsCtl_DoctorWorkstation)this.objController).m_mthShowPriceInfo("",1,e);
            string m_strText = e.m_strText.Replace("'", "’");
            this.intRowNo1 = e.m_intRowNumber;

            if (e.KeyCode == Keys.Enter)
            {
                switch (e.m_intColNumber)
                {
                    case 0://方号
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthSetRowNo(m_strText, e.m_intRowNumber, this.ctlDataGrid1[e.m_intRowNumber, 0].ToString().Trim(), 0);
                        break;
                    case 1://查询
                        if (m_strText.Trim() == "")
                        {
                            return;
                        }
                        else
                        {
                            if (this.m_cmbFind.SelectedIndex == 2)
                            {
                                m_strText = m_strText.ToUpper();
                            }
                            if (m_strText.IndexOf("\\") == 0)
                            {
                                if (((clsCtl_DoctorWorkstation)this.objController).ItemInputMode == 0)
                                {
                                    ((clsCtl_DoctorWorkstation)this.objController).m_mthFindAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                                }
                                else if (((clsCtl_DoctorWorkstation)this.objController).ItemInputMode == 1)
                                {
                                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                                }
                            }
                            else if (m_strText.Replace("？", "?").IndexOf("?") == 0)
                            {
                                ((clsCtl_DoctorWorkstation)this.objController).m_mthGetMedicineByCodex(e.m_intRowNumber);
                            }
                            else
                            {
                                ((clsCtl_DoctorWorkstation)this.objController).m_mthFindWMedicineByID(this.groupBox3.Tag.ToString() + m_strText, e.m_intRowNumber);
                            }
                        }
                        this.cboDeptmed1.SelectedIndex = 1;
                        break;
                    case 2://数量
                        if (m_strText.Trim() == "")
                        {
                            return;
                        }
                        else
                        {
                            //							((clsCtl_DoctorWorkstation)this.objController).IsCalculateAmount=true;
                            ctlDataGrid1[e.m_intRowNumber, 2] = m_strText;

                            //							((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGrid1[e.m_intRowNumber,c_resubitem].ToString(), this.ctlDataGrid1[e.m_intRowNumber,c_MainItemNum].ToString(), m_strText);

                            if (!((clsCtl_DoctorWorkstation)this.objController).m_mthIsOverflow(this.ctlDataGrid1.CurrentCell.RowNumber, m_strText))
                            {
                                return;
                            }

                            ctlDataGrid1[e.m_intRowNumber, 26] = 1;
                            ctlDataGrid1.CurrentCell = new DataGridCell(e.m_intRowNumber, 6);
                        }
                        break;
                    case 6://用法
                        if (((clsCtl_DoctorWorkstation)this.objController).m_mthFindUsage(m_strText, e.m_intRowNumber) > 0)
                        {
                            this.listView2.Location = e.m_ptPositionInDataGrid;
                            this.listView2.Top += e.m_szTextBoxSize.Height;
                            this.listView2.Show();
                            this.listView2.BringToFront();
                            this.listView2.Items[0].Selected = true;
                            this.listView2.Select();
                            this.listView2.Focus();
                        }
                        break;
                    case 7://频率
                        if (((clsCtl_DoctorWorkstation)this.objController).m_mthFindFrequency(m_strText, e.m_intRowNumber) > 0)
                        {
                            this.listView3.Location = e.m_ptPositionInDataGrid;
                            this.listView3.Top += e.m_szTextBoxSize.Height;
                            this.listView3.Show();
                            this.listView3.BringToFront();
                            this.listView3.Items[0].Selected = true;
                            this.listView3.Select();
                            this.listView3.Focus();
                        }
                        break;
                    case 8://天数
                        if (m_strText.Trim() != "")
                        {
                            if (intMedDays > 0 && intMedDays < int.Parse(m_strText))
                            {
                                MessageBox.Show(m_strText + "天超过了医院规定的最大天数，最大天数是" + intMedDays.ToString() + "天，请修改!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            ctlDataGrid1[e.m_intRowNumber, 26] = 1;
                            ctlDataGrid1[e.m_intRowNumber, 8] = m_strText;
                            ((clsCtl_DoctorWorkstation)this.objController).m_mthDaysEnter(m_strText);
                        }
                        break;
                    case 13://天数
                        if (m_strText.Trim() != "")
                        {
                            //								this.ctlDataGrid1.CurrentCell=new DataGridCell(e.m_intRowNumber+1,0);
                            SendKeys.SendWait("{Tab}");
                        }
                        break;

                }
            }
            else
            {
                if (e.m_intColNumber == 13 && m_strText.Trim() != "")
                {
                    ctlDataGrid1[e.m_intRowNumber, 13] = m_strText;
                    ctlDataGrid1[e.m_intRowNumber, 26] = 0;
                    ((clsCtl_DoctorWorkstation)this.objController).b_IndexChangeFlag = false;
                }

            }

            //			((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        private void ctlDataGrid2_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            //			((clsCtl_DoctorWorkstation)this.objController).m_mthShowPriceInfo("",2,e);
            //			((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
            string m_strText = e.m_strText.Replace("'", "’");
            intRowNo2 = e.m_intRowNumber;
            if (e.KeyCode == Keys.Enter)//查询
            {

                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }
                    //					intRowNo2=e.m_intRowNumber;
                    //					string m_strText =e.m_strText;
                    if (this.m_cmbFind.SelectedIndex == 2)
                    {
                        m_strText = m_strText.ToUpper();
                    }
                    if (m_strText.IndexOf("\\") == 0)
                    {
                        if (((clsCtl_DoctorWorkstation)this.objController).ItemInputMode == 0)
                        {
                            ((clsCtl_DoctorWorkstation)this.objController).m_mthFindAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                        }
                        else if (((clsCtl_DoctorWorkstation)this.objController).ItemInputMode == 1)
                        {
                            ((clsCtl_DoctorWorkstation)this.objController).m_mthGetAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                        }
                    }
                    else if (m_strText.Replace("？", "?").IndexOf("?") == 0)
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthGetMedicineByCodex(e.m_intRowNumber);
                    }
                    else
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindCMedicineByID(this.groupBox3.Tag.ToString() + m_strText, e.m_intRowNumber);
                    }
                    this.cboDeptmed2.SelectedIndex = 1;
                }

                if (e.m_intColNumber == 1)//输入数量
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }
                    if (!((clsCtl_DoctorWorkstation)this.objController).m_mthIsOverflow2(this.ctlDataGrid2.CurrentCell.RowNumber, m_strText))
                    {
                        return;
                    }
                    this.ctlDataGrid2[e.m_intRowNumber, 1] = m_strText;
                    intRowNo2 = e.m_intRowNumber;
                    if (e.KeyCode == Keys.Enter)
                    {
                        //					ctlDataGrid2.CurrentCell=new DataGridCell(e.m_intRowNumber+1,0);
                        ctlDataGrid2.CurrentCell = new DataGridCell(e.m_intRowNumber, 5);
                    }
                }
                if (e.m_intColNumber == 5)//选择用法
                {
                    if (((clsCtl_DoctorWorkstation)this.objController).m_mthFindUsage2(m_strText, e.m_intRowNumber) > 0)
                    {
                        this.listView4.Location = e.m_ptPositionInDataGrid;
                        this.listView4.Top += e.m_szTextBoxSize.Height;
                        this.listView4.Show();
                        this.listView4.BringToFront();
                        this.listView4.Items[0].Selected = true;
                        this.listView4.Select();
                        this.listView4.Focus();
                    }
                }
            }

        }
        private void ctlDataGrid3_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {

                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }
                    if (m_strText.IndexOf("\\") == 0)
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                    }
                    else
                    {
                        intRowNo3 = e.m_intRowNumber;
                        //						string m_strText =m_strText;
                        if (this.m_cmbFind.SelectedIndex == 2)
                        {
                            m_strText = m_strText.ToUpper();
                        }
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindTestChargeByID(this.groupBox3.Tag.ToString() + m_strText, e.m_intRowNumber);
                    }
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNo3 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGrid3[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString(), this.ctlDataGrid3[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_MainItemNum].ToString(), m_strText, null);
                    SendKeys.SendWait("{Tab}");
                }
            }
            if (e.m_intColNumber == 4)//查询检验类型
            {
                intRowNo3 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (((clsCtl_DoctorWorkstation)this.objController).m_lngGetLisSampletyType(m_strText, e.m_intRowNumber) > 0)
                    {
                        this.listView5.Location = e.m_ptPositionInDataGrid;
                        this.listView5.Top += e.m_szTextBoxSize.Height;
                        this.listView5.Show();
                        this.listView5.BringToFront();
                        this.listView5.Items[0].Selected = true;
                        this.listView5.Select();
                        this.listView5.Focus();
                    }
                }
            }
            if (e.m_intColNumber == 6)//输入单价
            {
                intRowNo3 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.SendWait("{Tab}");
                }
            }


            //			((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        private void ctlDataGrid4_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {

                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }
                    if (m_strText.IndexOf("\\") == 0)
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                    }
                    else
                    {
                        intRowNo4 = e.m_intRowNumber;
                        //						string m_strText =m_strText;
                        if (this.m_cmbFind.SelectedIndex == 2)
                        {
                            m_strText = m_strText.ToUpper();
                        }
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindExamineChargeByID(this.groupBox3.Tag.ToString() + m_strText, e.m_intRowNumber);
                    }
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                //				this.ctlDataGrid4[e.m_intRowNumber,1]=m_strText;
                intRowNo4 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGrid4[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString(), this.ctlDataGrid4[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_MainItemNum].ToString(), m_strText, null);
                    SendKeys.SendWait("{Tab}");
                }
            }
            if (e.m_intColNumber == 4)//输入检查部位
            {
                intRowNo4 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (((clsCtl_DoctorWorkstation)this.objController).m_mthLoadCheckPart(m_strText, e.m_intRowNumber) > 0)
                    {
                        this.listView5.Location = e.m_ptPositionInDataGrid;
                        this.listView5.Top += e.m_szTextBoxSize.Height;
                        this.listView5.Show();
                        this.listView5.BringToFront();
                        this.listView5.Items[0].Selected = true;
                        this.listView5.Select();
                        this.listView5.Focus();
                    }
                }
            }
            if (e.m_intColNumber == 5)//输入单价
            {
                intRowNo4 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.SendWait("{Tab}");
                }
            }
            //	
            //			((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        private void ctlDataGrid5_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }
                    if (m_strText.IndexOf("\\") == 0)
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                    }
                    else
                    {
                        intRowNo5 = e.m_intRowNumber;
                        //						string m_strText =m_strText;
                        if (this.m_cmbFind.SelectedIndex == 2)
                        {
                            m_strText = m_strText.ToUpper();
                        }
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindOPSChargeByID(this.groupBox3.Tag.ToString() + m_strText, e.m_intRowNumber);
                    }
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNo5 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGrid5[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_resubitem].ToString(), this.ctlDataGrid5[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_MainItemNum].ToString(), m_strText, null);
                    SendKeys.SendWait("{Tab}");
                }
            }
            if (e.m_intColNumber == 5)//输入单价
            {
                intRowNo5 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.SendWait("{Tab}");
                }
            }


        }
        private void ctlDataGrid6_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {

                    if (m_strText.Trim() == "")
                    {
                        return;
                    }
                    if (m_strText.IndexOf("\\") == 0)
                    {
                        if (((clsCtl_DoctorWorkstation)this.objController).ItemInputMode == 0)
                        {
                            ((clsCtl_DoctorWorkstation)this.objController).m_mthFindAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                        }
                        else if (((clsCtl_DoctorWorkstation)this.objController).ItemInputMode == 1)
                        {
                            ((clsCtl_DoctorWorkstation)this.objController).m_mthGetAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                        }
                    }
                    else
                    {
                        intRowNo6 = e.m_intRowNumber;
                        //						string m_strText =m_strText;
                        if (this.m_cmbFind.SelectedIndex == 2)
                        {
                            m_strText = m_strText.ToUpper();
                        }
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindOtherChargeByID(this.groupBox3.Tag.ToString() + m_strText, e.m_intRowNumber);
                    }
                    this.cboDeptmed6.SelectedIndex = 1;
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNo6 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGrid6[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_resubitem].ToString(), this.ctlDataGrid6[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_MainItemNum].ToString(), m_strText, null);
                    SendKeys.SendWait("{Tab}");
                }
            }
            if (e.m_intColNumber == 5)//输入单价
            {
                intRowNo6 = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.SendWait("{Tab}");
                }
            }
        }
        #endregion
        #region CellChange事件
        private void ctlDataGrid1_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateAmount();
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNo1();
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
            intRowNo1 = -1;
            int row = ctlDataGrid1.CurrentCell.RowNumber;
            if (this.ctlDataGrid1[row, 0].ToString().Trim() == "" || this.ctlDataGrid1[row, 0].ToString().Trim() == "0")
            {
                this.ctlDataGrid1[row, 29] = -4;
            }
            int col = ctlDataGrid1.CurrentCell.ColumnNumber;
            if (col != 1)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[col] != null)
            {
                //设置前背景色
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;						
            }
        }

        private void ctlDataGrid2_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNo2();

            if (this.intRowNo2 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateAmount2(this.intRowNo2);
                this.intRowNo2 = -1;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
            int row = ctlDataGrid1.CurrentCell.RowNumber;
            int col = ctlDataGrid1.CurrentCell.ColumnNumber;
            if (col != 0)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[col] != null)
            {
                //设置前背景色
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid2.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
        }

        private void ctlDataGrid3_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNo3();
            if (this.intRowNo3 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthAddItemToCulateClass(this.intRowNo3, 3);
                this.intRowNo3 = -1;
            }
            //设置前背景色
            int row = ctlDataGrid3.CurrentCell.RowNumber;
            int col = ctlDataGrid3.CurrentCell.ColumnNumber;
            if (col != 0)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid3.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
        }

        private void ctlDataGrid4_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNo4();
            if (this.intRowNo4 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthAddItemToCulateClass(this.intRowNo4, 4);
                this.intRowNo4 = -1;
            }
            //设置前背景色
            int row = ctlDataGrid4.CurrentCell.RowNumber;
            int col = ctlDataGrid4.CurrentCell.ColumnNumber;
            if (col != 0)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid4.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc; //Color.SteelBlue;			
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
        }

        private void ctlDataGrid5_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNo5();
            if (this.intRowNo5 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthAddItemToCulateClass(this.intRowNo5, 5);
                this.intRowNo5 = -1;
            }

            //设置前背景色
            int row = ctlDataGrid5.CurrentCell.RowNumber;
            int col = ctlDataGrid5.CurrentCell.ColumnNumber;

            if (col != 0)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid5.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
        }

        private void ctlDataGrid6_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNo6();
            if (this.intRowNo6 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthAddItemToCulateClass(this.intRowNo6, 6);
                this.intRowNo6 = -1;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
            //设置前背景色
            int row = ctlDataGrid6.CurrentCell.RowNumber;
            int col = ctlDataGrid6.CurrentCell.ColumnNumber;
            if (col != 0)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid6.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
        }
        #endregion

        private void listView3_Leave(object sender, System.EventArgs e)
        {
            this.listView3.Hide();
        }

        private void listView3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthListViewKeyDown3(e);
        }

        private void listView3_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthListViewDoubleClick3();
        }

        private void listView2_Leave(object sender, System.EventArgs e)
        {
            this.listView2.Hide();
            //			((clsCtl_DoctorWorkstation)this.objController).m_mthListViewDoubleClick2();
        }

        private void listView2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthListViewKeyDown2(e);
        }

        private void btSave_Click(object sender, System.EventArgs e)
        {
            this.btSave.Enabled = false;
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSaveAllData();
            this.btSave.Enabled = true;
        }

        private void BtExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void lblIsVip_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("该病人符合先诊疗后结算！");
        }

        public void m_mthEnableIsVip()
        {
            this.lblIsVip.ForeColor = System.Drawing.Color.Red;
            this.lblIsVip.Enabled = true;
            this.lblIsVip.Cursor = Cursors.Hand;
        }

        public void m_mthDisableIsVip()
        {
            this.lblIsVip.ForeColor = System.Drawing.Color.Gray;
            this.lblIsVip.Enabled = false;
        }

        private void m_PatInfo_PatientChanged(object sender, string RegID)
        {
            //记录调处方前的医生ID
            m_mthClearDoctorInof();
            //赋值给处方查询控件
            this.txtLoadRecipeNo1.PatientID = this.m_PatInfo.PatientID;
            //赋值病人类型给计费类，因为计费是按病人身份来计算的。
            ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.PatientType = this.m_PatInfo.PatientType;
            //病人费用限额
            ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.ChargeLimit = this.m_PatInfo.Limit;

            //只要病人变更就关闭之前的欠费提醒窗口
            if (((clsCtl_DoctorWorkstation)this.objController).blnIfDMShow == true && !((clsCtl_DoctorWorkstation)this.objController).frmDM.IsDisposed)
            {
                ((clsCtl_DoctorWorkstation)this.objController).frmDM.Close();
            }
            //判断病人是否为VIP
            if (this.m_PatInfo.m_strIsVip != null && this.m_PatInfo.m_strIsVip == "1")
            {
                m_mthEnableIsVip();
                //显示欠费信息
                ((clsCtl_DoctorWorkstation)this.objController).m_mthShowDebtMessage(this.m_PatInfo.PatientCardID);
            }
            else
            {
                m_mthDisableIsVip();
            }
            //更新病人就诊状态和保存数据在就诊列表。
            if (((clsCtl_DoctorWorkstation)this.objController).m_blnInsertData())
            {
                //显示急诊 
                if (objDclDoctor.m_blnCheckRegEmer(this.m_PatInfo.RegTypeID))
                {
                    intURGENCY_INT = 1;
                }
                else
                {
                    intURGENCY_INT = 0;
                }
                ((clsCtl_DoctorWorkstation)this.objController).m_mthShowRecipeEmer(intURGENCY_INT);
            }
            else
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthShowRecipeEmer(0);
            }

            if (this.m_PatInfo.Hypersusceptibility.Trim() != "")
            {
                if (frmAllergich != null)
                {
                    frmAllergich.txtInfo.Text = this.m_PatInfo.Hypersusceptibility.Trim();
                    frmAllergich.Show();
                }
            }
            else
            {
                if (frmAllergich != null)
                {
                    frmAllergich.Hide();
                    frmAllergich.txtInfo.Text = "";
                }
            }
            this.Focus();

            if (this.m_PatInfo.PayTypeID.Trim() == ((clsCtl_DoctorWorkstation)this.objController).YBSpecialPayTypeID)
            {
                this.cmbRecipeType.SelectedIndex = ((clsCtl_DoctorWorkstation)this.objController).YBSpecialRecTypeID;
            }

            //更换病人时清空上一病人历史处方号
            this.txtLoadRecipeNo1.m_mthClearText();

            //清空中药用法
            this.cmbCooking.Text = "";
            this.cmbCooking.SelectedIndex = -1;

            ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckYBPayType();

            clsDcl_DoctorWorkstation dcl = new clsDcl_DoctorWorkstation();
            this.txtWeight.Text = dcl.GetPatientWeight(this.m_PatInfo.PatientID);
            dcl = null;
        }

        private void btClear_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("是否要清空所有数据?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            m_mthFillPrimaryDoctor();
            this.txtLoadRecipeNo1.m_mthClearText();
            ((clsCtl_DoctorWorkstation)this.objController).m_mthClearAllData();
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            //			if(radioButton1.Checked)
            //			{
            //			radioButton1.Tag="2";
            //			this.btReUse.Enabled=true;
            //			
            //			}
            //			else
            //			{
            //			radioButton1.Tag="0";
            //			this.btReUse.Enabled=false;
            //			}
            //			((clsCtl_DoctorWorkstation)this.objController).m_mthGetRepiceNo();
        }

        private void cmbRipecNo_Enter(object sender, System.EventArgs e)
        {
            //			cmbRipecNo.DroppedDown=true;
            //			if(cmbRipecNo.SelectedIndex<1&&cmbRipecNo.Items.Count>0)
            //			{
            //				cmbRipecNo.SelectedIndex=0;
            //			}

        }

        private void cmbRipecNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //			((clsCtl_DoctorWorkstation)this.objController).m_mthCreatCalObj();
                //			((clsCtl_DoctorWorkstation)this.objController).m_mthFindRecipeByID(cmbRipecNo.Text);
            }
        }

        private void m_btVindicateTem_Click(object sender, System.EventArgs e)
        {
            //			m_txtDiagPort.Focus();
            //			m_objTemplate.m_mthManageTemplate();
        }

        private void frmDoctorWorkstation_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        this.m_btVindicateTem_Click(null, null);
                        break;
                    case Keys.M:
                        this.btShowTemplate2_Click(null, null);
                        break;
                }

            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }

        private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthChangeCMTimes();
        }

        private void m_dtgWaitReg_DoubleClick(object sender, System.EventArgs e)
        {
            //MessageBox.Show("a");
        }

        private void m_dtgWaitReg_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_AddNewTake();
        }
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if (this.tabControl1.SelectedIndex > 2)
            {
                this.panel4.Height = 32;
            }
            else
            {
                this.panel4.Height = 0;
            }
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    //					this.m_btnBackWait.Visible = true;
                    //					this.m_btnEndTake.Visible = true;
                    //					this.m_btnEndTake.Enabled = false;
                    //					this.m_btnRefReg.Visible = true;
                    this.m_btnBackWait.Text = "接诊(&J)";
                    break;
                case 1:
                    //					this.m_btnBackWait.Visible = true;
                    //					this.m_btnEndTake.Visible = true;
                    //					this.m_btnRefReg.Visible = false;
                    //					this.m_btnEndTake.Enabled = true;
                    this.m_btnBackWait.Text = "候诊(&W)";
                    this.m_btnEndTake.Text = "结诊(&O)";
                    break;
                default:
                    //					this.m_btnBackWait.Visible = false;
                    //					this.m_btnEndTake.Visible = false;
                    //					this.m_btnRefReg.Visible = false;
                    break;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetFocus();
        }

        private void m_btnEndTake_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_EndTakeReg(1);
        }

        private void m_btnBackWait_Click(object sender, System.EventArgs e)
        {
            //			if(this.tabControl1.SelectedIndex == 1)
            //			{
            //				((clsCtl_DoctorWorkstation)this.objController).m_mthReturnWait();
            //			}
            if (this.m_btnBackWait.Text == "候诊(&W)")
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthReturnWait();
            }
            if (this.m_btnBackWait.Text == "接诊(&J)")
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_AddNewTake();

            }

        }

        private void m_dtgWaitReg_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {

        }

        private void m_btnRefReg_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_GetWaitReg();
        }

        private void cmbFindAccordRecipe_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (cmbFindAccordRecipe.SelectedIndex)
            {
                case 0://项目名称
                    cmbFindAccordRecipe.Tag = "RECIPENAME_CHR";
                    break;
                case 1://助记码
                    cmbFindAccordRecipe.Tag = "USERCODE_CHR";
                    break;
                case 2://拼音
                    cmbFindAccordRecipe.Tag = "PYCODE_CHR";
                    break;
                case 3://五笔
                    cmbFindAccordRecipe.Tag = "WBCODE_CHR";
                    break;
            }
            this.txtFindAccordRecipe.Select();
        }

        private void txtFindAccordRecipe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthFindAccordRecipe(this.txtFindAccordRecipe.Text);
            }
        }

        private void btPrint_Click(object sender, System.EventArgs e)
        {
            this.btPrint.Tag = "1";
            if (((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.HospitalFlag == 0)
            {
                this.printDocument1.DefaultPageSettings.Landscape = true;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthShowPrint();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthPrint(e);
        }
        #region 删除DataGrid的数据
        private void ctlDataGrid1_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int row = this.ctlDataGrid1.CurrentCell.RowNumber;
            int col = this.ctlDataGrid1.CurrentCell.ColumnNumber;

            if (e.KeyCode == Keys.F6)
            {
                string strSubItemID = this.ctlDataGrid1[row, ((clsCtl_DoctorWorkstation)this.objController).c_SubItemID].ToString();
                if (strSubItemID.StartsWith("[PK]"))
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByUsageID(ctlDataGrid1[row, ((clsCtl_DoctorWorkstation)this.objController).c_UsageID].ToString().Trim(), true, strSubItemID.Replace("[PK]", ""), row);
                }

                string strReItemID = this.ctlDataGrid1[row, ((clsCtl_DoctorWorkstation)this.objController).c_resubitem].ToString();
                if (strReItemID.StartsWith("[PK]"))
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                if (this.ctlDataGrid1[row, ((clsCtl_DoctorWorkstation)this.objController).c_GroupNo].ToString().Trim() != "")
                {
                    DelRecGroupFlag = true;
                }

                ((clsCtl_DoctorWorkstation)this.objController).m_mthDeleteGroup(row);
                ((clsCtl_DoctorWorkstation)this.objController).m_mthSetRecipeType(row + 1);
                ctlDataGrid1.CurrentCell = new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber, 0);
                //因为DataGrid有个Bug所以发送下面的模拟键
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                DelRecGroupFlag = false;
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                if (col == ((clsCtl_DoctorWorkstation)this.objController).c_UsageName)
                {
                    this.ctlDataGrid1.CurrentCell = new DataGridCell(row, ((clsCtl_DoctorWorkstation)this.objController).c_Count);
                }
                else if (col == ((clsCtl_DoctorWorkstation)this.objController).c_Total)
                {
                    this.ctlDataGrid1.CurrentCell = new DataGridCell(row, ((clsCtl_DoctorWorkstation)this.objController).c_Day);
                }
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        private void ctlDataGrid2_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGrid2.CurrentCell.RowNumber;

                string strReItemID = this.ctlDataGrid2[intRow, ((clsCtl_DoctorWorkstation)this.objController).cm_resubitem].ToString();
                if (strReItemID.StartsWith("[PK]"))
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                if (this.ctlDataGrid2[intRow, 9].ToString().Trim() != "")
                {
                    ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.ctlDataGrid2[intRow, 9].ToString()));
                }
                this.ctlDataGrid2.m_mthDeleteRow(intRow);
                ctlDataGrid2.CurrentCell = new DataGridCell(this.ctlDataGrid2.CurrentCell.RowNumber, 0);
                //因为DataGrid有个Bug所以发送下面的模拟键
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;

            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        private void ctlDataGrid3_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGrid3.CurrentCell.RowNumber;
                string strReItemID = this.ctlDataGrid3[intRow, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString();

                if (strReItemID.StartsWith("[PK]"))
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                if (this.ctlDataGrid3[intRow, 10].ToString().Trim() != "")//如果行号不为空
                {
                    if (this.ctlDataGrid3[intRow, 18].ToString().Trim() != "")
                    {
                        string strTemp = this.ctlDataGrid3[intRow, 18].ToString().Trim();
                        if (MessageBox.Show("注意!此项目已开申请单,删除些项目要把该申请单\n的所有项目删除,是否继续?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            for (int i = this.ctlDataGrid3.RowCount - 1; i > -1; i--)
                            {
                                if (this.ctlDataGrid3[i, 18].ToString().Trim() == strTemp)
                                {
                                    ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.ctlDataGrid3[intRow, 10].ToString()));
                                    this.ctlDataGrid3.m_mthDeleteRow(i);
                                }
                            }
                        }
                    }
                    else
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.ctlDataGrid3[intRow, 10].ToString()));
                        this.ctlDataGrid3.m_mthDeleteRow(intRow);
                    }
                }
                else
                {
                    this.ctlDataGrid3.m_mthDeleteRow(intRow);
                }

                ctlDataGrid3.CurrentCell = new DataGridCell(this.ctlDataGrid3.CurrentCell.RowNumber, 0);
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;

            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        private void ctlDataGrid4_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGrid4.CurrentCell.RowNumber;
                string strReItemID = this.ctlDataGrid4[intRow, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString();

                if (strReItemID.StartsWith("[PK]"))
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                if (this.ctlDataGrid4[intRow, 10].ToString().Trim() != "")
                {
                    ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.ctlDataGrid4[intRow, 10].ToString()));
                }
                ((clsCtl_DoctorWorkstation)this.objController).m_mthDelApplyBill(intRow);
                this.ctlDataGrid4.m_mthDeleteRow(intRow);
                ctlDataGrid4.CurrentCell = new DataGridCell(this.ctlDataGrid4.CurrentCell.RowNumber, 0);
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;

            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        private void ctlDataGrid5_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGrid5.CurrentCell.RowNumber;
                string strReItemID = this.ctlDataGrid5[intRow, ((clsCtl_DoctorWorkstation)this.objController).o_resubitem].ToString();

                if (strReItemID.StartsWith("[PK]"))
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                if (this.ctlDataGrid5[intRow, 9].ToString().Trim() != "")
                {
                    ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.ctlDataGrid5[intRow, 9].ToString()));
                }
                this.ctlDataGrid5.m_mthDeleteRow(intRow);
                ctlDataGrid5.CurrentCell = new DataGridCell(this.ctlDataGrid5.CurrentCell.RowNumber, 0);
                //因为DataGrid有个Bug所以发送下面的模拟键
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        private void ctlDataGrid6_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGrid6.CurrentCell.RowNumber;
                string strReItemID = this.ctlDataGrid6[intRow, ((clsCtl_DoctorWorkstation)this.objController).o_resubitem].ToString();

                if (strReItemID.StartsWith("[PK]"))
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                if (this.ctlDataGrid6[intRow, 9].ToString().Trim() != "")
                {
                    ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.ctlDataGrid6[intRow, 9].ToString()));
                }
                this.ctlDataGrid6.m_mthDeleteRow(intRow);
                ctlDataGrid6.CurrentCell = new DataGridCell(this.ctlDataGrid6.CurrentCell.RowNumber, 0);
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;


            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }
        #endregion

        private void m_dtgWaitReg_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {


        }

        private void m_dtgTake_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void btDel_Click(object sender, System.EventArgs e)
        {
            if (this.btSave.Tag == null)
            {
                return;
            }

            if (((clsCtl_DoctorWorkstation)this.objController).m_blnCheckRecipe(this.btSave.Tag.ToString()) == false)
                return;

            if (this.btDel.Text.IndexOf("删") > -1)
            {
                ctmDel.Show(btDel, new Point(btDel.Width, btDel.Height));
            }
            else
            {
                if (MessageBox.Show("是否要" + this.btDel.Text.Substring(0, 2) + "当前处方?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthDelRecipe("0");
                }
            }
        }

        private void cmbApply_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthShowApplyBill();
            }
        }
        #region 打开申请单
        /// <summary>
        /// 填充申请单信息
        /// </summary>
        /// <param name="objApplyReportVO"></param>
        private void m_mthFillApplyData(out iCareData.clsApplyReport_T_VO objApplyReportVO)
        {
            objApplyReportVO = new clsApplyReport_T_VO();
            objApplyReportVO.m_DtmAppryDate = DateTime.Now;
            objApplyReportVO.m_StrAddress = this.m_PatInfo.PatientHomeAddress;
            objApplyReportVO.m_StrClinicDiagnose = this.objCaseHistory.Diag;
            objApplyReportVO.m_StrDeptID = this.m_PatInfo.DeptID;
            objApplyReportVO.m_StrDeptName = this.m_PatInfo.DeptName;
            if (this.m_PatInfo.DoctorName != null)
                objApplyReportVO.m_StrDoctor = this.m_PatInfo.DoctorName;

            objApplyReportVO.m_StrPatientAge = this.m_PatInfo.PatientAge;
            objApplyReportVO.m_StrPatientCardID = this.m_PatInfo.PatientCardID;
            objApplyReportVO.m_StrPatientID = this.m_PatInfo.PatientID;
            objApplyReportVO.m_StrPatientName = this.m_PatInfo.PatientName;
            objApplyReportVO.m_StrPatientSex = this.m_PatInfo.PatientSex;
            objApplyReportVO.m_StrRelationCall = this.m_PatInfo.PatientTelephoneNo;

            objApplyReportVO.m_ObjApply_LungFunction_T_VO = new clsApply_LungFunction_T_VO();
            if (this.objCaseHistory.DiagCurr != "")
            {
                objApplyReportVO.m_ObjApply_LungFunction_T_VO.m_StrSickHistory = this.objCaseHistory.DiagCurr;
            }
            if (this.objCaseHistory.DiagHis != "")
            {
                objApplyReportVO.m_ObjApply_LungFunction_T_VO.m_StrSickHistory += "\r\n" + this.objCaseHistory.DiagHis;
            }
            if (this.objCaseHistory.PersonHis != "")
            {
                objApplyReportVO.m_ObjApply_LungFunction_T_VO.m_StrSickHistory += "\r\n" + this.objCaseHistory.PersonHis;
            }

            objApplyReportVO.m_ObjApply_B_Ultrasonic_T_VO = new clsApply_B_Ultrasonic_T_VO();
            objApplyReportVO.m_ObjApply_B_Ultrasonic_T_VO.m_StrMedicaHistory = this.objCaseHistory.DiagCurr + "\r\n" + this.objCaseHistory.DiagHis + "\r\n" + this.objCaseHistory.PersonHis;
            objApplyReportVO.m_ObjApply_B_Ultrasonic_T_VO.m_StrOtherCheck = this.objCaseHistory.AidCheck;

            objApplyReportVO.m_ObjApply_BCH_T_VO = new clsApply_BCH_T_VO();
            objApplyReportVO.m_StrCaseHistory = this.objCaseHistory.DiagCurr + "\r\n" + this.objCaseHistory.DiagHis + "\r\n" + this.objCaseHistory.PersonHis + "\r\n" + this.objCaseHistory.Anaphylaxis + "\r\n" + this.objCaseHistory.ExamineResult + this.objCaseHistory.AidCheck;

            objApplyReportVO.m_ObjApply_Cardiogram_T_VO = new clsApply_Cardiogram_T_VO();
            objApplyReportVO.m_ObjApply_Cardiogram_T_VO.m_StrNowSick = this.objCaseHistory.DiagCurr;
            objApplyReportVO.m_ObjApply_Cardiogram_T_VO.m_StrSickHistory = this.objCaseHistory.DiagHis;

            objApplyReportVO.m_ObjApply_DynCardiogram_T_VO = new clsApply_DynCardiogram_T_VO();
            objApplyReportVO.m_ObjApply_DynCardiogram_T_VO.m_StrNowSick = this.objCaseHistory.DiagCurr;
            objApplyReportVO.m_ObjApply_DynCardiogram_T_VO.m_StrSickHistory = this.objCaseHistory.DiagHis;

            objApplyReportVO.m_ObjApply_EEGBrain_T_VO = new clsApply_EEGBrain_T_VO();
            objApplyReportVO.m_ObjApply_EEGBrain_T_VO.m_StrNowSick = this.objCaseHistory.DiagCurr;
            objApplyReportVO.m_ObjApply_EEGBrain_T_VO.m_StrSickHistory = this.objCaseHistory.DiagHis;

            objApplyReportVO.m_ObjApply_FlatCardiogram_T_VO = new clsApply_FlatCardiogram_T_VO();
            objApplyReportVO.m_ObjApply_FlatCardiogram_T_VO.m_StrNowSick = this.objCaseHistory.DiagCurr;
            objApplyReportVO.m_ObjApply_FlatCardiogram_T_VO.m_StrSickHistory = this.objCaseHistory.DiagHis;

            objApplyReportVO.m_ObjApply_TCDBrain_T_VO = new clsApply_TCDBrain_T_VO();
            objApplyReportVO.m_ObjApply_TCDBrain_T_VO.m_StrNowSick = this.objCaseHistory.DiagCurr;
            objApplyReportVO.m_ObjApply_TCDBrain_T_VO.m_StrSickHistory = this.objCaseHistory.DiagHis;

            objApplyReportVO.m_ObjApply_CTCheck_T_VO = new clsApply_CTCheck_T_VO();
            objApplyReportVO.m_ObjApply_CTCheck_T_VO.m_StrBodyCheck = this.objCaseHistory.AidCheck + "\r\n" + this.objCaseHistory.ExamineResult;
            objApplyReportVO.m_ObjApply_CTCheck_T_VO.m_StrSickHistory = this.objCaseHistory.DiagCurr + "\r\n" + this.objCaseHistory.DiagHis + "\r\n" + this.objCaseHistory.PersonHis;

            objApplyReportVO.m_ObjApply_DR_T_VO = new clsApply_DR_T_VO();
            objApplyReportVO.m_ObjApply_DR_T_VO.m_Str_ADR_CaseOrClinic = this.objCaseHistory.DiagCurr + "\r\n" + this.objCaseHistory.DiagHis + "\r\n" + this.objCaseHistory.PersonHis + "\r\n" + this.objCaseHistory.Anaphylaxis + "\r\n" + this.objCaseHistory.ExamineResult + "\r\n" + this.objCaseHistory.AidCheck;

            objApplyReportVO.m_ObjApply_Gastroscopy_T_VO = new clsApply_Gastroscopy_T_VO();
            objApplyReportVO.m_ObjApply_Gastroscopy_T_VO.m_StrBodyCheck = this.objCaseHistory.ExamineResult;
            objApplyReportVO.m_ObjApply_Gastroscopy_T_VO.m_StrSickHistory = this.objCaseHistory.DiagCurr + "\r\n" + this.objCaseHistory.DiagHis + "\r\n" + this.objCaseHistory.PersonHis;



            objApplyReportVO.m_ObjApply_IntestineMirror_T_VO = new clsApply_IntestineMirror_T_VO();
            objApplyReportVO.m_ObjApply_IntestineMirror_T_VO.m_StrBodyCheck = this.objCaseHistory.ExamineResult;
            objApplyReportVO.m_ObjApply_IntestineMirror_T_VO.m_StrSickHistory = this.objCaseHistory.DiagCurr + "\r\n" + this.objCaseHistory.DiagHis + "\r\n" + this.objCaseHistory.PersonHis;

            objApplyReportVO.m_StrDeliverDoctorName = this.LoginInfo.m_strEmpName.Trim();

        }
        private void m_mthShowApplyBill()
        {
            if (this.m_PatInfo.PatientID.Trim() == "")
            {
                MessageBox.Show("请先输入病人资料!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_PatInfo.txtCardID.Focus();
                return;
            }

        }
        #endregion
        private void m_PatInfo_PatientTypeChanged()
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthPatientTypeChanged();

            if (this.m_PatInfo.PayTypeID.Trim() == ((clsCtl_DoctorWorkstation)this.objController).YBSpecialPayTypeID)
            {
                this.cmbRecipeType.SelectedIndex = ((clsCtl_DoctorWorkstation)this.objController).YBSpecialRecTypeID;
            }

            ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckYBPayType();
        }
        private void m_mthFillPrimaryDoctor()
        {
            if (strDoctorName == "-1")
            {
                return;
            }
            this.m_PatInfo.txtRegisterDoctor.Text = strDoctorName;
            this.m_PatInfo.DoctorID = strDoctorID;
            this.m_PatInfo.DoctorNo = strDoctorNo;
            this.m_PatInfo.txtRegisterDept.Text = strDepName;
            this.m_PatInfo.DeptID = strDepID;
            this.m_PatInfo.txtType.Text = strPatientTypeName;
            this.m_PatInfo.PayTypeID = strPatientTypeID;
        }
        /// <summary>
        /// 复用按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReUse_Click(object sender, System.EventArgs e)
        {
            this.btReUse.Enabled = false;
            if (this.txtLoadRecipeNo1.RecipeInfo == null)
            {
                this.btReUse.Enabled = true;
                return;
            }
            m_mthFillPrimaryDoctor();
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCreatCalObj();

            clsRecipeInfo_VO obj = this.txtLoadRecipeNo1.RecipeInfo;
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFindChageItemByID(obj.m_strOUTPATRECIPEID_CHR, false);
            if (this.strHisPatientTypeID != this.strPatientTypeID)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthPatientTypeChanged();
            }
            else
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckItemDiscount();
            }

            this.btSave.Tag = null;
            this.btPutIn.Tag = null;
            this.btReUse.Enabled = true;
            if (this.lbeSumMoney.Text.Trim() == "0")
            {
                MessageBox.Show("对不起,找不到可复用项目,\n该处方可能是门诊收费直接开的处方。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetFocus();
        }

        //下面变量记录当前登陆医生的信息和病人的身份类型，目的是为了在复用处方时能还原。
        private string strDoctorName = "-1";
        private string strDoctorID = "-1";
        private string strDoctorNo = "-1";
        private string strDepName = "-1";
        private string strDepID = "-1";
        private string strPatientTypeName = "-1";
        private string strPatientTypeID = "-1";
        private string strHisPatientTypeID = "-1"; //记录复用处方所对应的费别

        private void m_mthClearDoctorInof()
        {
            strDoctorName = "-1";
            strDoctorID = "-1";
            strDoctorNo = "-1";
            strDepName = "-1";
            strDepID = "-1";
            strPatientTypeName = "-1";
            strPatientTypeID = "-1";
        }
        /// <summary>
        /// 选择处方时产生的事件处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoadRecipeNo1_RecipeSelected(object sender, System.EventArgs e)
        {
            #region 旧码
            /***
            //当第一次调处方时，记录当前登陆医生的信息和病人的身份类型，目的是为了在复用处方时能还原
			if( strDoctorName =="-1")
			{
				strDoctorName=this.m_PatInfo.txtRegisterDoctor.Text;
				strDoctorID=this.m_PatInfo.DoctorID;
				strDoctorNo=this.m_PatInfo.DoctorNo;
				strDepName=this.m_PatInfo.txtRegisterDept.Text;
				strDepID=this.m_PatInfo.DeptID;
				strPatientTypeName=this.m_PatInfo.txtType.Text;
				strPatientTypeID=this.m_PatInfo.PayTypeID;
			}
			clsRecipeInfo_VO obj=this.txtLoadRecipeNo1.RecipeInfo;           
			this.m_PatInfo.txtRegisterDoctor.Text=obj.m_strDoctorName;
			this.m_PatInfo.DoctorID=obj.m_strDoctorID;
			this.m_PatInfo.DoctorNo=obj.m_strDoctorNo;
			this.m_PatInfo.txtRegisterDept.Text=obj.m_strDepName;
			this.m_PatInfo.DeptID=obj.m_strDepID;
			this.m_PatInfo.txtType.Text=obj.m_strPatientTypeName;
			this.m_PatInfo.PayTypeID = obj.m_strPatientTypeID;
            this.strHisPatientTypeID = obj.m_strPatientTypeID;
            if (Convert.ToInt32(obj.m_strRECIPEFLAG_INT) <= this.m_cmbRecipeType.Items.Count)
            {
                this.m_cmbRecipeType.SelectedIndex = Convert.ToInt32(obj.m_strRECIPEFLAG_INT) - 1;
            }
            if (obj.m_intRecipetypeid <= this.cmbRecipeType.Items.Count - 1)
            {
                this.cmbRecipeType.SelectedIndex = obj.m_intRecipetypeid;
            }
			((clsCtl_DoctorWorkstation)this.objController).m_mthFindRecipeByID(obj);
			this.btReUse.Focus();
            ***/
            #endregion

            clsRecipeInfo_VO RecipeInfo_VO = this.txtLoadRecipeNo1.RecipeInfo;

            frmDoctReUseInfo fdru = new frmDoctReUseInfo(RecipeInfo_VO);
            fdru.LackMedicine = ((clsCtl_DoctorWorkstation)this.objController).isShowLackMedicine;
            fdru.ItemInputMode = ((clsCtl_DoctorWorkstation)this.objController).ItemInputMode;
            DialogResult dg = fdru.ShowDialog();
            if (dg == DialogResult.OK || dg == DialogResult.Retry || dg == DialogResult.Yes)
            {
                if (dg == DialogResult.Yes)
                {
                    this.txtLoadRecipeNo1.m_mthClearText();
                }

                //复用历史处方类型                
                if (RecipeInfo_VO.m_intRecipetypeid <= this.cmbRecipeType.Items.Count - 1)
                {
                    this.cmbRecipeType.SelectedIndex = RecipeInfo_VO.m_intRecipetypeid;
                }

                //初始化服数为1;	
                this.numericUpDown1.Value = 1;

                if (dg == DialogResult.OK || dg == DialogResult.Yes)
                {
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthCreatCalObj();
                    this.btSave.Tag = null;
                    this.btPutIn.Tag = null;
                }
                else if (dg == DialogResult.Retry)
                {
                    //赋值给一个隐藏了的lable控件，为了用它的TextChange事件来判断控钮的可用状态
                    this.lbeFlag.Text = RecipeInfo_VO.m_intPSTATUS_INT.ToString();

                    ((clsCtl_DoctorWorkstation)this.objController).objCalPatientCharge = new clsCalcPatientCharge(this.m_PatInfo.PatientID, this.m_PatInfo.PayTypeID, this.m_PatInfo.Limit, ((clsCtl_DoctorWorkstation)this.objController).m_objComInfo.m_strGetHospitalTitle(), this.m_PatInfo.PatientType, this.m_PatInfo.Discount);
                    ((clsCtl_DoctorWorkstation)this.objController).OPSApplyarr = new ArrayList();
                    this.btSave.Tag = RecipeInfo_VO.m_strOUTPATRECIPEID_CHR;
                    this.btPutIn.Tag = null;
                }

                ((clsCtl_DoctorWorkstation)this.objController).m_mthReUseRecipeItem(fdru.hasItem, fdru.hasEntry);
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckItemDiscount();
                ((clsCtl_DoctorWorkstation)this.objController).m_mthFormatDataGrid();
                ((clsCtl_DoctorWorkstation)this.objController).m_mthSetFocus();
            }
            else if (dg == DialogResult.Abort)
            {
                this.txtLoadRecipeNo1.m_mthClearText();
            }
        }

        private void frmDoctorWorkstation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!noopen)
            {
                if (MessageBox.Show("退出窗口前请保存所有未保存的数据。\r\n\r\n是否继续退出？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            //为了关闭窗口时DataGrid存的BUG引发程序出错，下面代码不能少。
            this.ctlDataGrid1.Enabled = false;
            this.ctlDataGrid2.Enabled = false;
            this.ctlDataGrid3.Enabled = false;
            this.ctlDataGrid4.Enabled = false;
            this.ctlDataGrid5.Enabled = false;
            this.ctlDataGrid6.Enabled = false;
            if (frmAllergich != null)
            {
                frmAllergich.Close();
            }
            frmAllergicl.Close();
            frmRecconf.Close();
            if (frmDiag != null)
            {
                frmDiag.Close();
                DiagnoseClient.frmDiagClientMain.PatientCalled -= new DiagnoseClient.PatientCalledEventHandler(frmDiagClientMain_PatientCalled);
            }
        }
        #region 加载申请单
        private void m_mthLoadApplyBill()
        {

            if (this.groupBox7.Visible == false)
            {
                return;
            }

        }
        #endregion

        private void btShowTemplate2_Click(object sender, System.EventArgs e)
        {

        }

        private void btCreatBill_Click(object sender, System.EventArgs e)
        {
            this.m_mthShowApplyBill();
        }

        private void m_PatInfo_PatientEnd(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_EndTakeReg(2);
        }

        private void btCaseyHistory_Click(object sender, System.EventArgs e)
        {
            this.btPrint.Tag = "2";
            this.printDocument1.DefaultPageSettings.Landscape = false;
            ((clsCtl_DoctorWorkstation)this.objController).m_mthShowPrint();
        }

        private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if ((int)e.KeyChar >= 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;

            }
            if (e.KeyChar == '.')
            {
                if (tb.Text.Trim() == "")
                {
                    tb.Text = "0.";
                    System.Windows.Forms.SendKeys.SendWait("{Right}");
                    System.Windows.Forms.SendKeys.SendWait("{Right}");
                    e.Handled = true;
                }
                if (tb.Text.IndexOf(".") > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private void txtCount_KeyPress2(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if ((int)e.KeyChar > 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;

            }

        }
        private void TextBox_KeyPress3(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if ((int)e.KeyChar >= 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {
                //-- 特殊处理 by kenny
                decimal decRes = 0;
                string strInput = string.Empty;
                if (tb.SelectedText.Length > 0)
                {
                    strInput = tb.Text.Replace(tb.SelectedText, "") + e.KeyChar.ToString();
                }
                else
                {
                    strInput = tb.Text + e.KeyChar.ToString();
                }
                if (decimal.TryParse(strInput, out decRes))
                {
                    if (decRes != 0 && decRes % 0.5M != 0)
                    {
                        com.digitalwave.iCare.gui.HIS.clsMain objMain = new com.digitalwave.iCare.gui.HIS.clsMain();
                        objMain.m_mthShowWarning(tb, "数量必须为0.5的倍数");
                        e.Handled = true;
                    }
                }
                //--
            }
            else
            {
                e.Handled = true;

            }
            if (e.KeyChar == '.')
            {
                if (tb.Text.Trim() == "")
                {
                    tb.Text = "0.";
                    System.Windows.Forms.SendKeys.SendWait("{Right}");
                    System.Windows.Forms.SendKeys.SendWait("{Right}");
                    e.Handled = true;
                }
                if (tb.Text.IndexOf(".") > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private void TextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (HandleInput)
            {
                e.Handled = true;
                HandleInput = false;
            }

        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.btPrint.Tag != null)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthBeginPrint();
            }

        }

        private void btGroup_Click(object sender, System.EventArgs e)
        {

        }

        private void btCancelGroup_Click(object sender, System.EventArgs e)
        {

        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (this.m_cmbFind.SelectedIndex == 1)
            {
                InputLanguage.CurrentInputLanguage = myInputLanguage;
            }

        }
        private int intCurRecipeRow = 0;
        private string strCurString = "";
        private void RecipeTextBox_Enter(object sender, EventArgs e)
        {
            intCurRecipeRow = this.ctlDataGrid1.CurrentCell.RowNumber;
            strCurString = this.ctlDataGrid1[intCurRecipeRow, 0].ToString().Trim();

        }
        private void RecipeTextBox_Leave(object sender, EventArgs e)
        {
            if (DelRecGroupFlag)
            {
                return;
            }

            string strtemp = this.ctlDataGrid1[intCurRecipeRow, 0].ToString().Trim();
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetRowNo(strtemp, intCurRecipeRow, strCurString, 1);
        }
        private void listView4_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthListView4KeyDown(e);

        }

        private void listView4_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthListViewDoubleClick4();
        }

        private void listView4_Leave(object sender, System.EventArgs e)
        {
            this.listView4.Hide();
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            myInputLanguage = InputLanguage.CurrentInputLanguage;
        }

        private void btInject_Click(object sender, System.EventArgs e)
        {
            this.btPrint.Tag = "3";
            if (((clsCtl_DoctorWorkstation)this.objController).m_objComInfo.m_strGetHospitalTitle().IndexOf("佛") > -1)
            {

                this.printDocument1.DefaultPageSettings.Landscape = true;
            }
            else
            {
                this.printDocument1.DefaultPageSettings.Landscape = false;
            }

            ((clsCtl_DoctorWorkstation)this.objController).m_mthShowPrint();
        }

        private void chkGroup_CheckedChanged(object sender, System.EventArgs e)
        {
            this.ctlDataGrid1.CurrentCell = new DataGridCell(this.ctlDataGrid1.RowCount, 0);
        }

        private void btNew_Click(object sender, System.EventArgs e)
        {
            //显示急诊 
            ((clsCtl_DoctorWorkstation)this.objController).m_mthShowRecipeEmer(intURGENCY_INT);

            //默认主方
            this.m_cmbRecipeType.SelectedIndex = 0;

            ((clsCtl_DoctorWorkstation)this.objController).m_mthNewRecipe();
        }

        private void btReGroup_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthReGroup();
        }

        private void lbeSumMoney_TextChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthIsOverFlow();
        }

        private void btCaseHistory_Click(object sender, System.EventArgs e)
        {
            if (this.m_PatInfo.PatientID.Trim() != "")
            {
                frmShowCaseHistory objfrm = new frmShowCaseHistory();
                objfrm.PatientID = this.m_PatInfo.PatientID.Trim();
                objfrm.PatientCardID = this.m_PatInfo.PatientCardID.Trim();
                objfrm.PatientName = this.m_PatInfo.PatientName.Trim();
                objfrm.PatientSex = this.m_PatInfo.PatientSex.Trim();
                objfrm.PatientAge = this.m_PatInfo.PatientAge.Trim();
                objfrm.m_IntStat = 0;
                DialogResult ret = objfrm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    if (objfrm.m_IntStat == 1)
                    {
                        this.objCaseHistory.m_mthClearData(1);
                        this.objCaseHistory.CaseHistoryStatus = 1;
                        this.objCaseHistory.ParentCaseHistoryID = objfrm.CaseHistoryInfo.m_strRecipeID;
                        this.objCaseHistory.Diag = objfrm.CaseHistoryInfo.strDiag;
                        this.objCaseHistory.DiagCurr = objfrm.CaseHistoryInfo.strDiagCurr;
                        this.objCaseHistory.DiagHis = objfrm.CaseHistoryInfo.strDiagHis;
                        this.objCaseHistory.DiagMain = DateTime.Now.ToString("yyyy-MM-dd");
                        this.objCaseHistory.ExamineResult = objfrm.CaseHistoryInfo.strExamineResult;
                        this.objCaseHistory.ReMark = objfrm.CaseHistoryInfo.strReMark;
                        this.objCaseHistory.Treatment = objfrm.CaseHistoryInfo.strTreatMent;
                        this.objCaseHistory.ChangeDepartment = objfrm.CaseHistoryInfo.strChangeDeparement;
                        this.objCaseHistory.PersonHis = objfrm.CaseHistoryInfo.m_strPRIHIS_VCHR;
                        this.objCaseHistory.AidCheck = objfrm.CaseHistoryInfo.strAidCheck;
                        this.objCaseHistory.Anaphylaxis = objfrm.CaseHistoryInfo.strAnaPhyLaXis;
                        this.tabControl1.SelectedIndex = 2;
                    }
                    else if (objfrm.m_IntStat == 2 || objfrm.m_IntStat == 3)
                    {
                        this.objCaseHistory.CaseHistoryStatus = 0;
                        this.objCaseHistory.ParentCaseHistoryID = "";
                        this.objCaseHistory.Diag = objfrm.CaseHistoryInfo.strDiag;
                        this.objCaseHistory.DiagCurr = objfrm.CaseHistoryInfo.strDiagCurr;
                        this.objCaseHistory.DiagHis = objfrm.CaseHistoryInfo.strDiagHis;
                        this.objCaseHistory.DiagMain = objfrm.CaseHistoryInfo.strDiagMain;
                        this.objCaseHistory.ExamineResult = objfrm.CaseHistoryInfo.strExamineResult;
                        this.objCaseHistory.ReMark = objfrm.CaseHistoryInfo.strReMark;
                        this.objCaseHistory.Treatment = objfrm.CaseHistoryInfo.strTreatMent;
                        this.objCaseHistory.PersonHis = objfrm.CaseHistoryInfo.m_strPRIHIS_VCHR;
                        this.objCaseHistory.AidCheck = objfrm.CaseHistoryInfo.strAidCheck;
                        this.objCaseHistory.ChangeDepartment = objfrm.CaseHistoryInfo.strChangeDeparement;
                        this.objCaseHistory.Anaphylaxis = objfrm.CaseHistoryInfo.strAnaPhyLaXis;
                        this.tabControl1.SelectedIndex = 2;

                        string CaseID = objfrm.CaseHistoryInfo.m_strRecipeID;
                        if (CaseID.Trim() != "")
                        {
                            clsICD10_VO[] objArrTemp;
                            clsDcl_DoctorWorkstation objDoct = new clsDcl_DoctorWorkstation();
                            long l = objDoct.m_mthIllnessInfo(CaseID, out objArrTemp);
                            if (l > 0 && objArrTemp != null)
                            {
                                ArrayList objArrList = new ArrayList();
                                objArrList.AddRange(objArrTemp);
                                this.objCaseHistory.ICD10 = objArrList;
                            }
                        }

                        if (objfrm.m_IntStat == 3)
                        {
                            ((clsCtl_DoctorWorkstation)this.objController).m_mthReUseRecipe(objfrm.CaseHistoryInfo.m_strRecipeID);
                        }
                    }
                }
                objfrm.Close();
            }
        }

        private void btPutIn_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthPutIn(false);
            if (this.m_PatInfo.m_strIsVip == "1")
            {
                this.btnPrefer.Enabled = true;
            }
        }

        private void m_mthSetEnabled(bool enable)
        {
            this.btSave.Enabled = enable;
            this.btnRecalc.Enabled = enable;
            this.ctlDataGrid1.Enabled = enable;
            this.ctlDataGrid2.Enabled = enable;
            this.ctlDataGrid3.Enabled = enable;
            this.ctlDataGrid4.Enabled = enable;
            this.ctlDataGrid5.Enabled = enable;
            this.ctlDataGrid6.Enabled = enable;
            this.m_PatInfo.txtRegisterDept.Enabled = enable;
            this.m_PatInfo.txtRegisterDoctor.Enabled = enable;
        }
        //这里用一个隐藏的Lable控件来控制按钮的状态
        private void lbeFlag_TextChanged(object sender, System.EventArgs e)
        {
            //0医生新建,1收费处新建,2已收费,-1作废,-2退票,3恢复,4 提交

            this.picris.Enabled = this.piclis.Enabled;
            switch (this.lbeFlag.Text.Trim())
            {
                case "-2":
                    m_mthSetEnabled(false);
                    this.btDel.Enabled = false;
                    this.btPutIn.Enabled = false;
                    break;
                case "0":
                    m_mthSetEnabled(true);
                    this.btPutIn.Enabled = true;
                    this.btDel.Text = "删除(Z)";
                    this.btDel.Enabled = true;
                    this.m_PatInfo.txtRegisterDoctor.Enabled = !((clsCtl_DoctorWorkstation)this.objController).isCanChangeDoctor;
                    break;
                case "2":
                    m_mthSetEnabled(false);
                    this.btPutIn.Enabled = false;
                    this.btDel.Enabled = false;
                    break;
                case "3":
                    m_mthSetEnabled(false);
                    this.btPutIn.Enabled = false;
                    this.btDel.Enabled = false;
                    break;
                case "4":
                    m_mthSetEnabled(false);
                    this.btDel.Text = "作废(Z)";
                    this.btDel.Enabled = true;
                    this.btPutIn.Enabled = false;
                    this.picris.Enabled = false;
                    break;
                default:
                    this.btDel.Text = "删除(Z)";
                    this.btDel.Enabled = false;
                    m_mthSetEnabled(true);
                    this.btPutIn.Enabled = false;
                    break;
            }
        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.cmbRecipeType.SelectedIndex > -1)
            {
                ((clsRecipeType_VO)this.cmbRecipeType.SelectedItem).REMARK_VCHR = "";
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthEndPrint();
        }

        private void ctlDataGrid4_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (this.ctlDataGrid4[e.m_intRowNumber, 18].ToString().Trim() != "")
            {
                MessageBox.Show("此项目已开申请单!", "提示");
                return;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthApplyCheckByItem(e.m_intRowNumber, 4);
        }

        private void ctlDataGrid3_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (!this.groupBox7.Visible)
            {
                return;
            }
            if (this.ctlDataGrid3[e.m_intRowNumber, 18].ToString().Trim() != "")
            {
                MessageBox.Show("此项目已开申请单!", "提示");
                return;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthShowTestApply(e.m_intRowNumber);
        }

        private void ra_Person_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ra_Person.Checked)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_GetWaitReg();
                this.cmbDeparment.Enabled = false;
            }
            else
            {
                this.cmbDeparment.Enabled = true;
                this.cmbDeparment.Focus();
            }

        }

        private void cmbDeparment_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_GetWaitReg();
            }
        }

        private void btSelect_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_GetWaitReg();
        }
        #region
        private void ctlDataGrid2_Leave(object sender, System.EventArgs e)
        {
            if (this.intRowNo2 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateAmount2(intRowNo2);
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
            }
        }

        private void ctlDataGrid1_Leave(object sender, System.EventArgs e)
        {
            if (intRowNo1 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateAmount(intRowNo1);
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
                intRowNo1 = -1;
            }
        }

        private void ctlDataGrid3_Leave(object sender, System.EventArgs e)
        {
            if (intRowNo3 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthAddItemToCulateClass(this.intRowNo3, 3);
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
                intRowNo3 = -1;
            }
        }

        private void ctlDataGrid4_Leave(object sender, System.EventArgs e)
        {
            if (intRowNo4 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthAddItemToCulateClass(this.intRowNo4, 4);
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
                intRowNo4 = -1;
            }
        }

        private void ctlDataGrid5_Leave(object sender, System.EventArgs e)
        {
            if (intRowNo5 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthAddItemToCulateClass(this.intRowNo5, 5);
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
                intRowNo5 = -1;
            }
        }

        private void ctlDataGrid6_Leave(object sender, System.EventArgs e)
        {
            if (intRowNo6 > -1)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthAddItemToCulateClass(this.intRowNo6, 6);
                ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();
                intRowNo6 = -1;
            }
        }
        #endregion

        private void m_PatInfo_SelectDoctor(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetFocus();
        }

        private void mniDelAll_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("确认是否删除当前病历和处方？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //伪删除处方
                ((clsCtl_DoctorWorkstation)this.objController).m_mthDelRecipe("0");
                //伪删除病历
                ((clsCtl_DoctorWorkstation)this.objController).m_mthDelCashHistory("0");
            }
        }

        private void muiDelRec_Click(object sender, System.EventArgs e)
        {
            //伪删除处方
            if (MessageBox.Show("确认是否删除当前处方？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthDelRecipe("0");
            }
        }

        private void mniDelCash_Click(object sender, System.EventArgs e)
        {
            //伪删除病历
            if (MessageBox.Show("确认是否删除当前病历？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthDelCashHistory("0");
            }
        }

        private void m_dtgTake_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (e.m_intRowNumber >= 0)
            {
                if (m_dtgTake[e.m_intRowNumber, 7].ToString().Substring(0, 10) == System.DateTime.Now.Date.ToString("yyyy-MM-dd"))
                {
                    string CardID = m_dtgTake[e.m_intRowNumber, 2].ToString();
                    this.m_PatInfo.txtCardID.Text = CardID;
                    this.m_PatInfo.m_mthGetPatientInfoByCard(CardID);
                }
            }
        }

        private void muiInfo_Click(object sender, System.EventArgs e)
        {
            if (this.m_dtgTake.RowCount == 0)
            {
                return;
            }

            int currRow = this.m_dtgTake.CurrentCell.RowNumber;
            if (currRow < 0)
            {
                currRow = 0;
            }

            string strCardNO = this.m_dtgTake[currRow, 2].ToString();

            frmShowReports objReport = new frmShowReports(strCardNO);
            objReport.ShowDialog();
            objReport = null;
        }

        private void llblDate_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSelectMode();
            this.Cursor = Cursors.Default;
        }

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSelectPat(1);
            this.Cursor = Cursors.Default;
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthGetAllergiclist();
        }

        private void piclis_Click(object sender, EventArgs e)
        {
            if (btSave.Enabled || btPutIn.Enabled)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthShowTestApply(-1);
            }
        }

        private void picris_Click(object sender, EventArgs e)
        {
            if (btSave.Enabled || btPutIn.Enabled)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthApplyCheck();
            }
        }

        private void picops_Click(object sender, EventArgs e)
        {
            if (btSave.Enabled || btPutIn.Enabled)
            {
                ((clsCtl_DoctorWorkstation)this.objController).m_mthOPSApply(-1, "", "");
            }
        }

        private void ctlDataGrid5_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (this.ctlDataGrid5[e.m_intRowNumber, 7].ToString().Trim() == "")
            {
                return;
            }

            //if (this.ctlDataGrid5[e.m_intRowNumber, 20].ToString().Trim() != "")
            //{
            //    MessageBox.Show("此项目已开申请单!", "提示");
            //    return;
            //}

            //((clsCtl_DoctorWorkstation)this.objController).m_mthOPSApply(e.m_intRowNumber, this.ctlDataGrid5[e.m_intRowNumber, 7].ToString().Trim(), this.ctlDataGrid5[e.m_intRowNumber, 2].ToString().Trim());

            if (this.ctlDataGrid5[e.m_intRowNumber, 17].ToString().Trim() != "")
            {
                MessageBox.Show("此项目已开申请单!", "提示");
                return;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthApplyCheckByItem(e.m_intRowNumber, 5);
        }

        private void timerrec_Tick(object sender, EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthGetrecipeconfirmfalllist();
        }

        private void TB_Enter(object sender, EventArgs e)
        {
            this.cboquick.Hide();
            TextBox temp = sender as TextBox;
            try
            {
                if (temp.Text.Trim() != "")
                {
                    this.cboquick.Text = temp.Text;
                }
                this.cboquick.Bounds = temp.Bounds;
                this.cboquick.Show();
                this.cboquick.Focus();
                this.cboquick.Select();
                this.cboquick.BringToFront();
            }
            catch
            {
            }
        }

        private void cboquick_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ctlDataGrid3[this.ctlDataGrid3.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_quick] = this.cboquick.Text;
            if (this.cboquick.Text.Trim() == "是" && this.ctlDataGrid3[this.ctlDataGrid3.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_ItemID].ToString().Trim() != "")
            {
                this.ctlDataGrid3.m_mthSetRowColor(this.ctlDataGrid3.CurrentCell.RowNumber, Color.FromArgb(255, 255, 255), Color.FromArgb(250, 89, 69));
                this.ctlDataGrid3[this.ctlDataGrid3.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_quickid] = "1";
            }
            else
            {
                this.ctlDataGrid3.m_mthSetRowColor(this.ctlDataGrid3.CurrentCell.RowNumber, nfc, nbc);
                this.ctlDataGrid3[this.ctlDataGrid3.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_quickid] = "0";
            }
        }

        private void cboquick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ctlDataGrid3[this.ctlDataGrid3.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_quick] = this.cboquick.Text;
                if (this.cboquick.Text.Trim() == "是" && this.ctlDataGrid3[this.ctlDataGrid3.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_ItemID].ToString().Trim() != "")
                {
                    this.ctlDataGrid3.m_mthSetRowColor(this.ctlDataGrid3.CurrentCell.RowNumber, Color.FromArgb(255, 255, 255), Color.FromArgb(250, 89, 69));
                    this.ctlDataGrid3[this.ctlDataGrid3.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_quickid] = "1";
                }
                this.ctlDataGrid3.CurrentCell = new DataGridCell(this.ctlDataGrid3.CurrentCell.RowNumber + 1, 0);
            }
        }

        private void cboDeptmed1_Enter(object sender, EventArgs e)
        {
            this.cboDeptmed1.Hide();
            TextBox temp = sender as TextBox;
            try
            {
                if (temp.Text.Trim() != "")
                {
                    this.cboDeptmed1.Text = temp.Text;
                }
                this.cboDeptmed1.Bounds = temp.Bounds;
                this.cboDeptmed1.Show();
                this.cboDeptmed1.Focus();
                this.cboDeptmed1.Select();
                this.cboDeptmed1.BringToFront();
            }
            catch
            {
            }
        }

        private void cboDeptmed2_Enter(object sender, EventArgs e)
        {
            this.cboDeptmed2.Hide();
            TextBox temp = sender as TextBox;
            try
            {
                if (temp.Text.Trim() != "")
                {
                    this.cboDeptmed2.Text = temp.Text;
                }
                this.cboDeptmed2.Bounds = temp.Bounds;
                this.cboDeptmed2.Show();
                this.cboDeptmed2.Focus();
                this.cboDeptmed2.Select();
                this.cboDeptmed2.BringToFront();
            }
            catch
            {
            }
        }

        private void cboDeptmed6_Enter(object sender, EventArgs e)
        {
            this.cboDeptmed6.Hide();
            TextBox temp = sender as TextBox;
            try
            {
                if (temp.Text.Trim() != "")
                {
                    this.cboDeptmed6.Text = temp.Text;
                }
                this.cboDeptmed6.Bounds = temp.Bounds;
                this.cboDeptmed6.Show();
                this.cboDeptmed6.Focus();
                this.cboDeptmed6.Select();
                this.cboDeptmed6.BringToFront();
            }
            catch
            {
            }
        }

        private void piclis_MouseLeave(object sender, EventArgs e)
        {
            this.piclis.Location = new Point(this.piclis.Location.X + 1, this.piclis.Location.Y + 1);
        }

        private void piclis_MouseEnter(object sender, EventArgs e)
        {
            this.piclis.Location = new Point(this.piclis.Location.X - 1, this.piclis.Location.Y - 1);
        }

        private void picris_MouseEnter(object sender, EventArgs e)
        {
            this.picris.Location = new Point(this.picris.Location.X - 1, this.picris.Location.Y - 1);
        }

        private void picris_MouseLeave(object sender, EventArgs e)
        {
            this.picris.Location = new Point(this.picris.Location.X + 1, this.picris.Location.Y + 1);
        }

        private void picops_MouseEnter(object sender, EventArgs e)
        {
            this.picops.Location = new Point(this.picops.Location.X - 1, this.picops.Location.Y - 1);
        }

        private void picops_MouseLeave(object sender, EventArgs e)
        {
            this.picops.Location = new Point(this.picops.Location.X + 1, this.picops.Location.Y + 1);
        }

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_DoctorWorkstation)this.objController).m_mthRecalculate();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 科备药前景色
        /// </summary>
        private Color dfc = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 科备药背景色
        /// </summary>
        private Color dbc = Color.FromArgb(99, 143, 97);
        /// <summary>
        /// 正常前景色
        /// </summary>
        private Color nfc = Color.FromArgb(0, 0, 0);
        /// <summary>
        /// 正常背景色
        /// </summary>
        private Color nbc = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 编辑前景色
        /// </summary>
        private Color efc = Color.FromArgb(222, 239, 165);

        private void cboDeptmed1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_ItemID].ToString().Trim() != "")
            {
                if (this.cboDeptmed1.Text.Trim() == "是" && this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_DeptmedID].ToString().Trim() == "*")
                {
                    MessageBox.Show("该药品不允许科室自备。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_Deptmed] = this.cboDeptmed1.Text;
                    if (this.cboDeptmed1.Text.Trim() == "是")
                    {
                        this.ctlDataGrid1.m_mthSetRowColor(this.ctlDataGrid1.CurrentCell.RowNumber, dfc, dbc);
                        this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_DeptmedID] = "1";
                    }
                }
                this.ctlDataGrid1.CurrentCell = new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber + 1, 0);
            }
        }

        private void cboDeptmed2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, 8].ToString().Trim() != "")
            {
                if (this.cboDeptmed2.Text.Trim() == "是" && this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).cm_DeptmedID].ToString().Trim() == "*")
                {
                    MessageBox.Show("该药品不允许科室自备。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).cm_Deptmed] = this.cboDeptmed2.Text;
                    if (this.cboDeptmed2.Text.Trim() == "是")
                    {
                        this.ctlDataGrid2.m_mthSetRowColor(this.ctlDataGrid2.CurrentCell.RowNumber, dfc, dbc);
                        this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).cm_DeptmedID] = "1";
                    }
                }
                this.ctlDataGrid2.CurrentCell = new DataGridCell(this.ctlDataGrid2.CurrentCell.RowNumber + 1, 0);
            }
        }

        private void cboDeptmed6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_ItemID].ToString().Trim() != "")
            {
                if (this.cboDeptmed6.Text.Trim() == "是" && this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_DeptmedID].ToString().Trim() == "*")
                {
                    MessageBox.Show("该项目不允许科室自备。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_Deptmed] = this.cboDeptmed6.Text;
                    if (this.cboDeptmed6.Text.Trim() == "是")
                    {
                        this.ctlDataGrid6.m_mthSetRowColor(this.ctlDataGrid6.CurrentCell.RowNumber, dfc, dbc);
                        this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_DeptmedID] = "1";
                    }
                }
                this.ctlDataGrid6.CurrentCell = new DataGridCell(this.ctlDataGrid6.CurrentCell.RowNumber + 1, 0);
            }
        }

        private void cboDeptmed1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_ItemID].ToString().Trim() != "")
            {
                if (this.cboDeptmed1.Text.Trim() == "是" && this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_DeptmedID].ToString().Trim() == "*")
                {
                    MessageBox.Show("该药品不允许科室自备。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_Deptmed] = this.cboDeptmed1.Text;
                if (this.cboDeptmed1.Text.Trim() == "是")
                {
                    this.ctlDataGrid1.m_mthSetRowColor(this.ctlDataGrid1.CurrentCell.RowNumber, dfc, dbc);
                    this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_DeptmedID] = "1";
                }
                else
                {
                    if (this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_DeptmedID].ToString().Trim() != "*")
                    {
                        this.ctlDataGrid1.m_mthSetRowColor(this.ctlDataGrid1.CurrentCell.RowNumber, nfc, nbc);
                        this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).c_DeptmedID] = "0";
                    }
                }
            }
        }

        private void cboDeptmed2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, 8].ToString().Trim() != "")
            {
                if (this.cboDeptmed2.Text.Trim() == "是" && this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).cm_DeptmedID].ToString().Trim() == "*")
                {
                    MessageBox.Show("该药品不允许科室自备。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).cm_Deptmed] = this.cboDeptmed2.Text;
                if (this.cboDeptmed2.Text.Trim() == "是")
                {
                    this.ctlDataGrid2.m_mthSetRowColor(this.ctlDataGrid2.CurrentCell.RowNumber, dfc, dbc);
                    this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).cm_DeptmedID] = "1";
                }
                else
                {
                    if (this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).cm_DeptmedID].ToString().Trim() != "*")
                    {
                        this.ctlDataGrid2.m_mthSetRowColor(this.ctlDataGrid2.CurrentCell.RowNumber, nfc, nbc);
                        this.ctlDataGrid2[this.ctlDataGrid2.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).cm_DeptmedID] = "0";
                    }
                }
            }
        }

        private void cboDeptmed6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_ItemID].ToString().Trim() != "")
            {
                if (this.cboDeptmed6.Text.Trim() == "是" && this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_DeptmedID].ToString().Trim() == "*")
                {
                    MessageBox.Show("该项目不允许科室自备。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_Deptmed] = this.cboDeptmed6.Text;
                if (this.cboDeptmed6.Text.Trim() == "是")
                {
                    this.ctlDataGrid6.m_mthSetRowColor(this.ctlDataGrid6.CurrentCell.RowNumber, dfc, dbc);
                    this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_DeptmedID] = "1";
                }
                else
                {
                    if (this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_DeptmedID].ToString().Trim() != "*")
                    {
                        this.ctlDataGrid6.m_mthSetRowColor(this.ctlDataGrid6.CurrentCell.RowNumber, nfc, nbc);
                        this.ctlDataGrid6[this.ctlDataGrid6.CurrentCell.RowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_DeptmedID] = "0";
                    }
                }
            }
        }

        private void timerRecpur_Tick(object sender, EventArgs e)
        {
            if (noopen)
            {
                foreach (Form f in this.MdiParent.MdiChildren)
                {
                    f.WindowState = FormWindowState.Maximized;
                }
                this.MdiParent.Refresh();
                this.Close();
            }
        }

        private void ctlDataGridLis_Leave(object sender, EventArgs e)
        {
            if (intRowNoLis > -1)
            {
                intRowNoLis = -1;
            }
        }

        private void ctlDataGridLis_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNoLis();

            //设置前背景色
            int row = ctlDataGridLis.CurrentCell.RowNumber;
            int col = ctlDataGridLis.CurrentCell.ColumnNumber;
            if (col != 0)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridLis.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();

            if (this.plLis.Width > 0)
            {
                this.plLis.Width = 0;
            }
        }

        private void ctlDataGridLis_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGridLis.CurrentCell.RowNumber;

                string strReItemID = this.ctlDataGridLis[intRow, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString();

                if (strReItemID.StartsWith("[PK]"))
                {
                    decimal d1, d2;
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), null, null, -1, null, "lis", out d1, out d2, 1, 0);
                    ((clsCtl_DoctorWorkstation)this.objController).hasOrderID.Remove("lis->" + strReItemID.Replace("[PK]", ""));
                }

                this.ctlDataGridLis.m_mthDeleteRow(intRow);

                ctlDataGridLis.CurrentCell = new DataGridCell(this.ctlDataGridLis.CurrentCell.RowNumber, 0);
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }

        private void ctlDataGridLis_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }

                    if (m_strText.Trim().Substring(0, 1) == @"\")
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthGetAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                    }
                    else
                    {
                        intRowNoLis = e.m_intRowNumber;
                        if (this.m_cmbFind.SelectedIndex == 2)
                        {
                            m_strText = m_strText.ToUpper();
                        }
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindOrderLisByID(m_strText, e.m_intRowNumber);
                    }
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                if (m_strText.IndexOf(".") >= 0)
                {
                    MessageBox.Show("对不起，数量不能是小数。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                intRowNoLis = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (m_strText.Trim() == "")
                    {
                        this.ctlDataGridLis[intRowNoLis, ((clsCtl_DoctorWorkstation)this.objController).t_SumMoney] = "0";
                    }
                    else
                    {
                        this.ctlDataGridLis[intRowNoLis, ((clsCtl_DoctorWorkstation)this.objController).t_SumMoney] = Convert.ToString(Convert.ToDecimal(this.ctlDataGridLis[intRowNoLis, ((clsCtl_DoctorWorkstation)this.objController).t_Discount].ToString()) * Convert.ToDecimal(m_strText));
                    }
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGridLis[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString(), this.ctlDataGridLis[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_MainItemNum].ToString(), m_strText, "lis");
                    SendKeys.SendWait("{Tab}");
                }
            }
            if (e.m_intColNumber == 4)//查询检验类型
            {
                intRowNoLis = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (((clsCtl_DoctorWorkstation)this.objController).m_lngGetLisSampletyType(m_strText, e.m_intRowNumber) > 0)
                    {
                        this.listView5.Location = e.m_ptPositionInDataGrid;
                        this.listView5.Top += e.m_szTextBoxSize.Height;
                        this.listView5.Show();
                        this.listView5.BringToFront();
                        this.listView5.Items[0].Selected = true;
                        this.listView5.Select();
                        this.listView5.Focus();
                    }
                }
            }
            if (e.m_intColNumber == ((clsCtl_DoctorWorkstation)this.objController).t_quick)
            {
                SendKeys.SendWait("{Tab}");
            }
        }

        private void ctlDataGridLis_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (ctlDataGridLis[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_ItemID] == null || ctlDataGridLis[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_ItemID].ToString().Trim() == "")
            {
                return;
            }

            string id = "lis->" + e.m_intRowNumber.ToString() + "->" + ctlDataGridLis[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_ItemID].ToString();

            clsOrder_VO Order_VO = ((clsCtl_DoctorWorkstation)this.objController).hasOrderID[id] as clsOrder_VO;

            this.lvLis.Items.Clear();

            for (int i = 0; i < Order_VO.EntryDT.Rows.Count; i++)
            {
                DataRow dr = Order_VO.EntryDT.Rows[i];

                ListViewItem Item = new ListViewItem();

                this.lvLis.Items.Add(Item);

                decimal d = ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["itemprice_mny"]) * ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["totalqty_dec"]);

                Item = new ListViewItem(Convert.ToString(i + 1));
                Item.SubItems.Add(dr["itemname"].ToString().Trim());
                Item.SubItems.Add(dr["itemprice_mny"].ToString().Trim());
                Item.SubItems.Add(dr["totalqty_dec"].ToString().Trim());
                Item.SubItems.Add(d.ToString());
                Item.SubItems.Add(dr["precent_dec"].ToString().Trim() + "%");
                d = d * ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["precent_dec"]) / 100;
                Item.SubItems.Add(d.ToString("0.00"));
                this.lvLis.Items.Add(Item);
            }

            this.plLis.BringToFront();
            this.plLis.Width = 460;
        }

        private void ctlDataGridTest_Leave(object sender, EventArgs e)
        {
            if (intRowNoTest > -1)
            {
                intRowNoTest = -1;
            }
        }

        private void ctlDataGridTest_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNoTest();

            //设置前背景色
            int row = ctlDataGridTest.CurrentCell.RowNumber;
            int col = ctlDataGridTest.CurrentCell.ColumnNumber;
            if (col != 0)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridTest.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc; //Color.SteelBlue;			
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();

            if (this.plTest.Width > 0)
            {
                this.plTest.Width = 0;
            }
        }

        private void ctlDataGridTest_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGridTest.CurrentCell.RowNumber;

                string strReItemID = this.ctlDataGridTest[intRow, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString();

                if (strReItemID.StartsWith("[PK]"))
                {
                    decimal d1, d2;
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), null, null, -1, null, "test", out d1, out d2, 1, 0);
                    ((clsCtl_DoctorWorkstation)this.objController).hasOrderID.Remove("test->" + strReItemID.Replace("[PK]", ""));
                }

                ((clsCtl_DoctorWorkstation)this.objController).m_mthDelApplyBill(intRow);
                this.ctlDataGridTest.m_mthDeleteRow(intRow);
                ctlDataGridTest.CurrentCell = new DataGridCell(this.ctlDataGridTest.CurrentCell.RowNumber, 0);
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;

            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }

        private void ctlDataGridTest_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {

                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }

                    if (m_strText.Trim().Substring(0, 1) == @"\")
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthGetAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                    }
                    else
                    {
                        intRowNoTest = e.m_intRowNumber;

                        if (this.m_cmbFind.SelectedIndex == 2)
                        {
                            m_strText = m_strText.ToUpper();
                        }
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindExamineChargeByOrderID(m_strText, e.m_intRowNumber);
                    }
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNoTest = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (m_strText.Trim() == "")
                    {
                        this.ctlDataGridTest[intRowNoTest, ((clsCtl_DoctorWorkstation)this.objController).t_SumMoney] = "0";
                    }
                    else
                    {
                        this.ctlDataGridTest[intRowNoTest, ((clsCtl_DoctorWorkstation)this.objController).t_SumMoney] = Convert.ToString(Convert.ToDecimal(this.ctlDataGridTest[intRowNoTest, ((clsCtl_DoctorWorkstation)this.objController).t_Discount].ToString()) * Convert.ToDecimal(m_strText));
                    }
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(this.ctlDataGridTest[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_resubitem].ToString(), this.ctlDataGridTest[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_MainItemNum].ToString(), m_strText, "test");
                    SendKeys.SendWait("{Tab}");
                }
            }
            if (e.m_intColNumber == 4)//输入检查部位
            {
                intRowNoTest = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (((clsCtl_DoctorWorkstation)this.objController).m_mthLoadCheckPart(m_strText, e.m_intRowNumber) > 0)
                    {
                        this.listView5.Location = e.m_ptPositionInDataGrid;
                        this.listView5.Top += e.m_szTextBoxSize.Height;
                        this.listView5.Show();
                        this.listView5.BringToFront();
                        this.listView5.Items[0].Selected = true;
                        this.listView5.Select();
                        this.listView5.Focus();
                    }
                }
            }
        }

        private void ctlDataGridTest_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (ctlDataGridTest[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_ItemID] == null || ctlDataGridTest[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_ItemID].ToString().Trim() == "")
            {
                return;
            }

            string id = "test->" + e.m_intRowNumber.ToString() + "->" + ctlDataGridTest[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).t_ItemID].ToString();

            clsOrder_VO Order_VO = ((clsCtl_DoctorWorkstation)this.objController).hasOrderID[id] as clsOrder_VO;

            this.lvTest.Items.Clear();

            for (int i = 0; i < Order_VO.EntryDT.Rows.Count; i++)
            {
                DataRow dr = Order_VO.EntryDT.Rows[i];

                ListViewItem Item = new ListViewItem();

                this.lvTest.Items.Add(Item);

                decimal d = ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["itemprice_mny"]) * ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["totalqty_dec"]);

                Item = new ListViewItem(Convert.ToString(i + 1));
                Item.SubItems.Add(dr["itemname"].ToString().Trim());
                Item.SubItems.Add(dr["itemprice_mny"].ToString().Trim());
                Item.SubItems.Add(dr["totalqty_dec"].ToString().Trim());
                Item.SubItems.Add(d.ToString());
                Item.SubItems.Add(dr["precent_dec"].ToString().Trim() + "%");
                d = d * ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["precent_dec"]) / 100;
                Item.SubItems.Add(d.ToString("0.00"));

                this.lvTest.Items.Add(Item);
            }

            this.plTest.BringToFront();
            this.plTest.Width = 460;
        }

        private void ctlDataGridOps_Leave(object sender, EventArgs e)
        {
            if (intRowNoOps > -1)
            {
                intRowNoOps = -1;
            }
        }

        private void ctlDataGridOps_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                int intRow = ctlDataGridOps.CurrentCell.RowNumber;

                string strReItemID = this.ctlDataGridOps[intRow, ((clsCtl_DoctorWorkstation)this.objController).o_resubitem].ToString();

                if (strReItemID.StartsWith("[PK]"))
                {
                    decimal d1, d2;
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), null, null, -1, null, "ops", out d1, out d2, 1, 0);
                    ((clsCtl_DoctorWorkstation)this.objController).hasOrderID.Remove("ops->" + strReItemID.Replace("[PK]", ""));
                }

                this.ctlDataGridOps.m_mthDeleteRow(intRow);
                ctlDataGridOps.CurrentCell = new DataGridCell(this.ctlDataGridOps.CurrentCell.RowNumber, 0);
                //因为DataGrid有个Bug所以发送下面的模拟键
                SendKeys.SendWait("{Right}");
                SendKeys.SendWait("{Left}");
                SendKeys.SendWait("{Left}");
                return;

            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthFormKeyDown(e);
        }

        private void ctlDataGridOps_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).m_mthSetColNoOps();

            //设置前背景色
            int row = ctlDataGridOps.CurrentCell.RowNumber;
            int col = ctlDataGridOps.CurrentCell.ColumnNumber;

            if (col != 0)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[col] != null)
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGridOps.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = efc;	//Color.SteelBlue;			
            }
            ((clsCtl_DoctorWorkstation)this.objController).m_mthCalculateTotalMoney();

            if (this.plOps.Width > 0)
            {
                this.plOps.Width = 0;
            }
        }

        private void ctlDataGridOps_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode == Keys.Enter)//查询
            {
                if (e.m_intColNumber == 0)
                {
                    if (m_strText.Trim() == "")
                    {
                        return;
                    }

                    if (m_strText.Trim().Substring(0, 1) == @"\")
                    {
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthGetAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                    }
                    else
                    {
                        intRowNoOps = e.m_intRowNumber;

                        if (this.m_cmbFind.SelectedIndex == 2)
                        {
                            m_strText = m_strText.ToUpper();
                        }
                        ((clsCtl_DoctorWorkstation)this.objController).m_mthFindOPSChargeByOrderID(m_strText, e.m_intRowNumber);
                    }
                }
            }
            if (e.m_intColNumber == 1)//输入数量
            {
                intRowNoOps = e.m_intRowNumber;
                if (e.KeyCode == Keys.Enter)
                {
                    if (m_strText.Trim() == "")
                    {
                        this.ctlDataGridOps[intRowNoOps, ((clsCtl_DoctorWorkstation)this.objController).o_SumMoney] = "0";
                    }
                    else
                    {
                        this.ctlDataGridOps[intRowNoOps, ((clsCtl_DoctorWorkstation)this.objController).o_SumMoney] = Convert.ToString(Convert.ToDecimal(ctlDataGridOps[intRowNoOps, ((clsCtl_DoctorWorkstation)this.objController).o_Discount].ToString()) * Convert.ToDecimal(m_strText));
                    }
                    ((clsCtl_DoctorWorkstation)this.objController).m_mthCheckMainItemNum(ctlDataGridOps[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_resubitem].ToString(), ctlDataGridOps[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_MainItemNum].ToString(), m_strText, "ops", "1");
                    SendKeys.SendWait("{Tab}");
                }
            }
        }

        private void ctlDataGridOps_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (ctlDataGridOps[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_ItemID] == null || ctlDataGridOps[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_ItemID].ToString().Trim() == "")
            {
                return;
            }

            string id = "ops->" + e.m_intRowNumber.ToString() + "->" + ctlDataGridOps[e.m_intRowNumber, ((clsCtl_DoctorWorkstation)this.objController).o_ItemID].ToString();

            clsOrder_VO Order_VO = ((clsCtl_DoctorWorkstation)this.objController).hasOrderID[id] as clsOrder_VO;

            this.lvOps.Items.Clear();

            for (int i = 0; i < Order_VO.EntryDT.Rows.Count; i++)
            {
                DataRow dr = Order_VO.EntryDT.Rows[i];

                ListViewItem Item = new ListViewItem();

                this.lvOps.Items.Add(Item);

                decimal d = ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["itemprice_mny"]) * ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["totalqty_dec"]);

                Item = new ListViewItem(Convert.ToString(i + 1));
                Item.SubItems.Add(dr["itemname"].ToString().Trim());
                Item.SubItems.Add(dr["itemprice_mny"].ToString().Trim());
                Item.SubItems.Add(dr["totalqty_dec"].ToString().Trim());
                Item.SubItems.Add(d.ToString());
                Item.SubItems.Add(dr["precent_dec"].ToString().Trim() + "%");
                d = d * ((clsCtl_DoctorWorkstation)this.objController).m_mthConvertObjToDecimal(dr["precent_dec"]) / 100;
                Item.SubItems.Add(d.ToString("0.00"));

                this.lvOps.Items.Add(Item);
            }

            this.plOps.BringToFront();
            this.plOps.Width = 460;
        }

        private void btnPrefer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确认该病人：是否要进行【先诊后结】的结算？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.btnPrefer.Enabled = false;
                ((clsCtl_DoctorWorkstation)this.objController).m_mthPayBillTrade();
            }
        }

        private void tsmiDrugInfo_Click(object sender, EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).GetDrugInfo();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            ((clsCtl_DoctorWorkstation)this.objController).RegBooking();
        }

        private void btnWAC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_PatInfo.PatientID))
            {
                MessageBox.Show("请刷卡（选择病人）", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frmWAC frmwac = new frmWAC(this.m_PatInfo.PatientID);
            frmwac.ShowDialog();
        }

    }
}