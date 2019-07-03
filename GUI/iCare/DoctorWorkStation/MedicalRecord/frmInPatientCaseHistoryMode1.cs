using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using System.Drawing.Printing ;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	public class frmInPatientCaseHistoryMode1 : iCare.frmBaseCaseHistory
	{
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRepresentor;
		private System.Windows.Forms.Label lblRepresentor;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCredibility;
		private System.Windows.Forms.Label lblCredibility;
		private System.Windows.Forms.ToolTip m_tip;
		protected System.Windows.Forms.Label lblPrimaryDiagnose;
		private System.Windows.Forms.PictureBox m_picDiagnose;
		protected System.Windows.Forms.Label lblSummary;
		private System.Windows.Forms.PictureBox m_picSummary;
		protected System.Windows.Forms.Label lblMedical;
		protected System.Windows.Forms.Label lblFamilyHistory;
		private System.Windows.Forms.PictureBox m_picFamilyHistory;
		protected System.Windows.Forms.Label lblCatameniaHistory;
		private System.Windows.Forms.PictureBox m_picCatameniaHistory;
		protected System.Windows.Forms.Label lblMarriageHistory;
		private System.Windows.Forms.PictureBox m_picMarriageHistory;
		protected System.Windows.Forms.Label lblOwnHistory;
		private System.Windows.Forms.PictureBox m_picOwnHistory;
		protected System.Windows.Forms.Label lblBeforetimeStatus;
		private System.Windows.Forms.PictureBox m_picBeforetimeStatus;
		protected System.Windows.Forms.Label lblMainDescription;
		private System.Windows.Forms.PictureBox m_picMainDescription;
		protected System.Windows.Forms.Label lblProfessionalCheck;
		private System.Windows.Forms.PictureBox m_picProfessionalCheck;
		private System.Windows.Forms.PictureBox m_picCurrentStatus;
		protected System.Windows.Forms.Label lblCurrentStatus;
		protected System.Windows.Forms.Label m_lblBloodPressureUnit;
		protected System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Label label2;
		protected com.digitalwave.controls.ctlRichTextBox m_txtMainDescription;
		protected com.digitalwave.controls.ctlRichTextBox m_txtCurrentStatus;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TabControl tabInPatientCase;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage 体格检查;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage6;
		protected System.Windows.Forms.Label label3;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBeforetimeStatus;
		private System.Windows.Forms.PictureBox pictureBox3;
		protected System.Windows.Forms.Label label5;
		protected System.Windows.Forms.Label label6;
		protected System.Windows.Forms.Label label7;
		protected com.digitalwave.controls.ctlRichTextBox m_txtCatameniaHistory;
		protected com.digitalwave.controls.ctlRichTextBox m_txtMarriageHistory;
		protected com.digitalwave.controls.ctlRichTextBox m_txtFamilyHistory;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.PictureBox pictureBox6;
		protected System.Windows.Forms.Label label4;
		protected com.digitalwave.controls.ctlRichTextBox m_txtOwnHistory;
		private System.Windows.Forms.PictureBox m_lblOwnHistory;
		private System.Windows.Forms.PictureBox m_picMedical;
		protected com.digitalwave.controls.ctlRichTextBox m_txtMedical;
		protected System.Windows.Forms.Label label8;
		protected System.Windows.Forms.Label lblTemperature;
		protected System.Windows.Forms.Label lblPulse;
		protected System.Windows.Forms.Label lblBreath;
		protected System.Windows.Forms.Label lblDia;
		protected System.Windows.Forms.Label lblSys;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBreath;
		protected com.digitalwave.controls.ctlRichTextBox m_txtSys;
		protected com.digitalwave.controls.ctlRichTextBox m_txtDia;
		protected com.digitalwave.controls.ctlRichTextBox m_txtTemperature;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPulse;
		protected com.digitalwave.controls.ctlRichTextBox m_txtProfessionalCheck;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.PictureBox m_picLabCheck;
		protected System.Windows.Forms.Label lblLabCheck;
		protected com.digitalwave.controls.ctlRichTextBox m_txtLabCheck;
		protected System.Windows.Forms.Label label10;
		protected com.digitalwave.controls.ctlRichTextBox m_txtSummary;
		private System.Windows.Forms.PictureBox pictureBox7;
		protected System.Windows.Forms.Label label11;
		protected System.Windows.Forms.Label lblFinallyDiagnose;
		private System.Windows.Forms.ListView m_lsvFinallyDiagnoseDocID;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpFinallyDiagnoseDate;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpPrimaryDiagnoseDate;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPrimaryDiagnoseDocID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFinallyDiagnoseDocID;
		protected System.Windows.Forms.Label lblPrimaryDiagnoseDate;
		private System.Windows.Forms.Label lblFinallyDiagnoseDate;
		protected com.digitalwave.controls.ctlRichTextBox m_txtFinallyDiagnose;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPrimaryDiagnose;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.PictureBox pictureBox10;
		private System.ComponentModel.IContainer components = null;
		protected System.Windows.Forms.ListView m_lsvEmployee;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSign;
		protected System.Windows.Forms.Label label12;
		private com.digitalwave.Utility.Controls.ctlPaintContainer ctlPaintContainer1;
		private System.Windows.Forms.Button m_cmdFinallyDiagnoseDocID;
		private System.Windows.Forms.Button m_cmdPrimaryDiagnoseDocID;

		private clsEmployeeSignTool m_objSignTool;
		protected System.Windows.Forms.Label label9;
		protected System.Windows.Forms.Label label13;
		private clsCommonUseToolCollection m_objCUTC;

		public frmInPatientCaseHistoryMode1()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
			m_objSignTool.m_mthAddControl(m_txtSign);
			
			m_blnCanDoctorTextChanged = true;

//			m_blnCanOperateDoctorSelect = true;
//			m_blnCanChargeDoctorSelect = true;
			
            //m_objBorderTool.m_mthChangedControlBorder(ctlPaintContainer1);

			this.m_tip.SetToolTip(this.m_picMainDescription ,"隐藏主诉"); 
			this.m_tip.SetToolTip(this.m_picCurrentStatus ,"隐藏现病史"); 
			this.m_tip.SetToolTip(this.m_picBeforetimeStatus ,"隐藏既往史");  
			this.m_tip.SetToolTip(this.m_picOwnHistory ,"隐藏个人史"); 
			this.m_tip.SetToolTip(this.m_picCatameniaHistory ,"隐藏月经史"); 
			this.m_tip.SetToolTip(this.m_picFamilyHistory ,"隐藏家族史"); 
			this.m_tip.SetToolTip(this.m_picLabCheck ,"隐藏实验室检查及特殊检查"); 
			this.m_tip.SetToolTip(this.m_picMarriageHistory ,"隐藏婚姻史");
			this.m_tip.SetToolTip(this.m_picMedical ,"隐藏体格检查");
			this.m_tip.SetToolTip(this.m_picProfessionalCheck ,"隐藏专科检查");
			this.m_tip.SetToolTip(this.m_picSummary ,"隐藏摘要");
			this.m_tip.SetToolTip(this.m_picDiagnose ,"隐藏诊断");
			m_mthSetRichTextBoxAttribInControl(this);
			m_mthUnEnableRichTextBox();
			
			m_txtPrimaryDiagnoseDocID.LostFocus += new EventHandler(m_mthDoctorListControl);
			m_txtFinallyDiagnoseDocID.LostFocus += new EventHandler(m_mthDoctorListControl);
			m_lsvFinallyDiagnoseDocID.LostFocus += new EventHandler(m_mthDoctorListControl);	
			
			
			//签名常用值
			m_objCUTC = new clsCommonUseToolCollection(this);
			m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdPrimaryDiagnoseDocID,m_cmdFinallyDiagnoseDocID,this.m_cmdCreateID },
				new Control[]{m_txtPrimaryDiagnoseDocID,m_txtFinallyDiagnoseDocID,this.m_txtSign },new int[]{1,1,1});

		}
