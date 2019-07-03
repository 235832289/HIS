using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmEmployeeDetailInfo.
	/// </summary>
	public class frmEmployeeDetailInfo : iCare.iCareBaseForm.frmBaseForm
	{
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboSex;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtName;
		protected System.Windows.Forms.Label lblNameTitle;
		protected System.Windows.Forms.Label lblSexTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtIDCard;
		protected System.Windows.Forms.Label lblIDCardTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTitleOfaTechnicalPost;
		protected System.Windows.Forms.Label lblTitleOfaTechnicalPostTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficePhone;
		protected System.Windows.Forms.Label lblOfficePhoneTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomePhone;
		protected System.Windows.Forms.Label lblHomePhoneTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomeAddress;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficeAddress;
		protected System.Windows.Forms.Label lblHomeAddressTitle;
		protected System.Windows.Forms.Label lblOfficeAddressTitle;
		protected System.Windows.Forms.Label lblHomePCTitle;
		protected System.Windows.Forms.Label lblOfficePCTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMobile;
		protected System.Windows.Forms.Label lblMobileTitle;
		protected System.Windows.Forms.Label lblEMailTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtEMail;
		protected System.Windows.Forms.Label lblEmployeeIDTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtEmployeeID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPYCode;
		protected System.Windows.Forms.Label lblPYCodeTitle;
		protected System.Windows.Forms.Label lblEducationalLevelTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtEducationalLevel;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMarried;
		protected System.Windows.Forms.Label lblMarriedTitle;
		protected System.Windows.Forms.Label lblLanguageAbilityTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLanguageAbility;
		protected System.Windows.Forms.Label label1;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFirstNameOfAnnouncer;
		protected System.Windows.Forms.Label lblFirstNameOfAnnouncerTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPhoneOfAnnouncer;
		protected System.Windows.Forms.Label lblPhoneOfAnnouncerTitle;
		protected System.Windows.Forms.Label lblExperienceTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExperience;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtRemark;
		protected System.Windows.Forms.Label lblRemarkTitle;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpBirth;
		private PinkieControls.ButtonXP buttonXP1;
		private PinkieControls.ButtonXP m_cmdCancel;
		private PinkieControls.ButtonXP m_cmdFireEmployee;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmEmployeeDetailInfo()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_objEmployee_BaseInfo=null;
			m_cmdFireEmployee.Visible=false;
		}

		public frmEmployeeDetailInfo(clsEmployee_BaseInfo p_objEmployee_BaseInfo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_objEmployee_BaseInfo=p_objEmployee_BaseInfo;
			m_mthSetGUIFromContent(p_objEmployee_BaseInfo);
		}
		private clsEmployee_BaseInfo m_objEmployee_BaseInfo;


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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmployeeDetailInfo));
			this.m_cboSex = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblNameTitle = new System.Windows.Forms.Label();
			this.lblSexTitle = new System.Windows.Forms.Label();
			this.m_txtIDCard = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblIDCardTitle = new System.Windows.Forms.Label();
			this.m_txtTitleOfaTechnicalPost = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblTitleOfaTechnicalPostTitle = new System.Windows.Forms.Label();
			this.m_txtOfficePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblOfficePhoneTitle = new System.Windows.Forms.Label();
			this.m_txtHomePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblHomePhoneTitle = new System.Windows.Forms.Label();
			this.m_txtHomeAddress = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtOfficeAddress = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblHomeAddressTitle = new System.Windows.Forms.Label();
			this.lblOfficeAddressTitle = new System.Windows.Forms.Label();
			this.lblHomePCTitle = new System.Windows.Forms.Label();
			this.lblOfficePCTitle = new System.Windows.Forms.Label();
			this.m_txtOfficePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtHomePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtMobile = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblMobileTitle = new System.Windows.Forms.Label();
			this.lblEMailTitle = new System.Windows.Forms.Label();
			this.m_txtEMail = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblEmployeeIDTitle = new System.Windows.Forms.Label();
			this.m_txtEmployeeID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtPYCode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblPYCodeTitle = new System.Windows.Forms.Label();
			this.lblEducationalLevelTitle = new System.Windows.Forms.Label();
			this.m_txtEducationalLevel = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtMarried = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblMarriedTitle = new System.Windows.Forms.Label();
			this.lblLanguageAbilityTitle = new System.Windows.Forms.Label();
			this.m_txtLanguageAbility = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtFirstNameOfAnnouncer = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblFirstNameOfAnnouncerTitle = new System.Windows.Forms.Label();
			this.m_txtPhoneOfAnnouncer = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblPhoneOfAnnouncerTitle = new System.Windows.Forms.Label();
			this.lblExperienceTitle = new System.Windows.Forms.Label();
			this.m_txtExperience = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtRemark = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblRemarkTitle = new System.Windows.Forms.Label();
			this.m_dtpBirth = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.m_cmdFireEmployee = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// m_cboSex
			// 
			this.m_cboSex.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboSex.BorderColor = System.Drawing.Color.Black;
			this.m_cboSex.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboSex.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboSex.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSex.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSex.ForeColor = System.Drawing.Color.Black;
			this.m_cboSex.ListBackColor = System.Drawing.Color.White;
			this.m_cboSex.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboSex.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboSex.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboSex.Location = new System.Drawing.Point(540, 18);
			this.m_cboSex.m_BlnEnableItemEventMenu = true;
			this.m_cboSex.Name = "m_cboSex";
			this.m_cboSex.SelectedIndex = -1;
			this.m_cboSex.SelectedItem = null;
			this.m_cboSex.Size = new System.Drawing.Size(80, 23);
			this.m_cboSex.TabIndex = 30;
			this.m_cboSex.TextBackColor = System.Drawing.Color.White;
			this.m_cboSex.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtName
			// 
			this.m_txtName.BackColor = System.Drawing.Color.White;
			this.m_txtName.BorderColor = System.Drawing.Color.White;
			this.m_txtName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtName.ForeColor = System.Drawing.Color.Black;
			this.m_txtName.Location = new System.Drawing.Point(316, 18);
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(120, 23);
			this.m_txtName.TabIndex = 20;
			this.m_txtName.Text = "";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.AutoSize = true;
			this.lblNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNameTitle.Location = new System.Drawing.Point(256, 20);
			this.lblNameTitle.Name = "lblNameTitle";
			this.lblNameTitle.Size = new System.Drawing.Size(48, 19);
			this.lblNameTitle.TabIndex = 522;
			this.lblNameTitle.Text = "姓 名:";
			this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.AutoSize = true;
			this.lblSexTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSexTitle.Location = new System.Drawing.Point(468, 20);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(56, 19);
			this.lblSexTitle.TabIndex = 515;
			this.lblSexTitle.Text = "性  别:";
			this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtIDCard
			// 
			this.m_txtIDCard.BackColor = System.Drawing.Color.White;
			this.m_txtIDCard.BorderColor = System.Drawing.Color.White;
			this.m_txtIDCard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtIDCard.ForeColor = System.Drawing.Color.Black;
			this.m_txtIDCard.Location = new System.Drawing.Point(124, 54);
			this.m_txtIDCard.MaxLength = 18;
			this.m_txtIDCard.Name = "m_txtIDCard";
			this.m_txtIDCard.Size = new System.Drawing.Size(152, 23);
			this.m_txtIDCard.TabIndex = 50;
			this.m_txtIDCard.Text = "";
			this.m_txtIDCard.TextChanged += new System.EventHandler(this.m_txtIDCard_TextChanged);
			// 
			// lblIDCardTitle
			// 
			this.lblIDCardTitle.AutoSize = true;
			this.lblIDCardTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblIDCardTitle.Location = new System.Drawing.Point(40, 56);
			this.lblIDCardTitle.Name = "lblIDCardTitle";
			this.lblIDCardTitle.Size = new System.Drawing.Size(70, 19);
			this.lblIDCardTitle.TabIndex = 521;
			this.lblIDCardTitle.Text = "身份证号:";
			this.lblIDCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtTitleOfaTechnicalPost
			// 
			this.m_txtTitleOfaTechnicalPost.BackColor = System.Drawing.Color.White;
			this.m_txtTitleOfaTechnicalPost.BorderColor = System.Drawing.Color.White;
			this.m_txtTitleOfaTechnicalPost.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTitleOfaTechnicalPost.ForeColor = System.Drawing.Color.Black;
			this.m_txtTitleOfaTechnicalPost.Location = new System.Drawing.Point(124, 90);
			this.m_txtTitleOfaTechnicalPost.Name = "m_txtTitleOfaTechnicalPost";
			this.m_txtTitleOfaTechnicalPost.Size = new System.Drawing.Size(152, 23);
			this.m_txtTitleOfaTechnicalPost.TabIndex = 80;
			this.m_txtTitleOfaTechnicalPost.Text = "";
			this.m_txtTitleOfaTechnicalPost.TextChanged += new System.EventHandler(this.m_txtTitleOfaTechnicalPost_TextChanged);
			// 
			// lblTitleOfaTechnicalPostTitle
			// 
			this.lblTitleOfaTechnicalPostTitle.AutoSize = true;
			this.lblTitleOfaTechnicalPostTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitleOfaTechnicalPostTitle.Location = new System.Drawing.Point(40, 92);
			this.lblTitleOfaTechnicalPostTitle.Name = "lblTitleOfaTechnicalPostTitle";
			this.lblTitleOfaTechnicalPostTitle.Size = new System.Drawing.Size(56, 19);
			this.lblTitleOfaTechnicalPostTitle.TabIndex = 520;
			this.lblTitleOfaTechnicalPostTitle.Text = "职  称:";
			this.lblTitleOfaTechnicalPostTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtOfficePhone
			// 
			this.m_txtOfficePhone.BackColor = System.Drawing.Color.White;
			this.m_txtOfficePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficePhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficePhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtOfficePhone.Location = new System.Drawing.Point(124, 126);
			this.m_txtOfficePhone.Name = "m_txtOfficePhone";
			this.m_txtOfficePhone.Size = new System.Drawing.Size(152, 23);
			this.m_txtOfficePhone.TabIndex = 120;
			this.m_txtOfficePhone.Text = "";
			this.m_txtOfficePhone.TextChanged += new System.EventHandler(this.m_txtOfficePhone_TextChanged);
			// 
			// lblOfficePhoneTitle
			// 
			this.lblOfficePhoneTitle.AutoSize = true;
			this.lblOfficePhoneTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePhoneTitle.Location = new System.Drawing.Point(40, 128);
			this.lblOfficePhoneTitle.Name = "lblOfficePhoneTitle";
			this.lblOfficePhoneTitle.Size = new System.Drawing.Size(70, 19);
			this.lblOfficePhoneTitle.TabIndex = 523;
			this.lblOfficePhoneTitle.Text = "办公电话:";
			this.lblOfficePhoneTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtHomePhone
			// 
			this.m_txtHomePhone.BackColor = System.Drawing.Color.White;
			this.m_txtHomePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtHomePhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomePhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtHomePhone.Location = new System.Drawing.Point(392, 126);
			this.m_txtHomePhone.Name = "m_txtHomePhone";
			this.m_txtHomePhone.Size = new System.Drawing.Size(132, 23);
			this.m_txtHomePhone.TabIndex = 130;
			this.m_txtHomePhone.Text = "";
			// 
			// lblHomePhoneTitle
			// 
			this.lblHomePhoneTitle.AutoSize = true;
			this.lblHomePhoneTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePhoneTitle.Location = new System.Drawing.Point(308, 128);
			this.lblHomePhoneTitle.Name = "lblHomePhoneTitle";
			this.lblHomePhoneTitle.Size = new System.Drawing.Size(70, 19);
			this.lblHomePhoneTitle.TabIndex = 526;
			this.lblHomePhoneTitle.Text = "家庭电话:";
			this.lblHomePhoneTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtHomeAddress
			// 
			this.m_txtHomeAddress.BackColor = System.Drawing.Color.White;
			this.m_txtHomeAddress.BorderColor = System.Drawing.Color.White;
			this.m_txtHomeAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomeAddress.ForeColor = System.Drawing.Color.Black;
			this.m_txtHomeAddress.Location = new System.Drawing.Point(124, 198);
			this.m_txtHomeAddress.Name = "m_txtHomeAddress";
			this.m_txtHomeAddress.Size = new System.Drawing.Size(400, 23);
			this.m_txtHomeAddress.TabIndex = 170;
			this.m_txtHomeAddress.Text = "";
			this.m_txtHomeAddress.TextChanged += new System.EventHandler(this.m_txtHomeAddress_TextChanged);
			// 
			// m_txtOfficeAddress
			// 
			this.m_txtOfficeAddress.BackColor = System.Drawing.Color.White;
			this.m_txtOfficeAddress.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficeAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficeAddress.ForeColor = System.Drawing.Color.Black;
			this.m_txtOfficeAddress.Location = new System.Drawing.Point(124, 162);
			this.m_txtOfficeAddress.Name = "m_txtOfficeAddress";
			this.m_txtOfficeAddress.Size = new System.Drawing.Size(400, 23);
			this.m_txtOfficeAddress.TabIndex = 150;
			this.m_txtOfficeAddress.Text = "";
			this.m_txtOfficeAddress.TextChanged += new System.EventHandler(this.m_txtOfficeAddress_TextChanged);
			// 
			// lblHomeAddressTitle
			// 
			this.lblHomeAddressTitle.AutoSize = true;
			this.lblHomeAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomeAddressTitle.Location = new System.Drawing.Point(40, 200);
			this.lblHomeAddressTitle.Name = "lblHomeAddressTitle";
			this.lblHomeAddressTitle.Size = new System.Drawing.Size(70, 19);
			this.lblHomeAddressTitle.TabIndex = 525;
			this.lblHomeAddressTitle.Text = "家庭地址:";
			this.lblHomeAddressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblOfficeAddressTitle
			// 
			this.lblOfficeAddressTitle.AutoSize = true;
			this.lblOfficeAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficeAddressTitle.Location = new System.Drawing.Point(40, 164);
			this.lblOfficeAddressTitle.Name = "lblOfficeAddressTitle";
			this.lblOfficeAddressTitle.Size = new System.Drawing.Size(70, 19);
			this.lblOfficeAddressTitle.TabIndex = 524;
			this.lblOfficeAddressTitle.Text = "办公地址:";
			this.lblOfficeAddressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHomePCTitle
			// 
			this.lblHomePCTitle.AutoSize = true;
			this.lblHomePCTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePCTitle.Location = new System.Drawing.Point(592, 200);
			this.lblHomePCTitle.Name = "lblHomePCTitle";
			this.lblHomePCTitle.Size = new System.Drawing.Size(48, 19);
			this.lblHomePCTitle.TabIndex = 516;
			this.lblHomePCTitle.Text = "邮 编:";
			this.lblHomePCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblOfficePCTitle
			// 
			this.lblOfficePCTitle.AutoSize = true;
			this.lblOfficePCTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePCTitle.Location = new System.Drawing.Point(592, 164);
			this.lblOfficePCTitle.Name = "lblOfficePCTitle";
			this.lblOfficePCTitle.Size = new System.Drawing.Size(48, 19);
			this.lblOfficePCTitle.TabIndex = 517;
			this.lblOfficePCTitle.Text = "邮 编:";
			this.lblOfficePCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtOfficePC
			// 
			this.m_txtOfficePC.BackColor = System.Drawing.Color.White;
			this.m_txtOfficePC.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficePC.ForeColor = System.Drawing.Color.Black;
			this.m_txtOfficePC.Location = new System.Drawing.Point(676, 162);
			this.m_txtOfficePC.MaxLength = 6;
			this.m_txtOfficePC.Name = "m_txtOfficePC";
			this.m_txtOfficePC.Size = new System.Drawing.Size(132, 23);
			this.m_txtOfficePC.TabIndex = 160;
			this.m_txtOfficePC.Text = "";
			// 
			// m_txtHomePC
			// 
			this.m_txtHomePC.BackColor = System.Drawing.Color.White;
			this.m_txtHomePC.BorderColor = System.Drawing.Color.White;
			this.m_txtHomePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomePC.ForeColor = System.Drawing.Color.Black;
			this.m_txtHomePC.Location = new System.Drawing.Point(676, 198);
			this.m_txtHomePC.MaxLength = 6;
			this.m_txtHomePC.Name = "m_txtHomePC";
			this.m_txtHomePC.Size = new System.Drawing.Size(132, 23);
			this.m_txtHomePC.TabIndex = 180;
			this.m_txtHomePC.Text = "";
			// 
			// m_txtMobile
			// 
			this.m_txtMobile.BackColor = System.Drawing.Color.White;
			this.m_txtMobile.BorderColor = System.Drawing.Color.White;
			this.m_txtMobile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMobile.ForeColor = System.Drawing.Color.Black;
			this.m_txtMobile.Location = new System.Drawing.Point(676, 126);
			this.m_txtMobile.Name = "m_txtMobile";
			this.m_txtMobile.Size = new System.Drawing.Size(132, 23);
			this.m_txtMobile.TabIndex = 140;
			this.m_txtMobile.Text = "";
			// 
			// lblMobileTitle
			// 
			this.lblMobileTitle.AutoSize = true;
			this.lblMobileTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMobileTitle.Location = new System.Drawing.Point(592, 128);
			this.lblMobileTitle.Name = "lblMobileTitle";
			this.lblMobileTitle.Size = new System.Drawing.Size(48, 19);
			this.lblMobileTitle.TabIndex = 518;
			this.lblMobileTitle.Text = "手 机:";
			this.lblMobileTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEMailTitle
			// 
			this.lblEMailTitle.AutoSize = true;
			this.lblEMailTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEMailTitle.Location = new System.Drawing.Point(44, 236);
			this.lblEMailTitle.Name = "lblEMailTitle";
			this.lblEMailTitle.Size = new System.Drawing.Size(48, 19);
			this.lblEMailTitle.TabIndex = 519;
			this.lblEMailTitle.Text = "EMail:";
			this.lblEMailTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtEMail
			// 
			this.m_txtEMail.BackColor = System.Drawing.Color.White;
			this.m_txtEMail.BorderColor = System.Drawing.Color.White;
			this.m_txtEMail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtEMail.ForeColor = System.Drawing.Color.Black;
			this.m_txtEMail.Location = new System.Drawing.Point(124, 234);
			this.m_txtEMail.Name = "m_txtEMail";
			this.m_txtEMail.Size = new System.Drawing.Size(400, 23);
			this.m_txtEMail.TabIndex = 190;
			this.m_txtEMail.Text = "";
			this.m_txtEMail.TextChanged += new System.EventHandler(this.m_txtEMail_TextChanged);
			// 
			// lblEmployeeIDTitle
			// 
			this.lblEmployeeIDTitle.AutoSize = true;
			this.lblEmployeeIDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEmployeeIDTitle.Location = new System.Drawing.Point(40, 20);
			this.lblEmployeeIDTitle.Name = "lblEmployeeIDTitle";
			this.lblEmployeeIDTitle.Size = new System.Drawing.Size(70, 19);
			this.lblEmployeeIDTitle.TabIndex = 522;
			this.lblEmployeeIDTitle.Text = "员工编号:";
			this.lblEmployeeIDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtEmployeeID
			// 
			this.m_txtEmployeeID.BackColor = System.Drawing.Color.White;
			this.m_txtEmployeeID.BorderColor = System.Drawing.Color.White;
			this.m_txtEmployeeID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtEmployeeID.ForeColor = System.Drawing.Color.Black;
			this.m_txtEmployeeID.Location = new System.Drawing.Point(124, 18);
			this.m_txtEmployeeID.Name = "m_txtEmployeeID";
			this.m_txtEmployeeID.Size = new System.Drawing.Size(104, 23);
			this.m_txtEmployeeID.TabIndex = 10;
			this.m_txtEmployeeID.Text = "";
			// 
			// m_txtPYCode
			// 
			this.m_txtPYCode.BackColor = System.Drawing.Color.White;
			this.m_txtPYCode.BorderColor = System.Drawing.Color.White;
			this.m_txtPYCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPYCode.ForeColor = System.Drawing.Color.Black;
			this.m_txtPYCode.Location = new System.Drawing.Point(720, 18);
			this.m_txtPYCode.Name = "m_txtPYCode";
			this.m_txtPYCode.Size = new System.Drawing.Size(88, 23);
			this.m_txtPYCode.TabIndex = 40;
			this.m_txtPYCode.Text = "";
			// 
			// lblPYCodeTitle
			// 
			this.lblPYCodeTitle.AutoSize = true;
			this.lblPYCodeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPYCodeTitle.Location = new System.Drawing.Point(652, 20);
			this.lblPYCodeTitle.Name = "lblPYCodeTitle";
			this.lblPYCodeTitle.Size = new System.Drawing.Size(56, 19);
			this.lblPYCodeTitle.TabIndex = 523;
			this.lblPYCodeTitle.Text = "拼音码:";
			this.lblPYCodeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEducationalLevelTitle
			// 
			this.lblEducationalLevelTitle.AutoSize = true;
			this.lblEducationalLevelTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEducationalLevelTitle.Location = new System.Drawing.Point(308, 92);
			this.lblEducationalLevelTitle.Name = "lblEducationalLevelTitle";
			this.lblEducationalLevelTitle.Size = new System.Drawing.Size(70, 19);
			this.lblEducationalLevelTitle.TabIndex = 523;
			this.lblEducationalLevelTitle.Text = "教育程度:";
			this.lblEducationalLevelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtEducationalLevel
			// 
			this.m_txtEducationalLevel.BackColor = System.Drawing.Color.White;
			this.m_txtEducationalLevel.BorderColor = System.Drawing.Color.White;
			this.m_txtEducationalLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtEducationalLevel.ForeColor = System.Drawing.Color.Black;
			this.m_txtEducationalLevel.Location = new System.Drawing.Point(392, 90);
			this.m_txtEducationalLevel.Name = "m_txtEducationalLevel";
			this.m_txtEducationalLevel.Size = new System.Drawing.Size(132, 23);
			this.m_txtEducationalLevel.TabIndex = 100;
			this.m_txtEducationalLevel.Text = "";
			// 
			// m_txtMarried
			// 
			this.m_txtMarried.BackColor = System.Drawing.Color.White;
			this.m_txtMarried.BorderColor = System.Drawing.Color.White;
			this.m_txtMarried.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMarried.ForeColor = System.Drawing.Color.Black;
			this.m_txtMarried.Location = new System.Drawing.Point(676, 54);
			this.m_txtMarried.Name = "m_txtMarried";
			this.m_txtMarried.Size = new System.Drawing.Size(132, 23);
			this.m_txtMarried.TabIndex = 70;
			this.m_txtMarried.Text = "";
			// 
			// lblMarriedTitle
			// 
			this.lblMarriedTitle.AutoSize = true;
			this.lblMarriedTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMarriedTitle.Location = new System.Drawing.Point(592, 56);
			this.lblMarriedTitle.Name = "lblMarriedTitle";
			this.lblMarriedTitle.Size = new System.Drawing.Size(70, 19);
			this.lblMarriedTitle.TabIndex = 520;
			this.lblMarriedTitle.Text = "婚姻状况:";
			this.lblMarriedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLanguageAbilityTitle
			// 
			this.lblLanguageAbilityTitle.AutoSize = true;
			this.lblLanguageAbilityTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLanguageAbilityTitle.Location = new System.Drawing.Point(592, 92);
			this.lblLanguageAbilityTitle.Name = "lblLanguageAbilityTitle";
			this.lblLanguageAbilityTitle.Size = new System.Drawing.Size(70, 19);
			this.lblLanguageAbilityTitle.TabIndex = 523;
			this.lblLanguageAbilityTitle.Text = "语言能力:";
			this.lblLanguageAbilityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtLanguageAbility
			// 
			this.m_txtLanguageAbility.BackColor = System.Drawing.Color.White;
			this.m_txtLanguageAbility.BorderColor = System.Drawing.Color.White;
			this.m_txtLanguageAbility.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLanguageAbility.ForeColor = System.Drawing.Color.Black;
			this.m_txtLanguageAbility.Location = new System.Drawing.Point(676, 90);
			this.m_txtLanguageAbility.Name = "m_txtLanguageAbility";
			this.m_txtLanguageAbility.Size = new System.Drawing.Size(132, 23);
			this.m_txtLanguageAbility.TabIndex = 110;
			this.m_txtLanguageAbility.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(308, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 19);
			this.label1.TabIndex = 520;
			this.label1.Text = "出生日期:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtFirstNameOfAnnouncer
			// 
			this.m_txtFirstNameOfAnnouncer.BackColor = System.Drawing.Color.White;
			this.m_txtFirstNameOfAnnouncer.BorderColor = System.Drawing.Color.White;
			this.m_txtFirstNameOfAnnouncer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFirstNameOfAnnouncer.ForeColor = System.Drawing.Color.Black;
			this.m_txtFirstNameOfAnnouncer.Location = new System.Drawing.Point(124, 270);
			this.m_txtFirstNameOfAnnouncer.Name = "m_txtFirstNameOfAnnouncer";
			this.m_txtFirstNameOfAnnouncer.Size = new System.Drawing.Size(132, 23);
			this.m_txtFirstNameOfAnnouncer.TabIndex = 200;
			this.m_txtFirstNameOfAnnouncer.Text = "";
			this.m_txtFirstNameOfAnnouncer.TextChanged += new System.EventHandler(this.m_txtFirstNameOfAnnouncer_TextChanged);
			// 
			// lblFirstNameOfAnnouncerTitle
			// 
			this.lblFirstNameOfAnnouncerTitle.AutoSize = true;
			this.lblFirstNameOfAnnouncerTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblFirstNameOfAnnouncerTitle.Location = new System.Drawing.Point(44, 272);
			this.lblFirstNameOfAnnouncerTitle.Name = "lblFirstNameOfAnnouncerTitle";
			this.lblFirstNameOfAnnouncerTitle.Size = new System.Drawing.Size(56, 19);
			this.lblFirstNameOfAnnouncerTitle.TabIndex = 522;
			this.lblFirstNameOfAnnouncerTitle.Text = "告知者:";
			this.lblFirstNameOfAnnouncerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtPhoneOfAnnouncer
			// 
			this.m_txtPhoneOfAnnouncer.BackColor = System.Drawing.Color.White;
			this.m_txtPhoneOfAnnouncer.BorderColor = System.Drawing.Color.White;
			this.m_txtPhoneOfAnnouncer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPhoneOfAnnouncer.ForeColor = System.Drawing.Color.Black;
			this.m_txtPhoneOfAnnouncer.Location = new System.Drawing.Point(504, 270);
			this.m_txtPhoneOfAnnouncer.Name = "m_txtPhoneOfAnnouncer";
			this.m_txtPhoneOfAnnouncer.Size = new System.Drawing.Size(136, 23);
			this.m_txtPhoneOfAnnouncer.TabIndex = 210;
			this.m_txtPhoneOfAnnouncer.Text = "";
			// 
			// lblPhoneOfAnnouncerTitle
			// 
			this.lblPhoneOfAnnouncerTitle.AutoSize = true;
			this.lblPhoneOfAnnouncerTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPhoneOfAnnouncerTitle.Location = new System.Drawing.Point(408, 272);
			this.lblPhoneOfAnnouncerTitle.Name = "lblPhoneOfAnnouncerTitle";
			this.lblPhoneOfAnnouncerTitle.Size = new System.Drawing.Size(84, 19);
			this.lblPhoneOfAnnouncerTitle.TabIndex = 522;
			this.lblPhoneOfAnnouncerTitle.Text = "告知者电话:";
			this.lblPhoneOfAnnouncerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExperienceTitle
			// 
			this.lblExperienceTitle.AutoSize = true;
			this.lblExperienceTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblExperienceTitle.Location = new System.Drawing.Point(44, 308);
			this.lblExperienceTitle.Name = "lblExperienceTitle";
			this.lblExperienceTitle.Size = new System.Drawing.Size(41, 19);
			this.lblExperienceTitle.TabIndex = 519;
			this.lblExperienceTitle.Text = "简历:";
			this.lblExperienceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtExperience
			// 
			this.m_txtExperience.BackColor = System.Drawing.Color.White;
			this.m_txtExperience.BorderColor = System.Drawing.Color.White;
			this.m_txtExperience.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtExperience.ForeColor = System.Drawing.Color.Black;
			this.m_txtExperience.Location = new System.Drawing.Point(124, 308);
			this.m_txtExperience.Multiline = true;
			this.m_txtExperience.Name = "m_txtExperience";
			this.m_txtExperience.Size = new System.Drawing.Size(688, 104);
			this.m_txtExperience.TabIndex = 220;
			this.m_txtExperience.Text = "";
			this.m_txtExperience.TextChanged += new System.EventHandler(this.m_txtExperience_TextChanged);
			// 
			// m_txtRemark
			// 
			this.m_txtRemark.BackColor = System.Drawing.Color.White;
			this.m_txtRemark.BorderColor = System.Drawing.Color.White;
			this.m_txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtRemark.ForeColor = System.Drawing.Color.Black;
			this.m_txtRemark.Location = new System.Drawing.Point(124, 424);
			this.m_txtRemark.Name = "m_txtRemark";
			this.m_txtRemark.Size = new System.Drawing.Size(688, 23);
			this.m_txtRemark.TabIndex = 230;
			this.m_txtRemark.Text = "";
			this.m_txtRemark.TextChanged += new System.EventHandler(this.m_txtRemark_TextChanged);
			// 
			// lblRemarkTitle
			// 
			this.lblRemarkTitle.AutoSize = true;
			this.lblRemarkTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRemarkTitle.Location = new System.Drawing.Point(48, 428);
			this.lblRemarkTitle.Name = "lblRemarkTitle";
			this.lblRemarkTitle.Size = new System.Drawing.Size(41, 19);
			this.lblRemarkTitle.TabIndex = 519;
			this.lblRemarkTitle.Text = "注释:";
			this.lblRemarkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_dtpBirth
			// 
			this.m_dtpBirth.BorderColor = System.Drawing.Color.Black;
			this.m_dtpBirth.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpBirth.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtpBirth.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpBirth.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtpBirth.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpBirth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpBirth.Location = new System.Drawing.Point(392, 54);
			this.m_dtpBirth.m_BlnOnlyTime = false;
			this.m_dtpBirth.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpBirth.Name = "m_dtpBirth";
			this.m_dtpBirth.ReadOnly = false;
			this.m_dtpBirth.Size = new System.Drawing.Size(132, 22);
			this.m_dtpBirth.TabIndex = 60;
			this.m_dtpBirth.TextBackColor = System.Drawing.Color.White;
			this.m_dtpBirth.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(228, 463);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(84, 32);
			this.m_cmdCancel.TabIndex = 10000001;
			this.m_cmdCancel.Text = "确 定";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// buttonXP1
			// 
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.ForeColor = System.Drawing.Color.Black;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(540, 463);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(84, 32);
			this.buttonXP1.TabIndex = 10000001;
			this.buttonXP1.Text = "取 消";
			this.buttonXP1.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// m_cmdFireEmployee
			// 
			this.m_cmdFireEmployee.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdFireEmployee.DefaultScheme = true;
			this.m_cmdFireEmployee.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdFireEmployee.ForeColor = System.Drawing.Color.Black;
			this.m_cmdFireEmployee.Hint = "";
			this.m_cmdFireEmployee.Location = new System.Drawing.Point(384, 463);
			this.m_cmdFireEmployee.Name = "m_cmdFireEmployee";
			this.m_cmdFireEmployee.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdFireEmployee.Size = new System.Drawing.Size(84, 32);
			this.m_cmdFireEmployee.TabIndex = 10000001;
			this.m_cmdFireEmployee.Text = "离职";
			this.m_cmdFireEmployee.Click += new System.EventHandler(this.m_cmdFireEmployee_Click);
			// 
			// frmEmployeeDetailInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(852, 513);
			this.Controls.Add(this.m_cmdCancel);
			this.Controls.Add(this.m_txtName);
			this.Controls.Add(this.lblNameTitle);
			this.Controls.Add(this.lblSexTitle);
			this.Controls.Add(this.lblIDCardTitle);
			this.Controls.Add(this.lblTitleOfaTechnicalPostTitle);
			this.Controls.Add(this.lblOfficePhoneTitle);
			this.Controls.Add(this.lblHomePhoneTitle);
			this.Controls.Add(this.lblHomeAddressTitle);
			this.Controls.Add(this.lblOfficeAddressTitle);
			this.Controls.Add(this.lblHomePCTitle);
			this.Controls.Add(this.lblOfficePCTitle);
			this.Controls.Add(this.lblMobileTitle);
			this.Controls.Add(this.lblEMailTitle);
			this.Controls.Add(this.lblEmployeeIDTitle);
			this.Controls.Add(this.lblPYCodeTitle);
			this.Controls.Add(this.lblEducationalLevelTitle);
			this.Controls.Add(this.lblMarriedTitle);
			this.Controls.Add(this.lblLanguageAbilityTitle);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblFirstNameOfAnnouncerTitle);
			this.Controls.Add(this.lblPhoneOfAnnouncerTitle);
			this.Controls.Add(this.lblExperienceTitle);
			this.Controls.Add(this.lblRemarkTitle);
			this.Controls.Add(this.m_txtIDCard);
			this.Controls.Add(this.m_txtTitleOfaTechnicalPost);
			this.Controls.Add(this.m_txtOfficePhone);
			this.Controls.Add(this.m_txtHomePhone);
			this.Controls.Add(this.m_txtHomeAddress);
			this.Controls.Add(this.m_txtOfficeAddress);
			this.Controls.Add(this.m_txtOfficePC);
			this.Controls.Add(this.m_txtHomePC);
			this.Controls.Add(this.m_txtMobile);
			this.Controls.Add(this.m_txtEMail);
			this.Controls.Add(this.m_txtEmployeeID);
			this.Controls.Add(this.m_txtPYCode);
			this.Controls.Add(this.m_txtEducationalLevel);
			this.Controls.Add(this.m_txtMarried);
			this.Controls.Add(this.m_txtLanguageAbility);
			this.Controls.Add(this.m_txtFirstNameOfAnnouncer);
			this.Controls.Add(this.m_txtPhoneOfAnnouncer);
			this.Controls.Add(this.m_txtExperience);
			this.Controls.Add(this.m_txtRemark);
			this.Controls.Add(this.buttonXP1);
			this.Controls.Add(this.m_cmdFireEmployee);
			this.Controls.Add(this.m_dtpBirth);
			this.Controls.Add(this.m_cboSex);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmEmployeeDetailInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "员工基本资料";
			this.Load += new System.EventHandler(this.frmEmployeeDetailInfo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public clsEmployee_BaseInfo m_objGetContentValue()
		{
			if(this.DialogResult==DialogResult.Yes)
				return m_objEmployee_BaseInfo;
			else return null;
		}

		/// <summary>
		/// 设置界面值
		/// </summary>
		/// <param name="p_objContent"></param>
		private void m_mthSetGUIFromContent(clsEmployee_BaseInfo p_objContent)
		{
			if(p_objContent==null)
				return;
			this.m_txtEmployeeID.Text=p_objContent.m_strEmployeeID;			
			this.m_txtName.Text=p_objContent.m_strFirstName;
			this.m_txtIDCard.Text=p_objContent.m_strIDCard;
			this.m_cboSex.Text=p_objContent.m_strSex;
			this.m_txtPYCode.Text=p_objContent.m_strPYCode;
			this.m_dtpBirth.Value = (p_objContent.m_dtmBirth==DateTime.MinValue) ? DateTime.Parse("1900-1-1") : p_objContent.m_dtmBirth; //员工没有生日，先注释
			this.m_txtMarried.Text=p_objContent.m_strMarried;
			this.m_txtTitleOfaTechnicalPost.Text=p_objContent.m_strTitleOfaTechnicalPost;
			this.m_txtEducationalLevel.Text=p_objContent.m_strEducationalLevel;
			this.m_txtLanguageAbility.Text=p_objContent.m_strLanguageAbility;
			this.m_txtOfficePhone.Text=p_objContent.m_strOfficePhone;
			this.m_txtHomePhone.Text=p_objContent.m_strHomePhone;
			this.m_txtMobile.Text=p_objContent.m_strMobile;
			this.m_txtOfficeAddress.Text=p_objContent.m_strOfficeAddress;
			this.m_txtOfficePC.Text=p_objContent.m_strOfficePC;
			this.m_txtHomeAddress.Text=p_objContent.m_strHomeAddress;
			this.m_txtHomePC.Text=p_objContent.m_strHomePC;
			this.m_txtEMail.Text=p_objContent.m_strEMail;
			this.m_txtFirstNameOfAnnouncer.Text=p_objContent.m_strFirstNameOfAnnouncer;
			this.m_txtPhoneOfAnnouncer.Text=p_objContent.m_strPhoneOfAnnouncer;
			this.m_txtExperience.Text=p_objContent.m_strExperience;
			this.m_txtRemark.Text=p_objContent.m_strRemark;
		}

		/// <summary>
		/// 从界面获取表单值
		/// </summary>
		/// <returns></returns>
		private clsEmployee_BaseInfo m_objGetContentFromGUI()
		{
			if(this.m_txtEmployeeID.Text.Trim().Length>7)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,员工编号长度不能大于7!");
				m_txtEmployeeID.Focus();
				return null;
			}	

			if(this.m_txtEmployeeID.Text.Trim() =="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写员工编号!");
				m_txtEmployeeID.Focus();
				return null;
			}			

			if( this.m_txtName.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写员工姓名!");
				m_txtName.Focus();
				return null;
			}

			//界面参数校验
			try
			{
				if(m_txtOfficePC.Text.Trim() !="")
					long.Parse(m_txtHomePC.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("邮编只能输入数字!");
				m_txtOfficePC.Focus();
				return null;
			}

			try
			{
				if(m_txtHomePC.Text.Trim() !="")
					long.Parse(m_txtHomePC.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("邮编只能输入数字!");
				m_txtHomePC.Focus();
				return null;
			}

			
			if(m_txtIDCard.Text.Trim() !="" && m_txtIDCard.Text.Trim().Length !=15 && m_txtIDCard.Text.Trim().Length !=18)
			{
				clsPublicFunction.ShowInformationMessageBox("身份证号输入有误!");
				m_txtIDCard.Focus();
				return null;
			}			
			
			//从界面获取表单值		
			clsEmployee_BaseInfo objEmployee_BaseInfo=new clsEmployee_BaseInfo();
			if(m_objEmployee_BaseInfo==null)
			{
				objEmployee_BaseInfo.m_dtmBeginDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());                					
			}
			else 
			{
				objEmployee_BaseInfo.m_dtmBeginDate=m_objEmployee_BaseInfo.m_dtmBeginDate;
			}
			objEmployee_BaseInfo.m_strEmployeeID=this.m_txtEmployeeID.Text.Trim();
			objEmployee_BaseInfo.m_strFirstName=this.m_txtName.Text.Trim();
			objEmployee_BaseInfo.m_strLastName="";
			objEmployee_BaseInfo.m_strLastNameOfAnnouncer="";
			objEmployee_BaseInfo.m_strIDCard=this.m_txtIDCard.Text.Trim();
			objEmployee_BaseInfo.m_strSex=this.m_cboSex.Text.Trim();
			objEmployee_BaseInfo.m_strPYCode=this.m_txtPYCode.Text.Trim();
			objEmployee_BaseInfo.m_dtmBirth=this.m_dtpBirth.Value;
			objEmployee_BaseInfo.m_strMarried=this.m_txtMarried.Text.Trim();
			objEmployee_BaseInfo.m_strTitleOfaTechnicalPost=this.m_txtTitleOfaTechnicalPost.Text.Trim();
			objEmployee_BaseInfo.m_strEducationalLevel=this.m_txtEducationalLevel.Text.Trim();
			objEmployee_BaseInfo.m_strLanguageAbility=this.m_txtLanguageAbility.Text.Trim();
			objEmployee_BaseInfo.m_strOfficePhone=this.m_txtOfficePhone.Text.Trim();
			objEmployee_BaseInfo.m_strHomePhone=this.m_txtHomePhone.Text.Trim();
			objEmployee_BaseInfo.m_strMobile=this.m_txtMobile.Text.Trim();
			objEmployee_BaseInfo.m_strOfficeAddress=this.m_txtOfficeAddress.Text.Trim();
			objEmployee_BaseInfo.m_strOfficePC=this.m_txtOfficePC.Text.Trim();
			objEmployee_BaseInfo.m_strHomeAddress=this.m_txtHomeAddress.Text.Trim();
			objEmployee_BaseInfo.m_strHomePC=this.m_txtHomePC.Text.Trim();
			objEmployee_BaseInfo.m_strEMail=this.m_txtEMail.Text.Trim();
			objEmployee_BaseInfo.m_strFirstNameOfAnnouncer=this.m_txtFirstNameOfAnnouncer.Text.Trim();
			objEmployee_BaseInfo.m_strPhoneOfAnnouncer=this.m_txtPhoneOfAnnouncer.Text.Trim();
			objEmployee_BaseInfo.m_strExperience=this.m_txtExperience.Text.Trim();
			objEmployee_BaseInfo.m_strRemark=this.m_txtRemark.Text.Trim();
			
			m_objEmployee_BaseInfo=objEmployee_BaseInfo;
			return objEmployee_BaseInfo;
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
		#endregion

		private void  m_mthClearUp()
		{
			foreach(Control ctlControl in this.Controls)
			{
				if(ctlControl.GetType().Name=="ctlBorderTextBox" || ctlControl.GetType().Name=="TextBox" )
					ctlControl.Text="";
				else if(ctlControl.GetType().Name=="ctlComboBox" )
					((ctlComboBox)ctlControl).SelectedIndex=0;
			}
			this.m_dtpBirth.Value=DateTime.Now;
		}

		private void frmEmployeeDetailInfo_Load(object sender, System.EventArgs e)
		{
			m_cboSex.AddRangeItems(new Object[]{"男","女"});
			m_cboSex.SelectedIndex=0;
			m_mthSetQuickKeys();

			m_objHighLight.m_mthAddControlInContainer(this);

			m_txtEmployeeID.Focus();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			clsEmployee_BaseInfo objContent=m_objGetContentFromGUI();
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

		private void m_cmdFireEmployee_Click(object sender, System.EventArgs e)
		{
			//clsEmployee_BaseInfo objContent=m_objGetContentFromGUI();
//			if( !=null)
//			{
			if(m_objEmployee_BaseInfo==null) return;
			m_objEmployee_BaseInfo.m_dtmDeActiveDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			m_objEmployee_BaseInfo.m_strDeActivedOperatorID=MDIParent.OperatorID;
			m_objEmployee_BaseInfo.m_strStatus="1";
			
			this.DialogResult=DialogResult.Yes;
			this.Close();
//			}
		}

		private void m_txtEMail_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtRemark_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtOfficeAddress_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtOfficePhone_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtExperience_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtIDCard_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtHomeAddress_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtFirstNameOfAnnouncer_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTitleOfaTechnicalPost_TextChanged(object sender, System.EventArgs e)
		{
		
		}



	}
}
