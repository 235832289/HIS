using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// frmFormula 的摘要说明。
	/// </summary>
	public class frmFormula : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 变量
		internal System.Windows.Forms.RichTextBox m_rtbFormula;
		internal PinkieControls.ButtonXP m_btnAdd;
		internal System.Windows.Forms.ListView m_lsvCheckItem;
		private System.Windows.Forms.ColumnHeader m_chCheckItemName;
		private System.Windows.Forms.ColumnHeader m_chCheckItemShortName;
		internal System.Windows.Forms.ComboBox m_cboSampleType;
		internal System.Windows.Forms.ComboBox m_cboCheckCategory;
		internal System.Windows.Forms.TextBox m_txtInstruction;
		internal PinkieControls.ButtonXP m_btnCancel;
		internal PinkieControls.ButtonXP m_btnSave;
		internal PinkieControls.ButtonXP m_btnRightParentThesis;
		internal PinkieControls.ButtonXP m_btnLeftParentThesis;
		internal PinkieControls.ButtonXP m_btnDivide;
		internal PinkieControls.ButtonXP m_btnMultiply;
		internal PinkieControls.ButtonXP m_btnSubtract;
		com.digitalwave.iCare.gui.LIS.clsDomainController_CheckItemManage m_objManage;
		private System.Data.DataTable m_dtbAddCheckItem;
		com.digitalwave.iCare.gui.LIS.frmAddCheckItem m_objViewer;
		#endregion
		internal PinkieControls.ButtonXP m_btnLog;
		internal PinkieControls.ButtonXP m_btnPow;
		internal PinkieControls.ButtonXP m_btnComma;


		#region SystemGenerate
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmFormula()
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
			this.m_rtbFormula = new System.Windows.Forms.RichTextBox();
			this.m_txtInstruction = new System.Windows.Forms.TextBox();
			this.m_btnCancel = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnRightParentThesis = new PinkieControls.ButtonXP();
			this.m_btnLeftParentThesis = new PinkieControls.ButtonXP();
			this.m_btnDivide = new PinkieControls.ButtonXP();
			this.m_btnMultiply = new PinkieControls.ButtonXP();
			this.m_btnSubtract = new PinkieControls.ButtonXP();
			this.m_btnAdd = new PinkieControls.ButtonXP();
			this.m_lsvCheckItem = new System.Windows.Forms.ListView();
			this.m_chCheckItemShortName = new System.Windows.Forms.ColumnHeader();
			this.m_chCheckItemName = new System.Windows.Forms.ColumnHeader();
			this.m_cboSampleType = new System.Windows.Forms.ComboBox();
			this.m_cboCheckCategory = new System.Windows.Forms.ComboBox();
			this.m_btnLog = new PinkieControls.ButtonXP();
			this.m_btnPow = new PinkieControls.ButtonXP();
			this.m_btnComma = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// m_rtbFormula
			// 
			this.m_rtbFormula.Location = new System.Drawing.Point(12, 16);
			this.m_rtbFormula.Name = "m_rtbFormula";
			this.m_rtbFormula.Size = new System.Drawing.Size(604, 104);
			this.m_rtbFormula.TabIndex = 1;
			this.m_rtbFormula.Text = "";
			this.m_rtbFormula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_rtbFormula_KeyPress);
			// 
			// m_txtInstruction
			// 
			this.m_txtInstruction.BackColor = System.Drawing.SystemColors.Info;
			this.m_txtInstruction.Location = new System.Drawing.Point(288, 244);
			this.m_txtInstruction.Multiline = true;
			this.m_txtInstruction.Name = "m_txtInstruction";
			this.m_txtInstruction.Size = new System.Drawing.Size(324, 152);
			this.m_txtInstruction.TabIndex = 25;
			this.m_txtInstruction.Text = "说明： \r\n\r\n   1.计算公式中不可包含其他计算项目，若有需要\r\n     一律转换为最原始的计算公式；\r\n   2.所有项目代号必须使用“[”和“]”括起来" +
				"；\r\n   3.对于Log函数，Log（X）表示以自然数e为底\r\n     的对数函数,Log（X,Y）表示以X为底的对数 \r\n     函数；\r\n   4.对" +
				"于Pow函数，Pow（X，Y）表示以X为幂，Y\r\n     为指数（即 X^Y ）的函数。";
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnCancel.DefaultScheme = true;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnCancel.Hint = "";
			this.m_btnCancel.Location = new System.Drawing.Point(488, 404);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnCancel.Size = new System.Drawing.Size(80, 30);
			this.m_btnCancel.TabIndex = 24;
			this.m_btnCancel.Text = "取消";
			this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(340, 404);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(80, 30);
			this.m_btnSave.TabIndex = 23;
			this.m_btnSave.Text = "确定";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_btnRightParentThesis
			// 
			this.m_btnRightParentThesis.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnRightParentThesis.DefaultScheme = true;
			this.m_btnRightParentThesis.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnRightParentThesis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnRightParentThesis.Hint = "";
			this.m_btnRightParentThesis.Location = new System.Drawing.Point(520, 168);
			this.m_btnRightParentThesis.Name = "m_btnRightParentThesis";
			this.m_btnRightParentThesis.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnRightParentThesis.Size = new System.Drawing.Size(80, 30);
			this.m_btnRightParentThesis.TabIndex = 22;
			this.m_btnRightParentThesis.Text = ")";
			this.m_btnRightParentThesis.Click += new System.EventHandler(this.m_btnRightParentThesis_Click);
			// 
			// m_btnLeftParentThesis
			// 
			this.m_btnLeftParentThesis.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnLeftParentThesis.DefaultScheme = true;
			this.m_btnLeftParentThesis.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnLeftParentThesis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnLeftParentThesis.Hint = "";
			this.m_btnLeftParentThesis.Location = new System.Drawing.Point(408, 168);
			this.m_btnLeftParentThesis.Name = "m_btnLeftParentThesis";
			this.m_btnLeftParentThesis.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnLeftParentThesis.Size = new System.Drawing.Size(80, 30);
			this.m_btnLeftParentThesis.TabIndex = 21;
			this.m_btnLeftParentThesis.Text = "(";
			this.m_btnLeftParentThesis.Click += new System.EventHandler(this.m_btnLeftParentThesis_Click);
			// 
			// m_btnDivide
			// 
			this.m_btnDivide.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDivide.DefaultScheme = true;
			this.m_btnDivide.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDivide.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnDivide.Hint = "";
			this.m_btnDivide.Location = new System.Drawing.Point(300, 168);
			this.m_btnDivide.Name = "m_btnDivide";
			this.m_btnDivide.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDivide.Size = new System.Drawing.Size(80, 30);
			this.m_btnDivide.TabIndex = 20;
			this.m_btnDivide.Text = "/ 除";
			this.m_btnDivide.Click += new System.EventHandler(this.m_btnDivide_Click);
			// 
			// m_btnMultiply
			// 
			this.m_btnMultiply.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnMultiply.DefaultScheme = true;
			this.m_btnMultiply.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnMultiply.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnMultiply.Hint = "";
			this.m_btnMultiply.Location = new System.Drawing.Point(520, 128);
			this.m_btnMultiply.Name = "m_btnMultiply";
			this.m_btnMultiply.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnMultiply.Size = new System.Drawing.Size(80, 30);
			this.m_btnMultiply.TabIndex = 19;
			this.m_btnMultiply.Text = "* 乘";
			this.m_btnMultiply.Click += new System.EventHandler(this.m_btnMultiply_Click);
			// 
			// m_btnSubtract
			// 
			this.m_btnSubtract.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSubtract.DefaultScheme = true;
			this.m_btnSubtract.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSubtract.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnSubtract.Hint = "";
			this.m_btnSubtract.Location = new System.Drawing.Point(408, 128);
			this.m_btnSubtract.Name = "m_btnSubtract";
			this.m_btnSubtract.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSubtract.Size = new System.Drawing.Size(80, 30);
			this.m_btnSubtract.TabIndex = 18;
			this.m_btnSubtract.Text = "- 减";
			this.m_btnSubtract.Click += new System.EventHandler(this.m_btnSubtract_Click);
			// 
			// m_btnAdd
			// 
			this.m_btnAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnAdd.DefaultScheme = true;
			this.m_btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnAdd.Hint = "";
			this.m_btnAdd.Location = new System.Drawing.Point(300, 128);
			this.m_btnAdd.Name = "m_btnAdd";
			this.m_btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnAdd.Size = new System.Drawing.Size(80, 30);
			this.m_btnAdd.TabIndex = 17;
			this.m_btnAdd.Text = "+ 加";
			this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
			// 
			// m_lsvCheckItem
			// 
			this.m_lsvCheckItem.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lsvCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.m_chCheckItemShortName,
																							 this.m_chCheckItemName});
			this.m_lsvCheckItem.FullRowSelect = true;
			this.m_lsvCheckItem.GridLines = true;
			this.m_lsvCheckItem.HideSelection = false;
			this.m_lsvCheckItem.Location = new System.Drawing.Point(16, 156);
			this.m_lsvCheckItem.MultiSelect = false;
			this.m_lsvCheckItem.Name = "m_lsvCheckItem";
			this.m_lsvCheckItem.Size = new System.Drawing.Size(260, 240);
			this.m_lsvCheckItem.TabIndex = 16;
			this.m_lsvCheckItem.View = System.Windows.Forms.View.Details;
			this.m_lsvCheckItem.Click += new System.EventHandler(this.m_lsvCheckItem_Click);
			// 
			// m_chCheckItemShortName
			// 
			this.m_chCheckItemShortName.Text = "缩写";
			this.m_chCheckItemShortName.Width = 100;
			// 
			// m_chCheckItemName
			// 
			this.m_chCheckItemName.Text = "项目名称";
			this.m_chCheckItemName.Width = 150;
			// 
			// m_cboSampleType
			// 
			this.m_cboSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSampleType.Location = new System.Drawing.Point(152, 128);
			this.m_cboSampleType.Name = "m_cboSampleType";
			this.m_cboSampleType.Size = new System.Drawing.Size(124, 22);
			this.m_cboSampleType.TabIndex = 15;
			this.m_cboSampleType.SelectedIndexChanged += new System.EventHandler(this.m_cboSampleType_SelectedIndexChanged);
			// 
			// m_cboCheckCategory
			// 
			this.m_cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCheckCategory.Location = new System.Drawing.Point(12, 128);
			this.m_cboCheckCategory.Name = "m_cboCheckCategory";
			this.m_cboCheckCategory.Size = new System.Drawing.Size(128, 22);
			this.m_cboCheckCategory.TabIndex = 14;
			this.m_cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckCategory_SelectedIndexChanged);
			// 
			// m_btnLog
			// 
			this.m_btnLog.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnLog.DefaultScheme = true;
			this.m_btnLog.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnLog.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnLog.Hint = "";
			this.m_btnLog.Location = new System.Drawing.Point(300, 208);
			this.m_btnLog.Name = "m_btnLog";
			this.m_btnLog.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnLog.Size = new System.Drawing.Size(80, 30);
			this.m_btnLog.TabIndex = 26;
			this.m_btnLog.Text = "Log";
			this.m_btnLog.Click += new System.EventHandler(this.m_btnLog_Click);
			// 
			// m_btnPow
			// 
			this.m_btnPow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnPow.DefaultScheme = true;
			this.m_btnPow.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnPow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnPow.Hint = "";
			this.m_btnPow.Location = new System.Drawing.Point(408, 208);
			this.m_btnPow.Name = "m_btnPow";
			this.m_btnPow.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnPow.Size = new System.Drawing.Size(80, 30);
			this.m_btnPow.TabIndex = 27;
			this.m_btnPow.Text = "Pow";
			this.m_btnPow.Click += new System.EventHandler(this.m_btnPow_Click);
			// 
			// m_btnComma
			// 
			this.m_btnComma.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnComma.DefaultScheme = true;
			this.m_btnComma.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnComma.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnComma.Hint = "";
			this.m_btnComma.Location = new System.Drawing.Point(520, 208);
			this.m_btnComma.Name = "m_btnComma";
			this.m_btnComma.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnComma.Size = new System.Drawing.Size(80, 30);
			this.m_btnComma.TabIndex = 28;
			this.m_btnComma.Text = ",";
			this.m_btnComma.Click += new System.EventHandler(this.m_btnComma_Click);
			// 
			// frmFormula
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(626, 441);
			this.Controls.Add(this.m_btnComma);
			this.Controls.Add(this.m_btnPow);
			this.Controls.Add(this.m_btnLog);
			this.Controls.Add(this.m_txtInstruction);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnSave);
			this.Controls.Add(this.m_btnRightParentThesis);
			this.Controls.Add(this.m_btnLeftParentThesis);
			this.Controls.Add(this.m_btnDivide);
			this.Controls.Add(this.m_btnMultiply);
			this.Controls.Add(this.m_btnSubtract);
			this.Controls.Add(this.m_btnAdd);
			this.Controls.Add(this.m_lsvCheckItem);
			this.Controls.Add(this.m_cboSampleType);
			this.Controls.Add(this.m_cboCheckCategory);
			this.Controls.Add(this.m_rtbFormula);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "frmFormula";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "计算公式";
			this.Load += new System.EventHandler(this.frmFormula_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region 构造DataTable
		public void m_mthConstructDataTable()
		{
			m_dtbAddCheckItem = new DataTable("m_dtbAddCheckItem");
			m_dtbAddCheckItem.Columns.Add("CHECK_ITEM_ID_CHR",typeof(string));
			m_dtbAddCheckItem.Columns.Add("CHECK_ITEM_ENGLISH_NAME_VCHR",typeof(string));
		}
		#endregion

		#region 只能输入数字
		private void m_rtbFormula_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			 if(e.KeyChar == (char)Keys.Delete || e.KeyChar ==(char)Keys.Back || e.KeyChar ==(char)42 || e.KeyChar ==(char)47
				|| e.KeyChar == (char)43 || e.KeyChar ==(char)45 || e.KeyChar == (char)40 || e.KeyChar == (char)41)
			{
				 return;
			}
			if(!char.IsNumber(e.KeyChar)) e.Handled = true;
		}
		#endregion

		#region 初始化项目类别
		public void m_mthGetCheckItemCategory()
		{
			long lngRes = 0;
			DataTable dtbCheckItemCategory = null;
			lngRes = m_objManage.m_lngGetCheckCategory(out dtbCheckItemCategory);
			if(lngRes > 0 && dtbCheckItemCategory != null)
			{
				this.m_cboCheckCategory.DataSource = dtbCheckItemCategory;
				this.m_cboCheckCategory.DisplayMember = "CHECK_CATEGORY_DESC_VCHR";
				this.m_cboCheckCategory.ValueMember = "CHECK_CATEGORY_ID_CHR";
			}
		}
		#endregion

		#region 初始化样本类别
		public void m_mthGetSampleType()
		{
			long lngRes = 0;
			DataTable dtbSampleType = null;
			clsDomainController_SampleManage objDomain = new clsDomainController_SampleManage();
			lngRes = objDomain.m_lngGetSampleTypeList(out dtbSampleType);
			if(lngRes > 0 && dtbSampleType != null)
			{
				this.m_cboSampleType.DataSource = dtbSampleType;
				this.m_cboSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
				this.m_cboSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
			}
		}
		#endregion

		#region 初始化界面及数据
		private void frmFormula_Load(object sender, System.EventArgs e)
		{
			m_objManage = new clsDomainController_CheckItemManage();
			m_mthConstructDataTable();
			m_mthInitCheckItemTable(m_objViewer.m_strUserFormula);
			m_rtbFormula.Text = m_objViewer.m_strUserFormula;
			m_mthGetSampleType();
			m_mthGetCheckItemCategory();
			if(this.m_cboCheckCategory.Items.Count > 0 && this.m_cboSampleType.Items.Count > 0)
			{
				m_mthGetCheckItemByCondition();
			}
		}
		#endregion

		#region 根据检验类别和样本类别查询相应的检验项目
		public void m_mthGetCheckItemByCondition()
		{
			this.m_lsvCheckItem.Items.Clear();
			if(this.m_cboCheckCategory.Items.Count <= 0 || this.m_cboSampleType.Items.Count <= 0)
				return;
			long lngRes = 0;
			string strCheckCategory = this.m_cboCheckCategory.SelectedValue.ToString().Trim();
			string strSampleType = this.m_cboSampleType.SelectedValue.ToString().Trim();
			clsCheckItem_VO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetCheckItemArrByCondition(strCheckCategory,strSampleType,out objResultArr);
			if(lngRes > 0 && objResultArr != null)
			{
				if(objResultArr.Length > 0)
				{
					for(int i=0;i<objResultArr.Length;i++)
					{
						ListViewItem objlsvItem = new ListViewItem();
						objlsvItem.Text = objResultArr[i].m_strCheck_Item_English_Name;
						objlsvItem.SubItems.Add(objResultArr[i].m_strCheck_Item_Name);
						objlsvItem.Tag = objResultArr[i];
						this.m_lsvCheckItem.Items.Add(objlsvItem);
					}
				}
			}
		}
		#endregion

		#region 根据不同的检验类别查询相应的检验项目
		private void m_cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_mthGetCheckItemByCondition();
		}
		#endregion

		#region 根据不同的样本类别查询相应的检验项目
		private void m_cboSampleType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_mthGetCheckItemByCondition();
		}
		#endregion

		#region 添加检验项目到公式
		private void m_lsvCheckItem_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvCheckItem.SelectedItems.Count <= 0)
				return;
			string strCheckItemEnglishName = ((clsCheckItem_VO)this.m_lsvCheckItem.SelectedItems[0].Tag).m_strCheck_Item_English_Name.ToString().Trim();
			string strCheckItemID = ((clsCheckItem_VO)this.m_lsvCheckItem.SelectedItems[0].Tag).m_strCheck_Item_ID.ToString().Trim();
			string strCheckItem = "["+strCheckItemID+" "+strCheckItemEnglishName+"]";
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,"["+strCheckItemID+" "+strCheckItemEnglishName+"]");
			this.m_rtbFormula.SelectionStart = intIdx + strCheckItem.Length;
			this.m_rtbFormula.SelectionLength = 0;
			//添加选中的项目到DataTable
			DataRow[] drArr = null;
			if(m_dtbAddCheckItem.Rows.Count > 0)
			{
				drArr = m_dtbAddCheckItem.Select("CHECK_ITEM_ID_CHR = "+strCheckItemID);
			}
			if(drArr == null || drArr.Length <= 0)
			{
				DataRow dr = m_dtbAddCheckItem.NewRow();
				dr["CHECK_ITEM_ID_CHR"] = strCheckItemID;
				dr["CHECK_ITEM_ENGLISH_NAME_VCHR"] = strCheckItemEnglishName;
				m_dtbAddCheckItem.Rows.Add(dr);
			}
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 添加加号到公式
		private void m_btnAdd_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,"+");
			this.m_rtbFormula.SelectionStart = intIdx + 1;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 添加减号到公式
		private void m_btnSubtract_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,"-");
			this.m_rtbFormula.SelectionStart = intIdx + 1;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 添加乘号到公式
		private void m_btnMultiply_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,"*");
			this.m_rtbFormula.SelectionStart = intIdx + 1;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 添加除号到公式
		private void m_btnDivide_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,"/");
			this.m_rtbFormula.SelectionStart = intIdx + 1;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 添加左括号到公式
		private void m_btnLeftParentThesis_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,"(");
			this.m_rtbFormula.SelectionStart = intIdx + 1;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 添加右括号
		private void m_btnRightParentThesis_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,")");
			this.m_rtbFormula.SelectionStart = intIdx + 1;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 取消
		private void m_btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region 将界面显示的公式转换为内部公式
		public string m_mthTranslateFormula(string p_strFormula)
		{
			int intCurPos = 0;
			int intLeftIdx = 0;
			int intRightIdx = 0;
			string strInternalFormula = "";
			while(intCurPos < p_strFormula.Length)
			{
				intLeftIdx = p_strFormula.IndexOf("[",intCurPos);
				intRightIdx = p_strFormula.IndexOf("]",intCurPos);
				if(intLeftIdx > -1 && intRightIdx > -1)
				{
					if(intRightIdx>intLeftIdx)
					{
						if(intLeftIdx > 0)
						{
							strInternalFormula += p_strFormula.Substring(intCurPos,intLeftIdx-intCurPos);
						}
						string[] strItemArr = (p_strFormula.Substring(intLeftIdx+1,intRightIdx-intLeftIdx-1)).Split(new char[] {' '});
						if(strItemArr != null && strItemArr.Length == 2)
						{
							DataRow[] drArr = m_dtbAddCheckItem.Select("CHECK_ITEM_ID_CHR = '"+strItemArr[0]+"'");
							if(drArr.Length > 0)
							{
								if(drArr[0]["CHECK_ITEM_ID_CHR"].ToString().Trim() == strItemArr[0].Trim() && 
									drArr[0]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim() == strItemArr[1].Trim())
								{
									strInternalFormula += "["+strItemArr[0].Trim()+"]";
								}
								else
								{
									strInternalFormula = "&&&100&&&";
									break;
								}
							}
							else
							{
								//检验项目及其编号不一致
								strInternalFormula = "&&&100&&&";
								break;
							}
						}
						else
						{
							//非法的检验项目及其编号
							strInternalFormula = "&&&200&&&";
							break;
						}
					}
					else
					{
						//非法的公式
						strInternalFormula = "&&&300&&&";
						break;
					}
				}
				else
				{
					break;
				}
				intCurPos = intRightIdx+1;
			}

			if(strInternalFormula != "&&&100&&&" && strInternalFormula != "&&&200&&&" && strInternalFormula != "&&&300&&&")
			{
				if(intCurPos < p_strFormula.Length)
				{
					strInternalFormula += p_strFormula.Substring(intCurPos,p_strFormula.Length-intCurPos);
				}
			}

			if((intLeftIdx == -1 && intRightIdx >0) || (intLeftIdx > 0 && intRightIdx == -1))
			{
				//括号不匹配
				strInternalFormula = "&&&400&&&";
			}
			return strInternalFormula;
		}
		#endregion

		#region 初始化页面时初始化DataTable
		public void m_mthInitCheckItemTable(string p_strFormula)
		{
			if(p_strFormula == "")
			{
				return;
			}
			int intCurPos = 0;
			int intLeftIdx = 0;
			int intRightIdx = 0;
			while(intCurPos < p_strFormula.Length)
			{
				intLeftIdx = p_strFormula.IndexOf("[",intCurPos);
				intRightIdx = p_strFormula.IndexOf("]",intCurPos);
				if(intLeftIdx > -1 && intRightIdx > -1)
				{
					if(intRightIdx>intLeftIdx)
					{
						string[] strItemArr = (p_strFormula.Substring(intLeftIdx+1,intRightIdx-intLeftIdx-1)).Split(new char[] {' '});
						if(strItemArr != null && strItemArr.Length == 2)
						{
							DataRow dr = m_dtbAddCheckItem.NewRow();
							dr["CHECK_ITEM_ID_CHR"] = strItemArr[0].Trim();
							dr["CHECK_ITEM_ENGLISH_NAME_VCHR"] = strItemArr[1].Trim();
							m_dtbAddCheckItem.Rows.Add(dr);
						}
					}
				}
				else
				{
					break;
				}
				intCurPos = intRightIdx+1;
			}
		}
		#endregion

		#region 确定
		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			//转换公式
			string strInternalFormula = m_mthTranslateFormula(m_rtbFormula.Text.ToString().Trim());
			if(strInternalFormula == "&&&100&&&")
			{
				MessageBox.Show("检验项目及其编号不一致");
				return;
			}
			else if(strInternalFormula == "&&&200&&&")
			{
				MessageBox.Show("非法的检验项目及其编号");
				return;
			}
			else if(strInternalFormula == "&&&300&&&")
			{
				MessageBox.Show("非法的公式");
				return;
			}
			else if(strInternalFormula == "&&&400&&&")
			{
				MessageBox.Show("括号不匹配");
				return;
			}
			//判断公式的有效性
			try
			{
				new clsFormulaValidate(strInternalFormula).m_mthValidateFormula();
			}
			catch(Exception objEx)
			{
				MessageBox.Show(objEx.Message);
				return;
			}
			//将公式传回主窗体
			m_objViewer.m_strFormula = strInternalFormula;
			m_objViewer.m_strUserFormula = this.m_rtbFormula.Text.ToString().Trim();
			m_objViewer.txtFormula.Text = this.m_rtbFormula.Text.ToString().Trim();
			this.Close();
		}
		#endregion

		#region 获取主窗体
		public void m_mthSetParentApperance(com.digitalwave.iCare.gui.LIS.frmAddCheckItem infrmAddCheckItem)
		{
			m_objViewer = infrmAddCheckItem;
		}
		#endregion

		#region 添加Log函数
		private void m_btnLog_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,"Log()");
			this.m_rtbFormula.SelectionStart = intIdx + 4;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 添加Pow函数
		private void m_btnPow_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,"Pow(,)");
			this.m_rtbFormula.SelectionStart = intIdx + 4;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

		#region 添加逗号
		private void m_btnComma_Click(object sender, System.EventArgs e)
		{
			int intIdx = this.m_rtbFormula.SelectionStart;
			int intLength = this.m_rtbFormula.SelectionLength;
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Remove(intIdx,intLength);
			this.m_rtbFormula.Text = this.m_rtbFormula.Text.Insert(intIdx,",");
			this.m_rtbFormula.SelectionStart = intIdx + 1;
			this.m_rtbFormula.SelectionLength = 0;
			this.m_rtbFormula.Focus();
		}
		#endregion

	}

	#region 公式有效性判断

	public class clsFormulaValidate
	{
		string strExpression;
		int PreceedInd;
		public clsFormulaValidate(string p_strExpression)
		{
			strExpression = p_strExpression;
		}

		public void m_mthValidateFormula()
		{
			PreceedInd = -1;
			int CurPos = 0;
			StringBuilder ExpressionBuffer = new StringBuilder("");
			while (CurPos < strExpression.Length) 
			{
				string curChr = strExpression.Substring(CurPos,1);
				if ( curChr =="(")
				{
					if(this.PreceedInd == 1) //前面是)
					{
						throw new Exception("表达式"+ExpressionBuffer.ToString()+"的"+curChr+"位于"+CurPos.ToString()+"错误!");
					}
					else
					{
						if(this.PreceedInd == 2)
						{
							string strParenthesesCont = this.GetVarList(ref CurPos);
							ExpressionBuffer.Append("("+strParenthesesCont+")");
						}
						else
						{
							this.GetParenthesesContent(ref CurPos);
							this.PreceedInd = 1;
						}
					}
				}
				else if ("+-*/".IndexOf(curChr,0)>=0) //是"+-*/"之一
				{
					if (this.PreceedInd == 0) //前面是"+-*/"
						throw new Exception("表达式"+strExpression.ToString()+"的"+curChr+"位于"+CurPos.ToString()+"错误!");
					else if(CurPos == strExpression.Length-1)
					{
						throw new Exception("表达式"+strExpression.ToString()+"的"+curChr+"位于"+CurPos.ToString()+"错误!");
					}
					else if("*/".IndexOf(curChr,0) >=0 && CurPos == 0)//判断第一个字符是否是*/
					{
						throw new Exception("表达式"+strExpression.ToString()+curChr+"位于"+CurPos.ToString()+"错误!");
					}
					else if("+-".IndexOf(curChr,0) >=0 && CurPos == 0)  //考虑到第一个操作数是-3,+4的情况
					{
						ExpressionBuffer.Append(curChr);
						this.PreceedInd = 2;
					}
					else
					{
						//考虑到-[001],+[001]的情况
						if(ExpressionBuffer.ToString() != "")
						{
							m_mthValidateItem(ExpressionBuffer.ToString());
						}
						ExpressionBuffer = new StringBuilder("");
						this.PreceedInd = 0;
					}
				}
				else //其他情况,即不等于(和+-*/符号
				{
					if (this.PreceedInd ==1) //前面为)。这种情况也不允许。
						throw new Exception("表达式"+ExpressionBuffer.ToString()+"的"+curChr+"位于"+CurPos.ToString()+"错误!");
					else
					{
						ExpressionBuffer.Append(curChr);
						this.PreceedInd = 2;
					}
				}
				CurPos++;
			}
			if(ExpressionBuffer.ToString() != "")
			{
				m_mthValidateItem(ExpressionBuffer.ToString());
			}
		}

		//获取函数的参数表达式，中间可能有“,”号,返回结果还原为字符串
		private string GetVarList(ref int CurPos)
		{
			string result = "";
			string strParenthesesContent = DeParentheses(ref CurPos);
			string[] ItemList = strParenthesesContent.Split(new char[]{','});
			foreach (string oneItem in ItemList)
			{
				new clsFormulaValidate(oneItem).m_mthValidateFormula();
				result += "OK" + ",";
			}
			return result.Substring(0,result.Length-1);
		}

		//判断
		private void m_mthValidateItem(string OprandExp)
		{
			string numRegex = @"(^[+-]?[1-9][0-9]+.[0-9]+$)|((^[+-]?0.[0-9]+$))|(^[+-]?[1-9].[0-9]+$)|(^[+-]?[1-9]\d+$)|(^[+-]?[0-9]$)";
			string itemRegex = @"^[-+]*\[[a-zA-Z0-9]+\]$";
			string funcRegex = @"^[a-zA-Z]+[a-zA-Z0-9]*\([\[a-zA-Z0-9\]a-zA-Z0-9\.,]+\)$";
			try
			{
				if (Regex.Match(OprandExp,numRegex).Success) //表明是数值
				{
					
				}
				else if(Regex.Match(OprandExp,itemRegex).Success)
				{
					
				}
				else if(Regex.Match(OprandExp,funcRegex).Success)
				{
					try
					{
						int firstPosOf = OprandExp.IndexOf("(");
						string funcName = OprandExp.Substring(0,firstPosOf);
						string strParameters = OprandExp.Substring(firstPosOf+1,OprandExp.Length-firstPosOf-1);
						string[] strParaArr = strParameters.Split(new char[]{','});
						System.Reflection.MethodInfo[] theMathMethods = typeof(Math).GetMethods(System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.Public);
						bool blnIsMatchFunction = false;
						foreach(MethodInfo objMethodInfo in theMathMethods)
						{
							if(objMethodInfo.Name == funcName)
							{
								System.Reflection.ParameterInfo[] theMathMethodsPara = objMethodInfo.GetParameters();
								if(strParaArr.Length == theMathMethodsPara.Length)
								{
									blnIsMatchFunction = true;
								}
							}
						}
						if(!blnIsMatchFunction)
						{
							throw new Exception();
						}
					}
					catch(Exception objEx)
					{
						throw new Exception("公式中的函数的参数不匹配！",objEx);
					}
				}
				else
				{
					throw new Exception("公式中包含非法的操作数");
				}
			}
			catch(Exception objEx)
			{
				throw objEx;
			}			
		}

		private void GetParenthesesContent(ref int CurPos)
		{
			string strParenthesesContent = DeParentheses(ref CurPos);
			if(strParenthesesContent == "")//判断括号里面的值是否为空
			{
				throw new Exception("表达式中的括号的值不能为空!");
			}
			//在这里使用递归
			new clsFormulaValidate(strParenthesesContent).m_mthValidateFormula();
		}

		//去括号算法
		private string DeParentheses(ref int CurPos)
		{
			int leftParenthesesCount = 0;
			string curChr;
			StringBuilder strResult = new StringBuilder("");
			for (;;)
			{
				CurPos++;
				if (CurPos==strExpression.Length)
					throw new Exception("表达式中括符不匹配！");
				curChr = strExpression.Substring(CurPos,1);
				if ((curChr == ")")&&(leftParenthesesCount == 0))
					break;
				else if ((curChr == ")")&&(leftParenthesesCount != 0))
					leftParenthesesCount--;
				else if (curChr =="(" )
					leftParenthesesCount++;
				strResult.Append(curChr);
			}
			return strResult.ToString();
		}
	}
	#endregion
}
