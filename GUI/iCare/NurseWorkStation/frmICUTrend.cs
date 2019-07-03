using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using com.digitalwave.Utility.ctlTrendViewer;


namespace iCare
{
	public class frmICUTrend : iCare.frmHRPBaseForm
	{
		#region Control Define
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblTitle11;
		private PinkieControls.ButtonXP cmdTrenData;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpEndTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpBeginTime;
		private System.Windows.Forms.Panel pnlTrend;
		private System.Windows.Forms.TabControl tabTrend;
		private System.Windows.Forms.TabPage tbpCharView;
		private PinkieControls.ButtonXP cmdForward;
		private System.Windows.Forms.Label label4;
		private PinkieControls.ButtonXP cmdBackward;
		public com.digitalwave.Utility.Controls.ctlBorderTextBox txtTimeOfMinute;
		private System.Windows.Forms.Panel pnlChart;
		private com.digitalwave.Utility.ctlTrendViewer.ctlTrendChart ctlTrendChart;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlTrendList;
		private com.digitalwave.Utility.ctlTrendViewer.ctlTrendList ctlTrendList;
		private System.Windows.Forms.ContextMenu ctmOption;
		private System.Windows.Forms.MenuItem mniDisplay;
		private System.Windows.Forms.MenuItem mniDisplay_Scatter;
		private System.Windows.Forms.MenuItem mniDisplay_Continuous;
		private System.Windows.Forms.MenuItem mniDisplay_Mixed;
		private System.Windows.Forms.MenuItem mniResolution;
		private System.Windows.Forms.MenuItem mniResolution_1Minute;
		private System.Windows.Forms.MenuItem mniResolution_5Minute;
		private System.Windows.Forms.MenuItem mniResolution_30Minute;
		private System.Windows.Forms.MenuItem mniResolution_1Hour;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mniSelectGroup;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Timer timRefresh;
		private System.Windows.Forms.NumericUpDown m_nmuTotal;
		private System.Windows.Forms.Label m_lblTotalUnit;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Constructor
		public frmICUTrend()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.m_nmuTotal});	
            
			m_objDomain = new clsTrendDomain();

			m_thrLoading = new Thread(new System.Threading.ThreadStart(m_mthLoading));

			m_objReset = new ManualResetEvent(false);

			m_thrLoading.Start();

			m_blnConnect = m_objReset.WaitOne(8000,false);

			m_objReset.Reset();

			if(!m_blnConnect)
			{
				MessageBox.Show("连接超时，应用程序无法连接DocVue服务器！", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
				m_thrLoading.Abort();
			}

			if(m_objVitalGroupArr != null && m_objVitalGroupArr.Length != 0)
			{
				if(m_objVitalGroupArr[0] != null)
				{
					m_objCurrentGroup = m_objVitalGroupArr[0];
				}

				if(m_objVitalSetArr != null && m_objVitalSetArr.Length != 0)
				{
					int[] intTempMFCArr = new int[m_objVitalSetArr.Length];
					int intIndex = 0;

					for(int i = 0; i < m_objVitalSetArr.Length; i ++)
					{
						if(m_objVitalSetArr[i] != null && m_objVitalSetArr[i].m_intGroupID == m_objCurrentGroup.m_intGroupID)
						{
							intTempMFCArr[intIndex++] = m_objVitalSetArr[i].m_intEMFC_ID;
						}
						else if(intIndex > 0)
						{
							break;
						}
					}

					m_intEMFC_IDArr = new int[intIndex];
					Array.Copy(intTempMFCArr,m_intEMFC_IDArr,intIndex);
					m_mthInitGroupSet();

					if(m_objGroupSetArr != null)
					{
						ctlTrendChart.m_mthShowParamDesc(m_objGroupSetArr);
						ctlTrendList.m_mthShowParamDesc(m_objGroupSetArr);
					}
				}
			}

			dtpBeginTime.Value = DateTime.Now.AddMinutes(-25);
			dtpEndTime.Value = DateTime.Now;

			ctlTrendChart.m_DtmStartDate = dtpBeginTime.Value;
			ctlTrendList.m_DtmStartDate = dtpBeginTime.Value;
		}
		#endregion

		#region Member
        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;

		private bool m_blnConnect = false;

		private Thread m_thrLoading;

		private ManualResetEvent m_objReset;
		/// <summary>
		/// 
		/// </summary>
		private clsTrendDomain m_objDomain;

		/// <summary>
		/// 
		/// </summary>
		private clsVitalGroup[] m_objVitalGroupArr;

		/// <summary>
		/// 
		/// </summary>
		private clsVitalSet[] m_objVitalSetArr;

		/// <summary>
		/// 当前的分组
		/// </summary>
		private clsVitalGroup m_objCurrentGroup;

		/// <summary>
		/// 
		/// </summary>
		private clsVitalGroupSet[] m_objGroupSetArr;

