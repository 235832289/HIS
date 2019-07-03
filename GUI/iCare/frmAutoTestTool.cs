using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Diagnostics;
using System.IO;
using com.digitalwave.Utility.Controls;
using com.digitalwave.Utility;

namespace iCare
{
	/// <summary>
	/// 自动测试结果
	/// </summary>
	public enum enmAutoTestResult
	{
		/// <summary>
		/// 测试成功
		/// </summary>
		Succeed,
		/// <summary>
		/// 测试失败
		/// </summary>
		Failure
	}

	/// <summary>
	/// 自动测试接口
	/// </summary>
	public interface infAutoTest
	{
		/// <summary>
		/// 新增功能测试
		/// </summary>
		/// <param name="p_objContentMaker">测试内容制造器</param>
		/// <param name="p_strInnerMessage">出错信息输出</param>
		/// <returns>
		/// 执行结果
		/// </returns>
		enmAutoTestResult i_enmTestAddNew(clsTestContentMaker p_objContentMaker,out string p_strInnerFailMessage);
		/// <summary>
		/// 修改功能测试
		/// </summary>
		/// <param name="p_objContentMaker">测试内容制造器</param>
		/// <param name="p_strInnerMessage">出错信息输出</param>
		/// <returns>
		/// 执行结果
		/// </returns>
		enmAutoTestResult i_enmTestModify(clsTestContentMaker p_objContentMaker,out string p_strInnerFailMessage);
		/// <summary>
		/// 删除功能测试
		/// </summary>
		/// <param name="p_objContentMaker">测试内容制造器</param>
		/// <param name="p_strInnerMessage">出错信息输出</param>
		/// <returns>
		/// 执行结果
		/// </returns>
		enmAutoTestResult i_enmTestDelete(clsTestContentMaker p_objContentMaker,out string p_strInnerFailMessage);
		/// <summary>
		/// 显示功能测试（不提供）
		/// </summary>
		/// <param name="p_objContentMaker">测试内容制造器</param>
		/// <param name="p_strInnerMessage">出错信息输出</param>
		/// <returns>
		/// 执行结果
		/// </returns>
		enmAutoTestResult i_enmTestDisplay(clsTestContentMaker p_objContentMaker,out string p_strInnerFailMessage);
	}

	/// <summary>
	/// 自动测试工具。使用单线程，测试时界面会不相应。
	/// liyi 2003-1-7
	/// </summary>
	public class frmAutoTestTool : iCare.iCareBaseForm.frmBaseForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAutoTestTool()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            //m_objBorderTool = new clsBorderTool(Color.White);

            //m_objBorderTool.m_mthChangedControlBorder(m_lsvRunningFormList);
            //m_objBorderTool.m_mthChangedControlBorder(m_nmuTestTimes);
            //m_objBorderTool.m_mthChangedControlBorder(m_nmuWaitMil);
            //m_objBorderTool.m_mthChangedControlBorder(m_lsvTestFailureInfo);

			m_objContentMaker = null;

