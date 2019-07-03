using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
namespace iCare
{
	/// <summary>
	/// 术前术后访视单 的摘要说明。
	/// </summary>
	public class frmIMR_PrePostOperateSee: frmInpatMedRecBase
	{
		#region 定义
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.Panel panel16;
		private System.Windows.Forms.Panel panel17;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Panel panel18;
		private System.Windows.Forms.Panel panel19;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Panel panel20;
		private System.Windows.Forms.Panel panel21;
		private System.Windows.Forms.Panel panel22;
		private System.Windows.Forms.Panel panel23;
		private System.Windows.Forms.Panel panel24;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label90;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboMasculineCharacter;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboEspecialHistory;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboNa;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTT;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboBloodK;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboUrineRt;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboAPTT;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboHCT;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboSort;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboHb;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboWBC;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboPLT;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboChest;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboECG;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboBloodType;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboBloodSugar;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboAST;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboALT;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboTTT;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboCO2CP;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboHepatitis;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtPreSeeDate;
		private PinkieControls.ButtonXP m_cmdAnaesthesiaDoctor;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtAnaesthesiaDoctor;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboMind;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboOther;
		private System.Windows.Forms.RadioButton m_rdbEvenCalm;
		private System.Windows.Forms.RadioButton m_rdbCalm;
		private System.Windows.Forms.CheckBox m_chkEndotracheal;
		private System.Windows.Forms.RadioButton m_cboComa;
		private System.Windows.Forms.RadioButton m_rdbWinkle;
		private System.Windows.Forms.RadioButton m_rdbSober;
		private System.Windows.Forms.RadioButton m_rdbEvenQuiet;
		private System.Windows.Forms.RadioButton m_rdbQuiet;
		private System.Windows.Forms.RadioButton m_rdbNoCalm;
		private System.Windows.Forms.RadioButton m_rdbShortCalm;
		private System.Windows.Forms.RadioButton m_rdbFavoring;
		private System.Windows.Forms.RadioButton m_rdbNotAllRight;
		private System.Windows.Forms.RadioButton m_rdbAllRight;
		private System.Windows.Forms.CheckBox m_chkExtradural;
		private System.Windows.Forms.RadioButton m_rdbNoKilter;
		private System.Windows.Forms.RadioButton m_rdbKilter;
		private System.Windows.Forms.RadioButton m_rdbNoQuiet;
		private System.Windows.Forms.RadioButton m_rdbShortQuiet;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboCause;
		private System.Windows.Forms.RadioButton m_rdbNotFavoring;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboChangeState;
		private System.Windows.Forms.CheckBox m_chkCobwebby;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboSmallNumState;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboEspecialCircs;
		private System.Windows.Forms.RadioButton m_rdbFluency;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboBlockRoad;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboEspecialInstuation;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboInfuse;
		private System.Windows.Forms.RadioButton m_rdbNotFluenty;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cbosecInfuse;
		private System.Windows.Forms.CheckBox m_chkFullVein;
		private System.Windows.Forms.CheckBox m_chkIntravenous;
		private System.Windows.Forms.CheckBox m_chkEffectBad;
		private System.Windows.Forms.CheckBox m_chkReinforceHocus;
		private System.Windows.Forms.CheckBox m_chkAbirritative;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboSpecial;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboCleaarPostOperate;
		private System.Windows.Forms.RadioButton m_rdbNotPlacidity;
		private System.Windows.Forms.RadioButton m_rdbShortPlacidity;
		private System.Windows.Forms.RadioButton m_rdbEvenPlacidity;
		private System.Windows.Forms.RadioButton m_rdbPlacidity;
		private System.Windows.Forms.CheckBox m_chkThighV;
		private System.Windows.Forms.CheckBox m_chkCVPNeckOut;
		private System.Windows.Forms.CheckBox m_chkCVPClavicle;
		private System.Windows.Forms.CheckBox m_chkCVPNeck;
		private System.Windows.Forms.RadioButton m_rdbCVPLeft;
		private System.Windows.Forms.RadioButton m_rdbCVPRight;
		private System.Windows.Forms.RadioButton m_rdbFloating;
		private System.Windows.Forms.RadioButton m_rdbAntrum;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboCVPEspecial;
		private System.Windows.Forms.RadioButton m_rdbkSingleAntrum;
		private System.Windows.Forms.CheckBox m_chkFlinch;
		private System.Windows.Forms.RadioButton m_rdbMAPLeft;
		private System.Windows.Forms.RadioButton m_rdbMAPRight;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboMAPEspecial;
		private System.Windows.Forms.CheckBox m_chkMAPFoot;
		private System.Windows.Forms.CheckBox m_chkMAPThigh;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_DtTime;
		private PinkieControls.ButtonXP m_cmbAnaesthesiaDoctorName;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_richTxtAnaesthesiaDoctorName;
		private com.digitalwave.controls.ctlRichTextBox m_richtxtPatientWard;
		private com.digitalwave.controls.ctlRichTextBox m_richtxtOperateDealwith;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboEndotrachealTingle;
		private System.Windows.Forms.CheckBox m_chkEndotrachealTingle;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboPCA;
		private System.Windows.Forms.CheckBox m_chkPCA;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboIntravenousTingle;
		private System.Windows.Forms.CheckBox m_chkIntravenousTingle;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboNeurolysisTingle;
		private System.Windows.Forms.CheckBox m_chkNeurolysisTingle;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboArachnoidTingle;
		private System.Windows.Forms.CheckBox m_chkArachnoidTingle;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboPutamenTigle;
		private System.Windows.Forms.CheckBox m_chkPutamenTigle;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtPostOperateTime;
		private PinkieControls.ButtonXP m_cmdHocusDoctorName;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHocusDoctorName;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboAnather;
		private com.digitalwave.controls.ctlRichTextBox m_richTxtPostOperateDoIdea;
		private System.Windows.Forms.Label label91;
		private com.digitalwave.Utility.Controls.ctlComboBox ctlComboBox1;
		private System.Windows.Forms.Label label92;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboCI;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboRBC;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboBUN;
		private System.Windows.Forms.TabControl tabControl1;
		#endregion 
	
		public frmIMR_PrePostOperateSee()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			InitializeComponent();
			m_mthSetRichTextBoxAttribInControl(this);
			new clsCommonUseToolCollection(this).m_mthBindEmployeeSign(new Control[]{this.m_cmdAnaesthesiaDoctor,this.m_cmbAnaesthesiaDoctorName,this.m_cmdHocusDoctorName },
				new Control[]{this.m_txtAnaesthesiaDoctor,this.m_richTxtAnaesthesiaDoctorName,this.m_txtHocusDoctorName},new int[]{1,1,1});
		}
		