//		private bool m_bolVisableMainDescription=true;
//		private bool m_bolVisableCurrentStatus=true;
//		private bool m_bolVisableBeforetimeStatus=true;
//		private bool m_bolVisableOwnHistory=true;
//		private bool m_bolVisableCatameniaHistory=true;
//		private bool m_bolVisableFamilyHistory=true;
//		private bool m_bolVisableLabCheck=true;
//		private bool m_bolVisableMarriageHistory=true;
//		private bool m_bolVisableMedical=true;
//		private bool m_bolVisableProfessionalCheck=true;
//		private bool m_bolVisableSummary=true;
//		private bool m_bolVisableDiagnose=true;


		private frmMedicalExam001 m_objMedicalExamForm=new frmMedicalExam001 ();		//刘颖源，结构化检查
		private clsMedicalExamDomain m_objMedicalExamDomain=new clsMedicalExamDomain ();
		private string m_strMedicalExam_ID="";
	
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_cboRepresentor = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblRepresentor = new System.Windows.Forms.Label();
			this.m_cboCredibility = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblCredibility = new System.Windows.Forms.Label();
			this.m_tip = new System.Windows.Forms.ToolTip(this.components);
			this.lblPrimaryDiagnose = new System.Windows.Forms.Label();
			this.m_picDiagnose = new System.Windows.Forms.PictureBox();
			this.lblSummary = new System.Windows.Forms.Label();
			this.m_picSummary = new System.Windows.Forms.PictureBox();
			this.lblMedical = new System.Windows.Forms.Label();
			this.lblFamilyHistory = new System.Windows.Forms.Label();
			this.m_picFamilyHistory = new System.Windows.Forms.PictureBox();
			this.lblCatameniaHistory = new System.Windows.Forms.Label();
			this.m_picCatameniaHistory = new System.Windows.Forms.PictureBox();
			this.lblMarriageHistory = new System.Windows.Forms.Label();
			this.m_picMarriageHistory = new System.Windows.Forms.PictureBox();
			this.lblOwnHistory = new System.Windows.Forms.Label();
			this.m_picOwnHistory = new System.Windows.Forms.PictureBox();
			this.lblBeforetimeStatus = new System.Windows.Forms.Label();
			this.m_picBeforetimeStatus = new System.Windows.Forms.PictureBox();
			this.lblMainDescription = new System.Windows.Forms.Label();
			this.m_picMainDescription = new System.Windows.Forms.PictureBox();
			this.lblProfessionalCheck = new System.Windows.Forms.Label();
			this.m_picProfessionalCheck = new System.Windows.Forms.PictureBox();
			this.m_picCurrentStatus = new System.Windows.Forms.PictureBox();
			this.lblCurrentStatus = new System.Windows.Forms.Label();
			this.m_lblBloodPressureUnit = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtMainDescription = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtCurrentStatus = new com.digitalwave.controls.ctlRichTextBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tabInPatientCase = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtBeforetimeStatus = new com.digitalwave.controls.ctlRichTextBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.体格检查 = new System.Windows.Forms.TabPage();
			this.label9 = new System.Windows.Forms.Label();
			this.m_picMedical = new System.Windows.Forms.PictureBox();
			this.m_txtMedical = new com.digitalwave.controls.ctlRichTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.lblTemperature = new System.Windows.Forms.Label();
			this.lblPulse = new System.Windows.Forms.Label();
			this.lblBreath = new System.Windows.Forms.Label();
			this.lblDia = new System.Windows.Forms.Label();
			this.lblSys = new System.Windows.Forms.Label();
			this.m_txtBreath = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtSys = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtDia = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtCatameniaHistory = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtMarriageHistory = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtFamilyHistory = new com.digitalwave.controls.ctlRichTextBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtOwnHistory = new com.digitalwave.controls.ctlRichTextBox();
			this.m_lblOwnHistory = new System.Windows.Forms.PictureBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.m_txtSummary = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtLabCheck = new com.digitalwave.controls.ctlRichTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.m_picLabCheck = new System.Windows.Forms.PictureBox();
			this.lblLabCheck = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.ctlPaintContainer1 = new com.digitalwave.Utility.Controls.ctlPaintContainer();
			this.m_txtProfessionalCheck = new com.digitalwave.controls.ctlRichTextBox();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.m_cmdFinallyDiagnoseDocID = new System.Windows.Forms.Button();
			this.m_cmdPrimaryDiagnoseDocID = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.lblFinallyDiagnose = new System.Windows.Forms.Label();
			this.m_lsvFinallyDiagnoseDocID = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.m_dtpFinallyDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_dtpPrimaryDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_txtPrimaryDiagnoseDocID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtFinallyDiagnoseDocID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblPrimaryDiagnoseDate = new System.Windows.Forms.Label();
			this.lblFinallyDiagnoseDate = new System.Windows.Forms.Label();
			this.m_txtFinallyDiagnose = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtPrimaryDiagnose = new com.digitalwave.controls.ctlRichTextBox();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.pictureBox10 = new System.Windows.Forms.PictureBox();
			this.m_lsvEmployee = new System.Windows.Forms.ListView();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.m_txtSign = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.tabInPatientCase.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.体格检查.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_cmdCreateID
			// 
			this.m_cmdCreateID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdCreateID.Location = new System.Drawing.Point(776, 132);
			this.m_cmdCreateID.Name = "m_cmdCreateID";
			this.m_cmdCreateID.Size = new System.Drawing.Size(100, 28);
			this.m_cmdCreateID.TabIndex = 80;
			// 
			// trvTime
			// 
			this.trvTime.Location = new System.Drawing.Point(28, 112);
			this.trvTime.Name = "trvTime";
			this.trvTime.Size = new System.Drawing.Size(228, 104);
			this.trvTime.TabIndex = 40;
			// 
			// m_dtpCreateDate
			// 
			this.m_dtpCreateDate.Location = new System.Drawing.Point(360, 104);
			this.m_dtpCreateDate.Name = "m_dtpCreateDate";
			this.m_dtpCreateDate.Size = new System.Drawing.Size(212, 22);
			this.m_dtpCreateDate.TabIndex = 50;
			// 
			// lblCreateDate
			// 
			this.lblCreateDate.Location = new System.Drawing.Point(276, 108);
			this.lblCreateDate.Name = "lblCreateDate";
			// 
			// lblNativePlace
			// 
			this.lblNativePlace.Location = new System.Drawing.Point(276, 168);
			this.lblNativePlace.Name = "lblNativePlace";
			this.lblNativePlace.Size = new System.Drawing.Size(70, 19);
			this.lblNativePlace.Text = "籍    贯:";
			// 
			// m_lblNativePlace
			// 
			this.m_lblNativePlace.Location = new System.Drawing.Point(360, 168);
			this.m_lblNativePlace.Name = "m_lblNativePlace";
			this.m_lblNativePlace.Size = new System.Drawing.Size(620, 20);
			// 
			// lblOccupation
			// 
			this.lblOccupation.Location = new System.Drawing.Point(444, 136);
			this.lblOccupation.Name = "lblOccupation";
			// 
			// m_lblOccupation
			// 
			this.m_lblOccupation.Location = new System.Drawing.Point(496, 136);
			this.m_lblOccupation.Name = "m_lblOccupation";
			this.m_lblOccupation.Size = new System.Drawing.Size(96, 20);
			// 
			// m_lblMarriaged
			// 
			this.m_lblMarriaged.Location = new System.Drawing.Point(664, 136);
			this.m_lblMarriaged.Name = "m_lblMarriaged";
			// 
			// lblMarriaged
			// 
			this.lblMarriaged.Location = new System.Drawing.Point(600, 136);
			this.lblMarriaged.Name = "lblMarriaged";
			this.lblMarriaged.Size = new System.Drawing.Size(56, 19);
			this.lblMarriaged.Text = "婚  否:";
			// 
			// m_lblCreateUserName
			// 
			this.m_lblCreateUserName.Location = new System.Drawing.Point(880, 20);
			this.m_lblCreateUserName.Name = "m_lblCreateUserName";
			this.m_lblCreateUserName.Size = new System.Drawing.Size(100, 20);
			// 
			// m_lblLinkMan
			// 
			this.m_lblLinkMan.Location = new System.Drawing.Point(360, 136);
			this.m_lblLinkMan.Name = "m_lblLinkMan";
			this.m_lblLinkMan.Size = new System.Drawing.Size(80, 20);
			// 
			// lblLinkMan
			// 
			this.lblLinkMan.Location = new System.Drawing.Point(276, 136);
			this.lblLinkMan.Name = "lblLinkMan";
			this.lblLinkMan.Size = new System.Drawing.Size(70, 19);
			this.lblLinkMan.Text = "联 系 人:";
			// 
			// lblAddress
			// 
			this.lblAddress.Location = new System.Drawing.Point(276, 196);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(70, 19);
			this.lblAddress.Text = "地    址:";
			// 
			// m_lblAddress
			// 
			this.m_lblAddress.Location = new System.Drawing.Point(360, 196);
			this.m_lblAddress.Name = "m_lblAddress";
			this.m_lblAddress.Size = new System.Drawing.Size(620, 20);
			// 
			// lblSex
			// 
			this.lblSex.Location = new System.Drawing.Point(664, 80);
			this.lblSex.Name = "lblSex";
			this.lblSex.Size = new System.Drawing.Size(36, 19);
			// 
			// lblAge
			// 
			this.lblAge.Location = new System.Drawing.Point(768, 80);
			this.lblAge.Name = "lblAge";
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Location = new System.Drawing.Point(276, 80);
			this.lblBedNoTitle.Name = "lblBedNoTitle";
			this.lblBedNoTitle.Size = new System.Drawing.Size(70, 19);
			this.lblBedNoTitle.Text = "床    号:";
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Name = "lblInHospitalNoTitle";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Location = new System.Drawing.Point(444, 80);
			this.lblNameTitle.Name = "lblNameTitle";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Location = new System.Drawing.Point(600, 80);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(56, 19);
			this.lblSexTitle.Text = "性  别:";
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Location = new System.Drawing.Point(720, 80);
			this.lblAgeTitle.Name = "lblAgeTitle";
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Location = new System.Drawing.Point(28, 80);
			this.lblAreaTitle.Name = "lblAreaTitle";
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Location = new System.Drawing.Point(880, 104);
			this.m_lsvInPatientID.Name = "m_lsvInPatientID";
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Name = "txtInPatientID";
			this.txtInPatientID.TabIndex = 30;
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Location = new System.Drawing.Point(496, 78);
			this.m_txtPatientName.Name = "m_txtPatientName";
			this.m_txtPatientName.Size = new System.Drawing.Size(92, 21);
			this.m_txtPatientName.TabIndex = 20;
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Location = new System.Drawing.Point(360, 78);
			this.m_txtBedNO.Name = "m_txtBedNO";
			this.m_txtBedNO.TabIndex = 10;
			// 
			// m_cboArea
			// 
			this.m_cboArea.Location = new System.Drawing.Point(76, 76);
			this.m_cboArea.Name = "m_cboArea";
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Location = new System.Drawing.Point(496, 104);
			this.m_lsvPatientName.Name = "m_lsvPatientName";
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Location = new System.Drawing.Point(324, 104);
			this.m_lsvBedNO.Name = "m_lsvBedNO";
			// 
			// m_cboDept
			// 
			this.m_cboDept.Location = new System.Drawing.Point(76, 40);
			this.m_cboDept.Name = "m_cboDept";
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(28, 48);
			this.lblDept.Name = "lblDept";
			// 
			// m_cmdNewTemplate
			// 
			this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdNewTemplate.Name = "m_cmdNewTemplate";
			// 
			// m_cmdNext
			// 
			this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdNext.Name = "m_cmdNext";
			// 
			// m_cmdPre
			// 
			this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdPre.Name = "m_cmdPre";
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Name = "m_lblForTitle";
			this.m_lblForTitle.Text = "住  院  病  历";
			// 
			// m_cboRepresentor
			// 
			this.m_cboRepresentor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboRepresentor.BorderColor = System.Drawing.Color.White;
			this.m_cboRepresentor.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboRepresentor.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboRepresentor.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboRepresentor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRepresentor.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboRepresentor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboRepresentor.ForeColor = System.Drawing.Color.White;
			this.m_cboRepresentor.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboRepresentor.ListForeColor = System.Drawing.Color.White;
			this.m_cboRepresentor.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboRepresentor.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboRepresentor.Location = new System.Drawing.Point(664, 104);
			this.m_cboRepresentor.m_BlnEnableItemEventMenu = true;
			this.m_cboRepresentor.Name = "m_cboRepresentor";
			this.m_cboRepresentor.SelectedIndex = -1;
			this.m_cboRepresentor.SelectedItem = null;
			this.m_cboRepresentor.SelectionStart = -1;
			this.m_cboRepresentor.Size = new System.Drawing.Size(104, 26);
			this.m_cboRepresentor.TabIndex = 60;
			this.m_cboRepresentor.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboRepresentor.TextForeColor = System.Drawing.Color.White;
			this.m_cboRepresentor.DropDown += new System.EventHandler(this.m_cboRepresentor_DropDown);
			// 
			// lblRepresentor
			// 
			this.lblRepresentor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRepresentor.Location = new System.Drawing.Point(600, 108);
			this.lblRepresentor.Name = "lblRepresentor";
			this.lblRepresentor.Size = new System.Drawing.Size(72, 20);
			this.lblRepresentor.TabIndex = 517;
			this.lblRepresentor.Text = "陈述者:";
			// 
			// m_cboCredibility
			// 
			this.m_cboCredibility.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboCredibility.BorderColor = System.Drawing.Color.White;
			this.m_cboCredibility.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboCredibility.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboCredibility.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboCredibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCredibility.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCredibility.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCredibility.ForeColor = System.Drawing.Color.White;
			this.m_cboCredibility.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboCredibility.ListForeColor = System.Drawing.Color.White;
			this.m_cboCredibility.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboCredibility.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboCredibility.Location = new System.Drawing.Point(880, 104);
			this.m_cboCredibility.m_BlnEnableItemEventMenu = true;
			this.m_cboCredibility.Name = "m_cboCredibility";
			this.m_cboCredibility.SelectedIndex = -1;
			this.m_cboCredibility.SelectedItem = null;
			this.m_cboCredibility.SelectionStart = -1;
			this.m_cboCredibility.Size = new System.Drawing.Size(100, 26);
			this.m_cboCredibility.TabIndex = 70;
			this.m_cboCredibility.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboCredibility.TextForeColor = System.Drawing.Color.White;
			this.m_cboCredibility.DropDown += new System.EventHandler(this.m_cboCredibility_DropDown);
			// 
			// lblCredibility
			// 
			this.lblCredibility.AutoSize = true;
			this.lblCredibility.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCredibility.Location = new System.Drawing.Point(812, 108);
			this.lblCredibility.Name = "lblCredibility";
			this.lblCredibility.Size = new System.Drawing.Size(63, 22);
			this.lblCredibility.TabIndex = 514;
			this.lblCredibility.Text = "可靠度:";
			// 
			// lblPrimaryDiagnose
			// 
			this.lblPrimaryDiagnose.Location = new System.Drawing.Point(16, 2312);
			this.lblPrimaryDiagnose.Name = "lblPrimaryDiagnose";
			this.lblPrimaryDiagnose.Size = new System.Drawing.Size(80, 19);
			this.lblPrimaryDiagnose.TabIndex = 0;
			// 
			// m_picDiagnose
			// 
			this.m_picDiagnose.Location = new System.Drawing.Point(96, 2316);
			this.m_picDiagnose.Name = "m_picDiagnose";
			this.m_picDiagnose.Size = new System.Drawing.Size(16, 16);
			this.m_picDiagnose.TabIndex = 0;
			this.m_picDiagnose.TabStop = false;
			// 
			// lblSummary
			// 
			this.lblSummary.Location = new System.Drawing.Point(28, 2120);
			this.lblSummary.Name = "lblSummary";
			this.lblSummary.Size = new System.Drawing.Size(55, 19);
			this.lblSummary.TabIndex = 0;
			// 
			// m_picSummary
			// 
			this.m_picSummary.Location = new System.Drawing.Point(92, 2120);
			this.m_picSummary.Name = "m_picSummary";
			this.m_picSummary.Size = new System.Drawing.Size(16, 16);
			this.m_picSummary.TabIndex = 0;
			this.m_picSummary.TabStop = false;
			// 
			// lblMedical
			// 
			this.lblMedical.Location = new System.Drawing.Point(16, 1148);
			this.lblMedical.Name = "lblMedical";
			this.lblMedical.Size = new System.Drawing.Size(80, 19);
			this.lblMedical.TabIndex = 0;
			// 
			// lblFamilyHistory
			// 
			this.lblFamilyHistory.Location = new System.Drawing.Point(16, 880);
			this.lblFamilyHistory.Name = "lblFamilyHistory";
			this.lblFamilyHistory.Size = new System.Drawing.Size(63, 19);
			this.lblFamilyHistory.TabIndex = 0;
			// 
			// m_picFamilyHistory
			// 
			this.m_picFamilyHistory.Location = new System.Drawing.Point(80, 880);
			this.m_picFamilyHistory.Name = "m_picFamilyHistory";
			this.m_picFamilyHistory.Size = new System.Drawing.Size(16, 16);
			this.m_picFamilyHistory.TabIndex = 0;
			this.m_picFamilyHistory.TabStop = false;
			// 
			// lblCatameniaHistory
			// 
			this.lblCatameniaHistory.Location = new System.Drawing.Point(12, 824);
			this.lblCatameniaHistory.Name = "lblCatameniaHistory";
			this.lblCatameniaHistory.Size = new System.Drawing.Size(63, 19);
			this.lblCatameniaHistory.TabIndex = 0;
			// 
			// m_picCatameniaHistory
			// 
			this.m_picCatameniaHistory.Location = new System.Drawing.Point(76, 824);
			this.m_picCatameniaHistory.Name = "m_picCatameniaHistory";
			this.m_picCatameniaHistory.Size = new System.Drawing.Size(16, 16);
			this.m_picCatameniaHistory.TabIndex = 0;
			this.m_picCatameniaHistory.TabStop = false;
			// 
			// lblMarriageHistory
			// 
			this.lblMarriageHistory.Location = new System.Drawing.Point(16, 768);
			this.lblMarriageHistory.Name = "lblMarriageHistory";
			this.lblMarriageHistory.Size = new System.Drawing.Size(63, 19);
			this.lblMarriageHistory.TabIndex = 0;
			// 
			// m_picMarriageHistory
			// 
			this.m_picMarriageHistory.Location = new System.Drawing.Point(80, 768);
			this.m_picMarriageHistory.Name = "m_picMarriageHistory";
			this.m_picMarriageHistory.Size = new System.Drawing.Size(16, 16);
			this.m_picMarriageHistory.TabIndex = 0;
			this.m_picMarriageHistory.TabStop = false;
			// 
			// lblOwnHistory
			// 
			this.lblOwnHistory.Location = new System.Drawing.Point(16, 668);
			this.lblOwnHistory.Name = "lblOwnHistory";
			this.lblOwnHistory.Size = new System.Drawing.Size(63, 19);
			this.lblOwnHistory.TabIndex = 0;
			// 
			// m_picOwnHistory
			// 
			this.m_picOwnHistory.Location = new System.Drawing.Point(80, 668);
			this.m_picOwnHistory.Name = "m_picOwnHistory";
			this.m_picOwnHistory.Size = new System.Drawing.Size(16, 16);
			this.m_picOwnHistory.TabIndex = 0;
			this.m_picOwnHistory.TabStop = false;
			// 
			// lblBeforetimeStatus
			// 
			this.lblBeforetimeStatus.Location = new System.Drawing.Point(16, 524);
			this.lblBeforetimeStatus.Name = "lblBeforetimeStatus";
			this.lblBeforetimeStatus.Size = new System.Drawing.Size(63, 19);
			this.lblBeforetimeStatus.TabIndex = 0;
			// 
			// m_picBeforetimeStatus
			// 
			this.m_picBeforetimeStatus.Location = new System.Drawing.Point(80, 714);
			this.m_picBeforetimeStatus.Name = "m_picBeforetimeStatus";
			this.m_picBeforetimeStatus.Size = new System.Drawing.Size(16, 16);
			this.m_picBeforetimeStatus.TabIndex = 0;
			this.m_picBeforetimeStatus.TabStop = false;
			// 
			// lblMainDescription
			// 
			this.lblMainDescription.Location = new System.Drawing.Point(0, 0);
			this.lblMainDescription.Name = "lblMainDescription";
			this.lblMainDescription.TabIndex = 0;
			// 
			// m_picMainDescription
			// 
			this.m_picMainDescription.Location = new System.Drawing.Point(72, 260);
			this.m_picMainDescription.Name = "m_picMainDescription";
			this.m_picMainDescription.TabIndex = 0;
			this.m_picMainDescription.TabStop = false;
			// 
			// lblProfessionalCheck
			// 
			this.lblProfessionalCheck.Location = new System.Drawing.Point(16, 1548);
			this.lblProfessionalCheck.Name = "lblProfessionalCheck";
			this.lblProfessionalCheck.Size = new System.Drawing.Size(80, 19);
			this.lblProfessionalCheck.TabIndex = 0;
			// 
			// m_picProfessionalCheck
			// 
			this.m_picProfessionalCheck.Location = new System.Drawing.Point(96, 1552);
			this.m_picProfessionalCheck.Name = "m_picProfessionalCheck";
			this.m_picProfessionalCheck.Size = new System.Drawing.Size(16, 16);
			this.m_picProfessionalCheck.TabIndex = 0;
			this.m_picProfessionalCheck.TabStop = false;
			// 
			// m_picCurrentStatus
			// 
			this.m_picCurrentStatus.Location = new System.Drawing.Point(80, 372);
			this.m_picCurrentStatus.Name = "m_picCurrentStatus";
			this.m_picCurrentStatus.Size = new System.Drawing.Size(16, 16);
			this.m_picCurrentStatus.TabIndex = 0;
			this.m_picCurrentStatus.TabStop = false;
			// 
			// lblCurrentStatus
			// 
			this.lblCurrentStatus.Location = new System.Drawing.Point(16, 372);
			this.lblCurrentStatus.Name = "lblCurrentStatus";
			this.lblCurrentStatus.Size = new System.Drawing.Size(63, 19);
			this.lblCurrentStatus.TabIndex = 0;
			// 
			// m_lblBloodPressureUnit
			// 
			this.m_lblBloodPressureUnit.Location = new System.Drawing.Point(928, 680);
			this.m_lblBloodPressureUnit.Name = "m_lblBloodPressureUnit";
			this.m_lblBloodPressureUnit.Size = new System.Drawing.Size(39, 19);
			this.m_lblBloodPressureUnit.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 22);
			this.label1.TabIndex = 549;
			this.label1.Tag = "1";
			this.label1.Text = "主  诉:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(20, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 22);
			this.label2.TabIndex = 550;
			this.label2.Tag = "2";
			this.label2.Text = "现病史:";
			// 
			// m_txtMainDescription
			// 
			this.m_txtMainDescription.AccessibleDescription = "主诉";
			this.m_txtMainDescription.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtMainDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtMainDescription.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMainDescription.ForeColor = System.Drawing.Color.White;
			this.m_txtMainDescription.Location = new System.Drawing.Point(16, 48);
			this.m_txtMainDescription.m_BlnIgnoreUserInfo = false;
			this.m_txtMainDescription.m_BlnPartControl = false;
			this.m_txtMainDescription.m_BlnReadOnly = false;
			this.m_txtMainDescription.m_BlnUnderLineDST = false;
			this.m_txtMainDescription.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtMainDescription.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtMainDescription.m_IntCanModifyTime = 6;
			this.m_txtMainDescription.m_IntPartControlLength = 0;
			this.m_txtMainDescription.m_IntPartControlStartIndex = 0;
			this.m_txtMainDescription.m_StrUserID = "";
			this.m_txtMainDescription.m_StrUserName = "";
			this.m_txtMainDescription.Name = "m_txtMainDescription";
			this.m_txtMainDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtMainDescription.Size = new System.Drawing.Size(912, 52);
			this.m_txtMainDescription.TabIndex = 110;
			this.m_txtMainDescription.Tag = "1";
			this.m_txtMainDescription.Text = "";
			// 
			// m_txtCurrentStatus
			// 
			this.m_txtCurrentStatus.AccessibleDescription = "现病史";
			this.m_txtCurrentStatus.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtCurrentStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtCurrentStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtCurrentStatus.ForeColor = System.Drawing.Color.White;
			this.m_txtCurrentStatus.Location = new System.Drawing.Point(16, 148);
			this.m_txtCurrentStatus.m_BlnIgnoreUserInfo = false;
			this.m_txtCurrentStatus.m_BlnPartControl = false;
			this.m_txtCurrentStatus.m_BlnReadOnly = false;
			this.m_txtCurrentStatus.m_BlnUnderLineDST = false;
			this.m_txtCurrentStatus.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtCurrentStatus.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtCurrentStatus.m_IntCanModifyTime = 6;
			this.m_txtCurrentStatus.m_IntPartControlLength = 0;
			this.m_txtCurrentStatus.m_IntPartControlStartIndex = 0;
			this.m_txtCurrentStatus.m_StrUserID = "";
			this.m_txtCurrentStatus.m_StrUserName = "";
			this.m_txtCurrentStatus.Name = "m_txtCurrentStatus";
			this.m_txtCurrentStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtCurrentStatus.Size = new System.Drawing.Size(912, 176);
			this.m_txtCurrentStatus.TabIndex = 120;
			this.m_txtCurrentStatus.Tag = "2";
			this.m_txtCurrentStatus.Text = "";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(16, 72);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(16, 16);
			this.pictureBox2.TabIndex = 558;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Tag = "2";
			this.pictureBox2.Visible = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.pictureBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.pictureBox1.ForeColor = System.Drawing.Color.White;
			this.pictureBox1.Location = new System.Drawing.Point(16, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.TabIndex = 557;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Tag = "1";
			this.pictureBox1.Visible = false;
			// 
			// tabInPatientCase
			// 
			this.tabInPatientCase.Controls.Add(this.tabPage1);
			this.tabInPatientCase.Controls.Add(this.体格检查);
			this.tabInPatientCase.Controls.Add(this.tabPage2);
			this.tabInPatientCase.Controls.Add(this.tabPage5);
			this.tabInPatientCase.Controls.Add(this.tabPage4);
			this.tabInPatientCase.Controls.Add(this.tabPage6);
			this.tabInPatientCase.Location = new System.Drawing.Point(27, 232);
			this.tabInPatientCase.Name = "tabInPatientCase";
			this.tabInPatientCase.SelectedIndex = 0;
			this.tabInPatientCase.Size = new System.Drawing.Size(952, 544);
			this.tabInPatientCase.TabIndex = 160;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.m_txtBeforetimeStatus);
			this.tabPage1.Controls.Add(this.pictureBox3);
			this.tabPage1.Controls.Add(this.pictureBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.m_txtMainDescription);
			this.tabPage1.Controls.Add(this.pictureBox2);
			this.tabPage1.Controls.Add(this.m_txtCurrentStatus);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(944, 515);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "第一页";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(16, 336);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 22);
			this.label3.TabIndex = 560;
			this.label3.Tag = "3";
			this.label3.Text = "既往史:";
			// 
			// m_txtBeforetimeStatus
			// 
			this.m_txtBeforetimeStatus.AccessibleDescription = "既往史";
			this.m_txtBeforetimeStatus.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtBeforetimeStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtBeforetimeStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtBeforetimeStatus.ForeColor = System.Drawing.Color.White;
			this.m_txtBeforetimeStatus.Location = new System.Drawing.Point(16, 364);
			this.m_txtBeforetimeStatus.m_BlnIgnoreUserInfo = false;
			this.m_txtBeforetimeStatus.m_BlnPartControl = false;
			this.m_txtBeforetimeStatus.m_BlnReadOnly = false;
			this.m_txtBeforetimeStatus.m_BlnUnderLineDST = false;
			this.m_txtBeforetimeStatus.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtBeforetimeStatus.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtBeforetimeStatus.m_IntCanModifyTime = 6;
			this.m_txtBeforetimeStatus.m_IntPartControlLength = 0;
			this.m_txtBeforetimeStatus.m_IntPartControlStartIndex = 0;
			this.m_txtBeforetimeStatus.m_StrUserID = "";
			this.m_txtBeforetimeStatus.m_StrUserName = "";
			this.m_txtBeforetimeStatus.Name = "m_txtBeforetimeStatus";
			this.m_txtBeforetimeStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtBeforetimeStatus.Size = new System.Drawing.Size(912, 136);
			this.m_txtBeforetimeStatus.TabIndex = 130;
			this.m_txtBeforetimeStatus.Tag = "3";
			this.m_txtBeforetimeStatus.Text = "";
			// 
			// pictureBox3
			// 
			this.pictureBox3.Location = new System.Drawing.Point(24, 352);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(16, 8);
			this.pictureBox3.TabIndex = 561;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Tag = "3";
			this.pictureBox3.Visible = false;
			// 
			// 体格检查
			// 
			this.体格检查.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.体格检查.Controls.Add(this.label9);
			this.体格检查.Controls.Add(this.m_picMedical);
			this.体格检查.Controls.Add(this.m_txtMedical);
			this.体格检查.Controls.Add(this.label8);
			this.体格检查.Controls.Add(this.lblTemperature);
			this.体格检查.Controls.Add(this.lblPulse);
			this.体格检查.Controls.Add(this.lblBreath);
			this.体格检查.Controls.Add(this.lblDia);
			this.体格检查.Controls.Add(this.lblSys);
			this.体格检查.Controls.Add(this.m_txtBreath);
			this.体格检查.Controls.Add(this.m_txtSys);
			this.体格检查.Controls.Add(this.m_txtDia);
			this.体格检查.Controls.Add(this.m_txtTemperature);
			this.体格检查.Controls.Add(this.m_txtPulse);
			this.体格检查.Location = new System.Drawing.Point(4, 25);
			this.体格检查.Name = "体格检查";
			this.体格检查.Size = new System.Drawing.Size(944, 515);
			this.体格检查.TabIndex = 2;
			this.体格检查.Text = "体格检查";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(16, 20);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 22);
			this.label9.TabIndex = 618;
			this.label9.Tag = "8";
			this.label9.Text = "体格检查:";
			// 
			// m_picMedical
			// 
			this.m_picMedical.Location = new System.Drawing.Point(236, 20);
			this.m_picMedical.Name = "m_picMedical";
			this.m_picMedical.Size = new System.Drawing.Size(16, 16);
			this.m_picMedical.TabIndex = 616;
			this.m_picMedical.TabStop = false;
			this.m_picMedical.Tag = "8";
			this.m_picMedical.Visible = false;
			// 
			// m_txtMedical
			// 
			this.m_txtMedical.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtMedical.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtMedical.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMedical.ForeColor = System.Drawing.Color.White;
			this.m_txtMedical.Location = new System.Drawing.Point(16, 48);
			this.m_txtMedical.m_BlnIgnoreUserInfo = false;
			this.m_txtMedical.m_BlnPartControl = false;
			this.m_txtMedical.m_BlnReadOnly = false;
			this.m_txtMedical.m_BlnUnderLineDST = false;
			this.m_txtMedical.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtMedical.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtMedical.m_IntCanModifyTime = 6;
			this.m_txtMedical.m_IntPartControlLength = 0;
			this.m_txtMedical.m_IntPartControlStartIndex = 0;
			this.m_txtMedical.m_StrUserID = "";
			this.m_txtMedical.m_StrUserName = "";
			this.m_txtMedical.Name = "m_txtMedical";
			this.m_txtMedical.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtMedical.Size = new System.Drawing.Size(912, 328);
			this.m_txtMedical.TabIndex = 270;
			this.m_txtMedical.Tag = "8";
			this.m_txtMedical.Text = "";
			this.m_txtMedical.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtMedical_MouseDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(812, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 22);
			this.label8.TabIndex = 614;
			this.label8.Tag = "8";
			this.label8.Text = "mmHg";
			// 
			// lblTemperature
			// 
			this.lblTemperature.AutoSize = true;
			this.lblTemperature.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTemperature.Location = new System.Drawing.Point(112, 20);
			this.lblTemperature.Name = "lblTemperature";
			this.lblTemperature.Size = new System.Drawing.Size(47, 22);
			this.lblTemperature.TabIndex = 613;
			this.lblTemperature.Tag = "8";
			this.lblTemperature.Text = "体温:";
			// 
			// lblPulse
			// 
			this.lblPulse.AutoSize = true;
			this.lblPulse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPulse.Location = new System.Drawing.Point(284, 20);
			this.lblPulse.Name = "lblPulse";
			this.lblPulse.Size = new System.Drawing.Size(47, 22);
			this.lblPulse.TabIndex = 610;
			this.lblPulse.Tag = "8";
			this.lblPulse.Text = "脉搏:";
			// 
			// lblBreath
			// 
			this.lblBreath.AutoSize = true;
			this.lblBreath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblBreath.Location = new System.Drawing.Point(456, 20);
			this.lblBreath.Name = "lblBreath";
			this.lblBreath.Size = new System.Drawing.Size(47, 22);
			this.lblBreath.TabIndex = 609;
			this.lblBreath.Tag = "8";
			this.lblBreath.Text = "呼吸:";
			// 
			// lblDia
			// 
			this.lblDia.AutoSize = true;
			this.lblDia.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDia.Location = new System.Drawing.Point(628, 20);
			this.lblDia.Name = "lblDia";
			this.lblDia.Size = new System.Drawing.Size(47, 22);
			this.lblDia.TabIndex = 612;
			this.lblDia.Tag = "8";
			this.lblDia.Text = "血压:";
			// 
			// lblSys
			// 
			this.lblSys.AutoSize = true;
			this.lblSys.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSys.Location = new System.Drawing.Point(732, 20);
			this.lblSys.Name = "lblSys";
			this.lblSys.Size = new System.Drawing.Size(17, 25);
			this.lblSys.TabIndex = 611;
			this.lblSys.Tag = "8";
			this.lblSys.Text = "/";
			// 
			// m_txtBreath
			// 
			this.m_txtBreath.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtBreath.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtBreath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtBreath.ForeColor = System.Drawing.Color.White;
			this.m_txtBreath.Location = new System.Drawing.Point(504, 20);
			this.m_txtBreath.m_BlnIgnoreUserInfo = false;
			this.m_txtBreath.m_BlnPartControl = false;
			this.m_txtBreath.m_BlnReadOnly = false;
			this.m_txtBreath.m_BlnUnderLineDST = false;
			this.m_txtBreath.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtBreath.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtBreath.m_IntCanModifyTime = 6;
			this.m_txtBreath.m_IntPartControlLength = 0;
			this.m_txtBreath.m_IntPartControlStartIndex = 0;
			this.m_txtBreath.m_StrUserID = "";
			this.m_txtBreath.m_StrUserName = "";
			this.m_txtBreath.Multiline = false;
			this.m_txtBreath.Name = "m_txtBreath";
			this.m_txtBreath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtBreath.Size = new System.Drawing.Size(52, 21);
			this.m_txtBreath.TabIndex = 240;
			this.m_txtBreath.Tag = "8";
			this.m_txtBreath.Text = "";
			// 
			// m_txtSys
			// 
			this.m_txtSys.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtSys.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtSys.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtSys.ForeColor = System.Drawing.Color.White;
			this.m_txtSys.Location = new System.Drawing.Point(676, 20);
			this.m_txtSys.m_BlnIgnoreUserInfo = false;
			this.m_txtSys.m_BlnPartControl = false;
			this.m_txtSys.m_BlnReadOnly = false;
			this.m_txtSys.m_BlnUnderLineDST = false;
			this.m_txtSys.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtSys.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtSys.m_IntCanModifyTime = 6;
			this.m_txtSys.m_IntPartControlLength = 0;
			this.m_txtSys.m_IntPartControlStartIndex = 0;
			this.m_txtSys.m_StrUserID = "";
			this.m_txtSys.m_StrUserName = "";
			this.m_txtSys.Multiline = false;
			this.m_txtSys.Name = "m_txtSys";
			this.m_txtSys.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtSys.Size = new System.Drawing.Size(52, 21);
			this.m_txtSys.TabIndex = 250;
			this.m_txtSys.Tag = "8";
			this.m_txtSys.Text = "";
			// 
			// m_txtDia
			// 
			this.m_txtDia.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtDia.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtDia.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDia.ForeColor = System.Drawing.Color.White;
			this.m_txtDia.Location = new System.Drawing.Point(756, 20);
			this.m_txtDia.m_BlnIgnoreUserInfo = false;
			this.m_txtDia.m_BlnPartControl = false;
			this.m_txtDia.m_BlnReadOnly = false;
			this.m_txtDia.m_BlnUnderLineDST = false;
			this.m_txtDia.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtDia.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtDia.m_IntCanModifyTime = 6;
			this.m_txtDia.m_IntPartControlLength = 0;
			this.m_txtDia.m_IntPartControlStartIndex = 0;
			this.m_txtDia.m_StrUserID = "";
			this.m_txtDia.m_StrUserName = "";
			this.m_txtDia.Multiline = false;
			this.m_txtDia.Name = "m_txtDia";
			this.m_txtDia.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtDia.Size = new System.Drawing.Size(52, 21);
			this.m_txtDia.TabIndex = 260;
			this.m_txtDia.Tag = "8";
			this.m_txtDia.Text = "";
			// 
			// m_txtTemperature
			// 
			this.m_txtTemperature.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTemperature.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemperature.ForeColor = System.Drawing.Color.White;
			this.m_txtTemperature.Location = new System.Drawing.Point(160, 20);
			this.m_txtTemperature.m_BlnIgnoreUserInfo = false;
			this.m_txtTemperature.m_BlnPartControl = false;
			this.m_txtTemperature.m_BlnReadOnly = false;
			this.m_txtTemperature.m_BlnUnderLineDST = false;
			this.m_txtTemperature.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtTemperature.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtTemperature.m_IntCanModifyTime = 6;
			this.m_txtTemperature.m_IntPartControlLength = 0;
			this.m_txtTemperature.m_IntPartControlStartIndex = 0;
			this.m_txtTemperature.m_StrUserID = "";
			this.m_txtTemperature.m_StrUserName = "";
			this.m_txtTemperature.Multiline = false;
			this.m_txtTemperature.Name = "m_txtTemperature";
			this.m_txtTemperature.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtTemperature.Size = new System.Drawing.Size(52, 21);
			this.m_txtTemperature.TabIndex = 220;
			this.m_txtTemperature.Tag = "8";
			this.m_txtTemperature.Text = "";
			// 
			// m_txtPulse
			// 
			this.m_txtPulse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPulse.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtPulse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPulse.ForeColor = System.Drawing.Color.White;
			this.m_txtPulse.Location = new System.Drawing.Point(332, 20);
			this.m_txtPulse.m_BlnIgnoreUserInfo = false;
			this.m_txtPulse.m_BlnPartControl = false;
			this.m_txtPulse.m_BlnReadOnly = false;
			this.m_txtPulse.m_BlnUnderLineDST = false;
			this.m_txtPulse.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtPulse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtPulse.m_IntCanModifyTime = 6;
			this.m_txtPulse.m_IntPartControlLength = 0;
			this.m_txtPulse.m_IntPartControlStartIndex = 0;
			this.m_txtPulse.m_StrUserID = "";
			this.m_txtPulse.m_StrUserName = "";
			this.m_txtPulse.Multiline = false;
			this.m_txtPulse.Name = "m_txtPulse";
			this.m_txtPulse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtPulse.Size = new System.Drawing.Size(52, 21);
			this.m_txtPulse.TabIndex = 230;
			this.m_txtPulse.Tag = "8";
			this.m_txtPulse.Text = "";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.m_txtCatameniaHistory);
			this.tabPage2.Controls.Add(this.m_txtMarriageHistory);
			this.tabPage2.Controls.Add(this.m_txtFamilyHistory);
			this.tabPage2.Controls.Add(this.pictureBox4);
			this.tabPage2.Controls.Add(this.pictureBox5);
			this.tabPage2.Controls.Add(this.pictureBox6);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.m_txtOwnHistory);
			this.tabPage2.Controls.Add(this.m_lblOwnHistory);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(944, 515);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "第二页";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(16, 280);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 22);
			this.label5.TabIndex = 586;
			this.label5.Tag = "6";
			this.label5.Text = "月经史:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(16, 180);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 22);
			this.label6.TabIndex = 584;
			this.label6.Tag = "5";
			this.label6.Text = "婚姻史:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(16, 376);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 22);
			this.label7.TabIndex = 585;
			this.label7.Tag = "7";
			this.label7.Text = "家族史:";
			// 
			// m_txtCatameniaHistory
			// 
			this.m_txtCatameniaHistory.AccessibleDescription = "月经史";
			this.m_txtCatameniaHistory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtCatameniaHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtCatameniaHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtCatameniaHistory.ForeColor = System.Drawing.Color.White;
			this.m_txtCatameniaHistory.Location = new System.Drawing.Point(16, 308);
			this.m_txtCatameniaHistory.m_BlnIgnoreUserInfo = false;
			this.m_txtCatameniaHistory.m_BlnPartControl = false;
			this.m_txtCatameniaHistory.m_BlnReadOnly = false;
			this.m_txtCatameniaHistory.m_BlnUnderLineDST = false;
			this.m_txtCatameniaHistory.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtCatameniaHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtCatameniaHistory.m_IntCanModifyTime = 6;
			this.m_txtCatameniaHistory.m_IntPartControlLength = 0;
			this.m_txtCatameniaHistory.m_IntPartControlStartIndex = 0;
			this.m_txtCatameniaHistory.m_StrUserID = "";
			this.m_txtCatameniaHistory.m_StrUserName = "";
			this.m_txtCatameniaHistory.Name = "m_txtCatameniaHistory";
			this.m_txtCatameniaHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtCatameniaHistory.Size = new System.Drawing.Size(912, 60);
			this.m_txtCatameniaHistory.TabIndex = 200;
			this.m_txtCatameniaHistory.Tag = "6";
			this.m_txtCatameniaHistory.Text = "";
			// 
			// m_txtMarriageHistory
			// 
			this.m_txtMarriageHistory.AccessibleDescription = "婚姻史";
			this.m_txtMarriageHistory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtMarriageHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtMarriageHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMarriageHistory.ForeColor = System.Drawing.Color.White;
			this.m_txtMarriageHistory.Location = new System.Drawing.Point(16, 208);
			this.m_txtMarriageHistory.m_BlnIgnoreUserInfo = false;
			this.m_txtMarriageHistory.m_BlnPartControl = false;
			this.m_txtMarriageHistory.m_BlnReadOnly = false;
			this.m_txtMarriageHistory.m_BlnUnderLineDST = false;
			this.m_txtMarriageHistory.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtMarriageHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtMarriageHistory.m_IntCanModifyTime = 6;
			this.m_txtMarriageHistory.m_IntPartControlLength = 0;
			this.m_txtMarriageHistory.m_IntPartControlStartIndex = 0;
			this.m_txtMarriageHistory.m_StrUserID = "";
			this.m_txtMarriageHistory.m_StrUserName = "";
			this.m_txtMarriageHistory.Name = "m_txtMarriageHistory";
			this.m_txtMarriageHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtMarriageHistory.Size = new System.Drawing.Size(912, 64);
			this.m_txtMarriageHistory.TabIndex = 190;
			this.m_txtMarriageHistory.Tag = "5";
			this.m_txtMarriageHistory.Text = "";
			// 
			// m_txtFamilyHistory
			// 
			this.m_txtFamilyHistory.AccessibleDescription = "家族史";
			this.m_txtFamilyHistory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFamilyHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFamilyHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFamilyHistory.ForeColor = System.Drawing.Color.White;
			this.m_txtFamilyHistory.Location = new System.Drawing.Point(16, 404);
			this.m_txtFamilyHistory.m_BlnIgnoreUserInfo = false;
			this.m_txtFamilyHistory.m_BlnPartControl = false;
			this.m_txtFamilyHistory.m_BlnReadOnly = false;
			this.m_txtFamilyHistory.m_BlnUnderLineDST = false;
			this.m_txtFamilyHistory.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtFamilyHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtFamilyHistory.m_IntCanModifyTime = 6;
			this.m_txtFamilyHistory.m_IntPartControlLength = 0;
			this.m_txtFamilyHistory.m_IntPartControlStartIndex = 0;
			this.m_txtFamilyHistory.m_StrUserID = "";
			this.m_txtFamilyHistory.m_StrUserName = "";
			this.m_txtFamilyHistory.Name = "m_txtFamilyHistory";
			this.m_txtFamilyHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtFamilyHistory.Size = new System.Drawing.Size(912, 92);
			this.m_txtFamilyHistory.TabIndex = 210;
			this.m_txtFamilyHistory.Tag = "7";
			this.m_txtFamilyHistory.Text = "";
			// 
			// pictureBox4
			// 
			this.pictureBox4.Location = new System.Drawing.Point(16, 192);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(16, 16);
			this.pictureBox4.TabIndex = 589;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Tag = "5";
			this.pictureBox4.Visible = false;
			// 
			// pictureBox5
			// 
			this.pictureBox5.Location = new System.Drawing.Point(16, 272);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(16, 16);
			this.pictureBox5.TabIndex = 588;
			this.pictureBox5.TabStop = false;
			this.pictureBox5.Tag = "6";
			this.pictureBox5.Visible = false;
			// 
			// pictureBox6
			// 
			this.pictureBox6.Location = new System.Drawing.Point(16, 416);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(16, 16);
			this.pictureBox6.TabIndex = 587;
			this.pictureBox6.TabStop = false;
			this.pictureBox6.Tag = "7";
			this.pictureBox6.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(16, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 22);
			this.label4.TabIndex = 582;
			this.label4.Tag = "4";
			this.label4.Text = "个人史:";
			// 
			// m_txtOwnHistory
			// 
			this.m_txtOwnHistory.AccessibleDescription = "个人史";
			this.m_txtOwnHistory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtOwnHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtOwnHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOwnHistory.ForeColor = System.Drawing.Color.White;
			this.m_txtOwnHistory.Location = new System.Drawing.Point(16, 48);
			this.m_txtOwnHistory.m_BlnIgnoreUserInfo = false;
			this.m_txtOwnHistory.m_BlnPartControl = false;
			this.m_txtOwnHistory.m_BlnReadOnly = false;
			this.m_txtOwnHistory.m_BlnUnderLineDST = false;
			this.m_txtOwnHistory.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtOwnHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtOwnHistory.m_IntCanModifyTime = 6;
			this.m_txtOwnHistory.m_IntPartControlLength = 0;
			this.m_txtOwnHistory.m_IntPartControlStartIndex = 0;
			this.m_txtOwnHistory.m_StrUserID = "";
			this.m_txtOwnHistory.m_StrUserName = "";
			this.m_txtOwnHistory.Name = "m_txtOwnHistory";
			this.m_txtOwnHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtOwnHistory.Size = new System.Drawing.Size(912, 120);
			this.m_txtOwnHistory.TabIndex = 180;
			this.m_txtOwnHistory.Tag = "4";
			this.m_txtOwnHistory.Text = "";
			// 
			// m_lblOwnHistory
			// 
			this.m_lblOwnHistory.Location = new System.Drawing.Point(16, 72);
			this.m_lblOwnHistory.Name = "m_lblOwnHistory";
			this.m_lblOwnHistory.Size = new System.Drawing.Size(16, 16);
			this.m_lblOwnHistory.TabIndex = 583;
			this.m_lblOwnHistory.TabStop = false;
			this.m_lblOwnHistory.Tag = "4";
			this.m_lblOwnHistory.Visible = false;
			// 
			// tabPage5
			// 
			this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage5.Controls.Add(this.m_txtSummary);
			this.tabPage5.Controls.Add(this.m_txtLabCheck);
			this.tabPage5.Controls.Add(this.label10);
			this.tabPage5.Controls.Add(this.pictureBox7);
			this.tabPage5.Controls.Add(this.m_picLabCheck);
			this.tabPage5.Controls.Add(this.lblLabCheck);
			this.tabPage5.Location = new System.Drawing.Point(4, 25);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(944, 515);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "第五页";
			// 
			// m_txtSummary
			// 
			this.m_txtSummary.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtSummary.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtSummary.ForeColor = System.Drawing.Color.White;
			this.m_txtSummary.Location = new System.Drawing.Point(396, 60);
			this.m_txtSummary.m_BlnIgnoreUserInfo = true;
			this.m_txtSummary.m_BlnPartControl = false;
			this.m_txtSummary.m_BlnReadOnly = false;
			this.m_txtSummary.m_BlnUnderLineDST = false;
			this.m_txtSummary.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtSummary.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtSummary.m_IntCanModifyTime = 6;
			this.m_txtSummary.m_IntPartControlLength = 0;
			this.m_txtSummary.m_IntPartControlStartIndex = 0;
			this.m_txtSummary.m_StrUserID = "";
			this.m_txtSummary.m_StrUserName = "";
			this.m_txtSummary.Name = "m_txtSummary";
			this.m_txtSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtSummary.Size = new System.Drawing.Size(196, 152);
			this.m_txtSummary.TabIndex = 23;
			this.m_txtSummary.Tag = "150";
			this.m_txtSummary.Text = "";
			this.m_txtSummary.Visible = false;
			// 
			// m_txtLabCheck
			// 
			this.m_txtLabCheck.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtLabCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtLabCheck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLabCheck.ForeColor = System.Drawing.Color.White;
			this.m_txtLabCheck.Location = new System.Drawing.Point(16, 48);
			this.m_txtLabCheck.m_BlnIgnoreUserInfo = false;
			this.m_txtLabCheck.m_BlnPartControl = false;
			this.m_txtLabCheck.m_BlnReadOnly = false;
			this.m_txtLabCheck.m_BlnUnderLineDST = false;
			this.m_txtLabCheck.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtLabCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtLabCheck.m_IntCanModifyTime = 6;
			this.m_txtLabCheck.m_IntPartControlLength = 0;
			this.m_txtLabCheck.m_IntPartControlStartIndex = 0;
			this.m_txtLabCheck.m_StrUserID = "";
			this.m_txtLabCheck.m_StrUserName = "";
			this.m_txtLabCheck.Name = "m_txtLabCheck";
			this.m_txtLabCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtLabCheck.Size = new System.Drawing.Size(912, 292);
			this.m_txtLabCheck.TabIndex = 22;
			this.m_txtLabCheck.Tag = "140";
			this.m_txtLabCheck.Text = "";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.Location = new System.Drawing.Point(148, 396);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 22);
			this.label10.TabIndex = 608;
			this.label10.Tag = "11";
			this.label10.Text = "摘      要:";
			this.label10.Visible = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.Location = new System.Drawing.Point(80, 384);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(16, 16);
			this.pictureBox7.TabIndex = 609;
			this.pictureBox7.TabStop = false;
			this.pictureBox7.Tag = "11";
			this.pictureBox7.Visible = false;
			// 
			// m_picLabCheck
			// 
			this.m_picLabCheck.Location = new System.Drawing.Point(72, 96);
			this.m_picLabCheck.Name = "m_picLabCheck";
			this.m_picLabCheck.Size = new System.Drawing.Size(16, 16);
			this.m_picLabCheck.TabIndex = 606;
			this.m_picLabCheck.TabStop = false;
			this.m_picLabCheck.Tag = "10";
			this.m_picLabCheck.Visible = false;
			// 
			// lblLabCheck
			// 
			this.lblLabCheck.AutoSize = true;
			this.lblLabCheck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLabCheck.Location = new System.Drawing.Point(16, 20);
			this.lblLabCheck.Name = "lblLabCheck";
			this.lblLabCheck.Size = new System.Drawing.Size(96, 22);
			this.lblLabCheck.TabIndex = 605;
			this.lblLabCheck.Tag = "10";
			this.lblLabCheck.Text = "实验室检查:";
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage4.Controls.Add(this.label13);
			this.tabPage4.Controls.Add(this.label12);
			this.tabPage4.Controls.Add(this.ctlPaintContainer1);
			this.tabPage4.Controls.Add(this.m_txtProfessionalCheck);
			this.tabPage4.Controls.Add(this.pictureBox9);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(944, 515);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "专科检查";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.Location = new System.Drawing.Point(16, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(80, 22);
			this.label13.TabIndex = 611;
			this.label13.Tag = "9";
			this.label13.Text = "专科检查:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(8, 288);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(80, 22);
			this.label12.TabIndex = 610;
			this.label12.Tag = "9";
			this.label12.Text = "图片信息:";
			// 
			// ctlPaintContainer1
			// 
			this.ctlPaintContainer1.AutoScroll = true;
			this.ctlPaintContainer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ctlPaintContainer1.ForeColor = System.Drawing.Color.White;
			this.ctlPaintContainer1.Location = new System.Drawing.Point(8, 316);
			this.ctlPaintContainer1.m_BlnCanAddImage = true;
			this.ctlPaintContainer1.m_BlnScaleSize = true;
			this.ctlPaintContainer1.m_ClrcmdRubber = System.Drawing.Color.Silver;
			this.ctlPaintContainer1.m_ClrcmdSelected = System.Drawing.Color.White;
			this.ctlPaintContainer1.m_ClrgpbTools = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ctlPaintContainer1.m_ClrppgPicSize = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ctlPaintContainer1.m_ClrrdbDash = System.Drawing.Color.Silver;
			this.ctlPaintContainer1.m_ClrrdbLine = System.Drawing.Color.Silver;
			this.ctlPaintContainer1.m_ClrrdbPen = System.Drawing.Color.Silver;
			this.ctlPaintContainer1.m_ClrrdbText = System.Drawing.Color.Silver;
			this.ctlPaintContainer1.m_IntDefaultHeight = 253;
			this.ctlPaintContainer1.m_IntDefaultWidth = 320;
			this.ctlPaintContainer1.Name = "ctlPaintContainer1";
			this.ctlPaintContainer1.Size = new System.Drawing.Size(916, 180);
			this.ctlPaintContainer1.TabIndex = 160;
			this.ctlPaintContainer1.选择科室图片 = com.digitalwave.Utility.Controls.ctlPaintContainer.enmImageNames.无;
			// 
			// m_txtProfessionalCheck
			// 
			this.m_txtProfessionalCheck.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtProfessionalCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtProfessionalCheck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtProfessionalCheck.ForeColor = System.Drawing.Color.White;
			this.m_txtProfessionalCheck.Location = new System.Drawing.Point(16, 48);
			this.m_txtProfessionalCheck.m_BlnIgnoreUserInfo = false;
			this.m_txtProfessionalCheck.m_BlnPartControl = false;
			this.m_txtProfessionalCheck.m_BlnReadOnly = false;
			this.m_txtProfessionalCheck.m_BlnUnderLineDST = false;
			this.m_txtProfessionalCheck.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtProfessionalCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtProfessionalCheck.m_IntCanModifyTime = 6;
			this.m_txtProfessionalCheck.m_IntPartControlLength = 0;
			this.m_txtProfessionalCheck.m_IntPartControlStartIndex = 0;
			this.m_txtProfessionalCheck.m_StrUserID = "";
			this.m_txtProfessionalCheck.m_StrUserName = "";
			this.m_txtProfessionalCheck.Name = "m_txtProfessionalCheck";
			this.m_txtProfessionalCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtProfessionalCheck.Size = new System.Drawing.Size(908, 232);
			this.m_txtProfessionalCheck.TabIndex = 150;
			this.m_txtProfessionalCheck.Tag = "9";
			this.m_txtProfessionalCheck.Text = "";
			// 
			// pictureBox9
			// 
			this.pictureBox9.Location = new System.Drawing.Point(90, 40);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(16, 20);
			this.pictureBox9.TabIndex = 606;
			this.pictureBox9.TabStop = false;
			this.pictureBox9.Tag = "9";
			this.pictureBox9.Visible = false;
			// 
			// tabPage6
			// 
			this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage6.Controls.Add(this.m_cmdFinallyDiagnoseDocID);
			this.tabPage6.Controls.Add(this.m_cmdPrimaryDiagnoseDocID);
			this.tabPage6.Controls.Add(this.label11);
			this.tabPage6.Controls.Add(this.lblFinallyDiagnose);
			this.tabPage6.Controls.Add(this.m_lsvFinallyDiagnoseDocID);
			this.tabPage6.Controls.Add(this.m_dtpFinallyDiagnoseDate);
			this.tabPage6.Controls.Add(this.m_dtpPrimaryDiagnoseDate);
			this.tabPage6.Controls.Add(this.m_txtPrimaryDiagnoseDocID);
			this.tabPage6.Controls.Add(this.m_txtFinallyDiagnoseDocID);
			this.tabPage6.Controls.Add(this.lblPrimaryDiagnoseDate);
			this.tabPage6.Controls.Add(this.lblFinallyDiagnoseDate);
			this.tabPage6.Controls.Add(this.m_txtFinallyDiagnose);
			this.tabPage6.Controls.Add(this.m_txtPrimaryDiagnose);
			this.tabPage6.Controls.Add(this.pictureBox8);
			this.tabPage6.Controls.Add(this.pictureBox10);
			this.tabPage6.Location = new System.Drawing.Point(4, 25);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(944, 515);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "诊断";
			// 
			// m_cmdFinallyDiagnoseDocID
			// 
			this.m_cmdFinallyDiagnoseDocID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdFinallyDiagnoseDocID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdFinallyDiagnoseDocID.Location = new System.Drawing.Point(576, 376);
			this.m_cmdFinallyDiagnoseDocID.Name = "m_cmdFinallyDiagnoseDocID";
			this.m_cmdFinallyDiagnoseDocID.Size = new System.Drawing.Size(110, 28);
			this.m_cmdFinallyDiagnoseDocID.TabIndex = 10000078;
			this.m_cmdFinallyDiagnoseDocID.Text = "最后诊断签名:";
			this.m_cmdFinallyDiagnoseDocID.Visible = false;
			// 
			// m_cmdPrimaryDiagnoseDocID
			// 
			this.m_cmdPrimaryDiagnoseDocID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdPrimaryDiagnoseDocID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdPrimaryDiagnoseDocID.Location = new System.Drawing.Point(92, 376);
			this.m_cmdPrimaryDiagnoseDocID.Name = "m_cmdPrimaryDiagnoseDocID";
			this.m_cmdPrimaryDiagnoseDocID.Size = new System.Drawing.Size(112, 28);
			this.m_cmdPrimaryDiagnoseDocID.TabIndex = 10000077;
			this.m_cmdPrimaryDiagnoseDocID.Text = "初步诊断签名:";
			this.m_cmdPrimaryDiagnoseDocID.Visible = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.Location = new System.Drawing.Point(16, 20);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 22);
			this.label11.TabIndex = 607;
			this.label11.Tag = "12";
			this.label11.Text = "初步诊断:";
			// 
			// lblFinallyDiagnose
			// 
			this.lblFinallyDiagnose.AutoSize = true;
			this.lblFinallyDiagnose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblFinallyDiagnose.Location = new System.Drawing.Point(492, 180);
			this.lblFinallyDiagnose.Name = "lblFinallyDiagnose";
			this.lblFinallyDiagnose.Size = new System.Drawing.Size(80, 22);
			this.lblFinallyDiagnose.TabIndex = 606;
			this.lblFinallyDiagnose.Tag = "12";
			this.lblFinallyDiagnose.Text = "最后诊断:";
			this.lblFinallyDiagnose.Visible = false;
			// 
			// m_lsvFinallyDiagnoseDocID
			// 
			this.m_lsvFinallyDiagnoseDocID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lsvFinallyDiagnoseDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvFinallyDiagnoseDocID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																										this.columnHeader3,
																										this.columnHeader4});
			this.m_lsvFinallyDiagnoseDocID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvFinallyDiagnoseDocID.ForeColor = System.Drawing.SystemColors.Window;
			this.m_lsvFinallyDiagnoseDocID.FullRowSelect = true;
			this.m_lsvFinallyDiagnoseDocID.GridLines = true;
			this.m_lsvFinallyDiagnoseDocID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvFinallyDiagnoseDocID.Location = new System.Drawing.Point(692, 400);
			this.m_lsvFinallyDiagnoseDocID.MultiSelect = false;
			this.m_lsvFinallyDiagnoseDocID.Name = "m_lsvFinallyDiagnoseDocID";
			this.m_lsvFinallyDiagnoseDocID.Size = new System.Drawing.Size(102, 105);
			this.m_lsvFinallyDiagnoseDocID.TabIndex = 608;
			this.m_lsvFinallyDiagnoseDocID.Tag = "12";
			this.m_lsvFinallyDiagnoseDocID.View = System.Windows.Forms.View.Details;
			this.m_lsvFinallyDiagnoseDocID.Visible = false;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "编号";
			this.columnHeader3.Width = 0;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "名称";
			this.columnHeader4.Width = 100;
			// 
			// m_dtpFinallyDiagnoseDate
			// 
			this.m_dtpFinallyDiagnoseDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpFinallyDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpFinallyDiagnoseDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpFinallyDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpFinallyDiagnoseDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpFinallyDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpFinallyDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpFinallyDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpFinallyDiagnoseDate.Location = new System.Drawing.Point(692, 424);
			this.m_dtpFinallyDiagnoseDate.m_BlnOnlyTime = false;
			this.m_dtpFinallyDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpFinallyDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpFinallyDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpFinallyDiagnoseDate.Name = "m_dtpFinallyDiagnoseDate";
			this.m_dtpFinallyDiagnoseDate.ReadOnly = false;
			this.m_dtpFinallyDiagnoseDate.Size = new System.Drawing.Size(216, 22);
			this.m_dtpFinallyDiagnoseDate.TabIndex = 29;
			this.m_dtpFinallyDiagnoseDate.Tag = "12";
			this.m_dtpFinallyDiagnoseDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpFinallyDiagnoseDate.TextForeColor = System.Drawing.Color.White;
			this.m_dtpFinallyDiagnoseDate.Visible = false;
			// 
			// m_dtpPrimaryDiagnoseDate
			// 
			this.m_dtpPrimaryDiagnoseDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpPrimaryDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpPrimaryDiagnoseDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpPrimaryDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpPrimaryDiagnoseDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpPrimaryDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpPrimaryDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpPrimaryDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpPrimaryDiagnoseDate.Location = new System.Drawing.Point(210, 424);
			this.m_dtpPrimaryDiagnoseDate.m_BlnOnlyTime = false;
			this.m_dtpPrimaryDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpPrimaryDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpPrimaryDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpPrimaryDiagnoseDate.Name = "m_dtpPrimaryDiagnoseDate";
			this.m_dtpPrimaryDiagnoseDate.ReadOnly = false;
			this.m_dtpPrimaryDiagnoseDate.Size = new System.Drawing.Size(216, 22);
			this.m_dtpPrimaryDiagnoseDate.TabIndex = 26;
			this.m_dtpPrimaryDiagnoseDate.Tag = "12";
			this.m_dtpPrimaryDiagnoseDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpPrimaryDiagnoseDate.TextForeColor = System.Drawing.Color.White;
			this.m_dtpPrimaryDiagnoseDate.Visible = false;
			// 
			// m_txtPrimaryDiagnoseDocID
			// 
			this.m_txtPrimaryDiagnoseDocID.AccessibleName = "NoDefault";
			this.m_txtPrimaryDiagnoseDocID.AutoSize = false;
			this.m_txtPrimaryDiagnoseDocID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPrimaryDiagnoseDocID.BorderColor = System.Drawing.Color.White;
			this.m_txtPrimaryDiagnoseDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtPrimaryDiagnoseDocID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPrimaryDiagnoseDocID.ForeColor = System.Drawing.Color.White;
			this.m_txtPrimaryDiagnoseDocID.Location = new System.Drawing.Point(210, 379);
			this.m_txtPrimaryDiagnoseDocID.Name = "m_txtPrimaryDiagnoseDocID";
			this.m_txtPrimaryDiagnoseDocID.Size = new System.Drawing.Size(102, 21);
			this.m_txtPrimaryDiagnoseDocID.TabIndex = 25;
			this.m_txtPrimaryDiagnoseDocID.Tag = "12";
			this.m_txtPrimaryDiagnoseDocID.Text = "";
			this.m_txtPrimaryDiagnoseDocID.Visible = false;
			// 
			// m_txtFinallyDiagnoseDocID
			// 
			this.m_txtFinallyDiagnoseDocID.AccessibleName = "NoDefault";
			this.m_txtFinallyDiagnoseDocID.AutoSize = false;
			this.m_txtFinallyDiagnoseDocID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFinallyDiagnoseDocID.BorderColor = System.Drawing.Color.White;
			this.m_txtFinallyDiagnoseDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtFinallyDiagnoseDocID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFinallyDiagnoseDocID.ForeColor = System.Drawing.Color.White;
			this.m_txtFinallyDiagnoseDocID.Location = new System.Drawing.Point(692, 379);
			this.m_txtFinallyDiagnoseDocID.Name = "m_txtFinallyDiagnoseDocID";
			this.m_txtFinallyDiagnoseDocID.Size = new System.Drawing.Size(102, 21);
			this.m_txtFinallyDiagnoseDocID.TabIndex = 28;
			this.m_txtFinallyDiagnoseDocID.Tag = "12";
			this.m_txtFinallyDiagnoseDocID.Text = "";
			this.m_txtFinallyDiagnoseDocID.Visible = false;
			// 
			// lblPrimaryDiagnoseDate
			// 
			this.lblPrimaryDiagnoseDate.AutoSize = true;
			this.lblPrimaryDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPrimaryDiagnoseDate.Location = new System.Drawing.Point(90, 424);
			this.lblPrimaryDiagnoseDate.Name = "lblPrimaryDiagnoseDate";
			this.lblPrimaryDiagnoseDate.Size = new System.Drawing.Size(113, 22);
			this.lblPrimaryDiagnoseDate.TabIndex = 611;
			this.lblPrimaryDiagnoseDate.Tag = "12";
			this.lblPrimaryDiagnoseDate.Text = "初步诊断日期:";
			this.lblPrimaryDiagnoseDate.Visible = false;
			// 
			// lblFinallyDiagnoseDate
			// 
			this.lblFinallyDiagnoseDate.AutoSize = true;
			this.lblFinallyDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblFinallyDiagnoseDate.Location = new System.Drawing.Point(572, 424);
			this.lblFinallyDiagnoseDate.Name = "lblFinallyDiagnoseDate";
			this.lblFinallyDiagnoseDate.Size = new System.Drawing.Size(113, 22);
			this.lblFinallyDiagnoseDate.TabIndex = 610;
			this.lblFinallyDiagnoseDate.Tag = "12";
			this.lblFinallyDiagnoseDate.Text = "最后诊断日期:";
			this.lblFinallyDiagnoseDate.Visible = false;
			// 
			// m_txtFinallyDiagnose
			// 
			this.m_txtFinallyDiagnose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtFinallyDiagnose.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtFinallyDiagnose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtFinallyDiagnose.ForeColor = System.Drawing.Color.White;
			this.m_txtFinallyDiagnose.Location = new System.Drawing.Point(308, 140);
			this.m_txtFinallyDiagnose.m_BlnIgnoreUserInfo = true;
			this.m_txtFinallyDiagnose.m_BlnPartControl = false;
			this.m_txtFinallyDiagnose.m_BlnReadOnly = false;
			this.m_txtFinallyDiagnose.m_BlnUnderLineDST = false;
			this.m_txtFinallyDiagnose.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtFinallyDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtFinallyDiagnose.m_IntCanModifyTime = 6;
			this.m_txtFinallyDiagnose.m_IntPartControlLength = 0;
			this.m_txtFinallyDiagnose.m_IntPartControlStartIndex = 0;
			this.m_txtFinallyDiagnose.m_StrUserID = "";
			this.m_txtFinallyDiagnose.m_StrUserName = "";
			this.m_txtFinallyDiagnose.Name = "m_txtFinallyDiagnose";
			this.m_txtFinallyDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtFinallyDiagnose.Size = new System.Drawing.Size(108, 68);
			this.m_txtFinallyDiagnose.TabIndex = 27;
			this.m_txtFinallyDiagnose.Tag = "12";
			this.m_txtFinallyDiagnose.Text = "";
			this.m_txtFinallyDiagnose.Visible = false;
			// 
			// m_txtPrimaryDiagnose
			// 
			this.m_txtPrimaryDiagnose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPrimaryDiagnose.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtPrimaryDiagnose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPrimaryDiagnose.ForeColor = System.Drawing.Color.White;
			this.m_txtPrimaryDiagnose.Location = new System.Drawing.Point(16, 48);
			this.m_txtPrimaryDiagnose.m_BlnIgnoreUserInfo = false;
			this.m_txtPrimaryDiagnose.m_BlnPartControl = false;
			this.m_txtPrimaryDiagnose.m_BlnReadOnly = false;
			this.m_txtPrimaryDiagnose.m_BlnUnderLineDST = false;
			this.m_txtPrimaryDiagnose.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtPrimaryDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtPrimaryDiagnose.m_IntCanModifyTime = 6;
			this.m_txtPrimaryDiagnose.m_IntPartControlLength = 0;
			this.m_txtPrimaryDiagnose.m_IntPartControlStartIndex = 0;
			this.m_txtPrimaryDiagnose.m_StrUserID = "";
			this.m_txtPrimaryDiagnose.m_StrUserName = "";
			this.m_txtPrimaryDiagnose.Name = "m_txtPrimaryDiagnose";
			this.m_txtPrimaryDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtPrimaryDiagnose.Size = new System.Drawing.Size(912, 288);
			this.m_txtPrimaryDiagnose.TabIndex = 280;
			this.m_txtPrimaryDiagnose.Tag = "12";
			this.m_txtPrimaryDiagnose.Text = "";
			// 
			// pictureBox8
			// 
			this.pictureBox8.Location = new System.Drawing.Point(40, 24);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(16, 16);
			this.pictureBox8.TabIndex = 613;
			this.pictureBox8.TabStop = false;
			this.pictureBox8.Tag = "12";
			// 
			// pictureBox10
			// 
			this.pictureBox10.Location = new System.Drawing.Point(40, 56);
			this.pictureBox10.Name = "pictureBox10";
			this.pictureBox10.Size = new System.Drawing.Size(16, 16);
			this.pictureBox10.TabIndex = 614;
			this.pictureBox10.TabStop = false;
			this.pictureBox10.Tag = "12";
			this.pictureBox10.Visible = false;
			// 
			// m_lsvEmployee
			// 
			this.m_lsvEmployee.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.columnHeader6,
																							this.columnHeader7});
			this.m_lsvEmployee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvEmployee.ForeColor = System.Drawing.Color.White;
			this.m_lsvEmployee.FullRowSelect = true;
			this.m_lsvEmployee.GridLines = true;
			this.m_lsvEmployee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvEmployee.Location = new System.Drawing.Point(880, 160);
			this.m_lsvEmployee.Name = "m_lsvEmployee";
			this.m_lsvEmployee.Size = new System.Drawing.Size(102, 105);
			this.m_lsvEmployee.TabIndex = 10000022;
			this.m_lsvEmployee.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Width = 0;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Width = 100;
			// 
			// m_txtSign
			// 
			this.m_txtSign.AccessibleName = "NoDefault";
			this.m_txtSign.AutoSize = false;
			this.m_txtSign.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtSign.BorderColor = System.Drawing.Color.White;
			this.m_txtSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtSign.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtSign.ForeColor = System.Drawing.Color.White;
			this.m_txtSign.Location = new System.Drawing.Point(880, 136);
			this.m_txtSign.Name = "m_txtSign";
			this.m_txtSign.Size = new System.Drawing.Size(100, 21);
			this.m_txtSign.TabIndex = 90;
			this.m_txtSign.Text = "";
			// 
			// frmInPatientCaseHistoryMode1
			// 
			this.AccessibleDescription = "住  院  病  历 2";
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(700, 453);
			this.Controls.Add(this.lblCredibility);
			this.Controls.Add(this.m_lsvEmployee);
			this.Controls.Add(this.m_txtSign);
			this.Controls.Add(this.tabInPatientCase);
			this.Controls.Add(this.m_cboRepresentor);
			this.Controls.Add(this.lblRepresentor);
			this.Controls.Add(this.m_cboCredibility);
			this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmInPatientCaseHistoryMode1";
			this.Text = "住  院  病  历";
			this.Load += new System.EventHandler(this.frmInPatientCaseHistory_Load);
			this.Controls.SetChildIndex(this.m_cboCredibility, 0);
			this.Controls.SetChildIndex(this.lblRepresentor, 0);
			this.Controls.SetChildIndex(this.m_cboRepresentor, 0);
			this.Controls.SetChildIndex(this.tabInPatientCase, 0);
			this.Controls.SetChildIndex(this.m_txtSign, 0);
			this.Controls.SetChildIndex(this.m_lsvEmployee, 0);
			this.Controls.SetChildIndex(this.lblCredibility, 0);
			this.Controls.SetChildIndex(this.m_lblForTitle, 0);
			this.Controls.SetChildIndex(this.txtInPatientID, 0);
			this.Controls.SetChildIndex(this.lblAreaTitle, 0);
			this.Controls.SetChildIndex(this.lblAgeTitle, 0);
			this.Controls.SetChildIndex(this.lblSexTitle, 0);
			this.Controls.SetChildIndex(this.lblNameTitle, 0);
			this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
			this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
			this.Controls.SetChildIndex(this.lblAge, 0);
			this.Controls.SetChildIndex(this.lblSex, 0);
			this.Controls.SetChildIndex(this.m_txtPatientName, 0);
			this.Controls.SetChildIndex(this.m_txtBedNO, 0);
			this.Controls.SetChildIndex(this.m_cboArea, 0);
			this.Controls.SetChildIndex(this.trvTime, 0);
			this.Controls.SetChildIndex(this.lblCreateDate, 0);
			this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
			this.Controls.SetChildIndex(this.m_lblAddress, 0);
			this.Controls.SetChildIndex(this.m_lblLinkMan, 0);
			this.Controls.SetChildIndex(this.m_lblCreateUserName, 0);
			this.Controls.SetChildIndex(this.m_lblMarriaged, 0);
			this.Controls.SetChildIndex(this.m_lblOccupation, 0);
			this.Controls.SetChildIndex(this.m_lblNativePlace, 0);
			this.Controls.SetChildIndex(this.lblAddress, 0);
			this.Controls.SetChildIndex(this.lblLinkMan, 0);
			this.Controls.SetChildIndex(this.lblMarriaged, 0);
			this.Controls.SetChildIndex(this.lblOccupation, 0);
			this.Controls.SetChildIndex(this.lblNativePlace, 0);
			this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
			this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
			this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
			this.Controls.SetChildIndex(this.lblDept, 0);
			this.Controls.SetChildIndex(this.m_cboDept, 0);
			this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
			this.Controls.SetChildIndex(this.m_cmdNext, 0);
			this.Controls.SetChildIndex(this.m_cmdPre, 0);
			this.Controls.SetChildIndex(this.m_cmdCreateID, 0);
			this.tabInPatientCase.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.体格检查.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		// 获取选择已经删除记录的窗体标题
		public override void m_strReloadFormTitle()
		{
		
		}

		// 清空特殊记录信息，并重置记录控制状态为不控制。
		protected override void m_mthClearRecordInfo()
		{
			m_objSignTool.m_mthSetDefaulEmployee();

			m_strCurrentOpenDate = "";

			this.m_txtBeforetimeStatus.m_mthClearText();
			this.m_txtBreath.m_mthClearText();
			this.m_txtCurrentStatus.m_mthClearText();
			this.m_txtDia.m_mthClearText();
			this.m_txtFamilyHistory.m_mthClearText();
			this.m_txtFinallyDiagnose.m_mthClearText();
			this.m_txtFinallyDiagnoseDocID.Text="";
			this.m_txtLabCheck.m_mthClearText();
			this.m_txtMainDescription .m_mthClearText();
			this.m_txtMarriageHistory.m_mthClearText();
			this.m_txtMedical.m_mthClearText();
			this.m_txtOwnHistory.m_mthClearText();
			this.m_txtPrimaryDiagnose.m_mthClearText();
			this.m_txtPrimaryDiagnoseDocID.Text="";
			this.m_txtProfessionalCheck.m_mthClearText() ;
			this.m_txtPulse.m_mthClearText();
			this.m_txtSummary.m_mthClearText();
			this.m_txtTemperature.m_mthClearText();
			this.m_txtSys.m_mthClearText();
			this.m_dtpFinallyDiagnoseDate.Text =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
			this.m_dtpPrimaryDiagnoseDate.Text =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			this.m_cboCredibility.SelectedIndex=-1;
			this.m_cboRepresentor.SelectedIndex=-1;
			this.m_txtCatameniaHistory.m_mthClearText();

			m_objMedicalExamDomain.m_mthClearMedicalExamControls (this.m_objMedicalExamForm );
			m_strMedicalExam_ID ="";

			m_mthSetModifyControl(null,true);

			ctlPaintContainer1.m_mthClear();
		}

		protected override void m_mthClearPatientBaseInfo()
		{
			base.m_mthClearPatientBaseInfo();
			m_lblLinkMan.Text="";
			m_lblOccupation.Text="";
			m_lblMarriaged.Text="";
			m_lblCreateUserName.Text="";
			m_lblNativePlace.Text="";
			m_lblAddress.Text="";
		}

		private void m_mthDoctorListControl(object sender,EventArgs e)
		{
			/*
			 * 控制选择医生的ListView是否隐藏
			 */
			try
			{
				switch(m_bytListOnDoctor)
				{
					case 0:
						if(!m_lsvFinallyDiagnoseDocID.Focused && !m_txtPrimaryDiagnoseDocID.Focused)
						{
							m_lsvFinallyDiagnoseDocID.Visible=false;
						}
						break;
					case 1:
						if(!m_lsvFinallyDiagnoseDocID.Focused && !m_txtFinallyDiagnoseDocID.Focused)
						{
							m_lsvFinallyDiagnoseDocID.Visible=false;
						}
						break;
				}
			}
			catch{}
		}

		protected override void m_mthUnEnableRichTextBox()
		{
			m_mthEnableRichTextBox(false);
		}

		protected override void m_mthEnableRichTextBox()
		{			
			m_mthEnableRichTextBox(true);
		}

		private void m_mthEnableRichTextBox(bool p_blnEnabled)
		{
			this.m_txtBeforetimeStatus.m_BlnReadOnly= ! p_blnEnabled;
			this.m_txtBreath.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtCurrentStatus.m_BlnReadOnly=! p_blnEnabled;	
			this.m_txtDia.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtFamilyHistory.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtFinallyDiagnose.m_BlnReadOnly=! p_blnEnabled;	
			this.m_txtLabCheck.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtMainDescription .m_BlnReadOnly=! p_blnEnabled;
			this.m_txtMarriageHistory.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtMedical.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtOwnHistory.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtPrimaryDiagnose.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtProfessionalCheck.m_BlnReadOnly=! p_blnEnabled ;
			this.m_txtPulse.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtSummary.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtTemperature.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtSys.m_BlnReadOnly=! p_blnEnabled;			
			this.m_txtCatameniaHistory.m_BlnReadOnly=! p_blnEnabled;
		}

		// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
		
		}

		protected override void m_mthHandleAddRecordSucceed()
		{
			if(trvTime.SelectedNode != null)
				trvTime.SelectedNode.Tag =(string)m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") ;
		}

		// 是否允许修改特殊记录的记录信息。
		protected override void m_mthEnableModifySub(bool p_blnEnable)
		{
			if(p_blnEnable)
			{
				this.m_txtPrimaryDiagnoseDocID.Enabled =true;
				this.m_txtFinallyDiagnoseDocID.Enabled =true;

			}
			else
			{
				if(this.m_txtPrimaryDiagnoseDocID.Text !="")
					this.m_txtPrimaryDiagnoseDocID.Enabled =false;
				if(this.m_txtFinallyDiagnoseDocID.Text !="")
					this.m_txtFinallyDiagnoseDocID.Enabled =false;
			}

		}

		#region Alex Mark 2003-5-16