			m_objLog = new clsLogText();
		}
		private System.Windows.Forms.TabPage tbpTestFormSelect;
		private System.Windows.Forms.NumericUpDown m_nmuTestTimes;
		private System.Windows.Forms.Label lblFormName;
		private System.Windows.Forms.Button m_cmdGetRunningForm;
		private System.Windows.Forms.ListView m_lsvRunningFormList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label lblRunningFormList;
		private System.Windows.Forms.Label m_lblFormText;
		private System.Windows.Forms.Label lblFormText;
		private System.Windows.Forms.Label m_lblFormName;
		private System.Windows.Forms.Label m_lblFormCanTest;
		private System.Windows.Forms.Label lblFormCanTest;
		private System.Windows.Forms.Button m_cmdTestModify;
		private System.Windows.Forms.Button m_cmdTestDisplay;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTestInfoFormName;
		private System.Windows.Forms.Label m_lblTestInfoFormText;
		private System.Windows.Forms.Label lblTestInfoFormText;
		private System.Windows.Forms.Label m_lblTestInfoFormName;
		private System.Windows.Forms.Label lblWaitMil;
		private System.Windows.Forms.NumericUpDown m_nmuWaitMil;
		private System.Windows.Forms.Label lblTestCurrentTimes;
		private System.Windows.Forms.Label m_lblTestTotalTimes;
		private System.Windows.Forms.Label lblTestTotalTimes;
		private System.Windows.Forms.Label m_lblTestCurrentTimes;
		private System.Windows.Forms.Label m_lblTestSucTimes;
		private System.Windows.Forms.Label lblTestFailTimes;
		private System.Windows.Forms.Label m_lblTestFailTimes;
		private System.Windows.Forms.Label lblTestSucTimes;
		private System.Windows.Forms.ListView m_lsvTestFailureInfo;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label lblTestFailInfo;
		private System.Windows.Forms.Label m_lblTestRecordTime;
		private System.Windows.Forms.Label lblTestItemName;
		private System.Windows.Forms.Label m_lblTestItemName;
		private System.Windows.Forms.Label lblTestRecordTime;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.TabPage tbpTestResultInfo;
		private System.Windows.Forms.Button m_cmdStopTest;
		private System.Windows.Forms.Button m_cmdGetTestContentFile;
		private System.Windows.Forms.Label lblTestFilePath;
		private System.Windows.Forms.Label m_lblTestFilePath;
		private System.Windows.Forms.OpenFileDialog m_ofdTestFile;
		private System.Windows.Forms.TabControl m_tabTest;
		private System.Windows.Forms.Button m_cmdTestDelete;
		private System.Windows.Forms.Button m_cmdTestAddNew;
		private System.Windows.Forms.Button m_cmdStartTest;

		
		/// <summary>
		/// 自动测试内容生成器
		/// </summary>
		private clsTestContentMaker m_objContentMaker;
		/// <summary>
		/// 边框工具
		/// </summary>
        //private clsBorderTool m_objBorderTool;

		/// <summary>
		/// 测试项目
		/// </summary>
		private enmTestItem m_enmTestItem;
		/// <summary>
		/// 被测试者
		/// </summary>
		private infAutoTest m_objTester;
		/// <summary>
		/// 被测试的窗体
		/// </summary>
		private Form m_frmTester;		

		/// <summary>
		/// 总共测试次数
		/// </summary>
		private int m_intTestTotalTimes;
		/// <summary>
		/// 当前测试次数
		/// </summary>
		private int m_intTestCurrentTimes;
		/// <summary>
		/// 测试成功次数
		/// </summary>
		private int m_intTestSucTimes;
		/// <summary>
		/// 测试失败次数
		/// </summary>
		private int m_intTestFailTimes;
		/// <summary>
		/// 每次测试的间隔
		/// </summary>
		private int m_intTestWaitMil;

		/// <summary>
		/// 当批测试的时间
		/// </summary>
		private string m_strRecordTime;

		private const string c_strAutoContent = "\r\n自动生成结果：\r\n\r\n";
		private const string c_strDBLog = "\r\n================================================================\r\n数据库执行信息：\r\n\r\n";
		private const string c_strFormValue = "\r\n================================================================\r\n窗体控件值：\r\n\r\n";
		private const string c_strInnerFailMessage = "\r\n================================================================\r\n内部信息：\r\n\r\n";
		private const string c_strExceptionMessage = "\r\n================================================================\r\n异常信息：\r\n\r\n";
		
		/// <summary>
		/// 测试失败记录总目录
		/// </summary>
		private const string c_strLogDir = "d:\\Code\\AutoTestLog";

		/// <summary>
		/// 记录工具
		/// </summary>
        private clsLogText m_objLog;

		/// <summary>
		/// 使用多线程测试，但由于多线程中操作控件有问题，现不使用。
		/// </summary>
		private Thread m_thrRunningTest;

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
			this.m_tabTest = new System.Windows.Forms.TabControl();
			this.tbpTestFormSelect = new System.Windows.Forms.TabPage();
			this.m_cmdTestDelete = new System.Windows.Forms.Button();
			this.m_cmdTestAddNew = new System.Windows.Forms.Button();
			this.m_nmuTestTimes = new System.Windows.Forms.NumericUpDown();
			this.lblFormName = new System.Windows.Forms.Label();
			this.m_cmdGetRunningForm = new System.Windows.Forms.Button();
			this.m_lsvRunningFormList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.lblRunningFormList = new System.Windows.Forms.Label();
			this.m_lblFormText = new System.Windows.Forms.Label();
			this.lblFormText = new System.Windows.Forms.Label();
			this.m_lblFormName = new System.Windows.Forms.Label();
			this.m_lblFormCanTest = new System.Windows.Forms.Label();
			this.lblFormCanTest = new System.Windows.Forms.Label();
			this.m_cmdTestModify = new System.Windows.Forms.Button();
			this.m_cmdTestDisplay = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblWaitMil = new System.Windows.Forms.Label();
			this.m_nmuWaitMil = new System.Windows.Forms.NumericUpDown();
			this.m_cmdGetTestContentFile = new System.Windows.Forms.Button();
			this.lblTestFilePath = new System.Windows.Forms.Label();
			this.m_lblTestFilePath = new System.Windows.Forms.Label();
			this.tbpTestResultInfo = new System.Windows.Forms.TabPage();
			this.m_cmdStopTest = new System.Windows.Forms.Button();
			this.m_lsvTestFailureInfo = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.lblTestInfoFormName = new System.Windows.Forms.Label();
			this.m_lblTestInfoFormText = new System.Windows.Forms.Label();
			this.lblTestInfoFormText = new System.Windows.Forms.Label();
			this.m_lblTestInfoFormName = new System.Windows.Forms.Label();
			this.lblTestCurrentTimes = new System.Windows.Forms.Label();
			this.m_lblTestTotalTimes = new System.Windows.Forms.Label();
			this.lblTestTotalTimes = new System.Windows.Forms.Label();
			this.m_lblTestCurrentTimes = new System.Windows.Forms.Label();
			this.m_lblTestSucTimes = new System.Windows.Forms.Label();
			this.lblTestFailTimes = new System.Windows.Forms.Label();
			this.m_lblTestFailTimes = new System.Windows.Forms.Label();
			this.lblTestSucTimes = new System.Windows.Forms.Label();
			this.lblTestFailInfo = new System.Windows.Forms.Label();
			this.m_lblTestRecordTime = new System.Windows.Forms.Label();
			this.lblTestItemName = new System.Windows.Forms.Label();
			this.m_lblTestItemName = new System.Windows.Forms.Label();
			this.lblTestRecordTime = new System.Windows.Forms.Label();
			this.m_cmdStartTest = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.m_ofdTestFile = new System.Windows.Forms.OpenFileDialog();
			this.m_tabTest.SuspendLayout();
			this.tbpTestFormSelect.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_nmuTestTimes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_nmuWaitMil)).BeginInit();
			this.tbpTestResultInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_tabTest
			// 
			this.m_tabTest.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tbpTestFormSelect,
																					this.tbpTestResultInfo});
			this.m_tabTest.Location = new System.Drawing.Point(52, 20);
			this.m_tabTest.Name = "m_tabTest";
			this.m_tabTest.SelectedIndex = 0;
			this.m_tabTest.Size = new System.Drawing.Size(900, 608);
			this.m_tabTest.TabIndex = 407;
			// 
			// tbpTestFormSelect
			// 
			this.tbpTestFormSelect.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tbpTestFormSelect.Controls.AddRange(new System.Windows.Forms.Control[] {
																							this.m_cmdTestDelete,
																							this.m_cmdTestAddNew,
																							this.m_nmuTestTimes,
																							this.lblFormName,
																							this.m_cmdGetRunningForm,
																							this.m_lsvRunningFormList,
																							this.lblRunningFormList,
																							this.m_lblFormText,
																							this.lblFormText,
																							this.m_lblFormName,
																							this.m_lblFormCanTest,
																							this.lblFormCanTest,
																							this.m_cmdTestModify,
																							this.m_cmdTestDisplay,
																							this.label1,
																							this.lblWaitMil,
																							this.m_nmuWaitMil,
																							this.m_cmdGetTestContentFile,
																							this.lblTestFilePath,
																							this.m_lblTestFilePath});
			this.tbpTestFormSelect.Location = new System.Drawing.Point(4, 23);
			this.tbpTestFormSelect.Name = "tbpTestFormSelect";
			this.tbpTestFormSelect.Size = new System.Drawing.Size(892, 581);
			this.tbpTestFormSelect.TabIndex = 0;
			this.tbpTestFormSelect.Text = "测试选项";
			this.tbpTestFormSelect.Click += new System.EventHandler(this.tbpTestFormSelect_Click);
			// 
			// m_cmdTestDelete
			// 
			this.m_cmdTestDelete.Enabled = false;
			this.m_cmdTestDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdTestDelete.ForeColor = System.Drawing.Color.White;
			this.m_cmdTestDelete.Location = new System.Drawing.Point(708, 308);
			this.m_cmdTestDelete.Name = "m_cmdTestDelete";
			this.m_cmdTestDelete.Size = new System.Drawing.Size(75, 28);
			this.m_cmdTestDelete.TabIndex = 430;
			this.m_cmdTestDelete.Text = "测试删除";
			this.m_cmdTestDelete.Click += new System.EventHandler(this.m_cmdTestDelete_Click);
			// 
			// m_cmdTestAddNew
			// 
			this.m_cmdTestAddNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_cmdTestAddNew.Enabled = false;
			this.m_cmdTestAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdTestAddNew.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdTestAddNew.ForeColor = System.Drawing.Color.White;
			this.m_cmdTestAddNew.Location = new System.Drawing.Point(512, 308);
			this.m_cmdTestAddNew.Name = "m_cmdTestAddNew";
			this.m_cmdTestAddNew.Size = new System.Drawing.Size(75, 28);
			this.m_cmdTestAddNew.TabIndex = 429;
			this.m_cmdTestAddNew.Text = "测试添加";
			this.m_cmdTestAddNew.Click += new System.EventHandler(this.m_cmdTestAddNew_Click);
			// 
			// m_nmuTestTimes
			// 
			this.m_nmuTestTimes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_nmuTestTimes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_nmuTestTimes.Enabled = false;
			this.m_nmuTestTimes.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_nmuTestTimes.ForeColor = System.Drawing.Color.White;
			this.m_nmuTestTimes.Location = new System.Drawing.Point(615, 224);
			this.m_nmuTestTimes.Maximum = new System.Decimal(new int[] {
																		   -727379968,
																		   232,
																		   0,
																		   0});
			this.m_nmuTestTimes.Name = "m_nmuTestTimes";
			this.m_nmuTestTimes.TabIndex = 421;
			this.m_nmuTestTimes.ThousandsSeparator = true;
			this.m_nmuTestTimes.Value = new System.Decimal(new int[] {
																		 100000,
																		 0,
																		 0,
																		 0});
			// 
			// lblFormName
			// 
			this.lblFormName.ForeColor = System.Drawing.Color.White;
			this.lblFormName.Location = new System.Drawing.Point(511, 118);
			this.lblFormName.Name = "lblFormName";
			this.lblFormName.TabIndex = 417;
			this.lblFormName.Text = "窗体名称：";
			// 
			// m_cmdGetRunningForm
			// 
			this.m_cmdGetRunningForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdGetRunningForm.ForeColor = System.Drawing.Color.White;
			this.m_cmdGetRunningForm.Location = new System.Drawing.Point(24, 20);
			this.m_cmdGetRunningForm.Name = "m_cmdGetRunningForm";
			this.m_cmdGetRunningForm.Size = new System.Drawing.Size(75, 28);
			this.m_cmdGetRunningForm.TabIndex = 412;
			this.m_cmdGetRunningForm.Text = "获取窗体";
			this.m_cmdGetRunningForm.Click += new System.EventHandler(this.m_cmdGetActiveForm_Click);
			// 
			// m_lsvRunningFormList
			// 
			this.m_lsvRunningFormList.AllowColumnReorder = true;
			this.m_lsvRunningFormList.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lsvRunningFormList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvRunningFormList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								   this.columnHeader1,
																								   this.columnHeader2,
																								   this.columnHeader3});
			this.m_lsvRunningFormList.ForeColor = System.Drawing.Color.White;
			this.m_lsvRunningFormList.FullRowSelect = true;
			this.m_lsvRunningFormList.Location = new System.Drawing.Point(19, 96);
			this.m_lsvRunningFormList.MultiSelect = false;
			this.m_lsvRunningFormList.Name = "m_lsvRunningFormList";
			this.m_lsvRunningFormList.Size = new System.Drawing.Size(428, 460);
			this.m_lsvRunningFormList.TabIndex = 408;
			this.m_lsvRunningFormList.View = System.Windows.Forms.View.Details;
			this.m_lsvRunningFormList.DoubleClick += new System.EventHandler(this.m_lsvRunningFormList_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "窗体标题";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "窗体名称";
			this.columnHeader2.Width = 150;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "可否自动测试";
			this.columnHeader3.Width = 120;
			// 
			// lblRunningFormList
			// 
			this.lblRunningFormList.ForeColor = System.Drawing.Color.White;
			this.lblRunningFormList.Location = new System.Drawing.Point(24, 68);
			this.lblRunningFormList.Name = "lblRunningFormList";
			this.lblRunningFormList.Size = new System.Drawing.Size(108, 16);
			this.lblRunningFormList.TabIndex = 407;
			this.lblRunningFormList.Text = "运行窗体列表：";
			// 
			// m_lblFormText
			// 
			this.m_lblFormText.ForeColor = System.Drawing.Color.White;
			this.m_lblFormText.Location = new System.Drawing.Point(611, 66);
			this.m_lblFormText.Name = "m_lblFormText";
			this.m_lblFormText.Size = new System.Drawing.Size(220, 23);
			this.m_lblFormText.TabIndex = 416;
			// 
			// lblFormText
			// 
			this.lblFormText.ForeColor = System.Drawing.Color.White;
			this.lblFormText.Location = new System.Drawing.Point(511, 66);
			this.lblFormText.Name = "lblFormText";
			this.lblFormText.TabIndex = 418;
			this.lblFormText.Text = "窗体标题：";
			// 
			// m_lblFormName
			// 
			this.m_lblFormName.ForeColor = System.Drawing.Color.White;
			this.m_lblFormName.Location = new System.Drawing.Point(611, 118);
			this.m_lblFormName.Name = "m_lblFormName";
			this.m_lblFormName.Size = new System.Drawing.Size(224, 23);
			this.m_lblFormName.TabIndex = 420;
			// 
			// m_lblFormCanTest
			// 
			this.m_lblFormCanTest.ForeColor = System.Drawing.Color.White;
			this.m_lblFormCanTest.Location = new System.Drawing.Point(611, 170);
			this.m_lblFormCanTest.Name = "m_lblFormCanTest";
			this.m_lblFormCanTest.Size = new System.Drawing.Size(224, 23);
			this.m_lblFormCanTest.TabIndex = 419;
			// 
			// lblFormCanTest
			// 
			this.lblFormCanTest.ForeColor = System.Drawing.Color.White;
			this.lblFormCanTest.Location = new System.Drawing.Point(511, 170);
			this.lblFormCanTest.Name = "lblFormCanTest";
			this.lblFormCanTest.TabIndex = 414;
			this.lblFormCanTest.Text = "可否测试：";
			// 
			// m_cmdTestModify
			// 
			this.m_cmdTestModify.Enabled = false;
			this.m_cmdTestModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdTestModify.ForeColor = System.Drawing.Color.White;
			this.m_cmdTestModify.Location = new System.Drawing.Point(608, 308);
			this.m_cmdTestModify.Name = "m_cmdTestModify";
			this.m_cmdTestModify.Size = new System.Drawing.Size(75, 28);
			this.m_cmdTestModify.TabIndex = 410;
			this.m_cmdTestModify.Text = "测试修改";
			this.m_cmdTestModify.Click += new System.EventHandler(this.m_cmdTestModify_Click);
			// 
			// m_cmdTestDisplay
			// 
			this.m_cmdTestDisplay.Enabled = false;
			this.m_cmdTestDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdTestDisplay.ForeColor = System.Drawing.Color.White;
			this.m_cmdTestDisplay.Location = new System.Drawing.Point(800, 308);
			this.m_cmdTestDisplay.Name = "m_cmdTestDisplay";
			this.m_cmdTestDisplay.Size = new System.Drawing.Size(75, 28);
			this.m_cmdTestDisplay.TabIndex = 413;
			this.m_cmdTestDisplay.Text = "测试显示";
			this.m_cmdTestDisplay.Visible = false;
			this.m_cmdTestDisplay.Click += new System.EventHandler(this.m_cmdTestDisplay_Click);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(511, 222);
			this.label1.Name = "label1";
			this.label1.TabIndex = 415;
			this.label1.Text = "测试次数：";
			// 
			// lblWaitMil
			// 
			this.lblWaitMil.ForeColor = System.Drawing.Color.White;
			this.lblWaitMil.Location = new System.Drawing.Point(512, 266);
			this.lblWaitMil.Name = "lblWaitMil";
			this.lblWaitMil.TabIndex = 415;
			this.lblWaitMil.Text = "停顿毫秒：";
			// 
			// m_nmuWaitMil
			// 
			this.m_nmuWaitMil.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_nmuWaitMil.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_nmuWaitMil.Enabled = false;
			this.m_nmuWaitMil.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_nmuWaitMil.ForeColor = System.Drawing.Color.White;
			this.m_nmuWaitMil.Location = new System.Drawing.Point(616, 268);
			this.m_nmuWaitMil.Maximum = new System.Decimal(new int[] {
																		 -727379968,
																		 232,
																		 0,
																		 0});
			this.m_nmuWaitMil.Minimum = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.m_nmuWaitMil.Name = "m_nmuWaitMil";
			this.m_nmuWaitMil.TabIndex = 421;
			this.m_nmuWaitMil.ThousandsSeparator = true;
			this.m_nmuWaitMil.Value = new System.Decimal(new int[] {
																	   10,
																	   0,
																	   0,
																	   0});
			// 
			// m_cmdGetTestContentFile
			// 
			this.m_cmdGetTestContentFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdGetTestContentFile.ForeColor = System.Drawing.Color.White;
			this.m_cmdGetTestContentFile.Location = new System.Drawing.Point(132, 20);
			this.m_cmdGetTestContentFile.Name = "m_cmdGetTestContentFile";
			this.m_cmdGetTestContentFile.Size = new System.Drawing.Size(75, 28);
			this.m_cmdGetTestContentFile.TabIndex = 412;
			this.m_cmdGetTestContentFile.Text = "测试文件";
			this.m_cmdGetTestContentFile.Click += new System.EventHandler(this.m_cmdGetTestContentFile_Click);
			// 
			// lblTestFilePath
			// 
			this.lblTestFilePath.ForeColor = System.Drawing.Color.White;
			this.lblTestFilePath.Location = new System.Drawing.Point(216, 24);
			this.lblTestFilePath.Name = "lblTestFilePath";
			this.lblTestFilePath.Size = new System.Drawing.Size(108, 20);
			this.lblTestFilePath.TabIndex = 407;
			this.lblTestFilePath.Text = "测试内容文件：";
			// 
			// m_lblTestFilePath
			// 
			this.m_lblTestFilePath.ForeColor = System.Drawing.Color.White;
			this.m_lblTestFilePath.Location = new System.Drawing.Point(328, 23);
			this.m_lblTestFilePath.Name = "m_lblTestFilePath";
			this.m_lblTestFilePath.Size = new System.Drawing.Size(556, 23);
			this.m_lblTestFilePath.TabIndex = 416;
			// 
			// tbpTestResultInfo
			// 
			this.tbpTestResultInfo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tbpTestResultInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
																							this.m_cmdStopTest,
																							this.m_lsvTestFailureInfo,
																							this.lblTestInfoFormName,
																							this.m_lblTestInfoFormText,
																							this.lblTestInfoFormText,
																							this.m_lblTestInfoFormName,
																							this.lblTestCurrentTimes,
																							this.m_lblTestTotalTimes,
																							this.lblTestTotalTimes,
																							this.m_lblTestCurrentTimes,
																							this.m_lblTestSucTimes,
																							this.lblTestFailTimes,
																							this.m_lblTestFailTimes,
																							this.lblTestSucTimes,
																							this.lblTestFailInfo,
																							this.m_lblTestRecordTime,
																							this.lblTestItemName,
																							this.m_lblTestItemName,
																							this.lblTestRecordTime,
																							this.m_cmdStartTest});
			this.tbpTestResultInfo.Location = new System.Drawing.Point(4, 21);
			this.tbpTestResultInfo.Name = "tbpTestResultInfo";
			this.tbpTestResultInfo.Size = new System.Drawing.Size(892, 583);
			this.tbpTestResultInfo.TabIndex = 1;
			this.tbpTestResultInfo.Text = "测试信息";
			// 
			// m_cmdStopTest
			// 
			this.m_cmdStopTest.Enabled = false;
			this.m_cmdStopTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdStopTest.ForeColor = System.Drawing.Color.White;
			this.m_cmdStopTest.Location = new System.Drawing.Point(284, 156);
			this.m_cmdStopTest.Name = "m_cmdStopTest";
			this.m_cmdStopTest.Size = new System.Drawing.Size(75, 28);
			this.m_cmdStopTest.TabIndex = 426;
			this.m_cmdStopTest.Text = "停止测试";
			this.m_cmdStopTest.Visible = false;
			this.m_cmdStopTest.Click += new System.EventHandler(this.m_cmdStopTest_Click);
			// 
			// m_lsvTestFailureInfo
			// 
			this.m_lsvTestFailureInfo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lsvTestFailureInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvTestFailureInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								   this.columnHeader4,
																								   this.columnHeader5,
																								   this.columnHeader6,
																								   this.columnHeader7,
																								   this.columnHeader8});
			this.m_lsvTestFailureInfo.ForeColor = System.Drawing.Color.White;
			this.m_lsvTestFailureInfo.FullRowSelect = true;
			this.m_lsvTestFailureInfo.Location = new System.Drawing.Point(32, 188);
			this.m_lsvTestFailureInfo.Name = "m_lsvTestFailureInfo";
			this.m_lsvTestFailureInfo.Size = new System.Drawing.Size(840, 372);
			this.m_lsvTestFailureInfo.TabIndex = 425;
			this.m_lsvTestFailureInfo.View = System.Windows.Forms.View.Details;
			this.m_lsvTestFailureInfo.DoubleClick += new System.EventHandler(this.m_lsvTestFailureInfo_DoubleClick);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "编号";
			this.columnHeader4.Width = 50;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "次数";
			this.columnHeader5.Width = 50;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "时间";
			this.columnHeader6.Width = 280;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "内部描述";
			this.columnHeader7.Width = 100;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "记录文件";
			this.columnHeader8.Width = 360;
			// 
			// lblTestInfoFormName
			// 
			this.lblTestInfoFormName.ForeColor = System.Drawing.Color.White;
			this.lblTestInfoFormName.Location = new System.Drawing.Point(420, 20);
			this.lblTestInfoFormName.Name = "lblTestInfoFormName";
			this.lblTestInfoFormName.TabIndex = 422;
			this.lblTestInfoFormName.Text = "窗体名称：";
			// 
			// m_lblTestInfoFormText
			// 
			this.m_lblTestInfoFormText.ForeColor = System.Drawing.Color.White;
			this.m_lblTestInfoFormText.Location = new System.Drawing.Point(132, 20);
			this.m_lblTestInfoFormText.Name = "m_lblTestInfoFormText";
			this.m_lblTestInfoFormText.Size = new System.Drawing.Size(220, 23);
			this.m_lblTestInfoFormText.TabIndex = 421;
			// 
			// lblTestInfoFormText
			// 
			this.lblTestInfoFormText.ForeColor = System.Drawing.Color.White;
			this.lblTestInfoFormText.Location = new System.Drawing.Point(32, 20);
			this.lblTestInfoFormText.Name = "lblTestInfoFormText";
			this.lblTestInfoFormText.TabIndex = 423;
			this.lblTestInfoFormText.Text = "窗体标题：";
			// 
			// m_lblTestInfoFormName
			// 
			this.m_lblTestInfoFormName.ForeColor = System.Drawing.Color.White;
			this.m_lblTestInfoFormName.Location = new System.Drawing.Point(520, 20);
			this.m_lblTestInfoFormName.Name = "m_lblTestInfoFormName";
			this.m_lblTestInfoFormName.Size = new System.Drawing.Size(224, 23);
			this.m_lblTestInfoFormName.TabIndex = 424;
			// 
			// lblTestCurrentTimes
			// 
			this.lblTestCurrentTimes.ForeColor = System.Drawing.Color.White;
			this.lblTestCurrentTimes.Location = new System.Drawing.Point(220, 108);
			this.lblTestCurrentTimes.Name = "lblTestCurrentTimes";
			this.lblTestCurrentTimes.Size = new System.Drawing.Size(84, 23);
			this.lblTestCurrentTimes.TabIndex = 422;
			this.lblTestCurrentTimes.Text = "当前次数：";
			// 
			// m_lblTestTotalTimes
			// 
			this.m_lblTestTotalTimes.ForeColor = System.Drawing.Color.White;
			this.m_lblTestTotalTimes.Location = new System.Drawing.Point(124, 108);
			this.m_lblTestTotalTimes.Name = "m_lblTestTotalTimes";
			this.m_lblTestTotalTimes.Size = new System.Drawing.Size(80, 23);
			this.m_lblTestTotalTimes.TabIndex = 421;
			// 
			// lblTestTotalTimes
			// 
			this.lblTestTotalTimes.ForeColor = System.Drawing.Color.White;
			this.lblTestTotalTimes.Location = new System.Drawing.Point(32, 108);
			this.lblTestTotalTimes.Name = "lblTestTotalTimes";
			this.lblTestTotalTimes.Size = new System.Drawing.Size(92, 23);
			this.lblTestTotalTimes.TabIndex = 423;
			this.lblTestTotalTimes.Text = "测试总次数：";
			// 
			// m_lblTestCurrentTimes
			// 
			this.m_lblTestCurrentTimes.ForeColor = System.Drawing.Color.White;
			this.m_lblTestCurrentTimes.Location = new System.Drawing.Point(304, 108);
			this.m_lblTestCurrentTimes.Name = "m_lblTestCurrentTimes";
			this.m_lblTestCurrentTimes.Size = new System.Drawing.Size(80, 23);
			this.m_lblTestCurrentTimes.TabIndex = 424;
			// 
			// m_lblTestSucTimes
			// 
			this.m_lblTestSucTimes.ForeColor = System.Drawing.Color.White;
			this.m_lblTestSucTimes.Location = new System.Drawing.Point(476, 108);
			this.m_lblTestSucTimes.Name = "m_lblTestSucTimes";
			this.m_lblTestSucTimes.Size = new System.Drawing.Size(80, 23);
			this.m_lblTestSucTimes.TabIndex = 421;
			// 
			// lblTestFailTimes
			// 
			this.lblTestFailTimes.ForeColor = System.Drawing.Color.White;
			this.lblTestFailTimes.Location = new System.Drawing.Point(568, 108);
			this.lblTestFailTimes.Name = "lblTestFailTimes";
			this.lblTestFailTimes.Size = new System.Drawing.Size(80, 23);
			this.lblTestFailTimes.TabIndex = 422;
			this.lblTestFailTimes.Text = "失败次数：";
			// 
			// m_lblTestFailTimes
			// 
			this.m_lblTestFailTimes.ForeColor = System.Drawing.Color.White;
			this.m_lblTestFailTimes.Location = new System.Drawing.Point(648, 108);
			this.m_lblTestFailTimes.Name = "m_lblTestFailTimes";
			this.m_lblTestFailTimes.Size = new System.Drawing.Size(80, 23);
			this.m_lblTestFailTimes.TabIndex = 424;
			// 
			// lblTestSucTimes
			// 
			this.lblTestSucTimes.ForeColor = System.Drawing.Color.White;
			this.lblTestSucTimes.Location = new System.Drawing.Point(396, 108);
			this.lblTestSucTimes.Name = "lblTestSucTimes";
			this.lblTestSucTimes.Size = new System.Drawing.Size(80, 23);
			this.lblTestSucTimes.TabIndex = 423;
			this.lblTestSucTimes.Text = "成功次数：";
			// 
			// lblTestFailInfo
			// 
			this.lblTestFailInfo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblTestFailInfo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTestFailInfo.ForeColor = System.Drawing.Color.White;
			this.lblTestFailInfo.Location = new System.Drawing.Point(32, 156);
			this.lblTestFailInfo.Name = "lblTestFailInfo";
			this.lblTestFailInfo.Size = new System.Drawing.Size(108, 23);
			this.lblTestFailInfo.TabIndex = 423;
			this.lblTestFailInfo.Text = "测试失败信息：";
			// 
			// m_lblTestRecordTime
			// 
			this.m_lblTestRecordTime.ForeColor = System.Drawing.Color.White;
			this.m_lblTestRecordTime.Location = new System.Drawing.Point(168, 64);
			this.m_lblTestRecordTime.Name = "m_lblTestRecordTime";
			this.m_lblTestRecordTime.Size = new System.Drawing.Size(240, 23);
			this.m_lblTestRecordTime.TabIndex = 421;
			// 
			// lblTestItemName
			// 
			this.lblTestItemName.ForeColor = System.Drawing.Color.White;
			this.lblTestItemName.Location = new System.Drawing.Point(420, 64);
			this.lblTestItemName.Name = "lblTestItemName";
			this.lblTestItemName.Size = new System.Drawing.Size(84, 23);
			this.lblTestItemName.TabIndex = 422;
			this.lblTestItemName.Text = "测试项目：";
			// 
			// m_lblTestItemName
			// 
			this.m_lblTestItemName.ForeColor = System.Drawing.Color.White;
			this.m_lblTestItemName.Location = new System.Drawing.Point(504, 64);
			this.m_lblTestItemName.Name = "m_lblTestItemName";
			this.m_lblTestItemName.Size = new System.Drawing.Size(164, 23);
			this.m_lblTestItemName.TabIndex = 424;
			// 
			// lblTestRecordTime
			// 
			this.lblTestRecordTime.ForeColor = System.Drawing.Color.White;
			this.lblTestRecordTime.Location = new System.Drawing.Point(32, 64);
			this.lblTestRecordTime.Name = "lblTestRecordTime";
			this.lblTestRecordTime.Size = new System.Drawing.Size(136, 23);
			this.lblTestRecordTime.TabIndex = 423;
			this.lblTestRecordTime.Text = "测试（记录）时间：";
			// 
			// m_cmdStartTest
			// 
			this.m_cmdStartTest.Enabled = false;
			this.m_cmdStartTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdStartTest.ForeColor = System.Drawing.Color.White;
			this.m_cmdStartTest.Location = new System.Drawing.Point(196, 156);
			this.m_cmdStartTest.Name = "m_cmdStartTest";
			this.m_cmdStartTest.Size = new System.Drawing.Size(75, 28);
			this.m_cmdStartTest.TabIndex = 426;
			this.m_cmdStartTest.Text = "开始测试";
			this.m_cmdStartTest.Click += new System.EventHandler(this.m_cmdStartTest_Click);
			// 
			// listView1
			// 
			this.listView1.Name = "listView1";
			this.listView1.TabIndex = 0;
			// 
			// m_ofdTestFile
			// 
			this.m_ofdTestFile.Filter = "Txt files|*.txt";
			this.m_ofdTestFile.Title = "测试内容文件";
			// 
			// frmAutoTestTool
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(1016, 741);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_tabTest});
			this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmAutoTestTool";
			this.Text = "自动测试工具";
			this.m_tabTest.ResumeLayout(false);
			this.tbpTestFormSelect.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_nmuTestTimes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_nmuWaitMil)).EndInit();
			this.tbpTestResultInfo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdGetActiveForm_Click(object sender, System.EventArgs e)
		{
			m_mthClearFormSelect();

			m_mthGetRunningForm();
		}

		/// <summary>
		/// 获取MDI中运行的窗体
		/// </summary>
		private void m_mthGetRunningForm()
		{
			m_lsvRunningFormList.Items.Clear();

			Form frmMDI = this.MdiParent;

			Form[] frmRunningFormArr = frmMDI.MdiChildren;

			for(int i=0;i<frmRunningFormArr.Length;i++)
			{
				Type typForm = frmRunningFormArr[i].GetType();

				bool blnCanAutoTest = typForm.GetInterface("infAutoTest") != null;
				ListViewItem lviFormInfo = new ListViewItem(
					new string[]{
					frmRunningFormArr[i].Text,
					frmRunningFormArr[i].Name,
					blnCanAutoTest.ToString()
								});
				lviFormInfo.Tag = frmRunningFormArr[i];

				m_lsvRunningFormList.Items.Add(lviFormInfo);
			}
		}

		/// <summary>
		/// 清空窗体的选择
		/// </summary>
		private void m_mthClearFormSelect()
		{
			m_lblFormText.Text = "";
			m_lblFormText.Tag = null;

			m_lblFormName.Text = "";
			m_lblFormCanTest.Text = "";

			m_nmuTestTimes.Value = 100000;
			m_nmuWaitMil.Value = 1;

			m_mthCanRunTest(false);
		}

		/// <summary>
		/// 设置是否可以测试
		/// </summary>
		/// <param name="p_blnCanRunning"></param>
		private void m_mthCanRunTest(bool p_blnCanRunning)
		{
			m_cmdTestAddNew.Enabled = p_blnCanRunning;
			m_cmdTestModify.Enabled = p_blnCanRunning;
			m_cmdTestDelete.Enabled = p_blnCanRunning;
			m_cmdTestDisplay.Enabled = p_blnCanRunning;

			m_nmuTestTimes.Enabled = p_blnCanRunning;
			m_nmuWaitMil.Enabled = p_blnCanRunning;
		}

		private void m_lsvRunningFormList_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvRunningFormList.SelectedItems.Count <= 0)
				return;

			m_mthClearFormSelect();

			ListViewItem lviTestForm = m_lsvRunningFormList.SelectedItems[0];

			m_lblFormText.Text = lviTestForm.SubItems[0].Text;
			m_lblFormName.Text = lviTestForm.SubItems[1].Text;
			m_lblFormCanTest.Text = lviTestForm.SubItems[2].Text;

			bool blnCanTest = bool.Parse(m_lblFormCanTest.Text);

			m_mthCanRunTest(blnCanTest);

			if(blnCanTest)
				m_lblFormText.Tag = lviTestForm.Tag;
		}

		/// <summary>
		/// 测试测试信息
		/// </summary>
		private void m_mthClearTestInfo()
		{
			m_lblTestInfoFormText.Text = "";
			m_lblTestInfoFormName.Text = "";
			m_lblTestRecordTime.Text = "";
			m_lblTestItemName.Text = "";
			m_lblTestTotalTimes.Text = "";
			m_lblTestCurrentTimes.Text = "";
			m_lblTestSucTimes.Text = "";
			m_lblTestFailTimes.Text = "";

			m_intTestTotalTimes = 0;
			m_intTestCurrentTimes = 0;
			m_intTestSucTimes = 0;
			m_intTestFailTimes = 0;
			m_intTestWaitMil = 10;


			m_lsvTestFailureInfo.Items.Clear();
		}

		private void m_cmdTestAddNew_Click(object sender, System.EventArgs e)
		{
			m_mthSetTestInfo(enmTestItem.AddNew);
		}

		private void m_cmdTestModify_Click(object sender, System.EventArgs e)
		{
			m_mthSetTestInfo(enmTestItem.Modify);
		}

		private void m_cmdTestDelete_Click(object sender, System.EventArgs e)
		{
			m_mthSetTestInfo(enmTestItem.Delete);		
		}

		private void m_cmdTestDisplay_Click(object sender, System.EventArgs e)
		{
			m_mthSetTestInfo(enmTestItem.Display);	
		}

		/// <summary>
		/// 设置测试信息
		/// </summary>
		/// <param name="p_enmTestItem">测试项目</param>
		private void m_mthSetTestInfo(enmTestItem p_enmTestItem)
		{
			if(m_objContentMaker == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择测试内容文件。");
				return;
			}

			m_mthClearTestInfo();

			m_enmTestItem = p_enmTestItem;

			m_objTester = (infAutoTest)m_lblFormText.Tag;
			m_frmTester = (Form)m_lblFormText.Tag;

			m_intTestTotalTimes = Decimal.ToInt32(m_nmuTestTimes.Value);
			m_intTestWaitMil = Decimal.ToInt32(m_nmuWaitMil.Value);

			m_strRecordTime = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");

			m_lblTestInfoFormText.Text = m_frmTester.Text;
			m_lblTestInfoFormName.Text = m_frmTester.Name;

			m_lblTestRecordTime.Text = m_strRecordTime;
			m_lblTestItemName.Text = m_enmTestItem.ToString();

			m_lblTestTotalTimes.Text = m_intTestTotalTimes.ToString();
			m_lblTestCurrentTimes.Text = "0";
			m_lblTestSucTimes.Text = "0";
			m_lblTestFailTimes.Text = "0";
			
			m_cmdStopTest.Enabled = true;
			m_cmdStartTest.Enabled = true;

			m_tabTest.SelectedIndex = 1;
		}

		private void m_cmdStopTest_Click(object sender, System.EventArgs e)
		{
			m_mthStopTest();

			m_mthCanRunTest(true);

			m_cmdStopTest.Enabled = false;
			m_cmdStartTest.Enabled = false;
		}

		/// <summary>
		/// 开始测试
		/// </summary>
		private void m_mthStartTest()
		{
			//由于线程下的控件使用有问题，故直接调用函数
//			if(m_thrRunningTest != null)
//				m_thrRunningTest.Abort();
//
//			m_thrRunningTest = new Thread(new ThreadStart(m_mthRunningTest));
//			m_thrRunningTest.Start();

			this.Cursor = Cursors.WaitCursor;
			m_mthRunningTest();
			this.Cursor = Cursors.Default;
		}

		/// <summary>
		/// 停止测试
		/// </summary>
		private void m_mthStopTest()
		{
			if(m_thrRunningTest != null)
			{
				m_thrRunningTest.Abort();
				m_thrRunningTest.Join(1000);

				m_thrRunningTest = null;
			}
		}

		/// <summary>
		/// 获取数据执行信息
		/// </summary>
		/// <param name="p_strLogFilePath"></param>
		/// <param name="p_strLogTime"></param>
		/// <returns></returns>
		private string m_strGetDBLog(string p_strLogFilePath,string p_strLogTime)
		{
			StreamReader objSR = new StreamReader(p_strLogFilePath);

			string strReslult = null;

			while(true)
			{
				strReslult = objSR.ReadLine();

				if(strReslult == null)
					break;

				if(strReslult.StartsWith("["+p_strLogTime+"] Function Called in"))
				{
					strReslult = strReslult +"\r\n"+ objSR.ReadToEnd();
					break;
				}
			}

			objSR.Close();

			return strReslult;
		}

		/// <summary>
		/// 执行测试
		/// </summary>
		private void m_mthRunningTest()
		{
			try
			{
				for(;m_intTestCurrentTimes <m_intTestTotalTimes;)
				{
					enmAutoTestResult enmResult = new enmAutoTestResult();
					string strInnerFailMessage = null;
					string strExp = null;

					string strTestTime = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
					string strDBLogTime = DateTime.Now.ToString();
						
					try
					{
						switch(m_enmTestItem)
						{
							case enmTestItem.AddNew:
								enmResult = m_objTester.i_enmTestAddNew(m_objContentMaker,out strInnerFailMessage);
								break;
							case enmTestItem.Modify:
								enmResult = m_objTester.i_enmTestModify(m_objContentMaker,out strInnerFailMessage);
								break;
							case enmTestItem.Delete:
								enmResult = m_objTester.i_enmTestDelete(m_objContentMaker,out strInnerFailMessage);
								break;
							case enmTestItem.Display:
								enmResult = m_objTester.i_enmTestDisplay(m_objContentMaker,out strInnerFailMessage);
								break;
						}
					}
					catch(Exception objExp)
					{
						enmResult = enmAutoTestResult.Failure;

						strExp = "Message : "+objExp.Message+"\r\nStackTrace : "+objExp.StackTrace;

						Exception objInnerExp = objExp.InnerException;
						while(objInnerExp != null)
						{							
							strExp += "InnerException : \r\nMessage : "+objInnerExp.Message+"\r\nStackTrace : "+objInnerExp.StackTrace;
						}
					}

					m_intTestCurrentTimes++;

					if(enmResult == enmAutoTestResult.Failure)
					{
						//处理失败信息
						m_intTestFailTimes++;
					
						string strAutoSetInfo = m_objContentMaker.m_strGetMakerLog();

						string strDBLog = m_strGetDBLog("d:\\code\\log.txt",strDBLogTime);
					
						string strFormControlValue = m_objContentMaker.m_strGetFormCurrentValue(m_frmTester);
						
						string strLogFileName = c_strLogDir+m_frmTester.Name+"\\"+m_enmTestItem.ToString()+"\\"+m_strRecordTime+"\\"+strTestTime+"_"+m_intTestFailTimes+".txt";

						if(strInnerFailMessage == null)
							strInnerFailMessage = "";

						m_objLog.Log2File(strLogFileName,
							"\r\n"+m_enmTestItem.ToString()+"(第"+m_intTestCurrentTimes+"次测试)"+"\r\n"
							+c_strAutoContent
							+strAutoSetInfo
							+c_strInnerFailMessage
							+strInnerFailMessage
							+c_strDBLog
							+strDBLog
							+c_strExceptionMessage
							+strExp
							+c_strFormValue
							+strFormControlValue,
							strTestTime);

						if(m_lsvTestFailureInfo.Items.Count >= 500)
							m_lsvTestFailureInfo.Items.Clear();

						ListViewItem lviFailInfo = new ListViewItem(
							new string[]{
											m_intTestFailTimes.ToString(),
											m_intTestCurrentTimes.ToString(),
											strTestTime,
											strInnerFailMessage,
											strLogFileName
										});
						m_lsvTestFailureInfo.Items.Add(lviFailInfo);
						m_lsvTestFailureInfo.Refresh();

						m_lblTestFailTimes.Text = m_intTestFailTimes.ToString();
						m_lblTestFailTimes.Refresh();
					}
					else
					{
						m_intTestSucTimes++;
						m_lblTestSucTimes.Text = m_intTestSucTimes.ToString();
						m_lblTestSucTimes.Refresh();
					}

					m_objContentMaker.m_mthClearMakerLog();

					m_lblTestCurrentTimes.Text = m_intTestCurrentTimes.ToString();
					m_lblTestCurrentTimes.Refresh();

					Thread.Sleep(m_intTestWaitMil);
				}
			}
			catch(ThreadAbortException)
			{
			}		

			m_mthCanRunTest(true);

			m_cmdStopTest.Enabled = false;		
			m_cmdStartTest.Enabled = false;
		}

		private void m_cmdGetTestContentFile_Click(object sender, System.EventArgs e)
		{
			if(m_ofdTestFile.ShowDialog() == DialogResult.OK)
			{
				m_objContentMaker = new clsTestContentMaker(m_ofdTestFile.FileName);
				m_lblTestFilePath.Text = m_ofdTestFile.FileName;
			}
		}

		private void m_lsvTestFailureInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvTestFailureInfo.SelectedItems.Count <= 0)
				return;

			string strLogFile = m_lsvTestFailureInfo.SelectedItems[0].SubItems[4].Text;

			Process objViewLog = new Process();
			objViewLog.StartInfo.FileName = strLogFile;
			objViewLog.Start();
			objViewLog.Close();
		}

		private void m_cmdStartTest_Click(object sender, System.EventArgs e)
		{
			m_mthCanRunTest(false);
			
			m_mthStartTest();
		}

		private void tbpTestFormSelect_Click(object sender, System.EventArgs e)
		{
			m_lsvRunningFormList.Focus();
		}

		/// <summary>
		/// 测试类型
		/// </summary>
		private enum enmTestItem
		{
			/// <summary>
			/// 新增
			/// </summary>
			AddNew,
			/// <summary>
			/// 修改
			/// </summary>
			Modify,
			/// <summary>
			/// 删除
			/// </summary>
			Delete,
			/// <summary>
			/// 显示（现不支持）
			/// </summary>
			Display
		}
	}
}
