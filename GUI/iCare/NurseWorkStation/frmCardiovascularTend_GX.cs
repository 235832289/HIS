using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.controls;
using System.Data;
using HRP;
using System.Xml;
using com.digitalwave.clsIntensiveTendRecord_GXService;

namespace iCare
{
	/// <summary>
	/// 心血管外科特护记录(广西)
	/// </summary>
	public class frmCardiovascularTend_GX : frmDiseaseTrackBase
	{
		#region 控件
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
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
		private System.Windows.Forms.ColumnHeader EXPANDVASMEDICINE;
		private System.Windows.Forms.ColumnHeader MEDICINENum;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.GroupBox groupBox6;
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
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private com.digitalwave.controls.ctlRichTextBox m_txtINFACT1;
		private com.digitalwave.controls.ctlRichTextBox m_txtINFACT2;
		private com.digitalwave.controls.ctlRichTextBox m_txtINFACT3;
		private com.digitalwave.controls.ctlRichTextBox m_txtINFACT4;
		private com.digitalwave.controls.ctlRichTextBox m_txtINFACT5;
		private com.digitalwave.controls.ctlRichTextBox m_txtINBLOOD;
		private com.digitalwave.controls.ctlRichTextBox m_txtINPERHOUR;
		private com.digitalwave.controls.ctlRichTextBox m_txtINSUM;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTPERHOUR;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTSUM;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTFACTPISSSUM;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTFACTPISS;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTFACTCHESTJUICE;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTFACTCHESTJUICESUM;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTFACTGASTRICJUICE;
		private System.Windows.Forms.ListView m_lsvEXPANDVASMEDICINE;
		private com.digitalwave.controls.ctlRichTextBox m_txtEXPANDVASMEDICINENum;
		private PinkieControls.ButtonXP m_cmdAddEXPANDVASMEDICINE;
		private PinkieControls.ButtonXP m_cmdRemoveEXPANDVASMEDICINE;
		private com.digitalwave.controls.ctlRichTextBox m_txtCARDIACDIURESISNum;
		private PinkieControls.ButtonXP m_cmdAddCARDIACDIURESIS;
		private System.Windows.Forms.ListView m_lsvCARDIACDIURESIS;
		private PinkieControls.ButtonXP m_cmdRemoveCARDIACDIURESIS;
		private PinkieControls.ButtonXP m_cmdAddOTHERMEDICINE;
        private System.Windows.Forms.ListView m_lsvOTHERMEDICINE;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.Label label95;
		private System.Windows.Forms.Label label96;
		private PinkieControls.ButtonXP m_cmdRemoveOTHERMEDICINE;
        private com.digitalwave.controls.ctlRichTextBox m_txtHEARTRHYTHM;
        private com.digitalwave.controls.ctlRichTextBox m_txtTEMPERATURE;
		private System.Windows.Forms.Label label97;
		private com.digitalwave.controls.ctlRichTextBox m_txtCVP;
		private com.digitalwave.controls.ctlRichTextBox m_txtBPA;
		private com.digitalwave.controls.ctlRichTextBox m_txtAVGBP;
		private com.digitalwave.controls.ctlRichTextBox m_txtLAP;
        private com.digitalwave.controls.ctlRichTextBox m_txtBPS;
		private com.digitalwave.controls.ctlRichTextBox m_txtFIO2;
		private com.digitalwave.controls.ctlRichTextBox m_txtIE;
		private com.digitalwave.controls.ctlRichTextBox m_txtPEEP;
		private com.digitalwave.controls.ctlRichTextBox m_txtTV;
		private com.digitalwave.controls.ctlRichTextBox m_txtVF;
        private com.digitalwave.controls.ctlRichTextBox m_txtBREATHTIMES;
		private com.digitalwave.controls.ctlRichTextBox m_txtREMARK;
		private com.digitalwave.controls.ctlRichTextBox m_txtPLT;
		private com.digitalwave.controls.ctlRichTextBox m_txtWBC;
		private com.digitalwave.controls.ctlRichTextBox m_txtHB;
		private com.digitalwave.controls.ctlRichTextBox m_txtRBC;
		private com.digitalwave.controls.ctlRichTextBox m_txtHCT;
		private com.digitalwave.controls.ctlRichTextBox m_txtBE;
		private com.digitalwave.controls.ctlRichTextBox m_txtPH;
		private com.digitalwave.controls.ctlRichTextBox m_txtPCO2;
		private com.digitalwave.controls.ctlRichTextBox m_txtPAO2;
		private com.digitalwave.controls.ctlRichTextBox m_txtHCO3;
		private com.digitalwave.controls.ctlRichTextBox m_txtGLU;
		private com.digitalwave.controls.ctlRichTextBox m_txtKPLUS;
		private com.digitalwave.controls.ctlRichTextBox m_txtNAPLUS;
		private com.digitalwave.controls.ctlRichTextBox m_txtCISUB;
		private com.digitalwave.controls.ctlRichTextBox m_txtCAPLUSPLUS;
		private com.digitalwave.controls.ctlRichTextBox m_txtBUN;
		private com.digitalwave.controls.ctlRichTextBox m_txtUA;
		private com.digitalwave.controls.ctlRichTextBox m_txtANHYDRIDE;
		private com.digitalwave.controls.ctlRichTextBox m_txtCO2CP;
		private com.digitalwave.controls.ctlRichTextBox m_txtPT;
		private com.digitalwave.controls.ctlRichTextBox m_txtXRAYCHECK;
		private com.digitalwave.controls.ctlRichTextBox m_txtACT;
		private com.digitalwave.controls.ctlRichTextBox m_txtPROPORTION;		
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private DateTime m_dtmRecordTime;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboEXPANDVASMEDICINE;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCARDIACDIURESIS;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCONSCIOUSNESS;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPUPIL;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLEFTPUPIL;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRIGHTPUPIL;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBREATHMACHINE;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboINSERTDEPTH;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboASSISTANT;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboALBUMEN;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHIDDENBLOOD;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboSKIN;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboWASHPERINEUM;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBRUSHBATH;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboMOUTHTEND;
		#endregion
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboINSPIRATION;
        private ctlRichTextBox m_txtCARDIACDIURESISMethod;
        private Label label98;
        private ColumnHeader columnHeader5;
        private ColumnHeader MEDICINEMethod;
        private ctlRichTextBox m_txtEXPANDVASMEDICINEMethod;
        private Label label99;
        private Label label100;
        private Label label101;
        private ctlRichTextBox m_txtSPO;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHEARTRATE;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboTWIGTEMPERATURE;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRIGHTBREATHVOICE;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPHLEGMCOLOR;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPHYSICALTHERAPY;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboGESTICULATION;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPHLEGMQUANTITY;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLEFTBREATHVOICE;
        private ctlRichTextBox m_txtOTHERMEDICINEMethod;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOTHERMEDICINE;
        private ctlRichTextBox m_txtOTHERMEDICINENum;
        private Label label102;
        private Label label27;
        private Label label28;
        private ColumnHeader columnHeader6;
        private Label label103;
        private Label label104;
        private Label label105;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCardiovascularTend_GX(DateTime p_dtmRecordTime)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthSetRichTextBoxAttribInControl(this);
			string strDay = p_dtmRecordTime.ToString("yyyy-MM-dd");
			string strTime = DateTime.Now.ToString("HH:mm:ss");
			m_dtmRecordTime = DateTime.Parse(strDay+" "+strTime);
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
            this.m_txtINFACT1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtINFACT2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINFACT3 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINFACT4 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINFACT5 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINBLOOD = new com.digitalwave.controls.ctlRichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtINPERHOUR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINSUM = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOUTPERHOUR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOUTSUM = new com.digitalwave.controls.ctlRichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtOUTFACTPISSSUM = new com.digitalwave.controls.ctlRichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtOUTFACTPISS = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOUTFACTCHESTJUICE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOUTFACTCHESTJUICESUM = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOUTFACTGASTRICJUICE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lsvEXPANDVASMEDICINE = new System.Windows.Forms.ListView();
            this.EXPANDVASMEDICINE = new System.Windows.Forms.ColumnHeader();
            this.MEDICINEMethod = new System.Windows.Forms.ColumnHeader();
            this.MEDICINENum = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtEXPANDVASMEDICINEMethod = new com.digitalwave.controls.ctlRichTextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.m_txtEXPANDVASMEDICINENum = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboEXPANDVASMEDICINE = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmdAddEXPANDVASMEDICINE = new PinkieControls.ButtonXP();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.m_cmdRemoveEXPANDVASMEDICINE = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtCARDIACDIURESISMethod = new com.digitalwave.controls.ctlRichTextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.m_cboCARDIACDIURESIS = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtCARDIACDIURESISNum = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdAddCARDIACDIURESIS = new PinkieControls.ButtonXP();
            this.label25 = new System.Windows.Forms.Label();
            this.m_lsvCARDIACDIURESIS = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label26 = new System.Windows.Forms.Label();
            this.m_cmdRemoveCARDIACDIURESIS = new PinkieControls.ButtonXP();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_txtOTHERMEDICINEMethod = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboOTHERMEDICINE = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtOTHERMEDICINENum = new com.digitalwave.controls.ctlRichTextBox();
            this.label102 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.m_cmdAddOTHERMEDICINE = new PinkieControls.ButtonXP();
            this.m_lsvOTHERMEDICINE = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdRemoveOTHERMEDICINE = new PinkieControls.ButtonXP();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_cboRIGHTPUPIL = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboLEFTPUPIL = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPUPIL = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboCONSCIOUSNESS = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_cboHEARTRATE = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboTWIGTEMPERATURE = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.m_txtCVP = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBPA = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtHEARTRHYTHM = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtTEMPERATURE = new com.digitalwave.controls.ctlRichTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.m_txtAVGBP = new com.digitalwave.controls.ctlRichTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.m_txtLAP = new com.digitalwave.controls.ctlRichTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.m_txtBPS = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_cboLEFTBREATHVOICE = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboRIGHTBREATHVOICE = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPHLEGMCOLOR = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPHYSICALTHERAPY = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboGESTICULATION = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPHLEGMQUANTITY = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboINSPIRATION = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboASSISTANT = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboINSERTDEPTH = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboBREATHMACHINE = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.m_txtFIO2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.m_txtIE = new com.digitalwave.controls.ctlRichTextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.m_txtPEEP = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtTV = new com.digitalwave.controls.ctlRichTextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.m_txtVF = new com.digitalwave.controls.ctlRichTextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.m_txtBREATHTIMES = new com.digitalwave.controls.ctlRichTextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.m_txtREMARK = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.m_txtPLT = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtWBC = new com.digitalwave.controls.ctlRichTextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.m_txtHB = new com.digitalwave.controls.ctlRichTextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.m_txtRBC = new com.digitalwave.controls.ctlRichTextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.m_txtHCT = new com.digitalwave.controls.ctlRichTextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label72 = new System.Windows.Forms.Label();
            this.m_txtBE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPH = new com.digitalwave.controls.ctlRichTextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.m_txtPCO2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPAO2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtHCO3 = new com.digitalwave.controls.ctlRichTextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.m_txtGLU = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtKPLUS = new com.digitalwave.controls.ctlRichTextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.m_txtNAPLUS = new com.digitalwave.controls.ctlRichTextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.m_txtCISUB = new com.digitalwave.controls.ctlRichTextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.m_txtCAPLUSPLUS = new com.digitalwave.controls.ctlRichTextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label82 = new System.Windows.Forms.Label();
            this.m_txtBUN = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtUA = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtANHYDRIDE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtCO2CP = new com.digitalwave.controls.ctlRichTextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.m_txtPT = new com.digitalwave.controls.ctlRichTextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.m_txtXRAYCHECK = new com.digitalwave.controls.ctlRichTextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.m_txtACT = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.m_cboHIDDENBLOOD = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboALBUMEN = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtPROPORTION = new com.digitalwave.controls.ctlRichTextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.m_cboWASHPERINEUM = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboBRUSHBATH = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboMOUTHTEND = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label96 = new System.Windows.Forms.Label();
            this.m_cboSKIN = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_txtSPO = new com.digitalwave.controls.ctlRichTextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(32, -104);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 104);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(8, 10);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(80, 8);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(192, 22);
            this.m_dtpCreateDate.TabIndex = 1000001;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(352, -64);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(248, -64);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(312, -144);
            this.lblSex.Size = new System.Drawing.Size(48, 35);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(424, -144);
            this.lblAge.Size = new System.Drawing.Size(52, 35);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(236, -200);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(224, -168);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(408, -200);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(264, -144);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(376, -144);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(32, -136);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(280, -152);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 120);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(280, -176);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(452, -208);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(280, -208);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(80, -144);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(452, -184);
            this.m_lsvPatientName.Size = new System.Drawing.Size(116, 120);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(280, -184);
            this.m_lsvBedNO.Size = new System.Drawing.Size(116, 120);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(80, -176);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(32, -168);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(392, -104);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 48);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -208);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 37);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -208);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 37);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -200);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 39);
            // 
            // m_txtINFACT1
            // 
            this.m_txtINFACT1.AccessibleDescription = "实入量>>1";
            this.m_txtINFACT1.BackColor = System.Drawing.Color.White;
            this.m_txtINFACT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtINFACT1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINFACT1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINFACT1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINFACT1.Location = new System.Drawing.Point(10, 104);
            this.m_txtINFACT1.m_BlnIgnoreUserInfo = false;
            this.m_txtINFACT1.m_BlnPartControl = false;
            this.m_txtINFACT1.m_BlnReadOnly = false;
            this.m_txtINFACT1.m_BlnUnderLineDST = false;
            this.m_txtINFACT1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINFACT1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINFACT1.m_IntCanModifyTime = 6;
            this.m_txtINFACT1.m_IntPartControlLength = 0;
            this.m_txtINFACT1.m_IntPartControlStartIndex = 0;
            this.m_txtINFACT1.m_StrUserID = "";
            this.m_txtINFACT1.m_StrUserName = "";
            this.m_txtINFACT1.MaxLength = 8000;
            this.m_txtINFACT1.Multiline = false;
            this.m_txtINFACT1.Name = "m_txtINFACT1";
            this.m_txtINFACT1.Size = new System.Drawing.Size(44, 28);
            this.m_txtINFACT1.TabIndex = 1000002;
            this.m_txtINFACT1.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(288, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 16);
            this.label9.TabIndex = 10000011;
            this.label9.Text = "血浆";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(256, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 10000012;
            this.label7.Text = "全血";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 40F);
            this.label8.Location = new System.Drawing.Point(264, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 48);
            this.label8.TabIndex = 10000013;
            this.label8.Text = "/";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 56);
            this.label1.TabIndex = 10000010;
            this.label1.Text = "1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(56, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 56);
            this.label2.TabIndex = 10000006;
            this.label2.Text = "2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(104, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 56);
            this.label3.TabIndex = 10000005;
            this.label3.Text = "3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(152, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 56);
            this.label4.TabIndex = 10000007;
            this.label4.Text = "4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(200, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 56);
            this.label5.TabIndex = 10000009;
            this.label5.Text = "5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(248, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 56);
            this.label6.TabIndex = 10000008;
            // 
            // m_txtINFACT2
            // 
            this.m_txtINFACT2.AccessibleDescription = "实入量>>2";
            this.m_txtINFACT2.BackColor = System.Drawing.Color.White;
            this.m_txtINFACT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtINFACT2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINFACT2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINFACT2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINFACT2.Location = new System.Drawing.Point(58, 104);
            this.m_txtINFACT2.m_BlnIgnoreUserInfo = false;
            this.m_txtINFACT2.m_BlnPartControl = false;
            this.m_txtINFACT2.m_BlnReadOnly = false;
            this.m_txtINFACT2.m_BlnUnderLineDST = false;
            this.m_txtINFACT2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINFACT2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINFACT2.m_IntCanModifyTime = 6;
            this.m_txtINFACT2.m_IntPartControlLength = 0;
            this.m_txtINFACT2.m_IntPartControlStartIndex = 0;
            this.m_txtINFACT2.m_StrUserID = "";
            this.m_txtINFACT2.m_StrUserName = "";
            this.m_txtINFACT2.MaxLength = 8000;
            this.m_txtINFACT2.Multiline = false;
            this.m_txtINFACT2.Name = "m_txtINFACT2";
            this.m_txtINFACT2.Size = new System.Drawing.Size(44, 28);
            this.m_txtINFACT2.TabIndex = 1000003;
            this.m_txtINFACT2.Text = "";
            // 
            // m_txtINFACT3
            // 
            this.m_txtINFACT3.AccessibleDescription = "实入量>>3";
            this.m_txtINFACT3.BackColor = System.Drawing.Color.White;
            this.m_txtINFACT3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtINFACT3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINFACT3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINFACT3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINFACT3.Location = new System.Drawing.Point(106, 104);
            this.m_txtINFACT3.m_BlnIgnoreUserInfo = false;
            this.m_txtINFACT3.m_BlnPartControl = false;
            this.m_txtINFACT3.m_BlnReadOnly = false;
            this.m_txtINFACT3.m_BlnUnderLineDST = false;
            this.m_txtINFACT3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINFACT3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINFACT3.m_IntCanModifyTime = 6;
            this.m_txtINFACT3.m_IntPartControlLength = 0;
            this.m_txtINFACT3.m_IntPartControlStartIndex = 0;
            this.m_txtINFACT3.m_StrUserID = "";
            this.m_txtINFACT3.m_StrUserName = "";
            this.m_txtINFACT3.MaxLength = 8000;
            this.m_txtINFACT3.Multiline = false;
            this.m_txtINFACT3.Name = "m_txtINFACT3";
            this.m_txtINFACT3.Size = new System.Drawing.Size(44, 28);
            this.m_txtINFACT3.TabIndex = 1000004;
            this.m_txtINFACT3.Text = "";
            // 
            // m_txtINFACT4
            // 
            this.m_txtINFACT4.AccessibleDescription = "实入量>>4";
            this.m_txtINFACT4.BackColor = System.Drawing.Color.White;
            this.m_txtINFACT4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtINFACT4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINFACT4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINFACT4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINFACT4.Location = new System.Drawing.Point(154, 104);
            this.m_txtINFACT4.m_BlnIgnoreUserInfo = false;
            this.m_txtINFACT4.m_BlnPartControl = false;
            this.m_txtINFACT4.m_BlnReadOnly = false;
            this.m_txtINFACT4.m_BlnUnderLineDST = false;
            this.m_txtINFACT4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINFACT4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINFACT4.m_IntCanModifyTime = 6;
            this.m_txtINFACT4.m_IntPartControlLength = 0;
            this.m_txtINFACT4.m_IntPartControlStartIndex = 0;
            this.m_txtINFACT4.m_StrUserID = "";
            this.m_txtINFACT4.m_StrUserName = "";
            this.m_txtINFACT4.MaxLength = 8000;
            this.m_txtINFACT4.Multiline = false;
            this.m_txtINFACT4.Name = "m_txtINFACT4";
            this.m_txtINFACT4.Size = new System.Drawing.Size(44, 28);
            this.m_txtINFACT4.TabIndex = 1000005;
            this.m_txtINFACT4.Text = "";
            // 
            // m_txtINFACT5
            // 
            this.m_txtINFACT5.AccessibleDescription = "实入量>>5";
            this.m_txtINFACT5.BackColor = System.Drawing.Color.White;
            this.m_txtINFACT5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtINFACT5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINFACT5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINFACT5.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINFACT5.Location = new System.Drawing.Point(202, 104);
            this.m_txtINFACT5.m_BlnIgnoreUserInfo = false;
            this.m_txtINFACT5.m_BlnPartControl = false;
            this.m_txtINFACT5.m_BlnReadOnly = false;
            this.m_txtINFACT5.m_BlnUnderLineDST = false;
            this.m_txtINFACT5.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINFACT5.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINFACT5.m_IntCanModifyTime = 6;
            this.m_txtINFACT5.m_IntPartControlLength = 0;
            this.m_txtINFACT5.m_IntPartControlStartIndex = 0;
            this.m_txtINFACT5.m_StrUserID = "";
            this.m_txtINFACT5.m_StrUserName = "";
            this.m_txtINFACT5.MaxLength = 8000;
            this.m_txtINFACT5.Multiline = false;
            this.m_txtINFACT5.Name = "m_txtINFACT5";
            this.m_txtINFACT5.Size = new System.Drawing.Size(44, 28);
            this.m_txtINFACT5.TabIndex = 1000006;
            this.m_txtINFACT5.Text = "";
            // 
            // m_txtINBLOOD
            // 
            this.m_txtINBLOOD.AccessibleDescription = "实入量>>全血/血浆";
            this.m_txtINBLOOD.BackColor = System.Drawing.Color.White;
            this.m_txtINBLOOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtINBLOOD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINBLOOD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINBLOOD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINBLOOD.Location = new System.Drawing.Point(250, 104);
            this.m_txtINBLOOD.m_BlnIgnoreUserInfo = false;
            this.m_txtINBLOOD.m_BlnPartControl = false;
            this.m_txtINBLOOD.m_BlnReadOnly = false;
            this.m_txtINBLOOD.m_BlnUnderLineDST = false;
            this.m_txtINBLOOD.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINBLOOD.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINBLOOD.m_IntCanModifyTime = 6;
            this.m_txtINBLOOD.m_IntPartControlLength = 0;
            this.m_txtINBLOOD.m_IntPartControlStartIndex = 0;
            this.m_txtINBLOOD.m_StrUserID = "";
            this.m_txtINBLOOD.m_StrUserName = "";
            this.m_txtINBLOOD.MaxLength = 8000;
            this.m_txtINBLOOD.Multiline = false;
            this.m_txtINBLOOD.Name = "m_txtINBLOOD";
            this.m_txtINBLOOD.Size = new System.Drawing.Size(76, 28);
            this.m_txtINBLOOD.TabIndex = 1000007;
            this.m_txtINBLOOD.Text = "";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(8, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(320, 23);
            this.label10.TabIndex = 10000020;
            this.label10.Text = "实      入      量";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(328, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 23);
            this.label11.TabIndex = 10000020;
            this.label11.Text = "入      量";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(328, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 56);
            this.label12.TabIndex = 10000010;
            this.label12.Text = "每时";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(376, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 56);
            this.label13.TabIndex = 10000006;
            this.label13.Text = "总量";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtINPERHOUR
            // 
            this.m_txtINPERHOUR.AccessibleDescription = "入量>>每时";
            this.m_txtINPERHOUR.BackColor = System.Drawing.Color.White;
            this.m_txtINPERHOUR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtINPERHOUR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINPERHOUR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINPERHOUR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINPERHOUR.Location = new System.Drawing.Point(330, 104);
            this.m_txtINPERHOUR.m_BlnIgnoreUserInfo = false;
            this.m_txtINPERHOUR.m_BlnPartControl = false;
            this.m_txtINPERHOUR.m_BlnReadOnly = false;
            this.m_txtINPERHOUR.m_BlnUnderLineDST = false;
            this.m_txtINPERHOUR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINPERHOUR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINPERHOUR.m_IntCanModifyTime = 6;
            this.m_txtINPERHOUR.m_IntPartControlLength = 0;
            this.m_txtINPERHOUR.m_IntPartControlStartIndex = 0;
            this.m_txtINPERHOUR.m_StrUserID = "";
            this.m_txtINPERHOUR.m_StrUserName = "";
            this.m_txtINPERHOUR.MaxLength = 8000;
            this.m_txtINPERHOUR.Multiline = false;
            this.m_txtINPERHOUR.Name = "m_txtINPERHOUR";
            this.m_txtINPERHOUR.Size = new System.Drawing.Size(44, 28);
            this.m_txtINPERHOUR.TabIndex = 1000008;
            this.m_txtINPERHOUR.Text = "";
            // 
            // m_txtINSUM
            // 
            this.m_txtINSUM.AccessibleDescription = "入量>>总量";
            this.m_txtINSUM.BackColor = System.Drawing.Color.White;
            this.m_txtINSUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtINSUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINSUM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINSUM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINSUM.Location = new System.Drawing.Point(378, 104);
            this.m_txtINSUM.m_BlnIgnoreUserInfo = false;
            this.m_txtINSUM.m_BlnPartControl = false;
            this.m_txtINSUM.m_BlnReadOnly = false;
            this.m_txtINSUM.m_BlnUnderLineDST = false;
            this.m_txtINSUM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINSUM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINSUM.m_IntCanModifyTime = 6;
            this.m_txtINSUM.m_IntPartControlLength = 0;
            this.m_txtINSUM.m_IntPartControlStartIndex = 0;
            this.m_txtINSUM.m_StrUserID = "";
            this.m_txtINSUM.m_StrUserName = "";
            this.m_txtINSUM.MaxLength = 8000;
            this.m_txtINSUM.Multiline = false;
            this.m_txtINSUM.Name = "m_txtINSUM";
            this.m_txtINSUM.Size = new System.Drawing.Size(44, 28);
            this.m_txtINSUM.TabIndex = 1000009;
            this.m_txtINSUM.Text = "";
            // 
            // m_txtOUTPERHOUR
            // 
            this.m_txtOUTPERHOUR.AccessibleDescription = "出量>>每时";
            this.m_txtOUTPERHOUR.BackColor = System.Drawing.Color.White;
            this.m_txtOUTPERHOUR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOUTPERHOUR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTPERHOUR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTPERHOUR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTPERHOUR.Location = new System.Drawing.Point(474, 104);
            this.m_txtOUTPERHOUR.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTPERHOUR.m_BlnPartControl = false;
            this.m_txtOUTPERHOUR.m_BlnReadOnly = false;
            this.m_txtOUTPERHOUR.m_BlnUnderLineDST = false;
            this.m_txtOUTPERHOUR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTPERHOUR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTPERHOUR.m_IntCanModifyTime = 6;
            this.m_txtOUTPERHOUR.m_IntPartControlLength = 0;
            this.m_txtOUTPERHOUR.m_IntPartControlStartIndex = 0;
            this.m_txtOUTPERHOUR.m_StrUserID = "";
            this.m_txtOUTPERHOUR.m_StrUserName = "";
            this.m_txtOUTPERHOUR.MaxLength = 8000;
            this.m_txtOUTPERHOUR.Multiline = false;
            this.m_txtOUTPERHOUR.Name = "m_txtOUTPERHOUR";
            this.m_txtOUTPERHOUR.Size = new System.Drawing.Size(44, 28);
            this.m_txtOUTPERHOUR.TabIndex = 1000011;
            this.m_txtOUTPERHOUR.Text = "";
            // 
            // m_txtOUTSUM
            // 
            this.m_txtOUTSUM.AccessibleDescription = "出量>>总量";
            this.m_txtOUTSUM.BackColor = System.Drawing.Color.White;
            this.m_txtOUTSUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOUTSUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTSUM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTSUM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTSUM.Location = new System.Drawing.Point(426, 104);
            this.m_txtOUTSUM.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTSUM.m_BlnPartControl = false;
            this.m_txtOUTSUM.m_BlnReadOnly = false;
            this.m_txtOUTSUM.m_BlnUnderLineDST = false;
            this.m_txtOUTSUM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTSUM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTSUM.m_IntCanModifyTime = 6;
            this.m_txtOUTSUM.m_IntPartControlLength = 0;
            this.m_txtOUTSUM.m_IntPartControlStartIndex = 0;
            this.m_txtOUTSUM.m_StrUserID = "";
            this.m_txtOUTSUM.m_StrUserName = "";
            this.m_txtOUTSUM.MaxLength = 8000;
            this.m_txtOUTSUM.Multiline = false;
            this.m_txtOUTSUM.Name = "m_txtOUTSUM";
            this.m_txtOUTSUM.Size = new System.Drawing.Size(44, 28);
            this.m_txtOUTSUM.TabIndex = 1000010;
            this.m_txtOUTSUM.Text = "";
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(424, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 23);
            this.label14.TabIndex = 10000020;
            this.label14.Text = "出      量";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(424, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 56);
            this.label15.TabIndex = 10000010;
            this.label15.Text = "总量";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(472, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 56);
            this.label16.TabIndex = 10000006;
            this.label16.Text = "每时";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(520, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(240, 23);
            this.label17.TabIndex = 10000020;
            this.label17.Text = "实      出      量";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtOUTFACTPISSSUM
            // 
            this.m_txtOUTFACTPISSSUM.AccessibleDescription = "实出量>>累积尿量";
            this.m_txtOUTFACTPISSSUM.BackColor = System.Drawing.Color.White;
            this.m_txtOUTFACTPISSSUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOUTFACTPISSSUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTFACTPISSSUM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTFACTPISSSUM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTFACTPISSSUM.Location = new System.Drawing.Point(522, 104);
            this.m_txtOUTFACTPISSSUM.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTFACTPISSSUM.m_BlnPartControl = false;
            this.m_txtOUTFACTPISSSUM.m_BlnReadOnly = false;
            this.m_txtOUTFACTPISSSUM.m_BlnUnderLineDST = false;
            this.m_txtOUTFACTPISSSUM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTFACTPISSSUM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTFACTPISSSUM.m_IntCanModifyTime = 6;
            this.m_txtOUTFACTPISSSUM.m_IntPartControlLength = 0;
            this.m_txtOUTFACTPISSSUM.m_IntPartControlStartIndex = 0;
            this.m_txtOUTFACTPISSSUM.m_StrUserID = "";
            this.m_txtOUTFACTPISSSUM.m_StrUserName = "";
            this.m_txtOUTFACTPISSSUM.MaxLength = 8000;
            this.m_txtOUTFACTPISSSUM.Multiline = false;
            this.m_txtOUTFACTPISSSUM.Name = "m_txtOUTFACTPISSSUM";
            this.m_txtOUTFACTPISSSUM.Size = new System.Drawing.Size(44, 28);
            this.m_txtOUTFACTPISSSUM.TabIndex = 1000012;
            this.m_txtOUTFACTPISSSUM.Text = "";
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Location = new System.Drawing.Point(520, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 56);
            this.label18.TabIndex = 10000010;
            this.label18.Text = "累积尿量";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Location = new System.Drawing.Point(568, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 56);
            this.label19.TabIndex = 10000006;
            this.label19.Text = "尿量";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(616, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 56);
            this.label20.TabIndex = 10000005;
            this.label20.Text = "胸液";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Location = new System.Drawing.Point(664, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 56);
            this.label21.TabIndex = 10000007;
            this.label21.Text = "积累胸液";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(712, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 56);
            this.label22.TabIndex = 10000009;
            this.label22.Text = "胃液";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtOUTFACTPISS
            // 
            this.m_txtOUTFACTPISS.AccessibleDescription = "实出量>>尿量";
            this.m_txtOUTFACTPISS.BackColor = System.Drawing.Color.White;
            this.m_txtOUTFACTPISS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOUTFACTPISS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTFACTPISS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTFACTPISS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTFACTPISS.Location = new System.Drawing.Point(570, 104);
            this.m_txtOUTFACTPISS.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTFACTPISS.m_BlnPartControl = false;
            this.m_txtOUTFACTPISS.m_BlnReadOnly = false;
            this.m_txtOUTFACTPISS.m_BlnUnderLineDST = false;
            this.m_txtOUTFACTPISS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTFACTPISS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTFACTPISS.m_IntCanModifyTime = 6;
            this.m_txtOUTFACTPISS.m_IntPartControlLength = 0;
            this.m_txtOUTFACTPISS.m_IntPartControlStartIndex = 0;
            this.m_txtOUTFACTPISS.m_StrUserID = "";
            this.m_txtOUTFACTPISS.m_StrUserName = "";
            this.m_txtOUTFACTPISS.MaxLength = 8000;
            this.m_txtOUTFACTPISS.Multiline = false;
            this.m_txtOUTFACTPISS.Name = "m_txtOUTFACTPISS";
            this.m_txtOUTFACTPISS.Size = new System.Drawing.Size(44, 28);
            this.m_txtOUTFACTPISS.TabIndex = 1000013;
            this.m_txtOUTFACTPISS.Text = "";
            // 
            // m_txtOUTFACTCHESTJUICE
            // 
            this.m_txtOUTFACTCHESTJUICE.AccessibleDescription = "实出量>>胸液";
            this.m_txtOUTFACTCHESTJUICE.BackColor = System.Drawing.Color.White;
            this.m_txtOUTFACTCHESTJUICE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOUTFACTCHESTJUICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTFACTCHESTJUICE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTFACTCHESTJUICE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTFACTCHESTJUICE.Location = new System.Drawing.Point(618, 104);
            this.m_txtOUTFACTCHESTJUICE.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTFACTCHESTJUICE.m_BlnPartControl = false;
            this.m_txtOUTFACTCHESTJUICE.m_BlnReadOnly = false;
            this.m_txtOUTFACTCHESTJUICE.m_BlnUnderLineDST = false;
            this.m_txtOUTFACTCHESTJUICE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTFACTCHESTJUICE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTFACTCHESTJUICE.m_IntCanModifyTime = 6;
            this.m_txtOUTFACTCHESTJUICE.m_IntPartControlLength = 0;
            this.m_txtOUTFACTCHESTJUICE.m_IntPartControlStartIndex = 0;
            this.m_txtOUTFACTCHESTJUICE.m_StrUserID = "";
            this.m_txtOUTFACTCHESTJUICE.m_StrUserName = "";
            this.m_txtOUTFACTCHESTJUICE.MaxLength = 8000;
            this.m_txtOUTFACTCHESTJUICE.Multiline = false;
            this.m_txtOUTFACTCHESTJUICE.Name = "m_txtOUTFACTCHESTJUICE";
            this.m_txtOUTFACTCHESTJUICE.Size = new System.Drawing.Size(44, 28);
            this.m_txtOUTFACTCHESTJUICE.TabIndex = 1000014;
            this.m_txtOUTFACTCHESTJUICE.Text = "";
            // 
            // m_txtOUTFACTCHESTJUICESUM
            // 
            this.m_txtOUTFACTCHESTJUICESUM.AccessibleDescription = "实出量>>积累胸液";
            this.m_txtOUTFACTCHESTJUICESUM.BackColor = System.Drawing.Color.White;
            this.m_txtOUTFACTCHESTJUICESUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOUTFACTCHESTJUICESUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTFACTCHESTJUICESUM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTFACTCHESTJUICESUM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTFACTCHESTJUICESUM.Location = new System.Drawing.Point(666, 104);
            this.m_txtOUTFACTCHESTJUICESUM.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTFACTCHESTJUICESUM.m_BlnPartControl = false;
            this.m_txtOUTFACTCHESTJUICESUM.m_BlnReadOnly = false;
            this.m_txtOUTFACTCHESTJUICESUM.m_BlnUnderLineDST = false;
            this.m_txtOUTFACTCHESTJUICESUM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTFACTCHESTJUICESUM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTFACTCHESTJUICESUM.m_IntCanModifyTime = 6;
            this.m_txtOUTFACTCHESTJUICESUM.m_IntPartControlLength = 0;
            this.m_txtOUTFACTCHESTJUICESUM.m_IntPartControlStartIndex = 0;
            this.m_txtOUTFACTCHESTJUICESUM.m_StrUserID = "";
            this.m_txtOUTFACTCHESTJUICESUM.m_StrUserName = "";
            this.m_txtOUTFACTCHESTJUICESUM.MaxLength = 8000;
            this.m_txtOUTFACTCHESTJUICESUM.Multiline = false;
            this.m_txtOUTFACTCHESTJUICESUM.Name = "m_txtOUTFACTCHESTJUICESUM";
            this.m_txtOUTFACTCHESTJUICESUM.Size = new System.Drawing.Size(44, 28);
            this.m_txtOUTFACTCHESTJUICESUM.TabIndex = 1000015;
            this.m_txtOUTFACTCHESTJUICESUM.Text = "";
            // 
            // m_txtOUTFACTGASTRICJUICE
            // 
            this.m_txtOUTFACTGASTRICJUICE.AccessibleDescription = "实出量>>胃液";
            this.m_txtOUTFACTGASTRICJUICE.BackColor = System.Drawing.Color.White;
            this.m_txtOUTFACTGASTRICJUICE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOUTFACTGASTRICJUICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTFACTGASTRICJUICE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTFACTGASTRICJUICE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTFACTGASTRICJUICE.Location = new System.Drawing.Point(714, 104);
            this.m_txtOUTFACTGASTRICJUICE.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTFACTGASTRICJUICE.m_BlnPartControl = false;
            this.m_txtOUTFACTGASTRICJUICE.m_BlnReadOnly = false;
            this.m_txtOUTFACTGASTRICJUICE.m_BlnUnderLineDST = false;
            this.m_txtOUTFACTGASTRICJUICE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTFACTGASTRICJUICE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTFACTGASTRICJUICE.m_IntCanModifyTime = 6;
            this.m_txtOUTFACTGASTRICJUICE.m_IntPartControlLength = 0;
            this.m_txtOUTFACTGASTRICJUICE.m_IntPartControlStartIndex = 0;
            this.m_txtOUTFACTGASTRICJUICE.m_StrUserID = "";
            this.m_txtOUTFACTGASTRICJUICE.m_StrUserName = "";
            this.m_txtOUTFACTGASTRICJUICE.MaxLength = 8000;
            this.m_txtOUTFACTGASTRICJUICE.Multiline = false;
            this.m_txtOUTFACTGASTRICJUICE.Name = "m_txtOUTFACTGASTRICJUICE";
            this.m_txtOUTFACTGASTRICJUICE.Size = new System.Drawing.Size(44, 28);
            this.m_txtOUTFACTGASTRICJUICE.TabIndex = 1000016;
            this.m_txtOUTFACTGASTRICJUICE.Text = "";
            // 
            // m_lsvEXPANDVASMEDICINE
            // 
            this.m_lsvEXPANDVASMEDICINE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EXPANDVASMEDICINE,
            this.MEDICINEMethod,
            this.MEDICINENum});
            this.m_lsvEXPANDVASMEDICINE.FullRowSelect = true;
            this.m_lsvEXPANDVASMEDICINE.GridLines = true;
            this.m_lsvEXPANDVASMEDICINE.Location = new System.Drawing.Point(100, 16);
            this.m_lsvEXPANDVASMEDICINE.Name = "m_lsvEXPANDVASMEDICINE";
            this.m_lsvEXPANDVASMEDICINE.Size = new System.Drawing.Size(134, 84);
            this.m_lsvEXPANDVASMEDICINE.TabIndex = 1000021;
            this.m_lsvEXPANDVASMEDICINE.UseCompatibleStateImageBehavior = false;
            this.m_lsvEXPANDVASMEDICINE.View = System.Windows.Forms.View.Details;
            // 
            // EXPANDVASMEDICINE
            // 
            this.EXPANDVASMEDICINE.Text = "药名";
            this.EXPANDVASMEDICINE.Width = 50;
            // 
            // MEDICINEMethod
            // 
            this.MEDICINEMethod.Text = "用法";
            this.MEDICINEMethod.Width = 40;
            // 
            // MEDICINENum
            // 
            this.MEDICINENum.Text = "剂量";
            this.MEDICINENum.Width = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label105);
            this.groupBox1.Controls.Add(this.m_txtEXPANDVASMEDICINEMethod);
            this.groupBox1.Controls.Add(this.label99);
            this.groupBox1.Controls.Add(this.m_txtEXPANDVASMEDICINENum);
            this.groupBox1.Controls.Add(this.m_cboEXPANDVASMEDICINE);
            this.groupBox1.Controls.Add(this.m_cmdAddEXPANDVASMEDICINE);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.m_lsvEXPANDVASMEDICINE);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.m_cmdRemoveEXPANDVASMEDICINE);
            this.groupBox1.Location = new System.Drawing.Point(760, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 127);
            this.groupBox1.TabIndex = 1000017;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "升压扩张血管药物ug/kg/min";
            // 
            // m_txtEXPANDVASMEDICINEMethod
            // 
            this.m_txtEXPANDVASMEDICINEMethod.AccessibleDescription = "升压扩张血管药物>>用法";
            this.m_txtEXPANDVASMEDICINEMethod.BackColor = System.Drawing.Color.White;
            this.m_txtEXPANDVASMEDICINEMethod.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEXPANDVASMEDICINEMethod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEXPANDVASMEDICINEMethod.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEXPANDVASMEDICINEMethod.Location = new System.Drawing.Point(40, 45);
            this.m_txtEXPANDVASMEDICINEMethod.m_BlnIgnoreUserInfo = false;
            this.m_txtEXPANDVASMEDICINEMethod.m_BlnPartControl = false;
            this.m_txtEXPANDVASMEDICINEMethod.m_BlnReadOnly = false;
            this.m_txtEXPANDVASMEDICINEMethod.m_BlnUnderLineDST = false;
            this.m_txtEXPANDVASMEDICINEMethod.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEXPANDVASMEDICINEMethod.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEXPANDVASMEDICINEMethod.m_IntCanModifyTime = 6;
            this.m_txtEXPANDVASMEDICINEMethod.m_IntPartControlLength = 0;
            this.m_txtEXPANDVASMEDICINEMethod.m_IntPartControlStartIndex = 0;
            this.m_txtEXPANDVASMEDICINEMethod.m_StrUserID = "";
            this.m_txtEXPANDVASMEDICINEMethod.m_StrUserName = "";
            this.m_txtEXPANDVASMEDICINEMethod.MaxLength = 8000;
            this.m_txtEXPANDVASMEDICINEMethod.Multiline = false;
            this.m_txtEXPANDVASMEDICINEMethod.Name = "m_txtEXPANDVASMEDICINEMethod";
            this.m_txtEXPANDVASMEDICINEMethod.Size = new System.Drawing.Size(48, 22);
            this.m_txtEXPANDVASMEDICINEMethod.TabIndex = 1000019;
            this.m_txtEXPANDVASMEDICINEMethod.Text = "";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(4, 45);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(42, 14);
            this.label99.TabIndex = 10000393;
            this.label99.Text = "用法:";
            // 
            // m_txtEXPANDVASMEDICINENum
            // 
            this.m_txtEXPANDVASMEDICINENum.AccessibleDescription = "升压扩张血管药物>>剂量";
            this.m_txtEXPANDVASMEDICINENum.BackColor = System.Drawing.Color.White;
            this.m_txtEXPANDVASMEDICINENum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEXPANDVASMEDICINENum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEXPANDVASMEDICINENum.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEXPANDVASMEDICINENum.Location = new System.Drawing.Point(40, 69);
            this.m_txtEXPANDVASMEDICINENum.m_BlnIgnoreUserInfo = false;
            this.m_txtEXPANDVASMEDICINENum.m_BlnPartControl = false;
            this.m_txtEXPANDVASMEDICINENum.m_BlnReadOnly = false;
            this.m_txtEXPANDVASMEDICINENum.m_BlnUnderLineDST = false;
            this.m_txtEXPANDVASMEDICINENum.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEXPANDVASMEDICINENum.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEXPANDVASMEDICINENum.m_IntCanModifyTime = 6;
            this.m_txtEXPANDVASMEDICINENum.m_IntPartControlLength = 0;
            this.m_txtEXPANDVASMEDICINENum.m_IntPartControlStartIndex = 0;
            this.m_txtEXPANDVASMEDICINENum.m_StrUserID = "";
            this.m_txtEXPANDVASMEDICINENum.m_StrUserName = "";
            this.m_txtEXPANDVASMEDICINENum.MaxLength = 8000;
            this.m_txtEXPANDVASMEDICINENum.Multiline = false;
            this.m_txtEXPANDVASMEDICINENum.Name = "m_txtEXPANDVASMEDICINENum";
            this.m_txtEXPANDVASMEDICINENum.Size = new System.Drawing.Size(48, 22);
            this.m_txtEXPANDVASMEDICINENum.TabIndex = 1000020;
            this.m_txtEXPANDVASMEDICINENum.Text = "";
            // 
            // m_cboEXPANDVASMEDICINE
            // 
            this.m_cboEXPANDVASMEDICINE.AccessibleDescription = "升压扩张血管药物>>药名";
            this.m_cboEXPANDVASMEDICINE.BackColor = System.Drawing.Color.White;
            this.m_cboEXPANDVASMEDICINE.BorderColor = System.Drawing.Color.Black;
            this.m_cboEXPANDVASMEDICINE.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboEXPANDVASMEDICINE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboEXPANDVASMEDICINE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboEXPANDVASMEDICINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboEXPANDVASMEDICINE.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEXPANDVASMEDICINE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboEXPANDVASMEDICINE.ForeColor = System.Drawing.Color.Black;
            this.m_cboEXPANDVASMEDICINE.ListBackColor = System.Drawing.Color.White;
            this.m_cboEXPANDVASMEDICINE.ListForeColor = System.Drawing.Color.Black;
            this.m_cboEXPANDVASMEDICINE.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboEXPANDVASMEDICINE.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboEXPANDVASMEDICINE.Location = new System.Drawing.Point(40, 20);
            this.m_cboEXPANDVASMEDICINE.m_BlnEnableItemEventMenu = true;
            this.m_cboEXPANDVASMEDICINE.Name = "m_cboEXPANDVASMEDICINE";
            this.m_cboEXPANDVASMEDICINE.SelectedIndex = -1;
            this.m_cboEXPANDVASMEDICINE.SelectedItem = null;
            this.m_cboEXPANDVASMEDICINE.SelectionStart = 0;
            this.m_cboEXPANDVASMEDICINE.Size = new System.Drawing.Size(61, 23);
            this.m_cboEXPANDVASMEDICINE.TabIndex = 1000018;
            this.m_cboEXPANDVASMEDICINE.TextBackColor = System.Drawing.Color.White;
            this.m_cboEXPANDVASMEDICINE.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdAddEXPANDVASMEDICINE
            // 
            this.m_cmdAddEXPANDVASMEDICINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddEXPANDVASMEDICINE.DefaultScheme = true;
            this.m_cmdAddEXPANDVASMEDICINE.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddEXPANDVASMEDICINE.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAddEXPANDVASMEDICINE.Hint = "";
            this.m_cmdAddEXPANDVASMEDICINE.Location = new System.Drawing.Point(13, 97);
            this.m_cmdAddEXPANDVASMEDICINE.Name = "m_cmdAddEXPANDVASMEDICINE";
            this.m_cmdAddEXPANDVASMEDICINE.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddEXPANDVASMEDICINE.Size = new System.Drawing.Size(40, 24);
            this.m_cmdAddEXPANDVASMEDICINE.TabIndex = 1000022;
            this.m_cmdAddEXPANDVASMEDICINE.Text = "添加";
            this.m_cmdAddEXPANDVASMEDICINE.Click += new System.EventHandler(this.m_cmdAddEXPANDVASMEDICINE_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 14);
            this.label23.TabIndex = 10000022;
            this.label23.Text = "药名:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(4, 69);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 14);
            this.label24.TabIndex = 10000022;
            this.label24.Text = "剂量:";
            // 
            // m_cmdRemoveEXPANDVASMEDICINE
            // 
            this.m_cmdRemoveEXPANDVASMEDICINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRemoveEXPANDVASMEDICINE.DefaultScheme = true;
            this.m_cmdRemoveEXPANDVASMEDICINE.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRemoveEXPANDVASMEDICINE.ForeColor = System.Drawing.Color.Black;
            this.m_cmdRemoveEXPANDVASMEDICINE.Hint = "";
            this.m_cmdRemoveEXPANDVASMEDICINE.Location = new System.Drawing.Point(61, 97);
            this.m_cmdRemoveEXPANDVASMEDICINE.Name = "m_cmdRemoveEXPANDVASMEDICINE";
            this.m_cmdRemoveEXPANDVASMEDICINE.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRemoveEXPANDVASMEDICINE.Size = new System.Drawing.Size(40, 24);
            this.m_cmdRemoveEXPANDVASMEDICINE.TabIndex = 1000023;
            this.m_cmdRemoveEXPANDVASMEDICINE.Text = "移除";
            this.m_cmdRemoveEXPANDVASMEDICINE.Click += new System.EventHandler(this.m_cmdRemoveEXPANDVASMEDICINE_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label103);
            this.groupBox2.Controls.Add(this.m_txtCARDIACDIURESISMethod);
            this.groupBox2.Controls.Add(this.label98);
            this.groupBox2.Controls.Add(this.m_cboCARDIACDIURESIS);
            this.groupBox2.Controls.Add(this.m_txtCARDIACDIURESISNum);
            this.groupBox2.Controls.Add(this.m_cmdAddCARDIACDIURESIS);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.m_lsvCARDIACDIURESIS);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.m_cmdRemoveCARDIACDIURESIS);
            this.groupBox2.Location = new System.Drawing.Point(1, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 117);
            this.groupBox2.TabIndex = 1000024;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "强心利尿";
            // 
            // m_txtCARDIACDIURESISMethod
            // 
            this.m_txtCARDIACDIURESISMethod.AccessibleDescription = "强心利尿>>用法";
            this.m_txtCARDIACDIURESISMethod.BackColor = System.Drawing.Color.White;
            this.m_txtCARDIACDIURESISMethod.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCARDIACDIURESISMethod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCARDIACDIURESISMethod.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCARDIACDIURESISMethod.Location = new System.Drawing.Point(40, 48);
            this.m_txtCARDIACDIURESISMethod.m_BlnIgnoreUserInfo = false;
            this.m_txtCARDIACDIURESISMethod.m_BlnPartControl = false;
            this.m_txtCARDIACDIURESISMethod.m_BlnReadOnly = false;
            this.m_txtCARDIACDIURESISMethod.m_BlnUnderLineDST = false;
            this.m_txtCARDIACDIURESISMethod.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCARDIACDIURESISMethod.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCARDIACDIURESISMethod.m_IntCanModifyTime = 6;
            this.m_txtCARDIACDIURESISMethod.m_IntPartControlLength = 0;
            this.m_txtCARDIACDIURESISMethod.m_IntPartControlStartIndex = 0;
            this.m_txtCARDIACDIURESISMethod.m_StrUserID = "";
            this.m_txtCARDIACDIURESISMethod.m_StrUserName = "";
            this.m_txtCARDIACDIURESISMethod.MaxLength = 8000;
            this.m_txtCARDIACDIURESISMethod.Multiline = false;
            this.m_txtCARDIACDIURESISMethod.Name = "m_txtCARDIACDIURESISMethod";
            this.m_txtCARDIACDIURESISMethod.Size = new System.Drawing.Size(61, 22);
            this.m_txtCARDIACDIURESISMethod.TabIndex = 1000026;
            this.m_txtCARDIACDIURESISMethod.Text = "";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(4, 48);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(42, 14);
            this.label98.TabIndex = 10000391;
            this.label98.Text = "用法:";
            // 
            // m_cboCARDIACDIURESIS
            // 
            this.m_cboCARDIACDIURESIS.AccessibleDescription = "强心利尿>>药名";
            this.m_cboCARDIACDIURESIS.BackColor = System.Drawing.Color.White;
            this.m_cboCARDIACDIURESIS.BorderColor = System.Drawing.Color.Black;
            this.m_cboCARDIACDIURESIS.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCARDIACDIURESIS.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCARDIACDIURESIS.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCARDIACDIURESIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCARDIACDIURESIS.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCARDIACDIURESIS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCARDIACDIURESIS.ForeColor = System.Drawing.Color.Black;
            this.m_cboCARDIACDIURESIS.ListBackColor = System.Drawing.Color.White;
            this.m_cboCARDIACDIURESIS.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCARDIACDIURESIS.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCARDIACDIURESIS.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCARDIACDIURESIS.Location = new System.Drawing.Point(40, 24);
            this.m_cboCARDIACDIURESIS.m_BlnEnableItemEventMenu = true;
            this.m_cboCARDIACDIURESIS.Name = "m_cboCARDIACDIURESIS";
            this.m_cboCARDIACDIURESIS.SelectedIndex = -1;
            this.m_cboCARDIACDIURESIS.SelectedItem = null;
            this.m_cboCARDIACDIURESIS.SelectionStart = 0;
            this.m_cboCARDIACDIURESIS.Size = new System.Drawing.Size(66, 23);
            this.m_cboCARDIACDIURESIS.TabIndex = 1000025;
            this.m_cboCARDIACDIURESIS.TextBackColor = System.Drawing.Color.White;
            this.m_cboCARDIACDIURESIS.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtCARDIACDIURESISNum
            // 
            this.m_txtCARDIACDIURESISNum.AccessibleDescription = "强心利尿>>剂量";
            this.m_txtCARDIACDIURESISNum.BackColor = System.Drawing.Color.White;
            this.m_txtCARDIACDIURESISNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCARDIACDIURESISNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCARDIACDIURESISNum.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCARDIACDIURESISNum.Location = new System.Drawing.Point(40, 71);
            this.m_txtCARDIACDIURESISNum.m_BlnIgnoreUserInfo = false;
            this.m_txtCARDIACDIURESISNum.m_BlnPartControl = false;
            this.m_txtCARDIACDIURESISNum.m_BlnReadOnly = false;
            this.m_txtCARDIACDIURESISNum.m_BlnUnderLineDST = false;
            this.m_txtCARDIACDIURESISNum.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCARDIACDIURESISNum.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCARDIACDIURESISNum.m_IntCanModifyTime = 6;
            this.m_txtCARDIACDIURESISNum.m_IntPartControlLength = 0;
            this.m_txtCARDIACDIURESISNum.m_IntPartControlStartIndex = 0;
            this.m_txtCARDIACDIURESISNum.m_StrUserID = "";
            this.m_txtCARDIACDIURESISNum.m_StrUserName = "";
            this.m_txtCARDIACDIURESISNum.MaxLength = 8000;
            this.m_txtCARDIACDIURESISNum.Multiline = false;
            this.m_txtCARDIACDIURESISNum.Name = "m_txtCARDIACDIURESISNum";
            this.m_txtCARDIACDIURESISNum.Size = new System.Drawing.Size(61, 22);
            this.m_txtCARDIACDIURESISNum.TabIndex = 1000027;
            this.m_txtCARDIACDIURESISNum.Text = "";
            // 
            // m_cmdAddCARDIACDIURESIS
            // 
            this.m_cmdAddCARDIACDIURESIS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddCARDIACDIURESIS.DefaultScheme = true;
            this.m_cmdAddCARDIACDIURESIS.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddCARDIACDIURESIS.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAddCARDIACDIURESIS.Hint = "";
            this.m_cmdAddCARDIACDIURESIS.Location = new System.Drawing.Point(8, 93);
            this.m_cmdAddCARDIACDIURESIS.Name = "m_cmdAddCARDIACDIURESIS";
            this.m_cmdAddCARDIACDIURESIS.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddCARDIACDIURESIS.Size = new System.Drawing.Size(40, 24);
            this.m_cmdAddCARDIACDIURESIS.TabIndex = 1000029;
            this.m_cmdAddCARDIACDIURESIS.Text = "添加";
            this.m_cmdAddCARDIACDIURESIS.Click += new System.EventHandler(this.m_cmdAddCARDIACDIURESIS_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 14);
            this.label25.TabIndex = 10000022;
            this.label25.Text = "药名:";
            // 
            // m_lsvCARDIACDIURESIS
            // 
            this.m_lsvCARDIACDIURESIS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2});
            this.m_lsvCARDIACDIURESIS.FullRowSelect = true;
            this.m_lsvCARDIACDIURESIS.GridLines = true;
            this.m_lsvCARDIACDIURESIS.Location = new System.Drawing.Point(108, 16);
            this.m_lsvCARDIACDIURESIS.Name = "m_lsvCARDIACDIURESIS";
            this.m_lsvCARDIACDIURESIS.Size = new System.Drawing.Size(134, 80);
            this.m_lsvCARDIACDIURESIS.TabIndex = 1000028;
            this.m_lsvCARDIACDIURESIS.UseCompatibleStateImageBehavior = false;
            this.m_lsvCARDIACDIURESIS.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "药名";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "用法";
            this.columnHeader5.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "剂量";
            this.columnHeader2.Width = 40;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 70);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(42, 14);
            this.label26.TabIndex = 10000022;
            this.label26.Text = "剂量:";
            // 
            // m_cmdRemoveCARDIACDIURESIS
            // 
            this.m_cmdRemoveCARDIACDIURESIS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRemoveCARDIACDIURESIS.DefaultScheme = true;
            this.m_cmdRemoveCARDIACDIURESIS.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRemoveCARDIACDIURESIS.ForeColor = System.Drawing.Color.Black;
            this.m_cmdRemoveCARDIACDIURESIS.Hint = "";
            this.m_cmdRemoveCARDIACDIURESIS.Location = new System.Drawing.Point(56, 93);
            this.m_cmdRemoveCARDIACDIURESIS.Name = "m_cmdRemoveCARDIACDIURESIS";
            this.m_cmdRemoveCARDIACDIURESIS.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRemoveCARDIACDIURESIS.Size = new System.Drawing.Size(40, 24);
            this.m_cmdRemoveCARDIACDIURESIS.TabIndex = 1000030;
            this.m_cmdRemoveCARDIACDIURESIS.Text = "移除";
            this.m_cmdRemoveCARDIACDIURESIS.Click += new System.EventHandler(this.m_cmdRemoveCARDIACDIURESIS_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label104);
            this.groupBox3.Controls.Add(this.m_txtOTHERMEDICINEMethod);
            this.groupBox3.Controls.Add(this.m_cboOTHERMEDICINE);
            this.groupBox3.Controls.Add(this.m_txtOTHERMEDICINENum);
            this.groupBox3.Controls.Add(this.label102);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.m_cmdAddOTHERMEDICINE);
            this.groupBox3.Controls.Add(this.m_lsvOTHERMEDICINE);
            this.groupBox3.Controls.Add(this.m_cmdRemoveOTHERMEDICINE);
            this.groupBox3.Location = new System.Drawing.Point(245, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 117);
            this.groupBox3.TabIndex = 1000031;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他药物";
            // 
            // m_txtOTHERMEDICINEMethod
            // 
            this.m_txtOTHERMEDICINEMethod.AccessibleDescription = "其他药物>>用法";
            this.m_txtOTHERMEDICINEMethod.BackColor = System.Drawing.Color.White;
            this.m_txtOTHERMEDICINEMethod.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOTHERMEDICINEMethod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOTHERMEDICINEMethod.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOTHERMEDICINEMethod.Location = new System.Drawing.Point(40, 45);
            this.m_txtOTHERMEDICINEMethod.m_BlnIgnoreUserInfo = false;
            this.m_txtOTHERMEDICINEMethod.m_BlnPartControl = false;
            this.m_txtOTHERMEDICINEMethod.m_BlnReadOnly = false;
            this.m_txtOTHERMEDICINEMethod.m_BlnUnderLineDST = false;
            this.m_txtOTHERMEDICINEMethod.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOTHERMEDICINEMethod.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOTHERMEDICINEMethod.m_IntCanModifyTime = 6;
            this.m_txtOTHERMEDICINEMethod.m_IntPartControlLength = 0;
            this.m_txtOTHERMEDICINEMethod.m_IntPartControlStartIndex = 0;
            this.m_txtOTHERMEDICINEMethod.m_StrUserID = "";
            this.m_txtOTHERMEDICINEMethod.m_StrUserName = "";
            this.m_txtOTHERMEDICINEMethod.MaxLength = 8000;
            this.m_txtOTHERMEDICINEMethod.Multiline = false;
            this.m_txtOTHERMEDICINEMethod.Name = "m_txtOTHERMEDICINEMethod";
            this.m_txtOTHERMEDICINEMethod.Size = new System.Drawing.Size(67, 22);
            this.m_txtOTHERMEDICINEMethod.TabIndex = 1000032;
            this.m_txtOTHERMEDICINEMethod.Text = "";
            // 
            // m_cboOTHERMEDICINE
            // 
            this.m_cboOTHERMEDICINE.AccessibleDescription = "其他药物>>药名";
            this.m_cboOTHERMEDICINE.BackColor = System.Drawing.Color.White;
            this.m_cboOTHERMEDICINE.BorderColor = System.Drawing.Color.Black;
            this.m_cboOTHERMEDICINE.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOTHERMEDICINE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOTHERMEDICINE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOTHERMEDICINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOTHERMEDICINE.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOTHERMEDICINE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOTHERMEDICINE.ForeColor = System.Drawing.Color.Black;
            this.m_cboOTHERMEDICINE.ListBackColor = System.Drawing.Color.White;
            this.m_cboOTHERMEDICINE.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOTHERMEDICINE.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOTHERMEDICINE.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOTHERMEDICINE.Location = new System.Drawing.Point(40, 24);
            this.m_cboOTHERMEDICINE.m_BlnEnableItemEventMenu = true;
            this.m_cboOTHERMEDICINE.Name = "m_cboOTHERMEDICINE";
            this.m_cboOTHERMEDICINE.SelectedIndex = -1;
            this.m_cboOTHERMEDICINE.SelectedItem = null;
            this.m_cboOTHERMEDICINE.SelectionStart = 0;
            this.m_cboOTHERMEDICINE.Size = new System.Drawing.Size(66, 23);
            this.m_cboOTHERMEDICINE.TabIndex = 1000031;
            this.m_cboOTHERMEDICINE.TextBackColor = System.Drawing.Color.White;
            this.m_cboOTHERMEDICINE.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtOTHERMEDICINENum
            // 
            this.m_txtOTHERMEDICINENum.AccessibleDescription = "其他药物>>剂量";
            this.m_txtOTHERMEDICINENum.BackColor = System.Drawing.Color.White;
            this.m_txtOTHERMEDICINENum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOTHERMEDICINENum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOTHERMEDICINENum.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOTHERMEDICINENum.Location = new System.Drawing.Point(41, 67);
            this.m_txtOTHERMEDICINENum.m_BlnIgnoreUserInfo = false;
            this.m_txtOTHERMEDICINENum.m_BlnPartControl = false;
            this.m_txtOTHERMEDICINENum.m_BlnReadOnly = false;
            this.m_txtOTHERMEDICINENum.m_BlnUnderLineDST = false;
            this.m_txtOTHERMEDICINENum.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOTHERMEDICINENum.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOTHERMEDICINENum.m_IntCanModifyTime = 6;
            this.m_txtOTHERMEDICINENum.m_IntPartControlLength = 0;
            this.m_txtOTHERMEDICINENum.m_IntPartControlStartIndex = 0;
            this.m_txtOTHERMEDICINENum.m_StrUserID = "";
            this.m_txtOTHERMEDICINENum.m_StrUserName = "";
            this.m_txtOTHERMEDICINENum.MaxLength = 8000;
            this.m_txtOTHERMEDICINENum.Multiline = false;
            this.m_txtOTHERMEDICINENum.Name = "m_txtOTHERMEDICINENum";
            this.m_txtOTHERMEDICINENum.Size = new System.Drawing.Size(66, 22);
            this.m_txtOTHERMEDICINENum.TabIndex = 1000033;
            this.m_txtOTHERMEDICINENum.Text = "";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(1, 48);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(42, 14);
            this.label102.TabIndex = 10000396;
            this.label102.Text = "用法:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(1, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 14);
            this.label27.TabIndex = 10000395;
            this.label27.Text = "药名:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(1, 67);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(42, 14);
            this.label28.TabIndex = 10000394;
            this.label28.Text = "剂量:";
            // 
            // m_cmdAddOTHERMEDICINE
            // 
            this.m_cmdAddOTHERMEDICINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddOTHERMEDICINE.DefaultScheme = true;
            this.m_cmdAddOTHERMEDICINE.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddOTHERMEDICINE.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAddOTHERMEDICINE.Hint = "";
            this.m_cmdAddOTHERMEDICINE.Location = new System.Drawing.Point(7, 91);
            this.m_cmdAddOTHERMEDICINE.Name = "m_cmdAddOTHERMEDICINE";
            this.m_cmdAddOTHERMEDICINE.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddOTHERMEDICINE.Size = new System.Drawing.Size(40, 24);
            this.m_cmdAddOTHERMEDICINE.TabIndex = 1000035;
            this.m_cmdAddOTHERMEDICINE.Text = "添加";
            this.m_cmdAddOTHERMEDICINE.Click += new System.EventHandler(this.m_cmdAddOTHERMEDICINE_Click);
            // 
            // m_lsvOTHERMEDICINE
            // 
            this.m_lsvOTHERMEDICINE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4});
            this.m_lsvOTHERMEDICINE.FullRowSelect = true;
            this.m_lsvOTHERMEDICINE.GridLines = true;
            this.m_lsvOTHERMEDICINE.Location = new System.Drawing.Point(112, 16);
            this.m_lsvOTHERMEDICINE.Name = "m_lsvOTHERMEDICINE";
            this.m_lsvOTHERMEDICINE.Size = new System.Drawing.Size(135, 80);
            this.m_lsvOTHERMEDICINE.TabIndex = 1000034;
            this.m_lsvOTHERMEDICINE.UseCompatibleStateImageBehavior = false;
            this.m_lsvOTHERMEDICINE.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "药名";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "用法";
            this.columnHeader6.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "剂量";
            this.columnHeader4.Width = 40;
            // 
            // m_cmdRemoveOTHERMEDICINE
            // 
            this.m_cmdRemoveOTHERMEDICINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRemoveOTHERMEDICINE.DefaultScheme = true;
            this.m_cmdRemoveOTHERMEDICINE.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRemoveOTHERMEDICINE.ForeColor = System.Drawing.Color.Black;
            this.m_cmdRemoveOTHERMEDICINE.Hint = "";
            this.m_cmdRemoveOTHERMEDICINE.Location = new System.Drawing.Point(66, 91);
            this.m_cmdRemoveOTHERMEDICINE.Name = "m_cmdRemoveOTHERMEDICINE";
            this.m_cmdRemoveOTHERMEDICINE.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRemoveOTHERMEDICINE.Size = new System.Drawing.Size(40, 24);
            this.m_cmdRemoveOTHERMEDICINE.TabIndex = 1000036;
            this.m_cmdRemoveOTHERMEDICINE.Text = "移除";
            this.m_cmdRemoveOTHERMEDICINE.Click += new System.EventHandler(this.m_cmdRemoveOTHERMEDICINE_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_cboRIGHTPUPIL);
            this.groupBox4.Controls.Add(this.m_cboLEFTPUPIL);
            this.groupBox4.Controls.Add(this.m_cboPUPIL);
            this.groupBox4.Controls.Add(this.m_cboCONSCIOUSNESS);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Location = new System.Drawing.Point(491, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 117);
            this.groupBox4.TabIndex = 1000037;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "神智";
            // 
            // m_cboRIGHTPUPIL
            // 
            this.m_cboRIGHTPUPIL.AccessibleDescription = "神智>>右瞳孔";
            this.m_cboRIGHTPUPIL.BackColor = System.Drawing.Color.White;
            this.m_cboRIGHTPUPIL.BorderColor = System.Drawing.Color.Black;
            this.m_cboRIGHTPUPIL.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboRIGHTPUPIL.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRIGHTPUPIL.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRIGHTPUPIL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboRIGHTPUPIL.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRIGHTPUPIL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRIGHTPUPIL.ForeColor = System.Drawing.Color.Black;
            this.m_cboRIGHTPUPIL.ListBackColor = System.Drawing.Color.White;
            this.m_cboRIGHTPUPIL.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRIGHTPUPIL.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRIGHTPUPIL.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRIGHTPUPIL.Location = new System.Drawing.Point(67, 78);
            this.m_cboRIGHTPUPIL.m_BlnEnableItemEventMenu = true;
            this.m_cboRIGHTPUPIL.Name = "m_cboRIGHTPUPIL";
            this.m_cboRIGHTPUPIL.SelectedIndex = -1;
            this.m_cboRIGHTPUPIL.SelectedItem = null;
            this.m_cboRIGHTPUPIL.SelectionStart = 0;
            this.m_cboRIGHTPUPIL.Size = new System.Drawing.Size(111, 23);
            this.m_cboRIGHTPUPIL.TabIndex = 1000041;
            this.m_cboRIGHTPUPIL.TextBackColor = System.Drawing.Color.White;
            this.m_cboRIGHTPUPIL.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboLEFTPUPIL
            // 
            this.m_cboLEFTPUPIL.AccessibleDescription = "神智>>左瞳孔";
            this.m_cboLEFTPUPIL.BackColor = System.Drawing.Color.White;
            this.m_cboLEFTPUPIL.BorderColor = System.Drawing.Color.Black;
            this.m_cboLEFTPUPIL.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLEFTPUPIL.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLEFTPUPIL.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLEFTPUPIL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLEFTPUPIL.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLEFTPUPIL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLEFTPUPIL.ForeColor = System.Drawing.Color.Black;
            this.m_cboLEFTPUPIL.ListBackColor = System.Drawing.Color.White;
            this.m_cboLEFTPUPIL.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLEFTPUPIL.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLEFTPUPIL.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLEFTPUPIL.Location = new System.Drawing.Point(67, 52);
            this.m_cboLEFTPUPIL.m_BlnEnableItemEventMenu = true;
            this.m_cboLEFTPUPIL.Name = "m_cboLEFTPUPIL";
            this.m_cboLEFTPUPIL.SelectedIndex = -1;
            this.m_cboLEFTPUPIL.SelectedItem = null;
            this.m_cboLEFTPUPIL.SelectionStart = 0;
            this.m_cboLEFTPUPIL.Size = new System.Drawing.Size(111, 23);
            this.m_cboLEFTPUPIL.TabIndex = 1000040;
            this.m_cboLEFTPUPIL.TextBackColor = System.Drawing.Color.White;
            this.m_cboLEFTPUPIL.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPUPIL
            // 
            this.m_cboPUPIL.AccessibleDescription = "神智>>瞳孔";
            this.m_cboPUPIL.BackColor = System.Drawing.Color.White;
            this.m_cboPUPIL.BorderColor = System.Drawing.Color.Black;
            this.m_cboPUPIL.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPUPIL.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPUPIL.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPUPIL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPUPIL.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPUPIL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPUPIL.ForeColor = System.Drawing.Color.Black;
            this.m_cboPUPIL.ListBackColor = System.Drawing.Color.White;
            this.m_cboPUPIL.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPUPIL.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPUPIL.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPUPIL.Location = new System.Drawing.Point(125, 20);
            this.m_cboPUPIL.m_BlnEnableItemEventMenu = true;
            this.m_cboPUPIL.Name = "m_cboPUPIL";
            this.m_cboPUPIL.SelectedIndex = -1;
            this.m_cboPUPIL.SelectedItem = null;
            this.m_cboPUPIL.SelectionStart = 0;
            this.m_cboPUPIL.Size = new System.Drawing.Size(53, 23);
            this.m_cboPUPIL.TabIndex = 1000039;
            this.m_cboPUPIL.TextBackColor = System.Drawing.Color.White;
            this.m_cboPUPIL.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboCONSCIOUSNESS
            // 
            this.m_cboCONSCIOUSNESS.AccessibleDescription = "神智>>意识";
            this.m_cboCONSCIOUSNESS.BackColor = System.Drawing.Color.White;
            this.m_cboCONSCIOUSNESS.BorderColor = System.Drawing.Color.Black;
            this.m_cboCONSCIOUSNESS.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCONSCIOUSNESS.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCONSCIOUSNESS.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCONSCIOUSNESS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCONSCIOUSNESS.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCONSCIOUSNESS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCONSCIOUSNESS.ForeColor = System.Drawing.Color.Black;
            this.m_cboCONSCIOUSNESS.ListBackColor = System.Drawing.Color.White;
            this.m_cboCONSCIOUSNESS.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCONSCIOUSNESS.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCONSCIOUSNESS.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCONSCIOUSNESS.Location = new System.Drawing.Point(40, 20);
            this.m_cboCONSCIOUSNESS.m_BlnEnableItemEventMenu = true;
            this.m_cboCONSCIOUSNESS.Name = "m_cboCONSCIOUSNESS";
            this.m_cboCONSCIOUSNESS.SelectedIndex = -1;
            this.m_cboCONSCIOUSNESS.SelectedItem = null;
            this.m_cboCONSCIOUSNESS.SelectionStart = 0;
            this.m_cboCONSCIOUSNESS.Size = new System.Drawing.Size(56, 23);
            this.m_cboCONSCIOUSNESS.TabIndex = 1000038;
            this.m_cboCONSCIOUSNESS.TextBackColor = System.Drawing.Color.White;
            this.m_cboCONSCIOUSNESS.TextForeColor = System.Drawing.Color.Black;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 14);
            this.label29.TabIndex = 0;
            this.label29.Text = "意识";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(93, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 14);
            this.label30.TabIndex = 0;
            this.label30.Text = "瞳孔";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(5, 59);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 14);
            this.label31.TabIndex = 0;
            this.label31.Text = "左瞳孔:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(5, 82);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 14);
            this.label32.TabIndex = 0;
            this.label32.Text = "右瞳孔:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_cboHEARTRATE);
            this.groupBox5.Controls.Add(this.m_cboTWIGTEMPERATURE);
            this.groupBox5.Controls.Add(this.label100);
            this.groupBox5.Controls.Add(this.label101);
            this.groupBox5.Controls.Add(this.m_txtCVP);
            this.groupBox5.Controls.Add(this.m_txtBPA);
            this.groupBox5.Controls.Add(this.m_txtHEARTRHYTHM);
            this.groupBox5.Controls.Add(this.m_txtTEMPERATURE);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.label35);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.label37);
            this.groupBox5.Controls.Add(this.m_txtAVGBP);
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.label39);
            this.groupBox5.Controls.Add(this.m_txtLAP);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.label97);
            this.groupBox5.Controls.Add(this.m_txtBPS);
            this.groupBox5.Location = new System.Drawing.Point(674, 157);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(320, 96);
            this.groupBox5.TabIndex = 1000042;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "循环";
            // 
            // m_cboHEARTRATE
            // 
            this.m_cboHEARTRATE.AccessibleDescription = "循环>>心率";
            this.m_cboHEARTRATE.BackColor = System.Drawing.Color.White;
            this.m_cboHEARTRATE.BorderColor = System.Drawing.Color.Black;
            this.m_cboHEARTRATE.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHEARTRATE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHEARTRATE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHEARTRATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHEARTRATE.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHEARTRATE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHEARTRATE.ForeColor = System.Drawing.Color.Black;
            this.m_cboHEARTRATE.ListBackColor = System.Drawing.Color.White;
            this.m_cboHEARTRATE.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHEARTRATE.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHEARTRATE.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHEARTRATE.Location = new System.Drawing.Point(256, 14);
            this.m_cboHEARTRATE.m_BlnEnableItemEventMenu = true;
            this.m_cboHEARTRATE.Name = "m_cboHEARTRATE";
            this.m_cboHEARTRATE.SelectedIndex = -1;
            this.m_cboHEARTRATE.SelectedItem = null;
            this.m_cboHEARTRATE.SelectionStart = 0;
            this.m_cboHEARTRATE.Size = new System.Drawing.Size(48, 23);
            this.m_cboHEARTRATE.TabIndex = 1000045;
            this.m_cboHEARTRATE.TextBackColor = System.Drawing.Color.White;
            this.m_cboHEARTRATE.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboTWIGTEMPERATURE
            // 
            this.m_cboTWIGTEMPERATURE.AccessibleDescription = "循环>>末梢温";
            this.m_cboTWIGTEMPERATURE.BackColor = System.Drawing.Color.White;
            this.m_cboTWIGTEMPERATURE.BorderColor = System.Drawing.Color.Black;
            this.m_cboTWIGTEMPERATURE.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTWIGTEMPERATURE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboTWIGTEMPERATURE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTWIGTEMPERATURE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTWIGTEMPERATURE.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTWIGTEMPERATURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTWIGTEMPERATURE.ForeColor = System.Drawing.Color.Black;
            this.m_cboTWIGTEMPERATURE.ListBackColor = System.Drawing.Color.White;
            this.m_cboTWIGTEMPERATURE.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTWIGTEMPERATURE.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTWIGTEMPERATURE.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTWIGTEMPERATURE.Location = new System.Drawing.Point(147, 14);
            this.m_cboTWIGTEMPERATURE.m_BlnEnableItemEventMenu = true;
            this.m_cboTWIGTEMPERATURE.Name = "m_cboTWIGTEMPERATURE";
            this.m_cboTWIGTEMPERATURE.SelectedIndex = -1;
            this.m_cboTWIGTEMPERATURE.SelectedItem = null;
            this.m_cboTWIGTEMPERATURE.SelectionStart = 0;
            this.m_cboTWIGTEMPERATURE.Size = new System.Drawing.Size(59, 23);
            this.m_cboTWIGTEMPERATURE.TabIndex = 1000044;
            this.m_cboTWIGTEMPERATURE.TextBackColor = System.Drawing.Color.White;
            this.m_cboTWIGTEMPERATURE.TextForeColor = System.Drawing.Color.Black;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("宋体", 6F);
            this.label100.Location = new System.Drawing.Point(251, 50);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(9, 8);
            this.label100.TabIndex = 10000024;
            this.label100.Text = "2";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(229, 40);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(42, 14);
            this.label101.TabIndex = 10000023;
            this.label101.Text = "Spo :";
            // 
            // m_txtCVP
            // 
            this.m_txtCVP.AccessibleDescription = "循环>>CVP";
            this.m_txtCVP.BackColor = System.Drawing.Color.White;
            this.m_txtCVP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCVP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCVP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCVP.Location = new System.Drawing.Point(152, 72);
            this.m_txtCVP.m_BlnIgnoreUserInfo = false;
            this.m_txtCVP.m_BlnPartControl = false;
            this.m_txtCVP.m_BlnReadOnly = false;
            this.m_txtCVP.m_BlnUnderLineDST = false;
            this.m_txtCVP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCVP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCVP.m_IntCanModifyTime = 6;
            this.m_txtCVP.m_IntPartControlLength = 0;
            this.m_txtCVP.m_IntPartControlStartIndex = 0;
            this.m_txtCVP.m_StrUserID = "";
            this.m_txtCVP.m_StrUserName = "";
            this.m_txtCVP.MaxLength = 8000;
            this.m_txtCVP.Multiline = false;
            this.m_txtCVP.Name = "m_txtCVP";
            this.m_txtCVP.Size = new System.Drawing.Size(48, 22);
            this.m_txtCVP.TabIndex = 1000051;
            this.m_txtCVP.Text = "";
            // 
            // m_txtBPA
            // 
            this.m_txtBPA.AccessibleDescription = "循环>>收缩压";
            this.m_txtBPA.BackColor = System.Drawing.Color.White;
            this.m_txtBPA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBPA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBPA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBPA.Location = new System.Drawing.Point(130, 40);
            this.m_txtBPA.m_BlnIgnoreUserInfo = false;
            this.m_txtBPA.m_BlnPartControl = false;
            this.m_txtBPA.m_BlnReadOnly = false;
            this.m_txtBPA.m_BlnUnderLineDST = false;
            this.m_txtBPA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBPA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBPA.m_IntCanModifyTime = 6;
            this.m_txtBPA.m_IntPartControlLength = 0;
            this.m_txtBPA.m_IntPartControlStartIndex = 0;
            this.m_txtBPA.m_StrUserID = "";
            this.m_txtBPA.m_StrUserName = "";
            this.m_txtBPA.MaxLength = 8000;
            this.m_txtBPA.Multiline = false;
            this.m_txtBPA.Name = "m_txtBPA";
            this.m_txtBPA.Size = new System.Drawing.Size(39, 22);
            this.m_txtBPA.TabIndex = 1000047;
            this.m_txtBPA.Text = "";
            // 
            // m_txtHEARTRHYTHM
            // 
            this.m_txtHEARTRHYTHM.AccessibleDescription = "循环>>心律";
            this.m_txtHEARTRHYTHM.BackColor = System.Drawing.Color.White;
            this.m_txtHEARTRHYTHM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHEARTRHYTHM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtHEARTRHYTHM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHEARTRHYTHM.Location = new System.Drawing.Point(48, 40);
            this.m_txtHEARTRHYTHM.m_BlnIgnoreUserInfo = false;
            this.m_txtHEARTRHYTHM.m_BlnPartControl = false;
            this.m_txtHEARTRHYTHM.m_BlnReadOnly = false;
            this.m_txtHEARTRHYTHM.m_BlnUnderLineDST = false;
            this.m_txtHEARTRHYTHM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHEARTRHYTHM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHEARTRHYTHM.m_IntCanModifyTime = 6;
            this.m_txtHEARTRHYTHM.m_IntPartControlLength = 0;
            this.m_txtHEARTRHYTHM.m_IntPartControlStartIndex = 0;
            this.m_txtHEARTRHYTHM.m_StrUserID = "";
            this.m_txtHEARTRHYTHM.m_StrUserName = "";
            this.m_txtHEARTRHYTHM.MaxLength = 8000;
            this.m_txtHEARTRHYTHM.Multiline = false;
            this.m_txtHEARTRHYTHM.Name = "m_txtHEARTRHYTHM";
            this.m_txtHEARTRHYTHM.Size = new System.Drawing.Size(48, 22);
            this.m_txtHEARTRHYTHM.TabIndex = 1000046;
            this.m_txtHEARTRHYTHM.Text = "";
            // 
            // m_txtTEMPERATURE
            // 
            this.m_txtTEMPERATURE.AccessibleDescription = "循环>>体温";
            this.m_txtTEMPERATURE.BackColor = System.Drawing.Color.White;
            this.m_txtTEMPERATURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTEMPERATURE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTEMPERATURE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTEMPERATURE.Location = new System.Drawing.Point(48, 14);
            this.m_txtTEMPERATURE.m_BlnIgnoreUserInfo = false;
            this.m_txtTEMPERATURE.m_BlnPartControl = false;
            this.m_txtTEMPERATURE.m_BlnReadOnly = false;
            this.m_txtTEMPERATURE.m_BlnUnderLineDST = false;
            this.m_txtTEMPERATURE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTEMPERATURE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTEMPERATURE.m_IntCanModifyTime = 6;
            this.m_txtTEMPERATURE.m_IntPartControlLength = 0;
            this.m_txtTEMPERATURE.m_IntPartControlStartIndex = 0;
            this.m_txtTEMPERATURE.m_StrUserID = "";
            this.m_txtTEMPERATURE.m_StrUserName = "";
            this.m_txtTEMPERATURE.MaxLength = 8000;
            this.m_txtTEMPERATURE.Multiline = false;
            this.m_txtTEMPERATURE.Name = "m_txtTEMPERATURE";
            this.m_txtTEMPERATURE.Size = new System.Drawing.Size(48, 22);
            this.m_txtTEMPERATURE.TabIndex = 1000043;
            this.m_txtTEMPERATURE.Text = "";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(8, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(42, 14);
            this.label33.TabIndex = 0;
            this.label33.Text = "体温:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(96, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(56, 14);
            this.label34.TabIndex = 0;
            this.label34.Text = "末梢温:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(208, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(42, 14);
            this.label35.TabIndex = 0;
            this.label35.Text = "心率:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(3, 44);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(42, 14);
            this.label36.TabIndex = 0;
            this.label36.Text = "心律:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(93, 43);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(42, 14);
            this.label37.TabIndex = 0;
            this.label37.Text = "血压:";
            // 
            // m_txtAVGBP
            // 
            this.m_txtAVGBP.AccessibleDescription = "循环>>平均压";
            this.m_txtAVGBP.BackColor = System.Drawing.Color.White;
            this.m_txtAVGBP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAVGBP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAVGBP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAVGBP.Location = new System.Drawing.Point(64, 72);
            this.m_txtAVGBP.m_BlnIgnoreUserInfo = false;
            this.m_txtAVGBP.m_BlnPartControl = false;
            this.m_txtAVGBP.m_BlnReadOnly = false;
            this.m_txtAVGBP.m_BlnUnderLineDST = false;
            this.m_txtAVGBP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAVGBP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAVGBP.m_IntCanModifyTime = 6;
            this.m_txtAVGBP.m_IntPartControlLength = 0;
            this.m_txtAVGBP.m_IntPartControlStartIndex = 0;
            this.m_txtAVGBP.m_StrUserID = "";
            this.m_txtAVGBP.m_StrUserName = "";
            this.m_txtAVGBP.MaxLength = 8000;
            this.m_txtAVGBP.Multiline = false;
            this.m_txtAVGBP.Name = "m_txtAVGBP";
            this.m_txtAVGBP.Size = new System.Drawing.Size(48, 22);
            this.m_txtAVGBP.TabIndex = 1000050;
            this.m_txtAVGBP.Text = "";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(8, 72);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(56, 14);
            this.label38.TabIndex = 0;
            this.label38.Text = "平均压:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(119, 72);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(35, 14);
            this.label39.TabIndex = 0;
            this.label39.Text = "CVP:";
            // 
            // m_txtLAP
            // 
            this.m_txtLAP.AccessibleDescription = "循环>>LAP";
            this.m_txtLAP.BackColor = System.Drawing.Color.White;
            this.m_txtLAP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLAP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtLAP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLAP.Location = new System.Drawing.Point(248, 72);
            this.m_txtLAP.m_BlnIgnoreUserInfo = false;
            this.m_txtLAP.m_BlnPartControl = false;
            this.m_txtLAP.m_BlnReadOnly = false;
            this.m_txtLAP.m_BlnUnderLineDST = false;
            this.m_txtLAP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLAP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLAP.m_IntCanModifyTime = 6;
            this.m_txtLAP.m_IntPartControlLength = 0;
            this.m_txtLAP.m_IntPartControlStartIndex = 0;
            this.m_txtLAP.m_StrUserID = "";
            this.m_txtLAP.m_StrUserName = "";
            this.m_txtLAP.MaxLength = 8000;
            this.m_txtLAP.Multiline = false;
            this.m_txtLAP.Name = "m_txtLAP";
            this.m_txtLAP.Size = new System.Drawing.Size(48, 22);
            this.m_txtLAP.TabIndex = 1000052;
            this.m_txtLAP.Text = "";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(120, 72);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(35, 14);
            this.label40.TabIndex = 0;
            this.label40.Text = "CVP:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(216, 72);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(35, 14);
            this.label41.TabIndex = 0;
            this.label41.Text = "LAP:";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Font = new System.Drawing.Font("宋体", 15F);
            this.label97.Location = new System.Drawing.Point(169, 39);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(19, 20);
            this.label97.TabIndex = 0;
            this.label97.Text = "/";
            // 
            // m_txtBPS
            // 
            this.m_txtBPS.AccessibleDescription = "循环>>舒张压";
            this.m_txtBPS.BackColor = System.Drawing.Color.White;
            this.m_txtBPS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBPS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBPS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBPS.Location = new System.Drawing.Point(187, 40);
            this.m_txtBPS.m_BlnIgnoreUserInfo = false;
            this.m_txtBPS.m_BlnPartControl = false;
            this.m_txtBPS.m_BlnReadOnly = false;
            this.m_txtBPS.m_BlnUnderLineDST = false;
            this.m_txtBPS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBPS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBPS.m_IntCanModifyTime = 6;
            this.m_txtBPS.m_IntPartControlLength = 0;
            this.m_txtBPS.m_IntPartControlStartIndex = 0;
            this.m_txtBPS.m_StrUserID = "";
            this.m_txtBPS.m_StrUserName = "";
            this.m_txtBPS.MaxLength = 8000;
            this.m_txtBPS.Multiline = false;
            this.m_txtBPS.Name = "m_txtBPS";
            this.m_txtBPS.Size = new System.Drawing.Size(43, 22);
            this.m_txtBPS.TabIndex = 1000048;
            this.m_txtBPS.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.m_cboLEFTBREATHVOICE);
            this.groupBox6.Controls.Add(this.m_cboRIGHTBREATHVOICE);
            this.groupBox6.Controls.Add(this.m_cboPHLEGMCOLOR);
            this.groupBox6.Controls.Add(this.m_cboPHYSICALTHERAPY);
            this.groupBox6.Controls.Add(this.m_cboGESTICULATION);
            this.groupBox6.Controls.Add(this.m_cboPHLEGMQUANTITY);
            this.groupBox6.Controls.Add(this.m_cboINSPIRATION);
            this.groupBox6.Controls.Add(this.m_cboASSISTANT);
            this.groupBox6.Controls.Add(this.m_cboINSERTDEPTH);
            this.groupBox6.Controls.Add(this.m_cboBREATHMACHINE);
            this.groupBox6.Controls.Add(this.label50);
            this.groupBox6.Controls.Add(this.label46);
            this.groupBox6.Controls.Add(this.label42);
            this.groupBox6.Controls.Add(this.label43);
            this.groupBox6.Controls.Add(this.label44);
            this.groupBox6.Controls.Add(this.m_txtFIO2);
            this.groupBox6.Controls.Add(this.label45);
            this.groupBox6.Controls.Add(this.m_txtIE);
            this.groupBox6.Controls.Add(this.label47);
            this.groupBox6.Controls.Add(this.label48);
            this.groupBox6.Controls.Add(this.label49);
            this.groupBox6.Controls.Add(this.m_txtPEEP);
            this.groupBox6.Controls.Add(this.m_txtTV);
            this.groupBox6.Controls.Add(this.label51);
            this.groupBox6.Controls.Add(this.m_txtVF);
            this.groupBox6.Controls.Add(this.label52);
            this.groupBox6.Controls.Add(this.m_txtBREATHTIMES);
            this.groupBox6.Controls.Add(this.label53);
            this.groupBox6.Controls.Add(this.label54);
            this.groupBox6.Controls.Add(this.label55);
            this.groupBox6.Controls.Add(this.label56);
            this.groupBox6.Controls.Add(this.label57);
            this.groupBox6.Controls.Add(this.label58);
            this.groupBox6.Controls.Add(this.label59);
            this.groupBox6.Location = new System.Drawing.Point(8, 259);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(656, 96);
            this.groupBox6.TabIndex = 1000053;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "呼吸";
            // 
            // m_cboLEFTBREATHVOICE
            // 
            this.m_cboLEFTBREATHVOICE.AccessibleDescription = "呼吸>>呼吸音>>左";
            this.m_cboLEFTBREATHVOICE.BackColor = System.Drawing.Color.White;
            this.m_cboLEFTBREATHVOICE.BorderColor = System.Drawing.Color.Black;
            this.m_cboLEFTBREATHVOICE.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLEFTBREATHVOICE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLEFTBREATHVOICE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLEFTBREATHVOICE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLEFTBREATHVOICE.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLEFTBREATHVOICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLEFTBREATHVOICE.ForeColor = System.Drawing.Color.Black;
            this.m_cboLEFTBREATHVOICE.ListBackColor = System.Drawing.Color.White;
            this.m_cboLEFTBREATHVOICE.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLEFTBREATHVOICE.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLEFTBREATHVOICE.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLEFTBREATHVOICE.Location = new System.Drawing.Point(79, 65);
            this.m_cboLEFTBREATHVOICE.m_BlnEnableItemEventMenu = true;
            this.m_cboLEFTBREATHVOICE.Name = "m_cboLEFTBREATHVOICE";
            this.m_cboLEFTBREATHVOICE.SelectedIndex = -1;
            this.m_cboLEFTBREATHVOICE.SelectedItem = null;
            this.m_cboLEFTBREATHVOICE.SelectionStart = 0;
            this.m_cboLEFTBREATHVOICE.Size = new System.Drawing.Size(58, 23);
            this.m_cboLEFTBREATHVOICE.TabIndex = 1000064;
            this.m_cboLEFTBREATHVOICE.TextBackColor = System.Drawing.Color.White;
            this.m_cboLEFTBREATHVOICE.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboRIGHTBREATHVOICE
            // 
            this.m_cboRIGHTBREATHVOICE.AccessibleDescription = "呼吸>>呼吸音>>右";
            this.m_cboRIGHTBREATHVOICE.BackColor = System.Drawing.Color.White;
            this.m_cboRIGHTBREATHVOICE.BorderColor = System.Drawing.Color.Black;
            this.m_cboRIGHTBREATHVOICE.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboRIGHTBREATHVOICE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRIGHTBREATHVOICE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRIGHTBREATHVOICE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboRIGHTBREATHVOICE.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRIGHTBREATHVOICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRIGHTBREATHVOICE.ForeColor = System.Drawing.Color.Black;
            this.m_cboRIGHTBREATHVOICE.ListBackColor = System.Drawing.Color.White;
            this.m_cboRIGHTBREATHVOICE.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRIGHTBREATHVOICE.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRIGHTBREATHVOICE.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRIGHTBREATHVOICE.Location = new System.Drawing.Point(165, 65);
            this.m_cboRIGHTBREATHVOICE.m_BlnEnableItemEventMenu = true;
            this.m_cboRIGHTBREATHVOICE.Name = "m_cboRIGHTBREATHVOICE";
            this.m_cboRIGHTBREATHVOICE.SelectedIndex = -1;
            this.m_cboRIGHTBREATHVOICE.SelectedItem = null;
            this.m_cboRIGHTBREATHVOICE.SelectionStart = 0;
            this.m_cboRIGHTBREATHVOICE.Size = new System.Drawing.Size(66, 23);
            this.m_cboRIGHTBREATHVOICE.TabIndex = 1000065;
            this.m_cboRIGHTBREATHVOICE.TextBackColor = System.Drawing.Color.White;
            this.m_cboRIGHTBREATHVOICE.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPHLEGMCOLOR
            // 
            this.m_cboPHLEGMCOLOR.AccessibleDescription = "呼吸>>痰色";
            this.m_cboPHLEGMCOLOR.BackColor = System.Drawing.Color.White;
            this.m_cboPHLEGMCOLOR.BorderColor = System.Drawing.Color.Black;
            this.m_cboPHLEGMCOLOR.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPHLEGMCOLOR.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPHLEGMCOLOR.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPHLEGMCOLOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPHLEGMCOLOR.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPHLEGMCOLOR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPHLEGMCOLOR.ForeColor = System.Drawing.Color.Black;
            this.m_cboPHLEGMCOLOR.ListBackColor = System.Drawing.Color.White;
            this.m_cboPHLEGMCOLOR.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPHLEGMCOLOR.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPHLEGMCOLOR.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPHLEGMCOLOR.Location = new System.Drawing.Point(272, 65);
            this.m_cboPHLEGMCOLOR.m_BlnEnableItemEventMenu = true;
            this.m_cboPHLEGMCOLOR.Name = "m_cboPHLEGMCOLOR";
            this.m_cboPHLEGMCOLOR.SelectedIndex = -1;
            this.m_cboPHLEGMCOLOR.SelectedItem = null;
            this.m_cboPHLEGMCOLOR.SelectionStart = 0;
            this.m_cboPHLEGMCOLOR.Size = new System.Drawing.Size(62, 23);
            this.m_cboPHLEGMCOLOR.TabIndex = 1000066;
            this.m_cboPHLEGMCOLOR.TextBackColor = System.Drawing.Color.White;
            this.m_cboPHLEGMCOLOR.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPHYSICALTHERAPY
            // 
            this.m_cboPHYSICALTHERAPY.AccessibleDescription = "呼吸>>理疗";
            this.m_cboPHYSICALTHERAPY.BackColor = System.Drawing.Color.White;
            this.m_cboPHYSICALTHERAPY.BorderColor = System.Drawing.Color.Black;
            this.m_cboPHYSICALTHERAPY.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPHYSICALTHERAPY.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPHYSICALTHERAPY.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPHYSICALTHERAPY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPHYSICALTHERAPY.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPHYSICALTHERAPY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPHYSICALTHERAPY.ForeColor = System.Drawing.Color.Black;
            this.m_cboPHYSICALTHERAPY.ListBackColor = System.Drawing.Color.White;
            this.m_cboPHYSICALTHERAPY.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPHYSICALTHERAPY.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPHYSICALTHERAPY.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPHYSICALTHERAPY.Location = new System.Drawing.Point(591, 65);
            this.m_cboPHYSICALTHERAPY.m_BlnEnableItemEventMenu = true;
            this.m_cboPHYSICALTHERAPY.Name = "m_cboPHYSICALTHERAPY";
            this.m_cboPHYSICALTHERAPY.SelectedIndex = -1;
            this.m_cboPHYSICALTHERAPY.SelectedItem = null;
            this.m_cboPHYSICALTHERAPY.SelectionStart = 0;
            this.m_cboPHYSICALTHERAPY.Size = new System.Drawing.Size(65, 23);
            this.m_cboPHYSICALTHERAPY.TabIndex = 1000069;
            this.m_cboPHYSICALTHERAPY.TextBackColor = System.Drawing.Color.White;
            this.m_cboPHYSICALTHERAPY.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboGESTICULATION
            // 
            this.m_cboGESTICULATION.AccessibleDescription = "呼吸>>体位";
            this.m_cboGESTICULATION.BackColor = System.Drawing.Color.White;
            this.m_cboGESTICULATION.BorderColor = System.Drawing.Color.Black;
            this.m_cboGESTICULATION.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboGESTICULATION.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboGESTICULATION.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboGESTICULATION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboGESTICULATION.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGESTICULATION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGESTICULATION.ForeColor = System.Drawing.Color.Black;
            this.m_cboGESTICULATION.ListBackColor = System.Drawing.Color.White;
            this.m_cboGESTICULATION.ListForeColor = System.Drawing.Color.Black;
            this.m_cboGESTICULATION.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboGESTICULATION.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboGESTICULATION.Location = new System.Drawing.Point(480, 65);
            this.m_cboGESTICULATION.m_BlnEnableItemEventMenu = true;
            this.m_cboGESTICULATION.Name = "m_cboGESTICULATION";
            this.m_cboGESTICULATION.SelectedIndex = -1;
            this.m_cboGESTICULATION.SelectedItem = null;
            this.m_cboGESTICULATION.SelectionStart = 0;
            this.m_cboGESTICULATION.Size = new System.Drawing.Size(66, 23);
            this.m_cboGESTICULATION.TabIndex = 1000068;
            this.m_cboGESTICULATION.TextBackColor = System.Drawing.Color.White;
            this.m_cboGESTICULATION.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPHLEGMQUANTITY
            // 
            this.m_cboPHLEGMQUANTITY.AccessibleDescription = "呼吸>>痰量";
            this.m_cboPHLEGMQUANTITY.BackColor = System.Drawing.Color.White;
            this.m_cboPHLEGMQUANTITY.BorderColor = System.Drawing.Color.Black;
            this.m_cboPHLEGMQUANTITY.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPHLEGMQUANTITY.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPHLEGMQUANTITY.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPHLEGMQUANTITY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPHLEGMQUANTITY.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPHLEGMQUANTITY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPHLEGMQUANTITY.ForeColor = System.Drawing.Color.Black;
            this.m_cboPHLEGMQUANTITY.ListBackColor = System.Drawing.Color.White;
            this.m_cboPHLEGMQUANTITY.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPHLEGMQUANTITY.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPHLEGMQUANTITY.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPHLEGMQUANTITY.Location = new System.Drawing.Point(376, 65);
            this.m_cboPHLEGMQUANTITY.m_BlnEnableItemEventMenu = true;
            this.m_cboPHLEGMQUANTITY.Name = "m_cboPHLEGMQUANTITY";
            this.m_cboPHLEGMQUANTITY.SelectedIndex = -1;
            this.m_cboPHLEGMQUANTITY.SelectedItem = null;
            this.m_cboPHLEGMQUANTITY.SelectionStart = 0;
            this.m_cboPHLEGMQUANTITY.Size = new System.Drawing.Size(66, 23);
            this.m_cboPHLEGMQUANTITY.TabIndex = 1000067;
            this.m_cboPHLEGMQUANTITY.TextBackColor = System.Drawing.Color.White;
            this.m_cboPHLEGMQUANTITY.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboINSPIRATION
            // 
            this.m_cboINSPIRATION.AccessibleDescription = "呼吸>>吸气压";
            this.m_cboINSPIRATION.BackColor = System.Drawing.Color.White;
            this.m_cboINSPIRATION.BorderColor = System.Drawing.Color.Black;
            this.m_cboINSPIRATION.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboINSPIRATION.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboINSPIRATION.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboINSPIRATION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboINSPIRATION.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboINSPIRATION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboINSPIRATION.ForeColor = System.Drawing.Color.Black;
            this.m_cboINSPIRATION.ListBackColor = System.Drawing.Color.White;
            this.m_cboINSPIRATION.ListForeColor = System.Drawing.Color.Black;
            this.m_cboINSPIRATION.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboINSPIRATION.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboINSPIRATION.Location = new System.Drawing.Point(60, 38);
            this.m_cboINSPIRATION.m_BlnEnableItemEventMenu = true;
            this.m_cboINSPIRATION.Name = "m_cboINSPIRATION";
            this.m_cboINSPIRATION.SelectedIndex = -1;
            this.m_cboINSPIRATION.SelectedItem = null;
            this.m_cboINSPIRATION.SelectionStart = 0;
            this.m_cboINSPIRATION.Size = new System.Drawing.Size(70, 23);
            this.m_cboINSPIRATION.TabIndex = 1000059;
            this.m_cboINSPIRATION.TextBackColor = System.Drawing.Color.White;
            this.m_cboINSPIRATION.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboASSISTANT
            // 
            this.m_cboASSISTANT.AccessibleDescription = "呼吸>>辅助方式";
            this.m_cboASSISTANT.BackColor = System.Drawing.Color.White;
            this.m_cboASSISTANT.BorderColor = System.Drawing.Color.Black;
            this.m_cboASSISTANT.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboASSISTANT.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboASSISTANT.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboASSISTANT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboASSISTANT.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboASSISTANT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboASSISTANT.ForeColor = System.Drawing.Color.Black;
            this.m_cboASSISTANT.ListBackColor = System.Drawing.Color.White;
            this.m_cboASSISTANT.ListForeColor = System.Drawing.Color.Black;
            this.m_cboASSISTANT.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboASSISTANT.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboASSISTANT.Location = new System.Drawing.Point(362, 14);
            this.m_cboASSISTANT.m_BlnEnableItemEventMenu = true;
            this.m_cboASSISTANT.Name = "m_cboASSISTANT";
            this.m_cboASSISTANT.SelectedIndex = -1;
            this.m_cboASSISTANT.SelectedItem = null;
            this.m_cboASSISTANT.SelectionStart = 0;
            this.m_cboASSISTANT.Size = new System.Drawing.Size(70, 23);
            this.m_cboASSISTANT.TabIndex = 1000056;
            this.m_cboASSISTANT.TextBackColor = System.Drawing.Color.White;
            this.m_cboASSISTANT.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboINSERTDEPTH
            // 
            this.m_cboINSERTDEPTH.AccessibleDescription = "呼吸>>插管深度";
            this.m_cboINSERTDEPTH.BackColor = System.Drawing.Color.White;
            this.m_cboINSERTDEPTH.BorderColor = System.Drawing.Color.Black;
            this.m_cboINSERTDEPTH.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboINSERTDEPTH.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboINSERTDEPTH.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboINSERTDEPTH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboINSERTDEPTH.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboINSERTDEPTH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboINSERTDEPTH.ForeColor = System.Drawing.Color.Black;
            this.m_cboINSERTDEPTH.ListBackColor = System.Drawing.Color.White;
            this.m_cboINSERTDEPTH.ListForeColor = System.Drawing.Color.Black;
            this.m_cboINSERTDEPTH.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboINSERTDEPTH.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboINSERTDEPTH.Location = new System.Drawing.Point(228, 14);
            this.m_cboINSERTDEPTH.m_BlnEnableItemEventMenu = true;
            this.m_cboINSERTDEPTH.Name = "m_cboINSERTDEPTH";
            this.m_cboINSERTDEPTH.SelectedIndex = -1;
            this.m_cboINSERTDEPTH.SelectedItem = null;
            this.m_cboINSERTDEPTH.SelectionStart = 0;
            this.m_cboINSERTDEPTH.Size = new System.Drawing.Size(70, 23);
            this.m_cboINSERTDEPTH.TabIndex = 1000055;
            this.m_cboINSERTDEPTH.TextBackColor = System.Drawing.Color.White;
            this.m_cboINSERTDEPTH.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboBREATHMACHINE
            // 
            this.m_cboBREATHMACHINE.AccessibleDescription = "呼吸>>呼吸机型号";
            this.m_cboBREATHMACHINE.BackColor = System.Drawing.Color.White;
            this.m_cboBREATHMACHINE.BorderColor = System.Drawing.Color.Black;
            this.m_cboBREATHMACHINE.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBREATHMACHINE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBREATHMACHINE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBREATHMACHINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBREATHMACHINE.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBREATHMACHINE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBREATHMACHINE.ForeColor = System.Drawing.Color.Black;
            this.m_cboBREATHMACHINE.ListBackColor = System.Drawing.Color.White;
            this.m_cboBREATHMACHINE.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBREATHMACHINE.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBREATHMACHINE.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBREATHMACHINE.Location = new System.Drawing.Point(82, 12);
            this.m_cboBREATHMACHINE.m_BlnEnableItemEventMenu = true;
            this.m_cboBREATHMACHINE.Name = "m_cboBREATHMACHINE";
            this.m_cboBREATHMACHINE.SelectedIndex = -1;
            this.m_cboBREATHMACHINE.SelectedItem = null;
            this.m_cboBREATHMACHINE.SelectionStart = 0;
            this.m_cboBREATHMACHINE.Size = new System.Drawing.Size(80, 23);
            this.m_cboBREATHMACHINE.TabIndex = 1000054;
            this.m_cboBREATHMACHINE.TextBackColor = System.Drawing.Color.White;
            this.m_cboBREATHMACHINE.TextForeColor = System.Drawing.Color.Black;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 6F);
            this.label50.Location = new System.Drawing.Point(188, 48);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(9, 8);
            this.label50.TabIndex = 10000022;
            this.label50.Text = "2";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 6F);
            this.label46.Location = new System.Drawing.Point(456, 24);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(9, 8);
            this.label46.TabIndex = 10000022;
            this.label46.Text = "2";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(4, 16);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(84, 14);
            this.label42.TabIndex = 10000022;
            this.label42.Text = "呼吸机型号:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(162, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(70, 14);
            this.label43.TabIndex = 10000022;
            this.label43.Text = "插管深度:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(298, 16);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(70, 14);
            this.label44.TabIndex = 10000022;
            this.label44.Text = "辅助方式:";
            // 
            // m_txtFIO2
            // 
            this.m_txtFIO2.AccessibleDescription = "呼吸>>FiO2";
            this.m_txtFIO2.BackColor = System.Drawing.Color.White;
            this.m_txtFIO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFIO2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtFIO2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFIO2.Location = new System.Drawing.Point(472, 14);
            this.m_txtFIO2.m_BlnIgnoreUserInfo = false;
            this.m_txtFIO2.m_BlnPartControl = false;
            this.m_txtFIO2.m_BlnReadOnly = false;
            this.m_txtFIO2.m_BlnUnderLineDST = false;
            this.m_txtFIO2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFIO2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFIO2.m_IntCanModifyTime = 6;
            this.m_txtFIO2.m_IntPartControlLength = 0;
            this.m_txtFIO2.m_IntPartControlStartIndex = 0;
            this.m_txtFIO2.m_StrUserID = "";
            this.m_txtFIO2.m_StrUserName = "";
            this.m_txtFIO2.MaxLength = 8000;
            this.m_txtFIO2.Multiline = false;
            this.m_txtFIO2.Name = "m_txtFIO2";
            this.m_txtFIO2.Size = new System.Drawing.Size(56, 22);
            this.m_txtFIO2.TabIndex = 1000057;
            this.m_txtFIO2.Text = "";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(432, 16);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(42, 14);
            this.label45.TabIndex = 10000022;
            this.label45.Text = "FiO :";
            // 
            // m_txtIE
            // 
            this.m_txtIE.AccessibleDescription = "呼吸>>I:E";
            this.m_txtIE.BackColor = System.Drawing.Color.White;
            this.m_txtIE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtIE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIE.Location = new System.Drawing.Point(592, 14);
            this.m_txtIE.m_BlnIgnoreUserInfo = false;
            this.m_txtIE.m_BlnPartControl = false;
            this.m_txtIE.m_BlnReadOnly = false;
            this.m_txtIE.m_BlnUnderLineDST = false;
            this.m_txtIE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIE.m_IntCanModifyTime = 6;
            this.m_txtIE.m_IntPartControlLength = 0;
            this.m_txtIE.m_IntPartControlStartIndex = 0;
            this.m_txtIE.m_StrUserID = "";
            this.m_txtIE.m_StrUserName = "";
            this.m_txtIE.MaxLength = 8000;
            this.m_txtIE.Multiline = false;
            this.m_txtIE.Name = "m_txtIE";
            this.m_txtIE.Size = new System.Drawing.Size(56, 22);
            this.m_txtIE.TabIndex = 1000058;
            this.m_txtIE.Text = "";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(560, 16);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(35, 14);
            this.label47.TabIndex = 10000022;
            this.label47.Text = "I:E:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(4, 40);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(56, 14);
            this.label48.TabIndex = 10000022;
            this.label48.Text = "吸气压:";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(130, 40);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(91, 14);
            this.label49.TabIndex = 10000022;
            this.label49.Text = "PEEP(CmH O):";
            // 
            // m_txtPEEP
            // 
            this.m_txtPEEP.AccessibleDescription = "呼吸>>PEEP(CmH O)";
            this.m_txtPEEP.BackColor = System.Drawing.Color.White;
            this.m_txtPEEP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPEEP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPEEP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPEEP.Location = new System.Drawing.Point(224, 40);
            this.m_txtPEEP.m_BlnIgnoreUserInfo = false;
            this.m_txtPEEP.m_BlnPartControl = false;
            this.m_txtPEEP.m_BlnReadOnly = false;
            this.m_txtPEEP.m_BlnUnderLineDST = false;
            this.m_txtPEEP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPEEP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPEEP.m_IntCanModifyTime = 6;
            this.m_txtPEEP.m_IntPartControlLength = 0;
            this.m_txtPEEP.m_IntPartControlStartIndex = 0;
            this.m_txtPEEP.m_StrUserID = "";
            this.m_txtPEEP.m_StrUserName = "";
            this.m_txtPEEP.MaxLength = 8000;
            this.m_txtPEEP.Multiline = false;
            this.m_txtPEEP.Name = "m_txtPEEP";
            this.m_txtPEEP.Size = new System.Drawing.Size(56, 22);
            this.m_txtPEEP.TabIndex = 1000060;
            this.m_txtPEEP.Text = "";
            // 
            // m_txtTV
            // 
            this.m_txtTV.AccessibleDescription = "呼吸>>TV(ml)";
            this.m_txtTV.BackColor = System.Drawing.Color.White;
            this.m_txtTV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTV.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTV.Location = new System.Drawing.Point(368, 40);
            this.m_txtTV.m_BlnIgnoreUserInfo = false;
            this.m_txtTV.m_BlnPartControl = false;
            this.m_txtTV.m_BlnReadOnly = false;
            this.m_txtTV.m_BlnUnderLineDST = false;
            this.m_txtTV.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTV.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTV.m_IntCanModifyTime = 6;
            this.m_txtTV.m_IntPartControlLength = 0;
            this.m_txtTV.m_IntPartControlStartIndex = 0;
            this.m_txtTV.m_StrUserID = "";
            this.m_txtTV.m_StrUserName = "";
            this.m_txtTV.MaxLength = 8000;
            this.m_txtTV.Multiline = false;
            this.m_txtTV.Name = "m_txtTV";
            this.m_txtTV.Size = new System.Drawing.Size(56, 22);
            this.m_txtTV.TabIndex = 1000061;
            this.m_txtTV.Text = "";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(312, 40);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(56, 14);
            this.label51.TabIndex = 10000022;
            this.label51.Text = "TV(ml):";
            // 
            // m_txtVF
            // 
            this.m_txtVF.AccessibleDescription = "呼吸>>VF";
            this.m_txtVF.BackColor = System.Drawing.Color.White;
            this.m_txtVF.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtVF.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtVF.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtVF.Location = new System.Drawing.Point(472, 40);
            this.m_txtVF.m_BlnIgnoreUserInfo = false;
            this.m_txtVF.m_BlnPartControl = false;
            this.m_txtVF.m_BlnReadOnly = false;
            this.m_txtVF.m_BlnUnderLineDST = false;
            this.m_txtVF.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtVF.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtVF.m_IntCanModifyTime = 6;
            this.m_txtVF.m_IntPartControlLength = 0;
            this.m_txtVF.m_IntPartControlStartIndex = 0;
            this.m_txtVF.m_StrUserID = "";
            this.m_txtVF.m_StrUserName = "";
            this.m_txtVF.MaxLength = 8000;
            this.m_txtVF.Multiline = false;
            this.m_txtVF.Name = "m_txtVF";
            this.m_txtVF.Size = new System.Drawing.Size(56, 22);
            this.m_txtVF.TabIndex = 1000062;
            this.m_txtVF.Text = "";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(448, 40);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(28, 14);
            this.label52.TabIndex = 10000022;
            this.label52.Text = "VF:";
            // 
            // m_txtBREATHTIMES
            // 
            this.m_txtBREATHTIMES.AccessibleDescription = "呼吸>>呼吸次数";
            this.m_txtBREATHTIMES.BackColor = System.Drawing.Color.White;
            this.m_txtBREATHTIMES.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBREATHTIMES.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBREATHTIMES.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBREATHTIMES.Location = new System.Drawing.Point(592, 40);
            this.m_txtBREATHTIMES.m_BlnIgnoreUserInfo = false;
            this.m_txtBREATHTIMES.m_BlnPartControl = false;
            this.m_txtBREATHTIMES.m_BlnReadOnly = false;
            this.m_txtBREATHTIMES.m_BlnUnderLineDST = false;
            this.m_txtBREATHTIMES.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBREATHTIMES.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBREATHTIMES.m_IntCanModifyTime = 6;
            this.m_txtBREATHTIMES.m_IntPartControlLength = 0;
            this.m_txtBREATHTIMES.m_IntPartControlStartIndex = 0;
            this.m_txtBREATHTIMES.m_StrUserID = "";
            this.m_txtBREATHTIMES.m_StrUserName = "";
            this.m_txtBREATHTIMES.MaxLength = 8000;
            this.m_txtBREATHTIMES.Multiline = false;
            this.m_txtBREATHTIMES.Name = "m_txtBREATHTIMES";
            this.m_txtBREATHTIMES.Size = new System.Drawing.Size(56, 22);
            this.m_txtBREATHTIMES.TabIndex = 1000063;
            this.m_txtBREATHTIMES.Text = "";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(528, 40);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(70, 14);
            this.label53.TabIndex = 10000022;
            this.label53.Text = "呼吸次数:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(4, 66);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(77, 14);
            this.label54.TabIndex = 10000022;
            this.label54.Text = "呼吸音 左:";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(136, 66);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(28, 14);
            this.label55.TabIndex = 10000022;
            this.label55.Text = "右:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(232, 66);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(42, 14);
            this.label56.TabIndex = 10000022;
            this.label56.Text = "痰色:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(334, 66);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(42, 14);
            this.label57.TabIndex = 10000022;
            this.label57.Text = "痰量:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(442, 66);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(42, 14);
            this.label58.TabIndex = 10000022;
            this.label58.Text = "体位:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(552, 66);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(42, 14);
            this.label59.TabIndex = 10000022;
            this.label59.Text = "理疗:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.m_txtREMARK);
            this.groupBox7.Location = new System.Drawing.Point(672, 259);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(304, 96);
            this.groupBox7.TabIndex = 1000070;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "备注";
            // 
            // m_txtREMARK
            // 
            this.m_txtREMARK.AccessibleDescription = "备注";
            this.m_txtREMARK.BackColor = System.Drawing.Color.White;
            this.m_txtREMARK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtREMARK.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtREMARK.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtREMARK.Location = new System.Drawing.Point(8, 16);
            this.m_txtREMARK.m_BlnIgnoreUserInfo = false;
            this.m_txtREMARK.m_BlnPartControl = false;
            this.m_txtREMARK.m_BlnReadOnly = false;
            this.m_txtREMARK.m_BlnUnderLineDST = false;
            this.m_txtREMARK.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtREMARK.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtREMARK.m_IntCanModifyTime = 6;
            this.m_txtREMARK.m_IntPartControlLength = 0;
            this.m_txtREMARK.m_IntPartControlStartIndex = 0;
            this.m_txtREMARK.m_StrUserID = "";
            this.m_txtREMARK.m_StrUserName = "";
            this.m_txtREMARK.MaxLength = 8000;
            this.m_txtREMARK.Name = "m_txtREMARK";
            this.m_txtREMARK.Size = new System.Drawing.Size(290, 72);
            this.m_txtREMARK.TabIndex = 1000071;
            this.m_txtREMARK.Text = "";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.m_txtPLT);
            this.groupBox8.Controls.Add(this.m_txtWBC);
            this.groupBox8.Controls.Add(this.label60);
            this.groupBox8.Controls.Add(this.m_txtHB);
            this.groupBox8.Controls.Add(this.label61);
            this.groupBox8.Controls.Add(this.m_txtRBC);
            this.groupBox8.Controls.Add(this.label62);
            this.groupBox8.Controls.Add(this.m_txtHCT);
            this.groupBox8.Controls.Add(this.label63);
            this.groupBox8.Controls.Add(this.label64);
            this.groupBox8.Location = new System.Drawing.Point(8, 363);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(480, 40);
            this.groupBox8.TabIndex = 1000072;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "血常规";
            // 
            // m_txtPLT
            // 
            this.m_txtPLT.AccessibleDescription = "血常规>>PLT";
            this.m_txtPLT.BackColor = System.Drawing.Color.White;
            this.m_txtPLT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPLT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPLT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPLT.Location = new System.Drawing.Point(416, 14);
            this.m_txtPLT.m_BlnIgnoreUserInfo = false;
            this.m_txtPLT.m_BlnPartControl = false;
            this.m_txtPLT.m_BlnReadOnly = false;
            this.m_txtPLT.m_BlnUnderLineDST = false;
            this.m_txtPLT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPLT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPLT.m_IntCanModifyTime = 6;
            this.m_txtPLT.m_IntPartControlLength = 0;
            this.m_txtPLT.m_IntPartControlStartIndex = 0;
            this.m_txtPLT.m_StrUserID = "";
            this.m_txtPLT.m_StrUserName = "";
            this.m_txtPLT.MaxLength = 8000;
            this.m_txtPLT.Multiline = false;
            this.m_txtPLT.Name = "m_txtPLT";
            this.m_txtPLT.Size = new System.Drawing.Size(56, 22);
            this.m_txtPLT.TabIndex = 1000077;
            this.m_txtPLT.Text = "";
            // 
            // m_txtWBC
            // 
            this.m_txtWBC.AccessibleDescription = "血常规>>WBC";
            this.m_txtWBC.BackColor = System.Drawing.Color.White;
            this.m_txtWBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWBC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtWBC.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWBC.Location = new System.Drawing.Point(40, 14);
            this.m_txtWBC.m_BlnIgnoreUserInfo = false;
            this.m_txtWBC.m_BlnPartControl = false;
            this.m_txtWBC.m_BlnReadOnly = false;
            this.m_txtWBC.m_BlnUnderLineDST = false;
            this.m_txtWBC.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtWBC.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtWBC.m_IntCanModifyTime = 6;
            this.m_txtWBC.m_IntPartControlLength = 0;
            this.m_txtWBC.m_IntPartControlStartIndex = 0;
            this.m_txtWBC.m_StrUserID = "";
            this.m_txtWBC.m_StrUserName = "";
            this.m_txtWBC.MaxLength = 8000;
            this.m_txtWBC.Multiline = false;
            this.m_txtWBC.Name = "m_txtWBC";
            this.m_txtWBC.Size = new System.Drawing.Size(56, 22);
            this.m_txtWBC.TabIndex = 1000073;
            this.m_txtWBC.Text = "";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(8, 16);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(35, 14);
            this.label60.TabIndex = 10000022;
            this.label60.Text = "WBC:";
            // 
            // m_txtHB
            // 
            this.m_txtHB.AccessibleDescription = "血常规>>Hb";
            this.m_txtHB.BackColor = System.Drawing.Color.White;
            this.m_txtHB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtHB.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHB.Location = new System.Drawing.Point(128, 14);
            this.m_txtHB.m_BlnIgnoreUserInfo = false;
            this.m_txtHB.m_BlnPartControl = false;
            this.m_txtHB.m_BlnReadOnly = false;
            this.m_txtHB.m_BlnUnderLineDST = false;
            this.m_txtHB.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHB.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHB.m_IntCanModifyTime = 6;
            this.m_txtHB.m_IntPartControlLength = 0;
            this.m_txtHB.m_IntPartControlStartIndex = 0;
            this.m_txtHB.m_StrUserID = "";
            this.m_txtHB.m_StrUserName = "";
            this.m_txtHB.MaxLength = 8000;
            this.m_txtHB.Multiline = false;
            this.m_txtHB.Name = "m_txtHB";
            this.m_txtHB.Size = new System.Drawing.Size(56, 22);
            this.m_txtHB.TabIndex = 1000074;
            this.m_txtHB.Text = "";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(104, 16);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(28, 14);
            this.label61.TabIndex = 10000022;
            this.label61.Text = "Hb:";
            // 
            // m_txtRBC
            // 
            this.m_txtRBC.AccessibleDescription = "血常规>>RBC";
            this.m_txtRBC.BackColor = System.Drawing.Color.White;
            this.m_txtRBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRBC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtRBC.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRBC.Location = new System.Drawing.Point(224, 14);
            this.m_txtRBC.m_BlnIgnoreUserInfo = false;
            this.m_txtRBC.m_BlnPartControl = false;
            this.m_txtRBC.m_BlnReadOnly = false;
            this.m_txtRBC.m_BlnUnderLineDST = false;
            this.m_txtRBC.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRBC.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRBC.m_IntCanModifyTime = 6;
            this.m_txtRBC.m_IntPartControlLength = 0;
            this.m_txtRBC.m_IntPartControlStartIndex = 0;
            this.m_txtRBC.m_StrUserID = "";
            this.m_txtRBC.m_StrUserName = "";
            this.m_txtRBC.MaxLength = 8000;
            this.m_txtRBC.Multiline = false;
            this.m_txtRBC.Name = "m_txtRBC";
            this.m_txtRBC.Size = new System.Drawing.Size(56, 22);
            this.m_txtRBC.TabIndex = 1000075;
            this.m_txtRBC.Text = "";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(192, 16);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(35, 14);
            this.label62.TabIndex = 10000022;
            this.label62.Text = "RBC:";
            // 
            // m_txtHCT
            // 
            this.m_txtHCT.AccessibleDescription = "血常规>>HCT";
            this.m_txtHCT.BackColor = System.Drawing.Color.White;
            this.m_txtHCT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHCT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtHCT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHCT.Location = new System.Drawing.Point(320, 14);
            this.m_txtHCT.m_BlnIgnoreUserInfo = false;
            this.m_txtHCT.m_BlnPartControl = false;
            this.m_txtHCT.m_BlnReadOnly = false;
            this.m_txtHCT.m_BlnUnderLineDST = false;
            this.m_txtHCT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHCT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHCT.m_IntCanModifyTime = 6;
            this.m_txtHCT.m_IntPartControlLength = 0;
            this.m_txtHCT.m_IntPartControlStartIndex = 0;
            this.m_txtHCT.m_StrUserID = "";
            this.m_txtHCT.m_StrUserName = "";
            this.m_txtHCT.MaxLength = 8000;
            this.m_txtHCT.Multiline = false;
            this.m_txtHCT.Name = "m_txtHCT";
            this.m_txtHCT.Size = new System.Drawing.Size(56, 22);
            this.m_txtHCT.TabIndex = 1000076;
            this.m_txtHCT.Text = "";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(288, 16);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(35, 14);
            this.label63.TabIndex = 10000022;
            this.label63.Text = "HCT:";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(384, 16);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(35, 14);
            this.label64.TabIndex = 10000022;
            this.label64.Text = "PLT:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label72);
            this.groupBox9.Controls.Add(this.m_txtBE);
            this.groupBox9.Controls.Add(this.m_txtPH);
            this.groupBox9.Controls.Add(this.label65);
            this.groupBox9.Controls.Add(this.m_txtPCO2);
            this.groupBox9.Controls.Add(this.m_txtPAO2);
            this.groupBox9.Controls.Add(this.m_txtHCO3);
            this.groupBox9.Controls.Add(this.label68);
            this.groupBox9.Controls.Add(this.label69);
            this.groupBox9.Controls.Add(this.label70);
            this.groupBox9.Controls.Add(this.label66);
            this.groupBox9.Controls.Add(this.label71);
            this.groupBox9.Controls.Add(this.label67);
            this.groupBox9.Location = new System.Drawing.Point(496, 363);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(480, 40);
            this.groupBox9.TabIndex = 1000078;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "血气";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("宋体", 7F);
            this.label72.Location = new System.Drawing.Point(312, 24);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(10, 10);
            this.label72.TabIndex = 10000022;
            this.label72.Text = "3";
            // 
            // m_txtBE
            // 
            this.m_txtBE.AccessibleDescription = "血气>>BE";
            this.m_txtBE.BackColor = System.Drawing.Color.White;
            this.m_txtBE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBE.Location = new System.Drawing.Point(416, 14);
            this.m_txtBE.m_BlnIgnoreUserInfo = false;
            this.m_txtBE.m_BlnPartControl = false;
            this.m_txtBE.m_BlnReadOnly = false;
            this.m_txtBE.m_BlnUnderLineDST = false;
            this.m_txtBE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBE.m_IntCanModifyTime = 6;
            this.m_txtBE.m_IntPartControlLength = 0;
            this.m_txtBE.m_IntPartControlStartIndex = 0;
            this.m_txtBE.m_StrUserID = "";
            this.m_txtBE.m_StrUserName = "";
            this.m_txtBE.MaxLength = 8000;
            this.m_txtBE.Multiline = false;
            this.m_txtBE.Name = "m_txtBE";
            this.m_txtBE.Size = new System.Drawing.Size(56, 22);
            this.m_txtBE.TabIndex = 1000083;
            this.m_txtBE.Text = "";
            // 
            // m_txtPH
            // 
            this.m_txtPH.AccessibleDescription = "血气>>PH";
            this.m_txtPH.BackColor = System.Drawing.Color.White;
            this.m_txtPH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPH.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPH.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPH.Location = new System.Drawing.Point(40, 14);
            this.m_txtPH.m_BlnIgnoreUserInfo = false;
            this.m_txtPH.m_BlnPartControl = false;
            this.m_txtPH.m_BlnReadOnly = false;
            this.m_txtPH.m_BlnUnderLineDST = false;
            this.m_txtPH.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPH.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPH.m_IntCanModifyTime = 6;
            this.m_txtPH.m_IntPartControlLength = 0;
            this.m_txtPH.m_IntPartControlStartIndex = 0;
            this.m_txtPH.m_StrUserID = "";
            this.m_txtPH.m_StrUserName = "";
            this.m_txtPH.MaxLength = 8000;
            this.m_txtPH.Multiline = false;
            this.m_txtPH.Name = "m_txtPH";
            this.m_txtPH.Size = new System.Drawing.Size(56, 22);
            this.m_txtPH.TabIndex = 1000079;
            this.m_txtPH.Text = "";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(8, 16);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(28, 14);
            this.label65.TabIndex = 10000022;
            this.label65.Text = "PH:";
            // 
            // m_txtPCO2
            // 
            this.m_txtPCO2.AccessibleDescription = "血气>>PCO2";
            this.m_txtPCO2.BackColor = System.Drawing.Color.White;
            this.m_txtPCO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPCO2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPCO2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPCO2.Location = new System.Drawing.Point(136, 14);
            this.m_txtPCO2.m_BlnIgnoreUserInfo = false;
            this.m_txtPCO2.m_BlnPartControl = false;
            this.m_txtPCO2.m_BlnReadOnly = false;
            this.m_txtPCO2.m_BlnUnderLineDST = false;
            this.m_txtPCO2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPCO2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPCO2.m_IntCanModifyTime = 6;
            this.m_txtPCO2.m_IntPartControlLength = 0;
            this.m_txtPCO2.m_IntPartControlStartIndex = 0;
            this.m_txtPCO2.m_StrUserID = "";
            this.m_txtPCO2.m_StrUserName = "";
            this.m_txtPCO2.MaxLength = 8000;
            this.m_txtPCO2.Multiline = false;
            this.m_txtPCO2.Name = "m_txtPCO2";
            this.m_txtPCO2.Size = new System.Drawing.Size(56, 22);
            this.m_txtPCO2.TabIndex = 1000080;
            this.m_txtPCO2.Text = "";
            // 
            // m_txtPAO2
            // 
            this.m_txtPAO2.AccessibleDescription = "血气>>PaO2";
            this.m_txtPAO2.BackColor = System.Drawing.Color.White;
            this.m_txtPAO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPAO2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPAO2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPAO2.Location = new System.Drawing.Point(232, 14);
            this.m_txtPAO2.m_BlnIgnoreUserInfo = false;
            this.m_txtPAO2.m_BlnPartControl = false;
            this.m_txtPAO2.m_BlnReadOnly = false;
            this.m_txtPAO2.m_BlnUnderLineDST = false;
            this.m_txtPAO2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPAO2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPAO2.m_IntCanModifyTime = 6;
            this.m_txtPAO2.m_IntPartControlLength = 0;
            this.m_txtPAO2.m_IntPartControlStartIndex = 0;
            this.m_txtPAO2.m_StrUserID = "";
            this.m_txtPAO2.m_StrUserName = "";
            this.m_txtPAO2.MaxLength = 8000;
            this.m_txtPAO2.Multiline = false;
            this.m_txtPAO2.Name = "m_txtPAO2";
            this.m_txtPAO2.Size = new System.Drawing.Size(56, 22);
            this.m_txtPAO2.TabIndex = 1000081;
            this.m_txtPAO2.Text = "";
            // 
            // m_txtHCO3
            // 
            this.m_txtHCO3.AccessibleDescription = "血气>>HCO3";
            this.m_txtHCO3.BackColor = System.Drawing.Color.White;
            this.m_txtHCO3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHCO3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtHCO3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHCO3.Location = new System.Drawing.Point(328, 14);
            this.m_txtHCO3.m_BlnIgnoreUserInfo = false;
            this.m_txtHCO3.m_BlnPartControl = false;
            this.m_txtHCO3.m_BlnReadOnly = false;
            this.m_txtHCO3.m_BlnUnderLineDST = false;
            this.m_txtHCO3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHCO3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHCO3.m_IntCanModifyTime = 6;
            this.m_txtHCO3.m_IntPartControlLength = 0;
            this.m_txtHCO3.m_IntPartControlStartIndex = 0;
            this.m_txtHCO3.m_StrUserID = "";
            this.m_txtHCO3.m_StrUserName = "";
            this.m_txtHCO3.MaxLength = 8000;
            this.m_txtHCO3.Multiline = false;
            this.m_txtHCO3.Name = "m_txtHCO3";
            this.m_txtHCO3.Size = new System.Drawing.Size(56, 22);
            this.m_txtHCO3.TabIndex = 1000082;
            this.m_txtHCO3.Text = "";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(288, 16);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(42, 14);
            this.label68.TabIndex = 10000022;
            this.label68.Text = "HCO :";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(392, 16);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(28, 14);
            this.label69.TabIndex = 10000022;
            this.label69.Text = "BE:";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("宋体", 6F);
            this.label70.Location = new System.Drawing.Point(120, 24);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(9, 8);
            this.label70.TabIndex = 10000022;
            this.label70.Text = "2";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(96, 16);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(42, 14);
            this.label66.TabIndex = 10000022;
            this.label66.Text = "PCO :";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("宋体", 6F);
            this.label71.Location = new System.Drawing.Point(216, 24);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(9, 8);
            this.label71.TabIndex = 10000022;
            this.label71.Text = "2";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(192, 16);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(42, 14);
            this.label67.TabIndex = 10000022;
            this.label67.Text = "PaO :";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label81);
            this.groupBox10.Controls.Add(this.label80);
            this.groupBox10.Controls.Add(this.label79);
            this.groupBox10.Controls.Add(this.label78);
            this.groupBox10.Controls.Add(this.m_txtGLU);
            this.groupBox10.Controls.Add(this.m_txtKPLUS);
            this.groupBox10.Controls.Add(this.label73);
            this.groupBox10.Controls.Add(this.m_txtNAPLUS);
            this.groupBox10.Controls.Add(this.label74);
            this.groupBox10.Controls.Add(this.m_txtCISUB);
            this.groupBox10.Controls.Add(this.label75);
            this.groupBox10.Controls.Add(this.m_txtCAPLUSPLUS);
            this.groupBox10.Controls.Add(this.label76);
            this.groupBox10.Controls.Add(this.label77);
            this.groupBox10.Location = new System.Drawing.Point(8, 411);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(480, 40);
            this.groupBox10.TabIndex = 1000084;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "血电解质";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("宋体", 6F);
            this.label81.Location = new System.Drawing.Point(296, 16);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(13, 8);
            this.label81.TabIndex = 10000022;
            this.label81.Text = "++";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("宋体", 6F);
            this.label80.Location = new System.Drawing.Point(208, 16);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(9, 8);
            this.label80.TabIndex = 10000022;
            this.label80.Text = "-";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 6F);
            this.label79.Location = new System.Drawing.Point(112, 16);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(9, 8);
            this.label79.TabIndex = 10000022;
            this.label79.Text = "+";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("宋体", 6F);
            this.label78.Location = new System.Drawing.Point(20, 16);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(9, 8);
            this.label78.TabIndex = 10000022;
            this.label78.Text = "+";
            // 
            // m_txtGLU
            // 
            this.m_txtGLU.AccessibleDescription = "血电解质>>GLU";
            this.m_txtGLU.BackColor = System.Drawing.Color.White;
            this.m_txtGLU.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGLU.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtGLU.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtGLU.Location = new System.Drawing.Point(416, 14);
            this.m_txtGLU.m_BlnIgnoreUserInfo = false;
            this.m_txtGLU.m_BlnPartControl = false;
            this.m_txtGLU.m_BlnReadOnly = false;
            this.m_txtGLU.m_BlnUnderLineDST = false;
            this.m_txtGLU.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtGLU.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtGLU.m_IntCanModifyTime = 6;
            this.m_txtGLU.m_IntPartControlLength = 0;
            this.m_txtGLU.m_IntPartControlStartIndex = 0;
            this.m_txtGLU.m_StrUserID = "";
            this.m_txtGLU.m_StrUserName = "";
            this.m_txtGLU.MaxLength = 8000;
            this.m_txtGLU.Multiline = false;
            this.m_txtGLU.Name = "m_txtGLU";
            this.m_txtGLU.Size = new System.Drawing.Size(56, 22);
            this.m_txtGLU.TabIndex = 1000089;
            this.m_txtGLU.Text = "";
            // 
            // m_txtKPLUS
            // 
            this.m_txtKPLUS.AccessibleDescription = "血电解质>>K+";
            this.m_txtKPLUS.BackColor = System.Drawing.Color.White;
            this.m_txtKPLUS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtKPLUS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtKPLUS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtKPLUS.Location = new System.Drawing.Point(40, 14);
            this.m_txtKPLUS.m_BlnIgnoreUserInfo = false;
            this.m_txtKPLUS.m_BlnPartControl = false;
            this.m_txtKPLUS.m_BlnReadOnly = false;
            this.m_txtKPLUS.m_BlnUnderLineDST = false;
            this.m_txtKPLUS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtKPLUS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtKPLUS.m_IntCanModifyTime = 6;
            this.m_txtKPLUS.m_IntPartControlLength = 0;
            this.m_txtKPLUS.m_IntPartControlStartIndex = 0;
            this.m_txtKPLUS.m_StrUserID = "";
            this.m_txtKPLUS.m_StrUserName = "";
            this.m_txtKPLUS.MaxLength = 8000;
            this.m_txtKPLUS.Multiline = false;
            this.m_txtKPLUS.Name = "m_txtKPLUS";
            this.m_txtKPLUS.Size = new System.Drawing.Size(56, 22);
            this.m_txtKPLUS.TabIndex = 1000085;
            this.m_txtKPLUS.Text = "";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(8, 16);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(35, 14);
            this.label73.TabIndex = 10000022;
            this.label73.Text = "K  :";
            // 
            // m_txtNAPLUS
            // 
            this.m_txtNAPLUS.AccessibleDescription = "血电解质>>Na+";
            this.m_txtNAPLUS.BackColor = System.Drawing.Color.White;
            this.m_txtNAPLUS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNAPLUS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtNAPLUS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNAPLUS.Location = new System.Drawing.Point(128, 14);
            this.m_txtNAPLUS.m_BlnIgnoreUserInfo = false;
            this.m_txtNAPLUS.m_BlnPartControl = false;
            this.m_txtNAPLUS.m_BlnReadOnly = false;
            this.m_txtNAPLUS.m_BlnUnderLineDST = false;
            this.m_txtNAPLUS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNAPLUS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNAPLUS.m_IntCanModifyTime = 6;
            this.m_txtNAPLUS.m_IntPartControlLength = 0;
            this.m_txtNAPLUS.m_IntPartControlStartIndex = 0;
            this.m_txtNAPLUS.m_StrUserID = "";
            this.m_txtNAPLUS.m_StrUserName = "";
            this.m_txtNAPLUS.MaxLength = 8000;
            this.m_txtNAPLUS.Multiline = false;
            this.m_txtNAPLUS.Name = "m_txtNAPLUS";
            this.m_txtNAPLUS.Size = new System.Drawing.Size(56, 22);
            this.m_txtNAPLUS.TabIndex = 1000086;
            this.m_txtNAPLUS.Text = "";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(96, 16);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(35, 14);
            this.label74.TabIndex = 10000022;
            this.label74.Text = "Na :";
            // 
            // m_txtCISUB
            // 
            this.m_txtCISUB.AccessibleDescription = "血电解质>>CIˉ";
            this.m_txtCISUB.BackColor = System.Drawing.Color.White;
            this.m_txtCISUB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCISUB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCISUB.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCISUB.Location = new System.Drawing.Point(224, 14);
            this.m_txtCISUB.m_BlnIgnoreUserInfo = false;
            this.m_txtCISUB.m_BlnPartControl = false;
            this.m_txtCISUB.m_BlnReadOnly = false;
            this.m_txtCISUB.m_BlnUnderLineDST = false;
            this.m_txtCISUB.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCISUB.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCISUB.m_IntCanModifyTime = 6;
            this.m_txtCISUB.m_IntPartControlLength = 0;
            this.m_txtCISUB.m_IntPartControlStartIndex = 0;
            this.m_txtCISUB.m_StrUserID = "";
            this.m_txtCISUB.m_StrUserName = "";
            this.m_txtCISUB.MaxLength = 8000;
            this.m_txtCISUB.Multiline = false;
            this.m_txtCISUB.Name = "m_txtCISUB";
            this.m_txtCISUB.Size = new System.Drawing.Size(56, 22);
            this.m_txtCISUB.TabIndex = 1000087;
            this.m_txtCISUB.Text = "";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(192, 16);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(35, 14);
            this.label75.TabIndex = 10000022;
            this.label75.Text = "CI :";
            // 
            // m_txtCAPLUSPLUS
            // 
            this.m_txtCAPLUSPLUS.AccessibleDescription = "血电解质>>Ca++";
            this.m_txtCAPLUSPLUS.BackColor = System.Drawing.Color.White;
            this.m_txtCAPLUSPLUS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCAPLUSPLUS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCAPLUSPLUS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCAPLUSPLUS.Location = new System.Drawing.Point(320, 14);
            this.m_txtCAPLUSPLUS.m_BlnIgnoreUserInfo = false;
            this.m_txtCAPLUSPLUS.m_BlnPartControl = false;
            this.m_txtCAPLUSPLUS.m_BlnReadOnly = false;
            this.m_txtCAPLUSPLUS.m_BlnUnderLineDST = false;
            this.m_txtCAPLUSPLUS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCAPLUSPLUS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCAPLUSPLUS.m_IntCanModifyTime = 6;
            this.m_txtCAPLUSPLUS.m_IntPartControlLength = 0;
            this.m_txtCAPLUSPLUS.m_IntPartControlStartIndex = 0;
            this.m_txtCAPLUSPLUS.m_StrUserID = "";
            this.m_txtCAPLUSPLUS.m_StrUserName = "";
            this.m_txtCAPLUSPLUS.MaxLength = 8000;
            this.m_txtCAPLUSPLUS.Multiline = false;
            this.m_txtCAPLUSPLUS.Name = "m_txtCAPLUSPLUS";
            this.m_txtCAPLUSPLUS.Size = new System.Drawing.Size(56, 22);
            this.m_txtCAPLUSPLUS.TabIndex = 1000088;
            this.m_txtCAPLUSPLUS.Text = "";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(280, 16);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(42, 14);
            this.label76.TabIndex = 10000022;
            this.label76.Text = "Ca  :";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(384, 16);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(35, 14);
            this.label77.TabIndex = 10000022;
            this.label77.Text = "GLU:";
            // 
            // groupBox11
            // 
            this.groupBox11.AccessibleDescription = "血液生化>>BUN";
            this.groupBox11.Controls.Add(this.label82);
            this.groupBox11.Controls.Add(this.m_txtBUN);
            this.groupBox11.Controls.Add(this.m_txtUA);
            this.groupBox11.Controls.Add(this.m_txtANHYDRIDE);
            this.groupBox11.Controls.Add(this.m_txtCO2CP);
            this.groupBox11.Controls.Add(this.label84);
            this.groupBox11.Controls.Add(this.label87);
            this.groupBox11.Controls.Add(this.label89);
            this.groupBox11.Controls.Add(this.label83);
            this.groupBox11.Location = new System.Drawing.Point(496, 411);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(400, 40);
            this.groupBox11.TabIndex = 1000090;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "血液生化";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("宋体", 7F);
            this.label82.Location = new System.Drawing.Point(303, 24);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(10, 10);
            this.label82.TabIndex = 10000022;
            this.label82.Text = "2";
            // 
            // m_txtBUN
            // 
            this.m_txtBUN.AccessibleDescription = "";
            this.m_txtBUN.BackColor = System.Drawing.Color.White;
            this.m_txtBUN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBUN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBUN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBUN.Location = new System.Drawing.Point(40, 14);
            this.m_txtBUN.m_BlnIgnoreUserInfo = false;
            this.m_txtBUN.m_BlnPartControl = false;
            this.m_txtBUN.m_BlnReadOnly = false;
            this.m_txtBUN.m_BlnUnderLineDST = false;
            this.m_txtBUN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBUN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBUN.m_IntCanModifyTime = 6;
            this.m_txtBUN.m_IntPartControlLength = 0;
            this.m_txtBUN.m_IntPartControlStartIndex = 0;
            this.m_txtBUN.m_StrUserID = "";
            this.m_txtBUN.m_StrUserName = "";
            this.m_txtBUN.MaxLength = 8000;
            this.m_txtBUN.Multiline = false;
            this.m_txtBUN.Name = "m_txtBUN";
            this.m_txtBUN.Size = new System.Drawing.Size(56, 22);
            this.m_txtBUN.TabIndex = 1000091;
            this.m_txtBUN.Text = "";
            // 
            // m_txtUA
            // 
            this.m_txtUA.AccessibleDescription = "血液生化>>UA";
            this.m_txtUA.BackColor = System.Drawing.Color.White;
            this.m_txtUA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtUA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUA.Location = new System.Drawing.Point(136, 14);
            this.m_txtUA.m_BlnIgnoreUserInfo = false;
            this.m_txtUA.m_BlnPartControl = false;
            this.m_txtUA.m_BlnReadOnly = false;
            this.m_txtUA.m_BlnUnderLineDST = false;
            this.m_txtUA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUA.m_IntCanModifyTime = 6;
            this.m_txtUA.m_IntPartControlLength = 0;
            this.m_txtUA.m_IntPartControlStartIndex = 0;
            this.m_txtUA.m_StrUserID = "";
            this.m_txtUA.m_StrUserName = "";
            this.m_txtUA.MaxLength = 8000;
            this.m_txtUA.Multiline = false;
            this.m_txtUA.Name = "m_txtUA";
            this.m_txtUA.Size = new System.Drawing.Size(56, 22);
            this.m_txtUA.TabIndex = 1000092;
            this.m_txtUA.Text = "";
            // 
            // m_txtANHYDRIDE
            // 
            this.m_txtANHYDRIDE.AccessibleDescription = "血液生化>>肌酐";
            this.m_txtANHYDRIDE.BackColor = System.Drawing.Color.White;
            this.m_txtANHYDRIDE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtANHYDRIDE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtANHYDRIDE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtANHYDRIDE.Location = new System.Drawing.Point(232, 14);
            this.m_txtANHYDRIDE.m_BlnIgnoreUserInfo = false;
            this.m_txtANHYDRIDE.m_BlnPartControl = false;
            this.m_txtANHYDRIDE.m_BlnReadOnly = false;
            this.m_txtANHYDRIDE.m_BlnUnderLineDST = false;
            this.m_txtANHYDRIDE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtANHYDRIDE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtANHYDRIDE.m_IntCanModifyTime = 6;
            this.m_txtANHYDRIDE.m_IntPartControlLength = 0;
            this.m_txtANHYDRIDE.m_IntPartControlStartIndex = 0;
            this.m_txtANHYDRIDE.m_StrUserID = "";
            this.m_txtANHYDRIDE.m_StrUserName = "";
            this.m_txtANHYDRIDE.MaxLength = 8000;
            this.m_txtANHYDRIDE.Multiline = false;
            this.m_txtANHYDRIDE.Name = "m_txtANHYDRIDE";
            this.m_txtANHYDRIDE.Size = new System.Drawing.Size(56, 22);
            this.m_txtANHYDRIDE.TabIndex = 1000093;
            this.m_txtANHYDRIDE.Text = "";
            // 
            // m_txtCO2CP
            // 
            this.m_txtCO2CP.AccessibleDescription = "血液生化>>CO2CP2";
            this.m_txtCO2CP.BackColor = System.Drawing.Color.White;
            this.m_txtCO2CP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCO2CP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCO2CP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCO2CP.Location = new System.Drawing.Point(336, 14);
            this.m_txtCO2CP.m_BlnIgnoreUserInfo = false;
            this.m_txtCO2CP.m_BlnPartControl = false;
            this.m_txtCO2CP.m_BlnReadOnly = false;
            this.m_txtCO2CP.m_BlnUnderLineDST = false;
            this.m_txtCO2CP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCO2CP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCO2CP.m_IntCanModifyTime = 6;
            this.m_txtCO2CP.m_IntPartControlLength = 0;
            this.m_txtCO2CP.m_IntPartControlStartIndex = 0;
            this.m_txtCO2CP.m_StrUserID = "";
            this.m_txtCO2CP.m_StrUserName = "";
            this.m_txtCO2CP.MaxLength = 8000;
            this.m_txtCO2CP.Multiline = false;
            this.m_txtCO2CP.Name = "m_txtCO2CP";
            this.m_txtCO2CP.Size = new System.Drawing.Size(56, 22);
            this.m_txtCO2CP.TabIndex = 1000094;
            this.m_txtCO2CP.Text = "";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(288, 16);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(49, 14);
            this.label84.TabIndex = 10000022;
            this.label84.Text = "CO CP:";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(112, 16);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(28, 14);
            this.label87.TabIndex = 10000022;
            this.label87.Text = "UA:";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(192, 16);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(42, 14);
            this.label89.TabIndex = 10000022;
            this.label89.Text = "肌酐:";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(8, 16);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(35, 14);
            this.label83.TabIndex = 10000022;
            this.label83.Text = "BUN:";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(22, 459);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(28, 14);
            this.label85.TabIndex = 10000029;
            this.label85.Text = "PT:";
            // 
            // m_txtPT
            // 
            this.m_txtPT.AccessibleDescription = "PT";
            this.m_txtPT.BackColor = System.Drawing.Color.White;
            this.m_txtPT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPT.Location = new System.Drawing.Point(48, 457);
            this.m_txtPT.m_BlnIgnoreUserInfo = false;
            this.m_txtPT.m_BlnPartControl = false;
            this.m_txtPT.m_BlnReadOnly = false;
            this.m_txtPT.m_BlnUnderLineDST = false;
            this.m_txtPT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPT.m_IntCanModifyTime = 6;
            this.m_txtPT.m_IntPartControlLength = 0;
            this.m_txtPT.m_IntPartControlStartIndex = 0;
            this.m_txtPT.m_StrUserID = "";
            this.m_txtPT.m_StrUserName = "";
            this.m_txtPT.MaxLength = 8000;
            this.m_txtPT.Multiline = false;
            this.m_txtPT.Name = "m_txtPT";
            this.m_txtPT.Size = new System.Drawing.Size(144, 22);
            this.m_txtPT.TabIndex = 1000095;
            this.m_txtPT.Text = "";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(200, 459);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(63, 14);
            this.label86.TabIndex = 10000029;
            this.label86.Text = "X线检查:";
            // 
            // m_txtXRAYCHECK
            // 
            this.m_txtXRAYCHECK.AccessibleDescription = "X线检查";
            this.m_txtXRAYCHECK.BackColor = System.Drawing.Color.White;
            this.m_txtXRAYCHECK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtXRAYCHECK.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtXRAYCHECK.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtXRAYCHECK.Location = new System.Drawing.Point(264, 459);
            this.m_txtXRAYCHECK.m_BlnIgnoreUserInfo = false;
            this.m_txtXRAYCHECK.m_BlnPartControl = false;
            this.m_txtXRAYCHECK.m_BlnReadOnly = false;
            this.m_txtXRAYCHECK.m_BlnUnderLineDST = false;
            this.m_txtXRAYCHECK.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtXRAYCHECK.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtXRAYCHECK.m_IntCanModifyTime = 6;
            this.m_txtXRAYCHECK.m_IntPartControlLength = 0;
            this.m_txtXRAYCHECK.m_IntPartControlStartIndex = 0;
            this.m_txtXRAYCHECK.m_StrUserID = "";
            this.m_txtXRAYCHECK.m_StrUserName = "";
            this.m_txtXRAYCHECK.MaxLength = 8000;
            this.m_txtXRAYCHECK.Multiline = false;
            this.m_txtXRAYCHECK.Name = "m_txtXRAYCHECK";
            this.m_txtXRAYCHECK.Size = new System.Drawing.Size(520, 22);
            this.m_txtXRAYCHECK.TabIndex = 1000096;
            this.m_txtXRAYCHECK.Text = "";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(800, 459);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(35, 14);
            this.label88.TabIndex = 10000029;
            this.label88.Text = "ACT:";
            // 
            // m_txtACT
            // 
            this.m_txtACT.AccessibleDescription = "ACT";
            this.m_txtACT.BackColor = System.Drawing.Color.White;
            this.m_txtACT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtACT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtACT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtACT.Location = new System.Drawing.Point(832, 459);
            this.m_txtACT.m_BlnIgnoreUserInfo = false;
            this.m_txtACT.m_BlnPartControl = false;
            this.m_txtACT.m_BlnReadOnly = false;
            this.m_txtACT.m_BlnUnderLineDST = false;
            this.m_txtACT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtACT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtACT.m_IntCanModifyTime = 6;
            this.m_txtACT.m_IntPartControlLength = 0;
            this.m_txtACT.m_IntPartControlStartIndex = 0;
            this.m_txtACT.m_StrUserID = "";
            this.m_txtACT.m_StrUserName = "";
            this.m_txtACT.MaxLength = 8000;
            this.m_txtACT.Multiline = false;
            this.m_txtACT.Name = "m_txtACT";
            this.m_txtACT.Size = new System.Drawing.Size(136, 22);
            this.m_txtACT.TabIndex = 1000097;
            this.m_txtACT.Text = "";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.m_cboHIDDENBLOOD);
            this.groupBox12.Controls.Add(this.m_cboALBUMEN);
            this.groupBox12.Controls.Add(this.m_txtPROPORTION);
            this.groupBox12.Controls.Add(this.label90);
            this.groupBox12.Controls.Add(this.label91);
            this.groupBox12.Controls.Add(this.label92);
            this.groupBox12.Location = new System.Drawing.Point(8, 479);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(324, 48);
            this.groupBox12.TabIndex = 1000098;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "尿常规";
            // 
            // m_cboHIDDENBLOOD
            // 
            this.m_cboHIDDENBLOOD.AccessibleDescription = "尿常规>>潜血";
            this.m_cboHIDDENBLOOD.BackColor = System.Drawing.Color.White;
            this.m_cboHIDDENBLOOD.BorderColor = System.Drawing.Color.Black;
            this.m_cboHIDDENBLOOD.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHIDDENBLOOD.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHIDDENBLOOD.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHIDDENBLOOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHIDDENBLOOD.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHIDDENBLOOD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHIDDENBLOOD.ForeColor = System.Drawing.Color.Black;
            this.m_cboHIDDENBLOOD.ListBackColor = System.Drawing.Color.White;
            this.m_cboHIDDENBLOOD.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHIDDENBLOOD.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHIDDENBLOOD.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHIDDENBLOOD.Location = new System.Drawing.Point(244, 16);
            this.m_cboHIDDENBLOOD.m_BlnEnableItemEventMenu = true;
            this.m_cboHIDDENBLOOD.Name = "m_cboHIDDENBLOOD";
            this.m_cboHIDDENBLOOD.SelectedIndex = -1;
            this.m_cboHIDDENBLOOD.SelectedItem = null;
            this.m_cboHIDDENBLOOD.SelectionStart = 0;
            this.m_cboHIDDENBLOOD.Size = new System.Drawing.Size(76, 23);
            this.m_cboHIDDENBLOOD.TabIndex = 10000101;
            this.m_cboHIDDENBLOOD.TextBackColor = System.Drawing.Color.White;
            this.m_cboHIDDENBLOOD.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboALBUMEN
            // 
            this.m_cboALBUMEN.AccessibleDescription = "尿常规>>蛋白";
            this.m_cboALBUMEN.BackColor = System.Drawing.Color.White;
            this.m_cboALBUMEN.BorderColor = System.Drawing.Color.Black;
            this.m_cboALBUMEN.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboALBUMEN.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboALBUMEN.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboALBUMEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboALBUMEN.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboALBUMEN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboALBUMEN.ForeColor = System.Drawing.Color.Black;
            this.m_cboALBUMEN.ListBackColor = System.Drawing.Color.White;
            this.m_cboALBUMEN.ListForeColor = System.Drawing.Color.Black;
            this.m_cboALBUMEN.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboALBUMEN.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboALBUMEN.Location = new System.Drawing.Point(132, 17);
            this.m_cboALBUMEN.m_BlnEnableItemEventMenu = true;
            this.m_cboALBUMEN.Name = "m_cboALBUMEN";
            this.m_cboALBUMEN.SelectedIndex = -1;
            this.m_cboALBUMEN.SelectedItem = null;
            this.m_cboALBUMEN.SelectionStart = 0;
            this.m_cboALBUMEN.Size = new System.Drawing.Size(76, 23);
            this.m_cboALBUMEN.TabIndex = 10000100;
            this.m_cboALBUMEN.TextBackColor = System.Drawing.Color.White;
            this.m_cboALBUMEN.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtPROPORTION
            // 
            this.m_txtPROPORTION.AccessibleDescription = "尿常规>>比重";
            this.m_txtPROPORTION.BackColor = System.Drawing.Color.White;
            this.m_txtPROPORTION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPROPORTION.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPROPORTION.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPROPORTION.Location = new System.Drawing.Point(40, 17);
            this.m_txtPROPORTION.m_BlnIgnoreUserInfo = false;
            this.m_txtPROPORTION.m_BlnPartControl = false;
            this.m_txtPROPORTION.m_BlnReadOnly = false;
            this.m_txtPROPORTION.m_BlnUnderLineDST = false;
            this.m_txtPROPORTION.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPROPORTION.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPROPORTION.m_IntCanModifyTime = 6;
            this.m_txtPROPORTION.m_IntPartControlLength = 0;
            this.m_txtPROPORTION.m_IntPartControlStartIndex = 0;
            this.m_txtPROPORTION.m_StrUserID = "";
            this.m_txtPROPORTION.m_StrUserName = "";
            this.m_txtPROPORTION.MaxLength = 8000;
            this.m_txtPROPORTION.Multiline = false;
            this.m_txtPROPORTION.Name = "m_txtPROPORTION";
            this.m_txtPROPORTION.Size = new System.Drawing.Size(56, 22);
            this.m_txtPROPORTION.TabIndex = 1000099;
            this.m_txtPROPORTION.Text = "";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(4, 19);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(42, 14);
            this.label90.TabIndex = 10000024;
            this.label90.Text = "比重:";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(96, 19);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(42, 14);
            this.label91.TabIndex = 10000024;
            this.label91.Text = "蛋白:";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(208, 19);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(42, 14);
            this.label92.TabIndex = 10000024;
            this.label92.Text = "潜血:";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.m_cboWASHPERINEUM);
            this.groupBox13.Controls.Add(this.m_cboBRUSHBATH);
            this.groupBox13.Controls.Add(this.m_cboMOUTHTEND);
            this.groupBox13.Controls.Add(this.label96);
            this.groupBox13.Controls.Add(this.m_cboSKIN);
            this.groupBox13.Controls.Add(this.label93);
            this.groupBox13.Controls.Add(this.label94);
            this.groupBox13.Controls.Add(this.label95);
            this.groupBox13.Location = new System.Drawing.Point(332, 479);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(502, 48);
            this.groupBox13.TabIndex = 10000031;
            this.groupBox13.TabStop = false;
            // 
            // m_cboWASHPERINEUM
            // 
            this.m_cboWASHPERINEUM.AccessibleDescription = "会阴冲洗";
            this.m_cboWASHPERINEUM.BackColor = System.Drawing.Color.White;
            this.m_cboWASHPERINEUM.BorderColor = System.Drawing.Color.Black;
            this.m_cboWASHPERINEUM.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboWASHPERINEUM.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboWASHPERINEUM.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboWASHPERINEUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboWASHPERINEUM.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboWASHPERINEUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboWASHPERINEUM.ForeColor = System.Drawing.Color.Black;
            this.m_cboWASHPERINEUM.ListBackColor = System.Drawing.Color.White;
            this.m_cboWASHPERINEUM.ListForeColor = System.Drawing.Color.Black;
            this.m_cboWASHPERINEUM.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboWASHPERINEUM.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboWASHPERINEUM.Location = new System.Drawing.Point(174, 18);
            this.m_cboWASHPERINEUM.m_BlnEnableItemEventMenu = true;
            this.m_cboWASHPERINEUM.Name = "m_cboWASHPERINEUM";
            this.m_cboWASHPERINEUM.SelectedIndex = -1;
            this.m_cboWASHPERINEUM.SelectedItem = null;
            this.m_cboWASHPERINEUM.SelectionStart = 0;
            this.m_cboWASHPERINEUM.Size = new System.Drawing.Size(76, 23);
            this.m_cboWASHPERINEUM.TabIndex = 10000103;
            this.m_cboWASHPERINEUM.TextBackColor = System.Drawing.Color.White;
            this.m_cboWASHPERINEUM.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboBRUSHBATH
            // 
            this.m_cboBRUSHBATH.AccessibleDescription = "擦浴";
            this.m_cboBRUSHBATH.BackColor = System.Drawing.Color.White;
            this.m_cboBRUSHBATH.BorderColor = System.Drawing.Color.Black;
            this.m_cboBRUSHBATH.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBRUSHBATH.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBRUSHBATH.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBRUSHBATH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBRUSHBATH.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBRUSHBATH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBRUSHBATH.ForeColor = System.Drawing.Color.Black;
            this.m_cboBRUSHBATH.ListBackColor = System.Drawing.Color.White;
            this.m_cboBRUSHBATH.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBRUSHBATH.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBRUSHBATH.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBRUSHBATH.Location = new System.Drawing.Point(284, 18);
            this.m_cboBRUSHBATH.m_BlnEnableItemEventMenu = true;
            this.m_cboBRUSHBATH.Name = "m_cboBRUSHBATH";
            this.m_cboBRUSHBATH.SelectedIndex = -1;
            this.m_cboBRUSHBATH.SelectedItem = null;
            this.m_cboBRUSHBATH.SelectionStart = 0;
            this.m_cboBRUSHBATH.Size = new System.Drawing.Size(76, 23);
            this.m_cboBRUSHBATH.TabIndex = 10000104;
            this.m_cboBRUSHBATH.TextBackColor = System.Drawing.Color.White;
            this.m_cboBRUSHBATH.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboMOUTHTEND
            // 
            this.m_cboMOUTHTEND.AccessibleDescription = "口腔护理";
            this.m_cboMOUTHTEND.BackColor = System.Drawing.Color.White;
            this.m_cboMOUTHTEND.BorderColor = System.Drawing.Color.Black;
            this.m_cboMOUTHTEND.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMOUTHTEND.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboMOUTHTEND.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMOUTHTEND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMOUTHTEND.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMOUTHTEND.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMOUTHTEND.ForeColor = System.Drawing.Color.Black;
            this.m_cboMOUTHTEND.ListBackColor = System.Drawing.Color.White;
            this.m_cboMOUTHTEND.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMOUTHTEND.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMOUTHTEND.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMOUTHTEND.Location = new System.Drawing.Point(422, 18);
            this.m_cboMOUTHTEND.m_BlnEnableItemEventMenu = true;
            this.m_cboMOUTHTEND.Name = "m_cboMOUTHTEND";
            this.m_cboMOUTHTEND.SelectedIndex = -1;
            this.m_cboMOUTHTEND.SelectedItem = null;
            this.m_cboMOUTHTEND.SelectionStart = 0;
            this.m_cboMOUTHTEND.Size = new System.Drawing.Size(76, 23);
            this.m_cboMOUTHTEND.TabIndex = 10000105;
            this.m_cboMOUTHTEND.TextBackColor = System.Drawing.Color.White;
            this.m_cboMOUTHTEND.TextForeColor = System.Drawing.Color.Black;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(362, 20);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(63, 14);
            this.label96.TabIndex = 10000024;
            this.label96.Text = "口腔护理";
            // 
            // m_cboSKIN
            // 
            this.m_cboSKIN.AccessibleDescription = "皮肤";
            this.m_cboSKIN.BackColor = System.Drawing.Color.White;
            this.m_cboSKIN.BorderColor = System.Drawing.Color.Black;
            this.m_cboSKIN.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboSKIN.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboSKIN.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboSKIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboSKIN.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSKIN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSKIN.ForeColor = System.Drawing.Color.Black;
            this.m_cboSKIN.ListBackColor = System.Drawing.Color.White;
            this.m_cboSKIN.ListForeColor = System.Drawing.Color.Black;
            this.m_cboSKIN.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboSKIN.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboSKIN.Location = new System.Drawing.Point(36, 16);
            this.m_cboSKIN.m_BlnEnableItemEventMenu = true;
            this.m_cboSKIN.Name = "m_cboSKIN";
            this.m_cboSKIN.SelectedIndex = -1;
            this.m_cboSKIN.SelectedItem = null;
            this.m_cboSKIN.SelectionStart = 0;
            this.m_cboSKIN.Size = new System.Drawing.Size(76, 23);
            this.m_cboSKIN.TabIndex = 10000102;
            this.m_cboSKIN.TextBackColor = System.Drawing.Color.White;
            this.m_cboSKIN.TextForeColor = System.Drawing.Color.Black;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(4, 19);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(35, 14);
            this.label93.TabIndex = 10000024;
            this.label93.Text = "皮肤";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(112, 19);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(63, 14);
            this.label94.TabIndex = 10000024;
            this.label94.Text = "会阴冲洗";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(254, 19);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(35, 14);
            this.label95.TabIndex = 10000024;
            this.label95.Text = "擦浴";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.ForeColor = System.Drawing.Color.Black;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(840, 487);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 10000106;
            this.m_cmdOK.Text = "确定(&Y)";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.ForeColor = System.Drawing.Color.Black;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(912, 487);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 10000107;
            this.m_cmdCancel.Text = "取消(&C)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_txtSPO
            // 
            this.m_txtSPO.AccessibleDescription = "循环>>SPO";
            this.m_txtSPO.BackColor = System.Drawing.Color.White;
            this.m_txtSPO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSPO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSPO.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSPO.Location = new System.Drawing.Point(940, 198);
            this.m_txtSPO.m_BlnIgnoreUserInfo = false;
            this.m_txtSPO.m_BlnPartControl = false;
            this.m_txtSPO.m_BlnReadOnly = false;
            this.m_txtSPO.m_BlnUnderLineDST = false;
            this.m_txtSPO.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSPO.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSPO.m_IntCanModifyTime = 6;
            this.m_txtSPO.m_IntPartControlLength = 0;
            this.m_txtSPO.m_IntPartControlStartIndex = 0;
            this.m_txtSPO.m_StrUserID = "";
            this.m_txtSPO.m_StrUserName = "";
            this.m_txtSPO.MaxLength = 8000;
            this.m_txtSPO.Multiline = false;
            this.m_txtSPO.Name = "m_txtSPO";
            this.m_txtSPO.Size = new System.Drawing.Size(51, 22);
            this.m_txtSPO.TabIndex = 1000049;
            this.m_txtSPO.Text = "";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.ForeColor = System.Drawing.Color.SteelBlue;
            this.label103.Location = new System.Drawing.Point(108, 99);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(119, 14);
            this.label103.TabIndex = 10000392;
            this.label103.Text = "F3(添加)F4(删除)";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.ForeColor = System.Drawing.Color.SteelBlue;
            this.label104.Location = new System.Drawing.Point(112, 99);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(119, 14);
            this.label104.TabIndex = 10000392;
            this.label104.Text = "F5(添加)F6(删除)";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.ForeColor = System.Drawing.Color.SteelBlue;
            this.label105.Location = new System.Drawing.Point(107, 103);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(119, 14);
            this.label105.TabIndex = 10000392;
            this.label105.Text = "F1(添加)F2(删除)";
            // 
            // frmCardiovascularTend_GX
            // 
            this.AccessibleDescription = "心血管外科特护记录";
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1005, 541);
            this.Controls.Add(this.m_txtSPO);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.m_txtACT);
            this.Controls.Add(this.m_txtPT);
            this.Controls.Add(this.label85);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_txtINFACT4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_txtINFACT1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_txtINFACT2);
            this.Controls.Add(this.m_txtINFACT3);
            this.Controls.Add(this.m_txtINFACT5);
            this.Controls.Add(this.m_txtINBLOOD);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_txtINPERHOUR);
            this.Controls.Add(this.m_txtINSUM);
            this.Controls.Add(this.m_txtOUTPERHOUR);
            this.Controls.Add(this.m_txtOUTSUM);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.m_txtOUTFACTPISSSUM);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.m_txtOUTFACTPISS);
            this.Controls.Add(this.m_txtOUTFACTCHESTJUICE);
            this.Controls.Add(this.m_txtOUTFACTCHESTJUICESUM);
            this.Controls.Add(this.m_txtOUTFACTGASTRICJUICE);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.label86);
            this.Controls.Add(this.m_txtXRAYCHECK);
            this.Controls.Add(this.label88);
            this.KeyPreview = true;
            this.Name = "frmCardiovascularTend_GX";
            this.Text = "心血管外科特护记录";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCardiovascularTend_GX_KeyDown);
            this.Load += new System.EventHandler(this.frmCardiovascularTend_GX_Load);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label88, 0);
            this.Controls.SetChildIndex(this.m_txtXRAYCHECK, 0);
            this.Controls.SetChildIndex(this.label86, 0);
            this.Controls.SetChildIndex(this.groupBox11, 0);
            this.Controls.SetChildIndex(this.groupBox10, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.m_txtOUTFACTGASTRICJUICE, 0);
            this.Controls.SetChildIndex(this.m_txtOUTFACTCHESTJUICESUM, 0);
            this.Controls.SetChildIndex(this.m_txtOUTFACTCHESTJUICE, 0);
            this.Controls.SetChildIndex(this.m_txtOUTFACTPISS, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.m_txtOUTFACTPISSSUM, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.m_txtOUTSUM, 0);
            this.Controls.SetChildIndex(this.m_txtOUTPERHOUR, 0);
            this.Controls.SetChildIndex(this.m_txtINSUM, 0);
            this.Controls.SetChildIndex(this.m_txtINPERHOUR, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
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
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtINBLOOD, 0);
            this.Controls.SetChildIndex(this.m_txtINFACT5, 0);
            this.Controls.SetChildIndex(this.m_txtINFACT3, 0);
            this.Controls.SetChildIndex(this.m_txtINFACT2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.m_txtINFACT1, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.m_txtINFACT4, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.Controls.SetChildIndex(this.groupBox7, 0);
            this.Controls.SetChildIndex(this.groupBox8, 0);
            this.Controls.SetChildIndex(this.groupBox9, 0);
            this.Controls.SetChildIndex(this.label85, 0);
            this.Controls.SetChildIndex(this.m_txtPT, 0);
            this.Controls.SetChildIndex(this.m_txtACT, 0);
            this.Controls.SetChildIndex(this.groupBox12, 0);
            this.Controls.SetChildIndex(this.groupBox13, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.m_txtSPO, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override int m_IntFormID
		{
			get
			{
				return 83;
			}
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现

			return	"心血管外科特护记录";
		}

		protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.CardiovascularTend_GX);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsCardiovascularTend_GX objContent=(clsCardiovascularTend_GX)p_objRecordContent;
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{		
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;

			#region 从界面获取表单值		
			clsCardiovascularTend_GX objContent=new clsCardiovascularTend_GX ();
			try
			{
				objContent.m_strModifyUserID = MDIParent.OperatorID;
				objContent.m_dtmRECORDDATE = this.m_dtpCreateDate.Value;

				objContent.m_strINFACT1_RIGHT = this.m_txtINFACT1.m_strGetRightText();
				objContent.m_strINFACT1 = this.m_txtINFACT1.Text;
				objContent.m_strINFACT1XML = this.m_txtINFACT1.m_strGetXmlText();

				objContent.m_strINFACT2_RIGHT = this.m_txtINFACT2.m_strGetRightText();
				objContent.m_strINFACT2 = this.m_txtINFACT2.Text;
				objContent.m_strINFACT2XML = this.m_txtINFACT2.m_strGetXmlText();

				objContent.m_strINFACT3_RIGHT = this.m_txtINFACT3.m_strGetRightText();
				objContent.m_strINFACT3 = this.m_txtINFACT3.Text;
				objContent.m_strINFACT3XML = this.m_txtINFACT3.m_strGetXmlText();

				objContent.m_strINFACT4_RIGHT = this.m_txtINFACT4.m_strGetRightText();
				objContent.m_strINFACT4 = this.m_txtINFACT4.Text;
				objContent.m_strINFACT4XML = this.m_txtINFACT4.m_strGetXmlText();
				
				objContent.m_strINFACT5_RIGHT = this.m_txtINFACT5.m_strGetRightText();
				objContent.m_strINFACT5 = this.m_txtINFACT5.Text;
				objContent.m_strINFACT5XML = this.m_txtINFACT5.m_strGetXmlText();

				objContent.m_strINBLOOD_RIGHT = this.m_txtINBLOOD.m_strGetRightText();
				objContent.m_strINBLOOD = this.m_txtINBLOOD.Text;
				objContent.m_strINBLOODXML = this.m_txtINBLOOD.m_strGetXmlText();

				objContent.m_strINPERHOUR_RIGHT = this.m_txtINPERHOUR.m_strGetRightText();
				objContent.m_strINPERHOUR = this.m_txtINPERHOUR.Text;
				objContent.m_strINPERHOURXML = this.m_txtINPERHOUR.m_strGetXmlText();

				objContent.m_strINSUM_RIGHT = this.m_txtINSUM.m_strGetRightText();
				objContent.m_strINSUM = this.m_txtINSUM.Text;
				objContent.m_strINSUMXML = this.m_txtINSUM.m_strGetXmlText();

				objContent.m_strOUTSUM_RIGHT = this.m_txtOUTSUM.m_strGetRightText();
				objContent.m_strOUTSUM = this.m_txtOUTSUM.Text;
				objContent.m_strOUTSUMXML = this.m_txtOUTSUM.m_strGetXmlText();

				objContent.m_strOUTPERHOUR_RIGHT = this.m_txtOUTPERHOUR.m_strGetRightText();
				objContent.m_strOUTPERHOUR = this.m_txtOUTPERHOUR.Text;
				objContent.m_strOUTPERHOURXML = this.m_txtOUTPERHOUR.m_strGetXmlText();

				objContent.m_strOUTFACTPISSSUM_RIGHT = this.m_txtOUTFACTPISSSUM.m_strGetRightText();
				objContent.m_strOUTFACTPISSSUM = this.m_txtOUTFACTPISSSUM.Text;
				objContent.m_strOUTFACTPISSSUMXML = this.m_txtOUTFACTPISSSUM.m_strGetXmlText();

				objContent.m_strOUTFACTPISS_RIGHT = this.m_txtOUTFACTPISS.m_strGetRightText();
				objContent.m_strOUTFACTPISS = this.m_txtOUTFACTPISS.Text;
				objContent.m_strOUTFACTPISSXML = this.m_txtOUTFACTPISS.m_strGetXmlText();

				objContent.m_strOUTFACTCHESTJUICE_RIGHT = this.m_txtOUTFACTCHESTJUICE.m_strGetRightText();
				objContent.m_strOUTFACTCHESTJUICE = this.m_txtOUTFACTCHESTJUICE.Text;
				objContent.m_strOUTFACTCHESTJUICEXML = this.m_txtOUTFACTCHESTJUICE.m_strGetXmlText();

				objContent.m_strOUTFACTCHESTJUICESUM_RIGHT = this.m_txtOUTFACTCHESTJUICESUM.m_strGetRightText();
				objContent.m_strOUTFACTCHESTJUICESUM = this.m_txtOUTFACTCHESTJUICESUM.Text;
				objContent.m_strOUTFACTCHESTJUICESUMXML = this.m_txtOUTFACTCHESTJUICESUM.m_strGetXmlText();

				objContent.m_strOUTFACTGASTRICJUICE_RIGHT = this.m_txtOUTFACTGASTRICJUICE.m_strGetRightText();
				objContent.m_strOUTFACTGASTRICJUICE = this.m_txtOUTFACTGASTRICJUICE.Text;
				objContent.m_strOUTFACTGASTRICJUICEXML = this.m_txtOUTFACTGASTRICJUICE.m_strGetXmlText();

				if(m_lsvEXPANDVASMEDICINE.Items.Count > 0)
				{
					string strEXPANDVASMEDICINE = "";
					for(int i=0; i<m_lsvEXPANDVASMEDICINE.Items.Count; i++)
					{
						strEXPANDVASMEDICINE += m_lsvEXPANDVASMEDICINE.Items[i].SubItems[0].Text+
											"×"+m_lsvEXPANDVASMEDICINE.Items[i].SubItems[1].Text+
                                            "×" + m_lsvEXPANDVASMEDICINE.Items[i].SubItems[2].Text;
						if(i != m_lsvEXPANDVASMEDICINE.Items.Count-1)
							strEXPANDVASMEDICINE += "√";
					}
					objContent.m_strEXPANDVASMEDICINE =strEXPANDVASMEDICINE;
					objContent.m_strEXPANDVASMEDICINE_RIGHT = strEXPANDVASMEDICINE;
				}

				if(m_lsvCARDIACDIURESIS.Items.Count > 0)
				{
					string strCARDIACDIURESIS = "";
					for(int i=0; i<m_lsvCARDIACDIURESIS.Items.Count; i++)
					{
						strCARDIACDIURESIS += m_lsvCARDIACDIURESIS.Items[i].SubItems[0].Text+
							"×"+m_lsvCARDIACDIURESIS.Items[i].SubItems[1].Text+
                            "×"+m_lsvCARDIACDIURESIS.Items[i].SubItems[2].Text;
						if(i != m_lsvCARDIACDIURESIS.Items.Count-1)
							strCARDIACDIURESIS += "√";
					}
					objContent.m_strCARDIACDIURESIS = strCARDIACDIURESIS;
					objContent.m_strCARDIACDIURESIS_RIGHT = strCARDIACDIURESIS;
				}

				if(m_lsvOTHERMEDICINE.Items.Count > 0)
				{
					string strOTHERMEDICINE = "";
					for(int i=0; i<m_lsvOTHERMEDICINE.Items.Count; i++)
					{
						strOTHERMEDICINE += m_lsvOTHERMEDICINE.Items[i].SubItems[0].Text+
                            "×"+m_lsvOTHERMEDICINE.Items[i].SubItems[1].Text+
							"×"+m_lsvOTHERMEDICINE.Items[i].SubItems[2].Text;
						if(i != m_lsvOTHERMEDICINE.Items.Count-1)
							strOTHERMEDICINE += "√";
					}
					objContent.m_strOTHERMEDICINE = strOTHERMEDICINE;
					objContent.m_strOTHERMEDICINE_RIGHT = strOTHERMEDICINE;
				}

				objContent.m_strCONSCIOUSNESS_RIGHT = this.m_cboCONSCIOUSNESS.Text;
				objContent.m_strCONSCIOUSNESS = this.m_cboCONSCIOUSNESS.Text;
//				objContent.m_strCONSCIOUSNESS_RIGHT = this.m_txtCONSCIOUSNESS.m_strGetRightText();
//				objContent.m_strCONSCIOUSNESS = this.m_txtCONSCIOUSNESS.Text;
//				objContent.m_strCONSCIOUSNESSXML = this.m_txtCONSCIOUSNESS.m_strGetXmlText();

				objContent.m_strPUPIL_RIGHT = this.m_cboPUPIL.Text;
				objContent.m_strPUPIL = this.m_cboPUPIL.Text;
//				objContent.m_strPUPIL_RIGHT = this.m_txtPUPIL.m_strGetRightText();
//				objContent.m_strPUPIL = this.m_txtPUPIL.Text;
//				objContent.m_strPUPILXML = this.m_txtPUPIL.m_strGetXmlText();

				objContent.m_strLEFTPUPIL_RIGHT = this.m_cboLEFTPUPIL.Text;
				objContent.m_strLEFTPUPIL = this.m_cboLEFTPUPIL.Text;
//				objContent.m_strLEFTPUPIL_RIGHT = this.m_txtLEFTPUPIL.m_strGetRightText();
//				objContent.m_strLEFTPUPIL = this.m_txtLEFTPUPIL.Text;
//				objContent.m_strLEFTPUPILXML = this.m_txtLEFTPUPIL.m_strGetXmlText();

				objContent.m_strRIGHTPUPIL_RIGHT = this.m_cboRIGHTPUPIL.Text;
				objContent.m_strRIGHTPUPIL = this.m_cboRIGHTPUPIL.Text;
//				objContent.m_strRIGHTPUPIL_RIGHT = this.m_txtRIGHTPUPIL.m_strGetRightText();
//				objContent.m_strRIGHTPUPIL = this.m_txtRIGHTPUPIL.Text;
//				objContent.m_strRIGHTPUPILXML = this.m_txtRIGHTPUPIL.m_strGetXmlText();

				objContent.m_strTEMPERATURE_RIGHT = this.m_txtTEMPERATURE.m_strGetRightText();
				objContent.m_strTEMPERATURE = this.m_txtTEMPERATURE.Text;
				objContent.m_strTEMPERATUREXML = this.m_txtTEMPERATURE.m_strGetXmlText();

                objContent.m_strTWIGTEMPERATURE_RIGHT = this.m_cboTWIGTEMPERATURE.Text;
                objContent.m_strTWIGTEMPERATURE = this.m_cboTWIGTEMPERATURE.Text;
                //objContent.m_strTWIGTEMPERATUREXML = this.m_cboTWIGTEMPERATURE.m_strGetXmlText();

                objContent.m_strHEARTRATE_RIGHT = this.m_cboHEARTRATE.Text;
				objContent.m_strHEARTRATE = this.m_cboHEARTRATE.Text;
                objContent.m_strHEARTRATEXML = this.m_cboHEARTRATE.Text;

                objContent.m_strHEARTRHYTHM_RIGHT = this.m_txtHEARTRHYTHM.m_strGetRightText();
                objContent.m_strHEARTRHYTHM = this.m_txtHEARTRHYTHM.Text;
                objContent.m_strHEARTRHYTHMXML = this.m_txtHEARTRHYTHM.m_strGetXmlText();

				objContent.m_strBPA_RIGHT = this.m_txtBPA.m_strGetRightText();
				objContent.m_strBPA = this.m_txtBPA.Text;
				objContent.m_strBPAXML = this.m_txtBPA.m_strGetXmlText();

				objContent.m_strBPS_RIGHT = this.m_txtBPS.m_strGetRightText();
				objContent.m_strBPS = this.m_txtBPS.Text;
				objContent.m_strBPSXML = this.m_txtBPS.m_strGetXmlText();

				objContent.m_strAVGBP_RIGHT = this.m_txtAVGBP.m_strGetRightText();
				objContent.m_strAVGBP = this.m_txtAVGBP.Text;
				objContent.m_strAVGBPXML = this.m_txtAVGBP.m_strGetXmlText();

				objContent.m_strCVP_RIGHT = this.m_txtCVP.m_strGetRightText();
				objContent.m_strCVP = this.m_txtCVP.Text;
				objContent.m_strCVPXML = this.m_txtCVP.m_strGetXmlText();

				objContent.m_strLAP_RIGHT = this.m_txtLAP.m_strGetRightText();
				objContent.m_strLAP = this.m_txtLAP.Text;
				objContent.m_strLAPXML = this.m_txtLAP.m_strGetXmlText();

                objContent.m_strSPO_RIGHT = this.m_txtSPO.m_strGetRightText();
                objContent.m_strSPO = this.m_txtSPO.Text;
                objContent.m_strSPOXML = this.m_txtSPO.m_strGetXmlText();

				objContent.m_strBREATHMACHINE_RIGHT = this.m_cboBREATHMACHINE.Text;
				objContent.m_strBREATHMACHINE = this.m_cboBREATHMACHINE.Text;
//				objContent.m_strBREATHMACHINE_RIGHT = this.m_txtBREATHMACHINE.m_strGetRightText();
//				objContent.m_strBREATHMACHINE = this.m_txtBREATHMACHINE.Text;
//				objContent.m_strBREATHMACHINEXML = this.m_txtBREATHMACHINE.m_strGetXmlText();

				objContent.m_strINSERTDEPTH_RIGHT = this.m_cboINSERTDEPTH.Text;
				objContent.m_strINSERTDEPTH = this.m_cboINSERTDEPTH.Text;
//				objContent.m_strINSERTDEPTH_RIGHT = this.m_txtINSERTDEPTH.m_strGetRightText();
//				objContent.m_strINSERTDEPTH = this.m_txtINSERTDEPTH.Text;
//				objContent.m_strINSERTDEPTHXML = this.m_txtINSERTDEPTH.m_strGetXmlText();

				objContent.m_strASSISTANT_RIGHT = this.m_cboASSISTANT.Text;
				objContent.m_strASSISTANT = this.m_cboASSISTANT.Text;
//				objContent.m_strASSISTANT_RIGHT = this.m_txtASSISTANT.m_strGetRightText();
//				objContent.m_strASSISTANT = this.m_txtASSISTANT.Text;
//				objContent.m_strASSISTANTXML = this.m_txtASSISTANT.m_strGetXmlText();

				objContent.m_strFIO2_RIGHT = this.m_txtFIO2.m_strGetRightText();
				objContent.m_strFIO2 = this.m_txtFIO2.Text;
				objContent.m_strFIO2XML = this.m_txtFIO2.m_strGetXmlText();

				objContent.m_strIE_RIGHT = this.m_txtIE.m_strGetRightText();
				objContent.m_strIE = this.m_txtIE.Text;
				objContent.m_strIEXML = this.m_txtIE.m_strGetXmlText();

				objContent.m_strINSPIRATION_RIGHT = this.m_cboINSPIRATION.Text;
				objContent.m_strINSPIRATION = this.m_cboINSPIRATION.Text;
//				objContent.m_strINSPIRATION_RIGHT = this.m_txtINSPIRATION.m_strGetRightText();
//				objContent.m_strINSPIRATION = this.m_txtINSPIRATION.Text;
//				objContent.m_strINSPIRATIONXML = this.m_txtINSPIRATION.m_strGetXmlText();

				objContent.m_strPEEP_RIGHT = this.m_txtPEEP.m_strGetRightText();
				objContent.m_strPEEP = this.m_txtPEEP.Text;
				objContent.m_strPEEPXML = this.m_txtPEEP.m_strGetXmlText();

				objContent.m_strTV_RIGHT = this.m_txtTV.m_strGetRightText();
				objContent.m_strTV = this.m_txtTV.Text;
				objContent.m_strTVXML = this.m_txtTV.m_strGetXmlText();

				objContent.m_strVF_RIGHT = this.m_txtVF.m_strGetRightText();
				objContent.m_strVF = this.m_txtVF.Text;
				objContent.m_strVFXML = this.m_txtVF.m_strGetXmlText();

				objContent.m_strBREATHTIMES_RIGHT = this.m_txtBREATHTIMES.m_strGetRightText();
				objContent.m_strBREATHTIMES = this.m_txtBREATHTIMES.Text;
				objContent.m_strBREATHTIMESXML = this.m_txtBREATHTIMES.m_strGetXmlText();

                objContent.m_strLEFTBREATHVOICE_RIGHT = this.m_cboLEFTBREATHVOICE.Text;
                objContent.m_strLEFTBREATHVOICE = this.m_cboLEFTBREATHVOICE.Text;
                //objContent.m_strLEFTBREATHVOICEXML = this.m_cboLEFTBREATHVOICE.m_strGetXmlText();

                objContent.m_strRIGHTBREATHVOICE_RIGHT = this.m_cboRIGHTBREATHVOICE.Text;
                objContent.m_strRIGHTBREATHVOICE = this.m_cboRIGHTBREATHVOICE.Text;
                //objContent.m_strRIGHTBREATHVOICEXML = this.m_cboRIGHTBREATHVOICE.m_strGetXmlText();

                objContent.m_strPHLEGMCOLOR_RIGHT = this.m_cboPHLEGMCOLOR.Text;
                objContent.m_strPHLEGMCOLOR = this.m_cboPHLEGMCOLOR.Text;
                //objContent.m_strPHLEGMCOLORXML = this.m_cboPHLEGMCOLOR.m_strGetXmlText();

                objContent.m_strPHLEGMQUANTITY_RIGHT = this.m_cboPHLEGMQUANTITY.Text;
                objContent.m_strPHLEGMQUANTITY = this.m_cboPHLEGMQUANTITY.Text;
                //objContent.m_strPHLEGMQUANTITYXML = this.m_cboPHLEGMQUANTITY.m_strGetXmlText();

                objContent.m_strGESTICULATION_RIGHT = this.m_cboGESTICULATION.Text;
                objContent.m_strGESTICULATION = this.m_cboGESTICULATION.Text;
                //objContent.m_strGESTICULATIONXML = this.m_cboGESTICULATION.m_strGetXmlText();

                objContent.m_strPHYSICALTHERAPY_RIGHT = this.m_cboPHYSICALTHERAPY.Text;
                objContent.m_strPHYSICALTHERAPY = this.m_cboPHYSICALTHERAPY.Text;
                //objContent.m_strPHYSICALTHERAPYXML = this.m_cboPHYSICALTHERAPY.m_strGetXmlText();

				objContent.m_strREMARK_RIGHT = this.m_txtREMARK.m_strGetRightText();
				objContent.m_strREMARK = this.m_txtREMARK.Text;
				objContent.m_strREMARKXML = this.m_txtREMARK.m_strGetXmlText();

				objContent.m_strWBC_RIGHT = this.m_txtWBC.m_strGetRightText();
				objContent.m_strWBC = this.m_txtWBC.Text;
				objContent.m_strWBCXML = this.m_txtWBC.m_strGetXmlText();

				objContent.m_strHB_RIGHT = this.m_txtHB.m_strGetRightText();
				objContent.m_strHB = this.m_txtHB.Text;
				objContent.m_strHBXML = this.m_txtHB.m_strGetXmlText();

				objContent.m_strRBC_RIGHT = this.m_txtRBC.m_strGetRightText();
				objContent.m_strRBC = this.m_txtRBC.Text;
				objContent.m_strRBCXML = this.m_txtRBC.m_strGetXmlText();

				objContent.m_strHCT_RIGHT = this.m_txtHCT.m_strGetRightText();
				objContent.m_strHCT = this.m_txtHCT.Text;
				objContent.m_strHCTXML = this.m_txtHCT.m_strGetXmlText();

				objContent.m_strPLT_RIGHT = this.m_txtPLT.m_strGetRightText();
				objContent.m_strPLT = this.m_txtPLT.Text;
				objContent.m_strPLTXML = this.m_txtPLT.m_strGetXmlText();

				objContent.m_strPH_RIGHT = this.m_txtPH.m_strGetRightText();
				objContent.m_strPH = this.m_txtPH.Text;
				objContent.m_strPHXML = this.m_txtPH.m_strGetXmlText();

				objContent.m_strPCO2_RIGHT = this.m_txtPCO2.m_strGetRightText();
				objContent.m_strPCO2 = this.m_txtPCO2.Text;
				objContent.m_strPCO2XML = this.m_txtPCO2.m_strGetXmlText();

				objContent.m_strPAO2_RIGHT = this.m_txtPAO2.m_strGetRightText();
				objContent.m_strPAO2 = this.m_txtPAO2.Text;
				objContent.m_strPAO2XML = this.m_txtPAO2.m_strGetXmlText();

				objContent.m_strHCO3_RIGHT = this.m_txtHCO3.m_strGetRightText();
				objContent.m_strHCO3 = this.m_txtHCO3.Text;
				objContent.m_strHCO3XML = this.m_txtHCO3.m_strGetXmlText();

				objContent.m_strBE_RIGHT = this.m_txtBE.m_strGetRightText();
				objContent.m_strBE = this.m_txtBE.Text;
				objContent.m_strBEXML = this.m_txtBE.m_strGetXmlText();

				objContent.m_strKPLUS_RIGHT = this.m_txtKPLUS.m_strGetRightText();
				objContent.m_strKPLUS = this.m_txtKPLUS.Text;
				objContent.m_strKPLUSXML = this.m_txtKPLUS.m_strGetXmlText();

				objContent.m_strNAPLUS_RIGHT = this.m_txtNAPLUS.m_strGetRightText();
				objContent.m_strNAPLUS = this.m_txtNAPLUS.Text;
				objContent.m_strNAPLUSXML = this.m_txtNAPLUS.m_strGetXmlText();

				objContent.m_strCISUB_RIGHT = this.m_txtCISUB.m_strGetRightText();
				objContent.m_strCISUB = this.m_txtCISUB.Text;
				objContent.m_strCISUBXML = this.m_txtCISUB.m_strGetXmlText();

				objContent.m_strCAPLUSPLUS_RIGHT = this.m_txtCAPLUSPLUS.m_strGetRightText();
				objContent.m_strCAPLUSPLUS = this.m_txtCAPLUSPLUS.Text;
				objContent.m_strCAPLUSPLUSXML = this.m_txtCAPLUSPLUS.m_strGetXmlText();

				objContent.m_strGLU_RIGHT = this.m_txtGLU.m_strGetRightText();
				objContent.m_strGLU = this.m_txtGLU.Text;
				objContent.m_strGLUXML = this.m_txtGLU.m_strGetXmlText();

				objContent.m_strBUN_RIGHT = this.m_txtBUN.m_strGetRightText();
				objContent.m_strBUN = this.m_txtBUN.Text;
				objContent.m_strBUNXML = this.m_txtBUN.m_strGetXmlText();

				objContent.m_strUA_RIGHT = this.m_txtUA.m_strGetRightText();
				objContent.m_strUA = this.m_txtUA.Text;
				objContent.m_strUAXML = this.m_txtUA.m_strGetXmlText();

				objContent.m_strANHYDRIDE_RIGHT = this.m_txtANHYDRIDE.m_strGetRightText();
				objContent.m_strANHYDRIDE = this.m_txtANHYDRIDE.Text;
				objContent.m_strANHYDRIDEXML = this.m_txtANHYDRIDE.m_strGetXmlText();

				objContent.m_strCO2CP_RIGHT = this.m_txtCO2CP.m_strGetRightText();
				objContent.m_strCO2CP = this.m_txtCO2CP.Text;
				objContent.m_strCO2CPXML = this.m_txtCO2CP.m_strGetXmlText();

				objContent.m_strPT_RIGHT = this.m_txtPT.m_strGetRightText();
				objContent.m_strPT = this.m_txtPT.Text;
				objContent.m_strPTXML = this.m_txtPT.m_strGetXmlText();

				objContent.m_strXRAYCHECK_RIGHT = this.m_txtXRAYCHECK.m_strGetRightText();
				objContent.m_strXRAYCHECK = this.m_txtXRAYCHECK.Text;
				objContent.m_strXRAYCHECKXML = this.m_txtXRAYCHECK.m_strGetXmlText();

				objContent.m_strACT_RIGHT = this.m_txtACT.m_strGetRightText();
				objContent.m_strACT = this.m_txtACT.Text;
				objContent.m_strACTXML = this.m_txtACT.m_strGetXmlText();

				objContent.m_strPROPORTION_RIGHT = this.m_txtPROPORTION.m_strGetRightText();
				objContent.m_strPROPORTION = this.m_txtPROPORTION.Text;
				objContent.m_strPROPORTIONXML = this.m_txtPROPORTION.m_strGetXmlText();

				objContent.m_strALBUMEN_RIGHT = this.m_cboALBUMEN.Text;
				objContent.m_strALBUMEN = this.m_cboALBUMEN.Text;
//				objContent.m_strALBUMEN_RIGHT = this.m_txtALBUMEN.m_strGetRightText();
//				objContent.m_strALBUMEN = this.m_txtALBUMEN.Text;
//				objContent.m_strALBUMENXML = this.m_txtALBUMEN.m_strGetXmlText();

				objContent.m_strHIDDENBLOOD_RIGHT = this.m_cboHIDDENBLOOD.Text;
				objContent.m_strHIDDENBLOOD = this.m_cboHIDDENBLOOD.Text;
//				objContent.m_strHIDDENBLOOD_RIGHT = this.m_txtHIDDENBLOOD.m_strGetRightText();
//				objContent.m_strHIDDENBLOOD = this.m_txtHIDDENBLOOD.Text;
//				objContent.m_strHIDDENBLOODXML = this.m_txtHIDDENBLOOD.m_strGetXmlText();

				objContent.m_strSKIN_RIGHT = this.m_cboSKIN.Text;
				objContent.m_strSKIN = this.m_cboSKIN.Text;
//				objContent.m_strSKIN_RIGHT = this.m_txtSKIN.m_strGetRightText();
//				objContent.m_strSKIN = this.m_txtSKIN.Text;
//				objContent.m_strSKINXML = this.m_txtSKIN.m_strGetXmlText();

				objContent.m_strWASHPERINEUM_RIGHT = this.m_cboWASHPERINEUM.Text;
				objContent.m_strWASHPERINEUM = this.m_cboWASHPERINEUM.Text;
//				objContent.m_strWASHPERINEUM_RIGHT = this.m_txtWASHPERINEUM.m_strGetRightText();
//				objContent.m_strWASHPERINEUM = this.m_txtWASHPERINEUM.Text;
//				objContent.m_strWASHPERINEUMXML = this.m_txtWASHPERINEUM.m_strGetXmlText();

				objContent.m_strBRUSHBATH_RIGHT = this.m_cboBRUSHBATH.Text;
				objContent.m_strBRUSHBATH = this.m_cboBRUSHBATH.Text;
//				objContent.m_strBRUSHBATH_RIGHT = this.m_txtBRUSHBATH.m_strGetRightText();
//				objContent.m_strBRUSHBATH = this.m_txtBRUSHBATH.Text;
//				objContent.m_strBRUSHBATHXML = this.m_txtBRUSHBATH.m_strGetXmlText();

				objContent.m_strMOUTHTEND_RIGHT = this.m_cboMOUTHTEND.Text;
				objContent.m_strMOUTHTEND = this.m_cboMOUTHTEND.Text;
//				objContent.m_strMOUTHTEND_RIGHT = this.m_txtMOUTHTEND.m_strGetRightText();
//				objContent.m_strMOUTHTEND = this.m_txtMOUTHTEND.Text;
//				objContent.m_strMOUTHTENDXML = this.m_txtMOUTHTEND.m_strGetXmlText();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			#endregion
			return(objContent );		
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsCardiovascularTend_GX objContent=(clsCardiovascularTend_GX )p_objContent;

			this.m_mthClearRecordInfo();

			#region 把表单值赋值到界面
			this.m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
			this.m_txtINFACT1.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINFACT1, objContent.m_strINFACT1XML);
			this.m_txtINFACT2.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINFACT2, objContent.m_strINFACT2XML);
			this.m_txtINFACT3.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINFACT3, objContent.m_strINFACT3XML);
			this.m_txtINFACT4.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINFACT4, objContent.m_strINFACT4XML);
			this.m_txtINFACT5.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINFACT5, objContent.m_strINFACT5XML);
			this.m_txtINBLOOD.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINBLOOD, objContent.m_strINBLOODXML);
			this.m_txtINPERHOUR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINPERHOUR, objContent.m_strINPERHOURXML);
			this.m_txtINSUM.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINSUM, objContent.m_strINSUMXML);
			this.m_txtOUTSUM.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTSUM, objContent.m_strOUTSUMXML);
			this.m_txtOUTPERHOUR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTPERHOUR, objContent.m_strOUTPERHOURXML);
			this.m_txtOUTFACTPISSSUM.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTFACTPISSSUM, objContent.m_strOUTFACTPISSSUMXML);
			this.m_txtOUTFACTPISS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTFACTPISS, objContent.m_strOUTFACTPISSXML);
			this.m_txtOUTFACTCHESTJUICE.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTFACTCHESTJUICE, objContent.m_strOUTFACTCHESTJUICEXML);
			this.m_txtOUTFACTCHESTJUICESUM.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTFACTCHESTJUICESUM, objContent.m_strOUTFACTCHESTJUICESUMXML);
			this.m_txtOUTFACTGASTRICJUICE.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTFACTGASTRICJUICE, objContent.m_strOUTFACTGASTRICJUICEXML);

			if(objContent.m_strEXPANDVASMEDICINE != null && objContent.m_strEXPANDVASMEDICINE != "")
			{
				string[] strExpArr = objContent.m_strEXPANDVASMEDICINE.Split('√');
				ListViewItem item = null;
				string[] strConArr = null;
				for(int i=0; i<strExpArr.Length; i++)
				{
					strConArr = strExpArr[i].Split('×');
                    //数据连接
                    if (strConArr.Length == 2)
                    {
                        item = new ListViewItem(new string[] { strConArr[0],"", strConArr[1] });
                    }
                    else
                    {
                        item = new ListViewItem(new string[] { strConArr[0], strConArr[1], strConArr[2] });
                    }
                    
					m_lsvEXPANDVASMEDICINE.Items.Add(item);
				}
			}

			if(objContent.m_strCARDIACDIURESIS != null && objContent.m_strCARDIACDIURESIS != "")
			{
				string[] strExpArr = objContent.m_strCARDIACDIURESIS.Split('√');
				ListViewItem item = null;
				string[] strConArr = null;
				for(int i=0; i<strExpArr.Length; i++)
				{
					strConArr = strExpArr[i].Split('×');
                    //数据连接
                    if (strConArr.Length == 2)
                    {
                        item = new ListViewItem(new string[] { strConArr[0], "", strConArr[1] });
                    }
                    else
                    {
                        item = new ListViewItem(new string[] { strConArr[0], strConArr[1], strConArr[2] });
                    }
					m_lsvCARDIACDIURESIS.Items.Add(item);
				}
			}

			if(objContent.m_strOTHERMEDICINE != null && objContent.m_strOTHERMEDICINE != "")
			{
				string[] strExpArr = objContent.m_strOTHERMEDICINE.Split('√');
				ListViewItem item = null;
				string[] strConArr = null;
				for(int i=0; i<strExpArr.Length; i++)
				{
					strConArr = strExpArr[i].Split('×');
                    if (strConArr.Length == 2)
                    {
                        item = new ListViewItem(new string[] { strConArr[0], "", strConArr[1] });
                    }
                    else
                    {
                        item = new ListViewItem(new string[] { strConArr[0], strConArr[1], strConArr[2] });
                    }
					m_lsvOTHERMEDICINE.Items.Add(item);
				}
			}

			this.m_cboCONSCIOUSNESS.Text = objContent.m_strCONSCIOUSNESS;