//		// 设置是否控制修改（修改留痕迹）。
//		protected override void m_mthSetModifyControl(clsInPatientCaseHistoryContent p_objRecordContent,
//			bool p_blnReset)
//		{
//			if(p_objRecordContent==null)
//				return ;
//
//			clsBaseCaseHistoryInfo m_objBaseInfo = (clsBaseCaseHistoryInfo)p_objRecordContent;
//			if(p_blnReset==false)
//			{
//				this.m_txtBeforetimeStatus.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtBreath.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtCurrentStatus.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtDia.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtFamilyHistory.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtFinallyDiagnose.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtLabCheck.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtMainDescription.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtMarriageHistory.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtMedical.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtOwnHistory.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtPrimaryDiagnose.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtProfessionalCheck.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtPulse.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtSummary.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtTemperature.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtSys.m_ClrOldPartInsertText = Color.Red;
//				this.m_txtCatameniaHistory .m_ClrOldPartInsertText = Color.Red;
//			}
//			else
//			{
//				this.m_txtBeforetimeStatus.m_ClrOldPartInsertText = Color.White;
//				this.m_txtBreath.m_ClrOldPartInsertText = Color.White;
//				this.m_txtCurrentStatus.m_ClrOldPartInsertText = Color.White;
//				this.m_txtDia.m_ClrOldPartInsertText = Color.White;
//				this.m_txtFamilyHistory.m_ClrOldPartInsertText = Color.White;
//				this.m_txtFinallyDiagnose.m_ClrOldPartInsertText = Color.White;
//				this.m_txtLabCheck.m_ClrOldPartInsertText = Color.White;
//				this.m_txtMainDescription.m_ClrOldPartInsertText = Color.White;
//				this.m_txtMarriageHistory.m_ClrOldPartInsertText = Color.White;
//				this.m_txtMedical.m_ClrOldPartInsertText = Color.White;
//				this.m_txtOwnHistory.m_ClrOldPartInsertText = Color.White;
//				this.m_txtPrimaryDiagnose.m_ClrOldPartInsertText = Color.White;
//				this.m_txtProfessionalCheck.m_ClrOldPartInsertText = Color.White;
//				this.m_txtPulse.m_ClrOldPartInsertText = Color.White;
//				this.m_txtSummary.m_ClrOldPartInsertText = Color.White;
//				this.m_txtTemperature.m_ClrOldPartInsertText = Color.White;
//				this.m_txtSys.m_ClrOldPartInsertText = Color.White;
//				this.m_txtCatameniaHistory .m_ClrOldPartInsertText = Color.White;
//			}
//
//			if(m_objBaseInfo.m_strModifyUserID == MDIParent.OperatorID)
//			{
//				m_txtBeforetimeStatus.m_BlnCanModifyLast = true;
//				this.m_txtBreath.m_BlnCanModifyLast = true;
//				this.m_txtCurrentStatus.m_BlnCanModifyLast = true;
//				this.m_txtDia.m_BlnCanModifyLast = true;
//				this.m_txtFamilyHistory.m_BlnCanModifyLast = true;
//				this.m_txtFinallyDiagnose.m_BlnCanModifyLast = true;
//				this.m_txtLabCheck.m_BlnCanModifyLast = true;
//				this.m_txtMainDescription.m_BlnCanModifyLast = true;
//				this.m_txtMarriageHistory.m_BlnCanModifyLast = true;
//				this.m_txtMedical.m_BlnCanModifyLast = true;
//				this.m_txtOwnHistory.m_BlnCanModifyLast = true;
//				this.m_txtPrimaryDiagnose.m_BlnCanModifyLast = true;
//				this.m_txtProfessionalCheck.m_BlnCanModifyLast = true;
//				this.m_txtPulse.m_BlnCanModifyLast = true;
//				this.m_txtSummary.m_BlnCanModifyLast = true;
//				this.m_txtTemperature.m_BlnCanModifyLast = true;
//				this.m_txtSys.m_BlnCanModifyLast = true;
//				this.m_txtCatameniaHistory.m_BlnCanModifyLast = true;
//			}
//			else
//			{
//				m_txtBeforetimeStatus.m_BlnCanModifyLast = false;
//				this.m_txtBreath.m_BlnCanModifyLast = false;
//				this.m_txtCurrentStatus.m_BlnCanModifyLast = false;
//				this.m_txtDia.m_BlnCanModifyLast = false;
//				this.m_txtFamilyHistory.m_BlnCanModifyLast = false;
//				this.m_txtFinallyDiagnose.m_BlnCanModifyLast = false;
//				this.m_txtLabCheck.m_BlnCanModifyLast = false;
//				this.m_txtMainDescription.m_BlnCanModifyLast = false;
//				this.m_txtMarriageHistory.m_BlnCanModifyLast = false;
//				this.m_txtMedical.m_BlnCanModifyLast = false;
//				this.m_txtOwnHistory.m_BlnCanModifyLast = false;
//				this.m_txtPrimaryDiagnose.m_BlnCanModifyLast = false;
//				this.m_txtProfessionalCheck.m_BlnCanModifyLast = false;
//				this.m_txtPulse.m_BlnCanModifyLast = false;
//				this.m_txtSummary.m_BlnCanModifyLast = false;
//				this.m_txtTemperature.m_BlnCanModifyLast = false;
//				this.m_txtSys.m_BlnCanModifyLast = false;
//				this.m_txtCatameniaHistory.m_BlnCanModifyLast = false;
//			}
//		}
		#endregion

		// 从界面获取特殊记录的值。如果界面值出错，返回null。
		protected override clsInPatientCaseHistoryContent m_objGetContentFromGUI()
		{
			clsInPatientCaseHistoryContent m_objContent=new clsInPatientCaseHistoryContent();
			
			m_objContent.m_strBeforetimeStatusAll=this.m_txtBeforetimeStatus.Text ;
			m_objContent.m_strBeforetimeStatusXML=this.m_txtBeforetimeStatus.m_strGetXmlText();
			m_objContent.m_strBeforetimeStatus=this.m_txtBeforetimeStatus.m_strGetRightText()  ;

			m_objContent.m_strBreath=this.m_txtBreath.m_strGetRightText() ;
			m_objContent.m_strBreathAll=this.m_txtBreath.Text  ;
			m_objContent.m_strBreathXML=this.m_txtBreath.m_strGetXmlText()  ;
			
			m_objContent.m_strCatameniaHistory=this.m_txtCatameniaHistory.m_strGetRightText() ;
			m_objContent.m_strCatameniaHistoryAll=this.m_txtCatameniaHistory.Text  ;
			m_objContent.m_strCatameniaHistoryXML=this.m_txtCatameniaHistory.m_strGetXmlText()  ;
			
			m_objContent.m_strCredibility=this.m_cboCredibility.Text  ;
			
			m_objContent.m_strCurrentStatus=this.m_txtCurrentStatus.m_strGetRightText()  ;
			m_objContent.m_strCurrentStatusXAll=this.m_txtCurrentStatus.Text   ;
			m_objContent.m_strCurrentStatusXML=this.m_txtCurrentStatus.m_strGetXmlText()  ;
			
			m_objContent.m_strDia=this.m_txtDia.m_strGetRightText()  ;
			m_objContent.m_strDiaAll=this.m_txtDia.Text   ;
			m_objContent.m_strDiaXML=this.m_txtDia.m_strGetXmlText()  ;
			
			m_objContent.m_strFamilyHistory=this.m_txtFamilyHistory.m_strGetRightText()  ;
			m_objContent.m_strFamilyHistoryAll=this.m_txtFamilyHistory.Text   ;
			m_objContent.m_strFamilyHistoryXML=this.m_txtFamilyHistory.m_strGetXmlText()  ;
			
			string strTemp=this.m_txtFinallyDiagnose.m_strGetRightText().Trim().Replace("；",";");
			m_objContent.m_strFinallyDiagnoseArr=strTemp.Split(MDIParent.c_chrSplitChars) ;			
			m_objContent.m_strFinallyDiagnoseAll=this.m_txtFinallyDiagnose.Text   ;
			m_objContent.m_strFinallyDiagnoseXML=this.m_txtFinallyDiagnose.m_strGetXmlText() ;
			
			m_objContent.m_strLabCheck=this.m_txtLabCheck.m_strGetRightText()  ;
			m_objContent.m_strLabCheckAll=this.m_txtLabCheck.Text   ;
			m_objContent.m_strLabCheckXML=this.m_txtLabCheck.m_strGetXmlText()  ;

			m_objContent.m_strMainDescription=this.m_txtMainDescription.m_strGetRightText()  ;
			m_objContent.m_strMainDescriptionAll=this.m_txtMainDescription.Text   ;
			m_objContent.m_strMainDescriptionXML=this.m_txtMainDescription.m_strGetXmlText()  ;
			
			m_objContent.m_strMarriageHistory=this.m_txtMarriageHistory.m_strGetRightText()  ;
			m_objContent.m_strMarriageHistoryAll=this.m_txtMarriageHistory.Text   ;
			m_objContent.m_strMarriageHistoryXML=this.m_txtMarriageHistory.m_strGetXmlText()  ;
			
			m_objContent.m_strMedical=this.m_txtMedical.m_strGetRightText()  ;
			m_objContent.m_strMedicalAll=this.m_txtMedical.Text   ;
			m_objContent.m_strMedicalXML=this.m_txtMedical.m_strGetXmlText()  ;
			
			m_objContent.m_strOwnHistory=this.m_txtOwnHistory.m_strGetRightText()  ;
			m_objContent.m_strOwnHistoryAll=this.m_txtOwnHistory.Text   ;
			m_objContent.m_strOwnHistoryXML=this.m_txtOwnHistory.m_strGetXmlText()  ;
			
			strTemp=this.m_txtPrimaryDiagnose.m_strGetRightText().Trim().Replace("；",";");
			m_objContent.m_strPrimaryDiagnoseArr=strTemp.Split(MDIParent.c_chrSplitChars);
			m_objContent.m_strPrimaryDiagnoseAll=this.m_txtPrimaryDiagnose.Text   ;
			m_objContent.m_strPrimaryDiagnoseXML=this.m_txtPrimaryDiagnose.m_strGetXmlText()  ;
			
			m_objContent.m_strProfessionalCheck=this.m_txtProfessionalCheck.m_strGetRightText()  ;
			m_objContent.m_strProfessionalCheckAll=this.m_txtProfessionalCheck.Text   ;
			m_objContent.m_strProfessionalCheckXML=this.m_txtProfessionalCheck.m_strGetXmlText()  ;
			
			m_objContent.m_strPulse=this.m_txtPulse.m_strGetRightText()  ;
			m_objContent.m_strPulseAll=this.m_txtPulse.Text   ;
			m_objContent.m_strPulseXML=this.m_txtPulse.m_strGetXmlText()  ;
			
			m_objContent.m_strRepresentor=this.m_cboRepresentor.Text  ;
			
			m_objContent.m_strSummary=this.m_txtSummary.m_strGetRightText()  ;
			m_objContent.m_strSummaryAll=this.m_txtSummary.Text   ;
			m_objContent.m_strSummaryXML=this.m_txtSummary.m_strGetXmlText()  ;
			
			m_objContent.m_strSys=this.m_txtSys.m_strGetRightText()  ;
			m_objContent.m_strSysAll=this.m_txtSys.Text   ;
			m_objContent.m_strSysXML=this.m_txtSys.m_strGetXmlText()  ;
			
			m_objContent.m_strTemperature=this.m_txtTemperature.m_strGetRightText()  ;
			m_objContent.m_strTemperatureAll=this.m_txtTemperature.Text   ;
			m_objContent.m_strTemperatureXML=this.m_txtTemperature.m_strGetXmlText()  ;
			
			m_objContent.m_strFinallyDiagnoseDate=this.m_dtpFinallyDiagnoseDate.Text ;
			m_objContent.m_strPrimaryDiagnoseDate=this.m_dtpPrimaryDiagnoseDate.Text ;
			
			m_objContent.m_strPrimaryDiagnoseDocID =(this.m_txtPrimaryDiagnoseDocID .Text=="" ? "":(string)this.m_txtPrimaryDiagnoseDocID.Tag );
			
			m_objContent.m_strFinallyDiagnoseDocID =(m_txtFinallyDiagnoseDocID.Text =="" ? "" : (string)this.m_txtFinallyDiagnoseDocID.Tag); 
 
			m_objContent.m_strCreateName =MDIParent.OperatorName ;
			m_objContent.m_strPrimaryDiagnoseDocName =this.m_txtPrimaryDiagnoseDocID.Text ;
			m_objContent.m_strFinallyDiagnosDocName =this.m_txtFinallyDiagnoseDocID.Text ;
			return m_objContent;
		}

