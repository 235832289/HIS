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
using com.digitalwave.Utility.Controls;
using PrivilegeData;
//using com.digitalwave.clsGeneralNurseRecord_GXS;
namespace iCare
{
	/// <summary>
	/// frmSurgeryICUWardshipEdit 的摘要说明。
	/// </summary>
	public class frmSurgeryICUWardshipEdit: frmDiseaseTrackBase
	{
		#region variable
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label9;
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
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label34;
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
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.Label label95;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.Label label97;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.Label label99;
		private System.Windows.Forms.Label label100;
		private System.Windows.Forms.Label label101;
		private System.Windows.Forms.Label label102;
		private System.Windows.Forms.Label label103;
		private System.Windows.Forms.Label label104;
		private System.Windows.Forms.Label label105;
		private System.Windows.Forms.Label label106;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.Label label107;
		private System.Windows.Forms.Label label109;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label label111;
		private System.Windows.Forms.Label label113;
		private System.Windows.Forms.Label label114;
		private System.Windows.Forms.Label label115;
		private System.Windows.Forms.Label label116;
		private System.Windows.Forms.Label label117;
		private System.Windows.Forms.Label label118;
		private System.Windows.Forms.Label label119;
		private System.Windows.Forms.Label label120;
		private System.Windows.Forms.Label label121;
		private System.Windows.Forms.Label label122;
		private System.Windows.Forms.Label label108;
		private System.Windows.Forms.Label label110;
		private System.Windows.Forms.Label label123;
		private System.Windows.Forms.Label label112;
		private System.Windows.Forms.Label label124;
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private com.digitalwave.controls.ctlRichTextBox m_txtPBODYPART;
		private com.digitalwave.controls.ctlRichTextBox m_txtPREFLECT;
		private com.digitalwave.controls.ctlRichTextBox m_txtPPUPIL;
		private com.digitalwave.controls.ctlRichTextBox m_txtPCONSCIOUSNESS;
		private com.digitalwave.controls.ctlRichTextBox m_txtCCVP;
		private com.digitalwave.controls.ctlRichTextBox m_txtCSD;
		private com.digitalwave.controls.ctlRichTextBox m_txtCHEARTRHYTHM;
		private com.digitalwave.controls.ctlRichTextBox m_txtCHEARTRATE;
		private com.digitalwave.controls.ctlRichTextBox m_txtCSMALLTEMPERATURE;
		private com.digitalwave.controls.ctlRichTextBox m_txtCTEMPERATURE;
		private com.digitalwave.controls.ctlRichTextBox m_txtDCURE8;
		private com.digitalwave.controls.ctlRichTextBox m_txtDPHYSIC8;
		private com.digitalwave.controls.ctlRichTextBox m_txtDCURE7;
		private com.digitalwave.controls.ctlRichTextBox m_txtDPHYSIC7;
		private com.digitalwave.controls.ctlRichTextBox m_txtDCURE6;
		private com.digitalwave.controls.ctlRichTextBox m_txtDPHYSIC6;
		private com.digitalwave.controls.ctlRichTextBox m_txtDCURE5;
		private com.digitalwave.controls.ctlRichTextBox m_txtDPHYSIC5;
		private com.digitalwave.controls.ctlRichTextBox m_txtDCURE4;
		private com.digitalwave.controls.ctlRichTextBox m_txtDPHYSIC4;
		private com.digitalwave.controls.ctlRichTextBox m_txtDCURE3;
		private com.digitalwave.controls.ctlRichTextBox m_txtDPHYSIC3;
		private com.digitalwave.controls.ctlRichTextBox m_txtDCURE2;
		private com.digitalwave.controls.ctlRichTextBox m_txtDPHYSIC2;
		private com.digitalwave.controls.ctlRichTextBox m_txtDCURE1;
		private com.digitalwave.controls.ctlRichTextBox m_txtDPHYSIC1;
		private com.digitalwave.controls.ctlRichTextBox m_txtINS;
		private com.digitalwave.controls.ctlRichTextBox m_txtIGS;
		private com.digitalwave.controls.ctlRichTextBox m_txtOGASTRICJUICE;
		private com.digitalwave.controls.ctlRichTextBox m_txtOEMIEMCTION;
		private com.digitalwave.controls.ctlRichTextBox m_txtOTATAL;
		private com.digitalwave.controls.ctlRichTextBox m_txtSESPECIALLYNOTE;
		private com.digitalwave.controls.ctlRichTextBox m_txtTO2CT;
		private com.digitalwave.controls.ctlRichTextBox m_txtTSAT;
		private com.digitalwave.controls.ctlRichTextBox m_txtTBE;
		private com.digitalwave.controls.ctlRichTextBox m_txtTTCO2;
		private com.digitalwave.controls.ctlRichTextBox m_txtTHCO3;
		private com.digitalwave.controls.ctlRichTextBox m_txtTP02;
		private com.digitalwave.controls.ctlRichTextBox m_txtTPCO2;
		private com.digitalwave.controls.ctlRichTextBox m_txtTPH;
		private com.digitalwave.controls.ctlRichTextBox m_txtTCOLLECTBLOODPOINT;
		private com.digitalwave.controls.ctlRichTextBox m_txtBSQ2;
		private com.digitalwave.controls.ctlRichTextBox m_txtBPHLEGMCOLOR;
		private com.digitalwave.controls.ctlRichTextBox m_txtBBLUSESOUND;
		private com.digitalwave.controls.ctlRichTextBox m_txtBMAXIP;
		private com.digitalwave.controls.ctlRichTextBox m_txtBFIO2PEEP;
		private com.digitalwave.controls.ctlRichTextBox m_txtBBLUSENUM;
		private com.digitalwave.controls.ctlRichTextBox m_txtBBLUESPRESSURE;
		private com.digitalwave.controls.ctlRichTextBox m_txtBEXPIREDMV;
		private com.digitalwave.controls.ctlRichTextBox m_txtBVT;
		private com.digitalwave.controls.ctlRichTextBox m_txtBBLUSEMODE;
		private com.digitalwave.controls.ctlRichTextBox m_txtBBLUSEMACHINETYPE;
		private com.digitalwave.controls.ctlRichTextBox m_txtBBLUSETIME;
		private com.digitalwave.controls.ctlRichTextBox m_txtSCOCI;
		private com.digitalwave.controls.ctlRichTextBox m_txtSWEDGE;
		private com.digitalwave.controls.ctlRichTextBox m_txtSMEAN;
		private com.digitalwave.controls.ctlRichTextBox m_txtSSD;
		private com.digitalwave.controls.ctlRichTextBox m_txtSCMH2O;
		private System.Windows.Forms.TextBox m_txtIDCode;
		private System.Windows.Forms.TextBox m_txtWeight;
		private System.Windows.Forms.TextBox m_txtOperationName;
		private System.Windows.Forms.Label label125;
		private System.Windows.Forms.DateTimePicker m_dtpOperationDate;
		private System.Windows.Forms.Label label126;
		private System.Windows.Forms.Label label127;
		private System.Windows.Forms.Label label128;
		private System.Windows.Forms.Label label129;
		private System.Windows.Forms.Label label130;
		private System.Windows.Forms.TextBox m_txtDATEAFTEROPERATION;
		private System.Windows.Forms.Label label131;
		private System.Windows.Forms.Label label132;
		private System.Windows.Forms.Label label133;
		private System.Windows.Forms.Label label134;
		private System.Windows.Forms.Label label135;
		private System.Windows.Forms.Label label136;
		private System.Windows.Forms.Label label137;
		private System.Windows.Forms.Label label138;
		private System.Windows.Forms.Label label140;
		private System.Windows.Forms.Label label142;
		private System.Windows.Forms.Label label144;
		private System.Windows.Forms.Label label146;
		private System.Windows.Forms.Label label139;
		private System.Windows.Forms.Label label143;
		private System.Windows.Forms.Label label145;
		private System.Windows.Forms.Label label147;
		private System.Windows.Forms.Label label148;
		private System.Windows.Forms.Label label149;
		private System.Windows.Forms.Label label150;
		private System.Windows.Forms.Label label141;
		private System.Windows.Forms.Label label151;
		private System.Windows.Forms.Label label152;
		private System.Windows.Forms.Label label153;
		private System.Windows.Forms.Label label154;
		private System.Windows.Forms.Label label155;
		private System.Windows.Forms.Label label156;
		private System.Windows.Forms.Label label157;
		private System.Windows.Forms.Label label158;
		private System.Windows.Forms.Label label159;
		private System.Windows.Forms.Label label160;
		private System.Windows.Forms.Label label162;
		private System.Windows.Forms.Label label161;
		private System.Windows.Forms.Label label163;
		private com.digitalwave.controls.ctlRichTextBox m_txtPREFLECTRIGHT;
		private com.digitalwave.controls.ctlRichTextBox m_txtPPUPLRIGHT;
		private com.digitalwave.controls.ctlRichTextBox m_txtINNAME2;
		private com.digitalwave.controls.ctlRichTextBox m_txtINAMOUNT2;
		private com.digitalwave.controls.ctlRichTextBox m_txtINNAME3;
		private com.digitalwave.controls.ctlRichTextBox m_txtINAMOUNT3;
		private com.digitalwave.controls.ctlRichTextBox m_txtINNAME4;
		private com.digitalwave.controls.ctlRichTextBox m_txtINAMOUNT4;
		private com.digitalwave.controls.ctlRichTextBox m_txtINTATAL;
		private com.digitalwave.controls.ctlRichTextBox m_txtINNAME1;
		private com.digitalwave.controls.ctlRichTextBox m_txtIBLOODPRO;
		private com.digitalwave.controls.ctlRichTextBox m_txtINAMOUNT1;
		private com.digitalwave.controls.ctlRichTextBox m_txtIBLOODPRODUCE;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTNAME4;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTAMOUNT4;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTNAME3;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTAMOUNT3;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTNAME2;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTAMOUNT2;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTNAME1;
		private com.digitalwave.controls.ctlRichTextBox m_txtOUTAMOUNT1;
		private com.digitalwave.controls.ctlRichTextBox m_txtBFI02PEEPRIGHT;
		private com.digitalwave.controls.ctlRichTextBox m_txtBPHLEGMAMOUNT;
		private System.Windows.Forms.Label label164;
		private System.Windows.Forms.Label label165;
		private System.Windows.Forms.Label label166;
		private System.Windows.Forms.Label label167;
		private System.Windows.Forms.Label label168;
		private System.Windows.Forms.Label label169;
		private System.Windows.Forms.Label label170;
		private System.Windows.Forms.Label label171;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		public frmSurgeryICUWardshipEdit()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

