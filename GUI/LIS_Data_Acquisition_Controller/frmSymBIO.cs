using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller
{
	/// <summary>
	/// frmSymBIO 的摘要说明。
	/// </summary>
	public class frmSymBIO : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region FromControls
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button m_btnAutoMatch;
		private System.Windows.Forms.Button m_btnCancelMatch;
		private System.Windows.Forms.Label m_lbDeviceSampleFrom;
		private System.Windows.Forms.Label m_lbDeviceSampleTo;
		private System.Windows.Forms.TextBox m_txtDeviceSampleFrom;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnTranslate;
		private System.Windows.Forms.TextBox m_txtDeviceSampleTo;
		private System.Windows.Forms.Label m_lbSampleSeq;
		private System.Windows.Forms.TextBox m_txtSampleSeqFrom;
		private System.Windows.Forms.Label m_lbSampleSeqTo;
		private System.Windows.Forms.TextBox m_txtSampleSeqTo;
		private System.Windows.Forms.GroupBox m_gpbInfo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtDeviceSampleIDTo;
		private System.Windows.Forms.TextBox m_txtDeviceSampleIDFrom;
		private System.Windows.Forms.Label m_lbDeviceRange;
		private System.Windows.Forms.ComboBox m_cboCheckItem;
		private System.Windows.Forms.Label m_lbCheckItem;
		private System.Windows.Forms.ListView m_lsvMatchedItemArr;
		private System.Windows.Forms.ColumnHeader m_chDeviceSample;
		private System.Windows.Forms.Label m_lbDatRange;
		private System.Windows.Forms.DateTimePicker m_dtpDatFrom;
		private System.Windows.Forms.Button m_btnQuery;
		private string m_strAnalysisDll;
		private System.Windows.Forms.Button m_btnSetDeviceSampleIDRange;
		private System.Windows.Forms.ListView m_lsvFileList;
		private System.Windows.Forms.ColumnHeader m_chFileName;
		private System.Windows.Forms.Label m_lbResultCount;
		private System.Windows.Forms.TextBox m_txtResultCount;
		private System.Windows.Forms.GroupBox groupBox2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSymBIO(string p_strAnalysisDll)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_strAnalysisDll = p_strAnalysisDll;
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

		#endregion

		#region ItemArr
		ArrayList[] m_arlItemArr;
		string[] m_strFilePathArr;
		clsFileInfo_VO[] m_objFileInfoArr;
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btnAutoMatch = new System.Windows.Forms.Button();
			this.m_btnCancelMatch = new System.Windows.Forms.Button();
			this.m_lbDeviceSampleTo = new System.Windows.Forms.Label();
			this.m_txtDeviceSampleFrom = new System.Windows.Forms.TextBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnTranslate = new System.Windows.Forms.Button();
			this.m_txtDeviceSampleTo = new System.Windows.Forms.TextBox();
			this.m_txtSampleSeqFrom = new System.Windows.Forms.TextBox();
			this.m_lbSampleSeqTo = new System.Windows.Forms.Label();
			this.m_txtSampleSeqTo = new System.Windows.Forms.TextBox();
			this.m_lbDeviceSampleFrom = new System.Windows.Forms.Label();
			this.m_lbSampleSeq = new System.Windows.Forms.Label();
			this.m_gpbInfo = new System.Windows.Forms.GroupBox();
			this.m_txtResultCount = new System.Windows.Forms.TextBox();
			this.m_lbResultCount = new System.Windows.Forms.Label();
			this.m_btnSetDeviceSampleIDRange = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtDeviceSampleIDTo = new System.Windows.Forms.TextBox();
			this.m_txtDeviceSampleIDFrom = new System.Windows.Forms.TextBox();
			this.m_lbDeviceRange = new System.Windows.Forms.Label();
			this.m_cboCheckItem = new System.Windows.Forms.ComboBox();
			this.m_lbCheckItem = new System.Windows.Forms.Label();
			this.m_btnQuery = new System.Windows.Forms.Button();
			this.m_dtpDatFrom = new System.Windows.Forms.DateTimePicker();
			this.m_lbDatRange = new System.Windows.Forms.Label();
			this.m_lsvMatchedItemArr = new System.Windows.Forms.ListView();
			this.m_chDeviceSample = new System.Windows.Forms.ColumnHeader();
			this.m_lsvFileList = new System.Windows.Forms.ListView();
			this.m_chFileName = new System.Windows.Forms.ColumnHeader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.m_gpbInfo.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_btnAutoMatch);
			this.groupBox1.Controls.Add(this.m_btnCancelMatch);
			this.groupBox1.Controls.Add(this.m_lbDeviceSampleTo);
			this.groupBox1.Controls.Add(this.m_txtDeviceSampleFrom);
			this.groupBox1.Controls.Add(this.m_btnOK);
			this.groupBox1.Controls.Add(this.m_btnTranslate);
			this.groupBox1.Controls.Add(this.m_txtDeviceSampleTo);
			this.groupBox1.Controls.Add(this.m_txtSampleSeqFrom);
			this.groupBox1.Controls.Add(this.m_lbSampleSeqTo);
			this.groupBox1.Controls.Add(this.m_txtSampleSeqTo);
			this.groupBox1.Controls.Add(this.m_lbDeviceSampleFrom);
			this.groupBox1.Controls.Add(this.m_lbSampleSeq);
			this.groupBox1.Location = new System.Drawing.Point(0, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(556, 76);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "关系对应";
			// 
			// m_btnAutoMatch
			// 
			this.m_btnAutoMatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnAutoMatch.Location = new System.Drawing.Point(468, 20);
			this.m_btnAutoMatch.Name = "m_btnAutoMatch";
			this.m_btnAutoMatch.Size = new System.Drawing.Size(76, 24);
			this.m_btnAutoMatch.TabIndex = 16;
			this.m_btnAutoMatch.Text = "自动对应";
			this.m_btnAutoMatch.Click += new System.EventHandler(this.m_btnAutoMatch_Click);
			// 
			// m_btnCancelMatch
			// 
			this.m_btnCancelMatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnCancelMatch.Location = new System.Drawing.Point(384, 48);
			this.m_btnCancelMatch.Name = "m_btnCancelMatch";
			this.m_btnCancelMatch.Size = new System.Drawing.Size(76, 24);
			this.m_btnCancelMatch.TabIndex = 15;
			this.m_btnCancelMatch.Text = "取消对应";
			this.m_btnCancelMatch.Click += new System.EventHandler(this.m_btnCancelMatch_Click);
			// 
			// m_lbDeviceSampleTo
			// 
			this.m_lbDeviceSampleTo.AutoSize = true;
			this.m_lbDeviceSampleTo.Location = new System.Drawing.Point(224, 24);
			this.m_lbDeviceSampleTo.Name = "m_lbDeviceSampleTo";
			this.m_lbDeviceSampleTo.Size = new System.Drawing.Size(20, 19);
			this.m_lbDeviceSampleTo.TabIndex = 7;
			this.m_lbDeviceSampleTo.Text = "至";
			// 
			// m_txtDeviceSampleFrom
			// 
			this.m_txtDeviceSampleFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.m_txtDeviceSampleFrom.Location = new System.Drawing.Point(88, 20);
			this.m_txtDeviceSampleFrom.Name = "m_txtDeviceSampleFrom";
			this.m_txtDeviceSampleFrom.Size = new System.Drawing.Size(132, 23);
			this.m_txtDeviceSampleFrom.TabIndex = 6;
			this.m_txtDeviceSampleFrom.Text = "";
			this.m_txtDeviceSampleFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleIDFrom_KeyPress);
			// 
			// m_btnOK
			// 
			this.m_btnOK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnOK.Location = new System.Drawing.Point(384, 20);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(76, 24);
			this.m_btnOK.TabIndex = 13;
			this.m_btnOK.Text = "确定";
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// m_btnTranslate
			// 
			this.m_btnTranslate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnTranslate.Location = new System.Drawing.Point(468, 48);
			this.m_btnTranslate.Name = "m_btnTranslate";
			this.m_btnTranslate.Size = new System.Drawing.Size(76, 24);
			this.m_btnTranslate.TabIndex = 14;
			this.m_btnTranslate.Text = "数据转换";
			this.m_btnTranslate.Click += new System.EventHandler(this.m_btnTranslate_Click);
			// 
			// m_txtDeviceSampleTo
			// 
			this.m_txtDeviceSampleTo.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtDeviceSampleTo.Location = new System.Drawing.Point(248, 20);
			this.m_txtDeviceSampleTo.Name = "m_txtDeviceSampleTo";
			this.m_txtDeviceSampleTo.Size = new System.Drawing.Size(132, 23);
			this.m_txtDeviceSampleTo.TabIndex = 8;
			this.m_txtDeviceSampleTo.Text = "";
			this.m_txtDeviceSampleTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleIDFrom_KeyPress);
			// 
			// m_txtSampleSeqFrom
			// 
			this.m_txtSampleSeqFrom.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtSampleSeqFrom.Location = new System.Drawing.Point(88, 44);
			this.m_txtSampleSeqFrom.Name = "m_txtSampleSeqFrom";
			this.m_txtSampleSeqFrom.Size = new System.Drawing.Size(132, 23);
			this.m_txtSampleSeqFrom.TabIndex = 10;
			this.m_txtSampleSeqFrom.Text = "";
			this.m_txtSampleSeqFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleIDFrom_KeyPress);
			// 
			// m_lbSampleSeqTo
			// 
			this.m_lbSampleSeqTo.AutoSize = true;
			this.m_lbSampleSeqTo.Location = new System.Drawing.Point(224, 48);
			this.m_lbSampleSeqTo.Name = "m_lbSampleSeqTo";
			this.m_lbSampleSeqTo.Size = new System.Drawing.Size(20, 19);
			this.m_lbSampleSeqTo.TabIndex = 11;
			this.m_lbSampleSeqTo.Text = "至";
			// 
			// m_txtSampleSeqTo
			// 
			this.m_txtSampleSeqTo.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtSampleSeqTo.Location = new System.Drawing.Point(248, 44);
			this.m_txtSampleSeqTo.Name = "m_txtSampleSeqTo";
			this.m_txtSampleSeqTo.Size = new System.Drawing.Size(132, 23);
			this.m_txtSampleSeqTo.TabIndex = 12;
			this.m_txtSampleSeqTo.Text = "";
			this.m_txtSampleSeqTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleIDFrom_KeyPress);
			// 
			// m_lbDeviceSampleFrom
			// 
			this.m_lbDeviceSampleFrom.AutoSize = true;
			this.m_lbDeviceSampleFrom.Location = new System.Drawing.Point(28, 24);
			this.m_lbDeviceSampleFrom.Name = "m_lbDeviceSampleFrom";
			this.m_lbDeviceSampleFrom.Size = new System.Drawing.Size(63, 19);
			this.m_lbDeviceSampleFrom.TabIndex = 5;
			this.m_lbDeviceSampleFrom.Text = "样本号：";
			// 
			// m_lbSampleSeq
			// 
			this.m_lbSampleSeq.AutoSize = true;
			this.m_lbSampleSeq.Location = new System.Drawing.Point(16, 48);
			this.m_lbSampleSeq.Name = "m_lbSampleSeq";
			this.m_lbSampleSeq.Size = new System.Drawing.Size(77, 19);
			this.m_lbSampleSeq.TabIndex = 9;
			this.m_lbSampleSeq.Text = "结果序号：";
			// 
			// m_gpbInfo
			// 
			this.m_gpbInfo.Controls.Add(this.m_txtResultCount);
			this.m_gpbInfo.Controls.Add(this.m_lbResultCount);
			this.m_gpbInfo.Controls.Add(this.m_btnSetDeviceSampleIDRange);
			this.m_gpbInfo.Controls.Add(this.label2);
			this.m_gpbInfo.Controls.Add(this.m_txtDeviceSampleIDTo);
			this.m_gpbInfo.Controls.Add(this.m_txtDeviceSampleIDFrom);
			this.m_gpbInfo.Controls.Add(this.m_lbDeviceRange);
			this.m_gpbInfo.Controls.Add(this.m_cboCheckItem);
			this.m_gpbInfo.Controls.Add(this.m_lbCheckItem);
			this.m_gpbInfo.Location = new System.Drawing.Point(0, 4);
			this.m_gpbInfo.Name = "m_gpbInfo";
			this.m_gpbInfo.Size = new System.Drawing.Size(556, 72);
			this.m_gpbInfo.TabIndex = 18;
			this.m_gpbInfo.TabStop = false;
			this.m_gpbInfo.Text = "基本信息";
			// 
			// m_txtResultCount
			// 
			this.m_txtResultCount.BackColor = System.Drawing.SystemColors.Info;
			this.m_txtResultCount.ForeColor = System.Drawing.Color.Red;
			this.m_txtResultCount.Location = new System.Drawing.Point(288, 16);
			this.m_txtResultCount.Name = "m_txtResultCount";
			this.m_txtResultCount.ReadOnly = true;
			this.m_txtResultCount.Size = new System.Drawing.Size(92, 23);
			this.m_txtResultCount.TabIndex = 28;
			this.m_txtResultCount.Text = "";
			// 
			// m_lbResultCount
			// 
			this.m_lbResultCount.AutoSize = true;
			this.m_lbResultCount.Location = new System.Drawing.Point(224, 20);
			this.m_lbResultCount.Name = "m_lbResultCount";
			this.m_lbResultCount.Size = new System.Drawing.Size(77, 19);
			this.m_lbResultCount.TabIndex = 27;
			this.m_lbResultCount.Text = "结果数量：";
			// 
			// m_btnSetDeviceSampleIDRange
			// 
			this.m_btnSetDeviceSampleIDRange.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnSetDeviceSampleIDRange.Location = new System.Drawing.Point(384, 44);
			this.m_btnSetDeviceSampleIDRange.Name = "m_btnSetDeviceSampleIDRange";
			this.m_btnSetDeviceSampleIDRange.Size = new System.Drawing.Size(76, 24);
			this.m_btnSetDeviceSampleIDRange.TabIndex = 5;
			this.m_btnSetDeviceSampleIDRange.Text = "确定";
			this.m_btnSetDeviceSampleIDRange.Click += new System.EventHandler(this.m_btnSetDeviceSampleIDRange_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(224, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 19);
			this.label2.TabIndex = 17;
			this.label2.Text = "至";
			// 
			// m_txtDeviceSampleIDTo
			// 
			this.m_txtDeviceSampleIDTo.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtDeviceSampleIDTo.Location = new System.Drawing.Point(248, 44);
			this.m_txtDeviceSampleIDTo.Name = "m_txtDeviceSampleIDTo";
			this.m_txtDeviceSampleIDTo.Size = new System.Drawing.Size(132, 23);
			this.m_txtDeviceSampleIDTo.TabIndex = 4;
			this.m_txtDeviceSampleIDTo.Text = "";
			this.m_txtDeviceSampleIDTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleIDFrom_KeyPress);
			// 
			// m_txtDeviceSampleIDFrom
			// 
			this.m_txtDeviceSampleIDFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.m_txtDeviceSampleIDFrom.Location = new System.Drawing.Point(88, 44);
			this.m_txtDeviceSampleIDFrom.Name = "m_txtDeviceSampleIDFrom";
			this.m_txtDeviceSampleIDFrom.Size = new System.Drawing.Size(132, 23);
			this.m_txtDeviceSampleIDFrom.TabIndex = 3;
			this.m_txtDeviceSampleIDFrom.Text = "";
			this.m_txtDeviceSampleIDFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleIDFrom_KeyPress);
			// 
			// m_lbDeviceRange
			// 
			this.m_lbDeviceRange.AutoSize = true;
			this.m_lbDeviceRange.Location = new System.Drawing.Point(4, 48);
			this.m_lbDeviceRange.Name = "m_lbDeviceRange";
			this.m_lbDeviceRange.Size = new System.Drawing.Size(92, 19);
			this.m_lbDeviceRange.TabIndex = 15;
			this.m_lbDeviceRange.Text = "样本号范围：";
			// 
			// m_cboCheckItem
			// 
			this.m_cboCheckItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCheckItem.Items.AddRange(new object[] {
																"HBSAG",
																"HBSAB",
																"HBEAG",
																"HBEAB",
																"HBCAB"});
			this.m_cboCheckItem.Location = new System.Drawing.Point(88, 16);
			this.m_cboCheckItem.Name = "m_cboCheckItem";
			this.m_cboCheckItem.Size = new System.Drawing.Size(132, 22);
			this.m_cboCheckItem.TabIndex = 1;
			this.m_cboCheckItem.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckItem_SelectedIndexChanged);
			// 
			// m_lbCheckItem
			// 
			this.m_lbCheckItem.AutoSize = true;
			this.m_lbCheckItem.Location = new System.Drawing.Point(16, 20);
			this.m_lbCheckItem.Name = "m_lbCheckItem";
			this.m_lbCheckItem.Size = new System.Drawing.Size(77, 19);
			this.m_lbCheckItem.TabIndex = 3;
			this.m_lbCheckItem.Text = "检验项目：";
			// 
			// m_btnQuery
			// 
			this.m_btnQuery.Font = new System.Drawing.Font("宋体", 9F);
			this.m_btnQuery.Location = new System.Drawing.Point(180, 16);
			this.m_btnQuery.Name = "m_btnQuery";
			this.m_btnQuery.Size = new System.Drawing.Size(68, 24);
			this.m_btnQuery.TabIndex = 26;
			this.m_btnQuery.Text = "查询";
			this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
			// 
			// m_dtpDatFrom
			// 
			this.m_dtpDatFrom.Location = new System.Drawing.Point(48, 16);
			this.m_dtpDatFrom.Name = "m_dtpDatFrom";
			this.m_dtpDatFrom.Size = new System.Drawing.Size(120, 23);
			this.m_dtpDatFrom.TabIndex = 23;
			// 
			// m_lbDatRange
			// 
			this.m_lbDatRange.AutoSize = true;
			this.m_lbDatRange.Location = new System.Drawing.Point(4, 20);
			this.m_lbDatRange.Name = "m_lbDatRange";
			this.m_lbDatRange.Size = new System.Drawing.Size(48, 19);
			this.m_lbDatRange.TabIndex = 22;
			this.m_lbDatRange.Text = "日期：";
			// 
			// m_lsvMatchedItemArr
			// 
			this.m_lsvMatchedItemArr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lsvMatchedItemArr.BackColor = System.Drawing.Color.LightSteelBlue;
			this.m_lsvMatchedItemArr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.m_chDeviceSample});
			this.m_lsvMatchedItemArr.FullRowSelect = true;
			this.m_lsvMatchedItemArr.GridLines = true;
			this.m_lsvMatchedItemArr.HideSelection = false;
			this.m_lsvMatchedItemArr.Location = new System.Drawing.Point(0, 160);
			this.m_lsvMatchedItemArr.MultiSelect = false;
			this.m_lsvMatchedItemArr.Name = "m_lsvMatchedItemArr";
			this.m_lsvMatchedItemArr.Size = new System.Drawing.Size(812, 548);
			this.m_lsvMatchedItemArr.TabIndex = 17;
			this.m_lsvMatchedItemArr.View = System.Windows.Forms.View.Details;
			// 
			// m_chDeviceSample
			// 
			this.m_chDeviceSample.Text = "仪器标本号";
			this.m_chDeviceSample.Width = 91;
			// 
			// m_lsvFileList
			// 
			this.m_lsvFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.m_chFileName});
			this.m_lsvFileList.FullRowSelect = true;
			this.m_lsvFileList.GridLines = true;
			this.m_lsvFileList.Location = new System.Drawing.Point(4, 44);
			this.m_lsvFileList.MultiSelect = false;
			this.m_lsvFileList.Name = "m_lsvFileList";
			this.m_lsvFileList.Size = new System.Drawing.Size(244, 104);
			this.m_lsvFileList.TabIndex = 20;
			this.m_lsvFileList.View = System.Windows.Forms.View.Details;
			this.m_lsvFileList.DoubleClick += new System.EventHandler(this.m_lsvFileList_DoubleClick);
			// 
			// m_chFileName
			// 
			this.m_chFileName.Text = "文件名";
			this.m_chFileName.Width = 230;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.m_dtpDatFrom);
			this.groupBox2.Controls.Add(this.m_lbDatRange);
			this.groupBox2.Controls.Add(this.m_lsvFileList);
			this.groupBox2.Controls.Add(this.m_btnQuery);
			this.groupBox2.Location = new System.Drawing.Point(556, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(256, 152);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			// 
			// frmSymBIO
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(812, 709);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.m_gpbInfo);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_lsvMatchedItemArr);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.Name = "frmSymBIO";
			this.Text = "";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSymBIO_KeyDown);
			this.Load += new System.EventHandler(this.frmSymBIO_Load);
			this.groupBox1.ResumeLayout(false);
			this.m_gpbInfo.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 时间转换函数
		public void m_mthTanslateCheckDat(ref string p_strCheckDat)
		{
			try
			{
				p_strCheckDat = p_strCheckDat.Replace("Jan","01");
				p_strCheckDat = p_strCheckDat.Replace("Feb","02");
				p_strCheckDat = p_strCheckDat.Replace("Mar","03");
				p_strCheckDat = p_strCheckDat.Replace("Apr","04");
				p_strCheckDat = p_strCheckDat.Replace("May","05");
				p_strCheckDat = p_strCheckDat.Replace("Jun","06");
				p_strCheckDat = p_strCheckDat.Replace("Jul","07");
				p_strCheckDat = p_strCheckDat.Replace("Aug","08");
				p_strCheckDat = p_strCheckDat.Replace("Sep","09");
				p_strCheckDat = p_strCheckDat.Replace("Oct","10");
				p_strCheckDat = p_strCheckDat.Replace("Nov","11");
				p_strCheckDat = p_strCheckDat.Replace("Dec","12");
				p_strCheckDat = DateTime.Parse(p_strCheckDat).ToString("yyyy-MM-dd").Trim();
			}
			catch
			{
			}
		}
		#endregion

		#region 将项目的结果信息加入到文件
		public void m_mthAddItemToFile(string p_strItemDetail)
		{
			string strPath = System.AppDomain.CurrentDomain.BaseDirectory;
			string strFileName = "";
			strFileName = strPath + "SymBIOResult.txt";
			StreamWriter sw;
			if(!File.Exists(strFileName))
			{
				sw = File.CreateText(strFileName);
				sw.WriteLine(p_strItemDetail);
			}
			else
			{
				FileInfo FI = new FileInfo(strFileName);
				sw = FI.AppendText();
				sw.WriteLine(p_strItemDetail);
			}
			sw.Close();
		}
		#endregion

		#region 获取默认路径
		public string m_mthGetDefaultPath(string p_strNode,string p_strKeyVal)
		{
			string p_strFilePath;
			try
			{
				string strPath = "";
				strPath = System.AppDomain.CurrentDomain.BaseDirectory + m_strAnalysisDll.Split(new char[]{'.'})[0] + ".config";
				System.Configuration.ConfigXmlDocument defaultPathConfig = new System.Configuration.ConfigXmlDocument();
				defaultPathConfig.Load(strPath);
				p_strFilePath = defaultPathConfig["configuration"][p_strNode].SelectSingleNode("add[@key=\""+p_strKeyVal+"\"]").Attributes["value"].Value;
			}
			catch
			{
				p_strFilePath = null;
			}
			return p_strFilePath;
		}
		#endregion

		#region 加载文件构造项目VO数组
		public void m_mthConstructFileCheckItemArr(string m_strPath,ref ArrayList p_arlItemVO)
		{
			p_arlItemVO.Clear();
			StreamReader sr = new StreamReader(m_strPath);
			string strLine = "";
			int count=0;
			string strCheckItemName = "";
			string strCheckDat = "";
			DateTime dtLastWriteDat = File.GetLastWriteTime(m_strPath);
			while((strLine = sr.ReadLine()) != null)
			{
				if(strLine.Trim() != "")
				{
					if(count == 0)
					{
						int intItemCount = 0;
						string[] strLineArr = strLine.Split(new char[]{' '});
						for(int i=0;i<strLineArr.Length;i++)
						{
							if(strLineArr[i] != "")
							{
								if(intItemCount == 1)
								{
									strCheckItemName = strLineArr[i].Trim();
								}
								else if(intItemCount == 3)
								{
									strCheckDat = strLineArr[i].Split(new char[]{'.'})[0].Trim();
									m_mthTanslateCheckDat(ref strCheckDat);
									if(strCheckDat != null && strCheckDat != "")
									{
										strCheckDat = strCheckDat +" "+dtLastWriteDat.ToShortTimeString();
									}
									else
									{
										strCheckDat = dtLastWriteDat.ToString().Trim();
									}
								}
								intItemCount++;
							}
						}
					}
					else if(count > 2)
					{
						clsFileCheckItem_VO objVO = new clsFileCheckItem_VO();
						string strSeq = "";
						string strResult = "";
						int intItemCount = 0;
						string[] strLineArr = strLine.Split(new char[]{' '});
						for(int i=0;i<strLineArr.Length;i++)
						{
							if(strLineArr[i] != "")
							{
								if(intItemCount == 0)
								{
									strSeq = strLineArr[i].Trim();
								}
								if(intItemCount == 3)
								{
									strResult = strLineArr[i].Trim();
								}
								intItemCount++;
							}
						}
						objVO.m_strSeq = strSeq;
						objVO.m_strCheckItemName = strCheckItemName;
						objVO.m_strCheckDat = strCheckDat;
						objVO.m_strResult = strResult;
						p_arlItemVO.Add(objVO);
					}
				}
				count++;
			}
		}
		#endregion

		#region 数据转换
		private void m_btnTranslate_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.m_lsvMatchedItemArr.Items.Count <= 0)
				{
					MessageBox.Show("无可转换的数据");
					return;
				}
				m_mthTranslateDeviceData();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch
			{
				MessageBox.Show(this,"数据转换失败！","iCare 数据采集");
			}
		}

		#region 转换仪器设备数据
		public void m_mthTranslateDeviceData()
		{
			for(int i=0;i<this.m_lsvMatchedItemArr.Items.Count;i++)
			{
				string strAllResult = "";
				string strDeviceSampleID = this.m_lsvMatchedItemArr.Items[i].SubItems[0].Text.ToString().Trim();
				for(int j=1;j<this.m_lsvMatchedItemArr.Columns.Count;j++)
				{
					if(this.m_lsvMatchedItemArr.Items[i].SubItems[j].Text.ToString().Trim() != "")
					{
						clsFileCheckItem_VO objVO = 
							(clsFileCheckItem_VO)(this.m_arlItemArr[j-1][int.Parse(this.m_lsvMatchedItemArr.Items[i].SubItems[j].Text.ToString().Trim())-1]);
						objVO.m_strDeviceSampleNO = strDeviceSampleID;
						objVO.m_strTanslateToFileResult = objVO.m_strDeviceSampleNO+ "$" +objVO.m_strCheckItemName+ "$" 
							+objVO.m_strCheckDat+ "$" +objVO.m_strResult;
						strAllResult += objVO.m_strTanslateToFileResult;
						if(j<this.m_lsvMatchedItemArr.Columns.Count-1)
						{
							strAllResult += "|";
						}
					}
				}
				//将一个仪器样本号的所有结果写入文件
				if(i<this.m_lsvMatchedItemArr.Items.Count-1)
				{
					strAllResult += "@";
				}
				m_mthAddItemToFile(strAllResult);
			}
		}
		#endregion
		#endregion

		#region 下拉列表事件
		private void m_cboCheckItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.m_lsvFileList.Items.Clear();
			if(m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count == 0)
			{
				string strDefaultPath = m_mthGetDefaultPath("defaultPathSettings",this.m_cboCheckItem.Text.ToString().Trim());
				if(strDefaultPath != null && strDefaultPath != "")
				{
					string strFilePath = m_mthGetLatestFile(strDefaultPath);
					if(strFilePath != null && strFilePath != "")
					{
						clsFileInfo_VO objVO = m_clsGetFileInfoByPath(strFilePath);
						m_objFileInfoArr[this.m_cboCheckItem.SelectedIndex] = objVO;
						m_mthConstructFileCheckItemArr(strFilePath,ref m_arlItemArr[this.m_cboCheckItem.SelectedIndex]);
						m_strFilePathArr[this.m_cboCheckItem.SelectedIndex] = strFilePath;
						this.m_txtResultCount.Text = m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
						if(this.m_lsvMatchedItemArr.Items.Count > 0)
						{
							this.m_txtDeviceSampleFrom.Focus();
						}
						else
						{
							this.m_txtDeviceSampleIDFrom.Focus();
						}
					}
					else
					{
						MessageBox.Show("请选择仪器结果文件！");
						return;
					}
				}
				else
				{
					MessageBox.Show("请选择仪器结果文件！");
					return;
				}
			}
			else
			{
				this.m_txtResultCount.Text = m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
			}
			ListViewItem lsvItem = new ListViewItem();
			lsvItem.Text = m_objFileInfoArr[this.m_cboCheckItem.SelectedIndex].m_strFileName;
			lsvItem.Tag = this.m_objFileInfoArr[m_cboCheckItem.SelectedIndex];
			this.m_lsvFileList.Items.Add(lsvItem);
			this.m_dtpDatFrom.Value = DateTime.Parse(this.m_objFileInfoArr[m_cboCheckItem.SelectedIndex].m_strFileLastWriteTime);
		}
		#endregion

		#region 获取最新文件
		public string m_mthGetLatestFile(string p_strDirectory)
		{
			string strFilePath = null;
			try
			{
				if(!Directory.Exists(p_strDirectory))
				{
					MessageBox.Show("不存在目录"+p_strDirectory+"！");
					return null;
				}
				string[] strFilesArr = Directory.GetFileSystemEntries(p_strDirectory,"*.ra");
				DateTime dtLastModify = new DateTime(1,1,1);
				for(int i=0;i<strFilesArr.Length;i++)
				{
					FileInfo FI = new FileInfo(strFilesArr[i]);
					if(i==0)
					{
						dtLastModify = FI.LastWriteTime;
						strFilePath = strFilesArr[i];
					}
					else
					{
						if(dtLastModify < FI.LastWriteTime)
						{
							dtLastModify = FI.LastWriteTime;
							strFilePath = strFilesArr[i];
						}
					}
				}
			}
			catch(Exception objEx)
			{
				MessageBox.Show(objEx.Message);
			}
			return strFilePath;
		}
		#endregion

		#region 控制只能输入数字和回退键
		private void m_txtDeviceSampleIDFrom_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if((e.KeyChar < (char)48 || e.KeyChar > (char)57) && e.KeyChar != (char)8)
				e.Handled = true;
		}
		#endregion

		#region 设置仪器样本号范围
		public void m_mthSetDeviceSampleIDRange()
		{
			if(this.m_txtDeviceSampleIDFrom.Text.ToString().Trim() == "" || this.m_txtDeviceSampleIDTo.Text.ToString().Trim() == "")
			{
				MessageBox.Show("请输入完整的起始和结束仪器标本号！");
				return;
			}
			this.m_lsvMatchedItemArr.Items.Clear();
			int intDeviceSampleIDFrom = int.Parse(this.m_txtDeviceSampleIDFrom.Text.ToString().Trim());
			int intDeviceSampleIDTo = int .Parse(this.m_txtDeviceSampleIDTo.Text.ToString().Trim());
			int intSampleCount = intDeviceSampleIDTo - intDeviceSampleIDFrom+1;
			if(intSampleCount <= 0)
			{
				MessageBox.Show("结束仪器标本号应大于起始仪器标本号！");
				return;
			}

			bool blnStartWithZero = false;
			string strDeviceSampleFrom = this.m_txtDeviceSampleIDFrom.Text.ToString().Trim();

			if(strDeviceSampleFrom.StartsWith("0"))
			{
				blnStartWithZero = true;
			}
			for(int i=0;i<intSampleCount;i++)
			{
				ListViewItem objlsvItem = new ListViewItem();
				if(blnStartWithZero)
				{
					objlsvItem.Text = 
						((int)(intDeviceSampleIDFrom+i)).ToString().Trim().PadLeft(strDeviceSampleFrom.Length,'0');
				}
				else
				{
					objlsvItem.Text = ((int)(i+intDeviceSampleIDFrom)).ToString().Trim();
				}
				for(int j=0;j<this.m_lsvMatchedItemArr.Columns.Count;j++)
				{
					objlsvItem.SubItems.Add("");
				}
				this.m_lsvMatchedItemArr.Items.Add(objlsvItem);
			}
		}

		private void m_btnSetDeviceSampleIDRange_Click(object sender, System.EventArgs e)
		{
			m_mthSetDeviceSampleIDRange();
		}
		#endregion

		#region 取消对应
		private void m_btnCancelMatch_Click(object sender, System.EventArgs e)
		{
			m_mthCancelMatch();
		}

		public void m_mthCancelMatch()
		{
			for(int i=0;i<this.m_lsvMatchedItemArr.Items.Count;i++)
			{
				this.m_lsvMatchedItemArr.Items[i].SubItems[this.m_cboCheckItem.SelectedIndex+1].Text = "";
			}
			this.m_txtDeviceSampleFrom.Clear();
			this.m_txtDeviceSampleTo.Clear();
			this.m_txtSampleSeqFrom.Clear();
			this.m_txtSampleSeqTo.Clear();
		}
		#endregion

		#region 自动对应
		public void m_mthAutoMatch()
		{
			if(this.m_lsvMatchedItemArr.Items.Count <= 0)
			{
				MessageBox.Show("请输入仪器标本号范围！");
				return;
			}
			for(int i=0;i<this.m_cboCheckItem.Items.Count;i++)
			{
				m_arlItemArr[i].Clear();
					string strDefaultPath = m_mthGetDefaultPath("defaultPathSettings",this.m_cboCheckItem.Items[i].ToString().Trim());
				if(strDefaultPath != null && strDefaultPath != "")
				{
					string strFilePath = m_mthGetLatestFile(strDefaultPath);
					if(strFilePath != null && strFilePath != "")
					{
						m_mthConstructFileCheckItemArr(strFilePath,ref m_arlItemArr[i]);
						m_strFilePathArr[i] = strFilePath;
					}
					else
					{
						continue;
					}
				}
				else
				{
					continue;
				}
			}
			for(int i=0;i<this.m_lsvMatchedItemArr.Items.Count;i++)
			{
				for(int j=0;j<this.m_arlItemArr.Length;j++)
				{
					this.m_lsvMatchedItemArr.Items[i].SubItems[j+1].Text = "";
					if(m_arlItemArr[j].Count > 0 && m_arlItemArr[j].Count >= i+1)
					{
						this.m_lsvMatchedItemArr.Items[i].SubItems[j+1].Text = ((int)(i+1)).ToString().Trim();
					}
				}
			}
			this.m_lsvFileList.Items.Clear();
			this.m_txtResultCount.Text = this.m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
			ListViewItem lsvItem = new ListViewItem();
			lsvItem.Text = m_objFileInfoArr[this.m_cboCheckItem.SelectedIndex].m_strFileName;
			lsvItem.Tag = this.m_objFileInfoArr[m_cboCheckItem.SelectedIndex];
			this.m_lsvFileList.Items.Add(lsvItem);
			this.m_dtpDatFrom.Value = DateTime.Parse(this.m_objFileInfoArr[m_cboCheckItem.SelectedIndex].m_strFileLastWriteTime);
		}

		private void m_btnAutoMatch_Click(object sender, System.EventArgs e)
		{
			m_mthAutoMatch();
		}
		#endregion

		#region 对应仪器关系
		public void m_mthMatchSampleRelation()
		{
//			if(this.m_txtResultCount.Text.ToString().Trim() == "")
//			{
//				MessageBox.Show("请导入仪器结果数据！");
//				return;
//			}
			if(this.m_txtDeviceSampleFrom.Text.ToString().Trim() == "" || this.m_txtDeviceSampleTo.Text.ToString().Trim() == ""
				|| this.m_txtSampleSeqFrom.Text.ToString().Trim() == "" || this.m_txtSampleSeqTo.Text.ToString().Trim() == "")
			{
				MessageBox.Show("请输入完整的起始和结束标本号及序号！");
				return;
			}
			if(this.m_lsvMatchedItemArr.Items.Count <= 0)
			{
				MessageBox.Show("请输入仪器标本范围！");
				return;
			}
			if(int.Parse(this.m_txtSampleSeqFrom.Text.ToString().Trim()) > m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count
				|| int.Parse(this.m_txtSampleSeqFrom.Text.ToString().Trim()) <= 0)
			{
				MessageBox.Show("序号应该小于或等于标本的个数且大于零");
				this.m_txtSampleSeqFrom.Focus();
				return;
			}
			if(int.Parse(this.m_txtSampleSeqTo.Text.ToString().Trim()) > m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count
				|| int.Parse(this.m_txtSampleSeqTo.Text.ToString().Trim()) <= 0)
			{
				MessageBox.Show("序号应该小于或等于标本的个数且大于零");
				this.m_txtSampleSeqTo.Focus();
				return;
			}
			int intDeviceSampleFrom = int.Parse(this.m_txtDeviceSampleFrom.Text.ToString().Trim());
			int intDeviceSampleTo = int.Parse(this.m_txtDeviceSampleTo.Text.ToString().Trim());
			int intSeqFrom = int.Parse(this.m_txtSampleSeqFrom.Text.ToString().Trim());
			int intSeqTo = int .Parse(this.m_txtSampleSeqTo.Text.ToString().Trim());
			int intDeviceSampleCount = intDeviceSampleTo-intDeviceSampleFrom+1;
			int intSeqCount = intSeqTo-intSeqFrom+1;

			if(intSeqCount != intDeviceSampleCount)
			{
				MessageBox.Show("仪器样本号与样本序号的数量不一致！");
				return;
			}

			for(int l=0;l<this.m_lsvMatchedItemArr.Items.Count;l++)
			{
				if(int.Parse(this.m_lsvMatchedItemArr.Items[l].SubItems[0].Text.ToString().Trim()) == intDeviceSampleFrom)
				{
					for(int i=0;i<intDeviceSampleCount;i++)
					{
						this.m_lsvMatchedItemArr.Items[l+i].SubItems[this.m_cboCheckItem.SelectedIndex+1].Text = 
							((int)(intSeqFrom+i)).ToString().Trim();
					}
				}
			}
		}

		private void m_btnOK_Click(object sender, System.EventArgs e)
		{
			m_mthMatchSampleRelation();
		}
		#endregion

		#region 初始化检验项目结果和默认路径数组
		public void m_mthInitalItemArr()
		{
			if(this.m_cboCheckItem.Items.Count <= 0)
				return;
			try
			{
				int intItemCount = this.m_cboCheckItem.Items.Count;
				m_arlItemArr = new ArrayList[intItemCount];
				m_strFilePathArr =new string[intItemCount];
				m_objFileInfoArr = new clsFileInfo_VO[intItemCount];
				for(int i=0;i<m_arlItemArr.Length;i++)
				{
					m_arlItemArr[i] = new ArrayList();
				}
			}
			catch
			{
			}
		}
		#endregion

		#region 初始化乙肝五项相关控件
		public void m_mthInitalHepatitisFive()
		{
			//更新listView
			ColumnHeader chHBSAG = new ColumnHeader();
			chHBSAG.Text = "HBSAG";
			this.m_lsvMatchedItemArr.Columns.Add(chHBSAG);
			ColumnHeader chHBSAB = new ColumnHeader();
			chHBSAB.Text = "HBSAB";
			this.m_lsvMatchedItemArr.Columns.Add(chHBSAB);
			ColumnHeader chHBEAG = new ColumnHeader();
			chHBEAG.Text = "HBEAG";
			this.m_lsvMatchedItemArr.Columns.Add(chHBEAG);
			ColumnHeader chHBEAB = new ColumnHeader();
			chHBEAB.Text = "HBEAB";
			this.m_lsvMatchedItemArr.Columns.Add(chHBEAB);
			ColumnHeader chHBCAB = new ColumnHeader();
			chHBCAB.Text = "HBCAB";
			this.m_lsvMatchedItemArr.Columns.Add(chHBCAB);
		}
		#endregion

		#region InitalViewer
		private void frmSymBIO_Load(object sender, System.EventArgs e)
		{
			m_mthSetEnter2Tab(new System.Windows.Forms.Control[]{this.m_btnCancelMatch,this.m_btnTranslate});
			m_mthInitalItemArr();
			m_mthInitalHepatitisFive();
			this.m_cboCheckItem.SelectedIndex = 0;
		}

		private void frmSymBIO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
		}
		#endregion

		#region 根据时间查询范围内的文件列表
		public void m_mthGetFileListByCondition()
		{
			this.m_lsvFileList.Items.Clear();
			DateTime dtFrom = this.m_dtpDatFrom.Value.Date;
			string strDefaultPath = m_mthGetDefaultPath("defaultPathSettings",this.m_cboCheckItem.Text.ToString().Trim());
			try
			{
				if(!Directory.Exists(strDefaultPath))
				{
					MessageBox.Show("不存在目录"+strDefaultPath+"！");
					return;
				}
				string[] strFilesArr = Directory.GetFileSystemEntries(strDefaultPath,"*.ra");
				for(int i=0;i<strFilesArr.Length;i++)
				{
					FileInfo FI = new FileInfo(strFilesArr[i]);
					if(FI.LastWriteTime.Date == dtFrom)
					{
						clsFileInfo_VO objVO = new clsFileInfo_VO();
						objVO.m_strFilePath = FI.FullName;
						objVO.m_strFileName = FI.Name;
						objVO.m_strFileLastWriteTime = FI.LastWriteTime.ToString().Trim();
						ListViewItem lsvItem = new ListViewItem();
						lsvItem.Text = objVO.m_strFileName;
						lsvItem.SubItems.Add(objVO.m_strFileLastWriteTime);
						lsvItem.Tag = objVO;
						this.m_lsvFileList.Items.Add(lsvItem);
					}
				}
				if(this.m_lsvFileList.Items.Count <= 0)
					MessageBox.Show("无符合条件的文件！");
			}
			catch(Exception objEx)
			{
				MessageBox.Show(objEx.Message);
			}
		}

		private void m_btnQuery_Click(object sender, System.EventArgs e)
		{
			m_mthGetFileListByCondition();
		}
		#endregion

		#region 根据文件路径返回FileInfo_VO
		public clsFileInfo_VO m_clsGetFileInfoByPath(string p_strFilePath)
		{
			if(!File.Exists(p_strFilePath))
				return null;
			FileInfo FI = new FileInfo(p_strFilePath);
			clsFileInfo_VO objVO = new clsFileInfo_VO();
			objVO.m_strFileLastWriteTime = FI.LastWriteTime.ToString().Trim();
			objVO.m_strFileName = FI.Name;
			objVO.m_strFilePath = FI.FullName;
			return objVO;
		}
		#endregion

		private void m_lsvFileList_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.m_lsvFileList.Items.Count <= 0)
				return;
			clsFileInfo_VO objVO = (clsFileInfo_VO)this.m_lsvFileList.SelectedItems[0].Tag;
			m_mthConstructFileCheckItemArr(objVO.m_strFilePath,ref m_arlItemArr[this.m_cboCheckItem.SelectedIndex]);
			this.m_txtResultCount.Text = m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
		}
	}

	public class clsFileInfo_VO
	{
		//文件名
		public string m_strFileName;
		//文件路径
		public string m_strFilePath;
		//文件修改时间
		public string m_strFileLastWriteTime;
	}
}