//		public clsPictureBoxValue[] m_objPicValueArr = null;

		protected override clsPictureBoxValue[] m_objGetPicContentFromGUI()
		{			
			return ctlPaintContainer1.m_objGetPicValue();
		}

		// 把特殊记录的值显示到界面上。
		protected override void m_mthSetGUIFromContent(clsInPatientCaseHistoryContent p_objContent,clsPictureBoxValue[] p_objPicValueArr)
		{
//			m_objMedicalExamForm.m_objPicValueArr = p_objPicValueArr;
//			m_objMedicalExamForm.m_mthSetPicValue(p_objPicValueArr);

			ctlPaintContainer1.m_mthSetPicValue(p_objPicValueArr);

			if( p_objContent.m_strInPatientID !=null && p_objContent.m_strInPatientID !="")
			{
				m_strCurrentOpenDate=p_objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

				m_strMedicalExam_ID =m_objMedicalExamDomain.strGetInPatientCaseMedicalExam_ID (p_objContent.m_strInPatientID,p_objContent.m_dtmInPatientDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_objContent.m_dtmOpenDate.ToString ("yyyy-MM-dd HH:mm:ss"));
			}
			else
			{
				m_strMedicalExam_ID ="";
			}
			this.m_txtBreath.m_mthSetNewText(p_objContent.m_strBreathAll, p_objContent.m_strBreathXML);   
			this.m_txtBeforetimeStatus.m_mthSetNewText( p_objContent.m_strBeforetimeStatusAll,p_objContent.m_strBeforetimeStatusXML); 
			this.m_txtCurrentStatus.m_mthSetNewText(p_objContent.m_strCurrentStatusXAll,p_objContent.m_strCurrentStatusXML );
			this.m_txtDia.m_mthSetNewText(p_objContent.m_strDiaAll ,p_objContent.m_strDiaXML );
			this.m_txtFamilyHistory.m_mthSetNewText(p_objContent.m_strFamilyHistoryAll,p_objContent.m_strFamilyHistoryXML  );
			this.m_txtFinallyDiagnose.m_mthSetNewText(p_objContent.m_strFinallyDiagnoseAll,p_objContent.m_strFinallyDiagnoseXML  );
			this.m_txtLabCheck.m_mthSetNewText(p_objContent.m_strLabCheckAll ,p_objContent.m_strLabCheckXML );
			this.m_txtMainDescription.m_mthSetNewText(p_objContent.m_strMainDescriptionAll ,p_objContent.m_strMainDescriptionXML );
			this.m_txtMarriageHistory.m_mthSetNewText(p_objContent.m_strMarriageHistoryAll,p_objContent.m_strMarriageHistoryXML  );
			this.m_txtMedical.m_mthSetNewText(p_objContent.m_strMedicalAll ,p_objContent.m_strMedicalXML );
			this.m_txtOwnHistory.m_mthSetNewText(p_objContent.m_strOwnHistoryAll ,p_objContent.m_strOwnHistoryXML );
			this.m_txtPrimaryDiagnose.m_mthSetNewText(p_objContent.m_strPrimaryDiagnoseAll ,p_objContent.m_strPrimaryDiagnoseXML );
			this.m_txtProfessionalCheck.m_mthSetNewText(p_objContent.m_strProfessionalCheckAll ,p_objContent.m_strProfessionalCheckXML );
			this.m_txtPulse.m_mthSetNewText(p_objContent.m_strPulseAll ,p_objContent.m_strPulseXML );
			this.m_txtSummary.m_mthSetNewText(p_objContent.m_strSummaryAll ,p_objContent.m_strSummaryXML );
			this.m_txtSys.m_mthSetNewText(p_objContent.m_strSysAll ,p_objContent.m_strSysXML );
			this.m_txtTemperature.m_mthSetNewText(p_objContent.m_strTemperatureAll ,p_objContent.m_strTemperatureXML );
			this.m_dtpFinallyDiagnoseDate .Text =(p_objContent.m_strFinallyDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strFinallyDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
			this.m_dtpPrimaryDiagnoseDate .Text =(p_objContent.m_strPrimaryDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strPrimaryDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
			this.m_cboCredibility.Text =p_objContent.m_strCredibility;
			this.m_cboRepresentor.Text =p_objContent.m_strRepresentor;
			this.m_txtCatameniaHistory.m_mthSetNewText(p_objContent.m_strCatameniaHistoryAll ,p_objContent.m_strCatameniaHistoryXML );
			
			clsEmployee []  objPDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_objContent.m_strPrimaryDiagnoseDocID ,m_objCurrentContext.m_ObjDepartment);
			if(objPDoctorArr.Length !=0)
			{
				this.m_txtPrimaryDiagnoseDocID.Text =objPDoctorArr[0].m_StrFirstName; 
				this.m_txtPrimaryDiagnoseDocID.Tag =objPDoctorArr[0].m_StrEmployeeID; 
				p_objContent.m_strPrimaryDiagnoseDocName =objPDoctorArr[0].m_StrFirstName;
			}
			clsEmployee [] objFDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_objContent.m_strFinallyDiagnoseDocID ,m_objCurrentContext.m_ObjDepartment);
			if(objFDoctorArr.Length !=0)
			{
				this.m_txtFinallyDiagnoseDocID.Text =objFDoctorArr[0].m_StrFirstName;
				this.m_txtFinallyDiagnoseDocID.Tag =objFDoctorArr[0].m_StrEmployeeID;
				p_objContent.m_strFinallyDiagnosDocName =objFDoctorArr[0].m_StrFirstName;
			
			}

			if(m_strMedicalExam_ID=="")
			{
				m_objMedicalExamDomain.m_mthClearMedicalExamControls (this.m_objMedicalExamForm );  
			}
			else
				m_objMedicalExamDomain.m_mthDisplayMedicalExamOptions (this.m_objMedicalExamForm ,m_strMedicalExam_ID );

			m_objSignTool.m_mtSetSpecialEmployee(p_objContent.m_strModifyUserID);
		}

		// 获取病程记录的领域层实例
		protected override clsBaseCaseHistoryDomain  m_objGetDomain()
		{

            return new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.InPatientCaseHistory);
		}

		// 把选择时间记录内容重新整理为完全正确的内容。
		protected override void m_mthReAddNewRecord(clsInPatientCaseHistoryContent p_objRecordContent)
		{
		
		}	
		#region 添加键盘快捷键

		private byte m_bytListOnDoctor;
		/// <summary>
		/// 是否处理医生的TextChanged事件
		/// </summary>
		private bool m_blnCanDoctorTextChanged;