			m_mthSetRichTextBoxAttribInControl(this);
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label134 = new System.Windows.Forms.Label();
            this.m_txtPREFLECTRIGHT = new com.digitalwave.controls.ctlRichTextBox();
            this.label133 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.m_txtPPUPLRIGHT = new com.digitalwave.controls.ctlRichTextBox();
            this.label131 = new System.Windows.Forms.Label();
            this.m_txtPREFLECT = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtPPUPIL = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPCONSCIOUSNESS = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtPBODYPART = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtCCVP = new com.digitalwave.controls.ctlRichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtCSD = new com.digitalwave.controls.ctlRichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtCHEARTRHYTHM = new com.digitalwave.controls.ctlRichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtCHEARTRATE = new com.digitalwave.controls.ctlRichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtCSMALLTEMPERATURE = new com.digitalwave.controls.ctlRichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtCTEMPERATURE = new com.digitalwave.controls.ctlRichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label33 = new System.Windows.Forms.Label();
            this.m_txtDCURE8 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDPHYSIC8 = new com.digitalwave.controls.ctlRichTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.m_txtDCURE7 = new com.digitalwave.controls.ctlRichTextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.m_txtDPHYSIC7 = new com.digitalwave.controls.ctlRichTextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.m_txtDCURE6 = new com.digitalwave.controls.ctlRichTextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.m_txtDPHYSIC6 = new com.digitalwave.controls.ctlRichTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.m_txtDCURE5 = new com.digitalwave.controls.ctlRichTextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.m_txtDPHYSIC5 = new com.digitalwave.controls.ctlRichTextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.m_txtDCURE4 = new com.digitalwave.controls.ctlRichTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.m_txtDPHYSIC4 = new com.digitalwave.controls.ctlRichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.m_txtDCURE3 = new com.digitalwave.controls.ctlRichTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.m_txtDPHYSIC3 = new com.digitalwave.controls.ctlRichTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.m_txtDCURE2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.m_txtDPHYSIC2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_txtDCURE1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.m_txtDPHYSIC1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label149 = new System.Windows.Forms.Label();
            this.m_txtINNAME2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINAMOUNT2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label147 = new System.Windows.Forms.Label();
            this.m_txtINNAME3 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINAMOUNT3 = new com.digitalwave.controls.ctlRichTextBox();
            this.label143 = new System.Windows.Forms.Label();
            this.m_txtINNAME4 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINAMOUNT4 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINTATAL = new com.digitalwave.controls.ctlRichTextBox();
            this.label146 = new System.Windows.Forms.Label();
            this.m_txtINNAME1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtIBLOODPRO = new com.digitalwave.controls.ctlRichTextBox();
            this.label142 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.m_txtINAMOUNT1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label135 = new System.Windows.Forms.Label();
            this.m_txtIBLOODPRODUCE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtINS = new com.digitalwave.controls.ctlRichTextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.m_txtIGS = new com.digitalwave.controls.ctlRichTextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label58 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.m_txtOUTNAME4 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOUTAMOUNT4 = new com.digitalwave.controls.ctlRichTextBox();
            this.label162 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.m_txtOUTNAME3 = new com.digitalwave.controls.ctlRichTextBox();
            this.label158 = new System.Windows.Forms.Label();
            this.m_txtOUTAMOUNT3 = new com.digitalwave.controls.ctlRichTextBox();
            this.label159 = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.m_txtOUTNAME2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label155 = new System.Windows.Forms.Label();
            this.m_txtOUTAMOUNT2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label156 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.m_txtOUTNAME1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label151 = new System.Windows.Forms.Label();
            this.m_txtOUTAMOUNT1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label152 = new System.Windows.Forms.Label();
            this.m_txtOGASTRICJUICE = new com.digitalwave.controls.ctlRichTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.m_txtOEMIEMCTION = new com.digitalwave.controls.ctlRichTextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.m_txtOTATAL = new com.digitalwave.controls.ctlRichTextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_txtSESPECIALLYNOTE = new com.digitalwave.controls.ctlRichTextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label79 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.m_txtTO2CT = new com.digitalwave.controls.ctlRichTextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.m_txtTSAT = new com.digitalwave.controls.ctlRichTextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.m_txtTBE = new com.digitalwave.controls.ctlRichTextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.m_txtTTCO2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.m_txtTHCO3 = new com.digitalwave.controls.ctlRichTextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.m_txtTP02 = new com.digitalwave.controls.ctlRichTextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.m_txtTPCO2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.m_txtTPH = new com.digitalwave.controls.ctlRichTextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.m_txtTCOLLECTBLOODPOINT = new com.digitalwave.controls.ctlRichTextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label171 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.m_txtBFI02PEEPRIGHT = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBPHLEGMAMOUNT = new com.digitalwave.controls.ctlRichTextBox();
            this.label161 = new System.Windows.Forms.Label();
            this.m_txtBSQ2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.m_txtBPHLEGMCOLOR = new com.digitalwave.controls.ctlRichTextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.m_txtBBLUSESOUND = new com.digitalwave.controls.ctlRichTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.m_txtBMAXIP = new com.digitalwave.controls.ctlRichTextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.m_txtBFIO2PEEP = new com.digitalwave.controls.ctlRichTextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.m_txtBBLUSENUM = new com.digitalwave.controls.ctlRichTextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.m_txtBBLUESPRESSURE = new com.digitalwave.controls.ctlRichTextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.m_txtBEXPIREDMV = new com.digitalwave.controls.ctlRichTextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.m_txtBVT = new com.digitalwave.controls.ctlRichTextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.m_txtBBLUSEMODE = new com.digitalwave.controls.ctlRichTextBox();
            this.label100 = new System.Windows.Forms.Label();
            this.m_txtBBLUSEMACHINETYPE = new com.digitalwave.controls.ctlRichTextBox();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.m_txtBBLUSETIME = new com.digitalwave.controls.ctlRichTextBox();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label112 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.m_txtSCOCI = new com.digitalwave.controls.ctlRichTextBox();
            this.label113 = new System.Windows.Forms.Label();
            this.m_txtSWEDGE = new com.digitalwave.controls.ctlRichTextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.m_txtSMEAN = new com.digitalwave.controls.ctlRichTextBox();
            this.label116 = new System.Windows.Forms.Label();
            this.m_txtSSD = new com.digitalwave.controls.ctlRichTextBox();
            this.label117 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.m_txtSCMH2O = new com.digitalwave.controls.ctlRichTextBox();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_txtIDCode = new System.Windows.Forms.TextBox();
            this.m_txtWeight = new System.Windows.Forms.TextBox();
            this.m_txtOperationName = new System.Windows.Forms.TextBox();
            this.label125 = new System.Windows.Forms.Label();
            this.m_dtpOperationDate = new System.Windows.Forms.DateTimePicker();
            this.label126 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.m_txtDATEAFTEROPERATION = new System.Windows.Forms.TextBox();
            this.label130 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(66, 12);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(512, 40);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(424, 48);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(624, 28);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(732, 32);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(336, 28);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(408, 32);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(576, 32);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(688, 32);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(72, 0);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(272, 48);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Size = new System.Drawing.Size(116, 40);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(272, 8);
            // 
            // lblDept
            // 
            this.lblDept.Visible = false;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(603, -32);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label134);
            this.panel1.Controls.Add(this.m_txtPREFLECTRIGHT);
            this.panel1.Controls.Add(this.label133);
            this.panel1.Controls.Add(this.label132);
            this.panel1.Controls.Add(this.m_txtPPUPLRIGHT);
            this.panel1.Controls.Add(this.label131);
            this.panel1.Controls.Add(this.m_txtPREFLECT);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.m_txtPPUPIL);
            this.panel1.Controls.Add(this.m_txtPCONSCIOUSNESS);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_txtPBODYPART);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(6, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 136);
            this.panel1.TabIndex = 10000005;
            // 
            // label134
            // 
            this.label134.Location = new System.Drawing.Point(168, 104);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(12, 24);
            this.label134.TabIndex = 50;
            this.label134.Text = "右";
            this.label134.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPREFLECTRIGHT
            // 
            this.m_txtPREFLECTRIGHT.AccessibleDescription = "项目>>对光反射>>右";
            this.m_txtPREFLECTRIGHT.BackColor = System.Drawing.Color.White;
            this.m_txtPREFLECTRIGHT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPREFLECTRIGHT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPREFLECTRIGHT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPREFLECTRIGHT.Location = new System.Drawing.Point(186, 104);
            this.m_txtPREFLECTRIGHT.m_BlnIgnoreUserInfo = false;
            this.m_txtPREFLECTRIGHT.m_BlnPartControl = false;
            this.m_txtPREFLECTRIGHT.m_BlnReadOnly = false;
            this.m_txtPREFLECTRIGHT.m_BlnUnderLineDST = false;
            this.m_txtPREFLECTRIGHT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPREFLECTRIGHT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPREFLECTRIGHT.m_IntCanModifyTime = 6;
            this.m_txtPREFLECTRIGHT.m_IntPartControlLength = 0;
            this.m_txtPREFLECTRIGHT.m_IntPartControlStartIndex = 0;
            this.m_txtPREFLECTRIGHT.m_StrUserID = "";
            this.m_txtPREFLECTRIGHT.m_StrUserName = "";
            this.m_txtPREFLECTRIGHT.MaxLength = 50;
            this.m_txtPREFLECTRIGHT.Multiline = false;
            this.m_txtPREFLECTRIGHT.Name = "m_txtPREFLECTRIGHT";
            this.m_txtPREFLECTRIGHT.Size = new System.Drawing.Size(42, 22);
            this.m_txtPREFLECTRIGHT.TabIndex = 49;
            this.m_txtPREFLECTRIGHT.Text = "";
            // 
            // label133
            // 
            this.label133.Location = new System.Drawing.Point(102, 104);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(12, 24);
            this.label133.TabIndex = 48;
            this.label133.Text = "左";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label132
            // 
            this.label132.Location = new System.Drawing.Point(168, 72);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(12, 24);
            this.label132.TabIndex = 47;
            this.label132.Text = "右";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPPUPLRIGHT
            // 
            this.m_txtPPUPLRIGHT.AccessibleDescription = "项目>>瞳孔>>右";
            this.m_txtPPUPLRIGHT.BackColor = System.Drawing.Color.White;
            this.m_txtPPUPLRIGHT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPPUPLRIGHT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPPUPLRIGHT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPPUPLRIGHT.Location = new System.Drawing.Point(186, 72);
            this.m_txtPPUPLRIGHT.m_BlnIgnoreUserInfo = false;
            this.m_txtPPUPLRIGHT.m_BlnPartControl = false;
            this.m_txtPPUPLRIGHT.m_BlnReadOnly = false;
            this.m_txtPPUPLRIGHT.m_BlnUnderLineDST = false;
            this.m_txtPPUPLRIGHT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPPUPLRIGHT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPPUPLRIGHT.m_IntCanModifyTime = 6;
            this.m_txtPPUPLRIGHT.m_IntPartControlLength = 0;
            this.m_txtPPUPLRIGHT.m_IntPartControlStartIndex = 0;
            this.m_txtPPUPLRIGHT.m_StrUserID = "";
            this.m_txtPPUPLRIGHT.m_StrUserName = "";
            this.m_txtPPUPLRIGHT.MaxLength = 50;
            this.m_txtPPUPLRIGHT.Multiline = false;
            this.m_txtPPUPLRIGHT.Name = "m_txtPPUPLRIGHT";
            this.m_txtPPUPLRIGHT.Size = new System.Drawing.Size(42, 22);
            this.m_txtPPUPLRIGHT.TabIndex = 46;
            this.m_txtPPUPLRIGHT.Text = "";
            // 
            // label131
            // 
            this.label131.Location = new System.Drawing.Point(102, 72);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(12, 24);
            this.label131.TabIndex = 45;
            this.label131.Text = "左";
            this.label131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPREFLECT
            // 
            this.m_txtPREFLECT.AccessibleDescription = "项目>>对光反射>>左";
            this.m_txtPREFLECT.BackColor = System.Drawing.Color.White;
            this.m_txtPREFLECT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPREFLECT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPREFLECT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPREFLECT.Location = new System.Drawing.Point(120, 104);
            this.m_txtPREFLECT.m_BlnIgnoreUserInfo = false;
            this.m_txtPREFLECT.m_BlnPartControl = false;
            this.m_txtPREFLECT.m_BlnReadOnly = false;
            this.m_txtPREFLECT.m_BlnUnderLineDST = false;
            this.m_txtPREFLECT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPREFLECT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPREFLECT.m_IntCanModifyTime = 6;
            this.m_txtPREFLECT.m_IntPartControlLength = 0;
            this.m_txtPREFLECT.m_IntPartControlStartIndex = 0;
            this.m_txtPREFLECT.m_StrUserID = "";
            this.m_txtPREFLECT.m_StrUserName = "";
            this.m_txtPREFLECT.MaxLength = 50;
            this.m_txtPREFLECT.Multiline = false;
            this.m_txtPREFLECT.Name = "m_txtPREFLECT";
            this.m_txtPREFLECT.Size = new System.Drawing.Size(42, 22);
            this.m_txtPREFLECT.TabIndex = 43;
            this.m_txtPREFLECT.Text = "";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(30, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 1);
            this.label7.TabIndex = 42;
            // 
            // m_txtPPUPIL
            // 
            this.m_txtPPUPIL.AccessibleDescription = "项目>>瞳孔>>左";
            this.m_txtPPUPIL.BackColor = System.Drawing.Color.White;
            this.m_txtPPUPIL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPPUPIL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPPUPIL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPPUPIL.Location = new System.Drawing.Point(120, 72);
            this.m_txtPPUPIL.m_BlnIgnoreUserInfo = false;
            this.m_txtPPUPIL.m_BlnPartControl = false;
            this.m_txtPPUPIL.m_BlnReadOnly = false;
            this.m_txtPPUPIL.m_BlnUnderLineDST = false;
            this.m_txtPPUPIL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPPUPIL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPPUPIL.m_IntCanModifyTime = 6;
            this.m_txtPPUPIL.m_IntPartControlLength = 0;
            this.m_txtPPUPIL.m_IntPartControlStartIndex = 0;
            this.m_txtPPUPIL.m_StrUserID = "";
            this.m_txtPPUPIL.m_StrUserName = "";
            this.m_txtPPUPIL.MaxLength = 50;
            this.m_txtPPUPIL.Multiline = false;
            this.m_txtPPUPIL.Name = "m_txtPPUPIL";
            this.m_txtPPUPIL.Size = new System.Drawing.Size(42, 22);
            this.m_txtPPUPIL.TabIndex = 40;
            this.m_txtPPUPIL.Text = "";
            // 
            // m_txtPCONSCIOUSNESS
            // 
            this.m_txtPCONSCIOUSNESS.AccessibleDescription = "项目>>意识";
            this.m_txtPCONSCIOUSNESS.BackColor = System.Drawing.Color.White;
            this.m_txtPCONSCIOUSNESS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPCONSCIOUSNESS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPCONSCIOUSNESS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPCONSCIOUSNESS.Location = new System.Drawing.Point(144, 40);
            this.m_txtPCONSCIOUSNESS.m_BlnIgnoreUserInfo = false;
            this.m_txtPCONSCIOUSNESS.m_BlnPartControl = false;
            this.m_txtPCONSCIOUSNESS.m_BlnReadOnly = false;
            this.m_txtPCONSCIOUSNESS.m_BlnUnderLineDST = false;
            this.m_txtPCONSCIOUSNESS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPCONSCIOUSNESS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPCONSCIOUSNESS.m_IntCanModifyTime = 6;
            this.m_txtPCONSCIOUSNESS.m_IntPartControlLength = 0;
            this.m_txtPCONSCIOUSNESS.m_IntPartControlStartIndex = 0;
            this.m_txtPCONSCIOUSNESS.m_StrUserID = "";
            this.m_txtPCONSCIOUSNESS.m_StrUserName = "";
            this.m_txtPCONSCIOUSNESS.MaxLength = 250;
            this.m_txtPCONSCIOUSNESS.Multiline = false;
            this.m_txtPCONSCIOUSNESS.Name = "m_txtPCONSCIOUSNESS";
            this.m_txtPCONSCIOUSNESS.Size = new System.Drawing.Size(84, 22);
            this.m_txtPCONSCIOUSNESS.TabIndex = 38;
            this.m_txtPCONSCIOUSNESS.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(36, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 24);
            this.label6.TabIndex = 39;
            this.label6.Text = "意识";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(30, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1, 138);
            this.label5.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(30, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 1);
            this.label4.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(30, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 1);
            this.label3.TabIndex = 35;
            // 
            // m_txtPBODYPART
            // 
            this.m_txtPBODYPART.AccessibleDescription = "项目>>体位";
            this.m_txtPBODYPART.BackColor = System.Drawing.Color.White;
            this.m_txtPBODYPART.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPBODYPART.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPBODYPART.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPBODYPART.Location = new System.Drawing.Point(144, 8);
            this.m_txtPBODYPART.m_BlnIgnoreUserInfo = false;
            this.m_txtPBODYPART.m_BlnPartControl = false;
            this.m_txtPBODYPART.m_BlnReadOnly = false;
            this.m_txtPBODYPART.m_BlnUnderLineDST = false;
            this.m_txtPBODYPART.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPBODYPART.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPBODYPART.m_IntCanModifyTime = 6;
            this.m_txtPBODYPART.m_IntPartControlLength = 0;
            this.m_txtPBODYPART.m_IntPartControlStartIndex = 0;
            this.m_txtPBODYPART.m_StrUserID = "";
            this.m_txtPBODYPART.m_StrUserName = "";
            this.m_txtPBODYPART.MaxLength = 250;
            this.m_txtPBODYPART.Multiline = false;
            this.m_txtPBODYPART.Name = "m_txtPBODYPART";
            this.m_txtPBODYPART.Size = new System.Drawing.Size(84, 22);
            this.m_txtPBODYPART.TabIndex = 31;
            this.m_txtPBODYPART.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 33;
            this.label2.Text = "体位";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 112);
            this.label1.TabIndex = 32;
            this.label1.Text = "项目";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(60, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 40);
            this.label8.TabIndex = 41;
            this.label8.Text = "瞳孔:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(30, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 23);
            this.label10.TabIndex = 44;
            this.label10.Text = "对光反射";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.m_txtCCVP);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.m_txtCSD);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.m_txtCHEARTRHYTHM);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.m_txtCHEARTRATE);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.m_txtCSMALLTEMPERATURE);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.m_txtCTEMPERATURE);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Location = new System.Drawing.Point(6, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 194);
            this.panel2.TabIndex = 10000006;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(30, 192);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(210, 1);
            this.label22.TabIndex = 51;
            // 
            // m_txtCCVP
            // 
            this.m_txtCCVP.AccessibleDescription = "循环系统>>CVP";
            this.m_txtCCVP.BackColor = System.Drawing.Color.White;
            this.m_txtCCVP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCCVP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCCVP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCCVP.Location = new System.Drawing.Point(144, 168);
            this.m_txtCCVP.m_BlnIgnoreUserInfo = false;
            this.m_txtCCVP.m_BlnPartControl = false;
            this.m_txtCCVP.m_BlnReadOnly = false;
            this.m_txtCCVP.m_BlnUnderLineDST = false;
            this.m_txtCCVP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCCVP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCCVP.m_IntCanModifyTime = 6;
            this.m_txtCCVP.m_IntPartControlLength = 0;
            this.m_txtCCVP.m_IntPartControlStartIndex = 0;
            this.m_txtCCVP.m_StrUserID = "";
            this.m_txtCCVP.m_StrUserName = "";
            this.m_txtCCVP.MaxLength = 50;
            this.m_txtCCVP.Multiline = false;
            this.m_txtCCVP.Name = "m_txtCCVP";
            this.m_txtCCVP.Size = new System.Drawing.Size(84, 22);
            this.m_txtCCVP.TabIndex = 49;
            this.m_txtCCVP.Text = "";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(36, 168);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 23);
            this.label23.TabIndex = 50;
            this.label23.Text = "CVP";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(30, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(210, 1);
            this.label21.TabIndex = 48;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(30, 160);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(210, 1);
            this.label19.TabIndex = 47;
            // 
            // m_txtCSD
            // 
            this.m_txtCSD.AccessibleDescription = "循环系统>>S/D";
            this.m_txtCSD.BackColor = System.Drawing.Color.White;
            this.m_txtCSD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCSD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCSD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCSD.Location = new System.Drawing.Point(144, 136);
            this.m_txtCSD.m_BlnIgnoreUserInfo = false;
            this.m_txtCSD.m_BlnPartControl = false;
            this.m_txtCSD.m_BlnReadOnly = false;
            this.m_txtCSD.m_BlnUnderLineDST = false;
            this.m_txtCSD.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCSD.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCSD.m_IntCanModifyTime = 6;
            this.m_txtCSD.m_IntPartControlLength = 0;
            this.m_txtCSD.m_IntPartControlStartIndex = 0;
            this.m_txtCSD.m_StrUserID = "";
            this.m_txtCSD.m_StrUserName = "";
            this.m_txtCSD.MaxLength = 50;
            this.m_txtCSD.Multiline = false;
            this.m_txtCSD.Name = "m_txtCSD";
            this.m_txtCSD.Size = new System.Drawing.Size(84, 22);
            this.m_txtCSD.TabIndex = 45;
            this.m_txtCSD.Text = "";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(36, 136);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 23);
            this.label20.TabIndex = 46;
            this.label20.Text = "S/D";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCHEARTRHYTHM
            // 
            this.m_txtCHEARTRHYTHM.AccessibleDescription = "循环系统>>心律";
            this.m_txtCHEARTRHYTHM.BackColor = System.Drawing.Color.White;
            this.m_txtCHEARTRHYTHM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCHEARTRHYTHM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCHEARTRHYTHM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCHEARTRHYTHM.Location = new System.Drawing.Point(144, 104);
            this.m_txtCHEARTRHYTHM.m_BlnIgnoreUserInfo = false;
            this.m_txtCHEARTRHYTHM.m_BlnPartControl = false;
            this.m_txtCHEARTRHYTHM.m_BlnReadOnly = false;
            this.m_txtCHEARTRHYTHM.m_BlnUnderLineDST = false;
            this.m_txtCHEARTRHYTHM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCHEARTRHYTHM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCHEARTRHYTHM.m_IntCanModifyTime = 6;
            this.m_txtCHEARTRHYTHM.m_IntPartControlLength = 0;
            this.m_txtCHEARTRHYTHM.m_IntPartControlStartIndex = 0;
            this.m_txtCHEARTRHYTHM.m_StrUserID = "";
            this.m_txtCHEARTRHYTHM.m_StrUserName = "";
            this.m_txtCHEARTRHYTHM.MaxLength = 50;
            this.m_txtCHEARTRHYTHM.Multiline = false;
            this.m_txtCHEARTRHYTHM.Name = "m_txtCHEARTRHYTHM";
            this.m_txtCHEARTRHYTHM.Size = new System.Drawing.Size(84, 22);
            this.m_txtCHEARTRHYTHM.TabIndex = 43;
            this.m_txtCHEARTRHYTHM.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(36, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 23);
            this.label9.TabIndex = 44;
            this.label9.Text = "心律";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(30, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(210, 1);
            this.label11.TabIndex = 42;
            // 
            // m_txtCHEARTRATE
            // 
            this.m_txtCHEARTRATE.AccessibleDescription = "循环系统>>心率";
            this.m_txtCHEARTRATE.BackColor = System.Drawing.Color.White;
            this.m_txtCHEARTRATE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCHEARTRATE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCHEARTRATE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCHEARTRATE.Location = new System.Drawing.Point(144, 72);
            this.m_txtCHEARTRATE.m_BlnIgnoreUserInfo = false;
            this.m_txtCHEARTRATE.m_BlnPartControl = false;
            this.m_txtCHEARTRATE.m_BlnReadOnly = false;
            this.m_txtCHEARTRATE.m_BlnUnderLineDST = false;
            this.m_txtCHEARTRATE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCHEARTRATE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCHEARTRATE.m_IntCanModifyTime = 6;
            this.m_txtCHEARTRATE.m_IntPartControlLength = 0;
            this.m_txtCHEARTRATE.m_IntPartControlStartIndex = 0;
            this.m_txtCHEARTRATE.m_StrUserID = "";
            this.m_txtCHEARTRATE.m_StrUserName = "";
            this.m_txtCHEARTRATE.MaxLength = 50;
            this.m_txtCHEARTRATE.Multiline = false;
            this.m_txtCHEARTRATE.Name = "m_txtCHEARTRATE";
            this.m_txtCHEARTRATE.Size = new System.Drawing.Size(84, 22);
            this.m_txtCHEARTRATE.TabIndex = 40;
            this.m_txtCHEARTRATE.Text = "";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(36, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 41;
            this.label12.Text = "心率";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // m_txtCSMALLTEMPERATURE
            // 
            this.m_txtCSMALLTEMPERATURE.AccessibleDescription = "循环系统>>未稍温";
            this.m_txtCSMALLTEMPERATURE.BackColor = System.Drawing.Color.White;
            this.m_txtCSMALLTEMPERATURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCSMALLTEMPERATURE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCSMALLTEMPERATURE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCSMALLTEMPERATURE.Location = new System.Drawing.Point(144, 40);
            this.m_txtCSMALLTEMPERATURE.m_BlnIgnoreUserInfo = false;
            this.m_txtCSMALLTEMPERATURE.m_BlnPartControl = false;
            this.m_txtCSMALLTEMPERATURE.m_BlnReadOnly = false;
            this.m_txtCSMALLTEMPERATURE.m_BlnUnderLineDST = false;
            this.m_txtCSMALLTEMPERATURE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCSMALLTEMPERATURE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCSMALLTEMPERATURE.m_IntCanModifyTime = 6;
            this.m_txtCSMALLTEMPERATURE.m_IntPartControlLength = 0;
            this.m_txtCSMALLTEMPERATURE.m_IntPartControlStartIndex = 0;
            this.m_txtCSMALLTEMPERATURE.m_StrUserID = "";
            this.m_txtCSMALLTEMPERATURE.m_StrUserName = "";
            this.m_txtCSMALLTEMPERATURE.MaxLength = 50;
            this.m_txtCSMALLTEMPERATURE.Multiline = false;
            this.m_txtCSMALLTEMPERATURE.Name = "m_txtCSMALLTEMPERATURE";
            this.m_txtCSMALLTEMPERATURE.Size = new System.Drawing.Size(84, 22);
            this.m_txtCSMALLTEMPERATURE.TabIndex = 38;
            this.m_txtCSMALLTEMPERATURE.Text = "";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(36, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 24);
            this.label13.TabIndex = 39;
            this.label13.Text = "未稍温";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(30, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1, 210);
            this.label14.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(30, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(210, 1);
            this.label15.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(30, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(210, 1);
            this.label16.TabIndex = 35;
            // 
            // m_txtCTEMPERATURE
            // 
            this.m_txtCTEMPERATURE.AccessibleDescription = "循环系统>>体温";
            this.m_txtCTEMPERATURE.BackColor = System.Drawing.Color.White;
            this.m_txtCTEMPERATURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCTEMPERATURE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCTEMPERATURE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCTEMPERATURE.Location = new System.Drawing.Point(144, 8);
            this.m_txtCTEMPERATURE.m_BlnIgnoreUserInfo = false;
            this.m_txtCTEMPERATURE.m_BlnPartControl = false;
            this.m_txtCTEMPERATURE.m_BlnReadOnly = false;
            this.m_txtCTEMPERATURE.m_BlnUnderLineDST = false;
            this.m_txtCTEMPERATURE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCTEMPERATURE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCTEMPERATURE.m_IntCanModifyTime = 6;
            this.m_txtCTEMPERATURE.m_IntPartControlLength = 0;
            this.m_txtCTEMPERATURE.m_IntPartControlStartIndex = 0;
            this.m_txtCTEMPERATURE.m_StrUserID = "";
            this.m_txtCTEMPERATURE.m_StrUserName = "";
            this.m_txtCTEMPERATURE.MaxLength = 50;
            this.m_txtCTEMPERATURE.Multiline = false;
            this.m_txtCTEMPERATURE.Name = "m_txtCTEMPERATURE";
            this.m_txtCTEMPERATURE.Size = new System.Drawing.Size(84, 22);
            this.m_txtCTEMPERATURE.TabIndex = 31;
            this.m_txtCTEMPERATURE.Text = "";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(36, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 23);
            this.label17.TabIndex = 33;
            this.label17.Text = "体温";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(6, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 112);
            this.label18.TabIndex = 32;
            this.label18.Text = "循环系统";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label33);
            this.panel3.Controls.Add(this.m_txtDCURE8);
            this.panel3.Controls.Add(this.m_txtDPHYSIC8);
            this.panel3.Controls.Add(this.label40);
            this.panel3.Controls.Add(this.m_txtDCURE7);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Controls.Add(this.m_txtDPHYSIC7);
            this.panel3.Controls.Add(this.label43);
            this.panel3.Controls.Add(this.m_txtDCURE6);
            this.panel3.Controls.Add(this.label45);
            this.panel3.Controls.Add(this.m_txtDPHYSIC6);
            this.panel3.Controls.Add(this.label46);
            this.panel3.Controls.Add(this.m_txtDCURE5);
            this.panel3.Controls.Add(this.label48);
            this.panel3.Controls.Add(this.m_txtDPHYSIC5);
            this.panel3.Controls.Add(this.label49);
            this.panel3.Controls.Add(this.m_txtDCURE4);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.m_txtDPHYSIC4);
            this.panel3.Controls.Add(this.label29);
            this.panel3.Controls.Add(this.m_txtDCURE3);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.m_txtDPHYSIC3);
            this.panel3.Controls.Add(this.label32);
            this.panel3.Controls.Add(this.m_txtDCURE2);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.m_txtDPHYSIC2);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.m_txtDCURE1);
            this.panel3.Controls.Add(this.label35);
            this.panel3.Controls.Add(this.m_txtDPHYSIC1);
            this.panel3.Controls.Add(this.label36);
            this.panel3.Controls.Add(this.label37);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.label44);
            this.panel3.Controls.Add(this.label47);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.label38);
            this.panel3.Location = new System.Drawing.Point(246, 368);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 260);
            this.panel3.TabIndex = 10000007;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(30, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(1, 270);
            this.label33.TabIndex = 37;
            // 
            // m_txtDCURE8
            // 
            this.m_txtDCURE8.AccessibleDescription = "用药及治疗>>治疗8";
            this.m_txtDCURE8.BackColor = System.Drawing.Color.White;
            this.m_txtDCURE8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDCURE8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDCURE8.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDCURE8.Location = new System.Drawing.Point(270, 232);
            this.m_txtDCURE8.m_BlnIgnoreUserInfo = false;
            this.m_txtDCURE8.m_BlnPartControl = false;
            this.m_txtDCURE8.m_BlnReadOnly = false;
            this.m_txtDCURE8.m_BlnUnderLineDST = false;
            this.m_txtDCURE8.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDCURE8.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDCURE8.m_IntCanModifyTime = 6;
            this.m_txtDCURE8.m_IntPartControlLength = 0;
            this.m_txtDCURE8.m_IntPartControlStartIndex = 0;
            this.m_txtDCURE8.m_StrUserID = "";
            this.m_txtDCURE8.m_StrUserName = "";
            this.m_txtDCURE8.MaxLength = 250;
            this.m_txtDCURE8.Multiline = false;
            this.m_txtDCURE8.Name = "m_txtDCURE8";
            this.m_txtDCURE8.Size = new System.Drawing.Size(198, 22);
            this.m_txtDCURE8.TabIndex = 88;
            this.m_txtDCURE8.Text = "";
            // 
            // m_txtDPHYSIC8
            // 
            this.m_txtDPHYSIC8.AccessibleDescription = "用药及治疗>>药品名称8";
            this.m_txtDPHYSIC8.BackColor = System.Drawing.Color.White;
            this.m_txtDPHYSIC8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDPHYSIC8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDPHYSIC8.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDPHYSIC8.Location = new System.Drawing.Point(102, 232);
            this.m_txtDPHYSIC8.m_BlnIgnoreUserInfo = false;
            this.m_txtDPHYSIC8.m_BlnPartControl = false;
            this.m_txtDPHYSIC8.m_BlnReadOnly = false;
            this.m_txtDPHYSIC8.m_BlnUnderLineDST = false;
            this.m_txtDPHYSIC8.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDPHYSIC8.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDPHYSIC8.m_IntCanModifyTime = 6;
            this.m_txtDPHYSIC8.m_IntPartControlLength = 0;
            this.m_txtDPHYSIC8.m_IntPartControlStartIndex = 0;
            this.m_txtDPHYSIC8.m_StrUserID = "";
            this.m_txtDPHYSIC8.m_StrUserName = "";
            this.m_txtDPHYSIC8.MaxLength = 250;
            this.m_txtDPHYSIC8.Multiline = false;
            this.m_txtDPHYSIC8.Name = "m_txtDPHYSIC8";
            this.m_txtDPHYSIC8.Size = new System.Drawing.Size(126, 22);
            this.m_txtDPHYSIC8.TabIndex = 84;
            this.m_txtDPHYSIC8.Text = "";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(30, 232);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(72, 23);
            this.label40.TabIndex = 85;
            this.label40.Text = "药品名称8";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDCURE7
            // 
            this.m_txtDCURE7.AccessibleDescription = "用药及治疗>>治疗7";
            this.m_txtDCURE7.BackColor = System.Drawing.Color.White;
            this.m_txtDCURE7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDCURE7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDCURE7.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDCURE7.Location = new System.Drawing.Point(270, 200);
            this.m_txtDCURE7.m_BlnIgnoreUserInfo = false;
            this.m_txtDCURE7.m_BlnPartControl = false;
            this.m_txtDCURE7.m_BlnReadOnly = false;
            this.m_txtDCURE7.m_BlnUnderLineDST = false;
            this.m_txtDCURE7.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDCURE7.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDCURE7.m_IntCanModifyTime = 6;
            this.m_txtDCURE7.m_IntPartControlLength = 0;
            this.m_txtDCURE7.m_IntPartControlStartIndex = 0;
            this.m_txtDCURE7.m_StrUserID = "";
            this.m_txtDCURE7.m_StrUserName = "";
            this.m_txtDCURE7.MaxLength = 250;
            this.m_txtDCURE7.Multiline = false;
            this.m_txtDCURE7.Name = "m_txtDCURE7";
            this.m_txtDCURE7.Size = new System.Drawing.Size(198, 22);
            this.m_txtDCURE7.TabIndex = 83;
            this.m_txtDCURE7.Text = "";
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(36, 224);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(800, 1);
            this.label42.TabIndex = 81;
            // 
            // m_txtDPHYSIC7
            // 
            this.m_txtDPHYSIC7.AccessibleDescription = "用药及治疗>>药品名称7";
            this.m_txtDPHYSIC7.BackColor = System.Drawing.Color.White;
            this.m_txtDPHYSIC7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDPHYSIC7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDPHYSIC7.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDPHYSIC7.Location = new System.Drawing.Point(102, 200);
            this.m_txtDPHYSIC7.m_BlnIgnoreUserInfo = false;
            this.m_txtDPHYSIC7.m_BlnPartControl = false;
            this.m_txtDPHYSIC7.m_BlnReadOnly = false;
            this.m_txtDPHYSIC7.m_BlnUnderLineDST = false;
            this.m_txtDPHYSIC7.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDPHYSIC7.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDPHYSIC7.m_IntCanModifyTime = 6;
            this.m_txtDPHYSIC7.m_IntPartControlLength = 0;
            this.m_txtDPHYSIC7.m_IntPartControlStartIndex = 0;
            this.m_txtDPHYSIC7.m_StrUserID = "";
            this.m_txtDPHYSIC7.m_StrUserName = "";
            this.m_txtDPHYSIC7.MaxLength = 250;
            this.m_txtDPHYSIC7.Multiline = false;
            this.m_txtDPHYSIC7.Name = "m_txtDPHYSIC7";
            this.m_txtDPHYSIC7.Size = new System.Drawing.Size(126, 22);
            this.m_txtDPHYSIC7.TabIndex = 79;
            this.m_txtDPHYSIC7.Text = "";
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(30, 200);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(72, 23);
            this.label43.TabIndex = 80;
            this.label43.Text = "药品名称7";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDCURE6
            // 
            this.m_txtDCURE6.AccessibleDescription = "用药及治疗>>治疗6";
            this.m_txtDCURE6.BackColor = System.Drawing.Color.White;
            this.m_txtDCURE6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDCURE6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDCURE6.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDCURE6.Location = new System.Drawing.Point(270, 168);
            this.m_txtDCURE6.m_BlnIgnoreUserInfo = false;
            this.m_txtDCURE6.m_BlnPartControl = false;
            this.m_txtDCURE6.m_BlnReadOnly = false;
            this.m_txtDCURE6.m_BlnUnderLineDST = false;
            this.m_txtDCURE6.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDCURE6.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDCURE6.m_IntCanModifyTime = 6;
            this.m_txtDCURE6.m_IntPartControlLength = 0;
            this.m_txtDCURE6.m_IntPartControlStartIndex = 0;
            this.m_txtDCURE6.m_StrUserID = "";
            this.m_txtDCURE6.m_StrUserName = "";
            this.m_txtDCURE6.MaxLength = 250;
            this.m_txtDCURE6.Multiline = false;
            this.m_txtDCURE6.Name = "m_txtDCURE6";
            this.m_txtDCURE6.Size = new System.Drawing.Size(198, 22);
            this.m_txtDCURE6.TabIndex = 78;
            this.m_txtDCURE6.Text = "";
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(36, 192);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(800, 1);
            this.label45.TabIndex = 76;
            // 
            // m_txtDPHYSIC6
            // 
            this.m_txtDPHYSIC6.AccessibleDescription = "用药及治疗>>药品名称6";
            this.m_txtDPHYSIC6.BackColor = System.Drawing.Color.White;
            this.m_txtDPHYSIC6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDPHYSIC6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDPHYSIC6.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDPHYSIC6.Location = new System.Drawing.Point(102, 168);
            this.m_txtDPHYSIC6.m_BlnIgnoreUserInfo = false;
            this.m_txtDPHYSIC6.m_BlnPartControl = false;
            this.m_txtDPHYSIC6.m_BlnReadOnly = false;
            this.m_txtDPHYSIC6.m_BlnUnderLineDST = false;
            this.m_txtDPHYSIC6.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDPHYSIC6.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDPHYSIC6.m_IntCanModifyTime = 6;
            this.m_txtDPHYSIC6.m_IntPartControlLength = 0;
            this.m_txtDPHYSIC6.m_IntPartControlStartIndex = 0;
            this.m_txtDPHYSIC6.m_StrUserID = "";
            this.m_txtDPHYSIC6.m_StrUserName = "";
            this.m_txtDPHYSIC6.MaxLength = 250;
            this.m_txtDPHYSIC6.Multiline = false;
            this.m_txtDPHYSIC6.Name = "m_txtDPHYSIC6";
            this.m_txtDPHYSIC6.Size = new System.Drawing.Size(126, 22);
            this.m_txtDPHYSIC6.TabIndex = 74;
            this.m_txtDPHYSIC6.Text = "";
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(30, 168);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(72, 23);
            this.label46.TabIndex = 75;
            this.label46.Text = "药品名称6";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDCURE5
            // 
            this.m_txtDCURE5.AccessibleDescription = "用药及治疗>>治疗5";
            this.m_txtDCURE5.BackColor = System.Drawing.Color.White;
            this.m_txtDCURE5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDCURE5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDCURE5.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDCURE5.Location = new System.Drawing.Point(270, 136);
            this.m_txtDCURE5.m_BlnIgnoreUserInfo = false;
            this.m_txtDCURE5.m_BlnPartControl = false;
            this.m_txtDCURE5.m_BlnReadOnly = false;
            this.m_txtDCURE5.m_BlnUnderLineDST = false;
            this.m_txtDCURE5.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDCURE5.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDCURE5.m_IntCanModifyTime = 6;
            this.m_txtDCURE5.m_IntPartControlLength = 0;
            this.m_txtDCURE5.m_IntPartControlStartIndex = 0;
            this.m_txtDCURE5.m_StrUserID = "";
            this.m_txtDCURE5.m_StrUserName = "";
            this.m_txtDCURE5.MaxLength = 250;
            this.m_txtDCURE5.Multiline = false;
            this.m_txtDCURE5.Name = "m_txtDCURE5";
            this.m_txtDCURE5.Size = new System.Drawing.Size(198, 22);
            this.m_txtDCURE5.TabIndex = 73;
            this.m_txtDCURE5.Text = "";
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(36, 160);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(800, 1);
            this.label48.TabIndex = 71;
            // 
            // m_txtDPHYSIC5
            // 
            this.m_txtDPHYSIC5.AccessibleDescription = "用药及治疗>>药品名称5";
            this.m_txtDPHYSIC5.BackColor = System.Drawing.Color.White;
            this.m_txtDPHYSIC5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDPHYSIC5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDPHYSIC5.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDPHYSIC5.Location = new System.Drawing.Point(102, 136);
            this.m_txtDPHYSIC5.m_BlnIgnoreUserInfo = false;
            this.m_txtDPHYSIC5.m_BlnPartControl = false;
            this.m_txtDPHYSIC5.m_BlnReadOnly = false;
            this.m_txtDPHYSIC5.m_BlnUnderLineDST = false;
            this.m_txtDPHYSIC5.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDPHYSIC5.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDPHYSIC5.m_IntCanModifyTime = 6;
            this.m_txtDPHYSIC5.m_IntPartControlLength = 0;
            this.m_txtDPHYSIC5.m_IntPartControlStartIndex = 0;
            this.m_txtDPHYSIC5.m_StrUserID = "";
            this.m_txtDPHYSIC5.m_StrUserName = "";
            this.m_txtDPHYSIC5.MaxLength = 250;
            this.m_txtDPHYSIC5.Multiline = false;
            this.m_txtDPHYSIC5.Name = "m_txtDPHYSIC5";
            this.m_txtDPHYSIC5.Size = new System.Drawing.Size(126, 22);
            this.m_txtDPHYSIC5.TabIndex = 69;
            this.m_txtDPHYSIC5.Text = "";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(30, 136);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(72, 23);
            this.label49.TabIndex = 70;
            this.label49.Text = "药品名称5";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDCURE4
            // 
            this.m_txtDCURE4.AccessibleDescription = "用药及治疗>>治疗4";
            this.m_txtDCURE4.BackColor = System.Drawing.Color.White;
            this.m_txtDCURE4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDCURE4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDCURE4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDCURE4.Location = new System.Drawing.Point(270, 104);
            this.m_txtDCURE4.m_BlnIgnoreUserInfo = false;
            this.m_txtDCURE4.m_BlnPartControl = false;
            this.m_txtDCURE4.m_BlnReadOnly = false;
            this.m_txtDCURE4.m_BlnUnderLineDST = false;
            this.m_txtDCURE4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDCURE4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDCURE4.m_IntCanModifyTime = 6;
            this.m_txtDCURE4.m_IntPartControlLength = 0;
            this.m_txtDCURE4.m_IntPartControlStartIndex = 0;
            this.m_txtDCURE4.m_StrUserID = "";
            this.m_txtDCURE4.m_StrUserName = "";
            this.m_txtDCURE4.MaxLength = 250;
            this.m_txtDCURE4.Multiline = false;
            this.m_txtDCURE4.Name = "m_txtDCURE4";
            this.m_txtDCURE4.Size = new System.Drawing.Size(198, 22);
            this.m_txtDCURE4.TabIndex = 68;
            this.m_txtDCURE4.Text = "";
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(30, 128);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(800, 1);
            this.label28.TabIndex = 66;
            // 
            // m_txtDPHYSIC4
            // 
            this.m_txtDPHYSIC4.AccessibleDescription = "用药及治疗>>药品名称4";
            this.m_txtDPHYSIC4.BackColor = System.Drawing.Color.White;
            this.m_txtDPHYSIC4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDPHYSIC4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDPHYSIC4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDPHYSIC4.Location = new System.Drawing.Point(102, 104);
            this.m_txtDPHYSIC4.m_BlnIgnoreUserInfo = false;
            this.m_txtDPHYSIC4.m_BlnPartControl = false;
            this.m_txtDPHYSIC4.m_BlnReadOnly = false;
            this.m_txtDPHYSIC4.m_BlnUnderLineDST = false;
            this.m_txtDPHYSIC4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDPHYSIC4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDPHYSIC4.m_IntCanModifyTime = 6;
            this.m_txtDPHYSIC4.m_IntPartControlLength = 0;
            this.m_txtDPHYSIC4.m_IntPartControlStartIndex = 0;
            this.m_txtDPHYSIC4.m_StrUserID = "";
            this.m_txtDPHYSIC4.m_StrUserName = "";
            this.m_txtDPHYSIC4.MaxLength = 250;
            this.m_txtDPHYSIC4.Multiline = false;
            this.m_txtDPHYSIC4.Name = "m_txtDPHYSIC4";
            this.m_txtDPHYSIC4.Size = new System.Drawing.Size(126, 22);
            this.m_txtDPHYSIC4.TabIndex = 64;
            this.m_txtDPHYSIC4.Text = "";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(30, 104);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 23);
            this.label29.TabIndex = 65;
            this.label29.Text = "药品名称4";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDCURE3
            // 
            this.m_txtDCURE3.AccessibleDescription = "用药及治疗>>治疗3";
            this.m_txtDCURE3.BackColor = System.Drawing.Color.White;
            this.m_txtDCURE3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDCURE3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDCURE3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDCURE3.Location = new System.Drawing.Point(270, 72);
            this.m_txtDCURE3.m_BlnIgnoreUserInfo = false;
            this.m_txtDCURE3.m_BlnPartControl = false;
            this.m_txtDCURE3.m_BlnReadOnly = false;
            this.m_txtDCURE3.m_BlnUnderLineDST = false;
            this.m_txtDCURE3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDCURE3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDCURE3.m_IntCanModifyTime = 6;
            this.m_txtDCURE3.m_IntPartControlLength = 0;
            this.m_txtDCURE3.m_IntPartControlStartIndex = 0;
            this.m_txtDCURE3.m_StrUserID = "";
            this.m_txtDCURE3.m_StrUserName = "";
            this.m_txtDCURE3.MaxLength = 250;
            this.m_txtDCURE3.Multiline = false;
            this.m_txtDCURE3.Name = "m_txtDCURE3";
            this.m_txtDCURE3.Size = new System.Drawing.Size(198, 22);
            this.m_txtDCURE3.TabIndex = 63;
            this.m_txtDCURE3.Text = "";
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(30, 96);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(800, 1);
            this.label31.TabIndex = 61;
            // 
            // m_txtDPHYSIC3
            // 
            this.m_txtDPHYSIC3.AccessibleDescription = "用药及治疗>>药品名称3";
            this.m_txtDPHYSIC3.BackColor = System.Drawing.Color.White;
            this.m_txtDPHYSIC3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDPHYSIC3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDPHYSIC3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDPHYSIC3.Location = new System.Drawing.Point(102, 72);
            this.m_txtDPHYSIC3.m_BlnIgnoreUserInfo = false;
            this.m_txtDPHYSIC3.m_BlnPartControl = false;
            this.m_txtDPHYSIC3.m_BlnReadOnly = false;
            this.m_txtDPHYSIC3.m_BlnUnderLineDST = false;
            this.m_txtDPHYSIC3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDPHYSIC3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDPHYSIC3.m_IntCanModifyTime = 6;
            this.m_txtDPHYSIC3.m_IntPartControlLength = 0;
            this.m_txtDPHYSIC3.m_IntPartControlStartIndex = 0;
            this.m_txtDPHYSIC3.m_StrUserID = "";
            this.m_txtDPHYSIC3.m_StrUserName = "";
            this.m_txtDPHYSIC3.MaxLength = 250;
            this.m_txtDPHYSIC3.Multiline = false;
            this.m_txtDPHYSIC3.Name = "m_txtDPHYSIC3";
            this.m_txtDPHYSIC3.Size = new System.Drawing.Size(126, 22);
            this.m_txtDPHYSIC3.TabIndex = 59;
            this.m_txtDPHYSIC3.Text = "";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(30, 72);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 23);
            this.label32.TabIndex = 60;
            this.label32.Text = "药品名称3";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDCURE2
            // 
            this.m_txtDCURE2.AccessibleDescription = "用药及治疗>>治疗2";
            this.m_txtDCURE2.BackColor = System.Drawing.Color.White;
            this.m_txtDCURE2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDCURE2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDCURE2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDCURE2.Location = new System.Drawing.Point(270, 40);
            this.m_txtDCURE2.m_BlnIgnoreUserInfo = false;
            this.m_txtDCURE2.m_BlnPartControl = false;
            this.m_txtDCURE2.m_BlnReadOnly = false;
            this.m_txtDCURE2.m_BlnUnderLineDST = false;
            this.m_txtDCURE2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDCURE2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDCURE2.m_IntCanModifyTime = 6;
            this.m_txtDCURE2.m_IntPartControlLength = 0;
            this.m_txtDCURE2.m_IntPartControlStartIndex = 0;
            this.m_txtDCURE2.m_StrUserID = "";
            this.m_txtDCURE2.m_StrUserName = "";
            this.m_txtDCURE2.MaxLength = 250;
            this.m_txtDCURE2.Multiline = false;
            this.m_txtDCURE2.Name = "m_txtDCURE2";
            this.m_txtDCURE2.Size = new System.Drawing.Size(198, 22);
            this.m_txtDCURE2.TabIndex = 58;
            this.m_txtDCURE2.Text = "";
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(30, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(800, 1);
            this.label25.TabIndex = 56;
            // 
            // m_txtDPHYSIC2
            // 
            this.m_txtDPHYSIC2.AccessibleDescription = "用药及治疗>>药品名称2";
            this.m_txtDPHYSIC2.BackColor = System.Drawing.Color.White;
            this.m_txtDPHYSIC2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDPHYSIC2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDPHYSIC2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDPHYSIC2.Location = new System.Drawing.Point(102, 40);
            this.m_txtDPHYSIC2.m_BlnIgnoreUserInfo = false;
            this.m_txtDPHYSIC2.m_BlnPartControl = false;
            this.m_txtDPHYSIC2.m_BlnReadOnly = false;
            this.m_txtDPHYSIC2.m_BlnUnderLineDST = false;
            this.m_txtDPHYSIC2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDPHYSIC2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDPHYSIC2.m_IntCanModifyTime = 6;
            this.m_txtDPHYSIC2.m_IntPartControlLength = 0;
            this.m_txtDPHYSIC2.m_IntPartControlStartIndex = 0;
            this.m_txtDPHYSIC2.m_StrUserID = "";
            this.m_txtDPHYSIC2.m_StrUserName = "";
            this.m_txtDPHYSIC2.MaxLength = 250;
            this.m_txtDPHYSIC2.Multiline = false;
            this.m_txtDPHYSIC2.Name = "m_txtDPHYSIC2";
            this.m_txtDPHYSIC2.Size = new System.Drawing.Size(126, 22);
            this.m_txtDPHYSIC2.TabIndex = 54;
            this.m_txtDPHYSIC2.Text = "";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(30, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 23);
            this.label26.TabIndex = 55;
            this.label26.Text = "药品名称2";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDCURE1
            // 
            this.m_txtDCURE1.AccessibleDescription = "用药及治疗>>治疗1";
            this.m_txtDCURE1.BackColor = System.Drawing.Color.White;
            this.m_txtDCURE1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDCURE1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDCURE1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDCURE1.Location = new System.Drawing.Point(270, 8);
            this.m_txtDCURE1.m_BlnIgnoreUserInfo = false;
            this.m_txtDCURE1.m_BlnPartControl = false;
            this.m_txtDCURE1.m_BlnReadOnly = false;
            this.m_txtDCURE1.m_BlnUnderLineDST = false;
            this.m_txtDCURE1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDCURE1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDCURE1.m_IntCanModifyTime = 6;
            this.m_txtDCURE1.m_IntPartControlLength = 0;
            this.m_txtDCURE1.m_IntPartControlStartIndex = 0;
            this.m_txtDCURE1.m_StrUserID = "";
            this.m_txtDCURE1.m_StrUserName = "";
            this.m_txtDCURE1.MaxLength = 250;
            this.m_txtDCURE1.Multiline = false;
            this.m_txtDCURE1.Name = "m_txtDCURE1";
            this.m_txtDCURE1.Size = new System.Drawing.Size(198, 22);
            this.m_txtDCURE1.TabIndex = 53;
            this.m_txtDCURE1.Text = "";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(30, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(800, 1);
            this.label35.TabIndex = 35;
            // 
            // m_txtDPHYSIC1
            // 
            this.m_txtDPHYSIC1.AccessibleDescription = "用药及治疗>>药品名称1";
            this.m_txtDPHYSIC1.BackColor = System.Drawing.Color.White;
            this.m_txtDPHYSIC1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDPHYSIC1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDPHYSIC1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDPHYSIC1.Location = new System.Drawing.Point(102, 8);
            this.m_txtDPHYSIC1.m_BlnIgnoreUserInfo = false;
            this.m_txtDPHYSIC1.m_BlnPartControl = false;
            this.m_txtDPHYSIC1.m_BlnReadOnly = false;
            this.m_txtDPHYSIC1.m_BlnUnderLineDST = false;
            this.m_txtDPHYSIC1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDPHYSIC1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDPHYSIC1.m_IntCanModifyTime = 6;
            this.m_txtDPHYSIC1.m_IntPartControlLength = 0;
            this.m_txtDPHYSIC1.m_IntPartControlStartIndex = 0;
            this.m_txtDPHYSIC1.m_StrUserID = "";
            this.m_txtDPHYSIC1.m_StrUserName = "";
            this.m_txtDPHYSIC1.MaxLength = 250;
            this.m_txtDPHYSIC1.Multiline = false;
            this.m_txtDPHYSIC1.Name = "m_txtDPHYSIC1";
            this.m_txtDPHYSIC1.Size = new System.Drawing.Size(126, 22);
            this.m_txtDPHYSIC1.TabIndex = 31;
            this.m_txtDPHYSIC1.Text = "";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(30, 8);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 23);
            this.label36.TabIndex = 33;
            this.label36.Text = "药品名称1";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(6, 8);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(18, 248);
            this.label37.TabIndex = 32;
            this.label37.Text = "用药及治疗";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(228, 232);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 23);
            this.label34.TabIndex = 87;
            this.label34.Text = "治疗8";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(228, 200);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(48, 23);
            this.label41.TabIndex = 82;
            this.label41.Text = "治疗7";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(228, 168);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(48, 23);
            this.label44.TabIndex = 77;
            this.label44.Text = "治疗6";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(228, 136);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(48, 23);
            this.label47.TabIndex = 72;
            this.label47.Text = "治疗5";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(228, 104);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 23);
            this.label27.TabIndex = 67;
            this.label27.Text = "治疗4";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(228, 72);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 23);
            this.label30.TabIndex = 62;
            this.label30.Text = "治疗3";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(228, 40);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 23);
            this.label24.TabIndex = 57;
            this.label24.Text = "治疗2";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(228, 8);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 23);
            this.label38.TabIndex = 52;
            this.label38.Text = "治疗1";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label149);
            this.panel4.Controls.Add(this.m_txtINNAME2);
            this.panel4.Controls.Add(this.m_txtINAMOUNT2);
            this.panel4.Controls.Add(this.label147);
            this.panel4.Controls.Add(this.m_txtINNAME3);
            this.panel4.Controls.Add(this.m_txtINAMOUNT3);
            this.panel4.Controls.Add(this.label143);
            this.panel4.Controls.Add(this.m_txtINNAME4);
            this.panel4.Controls.Add(this.m_txtINAMOUNT4);
            this.panel4.Controls.Add(this.m_txtINTATAL);
            this.panel4.Controls.Add(this.label146);
            this.panel4.Controls.Add(this.m_txtINNAME1);
            this.panel4.Controls.Add(this.m_txtIBLOODPRO);
            this.panel4.Controls.Add(this.label142);
            this.panel4.Controls.Add(this.label140);
            this.panel4.Controls.Add(this.label138);
            this.panel4.Controls.Add(this.label136);
            this.panel4.Controls.Add(this.m_txtINAMOUNT1);
            this.panel4.Controls.Add(this.label135);
            this.panel4.Controls.Add(this.m_txtIBLOODPRODUCE);
            this.panel4.Controls.Add(this.m_txtINS);
            this.panel4.Controls.Add(this.label52);
            this.panel4.Controls.Add(this.label53);
            this.panel4.Controls.Add(this.label54);
            this.panel4.Controls.Add(this.label55);
            this.panel4.Controls.Add(this.m_txtIGS);
            this.panel4.Controls.Add(this.label56);
            this.panel4.Controls.Add(this.label57);
            this.panel4.Controls.Add(this.label51);
            this.panel4.Controls.Add(this.label144);
            this.panel4.Controls.Add(this.label145);
            this.panel4.Controls.Add(this.label137);
            this.panel4.Controls.Add(this.label148);
            this.panel4.Controls.Add(this.label150);
            this.panel4.Controls.Add(this.label139);
            this.panel4.Location = new System.Drawing.Point(6, 368);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 260);
            this.panel4.TabIndex = 10000008;
            // 
            // label149
            // 
            this.label149.Location = new System.Drawing.Point(144, 136);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(36, 23);
            this.label149.TabIndex = 76;
            this.label149.Text = "数量";
            this.label149.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtINNAME2
            // 
            this.m_txtINNAME2.AccessibleDescription = "入量>>名称2";
            this.m_txtINNAME2.BackColor = System.Drawing.Color.White;
            this.m_txtINNAME2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINNAME2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINNAME2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINNAME2.Location = new System.Drawing.Point(66, 136);
            this.m_txtINNAME2.m_BlnIgnoreUserInfo = false;
            this.m_txtINNAME2.m_BlnPartControl = false;
            this.m_txtINNAME2.m_BlnReadOnly = false;
            this.m_txtINNAME2.m_BlnUnderLineDST = false;
            this.m_txtINNAME2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINNAME2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINNAME2.m_IntCanModifyTime = 6;
            this.m_txtINNAME2.m_IntPartControlLength = 0;
            this.m_txtINNAME2.m_IntPartControlStartIndex = 0;
            this.m_txtINNAME2.m_StrUserID = "";
            this.m_txtINNAME2.m_StrUserName = "";
            this.m_txtINNAME2.MaxLength = 50;
            this.m_txtINNAME2.Multiline = false;
            this.m_txtINNAME2.Name = "m_txtINNAME2";
            this.m_txtINNAME2.Size = new System.Drawing.Size(78, 22);
            this.m_txtINNAME2.TabIndex = 75;
            this.m_txtINNAME2.Text = "";
            // 
            // m_txtINAMOUNT2
            // 
            this.m_txtINAMOUNT2.AccessibleDescription = "入量>>数量2";
            this.m_txtINAMOUNT2.BackColor = System.Drawing.Color.White;
            this.m_txtINAMOUNT2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINAMOUNT2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINAMOUNT2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINAMOUNT2.Location = new System.Drawing.Point(180, 136);
            this.m_txtINAMOUNT2.m_BlnIgnoreUserInfo = false;
            this.m_txtINAMOUNT2.m_BlnPartControl = false;
            this.m_txtINAMOUNT2.m_BlnReadOnly = false;
            this.m_txtINAMOUNT2.m_BlnUnderLineDST = false;
            this.m_txtINAMOUNT2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINAMOUNT2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINAMOUNT2.m_IntCanModifyTime = 6;
            this.m_txtINAMOUNT2.m_IntPartControlLength = 0;
            this.m_txtINAMOUNT2.m_IntPartControlStartIndex = 0;
            this.m_txtINAMOUNT2.m_StrUserID = "";
            this.m_txtINAMOUNT2.m_StrUserName = "";
            this.m_txtINAMOUNT2.MaxLength = 6;
            this.m_txtINAMOUNT2.Multiline = false;
            this.m_txtINAMOUNT2.Name = "m_txtINAMOUNT2";
            this.m_txtINAMOUNT2.Size = new System.Drawing.Size(48, 22);
            this.m_txtINAMOUNT2.TabIndex = 73;
            this.m_txtINAMOUNT2.Text = "";
            // 
            // label147
            // 
            this.label147.Location = new System.Drawing.Point(144, 168);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(36, 23);
            this.label147.TabIndex = 72;
            this.label147.Text = "数量";
            this.label147.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtINNAME3
            // 
            this.m_txtINNAME3.AccessibleDescription = "入量>>名称3";
            this.m_txtINNAME3.BackColor = System.Drawing.Color.White;
            this.m_txtINNAME3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINNAME3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINNAME3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINNAME3.Location = new System.Drawing.Point(66, 168);
            this.m_txtINNAME3.m_BlnIgnoreUserInfo = false;
            this.m_txtINNAME3.m_BlnPartControl = false;
            this.m_txtINNAME3.m_BlnReadOnly = false;
            this.m_txtINNAME3.m_BlnUnderLineDST = false;
            this.m_txtINNAME3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINNAME3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINNAME3.m_IntCanModifyTime = 6;
            this.m_txtINNAME3.m_IntPartControlLength = 0;
            this.m_txtINNAME3.m_IntPartControlStartIndex = 0;
            this.m_txtINNAME3.m_StrUserID = "";
            this.m_txtINNAME3.m_StrUserName = "";
            this.m_txtINNAME3.MaxLength = 50;
            this.m_txtINNAME3.Multiline = false;
            this.m_txtINNAME3.Name = "m_txtINNAME3";
            this.m_txtINNAME3.Size = new System.Drawing.Size(78, 22);
            this.m_txtINNAME3.TabIndex = 71;
            this.m_txtINNAME3.Text = "";
            // 
            // m_txtINAMOUNT3
            // 
            this.m_txtINAMOUNT3.AccessibleDescription = "入量>>数量3";
            this.m_txtINAMOUNT3.BackColor = System.Drawing.Color.White;
            this.m_txtINAMOUNT3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINAMOUNT3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINAMOUNT3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINAMOUNT3.Location = new System.Drawing.Point(180, 168);
            this.m_txtINAMOUNT3.m_BlnIgnoreUserInfo = false;
            this.m_txtINAMOUNT3.m_BlnPartControl = false;
            this.m_txtINAMOUNT3.m_BlnReadOnly = false;
            this.m_txtINAMOUNT3.m_BlnUnderLineDST = false;
            this.m_txtINAMOUNT3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINAMOUNT3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINAMOUNT3.m_IntCanModifyTime = 6;
            this.m_txtINAMOUNT3.m_IntPartControlLength = 0;
            this.m_txtINAMOUNT3.m_IntPartControlStartIndex = 0;
            this.m_txtINAMOUNT3.m_StrUserID = "";
            this.m_txtINAMOUNT3.m_StrUserName = "";
            this.m_txtINAMOUNT3.MaxLength = 6;
            this.m_txtINAMOUNT3.Multiline = false;
            this.m_txtINAMOUNT3.Name = "m_txtINAMOUNT3";
            this.m_txtINAMOUNT3.Size = new System.Drawing.Size(48, 22);
            this.m_txtINAMOUNT3.TabIndex = 69;
            this.m_txtINAMOUNT3.Text = "";
            // 
            // label143
            // 
            this.label143.Location = new System.Drawing.Point(144, 200);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(36, 23);
            this.label143.TabIndex = 68;
            this.label143.Text = "数量";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtINNAME4
            // 
            this.m_txtINNAME4.AccessibleDescription = "入量>>名称4";
            this.m_txtINNAME4.BackColor = System.Drawing.Color.White;
            this.m_txtINNAME4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINNAME4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINNAME4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINNAME4.Location = new System.Drawing.Point(66, 200);
            this.m_txtINNAME4.m_BlnIgnoreUserInfo = false;
            this.m_txtINNAME4.m_BlnPartControl = false;
            this.m_txtINNAME4.m_BlnReadOnly = false;
            this.m_txtINNAME4.m_BlnUnderLineDST = false;
            this.m_txtINNAME4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINNAME4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINNAME4.m_IntCanModifyTime = 6;
            this.m_txtINNAME4.m_IntPartControlLength = 0;
            this.m_txtINNAME4.m_IntPartControlStartIndex = 0;
            this.m_txtINNAME4.m_StrUserID = "";
            this.m_txtINNAME4.m_StrUserName = "";
            this.m_txtINNAME4.MaxLength = 50;
            this.m_txtINNAME4.Multiline = false;
            this.m_txtINNAME4.Name = "m_txtINNAME4";
            this.m_txtINNAME4.Size = new System.Drawing.Size(78, 22);
            this.m_txtINNAME4.TabIndex = 67;
            this.m_txtINNAME4.Text = "";
            // 
            // m_txtINAMOUNT4
            // 
            this.m_txtINAMOUNT4.AccessibleDescription = "入量>>数量4";
            this.m_txtINAMOUNT4.BackColor = System.Drawing.Color.White;
            this.m_txtINAMOUNT4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINAMOUNT4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINAMOUNT4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINAMOUNT4.Location = new System.Drawing.Point(180, 200);
            this.m_txtINAMOUNT4.m_BlnIgnoreUserInfo = false;
            this.m_txtINAMOUNT4.m_BlnPartControl = false;
            this.m_txtINAMOUNT4.m_BlnReadOnly = false;
            this.m_txtINAMOUNT4.m_BlnUnderLineDST = false;
            this.m_txtINAMOUNT4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINAMOUNT4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINAMOUNT4.m_IntCanModifyTime = 6;
            this.m_txtINAMOUNT4.m_IntPartControlLength = 0;
            this.m_txtINAMOUNT4.m_IntPartControlStartIndex = 0;
            this.m_txtINAMOUNT4.m_StrUserID = "";
            this.m_txtINAMOUNT4.m_StrUserName = "";
            this.m_txtINAMOUNT4.MaxLength = 6;
            this.m_txtINAMOUNT4.Multiline = false;
            this.m_txtINAMOUNT4.Name = "m_txtINAMOUNT4";
            this.m_txtINAMOUNT4.Size = new System.Drawing.Size(48, 22);
            this.m_txtINAMOUNT4.TabIndex = 65;
            this.m_txtINAMOUNT4.Text = "";
            // 
            // m_txtINTATAL
            // 
            this.m_txtINTATAL.AccessibleDescription = "入量>>累计入量";
            this.m_txtINTATAL.BackColor = System.Drawing.Color.White;
            this.m_txtINTATAL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINTATAL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINTATAL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINTATAL.Location = new System.Drawing.Point(126, 232);
            this.m_txtINTATAL.m_BlnIgnoreUserInfo = false;
            this.m_txtINTATAL.m_BlnPartControl = false;
            this.m_txtINTATAL.m_BlnReadOnly = true;
            this.m_txtINTATAL.m_BlnUnderLineDST = false;
            this.m_txtINTATAL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINTATAL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINTATAL.m_IntCanModifyTime = 6;
            this.m_txtINTATAL.m_IntPartControlLength = 0;
            this.m_txtINTATAL.m_IntPartControlStartIndex = 0;
            this.m_txtINTATAL.m_StrUserID = "";
            this.m_txtINTATAL.m_StrUserName = "";
            this.m_txtINTATAL.MaxLength = 8000;
            this.m_txtINTATAL.Multiline = false;
            this.m_txtINTATAL.Name = "m_txtINTATAL";
            this.m_txtINTATAL.ReadOnly = true;
            this.m_txtINTATAL.Size = new System.Drawing.Size(102, 22);
            this.m_txtINTATAL.TabIndex = 0;
            this.m_txtINTATAL.Text = "";
            // 
            // label146
            // 
            this.label146.Location = new System.Drawing.Point(144, 104);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(36, 23);
            this.label146.TabIndex = 60;
            this.label146.Text = "数量";
            this.label146.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtINNAME1
            // 
            this.m_txtINNAME1.AccessibleDescription = "入量>>名称1";
            this.m_txtINNAME1.BackColor = System.Drawing.Color.White;
            this.m_txtINNAME1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINNAME1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINNAME1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINNAME1.Location = new System.Drawing.Point(66, 104);
            this.m_txtINNAME1.m_BlnIgnoreUserInfo = false;
            this.m_txtINNAME1.m_BlnPartControl = false;
            this.m_txtINNAME1.m_BlnReadOnly = false;
            this.m_txtINNAME1.m_BlnUnderLineDST = false;
            this.m_txtINNAME1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINNAME1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINNAME1.m_IntCanModifyTime = 6;
            this.m_txtINNAME1.m_IntPartControlLength = 0;
            this.m_txtINNAME1.m_IntPartControlStartIndex = 0;
            this.m_txtINNAME1.m_StrUserID = "";
            this.m_txtINNAME1.m_StrUserName = "";
            this.m_txtINNAME1.MaxLength = 50;
            this.m_txtINNAME1.Multiline = false;
            this.m_txtINNAME1.Name = "m_txtINNAME1";
            this.m_txtINNAME1.Size = new System.Drawing.Size(78, 22);
            this.m_txtINNAME1.TabIndex = 59;
            this.m_txtINNAME1.Text = "";
            // 
            // m_txtIBLOODPRO
            // 
            this.m_txtIBLOODPRO.AccessibleDescription = "入量>>累计量";
            this.m_txtIBLOODPRO.BackColor = System.Drawing.Color.White;
            this.m_txtIBLOODPRO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIBLOODPRO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtIBLOODPRO.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIBLOODPRO.Location = new System.Drawing.Point(174, 8);
            this.m_txtIBLOODPRO.m_BlnIgnoreUserInfo = false;
            this.m_txtIBLOODPRO.m_BlnPartControl = false;
            this.m_txtIBLOODPRO.m_BlnReadOnly = false;
            this.m_txtIBLOODPRO.m_BlnUnderLineDST = false;
            this.m_txtIBLOODPRO.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIBLOODPRO.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIBLOODPRO.m_IntCanModifyTime = 6;
            this.m_txtIBLOODPRO.m_IntPartControlLength = 0;
            this.m_txtIBLOODPRO.m_IntPartControlStartIndex = 0;
            this.m_txtIBLOODPRO.m_StrUserID = "";
            this.m_txtIBLOODPRO.m_StrUserName = "";
            this.m_txtIBLOODPRO.MaxLength = 50;
            this.m_txtIBLOODPRO.Multiline = false;
            this.m_txtIBLOODPRO.Name = "m_txtIBLOODPRO";
            this.m_txtIBLOODPRO.Size = new System.Drawing.Size(54, 22);
            this.m_txtIBLOODPRO.TabIndex = 58;
            this.m_txtIBLOODPRO.Text = "";
            // 
            // label142
            // 
            this.label142.BackColor = System.Drawing.Color.Black;
            this.label142.Location = new System.Drawing.Point(30, 224);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(210, 1);
            this.label142.TabIndex = 54;
            // 
            // label140
            // 
            this.label140.BackColor = System.Drawing.Color.Black;
            this.label140.Location = new System.Drawing.Point(30, 192);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(210, 1);
            this.label140.TabIndex = 51;
            // 
            // label138
            // 
            this.label138.BackColor = System.Drawing.Color.Black;
            this.label138.Location = new System.Drawing.Point(30, 160);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(210, 1);
            this.label138.TabIndex = 48;
            // 
            // label136
            // 
            this.label136.BackColor = System.Drawing.Color.Black;
            this.label136.Location = new System.Drawing.Point(30, 128);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(210, 1);
            this.label136.TabIndex = 45;
            // 
            // m_txtINAMOUNT1
            // 
            this.m_txtINAMOUNT1.AccessibleDescription = "入量>>数量1";
            this.m_txtINAMOUNT1.BackColor = System.Drawing.Color.White;
            this.m_txtINAMOUNT1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINAMOUNT1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINAMOUNT1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINAMOUNT1.Location = new System.Drawing.Point(180, 104);
            this.m_txtINAMOUNT1.m_BlnIgnoreUserInfo = false;
            this.m_txtINAMOUNT1.m_BlnPartControl = false;
            this.m_txtINAMOUNT1.m_BlnReadOnly = false;
            this.m_txtINAMOUNT1.m_BlnUnderLineDST = false;
            this.m_txtINAMOUNT1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINAMOUNT1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINAMOUNT1.m_IntCanModifyTime = 6;
            this.m_txtINAMOUNT1.m_IntPartControlLength = 0;
            this.m_txtINAMOUNT1.m_IntPartControlStartIndex = 0;
            this.m_txtINAMOUNT1.m_StrUserID = "";
            this.m_txtINAMOUNT1.m_StrUserName = "";
            this.m_txtINAMOUNT1.MaxLength = 6;
            this.m_txtINAMOUNT1.Multiline = false;
            this.m_txtINAMOUNT1.Name = "m_txtINAMOUNT1";
            this.m_txtINAMOUNT1.Size = new System.Drawing.Size(48, 22);
            this.m_txtINAMOUNT1.TabIndex = 43;
            this.m_txtINAMOUNT1.Text = "";
            // 
            // label135
            // 
            this.label135.BackColor = System.Drawing.Color.Black;
            this.label135.Location = new System.Drawing.Point(30, 96);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(210, 1);
            this.label135.TabIndex = 42;
            // 
            // m_txtIBLOODPRODUCE
            // 
            this.m_txtIBLOODPRODUCE.AccessibleDescription = "入量>>血制品";
            this.m_txtIBLOODPRODUCE.BackColor = System.Drawing.Color.White;
            this.m_txtIBLOODPRODUCE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIBLOODPRODUCE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtIBLOODPRODUCE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIBLOODPRODUCE.Location = new System.Drawing.Point(78, 8);
            this.m_txtIBLOODPRODUCE.m_BlnIgnoreUserInfo = false;
            this.m_txtIBLOODPRODUCE.m_BlnPartControl = false;
            this.m_txtIBLOODPRODUCE.m_BlnReadOnly = false;
            this.m_txtIBLOODPRODUCE.m_BlnUnderLineDST = false;
            this.m_txtIBLOODPRODUCE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIBLOODPRODUCE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIBLOODPRODUCE.m_IntCanModifyTime = 6;
            this.m_txtIBLOODPRODUCE.m_IntPartControlLength = 0;
            this.m_txtIBLOODPRODUCE.m_IntPartControlStartIndex = 0;
            this.m_txtIBLOODPRODUCE.m_StrUserID = "";
            this.m_txtIBLOODPRODUCE.m_StrUserName = "";
            this.m_txtIBLOODPRODUCE.MaxLength = 50;
            this.m_txtIBLOODPRODUCE.Multiline = false;
            this.m_txtIBLOODPRODUCE.Name = "m_txtIBLOODPRODUCE";
            this.m_txtIBLOODPRODUCE.Size = new System.Drawing.Size(42, 22);
            this.m_txtIBLOODPRODUCE.TabIndex = 40;
            this.m_txtIBLOODPRODUCE.Text = "";
            // 
            // m_txtINS
            // 
            this.m_txtINS.AccessibleDescription = "入量>>NS";
            this.m_txtINS.BackColor = System.Drawing.Color.White;
            this.m_txtINS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINS.Location = new System.Drawing.Point(144, 72);
            this.m_txtINS.m_BlnIgnoreUserInfo = false;
            this.m_txtINS.m_BlnPartControl = false;
            this.m_txtINS.m_BlnReadOnly = false;
            this.m_txtINS.m_BlnUnderLineDST = false;
            this.m_txtINS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINS.m_IntCanModifyTime = 6;
            this.m_txtINS.m_IntPartControlLength = 0;
            this.m_txtINS.m_IntPartControlStartIndex = 0;
            this.m_txtINS.m_StrUserID = "";
            this.m_txtINS.m_StrUserName = "";
            this.m_txtINS.MaxLength = 50;
            this.m_txtINS.Multiline = false;
            this.m_txtINS.Name = "m_txtINS";
            this.m_txtINS.Size = new System.Drawing.Size(84, 22);
            this.m_txtINS.TabIndex = 38;
            this.m_txtINS.Text = "";
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(36, 72);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(96, 24);
            this.label52.TabIndex = 39;
            this.label52.Text = "NS";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(30, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(1, 256);
            this.label53.TabIndex = 37;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Black;
            this.label54.Location = new System.Drawing.Point(30, 64);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(210, 1);
            this.label54.TabIndex = 36;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(30, 32);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(210, 1);
            this.label55.TabIndex = 35;
            // 
            // m_txtIGS
            // 
            this.m_txtIGS.AccessibleDescription = "入量>>GS";
            this.m_txtIGS.BackColor = System.Drawing.Color.White;
            this.m_txtIGS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIGS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtIGS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIGS.Location = new System.Drawing.Point(144, 40);
            this.m_txtIGS.m_BlnIgnoreUserInfo = false;
            this.m_txtIGS.m_BlnPartControl = false;
            this.m_txtIGS.m_BlnReadOnly = false;
            this.m_txtIGS.m_BlnUnderLineDST = false;
            this.m_txtIGS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIGS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIGS.m_IntCanModifyTime = 6;
            this.m_txtIGS.m_IntPartControlLength = 0;
            this.m_txtIGS.m_IntPartControlStartIndex = 0;
            this.m_txtIGS.m_StrUserID = "";
            this.m_txtIGS.m_StrUserName = "";
            this.m_txtIGS.MaxLength = 50;
            this.m_txtIGS.Multiline = false;
            this.m_txtIGS.Name = "m_txtIGS";
            this.m_txtIGS.Size = new System.Drawing.Size(84, 22);
            this.m_txtIGS.TabIndex = 31;
            this.m_txtIGS.Text = "";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(36, 40);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(96, 23);
            this.label56.TabIndex = 33;
            this.label56.Text = "GS";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(6, 8);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(18, 240);
            this.label57.TabIndex = 32;
            this.label57.Text = "入量";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(30, 8);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(48, 23);
            this.label51.TabIndex = 41;
            this.label51.Text = "血制品";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label144
            // 
            this.label144.Location = new System.Drawing.Point(114, 8);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(60, 23);
            this.label144.TabIndex = 57;
            this.label144.Text = "/累计量";
            this.label144.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label145
            // 
            this.label145.Location = new System.Drawing.Point(30, 200);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(36, 23);
            this.label145.TabIndex = 66;
            this.label145.Text = "名称";
            this.label145.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label137
            // 
            this.label137.Location = new System.Drawing.Point(30, 104);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(42, 23);
            this.label137.TabIndex = 44;
            this.label137.Text = "名称";
            this.label137.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label148
            // 
            this.label148.Location = new System.Drawing.Point(30, 168);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(36, 23);
            this.label148.TabIndex = 70;
            this.label148.Text = "名称";
            this.label148.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label150
            // 
            this.label150.Location = new System.Drawing.Point(30, 136);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(36, 23);
            this.label150.TabIndex = 74;
            this.label150.Text = "名称";
            this.label150.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label139
            // 
            this.label139.Location = new System.Drawing.Point(36, 232);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(84, 23);
            this.label139.TabIndex = 64;
            this.label139.Text = "累计入量:";
            this.label139.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label58);
            this.panel5.Controls.Add(this.label160);
            this.panel5.Controls.Add(this.m_txtOUTNAME4);
            this.panel5.Controls.Add(this.m_txtOUTAMOUNT4);
            this.panel5.Controls.Add(this.label162);
            this.panel5.Controls.Add(this.label157);
            this.panel5.Controls.Add(this.m_txtOUTNAME3);
            this.panel5.Controls.Add(this.label158);
            this.panel5.Controls.Add(this.m_txtOUTAMOUNT3);
            this.panel5.Controls.Add(this.label159);
            this.panel5.Controls.Add(this.label154);
            this.panel5.Controls.Add(this.m_txtOUTNAME2);
            this.panel5.Controls.Add(this.label155);
            this.panel5.Controls.Add(this.m_txtOUTAMOUNT2);
            this.panel5.Controls.Add(this.label156);
            this.panel5.Controls.Add(this.label153);
            this.panel5.Controls.Add(this.label141);
            this.panel5.Controls.Add(this.m_txtOUTNAME1);
            this.panel5.Controls.Add(this.label151);
            this.panel5.Controls.Add(this.m_txtOUTAMOUNT1);
            this.panel5.Controls.Add(this.label152);
            this.panel5.Controls.Add(this.m_txtOGASTRICJUICE);
            this.panel5.Controls.Add(this.label39);
            this.panel5.Controls.Add(this.m_txtOEMIEMCTION);
            this.panel5.Controls.Add(this.label50);
            this.panel5.Controls.Add(this.label59);
            this.panel5.Controls.Add(this.label60);
            this.panel5.Controls.Add(this.m_txtOTATAL);
            this.panel5.Controls.Add(this.label61);
            this.panel5.Controls.Add(this.label62);
            this.panel5.Location = new System.Drawing.Point(246, 44);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 228);
            this.panel5.TabIndex = 10000009;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.Black;
            this.label58.Location = new System.Drawing.Point(30, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(1, 232);
            this.label58.TabIndex = 37;
            // 
            // label160
            // 
            this.label160.Location = new System.Drawing.Point(144, 200);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(36, 23);
            this.label160.TabIndex = 81;
            this.label160.Text = "数量";
            this.label160.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtOUTNAME4
            // 
            this.m_txtOUTNAME4.AccessibleDescription = "出量>>名称4";
            this.m_txtOUTNAME4.BackColor = System.Drawing.Color.White;
            this.m_txtOUTNAME4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTNAME4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTNAME4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTNAME4.Location = new System.Drawing.Point(66, 200);
            this.m_txtOUTNAME4.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTNAME4.m_BlnPartControl = false;
            this.m_txtOUTNAME4.m_BlnReadOnly = false;
            this.m_txtOUTNAME4.m_BlnUnderLineDST = false;
            this.m_txtOUTNAME4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTNAME4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTNAME4.m_IntCanModifyTime = 6;
            this.m_txtOUTNAME4.m_IntPartControlLength = 0;
            this.m_txtOUTNAME4.m_IntPartControlStartIndex = 0;
            this.m_txtOUTNAME4.m_StrUserID = "";
            this.m_txtOUTNAME4.m_StrUserName = "";
            this.m_txtOUTNAME4.MaxLength = 50;
            this.m_txtOUTNAME4.Multiline = false;
            this.m_txtOUTNAME4.Name = "m_txtOUTNAME4";
            this.m_txtOUTNAME4.Size = new System.Drawing.Size(78, 22);
            this.m_txtOUTNAME4.TabIndex = 80;
            this.m_txtOUTNAME4.Text = "";
            // 
            // m_txtOUTAMOUNT4
            // 
            this.m_txtOUTAMOUNT4.AccessibleDescription = "出量>>数量4";
            this.m_txtOUTAMOUNT4.BackColor = System.Drawing.Color.White;
            this.m_txtOUTAMOUNT4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTAMOUNT4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTAMOUNT4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTAMOUNT4.Location = new System.Drawing.Point(180, 200);
            this.m_txtOUTAMOUNT4.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTAMOUNT4.m_BlnPartControl = false;
            this.m_txtOUTAMOUNT4.m_BlnReadOnly = false;
            this.m_txtOUTAMOUNT4.m_BlnUnderLineDST = false;
            this.m_txtOUTAMOUNT4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTAMOUNT4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTAMOUNT4.m_IntCanModifyTime = 6;
            this.m_txtOUTAMOUNT4.m_IntPartControlLength = 0;
            this.m_txtOUTAMOUNT4.m_IntPartControlStartIndex = 0;
            this.m_txtOUTAMOUNT4.m_StrUserID = "";
            this.m_txtOUTAMOUNT4.m_StrUserName = "";
            this.m_txtOUTAMOUNT4.MaxLength = 6;
            this.m_txtOUTAMOUNT4.Multiline = false;
            this.m_txtOUTAMOUNT4.Name = "m_txtOUTAMOUNT4";
            this.m_txtOUTAMOUNT4.Size = new System.Drawing.Size(48, 22);
            this.m_txtOUTAMOUNT4.TabIndex = 77;
            this.m_txtOUTAMOUNT4.Text = "";
            // 
            // label162
            // 
            this.label162.Location = new System.Drawing.Point(30, 200);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(36, 23);
            this.label162.TabIndex = 78;
            this.label162.Text = "名称";
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label157
            // 
            this.label157.Location = new System.Drawing.Point(144, 168);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(36, 23);
            this.label157.TabIndex = 76;
            this.label157.Text = "数量";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtOUTNAME3
            // 
            this.m_txtOUTNAME3.AccessibleDescription = "出量>>名称3";
            this.m_txtOUTNAME3.BackColor = System.Drawing.Color.White;
            this.m_txtOUTNAME3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTNAME3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTNAME3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTNAME3.Location = new System.Drawing.Point(66, 168);
            this.m_txtOUTNAME3.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTNAME3.m_BlnPartControl = false;
            this.m_txtOUTNAME3.m_BlnReadOnly = false;
            this.m_txtOUTNAME3.m_BlnUnderLineDST = false;
            this.m_txtOUTNAME3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTNAME3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTNAME3.m_IntCanModifyTime = 6;
            this.m_txtOUTNAME3.m_IntPartControlLength = 0;
            this.m_txtOUTNAME3.m_IntPartControlStartIndex = 0;
            this.m_txtOUTNAME3.m_StrUserID = "";
            this.m_txtOUTNAME3.m_StrUserName = "";
            this.m_txtOUTNAME3.MaxLength = 50;
            this.m_txtOUTNAME3.Multiline = false;
            this.m_txtOUTNAME3.Name = "m_txtOUTNAME3";
            this.m_txtOUTNAME3.Size = new System.Drawing.Size(78, 22);
            this.m_txtOUTNAME3.TabIndex = 75;
            this.m_txtOUTNAME3.Text = "";
            // 
            // label158
            // 
            this.label158.BackColor = System.Drawing.Color.Black;
            this.label158.Location = new System.Drawing.Point(30, 192);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(210, 1);
            this.label158.TabIndex = 74;
            // 
            // m_txtOUTAMOUNT3
            // 
            this.m_txtOUTAMOUNT3.AccessibleDescription = "出量>>数量3";
            this.m_txtOUTAMOUNT3.BackColor = System.Drawing.Color.White;
            this.m_txtOUTAMOUNT3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTAMOUNT3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTAMOUNT3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTAMOUNT3.Location = new System.Drawing.Point(180, 168);
            this.m_txtOUTAMOUNT3.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTAMOUNT3.m_BlnPartControl = false;
            this.m_txtOUTAMOUNT3.m_BlnReadOnly = false;
            this.m_txtOUTAMOUNT3.m_BlnUnderLineDST = false;
            this.m_txtOUTAMOUNT3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTAMOUNT3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTAMOUNT3.m_IntCanModifyTime = 6;
            this.m_txtOUTAMOUNT3.m_IntPartControlLength = 0;
            this.m_txtOUTAMOUNT3.m_IntPartControlStartIndex = 0;
            this.m_txtOUTAMOUNT3.m_StrUserID = "";
            this.m_txtOUTAMOUNT3.m_StrUserName = "";
            this.m_txtOUTAMOUNT3.MaxLength = 6;
            this.m_txtOUTAMOUNT3.Multiline = false;
            this.m_txtOUTAMOUNT3.Name = "m_txtOUTAMOUNT3";
            this.m_txtOUTAMOUNT3.Size = new System.Drawing.Size(48, 22);
            this.m_txtOUTAMOUNT3.TabIndex = 72;
            this.m_txtOUTAMOUNT3.Text = "";
            // 
            // label159
            // 
            this.label159.Location = new System.Drawing.Point(30, 168);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(36, 23);
            this.label159.TabIndex = 73;
            this.label159.Text = "名称";
            this.label159.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label154
            // 
            this.label154.Location = new System.Drawing.Point(144, 136);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(36, 23);
            this.label154.TabIndex = 71;
            this.label154.Text = "数量";
            this.label154.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtOUTNAME2
            // 
            this.m_txtOUTNAME2.AccessibleDescription = "出量>>名称2";
            this.m_txtOUTNAME2.BackColor = System.Drawing.Color.White;
            this.m_txtOUTNAME2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTNAME2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTNAME2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTNAME2.Location = new System.Drawing.Point(66, 136);
            this.m_txtOUTNAME2.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTNAME2.m_BlnPartControl = false;
            this.m_txtOUTNAME2.m_BlnReadOnly = false;
            this.m_txtOUTNAME2.m_BlnUnderLineDST = false;
            this.m_txtOUTNAME2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTNAME2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTNAME2.m_IntCanModifyTime = 6;
            this.m_txtOUTNAME2.m_IntPartControlLength = 0;
            this.m_txtOUTNAME2.m_IntPartControlStartIndex = 0;
            this.m_txtOUTNAME2.m_StrUserID = "";
            this.m_txtOUTNAME2.m_StrUserName = "";
            this.m_txtOUTNAME2.MaxLength = 50;
            this.m_txtOUTNAME2.Multiline = false;
            this.m_txtOUTNAME2.Name = "m_txtOUTNAME2";
            this.m_txtOUTNAME2.Size = new System.Drawing.Size(78, 22);
            this.m_txtOUTNAME2.TabIndex = 70;
            this.m_txtOUTNAME2.Text = "";
            // 
            // label155
            // 
            this.label155.BackColor = System.Drawing.Color.Black;
            this.label155.Location = new System.Drawing.Point(30, 160);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(210, 1);
            this.label155.TabIndex = 69;
            // 
            // m_txtOUTAMOUNT2
            // 
            this.m_txtOUTAMOUNT2.AccessibleDescription = "出量>>数量2";
            this.m_txtOUTAMOUNT2.BackColor = System.Drawing.Color.White;
            this.m_txtOUTAMOUNT2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTAMOUNT2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTAMOUNT2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTAMOUNT2.Location = new System.Drawing.Point(180, 136);
            this.m_txtOUTAMOUNT2.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTAMOUNT2.m_BlnPartControl = false;
            this.m_txtOUTAMOUNT2.m_BlnReadOnly = false;
            this.m_txtOUTAMOUNT2.m_BlnUnderLineDST = false;
            this.m_txtOUTAMOUNT2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTAMOUNT2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTAMOUNT2.m_IntCanModifyTime = 6;
            this.m_txtOUTAMOUNT2.m_IntPartControlLength = 0;
            this.m_txtOUTAMOUNT2.m_IntPartControlStartIndex = 0;
            this.m_txtOUTAMOUNT2.m_StrUserID = "";
            this.m_txtOUTAMOUNT2.m_StrUserName = "";
            this.m_txtOUTAMOUNT2.MaxLength = 6;
            this.m_txtOUTAMOUNT2.Multiline = false;
            this.m_txtOUTAMOUNT2.Name = "m_txtOUTAMOUNT2";
            this.m_txtOUTAMOUNT2.Size = new System.Drawing.Size(48, 22);
            this.m_txtOUTAMOUNT2.TabIndex = 67;
            this.m_txtOUTAMOUNT2.Text = "";
            // 
            // label156
            // 
            this.label156.Location = new System.Drawing.Point(30, 136);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(36, 23);
            this.label156.TabIndex = 68;
            this.label156.Text = "名称";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label153
            // 
            this.label153.BackColor = System.Drawing.Color.Black;
            this.label153.Location = new System.Drawing.Point(30, 96);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(210, 1);
            this.label153.TabIndex = 66;
            // 
            // label141
            // 
            this.label141.Location = new System.Drawing.Point(144, 104);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(36, 23);
            this.label141.TabIndex = 65;
            this.label141.Text = "数量";
            this.label141.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtOUTNAME1
            // 
            this.m_txtOUTNAME1.AccessibleDescription = "出量>>名称1";
            this.m_txtOUTNAME1.BackColor = System.Drawing.Color.White;
            this.m_txtOUTNAME1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTNAME1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTNAME1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTNAME1.Location = new System.Drawing.Point(66, 104);
            this.m_txtOUTNAME1.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTNAME1.m_BlnPartControl = false;
            this.m_txtOUTNAME1.m_BlnReadOnly = false;
            this.m_txtOUTNAME1.m_BlnUnderLineDST = false;
            this.m_txtOUTNAME1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTNAME1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTNAME1.m_IntCanModifyTime = 6;
            this.m_txtOUTNAME1.m_IntPartControlLength = 0;
            this.m_txtOUTNAME1.m_IntPartControlStartIndex = 0;
            this.m_txtOUTNAME1.m_StrUserID = "";
            this.m_txtOUTNAME1.m_StrUserName = "";
            this.m_txtOUTNAME1.MaxLength = 50;
            this.m_txtOUTNAME1.Multiline = false;
            this.m_txtOUTNAME1.Name = "m_txtOUTNAME1";
            this.m_txtOUTNAME1.Size = new System.Drawing.Size(78, 22);
            this.m_txtOUTNAME1.TabIndex = 64;
            this.m_txtOUTNAME1.Text = "";
            // 
            // label151
            // 
            this.label151.BackColor = System.Drawing.Color.Black;
            this.label151.Location = new System.Drawing.Point(30, 128);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(210, 1);
            this.label151.TabIndex = 63;
            // 
            // m_txtOUTAMOUNT1
            // 
            this.m_txtOUTAMOUNT1.AccessibleDescription = "出量>>数量1";
            this.m_txtOUTAMOUNT1.BackColor = System.Drawing.Color.White;
            this.m_txtOUTAMOUNT1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOUTAMOUNT1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOUTAMOUNT1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOUTAMOUNT1.Location = new System.Drawing.Point(180, 104);
            this.m_txtOUTAMOUNT1.m_BlnIgnoreUserInfo = false;
            this.m_txtOUTAMOUNT1.m_BlnPartControl = false;
            this.m_txtOUTAMOUNT1.m_BlnReadOnly = false;
            this.m_txtOUTAMOUNT1.m_BlnUnderLineDST = false;
            this.m_txtOUTAMOUNT1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOUTAMOUNT1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOUTAMOUNT1.m_IntCanModifyTime = 6;
            this.m_txtOUTAMOUNT1.m_IntPartControlLength = 0;
            this.m_txtOUTAMOUNT1.m_IntPartControlStartIndex = 0;
            this.m_txtOUTAMOUNT1.m_StrUserID = "";
            this.m_txtOUTAMOUNT1.m_StrUserName = "";
            this.m_txtOUTAMOUNT1.MaxLength = 6;
            this.m_txtOUTAMOUNT1.Multiline = false;
            this.m_txtOUTAMOUNT1.Name = "m_txtOUTAMOUNT1";
            this.m_txtOUTAMOUNT1.Size = new System.Drawing.Size(48, 22);
            this.m_txtOUTAMOUNT1.TabIndex = 61;
            this.m_txtOUTAMOUNT1.Text = "";
            // 
            // label152
            // 
            this.label152.Location = new System.Drawing.Point(30, 104);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(36, 23);
            this.label152.TabIndex = 62;
            this.label152.Text = "名称";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtOGASTRICJUICE
            // 
            this.m_txtOGASTRICJUICE.AccessibleDescription = "出量>>胃液";
            this.m_txtOGASTRICJUICE.BackColor = System.Drawing.Color.White;
            this.m_txtOGASTRICJUICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOGASTRICJUICE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOGASTRICJUICE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOGASTRICJUICE.Location = new System.Drawing.Point(144, 72);
            this.m_txtOGASTRICJUICE.m_BlnIgnoreUserInfo = false;
            this.m_txtOGASTRICJUICE.m_BlnPartControl = false;
            this.m_txtOGASTRICJUICE.m_BlnReadOnly = false;
            this.m_txtOGASTRICJUICE.m_BlnUnderLineDST = false;
            this.m_txtOGASTRICJUICE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOGASTRICJUICE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOGASTRICJUICE.m_IntCanModifyTime = 6;
            this.m_txtOGASTRICJUICE.m_IntPartControlLength = 0;
            this.m_txtOGASTRICJUICE.m_IntPartControlStartIndex = 0;
            this.m_txtOGASTRICJUICE.m_StrUserID = "";
            this.m_txtOGASTRICJUICE.m_StrUserName = "";
            this.m_txtOGASTRICJUICE.MaxLength = 6;
            this.m_txtOGASTRICJUICE.Multiline = false;
            this.m_txtOGASTRICJUICE.Name = "m_txtOGASTRICJUICE";
            this.m_txtOGASTRICJUICE.Size = new System.Drawing.Size(84, 22);
            this.m_txtOGASTRICJUICE.TabIndex = 40;
            this.m_txtOGASTRICJUICE.Text = "";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(36, 72);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(100, 23);
            this.label39.TabIndex = 41;
            this.label39.Text = "胃液";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtOEMIEMCTION
            // 
            this.m_txtOEMIEMCTION.AccessibleDescription = "出量>>尿量";
            this.m_txtOEMIEMCTION.BackColor = System.Drawing.Color.White;
            this.m_txtOEMIEMCTION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOEMIEMCTION.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOEMIEMCTION.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOEMIEMCTION.Location = new System.Drawing.Point(144, 40);
            this.m_txtOEMIEMCTION.m_BlnIgnoreUserInfo = false;
            this.m_txtOEMIEMCTION.m_BlnPartControl = false;
            this.m_txtOEMIEMCTION.m_BlnReadOnly = false;
            this.m_txtOEMIEMCTION.m_BlnUnderLineDST = false;
            this.m_txtOEMIEMCTION.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOEMIEMCTION.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOEMIEMCTION.m_IntCanModifyTime = 6;
            this.m_txtOEMIEMCTION.m_IntPartControlLength = 0;
            this.m_txtOEMIEMCTION.m_IntPartControlStartIndex = 0;
            this.m_txtOEMIEMCTION.m_StrUserID = "";
            this.m_txtOEMIEMCTION.m_StrUserName = "";
            this.m_txtOEMIEMCTION.MaxLength = 6;
            this.m_txtOEMIEMCTION.Multiline = false;
            this.m_txtOEMIEMCTION.Name = "m_txtOEMIEMCTION";
            this.m_txtOEMIEMCTION.Size = new System.Drawing.Size(84, 22);
            this.m_txtOEMIEMCTION.TabIndex = 38;
            this.m_txtOEMIEMCTION.Text = "";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(36, 40);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(96, 24);
            this.label50.TabIndex = 39;
            this.label50.Text = "尿量";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Black;
            this.label59.Location = new System.Drawing.Point(30, 64);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(210, 1);
            this.label59.TabIndex = 36;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(30, 32);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(210, 1);
            this.label60.TabIndex = 35;
            // 
            // m_txtOTATAL
            // 
            this.m_txtOTATAL.AccessibleDescription = "出量>>累计出量";
            this.m_txtOTATAL.BackColor = System.Drawing.Color.White;
            this.m_txtOTATAL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOTATAL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOTATAL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOTATAL.Location = new System.Drawing.Point(144, 8);
            this.m_txtOTATAL.m_BlnIgnoreUserInfo = false;
            this.m_txtOTATAL.m_BlnPartControl = false;
            this.m_txtOTATAL.m_BlnReadOnly = true;
            this.m_txtOTATAL.m_BlnUnderLineDST = false;
            this.m_txtOTATAL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOTATAL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOTATAL.m_IntCanModifyTime = 6;
            this.m_txtOTATAL.m_IntPartControlLength = 0;
            this.m_txtOTATAL.m_IntPartControlStartIndex = 0;
            this.m_txtOTATAL.m_StrUserID = "";
            this.m_txtOTATAL.m_StrUserName = "";
            this.m_txtOTATAL.MaxLength = 8000;
            this.m_txtOTATAL.Multiline = false;
            this.m_txtOTATAL.Name = "m_txtOTATAL";
            this.m_txtOTATAL.ReadOnly = true;
            this.m_txtOTATAL.Size = new System.Drawing.Size(84, 22);
            this.m_txtOTATAL.TabIndex = 0;
            this.m_txtOTATAL.Text = "";
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(36, 8);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(100, 23);
            this.label61.TabIndex = 33;
            this.label61.Text = "累计出量:";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label62
            // 
            this.label62.AccessibleDescription = "出量>>";
            this.label62.Location = new System.Drawing.Point(6, 8);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(18, 224);
            this.label62.TabIndex = 32;
            this.label62.Text = "出量";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.m_txtSESPECIALLYNOTE);
            this.panel6.Controls.Add(this.label65);
            this.panel6.Controls.Add(this.label69);
            this.panel6.Location = new System.Drawing.Point(246, 272);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(240, 96);
            this.panel6.TabIndex = 10000010;
            // 
            // m_txtSESPECIALLYNOTE
            // 
            this.m_txtSESPECIALLYNOTE.AccessibleDescription = "特殊记录";
            this.m_txtSESPECIALLYNOTE.BackColor = System.Drawing.Color.White;
            this.m_txtSESPECIALLYNOTE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSESPECIALLYNOTE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSESPECIALLYNOTE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSESPECIALLYNOTE.Location = new System.Drawing.Point(36, 8);
            this.m_txtSESPECIALLYNOTE.m_BlnIgnoreUserInfo = false;
            this.m_txtSESPECIALLYNOTE.m_BlnPartControl = false;
            this.m_txtSESPECIALLYNOTE.m_BlnReadOnly = false;
            this.m_txtSESPECIALLYNOTE.m_BlnUnderLineDST = false;
            this.m_txtSESPECIALLYNOTE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSESPECIALLYNOTE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSESPECIALLYNOTE.m_IntCanModifyTime = 6;
            this.m_txtSESPECIALLYNOTE.m_IntPartControlLength = 0;
            this.m_txtSESPECIALLYNOTE.m_IntPartControlStartIndex = 0;
            this.m_txtSESPECIALLYNOTE.m_StrUserID = "";
            this.m_txtSESPECIALLYNOTE.m_StrUserName = "";
            this.m_txtSESPECIALLYNOTE.MaxLength = 2000;
            this.m_txtSESPECIALLYNOTE.Name = "m_txtSESPECIALLYNOTE";
            this.m_txtSESPECIALLYNOTE.Size = new System.Drawing.Size(192, 80);
            this.m_txtSESPECIALLYNOTE.TabIndex = 1101;
            this.m_txtSESPECIALLYNOTE.Text = "";
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Black;
            this.label65.Location = new System.Drawing.Point(30, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(1, 138);
            this.label65.TabIndex = 37;
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(6, 8);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(18, 80);
            this.label69.TabIndex = 32;
            this.label69.Text = "特殊记录";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label79);
            this.panel7.Controls.Add(this.label108);
            this.panel7.Controls.Add(this.label169);
            this.panel7.Controls.Add(this.label168);
            this.panel7.Controls.Add(this.label167);
            this.panel7.Controls.Add(this.label75);
            this.panel7.Controls.Add(this.label166);
            this.panel7.Controls.Add(this.label64);
            this.panel7.Controls.Add(this.label165);
            this.panel7.Controls.Add(this.m_txtTO2CT);
            this.panel7.Controls.Add(this.label82);
            this.panel7.Controls.Add(this.label83);
            this.panel7.Controls.Add(this.m_txtTSAT);
            this.panel7.Controls.Add(this.label80);
            this.panel7.Controls.Add(this.label81);
            this.panel7.Controls.Add(this.m_txtTBE);
            this.panel7.Controls.Add(this.label78);
            this.panel7.Controls.Add(this.m_txtTTCO2);
            this.panel7.Controls.Add(this.label76);
            this.panel7.Controls.Add(this.label77);
            this.panel7.Controls.Add(this.m_txtTHCO3);
            this.panel7.Controls.Add(this.label74);
            this.panel7.Controls.Add(this.m_txtTP02);
            this.panel7.Controls.Add(this.label63);
            this.panel7.Controls.Add(this.m_txtTPCO2);
            this.panel7.Controls.Add(this.label66);
            this.panel7.Controls.Add(this.m_txtTPH);
            this.panel7.Controls.Add(this.label67);
            this.panel7.Controls.Add(this.label68);
            this.panel7.Controls.Add(this.label70);
            this.panel7.Controls.Add(this.label71);
            this.panel7.Controls.Add(this.m_txtTCOLLECTBLOODPOINT);
            this.panel7.Controls.Add(this.label72);
            this.panel7.Controls.Add(this.label73);
            this.panel7.Location = new System.Drawing.Point(486, 44);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 324);
            this.panel7.TabIndex = 10000011;
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.Black;
            this.label79.Location = new System.Drawing.Point(30, 192);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(210, 1);
            this.label79.TabIndex = 51;
            // 
            // label108
            // 
            this.label108.BackColor = System.Drawing.Color.Black;
            this.label108.Location = new System.Drawing.Point(30, 288);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(210, 1);
            this.label108.TabIndex = 60;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label169.Location = new System.Drawing.Point(84, 272);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(11, 12);
            this.label169.TabIndex = 61;
            this.label169.Text = "2";
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label168.Location = new System.Drawing.Point(78, 177);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(11, 12);
            this.label168.TabIndex = 61;
            this.label168.Text = "2";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label167.Location = new System.Drawing.Point(78, 143);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(11, 12);
            this.label167.TabIndex = 61;
            this.label167.Text = "3";
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.Black;
            this.label75.Location = new System.Drawing.Point(30, 128);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(210, 1);
            this.label75.TabIndex = 45;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label166.Location = new System.Drawing.Point(78, 112);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(11, 12);
            this.label166.TabIndex = 61;
            this.label166.Text = "2";
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.Black;
            this.label64.Location = new System.Drawing.Point(30, 96);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(210, 1);
            this.label64.TabIndex = 42;
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label165.Location = new System.Drawing.Point(84, 80);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(11, 12);
            this.label165.TabIndex = 61;
            this.label165.Text = "2";
            // 
            // m_txtTO2CT
            // 
            this.m_txtTO2CT.AccessibleDescription = "实验室检查>>Q2CT";
            this.m_txtTO2CT.BackColor = System.Drawing.Color.White;
            this.m_txtTO2CT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTO2CT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTO2CT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTO2CT.Location = new System.Drawing.Point(144, 264);
            this.m_txtTO2CT.m_BlnIgnoreUserInfo = false;
            this.m_txtTO2CT.m_BlnPartControl = false;
            this.m_txtTO2CT.m_BlnReadOnly = false;
            this.m_txtTO2CT.m_BlnUnderLineDST = false;
            this.m_txtTO2CT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTO2CT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTO2CT.m_IntCanModifyTime = 6;
            this.m_txtTO2CT.m_IntPartControlLength = 0;
            this.m_txtTO2CT.m_IntPartControlStartIndex = 0;
            this.m_txtTO2CT.m_StrUserID = "";
            this.m_txtTO2CT.m_StrUserName = "";
            this.m_txtTO2CT.MaxLength = 250;
            this.m_txtTO2CT.Multiline = false;
            this.m_txtTO2CT.Name = "m_txtTO2CT";
            this.m_txtTO2CT.Size = new System.Drawing.Size(84, 22);
            this.m_txtTO2CT.TabIndex = 58;
            this.m_txtTO2CT.Text = "";
            // 
            // label82
            // 
            this.label82.Location = new System.Drawing.Point(36, 264);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(114, 23);
            this.label82.TabIndex = 59;
            this.label82.Text = "Q  CT";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.Black;
            this.label83.Location = new System.Drawing.Point(30, 256);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(210, 1);
            this.label83.TabIndex = 57;
            // 
            // m_txtTSAT
            // 
            this.m_txtTSAT.AccessibleDescription = "实验室检查>>SAT(Cr)";
            this.m_txtTSAT.BackColor = System.Drawing.Color.White;
            this.m_txtTSAT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTSAT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTSAT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTSAT.Location = new System.Drawing.Point(144, 232);
            this.m_txtTSAT.m_BlnIgnoreUserInfo = false;
            this.m_txtTSAT.m_BlnPartControl = false;
            this.m_txtTSAT.m_BlnReadOnly = false;
            this.m_txtTSAT.m_BlnUnderLineDST = false;
            this.m_txtTSAT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTSAT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTSAT.m_IntCanModifyTime = 6;
            this.m_txtTSAT.m_IntPartControlLength = 0;
            this.m_txtTSAT.m_IntPartControlStartIndex = 0;
            this.m_txtTSAT.m_StrUserID = "";
            this.m_txtTSAT.m_StrUserName = "";
            this.m_txtTSAT.MaxLength = 250;
            this.m_txtTSAT.Multiline = false;
            this.m_txtTSAT.Name = "m_txtTSAT";
            this.m_txtTSAT.Size = new System.Drawing.Size(84, 22);
            this.m_txtTSAT.TabIndex = 55;
            this.m_txtTSAT.Text = "";
            // 
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.Location = new System.Drawing.Point(36, 232);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(114, 23);
            this.label80.TabIndex = 56;
            this.label80.Text = "SAT(Cr)";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Black;
            this.label81.Location = new System.Drawing.Point(30, 224);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(210, 1);
            this.label81.TabIndex = 54;
            // 
            // m_txtTBE
            // 
            this.m_txtTBE.AccessibleDescription = "实验室检查>>BE(Bun)";
            this.m_txtTBE.BackColor = System.Drawing.Color.White;
            this.m_txtTBE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTBE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTBE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTBE.Location = new System.Drawing.Point(144, 200);
            this.m_txtTBE.m_BlnIgnoreUserInfo = false;
            this.m_txtTBE.m_BlnPartControl = false;
            this.m_txtTBE.m_BlnReadOnly = false;
            this.m_txtTBE.m_BlnUnderLineDST = false;
            this.m_txtTBE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTBE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTBE.m_IntCanModifyTime = 6;
            this.m_txtTBE.m_IntPartControlLength = 0;
            this.m_txtTBE.m_IntPartControlStartIndex = 0;
            this.m_txtTBE.m_StrUserID = "";
            this.m_txtTBE.m_StrUserName = "";
            this.m_txtTBE.MaxLength = 250;
            this.m_txtTBE.Multiline = false;
            this.m_txtTBE.Name = "m_txtTBE";
            this.m_txtTBE.Size = new System.Drawing.Size(84, 22);
            this.m_txtTBE.TabIndex = 52;
            this.m_txtTBE.Text = "";
            // 
            // label78
            // 
            this.label78.Location = new System.Drawing.Point(36, 200);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(114, 23);
            this.label78.TabIndex = 53;
            this.label78.Text = "BE(Bun)";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTTCO2
            // 
            this.m_txtTTCO2.AccessibleDescription = "实验室检查>>TCQ2(Ca++)";
            this.m_txtTTCO2.BackColor = System.Drawing.Color.White;
            this.m_txtTTCO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTTCO2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTTCO2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTTCO2.Location = new System.Drawing.Point(144, 168);
            this.m_txtTTCO2.m_BlnIgnoreUserInfo = false;
            this.m_txtTTCO2.m_BlnPartControl = false;
            this.m_txtTTCO2.m_BlnReadOnly = false;
            this.m_txtTTCO2.m_BlnUnderLineDST = false;
            this.m_txtTTCO2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTTCO2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTTCO2.m_IntCanModifyTime = 6;
            this.m_txtTTCO2.m_IntPartControlLength = 0;
            this.m_txtTTCO2.m_IntPartControlStartIndex = 0;
            this.m_txtTTCO2.m_StrUserID = "";
            this.m_txtTTCO2.m_StrUserName = "";
            this.m_txtTTCO2.MaxLength = 250;
            this.m_txtTTCO2.Multiline = false;
            this.m_txtTTCO2.Name = "m_txtTTCO2";
            this.m_txtTTCO2.Size = new System.Drawing.Size(84, 22);
            this.m_txtTTCO2.TabIndex = 49;
            this.m_txtTTCO2.Text = "";
            // 
            // label76
            // 
            this.label76.Location = new System.Drawing.Point(36, 168);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(114, 23);
            this.label76.TabIndex = 50;
            this.label76.Text = "TCQ  (Ca++)";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.Black;
            this.label77.Location = new System.Drawing.Point(30, 160);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(210, 1);
            this.label77.TabIndex = 48;
            // 
            // m_txtTHCO3
            // 
            this.m_txtTHCO3.AccessibleDescription = "实验室检查>>HCQ3(CLˉ)";
            this.m_txtTHCO3.BackColor = System.Drawing.Color.White;
            this.m_txtTHCO3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTHCO3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTHCO3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTHCO3.Location = new System.Drawing.Point(144, 136);
            this.m_txtTHCO3.m_BlnIgnoreUserInfo = false;
            this.m_txtTHCO3.m_BlnPartControl = false;
            this.m_txtTHCO3.m_BlnReadOnly = false;
            this.m_txtTHCO3.m_BlnUnderLineDST = false;
            this.m_txtTHCO3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTHCO3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTHCO3.m_IntCanModifyTime = 6;
            this.m_txtTHCO3.m_IntPartControlLength = 0;
            this.m_txtTHCO3.m_IntPartControlStartIndex = 0;
            this.m_txtTHCO3.m_StrUserID = "";
            this.m_txtTHCO3.m_StrUserName = "";
            this.m_txtTHCO3.MaxLength = 250;
            this.m_txtTHCO3.Multiline = false;
            this.m_txtTHCO3.Name = "m_txtTHCO3";
            this.m_txtTHCO3.Size = new System.Drawing.Size(84, 22);
            this.m_txtTHCO3.TabIndex = 46;
            this.m_txtTHCO3.Text = "";
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(54, 128);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(84, 32);
            this.label74.TabIndex = 47;
            this.label74.Text = "HCQ  (CLˉ)";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTP02
            // 
            this.m_txtTP02.AccessibleDescription = "实验室检查>>PQ2(Na+)";
            this.m_txtTP02.BackColor = System.Drawing.Color.White;
            this.m_txtTP02.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTP02.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTP02.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTP02.Location = new System.Drawing.Point(144, 104);
            this.m_txtTP02.m_BlnIgnoreUserInfo = false;
            this.m_txtTP02.m_BlnPartControl = false;
            this.m_txtTP02.m_BlnReadOnly = false;
            this.m_txtTP02.m_BlnUnderLineDST = false;
            this.m_txtTP02.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTP02.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTP02.m_IntCanModifyTime = 6;
            this.m_txtTP02.m_IntPartControlLength = 0;
            this.m_txtTP02.m_IntPartControlStartIndex = 0;
            this.m_txtTP02.m_StrUserID = "";
            this.m_txtTP02.m_StrUserName = "";
            this.m_txtTP02.MaxLength = 250;
            this.m_txtTP02.Multiline = false;
            this.m_txtTP02.Name = "m_txtTP02";
            this.m_txtTP02.Size = new System.Drawing.Size(84, 22);
            this.m_txtTP02.TabIndex = 43;
            this.m_txtTP02.Text = "";
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(36, 104);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(114, 23);
            this.label63.TabIndex = 44;
            this.label63.Text = "PQ  (Na+)";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTPCO2
            // 
            this.m_txtTPCO2.AccessibleDescription = "实验室检查>>PCQ2(K+)";
            this.m_txtTPCO2.BackColor = System.Drawing.Color.White;
            this.m_txtTPCO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTPCO2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTPCO2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTPCO2.Location = new System.Drawing.Point(144, 72);
            this.m_txtTPCO2.m_BlnIgnoreUserInfo = false;
            this.m_txtTPCO2.m_BlnPartControl = false;
            this.m_txtTPCO2.m_BlnReadOnly = false;
            this.m_txtTPCO2.m_BlnUnderLineDST = false;
            this.m_txtTPCO2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTPCO2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTPCO2.m_IntCanModifyTime = 6;
            this.m_txtTPCO2.m_IntPartControlLength = 0;
            this.m_txtTPCO2.m_IntPartControlStartIndex = 0;
            this.m_txtTPCO2.m_StrUserID = "";
            this.m_txtTPCO2.m_StrUserName = "";
            this.m_txtTPCO2.MaxLength = 250;
            this.m_txtTPCO2.Multiline = false;
            this.m_txtTPCO2.Name = "m_txtTPCO2";
            this.m_txtTPCO2.Size = new System.Drawing.Size(84, 22);
            this.m_txtTPCO2.TabIndex = 40;
            this.m_txtTPCO2.Text = "";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(42, 72);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(102, 23);
            this.label66.TabIndex = 41;
            this.label66.Text = "PCQ  (K+)";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTPH
            // 
            this.m_txtTPH.AccessibleDescription = "实验室检查>>PH";
            this.m_txtTPH.BackColor = System.Drawing.Color.White;
            this.m_txtTPH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTPH.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTPH.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTPH.Location = new System.Drawing.Point(144, 40);
            this.m_txtTPH.m_BlnIgnoreUserInfo = false;
            this.m_txtTPH.m_BlnPartControl = false;
            this.m_txtTPH.m_BlnReadOnly = false;
            this.m_txtTPH.m_BlnUnderLineDST = false;
            this.m_txtTPH.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTPH.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTPH.m_IntCanModifyTime = 6;
            this.m_txtTPH.m_IntPartControlLength = 0;
            this.m_txtTPH.m_IntPartControlStartIndex = 0;
            this.m_txtTPH.m_StrUserID = "";
            this.m_txtTPH.m_StrUserName = "";
            this.m_txtTPH.MaxLength = 250;
            this.m_txtTPH.Multiline = false;
            this.m_txtTPH.Name = "m_txtTPH";
            this.m_txtTPH.Size = new System.Drawing.Size(84, 22);
            this.m_txtTPH.TabIndex = 38;
            this.m_txtTPH.Text = "";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(36, 40);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(96, 24);
            this.label67.TabIndex = 39;
            this.label67.Text = "PH";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.Color.Black;
            this.label68.Location = new System.Drawing.Point(30, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(1, 330);
            this.label68.TabIndex = 37;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(30, 64);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(210, 1);
            this.label70.TabIndex = 36;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Black;
            this.label71.Location = new System.Drawing.Point(30, 32);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(210, 1);
            this.label71.TabIndex = 35;
            // 
            // m_txtTCOLLECTBLOODPOINT
            // 
            this.m_txtTCOLLECTBLOODPOINT.AccessibleDescription = "实验室检查>>采血点";
            this.m_txtTCOLLECTBLOODPOINT.BackColor = System.Drawing.Color.White;
            this.m_txtTCOLLECTBLOODPOINT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTCOLLECTBLOODPOINT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTCOLLECTBLOODPOINT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTCOLLECTBLOODPOINT.Location = new System.Drawing.Point(144, 8);
            this.m_txtTCOLLECTBLOODPOINT.m_BlnIgnoreUserInfo = false;
            this.m_txtTCOLLECTBLOODPOINT.m_BlnPartControl = false;
            this.m_txtTCOLLECTBLOODPOINT.m_BlnReadOnly = false;
            this.m_txtTCOLLECTBLOODPOINT.m_BlnUnderLineDST = false;
            this.m_txtTCOLLECTBLOODPOINT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTCOLLECTBLOODPOINT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTCOLLECTBLOODPOINT.m_IntCanModifyTime = 6;
            this.m_txtTCOLLECTBLOODPOINT.m_IntPartControlLength = 0;
            this.m_txtTCOLLECTBLOODPOINT.m_IntPartControlStartIndex = 0;
            this.m_txtTCOLLECTBLOODPOINT.m_StrUserID = "";
            this.m_txtTCOLLECTBLOODPOINT.m_StrUserName = "";
            this.m_txtTCOLLECTBLOODPOINT.MaxLength = 250;
            this.m_txtTCOLLECTBLOODPOINT.Multiline = false;
            this.m_txtTCOLLECTBLOODPOINT.Name = "m_txtTCOLLECTBLOODPOINT";
            this.m_txtTCOLLECTBLOODPOINT.Size = new System.Drawing.Size(84, 22);
            this.m_txtTCOLLECTBLOODPOINT.TabIndex = 31;
            this.m_txtTCOLLECTBLOODPOINT.Text = "";
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(36, 8);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(100, 23);
            this.label72.TabIndex = 33;
            this.label72.Text = "采血点";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(6, 8);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(18, 312);
            this.label73.TabIndex = 32;
            this.label73.Text = "实验室检查";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label171);
            this.panel8.Controls.Add(this.label170);
            this.panel8.Controls.Add(this.m_txtBFI02PEEPRIGHT);
            this.panel8.Controls.Add(this.m_txtBPHLEGMAMOUNT);
            this.panel8.Controls.Add(this.label161);
            this.panel8.Controls.Add(this.m_txtBSQ2);
            this.panel8.Controls.Add(this.label109);
            this.panel8.Controls.Add(this.label85);
            this.panel8.Controls.Add(this.m_txtBPHLEGMCOLOR);
            this.panel8.Controls.Add(this.label84);
            this.panel8.Controls.Add(this.label86);
            this.panel8.Controls.Add(this.m_txtBBLUSESOUND);
            this.panel8.Controls.Add(this.label87);
            this.panel8.Controls.Add(this.label88);
            this.panel8.Controls.Add(this.m_txtBMAXIP);
            this.panel8.Controls.Add(this.label89);
            this.panel8.Controls.Add(this.label90);
            this.panel8.Controls.Add(this.m_txtBFIO2PEEP);
            this.panel8.Controls.Add(this.label92);
            this.panel8.Controls.Add(this.m_txtBBLUSENUM);
            this.panel8.Controls.Add(this.label93);
            this.panel8.Controls.Add(this.label94);
            this.panel8.Controls.Add(this.m_txtBBLUESPRESSURE);
            this.panel8.Controls.Add(this.label95);
            this.panel8.Controls.Add(this.label96);
            this.panel8.Controls.Add(this.m_txtBEXPIREDMV);
            this.panel8.Controls.Add(this.label97);
            this.panel8.Controls.Add(this.m_txtBVT);
            this.panel8.Controls.Add(this.label98);
            this.panel8.Controls.Add(this.label99);
            this.panel8.Controls.Add(this.m_txtBBLUSEMODE);
            this.panel8.Controls.Add(this.label100);
            this.panel8.Controls.Add(this.m_txtBBLUSEMACHINETYPE);
            this.panel8.Controls.Add(this.label101);
            this.panel8.Controls.Add(this.label102);
            this.panel8.Controls.Add(this.label103);
            this.panel8.Controls.Add(this.label104);
            this.panel8.Controls.Add(this.m_txtBBLUSETIME);
            this.panel8.Controls.Add(this.label105);
            this.panel8.Controls.Add(this.label106);
            this.panel8.Controls.Add(this.label107);
            this.panel8.Controls.Add(this.label91);
            this.panel8.Controls.Add(this.label163);
            this.panel8.Location = new System.Drawing.Point(726, 44);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(240, 388);
            this.panel8.TabIndex = 10000012;
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label171.Location = new System.Drawing.Point(85, 368);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(11, 11);
            this.label171.TabIndex = 61;
            this.label171.Text = "2";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label170.Location = new System.Drawing.Point(57, 240);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(11, 11);
            this.label170.TabIndex = 61;
            this.label170.Text = "2";
            // 
            // m_txtBFI02PEEPRIGHT
            // 
            this.m_txtBFI02PEEPRIGHT.AccessibleDescription = "呼吸系统>>PEEP";
            this.m_txtBFI02PEEPRIGHT.BackColor = System.Drawing.Color.White;
            this.m_txtBFI02PEEPRIGHT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBFI02PEEPRIGHT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBFI02PEEPRIGHT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBFI02PEEPRIGHT.Location = new System.Drawing.Point(174, 232);
            this.m_txtBFI02PEEPRIGHT.m_BlnIgnoreUserInfo = false;
            this.m_txtBFI02PEEPRIGHT.m_BlnPartControl = false;
            this.m_txtBFI02PEEPRIGHT.m_BlnReadOnly = false;
            this.m_txtBFI02PEEPRIGHT.m_BlnUnderLineDST = false;
            this.m_txtBFI02PEEPRIGHT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBFI02PEEPRIGHT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBFI02PEEPRIGHT.m_IntCanModifyTime = 6;
            this.m_txtBFI02PEEPRIGHT.m_IntPartControlLength = 0;
            this.m_txtBFI02PEEPRIGHT.m_IntPartControlStartIndex = 0;
            this.m_txtBFI02PEEPRIGHT.m_StrUserID = "";
            this.m_txtBFI02PEEPRIGHT.m_StrUserName = "";
            this.m_txtBFI02PEEPRIGHT.MaxLength = 250;
            this.m_txtBFI02PEEPRIGHT.Multiline = false;
            this.m_txtBFI02PEEPRIGHT.Name = "m_txtBFI02PEEPRIGHT";
            this.m_txtBFI02PEEPRIGHT.Size = new System.Drawing.Size(54, 22);
            this.m_txtBFI02PEEPRIGHT.TabIndex = 71;
            this.m_txtBFI02PEEPRIGHT.Text = "";
            // 
            // m_txtBPHLEGMAMOUNT
            // 
            this.m_txtBPHLEGMAMOUNT.AccessibleDescription = "呼吸系统>>痰量";
            this.m_txtBPHLEGMAMOUNT.BackColor = System.Drawing.Color.White;
            this.m_txtBPHLEGMAMOUNT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBPHLEGMAMOUNT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBPHLEGMAMOUNT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBPHLEGMAMOUNT.Location = new System.Drawing.Point(174, 328);
            this.m_txtBPHLEGMAMOUNT.m_BlnIgnoreUserInfo = false;
            this.m_txtBPHLEGMAMOUNT.m_BlnPartControl = false;
            this.m_txtBPHLEGMAMOUNT.m_BlnReadOnly = false;
            this.m_txtBPHLEGMAMOUNT.m_BlnUnderLineDST = false;
            this.m_txtBPHLEGMAMOUNT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBPHLEGMAMOUNT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBPHLEGMAMOUNT.m_IntCanModifyTime = 6;
            this.m_txtBPHLEGMAMOUNT.m_IntPartControlLength = 0;
            this.m_txtBPHLEGMAMOUNT.m_IntPartControlStartIndex = 0;
            this.m_txtBPHLEGMAMOUNT.m_StrUserID = "";
            this.m_txtBPHLEGMAMOUNT.m_StrUserName = "";
            this.m_txtBPHLEGMAMOUNT.MaxLength = 100;
            this.m_txtBPHLEGMAMOUNT.Multiline = false;
            this.m_txtBPHLEGMAMOUNT.Name = "m_txtBPHLEGMAMOUNT";
            this.m_txtBPHLEGMAMOUNT.Size = new System.Drawing.Size(54, 22);
            this.m_txtBPHLEGMAMOUNT.TabIndex = 69;
            this.m_txtBPHLEGMAMOUNT.Text = "";
            // 
            // label161
            // 
            this.label161.Location = new System.Drawing.Point(132, 328);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(42, 23);
            this.label161.TabIndex = 70;
            this.label161.Text = "/痰量";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtBSQ2
            // 
            this.m_txtBSQ2.AccessibleDescription = "呼吸系统>>SQ2(%)";
            this.m_txtBSQ2.BackColor = System.Drawing.Color.White;
            this.m_txtBSQ2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBSQ2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBSQ2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBSQ2.Location = new System.Drawing.Point(144, 360);
            this.m_txtBSQ2.m_BlnIgnoreUserInfo = false;
            this.m_txtBSQ2.m_BlnPartControl = false;
            this.m_txtBSQ2.m_BlnReadOnly = false;
            this.m_txtBSQ2.m_BlnUnderLineDST = false;
            this.m_txtBSQ2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBSQ2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBSQ2.m_IntCanModifyTime = 6;
            this.m_txtBSQ2.m_IntPartControlLength = 0;
            this.m_txtBSQ2.m_IntPartControlStartIndex = 0;
            this.m_txtBSQ2.m_StrUserID = "";
            this.m_txtBSQ2.m_StrUserName = "";
            this.m_txtBSQ2.MaxLength = 250;
            this.m_txtBSQ2.Multiline = false;
            this.m_txtBSQ2.Name = "m_txtBSQ2";
            this.m_txtBSQ2.Size = new System.Drawing.Size(84, 22);
            this.m_txtBSQ2.TabIndex = 67;
            this.m_txtBSQ2.Text = "";
            // 
            // label109
            // 
            this.label109.Location = new System.Drawing.Point(36, 360);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(114, 23);
            this.label109.TabIndex = 68;
            this.label109.Text = "SQ (%)";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.Color.Black;
            this.label85.Location = new System.Drawing.Point(30, 352);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(210, 1);
            this.label85.TabIndex = 66;
            // 
            // m_txtBPHLEGMCOLOR
            // 
            this.m_txtBPHLEGMCOLOR.AccessibleDescription = "呼吸系统>>痰色";
            this.m_txtBPHLEGMCOLOR.BackColor = System.Drawing.Color.White;
            this.m_txtBPHLEGMCOLOR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBPHLEGMCOLOR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBPHLEGMCOLOR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBPHLEGMCOLOR.Location = new System.Drawing.Point(84, 328);
            this.m_txtBPHLEGMCOLOR.m_BlnIgnoreUserInfo = false;
            this.m_txtBPHLEGMCOLOR.m_BlnPartControl = false;
            this.m_txtBPHLEGMCOLOR.m_BlnReadOnly = false;
            this.m_txtBPHLEGMCOLOR.m_BlnUnderLineDST = false;
            this.m_txtBPHLEGMCOLOR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBPHLEGMCOLOR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBPHLEGMCOLOR.m_IntCanModifyTime = 6;
            this.m_txtBPHLEGMCOLOR.m_IntPartControlLength = 0;
            this.m_txtBPHLEGMCOLOR.m_IntPartControlStartIndex = 0;
            this.m_txtBPHLEGMCOLOR.m_StrUserID = "";
            this.m_txtBPHLEGMCOLOR.m_StrUserName = "";
            this.m_txtBPHLEGMCOLOR.MaxLength = 100;
            this.m_txtBPHLEGMCOLOR.Multiline = false;
            this.m_txtBPHLEGMCOLOR.Name = "m_txtBPHLEGMCOLOR";
            this.m_txtBPHLEGMCOLOR.Size = new System.Drawing.Size(48, 22);
            this.m_txtBPHLEGMCOLOR.TabIndex = 64;
            this.m_txtBPHLEGMCOLOR.Text = "";
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.Black;
            this.label84.Location = new System.Drawing.Point(30, 320);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(210, 1);
            this.label84.TabIndex = 63;
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.Color.Black;
            this.label86.Location = new System.Drawing.Point(30, 128);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(210, 1);
            this.label86.TabIndex = 45;
            // 
            // m_txtBBLUSESOUND
            // 
            this.m_txtBBLUSESOUND.AccessibleDescription = "呼吸系统>>呼吸音";
            this.m_txtBBLUSESOUND.BackColor = System.Drawing.Color.White;
            this.m_txtBBLUSESOUND.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBBLUSESOUND.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBBLUSESOUND.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBBLUSESOUND.Location = new System.Drawing.Point(144, 296);
            this.m_txtBBLUSESOUND.m_BlnIgnoreUserInfo = false;
            this.m_txtBBLUSESOUND.m_BlnPartControl = false;
            this.m_txtBBLUSESOUND.m_BlnReadOnly = false;
            this.m_txtBBLUSESOUND.m_BlnUnderLineDST = false;
            this.m_txtBBLUSESOUND.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBBLUSESOUND.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBBLUSESOUND.m_IntCanModifyTime = 6;
            this.m_txtBBLUSESOUND.m_IntPartControlLength = 0;
            this.m_txtBBLUSESOUND.m_IntPartControlStartIndex = 0;
            this.m_txtBBLUSESOUND.m_StrUserID = "";
            this.m_txtBBLUSESOUND.m_StrUserName = "";
            this.m_txtBBLUSESOUND.MaxLength = 250;
            this.m_txtBBLUSESOUND.Multiline = false;
            this.m_txtBBLUSESOUND.Name = "m_txtBBLUSESOUND";
            this.m_txtBBLUSESOUND.Size = new System.Drawing.Size(84, 22);
            this.m_txtBBLUSESOUND.TabIndex = 61;
            this.m_txtBBLUSESOUND.Text = "";
            // 
            // label87
            // 
            this.label87.Location = new System.Drawing.Point(36, 296);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(114, 23);
            this.label87.TabIndex = 62;
            this.label87.Text = "呼吸音";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.Color.Black;
            this.label88.Location = new System.Drawing.Point(30, 288);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(210, 1);
            this.label88.TabIndex = 60;
            // 
            // m_txtBMAXIP
            // 
            this.m_txtBMAXIP.AccessibleDescription = "呼吸系统>>Max.I.P";
            this.m_txtBMAXIP.BackColor = System.Drawing.Color.White;
            this.m_txtBMAXIP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBMAXIP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBMAXIP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBMAXIP.Location = new System.Drawing.Point(144, 264);
            this.m_txtBMAXIP.m_BlnIgnoreUserInfo = false;
            this.m_txtBMAXIP.m_BlnPartControl = false;
            this.m_txtBMAXIP.m_BlnReadOnly = false;
            this.m_txtBMAXIP.m_BlnUnderLineDST = false;
            this.m_txtBMAXIP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBMAXIP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBMAXIP.m_IntCanModifyTime = 6;
            this.m_txtBMAXIP.m_IntPartControlLength = 0;
            this.m_txtBMAXIP.m_IntPartControlStartIndex = 0;
            this.m_txtBMAXIP.m_StrUserID = "";
            this.m_txtBMAXIP.m_StrUserName = "";
            this.m_txtBMAXIP.MaxLength = 250;
            this.m_txtBMAXIP.Multiline = false;
            this.m_txtBMAXIP.Name = "m_txtBMAXIP";
            this.m_txtBMAXIP.Size = new System.Drawing.Size(84, 22);
            this.m_txtBMAXIP.TabIndex = 58;
            this.m_txtBMAXIP.Text = "";
            // 
            // label89
            // 
            this.label89.Location = new System.Drawing.Point(36, 264);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(114, 23);
            this.label89.TabIndex = 59;
            this.label89.Text = "Max.I.P";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Black;
            this.label90.Location = new System.Drawing.Point(30, 256);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(210, 1);
            this.label90.TabIndex = 57;
            // 
            // m_txtBFIO2PEEP
            // 
            this.m_txtBFIO2PEEP.AccessibleDescription = "呼吸系统>>FIO2(%)";
            this.m_txtBFIO2PEEP.BackColor = System.Drawing.Color.White;
            this.m_txtBFIO2PEEP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBFIO2PEEP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBFIO2PEEP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBFIO2PEEP.Location = new System.Drawing.Point(84, 232);
            this.m_txtBFIO2PEEP.m_BlnIgnoreUserInfo = false;
            this.m_txtBFIO2PEEP.m_BlnPartControl = false;
            this.m_txtBFIO2PEEP.m_BlnReadOnly = false;
            this.m_txtBFIO2PEEP.m_BlnUnderLineDST = false;
            this.m_txtBFIO2PEEP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBFIO2PEEP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBFIO2PEEP.m_IntCanModifyTime = 6;
            this.m_txtBFIO2PEEP.m_IntPartControlLength = 0;
            this.m_txtBFIO2PEEP.m_IntPartControlStartIndex = 0;
            this.m_txtBFIO2PEEP.m_StrUserID = "";
            this.m_txtBFIO2PEEP.m_StrUserName = "";
            this.m_txtBFIO2PEEP.MaxLength = 250;
            this.m_txtBFIO2PEEP.Multiline = false;
            this.m_txtBFIO2PEEP.Name = "m_txtBFIO2PEEP";
            this.m_txtBFIO2PEEP.Size = new System.Drawing.Size(48, 22);
            this.m_txtBFIO2PEEP.TabIndex = 55;
            this.m_txtBFIO2PEEP.Text = "";
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.Black;
            this.label92.Location = new System.Drawing.Point(30, 224);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(210, 1);
            this.label92.TabIndex = 54;
            // 
            // m_txtBBLUSENUM
            // 
            this.m_txtBBLUSENUM.AccessibleDescription = "呼吸系统>>呼吸次数";
            this.m_txtBBLUSENUM.BackColor = System.Drawing.Color.White;
            this.m_txtBBLUSENUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBBLUSENUM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBBLUSENUM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBBLUSENUM.Location = new System.Drawing.Point(144, 200);
            this.m_txtBBLUSENUM.m_BlnIgnoreUserInfo = false;
            this.m_txtBBLUSENUM.m_BlnPartControl = false;
            this.m_txtBBLUSENUM.m_BlnReadOnly = false;
            this.m_txtBBLUSENUM.m_BlnUnderLineDST = false;
            this.m_txtBBLUSENUM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBBLUSENUM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBBLUSENUM.m_IntCanModifyTime = 6;
            this.m_txtBBLUSENUM.m_IntPartControlLength = 0;
            this.m_txtBBLUSENUM.m_IntPartControlStartIndex = 0;
            this.m_txtBBLUSENUM.m_StrUserID = "";
            this.m_txtBBLUSENUM.m_StrUserName = "";
            this.m_txtBBLUSENUM.MaxLength = 250;
            this.m_txtBBLUSENUM.Multiline = false;
            this.m_txtBBLUSENUM.Name = "m_txtBBLUSENUM";
            this.m_txtBBLUSENUM.Size = new System.Drawing.Size(84, 22);
            this.m_txtBBLUSENUM.TabIndex = 52;
            this.m_txtBBLUSENUM.Text = "";
            // 
            // label93
            // 
            this.label93.Location = new System.Drawing.Point(36, 200);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(114, 23);
            this.label93.TabIndex = 53;
            this.label93.Text = "呼吸次数";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.Color.Black;
            this.label94.Location = new System.Drawing.Point(30, 192);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(210, 1);
            this.label94.TabIndex = 51;
            // 
            // m_txtBBLUESPRESSURE
            // 
            this.m_txtBBLUESPRESSURE.AccessibleDescription = "呼吸系统>>气道压力";
            this.m_txtBBLUESPRESSURE.BackColor = System.Drawing.Color.White;
            this.m_txtBBLUESPRESSURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBBLUESPRESSURE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBBLUESPRESSURE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBBLUESPRESSURE.Location = new System.Drawing.Point(144, 168);
            this.m_txtBBLUESPRESSURE.m_BlnIgnoreUserInfo = false;
            this.m_txtBBLUESPRESSURE.m_BlnPartControl = false;
            this.m_txtBBLUESPRESSURE.m_BlnReadOnly = false;
            this.m_txtBBLUESPRESSURE.m_BlnUnderLineDST = false;
            this.m_txtBBLUESPRESSURE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBBLUESPRESSURE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBBLUESPRESSURE.m_IntCanModifyTime = 6;
            this.m_txtBBLUESPRESSURE.m_IntPartControlLength = 0;
            this.m_txtBBLUESPRESSURE.m_IntPartControlStartIndex = 0;
            this.m_txtBBLUESPRESSURE.m_StrUserID = "";
            this.m_txtBBLUESPRESSURE.m_StrUserName = "";
            this.m_txtBBLUESPRESSURE.MaxLength = 250;
            this.m_txtBBLUESPRESSURE.Multiline = false;
            this.m_txtBBLUESPRESSURE.Name = "m_txtBBLUESPRESSURE";
            this.m_txtBBLUESPRESSURE.Size = new System.Drawing.Size(84, 22);
            this.m_txtBBLUESPRESSURE.TabIndex = 49;
            this.m_txtBBLUESPRESSURE.Text = "";
            // 
            // label95
            // 
            this.label95.Location = new System.Drawing.Point(42, 168);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(96, 23);
            this.label95.TabIndex = 50;
            this.label95.Text = "气道压力";
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Black;
            this.label96.Location = new System.Drawing.Point(30, 160);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(210, 1);
            this.label96.TabIndex = 48;
            // 
            // m_txtBEXPIREDMV
            // 
            this.m_txtBEXPIREDMV.AccessibleDescription = "呼吸系统>>Expired MV";
            this.m_txtBEXPIREDMV.BackColor = System.Drawing.Color.White;
            this.m_txtBEXPIREDMV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBEXPIREDMV.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBEXPIREDMV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBEXPIREDMV.Location = new System.Drawing.Point(144, 136);
            this.m_txtBEXPIREDMV.m_BlnIgnoreUserInfo = false;
            this.m_txtBEXPIREDMV.m_BlnPartControl = false;
            this.m_txtBEXPIREDMV.m_BlnReadOnly = false;
            this.m_txtBEXPIREDMV.m_BlnUnderLineDST = false;
            this.m_txtBEXPIREDMV.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBEXPIREDMV.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBEXPIREDMV.m_IntCanModifyTime = 6;
            this.m_txtBEXPIREDMV.m_IntPartControlLength = 0;
            this.m_txtBEXPIREDMV.m_IntPartControlStartIndex = 0;
            this.m_txtBEXPIREDMV.m_StrUserID = "";
            this.m_txtBEXPIREDMV.m_StrUserName = "";
            this.m_txtBEXPIREDMV.MaxLength = 250;
            this.m_txtBEXPIREDMV.Multiline = false;
            this.m_txtBEXPIREDMV.Name = "m_txtBEXPIREDMV";
            this.m_txtBEXPIREDMV.Size = new System.Drawing.Size(84, 22);
            this.m_txtBEXPIREDMV.TabIndex = 46;
            this.m_txtBEXPIREDMV.Text = "";
            // 
            // label97
            // 
            this.label97.Location = new System.Drawing.Point(60, 128);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(66, 32);
            this.label97.TabIndex = 47;
            this.label97.Text = "Expired MV";
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtBVT
            // 
            this.m_txtBVT.AccessibleDescription = "呼吸系统>>Vt";
            this.m_txtBVT.BackColor = System.Drawing.Color.White;
            this.m_txtBVT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBVT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBVT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBVT.Location = new System.Drawing.Point(144, 104);
            this.m_txtBVT.m_BlnIgnoreUserInfo = false;
            this.m_txtBVT.m_BlnPartControl = false;
            this.m_txtBVT.m_BlnReadOnly = false;
            this.m_txtBVT.m_BlnUnderLineDST = false;
            this.m_txtBVT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBVT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBVT.m_IntCanModifyTime = 6;
            this.m_txtBVT.m_IntPartControlLength = 0;
            this.m_txtBVT.m_IntPartControlStartIndex = 0;
            this.m_txtBVT.m_StrUserID = "";
            this.m_txtBVT.m_StrUserName = "";
            this.m_txtBVT.MaxLength = 250;
            this.m_txtBVT.Multiline = false;
            this.m_txtBVT.Name = "m_txtBVT";
            this.m_txtBVT.Size = new System.Drawing.Size(84, 22);
            this.m_txtBVT.TabIndex = 43;
            this.m_txtBVT.Text = "";
            // 
            // label98
            // 
            this.label98.Location = new System.Drawing.Point(36, 104);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(114, 23);
            this.label98.TabIndex = 44;
            this.label98.Text = "Vt";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.Black;
            this.label99.Location = new System.Drawing.Point(30, 96);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(210, 1);
            this.label99.TabIndex = 42;
            // 
            // m_txtBBLUSEMODE
            // 
            this.m_txtBBLUSEMODE.AccessibleDescription = "呼吸系统>>呼吸方式";
            this.m_txtBBLUSEMODE.BackColor = System.Drawing.Color.White;
            this.m_txtBBLUSEMODE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBBLUSEMODE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBBLUSEMODE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBBLUSEMODE.Location = new System.Drawing.Point(144, 72);
            this.m_txtBBLUSEMODE.m_BlnIgnoreUserInfo = false;
            this.m_txtBBLUSEMODE.m_BlnPartControl = false;
            this.m_txtBBLUSEMODE.m_BlnReadOnly = false;
            this.m_txtBBLUSEMODE.m_BlnUnderLineDST = false;
            this.m_txtBBLUSEMODE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBBLUSEMODE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBBLUSEMODE.m_IntCanModifyTime = 6;
            this.m_txtBBLUSEMODE.m_IntPartControlLength = 0;
            this.m_txtBBLUSEMODE.m_IntPartControlStartIndex = 0;
            this.m_txtBBLUSEMODE.m_StrUserID = "";
            this.m_txtBBLUSEMODE.m_StrUserName = "";
            this.m_txtBBLUSEMODE.MaxLength = 250;
            this.m_txtBBLUSEMODE.Multiline = false;
            this.m_txtBBLUSEMODE.Name = "m_txtBBLUSEMODE";
            this.m_txtBBLUSEMODE.Size = new System.Drawing.Size(84, 22);
            this.m_txtBBLUSEMODE.TabIndex = 40;
            this.m_txtBBLUSEMODE.Text = "";
            // 
            // label100
            // 
            this.label100.Location = new System.Drawing.Point(36, 72);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(100, 23);
            this.label100.TabIndex = 41;
            this.label100.Text = "呼吸方式";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtBBLUSEMACHINETYPE
            // 
            this.m_txtBBLUSEMACHINETYPE.AccessibleDescription = "呼吸系统>>呼吸机型号";
            this.m_txtBBLUSEMACHINETYPE.BackColor = System.Drawing.Color.White;
            this.m_txtBBLUSEMACHINETYPE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBBLUSEMACHINETYPE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBBLUSEMACHINETYPE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBBLUSEMACHINETYPE.Location = new System.Drawing.Point(144, 40);
            this.m_txtBBLUSEMACHINETYPE.m_BlnIgnoreUserInfo = false;
            this.m_txtBBLUSEMACHINETYPE.m_BlnPartControl = false;
            this.m_txtBBLUSEMACHINETYPE.m_BlnReadOnly = false;
            this.m_txtBBLUSEMACHINETYPE.m_BlnUnderLineDST = false;
            this.m_txtBBLUSEMACHINETYPE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBBLUSEMACHINETYPE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBBLUSEMACHINETYPE.m_IntCanModifyTime = 6;
            this.m_txtBBLUSEMACHINETYPE.m_IntPartControlLength = 0;
            this.m_txtBBLUSEMACHINETYPE.m_IntPartControlStartIndex = 0;
            this.m_txtBBLUSEMACHINETYPE.m_StrUserID = "";
            this.m_txtBBLUSEMACHINETYPE.m_StrUserName = "";
            this.m_txtBBLUSEMACHINETYPE.MaxLength = 250;
            this.m_txtBBLUSEMACHINETYPE.Multiline = false;
            this.m_txtBBLUSEMACHINETYPE.Name = "m_txtBBLUSEMACHINETYPE";
            this.m_txtBBLUSEMACHINETYPE.Size = new System.Drawing.Size(84, 22);
            this.m_txtBBLUSEMACHINETYPE.TabIndex = 38;
            this.m_txtBBLUSEMACHINETYPE.Text = "";
            // 
            // label101
            // 
            this.label101.Location = new System.Drawing.Point(36, 40);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(96, 24);
            this.label101.TabIndex = 39;
            this.label101.Text = "呼吸机型号";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.Color.Black;
            this.label102.Location = new System.Drawing.Point(30, 0);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(1, 390);
            this.label102.TabIndex = 37;
            // 
            // label103
            // 
            this.label103.BackColor = System.Drawing.Color.Black;
            this.label103.Location = new System.Drawing.Point(30, 64);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(210, 1);
            this.label103.TabIndex = 36;
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.Black;
            this.label104.Location = new System.Drawing.Point(30, 32);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(210, 1);
            this.label104.TabIndex = 35;
            // 
            // m_txtBBLUSETIME
            // 
            this.m_txtBBLUSETIME.AccessibleDescription = "呼吸系统>>插管时间";
            this.m_txtBBLUSETIME.BackColor = System.Drawing.Color.White;
            this.m_txtBBLUSETIME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBBLUSETIME.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBBLUSETIME.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBBLUSETIME.Location = new System.Drawing.Point(144, 8);
            this.m_txtBBLUSETIME.m_BlnIgnoreUserInfo = false;
            this.m_txtBBLUSETIME.m_BlnPartControl = false;
            this.m_txtBBLUSETIME.m_BlnReadOnly = false;
            this.m_txtBBLUSETIME.m_BlnUnderLineDST = false;
            this.m_txtBBLUSETIME.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBBLUSETIME.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBBLUSETIME.m_IntCanModifyTime = 6;
            this.m_txtBBLUSETIME.m_IntPartControlLength = 0;
            this.m_txtBBLUSETIME.m_IntPartControlStartIndex = 0;
            this.m_txtBBLUSETIME.m_StrUserID = "";
            this.m_txtBBLUSETIME.m_StrUserName = "";
            this.m_txtBBLUSETIME.MaxLength = 50;
            this.m_txtBBLUSETIME.Multiline = false;
            this.m_txtBBLUSETIME.Name = "m_txtBBLUSETIME";
            this.m_txtBBLUSETIME.Size = new System.Drawing.Size(84, 22);
            this.m_txtBBLUSETIME.TabIndex = 31;
            this.m_txtBBLUSETIME.Text = "";
            // 
            // label105
            // 
            this.label105.Location = new System.Drawing.Point(36, 8);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(100, 23);
            this.label105.TabIndex = 33;
            this.label105.Text = "插管时间";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label106
            // 
            this.label106.Location = new System.Drawing.Point(6, 8);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(18, 376);
            this.label106.TabIndex = 32;
            this.label106.Text = "呼吸系统";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label107
            // 
            this.label107.Location = new System.Drawing.Point(42, 328);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(36, 23);
            this.label107.TabIndex = 65;
            this.label107.Text = "痰色";
            this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label91
            // 
            this.label91.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label91.Location = new System.Drawing.Point(30, 232);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(60, 23);
            this.label91.TabIndex = 56;
            this.label91.Text = "FIO (%)";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label163
            // 
            this.label163.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label163.Location = new System.Drawing.Point(126, 232);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(60, 23);
            this.label163.TabIndex = 72;
            this.label163.Text = "/PEEP";
            this.label163.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label112);
            this.panel9.Controls.Add(this.label123);
            this.panel9.Controls.Add(this.label111);
            this.panel9.Controls.Add(this.m_txtSCOCI);
            this.panel9.Controls.Add(this.label113);
            this.panel9.Controls.Add(this.m_txtSWEDGE);
            this.panel9.Controls.Add(this.label114);
            this.panel9.Controls.Add(this.label115);
            this.panel9.Controls.Add(this.m_txtSMEAN);
            this.panel9.Controls.Add(this.label116);
            this.panel9.Controls.Add(this.m_txtSSD);
            this.panel9.Controls.Add(this.label117);
            this.panel9.Controls.Add(this.label118);
            this.panel9.Controls.Add(this.label119);
            this.panel9.Controls.Add(this.label120);
            this.panel9.Controls.Add(this.m_txtSCMH2O);
            this.panel9.Controls.Add(this.label121);
            this.panel9.Controls.Add(this.label122);
            this.panel9.Controls.Add(this.label110);
            this.panel9.Controls.Add(this.label124);
            this.panel9.Location = new System.Drawing.Point(726, 428);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(240, 200);
            this.panel9.TabIndex = 10000013;
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.Color.Black;
            this.label112.Location = new System.Drawing.Point(66, 168);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(174, 1);
            this.label112.TabIndex = 52;
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.Black;
            this.label123.Location = new System.Drawing.Point(90, -6);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(1, 176);
            this.label123.TabIndex = 51;
            // 
            // label111
            // 
            this.label111.BackColor = System.Drawing.Color.Black;
            this.label111.Location = new System.Drawing.Point(66, 128);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(174, 1);
            this.label111.TabIndex = 48;
            // 
            // m_txtSCOCI
            // 
            this.m_txtSCOCI.AccessibleDescription = "S-G Cath  Pressures>>CO/CI";
            this.m_txtSCOCI.BackColor = System.Drawing.Color.White;
            this.m_txtSCOCI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSCOCI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSCOCI.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSCOCI.Location = new System.Drawing.Point(144, 136);
            this.m_txtSCOCI.m_BlnIgnoreUserInfo = false;
            this.m_txtSCOCI.m_BlnPartControl = false;
            this.m_txtSCOCI.m_BlnReadOnly = false;
            this.m_txtSCOCI.m_BlnUnderLineDST = false;
            this.m_txtSCOCI.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSCOCI.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSCOCI.m_IntCanModifyTime = 6;
            this.m_txtSCOCI.m_IntPartControlLength = 0;
            this.m_txtSCOCI.m_IntPartControlStartIndex = 0;
            this.m_txtSCOCI.m_StrUserID = "";
            this.m_txtSCOCI.m_StrUserName = "";
            this.m_txtSCOCI.MaxLength = 250;
            this.m_txtSCOCI.Multiline = false;
            this.m_txtSCOCI.Name = "m_txtSCOCI";
            this.m_txtSCOCI.Size = new System.Drawing.Size(84, 22);
            this.m_txtSCOCI.TabIndex = 45;
            this.m_txtSCOCI.Text = "";
            // 
            // label113
            // 
            this.label113.Location = new System.Drawing.Point(84, 136);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(60, 23);
            this.label113.TabIndex = 46;
            this.label113.Text = "CO/CI";
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtSWEDGE
            // 
            this.m_txtSWEDGE.AccessibleDescription = "S-G Cath  Pressures>>Wedge";
            this.m_txtSWEDGE.BackColor = System.Drawing.Color.White;
            this.m_txtSWEDGE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSWEDGE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSWEDGE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSWEDGE.Location = new System.Drawing.Point(144, 104);
            this.m_txtSWEDGE.m_BlnIgnoreUserInfo = false;
            this.m_txtSWEDGE.m_BlnPartControl = false;
            this.m_txtSWEDGE.m_BlnReadOnly = false;
            this.m_txtSWEDGE.m_BlnUnderLineDST = false;
            this.m_txtSWEDGE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSWEDGE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSWEDGE.m_IntCanModifyTime = 6;
            this.m_txtSWEDGE.m_IntPartControlLength = 0;
            this.m_txtSWEDGE.m_IntPartControlStartIndex = 0;
            this.m_txtSWEDGE.m_StrUserID = "";
            this.m_txtSWEDGE.m_StrUserName = "";
            this.m_txtSWEDGE.MaxLength = 250;
            this.m_txtSWEDGE.Multiline = false;
            this.m_txtSWEDGE.Name = "m_txtSWEDGE";
            this.m_txtSWEDGE.Size = new System.Drawing.Size(84, 22);
            this.m_txtSWEDGE.TabIndex = 43;
            this.m_txtSWEDGE.Text = "";
            // 
            // label114
            // 
            this.label114.Location = new System.Drawing.Point(84, 107);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(60, 23);
            this.label114.TabIndex = 44;
            this.label114.Text = "Wedge";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label115
            // 
            this.label115.BackColor = System.Drawing.Color.Black;
            this.label115.Location = new System.Drawing.Point(90, 96);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(150, 1);
            this.label115.TabIndex = 42;
            // 
            // m_txtSMEAN
            // 
            this.m_txtSMEAN.AccessibleDescription = "S-G Cath  Pressures>>Mean";
            this.m_txtSMEAN.BackColor = System.Drawing.Color.White;
            this.m_txtSMEAN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSMEAN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSMEAN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSMEAN.Location = new System.Drawing.Point(144, 72);
            this.m_txtSMEAN.m_BlnIgnoreUserInfo = false;
            this.m_txtSMEAN.m_BlnPartControl = false;
            this.m_txtSMEAN.m_BlnReadOnly = false;
            this.m_txtSMEAN.m_BlnUnderLineDST = false;
            this.m_txtSMEAN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSMEAN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSMEAN.m_IntCanModifyTime = 6;
            this.m_txtSMEAN.m_IntPartControlLength = 0;
            this.m_txtSMEAN.m_IntPartControlStartIndex = 0;
            this.m_txtSMEAN.m_StrUserID = "";
            this.m_txtSMEAN.m_StrUserName = "";
            this.m_txtSMEAN.MaxLength = 250;
            this.m_txtSMEAN.Multiline = false;
            this.m_txtSMEAN.Name = "m_txtSMEAN";
            this.m_txtSMEAN.Size = new System.Drawing.Size(84, 22);
            this.m_txtSMEAN.TabIndex = 40;
            this.m_txtSMEAN.Text = "";
            // 
            // label116
            // 
            this.label116.Location = new System.Drawing.Point(84, 72);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(60, 23);
            this.label116.TabIndex = 41;
            this.label116.Text = "Mean";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtSSD
            // 
            this.m_txtSSD.AccessibleDescription = "S-G Cath  Pressures>>S/D";
            this.m_txtSSD.BackColor = System.Drawing.Color.White;
            this.m_txtSSD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSSD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSSD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSSD.Location = new System.Drawing.Point(144, 40);
            this.m_txtSSD.m_BlnIgnoreUserInfo = false;
            this.m_txtSSD.m_BlnPartControl = false;
            this.m_txtSSD.m_BlnReadOnly = false;
            this.m_txtSSD.m_BlnUnderLineDST = false;
            this.m_txtSSD.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSSD.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSSD.m_IntCanModifyTime = 6;
            this.m_txtSSD.m_IntPartControlLength = 0;
            this.m_txtSSD.m_IntPartControlStartIndex = 0;
            this.m_txtSSD.m_StrUserID = "";
            this.m_txtSSD.m_StrUserName = "";
            this.m_txtSSD.MaxLength = 250;
            this.m_txtSSD.Multiline = false;
            this.m_txtSSD.Name = "m_txtSSD";
            this.m_txtSSD.Size = new System.Drawing.Size(84, 22);
            this.m_txtSSD.TabIndex = 38;
            this.m_txtSSD.Text = "";
            // 
            // label117
            // 
            this.label117.Location = new System.Drawing.Point(84, 40);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(60, 24);
            this.label117.TabIndex = 39;
            this.label117.Text = "S/D";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label118
            // 
            this.label118.BackColor = System.Drawing.Color.Black;
            this.label118.Location = new System.Drawing.Point(66, 0);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(1, 210);
            this.label118.TabIndex = 37;
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.Color.Black;
            this.label119.Location = new System.Drawing.Point(90, 64);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(150, 1);
            this.label119.TabIndex = 36;
            // 
            // label120
            // 
            this.label120.BackColor = System.Drawing.Color.Black;
            this.label120.Location = new System.Drawing.Point(66, 32);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(175, 1);
            this.label120.TabIndex = 35;
            // 
            // m_txtSCMH2O
            // 
            this.m_txtSCMH2O.AccessibleDescription = "S-G Cath  Pressures>>CmH20 mmHg";
            this.m_txtSCMH2O.BackColor = System.Drawing.Color.White;
            this.m_txtSCMH2O.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSCMH2O.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSCMH2O.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSCMH2O.Location = new System.Drawing.Point(144, 8);
            this.m_txtSCMH2O.m_BlnIgnoreUserInfo = false;
            this.m_txtSCMH2O.m_BlnPartControl = false;
            this.m_txtSCMH2O.m_BlnReadOnly = false;
            this.m_txtSCMH2O.m_BlnUnderLineDST = false;
            this.m_txtSCMH2O.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSCMH2O.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSCMH2O.m_IntCanModifyTime = 6;
            this.m_txtSCMH2O.m_IntPartControlLength = 0;
            this.m_txtSCMH2O.m_IntPartControlStartIndex = 0;
            this.m_txtSCMH2O.m_StrUserID = "";
            this.m_txtSCMH2O.m_StrUserName = "";
            this.m_txtSCMH2O.MaxLength = 250;
            this.m_txtSCMH2O.Multiline = false;
            this.m_txtSCMH2O.Name = "m_txtSCMH2O";
            this.m_txtSCMH2O.Size = new System.Drawing.Size(84, 22);
            this.m_txtSCMH2O.TabIndex = 31;
            this.m_txtSCMH2O.Text = "";
            // 
            // label121
            // 
            this.label121.Location = new System.Drawing.Point(96, 0);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(48, 32);
            this.label121.TabIndex = 33;
            this.label121.Text = "CmH20 mmHg";
            this.label121.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label122
            // 
            this.label122.Location = new System.Drawing.Point(0, 8);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(72, 184);
            this.label122.TabIndex = 32;
            this.label122.Text = "S-G Cath  Pressures";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label110
            // 
            this.label110.Location = new System.Drawing.Point(54, 0);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(48, 32);
            this.label110.TabIndex = 49;
            this.label110.Text = "RA";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label124
            // 
            this.label124.Location = new System.Drawing.Point(60, 40);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(36, 80);
            this.label124.TabIndex = 53;
            this.label124.Text = "PA";
            this.label124.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(810, 632);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 10000014;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(888, 632);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 10000015;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_txtIDCode
            // 
            this.m_txtIDCode.AccessibleDescription = "ID号";
            this.m_txtIDCode.Location = new System.Drawing.Point(396, 12);
            this.m_txtIDCode.Name = "m_txtIDCode";
            this.m_txtIDCode.Size = new System.Drawing.Size(66, 23);
            this.m_txtIDCode.TabIndex = 10000019;
            // 
            // m_txtWeight
            // 
            this.m_txtWeight.AccessibleDescription = "体重";
            this.m_txtWeight.Location = new System.Drawing.Point(318, 12);
            this.m_txtWeight.Name = "m_txtWeight";
            this.m_txtWeight.Size = new System.Drawing.Size(42, 23);
            this.m_txtWeight.TabIndex = 10000017;
            // 
            // m_txtOperationName
            // 
            this.m_txtOperationName.AccessibleDescription = "诊断/手术名称";
            this.m_txtOperationName.Location = new System.Drawing.Point(564, 12);
            this.m_txtOperationName.Name = "m_txtOperationName";
            this.m_txtOperationName.Size = new System.Drawing.Size(102, 23);
            this.m_txtOperationName.TabIndex = 10000021;
            // 
            // label125
            // 
            this.label125.Location = new System.Drawing.Point(282, 16);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(40, 23);
            this.label125.TabIndex = 10000016;
            this.label125.Text = "体重";
            // 
            // m_dtpOperationDate
            // 
            this.m_dtpOperationDate.CustomFormat = "yyy-MM-dd";
            this.m_dtpOperationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOperationDate.Location = new System.Drawing.Point(732, 12);
            this.m_dtpOperationDate.Name = "m_dtpOperationDate";
            this.m_dtpOperationDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpOperationDate.TabIndex = 10000023;
            // 
            // label126
            // 
            this.label126.Location = new System.Drawing.Point(672, 16);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(64, 23);
            this.label126.TabIndex = 10000022;
            this.label126.Text = "手术日期";
            // 
            // label127
            // 
            this.label127.Location = new System.Drawing.Point(468, 16);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(104, 23);
            this.label127.TabIndex = 10000020;
            this.label127.Text = "诊断/手术名称";
            // 
            // label128
            // 
            this.label128.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label128.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label128.Location = new System.Drawing.Point(360, 16);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(48, 23);
            this.label128.TabIndex = 10000018;
            this.label128.Text = "ID号";
            // 
            // label129
            // 
            this.label129.Location = new System.Drawing.Point(828, 16);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(104, 23);
            this.label129.TabIndex = 10000024;
            this.label129.Text = "术后/入ICU第";
            // 
            // m_txtDATEAFTEROPERATION
            // 
            this.m_txtDATEAFTEROPERATION.Location = new System.Drawing.Point(918, 12);
            this.m_txtDATEAFTEROPERATION.Name = "m_txtDATEAFTEROPERATION";
            this.m_txtDATEAFTEROPERATION.Size = new System.Drawing.Size(30, 23);
            this.m_txtDATEAFTEROPERATION.TabIndex = 10000025;
            // 
            // label130
            // 
            this.label130.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label130.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label130.Location = new System.Drawing.Point(948, 16);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(24, 23);
            this.label130.TabIndex = 10000026;
            this.label130.Text = "天";
            // 
            // label164
            // 
            this.label164.Location = new System.Drawing.Point(30, 12);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(100, 23);
            this.label164.TabIndex = 10000027;
            this.label164.Text = "时间";
            // 
            // frmSurgeryICUWardshipEdit
            // 
            this.AccessibleDescription = "外科ICU监护记录";
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(982, 677);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label130);
            this.Controls.Add(this.m_txtDATEAFTEROPERATION);
            this.Controls.Add(this.label129);
            this.Controls.Add(this.m_txtIDCode);
            this.Controls.Add(this.m_txtWeight);
            this.Controls.Add(this.m_txtOperationName);
            this.Controls.Add(this.label125);
            this.Controls.Add(this.label127);
            this.Controls.Add(this.label128);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label164);
            this.Controls.Add(this.m_dtpOperationDate);
            this.Controls.Add(this.label126);
            this.Name = "frmSurgeryICUWardshipEdit";
            this.Text = "外科ICU监护记录编辑";
            this.Load += new System.EventHandler(this.frmSurgeryICUWardshipEdit_Load);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label126, 0);
            this.Controls.SetChildIndex(this.m_dtpOperationDate, 0);
            this.Controls.SetChildIndex(this.label164, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.panel7, 0);
            this.Controls.SetChildIndex(this.panel8, 0);
            this.Controls.SetChildIndex(this.panel9, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.label128, 0);
            this.Controls.SetChildIndex(this.label127, 0);
            this.Controls.SetChildIndex(this.label125, 0);
            this.Controls.SetChildIndex(this.m_txtOperationName, 0);
            this.Controls.SetChildIndex(this.m_txtWeight, 0);
            this.Controls.SetChildIndex(this.m_txtIDCode, 0);
            this.Controls.SetChildIndex(this.label129, 0);
            this.Controls.SetChildIndex(this.m_txtDATEAFTEROPERATION, 0);
            this.Controls.SetChildIndex(this.label130, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override int m_IntFormID
		{
			get
			{
				return 92;
			}
		}

		private void frmSurgeryICUWardshipEdit_Load(object sender, System.EventArgs e)
		{
			m_txtPBODYPART.Focus();
			m_txtIBLOODPRO.LostFocus +=new EventHandler(m_txtIBLOODPRO_Leave);
			m_txtIGS.LostFocus +=new EventHandler(m_txtIBLOODPRO_Leave);
			m_txtINS.LostFocus +=new EventHandler(m_txtIBLOODPRO_Leave);
			m_txtINAMOUNT1.LostFocus +=new EventHandler(m_txtIBLOODPRO_Leave);
			m_txtINAMOUNT2.LostFocus +=new EventHandler(m_txtIBLOODPRO_Leave);
			m_txtINAMOUNT3.LostFocus +=new EventHandler(m_txtIBLOODPRO_Leave);
			m_txtINAMOUNT4.LostFocus +=new EventHandler(m_txtIBLOODPRO_Leave);
			m_txtOEMIEMCTION.LostFocus +=new EventHandler(m_txtOEMIEMCTION_Leave);
			m_txtOGASTRICJUICE.LostFocus +=new EventHandler(m_txtOEMIEMCTION_Leave);
			m_txtOUTAMOUNT1.LostFocus +=new EventHandler(m_txtOEMIEMCTION_Leave);
			m_txtOUTAMOUNT2.LostFocus +=new EventHandler(m_txtOEMIEMCTION_Leave);
			m_txtOUTAMOUNT3.LostFocus +=new EventHandler(m_txtOEMIEMCTION_Leave);
			m_txtOUTAMOUNT4.LostFocus +=new EventHandler(m_txtOEMIEMCTION_Leave);
			
		}
      
//		public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
//		{
//			clsIntensiveRecordInfo objTrackInfo = new clsIntensiveRecordInfo();
//
//			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
//			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
//			objTrackInfo.m_StrTitle =this.m_lblForTitle.Text;
//
//			//设置m_dtmRecordTime
//			if(objTrackInfo.m_ObjRecordContent !=null)
//			{
//				m_dtpCreateDate.Value=objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
//			}
//			return objTrackInfo;	
//		}
		protected  void m_mthClearAllInfo(Control p_ctlControl)
        {
            if (p_ctlControl == null) return;
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{
				if(p_ctlControl is iCare.CustomForm.ctlRichTextBox)//自定义表单中的cltRichTextBox
					((iCare.CustomForm.ctlRichTextBox)p_ctlControl).Text = "";
				else
					((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();	
			}
//			else if(strTypeName=="ctlBorderTextBox" && p_ctlControl.Name != "txtInPatientID" && p_ctlControl.Name != "m_txtPatientName" && p_ctlControl.Name != "m_txtBedNO")
//				((ctlBorderTextBox)p_ctlControl).Text="";	
			else if(strTypeName=="TreeView")
			{
				if( ((TreeView)p_ctlControl).Nodes.Count>0 )
					((TreeView)p_ctlControl).Nodes[0].Nodes.Clear();
			}
			else if(strTypeName=="ListView")
				((ListView)p_ctlControl).Items.Clear();	
			else if(strTypeName=="DateTimePicker")
				((DateTimePicker)p_ctlControl).Value=DateTime.Now;
			//m_lblInHospitalDate.Text = "";
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthClearAllInfo(subcontrol);						
				} 	
			}			
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//清空具体记录内容				

			//this.m_txtPBODYPART.m_mthClearText();

            //			m_objSignTool.m_mthSetDefaulEmployee();
			foreach(Control subcontrol in this.Controls)
			{										
				m_mthClearAllInfo(subcontrol);						
			} 
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
		}/// <summary>
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
		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsISURGERYICUWARDSHIP objContent=(clsISURGERYICUWARDSHIP)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();
			

			this.m_txtPBODYPART.m_mthSetNewText(objContent.m_strPBODYPART_Right,objContent.m_strPBODYPARTXML);
			this.m_txtPCONSCIOUSNESS.m_mthSetNewText(objContent.m_strPCONSCIOUSNESS_Right,objContent.m_strPCONSCIOUSNESSXML);
			this.m_txtPPUPIL.m_mthSetNewText(objContent.m_strPPUPIL_Right,objContent.m_strPPUPILXML);
			this.m_txtPREFLECT.m_mthSetNewText(objContent.m_strPREFLECT_Right,objContent.m_strPREFLECTXML);
			this.m_txtCTEMPERATURE.m_mthSetNewText(objContent.m_strCTEMPERATURE_Right,objContent.m_strCTEMPERATUREXML);

			this.m_txtCSMALLTEMPERATURE.m_mthSetNewText(objContent.m_strCSMALLTEMPERATURE_Right,objContent.m_strCSMALLTEMPERATUREXML);
			this.m_txtCHEARTRATE.m_mthSetNewText(objContent.m_strCHEARTRATE_Right,objContent.m_strCHEARTRATEXML);
			this.m_txtCHEARTRHYTHM.m_mthSetNewText(objContent.m_strCHEARTRHYTHM_Right,objContent.m_strCHEARTRHYTHMXML);
			this.m_txtCSD.m_mthSetNewText(objContent.m_strCSD_Right,objContent.m_strCSDXML);
			this.m_txtCCVP.m_mthSetNewText(objContent.m_strCCVP_Right,objContent.m_strCCVPXML);

			this.m_txtDPHYSIC1.m_mthSetNewText(objContent.m_strDPHYSIC1_Right,objContent.m_strDPHYSIC1XML);
			this.m_txtDPHYSIC2.m_mthSetNewText(objContent.m_strDPHYSIC2_Right,objContent.m_strDPHYSIC2XML);
			this.m_txtDPHYSIC3.m_mthSetNewText(objContent.m_strDPHYSIC3_Right,objContent.m_strDPHYSIC3XML);
			this.m_txtDPHYSIC4.m_mthSetNewText(objContent.m_strDPHYSIC4_Right,objContent.m_strDPHYSIC4XML);
			this.m_txtDPHYSIC5.m_mthSetNewText(objContent.m_strDPHYSIC5_Right,objContent.m_strDPHYSIC5XML);
			this.m_txtDPHYSIC6.m_mthSetNewText(objContent.m_strDPHYSIC6_Right,objContent.m_strDPHYSIC6XML);
			this.m_txtDPHYSIC7.m_mthSetNewText(objContent.m_strDPHYSIC7_Right,objContent.m_strDPHYSIC7XML);
			this.m_txtDPHYSIC8.m_mthSetNewText(objContent.m_strDPHYSIC8_Right,objContent.m_strDPHYSIC8XML);

			this.m_txtDCURE1.m_mthSetNewText(objContent.m_strDCURE1_Right,objContent.m_strDCURE1XML);
			this.m_txtDCURE2.m_mthSetNewText(objContent.m_strDCURE2_Right,objContent.m_strDCURE2XML);
			this.m_txtDCURE3.m_mthSetNewText(objContent.m_strDCURE3_Right,objContent.m_strDCURE3XML);
			this.m_txtDCURE4.m_mthSetNewText(objContent.m_strDCURE4_Right,objContent.m_strDCURE4XML);
			this.m_txtDCURE5.m_mthSetNewText(objContent.m_strDCURE5_Right,objContent.m_strDCURE5XML);
			this.m_txtDCURE6.m_mthSetNewText(objContent.m_strDCURE6_Right,objContent.m_strDCURE6XML);
			this.m_txtDCURE7.m_mthSetNewText(objContent.m_strDCURE7_Right,objContent.m_strDCURE7XML);
			this.m_txtDCURE8.m_mthSetNewText(objContent.m_strDCURE8_Right,objContent.m_strDCURE8XML);

			this.m_txtIGS.m_mthSetNewText(objContent.m_strIGS_Right,objContent.m_strIGSXML);
			this.m_txtINS.m_mthSetNewText(objContent.m_strINS_Right,objContent.m_strINSXML);
			this.m_txtINTATAL.m_mthSetNewText(objContent.m_strINTATAL_Right,objContent.m_strINTATALXML);

			this.m_txtOTATAL.m_mthSetNewText(objContent.m_strOTATAL_Right,objContent.m_strOTATALXML);
			this.m_txtOEMIEMCTION.m_mthSetNewText(objContent.m_strOEMIEMCTION_Right,objContent.m_strOEMEMCTIONXML);
			this.m_txtOGASTRICJUICE.m_mthSetNewText(objContent.m_strOGASTRICJUICE_Right,objContent.m_strOGASTRICJUICEXML);
			this.m_txtSESPECIALLYNOTE.m_mthSetNewText(objContent.m_strSESPECIALLYNOTE_Right,objContent.m_strSESPECIALLYNOTEXML);
			this.m_txtBBLUSETIME.m_mthSetNewText(objContent.m_strBBLUSETIME_Right,objContent.m_strBBLUSETIMEXML);
			this.m_txtBBLUSEMACHINETYPE.m_mthSetNewText(objContent.m_strBBLUSEMACHINETYPE_Right,objContent.m_strBBLUSEMACHINETYPEXML);

			this.m_txtBBLUSEMODE.m_mthSetNewText(objContent.m_strBBLUSEMODE_Right,objContent.m_strBBLUSEMONDEXML);
			this.m_txtBVT.m_mthSetNewText(objContent.m_strBVT_Right,objContent.m_strBVTXML);
			this.m_txtBEXPIREDMV.m_mthSetNewText(objContent.m_strBEXPIREDMV_Right,objContent.m_strBEXPIREDMVXML);

			this.m_txtBBLUESPRESSURE.m_mthSetNewText(objContent.m_strBBLUESPRESSURE_Right,objContent.m_strBBLUESPRESSUREXML);
			this.m_txtBBLUSENUM.m_mthSetNewText(objContent.m_strBBLUSENUM_Right,objContent.m_strBBLUSENUMXML);
			this.m_txtBFIO2PEEP.m_mthSetNewText(objContent.m_strBFIO2PEEP_Right,objContent.m_strBFIO2PEEPXML);
			this.m_txtBMAXIP.m_mthSetNewText(objContent.m_strBMAXIP_Right,objContent.m_strBMAXIPXML);
			this.m_txtBBLUSESOUND.m_mthSetNewText(objContent.m_strBBLUSESOUND_Right,objContent.m_strBBLUSESOUNDXML);
			this.m_txtBPHLEGMCOLOR.m_mthSetNewText(objContent.m_strBPHLEGMCOLOR_Right,objContent.m_strBPHLEGMCOLORXML);

			this.m_txtBSQ2.m_mthSetNewText(objContent.m_strBSQ2_Right,objContent.m_strBSQ2XML);
			this.m_txtTCOLLECTBLOODPOINT.m_mthSetNewText(objContent.m_strTCOLLECTBLOODPOINT_Right,objContent.m_strTCOLLECTBLOODPOINTXML);
			this.m_txtTPH.m_mthSetNewText(objContent.m_strTPH_Right,objContent.m_strTPHXML);

			this.m_txtTPCO2.m_mthSetNewText(objContent.m_strTPCO2_Right,objContent.m_strTPCO2XML);
			this.m_txtTP02.m_mthSetNewText(objContent.m_strTP02_Right,objContent.m_strTPO2XML);
			this.m_txtTHCO3.m_mthSetNewText(objContent.m_strTHCO3_Right,objContent.m_strTHCO3XML);
			this.m_txtTTCO2.m_mthSetNewText(objContent.m_strTTCO2_Right,objContent.m_strTTCO2XML);
			this.m_txtTBE.m_mthSetNewText(objContent.m_strTBE_Right,objContent.m_strTBEXML);
			this.m_txtTSAT.m_mthSetNewText(objContent.m_strTSAT_Right,objContent.m_strTSATXML);

			this.m_txtTO2CT.m_mthSetNewText(objContent.m_strTO2CT_Right,objContent.m_strTO2CTXML);
			this.m_txtSCMH2O.m_mthSetNewText(objContent.m_strSCMH2O_Right,objContent.m_strSCMH2OXML);
			this.m_txtSSD.m_mthSetNewText(objContent.m_strSSD_Right,objContent.m_strSSDXML);
			this.m_txtSMEAN.m_mthSetNewText(objContent.m_strSMEAN_Right,objContent.m_strSMEANXML);
			this.m_txtSWEDGE.m_mthSetNewText(objContent.m_strSWEDGE_Right,objContent.m_strSWEDGEXML);
			this.m_txtSCOCI.m_mthSetNewText(objContent.m_strSCOCI_Right,objContent.m_strSCOCIXML);

			//add
			this.m_txtIBLOODPRODUCE.m_mthSetNewText(objContent.m_strIBLOODPRODUCE_Right,objContent.m_strIBLOODPRODUCEXML);
			this.m_txtIBLOODPRO.m_mthSetNewText(objContent.m_strIBLOODPRODUCEAD_Right,objContent.m_strIBLOODPRODUCEADDXML);
			this.m_txtPPUPLRIGHT.m_mthSetNewText(objContent.m_strPPUPLRIGH_RightT,objContent.m_strPPUPLRIGHTXML);
			this.m_txtPREFLECTRIGHT.m_mthSetNewText(objContent.m_strPREFLECTRIGHT_Right,objContent.m_strPREFLECTRIGHTXML);
			this.m_txtINNAME1.m_mthSetNewText(objContent.m_strINNAME1_Right,objContent.m_strINNAME1XML);
			this.m_txtINNAME2.m_mthSetNewText(objContent.m_strINNAME2_Right,objContent.m_strINNAME2XML);
			this.m_txtINNAME3.m_mthSetNewText(objContent.m_strINNAME3_Right,objContent.m_strINNAME3XML);
			this.m_txtINNAME4.m_mthSetNewText(objContent.m_strINNAME4_Right,objContent.m_strINNAME4XML);
		
			this.m_txtINAMOUNT1.m_mthSetNewText(objContent.m_strINAMOUNT1_Right,objContent.m_strINAMOUNT1XML);
			this.m_txtINAMOUNT2.m_mthSetNewText(objContent.m_strINAMOUNT2_Right,objContent.m_strINAMOUNT2XML);
			this.m_txtINAMOUNT3.m_mthSetNewText(objContent.m_strINAMOUNT3_Right,objContent.m_strINAMOUNT3XML);
			this.m_txtINAMOUNT4.m_mthSetNewText(objContent.m_strINAMOUNT4_Right,objContent.m_strINAMOUNT4XML);
			this.m_txtOEMIEMCTION.m_mthSetNewText(objContent.m_strOEMIEMCTION_Right,objContent.m_strOEMEMCTIONXML);
			this.m_txtOGASTRICJUICE.m_mthSetNewText(objContent.m_strOGASTRICJUICE_Right,objContent.m_strOGASTRICJUICEXML);
			this.m_txtOUTNAME1.m_mthSetNewText(objContent.m_strOUTNAME1_Right,objContent.m_strOUTNAME1XML);
			this.m_txtOUTNAME2.m_mthSetNewText(objContent.m_strOUTNAME2_Right,objContent.m_strOUTNAME2XML);
			this.m_txtOUTNAME3.m_mthSetNewText(objContent.m_strOUTNAME3_Right,objContent.m_strOUTNAME3XML);
			this.m_txtOUTNAME4.m_mthSetNewText(objContent.m_strOUTNAME4_Right,objContent.m_strOUTNAME4XML);
		
			this.m_txtOUTAMOUNT1.m_mthSetNewText(objContent.m_strOUTAMOUNT1_Right,objContent.m_strOUTAMOUNT1XML);
			this.m_txtOUTAMOUNT2.m_mthSetNewText(objContent.m_strOUTAMOUNT2_Right,objContent.m_strOUTAMOUNT2XML);
			this.m_txtOUTAMOUNT3.m_mthSetNewText(objContent.m_strOUTAMOUNT3_Right,objContent.m_strOUTAMOUNT3XML);
			this.m_txtOUTAMOUNT4.m_mthSetNewText(objContent.m_strOUTAMOUNT4_Right,objContent.m_strOUTAMOUNT4XML);
			this.m_txtBFI02PEEPRIGHT.m_mthSetNewText(objContent.m_strBFI02PEEPRIGHT_Right,objContent.m_strBFI02PEEPRIGHTXML);
			this.m_txtBPHLEGMAMOUNT.m_mthSetNewText(objContent.m_strBPHLEGMAMOUNT_Right,objContent.m_strBPHLEGMAMOUNTXML);
			


			m_txtWeight.Text=objContent.m_strWEIGHT;
			m_txtIDCode.Text=objContent.m_strIDCODE;
			m_txtOperationName.Text=objContent.m_strOPERATIONNAME;
			if(objContent.m_dtmCreateDate.ToString("yyyy-MM-dd")=="0001-01-01")
				m_dtpCreateDate.Value=DateTime.Now;
			else
				m_dtpCreateDate.Value=objContent.m_dtmCreateDate;
			if(objContent.m_strOPERATIONDATE.ToString("yyyy-MM-dd")=="0001-01-01")
				m_dtpOperationDate.Value=DateTime.Now;
			else
			m_dtpOperationDate.Text =objContent.m_strOPERATIONDATE.ToString();
			m_txtDATEAFTEROPERATION.Text=objContent.m_strDATEAFTEROPERATION;
//			clsEmployee objEmployee=new clsEmployee(objContent.m_strCreateUserID);
//			if(objEmployee !=null)
//				m_txtSign.Text=objEmployee.m_StrFirstName;
//			this.m_txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
				clsISURGERYICUWARDSHIP objContent=(clsISURGERYICUWARDSHIP)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();		
			m_txtCTEMPERATURE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCTEMPERATURE_Right ,objContent.m_strCTEMPERATUREXML);


			this.m_txtPBODYPART.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPBODYPART_Right,objContent.m_strPBODYPARTXML);
			this.m_txtPCONSCIOUSNESS.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPCONSCIOUSNESS_Right,objContent.m_strPCONSCIOUSNESSXML);
			this.m_txtPPUPIL.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPPUPIL_Right,objContent.m_strPPUPILXML);
			this.m_txtPREFLECT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPREFLECT_Right,objContent.m_strPREFLECTXML);
			this.m_txtCTEMPERATURE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCTEMPERATURE_Right,objContent.m_strCTEMPERATUREXML);

			this.m_txtCSMALLTEMPERATURE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCSMALLTEMPERATURE_Right,objContent.m_strCSMALLTEMPERATUREXML);
			this.m_txtCHEARTRATE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCHEARTRATE_Right,objContent.m_strCHEARTRATEXML);
			this.m_txtCHEARTRHYTHM.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCHEARTRHYTHM_Right,objContent.m_strCHEARTRHYTHMXML);
			this.m_txtCSD.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCSD_Right,objContent.m_strCSDXML);
			this.m_txtCCVP.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCCVP_Right,objContent.m_strCCVPXML);

			this.m_txtDPHYSIC1.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDPHYSIC1_Right,objContent.m_strDPHYSIC1XML);
			this.m_txtDPHYSIC2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDPHYSIC2_Right,objContent.m_strDPHYSIC2XML);
			this.m_txtDPHYSIC3.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDPHYSIC3_Right,objContent.m_strDPHYSIC3XML);
			this.m_txtDPHYSIC4.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDPHYSIC4_Right,objContent.m_strDPHYSIC4XML);
			this.m_txtDPHYSIC5.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDPHYSIC5_Right,objContent.m_strDPHYSIC5XML);
			this.m_txtDPHYSIC6.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDPHYSIC6_Right,objContent.m_strDPHYSIC6XML);
			this.m_txtDPHYSIC7.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDPHYSIC7_Right,objContent.m_strDPHYSIC7XML);
			this.m_txtDPHYSIC8.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDPHYSIC8_Right,objContent.m_strDPHYSIC8XML);

			this.m_txtDCURE1.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDCURE1_Right,objContent.m_strDCURE1XML);
			this.m_txtDCURE2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDCURE2_Right,objContent.m_strDCURE2XML);
			this.m_txtDCURE3.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDCURE3_Right,objContent.m_strDCURE3XML);
			this.m_txtDCURE4.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDCURE4_Right,objContent.m_strDCURE4XML);
			this.m_txtDCURE5.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDCURE5_Right,objContent.m_strDCURE5XML);
			this.m_txtDCURE6.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDCURE6_Right,objContent.m_strDCURE6XML);
			this.m_txtDCURE7.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDCURE7_Right,objContent.m_strDCURE7XML);
			this.m_txtDCURE8.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDCURE8_Right,objContent.m_strDCURE8XML);

			this.m_txtIGS.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strIGS_Right,objContent.m_strIGSXML);
			this.m_txtINS.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINS_Right,objContent.m_strINSXML);
			this.m_txtINTATAL.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINTATAL_Right,objContent.m_strINTATALXML);

			this.m_txtOTATAL.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOTATAL_Right,objContent.m_strOTATALXML);
			this.m_txtOEMIEMCTION.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOEMIEMCTION_Right,objContent.m_strOEMEMCTIONXML);
			this.m_txtOGASTRICJUICE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOGASTRICJUICE_Right,objContent.m_strOGASTRICJUICEXML);
			this.m_txtSESPECIALLYNOTE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSESPECIALLYNOTE_Right,objContent.m_strSESPECIALLYNOTEXML);
			this.m_txtBBLUSETIME.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBBLUSETIME_Right,objContent.m_strBBLUSETIMEXML);
			this.m_txtBBLUSEMACHINETYPE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBBLUSEMACHINETYPE_Right,objContent.m_strBBLUSEMACHINETYPEXML);

			this.m_txtBBLUSEMODE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBBLUSEMODE_Right,objContent.m_strBBLUSEMONDEXML);
			this.m_txtBVT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBVT_Right,objContent.m_strBVTXML);
			this.m_txtBEXPIREDMV.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBEXPIREDMV_Right,objContent.m_strBEXPIREDMVXML);

			this.m_txtBBLUESPRESSURE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBBLUESPRESSURE_Right,objContent.m_strBBLUESPRESSUREXML);
			this.m_txtBBLUSENUM.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBBLUSENUM_Right,objContent.m_strBBLUSENUMXML);
			this.m_txtBFIO2PEEP.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBFIO2PEEP_Right,objContent.m_strBFIO2PEEPXML);
			this.m_txtBMAXIP.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBMAXIP_Right,objContent.m_strBMAXIPXML);
			this.m_txtBBLUSESOUND.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBBLUSESOUND_Right,objContent.m_strBBLUSESOUNDXML);
			this.m_txtBPHLEGMCOLOR.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBPHLEGMCOLOR_Right,objContent.m_strBPHLEGMCOLORXML);

			this.m_txtBSQ2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBSQ2_Right,objContent.m_strBSQ2XML);
			this.m_txtTCOLLECTBLOODPOINT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTCOLLECTBLOODPOINT_Right,objContent.m_strTCOLLECTBLOODPOINTXML);
			this.m_txtTPH.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTPH_Right,objContent.m_strTPHXML);

			this.m_txtTPCO2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTPCO2_Right,objContent.m_strTPCO2XML);
			this.m_txtTP02.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTP02_Right,objContent.m_strTPO2XML);
			this.m_txtTHCO3.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTHCO3_Right,objContent.m_strTHCO3XML);
			this.m_txtTTCO2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTTCO2_Right,objContent.m_strTTCO2XML);
			this.m_txtTBE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTBE_Right,objContent.m_strTBEXML);
			this.m_txtTSAT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTSAT_Right,objContent.m_strTSATXML);

			this.m_txtTO2CT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTO2CT_Right,objContent.m_strTO2CTXML);
			this.m_txtSCMH2O.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSCMH2O_Right,objContent.m_strSCMH2OXML);
			this.m_txtSSD.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSSD_Right,objContent.m_strSSDXML);
			this.m_txtSMEAN.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSMEAN_Right,objContent.m_strSMEANXML);
			this.m_txtSWEDGE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSWEDGE_Right,objContent.m_strSWEDGEXML);
			this.m_txtSCOCI.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSCOCI_Right,objContent.m_strSCOCIXML);

			//add
			this.m_txtIBLOODPRODUCE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strIBLOODPRODUCE_Right,objContent.m_strIBLOODPRODUCEXML);
			this.m_txtIBLOODPRO.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strIBLOODPRODUCEAD_Right,objContent.m_strIBLOODPRODUCEADDXML);
			this.m_txtPPUPLRIGHT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPPUPLRIGH_RightT,objContent.m_strPPUPLRIGHTXML);
			this.m_txtPREFLECTRIGHT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPREFLECTRIGHT_Right,objContent.m_strPREFLECTRIGHTXML);
			this.m_txtINNAME1.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINNAME1_Right,objContent.m_strINNAME1XML);
			this.m_txtINNAME2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINNAME2_Right,objContent.m_strINNAME2XML);
			this.m_txtINNAME3.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINNAME3_Right,objContent.m_strINNAME3XML);
			this.m_txtINNAME4.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINNAME4_Right,objContent.m_strINNAME4XML);
			this.m_txtINAMOUNT1.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINAMOUNT1_Right,objContent.m_strINAMOUNT1XML);
			this.m_txtINAMOUNT2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINAMOUNT2_Right,objContent.m_strINAMOUNT2XML);
			this.m_txtINAMOUNT3.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINAMOUNT3_Right,objContent.m_strINAMOUNT3XML);
			this.m_txtINAMOUNT4.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINAMOUNT4_Right,objContent.m_strINAMOUNT4XML);
			this.m_txtOEMIEMCTION.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOEMIEMCTION_Right,objContent.m_strOEMEMCTIONXML);
			this.m_txtOGASTRICJUICE.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOGASTRICJUICE_Right,objContent.m_strOGASTRICJUICEXML);
			this.m_txtOUTNAME1.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTNAME1_Right,objContent.m_strOUTNAME1XML);
			this.m_txtOUTNAME2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTNAME2_Right,objContent.m_strOUTNAME2XML);
			this.m_txtOUTNAME3.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTNAME3_Right,objContent.m_strOUTNAME3XML);
			this.m_txtOUTNAME4.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTNAME4_Right,objContent.m_strOUTNAME4XML);
			this.m_txtOUTAMOUNT1.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTAMOUNT1_Right,objContent.m_strOUTAMOUNT1XML);
			this.m_txtOUTAMOUNT2.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTAMOUNT2_Right,objContent.m_strOUTAMOUNT2XML);
			this.m_txtOUTAMOUNT3.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTAMOUNT3_Right,objContent.m_strOUTAMOUNT3XML);
			this.m_txtOUTAMOUNT4.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTAMOUNT4_Right,objContent.m_strOUTAMOUNT4XML);
			this.m_txtBFI02PEEPRIGHT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBFI02PEEPRIGHT_Right,objContent.m_strBFI02PEEPRIGHTXML);
			this.m_txtBPHLEGMAMOUNT.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBPHLEGMAMOUNT_Right,objContent.m_strBPHLEGMAMOUNTXML);
			
			



			m_txtWeight.Text=objContent.m_strWEIGHT;
			m_txtIDCode.Text=objContent.m_strIDCODE;
			m_txtOperationName.Text=objContent.m_strOPERATIONNAME;
			if(objContent.m_strOPERATIONDATE.ToString("yyyy-MM-dd")=="0001-01-01")
				m_dtpOperationDate.Value=DateTime.Now;
			else
				m_dtpOperationDate.Value=objContent.m_strOPERATIONDATE;
			if(objContent.m_dtmCreateDate.ToString("yyyy-MM-dd")=="0001-01-01")
				m_dtpCreateDate.Value=DateTime.Now;
			else
				m_dtpCreateDate.Value=objContent.m_dtmCreateDate;
			//m_dtpOperationDate.Text =objContent.m_strOPERATIONDATE.ToString();
			m_txtDATEAFTEROPERATION.Text=objContent.m_strDATEAFTEROPERATION;
