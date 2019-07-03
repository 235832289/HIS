using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using iCareData;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmManageExplorer : iCareBaseForm.frmBaseForm,PublicFunction
	{
		#region FromDefines		
		
		private System.Windows.Forms.TreeView m_trvManageExplorer;
		private System.Windows.Forms.Panel m_pnlRight;
		private System.Windows.Forms.Panel m_pnlDept;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage m_tbpDeptAddArea;
		private System.Windows.Forms.TextBox m_txtDeptNewAreaName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox m_txtDeptNewAreaID;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TabPage m_tbpDeptAddEmployee;
		private System.Windows.Forms.Label label40;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDeptAddEmployeeName;
		private System.Windows.Forms.Label label39;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDeptAddEmployeeID;
		private System.Windows.Forms.Label m_lblDeptDeptName;
		private System.Windows.Forms.Label m_lblDeptDeptID;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel m_pnlPatient;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedName;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedArea;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedDept;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedStatus;
		private System.Windows.Forms.Label m_lblPatientPatientID;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label m_lblPatientPatientName;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ImageList imgTreeView;
		private System.Windows.Forms.Panel m_pnlEmployee;
		private System.Windows.Forms.ListBox m_lstEmployeeTakenDept;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label m_lblEmployeeEmployeeName;
		private System.Windows.Forms.Label m_lblEmployeeEmployeeID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label19;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboEmployeeDeptName;
		private System.Windows.Forms.Label label23;
		protected System.Windows.Forms.ListView m_lsvDeptTbp2EmployeeID;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		protected System.Windows.Forms.ListView m_lsvDeptTbp2EmployeeName;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.Label m_lblLsvManagerTitle;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Panel m_pnlArea;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox m_txtAreaNewBedID;
		private System.Windows.Forms.TextBox m_txtAreaNewBedName;
		private System.Windows.Forms.Label m_lblAreaAreaID;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox m_txtAreaAreaName;
		private System.Windows.Forms.ContextMenu m_ctmTreeContextMenu;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.Panel m_pnlBed;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBedAddPatient;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label m_lblBedBedID;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox m_txtBedBedName;
		private System.Windows.Forms.Label label15;
		public System.Windows.Forms.ListView m_lsvManageExplorerMid;
		private System.Windows.Forms.ColumnHeader clmBedNO;
		private System.Windows.Forms.ColumnHeader clmInPatientID;
		private System.Windows.Forms.ImageList imgListView;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.TabControl m_tabQuanYuan;
		private System.Windows.Forms.TabPage m_tbpEmployee;
		protected System.Windows.Forms.ListView m_lsvTbp2EmployeeID;
		protected System.Windows.Forms.ListView m_lsvTbp2EmployeeName;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpTbp2Birth;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp2Sex;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2EmployeeName;
		protected System.Windows.Forms.Label label9;
		protected System.Windows.Forms.Label label24;
		protected System.Windows.Forms.Label label27;
		protected System.Windows.Forms.Label lblTitleOfaTechnicalPostTitle;
		protected System.Windows.Forms.Label label28;
		protected System.Windows.Forms.Label label29;
		protected System.Windows.Forms.Label label30;
		protected System.Windows.Forms.Label label31;
		protected System.Windows.Forms.Label label32;
		protected System.Windows.Forms.Label label33;
		protected System.Windows.Forms.Label label34;
		protected System.Windows.Forms.Label label35;
		protected System.Windows.Forms.Label lblEmployeeIDTitle;
		protected System.Windows.Forms.Label lblPYCodeTitle;
		protected System.Windows.Forms.Label lblEducationalLevelTitle;
		protected System.Windows.Forms.Label label36;
		protected System.Windows.Forms.Label lblLanguageAbilityTitle;
		protected System.Windows.Forms.Label label37;
		protected System.Windows.Forms.Label lblFirstNameOfAnnouncerTitle;
		protected System.Windows.Forms.Label lblPhoneOfAnnouncerTitle;
		protected System.Windows.Forms.Label lblExperienceTitle;
		protected System.Windows.Forms.Label lblRemarkTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2IDCard;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2TitleOfaTechnicalPost;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2OfficePhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2HomePhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2HomeAddress;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2OfficeAddress;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2OfficePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2HomePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2Mobile;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2EMail;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2EmployeeID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2PYCode;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2EducationalLevel;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2LanguageAbility;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2FirstNameOfAnnouncer;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2PhoneOfAnnouncer;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2Experience;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp2Remark;
		private System.Windows.Forms.TabPage m_tbpDept;
		protected System.Windows.Forms.ListView m_lsvTbp3DeptID;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp3Category;
		protected System.Windows.Forms.ListView m_lsvTbp3DeptName;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp3DeptID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp3DeptName;
		protected System.Windows.Forms.Label lblDeptIDTitle;
		protected System.Windows.Forms.Label lblDeptNameTitle;
		protected System.Windows.Forms.Label lblCategoryTitle;
		protected System.Windows.Forms.Label lblInPatientOrOutPatientTitle;
		protected System.Windows.Forms.Label lblAddressTitle;
		protected System.Windows.Forms.Label label38;
		protected System.Windows.Forms.Label lblShortNOTitle;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp3InPatientOrOutPatient;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp3Address;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp3PYCode;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp3ShortNO;
		private System.Windows.Forms.TabPage m_tbpPatient;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader clmTbp2EmployeeID;
		private System.Windows.Forms.ColumnHeader clmTbp2EmployeeName;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp2Married;
		private System.Windows.Forms.TabControl m_tabData;
		private System.Windows.Forms.TabPage m_tbpMust;
		private System.Windows.Forms.TabPage m_tbpOther;
		private System.Windows.Forms.GroupBox m_gpbtbp1Must;
		protected System.Windows.Forms.ListView m_lsvTbp1InPatientID;
		protected System.Windows.Forms.ListView m_lsvTbp1InPatientName;
		private System.Windows.Forms.NumericUpDown m_numTbp1Times;
		protected System.Windows.Forms.Label label41;
		private System.Windows.Forms.CheckBox m_chkTbp1IsOldPatient;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Married;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Sex;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpTbp1Birth;
		protected System.Windows.Forms.Label lblNameTitle;
		protected System.Windows.Forms.Label lblSexTitle;
		protected System.Windows.Forms.Label lblInPatientIDTitle;
		protected System.Windows.Forms.Label lblMarriedTitle;
		protected System.Windows.Forms.Label label1;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1InPatientID;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1PatientFirstName;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1LinkManRelation;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Admiss_status;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Visit_type;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Insurance;
		private System.Windows.Forms.Label lblLinkManAddress;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1TempPhone;
		protected System.Windows.Forms.Label label50;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1Temp_street;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Temp_district;
		protected System.Windows.Forms.Label label53;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1LinkManPhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1OfficePhone;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Office_district;
		protected System.Windows.Forms.Label label46;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1Office_street;
		protected System.Windows.Forms.Label label47;
		protected System.Windows.Forms.Label label48;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1OfficeName;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Nationality;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Nation;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1BornPlace;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Occupation;
		protected System.Windows.Forms.Label lblOfficePhoneTitle;
		protected System.Windows.Forms.Label lblHomePhoneTitle;
		protected System.Windows.Forms.Label lblHomeAddressTitle;
		protected System.Windows.Forms.Label lblHomePCTitle;
		protected System.Windows.Forms.Label lblOfficePCTitle;
		protected System.Windows.Forms.Label lblIDCardTitle;
		private System.Windows.Forms.Label lblNation;
		private System.Windows.Forms.Label lblNationality;
		private System.Windows.Forms.Label lblOccupation;
		private System.Windows.Forms.Label lblHomeplace;
		private System.Windows.Forms.Label lblPatientRelation;
		private System.Windows.Forms.Label lblLinkManPhone;
		private System.Windows.Forms.Label lblLinkMan;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1HomePhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1OfficePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1HomePC;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1IDCard;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1LinkManPC;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1LinkMan;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1vip_code;
		protected System.Windows.Forms.Label label42;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1LinkMan_district;
		protected System.Windows.Forms.Label label3;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1LinkMan_street;
		protected System.Windows.Forms.Label label49;
		protected System.Windows.Forms.Label label51;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1Home_district;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1Home_street;
		protected System.Windows.Forms.Label label52;
		protected System.Windows.Forms.Label label54;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1temp_zipcode;
		protected System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label43;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1Hic_no;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTbp1PatientID;
		private System.Windows.Forms.Label lblChargeCategory;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1ChargeCategory;
		private System.Windows.Forms.Label label45;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1PaymentPercent;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedArea2;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedDept2;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedName2;
		private System.Windows.Forms.GroupBox groupBox1;
		private PinkieControls.ButtonXP m_cmdDeptDeptInfo;
		private PinkieControls.ButtonXP m_cmdDeptDeptDelete;
		private PinkieControls.ButtonXP m_cmdDeptAddArea;
		private PinkieControls.ButtonXP m_cmdDeptTbp2AddEmployee;
		private PinkieControls.ButtonXP m_cmdBedRename;
		private PinkieControls.ButtonXP m_cmdBedApplyBedToPatient;
		private PinkieControls.ButtonXP m_cmdBedDeleteBed;
		private PinkieControls.ButtonXP m_cmdAreaApplyName;
		private PinkieControls.ButtonXP m_cmdAreaDeleteArea;
		private PinkieControls.ButtonXP m_cmdAreaAddBed;
		private PinkieControls.ButtonXP m_cmdEmployeeEmployeeInfo;
		private PinkieControls.ButtonXP m_cmdEmployeeAddArea;
		private PinkieControls.ButtonXP m_cmdEmployeeDeleteArea;
		private PinkieControls.ButtonXP m_cmdPatientPatientInfo;
		private PinkieControls.ButtonXP m_cmdPatientChangeBed;
		private PinkieControls.ButtonXP m_cmdTbp1OK;
		private PinkieControls.ButtonXP m_cmdTbp1ClearForm;
		private PinkieControls.ButtonXP m_cmdTbp3OK;
		private PinkieControls.ButtonXP m_cmdTbp3ClearForm;
		private PinkieControls.ButtonXP m_cmdTbp2OK;
		private PinkieControls.ButtonXP m_cmdTbp2ClearForm;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpInPatientDate;
		protected System.Windows.Forms.Label label60;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.TabPage m_tbpForLeavePatient;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.ListView m_lstLeavePatient;
		private System.Windows.Forms.ColumnHeader m_chrLeavePatientName;
		private System.Windows.Forms.ColumnHeader m_chrLastLeaveData;
		private System.Windows.Forms.ColumnHeader m_chrBedStatus;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDeptForLeave;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboAreaForLeave;
		private PinkieControls.ButtonXP m_cmdReLocate;
		private PinkieControls.ButtonXP m_cmdUndoLeave;
		private System.Windows.Forms.ColumnHeader m_chrBedName;
		private System.Windows.Forms.Label m_lblZCInf;
		protected System.Windows.Forms.Label label80;
		private System.Windows.Forms.TextBox m_txtAge;
		private System.Windows.Forms.Label label81;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTbp1NativePlace;
		private System.ComponentModel.IContainer components;		
		#endregion			

		public frmManageExplorer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//支持排序功能
			new clsSortTool().m_mthSetListViewSortable(m_lstLeavePatient);

			#region 添加常用值
			m_cboTbp1ChargeCategory.AddRangeItems(clsComboBoxItems.m_StrChargeCategoryArr);
			m_cboTbp1vip_code.AddRangeItems(clsComboBoxItems.m_StrVip_codeArr);
			m_cboTbp1Married.AddRangeItems(clsComboBoxItems.m_StrMarriedArr);
			m_cboTbp2Married.AddRangeItems(clsComboBoxItems.m_StrMarriedArr);
			m_cboTbp1Sex.AddRangeItems(clsComboBoxItems.m_StrSexArr);
			m_cboTbp2Sex.AddRangeItems(clsComboBoxItems.m_StrSexArr);
			m_cboTbp3Category.AddRangeItems(new string[]{"临床","辅助"});
			m_cboTbp3InPatientOrOutPatient.AddRangeItems(clsComboBoxItems.m_StrInPatientOrOutPatientArr);
			m_cboTbp1Nationality.AddItem("中国");
			m_cboTbp1Admiss_status.AddRangeItems(clsComboBoxItems.m_StrAdmiss_statusArr);
			m_cboTbp1Visit_type.AddRangeItems(clsComboBoxItems.m_StrVisit_typeArr);
			m_cboTbp1LinkManRelation.AddRangeItems(clsComboBoxItems.m_StrLinkManRelationArr);

			m_lsvTbp1InPatientID.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			m_lsvTbp1InPatientName.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			m_lsvTbp2EmployeeID.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			m_lsvTbp2EmployeeName.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			m_lsvTbp3DeptID.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			m_lsvTbp3DeptName.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			m_lsvDeptTbp2EmployeeID.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);
			m_lsvDeptTbp2EmployeeName.LostFocus+=new EventHandler(m_mthEvent_LsvLostFocus);

			m_cboTbp1PaymentPercent.AddRangeItems(clsComboBoxItems.m_StrPaymentPercentArr);
			m_cboTbp1Occupation.AddRangeItems(clsComboBoxItems.m_StrOccupationArr);
			m_cboTbp1Nation.AddRangeItems(clsComboBoxItems.m_StrNationalityArr);
			
			m_cboTbp1Home_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboTbp1Office_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboTbp1LinkMan_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboTbp1BornPlace.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboTbp1NativePlace.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboTbp1Temp_district.AddRangeItems(clsComboBoxItems.m_StrDistrictArr);
			m_cboTbp1Insurance.AddRangeItems(clsComboBoxItems.m_StrInsuranceArr);

			#endregion
			if(m_blnCurrentIsPatient)
			{
//				m_rdbPatientLsv.Checked=true;
//				m_gpbAddEmployee.Visible=false;
			}
			else
			{
				
//				m_rdbEmployeeLsv.Checked=true;
//				m_gpbAddEmployee.Visible=true;
			}

			m_lsvDeptTbp2EmployeeID.Left=m_pnlRight.Left+m_pnlDept.Left+tabControl1.Left +m_tbpDeptAddArea.Left+ m_txtDeptAddEmployeeID.Left;
//			m_lsvDeptTbp2EmployeeID.Top=m_pnlRight.Left+m_pnlDept.Left+tabControl1.Left +m_tbpDeptAddArea.Left+ m_txtDeptAddEmployeeID.Bottom;

			m_lsvDeptTbp2EmployeeName.Left=m_pnlRight.Left+m_pnlDept.Left+tabControl1.Left +m_tbpDeptAddArea.Left+ m_txtDeptAddEmployeeName.Left;
//			m_lsvDeptTbp2EmployeeName.Top=m_pnlRight.Left+m_pnlDept.Left+tabControl1.Left +m_tbpDeptAddArea.Left+ m_txtDeptAddEmployeeName.Bottom;

			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
			m_objHighLight.m_mthAddControlInContainer(this);

			#region 画白边和高亮

			clsBorderTool m_objBorderTool = new clsBorderTool(Color.White);
			m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
														{
															this.m_trvManageExplorer ,this.m_lsvManageExplorerMid,this.m_numTbp1Times
														});
			
			foreach(Control objPnl in m_pnlRight.Controls)
			{
				if(objPnl.GetType().Name=="Panel")
				{
					m_objHighLight.m_mthAddControlInContainer(objPnl);
					foreach(Control objCtl in objPnl.Controls)
					{
						if(objCtl.GetType().Name=="TextBox" || objCtl.GetType().Name=="ListBox")
						{
							m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{objCtl});
						}
						else if(objCtl.GetType().Name=="GroupBox")
						{
							m_objHighLight.m_mthAddControlInContainer(objCtl);
							foreach(Control objGroupCtl in objCtl.Controls)
							{
								if(objGroupCtl.GetType().Name=="TextBox" || objGroupCtl.GetType().Name=="ListBox")
								{
									m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{objGroupCtl});
								}
							}
						}
						else if(objCtl.GetType().Name=="TabControl")
						{
							foreach(Control ctlPage in objCtl.Controls)
							{
								if(ctlPage.GetType().Name=="TabPage")	m_objHighLight.m_mthAddControlInContainer(ctlPage);
								foreach(Control ctlInPage in ctlPage.Controls)
								{
									if(ctlInPage.GetType().Name=="TextBox") m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{ctlInPage});
								}
							}
						}
					}
				}
				else if(objPnl.GetType().Name=="TabControl")
				{
					foreach(Control ctlPage in objPnl.Controls)
					{
						if(ctlPage.GetType().Name=="TabPage")	m_objHighLight.m_mthAddControlInContainer(ctlPage);
					}
				}
			}
			#endregion

			m_mthSetQuickKeys();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		#region UserDefines
		clsDepartmentManager m_objManagerDomain=new clsDepartmentManager();
		clsDepartmentHandlerDomain m_objHandlerDomain=new clsDepartmentHandlerDomain();

		/// <summary>
		/// 记录当前选择的是哪个树节点。
		/// </summary>
		private TreeNode m_trnCurrentNode=new TreeNode();
		/// <summary>
		/// 模糊查询的下拉框允许的最大长度
		/// </summary>
		private int c_intMaxLikeLsvLength=3000;	

		/// <summary>
		/// 记录右下方的ListView中显示员工还是病人
		/// 		/// </summary>
		private bool m_blnCurrentIsPatient=true;

		private bool m_blnIsOldPatient=false;
		private ctlHighLightFocus m_objHighLight;
		#endregion UserDefines		

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmManageExplorer));
			this.m_trvManageExplorer = new System.Windows.Forms.TreeView();
			this.imgTreeView = new System.Windows.Forms.ImageList(this.components);
			this.m_pnlRight = new System.Windows.Forms.Panel();
			this.m_lsvDeptTbp2EmployeeName = new System.Windows.Forms.ListView();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.m_lblLsvManagerTitle = new System.Windows.Forms.Label();
			this.m_lsvManageExplorerMid = new System.Windows.Forms.ListView();
			this.clmBedNO = new System.Windows.Forms.ColumnHeader();
			this.clmInPatientID = new System.Windows.Forms.ColumnHeader();
			this.imgListView = new System.Windows.Forms.ImageList(this.components);
			this.m_pnlBed = new System.Windows.Forms.Panel();
			this.m_cboBedAddPatient = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.m_lblBedBedID = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.m_txtBedBedName = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.m_cmdBedRename = new PinkieControls.ButtonXP();
			this.m_cmdBedApplyBedToPatient = new PinkieControls.ButtonXP();
			this.m_cmdBedDeleteBed = new PinkieControls.ButtonXP();
			this.m_pnlDept = new System.Windows.Forms.Panel();
			this.m_cmdDeptDeptDelete = new PinkieControls.ButtonXP();
			this.m_cmdDeptDeptInfo = new PinkieControls.ButtonXP();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.m_tbpDeptAddArea = new System.Windows.Forms.TabPage();
			this.m_txtDeptNewAreaName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtDeptNewAreaID = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_cmdDeptAddArea = new PinkieControls.ButtonXP();
			this.m_tbpDeptAddEmployee = new System.Windows.Forms.TabPage();
			this.m_cmdDeptTbp2AddEmployee = new PinkieControls.ButtonXP();
			this.label40 = new System.Windows.Forms.Label();
			this.m_txtDeptAddEmployeeName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.m_txtDeptAddEmployeeID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_lblDeptDeptName = new System.Windows.Forms.Label();
			this.m_lblDeptDeptID = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_lblZCInf = new System.Windows.Forms.Label();
			this.m_lsvDeptTbp2EmployeeID = new System.Windows.Forms.ListView();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.m_pnlPatient = new System.Windows.Forms.Panel();
			this.m_cboPatientBedName = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboPatientBedArea = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboPatientBedDept = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboPatientBedStatus = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_lblPatientPatientID = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.m_lblPatientPatientName = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.m_cmdPatientPatientInfo = new PinkieControls.ButtonXP();
			this.m_cmdPatientChangeBed = new PinkieControls.ButtonXP();
			this.m_pnlEmployee = new System.Windows.Forms.Panel();
			this.label22 = new System.Windows.Forms.Label();
			this.m_cmdEmployeeEmployeeInfo = new PinkieControls.ButtonXP();
			this.m_lstEmployeeTakenDept = new System.Windows.Forms.ListBox();
			this.m_lblEmployeeEmployeeName = new System.Windows.Forms.Label();
			this.m_lblEmployeeEmployeeID = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.m_cboEmployeeDeptName = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.m_cmdEmployeeAddArea = new PinkieControls.ButtonXP();
			this.m_cmdEmployeeDeleteArea = new PinkieControls.ButtonXP();
			this.m_pnlArea = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.m_cmdAreaAddBed = new PinkieControls.ButtonXP();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.m_txtAreaNewBedID = new System.Windows.Forms.TextBox();
			this.m_txtAreaNewBedName = new System.Windows.Forms.TextBox();
			this.m_lblAreaAreaID = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.m_txtAreaAreaName = new System.Windows.Forms.TextBox();
			this.m_cmdAreaApplyName = new PinkieControls.ButtonXP();
			this.m_cmdAreaDeleteArea = new PinkieControls.ButtonXP();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.m_ctmTreeContextMenu = new System.Windows.Forms.ContextMenu();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.m_tabQuanYuan = new System.Windows.Forms.TabControl();
			this.m_tbpPatient = new System.Windows.Forms.TabPage();
			this.m_tabData = new System.Windows.Forms.TabControl();
			this.m_tbpMust = new System.Windows.Forms.TabPage();
			this.m_tbpOther = new System.Windows.Forms.TabPage();
			this.m_cmdTbp1OK = new PinkieControls.ButtonXP();
			this.m_cmdTbp1ClearForm = new PinkieControls.ButtonXP();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_gpbtbp1Must = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label53 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.m_txtTbp1LinkManPhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp1OfficePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblLinkManAddress = new System.Windows.Forms.Label();
			this.m_cboTbp1Office_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label46 = new System.Windows.Forms.Label();
			this.m_txtTbp1Office_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.m_txtTbp1OfficeName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboTbp1Nationality = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblOfficePhoneTitle = new System.Windows.Forms.Label();
			this.lblHomePCTitle = new System.Windows.Forms.Label();
			this.lblOfficePCTitle = new System.Windows.Forms.Label();
			this.lblIDCardTitle = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.lblNationality = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.m_txtTbp1Hic_no = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblPatientRelation = new System.Windows.Forms.Label();
			this.m_txtTbp1PatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblLinkManPhone = new System.Windows.Forms.Label();
			this.lblChargeCategory = new System.Windows.Forms.Label();
			this.m_cboTbp1ChargeCategory = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtTbp1OfficePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.m_txtTbp1HomePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboTbp1PaymentPercent = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtTbp1IDCard = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboTbp1LinkManRelation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboTbp1Admiss_status = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtTbp1LinkManPC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboTbp1Visit_type = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label55 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.m_cboTbp1vip_code = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label42 = new System.Windows.Forms.Label();
			this.m_cboTbp1Insurance = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboTbp1LinkMan_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.m_txtTbp1Home_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.m_txtTbp1TempPhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.m_txtTbp1temp_zipcode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp1Temp_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp1LinkMan_street = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboTbp1Temp_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label81 = new System.Windows.Forms.Label();
			this.m_cboTbp1BornPlace = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtAge = new System.Windows.Forms.TextBox();
			this.m_dtpInPatientDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_txtTbp1PatientFirstName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_lsvTbp1InPatientName = new System.Windows.Forms.ListView();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.m_cboTbp1Married = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboPatientBedArea2 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtTbp1HomePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label77 = new System.Windows.Forms.Label();
			this.label75 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.m_lsvTbp1InPatientID = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.label71 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.label69 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.label66 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.m_cboPatientBedDept2 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboTbp1Sex = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_numTbp1Times = new System.Windows.Forms.NumericUpDown();
			this.label41 = new System.Windows.Forms.Label();
			this.m_dtpTbp1Birth = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.lblNameTitle = new System.Windows.Forms.Label();
			this.lblSexTitle = new System.Windows.Forms.Label();
			this.lblMarriedTitle = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label59 = new System.Windows.Forms.Label();
			this.m_cboPatientBedName2 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label58 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.m_cboTbp1Nation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblOccupation = new System.Windows.Forms.Label();
			this.lblHomePhoneTitle = new System.Windows.Forms.Label();
			this.m_chkTbp1IsOldPatient = new System.Windows.Forms.CheckBox();
			this.lblHomeplace = new System.Windows.Forms.Label();
			this.lblHomeAddressTitle = new System.Windows.Forms.Label();
			this.m_cboTbp1Home_district = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblLinkMan = new System.Windows.Forms.Label();
			this.m_txtTbp1LinkMan = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblInPatientIDTitle = new System.Windows.Forms.Label();
			this.label67 = new System.Windows.Forms.Label();
			this.m_txtTbp1InPatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblNation = new System.Windows.Forms.Label();
			this.m_cboTbp1Occupation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label76 = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.m_cboTbp1NativePlace = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_tbpEmployee = new System.Windows.Forms.TabPage();
			this.m_cmdTbp2OK = new PinkieControls.ButtonXP();
			this.m_cmdTbp2ClearForm = new PinkieControls.ButtonXP();
			this.m_txtTbp2PYCode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2Experience = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2LanguageAbility = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_lsvTbp2EmployeeName = new System.Windows.Forms.ListView();
			this.clmTbp2EmployeeID = new System.Windows.Forms.ColumnHeader();
			this.clmTbp2EmployeeName = new System.Windows.Forms.ColumnHeader();
			this.m_lsvTbp2EmployeeID = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.m_cboTbp2Married = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_dtpTbp2Birth = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_cboTbp2Sex = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtTbp2EmployeeName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.lblPYCodeTitle = new System.Windows.Forms.Label();
			this.lblEducationalLevelTitle = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.lblLanguageAbilityTitle = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.lblPhoneOfAnnouncerTitle = new System.Windows.Forms.Label();
			this.lblExperienceTitle = new System.Windows.Forms.Label();
			this.lblRemarkTitle = new System.Windows.Forms.Label();
			this.m_txtTbp2IDCard = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2TitleOfaTechnicalPost = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2OfficePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2HomePhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2HomeAddress = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2OfficeAddress = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2OfficePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2HomePC = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2Mobile = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2EMail = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2EmployeeID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2EducationalLevel = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2FirstNameOfAnnouncer = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2PhoneOfAnnouncer = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp2Remark = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.lblTitleOfaTechnicalPostTitle = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.lblEmployeeIDTitle = new System.Windows.Forms.Label();
			this.lblFirstNameOfAnnouncerTitle = new System.Windows.Forms.Label();
			this.m_tbpDept = new System.Windows.Forms.TabPage();
			this.m_cmdTbp3OK = new PinkieControls.ButtonXP();
			this.m_lsvTbp3DeptID = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.m_lsvTbp3DeptName = new System.Windows.Forms.ListView();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.m_txtTbp3DeptID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp3DeptName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboTbp3Category = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblDeptIDTitle = new System.Windows.Forms.Label();
			this.lblDeptNameTitle = new System.Windows.Forms.Label();
			this.lblCategoryTitle = new System.Windows.Forms.Label();
			this.lblInPatientOrOutPatientTitle = new System.Windows.Forms.Label();
			this.lblAddressTitle = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.lblShortNOTitle = new System.Windows.Forms.Label();
			this.m_cboTbp3InPatientOrOutPatient = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_txtTbp3Address = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp3PYCode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtTbp3ShortNO = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cmdTbp3ClearForm = new PinkieControls.ButtonXP();
			this.m_tbpForLeavePatient = new System.Windows.Forms.TabPage();
			this.m_cmdReLocate = new PinkieControls.ButtonXP();
			this.m_cmdUndoLeave = new PinkieControls.ButtonXP();
			this.m_lstLeavePatient = new System.Windows.Forms.ListView();
			this.m_chrLeavePatientName = new System.Windows.Forms.ColumnHeader();
			this.m_chrLastLeaveData = new System.Windows.Forms.ColumnHeader();
			this.m_chrBedName = new System.Windows.Forms.ColumnHeader();
			this.m_chrBedStatus = new System.Windows.Forms.ColumnHeader();
			this.label79 = new System.Windows.Forms.Label();
			this.label78 = new System.Windows.Forms.Label();
			this.m_cboAreaForLeave = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboDeptForLeave = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_pnlRight.SuspendLayout();
			this.m_pnlBed.SuspendLayout();
			this.m_pnlDept.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.m_tbpDeptAddArea.SuspendLayout();
			this.m_tbpDeptAddEmployee.SuspendLayout();
			this.m_pnlPatient.SuspendLayout();
			this.m_pnlEmployee.SuspendLayout();
			this.m_pnlArea.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.m_tabQuanYuan.SuspendLayout();
			this.m_tbpPatient.SuspendLayout();
			this.m_tabData.SuspendLayout();
			this.m_gpbtbp1Must.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_numTbp1Times)).BeginInit();
			this.m_tbpEmployee.SuspendLayout();
			this.m_tbpDept.SuspendLayout();
			this.m_tbpForLeavePatient.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_trvManageExplorer
			// 
			this.m_trvManageExplorer.BackColor = System.Drawing.Color.White;
			this.m_trvManageExplorer.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_trvManageExplorer.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_trvManageExplorer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_trvManageExplorer.ForeColor = System.Drawing.Color.Black;
			this.m_trvManageExplorer.HideSelection = false;
			this.m_trvManageExplorer.HotTracking = true;
			this.m_trvManageExplorer.ImageList = this.imgTreeView;
			this.m_trvManageExplorer.Indent = 22;
			this.m_trvManageExplorer.Location = new System.Drawing.Point(0, 0);
			this.m_trvManageExplorer.Name = "m_trvManageExplorer";
			this.m_trvManageExplorer.ShowRootLines = false;
			this.m_trvManageExplorer.Size = new System.Drawing.Size(172, 653);
			this.m_trvManageExplorer.TabIndex = 1;
			this.m_trvManageExplorer.Click += new System.EventHandler(this.m_trvManageExplorer_Click);
			this.m_trvManageExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvManageExplorer_AfterSelect);
			// 
			// imgTreeView
			// 
			this.imgTreeView.ImageSize = new System.Drawing.Size(17, 17);
			this.imgTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTreeView.ImageStream")));
			this.imgTreeView.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_pnlRight
			// 
			this.m_pnlRight.Controls.Add(this.m_lsvDeptTbp2EmployeeName);
			this.m_pnlRight.Controls.Add(this.m_lblLsvManagerTitle);
			this.m_pnlRight.Controls.Add(this.m_lsvManageExplorerMid);
			this.m_pnlRight.Controls.Add(this.m_pnlBed);
			this.m_pnlRight.Controls.Add(this.m_pnlDept);
			this.m_pnlRight.Controls.Add(this.m_lblZCInf);
			this.m_pnlRight.Controls.Add(this.m_lsvDeptTbp2EmployeeID);
			this.m_pnlRight.Controls.Add(this.m_pnlPatient);
			this.m_pnlRight.Controls.Add(this.m_pnlEmployee);
			this.m_pnlRight.Controls.Add(this.m_pnlArea);
			this.m_pnlRight.Location = new System.Drawing.Point(256, 0);
			this.m_pnlRight.Name = "m_pnlRight";
			this.m_pnlRight.Size = new System.Drawing.Size(540, 644);
			this.m_pnlRight.TabIndex = 29218;
			// 
			// m_lsvDeptTbp2EmployeeName
			// 
			this.m_lsvDeptTbp2EmployeeName.BackColor = System.Drawing.Color.White;
			this.m_lsvDeptTbp2EmployeeName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																										this.columnHeader17,
																										this.columnHeader18});
			this.m_lsvDeptTbp2EmployeeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvDeptTbp2EmployeeName.ForeColor = System.Drawing.Color.Black;
			this.m_lsvDeptTbp2EmployeeName.FullRowSelect = true;
			this.m_lsvDeptTbp2EmployeeName.GridLines = true;
			this.m_lsvDeptTbp2EmployeeName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvDeptTbp2EmployeeName.Location = new System.Drawing.Point(360, 128);
			this.m_lsvDeptTbp2EmployeeName.MultiSelect = false;
			this.m_lsvDeptTbp2EmployeeName.Name = "m_lsvDeptTbp2EmployeeName";
			this.m_lsvDeptTbp2EmployeeName.Size = new System.Drawing.Size(108, 104);
			this.m_lsvDeptTbp2EmployeeName.TabIndex = 6091;
			this.m_lsvDeptTbp2EmployeeName.View = System.Windows.Forms.View.Details;
			this.m_lsvDeptTbp2EmployeeName.Visible = false;
			this.m_lsvDeptTbp2EmployeeName.DoubleClick += new System.EventHandler(this.m_mthEvent_DoubleClikcLsv);
			// 
			// columnHeader17
			// 
			this.columnHeader17.Width = 0;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Width = 102;
			// 
			// m_lblLsvManagerTitle
			// 
			this.m_lblLsvManagerTitle.AutoSize = true;
			this.m_lblLsvManagerTitle.Location = new System.Drawing.Point(12, 164);
			this.m_lblLsvManagerTitle.Name = "m_lblLsvManagerTitle";
			this.m_lblLsvManagerTitle.Size = new System.Drawing.Size(0, 19);
			this.m_lblLsvManagerTitle.TabIndex = 29226;
			// 
			// m_lsvManageExplorerMid
			// 
			this.m_lsvManageExplorerMid.BackColor = System.Drawing.Color.White;
			this.m_lsvManageExplorerMid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									 this.clmBedNO,
																									 this.clmInPatientID});
			this.m_lsvManageExplorerMid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvManageExplorerMid.ForeColor = System.Drawing.Color.Black;
			this.m_lsvManageExplorerMid.FullRowSelect = true;
			this.m_lsvManageExplorerMid.GridLines = true;
			this.m_lsvManageExplorerMid.LargeImageList = this.imgListView;
			this.m_lsvManageExplorerMid.Location = new System.Drawing.Point(4, 192);
			this.m_lsvManageExplorerMid.MultiSelect = false;
			this.m_lsvManageExplorerMid.Name = "m_lsvManageExplorerMid";
			this.m_lsvManageExplorerMid.Size = new System.Drawing.Size(552, 448);
			this.m_lsvManageExplorerMid.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvManageExplorerMid.TabIndex = 12000;
			this.m_lsvManageExplorerMid.Click += new System.EventHandler(this.m_lsvManageExplorerMid_Click);
			this.m_lsvManageExplorerMid.SelectedIndexChanged += new System.EventHandler(this.m_lsvManageExplorerMid_SelectedIndexChanged);
			// 
			// clmInPatientID
			// 
			this.clmInPatientID.Text = "住院号";
			this.clmInPatientID.Width = 150;
			// 
			// imgListView
			// 
			this.imgListView.ImageSize = new System.Drawing.Size(40, 40);
			this.imgListView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListView.ImageStream")));
			this.imgListView.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_pnlBed
			// 
			this.m_pnlBed.Controls.Add(this.m_cboBedAddPatient);
			this.m_pnlBed.Controls.Add(this.label18);
			this.m_pnlBed.Controls.Add(this.m_lblBedBedID);
			this.m_pnlBed.Controls.Add(this.label16);
			this.m_pnlBed.Controls.Add(this.m_txtBedBedName);
			this.m_pnlBed.Controls.Add(this.label15);
			this.m_pnlBed.Controls.Add(this.m_cmdBedRename);
			this.m_pnlBed.Controls.Add(this.m_cmdBedApplyBedToPatient);
			this.m_pnlBed.Controls.Add(this.m_cmdBedDeleteBed);
			this.m_pnlBed.Location = new System.Drawing.Point(8, 8);
			this.m_pnlBed.Name = "m_pnlBed";
			this.m_pnlBed.Size = new System.Drawing.Size(544, 148);
			this.m_pnlBed.TabIndex = 29222;
			// 
			// m_cboBedAddPatient
			// 
			this.m_cboBedAddPatient.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboBedAddPatient.BorderColor = System.Drawing.Color.Black;
			this.m_cboBedAddPatient.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboBedAddPatient.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboBedAddPatient.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboBedAddPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBedAddPatient.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBedAddPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBedAddPatient.ForeColor = System.Drawing.Color.Black;
			this.m_cboBedAddPatient.ListBackColor = System.Drawing.Color.White;
			this.m_cboBedAddPatient.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboBedAddPatient.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboBedAddPatient.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboBedAddPatient.Location = new System.Drawing.Point(142, 87);
			this.m_cboBedAddPatient.m_BlnEnableItemEventMenu = true;
			this.m_cboBedAddPatient.Name = "m_cboBedAddPatient";
			this.m_cboBedAddPatient.SelectedIndex = -1;
			this.m_cboBedAddPatient.SelectedItem = null;
			this.m_cboBedAddPatient.SelectionStart = -1;
			this.m_cboBedAddPatient.Size = new System.Drawing.Size(120, 23);
			this.m_cboBedAddPatient.TabIndex = 100;
			this.m_cboBedAddPatient.TextBackColor = System.Drawing.Color.White;
			this.m_cboBedAddPatient.TextForeColor = System.Drawing.Color.Black;
			this.m_cboBedAddPatient.DropDown += new System.EventHandler(this.m_cboBedAddPatient_DropDown_1);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(234, 41);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(56, 19);
			this.label18.TabIndex = 30;
			this.label18.Text = "病床名:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lblBedBedID
			// 
			this.m_lblBedBedID.Location = new System.Drawing.Point(118, 41);
			this.m_lblBedBedID.Name = "m_lblBedBedID";
			this.m_lblBedBedID.Size = new System.Drawing.Size(100, 19);
			this.m_lblBedBedID.TabIndex = 10;
			this.m_lblBedBedID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(50, 41);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 19);
			this.label16.TabIndex = 28;
			this.label16.Text = "病床ID:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtBedBedName
			// 
			this.m_txtBedBedName.BackColor = System.Drawing.Color.White;
			this.m_txtBedBedName.ForeColor = System.Drawing.Color.Black;
			this.m_txtBedBedName.Location = new System.Drawing.Point(310, 39);
			this.m_txtBedBedName.Name = "m_txtBedBedName";
			this.m_txtBedBedName.Size = new System.Drawing.Size(96, 23);
			this.m_txtBedBedName.TabIndex = 20;
			this.m_txtBedBedName.Text = "";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(50, 89);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(84, 19);
			this.label15.TabIndex = 18;
			this.label15.Text = "此床分配给:";
			// 
			// m_cmdBedRename
			// 
			this.m_cmdBedRename.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdBedRename.DefaultScheme = true;
			this.m_cmdBedRename.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdBedRename.ForeColor = System.Drawing.Color.Black;
			this.m_cmdBedRename.Hint = "";
			this.m_cmdBedRename.Location = new System.Drawing.Point(418, 34);
			this.m_cmdBedRename.Name = "m_cmdBedRename";
			this.m_cmdBedRename.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdBedRename.Size = new System.Drawing.Size(76, 32);
			this.m_cmdBedRename.TabIndex = 10000001;
			this.m_cmdBedRename.Text = "重命名";
			this.m_cmdBedRename.Click += new System.EventHandler(this.m_cmdBedRename_Click);
			// 
			// m_cmdBedApplyBedToPatient
			// 
			this.m_cmdBedApplyBedToPatient.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdBedApplyBedToPatient.DefaultScheme = true;
			this.m_cmdBedApplyBedToPatient.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdBedApplyBedToPatient.ForeColor = System.Drawing.Color.Black;
			this.m_cmdBedApplyBedToPatient.Hint = "";
			this.m_cmdBedApplyBedToPatient.Location = new System.Drawing.Point(274, 82);
			this.m_cmdBedApplyBedToPatient.Name = "m_cmdBedApplyBedToPatient";
			this.m_cmdBedApplyBedToPatient.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdBedApplyBedToPatient.Size = new System.Drawing.Size(76, 32);
			this.m_cmdBedApplyBedToPatient.TabIndex = 10000001;
			this.m_cmdBedApplyBedToPatient.Text = "应 用";
			this.m_cmdBedApplyBedToPatient.Click += new System.EventHandler(this.m_cmdBedApplyBedToPatient_Click);
			// 
			// m_cmdBedDeleteBed
			// 
			this.m_cmdBedDeleteBed.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdBedDeleteBed.DefaultScheme = true;
			this.m_cmdBedDeleteBed.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdBedDeleteBed.ForeColor = System.Drawing.Color.Black;
			this.m_cmdBedDeleteBed.Hint = "";
			this.m_cmdBedDeleteBed.Location = new System.Drawing.Point(358, 82);
			this.m_cmdBedDeleteBed.Name = "m_cmdBedDeleteBed";
			this.m_cmdBedDeleteBed.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdBedDeleteBed.Size = new System.Drawing.Size(104, 32);
			this.m_cmdBedDeleteBed.TabIndex = 10000001;
			this.m_cmdBedDeleteBed.Text = "删除此病床";
			this.m_cmdBedDeleteBed.Click += new System.EventHandler(this.m_cmdBedDeleteBed_Click);
			// 
			// m_pnlDept
			// 
			this.m_pnlDept.Controls.Add(this.m_cmdDeptDeptDelete);
			this.m_pnlDept.Controls.Add(this.m_cmdDeptDeptInfo);
			this.m_pnlDept.Controls.Add(this.tabControl1);
			this.m_pnlDept.Controls.Add(this.m_lblDeptDeptName);
			this.m_pnlDept.Controls.Add(this.m_lblDeptDeptID);
			this.m_pnlDept.Controls.Add(this.label17);
			this.m_pnlDept.Controls.Add(this.label4);
			this.m_pnlDept.Location = new System.Drawing.Point(8, 8);
			this.m_pnlDept.Name = "m_pnlDept";
			this.m_pnlDept.Size = new System.Drawing.Size(544, 148);
			this.m_pnlDept.TabIndex = 29221;
			// 
			// m_cmdDeptDeptDelete
			// 
			this.m_cmdDeptDeptDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDeptDeptDelete.DefaultScheme = true;
			this.m_cmdDeptDeptDelete.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDeptDeptDelete.ForeColor = System.Drawing.Color.Black;
			this.m_cmdDeptDeptDelete.Hint = "";
			this.m_cmdDeptDeptDelete.Location = new System.Drawing.Point(412, 40);
			this.m_cmdDeptDeptDelete.Name = "m_cmdDeptDeptDelete";
			this.m_cmdDeptDeptDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDeptDeptDelete.Size = new System.Drawing.Size(116, 32);
			this.m_cmdDeptDeptDelete.TabIndex = 10000001;
			this.m_cmdDeptDeptDelete.Text = "删除本科室";
			this.m_cmdDeptDeptDelete.Click += new System.EventHandler(this.m_cmdDeptDeptDelete_Click);
			// 
			// m_cmdDeptDeptInfo
			// 
			this.m_cmdDeptDeptInfo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDeptDeptInfo.DefaultScheme = true;
			this.m_cmdDeptDeptInfo.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDeptDeptInfo.ForeColor = System.Drawing.Color.Black;
			this.m_cmdDeptDeptInfo.Hint = "";
			this.m_cmdDeptDeptInfo.Location = new System.Drawing.Point(412, 8);
			this.m_cmdDeptDeptInfo.Name = "m_cmdDeptDeptInfo";
			this.m_cmdDeptDeptInfo.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDeptDeptInfo.Size = new System.Drawing.Size(116, 32);
			this.m_cmdDeptDeptInfo.TabIndex = 10000001;
			this.m_cmdDeptDeptInfo.Text = "科室基本资料";
			this.m_cmdDeptDeptInfo.Click += new System.EventHandler(this.m_cmdDeptDeptInfo_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.m_tbpDeptAddArea);
			this.tabControl1.Controls.Add(this.m_tbpDeptAddEmployee);
			this.tabControl1.Location = new System.Drawing.Point(8, 72);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(520, 72);
			this.tabControl1.TabIndex = 6030;
			// 
			// m_tbpDeptAddArea
			// 
			this.m_tbpDeptAddArea.BackColor = System.Drawing.SystemColors.Control;
			this.m_tbpDeptAddArea.Controls.Add(this.m_txtDeptNewAreaName);
			this.m_tbpDeptAddArea.Controls.Add(this.label6);
			this.m_tbpDeptAddArea.Controls.Add(this.m_txtDeptNewAreaID);
			this.m_tbpDeptAddArea.Controls.Add(this.label7);
			this.m_tbpDeptAddArea.Controls.Add(this.m_cmdDeptAddArea);
			this.m_tbpDeptAddArea.Location = new System.Drawing.Point(4, 23);
			this.m_tbpDeptAddArea.Name = "m_tbpDeptAddArea";
			this.m_tbpDeptAddArea.Size = new System.Drawing.Size(512, 45);
			this.m_tbpDeptAddArea.TabIndex = 0;
			this.m_tbpDeptAddArea.Text = "添加病区";
			// 
			// m_txtDeptNewAreaName
			// 
			this.m_txtDeptNewAreaName.BackColor = System.Drawing.Color.White;
			this.m_txtDeptNewAreaName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDeptNewAreaName.ForeColor = System.Drawing.Color.Black;
			this.m_txtDeptNewAreaName.Location = new System.Drawing.Point(284, 14);
			this.m_txtDeptNewAreaName.Name = "m_txtDeptNewAreaName";
			this.m_txtDeptNewAreaName.Size = new System.Drawing.Size(108, 23);
			this.m_txtDeptNewAreaName.TabIndex = 110;
			this.m_txtDeptNewAreaName.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.SystemColors.Control;
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(12, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 19);
			this.label6.TabIndex = 12;
			this.label6.Text = "新病区ID:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtDeptNewAreaID
			// 
			this.m_txtDeptNewAreaID.BackColor = System.Drawing.Color.White;
			this.m_txtDeptNewAreaID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDeptNewAreaID.ForeColor = System.Drawing.Color.Black;
			this.m_txtDeptNewAreaID.Location = new System.Drawing.Point(92, 14);
			this.m_txtDeptNewAreaID.Name = "m_txtDeptNewAreaID";
			this.m_txtDeptNewAreaID.TabIndex = 100;
			this.m_txtDeptNewAreaID.Text = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.SystemColors.Control;
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(208, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 19);
			this.label7.TabIndex = 13;
			this.label7.Text = "新病区名:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cmdDeptAddArea
			// 
			this.m_cmdDeptAddArea.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDeptAddArea.DefaultScheme = true;
			this.m_cmdDeptAddArea.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDeptAddArea.ForeColor = System.Drawing.Color.Black;
			this.m_cmdDeptAddArea.Hint = "";
			this.m_cmdDeptAddArea.Location = new System.Drawing.Point(412, 11);
			this.m_cmdDeptAddArea.Name = "m_cmdDeptAddArea";
			this.m_cmdDeptAddArea.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDeptAddArea.Size = new System.Drawing.Size(68, 28);
			this.m_cmdDeptAddArea.TabIndex = 10000001;
			this.m_cmdDeptAddArea.Text = "添加";
			this.m_cmdDeptAddArea.Click += new System.EventHandler(this.m_cmdDeptAddArea_Click);
			// 
			// m_tbpDeptAddEmployee
			// 
			this.m_tbpDeptAddEmployee.BackColor = System.Drawing.SystemColors.Control;
			this.m_tbpDeptAddEmployee.Controls.Add(this.m_cmdDeptTbp2AddEmployee);
			this.m_tbpDeptAddEmployee.Controls.Add(this.label40);
			this.m_tbpDeptAddEmployee.Controls.Add(this.m_txtDeptAddEmployeeName);
			this.m_tbpDeptAddEmployee.Controls.Add(this.label39);
			this.m_tbpDeptAddEmployee.Controls.Add(this.m_txtDeptAddEmployeeID);
			this.m_tbpDeptAddEmployee.Location = new System.Drawing.Point(4, 23);
			this.m_tbpDeptAddEmployee.Name = "m_tbpDeptAddEmployee";
			this.m_tbpDeptAddEmployee.Size = new System.Drawing.Size(512, 45);
			this.m_tbpDeptAddEmployee.TabIndex = 1;
			this.m_tbpDeptAddEmployee.Text = "调入员工";
			this.m_tbpDeptAddEmployee.Visible = false;
			// 
			// m_cmdDeptTbp2AddEmployee
			// 
			this.m_cmdDeptTbp2AddEmployee.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDeptTbp2AddEmployee.DefaultScheme = true;
			this.m_cmdDeptTbp2AddEmployee.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDeptTbp2AddEmployee.ForeColor = System.Drawing.Color.Black;
			this.m_cmdDeptTbp2AddEmployee.Hint = "";
			this.m_cmdDeptTbp2AddEmployee.Location = new System.Drawing.Point(432, 8);
			this.m_cmdDeptTbp2AddEmployee.Name = "m_cmdDeptTbp2AddEmployee";
			this.m_cmdDeptTbp2AddEmployee.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDeptTbp2AddEmployee.Size = new System.Drawing.Size(68, 28);
			this.m_cmdDeptTbp2AddEmployee.TabIndex = 10000002;
			this.m_cmdDeptTbp2AddEmployee.Text = "添 加";
			this.m_cmdDeptTbp2AddEmployee.Click += new System.EventHandler(this.m_cmdDeptTbp2AddEmployee_Click);
			// 
			// label40
			// 
			this.label40.BackColor = System.Drawing.SystemColors.Control;
			this.label40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label40.ForeColor = System.Drawing.Color.Black;
			this.label40.Location = new System.Drawing.Point(224, 12);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(80, 23);
			this.label40.TabIndex = 29181;
			this.label40.Text = "员工姓名:";
			// 
			// m_txtDeptAddEmployeeName
			// 
			this.m_txtDeptAddEmployeeName.BackColor = System.Drawing.Color.White;
			this.m_txtDeptAddEmployeeName.BorderColor = System.Drawing.Color.White;
			this.m_txtDeptAddEmployeeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDeptAddEmployeeName.ForeColor = System.Drawing.Color.Black;
			this.m_txtDeptAddEmployeeName.Location = new System.Drawing.Point(312, 8);
			this.m_txtDeptAddEmployeeName.Name = "m_txtDeptAddEmployeeName";
			this.m_txtDeptAddEmployeeName.Size = new System.Drawing.Size(104, 23);
			this.m_txtDeptAddEmployeeName.TabIndex = 110;
			this.m_txtDeptAddEmployeeName.Text = "";
			// 
			// label39
			// 
			this.label39.BackColor = System.Drawing.SystemColors.Control;
			this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label39.ForeColor = System.Drawing.Color.Black;
			this.label39.Location = new System.Drawing.Point(28, 12);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(72, 23);
			this.label39.TabIndex = 29179;
			this.label39.Text = "员工ID:";
			this.label39.Visible = false;
			// 
			// m_txtDeptAddEmployeeID
			// 
			this.m_txtDeptAddEmployeeID.BackColor = System.Drawing.Color.White;
			this.m_txtDeptAddEmployeeID.BorderColor = System.Drawing.Color.White;
			this.m_txtDeptAddEmployeeID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDeptAddEmployeeID.ForeColor = System.Drawing.Color.Black;
			this.m_txtDeptAddEmployeeID.Location = new System.Drawing.Point(108, 8);
			this.m_txtDeptAddEmployeeID.Name = "m_txtDeptAddEmployeeID";
			this.m_txtDeptAddEmployeeID.Size = new System.Drawing.Size(104, 23);
			this.m_txtDeptAddEmployeeID.TabIndex = 100;
			this.m_txtDeptAddEmployeeID.Text = "";
			this.m_txtDeptAddEmployeeID.Visible = false;
			// 
			// m_lblDeptDeptName
			// 
			this.m_lblDeptDeptName.Location = new System.Drawing.Point(252, 40);
			this.m_lblDeptDeptName.Name = "m_lblDeptDeptName";
			this.m_lblDeptDeptName.Size = new System.Drawing.Size(132, 19);
			this.m_lblDeptDeptName.TabIndex = 1;
			// 
			// m_lblDeptDeptID
			// 
			this.m_lblDeptDeptID.Location = new System.Drawing.Point(84, 40);
			this.m_lblDeptDeptID.Name = "m_lblDeptDeptID";
			this.m_lblDeptDeptID.Size = new System.Drawing.Size(88, 19);
			this.m_lblDeptDeptID.TabIndex = 13;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(16, 40);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(56, 19);
			this.label17.TabIndex = 12;
			this.label17.Text = "科室ID:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(184, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "科室名:";
			// 
			// m_lblZCInf
			// 
			this.m_lblZCInf.AutoSize = true;
			this.m_lblZCInf.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblZCInf.Location = new System.Drawing.Point(96, 168);
			this.m_lblZCInf.Name = "m_lblZCInf";
			this.m_lblZCInf.Size = new System.Drawing.Size(0, 17);
			this.m_lblZCInf.TabIndex = 29226;
			// 
			// m_lsvDeptTbp2EmployeeID
			// 
			this.m_lsvDeptTbp2EmployeeID.BackColor = System.Drawing.Color.White;
			this.m_lsvDeptTbp2EmployeeID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									  this.columnHeader15,
																									  this.columnHeader16});
			this.m_lsvDeptTbp2EmployeeID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvDeptTbp2EmployeeID.ForeColor = System.Drawing.Color.Black;
			this.m_lsvDeptTbp2EmployeeID.FullRowSelect = true;
			this.m_lsvDeptTbp2EmployeeID.GridLines = true;
			this.m_lsvDeptTbp2EmployeeID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvDeptTbp2EmployeeID.Location = new System.Drawing.Point(8, 156);
			this.m_lsvDeptTbp2EmployeeID.MultiSelect = false;
			this.m_lsvDeptTbp2EmployeeID.Name = "m_lsvDeptTbp2EmployeeID";
			this.m_lsvDeptTbp2EmployeeID.Size = new System.Drawing.Size(164, 104);
			this.m_lsvDeptTbp2EmployeeID.TabIndex = 6081;
			this.m_lsvDeptTbp2EmployeeID.View = System.Windows.Forms.View.Details;
			this.m_lsvDeptTbp2EmployeeID.Visible = false;
			this.m_lsvDeptTbp2EmployeeID.DoubleClick += new System.EventHandler(this.m_lsvDeptTbp2EmployeeID_DoubleClick);
			// 
			// columnHeader15
			// 
			this.columnHeader15.Width = 80;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Width = 80;
			// 
			// m_pnlPatient
			// 
			this.m_pnlPatient.AutoScroll = true;
			this.m_pnlPatient.Controls.Add(this.m_cboPatientBedName);
			this.m_pnlPatient.Controls.Add(this.m_cboPatientBedArea);
			this.m_pnlPatient.Controls.Add(this.m_cboPatientBedDept);
			this.m_pnlPatient.Controls.Add(this.m_cboPatientBedStatus);
			this.m_pnlPatient.Controls.Add(this.m_lblPatientPatientID);
			this.m_pnlPatient.Controls.Add(this.label21);
			this.m_pnlPatient.Controls.Add(this.label14);
			this.m_pnlPatient.Controls.Add(this.label13);
			this.m_pnlPatient.Controls.Add(this.label12);
			this.m_pnlPatient.Controls.Add(this.label10);
			this.m_pnlPatient.Controls.Add(this.m_lblPatientPatientName);
			this.m_pnlPatient.Controls.Add(this.label8);
			this.m_pnlPatient.Controls.Add(this.m_cmdPatientPatientInfo);
			this.m_pnlPatient.Controls.Add(this.m_cmdPatientChangeBed);
			this.m_pnlPatient.Location = new System.Drawing.Point(8, 8);
			this.m_pnlPatient.Name = "m_pnlPatient";
			this.m_pnlPatient.Size = new System.Drawing.Size(544, 148);
			this.m_pnlPatient.TabIndex = 29223;
			// 
			// m_cboPatientBedName
			// 
			this.m_cboPatientBedName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedName.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboPatientBedName.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedName.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedName.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedName.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedName.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedName.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedName.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedName.Location = new System.Drawing.Point(368, 72);
			this.m_cboPatientBedName.m_BlnEnableItemEventMenu = true;
			this.m_cboPatientBedName.Name = "m_cboPatientBedName";
			this.m_cboPatientBedName.SelectedIndex = -1;
			this.m_cboPatientBedName.SelectedItem = null;
			this.m_cboPatientBedName.SelectionStart = -1;
			this.m_cboPatientBedName.Size = new System.Drawing.Size(72, 23);
			this.m_cboPatientBedName.TabIndex = 130;
			this.m_cboPatientBedName.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedName.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName.Visible = false;
			this.m_cboPatientBedName.DropDown += new System.EventHandler(this.m_cboPatientBedName_DropDown);
			// 
			// m_cboPatientBedArea
			// 
			this.m_cboPatientBedArea.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedArea.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboPatientBedArea.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedArea.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedArea.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedArea.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedArea.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedArea.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedArea.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedArea.Location = new System.Drawing.Point(92, 72);
			this.m_cboPatientBedArea.m_BlnEnableItemEventMenu = true;
			this.m_cboPatientBedArea.Name = "m_cboPatientBedArea";
			this.m_cboPatientBedArea.SelectedIndex = -1;
			this.m_cboPatientBedArea.SelectedItem = null;
			this.m_cboPatientBedArea.SelectionStart = -1;
			this.m_cboPatientBedArea.Size = new System.Drawing.Size(152, 23);
			this.m_cboPatientBedArea.TabIndex = 120;
			this.m_cboPatientBedArea.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedArea.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea.Visible = false;
			this.m_cboPatientBedArea.DropDown += new System.EventHandler(this.m_cboPatientBedArea_DropDown_1);
			this.m_cboPatientBedArea.SelectedIndexChanged += new System.EventHandler(this.m_cboPatientBedArea_SelectedIndexChanged);
			// 
			// m_cboPatientBedDept
			// 
			this.m_cboPatientBedDept.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedDept.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboPatientBedDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedDept.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedDept.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedDept.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedDept.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedDept.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedDept.Location = new System.Drawing.Point(368, 44);
			this.m_cboPatientBedDept.m_BlnEnableItemEventMenu = true;
			this.m_cboPatientBedDept.Name = "m_cboPatientBedDept";
			this.m_cboPatientBedDept.SelectedIndex = -1;
			this.m_cboPatientBedDept.SelectedItem = null;
			this.m_cboPatientBedDept.SelectionStart = -1;
			this.m_cboPatientBedDept.Size = new System.Drawing.Size(148, 23);
			this.m_cboPatientBedDept.TabIndex = 110;
			this.m_cboPatientBedDept.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedDept.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept.Visible = false;
			this.m_cboPatientBedDept.DropDown += new System.EventHandler(this.m_cboPatientBedDept_DropDown_1);
			this.m_cboPatientBedDept.SelectedIndexChanged += new System.EventHandler(this.m_cboPatientBedDept_SelectedIndexChanged);
			// 
			// m_cboPatientBedStatus
			// 
			this.m_cboPatientBedStatus.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedStatus.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedStatus.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboPatientBedStatus.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedStatus.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedStatus.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedStatus.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedStatus.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedStatus.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedStatus.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedStatus.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedStatus.Location = new System.Drawing.Point(92, 40);
			this.m_cboPatientBedStatus.m_BlnEnableItemEventMenu = true;
			this.m_cboPatientBedStatus.Name = "m_cboPatientBedStatus";
			this.m_cboPatientBedStatus.SelectedIndex = -1;
			this.m_cboPatientBedStatus.SelectedItem = null;
			this.m_cboPatientBedStatus.SelectionStart = -1;
			this.m_cboPatientBedStatus.Size = new System.Drawing.Size(72, 23);
			this.m_cboPatientBedStatus.TabIndex = 100;
			this.m_cboPatientBedStatus.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedStatus.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedStatus.SelectedIndexChanged += new System.EventHandler(this.m_cboPatientBedStatus_SelectedIndexChanged);
			// 
			// m_lblPatientPatientID
			// 
			this.m_lblPatientPatientID.Location = new System.Drawing.Point(92, 16);
			this.m_lblPatientPatientID.Name = "m_lblPatientPatientID";
			this.m_lblPatientPatientID.Size = new System.Drawing.Size(100, 19);
			this.m_lblPatientPatientID.TabIndex = 17;
			this.m_lblPatientPatientID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(28, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(56, 19);
			this.label21.TabIndex = 16;
			this.label21.Text = "病人ID:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(288, 76);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(41, 19);
			this.label14.TabIndex = 6;
			this.label14.Text = "病床:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label14.Visible = false;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(28, 76);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(41, 19);
			this.label13.TabIndex = 5;
			this.label13.Text = "病区:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label13.Visible = false;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(288, 48);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(41, 19);
			this.label12.TabIndex = 4;
			this.label12.Text = "科室:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label12.Visible = false;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(28, 44);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 19);
			this.label10.TabIndex = 3;
			this.label10.Text = "状态:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lblPatientPatientName
			// 
			this.m_lblPatientPatientName.AutoSize = true;
			this.m_lblPatientPatientName.Location = new System.Drawing.Point(368, 16);
			this.m_lblPatientPatientName.Name = "m_lblPatientPatientName";
			this.m_lblPatientPatientName.Size = new System.Drawing.Size(48, 19);
			this.m_lblPatientPatientName.TabIndex = 2;
			this.m_lblPatientPatientName.Text = "王三金";
			this.m_lblPatientPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(288, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 19);
			this.label8.TabIndex = 0;
			this.label8.Text = "病人姓名:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cmdPatientPatientInfo
			// 
			this.m_cmdPatientPatientInfo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdPatientPatientInfo.DefaultScheme = true;
			this.m_cmdPatientPatientInfo.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdPatientPatientInfo.ForeColor = System.Drawing.Color.Black;
			this.m_cmdPatientPatientInfo.Hint = "";
			this.m_cmdPatientPatientInfo.Location = new System.Drawing.Point(88, 100);
			this.m_cmdPatientPatientInfo.Name = "m_cmdPatientPatientInfo";
			this.m_cmdPatientPatientInfo.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdPatientPatientInfo.Size = new System.Drawing.Size(120, 32);
			this.m_cmdPatientPatientInfo.TabIndex = 10000001;
			this.m_cmdPatientPatientInfo.Text = "病人基本信息";
			this.m_cmdPatientPatientInfo.Click += new System.EventHandler(this.m_cmdPatientPatientInfo_Click);
			// 
			// m_cmdPatientChangeBed
			// 
			this.m_cmdPatientChangeBed.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdPatientChangeBed.DefaultScheme = true;
			this.m_cmdPatientChangeBed.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdPatientChangeBed.ForeColor = System.Drawing.Color.Black;
			this.m_cmdPatientChangeBed.Hint = "";
			this.m_cmdPatientChangeBed.Location = new System.Drawing.Point(288, 100);
			this.m_cmdPatientChangeBed.Name = "m_cmdPatientChangeBed";
			this.m_cmdPatientChangeBed.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdPatientChangeBed.Size = new System.Drawing.Size(120, 32);
			this.m_cmdPatientChangeBed.TabIndex = 10000001;
			this.m_cmdPatientChangeBed.Text = "更新病床分配";
			this.m_cmdPatientChangeBed.Click += new System.EventHandler(this.m_cmdPatientChangeBed_Click);
			// 
			// m_pnlEmployee
			// 
			this.m_pnlEmployee.Controls.Add(this.label22);
			this.m_pnlEmployee.Controls.Add(this.m_cmdEmployeeEmployeeInfo);
			this.m_pnlEmployee.Controls.Add(this.m_lstEmployeeTakenDept);
			this.m_pnlEmployee.Controls.Add(this.m_lblEmployeeEmployeeName);
			this.m_pnlEmployee.Controls.Add(this.m_lblEmployeeEmployeeID);
			this.m_pnlEmployee.Controls.Add(this.label5);
			this.m_pnlEmployee.Controls.Add(this.label19);
			this.m_pnlEmployee.Controls.Add(this.m_cboEmployeeDeptName);
			this.m_pnlEmployee.Controls.Add(this.label23);
			this.m_pnlEmployee.Controls.Add(this.m_cmdEmployeeAddArea);
			this.m_pnlEmployee.Controls.Add(this.m_cmdEmployeeDeleteArea);
			this.m_pnlEmployee.Location = new System.Drawing.Point(8, 8);
			this.m_pnlEmployee.Name = "m_pnlEmployee";
			this.m_pnlEmployee.Size = new System.Drawing.Size(544, 148);
			this.m_pnlEmployee.TabIndex = 29224;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(18, 39);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(72, 92);
			this.label22.TabIndex = 5;
			this.label22.Text = "员工负责的科室:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cmdEmployeeEmployeeInfo
			// 
			this.m_cmdEmployeeEmployeeInfo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdEmployeeEmployeeInfo.DefaultScheme = true;
			this.m_cmdEmployeeEmployeeInfo.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdEmployeeEmployeeInfo.ForeColor = System.Drawing.Color.Black;
			this.m_cmdEmployeeEmployeeInfo.Hint = "";
			this.m_cmdEmployeeEmployeeInfo.Location = new System.Drawing.Point(420, 8);
			this.m_cmdEmployeeEmployeeInfo.Name = "m_cmdEmployeeEmployeeInfo";
			this.m_cmdEmployeeEmployeeInfo.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdEmployeeEmployeeInfo.Size = new System.Drawing.Size(108, 36);
			this.m_cmdEmployeeEmployeeInfo.TabIndex = 10000001;
			this.m_cmdEmployeeEmployeeInfo.Text = "员工基本资料";
			this.m_cmdEmployeeEmployeeInfo.Click += new System.EventHandler(this.m_cmdEmployeeEmployeeInfo_Click);
			// 
			// m_lstEmployeeTakenDept
			// 
			this.m_lstEmployeeTakenDept.BackColor = System.Drawing.Color.White;
			this.m_lstEmployeeTakenDept.ForeColor = System.Drawing.Color.Black;
			this.m_lstEmployeeTakenDept.HorizontalScrollbar = true;
			this.m_lstEmployeeTakenDept.ItemHeight = 14;
			this.m_lstEmployeeTakenDept.Location = new System.Drawing.Point(98, 39);
			this.m_lstEmployeeTakenDept.Name = "m_lstEmployeeTakenDept";
			this.m_lstEmployeeTakenDept.Size = new System.Drawing.Size(232, 88);
			this.m_lstEmployeeTakenDept.TabIndex = 110;
			// 
			// m_lblEmployeeEmployeeName
			// 
			this.m_lblEmployeeEmployeeName.Location = new System.Drawing.Point(98, 11);
			this.m_lblEmployeeEmployeeName.Name = "m_lblEmployeeEmployeeName";
			this.m_lblEmployeeEmployeeName.Size = new System.Drawing.Size(92, 19);
			this.m_lblEmployeeEmployeeName.TabIndex = 4;
			this.m_lblEmployeeEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lblEmployeeEmployeeID
			// 
			this.m_lblEmployeeEmployeeID.Location = new System.Drawing.Point(18, 115);
			this.m_lblEmployeeEmployeeID.Name = "m_lblEmployeeEmployeeID";
			this.m_lblEmployeeEmployeeID.Size = new System.Drawing.Size(92, 23);
			this.m_lblEmployeeEmployeeID.TabIndex = 3;
			this.m_lblEmployeeEmployeeID.Visible = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(34, 115);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "员工ID:";
			this.label5.Visible = false;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(18, 11);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(70, 19);
			this.label19.TabIndex = 0;
			this.label19.Text = "员工姓名:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboEmployeeDeptName
			// 
			this.m_cboEmployeeDeptName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboEmployeeDeptName.BorderColor = System.Drawing.Color.Black;
			this.m_cboEmployeeDeptName.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboEmployeeDeptName.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboEmployeeDeptName.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboEmployeeDeptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboEmployeeDeptName.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboEmployeeDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboEmployeeDeptName.ForeColor = System.Drawing.Color.Black;
			this.m_cboEmployeeDeptName.ListBackColor = System.Drawing.Color.White;
			this.m_cboEmployeeDeptName.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboEmployeeDeptName.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboEmployeeDeptName.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboEmployeeDeptName.Location = new System.Drawing.Point(242, 11);
			this.m_cboEmployeeDeptName.m_BlnEnableItemEventMenu = true;
			this.m_cboEmployeeDeptName.Name = "m_cboEmployeeDeptName";
			this.m_cboEmployeeDeptName.SelectedIndex = -1;
			this.m_cboEmployeeDeptName.SelectedItem = null;
			this.m_cboEmployeeDeptName.SelectionStart = -1;
			this.m_cboEmployeeDeptName.Size = new System.Drawing.Size(172, 23);
			this.m_cboEmployeeDeptName.TabIndex = 120;
			this.m_cboEmployeeDeptName.TextBackColor = System.Drawing.Color.White;
			this.m_cboEmployeeDeptName.TextForeColor = System.Drawing.Color.Black;
			this.m_cboEmployeeDeptName.DropDown += new System.EventHandler(this.m_cboEmployeeDeptName_DropDown);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(194, 11);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(41, 19);
			this.label23.TabIndex = 0;
			this.label23.Text = "科室:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cmdEmployeeAddArea
			// 
			this.m_cmdEmployeeAddArea.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdEmployeeAddArea.DefaultScheme = true;
			this.m_cmdEmployeeAddArea.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdEmployeeAddArea.ForeColor = System.Drawing.Color.Black;
			this.m_cmdEmployeeAddArea.Hint = "";
			this.m_cmdEmployeeAddArea.Location = new System.Drawing.Point(334, 39);
			this.m_cmdEmployeeAddArea.Name = "m_cmdEmployeeAddArea";
			this.m_cmdEmployeeAddArea.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdEmployeeAddArea.Size = new System.Drawing.Size(80, 32);
			this.m_cmdEmployeeAddArea.TabIndex = 10000001;
			this.m_cmdEmployeeAddArea.Text = "<<添加";
			this.m_cmdEmployeeAddArea.Click += new System.EventHandler(this.m_cmdEmployeeAddArea_Click);
			// 
			// m_cmdEmployeeDeleteArea
			// 
			this.m_cmdEmployeeDeleteArea.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdEmployeeDeleteArea.DefaultScheme = true;
			this.m_cmdEmployeeDeleteArea.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdEmployeeDeleteArea.ForeColor = System.Drawing.Color.Black;
			this.m_cmdEmployeeDeleteArea.Hint = "";
			this.m_cmdEmployeeDeleteArea.Location = new System.Drawing.Point(334, 95);
			this.m_cmdEmployeeDeleteArea.Name = "m_cmdEmployeeDeleteArea";
			this.m_cmdEmployeeDeleteArea.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdEmployeeDeleteArea.Size = new System.Drawing.Size(80, 32);
			this.m_cmdEmployeeDeleteArea.TabIndex = 10000001;
			this.m_cmdEmployeeDeleteArea.Text = "删 除";
			this.m_cmdEmployeeDeleteArea.Click += new System.EventHandler(this.m_cmdEmployeeDeleteArea_Click);
			// 
			// m_pnlArea
			// 
			this.m_pnlArea.Controls.Add(this.groupBox3);
			this.m_pnlArea.Controls.Add(this.m_lblAreaAreaID);
			this.m_pnlArea.Controls.Add(this.label20);
			this.m_pnlArea.Controls.Add(this.label11);
			this.m_pnlArea.Controls.Add(this.m_txtAreaAreaName);
			this.m_pnlArea.Controls.Add(this.m_cmdAreaApplyName);
			this.m_pnlArea.Controls.Add(this.m_cmdAreaDeleteArea);
			this.m_pnlArea.Location = new System.Drawing.Point(8, 8);
			this.m_pnlArea.Name = "m_pnlArea";
			this.m_pnlArea.Size = new System.Drawing.Size(544, 148);
			this.m_pnlArea.TabIndex = 29220;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.m_cmdAreaAddBed);
			this.groupBox3.Controls.Add(this.label26);
			this.groupBox3.Controls.Add(this.label25);
			this.groupBox3.Controls.Add(this.m_txtAreaNewBedID);
			this.groupBox3.Controls.Add(this.m_txtAreaNewBedName);
			this.groupBox3.Location = new System.Drawing.Point(8, 72);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(360, 60);
			this.groupBox3.TabIndex = 5041;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "添加病床:";
			// 
			// m_cmdAreaAddBed
			// 
			this.m_cmdAreaAddBed.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAreaAddBed.DefaultScheme = true;
			this.m_cmdAreaAddBed.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAreaAddBed.ForeColor = System.Drawing.Color.Black;
			this.m_cmdAreaAddBed.Hint = "";
			this.m_cmdAreaAddBed.Location = new System.Drawing.Point(264, 21);
			this.m_cmdAreaAddBed.Name = "m_cmdAreaAddBed";
			this.m_cmdAreaAddBed.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAreaAddBed.Size = new System.Drawing.Size(76, 32);
			this.m_cmdAreaAddBed.TabIndex = 10000001;
			this.m_cmdAreaAddBed.Text = "添加";
			this.m_cmdAreaAddBed.Click += new System.EventHandler(this.m_cmdAreaAddBed_Click);
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(16, 28);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(70, 19);
			this.label26.TabIndex = 18;
			this.label26.Text = "新病床名:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(408, 31);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(70, 19);
			this.label25.TabIndex = 17;
			this.label25.Text = "新病床ID:";
			this.label25.Visible = false;
			// 
			// m_txtAreaNewBedID
			// 
			this.m_txtAreaNewBedID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtAreaNewBedID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtAreaNewBedID.ForeColor = System.Drawing.Color.White;
			this.m_txtAreaNewBedID.Location = new System.Drawing.Point(496, 31);
			this.m_txtAreaNewBedID.Name = "m_txtAreaNewBedID";
			this.m_txtAreaNewBedID.TabIndex = 100;
			this.m_txtAreaNewBedID.Text = "";
			this.m_txtAreaNewBedID.Visible = false;
			// 
			// m_txtAreaNewBedName
			// 
			this.m_txtAreaNewBedName.BackColor = System.Drawing.Color.White;
			this.m_txtAreaNewBedName.ForeColor = System.Drawing.Color.Black;
			this.m_txtAreaNewBedName.Location = new System.Drawing.Point(104, 26);
			this.m_txtAreaNewBedName.Name = "m_txtAreaNewBedName";
			this.m_txtAreaNewBedName.Size = new System.Drawing.Size(144, 23);
			this.m_txtAreaNewBedName.TabIndex = 110;
			this.m_txtAreaNewBedName.Text = "";
			// 
			// m_lblAreaAreaID
			// 
			this.m_lblAreaAreaID.Location = new System.Drawing.Point(72, 32);
			this.m_lblAreaAreaID.Name = "m_lblAreaAreaID";
			this.m_lblAreaAreaID.Size = new System.Drawing.Size(100, 19);
			this.m_lblAreaAreaID.TabIndex = 10;
			this.m_lblAreaAreaID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(12, 32);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 19);
			this.label20.TabIndex = 15;
			this.label20.Text = "病区ID:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(180, 32);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 19);
			this.label11.TabIndex = 9;
			this.label11.Text = "病区名:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtAreaAreaName
			// 
			this.m_txtAreaAreaName.BackColor = System.Drawing.Color.White;
			this.m_txtAreaAreaName.ForeColor = System.Drawing.Color.Black;
			this.m_txtAreaAreaName.Location = new System.Drawing.Point(252, 30);
			this.m_txtAreaAreaName.Name = "m_txtAreaAreaName";
			this.m_txtAreaAreaName.Size = new System.Drawing.Size(113, 23);
			this.m_txtAreaAreaName.TabIndex = 5020;
			this.m_txtAreaAreaName.Text = "";
			// 
			// m_cmdAreaApplyName
			// 
			this.m_cmdAreaApplyName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAreaApplyName.DefaultScheme = true;
			this.m_cmdAreaApplyName.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAreaApplyName.ForeColor = System.Drawing.Color.Black;
			this.m_cmdAreaApplyName.Hint = "";
			this.m_cmdAreaApplyName.Location = new System.Drawing.Point(384, 25);
			this.m_cmdAreaApplyName.Name = "m_cmdAreaApplyName";
			this.m_cmdAreaApplyName.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAreaApplyName.Size = new System.Drawing.Size(104, 32);
			this.m_cmdAreaApplyName.TabIndex = 10000001;
			this.m_cmdAreaApplyName.Text = "重命名";
			this.m_cmdAreaApplyName.Click += new System.EventHandler(this.m_cmdAreaApplyName_Click);
			// 
			// m_cmdAreaDeleteArea
			// 
			this.m_cmdAreaDeleteArea.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAreaDeleteArea.DefaultScheme = true;
			this.m_cmdAreaDeleteArea.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAreaDeleteArea.ForeColor = System.Drawing.Color.Black;
			this.m_cmdAreaDeleteArea.Hint = "";
			this.m_cmdAreaDeleteArea.Location = new System.Drawing.Point(384, 86);
			this.m_cmdAreaDeleteArea.Name = "m_cmdAreaDeleteArea";
			this.m_cmdAreaDeleteArea.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAreaDeleteArea.Size = new System.Drawing.Size(104, 32);
			this.m_cmdAreaDeleteArea.TabIndex = 10000001;
			this.m_cmdAreaDeleteArea.Text = "删除本病区";
			this.m_cmdAreaDeleteArea.Click += new System.EventHandler(this.m_cmdAreaDeleteArea_Click);
			// 
			// columnHeader10
			// 
			this.columnHeader10.Width = 80;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Width = 80;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Width = 80;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Width = 80;
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "病床";
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "病人";
			// 
			// m_tabQuanYuan
			// 
			this.m_tabQuanYuan.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.m_tabQuanYuan.Controls.Add(this.m_tbpPatient);
			this.m_tabQuanYuan.Controls.Add(this.m_tbpDept);
			this.m_tabQuanYuan.Controls.Add(this.m_tbpEmployee);
			this.m_tabQuanYuan.Controls.Add(this.m_tbpForLeavePatient);
			this.m_tabQuanYuan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tabQuanYuan.Location = new System.Drawing.Point(0, 0);
			this.m_tabQuanYuan.Name = "m_tabQuanYuan";
			this.m_tabQuanYuan.SelectedIndex = 0;
			this.m_tabQuanYuan.Size = new System.Drawing.Size(840, 653);
			this.m_tabQuanYuan.TabIndex = 29219;
			this.m_tabQuanYuan.Visible = false;
			this.m_tabQuanYuan.SelectedIndexChanged += new System.EventHandler(this.m_tabQuanYuan_SelectedIndexChanged);
			// 
			// m_tbpPatient
			// 
			this.m_tbpPatient.AutoScroll = true;
			this.m_tbpPatient.BackColor = System.Drawing.SystemColors.Control;
			this.m_tbpPatient.Controls.Add(this.m_tabData);
			this.m_tbpPatient.Controls.Add(this.m_cmdTbp1OK);
			this.m_tbpPatient.Controls.Add(this.m_cmdTbp1ClearForm);
			this.m_tbpPatient.Controls.Add(this.groupBox1);
			this.m_tbpPatient.Controls.Add(this.m_gpbtbp1Must);
			this.m_tbpPatient.Location = new System.Drawing.Point(4, 26);
			this.m_tbpPatient.Name = "m_tbpPatient";
			this.m_tbpPatient.Size = new System.Drawing.Size(832, 623);
			this.m_tbpPatient.TabIndex = 0;
			this.m_tbpPatient.Text = "病人入院";
			this.m_tbpPatient.Visible = false;
			// 
			// m_tabData
			// 
			this.m_tabData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tabData.Controls.Add(this.m_tbpMust);
			this.m_tabData.Controls.Add(this.m_tbpOther);
			this.m_tabData.Location = new System.Drawing.Point(198, 520);
			this.m_tabData.Multiline = true;
			this.m_tabData.Name = "m_tabData";
			this.m_tabData.SelectedIndex = 0;
			this.m_tabData.Size = new System.Drawing.Size(220, 0);
			this.m_tabData.TabIndex = 29395;
			this.m_tabData.Visible = false;
			// 
			// m_tbpMust
			// 
			this.m_tbpMust.BackColor = System.Drawing.SystemColors.Control;
			this.m_tbpMust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tbpMust.Location = new System.Drawing.Point(4, 61);
			this.m_tbpMust.Name = "m_tbpMust";
			this.m_tbpMust.Size = new System.Drawing.Size(212, 0);
			this.m_tbpMust.TabIndex = 0;
			this.m_tbpMust.Text = "必填资料*";
			// 
			// m_tbpOther
			// 
			this.m_tbpOther.AutoScroll = true;
			this.m_tbpOther.BackColor = System.Drawing.SystemColors.Control;
			this.m_tbpOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tbpOther.Location = new System.Drawing.Point(4, 61);
			this.m_tbpOther.Name = "m_tbpOther";
			this.m_tbpOther.Size = new System.Drawing.Size(212, -65);
			this.m_tbpOther.TabIndex = 1;
			this.m_tbpOther.Text = "基本资料";
			// 
			// m_cmdTbp1OK
			// 
			this.m_cmdTbp1OK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdTbp1OK.DefaultScheme = true;
			this.m_cmdTbp1OK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdTbp1OK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdTbp1OK.Hint = "";
			this.m_cmdTbp1OK.Location = new System.Drawing.Point(32, 518);
			this.m_cmdTbp1OK.Name = "m_cmdTbp1OK";
			this.m_cmdTbp1OK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdTbp1OK.Size = new System.Drawing.Size(68, 26);
			this.m_cmdTbp1OK.TabIndex = 10000002;
			this.m_cmdTbp1OK.Text = "入 院";
			this.m_cmdTbp1OK.Click += new System.EventHandler(this.m_cmdTbp1OK_Click);
			// 
			// m_cmdTbp1ClearForm
			// 
			this.m_cmdTbp1ClearForm.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdTbp1ClearForm.DefaultScheme = true;
			this.m_cmdTbp1ClearForm.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdTbp1ClearForm.ForeColor = System.Drawing.Color.Black;
			this.m_cmdTbp1ClearForm.Hint = "";
			this.m_cmdTbp1ClearForm.Location = new System.Drawing.Point(120, 518);
			this.m_cmdTbp1ClearForm.Name = "m_cmdTbp1ClearForm";
			this.m_cmdTbp1ClearForm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdTbp1ClearForm.Size = new System.Drawing.Size(68, 26);
			this.m_cmdTbp1ClearForm.TabIndex = 10000002;
			this.m_cmdTbp1ClearForm.Text = "清 空";
			this.m_cmdTbp1ClearForm.Click += new System.EventHandler(this.m_cmdTbp1ClearForm_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(286, 520);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(122, 26);
			this.groupBox1.TabIndex = 29405;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "基本资料";
			this.groupBox1.Visible = false;
			// 
			// m_gpbtbp1Must
			// 
			this.m_gpbtbp1Must.Controls.Add(this.panel1);
			this.m_gpbtbp1Must.Controls.Add(this.m_txtAge);
			this.m_gpbtbp1Must.Controls.Add(this.m_dtpInPatientDate);
			this.m_gpbtbp1Must.Controls.Add(this.m_txtTbp1PatientFirstName);
			this.m_gpbtbp1Must.Controls.Add(this.m_lsvTbp1InPatientName);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboTbp1Married);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboPatientBedArea2);
			this.m_gpbtbp1Must.Controls.Add(this.m_txtTbp1HomePhone);
			this.m_gpbtbp1Must.Controls.Add(this.label77);
			this.m_gpbtbp1Must.Controls.Add(this.label75);
			this.m_gpbtbp1Must.Controls.Add(this.label74);
			this.m_gpbtbp1Must.Controls.Add(this.label73);
			this.m_gpbtbp1Must.Controls.Add(this.label72);
			this.m_gpbtbp1Must.Controls.Add(this.m_lsvTbp1InPatientID);
			this.m_gpbtbp1Must.Controls.Add(this.label71);
			this.m_gpbtbp1Must.Controls.Add(this.label70);
			this.m_gpbtbp1Must.Controls.Add(this.label69);
			this.m_gpbtbp1Must.Controls.Add(this.label68);
			this.m_gpbtbp1Must.Controls.Add(this.label66);
			this.m_gpbtbp1Must.Controls.Add(this.label65);
			this.m_gpbtbp1Must.Controls.Add(this.label64);
			this.m_gpbtbp1Must.Controls.Add(this.label63);
			this.m_gpbtbp1Must.Controls.Add(this.label62);
			this.m_gpbtbp1Must.Controls.Add(this.label61);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboPatientBedDept2);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboTbp1Sex);
			this.m_gpbtbp1Must.Controls.Add(this.m_numTbp1Times);
			this.m_gpbtbp1Must.Controls.Add(this.label41);
			this.m_gpbtbp1Must.Controls.Add(this.m_dtpTbp1Birth);
			this.m_gpbtbp1Must.Controls.Add(this.lblNameTitle);
			this.m_gpbtbp1Must.Controls.Add(this.lblSexTitle);
			this.m_gpbtbp1Must.Controls.Add(this.lblMarriedTitle);
			this.m_gpbtbp1Must.Controls.Add(this.label1);
			this.m_gpbtbp1Must.Controls.Add(this.label59);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboPatientBedName2);
			this.m_gpbtbp1Must.Controls.Add(this.label58);
			this.m_gpbtbp1Must.Controls.Add(this.label2);
			this.m_gpbtbp1Must.Controls.Add(this.label60);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboTbp1Nation);
			this.m_gpbtbp1Must.Controls.Add(this.lblOccupation);
			this.m_gpbtbp1Must.Controls.Add(this.lblHomePhoneTitle);
			this.m_gpbtbp1Must.Controls.Add(this.m_chkTbp1IsOldPatient);
			this.m_gpbtbp1Must.Controls.Add(this.lblHomeplace);
			this.m_gpbtbp1Must.Controls.Add(this.lblHomeAddressTitle);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboTbp1Home_district);
			this.m_gpbtbp1Must.Controls.Add(this.lblLinkMan);
			this.m_gpbtbp1Must.Controls.Add(this.m_txtTbp1LinkMan);
			this.m_gpbtbp1Must.Controls.Add(this.lblInPatientIDTitle);
			this.m_gpbtbp1Must.Controls.Add(this.label67);
			this.m_gpbtbp1Must.Controls.Add(this.m_txtTbp1InPatientID);
			this.m_gpbtbp1Must.Controls.Add(this.lblNation);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboTbp1Occupation);
			this.m_gpbtbp1Must.Controls.Add(this.label76);
			this.m_gpbtbp1Must.Controls.Add(this.label80);
			this.m_gpbtbp1Must.Controls.Add(this.m_cboTbp1NativePlace);
			this.m_gpbtbp1Must.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_gpbtbp1Must.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_gpbtbp1Must.Location = new System.Drawing.Point(0, 0);
			this.m_gpbtbp1Must.Name = "m_gpbtbp1Must";
			this.m_gpbtbp1Must.Size = new System.Drawing.Size(832, 514);
			this.m_gpbtbp1Must.TabIndex = 29394;
			this.m_gpbtbp1Must.TabStop = false;
			this.m_gpbtbp1Must.Text = "病人资料（以   号结尾的输入项必须详细填写）";
			this.m_gpbtbp1Must.Enter += new System.EventHandler(this.m_gpbtbp1Must_Enter);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label53);
			this.panel1.Controls.Add(this.label56);
			this.panel1.Controls.Add(this.m_txtTbp1LinkManPhone);
			this.panel1.Controls.Add(this.m_txtTbp1OfficePhone);
			this.panel1.Controls.Add(this.lblLinkManAddress);
			this.panel1.Controls.Add(this.m_cboTbp1Office_district);
			this.panel1.Controls.Add(this.label46);
			this.panel1.Controls.Add(this.m_txtTbp1Office_street);
			this.panel1.Controls.Add(this.label47);
			this.panel1.Controls.Add(this.label48);
			this.panel1.Controls.Add(this.m_txtTbp1OfficeName);
			this.panel1.Controls.Add(this.m_cboTbp1Nationality);
			this.panel1.Controls.Add(this.lblOfficePhoneTitle);
			this.panel1.Controls.Add(this.lblHomePCTitle);
			this.panel1.Controls.Add(this.lblOfficePCTitle);
			this.panel1.Controls.Add(this.lblIDCardTitle);
			this.panel1.Controls.Add(this.label44);
			this.panel1.Controls.Add(this.lblNationality);
			this.panel1.Controls.Add(this.label43);
			this.panel1.Controls.Add(this.m_txtTbp1Hic_no);
			this.panel1.Controls.Add(this.lblPatientRelation);
			this.panel1.Controls.Add(this.m_txtTbp1PatientID);
			this.panel1.Controls.Add(this.lblLinkManPhone);
			this.panel1.Controls.Add(this.lblChargeCategory);
			this.panel1.Controls.Add(this.m_cboTbp1ChargeCategory);
			this.panel1.Controls.Add(this.m_txtTbp1OfficePC);
			this.panel1.Controls.Add(this.label45);
			this.panel1.Controls.Add(this.m_txtTbp1HomePC);
			this.panel1.Controls.Add(this.m_cboTbp1PaymentPercent);
			this.panel1.Controls.Add(this.m_txtTbp1IDCard);
			this.panel1.Controls.Add(this.m_cboTbp1LinkManRelation);
			this.panel1.Controls.Add(this.m_cboTbp1Admiss_status);
			this.panel1.Controls.Add(this.m_txtTbp1LinkManPC);
			this.panel1.Controls.Add(this.m_cboTbp1Visit_type);
			this.panel1.Controls.Add(this.label55);
			this.panel1.Controls.Add(this.label57);
			this.panel1.Controls.Add(this.m_cboTbp1vip_code);
			this.panel1.Controls.Add(this.label42);
			this.panel1.Controls.Add(this.m_cboTbp1Insurance);
			this.panel1.Controls.Add(this.m_cboTbp1LinkMan_district);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label49);
			this.panel1.Controls.Add(this.label51);
			this.panel1.Controls.Add(this.m_txtTbp1Home_street);
			this.panel1.Controls.Add(this.label52);
			this.panel1.Controls.Add(this.m_txtTbp1TempPhone);
			this.panel1.Controls.Add(this.label50);
			this.panel1.Controls.Add(this.label54);
			this.panel1.Controls.Add(this.m_txtTbp1temp_zipcode);
			this.panel1.Controls.Add(this.m_txtTbp1Temp_street);
			this.panel1.Controls.Add(this.m_txtTbp1LinkMan_street);
			this.panel1.Controls.Add(this.m_cboTbp1Temp_district);
			this.panel1.Controls.Add(this.label81);
			this.panel1.Controls.Add(this.m_cboTbp1BornPlace);
			this.panel1.Location = new System.Drawing.Point(4, 178);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(642, 332);
			this.panel1.TabIndex = 29561;
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.BackColor = System.Drawing.SystemColors.Control;
			this.label53.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label53.ForeColor = System.Drawing.Color.Black;
			this.label53.Location = new System.Drawing.Point(26, 226);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(70, 19);
			this.label53.TabIndex = 29542;
			this.label53.Text = "临时地址:";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label53.Click += new System.EventHandler(this.label53_Click);
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.BackColor = System.Drawing.SystemColors.Control;
			this.label56.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label56.ForeColor = System.Drawing.Color.Black;
			this.label56.Location = new System.Drawing.Point(54, 310);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(41, 19);
			this.label56.TabIndex = 29550;
			this.label56.Text = "访问:";
			this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtTbp1LinkManPhone
			// 
			this.m_txtTbp1LinkManPhone.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1LinkManPhone.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1LinkManPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1LinkManPhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1LinkManPhone.Location = new System.Drawing.Point(100, 166);
			this.m_txtTbp1LinkManPhone.Name = "m_txtTbp1LinkManPhone";
			this.m_txtTbp1LinkManPhone.Size = new System.Drawing.Size(106, 23);
			this.m_txtTbp1LinkManPhone.TabIndex = 320;
			this.m_txtTbp1LinkManPhone.Text = "";
			this.m_txtTbp1LinkManPhone.TextChanged += new System.EventHandler(this.m_txtTbp1LinkManPhone_TextChanged);
			// 
			// m_txtTbp1OfficePhone
			// 
			this.m_txtTbp1OfficePhone.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1OfficePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1OfficePhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1OfficePhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1OfficePhone.Location = new System.Drawing.Point(304, 110);
			this.m_txtTbp1OfficePhone.Name = "m_txtTbp1OfficePhone";
			this.m_txtTbp1OfficePhone.Size = new System.Drawing.Size(106, 23);
			this.m_txtTbp1OfficePhone.TabIndex = 280;
			this.m_txtTbp1OfficePhone.Text = "";
			this.m_txtTbp1OfficePhone.TextChanged += new System.EventHandler(this.m_txtTbp1OfficePhone_TextChanged);
			// 
			// lblLinkManAddress
			// 
			this.lblLinkManAddress.AutoSize = true;
			this.lblLinkManAddress.BackColor = System.Drawing.SystemColors.Control;
			this.lblLinkManAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLinkManAddress.ForeColor = System.Drawing.Color.Black;
			this.lblLinkManAddress.Location = new System.Drawing.Point(26, 282);
			this.lblLinkManAddress.Name = "lblLinkManAddress";
			this.lblLinkManAddress.Size = new System.Drawing.Size(70, 19);
			this.lblLinkManAddress.TabIndex = 29546;
			this.lblLinkManAddress.Text = "保险公司:";
			this.lblLinkManAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboTbp1Office_district
			// 
			this.m_cboTbp1Office_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Office_district.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Office_district.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Office_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Office_district.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Office_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Office_district.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Office_district.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Office_district.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Office_district.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Office_district.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Office_district.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Office_district.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Office_district.Location = new System.Drawing.Point(304, 138);
			this.m_cboTbp1Office_district.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Office_district.Name = "m_cboTbp1Office_district";
			this.m_cboTbp1Office_district.SelectedIndex = -1;
			this.m_cboTbp1Office_district.SelectedItem = null;
			this.m_cboTbp1Office_district.SelectionStart = 0;
			this.m_cboTbp1Office_district.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1Office_district.TabIndex = 310;
			this.m_cboTbp1Office_district.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Office_district.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Office_district.Load += new System.EventHandler(this.m_cboTbp1Office_district_Load);
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.BackColor = System.Drawing.SystemColors.Control;
			this.label46.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label46.ForeColor = System.Drawing.Color.Black;
			this.label46.Location = new System.Drawing.Point(26, 142);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(70, 19);
			this.label46.TabIndex = 29536;
			this.label46.Text = "单位街道:";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label46.Click += new System.EventHandler(this.label46_Click);
			// 
			// m_txtTbp1Office_street
			// 
			this.m_txtTbp1Office_street.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1Office_street.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1Office_street.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1Office_street.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1Office_street.Location = new System.Drawing.Point(100, 138);
			this.m_txtTbp1Office_street.MaxLength = 16;
			this.m_txtTbp1Office_street.Name = "m_txtTbp1Office_street";
			this.m_txtTbp1Office_street.Size = new System.Drawing.Size(106, 23);
			this.m_txtTbp1Office_street.TabIndex = 300;
			this.m_txtTbp1Office_street.Text = "";
			this.m_txtTbp1Office_street.TextChanged += new System.EventHandler(this.m_txtTbp1Office_street_TextChanged);
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.BackColor = System.Drawing.SystemColors.Control;
			this.label47.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label47.ForeColor = System.Drawing.Color.Black;
			this.label47.Location = new System.Drawing.Point(257, 142);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(41, 19);
			this.label47.TabIndex = 29531;
			this.label47.Text = "省市:";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label47.Click += new System.EventHandler(this.label47_Click);
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.BackColor = System.Drawing.SystemColors.Control;
			this.label48.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label48.ForeColor = System.Drawing.Color.Black;
			this.label48.Location = new System.Drawing.Point(26, 114);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(70, 19);
			this.label48.TabIndex = 29530;
			this.label48.Text = "工作单位:";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label48.Click += new System.EventHandler(this.label48_Click);
			// 
			// m_txtTbp1OfficeName
			// 
			this.m_txtTbp1OfficeName.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1OfficeName.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1OfficeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1OfficeName.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1OfficeName.Location = new System.Drawing.Point(100, 110);
			this.m_txtTbp1OfficeName.MaxLength = 16;
			this.m_txtTbp1OfficeName.Name = "m_txtTbp1OfficeName";
			this.m_txtTbp1OfficeName.Size = new System.Drawing.Size(106, 23);
			this.m_txtTbp1OfficeName.TabIndex = 270;
			this.m_txtTbp1OfficeName.Text = "";
			this.m_txtTbp1OfficeName.TextChanged += new System.EventHandler(this.m_txtTbp1OfficeName_TextChanged);
			// 
			// m_cboTbp1Nationality
			// 
			this.m_cboTbp1Nationality.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Nationality.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Nationality.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Nationality.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Nationality.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Nationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Nationality.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Nationality.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Nationality.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Nationality.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Nationality.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Nationality.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Nationality.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Nationality.Location = new System.Drawing.Point(100, 56);
			this.m_cboTbp1Nationality.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Nationality.Name = "m_cboTbp1Nationality";
			this.m_cboTbp1Nationality.SelectedIndex = -1;
			this.m_cboTbp1Nationality.SelectedItem = null;
			this.m_cboTbp1Nationality.SelectionStart = 0;
			this.m_cboTbp1Nationality.Size = new System.Drawing.Size(108, 23);
			this.m_cboTbp1Nationality.TabIndex = 230;
			this.m_cboTbp1Nationality.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Nationality.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Nationality.Load += new System.EventHandler(this.m_cboTbp1Nationality_Load);
			// 
			// lblOfficePhoneTitle
			// 
			this.lblOfficePhoneTitle.AutoSize = true;
			this.lblOfficePhoneTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblOfficePhoneTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePhoneTitle.ForeColor = System.Drawing.Color.Black;
			this.lblOfficePhoneTitle.Location = new System.Drawing.Point(228, 114);
			this.lblOfficePhoneTitle.Name = "lblOfficePhoneTitle";
			this.lblOfficePhoneTitle.Size = new System.Drawing.Size(70, 19);
			this.lblOfficePhoneTitle.TabIndex = 29518;
			this.lblOfficePhoneTitle.Text = "办公电话:";
			this.lblOfficePhoneTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblOfficePhoneTitle.Click += new System.EventHandler(this.lblOfficePhoneTitle_Click);
			// 
			// lblHomePCTitle
			// 
			this.lblHomePCTitle.AutoSize = true;
			this.lblHomePCTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblHomePCTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePCTitle.ForeColor = System.Drawing.Color.Black;
			this.lblHomePCTitle.Location = new System.Drawing.Point(444, 58);
			this.lblHomePCTitle.Name = "lblHomePCTitle";
			this.lblHomePCTitle.Size = new System.Drawing.Size(41, 19);
			this.lblHomePCTitle.TabIndex = 29515;
			this.lblHomePCTitle.Text = "邮编:";
			this.lblHomePCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblHomePCTitle.Click += new System.EventHandler(this.lblHomePCTitle_Click);
			// 
			// lblOfficePCTitle
			// 
			this.lblOfficePCTitle.AutoSize = true;
			this.lblOfficePCTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblOfficePCTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOfficePCTitle.ForeColor = System.Drawing.Color.Black;
			this.lblOfficePCTitle.Location = new System.Drawing.Point(444, 114);
			this.lblOfficePCTitle.Name = "lblOfficePCTitle";
			this.lblOfficePCTitle.Size = new System.Drawing.Size(41, 19);
			this.lblOfficePCTitle.TabIndex = 29516;
			this.lblOfficePCTitle.Text = "邮编:";
			this.lblOfficePCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblOfficePCTitle.Click += new System.EventHandler(this.lblOfficePCTitle_Click);
			// 
			// lblIDCardTitle
			// 
			this.lblIDCardTitle.AutoSize = true;
			this.lblIDCardTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblIDCardTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblIDCardTitle.ForeColor = System.Drawing.Color.Black;
			this.lblIDCardTitle.Location = new System.Drawing.Point(428, 36);
			this.lblIDCardTitle.Name = "lblIDCardTitle";
			this.lblIDCardTitle.Size = new System.Drawing.Size(70, 19);
			this.lblIDCardTitle.TabIndex = 29514;
			this.lblIDCardTitle.Text = "身份证号:";
			this.lblIDCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblIDCardTitle.Click += new System.EventHandler(this.lblIDCardTitle_Click);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.BackColor = System.Drawing.SystemColors.Control;
			this.label44.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label44.ForeColor = System.Drawing.Color.Black;
			this.label44.Location = new System.Drawing.Point(26, 4);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(70, 19);
			this.label44.TabIndex = 29556;
			this.label44.Text = "病人编号:";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label44.Click += new System.EventHandler(this.label44_Click);
			// 
			// lblNationality
			// 
			this.lblNationality.AutoSize = true;
			this.lblNationality.BackColor = System.Drawing.SystemColors.Control;
			this.lblNationality.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNationality.ForeColor = System.Drawing.Color.Black;
			this.lblNationality.Location = new System.Drawing.Point(54, 60);
			this.lblNationality.Name = "lblNationality";
			this.lblNationality.Size = new System.Drawing.Size(41, 19);
			this.lblNationality.TabIndex = 29507;
			this.lblNationality.Text = "国籍:";
			this.lblNationality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblNationality.Click += new System.EventHandler(this.lblNationality_Click);
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.BackColor = System.Drawing.SystemColors.Control;
			this.label43.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label43.ForeColor = System.Drawing.Color.Black;
			this.label43.Location = new System.Drawing.Point(40, 32);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(56, 19);
			this.label43.TabIndex = 29558;
			this.label43.Text = "医疗证:";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label43.Click += new System.EventHandler(this.label43_Click);
			// 
			// m_txtTbp1Hic_no
			// 
			this.m_txtTbp1Hic_no.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1Hic_no.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1Hic_no.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1Hic_no.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1Hic_no.Location = new System.Drawing.Point(100, 28);
			this.m_txtTbp1Hic_no.MaxLength = 10;
			this.m_txtTbp1Hic_no.Name = "m_txtTbp1Hic_no";
			this.m_txtTbp1Hic_no.Size = new System.Drawing.Size(108, 23);
			this.m_txtTbp1Hic_no.TabIndex = 200;
			this.m_txtTbp1Hic_no.Text = "";
			this.m_txtTbp1Hic_no.TextChanged += new System.EventHandler(this.m_txtTbp1Hic_no_TextChanged);
			// 
			// lblPatientRelation
			// 
			this.lblPatientRelation.AutoSize = true;
			this.lblPatientRelation.BackColor = System.Drawing.SystemColors.Control;
			this.lblPatientRelation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPatientRelation.ForeColor = System.Drawing.Color.Black;
			this.lblPatientRelation.Location = new System.Drawing.Point(257, 170);
			this.lblPatientRelation.Name = "lblPatientRelation";
			this.lblPatientRelation.Size = new System.Drawing.Size(41, 19);
			this.lblPatientRelation.TabIndex = 29513;
			this.lblPatientRelation.Text = "关系:";
			this.lblPatientRelation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblPatientRelation.Click += new System.EventHandler(this.lblPatientRelation_Click);
			// 
			// m_txtTbp1PatientID
			// 
			this.m_txtTbp1PatientID.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1PatientID.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1PatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1PatientID.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1PatientID.Location = new System.Drawing.Point(100, 0);
			this.m_txtTbp1PatientID.MaxLength = 12;
			this.m_txtTbp1PatientID.Name = "m_txtTbp1PatientID";
			this.m_txtTbp1PatientID.Size = new System.Drawing.Size(108, 23);
			this.m_txtTbp1PatientID.TabIndex = 170;
			this.m_txtTbp1PatientID.Text = "";
			this.m_txtTbp1PatientID.TextChanged += new System.EventHandler(this.m_txtTbp1PatientID_TextChanged);
			// 
			// lblLinkManPhone
			// 
			this.lblLinkManPhone.AutoSize = true;
			this.lblLinkManPhone.BackColor = System.Drawing.SystemColors.Control;
			this.lblLinkManPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLinkManPhone.ForeColor = System.Drawing.Color.Black;
			this.lblLinkManPhone.Location = new System.Drawing.Point(12, 170);
			this.lblLinkManPhone.Name = "lblLinkManPhone";
			this.lblLinkManPhone.Size = new System.Drawing.Size(84, 19);
			this.lblLinkManPhone.TabIndex = 29511;
			this.lblLinkManPhone.Text = "联系人电话:";
			this.lblLinkManPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLinkManPhone.Click += new System.EventHandler(this.lblLinkManPhone_Click);
			// 
			// lblChargeCategory
			// 
			this.lblChargeCategory.AutoSize = true;
			this.lblChargeCategory.BackColor = System.Drawing.SystemColors.Control;
			this.lblChargeCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblChargeCategory.ForeColor = System.Drawing.Color.Black;
			this.lblChargeCategory.Location = new System.Drawing.Point(428, 8);
			this.lblChargeCategory.Name = "lblChargeCategory";
			this.lblChargeCategory.Size = new System.Drawing.Size(70, 19);
			this.lblChargeCategory.TabIndex = 29554;
			this.lblChargeCategory.Text = "收费种类:";
			this.lblChargeCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblChargeCategory.Click += new System.EventHandler(this.lblChargeCategory_Click);
			// 
			// m_cboTbp1ChargeCategory
			// 
			this.m_cboTbp1ChargeCategory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1ChargeCategory.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1ChargeCategory.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1ChargeCategory.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1ChargeCategory.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1ChargeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTbp1ChargeCategory.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1ChargeCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1ChargeCategory.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1ChargeCategory.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1ChargeCategory.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1ChargeCategory.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1ChargeCategory.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1ChargeCategory.Location = new System.Drawing.Point(502, 4);
			this.m_cboTbp1ChargeCategory.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1ChargeCategory.Name = "m_cboTbp1ChargeCategory";
			this.m_cboTbp1ChargeCategory.SelectedIndex = -1;
			this.m_cboTbp1ChargeCategory.SelectedItem = null;
			this.m_cboTbp1ChargeCategory.SelectionStart = -1;
			this.m_cboTbp1ChargeCategory.Size = new System.Drawing.Size(94, 23);
			this.m_cboTbp1ChargeCategory.TabIndex = 190;
			this.m_cboTbp1ChargeCategory.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1ChargeCategory.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1ChargeCategory.Load += new System.EventHandler(this.m_cboTbp1ChargeCategory_Load);
			// 
			// m_txtTbp1OfficePC
			// 
			this.m_txtTbp1OfficePC.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1OfficePC.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1OfficePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1OfficePC.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1OfficePC.Location = new System.Drawing.Point(490, 110);
			this.m_txtTbp1OfficePC.MaxLength = 6;
			this.m_txtTbp1OfficePC.Name = "m_txtTbp1OfficePC";
			this.m_txtTbp1OfficePC.Size = new System.Drawing.Size(106, 23);
			this.m_txtTbp1OfficePC.TabIndex = 290;
			this.m_txtTbp1OfficePC.Text = "";
			this.m_txtTbp1OfficePC.TextChanged += new System.EventHandler(this.m_txtTbp1OfficePC_TextChanged);
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.BackColor = System.Drawing.SystemColors.Control;
			this.label45.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label45.ForeColor = System.Drawing.Color.Black;
			this.label45.Location = new System.Drawing.Point(257, 32);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(41, 19);
			this.label45.TabIndex = 29559;
			this.label45.Text = "比例:";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label45.Click += new System.EventHandler(this.label45_Click);
			// 
			// m_txtTbp1HomePC
			// 
			this.m_txtTbp1HomePC.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1HomePC.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1HomePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1HomePC.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1HomePC.Location = new System.Drawing.Point(490, 58);
			this.m_txtTbp1HomePC.MaxLength = 6;
			this.m_txtTbp1HomePC.Name = "m_txtTbp1HomePC";
			this.m_txtTbp1HomePC.Size = new System.Drawing.Size(106, 23);
			this.m_txtTbp1HomePC.TabIndex = 250;
			this.m_txtTbp1HomePC.Text = "";
			this.m_txtTbp1HomePC.TextChanged += new System.EventHandler(this.m_txtTbp1HomePC_TextChanged);
			// 
			// m_cboTbp1PaymentPercent
			// 
			this.m_cboTbp1PaymentPercent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1PaymentPercent.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1PaymentPercent.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1PaymentPercent.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1PaymentPercent.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1PaymentPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1PaymentPercent.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1PaymentPercent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1PaymentPercent.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1PaymentPercent.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1PaymentPercent.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1PaymentPercent.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1PaymentPercent.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1PaymentPercent.Location = new System.Drawing.Point(304, 32);
			this.m_cboTbp1PaymentPercent.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1PaymentPercent.Name = "m_cboTbp1PaymentPercent";
			this.m_cboTbp1PaymentPercent.SelectedIndex = -1;
			this.m_cboTbp1PaymentPercent.SelectedItem = null;
			this.m_cboTbp1PaymentPercent.SelectionStart = 0;
			this.m_cboTbp1PaymentPercent.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1PaymentPercent.TabIndex = 210;
			this.m_cboTbp1PaymentPercent.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1PaymentPercent.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1PaymentPercent.Load += new System.EventHandler(this.m_cboTbp1PaymentPercent_Load);
			// 
			// m_txtTbp1IDCard
			// 
			this.m_txtTbp1IDCard.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1IDCard.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1IDCard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1IDCard.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1IDCard.Location = new System.Drawing.Point(500, 32);
			this.m_txtTbp1IDCard.MaxLength = 18;
			this.m_txtTbp1IDCard.Name = "m_txtTbp1IDCard";
			this.m_txtTbp1IDCard.Size = new System.Drawing.Size(96, 23);
			this.m_txtTbp1IDCard.TabIndex = 220;
			this.m_txtTbp1IDCard.Text = "";
			this.m_txtTbp1IDCard.TextChanged += new System.EventHandler(this.m_txtTbp1IDCard_TextChanged);
			// 
			// m_cboTbp1LinkManRelation
			// 
			this.m_cboTbp1LinkManRelation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1LinkManRelation.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1LinkManRelation.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1LinkManRelation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1LinkManRelation.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1LinkManRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1LinkManRelation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1LinkManRelation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1LinkManRelation.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1LinkManRelation.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1LinkManRelation.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1LinkManRelation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1LinkManRelation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1LinkManRelation.Location = new System.Drawing.Point(304, 166);
			this.m_cboTbp1LinkManRelation.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1LinkManRelation.Name = "m_cboTbp1LinkManRelation";
			this.m_cboTbp1LinkManRelation.SelectedIndex = -1;
			this.m_cboTbp1LinkManRelation.SelectedItem = null;
			this.m_cboTbp1LinkManRelation.SelectionStart = 0;
			this.m_cboTbp1LinkManRelation.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1LinkManRelation.TabIndex = 330;
			this.m_cboTbp1LinkManRelation.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1LinkManRelation.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1LinkManRelation.Load += new System.EventHandler(this.m_cboTbp1LinkManRelation_Load);
			// 
			// m_cboTbp1Admiss_status
			// 
			this.m_cboTbp1Admiss_status.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Admiss_status.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Admiss_status.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Admiss_status.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Admiss_status.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Admiss_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Admiss_status.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Admiss_status.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Admiss_status.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Admiss_status.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Admiss_status.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Admiss_status.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Admiss_status.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Admiss_status.Location = new System.Drawing.Point(490, 280);
			this.m_cboTbp1Admiss_status.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Admiss_status.Name = "m_cboTbp1Admiss_status";
			this.m_cboTbp1Admiss_status.SelectedIndex = -1;
			this.m_cboTbp1Admiss_status.SelectedItem = null;
			this.m_cboTbp1Admiss_status.SelectionStart = 0;
			this.m_cboTbp1Admiss_status.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1Admiss_status.TabIndex = 420;
			this.m_cboTbp1Admiss_status.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Admiss_status.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtTbp1LinkManPC
			// 
			this.m_txtTbp1LinkManPC.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1LinkManPC.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1LinkManPC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1LinkManPC.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1LinkManPC.Location = new System.Drawing.Point(490, 166);
			this.m_txtTbp1LinkManPC.MaxLength = 10;
			this.m_txtTbp1LinkManPC.Name = "m_txtTbp1LinkManPC";
			this.m_txtTbp1LinkManPC.Size = new System.Drawing.Size(106, 23);
			this.m_txtTbp1LinkManPC.TabIndex = 340;
			this.m_txtTbp1LinkManPC.Text = "";
			this.m_txtTbp1LinkManPC.TextChanged += new System.EventHandler(this.m_txtTbp1LinkManPC_TextChanged);
			// 
			// m_cboTbp1Visit_type
			// 
			this.m_cboTbp1Visit_type.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Visit_type.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Visit_type.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Visit_type.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Visit_type.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Visit_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Visit_type.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Visit_type.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Visit_type.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Visit_type.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Visit_type.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Visit_type.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Visit_type.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Visit_type.Location = new System.Drawing.Point(100, 306);
			this.m_cboTbp1Visit_type.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Visit_type.Name = "m_cboTbp1Visit_type";
			this.m_cboTbp1Visit_type.SelectedIndex = -1;
			this.m_cboTbp1Visit_type.SelectedItem = null;
			this.m_cboTbp1Visit_type.SelectionStart = 0;
			this.m_cboTbp1Visit_type.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1Visit_type.TabIndex = 430;
			this.m_cboTbp1Visit_type.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Visit_type.TextForeColor = System.Drawing.Color.Black;
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.BackColor = System.Drawing.SystemColors.Control;
			this.label55.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label55.ForeColor = System.Drawing.Color.Black;
			this.label55.Location = new System.Drawing.Point(214, 254);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(84, 19);
			this.label55.TabIndex = 29521;
			this.label55.Text = "临时地址号:";
			this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.BackColor = System.Drawing.SystemColors.Control;
			this.label57.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label57.ForeColor = System.Drawing.Color.Black;
			this.label57.Location = new System.Drawing.Point(442, 282);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(41, 19);
			this.label57.TabIndex = 29548;
			this.label57.Text = "状态:";
			this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboTbp1vip_code
			// 
			this.m_cboTbp1vip_code.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1vip_code.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1vip_code.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1vip_code.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1vip_code.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1vip_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1vip_code.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1vip_code.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1vip_code.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1vip_code.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1vip_code.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1vip_code.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1vip_code.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1vip_code.Location = new System.Drawing.Point(304, 4);
			this.m_cboTbp1vip_code.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1vip_code.Name = "m_cboTbp1vip_code";
			this.m_cboTbp1vip_code.SelectedIndex = -1;
			this.m_cboTbp1vip_code.SelectedItem = null;
			this.m_cboTbp1vip_code.SelectionStart = 0;
			this.m_cboTbp1vip_code.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1vip_code.TabIndex = 180;
			this.m_cboTbp1vip_code.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1vip_code.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1vip_code.Load += new System.EventHandler(this.m_cboTbp1vip_code_Load);
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.BackColor = System.Drawing.SystemColors.Control;
			this.label42.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label42.ForeColor = System.Drawing.Color.Black;
			this.label42.Location = new System.Drawing.Point(242, 6);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(56, 19);
			this.label42.TabIndex = 29525;
			this.label42.Text = "司局级:";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label42.Click += new System.EventHandler(this.label42_Click);
			// 
			// m_cboTbp1Insurance
			// 
			this.m_cboTbp1Insurance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Insurance.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Insurance.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Insurance.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Insurance.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Insurance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Insurance.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Insurance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Insurance.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Insurance.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Insurance.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Insurance.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Insurance.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Insurance.Location = new System.Drawing.Point(100, 278);
			this.m_cboTbp1Insurance.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Insurance.Name = "m_cboTbp1Insurance";
			this.m_cboTbp1Insurance.SelectedIndex = -1;
			this.m_cboTbp1Insurance.SelectedItem = null;
			this.m_cboTbp1Insurance.SelectionStart = 0;
			this.m_cboTbp1Insurance.Size = new System.Drawing.Size(310, 23);
			this.m_cboTbp1Insurance.TabIndex = 410;
			this.m_cboTbp1Insurance.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Insurance.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboTbp1LinkMan_district
			// 
			this.m_cboTbp1LinkMan_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1LinkMan_district.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1LinkMan_district.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1LinkMan_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1LinkMan_district.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1LinkMan_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1LinkMan_district.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1LinkMan_district.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1LinkMan_district.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1LinkMan_district.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1LinkMan_district.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1LinkMan_district.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1LinkMan_district.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1LinkMan_district.Location = new System.Drawing.Point(100, 194);
			this.m_cboTbp1LinkMan_district.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1LinkMan_district.Name = "m_cboTbp1LinkMan_district";
			this.m_cboTbp1LinkMan_district.SelectedIndex = -1;
			this.m_cboTbp1LinkMan_district.SelectedItem = null;
			this.m_cboTbp1LinkMan_district.SelectionStart = 0;
			this.m_cboTbp1LinkMan_district.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1LinkMan_district.TabIndex = 350;
			this.m_cboTbp1LinkMan_district.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1LinkMan_district.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1LinkMan_district.Load += new System.EventHandler(this.m_cboTbp1LinkMan_district_Load);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(26, 198);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 19);
			this.label3.TabIndex = 29532;
			this.label3.Text = "省    市:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.BackColor = System.Drawing.SystemColors.Control;
			this.label49.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label49.ForeColor = System.Drawing.Color.Black;
			this.label49.Location = new System.Drawing.Point(54, 86);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(41, 19);
			this.label49.TabIndex = 29538;
			this.label49.Text = "街道:";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label49.Click += new System.EventHandler(this.label49_Click);
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.BackColor = System.Drawing.SystemColors.Control;
			this.label51.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label51.ForeColor = System.Drawing.Color.Black;
			this.label51.Location = new System.Drawing.Point(444, 170);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(41, 19);
			this.label51.TabIndex = 29517;
			this.label51.Text = "邮编:";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label51.Click += new System.EventHandler(this.label51_Click);
			// 
			// m_txtTbp1Home_street
			// 
			this.m_txtTbp1Home_street.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1Home_street.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1Home_street.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1Home_street.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1Home_street.Location = new System.Drawing.Point(100, 82);
			this.m_txtTbp1Home_street.MaxLength = 16;
			this.m_txtTbp1Home_street.Name = "m_txtTbp1Home_street";
			this.m_txtTbp1Home_street.Size = new System.Drawing.Size(496, 23);
			this.m_txtTbp1Home_street.TabIndex = 260;
			this.m_txtTbp1Home_street.Text = "";
			this.m_txtTbp1Home_street.TextChanged += new System.EventHandler(this.m_txtTbp1Home_street_TextChanged);
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.BackColor = System.Drawing.SystemColors.Control;
			this.label52.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label52.ForeColor = System.Drawing.Color.Black;
			this.label52.Location = new System.Drawing.Point(257, 198);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(41, 19);
			this.label52.TabIndex = 29537;
			this.label52.Text = "街道:";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label52.Click += new System.EventHandler(this.label52_Click);
			// 
			// m_txtTbp1TempPhone
			// 
			this.m_txtTbp1TempPhone.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1TempPhone.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1TempPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1TempPhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1TempPhone.Location = new System.Drawing.Point(100, 250);
			this.m_txtTbp1TempPhone.Name = "m_txtTbp1TempPhone";
			this.m_txtTbp1TempPhone.Size = new System.Drawing.Size(106, 23);
			this.m_txtTbp1TempPhone.TabIndex = 390;
			this.m_txtTbp1TempPhone.Text = "";
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.BackColor = System.Drawing.SystemColors.Control;
			this.label50.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label50.ForeColor = System.Drawing.Color.Black;
			this.label50.Location = new System.Drawing.Point(257, 226);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(41, 19);
			this.label50.TabIndex = 29545;
			this.label50.Text = "街道:";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label50.Click += new System.EventHandler(this.label50_Click);
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.BackColor = System.Drawing.SystemColors.Control;
			this.label54.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label54.ForeColor = System.Drawing.Color.Black;
			this.label54.Location = new System.Drawing.Point(-2, 254);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(99, 19);
			this.label54.TabIndex = 29520;
			this.label54.Text = "临时地址电话:";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtTbp1temp_zipcode
			// 
			this.m_txtTbp1temp_zipcode.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1temp_zipcode.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1temp_zipcode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1temp_zipcode.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1temp_zipcode.Location = new System.Drawing.Point(304, 250);
			this.m_txtTbp1temp_zipcode.Name = "m_txtTbp1temp_zipcode";
			this.m_txtTbp1temp_zipcode.Size = new System.Drawing.Size(292, 23);
			this.m_txtTbp1temp_zipcode.TabIndex = 400;
			this.m_txtTbp1temp_zipcode.Text = "";
			this.m_txtTbp1temp_zipcode.TextChanged += new System.EventHandler(this.m_txtTbp1temp_zipcode_TextChanged);
			// 
			// m_txtTbp1Temp_street
			// 
			this.m_txtTbp1Temp_street.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1Temp_street.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1Temp_street.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1Temp_street.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1Temp_street.Location = new System.Drawing.Point(304, 222);
			this.m_txtTbp1Temp_street.MaxLength = 16;
			this.m_txtTbp1Temp_street.Name = "m_txtTbp1Temp_street";
			this.m_txtTbp1Temp_street.Size = new System.Drawing.Size(292, 23);
			this.m_txtTbp1Temp_street.TabIndex = 380;
			this.m_txtTbp1Temp_street.Text = "";
			this.m_txtTbp1Temp_street.TextChanged += new System.EventHandler(this.m_txtTbp1Temp_street_TextChanged);
			// 
			// m_txtTbp1LinkMan_street
			// 
			this.m_txtTbp1LinkMan_street.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1LinkMan_street.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1LinkMan_street.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1LinkMan_street.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1LinkMan_street.Location = new System.Drawing.Point(304, 194);
			this.m_txtTbp1LinkMan_street.MaxLength = 16;
			this.m_txtTbp1LinkMan_street.Name = "m_txtTbp1LinkMan_street";
			this.m_txtTbp1LinkMan_street.Size = new System.Drawing.Size(292, 23);
			this.m_txtTbp1LinkMan_street.TabIndex = 360;
			this.m_txtTbp1LinkMan_street.Text = "";
			this.m_txtTbp1LinkMan_street.TextChanged += new System.EventHandler(this.m_txtTbp1LinkMan_street_TextChanged);
			// 
			// m_cboTbp1Temp_district
			// 
			this.m_cboTbp1Temp_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Temp_district.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Temp_district.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Temp_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Temp_district.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Temp_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Temp_district.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Temp_district.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Temp_district.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Temp_district.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Temp_district.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Temp_district.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Temp_district.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Temp_district.Location = new System.Drawing.Point(100, 222);
			this.m_cboTbp1Temp_district.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Temp_district.Name = "m_cboTbp1Temp_district";
			this.m_cboTbp1Temp_district.SelectedIndex = -1;
			this.m_cboTbp1Temp_district.SelectedItem = null;
			this.m_cboTbp1Temp_district.SelectionStart = 0;
			this.m_cboTbp1Temp_district.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1Temp_district.TabIndex = 370;
			this.m_cboTbp1Temp_district.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Temp_district.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Temp_district.Load += new System.EventHandler(this.m_cboTbp1Temp_district_Load);
			// 
			// label81
			// 
			this.label81.AutoSize = true;
			this.label81.BackColor = System.Drawing.SystemColors.Control;
			this.label81.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label81.ForeColor = System.Drawing.Color.Black;
			this.label81.Location = new System.Drawing.Point(242, 60);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(56, 19);
			this.label81.TabIndex = 29512;
			this.label81.Text = "出生地:";
			this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboTbp1BornPlace
			// 
			this.m_cboTbp1BornPlace.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1BornPlace.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1BornPlace.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1BornPlace.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1BornPlace.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1BornPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1BornPlace.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1BornPlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1BornPlace.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1BornPlace.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1BornPlace.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1BornPlace.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1BornPlace.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1BornPlace.Location = new System.Drawing.Point(304, 58);
			this.m_cboTbp1BornPlace.m_BlnEnableItemEventMenu = true;
			this.m_cboTbp1BornPlace.Name = "m_cboTbp1BornPlace";
			this.m_cboTbp1BornPlace.SelectedIndex = -1;
			this.m_cboTbp1BornPlace.SelectedItem = null;
			this.m_cboTbp1BornPlace.SelectionStart = 0;
			this.m_cboTbp1BornPlace.Size = new System.Drawing.Size(106, 23);
			this.m_cboTbp1BornPlace.TabIndex = 150;
			this.m_cboTbp1BornPlace.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1BornPlace.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtAge
			// 
			this.m_txtAge.Location = new System.Drawing.Point(104, 102);
			this.m_txtAge.Name = "m_txtAge";
			this.m_txtAge.Size = new System.Drawing.Size(32, 23);
			this.m_txtAge.TabIndex = 80;
			this.m_txtAge.Text = "";
			this.m_txtAge.TextChanged += new System.EventHandler(this.m_txtAge_TextChanged);
			// 
			// m_dtpInPatientDate
			// 
			this.m_dtpInPatientDate.BackColor = System.Drawing.SystemColors.Control;
			this.m_dtpInPatientDate.BorderColor = System.Drawing.Color.Black;
			this.m_dtpInPatientDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpInPatientDate.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_dtpInPatientDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpInPatientDate.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtpInPatientDate.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpInPatientDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpInPatientDate.Location = new System.Drawing.Point(206, 23);
			this.m_dtpInPatientDate.m_BlnOnlyTime = false;
			this.m_dtpInPatientDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpInPatientDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpInPatientDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpInPatientDate.Name = "m_dtpInPatientDate";
			this.m_dtpInPatientDate.ReadOnly = false;
			this.m_dtpInPatientDate.Size = new System.Drawing.Size(212, 22);
			this.m_dtpInPatientDate.TabIndex = 0;
			this.m_dtpInPatientDate.TextBackColor = System.Drawing.Color.White;
			this.m_dtpInPatientDate.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtTbp1PatientFirstName
			// 
			this.m_txtTbp1PatientFirstName.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1PatientFirstName.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1PatientFirstName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1PatientFirstName.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1PatientFirstName.Location = new System.Drawing.Point(308, 74);
			this.m_txtTbp1PatientFirstName.Name = "m_txtTbp1PatientFirstName";
			this.m_txtTbp1PatientFirstName.Size = new System.Drawing.Size(110, 23);
			this.m_txtTbp1PatientFirstName.TabIndex = 60;
			this.m_txtTbp1PatientFirstName.Text = "";
			// 
			// m_lsvTbp1InPatientName
			// 
			this.m_lsvTbp1InPatientName.BackColor = System.Drawing.Color.White;
			this.m_lsvTbp1InPatientName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									 this.columnHeader7,
																									 this.columnHeader8});
			this.m_lsvTbp1InPatientName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvTbp1InPatientName.ForeColor = System.Drawing.Color.Black;
			this.m_lsvTbp1InPatientName.FullRowSelect = true;
			this.m_lsvTbp1InPatientName.GridLines = true;
			this.m_lsvTbp1InPatientName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvTbp1InPatientName.Location = new System.Drawing.Point(310, 98);
			this.m_lsvTbp1InPatientName.MultiSelect = false;
			this.m_lsvTbp1InPatientName.Name = "m_lsvTbp1InPatientName";
			this.m_lsvTbp1InPatientName.Size = new System.Drawing.Size(110, 60);
			this.m_lsvTbp1InPatientName.TabIndex = 31;
			this.m_lsvTbp1InPatientName.View = System.Windows.Forms.View.Details;
			this.m_lsvTbp1InPatientName.Visible = false;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Width = 80;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Width = 80;
			// 
			// m_cboTbp1Married
			// 
			this.m_cboTbp1Married.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Married.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Married.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboTbp1Married.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Married.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Married.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTbp1Married.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Married.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Married.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Married.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Married.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Married.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Married.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Married.Location = new System.Drawing.Point(504, 100);
			this.m_cboTbp1Married.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Married.Name = "m_cboTbp1Married";
			this.m_cboTbp1Married.SelectedIndex = -1;
			this.m_cboTbp1Married.SelectedItem = null;
			this.m_cboTbp1Married.SelectionStart = -1;
			this.m_cboTbp1Married.Size = new System.Drawing.Size(74, 23);
			this.m_cboTbp1Married.TabIndex = 110;
			this.m_cboTbp1Married.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Married.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboPatientBedArea2
			// 
			this.m_cboPatientBedArea2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedArea2.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea2.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboPatientBedArea2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedArea2.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedArea2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedArea2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedArea2.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea2.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedArea2.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedArea2.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedArea2.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedArea2.Location = new System.Drawing.Point(308, 48);
			this.m_cboPatientBedArea2.m_BlnEnableItemEventMenu = true;
			this.m_cboPatientBedArea2.Name = "m_cboPatientBedArea2";
			this.m_cboPatientBedArea2.SelectedIndex = -1;
			this.m_cboPatientBedArea2.SelectedItem = null;
			this.m_cboPatientBedArea2.SelectionStart = -1;
			this.m_cboPatientBedArea2.Size = new System.Drawing.Size(110, 23);
			this.m_cboPatientBedArea2.TabIndex = 30;
			this.m_cboPatientBedArea2.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedArea2.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea2.DropDown += new System.EventHandler(this.m_cboPatientBedArea_DropDown_2);
			this.m_cboPatientBedArea2.SelectedIndexChanged += new System.EventHandler(this.m_cboPatientBedArea2_SelectedIndexChanged);
			// 
			// m_txtTbp1HomePhone
			// 
			this.m_txtTbp1HomePhone.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1HomePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1HomePhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1HomePhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1HomePhone.Location = new System.Drawing.Point(308, 126);
			this.m_txtTbp1HomePhone.Name = "m_txtTbp1HomePhone";
			this.m_txtTbp1HomePhone.Size = new System.Drawing.Size(110, 23);
			this.m_txtTbp1HomePhone.TabIndex = 130;
			this.m_txtTbp1HomePhone.Text = "";
			// 
			// label77
			// 
			this.label77.AutoSize = true;
			this.label77.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label77.ForeColor = System.Drawing.Color.Red;
			this.label77.Location = new System.Drawing.Point(100, 0);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(19, 15);
			this.label77.TabIndex = 29578;
			this.label77.Text = "***";
			// 
			// label75
			// 
			this.label75.AutoSize = true;
			this.label75.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label75.ForeColor = System.Drawing.Color.Red;
			this.label75.Location = new System.Drawing.Point(418, 26);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(19, 15);
			this.label75.TabIndex = 29576;
			this.label75.Text = "***";
			// 
			// label74
			// 
			this.label74.AutoSize = true;
			this.label74.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label74.ForeColor = System.Drawing.Color.Red;
			this.label74.Location = new System.Drawing.Point(418, 130);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(19, 15);
			this.label74.TabIndex = 29575;
			this.label74.Text = "***";
			// 
			// label73
			// 
			this.label73.AutoSize = true;
			this.label73.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label73.ForeColor = System.Drawing.Color.Red;
			this.label73.Location = new System.Drawing.Point(580, 26);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(19, 15);
			this.label73.TabIndex = 29574;
			this.label73.Text = "***";
			// 
			// label72
			// 
			this.label72.AutoSize = true;
			this.label72.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label72.ForeColor = System.Drawing.Color.Red;
			this.label72.Location = new System.Drawing.Point(216, 156);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(19, 15);
			this.label72.TabIndex = 29573;
			this.label72.Text = "***";
			// 
			// m_lsvTbp1InPatientID
			// 
			this.m_lsvTbp1InPatientID.BackColor = System.Drawing.Color.White;
			this.m_lsvTbp1InPatientID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								   this.columnHeader5,
																								   this.columnHeader6});
			this.m_lsvTbp1InPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvTbp1InPatientID.ForeColor = System.Drawing.Color.Black;
			this.m_lsvTbp1InPatientID.FullRowSelect = true;
			this.m_lsvTbp1InPatientID.GridLines = true;
			this.m_lsvTbp1InPatientID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvTbp1InPatientID.Location = new System.Drawing.Point(104, 96);
			this.m_lsvTbp1InPatientID.MultiSelect = false;
			this.m_lsvTbp1InPatientID.Name = "m_lsvTbp1InPatientID";
			this.m_lsvTbp1InPatientID.Size = new System.Drawing.Size(110, 68);
			this.m_lsvTbp1InPatientID.TabIndex = 21;
			this.m_lsvTbp1InPatientID.View = System.Windows.Forms.View.Details;
			this.m_lsvTbp1InPatientID.Visible = false;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Width = 80;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Width = 80;
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label71.ForeColor = System.Drawing.Color.Red;
			this.label71.Location = new System.Drawing.Point(418, 52);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(19, 15);
			this.label71.TabIndex = 29572;
			this.label71.Text = "***";
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label70.ForeColor = System.Drawing.Color.Red;
			this.label70.Location = new System.Drawing.Point(580, 52);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(19, 15);
			this.label70.TabIndex = 29571;
			this.label70.Text = "***";
			// 
			// label69
			// 
			this.label69.AutoSize = true;
			this.label69.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label69.ForeColor = System.Drawing.Color.Red;
			this.label69.Location = new System.Drawing.Point(418, 78);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(19, 15);
			this.label69.TabIndex = 29570;
			this.label69.Text = "***";
			// 
			// label68
			// 
			this.label68.AutoSize = true;
			this.label68.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label68.ForeColor = System.Drawing.Color.Red;
			this.label68.Location = new System.Drawing.Point(216, 52);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(19, 15);
			this.label68.TabIndex = 29569;
			this.label68.Text = "***";
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label66.ForeColor = System.Drawing.Color.Red;
			this.label66.Location = new System.Drawing.Point(216, 130);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(19, 15);
			this.label66.TabIndex = 29567;
			this.label66.Text = "***";
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label65.ForeColor = System.Drawing.Color.Red;
			this.label65.Location = new System.Drawing.Point(580, 104);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(19, 15);
			this.label65.TabIndex = 29566;
			this.label65.Text = "***";
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label64.ForeColor = System.Drawing.Color.Red;
			this.label64.Location = new System.Drawing.Point(580, 130);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(19, 15);
			this.label64.TabIndex = 29565;
			this.label64.Text = "***";
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label63.ForeColor = System.Drawing.Color.Red;
			this.label63.Location = new System.Drawing.Point(580, 78);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(19, 15);
			this.label63.TabIndex = 29564;
			this.label63.Text = "***";
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label62.ForeColor = System.Drawing.Color.Red;
			this.label62.Location = new System.Drawing.Point(580, 156);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(19, 15);
			this.label62.TabIndex = 29563;
			this.label62.Text = "***";
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label61.ForeColor = System.Drawing.Color.Red;
			this.label61.Location = new System.Drawing.Point(296, 106);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(19, 15);
			this.label61.TabIndex = 29562;
			this.label61.Text = "***";
			// 
			// m_cboPatientBedDept2
			// 
			this.m_cboPatientBedDept2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedDept2.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept2.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboPatientBedDept2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedDept2.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedDept2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedDept2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedDept2.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept2.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedDept2.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedDept2.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedDept2.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedDept2.Location = new System.Drawing.Point(104, 48);
			this.m_cboPatientBedDept2.m_BlnEnableItemEventMenu = false;
			this.m_cboPatientBedDept2.Name = "m_cboPatientBedDept2";
			this.m_cboPatientBedDept2.SelectedIndex = -1;
			this.m_cboPatientBedDept2.SelectedItem = null;
			this.m_cboPatientBedDept2.SelectionStart = -1;
			this.m_cboPatientBedDept2.Size = new System.Drawing.Size(110, 23);
			this.m_cboPatientBedDept2.TabIndex = 20;
			this.m_cboPatientBedDept2.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedDept2.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept2.DropDown += new System.EventHandler(this.m_cboPatientBedDept_DropDown_2);
			this.m_cboPatientBedDept2.SelectedIndexChanged += new System.EventHandler(this.m_cboPatientBedDept2_SelectedIndexChanged);
			// 
			// m_cboTbp1Sex
			// 
			this.m_cboTbp1Sex.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Sex.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Sex.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboTbp1Sex.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Sex.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTbp1Sex.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Sex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Sex.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Sex.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Sex.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Sex.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Sex.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Sex.Location = new System.Drawing.Point(504, 74);
			this.m_cboTbp1Sex.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Sex.Name = "m_cboTbp1Sex";
			this.m_cboTbp1Sex.SelectedIndex = -1;
			this.m_cboTbp1Sex.SelectedItem = null;
			this.m_cboTbp1Sex.SelectionStart = -1;
			this.m_cboTbp1Sex.Size = new System.Drawing.Size(74, 23);
			this.m_cboTbp1Sex.TabIndex = 70;
			this.m_cboTbp1Sex.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Sex.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_numTbp1Times
			// 
			this.m_numTbp1Times.BackColor = System.Drawing.Color.White;
			this.m_numTbp1Times.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_numTbp1Times.ForeColor = System.Drawing.Color.Black;
			this.m_numTbp1Times.Location = new System.Drawing.Point(504, 22);
			this.m_numTbp1Times.Name = "m_numTbp1Times";
			this.m_numTbp1Times.Size = new System.Drawing.Size(74, 23);
			this.m_numTbp1Times.TabIndex = 10;
			this.m_numTbp1Times.Value = new System.Decimal(new int[] {
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
			this.label41.Location = new System.Drawing.Point(460, 26);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(41, 19);
			this.label41.TabIndex = 29409;
			this.label41.Text = "次数:";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_dtpTbp1Birth
			// 
			this.m_dtpTbp1Birth.BackColor = System.Drawing.SystemColors.Control;
			this.m_dtpTbp1Birth.BorderColor = System.Drawing.Color.Black;
			this.m_dtpTbp1Birth.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpTbp1Birth.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_dtpTbp1Birth.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpTbp1Birth.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtpTbp1Birth.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpTbp1Birth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpTbp1Birth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpTbp1Birth.Location = new System.Drawing.Point(156, 102);
			this.m_dtpTbp1Birth.m_BlnOnlyTime = false;
			this.m_dtpTbp1Birth.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpTbp1Birth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpTbp1Birth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpTbp1Birth.Name = "m_dtpTbp1Birth";
			this.m_dtpTbp1Birth.ReadOnly = false;
			this.m_dtpTbp1Birth.Size = new System.Drawing.Size(138, 22);
			this.m_dtpTbp1Birth.TabIndex = 90;
			this.m_dtpTbp1Birth.TextBackColor = System.Drawing.Color.White;
			this.m_dtpTbp1Birth.TextForeColor = System.Drawing.Color.Black;
			this.m_dtpTbp1Birth.evtTextChanged += new System.EventHandler(this.m_dtpTbp1Birth_evtTextChanged);
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.AutoSize = true;
			this.lblNameTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNameTitle.ForeColor = System.Drawing.Color.Black;
			this.lblNameTitle.Location = new System.Drawing.Point(262, 78);
			this.lblNameTitle.Name = "lblNameTitle";
			this.lblNameTitle.Size = new System.Drawing.Size(41, 19);
			this.lblNameTitle.TabIndex = 29407;
			this.lblNameTitle.Text = "姓名:";
			this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.AutoSize = true;
			this.lblSexTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblSexTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSexTitle.ForeColor = System.Drawing.Color.Black;
			this.lblSexTitle.Location = new System.Drawing.Point(460, 78);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(41, 19);
			this.lblSexTitle.TabIndex = 29404;
			this.lblSexTitle.Text = "性别:";
			this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMarriedTitle
			// 
			this.lblMarriedTitle.AutoSize = true;
			this.lblMarriedTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblMarriedTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMarriedTitle.ForeColor = System.Drawing.Color.Black;
			this.lblMarriedTitle.Location = new System.Drawing.Point(460, 104);
			this.lblMarriedTitle.Name = "lblMarriedTitle";
			this.lblMarriedTitle.Size = new System.Drawing.Size(41, 19);
			this.lblMarriedTitle.TabIndex = 29405;
			this.lblMarriedTitle.Text = "婚否:";
			this.lblMarriedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(31, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 19);
			this.label1.TabIndex = 29406;
			this.label1.Text = "出生日期:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label59.Location = new System.Drawing.Point(60, 52);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(41, 19);
			this.label59.TabIndex = 29399;
			this.label59.Text = "科室:";
			this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboPatientBedName2
			// 
			this.m_cboPatientBedName2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedName2.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName2.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboPatientBedName2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedName2.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedName2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedName2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedName2.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName2.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedName2.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedName2.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedName2.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedName2.Location = new System.Drawing.Point(504, 48);
			this.m_cboPatientBedName2.m_BlnEnableItemEventMenu = false;
			this.m_cboPatientBedName2.Name = "m_cboPatientBedName2";
			this.m_cboPatientBedName2.SelectedIndex = -1;
			this.m_cboPatientBedName2.SelectedItem = null;
			this.m_cboPatientBedName2.SelectionStart = -1;
			this.m_cboPatientBedName2.Size = new System.Drawing.Size(74, 23);
			this.m_cboPatientBedName2.TabIndex = 40;
			this.m_cboPatientBedName2.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedName2.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName2.DropDown += new System.EventHandler(this.m_cboPatientBedName_DropDown);
			this.m_cboPatientBedName2.SelectedIndexChanged += new System.EventHandler(this.m_cboPatientBedName2_SelectedIndexChanged);
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label58.Location = new System.Drawing.Point(262, 52);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(41, 19);
			this.label58.TabIndex = 29400;
			this.label58.Text = "病区:";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(460, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 19);
			this.label2.TabIndex = 29401;
			this.label2.Text = "病床:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.BackColor = System.Drawing.SystemColors.Control;
			this.label60.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label60.ForeColor = System.Drawing.Color.Black;
			this.label60.Location = new System.Drawing.Point(136, 26);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(70, 19);
			this.label60.TabIndex = 29406;
			this.label60.Text = "入院日期:";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboTbp1Nation
			// 
			this.m_cboTbp1Nation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Nation.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Nation.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Nation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Nation.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Nation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Nation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Nation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Nation.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Nation.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Nation.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Nation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Nation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Nation.Location = new System.Drawing.Point(362, 100);
			this.m_cboTbp1Nation.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Nation.Name = "m_cboTbp1Nation";
			this.m_cboTbp1Nation.SelectedIndex = -1;
			this.m_cboTbp1Nation.SelectedItem = null;
			this.m_cboTbp1Nation.SelectionStart = 0;
			this.m_cboTbp1Nation.Size = new System.Drawing.Size(74, 23);
			this.m_cboTbp1Nation.TabIndex = 100;
			this.m_cboTbp1Nation.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Nation.TextForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Nation.TextChanged += new System.EventHandler(this.m_cboTbp1Nation_TextChanged);
			// 
			// lblOccupation
			// 
			this.lblOccupation.AutoSize = true;
			this.lblOccupation.BackColor = System.Drawing.SystemColors.Control;
			this.lblOccupation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOccupation.ForeColor = System.Drawing.Color.Black;
			this.lblOccupation.Location = new System.Drawing.Point(60, 130);
			this.lblOccupation.Name = "lblOccupation";
			this.lblOccupation.Size = new System.Drawing.Size(41, 19);
			this.lblOccupation.TabIndex = 29509;
			this.lblOccupation.Text = "职业:";
			this.lblOccupation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHomePhoneTitle
			// 
			this.lblHomePhoneTitle.AutoSize = true;
			this.lblHomePhoneTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblHomePhoneTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomePhoneTitle.ForeColor = System.Drawing.Color.Black;
			this.lblHomePhoneTitle.Location = new System.Drawing.Point(233, 130);
			this.lblHomePhoneTitle.Name = "lblHomePhoneTitle";
			this.lblHomePhoneTitle.Size = new System.Drawing.Size(70, 19);
			this.lblHomePhoneTitle.TabIndex = 29522;
			this.lblHomePhoneTitle.Text = "家庭电话:";
			this.lblHomePhoneTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_chkTbp1IsOldPatient
			// 
			this.m_chkTbp1IsOldPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_chkTbp1IsOldPatient.Location = new System.Drawing.Point(8, 26);
			this.m_chkTbp1IsOldPatient.Name = "m_chkTbp1IsOldPatient";
			this.m_chkTbp1IsOldPatient.Size = new System.Drawing.Size(96, 24);
			this.m_chkTbp1IsOldPatient.TabIndex = 29398;
			this.m_chkTbp1IsOldPatient.Text = "旧病人入院";
			this.m_chkTbp1IsOldPatient.CheckedChanged += new System.EventHandler(this.m_chkTbp1IsOldPatient_CheckedChanged);
			// 
			// lblHomeplace
			// 
			this.lblHomeplace.AutoSize = true;
			this.lblHomeplace.BackColor = System.Drawing.SystemColors.Control;
			this.lblHomeplace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomeplace.ForeColor = System.Drawing.Color.Black;
			this.lblHomeplace.Location = new System.Drawing.Point(60, 156);
			this.lblHomeplace.Name = "lblHomeplace";
			this.lblHomeplace.Size = new System.Drawing.Size(41, 19);
			this.lblHomeplace.TabIndex = 29512;
			this.lblHomeplace.Text = "籍贯:";
			this.lblHomeplace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHomeAddressTitle
			// 
			this.lblHomeAddressTitle.AutoSize = true;
			this.lblHomeAddressTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblHomeAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHomeAddressTitle.ForeColor = System.Drawing.Color.Black;
			this.lblHomeAddressTitle.Location = new System.Drawing.Point(262, 156);
			this.lblHomeAddressTitle.Name = "lblHomeAddressTitle";
			this.lblHomeAddressTitle.Size = new System.Drawing.Size(41, 19);
			this.lblHomeAddressTitle.TabIndex = 29519;
			this.lblHomeAddressTitle.Text = "地址:";
			this.lblHomeAddressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboTbp1Home_district
			// 
			this.m_cboTbp1Home_district.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Home_district.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Home_district.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Home_district.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Home_district.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Home_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Home_district.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Home_district.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Home_district.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Home_district.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Home_district.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Home_district.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Home_district.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Home_district.Location = new System.Drawing.Point(308, 152);
			this.m_cboTbp1Home_district.m_BlnEnableItemEventMenu = false;
			this.m_cboTbp1Home_district.Name = "m_cboTbp1Home_district";
			this.m_cboTbp1Home_district.SelectedIndex = -1;
			this.m_cboTbp1Home_district.SelectedItem = null;
			this.m_cboTbp1Home_district.SelectionStart = 0;
			this.m_cboTbp1Home_district.Size = new System.Drawing.Size(270, 23);
			this.m_cboTbp1Home_district.TabIndex = 160;
			this.m_cboTbp1Home_district.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Home_district.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblLinkMan
			// 
			this.lblLinkMan.AutoSize = true;
			this.lblLinkMan.BackColor = System.Drawing.SystemColors.Control;
			this.lblLinkMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLinkMan.ForeColor = System.Drawing.Color.Black;
			this.lblLinkMan.Location = new System.Drawing.Point(445, 130);
			this.lblLinkMan.Name = "lblLinkMan";
			this.lblLinkMan.Size = new System.Drawing.Size(56, 19);
			this.lblLinkMan.TabIndex = 29510;
			this.lblLinkMan.Text = "联系人:";
			this.lblLinkMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLinkMan.Click += new System.EventHandler(this.lblLinkMan_Click);
			// 
			// m_txtTbp1LinkMan
			// 
			this.m_txtTbp1LinkMan.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1LinkMan.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1LinkMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1LinkMan.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1LinkMan.Location = new System.Drawing.Point(504, 126);
			this.m_txtTbp1LinkMan.Name = "m_txtTbp1LinkMan";
			this.m_txtTbp1LinkMan.Size = new System.Drawing.Size(74, 23);
			this.m_txtTbp1LinkMan.TabIndex = 140;
			this.m_txtTbp1LinkMan.Text = "";
			this.m_txtTbp1LinkMan.TextChanged += new System.EventHandler(this.m_txtTbp1LinkMan_TextChanged);
			// 
			// lblInPatientIDTitle
			// 
			this.lblInPatientIDTitle.AutoSize = true;
			this.lblInPatientIDTitle.BackColor = System.Drawing.SystemColors.Control;
			this.lblInPatientIDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInPatientIDTitle.ForeColor = System.Drawing.Color.Black;
			this.lblInPatientIDTitle.Location = new System.Drawing.Point(45, 78);
			this.lblInPatientIDTitle.Name = "lblInPatientIDTitle";
			this.lblInPatientIDTitle.Size = new System.Drawing.Size(56, 19);
			this.lblInPatientIDTitle.TabIndex = 29408;
			this.lblInPatientIDTitle.Text = "住院号:";
			this.lblInPatientIDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label67
			// 
			this.label67.AutoSize = true;
			this.label67.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label67.ForeColor = System.Drawing.Color.Red;
			this.label67.Location = new System.Drawing.Point(216, 78);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(19, 15);
			this.label67.TabIndex = 29568;
			this.label67.Text = "***";
			// 
			// m_txtTbp1InPatientID
			// 
			this.m_txtTbp1InPatientID.BackColor = System.Drawing.Color.White;
			this.m_txtTbp1InPatientID.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp1InPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp1InPatientID.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp1InPatientID.Location = new System.Drawing.Point(104, 74);
			this.m_txtTbp1InPatientID.Name = "m_txtTbp1InPatientID";
			this.m_txtTbp1InPatientID.Size = new System.Drawing.Size(110, 23);
			this.m_txtTbp1InPatientID.TabIndex = 50;
			this.m_txtTbp1InPatientID.Text = "";
			this.m_txtTbp1InPatientID.TextChanged += new System.EventHandler(this.m_txtTbp1InPatientID_TextChanged);
			// 
			// lblNation
			// 
			this.lblNation.AutoSize = true;
			this.lblNation.BackColor = System.Drawing.SystemColors.Control;
			this.lblNation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNation.ForeColor = System.Drawing.Color.Black;
			this.lblNation.Location = new System.Drawing.Point(318, 102);
			this.lblNation.Name = "lblNation";
			this.lblNation.Size = new System.Drawing.Size(41, 19);
			this.lblNation.TabIndex = 29508;
			this.lblNation.Text = "民族:";
			this.lblNation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboTbp1Occupation
			// 
			this.m_cboTbp1Occupation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1Occupation.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1Occupation.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1Occupation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1Occupation.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Occupation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1Occupation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Occupation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1Occupation.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1Occupation.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Occupation.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1Occupation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1Occupation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1Occupation.Location = new System.Drawing.Point(104, 126);
			this.m_cboTbp1Occupation.m_BlnEnableItemEventMenu = true;
			this.m_cboTbp1Occupation.Name = "m_cboTbp1Occupation";
			this.m_cboTbp1Occupation.SelectedIndex = -1;
			this.m_cboTbp1Occupation.SelectedItem = null;
			this.m_cboTbp1Occupation.SelectionStart = 0;
			this.m_cboTbp1Occupation.Size = new System.Drawing.Size(110, 23);
			this.m_cboTbp1Occupation.TabIndex = 120;
			this.m_cboTbp1Occupation.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1Occupation.TextForeColor = System.Drawing.Color.Black;
			// 
			// label76
			// 
			this.label76.AutoSize = true;
			this.label76.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label76.ForeColor = System.Drawing.Color.Red;
			this.label76.Location = new System.Drawing.Point(438, 106);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(19, 15);
			this.label76.TabIndex = 29577;
			this.label76.Text = "***";
			// 
			// label80
			// 
			this.label80.AutoSize = true;
			this.label80.BackColor = System.Drawing.SystemColors.Control;
			this.label80.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label80.ForeColor = System.Drawing.Color.Black;
			this.label80.Location = new System.Drawing.Point(136, 104);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(20, 19);
			this.label80.TabIndex = 29516;
			this.label80.Text = "岁";
			this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboTbp1NativePlace
			// 
			this.m_cboTbp1NativePlace.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp1NativePlace.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp1NativePlace.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp1NativePlace.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp1NativePlace.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1NativePlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboTbp1NativePlace.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1NativePlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp1NativePlace.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp1NativePlace.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp1NativePlace.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp1NativePlace.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp1NativePlace.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp1NativePlace.Location = new System.Drawing.Point(104, 154);
			this.m_cboTbp1NativePlace.m_BlnEnableItemEventMenu = true;
			this.m_cboTbp1NativePlace.Name = "m_cboTbp1NativePlace";
			this.m_cboTbp1NativePlace.SelectedIndex = -1;
			this.m_cboTbp1NativePlace.SelectedItem = null;
			this.m_cboTbp1NativePlace.SelectionStart = 0;
			this.m_cboTbp1NativePlace.Size = new System.Drawing.Size(110, 23);
			this.m_cboTbp1NativePlace.TabIndex = 150;
			this.m_cboTbp1NativePlace.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp1NativePlace.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_tbpEmployee
			// 
			this.m_tbpEmployee.AutoScroll = true;
			this.m_tbpEmployee.BackColor = System.Drawing.SystemColors.Control;
			this.m_tbpEmployee.Controls.Add(this.m_cmdTbp2OK);
			this.m_tbpEmployee.Controls.Add(this.m_cmdTbp2ClearForm);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2PYCode);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2Experience);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2LanguageAbility);
			this.m_tbpEmployee.Controls.Add(this.m_lsvTbp2EmployeeName);
			this.m_tbpEmployee.Controls.Add(this.m_lsvTbp2EmployeeID);
			this.m_tbpEmployee.Controls.Add(this.m_cboTbp2Married);
			this.m_tbpEmployee.Controls.Add(this.m_dtpTbp2Birth);
			this.m_tbpEmployee.Controls.Add(this.m_cboTbp2Sex);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2EmployeeName);
			this.m_tbpEmployee.Controls.Add(this.label9);
			this.m_tbpEmployee.Controls.Add(this.label24);
			this.m_tbpEmployee.Controls.Add(this.label29);
			this.m_tbpEmployee.Controls.Add(this.label32);
			this.m_tbpEmployee.Controls.Add(this.label33);
			this.m_tbpEmployee.Controls.Add(this.label34);
			this.m_tbpEmployee.Controls.Add(this.lblPYCodeTitle);
			this.m_tbpEmployee.Controls.Add(this.lblEducationalLevelTitle);
			this.m_tbpEmployee.Controls.Add(this.label36);
			this.m_tbpEmployee.Controls.Add(this.lblLanguageAbilityTitle);
			this.m_tbpEmployee.Controls.Add(this.label37);
			this.m_tbpEmployee.Controls.Add(this.lblPhoneOfAnnouncerTitle);
			this.m_tbpEmployee.Controls.Add(this.lblExperienceTitle);
			this.m_tbpEmployee.Controls.Add(this.lblRemarkTitle);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2IDCard);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2TitleOfaTechnicalPost);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2OfficePhone);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2HomePhone);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2HomeAddress);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2OfficeAddress);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2OfficePC);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2HomePC);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2Mobile);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2EMail);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2EmployeeID);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2EducationalLevel);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2FirstNameOfAnnouncer);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2PhoneOfAnnouncer);
			this.m_tbpEmployee.Controls.Add(this.m_txtTbp2Remark);
			this.m_tbpEmployee.Controls.Add(this.label27);
			this.m_tbpEmployee.Controls.Add(this.lblTitleOfaTechnicalPostTitle);
			this.m_tbpEmployee.Controls.Add(this.label28);
			this.m_tbpEmployee.Controls.Add(this.label30);
			this.m_tbpEmployee.Controls.Add(this.label31);
			this.m_tbpEmployee.Controls.Add(this.label35);
			this.m_tbpEmployee.Controls.Add(this.lblEmployeeIDTitle);
			this.m_tbpEmployee.Controls.Add(this.lblFirstNameOfAnnouncerTitle);
			this.m_tbpEmployee.Location = new System.Drawing.Point(4, 26);
			this.m_tbpEmployee.Name = "m_tbpEmployee";
			this.m_tbpEmployee.Size = new System.Drawing.Size(832, 623);
			this.m_tbpEmployee.TabIndex = 1;
			this.m_tbpEmployee.Text = "员工入职";
			// 
			// m_cmdTbp2OK
			// 
			this.m_cmdTbp2OK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdTbp2OK.DefaultScheme = true;
			this.m_cmdTbp2OK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdTbp2OK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdTbp2OK.Hint = "";
			this.m_cmdTbp2OK.Location = new System.Drawing.Point(388, 500);
			this.m_cmdTbp2OK.Name = "m_cmdTbp2OK";
			this.m_cmdTbp2OK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdTbp2OK.Size = new System.Drawing.Size(68, 32);
			this.m_cmdTbp2OK.TabIndex = 10000005;
			this.m_cmdTbp2OK.Text = "入 职";
			this.m_cmdTbp2OK.Click += new System.EventHandler(this.m_cmdTbp2OK_Click);
			// 
			// m_cmdTbp2ClearForm
			// 
			this.m_cmdTbp2ClearForm.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdTbp2ClearForm.DefaultScheme = true;
			this.m_cmdTbp2ClearForm.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdTbp2ClearForm.ForeColor = System.Drawing.Color.Black;
			this.m_cmdTbp2ClearForm.Hint = "";
			this.m_cmdTbp2ClearForm.Location = new System.Drawing.Point(476, 500);
			this.m_cmdTbp2ClearForm.Name = "m_cmdTbp2ClearForm";
			this.m_cmdTbp2ClearForm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdTbp2ClearForm.Size = new System.Drawing.Size(68, 32);
			this.m_cmdTbp2ClearForm.TabIndex = 10000004;
			this.m_cmdTbp2ClearForm.Text = "清 空";
			this.m_cmdTbp2ClearForm.Click += new System.EventHandler(this.m_cmdTbp2ClearForm_Click);
			// 
			// m_txtTbp2PYCode
			// 
			this.m_txtTbp2PYCode.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2PYCode.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2PYCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2PYCode.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2PYCode.Location = new System.Drawing.Point(504, 28);
			this.m_txtTbp2PYCode.Name = "m_txtTbp2PYCode";
			this.m_txtTbp2PYCode.Size = new System.Drawing.Size(56, 23);
			this.m_txtTbp2PYCode.TabIndex = 130;
			this.m_txtTbp2PYCode.Text = "";
			// 
			// m_txtTbp2Experience
			// 
			this.m_txtTbp2Experience.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2Experience.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2Experience.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2Experience.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2Experience.Location = new System.Drawing.Point(76, 360);
			this.m_txtTbp2Experience.Multiline = true;
			this.m_txtTbp2Experience.Name = "m_txtTbp2Experience";
			this.m_txtTbp2Experience.Size = new System.Drawing.Size(484, 92);
			this.m_txtTbp2Experience.TabIndex = 300;
			this.m_txtTbp2Experience.Text = "";
			// 
			// m_txtTbp2LanguageAbility
			// 
			this.m_txtTbp2LanguageAbility.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2LanguageAbility.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2LanguageAbility.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2LanguageAbility.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2LanguageAbility.Location = new System.Drawing.Point(468, 114);
			this.m_txtTbp2LanguageAbility.Name = "m_txtTbp2LanguageAbility";
			this.m_txtTbp2LanguageAbility.Size = new System.Drawing.Size(92, 23);
			this.m_txtTbp2LanguageAbility.TabIndex = 190;
			this.m_txtTbp2LanguageAbility.Text = "";
			// 
			// m_lsvTbp2EmployeeName
			// 
			this.m_lsvTbp2EmployeeName.BackColor = System.Drawing.Color.White;
			this.m_lsvTbp2EmployeeName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									this.clmTbp2EmployeeID,
																									this.clmTbp2EmployeeName});
			this.m_lsvTbp2EmployeeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvTbp2EmployeeName.ForeColor = System.Drawing.Color.Black;
			this.m_lsvTbp2EmployeeName.FullRowSelect = true;
			this.m_lsvTbp2EmployeeName.GridLines = true;
			this.m_lsvTbp2EmployeeName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvTbp2EmployeeName.Location = new System.Drawing.Point(228, 56);
			this.m_lsvTbp2EmployeeName.MultiSelect = false;
			this.m_lsvTbp2EmployeeName.Name = "m_lsvTbp2EmployeeName";
			this.m_lsvTbp2EmployeeName.Size = new System.Drawing.Size(164, 104);
			this.m_lsvTbp2EmployeeName.TabIndex = 521;
			this.m_lsvTbp2EmployeeName.View = System.Windows.Forms.View.Details;
			this.m_lsvTbp2EmployeeName.Visible = false;
			this.m_lsvTbp2EmployeeName.DoubleClick += new System.EventHandler(this.m_mthEvent_DoubleClikcLsv);
			// 
			// clmTbp2EmployeeID
			// 
			this.clmTbp2EmployeeID.Width = 80;
			// 
			// clmTbp2EmployeeName
			// 
			this.clmTbp2EmployeeName.Width = 80;
			// 
			// m_lsvTbp2EmployeeID
			// 
			this.m_lsvTbp2EmployeeID.BackColor = System.Drawing.Color.White;
			this.m_lsvTbp2EmployeeID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.columnHeader1,
																								  this.columnHeader2});
			this.m_lsvTbp2EmployeeID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvTbp2EmployeeID.ForeColor = System.Drawing.Color.Black;
			this.m_lsvTbp2EmployeeID.FullRowSelect = true;
			this.m_lsvTbp2EmployeeID.GridLines = true;
			this.m_lsvTbp2EmployeeID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvTbp2EmployeeID.Location = new System.Drawing.Point(76, 56);
			this.m_lsvTbp2EmployeeID.MultiSelect = false;
			this.m_lsvTbp2EmployeeID.Name = "m_lsvTbp2EmployeeID";
			this.m_lsvTbp2EmployeeID.Size = new System.Drawing.Size(164, 104);
			this.m_lsvTbp2EmployeeID.TabIndex = 511;
			this.m_lsvTbp2EmployeeID.View = System.Windows.Forms.View.Details;
			this.m_lsvTbp2EmployeeID.Visible = false;
			this.m_lsvTbp2EmployeeID.DoubleClick += new System.EventHandler(this.m_mthEvent_DoubleClikcLsv);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 80;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Width = 80;
			// 
			// m_cboTbp2Married
			// 
			this.m_cboTbp2Married.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp2Married.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp2Married.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp2Married.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp2Married.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp2Married.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTbp2Married.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp2Married.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp2Married.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp2Married.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp2Married.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp2Married.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp2Married.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp2Married.Location = new System.Drawing.Point(480, 72);
			this.m_cboTbp2Married.m_BlnEnableItemEventMenu = true;
			this.m_cboTbp2Married.Name = "m_cboTbp2Married";
			this.m_cboTbp2Married.SelectedIndex = -1;
			this.m_cboTbp2Married.SelectedItem = null;
			this.m_cboTbp2Married.SelectionStart = -1;
			this.m_cboTbp2Married.Size = new System.Drawing.Size(80, 23);
			this.m_cboTbp2Married.TabIndex = 160;
			this.m_cboTbp2Married.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp2Married.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_dtpTbp2Birth
			// 
			this.m_dtpTbp2Birth.BorderColor = System.Drawing.Color.Black;
			this.m_dtpTbp2Birth.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpTbp2Birth.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtpTbp2Birth.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpTbp2Birth.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtpTbp2Birth.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpTbp2Birth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpTbp2Birth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpTbp2Birth.Location = new System.Drawing.Point(276, 72);
			this.m_dtpTbp2Birth.m_BlnOnlyTime = false;
			this.m_dtpTbp2Birth.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpTbp2Birth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpTbp2Birth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpTbp2Birth.Name = "m_dtpTbp2Birth";
			this.m_dtpTbp2Birth.ReadOnly = false;
			this.m_dtpTbp2Birth.Size = new System.Drawing.Size(132, 22);
			this.m_dtpTbp2Birth.TabIndex = 150;
			this.m_dtpTbp2Birth.TextBackColor = System.Drawing.Color.White;
			this.m_dtpTbp2Birth.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboTbp2Sex
			// 
			this.m_cboTbp2Sex.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp2Sex.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp2Sex.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp2Sex.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp2Sex.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp2Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTbp2Sex.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp2Sex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp2Sex.ForeColor = System.Drawing.Color.Black;
			this.m_cboTbp2Sex.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp2Sex.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp2Sex.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp2Sex.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp2Sex.Location = new System.Drawing.Point(368, 30);
			this.m_cboTbp2Sex.m_BlnEnableItemEventMenu = true;
			this.m_cboTbp2Sex.Name = "m_cboTbp2Sex";
			this.m_cboTbp2Sex.SelectedIndex = -1;
			this.m_cboTbp2Sex.SelectedItem = null;
			this.m_cboTbp2Sex.SelectionStart = -1;
			this.m_cboTbp2Sex.Size = new System.Drawing.Size(80, 23);
			this.m_cboTbp2Sex.TabIndex = 120;
			this.m_cboTbp2Sex.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp2Sex.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtTbp2EmployeeName
			// 
			this.m_txtTbp2EmployeeName.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2EmployeeName.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2EmployeeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2EmployeeName.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2EmployeeName.Location = new System.Drawing.Point(228, 30);
			this.m_txtTbp2EmployeeName.Name = "m_txtTbp2EmployeeName";
			this.m_txtTbp2EmployeeName.Size = new System.Drawing.Size(88, 23);
			this.m_txtTbp2EmployeeName.TabIndex = 110;
			this.m_txtTbp2EmployeeName.Text = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(184, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 19);
			this.label9.TabIndex = 29197;
			this.label9.Text = "姓名:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label24.Location = new System.Drawing.Point(320, 32);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(48, 19);
			this.label24.TabIndex = 29185;
			this.label24.Text = "性 别:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label29.Location = new System.Drawing.Point(200, 158);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(70, 19);
			this.label29.TabIndex = 29206;
			this.label29.Text = "家庭电话:";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label32.Location = new System.Drawing.Point(396, 242);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(48, 19);
			this.label32.TabIndex = 29186;
			this.label32.Text = "邮 编:";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label33.Location = new System.Drawing.Point(396, 200);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(48, 19);
			this.label33.TabIndex = 29187;
			this.label33.Text = "邮 编:";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label34.Location = new System.Drawing.Point(396, 158);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(48, 19);
			this.label34.TabIndex = 29188;
			this.label34.Text = "手 机:";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPYCodeTitle
			// 
			this.lblPYCodeTitle.AutoSize = true;
			this.lblPYCodeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPYCodeTitle.Location = new System.Drawing.Point(452, 32);
			this.lblPYCodeTitle.Name = "lblPYCodeTitle";
			this.lblPYCodeTitle.Size = new System.Drawing.Size(56, 19);
			this.lblPYCodeTitle.TabIndex = 29203;
			this.lblPYCodeTitle.Text = "拼音码:";
			this.lblPYCodeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEducationalLevelTitle
			// 
			this.lblEducationalLevelTitle.AutoSize = true;
			this.lblEducationalLevelTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEducationalLevelTitle.Location = new System.Drawing.Point(204, 116);
			this.lblEducationalLevelTitle.Name = "lblEducationalLevelTitle";
			this.lblEducationalLevelTitle.Size = new System.Drawing.Size(70, 19);
			this.lblEducationalLevelTitle.TabIndex = 29201;
			this.lblEducationalLevelTitle.Text = "教育程度:";
			this.lblEducationalLevelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label36.Location = new System.Drawing.Point(412, 74);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(70, 19);
			this.label36.TabIndex = 29193;
			this.label36.Text = "婚姻状况:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLanguageAbilityTitle
			// 
			this.lblLanguageAbilityTitle.AutoSize = true;
			this.lblLanguageAbilityTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLanguageAbilityTitle.Location = new System.Drawing.Point(396, 116);
			this.lblLanguageAbilityTitle.Name = "lblLanguageAbilityTitle";
			this.lblLanguageAbilityTitle.Size = new System.Drawing.Size(70, 19);
			this.lblLanguageAbilityTitle.TabIndex = 29202;
			this.lblLanguageAbilityTitle.Text = "语言能力:";
			this.lblLanguageAbilityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label37.Location = new System.Drawing.Point(200, 74);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(70, 19);
			this.label37.TabIndex = 29194;
			this.label37.Text = "出生日期:";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPhoneOfAnnouncerTitle
			// 
			this.lblPhoneOfAnnouncerTitle.AutoSize = true;
			this.lblPhoneOfAnnouncerTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPhoneOfAnnouncerTitle.Location = new System.Drawing.Point(308, 326);
			this.lblPhoneOfAnnouncerTitle.Name = "lblPhoneOfAnnouncerTitle";
			this.lblPhoneOfAnnouncerTitle.Size = new System.Drawing.Size(84, 19);
			this.lblPhoneOfAnnouncerTitle.TabIndex = 29199;
			this.lblPhoneOfAnnouncerTitle.Text = "告知者电话:";
			this.lblPhoneOfAnnouncerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExperienceTitle
			// 
			this.lblExperienceTitle.AutoSize = true;
			this.lblExperienceTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblExperienceTitle.Location = new System.Drawing.Point(8, 364);
			this.lblExperienceTitle.Name = "lblExperienceTitle";
			this.lblExperienceTitle.Size = new System.Drawing.Size(41, 19);
			this.lblExperienceTitle.TabIndex = 29189;
			this.lblExperienceTitle.Text = "简历:";
			this.lblExperienceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRemarkTitle
			// 
			this.lblRemarkTitle.AutoSize = true;
			this.lblRemarkTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRemarkTitle.Location = new System.Drawing.Point(8, 468);
			this.lblRemarkTitle.Name = "lblRemarkTitle";
			this.lblRemarkTitle.Size = new System.Drawing.Size(41, 19);
			this.lblRemarkTitle.TabIndex = 29190;
			this.lblRemarkTitle.Text = "注释:";
			this.lblRemarkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtTbp2IDCard
			// 
			this.m_txtTbp2IDCard.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2IDCard.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2IDCard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2IDCard.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2IDCard.Location = new System.Drawing.Point(76, 72);
			this.m_txtTbp2IDCard.MaxLength = 18;
			this.m_txtTbp2IDCard.Name = "m_txtTbp2IDCard";
			this.m_txtTbp2IDCard.Size = new System.Drawing.Size(120, 23);
			this.m_txtTbp2IDCard.TabIndex = 140;
			this.m_txtTbp2IDCard.Text = "";
			// 
			// m_txtTbp2TitleOfaTechnicalPost
			// 
			this.m_txtTbp2TitleOfaTechnicalPost.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2TitleOfaTechnicalPost.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2TitleOfaTechnicalPost.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2TitleOfaTechnicalPost.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2TitleOfaTechnicalPost.Location = new System.Drawing.Point(76, 114);
			this.m_txtTbp2TitleOfaTechnicalPost.Name = "m_txtTbp2TitleOfaTechnicalPost";
			this.m_txtTbp2TitleOfaTechnicalPost.Size = new System.Drawing.Size(120, 23);
			this.m_txtTbp2TitleOfaTechnicalPost.TabIndex = 170;
			this.m_txtTbp2TitleOfaTechnicalPost.Text = "";
			// 
			// m_txtTbp2OfficePhone
			// 
			this.m_txtTbp2OfficePhone.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2OfficePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2OfficePhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2OfficePhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2OfficePhone.Location = new System.Drawing.Point(76, 156);
			this.m_txtTbp2OfficePhone.Name = "m_txtTbp2OfficePhone";
			this.m_txtTbp2OfficePhone.Size = new System.Drawing.Size(120, 23);
			this.m_txtTbp2OfficePhone.TabIndex = 200;
			this.m_txtTbp2OfficePhone.Text = "";
			// 
			// m_txtTbp2HomePhone
			// 
			this.m_txtTbp2HomePhone.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2HomePhone.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2HomePhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2HomePhone.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2HomePhone.Location = new System.Drawing.Point(276, 156);
			this.m_txtTbp2HomePhone.Name = "m_txtTbp2HomePhone";
			this.m_txtTbp2HomePhone.Size = new System.Drawing.Size(112, 23);
			this.m_txtTbp2HomePhone.TabIndex = 210;
			this.m_txtTbp2HomePhone.Text = "";
			// 
			// m_txtTbp2HomeAddress
			// 
			this.m_txtTbp2HomeAddress.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2HomeAddress.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2HomeAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2HomeAddress.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2HomeAddress.Location = new System.Drawing.Point(76, 240);
			this.m_txtTbp2HomeAddress.Name = "m_txtTbp2HomeAddress";
			this.m_txtTbp2HomeAddress.Size = new System.Drawing.Size(312, 23);
			this.m_txtTbp2HomeAddress.TabIndex = 250;
			this.m_txtTbp2HomeAddress.Text = "";
			// 
			// m_txtTbp2OfficeAddress
			// 
			this.m_txtTbp2OfficeAddress.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2OfficeAddress.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2OfficeAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2OfficeAddress.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2OfficeAddress.Location = new System.Drawing.Point(76, 198);
			this.m_txtTbp2OfficeAddress.Name = "m_txtTbp2OfficeAddress";
			this.m_txtTbp2OfficeAddress.Size = new System.Drawing.Size(312, 23);
			this.m_txtTbp2OfficeAddress.TabIndex = 230;
			this.m_txtTbp2OfficeAddress.Text = "";
			// 
			// m_txtTbp2OfficePC
			// 
			this.m_txtTbp2OfficePC.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2OfficePC.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2OfficePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2OfficePC.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2OfficePC.Location = new System.Drawing.Point(468, 198);
			this.m_txtTbp2OfficePC.MaxLength = 6;
			this.m_txtTbp2OfficePC.Name = "m_txtTbp2OfficePC";
			this.m_txtTbp2OfficePC.Size = new System.Drawing.Size(92, 23);
			this.m_txtTbp2OfficePC.TabIndex = 240;
			this.m_txtTbp2OfficePC.Text = "";
			// 
			// m_txtTbp2HomePC
			// 
			this.m_txtTbp2HomePC.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2HomePC.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2HomePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2HomePC.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2HomePC.Location = new System.Drawing.Point(468, 240);
			this.m_txtTbp2HomePC.MaxLength = 6;
			this.m_txtTbp2HomePC.Name = "m_txtTbp2HomePC";
			this.m_txtTbp2HomePC.Size = new System.Drawing.Size(92, 23);
			this.m_txtTbp2HomePC.TabIndex = 260;
			this.m_txtTbp2HomePC.Text = "";
			// 
			// m_txtTbp2Mobile
			// 
			this.m_txtTbp2Mobile.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2Mobile.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2Mobile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2Mobile.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2Mobile.Location = new System.Drawing.Point(468, 156);
			this.m_txtTbp2Mobile.Name = "m_txtTbp2Mobile";
			this.m_txtTbp2Mobile.Size = new System.Drawing.Size(92, 23);
			this.m_txtTbp2Mobile.TabIndex = 220;
			this.m_txtTbp2Mobile.Text = "";
			// 
			// m_txtTbp2EMail
			// 
			this.m_txtTbp2EMail.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2EMail.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2EMail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2EMail.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2EMail.Location = new System.Drawing.Point(76, 282);
			this.m_txtTbp2EMail.Name = "m_txtTbp2EMail";
			this.m_txtTbp2EMail.Size = new System.Drawing.Size(312, 23);
			this.m_txtTbp2EMail.TabIndex = 270;
			this.m_txtTbp2EMail.Text = "";
			// 
			// m_txtTbp2EmployeeID
			// 
			this.m_txtTbp2EmployeeID.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2EmployeeID.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2EmployeeID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2EmployeeID.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2EmployeeID.Location = new System.Drawing.Point(76, 30);
			this.m_txtTbp2EmployeeID.Name = "m_txtTbp2EmployeeID";
			this.m_txtTbp2EmployeeID.Size = new System.Drawing.Size(104, 23);
			this.m_txtTbp2EmployeeID.TabIndex = 100;
			this.m_txtTbp2EmployeeID.Text = "";
			// 
			// m_txtTbp2EducationalLevel
			// 
			this.m_txtTbp2EducationalLevel.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2EducationalLevel.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2EducationalLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2EducationalLevel.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2EducationalLevel.Location = new System.Drawing.Point(276, 114);
			this.m_txtTbp2EducationalLevel.Name = "m_txtTbp2EducationalLevel";
			this.m_txtTbp2EducationalLevel.Size = new System.Drawing.Size(112, 23);
			this.m_txtTbp2EducationalLevel.TabIndex = 180;
			this.m_txtTbp2EducationalLevel.Text = "";
			// 
			// m_txtTbp2FirstNameOfAnnouncer
			// 
			this.m_txtTbp2FirstNameOfAnnouncer.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2FirstNameOfAnnouncer.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2FirstNameOfAnnouncer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2FirstNameOfAnnouncer.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2FirstNameOfAnnouncer.Location = new System.Drawing.Point(76, 324);
			this.m_txtTbp2FirstNameOfAnnouncer.Name = "m_txtTbp2FirstNameOfAnnouncer";
			this.m_txtTbp2FirstNameOfAnnouncer.Size = new System.Drawing.Size(208, 23);
			this.m_txtTbp2FirstNameOfAnnouncer.TabIndex = 280;
			this.m_txtTbp2FirstNameOfAnnouncer.Text = "";
			// 
			// m_txtTbp2PhoneOfAnnouncer
			// 
			this.m_txtTbp2PhoneOfAnnouncer.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2PhoneOfAnnouncer.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2PhoneOfAnnouncer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2PhoneOfAnnouncer.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2PhoneOfAnnouncer.Location = new System.Drawing.Point(400, 324);
			this.m_txtTbp2PhoneOfAnnouncer.Name = "m_txtTbp2PhoneOfAnnouncer";
			this.m_txtTbp2PhoneOfAnnouncer.Size = new System.Drawing.Size(160, 23);
			this.m_txtTbp2PhoneOfAnnouncer.TabIndex = 290;
			this.m_txtTbp2PhoneOfAnnouncer.Text = "";
			// 
			// m_txtTbp2Remark
			// 
			this.m_txtTbp2Remark.BackColor = System.Drawing.Color.White;
			this.m_txtTbp2Remark.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp2Remark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp2Remark.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp2Remark.Location = new System.Drawing.Point(76, 464);
			this.m_txtTbp2Remark.Name = "m_txtTbp2Remark";
			this.m_txtTbp2Remark.Size = new System.Drawing.Size(484, 23);
			this.m_txtTbp2Remark.TabIndex = 310;
			this.m_txtTbp2Remark.Text = "";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label27.Location = new System.Drawing.Point(8, 74);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(70, 19);
			this.label27.TabIndex = 29195;
			this.label27.Text = "身份证号:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTitleOfaTechnicalPostTitle
			// 
			this.lblTitleOfaTechnicalPostTitle.AutoSize = true;
			this.lblTitleOfaTechnicalPostTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitleOfaTechnicalPostTitle.Location = new System.Drawing.Point(8, 116);
			this.lblTitleOfaTechnicalPostTitle.Name = "lblTitleOfaTechnicalPostTitle";
			this.lblTitleOfaTechnicalPostTitle.Size = new System.Drawing.Size(56, 19);
			this.lblTitleOfaTechnicalPostTitle.TabIndex = 29192;
			this.lblTitleOfaTechnicalPostTitle.Text = "职  称:";
			this.lblTitleOfaTechnicalPostTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label28.Location = new System.Drawing.Point(8, 158);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(70, 19);
			this.label28.TabIndex = 29200;
			this.label28.Text = "办公电话:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label30.Location = new System.Drawing.Point(8, 242);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(70, 19);
			this.label30.TabIndex = 29205;
			this.label30.Text = "家庭地址:";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label31.Location = new System.Drawing.Point(8, 200);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(70, 19);
			this.label31.TabIndex = 29204;
			this.label31.Text = "办公地址:";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label35.Location = new System.Drawing.Point(8, 284);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(48, 19);
			this.label35.TabIndex = 29191;
			this.label35.Text = "EMail:";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEmployeeIDTitle
			// 
			this.lblEmployeeIDTitle.AutoSize = true;
			this.lblEmployeeIDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEmployeeIDTitle.Location = new System.Drawing.Point(8, 32);
			this.lblEmployeeIDTitle.Name = "lblEmployeeIDTitle";
			this.lblEmployeeIDTitle.Size = new System.Drawing.Size(70, 19);
			this.lblEmployeeIDTitle.TabIndex = 29196;
			this.lblEmployeeIDTitle.Text = "员工编号:";
			this.lblEmployeeIDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblFirstNameOfAnnouncerTitle
			// 
			this.lblFirstNameOfAnnouncerTitle.AutoSize = true;
			this.lblFirstNameOfAnnouncerTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblFirstNameOfAnnouncerTitle.Location = new System.Drawing.Point(8, 326);
			this.lblFirstNameOfAnnouncerTitle.Name = "lblFirstNameOfAnnouncerTitle";
			this.lblFirstNameOfAnnouncerTitle.Size = new System.Drawing.Size(56, 19);
			this.lblFirstNameOfAnnouncerTitle.TabIndex = 29198;
			this.lblFirstNameOfAnnouncerTitle.Text = "告知者:";
			this.lblFirstNameOfAnnouncerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_tbpDept
			// 
			this.m_tbpDept.BackColor = System.Drawing.SystemColors.Control;
			this.m_tbpDept.Controls.Add(this.m_cmdTbp3OK);
			this.m_tbpDept.Controls.Add(this.m_lsvTbp3DeptID);
			this.m_tbpDept.Controls.Add(this.m_lsvTbp3DeptName);
			this.m_tbpDept.Controls.Add(this.m_txtTbp3DeptID);
			this.m_tbpDept.Controls.Add(this.m_txtTbp3DeptName);
			this.m_tbpDept.Controls.Add(this.m_cboTbp3Category);
			this.m_tbpDept.Controls.Add(this.lblDeptIDTitle);
			this.m_tbpDept.Controls.Add(this.lblDeptNameTitle);
			this.m_tbpDept.Controls.Add(this.lblCategoryTitle);
			this.m_tbpDept.Controls.Add(this.lblInPatientOrOutPatientTitle);
			this.m_tbpDept.Controls.Add(this.lblAddressTitle);
			this.m_tbpDept.Controls.Add(this.label38);
			this.m_tbpDept.Controls.Add(this.lblShortNOTitle);
			this.m_tbpDept.Controls.Add(this.m_cboTbp3InPatientOrOutPatient);
			this.m_tbpDept.Controls.Add(this.m_txtTbp3Address);
			this.m_tbpDept.Controls.Add(this.m_txtTbp3PYCode);
			this.m_tbpDept.Controls.Add(this.m_txtTbp3ShortNO);
			this.m_tbpDept.Controls.Add(this.m_cmdTbp3ClearForm);
			this.m_tbpDept.Location = new System.Drawing.Point(4, 26);
			this.m_tbpDept.Name = "m_tbpDept";
			this.m_tbpDept.Size = new System.Drawing.Size(832, 623);
			this.m_tbpDept.TabIndex = 2;
			this.m_tbpDept.Text = "添加科室";
			this.m_tbpDept.Visible = false;
			// 
			// m_cmdTbp3OK
			// 
			this.m_cmdTbp3OK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdTbp3OK.DefaultScheme = true;
			this.m_cmdTbp3OK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdTbp3OK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdTbp3OK.Hint = "";
			this.m_cmdTbp3OK.Location = new System.Drawing.Point(348, 196);
			this.m_cmdTbp3OK.Name = "m_cmdTbp3OK";
			this.m_cmdTbp3OK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdTbp3OK.Size = new System.Drawing.Size(68, 32);
			this.m_cmdTbp3OK.TabIndex = 10000003;
			this.m_cmdTbp3OK.Text = "添 加";
			this.m_cmdTbp3OK.Click += new System.EventHandler(this.m_cmdTbp3OK_Click);
			// 
			// m_lsvTbp3DeptID
			// 
			this.m_lsvTbp3DeptID.BackColor = System.Drawing.Color.White;
			this.m_lsvTbp3DeptID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeader11,
																							  this.columnHeader12});
			this.m_lsvTbp3DeptID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvTbp3DeptID.ForeColor = System.Drawing.Color.Black;
			this.m_lsvTbp3DeptID.FullRowSelect = true;
			this.m_lsvTbp3DeptID.GridLines = true;
			this.m_lsvTbp3DeptID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvTbp3DeptID.Location = new System.Drawing.Point(112, 60);
			this.m_lsvTbp3DeptID.MultiSelect = false;
			this.m_lsvTbp3DeptID.Name = "m_lsvTbp3DeptID";
			this.m_lsvTbp3DeptID.Size = new System.Drawing.Size(164, 104);
			this.m_lsvTbp3DeptID.TabIndex = 811;
			this.m_lsvTbp3DeptID.View = System.Windows.Forms.View.Details;
			this.m_lsvTbp3DeptID.Visible = false;
			this.m_lsvTbp3DeptID.DoubleClick += new System.EventHandler(this.m_mthEvent_DoubleClikcLsv);
			// 
			// columnHeader11
			// 
			this.columnHeader11.Width = 80;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Width = 80;
			// 
			// m_lsvTbp3DeptName
			// 
			this.m_lsvTbp3DeptName.BackColor = System.Drawing.Color.White;
			this.m_lsvTbp3DeptName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.columnHeader13,
																								this.columnHeader14});
			this.m_lsvTbp3DeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvTbp3DeptName.ForeColor = System.Drawing.Color.Black;
			this.m_lsvTbp3DeptName.FullRowSelect = true;
			this.m_lsvTbp3DeptName.GridLines = true;
			this.m_lsvTbp3DeptName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvTbp3DeptName.Location = new System.Drawing.Point(336, 60);
			this.m_lsvTbp3DeptName.MultiSelect = false;
			this.m_lsvTbp3DeptName.Name = "m_lsvTbp3DeptName";
			this.m_lsvTbp3DeptName.Size = new System.Drawing.Size(164, 104);
			this.m_lsvTbp3DeptName.TabIndex = 821;
			this.m_lsvTbp3DeptName.View = System.Windows.Forms.View.Details;
			this.m_lsvTbp3DeptName.Visible = false;
			this.m_lsvTbp3DeptName.DoubleClick += new System.EventHandler(this.m_mthEvent_DoubleClikcLsv);
			// 
			// columnHeader13
			// 
			this.columnHeader13.Width = 80;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Width = 80;
			// 
			// m_txtTbp3DeptID
			// 
			this.m_txtTbp3DeptID.BackColor = System.Drawing.Color.White;
			this.m_txtTbp3DeptID.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp3DeptID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp3DeptID.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp3DeptID.Location = new System.Drawing.Point(112, 36);
			this.m_txtTbp3DeptID.Name = "m_txtTbp3DeptID";
			this.m_txtTbp3DeptID.Size = new System.Drawing.Size(96, 23);
			this.m_txtTbp3DeptID.TabIndex = 100;
			this.m_txtTbp3DeptID.Text = "";
			// 
			// m_txtTbp3DeptName
			// 
			this.m_txtTbp3DeptName.BackColor = System.Drawing.Color.White;
			this.m_txtTbp3DeptName.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp3DeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp3DeptName.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp3DeptName.Location = new System.Drawing.Point(336, 36);
			this.m_txtTbp3DeptName.Name = "m_txtTbp3DeptName";
			this.m_txtTbp3DeptName.Size = new System.Drawing.Size(164, 23);
			this.m_txtTbp3DeptName.TabIndex = 110;
			this.m_txtTbp3DeptName.Text = "";
			// 
			// m_cboTbp3Category
			// 
			this.m_cboTbp3Category.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp3Category.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp3Category.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp3Category.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp3Category.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp3Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTbp3Category.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp3Category.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp3Category.ForeColor = System.Drawing.Color.White;
			this.m_cboTbp3Category.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp3Category.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp3Category.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp3Category.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp3Category.Location = new System.Drawing.Point(112, 80);
			this.m_cboTbp3Category.m_BlnEnableItemEventMenu = true;
			this.m_cboTbp3Category.Name = "m_cboTbp3Category";
			this.m_cboTbp3Category.SelectedIndex = -1;
			this.m_cboTbp3Category.SelectedItem = null;
			this.m_cboTbp3Category.SelectionStart = -1;
			this.m_cboTbp3Category.Size = new System.Drawing.Size(96, 23);
			this.m_cboTbp3Category.TabIndex = 120;
			this.m_cboTbp3Category.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp3Category.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblDeptIDTitle
			// 
			this.lblDeptIDTitle.AutoSize = true;
			this.lblDeptIDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDeptIDTitle.Location = new System.Drawing.Point(32, 40);
			this.lblDeptIDTitle.Name = "lblDeptIDTitle";
			this.lblDeptIDTitle.Size = new System.Drawing.Size(70, 19);
			this.lblDeptIDTitle.TabIndex = 6090;
			this.lblDeptIDTitle.Text = "科室编号:";
			this.lblDeptIDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDeptNameTitle
			// 
			this.lblDeptNameTitle.AutoSize = true;
			this.lblDeptNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDeptNameTitle.Location = new System.Drawing.Point(252, 40);
			this.lblDeptNameTitle.Name = "lblDeptNameTitle";
			this.lblDeptNameTitle.Size = new System.Drawing.Size(70, 19);
			this.lblDeptNameTitle.TabIndex = 6088;
			this.lblDeptNameTitle.Text = "科室名称:";
			this.lblDeptNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblCategoryTitle
			// 
			this.lblCategoryTitle.AutoSize = true;
			this.lblCategoryTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCategoryTitle.Location = new System.Drawing.Point(32, 84);
			this.lblCategoryTitle.Name = "lblCategoryTitle";
			this.lblCategoryTitle.Size = new System.Drawing.Size(41, 19);
			this.lblCategoryTitle.TabIndex = 6087;
			this.lblCategoryTitle.Text = "种类:";
			this.lblCategoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblInPatientOrOutPatientTitle
			// 
			this.lblInPatientOrOutPatientTitle.AutoSize = true;
			this.lblInPatientOrOutPatientTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInPatientOrOutPatientTitle.Location = new System.Drawing.Point(252, 84);
			this.lblInPatientOrOutPatientTitle.Name = "lblInPatientOrOutPatientTitle";
			this.lblInPatientOrOutPatientTitle.Size = new System.Drawing.Size(41, 19);
			this.lblInPatientOrOutPatientTitle.TabIndex = 6086;
			this.lblInPatientOrOutPatientTitle.Text = "性质:";
			this.lblInPatientOrOutPatientTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblAddressTitle
			// 
			this.lblAddressTitle.AutoSize = true;
			this.lblAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAddressTitle.Location = new System.Drawing.Point(32, 164);
			this.lblAddressTitle.Name = "lblAddressTitle";
			this.lblAddressTitle.Size = new System.Drawing.Size(41, 19);
			this.lblAddressTitle.TabIndex = 6089;
			this.lblAddressTitle.Text = "地址:";
			this.lblAddressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label38.Location = new System.Drawing.Point(32, 124);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(56, 19);
			this.label38.TabIndex = 6092;
			this.label38.Text = "拼音码:";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblShortNOTitle
			// 
			this.lblShortNOTitle.AutoSize = true;
			this.lblShortNOTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblShortNOTitle.Location = new System.Drawing.Point(252, 124);
			this.lblShortNOTitle.Name = "lblShortNOTitle";
			this.lblShortNOTitle.Size = new System.Drawing.Size(41, 19);
			this.lblShortNOTitle.TabIndex = 6091;
			this.lblShortNOTitle.Text = "短称:";
			this.lblShortNOTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboTbp3InPatientOrOutPatient
			// 
			this.m_cboTbp3InPatientOrOutPatient.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboTbp3InPatientOrOutPatient.BorderColor = System.Drawing.Color.Black;
			this.m_cboTbp3InPatientOrOutPatient.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboTbp3InPatientOrOutPatient.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboTbp3InPatientOrOutPatient.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboTbp3InPatientOrOutPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTbp3InPatientOrOutPatient.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp3InPatientOrOutPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboTbp3InPatientOrOutPatient.ForeColor = System.Drawing.Color.White;
			this.m_cboTbp3InPatientOrOutPatient.ListBackColor = System.Drawing.Color.White;
			this.m_cboTbp3InPatientOrOutPatient.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboTbp3InPatientOrOutPatient.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboTbp3InPatientOrOutPatient.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboTbp3InPatientOrOutPatient.Location = new System.Drawing.Point(336, 80);
			this.m_cboTbp3InPatientOrOutPatient.m_BlnEnableItemEventMenu = true;
			this.m_cboTbp3InPatientOrOutPatient.Name = "m_cboTbp3InPatientOrOutPatient";
			this.m_cboTbp3InPatientOrOutPatient.SelectedIndex = -1;
			this.m_cboTbp3InPatientOrOutPatient.SelectedItem = null;
			this.m_cboTbp3InPatientOrOutPatient.SelectionStart = -1;
			this.m_cboTbp3InPatientOrOutPatient.Size = new System.Drawing.Size(104, 23);
			this.m_cboTbp3InPatientOrOutPatient.TabIndex = 130;
			this.m_cboTbp3InPatientOrOutPatient.TextBackColor = System.Drawing.Color.White;
			this.m_cboTbp3InPatientOrOutPatient.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_txtTbp3Address
			// 
			this.m_txtTbp3Address.BackColor = System.Drawing.Color.White;
			this.m_txtTbp3Address.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp3Address.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp3Address.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp3Address.Location = new System.Drawing.Point(112, 160);
			this.m_txtTbp3Address.Name = "m_txtTbp3Address";
			this.m_txtTbp3Address.Size = new System.Drawing.Size(388, 23);
			this.m_txtTbp3Address.TabIndex = 160;
			this.m_txtTbp3Address.Text = "";
			// 
			// m_txtTbp3PYCode
			// 
			this.m_txtTbp3PYCode.BackColor = System.Drawing.Color.White;
			this.m_txtTbp3PYCode.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp3PYCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp3PYCode.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp3PYCode.Location = new System.Drawing.Point(112, 120);
			this.m_txtTbp3PYCode.Name = "m_txtTbp3PYCode";
			this.m_txtTbp3PYCode.Size = new System.Drawing.Size(96, 23);
			this.m_txtTbp3PYCode.TabIndex = 140;
			this.m_txtTbp3PYCode.Text = "";
			// 
			// m_txtTbp3ShortNO
			// 
			this.m_txtTbp3ShortNO.BackColor = System.Drawing.Color.White;
			this.m_txtTbp3ShortNO.BorderColor = System.Drawing.Color.White;
			this.m_txtTbp3ShortNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTbp3ShortNO.ForeColor = System.Drawing.Color.Black;
			this.m_txtTbp3ShortNO.Location = new System.Drawing.Point(336, 120);
			this.m_txtTbp3ShortNO.Name = "m_txtTbp3ShortNO";
			this.m_txtTbp3ShortNO.Size = new System.Drawing.Size(104, 23);
			this.m_txtTbp3ShortNO.TabIndex = 150;
			this.m_txtTbp3ShortNO.Text = "";
			// 
			// m_cmdTbp3ClearForm
			// 
			this.m_cmdTbp3ClearForm.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdTbp3ClearForm.DefaultScheme = true;
			this.m_cmdTbp3ClearForm.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdTbp3ClearForm.ForeColor = System.Drawing.Color.Black;
			this.m_cmdTbp3ClearForm.Hint = "";
			this.m_cmdTbp3ClearForm.Location = new System.Drawing.Point(436, 196);
			this.m_cmdTbp3ClearForm.Name = "m_cmdTbp3ClearForm";
			this.m_cmdTbp3ClearForm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdTbp3ClearForm.Size = new System.Drawing.Size(68, 32);
			this.m_cmdTbp3ClearForm.TabIndex = 10000003;
			this.m_cmdTbp3ClearForm.Text = "清 空";
			this.m_cmdTbp3ClearForm.Click += new System.EventHandler(this.m_cmdTbp3ClearForm_Click);
			// 
			// m_tbpForLeavePatient
			// 
			this.m_tbpForLeavePatient.Controls.Add(this.m_cmdReLocate);
			this.m_tbpForLeavePatient.Controls.Add(this.m_cmdUndoLeave);
			this.m_tbpForLeavePatient.Controls.Add(this.m_lstLeavePatient);
			this.m_tbpForLeavePatient.Controls.Add(this.label79);
			this.m_tbpForLeavePatient.Controls.Add(this.label78);
			this.m_tbpForLeavePatient.Controls.Add(this.m_cboAreaForLeave);
			this.m_tbpForLeavePatient.Controls.Add(this.m_cboDeptForLeave);
			this.m_tbpForLeavePatient.Location = new System.Drawing.Point(4, 26);
			this.m_tbpForLeavePatient.Name = "m_tbpForLeavePatient";
			this.m_tbpForLeavePatient.Size = new System.Drawing.Size(832, 623);
			this.m_tbpForLeavePatient.TabIndex = 3;
			this.m_tbpForLeavePatient.Text = "已出院病人";
			// 
			// m_cmdReLocate
			// 
			this.m_cmdReLocate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdReLocate.DefaultScheme = true;
			this.m_cmdReLocate.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdReLocate.ForeColor = System.Drawing.Color.Black;
			this.m_cmdReLocate.Hint = "";
			this.m_cmdReLocate.Location = new System.Drawing.Point(154, 546);
			this.m_cmdReLocate.Name = "m_cmdReLocate";
			this.m_cmdReLocate.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdReLocate.Size = new System.Drawing.Size(112, 26);
			this.m_cmdReLocate.TabIndex = 10000004;
			this.m_cmdReLocate.Text = "重新分配病床";
			this.m_cmdReLocate.Click += new System.EventHandler(this.m_cmdReLocate_Click);
			// 
			// m_cmdUndoLeave
			// 
			this.m_cmdUndoLeave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdUndoLeave.DefaultScheme = true;
			this.m_cmdUndoLeave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdUndoLeave.ForeColor = System.Drawing.Color.Black;
			this.m_cmdUndoLeave.Hint = "";
			this.m_cmdUndoLeave.Location = new System.Drawing.Point(42, 546);
			this.m_cmdUndoLeave.Name = "m_cmdUndoLeave";
			this.m_cmdUndoLeave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdUndoLeave.Size = new System.Drawing.Size(82, 26);
			this.m_cmdUndoLeave.TabIndex = 10000003;
			this.m_cmdUndoLeave.Text = "撤消出院";
			this.m_cmdUndoLeave.Click += new System.EventHandler(this.m_cmdUndoLeave_Click);
			// 
			// m_lstLeavePatient
			// 
			this.m_lstLeavePatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.m_chrLeavePatientName,
																								this.m_chrLastLeaveData,
																								this.m_chrBedName,
																								this.m_chrBedStatus});
			this.m_lstLeavePatient.FullRowSelect = true;
			this.m_lstLeavePatient.GridLines = true;
			this.m_lstLeavePatient.Location = new System.Drawing.Point(28, 82);
			this.m_lstLeavePatient.Name = "m_lstLeavePatient";
			this.m_lstLeavePatient.Size = new System.Drawing.Size(470, 458);
			this.m_lstLeavePatient.TabIndex = 29407;
			this.m_lstLeavePatient.View = System.Windows.Forms.View.Details;
			// 
			// m_chrLeavePatientName
			// 
			this.m_chrLeavePatientName.Text = "姓名";
			this.m_chrLeavePatientName.Width = 105;
			// 
			// m_chrLastLeaveData
			// 
			this.m_chrLastLeaveData.Text = "最后出院日期";
			this.m_chrLastLeaveData.Width = 156;
			// 
			// m_chrBedName
			// 
			this.m_chrBedName.Text = "病床";
			this.m_chrBedName.Width = 62;
			// 
			// m_chrBedStatus
			// 
			this.m_chrBedStatus.Text = "病床状态";
			this.m_chrBedStatus.Width = 141;
			// 
			// label79
			// 
			this.label79.AutoSize = true;
			this.label79.Location = new System.Drawing.Point(208, 44);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(41, 19);
			this.label79.TabIndex = 29406;
			this.label79.Text = "病区:";
			// 
			// label78
			// 
			this.label78.AutoSize = true;
			this.label78.Location = new System.Drawing.Point(28, 44);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(41, 19);
			this.label78.TabIndex = 29405;
			this.label78.Text = "科室:";
			// 
			// m_cboAreaForLeave
			// 
			this.m_cboAreaForLeave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboAreaForLeave.BorderColor = System.Drawing.Color.Black;
			this.m_cboAreaForLeave.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboAreaForLeave.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboAreaForLeave.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboAreaForLeave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboAreaForLeave.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboAreaForLeave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboAreaForLeave.ForeColor = System.Drawing.Color.Black;
			this.m_cboAreaForLeave.ListBackColor = System.Drawing.Color.White;
			this.m_cboAreaForLeave.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboAreaForLeave.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboAreaForLeave.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboAreaForLeave.Location = new System.Drawing.Point(260, 40);
			this.m_cboAreaForLeave.m_BlnEnableItemEventMenu = true;
			this.m_cboAreaForLeave.Name = "m_cboAreaForLeave";
			this.m_cboAreaForLeave.SelectedIndex = -1;
			this.m_cboAreaForLeave.SelectedItem = null;
			this.m_cboAreaForLeave.SelectionStart = -1;
			this.m_cboAreaForLeave.Size = new System.Drawing.Size(110, 23);
			this.m_cboAreaForLeave.TabIndex = 29404;
			this.m_cboAreaForLeave.TextBackColor = System.Drawing.Color.White;
			this.m_cboAreaForLeave.TextForeColor = System.Drawing.Color.Black;
			this.m_cboAreaForLeave.DropDown += new System.EventHandler(this.m_cboAreaForLeave_DropDown);
			this.m_cboAreaForLeave.SelectedIndexChanged += new System.EventHandler(this.m_cboAreaForLeave_SelectedIndexChanged);
			// 
			// m_cboDeptForLeave
			// 
			this.m_cboDeptForLeave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboDeptForLeave.BorderColor = System.Drawing.Color.Black;
			this.m_cboDeptForLeave.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboDeptForLeave.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboDeptForLeave.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboDeptForLeave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboDeptForLeave.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDeptForLeave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDeptForLeave.ForeColor = System.Drawing.Color.Black;
			this.m_cboDeptForLeave.ListBackColor = System.Drawing.Color.White;
			this.m_cboDeptForLeave.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboDeptForLeave.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboDeptForLeave.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboDeptForLeave.Location = new System.Drawing.Point(80, 40);
			this.m_cboDeptForLeave.m_BlnEnableItemEventMenu = true;
			this.m_cboDeptForLeave.Name = "m_cboDeptForLeave";
			this.m_cboDeptForLeave.SelectedIndex = -1;
			this.m_cboDeptForLeave.SelectedItem = null;
			this.m_cboDeptForLeave.SelectionStart = -1;
			this.m_cboDeptForLeave.Size = new System.Drawing.Size(110, 23);
			this.m_cboDeptForLeave.TabIndex = 29403;
			this.m_cboDeptForLeave.TextBackColor = System.Drawing.Color.White;
			this.m_cboDeptForLeave.TextForeColor = System.Drawing.Color.Black;
			this.m_cboDeptForLeave.DropDown += new System.EventHandler(this.m_cboDeptForLeave_DropDown);
			this.m_cboDeptForLeave.SelectedIndexChanged += new System.EventHandler(this.m_cboDeptForLeave_SelectedIndexChanged);
			// 
			// frmManageExplorer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(840, 653);
			this.Controls.Add(this.m_trvManageExplorer);
			this.Controls.Add(this.m_tabQuanYuan);
			this.Controls.Add(this.m_pnlRight);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmManageExplorer";
			this.Text = "医院信息管理";
			this.Load += new System.EventHandler(this.frmManageExplorer_Load);
			this.m_pnlRight.ResumeLayout(false);
			this.m_pnlBed.ResumeLayout(false);
			this.m_pnlDept.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.m_tbpDeptAddArea.ResumeLayout(false);
			this.m_tbpDeptAddEmployee.ResumeLayout(false);
			this.m_pnlPatient.ResumeLayout(false);
			this.m_pnlEmployee.ResumeLayout(false);
			this.m_pnlArea.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.m_tabQuanYuan.ResumeLayout(false);
			this.m_tbpPatient.ResumeLayout(false);
			this.m_tabData.ResumeLayout(false);
			this.m_gpbtbp1Must.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_numTbp1Times)).EndInit();
			this.m_tbpEmployee.ResumeLayout(false);
			this.m_tbpDept.ResumeLayout(false);
			this.m_tbpForLeavePatient.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// 从数据库读出部门和科室的信息并在树中显示
		/// </summary>
		private void m_mthLoadTree()
		{			
			//Load树的时候要把有关信息全部从数据库中提取出来
			TreeNode trnRootNode=new TreeNode("全院");
			clsNodeInfo objRootInfo=new clsNodeInfo();
			objRootInfo.m_strCategoryName="全院";
			objRootInfo.m_intCategory=0;
			//			objInfo.m_strID="0000001";
			objRootInfo.m_strName="全院";
			objRootInfo.m_objChildCategory=new clsNodeInfo();
			objRootInfo.m_objChildCategory.m_intCategory=1;
			objRootInfo.m_objChildCategory.m_strCategoryName="科室";
			trnRootNode.Tag=objRootInfo;
			trnRootNode.ImageIndex=0;
			m_trvManageExplorer.Nodes.Add(trnRootNode);
			
			
			
			clsDeptAndAreaInfo[] objDeptAndAreaInfoArr=null;
			long lngRes=m_objManagerDomain.m_lngGetAllDeptAndAreaInfoArr(out objDeptAndAreaInfoArr);
			if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
				return;
			}
			else if(objDeptAndAreaInfoArr==null ) 
				return;

			for(int i=0;i<objDeptAndAreaInfoArr.Length;i++)
			{
				TreeNode objNode=new TreeNode(objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptName);
				clsNodeInfo objInfo=new clsNodeInfo();
				objInfo.m_intCategory=1;
				objInfo.m_strCategoryName="科室";
				objInfo.m_strID=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptID;
				objInfo.m_strName=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptName;

				objInfo.m_objDeptDesc=new clsDept_Desc();
				objInfo.m_objDeptDesc.m_dtmCreateDate=objDeptAndAreaInfoArr[i].m_objDept.m_DtmDeptCreateDate;
				objInfo.m_objDeptDesc.m_dtmModifyDate=objDeptAndAreaInfoArr[i].m_objDept.m_DtmDeptInfoModifyDate;
				objInfo.m_objDeptDesc.m_dtmModifyDate=objDeptAndAreaInfoArr[i].m_objDept.m_DtmDeptRelationModifyDate;
				objInfo.m_objDeptDesc.m_strCategory=objDeptAndAreaInfoArr[i].m_objDept.m_EnmDeptCategory.ToString();
				objInfo.m_objDeptDesc.m_strDeActivedOperatorID="";	
				objInfo.m_objDeptDesc.m_strDeptID=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptID;
				objInfo.m_objDeptDesc.m_strDeptName=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptName;
				objInfo.m_objDeptDesc.m_strInPatientOrOutPatient=objDeptAndAreaInfoArr[i].m_objDept.m_EnmDeptType.ToString();
				objInfo.m_objDeptDesc.m_strPYCode=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptPYCode;
				objInfo.m_objDeptDesc.m_strShortNO=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptShortNO;


				objInfo.m_objChildCategory=new clsNodeInfo();
				objInfo.m_objChildCategory.m_intCategory=2;
				objInfo.m_objChildCategory.m_strCategoryName="病区";
				objNode.Tag=objInfo;
				objNode.ImageIndex=23;
				m_trvManageExplorer.Nodes[0].Nodes.Add(objNode);

				if(objDeptAndAreaInfoArr[i].m_objAreaArr!=null)
					for(int j=0;j<objDeptAndAreaInfoArr[i].m_objAreaArr.Length;j++)
					{
						TreeNode objNode2=new TreeNode(objDeptAndAreaInfoArr[i].m_objAreaArr[j].m_StrAreaName);
						clsNodeInfo objInfo2=new clsNodeInfo();
						objInfo2.m_intCategory=2;
						objInfo2.m_strCategoryName="病区";
						objInfo2.m_strID=objDeptAndAreaInfoArr[i].m_objAreaArr[j].m_StrAreaID;
						objInfo2.m_strName=objDeptAndAreaInfoArr[i].m_objAreaArr[j].m_StrAreaName;
						
						objInfo2.m_objAreaDesc=new clsArea_Desc();
						objInfo2.m_objAreaDesc.m_dtmBegin_Date_Area_Naming=objDeptAndAreaInfoArr[i].m_objAreaArr[j].m_DtmBeginDate;
						objInfo2.m_objAreaDesc.m_strArea_ID=objDeptAndAreaInfoArr[i].m_objAreaArr[j].m_StrAreaID;
						objInfo2.m_objAreaDesc.m_strArea_Name=objDeptAndAreaInfoArr[i].m_objAreaArr[j].m_StrAreaName;
						objInfo2.m_objAreaDesc.m_strParentDeptID=objDeptAndAreaInfoArr[i].m_objDept.m_StrDeptID;

						objNode2.Tag=objInfo2;
						objNode2.ImageIndex=2;
						m_trvManageExplorer.Nodes[0].Nodes[i].Nodes.Add(objNode2);
					}
			}		
		

			m_trvManageExplorer.ExpandAll();
			
			m_trvManageExplorer.SelectedNode=m_trvManageExplorer.Nodes[0];
		}

		#region 添加操作，已不用
		private void m_mthShowAddBox()
		{
			//如果新增节点下还有信息，m_objChildCategory也应有它的子类。这个可以从数据库决定 
//			frmAddBox frmAdd=null;
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory.m_objChildCategory=new clsNodeInfo();
			switch(((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory.m_intCategory)
			{
				case 0:
					((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory.m_objChildCategory.m_intCategory=1;
					((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory.m_objChildCategory.m_strCategoryName="科室";
					break;
				case 1:
					((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory.m_objChildCategory.m_intCategory=2;
					((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory.m_objChildCategory.m_strCategoryName="病区";
					break;
				case 2:
					((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory.m_objChildCategory.m_intCategory=3;
					((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory.m_objChildCategory.m_strCategoryName="病床";
					break;
				default: break;
			}

			
//			frmAdd=new frmAddBox(m_trvManageExplorer.SelectedNode,((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objChildCategory,m_lsvManageExplorerMid);
//			//应把窗口置于正中
//			frmAdd.ShowDialog();
		}

		private void m_mthShowRenameBox()
		{
////			frmRenameBox frmRename=new frmRenameBox(m_trvManageExplorer.SelectedNode);
//			frmRename.ShowDialog();
		}

		private void m_mthShowDeleteBox()
		{
		}
		#endregion


		#region 显示各Panel及其初始化
		
		/// <summary>
		/// 显示病区Panel
		/// </summary>
		private void m_mthDisplayPnlArea()
		{
			foreach(Control ctl in m_pnlRight.Controls)
			{
				if(ctl.GetType().Name=="Panel") ctl.Visible=false;
			}
			m_pnlArea.Visible=true;
			m_pnlArea.BringToFront();
			m_lblAreaAreaID.Text=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;

			m_txtAreaAreaName.Focus();
			m_txtAreaAreaName.Text=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strName;
			m_txtAreaAreaName.SelectAll();

			m_txtAreaNewBedID.Text="";
			m_txtAreaNewBedName.Text="";

		}

		/// <summary>
		/// 显示病床Panel
		/// </summary>
		private void m_mthDisplayPnlBed()
		{
			foreach(Control ctl in m_pnlRight.Controls)
			{
				if(ctl.GetType().Name=="Panel") ctl.Visible=false;
			}
			m_pnlBed.Visible=true;
			m_pnlBed.BringToFront();
			if(m_lsvManageExplorerMid.SelectedItems.Count==0)
			{
				m_lblBedBedID.Text="";
				m_txtBedBedName.Text="";
				
			}
			else
			{
				m_lblBedBedID.Text=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedID;
				m_txtBedBedName.Text=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName;
			}
			m_txtBedBedName.Focus();
			m_txtBedBedName.SelectAll();
			m_cboBedAddPatient.ClearItem();
			m_cboBedAddPatient.Text="(无病人)";
			
		}

		/// <summary>
		/// 显示科室Panel
		/// </summary>
		private void m_mthDisplayPnlDept()
		{
			foreach(Control ctl in m_pnlRight.Controls)
			{
				if(ctl.GetType().Name=="Panel") ctl.Visible=false;
			}
			m_pnlDept.Visible=true;
			m_pnlDept.BringToFront();
			m_lblDeptDeptID.Text=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;
			m_lblDeptDeptName.Text=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strName;
			m_txtDeptNewAreaID.Text="";
			m_txtDeptNewAreaName.Text="";

			clsDepartment objDept= new clsDepartment();
			objDept.m_StrDeptID=m_lblDeptDeptID.Text;
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc.m_dtmCreateDate=objDept.m_DtmDeptCreateDate;
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc.m_dtmModifyDate=objDept.m_DtmDeptInfoModifyDate;
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc.m_strCategory=objDept.m_EnmDeptCategory.ToString();
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc.m_strInPatientOrOutPatient=objDept.m_EnmDeptType.ToString();
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc.m_strAddress=objDept.m_StrDeptAddress;
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc.m_strPYCode=objDept.m_StrDeptPYCode;
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc.m_strShortNO=objDept.m_StrDeptShortNO;

			//此处获得员工病区及所属科室，要从数据库查

			

		}

		/// <summary>
		/// 显示员工Panel
		/// </summary>
		private void m_mthDisplayPnlEmployee()
		{
			
			foreach(Control ctl in m_pnlRight.Controls)
			{
				if(ctl.GetType().Name=="Panel") ctl.Visible=false;			
			}
			m_pnlEmployee.Visible=true;
			m_pnlEmployee.BringToFront();
			if(m_lsvManageExplorerMid.SelectedItems.Count==0)
			{
				m_lblEmployeeEmployeeID.Text="";
				m_lblEmployeeEmployeeName.Text="";
			}
			else 
			{
				m_lblEmployeeEmployeeID.Text=((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strEmployeeID;
				m_lblEmployeeEmployeeName.Text=((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strEmployeeName;
			}
			m_lstEmployeeTakenDept.Items.Clear();
			//从数据库中获取该员工负责的科室
			
//			clsDeptAreaInfo objDAInfo=new clsDeptAreaInfo();
//			objDAInfo.m_strAreaID="0000001";
//			objDAInfo.m_strAreaName="重症区";
//			objDAInfo.m_strDeptID="0000003";
//			objDAInfo.m_strDeptName="胸外科";
//			m_lstEmployeeTakenArea.Items.Add(objDAInfo);

			if(m_lsvManageExplorerMid.SelectedItems.Count==0)
			{
				return;
			}
			if(m_lsvManageExplorerMid.SelectedItems[0].Tag==null)
			{
				m_lsvManageExplorerMid.SelectedItems[0].Tag=new clsEmployeeInfo_ManageExplorer();
			}
			clsEmployee objEmployee= new clsEmployee(m_lblEmployeeEmployeeID.Text);
			
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo=new clsEmployee_BaseInfo();
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strEmployeeID=objEmployee.m_StrEmployeeID;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_dtmBeginDate=objEmployee.m_DtmBeginDate;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_dtmBirth=objEmployee.m_DtmBirth;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strEducationalLevel=objEmployee.m_StrEducationalLevel;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strEMail=objEmployee.m_StrEMail;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strExperience=objEmployee.m_StrExperience;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strFirstName=objEmployee.m_StrFirstName;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strFirstNameOfAnnouncer=objEmployee.m_StrFirstNameOfAnnouncer;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strHomeAddress=objEmployee.m_StrHomeAddress;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strHomePC=objEmployee.m_StrHomePC;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strHomePhone=objEmployee.m_StrHomePhone;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strIDCard=objEmployee.m_StrIDCard;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strLanguageAbility=objEmployee.m_StrLanguageAbility;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strLastName=objEmployee.m_StrLastName;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strLastNameOfAnnouncer=objEmployee.m_StrLastNameOfAnnouncer;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strMarried=objEmployee.m_StrMarried;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strMobile=objEmployee.m_StrMobile;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strOfficeAddress=objEmployee.m_StrOfficeAddress;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strOfficePC=objEmployee.m_StrOfficePC;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strOfficePhone=objEmployee.m_StrOfficePhone;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strPhoneOfAnnouncer=objEmployee.m_StrPhoneOfAnnouncer;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strPYCode=objEmployee.m_StrPYCode;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strRemark=objEmployee.m_StrRemark;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strSex=objEmployee.m_StrSex;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo.m_strTitleOfaTechnicalPost=objEmployee.m_StrTitleOfaTechnicalPost;
			
			

			m_cboEmployeeDeptName.SelectedIndex=-1;
//			m_cboEmployeeAreaName.Text="";
			clsDept_Desc[] objDeptArr=null;
			if(m_objManagerDomain.m_lngGetDeptArr_EmployeeCanManage(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,m_lblEmployeeEmployeeID.Text,
				out objDeptArr)<=0) return;
			m_lstEmployeeTakenDept.Items.Clear();
			if(objDeptArr==null) return;
			for(int i=0;i<objDeptArr.Length;i++)
			{
				clsDeptInfo_ManageExplorer objDeptInfo=new clsDeptInfo_ManageExplorer();
				objDeptInfo.m_strDeptID=objDeptArr[i].m_strDeptID;
				objDeptInfo.m_strDeptName=objDeptArr[i].m_strDeptName;
				m_lstEmployeeTakenDept.Items.Add(objDeptInfo);
			}
			
			

		}

		/// <summary>
		/// 显示病人Panel
		/// </summary>
		private void m_mthDisplayPnlPatient()
		{
			foreach(Control ctl in m_pnlRight.Controls)
			{
				if(ctl.GetType().Name=="Panel") ctl.Visible=false;
			}
			m_pnlPatient.Visible=true;
			m_pnlPatient.BringToFront();
			if(m_lsvManageExplorerMid.SelectedItems.Count==0)
			{
				m_lblPatientPatientID.Text="";
				m_lblPatientPatientName.Text="";
				return;
			}
		
				m_lblPatientPatientID.Text=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID;
				m_lblPatientPatientName.Text=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientName;
			
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objPatientBaseInfo.m_objPeopleInfo
				=new clsPatient(m_lblPatientPatientID.Text).m_ObjPeopleInfo;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objPatientBaseInfo.m_strPatientID
				=m_lblPatientPatientID.Text;
		

			//状态："在床"或"下床"，不从数据库读取并显示
			m_cboPatientBedStatus.ClearItem();
			m_cboPatientBedStatus.AddItem("在床");
			m_cboPatientBedStatus.AddItem("下床");
			m_cboPatientBedStatus.AddItem("转床");
			m_cboPatientBedStatus.AddItem("出院");
			m_cboPatientBedStatus.AddItem("死亡");
			m_cboPatientBedStatus.AddItem("转院");
			
			m_cboPatientBedStatus.SelectedIndex=0;
			m_cboPatientBedDept.ClearItem();
			m_cboPatientBedArea.ClearItem();
			m_cboPatientBedName.ClearItem();
			if(m_cboPatientBedStatus.SelectedItem.ToString()!="在床")
			{
				
				return;
			}
			//所在科室，若状态为下床，则空.不从数据库读取
			clsDeptInfo_ManageExplorer objDeptInfo=new clsDeptInfo_ManageExplorer();
			objDeptInfo.m_strDeptID=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Parent.Tag).m_strID;
			objDeptInfo.m_strDeptName=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Parent.Tag).m_strName;
			m_cboPatientBedDept.AddItem(objDeptInfo);
			m_cboPatientBedDept.SelectedIndex=0;
			
			//所在病区，若状态为下床，则空.不从数据库读取
			clsAreaInfo_ManageExplorer objAreaInfo=new clsAreaInfo_ManageExplorer();
			objAreaInfo.m_strAreaID=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;
			objAreaInfo.m_strAreaName=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strName;
			m_cboPatientBedArea.AddItem(objAreaInfo);
			m_cboPatientBedArea.SelectedIndex=0;
			
			//所在床，若状态为下床，则空.并更新床的相应信息. 不从数据库读取，
			m_cboPatientBedName.AddItem(m_lsvManageExplorerMid.SelectedItems[0].Tag);
			m_cboPatientBedName.SelectedIndex=0;


			//若在更新过程中病人已下床，则提示出错.

		}


		#endregion

		#region 全院Panel的相关操作
		private bool m_blnDeptCanBeAdded()
		{
			return true;
		}
		/// <summary>
		/// 输入有效性判断
		/// </summary>
		/// <returns></returns>
		private bool m_blnDeptInputValid()
		{
			
			
			
			if(m_txtTbp3DeptID.Text==null || m_txtTbp3DeptID.Text.Trim().Length==0)
			{
				clsPublicFunction.ShowInformationMessageBox("科室ID不能为空。");
				m_txtTbp3DeptID.Focus();
				return false;
			}
			if(m_txtTbp3DeptName.Text==null || m_txtTbp3DeptName.Text.Trim().Length==0)
			{
				clsPublicFunction.ShowInformationMessageBox("科室名不能为空。");
				m_txtTbp3DeptName.Focus();
				return false;
			}

			if(m_objHandlerDomain.m_lngCheckID_Dept(m_txtTbp3DeptID.Text.Trim())==(long)enmOperationResult.Record_Already_Exist)
			{
				clsPublicFunction.ShowInformationMessageBox("该ID已存在");
				m_txtTbp3DeptID.Focus();
				return false;
			}
			if(m_objHandlerDomain.m_lngCheckName_Dept(m_txtTbp3DeptName.Text.Trim())==(long)enmOperationResult.Record_Already_Exist)
			{
				if(clsPublicFunction.ShowQuestionMessageBox("与现有科室重名，是否继续？")!=DialogResult.Yes)
				{
					m_txtTbp3DeptName.Focus();
					return false;
				}
			}
			return true;
			
			
			
			
		}
		/// <summary>
		/// 向数据库添加科室
		/// </summary>
		/// <returns></returns>
		private long m_lngAddDeptSub()
		{
			clsDept_Desc objDept=m_objTbp3GetDeptFromUI();
			objDept.m_dtmCreateDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objDept.m_dtmModifyDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			long lngRes=m_objHandlerDomain.m_lngAddNewRecord_Dept(objDept);
			return lngRes;
			
		}
		/// <summary>
		/// 调用上面两个函数添加科室，成功后更新显示
		/// </summary>
		/// <returns></returns>
		private void m_mthAddDept()
		{
			if(!m_blnDeptInputValid()) return;
			if(!m_blnDeptCanBeAdded()) return;
			
			long lngRes=m_lngAddDeptSub();
			if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法添加科室。");
				return;
			}
			clsDepartment objTempDept=new clsDepartment();

			TreeNode trnNode=new TreeNode();
			clsNodeInfo objInfo= new clsNodeInfo();
			objInfo.m_intCategory=1;
			objInfo.m_strCategoryName="科室";
			objInfo.m_objDeptDesc=m_objTbp3GetDeptFromUI();
			objInfo.m_strID=objInfo.m_objDeptDesc.m_strDeptID;
			objInfo.m_strName=objInfo.m_objDeptDesc.m_strDeptName;

			trnNode.Text=objInfo.m_objDeptDesc.m_strDeptName;

			trnNode.Tag=objInfo;
			trnNode.ImageIndex=23;
			objTempDept.m_StrDeptID= objInfo.m_objDeptDesc.m_strDeptID;
			if(objTempDept.m_EnmDeptType!=enmDeptType.住院)
			{
				clsPublicFunction.ShowInformationMessageBox("已成功添加科室。由于不是住院科室，所以不在左边的树显示。");
				return;
			}

			
			m_trvManageExplorer.SelectedNode.Nodes.Add(trnNode);
			m_trvManageExplorer.ExpandAll();
			
			clsPublicFunction.ShowInformationMessageBox("已成功添加科室。");
			
		}
		
		
		#region 病人入院
		/// <summary>
		/// 病人入院
		/// </summary>
		private void m_mthAddPatientSub()
		{
			if (m_cboPatientBedArea2.Text != "" || m_cboPatientBedDept2.Text != "" || m_cboPatientBedName2.Text != "")
			{
				if(m_cboPatientBedArea2.Text.Trim()=="")
				{
					clsPublicFunction.ShowInformationMessageBox("你还没选择病区。");
					return;
				}
				if(m_cboPatientBedDept2.Text.Trim()=="")
				{
					clsPublicFunction.ShowInformationMessageBox("你还没选择科室。");
					return;
				}
				if(m_cboPatientBedName2.Text.Trim()=="")
				{
					clsPublicFunction.ShowInformationMessageBox("你还没选择病床。");
					return;
				}
			}

			#region 判断当前病人此次入院的时间是否小于病人最后一次出院的时间
			string SQL="";
			System.Data.DataTable dtRecord=null;
			SQL="select max(INPATIENTENDDATE) as MaxINPATIENTENDDATE from inpatientdateinfo where inpatientid='" + m_txtTbp1InPatientID.Text.Replace("'","''") + "'";

            com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objServ =
                (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

            objServ.m_lngGetData(SQL,ref dtRecord);
            objServ = null;

			if (dtRecord!=null)
			{
				if (dtRecord.Rows[0][0].ToString().Trim().Length>0)
				{
					if (DateTime.Parse(dtRecord.Rows[0][0].ToString())>=m_dtpInPatientDate.Value)
					{
						clsPublicFunction.ShowInformationMessageBox("病人最后一次出院时间大于病人当前入院时间，病人不能入院！");
						m_dtpInPatientDate.Focus();
						return ;
					}
				}
			}
			#endregion 判断当前病人此次入院的时间是否小于病人最后一次出院的时间

			if(m_blnIsOldPatient)
			{
				if(m_txtTbp1InPatientID.Text==null || m_txtTbp1InPatientID.Text.Trim().Length==0)
				{
					clsPublicFunction.ShowInformationMessageBox("住院号不能为空。");
					return;
				}
				if(m_txtTbp1InPatientID.Text.Trim().Length>12)
				{
					clsPublicFunction.ShowInformationMessageBox("住院号长度不能大于12。");
					return;
				}
				if(m_objHandlerDomain.m_lngCheckID_Patient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_txtTbp1InPatientID.Text.Trim())!=(long)enmOperationResult.Record_Already_Exist)
				{
					clsPublicFunction.ShowInformationMessageBox("这不是旧病人，请去掉右上\"旧病人入院\"前的勾。");
					return;
				}
//				if(m
				clsPatient objTempOldPatient= new clsPatient(m_txtTbp1InPatientID.Text.Trim());

				if(objTempOldPatient.m_ObjInBedInfo==null || objTempOldPatient.m_ObjInBedInfo.m_ObjLastSessionInfo==null
					||(objTempOldPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmOutDate!=DateTime.MinValue
					&&objTempOldPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmOutDate!=DateTime.Parse("1900-1-1")))
				{
					
					if(m_objHandlerDomain.m_lngAddNewInPatientDateInfo(m_txtTbp1InPatientID.Text.Trim(),m_dtpInPatientDate.Value)<=0)
					{
						clsPublicFunction.ShowInformationMessageBox("无法让病人入院。");
						return ;
					}
					else
					{
						m_mthBedAddPatientToBed2();
						clsPublicFunction.ShowInformationMessageBox("病人已成功入院。");
						m_cboPatientBedName2.ClearItem();
						
						return;
					}
				}
				else
				{
					clsPublicFunction.ShowInformationMessageBox("这不是旧病人，请去掉右上\"旧病人入院\"前的勾。");
					return;
				}
				
			}
			clsPatientBaseInfo objPatientInfo=m_objTbp1GetPatientFromUI();
			
			if(objPatientInfo==null || objPatientInfo.m_strInPatientID==null || objPatientInfo.m_strInPatientID=="")
			{
				return;
			}
			long lngTemp=m_objHandlerDomain.m_lngCheckID_Patient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, objPatientInfo.m_strInPatientID);
			if(lngTemp!=(long)enmOperationResult.Record_Already_Exist)
			{
				if(m_objHandlerDomain.m_lngAddNewPatientBaseInfo2(objPatientInfo)<=0)
				{
					clsPublicFunction.ShowInformationMessageBox("病人信息不正确，请重新操作。");
					return;
				}
				if(m_objHandlerDomain.m_lngAddNewInPatientDateInfo(objPatientInfo.m_strInPatientID,m_dtpInPatientDate.Value)<=0)
				{
					clsPublicFunction.ShowInformationMessageBox("无法让病人入院。");
					return ;
				}
				else
				{
					m_mthBedAddPatientToBed2();
					clsPublicFunction.ShowInformationMessageBox("病人已成功入院。");
					m_cboPatientBedName2.ClearItem();
					return;
				}
			}
			clsPatient objTempPatient= new clsPatient(objPatientInfo.m_strInPatientID);

			if(objTempPatient.m_ObjInBedInfo==null || objTempPatient.m_ObjInBedInfo.m_ObjLastSessionInfo==null
				||(objTempPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmOutDate!=DateTime.MinValue
				&&objTempPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmOutDate!=DateTime.Parse("1900-1-1")))
			{
				clsPublicFunction.ShowInformationMessageBox("此住院号属于已出院的旧病人。若是旧病人入院请在右上方\"旧病人入院\"处打勾。");
				return;
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("病人已在住院，不能重复入院。");
				return;

				#region 旧的病人重复入院处理作废
//				if(clsPublicFunction.ShowQuestionMessageBox("病人已在住院，不能重复入院。是否保存刚才对病人信息的修改？")==DialogResult.Yes)
//				{
//					
//					if(m_objHandlerDomain.m_lngModifyPatientBaseInfo2(objPatientInfo)<=0)
//					{
//						clsPublicFunction.ShowInformationMessageBox("无法保存病人信息。");
//						return ;
//					}
//					else
//					{
//						m_mthBedAddPatientToBed2();
//						clsPublicFunction.ShowInformationMessageBox("已成功保存修改后的病人信息。");
//						return;
//					}
//				}
			#endregion 旧的病人重复入院处理作废
				
			}		
		}
			
		/// <summary>
		/// 病人入院
		/// </summary>
		/// <returns></returns>
		private void m_mthAddPatient()
		{
			m_mthAddPatientSub();
		}
			


		#endregion

		#region 员工入职
		/// <summary>
		/// 员工入职
		/// </summary>
		/// <returns></returns>
		private void m_mthAddEmployeeSub()
		{
			
			clsEmployee_BaseInfo objEmployee= m_objTbp2GetEmployeeFromUI();
			if(objEmployee==null) return ;
			if(m_objHandlerDomain.m_lngCheckID_Employee(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,objEmployee.m_strEmployeeID)==(long)enmOperationResult.Record_Already_Exist)
			{
				clsEmployee objTempEmployee=new clsEmployee(objEmployee.m_strEmployeeID);
				if(objTempEmployee==null || objTempEmployee.m_StrStatus=="1" || objTempEmployee.m_StrStatus=="True")
				{

					//clsPublicFunction.ShowInformationMessageBox("员工ID已存在，无法添加。");
					if(clsPublicFunction.ShowQuestionMessageBox("员工ID已存在，是否重新分配此员工ID?")==DialogResult.Yes)
					{
						objEmployee.m_dtmBeginDate=objTempEmployee.m_DtmBeginDate == DateTime.MinValue ? DateTime.Parse("1900-1-1") : objTempEmployee.m_DtmBeginDate;
						long lngRes=m_objHandlerDomain.m_lngModifyEmployeeBaseInfo(objEmployee);
					}
					m_txtTbp2EmployeeID.Focus();
					return;
				}
				else
				{
					if(clsPublicFunction.ShowQuestionMessageBox("该员工已存在，无法重新入职。是否要保存对员工资料的修改？")==DialogResult.Yes)
					{
//						clsEmployee objTempEmployee=new clsEmployee(objEmployee.m_strEmployeeID);
						objEmployee.m_dtmBeginDate=objTempEmployee.m_DtmBeginDate == DateTime.MinValue ? DateTime.Parse("1900-1-1") : objTempEmployee.m_DtmBeginDate;
						long lngRes=m_objHandlerDomain.m_lngModifyEmployeeBaseInfo(objEmployee);
						if(lngRes<=0)
						{
							
							clsPublicFunction.ShowInformationMessageBox("无法保存修改。");
							return;
						}
					}
					m_txtTbp2EmployeeID.Focus();
					return;
				}
				
			}
			objEmployee.m_dtmBeginDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			if(m_objHandlerDomain.m_lngAddNewEmployeeBaseInfo(objEmployee)<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法添加员工。");
				m_txtTbp2EmployeeID.Focus();
				return ;
			}
			clsPublicFunction.ShowInformationMessageBox("已成功添加员工。");
		}
		/// <summary>
		/// 员工入职
		/// </summary>
		/// <returns></returns>
		private void m_mthAddEmployee()
		{
			m_mthAddEmployeeSub();
		}
		
		#endregion

		/// <summary>
		/// 这个函数暂时不用
		/// </summary>
		
		
		#endregion

		#region 科室Panel的相关操作
		
		#region 添加病区
		private bool m_blnDeptAreaCanBeAdded()
		{
			return true;
		}
		/// <summary>
		/// 判断新病区的信息有效性
		/// </summary>
		/// <returns></returns>
		private bool m_blnDeptAreaInputValid()
		{
			m_txtDeptNewAreaID.Text=m_txtDeptNewAreaID.Text.Trim();
			m_txtDeptNewAreaName.Text=m_txtDeptNewAreaName.Text.Trim();
			if(m_txtDeptNewAreaID.Text==null || m_txtDeptNewAreaID.Text.Trim().Length==0)
			{
				clsPublicFunction.ShowInformationMessageBox("ID不能为空。");
				return false;
			}
			if(m_txtDeptNewAreaName.Text==null || m_txtDeptNewAreaName.Text.Trim().Length==0)
			{
				clsPublicFunction.ShowInformationMessageBox("病区名不能为空。");
				return false;
			}
			if(m_txtDeptNewAreaID.Text.Length>7)
			{
				clsPublicFunction.ShowInformationMessageBox("ID的长度不能大于7.");
				m_txtDeptNewAreaID.Focus();
				return false;
			}
			
			if(m_objHandlerDomain.m_lngCheckID_Area(m_txtDeptNewAreaID.Text)==(long)enmOperationResult.Record_Already_Exist)
			{
				clsPublicFunction.ShowInformationMessageBox("ID格式错误或已存在，无法添加。");
				m_txtDeptNewAreaID.Focus();
				return false;
			}
			if(m_objHandlerDomain.m_lngCheckName_Area(m_txtDeptNewAreaName.Text)==(long)enmOperationResult.Record_Already_Exist)
			{
//				if(clsPublicFunction.ShowQuestionMessageBox("病区名已存在，是否继续？")!=DialogResult.Yes)
//				{
//					m_txtDeptNewAreaName.Focus();
//					return false;
//				}
				clsPublicFunction.ShowInformationMessageBox("病区名已存在，请重新填写病区名称。");
				m_txtDeptNewAreaName.Focus();
				return false;
			}
			return true;
		}
		/// <summary>
		/// 向数据库添加病区
		/// </summary>
		/// <returns></returns>
		private long m_lngDeptAddAreaSub()
		{
			clsArea_Desc objArea=new clsArea_Desc();
			objArea.m_dtmBegin_Date_Area_Naming=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objArea.m_dtmEnd_Date_Area=DateTime.Parse("1900-1-1 00:00:00");
			objArea.m_strArea_ID=m_txtDeptNewAreaID.Text.Trim();
			objArea.m_strArea_Name=m_txtDeptNewAreaName.Text.Trim();
			objArea.m_strParentDeptID=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;
			return m_objHandlerDomain.m_lngAddNewRecord_Area(objArea);
		}
		/// <summary>
		/// 调用上两个函数添加病区，并更新显示
		/// </summary>
		/// <returns></returns>
		private void m_mthDeptAddArea()
		{
			if(!m_blnDeptAreaInputValid()) return;
			if(!m_blnDeptAreaCanBeAdded()) return;
			
			long lngRes=m_lngDeptAddAreaSub();
			if(lngRes<=0)
			{
				MessageBox.Show("添加失败,请刷新");
				return;
			}
			TreeNode trnNode=new TreeNode();
			clsNodeInfo objInfo= new clsNodeInfo();
			objInfo.m_intCategory=2;
			objInfo.m_strCategoryName="病区";
			objInfo.m_strID=m_txtDeptNewAreaID.Text;
			objInfo.m_strName=m_txtDeptNewAreaName.Text;
			trnNode.Text=objInfo.m_strName;
			//objInfo.m_objChildCategory=new clsNodeInfo();
			//objInfo.m_objChildCategory.m_intCategory=2;
			//objInfo.m_objChildCategory.m_strCategoryName="病区";
			trnNode.Tag=objInfo;
			trnNode.ImageIndex=2;
			m_trvManageExplorer.SelectedNode.Nodes.Add(trnNode);
			m_trvManageExplorer.ExpandAll();
		}
		
		#endregion

		#region 删除本科室
//		private bool m_blnDeptInputValid()
//		{
//			return true;
//		}
//		private long m_lngDeptRenameSub()
//		{
//			return 1;
//		}
	

		private bool m_blnDeptCanBeDeleted()
		{
			if(clsPublicFunction.ShowQuestionMessageBox("是否要删除该科室？")!=DialogResult.Yes)
			{
				return false;
			}
			return true;
		}
		private long m_lngDeptDeleteSub()
		{
			try
			{
				clsDept_Desc objDept=new clsDept_Desc();
			
				objDept.m_dtmDeActivedDate=DateTime.Parse( new clsPublicDomain().m_strGetServerTime());
				objDept.m_strDeptID=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;
				objDept.m_strDeActivedOperatorID=MDIParent.OperatorID;
				return m_objHandlerDomain.m_lngDeleteRecord_Dept(objDept);	
				
			}
			catch
			{
				return -1;
			}
		}
		private void m_mthDeptDelete()
		{
			if(!m_blnDeptCanBeDeleted()) return;
			
			if(m_lngDeptDeleteSub()<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("科室下还有病区，无法删除。");
				return;
			}
			TreeNode objTempNode=null;
			if(m_trvManageExplorer.SelectedNode.PrevNode!=null)
			{
				objTempNode=m_trvManageExplorer.SelectedNode.PrevNode;
			}
			else if(m_trvManageExplorer.SelectedNode.NextNode!=null)
			{
				objTempNode=m_trvManageExplorer.SelectedNode.NextNode;
			}
			else
			{
				objTempNode=m_trvManageExplorer.SelectedNode.Parent;
			}
			m_trvManageExplorer.SelectedNode.Remove();
			m_trvManageExplorer.SelectedNode=objTempNode;

		}

		#endregion

		#region Add Employee
		private bool m_blnDeptEmployeeCanBeAdded()
		{
			return true;
		}
		/// <summary>
		/// 获得数据库和LIST VIEW操作都在这个函数中进行
		/// </summary>
		/// <returns></returns>
		private bool m_blnDeptEmployeeInputValid()
		{
			m_txtDeptAddEmployeeID.Text=m_txtDeptAddEmployeeID.Text.Trim();
			m_txtDeptAddEmployeeName.Text=m_txtDeptAddEmployeeName.Text.Trim();
			if(m_txtDeptAddEmployeeID.Text==null ||m_txtDeptAddEmployeeID.Text=="")
			{
				clsPublicFunction.ShowInformationMessageBox("员工ID不能为空。");
				return false;
			}
			if(m_objHandlerDomain.m_lngCheckID_Employee(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,m_txtDeptAddEmployeeID.Text)!=(long)enmOperationResult.Record_Already_Exist)
			{
				clsPublicFunction.ShowInformationMessageBox("员工不存在，无法调入。");
				return false;
			}
			clsEmployee objTempEmployee=new clsEmployee(m_txtDeptAddEmployeeID.Text);
			if(objTempEmployee.m_StrStatus=="True" || objTempEmployee.m_StrStatus=="1")
			{
				clsPublicFunction.ShowInformationMessageBox("员工已不是医院职工，无法调入。");
				return false;
			}
			clsEmployee_BaseInfo[] objEmployeeArr=null;
			if(m_objManagerDomain.m_lngGetEmployeeArrInDept(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,
				((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID,out objEmployeeArr)<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法连接数据库。");
				return false;
			}
			if(objEmployeeArr==null) return true;
			for(int i=0;i<objEmployeeArr.Length;i++)
			{
				if(m_txtDeptAddEmployeeID.Text.Trim()==objEmployeeArr[i].m_strEmployeeID.Trim())
				{
					clsPublicFunction.ShowInformationMessageBox("员工已在本科室任职，无法重复调入。");
					return false;
				}
			}

			return true;
		}
		private long m_lngDeptAddEmployeeSub()
		{
			clsDept_Employee objDept=new clsDept_Employee();
			//objAreaDept.m_dtmBegin_Date_Area_Dept=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objDept.m_dtmModifyDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objDept.m_dtmEndDate=DateTime.Parse("1900-1-1- 00:00:00");
			
			objDept.m_strDeptID=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;
			objDept.m_strEmployeeID=m_txtDeptAddEmployeeID.Text;
			long lngRes=1;
			lngRes=m_objHandlerDomain.m_lngAssignDept_Employee(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,objDept);
			if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法调入员工。");
				return lngRes;
			}

			ListViewItem objLsvItem=new ListViewItem();
			objLsvItem.Tag=new clsEmployeeInfo_ManageExplorer();
			
			((clsEmployeeInfo_ManageExplorer)objLsvItem.Tag).m_strEmployeeID=objDept.m_strEmployeeID;
			((clsEmployeeInfo_ManageExplorer)objLsvItem.Tag).m_strEmployeeName=new clsEmployee(objDept.m_strEmployeeID).m_StrFirstName;
			objLsvItem.Text=((clsEmployeeInfo_ManageExplorer)objLsvItem.Tag).m_strEmployeeName.Trim();
			objLsvItem.ImageIndex=2;
			m_lsvManageExplorerMid.Items.Add(objLsvItem);
			m_txtDeptAddEmployeeID.Text = "";
			m_txtDeptAddEmployeeName.Text = "";
			return lngRes;
		}
		private void m_mthDeptAddEmployee()
		{
			if(!m_blnDeptEmployeeCanBeAdded()) return;
			if(!m_blnDeptEmployeeInputValid()) return;
			if(m_lngDeptAddEmployeeSub()<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("添加失败，请刷新。");
				return;
			}
			//			clsEmployeeInfo_ManageExplorer objEmployee=new clsEmployeeInfo_ManageExplorer();
			////			objEmployee.m_strEmployeeID=m_txtAreaNewEmployeeID.Text;
			////			objEmployee.m_strEmployeeName=m_txtAreaNewEmployeeName.Text;
			//			ListViewItem objItem=new ListViewItem(objEmployee.m_strEmployeeName);
			//			objItem.Tag=new clsEmployeeInfo_ManageExplorer();
			//			((clsEmployeeInfo_ManageExplorer)objItem.Tag).m_objEmployeeBaseInfo=objEmployee;
			//			((clsEmployeeInfo_ManageExplorer)objItem.Tag).m_strEmployeeID=objEmployee.;
			//			objItem.ImageIndex=3;//员工在职
			//			m_lsvManageExplorerMid.Items.Add(objItem);
			
		}

		#endregion

		//Rename
		private bool m_blnDeptChangeInfoSub()
		{
			clsDept_Desc objDeptDesc = ((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc;
			string strOldDeptName = objDeptDesc.m_strDeptName.Trim();
			frmDeptDetailInfo frmForm=new frmDeptDetailInfo(objDeptDesc);
			if(frmForm.ShowDialog()!=DialogResult.Yes) return false;
			clsDept_Desc objDept=frmForm.m_objGetContentValue();
			
			if(objDept.m_strDeptID==null || objDept.m_strDeptID=="") return false;
			if(objDept.m_strDeptName==null || objDept.m_strDeptName=="") return false;

			if(m_objHandlerDomain.m_lngCheckName_Bed(objDept.m_strDeptName)==(long)enmOperationResult.Record_Already_Exist)
			{
				if(clsPublicFunction.ShowInformationMessageBox("与现有科室重名，是否继续？")!=DialogResult.Yes)
				{
					return false;
				}
			}
			if(m_objHandlerDomain.m_lngModifyRecord_Dept(objDept,strOldDeptName)<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法保存修改。");
				return false;
			}
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_objDeptDesc=objDept;
			((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strName=objDept.m_strDeptName;
			return true;
		}
		private  void m_mthDeptChangeInfo()
		{
			m_blnDeptChangeInfoSub();
		}



		#endregion
		
		#region 病区Panel的相关操作

		#region Add Bed
		private bool m_blnAreaBedInputValid()
		{
//			m_txtAreaNewBedID.Text=m_txtAreaNewBedID.Text.Trim();
			string strBedName = m_txtAreaNewBedName.Text.Trim();
//			m_txtAreaNewBedName.Text=m_txtAreaNewBedName.Text.Trim();
//			if(m_txtAreaNewBedName.Text==null || m_txtAreaNewBedName.Text.Trim()=="")
			if(strBedName == "")
			{
				clsPublicFunction.ShowInformationMessageBox("病床名不能为空。");
				m_txtAreaNewBedName.Focus();
				return false;
			}
			for(int i=0;i<m_lsvManageExplorerMid.Items.Count;i++)
				//if(strBedName == m_lsvManageExplorerMid.Items[i].Text)
				if(strBedName.Trim().ToUpper()==((clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag).m_strBedName.Trim().ToUpper())
				{
					
					clsPublicFunction.ShowInformationMessageBox("与现有病床名重复，请选择其他病床名!");
					return false;
				}
//			if(m_txtAreaNewBedID.Text==null || m_txtAreaNewBedID.Text.Trim()=="")
//			{
//				clsPublicFunction.ShowInformationMessageBox("病床ID不能为空。");
//				m_txtAreaNewBedID.Focus();
//				return false;
//			}
//			if(m_txtAreaNewBedID.Text.Length>4)
//			{
//				clsPublicFunction.ShowInformationMessageBox("ID的长度不能大于4.");
//				return false;
//			}
			
//			if(m_objHandlerDomain.m_lngCheckID_Bed(m_txtAreaNewBedID.Text.Trim())==(long)enmOperationResult.Record_Already_Exist)
//			{
//				clsPublicFunction.ShowInformationMessageBox("该ID已存在");
//				return false;
//			}
//			if(m_objHandlerDomain.m_lngCheckName_Bed(m_txtAreaNewBedName.Text.Trim())==(long)enmOperationResult.Record_Already_Exist)
//			{
//				if(clsPublicFunction.ShowQuestionMessageBox("与现有病床重名，是否继续？")!=DialogResult.Yes)
//				{
//					return false;
//				}
//			}
			
			
			return true;
		}
		private long m_lngAreaAddBedSub(out string p_strBedID)
		{
			clsBed_Desc objBed=new clsBed_Desc();
			objBed.m_dtmBegin_Date_Bed_Naming=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objBed.m_dtmEnd_Date_Bed=DateTime.Parse("1900-1-1");
			objBed.m_strBed_Name=m_txtAreaNewBedName.Text;
			objBed.m_strParentAreaID_OfParentRoom=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;
			return m_objHandlerDomain.m_lngAddNewRecord_Bed(objBed,out p_strBedID);
		}
		private void m_mthAreaAddBed()
		{
			if(!m_blnAreaBedInputValid()) 
				return;

			string strBedID;

			if(m_lngAreaAddBedSub(out strBedID)<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("添加失败，请刷新");
				return;
			}
			clsBedInfo objBed=new clsBedInfo();
			objBed.m_strBedID = strBedID;
			objBed.m_strBedName=m_txtAreaNewBedName.Text;
			ListViewItem objItem=new ListViewItem(objBed.m_strBedName);
			objItem.Tag=objBed;
			objItem.ImageIndex=0;
			m_lsvManageExplorerMid.Items.Add(objItem);
			
		}
		
		#endregion

		

		#region Rename
		private bool m_blnAreaInfoValid()
		{
			m_txtAreaAreaName.Text=m_txtAreaAreaName.Text.Trim();
			if(m_txtAreaAreaName.Text=="" || m_txtAreaAreaName.Text==null)
			{
				clsPublicFunction.ShowInformationMessageBox("病区名不能为空。");
				return false;
			}
			if(m_objHandlerDomain.m_lngCheckName_Area(m_txtAreaAreaName.Text)==(long)enmOperationResult.Record_Already_Exist)
			{
				if(clsPublicFunction.ShowQuestionMessageBox("新名称与已有病区重名，是否继续？")!=DialogResult.Yes)
				{
					return false;
				}
			}
			return true;
		}
		private long m_lngAreaRenameSub()
		{
			clsArea_Desc objNewArea=new clsArea_Desc();
			objNewArea=((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_objAreaDesc;
			objNewArea.m_dtmBegin_Date_Area_Naming=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objNewArea.m_dtmEnd_Date_Area=DateTime.Parse("1900-1-1 00:00:00");
			objNewArea.m_strArea_Name=m_txtAreaAreaName.Text;
			//clsArea objArea= new clsArea(strID);
//			objNewArea.m_dtmBegin_Date_Area_Naming=
//				DateTime.Parse(((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_strBeginDate);
//			objNewArea.m_dtmEnd_Date_Area=new clsPublicDomain().m_strGetServerTime();
//			objNewArea.m_strArea_ID=((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_strID;
//			objNewArea.m_strArea_Name=m_txtAreaAreaName.Text;
//			objNewArea.m_strParentDeptID=((clsNodeInfo) m_trvManageExplorer.SelectedNode.Parent.Tag).m_strID;
			return m_objHandlerDomain.m_lngModifyRecord_Area(objNewArea);
			
		}
		private void m_mthAreaRename()
		{
			if(!m_blnAreaInfoValid()) return;
			
			if(m_lngAreaRenameSub()<=0)
			{
				MessageBox.Show("重命名失败，请刷新");
				return;
			}
			
			((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_strName=m_txtAreaAreaName.Text;
			m_trvManageExplorer.SelectedNode.Text= ((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_strName;
										   
		}

		#endregion

		#region Delete
		private bool m_blnAreaCanBeDeleted()
		{
			if(clsPublicFunction.ShowQuestionMessageBox("是否要删除该病区？")!=DialogResult.Yes)
			{
				return false;
			}
			return true;
		}
		private long m_lngAreaDeleteSub()
		{
			long lngRes=1;
			try
			{

				clsInPatientRoom[] objRoomArr=null;
				lngRes=m_objManagerDomain.m_lngGetAllRoomInArea(((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID,
					out objRoomArr);
				if(lngRes<=0) return lngRes;
				if(objRoomArr!=null)
				{
					for(int i=0;i<objRoomArr.Length;i++)
					{
						clsRoom_Desc objRoom=new clsRoom_Desc();
						objRoom.m_dtmEnd_Date_Room=DateTime.Parse( new clsPublicDomain().m_strGetServerTime());
						objRoom.m_strRoom_ID=objRoomArr[i].m_StrRoomID;
						lngRes= m_objHandlerDomain.m_lngDeleteRecord_Room(objRoom);
						if(lngRes<=0) return lngRes;
					}
				}
				clsArea_Desc objArea= new clsArea_Desc();
				objArea.m_dtmEnd_Date_Area=DateTime.Parse( new clsPublicDomain().m_strGetServerTime());
				objArea.m_strArea_ID=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;
				return m_objHandlerDomain.m_lngDeleteRecord_Area(objArea);
			}
			catch
			{
				return (long)enmOperationResult.Parameter_Error;
			}
		}
		private void m_mthAreaDelete()
		{
			if(!m_blnAreaCanBeDeleted()) return;
			if(m_lngAreaDeleteSub()<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("病区下还有病床，无法删除。");
				return;
			}
			TreeNode objTempNode=null;
			if(m_trvManageExplorer.SelectedNode.PrevNode!=null)
			{
				objTempNode=m_trvManageExplorer.SelectedNode.PrevNode;
			}
			else if(m_trvManageExplorer.SelectedNode.NextNode!=null)
			{
				objTempNode=m_trvManageExplorer.SelectedNode.NextNode;
			}
			else if(m_trvManageExplorer.SelectedNode.Parent!=null)
			{
				objTempNode=m_trvManageExplorer.SelectedNode.Parent;
			}
			m_trvManageExplorer.SelectedNode.Remove();
			m_trvManageExplorer.SelectedNode=objTempNode;

		}

		#endregion

		#endregion

		#region 病床Panel的相关操作

		
		private bool m_blnBedInputValid()
		{
			if(m_lsvManageExplorerMid.SelectedItems.Count==0)
			{
				return false;
			}
			m_txtBedBedName.Text=m_txtBedBedName.Text.Trim();
			if(m_txtBedBedName.Text==null || m_txtBedBedName.Text=="") return false;
			if(m_objHandlerDomain.m_lngCheckName_Bed(m_txtBedBedName.Text)==(long)enmOperationResult.Record_Already_Exist)
			{
				if(clsPublicFunction.ShowQuestionMessageBox("与现有病床重名，是否继续？")==DialogResult.No)
				{
					return false;
				}
			}
			return true;
		}
		private long m_lngBedRenameSub()
		{

			clsBed_Desc objBed=new clsBed_Desc();
			objBed.m_dtmBegin_Date_Bed_Naming=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
//			objBed.m_dtmEnd_Date_Bed= DateTime.Parse(((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedEndDate);
			objBed.m_strBed_ID=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedID;
			objBed.m_strBed_Name=m_txtBedBedName.Text;
			
			return m_objHandlerDomain.m_lngModifyRecord_Bed(objBed);
			
		}
		private void m_mthBedRename()
		{
			if(!m_blnBedInputValid()) return;
			
			if(m_lngBedRenameSub()<=0)
			{
				MessageBox.Show("重命名失败，请刷新");
				return;
			}
			
			((clsBedInfo) m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName=m_txtBedBedName.Text.Trim();
			m_lsvManageExplorerMid.SelectedItems[0].Text=m_txtBedBedName.Text.Trim();
			
										   
		}

		/// <summary>
		/// 向LISTBOX装入病人信息信息
		/// </summary>
		/// <returns></returns>
		private void m_mthBedLoadAvailablePatient()
		{
			m_cboBedAddPatient.ClearItem();
			// 查数据库装入病人信息
			string[,] objPatientIDArr=null;
			long lngRes=m_objManagerDomain.m_lngGetPatientArrThatNotHasBed(out objPatientIDArr);
			if(lngRes<=0 || objPatientIDArr==null)
			{
				//				clsPublicFunction.ShowInformationMessageBox("所有病人已分配病床");
				return;
			}
			for(int i=0;i<objPatientIDArr.GetLength(0);i++)
			{
				clsInPatientInfo_ManageExplorer objCboPatient=new clsInPatientInfo_ManageExplorer();
				objCboPatient.m_strInPatientID=objPatientIDArr[i,0];
				objCboPatient.m_strInPatientName=objPatientIDArr[i,1];
//				clsPatient objPatient=new clsPatient(objCboPatient.m_strInPatientID);
//
//				if(objPatient.m_ObjPeopleInfo == null)
//					continue;

//				objCboPatient.m_strInPatientName=objPatient.m_ObjPeopleInfo.m_StrFirstName;
//				objCboPatient.m_strInPatientDate=objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
				m_cboBedAddPatient.AddItem(objCboPatient);
			}	
			
			return;
		}
		/// <summary>
		/// 入院用
		/// </summary>
		private void m_mthBedAddPatientToBed2()
		{
			m_lngBedAddPatientToBed2();
		}
		/// <summary>
		/// 入院用
		/// </summary>
		/// <returns></returns>
		private long m_lngBedAddPatientToBed2()
		{
			
			clsDeptAndAreaInfo[] objDeptAndAreaInfoArr=null;
			long lngRes=m_objManagerDomain.m_lngGetAllDeptAndAreaInfoArr(out objDeptAndAreaInfoArr);
			if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
				return lngRes;
			}
			else if(objDeptAndAreaInfoArr==null ) return -1;
			
			clsInDeptInfo objDept=new clsInDeptInfo();
			
			objDept.m_dtmModifyDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			for(int i1=0;i1<objDeptAndAreaInfoArr.Length;i1++)
			{
				int intIndex = -1;
				for(int j2=0;j2<objDeptAndAreaInfoArr[i1].m_objAreaArr.Length;j2++)
				{
					if (objDeptAndAreaInfoArr[i1].m_objAreaArr[j2].m_StrAreaName == m_cboPatientBedArea2.Text)
					{
						intIndex = j2;
						break;
					}
				}
				if (intIndex != -1)
				{
					objDept.m_strArea_ID=objDeptAndAreaInfoArr[i1].m_objAreaArr[intIndex].m_StrAreaID;
					break;
				}

			}
			for(int i1=0;i1<objDeptAndAreaInfoArr.Length;i1++)
			{
				if (objDeptAndAreaInfoArr[i1].m_objDept.m_StrDeptName == m_cboPatientBedDept2.Text)
				{
					objDept.m_strInDeptID=objDeptAndAreaInfoArr[i1].m_objDept.m_StrDeptID;
					break;
				}
			}
			clsInPatientBed[] objBedArr=null;
			clsPatient[] objPatientArr=null;
			if(m_objManagerDomain.m_lngGetAllBedAndPatientInArea(objDept.m_strArea_ID,out objBedArr,out objPatientArr)<=0)
				return -1;
			if(objBedArr==null || objPatientArr==null || objBedArr.Length<objPatientArr.Length)
				return -1;
			for(int i=0;i<objBedArr.Length;i++)
			{
				if(objPatientArr[i] == null && objBedArr[i].m_StrBedName == m_cboPatientBedName2.Text)
				{
					objDept.m_strBed_ID = objBedArr[i].m_StrBedID;
					break;
				}
			}
			objDept.m_strInPatientID=m_txtTbp1InPatientID.Text;
			clsInPatientRoom[] objRoomArr=null;
			lngRes=1;
			lngRes=m_objManagerDomain.m_lngGetAllRoomInArea(objDept.m_strArea_ID,out objRoomArr);
			if(lngRes<=0) return lngRes;
			if(objRoomArr==null||objRoomArr.Length!=1) return (long)enmOperationResult.DB_Fail;
			objDept.m_strRoom_ID=objRoomArr[0].m_StrRoomID;

			lngRes=m_objHandlerDomain.m_lngAssignPatientToBed(objDept);
			if(lngRes<=0) return lngRes;
			return lngRes;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private long m_lngBedAddPatientToBed()
		{
			clsInDeptInfo objDept=new clsInDeptInfo();
			
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择病床。");
				return (long)enmOperationResult.Parameter_Error;
			}

//			objDept.m_dtmInPatientDate=objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate;
			objDept.m_dtmModifyDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objDept.m_strArea_ID=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID;
			objDept.m_strInDeptID=((clsNodeInfo)m_trvManageExplorer.SelectedNode.Parent.Tag).m_strID;
			objDept.m_strBed_ID=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedID;
			objDept.m_strInPatientID=((clsInPatientInfo_ManageExplorer)m_cboBedAddPatient.SelectedItem).m_strInPatientID;
			clsInPatientRoom[] objRoomArr=null;
			long lngRes=1;
			lngRes=m_objManagerDomain.m_lngGetAllRoomInArea(objDept.m_strArea_ID,out objRoomArr);
			if(lngRes<=0) return lngRes;
			if(objRoomArr==null||objRoomArr.Length!=1) return (long)enmOperationResult.DB_Fail;
			objDept.m_strRoom_ID=objRoomArr[0].m_StrRoomID;

			lngRes=m_objHandlerDomain.m_lngAssignPatientToBed(objDept);
			if(lngRes<=0) return lngRes;
			clsPatient objPatient = new clsPatient(((clsInPatientInfo_ManageExplorer)m_cboBedAddPatient.SelectedItem).m_strInPatientID);
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objPatientBaseInfo=new clsPatientBaseInfo();
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objPatientBaseInfo.m_objPeopleInfo=objPatient.m_ObjPeopleInfo;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objPatientBaseInfo.m_strInPatientID=objPatient.m_StrInPatientID;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objPatientBaseInfo.m_strInPatientID=objPatient.m_ObjPeopleInfo.m_StrFirstName;
			return lngRes;
			
			
		}
		private void m_mthBedAddPatientToBed()
		{
//			if(!m_blnBedLoadAvailablePatient()) return;

			if(m_cboBedAddPatient.SelectedItem==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择病人。");
				return;
			}
			if(m_lngBedAddPatientToBed()<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法为病人分配该床位。");
				return;
			}
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择病床。");
				return;
			}
			m_lsvManageExplorerMid.SelectedItems[0].ImageIndex=1;
			m_lsvManageExplorerMid.SelectedItems[0].Text=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName+"\n"+m_cboBedAddPatient.Text;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID=((clsInPatientInfo_ManageExplorer) m_cboBedAddPatient.SelectedItem).m_strInPatientID;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientName=((clsInPatientInfo_ManageExplorer) m_cboBedAddPatient.SelectedItem).m_strInPatientName;
			
//			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientDate=((clsInPatientInfo_ManageExplorer) m_cboBedAddPatient.SelectedItem).m_strInPatientDate;
			m_mthDisplayPnlPatient();
		
		}


		private bool m_blnBedCanBeDeleted()
		{
			if(clsPublicFunction.ShowQuestionMessageBox("你是否要删除该病床？")==DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private long m_lngBedDeleteBedSub()
		{
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return (long) enmOperationResult.Parameter_Error;
			clsBed_Desc objBed=new clsBed_Desc();
			objBed.m_dtmEnd_Date_Bed=DateTime.Parse( new clsPublicDomain().m_strGetServerTime());
			objBed.m_strBed_ID=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedID;
			return m_objHandlerDomain.m_lngDeleteRecord_Bed(objBed);
			
		}
		private void m_mthBedDeleteBed()
		{
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return;
			if(!m_blnBedCanBeDeleted()) return;
			if(m_lngBedDeleteBedSub()<=0) return;
			m_lsvManageExplorerMid.SelectedItems[0].Remove();
//			if(m_lsvManageExplorerMid.Items.Count>0)
//			{
//				m_lsvManageExplorerMid.SelectedItems[0]=m_lsvManageExplorerMid.Items[0];
//			}
		}



	


		#endregion

		#region 员工Panel的相关操作
		private bool m_blnEmployeeDeptCanBedAdded()
		{
			// 
			if(m_cboEmployeeDeptName.SelectedItem==null )
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择科室。");
				return false;
			}
			bool RecordExists=false;
			for(int i=0;i<m_lstEmployeeTakenDept.Items.Count;i++)
			{
				if(((clsDeptInfo_ManageExplorer)m_lstEmployeeTakenDept.Items[i]).m_strDeptID==
					((clsDeptInfo_ManageExplorer)m_cboEmployeeDeptName.SelectedItem).m_strDeptID)
				{
					
						RecordExists=true;
						clsPublicFunction.ShowInformationMessageBox("该部门已存在，无法重复添加。");
						return !RecordExists;
					
				}
			}
			return !RecordExists;
		}
		private long m_lngEmployeeAddDeptSub()
		{
			clsDept_Employee objDept=new clsDept_Employee();
			objDept.m_dtmModifyDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return (long)enmOperationResult.Parameter_Error;
			objDept.m_strDeptID=((clsDeptInfo_ManageExplorer)m_cboEmployeeDeptName.SelectedItem).m_strDeptID;
			objDept.m_strEmployeeID=((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strEmployeeID;
//			objDept.m_strOperatorID=MDIParent.OperatorID;
			
			return m_objHandlerDomain.m_lngAssignDept_Employee(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,objDept);
			
			
		}
		private void m_mthEmployeeAddDept()
		{
			if(!m_blnEmployeeDeptCanBedAdded())
			{
				
				return;
			}
			if(m_lngEmployeeAddDeptSub()<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法添加，请刷新");
				return;
			}
//			if(m_cboEmployeeDeptName.SelectedItem==null || m_cboEmployeeAreaName.SelectedItem==null) return;
			clsDeptInfo_ManageExplorer objInfo= new clsDeptInfo_ManageExplorer();
			objInfo.m_strDeptID=((clsDeptInfo_ManageExplorer) m_cboEmployeeDeptName.SelectedItem).m_strDeptID;
			objInfo.m_strDeptName=((clsDeptInfo_ManageExplorer) m_cboEmployeeDeptName.SelectedItem).m_strDeptName;
//			objInfo.m_strAreaID=((clsAreaInfo_ManageExplorer) m_cboEmployeeAreaName.SelectedItem).m_strAreaID;
//			objInfo.m_strAreaName=((clsAreaInfo_ManageExplorer) m_cboEmployeeAreaName.SelectedItem).m_strAreaName;
			m_lstEmployeeTakenDept.Items.Add(objInfo);
		}


		private bool m_blnEmployeeDeptCanBeDeleted()
		{
			if(m_lstEmployeeTakenDept.SelectedItem==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没有选择要删除的部门。");
				return false;
			}
			return true;
		}
		private long m_lngEmployeeDeleteDeptSub()
		{
//			long lngRes=1;
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return (long)enmOperationResult.Parameter_Error;
			clsDept_Employee objDept=new clsDept_Employee();
			objDept.m_dtmEndDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objDept.m_strDeptID=((clsDeptInfo_ManageExplorer)m_lstEmployeeTakenDept.SelectedItem).m_strDeptID;
			objDept.m_strEmployeeID=((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strEmployeeID;
			return m_objHandlerDomain.m_lngDeleteDept_Employee(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,objDept);
		
		}
		private void m_mthEmployeeDeleteDept()
		{
			if(!m_blnEmployeeDeptCanBeDeleted())return;
			if(m_lngEmployeeDeleteDeptSub()<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法删除，请刷新");
				return;
			}
			
			if(m_lsvManageExplorerMid.SelectedItems.Count>0)
			{
				if(((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID==
					((clsDeptInfo_ManageExplorer) m_lstEmployeeTakenDept.SelectedItem).m_strDeptID)
				{
					m_lsvManageExplorerMid.SelectedItems[0].Remove();
				}
			}
			m_lstEmployeeTakenDept.Items.Remove(m_lstEmployeeTakenDept.SelectedItem);

		}


//		private void m_mthEmployeeLoadArea()
//		{
//			clsDept_Desc[] objDeptArr=null;
//			//这里要换成员工负责的科室
//			long lngRes= m_objManagerDomain.m_lngGetAreaArr_EmployeeCanManage(((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strEmployeeID,
//				out objDeptArr);
//			if(lngRes<=0 || objDeptArr==null) return;
//			for(int i=0;i<objDeptArr.Length;i++)
//			{
//				clsDeptInfo_ManageExplorer objDept=new clsDeptInfo_ManageExplorer();
////				objDept.m_strAreaID=objDeptArr[i].m_strArea_ID;
////				objDept.m_strAreaName=objDeptArr[i].m_strArea_Name.Trim();
//				objDept.m_strDeptID=objDeptArr[i].m_strParentDeptID;
//				objDept.m_strDeptName=objDeptArr[i].m_strParentDeptName.Trim();
//				m_lstEmployeeTakenDept.Items.Add(objDept);
//			}
//		}
		private void m_mthEmployeeLoadAvailableDept()
		{
			clsDepartment[] objDeptArr=null;
			objDeptArr= m_objManagerDomain.m_objGetAllInDeptArr();
	
			if(objDeptArr==null) return;
			for(int i=0;i<objDeptArr.Length;i++)
			{
				clsDeptInfo_ManageExplorer objDeptInfo=new clsDeptInfo_ManageExplorer();
				objDeptInfo.m_strDeptID = objDeptArr[i].m_StrDeptID;
				objDeptInfo.m_strDeptName = objDeptArr[i].m_StrDeptName;
				m_cboEmployeeDeptName.AddItem(objDeptInfo);
			}
//			m_cboEmployeeAreaName.ClearItem();
//			m_cboEmployeeAreaName.Text="";
		}
//		private void m_mthEmployeeLoadAvailableArea()
//		{
//			clsInPatientArea[] objAreaArr=null;
//			long lngRes= m_objManagerDomain.m_lngGetAllAreaInDept(((clsDeptInfo_ManageExplorer)m_cboEmployeeDeptName.SelectedItem).m_strDeptID,
//				out objAreaArr);
//	
//			if(lngRes<=0 || objAreaArr==null) return;
//			m_cboEmployeeAreaName.ClearItem();
//			for(int i=0;i<objAreaArr.Length;i++)
//			{
//				clsAreaInfo_ManageExplorer objAreaInfo=new clsAreaInfo_ManageExplorer();
//				objAreaInfo.m_strAreaID = objAreaArr[i].m_StrAreaID;
//				objAreaInfo.m_strAreaName = objAreaArr[i].m_StrAreaName;
////				m_cboEmployeeAreaName.AddItem(objAreaInfo);
//			}
//		}
		

		

		private bool m_blnEmployeeChangeInfoSub()
		{
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择员工。");
				return false;
			}
			frmEmployeeDetailInfo frmForm=new frmEmployeeDetailInfo(((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo);
			if(frmForm.ShowDialog()!=DialogResult.Yes) return false;
			clsEmployee_BaseInfo objDept=frmForm.m_objGetContentValue();
			
			if(objDept.m_strEmployeeID==null || objDept.m_strEmployeeID=="")
			{
				clsPublicFunction.ShowInformationMessageBox("员工ID不能为空。");
				return false;
			}
			
			//if(objDept.m_objPeopleInfo.m_StrFirstName==null || objDept.m_objPeopleInfo.m_StrFirstName=="") return false;
	
			if(m_objHandlerDomain.m_lngModifyEmployeeBaseInfo(objDept)<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法连接数据库。") ;
				return false;
			}
			if(objDept.m_strStatus=="1")
			{
				m_lsvManageExplorerMid.SelectedItems[0].Remove();
				return false;
			}
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objEmployeeBaseInfo=objDept;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strEmployeeID=objDept.m_strEmployeeID;
			((clsEmployeeInfo_ManageExplorer)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strEmployeeName=objDept.m_strFirstName;
			m_lsvManageExplorerMid.SelectedItems[0].Text=objDept.m_strFirstName;
			return true;
		}
		private void m_mthEmployeeChangeInfo()
		{
			m_blnEmployeeChangeInfoSub();
		}
		#endregion

		#region 病人Panel的相关操作

		private long m_lngPatientLeaveBedSub()
		{
			
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return (long)enmOperationResult.Parameter_Error;
			return m_objHandlerDomain.m_lngPatientLeaveBed(((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID,
				new clsPatient(((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID).m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.Parse( new clsPublicDomain().m_strGetServerTime()));
			
		}
		private void m_mthPatientLeaveBed()
		{
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return;
			if(m_lngPatientLeaveBedSub()<=0) return;
			m_lsvManageExplorerMid.SelectedItems[0].ImageIndex=0;
			m_lsvManageExplorerMid.SelectedItems[0].Text=((clsBedInfo) m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID="";//清空当前病人和病床的绑定信息，Jacky-2003-8-20
			m_mthDisplayPnlBed();

		}


		private long m_lngPatientTurnToBedSub()
		{

			if(m_cboPatientBedDept.SelectedItem==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择科室。");
				return (long)enmOperationResult.Parameter_Error;
			}
			if(m_cboPatientBedArea.SelectedItem==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择病区。");
				return (long)enmOperationResult.Parameter_Error;
			}
			if(m_cboPatientBedName.SelectedItem==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择病床。");
				return (long)enmOperationResult.Parameter_Error;
			}
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择病人");
				return (long)enmOperationResult.Parameter_Error;
			}
			if(((clsBedInfo)m_cboPatientBedName.SelectedItem).m_strBedID.Trim()
				==((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedID.Trim())
			{
				clsPublicFunction.ShowInformationMessageBox("不能转到现在所在的床。");
				return (long)enmOperationResult.Parameter_Error;
			}
//			InBedEndDate,
//			Begin_Date_Area_Dept,
//			Begin_Date_Room_Area,Begin_Date_Bed_Room不用赋值)</param>
			clsInDeptInfo objToDeptInfo=new clsInDeptInfo();
//			objToDeptInfo.m_dtmInPatientDate=DateTime.Parse(((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientDate);
			objToDeptInfo.m_dtmModifyDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objToDeptInfo.m_strArea_ID=((clsAreaInfo_ManageExplorer)m_cboPatientBedArea.SelectedItem).m_strAreaID;
			objToDeptInfo.m_strBed_ID=((clsBedInfo)m_cboPatientBedName.SelectedItem).m_strBedID;
			objToDeptInfo.m_strInDeptID=((clsDeptInfo_ManageExplorer)m_cboPatientBedDept.SelectedItem).m_strDeptID;
			objToDeptInfo.m_strInPatientID=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID;
			objToDeptInfo.m_dtmInPatientDate=new clsPatient(objToDeptInfo.m_strInPatientID).m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate;

			clsInPatientRoom[] objRoomArr=null;
			long lngRes=m_objManagerDomain.m_lngGetAllRoomInArea(objToDeptInfo.m_strArea_ID,out objRoomArr);
			if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法为病人转床。");
				return lngRes;
			}
			if(objRoomArr==null)
			{
				clsPublicFunction.ShowInformationMessageBox("无法为病人转床。");
				return (long)enmOperationResult.Record_Already_Delete;
			}
			objToDeptInfo.m_strRoom_ID=objRoomArr[0].m_StrRoomID;
			lngRes= m_objHandlerDomain.m_lngPatientTransferBed(objToDeptInfo);
			if(lngRes<=0)if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法为病人转床。");
				return lngRes;
			}

			m_lblZCInf.Text="转床成功：病人转到【" + ((clsDeptInfo_ManageExplorer)m_cboPatientBedDept.SelectedItem).m_strDeptName + "】科室，"
							+"【"+((clsAreaInfo_ManageExplorer)m_cboPatientBedArea.SelectedItem).m_strAreaName+"】病区，"
							+"【"+((clsBedInfo)m_cboPatientBedName.SelectedItem).m_strBedName+"】病床。";
			
			clsBedInfo objTempSwapBed=new clsBedInfo();
			string strTempSwapString=null;

			for(int i=0;i<m_lsvManageExplorerMid.Items.Count;i++)
			{	//如果目标床在本病区内，要更新显示
				if(((clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag).m_strBedID==
					((clsBedInfo)m_cboPatientBedName.SelectedItem).m_strBedID)
				{
					m_lsvManageExplorerMid.Items[i].ImageIndex=1;

					objTempSwapBed= (clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag;
					m_lsvManageExplorerMid.Items[i].Tag=m_lsvManageExplorerMid.SelectedItems[0].Tag;
					m_lsvManageExplorerMid.SelectedItems[0].Tag=objTempSwapBed;

					strTempSwapString=((clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag).m_strBedID;
					((clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag).m_strBedID=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedID;
					((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedID=strTempSwapString;

					strTempSwapString=((clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag).m_strBedName;
					((clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag).m_strBedName=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName;
					((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName=strTempSwapString;
					
					m_lsvManageExplorerMid.Items[i].Text=((clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag).m_strBedName
						+ "\n" + ((clsBedInfo)m_lsvManageExplorerMid.Items[i].Tag).m_strBedInPatientName;
					m_lsvManageExplorerMid.SelectedItems[0].Text=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName
						+ "\n" + ((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientName;
					break;
				}
			}
			return lngRes;
			
		

		}
		private void m_mthPatientTurnToBed()
		{
			if(m_lngPatientTurnToBedSub()<=0)
			{
//				clsPublicFunction.ShowInformationMessageBox("目标床已有病人，无法转床");
				return;
			}
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null)
			{
				return;
			}
			m_lsvManageExplorerMid.SelectedItems[0].ImageIndex=0;
			m_lsvManageExplorerMid.SelectedItems[0].Text=((clsBedInfo) m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName;
			m_mthDisplayPnlBed();
			
			

		}


		private void m_mthPatientLeaveHospital(int p_intEndReason)
		{
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return;
			string strInPatientID=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID;
			if(m_lngPatientLeaveBedSub()<=0) return;
			long lngRes=m_objHandlerDomain.m_lngDeleteInPatientDateInfo(strInPatientID,
				new clsPatient(strInPatientID).m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,
				DateTime.Parse(new clsPublicDomain().m_strGetServerTime()),p_intEndReason);
			if(lngRes<=0) return ;
////			m_lsvManageExplorerMid.SelectedItems[0].ImageIndex=0;
////			m_lsvManageExplorerMid.SelectedItems[0].Text=((clsBedInfo) m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName;
			m_trvManageExplorer_AfterSelect(null,null);
			m_mthDisplayPnlBed();
			

		}

		private void m_mthPatientLoadDept(Control p_ctlSender)
		{
			this.Cursor=Cursors.WaitCursor;
			clsDepartment[] objDeptArr=m_objManagerDomain.m_objGetAllInDeptArr();
			if(objDeptArr==null)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			ctlComboBox cboTemp = p_ctlSender as ctlComboBox; //
//			m_cboPatientBedDept.ClearItem();
			cboTemp.ClearItem();
			for(int i=0;i<objDeptArr.Length;i++)
			{
				clsDeptInfo_ManageExplorer objDept=new clsDeptInfo_ManageExplorer();
				objDept.m_strDeptID=objDeptArr[i].m_StrDeptID;
				objDept.m_strDeptName=objDeptArr[i].m_StrDeptName;
				cboTemp.AddItem(objDept);
			}
			this.Cursor=Cursors.Default;
		}
		private void m_mthPatientLoadArea(Control p_ctlSender)
		{
			ctlComboBox cboTemp = p_ctlSender as ctlComboBox; //
//			if(m_cboPatientBedDept.SelectedItem==null) return;
			bool blnIsNull = cboTemp.Name == "m_cboPatientBedDept" ? m_cboPatientBedDept.SelectedItem==null : m_cboPatientBedDept2.SelectedItem == null;
			if(blnIsNull) return;
			clsInPatientArea[] objAreaArr=null;
			this.Cursor=Cursors.WaitCursor;
			if(m_objManagerDomain.m_lngGetAllAreaInDept(((clsDeptInfo_ManageExplorer)m_cboPatientBedDept2.SelectedItem).m_strDeptID,
				out objAreaArr)<=0)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			if(objAreaArr==null)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			cboTemp.ClearItem();
			for(int i=0;i<objAreaArr.Length;i++)
			{
				clsAreaInfo_ManageExplorer objArea=new clsAreaInfo_ManageExplorer();
				objArea.m_strAreaID=objAreaArr[i].m_StrAreaID;
				objArea.m_strAreaName=objAreaArr[i].m_StrAreaName;
				cboTemp.AddItem(objArea);
			}
			this.Cursor=Cursors.Default;
		}

		/// <summary>
		/// 根据p_ctlSender2中的部门得到对应的病区信息
		/// </summary>
		/// <param name="p_ctlSender"> 存放p_ctlSender2中对应的病区信息 </param>
		/// <param name="p_ctlSender2"> 根据p_ctlSender2中的部门查找对应病区信息 </param>
		private void m_mthPatientLoadAreaByDept(Control p_ctlSender,Control p_ctlSender2)
		{
			ctlComboBox cboTemp = p_ctlSender as ctlComboBox; //
			ctlComboBox cboTemp1 = p_ctlSender2 as ctlComboBox; //
			if(cboTemp1.SelectedItem==null) return;

			clsInPatientArea[] objAreaArr=null;
			this.Cursor=Cursors.WaitCursor;
			if(m_objManagerDomain.m_lngGetAllAreaInDept(((clsDeptInfo_ManageExplorer)cboTemp1.SelectedItem).m_strDeptID,
				out objAreaArr)<=0)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			if(objAreaArr==null)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			cboTemp.ClearItem();
			for(int i=0;i<objAreaArr.Length;i++)
			{
				clsAreaInfo_ManageExplorer objArea=new clsAreaInfo_ManageExplorer();
				objArea.m_strAreaID=objAreaArr[i].m_StrAreaID;
				objArea.m_strAreaName=objAreaArr[i].m_StrAreaName;
				cboTemp.AddItem(objArea);
			}
			this.Cursor=Cursors.Default;
		}

		private void m_mthPatientLoadBed(Control p_ctlSender)
		{
			ctlComboBox cboBed = p_ctlSender as ctlComboBox;
			ctlComboBox cboArea = cboBed.Name == "m_cboPatientBedName" ? m_cboPatientBedArea : m_cboPatientBedArea2;
			if(cboArea.SelectedItem == null)
				return;

			clsInPatientBed[] objBedArr=null;
			clsPatient[] objPatientArr=null;
			this.Cursor=Cursors.WaitCursor;
			if(m_objManagerDomain.m_lngGetAllBedAndPatientInArea(((clsAreaInfo_ManageExplorer)cboArea.SelectedItem).m_strAreaID,
				out objBedArr,out objPatientArr)<=0)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			if(objBedArr==null || objPatientArr==null || objBedArr.Length<objPatientArr.Length)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			cboBed.ClearItem();
			for(int i=0;i<objBedArr.Length;i++)
			{
				if(objPatientArr[i]==null)
				{
					clsBedInfo objBed=new clsBedInfo();
					objBed.m_strBedID=objBedArr[i].m_StrBedID;
					objBed.m_strBedName=objBedArr[i].m_StrBedName;
					cboBed.AddItem(objBed);
				}
			}
			this.Cursor=Cursors.Default;
		}



		private bool m_blnPatientChangeInfoSub()
		{
			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return false;
			frmPatientDetailInfo frmForm=new frmPatientDetailInfo(((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objPatientBaseInfo);
			if(frmForm.ShowDialog()!=DialogResult.Yes) return false;
			clsPatientBaseInfo objDept=frmForm.m_objGetContentValue();
			
			if(objDept.m_strInPatientID==null || objDept.m_strInPatientID=="") return false;
			//if(objDept.m_objPeopleInfo.m_StrFirstName==null || objDept.m_objPeopleInfo.m_StrFirstName=="") return false;

			
			if(m_objHandlerDomain.m_lngModifyPatientBaseInfo(objDept)<=0) return false;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_objPatientBaseInfo=objDept;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID=objDept.m_strInPatientID;
			((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientName=objDept.m_objPeopleInfo.m_StrFirstName;
			m_lsvManageExplorerMid.SelectedItems[0].Text=((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedName+"\n"
				+((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientName;

			return true;
		}
		private void m_mthPatientChangeInfo()
		{
			m_blnPatientChangeInfoSub();
		}

		#endregion

		#region Load ListView
		
		private void m_mthLoadPatientLsv()
		{
			m_lsvManageExplorerMid.Visible=true;
			m_lsvManageExplorerMid.BringToFront();
			m_lsvManageExplorerMid.Clear();
			clsPatient[] objPatientArr=null;
			clsInPatientBed[] objBedArr=null;
			if(m_objManagerDomain.m_lngGetAllBedAndPatientInArea(((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID,
				out objBedArr, out objPatientArr)<=0 ) return;
			if(objPatientArr==null || objBedArr==null) return;
			if(objPatientArr.Length>objBedArr.Length)
			{
				MessageBox.Show("too few beds!");
				return;
			}
			
			for(int i=0;i<objBedArr.Length;i++)
			{
				clsBedInfo objInfo=new clsBedInfo();
				objInfo.m_strBedID=objBedArr[i].m_StrBedID;
				objInfo.m_strBedName=objBedArr[i].m_StrBedName;
				objInfo.m_strBedBeginDate=objBedArr[i].m_DtmBeginDate.ToString("yyyy-MM-dd HH:mm:ss");
				objInfo.m_strBedEndDate="1900-1-1 00:00:00";

				
			
				if(objPatientArr[i]!=null)
				{
//					objInfo.m_strBedInPatientDate=objPatientArr[i].m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
					objInfo.m_strBedInPatientID=objPatientArr[i].m_StrInPatientID;
					objInfo.m_strBedInPatientName=objPatientArr[i].m_StrName;

					objInfo.m_objPatientBaseInfo=new clsPatientBaseInfo();
					objInfo.m_objPatientBaseInfo.m_objPeopleInfo=objPatientArr[i].m_ObjPeopleInfo;
					objInfo.m_objPatientBaseInfo.m_strInPatientID=objPatientArr[i].m_StrInPatientID;
					objInfo.m_objPatientBaseInfo.m_strPatientID=objPatientArr[i].m_Str_OutPatientID;
				
				}
				
				ListViewItem objLsvItem=null;
				if(objInfo.m_strBedInPatientID==null || objInfo.m_strBedInPatientID=="")
				{
					objLsvItem=new ListViewItem(objInfo.m_strBedName);
					objLsvItem.ImageIndex=0;
				}
				else
				{
					objLsvItem=new ListViewItem(new string[]{objInfo.m_strBedName+"\n" + objInfo.m_strBedInPatientName});
					objLsvItem.ImageIndex=1;
				}
				
				objLsvItem.Tag=objInfo;
				m_lsvManageExplorerMid.Items.Add(objLsvItem);
			}


		}

		private void m_mthLoadEmployeeLsv()
		{
			//m_blnCurrentIsPatient=true;
//			long lngRes=1;
			m_lsvManageExplorerMid.Visible=true;
			m_lsvManageExplorerMid.BringToFront();
			m_lsvManageExplorerMid.Clear();
			clsEmployee_BaseInfo[] objEmployeeArr=null;
			//此处要获得科室下的员工
			long lngRes=m_objManagerDomain.m_lngGetEmployeeArrInDept(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_strID,
				out objEmployeeArr);
			if(lngRes<=0 || objEmployeeArr==null) return;
			for(int i=0;i<objEmployeeArr.Length;i++)
			{
				clsEmployeeInfo_ManageExplorer objInfo=new clsEmployeeInfo_ManageExplorer();
				objInfo.m_strEmployeeID=objEmployeeArr[i].m_strEmployeeID;
				objInfo.m_strEmployeeName=objEmployeeArr[i].m_strFirstName;


				objInfo.m_objEmployeeBaseInfo=objEmployeeArr[i];
				
				ListViewItem objLsvItem=new ListViewItem(objInfo.m_strEmployeeName.Trim());
				objLsvItem.Tag=objInfo;
				objLsvItem.ImageIndex=2;
				m_lsvManageExplorerMid.Items.Add(objLsvItem);
			}
				

		}

		#endregion

		#region Load 模糊查询的ListView
		private void m_mthLoadEmployeeIDLsv()
		{
			clsEmployee[] objArr=new clsEmployeeManager().m_objGetAllEmployeeIDLikeArr(m_txtTbp2EmployeeID.Text.Trim(),null);
			if(objArr==null)
			{
//				m_mthTbp2ClearUI();
				return;
			}
			m_lsvTbp2EmployeeID.Items.Clear();
			for(int i=0;i<objArr.Length && i<c_intMaxLikeLsvLength;i++)
			{
				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrEmployeeID,objArr[i].m_StrFirstName.Trim()});
				objItem.Tag=objArr[i];
				m_lsvTbp2EmployeeID.Items.Add(objItem);
			}
//			m_lsvTbp2EmployeeID.Sort();
		}
		private void m_mthLoadEmployeeNameLsv()
		{
			clsEmployee[] objArr=new clsEmployeeManager().m_objGetAllEmployeeIDLikeArr(m_txtTbp2EmployeeName.Text.Trim(),null);
			if(objArr==null) 
			{
//				m_mthTbp2ClearUI();
				return;
			}
			m_lsvTbp2EmployeeName.Items.Clear();
			for(int i=0;i<objArr.Length && i<c_intMaxLikeLsvLength;i++)
			{
				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrEmployeeID,objArr[i].m_StrFirstName.Trim()});
				objItem.Tag=objArr[i];
				m_lsvTbp2EmployeeName.Items.Add(objItem);
			}
//			m_lsvTbp2EmployeeName.Sort();
		}
		private void m_mthLoadPatientIDLsv()
		{
//			clsPatient[] objArr=new clsPatientManager().m_objGetInPatientByDeptIDLike(null,m_txtTbp1InPatientID.Text.Trim());
//			if(objArr==null)
//			{
////				m_mthTbp1ClearUI();
//				return;
//			}
//			m_lsvTbp1InPatientID.Items.Clear();
//			for(int i=0;i<objArr.Length && i<c_intMaxLikeLsvLength;i++)
//			{
//				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrInPatientID,objArr[i].m_ObjPeopleInfo.m_StrFirstName});
//				objItem.Tag=objArr[i];
//				m_lsvTbp1InPatientID.Items.Add(objItem);
//			}
//			m_lsvTbp1InPatientID.Sort();
		}
		private void m_mthLoadPatientNameLsv()
		{
//			clsPatient[] objArr=new clsPatientManager().m_objGetInPatientByDeptIDLike(null,m_txtTbp1PatientFirstName.Text.Trim());
//			if(objArr==null)
//			{
////				m_mthTbp1ClearUI();
//				return;
//			}
//			m_lsvTbp1InPatientName.Items.Clear();
//			for(int i=0;i<objArr.Length && i<c_intMaxLikeLsvLength;i++)
//			{
//				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrInPatientID,objArr[i].m_ObjPeopleInfo.m_StrFirstName});
//				objItem.Tag=objArr[i];
//				m_lsvTbp1InPatientName.Items.Add(objItem);
//			}
//			m_lsvTbp1InPatientName.Sort();
		}

		private void m_mthLoadDeptIDLsv()
		{
			clsDepartment[] objArr=new clsDepartmentManager().m_lngGetDeptLikeQuery(m_txtTbp3DeptID.Text.Trim());
			if(objArr==null)
			{
//				m_mthTbp3ClearUI();
				return;
			}
			m_lsvTbp3DeptID.Items.Clear();
			for(int i=0;i<objArr.Length && i<c_intMaxLikeLsvLength;i++)
			{
				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrDeptID,objArr[i].m_StrDeptName});
				objItem.Tag=objArr[i];
				m_lsvTbp3DeptID.Items.Add(objItem);
			}
//			m_lsvTbp3DeptID.Sort();
		}
		private void m_mthLoadDeptNameLsv()
		{
			clsDepartment[] objArr=new clsDepartmentManager().m_lngGetDeptLikeQuery(m_txtTbp3DeptName.Text.Trim());
			if(objArr==null)
			{
//				m_mthTbp3ClearUI();
				return;
			}
			m_lsvTbp3DeptName.Items.Clear();
			for(int i=0;i<objArr.Length && i<c_intMaxLikeLsvLength;i++)
			{
				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrDeptID,objArr[i].m_StrDeptName});
				objItem.Tag=objArr[i];
				m_lsvTbp3DeptName.Items.Add(objItem);
			}
//			m_lsvTbp3DeptName.Sort();
		}
		private void m_mthLoadDeptTbp2EmployeeIDLsv()
		{
			clsEmployee[] objArr=new clsEmployeeManager().m_objGetAllEmployeeIDLikeArr(m_txtDeptAddEmployeeID.Text.Trim(),null);
			if(objArr==null)
			{	
				return;
			}
			m_lsvDeptTbp2EmployeeID.Items.Clear();
			for(int i=0;i<objArr.Length && i<c_intMaxLikeLsvLength;i++)
			{
				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrEmployeeID,objArr[i].m_StrFirstName.Trim()});
				objItem.Tag=objArr[i];
				m_lsvDeptTbp2EmployeeID.Items.Add(objItem);
			}

			//显示的行数大于6时，减小最后一列的宽度，以显示滚动条
			clsPublicFunction.s_mthChangeListViewLastColumnWidth(m_lsvDeptTbp2EmployeeID);
//			m_lsvDeptTbp2EmployeeID.Sort();
		}
		private void m_mthLoadDeptTbp2EmployeeNameLsv()
		{
			clsEmployee[] objArr=new clsEmployeeManager().m_objGetAllEmployeeIDLikeArr(m_txtDeptAddEmployeeName.Text.Trim(),null);
			if(objArr==null) 
			{
				return;
			}
			m_lsvDeptTbp2EmployeeName.Items.Clear();
			for(int i=0;i<objArr.Length && i<c_intMaxLikeLsvLength;i++)
			{
				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrEmployeeID,objArr[i].m_StrFirstName.Trim()});
				objItem.Tag=objArr[i];
				m_lsvDeptTbp2EmployeeName.Items.Add(objItem);
			}
			//显示的行数大于6时，减小最后一列的宽度，以显示滚动条
			clsPublicFunction.s_mthChangeListViewLastColumnWidth(m_lsvDeptTbp2EmployeeName);
//			m_lsvDeptTbp2EmployeeName.Sort();
		}
		#endregion

		#region 点击全院节点时的TabPage的控制
		private void m_mthTbp1SetUIFromPatient(clsPatient p_objPatient)
		{
			p_objPatient=new clsPatient(p_objPatient.m_StrInPatientID);
			m_cboTbp1Home_district.Text=p_objPatient.m_ObjPeopleInfo.m_Strhome_district;
			m_txtTbp1HomePC.Text=p_objPatient.m_ObjPeopleInfo.m_StrHomePC;
			m_txtTbp1HomePhone.Text=p_objPatient.m_ObjPeopleInfo.m_StrHomePhone;
			m_cboTbp1BornPlace.Text=p_objPatient.m_ObjPeopleInfo.m_StrHomeplace;
			m_txtTbp1IDCard.Text=p_objPatient.m_ObjPeopleInfo.m_StrIDCard;
			m_txtTbp1InPatientID.Text=p_objPatient.m_StrInPatientID;
			m_txtTbp1LinkMan.Text=p_objPatient.m_ObjPeopleInfo.m_StrLinkManFirstName;
			m_cboTbp1LinkMan_district.Text=p_objPatient.m_ObjPeopleInfo.m_StrLinkMan_district;
			m_txtTbp1LinkManPC.Text=p_objPatient.m_ObjPeopleInfo.m_StrLinkManPC;
			m_txtTbp1LinkManPhone.Text=p_objPatient.m_ObjPeopleInfo.m_StrLinkManPhone;
			m_cboTbp1LinkManRelation.Text=p_objPatient.m_ObjPeopleInfo.m_StrPatientRelation;
//			m_txtTbp1Mobile.Text=p_objPatient.m_ObjPeopleInfo.m_StrMobile;
			m_cboTbp1Nation.Text=p_objPatient.m_ObjPeopleInfo.m_StrNation;
			m_cboTbp1Nationality.Text=p_objPatient.m_ObjPeopleInfo.m_StrNationality;
			m_cboTbp1NativePlace.Text=p_objPatient.m_ObjPeopleInfo.m_StrNativePlace;
			m_cboTbp1Occupation.Text=p_objPatient.m_ObjPeopleInfo.m_StrOccupation;
			m_cboTbp1Office_district.Text=p_objPatient.m_ObjPeopleInfo.m_StrOffice_district;
			m_txtTbp1OfficePC.Text=p_objPatient.m_ObjPeopleInfo.m_StrOfficePC;
			m_txtTbp1OfficePhone.Text=p_objPatient.m_ObjPeopleInfo.m_StrOfficePhone;
			m_txtTbp1PatientFirstName.Text=p_objPatient.m_ObjPeopleInfo.m_StrFirstName;
			m_txtTbp1PatientID.Text=p_objPatient.m_Str_OutPatientID;
//			m_txtTbp1PatientLastName.Text=p_objPatient.m_ObjPeopleInfo.m_StrLastName;
			m_cboTbp1PaymentPercent.Text=p_objPatient.m_ObjPeopleInfo.m_StrPaymentPercent;

			m_txtTbp1temp_zipcode.Text=p_objPatient.m_ObjPeopleInfo.m_Strtemp_zipcode; 
			m_cboTbp1Insurance.Text=p_objPatient.m_ObjPeopleInfo.m_Strinsurance;
			m_cboTbp1Admiss_status.Text=p_objPatient.m_ObjPeopleInfo.m_Stradmiss_status;
			m_cboTbp1Visit_type.Text=p_objPatient.m_ObjPeopleInfo.m_Strvisit_type;
			m_cboTbp1ChargeCategory.Text=p_objPatient.m_ObjPeopleInfo.m_StrChargeCategory;
			m_cboTbp1PaymentPercent.Text=p_objPatient.m_ObjPeopleInfo.m_StrPaymentPercent;
			
			if(p_objPatient.m_ObjPeopleInfo.m_StrChargeCategory==null) p_objPatient.m_ObjPeopleInfo.m_StrChargeCategory="";
			switch(p_objPatient.m_ObjPeopleInfo.m_StrChargeCategory.Trim())
			{
				case  "公费或自费":
					m_cboTbp1ChargeCategory.SelectedIndex=0;
					break;
				case  "14岁以下":
					m_cboTbp1ChargeCategory.SelectedIndex=1;
					break;
				case  "优质病房":
					m_cboTbp1ChargeCategory.SelectedIndex=2;
					break;
				case  "港澳华侨":
					m_cboTbp1ChargeCategory.SelectedIndex=3;
					break;
				case  "外宾":
					m_cboTbp1ChargeCategory.SelectedIndex=4;
					break;
				default:
					m_cboTbp1ChargeCategory.SelectedIndex=-1;
					break;
			}
			if(p_objPatient.m_ObjPeopleInfo.m_StrMarried==null) p_objPatient.m_ObjPeopleInfo.m_StrMarried="";
			switch(p_objPatient.m_ObjPeopleInfo.m_StrMarried.Trim())
			{
				case  "已婚":
					m_cboTbp1Married.SelectedIndex=0;
					break;
				case  "未婚":
					m_cboTbp1Married.SelectedIndex=1;
					break;
				case  "丧偶":
					m_cboTbp1Married.SelectedIndex=2;
					break;
				case  "离婚":
					m_cboTbp1Married.SelectedIndex=3;
					break;
				case  "其他":
					m_cboTbp1Married.SelectedIndex=4;
					break;
				default:
					m_cboTbp1Married.SelectedIndex=-1;
					break;
			}


//			m_cboTbp1IsEmployee.SelectedIndex=p_objPatient.m_ObjPeopleInfo.m_BlnIsEmployee ? 0 : 1;
			
			if(p_objPatient.m_ObjPeopleInfo.m_StrSex==null) p_objPatient.m_ObjPeopleInfo.m_StrSex="";
			switch(p_objPatient.m_ObjPeopleInfo.m_StrSex.Trim())
			{
				case  "男":
					m_cboTbp1Sex.SelectedIndex=0;
					break;
				case  "女":
					m_cboTbp1Sex.SelectedIndex=1;
					break;
				case  "其他":
					m_cboTbp1Sex.SelectedIndex=2;
					break;
				default:
					m_cboTbp1Sex.SelectedIndex=-1;
					break;
			}

			
			m_dtpTbp1Birth.Value=p_objPatient.m_ObjPeopleInfo.m_DtmBirth== DateTime.MinValue ? DateTime.Parse("1900-1-1") : p_objPatient.m_ObjPeopleInfo.m_DtmBirth;
//			m_dtpTbp1FirstDate.Value=p_objPatient.m_ObjPeopleInfo.m_DtmFirstDate== DateTime.MinValue ? DateTime.Parse("1900-1-1") : p_objPatient.m_ObjPeopleInfo.m_DtmFirstDate;
//			m_lblTbp1Age.Text=p_objPatient.m_ObjPeopleInfo.m_IntAge.ToString();
			
		}
		/// <summary>
		/// 从界面获取表单值
		/// </summary>
		/// <returns></returns>
		private clsPatientBaseInfo m_objTbp1GetPatientFromUI()
		{
			long lngInPatientID = -1L;;
			try{lngInPatientID = long.Parse(this.m_txtTbp1InPatientID.Text.Trim());}
			catch{lngInPatientID = -1L;}
			if(this.m_txtTbp1InPatientID.Text.Trim().Length>12 || lngInPatientID <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,住院号必须为数字，且长度应小于12");
				m_txtTbp1InPatientID.Focus();
				return null;
			}			
			
			if(this.m_txtTbp1InPatientID.Text.Trim() =="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写住院号!");
				m_txtTbp1InPatientID.Focus();
				return null;
			}			

			if( this.m_txtTbp1PatientFirstName.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人姓名!");
				m_txtTbp1PatientFirstName.Focus();
				return null;
			}
			if( this.m_cboTbp1Occupation.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人职业!");
				m_cboTbp1Occupation.Focus();
				return null;
			}
			if( this.m_cboTbp1Nation.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人民族!");
				m_cboTbp1Nation.Focus();
				return null;
			}
			if( this.m_txtTbp1HomePhone.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人电话!");
				m_txtTbp1HomePhone.Focus();
				return null;
			}
			if( this.m_cboTbp1NativePlace.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人籍贯!");
				m_cboTbp1NativePlace.Focus();
				return null;
			}
			if( this.m_cboTbp1Home_district.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人住址!");
				m_cboTbp1Home_district.Focus();
				return null;
			}
			if( this.m_txtTbp1LinkMan.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人联系人!");
				m_txtTbp1LinkMan.Focus();
				return null;
			}
			if( this.m_cboTbp1Sex.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人性别!");
				m_cboTbp1Sex.Focus();
				return null;
			}
			if( this.m_cboTbp1Married.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写病人婚姻状况!");
				m_cboTbp1Married.Focus();
				return null;
			}
			if( this.m_cboPatientBedDept2.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写入院科室!");
				m_cboPatientBedDept2.Focus();
				return null;
			}
			//界面参数校验
			try
			{
				if(m_txtTbp1OfficePC.Text.Trim() !="")
					long.Parse(m_txtTbp1HomePC.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("邮编只能输入数字!");
				m_txtTbp1OfficePC.Focus();
				return null;
			}
			try
			{
				if(m_txtTbp1Hic_no.Text.Trim() !="")
					long.Parse(m_txtTbp1Hic_no.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("医疗证只能输入数字!");
				m_txtTbp1Hic_no.Focus();
				return null;
			}
			try
			{
				if(m_txtTbp1HomePC.Text.Trim() !="")
					long.Parse(m_txtTbp1HomePC.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("邮编只能输入数字!");
				m_txtTbp1HomePC.Focus();
				return null;
			}
			try
			{
				if(m_txtTbp1LinkManPC.Text.Trim() !="")
					long.Parse(m_txtTbp1LinkManPC.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("邮编只能输入数字!");
				m_txtTbp1LinkManPC.Focus();
				return null;
			}
			
//			if(m_txtTbp1IDCard.Text.Trim().Length!=0 && (m_txtTbp1IDCard.Text.Trim().Length !=15 || m_txtTbp1IDCard.Text.Trim().Length !=18))
//			{
//				clsPublicFunction.ShowInformationMessageBox("身份证号输入有误!");
//				m_txtTbp1IDCard.Focus();
//				return null;
//			}
//			if(m_cboTbp1IsEmployee.SelectedIndex==-1)
//			{
//				clsPublicFunction.ShowInformationMessageBox("请选择是否医院职工。");
//				return null;
//			}
			if(m_cboTbp1Married.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择婚姻状况。");
				return null;
			}
			if(m_cboTbp1Sex.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择姓别。");
				return null;
			}
			if(m_txtTbp1PatientID.Text!=null && m_txtTbp1PatientID.Text.Trim().Length>12)
			{
				clsPublicFunction.ShowInformationMessageBox("病人医疗证号长度不能大于12.");
				return null;
			}

			clsPatientBaseInfo m_objPatientBaseInfo=new clsPatientBaseInfo();
			m_objPatientBaseInfo.m_objPeopleInfo=new clsPeopleInfo();

			m_objPatientBaseInfo.m_strInPatientID=m_txtTbp1InPatientID.Text.Trim();
			m_objPatientBaseInfo.m_strPatientID=m_txtTbp1PatientID.Text.Trim();			
			m_objPatientBaseInfo.m_objPeopleInfo.m_IntTimes = (int)m_numTbp1Times.Value;
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhic_no = m_txtTbp1Hic_no.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrFirstName=m_txtTbp1PatientFirstName.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrSex=m_cboTbp1Sex.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_DtmBirth=m_dtpTbp1Birth.Value;
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrMarried=m_cboTbp1Married.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOccupation=m_cboTbp1Occupation.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strvip_code=m_cboTbp1vip_code.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrNativePlace=m_cboTbp1NativePlace.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomeplace=m_cboTbp1BornPlace.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrNation=m_cboTbp1Nation.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrNationality=m_cboTbp1Nationality.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrIDCard=m_txtTbp1IDCard.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_name=m_txtTbp1OfficeName.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_district=m_cboTbp1Office_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOffice_street=m_txtTbp1Office_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOfficePhone=m_txtTbp1OfficePhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrOfficePC=m_txtTbp1OfficePC.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManFirstName=m_txtTbp1LinkMan.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrPatientRelation=m_cboTbp1LinkManRelation.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkMan_district=m_cboTbp1LinkMan_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkMan_street=m_txtTbp1LinkMan_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManPhone=m_txtTbp1LinkManPhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrLinkManPC=m_txtTbp1LinkManPC.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_district=m_cboTbp1Home_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strhome_street=m_txtTbp1Home_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePhone=m_txtTbp1HomePhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrHomePC=m_txtTbp1HomePC.Text.Trim(); 
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_district=m_cboTbp1Temp_district.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_street=m_txtTbp1Temp_street.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_tel=m_txtTbp1TempPhone.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strtemp_zipcode=m_txtTbp1temp_zipcode.Text.Trim(); 
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strinsurance=m_cboTbp1Insurance.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Stradmiss_status=m_cboTbp1Admiss_status.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_Strvisit_type=m_cboTbp1Visit_type.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrChargeCategory=m_cboTbp1ChargeCategory.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_StrPaymentPercent=m_cboTbp1PaymentPercent.Text.Trim();
			m_objPatientBaseInfo.m_objPeopleInfo.m_DtmFirstDate = m_dtpInPatientDate.Value;

			return m_objPatientBaseInfo;
		}
		
		private void m_mthTbp1ClearUI()
		{
			m_txtTbp1Home_street.Text="";
			m_txtTbp1HomePC.Text="";
			m_txtTbp1HomePhone.Text="";
			m_cboTbp1Home_district.SelectedIndex=-1;
			m_txtTbp1Temp_street.Text="";
			m_txtTbp1TempPhone.Text="";
			m_txtTbp1temp_zipcode.Text="";
			m_cboTbp1Temp_district.SelectedIndex=-1;
			m_cboTbp1BornPlace.SelectedIndex = -1;
			m_cboTbp1NativePlace.SelectedIndex = -1;
			m_txtTbp1IDCard.Text="";
			m_txtTbp1InPatientID.Text="";
			m_txtTbp1LinkMan.Text="";
			m_txtTbp1LinkMan_street.Text="";
			m_txtTbp1LinkManPC.Text="";
			m_txtTbp1LinkManPhone.Text="";
			m_cboTbp1LinkManRelation.SelectedIndex = -1;
			m_cboTbp1LinkMan_district.SelectedIndex = -1;
			m_cboTbp1Nation.SelectedIndex = -1;
			m_cboTbp1Nationality.SelectedIndex = -1;
			m_cboTbp1Occupation.SelectedIndex = -1;
			m_txtTbp1Office_street.Text="";
			m_txtTbp1OfficePC.Text="";
			m_txtTbp1OfficeName.Text="";
			m_txtTbp1OfficePhone.Text="";
			m_cboTbp1Office_district.SelectedIndex = -1;
			m_txtTbp1PatientFirstName.Text="";
			m_txtTbp1InPatientID.Text="";
			m_txtTbp1PatientID.Text="";
			m_cboTbp1PaymentPercent.SelectedIndex = -1;
			m_cboTbp1ChargeCategory.SelectedIndex=-1;
			m_cboTbp1Married.SelectedIndex=-1;
			m_cboTbp1Sex.SelectedIndex=-1;
			m_dtpTbp1Birth.Value= DateTime.Parse("1900-1-1");
			m_txtTbp1Hic_no.Text = "";
			m_cboTbp1vip_code.SelectedIndex = -1;
			m_cboTbp1Insurance.SelectedIndex = -1;
			m_cboTbp1Admiss_status.SelectedIndex = -1;
			m_cboTbp1Visit_type.SelectedIndex = -1;
			m_chkTbp1IsOldPatient.Checked = false;
			m_cboPatientBedArea2.SelectedIndex = -1;
			m_cboPatientBedDept2.SelectedIndex = -1;
			m_cboPatientBedName2.SelectedIndex = -1;
		}


		private void m_mthTbp2SetUIFromEmployee(clsEmployee p_objclsEmployee)
		{
			if(p_objclsEmployee==null) return;
			clsEmployee p_objEmployee=new clsEmployee(p_objclsEmployee.m_StrEmployeeID);
			
			m_txtTbp2EducationalLevel.Text=p_objEmployee.m_StrEducationalLevel;
			m_txtTbp2EMail.Text=p_objEmployee.m_StrEMail;
			m_txtTbp2EmployeeID.Text=p_objEmployee.m_StrEmployeeID;
			m_txtTbp2EmployeeName.Text=p_objEmployee.m_StrLastName;
			m_txtTbp2Experience.Text=p_objEmployee.m_StrExperience;
			m_txtTbp2FirstNameOfAnnouncer.Text=p_objEmployee.m_StrFirstNameOfAnnouncer;
			m_txtTbp2HomeAddress.Text=p_objEmployee.m_StrHomeAddress;
			m_txtTbp2HomePC.Text=p_objEmployee.m_StrHomePC;
			m_txtTbp2HomePhone.Text=p_objEmployee.m_StrHomePhone;
			m_txtTbp2IDCard.Text=p_objEmployee.m_StrIDCard;
			m_txtTbp2LanguageAbility.Text=p_objEmployee.m_StrLanguageAbility;


			if(p_objEmployee.m_StrMarried!=null)
			{
				switch(p_objEmployee.m_StrMarried.Trim())
				{
					case  "已婚":
						m_cboTbp2Married.SelectedIndex=0;
						break;
					case  "未婚":
						m_cboTbp2Married.SelectedIndex=1;
						break;
					case  "丧偶":
						m_cboTbp2Married.SelectedIndex=2;
						break;
					case  "离婚":
						m_cboTbp2Married.SelectedIndex=3;
						break;
					case  "其他":
						m_cboTbp2Married.SelectedIndex=4;
						break;
					default:
						m_cboTbp2Married.SelectedIndex=-1;
						break;
				}
			}
			else
			{
				m_cboTbp2Married.SelectedIndex=-1;
			}
			


			m_txtTbp2Mobile.Text=p_objEmployee.m_StrMobile;
			m_txtTbp2OfficeAddress.Text=p_objEmployee.m_StrOfficeAddress;
			m_txtTbp2OfficePC.Text=p_objEmployee.m_StrOfficePC;
			m_txtTbp2OfficePhone.Text=p_objEmployee.m_StrOfficePhone;
			m_txtTbp2PhoneOfAnnouncer.Text=p_objEmployee.m_StrPhoneOfAnnouncer;
			m_txtTbp2PYCode.Text=p_objEmployee.m_StrPYCode;
			m_txtTbp2Remark.Text=p_objEmployee.m_StrRemark;
			m_txtTbp2TitleOfaTechnicalPost.Text=p_objEmployee.m_StrTitleOfaTechnicalPost;
			if(p_objEmployee.m_StrSex!=null)
			{
				switch(p_objEmployee.m_StrSex.Trim())
				{
					case "男":
						m_cboTbp2Sex.SelectedIndex=0;
						break;
					case "女":
						m_cboTbp2Sex.SelectedIndex=1;
						break;
					case "其他":
						m_cboTbp2Sex.SelectedIndex=2;
						break;
					default:
						m_cboTbp2Sex.SelectedIndex=-1;
						break;
				}
			}
			else
			{
				m_cboTbp2Sex.SelectedIndex=-1;
			}

			m_dtpTbp2Birth.Value=p_objEmployee.m_DtmBirth==DateTime.MinValue ? DateTime.Parse("1900-1-1") : p_objEmployee.m_DtmBirth;
		}
		
		private clsEmployee_BaseInfo m_objTbp2GetEmployeeFromUI()
		{
			
			if(this.m_txtTbp2EmployeeID.Text.Trim().Length>7)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,员工编号长度不能大于7!");
				m_txtTbp2EmployeeID.Focus();
				return null;
			}	

			if(this.m_txtTbp2EmployeeID.Text.Trim() =="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写员工编号!");
				m_txtTbp2EmployeeID.Focus();
				return null;
			}			

			if( this.m_txtTbp2EmployeeName.Text.Trim()=="")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请填写员工姓名!");
				m_txtTbp2EmployeeName.Focus();
				return null;
			}

			//界面参数校验
			try
			{
				if(m_txtTbp2OfficePC.Text.Trim() !="")
					long.Parse(m_txtTbp2HomePC.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("邮编只能输入数字!");
				m_txtTbp2OfficePC.Focus();
				return null;
			}

			try
			{
				if(m_txtTbp2HomePC.Text.Trim() !="")
					long.Parse(m_txtTbp2HomePC.Text.Trim());
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("邮编只能输入数字!");
				m_txtTbp2HomePC.Focus();
				return null;
			}

			
			if(m_txtTbp2IDCard.Text.Trim() !="" && m_txtTbp2IDCard.Text.Trim().Length !=15 && m_txtTbp2IDCard.Text.Trim().Length !=18)
			{
				clsPublicFunction.ShowInformationMessageBox("身份证号输入有误!");
				m_txtTbp2IDCard.Focus();
				return null;
			}	
			if(m_cboTbp2Sex.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择姓别。");
				return null;
			}
			

			clsEmployee_BaseInfo objEmployee=new clsEmployee_BaseInfo();
			objEmployee.m_strEducationalLevel=	m_txtTbp2EducationalLevel.Text.Trim();
			objEmployee.m_strEMail=	m_txtTbp2EMail.Text.Trim();
			objEmployee.m_strEmployeeID=	m_txtTbp2EmployeeID.Text.Trim();
			objEmployee.m_strFirstName=	m_txtTbp2EmployeeName.Text.Trim();
			objEmployee.m_strExperience=	m_txtTbp2Experience.Text.Trim();
			objEmployee.m_strFirstNameOfAnnouncer=	m_txtTbp2FirstNameOfAnnouncer.Text.Trim();
			objEmployee.m_strHomeAddress=	m_txtTbp2HomeAddress.Text.Trim();
			objEmployee.m_strHomePC=	m_txtTbp2HomePC.Text.Trim();
			objEmployee.m_strHomePhone=	m_txtTbp2HomePhone.Text.Trim();
			objEmployee.m_strIDCard=	m_txtTbp2IDCard.Text.Trim();
			objEmployee.m_strLanguageAbility=	m_txtTbp2LanguageAbility.Text.Trim();
			objEmployee.m_strMarried=	m_cboTbp2Married.Text.Trim();
			objEmployee.m_strMobile=	m_txtTbp2Mobile.Text.Trim();
			objEmployee.m_strOfficeAddress=	m_txtTbp2OfficeAddress.Text.Trim();
			objEmployee.m_strOfficePC=	m_txtTbp2OfficePC.Text.Trim();
			objEmployee.m_strOfficePhone=	m_txtTbp2OfficePhone.Text.Trim();
			objEmployee.m_strPhoneOfAnnouncer=	m_txtTbp2PhoneOfAnnouncer.Text.Trim();
			objEmployee.m_strPYCode=	m_txtTbp2PYCode.Text.Trim();
			objEmployee.m_strRemark=	m_txtTbp2Remark.Text.Trim();
			objEmployee.m_strTitleOfaTechnicalPost=	m_txtTbp2TitleOfaTechnicalPost.Text.Trim();
			objEmployee.m_strSex=	m_cboTbp2Sex.Text.Trim();
			objEmployee.m_dtmBirth=	m_dtpTbp2Birth.Value;
			objEmployee.m_strLastName="";
			objEmployee.m_strLastNameOfAnnouncer="";

			return objEmployee;
		}

		private void m_mthTbp2ClearUI()
		{
			m_txtTbp2EducationalLevel.Text="";
			m_txtTbp2EMail.Text="";
			m_txtTbp2EmployeeID.Text="";
			m_txtTbp2EmployeeName.Text="";
			m_txtTbp2Experience.Text="";
			m_txtTbp2FirstNameOfAnnouncer.Text="";
			m_txtTbp2HomeAddress.Text="";
			m_txtTbp2HomePC.Text="";
			m_txtTbp2HomePhone.Text="";
			m_txtTbp2IDCard.Text="";
			m_txtTbp2LanguageAbility.Text="";
			m_cboTbp2Married.SelectedIndex=-1;
			m_txtTbp2Mobile.Text="";
			m_txtTbp2OfficeAddress.Text="";
			m_txtTbp2OfficePC.Text="";
			m_txtTbp2OfficePhone.Text="";
			m_txtTbp2PhoneOfAnnouncer.Text="";
			m_txtTbp2PYCode.Text="";
			m_txtTbp2Remark.Text="";
			m_txtTbp2TitleOfaTechnicalPost.Text="";
			m_cboTbp2Sex.SelectedIndex=-1;
			m_dtpTbp2Birth.Value=DateTime.Parse("1900-1-1");
		}


		private void m_mthTbp3SetUIFromDept(clsDepartment p_objDept)
		{
			m_txtTbp3Address.Text=p_objDept.m_StrDeptAddress;
			m_txtTbp3DeptID.Text=p_objDept.m_StrDeptID;
			m_txtTbp3DeptName.Text=p_objDept.m_StrDeptName;
			m_txtTbp3PYCode.Text=p_objDept.m_StrDeptPYCode;
			m_txtTbp3ShortNO.Text=p_objDept.m_StrDeptShortNO;

			m_cboTbp3Category.SelectedIndex=p_objDept.m_EnmDeptCategory==enmDeptCategory.临床 ? 0 : 1;
			
			if(p_objDept.m_EnmDeptType==enmDeptType.门诊)
				m_cboTbp3InPatientOrOutPatient.SelectedIndex=0;
			else if(p_objDept.m_EnmDeptType==enmDeptType.住院)
				m_cboTbp3InPatientOrOutPatient.SelectedIndex=1;
			if(p_objDept.m_EnmDeptType==enmDeptType.检验)
				m_cboTbp3InPatientOrOutPatient.SelectedIndex=2;
//			m_cboTbp3InPatientOrOutPatient.SelectedIndex=p_objDept.m_EnmDeptType==enmDeptType.门诊 ? 0 : 1;
			
		}

		private clsDept_Desc m_objTbp3GetDeptFromUI()
		{
			clsDept_Desc objDept=new clsDept_Desc();
			
			objDept.m_strAddress=	m_txtTbp3Address.Text.Trim();
			objDept.m_strDeptID=	m_txtTbp3DeptID.Text.Trim();
			objDept.m_strDeptName=	m_txtTbp3DeptName.Text.Trim();
			objDept.m_strPYCode=	m_txtTbp3PYCode.Text.Trim();
			objDept.m_strShortNO=	m_txtTbp3ShortNO.Text.Trim();
			objDept.m_strCategory=	m_cboTbp3Category.Text.Trim() == "临床" ? "0" : "1";
			
			if(m_cboTbp3InPatientOrOutPatient.SelectedIndex==-1)
				m_cboTbp3InPatientOrOutPatient.SelectedIndex=0;
			objDept.m_strInPatientOrOutPatient=	m_cboTbp3InPatientOrOutPatient.SelectedIndex.ToString();
			//objDept.m_strInPatientOrOutPatient=	m_cboTbp3InPatientOrOutPatient.Text.Trim()== "住院" ? "1" : "0";
			return objDept;
		}
		private void m_mthTbp3ClearUI()
		{
			m_txtTbp3Address.Text="";
			m_txtTbp3DeptID.Text="";
			m_txtTbp3DeptName.Text="";
			m_txtTbp3PYCode.Text="";
			m_txtTbp3ShortNO.Text="";
			m_cboTbp3Category.SelectedIndex=-1;
			m_cboTbp3InPatientOrOutPatient.SelectedIndex=-1;
		}
		#endregion

		#region 添加键盘快捷键
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{				
						string strSubTypeName = subcontrol.GetType().Name;
						if(strSubTypeName != "Lable" && strSubTypeName != "Button")												
							m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		#endregion

		#region Event Handle

		private void frmManageExplorer_Load(object sender, System.EventArgs e)
		{
			
			#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-7 17:03:11
			
			com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool = new com.digitalwave.Utility.Controls.clsBorderTool (Color.White);

			foreach(Control ctlControl in this.Controls )
			{
				string typeName = ctlControl.GetType().Name;
				if(typeName == "ctlRichTextBox" )
				{
					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
										{
											ctlControl ,
					});
				}
				if(typeName == "TextBox" )
				{
					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
										{
											ctlControl ,
					});
				}
				if(typeName == "DataGrid")
				{
					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
										{
											ctlControl ,
					});
					((DataGrid)ctlControl).AllowSorting =false ;
				}

				if(typeName =="TreeView")
				{
					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
										{
											ctlControl ,
					});
				}
				if(typeName == "GroupBox")
				{
					foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
					{
						string strSubTypeName = ctlGrp.GetType().Name;
						if(strSubTypeName == "PictureBox")
						{
							m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
														{
															ctlGrp ,
							});
						}
					}
				}
			}
			#endregion
			
			m_mthLoadTree();	
			m_mthInitJump();
		}	

		private void m_mthAdd_Click(object sender, System.EventArgs e)
		{
			m_mthShowAddBox();
		}
		private void m_mthRename_Click(object sender, System.EventArgs e)
		{
			m_mthShowRenameBox();
		}		

		private void m_trvManageExplorer_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{			
			this.Cursor=Cursors.WaitCursor;
			m_lsvManageExplorerMid.Clear();
			m_trnCurrentNode=m_trvManageExplorer.SelectedNode;
			switch(((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_intCategory)
			{
				case 0:

					m_pnlRight.Visible=false;
					m_tabQuanYuan.BringToFront();
					m_tabQuanYuan.Visible=true;
					m_trvManageExplorer.SelectedNode.ImageIndex=0;


					break;
					
				case 1:
					m_tabQuanYuan.Visible=false;
					m_pnlRight.Visible=true;
					m_trvManageExplorer.SelectedNode.ImageIndex=23;
					
					m_blnCurrentIsPatient=false;
					m_mthDisplayPnlDept();
					m_mthLoadEmployeeLsv();
					m_lblLsvManagerTitle.Text="员工:";

					#region 系统管理部门不能添加或者删除员工，只能有一个系统管理员
					if(m_trnCurrentNode.Text=="系统管理")
					{
						m_cmdDeptDeptDelete.Enabled = false;
						tabControl1.Enabled = false;
						m_cmdEmployeeAddArea.Enabled = false;
						m_cmdEmployeeDeleteArea.Enabled = false;
					}
					else
					{
						m_cmdDeptDeptDelete.Enabled = true;
						tabControl1.Enabled = true;
						m_cmdEmployeeAddArea.Enabled = true;
						m_cmdEmployeeDeleteArea.Enabled = true;
					}
					#endregion
					
					break;
				case 2:
					m_tabQuanYuan.Visible=false;
					m_pnlRight.Visible=true;
					m_trvManageExplorer.SelectedNode.ImageIndex=2;
										
					m_blnCurrentIsPatient=true;
					m_mthDisplayPnlArea();	
					m_mthLoadPatientLsv();
					m_lblLsvManagerTitle.Text="病人/病床:";
					break;
				default:
					m_tabQuanYuan.Visible=false;
					m_pnlRight.Visible=true;				
					break;

			}
			this.Cursor=Cursors.Default;

		}
		#endregion		

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			m_pnlBed.Visible=true;
			m_pnlBed.BringToFront();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			m_pnlPatient.Visible=true;
			m_pnlPatient.BringToFront();
		}	

		private void m_lsvManageExplorerMid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsvManageExplorerMid.SelectedItems.Count<=0)
			{
				if(((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_intCategory==2)
				{
					m_mthDisplayPnlArea();
				}
				else if(((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_intCategory==1)
				{
					m_mthDisplayPnlDept();
				}

				return;
			}
			if(m_lsvManageExplorerMid.SelectedItems[0].Tag.GetType().Name=="clsBedInfo")
			{
				
				if(((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID==null
					|| ((clsBedInfo)m_lsvManageExplorerMid.SelectedItems[0].Tag).m_strBedInPatientID=="")
				{
					m_mthDisplayPnlBed();
				}
				else
				{
					m_mthDisplayPnlPatient();
				}
			}
			else
			{
				m_mthDisplayPnlEmployee();
				
			}
		}

		private void m_txtQuanYuanAdd_Click(object sender, System.EventArgs e)
		{
			m_mthAddDept();
		}

		private void m_cmdDeptAddArea_Click(object sender, System.EventArgs e)
		{
			m_mthDeptAddArea();
		}

		private void m_cmdDeptDeptDelete_Click(object sender, System.EventArgs e)
		{
			m_mthDeptDelete();
		}

		private void m_rdbPatientLsv_Click(object sender, System.EventArgs e)
		{
			if(m_trvManageExplorer.SelectedNode==null || ((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_intCategory!=2) return;
//			if(m_strCurrentArea!= ((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_strID) return;
			this.Cursor=Cursors.WaitCursor;
			m_blnCurrentIsPatient=true;
//			m_gpbAddEmployee.Visible=false;
			m_mthLoadPatientLsv();
			m_mthDisplayPnlArea();
			this.Cursor=Cursors.Default;
		
		}

		private void m_rdbEmployeeLsv_Click(object sender, System.EventArgs e)
		{
			if(m_trvManageExplorer.SelectedNode==null || ((clsNodeInfo) m_trvManageExplorer.SelectedNode.Tag).m_intCategory!=2) return;
			m_blnCurrentIsPatient=false;
//			m_gpbAddEmployee.Visible=true;
			m_mthLoadEmployeeLsv();
			m_mthDisplayPnlArea();
			//m_rdbEmployeeLsv.ch
		}

		private void m_cmdAreaApplyName_Click(object sender, System.EventArgs e)
		{
			m_mthAreaRename();
		}

		private void m_cmdAreaDeleteArea_Click(object sender, System.EventArgs e)
		{
			m_mthAreaDelete();
		}

		private void m_cmdBedRename_Click(object sender, System.EventArgs e)
		{
			m_mthBedRename();
		}

		private void m_cmdBedApplyBedToPatient_Click(object sender, System.EventArgs e)
		{
			m_mthBedAddPatientToBed();
		}

		private void m_cmdEmployeeAddArea_Click(object sender, System.EventArgs e)
		{
			m_mthEmployeeAddDept();
		}

		private void m_cmdEmployeeDeleteArea_Click(object sender, System.EventArgs e)
		{
			m_mthEmployeeDeleteDept();
		}

		private void m_cmdPatientChangeBed_Click(object sender, System.EventArgs e)
		{
			if(m_cboPatientBedStatus.Text.Trim()=="在床")
			{
				m_mthPatientTurnToBed();
			}
			else if(m_cboPatientBedStatus.Text.Trim()=="下床")
			{
				m_mthPatientLeaveBed();
			}
			else if(m_cboPatientBedStatus.Text.Trim()=="转床")
			{
				m_mthPatientTurnToBed();
				m_lblZCInf.Visible=true;
			}
			else
			{
				if(m_cboPatientBedStatus.Text.Trim()=="出院")
				{
					m_mthPatientLeaveHospital(0);
				}
				else if(m_cboPatientBedStatus.Text.Trim()=="死亡")
				{
					m_mthPatientLeaveHospital(1);
				}
				else
				{
					m_mthPatientLeaveHospital(2);
				}
			}
		}

		private void m_trvManageExplorer_Click(object sender, System.EventArgs e)
		{
			m_lblZCInf.Visible=false;
			if(m_trvManageExplorer.SelectedNode==null) return;
			if(m_trnCurrentNode!= m_trvManageExplorer.SelectedNode) return;
			if(((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_intCategory==2)
			{
			
				this.Cursor=Cursors.WaitCursor;
//				m_lsvManageExplorerMid.Clear();
				m_mthDisplayPnlArea();
				m_mthLoadPatientLsv();
				m_lblLsvManagerTitle.Text="病人/病床:";
				this.Cursor=Cursors.Default;
			}
			else if(((clsNodeInfo)m_trvManageExplorer.SelectedNode.Tag).m_intCategory==1)
			{
				this.Cursor=Cursors.WaitCursor;
				m_mthDisplayPnlDept();
				m_mthLoadEmployeeLsv();
				m_lblLsvManagerTitle.Text="员工:";
				this.Cursor=Cursors.Default;
			}		
			m_upDataLeavePatientListVeiw();
			
		}

		private void m_cmdBedDeleteBed_Click(object sender, System.EventArgs e)
		{
			m_mthBedDeleteBed();
		}

		private void m_cboPatientBedStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboPatientBedStatus.Text.Trim()=="下床")
			{
				m_cboPatientBedDept.ClearItem();
				m_cboPatientBedName.ClearItem();
				m_cboPatientBedArea.ClearItem();

				m_cboPatientBedDept.SelectedIndex=-1;
				m_cboPatientBedArea.SelectedIndex=-1;
				m_cboPatientBedName.SelectedIndex=-1;
			}
			if(m_cboPatientBedStatus.Text.Trim()=="转床")
			{
				label12.Visible=true;
				m_cboPatientBedDept.Visible=true;
				label13.Visible=true;
				m_cboPatientBedArea.Visible=true;
				label14.Visible=true;
				m_cboPatientBedName.Visible=true;
			}
			else
			{
				label12.Visible=false;
				m_cboPatientBedDept.Visible=false;
				label13.Visible=false;
				m_cboPatientBedArea.Visible=false;
				label14.Visible=false;
				m_cboPatientBedName.Visible=false;
			}
		}

		private void m_cboPatientBedDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			m_cboPatientBedName.ClearItem();
			m_cboPatientBedArea.ClearItem();

			m_cboPatientBedArea.SelectedIndex=-1;
			m_cboPatientBedName.SelectedIndex=-1;

			m_mthPatientLoadArea(m_cboPatientBedArea);
		}

		private void m_cboPatientBedArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_cboPatientBedName.ClearItem();

			m_cboPatientBedName.SelectedIndex=-1;
		}

//		private void m_cboPatientBedDept_DropDown(object sender, System.EventArgs e)
//		{
//
//			m_cboPatientBedName.ClearItem();
//			m_cboPatientBedArea.ClearItem();
//
//
//			m_cboPatientBedArea.Text="";
//			m_cboPatientBedName.Text="";
//			m_mthPatientLoadDept();
//			
//		}
//
//		private void m_cboPatientBedArea_DropDown(object sender, System.EventArgs e)
//		{
//
//			m_cboPatientBedName.ClearItem();
//
//			m_cboPatientBedName.Text="";
//			m_mthPatientLoadArea();
//			
//		}
//
//		private void m_cboPatientBedName_DropDown(object sender, System.EventArgs e)
//		{
//			
//			m_mthPatientLoadBed();
//			
//		}
//
//		private void m_cboBedAddPatient_DropDown(object sender, System.EventArgs e)
//		{
//			m_mthBedLoadAvailablePatient();
//		}

		private void m_cmdAreaAddBed_Click(object sender, System.EventArgs e)
		{
			m_mthAreaAddBed();
		}


		private void m_cmdDeptDeptInfo_Click(object sender, System.EventArgs e)
		{
			m_mthDeptChangeInfo();
		}

		private void m_cmdEmployeeEmployeeInfo_Click(object sender, System.EventArgs e)
		{
			m_mthEmployeeChangeInfo();
		}

		private void m_cmdPatientPatientInfo_Click(object sender, System.EventArgs e)
		{
			m_mthPatientChangeInfo();
		}

		private void m_cmdAddPatient_Click(object sender, System.EventArgs e)
		{
			m_mthAddPatient();
		}

		private void m_cboBedAddPatient_DropDown_1(object sender, System.EventArgs e)
		{
//			string[] strPatientID
//			m_objManagerDomain.m_lngGetPatientArrThatNotHasBed();
			m_mthBedLoadAvailablePatient();
		}

		private void m_cboPatientBedDept_DropDown_1(object sender, System.EventArgs e)
		{
			m_cboPatientBedName.ClearItem();
			m_cboPatientBedArea.ClearItem();


			m_cboPatientBedArea.SelectedIndex=-1;
			m_cboPatientBedName.SelectedIndex=-1;
			m_mthPatientLoadDept(m_cboPatientBedDept);
		}
		private void m_cboPatientBedDept_DropDown_2(object sender, System.EventArgs e)
		{
			m_cboPatientBedName2.ClearItem();
			m_cboPatientBedArea2.ClearItem();


			m_cboPatientBedArea2.SelectedIndex=-1;
			m_cboPatientBedName2.SelectedIndex=-1;
			m_mthPatientLoadDept(m_cboPatientBedDept2);
		}

		private void m_cboPatientBedArea_DropDown_1(object sender, System.EventArgs e)
		{
			m_cboPatientBedName.ClearItem();
	
			m_cboPatientBedName.SelectedIndex=-1;
			//m_mthPatientLoadArea(m_cboPatientBedArea);
			m_mthPatientLoadAreaByDept(m_cboPatientBedArea,m_cboPatientBedDept);
		}
		private void m_cboPatientBedArea_DropDown_2(object sender, System.EventArgs e)
		{
			m_cboPatientBedName2.ClearItem();
	
			m_cboPatientBedName2.SelectedIndex=-1;
			m_mthPatientLoadArea(m_cboPatientBedArea2);
		}

		private void m_cboPatientBedName_DropDown(object sender, System.EventArgs e)
		{
			m_mthPatientLoadBed((Control)sender);
		}

		private void m_cboEmployeeDeptName_DropDown(object sender, System.EventArgs e)
		{
			m_mthEmployeeLoadAvailableDept();
		}

//		private void m_cboEmployeeAreaName_DropDown(object sender, System.EventArgs e)
//		{
//			m_mthEmployeeLoadAvailableArea();
//		}

		private void m_cmdAddEmployee_Click(object sender, System.EventArgs e)
		{
			m_mthAddEmployee();
		}

		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
//			if(m_lsvManageExplorerMid.SelectedItems.Count==0 || m_lsvManageExplorerMid.SelectedItems[0].Tag==null) return;
			switch(e.KeyValue)
			{// enter	//Arrow Up //Arrow Down	
					#region enter
				case 13:// enter	
				
					if( ((Control)sender).Name=="m_txtTbp2EmployeeID")
					{
						m_lsvTbp2EmployeeID.Visible=true;
						m_lsvTbp2EmployeeID.Focus();
						m_mthLoadEmployeeIDLsv();
						if(m_lsvTbp2EmployeeID.Items.Count==1 && m_txtTbp2EmployeeID.Text.Trim()==m_lsvTbp2EmployeeID.Items[0].SubItems[0].Text.Trim())
						{
							m_lsvTbp2EmployeeID.Items[0].Selected=true;
							m_mthTbp2SetUIFromEmployee((clsEmployee)m_lsvTbp2EmployeeID.SelectedItems[0].Tag);
							m_lsvTbp2EmployeeID.Visible = false;
							break;
						}
					}
					else if( ((Control)sender).Name=="m_lsvTbp2EmployeeID")
					{
						if(m_lsvTbp2EmployeeID.SelectedItems.Count==1)
						{
							m_mthTbp2SetUIFromEmployee((clsEmployee)m_lsvTbp2EmployeeID.SelectedItems[0].Tag);
							m_txtTbp2EmployeeID.Focus();
							m_lsvTbp2EmployeeID.Visible = false;
							break;
						}
					}

					else if( ((Control)sender).Name=="m_txtTbp2EmployeeName")
					{
						m_lsvTbp2EmployeeName.Visible=true;
						m_lsvTbp2EmployeeName.Focus();
						m_mthLoadEmployeeNameLsv();
						if(m_lsvTbp2EmployeeName.Items.Count==1 && m_txtTbp2EmployeeName.Text==m_lsvTbp2EmployeeName.Items[0].SubItems[1].Text)
						{
							m_lsvTbp2EmployeeName.Items[0].Selected=true;
							m_mthTbp2SetUIFromEmployee((clsEmployee)m_lsvTbp2EmployeeName.SelectedItems[0].Tag);
							m_lsvTbp2EmployeeName.Visible = false;
							break;
						}
					}
					else if( ((Control)sender).Name=="m_lsvTbp2EmployeeName")
					{
						if(m_lsvTbp2EmployeeName.SelectedItems.Count==1)
						{
							m_mthTbp2SetUIFromEmployee((clsEmployee)m_lsvTbp2EmployeeName.SelectedItems[0].Tag);
							m_lsvTbp2EmployeeName.Visible = false;
							m_txtTbp2EmployeeName.Focus();
							break;
						}
					}

					else if( ((Control)sender).Name=="m_txtTbp1InPatientID")
					{
						m_lsvTbp1InPatientID.Visible=true;
						m_lsvTbp1InPatientID.Focus();
						m_mthLoadPatientIDLsv();
						if(m_lsvTbp1InPatientID.Items.Count==1 && m_txtTbp1InPatientID.Text.Trim()==m_lsvTbp1InPatientID.Items[0].SubItems[0].Text)
						{
							m_lsvTbp1InPatientID.Items[0].Selected=true;
							m_mthTbp1SetUIFromPatient((clsPatient)m_lsvTbp1InPatientID.SelectedItems[0].Tag);
							m_lsvTbp1InPatientID.Visible = false;
							break;
						}
//						m_lsvTbp1InPatientID.Sort();
					}
					else if( ((Control)sender).Name=="m_lsvTbp1InPatientID")
					{
						if(m_lsvTbp1InPatientID.SelectedItems.Count==1)
						{
							m_mthTbp1SetUIFromPatient((clsPatient)m_lsvTbp1InPatientID.SelectedItems[0].Tag);
							m_lsvTbp1InPatientID.Visible = false;
							m_txtTbp1InPatientID.Focus();
							break;
						}
					}	
					else if( ((Control)sender).Name=="m_txtTbp1PatientFirstName")
					{
						m_lsvTbp1InPatientName.Visible=true;
						m_lsvTbp1InPatientName.Focus();
						m_mthLoadPatientNameLsv();
						if(m_lsvTbp1InPatientName.Items.Count==1 && m_txtTbp1PatientFirstName.Text.Trim()==m_lsvTbp1InPatientName.Items[0].SubItems[1].Text)
						{
							m_lsvTbp1InPatientName.Items[0].Selected=true;
							m_mthTbp1SetUIFromPatient((clsPatient)m_lsvTbp1InPatientName.SelectedItems[0].Tag);
							m_lsvTbp1InPatientName.Visible = false;
							break;
						}
//						m_lsvTbp1InPatientName.Sort();
					}
					else if( ((Control)sender).Name=="m_lsvTbp1InPatientName")
					{
						if(m_lsvTbp1InPatientName.SelectedItems.Count==1)
						{
							m_mthTbp1SetUIFromPatient((clsPatient)m_lsvTbp1InPatientName.SelectedItems[0].Tag);
							m_lsvTbp1InPatientName.Visible = false;
							m_txtTbp1PatientFirstName.Focus();
							break;
						}
					}		
					else if( ((Control)sender).Name=="m_txtTbp3DeptID")
					{
						m_lsvTbp3DeptID.Visible=true;
						m_lsvTbp3DeptID.Focus();
						m_mthLoadDeptIDLsv();
						if(m_lsvTbp3DeptID.Items.Count==1 && m_txtTbp3DeptID.Text.Trim()==m_lsvTbp3DeptID.Items[0].SubItems[0].Text)
						{
							m_lsvTbp3DeptID.Items[0].Selected=true;
							m_mthTbp3SetUIFromDept((clsDepartment)m_lsvTbp3DeptID.SelectedItems[0].Tag);
							m_lsvTbp3DeptID.Visible = false;
							break;
						}
						
					}
					else if( ((Control)sender).Name=="m_lsvTbp3DeptID")
					{
						if(m_lsvTbp3DeptID.SelectedItems.Count==1)
						{
							m_mthTbp3SetUIFromDept((clsDepartment)m_lsvTbp3DeptID.SelectedItems[0].Tag);
							m_lsvTbp3DeptID.Visible = false;
							m_txtTbp3DeptID.Focus();
							break;
						}
					}	
					else if( ((Control)sender).Name=="m_txtTbp3DeptName")
					{
						m_lsvTbp3DeptName.Visible=true;
						m_lsvTbp3DeptName.Focus();
						m_mthLoadDeptNameLsv();
						if(m_lsvTbp3DeptName.Items.Count==1 && m_txtTbp3DeptName.Text.Trim()==m_lsvTbp3DeptName.Items[0].SubItems[1].Text)
						{
							m_lsvTbp3DeptName.Items[0].Selected=true;
							m_mthTbp3SetUIFromDept((clsDepartment)m_lsvTbp3DeptName.SelectedItems[0].Tag);
							m_lsvTbp3DeptName.Visible = false;
							break;
						}
						
					}
					else if( ((Control)sender).Name=="m_lsvTbp3DeptName")
					{
						if(m_lsvTbp3DeptName.SelectedItems.Count==1)
						{
							m_mthTbp3SetUIFromDept((clsDepartment)m_lsvTbp3DeptName.SelectedItems[0].Tag);
							m_lsvTbp3DeptName.Visible = false;
							m_txtTbp3DeptName.Focus();
							break;
						}
					}	
					else if( ((Control)sender).Name=="m_txtDeptAddEmployeeID")
					{
						m_lsvDeptTbp2EmployeeID.Left=m_txtDeptAddEmployeeID.Left;
						m_lsvDeptTbp2EmployeeID.Visible=true;
						m_lsvDeptTbp2EmployeeID.BringToFront();
						m_lsvDeptTbp2EmployeeID.Focus();
						m_mthLoadDeptTbp2EmployeeIDLsv();
						if(m_lsvDeptTbp2EmployeeID.Items.Count==1 && m_txtDeptAddEmployeeID.Text.Trim()==m_lsvDeptTbp2EmployeeID.Items[0].SubItems[0].Text)
						{
							m_lsvDeptTbp2EmployeeID.Items[0].Selected=true;
							m_txtDeptAddEmployeeID.Text=m_lsvDeptTbp2EmployeeID.SelectedItems[0].SubItems[0].Text;
							m_txtDeptAddEmployeeName.Text=m_lsvDeptTbp2EmployeeID.SelectedItems[0].SubItems[1].Text;
//							m_mthDeptTbp3SetUIFromDept((clsEmployee)m_lsvDeptTbp2EmployeeID.SelectedItems[0].Tag);
							m_lsvDeptTbp2EmployeeID.Visible = false;
							break;
						}
						
					}
					else if( ((Control)sender).Name=="m_lsvDeptTbp2EmployeeID")
					{
						if(m_lsvDeptTbp2EmployeeID.SelectedItems.Count==1)
						{
							m_txtDeptAddEmployeeID.Text=m_lsvDeptTbp2EmployeeID.SelectedItems[0].SubItems[0].Text;
							m_txtDeptAddEmployeeName.Text=m_lsvDeptTbp2EmployeeID.SelectedItems[0].SubItems[1].Text;
//							m_mthTbp3SetUIFromDept((clsEmployee)m_lsvDeptTbp2EmployeeID.SelectedItems[0].Tag);
							m_lsvDeptTbp2EmployeeID.Visible = false;
							m_txtDeptAddEmployeeID.Focus();
							break;
						}
					}	
					else if( ((Control)sender).Name=="m_txtDeptAddEmployeeName")
					{
						m_lsvDeptTbp2EmployeeName.Left=m_pnlDept.Left+tabControl1.Left +m_tbpDeptAddArea.Left+m_txtDeptAddEmployeeName.Left;
						m_lsvDeptTbp2EmployeeName.Visible=true;
						m_lsvDeptTbp2EmployeeName.BringToFront();
						m_lsvDeptTbp2EmployeeName.Focus();
						m_mthLoadDeptTbp2EmployeeNameLsv();
						if(m_lsvDeptTbp2EmployeeName.Items.Count==1 && m_txtDeptAddEmployeeName.Text.Trim()==m_lsvDeptTbp2EmployeeName.Items[0].SubItems[1].Text)
						{
							m_lsvDeptTbp2EmployeeName.Items[0].Selected=true;
							m_txtDeptAddEmployeeID.Text=m_lsvDeptTbp2EmployeeName.SelectedItems[0].SubItems[0].Text;
							m_txtDeptAddEmployeeName.Text=m_lsvDeptTbp2EmployeeName.SelectedItems[0].SubItems[1].Text;
							//							m_mthDeptTbp3SetUIFromDept((clsEmployee)m_lsvDeptTbp2EmployeeID.SelectedItems[0].Tag);
							m_lsvDeptTbp2EmployeeName.Visible = false;
							break;
						}
						
					}
					else if( ((Control)sender).Name=="m_lsvDeptTbp2EmployeeName")
					{
						if(m_lsvDeptTbp2EmployeeName.SelectedItems.Count==1)
						{
							m_txtDeptAddEmployeeID.Text=m_lsvDeptTbp2EmployeeName.SelectedItems[0].SubItems[0].Text;
							m_txtDeptAddEmployeeName.Text=m_lsvDeptTbp2EmployeeName.SelectedItems[0].SubItems[1].Text;
							//							m_mthTbp3SetUIFromDept((clsEmployee)m_lsvDeptTbp2EmployeeID.SelectedItems[0].Tag);
							m_lsvDeptTbp2EmployeeName.Visible = false;
							m_txtDeptAddEmployeeName.Focus();
							break;
						}
					}
					
					
					break;

					#endregion]

					#region Arrown Up

				case 38://Arrow Up
					if( ((Control)sender).Name=="m_lsvTbp2EmployeeID")
					{
						if(m_lsvTbp2EmployeeID.Items.Count > 0 && m_lsvTbp2EmployeeID.Items[0].Selected)
							m_txtTbp2EmployeeID.Focus();					
					}	
					else if( ((Control)sender).Name=="m_lsvTbp2EmployeeName")
					{
						if(m_lsvTbp2EmployeeName.Items.Count > 0 && m_lsvTbp2EmployeeName.Items[0].Selected)
							m_txtTbp2EmployeeName.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvTbp1InPatientID")
					{
						if(m_lsvTbp1InPatientID.Items.Count > 0 && m_lsvTbp1InPatientID.Items[0].Selected)
							m_txtTbp1InPatientID.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvTbp1InPatientName")
					{
						if(m_lsvTbp1InPatientName.Items.Count > 0 && m_lsvTbp1InPatientName.Items[0].Selected)
							m_txtTbp1PatientFirstName.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvTbp3DeptID")
					{
						if(m_lsvTbp3DeptID.Items.Count > 0 && m_lsvTbp3DeptID.Items[0].Selected)
							m_txtTbp3DeptID.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvTbp3DeptName")
					{
						if(m_lsvTbp3DeptName.Items.Count > 0 && m_lsvTbp3DeptName.Items[0].Selected)
							m_txtTbp3DeptName.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvDeptTbp2EmployeeID")
					{
						if(m_lsvDeptTbp2EmployeeID.Items.Count > 0 && m_lsvDeptTbp2EmployeeID.Items[0].Selected)
							m_txtDeptAddEmployeeID.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvDeptTbp2EmployeeName")
					{
						if(m_lsvDeptTbp2EmployeeName.Items.Count > 0 && m_lsvDeptTbp2EmployeeName.Items[0].Selected)
							m_txtDeptAddEmployeeName.Focus();					
					}
//					
					break;
					#endregion

					#region Arrow Down
				case 40://Arrow Down				
					if( ((Control)sender).Name=="m_txtTbp2EmployeeID")
					{
						m_lsvTbp2EmployeeID.Visible=true;
						m_lsvTbp2EmployeeID.Focus();
						m_mthLoadEmployeeIDLsv();
						//m_lsvInPatientID.Visible=true;						
						if( m_lsvTbp2EmployeeID.Visible && m_lsvTbp2EmployeeID.Items.Count>0)
						{
							m_lsvTbp2EmployeeID.Focus();
							m_lsvTbp2EmployeeID.Items[0].Selected=true;
							m_lsvTbp2EmployeeID.Items[0].Focused=true;
						}	
						
					}		

					else if( ((Control)sender).Name=="m_txtTbp2EmployeeName")
					{
						m_lsvTbp2EmployeeName.Visible=true;
						m_lsvTbp2EmployeeName.Focus();
						m_mthLoadEmployeeNameLsv();
						//m_lsvPatientName.Visible=true;						
						if( m_lsvTbp2EmployeeName.Items.Count>0)
						{
							m_lsvTbp2EmployeeName.Focus();
							m_lsvTbp2EmployeeName.Items[0].Selected=true;
							m_lsvTbp2EmployeeName.Items[0].Focused=true;
						}						
					}
					else if( ((Control)sender).Name=="m_txtTbp1InPatientID")
					{
						m_lsvTbp1InPatientID.Visible=true;
						m_lsvTbp1InPatientID.Focus();
						m_mthLoadPatientIDLsv();
						//m_lsvPatientName.Visible=true;						
						if( m_lsvTbp1InPatientID.Items.Count>0)
						{
							m_lsvTbp1InPatientID.Focus();
							m_lsvTbp1InPatientID.Items[0].Selected=true;
							m_lsvTbp1InPatientID.Items[0].Focused=true;
						}						
					}
					else if( ((Control)sender).Name=="m_txtTbp1PatientFirstName")
					{
						m_lsvTbp1InPatientName.Visible=true;
						m_lsvTbp1InPatientName.Focus();
						m_mthLoadPatientNameLsv();
						//m_lsvPatientName.Visible=true;						
						if( m_lsvTbp1InPatientName.Items.Count>0)
						{
							m_lsvTbp1InPatientName.Focus();
							m_lsvTbp1InPatientName.Items[0].Selected=true;
							m_lsvTbp1InPatientName.Items[0].Focused=true;
						}						
					}
					else if( ((Control)sender).Name=="m_txtTbp3DeptID")
					{
						m_lsvTbp3DeptID.Visible=true;
						m_lsvTbp3DeptID.Focus();
						m_mthLoadDeptIDLsv();
						//m_lsvPatientName.Visible=true;						
						if( m_lsvTbp2EmployeeName.Items.Count>0)
						{
							m_lsvTbp3DeptID.Focus();
							m_lsvTbp3DeptID.Items[0].Selected=true;
							m_lsvTbp3DeptID.Items[0].Focused=true;
						}						
					}
					else if( ((Control)sender).Name=="m_txtTbp3DeptName")
					{
						m_lsvTbp3DeptName.Visible=true;
						m_lsvTbp3DeptName.Focus();
						m_mthLoadDeptNameLsv();
						//m_lsvPatientName.Visible=true;						
						if( m_lsvTbp3DeptName.Items.Count>0)
						{
							m_lsvTbp3DeptName.Focus();
							m_lsvTbp3DeptName.Items[0].Selected=true;
							m_lsvTbp3DeptName.Items[0].Focused=true;
						}						
					}
					else if( ((Control)sender).Name=="m_txtDeptAddEmployeeID")
					{
						m_lsvDeptTbp2EmployeeID.Visible=true;
						m_lsvDeptTbp2EmployeeID.BringToFront();
						m_lsvDeptTbp2EmployeeID.Focus();
						m_mthLoadDeptTbp2EmployeeIDLsv();
						//m_lsvPatientName.Visible=true;						
						if( m_lsvDeptTbp2EmployeeID.Items.Count>0)
						{
							m_lsvDeptTbp2EmployeeID.Focus();
							m_lsvDeptTbp2EmployeeID.Items[0].Selected=true;
							m_lsvDeptTbp2EmployeeID.Items[0].Focused=true;
						}						
					}
					else if( ((Control)sender).Name=="m_txtDeptAddEmployeeName")
					{
						m_lsvDeptTbp2EmployeeName.Visible=true;
						m_lsvDeptTbp2EmployeeName.BringToFront();
						m_lsvDeptTbp2EmployeeName.Focus();
						m_mthLoadDeptTbp2EmployeeNameLsv();
						//m_lsvPatientName.Visible=true;						
						if( m_lsvDeptTbp2EmployeeName.Items.Count>0)
						{
							m_lsvDeptTbp2EmployeeName.Focus();
							m_lsvDeptTbp2EmployeeName.Items[0].Selected=true;
							m_lsvDeptTbp2EmployeeName.Items[0].Focused=true;
						}						
					}
//					
					break;		
					#endregion

					#region Esc
				case 27:	//Esc
					if( ((Control)sender).Name=="m_lsvTbp2EmployeeID")
					{
						
							m_txtTbp2EmployeeID.Focus();					
					}	
					else if( ((Control)sender).Name=="m_lsvTbp2EmployeeName")
					{
						
							m_txtTbp2EmployeeName.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvTbp1InPatientID")
					{
						
							m_txtTbp1InPatientID.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvTbp1InPatientName")
					{
						
							m_txtTbp1PatientFirstName.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvTbp3DeptID")
					{
						
							m_txtTbp3DeptID.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvTbp3DeptName")
					{
						
							m_txtTbp3DeptName.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvDeptTbp2EmployeeID")
					{
						
						m_txtDeptAddEmployeeID.Focus();					
					}
					else if( ((Control)sender).Name=="m_lsvDeptTbp2EmployeeName")
					{
						
						m_txtDeptAddEmployeeName.Focus();					
					}

					
					break;
					#endregion

					#region F5
				case 116:
					m_mthTbp1ClearUI();
					m_mthTbp2ClearUI();
					m_mthTbp3ClearUI();
					break;
					#endregion
					
			}	
		}


		private void m_mthEvent_DoubleClikcLsv(object sender, System.EventArgs e)
		{
			if(((Control)sender).GetType().Name!="ListView") return;
			if(((ListView)sender).SelectedItems.Count==0) return;
			switch(((Control)sender).Name)
			{
				case "m_lsvTbp1InPatientID":
					m_mthTbp1SetUIFromPatient(((clsPatient)((ListView)sender).SelectedItems[0].Tag));
					m_txtTbp1InPatientID.Focus();
					break;
				case "m_lsvTbp1InPatientName":
					m_mthTbp1SetUIFromPatient(((clsPatient)((ListView)sender).SelectedItems[0].Tag));
					m_txtTbp1PatientFirstName.Focus();
					break;
				case "m_lsvTbp2EmployeeID":
					m_mthTbp2SetUIFromEmployee(((clsEmployee)((ListView)sender).SelectedItems[0].Tag));
					m_txtTbp2EmployeeID.Focus();
					break;
				case "m_lsvTbp2EmployeeName":
					m_mthTbp2SetUIFromEmployee(((clsEmployee)((ListView)sender).SelectedItems[0].Tag));
					m_txtTbp2EmployeeName.Focus();
					break;
				case "m_lsvTbp3DeptID":
					m_mthTbp3SetUIFromDept(((clsDepartment)((ListView)sender).SelectedItems[0].Tag));
					m_txtTbp3DeptID.Focus();
					break;
				case "m_lsvTbp3DeptName":
					m_mthTbp3SetUIFromDept(((clsDepartment)((ListView)sender).SelectedItems[0].Tag));
					m_txtTbp3DeptName.Focus();
					break;
				case "m_lsvDeptTbp2EmployeeID":
					m_txtDeptAddEmployeeID.Text=((ListView)sender).SelectedItems[0].SubItems[0].Text.Trim();
					m_txtDeptAddEmployeeName.Text=((ListView)sender).SelectedItems[0].SubItems[1].Text.Trim();
					m_txtDeptAddEmployeeID.Focus();
					break;
				case "m_lsvDeptTbp2EmployeeName":
					m_txtDeptAddEmployeeID.Text=((ListView)sender).SelectedItems[0].SubItems[0].Text.Trim();
					m_txtDeptAddEmployeeName.Text=((ListView)sender).SelectedItems[0].SubItems[1].Text.Trim();
					m_txtDeptAddEmployeeName.Focus();
					break;
				default:
					break;
			}
			
		}

		private void m_mthEvent_LsvLostFocus(object sender, System.EventArgs e)
		{
			if(((Control)sender).GetType().Name=="ListView")((Control)sender).Visible=false;
		}

		private void m_cmdTbp1OK_Click(object sender, System.EventArgs e)
		{
			m_mthAddPatient();
		}

		private void m_cmdTbp2OK_Click(object sender, System.EventArgs e)
		{
			m_mthAddEmployee();
		}

		private void m_cmdDeptTbp2AddEmployee_Click(object sender, System.EventArgs e)
		{
			if(m_txtDeptAddEmployeeName.Text.Trim()=="系统管理员")
			{
				clsPublicFunction.ShowInformationMessageBox("不能调入系统管理员！");
				return;
			}
			m_mthDeptAddEmployee();
		}

		private void m_cmdTbp3OK_Click(object sender, System.EventArgs e)
		{
			m_mthAddDept();
		}

		private void m_cboPatientBedStatus_DropDown(object sender, System.EventArgs e)
		{
			m_cboPatientBedDept.ClearItem();
			m_cboPatientBedName.ClearItem();
			m_cboPatientBedArea.ClearItem();

			m_cboPatientBedDept.SelectedIndex=-1;
			m_cboPatientBedArea.SelectedIndex=-1;
			m_cboPatientBedName.SelectedIndex=-1;
		}

		private void m_cmdTbp1ClearForm_Click(object sender, System.EventArgs e)
		{
			m_mthTbp1ClearUI();
		}


		private void m_cmdTbp2ClearForm_Click(object sender, System.EventArgs e)
		{
			m_mthTbp2ClearUI();
		}

		private void m_cmdTbp3ClearForm_Click(object sender, System.EventArgs e)
		{
			m_mthTbp3ClearUI();
		}

		#region PublicControls
		public void Save(){}
		public void Delete(){}
		public void Display(){}
		public void Display(string cardno,string sendcheckdate){}
		public void Print(){}		
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Verify()
		{
			////long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		#region Copy,Cut,Paste
		/// <summary>
		/// 复制操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngCopy()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;
			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						if(((ctlRichTextBox)ctlControl).Text != "")
						{
							((ctlRichTextBox)ctlControl).Copy();
							return 1;
						}
						break;
					
					case "RichTextBox":
						if(((RichTextBox)ctlControl).Text != "")
						{
							((RichTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "TextBox":
						if(((TextBox)ctlControl).Text != "")
						{
							((TextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "ctlBorderTextBox":
						if(((ctlBorderTextBox)ctlControl).Text != "")
						{
							((ctlBorderTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "DataGridTextBox":
						if(((DataGridTextBox)ctlControl).Text != "")
						{
							((DataGridTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					default:
						Clipboard.SetDataObject("");
						break;
				}
			}

			return 0;
		}

		/// <summary>
		/// 剪切操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngCut()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;
			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						if(((ctlRichTextBox)ctlControl).Text != "")
						{
							((ctlRichTextBox)ctlControl).Cut();
							return 1;
						}
						break;
					
					case "RichTextBox":
						if(((RichTextBox)ctlControl).Text != "")
						{
							((RichTextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "TextBox":
						if(((TextBox)ctlControl).Text != "")
						{
							((TextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "ctlBorderTextBox":
						if(((ctlBorderTextBox)ctlControl).Text != "")
						{
							((ctlBorderTextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "DataGridTextBox":
						if(((DataGridTextBox)ctlControl).Text != "")
						{
							((DataGridTextBox)ctlControl).Cut();
							return 1;
						}
						break;
				}
			}

			return 0;
		}

		/// <summary>
		/// 粘贴操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngPaste()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;

			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						((ctlRichTextBox)ctlControl).Paste();
						break;

					case "RichTextBox":
						((RichTextBox)ctlControl).Paste();
						break;

					case "TextBox":
						((TextBox)ctlControl).Paste();
						break;

					case "ctlBorderTextBox":
						((ctlBorderTextBox)ctlControl).Paste();
						break;

					case "DataGridTextBox":
						((DataGridTextBox)ctlControl).Paste();
						break;
				}
				return 1;
			}

			return 0;
		}
		#endregion

		private void m_chkTbp1IsOldPatient_CheckedChanged(object sender, System.EventArgs e)
		{
			m_blnIsOldPatient=m_chkTbp1IsOldPatient.Checked;
		
			foreach(Control ctlCtl in m_tbpPatient.Controls)
			{
				if(ctlCtl.GetType().Name=="TextBox" || ctlCtl.GetType().Name=="ctlBorderTextBox"
					||ctlCtl.GetType().Name=="ctlComboBox" || ctlCtl.GetType().Name=="ctlTimePicker")
				{
					if(ctlCtl.Name!="m_txtTbp1InPatientID")
					{
						ctlCtl.Enabled=!m_blnIsOldPatient;
					}
				}
			}
		
			
		}
		#endregion PublicControls			

		private void m_lsvDeptTbp2EmployeeID_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvDeptTbp2EmployeeID.SelectedItems.Count==1)
			{
				m_txtDeptAddEmployeeID.Text=m_lsvDeptTbp2EmployeeID.SelectedItems[0].SubItems[0].Text;
				m_txtDeptAddEmployeeName.Text=m_lsvDeptTbp2EmployeeID.SelectedItems[0].SubItems[1].Text;
				m_lsvDeptTbp2EmployeeID.Visible = false;
				m_txtDeptAddEmployeeID.Focus();
			}
		}

		private void m_tabQuanYuan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1TempPhone_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboPatientBedDept2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_cboPatientBedName2.ClearItem();
			m_cboPatientBedArea2.ClearItem();

			m_cboPatientBedArea2.SelectedIndex=-1;
			m_cboPatientBedName2.SelectedIndex=-1;
		}

		private void m_cboPatientBedArea2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_cboPatientBedName2.ClearItem();

			m_cboPatientBedName2.SelectedIndex=-1;
		}

		private void m_cboPatientBedName2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void m_txtTbp1InPatientID_TextChanged(object sender, System.EventArgs e)
		{
//			m_txtTbp1PatientID.Text = m_txtTbp1InPatientID.Text;
		}

		private void m_cboTbp1Nation_TextChanged(object sender, System.EventArgs e)
		{
//			string strText = m_cboTbp1Nation.Text;
//			int intIndex = 
		}

		private void m_gpbtbp1Must_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void label53_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1LinkManPhone_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1OfficePhone_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboTbp1Office_district_Load(object sender, System.EventArgs e)
		{
		
		}

		private void label46_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1Office_street_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label47_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label48_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1OfficeName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboTbp1Nationality_Load(object sender, System.EventArgs e)
		{
		
		}

		private void lblOfficePhoneTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblHomePCTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblOfficePCTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblIDCardTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label44_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblNationality_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label43_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1Hic_no_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lblPatientRelation_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1PatientID_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lblLinkManPhone_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblChargeCategory_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblLinkMan_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboTbp1ChargeCategory_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1OfficePC_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label45_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1HomePC_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboTbp1PaymentPercent_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1IDCard_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboTbp1LinkManRelation_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1LinkManPC_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1LinkMan_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboTbp1vip_code_Load(object sender, System.EventArgs e)
		{
		
		}

		private void label42_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboTbp1LinkMan_district_Load(object sender, System.EventArgs e)
		{
		
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label49_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label51_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1Home_street_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label52_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label50_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1Temp_street_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1LinkMan_street_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboTbp1Temp_district_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtTbp1temp_zipcode_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboDeptForLeave_DropDown(object sender, System.EventArgs e)
		{
			   
			m_lstLeavePatient.Items.Clear();
			m_cboAreaForLeave.ClearItem();
			m_cboAreaForLeave.SelectedIndex = -1;
	
		
			m_mthPatientLoadDept(m_cboDeptForLeave);
		}

		private void m_cboDeptForLeave_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_cboAreaForLeave.ClearItem();
			
			m_cboAreaForLeave.SelectedIndex=-1;
		}

		private void m_cboAreaForLeave_DropDown(object sender, System.EventArgs e)
		{
			m_lstLeavePatient.Items.Clear();
	
			
			m_mthPatientLoadAreaForLeave(m_cboAreaForLeave);
		
		}

		private void m_cboAreaForLeave_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_upDataLeavePatientListVeiw();
		}
		private void m_upDataLeavePatientListVeiw()
		{
			m_lstLeavePatient.Items.Clear();
			string strBedStatus ;
			long  lngBedStatus;
			clsPatient[] objPatientArr=null;
			clsInPatientBed[] objBedArr=null;
			if(m_cboDeptForLeave.Text =="" && m_cboAreaForLeave.Text =="")

			{
				return;
			}
			if(m_objManagerDomain.m_lngGetAllBedAndLeavePatientInArea(((clsAreaInfo_ManageExplorer)m_cboAreaForLeave.SelectedItem).m_strAreaID,out objBedArr, out objPatientArr)<=0 ) return;
			if(objPatientArr==null || objBedArr==null) return;
			for(int  i =0;i<	objPatientArr.Length ;i++)
			{
				ListViewItem lstPatient = null;
				lngBedStatus =m_objManagerDomain.m_lngGetBedStatus(  objPatientArr[i].m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID.Trim());
				if(lngBedStatus == 1)
				{
					strBedStatus = "病床已经被删除";
				
																																														  

				}
				else if(lngBedStatus == 2)
				{
					strBedStatus = "病床已经占用";
				}
				else
				{
					strBedStatus = "病床为空";
				}
				if(lngBedStatus == 1)
				{
					lstPatient = new ListViewItem(new string[]{ objPatientArr[i].m_StrName,objPatientArr[i].m_DtmLastOutDate.ToString(),strBedStatus,strBedStatus});  
					lstPatient.BackColor = System.Drawing.Color.Red;
				}
				else
				{
				  	lstPatient = new ListViewItem(new string[]{ objPatientArr[i].m_StrName,objPatientArr[i].m_DtmLastOutDate.ToString(),objPatientArr[i].m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName.ToString(),strBedStatus});  
			
				}
				lstPatient.Tag =   objPatientArr[i];
				m_lstLeavePatient.Items.Add(lstPatient);
			}
		}
		
		/// <summary>
		/// 记录病人信息
		/// </summary>
		private class clsInPatientInfo_ManageExplorer
		{
			public string m_strInPatientID;
			public string m_strInPatientName;	
			public override string ToString()
			{
				return m_strInPatientName;
			}
		}

		/// <summary>
		/// 记录员工信息
		/// </summary>
		private class clsEmployeeInfo_ManageExplorer
		{
			public string m_strEmployeeID;
			public string m_strEmployeeName;
			//		public string m_strEmployeeBeginDate;
			public clsEmployee_BaseInfo m_objEmployeeBaseInfo;
			public override string ToString()
			{
				return m_strEmployeeName;
			}
		}

		/// <summary>
		/// 记录病区信息
		/// </summary>
		private class clsAreaInfo_ManageExplorer
		{
			public string m_strAreaID;
			public string m_strAreaName;
			public override string ToString()

			{
				return m_strAreaName;
			}
		}

		/// <summary>
		/// 记录科室信息
		/// </summary>
		private class clsDeptInfo_ManageExplorer
		{
			public string m_strDeptID;
			public string m_strDeptName;
			public override string ToString()
			{
				return m_strDeptName;
			}
		}		

		/// <summary>
		/// 记录树节点信息
		/// </summary>
		private class clsNodeInfo
		{
			public string m_strCategoryName;
			public int m_intCategory;//0=全院,1=科室,2=病房,3=员工,4=病人
			public string m_strID;
			public string m_strName;
			//		public string m_strBeginDate;
			public clsDept_Desc m_objDeptDesc;
			public clsArea_Desc m_objAreaDesc;
			public clsNodeInfo m_objChildCategory=null;
		}

		/// <summary>
		/// 记录病床和在上面的病人的信息
		/// </summary>
		private class clsBedInfo
		{
			public string m_strBedID;
			public string m_strBedName;
			public string m_strBedInPatientID;
			//public string m_strBedInPatientDate;
			public string m_strBedInPatientName;
			public string m_strBedBeginDate;
			public string m_strBedEndDate;
			public clsPatientBaseInfo m_objPatientBaseInfo;
			public override string ToString()
			{
				return m_strBedName;
			}
		}
		private void m_mthPatientLoadAreaForLeave(Control p_ctlSender)
		{
			ctlComboBox cboTemp = p_ctlSender as ctlComboBox; //
			if(m_cboDeptForLeave.SelectedItem==null) return;
			clsInPatientArea[] objAreaArr=null;
			this.Cursor=Cursors.WaitCursor;
			if(m_objManagerDomain.m_lngGetAllAreaInDept(((clsDeptInfo_ManageExplorer)m_cboDeptForLeave.SelectedItem).m_strDeptID,
				out objAreaArr)<=0)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			if(objAreaArr==null)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			cboTemp.ClearItem();
			for(int i=0;i<objAreaArr.Length;i++)
			{
				clsAreaInfo_ManageExplorer objArea=new clsAreaInfo_ManageExplorer();
				objArea.m_strAreaID=objAreaArr[i].m_StrAreaID;
				objArea.m_strAreaName=objAreaArr[i].m_StrAreaName;
				cboTemp.AddItem(objArea);
			}
			this.Cursor=Cursors.Default;
		}

		private void m_cmdUndoLeave_Click(object sender, System.EventArgs e)
		{
		  m_unDoLeave();
		}
		/// <summary>
		/// 撤消出院
		/// </summary>
		private void m_unDoLeave()
		{
			if	 (m_lstLeavePatient.SelectedItems.Count  <= 0)
			{
				return;
			}
			clsPatient objPatient = null;
			objPatient =(clsPatient) m_lstLeavePatient.SelectedItems[0].Tag; 
			if(m_lstLeavePatient.SelectedItems[0].SubItems[3].Text.Trim() =="病床为空")
			{
				  m_objManagerDomain.m_lngUnDoLeave(objPatient.m_StrInPatientID,objPatient.m_DtmLastOutDate.ToString());

			}
			else
			{
				frmReLocate.objPatient =  objPatient;
			   frmReLocate frm = new frmReLocate();
					
						frm.ShowDialog();
			}
			 m_upDataLeavePatientListVeiw();

		}

		private void m_cmdReLocate_Click(object sender, System.EventArgs e)
		{
				m_unDoLeave();
		}

		private void m_lsvManageExplorerMid_Click(object sender, System.EventArgs e)
		{
			m_lblZCInf.Visible=false;
		}

		private bool m_blnCanChange = true;

		private void m_dtpTbp1Birth_evtTextChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanChange)  return;
			int intAge = DateTime.Now.Year - m_dtpTbp1Birth.Value.Year;
			m_blnCanChange = false;
			if(intAge > 0)
				m_txtAge.Text = intAge.ToString();
			else
				MDIParent.ShowInformationMessageBox("病人年龄填写错误！");
			m_blnCanChange = true;
		}

		private void m_txtAge_TextChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanChange)  return;
			int intAge = -1;
			try
			{
				intAge = int.Parse(m_txtAge.Text.Trim());
				if(intAge < 0)
					MDIParent.ShowInformationMessageBox("病人年龄填写错误！");
				m_blnCanChange = false;
				m_dtpTbp1Birth.Value = DateTime.Now.AddYears(-1*intAge);
				m_blnCanChange = true;
			}
			catch
			{m_dtpTbp1Birth.Value = DateTime.Now;}
		}
		#region Jump Control
		private void m_mthInitJump()
		{
			clsJumpControl p_objJump=new clsJumpControl(
				this,new Control[]{m_numTbp1Times,m_cboPatientBedDept2,m_cboPatientBedArea2,m_cboPatientBedName2
								 ,m_txtTbp1InPatientID,m_txtTbp1PatientFirstName,m_cboTbp1Sex,m_txtAge,m_cboTbp1Nation,
			m_cboTbp1Married,m_cboTbp1Occupation,m_txtTbp1HomePhone,m_txtTbp1LinkMan,m_cboTbp1NativePlace,m_cboTbp1Home_district,
			m_txtTbp1PatientID,m_cboTbp1vip_code,m_cboTbp1ChargeCategory,m_txtTbp1Hic_no,m_cboTbp1PaymentPercent,m_txtTbp1IDCard,
			m_cboTbp1Nationality,m_cboTbp1BornPlace,m_txtTbp1HomePC,m_txtTbp1Home_street,m_txtTbp1OfficeName,m_txtTbp1OfficePhone,m_txtTbp1OfficePC,
			m_txtTbp1Office_street,m_cboTbp1Office_district,m_txtTbp1LinkManPhone,m_cboTbp1LinkManRelation,m_txtTbp1LinkManPC,
			m_cboTbp1LinkMan_district,m_txtTbp1LinkMan_street,m_cboTbp1Temp_district,m_txtTbp1Temp_street,m_txtTbp1TempPhone,
			m_txtTbp1temp_zipcode,m_cboTbp1Insurance,m_cboTbp1Admiss_status,m_cboTbp1Visit_type},Keys.Enter);
		}
		#endregion
				
	}

	
}




