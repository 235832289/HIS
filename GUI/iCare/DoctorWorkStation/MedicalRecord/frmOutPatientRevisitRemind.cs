using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;

namespace iCare
{
	/// <summary>
	///出院病人复诊提醒设置
	/// </summary>
	public class frmOutPatientRevisitRemind : System.Windows.Forms.Form
	{
		#region  Define
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboDept;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboArea;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private com.digitalwave.controls.ctlRichTextBox m_txtRemindTips;
		private System.Windows.Forms.GroupBox gpbInPatientList;
		private System.Windows.Forms.NumericUpDown m_nudViewMo;
		private System.Windows.Forms.RadioButton m_rdbViewAll;
		private System.Windows.Forms.ListView m_lsvInPatientList;
		private System.Windows.Forms.RadioButton m_rdbViewPart;
		private System.Windows.Forms.GroupBox gpbRevisitDate;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpConcretelyTime;
		private System.Windows.Forms.RadioButton m_rdbPursuantMonth;
		private System.Windows.Forms.RadioButton m_rdbPursuantDate;
		private System.Windows.Forms.RadioButton m_rdbConcretelyTime;
		private System.Windows.Forms.NumericUpDown m_nudPursuantMonth;
		private System.Windows.Forms.NumericUpDown m_nudPursuantDate;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label m_lblName;
		private System.Windows.Forms.Label lblInPatientID;
		private System.Windows.Forms.Label m_lblInPatientID;
		private System.Windows.Forms.GroupBox gpbSelectedInPat;
		private System.Windows.Forms.Label m_lblLastOutDate;
		private System.Windows.Forms.Label m_lblLastInDate;
		private System.Windows.Forms.Label lblLastInDate;
		private System.Windows.Forms.Label lblLastOutDate;
		private System.Windows.Forms.GroupBox gpbRemindTime;
		private System.Windows.Forms.NumericUpDown m_nudRemindDate;
		private PinkieControls.ButtonXP m_cmdsave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool = new com.digitalwave.Utility.Controls.clsBorderTool(Color.White);
		private bool m_blnIsSaveNew = true;
		private bool m_blnCanDo = true;
		private string m_strRemindDate = DateTime.Now.AddMonths(1).ToString("yyyy年MM月dd日");
		private clsOutPatientRevisitDomain m_objDomain;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TreeView trvRevisitTime;
		private PinkieControls.ButtonXP m_cmdDelRevisitTime;
		private PinkieControls.ButtonXP m_cmdAddRevisitTime;
		private System.Windows.Forms.TextBox m_txtInpatientID;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpSearchEndTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpSearchStartTime;
		private PinkieControls.ButtonXP m_cmdSearchByInPatientID;
		private System.Windows.Forms.RadioButton m_rdbInPatientID;
		private System.Windows.Forms.RadioButton m_rdbPatientName;
		private System.Windows.Forms.TextBox m_txtPatientName;
		private System.Windows.Forms.RadioButton m_rdbOutHospitalPatient;
		private System.Windows.Forms.RadioButton m_rdbInHospitalPatient;
		private readonly string r_strTips = @"病人<NAME>，住院号：<INPATIENTID>，于<INPATIENTDATE>出院。定于<REVISITDATE>复诊，现已到期，请注意！";
		#endregion