//			this.m_txtCONSCIOUSNESS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCONSCIOUSNESS, objContent.m_strCONSCIOUSNESSXML);
			this.m_cboPUPIL.Text = objContent.m_strPUPIL;
//			this.m_txtPUPIL.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPUPIL, objContent.m_strPUPILXML);
			this.m_cboLEFTPUPIL.Text = objContent.m_strLEFTPUPIL;
//			this.m_txtLEFTPUPIL.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strLEFTPUPIL, objContent.m_strLEFTPUPILXML);
			this.m_cboRIGHTPUPIL.Text = objContent.m_strRIGHTPUPIL;
//			this.m_txtRIGHTPUPIL.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strRIGHTPUPIL, objContent.m_strRIGHTPUPILXML);
			this.m_txtTEMPERATURE.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strTEMPERATURE, objContent.m_strTEMPERATUREXML);
			this.m_cboTWIGTEMPERATURE.Text=objContent.m_strTEMPERATURE_RIGHT;
            this.m_cboHEARTRATE.Text = objContent.m_strHEARTRATE;
            this.m_txtHEARTRHYTHM.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strHEARTRHYTHM, objContent.m_strHEARTRHYTHMXML);  
			this.m_txtBPA.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBPA, objContent.m_strBPAXML);
			this.m_txtBPS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBPS, objContent.m_strBPSXML);
			this.m_txtAVGBP.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strAVGBP, objContent.m_strAVGBPXML);
			this.m_txtCVP.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCVP, objContent.m_strCVPXML);
			this.m_txtLAP.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strLAP, objContent.m_strLAPXML);
            this.m_txtSPO.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strSPO, objContent.m_strSPOXML);

			this.m_cboBREATHMACHINE.Text = objContent.m_strBREATHMACHINE;
