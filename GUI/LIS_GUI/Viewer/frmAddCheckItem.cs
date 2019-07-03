using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 检验项目维护界面
    /// </summary>
    public class frmAddCheckItem : frmMDI_Child_Base
    {
        #region 控件名称
        internal System.Windows.Forms.ListView lsvCheckItemDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        internal System.Windows.Forms.TextBox txtWBAss;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox txtCheckMethod;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtPYAss;
        internal System.Windows.Forms.TextBox txtReportNO;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtEnglistName;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtCheckItemNameCN;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cboCheckCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cboSampleValidateTimeUnit;
        internal System.Windows.Forms.TextBox txtSampleValidateTime;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label labDiagnose;
        internal System.Windows.Forms.TextBox txtClinicMeaning;
        internal System.Windows.Forms.Button btnDelRef;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtToRef;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtToAge;
        internal System.Windows.Forms.TextBox txtFromRef;
        internal System.Windows.Forms.TextBox txtFromAge;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ListView lsvSampleRef;
        private System.Windows.Forms.Button btnDelCheckItem;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label21;
        //		private System.Data.DataTable dtbAllCheckItem;
        internal System.Windows.Forms.CheckBox chkQC;
        internal System.Windows.Forms.CheckBox chkReservation;
        internal System.Windows.Forms.CheckBox chkPhysicalExam;
        internal System.Windows.Forms.CheckBox chkNoFood;
        private System.Data.DataTable dtbAllCheckCategory;
        private System.Data.DataTable dtbAllSampleType;
        internal System.Windows.Forms.ComboBox cboSex;
        internal System.Windows.Forms.ComboBox cboResultType;
        private System.Windows.Forms.Button btnAddCheckItem;
        internal System.Windows.Forms.Button btnSaveRef;
        internal System.Windows.Forms.Button btnAddRef;
        internal int intSEQ = 1;
        private System.Windows.Forms.GroupBox gbBsePara;
        private System.Windows.Forms.GroupBox gbPara;
        private System.Windows.Forms.GroupBox gbItemRef;
        private System.Windows.Forms.ColumnHeader chSex;
        private System.Windows.Forms.ColumnHeader chFromAge;
        private System.Windows.Forms.ColumnHeader chToAge;
        private System.Windows.Forms.ColumnHeader chRef;
        private System.Windows.Forms.ColumnHeader chFromRef;
        private System.Windows.Forms.ColumnHeader chToRef;
        internal System.Windows.Forms.ComboBox m_cboBeginAgeUnit;
        internal System.Windows.Forms.ComboBox m_cboEndAgeUnit;
        private System.Windows.Forms.Label m_lblAssistCodeOne;
        private System.Windows.Forms.Label m_lblAssistCodeTwo;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox m_txtAssistCodeOne;
        internal System.Windows.Forms.TextBox m_txtAssistCodeTwo;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox m_txtDefaultRefMax;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox m_txtDefaultRefMin;
        internal System.Windows.Forms.TextBox m_txtDefaultRefRange;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.CheckBox m_chkSexRelation;
        internal System.Windows.Forms.CheckBox m_chkAgeRelation;
        internal System.Windows.Forms.CheckBox m_chkMensesRelation;
        private System.Windows.Forms.GroupBox m_grpRelation;
        internal System.Windows.Forms.Button m_btnFormulaWizard;
        internal System.Windows.Forms.CheckBox m_chkMedUsedTimeRelation;
        private System.Windows.Forms.ColumnHeader chMedUseTime;
        private System.Windows.Forms.ColumnHeader chMenses;
        private System.Windows.Forms.ComboBox m_cboMedUsedTimeUnit;
        private System.Windows.Forms.TextBox m_txtMedUsedTime;
        private System.Windows.Forms.Label label23;
        internal System.Windows.Forms.ComboBox m_cboMenses;
        private System.Windows.Forms.Label label24;
        internal System.Windows.Forms.ComboBox cboSampleType;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.CheckBox chkIsCalculated;
        private System.Windows.Forms.ColumnHeader chSeqNo;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label25;
        internal System.Windows.Forms.Button m_btnValueTemplate;
        private System.Windows.Forms.Label m_lbDangerousValMax;
        private System.Windows.Forms.Label m_lbDangerousValMin;
        private System.Windows.Forms.Label m_lbDangerousVal;
        internal System.Windows.Forms.TextBox m_txtAlarmVal;
        internal System.Windows.Forms.TextBox m_txtAlarmValMax;
        internal System.Windows.Forms.TextBox m_txtAlarmValMin;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region 属性
        frmValueTemplate objfrmValueTemplate = new frmValueTemplate();
        internal com.digitalwave.iCare.gui.LIS.ctlLISSampleGroupComboBox m_cboSampleGroup;
        //系统内部的计算公式
        internal string m_strFormula = "";
        //显示给用户的计算公式
        internal string m_strUserFormula = "";
        private Button btnClose;
        private Label label26;
        internal TextBox m_txtItemPrice;
        private Label label27;
        internal TextBox txtCrVal2;
        private Label label28;
        internal TextBox txtCrVal1;
        private ColumnHeader colCrVal1;
        private ColumnHeader colCrVal2;
        internal ListBox lstDepts;
        internal PinkieControls.ButtonXP btnAddDept;
        private ColumnHeader colCrDept;
        internal PinkieControls.ButtonXP btnClearDept;
        internal Button btnYgCrivalue;
        internal bool m_blnInit = true;
        #endregion

        #region 系统自动创建
        public frmAddCheckItem()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.btnAddCheckItem = new System.Windows.Forms.Button();
            this.btnDelCheckItem = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lsvSampleRef = new System.Windows.Forms.ListView();
            this.chSeqNo = new System.Windows.Forms.ColumnHeader();
            this.chSex = new System.Windows.Forms.ColumnHeader();
            this.chFromAge = new System.Windows.Forms.ColumnHeader();
            this.chToAge = new System.Windows.Forms.ColumnHeader();
            this.chMenses = new System.Windows.Forms.ColumnHeader();
            this.chMedUseTime = new System.Windows.Forms.ColumnHeader();
            this.chFromRef = new System.Windows.Forms.ColumnHeader();
            this.chToRef = new System.Windows.Forms.ColumnHeader();
            this.chRef = new System.Windows.Forms.ColumnHeader();
            this.colCrVal1 = new System.Windows.Forms.ColumnHeader();
            this.colCrVal2 = new System.Windows.Forms.ColumnHeader();
            this.colCrDept = new System.Windows.Forms.ColumnHeader();
            this.gbItemRef = new System.Windows.Forms.GroupBox();
            this.btnClearDept = new PinkieControls.ButtonXP();
            this.lstDepts = new System.Windows.Forms.ListBox();
            this.btnAddDept = new PinkieControls.ButtonXP();
            this.label27 = new System.Windows.Forms.Label();
            this.txtCrVal2 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtCrVal1 = new System.Windows.Forms.TextBox();
            this.btnDelRef = new System.Windows.Forms.Button();
            this.btnSaveRef = new System.Windows.Forms.Button();
            this.btnAddRef = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.m_cboMenses = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.m_cboMedUsedTimeUnit = new System.Windows.Forms.ComboBox();
            this.m_txtMedUsedTime = new System.Windows.Forms.TextBox();
            this.m_cboEndAgeUnit = new System.Windows.Forms.ComboBox();
            this.m_cboBeginAgeUnit = new System.Windows.Forms.ComboBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtToRef = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtToAge = new System.Windows.Forms.TextBox();
            this.txtFromRef = new System.Windows.Forms.TextBox();
            this.txtFromAge = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbPara = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.chkQC = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkReservation = new System.Windows.Forms.CheckBox();
            this.chkNoFood = new System.Windows.Forms.CheckBox();
            this.chkPhysicalExam = new System.Windows.Forms.CheckBox();
            this.cboSampleValidateTimeUnit = new System.Windows.Forms.ComboBox();
            this.txtSampleValidateTime = new System.Windows.Forms.TextBox();
            this.m_grpRelation = new System.Windows.Forms.GroupBox();
            this.m_chkMedUsedTimeRelation = new System.Windows.Forms.CheckBox();
            this.m_chkSexRelation = new System.Windows.Forms.CheckBox();
            this.m_chkMensesRelation = new System.Windows.Forms.CheckBox();
            this.m_chkAgeRelation = new System.Windows.Forms.CheckBox();
            this.labDiagnose = new System.Windows.Forms.Label();
            this.txtClinicMeaning = new System.Windows.Forms.TextBox();
            this.gbBsePara = new System.Windows.Forms.GroupBox();
            this.m_txtItemPrice = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_txtAlarmVal = new System.Windows.Forms.TextBox();
            this.m_lbDangerousVal = new System.Windows.Forms.Label();
            this.m_txtAlarmValMax = new System.Windows.Forms.TextBox();
            this.m_lbDangerousValMax = new System.Windows.Forms.Label();
            this.m_txtAlarmValMin = new System.Windows.Forms.TextBox();
            this.m_lbDangerousValMin = new System.Windows.Forms.Label();
            this.m_btnValueTemplate = new System.Windows.Forms.Button();
            this.chkIsCalculated = new System.Windows.Forms.CheckBox();
            this.m_btnFormulaWizard = new System.Windows.Forms.Button();
            this.m_txtDefaultRefRange = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtDefaultRefMax = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtDefaultRefMin = new System.Windows.Forms.TextBox();
            this.m_txtAssistCodeTwo = new System.Windows.Forms.TextBox();
            this.m_txtAssistCodeOne = new System.Windows.Forms.TextBox();
            this.m_lblAssistCodeTwo = new System.Windows.Forms.Label();
            this.m_lblAssistCodeOne = new System.Windows.Forms.Label();
            this.cboResultType = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtWBAss = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCheckMethod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtPYAss = new System.Windows.Forms.TextBox();
            this.txtReportNO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnglistName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheckItemNameCN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lsvCheckItemDetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCheckCategory = new System.Windows.Forms.ComboBox();
            this.cboSampleType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnYgCrivalue = new System.Windows.Forms.Button();
            this.m_cboSampleGroup = new com.digitalwave.iCare.gui.LIS.ctlLISSampleGroupComboBox();
            this.gbItemRef.SuspendLayout();
            this.gbPara.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_grpRelation.SuspendLayout();
            this.gbBsePara.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("宋体", 9F);
            this.btnClose.Location = new System.Drawing.Point(1019, 616);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(372, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 14);
            this.label25.TabIndex = 44;
            this.label25.Text = "样本组";
            // 
            // btnAddCheckItem
            // 
            this.btnAddCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCheckItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCheckItem.Location = new System.Drawing.Point(734, 616);
            this.btnAddCheckItem.Name = "btnAddCheckItem";
            this.btnAddCheckItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddCheckItem.TabIndex = 37;
            this.btnAddCheckItem.Text = "新增";
            this.btnAddCheckItem.Click += new System.EventHandler(this.btnAddCheckItem_Click);
            // 
            // btnDelCheckItem
            // 
            this.btnDelCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCheckItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelCheckItem.Location = new System.Drawing.Point(924, 616);
            this.btnDelCheckItem.Name = "btnDelCheckItem";
            this.btnDelCheckItem.Size = new System.Drawing.Size(75, 23);
            this.btnDelCheckItem.TabIndex = 36;
            this.btnDelCheckItem.Text = "删除";
            this.btnDelCheckItem.Click += new System.EventHandler(this.btnDelCheckItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(829, 616);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lsvSampleRef
            // 
            this.lsvSampleRef.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSampleRef.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSeqNo,
            this.chSex,
            this.chFromAge,
            this.chToAge,
            this.chMenses,
            this.chMedUseTime,
            this.chFromRef,
            this.chToRef,
            this.chRef,
            this.colCrVal1,
            this.colCrVal2,
            this.colCrDept});
            this.lsvSampleRef.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSampleRef.FullRowSelect = true;
            this.lsvSampleRef.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvSampleRef.HideSelection = false;
            this.lsvSampleRef.Location = new System.Drawing.Point(256, 496);
            this.lsvSampleRef.MultiSelect = false;
            this.lsvSampleRef.Name = "lsvSampleRef";
            this.lsvSampleRef.Size = new System.Drawing.Size(844, 112);
            this.lsvSampleRef.TabIndex = 27;
            this.lsvSampleRef.UseCompatibleStateImageBehavior = false;
            this.lsvSampleRef.View = System.Windows.Forms.View.Details;
            this.lsvSampleRef.SelectedIndexChanged += new System.EventHandler(this.lsvSampleRef_Click);
            this.lsvSampleRef.Click += new System.EventHandler(this.lsvSampleRef_Click);
            // 
            // chSeqNo
            // 
            this.chSeqNo.Text = "序号";
            this.chSeqNo.Width = 40;
            // 
            // chSex
            // 
            this.chSex.Text = "性别";
            this.chSex.Width = 0;
            // 
            // chFromAge
            // 
            this.chFromAge.Text = "年龄下限";
            this.chFromAge.Width = 0;
            // 
            // chToAge
            // 
            this.chToAge.Text = "年龄上限";
            this.chToAge.Width = 0;
            // 
            // chMenses
            // 
            this.chMenses.Text = "月经期";
            this.chMenses.Width = 0;
            // 
            // chMedUseTime
            // 
            this.chMedUseTime.Text = "用药时间";
            this.chMedUseTime.Width = 0;
            // 
            // chFromRef
            // 
            this.chFromRef.Text = "参考下限";
            this.chFromRef.Width = 68;
            // 
            // chToRef
            // 
            this.chToRef.Text = "参考上限";
            this.chToRef.Width = 68;
            // 
            // chRef
            // 
            this.chRef.Text = "参考值";
            this.chRef.Width = 200;
            // 
            // colCrVal1
            // 
            this.colCrVal1.Text = "危急值下限";
            this.colCrVal1.Width = 90;
            // 
            // colCrVal2
            // 
            this.colCrVal2.Text = "危急值上限";
            this.colCrVal2.Width = 90;
            // 
            // colCrDept
            // 
            this.colCrDept.Text = "科室";
            this.colCrDept.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCrDept.Width = 260;
            // 
            // gbItemRef
            // 
            this.gbItemRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbItemRef.Controls.Add(this.btnClearDept);
            this.gbItemRef.Controls.Add(this.lstDepts);
            this.gbItemRef.Controls.Add(this.btnAddDept);
            this.gbItemRef.Controls.Add(this.label27);
            this.gbItemRef.Controls.Add(this.txtCrVal2);
            this.gbItemRef.Controls.Add(this.label28);
            this.gbItemRef.Controls.Add(this.txtCrVal1);
            this.gbItemRef.Controls.Add(this.btnDelRef);
            this.gbItemRef.Controls.Add(this.btnSaveRef);
            this.gbItemRef.Controls.Add(this.btnAddRef);
            this.gbItemRef.Controls.Add(this.label24);
            this.gbItemRef.Controls.Add(this.m_cboMenses);
            this.gbItemRef.Controls.Add(this.label23);
            this.gbItemRef.Controls.Add(this.m_cboMedUsedTimeUnit);
            this.gbItemRef.Controls.Add(this.m_txtMedUsedTime);
            this.gbItemRef.Controls.Add(this.m_cboEndAgeUnit);
            this.gbItemRef.Controls.Add(this.m_cboBeginAgeUnit);
            this.gbItemRef.Controls.Add(this.cboSex);
            this.gbItemRef.Controls.Add(this.label20);
            this.gbItemRef.Controls.Add(this.txtRef);
            this.gbItemRef.Controls.Add(this.label19);
            this.gbItemRef.Controls.Add(this.label17);
            this.gbItemRef.Controls.Add(this.label10);
            this.gbItemRef.Controls.Add(this.txtToRef);
            this.gbItemRef.Controls.Add(this.label12);
            this.gbItemRef.Controls.Add(this.txtToAge);
            this.gbItemRef.Controls.Add(this.txtFromRef);
            this.gbItemRef.Controls.Add(this.txtFromAge);
            this.gbItemRef.Controls.Add(this.label11);
            this.gbItemRef.Font = new System.Drawing.Font("宋体", 9F);
            this.gbItemRef.Location = new System.Drawing.Point(256, 380);
            this.gbItemRef.Name = "gbItemRef";
            this.gbItemRef.Size = new System.Drawing.Size(844, 112);
            this.gbItemRef.TabIndex = 7;
            this.gbItemRef.TabStop = false;
            this.gbItemRef.Text = "样品参考值范围";
            // 
            // btnClearDept
            // 
            this.btnClearDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClearDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearDept.DefaultScheme = true;
            this.btnClearDept.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClearDept.Font = new System.Drawing.Font("宋体", 9F);
            this.btnClearDept.Hint = "";
            this.btnClearDept.Location = new System.Drawing.Point(668, 16);
            this.btnClearDept.Name = "btnClearDept";
            this.btnClearDept.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClearDept.Size = new System.Drawing.Size(48, 24);
            this.btnClearDept.TabIndex = 49;
            this.btnClearDept.Text = "清空";
            this.btnClearDept.Click += new System.EventHandler(this.btnClearDept_Click);
            // 
            // lstDepts
            // 
            this.lstDepts.FormattingEnabled = true;
            this.lstDepts.ItemHeight = 12;
            this.lstDepts.Location = new System.Drawing.Point(592, 42);
            this.lstDepts.Name = "lstDepts";
            this.lstDepts.Size = new System.Drawing.Size(124, 64);
            this.lstDepts.TabIndex = 48;
            // 
            // btnAddDept
            // 
            this.btnAddDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAddDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDept.DefaultScheme = true;
            this.btnAddDept.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddDept.Font = new System.Drawing.Font("宋体", 9F);
            this.btnAddDept.Hint = "";
            this.btnAddDept.Location = new System.Drawing.Point(591, 16);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnAddDept.Size = new System.Drawing.Size(75, 24);
            this.btnAddDept.TabIndex = 47;
            this.btnAddDept.Text = "选择科室▼";
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(202, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 16);
            this.label27.TabIndex = 43;
            this.label27.Text = "危急值下限";
            // 
            // txtCrVal2
            // 
            this.txtCrVal2.Enabled = false;
            this.txtCrVal2.Location = new System.Drawing.Point(472, 72);
            this.txtCrVal2.MaxLength = 50;
            this.txtCrVal2.Name = "txtCrVal2";
            this.txtCrVal2.Size = new System.Drawing.Size(104, 21);
            this.txtCrVal2.TabIndex = 46;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(395, 76);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 16);
            this.label28.TabIndex = 45;
            this.label28.Text = "危急值上限";
            // 
            // txtCrVal1
            // 
            this.txtCrVal1.Enabled = false;
            this.txtCrVal1.Location = new System.Drawing.Point(288, 72);
            this.txtCrVal1.MaxLength = 50;
            this.txtCrVal1.Name = "txtCrVal1";
            this.txtCrVal1.Size = new System.Drawing.Size(104, 21);
            this.txtCrVal1.TabIndex = 44;
            // 
            // btnDelRef
            // 
            this.btnDelRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelRef.Enabled = false;
            this.btnDelRef.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelRef.Location = new System.Drawing.Point(748, 80);
            this.btnDelRef.Name = "btnDelRef";
            this.btnDelRef.Size = new System.Drawing.Size(75, 23);
            this.btnDelRef.TabIndex = 34;
            this.btnDelRef.Text = "删除";
            this.btnDelRef.Click += new System.EventHandler(this.btnDelRef_Click);
            // 
            // btnSaveRef
            // 
            this.btnSaveRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRef.Enabled = false;
            this.btnSaveRef.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveRef.Location = new System.Drawing.Point(748, 48);
            this.btnSaveRef.Name = "btnSaveRef";
            this.btnSaveRef.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRef.TabIndex = 33;
            this.btnSaveRef.Text = "保存";
            this.btnSaveRef.Click += new System.EventHandler(this.btnSaveRef_Click);
            // 
            // btnAddRef
            // 
            this.btnAddRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRef.Enabled = false;
            this.btnAddRef.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRef.Location = new System.Drawing.Point(748, 16);
            this.btnAddRef.Name = "btnAddRef";
            this.btnAddRef.Size = new System.Drawing.Size(75, 23);
            this.btnAddRef.TabIndex = 35;
            this.btnAddRef.Text = "新增";
            this.btnAddRef.Click += new System.EventHandler(this.btnAddRef_Click);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(32, 52);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 16);
            this.label24.TabIndex = 42;
            this.label24.Text = "月经期";
            this.label24.Visible = false;
            // 
            // m_cboMenses
            // 
            this.m_cboMenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMenses.Enabled = false;
            this.m_cboMenses.Location = new System.Drawing.Point(88, 48);
            this.m_cboMenses.Name = "m_cboMenses";
            this.m_cboMenses.Size = new System.Drawing.Size(104, 20);
            this.m_cboMenses.TabIndex = 41;
            this.m_cboMenses.Visible = false;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(32, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 40;
            this.label23.Text = "用药后";
            this.label23.Visible = false;
            // 
            // m_cboMedUsedTimeUnit
            // 
            this.m_cboMedUsedTimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedUsedTimeUnit.Enabled = false;
            this.m_cboMedUsedTimeUnit.Items.AddRange(new object[] {
            "秒",
            "分钟",
            "小时",
            "天",
            "月",
            "年"});
            this.m_cboMedUsedTimeUnit.Location = new System.Drawing.Point(136, 48);
            this.m_cboMedUsedTimeUnit.Name = "m_cboMedUsedTimeUnit";
            this.m_cboMedUsedTimeUnit.Size = new System.Drawing.Size(56, 20);
            this.m_cboMedUsedTimeUnit.TabIndex = 39;
            this.m_cboMedUsedTimeUnit.Visible = false;
            // 
            // m_txtMedUsedTime
            // 
            this.m_txtMedUsedTime.Enabled = false;
            this.m_txtMedUsedTime.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtMedUsedTime.Location = new System.Drawing.Point(88, 48);
            this.m_txtMedUsedTime.MaxLength = 5;
            this.m_txtMedUsedTime.Name = "m_txtMedUsedTime";
            this.m_txtMedUsedTime.Size = new System.Drawing.Size(48, 21);
            this.m_txtMedUsedTime.TabIndex = 38;
            this.m_txtMedUsedTime.Visible = false;
            // 
            // m_cboEndAgeUnit
            // 
            this.m_cboEndAgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboEndAgeUnit.Enabled = false;
            this.m_cboEndAgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.m_cboEndAgeUnit.Location = new System.Drawing.Point(536, 24);
            this.m_cboEndAgeUnit.Name = "m_cboEndAgeUnit";
            this.m_cboEndAgeUnit.Size = new System.Drawing.Size(40, 20);
            this.m_cboEndAgeUnit.TabIndex = 37;
            // 
            // m_cboBeginAgeUnit
            // 
            this.m_cboBeginAgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboBeginAgeUnit.Enabled = false;
            this.m_cboBeginAgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.m_cboBeginAgeUnit.Location = new System.Drawing.Point(352, 24);
            this.m_cboBeginAgeUnit.Name = "m_cboBeginAgeUnit";
            this.m_cboBeginAgeUnit.Size = new System.Drawing.Size(40, 20);
            this.m_cboBeginAgeUnit.TabIndex = 36;
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.Enabled = false;
            this.cboSex.Items.AddRange(new object[] {
            "",
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(88, 24);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(104, 20);
            this.cboSex.TabIndex = 32;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(48, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 16);
            this.label20.TabIndex = 31;
            this.label20.Text = "性别";
            // 
            // txtRef
            // 
            this.txtRef.Enabled = false;
            this.txtRef.Location = new System.Drawing.Point(88, 72);
            this.txtRef.MaxLength = 255;
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(104, 21);
            this.txtRef.TabIndex = 30;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(32, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 16);
            this.label19.TabIndex = 29;
            this.label19.Text = "参考值";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(216, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 21;
            this.label17.Text = "参考下限";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(408, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "年龄上限";
            // 
            // txtToRef
            // 
            this.txtToRef.Enabled = false;
            this.txtToRef.Location = new System.Drawing.Point(472, 48);
            this.txtToRef.MaxLength = 50;
            this.txtToRef.Name = "txtToRef";
            this.txtToRef.Size = new System.Drawing.Size(104, 21);
            this.txtToRef.TabIndex = 24;
            this.txtToRef.TextChanged += new System.EventHandler(this.m_txtRefMinMax_TextChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(408, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "参考上限";
            // 
            // txtToAge
            // 
            this.txtToAge.Enabled = false;
            this.txtToAge.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtToAge.Location = new System.Drawing.Point(472, 24);
            this.txtToAge.MaxLength = 3;
            this.txtToAge.Name = "txtToAge";
            this.txtToAge.Size = new System.Drawing.Size(64, 21);
            this.txtToAge.TabIndex = 28;
            this.txtToAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthKeyDown_OnlyInteger);
            // 
            // txtFromRef
            // 
            this.txtFromRef.Enabled = false;
            this.txtFromRef.Location = new System.Drawing.Point(288, 48);
            this.txtFromRef.MaxLength = 50;
            this.txtFromRef.Name = "txtFromRef";
            this.txtFromRef.Size = new System.Drawing.Size(104, 21);
            this.txtFromRef.TabIndex = 22;
            this.txtFromRef.TextChanged += new System.EventHandler(this.m_txtRefMinMax_TextChanged);
            // 
            // txtFromAge
            // 
            this.txtFromAge.Enabled = false;
            this.txtFromAge.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFromAge.Location = new System.Drawing.Point(288, 24);
            this.txtFromAge.MaxLength = 3;
            this.txtFromAge.Name = "txtFromAge";
            this.txtFromAge.Size = new System.Drawing.Size(64, 21);
            this.txtFromAge.TabIndex = 26;
            this.txtFromAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthKeyDown_OnlyInteger);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(216, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "年龄下限";
            // 
            // gbPara
            // 
            this.gbPara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPara.Controls.Add(this.panel1);
            this.gbPara.Controls.Add(this.m_grpRelation);
            this.gbPara.Controls.Add(this.labDiagnose);
            this.gbPara.Controls.Add(this.txtClinicMeaning);
            this.gbPara.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbPara.Location = new System.Drawing.Point(256, 248);
            this.gbPara.Name = "gbPara";
            this.gbPara.Size = new System.Drawing.Size(844, 128);
            this.gbPara.TabIndex = 4;
            this.gbPara.TabStop = false;
            this.gbPara.Text = "医学参数";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.chkQC);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cboSampleValidateTimeUnit);
            this.panel1.Controls.Add(this.txtSampleValidateTime);
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(12, 4);
            this.panel1.TabIndex = 43;
            this.panel1.Visible = false;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "样品有效时间";
            this.label15.Visible = false;
            // 
            // chkQC
            // 
            this.chkQC.Location = new System.Drawing.Point(440, 20);
            this.chkQC.Name = "chkQC";
            this.chkQC.Size = new System.Drawing.Size(88, 24);
            this.chkQC.TabIndex = 16;
            this.chkQC.Text = "质控项目";
            this.chkQC.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkReservation);
            this.groupBox1.Controls.Add(this.chkNoFood);
            this.groupBox1.Controls.Add(this.chkPhysicalExam);
            this.groupBox1.Location = new System.Drawing.Point(224, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 44);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "是否需要";
            this.groupBox1.Visible = false;
            // 
            // chkReservation
            // 
            this.chkReservation.Location = new System.Drawing.Point(136, 16);
            this.chkReservation.Name = "chkReservation";
            this.chkReservation.Size = new System.Drawing.Size(56, 24);
            this.chkReservation.TabIndex = 19;
            this.chkReservation.Text = "预约";
            // 
            // chkNoFood
            // 
            this.chkNoFood.Location = new System.Drawing.Point(8, 16);
            this.chkNoFood.Name = "chkNoFood";
            this.chkNoFood.Size = new System.Drawing.Size(56, 24);
            this.chkNoFood.TabIndex = 17;
            this.chkNoFood.Text = "空腹";
            // 
            // chkPhysicalExam
            // 
            this.chkPhysicalExam.Location = new System.Drawing.Point(72, 16);
            this.chkPhysicalExam.Name = "chkPhysicalExam";
            this.chkPhysicalExam.Size = new System.Drawing.Size(56, 24);
            this.chkPhysicalExam.TabIndex = 18;
            this.chkPhysicalExam.Text = "体检";
            // 
            // cboSampleValidateTimeUnit
            // 
            this.cboSampleValidateTimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSampleValidateTimeUnit.Items.AddRange(new object[] {
            "秒",
            "分钟",
            "小时",
            "天",
            "月",
            "年"});
            this.cboSampleValidateTimeUnit.Location = new System.Drawing.Point(160, 20);
            this.cboSampleValidateTimeUnit.Name = "cboSampleValidateTimeUnit";
            this.cboSampleValidateTimeUnit.Size = new System.Drawing.Size(56, 22);
            this.cboSampleValidateTimeUnit.TabIndex = 26;
            this.cboSampleValidateTimeUnit.Visible = false;
            // 
            // txtSampleValidateTime
            // 
            this.txtSampleValidateTime.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSampleValidateTime.Location = new System.Drawing.Point(108, 24);
            this.txtSampleValidateTime.MaxLength = 5;
            this.txtSampleValidateTime.Name = "txtSampleValidateTime";
            this.txtSampleValidateTime.Size = new System.Drawing.Size(56, 23);
            this.txtSampleValidateTime.TabIndex = 24;
            this.txtSampleValidateTime.Visible = false;
            this.txtSampleValidateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthKeyDown_OnlyInteger);
            // 
            // m_grpRelation
            // 
            this.m_grpRelation.Controls.Add(this.m_chkMedUsedTimeRelation);
            this.m_grpRelation.Controls.Add(this.m_chkSexRelation);
            this.m_grpRelation.Controls.Add(this.m_chkMensesRelation);
            this.m_grpRelation.Controls.Add(this.m_chkAgeRelation);
            this.m_grpRelation.Location = new System.Drawing.Point(16, 20);
            this.m_grpRelation.Name = "m_grpRelation";
            this.m_grpRelation.Size = new System.Drawing.Size(704, 40);
            this.m_grpRelation.TabIndex = 42;
            this.m_grpRelation.TabStop = false;
            // 
            // m_chkMedUsedTimeRelation
            // 
            this.m_chkMedUsedTimeRelation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkMedUsedTimeRelation.Location = new System.Drawing.Point(512, 12);
            this.m_chkMedUsedTimeRelation.Name = "m_chkMedUsedTimeRelation";
            this.m_chkMedUsedTimeRelation.Size = new System.Drawing.Size(176, 24);
            this.m_chkMedUsedTimeRelation.TabIndex = 40;
            this.m_chkMedUsedTimeRelation.Text = "参考值和用药时间有关";
            this.m_chkMedUsedTimeRelation.Visible = false;
            this.m_chkMedUsedTimeRelation.CheckedChanged += new System.EventHandler(this.m_chkMedUsedTimeRelation_CheckedChanged);
            // 
            // m_chkSexRelation
            // 
            this.m_chkSexRelation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkSexRelation.Location = new System.Drawing.Point(2, 14);
            this.m_chkSexRelation.Name = "m_chkSexRelation";
            this.m_chkSexRelation.Size = new System.Drawing.Size(144, 24);
            this.m_chkSexRelation.TabIndex = 38;
            this.m_chkSexRelation.Text = "参考值和性别有关";
            this.m_chkSexRelation.CheckedChanged += new System.EventHandler(this.m_chkSexRelation_CheckedChanged);
            // 
            // m_chkMensesRelation
            // 
            this.m_chkMensesRelation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkMensesRelation.Location = new System.Drawing.Point(340, 14);
            this.m_chkMensesRelation.Name = "m_chkMensesRelation";
            this.m_chkMensesRelation.Size = new System.Drawing.Size(168, 24);
            this.m_chkMensesRelation.TabIndex = 41;
            this.m_chkMensesRelation.Text = "参考值和月经周期有关";
            this.m_chkMensesRelation.Visible = false;
            this.m_chkMensesRelation.CheckedChanged += new System.EventHandler(this.m_chkMensesRelation_CheckedChanged);
            // 
            // m_chkAgeRelation
            // 
            this.m_chkAgeRelation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkAgeRelation.Location = new System.Drawing.Point(168, 14);
            this.m_chkAgeRelation.Name = "m_chkAgeRelation";
            this.m_chkAgeRelation.Size = new System.Drawing.Size(144, 24);
            this.m_chkAgeRelation.TabIndex = 39;
            this.m_chkAgeRelation.Text = "参考值和年龄有关";
            this.m_chkAgeRelation.CheckedChanged += new System.EventHandler(this.m_chkAgeRelation_CheckedChanged);
            // 
            // labDiagnose
            // 
            this.labDiagnose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labDiagnose.Location = new System.Drawing.Point(16, 64);
            this.labDiagnose.Name = "labDiagnose";
            this.labDiagnose.Size = new System.Drawing.Size(64, 16);
            this.labDiagnose.TabIndex = 3;
            this.labDiagnose.Text = "临床意义";
            // 
            // txtClinicMeaning
            // 
            this.txtClinicMeaning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClinicMeaning.Location = new System.Drawing.Point(16, 80);
            this.txtClinicMeaning.MaxLength = 255;
            this.txtClinicMeaning.Multiline = true;
            this.txtClinicMeaning.Name = "txtClinicMeaning";
            this.txtClinicMeaning.Size = new System.Drawing.Size(820, 36);
            this.txtClinicMeaning.TabIndex = 2;
            // 
            // gbBsePara
            // 
            this.gbBsePara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBsePara.Controls.Add(this.m_txtItemPrice);
            this.gbBsePara.Controls.Add(this.label26);
            this.gbBsePara.Controls.Add(this.m_txtAlarmVal);
            this.gbBsePara.Controls.Add(this.m_lbDangerousVal);
            this.gbBsePara.Controls.Add(this.m_txtAlarmValMax);
            this.gbBsePara.Controls.Add(this.m_lbDangerousValMax);
            this.gbBsePara.Controls.Add(this.m_txtAlarmValMin);
            this.gbBsePara.Controls.Add(this.m_lbDangerousValMin);
            this.gbBsePara.Controls.Add(this.m_btnValueTemplate);
            this.gbBsePara.Controls.Add(this.chkIsCalculated);
            this.gbBsePara.Controls.Add(this.m_btnFormulaWizard);
            this.gbBsePara.Controls.Add(this.m_txtDefaultRefRange);
            this.gbBsePara.Controls.Add(this.label22);
            this.gbBsePara.Controls.Add(this.label13);
            this.gbBsePara.Controls.Add(this.m_txtDefaultRefMax);
            this.gbBsePara.Controls.Add(this.label16);
            this.gbBsePara.Controls.Add(this.m_txtDefaultRefMin);
            this.gbBsePara.Controls.Add(this.m_txtAssistCodeTwo);
            this.gbBsePara.Controls.Add(this.m_txtAssistCodeOne);
            this.gbBsePara.Controls.Add(this.m_lblAssistCodeTwo);
            this.gbBsePara.Controls.Add(this.m_lblAssistCodeOne);
            this.gbBsePara.Controls.Add(this.cboResultType);
            this.gbBsePara.Controls.Add(this.label21);
            this.gbBsePara.Controls.Add(this.txtWBAss);
            this.gbBsePara.Controls.Add(this.label18);
            this.gbBsePara.Controls.Add(this.txtCheckMethod);
            this.gbBsePara.Controls.Add(this.label9);
            this.gbBsePara.Controls.Add(this.txtFormula);
            this.gbBsePara.Controls.Add(this.label8);
            this.gbBsePara.Controls.Add(this.txtUnit);
            this.gbBsePara.Controls.Add(this.txtPYAss);
            this.gbBsePara.Controls.Add(this.txtReportNO);
            this.gbBsePara.Controls.Add(this.label5);
            this.gbBsePara.Controls.Add(this.txtShortName);
            this.gbBsePara.Controls.Add(this.label4);
            this.gbBsePara.Controls.Add(this.txtEnglistName);
            this.gbBsePara.Controls.Add(this.label3);
            this.gbBsePara.Controls.Add(this.txtCheckItemNameCN);
            this.gbBsePara.Controls.Add(this.label2);
            this.gbBsePara.Controls.Add(this.label6);
            this.gbBsePara.Controls.Add(this.label7);
            this.gbBsePara.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbBsePara.Location = new System.Drawing.Point(256, 40);
            this.gbBsePara.Name = "gbBsePara";
            this.gbBsePara.Size = new System.Drawing.Size(844, 204);
            this.gbBsePara.TabIndex = 2;
            this.gbBsePara.TabStop = false;
            this.gbBsePara.Text = "基本参数";
            // 
            // m_txtItemPrice
            // 
            this.m_txtItemPrice.Location = new System.Drawing.Point(603, 144);
            this.m_txtItemPrice.Name = "m_txtItemPrice";
            this.m_txtItemPrice.Size = new System.Drawing.Size(117, 23);
            this.m_txtItemPrice.TabIndex = 44;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(535, 148);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(64, 16);
            this.label26.TabIndex = 43;
            this.label26.Text = "计费价格";
            // 
            // m_txtAlarmVal
            // 
            this.m_txtAlarmVal.Location = new System.Drawing.Point(472, 120);
            this.m_txtAlarmVal.MaxLength = 255;
            this.m_txtAlarmVal.Name = "m_txtAlarmVal";
            this.m_txtAlarmVal.Size = new System.Drawing.Size(248, 23);
            this.m_txtAlarmVal.TabIndex = 42;
            // 
            // m_lbDangerousVal
            // 
            this.m_lbDangerousVal.Location = new System.Drawing.Point(420, 124);
            this.m_lbDangerousVal.Name = "m_lbDangerousVal";
            this.m_lbDangerousVal.Size = new System.Drawing.Size(48, 16);
            this.m_lbDangerousVal.TabIndex = 41;
            this.m_lbDangerousVal.Text = "危险值";
            // 
            // m_txtAlarmValMax
            // 
            this.m_txtAlarmValMax.Location = new System.Drawing.Point(280, 120);
            this.m_txtAlarmValMax.MaxLength = 50;
            this.m_txtAlarmValMax.Name = "m_txtAlarmValMax";
            this.m_txtAlarmValMax.Size = new System.Drawing.Size(104, 23);
            this.m_txtAlarmValMax.TabIndex = 40;
            this.m_txtAlarmValMax.TextChanged += new System.EventHandler(this.m_txtAlarmValMax_TextChanged);
            // 
            // m_lbDangerousValMax
            // 
            this.m_lbDangerousValMax.AutoSize = true;
            this.m_lbDangerousValMax.Location = new System.Drawing.Point(202, 124);
            this.m_lbDangerousValMax.Name = "m_lbDangerousValMax";
            this.m_lbDangerousValMax.Size = new System.Drawing.Size(77, 14);
            this.m_lbDangerousValMax.TabIndex = 39;
            this.m_lbDangerousValMax.Text = "危急值上限";
            // 
            // m_txtAlarmValMin
            // 
            this.m_txtAlarmValMin.Location = new System.Drawing.Point(88, 120);
            this.m_txtAlarmValMin.MaxLength = 50;
            this.m_txtAlarmValMin.Name = "m_txtAlarmValMin";
            this.m_txtAlarmValMin.Size = new System.Drawing.Size(112, 23);
            this.m_txtAlarmValMin.TabIndex = 38;
            this.m_txtAlarmValMin.TextChanged += new System.EventHandler(this.m_txtAlarmValMin_TextChanged);
            // 
            // m_lbDangerousValMin
            // 
            this.m_lbDangerousValMin.AutoSize = true;
            this.m_lbDangerousValMin.Location = new System.Drawing.Point(2, 124);
            this.m_lbDangerousValMin.Name = "m_lbDangerousValMin";
            this.m_lbDangerousValMin.Size = new System.Drawing.Size(77, 14);
            this.m_lbDangerousValMin.TabIndex = 37;
            this.m_lbDangerousValMin.Text = "危急值下限";
            // 
            // m_btnValueTemplate
            // 
            this.m_btnValueTemplate.Location = new System.Drawing.Point(516, 20);
            this.m_btnValueTemplate.Name = "m_btnValueTemplate";
            this.m_btnValueTemplate.Size = new System.Drawing.Size(204, 24);
            this.m_btnValueTemplate.TabIndex = 36;
            this.m_btnValueTemplate.Text = "值模板";
            this.m_btnValueTemplate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.m_btnValueTemplate.Click += new System.EventHandler(this.m_btnValueTemplate_Click);
            // 
            // chkIsCalculated
            // 
            this.chkIsCalculated.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsCalculated.Location = new System.Drawing.Point(404, 24);
            this.chkIsCalculated.Name = "chkIsCalculated";
            this.chkIsCalculated.Size = new System.Drawing.Size(84, 24);
            this.chkIsCalculated.TabIndex = 35;
            this.chkIsCalculated.Text = "计算项目";
            this.chkIsCalculated.CheckedChanged += new System.EventHandler(this.chkIsCalculated_CheckedChanged);
            // 
            // m_btnFormulaWizard
            // 
            this.m_btnFormulaWizard.Enabled = false;
            this.m_btnFormulaWizard.Location = new System.Drawing.Point(430, 144);
            this.m_btnFormulaWizard.Name = "m_btnFormulaWizard";
            this.m_btnFormulaWizard.Size = new System.Drawing.Size(96, 24);
            this.m_btnFormulaWizard.TabIndex = 34;
            this.m_btnFormulaWizard.Text = "公式向导...";
            this.m_btnFormulaWizard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.m_btnFormulaWizard.Click += new System.EventHandler(this.m_btnFormulaWizard_Click);
            // 
            // m_txtDefaultRefRange
            // 
            this.m_txtDefaultRefRange.Location = new System.Drawing.Point(472, 96);
            this.m_txtDefaultRefRange.MaxLength = 255;
            this.m_txtDefaultRefRange.Name = "m_txtDefaultRefRange";
            this.m_txtDefaultRefRange.Size = new System.Drawing.Size(248, 23);
            this.m_txtDefaultRefRange.TabIndex = 33;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(418, 101);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 16);
            this.label22.TabIndex = 32;
            this.label22.Text = "参考值";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 28;
            this.label13.Text = "参考下限";
            // 
            // m_txtDefaultRefMax
            // 
            this.m_txtDefaultRefMax.Location = new System.Drawing.Point(280, 96);
            this.m_txtDefaultRefMax.MaxLength = 50;
            this.m_txtDefaultRefMax.Name = "m_txtDefaultRefMax";
            this.m_txtDefaultRefMax.Size = new System.Drawing.Size(104, 23);
            this.m_txtDefaultRefMax.TabIndex = 31;
            this.m_txtDefaultRefMax.TextChanged += new System.EventHandler(this.m_txtDefaultRefMinMax_TextChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(216, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 30;
            this.label16.Text = "参考上限";
            // 
            // m_txtDefaultRefMin
            // 
            this.m_txtDefaultRefMin.Location = new System.Drawing.Point(88, 96);
            this.m_txtDefaultRefMin.MaxLength = 50;
            this.m_txtDefaultRefMin.Name = "m_txtDefaultRefMin";
            this.m_txtDefaultRefMin.Size = new System.Drawing.Size(112, 23);
            this.m_txtDefaultRefMin.TabIndex = 29;
            this.m_txtDefaultRefMin.TextChanged += new System.EventHandler(this.m_txtDefaultRefMinMax_TextChanged);
            // 
            // m_txtAssistCodeTwo
            // 
            this.m_txtAssistCodeTwo.Location = new System.Drawing.Point(648, 72);
            this.m_txtAssistCodeTwo.Name = "m_txtAssistCodeTwo";
            this.m_txtAssistCodeTwo.Size = new System.Drawing.Size(72, 23);
            this.m_txtAssistCodeTwo.TabIndex = 27;
            // 
            // m_txtAssistCodeOne
            // 
            this.m_txtAssistCodeOne.Location = new System.Drawing.Point(648, 48);
            this.m_txtAssistCodeOne.Name = "m_txtAssistCodeOne";
            this.m_txtAssistCodeOne.Size = new System.Drawing.Size(72, 23);
            this.m_txtAssistCodeOne.TabIndex = 26;
            // 
            // m_lblAssistCodeTwo
            // 
            this.m_lblAssistCodeTwo.Location = new System.Drawing.Point(568, 76);
            this.m_lblAssistCodeTwo.Name = "m_lblAssistCodeTwo";
            this.m_lblAssistCodeTwo.Size = new System.Drawing.Size(80, 16);
            this.m_lblAssistCodeTwo.TabIndex = 24;
            this.m_lblAssistCodeTwo.Text = "第二助记码";
            // 
            // m_lblAssistCodeOne
            // 
            this.m_lblAssistCodeOne.Location = new System.Drawing.Point(568, 51);
            this.m_lblAssistCodeOne.Name = "m_lblAssistCodeOne";
            this.m_lblAssistCodeOne.Size = new System.Drawing.Size(80, 16);
            this.m_lblAssistCodeOne.TabIndex = 23;
            this.m_lblAssistCodeOne.Text = "第一助记码";
            // 
            // cboResultType
            // 
            this.cboResultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResultType.Items.AddRange(new object[] {
            "数值型",
            "文字型",
            "阴阳型",
            "图形型"});
            this.cboResultType.Location = new System.Drawing.Point(280, 24);
            this.cboResultType.Name = "cboResultType";
            this.cboResultType.Size = new System.Drawing.Size(104, 22);
            this.cboResultType.TabIndex = 21;
            this.cboResultType.SelectedIndexChanged += new System.EventHandler(this.cboResultType_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(216, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 16);
            this.label21.TabIndex = 20;
            this.label21.Text = "结果类型";
            // 
            // txtWBAss
            // 
            this.txtWBAss.Location = new System.Drawing.Point(472, 72);
            this.txtWBAss.MaxLength = 10;
            this.txtWBAss.Name = "txtWBAss";
            this.txtWBAss.Size = new System.Drawing.Size(88, 23);
            this.txtWBAss.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(392, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 18;
            this.label18.Text = "五笔助记符";
            // 
            // txtCheckMethod
            // 
            this.txtCheckMethod.Location = new System.Drawing.Point(88, 168);
            this.txtCheckMethod.MaxLength = 255;
            this.txtCheckMethod.Name = "txtCheckMethod";
            this.txtCheckMethod.Size = new System.Drawing.Size(632, 23);
            this.txtCheckMethod.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "检测方法";
            // 
            // txtFormula
            // 
            this.txtFormula.Enabled = false;
            this.txtFormula.Location = new System.Drawing.Point(88, 144);
            this.txtFormula.MaxLength = 255;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.ReadOnly = true;
            this.txtFormula.Size = new System.Drawing.Size(340, 23);
            this.txtFormula.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "计算公式";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(280, 72);
            this.txtUnit.MaxLength = 10;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(104, 23);
            this.txtUnit.TabIndex = 13;
            // 
            // txtPYAss
            // 
            this.txtPYAss.Location = new System.Drawing.Point(472, 48);
            this.txtPYAss.MaxLength = 10;
            this.txtPYAss.Name = "txtPYAss";
            this.txtPYAss.Size = new System.Drawing.Size(88, 23);
            this.txtPYAss.TabIndex = 11;
            // 
            // txtReportNO
            // 
            this.txtReportNO.Location = new System.Drawing.Point(88, 72);
            this.txtReportNO.MaxLength = 25;
            this.txtReportNO.Name = "txtReportNO";
            this.txtReportNO.Size = new System.Drawing.Size(112, 23);
            this.txtReportNO.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "报告代号";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(280, 48);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(104, 23);
            this.txtShortName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(216, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "缩    写";
            // 
            // txtEnglistName
            // 
            this.txtEnglistName.Location = new System.Drawing.Point(88, 48);
            this.txtEnglistName.MaxLength = 50;
            this.txtEnglistName.Name = "txtEnglistName";
            this.txtEnglistName.Size = new System.Drawing.Size(112, 23);
            this.txtEnglistName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "英文名称";
            // 
            // txtCheckItemNameCN
            // 
            this.txtCheckItemNameCN.Location = new System.Drawing.Point(88, 24);
            this.txtCheckItemNameCN.MaxLength = 50;
            this.txtCheckItemNameCN.Name = "txtCheckItemNameCN";
            this.txtCheckItemNameCN.Size = new System.Drawing.Size(112, 23);
            this.txtCheckItemNameCN.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "检验名称";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(216, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "单    位";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(392, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "拼音助记符";
            // 
            // lsvCheckItemDetail
            // 
            this.lsvCheckItemDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lsvCheckItemDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4});
            this.lsvCheckItemDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvCheckItemDetail.FullRowSelect = true;
            this.lsvCheckItemDetail.HideSelection = false;
            this.lsvCheckItemDetail.Location = new System.Drawing.Point(16, 48);
            this.lsvCheckItemDetail.MultiSelect = false;
            this.lsvCheckItemDetail.Name = "lsvCheckItemDetail";
            this.lsvCheckItemDetail.Size = new System.Drawing.Size(232, 560);
            this.lsvCheckItemDetail.TabIndex = 1;
            this.lsvCheckItemDetail.UseCompatibleStateImageBehavior = false;
            this.lsvCheckItemDetail.View = System.Windows.Forms.View.Details;
            this.lsvCheckItemDetail.SelectedIndexChanged += new System.EventHandler(this.lsvCheckItemDetail_Click);
            this.lsvCheckItemDetail.Click += new System.EventHandler(this.lsvCheckItemDetail_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "检验项目名称";
            this.columnHeader1.Width = 145;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "英文名称";
            this.columnHeader4.Width = 80;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "检验类别";
            // 
            // cboCheckCategory
            // 
            this.cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboCheckCategory.Location = new System.Drawing.Point(80, 16);
            this.cboCheckCategory.Name = "cboCheckCategory";
            this.cboCheckCategory.Size = new System.Drawing.Size(104, 22);
            this.cboCheckCategory.TabIndex = 1;
            this.cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.cboCheckCategory_SelectedIndexChanged);
            // 
            // cboSampleType
            // 
            this.cboSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSampleType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSampleType.Location = new System.Drawing.Point(256, 16);
            this.cboSampleType.Name = "cboSampleType";
            this.cboSampleType.Size = new System.Drawing.Size(104, 22);
            this.cboSampleType.TabIndex = 39;
            this.cboSampleType.SelectedIndexChanged += new System.EventHandler(this.cboSampleType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(192, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 16);
            this.label14.TabIndex = 38;
            this.label14.Text = "样本类别";
            // 
            // btnYgCrivalue
            // 
            this.btnYgCrivalue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYgCrivalue.Location = new System.Drawing.Point(16, 616);
            this.btnYgCrivalue.Name = "btnYgCrivalue";
            this.btnYgCrivalue.Size = new System.Drawing.Size(232, 23);
            this.btnYgCrivalue.TabIndex = 46;
            this.btnYgCrivalue.Text = "院感危急值";
            this.btnYgCrivalue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnYgCrivalue.Click += new System.EventHandler(this.btnYgCrivalue_Click);
            // 
            // m_cboSampleGroup
            // 
            this.m_cboSampleGroup.DisplayMember = "SAMPLE_GROUP_NAME_CHR";
            this.m_cboSampleGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSampleGroup.Location = new System.Drawing.Point(424, 16);
            this.m_cboSampleGroup.Name = "m_cboSampleGroup";
            this.m_cboSampleGroup.Size = new System.Drawing.Size(121, 22);
            this.m_cboSampleGroup.TabIndex = 43;
            this.m_cboSampleGroup.ValueMember = "SAMPLE_GROUP_ID_CHR";
            this.m_cboSampleGroup.SelectedIndexChanged += new System.EventHandler(this.m_cboSampleGroup_SelectedIndexChanged);
            // 
            // frmAddCheckItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1108, 651);
            this.Controls.Add(this.btnYgCrivalue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.m_cboSampleGroup);
            this.Controls.Add(this.btnAddCheckItem);
            this.Controls.Add(this.btnDelCheckItem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lsvSampleRef);
            this.Controls.Add(this.gbItemRef);
            this.Controls.Add(this.gbPara);
            this.Controls.Add(this.gbBsePara);
            this.Controls.Add(this.lsvCheckItemDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCheckCategory);
            this.Controls.Add(this.cboSampleType);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmAddCheckItem";
            this.ShowInTaskbar = false;
            this.Text = "检验项目";
            this.Deactivate += new System.EventHandler(this.frmAddCheckItem_Deactivate);
            this.Load += new System.EventHandler(this.frmAddCheckItem_Load);
            this.Closed += new System.EventHandler(this.frmAddCheckItem_Closed);
            this.gbItemRef.ResumeLayout(false);
            this.gbItemRef.PerformLayout();
            this.gbPara.ResumeLayout(false);
            this.gbPara.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.m_grpRelation.ResumeLayout(false);
            this.gbBsePara.ResumeLayout(false);
            this.gbBsePara.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //		[STAThread]
        //		static void Main() 
        //		{
        //			Application.Run(new frmAddCheckItem());
        //		} 

        public override void CreateController()
        {
            this.objController = new clsController_addCheckItem();
            this.objController.Set_GUI_Apperance(this);
        }

        #endregion

        #region 初始化信息
        private void frmAddCheckItem_Load(object sender, System.EventArgs e)
        {
            //获取所有的检验类别
            ((clsController_addCheckItem)this.objController).QryAllCheckCategory(out dtbAllCheckCategory);
            int count = dtbAllCheckCategory.Rows.Count;
            if (count > 0)
            {
                cboCheckCategory.DataSource = dtbAllCheckCategory;
                cboCheckCategory.DisplayMember = "CHECK_CATEGORY_DESC_VCHR";
                cboCheckCategory.ValueMember = "CHECK_CATEGORY_ID_CHR";
            }
            //获取所有的样本类型
            ((clsController_addCheckItem)this.objController).QryAllSampleType(out dtbAllSampleType);
            count = dtbAllSampleType.Rows.Count;
            if (count > 0)
            {
                cboSampleType.DataSource = dtbAllSampleType;
                cboSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
                cboSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
            }
            //初始化月经周期下拉列表
            ((clsController_addCheckItem)this.objController).m_lngGetAllMenses(this);
            this.cboResultType.SelectedIndex = 0;
            this.ResetAll();
            string strCategory = null;
            string strSampleType = null;
            if (this.cboCheckCategory.SelectedValue != null)
                strCategory = this.cboCheckCategory.SelectedValue.ToString().Trim();
            if (this.cboSampleType.SelectedValue != null)
                strSampleType = this.cboSampleType.SelectedValue.ToString().Trim();
            this.m_cboSampleGroup.m_mthShowStateByCategoryAndType(strCategory, strSampleType);
            this.m_blnInit = false;
            if (this.cboCheckCategory.Items.Count > 0 && this.cboSampleType.Items.Count > 0)
            {
                ((clsController_addCheckItem)this.objController).m_mthrefreshCheckItemList();
            }
            //			refreshCheckItemList();
        }
        #endregion

        #region 显示检验项目的明细
        private void lsvCheckItemDetail_Click(object sender, System.EventArgs e)
        {
            if (lsvCheckItemDetail.SelectedItems.Count > 0)
            {
                this.ResetAll();
                DataRow dr = (DataRow)this.lsvCheckItemDetail.SelectedItems[0].Tag;
                string Check_Item_ID = dr["CHECK_ITEM_ID_CHR"].ToString().Trim();
                txtCheckItemNameCN.Text = dr["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
                txtEnglistName.Text = dr["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim();
                txtShortName.Text = dr["SHORTNAME_CHR"].ToString().Trim();
                txtPYAss.Text = dr["PYCODE_CHR"].ToString().Trim();
                txtReportNO.Text = dr["RPTNO_CHR"].ToString().Trim();
                txtUnit.Text = dr["UNIT_CHR"].ToString().Trim();
                txtWBAss.Text = dr["WBCODE_CHR"].ToString().Trim();
                txtFormula.Text = dr["FORMULA_USER_VCHR"].ToString().Trim();
                txtCheckMethod.Text = dr["TEST_METHODS_VCHR"].ToString().Trim();
                txtSampleValidateTime.Text = dr["SAMPLE_VALID_TIME_DEC"].ToString().Trim();
                txtClinicMeaning.Text = dr["CLINIC_MEANING_VCHR"].ToString().Trim();
                txtSampleValidateTime.Text = dr["SAMPLE_VALID_TIME_DEC"].ToString().Trim();
                if (dr["IS_NO_FOOD_REQUIRED_CHR"].ToString().Trim() == "1")
                {
                    chkNoFood.Checked = true;
                }
                if (dr["IS_PHYSICAL_EXAM_REQUIRED_CHR"].ToString().Trim() == "1")
                {
                    chkPhysicalExam.Checked = true;
                }
                if (dr["IS_RESERVATION_REQUIRED_CHR"].ToString().Trim() == "1")
                {
                    chkReservation.Checked = true;
                }
                if (dr["IS_QC_REQUIRED_CHR"].ToString().Trim() == "1")
                {
                    chkQC.Checked = true;
                }
                string ResultType = dr["RESULTTYPE_CHR"].ToString().Trim();
                if (ResultType == "0")
                {
                    cboResultType.SelectedIndex = 0;
                }
                else if (ResultType == "1")
                {
                    cboResultType.SelectedIndex = 1;
                }
                else if (ResultType == "2")
                {
                    cboResultType.SelectedIndex = 2;
                }
                else if (ResultType == "3")
                {
                    cboResultType.SelectedIndex = 3;
                }
                if (dr["IS_CALCULATED_CHR"].ToString().Trim() == "1")
                {
                    this.chkIsCalculated.Checked = true;
                }
                else
                {
                    this.chkIsCalculated.Checked = false;
                }

                if (dr["IS_MENSES_RELATED_CHR"].ToString().Trim() == "1")
                {
                    this.m_chkMensesRelation.Checked = true;
                }
                else
                {
                    this.m_chkMensesRelation.Checked = false;
                }

                if (dr["IS_SEX_RELATED_CHR"].ToString().Trim() == "1")
                {
                    this.m_chkSexRelation.Checked = true;
                }
                else
                {
                    this.m_chkSexRelation.Checked = false;
                }

                if (dr["IS_AGE_RELATED_CHR"].ToString().Trim() == "1")
                {
                    this.m_chkAgeRelation.Checked = true;
                }
                else
                {
                    this.m_chkAgeRelation.Checked = false;
                }

                m_txtAssistCodeOne.Text = dr["ASSIST_CODE01_CHR"].ToString().Trim();
                m_txtAssistCodeTwo.Text = dr["ASSIST_CODE02_CHR"].ToString().Trim();
                m_txtDefaultRefMin.Text = dr["REF_MIN_VAL_VCHR"].ToString().Trim();
                m_txtDefaultRefMax.Text = dr["REF_MAX_VAL_VCHR"].ToString().Trim();
                m_txtDefaultRefRange.Text = dr["REF_VALUE_RANGE_VCHR"].ToString().Trim();
                m_txtAlarmValMin.Text = dr["ALARM_LOW_VAL_VCHR"].ToString().Trim();
                m_txtAlarmValMax.Text = dr["ALARM_UP_VAL_VCHR"].ToString().Trim();
                m_txtAlarmVal.Text = dr["ALERT_VALUE_RANGE_VCHR"].ToString().Trim();
                m_txtItemPrice.Text = dr["itemprice_mny"].ToString().Trim();

                //是否是计算项目 童华 2004.07.16
                if (dr["IS_CALCULATED_CHR"].ToString().Trim() == "1")
                {
                    this.chkIsCalculated.Checked = true;
                    m_strFormula = dr["FORMULA_VCHR"].ToString().Trim();
                    m_strUserFormula = dr["FORMULA_USER_VCHR"].ToString().Trim();
                }

                //根据check_item_id获取属于该检验项目的所有参考值
                ((clsController_addCheckItem)this.objController).QryItemRefByCheckItemID(this);
                #region old
                //				int count = dtbItemRef.Rows.Count;
                //				if(count > 0)
                //				{
                //					for(int i=0;i<count;i++)
                //					{
                //						ListViewItem objLsvItem = new ListViewItem();
                //						objLsvItem.Text = dtbItemRef.Rows[i]["SEQ_INT"].ToString().Trim();
                //						objLsvItem.SubItems.Add(dtbItemRef.Rows[i]["SEX_VCHR"].ToString().Trim());
                //						objLsvItem.SubItems.Add(dtbItemRef.Rows[i]["FROM_AGE_DEC"].ToString().Trim());
                //						objLsvItem.SubItems.Add(dtbItemRef.Rows[i]["TO_AGE_DEC"].ToString().Trim());
                //						objLsvItem.SubItems.Add(dtbItemRef.Rows[i]["REF_VALUE_RANGE_VCHR"].ToString().Trim());
                //						objLsvItem.SubItems.Add(dtbItemRef.Rows[i]["MIN_VAL_VCHR"].ToString().Trim());
                //						objLsvItem.SubItems.Add(dtbItemRef.Rows[i]["MAX_VAL_VCHR"].ToString().Trim());
                //						objLsvItem.Tag = dtbItemRef.Rows[i];
                //						lsvSampleRef.Items.Add(objLsvItem);
                //					}
                //					//样品参考值范围默认第一行数据
                //					FindSelectItem(cboSampleType,dtbItemRef.Rows[0]["SAMPLETYPE_VCHR"].ToString().Trim());
                //					FindSelectItem(cboSex,dtbItemRef.Rows[0]["SEX_VCHR"].ToString().Trim());
                //					txtFromAge.Text = dtbItemRef.Rows[0]["FROM_AGE_DEC"].ToString().Trim();
                //					txtToAge.Text = dtbItemRef.Rows[0]["TO_AGE_DEC"].ToString().Trim();
                //					txtFromRef.Text = dtbItemRef.Rows[0]["MIN_VAL_VCHR"].ToString().Trim();
                //					txtToRef.Text = dtbItemRef.Rows[0]["MAX_VAL_VCHR"].ToString().Trim();
                //				}
                #endregion

                if (objfrmValueTemplate.m_blnIsOpen)
                {
                    objfrmValueTemplate.m_mthInitTemplate(this.cboCheckCategory.SelectedValue.ToString().Trim(), this.cboSampleType.SelectedValue.ToString().Trim(),
                        ((DataRow)this.lsvCheckItemDetail.SelectedItems[0].Tag)["CHECK_ITEM_ID_CHR"].ToString().Trim(),
                        ((DataRow)this.lsvCheckItemDetail.SelectedItems[0].Tag)["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
                }

                btnSave.Text = "修改";
            }
        }
        #endregion

        #region Reset
        private void ResetAll()
        {
            bool blnTemp = this.m_blnInit;
            this.m_blnInit = true;
            txtCheckItemNameCN.Text = "";
            txtEnglistName.Text = "";
            txtShortName.Text = "";
            txtPYAss.Text = "";
            txtReportNO.Text = "";
            txtUnit.Text = "";
            txtWBAss.Text = "";
            txtFormula.Text = "";
            txtCheckMethod.Text = "";
            txtSampleValidateTime.Text = "";
            txtClinicMeaning.Text = "";
            txtRef.Text = "";
            chkNoFood.Checked = false;
            chkPhysicalExam.Checked = false;
            chkReservation.Checked = false;
            chkQC.Checked = false;
            lsvSampleRef.Items.Clear();
            txtFromAge.Text = "";
            txtToAge.Text = "";
            txtFromRef.Text = "";
            txtToRef.Text = "";
            txtRef.Text = "";
            this.btnSave.Text = "保存";
            intSEQ = 1;

            cboSex.SelectedIndex = 0;
            cboSampleValidateTimeUnit.SelectedIndex = 2;
            cboResultType.SelectedIndex = 0;
            //			cboSampleType.SelectedIndex = 0;
            //			cboCheckCategory.SelectedIndex = 0;

            m_txtAssistCodeOne.Text = "";
            m_txtAssistCodeTwo.Text = "";
            m_txtDefaultRefMax.Text = "";
            m_txtDefaultRefMin.Text = "";
            m_txtDefaultRefRange.Text = "";
            m_cboBeginAgeUnit.SelectedIndex = 0;
            m_cboEndAgeUnit.SelectedIndex = 0;
            m_chkSexRelation.Checked = false;
            m_chkAgeRelation.Checked = false;
            m_chkMedUsedTimeRelation.Checked = false;
            m_chkMensesRelation.Checked = false;

            m_strFormula = "";
            m_strUserFormula = "";

            this.m_txtAlarmVal.Clear();
            this.m_txtAlarmValMax.Clear();
            this.m_txtAlarmValMin.Clear();

            this.txtCrVal1.Clear();
            this.txtCrVal2.Clear();
            this.lstDepts.Items.Clear();

            //			lsvCheckItemDetail.SelectedItems[0].BackColor = System.Drawing.Color.White;
            this.m_blnInit = blnTemp;
        }
        #endregion

        #region 显示检验项目参考值明细
        private void lsvSampleRef_Click(object sender, System.EventArgs e)
        {
            if (lsvSampleRef.SelectedItems.Count > 0)
            {
                //				if(lsvCheckItemDetail.Tag != null)
                //				{
                //					ResetItemRef();
                //					DataRow dr = (DataRow)lsvSampleRef.SelectedItems[0].Tag;
                //
                //					string [] strFromAgeArr = dr["FROM_AGE_DEC"].ToString().Trim().Split(new char[]{' '});
                //					if(strFromAgeArr != null && strFromAgeArr.Length == 2)
                //					{
                //						txtFromAge.Text = strFromAgeArr[0];
                //						m_cboBeginAgeUnit.Text = strFromAgeArr[1];
                //					}
                //
                //					string [] strToAgeArr = dr["TO_AGE_DEC"].ToString().Trim().Split(new char[]{' '});
                //					if(strToAgeArr != null && strToAgeArr.Length == 2)
                //					{
                //						txtToAge.Text = strToAgeArr[0];
                //						m_cboEndAgeUnit.Text = strToAgeArr[1];
                //					}
                //					
                //					txtFromRef.Text = dr["MIN_VAL_VCHR"].ToString().Trim();
                //					txtToRef.Text = dr["MAX_VAL_VCHR"].ToString().Trim();
                //					txtRef.Text = dr["REF_VALUE_RANGE_VCHR"].ToString().Trim();
                //					FindSelectItem(cboSex,dr["SEX_VCHR"].ToString().Trim());
                //					btnSaveRef.Text = "修改";
                //				}
                //				else
                //				{
                //					//新增时修改样本参考值
                //					ResetItemRef();
                //					int index = lsvSampleRef.SelectedItems[0].Index;
                //					
                //					txtFromRef.Text = lsvSampleRef.SelectedItems[0].SubItems[5].Text;
                //
                //					string [] strFromAgeArr = lsvSampleRef.SelectedItems[0].SubItems[2].Text.Split(new char[]{' '});
                //					if(strFromAgeArr != null && strFromAgeArr.Length == 2)
                //					{
                //						txtFromAge.Text = strFromAgeArr[0];
                //						m_cboBeginAgeUnit.Text = strFromAgeArr[1];
                //					}
                //
                //					string [] strToAgeArr = lsvSampleRef.SelectedItems[0].SubItems[3].Text.Split(new char[]{' '});
                //					if(strToAgeArr != null && strToAgeArr.Length == 2)
                //					{
                //						txtToAge.Text = strToAgeArr[0];
                //						m_cboEndAgeUnit.Text = strToAgeArr[1];
                //					}
                //
                //					txtToRef.Text = lsvSampleRef.SelectedItems[0].SubItems[6].Text;
                //					txtRef.Text = lsvSampleRef.SelectedItems[0].SubItems[4].Text;
                //					FindSelectItem(cboSex,lsvSampleRef.SelectedItems[0].SubItems[1].Text);
                //					btnSaveRef.Text = "修改";
                //				}
                ResetItemRef();
                btnSaveRef.Text = "修改";
                if (this.m_chkAgeRelation.Checked)
                {
                    string[] strFromAgeArr = lsvSampleRef.SelectedItems[0].SubItems[2].Text.Split(new char[] { ' ' });
                    if (strFromAgeArr != null && strFromAgeArr.Length == 2)
                    {
                        txtFromAge.Text = strFromAgeArr[0];
                        m_cboBeginAgeUnit.Text = strFromAgeArr[1];
                    }

                    string[] strToAgeArr = lsvSampleRef.SelectedItems[0].SubItems[3].Text.Split(new char[] { ' ' });
                    if (strToAgeArr != null && strToAgeArr.Length == 2)
                    {
                        txtToAge.Text = strToAgeArr[0];
                        m_cboEndAgeUnit.Text = strToAgeArr[1];
                    }
                }
                if (this.m_chkMensesRelation.Checked)
                {
                    this.m_cboMenses.Text = lsvSampleRef.SelectedItems[0].SubItems[4].Text.ToString().Trim();
                }
                if (this.m_chkSexRelation.Checked)
                {
                    this.cboSex.Text = lsvSampleRef.SelectedItems[0].SubItems[1].Text.ToString().Trim();
                }
                this.txtFromRef.Text = lsvSampleRef.SelectedItems[0].SubItems[6].Text.ToString().Trim();
                this.txtToRef.Text = lsvSampleRef.SelectedItems[0].SubItems[7].Text.ToString().Trim();
                this.txtRef.Text = lsvSampleRef.SelectedItems[0].SubItems[8].Text.ToString().Trim();
                this.txtCrVal1.Text = lsvSampleRef.SelectedItems[0].SubItems[9].Text;
                this.txtCrVal2.Text = lsvSampleRef.SelectedItems[0].SubItems[10].Text;
                string deptNames = lsvSampleRef.SelectedItems[0].SubItems[11].Text;
                if (!string.IsNullOrEmpty(deptNames))
                {
                    this.lstDepts.Items.AddRange(deptNames.Split(','));
                }
            }
        }
        #endregion

        #region ReSetCheckItemRef
        private void ResetItemRef()
        {
            txtFromAge.Text = "";
            txtToAge.Text = "";
            txtFromRef.Text = "";
            txtToRef.Text = "";
            txtRef.Text = "";
            m_cboBeginAgeUnit.SelectedIndex = 0;
            m_cboEndAgeUnit.SelectedIndex = 0;
            cboSex.SelectedIndex = 0;
            txtCrVal1.Text = string.Empty;
            txtCrVal2.Text = string.Empty;
            this.lstDepts.Items.Clear();
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (txtCheckItemNameCN.Text.ToString().Trim() == "")
            {
                MessageBox.Show("检验项目名不能为空", "检验项目", MessageBoxButtons.OK);
                txtCheckItemNameCN.Focus();
                return;
            }

            //判断参考值与性别、年龄、月经周期的关系
            if (this.btnSaveRef.Enabled == true)
            {
                if (this.lsvSampleRef.Items.Count == 0)
                {
                    MessageBox.Show("请输入参考值范围明细资料", "参考值", MessageBoxButtons.OK);
                    return;
                }
            }

            if (this.lsvSampleRef.Items.Count > 0)
            {
                int count = lsvSampleRef.Items.Count;
                //判断参考值范围是否合法
                for (int i = 0; i < count; i++)
                {
                    ListViewItem objLsvItemRef = lsvSampleRef.Items[i];

                    if (m_chkAgeRelation.Checked)
                    {
                        if (objLsvItemRef.SubItems[2].Text.ToString().Trim() == "")
                        {
                            MessageBox.Show("请输入年龄下限!", "参考值", MessageBoxButtons.OK);
                            return;
                        }
                        if (objLsvItemRef.SubItems[3].Text.ToString().Trim() == "")
                        {
                            MessageBox.Show("请输入年龄上限!", "参考值", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    if (m_chkMedUsedTimeRelation.Checked)
                    {
                        if (objLsvItemRef.SubItems[5].Text.ToString().Trim() == "")
                        {
                            MessageBox.Show("请输入用药时间!", "参考值", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    if (m_chkSexRelation.Checked)
                    {
                        if (objLsvItemRef.SubItems[1].Text.ToString().Trim() == "")
                        {
                            MessageBox.Show("请输入性别!", "参考值", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    if (m_chkMensesRelation.Checked)
                    {
                        if (objLsvItemRef.SubItems[4].Text.ToString().Trim() == "")
                        {
                            MessageBox.Show("请输入月经期!", "参考值", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }
            }
            else
            {
                if (this.btnSaveRef.Enabled == true)
                {
                    MessageBox.Show("请输入参考值范围", "参考值", MessageBoxButtons.OK);
                    return;
                }

            }
            long lngRes = 0;

            if (this.chkIsCalculated.Checked)
            {
                if (m_strFormula == null || m_strFormula == "")
                {
                    MessageBox.Show("请输入计算公式！");
                    return;
                }
            }

            if (btnSave.Text == "修改")
            {
                #region 修改
                ((clsController_addCheckItem)this.objController).m_mthSetCheckItemBaseInfo();
                #endregion
            }
            else if (btnSave.Text == "保存")
            {
                #region 保存
                lngRes = ((clsController_addCheckItem)this.objController).m_lngAddCheckItemAndItemRef(this);
                #endregion
            }
        }
        #endregion

        #region 保存参考值明细
        private void btnSaveRef_Click(object sender, System.EventArgs e)
        {
            string strMinVal = txtFromRef.Text.ToString().Trim();
            string strFromAge = txtFromAge.Text.ToString().Trim();
            string strToAge = txtToAge.Text.ToString().Trim();

            if (this.m_chkAgeRelation.Checked)
            {
                if (strFromAge == null || strFromAge.Trim() == "")
                {
                    MessageBox.Show("请输入年龄下限", "参考值", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    strFromAge = strFromAge + " " + this.m_cboBeginAgeUnit.Text.Trim();
                }

                if (strToAge == null || strToAge.Trim() == "")
                {
                    MessageBox.Show("请输入年龄上限", "参考值", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    strToAge = strToAge + " " + this.m_cboEndAgeUnit.Text.Trim();
                }
            }

            string strMenses = this.m_cboMenses.Text.ToString().Trim();
            string strMedUseTime = this.m_txtMedUsedTime.Text.ToString().Trim();
            string strRefVal = txtRef.Text.ToString().Trim();
            //			string strSampleType = cboSampleType.Text.ToString().Trim();
            string strSex = cboSex.Text.ToString().Trim();
            string strMaxVal = txtToRef.Text.ToString().Trim();
            string crVal1 = txtCrVal1.Text.Trim();
            string crVal2 = txtCrVal2.Text.Trim();
            //			long flag = 0;
            string deptNames = string.Empty;

            if (strRefVal == "")
            {
                MessageBox.Show("参考值范围不能为空", "参考值", MessageBoxButtons.OK);
                return;
            }
            if (this.m_chkSexRelation.Checked)
            {
                if (strSex == "")
                {
                    MessageBox.Show("请选择性别", "参考值", MessageBoxButtons.OK);
                    return;
                }
            }
            if (this.m_chkMensesRelation.Checked)
            {
                if (strMenses == "")
                {
                    MessageBox.Show("请选择月经期", "参考值", MessageBoxButtons.OK);
                    return;
                }
            }
            if (this.m_chkMedUsedTimeRelation.Checked)
            {
                if (strMedUseTime == "")
                {
                    MessageBox.Show("请输入用药时间", "参考值", MessageBoxButtons.OK);
                    return;
                }
            }
            if (this.lstDepts.Items.Count > 0)
            {
                for (int i = 0; i < this.lstDepts.Items.Count; i++)
                {
                    deptNames += this.lstDepts.Items[i].ToString() + ",";
                }
                deptNames = deptNames.TrimEnd(',');
            }
            if (btnSaveRef.Text == "修改")
            {
                if (this.lsvSampleRef.SelectedItems.Count > 0)
                {
                    //					if(lsvCheckItemDetail.Tag != null)
                    //					{
                    //						//非新增检验项目时的修改
                    //						string strCheckItemID = ((DataRow)this.lsvSampleRef.SelectedItems[0].Tag)["CHECK_ITEM_ID_CHR"].ToString().Trim();
                    //						string strSEQ = ((DataRow)this.lsvSampleRef.SelectedItems[0].Tag)["SEQ_INT"].ToString().Trim();
                    //						flag = ((clsController_addCheckItem)this.objController).SetCheckItemRefByCheckItemID(strCheckItemID,strMinVal,strFromAge,strToAge,
                    //							strRefVal,strSampleType,strSex,strMaxVal,strSEQ);
                    //						if(flag > 0)
                    //						{
                    //							MessageBox.Show("记录修改成功！");
                    //							((clsController_addCheckItem)this.objController).QryItemRefByCheckItemID(this);
                    //						}
                    //					}
                    //					else
                    //					{
                    ListViewItem objLsvItem = lsvSampleRef.SelectedItems[0];
                    objLsvItem.SubItems[1].Text = strSex;
                    objLsvItem.SubItems[2].Text = strFromAge;
                    objLsvItem.SubItems[3].Text = strToAge;
                    objLsvItem.SubItems[4].Text = strMenses;
                    objLsvItem.SubItems[5].Text = strMedUseTime;
                    objLsvItem.SubItems[6].Text = strMinVal;
                    objLsvItem.SubItems[7].Text = strMaxVal;
                    objLsvItem.SubItems[8].Text = strRefVal;
                    objLsvItem.SubItems[9].Text = crVal1;
                    objLsvItem.SubItems[10].Text = crVal2;
                    objLsvItem.SubItems[11].Text = deptNames;
                    if (this.m_chkMensesRelation.Checked)
                    {
                        objLsvItem.Tag = this.m_cboMenses.SelectedValue.ToString().Trim();//暂时用selectIndex代替
                    }
                    else
                    {
                        objLsvItem.Tag = (string)"";
                    }
                    //					}
                }
            }
            else if (btnSaveRef.Text == "保存")
            {
                //此处在已经存在的CheckItem的基础上新增检验参考值范围
                //				if(lsvCheckItemDetail.Tag != null)
                //				{
                //					string strCheckItemID = ((DataRow)lsvCheckItemDetail.Tag)["CHECK_ITEM_ID_CHR"].ToString().Trim();
                //					string strSEQ = null;
                //					flag = ((clsController_addCheckItem)this.objController).AddItemRefByCheckItemID(strCheckItemID,strFromAge,
                //						strMaxVal,strMinVal,strRefVal,strSampleType,strSex,strToAge,out strSEQ);
                //					if(flag > 0)
                //					{
                //						MessageBox.Show("新增记录成功！");
                //						((clsController_addCheckItem)this.objController).QryItemRefByCheckItemID(this);
                //					}
                //				}
                //				else if(lsvCheckItemDetail.Tag == null)
                //				{
                int seq = 0;
                if (this.lsvSampleRef.Items.Count > 0)
                {
                    seq = int.Parse(this.lsvSampleRef.Items[this.lsvSampleRef.Items.Count - 1].SubItems[0].Text.ToString().Trim()) + 1;
                }
                ListViewItem objLsvItem = new ListViewItem();
                objLsvItem.Text = seq.ToString().Trim();
                objLsvItem.SubItems.Add(strSex);
                objLsvItem.SubItems.Add(strFromAge);
                objLsvItem.SubItems.Add(strToAge);
                objLsvItem.SubItems.Add(strMenses);
                objLsvItem.SubItems.Add(strMedUseTime);
                objLsvItem.SubItems.Add(strMinVal);
                objLsvItem.SubItems.Add(strMaxVal);
                objLsvItem.SubItems.Add(strRefVal);
                objLsvItem.SubItems.Add(crVal1);
                objLsvItem.SubItems.Add(crVal2);
                objLsvItem.SubItems.Add(deptNames);
                if (this.m_chkMensesRelation.Checked)
                {
                    objLsvItem.Tag = this.m_cboMenses.SelectedValue.ToString().Trim();//暂时用selectIndex代替
                }
                else
                {
                    objLsvItem.Tag = (string)"";
                }
                lsvSampleRef.Items.Add(objLsvItem);
                intSEQ++;
                //				}
            }
        }
        #endregion

        #region 新增检验项目及参考值范围
        private void btnAddRef_Click(object sender, System.EventArgs e)
        {
            btnSaveRef.Text = "保存";
            ResetItemRef();
            lsvSampleRef.Tag = null;
        }

        private void btnAddCheckItem_Click(object sender, System.EventArgs e)
        {
            btnSave.Text = "保存";
            ResetAll();
            lsvCheckItemDetail.Tag = null;
            btnSaveRef.Text = "保存";
        }
        #endregion

        #region 删除检验项目
        private void btnDelCheckItem_Click(object sender, System.EventArgs e)
        {
            ((clsController_addCheckItem)this.objController).m_mthDelCheckItem();
        }
        #endregion

        #region 删除参考值范围
        private void btnDelRef_Click(object sender, System.EventArgs e)
        {
            if (this.lsvSampleRef.SelectedItems.Count > 0)
            {
                //				if(lsvCheckItemDetail.Tag != null)
                //				{
                //					string strCheckItemID = ((DataRow)lsvSampleRef.SelectedItems[0].Tag)["CHECK_ITEM_ID_CHR"].ToString().Trim();
                //					string strSEQ = ((DataRow)lsvSampleRef.SelectedItems[0].Tag)["SEQ_INT"].ToString().Trim();
                //					int index = lsvSampleRef.SelectedItems[0].Index;
                //					long flag = 0;
                //					flag = ((clsController_addCheckItem)this.objController).DelCheckItemRef(strCheckItemID,strSEQ);
                //					if(flag > 0)
                //					{
                //						lsvSampleRef.SelectedItems[0].Remove();
                //						ResetItemRef();
                //					}
                //				}
                //				else
                //				{
                lsvSampleRef.SelectedItems[0].Remove();
                ResetItemRef();
                //				}
            }
        }
        #endregion

        #region 界面的事件处理

        private void m_mthOnlyInputInteger(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)13 || e.KeyChar == (char)8))
                e.Handled = true;
        }
        private void m_mthKeyDown_OnlyInteger(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            m_mthOnlyInputInteger(e);
        }


        #region 参考值UI设置
        private void cboResultType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            m_mthSetRefUI();
        }
        private void m_chkSexRelation_CheckedChanged(object sender, System.EventArgs e)
        {
            m_mthSetRefUI();
            if (((CheckBox)sender).Checked)
            {
                this.cboSex.Enabled = true;
                this.chSex.Width = 40;
            }
            else
            {
                this.cboSex.Text = "";
                this.cboSex.Enabled = false;
                this.chSex.Width = 0;
            }
        }

        private void m_chkAgeRelation_CheckedChanged(object sender, System.EventArgs e)
        {
            m_mthSetRefUI();
            if (((CheckBox)sender).Checked)
            {
                this.txtFromAge.Enabled = true;
                this.txtToAge.Enabled = true;
                this.m_cboBeginAgeUnit.Enabled = true;
                this.m_cboEndAgeUnit.Enabled = true;
                this.chFromAge.Width = 68;
                this.chToAge.Width = 68;
            }
            else
            {
                this.txtFromAge.Text = "";
                this.txtToAge.Text = "";
                this.m_cboBeginAgeUnit.Enabled = false;
                this.m_cboEndAgeUnit.Enabled = false;
                this.txtFromAge.Enabled = false;
                this.txtToAge.Enabled = false;
                this.chFromAge.Width = 0;
                this.chToAge.Width = 0;
            }
        }

        private void m_chkMedUsedTimeRelation_CheckedChanged(object sender, System.EventArgs e)
        {
            m_mthSetRefUI();
            if (((CheckBox)sender).Checked)
            {
                this.m_txtMedUsedTime.Enabled = true;
                this.m_cboMedUsedTimeUnit.Enabled = true;
                this.chMedUseTime.Width = 68;
            }
            else
            {
                this.m_txtMedUsedTime.Text = "";
                this.m_txtMedUsedTime.Enabled = false;
                this.m_cboMedUsedTimeUnit.Enabled = false;
                this.chMedUseTime.Width = 0;
            }
        }

        private void m_chkMensesRelation_CheckedChanged(object sender, System.EventArgs e)
        {
            m_mthSetRefUI();
            if (((CheckBox)sender).Checked)
            {
                this.m_cboMenses.Enabled = true;
                this.chMenses.Width = 68;
            }
            else
            {
                this.m_cboMenses.Text = "";
                this.m_cboMenses.Enabled = false;
                this.chMenses.Width = 0;
            }
        }
        private void m_mthSetRefUI()
        {

            switch (this.cboResultType.Text)
            {
                case "文字型":
                    this.chkIsCalculated.Enabled = false;
                    this.chkIsCalculated.Checked = false;
                    this.m_txtDefaultRefMax.Text = "";
                    this.m_txtDefaultRefMax.Enabled = false;
                    this.m_txtDefaultRefMin.Text = "";
                    this.m_txtDefaultRefMin.Enabled = false;
                    this.m_txtAlarmValMin.Clear();
                    this.m_txtAlarmValMin.Enabled = false;
                    this.m_txtAlarmValMax.Clear();
                    this.m_txtAlarmValMax.Enabled = false;
                    this.m_txtAlarmVal.ReadOnly = false;
                    this.m_txtDefaultRefRange.ReadOnly = false;
                    if (m_blnIsExistRefCondition())
                    {
                        txtFromRef.Text = "";
                        this.txtFromRef.Enabled = false;
                        txtToRef.Text = "";
                        this.txtToRef.Enabled = false;

                        this.txtCrVal1.Text = string.Empty;
                        this.txtCrVal1.Enabled = false;
                        this.txtCrVal2.Text = string.Empty;
                        this.txtCrVal2.Enabled = false;

                        txtRef.Enabled = true;
                        this.txtRef.ReadOnly = false;
                        this.m_mthSetRefConditionUI();
                    }
                    else
                    {
                        m_mthSetNoRefConditionUI();
                    }
                    break;
                case "数值型":
                    this.chkIsCalculated.Enabled = true;

                    this.m_txtDefaultRefMax.Enabled = true;
                    this.m_txtDefaultRefMin.Enabled = true;
                    m_txtDefaultRefRange.Text = "";
                    this.m_txtAlarmValMin.Enabled = true;
                    this.m_txtAlarmValMax.Enabled = true;
                    this.m_txtAlarmVal.ReadOnly = true;
                    this.m_txtAlarmVal.BackColor = Color.White;

                    string strMin = this.m_txtDefaultRefMin.Text.Trim() == "" ? null : this.m_txtDefaultRefMin.Text;
                    string strMax = this.m_txtDefaultRefMax.Text.Trim() == "" ? null : this.m_txtDefaultRefMax.Text;
                    clsReferenceValue objRefValue = new clsReferenceValue(strMin, strMax);
                    this.m_txtDefaultRefRange.Text = objRefValue.ToString();

                    this.m_txtDefaultRefRange.ReadOnly = true;
                    this.m_txtDefaultRefRange.BackColor = Color.White;
                    if (m_blnIsExistRefCondition())
                    {
                        this.txtFromRef.Enabled = true;
                        this.txtToRef.Enabled = true;
                        this.txtCrVal1.Enabled = true;
                        this.txtCrVal2.Enabled = true;
                        txtRef.Text = "";
                        txtRef.Enabled = true;
                        this.txtRef.ReadOnly = true;
                        this.m_mthSetRefConditionUI();
                    }
                    else
                    {
                        m_mthSetNoRefConditionUI();
                    }
                    break;
                case "阴阳型":
                    this.chkIsCalculated.Enabled = false;
                    this.chkIsCalculated.Checked = false;

                    this.m_txtDefaultRefMax.Text = "";
                    this.m_txtDefaultRefMax.Enabled = false;
                    this.m_txtDefaultRefMin.Text = "";
                    this.m_txtDefaultRefMin.Enabled = false;
                    this.m_txtDefaultRefRange.ReadOnly = false;
                    this.m_txtAlarmValMin.Clear();
                    this.m_txtAlarmValMin.Enabled = false;
                    this.m_txtAlarmValMax.Clear();
                    this.m_txtAlarmValMax.Enabled = false;
                    this.m_txtAlarmVal.ReadOnly = false;
                    if (m_blnIsExistRefCondition())
                    {
                        txtFromRef.Text = "";
                        this.txtFromRef.Enabled = false;
                        txtToRef.Text = "";
                        this.txtToRef.Enabled = false;
                        this.txtCrVal1.Text = string.Empty;
                        this.txtCrVal1.Enabled = false;
                        this.txtCrVal2.Text = string.Empty;
                        this.txtCrVal2.Enabled = false;
                        txtRef.Enabled = true;
                        this.txtRef.ReadOnly = false;
                        this.m_mthSetRefConditionUI();
                    }
                    else
                    {
                        m_mthSetNoRefConditionUI();
                    }
                    break;
                case "图形型":
                    this.chkIsCalculated.Enabled = false;
                    this.chkIsCalculated.Checked = false;

                    this.m_txtDefaultRefMax.Text = "";
                    this.m_txtDefaultRefMax.Enabled = false;
                    this.m_txtDefaultRefMin.Text = "";
                    this.m_txtDefaultRefMin.Enabled = false;
                    this.m_txtDefaultRefRange.ReadOnly = false;
                    this.m_txtAlarmValMin.Clear();
                    this.m_txtAlarmValMin.Enabled = false;
                    this.m_txtAlarmValMax.Clear();
                    this.m_txtAlarmValMax.Enabled = false;
                    this.m_txtAlarmVal.ReadOnly = false;
                    if (m_blnIsExistRefCondition())
                    {
                        txtFromRef.Text = "";
                        this.txtFromRef.Enabled = false;
                        txtToRef.Text = "";
                        this.txtToRef.Enabled = false;
                        this.txtCrVal1.Text = string.Empty;
                        this.txtCrVal1.Enabled = false;
                        this.txtCrVal2.Text = string.Empty;
                        this.txtCrVal2.Enabled = false;
                        txtRef.Enabled = true;
                        this.txtRef.ReadOnly = false;
                        this.m_mthSetRefConditionUI();
                    }
                    else
                    {
                        m_mthSetNoRefConditionUI();
                    }
                    break;
                default:
                    break;
            }
        }
        private bool m_blnIsExistRefCondition()
        {
            if (this.m_chkAgeRelation.Checked || this.m_chkMedUsedTimeRelation.Checked || this.m_chkMensesRelation.Checked || this.m_chkSexRelation.Checked)
                return true;
            else
                return false;
        }
        private void m_mthSetNoRefConditionUI()
        {

            txtFromRef.Text = "";
            txtToRef.Text = "";
            this.txtRef.Text = "";
            this.txtRef.Enabled = false;
            this.txtFromRef.Enabled = false;
            this.txtToRef.Enabled = false;
            this.txtRef.Enabled = false;
            this.btnAddRef.Enabled = false;
            this.btnDelRef.Enabled = false;
            this.btnSaveRef.Enabled = false;
            this.txtCrVal1.Text = string.Empty;
            this.txtCrVal1.Enabled = false;
            this.txtCrVal2.Text = string.Empty;
            this.txtCrVal2.Enabled = false;
            this.lstDepts.Items.Clear();
        }
        private void m_mthSetRefConditionUI()
        {
            this.btnAddRef.Enabled = true;
            this.btnDelRef.Enabled = true;
            this.btnSaveRef.Enabled = true;
        }
        #endregion

        private void m_txtDefaultRefMinMax_TextChanged(object sender, System.EventArgs e)
        {
            string strMin = this.m_txtDefaultRefMin.Text.Trim() == "" ? null : this.m_txtDefaultRefMin.Text;
            string strMax = this.m_txtDefaultRefMax.Text.Trim() == "" ? null : this.m_txtDefaultRefMax.Text;
            clsReferenceValue objRefValue = new clsReferenceValue(strMin, strMax);
            this.m_txtDefaultRefRange.Text = objRefValue.ToString();

        }
        private void m_txtRefMinMax_TextChanged(object sender, System.EventArgs e)
        {
            string strMin = this.txtFromRef.Text.Trim() == "" ? null : this.txtFromRef.Text;
            string strMax = this.txtToRef.Text.Trim() == "" ? null : this.txtToRef.Text;
            clsReferenceValue objRefValue = new clsReferenceValue(strMin, strMax);
            this.txtRef.Text = objRefValue.ToString();
        }

        private void cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.m_blnInit)
                return;
            if (this.cboSampleType.Items.Count > 0)
            {
                this.m_cboSampleGroup.m_mthShowStateByCategoryAndType(this.cboCheckCategory.SelectedValue.ToString().Trim(), this.cboSampleType.SelectedValue.ToString().Trim());
                ((clsController_addCheckItem)this.objController).m_mthrefreshCheckItemList();
            }
        }

        private void cboSampleType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.m_blnInit)
                return;
            if (this.cboCheckCategory.Items.Count > 0)
            {
                this.m_cboSampleGroup.m_mthShowStateByCategoryAndType(this.cboCheckCategory.SelectedValue.ToString().Trim(), this.cboSampleType.SelectedValue.ToString().Trim());

                ((clsController_addCheckItem)this.objController).m_mthrefreshCheckItemList();
            }
        }

        private void chkIsCalculated_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkIsCalculated.Checked)
            {
                if (this.lsvCheckItemDetail.SelectedItems.Count > 0)
                {
                    this.txtFormula.Text = ((DataRow)this.lsvCheckItemDetail.SelectedItems[0].Tag)["FORMULA_USER_VCHR"].ToString().Trim();
                }
                this.txtFormula.Enabled = true;
                this.m_btnFormulaWizard.Enabled = true;
            }
            else
            {
                this.txtFormula.Enabled = false;
                this.m_btnFormulaWizard.Enabled = false;
                this.txtFormula.Clear();
            }
        }

        #endregion

        #region 计算公式
        //计算公式
        private void m_btnFormulaWizard_Click(object sender, System.EventArgs e)
        {
            frmFormula objfrmFormula = new frmFormula();
            objfrmFormula.m_mthSetParentApperance(this);
            objfrmFormula.ShowDialog();
        }
        #endregion

        #region 样本组事件
        private void m_cboSampleGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.m_blnInit)
                return;
            Application.DoEvents();
            ((clsController_addCheckItem)this.objController).m_mthrefreshCheckItemList();
        }
        #endregion

        #region 值模板
        private void m_btnValueTemplate_Click(object sender, System.EventArgs e)
        {
            if (this.lsvCheckItemDetail.SelectedItems.Count <= 0)
                return;

            objfrmValueTemplate.m_mthInitTemplate(this.cboCheckCategory.SelectedValue.ToString().Trim(), this.cboSampleType.SelectedValue.ToString().Trim(),
                ((DataRow)this.lsvCheckItemDetail.SelectedItems[0].Tag)["CHECK_ITEM_ID_CHR"].ToString().Trim(),
                ((DataRow)this.lsvCheckItemDetail.SelectedItems[0].Tag)["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
            objfrmValueTemplate.Left = this.gbBsePara.Left + this.m_btnValueTemplate.Left - objfrmValueTemplate.Width;
            objfrmValueTemplate.Top = this.m_btnValueTemplate.Top + this.gbBsePara.Top + 66;
        }
        #endregion

        #region 窗体事件

        private void frmAddCheckItem_Closed(object sender, System.EventArgs e)
        {
            objfrmValueTemplate.m_blnIsClose = true;
            objfrmValueTemplate.Close();
        }

        private void frmAddCheckItem_Deactivate(object sender, System.EventArgs e)
        {
            objfrmValueTemplate.Hide();
            objfrmValueTemplate.m_blnIsOpen = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            frmAidChooseDept fDept = new frmAidChooseDept();
            fDept.DeptFlag = 3;
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in fDept.LstDeptName)
                {
                    if (this.lstDepts.Items.IndexOf(item) < 0)
                        this.lstDepts.Items.Add(item);
                }
            }
        }

        private void btnClearDept_Click(object sender, EventArgs e)
        {
            this.lstDepts.Items.Clear();
        }

        private void btnYgCrivalue_Click(object sender, EventArgs e)
        {
            frmYgCriValue frm = new frmYgCriValue();
            frm.ShowDialog();
        }

        #endregion

        #region 危险值
        private void m_txtAlarmValMin_TextChanged(object sender, System.EventArgs e)
        {
            string strMin = this.m_txtAlarmValMin.Text.Trim() == "" ? null : this.m_txtAlarmValMin.Text;
            string strMax = this.m_txtAlarmValMax.Text.Trim() == "" ? null : this.m_txtAlarmValMax.Text;
            string strAlarmVal = "";
            m_mthGetAlarmValue(strMin, strMax, out strAlarmVal);
            this.m_txtAlarmVal.Text = strAlarmVal;
        }

        private void m_txtAlarmValMax_TextChanged(object sender, System.EventArgs e)
        {
            string strMin = this.m_txtAlarmValMin.Text.Trim() == "" ? null : this.m_txtAlarmValMin.Text;
            string strMax = this.m_txtAlarmValMax.Text.Trim() == "" ? null : this.m_txtAlarmValMax.Text;
            string strAlarmVal = "";
            m_mthGetAlarmValue(strMin, strMax, out strAlarmVal);
            this.m_txtAlarmVal.Text = strAlarmVal;
        }

        public void m_mthGetAlarmValue(string p_strMinVal, string p_strMaxVal, out string p_strAlarmVal)
        {
            p_strAlarmVal = "";
            if (p_strMinVal != null && p_strMinVal.Trim() != "" && (p_strMaxVal == null || p_strMaxVal.Trim() == ""))
            {
                p_strAlarmVal = "<" + p_strMinVal;
            }
            else if (p_strMaxVal != null && p_strMaxVal.Trim() != "" && (p_strMinVal == null || p_strMinVal.Trim() == ""))
            {
                p_strAlarmVal = ">" + p_strMaxVal;
            }
            else if (p_strMaxVal != null && p_strMaxVal.Trim() != "" && p_strMinVal != null && p_strMinVal.Trim() != "")
            {
                p_strAlarmVal = ">" + p_strMaxVal + " 或 " + "<" + p_strMinVal;
            }
            else
            {
                p_strAlarmVal = "";
            }
        }

        #endregion

    }
}