		# region 初始化窗体
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label92 = new System.Windows.Forms.Label();
            this.ctlComboBox1 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label91 = new System.Windows.Forms.Label();
            this.m_dtPreSeeDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cmdAnaesthesiaDoctor = new PinkieControls.ButtonXP();
            this.m_txtAnaesthesiaDoctor = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.m_cboMind = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.m_cboOther = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.m_cboChest = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.m_cboECG = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.m_cboBloodType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.m_cboBloodSugar = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.m_cboAST = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.m_cboALT = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.m_cboTTT = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.m_cboCO2CP = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.m_cboBUN = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.m_cboCI = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.m_cboNa = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.m_cboTT = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.m_cboHepatitis = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboBloodK = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboUrineRt = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboAPTT = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_cboHCT = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboSort = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboMasculineCharacter = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboHb = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboWBC = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPLT = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboRBC = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboEspecialHistory = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label83 = new System.Windows.Forms.Label();
            this.m_cboMAPEspecial = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.m_chkMAPFoot = new System.Windows.Forms.CheckBox();
            this.m_chkMAPThigh = new System.Windows.Forms.CheckBox();
            this.m_chkFlinch = new System.Windows.Forms.CheckBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.m_rdbMAPLeft = new System.Windows.Forms.RadioButton();
            this.m_rdbMAPRight = new System.Windows.Forms.RadioButton();
            this.label82 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.m_cboCVPEspecial = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.m_rdbFloating = new System.Windows.Forms.RadioButton();
            this.m_rdbAntrum = new System.Windows.Forms.RadioButton();
            this.m_rdbkSingleAntrum = new System.Windows.Forms.RadioButton();
            this.panel16 = new System.Windows.Forms.Panel();
            this.m_chkThighV = new System.Windows.Forms.CheckBox();
            this.m_chkCVPNeckOut = new System.Windows.Forms.CheckBox();
            this.m_chkCVPClavicle = new System.Windows.Forms.CheckBox();
            this.m_chkCVPNeck = new System.Windows.Forms.CheckBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.m_rdbCVPLeft = new System.Windows.Forms.RadioButton();
            this.m_rdbCVPRight = new System.Windows.Forms.RadioButton();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.m_cboSpecial = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.m_cboCleaarPostOperate = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.m_rdbNotPlacidity = new System.Windows.Forms.RadioButton();
            this.m_rdbShortPlacidity = new System.Windows.Forms.RadioButton();
            this.m_rdbEvenPlacidity = new System.Windows.Forms.RadioButton();
            this.m_rdbPlacidity = new System.Windows.Forms.RadioButton();
            this.label76 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.m_chkEffectBad = new System.Windows.Forms.CheckBox();
            this.m_chkReinforceHocus = new System.Windows.Forms.CheckBox();
            this.m_chkAbirritative = new System.Windows.Forms.CheckBox();
            this.m_chkFullVein = new System.Windows.Forms.CheckBox();
            this.label75 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.m_chkIntravenous = new System.Windows.Forms.CheckBox();
            this.label73 = new System.Windows.Forms.Label();
            this.m_cboBlockRoad = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label74 = new System.Windows.Forms.Label();
            this.m_cboEspecialInstuation = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.m_cboInfuse = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label68 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.m_rdbNotFluenty = new System.Windows.Forms.RadioButton();
            this.m_rdbFluency = new System.Windows.Forms.RadioButton();
            this.label70 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.m_chkCobwebby = new System.Windows.Forms.CheckBox();
            this.m_cbosecInfuse = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label67 = new System.Windows.Forms.Label();
            this.m_cboSmallNumState = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label66 = new System.Windows.Forms.Label();
            this.m_cboEspecialCircs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.m_rdbNotFavoring = new System.Windows.Forms.RadioButton();
            this.m_rdbFavoring = new System.Windows.Forms.RadioButton();
            this.label64 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_rdbNotAllRight = new System.Windows.Forms.RadioButton();
            this.m_rdbAllRight = new System.Windows.Forms.RadioButton();
            this.label63 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_chkExtradural = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_rdbNoKilter = new System.Windows.Forms.RadioButton();
            this.m_rdbKilter = new System.Windows.Forms.RadioButton();
            this.label62 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_rdbNoQuiet = new System.Windows.Forms.RadioButton();
            this.m_rdbShortQuiet = new System.Windows.Forms.RadioButton();
            this.m_rdbEvenQuiet = new System.Windows.Forms.RadioButton();
            this.m_rdbQuiet = new System.Windows.Forms.RadioButton();
            this.label61 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_rdbNoCalm = new System.Windows.Forms.RadioButton();
            this.m_rdbShortCalm = new System.Windows.Forms.RadioButton();
            this.m_rdbEvenCalm = new System.Windows.Forms.RadioButton();
            this.m_rdbCalm = new System.Windows.Forms.RadioButton();
            this.label60 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_chkEndotracheal = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cboComa = new System.Windows.Forms.RadioButton();
            this.m_rdbWinkle = new System.Windows.Forms.RadioButton();
            this.m_rdbSober = new System.Windows.Forms.RadioButton();
            this.m_cboChangeState = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboCause = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_DtTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label86 = new System.Windows.Forms.Label();
            this.m_cmbAnaesthesiaDoctorName = new PinkieControls.ButtonXP();
            this.m_richTxtAnaesthesiaDoctorName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.m_richtxtPatientWard = new com.digitalwave.controls.ctlRichTextBox();
            this.m_richtxtOperateDealwith = new com.digitalwave.controls.ctlRichTextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.m_dtPostOperateTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label90 = new System.Windows.Forms.Label();
            this.m_cmdHocusDoctorName = new PinkieControls.ButtonXP();
            this.m_txtHocusDoctorName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_richTxtPostOperateDoIdea = new com.digitalwave.controls.ctlRichTextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.m_cboAnather = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPCA = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_chkPCA = new System.Windows.Forms.CheckBox();
            this.m_cboIntravenousTingle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.m_chkIntravenousTingle = new System.Windows.Forms.CheckBox();
            this.m_cboNeurolysisTingle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.m_chkNeurolysisTingle = new System.Windows.Forms.CheckBox();
            this.m_cboArachnoidTingle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel22 = new System.Windows.Forms.Panel();
            this.m_chkArachnoidTingle = new System.Windows.Forms.CheckBox();
            this.m_cboPutamenTigle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.m_chkPutamenTigle = new System.Windows.Forms.CheckBox();
            this.label88 = new System.Windows.Forms.Label();
            this.m_cboEndotrachealTingle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.m_chkEndotrachealTingle = new System.Windows.Forms.CheckBox();
            this.label87 = new System.Windows.Forms.Label();
            this.m_pnlContent.SuspendLayout();
            this.m_pnlNewBase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmdCreateID
            // 
            this.m_cmdCreateID.Location = new System.Drawing.Point(627, 127);
            this.m_cmdCreateID.Size = new System.Drawing.Size(84, 24);
            // 
            // m_pnlContent
            // 
            this.m_pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlContent.Controls.Add(this.tabControl1);
            this.m_pnlContent.Location = new System.Drawing.Point(4, 124);
            this.m_pnlContent.Size = new System.Drawing.Size(812, 492);
            // 
            // trvTime
            // 
            this.trvTime.LineColor = System.Drawing.Color.Black;
            this.trvTime.Location = new System.Drawing.Point(207, 191);
            this.trvTime.Visible = false;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(336, 128);
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Location = new System.Drawing.Point(261, 132);
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.Location = new System.Drawing.Point(261, 206);
            this.lblNativePlace.Visible = false;
            // 
            // m_lblNativePlace
            // 
            this.m_lblNativePlace.Location = new System.Drawing.Point(260, 208);
            this.m_lblNativePlace.Size = new System.Drawing.Size(304, 20);
            this.m_lblNativePlace.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.Location = new System.Drawing.Point(314, 194);
            this.lblOccupation.Visible = false;
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.Location = new System.Drawing.Point(354, 194);
            this.m_lblOccupation.Visible = false;
            // 
            // m_lblMarriaged
            // 
            this.m_lblMarriaged.Location = new System.Drawing.Point(350, 188);
            this.m_lblMarriaged.Visible = false;
            // 
            // lblMarriaged
            // 
            this.lblMarriaged.Location = new System.Drawing.Point(346, 162);
            this.lblMarriaged.Visible = false;
            // 
            // m_lblLinkMan
            // 
            this.m_lblLinkMan.Location = new System.Drawing.Point(292, 193);
            this.m_lblLinkMan.Visible = false;
            // 
            // lblLinkMan
            // 
            this.lblLinkMan.Location = new System.Drawing.Point(297, 188);
            this.lblLinkMan.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(266, 200);
            this.lblAddress.Visible = false;
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Location = new System.Drawing.Point(260, 214);
            this.m_lblAddress.Size = new System.Drawing.Size(320, 20);
            this.m_lblAddress.Visible = false;
            // 
            // lblRepresentor
            // 
            this.lblRepresentor.Location = new System.Drawing.Point(358, 95);
            // 
            // lblCredibility
            // 
            this.lblCredibility.Location = new System.Drawing.Point(508, 95);
            // 
            // m_cboRepresentor
            // 
            this.m_cboRepresentor.Location = new System.Drawing.Point(410, 91);
            // 
            // m_cboCredibility
            // 
            this.m_cboCredibility.Location = new System.Drawing.Point(564, 91);
            // 
            // m_lsvEmployee
            // 
            this.m_lsvEmployee.Location = new System.Drawing.Point(345, 194);
            // 
            // lsvSign
            // 
            this.lsvSign.Location = new System.Drawing.Point(307, 91);
            this.lsvSign.Visible = false;
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(715, 127);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(321, 194);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(300, 187);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(294, 194);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(280, 194);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(280, 185);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(321, 194);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(314, 194);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(266, 194);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(264, 162);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(297, 191);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(288, 194);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(288, 205);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(244, 194);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(287, 162);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(264, 176);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(275, 202);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(268, 211);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(287, 211);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(300, 179);
            this.m_cmdNext.Visible = false;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(276, 206);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(317, 193);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(452, 219);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(742, 36);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(4, 6);
            this.m_pnlNewBase.Size = new System.Drawing.Size(812, 113);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = true;
            this.m_ctlPatientInfo.m_BlnIsShowMarriage = true;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = true;
            this.m_ctlPatientInfo.m_BlnIsShowOffice = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowRelationName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRelationPhone = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(810, 82);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 456);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label92);
            this.tabPage1.Controls.Add(this.ctlComboBox1);
            this.tabPage1.Controls.Add(this.label91);
            this.tabPage1.Controls.Add(this.m_dtPreSeeDate);
            this.tabPage1.Controls.Add(this.m_cmdAnaesthesiaDoctor);
            this.tabPage1.Controls.Add(this.m_txtAnaesthesiaDoctor);
            this.tabPage1.Controls.Add(this.label56);
            this.tabPage1.Controls.Add(this.m_cboMind);
            this.tabPage1.Controls.Add(this.label55);
            this.tabPage1.Controls.Add(this.m_cboOther);
            this.tabPage1.Controls.Add(this.label54);
            this.tabPage1.Controls.Add(this.m_cboChest);
            this.tabPage1.Controls.Add(this.label53);
            this.tabPage1.Controls.Add(this.m_cboECG);
            this.tabPage1.Controls.Add(this.label52);
            this.tabPage1.Controls.Add(this.m_cboBloodType);
            this.tabPage1.Controls.Add(this.label51);
            this.tabPage1.Controls.Add(this.label49);
            this.tabPage1.Controls.Add(this.m_cboBloodSugar);
            this.tabPage1.Controls.Add(this.label50);
            this.tabPage1.Controls.Add(this.label47);
            this.tabPage1.Controls.Add(this.m_cboAST);
            this.tabPage1.Controls.Add(this.label48);
            this.tabPage1.Controls.Add(this.label45);
            this.tabPage1.Controls.Add(this.m_cboALT);
            this.tabPage1.Controls.Add(this.label46);
            this.tabPage1.Controls.Add(this.label43);
            this.tabPage1.Controls.Add(this.m_cboTTT);
            this.tabPage1.Controls.Add(this.label44);
            this.tabPage1.Controls.Add(this.label42);
            this.tabPage1.Controls.Add(this.label41);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.m_cboCO2CP);
            this.tabPage1.Controls.Add(this.label40);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.m_cboBUN);
            this.tabPage1.Controls.Add(this.label39);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.Controls.Add(this.m_cboCI);
            this.tabPage1.Controls.Add(this.label35);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.m_cboNa);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.m_cboTT);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.m_cboHepatitis);
            this.tabPage1.Controls.Add(this.m_cboBloodK);
            this.tabPage1.Controls.Add(this.m_cboUrineRt);
            this.tabPage1.Controls.Add(this.m_cboAPTT);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.m_cboHCT);
            this.tabPage1.Controls.Add(this.m_cboSort);
            this.tabPage1.Controls.Add(this.m_cboMasculineCharacter);
            this.tabPage1.Controls.Add(this.m_cboHb);
            this.tabPage1.Controls.Add(this.m_cboWBC);
            this.tabPage1.Controls.Add(this.m_cboPLT);
            this.tabPage1.Controls.Add(this.m_cboRBC);
            this.tabPage1.Controls.Add(this.m_cboEspecialHistory);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "第一页";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(752, 104);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(35, 14);
            this.label92.TabIndex = 1413;
            this.label92.Text = "急诊";
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctlComboBox1
            // 
            this.ctlComboBox1.AccessibleDescription = "辅助检查结果>>WBC";
            this.ctlComboBox1.BorderColor = System.Drawing.Color.Black;
            this.ctlComboBox1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.ctlComboBox1.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.ctlComboBox1.DropButtonForeColor = System.Drawing.Color.Black;
            this.ctlComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctlComboBox1.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlComboBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlComboBox1.ListBackColor = System.Drawing.Color.White;
            this.ctlComboBox1.ListForeColor = System.Drawing.Color.Black;
            this.ctlComboBox1.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.ctlComboBox1.ListSelectedForeColor = System.Drawing.Color.White;
            this.ctlComboBox1.Location = new System.Drawing.Point(624, 104);
            this.ctlComboBox1.m_BlnEnableItemEventMenu = true;
            this.ctlComboBox1.Name = "ctlComboBox1";
            this.ctlComboBox1.SelectedIndex = -1;
            this.ctlComboBox1.SelectedItem = null;
            this.ctlComboBox1.SelectionStart = 0;
            this.ctlComboBox1.Size = new System.Drawing.Size(128, 23);
            this.ctlComboBox1.TabIndex = 1412;
            this.ctlComboBox1.TextBackColor = System.Drawing.Color.White;
            this.ctlComboBox1.TextForeColor = System.Drawing.Color.Black;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(560, 104);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(70, 14);
            this.label91.TabIndex = 1411;
            this.label91.Text = "ASA分级：";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_dtPreSeeDate
            // 
            this.m_dtPreSeeDate.AccessibleDescription = "术前访视>>日期";
            this.m_dtPreSeeDate.BorderColor = System.Drawing.Color.White;
            this.m_dtPreSeeDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtPreSeeDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtPreSeeDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtPreSeeDate.DropButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtPreSeeDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtPreSeeDate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtPreSeeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtPreSeeDate.Location = new System.Drawing.Point(608, 376);
            this.m_dtPreSeeDate.m_BlnOnlyTime = false;
            this.m_dtPreSeeDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtPreSeeDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtPreSeeDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtPreSeeDate.Name = "m_dtPreSeeDate";
            this.m_dtPreSeeDate.ReadOnly = false;
            this.m_dtPreSeeDate.Size = new System.Drawing.Size(144, 22);
            this.m_dtPreSeeDate.TabIndex = 1410;
            this.m_dtPreSeeDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtPreSeeDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdAnaesthesiaDoctor
            // 
            this.m_cmdAnaesthesiaDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAnaesthesiaDoctor.DefaultScheme = true;
            this.m_cmdAnaesthesiaDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAnaesthesiaDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAnaesthesiaDoctor.Hint = "";
            this.m_cmdAnaesthesiaDoctor.Location = new System.Drawing.Point(336, 373);
            this.m_cmdAnaesthesiaDoctor.Name = "m_cmdAnaesthesiaDoctor";
            this.m_cmdAnaesthesiaDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAnaesthesiaDoctor.Size = new System.Drawing.Size(96, 28);
            this.m_cmdAnaesthesiaDoctor.TabIndex = 1339;
            this.m_cmdAnaesthesiaDoctor.Tag = "1";
            this.m_cmdAnaesthesiaDoctor.Text = "麻醉科医生:";
            // 
            // m_txtAnaesthesiaDoctor
            // 
            this.m_txtAnaesthesiaDoctor.AccessibleDescription = "麻醉科医生1";
            this.m_txtAnaesthesiaDoctor.AccessibleName = "NoDefault";
            this.m_txtAnaesthesiaDoctor.BackColor = System.Drawing.Color.White;
            this.m_txtAnaesthesiaDoctor.BorderColor = System.Drawing.Color.White;
            this.m_txtAnaesthesiaDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAnaesthesiaDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_txtAnaesthesiaDoctor.Location = new System.Drawing.Point(432, 376);
            this.m_txtAnaesthesiaDoctor.Name = "m_txtAnaesthesiaDoctor";
            this.m_txtAnaesthesiaDoctor.Size = new System.Drawing.Size(104, 23);
            this.m_txtAnaesthesiaDoctor.TabIndex = 1340;
            this.m_txtAnaesthesiaDoctor.Tag = "1";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(561, 380);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(49, 14);
            this.label56.TabIndex = 82;
            this.label56.Text = "日期：";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboMind
            // 
            this.m_cboMind.AccessibleDescription = "辅助检查结果>>意见";
            this.m_cboMind.BorderColor = System.Drawing.Color.Black;
            this.m_cboMind.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMind.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboMind.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMind.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMind.ListBackColor = System.Drawing.Color.White;
            this.m_cboMind.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMind.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMind.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMind.Location = new System.Drawing.Point(64, 328);
            this.m_cboMind.m_BlnEnableItemEventMenu = true;
            this.m_cboMind.Name = "m_cboMind";
            this.m_cboMind.SelectedIndex = -1;
            this.m_cboMind.SelectedItem = null;
            this.m_cboMind.SelectionStart = 0;
            this.m_cboMind.Size = new System.Drawing.Size(688, 23);
            this.m_cboMind.TabIndex = 81;
            this.m_cboMind.TextBackColor = System.Drawing.Color.White;
            this.m_cboMind.TextForeColor = System.Drawing.Color.Black;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(24, 328);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(49, 14);
            this.label55.TabIndex = 80;
            this.label55.Text = "意见：";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboOther
            // 
            this.m_cboOther.AccessibleDescription = "辅助检查结果>>其他";
            this.m_cboOther.BorderColor = System.Drawing.Color.Black;
            this.m_cboOther.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOther.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboOther.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOther.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOther.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOther.ListBackColor = System.Drawing.Color.White;
            this.m_cboOther.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOther.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOther.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOther.Location = new System.Drawing.Point(64, 296);
            this.m_cboOther.m_BlnEnableItemEventMenu = true;
            this.m_cboOther.Name = "m_cboOther";
            this.m_cboOther.SelectedIndex = -1;
            this.m_cboOther.SelectedItem = null;
            this.m_cboOther.SelectionStart = 0;
            this.m_cboOther.Size = new System.Drawing.Size(688, 23);
            this.m_cboOther.TabIndex = 79;
            this.m_cboOther.TextBackColor = System.Drawing.Color.White;
            this.m_cboOther.TextForeColor = System.Drawing.Color.Black;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(24, 296);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(49, 14);
            this.label54.TabIndex = 78;
            this.label54.Text = "其他：";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboChest
            // 
            this.m_cboChest.AccessibleDescription = "辅助检查结果>>胸透";
            this.m_cboChest.BorderColor = System.Drawing.Color.Black;
            this.m_cboChest.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboChest.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboChest.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboChest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboChest.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboChest.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboChest.ListBackColor = System.Drawing.Color.White;
            this.m_cboChest.ListForeColor = System.Drawing.Color.Black;
            this.m_cboChest.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboChest.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboChest.Location = new System.Drawing.Point(512, 264);
            this.m_cboChest.m_BlnEnableItemEventMenu = true;
            this.m_cboChest.Name = "m_cboChest";
            this.m_cboChest.SelectedIndex = -1;
            this.m_cboChest.SelectedItem = null;
            this.m_cboChest.SelectionStart = 0;
            this.m_cboChest.Size = new System.Drawing.Size(240, 23);
            this.m_cboChest.TabIndex = 77;
            this.m_cboChest.TextBackColor = System.Drawing.Color.White;
            this.m_cboChest.TextForeColor = System.Drawing.Color.Black;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(408, 264);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(112, 14);
            this.label53.TabIndex = 76;
            this.label53.Text = "胸透(X线胸片)：";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboECG
            // 
            this.m_cboECG.AccessibleDescription = "辅助检查结果>>ECG";
            this.m_cboECG.BorderColor = System.Drawing.Color.Black;
            this.m_cboECG.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboECG.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboECG.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboECG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboECG.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboECG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboECG.ListBackColor = System.Drawing.Color.White;
            this.m_cboECG.ListForeColor = System.Drawing.Color.Black;
            this.m_cboECG.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboECG.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboECG.Location = new System.Drawing.Point(168, 264);
            this.m_cboECG.m_BlnEnableItemEventMenu = true;
            this.m_cboECG.Name = "m_cboECG";
            this.m_cboECG.SelectedIndex = -1;
            this.m_cboECG.SelectedItem = null;
            this.m_cboECG.SelectionStart = 0;
            this.m_cboECG.Size = new System.Drawing.Size(240, 23);
            this.m_cboECG.TabIndex = 75;
            this.m_cboECG.TextBackColor = System.Drawing.Color.White;
            this.m_cboECG.TextForeColor = System.Drawing.Color.Black;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(136, 264);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(42, 14);
            this.label52.TabIndex = 74;
            this.label52.Text = "ECG：";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboBloodType
            // 
            this.m_cboBloodType.AccessibleDescription = "辅助检查结果>>血型";
            this.m_cboBloodType.BorderColor = System.Drawing.Color.Black;
            this.m_cboBloodType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBloodType.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboBloodType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBloodType.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBloodType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBloodType.ListBackColor = System.Drawing.Color.White;
            this.m_cboBloodType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBloodType.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBloodType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBloodType.Location = new System.Drawing.Point(64, 264);
            this.m_cboBloodType.m_BlnEnableItemEventMenu = true;
            this.m_cboBloodType.Name = "m_cboBloodType";
            this.m_cboBloodType.SelectedIndex = -1;
            this.m_cboBloodType.SelectedItem = null;
            this.m_cboBloodType.SelectionStart = 0;
            this.m_cboBloodType.Size = new System.Drawing.Size(64, 23);
            this.m_cboBloodType.TabIndex = 73;
            this.m_cboBloodType.TextBackColor = System.Drawing.Color.White;
            this.m_cboBloodType.TextForeColor = System.Drawing.Color.Black;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(32, 264);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(35, 14);
            this.label51.TabIndex = 72;
            this.label51.Text = "血型";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(744, 232);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(49, 14);
            this.label49.TabIndex = 71;
            this.label49.Text = "mmol/L";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboBloodSugar
            // 
            this.m_cboBloodSugar.AccessibleDescription = "辅助检查结果>>血糖";
            this.m_cboBloodSugar.BorderColor = System.Drawing.Color.Black;
            this.m_cboBloodSugar.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBloodSugar.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboBloodSugar.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBloodSugar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBloodSugar.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBloodSugar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBloodSugar.ListBackColor = System.Drawing.Color.White;
            this.m_cboBloodSugar.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBloodSugar.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBloodSugar.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBloodSugar.Location = new System.Drawing.Point(664, 232);
            this.m_cboBloodSugar.m_BlnEnableItemEventMenu = true;
            this.m_cboBloodSugar.Name = "m_cboBloodSugar";
            this.m_cboBloodSugar.SelectedIndex = -1;
            this.m_cboBloodSugar.SelectedItem = null;
            this.m_cboBloodSugar.SelectionStart = 0;
            this.m_cboBloodSugar.Size = new System.Drawing.Size(80, 23);
            this.m_cboBloodSugar.TabIndex = 70;
            this.m_cboBloodSugar.TextBackColor = System.Drawing.Color.White;
            this.m_cboBloodSugar.TextForeColor = System.Drawing.Color.Black;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(632, 232);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(35, 14);
            this.label50.TabIndex = 69;
            this.label50.Text = "血糖";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(600, 232);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(42, 14);
            this.label47.TabIndex = 68;
            this.label47.Text = "u/L，";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboAST
            // 
            this.m_cboAST.AccessibleDescription = "辅助检查结果>>AST";
            this.m_cboAST.BorderColor = System.Drawing.Color.Black;
            this.m_cboAST.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAST.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboAST.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAST.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAST.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAST.ListBackColor = System.Drawing.Color.White;
            this.m_cboAST.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAST.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboAST.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboAST.Location = new System.Drawing.Point(536, 232);
            this.m_cboAST.m_BlnEnableItemEventMenu = true;
            this.m_cboAST.Name = "m_cboAST";
            this.m_cboAST.SelectedIndex = -1;
            this.m_cboAST.SelectedItem = null;
            this.m_cboAST.SelectionStart = 0;
            this.m_cboAST.Size = new System.Drawing.Size(64, 23);
            this.m_cboAST.TabIndex = 67;
            this.m_cboAST.TextBackColor = System.Drawing.Color.White;
            this.m_cboAST.TextForeColor = System.Drawing.Color.Black;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(512, 232);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(28, 14);
            this.label48.TabIndex = 66;
            this.label48.Text = "AST";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(464, 232);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(42, 14);
            this.label45.TabIndex = 65;
            this.label45.Text = "u/L，";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboALT
            // 
            this.m_cboALT.AccessibleDescription = "辅助检查结果>>ALT";
            this.m_cboALT.BorderColor = System.Drawing.Color.Black;
            this.m_cboALT.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboALT.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboALT.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboALT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboALT.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboALT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboALT.ListBackColor = System.Drawing.Color.White;
            this.m_cboALT.ListForeColor = System.Drawing.Color.Black;
            this.m_cboALT.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboALT.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboALT.Location = new System.Drawing.Point(400, 232);
            this.m_cboALT.m_BlnEnableItemEventMenu = true;
            this.m_cboALT.Name = "m_cboALT";
            this.m_cboALT.SelectedIndex = -1;
            this.m_cboALT.SelectedItem = null;
            this.m_cboALT.SelectionStart = 0;
            this.m_cboALT.Size = new System.Drawing.Size(64, 23);
            this.m_cboALT.TabIndex = 64;
            this.m_cboALT.TextBackColor = System.Drawing.Color.White;
            this.m_cboALT.TextForeColor = System.Drawing.Color.Black;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(376, 232);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(28, 14);
            this.label46.TabIndex = 63;
            this.label46.Text = "ALT";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(336, 232);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(42, 14);
            this.label43.TabIndex = 62;
            this.label43.Text = "u/L，";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboTTT
            // 
            this.m_cboTTT.AccessibleDescription = "辅助检查结果>>TTT";
            this.m_cboTTT.BorderColor = System.Drawing.Color.Black;
            this.m_cboTTT.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTTT.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTTT.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTTT.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTTT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTTT.ListBackColor = System.Drawing.Color.White;
            this.m_cboTTT.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTTT.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTTT.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTTT.Location = new System.Drawing.Point(280, 232);
            this.m_cboTTT.m_BlnEnableItemEventMenu = true;
            this.m_cboTTT.Name = "m_cboTTT";
            this.m_cboTTT.SelectedIndex = -1;
            this.m_cboTTT.SelectedItem = null;
            this.m_cboTTT.SelectionStart = 0;
            this.m_cboTTT.Size = new System.Drawing.Size(56, 23);
            this.m_cboTTT.TabIndex = 61;
            this.m_cboTTT.TextBackColor = System.Drawing.Color.White;
            this.m_cboTTT.TextForeColor = System.Drawing.Color.Black;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(256, 232);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(28, 14);
            this.label44.TabIndex = 60;
            this.label44.Text = "TTT";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(512, 200);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(21, 14);
            this.label42.TabIndex = 59;
            this.label42.Text = "CP";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(504, 208);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(14, 14);
            this.label41.TabIndex = 58;
            this.label41.Text = "2";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(600, 200);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 14);
            this.label38.TabIndex = 57;
            this.label38.Text = "mmol/L，";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboCO2CP
            // 
            this.m_cboCO2CP.AccessibleDescription = "辅助检查结果>>CO2CP";
            this.m_cboCO2CP.BorderColor = System.Drawing.Color.Black;
            this.m_cboCO2CP.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCO2CP.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboCO2CP.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCO2CP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCO2CP.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCO2CP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCO2CP.ListBackColor = System.Drawing.Color.White;
            this.m_cboCO2CP.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCO2CP.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCO2CP.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCO2CP.Location = new System.Drawing.Point(536, 200);
            this.m_cboCO2CP.m_BlnEnableItemEventMenu = true;
            this.m_cboCO2CP.Name = "m_cboCO2CP";
            this.m_cboCO2CP.SelectedIndex = -1;
            this.m_cboCO2CP.SelectedItem = null;
            this.m_cboCO2CP.SelectionStart = 0;
            this.m_cboCO2CP.Size = new System.Drawing.Size(64, 23);
            this.m_cboCO2CP.TabIndex = 56;
            this.m_cboCO2CP.TextBackColor = System.Drawing.Color.White;
            this.m_cboCO2CP.TextForeColor = System.Drawing.Color.Black;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(488, 200);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(21, 14);
            this.label40.TabIndex = 55;
            this.label40.Text = "CO";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(432, 200);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 14);
            this.label37.TabIndex = 54;
            this.label37.Text = "mmol/L，";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboBUN
            // 
            this.m_cboBUN.AccessibleDescription = "辅助检查结果>>BUN";
            this.m_cboBUN.BorderColor = System.Drawing.Color.Black;
            this.m_cboBUN.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBUN.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboBUN.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBUN.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBUN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBUN.ListBackColor = System.Drawing.Color.White;
            this.m_cboBUN.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBUN.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBUN.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBUN.Location = new System.Drawing.Point(360, 200);
            this.m_cboBUN.m_BlnEnableItemEventMenu = true;
            this.m_cboBUN.Name = "m_cboBUN";
            this.m_cboBUN.SelectedIndex = -1;
            this.m_cboBUN.SelectedItem = null;
            this.m_cboBUN.SelectionStart = 0;
            this.m_cboBUN.Size = new System.Drawing.Size(64, 23);
            this.m_cboBUN.TabIndex = 53;
            this.m_cboBUN.TextBackColor = System.Drawing.Color.White;
            this.m_cboBUN.TextForeColor = System.Drawing.Color.Black;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(328, 200);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(28, 14);
            this.label39.TabIndex = 51;
            this.label39.Text = "BUN";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(272, 200);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(63, 14);
            this.label34.TabIndex = 50;
            this.label34.Text = "mmol/L，";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboCI
            // 
            this.m_cboCI.AccessibleDescription = "辅助检查结果>>CI";
            this.m_cboCI.BorderColor = System.Drawing.Color.Black;
            this.m_cboCI.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCI.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboCI.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCI.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCI.ListBackColor = System.Drawing.Color.White;
            this.m_cboCI.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCI.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCI.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCI.Location = new System.Drawing.Point(208, 200);
            this.m_cboCI.m_BlnEnableItemEventMenu = true;
            this.m_cboCI.Name = "m_cboCI";
            this.m_cboCI.SelectedIndex = -1;
            this.m_cboCI.SelectedItem = null;
            this.m_cboCI.SelectionStart = 0;
            this.m_cboCI.Size = new System.Drawing.Size(64, 23);
            this.m_cboCI.TabIndex = 49;
            this.m_cboCI.TextBackColor = System.Drawing.Color.White;
            this.m_cboCI.TextForeColor = System.Drawing.Color.Black;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(192, 192);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(14, 14);
            this.label35.TabIndex = 48;
            this.label35.Text = "-";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(176, 200);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(21, 14);
            this.label36.TabIndex = 47;
            this.label36.Text = "CI";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(128, 200);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 14);
            this.label33.TabIndex = 46;
            this.label33.Text = "mmol/L，";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboNa
            // 
            this.m_cboNa.AccessibleDescription = "辅助检查结果>>Na";
            this.m_cboNa.BorderColor = System.Drawing.Color.Black;
            this.m_cboNa.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboNa.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboNa.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboNa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboNa.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboNa.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboNa.ListBackColor = System.Drawing.Color.White;
            this.m_cboNa.ListForeColor = System.Drawing.Color.Black;
            this.m_cboNa.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboNa.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboNa.Location = new System.Drawing.Point(64, 200);
            this.m_cboNa.m_BlnEnableItemEventMenu = true;
            this.m_cboNa.Name = "m_cboNa";
            this.m_cboNa.SelectedIndex = -1;
            this.m_cboNa.SelectedItem = null;
            this.m_cboNa.SelectionStart = 0;
            this.m_cboNa.Size = new System.Drawing.Size(64, 23);
            this.m_cboNa.TabIndex = 45;
            this.m_cboNa.TextBackColor = System.Drawing.Color.White;
            this.m_cboNa.TextForeColor = System.Drawing.Color.Black;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(48, 192);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(14, 14);
            this.label31.TabIndex = 44;
            this.label31.Text = "+";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(32, 200);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(21, 14);
            this.label32.TabIndex = 43;
            this.label32.Text = "Na";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(24, 232);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 14);
            this.label30.TabIndex = 42;
            this.label30.Text = "肝炎系列";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(648, 160);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(14, 14);
            this.label29.TabIndex = 41;
            this.label29.Text = "+";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(744, 168);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 14);
            this.label28.TabIndex = 40;
            this.label28.Text = "mmol/L";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboTT
            // 
            this.m_cboTT.AccessibleDescription = "辅助检查结果>>TT";
            this.m_cboTT.BorderColor = System.Drawing.Color.Black;
            this.m_cboTT.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTT.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTT.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTT.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTT.ListBackColor = System.Drawing.Color.White;
            this.m_cboTT.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTT.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTT.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTT.Location = new System.Drawing.Point(360, 168);
            this.m_cboTT.m_BlnEnableItemEventMenu = true;
            this.m_cboTT.Name = "m_cboTT";
            this.m_cboTT.SelectedIndex = -1;
            this.m_cboTT.SelectedItem = null;
            this.m_cboTT.SelectionStart = 0;
            this.m_cboTT.Size = new System.Drawing.Size(64, 23);
            this.m_cboTT.TabIndex = 39;
            this.m_cboTT.TextBackColor = System.Drawing.Color.White;
            this.m_cboTT.TextForeColor = System.Drawing.Color.Black;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(424, 168);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 14);
            this.label27.TabIndex = 38;
            this.label27.Text = "sec，";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboHepatitis
            // 
            this.m_cboHepatitis.AccessibleDescription = "辅助检查结果>>肝炎系列";
            this.m_cboHepatitis.BorderColor = System.Drawing.Color.Black;
            this.m_cboHepatitis.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHepatitis.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboHepatitis.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHepatitis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHepatitis.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHepatitis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHepatitis.ListBackColor = System.Drawing.Color.White;
            this.m_cboHepatitis.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHepatitis.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHepatitis.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHepatitis.Location = new System.Drawing.Point(88, 232);
            this.m_cboHepatitis.m_BlnEnableItemEventMenu = true;
            this.m_cboHepatitis.Name = "m_cboHepatitis";
            this.m_cboHepatitis.SelectedIndex = -1;
            this.m_cboHepatitis.SelectedItem = null;
            this.m_cboHepatitis.SelectionStart = 0;
            this.m_cboHepatitis.Size = new System.Drawing.Size(160, 23);
            this.m_cboHepatitis.TabIndex = 37;
            this.m_cboHepatitis.TextBackColor = System.Drawing.Color.White;
            this.m_cboHepatitis.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboBloodK
            // 
            this.m_cboBloodK.AccessibleDescription = "辅助检查结果>>血K";
            this.m_cboBloodK.BorderColor = System.Drawing.Color.Black;
            this.m_cboBloodK.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBloodK.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboBloodK.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBloodK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBloodK.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBloodK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBloodK.ListBackColor = System.Drawing.Color.White;
            this.m_cboBloodK.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBloodK.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBloodK.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBloodK.Location = new System.Drawing.Point(664, 168);
            this.m_cboBloodK.m_BlnEnableItemEventMenu = true;
            this.m_cboBloodK.Name = "m_cboBloodK";
            this.m_cboBloodK.SelectedIndex = -1;
            this.m_cboBloodK.SelectedItem = null;
            this.m_cboBloodK.SelectionStart = 0;
            this.m_cboBloodK.Size = new System.Drawing.Size(80, 23);
            this.m_cboBloodK.TabIndex = 36;
            this.m_cboBloodK.TextBackColor = System.Drawing.Color.White;
            this.m_cboBloodK.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboUrineRt
            // 
            this.m_cboUrineRt.AccessibleDescription = "辅助检查结果>>尿Rt";
            this.m_cboUrineRt.BorderColor = System.Drawing.Color.Black;
            this.m_cboUrineRt.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboUrineRt.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboUrineRt.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboUrineRt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboUrineRt.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboUrineRt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboUrineRt.ListBackColor = System.Drawing.Color.White;
            this.m_cboUrineRt.ListForeColor = System.Drawing.Color.Black;
            this.m_cboUrineRt.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboUrineRt.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboUrineRt.Location = new System.Drawing.Point(536, 168);
            this.m_cboUrineRt.m_BlnEnableItemEventMenu = true;
            this.m_cboUrineRt.Name = "m_cboUrineRt";
            this.m_cboUrineRt.SelectedIndex = -1;
            this.m_cboUrineRt.SelectedItem = null;
            this.m_cboUrineRt.SelectionStart = 0;
            this.m_cboUrineRt.Size = new System.Drawing.Size(64, 23);
            this.m_cboUrineRt.TabIndex = 35;
            this.m_cboUrineRt.TextBackColor = System.Drawing.Color.White;
            this.m_cboUrineRt.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboAPTT
            // 
            this.m_cboAPTT.AccessibleDescription = "辅助检查结果>>APTT";
            this.m_cboAPTT.BorderColor = System.Drawing.Color.Black;
            this.m_cboAPTT.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAPTT.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboAPTT.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAPTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAPTT.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAPTT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAPTT.ListBackColor = System.Drawing.Color.White;
            this.m_cboAPTT.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAPTT.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboAPTT.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboAPTT.Location = new System.Drawing.Point(208, 168);
            this.m_cboAPTT.m_BlnEnableItemEventMenu = true;
            this.m_cboAPTT.Name = "m_cboAPTT";
            this.m_cboAPTT.SelectedIndex = -1;
            this.m_cboAPTT.SelectedItem = null;
            this.m_cboAPTT.SelectionStart = 0;
            this.m_cboAPTT.Size = new System.Drawing.Size(64, 23);
            this.m_cboAPTT.TabIndex = 34;
            this.m_cboAPTT.TextBackColor = System.Drawing.Color.White;
            this.m_cboAPTT.TextForeColor = System.Drawing.Color.Black;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(176, 168);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 14);
            this.label26.TabIndex = 33;
            this.label26.Text = "APTT";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(272, 168);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 14);
            this.label25.TabIndex = 32;
            this.label25.Text = "sec，";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(336, 168);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(21, 14);
            this.label24.TabIndex = 31;
            this.label24.Text = "TT";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(496, 168);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 14);
            this.label23.TabIndex = 30;
            this.label23.Text = "尿Rt";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(624, 168);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 14);
            this.label22.TabIndex = 29;
            this.label22.Text = "血K";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(128, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 14);
            this.label19.TabIndex = 28;
            this.label19.Text = "10";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(144, 160);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 12);
            this.label20.TabIndex = 27;
            this.label20.Text = "9";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(152, 168);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 14);
            this.label21.TabIndex = 26;
            this.label21.Text = "/L，";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(744, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 14);
            this.label18.TabIndex = 25;
            this.label18.Text = "%";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(424, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 14);
            this.label15.TabIndex = 24;
            this.label15.Text = "10";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(440, 128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 23;
            this.label16.Text = "9";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(448, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 14);
            this.label17.TabIndex = 22;
            this.label17.Text = "/L，";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(328, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 14);
            this.label14.TabIndex = 21;
            this.label14.Text = "WBC";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(488, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 20;
            this.label13.Text = "分类N";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(600, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "%，";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "PLT";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(632, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 14);
            this.label10.TabIndex = 17;
            this.label10.Text = "HCT";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboHCT
            // 
            this.m_cboHCT.AccessibleDescription = "辅助检查结果>>HCT";
            this.m_cboHCT.BorderColor = System.Drawing.Color.Black;
            this.m_cboHCT.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHCT.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboHCT.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHCT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHCT.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHCT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHCT.ListBackColor = System.Drawing.Color.White;
            this.m_cboHCT.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHCT.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHCT.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHCT.Location = new System.Drawing.Point(664, 136);
            this.m_cboHCT.m_BlnEnableItemEventMenu = true;
            this.m_cboHCT.Name = "m_cboHCT";
            this.m_cboHCT.SelectedIndex = -1;
            this.m_cboHCT.SelectedItem = null;
            this.m_cboHCT.SelectionStart = 0;
            this.m_cboHCT.Size = new System.Drawing.Size(80, 23);
            this.m_cboHCT.TabIndex = 16;
            this.m_cboHCT.TextBackColor = System.Drawing.Color.White;
            this.m_cboHCT.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboSort
            // 
            this.m_cboSort.AccessibleDescription = "辅助检查结果>>分类N";
            this.m_cboSort.BorderColor = System.Drawing.Color.Black;
            this.m_cboSort.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboSort.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboSort.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboSort.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSort.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSort.ListBackColor = System.Drawing.Color.White;
            this.m_cboSort.ListForeColor = System.Drawing.Color.Black;
            this.m_cboSort.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboSort.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboSort.Location = new System.Drawing.Point(536, 136);
            this.m_cboSort.m_BlnEnableItemEventMenu = true;
            this.m_cboSort.Name = "m_cboSort";
            this.m_cboSort.SelectedIndex = -1;
            this.m_cboSort.SelectedItem = null;
            this.m_cboSort.SelectionStart = 0;
            this.m_cboSort.Size = new System.Drawing.Size(64, 23);
            this.m_cboSort.TabIndex = 15;
            this.m_cboSort.TextBackColor = System.Drawing.Color.White;
            this.m_cboSort.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboMasculineCharacter
            // 
            this.m_cboMasculineCharacter.AccessibleDescription = "阳性体征";
            this.m_cboMasculineCharacter.BorderColor = System.Drawing.Color.Black;
            this.m_cboMasculineCharacter.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMasculineCharacter.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboMasculineCharacter.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMasculineCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMasculineCharacter.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMasculineCharacter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMasculineCharacter.ListBackColor = System.Drawing.Color.White;
            this.m_cboMasculineCharacter.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMasculineCharacter.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMasculineCharacter.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMasculineCharacter.Location = new System.Drawing.Point(104, 72);
            this.m_cboMasculineCharacter.m_BlnEnableItemEventMenu = true;
            this.m_cboMasculineCharacter.Name = "m_cboMasculineCharacter";
            this.m_cboMasculineCharacter.SelectedIndex = -1;
            this.m_cboMasculineCharacter.SelectedItem = null;
            this.m_cboMasculineCharacter.SelectionStart = 0;
            this.m_cboMasculineCharacter.Size = new System.Drawing.Size(648, 23);
            this.m_cboMasculineCharacter.TabIndex = 14;
            this.m_cboMasculineCharacter.TextBackColor = System.Drawing.Color.White;
            this.m_cboMasculineCharacter.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboHb
            // 
            this.m_cboHb.AccessibleDescription = "辅助检查结果>>Hb";
            this.m_cboHb.BorderColor = System.Drawing.Color.Black;
            this.m_cboHb.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHb.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboHb.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHb.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHb.ListBackColor = System.Drawing.Color.White;
            this.m_cboHb.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHb.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHb.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHb.Location = new System.Drawing.Point(64, 136);
            this.m_cboHb.m_BlnEnableItemEventMenu = true;
            this.m_cboHb.Name = "m_cboHb";
            this.m_cboHb.SelectedIndex = -1;
            this.m_cboHb.SelectedItem = null;
            this.m_cboHb.SelectionStart = 0;
            this.m_cboHb.Size = new System.Drawing.Size(64, 23);
            this.m_cboHb.TabIndex = 13;
            this.m_cboHb.TextBackColor = System.Drawing.Color.White;
            this.m_cboHb.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboWBC
            // 
            this.m_cboWBC.AccessibleDescription = "辅助检查结果>>WBC";
            this.m_cboWBC.BorderColor = System.Drawing.Color.Black;
            this.m_cboWBC.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboWBC.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboWBC.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboWBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboWBC.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboWBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboWBC.ListBackColor = System.Drawing.Color.White;
            this.m_cboWBC.ListForeColor = System.Drawing.Color.Black;
            this.m_cboWBC.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboWBC.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboWBC.Location = new System.Drawing.Point(360, 136);
            this.m_cboWBC.m_BlnEnableItemEventMenu = true;
            this.m_cboWBC.Name = "m_cboWBC";
            this.m_cboWBC.SelectedIndex = -1;
            this.m_cboWBC.SelectedItem = null;
            this.m_cboWBC.SelectionStart = 0;
            this.m_cboWBC.Size = new System.Drawing.Size(64, 23);
            this.m_cboWBC.TabIndex = 12;
            this.m_cboWBC.TextBackColor = System.Drawing.Color.White;
            this.m_cboWBC.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPLT
            // 
            this.m_cboPLT.AccessibleDescription = "辅助检查结果>>PLT";
            this.m_cboPLT.BorderColor = System.Drawing.Color.Black;
            this.m_cboPLT.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPLT.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboPLT.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPLT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPLT.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPLT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPLT.ListBackColor = System.Drawing.Color.White;
            this.m_cboPLT.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPLT.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPLT.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPLT.Location = new System.Drawing.Point(64, 168);
            this.m_cboPLT.m_BlnEnableItemEventMenu = true;
            this.m_cboPLT.Name = "m_cboPLT";
            this.m_cboPLT.SelectedIndex = -1;
            this.m_cboPLT.SelectedItem = null;
            this.m_cboPLT.SelectionStart = 0;
            this.m_cboPLT.Size = new System.Drawing.Size(64, 23);
            this.m_cboPLT.TabIndex = 11;
            this.m_cboPLT.TextBackColor = System.Drawing.Color.White;
            this.m_cboPLT.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboRBC
            // 
            this.m_cboRBC.AccessibleDescription = "辅助检查结果>>RBC";
            this.m_cboRBC.BorderColor = System.Drawing.Color.Black;
            this.m_cboRBC.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboRBC.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboRBC.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboRBC.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRBC.ListBackColor = System.Drawing.Color.White;
            this.m_cboRBC.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRBC.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRBC.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRBC.Location = new System.Drawing.Point(208, 136);
            this.m_cboRBC.m_BlnEnableItemEventMenu = true;
            this.m_cboRBC.Name = "m_cboRBC";
            this.m_cboRBC.SelectedIndex = -1;
            this.m_cboRBC.SelectedItem = null;
            this.m_cboRBC.SelectionStart = 0;
            this.m_cboRBC.Size = new System.Drawing.Size(64, 23);
            this.m_cboRBC.TabIndex = 10;
            this.m_cboRBC.TextBackColor = System.Drawing.Color.White;
            this.m_cboRBC.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboEspecialHistory
            // 
            this.m_cboEspecialHistory.AccessibleDescription = "特殊病史";
            this.m_cboEspecialHistory.BorderColor = System.Drawing.Color.Black;
            this.m_cboEspecialHistory.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboEspecialHistory.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboEspecialHistory.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboEspecialHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboEspecialHistory.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEspecialHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEspecialHistory.ListBackColor = System.Drawing.Color.White;
            this.m_cboEspecialHistory.ListForeColor = System.Drawing.Color.Black;
            this.m_cboEspecialHistory.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboEspecialHistory.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboEspecialHistory.Location = new System.Drawing.Point(104, 40);
            this.m_cboEspecialHistory.m_BlnEnableItemEventMenu = true;
            this.m_cboEspecialHistory.Name = "m_cboEspecialHistory";
            this.m_cboEspecialHistory.SelectedIndex = -1;
            this.m_cboEspecialHistory.SelectedItem = null;
            this.m_cboEspecialHistory.SelectionStart = 0;
            this.m_cboEspecialHistory.Size = new System.Drawing.Size(648, 23);
            this.m_cboEspecialHistory.TabIndex = 9;
            this.m_cboEspecialHistory.TextBackColor = System.Drawing.Color.White;
            this.m_cboEspecialHistory.TextForeColor = System.Drawing.Color.Black;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "特殊病史：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "阳性体征：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "辅助检查结果：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hb";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "g/L，RBC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "10";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(288, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "12";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "/L，";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "术前访视";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label83);
            this.tabPage2.Controls.Add(this.m_cboMAPEspecial);
            this.tabPage2.Controls.Add(this.panel18);
            this.tabPage2.Controls.Add(this.panel19);
            this.tabPage2.Controls.Add(this.label82);
            this.tabPage2.Controls.Add(this.label81);
            this.tabPage2.Controls.Add(this.m_cboCVPEspecial);
            this.tabPage2.Controls.Add(this.panel17);
            this.tabPage2.Controls.Add(this.panel16);
            this.tabPage2.Controls.Add(this.panel15);
            this.tabPage2.Controls.Add(this.label80);
            this.tabPage2.Controls.Add(this.label79);
            this.tabPage2.Controls.Add(this.m_cboSpecial);
            this.tabPage2.Controls.Add(this.label77);
            this.tabPage2.Controls.Add(this.label78);
            this.tabPage2.Controls.Add(this.m_cboCleaarPostOperate);
            this.tabPage2.Controls.Add(this.panel14);
            this.tabPage2.Controls.Add(this.label76);
            this.tabPage2.Controls.Add(this.panel12);
            this.tabPage2.Controls.Add(this.label75);
            this.tabPage2.Controls.Add(this.panel13);
            this.tabPage2.Controls.Add(this.label73);
            this.tabPage2.Controls.Add(this.m_cboBlockRoad);
            this.tabPage2.Controls.Add(this.label74);
            this.tabPage2.Controls.Add(this.m_cboEspecialInstuation);
            this.tabPage2.Controls.Add(this.panel9);
            this.tabPage2.Controls.Add(this.label72);
            this.tabPage2.Controls.Add(this.label71);
            this.tabPage2.Controls.Add(this.label69);
            this.tabPage2.Controls.Add(this.m_cboInfuse);
            this.tabPage2.Controls.Add(this.label68);
            this.tabPage2.Controls.Add(this.panel10);
            this.tabPage2.Controls.Add(this.label70);
            this.tabPage2.Controls.Add(this.panel11);
            this.tabPage2.Controls.Add(this.m_cbosecInfuse);
            this.tabPage2.Controls.Add(this.label67);
            this.tabPage2.Controls.Add(this.m_cboSmallNumState);
            this.tabPage2.Controls.Add(this.label66);
            this.tabPage2.Controls.Add(this.m_cboEspecialCircs);
            this.tabPage2.Controls.Add(this.label65);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Controls.Add(this.label64);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.label63);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.label62);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.label61);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.label60);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.m_cboChangeState);
            this.tabPage2.Controls.Add(this.m_cboCause);
            this.tabPage2.Controls.Add(this.label57);
            this.tabPage2.Controls.Add(this.label58);
            this.tabPage2.Controls.Add(this.label59);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "第二页";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(344, 352);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(77, 14);
            this.label83.TabIndex = 75;
            this.label83.Text = "特殊情况：";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboMAPEspecial
            // 
            this.m_cboMAPEspecial.AccessibleDescription = "MAP>>特殊情况";
            this.m_cboMAPEspecial.BorderColor = System.Drawing.Color.Black;
            this.m_cboMAPEspecial.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMAPEspecial.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboMAPEspecial.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMAPEspecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMAPEspecial.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMAPEspecial.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMAPEspecial.ListBackColor = System.Drawing.Color.White;
            this.m_cboMAPEspecial.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMAPEspecial.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMAPEspecial.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMAPEspecial.Location = new System.Drawing.Point(424, 352);
            this.m_cboMAPEspecial.m_BlnEnableItemEventMenu = true;
            this.m_cboMAPEspecial.Name = "m_cboMAPEspecial";
            this.m_cboMAPEspecial.SelectedIndex = -1;
            this.m_cboMAPEspecial.SelectedItem = null;
            this.m_cboMAPEspecial.SelectionStart = 0;
            this.m_cboMAPEspecial.Size = new System.Drawing.Size(360, 23);
            this.m_cboMAPEspecial.TabIndex = 74;
            this.m_cboMAPEspecial.TextBackColor = System.Drawing.Color.White;
            this.m_cboMAPEspecial.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.m_chkMAPFoot);
            this.panel18.Controls.Add(this.m_chkMAPThigh);
            this.panel18.Controls.Add(this.m_chkFlinch);
            this.panel18.Location = new System.Drawing.Point(152, 344);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(192, 32);
            this.panel18.TabIndex = 73;
            // 
            // m_chkMAPFoot
            // 
            this.m_chkMAPFoot.AccessibleDescription = "MAP>>足背A";
            this.m_chkMAPFoot.Location = new System.Drawing.Point(120, 8);
            this.m_chkMAPFoot.Name = "m_chkMAPFoot";
            this.m_chkMAPFoot.Size = new System.Drawing.Size(64, 24);
            this.m_chkMAPFoot.TabIndex = 62;
            this.m_chkMAPFoot.Text = "足背A";
            // 
            // m_chkMAPThigh
            // 
            this.m_chkMAPThigh.AccessibleDescription = "MAP>>股A";
            this.m_chkMAPThigh.Location = new System.Drawing.Point(64, 8);
            this.m_chkMAPThigh.Name = "m_chkMAPThigh";
            this.m_chkMAPThigh.Size = new System.Drawing.Size(48, 24);
            this.m_chkMAPThigh.TabIndex = 59;
            this.m_chkMAPThigh.Text = "股A";
            // 
            // m_chkFlinch
            // 
            this.m_chkFlinch.AccessibleDescription = "MAP>>挠A";
            this.m_chkFlinch.Location = new System.Drawing.Point(8, 8);
            this.m_chkFlinch.Name = "m_chkFlinch";
            this.m_chkFlinch.Size = new System.Drawing.Size(56, 24);
            this.m_chkFlinch.TabIndex = 58;
            this.m_chkFlinch.Text = "挠A";
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.m_rdbMAPLeft);
            this.panel19.Controls.Add(this.m_rdbMAPRight);
            this.panel19.Location = new System.Drawing.Point(72, 344);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(88, 32);
            this.panel19.TabIndex = 72;
            // 
            // m_rdbMAPLeft
            // 
            this.m_rdbMAPLeft.AccessibleDescription = "MAP>>左";
            this.m_rdbMAPLeft.Location = new System.Drawing.Point(40, 8);
            this.m_rdbMAPLeft.Name = "m_rdbMAPLeft";
            this.m_rdbMAPLeft.Size = new System.Drawing.Size(32, 24);
            this.m_rdbMAPLeft.TabIndex = 21;
            this.m_rdbMAPLeft.Text = "左";
            // 
            // m_rdbMAPRight
            // 
            this.m_rdbMAPRight.AccessibleDescription = "MAP>>右";
            this.m_rdbMAPRight.Location = new System.Drawing.Point(8, 8);
            this.m_rdbMAPRight.Name = "m_rdbMAPRight";
            this.m_rdbMAPRight.Size = new System.Drawing.Size(40, 24);
            this.m_rdbMAPRight.TabIndex = 20;
            this.m_rdbMAPRight.Text = "右";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(40, 352);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(42, 14);
            this.label82.TabIndex = 71;
            this.label82.Text = "MAP：";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(584, 320);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(70, 14);
            this.label81.TabIndex = 70;
            this.label81.Text = "特殊情况:";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboCVPEspecial
            // 
            this.m_cboCVPEspecial.AccessibleDescription = "CVP>>特殊情况";
            this.m_cboCVPEspecial.BorderColor = System.Drawing.Color.Black;
            this.m_cboCVPEspecial.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCVPEspecial.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboCVPEspecial.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCVPEspecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCVPEspecial.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCVPEspecial.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCVPEspecial.ListBackColor = System.Drawing.Color.White;
            this.m_cboCVPEspecial.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCVPEspecial.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCVPEspecial.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCVPEspecial.Location = new System.Drawing.Point(656, 320);
            this.m_cboCVPEspecial.m_BlnEnableItemEventMenu = true;
            this.m_cboCVPEspecial.Name = "m_cboCVPEspecial";
            this.m_cboCVPEspecial.SelectedIndex = -1;
            this.m_cboCVPEspecial.SelectedItem = null;
            this.m_cboCVPEspecial.SelectionStart = 0;
            this.m_cboCVPEspecial.Size = new System.Drawing.Size(128, 23);
            this.m_cboCVPEspecial.TabIndex = 69;
            this.m_cboCVPEspecial.TextBackColor = System.Drawing.Color.White;
            this.m_cboCVPEspecial.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.m_rdbFloating);
            this.panel17.Controls.Add(this.m_rdbAntrum);
            this.panel17.Controls.Add(this.m_rdbkSingleAntrum);
            this.panel17.Location = new System.Drawing.Point(400, 312);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(184, 32);
            this.panel17.TabIndex = 68;
            // 
            // m_rdbFloating
            // 
            this.m_rdbFloating.AccessibleDescription = "CVP>>漂浮导管";
            this.m_rdbFloating.Location = new System.Drawing.Point(104, 8);
            this.m_rdbFloating.Name = "m_rdbFloating";
            this.m_rdbFloating.Size = new System.Drawing.Size(88, 24);
            this.m_rdbFloating.TabIndex = 22;
            this.m_rdbFloating.Text = "漂浮导管";
            // 
            // m_rdbAntrum
            // 
            this.m_rdbAntrum.AccessibleDescription = "CVP>>双腔";
            this.m_rdbAntrum.Location = new System.Drawing.Point(56, 8);
            this.m_rdbAntrum.Name = "m_rdbAntrum";
            this.m_rdbAntrum.Size = new System.Drawing.Size(56, 24);
            this.m_rdbAntrum.TabIndex = 21;
            this.m_rdbAntrum.Text = "双腔";
            // 
            // m_rdbkSingleAntrum
            // 
            this.m_rdbkSingleAntrum.AccessibleDescription = "CVP>>单腔";
            this.m_rdbkSingleAntrum.Location = new System.Drawing.Point(8, 8);
            this.m_rdbkSingleAntrum.Name = "m_rdbkSingleAntrum";
            this.m_rdbkSingleAntrum.Size = new System.Drawing.Size(56, 24);
            this.m_rdbkSingleAntrum.TabIndex = 20;
            this.m_rdbkSingleAntrum.Text = "单腔";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.m_chkThighV);
            this.panel16.Controls.Add(this.m_chkCVPNeckOut);
            this.panel16.Controls.Add(this.m_chkCVPClavicle);
            this.panel16.Controls.Add(this.m_chkCVPNeck);
            this.panel16.Location = new System.Drawing.Point(152, 312);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(256, 32);
            this.panel16.TabIndex = 67;
            // 
            // m_chkThighV
            // 
            this.m_chkThighV.AccessibleDescription = "CVP>>股V";
            this.m_chkThighV.Location = new System.Drawing.Point(144, 8);
            this.m_chkThighV.Name = "m_chkThighV";
            this.m_chkThighV.Size = new System.Drawing.Size(48, 24);
            this.m_chkThighV.TabIndex = 62;
            this.m_chkThighV.Text = "股V";
            // 
            // m_chkCVPNeckOut
            // 
            this.m_chkCVPNeckOut.AccessibleDescription = "CVP>>颈外V";
            this.m_chkCVPNeckOut.Location = new System.Drawing.Point(192, 8);
            this.m_chkCVPNeckOut.Name = "m_chkCVPNeckOut";
            this.m_chkCVPNeckOut.Size = new System.Drawing.Size(64, 24);
            this.m_chkCVPNeckOut.TabIndex = 60;
            this.m_chkCVPNeckOut.Text = "颈外V";
            // 
            // m_chkCVPClavicle
            // 
            this.m_chkCVPClavicle.AccessibleDescription = "CVP>>锁骨下V";
            this.m_chkCVPClavicle.Location = new System.Drawing.Point(64, 8);
            this.m_chkCVPClavicle.Name = "m_chkCVPClavicle";
            this.m_chkCVPClavicle.Size = new System.Drawing.Size(80, 24);
            this.m_chkCVPClavicle.TabIndex = 59;
            this.m_chkCVPClavicle.Text = "锁骨下V";
            // 
            // m_chkCVPNeck
            // 
            this.m_chkCVPNeck.AccessibleDescription = "CVP>>颈内";
            this.m_chkCVPNeck.Location = new System.Drawing.Point(8, 8);
            this.m_chkCVPNeck.Name = "m_chkCVPNeck";
            this.m_chkCVPNeck.Size = new System.Drawing.Size(56, 24);
            this.m_chkCVPNeck.TabIndex = 58;
            this.m_chkCVPNeck.Text = "颈内";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.m_rdbCVPLeft);
            this.panel15.Controls.Add(this.m_rdbCVPRight);
            this.panel15.Location = new System.Drawing.Point(72, 312);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(88, 32);
            this.panel15.TabIndex = 66;
            // 
            // m_rdbCVPLeft
            // 
            this.m_rdbCVPLeft.AccessibleDescription = "CVP>>左";
            this.m_rdbCVPLeft.Location = new System.Drawing.Point(40, 8);
            this.m_rdbCVPLeft.Name = "m_rdbCVPLeft";
            this.m_rdbCVPLeft.Size = new System.Drawing.Size(32, 24);
            this.m_rdbCVPLeft.TabIndex = 21;
            this.m_rdbCVPLeft.Text = "左";
            // 
            // m_rdbCVPRight
            // 
            this.m_rdbCVPRight.AccessibleDescription = "CVP>>右";
            this.m_rdbCVPRight.Location = new System.Drawing.Point(8, 8);
            this.m_rdbCVPRight.Name = "m_rdbCVPRight";
            this.m_rdbCVPRight.Size = new System.Drawing.Size(40, 24);
            this.m_rdbCVPRight.TabIndex = 20;
            this.m_rdbCVPRight.Text = "右";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(40, 320);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(42, 14);
            this.label80.TabIndex = 65;
            this.label80.Text = "CVP：";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(584, 288);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(70, 14);
            this.label79.TabIndex = 64;
            this.label79.Text = "特殊情况:";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboSpecial
            // 
            this.m_cboSpecial.AccessibleDescription = "术后苏醒期>>特殊情况";
            this.m_cboSpecial.BorderColor = System.Drawing.Color.Black;
            this.m_cboSpecial.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboSpecial.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboSpecial.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboSpecial.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSpecial.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSpecial.ListBackColor = System.Drawing.Color.White;
            this.m_cboSpecial.ListForeColor = System.Drawing.Color.Black;
            this.m_cboSpecial.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboSpecial.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboSpecial.Location = new System.Drawing.Point(656, 286);
            this.m_cboSpecial.m_BlnEnableItemEventMenu = true;
            this.m_cboSpecial.Name = "m_cboSpecial";
            this.m_cboSpecial.SelectedIndex = -1;
            this.m_cboSpecial.SelectedItem = null;
            this.m_cboSpecial.SelectionStart = 0;
            this.m_cboSpecial.Size = new System.Drawing.Size(128, 23);
            this.m_cboSpecial.TabIndex = 63;
            this.m_cboSpecial.TextBackColor = System.Drawing.Color.White;
            this.m_cboSpecial.TextForeColor = System.Drawing.Color.Black;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(560, 288);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(35, 14);
            this.label77.TabIndex = 62;
            this.label77.Text = "ml，";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(376, 288);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(105, 14);
            this.label78.TabIndex = 61;
            this.label78.Text = "清醒时间在术后";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboCleaarPostOperate
            // 
            this.m_cboCleaarPostOperate.AccessibleDescription = "术后苏醒期>>清醒时间在术后";
            this.m_cboCleaarPostOperate.BorderColor = System.Drawing.Color.Black;
            this.m_cboCleaarPostOperate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCleaarPostOperate.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboCleaarPostOperate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCleaarPostOperate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCleaarPostOperate.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCleaarPostOperate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCleaarPostOperate.ListBackColor = System.Drawing.Color.White;
            this.m_cboCleaarPostOperate.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCleaarPostOperate.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCleaarPostOperate.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCleaarPostOperate.Location = new System.Drawing.Point(488, 288);
            this.m_cboCleaarPostOperate.m_BlnEnableItemEventMenu = true;
            this.m_cboCleaarPostOperate.Name = "m_cboCleaarPostOperate";
            this.m_cboCleaarPostOperate.SelectedIndex = -1;
            this.m_cboCleaarPostOperate.SelectedItem = null;
            this.m_cboCleaarPostOperate.SelectionStart = 0;
            this.m_cboCleaarPostOperate.Size = new System.Drawing.Size(72, 23);
            this.m_cboCleaarPostOperate.TabIndex = 60;
            this.m_cboCleaarPostOperate.TextBackColor = System.Drawing.Color.White;
            this.m_cboCleaarPostOperate.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.m_rdbNotPlacidity);
            this.panel14.Controls.Add(this.m_rdbShortPlacidity);
            this.panel14.Controls.Add(this.m_rdbEvenPlacidity);
            this.panel14.Controls.Add(this.m_rdbPlacidity);
            this.panel14.Location = new System.Drawing.Point(120, 280);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(256, 32);
            this.panel14.TabIndex = 59;
            // 
            // m_rdbNotPlacidity
            // 
            this.m_rdbNotPlacidity.AccessibleDescription = "术后苏醒期>>不平稳";
            this.m_rdbNotPlacidity.Location = new System.Drawing.Point(184, 8);
            this.m_rdbNotPlacidity.Name = "m_rdbNotPlacidity";
            this.m_rdbNotPlacidity.Size = new System.Drawing.Size(72, 24);
            this.m_rdbNotPlacidity.TabIndex = 23;
            this.m_rdbNotPlacidity.Text = "不平稳";
            // 
            // m_rdbShortPlacidity
            // 
            this.m_rdbShortPlacidity.AccessibleDescription = "术后苏醒期>>欠平稳";
            this.m_rdbShortPlacidity.Location = new System.Drawing.Point(120, 8);
            this.m_rdbShortPlacidity.Name = "m_rdbShortPlacidity";
            this.m_rdbShortPlacidity.Size = new System.Drawing.Size(72, 24);
            this.m_rdbShortPlacidity.TabIndex = 22;
            this.m_rdbShortPlacidity.Text = "欠平稳";
            // 
            // m_rdbEvenPlacidity
            // 
            this.m_rdbEvenPlacidity.AccessibleDescription = "术后苏醒期>>尚平稳";
            this.m_rdbEvenPlacidity.Location = new System.Drawing.Point(56, 8);
            this.m_rdbEvenPlacidity.Name = "m_rdbEvenPlacidity";
            this.m_rdbEvenPlacidity.Size = new System.Drawing.Size(72, 24);
            this.m_rdbEvenPlacidity.TabIndex = 21;
            this.m_rdbEvenPlacidity.Text = "尚平稳";
            // 
            // m_rdbPlacidity
            // 
            this.m_rdbPlacidity.AccessibleDescription = "术后苏醒期>>平稳";
            this.m_rdbPlacidity.Location = new System.Drawing.Point(8, 8);
            this.m_rdbPlacidity.Name = "m_rdbPlacidity";
            this.m_rdbPlacidity.Size = new System.Drawing.Size(56, 24);
            this.m_rdbPlacidity.TabIndex = 20;
            this.m_rdbPlacidity.Text = "平稳";
            this.m_rdbPlacidity.CheckedChanged += new System.EventHandler(this.m_rdbPlacidity_CheckedChanged);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(40, 288);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(91, 14);
            this.label76.TabIndex = 58;
            this.label76.Text = "术后苏醒期：";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.m_chkEffectBad);
            this.panel12.Controls.Add(this.m_chkReinforceHocus);
            this.panel12.Controls.Add(this.m_chkAbirritative);
            this.panel12.Controls.Add(this.m_chkFullVein);
            this.panel12.Location = new System.Drawing.Point(208, 248);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(472, 32);
            this.panel12.TabIndex = 57;
            // 
            // m_chkEffectBad
            // 
            this.m_chkEffectBad.AccessibleDescription = "静脉复合麻醉>>使用目的>>原麻醉效果差";
            this.m_chkEffectBad.Location = new System.Drawing.Point(336, 8);
            this.m_chkEffectBad.Name = "m_chkEffectBad";
            this.m_chkEffectBad.Size = new System.Drawing.Size(120, 24);
            this.m_chkEffectBad.TabIndex = 61;
            this.m_chkEffectBad.Text = "原麻醉效果差";
            // 
            // m_chkReinforceHocus
            // 
            this.m_chkReinforceHocus.AccessibleDescription = "静脉复合麻醉>>使用目的>>加强原麻醉作用";
            this.m_chkReinforceHocus.Location = new System.Drawing.Point(208, 8);
            this.m_chkReinforceHocus.Name = "m_chkReinforceHocus";
            this.m_chkReinforceHocus.Size = new System.Drawing.Size(128, 24);
            this.m_chkReinforceHocus.TabIndex = 60;
            this.m_chkReinforceHocus.Text = "加强原麻醉作用";
            // 
            // m_chkAbirritative
            // 
            this.m_chkAbirritative.AccessibleDescription = "静脉复合麻醉>>使用目的>>消除紧张";
            this.m_chkAbirritative.Location = new System.Drawing.Point(120, 8);
            this.m_chkAbirritative.Name = "m_chkAbirritative";
            this.m_chkAbirritative.Size = new System.Drawing.Size(88, 24);
            this.m_chkAbirritative.TabIndex = 59;
            this.m_chkAbirritative.Text = "消除紧张";
            // 
            // m_chkFullVein
            // 
            this.m_chkFullVein.AccessibleDescription = "静脉复合麻醉>>使用目的>>全凭静脉麻醉";
            this.m_chkFullVein.Location = new System.Drawing.Point(8, 8);
            this.m_chkFullVein.Name = "m_chkFullVein";
            this.m_chkFullVein.Size = new System.Drawing.Size(112, 24);
            this.m_chkFullVein.TabIndex = 58;
            this.m_chkFullVein.Text = "全凭静脉麻醉";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(144, 256);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(77, 14);
            this.label75.TabIndex = 56;
            this.label75.Text = "使用目的：";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.m_chkIntravenous);
            this.panel13.Location = new System.Drawing.Point(24, 248);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(128, 32);
            this.panel13.TabIndex = 55;
            // 
            // m_chkIntravenous
            // 
            this.m_chkIntravenous.AccessibleDescription = "静脉复合麻醉";
            this.m_chkIntravenous.Location = new System.Drawing.Point(0, 8);
            this.m_chkIntravenous.Name = "m_chkIntravenous";
            this.m_chkIntravenous.Size = new System.Drawing.Size(144, 24);
            this.m_chkIntravenous.TabIndex = 0;
            this.m_chkIntravenous.Text = "静脉复合麻醉：";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(136, 224);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(119, 14);
            this.label73.TabIndex = 54;
            this.label73.Text = "阻滞部位及路径：";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboBlockRoad
            // 
            this.m_cboBlockRoad.AccessibleDescription = "神经阻滞麻醉>>阻滞部位及路径";
            this.m_cboBlockRoad.BorderColor = System.Drawing.Color.Black;
            this.m_cboBlockRoad.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBlockRoad.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboBlockRoad.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBlockRoad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBlockRoad.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBlockRoad.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBlockRoad.ListBackColor = System.Drawing.Color.White;
            this.m_cboBlockRoad.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBlockRoad.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBlockRoad.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBlockRoad.Location = new System.Drawing.Point(256, 224);
            this.m_cboBlockRoad.m_BlnEnableItemEventMenu = true;
            this.m_cboBlockRoad.Name = "m_cboBlockRoad";
            this.m_cboBlockRoad.SelectedIndex = -1;
            this.m_cboBlockRoad.SelectedItem = null;
            this.m_cboBlockRoad.SelectionStart = 0;
            this.m_cboBlockRoad.Size = new System.Drawing.Size(208, 23);
            this.m_cboBlockRoad.TabIndex = 53;
            this.m_cboBlockRoad.TextBackColor = System.Drawing.Color.White;
            this.m_cboBlockRoad.TextForeColor = System.Drawing.Color.Black;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(488, 224);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(77, 14);
            this.label74.TabIndex = 52;
            this.label74.Text = "特殊情况：";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboEspecialInstuation
            // 
            this.m_cboEspecialInstuation.AccessibleDescription = "神经阻滞麻醉>>特殊情况";
            this.m_cboEspecialInstuation.BorderColor = System.Drawing.Color.Black;
            this.m_cboEspecialInstuation.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboEspecialInstuation.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboEspecialInstuation.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboEspecialInstuation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboEspecialInstuation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEspecialInstuation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEspecialInstuation.ListBackColor = System.Drawing.Color.White;
            this.m_cboEspecialInstuation.ListForeColor = System.Drawing.Color.Black;
            this.m_cboEspecialInstuation.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboEspecialInstuation.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboEspecialInstuation.Location = new System.Drawing.Point(568, 224);
            this.m_cboEspecialInstuation.m_BlnEnableItemEventMenu = true;
            this.m_cboEspecialInstuation.Name = "m_cboEspecialInstuation";
            this.m_cboEspecialInstuation.SelectedIndex = -1;
            this.m_cboEspecialInstuation.SelectedItem = null;
            this.m_cboEspecialInstuation.SelectionStart = 0;
            this.m_cboEspecialInstuation.Size = new System.Drawing.Size(216, 23);
            this.m_cboEspecialInstuation.TabIndex = 51;
            this.m_cboEspecialInstuation.TextBackColor = System.Drawing.Color.White;
            this.m_cboEspecialInstuation.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.checkBox4);
            this.panel9.Location = new System.Drawing.Point(24, 216);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(128, 32);
            this.panel9.TabIndex = 50;
            // 
            // checkBox4
            // 
            this.checkBox4.AccessibleDescription = "神经阻滞麻醉";
            this.checkBox4.Location = new System.Drawing.Point(0, 8);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(144, 24);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "神经阻滞麻醉：";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(544, 192);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(21, 14);
            this.label72.TabIndex = 49;
            this.label72.Text = "在";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(472, 192);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(35, 14);
            this.label71.TabIndex = 48;
            this.label71.Text = "ml，";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(360, 192);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(35, 14);
            this.label69.TabIndex = 47;
            this.label69.Text = "注药";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboInfuse
            // 
            this.m_cboInfuse.AccessibleDescription = "蛛网膜下腔麻醉>>注药";
            this.m_cboInfuse.BorderColor = System.Drawing.Color.Black;
            this.m_cboInfuse.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboInfuse.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboInfuse.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboInfuse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboInfuse.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboInfuse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboInfuse.ListBackColor = System.Drawing.Color.White;
            this.m_cboInfuse.ListForeColor = System.Drawing.Color.Black;
            this.m_cboInfuse.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboInfuse.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboInfuse.Location = new System.Drawing.Point(400, 192);
            this.m_cboInfuse.m_BlnEnableItemEventMenu = true;
            this.m_cboInfuse.Name = "m_cboInfuse";
            this.m_cboInfuse.SelectedIndex = -1;
            this.m_cboInfuse.SelectedItem = null;
            this.m_cboInfuse.SelectionStart = 0;
            this.m_cboInfuse.Size = new System.Drawing.Size(72, 23);
            this.m_cboInfuse.TabIndex = 46;
            this.m_cboInfuse.TextBackColor = System.Drawing.Color.White;
            this.m_cboInfuse.TextForeColor = System.Drawing.Color.Black;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(672, 192);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(70, 14);
            this.label68.TabIndex = 45;
            this.label68.Text = "sec内注完";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.m_rdbNotFluenty);
            this.panel10.Controls.Add(this.m_rdbFluency);
            this.panel10.Location = new System.Drawing.Point(192, 184);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(156, 32);
            this.panel10.TabIndex = 42;
            // 
            // m_rdbNotFluenty
            // 
            this.m_rdbNotFluenty.AccessibleDescription = "蛛网膜下腔麻醉>>脑脊液>>不流畅";
            this.m_rdbNotFluenty.Location = new System.Drawing.Point(64, 8);
            this.m_rdbNotFluenty.Name = "m_rdbNotFluenty";
            this.m_rdbNotFluenty.Size = new System.Drawing.Size(72, 24);
            this.m_rdbNotFluenty.TabIndex = 21;
            this.m_rdbNotFluenty.Text = "不流畅";
            // 
            // m_rdbFluency
            // 
            this.m_rdbFluency.AccessibleDescription = "蛛网膜下腔麻醉>>脑脊液>>流畅";
            this.m_rdbFluency.Location = new System.Drawing.Point(8, 8);
            this.m_rdbFluency.Name = "m_rdbFluency";
            this.m_rdbFluency.Size = new System.Drawing.Size(56, 24);
            this.m_rdbFluency.TabIndex = 20;
            this.m_rdbFluency.Text = "流畅";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(144, 192);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(63, 14);
            this.label70.TabIndex = 41;
            this.label70.Text = "脑脊液：";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.m_chkCobwebby);
            this.panel11.Location = new System.Drawing.Point(24, 184);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(128, 32);
            this.panel11.TabIndex = 40;
            // 
            // m_chkCobwebby
            // 
            this.m_chkCobwebby.AccessibleDescription = "蛛网膜下腔麻醉";
            this.m_chkCobwebby.Location = new System.Drawing.Point(0, 8);
            this.m_chkCobwebby.Name = "m_chkCobwebby";
            this.m_chkCobwebby.Size = new System.Drawing.Size(144, 24);
            this.m_chkCobwebby.TabIndex = 0;
            this.m_chkCobwebby.Text = "蛛网膜下腔麻醉：";
            // 
            // m_cbosecInfuse
            // 
            this.m_cbosecInfuse.AccessibleDescription = "蛛网膜下腔麻醉>>在>>sec内注完";
            this.m_cbosecInfuse.BorderColor = System.Drawing.Color.Black;
            this.m_cbosecInfuse.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cbosecInfuse.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cbosecInfuse.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cbosecInfuse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cbosecInfuse.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cbosecInfuse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cbosecInfuse.ListBackColor = System.Drawing.Color.White;
            this.m_cbosecInfuse.ListForeColor = System.Drawing.Color.Black;
            this.m_cbosecInfuse.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cbosecInfuse.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cbosecInfuse.Location = new System.Drawing.Point(568, 192);
            this.m_cbosecInfuse.m_BlnEnableItemEventMenu = true;
            this.m_cbosecInfuse.Name = "m_cbosecInfuse";
            this.m_cbosecInfuse.SelectedIndex = -1;
            this.m_cbosecInfuse.SelectedItem = null;
            this.m_cbosecInfuse.SelectionStart = 0;
            this.m_cbosecInfuse.Size = new System.Drawing.Size(100, 23);
            this.m_cbosecInfuse.TabIndex = 39;
            this.m_cbosecInfuse.TextBackColor = System.Drawing.Color.White;
            this.m_cbosecInfuse.TextForeColor = System.Drawing.Color.Black;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(40, 160);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(119, 14);
            this.label67.TabIndex = 38;
            this.label67.Text = "注初量期间情况：";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboSmallNumState
            // 
            this.m_cboSmallNumState.AccessibleDescription = "注初量期间情况";
            this.m_cboSmallNumState.BorderColor = System.Drawing.Color.Black;
            this.m_cboSmallNumState.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboSmallNumState.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboSmallNumState.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboSmallNumState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboSmallNumState.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSmallNumState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSmallNumState.ListBackColor = System.Drawing.Color.White;
            this.m_cboSmallNumState.ListForeColor = System.Drawing.Color.Black;
            this.m_cboSmallNumState.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboSmallNumState.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboSmallNumState.Location = new System.Drawing.Point(160, 160);
            this.m_cboSmallNumState.m_BlnEnableItemEventMenu = true;
            this.m_cboSmallNumState.Name = "m_cboSmallNumState";
            this.m_cboSmallNumState.SelectedIndex = -1;
            this.m_cboSmallNumState.SelectedItem = null;
            this.m_cboSmallNumState.SelectionStart = 0;
            this.m_cboSmallNumState.Size = new System.Drawing.Size(208, 23);
            this.m_cboSmallNumState.TabIndex = 37;
            this.m_cboSmallNumState.TextBackColor = System.Drawing.Color.White;
            this.m_cboSmallNumState.TextForeColor = System.Drawing.Color.Black;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(400, 160);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(77, 14);
            this.label66.TabIndex = 36;
            this.label66.Text = "特殊情况：";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboEspecialCircs
            // 
            this.m_cboEspecialCircs.AccessibleDescription = "特殊情况：";
            this.m_cboEspecialCircs.BorderColor = System.Drawing.Color.Black;
            this.m_cboEspecialCircs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboEspecialCircs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboEspecialCircs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboEspecialCircs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboEspecialCircs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEspecialCircs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEspecialCircs.ListBackColor = System.Drawing.Color.White;
            this.m_cboEspecialCircs.ListForeColor = System.Drawing.Color.Black;
            this.m_cboEspecialCircs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboEspecialCircs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboEspecialCircs.Location = new System.Drawing.Point(480, 160);
            this.m_cboEspecialCircs.m_BlnEnableItemEventMenu = true;
            this.m_cboEspecialCircs.Name = "m_cboEspecialCircs";
            this.m_cboEspecialCircs.SelectedIndex = -1;
            this.m_cboEspecialCircs.SelectedItem = null;
            this.m_cboEspecialCircs.SelectionStart = 0;
            this.m_cboEspecialCircs.Size = new System.Drawing.Size(304, 23);
            this.m_cboEspecialCircs.TabIndex = 35;
            this.m_cboEspecialCircs.TextBackColor = System.Drawing.Color.White;
            this.m_cboEspecialCircs.TextForeColor = System.Drawing.Color.Black;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(472, 128);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(91, 14);
            this.label65.TabIndex = 34;
            this.label65.Text = "更换间隙情况";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.m_rdbNotFavoring);
            this.panel8.Controls.Add(this.m_rdbFavoring);
            this.panel8.Location = new System.Drawing.Point(352, 120);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(112, 32);
            this.panel8.TabIndex = 33;
            // 
            // m_rdbNotFavoring
            // 
            this.m_rdbNotFavoring.AccessibleDescription = "置管>>困难";
            this.m_rdbNotFavoring.Location = new System.Drawing.Point(56, 8);
            this.m_rdbNotFavoring.Name = "m_rdbNotFavoring";
            this.m_rdbNotFavoring.Size = new System.Drawing.Size(56, 24);
            this.m_rdbNotFavoring.TabIndex = 21;
            this.m_rdbNotFavoring.Text = "困难";
            // 
            // m_rdbFavoring
            // 
            this.m_rdbFavoring.AccessibleDescription = "置管>>顺利";
            this.m_rdbFavoring.Location = new System.Drawing.Point(0, 8);
            this.m_rdbFavoring.Name = "m_rdbFavoring";
            this.m_rdbFavoring.Size = new System.Drawing.Size(56, 24);
            this.m_rdbFavoring.TabIndex = 20;
            this.m_rdbFavoring.Text = "顺利";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(312, 128);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(49, 14);
            this.label64.TabIndex = 32;
            this.label64.Text = "置管：";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.m_rdbNotAllRight);
            this.panel7.Controls.Add(this.m_rdbAllRight);
            this.panel7.Location = new System.Drawing.Point(192, 120);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(112, 32);
            this.panel7.TabIndex = 31;
            // 
            // m_rdbNotAllRight
            // 
            this.m_rdbNotAllRight.AccessibleDescription = "穿刺过程>>困难";
            this.m_rdbNotAllRight.Location = new System.Drawing.Point(64, 8);
            this.m_rdbNotAllRight.Name = "m_rdbNotAllRight";
            this.m_rdbNotAllRight.Size = new System.Drawing.Size(56, 24);
            this.m_rdbNotAllRight.TabIndex = 21;
            this.m_rdbNotAllRight.Text = "困难";
            // 
            // m_rdbAllRight
            // 
            this.m_rdbAllRight.AccessibleDescription = "穿刺过程>>顺利";
            this.m_rdbAllRight.Location = new System.Drawing.Point(8, 8);
            this.m_rdbAllRight.Name = "m_rdbAllRight";
            this.m_rdbAllRight.Size = new System.Drawing.Size(56, 24);
            this.m_rdbAllRight.TabIndex = 20;
            this.m_rdbAllRight.Text = "顺利";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(128, 128);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(77, 14);
            this.label63.TabIndex = 30;
            this.label63.Text = "穿刺过程：";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.m_chkExtradural);
            this.panel6.Location = new System.Drawing.Point(24, 120);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(128, 32);
            this.panel6.TabIndex = 29;
            // 
            // m_chkExtradural
            // 
            this.m_chkExtradural.AccessibleDescription = "硬膜外麻醉";
            this.m_chkExtradural.Location = new System.Drawing.Point(0, 8);
            this.m_chkExtradural.Name = "m_chkExtradural";
            this.m_chkExtradural.Size = new System.Drawing.Size(144, 24);
            this.m_chkExtradural.TabIndex = 0;
            this.m_chkExtradural.Text = "硬膜外麻醉：";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_rdbNoKilter);
            this.panel5.Controls.Add(this.m_rdbKilter);
            this.panel5.Location = new System.Drawing.Point(136, 88);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(128, 32);
            this.panel5.TabIndex = 28;
            // 
            // m_rdbNoKilter
            // 
            this.m_rdbNoKilter.AccessibleDescription = "气管插管经过>>困难";
            this.m_rdbNoKilter.Location = new System.Drawing.Point(72, 8);
            this.m_rdbNoKilter.Name = "m_rdbNoKilter";
            this.m_rdbNoKilter.Size = new System.Drawing.Size(56, 24);
            this.m_rdbNoKilter.TabIndex = 21;
            this.m_rdbNoKilter.Text = "困难";
            // 
            // m_rdbKilter
            // 
            this.m_rdbKilter.AccessibleDescription = "气管插管经过>>顺利";
            this.m_rdbKilter.Location = new System.Drawing.Point(16, 8);
            this.m_rdbKilter.Name = "m_rdbKilter";
            this.m_rdbKilter.Size = new System.Drawing.Size(56, 24);
            this.m_rdbKilter.TabIndex = 20;
            this.m_rdbKilter.Text = "顺利";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(40, 96);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(105, 14);
            this.label62.TabIndex = 27;
            this.label62.Text = "气管插管经过：";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_rdbNoQuiet);
            this.panel4.Controls.Add(this.m_rdbShortQuiet);
            this.panel4.Controls.Add(this.m_rdbEvenQuiet);
            this.panel4.Controls.Add(this.m_rdbQuiet);
            this.panel4.Location = new System.Drawing.Point(536, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 32);
            this.panel4.TabIndex = 26;
            // 
            // m_rdbNoQuiet
            // 
            this.m_rdbNoQuiet.AccessibleDescription = "麻醉维持>>不平稳";
            this.m_rdbNoQuiet.Location = new System.Drawing.Point(184, 8);
            this.m_rdbNoQuiet.Name = "m_rdbNoQuiet";
            this.m_rdbNoQuiet.Size = new System.Drawing.Size(72, 24);
            this.m_rdbNoQuiet.TabIndex = 23;
            this.m_rdbNoQuiet.Text = "不平稳";
            // 
            // m_rdbShortQuiet
            // 
            this.m_rdbShortQuiet.AccessibleDescription = "麻醉维持>>欠平稳";
            this.m_rdbShortQuiet.Location = new System.Drawing.Point(120, 8);
            this.m_rdbShortQuiet.Name = "m_rdbShortQuiet";
            this.m_rdbShortQuiet.Size = new System.Drawing.Size(72, 24);
            this.m_rdbShortQuiet.TabIndex = 22;
            this.m_rdbShortQuiet.Text = "欠平稳";
            // 
            // m_rdbEvenQuiet
            // 
            this.m_rdbEvenQuiet.AccessibleDescription = "麻醉维持>>尚平稳";
            this.m_rdbEvenQuiet.Location = new System.Drawing.Point(56, 8);
            this.m_rdbEvenQuiet.Name = "m_rdbEvenQuiet";
            this.m_rdbEvenQuiet.Size = new System.Drawing.Size(72, 24);
            this.m_rdbEvenQuiet.TabIndex = 21;
            this.m_rdbEvenQuiet.Text = "尚平稳";
            // 
            // m_rdbQuiet
            // 
            this.m_rdbQuiet.AccessibleDescription = "麻醉维持>>平稳";
            this.m_rdbQuiet.Location = new System.Drawing.Point(8, 8);
            this.m_rdbQuiet.Name = "m_rdbQuiet";
            this.m_rdbQuiet.Size = new System.Drawing.Size(56, 24);
            this.m_rdbQuiet.TabIndex = 20;
            this.m_rdbQuiet.Text = "平稳";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(472, 64);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(77, 14);
            this.label61.TabIndex = 25;
            this.label61.Text = "麻醉维持：";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_rdbNoCalm);
            this.panel3.Controls.Add(this.m_rdbShortCalm);
            this.panel3.Controls.Add(this.m_rdbEvenCalm);
            this.panel3.Controls.Add(this.m_rdbCalm);
            this.panel3.Location = new System.Drawing.Point(216, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 32);
            this.panel3.TabIndex = 24;
            // 
            // m_rdbNoCalm
            // 
            this.m_rdbNoCalm.AccessibleDescription = "麻醉诱导>>不平稳";
            this.m_rdbNoCalm.Location = new System.Drawing.Point(184, 8);
            this.m_rdbNoCalm.Name = "m_rdbNoCalm";
            this.m_rdbNoCalm.Size = new System.Drawing.Size(72, 24);
            this.m_rdbNoCalm.TabIndex = 23;
            this.m_rdbNoCalm.Text = "不平稳";
            // 
            // m_rdbShortCalm
            // 
            this.m_rdbShortCalm.AccessibleDescription = "麻醉诱导>>欠平稳";
            this.m_rdbShortCalm.Location = new System.Drawing.Point(120, 8);
            this.m_rdbShortCalm.Name = "m_rdbShortCalm";
            this.m_rdbShortCalm.Size = new System.Drawing.Size(72, 24);
            this.m_rdbShortCalm.TabIndex = 22;
            this.m_rdbShortCalm.Text = "欠平稳";
            // 
            // m_rdbEvenCalm
            // 
            this.m_rdbEvenCalm.AccessibleDescription = "麻醉诱导>>尚平稳";
            this.m_rdbEvenCalm.Location = new System.Drawing.Point(56, 8);
            this.m_rdbEvenCalm.Name = "m_rdbEvenCalm";
            this.m_rdbEvenCalm.Size = new System.Drawing.Size(72, 24);
            this.m_rdbEvenCalm.TabIndex = 21;
            this.m_rdbEvenCalm.Text = "尚平稳";
            // 
            // m_rdbCalm
            // 
            this.m_rdbCalm.AccessibleDescription = "麻醉诱导>>平稳";
            this.m_rdbCalm.Location = new System.Drawing.Point(8, 8);
            this.m_rdbCalm.Name = "m_rdbCalm";
            this.m_rdbCalm.Size = new System.Drawing.Size(56, 24);
            this.m_rdbCalm.TabIndex = 20;
            this.m_rdbCalm.Text = "平稳";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(152, 64);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(77, 14);
            this.label60.TabIndex = 23;
            this.label60.Text = "麻醉诱导：";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_chkEndotracheal);
            this.panel2.Location = new System.Drawing.Point(24, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 40);
            this.panel2.TabIndex = 22;
            // 
            // m_chkEndotracheal
            // 
            this.m_chkEndotracheal.AccessibleDescription = "气管内插管全麻";
            this.m_chkEndotracheal.Location = new System.Drawing.Point(0, 8);
            this.m_chkEndotracheal.Name = "m_chkEndotracheal";
            this.m_chkEndotracheal.Size = new System.Drawing.Size(144, 24);
            this.m_chkEndotracheal.TabIndex = 0;
            this.m_chkEndotracheal.Text = "气管内插管全麻：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cboComa);
            this.panel1.Controls.Add(this.m_rdbWinkle);
            this.panel1.Controls.Add(this.m_rdbSober);
            this.panel1.Location = new System.Drawing.Point(104, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 32);
            this.panel1.TabIndex = 21;
            // 
            // m_cboComa
            // 
            this.m_cboComa.AccessibleDescription = "患者入室>>昏迷";
            this.m_cboComa.Location = new System.Drawing.Point(128, 8);
            this.m_cboComa.Name = "m_cboComa";
            this.m_cboComa.Size = new System.Drawing.Size(56, 24);
            this.m_cboComa.TabIndex = 22;
            this.m_cboComa.Text = "昏迷";
            // 
            // m_rdbWinkle
            // 
            this.m_rdbWinkle.AccessibleDescription = "患者入室>>嗜睡";
            this.m_rdbWinkle.Location = new System.Drawing.Point(72, 8);
            this.m_rdbWinkle.Name = "m_rdbWinkle";
            this.m_rdbWinkle.Size = new System.Drawing.Size(56, 24);
            this.m_rdbWinkle.TabIndex = 21;
            this.m_rdbWinkle.Text = "嗜睡";
            this.m_rdbWinkle.CheckedChanged += new System.EventHandler(this.m_rdbWinkle_CheckedChanged);
            // 
            // m_rdbSober
            // 
            this.m_rdbSober.AccessibleDescription = "患者入室>>清醒";
            this.m_rdbSober.Location = new System.Drawing.Point(16, 8);
            this.m_rdbSober.Name = "m_rdbSober";
            this.m_rdbSober.Size = new System.Drawing.Size(56, 24);
            this.m_rdbSober.TabIndex = 20;
            this.m_rdbSober.Text = "清醒";
            // 
            // m_cboChangeState
            // 
            this.m_cboChangeState.AccessibleDescription = "更换间隙情况";
            this.m_cboChangeState.BorderColor = System.Drawing.Color.Black;
            this.m_cboChangeState.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboChangeState.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboChangeState.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboChangeState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboChangeState.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboChangeState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboChangeState.ListBackColor = System.Drawing.Color.White;
            this.m_cboChangeState.ListForeColor = System.Drawing.Color.Black;
            this.m_cboChangeState.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboChangeState.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboChangeState.Location = new System.Drawing.Point(568, 128);
            this.m_cboChangeState.m_BlnEnableItemEventMenu = true;
            this.m_cboChangeState.Name = "m_cboChangeState";
            this.m_cboChangeState.SelectedIndex = -1;
            this.m_cboChangeState.SelectedItem = null;
            this.m_cboChangeState.SelectionStart = 0;
            this.m_cboChangeState.Size = new System.Drawing.Size(216, 23);
            this.m_cboChangeState.TabIndex = 19;
            this.m_cboChangeState.TextBackColor = System.Drawing.Color.White;
            this.m_cboChangeState.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboCause
            // 
            this.m_cboCause.AccessibleDescription = "插管困难的原因";
            this.m_cboCause.BorderColor = System.Drawing.Color.Black;
            this.m_cboCause.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCause.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboCause.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCause.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCause.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCause.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCause.ListBackColor = System.Drawing.Color.White;
            this.m_cboCause.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCause.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCause.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCause.Location = new System.Drawing.Point(384, 96);
            this.m_cboCause.m_BlnEnableItemEventMenu = true;
            this.m_cboCause.Name = "m_cboCause";
            this.m_cboCause.SelectedIndex = -1;
            this.m_cboCause.SelectedItem = null;
            this.m_cboCause.SelectionStart = 0;
            this.m_cboCause.Size = new System.Drawing.Size(400, 23);
            this.m_cboCause.TabIndex = 18;
            this.m_cboCause.TextBackColor = System.Drawing.Color.White;
            this.m_cboCause.TextForeColor = System.Drawing.Color.Black;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(32, 32);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(77, 14);
            this.label57.TabIndex = 17;
            this.label57.Text = "患者入室：";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(272, 96);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(105, 14);
            this.label58.TabIndex = 16;
            this.label58.Text = "插管困难的原因";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(16, 8);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(63, 14);
            this.label59.TabIndex = 15;
            this.label59.Text = "麻醉总结";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_DtTime);
            this.tabPage3.Controls.Add(this.label86);
            this.tabPage3.Controls.Add(this.m_cmbAnaesthesiaDoctorName);
            this.tabPage3.Controls.Add(this.m_richTxtAnaesthesiaDoctorName);
            this.tabPage3.Controls.Add(this.label85);
            this.tabPage3.Controls.Add(this.m_richtxtPatientWard);
            this.tabPage3.Controls.Add(this.m_richtxtOperateDealwith);
            this.tabPage3.Controls.Add(this.label84);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 429);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "第三页";
            // 
            // m_DtTime
            // 
            this.m_DtTime.AccessibleDescription = "麻醉总结>>日期";
            this.m_DtTime.BorderColor = System.Drawing.Color.White;
            this.m_DtTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_DtTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_DtTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_DtTime.DropButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_DtTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_DtTime.Font = new System.Drawing.Font("宋体", 12F);
            this.m_DtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_DtTime.Location = new System.Drawing.Point(624, 360);
            this.m_DtTime.m_BlnOnlyTime = false;
            this.m_DtTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_DtTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_DtTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_DtTime.Name = "m_DtTime";
            this.m_DtTime.ReadOnly = false;
            this.m_DtTime.Size = new System.Drawing.Size(144, 22);
            this.m_DtTime.TabIndex = 1412;
            this.m_DtTime.TextBackColor = System.Drawing.Color.White;
            this.m_DtTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(576, 360);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(49, 14);
            this.label86.TabIndex = 1411;
            this.label86.Text = "日期：";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbAnaesthesiaDoctorName
            // 
            this.m_cmbAnaesthesiaDoctorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmbAnaesthesiaDoctorName.DefaultScheme = true;
            this.m_cmbAnaesthesiaDoctorName.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmbAnaesthesiaDoctorName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbAnaesthesiaDoctorName.Hint = "";
            this.m_cmbAnaesthesiaDoctorName.Location = new System.Drawing.Point(360, 360);
            this.m_cmbAnaesthesiaDoctorName.Name = "m_cmbAnaesthesiaDoctorName";
            this.m_cmbAnaesthesiaDoctorName.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmbAnaesthesiaDoctorName.Size = new System.Drawing.Size(96, 28);
            this.m_cmbAnaesthesiaDoctorName.TabIndex = 1341;
            this.m_cmbAnaesthesiaDoctorName.Tag = "1";
            this.m_cmbAnaesthesiaDoctorName.Text = "麻醉科医生:";
            // 
            // m_richTxtAnaesthesiaDoctorName
            // 
            this.m_richTxtAnaesthesiaDoctorName.AccessibleDescription = "麻醉科医生2";
            this.m_richTxtAnaesthesiaDoctorName.AccessibleName = "NoDefault";
            this.m_richTxtAnaesthesiaDoctorName.BackColor = System.Drawing.Color.White;
            this.m_richTxtAnaesthesiaDoctorName.BorderColor = System.Drawing.Color.White;
            this.m_richTxtAnaesthesiaDoctorName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_richTxtAnaesthesiaDoctorName.ForeColor = System.Drawing.Color.Black;
            this.m_richTxtAnaesthesiaDoctorName.Location = new System.Drawing.Point(456, 360);
            this.m_richTxtAnaesthesiaDoctorName.Name = "m_richTxtAnaesthesiaDoctorName";
            this.m_richTxtAnaesthesiaDoctorName.Size = new System.Drawing.Size(104, 23);
            this.m_richTxtAnaesthesiaDoctorName.TabIndex = 1342;
            this.m_richTxtAnaesthesiaDoctorName.Tag = "1";
            // 
            // label85
            // 
            this.label85.Location = new System.Drawing.Point(16, 200);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(168, 23);
            this.label85.TabIndex = 3;
            this.label85.Text = "患者入病房时交班情况：";
            // 
            // m_richtxtPatientWard
            // 
            this.m_richtxtPatientWard.AccessibleDescription = "患者入病房时交班情况";
            this.m_richtxtPatientWard.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_richtxtPatientWard.Location = new System.Drawing.Point(32, 224);
            this.m_richtxtPatientWard.m_BlnIgnoreUserInfo = false;
            this.m_richtxtPatientWard.m_BlnPartControl = false;
            this.m_richtxtPatientWard.m_BlnReadOnly = false;
            this.m_richtxtPatientWard.m_BlnUnderLineDST = false;
            this.m_richtxtPatientWard.m_ClrDST = System.Drawing.Color.Red;
            this.m_richtxtPatientWard.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_richtxtPatientWard.m_IntCanModifyTime = 6;
            this.m_richtxtPatientWard.m_IntPartControlLength = 0;
            this.m_richtxtPatientWard.m_IntPartControlStartIndex = 0;
            this.m_richtxtPatientWard.m_StrUserID = "";
            this.m_richtxtPatientWard.m_StrUserName = "";
            this.m_richtxtPatientWard.Name = "m_richtxtPatientWard";
            this.m_richtxtPatientWard.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_richtxtPatientWard.Size = new System.Drawing.Size(736, 120);
            this.m_richtxtPatientWard.TabIndex = 2;
            this.m_richtxtPatientWard.Text = "";
            // 
            // m_richtxtOperateDealwith
            // 
            this.m_richtxtOperateDealwith.AccessibleDescription = "术中情况及处理";
            this.m_richtxtOperateDealwith.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_richtxtOperateDealwith.Location = new System.Drawing.Point(32, 40);
            this.m_richtxtOperateDealwith.m_BlnIgnoreUserInfo = false;
            this.m_richtxtOperateDealwith.m_BlnPartControl = false;
            this.m_richtxtOperateDealwith.m_BlnReadOnly = false;
            this.m_richtxtOperateDealwith.m_BlnUnderLineDST = false;
            this.m_richtxtOperateDealwith.m_ClrDST = System.Drawing.Color.Red;
            this.m_richtxtOperateDealwith.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_richtxtOperateDealwith.m_IntCanModifyTime = 6;
            this.m_richtxtOperateDealwith.m_IntPartControlLength = 0;
            this.m_richtxtOperateDealwith.m_IntPartControlStartIndex = 0;
            this.m_richtxtOperateDealwith.m_StrUserID = "";
            this.m_richtxtOperateDealwith.m_StrUserName = "";
            this.m_richtxtOperateDealwith.Name = "m_richtxtOperateDealwith";
            this.m_richtxtOperateDealwith.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_richtxtOperateDealwith.Size = new System.Drawing.Size(736, 152);
            this.m_richtxtOperateDealwith.TabIndex = 1;
            this.m_richtxtOperateDealwith.Text = "";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(16, 16);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(119, 14);
            this.label84.TabIndex = 0;
            this.label84.Text = "术中情况及处理：";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_dtPostOperateTime);
            this.tabPage4.Controls.Add(this.label90);
            this.tabPage4.Controls.Add(this.m_cmdHocusDoctorName);
            this.tabPage4.Controls.Add(this.m_txtHocusDoctorName);
            this.tabPage4.Controls.Add(this.m_richTxtPostOperateDoIdea);
            this.tabPage4.Controls.Add(this.label89);
            this.tabPage4.Controls.Add(this.m_cboAnather);
            this.tabPage4.Controls.Add(this.m_cboPCA);
            this.tabPage4.Controls.Add(this.m_chkPCA);
            this.tabPage4.Controls.Add(this.m_cboIntravenousTingle);
            this.tabPage4.Controls.Add(this.panel24);
            this.tabPage4.Controls.Add(this.m_cboNeurolysisTingle);
            this.tabPage4.Controls.Add(this.panel23);
            this.tabPage4.Controls.Add(this.m_cboArachnoidTingle);
            this.tabPage4.Controls.Add(this.panel22);
            this.tabPage4.Controls.Add(this.m_cboPutamenTigle);
            this.tabPage4.Controls.Add(this.panel21);
            this.tabPage4.Controls.Add(this.label88);
            this.tabPage4.Controls.Add(this.m_cboEndotrachealTingle);
            this.tabPage4.Controls.Add(this.panel20);
            this.tabPage4.Controls.Add(this.label87);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(792, 429);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "第四页";
            // 
            // m_dtPostOperateTime
            // 
            this.m_dtPostOperateTime.AccessibleDescription = "术后访视>>日期";
            this.m_dtPostOperateTime.BorderColor = System.Drawing.Color.White;
            this.m_dtPostOperateTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtPostOperateTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtPostOperateTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtPostOperateTime.DropButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtPostOperateTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtPostOperateTime.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtPostOperateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtPostOperateTime.Location = new System.Drawing.Point(624, 384);
            this.m_dtPostOperateTime.m_BlnOnlyTime = false;
            this.m_dtPostOperateTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtPostOperateTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtPostOperateTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtPostOperateTime.Name = "m_dtPostOperateTime";
            this.m_dtPostOperateTime.ReadOnly = false;
            this.m_dtPostOperateTime.Size = new System.Drawing.Size(144, 22);
            this.m_dtPostOperateTime.TabIndex = 1416;
            this.m_dtPostOperateTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtPostOperateTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(576, 384);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(49, 14);
            this.label90.TabIndex = 1415;
            this.label90.Text = "日期：";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmdHocusDoctorName
            // 
            this.m_cmdHocusDoctorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdHocusDoctorName.DefaultScheme = true;
            this.m_cmdHocusDoctorName.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdHocusDoctorName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdHocusDoctorName.Hint = "";
            this.m_cmdHocusDoctorName.Location = new System.Drawing.Point(360, 384);
            this.m_cmdHocusDoctorName.Name = "m_cmdHocusDoctorName";
            this.m_cmdHocusDoctorName.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdHocusDoctorName.Size = new System.Drawing.Size(96, 28);
            this.m_cmdHocusDoctorName.TabIndex = 1413;
            this.m_cmdHocusDoctorName.Tag = "1";
            this.m_cmdHocusDoctorName.Text = "麻醉科医生:";
            // 
            // m_txtHocusDoctorName
            // 
            this.m_txtHocusDoctorName.AccessibleDescription = "麻醉科医生3";
            this.m_txtHocusDoctorName.AccessibleName = "NoDefault";
            this.m_txtHocusDoctorName.BackColor = System.Drawing.Color.White;
            this.m_txtHocusDoctorName.BorderColor = System.Drawing.Color.White;
            this.m_txtHocusDoctorName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHocusDoctorName.ForeColor = System.Drawing.Color.Black;
            this.m_txtHocusDoctorName.Location = new System.Drawing.Point(456, 384);
            this.m_txtHocusDoctorName.Name = "m_txtHocusDoctorName";
            this.m_txtHocusDoctorName.Size = new System.Drawing.Size(104, 23);
            this.m_txtHocusDoctorName.TabIndex = 1414;
            this.m_txtHocusDoctorName.Tag = "1";
            // 
            // m_richTxtPostOperateDoIdea
            // 
            this.m_richTxtPostOperateDoIdea.AccessibleDescription = "术后访视>>处理意见";
            this.m_richTxtPostOperateDoIdea.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_richTxtPostOperateDoIdea.Location = new System.Drawing.Point(28, 248);
            this.m_richTxtPostOperateDoIdea.m_BlnIgnoreUserInfo = false;
            this.m_richTxtPostOperateDoIdea.m_BlnPartControl = false;
            this.m_richTxtPostOperateDoIdea.m_BlnReadOnly = false;
            this.m_richTxtPostOperateDoIdea.m_BlnUnderLineDST = false;
            this.m_richTxtPostOperateDoIdea.m_ClrDST = System.Drawing.Color.Red;
            this.m_richTxtPostOperateDoIdea.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_richTxtPostOperateDoIdea.m_IntCanModifyTime = 6;
            this.m_richTxtPostOperateDoIdea.m_IntPartControlLength = 0;
            this.m_richTxtPostOperateDoIdea.m_IntPartControlStartIndex = 0;
            this.m_richTxtPostOperateDoIdea.m_StrUserID = "";
            this.m_richTxtPostOperateDoIdea.m_StrUserName = "";
            this.m_richTxtPostOperateDoIdea.Name = "m_richTxtPostOperateDoIdea";
            this.m_richTxtPostOperateDoIdea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_richTxtPostOperateDoIdea.Size = new System.Drawing.Size(740, 120);
            this.m_richTxtPostOperateDoIdea.TabIndex = 70;
            this.m_richTxtPostOperateDoIdea.Text = "";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(24, 232);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(77, 14);
            this.label89.TabIndex = 69;
            this.label89.Text = "处理意见：";
            // 
            // m_cboAnather
            // 
            this.m_cboAnather.AccessibleDescription = "术后访视>>其它";
            this.m_cboAnather.BorderColor = System.Drawing.Color.Black;
            this.m_cboAnather.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAnather.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboAnather.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAnather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAnather.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAnather.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAnather.ListBackColor = System.Drawing.Color.White;
            this.m_cboAnather.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAnather.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboAnather.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboAnather.Location = new System.Drawing.Point(360, 200);
            this.m_cboAnather.m_BlnEnableItemEventMenu = true;
            this.m_cboAnather.Name = "m_cboAnather";
            this.m_cboAnather.SelectedIndex = -1;
            this.m_cboAnather.SelectedItem = null;
            this.m_cboAnather.SelectionStart = 0;
            this.m_cboAnather.Size = new System.Drawing.Size(408, 23);
            this.m_cboAnather.TabIndex = 68;
            this.m_cboAnather.TextBackColor = System.Drawing.Color.White;
            this.m_cboAnather.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPCA
            // 
            this.m_cboPCA.AccessibleDescription = "术后访视>>PCA1";
            this.m_cboPCA.BorderColor = System.Drawing.Color.Black;
            this.m_cboPCA.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPCA.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboPCA.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPCA.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPCA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPCA.ListBackColor = System.Drawing.Color.White;
            this.m_cboPCA.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPCA.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPCA.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPCA.Location = new System.Drawing.Point(80, 200);
            this.m_cboPCA.m_BlnEnableItemEventMenu = true;
            this.m_cboPCA.Name = "m_cboPCA";
            this.m_cboPCA.SelectedIndex = -1;
            this.m_cboPCA.SelectedItem = null;
            this.m_cboPCA.SelectionStart = 0;
            this.m_cboPCA.Size = new System.Drawing.Size(212, 23);
            this.m_cboPCA.TabIndex = 67;
            this.m_cboPCA.TextBackColor = System.Drawing.Color.White;
            this.m_cboPCA.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_chkPCA
            // 
            this.m_chkPCA.AccessibleDescription = "术后访视>>PCA";
            this.m_chkPCA.Location = new System.Drawing.Point(24, 200);
            this.m_chkPCA.Name = "m_chkPCA";
            this.m_chkPCA.Size = new System.Drawing.Size(64, 24);
            this.m_chkPCA.TabIndex = 66;
            this.m_chkPCA.Text = "PCA：";
            // 
            // m_cboIntravenousTingle
            // 
            this.m_cboIntravenousTingle.AccessibleDescription = "术后访视>>静脉复合麻醉并发症1";
            this.m_cboIntravenousTingle.BorderColor = System.Drawing.Color.Black;
            this.m_cboIntravenousTingle.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboIntravenousTingle.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboIntravenousTingle.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboIntravenousTingle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboIntravenousTingle.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboIntravenousTingle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboIntravenousTingle.ListBackColor = System.Drawing.Color.White;
            this.m_cboIntravenousTingle.ListForeColor = System.Drawing.Color.Black;
            this.m_cboIntravenousTingle.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboIntravenousTingle.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboIntravenousTingle.Location = new System.Drawing.Point(192, 168);
            this.m_cboIntravenousTingle.m_BlnEnableItemEventMenu = true;
            this.m_cboIntravenousTingle.Name = "m_cboIntravenousTingle";
            this.m_cboIntravenousTingle.SelectedIndex = -1;
            this.m_cboIntravenousTingle.SelectedItem = null;
            this.m_cboIntravenousTingle.SelectionStart = 0;
            this.m_cboIntravenousTingle.Size = new System.Drawing.Size(576, 23);
            this.m_cboIntravenousTingle.TabIndex = 65;
            this.m_cboIntravenousTingle.TextBackColor = System.Drawing.Color.White;
            this.m_cboIntravenousTingle.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.m_chkIntravenousTingle);
            this.panel24.Location = new System.Drawing.Point(24, 160);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(184, 32);
            this.panel24.TabIndex = 64;
            // 
            // m_chkIntravenousTingle
            // 
            this.m_chkIntravenousTingle.AccessibleDescription = "术后访视>>静脉复合麻醉并发症";
            this.m_chkIntravenousTingle.Location = new System.Drawing.Point(0, 8);
            this.m_chkIntravenousTingle.Name = "m_chkIntravenousTingle";
            this.m_chkIntravenousTingle.Size = new System.Drawing.Size(184, 24);
            this.m_chkIntravenousTingle.TabIndex = 0;
            this.m_chkIntravenousTingle.Text = "静脉复合麻醉并发症：";
            // 
            // m_cboNeurolysisTingle
            // 
            this.m_cboNeurolysisTingle.AccessibleDescription = "术后访视>>神经阻滞麻醉并发症1";
            this.m_cboNeurolysisTingle.BorderColor = System.Drawing.Color.Black;
            this.m_cboNeurolysisTingle.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboNeurolysisTingle.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboNeurolysisTingle.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboNeurolysisTingle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboNeurolysisTingle.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboNeurolysisTingle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboNeurolysisTingle.ListBackColor = System.Drawing.Color.White;
            this.m_cboNeurolysisTingle.ListForeColor = System.Drawing.Color.Black;
            this.m_cboNeurolysisTingle.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboNeurolysisTingle.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboNeurolysisTingle.Location = new System.Drawing.Point(192, 136);
            this.m_cboNeurolysisTingle.m_BlnEnableItemEventMenu = true;
            this.m_cboNeurolysisTingle.Name = "m_cboNeurolysisTingle";
            this.m_cboNeurolysisTingle.SelectedIndex = -1;
            this.m_cboNeurolysisTingle.SelectedItem = null;
            this.m_cboNeurolysisTingle.SelectionStart = 0;
            this.m_cboNeurolysisTingle.Size = new System.Drawing.Size(576, 23);
            this.m_cboNeurolysisTingle.TabIndex = 63;
            this.m_cboNeurolysisTingle.TextBackColor = System.Drawing.Color.White;
            this.m_cboNeurolysisTingle.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.m_chkNeurolysisTingle);
            this.panel23.Location = new System.Drawing.Point(24, 128);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(184, 32);
            this.panel23.TabIndex = 62;
            // 
            // m_chkNeurolysisTingle
            // 
            this.m_chkNeurolysisTingle.AccessibleDescription = "术后访视>>神经阻滞麻醉并发症";
            this.m_chkNeurolysisTingle.Location = new System.Drawing.Point(0, 8);
            this.m_chkNeurolysisTingle.Name = "m_chkNeurolysisTingle";
            this.m_chkNeurolysisTingle.Size = new System.Drawing.Size(184, 24);
            this.m_chkNeurolysisTingle.TabIndex = 0;
            this.m_chkNeurolysisTingle.Text = "神经阻滞麻醉并发症：";
            // 
            // m_cboArachnoidTingle
            // 
            this.m_cboArachnoidTingle.AccessibleDescription = "术后访视>>蛛网膜下腔麻醉并发症1";
            this.m_cboArachnoidTingle.BorderColor = System.Drawing.Color.Black;
            this.m_cboArachnoidTingle.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboArachnoidTingle.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboArachnoidTingle.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboArachnoidTingle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboArachnoidTingle.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboArachnoidTingle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboArachnoidTingle.ListBackColor = System.Drawing.Color.White;
            this.m_cboArachnoidTingle.ListForeColor = System.Drawing.Color.Black;
            this.m_cboArachnoidTingle.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboArachnoidTingle.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboArachnoidTingle.Location = new System.Drawing.Point(192, 104);
            this.m_cboArachnoidTingle.m_BlnEnableItemEventMenu = true;
            this.m_cboArachnoidTingle.Name = "m_cboArachnoidTingle";
            this.m_cboArachnoidTingle.SelectedIndex = -1;
            this.m_cboArachnoidTingle.SelectedItem = null;
            this.m_cboArachnoidTingle.SelectionStart = 0;
            this.m_cboArachnoidTingle.Size = new System.Drawing.Size(576, 23);
            this.m_cboArachnoidTingle.TabIndex = 61;
            this.m_cboArachnoidTingle.TextBackColor = System.Drawing.Color.White;
            this.m_cboArachnoidTingle.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.m_chkArachnoidTingle);
            this.panel22.Location = new System.Drawing.Point(24, 96);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(184, 32);
            this.panel22.TabIndex = 60;
            // 
            // m_chkArachnoidTingle
            // 
            this.m_chkArachnoidTingle.AccessibleDescription = "术后访视>>蛛网膜下腔麻醉并发症";
            this.m_chkArachnoidTingle.Location = new System.Drawing.Point(0, 8);
            this.m_chkArachnoidTingle.Name = "m_chkArachnoidTingle";
            this.m_chkArachnoidTingle.Size = new System.Drawing.Size(184, 24);
            this.m_chkArachnoidTingle.TabIndex = 0;
            this.m_chkArachnoidTingle.Text = "蛛网膜下腔麻醉并发症：";
            // 
            // m_cboPutamenTigle
            // 
            this.m_cboPutamenTigle.AccessibleDescription = "术后访视>>硬膜外麻醉并发症1";
            this.m_cboPutamenTigle.BorderColor = System.Drawing.Color.Black;
            this.m_cboPutamenTigle.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPutamenTigle.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboPutamenTigle.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPutamenTigle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPutamenTigle.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPutamenTigle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPutamenTigle.ListBackColor = System.Drawing.Color.White;
            this.m_cboPutamenTigle.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPutamenTigle.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPutamenTigle.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPutamenTigle.Location = new System.Drawing.Point(192, 72);
            this.m_cboPutamenTigle.m_BlnEnableItemEventMenu = true;
            this.m_cboPutamenTigle.Name = "m_cboPutamenTigle";
            this.m_cboPutamenTigle.SelectedIndex = -1;
            this.m_cboPutamenTigle.SelectedItem = null;
            this.m_cboPutamenTigle.SelectionStart = 0;
            this.m_cboPutamenTigle.Size = new System.Drawing.Size(576, 23);
            this.m_cboPutamenTigle.TabIndex = 59;
            this.m_cboPutamenTigle.TextBackColor = System.Drawing.Color.White;
            this.m_cboPutamenTigle.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.m_chkPutamenTigle);
            this.panel21.Location = new System.Drawing.Point(24, 64);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(168, 32);
            this.panel21.TabIndex = 58;
            // 
            // m_chkPutamenTigle
            // 
            this.m_chkPutamenTigle.AccessibleDescription = "术后访视>>硬膜外麻醉并发症";
            this.m_chkPutamenTigle.Location = new System.Drawing.Point(0, 8);
            this.m_chkPutamenTigle.Name = "m_chkPutamenTigle";
            this.m_chkPutamenTigle.Size = new System.Drawing.Size(160, 24);
            this.m_chkPutamenTigle.TabIndex = 0;
            this.m_chkPutamenTigle.Text = "硬膜外麻醉并发症：";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(312, 200);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(49, 14);
            this.label88.TabIndex = 57;
            this.label88.Text = "其它：";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboEndotrachealTingle
            // 
            this.m_cboEndotrachealTingle.AccessibleDescription = "术后访视>>气管内插管全麻并发症1";
            this.m_cboEndotrachealTingle.BorderColor = System.Drawing.Color.Black;
            this.m_cboEndotrachealTingle.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboEndotrachealTingle.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboEndotrachealTingle.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboEndotrachealTingle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboEndotrachealTingle.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEndotrachealTingle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEndotrachealTingle.ListBackColor = System.Drawing.Color.White;
            this.m_cboEndotrachealTingle.ListForeColor = System.Drawing.Color.Black;
            this.m_cboEndotrachealTingle.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboEndotrachealTingle.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboEndotrachealTingle.Location = new System.Drawing.Point(192, 40);
            this.m_cboEndotrachealTingle.m_BlnEnableItemEventMenu = true;
            this.m_cboEndotrachealTingle.Name = "m_cboEndotrachealTingle";
            this.m_cboEndotrachealTingle.SelectedIndex = -1;
            this.m_cboEndotrachealTingle.SelectedItem = null;
            this.m_cboEndotrachealTingle.SelectionStart = 0;
            this.m_cboEndotrachealTingle.Size = new System.Drawing.Size(576, 23);
            this.m_cboEndotrachealTingle.TabIndex = 56;
            this.m_cboEndotrachealTingle.TextBackColor = System.Drawing.Color.White;
            this.m_cboEndotrachealTingle.TextForeColor = System.Drawing.Color.Black;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.m_chkEndotrachealTingle);
            this.panel20.Location = new System.Drawing.Point(24, 32);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(184, 32);
            this.panel20.TabIndex = 55;
            // 
            // m_chkEndotrachealTingle
            // 
            this.m_chkEndotrachealTingle.AccessibleDescription = "术后访视>>气管内插管全麻并发症";
            this.m_chkEndotrachealTingle.Location = new System.Drawing.Point(0, 8);
            this.m_chkEndotrachealTingle.Name = "m_chkEndotrachealTingle";
            this.m_chkEndotrachealTingle.Size = new System.Drawing.Size(184, 24);
            this.m_chkEndotrachealTingle.TabIndex = 0;
            this.m_chkEndotrachealTingle.Text = "气管内插管全麻并发症：";
            // 
            // label87
            // 
            this.label87.AccessibleDescription = "";
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(16, 16);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(63, 14);
            this.label87.TabIndex = 1;
            this.label87.Text = "术后访视";
            // 
            // frmIMR_PrePostOperateSee
            // 
            this.ClientSize = new System.Drawing.Size(899, 598);
            this.Name = "frmIMR_PrePostOperateSee";
            this.Text = "术前术后访视单";
            this.Load += new System.EventHandler(this.frmIMR_PrePostOperateSee_Load);
            this.m_pnlContent.ResumeLayout(false);
            this.m_pnlNewBase.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion 


		private void frmIMR_PrePostOperateSee_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_rdbWinkle_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_rdbPlacidity_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	
		public override int m_IntFormID
		{
			get
			{
				return 113;
			}
		}
	}
}