//			this.m_txtBREATHMACHINE.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBREATHMACHINE, objContent.m_strBREATHMACHINEXML);
			this.m_cboINSERTDEPTH.Text = objContent.m_strINSERTDEPTH;
//			this.m_txtINSERTDEPTH.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINSERTDEPTH, objContent.m_strINSERTDEPTHXML);
			this.m_cboASSISTANT.Text = objContent.m_strASSISTANT;
//			this.m_txtASSISTANT.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strASSISTANT, objContent.m_strASSISTANTXML);
			this.m_txtFIO2.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strFIO2, objContent.m_strFIO2XML);
			this.m_txtIE.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strIE, objContent.m_strIEXML);
			this.m_cboINSPIRATION.Text = objContent.m_strINSPIRATION;
//			this.m_txtINSPIRATION.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINSPIRATION, objContent.m_strINSPIRATIONXML);
			this.m_txtPEEP.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPEEP, objContent.m_strPEEPXML);
			this.m_txtTV.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strTV, objContent.m_strTVXML);
			this.m_txtVF.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strVF, objContent.m_strVFXML);
			this.m_txtBREATHTIMES.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBREATHTIMES, objContent.m_strBREATHTIMESXML);
			this.m_cboLEFTBREATHVOICE.Text=objContent.m_strLEFTBREATHVOICE_RIGHT;
			this.m_cboRIGHTBREATHVOICE.Text=objContent.m_strRIGHTBREATHVOICE_RIGHT;
			this.m_cboPHLEGMCOLOR.Text=objContent.m_strPHLEGMCOLOR_RIGHT;
			this.m_cboPHLEGMQUANTITY.Text=objContent.m_strPHLEGMQUANTITY_RIGHT;
			this.m_cboGESTICULATION.Text=objContent.m_strGESTICULATION_RIGHT;
			this.m_cboPHYSICALTHERAPY.Text=objContent.m_strPHYSICALTHERAPY_RIGHT;
			this.m_txtREMARK.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strREMARK, objContent.m_strREMARKXML);
			this.m_txtWBC.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strWBC, objContent.m_strWBCXML);
			this.m_txtHB.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strHB, objContent.m_strHBXML);
			this.m_txtRBC.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strRBC, objContent.m_strRBCXML);
			this.m_txtHCT.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strHCT, objContent.m_strHCTXML);
			this.m_txtPLT.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPLT, objContent.m_strPLTXML);
			this.m_txtPH.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPH, objContent.m_strPHXML);
			this.m_txtPCO2.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPCO2, objContent.m_strPCO2XML);
			this.m_txtPAO2.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPAO2, objContent.m_strPAO2XML);
			this.m_txtHCO3.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strHCO3, objContent.m_strHCO3XML);
			this.m_txtBE.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBE, objContent.m_strBEXML);
			this.m_txtKPLUS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strKPLUS, objContent.m_strKPLUSXML);
			this.m_txtNAPLUS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strNAPLUS, objContent.m_strNAPLUSXML);
			this.m_txtCISUB.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCISUB, objContent.m_strCISUBXML);
			this.m_txtCAPLUSPLUS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCAPLUSPLUS, objContent.m_strCAPLUSPLUSXML);
			this.m_txtGLU.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strGLU, objContent.m_strGLUXML);
			this.m_txtBUN.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBUN, objContent.m_strBUNXML);
			this.m_txtUA.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strUA, objContent.m_strUAXML);
			this.m_txtANHYDRIDE.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strANHYDRIDE, objContent.m_strANHYDRIDEXML);
			this.m_txtCO2CP.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCO2CP, objContent.m_strCO2CPXML);
			this.m_txtPT.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPT, objContent.m_strPTXML);
			this.m_txtXRAYCHECK.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strXRAYCHECK, objContent.m_strXRAYCHECKXML);
			this.m_txtACT.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strACT, objContent.m_strACTXML);
			this.m_txtPROPORTION.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPROPORTION, objContent.m_strPROPORTIONXML);
			this.m_cboALBUMEN.Text = objContent.m_strALBUMEN;
