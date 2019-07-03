using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// Summary description for frmDeptDetailInfo.
	/// </summary>
	public class frmDeptDetailInfo : iCare.iCareBaseForm.frmBaseForm
	{
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCategory;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDeptID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDeptName;
		protected System.Windows.Forms.Label lblDeptIDTitle;
		protected System.Windows.Forms.Label lblDeptNameTitle;
		protected System.Windows.Forms.Label lblCategoryTitle;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboInPatientOrOutPatient;
		protected System.Windows.Forms.Label lblInPatientOrOutPatientTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtAddress;
		protected System.Windows.Forms.Label lblAddressTitle;
		protected System.Windows.Forms.Label lblPYCodeTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPYCode;
		protected System.Windows.Forms.Label lblShortNOTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtShortNO;
		private PinkieControls.ButtonXP m_cmdCancel;
		private PinkieControls.ButtonXP buttonXP1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDeptDetailInfo()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_cboCategory.ClearItem();
			m_cboInPatientOrOutPatient.ClearItem();
			m_cboCategory.AddRangeItems(new string[]{"临床","辅助"});
			m_cboInPatientOrOutPatient.AddRangeItems(new string[]{"门诊","住院","检验"});
			m_cboCategory.SelectedIndex=0;
			m_cboInPatientOrOutPatient.SelectedIndex=0;
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_objDept_Desc=null;			
		}
		public frmDeptDetailInfo(clsDept_Desc p_objDept_Desc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_cboCategory.ClearItem();
			m_cboInPatientOrOutPatient.ClearItem();
			m_cboCategory.AddRangeItems(new string[]{"临床","辅助"});
			m_cboInPatientOrOutPatient.AddRangeItems(new string[]{"门诊","住院","检验"});
			m_cboCategory.SelectedIndex=0;
			m_cboInPatientOrOutPatient.SelectedIndex=0;
			

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_objDept_Desc=p_objDept_Desc;
			m_mthSetGUIFromContent(p_objDept_Desc);
		}
		private clsDept_Desc m_objDept_Desc;
		private ctlHighLightFocus m_objHighLight=new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDeptDetailInfo));
			this.m_cboCategory = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtDeptID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtDeptName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblDeptIDTitle = new System.Windows.Forms.Label();
			this.lblDeptNameTitle = new System.Windows.Forms.Label();
			this.lblCategoryTitle = new System.Windows.Forms.Label();
			this.m_cboInPatientOrOutPatient = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblInPatientOrOutPatientTitle = new System.Windows.Forms.Label();
			this.m_txtAddress = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblAddressTitle = new System.Windows.Forms.Label();
			this.lblPYCodeTitle = new System.Windows.Forms.Label();
			this.m_txtPYCode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblShortNOTitle = new System.Windows.Forms.Label();
			this.m_txtShortNO = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// m_cboCategory
			// 
			this.m_cboCategory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboCategory.BorderColor = System.Drawing.Color.Black;
			this.m_cboCategory.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboCategory.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboCategory.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCategory.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCategory.ForeColor = System.Drawing.Color.Black;
			this.m_cboCategory.ListBackColor = System.Drawing.Color.White;
			this.m_cboCategory.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboCategory.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboCategory.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboCategory.Location = new System.Drawing.Point(122, 62);
			this.m_cboCategory.m_BlnEnableItemEventMenu = true;
			this.m_cboCategory.Name = "m_cboCategory";
			this.m_cboCategory.SelectedIndex = -1;
			this.m_cboCategory.SelectedItem = null;
			this.m_cboCategory.Size = new System.Drawing.Size(120, 23);
			this.m_cboCategory.TabIndex = 2;
			this.m_cboCategory.TextBackColor = System.Drawing.Color.White;
			this.m_cboCategory.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtDeptID
			// 
			this.m_txtDeptID.BackColor = System.Drawing.Color.White;
			this.m_txtDeptID.BorderColor = System.Drawing.Color.White;
			this.m_txtDeptID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDeptID.ForeColor = System.Drawing.Color.Black;
			this.m_txtDeptID.Location = new System.Drawing.Point(122, 18);
			this.m_txtDeptID.Name = "m_txtDeptID";
			this.m_txtDeptID.ReadOnly = true;
			this.m_txtDeptID.Size = new System.Drawing.Size(120, 23);
			this.m_txtDeptID.TabIndex = 0;
			this.m_txtDeptID.Text = "";
			// 
			// m_txtDeptName
			// 
			this.m_txtDeptName.BackColor = System.Drawing.Color.White;
			this.m_txtDeptName.BorderColor = System.Drawing.Color.White;
			this.m_txtDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDeptName.ForeColor = System.Drawing.Color.Black;
			this.m_txtDeptName.Location = new System.Drawing.Point(346, 18);
			this.m_txtDeptName.Name = "m_txtDeptName";
			this.m_txtDeptName.Size = new System.Drawing.Size(152, 23);
			this.m_txtDeptName.TabIndex = 1;
			this.m_txtDeptName.Text = "";
			// 
			// lblDeptIDTitle
			// 
			this.lblDeptIDTitle.AutoSize = true;
			this.lblDeptIDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDeptIDTitle.Location = new System.Drawing.Point(42, 22);
			this.lblDeptIDTitle.Name = "lblDeptIDTitle";
			this.lblDeptIDTitle.Size = new System.Drawing.Size(70, 19);
			this.lblDeptIDTitle.TabIndex = 6076;
			this.lblDeptIDTitle.Text = "科室编号:";
			// 
			// lblDeptNameTitle
			// 
			this.lblDeptNameTitle.AutoSize = true;
			this.lblDeptNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDeptNameTitle.Location = new System.Drawing.Point(262, 22);
			this.lblDeptNameTitle.Name = "lblDeptNameTitle";
			this.lblDeptNameTitle.Size = new System.Drawing.Size(70, 19);
			this.lblDeptNameTitle.TabIndex = 6075;
			this.lblDeptNameTitle.Text = "科室名称:";
			// 
			// lblCategoryTitle
			// 
			this.lblCategoryTitle.AutoSize = true;
			this.lblCategoryTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCategoryTitle.Location = new System.Drawing.Point(42, 66);
			this.lblCategoryTitle.Name = "lblCategoryTitle";
			this.lblCategoryTitle.Size = new System.Drawing.Size(41, 19);
			this.lblCategoryTitle.TabIndex = 6074;
			this.lblCategoryTitle.Text = "种类:";
			// 
			// m_cboInPatientOrOutPatient
			// 
			this.m_cboInPatientOrOutPatient.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboInPatientOrOutPatient.BorderColor = System.Drawing.Color.Black;
			this.m_cboInPatientOrOutPatient.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboInPatientOrOutPatient.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboInPatientOrOutPatient.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboInPatientOrOutPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboInPatientOrOutPatient.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboInPatientOrOutPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboInPatientOrOutPatient.ForeColor = System.Drawing.Color.Black;
			this.m_cboInPatientOrOutPatient.ListBackColor = System.Drawing.Color.White;
			this.m_cboInPatientOrOutPatient.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboInPatientOrOutPatient.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboInPatientOrOutPatient.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboInPatientOrOutPatient.Location = new System.Drawing.Point(346, 62);
			this.m_cboInPatientOrOutPatient.m_BlnEnableItemEventMenu = true;
			this.m_cboInPatientOrOutPatient.Name = "m_cboInPatientOrOutPatient";
			this.m_cboInPatientOrOutPatient.SelectedIndex = -1;
			this.m_cboInPatientOrOutPatient.SelectedItem = null;
			this.m_cboInPatientOrOutPatient.Size = new System.Drawing.Size(152, 23);
			this.m_cboInPatientOrOutPatient.TabIndex = 3;
			this.m_cboInPatientOrOutPatient.TextBackColor = System.Drawing.Color.White;
			this.m_cboInPatientOrOutPatient.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblInPatientOrOutPatientTitle
			// 
			this.lblInPatientOrOutPatientTitle.AutoSize = true;
			this.lblInPatientOrOutPatientTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInPatientOrOutPatientTitle.Location = new System.Drawing.Point(262, 66);
			this.lblInPatientOrOutPatientTitle.Name = "lblInPatientOrOutPatientTitle";
			this.lblInPatientOrOutPatientTitle.Size = new System.Drawing.Size(41, 19);
			this.lblInPatientOrOutPatientTitle.TabIndex = 6074;
			this.lblInPatientOrOutPatientTitle.Text = "性质:";
			// 
			// m_txtAddress
			// 
			this.m_txtAddress.BackColor = System.Drawing.Color.White;
			this.m_txtAddress.BorderColor = System.Drawing.Color.White;
			this.m_txtAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtAddress.ForeColor = System.Drawing.Color.Black;
			this.m_txtAddress.Location = new System.Drawing.Point(122, 142);
			this.m_txtAddress.Name = "m_txtAddress";
			this.m_txtAddress.Size = new System.Drawing.Size(376, 23);
			this.m_txtAddress.TabIndex = 6;
			this.m_txtAddress.Text = "";
			// 
			// lblAddressTitle
			// 
			this.lblAddressTitle.AutoSize = true;
			this.lblAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAddressTitle.Location = new System.Drawing.Point(42, 146);
			this.lblAddressTitle.Name = "lblAddressTitle";
			this.lblAddressTitle.Size = new System.Drawing.Size(41, 19);
			this.lblAddressTitle.TabIndex = 6075;
			this.lblAddressTitle.Text = "地址:";
			// 
			// lblPYCodeTitle
			// 
			this.lblPYCodeTitle.AutoSize = true;
			this.lblPYCodeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPYCodeTitle.Location = new System.Drawing.Point(42, 106);
			this.lblPYCodeTitle.Name = "lblPYCodeTitle";
			this.lblPYCodeTitle.Size = new System.Drawing.Size(56, 19);
			this.lblPYCodeTitle.TabIndex = 6076;
			this.lblPYCodeTitle.Text = "拼音码:";
			// 
			// m_txtPYCode
			// 
			this.m_txtPYCode.BackColor = System.Drawing.Color.White;
			this.m_txtPYCode.BorderColor = System.Drawing.Color.White;
			this.m_txtPYCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPYCode.ForeColor = System.Drawing.Color.Black;
			this.m_txtPYCode.Location = new System.Drawing.Point(122, 102);
			this.m_txtPYCode.Name = "m_txtPYCode";
			this.m_txtPYCode.Size = new System.Drawing.Size(120, 23);
			this.m_txtPYCode.TabIndex = 4;
			this.m_txtPYCode.Text = "";
			// 
			// lblShortNOTitle
			// 
			this.lblShortNOTitle.AutoSize = true;
			this.lblShortNOTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblShortNOTitle.Location = new System.Drawing.Point(262, 106);
			this.lblShortNOTitle.Name = "lblShortNOTitle";
			this.lblShortNOTitle.Size = new System.Drawing.Size(41, 19);
			this.lblShortNOTitle.TabIndex = 6076;
			this.lblShortNOTitle.Text = "短称:";
			// 
			// m_txtShortNO
			// 
			this.m_txtShortNO.BackColor = System.Drawing.Color.White;
			this.m_txtShortNO.BorderColor = System.Drawing.Color.White;
			this.m_txtShortNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtShortNO.ForeColor = System.Drawing.Color.Black;
			this.m_txtShortNO.Location = new System.Drawing.Point(346, 102);
			this.m_txtShortNO.Name = "m_txtShortNO";
			this.m_txtShortNO.Size = new System.Drawing.Size(152, 23);
			this.m_txtShortNO.TabIndex = 5;
			this.m_txtShortNO.Text = "";
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(156, 182);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(92, 32);
			this.m_cmdCancel.TabIndex = 10000002;
			this.m_cmdCancel.Text = "确定(&O)";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// buttonXP1
			// 
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.ForeColor = System.Drawing.Color.Black;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(292, 182);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(92, 32);
			this.buttonXP1.TabIndex = 10000002;
			this.buttonXP1.Text = "取消(&C)";
			this.buttonXP1.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// frmDeptDetailInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(540, 233);
			this.Controls.Add(this.m_cmdCancel);
			this.Controls.Add(this.m_txtDeptID);
			this.Controls.Add(this.m_txtDeptName);
			this.Controls.Add(this.lblDeptIDTitle);
			this.Controls.Add(this.lblDeptNameTitle);
			this.Controls.Add(this.lblCategoryTitle);
			this.Controls.Add(this.lblInPatientOrOutPatientTitle);
			this.Controls.Add(this.m_txtAddress);
			this.Controls.Add(this.lblAddressTitle);
			this.Controls.Add(this.lblPYCodeTitle);
			this.Controls.Add(this.m_txtPYCode);
			this.Controls.Add(this.lblShortNOTitle);
			this.Controls.Add(this.m_txtShortNO);
			this.Controls.Add(this.buttonXP1);
			this.Controls.Add(this.m_cboCategory);
			this.Controls.Add(this.m_cboInPatientOrOutPatient);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeptDetailInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "科室详细信息";
			this.Load += new System.EventHandler(this.frmDeptDetailInfo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			clsDept_Desc objContent=m_objGetContentFromGUI();
			if(objContent !=null)
			{
				this.DialogResult=DialogResult.Yes;
				this.Close();
			}
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.None;
			this.Close();
		}

		public clsDept_Desc m_objGetContentValue()
		{
			if(this.DialogResult==DialogResult.Yes)
				return m_objDept_Desc;
			else return null;
		}

		/// <summary>
		/// 从界面获取记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		private  clsDept_Desc m_objGetContentFromGUI()
		{
			//界面参数校验
			if( this.m_txtDeptID.Text.Length>7 )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,科室编号不能大于7!");
				m_txtDeptID.Focus();
				return null;
			}
			
				
			if( this.m_txtDeptID.Text.Trim()=="" )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写完整科室编号!");
				m_txtDeptID.Focus();
				return null;
			}
			else if( this.m_txtDeptName.Text.Trim()=="")	
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写完整科室名称!");
				m_txtDeptName.Focus();
				return null;
			}
			else if(m_cboCategory.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请选择科室种类!");
				m_cboCategory.Focus();
				return null;
			}
			else if(m_cboInPatientOrOutPatient.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请选择科室性质!");
				m_cboInPatientOrOutPatient.Focus();
				return null;
			}
			
			//从界面获取表单值
			clsDept_Desc objContent=new clsDept_Desc();
			if(m_objDept_Desc==null)
			{
				objContent.m_dtmCreateDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
				objContent.m_dtmModifyDate=objContent.m_dtmCreateDate;	
			}
			else 
			{
				objContent.m_dtmCreateDate=m_objDept_Desc.m_dtmCreateDate;
				objContent.m_dtmModifyDate=	DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			}
			objContent.m_strAddress=m_txtAddress.Text.Trim();
			objContent.m_strCategory=m_cboCategory.SelectedIndex.ToString();					
			objContent.m_strInPatientOrOutPatient=m_cboInPatientOrOutPatient.SelectedIndex.ToString();
			objContent.m_strDeptID=m_txtDeptID.Text.Trim();
			objContent.m_strDeptName=m_txtDeptName.Text.Trim();
			objContent.m_strPYCode=m_txtPYCode.Text.Trim();
			objContent.m_strShortNO=m_txtShortNO.Text.Trim();
			objContent.m_strDeActivedOperatorID="";

			m_objDept_Desc=objContent;
			return objContent;	
		}

		/// <summary>
		/// 把记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		private  void m_mthSetGUIFromContent(clsDept_Desc p_objContent)
		{
			if(p_objContent ==null)
				return;
			
			m_txtAddress.Text=p_objContent.m_strAddress;
			
			m_cboCategory.SelectedIndex=p_objContent.m_strCategory== "临床" ? 0 : 1;					
			try
			{
				m_cboInPatientOrOutPatient.SelectedIndex=int.Parse(p_objContent.m_strInPatientOrOutPatient.Trim());
			}
			catch
			{
				if(p_objContent.m_strInPatientOrOutPatient=="门诊")
					m_cboInPatientOrOutPatient.SelectedIndex=0;
				else if(p_objContent.m_strInPatientOrOutPatient=="住院")
					m_cboInPatientOrOutPatient.SelectedIndex=1;
				if(p_objContent.m_strInPatientOrOutPatient=="检验")
					m_cboInPatientOrOutPatient.SelectedIndex=2;
			}
//			m_cboInPatientOrOutPatient.SelectedIndex=p_objContent.m_strInPatientOrOutPatient=="住院" ? 1:0;
			m_txtDeptID.Text=p_objContent.m_strDeptID;
			m_txtDeptName.Text=p_objContent.m_strDeptName;
			m_txtPYCode.Text=p_objContent.m_strPYCode;
			m_txtShortNO.Text=p_objContent.m_strShortNO;
		}

		#region 添加键盘快捷键
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter					
									
					if(sender.GetType().Name !="Button")
					{
						SendKeys.Send("{tab}");					
					}
					break;			
			
				case 113://save
					m_cmdOK_Click(null,null);
					break;
				case 114://del					
					break;
				case 115://print					
					break;
				case 116://refresh
					m_mthClearUp();
					break;
				case 117://Search					
					break;
			}	
		}

		private void m_mthClearUp()
		{
			m_txtAddress.Text="";			
			m_cboCategory.SelectedIndex=0;
			m_cboInPatientOrOutPatient.SelectedIndex=0;
			m_txtDeptID.Text="";
			m_txtDeptName.Text="";
			m_txtPYCode.Text="";
			m_txtShortNO.Text="";
		}

		
		#endregion

		private void frmDeptDetailInfo_Load(object sender, System.EventArgs e)
		{
			

			m_mthSetQuickKeys();
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

			m_txtDeptID.Focus();
		}
	}
}