//			clsEmployee objEmployee=new clsEmployee(objContent.m_strCreateUserID);
//			if(objEmployee !=null)
//				m_txtSign.Text=objEmployee.m_StrFirstName;
//			this.m_txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;

			//从界面获取表单值		
			clsISURGERYICUWARDSHIP objContent=new clsISURGERYICUWARDSHIP();
			try
			{

//				objContent.m_dtmCreateDate =DateTime.Now ;
				objContent.m_dtmCreateDate =m_dtpCreateDate.Value  ;

				objContent.m_strPBODYPART=this.m_txtPBODYPART.m_strGetRightText();
				objContent.m_strPBODYPARTXML=this.m_txtPBODYPART.m_strGetXmlText();

				objContent.m_strPCONSCIOUSNESS=this.m_txtPCONSCIOUSNESS.Text;
				objContent.m_strPCONSCIOUSNESSXML=this.m_txtPCONSCIOUSNESS.m_strGetXmlText();

				objContent.m_strPPUPIL=this.m_txtPPUPIL.Text;
				objContent.m_strPPUPILXML=this.m_txtPPUPIL.m_strGetXmlText();
				objContent.m_strPREFLECT=this.m_txtPREFLECT.Text;
				objContent.m_strPREFLECTXML=this.m_txtPREFLECT.m_strGetXmlText();

				objContent.m_strCTEMPERATURE=this.m_txtCTEMPERATURE.Text;
				objContent.m_strCTEMPERATUREXML=this.m_txtCTEMPERATURE.m_strGetXmlText();
				objContent.m_strCSMALLTEMPERATURE=this.m_txtCSMALLTEMPERATURE.Text;
				objContent.m_strCSMALLTEMPERATUREXML=this.m_txtCSMALLTEMPERATURE.m_strGetXmlText();

				objContent.m_strPPUPIL=this.m_txtPPUPIL.Text;
				objContent.m_strPPUPILXML=this.m_txtPPUPIL.m_strGetXmlText();
				objContent.m_strPCONSCIOUSNESS=this.m_txtPCONSCIOUSNESS.Text;
				objContent.m_strPCONSCIOUSNESSXML=this.m_txtPCONSCIOUSNESS.m_strGetXmlText();

				objContent.m_strCHEARTRATE=this.m_txtCHEARTRATE.Text;
				objContent.m_strCHEARTRATEXML=this.m_txtCHEARTRATE.m_strGetXmlText();
				objContent.m_strCHEARTRHYTHM=this.m_txtCHEARTRHYTHM.Text;
				objContent.m_strCHEARTRHYTHMXML=this.m_txtCHEARTRHYTHM.m_strGetXmlText();

				objContent.m_strCSD=this.m_txtCSD.Text;
				objContent.m_strCSDXML=this.m_txtCSD.m_strGetXmlText();
				objContent.m_strCCVP=this.m_txtCCVP.Text;
				objContent.m_strCCVPXML=this.m_txtCCVP.m_strGetXmlText();

				objContent.m_strDPHYSIC1=this.m_txtDPHYSIC1.Text;
				objContent.m_strDPHYSIC1XML=this.m_txtDPHYSIC1.m_strGetXmlText();
				objContent.m_strDPHYSIC2=this.m_txtDPHYSIC2.Text;
				objContent.m_strDPHYSIC2XML=this.m_txtDPHYSIC2.m_strGetXmlText();
				objContent.m_strDPHYSIC3=this.m_txtDPHYSIC3.Text;
				objContent.m_strDPHYSIC3XML=this.m_txtDPHYSIC3.m_strGetXmlText();
				objContent.m_strDPHYSIC4=this.m_txtDPHYSIC4.Text;
				objContent.m_strDPHYSIC4XML=this.m_txtDPHYSIC4.m_strGetXmlText();
				objContent.m_strDPHYSIC5=this.m_txtDPHYSIC5.Text;
				objContent.m_strDPHYSIC5XML=this.m_txtDPHYSIC5.m_strGetXmlText();
				objContent.m_strDPHYSIC6=this.m_txtDPHYSIC6.Text;
				objContent.m_strDPHYSIC6XML=this.m_txtDPHYSIC6.m_strGetXmlText();
				objContent.m_strDPHYSIC7=this.m_txtDPHYSIC7.Text;
				objContent.m_strDPHYSIC7XML=this.m_txtDPHYSIC7.m_strGetXmlText();
				objContent.m_strDPHYSIC8=this.m_txtDPHYSIC8.Text;
				objContent.m_strDPHYSIC8XML=this.m_txtDPHYSIC8.m_strGetXmlText();

				objContent.m_strDCURE1=this.m_txtDCURE1.Text;
				objContent.m_strDCURE1XML=this.m_txtDCURE1.m_strGetXmlText();
				objContent.m_strDCURE2=this.m_txtDCURE2.Text;
				objContent.m_strDCURE2XML=this.m_txtDCURE2.m_strGetXmlText();
				objContent.m_strDCURE3=this.m_txtDCURE3.Text;
				objContent.m_strDCURE3XML=this.m_txtDCURE3.m_strGetXmlText();
				objContent.m_strDCURE4=this.m_txtDCURE4.Text;
				objContent.m_strDCURE4XML=this.m_txtDCURE4.m_strGetXmlText();
				objContent.m_strDCURE5=this.m_txtDCURE5.Text;
				objContent.m_strDCURE5XML=this.m_txtDCURE5.m_strGetXmlText();
				objContent.m_strDCURE6=this.m_txtDCURE6.Text;
				objContent.m_strDCURE6XML=this.m_txtDCURE6.m_strGetXmlText();
				objContent.m_strDCURE7=this.m_txtDCURE7.Text;
				objContent.m_strDCURE7XML=this.m_txtDCURE7.m_strGetXmlText();
				objContent.m_strDCURE8=this.m_txtDCURE8.Text;
				objContent.m_strDCURE8XML=this.m_txtDCURE8.m_strGetXmlText();

				objContent.m_fltIGS=m_txtIGS.Text.Trim().Length>0 ? float.Parse(this.m_txtIGS.Text):0;
				objContent.m_strIGSXML=this.m_txtIGS.m_strGetXmlText();
				objContent.m_fltINS=m_txtINS.Text.Trim().Length>0 ? float.Parse(this.m_txtINS.Text):0;
				objContent.m_strINSXML=this.m_txtINS.m_strGetXmlText();
				objContent.m_fltINTATAL=m_txtINTATAL.Text.Trim().Length>0 ? float.Parse(this.m_txtINTATAL.Text):0;
				objContent.m_strINTATALXML=this.m_txtINTATAL.m_strGetXmlText();
				objContent.m_fltOTATAL=m_txtOTATAL.Text.Trim().Length>0 ? float.Parse(this.m_txtOTATAL.Text):0;
				objContent.m_strOTATALXML=this.m_txtOTATAL.m_strGetXmlText();
				objContent.m_fltOEMIEMCTION=m_txtOEMIEMCTION.Text.Trim().Length>0 ?  float.Parse(this.m_txtOEMIEMCTION.Text):0;
				objContent.m_strOEMEMCTIONXML=this.m_txtOEMIEMCTION.m_strGetXmlText();
				objContent.m_fltOGASTRICJUICE=m_txtOGASTRICJUICE.Text.Trim().Length>0 ? float.Parse(this.m_txtOGASTRICJUICE.Text):0;
				objContent.m_strOGASTRICJUICEXML=this.m_txtOGASTRICJUICE.m_strGetXmlText();
				objContent.m_strSESPECIALLYNOTE=this.m_txtSESPECIALLYNOTE.Text;
				objContent.m_strSESPECIALLYNOTEXML=this.m_txtSESPECIALLYNOTE.m_strGetXmlText();
				objContent.m_strBBLUSETIME=this.m_txtBBLUSETIME.Text;
				objContent.m_strBBLUSETIMEXML=this.m_txtBBLUSETIME.m_strGetXmlText();
				objContent.m_strBBLUSEMACHINETYPE=this.m_txtBBLUSEMACHINETYPE.Text;
				objContent.m_strBBLUSEMACHINETYPEXML=this.m_txtBBLUSEMACHINETYPE.m_strGetXmlText();
				objContent.m_strBBLUSEMODE=this.m_txtBBLUSEMODE.Text;
				objContent.m_strBBLUSEMONDEXML=this.m_txtBBLUSEMODE.m_strGetXmlText();

				objContent.m_strBVT=this.m_txtBVT.Text;
				objContent.m_strBVTXML=this.m_txtBVT.m_strGetXmlText();
				objContent.m_strBEXPIREDMV=this.m_txtBEXPIREDMV.Text;
				objContent.m_strBEXPIREDMVXML=this.m_txtBEXPIREDMV.m_strGetXmlText();
				objContent.m_strBBLUESPRESSURE=this.m_txtBBLUESPRESSURE.Text;
				objContent.m_strBBLUESPRESSUREXML=this.m_txtBBLUESPRESSURE.m_strGetXmlText();
				objContent.m_strBBLUSENUM=this.m_txtBBLUSENUM.Text;
				objContent.m_strBBLUSENUMXML=this.m_txtBBLUSENUM.m_strGetXmlText();
				objContent.m_strBFIO2PEEP=this.m_txtBFIO2PEEP.Text;
				objContent.m_strBFIO2PEEPXML=this.m_txtBFIO2PEEP.m_strGetXmlText();
				objContent.m_strBMAXIP=this.m_txtBMAXIP.Text;
				objContent.m_strBMAXIPXML=this.m_txtBMAXIP.m_strGetXmlText();
				objContent.m_strBBLUSESOUND=this.m_txtBBLUSESOUND.Text;
				objContent.m_strBBLUSESOUNDXML=this.m_txtBBLUSESOUND.m_strGetXmlText();
				objContent.m_strBPHLEGMCOLOR=this.m_txtBPHLEGMCOLOR.Text;
				objContent.m_strBPHLEGMCOLORXML=this.m_txtBPHLEGMCOLOR.m_strGetXmlText();
				objContent.m_strBSQ2=this.m_txtBSQ2.Text;
				objContent.m_strTCOLLECTBLOODPOINTXML=this.m_txtTCOLLECTBLOODPOINT.m_strGetXmlText();
				objContent.m_strTCOLLECTBLOODPOINT=this.m_txtTCOLLECTBLOODPOINT.Text;
				objContent.m_strBSQ2XML=this.m_txtBSQ2.m_strGetXmlText();

				objContent.m_strTPH=this.m_txtTPH.Text;
				objContent.m_strTPHXML=this.m_txtTPH.m_strGetXmlText();
				objContent.m_strTPCO2=this.m_txtTPCO2.Text;
				objContent.m_strTPCO2XML=this.m_txtTPCO2.m_strGetXmlText();
				objContent.m_strTP02=this.m_txtTP02.Text;
				objContent.m_strTPO2XML=this.m_txtTP02.m_strGetXmlText();
				objContent.m_strTHCO3=this.m_txtTHCO3.Text;
				objContent.m_strTHCO3XML=this.m_txtTHCO3.m_strGetXmlText();
				objContent.m_strTTCO2=this.m_txtTTCO2.Text;
				objContent.m_strTTCO2XML=this.m_txtTTCO2.m_strGetXmlText();
				objContent.m_strTBE=this.m_txtTBE.Text;
				objContent.m_strTBEXML=this.m_txtTBE.m_strGetXmlText();
				
				objContent.m_strTSAT=this.m_txtTSAT.Text;
				objContent.m_strTSATXML=this.m_txtTSAT.m_strGetXmlText();
				objContent.m_strTO2CT=this.m_txtTO2CT.Text;
				objContent.m_strTO2CTXML=this.m_txtTO2CT.m_strGetXmlText();
				objContent.m_strSCMH2O=this.m_txtSCMH2O.Text;
				objContent.m_strSCMH2OXML=this.m_txtSCMH2O.m_strGetXmlText();
				objContent.m_strSSD=this.m_txtSSD.Text;
				objContent.m_strSSDXML=this.m_txtSSD.m_strGetXmlText();
				objContent.m_strSMEAN=this.m_txtSMEAN.Text;
				objContent.m_strSMEANXML=this.m_txtSMEAN.m_strGetXmlText();
				objContent.m_strSWEDGE=this.m_txtSWEDGE.Text;
				objContent.m_strSWEDGEXML=this.m_txtSWEDGE.m_strGetXmlText();
				objContent.m_strSCOCI=this.m_txtSCOCI.Text;
				objContent.m_strSCOCIXML=this.m_txtSCOCI.m_strGetXmlText();
			
//				objContent.m_strCreateUserID = ((clsEmployee)m_txtSign.Tag).m_StrEmployeeID;
				
				objContent.m_dtmModifyDate = DateTime.Now;
				objContent.m_strModifyUserID = MDIParent.OperatorID;
				//if(objContent.m_dtmRECORDDATE.ToString("yyyy-MM-dd")=="0001-01-01")
				objContent.m_dtmRECORDDATE = m_dtpCreateDate.Value; //DateTime.Now;//;

				objContent.m_strWEIGHT=m_txtWeight.Text.Trim();
				objContent.m_strIDCODE=m_txtIDCode.Text.Trim();
				objContent.m_strOPERATIONNAME=m_txtOperationName.Text.Trim();
				objContent.m_strOPERATIONDATE=(DateTime)m_dtpOperationDate.Value;
				objContent.m_strDATEAFTEROPERATION=m_txtDATEAFTEROPERATION.Text.Trim();

				objContent.m_strPPUPLRIGHT=m_txtPPUPLRIGHT.Text.Trim();  //瞳孔(右)
				objContent.m_strPREFLECTRIGHT=m_txtPREFLECTRIGHT.Text.Trim();//对光反射(右)'

				objContent.m_fltIBLOODPRODUCE= m_txtIBLOODPRODUCE.Text.Trim().Length>0 ? float.Parse(m_txtIBLOODPRODUCE.Text.Trim()):0;//血制品';
				objContent.m_fltIBLOODPRODUCEADD=m_txtIBLOODPRO.Text.Trim().Length>0 ? float.Parse(m_txtIBLOODPRO.Text.Trim()):0;// '血制品累计量';
				objContent.m_strINNAME1=m_txtINNAME1.Text.Trim();//入量名称1';
				objContent.m_strINNAME2=m_txtINNAME2.Text.Trim();//入量名称2';
				objContent.m_strINNAME3=m_txtINNAME3.Text.Trim();//入量名称3';
				objContent.m_strINNAME4=m_txtINNAME4.Text.Trim();//入量名称4';
				objContent.m_fltINAMOUNT1=m_txtINAMOUNT1.Text.Trim().Length>0 ? float.Parse(m_txtINAMOUNT1.Text.Trim()):0;//入量数量1';
				objContent.m_fltINAMOUNT2=m_txtINAMOUNT2.Text.Trim().Length>0 ? float.Parse(m_txtINAMOUNT2.Text.Trim()):0;//入量数量2';
				objContent.m_fltINAMOUNT3=m_txtINAMOUNT3.Text.Trim().Length>0 ? float.Parse(m_txtINAMOUNT3.Text.Trim()):0;//入量数量3';
				objContent.m_fltINAMOUNT4=m_txtINAMOUNT4.Text.Trim().Length>0 ? float.Parse(m_txtINAMOUNT4.Text.Trim()):0;//入量数量4';
				objContent.m_fltINTATAL=m_txtINTATAL.Text.Trim().Length>0 ? float.Parse(m_txtINTATAL.Text.Trim()):0;//总入量';
				objContent.m_strOUTNAME1=m_txtOUTNAME1.Text.Trim();//出量名称1';
				objContent.m_strOUTNAME2=m_txtOUTNAME2.Text.Trim();//出量名称2';
				objContent.m_strOUTNAME3=m_txtOUTNAME3.Text.Trim();//出量名称3';
				objContent.m_strOUTNAME4=m_txtOUTNAME4.Text.Trim();//出量名称4';
				objContent.m_fltOUTAMOUNT1=m_txtOUTAMOUNT1.Text.Trim().Length>0 ? float.Parse(m_txtOUTAMOUNT1.Text.Trim()):0;//出量数量1';
				objContent.m_fltOUTAMOUNT2=m_txtOUTAMOUNT2.Text.Trim().Length>0 ? float.Parse(m_txtOUTAMOUNT2.Text.Trim()):0;//出量数量2';
				objContent.m_fltOUTAMOUNT3=m_txtOUTAMOUNT3.Text.Trim().Length>0 ? float.Parse(m_txtOUTAMOUNT3.Text.Trim()):0;//出量数量3';
				objContent.m_fltOUTAMOUNT4=m_txtOUTAMOUNT4.Text.Trim().Length>0 ? float.Parse(m_txtOUTAMOUNT4.Text.Trim()):0;//出量数量4';
				objContent.m_fltOTATAL=m_txtOTATAL.Text.Trim().Length>0 ? float.Parse(m_txtOTATAL.Text.Trim()):0;//总入量';
				objContent.m_strBFI02PEEPRIGHT=m_txtBFI02PEEPRIGHT.Text.Trim();//PEEP
				objContent.m_strBPHLEGMAMOUNT=m_txtBPHLEGMAMOUNT.Text.Trim();//痰量

				objContent.m_strPPUPLRIGHTXML=m_txtPPUPLRIGHT.m_strGetXmlText();  //瞳孔(右)
				objContent.m_strPREFLECTRIGHTXML=m_txtPREFLECTRIGHT.m_strGetXmlText();//对光反射(右)'
				objContent.m_strIBLOODPRODUCEXML=m_txtIBLOODPRODUCE.m_strGetXmlText();//血制品';
				objContent.m_strIBLOODPRODUCEADDXML=m_txtIBLOODPRO.m_strGetXmlText();// '血制品累计量';
				objContent.m_strINNAME1XML=m_txtINNAME1.m_strGetXmlText();//入量名称1';
				objContent.m_strINNAME2XML=m_txtINNAME2.m_strGetXmlText();//入量名称2';
				objContent.m_strINNAME3XML=m_txtINNAME3.m_strGetXmlText();//入量名称3';
				objContent.m_strINNAME4XML=m_txtINNAME4.m_strGetXmlText();//入量名称4';
				objContent.m_strINAMOUNT1XML=m_txtOUTNAME1.m_strGetXmlText();//入量数量1';
				objContent.m_strINAMOUNT2XML=m_txtOUTNAME2.m_strGetXmlText();//入量数量2';
				objContent.m_strINAMOUNT3XML=m_txtOUTNAME3.m_strGetXmlText();//入量数量3';
				objContent.m_strINAMOUNT4XML=m_txtOUTNAME4.m_strGetXmlText();//入量数量4';
				objContent.m_strOUTNAME1XML=m_txtOUTNAME1.m_strGetXmlText();//出量名称1';
				objContent.m_strOUTNAME2XML=m_txtOUTNAME2.m_strGetXmlText();//出量名称2';
				objContent.m_strOUTNAME3XML=m_txtOUTNAME3.m_strGetXmlText();//出量名称3';
				objContent.m_strOUTNAME4XML=m_txtOUTNAME4.m_strGetXmlText();//出量名称4';
				objContent.m_strOUTAMOUNT1XML=m_txtOUTAMOUNT1.m_strGetXmlText();//出量数量1';
				objContent.m_strOUTAMOUNT2XML=m_txtOUTAMOUNT2.m_strGetXmlText();//出量数量2';
				objContent.m_strOUTAMOUNT3XML=m_txtOUTAMOUNT3.m_strGetXmlText();//出量数量3';
				objContent.m_strOUTAMOUNT4XML=m_txtOUTAMOUNT4.m_strGetXmlText();//出量数量4';
				objContent.m_strBFI02PEEPRIGHTXML=m_txtBFI02PEEPRIGHT.m_strGetXmlText();//PEEP
				objContent.m_strBPHLEGMAMOUNTXML=m_txtBPHLEGMAMOUNT.m_strGetXmlText();//痰量

				
			}
		
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return(objContent );		
		}

		protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.SURGERYICUWARDSHIP);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsISURGERYICUWARDSHIP objContent=(clsISURGERYICUWARDSHIP)p_objRecordContent;
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现

			return	"外科ICU监护记录";
		}

		private void label12_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			

			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.None;
			this.Close();
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtPBODYPART,m_txtPCONSCIOUSNESS,m_txtPPUPIL,m_txtPPUPLRIGHT,
								 m_txtPREFLECT,m_txtPREFLECTRIGHT,m_txtCTEMPERATURE,m_txtCSMALLTEMPERATURE,
								 m_txtCHEARTRATE,m_txtCHEARTRHYTHM,m_txtCSD,m_txtCCVP,m_txtIBLOODPRODUCE,
								 m_txtIBLOODPRO,m_txtIGS,m_txtINS,m_txtINNAME1,m_txtINAMOUNT1,m_txtINNAME2,
								 m_txtINAMOUNT2,m_txtINNAME3,m_txtINAMOUNT3,m_txtINNAME4,m_txtINAMOUNT4,
								 m_txtOEMIEMCTION,m_txtOGASTRICJUICE,m_txtOUTNAME1,m_txtOUTAMOUNT1,m_txtOUTNAME2,
								 m_txtOUTAMOUNT2,m_txtOUTNAME3,m_txtOUTAMOUNT3,m_txtOUTNAME4,m_txtOUTAMOUNT4,
								 m_txtSESPECIALLYNOTE,m_txtDPHYSIC1,m_txtDCURE1,m_txtDPHYSIC2,m_txtDCURE2,
								 m_txtDPHYSIC3,m_txtDCURE3,m_txtDPHYSIC4,m_txtDCURE4,m_txtDPHYSIC5,m_txtDCURE5,
								 m_txtDPHYSIC6,m_txtDCURE6,m_txtDPHYSIC7,m_txtDCURE7,m_txtDPHYSIC8,m_txtDCURE8,
								 m_txtTCOLLECTBLOODPOINT,m_txtTPH,m_txtTPCO2,m_txtTP02,m_txtTHCO3,m_txtTTCO2,
								 m_txtTBE,m_txtTSAT,m_txtTO2CT,m_txtBBLUSETIME,m_txtBBLUSEMACHINETYPE,
								 m_txtBBLUSEMODE,m_txtBVT,m_txtBEXPIREDMV,m_txtBBLUESPRESSURE,m_txtBBLUSENUM,
								 m_txtBFIO2PEEP,m_txtBFI02PEEPRIGHT,m_txtBMAXIP,m_txtBBLUSESOUND,m_txtBPHLEGMCOLOR,
								 m_txtBPHLEGMAMOUNT,m_txtBSQ2,m_txtSCMH2O,m_txtSSD,m_txtSMEAN,m_txtSWEDGE,
								 m_txtSCOCI},Keys.Enter);
		}
		#endregion

		private void m_txtIBLOODPRO_Leave(object sender, System.EventArgs e)
		{
			float fltCheckValueInTotal=0;
			com.digitalwave.controls.ctlRichTextBox txbTemp=new com.digitalwave.controls.ctlRichTextBox();;
			string strExceptionBox=null;
			string strErrorMessage=null;
			//数值有效检验
			try
			{
				if(m_txtIBLOODPRO.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtIBLOODPRO";
					fltCheckValueInTotal+=float.Parse(m_txtIBLOODPRO.Text.Trim());
					txbTemp=m_txtIBLOODPRO;
				}
				if(m_txtIGS.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtIGS";
					fltCheckValueInTotal+=float.Parse(m_txtIGS.Text.Trim());
					txbTemp=m_txtIGS;
				}
				if(m_txtINS.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtINS";
					fltCheckValueInTotal+=float.Parse(m_txtINS.Text.Trim());
					txbTemp=m_txtINS;
				}
				if(m_txtINAMOUNT1.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtINAMOUNT1";
					fltCheckValueInTotal+=float.Parse(m_txtINAMOUNT1.Text.Trim());
					txbTemp=m_txtINAMOUNT1;
				}
				if(m_txtINAMOUNT2.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtINAMOUNT2";
					fltCheckValueInTotal+=float.Parse(m_txtINAMOUNT2.Text.Trim());
					txbTemp=m_txtINAMOUNT2;

				}
				if(m_txtINAMOUNT3.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtINAMOUNT31";
					fltCheckValueInTotal+=float.Parse(m_txtINAMOUNT3.Text.Trim());
					txbTemp=m_txtINAMOUNT3;

				}
				if(m_txtINAMOUNT4.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtINAMOUNT4";
					fltCheckValueInTotal+=float.Parse(m_txtINAMOUNT4.Text.Trim());
					txbTemp=m_txtINAMOUNT4;

				}
				
			}
			catch(Exception ex)
			{
				ex.ToString();
				switch(strExceptionBox)
				{
					case "m_txtIBLOODPRO":
						strErrorMessage="入量血制品累计量请输入数值";
						//m_txtIBLOODPRO.Focus();
						m_txtIBLOODPRO.Enabled=true;
						m_txtIBLOODPRO.ReadOnly=false;
						break;
					case "m_txtIGS":
						strErrorMessage="入量GS请输入数值";
						//m_txtIGS.Focus();
						m_txtIGS.Enabled=true;
						m_txtIGS.ReadOnly=false;
						break;
					case "m_txtINS":
						strErrorMessage="入量NS请输入数值";
						//m_txtINS.Focus();
						m_txtIGS.Enabled=true;
						m_txtIGS.ReadOnly=false;
						break;
					case "m_txtINAMOUNT1":
						strErrorMessage="入量数量请输入数值";
						//m_txtINAMOUNT1.Focus();
						m_txtINAMOUNT1.Enabled=true;
						m_txtINAMOUNT1.ReadOnly=false;
						break;
					case "m_txtINAMOUNT2":
						strErrorMessage="入量数量请输入数值";
						//m_txtINAMOUNT2.Focus();
						m_txtINAMOUNT2.Enabled=true;
						m_txtINAMOUNT2.ReadOnly=false;
						break;
					case "m_txtINAMOUNT3":
						strErrorMessage="入量数量请输入数值";
						//m_txtINAMOUNT3.Focus();
						m_txtINAMOUNT3.Enabled=true;
						m_txtINAMOUNT3.ReadOnly=false;
						break;
					case "m_txtINAMOUNT4":
						strErrorMessage="入量数量请输入数值";
						//m_txtINAMOUNT4.Focus();
						m_txtINAMOUNT4.Enabled=true;
						m_txtINAMOUNT4.ReadOnly=false;
						break;
				}
				MessageBox.Show(strErrorMessage,"提示");
				//txbTemp.Focus();
				return ;
								
			}
			//实时计算出入量的累计值
			m_txtINTATAL.Text =fltCheckValueInTotal.ToString();
		
		}

		private void m_txtOEMIEMCTION_Leave(object sender, System.EventArgs e)
		{
			com.digitalwave.controls.ctlRichTextBox txbTemp=new com.digitalwave.controls.ctlRichTextBox();
			float fltCheckValueOutTotal=0;
			string strExceptionBox=null;
			string strErrorMessage=null;
			//数值有效检验
			try
			{
				
				if(m_txtOEMIEMCTION.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtOEMIEMCTION";
					fltCheckValueOutTotal+=float.Parse(m_txtOEMIEMCTION.Text.Trim());
					txbTemp=m_txtOEMIEMCTION;
				}
				
				if(m_txtOGASTRICJUICE.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtOGASTRICJUICE";
					fltCheckValueOutTotal+=float.Parse(m_txtOGASTRICJUICE.Text.Trim());
					txbTemp=m_txtOGASTRICJUICE;
				}
				if(m_txtOUTAMOUNT1.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtOUTAMOUNT1";
					fltCheckValueOutTotal+=float.Parse(m_txtOUTAMOUNT1.Text.Trim());
					txbTemp=m_txtOUTAMOUNT1;
				}
				if(m_txtOUTAMOUNT2.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtOUTAMOUNT2";
					fltCheckValueOutTotal+=float.Parse(m_txtOUTAMOUNT2.Text.Trim());
					txbTemp=m_txtOUTAMOUNT2;
				}
				if(m_txtOUTAMOUNT3.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtOUTAMOUNT3";
					fltCheckValueOutTotal+=float.Parse(m_txtOUTAMOUNT3.Text.Trim());
					txbTemp=m_txtOUTAMOUNT3;
				}
				if(m_txtOUTAMOUNT4.Text.Trim().Length>0)
				{
					strExceptionBox="m_txtOUTAMOUNT4";
					fltCheckValueOutTotal+=float.Parse(m_txtOUTAMOUNT4.Text.Trim());
					txbTemp=m_txtOUTAMOUNT4;
				}
			}
			catch(Exception ex)
			{
				ex.ToString();
				switch(strExceptionBox)
				{
					
					case "m_txtOEMIEMCTION":
						strErrorMessage="出量尿量请输入数值";
						//m_txtOEMIEMCTION.Focus();
						m_txtOEMIEMCTION.Enabled=true;
						m_txtOEMIEMCTION.ReadOnly=false;
						break;
					case "m_txtOGASTRICJUICE":
						strErrorMessage="出量胃液请输入数值";
						//m_txtOGASTRICJUICE.Focus();
						m_txtOGASTRICJUICE.Enabled=true;
						m_txtOGASTRICJUICE.ReadOnly=false;
						break;
					case "m_txtOUTAMOUNT1":
						strErrorMessage="出量数量请输入数值";
						//m_txtOUTAMOUNT1.Focus();
						m_txtOUTAMOUNT1.Enabled=true;
						m_txtOUTAMOUNT1.ReadOnly=false;
						break;
					case "m_txtOUTAMOUNT2":
						strErrorMessage="出量数量请输入数值";
						//m_txtOUTAMOUNT2.Focus();
						m_txtOUTAMOUNT2.Enabled=true;
						m_txtOUTAMOUNT2.ReadOnly=false;
						break;
					case "m_txtOUTAMOUNT3":
						strErrorMessage="出量数量请输入数值";
						//m_txtOUTAMOUNT3.Focus();
						m_txtOUTAMOUNT3.Enabled=true;
						m_txtOUTAMOUNT3.ReadOnly=false;
						break;
					case "m_txtOUTAMOUNT4":
						strErrorMessage="出量数量请输入数值";
						//m_txtOUTAMOUNT4.Focus();
						m_txtOUTAMOUNT4.Enabled=true;
						m_txtOUTAMOUNT4.ReadOnly=false;
						break;
				}
				MessageBox.Show(strErrorMessage,"提示");
				//txbTemp.Focus();
				return ;
								
			}
			//实时计算出入量的累计值
			
			m_txtOTATAL.Text=fltCheckValueOutTotal.ToString();
		}


		
	}
}