//			this.m_txtALBUMEN.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strALBUMEN, objContent.m_strALBUMENXML);
			this.m_cboHIDDENBLOOD.Text = objContent.m_strHIDDENBLOOD;
//			this.m_txtHIDDENBLOOD.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strHIDDENBLOOD, objContent.m_strHIDDENBLOODXML);
			this.m_cboSKIN.Text = objContent.m_strSKIN;
//			this.m_txtSKIN.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strSKIN, objContent.m_strSKINXML);
			this.m_cboWASHPERINEUM.Text = objContent.m_strWASHPERINEUM;
//			this.m_txtWASHPERINEUM.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strWASHPERINEUM, objContent.m_strWASHPERINEUMXML);
			this.m_cboBRUSHBATH.Text = objContent.m_strBRUSHBATH;
//			this.m_txtBRUSHBATH.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBRUSHBATH, objContent.m_strBRUSHBATHXML);
			this.m_cboMOUTHTEND.Text = objContent.m_strMOUTHTEND;
//			this.m_txtMOUTHTEND.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strMOUTHTEND, objContent.m_strMOUTHTENDXML);
			#endregion
			this.m_dtpCreateDate.Enabled = false;
		}

		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsCardiovascularTend_GX objContent=(clsCardiovascularTend_GX )p_objContent;
						
			this.m_mthClearRecordInfo();

			#region 把表单值赋值到界面
			this.m_txtINFACT1.m_mthSetNewText(objContent.m_strINFACT1, objContent.m_strINFACT1XML);
			this.m_txtINFACT2.m_mthSetNewText(objContent.m_strINFACT2, objContent.m_strINFACT2XML);
			this.m_txtINFACT3.m_mthSetNewText(objContent.m_strINFACT3, objContent.m_strINFACT3XML);
			this.m_txtINFACT4.m_mthSetNewText(objContent.m_strINFACT4, objContent.m_strINFACT4XML);
			this.m_txtINFACT5.m_mthSetNewText(objContent.m_strINFACT5, objContent.m_strINFACT5XML);
			this.m_txtINBLOOD.m_mthSetNewText(objContent.m_strINBLOOD, objContent.m_strINBLOODXML);
			this.m_txtINPERHOUR.m_mthSetNewText(objContent.m_strINPERHOUR, objContent.m_strINPERHOURXML);
			this.m_txtINSUM.m_mthSetNewText(objContent.m_strINSUM, objContent.m_strINSUMXML);
			this.m_txtOUTSUM.m_mthSetNewText(objContent.m_strOUTSUM, objContent.m_strOUTSUMXML);
			this.m_txtOUTPERHOUR.m_mthSetNewText(objContent.m_strOUTPERHOUR, objContent.m_strOUTPERHOURXML);
			this.m_txtOUTFACTPISSSUM.m_mthSetNewText(objContent.m_strOUTFACTPISSSUM, objContent.m_strOUTFACTPISSSUMXML);
			this.m_txtOUTFACTPISS.m_mthSetNewText(objContent.m_strOUTFACTPISS, objContent.m_strOUTFACTPISSXML);
			this.m_txtOUTFACTCHESTJUICE.m_mthSetNewText(objContent.m_strOUTFACTCHESTJUICE, objContent.m_strOUTFACTCHESTJUICEXML);
			this.m_txtOUTFACTCHESTJUICESUM.m_mthSetNewText(objContent.m_strOUTFACTCHESTJUICESUM, objContent.m_strOUTFACTCHESTJUICESUMXML);
			this.m_txtOUTFACTGASTRICJUICE.m_mthSetNewText(objContent.m_strOUTFACTGASTRICJUICE, objContent.m_strOUTFACTGASTRICJUICEXML);

			if(objContent.m_strEXPANDVASMEDICINE != null && objContent.m_strEXPANDVASMEDICINE != "")
			{
				string[] strExpArr = objContent.m_strEXPANDVASMEDICINE.Split('√');
				ListViewItem item = null;
				string[] strConArr = null;
				for(int i=0; i<strExpArr.Length; i++)
				{
					strConArr = strExpArr[i].Split('×');
                    //数据连接
                    if (strConArr.Length == 2)
                    {
                        item = new ListViewItem(new string[] { strConArr[0], "", strConArr[1] });
                    }
                    else
                    {
                        item = new ListViewItem(new string[] { strConArr[0], strConArr[1], strConArr[2] });
                    }
					
                 
					m_lsvEXPANDVASMEDICINE.Items.Add(item);
				}
			}

			if(objContent.m_strCARDIACDIURESIS != null && objContent.m_strCARDIACDIURESIS != "")
			{
				string[] strExpArr = objContent.m_strCARDIACDIURESIS.Split('√');
				ListViewItem item = null;
				string[] strConArr = null;
				for(int i=0; i<strExpArr.Length; i++)
				{
					strConArr = strExpArr[i].Split('×');
                    //数据连接
                    if (strConArr.Length == 2)
                    {
                        item = new ListViewItem(new string[] { strConArr[0], "", strConArr[1] });
                    }
                    else
                    {
                        item = new ListViewItem(new string[] { strConArr[0], strConArr[1], strConArr[2] });
                    }
					
					m_lsvCARDIACDIURESIS.Items.Add(item);
				}
			}

			if(objContent.m_strOTHERMEDICINE != null && objContent.m_strOTHERMEDICINE != "")
			{
				string[] strExpArr = objContent.m_strOTHERMEDICINE.Split('√');
				ListViewItem item = null;
				string[] strConArr = null;
				for(int i=0; i<strExpArr.Length; i++)
				{
					strConArr = strExpArr[i].Split('×');
                    //数据连接
                    if (strConArr.Length == 2)
                    {
                        item = new ListViewItem(new string[] { strConArr[0], "", strConArr[1] });
                    }
                    else
                    {
                        item = new ListViewItem(new string[] { strConArr[0], strConArr[1], strConArr[2] });
                    }
					m_lsvOTHERMEDICINE.Items.Add(item);
				}
			}

			this.m_cboCONSCIOUSNESS.Text = objContent.m_strCONSCIOUSNESS;
