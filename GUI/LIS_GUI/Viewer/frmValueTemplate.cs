using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// frmValueTemplate 的摘要说明。
	/// </summary>
	public class frmValueTemplate : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		public bool m_blnIsClose = false;
		public bool m_blnIsOpen = false;
		public bool m_blnIsChangeDefaultVal = false;

		public event dlgValueReturnEventHandler evtValueReturn;
		#region 控件声名

		private System.Windows.Forms.ColumnHeader m_chValue;
		internal System.Windows.Forms.ListView m_lsvTemplateAndValue;
		private System.Windows.Forms.ComboBox m_cboSampleType;
		internal System.Windows.Forms.CheckBox m_chkReuse;
		private System.Windows.Forms.Label m_lbSampleType;
		private System.Windows.Forms.Label m_lbCheckCategory;
		private System.Windows.Forms.GroupBox m_gpbBaseInfo;
		private System.Windows.Forms.Label m_lbTemplateName;
		private System.Windows.Forms.ComboBox m_cboCheckCategory;
		private int intFlag;
		private System.Windows.Forms.ContextMenu m_ctmValue;
		private System.Windows.Forms.MenuItem m_mniAdd;
		private System.Windows.Forms.MenuItem m_mniDel;
		private ArrayList arlModifyValue = new ArrayList();
		private ArrayList arlDelValue = new ArrayList();
		private ArrayList arlAddValue = new ArrayList();
		private com.digitalwave.iCare.gui.LIS.clsDomainController_CheckItemManage m_objManage = new clsDomainController_CheckItemManage();
		private com.digitalwave.iCare.ValueObject.clsLisValueTemplateItem_VO m_objOldTemplateItem = null;
		private com.digitalwave.iCare.ValueObject.clsLisValueTemplate_VO m_objRawTemplate = null;
		private com.digitalwave.iCare.ValueObject.clsLisValueTemplateDetail_VO[] m_objRawTemplateDetailArr = null;
		internal System.Windows.Forms.TextBox m_txtTemplateName;
		internal string m_strCheckCategory;
		internal string m_strSampleType;
		internal string m_strCheckItemID;
		internal string m_strCheckItemName;
		private PinkieControls.ButtonXP m_btnCancel;
		private bool blnAdded = false;
		private bool blnValue = true;
		private System.Windows.Forms.MenuItem m_mniModify;
		private System.Windows.Forms.ColumnHeader m_chDeaultValFlag;
		private System.Windows.Forms.MenuItem m_mmiDefaultVal;
		private System.Windows.Forms.MenuItem m_mniClearDefaultValue;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmValueTemplate()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_mthInitCheckCategory();
			m_mthInitSampleType();
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
			this.m_lsvTemplateAndValue = new System.Windows.Forms.ListView();
			this.m_chValue = new System.Windows.Forms.ColumnHeader();
			this.m_chDeaultValFlag = new System.Windows.Forms.ColumnHeader();
			this.m_ctmValue = new System.Windows.Forms.ContextMenu();
			this.m_mniAdd = new System.Windows.Forms.MenuItem();
			this.m_mniModify = new System.Windows.Forms.MenuItem();
			this.m_mniDel = new System.Windows.Forms.MenuItem();
			this.m_mmiDefaultVal = new System.Windows.Forms.MenuItem();
			this.m_lbTemplateName = new System.Windows.Forms.Label();
			this.m_txtTemplateName = new System.Windows.Forms.TextBox();
			this.m_cboSampleType = new System.Windows.Forms.ComboBox();
			this.m_cboCheckCategory = new System.Windows.Forms.ComboBox();
			this.m_chkReuse = new System.Windows.Forms.CheckBox();
			this.m_lbSampleType = new System.Windows.Forms.Label();
			this.m_lbCheckCategory = new System.Windows.Forms.Label();
			this.m_gpbBaseInfo = new System.Windows.Forms.GroupBox();
			this.m_btnCancel = new PinkieControls.ButtonXP();
			this.m_mniClearDefaultValue = new System.Windows.Forms.MenuItem();
			this.m_gpbBaseInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lsvTemplateAndValue
			// 
			this.m_lsvTemplateAndValue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									this.m_chValue,
																									this.m_chDeaultValFlag});
			this.m_lsvTemplateAndValue.ContextMenu = this.m_ctmValue;
			this.m_lsvTemplateAndValue.FullRowSelect = true;
			this.m_lsvTemplateAndValue.GridLines = true;
			this.m_lsvTemplateAndValue.HideSelection = false;
			this.m_lsvTemplateAndValue.LabelEdit = true;
			this.m_lsvTemplateAndValue.Location = new System.Drawing.Point(1, 136);
			this.m_lsvTemplateAndValue.MultiSelect = false;
			this.m_lsvTemplateAndValue.Name = "m_lsvTemplateAndValue";
			this.m_lsvTemplateAndValue.Size = new System.Drawing.Size(204, 304);
			this.m_lsvTemplateAndValue.TabIndex = 0;
			this.m_lsvTemplateAndValue.View = System.Windows.Forms.View.Details;
			this.m_lsvTemplateAndValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvTemplateAndValue_KeyDown);
			this.m_lsvTemplateAndValue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvTemplateAndValue_MouseUp);
			this.m_lsvTemplateAndValue.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.m_lsvTemplateAndValue_AfterLabelEdit);
			// 
			// m_chValue
			// 
			this.m_chValue.Text = "特征值";
			this.m_chValue.Width = 108;
			// 
			// m_chDeaultValFlag
			// 
			this.m_chDeaultValFlag.Text = "默认值标志";
			this.m_chDeaultValFlag.Width = 88;
			// 
			// m_ctmValue
			// 
			this.m_ctmValue.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.m_mniAdd,
																					   this.m_mniModify,
																					   this.m_mniDel,
																					   this.m_mmiDefaultVal,
																					   this.m_mniClearDefaultValue});
			// 
			// m_mniAdd
			// 
			this.m_mniAdd.Index = 0;
			this.m_mniAdd.Text = "新增";
			this.m_mniAdd.Click += new System.EventHandler(this.m_mniAdd_Click);
			// 
			// m_mniModify
			// 
			this.m_mniModify.Index = 1;
			this.m_mniModify.Text = "修改";
			this.m_mniModify.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// m_mniDel
			// 
			this.m_mniDel.Index = 2;
			this.m_mniDel.Text = "删除";
			this.m_mniDel.Click += new System.EventHandler(this.m_mniDel_Click);
			// 
			// m_mmiDefaultVal
			// 
			this.m_mmiDefaultVal.Index = 3;
			this.m_mmiDefaultVal.Text = "设为默认值";
			this.m_mmiDefaultVal.Click += new System.EventHandler(this.m_mmiDefaultVal_Click);
			// 
			// m_lbTemplateName
			// 
			this.m_lbTemplateName.AutoSize = true;
			this.m_lbTemplateName.Location = new System.Drawing.Point(12, 72);
			this.m_lbTemplateName.Name = "m_lbTemplateName";
			this.m_lbTemplateName.Size = new System.Drawing.Size(63, 19);
			this.m_lbTemplateName.TabIndex = 5;
			this.m_lbTemplateName.Text = "模板名称";
			// 
			// m_txtTemplateName
			// 
			this.m_txtTemplateName.Location = new System.Drawing.Point(80, 68);
			this.m_txtTemplateName.Name = "m_txtTemplateName";
			this.m_txtTemplateName.TabIndex = 6;
			this.m_txtTemplateName.Text = "";
			// 
			// m_cboSampleType
			// 
			this.m_cboSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSampleType.Location = new System.Drawing.Point(80, 20);
			this.m_cboSampleType.Name = "m_cboSampleType";
			this.m_cboSampleType.Size = new System.Drawing.Size(100, 22);
			this.m_cboSampleType.TabIndex = 9;
			this.m_cboSampleType.SelectedIndexChanged += new System.EventHandler(this.m_cboSampleType_SelectedIndexChanged);
			// 
			// m_cboCheckCategory
			// 
			this.m_cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCheckCategory.Location = new System.Drawing.Point(80, 44);
			this.m_cboCheckCategory.Name = "m_cboCheckCategory";
			this.m_cboCheckCategory.Size = new System.Drawing.Size(100, 22);
			this.m_cboCheckCategory.TabIndex = 10;
			this.m_cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckCategory_SelectedIndexChanged);
			// 
			// m_chkReuse
			// 
			this.m_chkReuse.Location = new System.Drawing.Point(16, 96);
			this.m_chkReuse.Name = "m_chkReuse";
			this.m_chkReuse.Size = new System.Drawing.Size(84, 24);
			this.m_chkReuse.TabIndex = 11;
			this.m_chkReuse.Text = "复用模板";
			this.m_chkReuse.CheckedChanged += new System.EventHandler(this.m_chkReuse_CheckedChanged);
			// 
			// m_lbSampleType
			// 
			this.m_lbSampleType.AutoSize = true;
			this.m_lbSampleType.Location = new System.Drawing.Point(12, 24);
			this.m_lbSampleType.Name = "m_lbSampleType";
			this.m_lbSampleType.Size = new System.Drawing.Size(63, 19);
			this.m_lbSampleType.TabIndex = 12;
			this.m_lbSampleType.Text = "样本类型";
			// 
			// m_lbCheckCategory
			// 
			this.m_lbCheckCategory.AutoSize = true;
			this.m_lbCheckCategory.Location = new System.Drawing.Point(12, 48);
			this.m_lbCheckCategory.Name = "m_lbCheckCategory";
			this.m_lbCheckCategory.Size = new System.Drawing.Size(63, 19);
			this.m_lbCheckCategory.TabIndex = 13;
			this.m_lbCheckCategory.Text = "检验类别";
			// 
			// m_gpbBaseInfo
			// 
			this.m_gpbBaseInfo.Controls.Add(this.m_btnCancel);
			this.m_gpbBaseInfo.Controls.Add(this.m_cboCheckCategory);
			this.m_gpbBaseInfo.Controls.Add(this.m_chkReuse);
			this.m_gpbBaseInfo.Controls.Add(this.m_txtTemplateName);
			this.m_gpbBaseInfo.Controls.Add(this.m_lbCheckCategory);
			this.m_gpbBaseInfo.Controls.Add(this.m_lbTemplateName);
			this.m_gpbBaseInfo.Controls.Add(this.m_lbSampleType);
			this.m_gpbBaseInfo.Controls.Add(this.m_cboSampleType);
			this.m_gpbBaseInfo.Location = new System.Drawing.Point(1, 4);
			this.m_gpbBaseInfo.Name = "m_gpbBaseInfo";
			this.m_gpbBaseInfo.Size = new System.Drawing.Size(204, 128);
			this.m_gpbBaseInfo.TabIndex = 14;
			this.m_gpbBaseInfo.TabStop = false;
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnCancel.DefaultScheme = true;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnCancel.Hint = "";
			this.m_btnCancel.Location = new System.Drawing.Point(108, 92);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnCancel.Size = new System.Drawing.Size(72, 32);
			this.m_btnCancel.TabIndex = 14;
			this.m_btnCancel.Text = "取消";
			this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
			// 
			// m_mniClearDefaultValue
			// 
			this.m_mniClearDefaultValue.Index = 4;
			this.m_mniClearDefaultValue.Text = "清除默认值";
			this.m_mniClearDefaultValue.Click += new System.EventHandler(this.m_mniClearDefaultValue_Click);
			// 
			// frmValueTemplate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(206, 443);
			this.Controls.Add(this.m_gpbBaseInfo);
			this.Controls.Add(this.m_lsvTemplateAndValue);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmValueTemplate";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "值模板";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmValueTemplate_Closing);
			this.Load += new System.EventHandler(this.frmValueTemplate_Load);
			this.Closed += new System.EventHandler(this.frmValueTemplate_Closed);
			this.m_gpbBaseInfo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

 		#region 初始化信息
		public void m_mthNewTemplate(string p_strCheckCategory,string p_strSampleType,string p_strCheckItemID,string p_strCheckItemName)
		{
			intFlag = 0;
			m_strCheckCategory = p_strCheckCategory;
			m_strSampleType = p_strSampleType;
			m_strCheckItemID = p_strCheckItemID;
			m_strCheckItemName = p_strCheckItemName;

			this.m_cboCheckCategory.SelectedValue = p_strCheckCategory;
			this.m_cboSampleType.SelectedValue = p_strSampleType;
			this.m_txtTemplateName.Text = m_strCheckItemName;
			this.m_chkReuse.Checked = false;
			this.Show();
			this.TopMost = true;
		}

		public bool m_mthShowTemplate(string p_strCheckItemID)
		{
			//保存上一次修改的记录
			m_mthSave();

			long lngRes = 0;
			m_strCheckItemID = p_strCheckItemID;
			this.m_chkReuse.Checked = false;

			m_objOldTemplateItem = null;
			m_objRawTemplate = null;
			m_objRawTemplateDetailArr = null;
			lngRes = m_objManage.m_lngGetAllTemplateInfoByCheckItemID(p_strCheckItemID,out m_objOldTemplateItem,
				out m_objRawTemplate,out m_objRawTemplateDetailArr);
			if(lngRes > 0 && m_objOldTemplateItem != null)
			{
				this.m_cboCheckCategory.SelectedValue = m_objRawTemplate.m_strCHECK_CATEGORY_ID_CHR;
				this.m_cboSampleType.SelectedValue = m_objRawTemplate.m_strSAMPLE_TYPE_ID_CHR;
				if(m_objRawTemplateDetailArr != null)
				{
					for(int i=0;i<m_objRawTemplateDetailArr.Length;i++)
					{
						ListViewItem objlsvItem = new ListViewItem(m_objRawTemplateDetailArr[i].m_strVALUE_VCHR);
						if(m_objRawTemplateDetailArr[i].m_intDEFAULT_VALUE_FLAG_INT == 1)
						{
							objlsvItem.SubItems.Add("√");
						}
						else
						{
							objlsvItem.SubItems.Add("");
						}
						objlsvItem.Tag = m_objRawTemplateDetailArr[i];
						this.m_lsvTemplateAndValue.Items.Add(objlsvItem);
					}
				}
				this.m_txtTemplateName.Tag = m_objOldTemplateItem.m_strTEMPLATE_ID_CHR;
				this.m_txtTemplateName.Text = m_objOldTemplateItem.m_strTEMPLATE_NAME_VCHR;
				this.m_chkReuse.Checked = false;
				intFlag = 1;
				this.Show();
				this.TopMost = true;
				return true;
			}
			else
			{
				return false;
			}
		}

		public void m_mthInitTemplate(string p_strCheckCategory,string p_strSampleType,string p_strCheckItemID,string p_strCheckItemName)
		{
			//保存上一次修改的记录
			m_mthSave();

			long lngRes = 0;
			m_strCheckCategory = p_strCheckCategory;
			m_strSampleType = p_strSampleType;
			m_strCheckItemID = p_strCheckItemID;
			m_strCheckItemName = p_strCheckItemName;

			this.m_cboCheckCategory.SelectedValue = p_strCheckCategory;
			this.m_cboSampleType.SelectedValue = p_strSampleType;
			this.m_chkReuse.Checked = false;

			m_objOldTemplateItem = null;
			m_objRawTemplate = null;
			m_objRawTemplateDetailArr = null;
			lngRes = m_objManage.m_lngGetAllTemplateInfoByCheckItemID(p_strCheckItemID,out m_objOldTemplateItem,
				out m_objRawTemplate,out m_objRawTemplateDetailArr);
			if(lngRes > 0 && m_objOldTemplateItem != null)
			{
				this.m_cboCheckCategory.SelectedValue = m_objRawTemplate.m_strCHECK_CATEGORY_ID_CHR;
				this.m_cboSampleType.SelectedValue = m_objRawTemplate.m_strSAMPLE_TYPE_ID_CHR;
				if(m_objRawTemplateDetailArr != null)
				{
					for(int i=0;i<m_objRawTemplateDetailArr.Length;i++)
					{
						ListViewItem objlsvItem = new ListViewItem(m_objRawTemplateDetailArr[i].m_strVALUE_VCHR);
						if(m_objRawTemplateDetailArr[i].m_intDEFAULT_VALUE_FLAG_INT == 1)
						{
							objlsvItem.SubItems.Add("√");
						}
						else
						{
							objlsvItem.SubItems.Add("");
						}
						objlsvItem.Tag = m_objRawTemplateDetailArr[i];
						this.m_lsvTemplateAndValue.Items.Add(objlsvItem);
					}
				}
				this.m_txtTemplateName.Tag = m_objOldTemplateItem.m_strTEMPLATE_ID_CHR;
				this.m_txtTemplateName.Text = m_objOldTemplateItem.m_strTEMPLATE_NAME_VCHR;
				this.m_chkReuse.Checked = false;
				intFlag = 1;
			}
			else
			{
				intFlag = 0;
				this.m_txtTemplateName.Text = p_strCheckItemName;
			}
			m_blnIsOpen = true;
			this.Show();
			this.TopMost = true;
		}

		//初始化检验类别
		public void m_mthInitCheckCategory()
		{
			long lngRes = 0;
			DataTable dtbCheckCategory = null;
			clsDomainController_CheckItemManage objCheckItemManage = new clsDomainController_CheckItemManage();
			lngRes = objCheckItemManage.m_lngGetCheckCategory(out dtbCheckCategory);
			if(lngRes > 0 && dtbCheckCategory != null && dtbCheckCategory.Rows.Count > 0)
			{
				this.m_cboCheckCategory.DataSource = dtbCheckCategory;
				this.m_cboCheckCategory.DisplayMember = "CHECK_CATEGORY_DESC_VCHR";
				this.m_cboCheckCategory.ValueMember = "CHECK_CATEGORY_ID_CHR";
			}
		}

		//初始化样本类型
		public void m_mthInitSampleType()
		{
			long lngRes = 0;
			DataTable dtbSampleType = null;
			clsDomainController_SampleManage objSampleManage = new clsDomainController_SampleManage();
			lngRes = objSampleManage.m_lngGetSampleTypeList(out dtbSampleType);
			if(lngRes > 0 && dtbSampleType != null && dtbSampleType.Rows.Count > 0)
			{
				this.m_cboSampleType.DataSource = dtbSampleType;
				this.m_cboSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
				this.m_cboSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
			}
		}

		private void frmValueTemplate_Load(object sender, System.EventArgs e)
		{
//			m_mthInitCheckCategory();
//			m_mthInitSampleType();
		}
		#endregion

		#region 值模板listView的右键菜单事件,和 SendValue
		private void m_lsvTemplateAndValue_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				m_mthSendValue();
			}
			else if(e.Button == MouseButtons.Right)
			{
				if(this.m_chkReuse.Checked)
				{
					this.m_lsvTemplateAndValue.ContextMenu = null;
				}
				else
				{
					this.m_lsvTemplateAndValue.ContextMenu = this.m_ctmValue;
				}
			}
		}
		#endregion

		#region 复用模板事件
		private void m_chkReuse_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_lsvTemplateAndValue.Items.Clear();
			if(this.m_chkReuse.Checked)
			{
				this.m_chValue.Text = "模板名称";
				this.m_lsvTemplateAndValue.LabelEdit = false;
				this.m_txtTemplateName.Tag = null;
				this.m_txtTemplateName.Text = "";
				m_mthGetTemplateInfoByCondition();
				blnValue = false;
				this.m_chValue.Width = 190;
				this.m_chDeaultValFlag.Width = 0;
			}
			else
			{
				this.m_chValue.Width = 100;
				this.m_chDeaultValFlag.Width = 90;
				blnValue = true;
				this.m_lsvTemplateAndValue.LabelEdit = true;
				this.m_chValue.Text = "特征值";
				if(m_objOldTemplateItem != null)
				{
					this.m_cboCheckCategory.SelectedValue = this.m_objRawTemplate.m_strCHECK_CATEGORY_ID_CHR;
					this.m_cboSampleType.SelectedValue = this.m_objRawTemplate.m_strSAMPLE_TYPE_ID_CHR;
					this.m_txtTemplateName.Text = m_objOldTemplateItem.m_strTEMPLATE_NAME_VCHR;
					this.m_txtTemplateName.Tag = m_objOldTemplateItem.m_strTEMPLATE_ID_CHR;
					for(int i=0;i<m_objRawTemplateDetailArr.Length;i++)
					{
						ListViewItem objlsvItem = new ListViewItem(m_objRawTemplateDetailArr[i].m_strVALUE_VCHR);
						if(m_objRawTemplateDetailArr[i].m_intDEFAULT_VALUE_FLAG_INT == 1)
						{
							objlsvItem.SubItems.Add("√");
						}
						else
						{
							objlsvItem.SubItems.Add("");
						}
						objlsvItem.Tag = m_objRawTemplateDetailArr[i];
						this.m_lsvTemplateAndValue.Items.Add(objlsvItem);
					}
				}
				else
				{
					this.m_txtTemplateName.Tag = null;
					this.m_txtTemplateName.Text = this.m_strCheckItemName;
				}
			}
			arlModifyValue.Clear();
			arlDelValue.Clear();
			arlAddValue.Clear();
		}
		#endregion

		#region 保存
		public void m_mthSave()
		{
			if(m_blnIsChangeDefaultVal || arlModifyValue.Count > 0 || blnAdded || arlDelValue.Count > 0 || this.m_chkReuse.Checked)
			{
				long lngRes = 0;
				if(intFlag == 0)
				{
					//1 完全新增
					if(this.m_chkReuse.Checked)
					{
						if(this.m_txtTemplateName.Tag == null)
							return;
						//1.2 复用模板
						clsLisValueTemplateItem_VO objNewTemplateItem = new clsLisValueTemplateItem_VO();
						objNewTemplateItem.m_strCHECK_ITEM_ID_CHR = m_strCheckItemID;
						objNewTemplateItem.m_strTEMPLATE_ID_CHR = this.m_txtTemplateName.Tag.ToString().Trim();
						lngRes = m_objManage.m_lngReuseTemplate(null,objNewTemplateItem);
					}
					else
					{
						//1.1 新增特征值
						clsLisValueTemplate_VO objValueTemplate = new clsLisValueTemplate_VO();
						objValueTemplate.m_strCHECK_CATEGORY_ID_CHR = m_strCheckCategory;
						objValueTemplate.m_strSAMPLE_TYPE_ID_CHR = m_strSampleType;
						objValueTemplate.m_strTEMPLATE_NAME_VCHR = this.m_txtTemplateName.Text.ToString().Trim();

						clsLisValueTemplateItem_VO objValueTemplateItem = new clsLisValueTemplateItem_VO();
						objValueTemplateItem.m_strCHECK_ITEM_ID_CHR = m_strCheckItemID;

						clsLisValueTemplateDetail_VO[] objVauleTemplateDetailArr = null;
						if(this.m_lsvTemplateAndValue.Items.Count > 0)
						{
							objVauleTemplateDetailArr = new clsLisValueTemplateDetail_VO[this.m_lsvTemplateAndValue.Items.Count];
							for(int i=0;i<this.m_lsvTemplateAndValue.Items.Count;i++)
							{
								objVauleTemplateDetailArr[i] = new clsLisValueTemplateDetail_VO();
								objVauleTemplateDetailArr[i].m_strVALUE_VCHR = this.m_lsvTemplateAndValue.Items[i].Text;
								if(this.m_lsvTemplateAndValue.Items[i].SubItems[1].Text.ToString().Trim() != "")
								{
									objVauleTemplateDetailArr[i].m_intDEFAULT_VALUE_FLAG_INT = 1;
								}
								else
								{
									objVauleTemplateDetailArr[i].m_intDEFAULT_VALUE_FLAG_INT = 0;
								}
							}
						}

						lngRes = m_objManage.m_lngAddNewCheckItemVauleTemplate(objValueTemplate,objValueTemplateItem,objVauleTemplateDetailArr);
					}
				}
				else if(intFlag == 1)
				{
					//2 在原有的基础上新增和修改
					if(this.m_chkReuse.Checked)
					{
						if(this.m_txtTemplateName.Tag == null)
							return;
						//1.2 复用模板
						clsLisValueTemplateItem_VO objNewTemplateItem = new clsLisValueTemplateItem_VO();
						objNewTemplateItem.m_strCHECK_ITEM_ID_CHR = m_strCheckItemID;
						objNewTemplateItem.m_strTEMPLATE_ID_CHR = this.m_txtTemplateName.Tag.ToString().Trim();
						lngRes = m_objManage.m_lngReuseTemplate(m_objOldTemplateItem,objNewTemplateItem);
					}
					else
					{
						string strTemplateID = "";
						string strIdx = "";
						for(int i=0;i<this.m_lsvTemplateAndValue.Items.Count;i++)
						{
							if(this.m_lsvTemplateAndValue.Items[i].Tag == null)
							{
								clsLisValueTemplateDetail_VO objValueTemplateDetail = new clsLisValueTemplateDetail_VO();
								objValueTemplateDetail.m_strTEMPLATE_ID_CHR = this.m_objOldTemplateItem.m_strTEMPLATE_ID_CHR;
								objValueTemplateDetail.m_strVALUE_VCHR = this.m_lsvTemplateAndValue.Items[i].Text.ToString().Trim();
								if(this.m_lsvTemplateAndValue.Items[i].SubItems[1].Text.ToString().Trim() != "")
								{
									objValueTemplateDetail.m_intDEFAULT_VALUE_FLAG_INT = 1;
								}
								else
								{
									objValueTemplateDetail.m_intDEFAULT_VALUE_FLAG_INT = 0;
								}
								arlAddValue.Add(objValueTemplateDetail);
							}
							else
							{
								if(this.m_lsvTemplateAndValue.Items[i].SubItems[1].Text.ToString().Trim() != "" && m_blnIsChangeDefaultVal)
								{
									strTemplateID = ((clsLisValueTemplateDetail_VO)this.m_lsvTemplateAndValue.Items[i].Tag).m_strTEMPLATE_ID_CHR;
									strIdx = ((clsLisValueTemplateDetail_VO)this.m_lsvTemplateAndValue.Items[i].Tag).m_intINDEX_INT.ToString().Trim();
								}
							}
						}
						lngRes = m_objManage.m_lngValueTemplateDetailArr(arlAddValue,arlDelValue,arlModifyValue,strTemplateID,strIdx);
					}
				}
			}

			arlModifyValue.Clear();
			arlDelValue.Clear();
			arlAddValue.Clear();
			this.m_chkReuse.Checked = false;
			blnValue = true;
			blnAdded = false;
			this.m_txtTemplateName.Clear();
			this.m_txtTemplateName.Tag = null;
			this.m_lsvTemplateAndValue.Items.Clear();
		}
		#endregion

		#region 新增
		public void m_mthAddNew()
		{
			blnAdded = true;
			this.m_lsvTemplateAndValue.Items.Add("");
			this.m_lsvTemplateAndValue.Items[this.m_lsvTemplateAndValue.Items.Count-1].BeginEdit();
			this.m_lsvTemplateAndValue.Items[this.m_lsvTemplateAndValue.Items.Count-1].SubItems.Add("");
		}

		private void m_mniAdd_Click(object sender, System.EventArgs e)
		{
			m_mthAddNew();
		}
		#endregion

		#region 修改
		public void m_mthModify(string p_strValue)
		{
			if(this.m_lsvTemplateAndValue.SelectedItems.Count <= 0)
				return;
			if(this.m_lsvTemplateAndValue.SelectedItems[0].Tag != null)
			{
				clsLisValueTemplateDetail_VO objTemplateDetail = new clsLisValueTemplateDetail_VO();
				objTemplateDetail.m_intINDEX_INT = ((clsLisValueTemplateDetail_VO)this.m_lsvTemplateAndValue.SelectedItems[0].Tag).m_intINDEX_INT;
				objTemplateDetail.m_intSEQ_INT = ((clsLisValueTemplateDetail_VO)this.m_lsvTemplateAndValue.SelectedItems[0].Tag).m_intSEQ_INT;
				objTemplateDetail.m_strTEMPLATE_ID_CHR = ((clsLisValueTemplateDetail_VO)this.m_lsvTemplateAndValue.SelectedItems[0].Tag).m_strTEMPLATE_ID_CHR;
				objTemplateDetail.m_strVALUE_VCHR = p_strValue;
				bool blnModified = false;
				for(int i=0;i<arlModifyValue.Count;i++)
				{
					if(((clsLisValueTemplateDetail_VO)arlModifyValue[i]).m_strTEMPLATE_ID_CHR == objTemplateDetail.m_strTEMPLATE_ID_CHR)
					{
						blnModified = true;
						((clsLisValueTemplateDetail_VO)arlModifyValue[i]).m_strVALUE_VCHR = p_strValue;
						break;
					}
				}
				if(!blnModified)
				{
					arlModifyValue.Add(objTemplateDetail);
				}
			}
		}

		private void m_lsvTemplateAndValue_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
		{
			if(e.Label != null)
			{
				m_mthModify(e.Label.ToString().Trim());
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvTemplateAndValue.SelectedItems.Count <= 0)
				return;
			this.m_lsvTemplateAndValue.SelectedItems[0].BeginEdit();
		}
		#endregion

		#region 删除
		public void m_mthDel()
		{
			if(this.m_lsvTemplateAndValue.SelectedItems.Count <= 0)
				return;
			if(this.m_lsvTemplateAndValue.SelectedItems[0].Tag == null)
			{
				//1 新增项 直接删除
				this.m_lsvTemplateAndValue.SelectedItems[0].Remove();
			}
			else
			{
				//2 原有项 暂存临时变量中
				clsLisValueTemplateDetail_VO objTemplateDetail = (clsLisValueTemplateDetail_VO)this.m_lsvTemplateAndValue.SelectedItems[0].Tag;
				arlDelValue.Add(objTemplateDetail);
				this.m_lsvTemplateAndValue.SelectedItems[0].Remove();
			}
		}
		
		private void m_mniDel_Click(object sender, System.EventArgs e)
		{
			m_mthDel();
		}
		#endregion

		#region 根据检验项目类别和样本类别获取相应的模板信息
		public void m_mthGetTemplateInfoByCondition()
		{
			if(this.m_cboCheckCategory.Items.Count <= 0 || this.m_cboSampleType.Items.Count <= 0 || this.m_chkReuse.Checked == false)
				return;

			this.m_lsvTemplateAndValue.Items.Clear();
			string strCheckCategory = this.m_cboCheckCategory.SelectedValue.ToString().Trim();
			string strSampleType = this.m_cboSampleType.SelectedValue.ToString().Trim();
			long lngRes = 0;
			clsLisValueTemplate_VO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetTemplateInfoByCondition(strCheckCategory,strSampleType,out objResultArr);

			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem(objResultArr[i].m_strTEMPLATE_NAME_VCHR);
					objlsvItem.Tag = objResultArr[i];
					this.m_lsvTemplateAndValue.Items.Add(objlsvItem);
				}
			}
		}

		private void m_cboSampleType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_mthGetTemplateInfoByCondition();
		}

		private void m_cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_mthGetTemplateInfoByCondition();
		}
		#endregion

		#region 根据模板ID查询相应的模板明细信息
		public void m_mthGetTemplateDetailByTemplateID(string p_strTemplateID,out clsLisValueTemplateDetail_VO[] p_objResultArr)
		{;
			long lngRes = 0;
			lngRes = m_objManage.m_lngGetTemplateDetailByTemplateID(p_strTemplateID,out p_objResultArr);

			this.m_lsvTemplateAndValue.Items.Clear();

			if(lngRes > 0 && p_objResultArr != null && p_objResultArr.Length > 0)
			{
				for(int i=0;i<p_objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem(p_objResultArr[i].m_strVALUE_VCHR);
					if(p_objResultArr[i].m_intINDEX_INT == 1)
					{
						objlsvItem.SubItems.Add("√");
					}
					else
					{
						objlsvItem.SubItems.Add("");
					}
					objlsvItem.Tag = p_objResultArr[i];
					this.m_lsvTemplateAndValue.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 窗口关闭事件
		private void frmValueTemplate_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!m_blnIsClose)
			{
				e.Cancel = true;
				m_blnIsOpen = false;
				this.Hide();
			}
			
		}
		private void frmValueTemplate_Closed(object sender, System.EventArgs e)
		{
			if(m_blnIsChangeDefaultVal || arlModifyValue.Count > 0 || blnAdded || arlDelValue.Count > 0 || this.m_chkReuse.Checked)
			{
				this.m_mthSave();
			}
		}
		
		#endregion

		#region 取消
		private void m_btnCancel_Click(object sender, System.EventArgs e)
		{
			arlModifyValue.Clear();
			arlDelValue.Clear();
			arlAddValue.Clear();
			this.m_chkReuse.Checked = false;
			blnValue = true;
			blnAdded = false;
			this.m_txtTemplateName.Clear();
			this.m_txtTemplateName.Tag = null;
			this.m_lsvTemplateAndValue.Items.Clear();
			m_blnIsChangeDefaultVal = false;

			if(intFlag == 1)
			{
				this.m_cboCheckCategory.SelectedValue = this.m_objRawTemplate.m_strCHECK_CATEGORY_ID_CHR;
				this.m_cboSampleType.SelectedValue = this.m_objRawTemplate.m_strSAMPLE_TYPE_ID_CHR;
				this.m_txtTemplateName.Text = m_objOldTemplateItem.m_strTEMPLATE_NAME_VCHR;
				this.m_txtTemplateName.Tag = m_objOldTemplateItem.m_strTEMPLATE_ID_CHR;
                if (m_objRawTemplateDetailArr == null) { return; }
				for(int i=0;i<m_objRawTemplateDetailArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem(m_objRawTemplateDetailArr[i].m_strVALUE_VCHR);
					if(m_objRawTemplateDetailArr[i].m_intDEFAULT_VALUE_FLAG_INT == 1)
					{
						objlsvItem.SubItems.Add("√");
					}
					else
					{
						objlsvItem.SubItems.Add("");
					}
					objlsvItem.Tag = m_objRawTemplateDetailArr[i];
					this.m_lsvTemplateAndValue.Items.Add(objlsvItem);
				}
			}
			else
			{
				this.m_txtTemplateName.Text = this.m_strCheckItemName;
			}
		}
		#endregion

		#region 设默认值
		private void m_mmiDefaultVal_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvTemplateAndValue.SelectedItems.Count <= 0)
				return;
			for(int i=0;i<this.m_lsvTemplateAndValue.Items.Count;i++)
			{
				this.m_lsvTemplateAndValue.Items[i].SubItems[1].Text = "";
			}
			this.m_lsvTemplateAndValue.SelectedItems[0].SubItems[1].Text = "√";
			m_blnIsChangeDefaultVal = true;
		}
		#endregion

		#region 清除默认值
		private void m_mniClearDefaultValue_Click(object sender, System.EventArgs e)
		{
			long lngRes = 0;
			if(this.m_txtTemplateName.Tag != null)
			{
				string strTemplateID = this.m_txtTemplateName.Tag.ToString().Trim();
				lngRes = m_objManage.m_lngSetDefaultFlagByTemplateID(strTemplateID,0);
			}
			else
			{
				lngRes = 1;
			}
			if(lngRes > 0)
			{
				for(int i=0;i<this.m_lsvTemplateAndValue.Items.Count;i++)
				{
					this.m_lsvTemplateAndValue.Items[i].SubItems[1].Text = "";
				}
			}
		}
		#endregion

		private void m_lsvTemplateAndValue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
				m_mthSendValue();
		}
		private void m_mthSendValue()
		{
			if(this.m_lsvTemplateAndValue.SelectedItems.Count <= 0)
				return;
			if(!blnValue)
			{
				this.m_chValue.Width = 100;
				this.m_chDeaultValFlag.Width = 90;
				this.m_txtTemplateName.Text = ((clsLisValueTemplate_VO)this.m_lsvTemplateAndValue.SelectedItems[0].Tag).m_strTEMPLATE_NAME_VCHR;
				this.m_txtTemplateName.Tag = ((clsLisValueTemplate_VO)this.m_lsvTemplateAndValue.SelectedItems[0].Tag).m_strTEMPLATE_ID_CHR;
				clsLisValueTemplateDetail_VO[] objResultArr = null;
				m_mthGetTemplateDetailByTemplateID(((clsLisValueTemplate_VO)this.m_lsvTemplateAndValue.SelectedItems[0].Tag).m_strTEMPLATE_ID_CHR,
					out objResultArr);
				blnValue = true;
			}
			else
			{
				clsValueReturnArgs ee = new clsValueReturnArgs(this.m_lsvTemplateAndValue.SelectedItems[0].Text.Trim());
				if(this.evtValueReturn != null)
				{
					evtValueReturn(this,ee);
				}
			}
		}
		public void m_mthFoucsItem()
		{
			this.m_lsvTemplateAndValue.Focus();
			if(this.m_lsvTemplateAndValue.SelectedItems.Count >0)
			{
				this.m_lsvTemplateAndValue.SelectedItems[0].Focused = true;
				this.m_lsvTemplateAndValue.SelectedItems[0].EnsureVisible();
			}
			else
			{
				if(this.m_lsvTemplateAndValue.Items.Count >0)
				{
					this.m_lsvTemplateAndValue.Items[0].Selected = true;
					this.m_lsvTemplateAndValue.Items[0].Focused = true;
				}
			}
		}
	}
	public class clsValueReturnArgs : System.EventArgs
	{
		private string strValue;
		public string StrValue
		{
			get
			{
				return strValue;
			}
		}
		public clsValueReturnArgs(string p_strValue)
		{
			this.strValue = p_strValue;
		}
	}
	public delegate void dlgValueReturnEventHandler(object sender,clsValueReturnArgs e);
}
