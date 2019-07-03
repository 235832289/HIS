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
	/// Summary description for frmPatientInfoManage.
	/// </summary>
	public class frmPatientInfoManage : iCare.iCareBaseForm.frmBaseForm
	{
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLinkManPhone;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLinkManPC;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private ListViewItem m_lviSelectedPatient;
		private clsPatient m_objSelectedPatient;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		protected System.Windows.Forms.Label label14;
		protected System.Windows.Forms.Label label15;
		protected System.Windows.Forms.Label label16;
		protected System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label13;
		protected System.Windows.Forms.Label label9;
		protected System.Windows.Forms.Label label10;
		protected System.Windows.Forms.Label label11;
		protected System.Windows.Forms.Label label12;
		protected System.Windows.Forms.Label label8;
		protected System.Windows.Forms.Label label7;
		protected System.Windows.Forms.Label label6;
		protected System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		protected System.Windows.Forms.Label label5;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboPaymentPercent;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboLinkManRelation;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboHomePlace;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOccupation;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboNationality;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboNation;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboChargeCategory;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboMarried;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboSex;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpBirth;
		protected System.Windows.Forms.Label lblHomePhoneTitle;
		protected System.Windows.Forms.Label lblHomeAddressTitle;
		protected System.Windows.Forms.Label lblOfficeAddressTitle;
		protected System.Windows.Forms.Label lblHomePCTitle;
		protected System.Windows.Forms.Label lblOfficePCTitle;
		protected System.Windows.Forms.Label lblNameTitle;
		protected System.Windows.Forms.Label lblSexTitle;
		protected System.Windows.Forms.Label lblIDCardTitle;
		protected System.Windows.Forms.Label lblInPatientIDTitle;
		protected System.Windows.Forms.Label lblMarriedTitle;
		protected System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblPaymentPercentTitle;
		private System.Windows.Forms.Label lblChargeCategory;
		private System.Windows.Forms.Label lblNation;
		private System.Windows.Forms.Label lblNationality;
		private System.Windows.Forms.Label lblOccupation;
		private System.Windows.Forms.Label lblHomeplace;
		private System.Windows.Forms.Label lblLinkManAddress;
		private System.Windows.Forms.Label lblPatientRelation;
		private System.Windows.Forms.Label lblLinkMan;
		private System.Windows.Forms.Label lblCardNoTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomePhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHomePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtIDCard;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtInPatientID;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientFirstName;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLinkMan;
		private System.Windows.Forms.Button m_cmdOK;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientID;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown m_numTimes;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cbovip_code;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txthic_no;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboLinkMan_district;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLinkMan_street;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOffice_district;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficePhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOffice_street;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOfficeName;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cbovisit_type;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboadmiss_status;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboinsurance;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txttemp_street;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cbotemp_district;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txttemp_tel;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txttemp_zipcode;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txthome_street;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cbohome_district;
		private ctlHighLightFocus m_objHighLight;

		public frmPatientInfoManage(ListViewItem p_lviItem)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		
			m_lviSelectedPatient = p_lviItem;
			
			#region 添加常用值
//			m_cbovip_code.AddRangeItems(new string[]{"本院 ","外宾","高干","卫干","其他"});
			m_cbovip_code.AddRangeItems(clsComboBoxItems.m_StrVip_codeArr);
			m_cboadmiss_status.AddRangeItems(clsComboBoxItems.m_StrAdmiss_statusArr);
			m_cbovisit_type.AddRangeItems(clsComboBoxItems.m_StrVisit_typeArr);
//			m_cboIsEmployee.AddRangeItems(new string[]{"是","否"});
			m_cboSex.AddRangeItems(clsComboBoxItems.m_StrSexArr);
			m_cboChargeCategory.AddRangeItems(clsComboBoxItems.m_StrChargeCategoryArr);
			m_cboMarried.AddRangeItems(clsComboBoxItems.m_StrMarriedArr);
			m_cboNation.AddItem("中国");
			m_cboLinkManRelation.AddRangeItems(clsComboBoxItems.m_StrLinkManRelationArr);
			m_cboPaymentPercent.AddRangeItems(clsComboBoxItems.m_StrPaymentPercentArr);
			m_cboOccupation.AddRangeItems(clsComboBoxItems.m_StrOccupationArr);
			m_cboNationality.AddRangeItems(clsComboBoxItems.m_StrNationalityArr);
			
			m_cboHomePlace.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboOffice_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboLinkMan_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cbohome_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cbotemp_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboinsurance.AddRangeItems(clsComboBoxItems.m_StrInsuranceArr);
			#endregion

			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
			m_objHighLight.m_mthAddControlInContainer(this);

			new clsBorderTool(Color.White).m_mthChangedControlBorder(m_numTimes);
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPatientInfoManage));
			this.m_txtLinkManPhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtLinkManPC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.m_cbovisit_type = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.m_cboadmiss_status = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.m_cboinsurance = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.m_txttemp_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cbotemp_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.m_txttemp_tel = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txttemp_zipcode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.m_txthome_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cbohome_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboLinkMan_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.m_txtLinkMan_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.m_cboOffice_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.m_txtOfficePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtOffice_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_cbovip_code = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txthic_no = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_numTimes = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.m_cboPaymentPercent = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboLinkManRelation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboHomePlace = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboOccupation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboNationality = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboNation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboChargeCategory = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboMarried = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboSex = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_dtpBirth = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.lblHomePhoneTitle = new System.Windows.Forms.Label();
			this.lblHomeAddressTitle = new System.Windows.Forms.Label();
			this.lblOfficeAddressTitle = new System.Windows.Forms.Label();
			this.lblHomePCTitle = new System.Windows.Forms.Label();
			this.lblOfficePCTitle = new System.Windows.Forms.Label();
			this.lblNameTitle = new System.Windows.Forms.Label();
			this.lblSexTitle = new System.Windows.Forms.Label();
			this.lblIDCardTitle = new System.Windows.Forms.Label();
			this.lblInPatientIDTitle = new System.Windows.Forms.Label();
			this.lblMarriedTitle = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblPaymentPercentTitle = new System.Windows.Forms.Label();
			this.lblChargeCategory = new System.Windows.Forms.Label();
			this.lblNation = new System.Windows.Forms.Label();
			this.lblNationality = new System.Windows.Forms.Label();
			this.lblOccupation = new System.Windows.Forms.Label();
			this.lblHomeplace = new System.Windows.Forms.Label();
			this.lblLinkManAddress = new System.Windows.Forms.Label();
			this.lblPatientRelation = new System.Windows.Forms.Label();
			this.lblLinkMan = new System.Windows.Forms.Label();
			this.lblCardNoTitle = new System.Windows.Forms.Label();
			this.m_txtHomePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtOfficeName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtOfficePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtHomePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtIDCard = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtInPatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtPatientFirstName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtLinkMan = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cmdOK = new System.Windows.Forms.Button();
			this.m_txtPatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.m_numTimes)).BeginInit();
			this.SuspendLayout();
			// 
			// m_txtLinkManPhone
			// 
			this.m_txtLinkManPhone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtLinkManPhone.BorderColor = System.Drawing.Color.White;
			this.m_txtLinkManPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtLinkManPhone.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinkManPhone.ForeColor = System.Drawing.Color.White;
			this.m_txtLinkManPhone.Location = new System.Drawing.Point(772, 260);
			this.m_txtLinkManPhone.MaxLength = 16;
			this.m_txtLinkManPhone.Name = "m_txtLinkManPhone";
			this.m_txtLinkManPhone.Size = new System.Drawing.Size(76, 26);
			this.m_txtLinkManPhone.TabIndex = 2500;
			this.m_txtLinkManPhone.Text = "";
			this.m_txtLinkManPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// m_txtLinkManPC
			// 
			this.m_txtLinkManPC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtLinkManPC.BorderColor = System.Drawing.Color.White;
			this.m_txtLinkManPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtLinkManPC.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinkManPC.ForeColor = System.Drawing.Color.White;
			this.m_txtLinkManPC.Location = new System.Drawing.Point(916, 260);
			this.m_txtLinkManPC.MaxLength = 6;
			this.m_txtLinkManPC.Name = "m_txtLinkManPC";
			this.m_txtLinkManPC.Size = new System.Drawing.Size(72, 26);
			this.m_txtLinkManPC.TabIndex = 2700;
			this.m_txtLinkManPC.Text = "";
			this.m_txtLinkManPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label20.Location = new System.Drawing.Point(304, 12);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(319, 40);
			this.label20.TabIndex = 29419;
			this.label20.Text = "病 人 基 本 资 料";
			// 
			// m_cbovisit_type
			// 
			this.m_cbovisit_type.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbovisit_type.BorderColor = System.Drawing.Color.White;
			this.m_cbovisit_type.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbovisit_type.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cbovisit_type.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cbovisit_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cbovisit_type.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cbovisit_type.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cbovisit_type.ForeColor = System.Drawing.Color.White;
			this.m_cbovisit_type.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbovisit_type.ListForeColor = System.Drawing.Color.White;
			this.m_cbovisit_type.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cbovisit_type.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cbovisit_type.Location = new System.Drawing.Point(480, 396);
			this.m_cbovisit_type.Name = "m_cbovisit_type";
			this.m_cbovisit_type.SelectedIndex = -1;
			this.m_cbovisit_type.SelectedItem = null;
			this.m_cbovisit_type.Size = new System.Drawing.Size(80, 26);
			this.m_cbovisit_type.TabIndex = 29416;
			this.m_cbovisit_type.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbovisit_type.TextForeColor = System.Drawing.Color.White;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label19.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label19.ForeColor = System.Drawing.Color.White;
			this.label19.Location = new System.Drawing.Point(428, 400);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(47, 19);
			this.label19.TabIndex = 29417;
			this.label19.Text = "访问:";
			// 
			// m_cboadmiss_status
			// 
			this.m_cboadmiss_status.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboadmiss_status.BorderColor = System.Drawing.Color.White;
			this.m_cboadmiss_status.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboadmiss_status.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboadmiss_status.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboadmiss_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboadmiss_status.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboadmiss_status.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboadmiss_status.ForeColor = System.Drawing.Color.White;
			this.m_cboadmiss_status.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboadmiss_status.ListForeColor = System.Drawing.Color.White;
			this.m_cboadmiss_status.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboadmiss_status.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboadmiss_status.Location = new System.Drawing.Point(340, 396);
			this.m_cboadmiss_status.Name = "m_cboadmiss_status";
			this.m_cboadmiss_status.SelectedIndex = -1;
			this.m_cboadmiss_status.SelectedItem = null;
			this.m_cboadmiss_status.Size = new System.Drawing.Size(80, 26);
			this.m_cboadmiss_status.TabIndex = 29414;
			this.m_cboadmiss_status.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboadmiss_status.TextForeColor = System.Drawing.Color.White;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label18.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(288, 400);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(47, 19);
			this.label18.TabIndex = 29415;
			this.label18.Text = "状态:";
			// 
			// m_cboinsurance
			// 
			this.m_cboinsurance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboinsurance.BorderColor = System.Drawing.Color.White;
			this.m_cboinsurance.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboinsurance.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboinsurance.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboinsurance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboinsurance.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboinsurance.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboinsurance.ForeColor = System.Drawing.Color.White;
			this.m_cboinsurance.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboinsurance.ListForeColor = System.Drawing.Color.White;
			this.m_cboinsurance.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboinsurance.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboinsurance.Location = new System.Drawing.Point(92, 396);
			this.m_cboinsurance.Name = "m_cboinsurance";
			this.m_cboinsurance.SelectedIndex = -1;
			this.m_cboinsurance.SelectedItem = null;
			this.m_cboinsurance.Size = new System.Drawing.Size(160, 26);
			this.m_cboinsurance.TabIndex = 29413;
			this.m_cboinsurance.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboinsurance.TextForeColor = System.Drawing.Color.White;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label14.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label14.ForeColor = System.Drawing.SystemColors.Window;
			this.label14.Location = new System.Drawing.Point(288, 356);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(47, 19);
			this.label14.TabIndex = 29412;
			this.label14.Text = "街道:";
			// 
			// m_txttemp_street
			// 
			this.m_txttemp_street.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txttemp_street.BorderColor = System.Drawing.Color.White;
			this.m_txttemp_street.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txttemp_street.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txttemp_street.ForeColor = System.Drawing.Color.White;
			this.m_txttemp_street.Location = new System.Drawing.Point(340, 352);
			this.m_txttemp_street.MaxLength = 16;
			this.m_txttemp_street.Name = "m_txttemp_street";
			this.m_txttemp_street.Size = new System.Drawing.Size(356, 26);
			this.m_txttemp_street.TabIndex = 29411;
			this.m_txttemp_street.Text = "";
			// 
			// m_cbotemp_district
			// 
			this.m_cbotemp_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbotemp_district.BorderColor = System.Drawing.Color.White;
			this.m_cbotemp_district.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbotemp_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cbotemp_district.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cbotemp_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cbotemp_district.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cbotemp_district.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cbotemp_district.ForeColor = System.Drawing.Color.White;
			this.m_cbotemp_district.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbotemp_district.ListForeColor = System.Drawing.Color.White;
			this.m_cbotemp_district.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cbotemp_district.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cbotemp_district.Location = new System.Drawing.Point(92, 352);
			this.m_cbotemp_district.Name = "m_cbotemp_district";
			this.m_cbotemp_district.SelectedIndex = -1;
			this.m_cbotemp_district.SelectedItem = null;
			this.m_cbotemp_district.Size = new System.Drawing.Size(160, 26);
			this.m_cbotemp_district.TabIndex = 29410;
			this.m_cbotemp_district.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbotemp_district.TextForeColor = System.Drawing.Color.White;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label15.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label15.ForeColor = System.Drawing.SystemColors.Window;
			this.label15.Location = new System.Drawing.Point(720, 356);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(47, 19);
			this.label15.TabIndex = 29409;
			this.label15.Text = "电话:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label16.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label16.ForeColor = System.Drawing.SystemColors.Window;
			this.label16.Location = new System.Drawing.Point(8, 356);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(80, 19);
			this.label16.TabIndex = 29408;
			this.label16.Text = "临时地址:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label17.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label17.ForeColor = System.Drawing.SystemColors.Window;
			this.label17.Location = new System.Drawing.Point(856, 356);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(55, 19);
			this.label17.TabIndex = 29407;
			this.label17.Text = "旧 号:";
			// 
			// m_txttemp_tel
			// 
			this.m_txttemp_tel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txttemp_tel.BorderColor = System.Drawing.Color.White;
			this.m_txttemp_tel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txttemp_tel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txttemp_tel.ForeColor = System.Drawing.Color.White;
			this.m_txttemp_tel.Location = new System.Drawing.Point(772, 352);
			this.m_txttemp_tel.MaxLength = 16;
			this.m_txttemp_tel.Name = "m_txttemp_tel";
			this.m_txttemp_tel.Size = new System.Drawing.Size(76, 26);
			this.m_txttemp_tel.TabIndex = 29405;
			this.m_txttemp_tel.Text = "";
			this.m_txttemp_tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// m_txttemp_zipcode
			// 
			this.m_txttemp_zipcode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txttemp_zipcode.BorderColor = System.Drawing.Color.White;
			this.m_txttemp_zipcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txttemp_zipcode.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txttemp_zipcode.ForeColor = System.Drawing.Color.White;
			this.m_txttemp_zipcode.Location = new System.Drawing.Point(916, 352);
			this.m_txttemp_zipcode.MaxLength = 6;
			this.m_txttemp_zipcode.Name = "m_txttemp_zipcode";
			this.m_txttemp_zipcode.Size = new System.Drawing.Size(72, 26);
			this.m_txttemp_zipcode.TabIndex = 29406;
			this.m_txttemp_zipcode.Text = "";
			this.m_txttemp_zipcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label13.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.ForeColor = System.Drawing.SystemColors.Window;
			this.label13.Location = new System.Drawing.Point(288, 312);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(47, 19);
			this.label13.TabIndex = 29404;
			this.label13.Text = "街道:";
			// 
			// m_txthome_street
			// 
			this.m_txthome_street.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txthome_street.BorderColor = System.Drawing.Color.White;
			this.m_txthome_street.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txthome_street.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txthome_street.ForeColor = System.Drawing.Color.White;
			this.m_txthome_street.Location = new System.Drawing.Point(340, 308);
			this.m_txthome_street.MaxLength = 16;
			this.m_txthome_street.Name = "m_txthome_street";
			this.m_txthome_street.Size = new System.Drawing.Size(356, 26);
			this.m_txthome_street.TabIndex = 29403;
			this.m_txthome_street.Text = "";
			// 
			// m_cbohome_district
			// 
			this.m_cbohome_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbohome_district.BorderColor = System.Drawing.Color.White;
			this.m_cbohome_district.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbohome_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cbohome_district.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cbohome_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cbohome_district.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cbohome_district.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cbohome_district.ForeColor = System.Drawing.Color.White;
			this.m_cbohome_district.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbohome_district.ListForeColor = System.Drawing.Color.White;
			this.m_cbohome_district.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cbohome_district.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cbohome_district.Location = new System.Drawing.Point(92, 308);
			this.m_cbohome_district.Name = "m_cbohome_district";
			this.m_cbohome_district.SelectedIndex = -1;
			this.m_cbohome_district.SelectedItem = null;
			this.m_cbohome_district.Size = new System.Drawing.Size(160, 26);
			this.m_cbohome_district.TabIndex = 29402;
			this.m_cbohome_district.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbohome_district.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboLinkMan_district
			// 
			this.m_cboLinkMan_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinkMan_district.BorderColor = System.Drawing.Color.White;
			this.m_cboLinkMan_district.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinkMan_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinkMan_district.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboLinkMan_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboLinkMan_district.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinkMan_district.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinkMan_district.ForeColor = System.Drawing.Color.White;
			this.m_cboLinkMan_district.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinkMan_district.ListForeColor = System.Drawing.Color.White;
			this.m_cboLinkMan_district.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboLinkMan_district.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboLinkMan_district.Location = new System.Drawing.Point(340, 264);
			this.m_cboLinkMan_district.Name = "m_cboLinkMan_district";
			this.m_cboLinkMan_district.SelectedIndex = -1;
			this.m_cboLinkMan_district.SelectedItem = null;
			this.m_cboLinkMan_district.Size = new System.Drawing.Size(140, 26);
			this.m_cboLinkMan_district.TabIndex = 29401;
			this.m_cboLinkMan_district.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinkMan_district.TextForeColor = System.Drawing.Color.White;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label9.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.ForeColor = System.Drawing.SystemColors.Window;
			this.label9.Location = new System.Drawing.Point(720, 268);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(47, 19);
			this.label9.TabIndex = 29400;
			this.label9.Text = "电话:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label10.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.ForeColor = System.Drawing.SystemColors.Window;
			this.label10.Location = new System.Drawing.Point(484, 268);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(47, 19);
			this.label10.TabIndex = 29398;
			this.label10.Text = "街道:";
			// 
			// m_txtLinkMan_street
			// 
			this.m_txtLinkMan_street.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtLinkMan_street.BorderColor = System.Drawing.Color.White;
			this.m_txtLinkMan_street.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtLinkMan_street.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinkMan_street.ForeColor = System.Drawing.Color.White;
			this.m_txtLinkMan_street.Location = new System.Drawing.Point(536, 264);
			this.m_txtLinkMan_street.MaxLength = 16;
			this.m_txtLinkMan_street.Name = "m_txtLinkMan_street";
			this.m_txtLinkMan_street.Size = new System.Drawing.Size(160, 26);
			this.m_txtLinkMan_street.TabIndex = 29397;
			this.m_txtLinkMan_street.Text = "";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label11.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.ForeColor = System.Drawing.SystemColors.Window;
			this.label11.Location = new System.Drawing.Point(288, 268);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 19);
			this.label11.TabIndex = 29396;
			this.label11.Text = "省市:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label12.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.ForeColor = System.Drawing.SystemColors.Window;
			this.label12.Location = new System.Drawing.Point(856, 268);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(55, 19);
			this.label12.TabIndex = 29395;
			this.label12.Text = "邮 编:";
			// 
			// m_cboOffice_district
			// 
			this.m_cboOffice_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOffice_district.BorderColor = System.Drawing.Color.White;
			this.m_cboOffice_district.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOffice_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOffice_district.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboOffice_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboOffice_district.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOffice_district.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOffice_district.ForeColor = System.Drawing.Color.White;
			this.m_cboOffice_district.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOffice_district.ListForeColor = System.Drawing.Color.White;
			this.m_cboOffice_district.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboOffice_district.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboOffice_district.Location = new System.Drawing.Point(340, 220);
			this.m_cboOffice_district.Name = "m_cboOffice_district";
			this.m_cboOffice_district.SelectedIndex = -1;
			this.m_cboOffice_district.SelectedItem = null;
			this.m_cboOffice_district.Size = new System.Drawing.Size(140, 26);
			this.m_cboOffice_district.TabIndex = 29393;
			this.m_cboOffice_district.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOffice_district.TextForeColor = System.Drawing.Color.White;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label8.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.ForeColor = System.Drawing.SystemColors.Window;
			this.label8.Location = new System.Drawing.Point(720, 224);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(47, 19);
			this.label8.TabIndex = 29392;
			this.label8.Text = "电话:";
			// 
			// m_txtOfficePhone
			// 
			this.m_txtOfficePhone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOfficePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtOfficePhone.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficePhone.ForeColor = System.Drawing.Color.White;
			this.m_txtOfficePhone.Location = new System.Drawing.Point(772, 220);
			this.m_txtOfficePhone.MaxLength = 16;
			this.m_txtOfficePhone.Name = "m_txtOfficePhone";
			this.m_txtOfficePhone.Size = new System.Drawing.Size(76, 26);
			this.m_txtOfficePhone.TabIndex = 29391;
			this.m_txtOfficePhone.Text = "";
			this.m_txtOfficePhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label7.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.ForeColor = System.Drawing.SystemColors.Window;
			this.label7.Location = new System.Drawing.Point(484, 224);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 19);
			this.label7.TabIndex = 29390;
			this.label7.Text = "街道:";
			// 
			// m_txtOffice_street
			// 
			this.m_txtOffice_street.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOffice_street.BorderColor = System.Drawing.Color.White;
			this.m_txtOffice_street.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtOffice_street.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOffice_street.ForeColor = System.Drawing.Color.White;
			this.m_txtOffice_street.Location = new System.Drawing.Point(536, 220);
			this.m_txtOffice_street.MaxLength = 16;
			this.m_txtOffice_street.Name = "m_txtOffice_street";
			this.m_txtOffice_street.Size = new System.Drawing.Size(160, 26);
			this.m_txtOffice_street.TabIndex = 29389;
			this.m_txtOffice_street.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label6.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.SystemColors.Window;
			this.label6.Location = new System.Drawing.Point(288, 224);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 19);
			this.label6.TabIndex = 29387;
			this.label6.Text = "省市:";
			// 
			// m_cbovip_code
			// 
			this.m_cbovip_code.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbovip_code.BorderColor = System.Drawing.Color.White;
			this.m_cbovip_code.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbovip_code.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cbovip_code.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cbovip_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cbovip_code.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cbovip_code.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cbovip_code.ForeColor = System.Drawing.Color.White;
			this.m_cbovip_code.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbovip_code.ListForeColor = System.Drawing.Color.White;
			this.m_cbovip_code.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cbovip_code.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cbovip_code.Location = new System.Drawing.Point(772, 88);
			this.m_cbovip_code.Name = "m_cbovip_code";
			this.m_cbovip_code.SelectedIndex = -1;
			this.m_cbovip_code.SelectedItem = null;
			this.m_cbovip_code.Size = new System.Drawing.Size(128, 26);
			this.m_cbovip_code.TabIndex = 29384;
			this.m_cbovip_code.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cbovip_code.TextForeColor = System.Drawing.Color.White;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(704, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 19);
			this.label4.TabIndex = 29385;
			this.label4.Text = "司局级:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.SystemColors.Window;
			this.label3.Location = new System.Drawing.Point(540, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 19);
			this.label3.TabIndex = 29382;
			this.label3.Text = "医疗证:";
			// 
			// m_txthic_no
			// 
			this.m_txthic_no.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txthic_no.BorderColor = System.Drawing.Color.White;
			this.m_txthic_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txthic_no.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txthic_no.ForeColor = System.Drawing.Color.White;
			this.m_txthic_no.Location = new System.Drawing.Point(612, 88);
			this.m_txthic_no.MaxLength = 10;
			this.m_txthic_no.Name = "m_txthic_no";
			this.m_txthic_no.Size = new System.Drawing.Size(84, 26);
			this.m_txthic_no.TabIndex = 29381;
			this.m_txthic_no.Text = "";
			this.m_txthic_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// m_numTimes
			// 
			this.m_numTimes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_numTimes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_numTimes.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_numTimes.ForeColor = System.Drawing.Color.White;
			this.m_numTimes.Location = new System.Drawing.Point(248, 92);
			this.m_numTimes.Name = "m_numTimes";
			this.m_numTimes.Size = new System.Drawing.Size(36, 19);
			this.m_numTimes.TabIndex = 29380;
			this.m_numTimes.Value = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label5.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.ForeColor = System.Drawing.SystemColors.Window;
			this.label5.Location = new System.Drawing.Point(196, 92);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 19);
			this.label5.TabIndex = 29379;
			this.label5.Text = "次数:";
			// 
			// m_cboPaymentPercent
			// 
			this.m_cboPaymentPercent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPaymentPercent.BorderColor = System.Drawing.Color.White;
			this.m_cboPaymentPercent.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPaymentPercent.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPaymentPercent.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboPaymentPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboPaymentPercent.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPaymentPercent.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPaymentPercent.ForeColor = System.Drawing.Color.White;
			this.m_cboPaymentPercent.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPaymentPercent.ListForeColor = System.Drawing.Color.White;
			this.m_cboPaymentPercent.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboPaymentPercent.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboPaymentPercent.Location = new System.Drawing.Point(840, 396);
			this.m_cboPaymentPercent.Name = "m_cboPaymentPercent";
			this.m_cboPaymentPercent.SelectedIndex = -1;
			this.m_cboPaymentPercent.SelectedItem = null;
			this.m_cboPaymentPercent.Size = new System.Drawing.Size(148, 26);
			this.m_cboPaymentPercent.TabIndex = 29377;
			this.m_cboPaymentPercent.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboPaymentPercent.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboLinkManRelation
			// 
			this.m_cboLinkManRelation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinkManRelation.BorderColor = System.Drawing.Color.White;
			this.m_cboLinkManRelation.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinkManRelation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLinkManRelation.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboLinkManRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboLinkManRelation.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinkManRelation.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboLinkManRelation.ForeColor = System.Drawing.Color.White;
			this.m_cboLinkManRelation.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinkManRelation.ListForeColor = System.Drawing.Color.White;
			this.m_cboLinkManRelation.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboLinkManRelation.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboLinkManRelation.Location = new System.Drawing.Point(212, 264);
			this.m_cboLinkManRelation.Name = "m_cboLinkManRelation";
			this.m_cboLinkManRelation.SelectedIndex = -1;
			this.m_cboLinkManRelation.SelectedItem = null;
			this.m_cboLinkManRelation.Size = new System.Drawing.Size(72, 26);
			this.m_cboLinkManRelation.TabIndex = 2400;
			this.m_cboLinkManRelation.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboLinkManRelation.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboHomePlace
			// 
			this.m_cboHomePlace.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHomePlace.BorderColor = System.Drawing.Color.White;
			this.m_cboHomePlace.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHomePlace.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboHomePlace.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboHomePlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboHomePlace.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHomePlace.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboHomePlace.ForeColor = System.Drawing.Color.White;
			this.m_cboHomePlace.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHomePlace.ListForeColor = System.Drawing.Color.White;
			this.m_cboHomePlace.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboHomePlace.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboHomePlace.Location = new System.Drawing.Point(92, 176);
			this.m_cboHomePlace.Name = "m_cboHomePlace";
			this.m_cboHomePlace.SelectedIndex = -1;
			this.m_cboHomePlace.SelectedItem = null;
			this.m_cboHomePlace.Size = new System.Drawing.Size(160, 26);
			this.m_cboHomePlace.TabIndex = 1400;
			this.m_cboHomePlace.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboHomePlace.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboOccupation
			// 
			this.m_cboOccupation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOccupation.BorderColor = System.Drawing.Color.White;
			this.m_cboOccupation.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOccupation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOccupation.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboOccupation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboOccupation.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOccupation.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOccupation.ForeColor = System.Drawing.Color.White;
			this.m_cboOccupation.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOccupation.ListForeColor = System.Drawing.Color.White;
			this.m_cboOccupation.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboOccupation.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboOccupation.Location = new System.Drawing.Point(772, 128);
			this.m_cboOccupation.Name = "m_cboOccupation";
			this.m_cboOccupation.SelectedIndex = -1;
			this.m_cboOccupation.SelectedItem = null;
			this.m_cboOccupation.Size = new System.Drawing.Size(128, 26);
			this.m_cboOccupation.TabIndex = 1300;
			this.m_cboOccupation.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboOccupation.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboNationality
			// 
			this.m_cboNationality.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNationality.BorderColor = System.Drawing.Color.White;
			this.m_cboNationality.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNationality.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboNationality.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboNationality.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNationality.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNationality.ForeColor = System.Drawing.Color.White;
			this.m_cboNationality.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNationality.ListForeColor = System.Drawing.Color.White;
			this.m_cboNationality.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboNationality.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboNationality.Location = new System.Drawing.Point(536, 176);
			this.m_cboNationality.Name = "m_cboNationality";
			this.m_cboNationality.SelectedIndex = -1;
			this.m_cboNationality.SelectedItem = null;
			this.m_cboNationality.Size = new System.Drawing.Size(160, 26);
			this.m_cboNationality.TabIndex = 1100;
			this.m_cboNationality.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNationality.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboNation
			// 
			this.m_cboNation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNation.BorderColor = System.Drawing.Color.White;
			this.m_cboNation.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboNation.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboNation.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNation.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboNation.ForeColor = System.Drawing.Color.White;
			this.m_cboNation.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNation.ListForeColor = System.Drawing.Color.White;
			this.m_cboNation.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboNation.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboNation.Location = new System.Drawing.Point(340, 176);
			this.m_cboNation.Name = "m_cboNation";
			this.m_cboNation.SelectedIndex = -1;
			this.m_cboNation.SelectedItem = null;
			this.m_cboNation.Size = new System.Drawing.Size(140, 26);
			this.m_cboNation.TabIndex = 1000;
			this.m_cboNation.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboNation.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboChargeCategory
			// 
			this.m_cboChargeCategory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboChargeCategory.BorderColor = System.Drawing.Color.White;
			this.m_cboChargeCategory.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboChargeCategory.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboChargeCategory.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboChargeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboChargeCategory.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboChargeCategory.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboChargeCategory.ForeColor = System.Drawing.Color.White;
			this.m_cboChargeCategory.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboChargeCategory.ListForeColor = System.Drawing.Color.White;
			this.m_cboChargeCategory.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboChargeCategory.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboChargeCategory.Location = new System.Drawing.Point(632, 396);
			this.m_cboChargeCategory.Name = "m_cboChargeCategory";
			this.m_cboChargeCategory.SelectedIndex = -1;
			this.m_cboChargeCategory.SelectedItem = null;
			this.m_cboChargeCategory.Size = new System.Drawing.Size(140, 26);
			this.m_cboChargeCategory.TabIndex = 300;
			this.m_cboChargeCategory.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboChargeCategory.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboMarried
			// 
			this.m_cboMarried.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMarried.BorderColor = System.Drawing.Color.White;
			this.m_cboMarried.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMarried.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboMarried.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboMarried.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboMarried.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMarried.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboMarried.ForeColor = System.Drawing.Color.White;
			this.m_cboMarried.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMarried.ListForeColor = System.Drawing.Color.White;
			this.m_cboMarried.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboMarried.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboMarried.Location = new System.Drawing.Point(612, 128);
			this.m_cboMarried.Name = "m_cboMarried";
			this.m_cboMarried.SelectedIndex = -1;
			this.m_cboMarried.SelectedItem = null;
			this.m_cboMarried.Size = new System.Drawing.Size(84, 26);
			this.m_cboMarried.TabIndex = 200;
			this.m_cboMarried.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboMarried.TextForeColor = System.Drawing.Color.White;
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
			this.m_cboSex.Location = new System.Drawing.Point(248, 132);
			this.m_cboSex.Name = "m_cboSex";
			this.m_cboSex.SelectedIndex = -1;
			this.m_cboSex.SelectedItem = null;
			this.m_cboSex.Size = new System.Drawing.Size(64, 26);
			this.m_cboSex.TabIndex = 400;
			this.m_cboSex.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboSex.TextForeColor = System.Drawing.Color.White;
			// 
			// m_dtpBirth
			// 
			this.m_dtpBirth.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpBirth.BorderColor = System.Drawing.Color.White;
			this.m_dtpBirth.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpBirth.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_dtpBirth.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpBirth.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpBirth.flatFont = new System.Drawing.Font("SimSun", 12F);
			this.m_dtpBirth.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpBirth.ForeColor = System.Drawing.SystemColors.Window;
			this.m_dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpBirth.Location = new System.Drawing.Point(404, 132);
			this.m_dtpBirth.m_BlnOnlyTime = false;
			this.m_dtpBirth.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpBirth.Name = "m_dtpBirth";
			this.m_dtpBirth.ReadOnly = false;
			this.m_dtpBirth.Size = new System.Drawing.Size(140, 22);
			this.m_dtpBirth.TabIndex = 200;
			this.m_dtpBirth.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_dtpBirth.TextForeColor = System.Drawing.Color.White;
			// 
			// lblHomePhoneTitle
			// 
			this.lblHomePhoneTitle.AutoSize = true;
			this.lblHomePhoneTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblHomePhoneTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePhoneTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblHomePhoneTitle.Location = new System.Drawing.Point(720, 312);
			this.lblHomePhoneTitle.Name = "lblHomePhoneTitle";
			this.lblHomePhoneTitle.Size = new System.Drawing.Size(47, 19);
			this.lblHomePhoneTitle.TabIndex = 29372;
			this.lblHomePhoneTitle.Text = "电话:";
			// 
			// lblHomeAddressTitle
			// 
			this.lblHomeAddressTitle.AutoSize = true;
			this.lblHomeAddressTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblHomeAddressTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomeAddressTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblHomeAddressTitle.Location = new System.Drawing.Point(8, 312);
			this.lblHomeAddressTitle.Name = "lblHomeAddressTitle";
			this.lblHomeAddressTitle.Size = new System.Drawing.Size(80, 19);
			this.lblHomeAddressTitle.TabIndex = 29371;
			this.lblHomeAddressTitle.Text = "家庭地址:";
			// 
			// lblOfficeAddressTitle
			// 
			this.lblOfficeAddressTitle.AutoSize = true;
			this.lblOfficeAddressTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblOfficeAddressTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficeAddressTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblOfficeAddressTitle.Location = new System.Drawing.Point(8, 224);
			this.lblOfficeAddressTitle.Name = "lblOfficeAddressTitle";
			this.lblOfficeAddressTitle.Size = new System.Drawing.Size(80, 19);
			this.lblOfficeAddressTitle.TabIndex = 29370;
			this.lblOfficeAddressTitle.Text = "工作单位:";
			// 
			// lblHomePCTitle
			// 
			this.lblHomePCTitle.AutoSize = true;
			this.lblHomePCTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblHomePCTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePCTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblHomePCTitle.Location = new System.Drawing.Point(856, 312);
			this.lblHomePCTitle.Name = "lblHomePCTitle";
			this.lblHomePCTitle.Size = new System.Drawing.Size(55, 19);
			this.lblHomePCTitle.TabIndex = 29365;
			this.lblHomePCTitle.Text = "邮 编:";
			// 
			// lblOfficePCTitle
			// 
			this.lblOfficePCTitle.AutoSize = true;
			this.lblOfficePCTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblOfficePCTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePCTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblOfficePCTitle.Location = new System.Drawing.Point(856, 224);
			this.lblOfficePCTitle.Name = "lblOfficePCTitle";
			this.lblOfficePCTitle.Size = new System.Drawing.Size(55, 19);
			this.lblOfficePCTitle.TabIndex = 29366;
			this.lblOfficePCTitle.Text = "邮 编:";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.AutoSize = true;
			this.lblNameTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblNameTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNameTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblNameTitle.Location = new System.Drawing.Point(32, 136);
			this.lblNameTitle.Name = "lblNameTitle";
			this.lblNameTitle.Size = new System.Drawing.Size(55, 19);
			this.lblNameTitle.TabIndex = 29363;
			this.lblNameTitle.Text = "姓 名:";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.AutoSize = true;
			this.lblSexTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblSexTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSexTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblSexTitle.Location = new System.Drawing.Point(196, 136);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(47, 19);
			this.lblSexTitle.TabIndex = 29359;
			this.lblSexTitle.Text = "性别:";
			// 
			// lblIDCardTitle
			// 
			this.lblIDCardTitle.AutoSize = true;
			this.lblIDCardTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblIDCardTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblIDCardTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblIDCardTitle.Location = new System.Drawing.Point(704, 176);
			this.lblIDCardTitle.Name = "lblIDCardTitle";
			this.lblIDCardTitle.Size = new System.Drawing.Size(63, 19);
			this.lblIDCardTitle.TabIndex = 29362;
			this.lblIDCardTitle.Text = "身份证:";
			// 
			// lblInPatientIDTitle
			// 
			this.lblInPatientIDTitle.AutoSize = true;
			this.lblInPatientIDTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblInPatientIDTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInPatientIDTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblInPatientIDTitle.Location = new System.Drawing.Point(24, 92);
			this.lblInPatientIDTitle.Name = "lblInPatientIDTitle";
			this.lblInPatientIDTitle.Size = new System.Drawing.Size(63, 19);
			this.lblInPatientIDTitle.TabIndex = 29364;
			this.lblInPatientIDTitle.Text = "住院号:";
			// 
			// lblMarriedTitle
			// 
			this.lblMarriedTitle.AutoSize = true;
			this.lblMarriedTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblMarriedTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMarriedTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblMarriedTitle.Location = new System.Drawing.Point(556, 132);
			this.lblMarriedTitle.Name = "lblMarriedTitle";
			this.lblMarriedTitle.Size = new System.Drawing.Size(47, 19);
			this.lblMarriedTitle.TabIndex = 29360;
			this.lblMarriedTitle.Text = "婚否:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.SystemColors.Window;
			this.label1.Location = new System.Drawing.Point(320, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 19);
			this.label1.TabIndex = 29361;
			this.label1.Text = "出生日期:";
			// 
			// lblPaymentPercentTitle
			// 
			this.lblPaymentPercentTitle.AutoSize = true;
			this.lblPaymentPercentTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblPaymentPercentTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPaymentPercentTitle.ForeColor = System.Drawing.Color.White;
			this.lblPaymentPercentTitle.Location = new System.Drawing.Point(780, 400);
			this.lblPaymentPercentTitle.Name = "lblPaymentPercentTitle";
			this.lblPaymentPercentTitle.Size = new System.Drawing.Size(55, 19);
			this.lblPaymentPercentTitle.TabIndex = 29358;
			this.lblPaymentPercentTitle.Text = "比 例:";
			// 
			// lblChargeCategory
			// 
			this.lblChargeCategory.AutoSize = true;
			this.lblChargeCategory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblChargeCategory.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblChargeCategory.ForeColor = System.Drawing.Color.White;
			this.lblChargeCategory.Location = new System.Drawing.Point(572, 400);
			this.lblChargeCategory.Name = "lblChargeCategory";
			this.lblChargeCategory.Size = new System.Drawing.Size(55, 19);
			this.lblChargeCategory.TabIndex = 29356;
			this.lblChargeCategory.Text = "身 份:";
			// 
			// lblNation
			// 
			this.lblNation.AutoSize = true;
			this.lblNation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblNation.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNation.ForeColor = System.Drawing.SystemColors.Window;
			this.lblNation.Location = new System.Drawing.Point(288, 180);
			this.lblNation.Name = "lblNation";
			this.lblNation.Size = new System.Drawing.Size(47, 19);
			this.lblNation.TabIndex = 29343;
			this.lblNation.Text = "民族:";
			// 
			// lblNationality
			// 
			this.lblNationality.AutoSize = true;
			this.lblNationality.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblNationality.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNationality.ForeColor = System.Drawing.SystemColors.Window;
			this.lblNationality.Location = new System.Drawing.Point(484, 180);
			this.lblNationality.Name = "lblNationality";
			this.lblNationality.Size = new System.Drawing.Size(47, 19);
			this.lblNationality.TabIndex = 29342;
			this.lblNationality.Text = "国籍:";
			// 
			// lblOccupation
			// 
			this.lblOccupation.AutoSize = true;
			this.lblOccupation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblOccupation.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOccupation.ForeColor = System.Drawing.SystemColors.Window;
			this.lblOccupation.Location = new System.Drawing.Point(720, 132);
			this.lblOccupation.Name = "lblOccupation";
			this.lblOccupation.Size = new System.Drawing.Size(47, 19);
			this.lblOccupation.TabIndex = 29344;
			this.lblOccupation.Text = "职业:";
			// 
			// lblHomeplace
			// 
			this.lblHomeplace.AutoSize = true;
			this.lblHomeplace.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblHomeplace.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomeplace.ForeColor = System.Drawing.SystemColors.Window;
			this.lblHomeplace.Location = new System.Drawing.Point(24, 180);
			this.lblHomeplace.Name = "lblHomeplace";
			this.lblHomeplace.Size = new System.Drawing.Size(63, 19);
			this.lblHomeplace.TabIndex = 29353;
			this.lblHomeplace.Text = "出生地:";
			// 
			// lblLinkManAddress
			// 
			this.lblLinkManAddress.AutoSize = true;
			this.lblLinkManAddress.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblLinkManAddress.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLinkManAddress.ForeColor = System.Drawing.SystemColors.Window;
			this.lblLinkManAddress.Location = new System.Drawing.Point(8, 400);
			this.lblLinkManAddress.Name = "lblLinkManAddress";
			this.lblLinkManAddress.Size = new System.Drawing.Size(80, 19);
			this.lblLinkManAddress.TabIndex = 29346;
			this.lblLinkManAddress.Text = "保险公司:";
			// 
			// lblPatientRelation
			// 
			this.lblPatientRelation.AutoSize = true;
			this.lblPatientRelation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblPatientRelation.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPatientRelation.ForeColor = System.Drawing.SystemColors.Window;
			this.lblPatientRelation.Location = new System.Drawing.Point(164, 268);
			this.lblPatientRelation.Name = "lblPatientRelation";
			this.lblPatientRelation.Size = new System.Drawing.Size(47, 19);
			this.lblPatientRelation.TabIndex = 29354;
			this.lblPatientRelation.Text = "关系:";
			// 
			// lblLinkMan
			// 
			this.lblLinkMan.AutoSize = true;
			this.lblLinkMan.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblLinkMan.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLinkMan.ForeColor = System.Drawing.SystemColors.Window;
			this.lblLinkMan.Location = new System.Drawing.Point(24, 268);
			this.lblLinkMan.Name = "lblLinkMan";
			this.lblLinkMan.Size = new System.Drawing.Size(63, 19);
			this.lblLinkMan.TabIndex = 29345;
			this.lblLinkMan.Text = "联系人:";
			// 
			// lblCardNoTitle
			// 
			this.lblCardNoTitle.AutoSize = true;
			this.lblCardNoTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblCardNoTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCardNoTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblCardNoTitle.Location = new System.Drawing.Point(336, 92);
			this.lblCardNoTitle.Name = "lblCardNoTitle";
			this.lblCardNoTitle.Size = new System.Drawing.Size(63, 19);
			this.lblCardNoTitle.TabIndex = 29341;
			this.lblCardNoTitle.Text = "门诊号:";
			// 
			// m_txtHomePhone
			// 
			this.m_txtHomePhone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtHomePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtHomePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtHomePhone.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomePhone.ForeColor = System.Drawing.Color.White;
			this.m_txtHomePhone.Location = new System.Drawing.Point(772, 308);
			this.m_txtHomePhone.MaxLength = 16;
			this.m_txtHomePhone.Name = "m_txtHomePhone";
			this.m_txtHomePhone.Size = new System.Drawing.Size(76, 26);
			this.m_txtHomePhone.TabIndex = 1600;
			this.m_txtHomePhone.Text = "";
			this.m_txtHomePhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// m_txtOfficeName
			// 
			this.m_txtOfficeName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOfficeName.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtOfficeName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficeName.ForeColor = System.Drawing.Color.White;
			this.m_txtOfficeName.Location = new System.Drawing.Point(92, 220);
			this.m_txtOfficeName.MaxLength = 16;
			this.m_txtOfficeName.Name = "m_txtOfficeName";
			this.m_txtOfficeName.Size = new System.Drawing.Size(160, 26);
			this.m_txtOfficeName.TabIndex = 1800;
			this.m_txtOfficeName.Text = "";
			// 
			// m_txtOfficePC
			// 
			this.m_txtOfficePC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOfficePC.BorderColor = System.Drawing.Color.White;
			this.m_txtOfficePC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtOfficePC.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOfficePC.ForeColor = System.Drawing.Color.White;
			this.m_txtOfficePC.Location = new System.Drawing.Point(916, 220);
			this.m_txtOfficePC.MaxLength = 6;
			this.m_txtOfficePC.Name = "m_txtOfficePC";
			this.m_txtOfficePC.Size = new System.Drawing.Size(72, 26);
			this.m_txtOfficePC.TabIndex = 1900;
			this.m_txtOfficePC.Text = "";
			this.m_txtOfficePC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// m_txtHomePC
			// 
			this.m_txtHomePC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtHomePC.BorderColor = System.Drawing.Color.White;
			this.m_txtHomePC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtHomePC.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtHomePC.ForeColor = System.Drawing.Color.White;
			this.m_txtHomePC.Location = new System.Drawing.Point(916, 308);
			this.m_txtHomePC.MaxLength = 6;
			this.m_txtHomePC.Name = "m_txtHomePC";
			this.m_txtHomePC.Size = new System.Drawing.Size(72, 26);
			this.m_txtHomePC.TabIndex = 2100;
			this.m_txtHomePC.Text = "";
			this.m_txtHomePC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// m_txtIDCard
			// 
			this.m_txtIDCard.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtIDCard.BorderColor = System.Drawing.Color.White;
			this.m_txtIDCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtIDCard.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtIDCard.ForeColor = System.Drawing.Color.White;
			this.m_txtIDCard.Location = new System.Drawing.Point(772, 172);
			this.m_txtIDCard.MaxLength = 18;
			this.m_txtIDCard.Name = "m_txtIDCard";
			this.m_txtIDCard.Size = new System.Drawing.Size(128, 26);
			this.m_txtIDCard.TabIndex = 900;
			this.m_txtIDCard.Text = "";
			this.m_txtIDCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtOnlyNum_KeyPress);
			// 
			// m_txtInPatientID
			// 
			this.m_txtInPatientID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtInPatientID.BorderColor = System.Drawing.Color.White;
			this.m_txtInPatientID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtInPatientID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtInPatientID.ForeColor = System.Drawing.Color.White;
			this.m_txtInPatientID.Location = new System.Drawing.Point(92, 88);
			this.m_txtInPatientID.MaxLength = 12;
			this.m_txtInPatientID.Name = "m_txtInPatientID";
			this.m_txtInPatientID.Size = new System.Drawing.Size(84, 26);
			this.m_txtInPatientID.TabIndex = 1;
			this.m_txtInPatientID.Text = "";
			// 
			// m_txtPatientFirstName
			// 
			this.m_txtPatientFirstName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPatientFirstName.BorderColor = System.Drawing.Color.White;
			this.m_txtPatientFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtPatientFirstName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPatientFirstName.ForeColor = System.Drawing.Color.White;
			this.m_txtPatientFirstName.Location = new System.Drawing.Point(92, 132);
			this.m_txtPatientFirstName.MaxLength = 32;
			this.m_txtPatientFirstName.Name = "m_txtPatientFirstName";
			this.m_txtPatientFirstName.Size = new System.Drawing.Size(84, 26);
			this.m_txtPatientFirstName.TabIndex = 100;
			this.m_txtPatientFirstName.Text = "";
			// 
			// m_txtLinkMan
			// 
			this.m_txtLinkMan.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtLinkMan.BorderColor = System.Drawing.Color.White;
			this.m_txtLinkMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtLinkMan.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLinkMan.ForeColor = System.Drawing.Color.White;
			this.m_txtLinkMan.Location = new System.Drawing.Point(92, 264);
			this.m_txtLinkMan.MaxLength = 16;
			this.m_txtLinkMan.Name = "m_txtLinkMan";
			this.m_txtLinkMan.Size = new System.Drawing.Size(64, 26);
			this.m_txtLinkMan.TabIndex = 2300;
			this.m_txtLinkMan.Text = "";
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOK.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdOK.ForeColor = System.Drawing.SystemColors.Window;
			this.m_cmdOK.Location = new System.Drawing.Point(900, 444);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Size = new System.Drawing.Size(86, 32);
			this.m_cmdOK.TabIndex = 2800;
			this.m_cmdOK.Text = "修改(&M)";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_txtPatientID
			// 
			this.m_txtPatientID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPatientID.BorderColor = System.Drawing.Color.White;
			this.m_txtPatientID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtPatientID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPatientID.ForeColor = System.Drawing.Color.White;
			this.m_txtPatientID.Location = new System.Drawing.Point(404, 88);
			this.m_txtPatientID.MaxLength = 12;
			this.m_txtPatientID.Name = "m_txtPatientID";
			this.m_txtPatientID.Size = new System.Drawing.Size(84, 26);
			this.m_txtPatientID.TabIndex = 800;
			this.m_txtPatientID.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(-8, 68);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1024, 4);
			this.groupBox2.TabIndex = 29420;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// frmPatientInfoManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(998, 487);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.label20,
																		  this.m_cbovisit_type,
																		  this.label19,
																		  this.m_cboadmiss_status,
																		  this.label18,
																		  this.m_cboinsurance,
																		  this.label14,
																		  this.m_txttemp_street,
																		  this.m_cbotemp_district,
																		  this.label15,
																		  this.label16,
																		  this.label17,
																		  this.m_txttemp_tel,
																		  this.m_txttemp_zipcode,
																		  this.label13,
																		  this.m_txthome_street,
																		  this.m_cbohome_district,
																		  this.m_cboLinkMan_district,
																		  this.label9,
																		  this.label10,
																		  this.m_txtLinkMan_street,
																		  this.label11,
																		  this.label12,
																		  this.m_cboOffice_district,
																		  this.label8,
																		  this.m_txtOfficePhone,
																		  this.label7,
																		  this.m_txtOffice_street,
																		  this.label6,
																		  this.m_cbovip_code,
																		  this.label4,
																		  this.label3,
																		  this.m_txthic_no,
																		  this.m_numTimes,
																		  this.label5,
																		  this.m_cboPaymentPercent,
																		  this.m_cboLinkManRelation,
																		  this.m_cboHomePlace,
																		  this.m_cboOccupation,
																		  this.m_cboNationality,
																		  this.m_cboNation,
																		  this.m_cboChargeCategory,
																		  this.m_cboMarried,
																		  this.m_cboSex,
																		  this.m_dtpBirth,
																		  this.lblHomePhoneTitle,
																		  this.lblHomeAddressTitle,
																		  this.lblOfficeAddressTitle,
																		  this.lblHomePCTitle,
																		  this.lblOfficePCTitle,
																		  this.lblNameTitle,
																		  this.lblSexTitle,
																		  this.lblIDCardTitle,
																		  this.lblInPatientIDTitle,
																		  this.lblMarriedTitle,
																		  this.label1,
																		  this.lblPaymentPercentTitle,
																		  this.lblChargeCategory,
																		  this.lblNation,
																		  this.lblNationality,
																		  this.lblOccupation,
																		  this.lblHomeplace,
																		  this.lblLinkManAddress,
																		  this.lblPatientRelation,
																		  this.lblLinkMan,
																		  this.lblCardNoTitle,
																		  this.m_txtHomePhone,
																		  this.m_txtOfficeName,
																		  this.m_txtOfficePC,
																		  this.m_txtHomePC,
																		  this.m_txtIDCard,
																		  this.m_txtInPatientID,
																		  this.m_txtPatientFirstName,
																		  this.m_txtLinkMan,
																		  this.m_cmdOK,
																		  this.m_txtPatientID,
																		  this.m_txtLinkManPhone,
																		  this.m_txtLinkManPC});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.SystemColors.Window;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPatientInfoManage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "病人基本资料维护";
			this.Load += new System.EventHandler(this.frmPatientInfoManage_Load);
			((System.ComponentModel.ISupportInitialize)(this.m_numTimes)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmPatientInfoManage_Load(object sender, System.EventArgs e)
		{
			m_txtInPatientID.Focus();
		}

		/// <summary>
		/// 设置病人的基本住院信息
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		public void m_mthSetPatientBaseInfo(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient==null)
				return;		

			m_objSelectedPatient = p_objSelectedPatient;
	
			m_txtInPatientID.Text= p_objSelectedPatient.m_StrInPatientID;
			m_txtPatientID.Text= p_objSelectedPatient.m_Str_OutPatientID;

			m_numTimes.Value = p_objSelectedPatient.m_ObjPeopleInfo.m_IntTimes;
			m_txthic_no.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_Strhic_no;
			m_cbovip_code.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_Strvip_code;
			m_txtPatientFirstName.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrFirstName;
			m_txtHomePC.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePC;
			m_txtHomePhone.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePhone;
			m_txtIDCard.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrIDCard;
			m_txtLinkMan.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkManFirstName;
			m_txtLinkManPC.Text=  p_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkManPC;
			m_txtLinkManPhone.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkManPhone;
			m_txtOfficePhone.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrOfficePhone;		
			m_txtOfficePC.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrOfficePC;
			m_cboPaymentPercent.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrPaymentPercent;
			m_cboChargeCategory.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrChargeCategory;
			m_cboHomePlace.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeplace;
			m_cboOccupation.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;			
			m_cboMarried.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrMarried;
			m_cboNation.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrNationality;
			m_cboNationality.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrNation;;			
			m_cboLinkManRelation.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrPatientRelation;
			m_cboSex.Text= p_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;
			m_dtpBirth.Value= p_objSelectedPatient.m_ObjPeopleInfo.m_DtmBirth;
			m_txtOfficeName.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_name;
			m_cboOffice_district.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_district;
			m_txtOffice_street.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_street;
			m_cboLinkMan_district.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkMan_district;
			m_txtLinkMan_street.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkMan_street;
			m_cbohome_district.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Strhome_district;
			m_txthome_street.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Strhome_street;
			m_cbotemp_district.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Strtemp_district;
			m_txttemp_street.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Strtemp_street;
			m_txttemp_tel.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Strtemp_tel;
			m_txttemp_zipcode.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Strtemp_zipcode;
			m_cboinsurance.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Strinsurance;
			m_cboadmiss_status.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Stradmiss_status;
			m_cbovisit_type.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_Strvisit_type;

			m_mthSetControlReadOnly();
			
//			m_mthSetFlag();

			//记录设置窗体当前状态
			MDIParent.s_ObjSaveCue.m_mthAddFormStatus(this);
		}

		/// <summary>
		/// 设置修改标识，现在Trigger中完成。
		/// </summary>
		private void m_mthSetFlag()
		{
			clsPatientBaseInfo_ModifyFlag objFlag = new clsPatientBaseInfo_ModifyFlag();

			objFlag.m_strInPatientID = m_txtInPatientID.Text.Trim();

			foreach(Control ctlSub in this.Controls)
			{
//				Type type = objFlag.GetType();
//				type.GetField(ctlSub.Tag.ToString()).SetValue(objFlag,true);

				switch(ctlSub.Name)
				{
					case "m_txtInPatientID" :
						if(m_txtInPatientID.Text.Trim()!="") objFlag.m_intPatientID = 1;
						break;
//					case "m_txtEMail" :
//						if(m_txtEMail.Text.Trim()!="") objFlag.m_intEMail = 1;
//						break;
					case "m_txtPatientFirstName" :
						if(m_txtPatientFirstName.Text.Trim()!="") objFlag.m_intFirstName = 1;
						break;
//					case "m_txtHomeAddress" :
//						if(m_txtHomeAddress.Text.Trim()!="") objFlag.m_intHomeAddress = 1;
//						break;
					case "m_txtHomePC" :
						if(m_txtHomePC.Text.Trim()!="") objFlag.m_intHomePC = 1;
						break;
					case "m_txtHomePhone" :
						if(m_txtHomePhone.Text.Trim()!="") objFlag.m_intHomePhone = 1;
						break;
					case "m_txtIDCard" :
						if(m_txtIDCard.Text.Trim()!="") objFlag.m_intIDCard = 1;
						break;
//					case "m_txtLinkManAddress" :
//						if(m_txtLinkManAddress.Text.Trim()!="") objFlag.m_intLinkManAddress = 1;
//						break;
					case "m_txtLinkMan" :
						if(m_txtLinkMan.Text.Trim()!="") objFlag.m_intLinkManFirstName = 1;
						break;
					case "m_txtLinkManPC" :
						if(m_txtLinkManPC.Text.Trim()!="") objFlag.m_intLinkManPC = 1;
						break;
					case "m_txtLinkManPhone" :
						if(m_txtLinkManPhone.Text.Trim()!="") objFlag.m_intLinkManPhone = 1;
						break;
//					case "m_txtMobile" :
//						if(m_txtMobile.Text.Trim()!="") objFlag.m_intMobile = 1;
//						break;
					case "m_txtOfficeName" :
						if(m_txtOfficeName.Text.Trim()!="") objFlag.m_intOfficeAddress = 1;
						break;
					case "m_txtOfficePC" :
						if(m_txtOfficePC.Text.Trim()!="") objFlag.m_intOfficePC = 1;
						break;
//					case "m_txtOfficePhone" :
//						if(m_txtOfficePhone.Text.Trim()!="") objFlag.m_intOfficePhone = 1;
//						break;
					case "m_cboPaymentPercent" :
						if(m_cboPaymentPercent.Text.Trim()!="") objFlag.m_intPaymentPercent = 1;
						break;
					case "m_cboChargeCategory" : 
						if(m_cboChargeCategory.Text.Trim()!="") objFlag.m_intChargeCategory = 1;
						break;
//					case "m_cboIsEmployee" : 
//						if(m_cboIsEmployee.Text.Trim()!="") objFlag.m_intIsEmployee = 1;
//						break;
					case "m_cboHomePlace" : 
						if(m_cboHomePlace.Text.Trim()!="") objFlag.m_intHomeplace = 1;
						break;
					case "m_cboOccupation" : 
						if(m_cboOccupation.Text.Trim()!="") objFlag.m_intOccupation = 1;
						break;
					case "m_cboMarried" : 
						if(m_cboMarried.Text.Trim()!="") objFlag.m_intMarried = 1;
						break;
					case "m_cboNation" : 
						if(m_cboNation.Text.Trim()!="") objFlag.m_intNation = 1;
						break;
					case "m_cboNationality" : 
						if(m_cboNationality.Text.Trim()!="") objFlag.m_intNationality = 1;
						break;
//					case "m_cboNativePlace" : 
//						if(m_cboNativePlace.Text.Trim()!="") objFlag.m_intNativePlace = 1;
//						break;
					case "m_cboLinkManRelation" : 
						if(m_cboLinkManRelation.Text.Trim()!="") objFlag.m_intPatientRelation = 1;
						break;
					case "m_cboSex" : 
						if(m_cboSex.Text.Trim()!="") objFlag.m_intSex = 1;
						break;
					case "m_dtpBirth" : 
						if(!m_dtpBirth.Enabled) objFlag.m_intBirth = 1;
						break;
//					case "m_dtpFirstDate" : 
//						if(!m_dtpFirstDate.Enabled) objFlag.m_intFirstDate = 1;
//						break;
				}
			}

			long lngRes = new clsDepartmentHandlerDomain().m_lngAddPatientBaseInfo_Flag(objFlag);
		}


		/// <summary>
		/// 将原本有信息的控件设置为只读
		/// </summary>
		private void m_mthSetControlReadOnly()
		{
			foreach(Control ctlSub in this.Controls)
			{
				switch(ctlSub.GetType().Name)
				{
					case "ctlBorderTextBox" :
						ctlBorderTextBox objCtl = (ctlBorderTextBox)ctlSub;
						if(objCtl.Text.Trim()!="") objCtl.ReadOnly = true;
						break;
					case "ctlComboBox" : 
						ctlComboBox objCtl1 = (ctlComboBox)ctlSub;
						if(objCtl1.Text.Trim()!="") objCtl1.Enabled = false;
						break;
					case "ctlTimePicker" : 
						ctlTimePicker objCtl2= (ctlTimePicker)ctlSub;
						if(objCtl2.Value.ToString("yyyy-M-d") != "1900-1-1") objCtl2.Enabled = false;
						break;
					case "NumericUpDown" : 
						NumericUpDown objCtl3= (NumericUpDown)ctlSub;
						if((int)objCtl3.Value != 0) objCtl3.Enabled = false;
						break;
				}
			}

		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			clsPatientBaseInfo objConent = m_objGetContentFromGUI();

			if(objConent == null || objConent.m_strInPatientID==null || objConent.m_strInPatientID=="") return;
			if(!clsPublicFunction.s_blnAskForModify()) return;
				
			long lngRes = new clsDepartmentHandlerDomain().m_lngModifyPatientBaseInfo2(objConent);
			if(lngRes>0) 
			{
				m_objSelectedPatient.m_ObjPeopleInfo = objConent.m_objPeopleInfo;
				m_lviSelectedPatient.Tag = m_objSelectedPatient;
				clsPublicFunction.ShowInformationMessageBox("修改成功！");
			}

			//记录设置窗体当前状态
			MDIParent.s_ObjSaveCue.m_mthAddFormStatus(this);

			this.Close();
		}

		public void m_mthSave()
		{
			m_cmdOK_Click(null,null);
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

			//界面参数校验
			try
			{
				if(m_txthic_no.Text.Trim() !="")
					long.Parse(m_txthic_no.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("医疗证只能输入数字!");
				m_txthic_no.Focus();
				return null;
			}
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
			
			if(m_txtIDCard.Text.Trim().Length!=0 && m_txtIDCard.Text.Trim().Length !=15 && m_txtIDCard.Text.Trim().Length !=18)
			{
				clsPublicFunction.ShowInformationMessageBox("身份证号输入有误!");
				m_txtIDCard.Focus();
				return null;
			}

			clsPatientBaseInfo m_objPatientBaseInfo=new clsPatientBaseInfo();
			m_objPatientBaseInfo.m_objPeopleInfo=new clsPeopleInfo();
			m_objPatientBaseInfo.m_strInPatientID=m_txtInPatientID.Text.Trim();
			m_objPatientBaseInfo.m_strPatientID=m_txtPatientID.Text.Trim();			
			m_objPatientBaseInfo.m_objPeopleInfo.m_IntTimes = (int)m_numTimes.Value;
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhic_no = m_txthic_no.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrFirstName=m_txtPatientFirstName.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrSex=m_cboSex.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_DtmBirth=m_dtpBirth.Value;
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrMarried=m_cboMarried.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOccupation=m_cboOccupation.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strvip_code=m_cbovip_code.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomeplace=m_cboHomePlace.Text.Trim();
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
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_district=m_cbohome_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_street=m_txthome_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePhone=m_txtHomePhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePC=m_txtHomePC.Text.Trim(); 
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_district=m_cbotemp_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_street=m_txttemp_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_tel=m_txttemp_tel.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_zipcode=m_txttemp_zipcode.Text.Trim(); 
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strinsurance=m_cboinsurance.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Stradmiss_status=m_cboadmiss_status.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strvisit_type=m_cbovisit_type.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrChargeCategory=m_cboChargeCategory.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrPaymentPercent=m_cboPaymentPercent.Text.Trim();
			return m_objPatientBaseInfo;
		}

		/// <summary>
		/// 只能输入数字和退格的文本框
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_txtOnlyNum_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			bool blnIfOK=true;

			for(int i1=0;i1<=9;i1++)
			{
				if (e.KeyChar.ToString()==i1.ToString())
				{
					blnIfOK=false;
					break;
				}
			}
			if(e.KeyChar==Convert.ToChar(8))return;
			if (e.KeyChar.ToString()!=Keys.Back.ToString())
				e.Handled=blnIfOK;
		}

	}

//	[Serializable]
//	/// <summary>
//	/// 记录病人基本资料的修改标记
//	/// </summary>
//	public class clsPatientBaseInfo_ModifyFlag
//	{
//		public string m_strInPatientID;
//		public int m_intPatientID;
//		public int m_intFirstName;
//		public int m_intIDCard;
//		public int m_intSex;
//		public int m_intMarried;
//		public int m_intBirth;
//		public int m_intChargeCategory;
//		public int m_intPaymentPercent;
//		public int m_intHomeplace;
//		public int m_intNationality;
//		public int m_intNation;
//		public int m_intNativePlace;
//		public int m_intOccupation;
//		public int m_intOfficePhone;
//		public int m_intHomePhone;
//		public int m_intMobile;
//		public int m_intOfficeAddress;
//		public int m_intHomeAddress;
//		public int m_intOfficePC;
//		public int m_intHomePC;
//		public int m_intEMail;
//		public int m_intLinkManFirstName;
//		public int m_intLinkManAddress;
//		public int m_intLinkManPhone;
//		public int m_intLinkManPC;
//		public int m_intPatientRelation;
//		public int m_intFirstDate;
//		public int m_intIsEmployee;
//		
//	}
}