//			this.m_txtCONSCIOUSNESS.m_mthSetNewText(objContent.m_strCONSCIOUSNESS, objContent.m_strCONSCIOUSNESSXML);
			this.m_cboPUPIL.Text = objContent.m_strPUPIL;
//			this.m_txtPUPIL.m_mthSetNewText(objContent.m_strPUPIL, objContent.m_strPUPILXML);
			this.m_cboLEFTPUPIL.Text = objContent.m_strLEFTPUPIL;			
//			this.m_txtLEFTPUPIL.m_mthSetNewText(objContent.m_strLEFTPUPIL, objContent.m_strLEFTPUPILXML);
			this.m_cboRIGHTPUPIL.Text = objContent.m_strRIGHTPUPIL;
//			this.m_txtRIGHTPUPIL.m_mthSetNewText(objContent.m_strRIGHTPUPIL, objContent.m_strRIGHTPUPILXML);
			this.m_txtTEMPERATURE.m_mthSetNewText(objContent.m_strTEMPERATURE, objContent.m_strTEMPERATUREXML);
			this.m_cboTWIGTEMPERATURE.Text=objContent.m_strTWIGTEMPERATURE_RIGHT;
            this.m_cboHEARTRATE.Text = objContent.m_strHEARTRATE_RIGHT;
			this.m_txtHEARTRHYTHM.m_mthSetNewText(objContent.m_strHEARTRHYTHM, objContent.m_strHEARTRHYTHMXML);
			this.m_txtBPA.m_mthSetNewText(objContent.m_strBPA, objContent.m_strBPAXML);
			this.m_txtBPS.m_mthSetNewText(objContent.m_strBPS, objContent.m_strBPSXML);
			this.m_txtAVGBP.m_mthSetNewText(objContent.m_strAVGBP, objContent.m_strAVGBPXML);
			this.m_txtCVP.m_mthSetNewText(objContent.m_strCVP, objContent.m_strCVPXML);
			this.m_txtLAP.m_mthSetNewText(objContent.m_strLAP, objContent.m_strLAPXML);
            this.m_txtSPO.m_mthSetNewText(objContent.m_strSPO, objContent.m_strSPOXML);
			this.m_cboBREATHMACHINE.Text = objContent.m_strBREATHMACHINE;
