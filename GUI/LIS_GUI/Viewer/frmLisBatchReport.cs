using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// frmLisBatchReport 的摘要说明。
    /// </summary>
    public class frmLisBatchReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        com.digitalwave.iCare.gui.LIS.clsController_LisBatchReport m_objController;
        #region 控件声名
        internal System.Windows.Forms.ListView m_lsvBaseCheckItem;
        internal System.Windows.Forms.DateTimePicker m_dtpFromDate;
        internal System.Windows.Forms.DateTimePicker m_dtpToDate;
        internal System.Windows.Forms.TextBox m_txtSampleNoFrom;
        internal System.Windows.Forms.TextBox m_txtSampleNoTo;
        private System.Windows.Forms.Label m_lbSampleNo;
        private System.Windows.Forms.ColumnHeader m_chDate;
        internal System.Windows.Forms.ColumnHeader m_chPatientName;
        private System.Windows.Forms.ColumnHeader m_chSex;
        private System.Windows.Forms.ColumnHeader m_chDepartment;
        private System.Windows.Forms.GroupBox m_gbCondition;
        internal System.Windows.Forms.PrintDialog m_printDlg;
        private System.Windows.Forms.Label m_lbReportGroup;
        internal System.Windows.Forms.ComboBox m_cboReport;
        private System.Windows.Forms.Label m_lbTo;
        private System.Windows.Forms.ColumnHeader m_chmReportName;
        private PinkieControls.ButtonXP m_btnQuery;
        private PinkieControls.ButtonXP m_btnPrint;
        private PinkieControls.ButtonXP m_btnReset;
        private System.Windows.Forms.Label m_lbConfirmDate;
        private System.Windows.Forms.Label m_lbConfirmTo;
        private PinkieControls.ButtonXP m_btnSelectAll;
        internal PinkieControls.ButtonXP m_btnNotSelectAll;
        #endregion
        private System.Windows.Forms.ColumnHeader m_chCheckNO;
        private PinkieControls.ButtonXP btnExit;
        private Label label1;
        internal ComboBox m_cboPatientType;
        private int sortColumn = -1;   //————————————————————————————————————————————

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmLisBatchReport()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
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
            this.m_dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.m_lbConfirmDate = new System.Windows.Forms.Label();
            this.m_txtSampleNoFrom = new System.Windows.Forms.TextBox();
            this.m_txtSampleNoTo = new System.Windows.Forms.TextBox();
            this.m_lbSampleNo = new System.Windows.Forms.Label();
            this.m_lsvBaseCheckItem = new System.Windows.Forms.ListView();
            this.m_chCheckNO = new System.Windows.Forms.ColumnHeader();
            this.m_chmReportName = new System.Windows.Forms.ColumnHeader();
            this.m_chPatientName = new System.Windows.Forms.ColumnHeader();
            this.m_chSex = new System.Windows.Forms.ColumnHeader();
            this.m_chDepartment = new System.Windows.Forms.ColumnHeader();
            this.m_chDate = new System.Windows.Forms.ColumnHeader();
            this.m_gbCondition = new System.Windows.Forms.GroupBox();
            this.m_cboPatientType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new PinkieControls.ButtonXP();
            this.m_btnNotSelectAll = new PinkieControls.ButtonXP();
            this.m_btnSelectAll = new PinkieControls.ButtonXP();
            this.m_lbConfirmTo = new System.Windows.Forms.Label();
            this.m_lbTo = new System.Windows.Forms.Label();
            this.m_cboReport = new System.Windows.Forms.ComboBox();
            this.m_lbReportGroup = new System.Windows.Forms.Label();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_btnReset = new PinkieControls.ButtonXP();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.m_printDlg = new System.Windows.Forms.PrintDialog();
            this.m_gbCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtpFromDate
            // 
            this.m_dtpFromDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.m_dtpFromDate.Location = new System.Drawing.Point(88, 20);
            this.m_dtpFromDate.Name = "m_dtpFromDate";
            this.m_dtpFromDate.Size = new System.Drawing.Size(128, 23);
            this.m_dtpFromDate.TabIndex = 0;
            // 
            // m_dtpToDate
            // 
            this.m_dtpToDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.m_dtpToDate.Location = new System.Drawing.Point(252, 20);
            this.m_dtpToDate.Name = "m_dtpToDate";
            this.m_dtpToDate.Size = new System.Drawing.Size(128, 23);
            this.m_dtpToDate.TabIndex = 1;
            // 
            // m_lbConfirmDate
            // 
            this.m_lbConfirmDate.AutoSize = true;
            this.m_lbConfirmDate.Location = new System.Drawing.Point(16, 28);
            this.m_lbConfirmDate.Name = "m_lbConfirmDate";
            this.m_lbConfirmDate.Size = new System.Drawing.Size(70, 14);
            this.m_lbConfirmDate.TabIndex = 2;
            this.m_lbConfirmDate.Text = "审核日期:";
            // 
            // m_txtSampleNoFrom
            // 
            this.m_txtSampleNoFrom.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtSampleNoFrom.Location = new System.Drawing.Point(88, 56);
            this.m_txtSampleNoFrom.MaxLength = 18;
            this.m_txtSampleNoFrom.Name = "m_txtSampleNoFrom";
            this.m_txtSampleNoFrom.Size = new System.Drawing.Size(128, 23);
            this.m_txtSampleNoFrom.TabIndex = 3;
            // 
            // m_txtSampleNoTo
            // 
            this.m_txtSampleNoTo.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtSampleNoTo.Location = new System.Drawing.Point(252, 56);
            this.m_txtSampleNoTo.MaxLength = 18;
            this.m_txtSampleNoTo.Name = "m_txtSampleNoTo";
            this.m_txtSampleNoTo.Size = new System.Drawing.Size(128, 23);
            this.m_txtSampleNoTo.TabIndex = 4;
            // 
            // m_lbSampleNo
            // 
            this.m_lbSampleNo.AutoSize = true;
            this.m_lbSampleNo.Location = new System.Drawing.Point(16, 60);
            this.m_lbSampleNo.Name = "m_lbSampleNo";
            this.m_lbSampleNo.Size = new System.Drawing.Size(70, 14);
            this.m_lbSampleNo.TabIndex = 10;
            this.m_lbSampleNo.Text = "检验编号:";
            // 
            // m_lsvBaseCheckItem
            // 
            this.m_lsvBaseCheckItem.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.m_lsvBaseCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvBaseCheckItem.BackColor = System.Drawing.SystemColors.Window;
            this.m_lsvBaseCheckItem.CheckBoxes = true;
            this.m_lsvBaseCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chCheckNO,
            this.m_chmReportName,
            this.m_chPatientName,
            this.m_chSex,
            this.m_chDepartment,
            this.m_chDate});
            this.m_lsvBaseCheckItem.FullRowSelect = true;
            this.m_lsvBaseCheckItem.GridLines = true;
            this.m_lsvBaseCheckItem.HideSelection = false;
            this.m_lsvBaseCheckItem.Location = new System.Drawing.Point(16, 116);
            this.m_lsvBaseCheckItem.Name = "m_lsvBaseCheckItem";
            this.m_lsvBaseCheckItem.Size = new System.Drawing.Size(932, 480);
            this.m_lsvBaseCheckItem.TabIndex = 20;
            this.m_lsvBaseCheckItem.UseCompatibleStateImageBehavior = false;
            this.m_lsvBaseCheckItem.View = System.Windows.Forms.View.Details;
            this.m_lsvBaseCheckItem.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvBaseCheckItem_ColumnClick);
            // 
            // m_chCheckNO
            // 
            this.m_chCheckNO.Text = "检验编号";
            this.m_chCheckNO.Width = 100;
            // 
            // m_chmReportName
            // 
            this.m_chmReportName.Text = "报告名称";
            this.m_chmReportName.Width = 132;
            // 
            // m_chPatientName
            // 
            this.m_chPatientName.Text = "患者姓名";
            this.m_chPatientName.Width = 109;
            // 
            // m_chSex
            // 
            this.m_chSex.Text = "性别";
            this.m_chSex.Width = 74;
            // 
            // m_chDepartment
            // 
            this.m_chDepartment.Text = "科室";
            this.m_chDepartment.Width = 174;
            // 
            // m_chDate
            // 
            this.m_chDate.Text = "审核日期";
            this.m_chDate.Width = 154;
            // 
            // m_gbCondition
            // 
            this.m_gbCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gbCondition.Controls.Add(this.m_cboPatientType);
            this.m_gbCondition.Controls.Add(this.label1);
            this.m_gbCondition.Controls.Add(this.btnExit);
            this.m_gbCondition.Controls.Add(this.m_btnNotSelectAll);
            this.m_gbCondition.Controls.Add(this.m_btnSelectAll);
            this.m_gbCondition.Controls.Add(this.m_lbConfirmTo);
            this.m_gbCondition.Controls.Add(this.m_lbTo);
            this.m_gbCondition.Controls.Add(this.m_cboReport);
            this.m_gbCondition.Controls.Add(this.m_lbReportGroup);
            this.m_gbCondition.Controls.Add(this.m_txtSampleNoTo);
            this.m_gbCondition.Controls.Add(this.m_lbConfirmDate);
            this.m_gbCondition.Controls.Add(this.m_lbSampleNo);
            this.m_gbCondition.Controls.Add(this.m_txtSampleNoFrom);
            this.m_gbCondition.Controls.Add(this.m_dtpFromDate);
            this.m_gbCondition.Controls.Add(this.m_dtpToDate);
            this.m_gbCondition.Controls.Add(this.m_btnQuery);
            this.m_gbCondition.Controls.Add(this.m_btnReset);
            this.m_gbCondition.Controls.Add(this.m_btnPrint);
            this.m_gbCondition.Location = new System.Drawing.Point(16, 8);
            this.m_gbCondition.Name = "m_gbCondition";
            this.m_gbCondition.Size = new System.Drawing.Size(932, 96);
            this.m_gbCondition.TabIndex = 23;
            this.m_gbCondition.TabStop = false;
            // 
            // m_cboPatientType
            // 
            this.m_cboPatientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPatientType.FormattingEnabled = true;
            this.m_cboPatientType.Items.AddRange(new object[] {
            "全部",
            "门诊",
            "住院"});
            this.m_cboPatientType.Location = new System.Drawing.Point(462, 23);
            this.m_cboPatientType.Name = "m_cboPatientType";
            this.m_cboPatientType.Size = new System.Drawing.Size(172, 22);
            this.m_cboPatientType.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "病人类别";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(838, 52);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(76, 32);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "退出(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // m_btnNotSelectAll
            // 
            this.m_btnNotSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNotSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnNotSelectAll.DefaultScheme = true;
            this.m_btnNotSelectAll.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNotSelectAll.Hint = "";
            this.m_btnNotSelectAll.Location = new System.Drawing.Point(838, 14);
            this.m_btnNotSelectAll.Name = "m_btnNotSelectAll";
            this.m_btnNotSelectAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNotSelectAll.Size = new System.Drawing.Size(76, 32);
            this.m_btnNotSelectAll.TabIndex = 7;
            this.m_btnNotSelectAll.Text = "全清(F6)";
            this.m_btnNotSelectAll.Click += new System.EventHandler(this.m_btnNotSelectAll_Click);
            // 
            // m_btnSelectAll
            // 
            this.m_btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnSelectAll.DefaultScheme = true;
            this.m_btnSelectAll.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSelectAll.Hint = "";
            this.m_btnSelectAll.Location = new System.Drawing.Point(756, 14);
            this.m_btnSelectAll.Name = "m_btnSelectAll";
            this.m_btnSelectAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSelectAll.Size = new System.Drawing.Size(76, 32);
            this.m_btnSelectAll.TabIndex = 6;
            this.m_btnSelectAll.Text = "全选(F5)";
            this.m_btnSelectAll.Click += new System.EventHandler(this.m_btnSelectAll_Click);
            // 
            // m_lbConfirmTo
            // 
            this.m_lbConfirmTo.AutoSize = true;
            this.m_lbConfirmTo.Location = new System.Drawing.Point(224, 24);
            this.m_lbConfirmTo.Name = "m_lbConfirmTo";
            this.m_lbConfirmTo.Size = new System.Drawing.Size(21, 14);
            this.m_lbConfirmTo.TabIndex = 23;
            this.m_lbConfirmTo.Text = "至";
            // 
            // m_lbTo
            // 
            this.m_lbTo.AutoSize = true;
            this.m_lbTo.Location = new System.Drawing.Point(224, 60);
            this.m_lbTo.Name = "m_lbTo";
            this.m_lbTo.Size = new System.Drawing.Size(21, 14);
            this.m_lbTo.TabIndex = 22;
            this.m_lbTo.Text = "至";
            // 
            // m_cboReport
            // 
            this.m_cboReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboReport.Location = new System.Drawing.Point(462, 56);
            this.m_cboReport.Name = "m_cboReport";
            this.m_cboReport.Size = new System.Drawing.Size(172, 22);
            this.m_cboReport.TabIndex = 21;
            // 
            // m_lbReportGroup
            // 
            this.m_lbReportGroup.AutoSize = true;
            this.m_lbReportGroup.Location = new System.Drawing.Point(386, 60);
            this.m_lbReportGroup.Name = "m_lbReportGroup";
            this.m_lbReportGroup.Size = new System.Drawing.Size(70, 14);
            this.m_lbReportGroup.TabIndex = 20;
            this.m_lbReportGroup.Text = "报告类别:";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(674, 14);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(76, 32);
            this.m_btnQuery.TabIndex = 5;
            this.m_btnQuery.Text = "查询(F4)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // m_btnReset
            // 
            this.m_btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnReset.DefaultScheme = true;
            this.m_btnReset.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnReset.Hint = "";
            this.m_btnReset.Location = new System.Drawing.Point(674, 52);
            this.m_btnReset.Name = "m_btnReset";
            this.m_btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnReset.Size = new System.Drawing.Size(76, 32);
            this.m_btnReset.TabIndex = 8;
            this.m_btnReset.Text = "清空(F7)";
            this.m_btnReset.Click += new System.EventHandler(this.m_btnReset_Click);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(756, 52);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(76, 32);
            this.m_btnPrint.TabIndex = 9;
            this.m_btnPrint.Text = "打印(F8)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // frmLisBatchReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(976, 625);
            this.Controls.Add(this.m_gbCondition);
            this.Controls.Add(this.m_lsvBaseCheckItem);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmLisBatchReport";
            this.Text = "批量打印";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLisBatchReport_KeyDown);
            this.Load += new System.EventHandler(this.frmLisBatchReport_Load);
            this.m_gbCondition.ResumeLayout(false);
            this.m_gbCondition.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region CreateController
        public override void CreateController()
        {
            m_objController = new com.digitalwave.iCare.gui.LIS.clsController_LisBatchReport();
            m_objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 初始化界面
        private void frmLisBatchReport_Load(object sender, System.EventArgs e)
        {
            m_objController.m_lngInitialfrmLisBatchReport(this);
            m_cboPatientType.SelectedIndex = 2;

            

        }
        #endregion

        #region 一般处理
        private void frmLisBatchReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthShortCutKey(e.KeyCode);
            this.m_mthSetKeyTab(e);
        }

        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            if (p_eumKeyCode == Keys.F4 && this.m_btnQuery.Enabled && m_btnQuery.Visible)//读卡
            {
                this.m_btnQuery_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F5 && this.m_btnSelectAll.Enabled && m_btnSelectAll.Visible)//读卡
            {
                this.m_btnSelectAll_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F6 && this.m_btnNotSelectAll.Enabled && m_btnNotSelectAll.Visible)		//退出
            {
                this.m_btnNotSelectAll_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F7 && this.m_btnReset.Enabled && m_btnReset.Visible)//手输和读卡机切换
            {
                this.m_btnReset_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F8 && this.m_btnPrint.Enabled && m_btnPrint.Visible)//手输和读卡机切换
            {
                this.m_btnPrint_Click(null, null);
            }
        }

        #endregion

        #region 批量打印
        private void m_btnPrint_Click(object sender, System.EventArgs e)
        {
            if (this.m_lsvBaseCheckItem.CheckedItems.Count == 0)
            {
                MessageBox.Show("没有需要打印的报告单", "批量打印", MessageBoxButtons.OK);
                return;
            }
            //			System.Threading.Thread objPrintThread = new System.Threading.Thread(new System.Threading.ThreadStart(m_mthBatchPrint));
            //			objPrintThread.Name = "iCare-BatchPrint:" + objPrintThread.GetHashCode().ToString();
            //			objPrintThread.Start();
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnPrint.Enabled = false;
            m_mthBatchPrint();
            this.m_btnPrint.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_mthBatchPrint()
        {
            //获取需要打印的报告单数量
            int count = this.m_lsvBaseCheckItem.CheckedItems.Count;

            clsLisBatchReportList_VO[] objReportArr1 = null;
            clsLisBatchReportList_VO[] objReportArr2 = null;
            clsLisBatchReportDetail_VO[] objResultArr1 = null;
            clsLisBatchReportDetail_VO[] objResultArr2 = null;
            if (count > 5)
            {
                objReportArr1 = new clsLisBatchReportList_VO[5];
                objReportArr2 = new clsLisBatchReportList_VO[count - 5];
            }
            else
            {
                objReportArr1 = new clsLisBatchReportList_VO[count];
            }

            for (int i = 0; i < count; i++)
            {
                if (i >= 5)
                {
                    objReportArr2[i - 5] = (clsLisBatchReportList_VO)this.m_lsvBaseCheckItem.CheckedItems[i].Tag;
                }
                else
                {
                    objReportArr1[i] = (clsLisBatchReportList_VO)this.m_lsvBaseCheckItem.CheckedItems[i].Tag;
                }
            }


            clsBatchPrint objBatchPrint = new clsBatchPrint();
            com.digitalwave.iCare.gui.LIS.clsUnifyReportPrint[] objBatchReportPrint = null;

            m_printDlg.Document = objBatchPrint.m_printDoc;
            DialogResult objDialogRes = m_printDlg.ShowDialog();
            if (objDialogRes == DialogResult.OK)
            {
                new clsController_LisBatchReport().m_mthGetReportInfoArr(objReportArr1, out objResultArr1);

                if (objResultArr1 == null)
                    return;

                objBatchReportPrint = new clsUnifyReportPrint[objResultArr1.Length];
                string m_strParmValue = null;
                long lngRes = m_objController.m_lngGetSysParmValue("4030", out m_strParmValue);
                for (int i = 0; i < objResultArr1.Length; i++)
                {
                    objBatchReportPrint[i] = new clsUnifyReportPrint();
                    objBatchReportPrint[i].m_dtbSample = objResultArr1[i].m_dtbReportBaseInfo;
                    objBatchReportPrint[i].m_dtbResult = dtbFilter(objResultArr1[i].m_dtbCheckResult);
                }

                objBatchPrint.m_objBatchReportPrint = objBatchReportPrint;
                objBatchPrint.m_mthPrint();
                if (objReportArr2 != null)
                {
                    new clsController_LisBatchReport().m_mthGetReportInfoArr(objReportArr2, out objResultArr2);

                    if (objResultArr2 == null)
                        return;

                    objBatchReportPrint = new clsUnifyReportPrint[objResultArr2.Length];
                    for (int i = 0; i < objResultArr2.Length; i++)
                    {
                        objBatchReportPrint[i] = new clsUnifyReportPrint();
                        objBatchReportPrint[i].m_dtbSample = objResultArr2[i].m_dtbReportBaseInfo;
                        objBatchReportPrint[i].m_dtbResult = dtbFilter(objResultArr2[i].m_dtbCheckResult);
                    }

                    objBatchPrint.m_objBatchReportPrint = objBatchReportPrint;
                    objBatchPrint.m_mthPrint();
                }
            }
        }

        /// <summary>
        /// 过滤项目根据条件(值为"\"的)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable dtbFilter(DataTable dt)
        {
            if (dt != null)
            {
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["result_vchr"].ToString() == "\\")
                    {
                        dt.Rows.Remove(dr);
                        continue;
                    }
                    i++;
                }
            }
            return dt;
        }
        #endregion


        #region 查询
        private void m_btnQuery_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnQuery.Enabled = false;
            m_objController.m_mthGetReportByCondition();
            this.m_btnQuery.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        #endregion


        #region 清空
        private void m_btnReset_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnReset.Enabled = false;
            m_objController.m_mthClear();
            this.m_btnReset.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region 全选
        private void m_btnSelectAll_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnSelectAll.Enabled = false;
            m_objController.m_mthSelectAll();
            this.m_btnSelectAll.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region 全清
        private void m_btnNotSelectAll_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnNotSelectAll.Enabled = false;
            m_objController.m_mthNotSelectAll();
            this.m_btnNotSelectAll.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_lsvBaseCheckItem_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                m_lsvBaseCheckItem.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (m_lsvBaseCheckItem.Sorting == SortOrder.Ascending)
                    m_lsvBaseCheckItem.Sorting = SortOrder.Descending;
                else
                    m_lsvBaseCheckItem.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            m_lsvBaseCheckItem.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.m_lsvBaseCheckItem.ListViewItemSorter = new ListViewItemComparer1(e.Column, m_lsvBaseCheckItem.Sorting);
        }



    }
    class clsBatchPrint : com.digitalwave.GUI_Base.clsController_Base
    {
        public System.Drawing.Printing.PrintDocument m_printDoc;
        public com.digitalwave.iCare.gui.LIS.clsUnifyReportPrint[] m_objBatchReportPrint = null;
        private com.digitalwave.iCare.gui.LIS.clsUnifyReportPrint m_objPrintInstance = null;
        private string HospitalName = "";

        public clsBatchPrint()
        {
            // 
            // m_printDoc
            // 
            this.m_printDoc = new System.Drawing.Printing.PrintDocument();
            this.m_printDoc.PrintController = new System.Drawing.Printing.StandardPrintController();
            this.m_printDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_printDoc_BeginPrint);
            this.m_printDoc.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_printDoc_EndPrint);
            this.m_printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_printDoc_PrintPage);

            HospitalName = this.m_objComInfo.m_strGetHospitalTitle();
        }
        public void m_mthPrint()
        {
            if (m_objBatchReportPrint == null)
                return;
            try
            {
                for (int i = 0; i < m_objBatchReportPrint.Length; i++)
                {
                    if (m_objBatchReportPrint[i] != null)
                    {
                        m_objPrintInstance = m_objBatchReportPrint[i];
                        m_printDoc.Print();
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception es)
            {
                string strMess = "打印错误:" + es.Message;
                MessageBox.Show(strMess, "iCare-批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void m_printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (m_objPrintInstance != null)
            {
                clsPrintValuePara objPrintPara = new clsPrintValuePara();
                objPrintPara.m_dtbBaseInfo = m_objPrintInstance.m_dtbSample;
                objPrintPara.m_dtbResult = m_objPrintInstance.m_dtbResult;
                objPrintPara.m_strTitle = HospitalName; //"佛山市第二人民医院检验报告单";
                m_objPrintInstance.m_mthInitPrintTool(this.m_printDoc);
                m_objPrintInstance.m_mthBeginPrint(objPrintPara);
            }
        }

        private void m_printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (m_objPrintInstance != null)
            {
                m_objPrintInstance.m_mthPrintPage(e);
            }
        }

        private void m_printDoc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_objPrintInstance = null;
        }

    }


    #region 用于ListView排序的类：ListViewItemComparer1,暂时不用公司的类ListViewItemComparer。陈秀山2011.02.11
    //用于ListView排序的类：  

    // Implements the manual sorting of items by columns.
    class ListViewItemComparer1 : IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer1()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer1(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;


            int a = 0, b = 0;
            if (int.TryParse(((ListViewItem)x).SubItems[col].Text, out a) && int.TryParse(((ListViewItem)y).SubItems[col].Text, out b))
            {
                returnVal = a >= b ? (a == b ? 0 : 1) : -1;
            }
            else
            {
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                        ((ListViewItem)y).SubItems[col].Text);
                // Determine whether the sort order is descending.
                if (order == SortOrder.Descending)
                    // Invert the value returned by String.Compare.
                    returnVal *= -1;
            }


            return returnVal;
        }

    }
    
    #endregion
}