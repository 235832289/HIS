using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HI;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// frmOPCharge 的摘要说明。
    /// </summary>
    public class frmOPCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox m_txtInvoiceNO;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox m_cmbPayMode;
        internal System.Windows.Forms.ComboBox m_cmbRecipeNO;
        internal System.Windows.Forms.ComboBox m_cmbFind;
        internal System.Windows.Forms.ComboBox m_cmbRecipeType;
        private PinkieControls.ButtonXP btExit;
        internal PinkieControls.ButtonXP btOK;
        internal com.digitalwave.controls.ctlPatientBasicInfo m_PatientBasicInfo;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        internal System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label30;
        internal PinkieControls.ButtonXP btSave;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.CheckBox chkLoadData;
        /// <summary>
        /// 标志用户改变剂量但没有按回车的情况.true 为正常,false为要改变剂量
        /// </summary>
        public bool IsSave = true;
        /// <summary>
        /// 标志用户改变剂量但没有按回车更改剂量要不要跳转.正常为true.不需要跳转false
        /// </summary>
        public bool IsSendTabKey = true;
        /// <summary>
        /// 记录当前行的位置
        /// </summary>
        public int rowNO = 0;
        /// <summary>
        /// 记录中文输入法
        /// </summary>
        private InputLanguage myInputLanguage = InputLanguage.DefaultInputLanguage;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        internal com.digitalwave.controls.DGCS.txtLoadRecipeNo txtLoadRecipeNO;
        private PinkieControls.ButtonXP btPrint;
        internal System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cmbFindAccordRecipe;
        internal System.Windows.Forms.TextBox txtFindAccordRecipe;
        internal PinkieControls.ButtonXP btReUse;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        internal System.Windows.Forms.CheckBox chkDefaultItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private IContainer components;

        /// <summary>
        /// 关联项目ID列
        /// </summary>
        private const int ResubitemCol = 27;
        private System.Windows.Forms.Label label7;
        internal Label lblCardtype;
        internal System.Windows.Forms.TextBox txtIDcard;
        internal System.Windows.Forms.TextBox txtInsuranceID;
        private System.Windows.Forms.Label label9;
        private Timer timer;
        /// <summary>
        /// 主项默认用量列
        /// </summary>
        private const int ResubnumsCol = 28;

        /// <summary>
        /// 医保结算标志
        /// </summary>
        internal bool YBFlag = false;
        /// <summary>
        /// (医保)医保记账金额
        /// </summary>
        internal decimal YBVal = 0;
        /// <summary>
        /// (医保)总金额
        /// </summary>
        internal decimal TolVal = 0;
        /// <summary>
        /// 补充医疗（1）统筹支付
        /// </summary>
        public decimal m_decBCYLTCZF1 = 0;
        /// <summary>
        /// 补充医疗（2）统筹支付
        /// </summary>
        public decimal m_decBCYLTCZF2 = 0;
        /// <summary>
        /// 补充医疗（3）统筹支付
        /// </summary>
        public decimal m_decBCYLTCZF3 = 0;
        /// <summary>
        /// 补充医疗（4）统筹支付
        /// </summary>
        public decimal m_decBCYLTCZF4 = 0;
        /// <summary>
        /// 其他支付
        /// </summary>
        public decimal m_decQTZHIFU = 0;
        /// <summary>
        /// 医保记账发票金额
        /// </summary>
        public decimal m_decYBJZFPJE = 0;
        /// <summary>
        /// 行号
        /// </summary>
        public int RowNum = -1;
        /// <summary>
        /// 是否新社保
        /// </summary>
        public int YBnewFlag = -1;
        /// <summary>
        /// LED显示参数
        /// </summary>
        private QueueSystemClient.PatientCalledEventArgs LEDArgs;
        /// <summary>
        /// 是否开分门诊西药房和急诊药房，0为合并，1为分开
        /// </summary>
        public int IsDetachWMedStore = 0;
        /// <summary>
        /// 药房急诊配药窗ID
        /// </summary>
        public string strEmergencyMedStoreTWindow = "";
        /// <summary>
        /// 药房急诊发药窗ID
        /// </summary>
        public string strEmergencyMedStoreSWindow = "";
        /// <summary>
        /// 药房专用配药窗ID
        /// </summary>
        public string strSpecialMedStoreTWindow = "";
        /// <summary>
        /// 药房专用发药窗ID
        /// </summary>
        public string strSpecialMedStoreSWindow = "";
        /// <summary>
        /// 收费窗类型，0普通收费窗，1急诊收费窗
        /// </summary>
        public int intChargeWindowType = 0;
        /// <summary>
        /// 专窗接收特别年龄，如60，则接收60岁以上的病人处方
        /// </summary>
        public int intSpecialPatientAge = 0;
        /// <summary>
        /// 急诊配药窗口名
        /// </summary>
        public string strEmergencyTWinName = "";
        /// <summary>
        /// 急诊发药窗口名
        /// </summary>
        public string strEmergencySWinName = "";
        /// <summary>
        /// 专配药窗名
        /// </summary>
        public string strSpecialTWinName = "";
        /// <summary>
        /// 专发药窗名
        /// </summary>
        public string strSpecialSWinName = "";
        /// <summary>
        /// 急诊科ID
        /// </summary>
        public string strEmergencyDeptID = "";
        /// <summary>
        /// 先诊疗后结算不发送配药信息
        /// </summary>
        public bool blnFlag = false;
        /// <summary>
        /// 先诊疗后结算项目,是否是选择性交费
        /// </summary>
        internal bool m_blnIsSelectChargeItem = false;
        // 20151102
        decimal totalMoney = 0;

        /// <summary>
        /// 生育保险编码
        /// </summary>
        public string BirthInsuranceCode { get; set; }

        #region 门诊收费导引屏
        /// <summary>
        /// 门诊收费导引屏
        /// </summary>
        public frmOPChargeRight m_objOPChargeRight = null;
        internal Panel plRecipe;
        private Panel panel12;
        private Label label20;
        internal ListView lvRecipe;
        private ColumnHeader columnHeader44;
        private ColumnHeader columnHeader45;
        private ColumnHeader columnHeader46;
        private ColumnHeader columnHeader47;
        private ColumnHeader columnHeader49;
        private ColumnHeader columnHeader52;
        private Panel panel13;
        private Label label28;
        private PictureBox pictureBox3;
        private PinkieControls.ButtonXP btnViewRecipe;
        private ColumnHeader columnHeader53;
        internal ComboBox cboProxyBoilMed;
        private Label label32;

        /// <summary>
        /// 是否显示双屏
        /// </summary>
        internal bool m_blnDoubleScreen = false;
        #endregion

        /// <summary>
        /// 是否处方HTTP.POST
        /// </summary>
        internal bool IsRecipeHttpPost { get; set; }

        /// <summary>
        /// 是否中药处方.通过发票分类 0003 判断
        /// </summary>
        internal bool IsCmRecipe { get; set; }

        /// <summary>
        /// HTTP.Uri
        /// </summary>
        internal string HttpUri { get; set; }

        public frmOPCharge()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            //微调由2003升级到2005窗体高度BUG
            if (this.LoginInfo.m_strEmpNo != "0001")
            {
                this.Height += 20;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPCharge));
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chkDefaultItem = new System.Windows.Forms.CheckBox();
            this.btPrint = new PinkieControls.ButtonXP();
            this.chkLoadData = new System.Windows.Forms.CheckBox();
            this.btSave = new PinkieControls.ButtonXP();
            this.label30 = new System.Windows.Forms.Label();
            this.btExit = new PinkieControls.ButtonXP();
            this.btOK = new PinkieControls.ButtonXP();
            this.txtFindAccordRecipe = new System.Windows.Forms.TextBox();
            this.cmbFindAccordRecipe = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_PatientBasicInfo = new com.digitalwave.controls.ctlPatientBasicInfo();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbPayMode = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnViewRecipe = new PinkieControls.ButtonXP();
            this.m_cmbFind = new System.Windows.Forms.ComboBox();
            this.m_cmbRecipeType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoadRecipeNO = new com.digitalwave.controls.DGCS.txtLoadRecipeNo();
            this.txtInsuranceID = new System.Windows.Forms.TextBox();
            this.txtIDcard = new System.Windows.Forms.TextBox();
            this.lblCardtype = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btReUse = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtInvoiceNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbRecipeNO = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ctlDataGrid1 = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.plRecipe = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.lvRecipe = new System.Windows.Forms.ListView();
            this.columnHeader44 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader45 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader46 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader47 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader49 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader52 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader53 = new System.Windows.Forms.ColumnHeader();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cboProxyBoilMed = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).BeginInit();
            this.plRecipe.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cboProxyBoilMed);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.chkDefaultItem);
            this.panel1.Controls.Add(this.btPrint);
            this.panel1.Controls.Add(this.chkLoadData);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.txtFindAccordRecipe);
            this.panel1.Controls.Add(this.cmbFindAccordRecipe);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 584);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 40);
            this.panel1.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numericUpDown1.Location = new System.Drawing.Point(81, 11);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 23);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // chkDefaultItem
            // 
            this.chkDefaultItem.Checked = true;
            this.chkDefaultItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultItem.Location = new System.Drawing.Point(392, 7);
            this.chkDefaultItem.Name = "chkDefaultItem";
            this.chkDefaultItem.Size = new System.Drawing.Size(96, 32);
            this.chkDefaultItem.TabIndex = 41;
            this.chkDefaultItem.Text = "调默认项目";
            // 
            // btPrint
            // 
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "";
            this.btPrint.Location = new System.Drawing.Point(662, 5);
            this.btPrint.Name = "btPrint";
            this.btPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(80, 32);
            this.btPrint.TabIndex = 4;
            this.btPrint.Text = "打印明细";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // chkLoadData
            // 
            this.chkLoadData.Checked = true;
            this.chkLoadData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoadData.Location = new System.Drawing.Point(292, 7);
            this.chkLoadData.Name = "chkLoadData";
            this.chkLoadData.Size = new System.Drawing.Size(96, 32);
            this.chkLoadData.TabIndex = 7;
            this.chkLoadData.Text = "刷卡调处方";
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btSave.DefaultScheme = true;
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSave.Hint = "";
            this.btSave.Location = new System.Drawing.Point(496, 5);
            this.btSave.Name = "btSave";
            this.btSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btSave.Size = new System.Drawing.Size(80, 32);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "保存(&S)";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(8, 14);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(80, 16);
            this.label30.TabIndex = 5;
            this.label30.Text = "中药服数:";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(745, 5);
            this.btExit.Name = "btExit";
            this.btExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(80, 32);
            this.btExit.TabIndex = 6;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(579, 5);
            this.btOK.Name = "btOK";
            this.btOK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(80, 32);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "结账(+)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // txtFindAccordRecipe
            // 
            this.txtFindAccordRecipe.Location = new System.Drawing.Point(251, 80);
            this.txtFindAccordRecipe.Name = "txtFindAccordRecipe";
            this.txtFindAccordRecipe.Size = new System.Drawing.Size(87, 23);
            this.txtFindAccordRecipe.TabIndex = 40;
            this.txtFindAccordRecipe.Visible = false;
            this.txtFindAccordRecipe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFindAccordRecipe_KeyDown);
            // 
            // cmbFindAccordRecipe
            // 
            this.cmbFindAccordRecipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindAccordRecipe.Items.AddRange(new object[] {
            "名  称",
            "助记码",
            "拼音码",
            "五笔码"});
            this.cmbFindAccordRecipe.Location = new System.Drawing.Point(184, 80);
            this.cmbFindAccordRecipe.Name = "cmbFindAccordRecipe";
            this.cmbFindAccordRecipe.Size = new System.Drawing.Size(68, 22);
            this.cmbFindAccordRecipe.TabIndex = 39;
            this.cmbFindAccordRecipe.Visible = false;
            this.cmbFindAccordRecipe.SelectedIndexChanged += new System.EventHandler(this.cmbFindAccordRecipe_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "模板:";
            this.label4.Visible = false;
            // 
            // m_PatientBasicInfo
            // 
            this.m_PatientBasicInfo.Charge = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_PatientBasicInfo.CurrentDeptID = "";
            this.m_PatientBasicInfo.CurrentDeptName = "";
            this.m_PatientBasicInfo.CurrentDoctorID = "";
            this.m_PatientBasicInfo.CurrentDoctorName = "";
            this.m_PatientBasicInfo.CurrentDoctorNo = "";
            this.m_PatientBasicInfo.CurrentDoctTechnicalRank = "";
            this.m_PatientBasicInfo.DeptID = "";
            this.m_PatientBasicInfo.DeptName = "";
            this.m_PatientBasicInfo.Discount = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_PatientBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_PatientBasicInfo.DoctorID = "";
            this.m_PatientBasicInfo.DoctorName = "";
            this.m_PatientBasicInfo.DoctorNo = "";
            this.m_PatientBasicInfo.DoctTechnicalRank = "";
            this.m_PatientBasicInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_PatientBasicInfo.HotKey = "F3";
            this.m_PatientBasicInfo.Hypersusceptibility = "";
            this.m_PatientBasicInfo.IDcard = "";
            this.m_PatientBasicInfo.Limit = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_PatientBasicInfo.Location = new System.Drawing.Point(0, 0);
            this.m_PatientBasicInfo.m_strIsVip = "";
            this.m_PatientBasicInfo.Name = "m_PatientBasicInfo";
            this.m_PatientBasicInfo.PatientAge = "";
            this.m_PatientBasicInfo.PatientBirth = "";
            this.m_PatientBasicInfo.PatientCardID = "";
            this.m_PatientBasicInfo.PatientHomeAddress = "";
            this.m_PatientBasicInfo.PatientID = "";
            this.m_PatientBasicInfo.PatientName = "";
            this.m_PatientBasicInfo.PatientSex = "";
            this.m_PatientBasicInfo.PatientTelephoneNo = "";
            this.m_PatientBasicInfo.PatientType = 0;
            this.m_PatientBasicInfo.PayTypeID = "";
            this.m_PatientBasicInfo.PayTypeName = "";
            this.m_PatientBasicInfo.RegisterID = "";
            this.m_PatientBasicInfo.RegisterNo = "";
            this.m_PatientBasicInfo.RegTypeID = "";
            this.m_PatientBasicInfo.Size = new System.Drawing.Size(1028, 152);
            this.m_PatientBasicInfo.TabIndex = 0;
            this.m_PatientBasicInfo.TakeDiagRecID = "";
            this.m_PatientBasicInfo.PatientChanged += new com.digitalwave.controls.TextChangeEvent(this.m_PatientBasicInfo_PatientChanged);
            this.m_PatientBasicInfo.SelectDoctor += new System.EventHandler(this.m_PatientBasicInfo_SelectDoctor);
            this.m_PatientBasicInfo.PatientTypeChanged += new com.digitalwave.controls.HandlePatientTypeChange(this.m_PatientBasicInfo_PatientTypeChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(860, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 612);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(520, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "付款方式:";
            // 
            // m_cmbPayMode
            // 
            this.m_cmbPayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbPayMode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmbPayMode.Items.AddRange(new object[] {
            "现金",
            "银行卡",
            "支票",
            "IC卡",
            "社保预计费",
            "微信2"});
            this.m_cmbPayMode.Location = new System.Drawing.Point(592, 8);
            this.m_cmbPayMode.Name = "m_cmbPayMode";
            this.m_cmbPayMode.Size = new System.Drawing.Size(80, 22);
            this.m_cmbPayMode.TabIndex = 3;
            this.m_cmbPayMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cmbRecipeType_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnViewRecipe);
            this.panel3.Controls.Add(this.m_cmbFind);
            this.panel3.Controls.Add(this.m_cmbRecipeType);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtLoadRecipeNO);
            this.panel3.Controls.Add(this.txtInsuranceID);
            this.panel3.Controls.Add(this.txtIDcard);
            this.panel3.Controls.Add(this.lblCardtype);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.btReUse);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.m_txtInvoiceNO);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.m_cmbPayMode);
            this.panel3.Controls.Add(this.m_cmbRecipeNO);
            this.panel3.Font = new System.Drawing.Font("宋体", 9F);
            this.panel3.Location = new System.Drawing.Point(8, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(840, 67);
            this.panel3.TabIndex = 1;
            // 
            // btnViewRecipe
            // 
            this.btnViewRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnViewRecipe.DefaultScheme = true;
            this.btnViewRecipe.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnViewRecipe.Hint = "";
            this.btnViewRecipe.Location = new System.Drawing.Point(753, 6);
            this.btnViewRecipe.Name = "btnViewRecipe";
            this.btnViewRecipe.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnViewRecipe.Size = new System.Drawing.Size(80, 24);
            this.btnViewRecipe.TabIndex = 14;
            this.btnViewRecipe.Text = "查看处方";
            this.btnViewRecipe.Click += new System.EventHandler(this.btnViewRecipe_Click);
            // 
            // m_cmbFind
            // 
            this.m_cmbFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFind.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmbFind.Items.AddRange(new object[] {
            "编号",
            "项目名称",
            "拼音码",
            "五笔码",
            "英文名",
            "旧码"});
            this.m_cmbFind.Location = new System.Drawing.Point(753, 40);
            this.m_cmbFind.Name = "m_cmbFind";
            this.m_cmbFind.Size = new System.Drawing.Size(80, 22);
            this.m_cmbFind.TabIndex = 4;
            this.m_cmbFind.SelectedIndexChanged += new System.EventHandler(this.m_cmbFind_SelectedIndexChanged);
            this.m_cmbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cmbRecipeType_KeyDown);
            // 
            // m_cmbRecipeType
            // 
            this.m_cmbRecipeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRecipeType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmbRecipeType.Items.AddRange(new object[] {
            "正方",
            "副方"});
            this.m_cmbRecipeType.Location = new System.Drawing.Point(592, 40);
            this.m_cmbRecipeType.Name = "m_cmbRecipeType";
            this.m_cmbRecipeType.Size = new System.Drawing.Size(80, 22);
            this.m_cmbRecipeType.TabIndex = 1;
            this.m_cmbRecipeType.SelectedIndexChanged += new System.EventHandler(this.m_cmbRecipeType_SelectedIndexChanged);
            this.m_cmbRecipeType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cmbRecipeType_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(520, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "处方类型:";
            // 
            // txtLoadRecipeNO
            // 
            this.txtLoadRecipeNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoadRecipeNO.Location = new System.Drawing.Point(318, 40);
            this.txtLoadRecipeNO.Name = "txtLoadRecipeNO";
            this.txtLoadRecipeNO.Size = new System.Drawing.Size(146, 23);
            this.txtLoadRecipeNO.TabIndex = 7;
            this.txtLoadRecipeNO.RecipeSelected += new System.EventHandler(this.txtLoadRecipeNO_RecipeSelected);
            // 
            // txtInsuranceID
            // 
            this.txtInsuranceID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsuranceID.Location = new System.Drawing.Point(318, 6);
            this.txtInsuranceID.MaxLength = 20;
            this.txtInsuranceID.Name = "txtInsuranceID";
            this.txtInsuranceID.Size = new System.Drawing.Size(146, 23);
            this.txtInsuranceID.TabIndex = 12;
            this.txtInsuranceID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInsuranceID_KeyDown);
            // 
            // txtIDcard
            // 
            this.txtIDcard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDcard.Location = new System.Drawing.Point(79, 6);
            this.txtIDcard.MaxLength = 18;
            this.txtIDcard.Name = "txtIDcard";
            this.txtIDcard.Size = new System.Drawing.Size(146, 23);
            this.txtIDcard.TabIndex = 11;
            this.txtIDcard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDcard_KeyDown);
            // 
            // lblCardtype
            // 
            this.lblCardtype.AutoSize = true;
            this.lblCardtype.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardtype.Location = new System.Drawing.Point(247, 8);
            this.lblCardtype.Name = "lblCardtype";
            this.lblCardtype.Size = new System.Drawing.Size(77, 14);
            this.lblCardtype.TabIndex = 10;
            this.lblCardtype.Text = "医保卡号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "身份证号：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(247, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 14);
            this.label22.TabIndex = 6;
            this.label22.Text = "处方号:";
            // 
            // btReUse
            // 
            this.btReUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btReUse.DefaultScheme = true;
            this.btReUse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btReUse.Font = new System.Drawing.Font("宋体", 9F);
            this.btReUse.Hint = "";
            this.btReUse.Location = new System.Drawing.Point(468, 39);
            this.btReUse.Name = "btReUse";
            this.btReUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btReUse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btReUse.Size = new System.Drawing.Size(45, 24);
            this.btReUse.TabIndex = 8;
            this.btReUse.Text = "复用";
            this.btReUse.Click += new System.EventHandler(this.btReUse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(684, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "查找方式:";
            // 
            // m_txtInvoiceNO
            // 
            this.m_txtInvoiceNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.m_txtInvoiceNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtInvoiceNO.ForeColor = System.Drawing.Color.Black;
            this.m_txtInvoiceNO.Location = new System.Drawing.Point(79, 40);
            this.m_txtInvoiceNO.MaxLength = 10;
            this.m_txtInvoiceNO.Name = "m_txtInvoiceNO";
            this.m_txtInvoiceNO.Size = new System.Drawing.Size(146, 23);
            this.m_txtInvoiceNO.TabIndex = 0;
            this.m_txtInvoiceNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtInvoiceNO_KeyDown);
            this.m_txtInvoiceNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtInvoiceNO_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "发票号:";
            // 
            // m_cmbRecipeNO
            // 
            this.m_cmbRecipeNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRecipeNO.Location = new System.Drawing.Point(320, 40);
            this.m_cmbRecipeNO.Name = "m_cmbRecipeNO";
            this.m_cmbRecipeNO.Size = new System.Drawing.Size(112, 20);
            this.m_cmbRecipeNO.TabIndex = 2;
            this.m_cmbRecipeNO.Visible = false;
            this.m_cmbRecipeNO.Enter += new System.EventHandler(this.m_cmbRecipeNO_Enter);
            this.m_cmbRecipeNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cmbRecipeNO_KeyDown);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.ctlDataGrid1);
            this.panel4.Controls.Add(this.plRecipe);
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Controls.Add(this.listView1);
            this.panel4.Location = new System.Drawing.Point(8, 160);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(840, 420);
            this.panel4.TabIndex = 2;
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
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "Column1";
            clsColumnInfo1.ColumnWidth = 75;
            clsColumnInfo1.Enabled = true;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "查询";
            clsColumnInfo1.ReadOnly = false;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "Column2";
            clsColumnInfo2.ColumnWidth = 60;
            clsColumnInfo2.Enabled = true;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo2.HeadText = "数量";
            clsColumnInfo2.ReadOnly = false;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "Column3";
            clsColumnInfo3.ColumnWidth = 200;
            clsColumnInfo3.Enabled = true;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "项目名称";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "Column12";
            clsColumnInfo4.ColumnWidth = 60;
            clsColumnInfo4.Enabled = true;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "类型";
            clsColumnInfo4.ReadOnly = false;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo5.BackColor = System.Drawing.Color.White;
            clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo5.ColumnIndex = 4;
            clsColumnInfo5.ColumnName = "Column4";
            clsColumnInfo5.ColumnWidth = 122;
            clsColumnInfo5.Enabled = true;
            clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo5.HeadText = "规格";
            clsColumnInfo5.ReadOnly = true;
            clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo6.BackColor = System.Drawing.Color.White;
            clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo6.ColumnIndex = 5;
            clsColumnInfo6.ColumnName = "Column5";
            clsColumnInfo6.ColumnWidth = 45;
            clsColumnInfo6.Enabled = true;
            clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo6.HeadText = "单位";
            clsColumnInfo6.ReadOnly = true;
            clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo7.BackColor = System.Drawing.Color.White;
            clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo7.ColumnIndex = 6;
            clsColumnInfo7.ColumnName = "Column6";
            clsColumnInfo7.ColumnWidth = 70;
            clsColumnInfo7.Enabled = true;
            clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo7.HeadText = "单价";
            clsColumnInfo7.ReadOnly = false;
            clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo8.BackColor = System.Drawing.Color.White;
            clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo8.ColumnIndex = 7;
            clsColumnInfo8.ColumnName = "Column7";
            clsColumnInfo8.ColumnWidth = 70;
            clsColumnInfo8.Enabled = false;
            clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo8.HeadText = "总价";
            clsColumnInfo8.ReadOnly = true;
            clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo9.BackColor = System.Drawing.Color.White;
            clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo9.ColumnIndex = 8;
            clsColumnInfo9.ColumnName = "Column8";
            clsColumnInfo9.ColumnWidth = 0;
            clsColumnInfo9.Enabled = true;
            clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo9.HeadText = "门诊发票核算类别ID";
            clsColumnInfo9.ReadOnly = false;
            clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo10.BackColor = System.Drawing.Color.White;
            clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo10.ColumnIndex = 9;
            clsColumnInfo10.ColumnName = "Column9";
            clsColumnInfo10.ColumnWidth = 0;
            clsColumnInfo10.Enabled = true;
            clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo10.HeadText = "收费项目分类ID";
            clsColumnInfo10.ReadOnly = false;
            clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo11.BackColor = System.Drawing.Color.White;
            clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo11.ColumnIndex = 10;
            clsColumnInfo11.ColumnName = "Column10";
            clsColumnInfo11.ColumnWidth = 0;
            clsColumnInfo11.Enabled = true;
            clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo11.HeadText = "ID";
            clsColumnInfo11.ReadOnly = false;
            clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo12.BackColor = System.Drawing.Color.White;
            clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo12.ColumnIndex = 11;
            clsColumnInfo12.ColumnName = "Column11";
            clsColumnInfo12.ColumnWidth = 0;
            clsColumnInfo12.Enabled = true;
            clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo12.HeadText = "是否自定义价格";
            clsColumnInfo12.ReadOnly = true;
            clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo13.BackColor = System.Drawing.Color.White;
            clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo13.ColumnIndex = 12;
            clsColumnInfo13.ColumnName = "Column13";
            clsColumnInfo13.ColumnWidth = 0;
            clsColumnInfo13.Enabled = true;
            clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo13.HeadText = "行号";
            clsColumnInfo13.ReadOnly = false;
            clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo14.BackColor = System.Drawing.Color.White;
            clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo14.ColumnIndex = 13;
            clsColumnInfo14.ColumnName = "Column14";
            clsColumnInfo14.ColumnWidth = 60;
            clsColumnInfo14.Enabled = true;
            clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo14.HeadText = "比例";
            clsColumnInfo14.ReadOnly = false;
            clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo15.BackColor = System.Drawing.Color.White;
            clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo15.ColumnIndex = 14;
            clsColumnInfo15.ColumnName = "Column15";
            clsColumnInfo15.ColumnWidth = 0;
            clsColumnInfo15.Enabled = true;
            clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo15.HeadText = "比例值";
            clsColumnInfo15.ReadOnly = true;
            clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo16.BackColor = System.Drawing.Color.White;
            clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo16.ColumnIndex = 15;
            clsColumnInfo16.ColumnName = "Column16";
            clsColumnInfo16.ColumnWidth = 0;
            clsColumnInfo16.Enabled = false;
            clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo16.HeadText = "门诊核算ID";
            clsColumnInfo16.ReadOnly = true;
            clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo17.BackColor = System.Drawing.Color.White;
            clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo17.ColumnIndex = 16;
            clsColumnInfo17.ColumnName = "Column17";
            clsColumnInfo17.ColumnWidth = 0;
            clsColumnInfo17.Enabled = false;
            clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo17.HeadText = "颜色";
            clsColumnInfo17.ReadOnly = false;
            clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo18.BackColor = System.Drawing.Color.White;
            clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo18.ColumnIndex = 17;
            clsColumnInfo18.ColumnName = "Column18";
            clsColumnInfo18.ColumnWidth = 0;
            clsColumnInfo18.Enabled = false;
            clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo18.HeadText = "用法ID";
            clsColumnInfo18.ReadOnly = true;
            clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo19.BackColor = System.Drawing.Color.White;
            clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo19.ColumnIndex = 18;
            clsColumnInfo19.ColumnName = "Column19";
            clsColumnInfo19.ColumnWidth = 0;
            clsColumnInfo19.Enabled = false;
            clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo19.HeadText = "频率ID";
            clsColumnInfo19.ReadOnly = true;
            clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo20.BackColor = System.Drawing.Color.White;
            clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo20.ColumnIndex = 19;
            clsColumnInfo20.ColumnName = "Column20";
            clsColumnInfo20.ColumnWidth = 0;
            clsColumnInfo20.Enabled = false;
            clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo20.HeadText = "剂量";
            clsColumnInfo20.ReadOnly = true;
            clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo21.BackColor = System.Drawing.Color.White;
            clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo21.ColumnIndex = 20;
            clsColumnInfo21.ColumnName = "Column21";
            clsColumnInfo21.ColumnWidth = 0;
            clsColumnInfo21.Enabled = false;
            clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo21.HeadText = "天数";
            clsColumnInfo21.ReadOnly = true;
            clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo22.BackColor = System.Drawing.Color.White;
            clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo22.ColumnIndex = 21;
            clsColumnInfo22.ColumnName = "Column22";
            clsColumnInfo22.ColumnWidth = 0;
            clsColumnInfo22.Enabled = false;
            clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo22.HeadText = "剂量单位";
            clsColumnInfo22.ReadOnly = true;
            clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo23.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo23.BackColor = System.Drawing.Color.White;
            clsColumnInfo23.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo23.ColumnIndex = 22;
            clsColumnInfo23.ColumnName = "Column23";
            clsColumnInfo23.ColumnWidth = 0;
            clsColumnInfo23.Enabled = false;
            clsColumnInfo23.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo23.HeadText = "申请单ID";
            clsColumnInfo23.ReadOnly = true;
            clsColumnInfo23.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo24.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo24.BackColor = System.Drawing.Color.White;
            clsColumnInfo24.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo24.ColumnIndex = 23;
            clsColumnInfo24.ColumnName = "Column24";
            clsColumnInfo24.ColumnWidth = 60;
            clsColumnInfo24.Enabled = false;
            clsColumnInfo24.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo24.HeadText = "自付";
            clsColumnInfo24.ReadOnly = true;
            clsColumnInfo24.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo25.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo25.BackColor = System.Drawing.Color.White;
            clsColumnInfo25.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo25.ColumnIndex = 24;
            clsColumnInfo25.ColumnName = "Column25";
            clsColumnInfo25.ColumnWidth = 0;
            clsColumnInfo25.Enabled = false;
            clsColumnInfo25.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo25.HeadText = "皮试";
            clsColumnInfo25.ReadOnly = true;
            clsColumnInfo25.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo26.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo26.BackColor = System.Drawing.Color.White;
            clsColumnInfo26.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo26.ColumnIndex = 25;
            clsColumnInfo26.ColumnName = "Column26";
            clsColumnInfo26.ColumnWidth = 0;
            clsColumnInfo26.Enabled = false;
            clsColumnInfo26.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo26.HeadText = "详细用法";
            clsColumnInfo26.ReadOnly = true;
            clsColumnInfo26.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo27.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo27.BackColor = System.Drawing.Color.White;
            clsColumnInfo27.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo27.ColumnIndex = 26;
            clsColumnInfo27.ColumnName = "Column27";
            clsColumnInfo27.ColumnWidth = 0;
            clsColumnInfo27.Enabled = false;
            clsColumnInfo27.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo27.HeadText = "处方号";
            clsColumnInfo27.ReadOnly = true;
            clsColumnInfo27.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo28.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo28.BackColor = System.Drawing.Color.White;
            clsColumnInfo28.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo28.ColumnIndex = 27;
            clsColumnInfo28.ColumnName = "Column28";
            clsColumnInfo28.ColumnWidth = 0;
            clsColumnInfo28.Enabled = false;
            clsColumnInfo28.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo28.HeadText = "关联项目ID";
            clsColumnInfo28.ReadOnly = true;
            clsColumnInfo28.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo29.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo29.BackColor = System.Drawing.Color.White;
            clsColumnInfo29.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo29.ColumnIndex = 28;
            clsColumnInfo29.ColumnName = "Column29";
            clsColumnInfo29.ColumnWidth = 0;
            clsColumnInfo29.Enabled = false;
            clsColumnInfo29.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo29.HeadText = "项目带项目基数";
            clsColumnInfo29.ReadOnly = true;
            clsColumnInfo29.TextFont = new System.Drawing.Font("宋体", 11F);
            clsColumnInfo30.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo30.BackColor = System.Drawing.Color.White;
            clsColumnInfo30.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo30.ColumnIndex = 29;
            clsColumnInfo30.ColumnName = "Column31";
            clsColumnInfo30.ColumnWidth = 0;
            clsColumnInfo30.Enabled = false;
            clsColumnInfo30.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo30.HeadText = "用法项目ID";
            clsColumnInfo30.ReadOnly = true;
            clsColumnInfo30.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo31.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo31.BackColor = System.Drawing.Color.White;
            clsColumnInfo31.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo31.ColumnIndex = 30;
            clsColumnInfo31.ColumnName = "Column32";
            clsColumnInfo31.ColumnWidth = 0;
            clsColumnInfo31.Enabled = false;
            clsColumnInfo31.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo31.HeadText = "用法带出项目基数";
            clsColumnInfo31.ReadOnly = true;
            clsColumnInfo31.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo32.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo32.BackColor = System.Drawing.Color.White;
            clsColumnInfo32.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo32.ColumnIndex = 31;
            clsColumnInfo32.ColumnName = "Column33";
            clsColumnInfo32.ColumnWidth = 0;
            clsColumnInfo32.Enabled = false;
            clsColumnInfo32.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo32.HeadText = "科备药标志";
            clsColumnInfo32.ReadOnly = true;
            clsColumnInfo32.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo33.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo33.BackColor = System.Drawing.Color.White;
            clsColumnInfo33.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo33.ColumnIndex = 32;
            clsColumnInfo33.ColumnName = "Column34";
            clsColumnInfo33.ColumnWidth = 0;
            clsColumnInfo33.Enabled = false;
            clsColumnInfo33.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo33.HeadText = "诊疗项目ID";
            clsColumnInfo33.ReadOnly = true;
            clsColumnInfo33.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo34.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo34.BackColor = System.Drawing.Color.White;
            clsColumnInfo34.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo34.ColumnIndex = 33;
            clsColumnInfo34.ColumnName = "Column35";
            clsColumnInfo34.ColumnWidth = 0;
            clsColumnInfo34.Enabled = false;
            clsColumnInfo34.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo34.HeadText = "诊疗项目基数";
            clsColumnInfo34.ReadOnly = true;
            clsColumnInfo34.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo35.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo35.BackColor = System.Drawing.Color.White;
            clsColumnInfo35.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo35.ColumnIndex = 34;
            clsColumnInfo35.ColumnName = "colYbcode";
            clsColumnInfo35.ColumnWidth = 0;
            clsColumnInfo35.Enabled = false;
            clsColumnInfo35.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo35.HeadText = "医保码";
            clsColumnInfo35.ReadOnly = true;
            clsColumnInfo35.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo36.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo36.BackColor = System.Drawing.Color.White;
            clsColumnInfo36.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo36.ColumnIndex = 35;
            clsColumnInfo36.ColumnName = "Column30";
            clsColumnInfo36.ColumnWidth = 0;
            clsColumnInfo36.Enabled = false;
            clsColumnInfo36.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo36.HeadText = "默认带出标志";
            clsColumnInfo36.ReadOnly = true;
            clsColumnInfo36.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo37.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo37.BackColor = System.Drawing.Color.White;
            clsColumnInfo37.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo37.ColumnIndex = 36;
            clsColumnInfo37.ColumnName = "Column36";
            clsColumnInfo37.ColumnWidth = 75;
            clsColumnInfo37.Enabled = true;
            clsColumnInfo37.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo37.HeadText = "大小单位标识";
            clsColumnInfo37.ReadOnly = false;
            clsColumnInfo37.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo38.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo38.BackColor = System.Drawing.Color.White;
            clsColumnInfo38.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo38.ColumnIndex = 37;
            clsColumnInfo38.ColumnName = "Column37";
            clsColumnInfo38.ColumnWidth = 80;
            clsColumnInfo38.Enabled = true;
            clsColumnInfo38.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo38.HeadText = "让利金额";
            clsColumnInfo38.ReadOnly = false;
            clsColumnInfo38.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo39.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo39.BackColor = System.Drawing.Color.White;
            clsColumnInfo39.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo39.ColumnIndex = 38;
            clsColumnInfo39.ColumnName = "Column38";
            clsColumnInfo39.ColumnWidth = 0;
            clsColumnInfo39.Enabled = true;
            clsColumnInfo39.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo39.HeadText = "让利单价";
            clsColumnInfo39.ReadOnly = false;
            clsColumnInfo39.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo1);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo2);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo3);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo4);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo5);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo6);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo7);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo8);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo9);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo10);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo11);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo12);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo13);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo14);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo15);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo16);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo17);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo18);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo19);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo20);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo21);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo22);
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
            this.ctlDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDataGrid1.Font = new System.Drawing.Font("宋体", 11F);
            this.ctlDataGrid1.FullRowSelect = false;
            this.ctlDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGrid1.MultiSelect = true;
            this.ctlDataGrid1.Name = "ctlDataGrid1";
            this.ctlDataGrid1.ReadOnly = false;
            this.ctlDataGrid1.RowHeadersVisible = false;
            this.ctlDataGrid1.RowHeaderWidth = 35;
            this.ctlDataGrid1.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.ctlDataGrid1.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid1.Size = new System.Drawing.Size(840, 251);
            this.ctlDataGrid1.TabIndex = 0;
            this.ctlDataGrid1.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid1_m_evtCurrentCellChanged);
            this.ctlDataGrid1.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.ctlDataGrid1_m_evtDataGridTextBoxKeyDown);
            this.ctlDataGrid1.Enter += new System.EventHandler(this.ctlDataGrid1_Enter);
            this.ctlDataGrid1.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDataGrid1_m_evtDataGridKeyDown);
            this.ctlDataGrid1.Leave += new System.EventHandler(this.ctlDataGrid1_Leave);
            // 
            // plRecipe
            // 
            this.plRecipe.AutoScroll = true;
            this.plRecipe.BackColor = System.Drawing.Color.White;
            this.plRecipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plRecipe.Controls.Add(this.panel12);
            this.plRecipe.Controls.Add(this.panel13);
            this.plRecipe.Dock = System.Windows.Forms.DockStyle.Right;
            this.plRecipe.Location = new System.Drawing.Point(840, 0);
            this.plRecipe.Name = "plRecipe";
            this.plRecipe.Size = new System.Drawing.Size(0, 251);
            this.plRecipe.TabIndex = 41;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label20);
            this.panel12.Controls.Add(this.lvRecipe);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 28);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(0, 223);
            this.panel12.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label20.Location = new System.Drawing.Point(0, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(296, 16);
            this.label20.TabIndex = 3;
            this.label20.Text = "序号  名称                     单价    数量      金额   自付  自付金额";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Visible = false;
            // 
            // lvRecipe
            // 
            this.lvRecipe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvRecipe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader49,
            this.columnHeader52,
            this.columnHeader53});
            this.lvRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRecipe.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvRecipe.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lvRecipe.FullRowSelect = true;
            this.lvRecipe.GridLines = true;
            this.lvRecipe.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvRecipe.Location = new System.Drawing.Point(0, 0);
            this.lvRecipe.MultiSelect = false;
            this.lvRecipe.Name = "lvRecipe";
            this.lvRecipe.Size = new System.Drawing.Size(0, 223);
            this.lvRecipe.TabIndex = 2;
            this.lvRecipe.UseCompatibleStateImageBehavior = false;
            this.lvRecipe.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "项目名称";
            this.columnHeader44.Width = 175;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "诊疗项目名称";
            this.columnHeader45.Width = 129;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "数量";
            this.columnHeader46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader46.Width = 55;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "规格";
            this.columnHeader47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader47.Width = 56;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "单位";
            this.columnHeader49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader49.Width = 54;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "单价";
            this.columnHeader52.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader52.Width = 51;
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "金额";
            this.columnHeader53.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader53.Width = 74;
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
            this.label28.Text = "医生处方";
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
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 251);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(840, 1);
            this.splitter1.TabIndex = 34;
            this.splitter1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader13,
            this.columnHeader2,
            this.columnHeader12,
            this.columnHeader11,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader6});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Font = new System.Drawing.Font("宋体", 12F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 252);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(840, 168);
            this.listView1.TabIndex = 31;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.Leave += new System.EventHandler(this.listView1_Leave);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "查询码";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "新编码";
            this.columnHeader13.Width = 63;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "药品名称";
            this.columnHeader2.Width = 173;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "英文名";
            this.columnHeader12.Width = 84;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "类型";
            this.columnHeader11.Width = 76;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "规格";
            this.columnHeader3.Width = 124;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "单位";
            this.columnHeader4.Width = 47;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单价";
            this.columnHeader5.Width = 68;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "比例";
            this.columnHeader1.Width = 51;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 51;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
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
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            this.printDocument2.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument2_EndPrint);
            this.printDocument2.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument2_BeginPrint);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(8, 580);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(840, 48);
            this.label5.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(856, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 620);
            this.label6.TabIndex = 31;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.cboProxyBoilMed.Location = new System.Drawing.Point(204, 11);
            this.cboProxyBoilMed.Name = "cboProxyBoilMed";
            this.cboProxyBoilMed.Size = new System.Drawing.Size(79, 22);
            this.cboProxyBoilMed.TabIndex = 131;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.ForeColor = System.Drawing.Color.Blue;
            this.label32.Location = new System.Drawing.Point(130, 15);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(86, 16);
            this.label32.TabIndex = 130;
            this.label32.Text = "院外代送:";
            // 
            // frmOPCharge
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1028, 633);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_PatientBasicInfo);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmOPCharge";
            this.Text = "门诊收费";
            this.Load += new System.EventHandler(this.frmOPCharge_Load);
            this.Activated += new System.EventHandler(this.frmOPCharge_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOPCharge_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOPCharge_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOPCharge_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).EndInit();
            this.plRecipe.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_OPCharge();
            objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// 用户输入查询。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlDataGrid1_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            //替半角"'"号，防止拼SQL时出错。
            string m_strText = e.m_strText.Replace("'", "’");
            if (e.KeyCode != Keys.Down && e.KeyCode != Keys.Up)
            {
                rowNO = e.m_intRowNumber;
            }

            if (e.m_intColNumber == 1 && (m_strText.Trim() != "0" || m_strText.Trim() != ""))
            {
                this.IsSave = false;
            }
            //按下回车时查询
            if (e.KeyCode == Keys.Enter)
            {
                if (m_strText.Trim() == "")
                {
                    return;
                }
                if (e.m_intColNumber == 0)
                {
                    //在这里添加查询代码,如果以“\”开头的就代表查询协定处方
                    if (m_strText.StartsWith("\\"))
                    {
                        ((clsCtl_OPCharge)this.objController).m_mthFindAccordRecipe(m_strText.Substring(1, m_strText.Length - 1));
                    }
                    else
                    {
                        //如果“？”开头的就是查询常用药
                        if (m_strText.StartsWith("?"))
                        {
                            ((clsCtl_OPCharge)this.objController).m_mthFindItemByUsage(m_strText.Substring(1, m_strText.Length - 1));
                        }
                        else
                        {
                            //正常的查找收费项目
                            double dbOK = -1;
                            try
                            {
                                dbOK = Convert.ToDouble(m_strText.Replace("/", ""));
                            }
                            catch
                            {

                            }
                            if (dbOK > -1)
                            {
                                this.m_mthFindMedicineByID("itemcode_vchr", m_strText);
                            }
                            else
                            {
                                this.m_mthFindMedicineByID(m_cmbFind.Tag.ToString().Trim(), m_strText);
                            }
                        }

                    }
                }
                //第二列输入的是项目数量
                if (e.m_intColNumber == 1)
                {
                    this.IsSave = true;
                    this.IsSendTabKey = true;
                    //在这里添加剂量输入代码
                    this.m_mthDosageChange(ctlDataGrid1[e.m_intRowNumber, 10].ToString().Trim(),
                        ctlDataGrid1[e.m_intRowNumber, 6].ToString().Trim(), ctlDataGrid1[e.m_intRowNumber, 8].ToString().Trim(), m_strText,
                        e.m_intRowNumber);
                    //	

                    ((clsCtl_OPCharge)this.objController).m_mthAdjustReItemNum(this.ctlDataGrid1[e.m_intRowNumber, ResubitemCol].ToString(), this.ctlDataGrid1[e.m_intRowNumber, ResubnumsCol].ToString(), m_strText);
                }
                //根据收费项目的定义，如果是自定义价格的可以跳到第七列更改价格
                if (e.m_intColNumber == 6)
                {
                    //在这里添加格价输入代码
                    this.m_mthDosageChange(ctlDataGrid1[e.m_intRowNumber, 10].ToString().Trim(),
                        m_strText, ctlDataGrid1[e.m_intRowNumber, 8].ToString().Trim(), ctlDataGrid1[e.m_intRowNumber, 1].ToString().Trim(), e.m_intRowNumber);

                }
                //更改比例，如果系统配置表设置了可以更改收费项目的比例，就要在第十四例来改变比例。
                if (e.m_intColNumber == 13)
                {
                    ((clsCtl_OPCharge)this.objController).m_mthChangeDiscount(m_strText, e.m_intRowNumber);
                }
                return;
            }
            //有时在DataGrid按快捷键，窗口接收不了。经测试只是针对个别键，这可能FCL有关。
            //所以以下键时把e对象传递到窗口处理。
            if (e.KeyCode == Keys.F4 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F12)
            {
                this.frmOPCharge_KeyDown(null, e);
            }

        }
        /// <summary>
        /// 更改剂量
        /// </summary>
        /// <param name="strChargeID">项目ID</param>
        /// <param name="decPrice">价格</param>
        /// <param name="ChargeTypeID">分类ID</param>
        /// <param name="decDosage">剂量</param>
        /// <param name="rowNo">行号</param>
        private void m_mthDosageChange(string strChargeID, string decPrice, string ChargeTypeID, string decDosage, int rowNo)
        {
            this.IsSave = true;//标志已经处理
            if (strChargeID == "")
            {
                return;//如果项目ID为空就返回
            }

            ((clsCtl_OPCharge)this.objController).m_mthDosageChange(strChargeID, decPrice, ChargeTypeID, decDosage, rowNo);


        }
        private void btExit_Click(object sender, System.EventArgs e)
        {

            this.Close();
        }

        private void m_cmbFind_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (m_cmbFind.SelectedIndex)
            {
                case 0://项目编码
                    m_cmbFind.Tag = "ITEMCODE_VCHR";
                    cmbFindAccordRecipe.Tag = "USERCODE_CHR";
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                    break;
                case 1://项目名称
                    m_cmbFind.Tag = "ITEMNAME_VCHR";
                    cmbFindAccordRecipe.Tag = "RECIPENAME_CHR";
                    if (this.ctlDataGrid1.CurrentCell.ColumnNumber == 0 && this.ActiveControl.GetType().Name == "ctlDataGrid")
                    {
                        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
                    }
                    break;
                case 2://项目拼音
                    m_cmbFind.Tag = "ITEMPYCODE_CHR";
                    cmbFindAccordRecipe.Tag = "PYCODE_CHR";
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                    break;
                case 3://项目五笔
                    m_cmbFind.Tag = "ITEMWBCODE_CHR";
                    cmbFindAccordRecipe.Tag = "WBCODE_CHR";
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                    break;
                case 4://英文名
                    m_cmbFind.Tag = "ITEMENGNAME_VCHR";
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                    break;
                case 5://旧码
                    m_cmbFind.Tag = "ITEMOPCODE_CHR";
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

            ((clsCtl_OPCharge)this.objController).m_mthRecipeChanged();
        }
        #region 初始化DataGrid
        /// <summary>
        /// 控制DataGrid的Cell的长度和只能输入数字，和输入法的控制。
        /// 输入控制业务需求：当选择“名称”查询收费项目时，记录当前选择的输入法，以后
        /// 每跳到这个格时，自动恢复输入法。
        /// </summary>
        private void intDataGrid()
        {
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 10;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBox_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.MaxLength = 7;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress2);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[13]).DataGridTextBoxColumn.TextBox.Leave += new EventHandler(TextBoxDiscount_Leave);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[13]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBoxDiscount_Enter);
            ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[13]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            //把datagrid的第一和第二列转换成空格
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(1);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(13);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(0);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(6);
        }
        #endregion

        /// <summary>
        /// 发票号检查失败直接退出标志
        /// </summary>
        private bool noopen = false;
        private void frmOPCharge_Load(object sender, System.EventArgs e)
        {
            #region 读出发票号
            bool b = false;
            string invono = ((clsCtl_OPCharge)this.objController).m_strReadInvoiceNO();
            frmOPInvoiceinput fo = new frmOPInvoiceinput();
            fo.txtInvono.Text = invono;
            this.Visible = false;
            this.timer.Enabled = false;
            if (fo.ShowDialog() == DialogResult.Cancel)
            {
                b = true;
            }
            else
            {
                this.m_txtInvoiceNO.Text = fo.txtInvono.Text.Trim();
                if (((clsCtl_OPCharge)this.objController).m_mthInvoiceExpression() || ((clsCtl_OPCharge)this.objController).m_mthCheckInvoice() || !((clsCtl_OPCharge)this.objController).m_blnCheckInvoice())
                {
                    b = true;
                }
            }

            if (b)
            {
                noopen = true;
                this.timer.Enabled = true;
                this.timer.Interval = 3000;
                return;
            }
            else
            {
                this.timer.Enabled = true;
                this.timer.Interval = 1000;
                this.Cursor = Cursors.WaitCursor;
            }
            #endregion
            //读取是否合并门、急诊药房
            IsDetachWMedStore = ((clsCtl_OPCharge)this.objController).m_strReadXML("register", "IsDetachWMedStore", "AnyOne") != "" ? int.Parse(((clsCtl_OPCharge)this.objController).m_strReadXML("register", "IsDetachWMedStore", "AnyOne")) : 0;
            strEmergencyMedStoreTWindow = ((clsCtl_OPCharge)this.objController).m_strReadXMLAttr("register", "EmergencyMedStoreWindow", "AnyOne", "TreatWindowID");
            strEmergencyMedStoreSWindow = ((clsCtl_OPCharge)this.objController).m_strReadXMLAttr("register", "EmergencyMedStoreWindow", "AnyOne", "SendWindowID");
            strSpecialMedStoreTWindow = ((clsCtl_OPCharge)this.objController).m_strReadXMLAttr("register", "SpecialMedStoreWindow", "AnyOne", "TreatWindowID");
            strSpecialMedStoreSWindow = ((clsCtl_OPCharge)this.objController).m_strReadXMLAttr("register", "SpecialMedStoreWindow", "AnyOne", "SendWindowID");
            intSpecialPatientAge = ((clsCtl_OPCharge)this.objController).m_strReadXMLAttr("register", "SpecialMedStoreWindow", "AnyOne", "Age") != "" ? Convert.ToInt32(((clsCtl_OPCharge)this.objController).m_strReadXMLAttr("register", "SpecialMedStoreWindow", "AnyOne", "Age")) : 60;
            strEmergencyDeptID = ((clsCtl_OPCharge)this.objController).m_strReadXML("register", "EmergencyDeptID", "AnyOne");
            intChargeWindowType = ((clsCtl_OPCharge)this.objController).m_strReadXML("register", "ChargeWindowType", "AnyOne") != "" ? Convert.ToInt32(((clsCtl_OPCharge)this.objController).m_strReadXML("register", "ChargeWindowType", "AnyOne")) : 0;
            if (IsDetachWMedStore == 0)
            {
                if (intChargeWindowType == 1)
                {
                    this.Text = "急诊收费";
                }
            }
            ((clsCtl_OPCharge)this.objController).m_mthGetWindowName();
            ((clsCtl_OPCharge)this.objController).m_mthLoadCat();//读出项目分类
            ((clsCtl_OPCharge)this.objController).m_mthGetChooseHospitalInfo();//读出收费选择医院
            ((clsCtl_OPCharge)this.objController).m_mthGetsysparm();
            ((clsCtl_OPCharge)this.objController).m_strReadMedwinID(); //读出药房窗口ID
            ((clsCtl_OPCharge)this.objController).CheckCMachine();

            this.m_cmbFind.SelectedIndex = 2;
            this.m_cmbPayMode.SelectedIndex = 0;
            this.m_cmbRecipeType.SelectedIndex = 0;
            this.numericUpDown1.Tag = "";
            this.cmbFindAccordRecipe.SelectedIndex = 1;
            this.intDataGrid();
            m_mthHandleDataGridInput();
            this.m_PatientBasicInfo.HospitalName = ((clsCtl_OPCharge)this.objController).m_objComInfo.m_strGetHospitalTitle();
            ((clsCtl_OPCharge)this.objController).m_mthCreatCalObj();
            this.m_PatientBasicInfo.txtCardID.Select();
            this.m_PatientBasicInfo.Datetype = "发票日期:";
            this.m_PatientBasicInfo.txtCardID.KeyDown += new KeyEventHandler(this.m_objTextCardID_KeyDown);
            QueueSystemClient.frmDiagClientMain.PatientCalled += new QueueSystemClient.PatientCalledEventHandler(frmDiagClientMain_PatientCalled);

            int intDoubleLCD = clsPublic.m_intGetSysParm("0076");
            if (intDoubleLCD == 1)
            {
                this.m_objOPChargeRight = new frmOPChargeRight();
                m_objOPChargeRight.IsShowAmount = false;
                m_blnDoubleScreen = true;
                m_objOPChargeRight.m_objFormViewer = this;
                this.m_PatientBasicInfo.txtCardID.TextChanged += new EventHandler(txtCardID_TextChanged);
                m_objOPChargeRight.m_strHosTitle = this.objController.m_objComInfo.m_strGetHospitalTitle();
                m_objOPChargeRight.Show();
            }
            this.m_PatientBasicInfo.txtCardID.MaxLength = 18;
        }
        /// <summary>
        /// 获取第二屏是否开启状态
        /// </summary>
        /// <returns></returns>
        public bool m_blnGetChargeRightOpen()
        {
            bool blnRet = true;
            if (this.m_objOPChargeRight != null)
            {
                if (this.m_objOPChargeRight.IsDisposed)
                {
                    blnRet = false;
                }
            }
            else
            {
                blnRet = false;
            }
            return blnRet;
        }
        public void txtCardID_TextChanged(object sender, System.EventArgs e)
        {
            if (this.m_PatientBasicInfo.txtCardID.Text.Trim() == string.Empty)
            {
                this.m_objOPChargeRight.timer1.Enabled = true;
            }
            else
            {
                this.m_objOPChargeRight.timer1.Enabled = false;
            }
        }
        public void m_objTextCardID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    ((clsCtl_OPCharge)this.objController).m_mthSaveMedicineSend();
            //}

            if (m_blnGetChargeRightOpen())
            {
                if (this.m_PatientBasicInfo.txtPatient.Text.Trim() != string.Empty)
                {
                    this.m_objOPChargeRight.label2.Text = "您好，" + this.m_PatientBasicInfo.txtPatient.Text.Trim();
                    this.m_objOPChargeRight.label3.Text = "请稍候... ...";
                    this.m_objOPChargeRight.label1.Text = string.Empty;
                    this.m_objOPChargeRight.label4.Text = "";
                    this.m_objOPChargeRight.label5.Text = "";
                    this.m_objOPChargeRight.label6.Text = "";
                    this.m_objOPChargeRight.label7.Text = "";
                    this.m_objOPChargeRight.label7.Visible = false;
                    m_objOPChargeRight.IsShowAmount = false;
                }
            }
        }
        private delegate void v1(string id);
        public void frmDiagClientMain_PatientCalled(object sender, QueueSystemClient.PatientCalledEventArgs e)
        {
            LEDArgs = e;
            this.m_PatientBasicInfo.Invoke(new v1(this.m_PatientBasicInfo.m_mthGetPatientInfoByCard), e.Patient.m_strPatientCardNO);

            #region 直接显示
            //int RecipeNums = 0;
            //decimal TotalMny = 0;
            //decimal SbMny = 0;            
            ////e.ShowChargeInfo(2, 2.4);
            //((clsCtl_OPCharge)this.objController).m_mthGetPatientRecipeFee(e.PatientID, e.PatientCardNO, false, out RecipeNums, out TotalMny, out SbMny);

            //if (RecipeNums > 0)
            //{
            //    QueueSystemClient.PatientChargedInfo chargeInfo = new QueueSystemClient.PatientChargedInfo();
            //    e.exchangeSystem = QueueSystemClient.ExchangeSystem.ChargeSystem;
            //    chargeInfo.PrescriptionCount = RecipeNums;
            //    chargeInfo.Payment = TotalMny;
            //    e.ResData = chargeInfo;
            //}    
            #endregion
        }

        frmDebtMessage frmDM;
        bool blnIfDMShow = false;

        private void frmDebtMessage_recipeDoubleClick(object sender, string strRecipeNum)
        {
            this.txtLoadRecipeNO.Text = strRecipeNum;
            this.txtLoadRecipeNO.Focus();
            SendKeys.SendWait("{ENTER}");
        }

        private void m_PatientBasicInfo_PatientChanged(object sender, string RegID)
        {
            this.m_PatientBasicInfo.txtType.Enabled = true;
            this.m_PatientBasicInfo.txtRegisterDept.Enabled = true;
            this.m_PatientBasicInfo.txtRegisterDoctor.Enabled = true;
            this.m_cmbRecipeType.Enabled = true;
            this.ctlDataGrid1.Enabled = true;
            this.objYBCal = null;
            this.YBVal = 0;
            this.TolVal = 0;
            this.YBFlag = false;
            this.YBShownum = 0;
            //处方数
            int RecipeNums = 0;
            ((clsCtl_OPCharge)this.objController).EmpInputMode = false;

            this.txtLoadRecipeNO.m_mthClearText();
            //在这时添加读发票的代码
            ((clsCtl_OPCharge)this.objController).m_mthCreatCalObj();

            //只要病人变更就关闭之前的欠费提醒窗口
            if (blnIfDMShow == true && !frmDM.IsDisposed)
            {
                frmDM.Close();
            }
            //VIP病人显示欠费提醒
            DataTable dtIfVip = new DataTable();
            clsDcl_OPCharge objOPDcl = new clsDcl_OPCharge();
            objOPDcl.m_lngGetIfVipByPatientID(this.m_PatientBasicInfo.PatientID, ref dtIfVip);
            if (dtIfVip.Rows.Count > 0 && dtIfVip.Rows[0][0].ToString() == "1")
            {
                DataTable dtResult = new DataTable();
                clsDcl_DoctorWorkstation objDcl = new clsDcl_DoctorWorkstation();
                objDcl.m_lngGetVipDebtByCard(this.m_PatientBasicInfo.PatientCardID, out dtResult);
                if (dtResult.Rows.Count != 0)
                {
                    frmDM = new frmDebtMessage(dtResult);
                    frmDM.recipeDoubleClick += new frmDebtMessage.recipeDoubleClickEventHandler(frmDebtMessage_recipeDoubleClick);
                    frmDM.Show();
                    blnIfDMShow = true;
                }
            }

            this.btOK.Enabled = false;
            //新病人开处方时产生这个事件
            if (chkLoadData.Checked)
            {
                if (!((clsCtl_OPCharge)this.objController).PEWorkStationFlag)
                {
                    decimal TotalMny = 0;
                    decimal SbMny = 0;

                    ((clsCtl_OPCharge)this.objController).m_mthGetPatientRecipeFee(this.m_PatientBasicInfo.PatientID, this.m_PatientBasicInfo.PatientCardID, true, out RecipeNums, out TotalMny, out SbMny);

                    if (RecipeNums > 1)
                    {
                        if (LEDArgs != null)
                        {
                            LEDArgs.ShowChargeInfo(Convert.ToUInt32(RecipeNums), TotalMny);
                            LEDArgs = null;
                        }

                        string AcctMny = ((TotalMny - SbMny) == 0 ? "" : Convert.ToString(TotalMny - SbMny));

                        frmShowpatallrecinfo f = new frmShowpatallrecinfo(RecipeNums.ToString(), AcctMny, (SbMny == 0 ? "" : SbMny.ToString()), TotalMny.ToString());
                        if (f.ShowDialog() != DialogResult.OK)
                        {
                            this.m_mthClearAlldata();
                            this.m_PatientBasicInfo.txtCardID.Focus();
                            return;
                        }
                    }

                    ((clsCtl_OPCharge)this.objController).m_mthFindMaxRecipeNoByPatientID();
                }
            }

            if (chkDefaultItem.Checked)
            {
                ((clsCtl_OPCharge)this.objController).m_mthGetDefaultItem();
            }
            this.btOK.Enabled = true;

            if (this.m_cmbRecipeType.Enabled)
            {
                this.m_cmbRecipeType.Focus();
            }
            else
            {
                this.m_cmbPayMode.Focus();
            }

            if (this.m_PatientBasicInfo.DoctorID.Trim() == "")
            {
                this.m_PatientBasicInfo.txtRegisterDoctor.Focus();
            }
            else if (this.m_PatientBasicInfo.lbeDocType.Text == "")
            {
                ((clsCtl_OPCharge)this.objController).m_mthShowExpert(this.m_PatientBasicInfo.DoctorID);
            }

            ((clsCtl_OPCharge)this.objController).m_mthSetcardtype();
            this.txtIDcard.Text = this.m_PatientBasicInfo.IDcard;

            ((clsCtl_OPCharge)this.objController).m_mthCheckYBPayType();

            if (RecipeNums == 1 && LEDArgs != null)
            {
                string ChargeUpCost, PersonCost, TotalCost;
                ((clsCtl_OPCharge)this.objController).objCalPatientCharge.m_mthGetchargeinfo(out ChargeUpCost, out PersonCost, out TotalCost);
                LEDArgs.ShowChargeInfo(Convert.ToUInt32(RecipeNums), clsMZPublic.ConvertObjToDecimal(TotalCost));
                LEDArgs = null;
            }

            //调体检收费项目            
            ((clsCtl_OPCharge)this.objController).m_mthLoadPEItem();
        }

        public void ctlDataGrid1_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            try
            {
                #region 处理用户输入剂量没有控回车的情况
                this.IsSendTabKey = IsSave;
                if (!IsSave)
                {
                    string strItemID = ctlDataGrid1[rowNO, 10].ToString().Trim();
                    string price = ctlDataGrid1[rowNO, 6].ToString().Trim();
                    string strCatID = ctlDataGrid1[rowNO, 8].ToString().Trim();
                    string strCount = ctlDataGrid1[rowNO, 1].ToString().Trim();
                    this.m_mthDosageChange(strItemID, price, strCatID, strCount, rowNO);
                }
                #endregion
                int row = ctlDataGrid1.CurrentCell.RowNumber;
                if (this.ctlDataGrid1[row, 14].ToString().Trim() != "")
                {
                    this.ctlDataGrid1[row, 13] = this.ctlDataGrid1[row, 14].ToString() + "%";
                    this.ctlDataGrid1[row, 23] = clsConvertToDecimal.m_mthConvertObjToDecimal(ctlDataGrid1[row, 14]) / 100 * clsConvertToDecimal.m_mthConvertObjToDecimal(ctlDataGrid1[row, 7]);
                }
                int col = ctlDataGrid1.CurrentCell.ColumnNumber;
                if (col != 0)
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                }
                //设置前背景色
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[col]).DataGridTextBoxColumn.TextBox.BackColor = Color.FromArgb(222, 239, 165);	//Color.SteelBlue;			
                string strType = ctlDataGrid1[row, 8].ToString().Trim();
                bool isCouPrice = ctlDataGrid1[row, 11].ToString().Trim() == "0";
                #region 控制列跳转
                if (((clsCtl_OPCharge)this.objController).m_mthIsMedicine(strType) || isCouPrice)//如果是药品或者不是自定义价格的就直接跟到下一行
                {
                    if (((clsCtl_OPCharge)this.objController).IsDiscount)
                    {
                        if (ctlDataGrid1.CurrentCell.ColumnNumber > 1 && ctlDataGrid1.CurrentCell.ColumnNumber < 13)
                        {
                            ctlDataGrid1.CurrentCell = new DataGridCell(row, 13);
                        }
                        if (ctlDataGrid1.CurrentCell.ColumnNumber > 13)
                        {
                            ctlDataGrid1.CurrentCell = new DataGridCell(row + 1, 0);
                        }
                    }
                    else
                    {
                        if (ctlDataGrid1.CurrentCell.ColumnNumber > 1)
                        {
                            ctlDataGrid1.CurrentCell = new DataGridCell(row + 1, 0);
                        }
                    }
                }
                else//跳到单价
                {
                    if (((clsCtl_OPCharge)this.objController).IsDiscount)
                    {
                        if (ctlDataGrid1.CurrentCell.ColumnNumber > 1 && ctlDataGrid1.CurrentCell.ColumnNumber < 6)
                        {
                            ctlDataGrid1.CurrentCell = new DataGridCell(row, 6);
                        }
                        if (ctlDataGrid1.CurrentCell.ColumnNumber > 6 && ctlDataGrid1.CurrentCell.ColumnNumber < 13)
                        {
                            ctlDataGrid1.CurrentCell = new DataGridCell(row, 13);
                        }
                        if (ctlDataGrid1.CurrentCell.ColumnNumber > 13)
                        {
                            ctlDataGrid1.CurrentCell = new DataGridCell(row + 1, 0);
                        }
                    }
                    else
                    {
                        if (ctlDataGrid1.CurrentCell.ColumnNumber > 1 && ctlDataGrid1.CurrentCell.ColumnNumber < 6)
                        {
                            ctlDataGrid1.CurrentCell = new DataGridCell(row, 6);
                        }
                        if (ctlDataGrid1.CurrentCell.ColumnNumber > 6)
                        {
                            ctlDataGrid1.CurrentCell = new DataGridCell(row + 1, 0);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //在这里添加计价的代码
        }
        /// <summary>
        /// 查找药品
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="ID"></param>
        private void m_mthFindMedicineByID(string strType, string ID)
        {
            ((clsCtl_OPCharge)this.objController).m_mthFindMedicineByID(strType, ID);
        }

        private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.listView1_DoubleClick(null, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                listView1.Height = 0;
                listView1.Visible = false;
                ctlDataGrid1.Select();
                ctlDataGrid1.Focus();
                ctlDataGrid1.CurrentCell = new DataGridCell(this.rowNO, 0);
                //SendKeys.SendWait("{Right}");			
            }
        }

        private void listView1_Leave(object sender, System.EventArgs e)
        {
            listView1.Height = 0;
            listView1.Visible = false;
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsCtl_OPCharge)this.objController).m_mthListViewDoubleClick();
        }


        private void btOK_Click(object sender, System.EventArgs e)
        {
            if (this.m_PatientBasicInfo.PatientID == null || this.m_PatientBasicInfo.PatientID.Trim() == "")
            {
                return;
            }
            this.totalMoney = 0;
            bool flag = false;//标志项目为空时不能结账.
            for (int i = 0; i < this.ctlDataGrid1.RowCount; i++)
            {
                if (this.ctlDataGrid1[i, 12].ToString().Trim() != "")
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                return;
            }
            if (this.m_PatientBasicInfo.DeptID.Trim() == "")
            {
                MessageBox.Show("请选择科室再结账!", "ICare");
                this.m_PatientBasicInfo.txtRegisterDept.Focus();
                return;
            }
            if (this.m_PatientBasicInfo.DoctorID.Trim() == "")
            {
                MessageBox.Show("请选择医生再结账!", "ICare");
                this.m_PatientBasicInfo.txtRegisterDoctor.Focus();
                return;
            }

            #region 代煎中药处方:收件人信息判断

            if (this.cboProxyBoilMed.SelectedIndex > 0)
            {
                clsDcl_DoctorWorkstation svc = new clsDcl_DoctorWorkstation();
                DataTable dt = svc.GetPatientContactInfo(this.m_PatientBasicInfo.PatientID.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["contactpersonfirstname_vchr"] == DBNull.Value || dr["contactpersonfirstname_vchr"].ToString().Trim() == string.Empty)
                    {
                        MessageBox.Show("外送代煎药收件人信息: 联系人姓名 不能为空，请补充。", "ICare");
                        return;
                    }
                    if (dr["mobile_chr"] == DBNull.Value || dr["mobile_chr"].ToString().Trim() == string.Empty)
                    {
                        MessageBox.Show("外送代煎药收件人信息: 联系电话 不能为空，请补充。", "ICare");
                        return;
                    }
                    if (dr["consigneeaddr"] == DBNull.Value || dr["consigneeaddr"].ToString().Trim() == string.Empty)
                    {
                        MessageBox.Show("外送代煎药收件人信息: 联系人地址 不能为空，请补充。", "ICare");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("外送代煎药收件人信息不能为空，请补充。", "ICare");
                    return;
                }

                List<string> lstChargeItemId = new List<string>();
                for (int i = 0; i < this.ctlDataGrid1.RowCount; i++)
                {
                    if (this.ctlDataGrid1[i, 3].ToString().Trim() == "中草药")
                    {
                        lstChargeItemId.Add(this.ctlDataGrid1[i, 10].ToString().Trim());
                    }
                }
                if (lstChargeItemId.Count > 0)
                {
                    if (svc.CheckRecipeSlices(lstChargeItemId) == false)
                    {
                        MessageBox.Show("处方中存在非饮片药材，不能办理外送代煎。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cboProxyBoilMed.SelectedIndex = 0;
                        //return;
                    }
                }
            }
            #endregion

            if (((clsCtl_OPCharge)this.objController).m_mthInvoiceExpression())
            {
                return;
            }
            if (((clsCtl_OPCharge)this.objController).m_mthCheckInvoice())
            {
                this.m_txtInvoiceNO.Focus();
                return;
            }
            if ((this.btSave.Tag == null || this.btSave.Tag.ToString().Trim() == "") && !((clsCtl_OPCharge)this.objController).IsChargeReceiverRec)
            {
                MessageBox.Show("系统当前设置为不能结算收款员所开处方项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.ctlDataGrid1.CurrentCell = new DataGridCell(this.ctlDataGrid1.RowCount - 1, 0);

            //费用凑整            
            if (!((clsCtl_OPCharge)this.objController).m_blnRounding())
            {
                return;
            }

            frmreckoning obj = new frmreckoning();
            obj.m_blnDiffOn = ((clsCtl_OPCharge)this.objController).intDiffPriceOn == 1;// 让利启用开关

            obj.m_mthSetParentFrom(this);
            obj.m_mthShowRecipeCount(((clsCtl_OPCharge)this.objController).RecipeCount - 1);
            bool ret = ((clsCtl_OPCharge)this.objController).m_mthGetFillDataToComboBox(obj.cmbHopital);
            if (ret)
            {
                obj.Height += 70;
                obj.panel1.Visible = true;
            }

            if (((clsCtl_OPCharge)this.objController).m_Isybcharge())
            {
                obj.btnYb.Enabled = true;
                obj.btnNewYb.Enabled = true;

            }
            else
            {
                obj.btnYb.Enabled = false;
                obj.btnNewYb.Enabled = false;
            }

            clsPatientChargeCal objPC = ((clsCtl_OPCharge)this.objController).objCalPatientCharge.m_mthGetChargeTypeDetail();
            objPC.m_strInvoiceNO = this.m_txtInvoiceNO.Text.Trim();

            if (((clsCtl_OPCharge)this.objController).IsDongGuanYBPatient)
            {
                //objPC.m_decChargeUpCost = 0;
                //objPC.m_decPersonCost = objPC.m_decTotalCost;
            }

            //if (objPC.m_decChargeUpCost != 0)
            //{
            //    obj.lbeChargeUp.Text = objPC.m_decChargeUpCost.ToString();
            //}

            if (objPC.m_decSbPay != 0)
            {
                obj.lbeChargeUp.Text = objPC.m_decSbPay.ToString();
            }
            if (objPC.m_decPersonCost != 0)
            {
                obj.lbeSelfPay.Text = objPC.m_decPersonCost.ToString();
            }
            if (objPC.m_decTotalCost != 0)
            {
                obj.lbeSumMoney.Text = objPC.m_decTotalCost.ToString();
            }
            if (obj.m_blnDiffOn)
            {
                //obj.lbeChargeUp.Text = (objPC.m_decSbPay + objPC.m_decTotalDiffCost).ToString();//药品让利总金额
                obj.lbeSumMoney.Text = (objPC.m_decTotalCost - Math.Abs(objPC.m_decTotalDiffCost)).ToString();//总金额为药品让利后的总金额
                //obj.lbeSelfPay.Text = (objPC.m_decPersonCost - objPC.m_decTotalDiffCost).ToString();
            }
            this.totalMoney = decimal.Parse(obj.lbeSumMoney.Text);
            objPC.m_strPayTypeIndex = this.m_cmbPayMode.SelectedIndex.ToString();
            obj.PreInvoiceInfo = objPC;
            obj.Pid = this.m_PatientBasicInfo.PatientID;
            obj.PatientType = this.m_PatientBasicInfo.PatientType;
            obj.IsCanTurn = ((clsCtl_OPCharge)this.objController).IsCanTurn;
            obj.Idcardno = this.txtIDcard.Text;
            obj.Iccardno = this.txtInsuranceID.Text;
            obj.YBType = ((clsCtl_OPCharge)this.objController).YBType;
            objYBCal = objPC;
            if (m_blnGetChargeRightOpen())
            {
                if (obj.lbeSelfPay.Text.Trim() != string.Empty)
                {
                    //if (((clsCtl_OPCharge)this.objController).IsDongGuanYBPatient == false)
                    if (!((clsCtl_OPCharge)this.objController).m_Isybcharge())
                        if (((clsCtl_OPCharge)this.objController).intDiffPriceOn == 0)
                            this.m_objOPChargeRight.label3.Text = "请交： " + obj.lbeSelfPay.Text.Trim() + " 元";
                        else
                            this.m_objOPChargeRight.label3.Text = "请交： " + obj.lbeSelfPay.Text.Trim() + " 元,药品已让利 " + objPC.m_decTotalDiffCost.ToString() + " 元";// 提示总让利金额
                    this.m_objOPChargeRight.label4.Text = string.Empty;
                    this.m_objOPChargeRight.label1.Text = string.Empty;
                    m_objOPChargeRight.IsShowAmount = false;
                }
            }

            //判断明细是否与需交付的合计金额一致
            decimal decTotalPay = ((clsCtl_OPCharge)objController).m_decGetTotalPay(), decTotalPay_Cal = objPC.m_decTotalCost;
            if (((clsCtl_OPCharge)this.objController).intDiffPriceOn == 1)
            {
                decTotalPay_Cal = objPC.m_decTotalCost - objPC.m_decTotalDiffCost;// 减去总让利金额
                decTotalPay -= objPC.m_decTotalDiffCost;
            }
            if (decTotalPay != decTotalPay_Cal)
            {
                MessageBox.Show("明细金额与总金额不一致，请重新调处方！\r\n明细金额：" + decTotalPay.ToString() + "\r\n总金额：" + decTotalPay_Cal.ToString(), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dg = obj.ShowDialog();

            if (dg == DialogResult.OK)
            {
                decimal decTotal = objPC.m_decTotalCost;
                if (((clsCtl_OPCharge)this.objController).intDiffPriceOn == 1)
                {
                    decTotal = (decTotal - Math.Abs(objPC.m_decTotalDiffCost));// 让利后金额（自费病人的、直接现金结账的）
                }
                ((clsCtl_OPCharge)this.objController).SumTotalMoney += decTotal;
                ((clsCtl_OPCharge)this.objController).SumChargeUpMoney += objPC.m_decChargeUpCost;

                ((clsCtl_OPCharge)this.objController).SumPersonMoney += objPC.m_decPersonCost;
                ((clsCtl_OPCharge)this.objController).RecipeCountThisTime++;
                ((clsCtl_OPCharge)this.objController).strSumChargeUpMoney += "第 " + ((clsCtl_OPCharge)this.objController).RecipeCountThisTime.ToString() + " 张       " + objPC.m_decChargeUpCost.ToString("0.00") + "\n";
                ((clsCtl_OPCharge)this.objController).strSumPersonMoney += objPC.m_decPersonCost.ToString("0.00") + "\n";
                ((clsCtl_OPCharge)this.objController).strSumTotalMoney += decTotal.ToString("0.00") + "\n";

                #region 外挂显示
                if (m_blnGetChargeRightOpen())
                {
                    string m_strTemp = "0";
                    if (obj.txtFactPay.Text.Trim() != string.Empty && obj.txtFactPay.Text.Trim() != "0")
                    {

                        if (Convert.ToDouble(obj.txtFactPay.Text) < Convert.ToDouble(obj.lbeSelfPay.Text))
                        {
                            this.m_objOPChargeRight.label4.Text = "实收： " + obj.lbeSelfPay.Text.Trim() + " 元";
                            this.m_objOPChargeRight.label1.Text = string.Format("找零： {0} 元", m_strTemp.PadLeft(obj.lbeSelfPay.Text.Trim().Length, ' '));

                        }
                        else
                        {

                            this.m_objOPChargeRight.label4.Text = "实收： {0} 元";
                            this.m_objOPChargeRight.label1.Text = "找零： {0} 元";
                            if (obj.txtFactPay.Text.Trim().Length >= obj.lbePayBack.Text.Trim().Length)
                            {

                                m_strTemp = obj.lbePayBack.Text.Trim();
                                this.m_objOPChargeRight.label4.Text = string.Format(this.m_objOPChargeRight.label4.Text, obj.txtFactPay.Text.Trim());
                                this.m_objOPChargeRight.label1.Text = string.Format(this.m_objOPChargeRight.label1.Text, m_strTemp.PadLeft(obj.txtFactPay.Text.Trim().Length, ' '));
                            }
                            else
                            {
                                m_strTemp = obj.txtFactPay.Text.Trim();
                                this.m_objOPChargeRight.label4.Text = string.Format(this.m_objOPChargeRight.label4.Text, m_strTemp.PadLeft(obj.lbePayBack.Text.Trim().Length, ' '));
                                this.m_objOPChargeRight.label1.Text = string.Format(this.m_objOPChargeRight.label1.Text, obj.lbePayBack.Text.Trim());
                            }
                        }
                        this.m_objOPChargeRight.m_mthsetNotice();
                    }
                    else
                    {
                        this.m_objOPChargeRight.label4.Text = "实收： " + obj.lbeSelfPay.Text.Trim() + " 元";
                        this.m_objOPChargeRight.label1.Text = string.Format("找零： {0} 元", m_strTemp.PadLeft(obj.lbeSelfPay.Text.Trim().Length, ' '));

                    }
                }
                #endregion

                if (((clsCtl_OPCharge)this.objController).RecipeCount - ((clsCtl_OPCharge)this.objController).objHashTable.Count > 0)
                {
                    //((clsCtl_OPCharge)this.objController).m_mthSaveMedicineSend();

                    if (MessageBox.Show("是否继续调出未收费处方?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ((clsCtl_OPCharge)this.objController).m_mthFindMaxRecipeNoByPatientID();
                        if (chkDefaultItem.Checked)
                        {
                            ((clsCtl_OPCharge)this.objController).m_mthGetDefaultItem();
                        }
                        ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
                        return;
                    }
                    else
                    {
                        //((clsCtl_OPCharge)this.objController).m_mthSaveMedicineSend();

                    }
                }
                else
                {
                    //病人多张处方时在收完最后一张处方时在引导屏显示合计金额
                    if (((clsCtl_OPCharge)this.objController).RecipeCountThisTime > 1)
                    {
                        m_objOPChargeRight.IsShowAmount = true;
                        this.m_objOPChargeRight.m_lblAmount.Text = "合计金额： " + ((clsCtl_OPCharge)this.objController).SumTotalMoney.ToString("0.00") + "元";
                    }
                    if (((clsCtl_OPCharge)this.objController).PEWorkStationFlag)
                    {
                        ((clsCtl_OPCharge)this.objController).m_mthAutoSendLisApplyBill();
                    }
                    //else
                    //{
                    //    ((clsCtl_OPCharge)this.objController).m_mthSaveMedicineSend();
                    //}
                }
                if (((clsCtl_OPCharge)this.objController).RecipeCountThisTime > 1)
                {
                    frmShowTotalMoney objTotal = new frmShowTotalMoney();
                    objTotal.lbeTitle.Text = "处方合计金额(" + ((clsCtl_OPCharge)this.objController).RecipeCountThisTime.ToString() + "张)";
                    objTotal.lbeChargeUp.Text = ((clsCtl_OPCharge)this.objController).SumChargeUpMoney.ToString("0.00");
                    objTotal.lbeSelfPay.Text = ((clsCtl_OPCharge)this.objController).SumPersonMoney.ToString("0.00");
                    objTotal.lbeTotal.Text = ((clsCtl_OPCharge)this.objController).SumTotalMoney.ToString("0.00");
                    objTotal.lbe1.Text = ((clsCtl_OPCharge)this.objController).strSumChargeUpMoney;
                    objTotal.lbe2.Text = ((clsCtl_OPCharge)this.objController).strSumPersonMoney;
                    objTotal.lbe3.Text = ((clsCtl_OPCharge)this.objController).strSumTotalMoney;
                    objTotal.ShowDialog();
                }

                string ChargeMoney = this.m_mthReadChangeMoney();
                if (ChargeMoney == "")
                {
                    ChargeMoney = "0";
                }
                ((clsCtl_OPCharge)this.objController).SetShortCutInfo(this.MdiParent, 4, " 【上张发票找零】 … " + ChargeMoney + "元");

                this.m_mthClearAlldata();
                this.m_PatientBasicInfo.txtCardID.Focus();
            }
            else if (dg == DialogResult.Retry)
            {
                if (this.objYBCal != null)
                {
                    //新社保不计算凑整费，故需要删掉
                    if (RowNum >= 0 && YBnewFlag > 0)
                    {
                        string strReItemID = this.ctlDataGrid1[RowNum, ResubitemCol].ToString();

                        //如果项目ID不为空的就删除计费类对应的项目
                        if (this.ctlDataGrid1[RowNum, 10].ToString() != "" && this.ctlDataGrid1[RowNum, 1].ToString() != "")
                        {
                            int chrgrow = int.Parse(this.ctlDataGrid1[RowNum, 12].ToString());
                            ((clsCtl_OPCharge)this.objController).m_mthDeleteRecipe(chrgrow);
                        }
                        //删除DataGrid的数据
                        ctlDataGrid1.m_mthDeleteRow(RowNum);

                        if (strReItemID.StartsWith("[PK]"))
                        {
                            ((clsCtl_OPCharge)this.objController).m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                        }

                        this.ctlDataGrid1.Select();
                        if (this.ctlDataGrid1.CurrentCell.RowNumber == 0)
                        {
                            this.ctlDataGrid1.CurrentCell = new DataGridCell(0, 0);
                            SendKeys.SendWait("{Right}");
                            SendKeys.SendWait("{Left}");
                        }
                        else
                        {

                            ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
                        }
                    }
                    this.m_mthRecharge(objYBCal);
                }
            }
        }

        /// <summary>
        /// 打印发发票
        /// </summary>
        public long m_mthPrintInvoice(clsPatientChargeCal p_objPC, out string strInvoice)
        {
            long ret = 0;
            strInvoice = "";

            //if (((clsCtl_OPCharge)this.objController).IsDongGuanYBPatient)
            //{
            //    p_objPC.m_decPersonCost = p_objPC.m_decTotalCost;
            //    p_objPC.m_decChargeUpCost = 0;
            //}

            ret = ((clsCtl_OPCharge)this.objController).m_mthPrintInvoice(p_objPC, out strInvoice);
            if (ret > -1)
            {
                try
                {
                    if (((clsCtl_OPCharge)this.objController).IsPrintSendMedicineBill)
                    {
                        this.printPreviewDialog1.Document = this.printDocument2;
                        this.printDocument2.Print();
                    }
                }
                catch
                {
                    MessageBox.Show("无法打印发药单,请检查是否安装打印机");
                }
            }
            return ret;
        }
        /// <summary>
        /// 打印发发票
        /// </summary>
        public long m_mthPrintInvoicePreview(clsPatientChargeCal p_objPC)
        {
            return ((clsCtl_OPCharge)this.objController).m_mthPrintInvoicePreview(p_objPC);
        }

        #region 选择性交费新生成手工处方(先诊疗后结算项目)
        public long m_mthManualNewRecipe()
        {
            return ((clsCtl_OPCharge)this.objController).m_lngSelectFeeDispose();
            // ((clsCtl_OPCharge)this.objController).m_mthSaveRecipe(1); ;
        }
        #endregion
        /// <summary>
        /// 保存所有处方和发票的数据
        /// </summary>
        public long m_mthSaveAllData(clsPatientChargeCal[] p_objPC)
        {
            return ((clsCtl_OPCharge)this.objController).m_mthSaveRecipe(p_objPC);
        }
        #region 保存发票信息
        public long m_mthSaveInvoicInfo(clsPatientChargeCal p_objPC, int flag)
        {
            long ret = ((clsCtl_OPCharge)this.objController).m_mthSaveInvoicInfo(p_objPC, flag);
            if (ret <= 0)
            {
                MessageBox.Show("对不起,保存发票信息失败。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ((clsCtl_OPCharge)this.objController).m_mthSaveInvoiceDetail(p_objPC);
            }

            return ret;
        }
        #endregion
        #region 保存核算明细
        public void m_mthGetInvoiceNo(string strInvoiceNO)
        {
            ((clsCtl_OPCharge)this.objController).m_mthSaveInvoiceDetail2(strInvoiceNO);

        }
        #endregion
        #region 存取发票号
        public void m_mthSaveInvoiceNO(string strInvoice)
        {
            ((clsCtl_OPCharge)this.objController).m_mthSaveInvoiceNO(strInvoice);
            //			//保存发票号
            //			((clsCtl_OPCharge)this.objController).m_strReadInvoiceNO();//读出发票号
        }
        #endregion
        internal void frmOPCharge_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (btOK.Enabled == false)
                {
                    return;
                }

                this.btOK_Click(sender, e);

            }
            if (e.Control)
            {
                HandleInput = true;
                if (e.KeyCode == Keys.Q)
                {
                    this.m_mthChangeRegister();
                    return;
                }
                if (e.KeyCode == Keys.G)
                {
                    frmLocatingDayFs objfrm = new frmLocatingDayFs();
                    objfrm.ShowDialog();
                    return;
                }
                if (e.KeyCode == Keys.S && this.btSave.Enabled == true)
                {
                    this.btSave_Click(null, null);
                }
                if (e.KeyCode == Keys.P)
                {
                    this.btPrint_Click(null, null);
                }
                if (e.KeyCode == Keys.T)
                {
                    if (this.m_PatientBasicInfo.DeptID.Trim() == "")
                    {
                        this.m_PatientBasicInfo.txtRegisterDept.Focus();
                    }
                    else
                    {
                        this.m_PatientBasicInfo.txtRegisterDoctor.Focus();
                    }
                }
                if (e.KeyCode == Keys.D)
                {
                    if (m_cmbRecipeType.SelectedIndex == m_cmbRecipeType.Items.Count - 1)
                    {
                        m_cmbRecipeType.SelectedIndex = 0;
                    }
                    else
                    {
                        m_cmbRecipeType.SelectedIndex += 1;
                    }
                }
                if (e.KeyCode == Keys.B)
                {
                    frmChangePriceInfo frmObj = new frmChangePriceInfo();
                    frmObj.ItemCode = this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 0].ToString();
                    frmObj.ItemID = this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 10].ToString();
                    frmObj.ItemName = this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 2].ToString();
                    frmObj.ItemPrice = this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 6].ToString();
                    frmObj.ShowDialog();
                }
                if (e.KeyCode == Keys.L)
                {
                    if (MessageBox.Show("是否清空数据?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ((clsCtl_OPCharge)this.objController).m_mthCreatCalObj();
                        ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();

                    }

                }
                if (e.KeyCode == Keys.F)
                {
                    clsShowCalc objCalc = new clsShowCalc();
                    objCalc.m_mthShowCalc();
                }
                if (e.KeyCode == Keys.M)
                {
                    this.numericUpDown1.UpButton();
                }
                if (e.KeyCode == Keys.N)
                {
                    this.numericUpDown1.DownButton();
                }
            }
            if (e.Alt)
            {
                HandleInput = true;
                if (e.KeyCode == Keys.Z)
                {
                    this.m_PatientBasicInfo.txtType.Select();
                    this.m_PatientBasicInfo.txtType.SelectAll();
                }
                if (e.KeyCode == Keys.C)
                {
                    this.m_mthClearAlldata();
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                this.m_PatientBasicInfo.txtType.Select();
                this.m_PatientBasicInfo.txtType.SelectAll();
            }
            if (e.KeyCode == Keys.F8)
            {
                //病人补登记窗口
                com.digitalwave.iCare.gui.Patient.frmPatient frm = new com.digitalwave.iCare.gui.Patient.frmPatient();
                frm.UserFlag = 1;
                //把登陆信息转递过去
                frm.LoginInfo = this.LoginInfo;
                //调用窗口的方法，把窗体显示最小化
                frm.btnParticular_Click(null, null);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //登记完后获取病人信息更新到病人信息控件
                    this.m_PatientBasicInfo.m_mthGetPatientInfoByID(frm.m_strPatientID);
                    this.m_PatientBasicInfo.PatientType = frm.m_GetPatienVO.m_intINTERNALFLAG_INT;
                    this.m_PatientBasicInfo.PayTypeID = frm.m_GetPatienVO.m_strPAYTYPEID_CHR;
                    this.m_PatientBasicInfo.PayTypeName = frm.m_GetPatienVO.m_strPAYTYPENAME_VCHR;
                    try
                    {
                        this.m_PatientBasicInfo.Limit = decimal.Parse(frm.m_GetPatienVO.m_strPAYLIMIT_MNY);
                    }
                    catch
                    {
                        this.m_PatientBasicInfo.Limit = 0;
                    }
                    try
                    {
                        this.m_PatientBasicInfo.Discount = decimal.Parse(frm.m_GetPatienVO.m_strPAYPERCENT_DEC);
                    }
                    catch
                    {
                        this.m_PatientBasicInfo.Discount = 100;
                    }
                }
                frm.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                frmHelp2 objHelp = new frmHelp2();
                objHelp.SetObj = this;
                objHelp.ShowDialog();
            }
            if (e.KeyCode == Keys.Add)
            {

                if (btOK.Enabled == false)
                {
                    return;
                }

                this.btOK_Click(sender, e);

            }
            if (e.KeyCode == Keys.Escape)
            {

                if (this.listView1.Focused || this.m_cmbRecipeNO.Focused)
                {
                    return;
                }
                if (this.ActiveControl.GetType().Name == "ListView")
                {
                    return;
                }
                this.btExit_Click(null, null);
            }

            if (e.KeyCode == Keys.F5)
            {
                if (m_cmbFind.SelectedIndex == m_cmbFind.Items.Count - 1)
                {
                    m_cmbFind.SelectedIndex = 0;
                }
                else
                {
                    m_cmbFind.SelectedIndex += 1;
                }
            }

            if (e.KeyCode == Keys.F7)
            {
                this.txtLoadRecipeNO.Focus();
            }
            if (e.KeyCode == Keys.F9)
            {
                if (m_cmbPayMode.SelectedIndex == m_cmbPayMode.Items.Count - 1)
                {
                    m_cmbPayMode.SelectedIndex = 0;
                }
                else
                {
                    m_cmbPayMode.SelectedIndex += 1;
                }
            }
            if (e.KeyCode == Keys.F10)
            {
                e.Handled = true;
                m_txtInvoiceNO.Select();
                m_txtInvoiceNO.SelectAll();

            }
            if (e.KeyCode == Keys.F11)
            {
                if (m_cmbRecipeType.SelectedIndex == m_cmbRecipeType.Items.Count - 1)
                {
                    m_cmbRecipeType.SelectedIndex = 0;
                }
                else
                {
                    m_cmbRecipeType.SelectedIndex += 1;
                }
            }
            if (e.KeyCode == Keys.F12)
            {

                this.m_PatientBasicInfo.txtCardID.Select();

            }
            if (e.KeyCode == Keys.F3)
            {

                ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();

            }
        }
        /// <summary>
        /// 设置行号,如果是空行的,就不给与行号.这是为了与收费类的项目索引对应(已经作废)
        /// </summary>
        private void m_mthSetRowNo()
        {
            int row = 0;
            for (int i = 0; i < ctlDataGrid1.RowCount; i++)
            {
                if (this.ctlDataGrid1[i, 10].ToString() != "")
                {
                    this.ctlDataGrid1[i, 12] = row.ToString();
                    row++;
                }
                else
                {
                    this.ctlDataGrid1[i, 12] = "";
                }

            }
        }
        private void ctlDataGrid1_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int row = this.ctlDataGrid1.CurrentCell.RowNumber;
            int col = this.ctlDataGrid1.CurrentCell.ColumnNumber;

            try
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (col == 6)
                    {
                        this.ctlDataGrid1.CurrentCell = new DataGridCell(row, 1);
                        e.Handled = true;

                    }
                }
                if (e.KeyCode == Keys.F6)
                {
                    string strReItemID = this.ctlDataGrid1[row, ResubitemCol].ToString();

                    //如果项目ID不为空的就删除计费类对应的项目
                    if (this.ctlDataGrid1[row, 10].ToString() != "" && this.ctlDataGrid1[row, 1].ToString() != "")
                    {
                        int chrgrow = int.Parse(this.ctlDataGrid1[row, 12].ToString());
                        ((clsCtl_OPCharge)this.objController).m_mthDeleteRecipe(chrgrow);
                    }
                    //删除DataGrid的数据
                    ctlDataGrid1.m_mthDeleteRow(row);

                    if (strReItemID.StartsWith("[PK]"))
                    {
                        ((clsCtl_OPCharge)this.objController).m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                    }

                    this.ctlDataGrid1.Select();
                    if (this.ctlDataGrid1.CurrentCell.RowNumber == 0)
                    {
                        this.ctlDataGrid1.CurrentCell = new DataGridCell(0, 0);
                        SendKeys.SendWait("{Right}");
                        SendKeys.SendWait("{Left}");
                    }
                    else
                    {

                        ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
                    }


                    return;

                }

                if (e.KeyCode != Keys.F11)
                {
                    //把参数传递到窗体的KeyDown事件处理
                    this.frmOPCharge_KeyDown(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 改变中药服数时，循环DataGrid的项目找出中草药，重新计算项目价钱。注意同步到计费类。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.ctlDataGrid1.RowCount; i++)
            {
                int strRow = -1;
                if (this.ctlDataGrid1[i, 12].ToString().Trim() != "")
                {
                    strRow = int.Parse(this.ctlDataGrid1[i, 12].ToString().Trim());
                }
                if (this.ctlDataGrid1[i, 8].ToString().Trim() == ((clsCtl_OPCharge)this.objController).objCalPatientCharge.InvoiceCatID && strRow != -1)
                {
                    ((clsCtl_OPCharge)this.objController).m_mthChangeTimes(i, strRow);
                }
            }
        }

        private void m_cmbRecipeNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_OPCharge)this.objController).m_mthFindRecipeByID(m_cmbRecipeNO.Text);
            }
        }

        private void m_cmbRecipeNO_Enter(object sender, System.EventArgs e)
        {
            m_cmbRecipeNO.DroppedDown = true;
            if (m_cmbRecipeNO.SelectedIndex < 1 && m_cmbRecipeNO.Items.Count > 0)
            {
                m_cmbRecipeNO.SelectedIndex = 0;
            }

        }
        /// <summary>
        /// 只是保存处方信息，不保存发票信息和发药信息。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, System.EventArgs e)
        {
            //((clsCtl_OPCharge)this.objController).m_mthSaveRecipeOnly();
            if (this.ctlDataGrid1.RowCount == 0)
            {
                return;
            }

            ((clsCtl_OPCharge)this.objController).m_mthSaveRecipe();
        }
        /// <summary>
        /// 转变病人类型，详细说明请看函数说明。
        /// </summary>
        private void m_PatientBasicInfo_PatientTypeChanged()
        {
            ((clsCtl_OPCharge)this.objController).m_mthPatientTypeChanged();
            ((clsCtl_OPCharge)this.objController).m_mthCheckYBPayType();
        }

        private void m_txtInvoiceNO_Leave(object sender, System.EventArgs e)
        {
            ((clsCtl_OPCharge)this.objController).m_mthCheckInvoice();
        }

        /// <summary>
        /// 当用户改变发票号时要判断发票号是否正确。然后判断是否当前用户所领。
        /// 业务需求：判断发票号的长度在系统配置中有配置，但后来采用了正则表达式技术
        /// 兼容了前面的方法。正则表达式可以配置，保存在logFile.xml文件中。
        /// 补充：在点击结帐时也同样要作出判断。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtInvoiceNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_txtInvoiceNO.Text.Trim().Length != this.m_txtInvoiceNO.MaxLength)
                {
                    MessageBox.Show("发票号长度不对!", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (((clsCtl_OPCharge)this.objController).m_mthInvoiceExpression())
                {
                    return;
                }
                if (!((clsCtl_OPCharge)this.objController).IsOccupied(this.m_txtInvoiceNO.Text.Trim().Substring(2, this.m_txtInvoiceNO.Text.Trim().Length - 2)))
                {
                    DialogResult dr = MessageBox.Show("该发票号不属于当前用户所领!", "注意", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                    }
                    else
                    {
                        return;
                    }
                }
                ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
            }
        }
        /// <summary>
        /// 选择处方类型
        /// 业务需求：如果用户回车，光标跳到DataGrid让用户输入。用户可以通过数字键1、2来选择正副方。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmbRecipeType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && m_cmbRecipeType.DroppedDown == false)
            {
                m_cmbRecipeType.DroppedDown = true;
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
            }
            else
            {
                if (e.KeyValue == 97)
                {
                    m_cmbRecipeType.SelectedIndex = 0;
                    ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
                    return;
                }
                if (e.KeyValue == 98)
                {
                    m_cmbRecipeType.SelectedIndex = 1;
                    ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
                }
            }
        }
        /// <summary>
        /// 业务需求：当收费界面获取焦点时，用户想光标停留在原来的控件上，在这里作了控制，但
        /// 是存在Bug无法解决。有些情况下会失效。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOPCharge_Activated(object sender, System.EventArgs e)
        {
            //			this.ctlDataGrid1.m_mthClearSelectedRow();	
            if (this.objActiveControl != null)
            {
                if (objActiveControl is TextBox)
                {
                    this.ctlDataGrid1.Focus();
                    this.ctlDataGrid1.CurrentCell = cell;
                    //					this.ctlDataGrid1.Select();
                    //					return;
                }
                else
                {
                    int temp = 0;
                    if (this.objActiveControl.Parent != null)
                    {
                        temp = this.objActiveControl.Parent.TabIndex;
                        this.objActiveControl.Parent.TabIndex = 0;
                        this.objActiveControl.Parent.Focus();
                    }
                    this.objActiveControl.Select();
                    this.objActiveControl.Focus();
                    this.objActiveControl.Parent.TabIndex = temp;
                }
            }
        }
        /// <summary>
        /// 选择处方，处方选择是封装成一个控制。当用户选择一个处方时就产生这个事件，产生事件后，通过
        /// 访问控件的处方信息属性来获取数据。在获取数据时要把处方信息，例如当时处方的病人类型
        /// 填充到病人信息控件上显示。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoadRecipeNO_RecipeSelected(object sender, System.EventArgs e)
        {
            clsRecipeInfo_VO obj = this.txtLoadRecipeNO.RecipeInfo;
            this.m_PatientBasicInfo.DoctorName = obj.m_strDoctorName.Trim();
            this.m_PatientBasicInfo.DoctorID = obj.m_strDoctorID.Trim();
            this.m_PatientBasicInfo.DoctorNo = obj.m_strDoctorNo.Trim();
            this.m_PatientBasicInfo.DeptName = obj.m_strDepName.Trim();
            this.m_PatientBasicInfo.DeptID = obj.m_strDepID.Trim();
            this.m_PatientBasicInfo.PayTypeName = obj.m_strPatientTypeName.Trim();
            this.m_PatientBasicInfo.PayTypeID = obj.m_strPatientTypeID.Trim();
            this.m_PatientBasicInfo.PatientType = obj.m_intINTERNALFLAG_INT;
            this.m_PatientBasicInfo.Limit = obj.decLimint;
            this.m_PatientBasicInfo.Discount = obj.decDiscount;
            if (obj.m_strIsGreen.ToString().Trim() == "1")
            {
                this.blnFlag = true;
            }
            else
            {
                this.blnFlag = false;
            }
            ((clsCtl_OPCharge)this.objController).m_mthFindRecipeByID(obj.m_strOUTPATRECIPEID_CHR);

            if (chkDefaultItem.Checked)
            {
                ((clsCtl_OPCharge)this.objController).m_mthGetDefaultItem();
            }

            this.btReUse.Select();
            this.btReUse.Focus();

            if (this.m_cmbRecipeType.Enabled == false)
            {
                this.m_cmbPayMode.Focus();
            }
        }

        private void btPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                //				if(this.txtLoadRecipeNO.RecipeInfo==null)
                //				{
                //				return;
                //				}
                this.printPreviewDialog1.Document = this.printDocument1;
                this.printPreviewDialog1.ShowDialog();
                //				this.printDocument1.Print();
            }
            catch
            {
                MessageBox.Show("请先连接打印机!");
            }
            //			this.m_mthChangeRegister();
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsCtl_OPCharge)this.objController).m_mthPrintRecipe(e);
        }


        #region 清空数据
        /// <summary>
        /// 清空数据
        /// 业务需求：一、清空处方号。二、清空病人信息。三、生成一个新的计费类。
        /// 关于计费类的详细说明请查看文档的计费类。四、把光标放在卡号上，以便输入下一病人。
        /// </summary>
        private void m_mthClearAlldata()
        {
            this.txtLoadRecipeNO.m_mthClearText();
            this.m_PatientBasicInfo.Clear();
            this.txtIDcard.Text = "";
            this.txtInsuranceID.Text = "";
            this.cboProxyBoilMed.SelectedIndex = 0;
            ((clsCtl_OPCharge)this.objController).m_mthCreatCalObj();
            this.m_PatientBasicInfo.txtCardID.Focus();

        }
        #endregion

        private void frmOPCharge_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (noopen)
            {
                e.Cancel = false;
                return;
            }

            if (this.m_PatientBasicInfo.PatientID.Trim() != "" && this.ctlDataGrid1.RowCount > 0 && ((clsCtl_OPCharge)this.objController).IsReadOnly)
            {
                if (MessageBox.Show("处方没有保存,是否要退出门诊收费？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("是否要退出门诊收费？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            //this.ctlDataGrid1.Enabled=false;

            QueueSystemClient.frmDiagClientMain.PatientCalled -= new QueueSystemClient.PatientCalledEventHandler(frmDiagClientMain_PatientCalled);
            int intDoubleLCD = clsPublic.m_intGetSysParm("0076");
            if (intDoubleLCD == 1)
            {
                m_objOPChargeRight.Close();
            }

        }

        /// <summary>
        /// 改变查找方式时在Tag属性中保存查找条件，这里的条件是对应到数据库的字段。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //			if(e.KeyCode==Keys.Enter)
            //			{
            //				((clsCtl_OPCharge)this.objController).m_mthFindAccordRecipe();
            //			}
        }
        /// <summary>
        /// 处方复用功能。
        /// 业务需求：处方复用只针对已经收费的处方，btSave.Tag保存了处方号，复用后就会当作一张新和处方来
        /// 处理，这里就要清空它。还有个HashTable保存了处方号，因为一次收费可能有多张处方。因此要也要清空它。
        /// 还有DataGrid的26列保存了当明的明细处方对应的那一条处方的ID。复用的处方也要清空它，当作新的处方处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReUse_Click(object sender, System.EventArgs e)
        {
            //复用:清空处方号。
            this.btSave.Tag = null;
            this.btSave.Enabled = true;
            this.btOK.Enabled = true;
            this.m_PatientBasicInfo.txtRegisterDept.Enabled = true;
            this.m_PatientBasicInfo.txtRegisterDoctor.Enabled = true;
            this.ctlDataGrid1.Enabled = true;
            //清空HashTable 
            ((clsCtl_OPCharge)this.objController).objHashTable.Clear();
            //清空DataGrid的处方号
            for (int i = 0; i < this.ctlDataGrid1.RowCount; i++)
            {
                this.ctlDataGrid1[i, 26] = ""; ;
            }
            //复用后把当标控制到DataGrid方便用户继续输入其他项目
            ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
        }
        /// <summary>
        /// 控制只能输入数字。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (e.KeyChar == '+')
            {
                e.Handled = true;
            }

        }
        #region 转挂号
        /// <summary>
        /// 转到挂号窗口。
        /// 业务需求：有时病人没有挂号，为了方便病人不用再到挂号处挂号，
        /// 需要收费员转到挂号窗口代挂号。同样在挂号处也提供了转回收费的功能。
        /// </summary>
        private void m_mthChangeRegister()
        {
            if (this.FindWindow("frmRegister"))
            {
                return;
            }
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show_MDI_Child(this.MdiParent);
        }
        /// <summary>
        /// 查找父窗口的所有子窗口。如果有指定参数同名的就突出显示
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        private bool FindWindow(string strText)
        {
            for (int i = 0; i < this.MdiParent.MdiChildren.Length; i++)
            {
                string muText = this.MdiParent.MdiChildren[i].Name;
                if (strText == muText)
                {
                    this.MdiParent.MdiChildren[i].Activate();
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void btGroup_Click(object sender, System.EventArgs e)
        {
            //			int[] arr =this.ctlDataGrid1.m_arrSelectRows();
            //			this.ctlDataGrid1.m_mthClearSelectedRow();
            //			if(arr.Length==0)
            //			{
            //				return;
            //			}
            //			int temp =new Random().Next(1,244);
            //			for(int ii=0;ii<this.ctlDataGrid1.RowCount;ii++)
            //			{
            //				if(this.ctlDataGrid1[ii,16].ToString().Trim()!="")
            //				{
            //					this.ctlDataGrid1[ii,16] =int.Parse(this.ctlDataGrid1[ii,16].ToString().Trim())*-1;
            //				}
            //			}
            //			
            //			for(int i=0;i<arr.Length;i++)
            //			{
            //				this.ctlDataGrid1[arr[i],16] =-temp;
            //			}
            //			int beginValue =1;
            //			for(int ii=0;ii<this.ctlDataGrid1.RowCount;ii++)
            //			{
            //				if(this.ctlDataGrid1[ii,16].ToString().Trim()==""||int.Parse(this.ctlDataGrid1[ii,16].ToString().Trim())>=0)
            //				{
            //					continue;
            //				}
            //				string strValue =this.ctlDataGrid1[ii,16].ToString().Trim();
            //				this.ctlDataGrid1[ii,16]=0;
            //				bool flag =false;
            //				for(int i2=ii+1;i2<this.ctlDataGrid1.RowCount;i2++)
            //				{
            //								
            //					if(strValue ==this.ctlDataGrid1[i2,16].ToString().Trim())
            //					{
            //						this.ctlDataGrid1[ii,16] =beginValue;
            //						this.ctlDataGrid1[i2,16] =beginValue;
            //						flag =true;
            //					}
            //				}
            //				if(flag)
            //				{
            //					beginValue++;
            //				}
            //			}
            //			m_mthFormatDataGrid();

        }
        public void m_mthFormatDataGrid()
        {
            this.ctlDataGrid1.m_mthFormatReset();
            for (int i = 0; i < this.ctlDataGrid1.RowCount; i++)
            {
                switch (this.ctlDataGrid1[i, 16].ToString().Trim())
                {
                    case "0":
                        break;
                    case "1":
                        Color tempColor = System.Drawing.Color.FromArgb(((System.Byte)(250)), ((System.Byte)(255)), ((System.Byte)(200)));
                        this.ctlDataGrid1.m_mthSetRowColor(i, Color.Black, tempColor);
                        break;
                    case "2":
                        Color tempColor2 = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(255)), ((System.Byte)(255)));
                        this.ctlDataGrid1.m_mthSetRowColor(i, Color.Black, tempColor2);
                        break;
                    case "3":
                        Color tempColor3 = System.Drawing.Color.FromArgb(((System.Byte)(184)), ((System.Byte)(228)), ((System.Byte)(255)));
                        this.ctlDataGrid1.m_mthSetRowColor(i, Color.Black, tempColor3);
                        break;
                    case "4":
                        Color tempColor4 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(113)));
                        this.ctlDataGrid1.m_mthSetRowColor(i, Color.Black, tempColor4);
                        break;
                    case "5":
                        Color tempColor5 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(169)), ((System.Byte)(113)));
                        this.ctlDataGrid1.m_mthSetRowColor(i, Color.Black, tempColor5);
                        break;
                    default:
                        Color tempColor6 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(169)), ((System.Byte)(80)));
                        this.ctlDataGrid1.m_mthSetRowColor(i, Color.Black, tempColor6);
                        break;

                }

            }
        }
        private void btCancelGroup_Click(object sender, System.EventArgs e)
        {
            //			this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,16]=0;
            //			m_mthFormatDataGrid();
            //			this.ctlDataGrid1.m_mthSetRowColor(this.ctlDataGrid1.CurrentCell.RowNumber,Color.Black,Color.White);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            //		如果是用名称查找项目，则把调用记录了的输入法
            if (this.m_cmbFind.SelectedIndex == 1)
            {
                InputLanguage.CurrentInputLanguage = myInputLanguage;
            }

        }
        #region 设置医院
        /// <summary>
        /// 设置医院
        /// 业务说明：定义这个公共函数的目的是在弹出的收费窗口，改变医院时，同步更新到Controller类的变量中
        /// 保存，这种情况只适合慢病医院。
        /// </summary>
        public string SetHospital
        {
            set
            {
                ((clsCtl_OPCharge)this.objController).strHopitalID = value;
            }
        }
        #endregion

        private void TextBox_Leave(object sender, EventArgs e)
        {
            myInputLanguage = InputLanguage.CurrentInputLanguage;
        }
        //用户可以自定义收费比例，如果光标离开DataGrid的TextBox后，把比例值更新到14列，同时
        //最大长度改为4因100%是四位长度。
        private void TextBoxDiscount_Leave(object sender, EventArgs e)
        {
            TextBox myTextBox = sender as TextBox;
            myTextBox.MaxLength = 4;
            int row = ctlDataGrid1.CurrentCell.RowNumber;
            if (this.ctlDataGrid1[row, 14].ToString().Trim() != "")
            {
                this.ctlDataGrid1[row, 13] = this.ctlDataGrid1[row, 14].ToString() + "%";
            }

        }

        private void TextBoxDiscount_Enter(object sender, EventArgs e)
        {
            TextBox myTextBox = sender as TextBox;
            int row = ctlDataGrid1.CurrentCell.RowNumber;
            if (this.ctlDataGrid1[row, 14].ToString().Trim() != "")
            {
                myTextBox.Text = this.ctlDataGrid1[row, 14].ToString();
                this.ctlDataGrid1[row, 13] = this.ctlDataGrid1[row, 14].ToString();
            }
            myTextBox.MaxLength = 3;

        }
        /// <summary>
        /// 开始打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.printDocument1.DefaultPageSettings.Landscape = true;
            ((clsCtl_OPCharge)this.objController).m_mthBeginPrint();
        }
        /// <summary>
        ///开始打印发药单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument2_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((clsCtl_OPCharge)this.objController).m_mthBegionPrintMedicineSend();
        }
        /// <summary>
        /// 打印发药单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsCtl_OPCharge)this.objController).m_mthPrintMedicineSend(e);
        }

        private void printDocument2_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((clsCtl_OPCharge)this.objController).m_mthEndPrintMedicineSend();
        }
        /// <summary>
        /// 确保存发票号不能输入其他字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtInvoiceNO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            int temp = (int)e.KeyChar;
            if ((temp > 47 && temp < 58) || (temp > 96 && temp < 123) || (temp > 64 && temp < 91) || temp == 8)
            {

            }
            else
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 防止用户改量剂量后不按回车，直接用鼠标点击结账或其他操作时引起数据有误。这里作了控制，
        /// 就是在焦点离开DataGrid时计算一下。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlDataGrid1_Leave(object sender, System.EventArgs e)
        {
            if (!IsSave)
            {
                string strItemID = ctlDataGrid1[rowNO, 10].ToString().Trim();
                string price = ctlDataGrid1[rowNO, 6].ToString().Trim();
                string strCatID = ctlDataGrid1[rowNO, 8].ToString().Trim();
                string strCount = ctlDataGrid1[rowNO, 1].ToString().Trim();
                this.m_mthDosageChange(strItemID, price, strCatID, strCount, rowNO);
            }
            IsSave = true;
        }
        #region 控制DataGrid列
        /// <summary>
        /// 业务需求：为了在DataGrid或者文本框中输入组合快捷键时，快捷键的字母不要继续输入到文本框中去。
        /// 这里加了事件处理。如果按下了Ctrl或Alt等功能键时，输入无效。
        /// </summary>
        private void m_mthHandleDataGridInput()
        {
            for (int i = 0; i < ctlDataGrid1.Columns.Count; i++)
            {
                if (((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[i]).DataGridTextBoxColumn.TextBox.Enabled == false || ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[i]).DataGridTextBoxColumn.TextBox.MaxLength < 10)
                {
                    continue;
                }
                ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[i]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            }

            foreach (System.Windows.Forms.Control cc in this.m_PatientBasicInfo.Controls)
            {
                GroupBox g = cc as GroupBox;
                if (g != null)
                {
                    foreach (System.Windows.Forms.Control t in g.Controls)
                    {

                        t.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                    }
                }
            }
            foreach (System.Windows.Forms.Control cc in this.panel3.Controls)
            {

                cc.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            }

        }
        private bool HandleInput = false;
        private DataGridCell cell;
        private void TextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            objActiveControl = sender as System.Windows.Forms.Control;
            if (objActiveControl is TextBox)
            {
                cell = this.ctlDataGrid1.CurrentCell;
            }
            if (HandleInput)
            {
                e.Handled = true;
                HandleInput = false;
            }

        }
        #endregion
        private System.Windows.Forms.Control objActiveControl = null;

        private void m_PatientBasicInfo_SelectDoctor(object sender, System.EventArgs e)
        {
            ((clsCtl_OPCharge)this.objController).m_mthDoctorChanged();
            //调体检收费项目
            ((clsCtl_OPCharge)this.objController).m_mthLoadPEItem();
            this.m_cmbRecipeType.Focus();
            //ctlDataGrid1.Focus();
            //ctlDataGrid1.CurrentCell = new DataGridCell(ctlDataGrid1.RowCount, 0);
        }

        private void txtIDcard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtInsuranceID.Focus();
            }
        }

        private void txtInsuranceID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_cmbPayMode.Focus();
            }
        }

        #region 获取卡号文本框属性
        /// <summary>
        /// 获取卡号文本框属性
        /// </summary>
        public TextBox TextBoxPatientCard
        {
            get
            {
                return this.m_PatientBasicInfo.txtCardID;
            }
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
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
            else
            {
                this.timer.Enabled = false;
                this.Visible = true;
                this.Cursor = Cursors.Default;
            }
        }

        internal clsPatientChargeCal objYBCal = null;

        #region new
        public bool m_blnCreateDBFData(ref string p_strDBFile)
        {
            return ((clsCtl_OPCharge)this.objController).m_blnCreateDBFData(ref p_strDBFile, this.totalMoney);
        }

        public bool m_blnReadDBFData(string p_strDBFile, out DataTable p_dtYB)
        {
            return ((clsCtl_OPCharge)this.objController).m_blnReadDBFData(p_strDBFile, out p_dtYB);
        }

        public bool m_blnNewYbInterface()
        {
            return ((clsCtl_OPCharge)this.objController).m_blnNewYbInterface();
        }

        internal string m_strYBChargeNo = string.Empty;
        /// <summary>
        /// 设置医保结果
        /// </summary>
        /// <param name="p_strChargeNo"></param>
        /// <param name="p_decYBSum"></param>
        /// <param name="p_decTotalSum"></param>
        public void m_mthSetYBValue(string p_strChargeNo, decimal p_decYBSum, decimal p_decTotalSum)
        {
            this.m_strYBChargeNo = p_strChargeNo;
            this.YBVal = p_decYBSum;            // 让利后的记账金额
            this.TolVal = p_decTotalSum;        // 让利后的总金额
            this.YBFlag = true;
            // 20151231 补差价->20160927
            //if (this.objYBCal != null)
            //{
            //    this.TolVal += this.objYBCal.m_decTotalCost - this.objYBCal.m_decTotalDiffCost - this.TolVal;
            //}
        }
        public void m_mthSetYBValue(string p_strChargeNo, decimal p_decYBSum, decimal p_decTotalSum, decimal m_decBCYLTCZF1, decimal m_decBCYLTCZF2, decimal m_decBCYLTCZF3, decimal m_decQTZHIFU, decimal m_decYBJZFPJE)
        {
            this.m_strYBChargeNo = p_strChargeNo;
            this.YBVal = p_decYBSum;
            this.TolVal = p_decTotalSum;
            this.m_decBCYLTCZF1 = m_decBCYLTCZF1;
            this.m_decBCYLTCZF2 = m_decBCYLTCZF2;
            this.m_decBCYLTCZF3 = m_decBCYLTCZF3;
            this.m_decQTZHIFU = m_decQTZHIFU;
            this.m_decYBJZFPJE = m_decYBJZFPJE;
            this.YBFlag = true;
        }
        #endregion


        #region 佛山医保

        #region 传送或读取医保数据(佛山)
        /// <summary>
        /// 传送或读取医保数据(佛山)
        /// </summary>
        /// <param name="dg"></param>
        /// <returns></returns>
        public bool m_blnYBStart(Label lblBillNO, com.digitalwave.controls.datagrid.ctlDataGrid dg)
        {
            return ((clsCtl_OPCharge)this.objController).m_blnYBStart(lblBillNO, dg);
        }
        #endregion

        #region 读取医保数据并且填充到DATAGRID
        /// <summary>
        /// 读取医保数据并且填充到DATAGRID
        /// </summary>
        /// <param name="dg"></param>
        /// <returns></returns>
        public void m_mthYBRead(com.digitalwave.controls.datagrid.ctlDataGrid dg)
        {
            ((clsCtl_OPCharge)this.objController).m_mthGetybdata(dg);
        }
        #endregion

        #region 更新自付比例
        /// <summary>
        /// 更新自付比例
        /// </summary>
        /// <param name="dg"></param>
        public void m_mthYBEnd(com.digitalwave.controls.datagrid.ctlDataGrid dg)
        {
            ((clsCtl_OPCharge)this.objController).m_mthYBEnd(dg);
        }
        #endregion

        #region 根据医保信息重算
        /// <summary>
        /// 根据医保信息重算
        /// </summary>
        /// <param name="objCal"></param>
        public void m_mthRecharge(clsPatientChargeCal YBCal)
        {
            frmreckoning obj = new frmreckoning();
            obj.m_mthSetParentFrom(this);
            obj.m_mthShowRecipeCount(((clsCtl_OPCharge)this.objController).RecipeCount - 1);

            if (((clsCtl_OPCharge)this.objController).m_Isybcharge())
            {
                obj.btnYb.Enabled = true;
                obj.btnNewYb.Enabled = true;
            }
            else
            {
                obj.btnYb.Enabled = false;
                obj.btnNewYb.Enabled = false;
            }

            YBCal.m_strInvoiceNO = this.m_txtInvoiceNO.Text.Trim();
            //YBCal.m_decChargeUpCost = YBCal.m_decTotalCost - this.YBVal;  
            // YBCal.m_decPersonCost = this.YBVal;

            //记账金额
            YBCal.m_decChargeUpCost = this.YBVal;
            //YBCal.m_decTotalCost = this.TolVal; //还是要存让利前的金额，但是要用让利后的金额来结算。
            if (YBCal.m_decChargeUpCost != 0)
            {
                obj.lbeChargeUp.Text = YBCal.m_decChargeUpCost.ToString();
            }

            //自费金额
            //YBCal.m_decPersonCost = YBCal.m_decTotalCost - this.YBVal;
            YBCal.m_decPersonCost = this.TolVal - this.YBVal;           // 让利后总金额 - 让利后的记账
            YBCal.m_decBCYLTCZF1 = this.m_decBCYLTCZF1;//补充1支付
            YBCal.m_decBCYLTCZF2 = this.m_decBCYLTCZF2;//补充2支付
            YBCal.m_decBCYLTCZF3 = this.m_decBCYLTCZF3;//补充3支付
            YBCal.m_decQTZHIFU = this.m_decQTZHIFU;//其它支付
            YBCal.m_decYBJZFPJE = this.m_decYBJZFPJE;//医保记账
            decimal decTotalMny = YBCal.m_decTotalCost;//让利前的金额
            //if (((clsCtl_OPCharge)this.objController).intDiffPriceOn == 1)
            // {
            //decTotalMny = decTotalMny - Math.Abs(YBCal.m_decTotalDiffCost);
            // }
            if ((decTotalMny - Math.Abs(YBCal.m_decTotalDiffCost) - this.TolVal) > 1)
            {
                if (MessageBox.Show("社保总金额与HIS总金额不致，是否继续！", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

            obj.lbeSelfPay.Text = YBCal.m_decPersonCost.ToString();

            obj.lbeSumMoney.Text = this.TolVal.ToString();//让利后的金额（医保返回的金额是让利后的）


            YBCal.m_strPayTypeIndex = this.m_cmbPayMode.SelectedIndex.ToString();
            obj.PreInvoiceInfo = YBCal;
            obj.Pid = this.m_PatientBasicInfo.PatientID;
            obj.PatientType = this.m_PatientBasicInfo.PatientType;
            obj.IsCanTurn = ((clsCtl_OPCharge)this.objController).IsCanTurn;
            obj.Idcardno = this.txtIDcard.Text;
            obj.Iccardno = this.txtInsuranceID.Text;
            obj.YBHint = false;
            this.m_objOPChargeRight.label3.Text = "请交： " + obj.lbeSelfPay.Text.Trim() + " 元";
            m_objOPChargeRight.label7.Text = string.Format("（合计:{0}元  病人支付:{1}元  医保报销:{2}元）", obj.lbeSumMoney.Text.Trim(), obj.lbeSelfPay.Text.Trim(), (obj.lbeChargeUp.Text.Trim() == "") ? "0" : obj.lbeChargeUp.Text.Trim());
            m_objOPChargeRight.label7.Visible = true;
            if (obj.ShowDialog() == DialogResult.OK)
            {
                ((clsCtl_OPCharge)this.objController).m_mthUpdateChargeNo(this.m_strYBChargeNo);
                ((clsCtl_OPCharge)this.objController).SumTotalMoney += this.TolVal;
                ((clsCtl_OPCharge)this.objController).SumChargeUpMoney += YBCal.m_decChargeUpCost;
                ((clsCtl_OPCharge)this.objController).SumPersonMoney += YBCal.m_decPersonCost;
                ((clsCtl_OPCharge)this.objController).RecipeCountThisTime++;
                ((clsCtl_OPCharge)this.objController).strSumChargeUpMoney += "第 " + ((clsCtl_OPCharge)this.objController).RecipeCountThisTime.ToString() + " 张       " + YBCal.m_decChargeUpCost.ToString("0.00") + "\n";
                ((clsCtl_OPCharge)this.objController).strSumPersonMoney += YBCal.m_decPersonCost.ToString("0.00") + "\n";
                ((clsCtl_OPCharge)this.objController).strSumTotalMoney += this.TolVal.ToString("0.00") + "\n";

                if (((clsCtl_OPCharge)this.objController).RecipeCount - ((clsCtl_OPCharge)this.objController).objHashTable.Count > 0)
                {
                    //((clsCtl_OPCharge)this.objController).m_mthSaveMedicineSend();
                    if (MessageBox.Show("是否继续调出未收费处方?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.objYBCal = null;
                        this.YBVal = 0;
                        this.TolVal = 0;
                        this.YBFlag = false;
                        this.YBShownum = 0;

                        ((clsCtl_OPCharge)this.objController).m_mthFindMaxRecipeNoByPatientID();
                        if (chkDefaultItem.Checked)
                        {
                            ((clsCtl_OPCharge)this.objController).m_mthGetDefaultItem();
                        }
                        ((clsCtl_OPCharge)this.objController).m_mthSetFocusOnDataGrid();
                        return;
                    }
                    else
                    {
                        //((clsCtl_OPCharge)this.objController).m_mthSaveMedicineSend();
                    }
                }
                else
                {
                    //((clsCtl_OPCharge)this.objController).m_mthSaveMedicineSend();
                }
                if (((clsCtl_OPCharge)this.objController).RecipeCountThisTime > 1)
                {
                    frmShowTotalMoney objTotal = new frmShowTotalMoney();
                    objTotal.lbeTitle.Text = "处方合计金额(" + ((clsCtl_OPCharge)this.objController).RecipeCountThisTime.ToString() + "张)";
                    objTotal.lbeChargeUp.Text = ((clsCtl_OPCharge)this.objController).SumChargeUpMoney.ToString("0.00");
                    objTotal.lbeSelfPay.Text = ((clsCtl_OPCharge)this.objController).SumPersonMoney.ToString("0.00");
                    objTotal.lbeTotal.Text = ((clsCtl_OPCharge)this.objController).SumTotalMoney.ToString("0.00");
                    objTotal.lbe1.Text = ((clsCtl_OPCharge)this.objController).strSumChargeUpMoney;
                    objTotal.lbe2.Text = ((clsCtl_OPCharge)this.objController).strSumPersonMoney;
                    objTotal.lbe3.Text = ((clsCtl_OPCharge)this.objController).strSumTotalMoney;
                    objTotal.ShowDialog();
                }

                string ChargeMoney = this.m_mthReadChangeMoney();
                if (ChargeMoney == "")
                {
                    ChargeMoney = "0";
                }
                ((clsCtl_OPCharge)this.objController).SetShortCutInfo(this.MdiParent, 4, " 【上张发票找零】 … " + ChargeMoney + "元");

                this.m_mthClearAlldata();
                this.m_PatientBasicInfo.txtCardID.Focus();
            }
        }
        #endregion

        #region 提示医保结算
        /// <summary>
        /// 判断重显示一次医保结算窗口
        /// </summary>
        internal int YBShownum = 0;

        /// <summary>
        /// 提示医保结算
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="info"></param>
        public void m_mthYBHint(Button btn, string info)
        {
            frmFlash flash = new frmFlash();
            flash.Information = info;
            Point p = btn.Parent.PointToScreen(btn.Location);
            p.Offset(-50, -(flash.Height - btn.Height));
            flash.Location = p;
            flash.Show();
        }
        #endregion

        #region 手工更改记帐单号
        /// <summary>
        /// 手工更改记帐单号
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public bool m_blnModifyBillNo(out string BillNo)
        {
            return ((clsCtl_OPCharge)this.objController).m_blnModifyBillNo(out BillNo);
        }
        #endregion

        #endregion

        #region 顺特定门诊医保
        /// <summary>
        /// 顺特定门诊医保
        /// </summary>
        /// <returns></returns>
        public bool m_blnSDYBStart()
        {
            if (this.btSave.Tag == null || this.btSave.Tag.ToString().Trim() == "")
            {
                MessageBox.Show("特定医保结算前，请预先保存处方！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return ((clsCtl_OPCharge)this.objController).m_blnSDTDYB();
        }
        #endregion

        private void frmOPCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            //((clsCtl_OPCharge)this.objController).m_mthSaveMedicineSend();
            //设置快捷信息
            ((clsCtl_OPCharge)this.objController).SetShortCutInfo(this.MdiParent, 4, "");
        }

        #region 保存上张发票找零金额
        /// <summary>
        /// 保存上张发票找零金额
        /// </summary>
        /// <param name="val"></param>
        public void m_mthWriteChangeMoney(string val)
        {
            ((clsCtl_OPCharge)this.objController).m_blnWriteXML("HISMZ", "ChangeMoney", "AnyOne", val);
        }
        #endregion

        #region 读取上张发票找零金额
        /// <summary>
        /// 读取上张发票找零金额
        /// </summary>
        /// <returns></returns>
        public string m_mthReadChangeMoney()
        {
            return ((clsCtl_OPCharge)this.objController).m_strReadXML("HISMZ", "ChangeMoney", "AnyOne");
        }
        #endregion

        private void btnViewRecipe_Click(object sender, EventArgs e)
        {
            //查看处方
            DataTable dt;
            clsDcl_DoctorWorkstation objDoct = new clsDcl_DoctorWorkstation();
            int intRecipeCreateType = -1;

            long ret;

            if (this.txtLoadRecipeNO.Text == "")
            {
                return;
            }
            if (this.plRecipe.Tag != null && this.plRecipe.Tag.ToString() == this.txtLoadRecipeNO.Text)
            {
                plRecipe.BringToFront();
                plRecipe.Width = 652;
                return;
            }
            else
            {
                objDoct.m_lngGetRecipeCreateType(ref intRecipeCreateType, this.txtLoadRecipeNO.Text);
                if (intRecipeCreateType > 0)
                {
                    MessageBox.Show("非医生处方", "提示");
                    return;
                }
                this.plRecipe.Tag = this.txtLoadRecipeNO.Text;
                this.lvRecipe.Items.Clear();
            }
            #region 弃用
            ////1、西药
            //ret = objDoct.m_mthFindRecipeDetail1(txtLoadRecipeNO.Text, out dt, false);
            //if (ret > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow dr = dt.Rows[i];

            //        //0 状态 1 方号 2 项目名称 3 原规格 4 新规格 5 频率 6 用法 7 数量 8 原单价 9 新单价 10 原合计金额
            //        string[] s = new string[12];

            //        ListViewItem lvi = new ListViewItem();

            //        //1方号
            //        if (dr["rowno_chr"].ToString().Trim() == "0")
            //        {
            //            lvi.Text = "";
            //        }
            //        else
            //        {
            //            lvi.Text=dr["rowno_chr"].ToString().Trim();
            //        }
            //        //2项目名称
            //        lvi.SubItems.Add(dr["itemname_vchr"].ToString());
            //        //3原规格
            //        lvi.SubItems.Add(dr["itemspec_vchr"].ToString());

            //        //4新规格
            //        if (dr["itemspec_vchr"].ToString().Trim() != dr["spec"].ToString().Trim())
            //        {
            //            lvi.SubItems.Add(dr["spec"].ToString().Trim());
            //        }
            //        else
            //        {
            //            lvi.SubItems.Add("");
            //        }
            //        //5频率
            //        lvi.SubItems.Add(dr["freqname_chr"].ToString());
            //        //6用法
            //        lvi.SubItems.Add(dr["usagename_vchr"].ToString());
            //        //7数量
            //        lvi.SubItems.Add(dr["tolqty_dec"].ToString());
            //        //8原单价
            //        lvi.SubItems.Add(dr["unitprice_mny"].ToString());
            //        //9新单价
            //        if (dr["opchargeflg_int"].ToString().Trim() == "0")
            //        {
            //            if (this.ConvertObjToDecimal(dr["unitprice_mny"]) != this.ConvertObjToDecimal(dr["itemprice_mny"]))
            //            {
            //                lvi.SubItems.Add(dr["itemprice_mny"].ToString());
            //            }
            //            else
            //            {
            //                lvi.SubItems.Add("");
            //            }
            //        }
            //        else
            //        {
            //            if (this.ConvertObjToDecimal(dr["unitprice_mny"]) != this.ConvertObjToDecimal(dr["submoney"]))
            //            {
            //                lvi.SubItems.Add(dr["submoney"].ToString());
            //            }
            //            else
            //            {
            //                lvi.SubItems.Add("");
            //            }
            //        }
            //        //10原合计金额
            //        lvi.SubItems.Add(dr["tolprice_mny"].ToString());
            //        this.lvRecipe.Items.Add(lvi);
            //    }
            //}
            ////2、中药
            //ret = objDoct.m_mthFindRecipeDetail2(txtLoadRecipeNO.Text, out dt, false);
            //if (ret > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow dr = dt.Rows[i];

            //        //0 状态 1 方号 2 项目名称 3 原规格 4 新规格 5 频率 6 用法 7 数量 8 原单价 9 新单价 10 原合计金额 11 项目属性
            //        ListViewItem lvi = new ListViewItem();
            //        //1 方号
            //        lvi.Text = "";
            //        //2 项目名称
            //        lvi.SubItems.Add(dr["itemname"].ToString());
            //        //3 原规格
            //        lvi.SubItems.Add(dr["dec"].ToString());
            //        //4 新规格
            //        if (dr["dec"].ToString().Trim() != dr["spec"].ToString().Trim())
            //        {
            //            lvi.SubItems.Add(dr["spec"].ToString());
            //        }
            //        else
            //        {
            //            lvi.SubItems.Add("");
            //        }
            //        //5 频率
            //        lvi.SubItems.Add("");
            //        //6 用法
            //        lvi.SubItems.Add(dr["usagename_vchr"].ToString());
            //        //7 数量
            //        lvi.SubItems.Add(Convert.ToString(ConvertObjToDecimal(dr["times"]) * ConvertObjToDecimal(dr["min_qty_dec"])));
            //        //8 原单价
            //        lvi.SubItems.Add(dr["price"].ToString());
            //        //9 新单价
            //        if (this.ConvertObjToDecimal(dr["price"]) != this.ConvertObjToDecimal(dr["submoney"]))
            //        {
            //            lvi.SubItems.Add(dr["submoney"].ToString());
            //        }
            //        else
            //        {
            //            lvi.SubItems.Add("");
            //        }
            //        //10 原合计金额
            //        lvi.SubItems.Add(dr["summoney"].ToString());
            //        this.lvRecipe.Items.Add(lvi);
            //    }
            //}
            ////诊疗项目
            //ret = objDoct.m_mthFindRecipeDetailOrder(txtLoadRecipeNO.Text, out dt);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt.Rows[i];

            //    //0 状态 1 方号 2 项目名称 3 原规格 4 新规格 5 频率 6 用法 7 数量 8 原单价 9 新单价 10 原合计金额 11 项目属性

            //    ListViewItem lvi = new ListViewItem();
            //    //1 方号
            //    lvi.Text = "";
            //    //2 项目名称
            //    lvi.SubItems.Add(dr["ORDERDICNAME_VCHR"].ToString());
            //    //3 原规格
            //    lvi.SubItems.Add(dr["spec_vchr"].ToString());
            //    //4 新规格
            //    lvi.SubItems.Add("");
            //    //5 频率
            //    lvi.SubItems.Add("");
            //    //6 用法
            //    lvi.SubItems.Add("");
            //    //7 数量
            //    lvi.SubItems.Add(dr["qty_dec"].ToString());
            //    //8 原单价
            //    lvi.SubItems.Add(dr["pricemny_dec"].ToString());
            //    //9 新单价
            //    lvi.SubItems.Add("");
            //    //10 原合计金额
            //    lvi.SubItems.Add(dr["totalmny_dec"].ToString());

            //    this.lvRecipe.Items.Add(lvi);
            //}
            ////6、其他
            //ret = objDoct.m_mthFindRecipeDetail6(this.txtLoadRecipeNO.Text, out dt, false);
            //if (ret > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow dr = dt.Rows[i];

            //        //0 状态 1 方号 2 项目名称 3 原规格 4 新规格 5 频率 6 用法 7 数量 8 原单价 9 新单价  11 项目属性
            //        ListViewItem lvi = new ListViewItem();
            //        string[] s = new string[12];

            //        //1 方号
            //        lvi.Text = "";
            //        //2 项目名称
            //        lvi.SubItems.Add(dr["itemname"].ToString());
            //        //3 原规格
            //        lvi.SubItems.Add(dr["dec"].ToString());
            //        //4 新规格
            //        if (dr["dec"].ToString().Trim() != dr["spec"].ToString().Trim())
            //        {
            //            s[4] = dr["spec"].ToString();
            //        }
            //        else
            //        {
            //            lvi.SubItems.Add("");
            //        }
            //        //5 频率
            //        lvi.SubItems.Add("");
            //        //6 用法
            //        lvi.SubItems.Add("");
            //        //7 数量
            //        lvi.SubItems.Add(dr["quantity"].ToString());
            //        //8 原单价
            //        lvi.SubItems.Add(dr["price"].ToString());
            //        //9 新单价
            //        if (this.ConvertObjToDecimal(dr["price"]) != this.ConvertObjToDecimal(dr["itemprice_mny"]))
            //        {
            //            s[9] = dr["itemprice_mny"].ToString();
            //        }
            //        else
            //        {
            //            lvi.SubItems.Add("");
            //        }
            //        //10 原合计金额
            //        lvi.SubItems.Add(dr["summoney"].ToString());
            //        this.lvRecipe.Items.Add(lvi);
            //    }
            //}
            #endregion
            objDoct.m_lngGetRecipeDetail(txtLoadRecipeNO.Text, out dt);
            DataView dv = dt.DefaultView;
            dv.Sort = "opritemname";
            dt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = dt.Rows[i][0].ToString();
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                    lvi.SubItems.Add(dt.Rows[i][4].ToString());
                    lvi.SubItems.Add(dt.Rows[i][5].ToString());
                    lvi.SubItems.Add(dt.Rows[i][6].ToString());
                    lvRecipe.Items.Add(lvi);
                }
            }
            plRecipe.BringToFront();
            plRecipe.Width = 652;
        }
        #region 转换成数字
        /// <summary>
        /// 转换成数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public decimal ConvertObjToDecimal(object obj)
        {
            try
            {
                if (obj != null && obj.ToString() != "")
                {
                    return Convert.ToDecimal(obj.ToString());

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        #endregion
        private void ctlDataGrid1_Enter(object sender, EventArgs e)
        {
            plRecipe.Width = 0;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
