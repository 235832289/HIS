using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using iCareData;
//using System.Windows.Forms;
using com.digitalwave.Utility .Controls ;
using HRP;
using System.Xml;
using System.IO;
using System.Text;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
    /// 病人入院评估表
	/// </summary>
	public class frmEMR_InPatientEvaluate : iCare.frmHRPBaseForm,PublicFunction
	{
		#region 控件
		private System.Windows.Forms.TreeView m_trvTime;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblFolk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblJob;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblNativePlace;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private com.digitalwave.controls.ctlRichTextBox m_txtInPatientDiagnose;
		private System.Windows.Forms.Label lblTitle5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbWalk;
		private System.Windows.Forms.RadioButton rdbHand;
		private System.Windows.Forms.RadioButton rdbWheel;
		private System.Windows.Forms.RadioButton rdbFlat;
		private System.Windows.Forms.RadioButton rdbBack;
		private System.Windows.Forms.RadioButton rdbArm;
		private com.digitalwave.controls.ctlRichTextBox m_txtCaseHistory;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private com.digitalwave.controls.ctlRichTextBox m_txtFamilyHistory;
		private System.Windows.Forms.GroupBox groupBox2;
		private com.digitalwave.controls.ctlRichTextBox m_txtChiefComplain;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox chkSensitive0;
		private System.Windows.Forms.CheckBox chkSensitive1;
		private System.Windows.Forms.CheckBox chkSensitive2;
		private System.Windows.Forms.CheckBox chkSensitive3;
		private com.digitalwave.controls.ctlRichTextBox m_txtSensitiveOther;
		private System.Windows.Forms.TextBox m_txtTemperature;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox m_txtPulse;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox m_txtRhythm;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox m_txtBp_Shink;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox m_txtBp_Extend;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox m_txtAvoirdupois;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox chkConsciousness0;
		private System.Windows.Forms.CheckBox chkConsciousness1;
		private System.Windows.Forms.CheckBox chkConsciousness3;
		private System.Windows.Forms.CheckBox chkConsciousness4;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox16;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.GroupBox groupBox18;
		private System.Windows.Forms.GroupBox groupBox19;
		private System.Windows.Forms.GroupBox groupBox20;
		private System.Windows.Forms.GroupBox groupBox21;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.GroupBox groupBox22;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.GroupBox groupBox23;
		private System.Windows.Forms.GroupBox groupBox24;
		private System.Windows.Forms.GroupBox groupBox25;
		private System.Windows.Forms.GroupBox groupBox26;
		private System.Windows.Forms.GroupBox groupBox28;
		private System.Windows.Forms.GroupBox groupBox29;
		private PinkieControls.ButtonXP m_cmdSign;
		private TextBox m_txtSign;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.CheckBox chkLimbsactivity0;
		private System.Windows.Forms.CheckBox chkLimbsactivity1;
		private System.Windows.Forms.CheckBox chkLimbsactivity2;
		private System.Windows.Forms.CheckBox chkLimbsactivity3;
		private System.Windows.Forms.CheckBox chkLimbsactivity4;
		private System.Windows.Forms.CheckBox chkLimbsactivity5;
		private System.Windows.Forms.CheckBox chkLimbsactivity6;
		private com.digitalwave.controls.ctlRichTextBox m_txtLimbsactivityOther;
		private System.Windows.Forms.CheckBox chkSkin0;
		private System.Windows.Forms.CheckBox chkSkin1;
		private System.Windows.Forms.CheckBox chkSkin2;
		private System.Windows.Forms.CheckBox chkSkin3;
		private System.Windows.Forms.CheckBox chkSkin4;
		private System.Windows.Forms.CheckBox chkSkin5;
		private System.Windows.Forms.CheckBox chkSkin6;
		private System.Windows.Forms.CheckBox chkSkin7;
		private System.Windows.Forms.CheckBox chkSkin8;
		private com.digitalwave.controls.ctlRichTextBox m_txtSkinOther;
		private System.Windows.Forms.CheckBox chkEmotion0;
		private System.Windows.Forms.CheckBox chkEmotion1;
		private System.Windows.Forms.CheckBox chkEmotion2;
		private System.Windows.Forms.CheckBox chkPhysique0;
		private System.Windows.Forms.CheckBox chkPhysique1;
		private System.Windows.Forms.CheckBox chkPhysique2;
		private com.digitalwave.controls.ctlRichTextBox m_txtPhysiqueOther;
		private System.Windows.Forms.CheckBox chkComplexion0;
		private System.Windows.Forms.CheckBox chkComplexion1;
		private System.Windows.Forms.CheckBox chkComplexion2;
		private System.Windows.Forms.CheckBox chkComplexion3;
		private System.Windows.Forms.CheckBox chkFamilyForm0;
		private System.Windows.Forms.CheckBox chkFamilyForm1;
		private System.Windows.Forms.CheckBox chkFamilyForm2;
		private System.Windows.Forms.CheckBox chkFamilyForm3;
		private com.digitalwave.controls.ctlRichTextBox m_txtFamilyFormOther;
		private System.Windows.Forms.CheckBox chkInHospitalWorry0;
		private System.Windows.Forms.CheckBox chkInHospitalWorry1;
		private System.Windows.Forms.CheckBox chkInHospitalWorry2;
		private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalWorryOther;
		private System.Windows.Forms.CheckBox chkFeeling0;
		private System.Windows.Forms.CheckBox chkFeeling1;
		private System.Windows.Forms.CheckBox chkFeeling2;
		private System.Windows.Forms.CheckBox chkFeeling3;
		private System.Windows.Forms.CheckBox chkFeeling4;
		private System.Windows.Forms.CheckBox chkFeeling5;
		private System.Windows.Forms.CheckBox chkFeeling6;
		private System.Windows.Forms.CheckBox chkFeeling7;
		private System.Windows.Forms.CheckBox chkFeeling8;
		private System.Windows.Forms.CheckBox chkJob6;
		private System.Windows.Forms.CheckBox chkJob0;
		private System.Windows.Forms.CheckBox chkJob1;
		private System.Windows.Forms.CheckBox chkJob2;
		private System.Windows.Forms.CheckBox chkJob3;
		private System.Windows.Forms.CheckBox chkJob4;
		private System.Windows.Forms.CheckBox chkJob5;
		private System.Windows.Forms.CheckBox chkSelfSolve0;
		private System.Windows.Forms.CheckBox chkSelfSolve1;
		private System.Windows.Forms.CheckBox chkSelfSolve2;
		private System.Windows.Forms.CheckBox chkHobby0;
		private System.Windows.Forms.CheckBox chkHobby1;
		private System.Windows.Forms.CheckBox chkHobby2;
		private System.Windows.Forms.CheckBox chkHobby3;
		private System.Windows.Forms.CheckBox chkHobby4;
		private com.digitalwave.controls.ctlRichTextBox m_txtHobbyOther;
		private System.Windows.Forms.CheckBox chkPee0;
		private System.Windows.Forms.CheckBox chkPee1;
		private System.Windows.Forms.CheckBox chkPee2;
		private System.Windows.Forms.CheckBox chkPee3;
		private System.Windows.Forms.CheckBox chkPee4;
		private System.Windows.Forms.CheckBox chkPee5;
		private System.Windows.Forms.CheckBox chkPee6;
		private System.Windows.Forms.CheckBox chkPee7;
		private System.Windows.Forms.CheckBox chkPee8;
		private System.Windows.Forms.CheckBox chkPee9;
		private com.digitalwave.controls.ctlRichTextBox m_txtStoolOther;
		private System.Windows.Forms.TextBox m_txtAstrictionDays;
		private System.Windows.Forms.TextBox m_txtAstrictionTimes;
		private System.Windows.Forms.CheckBox chkStool;
		private System.Windows.Forms.TextBox m_txtDiarrheaDays;
		private System.Windows.Forms.TextBox m_txtDiarrheaTimes;
		private System.Windows.Forms.CheckBox chkSleep1;
		private System.Windows.Forms.CheckBox chkSleep3;
		private System.Windows.Forms.CheckBox chkSleep0;
		private System.Windows.Forms.CheckBox chkSleep2;
		private System.Windows.Forms.CheckBox chkSleep4;
		private System.Windows.Forms.CheckBox chkAppetite2;
		private System.Windows.Forms.CheckBox chkAppetite3;
		private System.Windows.Forms.CheckBox chkAppetite4;
		private System.Windows.Forms.CheckBox chkAppetite5;
		private System.Windows.Forms.CheckBox chkAppetite0;
		private System.Windows.Forms.CheckBox chkAppetite1;
		private System.Windows.Forms.CheckBox chkBiteSup0;
		private System.Windows.Forms.CheckBox chkBiteSup1;
		private System.Windows.Forms.CheckBox chkBiteSup2;
		private System.Windows.Forms.CheckBox chkBiteSup3;
		private System.Windows.Forms.CheckBox chkBiteSup4;
		private System.Windows.Forms.CheckBox chkBiteSup6;
		private System.Windows.Forms.CheckBox chkBiteSup7;
		private System.Windows.Forms.CheckBox chkBiteSup8;
		private System.Windows.Forms.CheckBox chkBiteSup9;
		private System.Windows.Forms.CheckBox chkBiteSup10;
		private com.digitalwave.controls.ctlRichTextBox m_txtSpecilizedCheck;
		private System.Windows.Forms.CheckBox chkKnowDisease0;
		private System.Windows.Forms.CheckBox chkKnowDisease1;
		private System.Windows.Forms.CheckBox chkKnowDisease2;
		private System.Windows.Forms.CheckBox chkKnowDisease3;
		private System.Windows.Forms.CheckBox chkHealthNeed0;
		private System.Windows.Forms.CheckBox chkHealthNeed1;
		private System.Windows.Forms.CheckBox chkHealthNeed2;
		private System.Windows.Forms.CheckBox chkHealthNeed3;
		private System.Windows.Forms.CheckBox chkHealthNeed4;
		private System.Windows.Forms.GroupBox grpPip;
		private com.digitalwave.controls.ctlRichTextBox m_txtPipInstance;
		private com.digitalwave.controls.ctlRichTextBox m_txtWoodInstance;
		private com.digitalwave.controls.ctlRichTextBox m_txtTendPlan;
		private clsEMR_InPatientEvaluateDomain m_objDomain;
		private System.Windows.Forms.CheckBox chkInsure;
		private System.Windows.Forms.CheckBox chkSelfPay;
		private System.Windows.Forms.CheckBox chkConsciousness2;
		private System.Windows.Forms.Label lblRecordTimeTitle;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpRecordTime;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.GroupBox groupBox27;
		private System.Windows.Forms.GroupBox groupBox30;
		private System.Windows.Forms.GroupBox groupBox31;
		private System.Windows.Forms.GroupBox groupBox32;
		private System.Windows.Forms.GroupBox groupBox33;
		private System.Windows.Forms.GroupBox groupBox34;
		private System.Windows.Forms.GroupBox groupBox35;
		private System.Windows.Forms.GroupBox groupBox36;
		private System.Windows.Forms.GroupBox groupBox37;
		private System.Windows.Forms.GroupBox groupBox38;
		private System.Windows.Forms.GroupBox groupBox39;
		private PinkieControls.ButtonXP m_cmdChargeNurse;
		private TextBox m_txtNurseSign;
		private PinkieControls.ButtonXP m_cmdNurseSign;
		private TextBox m_txtChargeNurse;
		private System.Windows.Forms.CheckBox chkSpecialtiesCoach0;
		private System.Windows.Forms.CheckBox chkSpecialtiesCoach1;
		private com.digitalwave.controls.ctlRichTextBox m_txtSpecialtiesCoach;
		private System.Windows.Forms.CheckBox chkAdviceDrug0;
		private System.Windows.Forms.CheckBox chkAdviceDrug1;
		private System.Windows.Forms.CheckBox chkAdviceDrug2;
		private System.Windows.Forms.CheckBox chkAdviceDrug3;
		private System.Windows.Forms.CheckBox chkCommonlyCoach0;
		private System.Windows.Forms.CheckBox chkCommonlyCoach1;
		private System.Windows.Forms.CheckBox chkCommonlyCoach2;
		private System.Windows.Forms.CheckBox chkCommonlyCoach3;
		private System.Windows.Forms.CheckBox chkCommonlyCoach4;
		private System.Windows.Forms.CheckBox chkCommonlyCoach5;
		private System.Windows.Forms.CheckBox chkCommonlyCoach6;
		private System.Windows.Forms.CheckBox chkCommonlyCoach7;
		private com.digitalwave.controls.ctlRichTextBox m_txtNurseIssue;
		private System.Windows.Forms.CheckBox chkNurseIssue0;
		private System.Windows.Forms.CheckBox chkNurseIssue1;
		private com.digitalwave.controls.ctlRichTextBox m_txtNurseSyndrome;
		private System.Windows.Forms.CheckBox chkNurseSyndrome0;
		private System.Windows.Forms.CheckBox chkNurseSyndrome1;
		private System.Windows.Forms.CheckBox chkOutHospitalMode0;
		private System.Windows.Forms.CheckBox chkOutHospitalMode1;
		private System.Windows.Forms.CheckBox chkOutHospitalMode2;
		private System.Windows.Forms.CheckBox chkOutHospitalMode3;
		private System.Windows.Forms.CheckBox chkOutHospitalMode4;
		private System.Windows.Forms.CheckBox chkDieteticCircs0;
		private System.Windows.Forms.CheckBox chkDieteticCircs1;
		private System.Windows.Forms.CheckBox chkDieteticCircs2;
		private System.Windows.Forms.CheckBox chkDieteticCircs3;
		private System.Windows.Forms.CheckBox chkDieteticCircs4;
		private System.Windows.Forms.CheckBox chkDieteticCircs5;
		private System.Windows.Forms.CheckBox chkDieteticCircs6;
		private System.Windows.Forms.CheckBox chkLiveAbility0;
		private System.Windows.Forms.CheckBox chkLiveAbility1;
		private System.Windows.Forms.CheckBox chkLiveAbility2;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutHospitalDiagnose;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReadOutEdu1;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReadOutDate1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReadOutEdu2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReadOutDate2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReadOutEdu3;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReadOutDate3;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExplanEdu1;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExplanDate1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExplanEdu2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExplanDate2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExplanEdu3;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExplanDate3;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMedicineEdu1;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMedicineDate1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMedicineEdu2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMedicineDate2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMedicineEdu3;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMedicineDate3;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNoticeEdu1;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNoticeDate1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNoticeEdu2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNoticeDate2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNoticeEdu3;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNoticeDate3;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtKnowledgeDate1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtKnowledgeEdu2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtKnowledgeDate2;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtKnowledgeEdu3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtKnowledgeDate3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtKnowledgeEdu1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtGuidanceEdu1;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtGuidanceDate3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtGuidanceEdu3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtGuidanceDate2;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtGuidanceEdu2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtGuidanceDate1;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOtherDate1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOtherEdu2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOtherDate2;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOtherEdu3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOtherDate3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOtherEdu1;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label lblInHospitalDays;
        private com.digitalwave.Utility.Controls.ctlTimePicker dtpEduTime;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label lblAddress;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        internal ctlComboBox m_cboEducation;
        private Label label53;
        private Label label54;
        private TextBox m_txtshengao;
        private Label label55;
        private clsEmrSignToolCollection m_objSign;
        private TextBox m_txtReadOutNurse1;
        private Button m_cmdNurseSign11;
        private ctlTimePicker dtpNurseSignDate11;
        private Button m_cmdNurseSign12;
        private ctlTimePicker dtpNurseSignDate12;
        private Button m_cmdNurseSign53;
        private Button m_cmdNurseSign43;
        private Button m_cmdNurseSign33;
        private Button m_cmdNurseSign23;
        private Button m_cmdNurseSign13;
        private Button m_cmdNurseSign52;
        private Button m_cmdNurseSign42;
        private Button m_cmdNurseSign32;
        private Button m_cmdNurseSign22;
        private Button m_cmdNurseSign51;
        private Button m_cmdNurseSign41;
        private Button m_cmdNurseSign31;
        private Button m_cmdNurseSign21;
        private ctlTimePicker dtpNurseSignDate53;
        private ctlTimePicker dtpNurseSignDate43;
        private ctlTimePicker dtpNurseSignDate33;
        private ctlTimePicker dtpNurseSignDate52;
        private ctlTimePicker dtpNurseSignDate42;
        private ctlTimePicker dtpNurseSignDate23;
        private ctlTimePicker dtpNurseSignDate32;
        private ctlTimePicker dtpNurseSignDate13;
        private ctlTimePicker dtpNurseSignDate22;
        private ctlTimePicker dtpNurseSignDate51;
        private ctlTimePicker dtpNurseSignDate41;
        private ctlTimePicker dtpNurseSignDate31;
        private ctlTimePicker dtpNurseSignDate21;
        private Button m_cmdNurseSign73;
        private Button m_cmdNurseSign63;
        private Button m_cmdNurseSign72;
        private Button m_cmdNurseSign62;
        private Button m_cmdNurseSign71;
        private Button m_cmdNurseSign61;
        private ctlTimePicker dtpNurseSignDate73;
        private ctlTimePicker dtpNurseSignDate63;
        private ctlTimePicker dtpNurseSignDate72;
        private ctlTimePicker dtpNurseSignDate62;
        private ctlTimePicker dtpNurseSignDate71;
        private ctlTimePicker dtpNurseSignDate61;
        private TextBox m_txtReadOutNurse3;
        private TextBox m_txtReadOutNurse2;
        private TextBox m_txtExplanNurse3;
        private TextBox m_txtExplanNurse2;
        private TextBox m_txtMedicineNurse3;
        private TextBox m_txtMedicineNurse2;
        private TextBox m_txtNoticeNurse3;
        private TextBox m_txtNoticeNurse2;
        private TextBox m_txtKnowledgeNurse3;
        private TextBox m_txtKnowledgeNurse2;
        private TextBox m_txtGuidanceNurse3;
        private TextBox m_txtGuidanceNurse2;
        private TextBox m_txtOtherNurse3;
        private TextBox m_txtOtherNurse2;
        private TextBox m_txtOtherNurse1;
        private TextBox m_txtGuidanceNurse1;
        private TextBox m_txtKnowledgeNurse1;
        private TextBox m_txtNoticeNurse1;
        private TextBox m_txtMedicineNurse1;
        private TextBox m_txtExplanNurse1;
        private clsInHospitalMainRecordDomain m_objDomain1;
		public frmEMR_InPatientEvaluate()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, m_txtSign, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign, m_txtNurseSign, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdChargeNurse, m_txtChargeNurse, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //1
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign11, m_txtReadOutNurse1, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign12, m_txtReadOutNurse2, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign13, m_txtReadOutNurse3, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //2
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign21, m_txtExplanNurse1, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign22, m_txtExplanNurse2, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign23, m_txtExplanNurse3, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //3
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign31, m_txtMedicineNurse1, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign32, m_txtMedicineNurse2, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign33, m_txtMedicineNurse3, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //4
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign41, m_txtNoticeNurse1, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign42, m_txtNoticeNurse2, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign43, m_txtNoticeNurse3, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //5
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign51, m_txtKnowledgeNurse1, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign52, m_txtKnowledgeNurse2, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign53, m_txtKnowledgeNurse3, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //6
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign61, m_txtGuidanceNurse1, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign62, m_txtGuidanceNurse2, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign63, m_txtGuidanceNurse3, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //7
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign71, m_txtOtherNurse1, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign72, m_txtOtherNurse2, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNurseSign73, m_txtOtherNurse3, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
			tabControl1.TabPages.Clear();
			tabControl1.TabPages.AddRange(new TabPage[]{tabPage1,tabPage2,tabPage3,tabPage4,tabPage5});

			m_mthSetRichTextBoxAttribInControl(this);
			InitializeCnmEdu();

			m_objDomain = new clsEMR_InPatientEvaluateDomain();
            m_objDomain1 = new clsInHospitalMainRecordDomain();
			m_objIPE = new clsEMR_InPatientEvaluate();
			m_objIPH = new clsEMR_InPatientHealth_VO();
			m_objIPO = new clsEMR_InPatientOutEvaluate_VO();
		}

		private bool blnCanSearch = true; 

		private bool blnCanDelete = true;

		private bool m_blnFormReadOnly = false;

        private string aaa = "";

		string strInPatientID = "";
		string strInPatientDate = "";

		private clsEMR_InPatientEvaluate m_objIPE = null; //保存当前的申请单
		private clsEMR_InPatientHealth_VO m_objIPH = null;
		private clsEMR_InPatientOutEvaluate_VO m_objIPO = null;
		private clsPatient m_objCurrentPatient = null;  //保存当前的病人
		private clsEMR_InPatientEvaluatePrintTool objPrintTool;
		private ContextMenu cnmEduMnu ;

		private clsEMR_InPatientEvaluate_All m_objCurrent_clsInPatientEvaluate_All;
        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;

		private static MemoryStream m_objXmlMemStream = new MemoryStream(300);
		private XmlParserContext m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Default);
		private XmlTextWriter m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Default);

		public override int m_IntFormID
		{
			get
			{
				return 52;
			}
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("入院时间");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMR_InPatientEvaluate));
            this.m_trvTime = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFolk = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNativePlace = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkSelfPay = new System.Windows.Forms.CheckBox();
            this.chkInsure = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.m_txtshengao = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.chkLimbsactivity0 = new System.Windows.Forms.CheckBox();
            this.chkLimbsactivity1 = new System.Windows.Forms.CheckBox();
            this.chkLimbsactivity2 = new System.Windows.Forms.CheckBox();
            this.chkLimbsactivity3 = new System.Windows.Forms.CheckBox();
            this.chkLimbsactivity4 = new System.Windows.Forms.CheckBox();
            this.chkLimbsactivity5 = new System.Windows.Forms.CheckBox();
            this.chkLimbsactivity6 = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtLimbsactivityOther = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkSkin0 = new System.Windows.Forms.CheckBox();
            this.chkSkin1 = new System.Windows.Forms.CheckBox();
            this.chkSkin2 = new System.Windows.Forms.CheckBox();
            this.chkSkin3 = new System.Windows.Forms.CheckBox();
            this.chkSkin4 = new System.Windows.Forms.CheckBox();
            this.chkSkin5 = new System.Windows.Forms.CheckBox();
            this.chkSkin6 = new System.Windows.Forms.CheckBox();
            this.chkSkin7 = new System.Windows.Forms.CheckBox();
            this.chkSkin8 = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtSkinOther = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkEmotion0 = new System.Windows.Forms.CheckBox();
            this.chkEmotion1 = new System.Windows.Forms.CheckBox();
            this.chkEmotion2 = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkPhysique0 = new System.Windows.Forms.CheckBox();
            this.chkPhysique1 = new System.Windows.Forms.CheckBox();
            this.chkPhysique2 = new System.Windows.Forms.CheckBox();
            this.m_txtPhysiqueOther = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkComplexion0 = new System.Windows.Forms.CheckBox();
            this.chkComplexion1 = new System.Windows.Forms.CheckBox();
            this.chkComplexion2 = new System.Windows.Forms.CheckBox();
            this.chkComplexion3 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkConsciousness0 = new System.Windows.Forms.CheckBox();
            this.chkConsciousness1 = new System.Windows.Forms.CheckBox();
            this.chkConsciousness2 = new System.Windows.Forms.CheckBox();
            this.chkConsciousness3 = new System.Windows.Forms.CheckBox();
            this.chkConsciousness4 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtTemperature = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtPulse = new System.Windows.Forms.TextBox();
            this.m_txtRhythm = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtBp_Shink = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtBp_Extend = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtAvoirdupois = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSensitive0 = new System.Windows.Forms.CheckBox();
            this.chkSensitive1 = new System.Windows.Forms.CheckBox();
            this.chkSensitive2 = new System.Windows.Forms.CheckBox();
            this.chkSensitive3 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtSensitiveOther = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtChiefComplain = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtInPatientDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTitle5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbWalk = new System.Windows.Forms.RadioButton();
            this.rdbHand = new System.Windows.Forms.RadioButton();
            this.rdbWheel = new System.Windows.Forms.RadioButton();
            this.rdbFlat = new System.Windows.Forms.RadioButton();
            this.rdbBack = new System.Windows.Forms.RadioButton();
            this.rdbArm = new System.Windows.Forms.RadioButton();
            this.m_txtCaseHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtFamilyHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.chkFamilyForm0 = new System.Windows.Forms.CheckBox();
            this.chkFamilyForm1 = new System.Windows.Forms.CheckBox();
            this.chkFamilyForm2 = new System.Windows.Forms.CheckBox();
            this.chkFamilyForm3 = new System.Windows.Forms.CheckBox();
            this.m_txtFamilyFormOther = new com.digitalwave.controls.ctlRichTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.chkInHospitalWorry0 = new System.Windows.Forms.CheckBox();
            this.chkInHospitalWorry1 = new System.Windows.Forms.CheckBox();
            this.chkInHospitalWorry2 = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.m_txtInHospitalWorryOther = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.chkFeeling0 = new System.Windows.Forms.CheckBox();
            this.chkFeeling1 = new System.Windows.Forms.CheckBox();
            this.chkFeeling2 = new System.Windows.Forms.CheckBox();
            this.chkFeeling3 = new System.Windows.Forms.CheckBox();
            this.chkFeeling4 = new System.Windows.Forms.CheckBox();
            this.chkFeeling5 = new System.Windows.Forms.CheckBox();
            this.chkFeeling6 = new System.Windows.Forms.CheckBox();
            this.chkFeeling7 = new System.Windows.Forms.CheckBox();
            this.chkFeeling8 = new System.Windows.Forms.CheckBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.chkJob6 = new System.Windows.Forms.CheckBox();
            this.chkJob0 = new System.Windows.Forms.CheckBox();
            this.chkJob1 = new System.Windows.Forms.CheckBox();
            this.chkJob2 = new System.Windows.Forms.CheckBox();
            this.chkJob3 = new System.Windows.Forms.CheckBox();
            this.chkJob4 = new System.Windows.Forms.CheckBox();
            this.chkJob5 = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.chkSelfSolve0 = new System.Windows.Forms.CheckBox();
            this.chkSelfSolve1 = new System.Windows.Forms.CheckBox();
            this.chkSelfSolve2 = new System.Windows.Forms.CheckBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.chkHobby0 = new System.Windows.Forms.CheckBox();
            this.chkHobby1 = new System.Windows.Forms.CheckBox();
            this.chkHobby2 = new System.Windows.Forms.CheckBox();
            this.chkHobby3 = new System.Windows.Forms.CheckBox();
            this.chkHobby4 = new System.Windows.Forms.CheckBox();
            this.m_txtHobbyOther = new com.digitalwave.controls.ctlRichTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPee0 = new System.Windows.Forms.CheckBox();
            this.chkPee1 = new System.Windows.Forms.CheckBox();
            this.chkPee2 = new System.Windows.Forms.CheckBox();
            this.chkPee3 = new System.Windows.Forms.CheckBox();
            this.chkPee4 = new System.Windows.Forms.CheckBox();
            this.chkPee5 = new System.Windows.Forms.CheckBox();
            this.chkPee6 = new System.Windows.Forms.CheckBox();
            this.chkPee7 = new System.Windows.Forms.CheckBox();
            this.chkPee8 = new System.Windows.Forms.CheckBox();
            this.chkPee9 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtStoolOther = new com.digitalwave.controls.ctlRichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.m_txtAstrictionDays = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.m_txtAstrictionTimes = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.chkStool = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.m_txtDiarrheaDays = new System.Windows.Forms.TextBox();
            this.m_txtDiarrheaTimes = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.chkSleep1 = new System.Windows.Forms.CheckBox();
            this.chkSleep3 = new System.Windows.Forms.CheckBox();
            this.chkSleep0 = new System.Windows.Forms.CheckBox();
            this.chkSleep2 = new System.Windows.Forms.CheckBox();
            this.chkSleep4 = new System.Windows.Forms.CheckBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.chkAppetite2 = new System.Windows.Forms.CheckBox();
            this.chkAppetite3 = new System.Windows.Forms.CheckBox();
            this.chkAppetite4 = new System.Windows.Forms.CheckBox();
            this.chkAppetite5 = new System.Windows.Forms.CheckBox();
            this.chkAppetite0 = new System.Windows.Forms.CheckBox();
            this.chkAppetite1 = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.chkBiteSup0 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup1 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup2 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup3 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup4 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup6 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup7 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup8 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup9 = new System.Windows.Forms.CheckBox();
            this.chkBiteSup10 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblRecordTimeTitle = new System.Windows.Forms.Label();
            this.m_dtpRecordTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.m_txtSign = new System.Windows.Forms.TextBox();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.m_txtSpecilizedCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.chkKnowDisease0 = new System.Windows.Forms.CheckBox();
            this.chkKnowDisease1 = new System.Windows.Forms.CheckBox();
            this.chkKnowDisease2 = new System.Windows.Forms.CheckBox();
            this.chkKnowDisease3 = new System.Windows.Forms.CheckBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.chkHealthNeed0 = new System.Windows.Forms.CheckBox();
            this.chkHealthNeed1 = new System.Windows.Forms.CheckBox();
            this.chkHealthNeed2 = new System.Windows.Forms.CheckBox();
            this.chkHealthNeed3 = new System.Windows.Forms.CheckBox();
            this.chkHealthNeed4 = new System.Windows.Forms.CheckBox();
            this.grpPip = new System.Windows.Forms.GroupBox();
            this.m_txtPipInstance = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.m_txtWoodInstance = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.m_txtTendPlan = new com.digitalwave.controls.ctlRichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.m_txtKnowledgeEdu2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtOtherDate3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtOtherDate2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtOtherDate1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtGuidanceDate3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtGuidanceDate1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtGuidanceDate2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtKnowledgeDate2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtKnowledgeDate1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtNoticeDate3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtNoticeDate1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtNoticeDate2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtMedicineDate3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtMedicineDate2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtMedicineDate1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtExplanDate3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtReadOutDate3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_cmdNurseSign73 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign63 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign53 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign43 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign33 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign23 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign13 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign72 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign62 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign52 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign42 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign32 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign22 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign12 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign71 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign61 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign51 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign41 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign31 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign21 = new System.Windows.Forms.Button();
            this.m_cmdNurseSign11 = new System.Windows.Forms.Button();
            this.m_txtReadOutNurse3 = new System.Windows.Forms.TextBox();
            this.m_txtReadOutNurse2 = new System.Windows.Forms.TextBox();
            this.m_txtExplanNurse3 = new System.Windows.Forms.TextBox();
            this.m_txtExplanNurse2 = new System.Windows.Forms.TextBox();
            this.m_txtMedicineNurse3 = new System.Windows.Forms.TextBox();
            this.m_txtMedicineNurse2 = new System.Windows.Forms.TextBox();
            this.m_txtNoticeNurse3 = new System.Windows.Forms.TextBox();
            this.m_txtNoticeNurse2 = new System.Windows.Forms.TextBox();
            this.m_txtKnowledgeNurse3 = new System.Windows.Forms.TextBox();
            this.m_txtKnowledgeNurse2 = new System.Windows.Forms.TextBox();
            this.m_txtGuidanceNurse3 = new System.Windows.Forms.TextBox();
            this.m_txtGuidanceNurse2 = new System.Windows.Forms.TextBox();
            this.m_txtOtherNurse3 = new System.Windows.Forms.TextBox();
            this.m_txtOtherNurse2 = new System.Windows.Forms.TextBox();
            this.m_txtOtherNurse1 = new System.Windows.Forms.TextBox();
            this.m_txtGuidanceNurse1 = new System.Windows.Forms.TextBox();
            this.m_txtKnowledgeNurse1 = new System.Windows.Forms.TextBox();
            this.m_txtNoticeNurse1 = new System.Windows.Forms.TextBox();
            this.m_txtMedicineNurse1 = new System.Windows.Forms.TextBox();
            this.m_txtExplanNurse1 = new System.Windows.Forms.TextBox();
            this.m_txtReadOutNurse1 = new System.Windows.Forms.TextBox();
            this.m_txtReadOutDate1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.dtpNurseSignDate11 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpEduTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label46 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.m_txtReadOutEdu1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.m_txtReadOutEdu2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtReadOutDate2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtReadOutEdu3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.m_txtExplanEdu1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtExplanDate1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtExplanEdu2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtExplanDate2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtExplanEdu3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtMedicineEdu1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtMedicineEdu2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtMedicineEdu3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtNoticeEdu1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtNoticeEdu2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtNoticeEdu3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtKnowledgeEdu3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtKnowledgeDate3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtKnowledgeEdu1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtGuidanceEdu1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtGuidanceEdu3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtGuidanceEdu2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtOtherEdu2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtOtherEdu3 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.dtpNurseSignDate73 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate63 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate53 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate43 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate33 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate72 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate62 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_txtOtherEdu1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.dtpNurseSignDate52 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate42 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate23 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate32 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate13 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate22 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate71 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate12 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate61 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate51 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate41 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate31 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpNurseSignDate21 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lblInHospitalDays = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.m_cmdChargeNurse = new PinkieControls.ButtonXP();
            this.m_txtNurseSign = new System.Windows.Forms.TextBox();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.chkSpecialtiesCoach0 = new System.Windows.Forms.CheckBox();
            this.chkSpecialtiesCoach1 = new System.Windows.Forms.CheckBox();
            this.m_txtSpecialtiesCoach = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.chkAdviceDrug0 = new System.Windows.Forms.CheckBox();
            this.chkAdviceDrug1 = new System.Windows.Forms.CheckBox();
            this.chkAdviceDrug2 = new System.Windows.Forms.CheckBox();
            this.chkAdviceDrug3 = new System.Windows.Forms.CheckBox();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.chkCommonlyCoach0 = new System.Windows.Forms.CheckBox();
            this.chkCommonlyCoach1 = new System.Windows.Forms.CheckBox();
            this.chkCommonlyCoach2 = new System.Windows.Forms.CheckBox();
            this.chkCommonlyCoach3 = new System.Windows.Forms.CheckBox();
            this.chkCommonlyCoach4 = new System.Windows.Forms.CheckBox();
            this.chkCommonlyCoach5 = new System.Windows.Forms.CheckBox();
            this.chkCommonlyCoach6 = new System.Windows.Forms.CheckBox();
            this.chkCommonlyCoach7 = new System.Windows.Forms.CheckBox();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.m_txtNurseIssue = new com.digitalwave.controls.ctlRichTextBox();
            this.chkNurseIssue0 = new System.Windows.Forms.CheckBox();
            this.chkNurseIssue1 = new System.Windows.Forms.CheckBox();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.m_txtNurseSyndrome = new com.digitalwave.controls.ctlRichTextBox();
            this.chkNurseSyndrome0 = new System.Windows.Forms.CheckBox();
            this.chkNurseSyndrome1 = new System.Windows.Forms.CheckBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.chkOutHospitalMode0 = new System.Windows.Forms.CheckBox();
            this.chkOutHospitalMode1 = new System.Windows.Forms.CheckBox();
            this.chkOutHospitalMode2 = new System.Windows.Forms.CheckBox();
            this.chkOutHospitalMode3 = new System.Windows.Forms.CheckBox();
            this.chkOutHospitalMode4 = new System.Windows.Forms.CheckBox();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.chkDieteticCircs0 = new System.Windows.Forms.CheckBox();
            this.chkDieteticCircs1 = new System.Windows.Forms.CheckBox();
            this.chkDieteticCircs2 = new System.Windows.Forms.CheckBox();
            this.chkDieteticCircs3 = new System.Windows.Forms.CheckBox();
            this.chkDieteticCircs4 = new System.Windows.Forms.CheckBox();
            this.chkDieteticCircs5 = new System.Windows.Forms.CheckBox();
            this.chkDieteticCircs6 = new System.Windows.Forms.CheckBox();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.chkLiveAbility0 = new System.Windows.Forms.CheckBox();
            this.chkLiveAbility1 = new System.Windows.Forms.CheckBox();
            this.chkLiveAbility2 = new System.Windows.Forms.CheckBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.m_txtOutHospitalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdNurseSign = new PinkieControls.ButtonXP();
            this.m_txtChargeNurse = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.lblAddress = new System.Windows.Forms.Label();
            this.m_cboEducation = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_pnlNewBase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.grpPip.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(289, 121);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(218, 165);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(266, 166);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(245, 157);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(266, 136);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(311, 140);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(245, 119);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(227, 157);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(264, 136);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(288, 171);
            this.txtInPatientID.Size = new System.Drawing.Size(104, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(295, 161);
            this.m_txtPatientName.Size = new System.Drawing.Size(72, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(275, 136);
            this.m_txtBedNO.Size = new System.Drawing.Size(72, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(230, 157);
            this.m_cboArea.Size = new System.Drawing.Size(120, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(264, 130);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(264, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(247, 171);
            this.m_cboDept.Size = new System.Drawing.Size(120, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(289, 154);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(269, 143);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(311, 157);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(276, 154);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(288, 104);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(428, 184);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(749, 62);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(78, 29);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_cboEducation);
            this.m_pnlNewBase.Controls.Add(this.label4);
            this.m_pnlNewBase.Size = new System.Drawing.Size(822, 86);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label4, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cboEducation, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = true;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(820, 55);
            // 
            // m_trvTime
            // 
            this.m_trvTime.BackColor = System.Drawing.Color.White;
            this.m_trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvTime.ForeColor = System.Drawing.Color.Black;
            this.m_trvTime.HideSelection = false;
            this.m_trvTime.Location = new System.Drawing.Point(224, 143);
            this.m_trvTime.Name = "m_trvTime";
            treeNode1.Name = "";
            treeNode1.Text = "入院时间";
            this.m_trvTime.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.m_trvTime.ShowRootLines = false;
            this.m_trvTime.Size = new System.Drawing.Size(160, 65);
            this.m_trvTime.TabIndex = 10000004;
            this.m_trvTime.Visible = false;
            this.m_trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvTime_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000005;
            this.label1.Text = "民族:";
            this.label1.Visible = false;
            // 
            // lblFolk
            // 
            this.lblFolk.Location = new System.Drawing.Point(289, 152);
            this.lblFolk.Name = "lblFolk";
            this.lblFolk.Size = new System.Drawing.Size(72, 16);
            this.lblFolk.TabIndex = 10000006;
            this.lblFolk.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000005;
            this.label2.Text = "职业:";
            this.label2.Visible = false;
            // 
            // lblJob
            // 
            this.lblJob.AccessibleDescription = "职业";
            this.lblJob.Location = new System.Drawing.Point(221, 162);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(120, 18);
            this.lblJob.TabIndex = 10000006;
            this.lblJob.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 10000005;
            this.label3.Text = "籍贯:";
            this.label3.Visible = false;
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.AccessibleDescription = "籍贯";
            this.lblNativePlace.Location = new System.Drawing.Point(244, 134);
            this.lblNativePlace.Name = "lblNativePlace";
            this.lblNativePlace.Size = new System.Drawing.Size(112, 23);
            this.lblNativePlace.TabIndex = 10000006;
            this.lblNativePlace.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(345, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 10000007;
            this.label4.Text = "文化程度:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000005;
            this.label5.Text = "住址:";
            this.label5.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(8, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 534);
            this.tabControl1.TabIndex = 3010;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkSelfPay);
            this.tabPage1.Controls.Add(this.chkInsure);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.m_txtInPatientDiagnose);
            this.tabPage1.Controls.Add(this.lblTitle5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.m_txtCaseHistory);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.m_txtFamilyHistory);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(816, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "病人资料一";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkSelfPay
            // 
            this.chkSelfPay.AccessibleDescription = "自费";
            this.chkSelfPay.Location = new System.Drawing.Point(560, 8);
            this.chkSelfPay.Name = "chkSelfPay";
            this.chkSelfPay.Size = new System.Drawing.Size(104, 24);
            this.chkSelfPay.TabIndex = 450;
            this.chkSelfPay.Text = "自费";
            // 
            // chkInsure
            // 
            this.chkInsure.AccessibleDescription = "医疗保险";
            this.chkInsure.Location = new System.Drawing.Point(456, 8);
            this.chkInsure.Name = "chkInsure";
            this.chkInsure.Size = new System.Drawing.Size(104, 24);
            this.chkInsure.TabIndex = 400;
            this.chkInsure.Text = "医疗保险";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.label53);
            this.groupBox4.Controls.Add(this.label54);
            this.groupBox4.Controls.Add(this.m_txtshengao);
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.m_txtTemperature);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.m_txtPulse);
            this.groupBox4.Controls.Add(this.m_txtRhythm);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.m_txtBp_Shink);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.m_txtBp_Extend);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.m_txtAvoirdupois);
            this.groupBox4.Location = new System.Drawing.Point(8, 222);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(800, 280);
            this.groupBox4.TabIndex = 10000017;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "一、体格检查";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(776, 31);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(21, 14);
            this.label55.TabIndex = 1254;
            this.label55.Text = "cm";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(677, 30);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(35, 14);
            this.label53.TabIndex = 1251;
            this.label53.Text = "身高";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(802, 36);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(21, 14);
            this.label54.TabIndex = 1252;
            this.label54.Text = "Kg";
            // 
            // m_txtshengao
            // 
            this.m_txtshengao.AccessibleDescription = "身高";
            this.m_txtshengao.Location = new System.Drawing.Point(712, 28);
            this.m_txtshengao.MaxLength = 6;
            this.m_txtshengao.Name = "m_txtshengao";
            this.m_txtshengao.Size = new System.Drawing.Size(64, 23);
            this.m_txtshengao.TabIndex = 1253;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.chkLimbsactivity0);
            this.groupBox10.Controls.Add(this.chkLimbsactivity1);
            this.groupBox10.Controls.Add(this.chkLimbsactivity2);
            this.groupBox10.Controls.Add(this.chkLimbsactivity3);
            this.groupBox10.Controls.Add(this.chkLimbsactivity4);
            this.groupBox10.Controls.Add(this.chkLimbsactivity5);
            this.groupBox10.Controls.Add(this.chkLimbsactivity6);
            this.groupBox10.Controls.Add(this.label22);
            this.groupBox10.Controls.Add(this.m_txtLimbsactivityOther);
            this.groupBox10.Location = new System.Drawing.Point(8, 224);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(776, 48);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "四肢活动";
            // 
            // chkLimbsactivity0
            // 
            this.chkLimbsactivity0.AccessibleDescription = "四肢活动>>自如";
            this.chkLimbsactivity0.Location = new System.Drawing.Point(16, 16);
            this.chkLimbsactivity0.Name = "chkLimbsactivity0";
            this.chkLimbsactivity0.Size = new System.Drawing.Size(56, 24);
            this.chkLimbsactivity0.TabIndex = 2650;
            this.chkLimbsactivity0.Text = "自如";
            // 
            // chkLimbsactivity1
            // 
            this.chkLimbsactivity1.AccessibleDescription = "四肢活动>>障碍";
            this.chkLimbsactivity1.Location = new System.Drawing.Point(78, 16);
            this.chkLimbsactivity1.Name = "chkLimbsactivity1";
            this.chkLimbsactivity1.Size = new System.Drawing.Size(64, 24);
            this.chkLimbsactivity1.TabIndex = 2700;
            this.chkLimbsactivity1.Text = "障碍(";
            this.chkLimbsactivity1.CheckedChanged += new System.EventHandler(this.chkLimbsactivity1_CheckedChanged);
            // 
            // chkLimbsactivity2
            // 
            this.chkLimbsactivity2.AccessibleDescription = "四肢活动>>进食";
            this.chkLimbsactivity2.Enabled = false;
            this.chkLimbsactivity2.Location = new System.Drawing.Point(148, 16);
            this.chkLimbsactivity2.Name = "chkLimbsactivity2";
            this.chkLimbsactivity2.Size = new System.Drawing.Size(56, 24);
            this.chkLimbsactivity2.TabIndex = 2750;
            this.chkLimbsactivity2.Text = "进食";
            // 
            // chkLimbsactivity3
            // 
            this.chkLimbsactivity3.AccessibleDescription = "四肢活动>>洗漱";
            this.chkLimbsactivity3.Enabled = false;
            this.chkLimbsactivity3.Location = new System.Drawing.Point(210, 16);
            this.chkLimbsactivity3.Name = "chkLimbsactivity3";
            this.chkLimbsactivity3.Size = new System.Drawing.Size(56, 24);
            this.chkLimbsactivity3.TabIndex = 2800;
            this.chkLimbsactivity3.Text = "洗漱";
            // 
            // chkLimbsactivity4
            // 
            this.chkLimbsactivity4.AccessibleDescription = "四肢活动>>排泄";
            this.chkLimbsactivity4.Enabled = false;
            this.chkLimbsactivity4.Location = new System.Drawing.Point(272, 16);
            this.chkLimbsactivity4.Name = "chkLimbsactivity4";
            this.chkLimbsactivity4.Size = new System.Drawing.Size(92, 24);
            this.chkLimbsactivity4.TabIndex = 2850;
            this.chkLimbsactivity4.Text = "排泄  )";
            // 
            // chkLimbsactivity5
            // 
            this.chkLimbsactivity5.AccessibleDescription = "四肢活动>>偏瘫";
            this.chkLimbsactivity5.Location = new System.Drawing.Point(370, 16);
            this.chkLimbsactivity5.Name = "chkLimbsactivity5";
            this.chkLimbsactivity5.Size = new System.Drawing.Size(56, 24);
            this.chkLimbsactivity5.TabIndex = 2900;
            this.chkLimbsactivity5.Text = "偏瘫";
            // 
            // chkLimbsactivity6
            // 
            this.chkLimbsactivity6.AccessibleDescription = "四肢活动>>畸形";
            this.chkLimbsactivity6.Location = new System.Drawing.Point(432, 16);
            this.chkLimbsactivity6.Name = "chkLimbsactivity6";
            this.chkLimbsactivity6.Size = new System.Drawing.Size(56, 24);
            this.chkLimbsactivity6.TabIndex = 2950;
            this.chkLimbsactivity6.Text = "畸形";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(494, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 14);
            this.label22.TabIndex = 1;
            this.label22.Text = "其它 ";
            // 
            // m_txtLimbsactivityOther
            // 
            this.m_txtLimbsactivityOther.AccessibleDescription = "四肢活动>>其它";
            this.m_txtLimbsactivityOther.BackColor = System.Drawing.Color.White;
            this.m_txtLimbsactivityOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLimbsactivityOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtLimbsactivityOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLimbsactivityOther.Location = new System.Drawing.Point(536, 16);
            this.m_txtLimbsactivityOther.m_BlnIgnoreUserInfo = false;
            this.m_txtLimbsactivityOther.m_BlnPartControl = false;
            this.m_txtLimbsactivityOther.m_BlnReadOnly = false;
            this.m_txtLimbsactivityOther.m_BlnUnderLineDST = false;
            this.m_txtLimbsactivityOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLimbsactivityOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLimbsactivityOther.m_IntCanModifyTime = 6;
            this.m_txtLimbsactivityOther.m_IntPartControlLength = 0;
            this.m_txtLimbsactivityOther.m_IntPartControlStartIndex = 0;
            this.m_txtLimbsactivityOther.m_StrUserID = "";
            this.m_txtLimbsactivityOther.m_StrUserName = "";
            this.m_txtLimbsactivityOther.MaxLength = 8000;
            this.m_txtLimbsactivityOther.Multiline = false;
            this.m_txtLimbsactivityOther.Name = "m_txtLimbsactivityOther";
            this.m_txtLimbsactivityOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtLimbsactivityOther.Size = new System.Drawing.Size(232, 23);
            this.m_txtLimbsactivityOther.TabIndex = 3000;
            this.m_txtLimbsactivityOther.Text = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chkSkin0);
            this.groupBox9.Controls.Add(this.chkSkin1);
            this.groupBox9.Controls.Add(this.chkSkin2);
            this.groupBox9.Controls.Add(this.chkSkin3);
            this.groupBox9.Controls.Add(this.chkSkin4);
            this.groupBox9.Controls.Add(this.chkSkin5);
            this.groupBox9.Controls.Add(this.chkSkin6);
            this.groupBox9.Controls.Add(this.chkSkin7);
            this.groupBox9.Controls.Add(this.chkSkin8);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.m_txtSkinOther);
            this.groupBox9.Location = new System.Drawing.Point(8, 168);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(776, 48);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "皮肤";
            // 
            // chkSkin0
            // 
            this.chkSkin0.AccessibleDescription = "皮肤>>正常";
            this.chkSkin0.Location = new System.Drawing.Point(16, 16);
            this.chkSkin0.Name = "chkSkin0";
            this.chkSkin0.Size = new System.Drawing.Size(56, 24);
            this.chkSkin0.TabIndex = 2150;
            this.chkSkin0.Text = "正常";
            // 
            // chkSkin1
            // 
            this.chkSkin1.AccessibleDescription = "皮肤>>潮红";
            this.chkSkin1.Location = new System.Drawing.Point(78, 16);
            this.chkSkin1.Name = "chkSkin1";
            this.chkSkin1.Size = new System.Drawing.Size(56, 24);
            this.chkSkin1.TabIndex = 2200;
            this.chkSkin1.Text = "潮红";
            // 
            // chkSkin2
            // 
            this.chkSkin2.AccessibleDescription = "皮肤>>苍白";
            this.chkSkin2.Location = new System.Drawing.Point(140, 16);
            this.chkSkin2.Name = "chkSkin2";
            this.chkSkin2.Size = new System.Drawing.Size(56, 24);
            this.chkSkin2.TabIndex = 2250;
            this.chkSkin2.Text = "苍白";
            // 
            // chkSkin3
            // 
            this.chkSkin3.AccessibleDescription = "皮肤>>发绀";
            this.chkSkin3.Location = new System.Drawing.Point(202, 16);
            this.chkSkin3.Name = "chkSkin3";
            this.chkSkin3.Size = new System.Drawing.Size(56, 24);
            this.chkSkin3.TabIndex = 2300;
            this.chkSkin3.Text = "发绀";
            // 
            // chkSkin4
            // 
            this.chkSkin4.AccessibleDescription = "皮肤>>黄染";
            this.chkSkin4.Location = new System.Drawing.Point(264, 16);
            this.chkSkin4.Name = "chkSkin4";
            this.chkSkin4.Size = new System.Drawing.Size(56, 24);
            this.chkSkin4.TabIndex = 2350;
            this.chkSkin4.Text = "黄染";
            // 
            // chkSkin5
            // 
            this.chkSkin5.AccessibleDescription = "皮肤>>水肿";
            this.chkSkin5.Location = new System.Drawing.Point(326, 16);
            this.chkSkin5.Name = "chkSkin5";
            this.chkSkin5.Size = new System.Drawing.Size(56, 24);
            this.chkSkin5.TabIndex = 2400;
            this.chkSkin5.Text = "水肿";
            // 
            // chkSkin6
            // 
            this.chkSkin6.AccessibleDescription = "皮肤>>失水";
            this.chkSkin6.Location = new System.Drawing.Point(388, 16);
            this.chkSkin6.Name = "chkSkin6";
            this.chkSkin6.Size = new System.Drawing.Size(56, 24);
            this.chkSkin6.TabIndex = 2450;
            this.chkSkin6.Text = "失水";
            // 
            // chkSkin7
            // 
            this.chkSkin7.AccessibleDescription = "皮肤>>疖肿";
            this.chkSkin7.Location = new System.Drawing.Point(450, 16);
            this.chkSkin7.Name = "chkSkin7";
            this.chkSkin7.Size = new System.Drawing.Size(56, 24);
            this.chkSkin7.TabIndex = 2500;
            this.chkSkin7.Text = "疖肿";
            // 
            // chkSkin8
            // 
            this.chkSkin8.AccessibleDescription = "皮肤>>皮疹";
            this.chkSkin8.Location = new System.Drawing.Point(512, 16);
            this.chkSkin8.Name = "chkSkin8";
            this.chkSkin8.Size = new System.Drawing.Size(56, 24);
            this.chkSkin8.TabIndex = 2550;
            this.chkSkin8.Text = "皮疹";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(566, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 14);
            this.label21.TabIndex = 1;
            this.label21.Text = "其它 ";
            // 
            // m_txtSkinOther
            // 
            this.m_txtSkinOther.AccessibleDescription = "皮肤>>其它";
            this.m_txtSkinOther.BackColor = System.Drawing.Color.White;
            this.m_txtSkinOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSkinOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtSkinOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSkinOther.Location = new System.Drawing.Point(608, 16);
            this.m_txtSkinOther.m_BlnIgnoreUserInfo = false;
            this.m_txtSkinOther.m_BlnPartControl = false;
            this.m_txtSkinOther.m_BlnReadOnly = false;
            this.m_txtSkinOther.m_BlnUnderLineDST = false;
            this.m_txtSkinOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSkinOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSkinOther.m_IntCanModifyTime = 6;
            this.m_txtSkinOther.m_IntPartControlLength = 0;
            this.m_txtSkinOther.m_IntPartControlStartIndex = 0;
            this.m_txtSkinOther.m_StrUserID = "";
            this.m_txtSkinOther.m_StrUserName = "";
            this.m_txtSkinOther.MaxLength = 8000;
            this.m_txtSkinOther.Multiline = false;
            this.m_txtSkinOther.Name = "m_txtSkinOther";
            this.m_txtSkinOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSkinOther.Size = new System.Drawing.Size(160, 23);
            this.m_txtSkinOther.TabIndex = 2600;
            this.m_txtSkinOther.Text = "";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkEmotion0);
            this.groupBox8.Controls.Add(this.chkEmotion1);
            this.groupBox8.Controls.Add(this.chkEmotion2);
            this.groupBox8.Location = new System.Drawing.Point(432, 112);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(352, 48);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "情绪";
            // 
            // chkEmotion0
            // 
            this.chkEmotion0.AccessibleDescription = "情绪>>正常";
            this.chkEmotion0.Location = new System.Drawing.Point(16, 16);
            this.chkEmotion0.Name = "chkEmotion0";
            this.chkEmotion0.Size = new System.Drawing.Size(56, 24);
            this.chkEmotion0.TabIndex = 2000;
            this.chkEmotion0.Text = "正常";
            // 
            // chkEmotion1
            // 
            this.chkEmotion1.AccessibleDescription = "情绪>>淡漠";
            this.chkEmotion1.Location = new System.Drawing.Point(104, 16);
            this.chkEmotion1.Name = "chkEmotion1";
            this.chkEmotion1.Size = new System.Drawing.Size(56, 24);
            this.chkEmotion1.TabIndex = 2050;
            this.chkEmotion1.Text = "淡漠";
            // 
            // chkEmotion2
            // 
            this.chkEmotion2.AccessibleDescription = "情绪>>痛苦面容";
            this.chkEmotion2.Location = new System.Drawing.Point(192, 16);
            this.chkEmotion2.Name = "chkEmotion2";
            this.chkEmotion2.Size = new System.Drawing.Size(96, 24);
            this.chkEmotion2.TabIndex = 2100;
            this.chkEmotion2.Text = "痛苦面容";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.chkPhysique0);
            this.groupBox7.Controls.Add(this.chkPhysique1);
            this.groupBox7.Controls.Add(this.chkPhysique2);
            this.groupBox7.Controls.Add(this.m_txtPhysiqueOther);
            this.groupBox7.Location = new System.Drawing.Point(8, 112);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(408, 48);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "体形";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(238, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 14);
            this.label12.TabIndex = 1;
            this.label12.Text = "其它 ";
            // 
            // chkPhysique0
            // 
            this.chkPhysique0.AccessibleDescription = "体形>>一般";
            this.chkPhysique0.Location = new System.Drawing.Point(16, 16);
            this.chkPhysique0.Name = "chkPhysique0";
            this.chkPhysique0.Size = new System.Drawing.Size(56, 24);
            this.chkPhysique0.TabIndex = 1750;
            this.chkPhysique0.Text = "一般";
            // 
            // chkPhysique1
            // 
            this.chkPhysique1.AccessibleDescription = "体形>>消瘦";
            this.chkPhysique1.Location = new System.Drawing.Point(96, 16);
            this.chkPhysique1.Name = "chkPhysique1";
            this.chkPhysique1.Size = new System.Drawing.Size(56, 24);
            this.chkPhysique1.TabIndex = 1800;
            this.chkPhysique1.Text = "消瘦";
            // 
            // chkPhysique2
            // 
            this.chkPhysique2.AccessibleDescription = "体形>>肥胖";
            this.chkPhysique2.Location = new System.Drawing.Point(176, 16);
            this.chkPhysique2.Name = "chkPhysique2";
            this.chkPhysique2.Size = new System.Drawing.Size(56, 24);
            this.chkPhysique2.TabIndex = 1900;
            this.chkPhysique2.Text = "肥胖";
            // 
            // m_txtPhysiqueOther
            // 
            this.m_txtPhysiqueOther.AccessibleDescription = "体形>>其它";
            this.m_txtPhysiqueOther.BackColor = System.Drawing.Color.White;
            this.m_txtPhysiqueOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPhysiqueOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtPhysiqueOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPhysiqueOther.Location = new System.Drawing.Point(280, 16);
            this.m_txtPhysiqueOther.m_BlnIgnoreUserInfo = false;
            this.m_txtPhysiqueOther.m_BlnPartControl = false;
            this.m_txtPhysiqueOther.m_BlnReadOnly = false;
            this.m_txtPhysiqueOther.m_BlnUnderLineDST = false;
            this.m_txtPhysiqueOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPhysiqueOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPhysiqueOther.m_IntCanModifyTime = 6;
            this.m_txtPhysiqueOther.m_IntPartControlLength = 0;
            this.m_txtPhysiqueOther.m_IntPartControlStartIndex = 0;
            this.m_txtPhysiqueOther.m_StrUserID = "";
            this.m_txtPhysiqueOther.m_StrUserName = "";
            this.m_txtPhysiqueOther.MaxLength = 8000;
            this.m_txtPhysiqueOther.Multiline = false;
            this.m_txtPhysiqueOther.Name = "m_txtPhysiqueOther";
            this.m_txtPhysiqueOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPhysiqueOther.Size = new System.Drawing.Size(120, 23);
            this.m_txtPhysiqueOther.TabIndex = 1950;
            this.m_txtPhysiqueOther.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkComplexion0);
            this.groupBox6.Controls.Add(this.chkComplexion1);
            this.groupBox6.Controls.Add(this.chkComplexion2);
            this.groupBox6.Controls.Add(this.chkComplexion3);
            this.groupBox6.Location = new System.Drawing.Point(432, 56);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(352, 48);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "面色";
            // 
            // chkComplexion0
            // 
            this.chkComplexion0.AccessibleDescription = "面色>>正常";
            this.chkComplexion0.Location = new System.Drawing.Point(16, 16);
            this.chkComplexion0.Name = "chkComplexion0";
            this.chkComplexion0.Size = new System.Drawing.Size(56, 24);
            this.chkComplexion0.TabIndex = 1550;
            this.chkComplexion0.Text = "正常";
            // 
            // chkComplexion1
            // 
            this.chkComplexion1.AccessibleDescription = "面色>>潮红";
            this.chkComplexion1.Location = new System.Drawing.Point(104, 16);
            this.chkComplexion1.Name = "chkComplexion1";
            this.chkComplexion1.Size = new System.Drawing.Size(56, 24);
            this.chkComplexion1.TabIndex = 1600;
            this.chkComplexion1.Text = "潮红";
            // 
            // chkComplexion2
            // 
            this.chkComplexion2.AccessibleDescription = "面色>>苍白";
            this.chkComplexion2.Location = new System.Drawing.Point(192, 16);
            this.chkComplexion2.Name = "chkComplexion2";
            this.chkComplexion2.Size = new System.Drawing.Size(56, 24);
            this.chkComplexion2.TabIndex = 1650;
            this.chkComplexion2.Text = "苍白";
            // 
            // chkComplexion3
            // 
            this.chkComplexion3.AccessibleDescription = "面色>>黄染";
            this.chkComplexion3.Location = new System.Drawing.Point(280, 16);
            this.chkComplexion3.Name = "chkComplexion3";
            this.chkComplexion3.Size = new System.Drawing.Size(56, 24);
            this.chkComplexion3.TabIndex = 1700;
            this.chkComplexion3.Text = "黄染";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkConsciousness0);
            this.groupBox5.Controls.Add(this.chkConsciousness1);
            this.groupBox5.Controls.Add(this.chkConsciousness2);
            this.groupBox5.Controls.Add(this.chkConsciousness3);
            this.groupBox5.Controls.Add(this.chkConsciousness4);
            this.groupBox5.Location = new System.Drawing.Point(8, 56);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(408, 48);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "意识状态";
            // 
            // chkConsciousness0
            // 
            this.chkConsciousness0.AccessibleDescription = "意识状态>>清醒";
            this.chkConsciousness0.Location = new System.Drawing.Point(16, 16);
            this.chkConsciousness0.Name = "chkConsciousness0";
            this.chkConsciousness0.Size = new System.Drawing.Size(56, 24);
            this.chkConsciousness0.TabIndex = 1300;
            this.chkConsciousness0.Text = "清醒";
            // 
            // chkConsciousness1
            // 
            this.chkConsciousness1.AccessibleDescription = "意识状态>>模糊";
            this.chkConsciousness1.Location = new System.Drawing.Point(96, 16);
            this.chkConsciousness1.Name = "chkConsciousness1";
            this.chkConsciousness1.Size = new System.Drawing.Size(56, 24);
            this.chkConsciousness1.TabIndex = 1350;
            this.chkConsciousness1.Text = "模糊";
            // 
            // chkConsciousness2
            // 
            this.chkConsciousness2.AccessibleDescription = "意识状态>>嗜睡";
            this.chkConsciousness2.Location = new System.Drawing.Point(176, 16);
            this.chkConsciousness2.Name = "chkConsciousness2";
            this.chkConsciousness2.Size = new System.Drawing.Size(56, 24);
            this.chkConsciousness2.TabIndex = 1400;
            this.chkConsciousness2.Text = "嗜睡";
            // 
            // chkConsciousness3
            // 
            this.chkConsciousness3.AccessibleDescription = "意识状态>>谵妄";
            this.chkConsciousness3.Location = new System.Drawing.Point(256, 16);
            this.chkConsciousness3.Name = "chkConsciousness3";
            this.chkConsciousness3.Size = new System.Drawing.Size(56, 24);
            this.chkConsciousness3.TabIndex = 1450;
            this.chkConsciousness3.Text = "谵妄";
            // 
            // chkConsciousness4
            // 
            this.chkConsciousness4.AccessibleDescription = "意识状态>>昏迷";
            this.chkConsciousness4.Location = new System.Drawing.Point(336, 16);
            this.chkConsciousness4.Name = "chkConsciousness4";
            this.chkConsciousness4.Size = new System.Drawing.Size(56, 24);
            this.chkConsciousness4.TabIndex = 1500;
            this.chkConsciousness4.Text = "昏迷";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(205, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "次/分";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(117, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "P";
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.AccessibleDescription = "体温";
            this.m_txtTemperature.Location = new System.Drawing.Point(24, 24);
            this.m_txtTemperature.MaxLength = 6;
            this.m_txtTemperature.Name = "m_txtTemperature";
            this.m_txtTemperature.Size = new System.Drawing.Size(64, 23);
            this.m_txtTemperature.TabIndex = 1000;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "T";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(91, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "℃";
            // 
            // m_txtPulse
            // 
            this.m_txtPulse.AccessibleDescription = "脉搏";
            this.m_txtPulse.Location = new System.Drawing.Point(133, 24);
            this.m_txtPulse.MaxLength = 6;
            this.m_txtPulse.Name = "m_txtPulse";
            this.m_txtPulse.Size = new System.Drawing.Size(64, 23);
            this.m_txtPulse.TabIndex = 1050;
            // 
            // m_txtRhythm
            // 
            this.m_txtRhythm.AccessibleDescription = "心律";
            this.m_txtRhythm.Location = new System.Drawing.Point(269, 26);
            this.m_txtRhythm.MaxLength = 6;
            this.m_txtRhythm.Name = "m_txtRhythm";
            this.m_txtRhythm.Size = new System.Drawing.Size(64, 23);
            this.m_txtRhythm.TabIndex = 1100;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(334, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "次/分";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(252, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 14);
            this.label15.TabIndex = 2;
            this.label15.Text = "R";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(377, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 14);
            this.label16.TabIndex = 2;
            this.label16.Text = "Bp";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(515, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 14);
            this.label17.TabIndex = 3;
            this.label17.Text = "mmHg";
            // 
            // m_txtBp_Shink
            // 
            this.m_txtBp_Shink.AccessibleDescription = "血压>>收缩压";
            this.m_txtBp_Shink.Location = new System.Drawing.Point(401, 25);
            this.m_txtBp_Shink.MaxLength = 6;
            this.m_txtBp_Shink.Name = "m_txtBp_Shink";
            this.m_txtBp_Shink.Size = new System.Drawing.Size(48, 23);
            this.m_txtBp_Shink.TabIndex = 1150;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(446, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 20);
            this.label18.TabIndex = 3;
            this.label18.Text = "/";
            // 
            // m_txtBp_Extend
            // 
            this.m_txtBp_Extend.AccessibleDescription = "血压>>舒张压";
            this.m_txtBp_Extend.Location = new System.Drawing.Point(465, 25);
            this.m_txtBp_Extend.MaxLength = 6;
            this.m_txtBp_Extend.Name = "m_txtBp_Extend";
            this.m_txtBp_Extend.Size = new System.Drawing.Size(48, 23);
            this.m_txtBp_Extend.TabIndex = 1200;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(552, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 14);
            this.label19.TabIndex = 2;
            this.label19.Text = "体重";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(657, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 14);
            this.label20.TabIndex = 3;
            this.label20.Text = "Kg";
            // 
            // m_txtAvoirdupois
            // 
            this.m_txtAvoirdupois.AccessibleDescription = "体重";
            this.m_txtAvoirdupois.Location = new System.Drawing.Point(589, 26);
            this.m_txtAvoirdupois.MaxLength = 6;
            this.m_txtAvoirdupois.Name = "m_txtAvoirdupois";
            this.m_txtAvoirdupois.Size = new System.Drawing.Size(64, 23);
            this.m_txtAvoirdupois.TabIndex = 1250;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSensitive0);
            this.groupBox3.Controls.Add(this.chkSensitive1);
            this.groupBox3.Controls.Add(this.chkSensitive2);
            this.groupBox3.Controls.Add(this.chkSensitive3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.m_txtSensitiveOther);
            this.groupBox3.Location = new System.Drawing.Point(8, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 56);
            this.groupBox3.TabIndex = 10000016;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "药物过敏史";
            // 
            // chkSensitive0
            // 
            this.chkSensitive0.AccessibleDescription = "药物过敏史>>无";
            this.chkSensitive0.Location = new System.Drawing.Point(16, 24);
            this.chkSensitive0.Name = "chkSensitive0";
            this.chkSensitive0.Size = new System.Drawing.Size(40, 24);
            this.chkSensitive0.TabIndex = 700;
            this.chkSensitive0.Text = "无";
            // 
            // chkSensitive1
            // 
            this.chkSensitive1.AccessibleDescription = "药物过敏史>>青霉素";
            this.chkSensitive1.Location = new System.Drawing.Point(88, 24);
            this.chkSensitive1.Name = "chkSensitive1";
            this.chkSensitive1.Size = new System.Drawing.Size(72, 24);
            this.chkSensitive1.TabIndex = 750;
            this.chkSensitive1.Text = "青霉素";
            // 
            // chkSensitive2
            // 
            this.chkSensitive2.AccessibleDescription = "药物过敏史>>链霉素";
            this.chkSensitive2.Location = new System.Drawing.Point(192, 24);
            this.chkSensitive2.Name = "chkSensitive2";
            this.chkSensitive2.Size = new System.Drawing.Size(72, 24);
            this.chkSensitive2.TabIndex = 800;
            this.chkSensitive2.Text = "链霉素";
            // 
            // chkSensitive3
            // 
            this.chkSensitive3.AccessibleDescription = "药物过敏史>>磺胺类";
            this.chkSensitive3.Location = new System.Drawing.Point(288, 24);
            this.chkSensitive3.Name = "chkSensitive3";
            this.chkSensitive3.Size = new System.Drawing.Size(72, 24);
            this.chkSensitive3.TabIndex = 850;
            this.chkSensitive3.Text = "磺胺类";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(392, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 10000013;
            this.label8.Text = "其它";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtSensitiveOther
            // 
            this.m_txtSensitiveOther.AccessibleDescription = "药物过敏史>>其它";
            this.m_txtSensitiveOther.BackColor = System.Drawing.Color.White;
            this.m_txtSensitiveOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSensitiveOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtSensitiveOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSensitiveOther.Location = new System.Drawing.Point(448, 24);
            this.m_txtSensitiveOther.m_BlnIgnoreUserInfo = false;
            this.m_txtSensitiveOther.m_BlnPartControl = false;
            this.m_txtSensitiveOther.m_BlnReadOnly = false;
            this.m_txtSensitiveOther.m_BlnUnderLineDST = false;
            this.m_txtSensitiveOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSensitiveOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSensitiveOther.m_IntCanModifyTime = 6;
            this.m_txtSensitiveOther.m_IntPartControlLength = 0;
            this.m_txtSensitiveOther.m_IntPartControlStartIndex = 0;
            this.m_txtSensitiveOther.m_StrUserID = "";
            this.m_txtSensitiveOther.m_StrUserName = "";
            this.m_txtSensitiveOther.MaxLength = 8000;
            this.m_txtSensitiveOther.Multiline = false;
            this.m_txtSensitiveOther.Name = "m_txtSensitiveOther";
            this.m_txtSensitiveOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSensitiveOther.Size = new System.Drawing.Size(344, 23);
            this.m_txtSensitiveOther.TabIndex = 900;
            this.m_txtSensitiveOther.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtChiefComplain);
            this.groupBox2.Location = new System.Drawing.Point(8, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 56);
            this.groupBox2.TabIndex = 10000015;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "主诉(症状与体征)";
            // 
            // m_txtChiefComplain
            // 
            this.m_txtChiefComplain.AccessibleDescription = "主诉";
            this.m_txtChiefComplain.BackColor = System.Drawing.Color.White;
            this.m_txtChiefComplain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtChiefComplain.ForeColor = System.Drawing.Color.Black;
            this.m_txtChiefComplain.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtChiefComplain.Location = new System.Drawing.Point(8, 24);
            this.m_txtChiefComplain.m_BlnIgnoreUserInfo = false;
            this.m_txtChiefComplain.m_BlnPartControl = false;
            this.m_txtChiefComplain.m_BlnReadOnly = false;
            this.m_txtChiefComplain.m_BlnUnderLineDST = false;
            this.m_txtChiefComplain.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtChiefComplain.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtChiefComplain.m_IntCanModifyTime = 6;
            this.m_txtChiefComplain.m_IntPartControlLength = 0;
            this.m_txtChiefComplain.m_IntPartControlStartIndex = 0;
            this.m_txtChiefComplain.m_StrUserID = "";
            this.m_txtChiefComplain.m_StrUserName = "";
            this.m_txtChiefComplain.MaxLength = 8000;
            this.m_txtChiefComplain.Multiline = false;
            this.m_txtChiefComplain.Name = "m_txtChiefComplain";
            this.m_txtChiefComplain.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtChiefComplain.Size = new System.Drawing.Size(784, 23);
            this.m_txtChiefComplain.TabIndex = 650;
            this.m_txtChiefComplain.Text = "";
            // 
            // m_txtInPatientDiagnose
            // 
            this.m_txtInPatientDiagnose.AccessibleDescription = "入院诊断";
            this.m_txtInPatientDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtInPatientDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInPatientDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtInPatientDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInPatientDiagnose.Location = new System.Drawing.Point(456, 40);
            this.m_txtInPatientDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtInPatientDiagnose.m_BlnPartControl = false;
            this.m_txtInPatientDiagnose.m_BlnReadOnly = false;
            this.m_txtInPatientDiagnose.m_BlnUnderLineDST = false;
            this.m_txtInPatientDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInPatientDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInPatientDiagnose.m_IntCanModifyTime = 6;
            this.m_txtInPatientDiagnose.m_IntPartControlLength = 0;
            this.m_txtInPatientDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtInPatientDiagnose.m_StrUserID = "";
            this.m_txtInPatientDiagnose.m_StrUserName = "";
            this.m_txtInPatientDiagnose.MaxLength = 8000;
            this.m_txtInPatientDiagnose.Multiline = false;
            this.m_txtInPatientDiagnose.Name = "m_txtInPatientDiagnose";
            this.m_txtInPatientDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInPatientDiagnose.Size = new System.Drawing.Size(352, 23);
            this.m_txtInPatientDiagnose.TabIndex = 500;
            this.m_txtInPatientDiagnose.Text = "";
            // 
            // lblTitle5
            // 
            this.lblTitle5.AutoSize = true;
            this.lblTitle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle5.Location = new System.Drawing.Point(384, 40);
            this.lblTitle5.Name = "lblTitle5";
            this.lblTitle5.Size = new System.Drawing.Size(70, 14);
            this.lblTitle5.TabIndex = 10000013;
            this.lblTitle5.Text = "入院诊断:";
            this.lblTitle5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbWalk);
            this.groupBox1.Controls.Add(this.rdbHand);
            this.groupBox1.Controls.Add(this.rdbWheel);
            this.groupBox1.Controls.Add(this.rdbFlat);
            this.groupBox1.Controls.Add(this.rdbBack);
            this.groupBox1.Controls.Add(this.rdbArm);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 56);
            this.groupBox1.TabIndex = 10000012;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入院方式:";
            // 
            // rdbWalk
            // 
            this.rdbWalk.AccessibleDescription = "入院方式>>步行";
            this.rdbWalk.Location = new System.Drawing.Point(8, 24);
            this.rdbWalk.Name = "rdbWalk";
            this.rdbWalk.Size = new System.Drawing.Size(56, 24);
            this.rdbWalk.TabIndex = 100;
            this.rdbWalk.Text = "步行";
            // 
            // rdbHand
            // 
            this.rdbHand.AccessibleDescription = "入院方式>>扶行";
            this.rdbHand.Location = new System.Drawing.Point(70, 24);
            this.rdbHand.Name = "rdbHand";
            this.rdbHand.Size = new System.Drawing.Size(56, 24);
            this.rdbHand.TabIndex = 150;
            this.rdbHand.Text = "扶行";
            // 
            // rdbWheel
            // 
            this.rdbWheel.AccessibleDescription = "入院方式>>轮椅";
            this.rdbWheel.Location = new System.Drawing.Point(132, 24);
            this.rdbWheel.Name = "rdbWheel";
            this.rdbWheel.Size = new System.Drawing.Size(56, 24);
            this.rdbWheel.TabIndex = 200;
            this.rdbWheel.Text = "轮椅";
            // 
            // rdbFlat
            // 
            this.rdbFlat.AccessibleDescription = "入院方式>>平车";
            this.rdbFlat.Location = new System.Drawing.Point(194, 24);
            this.rdbFlat.Name = "rdbFlat";
            this.rdbFlat.Size = new System.Drawing.Size(56, 24);
            this.rdbFlat.TabIndex = 250;
            this.rdbFlat.Text = "平车";
            // 
            // rdbBack
            // 
            this.rdbBack.AccessibleDescription = "入院方式>>背";
            this.rdbBack.Location = new System.Drawing.Point(256, 24);
            this.rdbBack.Name = "rdbBack";
            this.rdbBack.Size = new System.Drawing.Size(56, 24);
            this.rdbBack.TabIndex = 300;
            this.rdbBack.Text = "背";
            // 
            // rdbArm
            // 
            this.rdbArm.AccessibleDescription = "入院方式>>抱入";
            this.rdbArm.Location = new System.Drawing.Point(318, 24);
            this.rdbArm.Name = "rdbArm";
            this.rdbArm.Size = new System.Drawing.Size(56, 24);
            this.rdbArm.TabIndex = 350;
            this.rdbArm.Text = "抱入";
            // 
            // m_txtCaseHistory
            // 
            this.m_txtCaseHistory.AccessibleDescription = "既往史";
            this.m_txtCaseHistory.BackColor = System.Drawing.Color.White;
            this.m_txtCaseHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaseHistory.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaseHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaseHistory.Location = new System.Drawing.Point(64, 72);
            this.m_txtCaseHistory.m_BlnIgnoreUserInfo = false;
            this.m_txtCaseHistory.m_BlnPartControl = false;
            this.m_txtCaseHistory.m_BlnReadOnly = false;
            this.m_txtCaseHistory.m_BlnUnderLineDST = false;
            this.m_txtCaseHistory.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaseHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaseHistory.m_IntCanModifyTime = 6;
            this.m_txtCaseHistory.m_IntPartControlLength = 0;
            this.m_txtCaseHistory.m_IntPartControlStartIndex = 0;
            this.m_txtCaseHistory.m_StrUserID = "";
            this.m_txtCaseHistory.m_StrUserName = "";
            this.m_txtCaseHistory.MaxLength = 8000;
            this.m_txtCaseHistory.Multiline = false;
            this.m_txtCaseHistory.Name = "m_txtCaseHistory";
            this.m_txtCaseHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaseHistory.Size = new System.Drawing.Size(320, 23);
            this.m_txtCaseHistory.TabIndex = 550;
            this.m_txtCaseHistory.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(8, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 10000013;
            this.label6.Text = "既往史:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtFamilyHistory
            // 
            this.m_txtFamilyHistory.AccessibleDescription = "家族史";
            this.m_txtFamilyHistory.BackColor = System.Drawing.Color.White;
            this.m_txtFamilyHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFamilyHistory.ForeColor = System.Drawing.Color.Black;
            this.m_txtFamilyHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFamilyHistory.Location = new System.Drawing.Point(456, 72);
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
            this.m_txtFamilyHistory.MaxLength = 8000;
            this.m_txtFamilyHistory.Multiline = false;
            this.m_txtFamilyHistory.Name = "m_txtFamilyHistory";
            this.m_txtFamilyHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFamilyHistory.Size = new System.Drawing.Size(352, 23);
            this.m_txtFamilyHistory.TabIndex = 600;
            this.m_txtFamilyHistory.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(392, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 14);
            this.label7.TabIndex = 10000013;
            this.label7.Text = "家族史:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox18);
            this.tabPage2.Controls.Add(this.groupBox11);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(816, 507);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "病人资料二";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.groupBox22);
            this.groupBox18.Controls.Add(this.groupBox21);
            this.groupBox18.Controls.Add(this.groupBox19);
            this.groupBox18.Controls.Add(this.groupBox20);
            this.groupBox18.Location = new System.Drawing.Point(8, 312);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(800, 192);
            this.groupBox18.TabIndex = 1;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "三、心理社会方面";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.chkFamilyForm0);
            this.groupBox22.Controls.Add(this.chkFamilyForm1);
            this.groupBox22.Controls.Add(this.chkFamilyForm2);
            this.groupBox22.Controls.Add(this.chkFamilyForm3);
            this.groupBox22.Controls.Add(this.m_txtFamilyFormOther);
            this.groupBox22.Controls.Add(this.label32);
            this.groupBox22.Location = new System.Drawing.Point(416, 136);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(376, 48);
            this.groupBox22.TabIndex = 3;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "家庭同住人口构成";
            // 
            // chkFamilyForm0
            // 
            this.chkFamilyForm0.AccessibleDescription = "家庭同住人口构成>>父母";
            this.chkFamilyForm0.Location = new System.Drawing.Point(8, 16);
            this.chkFamilyForm0.Name = "chkFamilyForm0";
            this.chkFamilyForm0.Size = new System.Drawing.Size(56, 24);
            this.chkFamilyForm0.TabIndex = 6450;
            this.chkFamilyForm0.Text = "父母";
            // 
            // chkFamilyForm1
            // 
            this.chkFamilyForm1.AccessibleDescription = "家庭同住人口构成>>独居";
            this.chkFamilyForm1.Location = new System.Drawing.Point(64, 16);
            this.chkFamilyForm1.Name = "chkFamilyForm1";
            this.chkFamilyForm1.Size = new System.Drawing.Size(56, 24);
            this.chkFamilyForm1.TabIndex = 6500;
            this.chkFamilyForm1.Text = "独居";
            // 
            // chkFamilyForm2
            // 
            this.chkFamilyForm2.AccessibleDescription = "家庭同住人口构成>>配偶";
            this.chkFamilyForm2.Location = new System.Drawing.Point(120, 16);
            this.chkFamilyForm2.Name = "chkFamilyForm2";
            this.chkFamilyForm2.Size = new System.Drawing.Size(56, 24);
            this.chkFamilyForm2.TabIndex = 6550;
            this.chkFamilyForm2.Text = "配偶";
            // 
            // chkFamilyForm3
            // 
            this.chkFamilyForm3.AccessibleDescription = "家庭同住人口构成>>子女";
            this.chkFamilyForm3.Location = new System.Drawing.Point(176, 16);
            this.chkFamilyForm3.Name = "chkFamilyForm3";
            this.chkFamilyForm3.Size = new System.Drawing.Size(56, 24);
            this.chkFamilyForm3.TabIndex = 6600;
            this.chkFamilyForm3.Text = "子女";
            // 
            // m_txtFamilyFormOther
            // 
            this.m_txtFamilyFormOther.AccessibleDescription = "家庭同住人口构成>>其它";
            this.m_txtFamilyFormOther.BackColor = System.Drawing.Color.White;
            this.m_txtFamilyFormOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFamilyFormOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtFamilyFormOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFamilyFormOther.Location = new System.Drawing.Point(272, 16);
            this.m_txtFamilyFormOther.m_BlnIgnoreUserInfo = false;
            this.m_txtFamilyFormOther.m_BlnPartControl = false;
            this.m_txtFamilyFormOther.m_BlnReadOnly = false;
            this.m_txtFamilyFormOther.m_BlnUnderLineDST = false;
            this.m_txtFamilyFormOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFamilyFormOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFamilyFormOther.m_IntCanModifyTime = 6;
            this.m_txtFamilyFormOther.m_IntPartControlLength = 0;
            this.m_txtFamilyFormOther.m_IntPartControlStartIndex = 0;
            this.m_txtFamilyFormOther.m_StrUserID = "";
            this.m_txtFamilyFormOther.m_StrUserName = "";
            this.m_txtFamilyFormOther.MaxLength = 8000;
            this.m_txtFamilyFormOther.Multiline = false;
            this.m_txtFamilyFormOther.Name = "m_txtFamilyFormOther";
            this.m_txtFamilyFormOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFamilyFormOther.Size = new System.Drawing.Size(96, 23);
            this.m_txtFamilyFormOther.TabIndex = 6650;
            this.m_txtFamilyFormOther.Text = "";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(232, 19);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 14);
            this.label32.TabIndex = 5;
            this.label32.Text = "其它";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.chkInHospitalWorry0);
            this.groupBox21.Controls.Add(this.chkInHospitalWorry1);
            this.groupBox21.Controls.Add(this.chkInHospitalWorry2);
            this.groupBox21.Controls.Add(this.label31);
            this.groupBox21.Controls.Add(this.m_txtInHospitalWorryOther);
            this.groupBox21.Location = new System.Drawing.Point(8, 136);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(400, 48);
            this.groupBox21.TabIndex = 2;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "住院顾虑";
            // 
            // chkInHospitalWorry0
            // 
            this.chkInHospitalWorry0.AccessibleDescription = "住院顾虑>>无";
            this.chkInHospitalWorry0.Location = new System.Drawing.Point(8, 16);
            this.chkInHospitalWorry0.Name = "chkInHospitalWorry0";
            this.chkInHospitalWorry0.Size = new System.Drawing.Size(40, 24);
            this.chkInHospitalWorry0.TabIndex = 6250;
            this.chkInHospitalWorry0.Text = "无";
            // 
            // chkInHospitalWorry1
            // 
            this.chkInHospitalWorry1.AccessibleDescription = "就业状态>>经济困难";
            this.chkInHospitalWorry1.Location = new System.Drawing.Point(56, 16);
            this.chkInHospitalWorry1.Name = "chkInHospitalWorry1";
            this.chkInHospitalWorry1.Size = new System.Drawing.Size(88, 24);
            this.chkInHospitalWorry1.TabIndex = 6300;
            this.chkInHospitalWorry1.Text = "经济困难";
            // 
            // chkInHospitalWorry2
            // 
            this.chkInHospitalWorry2.AccessibleDescription = "就业状态>>疾病预后";
            this.chkInHospitalWorry2.Location = new System.Drawing.Point(144, 16);
            this.chkInHospitalWorry2.Name = "chkInHospitalWorry2";
            this.chkInHospitalWorry2.Size = new System.Drawing.Size(88, 24);
            this.chkInHospitalWorry2.TabIndex = 6350;
            this.chkInHospitalWorry2.Text = "疾病预后";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(232, 19);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 14);
            this.label31.TabIndex = 5;
            this.label31.Text = "其它";
            // 
            // m_txtInHospitalWorryOther
            // 
            this.m_txtInHospitalWorryOther.AccessibleDescription = "就业状态>>其它";
            this.m_txtInHospitalWorryOther.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalWorryOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalWorryOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtInHospitalWorryOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInHospitalWorryOther.Location = new System.Drawing.Point(272, 16);
            this.m_txtInHospitalWorryOther.m_BlnIgnoreUserInfo = false;
            this.m_txtInHospitalWorryOther.m_BlnPartControl = false;
            this.m_txtInHospitalWorryOther.m_BlnReadOnly = false;
            this.m_txtInHospitalWorryOther.m_BlnUnderLineDST = false;
            this.m_txtInHospitalWorryOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInHospitalWorryOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInHospitalWorryOther.m_IntCanModifyTime = 6;
            this.m_txtInHospitalWorryOther.m_IntPartControlLength = 0;
            this.m_txtInHospitalWorryOther.m_IntPartControlStartIndex = 0;
            this.m_txtInHospitalWorryOther.m_StrUserID = "";
            this.m_txtInHospitalWorryOther.m_StrUserName = "";
            this.m_txtInHospitalWorryOther.MaxLength = 8000;
            this.m_txtInHospitalWorryOther.Multiline = false;
            this.m_txtInHospitalWorryOther.Name = "m_txtInHospitalWorryOther";
            this.m_txtInHospitalWorryOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInHospitalWorryOther.Size = new System.Drawing.Size(120, 23);
            this.m_txtInHospitalWorryOther.TabIndex = 6400;
            this.m_txtInHospitalWorryOther.Text = "";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.chkFeeling0);
            this.groupBox19.Controls.Add(this.chkFeeling1);
            this.groupBox19.Controls.Add(this.chkFeeling2);
            this.groupBox19.Controls.Add(this.chkFeeling3);
            this.groupBox19.Controls.Add(this.chkFeeling4);
            this.groupBox19.Controls.Add(this.chkFeeling5);
            this.groupBox19.Controls.Add(this.chkFeeling6);
            this.groupBox19.Controls.Add(this.chkFeeling7);
            this.groupBox19.Controls.Add(this.chkFeeling8);
            this.groupBox19.Location = new System.Drawing.Point(8, 24);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(784, 48);
            this.groupBox19.TabIndex = 0;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "情绪";
            // 
            // chkFeeling0
            // 
            this.chkFeeling0.AccessibleDescription = "情绪>>稳定";
            this.chkFeeling0.Location = new System.Drawing.Point(16, 16);
            this.chkFeeling0.Name = "chkFeeling0";
            this.chkFeeling0.Size = new System.Drawing.Size(56, 24);
            this.chkFeeling0.TabIndex = 5400;
            this.chkFeeling0.Text = "稳定";
            // 
            // chkFeeling1
            // 
            this.chkFeeling1.AccessibleDescription = "情绪>>易激动";
            this.chkFeeling1.Location = new System.Drawing.Point(98, 16);
            this.chkFeeling1.Name = "chkFeeling1";
            this.chkFeeling1.Size = new System.Drawing.Size(72, 24);
            this.chkFeeling1.TabIndex = 5450;
            this.chkFeeling1.Text = "易激动 ";
            // 
            // chkFeeling2
            // 
            this.chkFeeling2.AccessibleDescription = "情绪>>焦虑";
            this.chkFeeling2.Location = new System.Drawing.Point(196, 16);
            this.chkFeeling2.Name = "chkFeeling2";
            this.chkFeeling2.Size = new System.Drawing.Size(56, 24);
            this.chkFeeling2.TabIndex = 5500;
            this.chkFeeling2.Text = "焦虑";
            // 
            // chkFeeling3
            // 
            this.chkFeeling3.AccessibleDescription = "情绪>>恐惧";
            this.chkFeeling3.Location = new System.Drawing.Point(278, 16);
            this.chkFeeling3.Name = "chkFeeling3";
            this.chkFeeling3.Size = new System.Drawing.Size(56, 24);
            this.chkFeeling3.TabIndex = 5550;
            this.chkFeeling3.Text = "恐惧";
            // 
            // chkFeeling4
            // 
            this.chkFeeling4.AccessibleDescription = "情绪>>孤独无助感";
            this.chkFeeling4.Location = new System.Drawing.Point(360, 16);
            this.chkFeeling4.Name = "chkFeeling4";
            this.chkFeeling4.Size = new System.Drawing.Size(96, 24);
            this.chkFeeling4.TabIndex = 5600;
            this.chkFeeling4.Text = "孤独无助感";
            // 
            // chkFeeling5
            // 
            this.chkFeeling5.AccessibleDescription = "情绪>>压抑";
            this.chkFeeling5.Location = new System.Drawing.Point(482, 16);
            this.chkFeeling5.Name = "chkFeeling5";
            this.chkFeeling5.Size = new System.Drawing.Size(56, 24);
            this.chkFeeling5.TabIndex = 5650;
            this.chkFeeling5.Text = "压抑";
            // 
            // chkFeeling6
            // 
            this.chkFeeling6.AccessibleDescription = "情绪>>悲哀";
            this.chkFeeling6.Location = new System.Drawing.Point(564, 16);
            this.chkFeeling6.Name = "chkFeeling6";
            this.chkFeeling6.Size = new System.Drawing.Size(56, 24);
            this.chkFeeling6.TabIndex = 5700;
            this.chkFeeling6.Text = "悲哀";
            // 
            // chkFeeling7
            // 
            this.chkFeeling7.AccessibleDescription = "情绪>>开朗";
            this.chkFeeling7.Location = new System.Drawing.Point(646, 16);
            this.chkFeeling7.Name = "chkFeeling7";
            this.chkFeeling7.Size = new System.Drawing.Size(56, 24);
            this.chkFeeling7.TabIndex = 5750;
            this.chkFeeling7.Text = "开朗";
            // 
            // chkFeeling8
            // 
            this.chkFeeling8.AccessibleDescription = "情绪>>无";
            this.chkFeeling8.Location = new System.Drawing.Point(728, 16);
            this.chkFeeling8.Name = "chkFeeling8";
            this.chkFeeling8.Size = new System.Drawing.Size(40, 24);
            this.chkFeeling8.TabIndex = 5800;
            this.chkFeeling8.Text = "无";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.chkJob6);
            this.groupBox20.Controls.Add(this.chkJob0);
            this.groupBox20.Controls.Add(this.chkJob1);
            this.groupBox20.Controls.Add(this.chkJob2);
            this.groupBox20.Controls.Add(this.chkJob3);
            this.groupBox20.Controls.Add(this.chkJob4);
            this.groupBox20.Controls.Add(this.chkJob5);
            this.groupBox20.Location = new System.Drawing.Point(8, 80);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(784, 48);
            this.groupBox20.TabIndex = 1;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "就业状态";
            // 
            // chkJob6
            // 
            this.chkJob6.AccessibleDescription = "就业状态>>个体户";
            this.chkJob6.Location = new System.Drawing.Point(692, 16);
            this.chkJob6.Name = "chkJob6";
            this.chkJob6.Size = new System.Drawing.Size(72, 24);
            this.chkJob6.TabIndex = 6200;
            this.chkJob6.Text = "个体户";
            // 
            // chkJob0
            // 
            this.chkJob0.AccessibleDescription = "就业状态>>固定职业";
            this.chkJob0.Location = new System.Drawing.Point(16, 16);
            this.chkJob0.Name = "chkJob0";
            this.chkJob0.Size = new System.Drawing.Size(96, 24);
            this.chkJob0.TabIndex = 5850;
            this.chkJob0.Text = "固定职业";
            // 
            // chkJob1
            // 
            this.chkJob1.AccessibleDescription = "就业状态>>短期丧失劳动力";
            this.chkJob1.Location = new System.Drawing.Point(130, 16);
            this.chkJob1.Name = "chkJob1";
            this.chkJob1.Size = new System.Drawing.Size(128, 24);
            this.chkJob1.TabIndex = 5900;
            this.chkJob1.Text = "短期丧失劳动力";
            // 
            // chkJob2
            // 
            this.chkJob2.AccessibleDescription = "就业状态>>长期丧失劳动力";
            this.chkJob2.Location = new System.Drawing.Point(276, 16);
            this.chkJob2.Name = "chkJob2";
            this.chkJob2.Size = new System.Drawing.Size(128, 24);
            this.chkJob2.TabIndex = 6000;
            this.chkJob2.Text = "长期丧失劳动力";
            // 
            // chkJob3
            // 
            this.chkJob3.AccessibleDescription = "就业状态>>失业";
            this.chkJob3.Location = new System.Drawing.Point(422, 16);
            this.chkJob3.Name = "chkJob3";
            this.chkJob3.Size = new System.Drawing.Size(72, 24);
            this.chkJob3.TabIndex = 6050;
            this.chkJob3.Text = "失业";
            // 
            // chkJob4
            // 
            this.chkJob4.AccessibleDescription = "就业状态>>无职业";
            this.chkJob4.Location = new System.Drawing.Point(512, 16);
            this.chkJob4.Name = "chkJob4";
            this.chkJob4.Size = new System.Drawing.Size(72, 24);
            this.chkJob4.TabIndex = 6100;
            this.chkJob4.Text = "无职业";
            // 
            // chkJob5
            // 
            this.chkJob5.AccessibleDescription = "就业状态>>退休";
            this.chkJob5.Location = new System.Drawing.Point(602, 16);
            this.chkJob5.Name = "chkJob5";
            this.chkJob5.Size = new System.Drawing.Size(72, 24);
            this.chkJob5.TabIndex = 6150;
            this.chkJob5.Text = "退休";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.groupBox17);
            this.groupBox11.Controls.Add(this.groupBox16);
            this.groupBox11.Controls.Add(this.groupBox15);
            this.groupBox11.Controls.Add(this.groupBox14);
            this.groupBox11.Controls.Add(this.groupBox13);
            this.groupBox11.Controls.Add(this.groupBox12);
            this.groupBox11.Location = new System.Drawing.Point(8, 8);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(800, 296);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "二、生活状况及自理程度";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.chkSelfSolve0);
            this.groupBox17.Controls.Add(this.chkSelfSolve1);
            this.groupBox17.Controls.Add(this.chkSelfSolve2);
            this.groupBox17.Location = new System.Drawing.Point(512, 240);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(280, 48);
            this.groupBox17.TabIndex = 5;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "生活自理能力";
            // 
            // chkSelfSolve0
            // 
            this.chkSelfSolve0.AccessibleDescription = "生活自理能力>>自理";
            this.chkSelfSolve0.Location = new System.Drawing.Point(16, 16);
            this.chkSelfSolve0.Name = "chkSelfSolve0";
            this.chkSelfSolve0.Size = new System.Drawing.Size(56, 24);
            this.chkSelfSolve0.TabIndex = 5250;
            this.chkSelfSolve0.Text = "自理";
            // 
            // chkSelfSolve1
            // 
            this.chkSelfSolve1.AccessibleDescription = "生活自理能力>>半自理";
            this.chkSelfSolve1.Location = new System.Drawing.Point(104, 16);
            this.chkSelfSolve1.Name = "chkSelfSolve1";
            this.chkSelfSolve1.Size = new System.Drawing.Size(72, 24);
            this.chkSelfSolve1.TabIndex = 5300;
            this.chkSelfSolve1.Text = "半自理";
            // 
            // chkSelfSolve2
            // 
            this.chkSelfSolve2.AccessibleDescription = "生活自理能力>>不能自理";
            this.chkSelfSolve2.Location = new System.Drawing.Point(184, 16);
            this.chkSelfSolve2.Name = "chkSelfSolve2";
            this.chkSelfSolve2.Size = new System.Drawing.Size(88, 24);
            this.chkSelfSolve2.TabIndex = 5350;
            this.chkSelfSolve2.Text = "不能自理";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.chkHobby0);
            this.groupBox16.Controls.Add(this.chkHobby1);
            this.groupBox16.Controls.Add(this.chkHobby2);
            this.groupBox16.Controls.Add(this.chkHobby3);
            this.groupBox16.Controls.Add(this.chkHobby4);
            this.groupBox16.Controls.Add(this.m_txtHobbyOther);
            this.groupBox16.Controls.Add(this.label30);
            this.groupBox16.Location = new System.Drawing.Point(8, 240);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(496, 48);
            this.groupBox16.TabIndex = 4;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "嗜好";
            // 
            // chkHobby0
            // 
            this.chkHobby0.AccessibleDescription = "嗜好>>无";
            this.chkHobby0.Location = new System.Drawing.Point(16, 16);
            this.chkHobby0.Name = "chkHobby0";
            this.chkHobby0.Size = new System.Drawing.Size(40, 24);
            this.chkHobby0.TabIndex = 4950;
            this.chkHobby0.Text = "无";
            // 
            // chkHobby1
            // 
            this.chkHobby1.AccessibleDescription = "排泄>>烟";
            this.chkHobby1.Location = new System.Drawing.Point(72, 16);
            this.chkHobby1.Name = "chkHobby1";
            this.chkHobby1.Size = new System.Drawing.Size(40, 24);
            this.chkHobby1.TabIndex = 5000;
            this.chkHobby1.Text = "烟";
            // 
            // chkHobby2
            // 
            this.chkHobby2.AccessibleDescription = "排泄>>酒";
            this.chkHobby2.Location = new System.Drawing.Point(128, 16);
            this.chkHobby2.Name = "chkHobby2";
            this.chkHobby2.Size = new System.Drawing.Size(40, 24);
            this.chkHobby2.TabIndex = 5050;
            this.chkHobby2.Text = "酒";
            // 
            // chkHobby3
            // 
            this.chkHobby3.AccessibleDescription = "排泄>>甜食";
            this.chkHobby3.Location = new System.Drawing.Point(184, 16);
            this.chkHobby3.Name = "chkHobby3";
            this.chkHobby3.Size = new System.Drawing.Size(56, 24);
            this.chkHobby3.TabIndex = 5100;
            this.chkHobby3.Text = "甜食";
            // 
            // chkHobby4
            // 
            this.chkHobby4.AccessibleDescription = "排泄>>咸食";
            this.chkHobby4.Location = new System.Drawing.Point(240, 16);
            this.chkHobby4.Name = "chkHobby4";
            this.chkHobby4.Size = new System.Drawing.Size(56, 24);
            this.chkHobby4.TabIndex = 5150;
            this.chkHobby4.Text = "咸食";
            // 
            // m_txtHobbyOther
            // 
            this.m_txtHobbyOther.AccessibleDescription = "排泄>>其它";
            this.m_txtHobbyOther.BackColor = System.Drawing.Color.White;
            this.m_txtHobbyOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHobbyOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtHobbyOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHobbyOther.Location = new System.Drawing.Point(344, 16);
            this.m_txtHobbyOther.m_BlnIgnoreUserInfo = false;
            this.m_txtHobbyOther.m_BlnPartControl = false;
            this.m_txtHobbyOther.m_BlnReadOnly = false;
            this.m_txtHobbyOther.m_BlnUnderLineDST = false;
            this.m_txtHobbyOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHobbyOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHobbyOther.m_IntCanModifyTime = 6;
            this.m_txtHobbyOther.m_IntPartControlLength = 0;
            this.m_txtHobbyOther.m_IntPartControlStartIndex = 0;
            this.m_txtHobbyOther.m_StrUserID = "";
            this.m_txtHobbyOther.m_StrUserName = "";
            this.m_txtHobbyOther.MaxLength = 8000;
            this.m_txtHobbyOther.Multiline = false;
            this.m_txtHobbyOther.Name = "m_txtHobbyOther";
            this.m_txtHobbyOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtHobbyOther.Size = new System.Drawing.Size(144, 23);
            this.m_txtHobbyOther.TabIndex = 5200;
            this.m_txtHobbyOther.Text = "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(304, 19);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 14);
            this.label30.TabIndex = 5;
            this.label30.Text = "其它";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.panel2);
            this.groupBox15.Controls.Add(this.panel1);
            this.groupBox15.Location = new System.Drawing.Point(8, 124);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(784, 112);
            this.groupBox15.TabIndex = 3;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "排泄";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkPee0);
            this.panel2.Controls.Add(this.chkPee1);
            this.panel2.Controls.Add(this.chkPee2);
            this.panel2.Controls.Add(this.chkPee3);
            this.panel2.Controls.Add(this.chkPee4);
            this.panel2.Controls.Add(this.chkPee5);
            this.panel2.Controls.Add(this.chkPee6);
            this.panel2.Controls.Add(this.chkPee7);
            this.panel2.Controls.Add(this.chkPee8);
            this.panel2.Controls.Add(this.chkPee9);
            this.panel2.Location = new System.Drawing.Point(8, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 40);
            this.panel2.TabIndex = 1;
            // 
            // chkPee0
            // 
            this.chkPee0.AccessibleDescription = "排泄>>小便正常";
            this.chkPee0.Location = new System.Drawing.Point(8, 8);
            this.chkPee0.Name = "chkPee0";
            this.chkPee0.Size = new System.Drawing.Size(88, 24);
            this.chkPee0.TabIndex = 4450;
            this.chkPee0.Text = "小便正常";
            // 
            // chkPee1
            // 
            this.chkPee1.AccessibleDescription = "排泄>>尿频";
            this.chkPee1.Location = new System.Drawing.Point(106, 8);
            this.chkPee1.Name = "chkPee1";
            this.chkPee1.Size = new System.Drawing.Size(56, 24);
            this.chkPee1.TabIndex = 4500;
            this.chkPee1.Text = "尿频";
            // 
            // chkPee2
            // 
            this.chkPee2.AccessibleDescription = "排泄>>尿急";
            this.chkPee2.Location = new System.Drawing.Point(172, 8);
            this.chkPee2.Name = "chkPee2";
            this.chkPee2.Size = new System.Drawing.Size(56, 24);
            this.chkPee2.TabIndex = 4550;
            this.chkPee2.Text = "尿急";
            // 
            // chkPee3
            // 
            this.chkPee3.AccessibleDescription = "排泄>>尿痛";
            this.chkPee3.Location = new System.Drawing.Point(238, 8);
            this.chkPee3.Name = "chkPee3";
            this.chkPee3.Size = new System.Drawing.Size(56, 24);
            this.chkPee3.TabIndex = 4600;
            this.chkPee3.Text = "尿痛";
            // 
            // chkPee4
            // 
            this.chkPee4.AccessibleDescription = "排泄>>血尿";
            this.chkPee4.Location = new System.Drawing.Point(304, 8);
            this.chkPee4.Name = "chkPee4";
            this.chkPee4.Size = new System.Drawing.Size(56, 24);
            this.chkPee4.TabIndex = 4650;
            this.chkPee4.Text = "血尿";
            // 
            // chkPee5
            // 
            this.chkPee5.AccessibleDescription = "排泄>>多尿";
            this.chkPee5.Location = new System.Drawing.Point(370, 8);
            this.chkPee5.Name = "chkPee5";
            this.chkPee5.Size = new System.Drawing.Size(56, 24);
            this.chkPee5.TabIndex = 4700;
            this.chkPee5.Text = "多尿";
            // 
            // chkPee6
            // 
            this.chkPee6.AccessibleDescription = "排泄>>少尿";
            this.chkPee6.Location = new System.Drawing.Point(436, 8);
            this.chkPee6.Name = "chkPee6";
            this.chkPee6.Size = new System.Drawing.Size(56, 24);
            this.chkPee6.TabIndex = 4750;
            this.chkPee6.Text = "少尿";
            // 
            // chkPee7
            // 
            this.chkPee7.AccessibleDescription = "排泄>>尿潴留";
            this.chkPee7.Location = new System.Drawing.Point(502, 8);
            this.chkPee7.Name = "chkPee7";
            this.chkPee7.Size = new System.Drawing.Size(72, 24);
            this.chkPee7.TabIndex = 4800;
            this.chkPee7.Text = "尿潴留";
            // 
            // chkPee8
            // 
            this.chkPee8.AccessibleDescription = "排泄>>尿失禁";
            this.chkPee8.Location = new System.Drawing.Point(584, 8);
            this.chkPee8.Name = "chkPee8";
            this.chkPee8.Size = new System.Drawing.Size(72, 24);
            this.chkPee8.TabIndex = 4850;
            this.chkPee8.Text = "尿失禁";
            // 
            // chkPee9
            // 
            this.chkPee9.AccessibleDescription = "排泄>>尿管";
            this.chkPee9.Location = new System.Drawing.Point(666, 8);
            this.chkPee9.Name = "chkPee9";
            this.chkPee9.Size = new System.Drawing.Size(56, 24);
            this.chkPee9.TabIndex = 4900;
            this.chkPee9.Text = "尿管";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_txtStoolOther);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.m_txtAstrictionDays);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.m_txtAstrictionTimes);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.chkStool);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.m_txtDiarrheaDays);
            this.panel1.Controls.Add(this.m_txtDiarrheaTimes);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Location = new System.Drawing.Point(8, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 40);
            this.panel1.TabIndex = 0;
            // 
            // m_txtStoolOther
            // 
            this.m_txtStoolOther.AccessibleDescription = "排泄>>大便>>其它";
            this.m_txtStoolOther.BackColor = System.Drawing.Color.White;
            this.m_txtStoolOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtStoolOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtStoolOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtStoolOther.Location = new System.Drawing.Point(560, 8);
            this.m_txtStoolOther.m_BlnIgnoreUserInfo = false;
            this.m_txtStoolOther.m_BlnPartControl = false;
            this.m_txtStoolOther.m_BlnReadOnly = false;
            this.m_txtStoolOther.m_BlnUnderLineDST = false;
            this.m_txtStoolOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtStoolOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtStoolOther.m_IntCanModifyTime = 6;
            this.m_txtStoolOther.m_IntPartControlLength = 0;
            this.m_txtStoolOther.m_IntPartControlStartIndex = 0;
            this.m_txtStoolOther.m_StrUserID = "";
            this.m_txtStoolOther.m_StrUserName = "";
            this.m_txtStoolOther.MaxLength = 8000;
            this.m_txtStoolOther.Multiline = false;
            this.m_txtStoolOther.Name = "m_txtStoolOther";
            this.m_txtStoolOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtStoolOther.Size = new System.Drawing.Size(200, 23);
            this.m_txtStoolOther.TabIndex = 4400;
            this.m_txtStoolOther.Text = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(520, 11);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 14);
            this.label29.TabIndex = 5;
            this.label29.Text = "其它";
            // 
            // m_txtAstrictionDays
            // 
            this.m_txtAstrictionDays.AccessibleDescription = "排泄>>便秘>>天";
            this.m_txtAstrictionDays.Location = new System.Drawing.Point(216, 8);
            this.m_txtAstrictionDays.MaxLength = 10;
            this.m_txtAstrictionDays.Name = "m_txtAstrictionDays";
            this.m_txtAstrictionDays.Size = new System.Drawing.Size(40, 23);
            this.m_txtAstrictionDays.TabIndex = 4250;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(184, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 14);
            this.label24.TabIndex = 3;
            this.label24.Text = "次/";
            // 
            // m_txtAstrictionTimes
            // 
            this.m_txtAstrictionTimes.AccessibleDescription = "排泄>>便秘>>次数";
            this.m_txtAstrictionTimes.Location = new System.Drawing.Point(144, 8);
            this.m_txtAstrictionTimes.MaxLength = 10;
            this.m_txtAstrictionTimes.Name = "m_txtAstrictionTimes";
            this.m_txtAstrictionTimes.Size = new System.Drawing.Size(40, 23);
            this.m_txtAstrictionTimes.TabIndex = 4200;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(104, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 14);
            this.label23.TabIndex = 1;
            this.label23.Text = "便秘";
            // 
            // chkStool
            // 
            this.chkStool.AccessibleDescription = "排泄>>大便正常";
            this.chkStool.Location = new System.Drawing.Point(8, 8);
            this.chkStool.Name = "chkStool";
            this.chkStool.Size = new System.Drawing.Size(88, 24);
            this.chkStool.TabIndex = 4150;
            this.chkStool.Text = "大便正常";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(264, 11);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 14);
            this.label25.TabIndex = 3;
            this.label25.Text = "天；";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(472, 11);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 14);
            this.label26.TabIndex = 3;
            this.label26.Text = "天；";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(312, 11);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 14);
            this.label27.TabIndex = 1;
            this.label27.Text = "腹泻";
            // 
            // m_txtDiarrheaDays
            // 
            this.m_txtDiarrheaDays.AccessibleDescription = "排泄>>腹泻>>天";
            this.m_txtDiarrheaDays.Location = new System.Drawing.Point(424, 8);
            this.m_txtDiarrheaDays.MaxLength = 10;
            this.m_txtDiarrheaDays.Name = "m_txtDiarrheaDays";
            this.m_txtDiarrheaDays.Size = new System.Drawing.Size(40, 23);
            this.m_txtDiarrheaDays.TabIndex = 4350;
            // 
            // m_txtDiarrheaTimes
            // 
            this.m_txtDiarrheaTimes.AccessibleDescription = "排泄>>腹泻>>次数";
            this.m_txtDiarrheaTimes.Location = new System.Drawing.Point(352, 8);
            this.m_txtDiarrheaTimes.MaxLength = 10;
            this.m_txtDiarrheaTimes.Name = "m_txtDiarrheaTimes";
            this.m_txtDiarrheaTimes.Size = new System.Drawing.Size(40, 23);
            this.m_txtDiarrheaTimes.TabIndex = 4300;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(392, 11);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(28, 14);
            this.label28.TabIndex = 3;
            this.label28.Text = "次/";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.chkSleep1);
            this.groupBox14.Controls.Add(this.chkSleep3);
            this.groupBox14.Controls.Add(this.chkSleep0);
            this.groupBox14.Controls.Add(this.chkSleep2);
            this.groupBox14.Controls.Add(this.chkSleep4);
            this.groupBox14.Location = new System.Drawing.Point(376, 72);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(416, 48);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "睡眠";
            // 
            // chkSleep1
            // 
            this.chkSleep1.AccessibleDescription = "睡眠>>入睡困难";
            this.chkSleep1.Location = new System.Drawing.Point(72, 16);
            this.chkSleep1.Name = "chkSleep1";
            this.chkSleep1.Size = new System.Drawing.Size(88, 24);
            this.chkSleep1.TabIndex = 3950;
            this.chkSleep1.Text = "入睡困难";
            // 
            // chkSleep3
            // 
            this.chkSleep3.AccessibleDescription = "睡眠>>失眠";
            this.chkSleep3.Location = new System.Drawing.Point(248, 16);
            this.chkSleep3.Name = "chkSleep3";
            this.chkSleep3.Size = new System.Drawing.Size(56, 24);
            this.chkSleep3.TabIndex = 4050;
            this.chkSleep3.Text = "失眠";
            // 
            // chkSleep0
            // 
            this.chkSleep0.AccessibleDescription = "睡眠>>正常";
            this.chkSleep0.Location = new System.Drawing.Point(8, 16);
            this.chkSleep0.Name = "chkSleep0";
            this.chkSleep0.Size = new System.Drawing.Size(56, 24);
            this.chkSleep0.TabIndex = 3900;
            this.chkSleep0.Text = "正常";
            // 
            // chkSleep2
            // 
            this.chkSleep2.AccessibleDescription = "睡眠>>易多梦";
            this.chkSleep2.Location = new System.Drawing.Point(168, 16);
            this.chkSleep2.Name = "chkSleep2";
            this.chkSleep2.Size = new System.Drawing.Size(72, 24);
            this.chkSleep2.TabIndex = 4000;
            this.chkSleep2.Text = "易多梦";
            // 
            // chkSleep4
            // 
            this.chkSleep4.AccessibleDescription = "睡眠>>需用药入睡";
            this.chkSleep4.Location = new System.Drawing.Point(312, 16);
            this.chkSleep4.Name = "chkSleep4";
            this.chkSleep4.Size = new System.Drawing.Size(96, 24);
            this.chkSleep4.TabIndex = 4100;
            this.chkSleep4.Text = "需用药入睡";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.chkAppetite2);
            this.groupBox13.Controls.Add(this.chkAppetite3);
            this.groupBox13.Controls.Add(this.chkAppetite4);
            this.groupBox13.Controls.Add(this.chkAppetite5);
            this.groupBox13.Controls.Add(this.chkAppetite0);
            this.groupBox13.Controls.Add(this.chkAppetite1);
            this.groupBox13.Location = new System.Drawing.Point(8, 72);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(360, 48);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "食欲";
            // 
            // chkAppetite2
            // 
            this.chkAppetite2.AccessibleDescription = "食欲>>亢进";
            this.chkAppetite2.Location = new System.Drawing.Point(128, 16);
            this.chkAppetite2.Name = "chkAppetite2";
            this.chkAppetite2.Size = new System.Drawing.Size(56, 24);
            this.chkAppetite2.TabIndex = 3700;
            this.chkAppetite2.Text = "亢进";
            // 
            // chkAppetite3
            // 
            this.chkAppetite3.AccessibleDescription = "食欲>>下降";
            this.chkAppetite3.Location = new System.Drawing.Point(192, 16);
            this.chkAppetite3.Name = "chkAppetite3";
            this.chkAppetite3.Size = new System.Drawing.Size(56, 24);
            this.chkAppetite3.TabIndex = 3750;
            this.chkAppetite3.Text = "下降";
            // 
            // chkAppetite4
            // 
            this.chkAppetite4.AccessibleDescription = "食欲>>厌食";
            this.chkAppetite4.Location = new System.Drawing.Point(248, 16);
            this.chkAppetite4.Name = "chkAppetite4";
            this.chkAppetite4.Size = new System.Drawing.Size(56, 24);
            this.chkAppetite4.TabIndex = 3800;
            this.chkAppetite4.Text = "厌食";
            // 
            // chkAppetite5
            // 
            this.chkAppetite5.AccessibleDescription = "食欲>>无";
            this.chkAppetite5.Location = new System.Drawing.Point(312, 16);
            this.chkAppetite5.Name = "chkAppetite5";
            this.chkAppetite5.Size = new System.Drawing.Size(40, 24);
            this.chkAppetite5.TabIndex = 3850;
            this.chkAppetite5.Text = "无";
            // 
            // chkAppetite0
            // 
            this.chkAppetite0.AccessibleDescription = "食欲>>正常";
            this.chkAppetite0.Location = new System.Drawing.Point(8, 16);
            this.chkAppetite0.Name = "chkAppetite0";
            this.chkAppetite0.Size = new System.Drawing.Size(56, 24);
            this.chkAppetite0.TabIndex = 3600;
            this.chkAppetite0.Text = "正常";
            // 
            // chkAppetite1
            // 
            this.chkAppetite1.AccessibleDescription = "食欲>>增加";
            this.chkAppetite1.Location = new System.Drawing.Point(72, 16);
            this.chkAppetite1.Name = "chkAppetite1";
            this.chkAppetite1.Size = new System.Drawing.Size(56, 24);
            this.chkAppetite1.TabIndex = 3650;
            this.chkAppetite1.Text = "增加";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label52);
            this.groupBox12.Controls.Add(this.chkBiteSup0);
            this.groupBox12.Controls.Add(this.chkBiteSup1);
            this.groupBox12.Controls.Add(this.chkBiteSup2);
            this.groupBox12.Controls.Add(this.chkBiteSup3);
            this.groupBox12.Controls.Add(this.chkBiteSup4);
            this.groupBox12.Controls.Add(this.chkBiteSup6);
            this.groupBox12.Controls.Add(this.chkBiteSup7);
            this.groupBox12.Controls.Add(this.chkBiteSup8);
            this.groupBox12.Controls.Add(this.chkBiteSup9);
            this.groupBox12.Controls.Add(this.chkBiteSup10);
            this.groupBox12.Location = new System.Drawing.Point(8, 20);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(784, 48);
            this.groupBox12.TabIndex = 0;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "饮食";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(328, 19);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(70, 14);
            this.label52.TabIndex = 3551;
            this.label52.Text = "治疗饮食(";
            // 
            // chkBiteSup0
            // 
            this.chkBiteSup0.AccessibleDescription = "饮食>>普食";
            this.chkBiteSup0.Location = new System.Drawing.Point(8, 16);
            this.chkBiteSup0.Name = "chkBiteSup0";
            this.chkBiteSup0.Size = new System.Drawing.Size(56, 24);
            this.chkBiteSup0.TabIndex = 3050;
            this.chkBiteSup0.Text = "普食";
            // 
            // chkBiteSup1
            // 
            this.chkBiteSup1.AccessibleDescription = "饮食>>半流";
            this.chkBiteSup1.Location = new System.Drawing.Point(68, 16);
            this.chkBiteSup1.Name = "chkBiteSup1";
            this.chkBiteSup1.Size = new System.Drawing.Size(56, 24);
            this.chkBiteSup1.TabIndex = 3100;
            this.chkBiteSup1.Text = "半流";
            // 
            // chkBiteSup2
            // 
            this.chkBiteSup2.AccessibleDescription = "饮食>>全流";
            this.chkBiteSup2.Location = new System.Drawing.Point(128, 16);
            this.chkBiteSup2.Name = "chkBiteSup2";
            this.chkBiteSup2.Size = new System.Drawing.Size(56, 24);
            this.chkBiteSup2.TabIndex = 3150;
            this.chkBiteSup2.Text = "全流";
            // 
            // chkBiteSup3
            // 
            this.chkBiteSup3.AccessibleDescription = "饮食>>鼻饲";
            this.chkBiteSup3.Location = new System.Drawing.Point(188, 16);
            this.chkBiteSup3.Name = "chkBiteSup3";
            this.chkBiteSup3.Size = new System.Drawing.Size(56, 24);
            this.chkBiteSup3.TabIndex = 3200;
            this.chkBiteSup3.Text = "鼻饲";
            // 
            // chkBiteSup4
            // 
            this.chkBiteSup4.AccessibleDescription = "饮食>>禁食";
            this.chkBiteSup4.Location = new System.Drawing.Point(248, 16);
            this.chkBiteSup4.Name = "chkBiteSup4";
            this.chkBiteSup4.Size = new System.Drawing.Size(56, 24);
            this.chkBiteSup4.TabIndex = 3250;
            this.chkBiteSup4.Text = "禁食";
            // 
            // chkBiteSup6
            // 
            this.chkBiteSup6.AccessibleDescription = "饮食>>低盐";
            this.chkBiteSup6.Location = new System.Drawing.Point(408, 16);
            this.chkBiteSup6.Name = "chkBiteSup6";
            this.chkBiteSup6.Size = new System.Drawing.Size(56, 24);
            this.chkBiteSup6.TabIndex = 3350;
            this.chkBiteSup6.Text = "低盐";
            // 
            // chkBiteSup7
            // 
            this.chkBiteSup7.AccessibleDescription = "饮食>>低脂";
            this.chkBiteSup7.Location = new System.Drawing.Point(468, 16);
            this.chkBiteSup7.Name = "chkBiteSup7";
            this.chkBiteSup7.Size = new System.Drawing.Size(56, 24);
            this.chkBiteSup7.TabIndex = 3400;
            this.chkBiteSup7.Text = "低脂";
            // 
            // chkBiteSup8
            // 
            this.chkBiteSup8.AccessibleDescription = "饮食>>低胆固醇";
            this.chkBiteSup8.Location = new System.Drawing.Point(528, 16);
            this.chkBiteSup8.Name = "chkBiteSup8";
            this.chkBiteSup8.Size = new System.Drawing.Size(88, 24);
            this.chkBiteSup8.TabIndex = 3450;
            this.chkBiteSup8.Text = "低胆固醇";
            // 
            // chkBiteSup9
            // 
            this.chkBiteSup9.AccessibleDescription = "饮食>>低糖";
            this.chkBiteSup9.Location = new System.Drawing.Point(620, 16);
            this.chkBiteSup9.Name = "chkBiteSup9";
            this.chkBiteSup9.Size = new System.Drawing.Size(56, 24);
            this.chkBiteSup9.TabIndex = 3500;
            this.chkBiteSup9.Text = "低糖";
            // 
            // chkBiteSup10
            // 
            this.chkBiteSup10.AccessibleDescription = "饮食>>高蛋白";
            this.chkBiteSup10.Location = new System.Drawing.Point(680, 16);
            this.chkBiteSup10.Name = "chkBiteSup10";
            this.chkBiteSup10.Size = new System.Drawing.Size(96, 24);
            this.chkBiteSup10.TabIndex = 3550;
            this.chkBiteSup10.Text = "高蛋白  )";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblRecordTimeTitle);
            this.tabPage3.Controls.Add(this.m_dtpRecordTime);
            this.tabPage3.Controls.Add(this.m_cmdSign);
            this.tabPage3.Controls.Add(this.m_txtSign);
            this.tabPage3.Controls.Add(this.groupBox26);
            this.tabPage3.Controls.Add(this.groupBox23);
            this.tabPage3.Controls.Add(this.grpPip);
            this.tabPage3.Controls.Add(this.groupBox28);
            this.tabPage3.Controls.Add(this.groupBox29);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(816, 507);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "病人资料三";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblRecordTimeTitle
            // 
            this.lblRecordTimeTitle.AutoSize = true;
            this.lblRecordTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecordTimeTitle.Location = new System.Drawing.Point(272, 480);
            this.lblRecordTimeTitle.Name = "lblRecordTimeTitle";
            this.lblRecordTimeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblRecordTimeTitle.TabIndex = 5605;
            this.lblRecordTimeTitle.Text = "记录时间:";
            this.lblRecordTimeTitle.Visible = false;
            // 
            // m_dtpRecordTime
            // 
            this.m_dtpRecordTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpRecordTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpRecordTime.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.m_dtpRecordTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpRecordTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpRecordTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpRecordTime.Location = new System.Drawing.Point(344, 478);
            this.m_dtpRecordTime.m_BlnOnlyTime = false;
            this.m_dtpRecordTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpRecordTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpRecordTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpRecordTime.Name = "m_dtpRecordTime";
            this.m_dtpRecordTime.ReadOnly = false;
            this.m_dtpRecordTime.Size = new System.Drawing.Size(216, 22);
            this.m_dtpRecordTime.TabIndex = 7400;
            this.m_dtpRecordTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpRecordTime.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.Visible = false;
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(584, 475);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(104, 28);
            this.m_cmdSign.TabIndex = 5601;
            this.m_cmdSign.Tag = "1";
            this.m_cmdSign.Text = "负责护士签名:";
            // 
            // m_txtSign
            // 
            this.m_txtSign.AccessibleName = "NoDefault";
            this.m_txtSign.BackColor = System.Drawing.Color.White;
            this.m_txtSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtSign.Location = new System.Drawing.Point(696, 478);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.ReadOnly = true;
            this.m_txtSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtSign.TabIndex = 7450;
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.m_txtSpecilizedCheck);
            this.groupBox26.Location = new System.Drawing.Point(8, 92);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(800, 72);
            this.groupBox26.TabIndex = 1;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "专科检查";
            // 
            // m_txtSpecilizedCheck
            // 
            this.m_txtSpecilizedCheck.AccessibleDescription = "专科检查";
            this.m_txtSpecilizedCheck.BackColor = System.Drawing.Color.White;
            this.m_txtSpecilizedCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSpecilizedCheck.ForeColor = System.Drawing.Color.Black;
            this.m_txtSpecilizedCheck.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSpecilizedCheck.Location = new System.Drawing.Point(8, 24);
            this.m_txtSpecilizedCheck.m_BlnIgnoreUserInfo = false;
            this.m_txtSpecilizedCheck.m_BlnPartControl = false;
            this.m_txtSpecilizedCheck.m_BlnReadOnly = false;
            this.m_txtSpecilizedCheck.m_BlnUnderLineDST = false;
            this.m_txtSpecilizedCheck.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSpecilizedCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSpecilizedCheck.m_IntCanModifyTime = 6;
            this.m_txtSpecilizedCheck.m_IntPartControlLength = 0;
            this.m_txtSpecilizedCheck.m_IntPartControlStartIndex = 0;
            this.m_txtSpecilizedCheck.m_StrUserID = "";
            this.m_txtSpecilizedCheck.m_StrUserName = "";
            this.m_txtSpecilizedCheck.MaxLength = 8000;
            this.m_txtSpecilizedCheck.Name = "m_txtSpecilizedCheck";
            this.m_txtSpecilizedCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSpecilizedCheck.Size = new System.Drawing.Size(784, 40);
            this.m_txtSpecilizedCheck.TabIndex = 7200;
            this.m_txtSpecilizedCheck.Text = "";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.groupBox25);
            this.groupBox23.Controls.Add(this.groupBox24);
            this.groupBox23.Location = new System.Drawing.Point(8, 8);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(800, 80);
            this.groupBox23.TabIndex = 0;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "三、心理社会方面";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.chkKnowDisease0);
            this.groupBox25.Controls.Add(this.chkKnowDisease1);
            this.groupBox25.Controls.Add(this.chkKnowDisease2);
            this.groupBox25.Controls.Add(this.chkKnowDisease3);
            this.groupBox25.Location = new System.Drawing.Point(440, 24);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(352, 48);
            this.groupBox25.TabIndex = 1;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "对疾病的认识";
            // 
            // chkKnowDisease0
            // 
            this.chkKnowDisease0.AccessibleDescription = "对疾病的认识>>明白";
            this.chkKnowDisease0.Location = new System.Drawing.Point(16, 16);
            this.chkKnowDisease0.Name = "chkKnowDisease0";
            this.chkKnowDisease0.Size = new System.Drawing.Size(56, 24);
            this.chkKnowDisease0.TabIndex = 7000;
            this.chkKnowDisease0.Text = "明白";
            // 
            // chkKnowDisease1
            // 
            this.chkKnowDisease1.AccessibleDescription = "对疾病的认识>>一知半解";
            this.chkKnowDisease1.Location = new System.Drawing.Point(85, 16);
            this.chkKnowDisease1.Name = "chkKnowDisease1";
            this.chkKnowDisease1.Size = new System.Drawing.Size(88, 24);
            this.chkKnowDisease1.TabIndex = 7050;
            this.chkKnowDisease1.Text = "一知半解";
            // 
            // chkKnowDisease2
            // 
            this.chkKnowDisease2.AccessibleDescription = "对疾病的认识>>不知";
            this.chkKnowDisease2.Location = new System.Drawing.Point(186, 16);
            this.chkKnowDisease2.Name = "chkKnowDisease2";
            this.chkKnowDisease2.Size = new System.Drawing.Size(56, 24);
            this.chkKnowDisease2.TabIndex = 7100;
            this.chkKnowDisease2.Text = "不知";
            // 
            // chkKnowDisease3
            // 
            this.chkKnowDisease3.AccessibleDescription = "对疾病的认识>>基本清楚";
            this.chkKnowDisease3.Location = new System.Drawing.Point(255, 16);
            this.chkKnowDisease3.Name = "chkKnowDisease3";
            this.chkKnowDisease3.Size = new System.Drawing.Size(88, 24);
            this.chkKnowDisease3.TabIndex = 7150;
            this.chkKnowDisease3.Text = "基本清楚";
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.chkHealthNeed0);
            this.groupBox24.Controls.Add(this.chkHealthNeed1);
            this.groupBox24.Controls.Add(this.chkHealthNeed2);
            this.groupBox24.Controls.Add(this.chkHealthNeed3);
            this.groupBox24.Controls.Add(this.chkHealthNeed4);
            this.groupBox24.Location = new System.Drawing.Point(8, 24);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(424, 48);
            this.groupBox24.TabIndex = 0;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "家庭对患者的健康需要";
            // 
            // chkHealthNeed0
            // 
            this.chkHealthNeed0.AccessibleDescription = "家庭对患者的健康需要>>能满足";
            this.chkHealthNeed0.Location = new System.Drawing.Point(16, 16);
            this.chkHealthNeed0.Name = "chkHealthNeed0";
            this.chkHealthNeed0.Size = new System.Drawing.Size(72, 24);
            this.chkHealthNeed0.TabIndex = 6700;
            this.chkHealthNeed0.Text = "能满足";
            // 
            // chkHealthNeed1
            // 
            this.chkHealthNeed1.AccessibleDescription = "家庭对患者的健康需要>>不能满足";
            this.chkHealthNeed1.Location = new System.Drawing.Point(90, 16);
            this.chkHealthNeed1.Name = "chkHealthNeed1";
            this.chkHealthNeed1.Size = new System.Drawing.Size(88, 24);
            this.chkHealthNeed1.TabIndex = 6750;
            this.chkHealthNeed1.Text = "不能满足";
            // 
            // chkHealthNeed2
            // 
            this.chkHealthNeed2.AccessibleDescription = "家庭对患者的健康需要>>忽视";
            this.chkHealthNeed2.Location = new System.Drawing.Point(180, 16);
            this.chkHealthNeed2.Name = "chkHealthNeed2";
            this.chkHealthNeed2.Size = new System.Drawing.Size(56, 24);
            this.chkHealthNeed2.TabIndex = 6800;
            this.chkHealthNeed2.Text = "忽视";
            // 
            // chkHealthNeed3
            // 
            this.chkHealthNeed3.AccessibleDescription = "家庭对患者的健康需要>>寻求帮助";
            this.chkHealthNeed3.Location = new System.Drawing.Point(238, 16);
            this.chkHealthNeed3.Name = "chkHealthNeed3";
            this.chkHealthNeed3.Size = new System.Drawing.Size(88, 24);
            this.chkHealthNeed3.TabIndex = 6850;
            this.chkHealthNeed3.Text = "寻求帮助";
            // 
            // chkHealthNeed4
            // 
            this.chkHealthNeed4.AccessibleDescription = "家庭对患者的健康需要>>过于关心";
            this.chkHealthNeed4.Location = new System.Drawing.Point(328, 16);
            this.chkHealthNeed4.Name = "chkHealthNeed4";
            this.chkHealthNeed4.Size = new System.Drawing.Size(88, 24);
            this.chkHealthNeed4.TabIndex = 6900;
            this.chkHealthNeed4.Text = "过于关心";
            // 
            // grpPip
            // 
            this.grpPip.Controls.Add(this.m_txtPipInstance);
            this.grpPip.Location = new System.Drawing.Point(8, 168);
            this.grpPip.Name = "grpPip";
            this.grpPip.Size = new System.Drawing.Size(800, 72);
            this.grpPip.TabIndex = 1;
            this.grpPip.TabStop = false;
            this.grpPip.Text = "各种导管情况";
            // 
            // m_txtPipInstance
            // 
            this.m_txtPipInstance.AccessibleDescription = "各种导管情况";
            this.m_txtPipInstance.BackColor = System.Drawing.Color.White;
            this.m_txtPipInstance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPipInstance.ForeColor = System.Drawing.Color.Black;
            this.m_txtPipInstance.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPipInstance.Location = new System.Drawing.Point(8, 24);
            this.m_txtPipInstance.m_BlnIgnoreUserInfo = false;
            this.m_txtPipInstance.m_BlnPartControl = false;
            this.m_txtPipInstance.m_BlnReadOnly = false;
            this.m_txtPipInstance.m_BlnUnderLineDST = false;
            this.m_txtPipInstance.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPipInstance.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPipInstance.m_IntCanModifyTime = 6;
            this.m_txtPipInstance.m_IntPartControlLength = 0;
            this.m_txtPipInstance.m_IntPartControlStartIndex = 0;
            this.m_txtPipInstance.m_StrUserID = "";
            this.m_txtPipInstance.m_StrUserName = "";
            this.m_txtPipInstance.MaxLength = 8000;
            this.m_txtPipInstance.Name = "m_txtPipInstance";
            this.m_txtPipInstance.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPipInstance.Size = new System.Drawing.Size(784, 40);
            this.m_txtPipInstance.TabIndex = 7250;
            this.m_txtPipInstance.Text = "";
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.m_txtWoodInstance);
            this.groupBox28.Location = new System.Drawing.Point(8, 244);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(800, 96);
            this.groupBox28.TabIndex = 1;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "伤口情况";
            // 
            // m_txtWoodInstance
            // 
            this.m_txtWoodInstance.AccessibleDescription = "伤口情况";
            this.m_txtWoodInstance.BackColor = System.Drawing.Color.White;
            this.m_txtWoodInstance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWoodInstance.ForeColor = System.Drawing.Color.Black;
            this.m_txtWoodInstance.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWoodInstance.Location = new System.Drawing.Point(8, 24);
            this.m_txtWoodInstance.m_BlnIgnoreUserInfo = false;
            this.m_txtWoodInstance.m_BlnPartControl = false;
            this.m_txtWoodInstance.m_BlnReadOnly = false;
            this.m_txtWoodInstance.m_BlnUnderLineDST = false;
            this.m_txtWoodInstance.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtWoodInstance.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtWoodInstance.m_IntCanModifyTime = 6;
            this.m_txtWoodInstance.m_IntPartControlLength = 0;
            this.m_txtWoodInstance.m_IntPartControlStartIndex = 0;
            this.m_txtWoodInstance.m_StrUserID = "";
            this.m_txtWoodInstance.m_StrUserName = "";
            this.m_txtWoodInstance.MaxLength = 8000;
            this.m_txtWoodInstance.Name = "m_txtWoodInstance";
            this.m_txtWoodInstance.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtWoodInstance.Size = new System.Drawing.Size(784, 64);
            this.m_txtWoodInstance.TabIndex = 7300;
            this.m_txtWoodInstance.Text = "";
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.m_txtTendPlan);
            this.groupBox29.Location = new System.Drawing.Point(8, 344);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(800, 120);
            this.groupBox29.TabIndex = 1;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "实施护理计划";
            // 
            // m_txtTendPlan
            // 
            this.m_txtTendPlan.AccessibleDescription = "实施护理计划";
            this.m_txtTendPlan.BackColor = System.Drawing.Color.White;
            this.m_txtTendPlan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTendPlan.ForeColor = System.Drawing.Color.Black;
            this.m_txtTendPlan.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTendPlan.Location = new System.Drawing.Point(8, 24);
            this.m_txtTendPlan.m_BlnIgnoreUserInfo = false;
            this.m_txtTendPlan.m_BlnPartControl = false;
            this.m_txtTendPlan.m_BlnReadOnly = false;
            this.m_txtTendPlan.m_BlnUnderLineDST = false;
            this.m_txtTendPlan.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTendPlan.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTendPlan.m_IntCanModifyTime = 6;
            this.m_txtTendPlan.m_IntPartControlLength = 0;
            this.m_txtTendPlan.m_IntPartControlStartIndex = 0;
            this.m_txtTendPlan.m_StrUserID = "";
            this.m_txtTendPlan.m_StrUserName = "";
            this.m_txtTendPlan.MaxLength = 8000;
            this.m_txtTendPlan.Name = "m_txtTendPlan";
            this.m_txtTendPlan.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtTendPlan.Size = new System.Drawing.Size(784, 88);
            this.m_txtTendPlan.TabIndex = 7350;
            this.m_txtTendPlan.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_txtKnowledgeEdu2);
            this.tabPage4.Controls.Add(this.m_txtOtherDate3);
            this.tabPage4.Controls.Add(this.m_txtOtherDate2);
            this.tabPage4.Controls.Add(this.m_txtOtherDate1);
            this.tabPage4.Controls.Add(this.m_txtGuidanceDate3);
            this.tabPage4.Controls.Add(this.m_txtGuidanceDate1);
            this.tabPage4.Controls.Add(this.m_txtGuidanceDate2);
            this.tabPage4.Controls.Add(this.m_txtKnowledgeDate2);
            this.tabPage4.Controls.Add(this.m_txtKnowledgeDate1);
            this.tabPage4.Controls.Add(this.m_txtNoticeDate3);
            this.tabPage4.Controls.Add(this.m_txtNoticeDate1);
            this.tabPage4.Controls.Add(this.m_txtNoticeDate2);
            this.tabPage4.Controls.Add(this.m_txtMedicineDate3);
            this.tabPage4.Controls.Add(this.m_txtMedicineDate2);
            this.tabPage4.Controls.Add(this.m_txtMedicineDate1);
            this.tabPage4.Controls.Add(this.m_txtExplanDate3);
            this.tabPage4.Controls.Add(this.m_txtReadOutDate3);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign73);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign63);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign53);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign43);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign33);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign23);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign13);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign72);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign62);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign52);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign42);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign32);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign22);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign12);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign71);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign61);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign51);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign41);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign31);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign21);
            this.tabPage4.Controls.Add(this.m_cmdNurseSign11);
            this.tabPage4.Controls.Add(this.m_txtReadOutNurse3);
            this.tabPage4.Controls.Add(this.m_txtReadOutNurse2);
            this.tabPage4.Controls.Add(this.m_txtExplanNurse3);
            this.tabPage4.Controls.Add(this.m_txtExplanNurse2);
            this.tabPage4.Controls.Add(this.m_txtMedicineNurse3);
            this.tabPage4.Controls.Add(this.m_txtMedicineNurse2);
            this.tabPage4.Controls.Add(this.m_txtNoticeNurse3);
            this.tabPage4.Controls.Add(this.m_txtNoticeNurse2);
            this.tabPage4.Controls.Add(this.m_txtKnowledgeNurse3);
            this.tabPage4.Controls.Add(this.m_txtKnowledgeNurse2);
            this.tabPage4.Controls.Add(this.m_txtGuidanceNurse3);
            this.tabPage4.Controls.Add(this.m_txtGuidanceNurse2);
            this.tabPage4.Controls.Add(this.m_txtOtherNurse3);
            this.tabPage4.Controls.Add(this.m_txtOtherNurse2);
            this.tabPage4.Controls.Add(this.m_txtOtherNurse1);
            this.tabPage4.Controls.Add(this.m_txtGuidanceNurse1);
            this.tabPage4.Controls.Add(this.m_txtKnowledgeNurse1);
            this.tabPage4.Controls.Add(this.m_txtNoticeNurse1);
            this.tabPage4.Controls.Add(this.m_txtMedicineNurse1);
            this.tabPage4.Controls.Add(this.m_txtExplanNurse1);
            this.tabPage4.Controls.Add(this.m_txtReadOutNurse1);
            this.tabPage4.Controls.Add(this.m_txtReadOutDate1);
            this.tabPage4.Controls.Add(this.label51);
            this.tabPage4.Controls.Add(this.label48);
            this.tabPage4.Controls.Add(this.label47);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate11);
            this.tabPage4.Controls.Add(this.dtpEduTime);
            this.tabPage4.Controls.Add(this.label46);
            this.tabPage4.Controls.Add(this.label44);
            this.tabPage4.Controls.Add(this.m_txtReadOutEdu1);
            this.tabPage4.Controls.Add(this.label33);
            this.tabPage4.Controls.Add(this.m_txtReadOutEdu2);
            this.tabPage4.Controls.Add(this.m_txtReadOutDate2);
            this.tabPage4.Controls.Add(this.m_txtReadOutEdu3);
            this.tabPage4.Controls.Add(this.label34);
            this.tabPage4.Controls.Add(this.label35);
            this.tabPage4.Controls.Add(this.label36);
            this.tabPage4.Controls.Add(this.label37);
            this.tabPage4.Controls.Add(this.label38);
            this.tabPage4.Controls.Add(this.label39);
            this.tabPage4.Controls.Add(this.label40);
            this.tabPage4.Controls.Add(this.label41);
            this.tabPage4.Controls.Add(this.label43);
            this.tabPage4.Controls.Add(this.label45);
            this.tabPage4.Controls.Add(this.label42);
            this.tabPage4.Controls.Add(this.m_txtExplanEdu1);
            this.tabPage4.Controls.Add(this.m_txtExplanDate1);
            this.tabPage4.Controls.Add(this.m_txtExplanEdu2);
            this.tabPage4.Controls.Add(this.m_txtExplanDate2);
            this.tabPage4.Controls.Add(this.m_txtExplanEdu3);
            this.tabPage4.Controls.Add(this.m_txtMedicineEdu1);
            this.tabPage4.Controls.Add(this.m_txtMedicineEdu2);
            this.tabPage4.Controls.Add(this.m_txtMedicineEdu3);
            this.tabPage4.Controls.Add(this.m_txtNoticeEdu1);
            this.tabPage4.Controls.Add(this.m_txtNoticeEdu2);
            this.tabPage4.Controls.Add(this.m_txtNoticeEdu3);
            this.tabPage4.Controls.Add(this.m_txtKnowledgeEdu3);
            this.tabPage4.Controls.Add(this.m_txtKnowledgeDate3);
            this.tabPage4.Controls.Add(this.m_txtKnowledgeEdu1);
            this.tabPage4.Controls.Add(this.m_txtGuidanceEdu1);
            this.tabPage4.Controls.Add(this.m_txtGuidanceEdu3);
            this.tabPage4.Controls.Add(this.m_txtGuidanceEdu2);
            this.tabPage4.Controls.Add(this.m_txtOtherEdu2);
            this.tabPage4.Controls.Add(this.m_txtOtherEdu3);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate73);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate63);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate53);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate43);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate33);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate72);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate62);
            this.tabPage4.Controls.Add(this.m_txtOtherEdu1);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate52);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate42);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate23);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate32);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate13);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate22);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate71);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate12);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate61);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate51);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate41);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate31);
            this.tabPage4.Controls.Add(this.dtpNurseSignDate21);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(816, 507);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "病人健康教育评估表";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // m_txtKnowledgeEdu2
            // 
            this.m_txtKnowledgeEdu2.AccessibleDescription = "有关知识>>第三次完成>>教育项目";
            this.m_txtKnowledgeEdu2.AccessibleName = "";
            this.m_txtKnowledgeEdu2.BackColor = System.Drawing.Color.White;
            this.m_txtKnowledgeEdu2.BorderColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeEdu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeEdu2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKnowledgeEdu2.ForeColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeEdu2.Location = new System.Drawing.Point(348, 284);
            this.m_txtKnowledgeEdu2.Multiline = true;
            this.m_txtKnowledgeEdu2.Name = "m_txtKnowledgeEdu2";
            this.m_txtKnowledgeEdu2.Size = new System.Drawing.Size(76, 44);
            this.m_txtKnowledgeEdu2.TabIndex = 7484;
            this.m_txtKnowledgeEdu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeEdu2.Enter += new System.EventHandler(this.m_txtKnowledgeEdu2_Enter);
            // 
            // m_txtOtherDate3
            // 
            this.m_txtOtherDate3.AccessibleDescription = "其他>>第三次完成>>日期";
            this.m_txtOtherDate3.AccessibleName = "NoDefault";
            this.m_txtOtherDate3.BackColor = System.Drawing.Color.White;
            this.m_txtOtherDate3.BorderColor = System.Drawing.Color.Black;
            this.m_txtOtherDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherDate3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherDate3.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherDate3.Location = new System.Drawing.Point(655, 402);
            this.m_txtOtherDate3.Multiline = true;
            this.m_txtOtherDate3.Name = "m_txtOtherDate3";
            this.m_txtOtherDate3.Size = new System.Drawing.Size(136, 22);
            this.m_txtOtherDate3.TabIndex = 7513;
            this.m_txtOtherDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherDate3.Enter += new System.EventHandler(this.m_txtOtherDate3_Enter);
            // 
            // m_txtOtherDate2
            // 
            this.m_txtOtherDate2.AccessibleDescription = "其他>>第二次完成>>日期";
            this.m_txtOtherDate2.AccessibleName = "NoDefault";
            this.m_txtOtherDate2.BackColor = System.Drawing.Color.White;
            this.m_txtOtherDate2.BorderColor = System.Drawing.Color.Black;
            this.m_txtOtherDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherDate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherDate2.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherDate2.Location = new System.Drawing.Point(423, 402);
            this.m_txtOtherDate2.Multiline = true;
            this.m_txtOtherDate2.Name = "m_txtOtherDate2";
            this.m_txtOtherDate2.Size = new System.Drawing.Size(136, 22);
            this.m_txtOtherDate2.TabIndex = 7492;
            this.m_txtOtherDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherDate2.Enter += new System.EventHandler(this.m_txtOtherDate2_Enter);
            // 
            // m_txtOtherDate1
            // 
            this.m_txtOtherDate1.AccessibleDescription = "其他>>第一次完成>>日期";
            this.m_txtOtherDate1.AccessibleName = "NoDefault";
            this.m_txtOtherDate1.BackColor = System.Drawing.Color.White;
            this.m_txtOtherDate1.BorderColor = System.Drawing.Color.Black;
            this.m_txtOtherDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherDate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherDate1.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherDate1.Location = new System.Drawing.Point(191, 402);
            this.m_txtOtherDate1.Multiline = true;
            this.m_txtOtherDate1.Name = "m_txtOtherDate1";
            this.m_txtOtherDate1.Size = new System.Drawing.Size(136, 22);
            this.m_txtOtherDate1.TabIndex = 7471;
            this.m_txtOtherDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherDate1.Enter += new System.EventHandler(this.m_txtOtherDate1_Enter);
            // 
            // m_txtGuidanceDate3
            // 
            this.m_txtGuidanceDate3.AccessibleDescription = "康复指导>>第三次完成>>日期";
            this.m_txtGuidanceDate3.AccessibleName = "NoDefault";
            this.m_txtGuidanceDate3.BackColor = System.Drawing.Color.White;
            this.m_txtGuidanceDate3.BorderColor = System.Drawing.Color.Black;
            this.m_txtGuidanceDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceDate3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGuidanceDate3.ForeColor = System.Drawing.Color.Black;
            this.m_txtGuidanceDate3.Location = new System.Drawing.Point(655, 354);
            this.m_txtGuidanceDate3.Multiline = true;
            this.m_txtGuidanceDate3.Name = "m_txtGuidanceDate3";
            this.m_txtGuidanceDate3.Size = new System.Drawing.Size(136, 22);
            this.m_txtGuidanceDate3.TabIndex = 7510;
            this.m_txtGuidanceDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceDate3.Enter += new System.EventHandler(this.m_txtGuidanceDate3_Enter);
            // 
            // m_txtGuidanceDate1
            // 
            this.m_txtGuidanceDate1.AccessibleDescription = "康复指导>>第一次完成>>日期";
            this.m_txtGuidanceDate1.AccessibleName = "NoDefault";
            this.m_txtGuidanceDate1.BackColor = System.Drawing.Color.White;
            this.m_txtGuidanceDate1.BorderColor = System.Drawing.Color.Black;
            this.m_txtGuidanceDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceDate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGuidanceDate1.ForeColor = System.Drawing.Color.Black;
            this.m_txtGuidanceDate1.Location = new System.Drawing.Point(191, 354);
            this.m_txtGuidanceDate1.Multiline = true;
            this.m_txtGuidanceDate1.Name = "m_txtGuidanceDate1";
            this.m_txtGuidanceDate1.Size = new System.Drawing.Size(136, 22);
            this.m_txtGuidanceDate1.TabIndex = 7468;
            this.m_txtGuidanceDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceDate1.Enter += new System.EventHandler(this.m_txtGuidanceDate1_Enter);
            // 
            // m_txtGuidanceDate2
            // 
            this.m_txtGuidanceDate2.AccessibleDescription = "康复指导>>第二次完成>>日期";
            this.m_txtGuidanceDate2.AccessibleName = "NoDefault";
            this.m_txtGuidanceDate2.BackColor = System.Drawing.Color.White;
            this.m_txtGuidanceDate2.BorderColor = System.Drawing.Color.Black;
            this.m_txtGuidanceDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceDate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGuidanceDate2.ForeColor = System.Drawing.Color.Black;
            this.m_txtGuidanceDate2.Location = new System.Drawing.Point(423, 354);
            this.m_txtGuidanceDate2.Multiline = true;
            this.m_txtGuidanceDate2.Name = "m_txtGuidanceDate2";
            this.m_txtGuidanceDate2.Size = new System.Drawing.Size(136, 22);
            this.m_txtGuidanceDate2.TabIndex = 7489;
            this.m_txtGuidanceDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceDate2.Enter += new System.EventHandler(this.m_txtGuidanceDate2_Enter);
            // 
            // m_txtKnowledgeDate2
            // 
            this.m_txtKnowledgeDate2.AccessibleDescription = "有关知识>>第二次完成>>日期";
            this.m_txtKnowledgeDate2.AccessibleName = "NoDefault";
            this.m_txtKnowledgeDate2.BackColor = System.Drawing.Color.White;
            this.m_txtKnowledgeDate2.BorderColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeDate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKnowledgeDate2.ForeColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeDate2.Location = new System.Drawing.Point(423, 306);
            this.m_txtKnowledgeDate2.Multiline = true;
            this.m_txtKnowledgeDate2.Name = "m_txtKnowledgeDate2";
            this.m_txtKnowledgeDate2.Size = new System.Drawing.Size(136, 22);
            this.m_txtKnowledgeDate2.TabIndex = 7486;
            this.m_txtKnowledgeDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeDate2.Enter += new System.EventHandler(this.m_txtKnowledgeDate2_Enter);
            // 
            // m_txtKnowledgeDate1
            // 
            this.m_txtKnowledgeDate1.AccessibleDescription = "有关知识>>第一次完成>>日期";
            this.m_txtKnowledgeDate1.AccessibleName = "NoDefault";
            this.m_txtKnowledgeDate1.BackColor = System.Drawing.Color.White;
            this.m_txtKnowledgeDate1.BorderColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeDate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKnowledgeDate1.ForeColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeDate1.Location = new System.Drawing.Point(191, 306);
            this.m_txtKnowledgeDate1.Multiline = true;
            this.m_txtKnowledgeDate1.Name = "m_txtKnowledgeDate1";
            this.m_txtKnowledgeDate1.Size = new System.Drawing.Size(136, 22);
            this.m_txtKnowledgeDate1.TabIndex = 7465;
            this.m_txtKnowledgeDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeDate1.Enter += new System.EventHandler(this.m_txtKnowledgeDate1_Enter);
            // 
            // m_txtNoticeDate3
            // 
            this.m_txtNoticeDate3.AccessibleDescription = "注意事项>>第三次完成>>日期";
            this.m_txtNoticeDate3.AccessibleName = "NoDefault";
            this.m_txtNoticeDate3.BackColor = System.Drawing.Color.White;
            this.m_txtNoticeDate3.BorderColor = System.Drawing.Color.Black;
            this.m_txtNoticeDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeDate3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNoticeDate3.ForeColor = System.Drawing.Color.Black;
            this.m_txtNoticeDate3.Location = new System.Drawing.Point(655, 258);
            this.m_txtNoticeDate3.Multiline = true;
            this.m_txtNoticeDate3.Name = "m_txtNoticeDate3";
            this.m_txtNoticeDate3.Size = new System.Drawing.Size(136, 22);
            this.m_txtNoticeDate3.TabIndex = 7504;
            this.m_txtNoticeDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeDate3.Enter += new System.EventHandler(this.m_txtNoticeDate3_Enter);
            // 
            // m_txtNoticeDate1
            // 
            this.m_txtNoticeDate1.AccessibleDescription = "注意事项>>第一次完成>>日期";
            this.m_txtNoticeDate1.AccessibleName = "NoDefault";
            this.m_txtNoticeDate1.BackColor = System.Drawing.Color.White;
            this.m_txtNoticeDate1.BorderColor = System.Drawing.Color.Black;
            this.m_txtNoticeDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeDate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNoticeDate1.ForeColor = System.Drawing.Color.Black;
            this.m_txtNoticeDate1.Location = new System.Drawing.Point(191, 258);
            this.m_txtNoticeDate1.Multiline = true;
            this.m_txtNoticeDate1.Name = "m_txtNoticeDate1";
            this.m_txtNoticeDate1.Size = new System.Drawing.Size(136, 22);
            this.m_txtNoticeDate1.TabIndex = 7462;
            this.m_txtNoticeDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeDate1.Enter += new System.EventHandler(this.m_txtNoticeDate1_Enter);
            // 
            // m_txtNoticeDate2
            // 
            this.m_txtNoticeDate2.AccessibleDescription = "注意事项>>第二次完成>>日期";
            this.m_txtNoticeDate2.AccessibleName = "NoDefault";
            this.m_txtNoticeDate2.BackColor = System.Drawing.Color.White;
            this.m_txtNoticeDate2.BorderColor = System.Drawing.Color.Black;
            this.m_txtNoticeDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeDate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNoticeDate2.ForeColor = System.Drawing.Color.Black;
            this.m_txtNoticeDate2.Location = new System.Drawing.Point(423, 258);
            this.m_txtNoticeDate2.Multiline = true;
            this.m_txtNoticeDate2.Name = "m_txtNoticeDate2";
            this.m_txtNoticeDate2.Size = new System.Drawing.Size(136, 22);
            this.m_txtNoticeDate2.TabIndex = 7483;
            this.m_txtNoticeDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeDate2.Enter += new System.EventHandler(this.m_txtNoticeDate2_Enter);
            // 
            // m_txtMedicineDate3
            // 
            this.m_txtMedicineDate3.AccessibleDescription = "药物服用方法>>第三次完成>>日期";
            this.m_txtMedicineDate3.AccessibleName = "NoDefault";
            this.m_txtMedicineDate3.BackColor = System.Drawing.Color.White;
            this.m_txtMedicineDate3.BorderColor = System.Drawing.Color.Black;
            this.m_txtMedicineDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineDate3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineDate3.ForeColor = System.Drawing.Color.Black;
            this.m_txtMedicineDate3.Location = new System.Drawing.Point(655, 210);
            this.m_txtMedicineDate3.Multiline = true;
            this.m_txtMedicineDate3.Name = "m_txtMedicineDate3";
            this.m_txtMedicineDate3.Size = new System.Drawing.Size(136, 22);
            this.m_txtMedicineDate3.TabIndex = 7501;
            this.m_txtMedicineDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineDate3.Enter += new System.EventHandler(this.m_txtMedicineDate3_Enter);
            // 
            // m_txtMedicineDate2
            // 
            this.m_txtMedicineDate2.AccessibleDescription = "药物服用方法>>第二次完成>>日期";
            this.m_txtMedicineDate2.AccessibleName = "NoDefault";
            this.m_txtMedicineDate2.BackColor = System.Drawing.Color.White;
            this.m_txtMedicineDate2.BorderColor = System.Drawing.Color.Black;
            this.m_txtMedicineDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineDate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineDate2.ForeColor = System.Drawing.Color.Black;
            this.m_txtMedicineDate2.Location = new System.Drawing.Point(423, 210);
            this.m_txtMedicineDate2.Multiline = true;
            this.m_txtMedicineDate2.Name = "m_txtMedicineDate2";
            this.m_txtMedicineDate2.Size = new System.Drawing.Size(136, 22);
            this.m_txtMedicineDate2.TabIndex = 7480;
            this.m_txtMedicineDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineDate2.Enter += new System.EventHandler(this.m_txtMedicineDate2_Enter);
            // 
            // m_txtMedicineDate1
            // 
            this.m_txtMedicineDate1.AccessibleDescription = "药物服用方法>>第一次完成>>日期";
            this.m_txtMedicineDate1.AccessibleName = "NoDefault";
            this.m_txtMedicineDate1.BackColor = System.Drawing.Color.White;
            this.m_txtMedicineDate1.BorderColor = System.Drawing.Color.Black;
            this.m_txtMedicineDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineDate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineDate1.ForeColor = System.Drawing.Color.Black;
            this.m_txtMedicineDate1.Location = new System.Drawing.Point(191, 210);
            this.m_txtMedicineDate1.Multiline = true;
            this.m_txtMedicineDate1.Name = "m_txtMedicineDate1";
            this.m_txtMedicineDate1.Size = new System.Drawing.Size(136, 22);
            this.m_txtMedicineDate1.TabIndex = 7459;
            this.m_txtMedicineDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineDate1.Enter += new System.EventHandler(this.m_txtMedicineDate1_Enter);
            // 
            // m_txtExplanDate3
            // 
            this.m_txtExplanDate3.AccessibleDescription = "解释与交代>>第三次完成>>日期";
            this.m_txtExplanDate3.AccessibleName = "NoDefault";
            this.m_txtExplanDate3.BackColor = System.Drawing.Color.White;
            this.m_txtExplanDate3.BorderColor = System.Drawing.Color.Black;
            this.m_txtExplanDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanDate3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExplanDate3.ForeColor = System.Drawing.Color.Black;
            this.m_txtExplanDate3.Location = new System.Drawing.Point(655, 162);
            this.m_txtExplanDate3.Multiline = true;
            this.m_txtExplanDate3.Name = "m_txtExplanDate3";
            this.m_txtExplanDate3.Size = new System.Drawing.Size(136, 22);
            this.m_txtExplanDate3.TabIndex = 7498;
            this.m_txtExplanDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanDate3.Enter += new System.EventHandler(this.m_txtExplanDate3_Enter);
            // 
            // m_txtReadOutDate3
            // 
            this.m_txtReadOutDate3.AccessibleDescription = "入院宣教>>第三次完成>>日期";
            this.m_txtReadOutDate3.AccessibleName = "NoDefault";
            this.m_txtReadOutDate3.BackColor = System.Drawing.Color.White;
            this.m_txtReadOutDate3.BorderColor = System.Drawing.Color.Black;
            this.m_txtReadOutDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutDate3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReadOutDate3.ForeColor = System.Drawing.Color.Black;
            this.m_txtReadOutDate3.Location = new System.Drawing.Point(655, 114);
            this.m_txtReadOutDate3.Multiline = true;
            this.m_txtReadOutDate3.Name = "m_txtReadOutDate3";
            this.m_txtReadOutDate3.Size = new System.Drawing.Size(136, 22);
            this.m_txtReadOutDate3.TabIndex = 7495;
            this.m_txtReadOutDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutDate3.Enter += new System.EventHandler(this.m_txtReadOutDate3_Enter);
            // 
            // m_cmdNurseSign73
            // 
            this.m_cmdNurseSign73.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign73.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign73.Location = new System.Drawing.Point(790, 380);
            this.m_cmdNurseSign73.Name = "m_cmdNurseSign73";
            this.m_cmdNurseSign73.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign73.TabIndex = 10000027;
            this.m_cmdNurseSign73.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign63
            // 
            this.m_cmdNurseSign63.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign63.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign63.Location = new System.Drawing.Point(790, 332);
            this.m_cmdNurseSign63.Name = "m_cmdNurseSign63";
            this.m_cmdNurseSign63.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign63.TabIndex = 10000027;
            this.m_cmdNurseSign63.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign53
            // 
            this.m_cmdNurseSign53.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign53.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign53.Location = new System.Drawing.Point(790, 284);
            this.m_cmdNurseSign53.Name = "m_cmdNurseSign53";
            this.m_cmdNurseSign53.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign53.TabIndex = 10000027;
            this.m_cmdNurseSign53.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign43
            // 
            this.m_cmdNurseSign43.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign43.Location = new System.Drawing.Point(790, 236);
            this.m_cmdNurseSign43.Name = "m_cmdNurseSign43";
            this.m_cmdNurseSign43.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign43.TabIndex = 10000027;
            this.m_cmdNurseSign43.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign33
            // 
            this.m_cmdNurseSign33.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign33.Location = new System.Drawing.Point(790, 188);
            this.m_cmdNurseSign33.Name = "m_cmdNurseSign33";
            this.m_cmdNurseSign33.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign33.TabIndex = 10000027;
            this.m_cmdNurseSign33.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign23
            // 
            this.m_cmdNurseSign23.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign23.Location = new System.Drawing.Point(790, 140);
            this.m_cmdNurseSign23.Name = "m_cmdNurseSign23";
            this.m_cmdNurseSign23.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign23.TabIndex = 10000027;
            this.m_cmdNurseSign23.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign13
            // 
            this.m_cmdNurseSign13.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign13.Location = new System.Drawing.Point(790, 92);
            this.m_cmdNurseSign13.Name = "m_cmdNurseSign13";
            this.m_cmdNurseSign13.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign13.TabIndex = 10000027;
            this.m_cmdNurseSign13.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign72
            // 
            this.m_cmdNurseSign72.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign72.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign72.Location = new System.Drawing.Point(558, 380);
            this.m_cmdNurseSign72.Name = "m_cmdNurseSign72";
            this.m_cmdNurseSign72.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign72.TabIndex = 10000027;
            this.m_cmdNurseSign72.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign62
            // 
            this.m_cmdNurseSign62.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign62.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign62.Location = new System.Drawing.Point(558, 332);
            this.m_cmdNurseSign62.Name = "m_cmdNurseSign62";
            this.m_cmdNurseSign62.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign62.TabIndex = 10000027;
            this.m_cmdNurseSign62.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign52
            // 
            this.m_cmdNurseSign52.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign52.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign52.Location = new System.Drawing.Point(558, 284);
            this.m_cmdNurseSign52.Name = "m_cmdNurseSign52";
            this.m_cmdNurseSign52.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign52.TabIndex = 10000027;
            this.m_cmdNurseSign52.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign42
            // 
            this.m_cmdNurseSign42.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign42.Location = new System.Drawing.Point(558, 236);
            this.m_cmdNurseSign42.Name = "m_cmdNurseSign42";
            this.m_cmdNurseSign42.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign42.TabIndex = 10000027;
            this.m_cmdNurseSign42.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign32
            // 
            this.m_cmdNurseSign32.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign32.Location = new System.Drawing.Point(558, 188);
            this.m_cmdNurseSign32.Name = "m_cmdNurseSign32";
            this.m_cmdNurseSign32.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign32.TabIndex = 10000027;
            this.m_cmdNurseSign32.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign22
            // 
            this.m_cmdNurseSign22.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign22.Location = new System.Drawing.Point(558, 140);
            this.m_cmdNurseSign22.Name = "m_cmdNurseSign22";
            this.m_cmdNurseSign22.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign22.TabIndex = 10000027;
            this.m_cmdNurseSign22.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign12
            // 
            this.m_cmdNurseSign12.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign12.Location = new System.Drawing.Point(558, 92);
            this.m_cmdNurseSign12.Name = "m_cmdNurseSign12";
            this.m_cmdNurseSign12.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign12.TabIndex = 10000027;
            this.m_cmdNurseSign12.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign71
            // 
            this.m_cmdNurseSign71.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign71.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign71.Location = new System.Drawing.Point(326, 380);
            this.m_cmdNurseSign71.Name = "m_cmdNurseSign71";
            this.m_cmdNurseSign71.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign71.TabIndex = 10000027;
            this.m_cmdNurseSign71.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign61
            // 
            this.m_cmdNurseSign61.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign61.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign61.Location = new System.Drawing.Point(326, 332);
            this.m_cmdNurseSign61.Name = "m_cmdNurseSign61";
            this.m_cmdNurseSign61.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign61.TabIndex = 10000027;
            this.m_cmdNurseSign61.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign51
            // 
            this.m_cmdNurseSign51.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign51.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign51.Location = new System.Drawing.Point(326, 284);
            this.m_cmdNurseSign51.Name = "m_cmdNurseSign51";
            this.m_cmdNurseSign51.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign51.TabIndex = 10000027;
            this.m_cmdNurseSign51.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign41
            // 
            this.m_cmdNurseSign41.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign41.Location = new System.Drawing.Point(326, 236);
            this.m_cmdNurseSign41.Name = "m_cmdNurseSign41";
            this.m_cmdNurseSign41.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign41.TabIndex = 10000027;
            this.m_cmdNurseSign41.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign31
            // 
            this.m_cmdNurseSign31.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign31.Location = new System.Drawing.Point(326, 188);
            this.m_cmdNurseSign31.Name = "m_cmdNurseSign31";
            this.m_cmdNurseSign31.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign31.TabIndex = 10000027;
            this.m_cmdNurseSign31.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign21
            // 
            this.m_cmdNurseSign21.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign21.Location = new System.Drawing.Point(326, 140);
            this.m_cmdNurseSign21.Name = "m_cmdNurseSign21";
            this.m_cmdNurseSign21.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign21.TabIndex = 10000027;
            this.m_cmdNurseSign21.UseVisualStyleBackColor = false;
            // 
            // m_cmdNurseSign11
            // 
            this.m_cmdNurseSign11.BackColor = System.Drawing.SystemColors.Control;
            this.m_cmdNurseSign11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNurseSign11.Location = new System.Drawing.Point(326, 92);
            this.m_cmdNurseSign11.Name = "m_cmdNurseSign11";
            this.m_cmdNurseSign11.Size = new System.Drawing.Size(18, 23);
            this.m_cmdNurseSign11.TabIndex = 10000027;
            this.m_cmdNurseSign11.UseVisualStyleBackColor = false;
            // 
            // m_txtReadOutNurse3
            // 
            this.m_txtReadOutNurse3.AccessibleDescription = "入院宣教>>第三次完成>>护士签名";
            this.m_txtReadOutNurse3.AccessibleName = "NoDefault";
            this.m_txtReadOutNurse3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutNurse3.Location = new System.Drawing.Point(655, 92);
            this.m_txtReadOutNurse3.Name = "m_txtReadOutNurse3";
            this.m_txtReadOutNurse3.Size = new System.Drawing.Size(136, 23);
            this.m_txtReadOutNurse3.TabIndex = 10000026;
            this.m_txtReadOutNurse3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutNurse3.Enter += new System.EventHandler(this.m_txtReadOutNurse3_Enter);
            // 
            // m_txtReadOutNurse2
            // 
            this.m_txtReadOutNurse2.AccessibleDescription = "入院宣教>>第二次完成>>护士签名";
            this.m_txtReadOutNurse2.AccessibleName = "NoDefault";
            this.m_txtReadOutNurse2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutNurse2.Location = new System.Drawing.Point(423, 92);
            this.m_txtReadOutNurse2.Name = "m_txtReadOutNurse2";
            this.m_txtReadOutNurse2.Size = new System.Drawing.Size(136, 23);
            this.m_txtReadOutNurse2.TabIndex = 10000026;
            this.m_txtReadOutNurse2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutNurse2.Enter += new System.EventHandler(this.m_txtReadOutNurse2_Enter);
            // 
            // m_txtExplanNurse3
            // 
            this.m_txtExplanNurse3.AccessibleDescription = "解释与交代>>第三次完成>>护士签名";
            this.m_txtExplanNurse3.AccessibleName = "NoDefault";
            this.m_txtExplanNurse3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanNurse3.Location = new System.Drawing.Point(655, 140);
            this.m_txtExplanNurse3.Name = "m_txtExplanNurse3";
            this.m_txtExplanNurse3.Size = new System.Drawing.Size(136, 23);
            this.m_txtExplanNurse3.TabIndex = 10000026;
            this.m_txtExplanNurse3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanNurse3.Enter += new System.EventHandler(this.m_txtExplanNurse3_Enter);
            // 
            // m_txtExplanNurse2
            // 
            this.m_txtExplanNurse2.AccessibleDescription = "解释与交代>>第二次完成>>护士签名";
            this.m_txtExplanNurse2.AccessibleName = "NoDefault";
            this.m_txtExplanNurse2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanNurse2.Location = new System.Drawing.Point(423, 140);
            this.m_txtExplanNurse2.Name = "m_txtExplanNurse2";
            this.m_txtExplanNurse2.Size = new System.Drawing.Size(136, 23);
            this.m_txtExplanNurse2.TabIndex = 10000026;
            this.m_txtExplanNurse2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanNurse2.Enter += new System.EventHandler(this.m_txtExplanNurse2_Enter);
            // 
            // m_txtMedicineNurse3
            // 
            this.m_txtMedicineNurse3.AccessibleDescription = "药物服用方法>>第三次完成>>护士签名";
            this.m_txtMedicineNurse3.AccessibleName = "NoDefault";
            this.m_txtMedicineNurse3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineNurse3.Location = new System.Drawing.Point(655, 188);
            this.m_txtMedicineNurse3.Name = "m_txtMedicineNurse3";
            this.m_txtMedicineNurse3.Size = new System.Drawing.Size(136, 23);
            this.m_txtMedicineNurse3.TabIndex = 10000026;
            this.m_txtMedicineNurse3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineNurse3.Enter += new System.EventHandler(this.m_txtMedicineNurse3_Enter);
            // 
            // m_txtMedicineNurse2
            // 
            this.m_txtMedicineNurse2.AccessibleDescription = "药物服用方法>>第二次完成>>护士签名";
            this.m_txtMedicineNurse2.AccessibleName = "NoDefault";
            this.m_txtMedicineNurse2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineNurse2.Location = new System.Drawing.Point(423, 188);
            this.m_txtMedicineNurse2.Name = "m_txtMedicineNurse2";
            this.m_txtMedicineNurse2.Size = new System.Drawing.Size(136, 23);
            this.m_txtMedicineNurse2.TabIndex = 10000026;
            this.m_txtMedicineNurse2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineNurse2.Enter += new System.EventHandler(this.m_txtMedicineNurse2_Enter);
            // 
            // m_txtNoticeNurse3
            // 
            this.m_txtNoticeNurse3.AccessibleDescription = "注意事项>>第三次完成>>护士签名";
            this.m_txtNoticeNurse3.AccessibleName = "NoDefault";
            this.m_txtNoticeNurse3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeNurse3.Location = new System.Drawing.Point(655, 236);
            this.m_txtNoticeNurse3.Name = "m_txtNoticeNurse3";
            this.m_txtNoticeNurse3.Size = new System.Drawing.Size(136, 23);
            this.m_txtNoticeNurse3.TabIndex = 10000026;
            this.m_txtNoticeNurse3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeNurse3.Enter += new System.EventHandler(this.m_txtNoticeNurse3_Enter);
            // 
            // m_txtNoticeNurse2
            // 
            this.m_txtNoticeNurse2.AccessibleDescription = "注意事项>>第二次完成>>护士签名";
            this.m_txtNoticeNurse2.AccessibleName = "NoDefault";
            this.m_txtNoticeNurse2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeNurse2.Location = new System.Drawing.Point(423, 236);
            this.m_txtNoticeNurse2.Name = "m_txtNoticeNurse2";
            this.m_txtNoticeNurse2.Size = new System.Drawing.Size(136, 23);
            this.m_txtNoticeNurse2.TabIndex = 10000026;
            this.m_txtNoticeNurse2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeNurse2.Enter += new System.EventHandler(this.m_txtNoticeNurse2_Enter);
            // 
            // m_txtKnowledgeNurse3
            // 
            this.m_txtKnowledgeNurse3.AccessibleDescription = "有关知识>>第三次完成>>护士签名";
            this.m_txtKnowledgeNurse3.AccessibleName = "NoDefault";
            this.m_txtKnowledgeNurse3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeNurse3.Location = new System.Drawing.Point(655, 284);
            this.m_txtKnowledgeNurse3.Name = "m_txtKnowledgeNurse3";
            this.m_txtKnowledgeNurse3.Size = new System.Drawing.Size(136, 23);
            this.m_txtKnowledgeNurse3.TabIndex = 10000026;
            this.m_txtKnowledgeNurse3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeNurse3.Enter += new System.EventHandler(this.m_txtKnowledgeNurse3_Enter);
            // 
            // m_txtKnowledgeNurse2
            // 
            this.m_txtKnowledgeNurse2.AccessibleDescription = "有关知识>>第二次完成>>护士签名";
            this.m_txtKnowledgeNurse2.AccessibleName = "NoDefault";
            this.m_txtKnowledgeNurse2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeNurse2.Location = new System.Drawing.Point(423, 284);
            this.m_txtKnowledgeNurse2.Name = "m_txtKnowledgeNurse2";
            this.m_txtKnowledgeNurse2.Size = new System.Drawing.Size(136, 23);
            this.m_txtKnowledgeNurse2.TabIndex = 10000026;
            this.m_txtKnowledgeNurse2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeNurse2.Enter += new System.EventHandler(this.m_txtKnowledgeNurse2_Enter);
            // 
            // m_txtGuidanceNurse3
            // 
            this.m_txtGuidanceNurse3.AccessibleDescription = "康复指导>>第三次完成>>护士签名";
            this.m_txtGuidanceNurse3.AccessibleName = "NoDefault";
            this.m_txtGuidanceNurse3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceNurse3.Location = new System.Drawing.Point(655, 332);
            this.m_txtGuidanceNurse3.Name = "m_txtGuidanceNurse3";
            this.m_txtGuidanceNurse3.Size = new System.Drawing.Size(136, 23);
            this.m_txtGuidanceNurse3.TabIndex = 10000026;
            this.m_txtGuidanceNurse3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceNurse3.Enter += new System.EventHandler(this.m_txtGuidanceNurse3_Enter);
            // 
            // m_txtGuidanceNurse2
            // 
            this.m_txtGuidanceNurse2.AccessibleDescription = "康复指导>>第二次完成>>护士签名";
            this.m_txtGuidanceNurse2.AccessibleName = "NoDefault";
            this.m_txtGuidanceNurse2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceNurse2.Location = new System.Drawing.Point(423, 332);
            this.m_txtGuidanceNurse2.Name = "m_txtGuidanceNurse2";
            this.m_txtGuidanceNurse2.Size = new System.Drawing.Size(136, 23);
            this.m_txtGuidanceNurse2.TabIndex = 10000026;
            this.m_txtGuidanceNurse2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceNurse2.Enter += new System.EventHandler(this.m_txtGuidanceNurse2_Enter);
            // 
            // m_txtOtherNurse3
            // 
            this.m_txtOtherNurse3.AccessibleDescription = "其他>>第三次完成>>护士签名";
            this.m_txtOtherNurse3.AccessibleName = "NoDefault";
            this.m_txtOtherNurse3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherNurse3.Location = new System.Drawing.Point(655, 380);
            this.m_txtOtherNurse3.Name = "m_txtOtherNurse3";
            this.m_txtOtherNurse3.Size = new System.Drawing.Size(136, 23);
            this.m_txtOtherNurse3.TabIndex = 10000026;
            this.m_txtOtherNurse3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherNurse3.Enter += new System.EventHandler(this.m_txtOtherNurse3_Enter);
            // 
            // m_txtOtherNurse2
            // 
            this.m_txtOtherNurse2.AccessibleDescription = "其他>>第二次完成>>护士签名";
            this.m_txtOtherNurse2.AccessibleName = "NoDefault";
            this.m_txtOtherNurse2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherNurse2.Location = new System.Drawing.Point(423, 380);
            this.m_txtOtherNurse2.Name = "m_txtOtherNurse2";
            this.m_txtOtherNurse2.Size = new System.Drawing.Size(136, 23);
            this.m_txtOtherNurse2.TabIndex = 10000026;
            this.m_txtOtherNurse2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherNurse2.Enter += new System.EventHandler(this.m_txtOtherNurse2_Enter);
            // 
            // m_txtOtherNurse1
            // 
            this.m_txtOtherNurse1.AccessibleDescription = "其他>>第一次完成>>护士签名";
            this.m_txtOtherNurse1.AccessibleName = "NoDefault";
            this.m_txtOtherNurse1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherNurse1.Location = new System.Drawing.Point(191, 380);
            this.m_txtOtherNurse1.Name = "m_txtOtherNurse1";
            this.m_txtOtherNurse1.Size = new System.Drawing.Size(136, 23);
            this.m_txtOtherNurse1.TabIndex = 10000026;
            this.m_txtOtherNurse1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherNurse1.Enter += new System.EventHandler(this.m_txtOtherNurse1_Enter);
            // 
            // m_txtGuidanceNurse1
            // 
            this.m_txtGuidanceNurse1.AccessibleDescription = "康复指导>>第一次完成>>护士签名";
            this.m_txtGuidanceNurse1.AccessibleName = "NoDefault";
            this.m_txtGuidanceNurse1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceNurse1.Location = new System.Drawing.Point(191, 332);
            this.m_txtGuidanceNurse1.Name = "m_txtGuidanceNurse1";
            this.m_txtGuidanceNurse1.Size = new System.Drawing.Size(136, 23);
            this.m_txtGuidanceNurse1.TabIndex = 10000026;
            this.m_txtGuidanceNurse1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceNurse1.Enter += new System.EventHandler(this.m_txtGuidanceNurse1_Enter);
            // 
            // m_txtKnowledgeNurse1
            // 
            this.m_txtKnowledgeNurse1.AccessibleDescription = "有关知识>>第一次完成>>护士签名";
            this.m_txtKnowledgeNurse1.AccessibleName = "NoDefault";
            this.m_txtKnowledgeNurse1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeNurse1.Location = new System.Drawing.Point(191, 284);
            this.m_txtKnowledgeNurse1.Name = "m_txtKnowledgeNurse1";
            this.m_txtKnowledgeNurse1.Size = new System.Drawing.Size(136, 23);
            this.m_txtKnowledgeNurse1.TabIndex = 10000026;
            this.m_txtKnowledgeNurse1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeNurse1.Enter += new System.EventHandler(this.m_txtKnowledgeNurse1_Enter);
            // 
            // m_txtNoticeNurse1
            // 
            this.m_txtNoticeNurse1.AccessibleDescription = "注意事项>>第一次完成>>护士签名";
            this.m_txtNoticeNurse1.AccessibleName = "NoDefault";
            this.m_txtNoticeNurse1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeNurse1.Location = new System.Drawing.Point(191, 236);
            this.m_txtNoticeNurse1.Name = "m_txtNoticeNurse1";
            this.m_txtNoticeNurse1.Size = new System.Drawing.Size(136, 23);
            this.m_txtNoticeNurse1.TabIndex = 10000026;
            this.m_txtNoticeNurse1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeNurse1.Enter += new System.EventHandler(this.m_txtNoticeNurse1_Enter);
            // 
            // m_txtMedicineNurse1
            // 
            this.m_txtMedicineNurse1.AccessibleDescription = "药物服用方法>>第一次完成>>护士签名";
            this.m_txtMedicineNurse1.AccessibleName = "NoDefault";
            this.m_txtMedicineNurse1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineNurse1.Location = new System.Drawing.Point(191, 188);
            this.m_txtMedicineNurse1.Name = "m_txtMedicineNurse1";
            this.m_txtMedicineNurse1.Size = new System.Drawing.Size(136, 23);
            this.m_txtMedicineNurse1.TabIndex = 10000026;
            this.m_txtMedicineNurse1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineNurse1.Enter += new System.EventHandler(this.m_txtMedicineNurse1_Enter);
            // 
            // m_txtExplanNurse1
            // 
            this.m_txtExplanNurse1.AccessibleDescription = "解释与交代>>第一次完成>>护士签名";
            this.m_txtExplanNurse1.AccessibleName = "NoDefault";
            this.m_txtExplanNurse1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanNurse1.Location = new System.Drawing.Point(191, 140);
            this.m_txtExplanNurse1.Name = "m_txtExplanNurse1";
            this.m_txtExplanNurse1.Size = new System.Drawing.Size(136, 23);
            this.m_txtExplanNurse1.TabIndex = 10000026;
            this.m_txtExplanNurse1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanNurse1.Enter += new System.EventHandler(this.m_txtExplanNurse1_Enter);
            // 
            // m_txtReadOutNurse1
            // 
            this.m_txtReadOutNurse1.AccessibleDescription = "入院宣教>>第一次完成>>护士签名";
            this.m_txtReadOutNurse1.AccessibleName = "NoDefault";
            this.m_txtReadOutNurse1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutNurse1.Location = new System.Drawing.Point(191, 92);
            this.m_txtReadOutNurse1.Name = "m_txtReadOutNurse1";
            this.m_txtReadOutNurse1.Size = new System.Drawing.Size(136, 23);
            this.m_txtReadOutNurse1.TabIndex = 10000026;
            this.m_txtReadOutNurse1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutNurse1.Enter += new System.EventHandler(this.m_txtReadOutNurse1_Enter);
            // 
            // m_txtReadOutDate1
            // 
            this.m_txtReadOutDate1.AccessibleDescription = "入院宣教>>第一次完成>>日期";
            this.m_txtReadOutDate1.AccessibleName = "NoDefault";
            this.m_txtReadOutDate1.BackColor = System.Drawing.Color.White;
            this.m_txtReadOutDate1.BorderColor = System.Drawing.Color.Black;
            this.m_txtReadOutDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutDate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReadOutDate1.ForeColor = System.Drawing.Color.Black;
            this.m_txtReadOutDate1.Location = new System.Drawing.Point(191, 114);
            this.m_txtReadOutDate1.Multiline = true;
            this.m_txtReadOutDate1.Name = "m_txtReadOutDate1";
            this.m_txtReadOutDate1.Size = new System.Drawing.Size(136, 22);
            this.m_txtReadOutDate1.TabIndex = 7453;
            this.m_txtReadOutDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutDate1.Enter += new System.EventHandler(this.m_txtReadOutDate1_Enter);
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(28, 432);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(32, 20);
            this.label51.TabIndex = 10000023;
            this.label51.Text = "注:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(60, 452);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(399, 14);
            this.label48.TabIndex = 10000021;
            this.label48.Text = "2.具体的教育内容可以记录于护理记录单上，护长、组长检查。";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(60, 432);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(560, 14);
            this.label47.TabIndex = 10000020;
            this.label47.Text = "1.根据病人的需要及住院时间可分阶段完成，每次不宜过多内容。并在相应项目用V标识。";
            // 
            // dtpNurseSignDate11
            // 
            this.dtpNurseSignDate11.AccessibleDescription = "";
            this.dtpNurseSignDate11.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate11.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate11.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate11.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate11.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate11.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate11.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate11.Location = new System.Drawing.Point(193, 114);
            this.dtpNurseSignDate11.m_BlnOnlyTime = false;
            this.dtpNurseSignDate11.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate11.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate11.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate11.Name = "dtpNurseSignDate11";
            this.dtpNurseSignDate11.ReadOnly = false;
            this.dtpNurseSignDate11.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate11.TabIndex = 10000019;
            this.dtpNurseSignDate11.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate11.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate11.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate11_evtValueChanged);
            // 
            // dtpEduTime
            // 
            this.dtpEduTime.AccessibleDescription = "填表时间";
            this.dtpEduTime.BorderColor = System.Drawing.Color.Black;
            this.dtpEduTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpEduTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpEduTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpEduTime.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpEduTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpEduTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEduTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEduTime.Location = new System.Drawing.Point(584, 12);
            this.dtpEduTime.m_BlnOnlyTime = false;
            this.dtpEduTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpEduTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEduTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEduTime.Name = "dtpEduTime";
            this.dtpEduTime.ReadOnly = false;
            this.dtpEduTime.Size = new System.Drawing.Size(216, 22);
            this.dtpEduTime.TabIndex = 10000019;
            this.dtpEduTime.TextBackColor = System.Drawing.Color.White;
            this.dtpEduTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(588, 68);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(212, 16);
            this.label46.TabIndex = 10000018;
            this.label46.Text = "教育项目     护士签名及日期";
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(124, 68);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(212, 16);
            this.label44.TabIndex = 10000018;
            this.label44.Text = "教育项目     护士签名及日期";
            // 
            // m_txtReadOutEdu1
            // 
            this.m_txtReadOutEdu1.AccessibleDescription = "入院宣教>>第一次完成>>教育项目";
            this.m_txtReadOutEdu1.AccessibleName = "";
            this.m_txtReadOutEdu1.BackColor = System.Drawing.Color.White;
            this.m_txtReadOutEdu1.BorderColor = System.Drawing.Color.Black;
            this.m_txtReadOutEdu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutEdu1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReadOutEdu1.ForeColor = System.Drawing.Color.Black;
            this.m_txtReadOutEdu1.Location = new System.Drawing.Point(116, 92);
            this.m_txtReadOutEdu1.Multiline = true;
            this.m_txtReadOutEdu1.Name = "m_txtReadOutEdu1";
            this.m_txtReadOutEdu1.Size = new System.Drawing.Size(76, 44);
            this.m_txtReadOutEdu1.TabIndex = 7451;
            this.m_txtReadOutEdu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutEdu1.Enter += new System.EventHandler(this.m_txtReadOutEdu1_Enter);
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Location = new System.Drawing.Point(12, 92);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(100, 44);
            this.label33.TabIndex = 10000016;
            this.label33.Text = "1.入院宣教";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtReadOutEdu2
            // 
            this.m_txtReadOutEdu2.AccessibleDescription = "入院宣教>>第二次完成>>教育项目";
            this.m_txtReadOutEdu2.AccessibleName = "";
            this.m_txtReadOutEdu2.BackColor = System.Drawing.Color.White;
            this.m_txtReadOutEdu2.BorderColor = System.Drawing.Color.Black;
            this.m_txtReadOutEdu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutEdu2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReadOutEdu2.ForeColor = System.Drawing.Color.Black;
            this.m_txtReadOutEdu2.Location = new System.Drawing.Point(348, 92);
            this.m_txtReadOutEdu2.Multiline = true;
            this.m_txtReadOutEdu2.Name = "m_txtReadOutEdu2";
            this.m_txtReadOutEdu2.Size = new System.Drawing.Size(76, 44);
            this.m_txtReadOutEdu2.TabIndex = 7472;
            this.m_txtReadOutEdu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutEdu2.Enter += new System.EventHandler(this.m_txtReadOutEdu2_Enter);
            // 
            // m_txtReadOutDate2
            // 
            this.m_txtReadOutDate2.AccessibleDescription = "入院宣教>>第二次完成>>日期";
            this.m_txtReadOutDate2.AccessibleName = "NoDefault";
            this.m_txtReadOutDate2.BackColor = System.Drawing.Color.White;
            this.m_txtReadOutDate2.BorderColor = System.Drawing.Color.Black;
            this.m_txtReadOutDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutDate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReadOutDate2.ForeColor = System.Drawing.Color.Black;
            this.m_txtReadOutDate2.Location = new System.Drawing.Point(423, 114);
            this.m_txtReadOutDate2.Multiline = true;
            this.m_txtReadOutDate2.Name = "m_txtReadOutDate2";
            this.m_txtReadOutDate2.Size = new System.Drawing.Size(136, 22);
            this.m_txtReadOutDate2.TabIndex = 7474;
            this.m_txtReadOutDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutDate2.Enter += new System.EventHandler(this.m_txtReadOutDate2_Enter);
            // 
            // m_txtReadOutEdu3
            // 
            this.m_txtReadOutEdu3.AccessibleDescription = "入院宣教>>第三次完成>>教育项目";
            this.m_txtReadOutEdu3.AccessibleName = "";
            this.m_txtReadOutEdu3.BackColor = System.Drawing.Color.White;
            this.m_txtReadOutEdu3.BorderColor = System.Drawing.Color.Black;
            this.m_txtReadOutEdu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReadOutEdu3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReadOutEdu3.ForeColor = System.Drawing.Color.Black;
            this.m_txtReadOutEdu3.Location = new System.Drawing.Point(580, 92);
            this.m_txtReadOutEdu3.Multiline = true;
            this.m_txtReadOutEdu3.Name = "m_txtReadOutEdu3";
            this.m_txtReadOutEdu3.Size = new System.Drawing.Size(76, 44);
            this.m_txtReadOutEdu3.TabIndex = 7493;
            this.m_txtReadOutEdu3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtReadOutEdu3.Enter += new System.EventHandler(this.m_txtReadOutEdu3_Enter);
            // 
            // label34
            // 
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.Location = new System.Drawing.Point(12, 44);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(100, 44);
            this.label34.TabIndex = 10000016;
            this.label34.Text = "教育项目";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label35.Location = new System.Drawing.Point(116, 44);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(228, 44);
            this.label35.TabIndex = 10000016;
            this.label35.Text = "第1次完成";
            this.label35.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label36
            // 
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Location = new System.Drawing.Point(12, 140);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(100, 44);
            this.label36.TabIndex = 10000016;
            this.label36.Text = "2.检查前解释与交代";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label37.Location = new System.Drawing.Point(12, 188);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 44);
            this.label37.TabIndex = 10000016;
            this.label37.Text = "3.主要药物的服用方法";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Location = new System.Drawing.Point(12, 236);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 44);
            this.label38.TabIndex = 10000016;
            this.label38.Text = "4.手术前后的注意事项";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.Location = new System.Drawing.Point(12, 284);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(100, 44);
            this.label39.TabIndex = 10000016;
            this.label39.Text = "5.饮食、疾病有关知识";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label40.Location = new System.Drawing.Point(12, 332);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(100, 44);
            this.label40.TabIndex = 10000016;
            this.label40.Text = "6.康复指导、家属指导";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label41.Location = new System.Drawing.Point(12, 380);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(100, 44);
            this.label41.TabIndex = 10000016;
            this.label41.Text = "7.其他";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label43.Location = new System.Drawing.Point(580, 44);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(228, 44);
            this.label43.TabIndex = 10000016;
            this.label43.Text = "第3次完成";
            this.label43.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(352, 68);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(212, 16);
            this.label45.TabIndex = 10000018;
            this.label45.Text = "教育项目     护士签名及日期";
            // 
            // label42
            // 
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Location = new System.Drawing.Point(348, 44);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(228, 44);
            this.label42.TabIndex = 10000016;
            this.label42.Text = "第2次完成";
            this.label42.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_txtExplanEdu1
            // 
            this.m_txtExplanEdu1.AccessibleDescription = "解释与交代>>第一次完成>>教育项目";
            this.m_txtExplanEdu1.AccessibleName = "";
            this.m_txtExplanEdu1.BackColor = System.Drawing.Color.White;
            this.m_txtExplanEdu1.BorderColor = System.Drawing.Color.Black;
            this.m_txtExplanEdu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanEdu1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExplanEdu1.ForeColor = System.Drawing.Color.Black;
            this.m_txtExplanEdu1.Location = new System.Drawing.Point(116, 140);
            this.m_txtExplanEdu1.Multiline = true;
            this.m_txtExplanEdu1.Name = "m_txtExplanEdu1";
            this.m_txtExplanEdu1.Size = new System.Drawing.Size(76, 44);
            this.m_txtExplanEdu1.TabIndex = 7454;
            this.m_txtExplanEdu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanEdu1.Enter += new System.EventHandler(this.m_txtExplanEdu1_Enter);
            // 
            // m_txtExplanDate1
            // 
            this.m_txtExplanDate1.AccessibleDescription = "解释与交代>>第一次完成>>日期";
            this.m_txtExplanDate1.AccessibleName = "NoDefault";
            this.m_txtExplanDate1.BackColor = System.Drawing.Color.White;
            this.m_txtExplanDate1.BorderColor = System.Drawing.Color.Black;
            this.m_txtExplanDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanDate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExplanDate1.ForeColor = System.Drawing.Color.Black;
            this.m_txtExplanDate1.Location = new System.Drawing.Point(191, 162);
            this.m_txtExplanDate1.Multiline = true;
            this.m_txtExplanDate1.Name = "m_txtExplanDate1";
            this.m_txtExplanDate1.Size = new System.Drawing.Size(136, 22);
            this.m_txtExplanDate1.TabIndex = 7456;
            this.m_txtExplanDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanDate1.Enter += new System.EventHandler(this.m_txtExplanDate1_Enter);
            // 
            // m_txtExplanEdu2
            // 
            this.m_txtExplanEdu2.AccessibleDescription = "解释与交代>>第二次完成>>教育项目";
            this.m_txtExplanEdu2.AccessibleName = "";
            this.m_txtExplanEdu2.BackColor = System.Drawing.Color.White;
            this.m_txtExplanEdu2.BorderColor = System.Drawing.Color.Black;
            this.m_txtExplanEdu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanEdu2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExplanEdu2.ForeColor = System.Drawing.Color.Black;
            this.m_txtExplanEdu2.Location = new System.Drawing.Point(348, 140);
            this.m_txtExplanEdu2.Multiline = true;
            this.m_txtExplanEdu2.Name = "m_txtExplanEdu2";
            this.m_txtExplanEdu2.Size = new System.Drawing.Size(76, 44);
            this.m_txtExplanEdu2.TabIndex = 7475;
            this.m_txtExplanEdu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanEdu2.Enter += new System.EventHandler(this.m_txtExplanEdu2_Enter);
            // 
            // m_txtExplanDate2
            // 
            this.m_txtExplanDate2.AccessibleDescription = "解释与交代>>第二次完成>>日期";
            this.m_txtExplanDate2.AccessibleName = "NoDefault";
            this.m_txtExplanDate2.BackColor = System.Drawing.Color.White;
            this.m_txtExplanDate2.BorderColor = System.Drawing.Color.Black;
            this.m_txtExplanDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanDate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExplanDate2.ForeColor = System.Drawing.Color.Black;
            this.m_txtExplanDate2.Location = new System.Drawing.Point(423, 162);
            this.m_txtExplanDate2.Multiline = true;
            this.m_txtExplanDate2.Name = "m_txtExplanDate2";
            this.m_txtExplanDate2.Size = new System.Drawing.Size(136, 22);
            this.m_txtExplanDate2.TabIndex = 7477;
            this.m_txtExplanDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanDate2.Enter += new System.EventHandler(this.m_txtExplanDate2_Enter);
            // 
            // m_txtExplanEdu3
            // 
            this.m_txtExplanEdu3.AccessibleDescription = "解释与交代>>第三次完成>>教育项目";
            this.m_txtExplanEdu3.AccessibleName = "";
            this.m_txtExplanEdu3.BackColor = System.Drawing.Color.White;
            this.m_txtExplanEdu3.BorderColor = System.Drawing.Color.Black;
            this.m_txtExplanEdu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtExplanEdu3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExplanEdu3.ForeColor = System.Drawing.Color.Black;
            this.m_txtExplanEdu3.Location = new System.Drawing.Point(580, 140);
            this.m_txtExplanEdu3.Multiline = true;
            this.m_txtExplanEdu3.Name = "m_txtExplanEdu3";
            this.m_txtExplanEdu3.Size = new System.Drawing.Size(76, 44);
            this.m_txtExplanEdu3.TabIndex = 7496;
            this.m_txtExplanEdu3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtExplanEdu3.Enter += new System.EventHandler(this.m_txtExplanEdu3_Enter);
            // 
            // m_txtMedicineEdu1
            // 
            this.m_txtMedicineEdu1.AccessibleDescription = "药物服用方法>>第一次完成>>教育项目";
            this.m_txtMedicineEdu1.AccessibleName = "";
            this.m_txtMedicineEdu1.BackColor = System.Drawing.Color.White;
            this.m_txtMedicineEdu1.BorderColor = System.Drawing.Color.Black;
            this.m_txtMedicineEdu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineEdu1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineEdu1.ForeColor = System.Drawing.Color.Black;
            this.m_txtMedicineEdu1.Location = new System.Drawing.Point(116, 188);
            this.m_txtMedicineEdu1.Multiline = true;
            this.m_txtMedicineEdu1.Name = "m_txtMedicineEdu1";
            this.m_txtMedicineEdu1.Size = new System.Drawing.Size(76, 44);
            this.m_txtMedicineEdu1.TabIndex = 7457;
            this.m_txtMedicineEdu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineEdu1.Enter += new System.EventHandler(this.m_txtMedicineEdu1_Enter);
            // 
            // m_txtMedicineEdu2
            // 
            this.m_txtMedicineEdu2.AccessibleDescription = "药物服用方法>>第二次完成>>教育项目";
            this.m_txtMedicineEdu2.AccessibleName = "";
            this.m_txtMedicineEdu2.BackColor = System.Drawing.Color.White;
            this.m_txtMedicineEdu2.BorderColor = System.Drawing.Color.Black;
            this.m_txtMedicineEdu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineEdu2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineEdu2.ForeColor = System.Drawing.Color.Black;
            this.m_txtMedicineEdu2.Location = new System.Drawing.Point(348, 188);
            this.m_txtMedicineEdu2.Multiline = true;
            this.m_txtMedicineEdu2.Name = "m_txtMedicineEdu2";
            this.m_txtMedicineEdu2.Size = new System.Drawing.Size(76, 44);
            this.m_txtMedicineEdu2.TabIndex = 7478;
            this.m_txtMedicineEdu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineEdu2.Enter += new System.EventHandler(this.m_txtMedicineEdu2_Enter);
            // 
            // m_txtMedicineEdu3
            // 
            this.m_txtMedicineEdu3.AccessibleDescription = "药物服用方法>>第三次完成>>教育项目";
            this.m_txtMedicineEdu3.AccessibleName = "";
            this.m_txtMedicineEdu3.BackColor = System.Drawing.Color.White;
            this.m_txtMedicineEdu3.BorderColor = System.Drawing.Color.Black;
            this.m_txtMedicineEdu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedicineEdu3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineEdu3.ForeColor = System.Drawing.Color.Black;
            this.m_txtMedicineEdu3.Location = new System.Drawing.Point(580, 188);
            this.m_txtMedicineEdu3.Multiline = true;
            this.m_txtMedicineEdu3.Name = "m_txtMedicineEdu3";
            this.m_txtMedicineEdu3.Size = new System.Drawing.Size(76, 44);
            this.m_txtMedicineEdu3.TabIndex = 7499;
            this.m_txtMedicineEdu3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtMedicineEdu3.Enter += new System.EventHandler(this.m_txtMedicineEdu3_Enter);
            // 
            // m_txtNoticeEdu1
            // 
            this.m_txtNoticeEdu1.AccessibleDescription = "注意事项>>第一次完成>>教育项目";
            this.m_txtNoticeEdu1.AccessibleName = "";
            this.m_txtNoticeEdu1.BackColor = System.Drawing.Color.White;
            this.m_txtNoticeEdu1.BorderColor = System.Drawing.Color.Black;
            this.m_txtNoticeEdu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeEdu1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNoticeEdu1.ForeColor = System.Drawing.Color.Black;
            this.m_txtNoticeEdu1.Location = new System.Drawing.Point(116, 236);
            this.m_txtNoticeEdu1.Multiline = true;
            this.m_txtNoticeEdu1.Name = "m_txtNoticeEdu1";
            this.m_txtNoticeEdu1.Size = new System.Drawing.Size(76, 44);
            this.m_txtNoticeEdu1.TabIndex = 7460;
            this.m_txtNoticeEdu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeEdu1.Enter += new System.EventHandler(this.m_txtNoticeEdu1_Enter);
            // 
            // m_txtNoticeEdu2
            // 
            this.m_txtNoticeEdu2.AccessibleDescription = "注意事项>>第二次完成>>教育项目";
            this.m_txtNoticeEdu2.AccessibleName = "";
            this.m_txtNoticeEdu2.BackColor = System.Drawing.Color.White;
            this.m_txtNoticeEdu2.BorderColor = System.Drawing.Color.Black;
            this.m_txtNoticeEdu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeEdu2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNoticeEdu2.ForeColor = System.Drawing.Color.Black;
            this.m_txtNoticeEdu2.Location = new System.Drawing.Point(348, 236);
            this.m_txtNoticeEdu2.Multiline = true;
            this.m_txtNoticeEdu2.Name = "m_txtNoticeEdu2";
            this.m_txtNoticeEdu2.Size = new System.Drawing.Size(76, 44);
            this.m_txtNoticeEdu2.TabIndex = 7481;
            this.m_txtNoticeEdu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeEdu2.Enter += new System.EventHandler(this.m_txtNoticeEdu2_Enter);
            // 
            // m_txtNoticeEdu3
            // 
            this.m_txtNoticeEdu3.AccessibleDescription = "注意事项>>第三次完成>>教育项目";
            this.m_txtNoticeEdu3.AccessibleName = "";
            this.m_txtNoticeEdu3.BackColor = System.Drawing.Color.White;
            this.m_txtNoticeEdu3.BorderColor = System.Drawing.Color.Black;
            this.m_txtNoticeEdu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNoticeEdu3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNoticeEdu3.ForeColor = System.Drawing.Color.Black;
            this.m_txtNoticeEdu3.Location = new System.Drawing.Point(580, 236);
            this.m_txtNoticeEdu3.Multiline = true;
            this.m_txtNoticeEdu3.Name = "m_txtNoticeEdu3";
            this.m_txtNoticeEdu3.Size = new System.Drawing.Size(76, 44);
            this.m_txtNoticeEdu3.TabIndex = 7502;
            this.m_txtNoticeEdu3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtNoticeEdu3.Enter += new System.EventHandler(this.m_txtNoticeEdu3_Enter);
            // 
            // m_txtKnowledgeEdu3
            // 
            this.m_txtKnowledgeEdu3.AccessibleDescription = "有关知识>>第三次完成>>教育项目";
            this.m_txtKnowledgeEdu3.AccessibleName = "";
            this.m_txtKnowledgeEdu3.BackColor = System.Drawing.Color.White;
            this.m_txtKnowledgeEdu3.BorderColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeEdu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeEdu3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKnowledgeEdu3.ForeColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeEdu3.Location = new System.Drawing.Point(580, 284);
            this.m_txtKnowledgeEdu3.Multiline = true;
            this.m_txtKnowledgeEdu3.Name = "m_txtKnowledgeEdu3";
            this.m_txtKnowledgeEdu3.Size = new System.Drawing.Size(76, 44);
            this.m_txtKnowledgeEdu3.TabIndex = 7505;
            this.m_txtKnowledgeEdu3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeEdu3.Enter += new System.EventHandler(this.m_txtKnowledgeEdu3_Enter);
            // 
            // m_txtKnowledgeDate3
            // 
            this.m_txtKnowledgeDate3.AccessibleDescription = "有关知识>>第三次完成>>日期";
            this.m_txtKnowledgeDate3.AccessibleName = "NoDefault";
            this.m_txtKnowledgeDate3.BackColor = System.Drawing.Color.White;
            this.m_txtKnowledgeDate3.BorderColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeDate3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKnowledgeDate3.ForeColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeDate3.Location = new System.Drawing.Point(655, 306);
            this.m_txtKnowledgeDate3.Multiline = true;
            this.m_txtKnowledgeDate3.Name = "m_txtKnowledgeDate3";
            this.m_txtKnowledgeDate3.Size = new System.Drawing.Size(136, 22);
            this.m_txtKnowledgeDate3.TabIndex = 7507;
            this.m_txtKnowledgeDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeDate3.Enter += new System.EventHandler(this.m_txtKnowledgeDate3_Enter);
            // 
            // m_txtKnowledgeEdu1
            // 
            this.m_txtKnowledgeEdu1.AccessibleDescription = "有关知识>>第一次完成>>教育项目";
            this.m_txtKnowledgeEdu1.AccessibleName = "";
            this.m_txtKnowledgeEdu1.BackColor = System.Drawing.Color.White;
            this.m_txtKnowledgeEdu1.BorderColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeEdu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtKnowledgeEdu1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKnowledgeEdu1.ForeColor = System.Drawing.Color.Black;
            this.m_txtKnowledgeEdu1.Location = new System.Drawing.Point(116, 284);
            this.m_txtKnowledgeEdu1.Multiline = true;
            this.m_txtKnowledgeEdu1.Name = "m_txtKnowledgeEdu1";
            this.m_txtKnowledgeEdu1.Size = new System.Drawing.Size(76, 44);
            this.m_txtKnowledgeEdu1.TabIndex = 7463;
            this.m_txtKnowledgeEdu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtKnowledgeEdu1.Enter += new System.EventHandler(this.m_txtKnowledgeEdu1_Enter);
            // 
            // m_txtGuidanceEdu1
            // 
            this.m_txtGuidanceEdu1.AccessibleDescription = "康复指导>>第一次完成>>教育项目";
            this.m_txtGuidanceEdu1.AccessibleName = "";
            this.m_txtGuidanceEdu1.BackColor = System.Drawing.Color.White;
            this.m_txtGuidanceEdu1.BorderColor = System.Drawing.Color.Black;
            this.m_txtGuidanceEdu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceEdu1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGuidanceEdu1.ForeColor = System.Drawing.Color.Black;
            this.m_txtGuidanceEdu1.Location = new System.Drawing.Point(116, 332);
            this.m_txtGuidanceEdu1.Multiline = true;
            this.m_txtGuidanceEdu1.Name = "m_txtGuidanceEdu1";
            this.m_txtGuidanceEdu1.Size = new System.Drawing.Size(76, 44);
            this.m_txtGuidanceEdu1.TabIndex = 7466;
            this.m_txtGuidanceEdu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceEdu1.Enter += new System.EventHandler(this.m_txtGuidanceEdu1_Enter);
            // 
            // m_txtGuidanceEdu3
            // 
            this.m_txtGuidanceEdu3.AccessibleDescription = "康复指导>>第三次完成>>教育项目";
            this.m_txtGuidanceEdu3.AccessibleName = "";
            this.m_txtGuidanceEdu3.BackColor = System.Drawing.Color.White;
            this.m_txtGuidanceEdu3.BorderColor = System.Drawing.Color.Black;
            this.m_txtGuidanceEdu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceEdu3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGuidanceEdu3.ForeColor = System.Drawing.Color.Black;
            this.m_txtGuidanceEdu3.Location = new System.Drawing.Point(580, 332);
            this.m_txtGuidanceEdu3.Multiline = true;
            this.m_txtGuidanceEdu3.Name = "m_txtGuidanceEdu3";
            this.m_txtGuidanceEdu3.Size = new System.Drawing.Size(76, 44);
            this.m_txtGuidanceEdu3.TabIndex = 7508;
            this.m_txtGuidanceEdu3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceEdu3.Enter += new System.EventHandler(this.m_txtGuidanceEdu3_Enter);
            // 
            // m_txtGuidanceEdu2
            // 
            this.m_txtGuidanceEdu2.AccessibleDescription = "康复指导>>第二次完成>>教育项目";
            this.m_txtGuidanceEdu2.AccessibleName = "";
            this.m_txtGuidanceEdu2.BackColor = System.Drawing.Color.White;
            this.m_txtGuidanceEdu2.BorderColor = System.Drawing.Color.Black;
            this.m_txtGuidanceEdu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtGuidanceEdu2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGuidanceEdu2.ForeColor = System.Drawing.Color.Black;
            this.m_txtGuidanceEdu2.Location = new System.Drawing.Point(348, 332);
            this.m_txtGuidanceEdu2.Multiline = true;
            this.m_txtGuidanceEdu2.Name = "m_txtGuidanceEdu2";
            this.m_txtGuidanceEdu2.Size = new System.Drawing.Size(76, 44);
            this.m_txtGuidanceEdu2.TabIndex = 7487;
            this.m_txtGuidanceEdu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtGuidanceEdu2.Enter += new System.EventHandler(this.m_txtGuidanceEdu2_Enter);
            // 
            // m_txtOtherEdu2
            // 
            this.m_txtOtherEdu2.AccessibleDescription = "其他>>第二次完成>>教育项目";
            this.m_txtOtherEdu2.AccessibleName = "";
            this.m_txtOtherEdu2.BackColor = System.Drawing.Color.White;
            this.m_txtOtherEdu2.BorderColor = System.Drawing.Color.Black;
            this.m_txtOtherEdu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherEdu2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherEdu2.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherEdu2.Location = new System.Drawing.Point(348, 380);
            this.m_txtOtherEdu2.Multiline = true;
            this.m_txtOtherEdu2.Name = "m_txtOtherEdu2";
            this.m_txtOtherEdu2.Size = new System.Drawing.Size(76, 44);
            this.m_txtOtherEdu2.TabIndex = 7490;
            this.m_txtOtherEdu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherEdu2.Enter += new System.EventHandler(this.m_txtOtherEdu2_Enter);
            // 
            // m_txtOtherEdu3
            // 
            this.m_txtOtherEdu3.AccessibleDescription = "其他>>第三次完成>>教育项目";
            this.m_txtOtherEdu3.AccessibleName = "";
            this.m_txtOtherEdu3.BackColor = System.Drawing.Color.White;
            this.m_txtOtherEdu3.BorderColor = System.Drawing.Color.Black;
            this.m_txtOtherEdu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherEdu3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherEdu3.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherEdu3.Location = new System.Drawing.Point(580, 380);
            this.m_txtOtherEdu3.Multiline = true;
            this.m_txtOtherEdu3.Name = "m_txtOtherEdu3";
            this.m_txtOtherEdu3.Size = new System.Drawing.Size(76, 44);
            this.m_txtOtherEdu3.TabIndex = 7511;
            this.m_txtOtherEdu3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherEdu3.Enter += new System.EventHandler(this.m_txtOtherEdu3_Enter);
            // 
            // dtpNurseSignDate73
            // 
            this.dtpNurseSignDate73.AccessibleDescription = "";
            this.dtpNurseSignDate73.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate73.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate73.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate73.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate73.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate73.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate73.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate73.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate73.Location = new System.Drawing.Point(657, 402);
            this.dtpNurseSignDate73.m_BlnOnlyTime = false;
            this.dtpNurseSignDate73.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate73.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate73.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate73.Name = "dtpNurseSignDate73";
            this.dtpNurseSignDate73.ReadOnly = false;
            this.dtpNurseSignDate73.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate73.TabIndex = 10000019;
            this.dtpNurseSignDate73.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate73.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate73.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate73_evtValueChanged);
            // 
            // dtpNurseSignDate63
            // 
            this.dtpNurseSignDate63.AccessibleDescription = "";
            this.dtpNurseSignDate63.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate63.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate63.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate63.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate63.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate63.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate63.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate63.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate63.Location = new System.Drawing.Point(657, 354);
            this.dtpNurseSignDate63.m_BlnOnlyTime = false;
            this.dtpNurseSignDate63.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate63.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate63.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate63.Name = "dtpNurseSignDate63";
            this.dtpNurseSignDate63.ReadOnly = false;
            this.dtpNurseSignDate63.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate63.TabIndex = 10000019;
            this.dtpNurseSignDate63.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate63.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate63.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate63_evtValueChanged);
            // 
            // dtpNurseSignDate53
            // 
            this.dtpNurseSignDate53.AccessibleDescription = "";
            this.dtpNurseSignDate53.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate53.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate53.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate53.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate53.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate53.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate53.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate53.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate53.Location = new System.Drawing.Point(657, 306);
            this.dtpNurseSignDate53.m_BlnOnlyTime = false;
            this.dtpNurseSignDate53.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate53.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate53.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate53.Name = "dtpNurseSignDate53";
            this.dtpNurseSignDate53.ReadOnly = false;
            this.dtpNurseSignDate53.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate53.TabIndex = 10000019;
            this.dtpNurseSignDate53.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate53.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate53.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate53_evtValueChanged);
            // 
            // dtpNurseSignDate43
            // 
            this.dtpNurseSignDate43.AccessibleDescription = "";
            this.dtpNurseSignDate43.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate43.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate43.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate43.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate43.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate43.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate43.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate43.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate43.Location = new System.Drawing.Point(657, 258);
            this.dtpNurseSignDate43.m_BlnOnlyTime = false;
            this.dtpNurseSignDate43.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate43.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate43.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate43.Name = "dtpNurseSignDate43";
            this.dtpNurseSignDate43.ReadOnly = false;
            this.dtpNurseSignDate43.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate43.TabIndex = 10000019;
            this.dtpNurseSignDate43.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate43.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate43.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate43_evtValueChanged);
            // 
            // dtpNurseSignDate33
            // 
            this.dtpNurseSignDate33.AccessibleDescription = "";
            this.dtpNurseSignDate33.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate33.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate33.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate33.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate33.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate33.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate33.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate33.Location = new System.Drawing.Point(657, 210);
            this.dtpNurseSignDate33.m_BlnOnlyTime = false;
            this.dtpNurseSignDate33.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate33.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate33.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate33.Name = "dtpNurseSignDate33";
            this.dtpNurseSignDate33.ReadOnly = false;
            this.dtpNurseSignDate33.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate33.TabIndex = 10000019;
            this.dtpNurseSignDate33.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate33.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate33.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate33_evtValueChanged);
            // 
            // dtpNurseSignDate72
            // 
            this.dtpNurseSignDate72.AccessibleDescription = "";
            this.dtpNurseSignDate72.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate72.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate72.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate72.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate72.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate72.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate72.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate72.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate72.Location = new System.Drawing.Point(425, 402);
            this.dtpNurseSignDate72.m_BlnOnlyTime = false;
            this.dtpNurseSignDate72.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate72.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate72.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate72.Name = "dtpNurseSignDate72";
            this.dtpNurseSignDate72.ReadOnly = false;
            this.dtpNurseSignDate72.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate72.TabIndex = 10000019;
            this.dtpNurseSignDate72.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate72.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate72.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate72_evtValueChanged);
            // 
            // dtpNurseSignDate62
            // 
            this.dtpNurseSignDate62.AccessibleDescription = "";
            this.dtpNurseSignDate62.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate62.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate62.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate62.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate62.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate62.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate62.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate62.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate62.Location = new System.Drawing.Point(425, 354);
            this.dtpNurseSignDate62.m_BlnOnlyTime = false;
            this.dtpNurseSignDate62.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate62.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate62.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate62.Name = "dtpNurseSignDate62";
            this.dtpNurseSignDate62.ReadOnly = false;
            this.dtpNurseSignDate62.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate62.TabIndex = 10000019;
            this.dtpNurseSignDate62.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate62.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate62.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate62_evtValueChanged);
            // 
            // m_txtOtherEdu1
            // 
            this.m_txtOtherEdu1.AccessibleDescription = "其他>>第一次完成>>教育项目";
            this.m_txtOtherEdu1.AccessibleName = "";
            this.m_txtOtherEdu1.BackColor = System.Drawing.Color.White;
            this.m_txtOtherEdu1.BorderColor = System.Drawing.Color.Black;
            this.m_txtOtherEdu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherEdu1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherEdu1.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherEdu1.Location = new System.Drawing.Point(116, 380);
            this.m_txtOtherEdu1.Multiline = true;
            this.m_txtOtherEdu1.Name = "m_txtOtherEdu1";
            this.m_txtOtherEdu1.Size = new System.Drawing.Size(76, 44);
            this.m_txtOtherEdu1.TabIndex = 7469;
            this.m_txtOtherEdu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtOtherEdu1.Enter += new System.EventHandler(this.m_txtOtherEdu1_Enter);
            // 
            // dtpNurseSignDate52
            // 
            this.dtpNurseSignDate52.AccessibleDescription = "";
            this.dtpNurseSignDate52.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate52.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate52.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate52.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate52.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate52.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate52.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate52.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate52.Location = new System.Drawing.Point(425, 306);
            this.dtpNurseSignDate52.m_BlnOnlyTime = false;
            this.dtpNurseSignDate52.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate52.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate52.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate52.Name = "dtpNurseSignDate52";
            this.dtpNurseSignDate52.ReadOnly = false;
            this.dtpNurseSignDate52.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate52.TabIndex = 10000019;
            this.dtpNurseSignDate52.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate52.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate52.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate52_evtValueChanged);
            // 
            // dtpNurseSignDate42
            // 
            this.dtpNurseSignDate42.AccessibleDescription = "";
            this.dtpNurseSignDate42.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate42.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate42.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate42.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate42.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate42.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate42.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate42.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate42.Location = new System.Drawing.Point(425, 258);
            this.dtpNurseSignDate42.m_BlnOnlyTime = false;
            this.dtpNurseSignDate42.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate42.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate42.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate42.Name = "dtpNurseSignDate42";
            this.dtpNurseSignDate42.ReadOnly = false;
            this.dtpNurseSignDate42.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate42.TabIndex = 10000019;
            this.dtpNurseSignDate42.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate42.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate42.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate42_evtValueChanged);
            // 
            // dtpNurseSignDate23
            // 
            this.dtpNurseSignDate23.AccessibleDescription = "";
            this.dtpNurseSignDate23.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate23.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate23.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate23.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate23.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate23.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate23.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate23.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate23.Location = new System.Drawing.Point(657, 162);
            this.dtpNurseSignDate23.m_BlnOnlyTime = false;
            this.dtpNurseSignDate23.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate23.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate23.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate23.Name = "dtpNurseSignDate23";
            this.dtpNurseSignDate23.ReadOnly = false;
            this.dtpNurseSignDate23.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate23.TabIndex = 10000019;
            this.dtpNurseSignDate23.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate23.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate23.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate23_evtValueChanged);
            // 
            // dtpNurseSignDate32
            // 
            this.dtpNurseSignDate32.AccessibleDescription = "";
            this.dtpNurseSignDate32.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate32.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate32.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate32.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate32.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate32.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate32.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate32.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate32.Location = new System.Drawing.Point(425, 210);
            this.dtpNurseSignDate32.m_BlnOnlyTime = false;
            this.dtpNurseSignDate32.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate32.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate32.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate32.Name = "dtpNurseSignDate32";
            this.dtpNurseSignDate32.ReadOnly = false;
            this.dtpNurseSignDate32.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate32.TabIndex = 10000019;
            this.dtpNurseSignDate32.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate32.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate32.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate32_evtValueChanged);
            // 
            // dtpNurseSignDate13
            // 
            this.dtpNurseSignDate13.AccessibleDescription = "";
            this.dtpNurseSignDate13.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate13.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate13.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate13.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate13.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate13.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate13.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate13.Location = new System.Drawing.Point(657, 114);
            this.dtpNurseSignDate13.m_BlnOnlyTime = false;
            this.dtpNurseSignDate13.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate13.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate13.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate13.Name = "dtpNurseSignDate13";
            this.dtpNurseSignDate13.ReadOnly = false;
            this.dtpNurseSignDate13.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate13.TabIndex = 10000019;
            this.dtpNurseSignDate13.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate13.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate13.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate13_evtValueChanged);
            // 
            // dtpNurseSignDate22
            // 
            this.dtpNurseSignDate22.AccessibleDescription = "";
            this.dtpNurseSignDate22.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate22.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate22.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate22.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate22.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate22.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate22.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate22.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate22.Location = new System.Drawing.Point(425, 162);
            this.dtpNurseSignDate22.m_BlnOnlyTime = false;
            this.dtpNurseSignDate22.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate22.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate22.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate22.Name = "dtpNurseSignDate22";
            this.dtpNurseSignDate22.ReadOnly = false;
            this.dtpNurseSignDate22.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate22.TabIndex = 10000019;
            this.dtpNurseSignDate22.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate22.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate22.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate22_evtValueChanged);
            // 
            // dtpNurseSignDate71
            // 
            this.dtpNurseSignDate71.AccessibleDescription = "";
            this.dtpNurseSignDate71.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate71.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate71.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate71.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate71.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate71.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate71.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate71.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate71.Location = new System.Drawing.Point(193, 402);
            this.dtpNurseSignDate71.m_BlnOnlyTime = false;
            this.dtpNurseSignDate71.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate71.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate71.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate71.Name = "dtpNurseSignDate71";
            this.dtpNurseSignDate71.ReadOnly = false;
            this.dtpNurseSignDate71.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate71.TabIndex = 10000019;
            this.dtpNurseSignDate71.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate71.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate71.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate71_evtValueChanged);
            // 
            // dtpNurseSignDate12
            // 
            this.dtpNurseSignDate12.AccessibleDescription = "";
            this.dtpNurseSignDate12.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate12.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate12.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate12.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate12.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate12.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate12.Location = new System.Drawing.Point(425, 114);
            this.dtpNurseSignDate12.m_BlnOnlyTime = false;
            this.dtpNurseSignDate12.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate12.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate12.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate12.Name = "dtpNurseSignDate12";
            this.dtpNurseSignDate12.ReadOnly = false;
            this.dtpNurseSignDate12.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate12.TabIndex = 10000019;
            this.dtpNurseSignDate12.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate12.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate12.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate12_evtValueChanged);
            // 
            // dtpNurseSignDate61
            // 
            this.dtpNurseSignDate61.AccessibleDescription = "";
            this.dtpNurseSignDate61.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate61.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate61.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate61.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate61.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate61.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate61.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate61.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate61.Location = new System.Drawing.Point(193, 354);
            this.dtpNurseSignDate61.m_BlnOnlyTime = false;
            this.dtpNurseSignDate61.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate61.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate61.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate61.Name = "dtpNurseSignDate61";
            this.dtpNurseSignDate61.ReadOnly = false;
            this.dtpNurseSignDate61.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate61.TabIndex = 10000019;
            this.dtpNurseSignDate61.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate61.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate61.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate61_evtValueChanged);
            // 
            // dtpNurseSignDate51
            // 
            this.dtpNurseSignDate51.AccessibleDescription = "";
            this.dtpNurseSignDate51.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate51.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate51.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate51.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate51.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate51.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate51.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate51.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate51.Location = new System.Drawing.Point(193, 306);
            this.dtpNurseSignDate51.m_BlnOnlyTime = false;
            this.dtpNurseSignDate51.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate51.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate51.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate51.Name = "dtpNurseSignDate51";
            this.dtpNurseSignDate51.ReadOnly = false;
            this.dtpNurseSignDate51.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate51.TabIndex = 10000019;
            this.dtpNurseSignDate51.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate51.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate51.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate51_evtValueChanged);
            // 
            // dtpNurseSignDate41
            // 
            this.dtpNurseSignDate41.AccessibleDescription = "";
            this.dtpNurseSignDate41.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate41.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate41.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate41.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate41.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate41.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate41.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate41.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate41.Location = new System.Drawing.Point(193, 258);
            this.dtpNurseSignDate41.m_BlnOnlyTime = false;
            this.dtpNurseSignDate41.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate41.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate41.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate41.Name = "dtpNurseSignDate41";
            this.dtpNurseSignDate41.ReadOnly = false;
            this.dtpNurseSignDate41.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate41.TabIndex = 10000019;
            this.dtpNurseSignDate41.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate41.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate41.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate41_evtValueChanged);
            // 
            // dtpNurseSignDate31
            // 
            this.dtpNurseSignDate31.AccessibleDescription = "";
            this.dtpNurseSignDate31.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate31.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate31.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate31.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate31.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate31.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate31.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate31.Location = new System.Drawing.Point(193, 210);
            this.dtpNurseSignDate31.m_BlnOnlyTime = false;
            this.dtpNurseSignDate31.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate31.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate31.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate31.Name = "dtpNurseSignDate31";
            this.dtpNurseSignDate31.ReadOnly = false;
            this.dtpNurseSignDate31.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate31.TabIndex = 10000019;
            this.dtpNurseSignDate31.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate31.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate31.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate31_evtValueChanged);
            // 
            // dtpNurseSignDate21
            // 
            this.dtpNurseSignDate21.AccessibleDescription = "";
            this.dtpNurseSignDate21.BorderColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate21.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpNurseSignDate21.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpNurseSignDate21.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNurseSignDate21.DropButtonForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpNurseSignDate21.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpNurseSignDate21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpNurseSignDate21.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNurseSignDate21.Location = new System.Drawing.Point(193, 162);
            this.dtpNurseSignDate21.m_BlnOnlyTime = false;
            this.dtpNurseSignDate21.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpNurseSignDate21.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNurseSignDate21.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNurseSignDate21.Name = "dtpNurseSignDate21";
            this.dtpNurseSignDate21.ReadOnly = false;
            this.dtpNurseSignDate21.Size = new System.Drawing.Size(151, 22);
            this.dtpNurseSignDate21.TabIndex = 10000019;
            this.dtpNurseSignDate21.TextBackColor = System.Drawing.Color.White;
            this.dtpNurseSignDate21.TextForeColor = System.Drawing.Color.Black;
            this.dtpNurseSignDate21.evtValueChanged += new System.EventHandler(this.dtpNurseSignDate21_evtValueChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lblInHospitalDays);
            this.tabPage5.Controls.Add(this.label49);
            this.tabPage5.Controls.Add(this.m_cmdChargeNurse);
            this.tabPage5.Controls.Add(this.m_txtNurseSign);
            this.tabPage5.Controls.Add(this.groupBox36);
            this.tabPage5.Controls.Add(this.groupBox30);
            this.tabPage5.Controls.Add(this.groupBox27);
            this.tabPage5.Controls.Add(this.m_cmdNurseSign);
            this.tabPage5.Controls.Add(this.m_txtChargeNurse);
            this.tabPage5.Controls.Add(this.label50);
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(816, 507);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "病人出院评估及指导";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lblInHospitalDays
            // 
            this.lblInHospitalDays.AccessibleDescription = "住院天数";
            this.lblInHospitalDays.Location = new System.Drawing.Point(696, 40);
            this.lblInHospitalDays.Name = "lblInHospitalDays";
            this.lblInHospitalDays.Size = new System.Drawing.Size(72, 23);
            this.lblInHospitalDays.TabIndex = 5608;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(656, 40);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(35, 14);
            this.label49.TabIndex = 5607;
            this.label49.Text = "住院";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cmdChargeNurse
            // 
            this.m_cmdChargeNurse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdChargeNurse.DefaultScheme = true;
            this.m_cmdChargeNurse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChargeNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdChargeNurse.Hint = "";
            this.m_cmdChargeNurse.Location = new System.Drawing.Point(584, 478);
            this.m_cmdChargeNurse.Name = "m_cmdChargeNurse";
            this.m_cmdChargeNurse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChargeNurse.Size = new System.Drawing.Size(104, 28);
            this.m_cmdChargeNurse.TabIndex = 5604;
            this.m_cmdChargeNurse.Tag = "1";
            this.m_cmdChargeNurse.Text = "护长签名:";
            // 
            // m_txtNurseSign
            // 
            this.m_txtNurseSign.AccessibleName = "NoDefault";
            this.m_txtNurseSign.BackColor = System.Drawing.Color.White;
            this.m_txtNurseSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNurseSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtNurseSign.Location = new System.Drawing.Point(448, 482);
            this.m_txtNurseSign.Name = "m_txtNurseSign";
            this.m_txtNurseSign.ReadOnly = true;
            this.m_txtNurseSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtNurseSign.TabIndex = 9350;
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.groupBox39);
            this.groupBox36.Controls.Add(this.groupBox38);
            this.groupBox36.Controls.Add(this.groupBox37);
            this.groupBox36.Location = new System.Drawing.Point(8, 290);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(800, 184);
            this.groupBox36.TabIndex = 2;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "出院病人健康指导";
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.chkSpecialtiesCoach0);
            this.groupBox39.Controls.Add(this.chkSpecialtiesCoach1);
            this.groupBox39.Controls.Add(this.m_txtSpecialtiesCoach);
            this.groupBox39.Location = new System.Drawing.Point(320, 128);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(472, 48);
            this.groupBox39.TabIndex = 2;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "三、专科指导";
            // 
            // chkSpecialtiesCoach0
            // 
            this.chkSpecialtiesCoach0.AccessibleDescription = "专科指导>>无";
            this.chkSpecialtiesCoach0.Location = new System.Drawing.Point(8, 16);
            this.chkSpecialtiesCoach0.Name = "chkSpecialtiesCoach0";
            this.chkSpecialtiesCoach0.Size = new System.Drawing.Size(40, 24);
            this.chkSpecialtiesCoach0.TabIndex = 9200;
            this.chkSpecialtiesCoach0.Text = "无";
            this.chkSpecialtiesCoach0.CheckedChanged += new System.EventHandler(this.chkSpecialtiesCoach0_CheckedChanged);
            // 
            // chkSpecialtiesCoach1
            // 
            this.chkSpecialtiesCoach1.AccessibleDescription = "专科指导>>有";
            this.chkSpecialtiesCoach1.Location = new System.Drawing.Point(56, 16);
            this.chkSpecialtiesCoach1.Name = "chkSpecialtiesCoach1";
            this.chkSpecialtiesCoach1.Size = new System.Drawing.Size(40, 24);
            this.chkSpecialtiesCoach1.TabIndex = 9250;
            this.chkSpecialtiesCoach1.Text = "有";
            this.chkSpecialtiesCoach1.CheckedChanged += new System.EventHandler(this.chkSpecialtiesCoach1_CheckedChanged);
            // 
            // m_txtSpecialtiesCoach
            // 
            this.m_txtSpecialtiesCoach.AccessibleDescription = "专科指导>>有";
            this.m_txtSpecialtiesCoach.BackColor = System.Drawing.Color.White;
            this.m_txtSpecialtiesCoach.Enabled = false;
            this.m_txtSpecialtiesCoach.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSpecialtiesCoach.ForeColor = System.Drawing.Color.Black;
            this.m_txtSpecialtiesCoach.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSpecialtiesCoach.Location = new System.Drawing.Point(96, 16);
            this.m_txtSpecialtiesCoach.m_BlnIgnoreUserInfo = false;
            this.m_txtSpecialtiesCoach.m_BlnPartControl = false;
            this.m_txtSpecialtiesCoach.m_BlnReadOnly = false;
            this.m_txtSpecialtiesCoach.m_BlnUnderLineDST = false;
            this.m_txtSpecialtiesCoach.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSpecialtiesCoach.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSpecialtiesCoach.m_IntCanModifyTime = 6;
            this.m_txtSpecialtiesCoach.m_IntPartControlLength = 0;
            this.m_txtSpecialtiesCoach.m_IntPartControlStartIndex = 0;
            this.m_txtSpecialtiesCoach.m_StrUserID = "";
            this.m_txtSpecialtiesCoach.m_StrUserName = "";
            this.m_txtSpecialtiesCoach.MaxLength = 8000;
            this.m_txtSpecialtiesCoach.Multiline = false;
            this.m_txtSpecialtiesCoach.Name = "m_txtSpecialtiesCoach";
            this.m_txtSpecialtiesCoach.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSpecialtiesCoach.Size = new System.Drawing.Size(368, 23);
            this.m_txtSpecialtiesCoach.TabIndex = 9300;
            this.m_txtSpecialtiesCoach.Text = "";
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.chkAdviceDrug0);
            this.groupBox38.Controls.Add(this.chkAdviceDrug1);
            this.groupBox38.Controls.Add(this.chkAdviceDrug2);
            this.groupBox38.Controls.Add(this.chkAdviceDrug3);
            this.groupBox38.Location = new System.Drawing.Point(8, 128);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(304, 48);
            this.groupBox38.TabIndex = 1;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "二、按医嘱用药";
            // 
            // chkAdviceDrug0
            // 
            this.chkAdviceDrug0.AccessibleDescription = "按医嘱用药>>明白";
            this.chkAdviceDrug0.Location = new System.Drawing.Point(8, 16);
            this.chkAdviceDrug0.Name = "chkAdviceDrug0";
            this.chkAdviceDrug0.Size = new System.Drawing.Size(56, 24);
            this.chkAdviceDrug0.TabIndex = 9000;
            this.chkAdviceDrug0.Text = "明白";
            // 
            // chkAdviceDrug1
            // 
            this.chkAdviceDrug1.AccessibleDescription = "按医嘱用药>>不明白";
            this.chkAdviceDrug1.Location = new System.Drawing.Point(72, 16);
            this.chkAdviceDrug1.Name = "chkAdviceDrug1";
            this.chkAdviceDrug1.Size = new System.Drawing.Size(72, 24);
            this.chkAdviceDrug1.TabIndex = 9050;
            this.chkAdviceDrug1.Text = "不明白";
            // 
            // chkAdviceDrug2
            // 
            this.chkAdviceDrug2.AccessibleDescription = "按医嘱用药>>交待家属";
            this.chkAdviceDrug2.Location = new System.Drawing.Point(152, 16);
            this.chkAdviceDrug2.Name = "chkAdviceDrug2";
            this.chkAdviceDrug2.Size = new System.Drawing.Size(88, 24);
            this.chkAdviceDrug2.TabIndex = 9100;
            this.chkAdviceDrug2.Text = "交待家属";
            // 
            // chkAdviceDrug3
            // 
            this.chkAdviceDrug3.AccessibleDescription = "按医嘱用药>>无药";
            this.chkAdviceDrug3.Location = new System.Drawing.Point(240, 16);
            this.chkAdviceDrug3.Name = "chkAdviceDrug3";
            this.chkAdviceDrug3.Size = new System.Drawing.Size(56, 24);
            this.chkAdviceDrug3.TabIndex = 9150;
            this.chkAdviceDrug3.Text = "无药";
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.chkCommonlyCoach0);
            this.groupBox37.Controls.Add(this.chkCommonlyCoach1);
            this.groupBox37.Controls.Add(this.chkCommonlyCoach2);
            this.groupBox37.Controls.Add(this.chkCommonlyCoach3);
            this.groupBox37.Controls.Add(this.chkCommonlyCoach4);
            this.groupBox37.Controls.Add(this.chkCommonlyCoach5);
            this.groupBox37.Controls.Add(this.chkCommonlyCoach6);
            this.groupBox37.Controls.Add(this.chkCommonlyCoach7);
            this.groupBox37.Location = new System.Drawing.Point(8, 24);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(784, 96);
            this.groupBox37.TabIndex = 0;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "一、一般指导";
            // 
            // chkCommonlyCoach0
            // 
            this.chkCommonlyCoach0.AccessibleDescription = "一般指导>>休养环境";
            this.chkCommonlyCoach0.Location = new System.Drawing.Point(8, 16);
            this.chkCommonlyCoach0.Name = "chkCommonlyCoach0";
            this.chkCommonlyCoach0.Size = new System.Drawing.Size(288, 24);
            this.chkCommonlyCoach0.TabIndex = 8600;
            this.chkCommonlyCoach0.Text = "休养环境应清洁舒适，保持室内空气新鲜";
            // 
            // chkCommonlyCoach1
            // 
            this.chkCommonlyCoach1.AccessibleDescription = "一般指导>>稳定情绪有利健康";
            this.chkCommonlyCoach1.Location = new System.Drawing.Point(296, 16);
            this.chkCommonlyCoach1.Name = "chkCommonlyCoach1";
            this.chkCommonlyCoach1.Size = new System.Drawing.Size(144, 24);
            this.chkCommonlyCoach1.TabIndex = 8650;
            this.chkCommonlyCoach1.Text = "稳定情绪有利健康";
            // 
            // chkCommonlyCoach2
            // 
            this.chkCommonlyCoach2.AccessibleDescription = "一般指导>>根据自身情况适当煅炼";
            this.chkCommonlyCoach2.Location = new System.Drawing.Point(528, 16);
            this.chkCommonlyCoach2.Name = "chkCommonlyCoach2";
            this.chkCommonlyCoach2.Size = new System.Drawing.Size(240, 24);
            this.chkCommonlyCoach2.TabIndex = 8700;
            this.chkCommonlyCoach2.Text = "根据自身情况适当锻炼，增强体质";
            // 
            // chkCommonlyCoach3
            // 
            this.chkCommonlyCoach3.AccessibleDescription = "一般指导>>注意营养饮食";
            this.chkCommonlyCoach3.Location = new System.Drawing.Point(8, 40);
            this.chkCommonlyCoach3.Name = "chkCommonlyCoach3";
            this.chkCommonlyCoach3.Size = new System.Drawing.Size(216, 24);
            this.chkCommonlyCoach3.TabIndex = 8750;
            this.chkCommonlyCoach3.Text = "注重营养饮食，有利机体恢复";
            // 
            // chkCommonlyCoach4
            // 
            this.chkCommonlyCoach4.AccessibleDescription = "一般指导>>按医生预约时间复诊";
            this.chkCommonlyCoach4.Location = new System.Drawing.Point(296, 40);
            this.chkCommonlyCoach4.Name = "chkCommonlyCoach4";
            this.chkCommonlyCoach4.Size = new System.Drawing.Size(184, 24);
            this.chkCommonlyCoach4.TabIndex = 8800;
            this.chkCommonlyCoach4.Text = "按医生预约时间复诊";
            // 
            // chkCommonlyCoach5
            // 
            this.chkCommonlyCoach5.AccessibleDescription = "一般指导>>如有不适随时就诊";
            this.chkCommonlyCoach5.Location = new System.Drawing.Point(528, 40);
            this.chkCommonlyCoach5.Name = "chkCommonlyCoach5";
            this.chkCommonlyCoach5.Size = new System.Drawing.Size(184, 24);
            this.chkCommonlyCoach5.TabIndex = 8850;
            this.chkCommonlyCoach5.Text = "如有不适随时就诊";
            // 
            // chkCommonlyCoach6
            // 
            this.chkCommonlyCoach6.AccessibleDescription = "一般指导>>适当休息";
            this.chkCommonlyCoach6.Location = new System.Drawing.Point(8, 64);
            this.chkCommonlyCoach6.Name = "chkCommonlyCoach6";
            this.chkCommonlyCoach6.Size = new System.Drawing.Size(216, 24);
            this.chkCommonlyCoach6.TabIndex = 8900;
            this.chkCommonlyCoach6.Text = "适当休息，避免刺激性活动";
            // 
            // chkCommonlyCoach7
            // 
            this.chkCommonlyCoach7.AccessibleDescription = "一般指导>>按时服药";
            this.chkCommonlyCoach7.Location = new System.Drawing.Point(296, 64);
            this.chkCommonlyCoach7.Name = "chkCommonlyCoach7";
            this.chkCommonlyCoach7.Size = new System.Drawing.Size(216, 24);
            this.chkCommonlyCoach7.TabIndex = 8950;
            this.chkCommonlyCoach7.Text = "按时服药";
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.groupBox35);
            this.groupBox30.Controls.Add(this.groupBox34);
            this.groupBox30.Controls.Add(this.groupBox33);
            this.groupBox30.Controls.Add(this.groupBox32);
            this.groupBox30.Controls.Add(this.groupBox31);
            this.groupBox30.Location = new System.Drawing.Point(8, 92);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(800, 192);
            this.groupBox30.TabIndex = 1;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "出院病人护理评价";
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.m_txtNurseIssue);
            this.groupBox35.Controls.Add(this.chkNurseIssue0);
            this.groupBox35.Controls.Add(this.chkNurseIssue1);
            this.groupBox35.Location = new System.Drawing.Point(8, 136);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(776, 48);
            this.groupBox35.TabIndex = 4;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "现存或潜在的护理问题";
            // 
            // m_txtNurseIssue
            // 
            this.m_txtNurseIssue.AccessibleDescription = "现存或潜在的护理问题>>有";
            this.m_txtNurseIssue.BackColor = System.Drawing.Color.White;
            this.m_txtNurseIssue.Enabled = false;
            this.m_txtNurseIssue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNurseIssue.ForeColor = System.Drawing.Color.Black;
            this.m_txtNurseIssue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNurseIssue.Location = new System.Drawing.Point(120, 16);
            this.m_txtNurseIssue.m_BlnIgnoreUserInfo = false;
            this.m_txtNurseIssue.m_BlnPartControl = false;
            this.m_txtNurseIssue.m_BlnReadOnly = false;
            this.m_txtNurseIssue.m_BlnUnderLineDST = false;
            this.m_txtNurseIssue.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNurseIssue.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNurseIssue.m_IntCanModifyTime = 6;
            this.m_txtNurseIssue.m_IntPartControlLength = 0;
            this.m_txtNurseIssue.m_IntPartControlStartIndex = 0;
            this.m_txtNurseIssue.m_StrUserID = "";
            this.m_txtNurseIssue.m_StrUserName = "";
            this.m_txtNurseIssue.MaxLength = 8000;
            this.m_txtNurseIssue.Multiline = false;
            this.m_txtNurseIssue.Name = "m_txtNurseIssue";
            this.m_txtNurseIssue.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtNurseIssue.Size = new System.Drawing.Size(648, 23);
            this.m_txtNurseIssue.TabIndex = 8550;
            this.m_txtNurseIssue.Text = "";
            // 
            // chkNurseIssue0
            // 
            this.chkNurseIssue0.AccessibleDescription = "现存或潜在的护理问题>>无";
            this.chkNurseIssue0.Location = new System.Drawing.Point(8, 16);
            this.chkNurseIssue0.Name = "chkNurseIssue0";
            this.chkNurseIssue0.Size = new System.Drawing.Size(40, 24);
            this.chkNurseIssue0.TabIndex = 8450;
            this.chkNurseIssue0.Text = "无";
            this.chkNurseIssue0.CheckedChanged += new System.EventHandler(this.chkNurseIssue0_CheckedChanged);
            // 
            // chkNurseIssue1
            // 
            this.chkNurseIssue1.AccessibleDescription = "现存或潜在的护理问题>>有";
            this.chkNurseIssue1.Location = new System.Drawing.Point(68, 16);
            this.chkNurseIssue1.Name = "chkNurseIssue1";
            this.chkNurseIssue1.Size = new System.Drawing.Size(40, 24);
            this.chkNurseIssue1.TabIndex = 8500;
            this.chkNurseIssue1.Text = "有";
            this.chkNurseIssue1.CheckedChanged += new System.EventHandler(this.chkNurseIssue1_CheckedChanged);
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.m_txtNurseSyndrome);
            this.groupBox34.Controls.Add(this.chkNurseSyndrome0);
            this.groupBox34.Controls.Add(this.chkNurseSyndrome1);
            this.groupBox34.Location = new System.Drawing.Point(344, 80);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(440, 48);
            this.groupBox34.TabIndex = 3;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "护理并发症";
            // 
            // m_txtNurseSyndrome
            // 
            this.m_txtNurseSyndrome.AccessibleDescription = "护理并发症>>有";
            this.m_txtNurseSyndrome.BackColor = System.Drawing.Color.White;
            this.m_txtNurseSyndrome.Enabled = false;
            this.m_txtNurseSyndrome.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNurseSyndrome.ForeColor = System.Drawing.Color.Black;
            this.m_txtNurseSyndrome.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNurseSyndrome.Location = new System.Drawing.Point(88, 16);
            this.m_txtNurseSyndrome.m_BlnIgnoreUserInfo = false;
            this.m_txtNurseSyndrome.m_BlnPartControl = false;
            this.m_txtNurseSyndrome.m_BlnReadOnly = false;
            this.m_txtNurseSyndrome.m_BlnUnderLineDST = false;
            this.m_txtNurseSyndrome.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNurseSyndrome.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNurseSyndrome.m_IntCanModifyTime = 6;
            this.m_txtNurseSyndrome.m_IntPartControlLength = 0;
            this.m_txtNurseSyndrome.m_IntPartControlStartIndex = 0;
            this.m_txtNurseSyndrome.m_StrUserID = "";
            this.m_txtNurseSyndrome.m_StrUserName = "";
            this.m_txtNurseSyndrome.MaxLength = 8000;
            this.m_txtNurseSyndrome.Multiline = false;
            this.m_txtNurseSyndrome.Name = "m_txtNurseSyndrome";
            this.m_txtNurseSyndrome.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtNurseSyndrome.Size = new System.Drawing.Size(344, 23);
            this.m_txtNurseSyndrome.TabIndex = 8400;
            this.m_txtNurseSyndrome.Text = "";
            // 
            // chkNurseSyndrome0
            // 
            this.chkNurseSyndrome0.AccessibleDescription = "护理并发症>>无";
            this.chkNurseSyndrome0.Location = new System.Drawing.Point(8, 16);
            this.chkNurseSyndrome0.Name = "chkNurseSyndrome0";
            this.chkNurseSyndrome0.Size = new System.Drawing.Size(40, 24);
            this.chkNurseSyndrome0.TabIndex = 8300;
            this.chkNurseSyndrome0.Text = "无";
            this.chkNurseSyndrome0.CheckedChanged += new System.EventHandler(this.chkNurseSyndrome0_CheckedChanged);
            // 
            // chkNurseSyndrome1
            // 
            this.chkNurseSyndrome1.AccessibleDescription = "护理并发症>>有";
            this.chkNurseSyndrome1.Location = new System.Drawing.Point(48, 16);
            this.chkNurseSyndrome1.Name = "chkNurseSyndrome1";
            this.chkNurseSyndrome1.Size = new System.Drawing.Size(40, 24);
            this.chkNurseSyndrome1.TabIndex = 8350;
            this.chkNurseSyndrome1.Text = "有";
            this.chkNurseSyndrome1.CheckedChanged += new System.EventHandler(this.chkNurseSyndrome1_CheckedChanged);
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.chkOutHospitalMode0);
            this.groupBox33.Controls.Add(this.chkOutHospitalMode1);
            this.groupBox33.Controls.Add(this.chkOutHospitalMode2);
            this.groupBox33.Controls.Add(this.chkOutHospitalMode3);
            this.groupBox33.Controls.Add(this.chkOutHospitalMode4);
            this.groupBox33.Location = new System.Drawing.Point(8, 80);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(328, 48);
            this.groupBox33.TabIndex = 2;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "出院方式";
            // 
            // chkOutHospitalMode0
            // 
            this.chkOutHospitalMode0.AccessibleDescription = "出院方式>>步行";
            this.chkOutHospitalMode0.Location = new System.Drawing.Point(8, 16);
            this.chkOutHospitalMode0.Name = "chkOutHospitalMode0";
            this.chkOutHospitalMode0.Size = new System.Drawing.Size(56, 24);
            this.chkOutHospitalMode0.TabIndex = 8050;
            this.chkOutHospitalMode0.Text = "步行";
            // 
            // chkOutHospitalMode1
            // 
            this.chkOutHospitalMode1.AccessibleDescription = "出院方式>>轮椅";
            this.chkOutHospitalMode1.Location = new System.Drawing.Point(68, 16);
            this.chkOutHospitalMode1.Name = "chkOutHospitalMode1";
            this.chkOutHospitalMode1.Size = new System.Drawing.Size(56, 24);
            this.chkOutHospitalMode1.TabIndex = 8100;
            this.chkOutHospitalMode1.Text = "轮椅";
            // 
            // chkOutHospitalMode2
            // 
            this.chkOutHospitalMode2.AccessibleDescription = "出院方式>>平车";
            this.chkOutHospitalMode2.Location = new System.Drawing.Point(128, 16);
            this.chkOutHospitalMode2.Name = "chkOutHospitalMode2";
            this.chkOutHospitalMode2.Size = new System.Drawing.Size(56, 24);
            this.chkOutHospitalMode2.TabIndex = 8150;
            this.chkOutHospitalMode2.Text = "平车";
            // 
            // chkOutHospitalMode3
            // 
            this.chkOutHospitalMode3.AccessibleDescription = "出院方式>>抱婴儿";
            this.chkOutHospitalMode3.Location = new System.Drawing.Point(188, 16);
            this.chkOutHospitalMode3.Name = "chkOutHospitalMode3";
            this.chkOutHospitalMode3.Size = new System.Drawing.Size(72, 24);
            this.chkOutHospitalMode3.TabIndex = 8200;
            this.chkOutHospitalMode3.Text = "抱婴儿";
            // 
            // chkOutHospitalMode4
            // 
            this.chkOutHospitalMode4.AccessibleDescription = "出院方式>>拐杖";
            this.chkOutHospitalMode4.Location = new System.Drawing.Point(264, 16);
            this.chkOutHospitalMode4.Name = "chkOutHospitalMode4";
            this.chkOutHospitalMode4.Size = new System.Drawing.Size(56, 24);
            this.chkOutHospitalMode4.TabIndex = 8250;
            this.chkOutHospitalMode4.Text = "拐杖";
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.chkDieteticCircs0);
            this.groupBox32.Controls.Add(this.chkDieteticCircs1);
            this.groupBox32.Controls.Add(this.chkDieteticCircs2);
            this.groupBox32.Controls.Add(this.chkDieteticCircs3);
            this.groupBox32.Controls.Add(this.chkDieteticCircs4);
            this.groupBox32.Controls.Add(this.chkDieteticCircs5);
            this.groupBox32.Controls.Add(this.chkDieteticCircs6);
            this.groupBox32.Location = new System.Drawing.Point(264, 24);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(520, 48);
            this.groupBox32.TabIndex = 1;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "饮食状况";
            // 
            // chkDieteticCircs0
            // 
            this.chkDieteticCircs0.AccessibleDescription = "饮食状况>>普食";
            this.chkDieteticCircs0.Location = new System.Drawing.Point(8, 16);
            this.chkDieteticCircs0.Name = "chkDieteticCircs0";
            this.chkDieteticCircs0.Size = new System.Drawing.Size(56, 24);
            this.chkDieteticCircs0.TabIndex = 7700;
            this.chkDieteticCircs0.Text = "普食";
            // 
            // chkDieteticCircs1
            // 
            this.chkDieteticCircs1.AccessibleDescription = "饮食状况>>软食";
            this.chkDieteticCircs1.Location = new System.Drawing.Point(72, 16);
            this.chkDieteticCircs1.Name = "chkDieteticCircs1";
            this.chkDieteticCircs1.Size = new System.Drawing.Size(56, 24);
            this.chkDieteticCircs1.TabIndex = 7750;
            this.chkDieteticCircs1.Text = "软食";
            // 
            // chkDieteticCircs2
            // 
            this.chkDieteticCircs2.AccessibleDescription = "饮食状况>>治疗饮食";
            this.chkDieteticCircs2.Location = new System.Drawing.Point(136, 16);
            this.chkDieteticCircs2.Name = "chkDieteticCircs2";
            this.chkDieteticCircs2.Size = new System.Drawing.Size(88, 24);
            this.chkDieteticCircs2.TabIndex = 7800;
            this.chkDieteticCircs2.Text = "治疗饮食";
            // 
            // chkDieteticCircs3
            // 
            this.chkDieteticCircs3.AccessibleDescription = "饮食状况>>鼻管";
            this.chkDieteticCircs3.Location = new System.Drawing.Point(232, 16);
            this.chkDieteticCircs3.Name = "chkDieteticCircs3";
            this.chkDieteticCircs3.Size = new System.Drawing.Size(56, 24);
            this.chkDieteticCircs3.TabIndex = 7850;
            this.chkDieteticCircs3.Text = "鼻管";
            // 
            // chkDieteticCircs4
            // 
            this.chkDieteticCircs4.AccessibleDescription = "饮食状况>>少吃多餐";
            this.chkDieteticCircs4.Location = new System.Drawing.Point(296, 16);
            this.chkDieteticCircs4.Name = "chkDieteticCircs4";
            this.chkDieteticCircs4.Size = new System.Drawing.Size(88, 24);
            this.chkDieteticCircs4.TabIndex = 7900;
            this.chkDieteticCircs4.Text = "少吃多餐";
            // 
            // chkDieteticCircs5
            // 
            this.chkDieteticCircs5.AccessibleDescription = "饮食状况>>半流";
            this.chkDieteticCircs5.Location = new System.Drawing.Point(392, 16);
            this.chkDieteticCircs5.Name = "chkDieteticCircs5";
            this.chkDieteticCircs5.Size = new System.Drawing.Size(56, 24);
            this.chkDieteticCircs5.TabIndex = 7950;
            this.chkDieteticCircs5.Text = "半流";
            // 
            // chkDieteticCircs6
            // 
            this.chkDieteticCircs6.AccessibleDescription = "饮食状况>>全流";
            this.chkDieteticCircs6.Location = new System.Drawing.Point(456, 16);
            this.chkDieteticCircs6.Name = "chkDieteticCircs6";
            this.chkDieteticCircs6.Size = new System.Drawing.Size(56, 24);
            this.chkDieteticCircs6.TabIndex = 8000;
            this.chkDieteticCircs6.Text = "全流";
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.chkLiveAbility0);
            this.groupBox31.Controls.Add(this.chkLiveAbility1);
            this.groupBox31.Controls.Add(this.chkLiveAbility2);
            this.groupBox31.Location = new System.Drawing.Point(8, 24);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(248, 48);
            this.groupBox31.TabIndex = 0;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "生活能力";
            // 
            // chkLiveAbility0
            // 
            this.chkLiveAbility0.AccessibleDescription = "生活能力>>自理";
            this.chkLiveAbility0.Location = new System.Drawing.Point(8, 16);
            this.chkLiveAbility0.Name = "chkLiveAbility0";
            this.chkLiveAbility0.Size = new System.Drawing.Size(56, 24);
            this.chkLiveAbility0.TabIndex = 7550;
            this.chkLiveAbility0.Text = "自理";
            // 
            // chkLiveAbility1
            // 
            this.chkLiveAbility1.AccessibleDescription = "生活能力>>部分自理";
            this.chkLiveAbility1.Location = new System.Drawing.Point(64, 16);
            this.chkLiveAbility1.Name = "chkLiveAbility1";
            this.chkLiveAbility1.Size = new System.Drawing.Size(88, 24);
            this.chkLiveAbility1.TabIndex = 7600;
            this.chkLiveAbility1.Text = "部分自理";
            // 
            // chkLiveAbility2
            // 
            this.chkLiveAbility2.AccessibleDescription = "生活能力>>不能自理";
            this.chkLiveAbility2.Location = new System.Drawing.Point(152, 16);
            this.chkLiveAbility2.Name = "chkLiveAbility2";
            this.chkLiveAbility2.Size = new System.Drawing.Size(88, 24);
            this.chkLiveAbility2.TabIndex = 7650;
            this.chkLiveAbility2.Text = "不能自理";
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.m_txtOutHospitalDiagnose);
            this.groupBox27.Location = new System.Drawing.Point(8, 8);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(632, 80);
            this.groupBox27.TabIndex = 0;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "出院诊断";
            // 
            // m_txtOutHospitalDiagnose
            // 
            this.m_txtOutHospitalDiagnose.AccessibleDescription = "出院诊断";
            this.m_txtOutHospitalDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtOutHospitalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutHospitalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtOutHospitalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutHospitalDiagnose.Location = new System.Drawing.Point(8, 24);
            this.m_txtOutHospitalDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtOutHospitalDiagnose.m_BlnPartControl = false;
            this.m_txtOutHospitalDiagnose.m_BlnReadOnly = false;
            this.m_txtOutHospitalDiagnose.m_BlnUnderLineDST = false;
            this.m_txtOutHospitalDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutHospitalDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutHospitalDiagnose.m_IntCanModifyTime = 6;
            this.m_txtOutHospitalDiagnose.m_IntPartControlLength = 0;
            this.m_txtOutHospitalDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtOutHospitalDiagnose.m_StrUserID = "";
            this.m_txtOutHospitalDiagnose.m_StrUserName = "";
            this.m_txtOutHospitalDiagnose.MaxLength = 8000;
            this.m_txtOutHospitalDiagnose.Name = "m_txtOutHospitalDiagnose";
            this.m_txtOutHospitalDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOutHospitalDiagnose.Size = new System.Drawing.Size(616, 48);
            this.m_txtOutHospitalDiagnose.TabIndex = 7540;
            this.m_txtOutHospitalDiagnose.Text = "";
            // 
            // m_cmdNurseSign
            // 
            this.m_cmdNurseSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdNurseSign.DefaultScheme = true;
            this.m_cmdNurseSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNurseSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNurseSign.Hint = "";
            this.m_cmdNurseSign.Location = new System.Drawing.Point(336, 478);
            this.m_cmdNurseSign.Name = "m_cmdNurseSign";
            this.m_cmdNurseSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNurseSign.Size = new System.Drawing.Size(104, 28);
            this.m_cmdNurseSign.TabIndex = 5604;
            this.m_cmdNurseSign.Tag = "1";
            this.m_cmdNurseSign.Text = "责任护士签名:";
            // 
            // m_txtChargeNurse
            // 
            this.m_txtChargeNurse.AccessibleName = "NoDefault";
            this.m_txtChargeNurse.BackColor = System.Drawing.Color.White;
            this.m_txtChargeNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtChargeNurse.ForeColor = System.Drawing.Color.Black;
            this.m_txtChargeNurse.Location = new System.Drawing.Point(696, 482);
            this.m_txtChargeNurse.Name = "m_txtChargeNurse";
            this.m_txtChargeNurse.ReadOnly = true;
            this.m_txtChargeNurse.Size = new System.Drawing.Size(100, 23);
            this.m_txtChargeNurse.TabIndex = 9400;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(768, 40);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(21, 14);
            this.label50.TabIndex = 5607;
            this.label50.Text = "天";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 100;
            // 
            // lblAddress
            // 
            this.lblAddress.AccessibleDescription = "住址";
            this.lblAddress.Location = new System.Drawing.Point(95, 139);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(272, 43);
            this.lblAddress.TabIndex = 10000008;
            this.lblAddress.Visible = false;
            // 
            // m_cboEducation
            // 
            this.m_cboEducation.AccessibleDescription = "文化程度";
            this.m_cboEducation.AccessibleName = "NoDefault";
            this.m_cboEducation.BackColor = System.Drawing.Color.White;
            this.m_cboEducation.BorderColor = System.Drawing.Color.Black;
            this.m_cboEducation.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboEducation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboEducation.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboEducation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboEducation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEducation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEducation.ForeColor = System.Drawing.Color.Black;
            this.m_cboEducation.ListBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboEducation.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboEducation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboEducation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboEducation.Location = new System.Drawing.Point(416, 58);
            this.m_cboEducation.m_BlnEnableItemEventMenu = true;
            this.m_cboEducation.Name = "m_cboEducation";
            this.m_cboEducation.SelectedIndex = -1;
            this.m_cboEducation.SelectedItem = null;
            this.m_cboEducation.SelectionStart = 0;
            this.m_cboEducation.Size = new System.Drawing.Size(105, 23);
            this.m_cboEducation.TabIndex = 10000009;
            this.m_cboEducation.TabStop = false;
            this.m_cboEducation.TextBackColor = System.Drawing.Color.White;
            this.m_cboEducation.TextForeColor = System.Drawing.Color.Black;
            // 
            // frmEMR_InPatientEvaluate
            // 
            this.ClientSize = new System.Drawing.Size(848, 655);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.m_trvTime);
            this.Controls.Add(this.lblFolk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNativePlace);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEMR_InPatientEvaluate";
            this.Text = "病人入院评估表";
            this.Load += new System.EventHandler(this.frmEMR_InPatientEvaluate_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblNativePlace, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblJob, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblFolk, 0);
            this.Controls.SetChildIndex(this.m_trvTime, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.grpPip.ResumeLayout(false);
            this.groupBox28.ResumeLayout(false);
            this.groupBox29.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox39.ResumeLayout(false);
            this.groupBox38.ResumeLayout(false);
            this.groupBox37.ResumeLayout(false);
            this.groupBox30.ResumeLayout(false);
            this.groupBox35.ResumeLayout(false);
            this.groupBox34.ResumeLayout(false);
            this.groupBox33.ResumeLayout(false);
            this.groupBox32.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox27.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 获取界面数据
		private DateTime dtmOpenTime;
		private DateTime dtmModifyTime;
		private clsEMR_InPatientEvaluate objInPatientEvaluate(bool blnIsAddNew)
		{
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
			{				
				return null;
			}
			
			dtmOpenTime = DateTime.Now;
			dtmModifyTime = DateTime.Now;
			m_objIPE.m_strInPatientID=m_objCurrentPatient.m_StrEMRInPatientID;
            m_objIPE.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;		
			m_objIPE.m_dtmModifyDate=dtmModifyTime;
            m_objIPE.m_strModifyUserID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPNO_CHR;
            m_objIPE.m_strNurseID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPNO_CHR;
			
			clsEMR_InPatientEvaluate_All objclsInPatientEvaluate_AllOld;
			long lngSuccess=m_objDomain.m_lngGetLatestRecord_All(strInPatientID,strInPatientDate,out objclsInPatientEvaluate_AllOld);
				
			
			if(lngSuccess>0 && objclsInPatientEvaluate_AllOld !=null && objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate !=null 
				&& m_objCurrent_clsInPatientEvaluate_All !=null && m_objCurrent_clsInPatientEvaluate_All.m_objclsInPatientEvaluate !=null 
				&& DateTime.Parse(objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss")) != DateTime.Parse(m_objCurrent_clsInPatientEvaluate_All.m_objclsInPatientEvaluate.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss")))
			{//本判断根据最后修改时间的大小比较得到	,只可能大于（被修改）或等于（没修改），不可能小于（此时查询时为空记录）
				m_objCurrent_clsInPatientEvaluate_All=objclsInPatientEvaluate_AllOld;
				m_mthSetNewValue(m_objCurrent_clsInPatientEvaluate_All);//更新显示
//				return null;//若最新记录改变时的返回值
			}			
			else if(lngSuccess<=0)
			{
				return null;
			}

			if(m_dtpRecordTime.Enabled==false)
			{//修改记录：提取原来记录中的开放时间及创建者				
				if(objclsInPatientEvaluate_AllOld !=null && objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate!=null)
				{
					m_objIPE.m_dtmOpenDate=objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate.m_dtmOpenDate;
					m_objIPE.m_strCreateUserID=objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate.m_strCreateUserID;
					m_objIPE.m_dtmCreateDate=objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate.m_dtmCreateDate;
				}
				else 
				{
					return null;
				}
			}
			else
			{//添加记录：新时间及新创建者
				m_objIPE.m_strCreateUserID=MDIParent.strOperatorID;		
				m_objIPE.m_dtmOpenDate=dtmOpenTime;
				m_objIPE.m_dtmCreateDate=m_dtpRecordTime.Value;
			}	

			clsEmployee clsEm = new clsEmployee(MDIParent.strOperatorID);
			m_objIPE.m_strModifyUserName = clsEm.m_StrFirstName;
			#region
			m_objIPE.m_strPaymentMethod = (this.chkInsure.Checked == true ? "1":"0");
			m_objIPE.m_strPaymentMethod += (this.chkSelfPay.Checked == true ? "1":"0");

			m_objIPE.m_strEducationDegree = this.m_cboEducation.Text;
			m_objIPE.m_strInHospitalDiagnose = this.m_txtInPatientDiagnose.Text;
			m_objIPE.m_strCaseHistory = this.m_txtCaseHistory.Text;
			m_objIPE.m_strFamilyHistory = this.m_txtFamilyHistory.Text;
			m_objIPE.m_strChiefComplain = this.m_txtChiefComplain.Text;	
			m_objIPE.m_strInHospitalDiagnoseXML = this.m_txtInPatientDiagnose.m_strGetXmlText();
			m_objIPE.m_strCaseHistoryXML =	this.m_txtCaseHistory.m_strGetXmlText();
			m_objIPE.m_strFamilyHistoryXML = this.m_txtFamilyHistory.m_strGetXmlText();
			m_objIPE.m_strChiefComplainXML = this.m_txtChiefComplain.m_strGetXmlText();

			m_objIPE.m_strSensitiveHistory = (this.chkSensitive0.Checked == true ? "1":"0");
			m_objIPE.m_strSensitiveHistory += (this.chkSensitive1.Checked == true ? "1":"0");
			m_objIPE.m_strSensitiveHistory += (this.chkSensitive2.Checked == true ? "1":"0");
			m_objIPE.m_strSensitiveHistory += (this.chkSensitive3.Checked == true ? "1":"0");

			m_objIPE.m_strSensitiveHistory_Other = this.m_txtSensitiveOther.Text;
			m_objIPE.m_strSensitiveHistory_OtherXML =   this.m_txtSensitiveOther.m_strGetXmlText();

			m_objIPE.m_strInHospitalMethod = (this.rdbWalk.Checked == true ? "1":"0");
			m_objIPE.m_strInHospitalMethod += (this.rdbHand.Checked == true ? "1":"0");
			m_objIPE.m_strInHospitalMethod += (this.rdbWheel.Checked == true ? "1":"0");
			m_objIPE.m_strInHospitalMethod += (this.rdbFlat.Checked == true ? "1":"0");
			m_objIPE.m_strInHospitalMethod += (this.rdbBack.Checked == true ? "1":"0");
			m_objIPE.m_strInHospitalMethod += (this.rdbArm.Checked == true ? "1":"0");

			m_objIPE.m_strBodyTemperature = this.m_txtTemperature.Text;
			m_objIPE.m_strPulse = this.m_txtPulse.Text;
			m_objIPE.m_strHeartPhythm = this.m_txtRhythm.Text;
			m_objIPE.m_strBP_Shrink = this.m_txtBp_Shink.Text;
			m_objIPE.m_strBP_Extend = this.m_txtBp_Extend.Text;
			m_objIPE.m_strAvoirdupois = this.m_txtAvoirdupois.Text;
            m_objIPE.m_strShengao = this.m_txtshengao.Text;

			m_objIPE.m_strConsciousness = (this.chkConsciousness0.Checked == true ? "1":"0");
			m_objIPE.m_strConsciousness += (this.chkConsciousness1.Checked == true ? "1":"0");
			m_objIPE.m_strConsciousness += (this.chkConsciousness2.Checked == true ? "1":"0");
			m_objIPE.m_strConsciousness += (this.chkConsciousness3.Checked == true ? "1":"0");
			m_objIPE.m_strConsciousness += (this.chkConsciousness4.Checked == true ? "1":"0");

			m_objIPE.m_strComplexion = (this.chkComplexion0.Checked == true ? "1":"0");
			m_objIPE.m_strComplexion += (this.chkComplexion1.Checked == true ? "1":"0");
			m_objIPE.m_strComplexion += (this.chkComplexion2.Checked == true ? "1":"0");
			m_objIPE.m_strComplexion += (this.chkComplexion3.Checked == true ? "1":"0");

			m_objIPE.m_strPhysique = (this.chkPhysique0.Checked == true ? "1":"0");
			m_objIPE.m_strPhysique += (this.chkPhysique1.Checked == true ? "1":"0");
			m_objIPE.m_strPhysique += (this.chkPhysique2.Checked == true ? "1":"0");

			m_objIPE.m_strPhysique_Other = this.m_txtPhysiqueOther.Text;
			m_objIPE.m_strPhysique_OtherXML = this.m_txtPhysiqueOther.m_strGetXmlText();

			m_objIPE.m_strEmotion = (this.chkEmotion0.Checked == true ? "1":"0");
			m_objIPE.m_strEmotion += (this.chkEmotion1.Checked == true ? "1":"0");
			m_objIPE.m_strEmotion += (this.chkEmotion2.Checked == true ? "1":"0");

			m_objIPE.m_strSkin = (this.chkSkin0.Checked == true ? "1":"0");
			m_objIPE.m_strSkin += (this.chkSkin1.Checked == true ? "1":"0");
			m_objIPE.m_strSkin += (this.chkSkin2.Checked == true ? "1":"0");
			m_objIPE.m_strSkin += (this.chkSkin3.Checked == true ? "1":"0");
			m_objIPE.m_strSkin += (this.chkSkin4.Checked == true ? "1":"0");
			m_objIPE.m_strSkin += (this.chkSkin5.Checked == true ? "1":"0");
			m_objIPE.m_strSkin += (this.chkSkin6.Checked == true ? "1":"0");
			m_objIPE.m_strSkin += (this.chkSkin7.Checked == true ? "1":"0");
			m_objIPE.m_strSkin += (this.chkSkin8.Checked == true ? "1":"0");

			m_objIPE.m_strSkin_Other = this.m_txtSkinOther.Text;
			m_objIPE.m_strSkin_OtherXML = this.m_txtSkinOther.m_strGetXmlText();

			m_objIPE.m_strLimbsactivity = (this.chkLimbsactivity0.Checked == true ? "1":"0");
			m_objIPE.m_strLimbsactivity += (this.chkLimbsactivity1.Checked == true ? "1":"0");
			m_objIPE.m_strLimbsactivity += (this.chkLimbsactivity2.Checked == true ? "1":"0");
			m_objIPE.m_strLimbsactivity += (this.chkLimbsactivity3.Checked == true ? "1":"0");
			m_objIPE.m_strLimbsactivity += (this.chkLimbsactivity4.Checked == true ? "1":"0");
			m_objIPE.m_strLimbsactivity += (this.chkLimbsactivity5.Checked == true ? "1":"0");
			m_objIPE.m_strLimbsactivity += (this.chkLimbsactivity6.Checked == true ? "1":"0");

			m_objIPE.m_strLimbsactivity_Other = this.m_txtLimbsactivityOther.Text;
			m_objIPE.m_strLimbsactivity_OtherXML = this.m_txtLimbsactivityOther.m_strGetXmlText();

			m_objIPE.m_strBiteSup = (this.chkBiteSup0.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup1.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup2.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup3.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup4.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup6.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup7.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup8.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup9.Checked == true ? "1":"0");
			m_objIPE.m_strBiteSup += (this.chkBiteSup10.Checked == true ? "1":"0");

			m_objIPE.m_strAppetite = (this.chkAppetite0.Checked == true ? "1":"0");
			m_objIPE.m_strAppetite += (this.chkAppetite1.Checked == true ? "1":"0");
			m_objIPE.m_strAppetite += (this.chkAppetite2.Checked == true ? "1":"0");
			m_objIPE.m_strAppetite += (this.chkAppetite3.Checked == true ? "1":"0");
			m_objIPE.m_strAppetite += (this.chkAppetite4.Checked == true ? "1":"0");
			m_objIPE.m_strAppetite += (this.chkAppetite5.Checked == true ? "1":"0");

			m_objIPE.m_strSleep = (this.chkSleep0.Checked == true ? "1":"0");
			m_objIPE.m_strSleep += (this.chkSleep1.Checked == true ? "1":"0");
			m_objIPE.m_strSleep += (this.chkSleep2.Checked == true ? "1":"0");
			m_objIPE.m_strSleep += (this.chkSleep3.Checked == true ? "1":"0");
			m_objIPE.m_strSleep += (this.chkSleep4.Checked == true ? "1":"0");

			m_objIPE.m_strStool = (this.chkStool.Checked == true ? "1":"0");
			m_objIPE.m_strAstriction = this.m_txtAstrictionTimes.Text + "次" + this.m_txtAstrictionDays.Text;
			m_objIPE.m_strDiarrhea = this.m_txtDiarrheaTimes.Text + "次" + this.m_txtDiarrheaDays.Text;
			m_objIPE.m_strStool_Other = this.m_txtStoolOther.Text;
			m_objIPE.m_strStool_OtherXML = this.m_txtStoolOther.m_strGetXmlText();

			m_objIPE.m_strPee = (this.chkPee0.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee1.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee2.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee3.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee4.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee5.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee6.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee7.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee8.Checked == true ? "1":"0");
			m_objIPE.m_strPee += (this.chkPee9.Checked == true ? "1":"0");

			m_objIPE.m_strHobby = (this.chkHobby0.Checked == true ? "1":"0");
			m_objIPE.m_strHobby += (this.chkHobby1.Checked == true ? "1":"0");
			m_objIPE.m_strHobby += (this.chkHobby2.Checked == true ? "1":"0");
			m_objIPE.m_strHobby += (this.chkHobby3.Checked == true ? "1":"0");
			m_objIPE.m_strHobby += (this.chkHobby4.Checked == true ? "1":"0");
			m_objIPE.m_strHobby_Other = this.m_txtHobbyOther.Text;
			m_objIPE.m_strHobby_OtherXML =	this.m_txtHobbyOther.m_strGetXmlText();

			m_objIPE.m_strSelfSolve = (this.chkSelfSolve0.Checked == true ? "1":"0");
			m_objIPE.m_strSelfSolve += (this.chkSelfSolve1.Checked == true ? "1":"0");
			m_objIPE.m_strSelfSolve += (this.chkSelfSolve2.Checked == true ? "1":"0");

			m_objIPE.m_strFeeling = (this.chkFeeling0.Checked == true ? "1":"0");
			m_objIPE.m_strFeeling += (this.chkFeeling1.Checked == true ? "1":"0");
			m_objIPE.m_strFeeling += (this.chkFeeling2.Checked == true ? "1":"0");
			m_objIPE.m_strFeeling += (this.chkFeeling3.Checked == true ? "1":"0");
			m_objIPE.m_strFeeling += (this.chkFeeling4.Checked == true ? "1":"0");
			m_objIPE.m_strFeeling += (this.chkFeeling5.Checked == true ? "1":"0");
			m_objIPE.m_strFeeling += (this.chkFeeling6.Checked == true ? "1":"0");
			m_objIPE.m_strFeeling += (this.chkFeeling7.Checked == true ? "1":"0");
			m_objIPE.m_strFeeling += (this.chkFeeling8.Checked == true ? "1":"0");

			m_objIPE.m_strJob = (this.chkJob0.Checked == true ? "1":"0");
			m_objIPE.m_strJob += (this.chkJob1.Checked == true ? "1":"0");
			m_objIPE.m_strJob += (this.chkJob2.Checked == true ? "1":"0");
			m_objIPE.m_strJob += (this.chkJob3.Checked == true ? "1":"0");
			m_objIPE.m_strJob += (this.chkJob4.Checked == true ? "1":"0");
			m_objIPE.m_strJob += (this.chkJob5.Checked == true ? "1":"0");
			m_objIPE.m_strJob += (this.chkJob6.Checked == true ? "1":"0");

			m_objIPE.m_strInHospitalWorry = (this.chkInHospitalWorry0.Checked == true ? "1":"0");
			m_objIPE.m_strInHospitalWorry += (this.chkInHospitalWorry1.Checked == true ? "1":"0");
			m_objIPE.m_strInHospitalWorry += (this.chkInHospitalWorry2.Checked == true ? "1":"0");
			m_objIPE.m_strInHospitalWorry_Other = this.m_txtInHospitalWorryOther.Text;
			m_objIPE.m_strInHospitalWorryXML =	this.m_txtInHospitalWorryOther.m_strGetXmlText();

			m_objIPE.m_strFamilyForm = (this.chkFamilyForm0.Checked == true ? "1":"0");
			m_objIPE.m_strFamilyForm += (this.chkFamilyForm1.Checked == true ? "1":"0");
			m_objIPE.m_strFamilyForm += (this.chkFamilyForm2.Checked == true ? "1":"0");
			m_objIPE.m_strFamilyForm += (this.chkFamilyForm3.Checked == true ? "1":"0");
			m_objIPE.m_strFamilyForm_Other = this.m_txtFamilyFormOther.Text;
			m_objIPE.m_strFamilyForm_OtherXML = this.m_txtFamilyFormOther.m_strGetXmlText();

			m_objIPE.m_strHealthNeed = (this.chkHealthNeed0.Checked == true ? "1":"0");
			m_objIPE.m_strHealthNeed += (this.chkHealthNeed1.Checked == true ? "1":"0");
			m_objIPE.m_strHealthNeed += (this.chkHealthNeed2.Checked == true ? "1":"0");
			m_objIPE.m_strHealthNeed += (this.chkHealthNeed3.Checked == true ? "1":"0");
			m_objIPE.m_strHealthNeed += (this.chkHealthNeed4.Checked == true ? "1":"0");

			m_objIPE.m_strKnowDisease = (this.chkKnowDisease0.Checked == true ? "1":"0");
			m_objIPE.m_strKnowDisease += (this.chkKnowDisease1.Checked == true ? "1":"0");
			m_objIPE.m_strKnowDisease += (this.chkKnowDisease2.Checked == true ? "1":"0");
			m_objIPE.m_strKnowDisease += (this.chkKnowDisease3.Checked == true ? "1":"0");

			m_objIPE.m_strSpecializedCheck = this.m_txtSpecilizedCheck.Text.Replace("?","&*");//replace为“&*”是为了避免将？替换成：1
            m_objIPE.m_strPipInstance = this.m_txtPipInstance.Text.Replace("?", "&*");
            m_objIPE.m_strWoodInstance = this.m_txtWoodInstance.Text.Replace("?", "&*");
            m_objIPE.m_strTendPlan = this.m_txtTendPlan.Text.Replace("?", "&*");
			m_objIPE.m_strSpecializedCheckXML = this.m_txtSpecilizedCheck.m_strGetXmlText();
			m_objIPE.m_strPipInstanceXML = this.m_txtPipInstance.m_strGetXmlText();
			m_objIPE.m_strWoodInstanceXML =	 this.m_txtWoodInstance.m_strGetXmlText();
			m_objIPE.m_strTendPlanXML =	 this.m_txtTendPlan.m_strGetXmlText();
			#endregion

			m_objIPE.m_bytStatus = 0;

			return m_objIPE;
		}

		private clsEMR_InPatientHealth_VO objInPatientHealth(bool blnIsAddNew)
		{
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
			{				
				return null;
			}

            m_objIPH.m_strInPatientID = m_objCurrentPatient.m_StrEMRInPatientID;
            m_objIPH.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;		
			m_objIPH.m_dtmModifyDate=dtmModifyTime;
            m_objIPH.m_strModifyUserID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPNO_CHR;
			
			clsEMR_InPatientEvaluate_All objclsInPatientEvaluate_AllOld;
			long lngSuccess=m_objDomain.m_lngGetLatestRecord_All(strInPatientID,strInPatientDate,out objclsInPatientEvaluate_AllOld);
				
			
			if(lngSuccess>0 && objclsInPatientEvaluate_AllOld !=null && objclsInPatientEvaluate_AllOld.m_objclsInPatientHealth_VO !=null 
				&& m_objCurrent_clsInPatientEvaluate_All !=null && m_objCurrent_clsInPatientEvaluate_All.m_objclsInPatientHealth_VO !=null 
				&& DateTime.Parse(objclsInPatientEvaluate_AllOld.m_objclsInPatientHealth_VO.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss")) != DateTime.Parse(m_objCurrent_clsInPatientEvaluate_All.m_objclsInPatientHealth_VO.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss")))
			{//本判断根据最后修改时间的大小比较得到	,只可能大于（被修改）或等于（没修改），不可能小于（此时查询时为空记录）
				m_objCurrent_clsInPatientEvaluate_All=objclsInPatientEvaluate_AllOld;
				m_mthSetNewValue(m_objCurrent_clsInPatientEvaluate_All);//更新显示
//				return null;//若最新记录改变时的返回值
			}			
			else if(lngSuccess<=0)
			{
				return null;
			}

            //if(dtpEduTime.Enabled==false)
            //{//修改记录：提取原来记录中的开放时间及创建者				
				if(objclsInPatientEvaluate_AllOld !=null && objclsInPatientEvaluate_AllOld.m_objclsInPatientHealth_VO!=null)
				{
					m_objIPH.m_dtmOpenDate=objclsInPatientEvaluate_AllOld.m_objclsInPatientHealth_VO.m_dtmOpenDate;
					m_objIPH.m_strCreateUserID=objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate.m_strCreateUserID;
					m_objIPH.m_dtmCreateDate=objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate.m_dtmCreateDate;
				}
				else 
				{
                    m_objIPH.m_strCreateUserID = MDIParent.strOperatorID;
                    m_objIPH.m_dtmOpenDate = dtmOpenTime;
                    m_objIPH.m_dtmCreateDate = dtpEduTime.Value;
                }
            //}
            //else
            //{//添加记录：新时间及新创建者
            //    m_objIPH.m_strCreateUserID=MDIParent.strOperatorID;		
            //    m_objIPH.m_dtmOpenDate=dtmOpenTime;
            //    m_objIPH.m_dtmCreateDate=dtpEduTime.Value;
            //}
			
			#region 获取数据

			#region 第一次完成
			ArrayList arrFormData =new ArrayList();
			arrFormData.Add(m_txtReadOutEdu1.Text);
			arrFormData.Add(m_txtReadOutNurse1.Text);
			arrFormData.Add(m_txtReadOutDate1.Text);
			arrFormData.Add(m_txtExplanEdu1.Text);
			arrFormData.Add(m_txtExplanNurse1.Text);
			arrFormData.Add(m_txtExplanDate1.Text);
			arrFormData.Add(m_txtMedicineEdu1.Text);
			arrFormData.Add(m_txtMedicineNurse1.Text);
			arrFormData.Add(m_txtMedicineDate1.Text);
			arrFormData.Add(m_txtNoticeEdu1.Text);
			arrFormData.Add(m_txtNoticeNurse1.Text);
			arrFormData.Add(m_txtNoticeDate1.Text);
			arrFormData.Add(m_txtKnowledgeEdu1.Text);
			arrFormData.Add(m_txtKnowledgeNurse1.Text);
			arrFormData.Add(m_txtKnowledgeDate1.Text);
			arrFormData.Add(m_txtGuidanceEdu1.Text);
			arrFormData.Add(m_txtGuidanceNurse1.Text);
			arrFormData.Add(m_txtGuidanceDate1.Text);
			arrFormData.Add(m_txtOtherEdu1.Text);
			arrFormData.Add(m_txtOtherNurse1.Text);
			arrFormData.Add(m_txtOtherDate1.Text);
			m_objIPH.m_strHEDU_First=m_StrFormToXML(arrFormData,"First");
			#endregion

			#region 第二次完成
			ArrayList arrFormData2 =new ArrayList();
			arrFormData2.Add(m_txtReadOutEdu2.Text);
			arrFormData2.Add(m_txtReadOutNurse2.Text);
			arrFormData2.Add(m_txtReadOutDate2.Text);
			arrFormData2.Add(m_txtExplanEdu2.Text);
			arrFormData2.Add(m_txtExplanNurse2.Text);
			arrFormData2.Add(m_txtExplanDate2.Text);
			arrFormData2.Add(m_txtMedicineEdu2.Text);
			arrFormData2.Add(m_txtMedicineNurse2.Text);
			arrFormData2.Add(m_txtMedicineDate2.Text);
			arrFormData2.Add(m_txtNoticeEdu2.Text);
			arrFormData2.Add(m_txtNoticeNurse2.Text);
			arrFormData2.Add(m_txtNoticeDate2.Text);
			arrFormData2.Add(m_txtKnowledgeEdu2.Text);
			arrFormData2.Add(m_txtKnowledgeNurse2.Text);
			arrFormData2.Add(m_txtKnowledgeDate2.Text);
			arrFormData2.Add(m_txtGuidanceEdu2.Text);
			arrFormData2.Add(m_txtGuidanceNurse2.Text);
			arrFormData2.Add(m_txtGuidanceDate2.Text);
			arrFormData2.Add(m_txtOtherEdu2.Text);
			arrFormData2.Add(m_txtOtherNurse2.Text);
			arrFormData2.Add(m_txtOtherDate2.Text);
			m_objIPH.m_strHEDU_Second=m_StrFormToXML(arrFormData2,"Second");
			#endregion

			#region 第三次完成
			ArrayList arrFormData3 =new ArrayList();
			arrFormData3.Add(m_txtReadOutEdu3.Text);
			arrFormData3.Add(m_txtReadOutNurse3.Text);
			arrFormData3.Add(m_txtReadOutDate3.Text);
			arrFormData3.Add(m_txtExplanEdu3.Text);
			arrFormData3.Add(m_txtExplanNurse3.Text);
			arrFormData3.Add(m_txtExplanDate3.Text);
			arrFormData3.Add(m_txtMedicineEdu3.Text);
			arrFormData3.Add(m_txtMedicineNurse3.Text);
			arrFormData3.Add(m_txtMedicineDate3.Text);
			arrFormData3.Add(m_txtNoticeEdu3.Text);
			arrFormData3.Add(m_txtNoticeNurse3.Text);
			arrFormData3.Add(m_txtNoticeDate3.Text);
			arrFormData3.Add(m_txtKnowledgeEdu3.Text);
			arrFormData3.Add(m_txtKnowledgeNurse3.Text);
			arrFormData3.Add(m_txtKnowledgeDate3.Text);
			arrFormData3.Add(m_txtGuidanceEdu3.Text);
			arrFormData3.Add(m_txtGuidanceNurse3.Text);
			arrFormData3.Add(m_txtGuidanceDate3.Text);
			arrFormData3.Add(m_txtOtherEdu3.Text);
			arrFormData3.Add(m_txtOtherNurse3.Text);
			arrFormData3.Add(m_txtOtherDate3.Text);
			m_objIPH.m_strHEDU_Three=m_StrFormToXML(arrFormData3,"Third");
			#endregion
			
			m_objIPH.m_dtmWriteFormDate = dtpEduTime.Value;

			m_objIPH.m_bytStatus = 0;
			#endregion

			return m_objIPH;
		}

		private clsEMR_InPatientOutEvaluate_VO objInPatientOutEvaluate(bool blnIsAddNew)
		{
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
			{				
				return null;
			}

            m_objIPO.m_strInPatientID = m_objCurrentPatient.m_StrEMRInPatientID;
            m_objIPO.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;	
			m_objIPO.m_dtmModifyDate=dtmModifyTime;
			m_objIPO.m_strModifyUserID=MDIParent.OperatorID;
			
			clsEMR_InPatientEvaluate_All objclsInPatientEvaluate_AllOld;
			long lngSuccess=m_objDomain.m_lngGetLatestRecord_All(strInPatientID,strInPatientDate,out objclsInPatientEvaluate_AllOld);
				
			
			if(lngSuccess>0 && objclsInPatientEvaluate_AllOld !=null && objclsInPatientEvaluate_AllOld.m_objInPatientOutEvaluate_VO !=null 
				&& m_objCurrent_clsInPatientEvaluate_All !=null && m_objCurrent_clsInPatientEvaluate_All.m_objInPatientOutEvaluate_VO !=null 
				&& DateTime.Parse(objclsInPatientEvaluate_AllOld.m_objInPatientOutEvaluate_VO.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss")) != DateTime.Parse(m_objCurrent_clsInPatientEvaluate_All.m_objInPatientOutEvaluate_VO.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss")))
			{//本判断根据最后修改时间的大小比较得到	,只可能大于（被修改）或等于（没修改），不可能小于（此时查询时为空记录）
				m_objCurrent_clsInPatientEvaluate_All=objclsInPatientEvaluate_AllOld;
				m_mthSetNewValue(m_objCurrent_clsInPatientEvaluate_All);//更新显示
//				return null;//若最新记录改变时的返回值
			}			
			else if(lngSuccess<=0)
			{
				return null;
			}

			if(m_dtpRecordTime.Enabled==false)
			{//修改记录：提取原来记录中的开放时间及创建者				
                if (objclsInPatientEvaluate_AllOld != null && objclsInPatientEvaluate_AllOld.m_objInPatientOutEvaluate_VO != null)
				{
					m_objIPO.m_dtmOpenDate=objclsInPatientEvaluate_AllOld.m_objInPatientOutEvaluate_VO.m_dtmOpenDate;
                    m_objIPO.m_strCreateUserID = objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate.m_strCreateUserID;
                    m_objIPO.m_dtmCreateDate = objclsInPatientEvaluate_AllOld.m_objclsInPatientEvaluate.m_dtmCreateDate;
				}
				else 
				{
					return null;
				}
			}
			else
			{//添加记录：新时间及新创建者
				m_objIPO.m_strCreateUserID=MDIParent.strOperatorID;		
				m_objIPO.m_dtmOpenDate=dtmOpenTime;
				m_objIPO.m_dtmCreateDate=m_dtpRecordTime.Value;
            }

           
            m_objIPO.m_strInHospitalDays = ((m_objIPO.m_dtmOpenDate - m_objIPO.m_dtmInPatientDate).Days + 1).ToString();
            //m_objIPO.m_strInHospitalDays = m_objIPO.m_strInHospitalDays.ToString();
            aaa = m_objIPO.m_strInHospitalDays;

            #region 获取数据
            m_objIPO.m_strOutHospitalDiagnose = m_txtOutHospitalDiagnose.Text.Replace("?","&*");
			m_objIPO.m_strOutHospitalDiagnoseXML = m_txtOutHospitalDiagnose.m_strGetXmlText();
			m_objIPO.m_strLiveAbility = (this.chkLiveAbility0.Checked == true ? "1":"0");
			m_objIPO.m_strLiveAbility += (this.chkLiveAbility1.Checked == true ? "1":"0");
			m_objIPO.m_strLiveAbility += (this.chkLiveAbility2.Checked == true ? "1":"0");

			m_objIPO.m_strDieteticCircs = (this.chkDieteticCircs0.Checked == true ? "1":"0");
			m_objIPO.m_strDieteticCircs += (this.chkDieteticCircs1.Checked == true ? "1":"0");
			m_objIPO.m_strDieteticCircs += (this.chkDieteticCircs2.Checked == true ? "1":"0");
			m_objIPO.m_strDieteticCircs += (this.chkDieteticCircs3.Checked == true ? "1":"0");
			m_objIPO.m_strDieteticCircs += (this.chkDieteticCircs4.Checked == true ? "1":"0");
			m_objIPO.m_strDieteticCircs += (this.chkDieteticCircs5.Checked == true ? "1":"0");
			m_objIPO.m_strDieteticCircs += (this.chkDieteticCircs6.Checked == true ? "1":"0");

			m_objIPO.m_strOutHospitalMode = (this.chkOutHospitalMode0.Checked == true ? "1":"0");
			m_objIPO.m_strOutHospitalMode += (this.chkOutHospitalMode1.Checked == true ? "1":"0");
			m_objIPO.m_strOutHospitalMode += (this.chkOutHospitalMode2.Checked == true ? "1":"0");
			m_objIPO.m_strOutHospitalMode += (this.chkOutHospitalMode3.Checked == true ? "1":"0");
			m_objIPO.m_strOutHospitalMode += (this.chkOutHospitalMode4.Checked == true ? "1":"0");

			m_objIPO.m_strIsNurseSyndrome = (this.chkNurseSyndrome0.Checked == true ? "1":"0");
			m_objIPO.m_strIsNurseSyndrome += (this.chkNurseSyndrome1.Checked == true ? "1":"0");
			m_objIPO.m_strNurseSyndrome = m_txtNurseSyndrome.Text;
			m_objIPO.m_strNurseSyndromeXML =  m_txtNurseSyndrome.m_strGetXmlText();

			m_objIPO.m_strIsNurseIssue = (this.chkNurseIssue0.Checked == true ? "1":"0");
			m_objIPO.m_strIsNurseIssue += (this.chkNurseIssue1.Checked == true ? "1":"0");
			m_objIPO.m_strNurseIssue = m_txtNurseIssue.Text;
			m_objIPO.m_strNurseIssueXML = m_txtNurseIssue.m_strGetXmlText();

			m_objIPO.m_strCommonlyCoach = (this.chkCommonlyCoach0.Checked == true ? "1":"0");
			m_objIPO.m_strCommonlyCoach += (this.chkCommonlyCoach1.Checked == true ? "1":"0");
			m_objIPO.m_strCommonlyCoach += (this.chkCommonlyCoach2.Checked == true ? "1":"0");
			m_objIPO.m_strCommonlyCoach += (this.chkCommonlyCoach3.Checked == true ? "1":"0");
			m_objIPO.m_strCommonlyCoach += (this.chkCommonlyCoach4.Checked == true ? "1":"0");
			m_objIPO.m_strCommonlyCoach += (this.chkCommonlyCoach5.Checked == true ? "1":"0");
			m_objIPO.m_strCommonlyCoach += (this.chkCommonlyCoach6.Checked == true ? "1":"0");
			m_objIPO.m_strCommonlyCoach += (this.chkCommonlyCoach7.Checked == true ? "1":"0");

			m_objIPO.m_strAdviceDrug = (this.chkAdviceDrug0.Checked == true ? "1":"0");
			m_objIPO.m_strAdviceDrug += (this.chkAdviceDrug1.Checked == true ? "1":"0");
			m_objIPO.m_strAdviceDrug += (this.chkAdviceDrug2.Checked == true ? "1":"0");
			m_objIPO.m_strAdviceDrug += (this.chkAdviceDrug3.Checked == true ? "1":"0");

			m_objIPO.m_strIsSpecialtiesCoach = (this.chkSpecialtiesCoach0.Checked == true ? "1":"0");
			m_objIPO.m_strIsSpecialtiesCoach += (this.chkSpecialtiesCoach1.Checked == true ? "1":"0");
			m_objIPO.m_strSpecialtiesCoach = m_txtSpecialtiesCoach.Text;
			m_objIPO.m_strSpecialtiesCoachXML = m_txtSpecialtiesCoach.m_strGetXmlText();

            //if (m_txtNurseSign.Tag != null && m_txtChargeNurse.Tag != null)
            //{
                m_objIPO.m_strNurseSign_ID = m_txtNurseSign.Tag != null ? ((clsEmrEmployeeBase_VO)m_txtNurseSign.Tag).m_strEMPNO_CHR : "";
                m_objIPO.m_strChargeNurse_ID = m_txtChargeNurse.Tag != null ? ((clsEmrEmployeeBase_VO)m_txtChargeNurse.Tag).m_strEMPNO_CHR : "";
            //}
			m_objIPO.m_strNurseSign_Name = m_txtNurseSign.Text;
			m_objIPO.m_strChargeNurse_Name = m_txtChargeNurse.Text;

			m_objIPO.m_bytStatus = 0;
			#endregion

			return m_objIPO;
		}

		#endregion


        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            clsPeopleInfo objPeopleInfo = p_objSelectedPatient.m_ObjPeopleInfo;
            //lblSex.Text = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvTime.Nodes[0].Nodes.Count - m_trvTime.SelectedNode.Index - 1).m_ObjPeopleInfo.m_StrSex.Trim();
            //lblAge.Text = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvTime.Nodes[0].Nodes.Count - m_trvTime.SelectedNode.Index - 1).m_ObjPeopleInfo.m_StrAge.Trim();

            lblNativePlace.Text = objPeopleInfo.m_StrHomeplace;
            lblJob.Text = objPeopleInfo.m_StrOccupation;
            lblFolk.Text = objPeopleInfo.m_StrNation;
            lblAddress.Text = objPeopleInfo.m_StrHomeAddress;

            if (objPeopleInfo.m_StrPayTypeName == "自费")
            {
                this.chkSelfPay.Checked = true;
                this.chkInsure.Checked = false; 
            }
        }
        // 设置

		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient == null)
				return;
			
			if(m_trvTime.Nodes[0].Nodes.Count >0)
				this.m_trvTime.Nodes[0].Nodes.Clear ();

			m_mthClearUpSheet();
			m_mthReadOnly(false);
//			m_objIPE=null;	
		
            //lblNativePlace.Text  = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeplace;
            //lblJob.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;
            //lblFolk.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrNation;
            //lblAddress.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress;

            strInPatientID = p_objSelectedPatient.m_StrInPatientID;
			m_objCurrentPatient=p_objSelectedPatient ;
            //m_mthDisplayDates(p_objSelectedPatient);

            //m_mthSetPatientBaseInfo(p_objSelectedPatient);
			objInPatientEvaluate(false);
			objInPatientHealth(false);
			objInPatientOutEvaluate(false);
		}	
	
		private void m_mthDisplayDates(clsPatient p_objSelectedPatient)
		{			
			if(m_trvTime.Nodes.Count==0)
				m_trvTime.Nodes.Add("入院时间");

			string[] strDateArr ;
			long lngRes=m_objDomain.m_lngGetAllRecordDateArr(p_objSelectedPatient.m_StrInPatientID,out strDateArr);		
			
			/*if(strDateArr==null) 
			{
				m_mthSetDefaultValue(m_objCurrentPatient);
				return ;
			}
			this.m_trvTime.Nodes[0].Nodes .Clear();
			for(int i=strDateArr.Length-1;i>=0 ;i--)
			{
		
				string strDate = DateTime.Parse(strDateArr[i]).ToString("yyyy年MM月dd日 HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =strDateArr[i];
				this.m_trvTime.Nodes[0].Nodes.Add(trnDate );
				
			}*/
			for(int i=p_objSelectedPatient.m_ObjInBedInfo.m_intGetSessionCount()-1;i>=0;i--)
			{			
				TreeNode trnRecordDate = new TreeNode(p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i).m_DtmHISInDate.ToString("yyyy-MM-dd HH:mm:ss"));
                trnRecordDate.Tag = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i).m_DtmEMRInDate;
				m_trvTime.Nodes[0].Nodes.Add(trnRecordDate);	
				m_trvTime.ExpandAll();					
			}	
			m_trvTime.SelectedNode= m_trvTime.Nodes[0].FirstNode;//选中最新的入院时间
		}

		/// <summary>
		/// 清空除了基本资料和"树"外的全部界面内容
		/// </summary>
		private void m_mthClearUpSheet()
		{

			foreach(Control ctlRichText in this.Controls )
			{
				m_mthClearAll(ctlRichText);
			}
            string aaa = m_objIPO.m_strInHospitalDays;
			lblInHospitalDays.Text = "";
            m_cboEducation.Text = "";
            MDIParent.m_mthSetDefaulEmployee(m_txtSign);
            #region  屏蔽：健康教育评估表签名不需要默认值
            /*
            //1
            MDIParent.m_mthSetDefaulEmployee(m_txtReadOutNurse1);
            MDIParent.m_mthSetDefaulEmployee(m_txtReadOutNurse2);
            MDIParent.m_mthSetDefaulEmployee(m_txtReadOutNurse3);
            //2
            MDIParent.m_mthSetDefaulEmployee(m_txtExplanNurse1);
            MDIParent.m_mthSetDefaulEmployee(m_txtExplanNurse2);
            MDIParent.m_mthSetDefaulEmployee(m_txtExplanNurse3);
            //3
            MDIParent.m_mthSetDefaulEmployee(m_txtMedicineNurse1);
            MDIParent.m_mthSetDefaulEmployee(m_txtMedicineNurse2);
            MDIParent.m_mthSetDefaulEmployee(m_txtMedicineNurse3);
            //4
            MDIParent.m_mthSetDefaulEmployee(m_txtNoticeNurse1);
            MDIParent.m_mthSetDefaulEmployee(m_txtNoticeNurse2);
            MDIParent.m_mthSetDefaulEmployee(m_txtNoticeNurse3);
            //5
            MDIParent.m_mthSetDefaulEmployee(m_txtKnowledgeNurse1);
            MDIParent.m_mthSetDefaulEmployee(m_txtKnowledgeNurse2);
            MDIParent.m_mthSetDefaulEmployee(m_txtKnowledgeNurse3);
            //6
            MDIParent.m_mthSetDefaulEmployee(m_txtGuidanceNurse1);
            MDIParent.m_mthSetDefaulEmployee(m_txtGuidanceNurse2);
            MDIParent.m_mthSetDefaulEmployee(m_txtGuidanceNurse3);
            //7
            MDIParent.m_mthSetDefaulEmployee(m_txtOtherNurse1);
            MDIParent.m_mthSetDefaulEmployee(m_txtOtherNurse2);
            MDIParent.m_mthSetDefaulEmployee(m_txtOtherNurse3);
             */
            #endregion
            chkModifyWithoutMatk.Checked = true;
		}
		private void m_mthClearAll(Control p_ctlControl)
		{
			string typeName = p_ctlControl.GetType().Name;
            switch (typeName)
            {
                case "CheckBox":
                    ((CheckBox)p_ctlControl).Checked = false;                  
                    break; 
                case "RadioButton":
                    ((RadioButton)p_ctlControl).Checked = false;
                    break;
                case "ctlBorderTextBox":
                    if (p_ctlControl.Name != "txtInPatientID" && p_ctlControl.Name != "m_txtPatientName" && p_ctlControl.Name != "m_txtBedNO")
                    {
                        p_ctlControl.Text = "";
                    }
                    break;
                case "ctlRichTextBox":
                    ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();
                    break;
                case "m_cboArea":
                    typeName = p_ctlControl.Name;
                    break;
                case "TextBox":
                    if (p_ctlControl.Name != "m_txtContent")//病区过滤控件中显示病人姓名
                    {
                        ((TextBox)p_ctlControl).Clear();
                        ((TextBox)p_ctlControl).Tag = null;
                    }
                    break;
                default:
                    break;
            }
			foreach(Control p_ctlCon in p_ctlControl.Controls)
			{
				m_mthClearAll(p_ctlCon);	
			}  
		}

		private void m_mthSetUnEdit(bool blnIsEdit)
		{

			foreach(Control ctlRichText in this.Controls )
			{
				m_mthUnEditAll(ctlRichText,blnIsEdit);
			}
		}
		private void m_mthUnEditAll(Control p_ctlControl,bool blnIsEdit)
		{
			string typeName = p_ctlControl.GetType().Name;
			if(typeName =="CheckBox")
				((CheckBox)p_ctlControl).Enabled= blnIsEdit;
			if(typeName == "RadioButton")
				((RadioButton)p_ctlControl).Enabled=blnIsEdit;
			if(typeName =="ctlBorderTextBox" && p_ctlControl.Name!="txtInPatientID" && p_ctlControl.Name!="m_txtPatientName" && p_ctlControl.Name!="m_txtBedNO")
				((ctlBorderTextBox)p_ctlControl).ReadOnly = !blnIsEdit;
            if (typeName == "TextBox")
            {
                ((TextBox)p_ctlControl).ReadOnly = !blnIsEdit;
                m_txtSign.ReadOnly = true;
                m_txtNurseSign.ReadOnly = true;
                m_txtChargeNurse.ReadOnly = true;
            }
			if(typeName == "ctlRichTextBox")
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnReadOnly = !blnIsEdit;

			foreach(Control p_ctlCon in p_ctlControl.Controls)
			{
				m_mthUnEditAll(p_ctlCon,blnIsEdit);	
			}  
		}


		private void m_mthReadOnly(bool blnIsReadOnly)
		{
			if(blnIsReadOnly)
			{
				foreach(Control ctlRichText in this.Controls )
				{
					string typeName = ctlRichText.GetType().Name;
					if(typeName =="CheckBox")
					{
						((CheckBox)ctlRichText).Enabled=false;
						//						((CheckBox)ctlRichText).ForeColor=Color.White;

					}
					if(typeName == "RichTextBox") ((RichTextBox)ctlRichText).ReadOnly=true;
					if(typeName =="ctlBorderTextBox" && ctlRichText.Name!="txtInPatientID" && ctlRichText.Name != "m_txtBedNO" && ctlRichText.Name != "m_txtPatientName")
						ctlRichText.Enabled=false;
					blnCanDelete=false;
				}
			}
			else
			{
				foreach(Control ctlRichText in this.Controls )
				{
					string typeName = ctlRichText.GetType().Name;
					if(typeName =="CheckBox")
						((CheckBox)ctlRichText).Enabled=true;
					if(typeName == "RichTextBox") ((RichTextBox)ctlRichText).ReadOnly=false;
					if(typeName =="ctlBorderTextBox" && ctlRichText.Name!="txtInPatientID")
						ctlRichText.Enabled=true;
					blnCanDelete=true;
				}

			}
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				
				if(m_dtpRecordTime.Enabled ==true)
					return true;
				else 
					return false;
		
			}
		}

		protected override long m_lngSubModify()
		{
			if(m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
				return -1;

			if(m_objIPE==null) 
				return -1;
//			if(MDIParent.OperatorID.Trim()!=m_objIPE.m_strCreateUserID.Trim() && MDIParent.OperatorID.Trim() != m_objIPO.m_strChargeNurse_ID)
//			{
//				clsPublicFunction.ShowInformationMessageBox("无法修改他人的评估表!");
//				return -1;
//			}
			clsEMR_InPatientEvaluate_All objAll = new clsEMR_InPatientEvaluate_All();
			objAll.m_objclsInPatientEvaluate = objInPatientEvaluate(false);
			objAll.m_objclsInPatientHealth_VO = objInPatientHealth(false);
			objAll.m_objInPatientOutEvaluate_VO = objInPatientOutEvaluate(false);
			string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            string m_strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_strInPatientID.Trim() + "-" + m_strInPatientDate;
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objAll, objSign_VO) == -1)
                return -1;

			long lngSave=m_objDomain.m_lngSave(objAll.m_objclsInPatientEvaluate,objAll.m_objclsInPatientHealth_VO,objAll.m_objInPatientOutEvaluate_VO,false ); 
			if(lngSave>0)
			{
				m_mthSetNewValue(m_objCurrent_clsInPatientEvaluate_All);
                clsPublicFunction.ShowInformationMessageBox("修改成功！");
				return 1;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("修改失败！");
				return -5;
			}			
		}

		protected override long m_lngSubAddNew()
		{

//			m_objIPE=new clsEMR_InPatientEvaluate();
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
				return -1;

			clsEMR_InPatientEvaluate_All objAll = new clsEMR_InPatientEvaluate_All();
			objAll.m_objclsInPatientEvaluate = objInPatientEvaluate(true);
			objAll.m_objclsInPatientHealth_VO = objInPatientHealth(true);
			objAll.m_objInPatientOutEvaluate_VO = objInPatientOutEvaluate(true);
			string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            string m_strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_strInPatientID.Trim() + "-" + m_strInPatientDate;
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objAll, objSign_VO) == -1)
                return -1;
          
			long lngSave=m_objDomain.m_lngSave(objAll.m_objclsInPatientEvaluate,objAll.m_objclsInPatientHealth_VO,objAll.m_objInPatientOutEvaluate_VO,true); 
			if(lngSave>0)
			{
				
//				m_mthAddNodeToTrv(this.m_dtpRecordTime.Value);
				m_mthSetNewValue(m_objCurrent_clsInPatientEvaluate_All);
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
				return 1;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败！");
				return -5;
			}
			
		}

		private void m_mthAddNodeToTrv(DateTime p_dtmAdd)
		{
			string strDate=p_dtmAdd.ToString("yyyy-MM-dd HH:mm:ss");
			TreeNode trnDate=new TreeNode(strDate);
			trnDate.Tag =p_dtmAdd;
			if(m_trvTime.Nodes[0].Nodes.Count==0)
				m_trvTime.Nodes[0].Nodes.Add(trnDate);
			else 
			{
				for(int i=0;i<m_trvTime.Nodes[0].Nodes.Count;i++)
				{
					if(trnDate.Text.CompareTo (m_trvTime.Nodes[0].Nodes[i].Text)>0)
					{
						m_trvTime.Nodes[0].Nodes.Insert(i,trnDate);
						break;
					}
				}
			}
			m_trvTime.SelectedNode=trnDate ;
			this.m_trvTime.ExpandAll();

		}

		protected override long m_lngSubDelete()
		{
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
			{
				m_mthShowNoPatient();
				return -1;
			}
            if (m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate == DateTime.MinValue)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择相应的创建时间再删除");
				return -1;
			}
			long lngRes= m_objDomain.m_lngDelete(MDIParent.strOperatorID,strInPatientID,strInPatientDate);
			if(lngRes <=0)
			{
				clsPublicFunction.ShowInformationMessageBox("删除失败");
			}
			else 
			{
				m_mthClearUpSheet();
				m_dtpRecordTime.Enabled=true;
				dtpEduTime.Enabled=true;
				m_objCurrent_clsInPatientEvaluate_All=null;
			}
			return lngRes;
		}

		# region PublicFuction
		public void Delete()
		{
			if(m_BlnIsAddNew)//此时当前没有记录
				return;
            long lngRes = m_lngDelete();
            if (lngRes < 0)
                return;

			this.m_trvTime.SelectedNode=this.m_trvTime.Nodes[0];
		}
		public void Display(){}
		public void Display(string strInPatientID,string strInPatientDate)
		{ 
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Print()
		{
			m_lngPrint();			
		}
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Save()
		{
            //if (m_blnFormReadOnly == true)
            //{
            //    if (m_trvTime.SelectedNode != m_trvTime.Nodes[0].FirstNode)
            //        clsPublicFunction.ShowInformationMessageBox("对不起，历史记录不能修改！");
            //    else if (m_trvTime.Nodes[0].Nodes.Count == 0)
            //        clsPublicFunction.ShowInformationMessageBox("对不起，此病人当前没有入院！");
            //    else
            //        clsPublicFunction.ShowInformationMessageBox("请选择入院时间！");
            //    return;
            //}
            //if (m_trvTime.SelectedNode != m_trvTime.Nodes[0].FirstNode)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("对不起，历史记录不能修改！");
            //    return;
            //}
			if(m_ObjCurrentEmrPatientSession == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择一个病人");
				return;
			}
			
			long m_lngRe=this.m_lngSave();
			if(m_lngRe>0)
			{
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
			}
		}
		#endregion


		private string m_strCurrentOpenDate = "1900-1-1";

		protected override string m_StrCurrentOpenDate
		{
			get
			{
				if(m_strCurrentOpenDate=="")
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
					return "";
				}
				return m_strCurrentOpenDate;
			}
		}
        clsInHospitalMainTransDeptInstance objTransDeptInstance = null;
		/// <summary>
		/// 显示新记录
		/// </summary>
		/// <param name="p_objclsInPatientEvaluate_All">待显示记录的值</param>
		private void m_mthSetNewValue(clsEMR_InPatientEvaluate_All p_objclsInPatientEvaluate_All)
		{
			if(p_objclsInPatientEvaluate_All ==null || p_objclsInPatientEvaluate_All.m_objclsInPatientEvaluate==null)
				return;

			m_mthClearUpSheet();
//			m_dtpRecordTime.Enabled=false;
//			dtpEduTime.Enabled=false;
			
			#region 显示最新的记录

			clsEMR_InPatientEvaluate objclsInPatientEvaluate=p_objclsInPatientEvaluate_All.m_objclsInPatientEvaluate; 
			clsEMR_InPatientHealth_VO objclsInPatientHealth = p_objclsInPatientEvaluate_All.m_objclsInPatientHealth_VO;
			clsEMR_InPatientOutEvaluate_VO objclsInPatientOut = p_objclsInPatientEvaluate_All.m_objInPatientOutEvaluate_VO;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objclsInPatientEvaluate.m_strModifyUserID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign.Tag = objEmpVO;
                m_txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
            }
			
			m_strCurrentOpenDate = objclsInPatientEvaluate.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

			#region 病人历史资料 
			chkInsure.Checked = (objclsInPatientEvaluate.m_strPaymentMethod[0].ToString()=="1"?true:false);
			chkSelfPay.Checked = (objclsInPatientEvaluate.m_strPaymentMethod[1].ToString()=="1"?true:false);
            m_cboEducation.Text = objclsInPatientEvaluate.m_strEducationDegree;
			rdbWalk.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[0].ToString()=="1"?true:false);
			rdbHand.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[1].ToString()=="1"?true:false);
			rdbWheel.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[2].ToString()=="1"?true:false);
			rdbFlat.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[3].ToString()=="1"?true:false);
			rdbBack.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[4].ToString()=="1"?true:false);
			rdbArm.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[5].ToString()=="1"?true:false);
//			m_txtInPatientDiagnose.Text = objclsInPatientEvaluate.m_strInHospitalDiagnose;
//			m_txtInPatientDiagnose.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strInHospitalDiagnose,objclsInPatientEvaluate.m_strInHospitalDiagnoseXML);
			m_txtInPatientDiagnose.m_mthSetNewText(objclsInPatientEvaluate.m_strInHospitalDiagnose,objclsInPatientEvaluate.m_strInHospitalDiagnoseXML);
//			m_txtCaseHistory.Text = objclsInPatientEvaluate.m_strCaseHistory;
//			m_txtCaseHistory.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strCaseHistory,objclsInPatientEvaluate.m_strCaseHistoryXML);
			m_txtCaseHistory.m_mthSetNewText(objclsInPatientEvaluate.m_strCaseHistory,objclsInPatientEvaluate.m_strCaseHistoryXML);
//			m_txtFamilyHistory.Text = objclsInPatientEvaluate.m_strFamilyHistory;
//			m_txtFamilyHistory.Text =ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strFamilyHistory,objclsInPatientEvaluate.m_strFamilyHistoryXML); 
			m_txtFamilyHistory.m_mthSetNewText(objclsInPatientEvaluate.m_strFamilyHistory,objclsInPatientEvaluate.m_strFamilyHistoryXML);
//			m_txtChiefComplain.Text = objclsInPatientEvaluate.m_strChiefComplain;
//			m_txtChiefComplain.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strChiefComplain,objclsInPatientEvaluate.m_strChiefComplainXML);
			m_txtChiefComplain.m_mthSetNewText(objclsInPatientEvaluate.m_strChiefComplain,objclsInPatientEvaluate.m_strChiefComplainXML);
			chkSensitive0.Checked = (objclsInPatientEvaluate.m_strSensitiveHistory[0].ToString()=="1"?true:false);
			chkSensitive1.Checked = (objclsInPatientEvaluate.m_strSensitiveHistory[1].ToString()=="1"?true:false);
			chkSensitive2.Checked = (objclsInPatientEvaluate.m_strSensitiveHistory[2].ToString()=="1"?true:false);
			chkSensitive3.Checked = (objclsInPatientEvaluate.m_strSensitiveHistory[3].ToString()=="1"?true:false);
//			m_txtSensitiveOther.Text = objclsInPatientEvaluate.m_strSensitiveHistory_Other;
//			m_txtSensitiveOther.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strSensitiveHistory_Other,objclsInPatientEvaluate.m_strSensitiveHistory_OtherXML);
			m_txtSensitiveOther.m_mthSetNewText(objclsInPatientEvaluate.m_strSensitiveHistory_Other,objclsInPatientEvaluate.m_strSensitiveHistory_OtherXML);
			#endregion

			#region 体格检查
			m_txtTemperature.Text = objclsInPatientEvaluate.m_strBodyTemperature.Trim();
			m_txtPulse.Text = objclsInPatientEvaluate.m_strPulse.Trim();
			m_txtRhythm.Text = objclsInPatientEvaluate.m_strHeartPhythm.Trim();
			m_txtBp_Shink.Text = objclsInPatientEvaluate.m_strBP_Shrink.Trim();
			m_txtBp_Extend.Text = objclsInPatientEvaluate.m_strBP_Extend.Trim();
			m_txtAvoirdupois.Text = objclsInPatientEvaluate.m_strAvoirdupois.Trim();
            m_txtshengao.Text = objclsInPatientEvaluate.m_strShengao.Trim();

			chkConsciousness0.Checked = (objclsInPatientEvaluate.m_strConsciousness[0].ToString()=="1"?true:false);
			chkConsciousness1.Checked = (objclsInPatientEvaluate.m_strConsciousness[1].ToString()=="1"?true:false);
			chkConsciousness2.Checked = (objclsInPatientEvaluate.m_strConsciousness[2].ToString()=="1"?true:false);
			chkConsciousness3.Checked = (objclsInPatientEvaluate.m_strConsciousness[3].ToString()=="1"?true:false);
			chkConsciousness4.Checked = (objclsInPatientEvaluate.m_strConsciousness[4].ToString()=="1"?true:false);

			chkComplexion0.Checked = (objclsInPatientEvaluate.m_strComplexion[0].ToString()=="1"?true:false);
			chkComplexion1.Checked = (objclsInPatientEvaluate.m_strComplexion[1].ToString()=="1"?true:false);
			chkComplexion2.Checked = (objclsInPatientEvaluate.m_strComplexion[2].ToString()=="1"?true:false);
			chkComplexion3.Checked = (objclsInPatientEvaluate.m_strComplexion[3].ToString()=="1"?true:false);

			chkPhysique0.Checked = (objclsInPatientEvaluate.m_strPhysique[0].ToString()=="1"?true:false);
			chkPhysique1.Checked = (objclsInPatientEvaluate.m_strPhysique[1].ToString()=="1"?true:false);
			chkPhysique2.Checked = (objclsInPatientEvaluate.m_strPhysique[2].ToString()=="1"?true:false);
//			m_txtPhysiqueOther.Text = objclsInPatientEvaluate.m_strPhysique_Other;
//			m_txtPhysiqueOther.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strPhysique_Other,objclsInPatientEvaluate.m_strPhysique_OtherXML);
			m_txtPhysiqueOther.m_mthSetNewText(objclsInPatientEvaluate.m_strPhysique_Other,objclsInPatientEvaluate.m_strPhysique_OtherXML);

			chkEmotion0.Checked = (objclsInPatientEvaluate.m_strEmotion[0].ToString()=="1"?true:false);
			chkEmotion1.Checked = (objclsInPatientEvaluate.m_strEmotion[1].ToString()=="1"?true:false);
			chkEmotion2.Checked = (objclsInPatientEvaluate.m_strEmotion[2].ToString()=="1"?true:false);

			chkSkin0.Checked = (objclsInPatientEvaluate.m_strSkin[0].ToString()=="1"?true:false);
			chkSkin1.Checked = (objclsInPatientEvaluate.m_strSkin[1].ToString()=="1"?true:false);
			chkSkin2.Checked = (objclsInPatientEvaluate.m_strSkin[2].ToString()=="1"?true:false);
			chkSkin3.Checked = (objclsInPatientEvaluate.m_strSkin[3].ToString()=="1"?true:false);
			chkSkin4.Checked = (objclsInPatientEvaluate.m_strSkin[4].ToString()=="1"?true:false);
			chkSkin5.Checked = (objclsInPatientEvaluate.m_strSkin[5].ToString()=="1"?true:false);
			chkSkin6.Checked = (objclsInPatientEvaluate.m_strSkin[6].ToString()=="1"?true:false);
			chkSkin7.Checked = (objclsInPatientEvaluate.m_strSkin[7].ToString()=="1"?true:false);
			chkSkin8.Checked = (objclsInPatientEvaluate.m_strSkin[8].ToString()=="1"?true:false);
//			m_txtSkinOther.Text = objclsInPatientEvaluate.m_strSkin_Other;
//			m_txtSkinOther.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strSkin_Other,objclsInPatientEvaluate.m_strSkin_OtherXML);
			m_txtSkinOther.m_mthSetNewText(objclsInPatientEvaluate.m_strSkin_Other,objclsInPatientEvaluate.m_strSkin_OtherXML);

			chkLimbsactivity0.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[0].ToString()=="1"?true:false);
			chkLimbsactivity1.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[1].ToString()=="1"?true:false);
			chkLimbsactivity2.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[2].ToString()=="1"?true:false);
			chkLimbsactivity3.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[3].ToString()=="1"?true:false);
			chkLimbsactivity4.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[4].ToString()=="1"?true:false);
			chkLimbsactivity5.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[5].ToString()=="1"?true:false);
			chkLimbsactivity6.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[6].ToString()=="1"?true:false);
//			m_txtLimbsactivityOther.Text = objclsInPatientEvaluate.m_strLimbsactivity_Other;
//			m_txtLimbsactivityOther.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strLimbsactivity_Other,objclsInPatientEvaluate.m_strLimbsactivity_OtherXML);
			m_txtLimbsactivityOther.m_mthSetNewText(objclsInPatientEvaluate.m_strLimbsactivity_Other,objclsInPatientEvaluate.m_strLimbsactivity_OtherXML);
			#endregion

			#region 生活状况及自理程度
			chkBiteSup0.Checked = (objclsInPatientEvaluate.m_strBiteSup[0].ToString()=="1"?true:false);
			chkBiteSup1.Checked = (objclsInPatientEvaluate.m_strBiteSup[1].ToString()=="1"?true:false);
			chkBiteSup2.Checked = (objclsInPatientEvaluate.m_strBiteSup[2].ToString()=="1"?true:false);
			chkBiteSup3.Checked = (objclsInPatientEvaluate.m_strBiteSup[3].ToString()=="1"?true:false);
			chkBiteSup4.Checked = (objclsInPatientEvaluate.m_strBiteSup[4].ToString()=="1"?true:false);
			chkBiteSup6.Checked = (objclsInPatientEvaluate.m_strBiteSup[5].ToString()=="1"?true:false);
			chkBiteSup7.Checked = (objclsInPatientEvaluate.m_strBiteSup[6].ToString()=="1"?true:false);
			chkBiteSup8.Checked = (objclsInPatientEvaluate.m_strBiteSup[7].ToString()=="1"?true:false);
			chkBiteSup9.Checked = (objclsInPatientEvaluate.m_strBiteSup[8].ToString()=="1"?true:false);
			chkBiteSup10.Checked = (objclsInPatientEvaluate.m_strBiteSup[9].ToString()=="1"?true:false);

			chkAppetite0.Checked = (objclsInPatientEvaluate.m_strAppetite[0].ToString()=="1"?true:false);
			chkAppetite1.Checked = (objclsInPatientEvaluate.m_strAppetite[1].ToString()=="1"?true:false);
			chkAppetite2.Checked = (objclsInPatientEvaluate.m_strAppetite[2].ToString()=="1"?true:false);
			chkAppetite3.Checked = (objclsInPatientEvaluate.m_strAppetite[3].ToString()=="1"?true:false);
			chkAppetite4.Checked = (objclsInPatientEvaluate.m_strAppetite[4].ToString()=="1"?true:false);
			chkAppetite5.Checked = (objclsInPatientEvaluate.m_strAppetite[5].ToString()=="1"?true:false);

			chkSleep0.Checked = (objclsInPatientEvaluate.m_strSleep[0].ToString()=="1"?true:false);
			chkSleep1.Checked = (objclsInPatientEvaluate.m_strSleep[1].ToString()=="1"?true:false);
			chkSleep2.Checked = (objclsInPatientEvaluate.m_strSleep[2].ToString()=="1"?true:false);
			chkSleep3.Checked = (objclsInPatientEvaluate.m_strSleep[3].ToString()=="1"?true:false);
			chkSleep4.Checked = (objclsInPatientEvaluate.m_strSleep[4].ToString()=="1"?true:false);

			chkStool.Checked = (objclsInPatientEvaluate.m_strStool=="1"?true:false);
			string [] split = objclsInPatientEvaluate.m_strAstriction.Split(new Char [] {'次'},2);
			m_txtAstrictionTimes.Text = split[0];
			m_txtAstrictionDays.Text = split[1];
			string [] split1 = objclsInPatientEvaluate.m_strDiarrhea.Split(new Char [] {'次'},2);
			m_txtDiarrheaTimes.Text = split1[0];
			m_txtDiarrheaDays.Text = split1[1];
//			m_txtStoolOther.Text = objclsInPatientEvaluate.m_strStool_Other;
//			m_txtStoolOther.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strStool_Other,objclsInPatientEvaluate.m_strStool_OtherXML);
			m_txtStoolOther.m_mthSetNewText(objclsInPatientEvaluate.m_strStool_Other,objclsInPatientEvaluate.m_strStool_OtherXML);

			chkPee0.Checked = (objclsInPatientEvaluate.m_strPee[0].ToString()=="1"?true:false);
			chkPee1.Checked = (objclsInPatientEvaluate.m_strPee[1].ToString()=="1"?true:false);
			chkPee2.Checked = (objclsInPatientEvaluate.m_strPee[2].ToString()=="1"?true:false);
			chkPee3.Checked = (objclsInPatientEvaluate.m_strPee[3].ToString()=="1"?true:false);
			chkPee4.Checked = (objclsInPatientEvaluate.m_strPee[4].ToString()=="1"?true:false);
			chkPee5.Checked = (objclsInPatientEvaluate.m_strPee[5].ToString()=="1"?true:false);
			chkPee6.Checked = (objclsInPatientEvaluate.m_strPee[6].ToString()=="1"?true:false);
			chkPee7.Checked = (objclsInPatientEvaluate.m_strPee[7].ToString()=="1"?true:false);
			chkPee8.Checked = (objclsInPatientEvaluate.m_strPee[8].ToString()=="1"?true:false);
			chkPee9.Checked = (objclsInPatientEvaluate.m_strPee[9].ToString()=="1"?true:false);

			chkHobby0.Checked  = (objclsInPatientEvaluate.m_strHobby[0].ToString()=="1"?true:false);
			chkHobby1.Checked  = (objclsInPatientEvaluate.m_strHobby[1].ToString()=="1"?true:false);
			chkHobby2.Checked  = (objclsInPatientEvaluate.m_strHobby[2].ToString()=="1"?true:false);
			chkHobby3.Checked  = (objclsInPatientEvaluate.m_strHobby[3].ToString()=="1"?true:false);
			chkHobby4.Checked  = (objclsInPatientEvaluate.m_strHobby[4].ToString()=="1"?true:false);
//			m_txtHobbyOther.Text = objclsInPatientEvaluate.m_strHobby_Other;
//			m_txtHobbyOther.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strHobby_Other,objclsInPatientEvaluate.m_strHobby_OtherXML);
			m_txtHobbyOther.m_mthSetNewText(objclsInPatientEvaluate.m_strHobby_Other,objclsInPatientEvaluate.m_strHobby_OtherXML);

			chkSelfSolve0.Checked = (objclsInPatientEvaluate.m_strSelfSolve[0].ToString()=="1"?true:false);
			chkSelfSolve1.Checked = (objclsInPatientEvaluate.m_strSelfSolve[1].ToString()=="1"?true:false);
			chkSelfSolve2.Checked = (objclsInPatientEvaluate.m_strSelfSolve[2].ToString()=="1"?true:false);
			#endregion

			#region 心理社会方面
			chkFeeling0.Checked = (objclsInPatientEvaluate.m_strFeeling[0].ToString()=="1"?true:false);
			chkFeeling1.Checked = (objclsInPatientEvaluate.m_strFeeling[1].ToString()=="1"?true:false);
			chkFeeling2.Checked = (objclsInPatientEvaluate.m_strFeeling[2].ToString()=="1"?true:false);
			chkFeeling3.Checked = (objclsInPatientEvaluate.m_strFeeling[3].ToString()=="1"?true:false);
			chkFeeling4.Checked = (objclsInPatientEvaluate.m_strFeeling[4].ToString()=="1"?true:false);
			chkFeeling5.Checked = (objclsInPatientEvaluate.m_strFeeling[5].ToString()=="1"?true:false);
			chkFeeling6.Checked = (objclsInPatientEvaluate.m_strFeeling[6].ToString()=="1"?true:false);
			chkFeeling7.Checked = (objclsInPatientEvaluate.m_strFeeling[7].ToString()=="1"?true:false);
			chkFeeling8.Checked = (objclsInPatientEvaluate.m_strFeeling[8].ToString()=="1"?true:false);

			chkJob0.Checked = (objclsInPatientEvaluate.m_strJob[0].ToString()=="1"?true:false);
			chkJob1.Checked = (objclsInPatientEvaluate.m_strJob[1].ToString()=="1"?true:false);
			chkJob2.Checked = (objclsInPatientEvaluate.m_strJob[2].ToString()=="1"?true:false);
			chkJob3.Checked = (objclsInPatientEvaluate.m_strJob[3].ToString()=="1"?true:false);
			chkJob4.Checked = (objclsInPatientEvaluate.m_strJob[4].ToString()=="1"?true:false);
			chkJob5.Checked = (objclsInPatientEvaluate.m_strJob[5].ToString()=="1"?true:false);
			chkJob6.Checked = (objclsInPatientEvaluate.m_strJob[6].ToString()=="1"?true:false);

			chkInHospitalWorry0.Checked = (objclsInPatientEvaluate.m_strInHospitalWorry[0].ToString()=="1"?true:false);
			chkInHospitalWorry1.Checked = (objclsInPatientEvaluate.m_strInHospitalWorry[1].ToString()=="1"?true:false);
			chkInHospitalWorry2.Checked = (objclsInPatientEvaluate.m_strInHospitalWorry[2].ToString()=="1"?true:false);
//			m_txtInHospitalWorryOther.Text = objclsInPatientEvaluate.m_strInHospitalWorry_Other;
//			m_txtInHospitalWorryOther.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strInHospitalWorry_Other,objclsInPatientEvaluate.m_strInHospitalWorryXML);
			m_txtInHospitalWorryOther.m_mthSetNewText(objclsInPatientEvaluate.m_strInHospitalWorry_Other,objclsInPatientEvaluate.m_strInHospitalWorryXML);

			chkFamilyForm0.Checked = (objclsInPatientEvaluate.m_strFamilyForm[0].ToString()=="1"?true:false);
			chkFamilyForm1.Checked = (objclsInPatientEvaluate.m_strFamilyForm[1].ToString()=="1"?true:false);
			chkFamilyForm2.Checked = (objclsInPatientEvaluate.m_strFamilyForm[2].ToString()=="1"?true:false);
			chkFamilyForm3.Checked = (objclsInPatientEvaluate.m_strFamilyForm[3].ToString()=="1"?true:false);
//			m_txtFamilyFormOther.Text = objclsInPatientEvaluate.m_strFamilyForm_Other;
//			m_txtFamilyFormOther.Text =	 ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strFamilyForm_Other,objclsInPatientEvaluate.m_strFamilyForm_OtherXML);
			m_txtFamilyFormOther.m_mthSetNewText(objclsInPatientEvaluate.m_strFamilyForm_Other,objclsInPatientEvaluate.m_strFamilyForm_OtherXML);

			chkHealthNeed0.Checked = (objclsInPatientEvaluate.m_strHealthNeed[0].ToString()=="1"?true:false);
			chkHealthNeed1.Checked = (objclsInPatientEvaluate.m_strHealthNeed[1].ToString()=="1"?true:false);
			chkHealthNeed2.Checked = (objclsInPatientEvaluate.m_strHealthNeed[2].ToString()=="1"?true:false);
			chkHealthNeed3.Checked = (objclsInPatientEvaluate.m_strHealthNeed[3].ToString()=="1"?true:false);
			chkHealthNeed4.Checked = (objclsInPatientEvaluate.m_strHealthNeed[4].ToString()=="1"?true:false);

			chkKnowDisease0.Checked = (objclsInPatientEvaluate.m_strKnowDisease[0].ToString()=="1"?true:false);
			chkKnowDisease1.Checked = (objclsInPatientEvaluate.m_strKnowDisease[1].ToString()=="1"?true:false);
			chkKnowDisease2.Checked = (objclsInPatientEvaluate.m_strKnowDisease[2].ToString()=="1"?true:false);
			chkKnowDisease3.Checked = (objclsInPatientEvaluate.m_strKnowDisease[3].ToString()=="1"?true:false);
			#endregion

			#region 检查及计划
//			m_txtSpecilizedCheck.Text = objclsInPatientEvaluate.m_strSpecializedCheck;
//			m_txtSpecilizedCheck.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strSpecializedCheck,objclsInPatientEvaluate.m_strSpecializedCheckXML);
			m_txtSpecilizedCheck.m_mthSetNewText(objclsInPatientEvaluate.m_strSpecializedCheck.Replace("&*","?"),objclsInPatientEvaluate.m_strSpecializedCheckXML);
//			m_txtPipInstance.Text = objclsInPatientEvaluate.m_strPipInstance;
//			m_txtPipInstance.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strPipInstance,objclsInPatientEvaluate.m_strPipInstanceXML);
			m_txtPipInstance.m_mthSetNewText(objclsInPatientEvaluate.m_strPipInstance,objclsInPatientEvaluate.m_strPipInstanceXML);
//			m_txtWoodInstance.Text = objclsInPatientEvaluate.m_strWoodInstance;
//			m_txtWoodInstance.Text = ctlRichTextBox.s_strGetRightText( objclsInPatientEvaluate.m_strWoodInstance, objclsInPatientEvaluate.m_strWoodInstanceXML);
			m_txtWoodInstance.m_mthSetNewText(objclsInPatientEvaluate.m_strWoodInstance,objclsInPatientEvaluate.m_strWoodInstanceXML);
//			m_txtTendPlan.Text = objclsInPatientEvaluate.m_strTendPlan;
//			m_txtTendPlan.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strTendPlan,objclsInPatientEvaluate.m_strTendPlanXML);
			m_txtTendPlan.m_mthSetNewText(objclsInPatientEvaluate.m_strTendPlan,objclsInPatientEvaluate.m_strTendPlanXML);
			#endregion

			#region 病人健康教育评估表
			#region 第一次完成
            if (objclsInPatientHealth != null)
            {
                ArrayList arrList = new ArrayList();
                m_mthXMLToForm(out arrList, objclsInPatientHealth.m_strHEDU_First);
                m_txtReadOutEdu1.Text = arrList[0].ToString().Trim();
                m_txtReadOutNurse1.Text = arrList[1].ToString().Trim();
                m_txtReadOutDate1.Text = arrList[2].ToString().Trim();
                m_txtExplanEdu1.Text = arrList[3].ToString().Trim();
                m_txtExplanNurse1.Text = arrList[4].ToString().Trim();
                m_txtExplanDate1.Text = arrList[5].ToString().Trim();
                m_txtMedicineEdu1.Text = arrList[6].ToString().Trim();
                m_txtMedicineNurse1.Text = arrList[7].ToString().Trim();
                m_txtMedicineDate1.Text = arrList[8].ToString().Trim();
                m_txtNoticeEdu1.Text = arrList[9].ToString().Trim();
                m_txtNoticeNurse1.Text = arrList[10].ToString().Trim();
                m_txtNoticeDate1.Text = arrList[11].ToString().Trim();
                m_txtKnowledgeEdu1.Text = arrList[12].ToString().Trim();
                m_txtKnowledgeNurse1.Text = arrList[13].ToString().Trim();
                m_txtKnowledgeDate1.Text = arrList[14].ToString().Trim();
                m_txtGuidanceEdu1.Text = arrList[15].ToString().Trim();
                m_txtGuidanceNurse1.Text = arrList[16].ToString().Trim();
                m_txtGuidanceDate1.Text = arrList[17].ToString().Trim();
                m_txtOtherEdu1.Text = arrList[18].ToString().Trim();
                m_txtOtherNurse1.Text = arrList[19].ToString().Trim();
                m_txtOtherDate1.Text = arrList[20].ToString().Trim();
            }
			#endregion

			#region 第二次完成
            if (objclsInPatientHealth != null)
            {
                ArrayList arrList2 = new ArrayList();
                m_mthXMLToForm(out arrList2, objclsInPatientHealth.m_strHEDU_Second);
                m_txtReadOutEdu2.Text = arrList2[0].ToString().Trim();
                m_txtReadOutNurse2.Text = arrList2[1].ToString().Trim();
                m_txtReadOutDate2.Text = arrList2[2].ToString().Trim();
                m_txtExplanEdu2.Text = arrList2[3].ToString().Trim();
                m_txtExplanNurse2.Text = arrList2[4].ToString().Trim();
                m_txtExplanDate2.Text = arrList2[5].ToString().Trim();
                m_txtMedicineEdu2.Text = arrList2[6].ToString().Trim();
                m_txtMedicineNurse2.Text = arrList2[7].ToString().Trim();
                m_txtMedicineDate2.Text = arrList2[8].ToString().Trim();
                m_txtNoticeEdu2.Text = arrList2[9].ToString().Trim();
                m_txtNoticeNurse2.Text = arrList2[10].ToString().Trim();
                m_txtNoticeDate2.Text = arrList2[11].ToString().Trim();
                m_txtKnowledgeEdu2.Text = arrList2[12].ToString().Trim();
                m_txtKnowledgeNurse2.Text = arrList2[13].ToString().Trim();
                m_txtKnowledgeDate2.Text = arrList2[14].ToString().Trim();
                m_txtGuidanceEdu2.Text = arrList2[15].ToString().Trim();
                m_txtGuidanceNurse2.Text = arrList2[16].ToString().Trim();
                m_txtGuidanceDate2.Text = arrList2[17].ToString().Trim();
                m_txtOtherEdu2.Text = arrList2[18].ToString().Trim();
                m_txtOtherNurse2.Text = arrList2[19].ToString().Trim();
                m_txtOtherDate2.Text = arrList2[20].ToString().Trim();
            }
			#endregion

			#region 第三次完成
            if (objclsInPatientHealth != null)
            {
                ArrayList arrList3 = new ArrayList();
                m_mthXMLToForm(out arrList3, objclsInPatientHealth.m_strHEDU_Three);
                m_txtReadOutEdu3.Text = arrList3[0].ToString().Trim();
                m_txtReadOutNurse3.Text = arrList3[1].ToString().Trim();
                m_txtReadOutDate3.Text = arrList3[2].ToString().Trim();
                m_txtExplanEdu3.Text = arrList3[3].ToString().Trim();
                m_txtExplanNurse3.Text = arrList3[4].ToString().Trim();
                m_txtExplanDate3.Text = arrList3[5].ToString().Trim();
                m_txtMedicineEdu3.Text = arrList3[6].ToString().Trim();
                m_txtMedicineNurse3.Text = arrList3[7].ToString().Trim();
                m_txtMedicineDate3.Text = arrList3[8].ToString().Trim();
                m_txtNoticeEdu3.Text = arrList3[9].ToString();
                m_txtNoticeNurse3.Text = arrList3[10].ToString().Trim();
                m_txtNoticeDate3.Text = arrList3[11].ToString().Trim();
                m_txtKnowledgeEdu3.Text = arrList3[12].ToString().Trim();
                m_txtKnowledgeNurse3.Text = arrList3[13].ToString().Trim();
                m_txtKnowledgeDate3.Text = arrList3[14].ToString().Trim();
                m_txtGuidanceEdu3.Text = arrList3[15].ToString().Trim();
                m_txtGuidanceNurse3.Text = arrList3[16].ToString().Trim();
                m_txtGuidanceDate3.Text = arrList3[17].ToString().Trim();
                m_txtOtherEdu3.Text = arrList3[18].ToString().Trim();
                m_txtOtherNurse3.Text = arrList3[19].ToString().Trim();
                m_txtOtherDate3.Text = arrList3[20].ToString().Trim();
            }
			#endregion

            dtpEduTime.Value = objclsInPatientHealth.m_dtmWriteFormDate;// m_dtpRecordTime.Value;

			#endregion

			#region 病人出院评估及指导
            if (objclsInPatientOut != null)
            {
                //			m_txtOutHospitalDiagnose.Text = objclsInPatientOut.m_strOutHospitalDiagnose;
                //			m_txtOutHospitalDiagnose.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientOut.m_strOutHospitalDiagnose,objclsInPatientOut.m_strOutHospitalDiagnoseXML);
                m_txtOutHospitalDiagnose.m_mthSetNewText(objclsInPatientOut.m_strOutHospitalDiagnose.Replace("&*","?"), objclsInPatientOut.m_strOutHospitalDiagnoseXML);

                chkLiveAbility0.Checked = (objclsInPatientOut.m_strLiveAbility[0].ToString() == "1" ? true : false);
                chkLiveAbility1.Checked = (objclsInPatientOut.m_strLiveAbility[1].ToString() == "1" ? true : false);
                chkLiveAbility2.Checked = (objclsInPatientOut.m_strLiveAbility[2].ToString() == "1" ? true : false);

                chkDieteticCircs0.Checked = (objclsInPatientOut.m_strDieteticCircs[0].ToString() == "1" ? true : false);
                chkDieteticCircs1.Checked = (objclsInPatientOut.m_strDieteticCircs[1].ToString() == "1" ? true : false);
                chkDieteticCircs2.Checked = (objclsInPatientOut.m_strDieteticCircs[2].ToString() == "1" ? true : false);
                chkDieteticCircs3.Checked = (objclsInPatientOut.m_strDieteticCircs[3].ToString() == "1" ? true : false);
                chkDieteticCircs4.Checked = (objclsInPatientOut.m_strDieteticCircs[4].ToString() == "1" ? true : false);
                chkDieteticCircs5.Checked = (objclsInPatientOut.m_strDieteticCircs[5].ToString() == "1" ? true : false);
                chkDieteticCircs6.Checked = (objclsInPatientOut.m_strDieteticCircs[6].ToString() == "1" ? true : false);

                chkOutHospitalMode0.Checked = (objclsInPatientOut.m_strOutHospitalMode[0].ToString() == "1" ? true : false);
                chkOutHospitalMode1.Checked = (objclsInPatientOut.m_strOutHospitalMode[1].ToString() == "1" ? true : false);
                chkOutHospitalMode2.Checked = (objclsInPatientOut.m_strOutHospitalMode[2].ToString() == "1" ? true : false);
                chkOutHospitalMode3.Checked = (objclsInPatientOut.m_strOutHospitalMode[3].ToString() == "1" ? true : false);
                chkOutHospitalMode4.Checked = (objclsInPatientOut.m_strOutHospitalMode[4].ToString() == "1" ? true : false);

                chkNurseSyndrome0.Checked = (objclsInPatientOut.m_strIsNurseSyndrome[0].ToString() == "1" ? true : false);
                chkNurseSyndrome1.Checked = (objclsInPatientOut.m_strIsNurseSyndrome[1].ToString() == "1" ? true : false);
                //			m_txtNurseSyndrome.Text = objclsInPatientOut.m_strNurseSyndrome;
                //			m_txtNurseSyndrome.Text =   ctlRichTextBox.s_strGetRightText(objclsInPatientOut.m_strNurseSyndrome,objclsInPatientOut.m_strNurseSyndromeXML);
                m_txtNurseSyndrome.m_mthSetNewText(objclsInPatientOut.m_strNurseSyndrome, objclsInPatientOut.m_strNurseSyndromeXML);

                chkNurseIssue0.Checked = (objclsInPatientOut.m_strIsNurseIssue[0].ToString() == "1" ? true : false);
                chkNurseIssue1.Checked = (objclsInPatientOut.m_strIsNurseIssue[1].ToString() == "1" ? true : false);
                //			m_txtNurseIssue.Text = objclsInPatientOut.m_strNurseIssue;
                //			m_txtNurseIssue.Text = ctlRichTextBox.s_strGetRightText(objclsInPatientOut.m_strNurseIssue,objclsInPatientOut.m_strNurseIssueXML);
                m_txtNurseIssue.m_mthSetNewText(objclsInPatientOut.m_strNurseIssue, objclsInPatientOut.m_strNurseIssueXML);

                chkCommonlyCoach0.Checked = (objclsInPatientOut.m_strCommonlyCoach[0].ToString() == "1" ? true : false);
                chkCommonlyCoach1.Checked = (objclsInPatientOut.m_strCommonlyCoach[1].ToString() == "1" ? true : false);
                chkCommonlyCoach2.Checked = (objclsInPatientOut.m_strCommonlyCoach[2].ToString() == "1" ? true : false);
                chkCommonlyCoach3.Checked = (objclsInPatientOut.m_strCommonlyCoach[3].ToString() == "1" ? true : false);
                chkCommonlyCoach4.Checked = (objclsInPatientOut.m_strCommonlyCoach[4].ToString() == "1" ? true : false);
                chkCommonlyCoach5.Checked = (objclsInPatientOut.m_strCommonlyCoach[5].ToString() == "1" ? true : false);
                chkCommonlyCoach6.Checked = (objclsInPatientOut.m_strCommonlyCoach[6].ToString() == "1" ? true : false);
                chkCommonlyCoach7.Checked = (objclsInPatientOut.m_strCommonlyCoach[7].ToString() == "1" ? true : false);

                chkAdviceDrug0.Checked = (objclsInPatientOut.m_strAdviceDrug[0].ToString() == "1" ? true : false);
                chkAdviceDrug1.Checked = (objclsInPatientOut.m_strAdviceDrug[1].ToString() == "1" ? true : false);
                chkAdviceDrug2.Checked = (objclsInPatientOut.m_strAdviceDrug[2].ToString() == "1" ? true : false);
                chkAdviceDrug3.Checked = (objclsInPatientOut.m_strAdviceDrug[3].ToString() == "1" ? true : false);

                chkSpecialtiesCoach0.Checked = (objclsInPatientOut.m_strIsSpecialtiesCoach[0].ToString() == "1" ? true : false);
                chkSpecialtiesCoach1.Checked = (objclsInPatientOut.m_strIsSpecialtiesCoach[1].ToString() == "1" ? true : false);
                //			m_txtSpecialtiesCoach.Text  = objclsInPatientOut.m_strSpecialtiesCoach;
                //			m_txtSpecialtiesCoach.Text  = ctlRichTextBox.s_strGetRightText(objclsInPatientOut.m_strSpecialtiesCoach,objclsInPatientOut.m_strSpecialtiesCoachXML);
                m_txtSpecialtiesCoach.m_mthSetNewText(objclsInPatientOut.m_strSpecialtiesCoach, objclsInPatientOut.m_strSpecialtiesCoachXML);

                objEmployeeSign.m_lngGetEmpByNO(objclsInPatientOut.m_strNurseSign_ID, out objEmpVO);
                if (objEmpVO != null)
                {
                    m_txtNurseSign.Tag = objEmpVO;
                    m_txtNurseSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                }

                objEmployeeSign.m_lngGetEmpByNO(objclsInPatientOut.m_strChargeNurse_ID, out objEmpVO);
                if (objEmpVO != null)
                {
                    m_txtChargeNurse.Tag = objEmpVO;
                    m_txtChargeNurse.Text = objEmpVO.m_strLASTNAME_VCHR;
                }
                long lngRes = 0;
                string strTemp = "";
                lngRes = m_objDomain1.m_lngGetInHospitalMainTransDeptInstance(m_ObjCurrentEmrPatientSession.m_strRegisterId, out objTransDeptInstance);

                if (lngRes > 0 && objTransDeptInstance != null)
                {
                    if (objTransDeptInstance.m_demOutPatientDate != new DateTime(1900, 1, 1) && objTransDeptInstance.m_demOutPatientDate != DateTime.MinValue)
                        strTemp = objTransDeptInstance.m_demOutPatientDate.ToString("yyyy年MM月dd日 HH时");
                    else
                        strTemp = "";

                }
                System.TimeSpan diff = new TimeSpan(0);
                DateTime dtmTemp = DateTime.Now;
                if (strTemp == "")
                {

                    com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objPMT =
                        (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));
                    string strDateNow = objPMT.m_strGetDBServerTime(null);
                    objPMT = null;
                    if (!DateTime.TryParse(strDateNow, out dtmTemp))
                    {
                        dtmTemp = DateTime.Now;
                    }
                    diff = dtmTemp.Subtract(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate);
                }
                else
                {
                    diff = Convert.ToDateTime(strTemp).Subtract(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate);
                }

                if (diff.Days < 1)
                    lblInHospitalDays.Text = "1";
                else if (strTemp == "")
                {
                    diff = Convert.ToDateTime(dtmTemp.ToString("yyyy-MM-dd")).Subtract(Convert.ToDateTime(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy-MM-dd")));
                    lblInHospitalDays.Text = diff.Days.ToString();
                }
                else
                {
                    diff = Convert.ToDateTime(Convert.ToDateTime(strTemp).ToString("yyyy-MM-dd")).Subtract(Convert.ToDateTime(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy-MM-dd")));
                    lblInHospitalDays.Text = diff.Days.ToString();
                }
                //if (m_ObjCurrentEmrPatientSession.m_dtmOutDate == DateTime.Parse("1900-01-01 00:00:00") || m_ObjCurrentEmrPatientSession.m_dtmOutDate == DateTime.MinValue)
                //{
                //    this.lblInHospitalDays.Text = ((DateTime.Now - m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate).Days + 1).ToString();
                //    //this.lblInHospitalDays.Text = ((m_objIPO.m_dtmOpenDate - m_objIPO.m_dtmInPatientDate).Days + 1).ToString();
                //}
                //else
                //{
                //    this.lblInHospitalDays.Text = ((m_ObjCurrentEmrPatientSession.m_dtmOutDate - m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate).Days + 1).ToString();
                //    //this.lblInHospitalDays.Text = ((m_objIPO.m_dtmOpenDate - m_objIPO.m_dtmInPatientDate).Days + 1).ToString();
                //}
            }
			#endregion

			m_mthSetRichTextModifyColor(this,Color.Red); 
			m_mthSetRichTextCanModifyLast(this,true);            
			#endregion
		}

		private void m_trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{		
			try
			{
				m_mthRecordChangedToSave();

				m_dtpRecordTime.Enabled=false;
                dtpEduTime.Enabled = true;

				if( e.Node.Text.Length > 4)
				{	
					m_mthClearUpSheet();
					m_mthSetUnEdit(true);
					clsEMR_InPatientEvaluate_All objclsInPatientEvaluate_All;

                    //设置病人当次住院的基本信息
                    m_mthOnlySetPatientInfo(m_objCurrentPatient);
                    m_objCurrentPatient.m_ObjPeopleInfo = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvTime.Nodes[0].Nodes.Count - m_trvTime.SelectedNode.Index - 1).m_ObjPeopleInfo;

                    string m_strInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvTime.Nodes[0].Nodes.Count - m_trvTime.SelectedNode.Index - 1).m_StrEMRInPatientID;
                    string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvTime.Nodes[0].Nodes.Count - m_trvTime.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");

                    txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvTime.Nodes[0].Nodes.Count - m_trvTime.SelectedNode.Index - 1).m_StrHISInPatientID;
                    m_objCurrentPatient.m_DtmSelectedInDate = DateTime.Parse(m_strInPatientDate);
                    m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                    m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(m_trvTime.SelectedNode.Text);
                    strInPatientID = m_strInPatientID;

                    m_mthIsReadOnly();

                    if (!m_blnCanShowRecordContent())
                    {
                        clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                        return;
                    }

                    string strSelectedInTime = m_strInPatientDate;
                    long lngRes = m_objDomain.m_lngGetLatestRecord_All(strInPatientID, strSelectedInTime, out objclsInPatientEvaluate_All);
					if(lngRes<=0)
					{
						clsPublicFunction.ShowInformationMessageBox("数据错误或数据库连接失败，请与系统管理员联系！");
						return;
					}
					else if(lngRes>0 && (objclsInPatientEvaluate_All==null ||objclsInPatientEvaluate_All.m_objclsInPatientEvaluate==null ))
					{
						if(Convert.ToDateTime(strInPatientDate) > Convert.ToDateTime(strSelectedInTime))
						{
							m_objCurrent_clsInPatientEvaluate_All=null;
							m_mthSetControlReadOnly(this,true);
							m_mthAddFormStatusForClosingSave();
							//当前处于禁止输入状态
							MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.None );
							return;
						}
						else
						{
							m_dtpRecordTime.Enabled=true;
							dtpEduTime.Enabled = true;
							m_mthClearUpSheet();
							m_blnFormReadOnly=false;
							m_mthSetControlReadOnly(this,m_blnFormReadOnly);
							m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
							m_mthSetRichTextCanModifyLast(this,true);
							m_objCurrent_clsInPatientEvaluate_All=null;

                            m_mthSetDefaultValue(m_objCurrentPatient);

							int m_intSessionIndex = m_trvTime.Nodes[0].Nodes.Count - (m_trvTime.SelectedNode.Index);
							clsInBedSessionInfo m_objSession = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_intSessionIndex-1);
							if(m_objSession.m_DtmOutDate == DateTime.Parse("1900-01-01 00:00:00") || m_objSession.m_DtmOutDate == m_objSession.m_DtmInDate)
							{
                                this.lblInHospitalDays.Text = ((DateTime.Now - DateTime.Parse(e.Node.Text)).Days + 1).ToString();
                                //this.lblInHospitalDays.Text = ((m_objIPO.m_dtmOpenDate - m_objIPO.m_dtmInPatientDate).Days + 1).ToString();
							}
							else
							{
                                this.lblInHospitalDays.Text = ((m_objSession.m_DtmOutDate - DateTime.Parse(e.Node.Text)).Days + 1).ToString();
                                //this.lblInHospitalDays.Text = ((m_objIPO.m_dtmOpenDate - m_objIPO.m_dtmInPatientDate).Days + 1).ToString();
							}

							//当前处于新增记录状态
							MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);

							m_mthAddFormStatusForClosingSave();

							return;//当前为空记录，进入添加记录状态
						}
					}			
					
					m_objCurrent_clsInPatientEvaluate_All=objclsInPatientEvaluate_All;
					m_mthSetNewValue(m_objCurrent_clsInPatientEvaluate_All);

                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);

                    m_mthAddFormStatusForClosingSave();

                    if (strInPatientDate != ((DateTime)e.Node.Tag).ToString("yyyy-MM-dd HH:mm:ss"))
                        m_blnFormReadOnly = true;
                    else m_blnFormReadOnly = false;
				}
				else 
				{
					m_mthClearUpSheet();
					m_mthSetUnEdit(false);
					m_dtpRecordTime.Value=DateTime.Now;
					dtpEduTime.Value = DateTime.Now;

					//当前处于禁止输入状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.None );

					m_mthAddFormStatusForClosingSave();
				}
//				m_mthSetControlReadOnly(this,m_blnFormReadOnly);
				
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);
			}
		}

		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

            MDIParent.m_mthSetDefaulEmployee(m_txtSign);

            clsPeopleInfo objPeopleInfo = p_objPatient.m_ObjPeopleInfo;
            dtpEduTime.Value = p_objPatient.m_DtmSelectedHISInDate;
            if (objPeopleInfo.m_StrPayTypeName == "自费")
            {
                this.chkSelfPay.Checked = true;
                this.chkInsure.Checked = false;
            }
		}

		private void frmEMR_InPatientEvaluate_Load(object sender, System.EventArgs e)
		{
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
			m_mthfrmLoad();
	
			this.m_dtpRecordTime.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpRecordTime.m_mthResetSize();
			this.dtpEduTime.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpEduTime.m_mthResetSize();

		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			try
			{				
				if(m_ObjCurrentEmrPatientSession != null)
				{		
					clsEMR_InPatientEvaluate_All objclsInPatientEvaluate_All;
					long lngRes=m_objDomain.m_lngGetLatestDeleteRecord_All(strInPatientID,strInPatientDate,p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"),out objclsInPatientEvaluate_All);
					if(lngRes<=0)
					{
						clsPublicFunction.ShowInformationMessageBox("数据错误或数据库连接失败，请与系统管理员联系！");
						return;
					}		
											
					m_objCurrent_clsInPatientEvaluate_All=objclsInPatientEvaluate_All;
					m_dtpRecordTime.Enabled=true;
					dtpEduTime.Enabled=true;
					m_mthSetDelValue(m_objCurrent_clsInPatientEvaluate_All);					
				}
				else 
				{
					m_mthClearUpSheet();
					m_dtpRecordTime.Value=DateTime.Now;
					//dtpEduTime.Value = DateTime.Now;
				}
				
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);
			}
		}

		/// <summary>
		/// 显示被删除记录
		/// </summary>
		/// <param name="p_objclsInPatientEvaluate_All">待显示记录的值</param>
		private void m_mthSetDelValue(clsEMR_InPatientEvaluate_All p_objclsInPatientEvaluate_All)
		{
			if(p_objclsInPatientEvaluate_All ==null || p_objclsInPatientEvaluate_All.m_objclsInPatientEvaluate==null)
				return;

			
			//			m_dtpRecordTime.Enabled=false;
			//			dtpEduTime.Enabled=false;
			 m_mthClearUpSheet();
			#region 显示被删除记录

			clsEMR_InPatientEvaluate objclsInPatientEvaluate=p_objclsInPatientEvaluate_All.m_objclsInPatientEvaluate;
			clsEMR_InPatientHealth_VO objclsInPatientHealth = p_objclsInPatientEvaluate_All.m_objclsInPatientHealth_VO;
			clsEMR_InPatientOutEvaluate_VO objclsInPatientOut = p_objclsInPatientEvaluate_All.m_objInPatientOutEvaluate_VO;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objclsInPatientEvaluate.m_strModifyUserID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign.Tag = objEmpVO;
                m_txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
            }
			
			m_strCurrentOpenDate = objclsInPatientEvaluate.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

			#region 病人历史资料 
			chkInsure.Checked = (objclsInPatientEvaluate.m_strPaymentMethod[0].ToString()=="1"?true:false);
			chkSelfPay.Checked = (objclsInPatientEvaluate.m_strPaymentMethod[1].ToString()=="1"?true:false);
            m_cboEducation.Text = objclsInPatientEvaluate.m_strEducationDegree;
			rdbWalk.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[0].ToString()=="1"?true:false);
			rdbHand.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[1].ToString()=="1"?true:false);
			rdbWheel.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[2].ToString()=="1"?true:false);
			rdbFlat.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[3].ToString()=="1"?true:false);
			rdbBack.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[4].ToString()=="1"?true:false);
			rdbArm.Checked = (objclsInPatientEvaluate.m_strInHospitalMethod[5].ToString()=="1"?true:false);
			m_txtInPatientDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strInHospitalDiagnose,objclsInPatientEvaluate.m_strInHospitalDiagnoseXML);

			
			m_txtCaseHistory.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strCaseHistory,objclsInPatientEvaluate.m_strCaseHistoryXML);
			
			
			m_txtFamilyHistory.Text =com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strFamilyHistory,objclsInPatientEvaluate.m_strFamilyHistoryXML); 
			
			
			m_txtChiefComplain.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strChiefComplain,objclsInPatientEvaluate.m_strChiefComplainXML);
			
			chkSensitive0.Checked = (objclsInPatientEvaluate.m_strSensitiveHistory[0].ToString()=="1"?true:false);
			chkSensitive1.Checked = (objclsInPatientEvaluate.m_strSensitiveHistory[1].ToString()=="1"?true:false);
			chkSensitive2.Checked = (objclsInPatientEvaluate.m_strSensitiveHistory[2].ToString()=="1"?true:false);
			chkSensitive3.Checked = (objclsInPatientEvaluate.m_strSensitiveHistory[3].ToString()=="1"?true:false);
			
			m_txtSensitiveOther.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strSensitiveHistory_Other,objclsInPatientEvaluate.m_strSensitiveHistory_OtherXML);
			
			#endregion

			#region 体格检查
			m_txtTemperature.Text = objclsInPatientEvaluate.m_strBodyTemperature;
			m_txtPulse.Text = objclsInPatientEvaluate.m_strPulse;
			m_txtRhythm.Text = objclsInPatientEvaluate.m_strHeartPhythm;
			m_txtBp_Shink.Text = objclsInPatientEvaluate.m_strBP_Shrink;
			m_txtBp_Extend.Text = objclsInPatientEvaluate.m_strBP_Extend;
			m_txtAvoirdupois.Text = objclsInPatientEvaluate.m_strAvoirdupois;
            m_txtshengao.Text = objclsInPatientEvaluate.m_strShengao;

			chkConsciousness0.Checked = (objclsInPatientEvaluate.m_strConsciousness[0].ToString()=="1"?true:false);
			chkConsciousness1.Checked = (objclsInPatientEvaluate.m_strConsciousness[1].ToString()=="1"?true:false);
			chkConsciousness2.Checked = (objclsInPatientEvaluate.m_strConsciousness[2].ToString()=="1"?true:false);
			chkConsciousness3.Checked = (objclsInPatientEvaluate.m_strConsciousness[3].ToString()=="1"?true:false);
			chkConsciousness4.Checked = (objclsInPatientEvaluate.m_strConsciousness[4].ToString()=="1"?true:false);

			chkComplexion0.Checked = (objclsInPatientEvaluate.m_strComplexion[0].ToString()=="1"?true:false);
			chkComplexion1.Checked = (objclsInPatientEvaluate.m_strComplexion[1].ToString()=="1"?true:false);
			chkComplexion2.Checked = (objclsInPatientEvaluate.m_strComplexion[2].ToString()=="1"?true:false);
			chkComplexion3.Checked = (objclsInPatientEvaluate.m_strComplexion[3].ToString()=="1"?true:false);

			chkPhysique0.Checked = (objclsInPatientEvaluate.m_strPhysique[0].ToString()=="1"?true:false);
			chkPhysique1.Checked = (objclsInPatientEvaluate.m_strPhysique[1].ToString()=="1"?true:false);
			chkPhysique2.Checked = (objclsInPatientEvaluate.m_strPhysique[2].ToString()=="1"?true:false);
			
			m_txtPhysiqueOther.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strPhysique_Other,objclsInPatientEvaluate.m_strPhysique_OtherXML);
			

			chkEmotion0.Checked = (objclsInPatientEvaluate.m_strEmotion[0].ToString()=="1"?true:false);
			chkEmotion1.Checked = (objclsInPatientEvaluate.m_strEmotion[1].ToString()=="1"?true:false);
			chkEmotion2.Checked = (objclsInPatientEvaluate.m_strEmotion[2].ToString()=="1"?true:false);

			chkSkin0.Checked = (objclsInPatientEvaluate.m_strSkin[0].ToString()=="1"?true:false);
			chkSkin1.Checked = (objclsInPatientEvaluate.m_strSkin[1].ToString()=="1"?true:false);
			chkSkin2.Checked = (objclsInPatientEvaluate.m_strSkin[2].ToString()=="1"?true:false);
			chkSkin3.Checked = (objclsInPatientEvaluate.m_strSkin[3].ToString()=="1"?true:false);
			chkSkin4.Checked = (objclsInPatientEvaluate.m_strSkin[4].ToString()=="1"?true:false);
			chkSkin5.Checked = (objclsInPatientEvaluate.m_strSkin[5].ToString()=="1"?true:false);
			chkSkin6.Checked = (objclsInPatientEvaluate.m_strSkin[6].ToString()=="1"?true:false);
			chkSkin7.Checked = (objclsInPatientEvaluate.m_strSkin[7].ToString()=="1"?true:false);
			chkSkin8.Checked = (objclsInPatientEvaluate.m_strSkin[8].ToString()=="1"?true:false);
			m_txtSkinOther.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strSkin_Other,objclsInPatientEvaluate.m_strSkin_OtherXML);
			

			chkLimbsactivity0.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[0].ToString()=="1"?true:false);
			chkLimbsactivity1.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[1].ToString()=="1"?true:false);
			chkLimbsactivity2.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[2].ToString()=="1"?true:false);
			chkLimbsactivity3.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[3].ToString()=="1"?true:false);
			chkLimbsactivity4.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[4].ToString()=="1"?true:false);
			chkLimbsactivity5.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[5].ToString()=="1"?true:false);
			chkLimbsactivity6.Checked = (objclsInPatientEvaluate.m_strLimbsactivity[6].ToString()=="1"?true:false);
			
			m_txtLimbsactivityOther.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strLimbsactivity_Other,objclsInPatientEvaluate.m_strLimbsactivity_OtherXML);
			
			#endregion

			#region 生活状况及自理程度
			chkBiteSup0.Checked = (objclsInPatientEvaluate.m_strBiteSup[0].ToString()=="1"?true:false);
			chkBiteSup1.Checked = (objclsInPatientEvaluate.m_strBiteSup[1].ToString()=="1"?true:false);
			chkBiteSup2.Checked = (objclsInPatientEvaluate.m_strBiteSup[2].ToString()=="1"?true:false);
			chkBiteSup3.Checked = (objclsInPatientEvaluate.m_strBiteSup[3].ToString()=="1"?true:false);
			chkBiteSup4.Checked = (objclsInPatientEvaluate.m_strBiteSup[4].ToString()=="1"?true:false);
			chkBiteSup6.Checked = (objclsInPatientEvaluate.m_strBiteSup[5].ToString()=="1"?true:false);
			chkBiteSup7.Checked = (objclsInPatientEvaluate.m_strBiteSup[6].ToString()=="1"?true:false);
			chkBiteSup8.Checked = (objclsInPatientEvaluate.m_strBiteSup[7].ToString()=="1"?true:false);
			chkBiteSup9.Checked = (objclsInPatientEvaluate.m_strBiteSup[8].ToString()=="1"?true:false);
			chkBiteSup10.Checked = (objclsInPatientEvaluate.m_strBiteSup[9].ToString()=="1"?true:false);

			chkAppetite0.Checked = (objclsInPatientEvaluate.m_strAppetite[0].ToString()=="1"?true:false);
			chkAppetite1.Checked = (objclsInPatientEvaluate.m_strAppetite[1].ToString()=="1"?true:false);
			chkAppetite2.Checked = (objclsInPatientEvaluate.m_strAppetite[2].ToString()=="1"?true:false);
			chkAppetite3.Checked = (objclsInPatientEvaluate.m_strAppetite[3].ToString()=="1"?true:false);
			chkAppetite4.Checked = (objclsInPatientEvaluate.m_strAppetite[4].ToString()=="1"?true:false);
			chkAppetite5.Checked = (objclsInPatientEvaluate.m_strAppetite[5].ToString()=="1"?true:false);

			chkSleep0.Checked = (objclsInPatientEvaluate.m_strSleep[0].ToString()=="1"?true:false);
			chkSleep1.Checked = (objclsInPatientEvaluate.m_strSleep[1].ToString()=="1"?true:false);
			chkSleep2.Checked = (objclsInPatientEvaluate.m_strSleep[2].ToString()=="1"?true:false);
			chkSleep3.Checked = (objclsInPatientEvaluate.m_strSleep[3].ToString()=="1"?true:false);
			chkSleep4.Checked = (objclsInPatientEvaluate.m_strSleep[4].ToString()=="1"?true:false);

			chkStool.Checked = (objclsInPatientEvaluate.m_strStool=="1"?true:false);
			string [] split = objclsInPatientEvaluate.m_strAstriction.Split(new Char [] {'次'},2);
			m_txtAstrictionTimes.Text = split[0];
			m_txtAstrictionDays.Text = split[1];
			string [] split1 = objclsInPatientEvaluate.m_strDiarrhea.Split(new Char [] {'次'},2);
			m_txtDiarrheaTimes.Text = split1[0];
			m_txtDiarrheaDays.Text = split1[1];
			m_txtStoolOther.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strStool_Other,objclsInPatientEvaluate.m_strStool_OtherXML);
			

			chkPee0.Checked = (objclsInPatientEvaluate.m_strPee[0].ToString()=="1"?true:false);
			chkPee1.Checked = (objclsInPatientEvaluate.m_strPee[1].ToString()=="1"?true:false);
			chkPee2.Checked = (objclsInPatientEvaluate.m_strPee[2].ToString()=="1"?true:false);
			chkPee3.Checked = (objclsInPatientEvaluate.m_strPee[3].ToString()=="1"?true:false);
			chkPee4.Checked = (objclsInPatientEvaluate.m_strPee[4].ToString()=="1"?true:false);
			chkPee5.Checked = (objclsInPatientEvaluate.m_strPee[5].ToString()=="1"?true:false);
			chkPee6.Checked = (objclsInPatientEvaluate.m_strPee[6].ToString()=="1"?true:false);
			chkPee7.Checked = (objclsInPatientEvaluate.m_strPee[7].ToString()=="1"?true:false);
			chkPee8.Checked = (objclsInPatientEvaluate.m_strPee[8].ToString()=="1"?true:false);
			chkPee9.Checked = (objclsInPatientEvaluate.m_strPee[9].ToString()=="1"?true:false);

			chkHobby0.Checked  = (objclsInPatientEvaluate.m_strHobby[0].ToString()=="1"?true:false);
			chkHobby1.Checked  = (objclsInPatientEvaluate.m_strHobby[1].ToString()=="1"?true:false);
			chkHobby2.Checked  = (objclsInPatientEvaluate.m_strHobby[2].ToString()=="1"?true:false);
			chkHobby3.Checked  = (objclsInPatientEvaluate.m_strHobby[3].ToString()=="1"?true:false);
			chkHobby4.Checked  = (objclsInPatientEvaluate.m_strHobby[4].ToString()=="1"?true:false);
			
			m_txtHobbyOther.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strHobby_Other,objclsInPatientEvaluate.m_strHobby_OtherXML);
			

			chkSelfSolve0.Checked = (objclsInPatientEvaluate.m_strSelfSolve[0].ToString()=="1"?true:false);
			chkSelfSolve1.Checked = (objclsInPatientEvaluate.m_strSelfSolve[1].ToString()=="1"?true:false);
			chkSelfSolve2.Checked = (objclsInPatientEvaluate.m_strSelfSolve[2].ToString()=="1"?true:false);
			#endregion

			#region 心理社会方面
			chkFeeling0.Checked = (objclsInPatientEvaluate.m_strFeeling[0].ToString()=="1"?true:false);
			chkFeeling1.Checked = (objclsInPatientEvaluate.m_strFeeling[1].ToString()=="1"?true:false);
			chkFeeling2.Checked = (objclsInPatientEvaluate.m_strFeeling[2].ToString()=="1"?true:false);
			chkFeeling3.Checked = (objclsInPatientEvaluate.m_strFeeling[3].ToString()=="1"?true:false);
			chkFeeling4.Checked = (objclsInPatientEvaluate.m_strFeeling[4].ToString()=="1"?true:false);
			chkFeeling5.Checked = (objclsInPatientEvaluate.m_strFeeling[5].ToString()=="1"?true:false);
			chkFeeling6.Checked = (objclsInPatientEvaluate.m_strFeeling[6].ToString()=="1"?true:false);
			chkFeeling7.Checked = (objclsInPatientEvaluate.m_strFeeling[7].ToString()=="1"?true:false);
			chkFeeling8.Checked = (objclsInPatientEvaluate.m_strFeeling[8].ToString()=="1"?true:false);

			chkJob0.Checked = (objclsInPatientEvaluate.m_strJob[0].ToString()=="1"?true:false);
			chkJob1.Checked = (objclsInPatientEvaluate.m_strJob[1].ToString()=="1"?true:false);
			chkJob2.Checked = (objclsInPatientEvaluate.m_strJob[2].ToString()=="1"?true:false);
			chkJob3.Checked = (objclsInPatientEvaluate.m_strJob[3].ToString()=="1"?true:false);
			chkJob4.Checked = (objclsInPatientEvaluate.m_strJob[4].ToString()=="1"?true:false);
			chkJob5.Checked = (objclsInPatientEvaluate.m_strJob[5].ToString()=="1"?true:false);
			chkJob6.Checked = (objclsInPatientEvaluate.m_strJob[6].ToString()=="1"?true:false);

			chkInHospitalWorry0.Checked = (objclsInPatientEvaluate.m_strInHospitalWorry[0].ToString()=="1"?true:false);
			chkInHospitalWorry1.Checked = (objclsInPatientEvaluate.m_strInHospitalWorry[1].ToString()=="1"?true:false);
			chkInHospitalWorry2.Checked = (objclsInPatientEvaluate.m_strInHospitalWorry[2].ToString()=="1"?true:false);
			
			m_txtInHospitalWorryOther.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strInHospitalWorry_Other,objclsInPatientEvaluate.m_strInHospitalWorryXML);
			

			chkFamilyForm0.Checked = (objclsInPatientEvaluate.m_strFamilyForm[0].ToString()=="1"?true:false);
			chkFamilyForm1.Checked = (objclsInPatientEvaluate.m_strFamilyForm[1].ToString()=="1"?true:false);
			chkFamilyForm2.Checked = (objclsInPatientEvaluate.m_strFamilyForm[2].ToString()=="1"?true:false);
			chkFamilyForm3.Checked = (objclsInPatientEvaluate.m_strFamilyForm[3].ToString()=="1"?true:false);
			m_txtFamilyFormOther.Text =	 com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strFamilyForm_Other,objclsInPatientEvaluate.m_strFamilyForm_OtherXML);
			

			chkHealthNeed0.Checked = (objclsInPatientEvaluate.m_strHealthNeed[0].ToString()=="1"?true:false);
			chkHealthNeed1.Checked = (objclsInPatientEvaluate.m_strHealthNeed[1].ToString()=="1"?true:false);
			chkHealthNeed2.Checked = (objclsInPatientEvaluate.m_strHealthNeed[2].ToString()=="1"?true:false);
			chkHealthNeed3.Checked = (objclsInPatientEvaluate.m_strHealthNeed[3].ToString()=="1"?true:false);
			chkHealthNeed4.Checked = (objclsInPatientEvaluate.m_strHealthNeed[4].ToString()=="1"?true:false);

			chkKnowDisease0.Checked = (objclsInPatientEvaluate.m_strKnowDisease[0].ToString()=="1"?true:false);
			chkKnowDisease1.Checked = (objclsInPatientEvaluate.m_strKnowDisease[1].ToString()=="1"?true:false);
			chkKnowDisease2.Checked = (objclsInPatientEvaluate.m_strKnowDisease[2].ToString()=="1"?true:false);
			chkKnowDisease3.Checked = (objclsInPatientEvaluate.m_strKnowDisease[3].ToString()=="1"?true:false);
			#endregion

			#region 检查及计划
			m_txtSpecilizedCheck.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strSpecializedCheck.Replace("&*","?"),objclsInPatientEvaluate.m_strSpecializedCheckXML);


            m_txtPipInstance.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strPipInstance.Replace("&*", "?"), objclsInPatientEvaluate.m_strPipInstanceXML);

            m_txtWoodInstance.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strWoodInstance.Replace("&*", "?"), objclsInPatientEvaluate.m_strWoodInstanceXML);

            m_txtTendPlan.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientEvaluate.m_strTendPlan.Replace("&*", "?"), objclsInPatientEvaluate.m_strTendPlanXML);
			
			#endregion

			#region 病人健康教育评估表
			#region 第一次完成
			ArrayList arrList = new ArrayList();
			m_mthXMLToForm(out arrList,objclsInPatientHealth.m_strHEDU_First);
			m_txtReadOutEdu1.Text = arrList[0].ToString();
			m_txtReadOutNurse1.Text = arrList[1].ToString();
			m_txtReadOutDate1.Text = arrList[2].ToString();
			m_txtExplanEdu1.Text = arrList[3].ToString();
			m_txtExplanNurse1.Text = arrList[4].ToString();
			m_txtExplanDate1.Text = arrList[5].ToString();
			m_txtMedicineEdu1.Text = arrList[6].ToString();
			m_txtMedicineNurse1.Text = arrList[7].ToString();
			m_txtMedicineDate1.Text = arrList[8].ToString();
			m_txtNoticeEdu1.Text = arrList[9].ToString();
			m_txtNoticeNurse1.Text = arrList[10].ToString();
			m_txtNoticeDate1.Text = arrList[11].ToString();
			m_txtKnowledgeEdu1.Text = arrList[12].ToString();
			m_txtKnowledgeNurse1.Text = arrList[13].ToString();
			m_txtKnowledgeDate1.Text = arrList[14].ToString();
			m_txtGuidanceEdu1.Text = arrList[15].ToString();
			m_txtGuidanceNurse1.Text = arrList[16].ToString();
			m_txtGuidanceDate1.Text = arrList[17].ToString();
			m_txtOtherEdu1.Text = arrList[18].ToString();
			m_txtOtherNurse1.Text = arrList[19].ToString();
			m_txtOtherDate1.Text = arrList[20].ToString();
			#endregion

			#region 第二次完成
			ArrayList arrList2 = new ArrayList();
			m_mthXMLToForm(out arrList2,objclsInPatientHealth.m_strHEDU_Second);
			m_txtReadOutEdu2.Text = arrList2[0].ToString();
			m_txtReadOutNurse2.Text = arrList2[1].ToString();
			m_txtReadOutDate2.Text = arrList2[2].ToString();
			m_txtExplanEdu2.Text = arrList2[3].ToString();
			m_txtExplanNurse2.Text = arrList2[4].ToString();
			m_txtExplanDate2.Text = arrList2[5].ToString();
			m_txtMedicineEdu2.Text = arrList2[6].ToString();
			m_txtMedicineNurse2.Text = arrList2[7].ToString();
			m_txtMedicineDate2.Text = arrList2[8].ToString();
			m_txtNoticeEdu2.Text = arrList2[9].ToString();
			m_txtNoticeNurse2.Text = arrList2[10].ToString();
			m_txtNoticeDate2.Text = arrList2[11].ToString();
			m_txtKnowledgeEdu2.Text = arrList2[12].ToString();
			m_txtKnowledgeNurse2.Text = arrList2[13].ToString();
			m_txtKnowledgeDate2.Text = arrList2[14].ToString();
			m_txtGuidanceEdu2.Text = arrList2[15].ToString();
			m_txtGuidanceNurse2.Text = arrList2[16].ToString();
			m_txtGuidanceDate2.Text = arrList2[17].ToString();
			m_txtOtherEdu2.Text = arrList2[18].ToString();
			m_txtOtherNurse2.Text = arrList2[19].ToString();
			m_txtOtherDate2.Text = arrList2[20].ToString();
			#endregion

			#region 第三次完成
			ArrayList arrList3 = new ArrayList();
			m_mthXMLToForm(out arrList3,objclsInPatientHealth.m_strHEDU_Three);
			m_txtReadOutEdu3.Text = arrList3[0].ToString();
			m_txtReadOutNurse3.Text = arrList3[1].ToString();
			m_txtReadOutDate3.Text = arrList3[2].ToString();
			m_txtExplanEdu3.Text = arrList3[3].ToString();
			m_txtExplanNurse3.Text = arrList3[4].ToString();
			m_txtExplanDate3.Text = arrList3[5].ToString();
			m_txtMedicineEdu3.Text = arrList3[6].ToString();
			m_txtMedicineNurse3.Text = arrList3[7].ToString();
			m_txtMedicineDate3.Text = arrList3[8].ToString();
			m_txtNoticeEdu3.Text = arrList3[9].ToString();
			m_txtNoticeNurse3.Text = arrList3[10].ToString();
			m_txtNoticeDate3.Text = arrList3[11].ToString();
			m_txtKnowledgeEdu3.Text = arrList3[12].ToString();
			m_txtKnowledgeNurse3.Text = arrList3[13].ToString();
			m_txtKnowledgeDate3.Text = arrList3[14].ToString();
			m_txtGuidanceEdu3.Text = arrList3[15].ToString();
			m_txtGuidanceNurse3.Text = arrList3[16].ToString();
			m_txtGuidanceDate3.Text = arrList3[17].ToString();
			m_txtOtherEdu3.Text = arrList3[18].ToString();
			m_txtOtherNurse3.Text = arrList3[19].ToString();
			m_txtOtherDate3.Text = arrList3[20].ToString();
			#endregion

			dtpEduTime.Value = m_dtpRecordTime.Value;

			#endregion

			#region 病人出院评估及指导
			m_txtOutHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientOut.m_strOutHospitalDiagnose,objclsInPatientOut.m_strOutHospitalDiagnoseXML);
			

			chkLiveAbility0.Checked = (objclsInPatientOut.m_strLiveAbility[0].ToString()=="1"?true:false);
			chkLiveAbility1.Checked = (objclsInPatientOut.m_strLiveAbility[1].ToString()=="1"?true:false);
			chkLiveAbility2.Checked = (objclsInPatientOut.m_strLiveAbility[2].ToString()=="1"?true:false);

			chkDieteticCircs0.Checked = (objclsInPatientOut.m_strDieteticCircs[0].ToString()=="1"?true:false);
			chkDieteticCircs1.Checked = (objclsInPatientOut.m_strDieteticCircs[1].ToString()=="1"?true:false);
			chkDieteticCircs2.Checked = (objclsInPatientOut.m_strDieteticCircs[2].ToString()=="1"?true:false);
			chkDieteticCircs3.Checked = (objclsInPatientOut.m_strDieteticCircs[3].ToString()=="1"?true:false);
			chkDieteticCircs4.Checked = (objclsInPatientOut.m_strDieteticCircs[4].ToString()=="1"?true:false);
			chkDieteticCircs5.Checked = (objclsInPatientOut.m_strDieteticCircs[5].ToString()=="1"?true:false);
			chkDieteticCircs6.Checked = (objclsInPatientOut.m_strDieteticCircs[6].ToString()=="1"?true:false);

			chkOutHospitalMode0.Checked = (objclsInPatientOut.m_strOutHospitalMode[0].ToString()=="1"?true:false);
			chkOutHospitalMode1.Checked = (objclsInPatientOut.m_strOutHospitalMode[1].ToString()=="1"?true:false);
			chkOutHospitalMode2.Checked = (objclsInPatientOut.m_strOutHospitalMode[2].ToString()=="1"?true:false);
			chkOutHospitalMode3.Checked = (objclsInPatientOut.m_strOutHospitalMode[3].ToString()=="1"?true:false);
			chkOutHospitalMode4.Checked = (objclsInPatientOut.m_strOutHospitalMode[4].ToString()=="1"?true:false);

			chkNurseSyndrome0.Checked = (objclsInPatientOut.m_strIsNurseSyndrome[0].ToString()=="1"?true:false);
			chkNurseSyndrome1.Checked = (objclsInPatientOut.m_strIsNurseSyndrome[1].ToString()=="1"?true:false);
			
			m_txtNurseSyndrome.Text =   com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientOut.m_strNurseSyndrome,objclsInPatientOut.m_strNurseSyndromeXML);
			

			chkNurseIssue0.Checked = (objclsInPatientOut.m_strIsNurseIssue[0].ToString()=="1"?true:false);
			chkNurseIssue1.Checked = (objclsInPatientOut.m_strIsNurseIssue[1].ToString()=="1"?true:false);
			
			m_txtNurseIssue.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientOut.m_strNurseIssue,objclsInPatientOut.m_strNurseIssueXML);
			

			chkCommonlyCoach0.Checked = (objclsInPatientOut.m_strCommonlyCoach[0].ToString()=="1"?true:false);
			chkCommonlyCoach1.Checked = (objclsInPatientOut.m_strCommonlyCoach[1].ToString()=="1"?true:false);
			chkCommonlyCoach2.Checked = (objclsInPatientOut.m_strCommonlyCoach[2].ToString()=="1"?true:false);
			chkCommonlyCoach3.Checked = (objclsInPatientOut.m_strCommonlyCoach[3].ToString()=="1"?true:false);
			chkCommonlyCoach4.Checked = (objclsInPatientOut.m_strCommonlyCoach[4].ToString()=="1"?true:false);
			chkCommonlyCoach5.Checked = (objclsInPatientOut.m_strCommonlyCoach[5].ToString()=="1"?true:false);
			chkCommonlyCoach6.Checked = (objclsInPatientOut.m_strCommonlyCoach[6].ToString()=="1"?true:false);
			chkCommonlyCoach7.Checked = (objclsInPatientOut.m_strCommonlyCoach[7].ToString()=="1"?true:false);

			chkAdviceDrug0.Checked = (objclsInPatientOut.m_strAdviceDrug[0].ToString()=="1"?true:false);
			chkAdviceDrug1.Checked = (objclsInPatientOut.m_strAdviceDrug[1].ToString()=="1"?true:false);
			chkAdviceDrug2.Checked = (objclsInPatientOut.m_strAdviceDrug[2].ToString()=="1"?true:false);
			chkAdviceDrug3.Checked = (objclsInPatientOut.m_strAdviceDrug[3].ToString()=="1"?true:false);

			chkSpecialtiesCoach0.Checked = (objclsInPatientOut.m_strIsSpecialtiesCoach[0].ToString()=="1"?true:false);
			chkSpecialtiesCoach1.Checked = (objclsInPatientOut.m_strIsSpecialtiesCoach[1].ToString()=="1"?true:false);
			
			m_txtSpecialtiesCoach.Text  = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objclsInPatientOut.m_strSpecialtiesCoach,objclsInPatientOut.m_strSpecialtiesCoachXML);
            
            objEmployeeSign.m_lngGetEmpByNO(objclsInPatientOut.m_strNurseSign_ID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtNurseSign.Tag = objEmpVO;
                m_txtNurseSign.Text = objEmpVO.m_strLASTNAME_VCHR;
            }

            objEmployeeSign.m_lngGetEmpByNO(objclsInPatientOut.m_strChargeNurse_ID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtChargeNurse.Tag = objEmpVO;
                m_txtChargeNurse.Text = objEmpVO.m_strLASTNAME_VCHR;
            }
          //  this.lblInHospitalDays.Text = ((m_objIPO.m_dtmOpenDate - m_objIPO.m_dtmInPatientDate).Days + 1).ToString();
            this.lblInHospitalDays.Text = ((objclsInPatientOut.m_dtmOpenDate - objclsInPatientOut.m_dtmInPatientDate).Days + 1).ToString();
			#endregion
			m_mthSetRichTextModifyColor(this,Color.Red);
			m_mthSetRichTextCanModifyLast(this,true);
			#endregion
		}

		private void tabPage4_Click(object sender, System.EventArgs e)
		{
		
		}

		#region 病人健康教育评估表ToXML
		private string m_StrFormToXML(ArrayList arrL,string strTims)
		{
			if(arrL.Count != 21)
				return null;

			m_objXmlWriter.Flush();
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement(strTims);
			m_objXmlWriter.WriteStartElement("READOUT");
			m_objXmlWriter.WriteElementString("eduitem",arrL[0].ToString());
			m_objXmlWriter.WriteElementString("nursesign",arrL[1].ToString());
			m_objXmlWriter.WriteElementString("date",arrL[2].ToString());		
			m_objXmlWriter.WriteEndElement();
		
			m_objXmlWriter.WriteStartElement("EXPLAIN");
			m_objXmlWriter.WriteElementString("eduitem",arrL[3].ToString());
			m_objXmlWriter.WriteElementString("nursesign",arrL[4].ToString());
			m_objXmlWriter.WriteElementString("date",arrL[5].ToString());		
			m_objXmlWriter.WriteEndElement();
		
			m_objXmlWriter.WriteStartElement("MEDICINE");
			m_objXmlWriter.WriteElementString("eduitem",arrL[6].ToString());
			m_objXmlWriter.WriteElementString("nursesign",arrL[7].ToString());
			m_objXmlWriter.WriteElementString("date",arrL[8].ToString());		
			m_objXmlWriter.WriteEndElement();
		
			m_objXmlWriter.WriteStartElement("NOTICE");
			m_objXmlWriter.WriteElementString("eduitem",arrL[9].ToString());
			m_objXmlWriter.WriteElementString("nursesign",arrL[10].ToString());
			m_objXmlWriter.WriteElementString("date",arrL[11].ToString());		
			m_objXmlWriter.WriteEndElement();
		
			m_objXmlWriter.WriteStartElement("KNOWLEDGE");
			m_objXmlWriter.WriteElementString("eduitem",arrL[12].ToString());
			m_objXmlWriter.WriteElementString("nursesign",arrL[13].ToString());
			m_objXmlWriter.WriteElementString("date",arrL[14].ToString());		
			m_objXmlWriter.WriteEndElement();
		
			m_objXmlWriter.WriteStartElement("GUIDANCE");
			m_objXmlWriter.WriteElementString("eduitem",arrL[15].ToString());
			m_objXmlWriter.WriteElementString("nursesign",arrL[16].ToString());
			m_objXmlWriter.WriteElementString("date",arrL[17].ToString());		
			m_objXmlWriter.WriteEndElement();
		
			m_objXmlWriter.WriteStartElement("OTHER");
			m_objXmlWriter.WriteElementString("eduitem",arrL[18].ToString());
			m_objXmlWriter.WriteElementString("nursesign",arrL[19].ToString());
			m_objXmlWriter.WriteElementString("date",arrL[20].ToString());		
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();
		
			string str = System.Text.Encoding.Default.GetString(m_objXmlMemStream.ToArray(),39,(int)m_objXmlMemStream.Length-39);
//			m_objXmlWriter.Close();
			return str;
		}
		#endregion

		#region XMLTo病人健康教育评估表
		private void m_mthXMLToForm(out ArrayList arrL,string strDate)
		{
			XmlTextReader objReader = new XmlTextReader(strDate,XmlNodeType.Element,m_objXmlParser);
			arrL = new ArrayList();

			while (objReader.Read())
			{
				if (objReader.IsStartElement())
				{
					if (objReader.IsEmptyElement)
						arrL.Add("");
//						break;
					else
					{
						if(objReader.Name == "eduitem")
							arrL.Add(objReader.ReadString());
						if(objReader.Name == "nursesign")
							arrL.Add(objReader.ReadString());
						if(objReader.Name == "date")
							arrL.Add(objReader.ReadString());
					}
				}
			}
		}
		#endregion

		private void chkLimbsactivity1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.chkLimbsactivity2.Enabled = this.chkLimbsactivity3.Enabled = this.chkLimbsactivity4.Enabled = this.chkLimbsactivity1.Checked;
			if(this.chkLimbsactivity1.Checked == false)
				this.chkLimbsactivity2.Checked = this.chkLimbsactivity3.Checked = this.chkLimbsactivity4.Checked = false;
		}


		private void chkNurseSyndrome1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.chkNurseSyndrome0.Checked = !this.chkNurseSyndrome1.Checked;
			this.m_txtNurseSyndrome.Enabled = this.chkNurseSyndrome1.Checked;
			if(this.chkNurseSyndrome1.Checked == false)
				this.m_txtNurseSyndrome.Text = "";
		}

		private void chkNurseIssue1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.chkNurseIssue0.Checked = !this.chkNurseIssue1.Checked;
			this.m_txtNurseIssue.Enabled = this.chkNurseIssue1.Checked;
			if(this.chkNurseIssue1.Checked == false)
				this.m_txtNurseIssue.Text = "";
		}

		private void chkSpecialtiesCoach1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.chkSpecialtiesCoach0.Checked = !this.chkSpecialtiesCoach1.Checked;
			this.m_txtSpecialtiesCoach.Enabled = this.chkSpecialtiesCoach1.Checked;
			if(this.chkSpecialtiesCoach1.Checked == false)
				this.m_txtSpecialtiesCoach.Text = "";
		}
	 
		/// <summary>
		/// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
		/// </summary>
		/// <param name="p_objRichTextBox"></param>
		protected void m_mthSetRichTextBoxAttrib(com.digitalwave.controls.ctlRichTextBox p_objRichTextBox)
		{
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_objRichTextBox });
			//设置右键菜单			
			//			p_objRichTextBox.ContextMenu=m_cmuRichTextBoxMenu;
			p_objRichTextBox.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);
			
			//设置其他属性			
			p_objRichTextBox.m_StrUserID = MDIParent.strOperatorID;
			p_objRichTextBox.m_StrUserName = MDIParent.strOperatorName;
			p_objRichTextBox.m_ClrOldPartInsertText = Color.Black;
			p_objRichTextBox.m_ClrDST = Color.Red;
		}

		protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
		{
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
				m_mthSetRichTextBoxAttrib((com.digitalwave.controls.ctlRichTextBox)p_ctlControl);
			}

			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextBoxAttribInControl(subcontrol);						
				} 	
			}
		}

		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>		
		private void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor )
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{				
				foreach(Control subcontrol in p_ctlControl.Controls)
				{							
					m_mthSetRichTextModifyColor(subcontrol,p_clrColor);					
				} 	
			}			
			#endregion
		}
		private void m_mthSetRichTextCanModifyLast(Control p_ctlControl,bool p_blnCanModifyLast )
		{
			#region 设置控件输入文本的是否最后修改,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{				
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}

		

		private com.digitalwave.controls.ctlRichTextBox m_txtFocusedRichTextBox=null;//存放当前获得焦点的RichTextBox
		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox=((com.digitalwave.controls.ctlRichTextBox)(sender));
		}

		#region 打印

		PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();

		private void m_mthPrintEnd(Object sender,System.Drawing.Printing.PrintEventArgs e)
		{
			m_objDomain.m_lngUpdateFirstPrintDate(strInPatientID,strInPatientDate);
		}


		private void m_mthfrmLoad()
		{	
			this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		
		}
		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
            objPrintTool.m_mthPrintPage(e);

            if (ppdPrintPreview != null)
                while (!ppdPrintPreview.m_blnHandlePrint(e))
                    objPrintTool.m_mthPrintPage(e);
        
		}
		
		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
            objPrintTool.m_mthBeginPrint(e);		
		}
		
		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
            objPrintTool.m_mthEndPrint(e);
		}
		
		
		private void m_mthDemoPrint_FromDataSource()
		{	
            objPrintTool = new clsEMR_InPatientEvaluatePrintTool();
            objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);

            objPrintTool.m_mthInitPrintContent();
            
            m_mthStartPrint();
		}
				
		private void m_mthStartPrint()
		{
            if (m_blnDirectPrint)
            {
                objPrintTool.m_BlnPreview = false;
                objPrintTool.m_BlnIsDummy = false;
                m_pdcPrintDocument.Print();
                //if (clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strPromptForPrint, MessageBoxButtons.OKCancel) == DialogResult.OK)
                //{
                //    objPrintTool.m_BlnIsDummy = true;
                //    m_pdcPrintDocument.Print();
                //}
            }
            else
            {
                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog();
            }
		}
				
		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
		{					
			m_mthDemoPrint_FromDataSource();					
			return 1;
		}
		#endregion

		private void chkSpecialtiesCoach0_CheckedChanged(object sender, System.EventArgs e)
		{
			this.chkSpecialtiesCoach1.Checked = !this.chkSpecialtiesCoach0.Checked;
		}

		private void chkNurseIssue0_CheckedChanged(object sender, System.EventArgs e)
		{
		   this.chkNurseIssue1.Checked = !this.chkNurseIssue0.Checked;
		}

		private void chkNurseSyndrome0_CheckedChanged(object sender, System.EventArgs e)
		{
		   this.chkNurseSyndrome1.Checked = !this.chkNurseSyndrome0.Checked;
		}

		#region 病人健康教育评估表右键菜单
		private void InitializeCnmEdu ( ) 
		{
			MenuItem [ ] mnuItms = new MenuItem [ 5] ;

			mnuItms [ 0 ] = new MenuItem ( ) ;
　			mnuItms [ 0 ] .Text = "剪切(&T)" ;
　			mnuItms [ 0 ] .Click += new System.EventHandler(this.m_mthCut) ;

			mnuItms [ 1 ] = new MenuItem ( ) ;
　			mnuItms [ 1 ] .Text = "复制(&C)" ;
　			mnuItms [ 1 ] .Click += new System.EventHandler(this.m_mthCopy) ;

			mnuItms [ 2 ] = new MenuItem ( ) ;
　			mnuItms [ 2 ] .Text = "粘贴(&P)" ;
　			mnuItms [ 2 ] .Click += new System.EventHandler(this.m_mthPaste) ;

			mnuItms [ 3 ] = new MenuItem ( "-" ) ;

			mnuItms [ 4 ] = new MenuItem ( ) ;
　			mnuItms [ 4 ] .Text = "特殊符号" ;
　			mnuItms [ 4 ] .Click += new System.EventHandler(this.m_mthInvokeSpecialSymbol) ;

			cnmEduMnu = new ContextMenu(mnuItms);
			 
			foreach(Control ctlControl in tabPage4.Controls)
			{
				string strTypeName = ctlControl.GetType().FullName;
				if(strTypeName == "com.digitalwave.Utility.Controls.ctlBorderTextBox")
				{
					ctlControl.ContextMenu = cnmEduMnu;
				}
			}
		}

		private void m_mthCut( object sender , System.EventArgs e )
		{
			m_lngCut();
		}

		private void m_mthCopy( object sender , System.EventArgs e )
		{
			m_lngCopy();
		}

		private void m_mthPaste( object sender , System.EventArgs e )
		{
			m_lngPaste();
		}

		/// <summary>
		/// 调用特殊符号
		/// </summary>
		private void m_mthInvokeSpecialSymbol(object sender,EventArgs e)
		{
			string strContent = "";
			try
			{
				using(iCare.AssitantTool.frmSpecialSymbolList frmSpecialSymbolList = new AssitantTool.frmSpecialSymbolList())
				{
					frmSpecialSymbolList.ShowDialog();
					strContent = frmSpecialSymbolList.m_StrOutputSpectialSymbol;
					if (strContent == null)
						strContent = "";
				}
			}
			catch
			{
				strContent = "";
			}
	
			this.ActiveControl.Text = strContent;
		}
		
		/// <summary>
		/// 在当前文本框插入值
		/// </summary>
		/// <param name="p_strText"></param>
//		private void m_mthInertText(string p_strText)
//		{
//			switch(m_txtRichTextBox.GetType().FullName)
//			{
//				case "com.digitalwave.Utility.Controls.ctlRichTextBox" :
//					((ctlRichTextBox)m_txtRichTextBox).m_mthInsertText(p_strText,m_txtRichTextBox.SelectionStart);
//					break;
//				case "com.digitalwave.controls.ctlRichTextBox" :
//					((com.digitalwave.controls.ctlRichTextBox)m_txtRichTextBox).m_mthInsertText(p_strText,m_txtRichTextBox.SelectionStart);
//					break;
//				default :
//					int intPreStart = m_txtRichTextBox.SelectionStart;
//					m_txtRichTextBox.Text = m_txtRichTextBox.Text.Insert(m_txtRichTextBox.SelectionStart,p_strText);
//					m_txtRichTextBox.SelectionStart = intPreStart + p_strText.Length;
//					break;
//			}
//		}
		#endregion

		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump = new clsJumpControl(this,
				new Control[]{rdbWalk,rdbHand,rdbWheel,rdbFlat,rdbBack,rdbArm,chkInsure,chkSelfPay,m_txtInPatientDiagnose,m_txtCaseHistory,m_txtFamilyHistory,m_txtChiefComplain,
							chkSensitive0,chkSensitive1,chkSensitive2,chkSensitive3,m_txtSensitiveOther,m_txtTemperature,m_txtPulse,m_txtRhythm,m_txtBp_Shink,m_txtBp_Extend,m_txtAvoirdupois,m_txtshengao,
							chkConsciousness0,chkConsciousness1,chkConsciousness2,chkConsciousness3,chkConsciousness4,chkComplexion0,chkComplexion1,chkComplexion2,chkComplexion3,chkPhysique0,
							chkPhysique1,chkPhysique2,m_txtPhysiqueOther,chkEmotion0,chkEmotion1,chkEmotion2,chkSkin0,chkSkin1,chkSkin2,chkSkin3,chkSkin4,chkSkin5,chkSkin6,chkSkin7,chkSkin8,
							m_txtSkinOther,chkLimbsactivity0,chkLimbsactivity1,chkLimbsactivity2,chkLimbsactivity3,chkLimbsactivity4,chkLimbsactivity5,chkLimbsactivity6,m_txtLimbsactivityOther,
							tabPage2,chkBiteSup0,chkBiteSup1,chkBiteSup2,chkBiteSup3,chkBiteSup4,chkBiteSup6,chkBiteSup7,chkBiteSup8,chkBiteSup9,chkBiteSup10,chkAppetite0,chkAppetite1,chkAppetite2,
							chkAppetite3,chkAppetite4,chkAppetite5,chkSleep0,chkSleep1,chkSleep2,chkSleep3,chkSleep4,chkStool,m_txtAstrictionTimes,m_txtAstrictionDays,m_txtDiarrheaTimes,m_txtDiarrheaDays,
							m_txtStoolOther,chkPee0,chkPee1,chkPee2,chkPee3,chkPee4,chkPee5,chkPee6,chkPee7,chkPee8,chkPee9,chkHobby0,chkHobby1,chkHobby2,chkHobby3,chkHobby4,m_txtHobbyOther,
							chkSelfSolve0,chkSelfSolve1,chkSelfSolve2,chkFeeling0,chkFeeling1,chkFeeling2,chkFeeling3,chkFeeling4,chkFeeling5,chkFeeling6,chkFeeling7,chkFeeling8,chkJob0,chkJob1,
							chkJob2,chkJob3,chkJob4,chkJob5,chkJob6,chkInHospitalWorry0,chkInHospitalWorry1,chkInHospitalWorry2,m_txtInHospitalWorryOther,chkFamilyForm0,chkFamilyForm1,chkFamilyForm2,
							chkFamilyForm3,m_txtFamilyFormOther,tabPage3,chkHealthNeed0,chkHealthNeed1,chkHealthNeed2,chkHealthNeed3,chkHealthNeed4,chkKnowDisease0,chkKnowDisease1,chkKnowDisease2,
							chkKnowDisease3,m_txtSpecilizedCheck,m_txtPipInstance,m_txtWoodInstance,m_txtTendPlan,tabPage4,m_txtReadOutEdu1,m_txtReadOutNurse1, m_txtReadOutDate1,m_txtExplanEdu1,
							m_txtExplanNurse1, m_txtExplanDate1,m_txtMedicineEdu1,m_txtMedicineNurse1, m_txtMedicineDate1,m_txtNoticeEdu1,m_txtNoticeNurse1, m_txtNoticeDate1,
							m_txtKnowledgeEdu1,m_txtKnowledgeNurse1, m_txtKnowledgeDate1,m_txtGuidanceEdu1,m_txtGuidanceNurse1, m_txtGuidanceDate1,m_txtOtherEdu1,m_txtOtherNurse1, m_txtOtherDate1,
							m_txtReadOutEdu2,m_txtReadOutNurse2, m_txtReadOutDate2,m_txtExplanEdu2, m_txtExplanNurse2, m_txtExplanDate2,m_txtMedicineEdu2,m_txtMedicineNurse2, m_txtMedicineDate2,
							m_txtNoticeEdu2,m_txtNoticeNurse2, m_txtNoticeDate2,m_txtKnowledgeEdu2,m_txtKnowledgeNurse2, m_txtKnowledgeDate2,m_txtGuidanceEdu2,m_txtGuidanceNurse2, 
							m_txtGuidanceDate2,m_txtOtherEdu2,m_txtOtherNurse2, m_txtOtherDate2,m_txtReadOutEdu3,m_txtReadOutNurse3, m_txtReadOutDate3,m_txtExplanEdu3, 
							m_txtExplanNurse3, m_txtExplanDate3,m_txtMedicineEdu3,m_txtMedicineNurse3, m_txtMedicineDate3,m_txtNoticeEdu3,m_txtNoticeNurse3, m_txtNoticeDate3,
							m_txtKnowledgeEdu3,m_txtKnowledgeNurse3, m_txtKnowledgeDate3,m_txtGuidanceEdu3,m_txtGuidanceNurse3, m_txtGuidanceDate3,m_txtOtherEdu3,m_txtOtherNurse3,
							 m_txtOtherDate3,tabPage5,m_txtOutHospitalDiagnose,chkLiveAbility0,chkLiveAbility1,chkLiveAbility2,chkDieteticCircs0,chkDieteticCircs1,chkDieteticCircs2,
							chkDieteticCircs3,chkDieteticCircs4,chkDieteticCircs5,chkDieteticCircs6,chkOutHospitalMode0,chkOutHospitalMode1,chkOutHospitalMode2,chkOutHospitalMode3,chkOutHospitalMode4,
							chkNurseSyndrome0,chkNurseSyndrome1,m_txtNurseSyndrome,chkNurseIssue0,chkNurseIssue1,m_txtNurseIssue,chkCommonlyCoach0,chkCommonlyCoach1,chkCommonlyCoach2,chkCommonlyCoach3,
							chkCommonlyCoach4,chkCommonlyCoach5,chkCommonlyCoach6,chkCommonlyCoach7,chkAdviceDrug0,chkAdviceDrug1,chkAdviceDrug2,chkAdviceDrug3,chkSpecialtiesCoach0,chkSpecialtiesCoach1,
							m_txtSpecialtiesCoach},Keys.Enter);
			p_objJump.m_BlnCanCycle = false;
		}



		#endregion

        private void m_txtGetEmployeeNmae_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(((com.digitalwave.Utility.Controls.ctlBorderTextBox)sender).Text))
                    return;

                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(((com.digitalwave.Utility.Controls.ctlBorderTextBox)sender).Text, out objEmpVO);
                if (objEmpVO != null)
                {
                    ((com.digitalwave.Utility.Controls.ctlBorderTextBox)sender).Tag = objEmpVO;
                    ((com.digitalwave.Utility.Controls.ctlBorderTextBox)sender).Text = objEmpVO.m_strLASTNAME_VCHR;
                }
                else
                {
                    clsPublicFunction.ShowInformationMessageBox("不存在此工号！");
                }
            }
        }
    

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            try
            {
                if (m_dtpRecordTime == null)
                    return;

                m_mthRecordChangedToSave();

                m_dtpRecordTime.Enabled = false;
                dtpEduTime.Enabled = true;

                if (p_objSelectedSession != null)
                {
                    strInPatientDate = p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");

                    m_mthClearUpSheet();
                    m_mthSetUnEdit(true);
                    clsEMR_InPatientEvaluate_All objclsInPatientEvaluate_All;

                    m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                    m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                    m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
                    strInPatientID = p_objSelectedSession.m_strEMRInpatientId;

                    //设置病人当次住院的基本信息
                    m_mthOnlySetPatientInfo(m_objCurrentPatient);

                    m_mthIsReadOnly();

                    if (!m_blnCanShowRecordContent())
                    {
                        clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                        return;
                    }

                    string strSelectedInTime = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                    long lngRes = m_objDomain.m_lngGetLatestRecord_All(strInPatientID, strSelectedInTime, out objclsInPatientEvaluate_All);
                    if (lngRes <= 0)
                    {
                        clsPublicFunction.ShowInformationMessageBox("数据错误或数据库连接失败，请与系统管理员联系！");
                        return;
                    }
                    else if (lngRes > 0 && (objclsInPatientEvaluate_All == null || objclsInPatientEvaluate_All.m_objclsInPatientEvaluate == null))
                    {
                        if (m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate > m_objCurrentPatient.m_DtmSelectedInDate)
                        {
                            m_objCurrent_clsInPatientEvaluate_All = null;
                            m_mthSetControlReadOnly(this, true);
                            m_mthAddFormStatusForClosingSave();
                            //当前处于禁止输入状态
                            MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
                            return;
                        }
                        else
                        {
                            m_dtpRecordTime.Enabled = true;
                            dtpEduTime.Enabled = true;
                            m_mthClearUpSheet();
                            m_blnFormReadOnly = false;
                            m_mthSetControlReadOnly(this, m_blnFormReadOnly);
                            m_mthSetRichTextModifyColor(this, clsHRPColor.s_ClrInputFore);
                            m_mthSetRichTextCanModifyLast(this, true);
                            m_objCurrent_clsInPatientEvaluate_All = null;

                            m_mthSetDefaultValue(m_objCurrentPatient);

                            //int m_intSessionIndex = m_trvTime.Nodes[0].Nodes.Count - (m_trvTime.SelectedNode.Index);
                            //clsInBedSessionInfo m_objSession = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_intSessionIndex - 1);
                            if (p_objSelectedSession.m_dtmOutDate == DateTime.Parse("1900-01-01 00:00:00") || p_objSelectedSession.m_dtmOutDate == DateTime.MinValue)
                            {
                                this.lblInHospitalDays.Text = ((DateTime.Now - p_objSelectedSession.m_dtmHISInpatientDate).Days + 1).ToString();

                                //this.lblInHospitalDays.Text = ((m_objIPO.m_dtmOpenDate - m_objIPO.m_dtmInPatientDate).Days + 1).ToString();
                            }
                            else
                            {
                                this.lblInHospitalDays.Text = ((p_objSelectedSession.m_dtmOutDate - p_objSelectedSession.m_dtmHISInpatientDate).Days + 1).ToString();


                                //this.lblInHospitalDays.Text = ((m_objIPO.m_dtmOpenDate - m_objIPO.m_dtmInPatientDate).Days + 1).ToString();
                            }

                            //当前处于新增记录状态
                            MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);

                            m_mthAddFormStatusForClosingSave();

                            return;//当前为空记录，进入添加记录状态
                        }
                    }

                    m_objCurrent_clsInPatientEvaluate_All = objclsInPatientEvaluate_All;
                    m_mthSetNewValue(m_objCurrent_clsInPatientEvaluate_All);

                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);

                    m_mthAddFormStatusForClosingSave();

                    if (strInPatientDate != p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"))
                        m_blnFormReadOnly = true;
                    else m_blnFormReadOnly = false;
                }
                else
                {
                    m_mthClearUpSheet();
                    m_mthSetUnEdit(false);
                    m_dtpRecordTime.Value = DateTime.Now;
                   // dtpEduTime.Value = DateTime.Now;

                    //当前处于禁止输入状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);

                    m_mthAddFormStatusForClosingSave();
                }
                //				m_mthSetControlReadOnly(this,m_blnFormReadOnly);

            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message);
            }
        }
        private void dtpNurseSignDate11_evtValueChanged(object sender, EventArgs e)
        {
            m_txtReadOutDate1.Text = dtpNurseSignDate11.Value.ToString("yyyy-M-d");
        }

        private void dtpNurseSignDate12_evtValueChanged(object sender, EventArgs e)
        {
            m_txtReadOutDate2.Text = dtpNurseSignDate12.Value.ToString("yyyy-M-d");
        }

        private void dtpNurseSignDate13_evtValueChanged(object sender, EventArgs e)
        {
            m_txtReadOutDate3.Text = dtpNurseSignDate13.Value.ToString("yyyy-M-d");
        }

        private void dtpNurseSignDate21_evtValueChanged(object sender, EventArgs e)
        {
            m_txtExplanDate1.Text = dtpNurseSignDate21.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate22_evtValueChanged(object sender, EventArgs e)
        {
            m_txtExplanDate2.Text = dtpNurseSignDate22.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate23_evtValueChanged(object sender, EventArgs e)
        {
            m_txtExplanDate3.Text = dtpNurseSignDate23.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate31_evtValueChanged(object sender, EventArgs e)
        {
            m_txtMedicineDate1.Text = dtpNurseSignDate31.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate32_evtValueChanged(object sender, EventArgs e)
        {
            m_txtMedicineDate2.Text = dtpNurseSignDate32.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate33_evtValueChanged(object sender, EventArgs e)
        {
            m_txtMedicineDate3.Text = dtpNurseSignDate33.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate41_evtValueChanged(object sender, EventArgs e)
        {
            m_txtNoticeDate1.Text = dtpNurseSignDate41.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate42_evtValueChanged(object sender, EventArgs e)
        {
            m_txtNoticeDate2.Text = dtpNurseSignDate42.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate43_evtValueChanged(object sender, EventArgs e)
        {
            m_txtNoticeDate3.Text = dtpNurseSignDate43.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate51_evtValueChanged(object sender, EventArgs e)
        {
            m_txtKnowledgeDate1.Text = dtpNurseSignDate51.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate52_evtValueChanged(object sender, EventArgs e)
        {
            m_txtKnowledgeDate2.Text = dtpNurseSignDate52.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate53_evtValueChanged(object sender, EventArgs e)
        {
            m_txtKnowledgeDate3.Text = dtpNurseSignDate53.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate61_evtValueChanged(object sender, EventArgs e)
        {
            m_txtGuidanceDate1.Text = dtpNurseSignDate61.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate62_evtValueChanged(object sender, EventArgs e)
        {
            m_txtGuidanceDate2.Text = dtpNurseSignDate62.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate63_evtValueChanged(object sender, EventArgs e)
        {
            m_txtGuidanceDate3.Text = dtpNurseSignDate63.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate71_evtValueChanged(object sender, EventArgs e)
        {
            m_txtOtherDate1.Text = dtpNurseSignDate71.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate72_evtValueChanged(object sender, EventArgs e)
        {
            m_txtOtherDate2.Text = dtpNurseSignDate72.Value.ToString("yyyy-M-d");
        }
        private void dtpNurseSignDate73_evtValueChanged(object sender, EventArgs e)
        {
            m_txtOtherDate3.Text = dtpNurseSignDate73.Value.ToString("yyyy-M-d");
        }
        //1
        private void m_txtReadOutDate1_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutDate1.Text.Trim() == "")
                m_txtReadOutDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtReadOutDate2_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutDate2.Text.Trim() == "")
                m_txtReadOutDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtReadOutDate3_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutDate3.Text.Trim() == "")
                m_txtReadOutDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //2
        private void m_txtExplanDate1_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanDate1.Text.Trim() == "")
                m_txtExplanDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtExplanDate2_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanDate2.Text.Trim() == "")
                m_txtExplanDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtExplanDate3_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanDate3.Text.Trim() == "")
                m_txtExplanDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //3
        private void m_txtMedicineDate1_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineDate1.Text.Trim() == "")
                m_txtMedicineDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtMedicineDate2_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineDate2.Text.Trim() == "")
                m_txtMedicineDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtMedicineDate3_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineDate3.Text.Trim() == "")
                m_txtMedicineDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //4
        private void m_txtNoticeDate1_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeDate1.Text.Trim() == "")
                m_txtNoticeDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtNoticeDate2_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeDate2.Text.Trim() == "")
                m_txtNoticeDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtNoticeDate3_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeDate3.Text.Trim() == "")
                m_txtNoticeDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //5
        private void m_txtKnowledgeDate1_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeDate1.Text.Trim() == "")
                m_txtKnowledgeDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtKnowledgeDate2_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeDate2.Text.Trim() == "")
                m_txtKnowledgeDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtKnowledgeDate3_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeDate3.Text.Trim() == "")
                m_txtKnowledgeDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //6
        private void m_txtGuidanceDate1_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceDate1.Text.Trim() == "")
                m_txtGuidanceDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtGuidanceDate2_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceDate2.Text.Trim() == "")
                m_txtGuidanceDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtGuidanceDate3_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceDate3.Text.Trim() == "")
                m_txtGuidanceDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //7
        private void m_txtOtherDate1_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherDate1.Text.Trim() == "")
                m_txtOtherDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtOtherDate2_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherDate2.Text.Trim() == "")
                m_txtOtherDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtOtherDate3_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherDate3.Text.Trim() == "")
                m_txtOtherDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //1
        private void m_txtReadOutNurse1_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutNurse1.Text.Trim() == "")
                m_txtReadOutNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtReadOutDate1.Text.Trim() == "")
                m_txtReadOutDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtReadOutNurse2_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutNurse2.Text.Trim() == "")
                m_txtReadOutNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtReadOutDate2.Text.Trim() == "")
                m_txtReadOutDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtReadOutNurse3_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutNurse3.Text.Trim() == "")
                m_txtReadOutNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtReadOutDate3.Text.Trim() == "")
                m_txtReadOutDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //2
        private void m_txtExplanNurse1_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanNurse1.Text.Trim() == "")
                m_txtExplanNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtExplanDate1.Text.Trim() == "")
                m_txtExplanDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtExplanNurse2_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanNurse2.Text.Trim() == "")
                m_txtExplanNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtExplanDate2.Text.Trim() == "")
                m_txtExplanDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtExplanNurse3_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanNurse3.Text.Trim() == "")
                m_txtExplanNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtExplanDate3.Text.Trim() == "")
                m_txtExplanDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //3
        private void m_txtMedicineNurse1_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineNurse1.Text.Trim() == "")
                m_txtMedicineNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtMedicineDate1.Text.Trim() == "")
                m_txtMedicineDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtMedicineNurse2_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineNurse2.Text.Trim() == "")
                m_txtMedicineNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtMedicineDate2.Text.Trim() == "")
                m_txtMedicineDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtMedicineNurse3_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineNurse3.Text.Trim() == "")
                m_txtMedicineNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtMedicineDate3.Text.Trim() == "")
                m_txtMedicineDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //4
        private void m_txtNoticeNurse1_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeNurse1.Text.Trim() == "")
                m_txtNoticeNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtNoticeDate1.Text.Trim() == "")
                m_txtNoticeDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtNoticeNurse2_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeNurse2.Text.Trim() == "")
                m_txtNoticeNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtNoticeDate2.Text.Trim() == "")
                m_txtNoticeDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtNoticeNurse3_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeNurse3.Text.Trim() == "")
                m_txtNoticeNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtNoticeDate3.Text.Trim() == "")
                m_txtNoticeDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //5
        private void m_txtKnowledgeNurse1_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeNurse1.Text.Trim() == "")
                m_txtKnowledgeNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtKnowledgeDate1.Text.Trim() == "")
                m_txtKnowledgeDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtKnowledgeNurse2_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeNurse2.Text.Trim() == "")
                m_txtKnowledgeNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtKnowledgeDate2.Text.Trim() == "")
                m_txtKnowledgeDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtKnowledgeNurse3_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeNurse3.Text.Trim() == "")
                m_txtKnowledgeNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtKnowledgeDate3.Text.Trim() == "")
                m_txtKnowledgeDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //6
        private void m_txtGuidanceNurse1_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceNurse1.Text.Trim() == "")
                m_txtGuidanceNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtGuidanceDate1.Text.Trim() == "")
                m_txtGuidanceDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtGuidanceNurse2_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceNurse2.Text.Trim() == "")
                m_txtGuidanceNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtGuidanceDate2.Text.Trim() == "")
                m_txtGuidanceDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtGuidanceNurse3_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceNurse3.Text.Trim() == "")
                m_txtGuidanceNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtGuidanceDate3.Text.Trim() == "")
                m_txtGuidanceDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //7
        private void m_txtOtherNurse1_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherNurse1.Text.Trim() == "")
                m_txtOtherNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtOtherDate1.Text.Trim() == "")
                m_txtOtherDate1.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtOtherNurse2_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherNurse2.Text.Trim() == "")
                m_txtOtherNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtOtherDate2.Text.Trim() == "")
                m_txtOtherDate2.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        private void m_txtOtherNurse3_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherNurse3.Text.Trim() == "")
                m_txtOtherNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
            if (m_txtOtherDate3.Text.Trim() == "")
                m_txtOtherDate3.Text = DateTime.Now.ToString("yyyy-M-d");
        }
        //11
        private void m_txtReadOutEdu1_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutEdu1.Text.Trim() == "")
            {
                m_txtReadOutEdu1.Text = "√";
                if (m_txtReadOutNurse1.Text.Trim() == "")
                    m_txtReadOutNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtReadOutDate1.Text.Trim() == "")
                    m_txtReadOutDate1.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //12
        private void m_txtReadOutEdu2_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutEdu2.Text.Trim() == "")
            {
                m_txtReadOutEdu2.Text = "√";
                if (m_txtReadOutNurse2.Text.Trim() == "")
                    m_txtReadOutNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtReadOutDate2.Text.Trim() == "")
                    m_txtReadOutDate2.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //13
        private void m_txtReadOutEdu3_Enter(object sender, EventArgs e)
        {
            if (m_txtReadOutEdu3.Text.Trim() == "")
            {
                m_txtReadOutEdu3.Text = "√";
                if (m_txtReadOutNurse3.Text.Trim() == "")
                    m_txtReadOutNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtReadOutDate3.Text.Trim() == "")
                    m_txtReadOutDate3.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //21
        private void m_txtExplanEdu1_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanEdu1.Text.Trim() == "")
            {
                m_txtExplanEdu1.Text = "√";
                if (m_txtExplanNurse1.Text.Trim() == "")
                    m_txtExplanNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtExplanDate1.Text.Trim() == "")
                    m_txtExplanDate1.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //22
        private void m_txtExplanEdu2_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanEdu2.Text.Trim() == "")
            {
                m_txtExplanEdu2.Text = "√";
                if (m_txtExplanNurse2.Text.Trim() == "")
                    m_txtExplanNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtExplanDate2.Text.Trim() == "")
                    m_txtExplanDate2.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //23
        private void m_txtExplanEdu3_Enter(object sender, EventArgs e)
        {
            if (m_txtExplanEdu3.Text.Trim() == "")
            {
                m_txtExplanEdu3.Text = "√";
                if (m_txtExplanNurse3.Text.Trim() == "")
                    m_txtExplanNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtExplanDate3.Text.Trim() == "")
                    m_txtExplanDate3.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //31
        private void m_txtMedicineEdu1_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineEdu1.Text.Trim() == "")
            {
                m_txtMedicineEdu1.Text = "√";
                if (m_txtMedicineNurse1.Text.Trim() == "")
                    m_txtMedicineNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtMedicineDate1.Text.Trim() == "")
                    m_txtMedicineDate1.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //32
        private void m_txtMedicineEdu2_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineEdu2.Text.Trim() == "")
            {
                m_txtMedicineEdu2.Text = "√";
                if (m_txtMedicineNurse2.Text.Trim() == "")
                    m_txtMedicineNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtMedicineDate2.Text.Trim() == "")
                    m_txtMedicineDate2.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //33
        private void m_txtMedicineEdu3_Enter(object sender, EventArgs e)
        {
            if (m_txtMedicineEdu3.Text.Trim() == "")
            {
                m_txtMedicineEdu3.Text = "√";
                if (m_txtMedicineNurse3.Text.Trim() == "")
                    m_txtMedicineNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtMedicineDate3.Text.Trim() == "")
                    m_txtMedicineDate3.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //41
        private void m_txtNoticeEdu1_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeEdu1.Text.Trim() == "")
            {
                m_txtNoticeEdu1.Text = "√";
                if (m_txtNoticeNurse1.Text.Trim() == "")
                    m_txtNoticeNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtNoticeDate1.Text.Trim() == "")
                    m_txtNoticeDate1.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //42
        private void m_txtNoticeEdu2_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeEdu2.Text.Trim() == "")
            {
                m_txtNoticeEdu2.Text = "√";
                if (m_txtNoticeNurse2.Text.Trim() == "")
                    m_txtNoticeNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtNoticeDate2.Text.Trim() == "")
                    m_txtNoticeDate2.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //43
        private void m_txtNoticeEdu3_Enter(object sender, EventArgs e)
        {
            if (m_txtNoticeEdu3.Text.Trim() == "")
            {
                m_txtNoticeEdu3.Text = "√";
                if (m_txtNoticeNurse3.Text.Trim() == "")
                    m_txtNoticeNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtNoticeDate3.Text.Trim() == "")
                    m_txtNoticeDate3.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //51
        private void m_txtKnowledgeEdu1_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeEdu1.Text.Trim() == "")
            {
                m_txtKnowledgeEdu1.Text = "√";
                if (m_txtKnowledgeNurse1.Text.Trim() == "")
                    m_txtKnowledgeNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtKnowledgeDate1.Text.Trim() == "")
                    m_txtKnowledgeDate1.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //52
        private void m_txtKnowledgeEdu2_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeEdu2.Text.Trim() == "")
            {
                m_txtKnowledgeEdu2.Text = "√";
                if (m_txtKnowledgeNurse2.Text.Trim() == "")
                    m_txtKnowledgeNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtKnowledgeDate2.Text.Trim() == "")
                    m_txtKnowledgeDate2.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //53
        private void m_txtKnowledgeEdu3_Enter(object sender, EventArgs e)
        {
            if (m_txtKnowledgeEdu3.Text.Trim() == "")
            {
                m_txtKnowledgeEdu3.Text = "√";
                if (m_txtKnowledgeNurse3.Text.Trim() == "")
                    m_txtKnowledgeNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtKnowledgeDate3.Text.Trim() == "")
                    m_txtKnowledgeDate3.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //61
        private void m_txtGuidanceEdu1_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceEdu1.Text.Trim() == "")
            {
                m_txtGuidanceEdu1.Text = "√";
                if (m_txtGuidanceNurse1.Text.Trim() == "")
                    m_txtGuidanceNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtGuidanceDate1.Text.Trim() == "")
                    m_txtGuidanceDate1.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //62
        private void m_txtGuidanceEdu2_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceEdu2.Text.Trim() == "")
            {
                m_txtGuidanceEdu2.Text = "√";
                if (m_txtGuidanceNurse2.Text.Trim() == "")
                    m_txtGuidanceNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtGuidanceDate2.Text.Trim() == "")
                    m_txtGuidanceDate2.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //63
        private void m_txtGuidanceEdu3_Enter(object sender, EventArgs e)
        {
            if (m_txtGuidanceEdu3.Text.Trim() == "")
            {
                m_txtGuidanceEdu3.Text = "√";
                if (m_txtGuidanceNurse3.Text.Trim() == "")
                    m_txtGuidanceNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtGuidanceDate3.Text.Trim() == "")
                    m_txtGuidanceDate3.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //71
        private void m_txtOtherEdu1_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherEdu1.Text.Trim() == "")
            {
                m_txtOtherEdu1.Text = "√";
                if (m_txtOtherNurse1.Text.Trim() == "")
                    m_txtOtherNurse1.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtOtherDate1.Text.Trim() == "")
                    m_txtOtherDate1.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //72
        private void m_txtOtherEdu2_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherEdu2.Text.Trim() == "")
            {
                m_txtOtherEdu2.Text = "√";
                if (m_txtOtherNurse2.Text.Trim() == "")
                    m_txtOtherNurse2.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtOtherDate2.Text.Trim() == "")
                    m_txtOtherDate2.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
        //73
        private void m_txtOtherEdu3_Enter(object sender, EventArgs e)
        {
            if (m_txtOtherEdu3.Text.Trim() == "")
            {
                m_txtOtherEdu3.Text = "√";
                if (m_txtOtherNurse3.Text.Trim() == "")
                    m_txtOtherNurse3.Text = clsEMRLogin.LoginInfo.m_strEmpName;
                if (m_txtOtherDate3.Text.Trim() == "")
                    m_txtOtherDate3.Text = DateTime.Now.ToString("yyyy-M-d");
            }
        }
	}
}