//		private bool m_blnCanOperateDoctorSelect;
//
//		private bool m_blnCanChargeDoctorSelect;

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
				if(strTypeName != "TabControl" && strTypeName != "TabPage")
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
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
					//					if(sender.GetType().Name!="ctlRichTextBox")
					//						SendKeys.Send(  "{tab}");
					if(((Control)sender).Name=="m_txtPrimaryDiagnoseDocID")
					{
						m_bytListOnDoctor = 0;
						m_mthGetDoctorList(m_txtPrimaryDiagnoseDocID.Text);

						if(this.m_lsvFinallyDiagnoseDocID .Items.Count==1 && (m_txtPrimaryDiagnoseDocID.Text==m_lsvFinallyDiagnoseDocID.Items[0].SubItems[0].Text|| m_txtPrimaryDiagnoseDocID.Text==m_lsvFinallyDiagnoseDocID.Items[0].SubItems[1].Text))
						{
							m_lsvFinallyDiagnoseDocID.Items[0].Selected=true;
							m_lsvFinallyDiagnoseDocID_DoubleClick(null,null);
							break;
						}
					}
					else if(((Control)sender).Name=="m_txtFinallyDiagnoseDocID")
					{
						m_bytListOnDoctor = 1;
						m_mthGetDoctorList(m_txtFinallyDiagnoseDocID.Text);

						if(m_lsvFinallyDiagnoseDocID.Items.Count==1 && (m_txtFinallyDiagnoseDocID.Text==m_lsvFinallyDiagnoseDocID.Items[0].SubItems[0].Text || m_txtFinallyDiagnoseDocID.Text==m_lsvFinallyDiagnoseDocID.Items[0].SubItems[1].Text))
						{
							m_lsvFinallyDiagnoseDocID.Items[0].Selected=true;
							m_lsvFinallyDiagnoseDocID_DoubleClick(null,null);
							break;
						}
					}
					else if(((Control)sender).Name=="m_lsvFinallyDiagnoseDocID")
					{
						m_lsvFinallyDiagnoseDocID_DoubleClick(null,null);						
					}

					break;

				case 38:
				case 40:
					if(((Control)sender).Name=="m_txtPrimaryDiagnoseDocID")
					{
						if(m_txtPrimaryDiagnoseDocID.Text.Length>0)
						{	
							if(m_lsvFinallyDiagnoseDocID.Visible==false || m_lsvFinallyDiagnoseDocID.Items.Count==0)
							{
								m_bytListOnDoctor = 0;
								m_mthGetDoctorList(m_txtPrimaryDiagnoseDocID.Text);
							}

							m_lsvFinallyDiagnoseDocID.BringToFront();
							m_lsvFinallyDiagnoseDocID.Visible=true;
							m_lsvFinallyDiagnoseDocID.Focus();
							if( m_lsvFinallyDiagnoseDocID.Items.Count>0)
							{
								m_lsvFinallyDiagnoseDocID.Items[0].Selected=true;
								m_lsvFinallyDiagnoseDocID.Items[0].Focused=true;
							}	
						}
					}

					else if(((Control)sender).Name=="m_txtFinallyDiagnoseDocID" )
					{
						if(m_txtFinallyDiagnoseDocID.Text.Length>0)
						{	
							if(m_lsvFinallyDiagnoseDocID.Visible==false || m_lsvFinallyDiagnoseDocID.Items.Count==0)
							{
								m_bytListOnDoctor = 1;
								m_mthGetDoctorList(m_txtFinallyDiagnoseDocID.Text);
								//	m_lsvDoctorList.BringToFront();
								//	m_lsvDoctorList.Visible=true;
							}							
							m_lsvFinallyDiagnoseDocID.Focus();
							if( m_lsvFinallyDiagnoseDocID.Items.Count>0)
							{
								m_lsvFinallyDiagnoseDocID.Items[0].Selected=true;
								m_lsvFinallyDiagnoseDocID.Items[0].Focused=true;
							}	
						}
					}
					
					break;	

				
				case 113://save
					this.m_lngSave(); 
					break;
				case 114://del
					this.m_lngDelete(); 
					break;
				case 115://print
					this.m_lngPrint();
					break;
				case 116://refresh
					m_mthClearAll();
					m_mthClearPatientBaseInfo();
					break;
				case 117://Search					
					break;
			}	
		}

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
			if(!m_blnCanDoctorTextChanged)
				return;

			if(p_strDoctorNameLike.Length == 0)
			{
				m_lsvFinallyDiagnoseDocID.Visible = false;
				return;
			}

			clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

			if(objDoctorArr == null)
			{
				m_lsvFinallyDiagnoseDocID.Visible = false;
				return;
			}

			switch(m_bytListOnDoctor)
			{
				case 0:
					m_lsvFinallyDiagnoseDocID.Left = m_txtPrimaryDiagnoseDocID.Left ;
					m_lsvFinallyDiagnoseDocID.Top  = m_txtPrimaryDiagnoseDocID.Top +m_txtPrimaryDiagnoseDocID.Height ;
					break;
				case 1:
					m_lsvFinallyDiagnoseDocID.Left = m_txtFinallyDiagnoseDocID.Left  ;
					m_lsvFinallyDiagnoseDocID.Top  = m_txtFinallyDiagnoseDocID.Top +m_txtFinallyDiagnoseDocID.Height ;
					break;
			}

			m_lsvFinallyDiagnoseDocID.Items.Clear();

			for(int i=0;i<objDoctorArr.Length;i++)
			{
				ListViewItem lviDoctor = new ListViewItem(
					new string[]{
									objDoctorArr[i].m_StrEmployeeID,
									objDoctorArr[i].m_StrFirstName
								});
				lviDoctor.Tag = objDoctorArr[i];

				m_lsvFinallyDiagnoseDocID.Items.Add(lviDoctor);
			}

			//但显示的行数大于6时，减小最后一列的宽度，以显示滚动条
			m_mthChangeListViewLastColumnWidth(m_lsvFinallyDiagnoseDocID);

			m_lsvFinallyDiagnoseDocID.BringToFront();
			m_lsvFinallyDiagnoseDocID.Visible = true;
		}

		private void m_lsvDoctorList_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
			if(m_lsvFinallyDiagnoseDocID.SelectedItems.Count <= 0)
				return;

			clsEmployee objEmp = (clsEmployee)m_lsvFinallyDiagnoseDocID.SelectedItems[0].Tag;

			if(objEmp == null)
				return;