//		/// <summary>
//		/// 
//		/// </summary>
//		private clsPatDemo m_objPatDemo;
		#endregion

		#region Dispose
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label3 = new System.Windows.Forms.Label();
			this.lblTitle11 = new System.Windows.Forms.Label();
			this.cmdTrenData = new PinkieControls.ButtonXP();
			this.dtpEndTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.dtpBeginTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.pnlTrend = new System.Windows.Forms.Panel();
			this.tabTrend = new System.Windows.Forms.TabControl();
			this.tbpCharView = new System.Windows.Forms.TabPage();
			this.cmdForward = new PinkieControls.ButtonXP();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdBackward = new PinkieControls.ButtonXP();
			this.txtTimeOfMinute = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.pnlChart = new System.Windows.Forms.Panel();
			this.ctlTrendChart = new com.digitalwave.Utility.ctlTrendViewer.ctlTrendChart();
			this.ctmOption = new System.Windows.Forms.ContextMenu();
			this.mniDisplay = new System.Windows.Forms.MenuItem();
			this.mniDisplay_Scatter = new System.Windows.Forms.MenuItem();
			this.mniDisplay_Continuous = new System.Windows.Forms.MenuItem();
			this.mniDisplay_Mixed = new System.Windows.Forms.MenuItem();
			this.mniResolution = new System.Windows.Forms.MenuItem();
			this.mniResolution_1Minute = new System.Windows.Forms.MenuItem();
			this.mniResolution_5Minute = new System.Windows.Forms.MenuItem();
			this.mniResolution_30Minute = new System.Windows.Forms.MenuItem();
			this.mniResolution_1Hour = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mniSelectGroup = new System.Windows.Forms.MenuItem();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlTrendList = new System.Windows.Forms.Panel();
			this.ctlTrendList = new com.digitalwave.Utility.ctlTrendViewer.ctlTrendList();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.timRefresh = new System.Windows.Forms.Timer(this.components);
			this.m_nmuTotal = new System.Windows.Forms.NumericUpDown();
			this.m_lblTotalUnit = new System.Windows.Forms.Label();
			this.pnlTrend.SuspendLayout();
			this.tabTrend.SuspendLayout();
			this.tbpCharView.SuspendLayout();
			this.pnlChart.SuspendLayout();
			this.pnlTrendList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_nmuTotal)).BeginInit();
			this.SuspendLayout();
			// 
			// lblSex
			// 
			this.lblSex.Location = new System.Drawing.Point(512, 12);
			this.lblSex.Name = "lblSex";
			// 
			// lblAge
			// 
			this.lblAge.Location = new System.Drawing.Point(600, 12);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(36, 19);
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Location = new System.Drawing.Point(212, 12);
			this.lblBedNoTitle.Name = "lblBedNoTitle";
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Location = new System.Drawing.Point(200, 36);
			this.lblInHospitalNoTitle.Name = "lblInHospitalNoTitle";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Location = new System.Drawing.Point(348, 12);
			this.lblNameTitle.Name = "lblNameTitle";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Location = new System.Drawing.Point(468, 12);
			this.lblSexTitle.Name = "lblSexTitle";
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Location = new System.Drawing.Point(560, 12);
			this.lblAgeTitle.Name = "lblAgeTitle";
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Location = new System.Drawing.Point(8, 36);
			this.lblAreaTitle.Name = "lblAreaTitle";
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Location = new System.Drawing.Point(252, 56);
			this.m_lsvInPatientID.Name = "m_lsvInPatientID";
			this.m_lsvInPatientID.Size = new System.Drawing.Size(92, 104);
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Location = new System.Drawing.Point(252, 36);
			this.txtInPatientID.Name = "txtInPatientID";
			this.txtInPatientID.Size = new System.Drawing.Size(92, 21);
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Location = new System.Drawing.Point(388, 12);
			this.m_txtPatientName.Name = "m_txtPatientName";
			this.m_txtPatientName.Size = new System.Drawing.Size(80, 21);
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Location = new System.Drawing.Point(252, 12);
			this.m_txtBedNO.Name = "m_txtBedNO";
			this.m_txtBedNO.Size = new System.Drawing.Size(68, 21);
			// 
			// m_cboArea
			// 
			this.m_cboArea.Location = new System.Drawing.Point(52, 32);
			this.m_cboArea.Name = "m_cboArea";
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Location = new System.Drawing.Point(388, 36);
			this.m_lsvPatientName.Name = "m_lsvPatientName";
			this.m_lsvPatientName.Size = new System.Drawing.Size(80, 104);
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Location = new System.Drawing.Point(252, 36);
			this.m_lsvBedNO.Name = "m_lsvBedNO";
			this.m_lsvBedNO.Size = new System.Drawing.Size(88, 104);
			// 
			// m_cboDept
			// 
			this.m_cboDept.Location = new System.Drawing.Point(52, 8);
			this.m_cboDept.Name = "m_cboDept";
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(8, 12);
			this.lblDept.Name = "lblDept";
			// 
			// m_cmdNewTemplate
			// 
			this.m_cmdNewTemplate.Name = "m_cmdNewTemplate";
			// 
			// m_cmdNext
			// 
			this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.m_cmdNext.Location = new System.Drawing.Point(320, 12);
			this.m_cmdNext.Name = "m_cmdNext";
			this.m_cmdNext.Visible = true;
			// 
			// m_cmdPre
			// 
			this.m_cmdPre.Name = "m_cmdPre";
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Location = new System.Drawing.Point(308, 4);
			this.m_lblForTitle.Name = "m_lblForTitle";
			this.m_lblForTitle.Size = new System.Drawing.Size(416, 8);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(268, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 19);
			this.label3.TabIndex = 503;
			this.label3.Text = "共";
			// 
			// lblTitle11
			// 
			this.lblTitle11.AutoSize = true;
			this.lblTitle11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitle11.ForeColor = System.Drawing.Color.Black;
			this.lblTitle11.Location = new System.Drawing.Point(12, 72);
			this.lblTitle11.Name = "lblTitle11";
			this.lblTitle11.Size = new System.Drawing.Size(77, 19);
			this.lblTitle11.TabIndex = 502;
			this.lblTitle11.Text = "查询时间：";
			// 
			// cmdTrenData
			// 
			this.cmdTrenData.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdTrenData.DefaultScheme = true;
			this.cmdTrenData.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdTrenData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdTrenData.ForeColor = System.Drawing.Color.Black;
			this.cmdTrenData.Hint = "";
			this.cmdTrenData.Location = new System.Drawing.Point(380, 68);
			this.cmdTrenData.Name = "cmdTrenData";
			this.cmdTrenData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdTrenData.Size = new System.Drawing.Size(64, 28);
			this.cmdTrenData.TabIndex = 501;
			this.cmdTrenData.Text = "查询";
			this.cmdTrenData.Click += new System.EventHandler(this.cmdTrenData_Click);
			// 
			// dtpEndTime
			// 
			this.dtpEndTime.BorderColor = System.Drawing.Color.White;
			this.dtpEndTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.dtpEndTime.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.dtpEndTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.dtpEndTime.DropButtonForeColor = System.Drawing.Color.White;
			this.dtpEndTime.flatFont = new System.Drawing.Font("宋体", 12F);
			this.dtpEndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndTime.Location = new System.Drawing.Point(484, 8);
			this.dtpEndTime.m_BlnOnlyTime = false;
			this.dtpEndTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.dtpEndTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dtpEndTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dtpEndTime.Name = "dtpEndTime";
			this.dtpEndTime.ReadOnly = false;
			this.dtpEndTime.Size = new System.Drawing.Size(188, 22);
			this.dtpEndTime.TabIndex = 500;
			this.dtpEndTime.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.dtpEndTime.TextForeColor = System.Drawing.Color.White;
			this.dtpEndTime.Visible = false;
			this.dtpEndTime.evtValueChanged += new System.EventHandler(this.dtpEndTime_evtValueChanged);
			// 
			// dtpBeginTime
			// 
			this.dtpBeginTime.BackColor = System.Drawing.Color.White;
			this.dtpBeginTime.BorderColor = System.Drawing.Color.Black;
			this.dtpBeginTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.dtpBeginTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
			this.dtpBeginTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.dtpBeginTime.DropButtonForeColor = System.Drawing.Color.Black;
			this.dtpBeginTime.flatFont = new System.Drawing.Font("宋体", 12F);
			this.dtpBeginTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpBeginTime.ForeColor = System.Drawing.Color.Black;
			this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpBeginTime.Location = new System.Drawing.Point(80, 68);
			this.dtpBeginTime.m_BlnOnlyTime = false;
			this.dtpBeginTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.dtpBeginTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dtpBeginTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dtpBeginTime.Name = "dtpBeginTime";
			this.dtpBeginTime.ReadOnly = false;
			this.dtpBeginTime.Size = new System.Drawing.Size(188, 22);
			this.dtpBeginTime.TabIndex = 499;
			this.dtpBeginTime.TextBackColor = System.Drawing.Color.White;
			this.dtpBeginTime.TextForeColor = System.Drawing.Color.Black;
			this.dtpBeginTime.evtValueChanged += new System.EventHandler(this.dtpBeginTime_evtValueChanged);
			// 
			// pnlTrend
			// 
			this.pnlTrend.Controls.Add(this.tabTrend);
			this.pnlTrend.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlTrend.Location = new System.Drawing.Point(0, 101);
			this.pnlTrend.Name = "pnlTrend";
			this.pnlTrend.Size = new System.Drawing.Size(792, 572);
			this.pnlTrend.TabIndex = 504;
			// 
			// tabTrend
			// 
			this.tabTrend.Controls.Add(this.tbpCharView);
			this.tabTrend.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabTrend.Location = new System.Drawing.Point(0, 0);
			this.tabTrend.Name = "tabTrend";
			this.tabTrend.SelectedIndex = 0;
			this.tabTrend.Size = new System.Drawing.Size(792, 572);
			this.tabTrend.TabIndex = 0;
			// 
			// tbpCharView
			// 
			this.tbpCharView.BackColor = System.Drawing.SystemColors.Control;
			this.tbpCharView.Controls.Add(this.cmdForward);
			this.tbpCharView.Controls.Add(this.label4);
			this.tbpCharView.Controls.Add(this.cmdBackward);
			this.tbpCharView.Controls.Add(this.txtTimeOfMinute);
			this.tbpCharView.Controls.Add(this.pnlChart);
			this.tbpCharView.Controls.Add(this.splitter1);
			this.tbpCharView.Controls.Add(this.pnlTrendList);
			this.tbpCharView.ForeColor = System.Drawing.Color.White;
			this.tbpCharView.Location = new System.Drawing.Point(4, 23);
			this.tbpCharView.Name = "tbpCharView";
			this.tbpCharView.Size = new System.Drawing.Size(784, 545);
			this.tbpCharView.TabIndex = 0;
			this.tbpCharView.Text = "趋势图";
			// 
			// cmdForward
			// 
			this.cmdForward.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdForward.DefaultScheme = true;
			this.cmdForward.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdForward.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmdForward.ForeColor = System.Drawing.Color.Black;
			this.cmdForward.Hint = "";
			this.cmdForward.Location = new System.Drawing.Point(576, 492);
			this.cmdForward.Name = "cmdForward";
			this.cmdForward.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdForward.Size = new System.Drawing.Size(32, 23);
			this.cmdForward.TabIndex = 419;
			this.cmdForward.Text = ">>";
			this.cmdForward.Click += new System.EventHandler(this.cmdForward_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(540, 496);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 19);
			this.label4.TabIndex = 421;
			this.label4.Text = "分钟";
			// 
			// cmdBackward
			// 
			this.cmdBackward.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdBackward.DefaultScheme = true;
			this.cmdBackward.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdBackward.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmdBackward.ForeColor = System.Drawing.Color.Black;
			this.cmdBackward.Hint = "";
			this.cmdBackward.Location = new System.Drawing.Point(440, 492);
			this.cmdBackward.Name = "cmdBackward";
			this.cmdBackward.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdBackward.Size = new System.Drawing.Size(32, 23);
			this.cmdBackward.TabIndex = 420;
			this.cmdBackward.Text = "<<";
			this.cmdBackward.Click += new System.EventHandler(this.cmdBackward_Click);
			// 
			// txtTimeOfMinute
			// 
			this.txtTimeOfMinute.AutoSize = false;
			this.txtTimeOfMinute.BackColor = System.Drawing.Color.White;
			this.txtTimeOfMinute.BorderColor = System.Drawing.Color.Transparent;
			this.txtTimeOfMinute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTimeOfMinute.ForeColor = System.Drawing.Color.Black;
			this.txtTimeOfMinute.Location = new System.Drawing.Point(472, 492);
			this.txtTimeOfMinute.MaxLength = 7;
			this.txtTimeOfMinute.Name = "txtTimeOfMinute";
			this.txtTimeOfMinute.Size = new System.Drawing.Size(68, 21);
			this.txtTimeOfMinute.TabIndex = 418;
			this.txtTimeOfMinute.Text = "5";
			this.txtTimeOfMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// pnlChart
			// 
			this.pnlChart.Controls.Add(this.ctlTrendChart);
			this.pnlChart.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlChart.Location = new System.Drawing.Point(0, 176);
			this.pnlChart.Name = "pnlChart";
			this.pnlChart.Size = new System.Drawing.Size(784, 312);
			this.pnlChart.TabIndex = 2;
			// 
			// ctlTrendChart
			// 
			this.ctlTrendChart.BackColor = System.Drawing.Color.Lavender;
			this.ctlTrendChart.ContextMenu = this.ctmOption;
			this.ctlTrendChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlTrendChart.ForeColor = System.Drawing.Color.Black;
			this.ctlTrendChart.Location = new System.Drawing.Point(0, 0);
			this.ctlTrendChart.m_BlnShowAlarm = true;
			this.ctlTrendChart.m_ClrChartBackColor = System.Drawing.Color.White;
			this.ctlTrendChart.m_ClrChartColor = System.Drawing.Color.SaddleBrown;
			this.ctlTrendChart.m_ClrDateColor = System.Drawing.Color.Navy;
			this.ctlTrendChart.m_DtmStartDate = new System.DateTime(2003, 5, 10, 15, 30, 0, 0);
			this.ctlTrendChart.m_EnmDisplay = com.digitalwave.Utility.ctlTrendViewer.enmDisplay.Mixed;
			this.ctlTrendChart.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.Five_Minute;
			this.ctlTrendChart.m_IntTotalTime = 25;
			this.ctlTrendChart.Name = "ctlTrendChart";
			this.ctlTrendChart.Size = new System.Drawing.Size(784, 312);
			this.ctlTrendChart.TabIndex = 0;
			// 
			// ctmOption
			// 
			this.ctmOption.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mniDisplay,
																					  this.mniResolution,
																					  this.menuItem1,
																					  this.mniSelectGroup});
			this.ctmOption.Popup += new System.EventHandler(this.ctmOption_Popup);
			// 
			// mniDisplay
			// 
			this.mniDisplay.Index = 0;
			this.mniDisplay.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mniDisplay_Scatter,
																					   this.mniDisplay_Continuous,
																					   this.mniDisplay_Mixed});
			this.mniDisplay.Text = "显   示";
			// 
			// mniDisplay_Scatter
			// 
			this.mniDisplay_Scatter.Index = 0;
			this.mniDisplay_Scatter.Text = "离  散";
			this.mniDisplay_Scatter.Click += new System.EventHandler(this.mniDisplay_Scatter_Click);
			// 
			// mniDisplay_Continuous
			// 
			this.mniDisplay_Continuous.Index = 1;
			this.mniDisplay_Continuous.Text = "连  续";
			this.mniDisplay_Continuous.Click += new System.EventHandler(this.mniDisplay_Continuous_Click);
			// 
			// mniDisplay_Mixed
			// 
			this.mniDisplay_Mixed.Checked = true;
			this.mniDisplay_Mixed.Index = 2;
			this.mniDisplay_Mixed.Text = "混  合";
			this.mniDisplay_Mixed.Click += new System.EventHandler(this.mniDisplay_Mixed_Click);
			// 
			// mniResolution
			// 
			this.mniResolution.Index = 1;
			this.mniResolution.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.mniResolution_1Minute,
																						  this.mniResolution_5Minute,
																						  this.mniResolution_30Minute,
																						  this.mniResolution_1Hour});
			this.mniResolution.Text = "分辨率";
			// 
			// mniResolution_1Minute
			// 
			this.mniResolution_1Minute.Index = 0;
			this.mniResolution_1Minute.Text = "1   分钟";
			this.mniResolution_1Minute.Click += new System.EventHandler(this.mniResolution_1Minute_Click);
			// 
			// mniResolution_5Minute
			// 
			this.mniResolution_5Minute.Checked = true;
			this.mniResolution_5Minute.Index = 1;
			this.mniResolution_5Minute.Text = "5   分钟";
			this.mniResolution_5Minute.Click += new System.EventHandler(this.mniResolution_5Minute_Click);
			// 
			// mniResolution_30Minute
			// 
			this.mniResolution_30Minute.Index = 2;
			this.mniResolution_30Minute.Text = "30 分钟";
			this.mniResolution_30Minute.Click += new System.EventHandler(this.mniResolution_30Minute_Click);
			// 
			// mniResolution_1Hour
			// 
			this.mniResolution_1Hour.Index = 3;
			this.mniResolution_1Hour.Text = "1   小时";
			this.mniResolution_1Hour.Click += new System.EventHandler(this.mniResolution_1Hour_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 2;
			this.menuItem1.Text = "-";
			// 
			// mniSelectGroup
			// 
			this.mniSelectGroup.Index = 3;
			this.mniSelectGroup.Text = "选择分组...";
			this.mniSelectGroup.Click += new System.EventHandler(this.mniSelectGroup_Click);
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.Gainsboro;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Enabled = false;
			this.splitter1.Location = new System.Drawing.Point(0, 168);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(784, 8);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// pnlTrendList
			// 
			this.pnlTrendList.Controls.Add(this.ctlTrendList);
			this.pnlTrendList.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTrendList.Location = new System.Drawing.Point(0, 0);
			this.pnlTrendList.Name = "pnlTrendList";
			this.pnlTrendList.Size = new System.Drawing.Size(784, 168);
			this.pnlTrendList.TabIndex = 0;
			// 
			// ctlTrendList
			// 
			this.ctlTrendList.BackColor = System.Drawing.Color.Lavender;
			this.ctlTrendList.ContextMenu = this.ctmOption;
			this.ctlTrendList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlTrendList.ForeColor = System.Drawing.Color.Black;
			this.ctlTrendList.Location = new System.Drawing.Point(0, 0);
			this.ctlTrendList.m_ClrListBackColor = System.Drawing.Color.White;
			this.ctlTrendList.m_DtmStartDate = new System.DateTime(2003, 5, 10, 15, 30, 0, 0);
			this.ctlTrendList.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.Five_Minute;
			this.ctlTrendList.m_IntTotalTime = 25;
			this.ctlTrendList.Name = "ctlTrendList";
			this.ctlTrendList.Size = new System.Drawing.Size(784, 168);
			this.ctlTrendList.TabIndex = 0;
			// 
			// timRefresh
			// 
			this.timRefresh.Tick += new System.EventHandler(this.timRefresh_Tick);
			// 
			// m_nmuTotal
			// 
			this.m_nmuTotal.BackColor = System.Drawing.Color.White;
			this.m_nmuTotal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_nmuTotal.ForeColor = System.Drawing.Color.Black;
			this.m_nmuTotal.Location = new System.Drawing.Point(288, 68);
			this.m_nmuTotal.Maximum = new System.Decimal(new int[] {
																	   10000,
																	   0,
																	   0,
																	   0});
			this.m_nmuTotal.Name = "m_nmuTotal";
			this.m_nmuTotal.Size = new System.Drawing.Size(56, 23);
			this.m_nmuTotal.TabIndex = 500;
			this.m_nmuTotal.Value = new System.Decimal(new int[] {
																	 25,
																	 0,
																	 0,
																	 0});
			this.m_nmuTotal.TextChanged += new System.EventHandler(this.m_nmuTotal_ValueChanged);
			// 
			// m_lblTotalUnit
			// 
			this.m_lblTotalUnit.AutoSize = true;
			this.m_lblTotalUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblTotalUnit.ForeColor = System.Drawing.Color.Black;
			this.m_lblTotalUnit.Location = new System.Drawing.Point(344, 72);
			this.m_lblTotalUnit.Name = "m_lblTotalUnit";
			this.m_lblTotalUnit.Size = new System.Drawing.Size(34, 19);
			this.m_lblTotalUnit.TabIndex = 503;
			this.m_lblTotalUnit.Text = "分钟";
			// 
			// frmICUTrend
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.AutoScroll = false;
			this.ClientSize = new System.Drawing.Size(792, 673);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtpEndTime);
			this.Controls.Add(this.m_nmuTotal);
			this.Controls.Add(this.cmdTrenData);
			this.Controls.Add(this.dtpBeginTime);
			this.Controls.Add(this.pnlTrend);
			this.Controls.Add(this.lblTitle11);
			this.Controls.Add(this.m_lblTotalUnit);
			this.Name = "frmICUTrend";
			this.Text = "趋势分析";
			this.Controls.SetChildIndex(this.m_lblTotalUnit, 0);
			this.Controls.SetChildIndex(this.lblTitle11, 0);
			this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
			this.Controls.SetChildIndex(this.pnlTrend, 0);
			this.Controls.SetChildIndex(this.dtpBeginTime, 0);
			this.Controls.SetChildIndex(this.cmdTrenData, 0);
			this.Controls.SetChildIndex(this.m_nmuTotal, 0);
			this.Controls.SetChildIndex(this.dtpEndTime, 0);
			this.Controls.SetChildIndex(this.m_lblForTitle, 0);
			this.Controls.SetChildIndex(this.txtInPatientID, 0);
			this.Controls.SetChildIndex(this.lblAreaTitle, 0);
			this.Controls.SetChildIndex(this.lblAgeTitle, 0);
			this.Controls.SetChildIndex(this.lblSexTitle, 0);
			this.Controls.SetChildIndex(this.lblNameTitle, 0);
			this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
			this.Controls.SetChildIndex(this.lblAge, 0);
			this.Controls.SetChildIndex(this.lblSex, 0);
			this.Controls.SetChildIndex(this.m_txtPatientName, 0);
			this.Controls.SetChildIndex(this.m_txtBedNO, 0);
			this.Controls.SetChildIndex(this.m_cboArea, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
			this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
			this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
			this.Controls.SetChildIndex(this.lblDept, 0);
			this.Controls.SetChildIndex(this.m_cboDept, 0);
			this.Controls.SetChildIndex(this.m_cmdNext, 0);
			this.Controls.SetChildIndex(this.m_cmdPre, 0);
			this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
			this.pnlTrend.ResumeLayout(false);
			this.tabTrend.ResumeLayout(false);
			this.tbpCharView.ResumeLayout(false);
			this.pnlChart.ResumeLayout(false);
			this.pnlTrendList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_nmuTotal)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region 右键菜单
		/// <summary>
		/// 动态显示右键菜单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ctmOption_Popup(object sender, System.EventArgs e)
		{
			if(ctmOption.SourceControl.GetType() == typeof(com.digitalwave.Utility.ctlTrendViewer.ctlTrendList))
			{
				mniDisplay.Visible = false;
			}
			else if(ctmOption.SourceControl.GetType() == typeof(com.digitalwave.Utility.ctlTrendViewer.ctlTrendChart))
			{
				mniDisplay.Visible = true;
			}
			else
			{
				return;
			}
		}

		/// <summary>
		/// 初始化显示右键菜单 -- 只对图表起作用
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniDisplay_Popup(object sender, System.EventArgs e)
		{
			switch(ctlTrendChart.m_EnmDisplay)
			{
				case com.digitalwave.Utility.ctlTrendViewer.enmDisplay.Scatter:
					mniDisplay_Scatter.Checked = true;
					mniDisplay_Continuous.Checked = false;
					mniDisplay_Mixed.Checked = false;
					break;

				case com.digitalwave.Utility.ctlTrendViewer.enmDisplay.Continues:
					mniDisplay_Scatter.Checked = false;
					mniDisplay_Continuous.Checked = true;
					mniDisplay_Mixed.Checked = false;
					break;

				case com.digitalwave.Utility.ctlTrendViewer.enmDisplay.Mixed:
					mniDisplay_Scatter.Checked = false;
					mniDisplay_Continuous.Checked = false;
					mniDisplay_Mixed.Checked = true;
					break;
			}
		}

		/// <summary>
		/// 初始化分辨率右键菜单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniResolution_Popup(object sender, System.EventArgs e)
		{
			switch(ctlTrendChart.m_EnmResolution)
			{
				case com.digitalwave.Utility.ctlTrendViewer.enmResolution.One_Minute:
					mniResolution_1Minute.Checked = true;
					mniResolution_5Minute.Checked = false;
					mniResolution_30Minute.Checked = false;
					mniResolution_1Hour.Checked = false;
					break;

				case com.digitalwave.Utility.ctlTrendViewer.enmResolution.Five_Minute:
					mniResolution_1Minute.Checked = false;
					mniResolution_5Minute.Checked = true;
					mniResolution_30Minute.Checked = false;
					mniResolution_1Hour.Checked = false;
					break;

				case com.digitalwave.Utility.ctlTrendViewer.enmResolution.Thirty_Minute:
					mniResolution_1Minute.Checked = false;
					mniResolution_5Minute.Checked = false;
					mniResolution_30Minute.Checked = true;
					mniResolution_1Hour.Checked = false;
					break;

				case com.digitalwave.Utility.ctlTrendViewer.enmResolution.One_Hour:
					mniResolution_1Minute.Checked = false;
					mniResolution_5Minute.Checked = false;
					mniResolution_30Minute.Checked = false;
					mniResolution_1Hour.Checked = true;
					break;
			}
		}

		private void mniDisplay_Scatter_Click(object sender, System.EventArgs e)
		{
			mniDisplay_Scatter.Checked = true;
			mniDisplay_Continuous.Checked = false;
			mniDisplay_Mixed.Checked = false;

			ctlTrendChart.m_EnmDisplay = com.digitalwave.Utility.ctlTrendViewer.enmDisplay.Scatter;
		}

		private void mniDisplay_Continuous_Click(object sender, System.EventArgs e)
		{
			mniDisplay_Scatter.Checked = false;
			mniDisplay_Continuous.Checked = true;
			mniDisplay_Mixed.Checked = false;

			ctlTrendChart.m_EnmDisplay = com.digitalwave.Utility.ctlTrendViewer.enmDisplay.Continues;
		}

		private void mniDisplay_Mixed_Click(object sender, System.EventArgs e)
		{
			mniDisplay_Scatter.Checked = false;
			mniDisplay_Continuous.Checked = false;
			mniDisplay_Mixed.Checked = true;

			ctlTrendChart.m_EnmDisplay = com.digitalwave.Utility.ctlTrendViewer.enmDisplay.Mixed;
		}

		private void mniResolution_1Minute_Click(object sender, System.EventArgs e)
		{
			mniResolution_1Minute.Checked = true;
			mniResolution_5Minute.Checked = false;
			mniResolution_30Minute.Checked = false;
			mniResolution_1Hour.Checked = false;

			ctlTrendChart.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.One_Minute;
			ctlTrendList.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.One_Minute;

			m_nmuTotal.Value = 1*5;

			cmdTrenData_Click(null, null);
		}

		private void mniResolution_5Minute_Click(object sender, System.EventArgs e)
		{
			mniResolution_1Minute.Checked = false;
			mniResolution_5Minute.Checked = true;
			mniResolution_30Minute.Checked = false;
			mniResolution_1Hour.Checked = false;

			ctlTrendChart.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.Five_Minute;
			ctlTrendList.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.Five_Minute;

			m_nmuTotal.Value = 5*5;

			cmdTrenData_Click(null, null);
		}

		private void mniResolution_30Minute_Click(object sender, System.EventArgs e)
		{
			mniResolution_1Minute.Checked = false;
			mniResolution_5Minute.Checked = false;
			mniResolution_30Minute.Checked = true;
			mniResolution_1Hour.Checked = false;

			ctlTrendChart.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.Thirty_Minute;
			ctlTrendList.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.Thirty_Minute;

			m_nmuTotal.Value = 30*5;

			cmdTrenData_Click(null, null);
		}

		private void mniResolution_1Hour_Click(object sender, System.EventArgs e)
		{
			mniResolution_1Minute.Checked = false;
			mniResolution_5Minute.Checked = false;
			mniResolution_30Minute.Checked = false;
			mniResolution_1Hour.Checked = true;

			ctlTrendChart.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.One_Hour;
			ctlTrendList.m_EnmResolution = com.digitalwave.Utility.ctlTrendViewer.enmResolution.One_Hour;

			m_nmuTotal.Value = 60*5;

			cmdTrenData_Click(null, null);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniSelectGroup_Click(object sender, System.EventArgs e)
		{
			frmVitalGroup frmvitalgroup = new frmVitalGroup();

			frmvitalgroup.m_ObjVitalGroupArr = m_objVitalGroupArr;

			frmvitalgroup.m_ObjVitalSetArr = m_objVitalSetArr;

			frmvitalgroup.m_mthSetSelectedGroup(m_objCurrentGroup.m_intGroupID);
			frmvitalgroup.m_mthSetSelectedEMFC(m_intEMFC_IDArr);

			frmvitalgroup.m_ObjParent = this;

			frmvitalgroup.m_IntRefreshRate = m_intRefreshRate;

			frmvitalgroup.m_BlnAutoRefresh = m_blnAutoRefresh;
			
			frmvitalgroup.ShowDialog(this);

			cmdTrenData_Click(null, null);
		}
		#endregion

		#region Properties
		/// <summary>
		/// 刷新速率
		/// </summary>
		private int m_intRefreshRate = 5;

		/// <summary>
		/// 刷新速率
		/// </summary>
		public int m_IntRefreshRate
		{
			get
			{
				return m_intRefreshRate;
			}
			set 
			{
				m_intRefreshRate = value;
			}
		}

		/// <summary>
		/// 是否自动刷新
		/// </summary>
		private bool m_blnAutoRefresh = false;

		/// <summary>
		/// 是否自动刷新
		/// </summary>
		public bool m_BlnAutoRefresh
		{
			get
			{
				return m_blnAutoRefresh;
			}
			set
			{
				m_blnAutoRefresh = value;

				if(m_blnAutoRefresh)
				{
					timRefresh.Interval = m_intRefreshRate * 60 * 1000;
					timRefresh.Start();
				}
				else
				{
					timRefresh.Stop();
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public clsVitalSet[] m_ObjVitalSetArr
		{
			get
			{
				return m_objVitalSetArr;
			}
			set 
			{
				m_objVitalSetArr = value;
			}
		}

		public int m_IntCurrentGroupID
		{
			get
			{
				return m_objCurrentGroup.m_intGroupID;
			}
			set
			{
				for(int i=0;i<m_objVitalGroupArr.Length;i++)
				{
					if(m_objVitalGroupArr[i].m_intGroupID == value)
					{
						m_objCurrentGroup = m_objVitalGroupArr[i];
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private int[] m_intEMFC_IDArr;

		/// <summary>
		/// 
		/// </summary>
		public int[] m_IntEMFC_IDArr
		{
			get
			{
				return m_intEMFC_IDArr;
			}
			set
			{
				m_intEMFC_IDArr = value;

				m_mthInitGroupSet();

				if(m_objGroupSetArr != null)
				{
					ctlTrendChart.m_mthShowParamDesc(m_objGroupSetArr);
					ctlTrendList.m_mthShowParamDesc(m_objGroupSetArr);
				}
			}
		}

		
		#endregion

		#region Private Function
		/// <summary>
		/// 
		/// </summary>
		private void m_mthInitGroupSet()
		{
			if(m_intEMFC_IDArr != null && m_intEMFC_IDArr.Length != 0)
			{
				clsVitalGroupSet[] objGroupSetArr = new clsVitalGroupSet[m_intEMFC_IDArr.Length];

				int intIndex = 0;
				//查找当前Group开始的参数集点
				for(;intIndex<m_objVitalSetArr.Length;intIndex++)
				{
					if(m_objVitalSetArr[intIndex].m_intGroupID == m_objCurrentGroup.m_intGroupID)
						break;
				}

				for(int i1=0;i1<objGroupSetArr.Length;i1++)
				{
					objGroupSetArr[i1] = new clsVitalGroupSet();

					for(int j2=intIndex;j2<m_objVitalSetArr.Length;j2++)
					{
						if(m_objVitalSetArr[j2].m_intEMFC_ID == m_intEMFC_IDArr[i1])
						{
							objGroupSetArr[i1].m_intEMFCID  = m_objVitalSetArr[j2].m_intEMFC_ID;
							objGroupSetArr[i1].m_intScaleNumber = m_objVitalSetArr[j2].m_intScaleNumber;
							objGroupSetArr[i1].m_intUnitID = m_objVitalSetArr[j2].m_intUnitID;
							objGroupSetArr[i1].m_strUnitDesc = m_objVitalSetArr[j2].m_strUnit;
							objGroupSetArr[i1].m_strParamLabel = m_objVitalSetArr[j2].m_strParameter;
							objGroupSetArr[i1].m_strParamLabelDesc = m_objVitalSetArr[j2].m_strDescription;
							objGroupSetArr[i1].m_clrColor = m_objVitalSetArr[j2].m_clrParamColor;
							objGroupSetArr[i1].m_intMarkerIndex = m_objVitalSetArr[j2].m_intMarkerIndex;							

							objGroupSetArr[i1].m_intGroupID = m_objCurrentGroup.m_intGroupID;
							objGroupSetArr[i1].m_intMaxScale0 = m_objCurrentGroup.m_intMaxScale0;
							objGroupSetArr[i1].m_intMinScale0 = m_objCurrentGroup.m_intMinScale0;
							objGroupSetArr[i1].m_intMaxScale1 = m_objCurrentGroup.m_intMaxScale1;
							objGroupSetArr[i1].m_intMinScale1 = m_objCurrentGroup.m_intMinScale1;
							objGroupSetArr[i1].m_intMaxScale2 = m_objCurrentGroup.m_intMaxScale2;
							objGroupSetArr[i1].m_intMinScale2 = m_objCurrentGroup.m_intMinScale2;
							objGroupSetArr[i1].m_strGroupName = m_objCurrentGroup.m_strGroupName;

							break;
						}
						else if(m_objVitalSetArr[j2].m_intGroupID != m_objCurrentGroup.m_intGroupID)
						{
							break;
						}

					}
				}

				m_objGroupSetArr =  objGroupSetArr;
			}//end if
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dtpBeginTime_evtValueChanged(object sender, System.EventArgs e)
		{
//			//改变开始时间，总时间
//			TimeSpan tmsDiff = dtpEndTime.Value - dtpBeginTime.Value;
//
//			ctlTrendChart.m_DtmStartDate = dtpBeginTime.Value;
//			ctlTrendList.m_DtmStartDate = dtpBeginTime.Value;
//
//			if(tmsDiff.TotalMinutes > 0)
//			{
//				ctlTrendChart.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
//				ctlTrendList.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
//			}
			dtpEndTime.Value = dtpBeginTime.Value.AddMinutes(Decimal.ToDouble(m_nmuTotal.Value));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dtpEndTime_evtValueChanged(object sender, System.EventArgs e)
		{
//			//改变总时间
//			TimeSpan tmsDiff = dtpEndTime.Value - dtpBeginTime.Value;
//
//			if(tmsDiff.TotalMinutes > 0)
//			{
//				ctlTrendChart.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
//				ctlTrendList.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
//			}
		}

		private void cmdForward_Click(object sender, System.EventArgs e)
		{
			int intTimeOfMinute = 0;
			try
			{
				intTimeOfMinute = int.Parse(txtTimeOfMinute.Text.Trim());
			}
			catch
			{
				intTimeOfMinute = 0;
			}

			if(intTimeOfMinute == 0)
				return;

			//改变DateTimePicker 的值
			dtpBeginTime.Value = dtpBeginTime.Value.AddMinutes((double)intTimeOfMinute);
//			dtpEndTime.Value = dtpEndTime.Value.AddMinutes((double)intTimeOfMinute);

			TimeSpan tmsDiff = dtpEndTime.Value - dtpBeginTime.Value;

			ctlTrendChart.m_DtmStartDate = dtpBeginTime.Value;
			ctlTrendList.m_DtmStartDate = dtpBeginTime.Value;

			if(tmsDiff.TotalMinutes > 0)
			{
				ctlTrendChart.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
				ctlTrendList.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
			}

			cmdTrenData_Click(null, null);
		}

		private void cmdBackward_Click(object sender, System.EventArgs e)
		{
			int intTimeOfMinute = 0;
			try
			{
				intTimeOfMinute = int.Parse(txtTimeOfMinute.Text.Trim());
			}
			catch
			{
				intTimeOfMinute = 0;
			}

			if(intTimeOfMinute == 0)
				return;

			//改变DateTimePicker 的值
			dtpBeginTime.Value = dtpBeginTime.Value.AddMinutes((double)intTimeOfMinute * (-1));			
//			dtpEndTime.Value = dtpEndTime.Value.AddMinutes((double)intTimeOfMinute * (-1));

			TimeSpan tmsDiff = dtpEndTime.Value - dtpBeginTime.Value;

			ctlTrendChart.m_DtmStartDate = dtpBeginTime.Value;
			ctlTrendList.m_DtmStartDate = dtpBeginTime.Value;

			if(tmsDiff.TotalMinutes > 0)
			{
				ctlTrendChart.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
				ctlTrendList.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
			}

			cmdTrenData_Click(null, null);
		}

		private void cmdForward_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			toolTip.ShowAlways = true;
			toolTip.SetToolTip(cmdForward, "前进");
		}

		private void cmdBackward_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			toolTip.ShowAlways = true;
			toolTip.SetToolTip(cmdBackward, "后退");
		}

		private void cmdTrenData_Click(object sender, System.EventArgs e)
		{
			//改变开始时间，总时间
			TimeSpan tmsDiff = dtpEndTime.Value - dtpBeginTime.Value;

			ctlTrendChart.m_DtmStartDate = dtpBeginTime.Value;
			ctlTrendList.m_DtmStartDate = dtpBeginTime.Value;

			if(tmsDiff.TotalMinutes > 0)
			{
				ctlTrendChart.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
				ctlTrendList.m_IntTotalTime = (int)tmsDiff.TotalMinutes;
			}

//			if(m_objPatDemo == null)
//			{
//				//				MessageBox.Show("select patient please!");
//				return;
//			}

			if(m_objGroupSetArr == null || m_objGroupSetArr.Length == 0)
			{
				//				MessageBox.Show("select group please!");
				return;
			}

			m_mthChangeTrendDate();

			ctlTrendChart.m_mthShowParamValue(m_objTrendValueArr);
			ctlTrendList.m_mthShowParamValue(m_objTrendValueArr);
		}

		/// <summary>
		/// 
		/// </summary>
		private clsTrendValue[] m_objTrendValueArr ;

		private void m_mthChangeTrendDate()
		{
			if(m_objBaseCurrentPatient == null)
				return;

			//清空数据
			m_objTrendValueArr = null;

			clsTrendData[] objTrendDataArr;
//			long lngRes = m_objDomain.m_lngGetTrendData(m_objPatDemo.m_intCaseID, dtpBeginTime.Value,dtpEndTime.Value,m_intEMFC_IDArr, out objTrendDataArr);
			//alex 2003-8-12
			long lngRes = m_objDomain.m_lngGetTrendData(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmLastInDate, dtpBeginTime.Value,dtpEndTime.Value,m_intEMFC_IDArr, out objTrendDataArr);
			if(lngRes <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("不能获取趋势数据。");
				return;
			}

			if(objTrendDataArr!= null && objTrendDataArr.Length != 0)
			{
				m_objTrendValueArr = new clsTrendValue[objTrendDataArr.Length];

				for(int i = 0; i < objTrendDataArr.Length; i++)
				{
					m_objTrendValueArr[i] = new clsTrendValue();

					m_objTrendValueArr[i].m_intEMFCID = objTrendDataArr[i].m_intEFMC_ID;
					m_objTrendValueArr[i].m_fltValue = objTrendDataArr[i].m_fltResult;
					m_objTrendValueArr[i].m_dtmStoreDate = objTrendDataArr[i].m_dtmStoreDate;
				}
			}//end if
		}


		private void m_mthLoading()
		{
			try
			{
				//加载参数分组信息
				m_objDomain.m_lngGetVitalGroup(out m_objVitalGroupArr);
				m_objDomain.m_lngGetVitalSet(out m_objVitalSetArr);
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}

			m_objReset.Set();
		}
		#endregion

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
			ctlTrendChart.m_mthClearParam();
			ctlTrendList.m_mthClearParam();

			cmdTrenData_Click(null,null);			
		}

//		protected override void m_mthSetPatientBaseInfo(iCare.clsPatient p_objSelectedPatient)
//		{
//			base.m_mthSetPatientBaseInfo(p_objSelectedPatient);
//
//			
////			m_mthSearchPatientInDocvue(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID);
//		}
//
//		private void m_mthSearchPatientInDocvue(string p_strBedID)
//		{
//			clsPatDemo[] objPatDemoArr;
//			m_objDomain.m_lngGetPatientInfo(p_strBedID, out objPatDemoArr);
//
//			if(objPatDemoArr != null && objPatDemoArr.Length==1)
//			{
//				m_objPatDemo = objPatDemoArr[0];
//			}
//		}

		private void timRefresh_Tick(object sender, System.EventArgs e)
		{
//			if(m_objPatDemo == null)
//				return;

			if(m_objGroupSetArr == null || m_objGroupSetArr.Length == 0)
				return;

//			m_nmuTotal.Value += m_intRefreshRate;
			dtpEndTime.Value = dtpEndTime.Value.AddMinutes((double)m_intRefreshRate);
			dtpBeginTime.Value = dtpBeginTime.Value.AddMinutes((double)m_intRefreshRate);
//			dtpEndTime_evtValueChanged(null,null);

			cmdTrenData_Click(null,null);
		}

		private void m_nmuTotal_ValueChanged(object sender, System.EventArgs e)
		{
			dtpEndTime.Value = dtpBeginTime.Value.AddMinutes(Decimal.ToDouble(m_nmuTotal.Value));
		}

		/// <summary>
		/// 不需要保存提示
		/// </summary>
		protected override void m_mthAddFormStatusForClosingSave()
		{
		}
	}
}