//			this.m_txtBREATHMACHINE.m_mthSetNewText(objContent.m_strBREATHMACHINE, objContent.m_strBREATHMACHINEXML);
			this.m_cboINSERTDEPTH.Text = objContent.m_strINSERTDEPTH;
//			this.m_txtINSERTDEPTH.m_mthSetNewText(objContent.m_strINSERTDEPTH, objContent.m_strINSERTDEPTHXML);
			this.m_cboASSISTANT.Text = objContent.m_strASSISTANT;
//			this.m_txtASSISTANT.m_mthSetNewText(objContent.m_strASSISTANT, objContent.m_strASSISTANTXML);
			this.m_txtFIO2.m_mthSetNewText(objContent.m_strFIO2, objContent.m_strFIO2XML);
			this.m_txtIE.m_mthSetNewText(objContent.m_strIE, objContent.m_strIEXML);
			this.m_cboINSPIRATION.Text = objContent.m_strINSPIRATION;
//			this.m_txtINSPIRATION.m_mthSetNewText(objContent.m_strINSPIRATION, objContent.m_strINSPIRATIONXML);
			this.m_txtPEEP.m_mthSetNewText(objContent.m_strPEEP, objContent.m_strPEEPXML);
			this.m_txtTV.m_mthSetNewText(objContent.m_strTV, objContent.m_strTVXML);
			this.m_txtVF.m_mthSetNewText(objContent.m_strVF, objContent.m_strVFXML);
			this.m_txtBREATHTIMES.m_mthSetNewText(objContent.m_strBREATHTIMES, objContent.m_strBREATHTIMESXML);
			this.m_cboLEFTBREATHVOICE.Text=objContent.m_strLEFTBREATHVOICE_RIGHT;
            this.m_cboRIGHTBREATHVOICE.Text=objContent.m_strRIGHTBREATHVOICE_RIGHT;
            this.m_cboPHLEGMCOLOR.Text=objContent.m_strPHLEGMCOLOR_RIGHT;
            this.m_cboPHLEGMQUANTITY.Text=objContent.m_strPHLEGMQUANTITY_RIGHT;
            this.m_cboGESTICULATION.Text=objContent.m_strGESTICULATION_RIGHT;
            this.m_cboPHYSICALTHERAPY.Text=objContent.m_strPHYSICALTHERAPY_RIGHT;
			this.m_txtREMARK.m_mthSetNewText(objContent.m_strREMARK, objContent.m_strREMARKXML);
			this.m_txtWBC.m_mthSetNewText(objContent.m_strWBC, objContent.m_strWBCXML);
			this.m_txtHB.m_mthSetNewText(objContent.m_strHB, objContent.m_strHBXML);
			this.m_txtRBC.m_mthSetNewText(objContent.m_strRBC, objContent.m_strRBCXML);
			this.m_txtHCT.m_mthSetNewText(objContent.m_strHCT, objContent.m_strHCTXML);
			this.m_txtPLT.m_mthSetNewText(objContent.m_strPLT, objContent.m_strPLTXML);
			this.m_txtPH.m_mthSetNewText(objContent.m_strPH, objContent.m_strPHXML);
			this.m_txtPCO2.m_mthSetNewText(objContent.m_strPCO2, objContent.m_strPCO2XML);
			this.m_txtPAO2.m_mthSetNewText(objContent.m_strPAO2, objContent.m_strPAO2XML);
			this.m_txtHCO3.m_mthSetNewText(objContent.m_strHCO3, objContent.m_strHCO3XML);
			this.m_txtBE.m_mthSetNewText(objContent.m_strBE, objContent.m_strBEXML);
			this.m_txtKPLUS.m_mthSetNewText(objContent.m_strKPLUS, objContent.m_strKPLUSXML);
			this.m_txtNAPLUS.m_mthSetNewText(objContent.m_strNAPLUS, objContent.m_strNAPLUSXML);
			this.m_txtCISUB.m_mthSetNewText(objContent.m_strCISUB, objContent.m_strCISUBXML);
			this.m_txtCAPLUSPLUS.m_mthSetNewText(objContent.m_strCAPLUSPLUS, objContent.m_strCAPLUSPLUSXML);
			this.m_txtGLU.m_mthSetNewText(objContent.m_strGLU, objContent.m_strGLUXML);
			this.m_txtBUN.m_mthSetNewText(objContent.m_strBUN, objContent.m_strBUNXML);
			this.m_txtUA.m_mthSetNewText(objContent.m_strUA, objContent.m_strUAXML);
			this.m_txtANHYDRIDE.m_mthSetNewText(objContent.m_strANHYDRIDE, objContent.m_strANHYDRIDEXML);
			this.m_txtCO2CP.m_mthSetNewText(objContent.m_strCO2CP, objContent.m_strCO2CPXML);
			this.m_txtPT.m_mthSetNewText(objContent.m_strPT, objContent.m_strPTXML);
			this.m_txtXRAYCHECK.m_mthSetNewText(objContent.m_strXRAYCHECK, objContent.m_strXRAYCHECKXML);
			this.m_txtACT.m_mthSetNewText(objContent.m_strACT, objContent.m_strACTXML);
			this.m_txtPROPORTION.m_mthSetNewText(objContent.m_strPROPORTION, objContent.m_strPROPORTIONXML);
			this.m_cboALBUMEN.Text = objContent.m_strALBUMEN;
