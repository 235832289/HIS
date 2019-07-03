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
	/// Summary description for frmPatientDetailInfo.
	/// </summary>
	public class frmPatientDetailInfo : iCare.iCareBaseForm.frmBaseForm
	{
		#region  Member

		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOffice_district;
		private System.Windows.Forms.Label label46;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOffice_street;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label lblNation;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficeName;
		private System.Windows.Forms.Label lblNationality;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboNationality;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficePC;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboNation;
		private System.Windows.Forms.Label lblOccupation;
		private System.Windows.Forms.Label lblHomeplace;
		private System.Windows.Forms.Label lblPatientRelation;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOccupation;
		protected System.Windows.Forms.Label lblOfficePhoneTitle;
		protected System.Windows.Forms.Label lblHomePhoneTitle;
		private System.Windows.Forms.Label lblLinkManPhone;
		protected System.Windows.Forms.Label lblHomeAddressTitle;
		private System.Windows.Forms.Label lblLinkMan;
		protected System.Windows.Forms.Label lblHomePCTitle;
		protected System.Windows.Forms.Label lblOfficePCTitle;
		private System.Windows.Forms.GroupBox groupBox1;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboLinkManRelation;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboVisit_type;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboInsurance;
		private System.Windows.Forms.Label lblLinkManAddress;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTempPhone;
		private System.Windows.Forms.Label label50;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTemp_street;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTemp_district;
		private System.Windows.Forms.Label label53;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLinkManPhone;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficePhone;
		protected System.Windows.Forms.Label lblIDCardTitle;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomePhone;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomePC;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtIDCard;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLinkManPC;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLinkMan;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboVip_code;
		private System.Windows.Forms.Label label42;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboLinkMan_district;
		private System.Windows.Forms.Label label3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLinkMan_street;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label51;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboHome_district;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHome_street;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label54;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txttemp_zipcode;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.GroupBox m_gpbMust;
		private System.Windows.Forms.NumericUpDown m_numTimes;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.CheckBox m_chkIsOldPatient;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboMarried;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboSex;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpBirth;
		protected System.Windows.Forms.Label lblNameTitle;
		protected System.Windows.Forms.Label lblSexTitle;
		protected System.Windows.Forms.Label lblInPatientIDTitle;
		protected System.Windows.Forms.Label lblMarriedTitle;
		protected System.Windows.Forms.Label label1;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboAdmiss_status;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtInPatientID;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientFirstName;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboPaymentPercent;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label43;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHic_no;
		private System.Windows.Forms.Label label44;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientID;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboChargeCategory;
		private System.Windows.Forms.Label lblChargeCategory;
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboNativePlace;
		private System.Windows.Forms.Label label2;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboBornPlace;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public frmPatientDetailInfo()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_mthAddValueToComboBox();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			new clsBorderTool(Color.White).m_mthChangedControlBorder(m_numTimes);
		}		
		public frmPatientDetailInfo(clsPatientBaseInfo p_objPatientBaseInfo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_mthAddValueToComboBox();


			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			new clsBorderTool(Color.White).m_mthChangedControlBorder(m_numTimes);
			m_objPatientBaseInfo=p_objPatientBaseInfo;
			m_mthSetGUIFromContent(p_objPatientBaseInfo);
		}
		private clsPatientBaseInfo m_objPatientBaseInfo;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPatientDetailInfo));
			this.m_cboOffice_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label46 = new System.Windows.Forms.Label();
			this.m_txtOffice_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.lblNation = new System.Windows.Forms.Label();
			this.m_txtOfficeName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblNationality = new System.Windows.Forms.Label();
			this.m_cboNationality = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtOfficePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboNation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblOccupation = new System.Windows.Forms.Label();
			this.lblHomeplace = new System.Windows.Forms.Label();
			this.m_cboNativePlace = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblPatientRelation = new System.Windows.Forms.Label();
			this.m_cboOccupation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblOfficePhoneTitle = new System.Windows.Forms.Label();
			this.lblHomePhoneTitle = new System.Windows.Forms.Label();
			this.lblLinkManPhone = new System.Windows.Forms.Label();
			this.lblHomeAddressTitle = new System.Windows.Forms.Label();
			this.lblLinkMan = new System.Windows.Forms.Label();
			this.lblHomePCTitle = new System.Windows.Forms.Label();
			this.lblOfficePCTitle = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_cboPaymentPercent = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label45 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.m_txtHic_no = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.m_txtPatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboChargeCategory = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblChargeCategory = new System.Windows.Forms.Label();
			this.m_cboLinkManRelation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboAdmiss_status = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboVisit_type = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label56 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.m_cboInsurance = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblLinkManAddress = new System.Windows.Forms.Label();
			this.m_txtTempPhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.m_txtTemp_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboTemp_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label53 = new System.Windows.Forms.Label();
			this.m_txtLinkManPhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtOfficePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblIDCardTitle = new System.Windows.Forms.Label();
			this.m_txtHomePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtHomePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtIDCard = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtLinkManPC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtLinkMan = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboVip_code = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label42 = new System.Windows.Forms.Label();
			this.m_cboLinkMan_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtLinkMan_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label49 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.m_cboHome_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtHome_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.m_txttemp_zipcode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.m_cboBornPlace = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_gpbMust = new System.Windows.Forms.GroupBox();
			this.m_numTimes = new System.Windows.Forms.NumericUpDown();
			this.label41 = new System.Windows.Forms.Label();
			this.m_chkIsOldPatient = new System.Windows.Forms.CheckBox();
			this.m_cboMarried = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboSex = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_dtpBirth = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.lblNameTitle = new System.Windows.Forms.Label();
			this.lblSexTitle = new System.Windows.Forms.Label();
			this.lblInPatientIDTitle = new System.Windows.Forms.Label();
			this.lblMarriedTitle = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtInPatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtPatientFirstName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.groupBox1.SuspendLayout();
			this.m_gpbMust.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_numTimes)).BeginInit();
			this.SuspendLayout();
			// 
			// m_cboOffice_district
			// 
			this.m_cboOffice_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboOffice_district.BorderColor = System.Drawing.Color.Black;
			this.m_cboOffice_district.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboOffice_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOffice_district.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboOffice_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboOffice_district.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOffice_district.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOffice_district.ForeColor = System.Drawing.Color.Black;
			this.m_cboOffice_district.ListBackColor = System.Drawing.Color.White;
			this.m_cboOffice_district.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboOffice_district.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboOffice_district.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboOffice_district.Location = new System.Drawing.Point(98, 160);
			this.m_cboOffice_district.m_BlnEnableItemEventMenu = true;
			this.m_cboOffice_district.Name = "m_cboOffice_district";
			this.m_cboOffice_district.SelectedIndex = -1;
			this.m_cboOffice_district.SelectedItem = null;
			this.m_cboOffice_district.SelectionStart = 0;
			this.m_cboOffice_district.Size = new System.Drawing.Size(162, 23);
			this.m_cboOffice_district.TabIndex = 12;
			this.m_cboOffice_district.TextBackColor = System.Drawing.Color.White;
			this.m_cboOffice_district.TextForeColor = System.Drawing.Color.Black;
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.BackColor = System.Drawing.SystemColors.Control;
			this.label46.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label46.ForeColor = System.Drawing.Color.Black;
			this.label46.Location = new System.Drawing.Point(276, 164);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(41, 19);
			this.label46.TabIndex = 29480;
			this.label46.Text = "街道:";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtOffice_street
			// 
			this.m_txtOffice_street.BackColor = System.Drawing.Color.White;
			this.m_txtOffice_street.BorderColor = System.Drawing.Color.White;
			this.m_txtOffice_street.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOffice_street.ForeColor = System.Drawing.Color.Black;
			this.m_txtOffice_street.Location = new System.Drawing.Point(320, 160);
			this.m_txtOffice_street.MaxLength = 20;
			this.m_txtOffice_street.Name = "m_txtOffice_street";
			this.m_txtOffice_street.Size = new System.Drawing.Size(232, 23);
			this.m_txtOffice_street.TabIndex = 13;
			this.m_txtOffice_street.Text = "";
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.BackColor = System.Drawing.SystemColors.Control;
			this.label47.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label47.ForeColor = System.Drawing.Color.Black;
			this.label47.Location = new System.Drawing.Point(10, 164);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(70, 19);
			this.label47.TabIndex = 29475;
			this.label47.Text = "省    市:";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.BackColor = System.Drawing.SystemColors.Control;
			this.label48.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label48.ForeColor = System.Drawing.Color.Black;
			this.label48.Location = new System.Drawing.Point(276, 128);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(70, 19);
			this.label48.TabIndex = 29474;
			this.label48.Text = "工作单位:";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblNation
			// 
			this.lblNation.AutoSize = true;
			this.lblNation.BackColor = System.Drawing.SystemColors.Control;
			this.lblNation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNation.ForeColor = System.Drawing.Color.Black;
			this.lblNation.Location = new System.Drawing.Point(416, 92);
			this.lblNation.Name = "lblNation";
			this.lblNation.Size = new System.Drawing.Size(41, 19);
			this.lblNation.TabIndex = 29450;
			this.lblNation.Text = "民族:";
			this.lblNation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtOfficeName
			// 
			this.m_txtOfficeName.BackColor = System.Drawing.Color.White;
			this.m_txtOfficeName.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficeName.ForeColor = System.Drawing.Color.Black;
			this.m_txtOfficeName.Location = new System.Drawing.Point(348, 124);
			this.m_txtOfficeName.MaxLength = 16;
			this.m_txtOfficeName.Name = "m_txtOfficeName";
			this.m_txtOfficeName.Size = new System.Drawing.Size(204, 23);
			this.m_txtOfficeName.TabIndex = 10;
			this.m_txtOfficeName.Text = "";
			// 
			// lblNationality
			// 
			this.lblNationality.AutoSize = true;
			this.lblNationality.BackColor = System.Drawing.SystemColors.Control;
			this.lblNationality.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNationality.ForeColor = System.Drawing.Color.Black;
			this.lblNationality.Location = new System.Drawing.Point(276, 92);
			this.lblNationality.Name = "lblNationality";
			this.lblNationality.Size = new System.Drawing.Size(41, 19);
			this.lblNationality.TabIndex = 29449;
			this.lblNationality.Text = "国籍:";
			this.lblNationality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboNationality
			// 
			this.m_cboNationality.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboNationality.BorderColor = System.Drawing.Color.Black;
			this.m_cboNationality.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboNationality.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboNationality.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboNationality.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNationality.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNationality.ForeColor = System.Drawing.Color.Black;
			this.m_cboNationality.ListBackColor = System.Drawing.Color.White;
			this.m_cboNationality.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboNationality.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboNationality.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboNationality.Location = new System.Drawing.Point(320, 88);
			this.m_cboNationality.m_BlnEnableItemEventMenu = true;
			this.m_cboNationality.Name = "m_cboNationality";
			this.m_cboNationality.SelectedIndex = -1;
			this.m_cboNationality.SelectedItem = null;
			this.m_cboNationality.SelectionStart = 0;
			this.m_cboNationality.Size = new System.Drawing.Size(80, 23);
			this.m_cboNationality.TabIndex = 8;
			this.m_cboNationality.TextBackColor = System.Drawing.Color.White;
			this.m_cboNationality.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtOfficePC
			// 
			this.m_txtOfficePC.BackColor = System.Drawing.Color.White;
			this.m_txtOfficePC.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficePC.ForeColor = System.Drawing.Color.Black;
			this.m_txtOfficePC.Location = new System.Drawing.Point(628, 160);
			this.m_txtOfficePC.MaxLength = 6;
			this.m_txtOfficePC.Name = "m_txtOfficePC";
			this.m_txtOfficePC.Size = new System.Drawing.Size(140, 23);
			this.m_txtOfficePC.TabIndex = 14;
			this.m_txtOfficePC.Text = "";
			// 
			// m_cboNation
			// 
			this.m_cboNation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboNation.BorderColor = System.Drawing.Color.Black;
			this.m_cboNation.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboNation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboNation.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboNation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNation.ForeColor = System.Drawing.Color.Black;
			this.m_cboNation.ListBackColor = System.Drawing.Color.White;
			this.m_cboNation.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboNation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboNation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboNation.Location = new System.Drawing.Point(460, 88);
			this.m_cboNation.m_BlnEnableItemEventMenu = true;
			this.m_cboNation.Name = "m_cboNation";
			this.m_cboNation.SelectedIndex = -1;
			this.m_cboNation.SelectedItem = null;
			this.m_cboNation.SelectionStart = 0;
			this.m_cboNation.Size = new System.Drawing.Size(92, 23);
			this.m_cboNation.TabIndex = 7;
			this.m_cboNation.TextBackColor = System.Drawing.Color.White;
			this.m_cboNation.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblOccupation
			// 
			this.lblOccupation.AutoSize = true;
			this.lblOccupation.BackColor = System.Drawing.SystemColors.Control;
			this.lblOccupation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOccupation.ForeColor = System.Drawing.Color.Black;
			this.lblOccupation.Location = new System.Drawing.Point(10, 128);
			this.lblOccupation.Name = "lblOccupation";
			this.lblOccupation.Size = new System.Drawing.Size(70, 19);
			this.lblOccupation.TabIndex = 29451;
			this.lblOccupation.Text = "职    业:";
			this.lblOccupation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHomeplace
			// 
			this.lblHomeplace.AutoSize = true;
			this.lblHomeplace.BackColor = System.Drawing.SystemColors.Control;
			this.lblHomeplace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomeplace.ForeColor = System.Drawing.Color.Black;
			this.lblHomeplace.Location = new System.Drawing.Point(10, 92);
			this.lblHomeplace.Name = "lblHomeplace";
			this.lblHomeplace.Size = new System.Drawing.Size(70, 19);
			this.lblHomeplace.TabIndex = 29455;
			this.lblHomeplace.Text = "籍    贯:";
			this.lblHomeplace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboNativePlace
			// 
			this.m_cboNativePlace.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboNativePlace.BorderColor = System.Drawing.Color.Black;
			this.m_cboNativePlace.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboNativePlace.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboNativePlace.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboNativePlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboNativePlace.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNativePlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNativePlace.ForeColor = System.Drawing.Color.Black;
			this.m_cboNativePlace.ListBackColor = System.Drawing.Color.White;
			this.m_cboNativePlace.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboNativePlace.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboNativePlace.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboNativePlace.Location = new System.Drawing.Point(98, 88);
			this.m_cboNativePlace.m_BlnEnableItemEventMenu = true;
			this.m_cboNativePlace.Name = "m_cboNativePlace";
			this.m_cboNativePlace.SelectedIndex = -1;
			this.m_cboNativePlace.SelectedItem = null;
			this.m_cboNativePlace.SelectionStart = 0;
			this.m_cboNativePlace.Size = new System.Drawing.Size(160, 23);
			this.m_cboNativePlace.TabIndex = 6;
			this.m_cboNativePlace.TextBackColor = System.Drawing.Color.White;
			this.m_cboNativePlace.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblPatientRelation
			// 
			this.lblPatientRelation.AutoSize = true;
			this.lblPatientRelation.BackColor = System.Drawing.SystemColors.Control;
			this.lblPatientRelation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPatientRelation.ForeColor = System.Drawing.Color.Black;
			this.lblPatientRelation.Location = new System.Drawing.Point(276, 200);
			this.lblPatientRelation.Name = "lblPatientRelation";
			this.lblPatientRelation.Size = new System.Drawing.Size(41, 19);
			this.lblPatientRelation.TabIndex = 29456;
			this.lblPatientRelation.Text = "关系:";
			this.lblPatientRelation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboOccupation
			// 
			this.m_cboOccupation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboOccupation.BorderColor = System.Drawing.Color.Black;
			this.m_cboOccupation.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboOccupation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOccupation.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboOccupation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboOccupation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOccupation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOccupation.ForeColor = System.Drawing.Color.Black;
			this.m_cboOccupation.ListBackColor = System.Drawing.Color.White;
			this.m_cboOccupation.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboOccupation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboOccupation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboOccupation.Location = new System.Drawing.Point(98, 124);
			this.m_cboOccupation.m_BlnEnableItemEventMenu = true;
			this.m_cboOccupation.Name = "m_cboOccupation";
			this.m_cboOccupation.SelectedIndex = -1;
			this.m_cboOccupation.SelectedItem = null;
			this.m_cboOccupation.SelectionStart = 0;
			this.m_cboOccupation.Size = new System.Drawing.Size(160, 23);
			this.m_cboOccupation.TabIndex = 9;
			this.m_cboOccupation.TextBackColor = System.Drawing.Color.White;
			this.m_cboOccupation.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblOfficePhoneTitle
			// 
			this.lblOfficePhoneTitle.AutoSize = true;
			this.lblOfficePhoneTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblOfficePhoneTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePhoneTitle.ForeColor = System.Drawing.Color.Black;
			this.lblOfficePhoneTitle.Location = new System.Drawing.Point(568, 128);
			this.lblOfficePhoneTitle.Name = "lblOfficePhoneTitle";
			this.lblOfficePhoneTitle.Size = new System.Drawing.Size(70, 19);
			this.lblOfficePhoneTitle.TabIndex = 29462;
			this.lblOfficePhoneTitle.Text = "办公电话:";
			this.lblOfficePhoneTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHomePhoneTitle
			// 
			this.lblHomePhoneTitle.AutoSize = true;
			this.lblHomePhoneTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblHomePhoneTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePhoneTitle.ForeColor = System.Drawing.Color.Black;
			this.lblHomePhoneTitle.Location = new System.Drawing.Point(10, 308);
			this.lblHomePhoneTitle.Name = "lblHomePhoneTitle";
			this.lblHomePhoneTitle.Size = new System.Drawing.Size(70, 19);
			this.lblHomePhoneTitle.TabIndex = 29466;
			this.lblHomePhoneTitle.Text = "家庭电话:";
			this.lblHomePhoneTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLinkManPhone
			// 
			this.lblLinkManPhone.AutoSize = true;
			this.lblLinkManPhone.BackColor = System.Drawing.SystemColors.Control;
			this.lblLinkManPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLinkManPhone.ForeColor = System.Drawing.Color.Black;
			this.lblLinkManPhone.Location = new System.Drawing.Point(568, 200);
			this.lblLinkManPhone.Name = "lblLinkManPhone";
			this.lblLinkManPhone.Size = new System.Drawing.Size(84, 19);
			this.lblLinkManPhone.TabIndex = 29454;
			this.lblLinkManPhone.Text = "联系人电话:";
			this.lblLinkManPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHomeAddressTitle
			// 
			this.lblHomeAddressTitle.AutoSize = true;
			this.lblHomeAddressTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblHomeAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomeAddressTitle.ForeColor = System.Drawing.Color.Black;
			this.lblHomeAddressTitle.Location = new System.Drawing.Point(10, 272);
			this.lblHomeAddressTitle.Name = "lblHomeAddressTitle";
			this.lblHomeAddressTitle.Size = new System.Drawing.Size(70, 19);
			this.lblHomeAddressTitle.TabIndex = 29463;
			this.lblHomeAddressTitle.Text = "家庭地址:";
			this.lblHomeAddressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLinkMan
			// 
			this.lblLinkMan.AutoSize = true;
			this.lblLinkMan.BackColor = System.Drawing.SystemColors.Control;
			this.lblLinkMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLinkMan.ForeColor = System.Drawing.Color.Black;
			this.lblLinkMan.Location = new System.Drawing.Point(10, 200);
			this.lblLinkMan.Name = "lblLinkMan";
			this.lblLinkMan.Size = new System.Drawing.Size(70, 19);
			this.lblLinkMan.TabIndex = 29452;
			this.lblLinkMan.Text = "联 系 人:";
			this.lblLinkMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHomePCTitle
			// 
			this.lblHomePCTitle.AutoSize = true;
			this.lblHomePCTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblHomePCTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePCTitle.ForeColor = System.Drawing.Color.Black;
			this.lblHomePCTitle.Location = new System.Drawing.Point(276, 308);
			this.lblHomePCTitle.Name = "lblHomePCTitle";
			this.lblHomePCTitle.Size = new System.Drawing.Size(41, 19);
			this.lblHomePCTitle.TabIndex = 29459;
			this.lblHomePCTitle.Text = "邮编:";
			this.lblHomePCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblOfficePCTitle
			// 
			this.lblOfficePCTitle.AutoSize = true;
			this.lblOfficePCTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblOfficePCTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePCTitle.ForeColor = System.Drawing.Color.Black;
			this.lblOfficePCTitle.Location = new System.Drawing.Point(568, 164);
			this.lblOfficePCTitle.Name = "lblOfficePCTitle";
			this.lblOfficePCTitle.Size = new System.Drawing.Size(41, 19);
			this.lblOfficePCTitle.TabIndex = 29460;
			this.lblOfficePCTitle.Text = "邮编:";
			this.lblOfficePCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Controls.Add(this.m_cboPaymentPercent);
			this.groupBox1.Controls.Add(this.label45);
			this.groupBox1.Controls.Add(this.label43);
			this.groupBox1.Controls.Add(this.m_txtHic_no);
			this.groupBox1.Controls.Add(this.label44);
			this.groupBox1.Controls.Add(this.m_txtPatientID);
			this.groupBox1.Controls.Add(this.m_cboChargeCategory);
			this.groupBox1.Controls.Add(this.lblChargeCategory);
			this.groupBox1.Controls.Add(this.m_cboLinkManRelation);
			this.groupBox1.Controls.Add(this.m_cboAdmiss_status);
			this.groupBox1.Controls.Add(this.m_cboVisit_type);
			this.groupBox1.Controls.Add(this.label56);
			this.groupBox1.Controls.Add(this.label57);
			this.groupBox1.Controls.Add(this.m_cboInsurance);
			this.groupBox1.Controls.Add(this.lblLinkManAddress);
			this.groupBox1.Controls.Add(this.m_txtTempPhone);
			this.groupBox1.Controls.Add(this.label50);
			this.groupBox1.Controls.Add(this.m_txtTemp_street);
			this.groupBox1.Controls.Add(this.m_cboTemp_district);
			this.groupBox1.Controls.Add(this.label53);
			this.groupBox1.Controls.Add(this.m_txtLinkManPhone);
			this.groupBox1.Controls.Add(this.m_txtOfficePhone);
			this.groupBox1.Controls.Add(this.m_cboOffice_district);
			this.groupBox1.Controls.Add(this.label46);
			this.groupBox1.Controls.Add(this.m_txtOffice_street);
			this.groupBox1.Controls.Add(this.label47);
			this.groupBox1.Controls.Add(this.label48);
			this.groupBox1.Controls.Add(this.m_txtOfficeName);
			this.groupBox1.Controls.Add(this.m_cboNationality);
			this.groupBox1.Controls.Add(this.m_cboNation);
			this.groupBox1.Controls.Add(this.m_cboNativePlace);
			this.groupBox1.Controls.Add(this.m_cboOccupation);
			this.groupBox1.Controls.Add(this.lblOfficePhoneTitle);
			this.groupBox1.Controls.Add(this.lblHomePhoneTitle);
			this.groupBox1.Controls.Add(this.lblHomeAddressTitle);
			this.groupBox1.Controls.Add(this.lblHomePCTitle);
			this.groupBox1.Controls.Add(this.lblOfficePCTitle);
			this.groupBox1.Controls.Add(this.lblIDCardTitle);
			this.groupBox1.Controls.Add(this.lblNation);
			this.groupBox1.Controls.Add(this.lblNationality);
			this.groupBox1.Controls.Add(this.lblOccupation);
			this.groupBox1.Controls.Add(this.lblHomeplace);
			this.groupBox1.Controls.Add(this.lblPatientRelation);
			this.groupBox1.Controls.Add(this.lblLinkManPhone);
			this.groupBox1.Controls.Add(this.lblLinkMan);
			this.groupBox1.Controls.Add(this.m_txtHomePhone);
			this.groupBox1.Controls.Add(this.m_txtOfficePC);
			this.groupBox1.Controls.Add(this.m_txtHomePC);
			this.groupBox1.Controls.Add(this.m_txtIDCard);
			this.groupBox1.Controls.Add(this.m_txtLinkManPC);
			this.groupBox1.Controls.Add(this.m_txtLinkMan);
			this.groupBox1.Controls.Add(this.m_cboVip_code);
			this.groupBox1.Controls.Add(this.label42);
			this.groupBox1.Controls.Add(this.m_cboLinkMan_district);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.m_txtLinkMan_street);
			this.groupBox1.Controls.Add(this.label49);
			this.groupBox1.Controls.Add(this.label51);
			this.groupBox1.Controls.Add(this.m_cboHome_district);
			this.groupBox1.Controls.Add(this.m_txtHome_street);
			this.groupBox1.Controls.Add(this.label52);
			this.groupBox1.Controls.Add(this.label54);
			this.groupBox1.Controls.Add(this.m_txttemp_zipcode);
			this.groupBox1.Controls.Add(this.label55);
			this.groupBox1.Controls.Add(this.m_cboBornPlace);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.ForeColor = System.Drawing.Color.Black;
			this.groupBox1.Location = new System.Drawing.Point(43, 127);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(793, 453);
			this.groupBox1.TabIndex = 29396;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "基本资料";
			// 
			// m_cboPaymentPercent
			// 
			this.m_cboPaymentPercent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPaymentPercent.BorderColor = System.Drawing.Color.Black;
			this.m_cboPaymentPercent.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboPaymentPercent.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPaymentPercent.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPaymentPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboPaymentPercent.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPaymentPercent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPaymentPercent.ForeColor = System.Drawing.Color.Black;
			this.m_cboPaymentPercent.ListBackColor = System.Drawing.Color.White;
			this.m_cboPaymentPercent.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPaymentPercent.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPaymentPercent.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPaymentPercent.Location = new System.Drawing.Point(566, 56);
			this.m_cboPaymentPercent.m_BlnEnableItemEventMenu = true;
			this.m_cboPaymentPercent.Name = "m_cboPaymentPercent";
			this.m_cboPaymentPercent.SelectedIndex = -1;
			this.m_cboPaymentPercent.SelectedItem = null;
			this.m_cboPaymentPercent.SelectionStart = 0;
			this.m_cboPaymentPercent.Size = new System.Drawing.Size(202, 23);
			this.m_cboPaymentPercent.TabIndex = 5;
			this.m_cboPaymentPercent.TextBackColor = System.Drawing.Color.White;
			this.m_cboPaymentPercent.TextForeColor = System.Drawing.Color.Black;
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.BackColor = System.Drawing.SystemColors.Control;
			this.label45.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label45.ForeColor = System.Drawing.Color.Black;
			this.label45.Location = new System.Drawing.Point(472, 60);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(70, 19);
			this.label45.TabIndex = 29503;
			this.label45.Text = "比    例:";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.BackColor = System.Drawing.SystemColors.Control;
			this.label43.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label43.ForeColor = System.Drawing.Color.Black;
			this.label43.Location = new System.Drawing.Point(10, 60);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(70, 19);
			this.label43.TabIndex = 29502;
			this.label43.Text = "医 疗 证:";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtHic_no
			// 
			this.m_txtHic_no.BackColor = System.Drawing.Color.White;
			this.m_txtHic_no.BorderColor = System.Drawing.Color.White;
			this.m_txtHic_no.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHic_no.ForeColor = System.Drawing.Color.Black;
			this.m_txtHic_no.Location = new System.Drawing.Point(98, 56);
			this.m_txtHic_no.MaxLength = 10;
			this.m_txtHic_no.Name = "m_txtHic_no";
			this.m_txtHic_no.Size = new System.Drawing.Size(86, 23);
			this.m_txtHic_no.TabIndex = 1;
			this.m_txtHic_no.Text = "";
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.BackColor = System.Drawing.SystemColors.Control;
			this.label44.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label44.ForeColor = System.Drawing.Color.Black;
			this.label44.Location = new System.Drawing.Point(10, 24);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(70, 19);
			this.label44.TabIndex = 29500;
			this.label44.Text = "门 诊 号:";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtPatientID
			// 
			this.m_txtPatientID.BackColor = System.Drawing.Color.White;
			this.m_txtPatientID.BorderColor = System.Drawing.Color.White;
			this.m_txtPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPatientID.ForeColor = System.Drawing.Color.Black;
			this.m_txtPatientID.Location = new System.Drawing.Point(98, 20);
			this.m_txtPatientID.MaxLength = 12;
			this.m_txtPatientID.Name = "m_txtPatientID";
			this.m_txtPatientID.Size = new System.Drawing.Size(86, 23);
			this.m_txtPatientID.TabIndex = 0;
			this.m_txtPatientID.Text = "";
			// 
			// m_cboChargeCategory
			// 
			this.m_cboChargeCategory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboChargeCategory.BorderColor = System.Drawing.Color.Black;
			this.m_cboChargeCategory.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboChargeCategory.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboChargeCategory.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboChargeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboChargeCategory.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboChargeCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboChargeCategory.ForeColor = System.Drawing.Color.Black;
			this.m_cboChargeCategory.ListBackColor = System.Drawing.Color.White;
			this.m_cboChargeCategory.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboChargeCategory.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboChargeCategory.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboChargeCategory.Location = new System.Drawing.Point(566, 24);
			this.m_cboChargeCategory.m_BlnEnableItemEventMenu = true;
			this.m_cboChargeCategory.Name = "m_cboChargeCategory";
			this.m_cboChargeCategory.SelectedIndex = -1;
			this.m_cboChargeCategory.SelectedItem = null;
			this.m_cboChargeCategory.SelectionStart = -1;
			this.m_cboChargeCategory.Size = new System.Drawing.Size(202, 23);
			this.m_cboChargeCategory.TabIndex = 4;
			this.m_cboChargeCategory.TextBackColor = System.Drawing.Color.White;
			this.m_cboChargeCategory.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblChargeCategory
			// 
			this.lblChargeCategory.AutoSize = true;
			this.lblChargeCategory.BackColor = System.Drawing.SystemColors.Control;
			this.lblChargeCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblChargeCategory.ForeColor = System.Drawing.Color.Black;
			this.lblChargeCategory.Location = new System.Drawing.Point(472, 28);
			this.lblChargeCategory.Name = "lblChargeCategory";
			this.lblChargeCategory.Size = new System.Drawing.Size(70, 19);
			this.lblChargeCategory.TabIndex = 29498;
			this.lblChargeCategory.Text = "收费种类:";
			this.lblChargeCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboLinkManRelation
			// 
			this.m_cboLinkManRelation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboLinkManRelation.BorderColor = System.Drawing.Color.Black;
			this.m_cboLinkManRelation.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboLinkManRelation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinkManRelation.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboLinkManRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboLinkManRelation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinkManRelation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinkManRelation.ForeColor = System.Drawing.Color.Black;
			this.m_cboLinkManRelation.ListBackColor = System.Drawing.Color.White;
			this.m_cboLinkManRelation.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboLinkManRelation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboLinkManRelation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboLinkManRelation.Location = new System.Drawing.Point(320, 196);
			this.m_cboLinkManRelation.m_BlnEnableItemEventMenu = true;
			this.m_cboLinkManRelation.Name = "m_cboLinkManRelation";
			this.m_cboLinkManRelation.SelectedIndex = -1;
			this.m_cboLinkManRelation.SelectedItem = null;
			this.m_cboLinkManRelation.SelectionStart = 0;
			this.m_cboLinkManRelation.Size = new System.Drawing.Size(232, 23);
			this.m_cboLinkManRelation.TabIndex = 16;
			this.m_cboLinkManRelation.TextBackColor = System.Drawing.Color.White;
			this.m_cboLinkManRelation.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboAdmiss_status
			// 
			this.m_cboAdmiss_status.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboAdmiss_status.BorderColor = System.Drawing.Color.Black;
			this.m_cboAdmiss_status.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboAdmiss_status.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboAdmiss_status.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboAdmiss_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboAdmiss_status.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboAdmiss_status.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboAdmiss_status.ForeColor = System.Drawing.Color.Black;
			this.m_cboAdmiss_status.ListBackColor = System.Drawing.Color.White;
			this.m_cboAdmiss_status.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboAdmiss_status.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboAdmiss_status.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboAdmiss_status.Location = new System.Drawing.Point(378, 412);
			this.m_cboAdmiss_status.m_BlnEnableItemEventMenu = true;
			this.m_cboAdmiss_status.Name = "m_cboAdmiss_status";
			this.m_cboAdmiss_status.SelectedIndex = -1;
			this.m_cboAdmiss_status.SelectedItem = null;
			this.m_cboAdmiss_status.SelectionStart = 0;
			this.m_cboAdmiss_status.Size = new System.Drawing.Size(140, 23);
			this.m_cboAdmiss_status.TabIndex = 30;
			this.m_cboAdmiss_status.TextBackColor = System.Drawing.Color.White;
			this.m_cboAdmiss_status.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboVisit_type
			// 
			this.m_cboVisit_type.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboVisit_type.BorderColor = System.Drawing.Color.Black;
			this.m_cboVisit_type.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboVisit_type.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboVisit_type.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboVisit_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboVisit_type.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboVisit_type.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboVisit_type.ForeColor = System.Drawing.Color.Black;
			this.m_cboVisit_type.ListBackColor = System.Drawing.Color.White;
			this.m_cboVisit_type.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboVisit_type.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboVisit_type.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboVisit_type.Location = new System.Drawing.Point(594, 412);
			this.m_cboVisit_type.m_BlnEnableItemEventMenu = true;
			this.m_cboVisit_type.Name = "m_cboVisit_type";
			this.m_cboVisit_type.SelectedIndex = -1;
			this.m_cboVisit_type.SelectedItem = null;
			this.m_cboVisit_type.SelectionStart = 0;
			this.m_cboVisit_type.Size = new System.Drawing.Size(140, 23);
			this.m_cboVisit_type.TabIndex = 31;
			this.m_cboVisit_type.TextBackColor = System.Drawing.Color.White;
			this.m_cboVisit_type.TextForeColor = System.Drawing.Color.Black;
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.BackColor = System.Drawing.SystemColors.Control;
			this.label56.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label56.ForeColor = System.Drawing.Color.Black;
			this.label56.Location = new System.Drawing.Point(534, 416);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(41, 19);
			this.label56.TabIndex = 29494;
			this.label56.Text = "访问:";
			this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.BackColor = System.Drawing.SystemColors.Control;
			this.label57.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label57.ForeColor = System.Drawing.Color.Black;
			this.label57.Location = new System.Drawing.Point(318, 416);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(41, 19);
			this.label57.TabIndex = 29492;
			this.label57.Text = "状态:";
			this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboInsurance
			// 
			this.m_cboInsurance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboInsurance.BorderColor = System.Drawing.Color.Black;
			this.m_cboInsurance.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboInsurance.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboInsurance.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboInsurance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboInsurance.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboInsurance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboInsurance.ForeColor = System.Drawing.Color.Black;
			this.m_cboInsurance.ListBackColor = System.Drawing.Color.White;
			this.m_cboInsurance.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboInsurance.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboInsurance.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboInsurance.Location = new System.Drawing.Point(98, 412);
			this.m_cboInsurance.m_BlnEnableItemEventMenu = true;
			this.m_cboInsurance.Name = "m_cboInsurance";
			this.m_cboInsurance.SelectedIndex = -1;
			this.m_cboInsurance.SelectedItem = null;
			this.m_cboInsurance.SelectionStart = 0;
			this.m_cboInsurance.Size = new System.Drawing.Size(196, 23);
			this.m_cboInsurance.TabIndex = 29;
			this.m_cboInsurance.TextBackColor = System.Drawing.Color.White;
			this.m_cboInsurance.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblLinkManAddress
			// 
			this.lblLinkManAddress.AutoSize = true;
			this.lblLinkManAddress.BackColor = System.Drawing.SystemColors.Control;
			this.lblLinkManAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLinkManAddress.ForeColor = System.Drawing.Color.Black;
			this.lblLinkManAddress.Location = new System.Drawing.Point(10, 416);
			this.lblLinkManAddress.Name = "lblLinkManAddress";
			this.lblLinkManAddress.Size = new System.Drawing.Size(70, 19);
			this.lblLinkManAddress.TabIndex = 29490;
			this.lblLinkManAddress.Text = "保险公司:";
			this.lblLinkManAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtTempPhone
			// 
			this.m_txtTempPhone.BackColor = System.Drawing.Color.White;
			this.m_txtTempPhone.BorderColor = System.Drawing.Color.White;
			this.m_txtTempPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTempPhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtTempPhone.Location = new System.Drawing.Point(122, 376);
			this.m_txtTempPhone.Name = "m_txtTempPhone";
			this.m_txtTempPhone.Size = new System.Drawing.Size(172, 23);
			this.m_txtTempPhone.TabIndex = 27;
			this.m_txtTempPhone.Text = "";
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.BackColor = System.Drawing.SystemColors.Control;
			this.label50.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label50.ForeColor = System.Drawing.Color.Black;
			this.label50.Location = new System.Drawing.Point(276, 344);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(41, 19);
			this.label50.TabIndex = 29489;
			this.label50.Text = "街道:";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtTemp_street
			// 
			this.m_txtTemp_street.BackColor = System.Drawing.Color.White;
			this.m_txtTemp_street.BorderColor = System.Drawing.Color.White;
			this.m_txtTemp_street.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemp_street.ForeColor = System.Drawing.Color.Black;
			this.m_txtTemp_street.Location = new System.Drawing.Point(320, 340);
			this.m_txtTemp_street.MaxLength = 20;
			this.m_txtTemp_street.Name = "m_txtTemp_street";
			this.m_txtTemp_street.Size = new System.Drawing.Size(444, 23);
			this.m_txtTemp_street.TabIndex = 26;
			this.m_txtTemp_street.Text = "";
			// 
			// m_cboTemp_district
			// 
			this.m_cboTemp_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTemp_district.BorderColor = System.Drawing.Color.Black;
			this.m_cboTemp_district.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTemp_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTemp_district.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTemp_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTemp_district.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTemp_district.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTemp_district.ForeColor = System.Drawing.Color.Black;
			this.m_cboTemp_district.ListBackColor = System.Drawing.Color.White;
			this.m_cboTemp_district.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTemp_district.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTemp_district.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTemp_district.Location = new System.Drawing.Point(98, 340);
			this.m_cboTemp_district.m_BlnEnableItemEventMenu = true;
			this.m_cboTemp_district.Name = "m_cboTemp_district";
			this.m_cboTemp_district.SelectedIndex = -1;
			this.m_cboTemp_district.SelectedItem = null;
			this.m_cboTemp_district.SelectionStart = 0;
			this.m_cboTemp_district.Size = new System.Drawing.Size(162, 23);
			this.m_cboTemp_district.TabIndex = 25;
			this.m_cboTemp_district.TextBackColor = System.Drawing.Color.White;
			this.m_cboTemp_district.TextForeColor = System.Drawing.Color.Black;
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.BackColor = System.Drawing.SystemColors.Control;
			this.label53.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label53.ForeColor = System.Drawing.Color.Black;
			this.label53.Location = new System.Drawing.Point(10, 344);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(70, 19);
			this.label53.TabIndex = 29486;
			this.label53.Text = "临时地址:";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtLinkManPhone
			// 
			this.m_txtLinkManPhone.BackColor = System.Drawing.Color.White;
			this.m_txtLinkManPhone.BorderColor = System.Drawing.Color.White;
			this.m_txtLinkManPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinkManPhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtLinkManPhone.Location = new System.Drawing.Point(660, 196);
			this.m_txtLinkManPhone.Name = "m_txtLinkManPhone";
			this.m_txtLinkManPhone.Size = new System.Drawing.Size(108, 23);
			this.m_txtLinkManPhone.TabIndex = 17;
			this.m_txtLinkManPhone.Text = "";
			// 
			// m_txtOfficePhone
			// 
			this.m_txtOfficePhone.BackColor = System.Drawing.Color.White;
			this.m_txtOfficePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficePhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficePhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtOfficePhone.Location = new System.Drawing.Point(644, 124);
			this.m_txtOfficePhone.Name = "m_txtOfficePhone";
			this.m_txtOfficePhone.Size = new System.Drawing.Size(124, 23);
			this.m_txtOfficePhone.TabIndex = 11;
			this.m_txtOfficePhone.Text = "";
			// 
			// lblIDCardTitle
			// 
			this.lblIDCardTitle.AutoSize = true;
			this.lblIDCardTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblIDCardTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblIDCardTitle.ForeColor = System.Drawing.Color.Black;
			this.lblIDCardTitle.Location = new System.Drawing.Point(204, 60);
			this.lblIDCardTitle.Name = "lblIDCardTitle";
			this.lblIDCardTitle.Size = new System.Drawing.Size(70, 19);
			this.lblIDCardTitle.TabIndex = 29458;
			this.lblIDCardTitle.Text = "身份证号:";
			this.lblIDCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtHomePhone
			// 
			this.m_txtHomePhone.BackColor = System.Drawing.Color.White;
			this.m_txtHomePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtHomePhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomePhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtHomePhone.Location = new System.Drawing.Point(98, 304);
			this.m_txtHomePhone.Name = "m_txtHomePhone";
			this.m_txtHomePhone.Size = new System.Drawing.Size(162, 23);
			this.m_txtHomePhone.TabIndex = 23;
			this.m_txtHomePhone.Text = "";
			// 
			// m_txtHomePC
			// 
			this.m_txtHomePC.BackColor = System.Drawing.Color.White;
			this.m_txtHomePC.BorderColor = System.Drawing.Color.White;
			this.m_txtHomePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomePC.ForeColor = System.Drawing.Color.Black;
			this.m_txtHomePC.Location = new System.Drawing.Point(320, 304);
			this.m_txtHomePC.MaxLength = 6;
			this.m_txtHomePC.Name = "m_txtHomePC";
			this.m_txtHomePC.Size = new System.Drawing.Size(152, 23);
			this.m_txtHomePC.TabIndex = 24;
			this.m_txtHomePC.Text = "";
			// 
			// m_txtIDCard
			// 
			this.m_txtIDCard.BackColor = System.Drawing.Color.White;
			this.m_txtIDCard.BorderColor = System.Drawing.Color.White;
			this.m_txtIDCard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtIDCard.ForeColor = System.Drawing.Color.Black;
			this.m_txtIDCard.Location = new System.Drawing.Point(296, 56);
			this.m_txtIDCard.MaxLength = 18;
			this.m_txtIDCard.Name = "m_txtIDCard";
			this.m_txtIDCard.Size = new System.Drawing.Size(156, 23);
			this.m_txtIDCard.TabIndex = 3;
			this.m_txtIDCard.Text = "";
			// 
			// m_txtLinkManPC
			// 
			this.m_txtLinkManPC.BackColor = System.Drawing.Color.White;
			this.m_txtLinkManPC.BorderColor = System.Drawing.Color.White;
			this.m_txtLinkManPC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinkManPC.ForeColor = System.Drawing.Color.Black;
			this.m_txtLinkManPC.Location = new System.Drawing.Point(628, 232);
			this.m_txtLinkManPC.MaxLength = 10;
			this.m_txtLinkManPC.Name = "m_txtLinkManPC";
			this.m_txtLinkManPC.Size = new System.Drawing.Size(140, 23);
			this.m_txtLinkManPC.TabIndex = 20;
			this.m_txtLinkManPC.Text = "";
			// 
			// m_txtLinkMan
			// 
			this.m_txtLinkMan.BackColor = System.Drawing.Color.White;
			this.m_txtLinkMan.BorderColor = System.Drawing.Color.White;
			this.m_txtLinkMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinkMan.ForeColor = System.Drawing.Color.Black;
			this.m_txtLinkMan.Location = new System.Drawing.Point(98, 196);
			this.m_txtLinkMan.Name = "m_txtLinkMan";
			this.m_txtLinkMan.Size = new System.Drawing.Size(162, 23);
			this.m_txtLinkMan.TabIndex = 15;
			this.m_txtLinkMan.Text = "";
			// 
			// m_cboVip_code
			// 
			this.m_cboVip_code.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboVip_code.BorderColor = System.Drawing.Color.Black;
			this.m_cboVip_code.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboVip_code.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboVip_code.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboVip_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboVip_code.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboVip_code.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboVip_code.ForeColor = System.Drawing.Color.Black;
			this.m_cboVip_code.ListBackColor = System.Drawing.Color.White;
			this.m_cboVip_code.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboVip_code.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboVip_code.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboVip_code.Location = new System.Drawing.Point(296, 24);
			this.m_cboVip_code.m_BlnEnableItemEventMenu = true;
			this.m_cboVip_code.Name = "m_cboVip_code";
			this.m_cboVip_code.SelectedIndex = -1;
			this.m_cboVip_code.SelectedItem = null;
			this.m_cboVip_code.SelectionStart = 0;
			this.m_cboVip_code.Size = new System.Drawing.Size(156, 23);
			this.m_cboVip_code.TabIndex = 2;
			this.m_cboVip_code.TextBackColor = System.Drawing.Color.White;
			this.m_cboVip_code.TextForeColor = System.Drawing.Color.Black;
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.BackColor = System.Drawing.SystemColors.Control;
			this.label42.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label42.ForeColor = System.Drawing.Color.Black;
			this.label42.Location = new System.Drawing.Point(204, 24);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(70, 19);
			this.label42.TabIndex = 29469;
			this.label42.Text = "司 局 级:";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboLinkMan_district
			// 
			this.m_cboLinkMan_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboLinkMan_district.BorderColor = System.Drawing.Color.Black;
			this.m_cboLinkMan_district.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboLinkMan_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinkMan_district.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboLinkMan_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboLinkMan_district.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinkMan_district.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinkMan_district.ForeColor = System.Drawing.Color.Black;
			this.m_cboLinkMan_district.ListBackColor = System.Drawing.Color.White;
			this.m_cboLinkMan_district.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboLinkMan_district.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboLinkMan_district.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboLinkMan_district.Location = new System.Drawing.Point(98, 232);
			this.m_cboLinkMan_district.m_BlnEnableItemEventMenu = true;
			this.m_cboLinkMan_district.Name = "m_cboLinkMan_district";
			this.m_cboLinkMan_district.SelectedIndex = -1;
			this.m_cboLinkMan_district.SelectedItem = null;
			this.m_cboLinkMan_district.SelectionStart = 0;
			this.m_cboLinkMan_district.Size = new System.Drawing.Size(162, 23);
			this.m_cboLinkMan_district.TabIndex = 18;
			this.m_cboLinkMan_district.TextBackColor = System.Drawing.Color.White;
			this.m_cboLinkMan_district.TextForeColor = System.Drawing.Color.Black;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(10, 236);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 19);
			this.label3.TabIndex = 29476;
			this.label3.Text = "省    市:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtLinkMan_street
			// 
			this.m_txtLinkMan_street.BackColor = System.Drawing.Color.White;
			this.m_txtLinkMan_street.BorderColor = System.Drawing.Color.White;
			this.m_txtLinkMan_street.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinkMan_street.ForeColor = System.Drawing.Color.Black;
			this.m_txtLinkMan_street.Location = new System.Drawing.Point(320, 232);
			this.m_txtLinkMan_street.MaxLength = 20;
			this.m_txtLinkMan_street.Name = "m_txtLinkMan_street";
			this.m_txtLinkMan_street.Size = new System.Drawing.Size(232, 23);
			this.m_txtLinkMan_street.TabIndex = 19;
			this.m_txtLinkMan_street.Text = "";
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.BackColor = System.Drawing.SystemColors.Control;
			this.label49.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label49.ForeColor = System.Drawing.Color.Black;
			this.label49.Location = new System.Drawing.Point(276, 236);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(41, 19);
			this.label49.TabIndex = 29482;
			this.label49.Text = "街道:";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.BackColor = System.Drawing.SystemColors.Control;
			this.label51.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label51.ForeColor = System.Drawing.Color.Black;
			this.label51.Location = new System.Drawing.Point(568, 236);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(41, 19);
			this.label51.TabIndex = 29461;
			this.label51.Text = "邮编:";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboHome_district
			// 
			this.m_cboHome_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboHome_district.BorderColor = System.Drawing.Color.Black;
			this.m_cboHome_district.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboHome_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboHome_district.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboHome_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboHome_district.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHome_district.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHome_district.ForeColor = System.Drawing.Color.Black;
			this.m_cboHome_district.ListBackColor = System.Drawing.Color.White;
			this.m_cboHome_district.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboHome_district.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboHome_district.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboHome_district.Location = new System.Drawing.Point(98, 268);
			this.m_cboHome_district.m_BlnEnableItemEventMenu = true;
			this.m_cboHome_district.Name = "m_cboHome_district";
			this.m_cboHome_district.SelectedIndex = -1;
			this.m_cboHome_district.SelectedItem = null;
			this.m_cboHome_district.SelectionStart = 0;
			this.m_cboHome_district.Size = new System.Drawing.Size(162, 23);
			this.m_cboHome_district.TabIndex = 21;
			this.m_cboHome_district.TextBackColor = System.Drawing.Color.White;
			this.m_cboHome_district.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtHome_street
			// 
			this.m_txtHome_street.BackColor = System.Drawing.Color.White;
			this.m_txtHome_street.BorderColor = System.Drawing.Color.White;
			this.m_txtHome_street.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHome_street.ForeColor = System.Drawing.Color.Black;
			this.m_txtHome_street.Location = new System.Drawing.Point(320, 268);
			this.m_txtHome_street.MaxLength = 20;
			this.m_txtHome_street.Name = "m_txtHome_street";
			this.m_txtHome_street.Size = new System.Drawing.Size(444, 23);
			this.m_txtHome_street.TabIndex = 22;
			this.m_txtHome_street.Text = "";
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.BackColor = System.Drawing.SystemColors.Control;
			this.label52.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label52.ForeColor = System.Drawing.Color.Black;
			this.label52.Location = new System.Drawing.Point(276, 272);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(41, 19);
			this.label52.TabIndex = 29481;
			this.label52.Text = "街道:";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.BackColor = System.Drawing.SystemColors.Control;
			this.label54.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label54.ForeColor = System.Drawing.Color.Black;
			this.label54.Location = new System.Drawing.Point(10, 380);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(99, 19);
			this.label54.TabIndex = 29464;
			this.label54.Text = "临时地址电话:";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txttemp_zipcode
			// 
			this.m_txttemp_zipcode.BackColor = System.Drawing.Color.White;
			this.m_txttemp_zipcode.BorderColor = System.Drawing.Color.White;
			this.m_txttemp_zipcode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txttemp_zipcode.ForeColor = System.Drawing.Color.Black;
			this.m_txttemp_zipcode.Location = new System.Drawing.Point(426, 376);
			this.m_txttemp_zipcode.Name = "m_txttemp_zipcode";
			this.m_txttemp_zipcode.Size = new System.Drawing.Size(108, 23);
			this.m_txttemp_zipcode.TabIndex = 28;
			this.m_txttemp_zipcode.Text = "";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.BackColor = System.Drawing.SystemColors.Control;
			this.label55.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label55.ForeColor = System.Drawing.Color.Black;
			this.label55.Location = new System.Drawing.Point(318, 380);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(99, 19);
			this.label55.TabIndex = 29465;
			this.label55.Text = "临时地址旧号:";
			this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboBornPlace
			// 
			this.m_cboBornPlace.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboBornPlace.BorderColor = System.Drawing.Color.Black;
			this.m_cboBornPlace.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboBornPlace.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboBornPlace.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboBornPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboBornPlace.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBornPlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBornPlace.ForeColor = System.Drawing.Color.Black;
			this.m_cboBornPlace.ListBackColor = System.Drawing.Color.White;
			this.m_cboBornPlace.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboBornPlace.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboBornPlace.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboBornPlace.Location = new System.Drawing.Point(628, 88);
			this.m_cboBornPlace.m_BlnEnableItemEventMenu = true;
			this.m_cboBornPlace.Name = "m_cboBornPlace";
			this.m_cboBornPlace.SelectedIndex = -1;
			this.m_cboBornPlace.SelectedItem = null;
			this.m_cboBornPlace.SelectionStart = 0;
			this.m_cboBornPlace.Size = new System.Drawing.Size(140, 23);
			this.m_cboBornPlace.TabIndex = 6;
			this.m_cboBornPlace.TextBackColor = System.Drawing.Color.White;
			this.m_cboBornPlace.TextForeColor = System.Drawing.Color.Black;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(568, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 19);
			this.label2.TabIndex = 29455;
			this.label2.Text = "出生地:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_gpbMust
			// 
			this.m_gpbMust.BackColor = System.Drawing.SystemColors.Control;
			this.m_gpbMust.Controls.Add(this.m_numTimes);
			this.m_gpbMust.Controls.Add(this.label41);
			this.m_gpbMust.Controls.Add(this.m_chkIsOldPatient);
			this.m_gpbMust.Controls.Add(this.m_cboMarried);
			this.m_gpbMust.Controls.Add(this.m_cboSex);
			this.m_gpbMust.Controls.Add(this.m_dtpBirth);
			this.m_gpbMust.Controls.Add(this.lblNameTitle);
			this.m_gpbMust.Controls.Add(this.lblSexTitle);
			this.m_gpbMust.Controls.Add(this.lblInPatientIDTitle);
			this.m_gpbMust.Controls.Add(this.lblMarriedTitle);
			this.m_gpbMust.Controls.Add(this.label1);
			this.m_gpbMust.Controls.Add(this.m_txtInPatientID);
			this.m_gpbMust.Controls.Add(this.m_txtPatientFirstName);
			this.m_gpbMust.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_gpbMust.ForeColor = System.Drawing.Color.Black;
			this.m_gpbMust.Location = new System.Drawing.Point(43, 11);
			this.m_gpbMust.Name = "m_gpbMust";
			this.m_gpbMust.Size = new System.Drawing.Size(793, 108);
			this.m_gpbMust.TabIndex = 29395;
			this.m_gpbMust.TabStop = false;
			this.m_gpbMust.Text = "必填资料";
			// 
			// m_numTimes
			// 
			this.m_numTimes.BackColor = System.Drawing.Color.White;
			this.m_numTimes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_numTimes.ForeColor = System.Drawing.Color.Black;
			this.m_numTimes.Location = new System.Drawing.Point(88, 76);
			this.m_numTimes.Name = "m_numTimes";
			this.m_numTimes.Size = new System.Drawing.Size(36, 23);
			this.m_numTimes.TabIndex = 29410;
			this.m_numTimes.Value = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.BackColor = System.Drawing.SystemColors.Control;
			this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label41.ForeColor = System.Drawing.Color.Black;
			this.label41.Location = new System.Drawing.Point(10, 76);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(56, 19);
			this.label41.TabIndex = 29409;
			this.label41.Text = "次  数:";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_chkIsOldPatient
			// 
			this.m_chkIsOldPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_chkIsOldPatient.Location = new System.Drawing.Point(624, 12);
			this.m_chkIsOldPatient.Name = "m_chkIsOldPatient";
			this.m_chkIsOldPatient.Size = new System.Drawing.Size(112, 24);
			this.m_chkIsOldPatient.TabIndex = 29398;
			this.m_chkIsOldPatient.Text = "旧病人入院";
			// 
			// m_cboMarried
			// 
			this.m_cboMarried.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboMarried.BorderColor = System.Drawing.Color.Black;
			this.m_cboMarried.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboMarried.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboMarried.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboMarried.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboMarried.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMarried.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMarried.ForeColor = System.Drawing.Color.Black;
			this.m_cboMarried.ListBackColor = System.Drawing.Color.White;
			this.m_cboMarried.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboMarried.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboMarried.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboMarried.Location = new System.Drawing.Point(612, 76);
			this.m_cboMarried.m_BlnEnableItemEventMenu = true;
			this.m_cboMarried.Name = "m_cboMarried";
			this.m_cboMarried.SelectedIndex = -1;
			this.m_cboMarried.SelectedItem = null;
			this.m_cboMarried.SelectionStart = -1;
			this.m_cboMarried.Size = new System.Drawing.Size(120, 23);
			this.m_cboMarried.TabIndex = 4;
			this.m_cboMarried.TextBackColor = System.Drawing.Color.White;
			this.m_cboMarried.TextForeColor = System.Drawing.Color.Black;
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
			this.m_cboSex.Location = new System.Drawing.Point(612, 41);
			this.m_cboSex.m_BlnEnableItemEventMenu = true;
			this.m_cboSex.Name = "m_cboSex";
			this.m_cboSex.SelectedIndex = -1;
			this.m_cboSex.SelectedItem = null;
			this.m_cboSex.SelectionStart = -1;
			this.m_cboSex.Size = new System.Drawing.Size(120, 23);
			this.m_cboSex.TabIndex = 2;
			this.m_cboSex.TextBackColor = System.Drawing.Color.White;
			this.m_cboSex.TextForeColor = System.Drawing.Color.Black;
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
			this.m_dtpBirth.Location = new System.Drawing.Point(308, 76);
			this.m_dtpBirth.m_BlnOnlyTime = false;
			this.m_dtpBirth.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpBirth.Name = "m_dtpBirth";
			this.m_dtpBirth.ReadOnly = false;
			this.m_dtpBirth.Size = new System.Drawing.Size(144, 22);
			this.m_dtpBirth.TabIndex = 3;
			this.m_dtpBirth.TextBackColor = System.Drawing.Color.White;
			this.m_dtpBirth.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.AutoSize = true;
			this.lblNameTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNameTitle.ForeColor = System.Drawing.Color.Black;
			this.lblNameTitle.Location = new System.Drawing.Point(224, 44);
			this.lblNameTitle.Name = "lblNameTitle";
			this.lblNameTitle.Size = new System.Drawing.Size(70, 19);
			this.lblNameTitle.TabIndex = 29407;
			this.lblNameTitle.Text = "姓    名:";
			this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.AutoSize = true;
			this.lblSexTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblSexTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSexTitle.ForeColor = System.Drawing.Color.Black;
			this.lblSexTitle.Location = new System.Drawing.Point(528, 45);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(56, 19);
			this.lblSexTitle.TabIndex = 29404;
			this.lblSexTitle.Text = "性  别:";
			this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblInPatientIDTitle
			// 
			this.lblInPatientIDTitle.AutoSize = true;
			this.lblInPatientIDTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblInPatientIDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInPatientIDTitle.ForeColor = System.Drawing.Color.Black;
			this.lblInPatientIDTitle.Location = new System.Drawing.Point(10, 45);
			this.lblInPatientIDTitle.Name = "lblInPatientIDTitle";
			this.lblInPatientIDTitle.Size = new System.Drawing.Size(56, 19);
			this.lblInPatientIDTitle.TabIndex = 29408;
			this.lblInPatientIDTitle.Text = "住院号:";
			this.lblInPatientIDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMarriedTitle
			// 
			this.lblMarriedTitle.AutoSize = true;
			this.lblMarriedTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblMarriedTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMarriedTitle.ForeColor = System.Drawing.Color.Black;
			this.lblMarriedTitle.Location = new System.Drawing.Point(528, 80);
			this.lblMarriedTitle.Name = "lblMarriedTitle";
			this.lblMarriedTitle.Size = new System.Drawing.Size(56, 19);
			this.lblMarriedTitle.TabIndex = 29405;
			this.lblMarriedTitle.Text = "婚  否:";
			this.lblMarriedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(224, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 19);
			this.label1.TabIndex = 29406;
			this.label1.Text = "出生日期:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtInPatientID
			// 
			this.m_txtInPatientID.BackColor = System.Drawing.Color.White;
			this.m_txtInPatientID.BorderColor = System.Drawing.Color.White;
			this.m_txtInPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtInPatientID.ForeColor = System.Drawing.Color.Black;
			this.m_txtInPatientID.Location = new System.Drawing.Point(86, 41);
			this.m_txtInPatientID.Name = "m_txtInPatientID";
			this.m_txtInPatientID.Size = new System.Drawing.Size(110, 23);
			this.m_txtInPatientID.TabIndex = 0;
			this.m_txtInPatientID.Text = "";
			// 
			// m_txtPatientFirstName
			// 
			this.m_txtPatientFirstName.BackColor = System.Drawing.Color.White;
			this.m_txtPatientFirstName.BorderColor = System.Drawing.Color.White;
			this.m_txtPatientFirstName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPatientFirstName.ForeColor = System.Drawing.Color.Black;
			this.m_txtPatientFirstName.Location = new System.Drawing.Point(308, 40);
			this.m_txtPatientFirstName.Name = "m_txtPatientFirstName";
			this.m_txtPatientFirstName.Size = new System.Drawing.Size(144, 23);
			this.m_txtPatientFirstName.TabIndex = 1;
			this.m_txtPatientFirstName.Text = "";
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(306, 587);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(84, 32);
			this.m_cmdOK.TabIndex = 10000001;
			this.m_cmdOK.Text = "确定(&O)";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(474, 587);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(84, 32);
			this.m_cmdCancel.TabIndex = 10000001;
			this.m_cmdCancel.Text = "取消(&C)";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// frmPatientDetailInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(866, 631);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.m_cmdCancel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_gpbMust);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPatientDetailInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "病人详细信息";
			this.Load += new System.EventHandler(this.frmPatientDetailInfo_Load);
			this.groupBox1.ResumeLayout(false);
			this.m_gpbMust.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_numTimes)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public clsPatientBaseInfo m_objGetContentValue()
		{
			if(this.DialogResult==DialogResult.Yes)
				return m_objPatientBaseInfo;
			else return null;
		}

		/// <summary>
		/// 设置界面值
		/// </summary>
		/// <param name="p_objContent"></param>
		private void m_mthSetGUIFromContent(clsPatientBaseInfo p_objContent)
		{
			if(p_objContent==null)
				return;
	
			m_txtInPatientID.Text=m_objPatientBaseInfo.m_strInPatientID;
			m_txtPatientID.Text=m_objPatientBaseInfo.m_strPatientID;			
			m_numTimes.Value = m_objPatientBaseInfo.m_objPeopleInfo.m_IntTimes > 0 ? m_objPatientBaseInfo.m_objPeopleInfo.m_IntTimes : 1;
			m_txtHic_no.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strhic_no == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strhic_no;
			m_txtPatientFirstName.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrFirstName == null ? "":m_objPatientBaseInfo.m_objPeopleInfo.m_StrFirstName;
			m_cboSex.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrSex == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrSex;
			m_dtpBirth.Value = m_objPatientBaseInfo.m_objPeopleInfo.m_DtmBirth;
			m_cboMarried.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrMarried == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrMarried;
			m_cboOccupation.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrOccupation == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrOccupation;
			m_cboVip_code.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strvip_code == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strvip_code;
			m_cboHome_district.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_district == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_district;
			m_cboNation.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrNation == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrNation;
			m_cboNationality.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrNationality == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrNationality;
			m_txtIDCard.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrIDCard == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrIDCard;
			m_txtOfficeName.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_name == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_name;
			m_cboOffice_district.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_district == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_district;
			m_txtOffice_street.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_street == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_street;
			m_txtOfficePhone.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrOfficePhone == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrOfficePhone;
			m_txtOfficePC.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrOfficePC == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrOfficePC;
			m_txtLinkMan.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManFirstName == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManFirstName;
			m_cboLinkManRelation.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrPatientRelation == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrPatientRelation;
			m_cboLinkMan_district.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkMan_district == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkMan_district;
			m_txtLinkMan_street.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkMan_street == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkMan_street;
			m_txtLinkManPhone.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManPhone == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManPhone;
			m_txtLinkManPC.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManPC == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManPC;
			m_cboHome_district.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_district == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_district;
			m_txtHome_street.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_street == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_street;
			m_txtHomePhone.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePhone == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePhone;
			m_txtHomePC.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePC == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePC; 
			m_cboTemp_district.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_district == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_district;
			m_txtTemp_street.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_street == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_street;
			m_txtTempPhone.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_tel == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_tel;
			m_txttemp_zipcode.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_zipcode == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_zipcode; 
			m_cboInsurance.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strinsurance == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strinsurance;
			m_cboAdmiss_status.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Stradmiss_status == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Stradmiss_status;
			m_cboVisit_type.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_Strvisit_type == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_Strvisit_type;
			m_cboChargeCategory.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrChargeCategory == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrChargeCategory;
			m_cboPaymentPercent.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrPaymentPercent == null ? "": m_objPatientBaseInfo.m_objPeopleInfo.m_StrPaymentPercent;
			m_cboNativePlace.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrNativePlace;
			m_cboBornPlace.Text = m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomeplace;
		}

		/// <summary>
		/// 从界面获取表单值
		/// </summary>
		/// <returns></returns>
		private clsPatientBaseInfo m_objGetContentFromGUI()
		{

			if(this.m_txtInPatientID.Text.Length>12)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,住院号长度应小于12");
				m_txtInPatientID.Focus();
				return null;
			}			
			
			if(this.m_txtInPatientID.Text.Trim() =="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写住院号!");
				m_txtInPatientID.Focus();
				return null;
			}			

			if( this.m_txtPatientFirstName.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人姓名!");
				m_txtPatientFirstName.Focus();
				return null;
			}

			if(m_cboMarried.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择婚姻状况。");
				return null;
			}

			if(m_cboSex.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择姓别。");
				return null;
			}

			//界面参数校验
			try
			{
				if(m_txtOfficePC.Text.Trim() !="")
					long.Parse(m_txtOfficePC.Text.Trim());
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

			try
			{
				if(m_txtLinkManPC.Text.Trim() !="")
					long.Parse(m_txtLinkManPC.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("邮编只能输入数字!");
				m_txtLinkManPC.Focus();
				return null;
			}

			try
			{
				if(m_txtHic_no.Text.Trim() !="")
					long.Parse(m_txtHic_no.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("医疗证只能输入数字!");
				m_txtHic_no.Focus();
				return null;
			}

			
			if(m_txtIDCard.Text.Trim().Length!=0 && m_txtIDCard.Text.Trim().Length !=15 && m_txtIDCard.Text.Trim().Length !=18)
			{
				clsPublicFunction.ShowInformationMessageBox("身份证号输入有误!");
				m_txtIDCard.Focus();
				return null;
			}			

			if(m_txtPatientID.Text!=null && m_txtPatientID.Text.Trim().Length>12)
			{
				clsPublicFunction.ShowInformationMessageBox("病人诊疗卡号长度不能大于12.");
				return null;
			}


			m_objPatientBaseInfo=new clsPatientBaseInfo();
			m_objPatientBaseInfo.m_objPeopleInfo=new clsPeopleInfo();
			//从界面获取表单值		
			m_objPatientBaseInfo.m_strInPatientID=m_txtInPatientID.Text.Trim();
			m_objPatientBaseInfo.m_strPatientID=m_txtPatientID.Text.Trim();			
			m_objPatientBaseInfo.m_objPeopleInfo.m_IntTimes = (int)m_numTimes.Value;
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhic_no = m_txtHic_no.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrFirstName=m_txtPatientFirstName.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrSex=m_cboSex.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_DtmBirth=m_dtpBirth.Value;
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrMarried=m_cboMarried.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOccupation=m_cboOccupation.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strvip_code=m_cboVip_code.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrNativePlace=m_cboNativePlace.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomeplace=m_cboBornPlace.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrNation=m_cboNation.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrNationality=m_cboNationality.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrIDCard=m_txtIDCard.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_name=m_txtOfficeName.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_district=m_cboOffice_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_street=m_txtOffice_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOfficePhone=m_txtOfficePhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOfficePC=m_txtOfficePC.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManFirstName=m_txtLinkMan.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrPatientRelation=m_cboLinkManRelation.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkMan_district=m_cboLinkMan_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkMan_street=m_txtLinkMan_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManPhone=m_txtLinkManPhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManPC=m_txtLinkManPC.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_district=m_cboHome_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_street=m_txtHome_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePhone=m_txtHomePhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePC=m_txtHomePC.Text.Trim(); 
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_district=m_cboTemp_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_street=m_txtTemp_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_tel=m_txtTempPhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_zipcode=m_txttemp_zipcode.Text.Trim(); 
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strinsurance=m_cboInsurance.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Stradmiss_status=m_cboAdmiss_status.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strvisit_type=m_cboVisit_type.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrChargeCategory=m_cboChargeCategory.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrPaymentPercent=m_cboPaymentPercent.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_DtmFirstDate = DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			return m_objPatientBaseInfo;
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
//			this.m_dtpFirstDate.Value=DateTime.Now;
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			clsPatientBaseInfo objContent=m_objGetContentFromGUI();
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

		private void frmPatientDetailInfo_Load(object sender, System.EventArgs e)
		{
			m_mthSetQuickKeys();

			m_objHighLight.m_mthAddControlInContainer(this);

			m_txtInPatientID.Focus();
		}
		/// <summary>
		/// 添加常用值
		/// </summary>
		private void m_mthAddValueToComboBox()
		{
			m_cboChargeCategory.AddRangeItems(clsComboBoxItems.m_StrChargeCategoryArr);
			m_cboVip_code.AddRangeItems(clsComboBoxItems.m_StrVip_codeArr);
			m_cboMarried.AddRangeItems(clsComboBoxItems.m_StrMarriedArr);
			m_cboSex.AddRangeItems(clsComboBoxItems.m_StrSexArr);
			m_cboNationality.AddItem("中国");
			m_cboAdmiss_status.AddRangeItems(clsComboBoxItems.m_StrAdmiss_statusArr);
			m_cboVisit_type.AddRangeItems(clsComboBoxItems.m_StrVisit_typeArr);
			m_cboLinkManRelation.AddRangeItems(clsComboBoxItems.m_StrLinkManRelationArr);

			m_cboPaymentPercent.AddRangeItems(clsComboBoxItems.m_StrPaymentPercentArr);
			m_cboOccupation.AddRangeItems(clsComboBoxItems.m_StrOccupationArr);
			m_cboNation.AddRangeItems(clsComboBoxItems.m_StrNationalityArr);
			
			m_cboHome_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboOffice_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboLinkMan_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboBornPlace.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboNativePlace.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboTemp_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboInsurance.AddRangeItems(clsComboBoxItems.m_StrInsuranceArr);
		}
	}
}
