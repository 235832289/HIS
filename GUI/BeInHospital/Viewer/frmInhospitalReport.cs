using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmInhospitalReport 的摘要说明。
	/// </summary>
	public class frmInhospitalReport : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		private System.Windows.Forms.TabControl m_tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
        private PinkieControls.ButtonXP m_cmdSearch;
        private PinkieControls.ButtonXP m_cmdPrint;
        internal DateTimePicker m_dtpEndDate;
       
        internal System.Windows.Forms.ColumnHeader ColumnNum;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private Label label3;
        internal TextBox m_txtAREAID_CHR;
        internal System.Windows.Forms.ListView lsvAreaInfo;
        private Label label1;
        internal DateTimePicker m_dtpBeginDate;
        private Label label2;
        private PinkieControls.ButtonXP m_cmdReturn;
        internal CheckBox m_checkBoxArea;

        /// <summary>
        /// 科室ID数组
        /// </summary>
        internal ArrayList m_deptIDArr = new ArrayList();
        private PinkieControls.ButtonXP m_cmdArea;
        internal DataGridView m_dgvIn;
        internal Sybase.DataWindow.DataStore m_dsPrint;
        internal DataGridView m_dgvOut;
        internal DataGridView m_dgvTrArea;
        internal DataGridView m_dgvTrBed;
        private PinkieControls.ButtonXP btnExport;
        private IContainer components;

		public frmInhospitalReport()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

            #region 临时控件
            //			//Dept
            //			lsvDeptInfo = new ListView();
            //			this.lsvDeptInfo.DoubleClick += new System.EventHandler(this.lsvDeptInfo_DoubleClick);
            //			this.lsvDeptInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvDeptInfo_KeyDown);
            //			this.lsvDeptInfo.Leave += new System.EventHandler(this.lsvDeptInfo_Leave);
            //Area
            lsvAreaInfo = new ListView();
            this.lsvAreaInfo.DoubleClick += new System.EventHandler(this.lsvAreaInfo_DoubleClick);
            this.lsvAreaInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvAreaInfo_KeyDown);
            this.lsvAreaInfo.Leave += new System.EventHandler(this.lsvAreaInfo_Leave);
            #endregion
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_dgvIn = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_dgvOut = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_dgvTrArea = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.m_dgvTrBed = new System.Windows.Forms.DataGridView();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtAREAID_CHR = new System.Windows.Forms.TextBox();
            this.m_dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmdReturn = new PinkieControls.ButtonXP();
            this.m_checkBoxArea = new System.Windows.Forms.CheckBox();
            this.m_cmdArea = new PinkieControls.ButtonXP();
            this.m_dsPrint = new Sybase.DataWindow.DataStore(this.components);
            this.btnExport = new PinkieControls.ButtonXP();
            this.m_tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvIn)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvOut)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTrArea)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTrBed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dsPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // m_tabControl1
            // 
            this.m_tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl1.Controls.Add(this.tabPage1);
            this.m_tabControl1.Controls.Add(this.tabPage2);
            this.m_tabControl1.Controls.Add(this.tabPage3);
            this.m_tabControl1.Controls.Add(this.tabPage4);
            this.m_tabControl1.HotTrack = true;
            this.m_tabControl1.Location = new System.Drawing.Point(12, 37);
            this.m_tabControl1.Name = "m_tabControl1";
            this.m_tabControl1.SelectedIndex = 0;
            this.m_tabControl1.Size = new System.Drawing.Size(924, 474);
            this.m_tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_dgvIn);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(916, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "入院日志";
            // 
            // m_dgvIn
            // 
            this.m_dgvIn.AllowUserToAddRows = false;
            this.m_dgvIn.AllowUserToDeleteRows = false;
            this.m_dgvIn.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvIn.Location = new System.Drawing.Point(0, 0);
            this.m_dgvIn.Name = "m_dgvIn";
            this.m_dgvIn.RowHeadersVisible = false;
            this.m_dgvIn.RowTemplate.Height = 23;
            this.m_dgvIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvIn.Size = new System.Drawing.Size(916, 447);
            this.m_dgvIn.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_dgvOut);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(916, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "出院日志";
            // 
            // m_dgvOut
            // 
            this.m_dgvOut.AllowUserToAddRows = false;
            this.m_dgvOut.AllowUserToDeleteRows = false;
            this.m_dgvOut.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvOut.Location = new System.Drawing.Point(0, 0);
            this.m_dgvOut.Name = "m_dgvOut";
            this.m_dgvOut.RowHeadersVisible = false;
            this.m_dgvOut.RowTemplate.Height = 23;
            this.m_dgvOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvOut.Size = new System.Drawing.Size(916, 447);
            this.m_dgvOut.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_dgvTrArea);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(916, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "转区日志";
            // 
            // m_dgvTrArea
            // 
            this.m_dgvTrArea.AllowUserToAddRows = false;
            this.m_dgvTrArea.AllowUserToDeleteRows = false;
            this.m_dgvTrArea.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvTrArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvTrArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvTrArea.Location = new System.Drawing.Point(0, 0);
            this.m_dgvTrArea.Name = "m_dgvTrArea";
            this.m_dgvTrArea.RowHeadersVisible = false;
            this.m_dgvTrArea.RowTemplate.Height = 23;
            this.m_dgvTrArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvTrArea.Size = new System.Drawing.Size(916, 447);
            this.m_dgvTrArea.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_dgvTrBed);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(916, 447);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "转床日志";
            // 
            // m_dgvTrBed
            // 
            this.m_dgvTrBed.AllowUserToAddRows = false;
            this.m_dgvTrBed.AllowUserToDeleteRows = false;
            this.m_dgvTrBed.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvTrBed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvTrBed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvTrBed.Location = new System.Drawing.Point(0, 0);
            this.m_dgvTrBed.Name = "m_dgvTrBed";
            this.m_dgvTrBed.RowHeadersVisible = false;
            this.m_dgvTrBed.RowTemplate.Height = 23;
            this.m_dgvTrBed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvTrBed.Size = new System.Drawing.Size(916, 447);
            this.m_dgvTrBed.TabIndex = 3;
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(745, 6);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(84, 27);
            this.m_cmdPrint.TabIndex = 4;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(569, 6);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(84, 27);
            this.m_cmdSearch.TabIndex = 1;
            this.m_cmdSearch.Text = "查询(&S)";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(344, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "住院病区:";
            this.label3.Visible = false;
            // 
            // m_txtAREAID_CHR
            // 
            this.m_txtAREAID_CHR.Location = new System.Drawing.Point(414, 17);
            this.m_txtAREAID_CHR.Name = "m_txtAREAID_CHR";
            this.m_txtAREAID_CHR.Size = new System.Drawing.Size(125, 23);
            this.m_txtAREAID_CHR.TabIndex = 8;
            this.m_txtAREAID_CHR.Visible = false;
            this.m_txtAREAID_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAREAID_CHR_KeyDown);
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Location = new System.Drawing.Point(186, 7);
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(122, 23);
            this.m_dtpEndDate.TabIndex = 5;
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Location = new System.Drawing.Point(41, 7);
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(122, 23);
            this.m_dtpBeginDate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "从";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(163, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "至";
            // 
            // m_cmdReturn
            // 
            this.m_cmdReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdReturn.DefaultScheme = true;
            this.m_cmdReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReturn.Hint = "";
            this.m_cmdReturn.Location = new System.Drawing.Point(833, 6);
            this.m_cmdReturn.Name = "m_cmdReturn";
            this.m_cmdReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReturn.Size = new System.Drawing.Size(84, 27);
            this.m_cmdReturn.TabIndex = 10;
            this.m_cmdReturn.Text = "返回(&R)";
            this.m_cmdReturn.Click += new System.EventHandler(this.m_cmdReturn_Click);
            // 
            // m_checkBoxArea
            // 
            this.m_checkBoxArea.AutoSize = true;
            this.m_checkBoxArea.Location = new System.Drawing.Point(441, 0);
            this.m_checkBoxArea.Name = "m_checkBoxArea";
            this.m_checkBoxArea.Size = new System.Drawing.Size(54, 18);
            this.m_checkBoxArea.TabIndex = 62;
            this.m_checkBoxArea.Text = "病区";
            this.m_checkBoxArea.UseVisualStyleBackColor = true;
            this.m_checkBoxArea.Visible = false;
            this.m_checkBoxArea.CheckedChanged += new System.EventHandler(this.m_checkBoxArea_CheckedChanged);
            // 
            // m_cmdArea
            // 
            this.m_cmdArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdArea.DefaultScheme = true;
            this.m_cmdArea.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdArea.ForeColor = System.Drawing.Color.Blue;
            this.m_cmdArea.Hint = "";
            this.m_cmdArea.Location = new System.Drawing.Point(323, 6);
            this.m_cmdArea.Name = "m_cmdArea";
            this.m_cmdArea.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdArea.Size = new System.Drawing.Size(84, 27);
            this.m_cmdArea.TabIndex = 63;
            this.m_cmdArea.Text = "病区▼";
            this.m_cmdArea.Click += new System.EventHandler(this.m_cmdArea_Click);
            // 
            // m_dsPrint
            // 
            this.m_dsPrint.DataWindowObject = null;
            this.m_dsPrint.LibraryList = "D:\\dev\\icare_ver2\\Code\\bin\\Debug\\pb_new.pbl";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(657, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(84, 27);
            this.btnExport.TabIndex = 64;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmInhospitalReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(936, 541);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.m_cmdArea);
            this.Controls.Add(this.m_checkBoxArea);
            this.Controls.Add(this.m_cmdReturn);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_dtpEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txtAREAID_CHR);
            this.Controls.Add(this.m_dtpBeginDate);
            this.Controls.Add(this.m_tabControl1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmInhospitalReport";
            this.Text = "住院进出转报表";
            this.Load += new System.EventHandler(this.frmInhospitalReport_Load);
            this.m_tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvIn)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvOut)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTrArea)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTrBed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dsPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_InhospitalReport();
			objController.Set_GUI_Apperance(this);
		}

		private void m_cmdTransferbedLog_Click(object sender, System.EventArgs e)
		{
			((clsCtl_InhospitalReport)this.objController).m_mthShowTransferbedLog();
		}

        #region 接收函数接口
        /// <summary>
        /// 
        /// </summary>
        internal string str_parmval = "0";

        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;

            this.Show();
        }
        #endregion

		private void m_cmdSearch_Click(object sender, System.EventArgs e)
		{
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.m_dtpBeginDate.Value.ToString("yyyy-MM-dd"), this.m_dtpEndDate.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
    
            switch (this.m_tabControl1.SelectedIndex)
            {
                case 0:
                    //入院日志
                    ((clsCtl_InhospitalReport)this.objController).m_mthShowInHospitalLog();
                    break;

                case 1:
                    //出院日志
                    ((clsCtl_InhospitalReport)this.objController).m_mthShowOutHospitalLog();
                    break;

                case 2:
                    //转区日志
                    ((clsCtl_InhospitalReport)this.objController).m_mthShowTransferArea();
                    break;
                case 3:
                    //转床日志
                    ((clsCtl_InhospitalReport)this.objController).m_mthShowTransferbedLog();
                    break;
                default:
                    
                    break;


            }
		}

        private void m_cmdPrint_Click(object sender, System.EventArgs e)
        {
            switch (this.m_tabControl1.SelectedIndex)
            {
                case 0:
                    //入院
                    ((clsCtl_InhospitalReport)this.objController).PrintInHospitalLog();
                    break;

                case 1:
                    //出院
                    ((clsCtl_InhospitalReport)this.objController).PrintOutHospitalLog();
                    break;

                case 2:
                    //转区
                    ((clsCtl_InhospitalReport)this.objController).PrintTransferArea();
                    break;
                case 3:
                    //转床
                    ((clsCtl_InhospitalReport)this.objController).PrintTransferbedLog();
                    break;
                default:

                    break;
                    
            }
        }

        private void m_cmdReturn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

       
        #region 病区查找
        private void lsvAreaInfo_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.lsvAreaInfo.SelectedItems.Count > 0)
            {
                this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.SelectedItems[0].SubItems[1].Text;
                if (this.lsvAreaInfo.SelectedItems[0].Index == 0)
                {
                    this.m_txtAREAID_CHR.Tag = "%";
                }
                else
                {
                    this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.SelectedItems[0].Tag).m_strDEPTID_CHR;
                }
                this.lsvAreaInfo.Visible = false;
            }
        }
        private void lsvAreaInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lsvAreaInfo_DoubleClick(null, null);
            }
        }
        private void lsvAreaInfo_Leave(object sender, System.EventArgs e)
        {
            this.lsvAreaInfo.Visible = false;
        }
        #endregion

        private void m_txtAREAID_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 控件处理

                #region 病区编号	glzhang	2005.07.29
                this.ColumnNum = new System.Windows.Forms.ColumnHeader();
                this.ColumnNum.Text = "病区编号";
                this.ColumnNum.Width = 80;
                #endregion

                this.ColumnName = new System.Windows.Forms.ColumnHeader();
                this.ColumnName.Text = "病区名称";
                this.ColumnName.Width = 120;
                this.lsvAreaInfo.Size = new System.Drawing.Size(220, 144);

                this.lsvAreaInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  ColumnNum,this.ColumnName});
                this.lsvAreaInfo.View = System.Windows.Forms.View.Details;
                this.lsvAreaInfo.FullRowSelect = true;
                this.lsvAreaInfo.GridLines = true;
                ((clsCtl_InhospitalReport)this.objController).LoadAreaID();
                if (lsvAreaInfo.Items.Count < 1)
                    return;
                if (lsvAreaInfo.Items.Count == 1)
                {
                    this.lsvAreaInfo.Items[0].Selected = true;
                    this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.Items[0].SubItems[1].Text;
                    this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.Items[0].Tag).m_strDEPTID_CHR;
                    return;
                }
                this.Controls.Add(this.lsvAreaInfo);
                //this.tabPage1.Controls.Add(this.lsvAreaInfo);
                this.lsvAreaInfo.Location = new System.Drawing.Point(395, 31);
                #endregion
                this.lsvAreaInfo.Items[0].Selected = true;
                this.lsvAreaInfo.Show();
                this.lsvAreaInfo.BringToFront();
                this.lsvAreaInfo.Focus();
            }
        }

        private void m_dtpBeginDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmInhospitalReport_Load(object sender, EventArgs e)
        {
            this.m_dsPrint.LibraryList = Application.StartupPath + "\\pb_new.pbl";
        }

        private void m_checkBoxArea_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_checkBoxArea.Checked == true)
            {
                frmAidDeptList fDept = new frmAidDeptList();
                if (fDept.ShowDialog() == DialogResult.OK)
                {
                    m_deptIDArr = fDept.DeptIDArr;
                }
            }
        }

        private void m_cmdArea_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                m_deptIDArr = fDept.DeptIDArr;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataGridView tmpDV = null;
            DataTable dt;
            if (this.m_tabControl1.SelectedIndex == 0)
            {
                 dt = this.m_dgvIn.DataSource as DataTable;
                ((clsCtl_InhospitalReport)this.objController).m_mthExportByDs(dt, "d_inpatient_log");
                tmpDV = this.m_dgvIn;
            }
            else if (this.m_tabControl1.SelectedIndex == 1)
            {
                dt = this.m_dgvOut.DataSource as DataTable;
                ((clsCtl_InhospitalReport)this.objController).m_mthExportByDs(dt, "d_out_log");
                tmpDV = this.m_dgvOut;
            }
            else if (this.m_tabControl1.SelectedIndex == 2)
            {
                dt = this.m_dgvTrArea.DataSource as DataTable;
                ((clsCtl_InhospitalReport)this.objController).m_mthExportByDs(dt, "d_trarea_log");
                tmpDV = this.m_dgvTrArea;
            }
            else if (this.m_tabControl1.SelectedIndex == 3)
            {
                dt = this.m_dgvTrBed.DataSource as DataTable;
                ((clsCtl_InhospitalReport)this.objController).m_mthExportByDs(dt, "d_trbed_log");
                tmpDV = this.m_dgvTrBed;
            }
            else
            {
                return;
            }

            //if (tmpDV.Rows.Count == 0)
            //{
            //    return;
            //}

            //clsPublic.m_mthDataTableExportToExcel(tmpDV);
        }

    }
}