//			this.m_txtALBUMEN.m_mthSetNewText(objContent.m_strALBUMEN, objContent.m_strALBUMENXML);
			this.m_cboHIDDENBLOOD.Text = objContent.m_strHIDDENBLOOD;
//			this.m_txtHIDDENBLOOD.m_mthSetNewText(objContent.m_strHIDDENBLOOD, objContent.m_strHIDDENBLOODXML);
			this.m_cboSKIN.Text = objContent.m_strSKIN;
//			this.m_txtSKIN.m_mthSetNewText(objContent.m_strSKIN, objContent.m_strSKINXML);
			this.m_cboWASHPERINEUM.Text = objContent.m_strWASHPERINEUM;
//			this.m_txtWASHPERINEUM.m_mthSetNewText(objContent.m_strWASHPERINEUM, objContent.m_strWASHPERINEUMXML);
			this.m_cboBRUSHBATH.Text = objContent.m_strBRUSHBATH;
//			this.m_txtBRUSHBATH.m_mthSetNewText(objContent.m_strBRUSHBATH, objContent.m_strBRUSHBATHXML);
			this.m_cboMOUTHTEND.Text = objContent.m_strMOUTHTEND;
//			this.m_txtMOUTHTEND.m_mthSetNewText(objContent.m_strMOUTHTEND, objContent.m_strMOUTHTENDXML);
			#endregion

			this.m_dtpCreateDate.Enabled = false;
		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
			if(p_blnEnable==false)
			{
			
				m_cmdOK.Visible=true;
				
				this.CenterToParent();	
			}	
	
			this.MaximizeBox=false;
		}

		/// <summary>
		/// 具体记录的特殊控制,根据子窗体的需要重载实现
		/// </summary>
		/// <param name="p_blnEnable">是否允许修改特殊记录的记录信息。</param>
		protected override void m_mthEnableModifySub(bool p_blnEnable)
		{
		
		}	

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset">是否重置控制修改（修改留痕迹）。
		///如果为true，忽略记录内容，把界面控制设置为不控制；
		///否则根据记录内容进行设置。
		///</param>
		protected override void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
			bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制
			
		}

		public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsIntensiveRecordInfo objTrackInfo = new clsIntensiveRecordInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle =this.m_lblForTitle.Text;

			//设置m_dtmRecordTime
			if(objTrackInfo.m_ObjRecordContent !=null)
			{
				m_dtpCreateDate.Value=objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
			}
			return objTrackInfo;	
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//清空具体记录内容
		}

		#region 升压扩张血管药物 ListView操作
		private void m_cmdAddEXPANDVASMEDICINE_Click(object sender, System.EventArgs e)
		{
			if(m_cboEXPANDVASMEDICINE.Text.Trim() != "" && m_cboEXPANDVASMEDICINE.Text.Trim() != "")
			{
				ListViewItem item = new ListViewItem(new string[]{m_cboEXPANDVASMEDICINE.Text,this.m_txtEXPANDVASMEDICINEMethod.Text , m_txtEXPANDVASMEDICINENum.Text});
				m_lsvEXPANDVASMEDICINE.Items.Add(item);
				m_cboEXPANDVASMEDICINE.Text = "";
                this.m_txtEXPANDVASMEDICINEMethod.Text = "";
				m_txtEXPANDVASMEDICINENum.Text = "";
			}
		}

		private void m_cmdRemoveEXPANDVASMEDICINE_Click(object sender, System.EventArgs e)
		{
			if(m_lsvEXPANDVASMEDICINE.SelectedItems.Count> 0)
				m_lsvEXPANDVASMEDICINE.SelectedItems[0].Remove();
		}
		#endregion

		#region 强心利尿 ListView操作
		private void m_cmdAddCARDIACDIURESIS_Click(object sender, System.EventArgs e)
		{
			if(m_cboCARDIACDIURESIS.Text.Trim() != "" && m_cboCARDIACDIURESIS.Text.Trim() != "")
			{                                            
				ListViewItem item = new ListViewItem(new string[]{m_cboCARDIACDIURESIS.Text,this.m_txtCARDIACDIURESISMethod.Text , m_txtCARDIACDIURESISNum.Text});
				m_lsvCARDIACDIURESIS.Items.Add(item);
				m_cboCARDIACDIURESIS.Text = "";
                m_txtCARDIACDIURESISMethod.Text = "";
				m_txtCARDIACDIURESISNum.Text = "";
			}
		}

		private void m_cmdRemoveCARDIACDIURESIS_Click(object sender, System.EventArgs e)
		{
			if(m_lsvCARDIACDIURESIS.SelectedItems.Count > 0)
				m_lsvCARDIACDIURESIS.SelectedItems[0].Remove();
		}
		#endregion

		#region 其他药物 ListView操作
		private void m_cmdAddOTHERMEDICINE_Click(object sender, System.EventArgs e)
		{
			if(m_cboOTHERMEDICINE.Text.Trim() != "" && m_cboOTHERMEDICINE.Text.Trim() != "")
			{
				ListViewItem item = new ListViewItem(new string[]{m_cboOTHERMEDICINE.Text,m_txtOTHERMEDICINEMethod.Text, m_txtOTHERMEDICINENum.Text});
				m_lsvOTHERMEDICINE.Items.Add(item);
				m_cboOTHERMEDICINE.Text = "";
                m_txtOTHERMEDICINEMethod.Text = "";
				m_txtOTHERMEDICINENum.Text = "";
			}
		}

		private void m_cmdRemoveOTHERMEDICINE_Click(object sender, System.EventArgs e)
		{
			if(m_lsvOTHERMEDICINE.SelectedItems.Count > 0)
				m_lsvOTHERMEDICINE.SelectedItems[0].Remove();
		}
		#endregion

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.None;
			this.Close();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(m_dtmRecordTime.Date != m_dtpCreateDate.Value.Date)
			{
				string strMessageShow = @"此特护记录的日期与主窗体所示记录日期不同\r\n主窗体所示为"+m_dtmRecordTime.ToString("yyyy-MM-dd")+
										"\r\n此特护记录的日期为"+m_dtpCreateDate.Value.ToString("yyyy-MM-dd")+
										"\r\n是否继续保存？";
				MessageBoxButtons btnMessage = MessageBoxButtons.YesNo;
				DialogResult result = MessageBox.Show(strMessageShow, "！",btnMessage);
				if(result == DialogResult.No)
					return;
			}
			if (m_lngSave()>0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		private void frmCardiovascularTend_GX_Load(object sender, System.EventArgs e)
		{
			m_dtpCreateDate.Value = m_dtmRecordTime;
		}

		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtINFACT1,m_txtINFACT2,m_txtINFACT3,m_txtINFACT4,m_txtINFACT5,m_txtINBLOOD,m_txtINPERHOUR,
								 m_txtINSUM,m_txtOUTSUM,m_txtOUTPERHOUR,m_txtOUTFACTPISSSUM,m_txtOUTFACTPISS,m_txtOUTFACTCHESTJUICE,
								 m_txtOUTFACTCHESTJUICESUM,m_txtOUTFACTGASTRICJUICE,m_cboEXPANDVASMEDICINE,m_txtEXPANDVASMEDICINENum,
								 m_cboCARDIACDIURESIS,m_txtCARDIACDIURESISNum,m_cboOTHERMEDICINE,m_txtOTHERMEDICINENum,m_cboCONSCIOUSNESS,
								 m_cboPUPIL,m_cboLEFTPUPIL,m_cboRIGHTPUPIL,m_txtTEMPERATURE,m_cboTWIGTEMPERATURE,m_cboHEARTRATE,
								 m_txtHEARTRHYTHM,m_txtBPA,m_txtBPS,m_txtAVGBP,m_txtCVP,m_txtLAP,m_txtSPO,m_txtSPO,m_cboBREATHMACHINE,m_cboINSERTDEPTH,
								 m_cboASSISTANT,m_txtFIO2,m_txtIE,m_cboINSPIRATION,m_txtPEEP,m_txtTV,m_txtVF,m_txtBREATHTIMES,
								 m_cboLEFTBREATHVOICE,m_cboRIGHTBREATHVOICE,m_cboPHLEGMCOLOR,m_cboPHLEGMQUANTITY,m_cboGESTICULATION,
								 m_cboPHYSICALTHERAPY,m_txtREMARK,m_txtWBC,m_txtHB,m_txtRBC,m_txtHCT,m_txtPLT,m_txtPH,m_txtPCO2,m_txtPAO2,
								 m_txtHCO3,m_txtBE,m_txtKPLUS,m_txtNAPLUS,m_txtCISUB,m_txtCAPLUSPLUS,m_txtGLU,m_txtBUN,m_txtUA,
								 m_txtANHYDRIDE,m_txtCO2CP,m_txtPT,m_txtXRAYCHECK,m_txtACT,m_txtPROPORTION,m_cboALBUMEN,m_cboHIDDENBLOOD,
								 m_cboSKIN,m_cboWASHPERINEUM,m_cboBRUSHBATH,m_cboMOUTHTEND},Keys.Enter);
		}
		#endregion

        private void frmCardiovascularTend_GX_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    m_cmdAddEXPANDVASMEDICINE_Click(null, System.EventArgs.Empty);
                    break;
                case Keys.F2:
                    m_cmdRemoveEXPANDVASMEDICINE_Click(null, System.EventArgs.Empty);
                    break;
                case Keys.F3:
                    m_cmdAddCARDIACDIURESIS_Click(null, System.EventArgs.Empty);
                    break;
                case Keys.F4:
                    m_cmdRemoveCARDIACDIURESIS_Click(null, System.EventArgs.Empty);
                    break;
                case Keys.F5:
                    m_cmdAddOTHERMEDICINE_Click(null, System.EventArgs.Empty);
                    break;
                case Keys.F6:
                    m_cmdRemoveOTHERMEDICINE_Click(null, System.EventArgs.Empty);
                    break;
            }
        }
	}
}
