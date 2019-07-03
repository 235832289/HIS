//#define FunctionPrivilege
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
using PrivilegeData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmAddOuterExpert.
	/// </summary>
	public class frmAddOuterExpert : iCare.iCareBaseForm.frmBaseForm,PublicFunction
	{
		protected System.Windows.Forms.Label lblSexTitle;
		private System.Windows.Forms.Button cmdDel;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdExit;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtName;
		protected System.Windows.Forms.Label lblNameTitle;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboSex;
		protected System.Windows.Forms.Label lblExpertIDTitle;
		protected System.Windows.Forms.ListView m_lsvExpertID;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExpertID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtIDCard;
		protected System.Windows.Forms.Label lblIDCardTitle;
		protected System.Windows.Forms.Label label2;
		protected System.Windows.Forms.Label lblTitleOfaTechnicalPostTitle;
		protected System.Windows.Forms.Label lblOfficePhoneTitle;
		protected System.Windows.Forms.Label lblHomePhoneTitle;
		protected System.Windows.Forms.Label lblHomeAddressTitle;
		protected System.Windows.Forms.Label lblOfficeAddressTitle;
		protected System.Windows.Forms.Label lblHomePCTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTitleOfaTechnicalPost;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficePhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomePhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomeAddress;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficeAddress;
		protected System.Windows.Forms.Label lblOfficePCTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMobile;
		protected System.Windows.Forms.Label lblMobileTitle;
		protected System.Windows.Forms.Label lblEMailTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtEMail;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private clsSystemContext m_objCurrentContext
		{
			get
			{
				return clsSystemContext.s_ObjCurrentContext;
			}
		}


		public frmAddOuterExpert()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//			
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
		}

		private ctlHighLightFocus m_objHighLight;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddOuterExpert));
			this.lblTitle = new System.Windows.Forms.Label();
			this.m_txtName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblNameTitle = new System.Windows.Forms.Label();
			this.lblSexTitle = new System.Windows.Forms.Label();
			this.m_cboSex = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.cmdDel = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.lblExpertIDTitle = new System.Windows.Forms.Label();
			this.m_lsvExpertID = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.m_txtExpertID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtIDCard = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblIDCardTitle = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitle.Location = new System.Drawing.Point(24, 16);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(308, 37);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "非正式员工资料管理";
			// 
			// m_txtName
			// 
			this.m_txtName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtName.BorderColor = System.Drawing.Color.White;
			this.m_txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtName.ForeColor = System.Drawing.Color.White;
			this.m_txtName.Location = new System.Drawing.Point(96, 108);
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.TabIndex = 110;
			this.m_txtName.Text = "";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.AutoSize = true;
			this.lblNameTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNameTitle.Location = new System.Drawing.Point(24, 112);
			this.lblNameTitle.Name = "lblNameTitle";
			this.lblNameTitle.Size = new System.Drawing.Size(64, 19);
			this.lblNameTitle.TabIndex = 501;
			this.lblNameTitle.Text = "姓  名:";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.AutoSize = true;
			this.lblSexTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSexTitle.Location = new System.Drawing.Point(208, 112);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(64, 19);
			this.lblSexTitle.TabIndex = 500;
			this.lblSexTitle.Text = "性  别:";
			// 
			// m_cboSex
			// 
			this.m_cboSex.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSex.BorderColor = System.Drawing.Color.White;
			this.m_cboSex.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSex.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboSex.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSex.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSex.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSex.ForeColor = System.Drawing.Color.White;
			this.m_cboSex.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSex.ListForeColor = System.Drawing.Color.White;
			this.m_cboSex.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboSex.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboSex.Location = new System.Drawing.Point(280, 108);
			this.m_cboSex.Name = "m_cboSex";
			this.m_cboSex.SelectedIndex = -1;
			this.m_cboSex.SelectedItem = null;
			this.m_cboSex.Size = new System.Drawing.Size(64, 26);
			this.m_cboSex.TabIndex = 120;
			this.m_cboSex.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSex.TextForeColor = System.Drawing.Color.White;
			// 
			// cmdDel
			// 
			this.cmdDel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdDel.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdDel.ForeColor = System.Drawing.Color.White;
			this.cmdDel.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdDel.Image")));
			this.cmdDel.Location = new System.Drawing.Point(184, 168);
			this.cmdDel.Name = "cmdDel";
			this.cmdDel.Size = new System.Drawing.Size(48, 48);
			this.cmdDel.TabIndex = 240;
			this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdAdd.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdAdd.ForeColor = System.Drawing.Color.White;
			this.cmdAdd.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdAdd.Image")));
			this.cmdAdd.Location = new System.Drawing.Point(112, 168);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(48, 48);
			this.cmdAdd.TabIndex = 230;
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdExit
			// 
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdExit.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdExit.ForeColor = System.Drawing.Color.White;
			this.cmdExit.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdExit.Image")));
			this.cmdExit.Location = new System.Drawing.Point(256, 168);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.Size = new System.Drawing.Size(48, 48);
			this.cmdExit.TabIndex = 250;
			this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
			// 
			// lblExpertIDTitle
			// 
			this.lblExpertIDTitle.AutoSize = true;
			this.lblExpertIDTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblExpertIDTitle.Location = new System.Drawing.Point(24, 72);
			this.lblExpertIDTitle.Name = "lblExpertIDTitle";
			this.lblExpertIDTitle.Size = new System.Drawing.Size(64, 19);
			this.lblExpertIDTitle.TabIndex = 501;
			this.lblExpertIDTitle.Text = "编  号:";
			// 
			// m_lsvExpertID
			// 
			this.m_lsvExpertID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvExpertID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvExpertID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.columnHeader1,
																							this.columnHeader2});
			this.m_lsvExpertID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvExpertID.ForeColor = System.Drawing.Color.White;
			this.m_lsvExpertID.FullRowSelect = true;
			this.m_lsvExpertID.GridLines = true;
			this.m_lsvExpertID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvExpertID.Location = new System.Drawing.Point(96, 92);
			this.m_lsvExpertID.Name = "m_lsvExpertID";
			this.m_lsvExpertID.Size = new System.Drawing.Size(202, 105);
			this.m_lsvExpertID.TabIndex = 6104;
			this.m_lsvExpertID.View = System.Windows.Forms.View.Details;
			this.m_lsvExpertID.Visible = false;
			this.m_lsvExpertID.DoubleClick += new System.EventHandler(this.m_lsvExpertID_DoubleClick);
			this.m_lsvExpertID.Leave += new System.EventHandler(this.m_lsvExpertID_LostFocus);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Width = 100;
			// 
			// m_txtExpertID
			// 
			this.m_txtExpertID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtExpertID.BorderColor = System.Drawing.Color.White;
			this.m_txtExpertID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtExpertID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtExpertID.ForeColor = System.Drawing.Color.White;
			this.m_txtExpertID.Location = new System.Drawing.Point(96, 68);
			this.m_txtExpertID.MaxLength = 7;
			this.m_txtExpertID.Name = "m_txtExpertID";
			this.m_txtExpertID.ReadOnly = true;
			this.m_txtExpertID.TabIndex = 100;
			this.m_txtExpertID.Text = "99";
			this.m_txtExpertID.Leave += new System.EventHandler(this.m_lsvExpertID_LostFocus);
			// 
			// m_txtIDCard
			// 
			this.m_txtIDCard.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtIDCard.BorderColor = System.Drawing.Color.White;
			this.m_txtIDCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtIDCard.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtIDCard.ForeColor = System.Drawing.Color.White;
			this.m_txtIDCard.Location = new System.Drawing.Point(96, 56);
			this.m_txtIDCard.MaxLength = 18;
			this.m_txtIDCard.Name = "m_txtIDCard";
			this.m_txtIDCard.Size = new System.Drawing.Size(120, 26);
			this.m_txtIDCard.TabIndex = 140;
			this.m_txtIDCard.Text = "";
			// 
			// lblIDCardTitle
			// 
			this.lblIDCardTitle.AutoSize = true;
			this.lblIDCardTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblIDCardTitle.Location = new System.Drawing.Point(8, 56);
			this.lblIDCardTitle.Name = "lblIDCardTitle";
			this.lblIDCardTitle.Size = new System.Drawing.Size(80, 19);
			this.lblIDCardTitle.TabIndex = 501;
			this.lblIDCardTitle.Text = "身份证号:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(200, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 19);
			this.label2.TabIndex = 6105;
			this.label2.Text = "(*编号以99开头)";
			// 
			// m_txtTitleOfaTechnicalPost
			// 
			this.m_txtTitleOfaTechnicalPost.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTitleOfaTechnicalPost.BorderColor = System.Drawing.Color.White;
			this.m_txtTitleOfaTechnicalPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtTitleOfaTechnicalPost.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTitleOfaTechnicalPost.ForeColor = System.Drawing.Color.White;
			this.m_txtTitleOfaTechnicalPost.Location = new System.Drawing.Point(80, 24);
			this.m_txtTitleOfaTechnicalPost.Name = "m_txtTitleOfaTechnicalPost";
			this.m_txtTitleOfaTechnicalPost.Size = new System.Drawing.Size(136, 26);
			this.m_txtTitleOfaTechnicalPost.TabIndex = 130;
			this.m_txtTitleOfaTechnicalPost.Text = "";
			// 
			// lblTitleOfaTechnicalPostTitle
			// 
			this.lblTitleOfaTechnicalPostTitle.AutoSize = true;
			this.lblTitleOfaTechnicalPostTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitleOfaTechnicalPostTitle.Location = new System.Drawing.Point(8, 24);
			this.lblTitleOfaTechnicalPostTitle.Name = "lblTitleOfaTechnicalPostTitle";
			this.lblTitleOfaTechnicalPostTitle.Size = new System.Drawing.Size(64, 19);
			this.lblTitleOfaTechnicalPostTitle.TabIndex = 501;
			this.lblTitleOfaTechnicalPostTitle.Text = "职  称:";
			// 
			// m_txtOfficePhone
			// 
			this.m_txtOfficePhone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOfficePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtOfficePhone.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficePhone.ForeColor = System.Drawing.Color.White;
			this.m_txtOfficePhone.Location = new System.Drawing.Point(96, 88);
			this.m_txtOfficePhone.Name = "m_txtOfficePhone";
			this.m_txtOfficePhone.Size = new System.Drawing.Size(120, 26);
			this.m_txtOfficePhone.TabIndex = 150;
			this.m_txtOfficePhone.Text = "";
			// 
			// lblOfficePhoneTitle
			// 
			this.lblOfficePhoneTitle.AutoSize = true;
			this.lblOfficePhoneTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePhoneTitle.Location = new System.Drawing.Point(8, 88);
			this.lblOfficePhoneTitle.Name = "lblOfficePhoneTitle";
			this.lblOfficePhoneTitle.Size = new System.Drawing.Size(80, 19);
			this.lblOfficePhoneTitle.TabIndex = 501;
			this.lblOfficePhoneTitle.Text = "办公电话:";
			// 
			// m_txtHomePhone
			// 
			this.m_txtHomePhone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtHomePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtHomePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtHomePhone.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomePhone.ForeColor = System.Drawing.Color.White;
			this.m_txtHomePhone.Location = new System.Drawing.Point(96, 120);
			this.m_txtHomePhone.Name = "m_txtHomePhone";
			this.m_txtHomePhone.Size = new System.Drawing.Size(120, 26);
			this.m_txtHomePhone.TabIndex = 160;
			this.m_txtHomePhone.Text = "";
			// 
			// lblHomePhoneTitle
			// 
			this.lblHomePhoneTitle.AutoSize = true;
			this.lblHomePhoneTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePhoneTitle.Location = new System.Drawing.Point(8, 120);
			this.lblHomePhoneTitle.Name = "lblHomePhoneTitle";
			this.lblHomePhoneTitle.Size = new System.Drawing.Size(80, 19);
			this.lblHomePhoneTitle.TabIndex = 501;
			this.lblHomePhoneTitle.Text = "家庭电话:";
			// 
			// m_txtHomeAddress
			// 
			this.m_txtHomeAddress.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtHomeAddress.BorderColor = System.Drawing.Color.White;
			this.m_txtHomeAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtHomeAddress.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomeAddress.ForeColor = System.Drawing.Color.White;
			this.m_txtHomeAddress.Location = new System.Drawing.Point(96, 184);
			this.m_txtHomeAddress.Name = "m_txtHomeAddress";
			this.m_txtHomeAddress.Size = new System.Drawing.Size(120, 26);
			this.m_txtHomeAddress.TabIndex = 200;
			this.m_txtHomeAddress.Text = "";
			// 
			// m_txtOfficeAddress
			// 
			this.m_txtOfficeAddress.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOfficeAddress.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficeAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtOfficeAddress.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficeAddress.ForeColor = System.Drawing.Color.White;
			this.m_txtOfficeAddress.Location = new System.Drawing.Point(96, 152);
			this.m_txtOfficeAddress.Name = "m_txtOfficeAddress";
			this.m_txtOfficeAddress.Size = new System.Drawing.Size(120, 26);
			this.m_txtOfficeAddress.TabIndex = 180;
			this.m_txtOfficeAddress.Text = "";
			// 
			// lblHomeAddressTitle
			// 
			this.lblHomeAddressTitle.AutoSize = true;
			this.lblHomeAddressTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomeAddressTitle.Location = new System.Drawing.Point(8, 184);
			this.lblHomeAddressTitle.Name = "lblHomeAddressTitle";
			this.lblHomeAddressTitle.Size = new System.Drawing.Size(80, 19);
			this.lblHomeAddressTitle.TabIndex = 501;
			this.lblHomeAddressTitle.Text = "家庭地址:";
			// 
			// lblOfficeAddressTitle
			// 
			this.lblOfficeAddressTitle.AutoSize = true;
			this.lblOfficeAddressTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficeAddressTitle.Location = new System.Drawing.Point(8, 152);
			this.lblOfficeAddressTitle.Name = "lblOfficeAddressTitle";
			this.lblOfficeAddressTitle.Size = new System.Drawing.Size(80, 19);
			this.lblOfficeAddressTitle.TabIndex = 501;
			this.lblOfficeAddressTitle.Text = "办公地址:";
			// 
			// lblHomePCTitle
			// 
			this.lblHomePCTitle.AutoSize = true;
			this.lblHomePCTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePCTitle.Location = new System.Drawing.Point(224, 88);
			this.lblHomePCTitle.Name = "lblHomePCTitle";
			this.lblHomePCTitle.Size = new System.Drawing.Size(47, 19);
			this.lblHomePCTitle.TabIndex = 501;
			this.lblHomePCTitle.Text = "邮编:";
			// 
			// lblOfficePCTitle
			// 
			this.lblOfficePCTitle.AutoSize = true;
			this.lblOfficePCTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePCTitle.Location = new System.Drawing.Point(224, 56);
			this.lblOfficePCTitle.Name = "lblOfficePCTitle";
			this.lblOfficePCTitle.Size = new System.Drawing.Size(47, 19);
			this.lblOfficePCTitle.TabIndex = 501;
			this.lblOfficePCTitle.Text = "邮编:";
			// 
			// m_txtOfficePC
			// 
			this.m_txtOfficePC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOfficePC.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficePC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtOfficePC.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficePC.ForeColor = System.Drawing.Color.White;
			this.m_txtOfficePC.Location = new System.Drawing.Point(280, 56);
			this.m_txtOfficePC.MaxLength = 6;
			this.m_txtOfficePC.Name = "m_txtOfficePC";
			this.m_txtOfficePC.Size = new System.Drawing.Size(112, 26);
			this.m_txtOfficePC.TabIndex = 190;
			this.m_txtOfficePC.Text = "";
			// 
			// m_txtHomePC
			// 
			this.m_txtHomePC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtHomePC.BorderColor = System.Drawing.Color.White;
			this.m_txtHomePC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtHomePC.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomePC.ForeColor = System.Drawing.Color.White;
			this.m_txtHomePC.Location = new System.Drawing.Point(280, 88);
			this.m_txtHomePC.MaxLength = 6;
			this.m_txtHomePC.Name = "m_txtHomePC";
			this.m_txtHomePC.Size = new System.Drawing.Size(112, 26);
			this.m_txtHomePC.TabIndex = 210;
			this.m_txtHomePC.Text = "";
			// 
			// m_txtMobile
			// 
			this.m_txtMobile.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtMobile.BorderColor = System.Drawing.Color.White;
			this.m_txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtMobile.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMobile.ForeColor = System.Drawing.Color.White;
			this.m_txtMobile.Location = new System.Drawing.Point(280, 24);
			this.m_txtMobile.Name = "m_txtMobile";
			this.m_txtMobile.Size = new System.Drawing.Size(112, 26);
			this.m_txtMobile.TabIndex = 170;
			this.m_txtMobile.Text = "";
			// 
			// lblMobileTitle
			// 
			this.lblMobileTitle.AutoSize = true;
			this.lblMobileTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMobileTitle.Location = new System.Drawing.Point(224, 24);
			this.lblMobileTitle.Name = "lblMobileTitle";
			this.lblMobileTitle.Size = new System.Drawing.Size(47, 19);
			this.lblMobileTitle.TabIndex = 501;
			this.lblMobileTitle.Text = "手机:";
			// 
			// lblEMailTitle
			// 
			this.lblEMailTitle.AutoSize = true;
			this.lblEMailTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEMailTitle.Location = new System.Drawing.Point(16, 224);
			this.lblEMailTitle.Name = "lblEMailTitle";
			this.lblEMailTitle.Size = new System.Drawing.Size(55, 19);
			this.lblEMailTitle.TabIndex = 501;
			this.lblEMailTitle.Text = "EMail:";
			// 
			// m_txtEMail
			// 
			this.m_txtEMail.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtEMail.BorderColor = System.Drawing.Color.White;
			this.m_txtEMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtEMail.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtEMail.ForeColor = System.Drawing.Color.White;
			this.m_txtEMail.Location = new System.Drawing.Point(96, 216);
			this.m_txtEMail.Name = "m_txtEMail";
			this.m_txtEMail.Size = new System.Drawing.Size(120, 26);
			this.m_txtEMail.TabIndex = 220;
			this.m_txtEMail.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lblTitleOfaTechnicalPostTitle,
																					this.m_txtTitleOfaTechnicalPost,
																					this.lblIDCardTitle,
																					this.m_txtIDCard,
																					this.lblOfficePhoneTitle,
																					this.m_txtOfficePhone,
																					this.lblHomePhoneTitle,
																					this.m_txtHomePhone,
																					this.lblMobileTitle,
																					this.m_txtMobile,
																					this.lblOfficeAddressTitle,
																					this.m_txtOfficeAddress,
																					this.lblHomeAddressTitle,
																					this.m_txtHomeAddress,
																					this.lblEMailTitle,
																					this.m_txtEMail,
																					this.lblOfficePCTitle,
																					this.m_txtOfficePC,
																					this.lblHomePCTitle,
																					this.m_txtHomePC});
			this.groupBox1.Location = new System.Drawing.Point(16, 176);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(72, 24);
			this.groupBox1.TabIndex = 6106;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "no use";
			this.groupBox1.Visible = false;
			// 
			// frmAddOuterExpert
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.CancelButton = this.cmdExit;
			this.ClientSize = new System.Drawing.Size(362, 239);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1,
																		  this.label2,
																		  this.m_txtExpertID,
																		  this.cmdDel,
																		  this.cmdAdd,
																		  this.cmdExit,
																		  this.m_cboSex,
																		  this.m_txtName,
																		  this.lblNameTitle,
																		  this.lblSexTitle,
																		  this.lblTitle,
																		  this.lblExpertIDTitle,
																		  this.m_lsvExpertID});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.SystemColors.Window;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAddOuterExpert";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "非正式员工资料管理";
			this.Load += new System.EventHandler(this.frmAddOuterExpert_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 通过ID或Name查找签名
		/// <summary>
		/// 显示医生列表
		/// </summary>
		/// <param name="p_strDoctorNameLike">医生号</param>
		private void m_mthGetDoctorList(string p_strDoctorNameLike)
		{
			
			/*
			 * 获取所有医生号和姓名，根据输入医生号的控件标志（m_bytListOnDoctor）,
			 * 在相应的位置显示ListView。
			 */			

			if(p_strDoctorNameLike==null || p_strDoctorNameLike.Length < 2 || p_strDoctorNameLike.Substring(0,2) !="99")
			{
				m_lsvExpertID.Visible = false;
				return;
			}

			clsEmployee [] objDoctorArr = new clsEmployeeManager().m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,null);

			if(objDoctorArr == null)
			{
				m_lsvExpertID.Visible = false;
				return;
			}

			m_lsvExpertID.Items.Clear();

			for(int i=0;i<objDoctorArr.Length;i++)
			{
				ListViewItem lviDoctor = new ListViewItem(
					new string[]{
									objDoctorArr[i].m_StrEmployeeID,
									objDoctorArr[i].m_StrFirstName
								});
				lviDoctor.Tag = objDoctorArr[i];

				m_lsvExpertID.Items.Add(lviDoctor);
			}

			clsPublicFunction.s_mthChangeListViewLastColumnWidth(m_lsvExpertID);
			m_lsvExpertID.BringToFront();
			m_lsvExpertID.Visible = true;
		}

		private void m_lsvExpertID_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
			if(m_lsvExpertID.SelectedItems.Count <= 0)
				return;

			clsEmployee objEmp = (clsEmployee)m_lsvExpertID.SelectedItems[0].Tag;

			if(objEmp == null)
				return;	

			m_lsvExpertID.Visible = false;