		public frmOutPatientRevisitRemind()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_txtRemindTips});
			m_objDomain = new clsOutPatientRevisitDomain(m_cboDept,m_cboArea,m_lsvInPatientList);
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOutPatientRevisitRemind));
			this.m_cboDept = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_cboArea = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtRemindTips = new com.digitalwave.controls.ctlRichTextBox();
			this.gpbInPatientList = new System.Windows.Forms.GroupBox();
			this.m_txtInpatientID = new System.Windows.Forms.TextBox();
			this.m_rdbInPatientID = new System.Windows.Forms.RadioButton();
			this.m_dtpSearchEndTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_dtpSearchStartTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.m_cmdSearchByInPatientID = new PinkieControls.ButtonXP();
			this.m_lsvInPatientList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.m_nudViewMo = new System.Windows.Forms.NumericUpDown();
			this.m_rdbViewAll = new System.Windows.Forms.RadioButton();
			this.m_rdbViewPart = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.m_txtPatientName = new System.Windows.Forms.TextBox();
			this.m_rdbPatientName = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.gpbRevisitDate = new System.Windows.Forms.GroupBox();
			this.m_nudPursuantDate = new System.Windows.Forms.NumericUpDown();
			this.m_nudPursuantMonth = new System.Windows.Forms.NumericUpDown();
			this.m_dtpConcretelyTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_rdbPursuantMonth = new System.Windows.Forms.RadioButton();
			this.m_rdbPursuantDate = new System.Windows.Forms.RadioButton();
			this.m_rdbConcretelyTime = new System.Windows.Forms.RadioButton();
			this.label16 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.m_lblName = new System.Windows.Forms.Label();
			this.lblInPatientID = new System.Windows.Forms.Label();
			this.m_lblInPatientID = new System.Windows.Forms.Label();
			this.gpbSelectedInPat = new System.Windows.Forms.GroupBox();
			this.m_lblLastOutDate = new System.Windows.Forms.Label();
			this.m_lblLastInDate = new System.Windows.Forms.Label();
			this.lblLastInDate = new System.Windows.Forms.Label();
			this.lblLastOutDate = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.gpbRemindTime = new System.Windows.Forms.GroupBox();
			this.m_nudRemindDate = new System.Windows.Forms.NumericUpDown();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.m_cmdsave = new PinkieControls.ButtonXP();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_cmdDelRevisitTime = new PinkieControls.ButtonXP();
			this.m_cmdAddRevisitTime = new PinkieControls.ButtonXP();
			this.trvRevisitTime = new System.Windows.Forms.TreeView();
			this.m_rdbOutHospitalPatient = new System.Windows.Forms.RadioButton();
			this.m_rdbInHospitalPatient = new System.Windows.Forms.RadioButton();
			this.gpbInPatientList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_nudViewMo)).BeginInit();
			this.gpbRevisitDate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_nudPursuantDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_nudPursuantMonth)).BeginInit();
			this.gpbSelectedInPat.SuspendLayout();
			this.gpbRemindTime.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_nudRemindDate)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_cboDept
			// 
			this.m_cboDept.AccessibleDescription = "";
			this.m_cboDept.BackColor = System.Drawing.SystemColors.Control;
			this.m_cboDept.BorderColor = System.Drawing.Color.Black;
			this.m_cboDept.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboDept.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboDept.flatFont = new System.Drawing.Font("宋体", 10.5F);
			this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cboDept.ForeColor = System.Drawing.Color.Black;
			this.m_cboDept.ListBackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_cboDept.ListForeColor = System.Drawing.Color.Black;
			this.m_cboDept.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboDept.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboDept.Location = new System.Drawing.Point(80, 8);
			this.m_cboDept.m_BlnEnableItemEventMenu = true;
			this.m_cboDept.Name = "m_cboDept";
			this.m_cboDept.SelectedIndex = -1;
			this.m_cboDept.SelectedItem = null;
			this.m_cboDept.SelectionStart = -1;
			this.m_cboDept.Size = new System.Drawing.Size(164, 23);
			this.m_cboDept.TabIndex = 91;
			this.m_cboDept.TextBackColor = System.Drawing.Color.White;
			this.m_cboDept.TextForeColor = System.Drawing.Color.Black;
			this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 19);
			this.label1.TabIndex = 93;
			this.label1.Text = "科室：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(260, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 19);
			this.label2.TabIndex = 93;
			this.label2.Text = "病区：";
			// 
			// m_cboArea
			// 
			this.m_cboArea.AccessibleDescription = "";
			this.m_cboArea.BackColor = System.Drawing.SystemColors.Control;
			this.m_cboArea.BorderColor = System.Drawing.Color.Black;
			this.m_cboArea.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboArea.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboArea.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboArea.flatFont = new System.Drawing.Font("宋体", 10.5F);
			this.m_cboArea.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cboArea.ForeColor = System.Drawing.Color.Black;
			this.m_cboArea.ListBackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_cboArea.ListForeColor = System.Drawing.Color.Black;
			this.m_cboArea.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboArea.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboArea.Location = new System.Drawing.Point(320, 8);
			this.m_cboArea.m_BlnEnableItemEventMenu = true;
			this.m_cboArea.Name = "m_cboArea";
			this.m_cboArea.SelectedIndex = -1;
			this.m_cboArea.SelectedItem = null;
			this.m_cboArea.SelectionStart = -1;
			this.m_cboArea.Size = new System.Drawing.Size(164, 23);
			this.m_cboArea.TabIndex = 91;
			this.m_cboArea.TextBackColor = System.Drawing.Color.White;
			this.m_cboArea.TextForeColor = System.Drawing.Color.Black;
			this.m_cboArea.SelectedIndexChanged += new System.EventHandler(this.m_cboArea_SelectedIndexChanged);
			// 
			// m_txtRemindTips
			// 
			this.m_txtRemindTips.AccessibleDescription = "";
			this.m_txtRemindTips.AutoSize = true;
			this.m_txtRemindTips.BackColor = System.Drawing.Color.White;
			this.m_txtRemindTips.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_txtRemindTips.ForeColor = System.Drawing.Color.Black;
			this.m_txtRemindTips.Location = new System.Drawing.Point(16, 76);
			this.m_txtRemindTips.m_BlnIgnoreUserInfo = false;
			this.m_txtRemindTips.m_BlnPartControl = false;
			this.m_txtRemindTips.m_BlnReadOnly = false;
			this.m_txtRemindTips.m_BlnUnderLineDST = false;
			this.m_txtRemindTips.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtRemindTips.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtRemindTips.m_IntCanModifyTime = 6;
			this.m_txtRemindTips.m_IntPartControlLength = 0;
			this.m_txtRemindTips.m_IntPartControlStartIndex = 0;
			this.m_txtRemindTips.m_StrUserID = "";
			this.m_txtRemindTips.m_StrUserName = "";
			this.m_txtRemindTips.MaxLength = 100;
			this.m_txtRemindTips.Name = "m_txtRemindTips";
			this.m_txtRemindTips.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtRemindTips.Size = new System.Drawing.Size(320, 96);
			this.m_txtRemindTips.TabIndex = 92;
			this.m_txtRemindTips.Tag = "0";
			this.m_txtRemindTips.Text = "";
			// 
			// gpbInPatientList
			// 
			this.gpbInPatientList.Controls.Add(this.m_txtInpatientID);
			this.gpbInPatientList.Controls.Add(this.m_rdbInPatientID);
			this.gpbInPatientList.Controls.Add(this.m_dtpSearchEndTime);
			this.gpbInPatientList.Controls.Add(this.m_dtpSearchStartTime);
			this.gpbInPatientList.Controls.Add(this.label6);
			this.gpbInPatientList.Controls.Add(this.m_cmdSearchByInPatientID);
			this.gpbInPatientList.Controls.Add(this.m_lsvInPatientList);
			this.gpbInPatientList.Controls.Add(this.m_nudViewMo);
			this.gpbInPatientList.Controls.Add(this.m_rdbViewAll);
			this.gpbInPatientList.Controls.Add(this.m_rdbViewPart);
			this.gpbInPatientList.Controls.Add(this.label4);
			this.gpbInPatientList.Controls.Add(this.label7);
			this.gpbInPatientList.Controls.Add(this.label8);
			this.gpbInPatientList.Controls.Add(this.m_txtPatientName);
			this.gpbInPatientList.Controls.Add(this.m_rdbPatientName);
			this.gpbInPatientList.Location = new System.Drawing.Point(16, 52);
			this.gpbInPatientList.Name = "gpbInPatientList";
			this.gpbInPatientList.Size = new System.Drawing.Size(392, 532);
			this.gpbInPatientList.TabIndex = 94;
			this.gpbInPatientList.TabStop = false;
			this.gpbInPatientList.Text = "病人一览表";
			// 
			// m_txtInpatientID
			// 
			this.m_txtInpatientID.Location = new System.Drawing.Point(68, 20);
			this.m_txtInpatientID.Name = "m_txtInpatientID";
			this.m_txtInpatientID.TabIndex = 99;
			this.m_txtInpatientID.Text = "";
			this.m_txtInpatientID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtInpatientID_KeyPress);
			// 
			// m_rdbInPatientID
			// 
			this.m_rdbInPatientID.Checked = true;
			this.m_rdbInPatientID.Location = new System.Drawing.Point(4, 19);
			this.m_rdbInPatientID.Name = "m_rdbInPatientID";
			this.m_rdbInPatientID.Size = new System.Drawing.Size(68, 24);
			this.m_rdbInPatientID.TabIndex = 10000007;
			this.m_rdbInPatientID.TabStop = true;
			this.m_rdbInPatientID.Text = "住院号";
			this.m_rdbInPatientID.CheckedChanged += new System.EventHandler(this.m_rdbSearch_CheckedChanged);
			// 
			// m_dtpSearchEndTime
			// 
			this.m_dtpSearchEndTime.BorderColor = System.Drawing.Color.Black;
			this.m_dtpSearchEndTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpSearchEndTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtpSearchEndTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpSearchEndTime.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtpSearchEndTime.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpSearchEndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpSearchEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpSearchEndTime.Location = new System.Drawing.Point(202, 52);
			this.m_dtpSearchEndTime.m_BlnOnlyTime = false;
			this.m_dtpSearchEndTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpSearchEndTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpSearchEndTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpSearchEndTime.Name = "m_dtpSearchEndTime";
			this.m_dtpSearchEndTime.ReadOnly = false;
			this.m_dtpSearchEndTime.Size = new System.Drawing.Size(138, 22);
			this.m_dtpSearchEndTime.TabIndex = 10000006;
			this.m_dtpSearchEndTime.TextBackColor = System.Drawing.Color.White;
			this.m_dtpSearchEndTime.TextForeColor = System.Drawing.Color.Black;
			this.m_dtpSearchEndTime.evtValueChanged += new System.EventHandler(this.ctlTimePicker_evtValueChanged);
			// 
			// m_dtpSearchStartTime
			// 
			this.m_dtpSearchStartTime.BorderColor = System.Drawing.Color.Black;
			this.m_dtpSearchStartTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpSearchStartTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtpSearchStartTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpSearchStartTime.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtpSearchStartTime.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpSearchStartTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpSearchStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpSearchStartTime.Location = new System.Drawing.Point(48, 52);
			this.m_dtpSearchStartTime.m_BlnOnlyTime = false;
			this.m_dtpSearchStartTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpSearchStartTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpSearchStartTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpSearchStartTime.Name = "m_dtpSearchStartTime";
			this.m_dtpSearchStartTime.ReadOnly = false;
			this.m_dtpSearchStartTime.Size = new System.Drawing.Size(138, 22);
			this.m_dtpSearchStartTime.TabIndex = 10000006;
			this.m_dtpSearchStartTime.TextBackColor = System.Drawing.Color.White;
			this.m_dtpSearchStartTime.TextForeColor = System.Drawing.Color.Black;
			this.m_dtpSearchStartTime.evtValueChanged += new System.EventHandler(this.ctlTimePicker_evtValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 19);
			this.label6.TabIndex = 101;
			this.label6.Text = "显示从";
			// 
			// m_cmdSearchByInPatientID
			// 
			this.m_cmdSearchByInPatientID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSearchByInPatientID.DefaultScheme = true;
			this.m_cmdSearchByInPatientID.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdSearchByInPatientID.Hint = "";
			this.m_cmdSearchByInPatientID.Location = new System.Drawing.Point(324, 17);
			this.m_cmdSearchByInPatientID.Name = "m_cmdSearchByInPatientID";
			this.m_cmdSearchByInPatientID.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSearchByInPatientID.Size = new System.Drawing.Size(60, 28);
			this.m_cmdSearchByInPatientID.TabIndex = 100;
			this.m_cmdSearchByInPatientID.Text = "查  询";
			this.m_cmdSearchByInPatientID.Click += new System.EventHandler(this.m_cmdSearchByInPatientID_Click);
			// 
			// m_lsvInPatientList
			// 
			this.m_lsvInPatientList.BackColor = System.Drawing.Color.White;
			this.m_lsvInPatientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.columnHeader1,
																								 this.columnHeader2,
																								 this.columnHeader3,
																								 this.columnHeader4});
			this.m_lsvInPatientList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_lsvInPatientList.ForeColor = System.Drawing.Color.Black;
			this.m_lsvInPatientList.FullRowSelect = true;
			this.m_lsvInPatientList.GridLines = true;
			this.m_lsvInPatientList.Location = new System.Drawing.Point(3, 81);
			this.m_lsvInPatientList.MultiSelect = false;
			this.m_lsvInPatientList.Name = "m_lsvInPatientList";
			this.m_lsvInPatientList.Size = new System.Drawing.Size(386, 448);
			this.m_lsvInPatientList.TabIndex = 0;
			this.m_lsvInPatientList.View = System.Windows.Forms.View.Details;
			this.m_lsvInPatientList.SelectedIndexChanged += new System.EventHandler(this.m_lsvInPatientList_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "住  院  号";
			this.columnHeader1.Width = 90;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "姓  名";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 80;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "住院日期";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 120;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "复诊次数";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 70;
			// 
			// m_nudViewMo
			// 
			this.m_nudViewMo.BackColor = System.Drawing.Color.White;
			this.m_nudViewMo.ForeColor = System.Drawing.Color.Black;
			this.m_nudViewMo.Location = new System.Drawing.Point(204, 112);
			this.m_nudViewMo.Maximum = new System.Decimal(new int[] {
																		36,
																		0,
																		0,
																		0});
			this.m_nudViewMo.Minimum = new System.Decimal(new int[] {
																		1,
																		0,
																		0,
																		0});
			this.m_nudViewMo.Name = "m_nudViewMo";
			this.m_nudViewMo.Size = new System.Drawing.Size(40, 23);
			this.m_nudViewMo.TabIndex = 97;
			this.m_nudViewMo.Value = new System.Decimal(new int[] {
																	  3,
																	  0,
																	  0,
																	  0});
			this.m_nudViewMo.Visible = false;
			// 
			// m_rdbViewAll
			// 
			this.m_rdbViewAll.Location = new System.Drawing.Point(8, 116);
			this.m_rdbViewAll.Name = "m_rdbViewAll";
			this.m_rdbViewAll.Size = new System.Drawing.Size(92, 20);
			this.m_rdbViewAll.TabIndex = 1;
			this.m_rdbViewAll.Text = "显示全部";
			this.m_rdbViewAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_rdbViewAll.Visible = false;
			// 
			// m_rdbViewPart
			// 
			this.m_rdbViewPart.Location = new System.Drawing.Point(156, 116);
			this.m_rdbViewPart.Name = "m_rdbViewPart";
			this.m_rdbViewPart.Size = new System.Drawing.Size(224, 20);
			this.m_rdbViewPart.TabIndex = 1;
			this.m_rdbViewPart.Text = "显示      个月内出院病人";
			this.m_rdbViewPart.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_rdbViewPart.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(192, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(106, 19);
			this.label4.TabIndex = 93;
			this.label4.Text = "个月内出院病人";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(186, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(20, 19);
			this.label7.TabIndex = 101;
			this.label7.Text = "到";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(341, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 19);
			this.label8.TabIndex = 101;
			this.label8.Text = "的记录";
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Enabled = false;
			this.m_txtPatientName.Location = new System.Drawing.Point(220, 20);
			this.m_txtPatientName.Name = "m_txtPatientName";
			this.m_txtPatientName.TabIndex = 99;
			this.m_txtPatientName.Text = "";
			this.m_txtPatientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtPatientName_KeyPress);
			// 
			// m_rdbPatientName
			// 
			this.m_rdbPatientName.Location = new System.Drawing.Point(172, 19);
			this.m_rdbPatientName.Name = "m_rdbPatientName";
			this.m_rdbPatientName.Size = new System.Drawing.Size(52, 24);
			this.m_rdbPatientName.TabIndex = 10000007;
			this.m_rdbPatientName.Text = "姓名";
			this.m_rdbPatientName.CheckedChanged += new System.EventHandler(this.m_rdbSearch_CheckedChanged);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Yellow;
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(12, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(750, 1);
			this.label3.TabIndex = 95;
			// 
			// gpbRevisitDate
			// 
			this.gpbRevisitDate.Controls.Add(this.m_nudPursuantDate);
			this.gpbRevisitDate.Controls.Add(this.m_nudPursuantMonth);
			this.gpbRevisitDate.Controls.Add(this.m_dtpConcretelyTime);
			this.gpbRevisitDate.Controls.Add(this.m_rdbPursuantMonth);
			this.gpbRevisitDate.Controls.Add(this.m_rdbPursuantDate);
			this.gpbRevisitDate.Controls.Add(this.m_rdbConcretelyTime);
			this.gpbRevisitDate.Controls.Add(this.label16);
			this.gpbRevisitDate.Location = new System.Drawing.Point(416, 180);
			this.gpbRevisitDate.Name = "gpbRevisitDate";
			this.gpbRevisitDate.Size = new System.Drawing.Size(344, 108);
			this.gpbRevisitDate.TabIndex = 96;
			this.gpbRevisitDate.TabStop = false;
			this.gpbRevisitDate.Text = "复诊时间";
			// 
			// m_nudPursuantDate
			// 
			this.m_nudPursuantDate.BackColor = System.Drawing.Color.White;
			this.m_nudPursuantDate.Enabled = false;
			this.m_nudPursuantDate.ForeColor = System.Drawing.Color.Black;
			this.m_nudPursuantDate.Location = new System.Drawing.Point(136, 52);
			this.m_nudPursuantDate.Maximum = new System.Decimal(new int[] {
																			  1000,
																			  0,
																			  0,
																			  0});
			this.m_nudPursuantDate.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
			this.m_nudPursuantDate.Name = "m_nudPursuantDate";
			this.m_nudPursuantDate.Size = new System.Drawing.Size(44, 23);
			this.m_nudPursuantDate.TabIndex = 97;
			this.m_nudPursuantDate.Value = new System.Decimal(new int[] {
																			20,
																			0,
																			0,
																			0});
			this.m_nudPursuantDate.ValueChanged += new System.EventHandler(this.m_nudPursuantDate_ValueChanged);
			// 
			// m_nudPursuantMonth
			// 
			this.m_nudPursuantMonth.BackColor = System.Drawing.Color.White;
			this.m_nudPursuantMonth.ForeColor = System.Drawing.Color.Black;
			this.m_nudPursuantMonth.Location = new System.Drawing.Point(136, 24);
			this.m_nudPursuantMonth.Maximum = new System.Decimal(new int[] {
																			   60,
																			   0,
																			   0,
																			   0});
			this.m_nudPursuantMonth.Minimum = new System.Decimal(new int[] {
																			   1,
																			   0,
																			   0,
																			   0});
			this.m_nudPursuantMonth.Name = "m_nudPursuantMonth";
			this.m_nudPursuantMonth.Size = new System.Drawing.Size(44, 23);
			this.m_nudPursuantMonth.TabIndex = 97;
			this.m_nudPursuantMonth.Value = new System.Decimal(new int[] {
																			 1,
																			 0,
																			 0,
																			 0});
			this.m_nudPursuantMonth.ValueChanged += new System.EventHandler(this.m_nudPursuantMonth_ValueChanged);
			// 
			// m_dtpConcretelyTime
			// 
			this.m_dtpConcretelyTime.BorderColor = System.Drawing.Color.Black;
			this.m_dtpConcretelyTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpConcretelyTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtpConcretelyTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpConcretelyTime.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtpConcretelyTime.Enabled = false;
			this.m_dtpConcretelyTime.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpConcretelyTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpConcretelyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpConcretelyTime.Location = new System.Drawing.Point(104, 80);
			this.m_dtpConcretelyTime.m_BlnOnlyTime = false;
			this.m_dtpConcretelyTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpConcretelyTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpConcretelyTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpConcretelyTime.Name = "m_dtpConcretelyTime";
			this.m_dtpConcretelyTime.ReadOnly = false;
			this.m_dtpConcretelyTime.Size = new System.Drawing.Size(212, 22);
			this.m_dtpConcretelyTime.TabIndex = 10000005;
			this.m_dtpConcretelyTime.TextBackColor = System.Drawing.Color.White;
			this.m_dtpConcretelyTime.TextForeColor = System.Drawing.Color.Black;
			this.m_dtpConcretelyTime.evtTextChanged += new System.EventHandler(this.m_dtpConcretelyTime_evtTextChanged);
			// 
			// m_rdbPursuantMonth
			// 
			this.m_rdbPursuantMonth.Checked = true;
			this.m_rdbPursuantMonth.Location = new System.Drawing.Point(4, 24);
			this.m_rdbPursuantMonth.Name = "m_rdbPursuantMonth";
			this.m_rdbPursuantMonth.Size = new System.Drawing.Size(248, 24);
			this.m_rdbPursuantMonth.TabIndex = 2;
			this.m_rdbPursuantMonth.TabStop = true;
			this.m_rdbPursuantMonth.Text = "按月数     出院        个月后";
			this.m_rdbPursuantMonth.CheckedChanged += new System.EventHandler(this.m_rdbPursuantMonth_CheckedChanged);
			// 
			// m_rdbPursuantDate
			// 
			this.m_rdbPursuantDate.Location = new System.Drawing.Point(4, 52);
			this.m_rdbPursuantDate.Name = "m_rdbPursuantDate";
			this.m_rdbPursuantDate.Size = new System.Drawing.Size(248, 24);
			this.m_rdbPursuantDate.TabIndex = 2;
			this.m_rdbPursuantDate.Text = "按天数     出院        天后";
			this.m_rdbPursuantDate.CheckedChanged += new System.EventHandler(this.m_rdbPursuantDate_CheckedChanged);
			// 
			// m_rdbConcretelyTime
			// 
			this.m_rdbConcretelyTime.Location = new System.Drawing.Point(4, 80);
			this.m_rdbConcretelyTime.Name = "m_rdbConcretelyTime";
			this.m_rdbConcretelyTime.Size = new System.Drawing.Size(92, 24);
			this.m_rdbConcretelyTime.TabIndex = 2;
			this.m_rdbConcretelyTime.Text = "具体时间";
			this.m_rdbConcretelyTime.CheckedChanged += new System.EventHandler(this.m_rdbConcretelyTime_CheckedChanged);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(104, 52);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(34, 19);
			this.label16.TabIndex = 93;
			this.label16.Text = "出院";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(200, 28);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(41, 19);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "姓名:";
			// 
			// m_lblName
			// 
			this.m_lblName.Location = new System.Drawing.Point(252, 28);
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(88, 19);
			this.m_lblName.TabIndex = 0;
			// 
			// lblInPatientID
			// 
			this.lblInPatientID.AutoSize = true;
			this.lblInPatientID.Location = new System.Drawing.Point(8, 28);
			this.lblInPatientID.Name = "lblInPatientID";
			this.lblInPatientID.Size = new System.Drawing.Size(56, 19);
			this.lblInPatientID.TabIndex = 0;
			this.lblInPatientID.Text = "住院号:";
			// 
			// m_lblInPatientID
			// 
			this.m_lblInPatientID.Location = new System.Drawing.Point(76, 28);
			this.m_lblInPatientID.Name = "m_lblInPatientID";
			this.m_lblInPatientID.Size = new System.Drawing.Size(120, 19);
			this.m_lblInPatientID.TabIndex = 0;
			// 
			// gpbSelectedInPat
			// 
			this.gpbSelectedInPat.Controls.Add(this.m_lblName);
			this.gpbSelectedInPat.Controls.Add(this.m_lblInPatientID);
			this.gpbSelectedInPat.Controls.Add(this.lblInPatientID);
			this.gpbSelectedInPat.Controls.Add(this.lblName);
			this.gpbSelectedInPat.Controls.Add(this.m_lblLastOutDate);
			this.gpbSelectedInPat.Controls.Add(this.m_lblLastInDate);
			this.gpbSelectedInPat.Controls.Add(this.lblLastInDate);
			this.gpbSelectedInPat.Controls.Add(this.lblLastOutDate);
			this.gpbSelectedInPat.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gpbSelectedInPat.Location = new System.Drawing.Point(416, 52);
			this.gpbSelectedInPat.Name = "gpbSelectedInPat";
			this.gpbSelectedInPat.Size = new System.Drawing.Size(344, 100);
			this.gpbSelectedInPat.TabIndex = 1;
			this.gpbSelectedInPat.TabStop = false;
			this.gpbSelectedInPat.Text = "当前选择病人";
			// 
			// m_lblLastOutDate
			// 
			this.m_lblLastOutDate.Location = new System.Drawing.Point(120, 76);
			this.m_lblLastOutDate.Name = "m_lblLastOutDate";
			this.m_lblLastOutDate.Size = new System.Drawing.Size(212, 19);
			this.m_lblLastOutDate.TabIndex = 0;
			// 
			// m_lblLastInDate
			// 
			this.m_lblLastInDate.Location = new System.Drawing.Point(120, 52);
			this.m_lblLastInDate.Name = "m_lblLastInDate";
			this.m_lblLastInDate.Size = new System.Drawing.Size(212, 19);
			this.m_lblLastInDate.TabIndex = 0;
			// 
			// lblLastInDate
			// 
			this.lblLastInDate.AutoSize = true;
			this.lblLastInDate.Location = new System.Drawing.Point(8, 52);
			this.lblLastInDate.Name = "lblLastInDate";
			this.lblLastInDate.Size = new System.Drawing.Size(99, 19);
			this.lblLastInDate.TabIndex = 0;
			this.lblLastInDate.Text = "最近住院日期:";
			// 
			// lblLastOutDate
			// 
			this.lblLastOutDate.AutoSize = true;
			this.lblLastOutDate.Location = new System.Drawing.Point(8, 76);
			this.lblLastOutDate.Name = "lblLastOutDate";
			this.lblLastOutDate.Size = new System.Drawing.Size(99, 19);
			this.lblLastOutDate.TabIndex = 0;
			this.lblLastOutDate.Text = "最近出院日期:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(420, 156);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(70, 19);
			this.label13.TabIndex = 93;
			this.label13.Text = "复诊设置:";
			// 
			// gpbRemindTime
			// 
			this.gpbRemindTime.Controls.Add(this.m_txtRemindTips);
			this.gpbRemindTime.Controls.Add(this.m_nudRemindDate);
			this.gpbRemindTime.Controls.Add(this.label18);
			this.gpbRemindTime.Controls.Add(this.label19);
			this.gpbRemindTime.Controls.Add(this.label20);
			this.gpbRemindTime.Location = new System.Drawing.Point(416, 296);
			this.gpbRemindTime.Name = "gpbRemindTime";
			this.gpbRemindTime.Size = new System.Drawing.Size(344, 180);
			this.gpbRemindTime.TabIndex = 97;
			this.gpbRemindTime.TabStop = false;
			this.gpbRemindTime.Text = "提醒时间";
			// 
			// m_nudRemindDate
			// 
			this.m_nudRemindDate.BackColor = System.Drawing.Color.White;
			this.m_nudRemindDate.ForeColor = System.Drawing.Color.Black;
			this.m_nudRemindDate.Location = new System.Drawing.Point(56, 24);
			this.m_nudRemindDate.Maximum = new System.Decimal(new int[] {
																			60,
																			0,
																			0,
																			0});
			this.m_nudRemindDate.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.m_nudRemindDate.Name = "m_nudRemindDate";
			this.m_nudRemindDate.Size = new System.Drawing.Size(48, 23);
			this.m_nudRemindDate.TabIndex = 97;
			this.m_nudRemindDate.Value = new System.Decimal(new int[] {
																		  1,
																		  0,
																		  0,
																		  0});
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(16, 28);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(34, 19);
			this.label18.TabIndex = 93;
			this.label18.Text = "提前";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(112, 28);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(20, 19);
			this.label19.TabIndex = 93;
			this.label19.Text = "天";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(16, 52);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(106, 19);
			this.label20.TabIndex = 93;
			this.label20.Text = "提醒标示内容：";
			// 
			// m_cmdsave
			// 
			this.m_cmdsave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdsave.DefaultScheme = true;
			this.m_cmdsave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdsave.Hint = "";
			this.m_cmdsave.Location = new System.Drawing.Point(680, 68);
			this.m_cmdsave.Name = "m_cmdsave";
			this.m_cmdsave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdsave.Size = new System.Drawing.Size(75, 28);
			this.m_cmdsave.TabIndex = 98;
			this.m_cmdsave.Text = "保  存";
			this.m_cmdsave.Visible = false;
			this.m_cmdsave.Click += new System.EventHandler(this.m_cmdsave_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_cmdDelRevisitTime);
			this.groupBox1.Controls.Add(this.m_cmdAddRevisitTime);
			this.groupBox1.Controls.Add(this.trvRevisitTime);
			this.groupBox1.Location = new System.Drawing.Point(416, 484);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(344, 100);
			this.groupBox1.TabIndex = 100;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "保存复诊提醒设置";
			// 
			// m_cmdDelRevisitTime
			// 
			this.m_cmdDelRevisitTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDelRevisitTime.DefaultScheme = true;
			this.m_cmdDelRevisitTime.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDelRevisitTime.Hint = "";
			this.m_cmdDelRevisitTime.Location = new System.Drawing.Point(16, 64);
			this.m_cmdDelRevisitTime.Name = "m_cmdDelRevisitTime";
			this.m_cmdDelRevisitTime.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDelRevisitTime.Size = new System.Drawing.Size(75, 28);
			this.m_cmdDelRevisitTime.TabIndex = 10000010;
			this.m_cmdDelRevisitTime.Text = "删  除";
			this.m_cmdDelRevisitTime.Click += new System.EventHandler(this.m_cmdDelRevisitTime_Click);
			// 
			// m_cmdAddRevisitTime
			// 
			this.m_cmdAddRevisitTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAddRevisitTime.DefaultScheme = true;
			this.m_cmdAddRevisitTime.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAddRevisitTime.Hint = "";
			this.m_cmdAddRevisitTime.Location = new System.Drawing.Point(16, 24);
			this.m_cmdAddRevisitTime.Name = "m_cmdAddRevisitTime";
			this.m_cmdAddRevisitTime.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAddRevisitTime.Size = new System.Drawing.Size(75, 28);
			this.m_cmdAddRevisitTime.TabIndex = 10000009;
			this.m_cmdAddRevisitTime.Text = "添  加";
			this.m_cmdAddRevisitTime.Click += new System.EventHandler(this.m_cmdAddRevisitTime_Click);
			// 
			// trvRevisitTime
			// 
			this.trvRevisitTime.BackColor = System.Drawing.SystemColors.Window;
			this.trvRevisitTime.ForeColor = System.Drawing.SystemColors.WindowText;
			this.trvRevisitTime.ImageIndex = -1;
			this.trvRevisitTime.Location = new System.Drawing.Point(112, 24);
			this.trvRevisitTime.Name = "trvRevisitTime";
			this.trvRevisitTime.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					   new System.Windows.Forms.TreeNode("复诊时间")});
			this.trvRevisitTime.SelectedImageIndex = -1;
			this.trvRevisitTime.Size = new System.Drawing.Size(224, 72);
			this.trvRevisitTime.TabIndex = 10000008;
			this.trvRevisitTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvRevisitTime_AfterSelect);
			// 
			// m_rdbOutHospitalPatient
			// 
			this.m_rdbOutHospitalPatient.Checked = true;
			this.m_rdbOutHospitalPatient.Location = new System.Drawing.Point(532, 8);
			this.m_rdbOutHospitalPatient.Name = "m_rdbOutHospitalPatient";
			this.m_rdbOutHospitalPatient.Size = new System.Drawing.Size(84, 24);
			this.m_rdbOutHospitalPatient.TabIndex = 10000007;
			this.m_rdbOutHospitalPatient.TabStop = true;
			this.m_rdbOutHospitalPatient.Text = "出院病人";
			this.m_rdbOutHospitalPatient.CheckedChanged += new System.EventHandler(this.m_rdbOutHospitalPatient_CheckedChanged);
			// 
			// m_rdbInHospitalPatient
			// 
			this.m_rdbInHospitalPatient.Location = new System.Drawing.Point(628, 8);
			this.m_rdbInHospitalPatient.Name = "m_rdbInHospitalPatient";
			this.m_rdbInHospitalPatient.Size = new System.Drawing.Size(84, 24);
			this.m_rdbInHospitalPatient.TabIndex = 10000007;
			this.m_rdbInHospitalPatient.Text = "在院病人";
			this.m_rdbInHospitalPatient.CheckedChanged += new System.EventHandler(this.m_rdbInHospitalPatient_CheckedChanged);
			// 
			// frmOutPatientRevisitRemind
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(772, 589);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.m_cmdsave);
			this.Controls.Add(this.gpbRemindTime);
			this.Controls.Add(this.gpbRevisitDate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.gpbInPatientList);
			this.Controls.Add(this.m_cboDept);
			this.Controls.Add(this.m_cboArea);
			this.Controls.Add(this.gpbSelectedInPat);
			this.Controls.Add(this.m_rdbOutHospitalPatient);
			this.Controls.Add(this.m_rdbInHospitalPatient);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmOutPatientRevisitRemind";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "病人复诊\\随访提醒设置";
			this.Load += new System.EventHandler(this.frmOutPatientRevisitRemind_Load);
			this.gpbInPatientList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_nudViewMo)).EndInit();
			this.gpbRevisitDate.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_nudPursuantDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_nudPursuantMonth)).EndInit();
			this.gpbSelectedInPat.ResumeLayout(false);
			this.gpbRemindTime.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_nudRemindDate)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_mthInitilize()
		{
			m_objDomain.m_mthInitilize();
			m_dtpConcretelyTime.Value = DateTime.Now.AddMonths(int.Parse(m_nudPursuantMonth.Value.ToString()));
			m_dtpSearchStartTime.Value = DateTime.Now.AddDays(-10);
		}

		private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			m_mthClearAll();
			m_objDomain.m_thDept_SelectedIndexChanged();
			this.Cursor=Cursors.Default;
			if(m_cboArea.GetItemsCount() <= 0)
			{
				m_mthDisplayPatient();
			}
		}

		private void m_cboArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboArea.SelectedIndex < 0)
				return;
			m_mthClearAll();
			m_mthDisplayPatient();
		}

		private void m_rdbViewPart_CheckedChanged(object sender, System.EventArgs e)
		{
			m_nudViewMo.Enabled = m_rdbViewPart.Checked;
			m_mthDisplayPatient();
		}
		private void m_mthDisplayPatient()
		{
			this.Cursor=Cursors.WaitCursor;
			string strDate = "1900-1-1";
			if(m_rdbViewPart.Checked)
			{
				try
				{
					strDate = DateTime.Now.AddMonths(-1*Convert.ToInt32(m_nudViewMo.Value)).ToString("yyyy-MM-dd 00:00:00");}
				catch{strDate = "1900-1-1";}
			}

			if(m_dtpSearchStartTime.Value < m_dtpSearchEndTime.Value)
			{
				if(m_rdbOutHospitalPatient.Checked)
					m_objDomain.m_mthDisplayPatient(m_dtpSearchStartTime.Value.ToString("yyyy-MM-dd 00:00:00"),m_dtpSearchEndTime.Value.ToString("yyyy-MM-dd 00:00:00"),false,true);
				else if(m_rdbInHospitalPatient.Checked)
					m_objDomain.m_mthDisplayPatient(m_dtpSearchStartTime.Value.ToString("yyyy-MM-dd 00:00:00"),m_dtpSearchEndTime.Value.ToString("yyyy-MM-dd 00:00:00"),false,false);
			}
			this.Cursor=Cursors.Default;
		}

		private void m_rdbPursuantDate_CheckedChanged(object sender, System.EventArgs e)
		{
			m_mthSetEnable();
			if(m_lblLastOutDate.Text.Trim() == "")
				m_dtpConcretelyTime.Value = DateTime.Now.AddDays(int.Parse(m_nudPursuantDate.Value.ToString()));
			else
				m_dtpConcretelyTime.Value = DateTime.Parse(m_lblLastOutDate.Text.Trim()).AddDays(int.Parse(m_nudPursuantDate.Value.ToString()));
		}
		private void m_mthSetEnable()
		{
			m_nudPursuantDate.Enabled = m_rdbPursuantDate.Checked;
			m_nudPursuantMonth.Enabled = m_rdbPursuantMonth.Checked;
			m_dtpConcretelyTime.Enabled = m_rdbConcretelyTime.Checked;
		}

		private void m_rdbPursuantMonth_CheckedChanged(object sender, System.EventArgs e)
		{
			m_mthSetEnable();
			if(m_lblLastOutDate.Text.Trim() == "")
				m_dtpConcretelyTime.Value = DateTime.Now.AddMonths(int.Parse(m_nudPursuantMonth.Value.ToString()));
			else
				m_dtpConcretelyTime.Value = DateTime.Parse(m_lblLastOutDate.Text.Trim()).AddMonths(int.Parse(m_nudPursuantMonth.Value.ToString()));
		}

		private void m_rdbConcretelyTime_CheckedChanged(object sender, System.EventArgs e)
		{
			m_mthSetEnable();
			m_dtpConcretelyTime_evtTextChanged(null, null);
		}

		private void m_lsvInPatientList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsvInPatientList.SelectedItems.Count <= 0)
				return;
			clsPatient objPatient = m_lsvInPatientList.SelectedItems[0].Tag as clsPatient;
			m_mthClearItems();
			if(objPatient != null)
			{
				m_lblInPatientID.Text = objPatient.m_StrInPatientID;
				m_lblName.Text = objPatient.m_StrName;
				m_lblLastInDate.Text = objPatient.m_DtmLastInDate.ToString("yyyy年MM月dd日 HH时");
				if(objPatient.m_DtmLastOutDate.ToString("yyyy-M-d") == "1900-1-1")
					m_lblLastOutDate.Text = "";
				else
					m_lblLastOutDate.Text = objPatient.m_DtmLastOutDate.ToString("yyyy年MM月dd日 HH时");
				gpbSelectedInPat.Tag = objPatient;
				if(m_rdbPursuantMonth.Checked)
				{
					if(m_lblLastOutDate.Text.Trim() == "")
						m_dtpConcretelyTime.Value = DateTime.Now.AddMonths(int.Parse(m_nudPursuantMonth.Value.ToString()));
					else
						m_dtpConcretelyTime.Value = DateTime.Parse(m_lblLastOutDate.Text.Trim()).AddMonths(int.Parse(m_nudPursuantMonth.Value.ToString()));
				}
//				string str = r_strTips;
//				m_txtRemindTips.Text = str.Replace("<NAME>",objPatient.m_StrName).Replace("<INPATIENTID>",objPatient.m_StrInPatientID).Replace("<INPATIENTDATE>",objPatient.m_DtmLastOutDate.ToString("yyyy年MM月dd日")).Replace("<REVISITDATE>",m_strRemindDate);
				m_mthViewRecoed(objPatient);
				m_blnIsSaveNew = true;
				if(objPatient.m_IntRevisitStatus != 0)
					m_blnIsSaveNew = false;
			}
		}
		private void m_mthViewRecoed(clsPatient p_objPatient)
		{
			if(p_objPatient == null)
				return;
			clsOutPatientRevisitRemind_VO[] objValue = null;
			m_objDomain.m_lngGetRemindRecord(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate,out objValue);
			if(objValue != null)
			{
				for(int i=0; i<objValue.Length; i++)
				{
					m_blnCanDo = false;
					if(objValue[i].m_IntRevisitType == 0)
					{
						m_rdbPursuantDate.Checked = true;
						try
						{
							m_nudPursuantDate.Value = Convert.ToDecimal(objValue[i].m_IntRevisitTypeContent);}
						catch{}
					}
					else if(objValue[i].m_IntRevisitType == 1)
					{
						m_rdbPursuantMonth.Checked = true;
						try
						{
							m_nudPursuantMonth.Value = Convert.ToDecimal(objValue[i].m_IntRevisitTypeContent);}
						catch{}
					}
					else
					{
						m_rdbConcretelyTime.Checked = true;
						try
						{
							m_dtpConcretelyTime.Value = DateTime.Parse(objValue[i].m_StrRevisitTime);}
						catch{}
					}
					try
					{
						m_nudRemindDate.Value = decimal.Parse(objValue[i].m_IntBeforeRemindDate.ToString());}
					catch{}
//					m_txtRemindTips.Text = objValue[i].m_StrRemaindText;

					if(objValue[i].m_IntStatus == 1)
					{
						TreeNode trnNew=new TreeNode(objValue[i].m_StrRevisitTime);
						trvRevisitTime.Nodes[0].Nodes.Insert(0,trnNew);
//						trvRevisitTime.SelectedNode= trnNew;
					}

					m_blnCanDo = true;
				}
				clsSortTool objs = new clsSortTool();
				objs.m_mthSortTreeNode(trvRevisitTime.Nodes[0],false);
				if(trvRevisitTime.Nodes[0].Nodes.Count > 0)
				{
					trvRevisitTime.SelectedNode = trvRevisitTime.Nodes[0].Nodes[0];
				}
			}
		}
		private void m_mthClearAll()
		{
			m_lsvInPatientList.Items.Clear();
			m_mthClearItems();
		}
		private void m_mthClearItems()
		{
			m_lblInPatientID.Text = "";
			m_lblName.Text = "";
			m_lblLastInDate.Text = "";
			m_lblLastOutDate.Text = "";
			gpbSelectedInPat.Tag = null;
			m_dtpConcretelyTime.Value = DateTime.Now.AddMonths(int.Parse(m_nudPursuantMonth.Value.ToString()));
			m_rdbPursuantMonth.Checked = true;
			m_nudPursuantDate.Value = 20;
			m_nudRemindDate.Value = 1;
			m_nudPursuantMonth.Value = 1;
			m_txtRemindTips.Text = "";
			trvRevisitTime.Nodes[0].Nodes.Clear();
			m_txtInpatientID.Text = "";
			m_txtPatientName.Text = "";
		}

		private void m_cmdsave_Click(object sender, System.EventArgs e)
		{
			clsPatient objPatient = null;
			if(gpbSelectedInPat.Tag is clsPatient)
				objPatient = gpbSelectedInPat.Tag as clsPatient;
			else if(m_lsvInPatientList.SelectedItems.Count > 0)
			{
				objPatient = m_lsvInPatientList.SelectedItems[0].Tag as clsPatient;
			}
			if(objPatient == null)
				return;
			clsOutPatientRevisitRemind_VO objValue = new clsOutPatientRevisitRemind_VO();
			objValue.m_StrInPatientID = objPatient.m_StrInPatientID;
			objValue.m_DtmInPatientDate = objPatient.m_DtmLastInDate;
			objValue.m_DtmInPatientEndDate = objPatient.m_DtmLastOutDate;
			objValue.m_IntBeforeRemindDate = Convert.ToInt32(m_nudRemindDate.Value);

			objValue.m_IntTimes = objPatient.m_IntRevisitTimes+1;
			if(m_rdbPursuantDate.Checked)
			{
				objValue.m_IntRevisitType = 0;
				objValue.m_IntRevisitTypeContent = Convert.ToInt32(m_nudPursuantDate.Value);
				objValue.m_StrRevisitTime = DateTime.Now.AddDays(Convert.ToInt32(m_nudPursuantDate.Value)).ToString("yyyy-MM-dd HH:mm:ss");
			}
			else if(m_rdbPursuantMonth.Checked)
			{
				objValue.m_IntRevisitType = 1;
				objValue.m_IntRevisitTypeContent = Convert.ToInt32(m_nudPursuantMonth.Value);
				objValue.m_StrRevisitTime = DateTime.Now.AddMonths(Convert.ToInt32(m_nudPursuantMonth.Value)).ToString("yyyy-MM-dd HH:mm:ss");
			}
			else
			{
				objValue.m_IntRevisitType = 2;
				objValue.m_IntRevisitTypeContent = 0;
				objValue.m_StrRevisitTime = m_dtpConcretelyTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
			}
			objValue.m_StrRemaindText = m_txtRemindTips.Text;
			objValue.m_IntStatus = 1;
			long lngRes = 0;
			if(m_blnIsSaveNew)
				lngRes = m_objDomain.m_lngAddRemindRecord(objValue);
			else
				lngRes = m_objDomain.m_lngModifyRemindRecord(objValue);
			if(lngRes > 0)
				MDIParent.ShowInformationMessageBox("保存成功！");
			else
				MDIParent.ShowInformationMessageBox("保存失败！");
		}

		private void m_nudPursuantMonth_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanDo)
				return;
			m_strRemindDate = DateTime.Now.AddMonths(Convert.ToInt32(m_nudPursuantMonth.Value)).ToString("yyyy年MM月dd日");
			m_mthShowText();
		}

		private void m_nudPursuantDate_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanDo)
				return;
			m_strRemindDate = DateTime.Now.AddDays(Convert.ToInt32(m_nudPursuantDate.Value)).ToString("yyyy年MM月dd日");
			m_mthShowText();
		}

		private void m_dtpConcretelyTime_evtTextChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanDo)
				return;
			m_strRemindDate = m_dtpConcretelyTime.Value.ToString("yyyy年MM月dd日");
			m_mthShowText();
		}
		private void m_mthShowText()
		{
			if(gpbSelectedInPat.Tag is clsPatient)
			{
				clsPatient objPatient = gpbSelectedInPat.Tag as clsPatient;
				string str = r_strTips;
				m_txtRemindTips.Text = str.Replace("<NAME>",objPatient.m_StrName).Replace("<INPATIENTID>",objPatient.m_StrInPatientID).Replace("<INPATIENTDATE>",objPatient.m_DtmLastOutDate.ToString("yyyy年MM月dd日")).Replace("<REVISITDATE>",m_strRemindDate);
			}
		}

		private void frmOutPatientRevisitRemind_Load(object sender, System.EventArgs e)
		{
			m_mthInitilize();
		}

		private void m_nudViewMo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (byte)13)//回车
			{
				m_mthDisplayPatient();
			}
		}

		private void m_cmdAddRevisitTime_Click(object sender, System.EventArgs e)
		{
			clsPatient objPatient = null;
			TreeNode trnNew;
			if(gpbSelectedInPat.Tag is clsPatient)
				objPatient = gpbSelectedInPat.Tag as clsPatient;
			else if(m_lsvInPatientList.SelectedItems.Count > 0)
			{
				objPatient = m_lsvInPatientList.SelectedItems[0].Tag as clsPatient;
			}
			if(objPatient == null)
				return;
			clsOutPatientRevisitRemind_VO objValue = new clsOutPatientRevisitRemind_VO();
			objValue.m_StrInPatientID = objPatient.m_StrInPatientID;
			objValue.m_DtmInPatientDate = objPatient.m_DtmLastInDate;
			objValue.m_DtmInPatientEndDate = objPatient.m_DtmLastOutDate;
			objValue.m_IntBeforeRemindDate = Convert.ToInt32(m_nudRemindDate.Value);

			objValue.m_IntTimes = objPatient.m_IntRevisitTimes+1;

			if(m_rdbPursuantDate.Checked)
			{
				objValue.m_IntRevisitType = 0;
				objValue.m_IntRevisitTypeContent = Convert.ToInt32(m_nudPursuantDate.Value);
				if(m_lblLastOutDate.Text == string.Empty)
				{
					objValue.m_StrRevisitTime = DateTime.Now.AddDays(Convert.ToInt32(m_nudPursuantDate.Value)).ToString("yyyy-MM-dd HH:mm:ss");

					trnNew=new TreeNode(DateTime.Now.AddDays(Convert.ToInt32(m_nudPursuantDate.Value)).ToString("yyyy-MM-dd HH:mm:ss"));
				}
				else
				{
					objValue.m_StrRevisitTime = DateTime.Parse(m_lblLastOutDate.Text.Trim()).AddDays(Convert.ToInt32(m_nudPursuantDate.Value)).ToString("yyyy-MM-dd HH:mm:ss");

					trnNew=new TreeNode(DateTime.Parse(m_lblLastOutDate.Text.Trim()).AddDays(Convert.ToInt32(m_nudPursuantDate.Value)).ToString("yyyy-MM-dd HH:mm:ss"));
				}
			}
				 
			else if(m_rdbPursuantMonth.Checked)
			{
				objValue.m_IntRevisitType = 1;
				objValue.m_IntRevisitTypeContent = Convert.ToInt32(m_nudPursuantMonth.Value);
				if(m_lblLastOutDate.Text == string.Empty)
				{
					objValue.m_StrRevisitTime = DateTime.Now.AddMonths(Convert.ToInt32(m_nudPursuantMonth.Value)).ToString("yyyy-MM-dd HH:mm:ss");

					trnNew=new TreeNode(DateTime.Now.AddMonths(Convert.ToInt32(m_nudPursuantMonth.Value)).ToString("yyyy-MM-dd HH:mm:ss"));
				}
				else
				{
					objValue.m_StrRevisitTime = DateTime.Parse(m_lblLastOutDate.Text.Trim()).AddMonths(Convert.ToInt32(m_nudPursuantMonth.Value)).ToString("yyyy-MM-dd HH:mm:ss");

					trnNew=new TreeNode(DateTime.Parse(m_lblLastOutDate.Text.Trim()).AddMonths(Convert.ToInt32(m_nudPursuantMonth.Value)).ToString("yyyy-MM-dd HH:mm:ss"));
				}
			}
			else
			{
				objValue.m_IntRevisitType = 2;
				objValue.m_IntRevisitTypeContent = 0;
				objValue.m_StrRevisitTime = m_dtpConcretelyTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

				trnNew=new TreeNode(m_dtpConcretelyTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
			}

			objValue.m_StrRemaindText = m_txtRemindTips.Text;
			objValue.m_IntStatus = 1;

			m_blnIsSaveNew = true;
			if(trvRevisitTime.Nodes[0].Nodes.Count > 0)
			{
				for(int i=0; i<trvRevisitTime.Nodes[0].Nodes.Count; i++)
				{
					if(DateTime.Parse(trvRevisitTime.Nodes[0].Nodes[i].Text) == DateTime.Parse(objValue.m_StrRevisitTime))
					{
						m_blnIsSaveNew = false;
					}
				}
			}

			long lngRes = 0;
			if(m_blnIsSaveNew)
				lngRes = m_objDomain.m_lngAddRemindRecord(objValue);
			else
				lngRes = m_objDomain.m_lngModifyRemindRecord(objValue);
			if(lngRes > 0)
			{
				if(m_blnIsSaveNew)
				{
					trvRevisitTime.BeginUpdate();
					trvRevisitTime.Nodes[0].Nodes.Insert(0,trnNew);
					trvRevisitTime.EndUpdate();
				}
				MDIParent.ShowInformationMessageBox("保存成功！");
				trvRevisitTime.SelectedNode= trnNew;
			}
			else
				MDIParent.ShowInformationMessageBox("保存失败！");
		}

		private void m_cmdDelRevisitTime_Click(object sender, System.EventArgs e)
		{
			clsPatient objPatient = null;
			if(gpbSelectedInPat.Tag is clsPatient)
				objPatient = gpbSelectedInPat.Tag as clsPatient;
			else if(m_lsvInPatientList.SelectedItems.Count > 0)
			{
				objPatient = m_lsvInPatientList.SelectedItems[0].Tag as clsPatient;
			}
			if(objPatient == null)
				return;	

			long lngRes = m_objDomain.m_lngSetRemindRecordStatusMRecord(0,objPatient.m_StrInPatientID,objPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"),trvRevisitTime.SelectedNode.Text);

			if(lngRes > 0)
			{
				trvRevisitTime.Nodes.Remove(trvRevisitTime.SelectedNode);
				MDIParent.ShowInformationMessageBox("删除成功！");
			}
			else
				MDIParent.ShowInformationMessageBox("删除失败！");
		}

		private void ctlTimePicker_evtValueChanged(object sender, System.EventArgs e)
		{
			if(m_dtpSearchStartTime.Value < m_dtpSearchEndTime.Value)
			{
				if(m_rdbOutHospitalPatient.Checked)
					m_objDomain.m_mthDisplayPatient(m_dtpSearchStartTime.Value.ToString("yyyy-MM-dd 00:00:00"),m_dtpSearchEndTime.Value.ToString("yyyy-MM-dd 00:00:00"),false,true);
				else if(m_rdbInHospitalPatient.Checked)
					m_objDomain.m_mthDisplayPatient(m_dtpSearchStartTime.Value.ToString("yyyy-MM-dd 00:00:00"),m_dtpSearchEndTime.Value.ToString("yyyy-MM-dd 00:00:00"),false,false);
			}
			else
				m_mthClearAll();
		}

		private void m_cmdSearchByInPatientID_Click(object sender, System.EventArgs e)
		{
			if(m_txtInpatientID.Text.Trim() != "" && m_txtInpatientID.Enabled)
			{
				m_objDomain.m_mthDispalyPatientByInPatientID(m_txtInpatientID.Text.Trim(),false);
			}
			if (m_txtPatientName.Text.Trim() != "" && m_txtPatientName.Enabled)
			{
				m_objDomain.m_mthDispalyPatientByPatientName(m_txtPatientName.Text.Trim(),false);
			}
			if((m_txtInpatientID.Enabled && m_txtInpatientID.Text.Trim() == "") || (m_txtPatientName.Enabled && m_txtPatientName.Text.Trim() == ""))
			{
				MDIParent.ShowInformationMessageBox("请输入查询条件！");
			}
		}

		private void m_txtInpatientID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (byte)13)//回车
			{
				if(m_txtInpatientID.Text.Trim() != "")
				{
					m_objDomain.m_mthDispalyPatientByInPatientID(m_txtInpatientID.Text.Trim(),false);
				}
				else
				{
					MDIParent.ShowInformationMessageBox("请输入病人住院号！");
				}
			}
		}

		private void trvRevisitTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(trvRevisitTime.SelectedNode.Text.Length != 4)
			{
				clsPatient objPatient = gpbSelectedInPat.Tag as clsPatient;
				DateTime dtmRevisitTime = DateTime.Now;
				string strTips = "";
				try
				{
					dtmRevisitTime = DateTime.Parse(trvRevisitTime.SelectedNode.Text);
				}
				catch{}
				m_objDomain.m_lngGetRemindRecord(objPatient.m_StrInPatientID, objPatient.m_DtmLastInDate, dtmRevisitTime, out strTips);
				
				m_rdbConcretelyTime.Checked = true;
				m_dtpConcretelyTime.Value = dtmRevisitTime;
				if (strTips == string.Empty)
				{
					strTips = r_strTips;
					m_txtRemindTips.Text = strTips.Replace("<NAME>",objPatient.m_StrName).Replace("<INPATIENTID>",objPatient.m_StrInPatientID).Replace("<INPATIENTDATE>",objPatient.m_DtmLastOutDate.ToString("yyyy年MM月dd日")).Replace("<REVISITDATE>",trvRevisitTime.SelectedNode.Text);
				}
				else
					m_txtRemindTips.Text = strTips;
			}
		}
		
		private void m_rdbSearch_CheckedChanged(object sender, System.EventArgs e)
		{
			m_txtInpatientID.Enabled = m_rdbInPatientID.Checked;
			m_txtPatientName.Enabled = m_rdbPatientName.Checked;
		}

		private void m_txtPatientName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (byte)13)//回车
			{
				if(m_txtPatientName.Text.Trim() != "")
				{
					m_objDomain.m_mthDispalyPatientByPatientName(m_txtPatientName.Text.Trim(),false);
				}
				else
				{
					MDIParent.ShowInformationMessageBox("请输入病人姓名！");
				}
			}
		}

		private void m_rdbOutHospitalPatient_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_rdbOutHospitalPatient.Checked)
			{
				m_mthDisplayPatient();
			}
		}

		private void m_rdbInHospitalPatient_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_rdbInHospitalPatient.Checked)
			{
				m_mthDisplayPatient();
			}
		}
	}
}
