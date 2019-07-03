using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller
{
	/// <summary>
	/// frmFileProcess 的摘要说明。
	/// </summary>
	public class frmFileProcess : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region FromControls
		private System.Windows.Forms.Label m_lbFilePath;
		private System.Windows.Forms.TextBox m_txtFilePath;
		private System.Windows.Forms.Button m_btnBrowse;
		private System.Windows.Forms.Label m_lbCheckItem;
		private System.Windows.Forms.ComboBox m_cboCheckItem;
		private System.Windows.Forms.Label m_lbDeviceSampleFrom;
		private System.Windows.Forms.TextBox m_txtDeviceSampleFrom;
		private System.Windows.Forms.Label m_lbDeviceSampleTo;
		private System.Windows.Forms.TextBox m_txtDeviceSampleTo;
		private System.Windows.Forms.Label m_lbSampleSeq;
		private System.Windows.Forms.TextBox m_txtSampleSeqFrom;
		private System.Windows.Forms.Label m_lbSampleSeqTo;
		private System.Windows.Forms.TextBox m_txtSampleSeqTo;
		private System.Windows.Forms.GroupBox m_gpbInfo;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnTranslate;
		private System.Windows.Forms.OpenFileDialog m_openFileDlg;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label m_lbDeviceRange;
		private System.Windows.Forms.TextBox m_txtDeviceSampleIDTo;
		private System.Windows.Forms.TextBox m_txtDeviceSampleIDFrom;
		private System.Windows.Forms.Label m_lbResultCount;
		private System.Windows.Forms.TextBox m_txtResultCount;
		private System.Windows.Forms.Button m_btnCancelMatch;
		private System.Windows.Forms.Label m_lbCheckCategory;
		private System.Windows.Forms.Label m_lbFileModifyDat;
		private System.Windows.Forms.ComboBox m_cboCheckCategory;
		private System.Windows.Forms.Button m_btnAutoMatch;
		string m_strAnalysisDll;
		private System.Windows.Forms.ListView m_lsvMatchedItemArr;
		private System.Windows.Forms.ColumnHeader m_chDeviceSample;
		private System.Windows.Forms.Button m_btnSaveResult;
		private System.Windows.Forms.SaveFileDialog m_saveFileDlg;
		#endregion

		#region ItemArr
		#region 检验项目结果数组
		ArrayList[] m_arlItemArr;
		string[] m_strFilePathArr;
		#endregion
		#endregion

		#region SysInitalize
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmFileProcess(string p_strAnalysisDll)
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.m_lbFilePath = new System.Windows.Forms.Label();
			this.m_txtFilePath = new System.Windows.Forms.TextBox();
			this.m_btnBrowse = new System.Windows.Forms.Button();
			this.m_lbCheckItem = new System.Windows.Forms.Label();
			this.m_cboCheckItem = new System.Windows.Forms.ComboBox();
			this.m_lbDeviceSampleFrom = new System.Windows.Forms.Label();
			this.m_txtDeviceSampleFrom = new System.Windows.Forms.TextBox();
			this.m_lbDeviceSampleTo = new System.Windows.Forms.Label();
			this.m_txtDeviceSampleTo = new System.Windows.Forms.TextBox();
			this.m_lbSampleSeq = new System.Windows.Forms.Label();
			this.m_txtSampleSeqFrom = new System.Windows.Forms.TextBox();
			this.m_lbSampleSeqTo = new System.Windows.Forms.Label();
			this.m_txtSampleSeqTo = new System.Windows.Forms.TextBox();
			this.m_lsvMatchedItemArr = new System.Windows.Forms.ListView();
			this.m_chDeviceSample = new System.Windows.Forms.ColumnHeader();
			this.m_gpbInfo = new System.Windows.Forms.GroupBox();
			this.m_cboCheckCategory = new System.Windows.Forms.ComboBox();
			this.m_lbCheckCategory = new System.Windows.Forms.Label();
			this.m_txtResultCount = new System.Windows.Forms.TextBox();
			this.m_lbResultCount = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtDeviceSampleIDTo = new System.Windows.Forms.TextBox();
			this.m_txtDeviceSampleIDFrom = new System.Windows.Forms.TextBox();
			this.m_lbDeviceRange = new System.Windows.Forms.Label();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnTranslate = new System.Windows.Forms.Button();
			this.m_openFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btnAutoMatch = new System.Windows.Forms.Button();
			this.m_btnCancelMatch = new System.Windows.Forms.Button();
			this.m_lbFileModifyDat = new System.Windows.Forms.Label();
			this.m_btnSaveResult = new System.Windows.Forms.Button();
			this.m_saveFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.m_gpbInfo.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lbFilePath
			// 
			this.m_lbFilePath.AutoSize = true;
			this.m_lbFilePath.Location = new System.Drawing.Point(208, 44);
			this.m_lbFilePath.Name = "m_lbFilePath";
			this.m_lbFilePath.Size = new System.Drawing.Size(77, 19);
			this.m_lbFilePath.TabIndex = 0;
			this.m_lbFilePath.Text = "文件路径：";
			// 
			// m_txtFilePath
			// 
			this.m_txtFilePath.BackColor = System.Drawing.SystemColors.Info;
			this.m_txtFilePath.Location = new System.Drawing.Point(276, 40);
			this.m_txtFilePath.Name = "m_txtFilePath";
			this.m_txtFilePath.ReadOnly = true;
			this.m_txtFilePath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtFilePath.Size = new System.Drawing.Size(248, 23);
			this.m_txtFilePath.TabIndex = 22;
			this.m_txtFilePath.TabStop = false;
			this.m_txtFilePath.Text = "";
			// 
			// m_btnBrowse
			// 
			this.m_btnBrowse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnBrowse.Location = new System.Drawing.Point(528, 40);
			this.m_btnBrowse.Name = "m_btnBrowse";
			this.m_btnBrowse.Size = new System.Drawing.Size(76, 24);
			this.m_btnBrowse.TabIndex = 2;
			this.m_btnBrowse.Text = "浏览";
			this.m_btnBrowse.Click += new System.EventHandler(this.m_btnBrowse_Click);
			// 
			// m_lbCheckItem
			// 
			this.m_lbCheckItem.AutoSize = true;
			this.m_lbCheckItem.Location = new System.Drawing.Point(208, 20);
			this.m_lbCheckItem.Name = "m_lbCheckItem";
			this.m_lbCheckItem.Size = new System.Drawing.Size(77, 19);
			this.m_lbCheckItem.TabIndex = 3;
			this.m_lbCheckItem.Text = "检验项目：";
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
			this.m_cboCheckItem.Location = new System.Drawing.Point(276, 16);
			this.m_cboCheckItem.Name = "m_cboCheckItem";
			this.m_cboCheckItem.Size = new System.Drawing.Size(128, 22);
			this.m_cboCheckItem.TabIndex = 1;
			this.m_cboCheckItem.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckItem_SelectedIndexChanged);
			// 
			// m_lbDeviceSampleFrom
			// 
			this.m_lbDeviceSampleFrom.AutoSize = true;
			this.m_lbDeviceSampleFrom.Location = new System.Drawing.Point(8, 24);
			this.m_lbDeviceSampleFrom.Name = "m_lbDeviceSampleFrom";
			this.m_lbDeviceSampleFrom.Size = new System.Drawing.Size(92, 19);
			this.m_lbDeviceSampleFrom.TabIndex = 5;
			this.m_lbDeviceSampleFrom.Text = "仪器标本号：";
			// 
			// m_txtDeviceSampleFrom
			// 
			this.m_txtDeviceSampleFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.m_txtDeviceSampleFrom.Location = new System.Drawing.Point(100, 20);
			this.m_txtDeviceSampleFrom.Name = "m_txtDeviceSampleFrom";
			this.m_txtDeviceSampleFrom.Size = new System.Drawing.Size(164, 23);
			this.m_txtDeviceSampleFrom.TabIndex = 6;
			this.m_txtDeviceSampleFrom.Text = "";
			this.m_txtDeviceSampleFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleFrom_KeyPress);
			// 
			// m_lbDeviceSampleTo
			// 
			this.m_lbDeviceSampleTo.AutoSize = true;
			this.m_lbDeviceSampleTo.Location = new System.Drawing.Point(272, 24);
			this.m_lbDeviceSampleTo.Name = "m_lbDeviceSampleTo";
			this.m_lbDeviceSampleTo.Size = new System.Drawing.Size(20, 19);
			this.m_lbDeviceSampleTo.TabIndex = 7;
			this.m_lbDeviceSampleTo.Text = "至";
			// 
			// m_txtDeviceSampleTo
			// 
			this.m_txtDeviceSampleTo.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtDeviceSampleTo.Location = new System.Drawing.Point(296, 20);
			this.m_txtDeviceSampleTo.Name = "m_txtDeviceSampleTo";
			this.m_txtDeviceSampleTo.Size = new System.Drawing.Size(144, 23);
			this.m_txtDeviceSampleTo.TabIndex = 8;
			this.m_txtDeviceSampleTo.Text = "";
			this.m_txtDeviceSampleTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleFrom_KeyPress);
			// 
			// m_lbSampleSeq
			// 
			this.m_lbSampleSeq.AutoSize = true;
			this.m_lbSampleSeq.Location = new System.Drawing.Point(20, 48);
			this.m_lbSampleSeq.Name = "m_lbSampleSeq";
			this.m_lbSampleSeq.Size = new System.Drawing.Size(77, 19);
			this.m_lbSampleSeq.TabIndex = 9;
			this.m_lbSampleSeq.Text = "标本序号：";
			// 
			// m_txtSampleSeqFrom
			// 
			this.m_txtSampleSeqFrom.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtSampleSeqFrom.Location = new System.Drawing.Point(100, 44);
			this.m_txtSampleSeqFrom.Name = "m_txtSampleSeqFrom";
			this.m_txtSampleSeqFrom.Size = new System.Drawing.Size(164, 23);
			this.m_txtSampleSeqFrom.TabIndex = 10;
			this.m_txtSampleSeqFrom.Text = "";
			this.m_txtSampleSeqFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleFrom_KeyPress);
			// 
			// m_lbSampleSeqTo
			// 
			this.m_lbSampleSeqTo.AutoSize = true;
			this.m_lbSampleSeqTo.Location = new System.Drawing.Point(272, 48);
			this.m_lbSampleSeqTo.Name = "m_lbSampleSeqTo";
			this.m_lbSampleSeqTo.Size = new System.Drawing.Size(20, 19);
			this.m_lbSampleSeqTo.TabIndex = 11;
			this.m_lbSampleSeqTo.Text = "至";
			// 
			// m_txtSampleSeqTo
			// 
			this.m_txtSampleSeqTo.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtSampleSeqTo.Location = new System.Drawing.Point(296, 44);
			this.m_txtSampleSeqTo.Name = "m_txtSampleSeqTo";
			this.m_txtSampleSeqTo.Size = new System.Drawing.Size(144, 23);
			this.m_txtSampleSeqTo.TabIndex = 12;
			this.m_txtSampleSeqTo.Text = "";
			this.m_txtSampleSeqTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleFrom_KeyPress);
			// 
			// m_lsvMatchedItemArr
			// 
			this.m_lsvMatchedItemArr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lsvMatchedItemArr.BackColor = System.Drawing.Color.LightSteelBlue;
			this.m_lsvMatchedItemArr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.m_chDeviceSample});
			this.m_lsvMatchedItemArr.FullRowSelect = true;
			this.m_lsvMatchedItemArr.GridLines = true;
			this.m_lsvMatchedItemArr.HideSelection = false;
			this.m_lsvMatchedItemArr.Location = new System.Drawing.Point(0, 184);
			this.m_lsvMatchedItemArr.MultiSelect = false;
			this.m_lsvMatchedItemArr.Name = "m_lsvMatchedItemArr";
			this.m_lsvMatchedItemArr.Size = new System.Drawing.Size(644, 528);
			this.m_lsvMatchedItemArr.TabIndex = 14;
			this.m_lsvMatchedItemArr.View = System.Windows.Forms.View.Details;
			// 
			// m_chDeviceSample
			// 
			this.m_chDeviceSample.Text = "仪器标本号";
			this.m_chDeviceSample.Width = 91;
			// 
			// m_gpbInfo
			// 
			this.m_gpbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gpbInfo.Controls.Add(this.m_btnSaveResult);
			this.m_gpbInfo.Controls.Add(this.m_cboCheckCategory);
			this.m_gpbInfo.Controls.Add(this.m_lbCheckCategory);
			this.m_gpbInfo.Controls.Add(this.m_txtResultCount);
			this.m_gpbInfo.Controls.Add(this.m_lbResultCount);
			this.m_gpbInfo.Controls.Add(this.button1);
			this.m_gpbInfo.Controls.Add(this.label2);
			this.m_gpbInfo.Controls.Add(this.m_txtDeviceSampleIDTo);
			this.m_gpbInfo.Controls.Add(this.m_txtDeviceSampleIDFrom);
			this.m_gpbInfo.Controls.Add(this.m_lbDeviceRange);
			this.m_gpbInfo.Controls.Add(this.m_cboCheckItem);
			this.m_gpbInfo.Controls.Add(this.m_btnBrowse);
			this.m_gpbInfo.Controls.Add(this.m_lbCheckItem);
			this.m_gpbInfo.Controls.Add(this.m_txtFilePath);
			this.m_gpbInfo.Controls.Add(this.m_lbFilePath);
			this.m_gpbInfo.Location = new System.Drawing.Point(4, 4);
			this.m_gpbInfo.Name = "m_gpbInfo";
			this.m_gpbInfo.Size = new System.Drawing.Size(636, 96);
			this.m_gpbInfo.TabIndex = 15;
			this.m_gpbInfo.TabStop = false;
			this.m_gpbInfo.Text = "基本信息";
			// 
			// m_cboCheckCategory
			// 
			this.m_cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCheckCategory.Items.AddRange(new object[] {
																	"肿瘤五项",
																	"甲功八项",
																	"乙肝六项",
																	"肝纤四项",
																	"生长激素",
																	"其他"});
			this.m_cboCheckCategory.Location = new System.Drawing.Point(76, 16);
			this.m_cboCheckCategory.Name = "m_cboCheckCategory";
			this.m_cboCheckCategory.Size = new System.Drawing.Size(128, 22);
			this.m_cboCheckCategory.TabIndex = 0;
			this.m_cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckCategory_SelectedIndexChanged);
			// 
			// m_lbCheckCategory
			// 
			this.m_lbCheckCategory.AutoSize = true;
			this.m_lbCheckCategory.Location = new System.Drawing.Point(8, 20);
			this.m_lbCheckCategory.Name = "m_lbCheckCategory";
			this.m_lbCheckCategory.Size = new System.Drawing.Size(77, 19);
			this.m_lbCheckCategory.TabIndex = 23;
			this.m_lbCheckCategory.Text = "检验分类：";
			// 
			// m_txtResultCount
			// 
			this.m_txtResultCount.BackColor = System.Drawing.SystemColors.Info;
			this.m_txtResultCount.Location = new System.Drawing.Point(76, 40);
			this.m_txtResultCount.Name = "m_txtResultCount";
			this.m_txtResultCount.ReadOnly = true;
			this.m_txtResultCount.Size = new System.Drawing.Size(128, 23);
			this.m_txtResultCount.TabIndex = 21;
			this.m_txtResultCount.TabStop = false;
			this.m_txtResultCount.Text = "";
			// 
			// m_lbResultCount
			// 
			this.m_lbResultCount.AutoSize = true;
			this.m_lbResultCount.Location = new System.Drawing.Point(8, 44);
			this.m_lbResultCount.Name = "m_lbResultCount";
			this.m_lbResultCount.Size = new System.Drawing.Size(77, 19);
			this.m_lbResultCount.TabIndex = 20;
			this.m_lbResultCount.Text = "结果数量：";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.Location = new System.Drawing.Point(448, 68);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 24);
			this.button1.TabIndex = 5;
			this.button1.Text = "确定";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(272, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 19);
			this.label2.TabIndex = 17;
			this.label2.Text = "至";
			// 
			// m_txtDeviceSampleIDTo
			// 
			this.m_txtDeviceSampleIDTo.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtDeviceSampleIDTo.Location = new System.Drawing.Point(296, 64);
			this.m_txtDeviceSampleIDTo.Name = "m_txtDeviceSampleIDTo";
			this.m_txtDeviceSampleIDTo.Size = new System.Drawing.Size(144, 23);
			this.m_txtDeviceSampleIDTo.TabIndex = 4;
			this.m_txtDeviceSampleIDTo.Text = "";
			this.m_txtDeviceSampleIDTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleFrom_KeyPress);
			// 
			// m_txtDeviceSampleIDFrom
			// 
			this.m_txtDeviceSampleIDFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.m_txtDeviceSampleIDFrom.Location = new System.Drawing.Point(112, 64);
			this.m_txtDeviceSampleIDFrom.Name = "m_txtDeviceSampleIDFrom";
			this.m_txtDeviceSampleIDFrom.Size = new System.Drawing.Size(152, 23);
			this.m_txtDeviceSampleIDFrom.TabIndex = 3;
			this.m_txtDeviceSampleIDFrom.Text = "";
			this.m_txtDeviceSampleIDFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtDeviceSampleFrom_KeyPress);
			// 
			// m_lbDeviceRange
			// 
			this.m_lbDeviceRange.AutoSize = true;
			this.m_lbDeviceRange.Location = new System.Drawing.Point(4, 68);
			this.m_lbDeviceRange.Name = "m_lbDeviceRange";
			this.m_lbDeviceRange.Size = new System.Drawing.Size(120, 19);
			this.m_lbDeviceRange.TabIndex = 15;
			this.m_lbDeviceRange.Text = "仪器标本号范围：";
			// 
			// m_btnOK
			// 
			this.m_btnOK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnOK.Location = new System.Drawing.Point(448, 44);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(76, 24);
			this.m_btnOK.TabIndex = 13;
			this.m_btnOK.Text = "确定";
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// m_btnTranslate
			// 
			this.m_btnTranslate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnTranslate.Location = new System.Drawing.Point(532, 44);
			this.m_btnTranslate.Name = "m_btnTranslate";
			this.m_btnTranslate.Size = new System.Drawing.Size(76, 24);
			this.m_btnTranslate.TabIndex = 14;
			this.m_btnTranslate.Text = "数据转换";
			this.m_btnTranslate.Click += new System.EventHandler(this.m_btnTranslate_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_btnAutoMatch);
			this.groupBox1.Controls.Add(this.m_btnCancelMatch);
			this.groupBox1.Controls.Add(this.m_lbDeviceSampleFrom);
			this.groupBox1.Controls.Add(this.m_lbDeviceSampleTo);
			this.groupBox1.Controls.Add(this.m_txtDeviceSampleFrom);
			this.groupBox1.Controls.Add(this.m_btnOK);
			this.groupBox1.Controls.Add(this.m_btnTranslate);
			this.groupBox1.Controls.Add(this.m_txtDeviceSampleTo);
			this.groupBox1.Controls.Add(this.m_lbSampleSeq);
			this.groupBox1.Controls.Add(this.m_txtSampleSeqFrom);
			this.groupBox1.Controls.Add(this.m_lbSampleSeqTo);
			this.groupBox1.Controls.Add(this.m_txtSampleSeqTo);
			this.groupBox1.Location = new System.Drawing.Point(4, 104);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(636, 76);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "关系对应";
			// 
			// m_btnAutoMatch
			// 
			this.m_btnAutoMatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnAutoMatch.Location = new System.Drawing.Point(532, 16);
			this.m_btnAutoMatch.Name = "m_btnAutoMatch";
			this.m_btnAutoMatch.Size = new System.Drawing.Size(76, 24);
			this.m_btnAutoMatch.TabIndex = 16;
			this.m_btnAutoMatch.Text = "自动对应";
			this.m_btnAutoMatch.Click += new System.EventHandler(this.m_btnAutoMatch_Click);
			// 
			// m_btnCancelMatch
			// 
			this.m_btnCancelMatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnCancelMatch.Location = new System.Drawing.Point(448, 16);
			this.m_btnCancelMatch.Name = "m_btnCancelMatch";
			this.m_btnCancelMatch.Size = new System.Drawing.Size(76, 24);
			this.m_btnCancelMatch.TabIndex = 15;
			this.m_btnCancelMatch.Text = "取消对应";
			this.m_btnCancelMatch.Click += new System.EventHandler(this.m_btnCancelMatch_Click);
			// 
			// m_lbFileModifyDat
			// 
			this.m_lbFileModifyDat.Location = new System.Drawing.Point(304, 40);
			this.m_lbFileModifyDat.Name = "m_lbFileModifyDat";
			this.m_lbFileModifyDat.TabIndex = 25;
			this.m_lbFileModifyDat.Text = "label1";
			// 
			// m_btnSaveResult
			// 
			this.m_btnSaveResult.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnSaveResult.Location = new System.Drawing.Point(408, 16);
			this.m_btnSaveResult.Name = "m_btnSaveResult";
			this.m_btnSaveResult.Size = new System.Drawing.Size(92, 23);
			this.m_btnSaveResult.TabIndex = 24;
			this.m_btnSaveResult.Text = "保存结果数据";
			this.m_btnSaveResult.Click += new System.EventHandler(this.m_btnSaveResult_Click);
			// 
			// frmFileProcess
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(644, 713);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_gpbInfo);
			this.Controls.Add(this.m_lsvMatchedItemArr);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFileProcess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据采集";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFileProcess_KeyDown);
			this.Load += new System.EventHandler(this.frmFileProcess_Load);
			this.m_gpbInfo.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
			if(this.m_cboCheckCategory.Text.ToString().Trim() == "乙肝五项")
			{
				strFileName = strPath + "SymBIOResult.txt";
			}
			else
			{
				strFileName = strPath + "SN695BResult.txt";
			}
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

		#region 设置项目的默认路径
		public void m_mthSetItemDefaultPath(string p_strPath)
		{
			try
			{
				string strPath = "";
//				if(this.m_cboCheckCategory.Text.ToString().Trim() == "乙肝五项")
//				{
					strPath = System.AppDomain.CurrentDomain.BaseDirectory + m_strAnalysisDll.Split(new char[]{'.'})[0] + ".config";
//				}
//				else
//				{
//					strPath = System.AppDomain.CurrentDomain.BaseDirectory + "SN695B.config";
//				}
				System.Configuration.ConfigXmlDocument defaultPathConfig = new System.Configuration.ConfigXmlDocument();
				defaultPathConfig.Load(strPath);
				defaultPathConfig["configuration"]["defaultPathSettings"].SelectSingleNode("add[@key=\""+this.m_cboCheckItem.Text.ToString().Trim()+"\"]").Attributes["value"].Value = 
					p_strPath;
				defaultPathConfig.Save(strPath);
			}
			catch
			{
			}
		}
		#endregion

		#region 获取默认路径
		public string m_mthGetDefaultPath(string p_strNode,string p_strKeyVal)
		{
			string p_strFilePath;
			try
			{
				string strPath = "";
//				if(this.m_cboCheckCategory.Text.ToString().Trim() == "乙肝五项")
//				{
					strPath = System.AppDomain.CurrentDomain.BaseDirectory + m_strAnalysisDll.Split(new char[]{'.'})[0] + ".config";
//				}
//				else
//				{
//					strPath = System.AppDomain.CurrentDomain.BaseDirectory + "SN695B.config";
//				}
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

		#region ViewerInital
		private void frmFileProcess_Load(object sender, System.EventArgs e)
		{
			m_mthSetEnter2Tab(new System.Windows.Forms.Control[]{this.m_btnBrowse,this.m_btnCancelMatch,this.m_btnTranslate,m_cboCheckCategory,
			m_btnSaveResult});
			m_mthInitalCheckCategory(System.AppDomain.CurrentDomain.BaseDirectory + m_strAnalysisDll.Split(new char[]{'.'})[0] + ".config");
			if(this.m_strAnalysisDll == "SN695B.dll")
			{
				this.m_btnSaveResult.Visible = true;
			}
			else if(this.m_strAnalysisDll == "SymBIO.dll")
			{
				this.m_btnSaveResult.Visible = false;
			}
			this.m_cboCheckCategory.SelectedIndex = 0;
			this.m_cboCheckItem.SelectedIndex = 0;
			this.m_btnBrowse.Focus();
		}
		#endregion

		#region 根据分析的Dll名称初始化检验类别
		public void m_mthInitalCheckCategory(string strFilePath)
		{
			this.m_cboCheckCategory.Items.Clear();
			System.Configuration.ConfigXmlDocument defaultPathConfig = new System.Configuration.ConfigXmlDocument();
			defaultPathConfig.Load(strFilePath);
			XmlNodeList nodeList = defaultPathConfig["configuration"]["checkGroup"].ChildNodes;
			foreach(XmlNode xn in nodeList)
			{
				this.m_cboCheckCategory.Items.Add(xn.Attributes["value"].Value);
			}
		}
		#endregion
	
		#region 下拉列表事件
		private void m_cboCheckItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_cboCheckCategory.Text == "乙肝五项")
			{
				if(m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count == 0)
				{
					string strDefaultPath = m_mthGetDefaultPath("defaultPathSettings",this.m_cboCheckItem.Text.ToString().Trim());
					if(strDefaultPath != null && strDefaultPath != "")
					{
						string strFilePath = m_mthGetLatestFile(strDefaultPath);
						if(strFilePath != null && strFilePath != "")
						{
							m_mthConstructFileCheckItemArr(strFilePath,ref m_arlItemArr[this.m_cboCheckItem.SelectedIndex]);
							m_strFilePathArr[this.m_cboCheckItem.SelectedIndex] = strFilePath;
							this.m_txtFilePath.Text = strFilePath;
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
							this.m_txtFilePath.Clear();
							this.m_txtResultCount.Clear();
							MessageBox.Show("请选择仪器结果文件！");
							this.m_btnBrowse.Focus();
						}
					}
					else
					{
						this.m_txtFilePath.Clear();
						this.m_txtResultCount.Clear();
						MessageBox.Show("请选择仪器结果文件！");
						this.m_btnBrowse.Focus();
					}
				}
				else
				{
					this.m_txtFilePath.Text = m_strFilePathArr[this.m_cboCheckItem.SelectedIndex].Trim();
					this.m_txtResultCount.Text = m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
				}
			}
			else
			{
				//放免仪器处理
				m_mthSelectedItem();
			}
		}
		#endregion

		#region 控制只能输入数字和回退键
		private void m_txtDeviceSampleFrom_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if((e.KeyChar < (char)48 || e.KeyChar > (char)57) && e.KeyChar != (char)8)
				e.Handled = true;
		}
		#endregion

		#region 浏览文件事件
		private void m_btnBrowse_Click(object sender, System.EventArgs e)
		{
			if(this.m_cboCheckCategory.Text == "乙肝五项")
			{
				m_openFileDlg.Filter = "仪器结果(*.ra)|*.ra";
				string strInitalDirectiory = m_mthGetDefaultPath("defaultPathSettings",this.m_cboCheckItem.Text.ToString().Trim());
				if(strInitalDirectiory != null && strInitalDirectiory != "")
				{
					m_openFileDlg.InitialDirectory = strInitalDirectiory;
				}
				DialogResult dlgRes = this.m_openFileDlg.ShowDialog();
				if(dlgRes == DialogResult.OK)
				{
					m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Clear();
					m_mthReset();
					m_mthCancelMatch();
					string strFilePath = this.m_openFileDlg.FileName;
					m_mthConstructFileCheckItemArr(strFilePath,ref m_arlItemArr[this.m_cboCheckItem.SelectedIndex]);
					m_strFilePathArr[this.m_cboCheckItem.SelectedIndex] = strFilePath;
					this.m_txtFilePath.Text = strFilePath;
					this.m_txtResultCount.Text = m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
					m_mthSetItemDefaultPath(strFilePath.Substring(0,strFilePath.LastIndexOf(@"\")+1));
				}
			}
			else
			{
//				string strInitalDirectiory = m_mthGetDefaultPath("defaultPathSettings",this.m_cboCheckItem.Text.ToString().Trim());
//				strInitalDirectiory = strInitalDirectiory.Substring(0,strInitalDirectiory.Length-strInitalDirectiory.LastIndexOf(@"\"));
				m_openFileDlg.Reset();
				m_openFileDlg.Filter = "仪器结果(*.OOT)|*.OOT";
				string strInitalPath = m_mthGetDefaultPath("savePathSettings",this.m_cboCheckItem.Text.ToString().Trim());
				if(strInitalPath != null && strInitalPath != "")
				{
					m_openFileDlg.InitialDirectory = strInitalPath;
				}
				DialogResult dlgRes = this.m_openFileDlg.ShowDialog();
				if(dlgRes == DialogResult.OK)
				{
					this.m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Clear();
					m_mthReset();
					m_mthCancelMatch();
					string strFilePath = this.m_openFileDlg.FileName;
					m_mthAnalysisGammaMeasureDeviceData(this.m_cboCheckItem.Text.ToString().Trim(),
						strFilePath,ref m_arlItemArr[this.m_cboCheckItem.SelectedIndex]);
					m_strFilePathArr[this.m_cboCheckItem.SelectedIndex] = strFilePath;
					this.m_txtFilePath.Text = strFilePath;
					this.m_txtResultCount.Text = m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
				}
			}
		}
		#endregion

		#region 对应仪器关系
		public void m_mthMatchSampleRelation()
		{
			if(this.m_txtResultCount.Text.ToString().Trim() == "")
			{
				MessageBox.Show("请导入仪器结果数据！");
				return;
			}
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
			if(int.Parse(this.m_txtSampleSeqFrom.Text.ToString().Trim()) > int.Parse(this.m_txtResultCount.Text.ToString().Trim())
				|| int.Parse(this.m_txtSampleSeqFrom.Text.ToString().Trim()) <= 0)
			{
				MessageBox.Show("序号应该小于或等于标本的个数且大于零");
				this.m_txtSampleSeqFrom.Focus();
				return;
			}
			if(int.Parse(this.m_txtSampleSeqTo.Text.ToString().Trim()) > int.Parse(this.m_txtResultCount.Text.ToString().Trim())
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
			this.m_cboCheckItem.Focus();
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			m_mthSetDeviceSampleIDRange();
		}
		#endregion

		#region 重置
		public void m_mthReset()
		{
			this.m_txtResultCount.Clear();
			this.m_txtFilePath.Clear();
			this.m_txtSampleSeqFrom.Clear();
			this.m_txtSampleSeqTo.Clear();
			this.m_txtDeviceSampleFrom.Clear();
			this.m_txtDeviceSampleTo.Clear();
		}
		#endregion

		#region 转换数据
		public void m_mthTranslateData()
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

		private void m_btnTranslate_Click(object sender, System.EventArgs e)
		{
			m_mthTranslateData();
		}
		#endregion

		#region 取消对应
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

		private void m_btnCancelMatch_Click(object sender, System.EventArgs e)
		{
			m_mthCancelMatch();
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

		#region ViewerKeyDownEvent
		private void frmFileProcess_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
		}
		#endregion

		#region 初始化控件
		#region 初始化肿瘤五项的相关控件
		public void m_mthInitalCancerFive()
		{
			//更新listView
			ColumnHeader chAFP = new ColumnHeader();
			chAFP.Text = "AFP";
			this.m_lsvMatchedItemArr.Columns.Add(chAFP);
			ColumnHeader chCEA = new ColumnHeader();
			chCEA.Text = "CEA";
			this.m_lsvMatchedItemArr.Columns.Add(chCEA);
			ColumnHeader chSF = new ColumnHeader();
			chSF.Text = "SF";
			this.m_lsvMatchedItemArr.Columns.Add(chSF);
			ColumnHeader chAB2MG = new ColumnHeader();
			chAB2MG.Text = "A-B2MG";
			this.m_lsvMatchedItemArr.Columns.Add(chAB2MG);
			//更新ComboBox
			this.m_cboCheckItem.Items.Add("AFP");
			this.m_cboCheckItem.Items.Add("CEA");
			this.m_cboCheckItem.Items.Add("SF");
			this.m_cboCheckItem.Items.Add("A-B2MG");
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
			//更新ComboBox
			this.m_cboCheckItem.Items.Add("HBSAG");
			this.m_cboCheckItem.Items.Add("HBSAB");
			this.m_cboCheckItem.Items.Add("HBEAG");
			this.m_cboCheckItem.Items.Add("HBEAB");
			this.m_cboCheckItem.Items.Add("HBCAB");
		}
		#endregion

		#region 初始化甲功八项相关控件
		public void m_mthInitalJiaGongEight()
		{
			//更新listView
			ColumnHeader[] chArr = new ColumnHeader[8];
			for(int i=0;i<chArr.Length;i++)
			{
				chArr[i] = new ColumnHeader();
			}
			chArr[0].Text = "T3";
			chArr[1].Text = "T4";
			chArr[2].Text = "HTSH";
			chArr[3].Text = "TG";
			chArr[4].Text = "TM";
			chArr[5].Text = "FT3";
			chArr[6].Text = "FT4";
			chArr[7].Text = "R-T3";
			//更新ComboBox
			string[] strArr = new string[8];
			strArr[0] = "T3";
			strArr[1] = "T4";
			strArr[2] = "HTSH";
			strArr[3] = "TG";
			strArr[4] = "TM";
			strArr[5] = "FT3";
			strArr[6] = "FT4";
			strArr[7] = "R-T3";
			m_mthSetColummHeaderANDComBoBox(chArr,strArr);
		}
		#endregion

		#region 初始化乙肝六项相关控件
		public void m_mthInitalHepatitisSix()
		{
			//更新listView
			ColumnHeader[] chArr = new ColumnHeader[6];
			for(int i=0;i<chArr.Length;i++)
			{
				chArr[i] = new ColumnHeader();
				chArr[i].Width = 80;
			}
			chArr[0].Text = "L-HBSAG";
			chArr[1].Text = "L-HBSAB";
			chArr[2].Text = "L-HBEAG";
			chArr[3].Text = "L-HBEAB";
			chArr[4].Text = "L-HBCAB";
			chArr[5].Text = "CAB-IGM";
//			ColumnHeader chHBSAG = new ColumnHeader();
//			chHBSAG.Text = "L-HBSAG";
//			this.m_lsvMatchedItemArr.Columns.Add(chHBSAG);
//			ColumnHeader chHBSAB = new ColumnHeader();
//			chHBSAB.Text = "L-HBSAB";
//			this.m_lsvMatchedItemArr.Columns.Add(chHBSAB);
//			ColumnHeader chHBEAG = new ColumnHeader();
//			chHBEAG.Text = "L-HBEAG";
//			this.m_lsvMatchedItemArr.Columns.Add(chHBEAG);
//			ColumnHeader chHBEAB = new ColumnHeader();
//			chHBEAB.Text = "L-HBEAB";
//			this.m_lsvMatchedItemArr.Columns.Add(chHBEAB);
//			ColumnHeader chHBCAB = new ColumnHeader();
//			chHBCAB.Text = "L-HBCAB";
//			this.m_lsvMatchedItemArr.Columns.Add(chHBCAB);
//			ColumnHeader chCABIGM = new ColumnHeader();
//			chCABIGM.Text = "CAB-IGM";
//			this.m_lsvMatchedItemArr.Columns.Add(chCABIGM);
			//更新ComboBox
			string[] strArr = new string[6];
			strArr[0] = "L-HBSAG";
			strArr[1] = "L-HBSAB";
			strArr[2] = "L-HBEAG";
			strArr[3] = "L-HBEAB";
			strArr[4] = "L-HBCAB";
			strArr[5] = "CAB-IGM";
//			this.m_cboCheckItem.Items.AddRange(strArr);
			m_mthSetColummHeaderANDComBoBox(chArr,strArr);
		}
		#endregion

		#region 初始化肝纤四项相关控件
		public void m_mthInitalLiverFour()
		{
			//更新listView
			ColumnHeader[] chArr = new ColumnHeader[4];
			for(int i=0;i<chArr.Length;i++)
			{
				chArr[i] = new ColumnHeader();
			}
			chArr[0].Text = "CG";
			chArr[1].Text = "HA";
			chArr[2].Text = "PC3";
			chArr[3].Text = "LN";
			//更新ComboBox
			string[] strArr = new string[4];
			strArr[0] = "CG";
			strArr[1] = "HA";
			strArr[2] = "PC3";
			strArr[3] = "LN";
			m_mthSetColummHeaderANDComBoBox(chArr,strArr);
		}
		#endregion

		#region 初始化生长激素相关控件
		public void m_mthInitalGrowHormone()
		{
			//更新listView
			ColumnHeader[] chArr = new ColumnHeader[1];
			for(int i=0;i<chArr.Length;i++)
			{
				chArr[i] = new ColumnHeader();
			}
			chArr[0].Text = "HGH";
			//更新ComboBox
			string[] strArr = new string[1];
			strArr[0] = "HGH";
			m_mthSetColummHeaderANDComBoBox(chArr,strArr);
		}
		#endregion

		#region 初始化其他相关控件
		public void m_mthInitalOther()
		{
			//更新listView
			ColumnHeader[] chArr = new ColumnHeader[2];
			for(int i=0;i<chArr.Length;i++)
			{
				chArr[i] = new ColumnHeader();
			}
			chArr[0].Text = "INS";
			chArr[1].Text = "C-P";
			//更新ComboBox
			string[] strArr = new string[2];
			strArr[0] = "INS";
			strArr[1] = "C-P";
			m_mthSetColummHeaderANDComBoBox(chArr,strArr);
		}
		#endregion

		#region 更新listView和ComboBox控件
		public void m_mthSetColummHeaderANDComBoBox(ColumnHeader[] p_chArr,string[] p_strItemArr)
		{
			this.m_cboCheckItem.Items.Clear();
			this.m_lsvMatchedItemArr.Columns.AddRange(p_chArr);
//			for(int i=0;i<p_chArr.Length;i++)
//			{
//				this.m_lsvMatchedItemArr.Columns.Add(p_chArr[i]);
//			}
			this.m_cboCheckItem.Items.AddRange(p_strItemArr);
		}
		#endregion
		#endregion

		#region 分析放免r测量仪器数据
		public void m_mthAnalysisGammaMeasureDeviceData(string p_strCheckItemName,string p_strFilePath,ref ArrayList p_arlItem)
		{
			if(!File.Exists(p_strFilePath))
				return;
			StreamReader sr = new StreamReader(p_strFilePath);
			string strCheckDat = File.GetLastWriteTime(p_strFilePath).ToString().Trim();
//			string strCheckItemName = p_strFilePath.Substring(p_strFilePath.LastIndexOf(@"\")+1,
//				p_strFilePath.LastIndexOf(".")-p_strFilePath.LastIndexOf(@"\")-1);
			string strLine = "";
			while((strLine = sr.ReadLine()) != null)
			{
				string[] strItemArr = strLine.Split(new char[]{','});
				if(strItemArr.Length == 3)
				{
					clsFileCheckItem_VO objVO = new clsFileCheckItem_VO();
					objVO.m_strCheckDat = strCheckDat;
					objVO.m_strCheckItemName = p_strCheckItemName;
					objVO.m_strResult = strItemArr[2].Trim();
					objVO.m_strSeq = strItemArr[0].Trim();
					p_arlItem.Add(objVO);
				}
			}
			sr.Close();
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

		#region 检验项目下拉列表事件处理
		public void m_mthSelectedItem()
		{
			m_mthReset();
			if(this.m_cboCheckItem.SelectedIndex < 0)
				return;
			int intIdx = this.m_cboCheckItem.SelectedIndex;
			if(this.m_arlItemArr[intIdx].Count == 0)
			{
				//获取默认路径
				string strDefPath = m_mthGetDefaultPath("defaultPathSettings",this.m_cboCheckItem.Text.ToString().Trim());
				if(strDefPath != null && strDefPath != "")
				{
					if(!File.Exists(strDefPath))
					{
						MessageBox.Show("该文件路径不存在！");
						return;
					}
					//构造结果VO
					m_mthAnalysisGammaMeasureDeviceData(this.m_cboCheckItem.Text.ToString().Trim(),strDefPath,ref m_arlItemArr[intIdx]);
					m_strFilePathArr[this.m_cboCheckItem.SelectedIndex] = strDefPath;
					this.m_txtFilePath.Text = strDefPath;
					this.m_txtResultCount.Text = m_arlItemArr[intIdx].Count.ToString().Trim();
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
					this.m_txtFilePath.Clear();
					this.m_txtResultCount.Clear();
					MessageBox.Show("请选择仪器结果文件！");
					this.m_btnBrowse.Focus();
				}
			}
			else
			{
				this.m_txtFilePath.Text = m_strFilePathArr[m_cboCheckItem.SelectedIndex].Trim();
				this.m_txtResultCount.Text = m_arlItemArr[m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
			}
		}
		#endregion

		#region 检验分类下拉列表事件
		private void m_cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.m_lsvMatchedItemArr.Items.Clear();
			this.m_lsvMatchedItemArr.Columns.Clear();
			ColumnHeader chDeviceSampleNO = new ColumnHeader();
			chDeviceSampleNO.Text = "仪器标本号";
			chDeviceSampleNO.Width = 105;
			this.m_lsvMatchedItemArr.Columns.Add(chDeviceSampleNO);
			this.m_cboCheckItem.Items.Clear();
			m_arlItemArr = null;
			m_strFilePathArr = null;
			if(this.m_cboCheckCategory.Text.ToString().Trim() == "乙肝五项")
			{
				m_mthInitalHepatitisFive();
			}
			else
			{
				if(this.m_cboCheckCategory.Text.ToString().Trim() == "肿瘤五项")
				 {
					 m_mthInitalCancerFive();
				 }
				 else if(this.m_cboCheckCategory.Text.ToString().Trim() == "甲功八项")
				 {
					 m_mthInitalJiaGongEight();
				 }
				 else if(this.m_cboCheckCategory.Text.ToString().Trim() == "乙肝六项")
				 {
					 m_mthInitalHepatitisSix();
				 }
				 else if(this.m_cboCheckCategory.Text.ToString().Trim() == "肝纤四项")
				 {
					 m_mthInitalLiverFour();
				 }
				 else if(this.m_cboCheckCategory.Text.ToString().Trim() == "生长激素")
				 {
					 m_mthInitalGrowHormone();
				 }
				 else if(this.m_cboCheckCategory.Text.ToString().Trim() == "其他")
				 {
					 m_mthInitalOther();
				 }
			}
			m_mthInitalItemArr();
			this.m_cboCheckItem.SelectedIndex = 0;
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
				if(this.m_cboCheckCategory.Text == "乙肝五项")
				{
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
				else
				{
					string strPath = m_mthGetDefaultPath("defaultPathSettings",this.m_cboCheckItem.Items[i].ToString());
					m_mthAnalysisGammaMeasureDeviceData(this.m_cboCheckItem.Items[i].ToString(),strPath,ref m_arlItemArr[i]);
					m_strFilePathArr[i] = strPath;
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
			this.m_txtFilePath.Text = this.m_strFilePathArr[this.m_cboCheckItem.SelectedIndex].Trim();
			this.m_txtResultCount.Text = this.m_arlItemArr[this.m_cboCheckItem.SelectedIndex].Count.ToString().Trim();
		}

		private void m_btnAutoMatch_Click(object sender, System.EventArgs e)
		{
			m_mthAutoMatch();
		}
		#endregion

		#region 保存放免的结果数据
		public void m_mthSaveGammaResult()
		{
			try
			{
				string strRawDataPath = this.m_txtFilePath.Text.ToString().Trim();
				if(!File.Exists(strRawDataPath))
					return;
				FileInfo fi = new FileInfo(strRawDataPath);
				DateTime dtLastWriteTime = fi.LastWriteTime;
				m_saveFileDlg.Reset();
				string strInitalPath = m_mthGetDefaultPath("savePathSettings",this.m_cboCheckItem.Text.ToString().Trim());
				if(Directory.Exists(strInitalPath))
				{
					m_saveFileDlg.InitialDirectory = strInitalPath;
				}
				m_saveFileDlg.RestoreDirectory = true;
				m_saveFileDlg.Filter = "仪器结果(*.OOT)|*.OOT";
				DialogResult dlgRes = this.m_saveFileDlg.ShowDialog();
				if(dlgRes == DialogResult.OK)
				{
					StreamReader sr = new StreamReader(strRawDataPath);
					string strRawData = sr.ReadToEnd();
					string strSavePath = m_saveFileDlg.FileName;
					StreamWriter sw;
					if(File.Exists(strSavePath))
					{
						File.Delete(strSavePath);
					}
					sw = File.CreateText(strSavePath);
					sw.Write(strRawData);
					sw.Close();
					sr.Close();
					File.SetLastWriteTime(strSavePath,dtLastWriteTime);
				}
			}
			catch
			{}
		}

		private void m_btnSaveResult_Click(object sender, System.EventArgs e)
		{
			m_mthSaveGammaResult();
		}
		#endregion

	}

	public class clsFileCheckItem_VO
	{
		/// <summary>
		/// 序号
		/// </summary>
		public string m_strSeq = null;
		/// <summary>
		/// 仪器样本号
		/// </summary>
		public string m_strDeviceSampleNO = null;
		/// <summary>
		/// 检验日期
		/// </summary>
		public string m_strCheckDat = null;
		/// <summary>
		/// 检验项目名称
		/// </summary>
		public string m_strCheckItemName = null;
		/// <summary>
		/// 检验结果
		/// </summary>
		public string m_strResult = null;
		/// <summary>
		/// 转换后写入文件的结果
		/// </summary>
		public string m_strTanslateToFileResult = null;
	}
}