//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
//				return;

			m_blnCanDoctorTextChanged = false;
			switch(m_bytListOnDoctor)
			{
				case 0:
					m_txtPrimaryDiagnoseDocID.Text = objEmp.m_StrLastName;
					m_txtPrimaryDiagnoseDocID.Tag = objEmp.m_StrEmployeeID;
//					m_blnCanOperateDoctorSelect = true;
					break;
				case 1:
					m_txtFinallyDiagnoseDocID .Text = objEmp.m_StrLastName;
					m_txtFinallyDiagnoseDocID.Tag = objEmp.m_StrEmployeeID;
//					m_blnCanChargeDoctorSelect = true;
					break;
			}
			m_blnCanDoctorTextChanged = true;

			m_lsvFinallyDiagnoseDocID.Visible = false;
		}

		private void m_lsvFinallyDiagnoseDocID_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
			if(m_lsvFinallyDiagnoseDocID.SelectedItems.Count <= 0)
				return;

			clsEmployee objEmp = (clsEmployee)m_lsvFinallyDiagnoseDocID.SelectedItems[0].Tag;

			if(objEmp == null)
				return;

//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
//				return;

			m_blnCanDoctorTextChanged = false;
			switch(m_bytListOnDoctor)
			{
				case 0:
					m_txtPrimaryDiagnoseDocID.Text = objEmp.m_StrLastName;
					m_txtPrimaryDiagnoseDocID.Tag = (string)objEmp.m_StrEmployeeID;
//					m_blnCanOperateDoctorSelect = true;
					break;
				case 1:
					m_txtFinallyDiagnoseDocID.Text = objEmp.m_StrLastName;
					m_txtFinallyDiagnoseDocID.Tag =(string)objEmp.m_StrEmployeeID;
//					m_blnCanChargeDoctorSelect = true;
					break;
			}
			m_blnCanDoctorTextChanged = true;

			m_lsvFinallyDiagnoseDocID.Visible = false;
		}

		#endregion

		private void frmInPatientCaseHistory_Load(object sender, System.EventArgs e)
		{
			TreeNode tndInPatientDate=new TreeNode();
			tndInPatientDate.Text ="入院日期";
			this.trvTime.Nodes.Add(tndInPatientDate); 
			m_mthSetQuickKeys();

			this.m_dtpCreateDate.m_EnmVisibleFlag= MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtMainDescription.Focus();
		}

		
		private void m_txtMedical_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		}

		private void m_mthShowMedicalExam(frmMedicalExam001 p_frmMedicalExam)
		{
			p_frmMedicalExam.m_EvtHide += new EventHandler(m_mthMedicalExamHide);

			p_frmMedicalExam.TopMost = true;
			p_frmMedicalExam.Show();
		}

		private void m_mthMedicalExamHide(object sender,EventArgs e)
		{
			frmMedicalExam001 frmMedicalExam = (frmMedicalExam001)sender;
			if(frmMedicalExam.m_blnIsOK )
			{
				m_txtMedical.m_mthClearText();
				m_txtMedical.m_mthInsertText(m_objMedicalExamDomain.m_strGetMedicalExamUnitString (frmMedicalExam),0);
				//体格检查窗体上按确定后，提取画图信息
//				m_objPicValueArr = frmMedicalExam.m_objPicValueArr;
			}
		}

		/// <summary>
		///保存体格检查
		/// </summary>
		/// <param name="p_objNewContent"></param>
		/// <returns></returns>
		protected override long m_lngSubAddNewRecordAfterMain(iCareData.clsInPatientCaseHistoryContent p_objNewContent)
		{
			clsMedicalExamInHospital_TargetValue objMedicalExamInHopital=new clsMedicalExamInHospital_TargetValue ();
			objMedicalExamInHopital.m_strInPatientDate =p_objNewContent.m_dtmInPatientDate.ToString ("yyyy-MM-dd HH:mm:ss");
			objMedicalExamInHopital.m_strInPatientID =p_objNewContent.m_strInPatientID ;
			objMedicalExamInHopital.m_strItemID = "1";
			objMedicalExamInHopital.m_strMedicalExam_ID ="";
			objMedicalExamInHopital.m_strModifyDate =p_objNewContent.m_dtmModifyDate.ToString ("yyyy-MM-dd HH:mm:ss");
			objMedicalExamInHopital.m_strOpenDate =p_objNewContent.m_dtmOpenDate.ToString ("yyyy-MM-dd HH:mm:ss"); 
			m_objMedicalExamDomain.m_mthSaveMedicalExamRecord (this.m_objMedicalExamForm,"001",objMedicalExamInHopital);
			return 1;
		}

		protected override long m_lngSubModifyRecordAfterMain(iCareData.clsInPatientCaseHistoryContent p_objNewContent)
		{
			clsMedicalExamInHospital_TargetValue objMedicalExamInHopital=new clsMedicalExamInHospital_TargetValue ();
			objMedicalExamInHopital.m_strInPatientDate =p_objNewContent.m_dtmInPatientDate.ToString ("yyyy-MM-dd HH:mm:ss");
			objMedicalExamInHopital.m_strInPatientID =p_objNewContent.m_strInPatientID ;
			objMedicalExamInHopital.m_strItemID = "1";
			objMedicalExamInHopital.m_strMedicalExam_ID =m_strMedicalExam_ID.Trim () ;
			objMedicalExamInHopital.m_strModifyDate =p_objNewContent.m_dtmModifyDate.ToString ("yyyy-MM-dd HH:mm:ss");
			objMedicalExamInHopital.m_strOpenDate =p_objNewContent.m_dtmOpenDate.ToString ("yyyy-MM-dd HH:mm:ss"); 
			m_objMedicalExamDomain.m_mthSaveMedicalExamRecord (this.m_objMedicalExamForm,"001",objMedicalExamInHopital);
			return 1;
		}	
	
		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			clsInPatientCaseHistoryContent p_objContent=new clsInPatientCaseHistoryContent();
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue)
			{
				m_strMedicalExam_ID ="";
				m_objMedicalExamDomain.m_mthClearMedicalExamControls (this.m_objMedicalExamForm );  
				return ;
			}
		
			long lngRes=m_objGetDomain().m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString ("yyyy-MM-dd HH:mm:ss"),out p_objContent);
			if(lngRes<=0 || p_objContent==null)
			{
				switch(lngRes)
				{
					case (long)(iCareData.enmOperationResult.Not_permission) :
						m_mthShowNotPermitted();break;
					case (long)(iCareData.enmOperationResult.DB_Fail) :
						m_mthShowDBError();break;
				}
				return;
			}
			m_strMedicalExam_ID =m_objMedicalExamDomain.strGetInPatientCaseMedicalExam_ID (m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString ("yyyy-MM-dd HH:mm:ss"));
			m_objMedicalExamDomain.m_mthDisplayMedicalExamOptions (this.m_objMedicalExamForm ,m_strMedicalExam_ID );
						
			this.m_txtBreath.Text=p_objContent.m_strBreath;   
			this.m_txtBeforetimeStatus.Text= p_objContent.m_strBeforetimeStatus; 
			this.m_txtCurrentStatus.Text=p_objContent.m_strCurrentStatus;
			this.m_txtDia.Text=p_objContent.m_strDia;
			this.m_txtFamilyHistory.Text=p_objContent.m_strFamilyHistory;
			this.m_txtFinallyDiagnose.Text= com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText( p_objContent.m_strFinallyDiagnoseAll,p_objContent.m_strFinallyDiagnoseXML);
			this.m_txtLabCheck.Text=p_objContent.m_strLabCheck;
			this.m_txtMainDescription.Text=p_objContent.m_strMainDescription;
			this.m_txtMarriageHistory.Text=p_objContent.m_strMarriageHistory;
			this.m_txtMedical.Text=p_objContent.m_strMedical;
			this.m_txtOwnHistory.Text=p_objContent.m_strOwnHistory;
			this.m_txtPrimaryDiagnose.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(p_objContent.m_strPrimaryDiagnoseAll ,p_objContent.m_strPrimaryDiagnoseXML );
			this.m_txtProfessionalCheck.Text=p_objContent.m_strProfessionalCheck;
			this.m_txtPulse.Text=p_objContent.m_strPulse;
			this.m_txtSummary.Text=p_objContent.m_strSummary;
			this.m_txtSys.Text=p_objContent.m_strSys;
			this.m_txtTemperature.Text=p_objContent.m_strTemperature;
			this.m_dtpFinallyDiagnoseDate .Text =(p_objContent.m_strFinallyDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strFinallyDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
			this.m_dtpPrimaryDiagnoseDate .Text =(p_objContent.m_strPrimaryDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strPrimaryDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
			this.m_cboCredibility.Text =p_objContent.m_strCredibility;
			this.m_cboRepresentor.Text =p_objContent.m_strRepresentor;
			this.m_txtCatameniaHistory.Text=p_objContent.m_strCatameniaHistory;
			//医生签名不需要				
		}

		/// <summary>
		/// 窗体ID，只针对允许作废重做的窗体
		/// </summary>		
		public override int m_IntFormID
		{
			get
			{
				return 20;
			}
		}

		#region 审核
		private string m_strCurrentOpenDate = "";
		protected override string m_StrCurrentOpenDate
		{
			get
			{
//				if(m_strCurrentOpenDate=="")
//				{
//					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
//					return "";
//				}
//				return m_strCurrentOpenDate;
					
				if(this.trvTime.SelectedNode==null || this.trvTime.SelectedNode.Tag==null)
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
					return "";
				}
				return (string)this.trvTime.SelectedNode.Tag;

			}
		}

		protected override bool m_BlnCanApprove
		{
			get
			{
				return true;
			}
		}		
		#endregion 
        
		private void m_cmdGetDovueData_Click(object sender, System.EventArgs e)
		{
			if(m_objBaseCurrentPatient==null)return;

			this.m_txtTemperature.Text="";
			this.m_txtPulse.Text="";
			this.m_txtBreath.Text="";
			this.m_txtSys.Text="";
			this.m_txtDia.Text="";

			clsTrendDomain objDomain=new clsTrendDomain();
			string[] strEMFC_IDArr=new string[]{"100","40","92","89","90"};//体温，脉搏，呼吸，收缩压，舒张压
			string[] strResultArr;
			long lngRes=objDomain.m_lngGetDocvueResultArr(this.m_objBaseCurrentPatient.m_StrInPatientID,this.m_objBaseCurrentPatient.m_DtmLastInDate,strEMFC_IDArr,m_dtpCreateDate.Value,out strResultArr);
			if(lngRes<=0)
			{
				switch(lngRes)
				{
					case (long)(iCareData.enmOperationResult.Not_permission) :
						m_mthShowNotPermitted();break;
					case (long)(iCareData.enmOperationResult.DB_Fail) :
						m_mthShowDBError();break;
				}
			}
			else 
			{
				this.m_txtTemperature.Text=strResultArr[0];
				this.m_txtPulse.Text=strResultArr[1];
				this.m_txtBreath.Text=strResultArr[2];
				this.m_txtSys.Text=strResultArr[3];
				this.m_txtDia.Text=strResultArr[4];				
			}
		}

		private void m_cboRepresentor_DropDown(object sender, System.EventArgs e)
		{
			m_cboRepresentor.ClearItem();

			clsCommonUseValue[] objclsCommonUseValue=null;

			new clsCommonUseDomain().m_lngGetAllCommonUseValue(((int)enmCommonUseValue.InPatientCaseHistory_Representor).ToString(),out objclsCommonUseValue);
			if(objclsCommonUseValue!=null && objclsCommonUseValue.Length>0)
			{
				for(int i=0;i<objclsCommonUseValue.Length;i++)
				{
					m_cboRepresentor.AddItem(objclsCommonUseValue[i].m_strCommonUseValue);
				}
			}
		}

		private void m_cboCredibility_DropDown(object sender, System.EventArgs e)
		{
			m_cboCredibility.ClearItem();

			clsCommonUseValue[] objclsCommonUseValue=null;

			new clsCommonUseDomain().m_lngGetAllCommonUseValue(((int)enmCommonUseValue.InPatientCaseHistory_Credibility).ToString(),out objclsCommonUseValue);
			if(objclsCommonUseValue!=null && objclsCommonUseValue.Length>0)
			{
				for(int i=0;i<objclsCommonUseValue.Length;i++)
				{
					m_cboCredibility.AddItem(objclsCommonUseValue[i].m_strCommonUseValue);
				}
			}
		}

		private clsThreeMeasureShareDomain m_objShareDomain = new clsThreeMeasureShareDomain();

		protected override void m_mthSetNewRecord()
		{
			if(m_objCurrentPatient != null)
			{				
				//签名默认值
				clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtPrimaryDiagnoseDocID);
				clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtFinallyDiagnoseDocID);

				//默认值
				new clsDefaultValueTool(this).m_mthSetDefaultValue();
				new clsDefaultValueTool(m_objMedicalExamForm).m_mthSetDefaultValue();

				clsThreeMeasureShareDomain.stuFirstValue stuValue;
				long lngRes = m_objShareDomain.m_lngGetFirstValue(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),out stuValue);

				if(lngRes > 0)
				{
					m_txtTemperature.Text = stuValue.m_strTemperatureValue;
					m_txtPulse.Text = stuValue.m_strPulseValue;
					m_txtBreath.Text = stuValue.m_strBreathValue;

					if(stuValue.m_strSystolicValue != "")
					{
						m_txtSys.Text = stuValue.m_strSystolicValue;
						m_txtDia.Text = stuValue.m_strDiastolicValue;
					}
					else
					{
						m_txtSys.Text = stuValue.m_strSystolicValue2;
						m_txtDia.Text = stuValue.m_strDiastolicValue2;
					}
				}
			}
		}
	}
	
}