//			m_txtExpertID.Text=objEmp.m_StrEmployeeID;
//			m_txtName.Text= objEmp.m_StrFirstName;
			m_mthSetGUIFromContent(objEmp);
			m_txtExpertID.Focus();
		}

		private void m_lsvExpertID_LostFocus(object sender,EventArgs e)
		{							
			if(!m_lsvExpertID.Focused)
			{
				m_lsvExpertID.Visible=false;				
			}
		}	

		#endregion 通过ID或Name查找签名

		/// <summary>
		/// 设置界面值
		/// </summary>
		/// <param name="p_objContent"></param>
		private void m_mthSetGUIFromContent(clsEmployee p_objContent)
		{
			if(p_objContent==null)
				return;
			this.m_txtExpertID.Text=p_objContent.m_StrEmployeeID;
			this.m_txtExpertID.Tag=p_objContent.m_StrEmployeeID;//作为判断界面与内存中对象是否一致.
			this.m_txtName.Text=p_objContent.m_StrFirstName;
			this.m_txtIDCard.Text=p_objContent.m_StrIDCard;
			this.m_cboSex.Text=p_objContent.m_StrSex;
			this.m_txtTitleOfaTechnicalPost.Text=p_objContent.m_StrTitleOfaTechnicalPost;
			this.m_txtOfficePhone.Text=p_objContent.m_StrOfficePhone;
			this.m_txtHomePhone.Text=p_objContent.m_StrHomePhone;
			this.m_txtMobile.Text=p_objContent.m_StrMobile;
			this.m_txtOfficeAddress.Text=p_objContent.m_StrOfficeAddress;
			this.m_txtOfficePC.Text=p_objContent.m_StrOfficePC;
			this.m_txtHomeAddress.Text=p_objContent.m_StrHomeAddress;
			this.m_txtHomePC.Text=p_objContent.m_StrHomePC;
			this.m_txtEMail.Text=p_objContent.m_StrEMail;
		}

		/// <summary>
		/// 从界面获取表单值
		/// </summary>
		/// <returns></returns>
		private clsEmployee_BaseInfo m_objGetContentFromGUI()
		{
			if(this.m_txtExpertID.Text.Trim() =="99" || this.m_txtExpertID.Text.Trim()=="")
				this.m_txtExpertID.Tag =null;

			if(this.m_txtExpertID.Tag !=null && this.m_txtExpertID.Text.Trim() !="99" && this.m_txtExpertID.Text.Trim()!=this.m_txtExpertID.Tag.ToString())
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,该员工不存在!");
				this.m_txtExpertID.Tag =null;
				return null;
			}			

			if( this.m_txtName.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("专家姓名不能为空!");
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
			if( ! m_blnIsAddNew)
				objEmployee_BaseInfo.m_strEmployeeID=this.m_txtExpertID.Tag.ToString();
			objEmployee_BaseInfo.m_strFirstName=this.m_txtName.Text.Trim();
			objEmployee_BaseInfo.m_strIDCard=this.m_txtIDCard.Text.Trim();
			objEmployee_BaseInfo.m_strSex=this.m_cboSex.Text;
			objEmployee_BaseInfo.m_strTitleOfaTechnicalPost=this.m_txtTitleOfaTechnicalPost.Text.Trim();
			objEmployee_BaseInfo.m_strOfficePhone=this.m_txtOfficePhone.Text.Trim();
			objEmployee_BaseInfo.m_strHomePhone=this.m_txtHomePhone.Text.Trim();
			objEmployee_BaseInfo.m_strMobile=this.m_txtMobile.Text.Trim();
			objEmployee_BaseInfo.m_strOfficeAddress=this.m_txtOfficeAddress.Text.Trim();
			objEmployee_BaseInfo.m_strOfficePC=this.m_txtOfficePC.Text.Trim();
			objEmployee_BaseInfo.m_strHomeAddress=this.m_txtHomeAddress.Text.Trim();
			objEmployee_BaseInfo.m_strHomePC=this.m_txtHomePC.Text.Trim();
			objEmployee_BaseInfo.m_strEMail=this.m_txtEMail.Text.Trim();
			objEmployee_BaseInfo.m_strDeptID=MDIParent.s_ObjDepartment.m_StrDeptID;
			return objEmployee_BaseInfo;
		}

		/// <summary>
		/// 添加/修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			m_lngSave();
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdDel_Click(object sender, System.EventArgs e)
		{
			m_lngDelete();
		}

		/// <summary>
		/// 退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
				if(p_ctlControl.HasChildren  && strTypeName !="DateTimePicker")
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
					if(((Control)sender).Name=="m_txtExpertID")
					{						
						m_mthGetDoctorList(m_txtExpertID.Text);

						if(m_lsvExpertID.Items.Count==1 && (m_txtExpertID.Text==m_lsvExpertID.Items[0].SubItems[0].Text|| m_txtExpertID.Text==m_lsvExpertID.Items[0].SubItems[1].Text))
						{
							m_lsvExpertID.Items[0].Selected=true;
							m_lsvExpertID_DoubleClick(null,null);
							break;
						}
					}					
					else if(((Control)sender).Name=="m_lsvExpertID")
					{
						m_lsvExpertID_DoubleClick(null,null);						
					}

					break;

				case 38:
				case 40:
					if(((Control)sender).Name=="m_txtExpertID")
					{
						if(m_txtExpertID.Text.Length>0)
						{	
							if(m_lsvExpertID.Visible==false || m_lsvExpertID.Items.Count==0)
							{								
								m_mthGetDoctorList(m_txtExpertID.Text);
							}

							m_lsvExpertID.BringToFront();
							m_lsvExpertID.Visible=true;
							m_lsvExpertID.Focus();
							if( m_lsvExpertID.Items.Count>0)
							{
								m_lsvExpertID.Items[0].Selected=true;
								m_lsvExpertID.Items[0].Focused=true;
							}	
						}
					}					
					break;
				case 113://save
					this.Save(); 
					break;
				case 114://del
					this.Delete(); 
					break;
				case 115://print
					this.Print();
					break;
				case 116://refresh
					m_mthClearUp();
					break;
				case 117://Search					
					break;
			}	
		}		
		#endregion

		private bool m_blnIsAddNew
		{
			get
			{
				return m_txtExpertID.Tag==null;
			}			
		}

		private long  m_lngSave()
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmAddOuterExpert,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif

			clsEmployee_BaseInfo objEmployee_BaseInfo=m_objGetContentFromGUI();
			if(objEmployee_BaseInfo==null)
			{				
				return -1;
			}

			long lngRes=0;
			string strNewEmployeeID="";
			if( m_blnIsAddNew)
			{
				if(m_objCurrentContext.m_ObjControl.m_enmModifyCheck(clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,this,enmFormState.NowUser)
					== enmDBControlCheckResult.Disable)
				{
					clsPublicFunction.s_mthShowNotPermitMessage();
					return -1;
				}
				lngRes= new clsEmployeeManager().m_lngAddNewRecord(objEmployee_BaseInfo,out strNewEmployeeID);
			}
			else 
			{
				if(m_objCurrentContext.m_ObjControl.m_enmAddNewCheck(clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,this,enmFormState.NowUser)
					== enmDBControlCheckResult.Disable)
				{
					clsPublicFunction.s_mthShowNotPermitMessage();
					return -1;
				}

				if(!clsPublicFunction.s_blnAskForModify())
					return 1;

				lngRes= new clsEmployeeManager().m_lngModifyRecord(objEmployee_BaseInfo);
			}
			if(lngRes<=0)
			{
				if(lngRes==(long)iCareData.enmOperationResult.Parameter_Error)
				{
					clsPublicFunction.ShowInformationMessageBox("参数错误");
				}
				else
				{
					clsPublicFunction.ShowInformationMessageBox("保存失败");
				}
			}
			else if(m_blnIsAddNew)//lngRes>0
			{
				this.m_txtExpertID.Text=strNewEmployeeID;
				this.m_txtExpertID.Tag=strNewEmployeeID;				
			}

			return lngRes;
		}

		private long  m_lngDelete()
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmAddOuterExpert,PrivilegeData.enmPrivilegeOperation.Delete))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif

			if( m_blnIsAddNew || this.m_txtName.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,该员工不存在!");
				m_txtExpertID.Focus();
				return 1;
			}

			if(!clsPublicFunction.s_blnAskForDelete())
				return 1;

			clsEmployee_BaseInfo objEmployee_BaseInfo=m_objGetContentFromGUI();
			if(objEmployee_BaseInfo==null || objEmployee_BaseInfo.m_strEmployeeID==null)//说明当前没有要删除的员工
				return 1;
			objEmployee_BaseInfo.m_strDeActivedOperatorID=MDIParent.OperatorID;
			long lngRes= new clsEmployeeManager().m_lngDeleteRecord(objEmployee_BaseInfo);

			if(lngRes<=0)
			{
				if(lngRes==(long)iCareData.enmOperationResult.Parameter_Error)
				{
					clsPublicFunction.ShowInformationMessageBox("参数错误");
				}
				else
				{
					clsPublicFunction.ShowInformationMessageBox("删除失败");
				}
			}
			else m_mthClearUp();
			return lngRes;
		}

		private void  m_mthClearUp()
		{
			this.m_txtExpertID.Text="99";
			this.m_txtExpertID.Tag=null;//作为判断界面与内存中对象是否一致.
			this.m_txtName.Text="";
			this.m_txtIDCard.Text="";
			this.m_cboSex.Text="";
			this.m_txtTitleOfaTechnicalPost.Text="";
			this.m_txtOfficePhone.Text="";
			this.m_txtHomePhone.Text="";
			this.m_txtMobile.Text="";
			this.m_txtOfficeAddress.Text="";
			this.m_txtOfficePC.Text="";
			this.m_txtHomeAddress.Text="";
			this.m_txtHomePC.Text="";
			this.m_txtEMail.Text="";			
		}

		#region DataControl
		public void Save()
		{			
			this.m_lngSave();
		}		
		public void Delete()
		{
			m_lngDelete();
		}
		public void Display(){}
		public void Display(string strInPatientID,string strInPatientDate)
		{
		}
		public void Print()
		{						
		}
		public void Copy(){}
		public void Cut(){}
		public void Paste(){}
		public void Redo(){}
		public void Undo(){}
		public void Verify()
		{
			////long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		#endregion

		private void frmAddOuterExpert_Load(object sender, System.EventArgs e)
		{
			m_cboSex.AddRangeItems(new Object[]{"男","女"});
			m_mthSetQuickKeys();

			m_objHighLight.m_mthAddControlInContainer(this);

			m_txtExpertID.Focus();
		}
	}
}
