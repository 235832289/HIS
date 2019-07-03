using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using System.Drawing.Printing ;
using System.Data;
using com.digitalwave.controls;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
	/// 新生儿入室记录
	/// </summary>
	public class frmNewBabyInRoomRecord : iCare.frmBaseCaseHistory
	{
		#region 控件

        private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
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
		private System.Windows.Forms.Panel panel3;
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
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
		private PinkieControls.ButtonXP m_cmdDoctorSign;
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
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.RadioButton m_rdbSmoothBirth;
		private System.Windows.Forms.RadioButton m_rdbClampBirth;
		private System.Windows.Forms.RadioButton m_rdbSuctionBirth;
		private System.Windows.Forms.RadioButton m_rdbCaesareanBirth;
		private System.Windows.Forms.RadioButton m_rdbBreechDelivery;
		private System.Windows.Forms.RadioButton m_rdbBreechNature;
		private System.Windows.Forms.RadioButton m_rdbBreechHalf;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBirthBurl;
		protected com.digitalwave.controls.ctlRichTextBox m_txtHaematoma;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPregnantWeeks;
        private System.Windows.Forms.RadioButton m_rdbBreechTow;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCryVoice;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDropsy;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboColor;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboElasticity;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboIcterus;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboSkullSoft;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPigment;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPetechia;
		private System.Windows.Forms.RadioButton m_rdbFontanelOut;
		private System.Windows.Forms.RadioButton m_rdbFontanelSatiation;
		private System.Windows.Forms.RadioButton m_rdbFontanelLow;
		private System.Windows.Forms.RadioButton m_rdbFontanelFlat;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBoneSew;
		protected com.digitalwave.controls.ctlRichTextBox m_txtHeadRound;
		protected com.digitalwave.controls.ctlRichTextBox m_txtOtherRecord;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboVein;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLiver;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboSpleen;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHilum;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFacialFeatures;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboMouth;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHeart;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLung;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboChest;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboActivity;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboArthrosis;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboAbnormality;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboGenitalia;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboSkin;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboGenitalia_OutHospital;
		protected com.digitalwave.controls.ctlRichTextBox m_txtWeight;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHeart_OutHospital;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHead;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLung_OutHospital;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboButtocks;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboNormalCircs;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLactation;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBLiverBacterin;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBcgVaccine;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLimb;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboAbdomen;
		private PinkieControls.ButtonXP m_cmdCheckDoc;
		protected com.digitalwave.controls.ctlRichTextBox m_txtOutHospitalAdvice;
		protected com.digitalwave.controls.ctlRichTextBox m_txtDealWith;
		protected com.digitalwave.controls.ctlRichTextBox m_txtOtherCheck;
		private System.Windows.Forms.MenuItem m_mniAddBabyCircsRecord;
		private System.Windows.Forms.MenuItem m_mmiModifyBabyCircsRecord;
		private System.Windows.Forms.MenuItem m_mmiDelBabyCircsRecord;
		private System.ComponentModel.IContainer components;
		
		protected System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;

		
		protected System.Windows.Forms.DataGrid m_dtgRecord;
		private System.Windows.Forms.ContextMenu m_ctmRecordControl;
		private System.Windows.Forms.DataGridTextBoxColumn m_clmRecordDate;
		private System.Windows.Forms.DataGridTextBoxColumn m_clmBirthDays;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBirthBurl;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcHaematoma;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcFontanel;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcConjunctiva;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSecretion;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPharynx;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcWhitePoint;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcIcterus;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcFester;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBleeding;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcAgnail;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcRedStern;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSternSkin;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcHeartLung;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcAbdomen;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcRemark;
		private System.Windows.Forms.DataGridTextBoxColumn m_clmSign;

		#endregion

		/// <summary>
		/// 改变控件边框工具
		/// </summary>
        //private new clsBorderTool m_objBorderTool;
		public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCheckDate;

		private bool m_blnCanShowNewForm = true;
		private string m_strCurrentOpenDate = "";
		private new clsNewBabyInRoomRecord m_objCurrentRecordContent;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboReaction;
		private new clsNewBabyInRoomRecordDomain m_objDomain;
		private clsEmployeeSignTool m_objSignTool;
        private clsEmployeeSignTool m_objSignTool1;
        private TextBox m_txtDoctorSign;
        private TextBox m_txtCheckDocSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboMuscleStrain;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBabySex;
        private PinkieControls.ButtonXP m_cmdRecorder;
        private TextBox txtSign;
        protected ListView m_lsvAssistant1;
        private ColumnHeader columnHeader2;
        private PinkieControls.ButtonXP m_cmdHelp1;
        protected ListView m_lsvAssistant2;
        private ColumnHeader columnHeader3;
        private PinkieControls.ButtonXP m_cmdHelp2;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_dtpUmbilicalCordLeftTime;
        private GroupBox groupBox1;
        private RadioButton m_rdbChangeDeptC;
        private RadioButton m_rdbOutHospitalC;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker m_lblOutHospitalDate;
        private TextBox m_lblOutHospitalDays;
		/// <summary>
		/// 文字栏字体
		/// </summary>
		protected virtual Font m_FntHeaderFont
		{
			get
			{
				return new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			}
		}

		private DataTable m_dtbRecords;
		public frmNewBabyInRoomRecord()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

			
            //m_objSignTool = new clsEmployeeSignTool(listView1);
            //m_objSignTool.m_mthAddControl(m_txtDoctorSign);

            //m_objSignTool1 = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool1.m_mthAddControl(m_txtCheckDocSign);

            //new clsCommonUseToolCollection(this).m_mthBindEmployeeSign(new Control[]{this.m_cmdDoctorSign,this.m_cmdCheckDoc },
            //    new Control[]{this.m_txtDoctorSign,this.m_txtCheckDocSign},new int[]{1,1});
			
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{trvTime});

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            //m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //m_objSign.m_mthBindEmployeeSign(m_cmdCheckDoc, m_txtCheckDocSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdRecorder, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);           
          
            m_objSign.m_mthBindEmployeeSign(m_cmdHelp1, m_lsvAssistant1, 1, true , clsEMRLogin.LoginInfo.m_strEmpID,2);
            m_objSign.m_mthBindEmployeeSign(m_cmdHelp2, m_lsvAssistant2, 1, true, clsEMRLogin.LoginInfo.m_strEmpID,2);

			m_dtbRecords = new DataTable("RecordDetail");
			this.m_dtgRecord.HeaderFont = m_FntHeaderFont;
			m_objDomain = new clsNewBabyInRoomRecordDomain();
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("入院时间");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewBabyInRoomRecord));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_lsvAssistant1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdHelp1 = new PinkieControls.ButtonXP();
            this.m_cboFacialFeatures = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtBirthBurl = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtHaematoma = new com.digitalwave.controls.ctlRichTextBox();
            this.m_dtpCheckDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_txtOtherRecord = new com.digitalwave.controls.ctlRichTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.m_cboVein = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.m_cboLiver = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboSpleen = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboHilum = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_rdbFontanelOut = new System.Windows.Forms.RadioButton();
            this.m_rdbFontanelSatiation = new System.Windows.Forms.RadioButton();
            this.m_rdbFontanelLow = new System.Windows.Forms.RadioButton();
            this.m_rdbFontanelFlat = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboPregnantWeeks = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_rdbBreechNature = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_rdbBreechHalf = new System.Windows.Forms.RadioButton();
            this.m_rdbBreechTow = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_rdbSmoothBirth = new System.Windows.Forms.RadioButton();
            this.m_rdbClampBirth = new System.Windows.Forms.RadioButton();
            this.m_rdbSuctionBirth = new System.Windows.Forms.RadioButton();
            this.m_rdbCaesareanBirth = new System.Windows.Forms.RadioButton();
            this.m_rdbBreechDelivery = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboReaction = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cboMuscleStrain = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboCryVoice = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboDropsy = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_cboColor = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboElasticity = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_cboIcterus = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_cboSkullSoft = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_cboBoneSew = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtHeadRound = new com.digitalwave.controls.ctlRichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.m_cboMouth = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.m_cboHeart = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.m_cboLung = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.m_cboChest = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.m_cboActivity = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.m_cboArthrosis = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.m_cboAbnormality = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.m_cboGenitalia = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.m_cboPigment = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPetechia = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_dtgRecord = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.m_clmRecordDate = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_clmBirthDays = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcBirthBurl = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHaematoma = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcFontanel = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcConjunctiva = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSecretion = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPharynx = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcWhitePoint = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcIcterus = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcFester = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBleeding = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcAgnail = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRedStern = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSternSkin = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHeartLung = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcAbdomen = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRemark = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_clmSign = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_lblOutHospitalDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdbChangeDeptC = new System.Windows.Forms.RadioButton();
            this.m_rdbOutHospitalC = new System.Windows.Forms.RadioButton();
            this.m_lsvAssistant2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdHelp2 = new PinkieControls.ButtonXP();
            this.m_txtOutHospitalAdvice = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDealWith = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOtherCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboSkin = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboGenitalia_OutHospital = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboButtocks = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboNormalCircs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboLactation = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboBLiverBacterin = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboBcgVaccine = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboLimb = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtWeight = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboHeart_OutHospital = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboHead = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.m_dtpUmbilicalCordLeftTime = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboLung_OutHospital = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.m_cboAbdomen = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_txtDoctorSign = new System.Windows.Forms.TextBox();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.m_txtCheckDocSign = new System.Windows.Forms.TextBox();
            this.m_cmdCheckDoc = new PinkieControls.ButtonXP();
            this.m_ctmRecordControl = new System.Windows.Forms.ContextMenu();
            this.m_mniAddBabyCircsRecord = new System.Windows.Forms.MenuItem();
            this.m_mmiModifyBabyCircsRecord = new System.Windows.Forms.MenuItem();
            this.m_mmiDelBabyCircsRecord = new System.Windows.Forms.MenuItem();
            this.m_cboBabySex = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmdRecorder = new PinkieControls.ButtonXP();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_lblOutHospitalDays = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecord)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmdCreateID
            // 
            this.m_cmdCreateID.Visible = false;
            // 
            // trvTime
            // 
            this.trvTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.trvTime.LineColor = System.Drawing.Color.Black;
            this.trvTime.Location = new System.Drawing.Point(20, 130);
            treeNode1.Name = "";
            treeNode1.Text = "入院时间";
            this.trvTime.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvTime.Visible = false;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(90, 72);
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Location = new System.Drawing.Point(10, 76);
            this.lblCreateDate.Text = "出生时间:";
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.Visible = false;
            // 
            // m_lblNativePlace
            // 
            this.m_lblNativePlace.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.Location = new System.Drawing.Point(120, 200);
            this.lblOccupation.Visible = false;
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.Location = new System.Drawing.Point(168, 200);
            this.m_lblOccupation.Visible = false;
            // 
            // m_lblMarriaged
            // 
            this.m_lblMarriaged.Location = new System.Drawing.Point(456, 200);
            this.m_lblMarriaged.Visible = false;
            // 
            // lblMarriaged
            // 
            this.lblMarriaged.Location = new System.Drawing.Point(408, 200);
            this.lblMarriaged.Visible = false;
            // 
            // m_lblLinkMan
            // 
            this.m_lblLinkMan.Location = new System.Drawing.Point(432, 192);
            this.m_lblLinkMan.Visible = false;
            // 
            // lblLinkMan
            // 
            this.lblLinkMan.Location = new System.Drawing.Point(368, 192);
            this.lblLinkMan.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Visible = false;
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Visible = false;
            // 
            // lblNation
            // 
            this.lblNation.Location = new System.Drawing.Point(522, 127);
            this.lblNation.Visible = false;
            // 
            // m_lblNation
            // 
            this.m_lblNation.Location = new System.Drawing.Point(564, 127);
            this.m_lblNation.Visible = false;
            // 
            // ppdPrintPreview
            // 
            this.ppdPrintPreview.ClientSize = new System.Drawing.Size(1024, 721);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(544, 160);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(632, 160);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(405, 136);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(390, 173);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(568, 136);
            this.lblNameTitle.Size = new System.Drawing.Size(70, 14);
            this.lblNameTitle.Text = "母亲姓名:";
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(348, 80);
            this.lblSexTitle.Size = new System.Drawing.Size(70, 14);
            this.lblSexTitle.Text = "婴儿性别:";
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(584, 160);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(212, 173);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(452, 145);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(452, 171);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(648, 132);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(452, 132);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(262, 169);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(622, 191);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(452, 187);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(262, 130);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(212, 130);
            this.lblDept.Visible = false;
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(528, 132);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, 128);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(618, 122);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(704, 72);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(668, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(798, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(796, 29);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(16, 99);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 496);
            this.tabControl1.TabIndex = 10000084;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_lsvAssistant1);
            this.tabPage1.Controls.Add(this.m_cmdHelp1);
            this.tabPage1.Controls.Add(this.m_cboFacialFeatures);
            this.tabPage1.Controls.Add(this.m_txtBirthBurl);
            this.tabPage1.Controls.Add(this.m_txtHaematoma);
            this.tabPage1.Controls.Add(this.m_dtpCheckDate);
            this.tabPage1.Controls.Add(this.m_txtOtherRecord);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.m_cboVein);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.m_cboLiver);
            this.tabPage1.Controls.Add(this.m_cboSpleen);
            this.tabPage1.Controls.Add(this.m_cboHilum);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.m_cboPregnantWeeks);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.m_cboReaction);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.m_cboMuscleStrain);
            this.tabPage1.Controls.Add(this.m_cboCryVoice);
            this.tabPage1.Controls.Add(this.m_cboDropsy);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.m_cboColor);
            this.tabPage1.Controls.Add(this.m_cboElasticity);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.m_cboIcterus);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.m_cboSkullSoft);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.m_cboBoneSew);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.m_txtHeadRound);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.m_cboMouth);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.m_cboHeart);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.m_cboLung);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.m_cboChest);
            this.tabPage1.Controls.Add(this.label35);
            this.tabPage1.Controls.Add(this.m_cboActivity);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.m_cboArthrosis);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.m_cboAbnormality);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.label39);
            this.tabPage1.Controls.Add(this.m_cboGenitalia);
            this.tabPage1.Controls.Add(this.label40);
            this.tabPage1.Controls.Add(this.m_cboPigment);
            this.tabPage1.Controls.Add(this.m_cboPetechia);
            this.tabPage1.Controls.Add(this.label41);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(784, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "入室记录";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_lsvAssistant1
            // 
            this.m_lsvAssistant1.AccessibleDescription = "入室记录>>签名(txt)";
            this.m_lsvAssistant1.BackColor = System.Drawing.Color.White;
            this.m_lsvAssistant1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.m_lsvAssistant1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvAssistant1.ForeColor = System.Drawing.Color.Black;
            this.m_lsvAssistant1.FullRowSelect = true;
            this.m_lsvAssistant1.GridLines = true;
            this.m_lsvAssistant1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvAssistant1.Location = new System.Drawing.Point(315, 432);
            this.m_lsvAssistant1.Name = "m_lsvAssistant1";
            this.m_lsvAssistant1.Size = new System.Drawing.Size(457, 28);
            this.m_lsvAssistant1.TabIndex = 10000458;
            this.m_lsvAssistant1.UseCompatibleStateImageBehavior = false;
            this.m_lsvAssistant1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 55;
            // 
            // m_cmdHelp1
            // 
            this.m_cmdHelp1.AccessibleDescription = "入室记录>>签名(cmd)";
            this.m_cmdHelp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdHelp1.DefaultScheme = true;
            this.m_cmdHelp1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdHelp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdHelp1.Hint = "";
            this.m_cmdHelp1.Location = new System.Drawing.Point(232, 432);
            this.m_cmdHelp1.Name = "m_cmdHelp1";
            this.m_cmdHelp1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdHelp1.Size = new System.Drawing.Size(77, 28);
            this.m_cmdHelp1.TabIndex = 10000457;
            this.m_cmdHelp1.Tag = "1";
            this.m_cmdHelp1.Text = "签名:";
            // 
            // m_cboFacialFeatures
            // 
            this.m_cboFacialFeatures.AccessibleDescription = "入室记录>>五官";
            this.m_cboFacialFeatures.BackColor = System.Drawing.Color.White;
            this.m_cboFacialFeatures.BorderColor = System.Drawing.Color.Black;
            this.m_cboFacialFeatures.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboFacialFeatures.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboFacialFeatures.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboFacialFeatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboFacialFeatures.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFacialFeatures.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFacialFeatures.ForeColor = System.Drawing.Color.Black;
            this.m_cboFacialFeatures.ListBackColor = System.Drawing.Color.White;
            this.m_cboFacialFeatures.ListForeColor = System.Drawing.Color.Black;
            this.m_cboFacialFeatures.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboFacialFeatures.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboFacialFeatures.Location = new System.Drawing.Point(80, 206);
            this.m_cboFacialFeatures.m_BlnEnableItemEventMenu = true;
            this.m_cboFacialFeatures.MaxLength = 32767;
            this.m_cboFacialFeatures.Name = "m_cboFacialFeatures";
            this.m_cboFacialFeatures.SelectedIndex = -1;
            this.m_cboFacialFeatures.SelectedItem = null;
            this.m_cboFacialFeatures.SelectionStart = 0;
            this.m_cboFacialFeatures.Size = new System.Drawing.Size(304, 23);
            this.m_cboFacialFeatures.TabIndex = 10000084;
            this.m_cboFacialFeatures.TextBackColor = System.Drawing.Color.White;
            this.m_cboFacialFeatures.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtBirthBurl
            // 
            this.m_txtBirthBurl.AccessibleDescription = "入室记录>>头颅>>产瘤";
            this.m_txtBirthBurl.BackColor = System.Drawing.Color.White;
            this.m_txtBirthBurl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBirthBurl.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBirthBurl.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBirthBurl.Location = new System.Drawing.Point(120, 141);
            this.m_txtBirthBurl.m_BlnIgnoreUserInfo = false;
            this.m_txtBirthBurl.m_BlnPartControl = false;
            this.m_txtBirthBurl.m_BlnReadOnly = false;
            this.m_txtBirthBurl.m_BlnUnderLineDST = false;
            this.m_txtBirthBurl.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBirthBurl.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBirthBurl.m_IntCanModifyTime = 6;
            this.m_txtBirthBurl.m_IntPartControlLength = 0;
            this.m_txtBirthBurl.m_IntPartControlStartIndex = 0;
            this.m_txtBirthBurl.m_StrUserID = "";
            this.m_txtBirthBurl.m_StrUserName = "";
            this.m_txtBirthBurl.Multiline = false;
            this.m_txtBirthBurl.Name = "m_txtBirthBurl";
            this.m_txtBirthBurl.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBirthBurl.Size = new System.Drawing.Size(72, 24);
            this.m_txtBirthBurl.TabIndex = 10000086;
            this.m_txtBirthBurl.Tag = "8";
            this.m_txtBirthBurl.Text = "";
            // 
            // m_txtHaematoma
            // 
            this.m_txtHaematoma.AccessibleDescription = "入室记录>>头颅>>血肿";
            this.m_txtHaematoma.BackColor = System.Drawing.Color.White;
            this.m_txtHaematoma.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHaematoma.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtHaematoma.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHaematoma.Location = new System.Drawing.Point(256, 141);
            this.m_txtHaematoma.m_BlnIgnoreUserInfo = false;
            this.m_txtHaematoma.m_BlnPartControl = false;
            this.m_txtHaematoma.m_BlnReadOnly = false;
            this.m_txtHaematoma.m_BlnUnderLineDST = false;
            this.m_txtHaematoma.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHaematoma.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHaematoma.m_IntCanModifyTime = 6;
            this.m_txtHaematoma.m_IntPartControlLength = 0;
            this.m_txtHaematoma.m_IntPartControlStartIndex = 0;
            this.m_txtHaematoma.m_StrUserID = "";
            this.m_txtHaematoma.m_StrUserName = "";
            this.m_txtHaematoma.Multiline = false;
            this.m_txtHaematoma.Name = "m_txtHaematoma";
            this.m_txtHaematoma.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtHaematoma.Size = new System.Drawing.Size(72, 24);
            this.m_txtHaematoma.TabIndex = 10000086;
            this.m_txtHaematoma.Tag = "8";
            this.m_txtHaematoma.Text = "";
            // 
            // m_dtpCheckDate
            // 
            this.m_dtpCheckDate.AccessibleDescription = "入室记录>>检查日期";
            this.m_dtpCheckDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCheckDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCheckDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCheckDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCheckDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCheckDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCheckDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCheckDate.Location = new System.Drawing.Point(84, 434);
            this.m_dtpCheckDate.m_BlnOnlyTime = false;
            this.m_dtpCheckDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCheckDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCheckDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCheckDate.Name = "m_dtpCheckDate";
            this.m_dtpCheckDate.ReadOnly = false;
            this.m_dtpCheckDate.Size = new System.Drawing.Size(140, 22);
            this.m_dtpCheckDate.TabIndex = 10000098;
            this.m_dtpCheckDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCheckDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtOtherRecord
            // 
            this.m_txtOtherRecord.AccessibleDescription = "入室记录>>其它";
            this.m_txtOtherRecord.BackColor = System.Drawing.Color.White;
            this.m_txtOtherRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherRecord.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtOtherRecord.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOtherRecord.Location = new System.Drawing.Point(80, 368);
            this.m_txtOtherRecord.m_BlnIgnoreUserInfo = false;
            this.m_txtOtherRecord.m_BlnPartControl = false;
            this.m_txtOtherRecord.m_BlnReadOnly = false;
            this.m_txtOtherRecord.m_BlnUnderLineDST = false;
            this.m_txtOtherRecord.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOtherRecord.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOtherRecord.m_IntCanModifyTime = 6;
            this.m_txtOtherRecord.m_IntPartControlLength = 0;
            this.m_txtOtherRecord.m_IntPartControlStartIndex = 0;
            this.m_txtOtherRecord.m_StrUserID = "";
            this.m_txtOtherRecord.m_StrUserName = "";
            this.m_txtOtherRecord.Name = "m_txtOtherRecord";
            this.m_txtOtherRecord.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOtherRecord.Size = new System.Drawing.Size(696, 56);
            this.m_txtOtherRecord.TabIndex = 10000097;
            this.m_txtOtherRecord.Tag = "8";
            this.m_txtOtherRecord.Text = "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(8, 272);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(70, 14);
            this.label30.TabIndex = 10000094;
            this.label30.Text = "腹    部:";
            // 
            // m_cboVein
            // 
            this.m_cboVein.AccessibleDescription = "入室记录>>腹部>>静脉怒张";
            this.m_cboVein.BackColor = System.Drawing.Color.White;
            this.m_cboVein.BorderColor = System.Drawing.Color.Black;
            this.m_cboVein.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboVein.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboVein.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboVein.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboVein.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboVein.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboVein.ForeColor = System.Drawing.Color.Black;
            this.m_cboVein.ListBackColor = System.Drawing.Color.White;
            this.m_cboVein.ListForeColor = System.Drawing.Color.Black;
            this.m_cboVein.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboVein.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboVein.Location = new System.Drawing.Point(144, 270);
            this.m_cboVein.m_BlnEnableItemEventMenu = true;
            this.m_cboVein.MaxLength = 32767;
            this.m_cboVein.Name = "m_cboVein";
            this.m_cboVein.SelectedIndex = -1;
            this.m_cboVein.SelectedItem = null;
            this.m_cboVein.SelectionStart = 0;
            this.m_cboVein.Size = new System.Drawing.Size(152, 23);
            this.m_cboVein.TabIndex = 10000091;
            this.m_cboVein.TextBackColor = System.Drawing.Color.White;
            this.m_cboVein.TextForeColor = System.Drawing.Color.Black;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(80, 272);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 14);
            this.label31.TabIndex = 10000095;
            this.label31.Text = "静脉怒张";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(312, 272);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(21, 14);
            this.label32.TabIndex = 10000096;
            this.label32.Text = "肝";
            // 
            // m_cboLiver
            // 
            this.m_cboLiver.AccessibleDescription = "入室记录>>腹部>>肝";
            this.m_cboLiver.BackColor = System.Drawing.Color.White;
            this.m_cboLiver.BorderColor = System.Drawing.Color.Black;
            this.m_cboLiver.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLiver.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLiver.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLiver.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLiver.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLiver.ForeColor = System.Drawing.Color.Black;
            this.m_cboLiver.ListBackColor = System.Drawing.Color.White;
            this.m_cboLiver.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLiver.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLiver.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLiver.Location = new System.Drawing.Point(336, 270);
            this.m_cboLiver.m_BlnEnableItemEventMenu = true;
            this.m_cboLiver.MaxLength = 32767;
            this.m_cboLiver.Name = "m_cboLiver";
            this.m_cboLiver.SelectedIndex = -1;
            this.m_cboLiver.SelectedItem = null;
            this.m_cboLiver.SelectionStart = 0;
            this.m_cboLiver.Size = new System.Drawing.Size(120, 23);
            this.m_cboLiver.TabIndex = 10000088;
            this.m_cboLiver.TextBackColor = System.Drawing.Color.White;
            this.m_cboLiver.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboSpleen
            // 
            this.m_cboSpleen.AccessibleDescription = "入室记录>>腹部>>脾";
            this.m_cboSpleen.BackColor = System.Drawing.Color.White;
            this.m_cboSpleen.BorderColor = System.Drawing.Color.Black;
            this.m_cboSpleen.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboSpleen.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboSpleen.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboSpleen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboSpleen.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSpleen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSpleen.ForeColor = System.Drawing.Color.Black;
            this.m_cboSpleen.ListBackColor = System.Drawing.Color.White;
            this.m_cboSpleen.ListForeColor = System.Drawing.Color.Black;
            this.m_cboSpleen.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboSpleen.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboSpleen.Location = new System.Drawing.Point(488, 270);
            this.m_cboSpleen.m_BlnEnableItemEventMenu = true;
            this.m_cboSpleen.MaxLength = 32767;
            this.m_cboSpleen.Name = "m_cboSpleen";
            this.m_cboSpleen.SelectedIndex = -1;
            this.m_cboSpleen.SelectedItem = null;
            this.m_cboSpleen.SelectionStart = 0;
            this.m_cboSpleen.Size = new System.Drawing.Size(120, 23);
            this.m_cboSpleen.TabIndex = 10000089;
            this.m_cboSpleen.TextBackColor = System.Drawing.Color.White;
            this.m_cboSpleen.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboHilum
            // 
            this.m_cboHilum.AccessibleDescription = "入室记录>>腹部>>脐部";
            this.m_cboHilum.BackColor = System.Drawing.Color.White;
            this.m_cboHilum.BorderColor = System.Drawing.Color.Black;
            this.m_cboHilum.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHilum.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHilum.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHilum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHilum.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHilum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHilum.ForeColor = System.Drawing.Color.Black;
            this.m_cboHilum.ListBackColor = System.Drawing.Color.White;
            this.m_cboHilum.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHilum.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHilum.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHilum.Location = new System.Drawing.Point(656, 270);
            this.m_cboHilum.m_BlnEnableItemEventMenu = true;
            this.m_cboHilum.MaxLength = 32767;
            this.m_cboHilum.Name = "m_cboHilum";
            this.m_cboHilum.SelectedIndex = -1;
            this.m_cboHilum.SelectedItem = null;
            this.m_cboHilum.SelectionStart = 0;
            this.m_cboHilum.Size = new System.Drawing.Size(120, 23);
            this.m_cboHilum.TabIndex = 10000090;
            this.m_cboHilum.TextBackColor = System.Drawing.Color.White;
            this.m_cboHilum.TextForeColor = System.Drawing.Color.Black;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(464, 272);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(21, 14);
            this.label33.TabIndex = 10000092;
            this.label33.Text = "脾";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(616, 272);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(35, 14);
            this.label34.TabIndex = 10000093;
            this.label34.Text = "脐部";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_rdbFontanelOut);
            this.panel3.Controls.Add(this.m_rdbFontanelSatiation);
            this.panel3.Controls.Add(this.m_rdbFontanelLow);
            this.panel3.Controls.Add(this.m_rdbFontanelFlat);
            this.panel3.Location = new System.Drawing.Point(80, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 48);
            this.panel3.TabIndex = 10000087;
            // 
            // m_rdbFontanelOut
            // 
            this.m_rdbFontanelOut.AccessibleDescription = "入室记录>>前囟>>突出";
            this.m_rdbFontanelOut.Location = new System.Drawing.Point(0, 14);
            this.m_rdbFontanelOut.Name = "m_rdbFontanelOut";
            this.m_rdbFontanelOut.Size = new System.Drawing.Size(56, 24);
            this.m_rdbFontanelOut.TabIndex = 1;
            this.m_rdbFontanelOut.Text = "突、";
            // 
            // m_rdbFontanelSatiation
            // 
            this.m_rdbFontanelSatiation.AccessibleDescription = "入室记录>>前囟>>饱满";
            this.m_rdbFontanelSatiation.Location = new System.Drawing.Point(56, 14);
            this.m_rdbFontanelSatiation.Name = "m_rdbFontanelSatiation";
            this.m_rdbFontanelSatiation.Size = new System.Drawing.Size(72, 24);
            this.m_rdbFontanelSatiation.TabIndex = 1;
            this.m_rdbFontanelSatiation.Text = "饱满、";
            // 
            // m_rdbFontanelLow
            // 
            this.m_rdbFontanelLow.AccessibleDescription = "入室记录>>前囟>>低";
            this.m_rdbFontanelLow.Location = new System.Drawing.Point(128, 14);
            this.m_rdbFontanelLow.Name = "m_rdbFontanelLow";
            this.m_rdbFontanelLow.Size = new System.Drawing.Size(56, 24);
            this.m_rdbFontanelLow.TabIndex = 1;
            this.m_rdbFontanelLow.Text = "低、";
            // 
            // m_rdbFontanelFlat
            // 
            this.m_rdbFontanelFlat.AccessibleDescription = "入室记录>>前囟>>平";
            this.m_rdbFontanelFlat.Location = new System.Drawing.Point(184, 14);
            this.m_rdbFontanelFlat.Name = "m_rdbFontanelFlat";
            this.m_rdbFontanelFlat.Size = new System.Drawing.Size(56, 24);
            this.m_rdbFontanelFlat.TabIndex = 1;
            this.m_rdbFontanelFlat.Text = "平。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10000085;
            this.label5.Text = "一般情况:";
            // 
            // m_cboPregnantWeeks
            // 
            this.m_cboPregnantWeeks.AccessibleDescription = "入室记录>>孕周";
            this.m_cboPregnantWeeks.BackColor = System.Drawing.Color.White;
            this.m_cboPregnantWeeks.BorderColor = System.Drawing.Color.Black;
            this.m_cboPregnantWeeks.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPregnantWeeks.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPregnantWeeks.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPregnantWeeks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPregnantWeeks.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPregnantWeeks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPregnantWeeks.ForeColor = System.Drawing.Color.Black;
            this.m_cboPregnantWeeks.ListBackColor = System.Drawing.Color.White;
            this.m_cboPregnantWeeks.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPregnantWeeks.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPregnantWeeks.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPregnantWeeks.Location = new System.Drawing.Point(80, 46);
            this.m_cboPregnantWeeks.m_BlnEnableItemEventMenu = true;
            this.m_cboPregnantWeeks.MaxLength = 32767;
            this.m_cboPregnantWeeks.Name = "m_cboPregnantWeeks";
            this.m_cboPregnantWeeks.SelectedIndex = -1;
            this.m_cboPregnantWeeks.SelectedItem = null;
            this.m_cboPregnantWeeks.SelectionStart = 0;
            this.m_cboPregnantWeeks.Size = new System.Drawing.Size(88, 23);
            this.m_cboPregnantWeeks.TabIndex = 10000084;
            this.m_cboPregnantWeeks.TextBackColor = System.Drawing.Color.White;
            this.m_cboPregnantWeeks.TextForeColor = System.Drawing.Color.Black;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "孕    周:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_rdbBreechNature);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_rdbBreechHalf);
            this.panel2.Controls.Add(this.m_rdbBreechTow);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(448, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 32);
            this.panel2.TabIndex = 3;
            // 
            // m_rdbBreechNature
            // 
            this.m_rdbBreechNature.AccessibleDescription = "入室记录>>分娩方式>>臀位产>>自然";
            this.m_rdbBreechNature.Location = new System.Drawing.Point(16, 8);
            this.m_rdbBreechNature.Name = "m_rdbBreechNature";
            this.m_rdbBreechNature.Size = new System.Drawing.Size(72, 24);
            this.m_rdbBreechNature.TabIndex = 5;
            this.m_rdbBreechNature.Text = "自然、";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(248, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(-8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "（";
            // 
            // m_rdbBreechHalf
            // 
            this.m_rdbBreechHalf.AccessibleDescription = "入室记录>>分娩方式>>臀位产>>半臀牵引";
            this.m_rdbBreechHalf.Location = new System.Drawing.Point(88, 8);
            this.m_rdbBreechHalf.Name = "m_rdbBreechHalf";
            this.m_rdbBreechHalf.Size = new System.Drawing.Size(96, 24);
            this.m_rdbBreechHalf.TabIndex = 5;
            this.m_rdbBreechHalf.Text = "半臀牵引、";
            // 
            // m_rdbBreechTow
            // 
            this.m_rdbBreechTow.AccessibleDescription = "入室记录>>分娩方式>>臀位产>>臀牵引";
            this.m_rdbBreechTow.Location = new System.Drawing.Point(184, 8);
            this.m_rdbBreechTow.Name = "m_rdbBreechTow";
            this.m_rdbBreechTow.Size = new System.Drawing.Size(72, 24);
            this.m_rdbBreechTow.TabIndex = 5;
            this.m_rdbBreechTow.Text = "臀牵引";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_rdbSmoothBirth);
            this.panel1.Controls.Add(this.m_rdbClampBirth);
            this.panel1.Controls.Add(this.m_rdbSuctionBirth);
            this.panel1.Controls.Add(this.m_rdbCaesareanBirth);
            this.panel1.Controls.Add(this.m_rdbBreechDelivery);
            this.panel1.Location = new System.Drawing.Point(80, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 32);
            this.panel1.TabIndex = 1;
            // 
            // m_rdbSmoothBirth
            // 
            this.m_rdbSmoothBirth.AccessibleDescription = "入室记录>>分娩方式>>顺产";
            this.m_rdbSmoothBirth.Location = new System.Drawing.Point(0, 8);
            this.m_rdbSmoothBirth.Name = "m_rdbSmoothBirth";
            this.m_rdbSmoothBirth.Size = new System.Drawing.Size(72, 24);
            this.m_rdbSmoothBirth.TabIndex = 0;
            this.m_rdbSmoothBirth.Text = "顺产、";
            // 
            // m_rdbClampBirth
            // 
            this.m_rdbClampBirth.AccessibleDescription = "入室记录>>分娩方式>>钳产";
            this.m_rdbClampBirth.Location = new System.Drawing.Point(72, 8);
            this.m_rdbClampBirth.Name = "m_rdbClampBirth";
            this.m_rdbClampBirth.Size = new System.Drawing.Size(72, 24);
            this.m_rdbClampBirth.TabIndex = 0;
            this.m_rdbClampBirth.Text = "钳产、";
            // 
            // m_rdbSuctionBirth
            // 
            this.m_rdbSuctionBirth.AccessibleDescription = "入室记录>>分娩方式>>吸引产";
            this.m_rdbSuctionBirth.Location = new System.Drawing.Point(144, 8);
            this.m_rdbSuctionBirth.Name = "m_rdbSuctionBirth";
            this.m_rdbSuctionBirth.Size = new System.Drawing.Size(88, 24);
            this.m_rdbSuctionBirth.TabIndex = 0;
            this.m_rdbSuctionBirth.Text = "吸引产、";
            // 
            // m_rdbCaesareanBirth
            // 
            this.m_rdbCaesareanBirth.AccessibleDescription = "入室记录>>分娩方式>>剖宫";
            this.m_rdbCaesareanBirth.Location = new System.Drawing.Point(232, 8);
            this.m_rdbCaesareanBirth.Name = "m_rdbCaesareanBirth";
            this.m_rdbCaesareanBirth.Size = new System.Drawing.Size(72, 24);
            this.m_rdbCaesareanBirth.TabIndex = 0;
            this.m_rdbCaesareanBirth.Text = "剖宫、";
            // 
            // m_rdbBreechDelivery
            // 
            this.m_rdbBreechDelivery.AccessibleDescription = "入室记录>>分娩方式>>臀位产";
            this.m_rdbBreechDelivery.Location = new System.Drawing.Point(304, 8);
            this.m_rdbBreechDelivery.Name = "m_rdbBreechDelivery";
            this.m_rdbBreechDelivery.Size = new System.Drawing.Size(72, 24);
            this.m_rdbBreechDelivery.TabIndex = 0;
            this.m_rdbBreechDelivery.Text = "臀位产";
            this.m_rdbBreechDelivery.CheckedChanged += new System.EventHandler(this.m_rdbBreechDelivery_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "分娩方式：";
            // 
            // m_cboReaction
            // 
            this.m_cboReaction.AccessibleDescription = "入室记录>>一般情况>>反应";
            this.m_cboReaction.BackColor = System.Drawing.Color.White;
            this.m_cboReaction.BorderColor = System.Drawing.Color.Black;
            this.m_cboReaction.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboReaction.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboReaction.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboReaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboReaction.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboReaction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboReaction.ForeColor = System.Drawing.Color.Black;
            this.m_cboReaction.ListBackColor = System.Drawing.Color.White;
            this.m_cboReaction.ListForeColor = System.Drawing.Color.Black;
            this.m_cboReaction.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboReaction.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboReaction.Location = new System.Drawing.Point(120, 78);
            this.m_cboReaction.m_BlnEnableItemEventMenu = true;
            this.m_cboReaction.MaxLength = 32767;
            this.m_cboReaction.Name = "m_cboReaction";
            this.m_cboReaction.SelectedIndex = -1;
            this.m_cboReaction.SelectedItem = null;
            this.m_cboReaction.SelectionStart = 0;
            this.m_cboReaction.Size = new System.Drawing.Size(120, 23);
            this.m_cboReaction.TabIndex = 10000084;
            this.m_cboReaction.TextBackColor = System.Drawing.Color.White;
            this.m_cboReaction.TextForeColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 10000085;
            this.label6.Text = "反应";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 10000085;
            this.label7.Text = "肌张力";
            // 
            // m_cboMuscleStrain
            // 
            this.m_cboMuscleStrain.AccessibleDescription = "入室记录>>一般情况>>肌张力";
            this.m_cboMuscleStrain.BackColor = System.Drawing.Color.White;
            this.m_cboMuscleStrain.BorderColor = System.Drawing.Color.Black;
            this.m_cboMuscleStrain.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMuscleStrain.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboMuscleStrain.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMuscleStrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMuscleStrain.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMuscleStrain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMuscleStrain.ForeColor = System.Drawing.Color.Black;
            this.m_cboMuscleStrain.ListBackColor = System.Drawing.Color.White;
            this.m_cboMuscleStrain.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMuscleStrain.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMuscleStrain.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMuscleStrain.Location = new System.Drawing.Point(304, 78);
            this.m_cboMuscleStrain.m_BlnEnableItemEventMenu = true;
            this.m_cboMuscleStrain.MaxLength = 32767;
            this.m_cboMuscleStrain.Name = "m_cboMuscleStrain";
            this.m_cboMuscleStrain.SelectedIndex = -1;
            this.m_cboMuscleStrain.SelectedItem = null;
            this.m_cboMuscleStrain.SelectionStart = 0;
            this.m_cboMuscleStrain.Size = new System.Drawing.Size(120, 23);
            this.m_cboMuscleStrain.TabIndex = 10000084;
            this.m_cboMuscleStrain.TextBackColor = System.Drawing.Color.White;
            this.m_cboMuscleStrain.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboCryVoice
            // 
            this.m_cboCryVoice.AccessibleDescription = "入室记录>>一般情况>>哭声";
            this.m_cboCryVoice.BackColor = System.Drawing.Color.White;
            this.m_cboCryVoice.BorderColor = System.Drawing.Color.Black;
            this.m_cboCryVoice.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCryVoice.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCryVoice.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCryVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCryVoice.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCryVoice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCryVoice.ForeColor = System.Drawing.Color.Black;
            this.m_cboCryVoice.ListBackColor = System.Drawing.Color.White;
            this.m_cboCryVoice.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCryVoice.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCryVoice.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCryVoice.Location = new System.Drawing.Point(480, 78);
            this.m_cboCryVoice.m_BlnEnableItemEventMenu = true;
            this.m_cboCryVoice.MaxLength = 32767;
            this.m_cboCryVoice.Name = "m_cboCryVoice";
            this.m_cboCryVoice.SelectedIndex = -1;
            this.m_cboCryVoice.SelectedItem = null;
            this.m_cboCryVoice.SelectionStart = 0;
            this.m_cboCryVoice.Size = new System.Drawing.Size(120, 23);
            this.m_cboCryVoice.TabIndex = 10000084;
            this.m_cboCryVoice.TextBackColor = System.Drawing.Color.White;
            this.m_cboCryVoice.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboDropsy
            // 
            this.m_cboDropsy.AccessibleDescription = "入室记录>>一般情况>>水肿";
            this.m_cboDropsy.BackColor = System.Drawing.Color.White;
            this.m_cboDropsy.BorderColor = System.Drawing.Color.Black;
            this.m_cboDropsy.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDropsy.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDropsy.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDropsy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboDropsy.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDropsy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDropsy.ForeColor = System.Drawing.Color.Black;
            this.m_cboDropsy.ListBackColor = System.Drawing.Color.White;
            this.m_cboDropsy.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDropsy.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboDropsy.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDropsy.Location = new System.Drawing.Point(656, 78);
            this.m_cboDropsy.m_BlnEnableItemEventMenu = true;
            this.m_cboDropsy.MaxLength = 32767;
            this.m_cboDropsy.Name = "m_cboDropsy";
            this.m_cboDropsy.SelectedIndex = -1;
            this.m_cboDropsy.SelectedItem = null;
            this.m_cboDropsy.SelectionStart = 0;
            this.m_cboDropsy.Size = new System.Drawing.Size(120, 23);
            this.m_cboDropsy.TabIndex = 10000084;
            this.m_cboDropsy.TextBackColor = System.Drawing.Color.White;
            this.m_cboDropsy.TextForeColor = System.Drawing.Color.Black;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 10000085;
            this.label8.Text = "哭声";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(616, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 10000085;
            this.label9.Text = "水肿";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 10000085;
            this.label10.Text = "皮    肤:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(80, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 10000085;
            this.label11.Text = "色泽";
            // 
            // m_cboColor
            // 
            this.m_cboColor.AccessibleDescription = "入室记录>>皮肤>>色泽";
            this.m_cboColor.BackColor = System.Drawing.Color.White;
            this.m_cboColor.BorderColor = System.Drawing.Color.Black;
            this.m_cboColor.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboColor.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboColor.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboColor.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboColor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboColor.ForeColor = System.Drawing.Color.Black;
            this.m_cboColor.ListBackColor = System.Drawing.Color.White;
            this.m_cboColor.ListForeColor = System.Drawing.Color.Black;
            this.m_cboColor.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboColor.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboColor.Location = new System.Drawing.Point(120, 110);
            this.m_cboColor.m_BlnEnableItemEventMenu = true;
            this.m_cboColor.MaxLength = 32767;
            this.m_cboColor.Name = "m_cboColor";
            this.m_cboColor.SelectedIndex = -1;
            this.m_cboColor.SelectedItem = null;
            this.m_cboColor.SelectionStart = 0;
            this.m_cboColor.Size = new System.Drawing.Size(88, 23);
            this.m_cboColor.TabIndex = 10000084;
            this.m_cboColor.TextBackColor = System.Drawing.Color.White;
            this.m_cboColor.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboElasticity
            // 
            this.m_cboElasticity.AccessibleDescription = "入室记录>>皮肤>>弹性";
            this.m_cboElasticity.BackColor = System.Drawing.Color.White;
            this.m_cboElasticity.BorderColor = System.Drawing.Color.Black;
            this.m_cboElasticity.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboElasticity.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboElasticity.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboElasticity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboElasticity.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboElasticity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboElasticity.ForeColor = System.Drawing.Color.Black;
            this.m_cboElasticity.ListBackColor = System.Drawing.Color.White;
            this.m_cboElasticity.ListForeColor = System.Drawing.Color.Black;
            this.m_cboElasticity.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboElasticity.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboElasticity.Location = new System.Drawing.Point(256, 110);
            this.m_cboElasticity.m_BlnEnableItemEventMenu = true;
            this.m_cboElasticity.MaxLength = 32767;
            this.m_cboElasticity.Name = "m_cboElasticity";
            this.m_cboElasticity.SelectedIndex = -1;
            this.m_cboElasticity.SelectedItem = null;
            this.m_cboElasticity.SelectionStart = 0;
            this.m_cboElasticity.Size = new System.Drawing.Size(88, 23);
            this.m_cboElasticity.TabIndex = 10000084;
            this.m_cboElasticity.TextBackColor = System.Drawing.Color.White;
            this.m_cboElasticity.TextForeColor = System.Drawing.Color.Black;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(216, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 10000085;
            this.label12.Text = "弹性";
            // 
            // m_cboIcterus
            // 
            this.m_cboIcterus.AccessibleDescription = "入室记录>>皮肤>>胎脂黄染";
            this.m_cboIcterus.BackColor = System.Drawing.Color.White;
            this.m_cboIcterus.BorderColor = System.Drawing.Color.Black;
            this.m_cboIcterus.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboIcterus.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboIcterus.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboIcterus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboIcterus.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboIcterus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboIcterus.ForeColor = System.Drawing.Color.Black;
            this.m_cboIcterus.ListBackColor = System.Drawing.Color.White;
            this.m_cboIcterus.ListForeColor = System.Drawing.Color.Black;
            this.m_cboIcterus.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboIcterus.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboIcterus.Location = new System.Drawing.Point(424, 110);
            this.m_cboIcterus.m_BlnEnableItemEventMenu = true;
            this.m_cboIcterus.MaxLength = 32767;
            this.m_cboIcterus.Name = "m_cboIcterus";
            this.m_cboIcterus.SelectedIndex = -1;
            this.m_cboIcterus.SelectedItem = null;
            this.m_cboIcterus.SelectionStart = 0;
            this.m_cboIcterus.Size = new System.Drawing.Size(88, 23);
            this.m_cboIcterus.TabIndex = 10000084;
            this.m_cboIcterus.TextBackColor = System.Drawing.Color.White;
            this.m_cboIcterus.TextForeColor = System.Drawing.Color.Black;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(360, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 10000085;
            this.label13.Text = "胎脂黄染";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(512, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 10000085;
            this.label14.Text = "色素病";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(648, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 10000085;
            this.label15.Text = "瘀点";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 10000085;
            this.label16.Text = "头    颅:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(80, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 14);
            this.label17.TabIndex = 10000085;
            this.label17.Text = "产瘤";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(192, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 14);
            this.label18.TabIndex = 10000085;
            this.label18.Text = "cm，血肿";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(328, 144);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 14);
            this.label19.TabIndex = 10000085;
            this.label19.Text = "cm，颅骨软化";
            // 
            // m_cboSkullSoft
            // 
            this.m_cboSkullSoft.AccessibleDescription = "入室记录>>头颅>>颅骨软化";
            this.m_cboSkullSoft.BackColor = System.Drawing.Color.White;
            this.m_cboSkullSoft.BorderColor = System.Drawing.Color.Black;
            this.m_cboSkullSoft.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboSkullSoft.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboSkullSoft.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboSkullSoft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboSkullSoft.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSkullSoft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSkullSoft.ForeColor = System.Drawing.Color.Black;
            this.m_cboSkullSoft.ListBackColor = System.Drawing.Color.White;
            this.m_cboSkullSoft.ListForeColor = System.Drawing.Color.Black;
            this.m_cboSkullSoft.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboSkullSoft.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboSkullSoft.Location = new System.Drawing.Point(424, 142);
            this.m_cboSkullSoft.m_BlnEnableItemEventMenu = true;
            this.m_cboSkullSoft.MaxLength = 32767;
            this.m_cboSkullSoft.Name = "m_cboSkullSoft";
            this.m_cboSkullSoft.SelectedIndex = -1;
            this.m_cboSkullSoft.SelectedItem = null;
            this.m_cboSkullSoft.SelectionStart = 0;
            this.m_cboSkullSoft.Size = new System.Drawing.Size(88, 23);
            this.m_cboSkullSoft.TabIndex = 10000084;
            this.m_cboSkullSoft.TextBackColor = System.Drawing.Color.White;
            this.m_cboSkullSoft.TextForeColor = System.Drawing.Color.Black;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(520, 144);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 14);
            this.label20.TabIndex = 10000085;
            this.label20.Text = "骨缝";
            // 
            // m_cboBoneSew
            // 
            this.m_cboBoneSew.AccessibleDescription = "入室记录>>头颅>>骨缝";
            this.m_cboBoneSew.BackColor = System.Drawing.Color.White;
            this.m_cboBoneSew.BorderColor = System.Drawing.Color.Black;
            this.m_cboBoneSew.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBoneSew.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBoneSew.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBoneSew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBoneSew.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBoneSew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBoneSew.ForeColor = System.Drawing.Color.Black;
            this.m_cboBoneSew.ListBackColor = System.Drawing.Color.White;
            this.m_cboBoneSew.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBoneSew.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBoneSew.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBoneSew.Location = new System.Drawing.Point(560, 142);
            this.m_cboBoneSew.m_BlnEnableItemEventMenu = true;
            this.m_cboBoneSew.MaxLength = 32767;
            this.m_cboBoneSew.Name = "m_cboBoneSew";
            this.m_cboBoneSew.SelectedIndex = -1;
            this.m_cboBoneSew.SelectedItem = null;
            this.m_cboBoneSew.SelectionStart = 0;
            this.m_cboBoneSew.Size = new System.Drawing.Size(88, 23);
            this.m_cboBoneSew.TabIndex = 10000084;
            this.m_cboBoneSew.TextBackColor = System.Drawing.Color.White;
            this.m_cboBoneSew.TextForeColor = System.Drawing.Color.Black;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 176);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 14);
            this.label21.TabIndex = 10000085;
            this.label21.Text = "前    囟:";
            // 
            // m_txtHeadRound
            // 
            this.m_txtHeadRound.AccessibleDescription = "入室记录>>头围";
            this.m_txtHeadRound.BackColor = System.Drawing.Color.White;
            this.m_txtHeadRound.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHeadRound.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtHeadRound.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHeadRound.Location = new System.Drawing.Point(424, 173);
            this.m_txtHeadRound.m_BlnIgnoreUserInfo = false;
            this.m_txtHeadRound.m_BlnPartControl = false;
            this.m_txtHeadRound.m_BlnReadOnly = false;
            this.m_txtHeadRound.m_BlnUnderLineDST = false;
            this.m_txtHeadRound.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHeadRound.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHeadRound.m_IntCanModifyTime = 6;
            this.m_txtHeadRound.m_IntPartControlLength = 0;
            this.m_txtHeadRound.m_IntPartControlStartIndex = 0;
            this.m_txtHeadRound.m_StrUserID = "";
            this.m_txtHeadRound.m_StrUserName = "";
            this.m_txtHeadRound.Multiline = false;
            this.m_txtHeadRound.Name = "m_txtHeadRound";
            this.m_txtHeadRound.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtHeadRound.Size = new System.Drawing.Size(72, 24);
            this.m_txtHeadRound.TabIndex = 10000086;
            this.m_txtHeadRound.Tag = "8";
            this.m_txtHeadRound.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(496, 176);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 14);
            this.label22.TabIndex = 10000085;
            this.label22.Text = "cm";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(386, 176);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 14);
            this.label23.TabIndex = 10000085;
            this.label23.Text = "头围";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 208);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 14);
            this.label24.TabIndex = 4;
            this.label24.Text = "五    官:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(386, 208);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 14);
            this.label25.TabIndex = 10000085;
            this.label25.Text = "口腔";
            // 
            // m_cboMouth
            // 
            this.m_cboMouth.AccessibleDescription = "入室记录>>口腔";
            this.m_cboMouth.BackColor = System.Drawing.Color.White;
            this.m_cboMouth.BorderColor = System.Drawing.Color.Black;
            this.m_cboMouth.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMouth.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboMouth.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMouth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMouth.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMouth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMouth.ForeColor = System.Drawing.Color.Black;
            this.m_cboMouth.ListBackColor = System.Drawing.Color.White;
            this.m_cboMouth.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMouth.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMouth.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMouth.Location = new System.Drawing.Point(424, 206);
            this.m_cboMouth.m_BlnEnableItemEventMenu = true;
            this.m_cboMouth.MaxLength = 32767;
            this.m_cboMouth.Name = "m_cboMouth";
            this.m_cboMouth.SelectedIndex = -1;
            this.m_cboMouth.SelectedItem = null;
            this.m_cboMouth.SelectionStart = 0;
            this.m_cboMouth.Size = new System.Drawing.Size(352, 23);
            this.m_cboMouth.TabIndex = 10000084;
            this.m_cboMouth.TextBackColor = System.Drawing.Color.White;
            this.m_cboMouth.TextForeColor = System.Drawing.Color.Black;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 240);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 14);
            this.label26.TabIndex = 4;
            this.label26.Text = "胸    部:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(80, 240);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(21, 14);
            this.label27.TabIndex = 10000085;
            this.label27.Text = "心";
            // 
            // m_cboHeart
            // 
            this.m_cboHeart.AccessibleDescription = "入室记录>>胸部>>心";
            this.m_cboHeart.BackColor = System.Drawing.Color.White;
            this.m_cboHeart.BorderColor = System.Drawing.Color.Black;
            this.m_cboHeart.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHeart.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHeart.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHeart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHeart.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHeart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHeart.ForeColor = System.Drawing.Color.Black;
            this.m_cboHeart.ListBackColor = System.Drawing.Color.White;
            this.m_cboHeart.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHeart.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHeart.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHeart.Location = new System.Drawing.Point(104, 238);
            this.m_cboHeart.m_BlnEnableItemEventMenu = true;
            this.m_cboHeart.MaxLength = 32767;
            this.m_cboHeart.Name = "m_cboHeart";
            this.m_cboHeart.SelectedIndex = -1;
            this.m_cboHeart.SelectedItem = null;
            this.m_cboHeart.SelectionStart = 0;
            this.m_cboHeart.Size = new System.Drawing.Size(192, 23);
            this.m_cboHeart.TabIndex = 10000084;
            this.m_cboHeart.TextBackColor = System.Drawing.Color.White;
            this.m_cboHeart.TextForeColor = System.Drawing.Color.Black;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(312, 240);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 14);
            this.label28.TabIndex = 10000085;
            this.label28.Text = "肺";
            // 
            // m_cboLung
            // 
            this.m_cboLung.AccessibleDescription = "入室记录>>胸部>>肺";
            this.m_cboLung.BackColor = System.Drawing.Color.White;
            this.m_cboLung.BorderColor = System.Drawing.Color.Black;
            this.m_cboLung.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLung.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLung.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLung.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLung.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLung.ForeColor = System.Drawing.Color.Black;
            this.m_cboLung.ListBackColor = System.Drawing.Color.White;
            this.m_cboLung.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLung.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLung.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLung.Location = new System.Drawing.Point(336, 238);
            this.m_cboLung.m_BlnEnableItemEventMenu = true;
            this.m_cboLung.MaxLength = 32767;
            this.m_cboLung.Name = "m_cboLung";
            this.m_cboLung.SelectedIndex = -1;
            this.m_cboLung.SelectedItem = null;
            this.m_cboLung.SelectionStart = 0;
            this.m_cboLung.Size = new System.Drawing.Size(200, 23);
            this.m_cboLung.TabIndex = 10000084;
            this.m_cboLung.TextBackColor = System.Drawing.Color.White;
            this.m_cboLung.TextForeColor = System.Drawing.Color.Black;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(544, 240);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 14);
            this.label29.TabIndex = 10000085;
            this.label29.Text = "胸廓";
            // 
            // m_cboChest
            // 
            this.m_cboChest.AccessibleDescription = "入室记录>>胸部>>胸廓";
            this.m_cboChest.BackColor = System.Drawing.Color.White;
            this.m_cboChest.BorderColor = System.Drawing.Color.Black;
            this.m_cboChest.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboChest.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboChest.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboChest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboChest.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboChest.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboChest.ForeColor = System.Drawing.Color.Black;
            this.m_cboChest.ListBackColor = System.Drawing.Color.White;
            this.m_cboChest.ListForeColor = System.Drawing.Color.Black;
            this.m_cboChest.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboChest.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboChest.Location = new System.Drawing.Point(584, 238);
            this.m_cboChest.m_BlnEnableItemEventMenu = true;
            this.m_cboChest.MaxLength = 32767;
            this.m_cboChest.Name = "m_cboChest";
            this.m_cboChest.SelectedIndex = -1;
            this.m_cboChest.SelectedItem = null;
            this.m_cboChest.SelectionStart = 0;
            this.m_cboChest.Size = new System.Drawing.Size(192, 23);
            this.m_cboChest.TabIndex = 10000084;
            this.m_cboChest.TextBackColor = System.Drawing.Color.White;
            this.m_cboChest.TextForeColor = System.Drawing.Color.Black;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(80, 304);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(35, 14);
            this.label35.TabIndex = 10000085;
            this.label35.Text = "活动";
            // 
            // m_cboActivity
            // 
            this.m_cboActivity.AccessibleDescription = "入室记录>>四肢>>活动";
            this.m_cboActivity.BackColor = System.Drawing.Color.White;
            this.m_cboActivity.BorderColor = System.Drawing.Color.Black;
            this.m_cboActivity.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboActivity.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboActivity.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboActivity.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboActivity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboActivity.ForeColor = System.Drawing.Color.Black;
            this.m_cboActivity.ListBackColor = System.Drawing.Color.White;
            this.m_cboActivity.ListForeColor = System.Drawing.Color.Black;
            this.m_cboActivity.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboActivity.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboActivity.Location = new System.Drawing.Point(120, 302);
            this.m_cboActivity.m_BlnEnableItemEventMenu = true;
            this.m_cboActivity.MaxLength = 32767;
            this.m_cboActivity.Name = "m_cboActivity";
            this.m_cboActivity.SelectedIndex = -1;
            this.m_cboActivity.SelectedItem = null;
            this.m_cboActivity.SelectionStart = 0;
            this.m_cboActivity.Size = new System.Drawing.Size(192, 23);
            this.m_cboActivity.TabIndex = 10000084;
            this.m_cboActivity.TextBackColor = System.Drawing.Color.White;
            this.m_cboActivity.TextForeColor = System.Drawing.Color.Black;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(312, 304);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(35, 14);
            this.label36.TabIndex = 10000085;
            this.label36.Text = "关节";
            // 
            // m_cboArthrosis
            // 
            this.m_cboArthrosis.AccessibleDescription = "入室记录>>四肢>>关节";
            this.m_cboArthrosis.BackColor = System.Drawing.Color.White;
            this.m_cboArthrosis.BorderColor = System.Drawing.Color.Black;
            this.m_cboArthrosis.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboArthrosis.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboArthrosis.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboArthrosis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboArthrosis.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboArthrosis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboArthrosis.ForeColor = System.Drawing.Color.Black;
            this.m_cboArthrosis.ListBackColor = System.Drawing.Color.White;
            this.m_cboArthrosis.ListForeColor = System.Drawing.Color.Black;
            this.m_cboArthrosis.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboArthrosis.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboArthrosis.Location = new System.Drawing.Point(352, 302);
            this.m_cboArthrosis.m_BlnEnableItemEventMenu = true;
            this.m_cboArthrosis.MaxLength = 32767;
            this.m_cboArthrosis.Name = "m_cboArthrosis";
            this.m_cboArthrosis.SelectedIndex = -1;
            this.m_cboArthrosis.SelectedItem = null;
            this.m_cboArthrosis.SelectionStart = 0;
            this.m_cboArthrosis.Size = new System.Drawing.Size(184, 23);
            this.m_cboArthrosis.TabIndex = 10000084;
            this.m_cboArthrosis.TextBackColor = System.Drawing.Color.White;
            this.m_cboArthrosis.TextForeColor = System.Drawing.Color.Black;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(544, 304);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(35, 14);
            this.label37.TabIndex = 10000085;
            this.label37.Text = "畸形";
            // 
            // m_cboAbnormality
            // 
            this.m_cboAbnormality.AccessibleDescription = "入室记录>>四肢>>畸形";
            this.m_cboAbnormality.BackColor = System.Drawing.Color.White;
            this.m_cboAbnormality.BorderColor = System.Drawing.Color.Black;
            this.m_cboAbnormality.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAbnormality.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboAbnormality.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAbnormality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAbnormality.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAbnormality.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAbnormality.ForeColor = System.Drawing.Color.Black;
            this.m_cboAbnormality.ListBackColor = System.Drawing.Color.White;
            this.m_cboAbnormality.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAbnormality.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboAbnormality.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboAbnormality.Location = new System.Drawing.Point(584, 302);
            this.m_cboAbnormality.m_BlnEnableItemEventMenu = true;
            this.m_cboAbnormality.MaxLength = 32767;
            this.m_cboAbnormality.Name = "m_cboAbnormality";
            this.m_cboAbnormality.SelectedIndex = -1;
            this.m_cboAbnormality.SelectedItem = null;
            this.m_cboAbnormality.SelectionStart = 0;
            this.m_cboAbnormality.Size = new System.Drawing.Size(192, 23);
            this.m_cboAbnormality.TabIndex = 10000084;
            this.m_cboAbnormality.TextBackColor = System.Drawing.Color.White;
            this.m_cboAbnormality.TextForeColor = System.Drawing.Color.Black;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(8, 304);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(70, 14);
            this.label38.TabIndex = 4;
            this.label38.Text = "四    肢:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(8, 336);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(70, 14);
            this.label39.TabIndex = 4;
            this.label39.Text = "外生殖器:";
            // 
            // m_cboGenitalia
            // 
            this.m_cboGenitalia.AccessibleDescription = "入室记录>>外生殖器";
            this.m_cboGenitalia.BackColor = System.Drawing.Color.White;
            this.m_cboGenitalia.BorderColor = System.Drawing.Color.Black;
            this.m_cboGenitalia.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboGenitalia.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboGenitalia.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboGenitalia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboGenitalia.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGenitalia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGenitalia.ForeColor = System.Drawing.Color.Black;
            this.m_cboGenitalia.ListBackColor = System.Drawing.Color.White;
            this.m_cboGenitalia.ListForeColor = System.Drawing.Color.Black;
            this.m_cboGenitalia.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboGenitalia.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboGenitalia.Location = new System.Drawing.Point(80, 334);
            this.m_cboGenitalia.m_BlnEnableItemEventMenu = true;
            this.m_cboGenitalia.MaxLength = 32767;
            this.m_cboGenitalia.Name = "m_cboGenitalia";
            this.m_cboGenitalia.SelectedIndex = -1;
            this.m_cboGenitalia.SelectedItem = null;
            this.m_cboGenitalia.SelectionStart = 0;
            this.m_cboGenitalia.Size = new System.Drawing.Size(696, 23);
            this.m_cboGenitalia.TabIndex = 10000084;
            this.m_cboGenitalia.TextBackColor = System.Drawing.Color.White;
            this.m_cboGenitalia.TextForeColor = System.Drawing.Color.Black;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(12, 436);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(70, 14);
            this.label40.TabIndex = 4;
            this.label40.Text = "检查日期:";
            // 
            // m_cboPigment
            // 
            this.m_cboPigment.AccessibleDescription = "入室记录>>皮肤>>色素病";
            this.m_cboPigment.BackColor = System.Drawing.Color.White;
            this.m_cboPigment.BorderColor = System.Drawing.Color.Black;
            this.m_cboPigment.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPigment.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPigment.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPigment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPigment.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPigment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPigment.ForeColor = System.Drawing.Color.Black;
            this.m_cboPigment.ListBackColor = System.Drawing.Color.White;
            this.m_cboPigment.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPigment.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPigment.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPigment.Location = new System.Drawing.Point(560, 110);
            this.m_cboPigment.m_BlnEnableItemEventMenu = true;
            this.m_cboPigment.MaxLength = 32767;
            this.m_cboPigment.Name = "m_cboPigment";
            this.m_cboPigment.SelectedIndex = -1;
            this.m_cboPigment.SelectedItem = null;
            this.m_cboPigment.SelectionStart = 0;
            this.m_cboPigment.Size = new System.Drawing.Size(88, 23);
            this.m_cboPigment.TabIndex = 10000084;
            this.m_cboPigment.TextBackColor = System.Drawing.Color.White;
            this.m_cboPigment.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPetechia
            // 
            this.m_cboPetechia.AccessibleDescription = "入室记录>>皮肤>>瘀点";
            this.m_cboPetechia.BackColor = System.Drawing.Color.White;
            this.m_cboPetechia.BorderColor = System.Drawing.Color.Black;
            this.m_cboPetechia.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPetechia.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPetechia.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPetechia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPetechia.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPetechia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPetechia.ForeColor = System.Drawing.Color.Black;
            this.m_cboPetechia.ListBackColor = System.Drawing.Color.White;
            this.m_cboPetechia.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPetechia.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPetechia.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPetechia.Location = new System.Drawing.Point(688, 110);
            this.m_cboPetechia.m_BlnEnableItemEventMenu = true;
            this.m_cboPetechia.MaxLength = 32767;
            this.m_cboPetechia.Name = "m_cboPetechia";
            this.m_cboPetechia.SelectedIndex = -1;
            this.m_cboPetechia.SelectedItem = null;
            this.m_cboPetechia.SelectionStart = 0;
            this.m_cboPetechia.Size = new System.Drawing.Size(88, 23);
            this.m_cboPetechia.TabIndex = 10000084;
            this.m_cboPetechia.TextBackColor = System.Drawing.Color.White;
            this.m_cboPetechia.TextForeColor = System.Drawing.Color.Black;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(8, 368);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(70, 14);
            this.label41.TabIndex = 4;
            this.label41.Text = "其    它:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_dtgRecord);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(784, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "情况记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // m_dtgRecord
            // 
            this.m_dtgRecord.AccessibleName = "DataGrid";
            this.m_dtgRecord.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.m_dtgRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dtgRecord.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtgRecord.CaptionText = "情况记录";
            this.m_dtgRecord.CaptionVisible = false;
            this.m_dtgRecord.DataMember = "";
            this.m_dtgRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgRecord.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecord.HeaderFont = new System.Drawing.Font("宋体", 40F);
            this.m_dtgRecord.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecord.Location = new System.Drawing.Point(8, 8);
            this.m_dtgRecord.Name = "m_dtgRecord";
            this.m_dtgRecord.ParentRowsForeColor = System.Drawing.Color.White;
            this.m_dtgRecord.PreferredRowHeight = 200;
            this.m_dtgRecord.RowHeaderWidth = 70;
            this.m_dtgRecord.Size = new System.Drawing.Size(768, 456);
            this.m_dtgRecord.TabIndex = 0;
            this.m_dtgRecord.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.m_dtgRecord;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.m_clmRecordDate,
            this.m_clmBirthDays,
            this.m_dtcBirthBurl,
            this.m_dtcHaematoma,
            this.m_dtcFontanel,
            this.m_dtcConjunctiva,
            this.m_dtcSecretion,
            this.m_dtcPharynx,
            this.m_dtcWhitePoint,
            this.m_dtcIcterus,
            this.m_dtcFester,
            this.m_dtcBleeding,
            this.m_dtcAgnail,
            this.m_dtcRedStern,
            this.m_dtcSternSkin,
            this.m_dtcHeartLung,
            this.m_dtcAbdomen,
            this.m_dtcRemark,
            this.m_clmSign});
            this.dataGridTableStyle1.HeaderFont = new System.Drawing.Font("宋体", 10.5F);
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "RecordDetail";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeadersVisible = false;
            this.dataGridTableStyle1.RowHeaderWidth = 70;
            // 
            // m_clmRecordDate
            // 
            this.m_clmRecordDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_clmRecordDate.Format = "";
            this.m_clmRecordDate.FormatInfo = null;
            this.m_clmRecordDate.MappingName = "RecordDate";
            this.m_clmRecordDate.Width = 130;
            // 
            // m_clmBirthDays
            // 
            this.m_clmBirthDays.Format = "";
            this.m_clmBirthDays.FormatInfo = null;
            this.m_clmBirthDays.MappingName = "BirthDays";
            this.m_clmBirthDays.Width = 70;
            // 
            // m_dtcBirthBurl
            // 
            this.m_dtcBirthBurl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBirthBurl.m_BlnGobleSet = true;
            this.m_dtcBirthBurl.m_BlnUnderLineDST = false;
            this.m_dtcBirthBurl.MappingName = "BirthBurl";
            this.m_dtcBirthBurl.Width = 90;
            // 
            // m_dtcHaematoma
            // 
            this.m_dtcHaematoma.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHaematoma.m_BlnGobleSet = true;
            this.m_dtcHaematoma.m_BlnUnderLineDST = false;
            this.m_dtcHaematoma.MappingName = "Haematoma";
            this.m_dtcHaematoma.Width = 90;
            // 
            // m_dtcFontanel
            // 
            this.m_dtcFontanel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFontanel.m_BlnGobleSet = true;
            this.m_dtcFontanel.m_BlnUnderLineDST = false;
            this.m_dtcFontanel.MappingName = "Fontanel";
            this.m_dtcFontanel.Width = 80;
            // 
            // m_dtcConjunctiva
            // 
            this.m_dtcConjunctiva.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcConjunctiva.m_BlnGobleSet = true;
            this.m_dtcConjunctiva.m_BlnUnderLineDST = false;
            this.m_dtcConjunctiva.MappingName = "Conjunctiva";
            this.m_dtcConjunctiva.Width = 90;
            // 
            // m_dtcSecretion
            // 
            this.m_dtcSecretion.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSecretion.m_BlnGobleSet = true;
            this.m_dtcSecretion.m_BlnUnderLineDST = false;
            this.m_dtcSecretion.MappingName = "Secretion";
            this.m_dtcSecretion.Width = 90;
            // 
            // m_dtcPharynx
            // 
            this.m_dtcPharynx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPharynx.m_BlnGobleSet = true;
            this.m_dtcPharynx.m_BlnUnderLineDST = false;
            this.m_dtcPharynx.MappingName = "Pharynx";
            this.m_dtcPharynx.Width = 90;
            // 
            // m_dtcWhitePoint
            // 
            this.m_dtcWhitePoint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcWhitePoint.m_BlnGobleSet = true;
            this.m_dtcWhitePoint.m_BlnUnderLineDST = false;
            this.m_dtcWhitePoint.MappingName = "WhitePoint";
            this.m_dtcWhitePoint.Width = 90;
            // 
            // m_dtcIcterus
            // 
            this.m_dtcIcterus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcIcterus.m_BlnGobleSet = true;
            this.m_dtcIcterus.m_BlnUnderLineDST = false;
            this.m_dtcIcterus.MappingName = "Icterus";
            this.m_dtcIcterus.Width = 90;
            // 
            // m_dtcFester
            // 
            this.m_dtcFester.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFester.m_BlnGobleSet = true;
            this.m_dtcFester.m_BlnUnderLineDST = false;
            this.m_dtcFester.MappingName = "Fester";
            this.m_dtcFester.Width = 90;
            // 
            // m_dtcBleeding
            // 
            this.m_dtcBleeding.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBleeding.m_BlnGobleSet = true;
            this.m_dtcBleeding.m_BlnUnderLineDST = false;
            this.m_dtcBleeding.MappingName = "Bleeding";
            this.m_dtcBleeding.Width = 90;
            // 
            // m_dtcAgnail
            // 
            this.m_dtcAgnail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcAgnail.m_BlnGobleSet = true;
            this.m_dtcAgnail.m_BlnUnderLineDST = false;
            this.m_dtcAgnail.MappingName = "Agnail";
            this.m_dtcAgnail.Width = 90;
            // 
            // m_dtcRedStern
            // 
            this.m_dtcRedStern.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRedStern.m_BlnGobleSet = true;
            this.m_dtcRedStern.m_BlnUnderLineDST = false;
            this.m_dtcRedStern.MappingName = "RedStern";
            this.m_dtcRedStern.Width = 90;
            // 
            // m_dtcSternSkin
            // 
            this.m_dtcSternSkin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSternSkin.m_BlnGobleSet = true;
            this.m_dtcSternSkin.m_BlnUnderLineDST = false;
            this.m_dtcSternSkin.MappingName = "SternSkin";
            this.m_dtcSternSkin.Width = 90;
            // 
            // m_dtcHeartLung
            // 
            this.m_dtcHeartLung.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHeartLung.m_BlnGobleSet = true;
            this.m_dtcHeartLung.m_BlnUnderLineDST = false;
            this.m_dtcHeartLung.MappingName = "HeartLung";
            this.m_dtcHeartLung.Width = 90;
            // 
            // m_dtcAbdomen
            // 
            this.m_dtcAbdomen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcAbdomen.m_BlnGobleSet = true;
            this.m_dtcAbdomen.m_BlnUnderLineDST = false;
            this.m_dtcAbdomen.MappingName = "Abdomen";
            this.m_dtcAbdomen.Width = 90;
            // 
            // m_dtcRemark
            // 
            this.m_dtcRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRemark.m_BlnGobleSet = true;
            this.m_dtcRemark.m_BlnUnderLineDST = false;
            this.m_dtcRemark.MappingName = "Remark";
            this.m_dtcRemark.Width = 120;
            // 
            // m_clmSign
            // 
            this.m_clmSign.Format = "";
            this.m_clmSign.FormatInfo = null;
            this.m_clmSign.MappingName = "Sign";
            this.m_clmSign.Width = 80;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_lblOutHospitalDays);
            this.tabPage3.Controls.Add(this.m_lblOutHospitalDate);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.m_lsvAssistant2);
            this.tabPage3.Controls.Add(this.m_cmdHelp2);
            this.tabPage3.Controls.Add(this.m_txtOutHospitalAdvice);
            this.tabPage3.Controls.Add(this.m_txtDealWith);
            this.tabPage3.Controls.Add(this.m_txtOtherCheck);
            this.tabPage3.Controls.Add(this.m_cboSkin);
            this.tabPage3.Controls.Add(this.m_cboGenitalia_OutHospital);
            this.tabPage3.Controls.Add(this.m_cboButtocks);
            this.tabPage3.Controls.Add(this.m_cboNormalCircs);
            this.tabPage3.Controls.Add(this.m_cboLactation);
            this.tabPage3.Controls.Add(this.m_cboBLiverBacterin);
            this.tabPage3.Controls.Add(this.m_cboBcgVaccine);
            this.tabPage3.Controls.Add(this.m_cboLimb);
            this.tabPage3.Controls.Add(this.m_txtWeight);
            this.tabPage3.Controls.Add(this.m_cboHeart_OutHospital);
            this.tabPage3.Controls.Add(this.m_cboHead);
            this.tabPage3.Controls.Add(this.label43);
            this.tabPage3.Controls.Add(this.label42);
            this.tabPage3.Controls.Add(this.label44);
            this.tabPage3.Controls.Add(this.label45);
            this.tabPage3.Controls.Add(this.label46);
            this.tabPage3.Controls.Add(this.label47);
            this.tabPage3.Controls.Add(this.label48);
            this.tabPage3.Controls.Add(this.m_dtpUmbilicalCordLeftTime);
            this.tabPage3.Controls.Add(this.m_cboLung_OutHospital);
            this.tabPage3.Controls.Add(this.label49);
            this.tabPage3.Controls.Add(this.label50);
            this.tabPage3.Controls.Add(this.m_cboAbdomen);
            this.tabPage3.Controls.Add(this.label51);
            this.tabPage3.Controls.Add(this.label52);
            this.tabPage3.Controls.Add(this.label53);
            this.tabPage3.Controls.Add(this.label54);
            this.tabPage3.Controls.Add(this.label55);
            this.tabPage3.Controls.Add(this.label56);
            this.tabPage3.Controls.Add(this.label57);
            this.tabPage3.Controls.Add(this.label58);
            this.tabPage3.Controls.Add(this.label59);
            this.tabPage3.Controls.Add(this.label60);
            this.tabPage3.Controls.Add(this.label61);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(784, 469);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "检查";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // m_lblOutHospitalDate
            // 
            this.m_lblOutHospitalDate.AccessibleDescription = "出院检查>>住院日期";
            this.m_lblOutHospitalDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_lblOutHospitalDate.Location = new System.Drawing.Point(82, 43);
            this.m_lblOutHospitalDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_lblOutHospitalDate.Mask = "0000年90月90日";
            this.m_lblOutHospitalDate.Name = "m_lblOutHospitalDate";
            this.m_lblOutHospitalDate.Size = new System.Drawing.Size(138, 23);
            this.m_lblOutHospitalDate.TabIndex = 10000548;
            this.m_lblOutHospitalDate.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdbChangeDeptC);
            this.groupBox1.Controls.Add(this.m_rdbOutHospitalC);
            this.groupBox1.Location = new System.Drawing.Point(197, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 30);
            this.groupBox1.TabIndex = 10000461;
            this.groupBox1.TabStop = false;
            // 
            // m_rdbChangeDeptC
            // 
            this.m_rdbChangeDeptC.AccessibleDescription = "转科检查";
            this.m_rdbChangeDeptC.AutoSize = true;
            this.m_rdbChangeDeptC.Location = new System.Drawing.Point(184, 10);
            this.m_rdbChangeDeptC.Name = "m_rdbChangeDeptC";
            this.m_rdbChangeDeptC.Size = new System.Drawing.Size(81, 18);
            this.m_rdbChangeDeptC.TabIndex = 1;
            this.m_rdbChangeDeptC.TabStop = true;
            this.m_rdbChangeDeptC.Text = "转科检查";
            this.m_rdbChangeDeptC.UseVisualStyleBackColor = true;
            this.m_rdbChangeDeptC.CheckedChanged += new System.EventHandler(this.m_rdbChangeDeptC_CheckedChanged);
            // 
            // m_rdbOutHospitalC
            // 
            this.m_rdbOutHospitalC.AccessibleDescription = "出院检查";
            this.m_rdbOutHospitalC.AutoSize = true;
            this.m_rdbOutHospitalC.Location = new System.Drawing.Point(16, 10);
            this.m_rdbOutHospitalC.Name = "m_rdbOutHospitalC";
            this.m_rdbOutHospitalC.Size = new System.Drawing.Size(81, 18);
            this.m_rdbOutHospitalC.TabIndex = 0;
            this.m_rdbOutHospitalC.TabStop = true;
            this.m_rdbOutHospitalC.Text = "出院检查";
            this.m_rdbOutHospitalC.UseVisualStyleBackColor = true;
            this.m_rdbOutHospitalC.CheckedChanged += new System.EventHandler(this.m_rdbOutHospitalC_CheckedChanged);
            // 
            // m_lsvAssistant2
            // 
            this.m_lsvAssistant2.AccessibleDescription = "出院检查>>医生签名(txt)";
            this.m_lsvAssistant2.BackColor = System.Drawing.Color.White;
            this.m_lsvAssistant2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.m_lsvAssistant2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvAssistant2.ForeColor = System.Drawing.Color.Black;
            this.m_lsvAssistant2.FullRowSelect = true;
            this.m_lsvAssistant2.GridLines = true;
            this.m_lsvAssistant2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvAssistant2.Location = new System.Drawing.Point(174, 428);
            this.m_lsvAssistant2.Name = "m_lsvAssistant2";
            this.m_lsvAssistant2.Size = new System.Drawing.Size(496, 28);
            this.m_lsvAssistant2.TabIndex = 10000460;
            this.m_lsvAssistant2.UseCompatibleStateImageBehavior = false;
            this.m_lsvAssistant2.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 55;
            // 
            // m_cmdHelp2
            // 
            this.m_cmdHelp2.AccessibleDescription = "出院检查>>医生签名(cmd)";
            this.m_cmdHelp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdHelp2.DefaultScheme = true;
            this.m_cmdHelp2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdHelp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdHelp2.Hint = "";
            this.m_cmdHelp2.Location = new System.Drawing.Point(80, 428);
            this.m_cmdHelp2.Name = "m_cmdHelp2";
            this.m_cmdHelp2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdHelp2.Size = new System.Drawing.Size(88, 28);
            this.m_cmdHelp2.TabIndex = 10000459;
            this.m_cmdHelp2.Tag = "1";
            this.m_cmdHelp2.Text = "医生签名:";
            // 
            // m_txtOutHospitalAdvice
            // 
            this.m_txtOutHospitalAdvice.AccessibleDescription = "出院检查>>出院医嘱";
            this.m_txtOutHospitalAdvice.BackColor = System.Drawing.Color.White;
            this.m_txtOutHospitalAdvice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutHospitalAdvice.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtOutHospitalAdvice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutHospitalAdvice.Location = new System.Drawing.Point(80, 319);
            this.m_txtOutHospitalAdvice.m_BlnIgnoreUserInfo = false;
            this.m_txtOutHospitalAdvice.m_BlnPartControl = false;
            this.m_txtOutHospitalAdvice.m_BlnReadOnly = false;
            this.m_txtOutHospitalAdvice.m_BlnUnderLineDST = false;
            this.m_txtOutHospitalAdvice.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutHospitalAdvice.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutHospitalAdvice.m_IntCanModifyTime = 6;
            this.m_txtOutHospitalAdvice.m_IntPartControlLength = 0;
            this.m_txtOutHospitalAdvice.m_IntPartControlStartIndex = 0;
            this.m_txtOutHospitalAdvice.m_StrUserID = "";
            this.m_txtOutHospitalAdvice.m_StrUserName = "";
            this.m_txtOutHospitalAdvice.Name = "m_txtOutHospitalAdvice";
            this.m_txtOutHospitalAdvice.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOutHospitalAdvice.Size = new System.Drawing.Size(696, 40);
            this.m_txtOutHospitalAdvice.TabIndex = 10000102;
            this.m_txtOutHospitalAdvice.Tag = "8";
            this.m_txtOutHospitalAdvice.Text = "";
            // 
            // m_txtDealWith
            // 
            this.m_txtDealWith.AccessibleDescription = "出院检查>>处理";
            this.m_txtDealWith.BackColor = System.Drawing.Color.White;
            this.m_txtDealWith.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDealWith.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtDealWith.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDealWith.Location = new System.Drawing.Point(80, 374);
            this.m_txtDealWith.m_BlnIgnoreUserInfo = false;
            this.m_txtDealWith.m_BlnPartControl = false;
            this.m_txtDealWith.m_BlnReadOnly = false;
            this.m_txtDealWith.m_BlnUnderLineDST = false;
            this.m_txtDealWith.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDealWith.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDealWith.m_IntCanModifyTime = 6;
            this.m_txtDealWith.m_IntPartControlLength = 0;
            this.m_txtDealWith.m_IntPartControlStartIndex = 0;
            this.m_txtDealWith.m_StrUserID = "";
            this.m_txtDealWith.m_StrUserName = "";
            this.m_txtDealWith.Name = "m_txtDealWith";
            this.m_txtDealWith.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDealWith.Size = new System.Drawing.Size(696, 40);
            this.m_txtDealWith.TabIndex = 10000102;
            this.m_txtDealWith.Tag = "8";
            this.m_txtDealWith.Text = "";
            // 
            // m_txtOtherCheck
            // 
            this.m_txtOtherCheck.AccessibleDescription = "出院检查>>其他";
            this.m_txtOtherCheck.BackColor = System.Drawing.Color.White;
            this.m_txtOtherCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherCheck.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtOtherCheck.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOtherCheck.Location = new System.Drawing.Point(80, 262);
            this.m_txtOtherCheck.m_BlnIgnoreUserInfo = false;
            this.m_txtOtherCheck.m_BlnPartControl = false;
            this.m_txtOtherCheck.m_BlnReadOnly = false;
            this.m_txtOtherCheck.m_BlnUnderLineDST = false;
            this.m_txtOtherCheck.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOtherCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOtherCheck.m_IntCanModifyTime = 6;
            this.m_txtOtherCheck.m_IntPartControlLength = 0;
            this.m_txtOtherCheck.m_IntPartControlStartIndex = 0;
            this.m_txtOtherCheck.m_StrUserID = "";
            this.m_txtOtherCheck.m_StrUserName = "";
            this.m_txtOtherCheck.Name = "m_txtOtherCheck";
            this.m_txtOtherCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOtherCheck.Size = new System.Drawing.Size(696, 40);
            this.m_txtOtherCheck.TabIndex = 10000102;
            this.m_txtOtherCheck.Tag = "8";
            this.m_txtOtherCheck.Text = "";
            // 
            // m_cboSkin
            // 
            this.m_cboSkin.AccessibleDescription = "出院检查>>皮肤";
            this.m_cboSkin.BackColor = System.Drawing.Color.White;
            this.m_cboSkin.BorderColor = System.Drawing.Color.Black;
            this.m_cboSkin.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboSkin.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboSkin.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboSkin.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSkin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSkin.ForeColor = System.Drawing.Color.Black;
            this.m_cboSkin.ListBackColor = System.Drawing.Color.White;
            this.m_cboSkin.ListForeColor = System.Drawing.Color.Black;
            this.m_cboSkin.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboSkin.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboSkin.Location = new System.Drawing.Point(592, 76);
            this.m_cboSkin.m_BlnEnableItemEventMenu = true;
            this.m_cboSkin.MaxLength = 32767;
            this.m_cboSkin.Name = "m_cboSkin";
            this.m_cboSkin.SelectedIndex = -1;
            this.m_cboSkin.SelectedItem = null;
            this.m_cboSkin.SelectionStart = 0;
            this.m_cboSkin.Size = new System.Drawing.Size(184, 23);
            this.m_cboSkin.TabIndex = 10000101;
            this.m_cboSkin.TextBackColor = System.Drawing.Color.White;
            this.m_cboSkin.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboGenitalia_OutHospital
            // 
            this.m_cboGenitalia_OutHospital.AccessibleDescription = "出院检查>>生殖器";
            this.m_cboGenitalia_OutHospital.BackColor = System.Drawing.Color.White;
            this.m_cboGenitalia_OutHospital.BorderColor = System.Drawing.Color.Black;
            this.m_cboGenitalia_OutHospital.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboGenitalia_OutHospital.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboGenitalia_OutHospital.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboGenitalia_OutHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboGenitalia_OutHospital.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGenitalia_OutHospital.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGenitalia_OutHospital.ForeColor = System.Drawing.Color.Black;
            this.m_cboGenitalia_OutHospital.ListBackColor = System.Drawing.Color.White;
            this.m_cboGenitalia_OutHospital.ListForeColor = System.Drawing.Color.Black;
            this.m_cboGenitalia_OutHospital.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboGenitalia_OutHospital.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboGenitalia_OutHospital.Location = new System.Drawing.Point(592, 111);
            this.m_cboGenitalia_OutHospital.m_BlnEnableItemEventMenu = true;
            this.m_cboGenitalia_OutHospital.MaxLength = 32767;
            this.m_cboGenitalia_OutHospital.Name = "m_cboGenitalia_OutHospital";
            this.m_cboGenitalia_OutHospital.SelectedIndex = -1;
            this.m_cboGenitalia_OutHospital.SelectedItem = null;
            this.m_cboGenitalia_OutHospital.SelectionStart = 0;
            this.m_cboGenitalia_OutHospital.Size = new System.Drawing.Size(184, 23);
            this.m_cboGenitalia_OutHospital.TabIndex = 10000101;
            this.m_cboGenitalia_OutHospital.TextBackColor = System.Drawing.Color.White;
            this.m_cboGenitalia_OutHospital.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboButtocks
            // 
            this.m_cboButtocks.AccessibleDescription = "出院检查>>臀部";
            this.m_cboButtocks.BackColor = System.Drawing.Color.White;
            this.m_cboButtocks.BorderColor = System.Drawing.Color.Black;
            this.m_cboButtocks.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboButtocks.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboButtocks.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboButtocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboButtocks.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboButtocks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboButtocks.ForeColor = System.Drawing.Color.Black;
            this.m_cboButtocks.ListBackColor = System.Drawing.Color.White;
            this.m_cboButtocks.ListForeColor = System.Drawing.Color.Black;
            this.m_cboButtocks.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboButtocks.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboButtocks.Location = new System.Drawing.Point(592, 148);
            this.m_cboButtocks.m_BlnEnableItemEventMenu = true;
            this.m_cboButtocks.MaxLength = 32767;
            this.m_cboButtocks.Name = "m_cboButtocks";
            this.m_cboButtocks.SelectedIndex = -1;
            this.m_cboButtocks.SelectedItem = null;
            this.m_cboButtocks.SelectionStart = 0;
            this.m_cboButtocks.Size = new System.Drawing.Size(184, 23);
            this.m_cboButtocks.TabIndex = 10000101;
            this.m_cboButtocks.TextBackColor = System.Drawing.Color.White;
            this.m_cboButtocks.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboNormalCircs
            // 
            this.m_cboNormalCircs.AccessibleDescription = "出院检查>>一般情况";
            this.m_cboNormalCircs.BackColor = System.Drawing.Color.White;
            this.m_cboNormalCircs.BorderColor = System.Drawing.Color.Black;
            this.m_cboNormalCircs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboNormalCircs.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboNormalCircs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboNormalCircs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboNormalCircs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboNormalCircs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboNormalCircs.ForeColor = System.Drawing.Color.Black;
            this.m_cboNormalCircs.ListBackColor = System.Drawing.Color.White;
            this.m_cboNormalCircs.ListForeColor = System.Drawing.Color.Black;
            this.m_cboNormalCircs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboNormalCircs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboNormalCircs.Location = new System.Drawing.Point(340, 186);
            this.m_cboNormalCircs.m_BlnEnableItemEventMenu = true;
            this.m_cboNormalCircs.MaxLength = 32767;
            this.m_cboNormalCircs.Name = "m_cboNormalCircs";
            this.m_cboNormalCircs.SelectedIndex = -1;
            this.m_cboNormalCircs.SelectedItem = null;
            this.m_cboNormalCircs.SelectionStart = 0;
            this.m_cboNormalCircs.Size = new System.Drawing.Size(184, 23);
            this.m_cboNormalCircs.TabIndex = 10000101;
            this.m_cboNormalCircs.TextBackColor = System.Drawing.Color.White;
            this.m_cboNormalCircs.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboLactation
            // 
            this.m_cboLactation.AccessibleDescription = "出院检查>>哺乳情况";
            this.m_cboLactation.BackColor = System.Drawing.Color.White;
            this.m_cboLactation.BorderColor = System.Drawing.Color.Black;
            this.m_cboLactation.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLactation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLactation.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLactation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLactation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLactation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLactation.ForeColor = System.Drawing.Color.Black;
            this.m_cboLactation.ListBackColor = System.Drawing.Color.White;
            this.m_cboLactation.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLactation.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLactation.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLactation.Location = new System.Drawing.Point(592, 185);
            this.m_cboLactation.m_BlnEnableItemEventMenu = true;
            this.m_cboLactation.MaxLength = 32767;
            this.m_cboLactation.Name = "m_cboLactation";
            this.m_cboLactation.SelectedIndex = -1;
            this.m_cboLactation.SelectedItem = null;
            this.m_cboLactation.SelectionStart = 0;
            this.m_cboLactation.Size = new System.Drawing.Size(184, 23);
            this.m_cboLactation.TabIndex = 10000101;
            this.m_cboLactation.TextBackColor = System.Drawing.Color.White;
            this.m_cboLactation.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboBLiverBacterin
            // 
            this.m_cboBLiverBacterin.AccessibleDescription = "出院检查>>乙肝疫苗";
            this.m_cboBLiverBacterin.BackColor = System.Drawing.Color.White;
            this.m_cboBLiverBacterin.BorderColor = System.Drawing.Color.Black;
            this.m_cboBLiverBacterin.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBLiverBacterin.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBLiverBacterin.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBLiverBacterin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBLiverBacterin.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBLiverBacterin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBLiverBacterin.ForeColor = System.Drawing.Color.Black;
            this.m_cboBLiverBacterin.ListBackColor = System.Drawing.Color.White;
            this.m_cboBLiverBacterin.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBLiverBacterin.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBLiverBacterin.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBLiverBacterin.Location = new System.Drawing.Point(340, 222);
            this.m_cboBLiverBacterin.m_BlnEnableItemEventMenu = true;
            this.m_cboBLiverBacterin.MaxLength = 32767;
            this.m_cboBLiverBacterin.Name = "m_cboBLiverBacterin";
            this.m_cboBLiverBacterin.SelectedIndex = -1;
            this.m_cboBLiverBacterin.SelectedItem = null;
            this.m_cboBLiverBacterin.SelectionStart = 0;
            this.m_cboBLiverBacterin.Size = new System.Drawing.Size(184, 23);
            this.m_cboBLiverBacterin.TabIndex = 10000101;
            this.m_cboBLiverBacterin.TextBackColor = System.Drawing.Color.White;
            this.m_cboBLiverBacterin.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboBcgVaccine
            // 
            this.m_cboBcgVaccine.AccessibleDescription = "出院检查>>卡介苗";
            this.m_cboBcgVaccine.BackColor = System.Drawing.Color.White;
            this.m_cboBcgVaccine.BorderColor = System.Drawing.Color.Black;
            this.m_cboBcgVaccine.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBcgVaccine.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBcgVaccine.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBcgVaccine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBcgVaccine.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBcgVaccine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBcgVaccine.ForeColor = System.Drawing.Color.Black;
            this.m_cboBcgVaccine.ListBackColor = System.Drawing.Color.White;
            this.m_cboBcgVaccine.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBcgVaccine.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBcgVaccine.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBcgVaccine.Location = new System.Drawing.Point(80, 221);
            this.m_cboBcgVaccine.m_BlnEnableItemEventMenu = true;
            this.m_cboBcgVaccine.MaxLength = 32767;
            this.m_cboBcgVaccine.Name = "m_cboBcgVaccine";
            this.m_cboBcgVaccine.SelectedIndex = -1;
            this.m_cboBcgVaccine.SelectedItem = null;
            this.m_cboBcgVaccine.SelectionStart = 0;
            this.m_cboBcgVaccine.Size = new System.Drawing.Size(184, 23);
            this.m_cboBcgVaccine.TabIndex = 10000101;
            this.m_cboBcgVaccine.TextBackColor = System.Drawing.Color.White;
            this.m_cboBcgVaccine.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboLimb
            // 
            this.m_cboLimb.AccessibleDescription = "出院检查>>四肢";
            this.m_cboLimb.BackColor = System.Drawing.Color.White;
            this.m_cboLimb.BorderColor = System.Drawing.Color.Black;
            this.m_cboLimb.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLimb.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLimb.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLimb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLimb.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLimb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLimb.ForeColor = System.Drawing.Color.Black;
            this.m_cboLimb.ListBackColor = System.Drawing.Color.White;
            this.m_cboLimb.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLimb.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLimb.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLimb.Location = new System.Drawing.Point(80, 187);
            this.m_cboLimb.m_BlnEnableItemEventMenu = true;
            this.m_cboLimb.MaxLength = 32767;
            this.m_cboLimb.Name = "m_cboLimb";
            this.m_cboLimb.SelectedIndex = -1;
            this.m_cboLimb.SelectedItem = null;
            this.m_cboLimb.SelectionStart = 0;
            this.m_cboLimb.Size = new System.Drawing.Size(184, 23);
            this.m_cboLimb.TabIndex = 10000101;
            this.m_cboLimb.TextBackColor = System.Drawing.Color.White;
            this.m_cboLimb.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtWeight
            // 
            this.m_txtWeight.AccessibleDescription = "出院检查>>体重";
            this.m_txtWeight.BackColor = System.Drawing.Color.White;
            this.m_txtWeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWeight.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWeight.Location = new System.Drawing.Point(80, 73);
            this.m_txtWeight.m_BlnIgnoreUserInfo = false;
            this.m_txtWeight.m_BlnPartControl = false;
            this.m_txtWeight.m_BlnReadOnly = false;
            this.m_txtWeight.m_BlnUnderLineDST = false;
            this.m_txtWeight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtWeight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtWeight.m_IntCanModifyTime = 6;
            this.m_txtWeight.m_IntPartControlLength = 0;
            this.m_txtWeight.m_IntPartControlStartIndex = 0;
            this.m_txtWeight.m_StrUserID = "";
            this.m_txtWeight.m_StrUserName = "";
            this.m_txtWeight.Multiline = false;
            this.m_txtWeight.Name = "m_txtWeight";
            this.m_txtWeight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtWeight.Size = new System.Drawing.Size(72, 24);
            this.m_txtWeight.TabIndex = 10000087;
            this.m_txtWeight.Tag = "8";
            this.m_txtWeight.Text = "";
            // 
            // m_cboHeart_OutHospital
            // 
            this.m_cboHeart_OutHospital.AccessibleDescription = "出院检查>>心";
            this.m_cboHeart_OutHospital.BackColor = System.Drawing.Color.White;
            this.m_cboHeart_OutHospital.BorderColor = System.Drawing.Color.Black;
            this.m_cboHeart_OutHospital.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHeart_OutHospital.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHeart_OutHospital.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHeart_OutHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHeart_OutHospital.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHeart_OutHospital.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHeart_OutHospital.ForeColor = System.Drawing.Color.Black;
            this.m_cboHeart_OutHospital.ListBackColor = System.Drawing.Color.White;
            this.m_cboHeart_OutHospital.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHeart_OutHospital.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHeart_OutHospital.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHeart_OutHospital.Location = new System.Drawing.Point(80, 111);
            this.m_cboHeart_OutHospital.m_BlnEnableItemEventMenu = true;
            this.m_cboHeart_OutHospital.MaxLength = 32767;
            this.m_cboHeart_OutHospital.Name = "m_cboHeart_OutHospital";
            this.m_cboHeart_OutHospital.SelectedIndex = -1;
            this.m_cboHeart_OutHospital.SelectedItem = null;
            this.m_cboHeart_OutHospital.SelectionStart = 0;
            this.m_cboHeart_OutHospital.Size = new System.Drawing.Size(184, 23);
            this.m_cboHeart_OutHospital.TabIndex = 10000101;
            this.m_cboHeart_OutHospital.TextBackColor = System.Drawing.Color.White;
            this.m_cboHeart_OutHospital.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboHead
            // 
            this.m_cboHead.AccessibleDescription = "出院检查>>头部";
            this.m_cboHead.BackColor = System.Drawing.Color.White;
            this.m_cboHead.BorderColor = System.Drawing.Color.Black;
            this.m_cboHead.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHead.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHead.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHead.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHead.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHead.ForeColor = System.Drawing.Color.Black;
            this.m_cboHead.ListBackColor = System.Drawing.Color.White;
            this.m_cboHead.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHead.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHead.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHead.Location = new System.Drawing.Point(340, 75);
            this.m_cboHead.m_BlnEnableItemEventMenu = true;
            this.m_cboHead.MaxLength = 32767;
            this.m_cboHead.Name = "m_cboHead";
            this.m_cboHead.SelectedIndex = -1;
            this.m_cboHead.SelectedItem = null;
            this.m_cboHead.SelectionStart = 0;
            this.m_cboHead.Size = new System.Drawing.Size(184, 23);
            this.m_cboHead.TabIndex = 10000101;
            this.m_cboHead.TextBackColor = System.Drawing.Color.White;
            this.m_cboHead.TextForeColor = System.Drawing.Color.Black;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(8, 47);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(70, 14);
            this.label43.TabIndex = 10000099;
            this.label43.Text = "出院日期:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(297, 48);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(70, 14);
            this.label42.TabIndex = 0;
            this.label42.Text = "住院天数:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(8, 77);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(77, 14);
            this.label44.TabIndex = 0;
            this.label44.Text = "体    重：";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(160, 78);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(21, 14);
            this.label45.TabIndex = 0;
            this.label45.Text = "kg";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(301, 80);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(49, 14);
            this.label46.TabIndex = 0;
            this.label46.Text = "头部：";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(557, 79);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(49, 14);
            this.label47.TabIndex = 0;
            this.label47.Text = "皮肤：";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(51, 115);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(35, 14);
            this.label48.TabIndex = 0;
            this.label48.Text = "心：";
            // 
            // m_dtpUmbilicalCordLeftTime
            // 
            this.m_dtpUmbilicalCordLeftTime.AccessibleDescription = "出院检查>>脐带(脱脐日期)";
            this.m_dtpUmbilicalCordLeftTime.BackColor = System.Drawing.Color.White;
            this.m_dtpUmbilicalCordLeftTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpUmbilicalCordLeftTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpUmbilicalCordLeftTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpUmbilicalCordLeftTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpUmbilicalCordLeftTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_dtpUmbilicalCordLeftTime.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpUmbilicalCordLeftTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpUmbilicalCordLeftTime.ForeColor = System.Drawing.Color.Black;
            this.m_dtpUmbilicalCordLeftTime.ListBackColor = System.Drawing.Color.White;
            this.m_dtpUmbilicalCordLeftTime.ListForeColor = System.Drawing.Color.Black;
            this.m_dtpUmbilicalCordLeftTime.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_dtpUmbilicalCordLeftTime.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_dtpUmbilicalCordLeftTime.Location = new System.Drawing.Point(381, 148);
            this.m_dtpUmbilicalCordLeftTime.m_BlnEnableItemEventMenu = true;
            this.m_dtpUmbilicalCordLeftTime.MaxLength = 32767;
            this.m_dtpUmbilicalCordLeftTime.Name = "m_dtpUmbilicalCordLeftTime";
            this.m_dtpUmbilicalCordLeftTime.SelectedIndex = -1;
            this.m_dtpUmbilicalCordLeftTime.SelectedItem = null;
            this.m_dtpUmbilicalCordLeftTime.SelectionStart = 0;
            this.m_dtpUmbilicalCordLeftTime.Size = new System.Drawing.Size(143, 23);
            this.m_dtpUmbilicalCordLeftTime.TabIndex = 10000101;
            this.m_dtpUmbilicalCordLeftTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpUmbilicalCordLeftTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboLung_OutHospital
            // 
            this.m_cboLung_OutHospital.AccessibleDescription = "出院检查>>肺";
            this.m_cboLung_OutHospital.BackColor = System.Drawing.Color.White;
            this.m_cboLung_OutHospital.BorderColor = System.Drawing.Color.Black;
            this.m_cboLung_OutHospital.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLung_OutHospital.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLung_OutHospital.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLung_OutHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLung_OutHospital.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLung_OutHospital.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLung_OutHospital.ForeColor = System.Drawing.Color.Black;
            this.m_cboLung_OutHospital.ListBackColor = System.Drawing.Color.White;
            this.m_cboLung_OutHospital.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLung_OutHospital.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLung_OutHospital.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLung_OutHospital.Location = new System.Drawing.Point(340, 112);
            this.m_cboLung_OutHospital.m_BlnEnableItemEventMenu = true;
            this.m_cboLung_OutHospital.MaxLength = 32767;
            this.m_cboLung_OutHospital.Name = "m_cboLung_OutHospital";
            this.m_cboLung_OutHospital.SelectedIndex = -1;
            this.m_cboLung_OutHospital.SelectedItem = null;
            this.m_cboLung_OutHospital.SelectionStart = 0;
            this.m_cboLung_OutHospital.Size = new System.Drawing.Size(184, 23);
            this.m_cboLung_OutHospital.TabIndex = 10000101;
            this.m_cboLung_OutHospital.TextBackColor = System.Drawing.Color.White;
            this.m_cboLung_OutHospital.TextForeColor = System.Drawing.Color.Black;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(315, 116);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(35, 14);
            this.label49.TabIndex = 0;
            this.label49.Text = "肺：";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(542, 116);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(63, 14);
            this.label50.TabIndex = 0;
            this.label50.Text = "生殖器：";
            // 
            // m_cboAbdomen
            // 
            this.m_cboAbdomen.AccessibleDescription = "出院检查>>腹部";
            this.m_cboAbdomen.BackColor = System.Drawing.Color.White;
            this.m_cboAbdomen.BorderColor = System.Drawing.Color.Black;
            this.m_cboAbdomen.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAbdomen.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboAbdomen.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAbdomen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAbdomen.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAbdomen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAbdomen.ForeColor = System.Drawing.Color.Black;
            this.m_cboAbdomen.ListBackColor = System.Drawing.Color.White;
            this.m_cboAbdomen.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAbdomen.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboAbdomen.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboAbdomen.Location = new System.Drawing.Point(80, 148);
            this.m_cboAbdomen.m_BlnEnableItemEventMenu = true;
            this.m_cboAbdomen.MaxLength = 32767;
            this.m_cboAbdomen.Name = "m_cboAbdomen";
            this.m_cboAbdomen.SelectedIndex = -1;
            this.m_cboAbdomen.SelectedItem = null;
            this.m_cboAbdomen.SelectionStart = 0;
            this.m_cboAbdomen.Size = new System.Drawing.Size(184, 23);
            this.m_cboAbdomen.TabIndex = 10000101;
            this.m_cboAbdomen.TextBackColor = System.Drawing.Color.White;
            this.m_cboAbdomen.TextForeColor = System.Drawing.Color.Black;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(8, 152);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(77, 14);
            this.label51.TabIndex = 0;
            this.label51.Text = "腹    部：";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(272, 153);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(119, 14);
            this.label52.TabIndex = 0;
            this.label52.Text = "脐带(脱脐日期)：";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(557, 155);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(49, 14);
            this.label53.TabIndex = 0;
            this.label53.Text = "臀部：";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(8, 191);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(77, 14);
            this.label54.TabIndex = 0;
            this.label54.Text = "四    肢：";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(272, 190);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(77, 14);
            this.label55.TabIndex = 0;
            this.label55.Text = "一般情况：";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(528, 190);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(77, 14);
            this.label56.TabIndex = 0;
            this.label56.Text = "哺乳情况：";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(8, 225);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(77, 14);
            this.label57.TabIndex = 0;
            this.label57.Text = "卡 介 苗：";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(272, 225);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(77, 14);
            this.label58.TabIndex = 0;
            this.label58.Text = "乙肝疫苗：";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(8, 265);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(77, 14);
            this.label59.TabIndex = 0;
            this.label59.Text = "其    他：";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(8, 324);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(77, 14);
            this.label60.TabIndex = 0;
            this.label60.Text = "出院医嘱：";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(8, 379);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(77, 14);
            this.label61.TabIndex = 0;
            this.label61.Text = "处    理：";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleDescription = "入室记录>>签名(txt)";
            this.m_txtDoctorSign.Enabled = false;
            this.m_txtDoctorSign.Location = new System.Drawing.Point(676, 601);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(102, 23);
            this.m_txtDoctorSign.TabIndex = 10000101;
            this.m_txtDoctorSign.Visible = false;
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.AccessibleDescription = "入室记录>>签名(cmd)";
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Enabled = false;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(605, 596);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(64, 32);
            this.m_cmdDoctorSign.TabIndex = 10000100;
            this.m_cmdDoctorSign.Tag = "1";
            this.m_cmdDoctorSign.Text = "签名:";
            this.m_cmdDoctorSign.Visible = false;
            // 
            // m_txtCheckDocSign
            // 
            this.m_txtCheckDocSign.AccessibleDescription = "出院检查>>医生签名(txt)";
            this.m_txtCheckDocSign.Enabled = false;
            this.m_txtCheckDocSign.Location = new System.Drawing.Point(494, 601);
            this.m_txtCheckDocSign.Name = "m_txtCheckDocSign";
            this.m_txtCheckDocSign.ReadOnly = true;
            this.m_txtCheckDocSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtCheckDocSign.TabIndex = 10000105;
            this.m_txtCheckDocSign.Visible = false;
            // 
            // m_cmdCheckDoc
            // 
            this.m_cmdCheckDoc.AccessibleDescription = "出院检查>>医生签名(cmd)";
            this.m_cmdCheckDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCheckDoc.DefaultScheme = true;
            this.m_cmdCheckDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCheckDoc.Enabled = false;
            this.m_cmdCheckDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCheckDoc.Hint = "";
            this.m_cmdCheckDoc.Location = new System.Drawing.Point(392, 596);
            this.m_cmdCheckDoc.Name = "m_cmdCheckDoc";
            this.m_cmdCheckDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCheckDoc.Size = new System.Drawing.Size(96, 32);
            this.m_cmdCheckDoc.TabIndex = 10000104;
            this.m_cmdCheckDoc.Tag = "1";
            this.m_cmdCheckDoc.Text = "医生签名:";
            this.m_cmdCheckDoc.Visible = false;
            // 
            // m_ctmRecordControl
            // 
            this.m_ctmRecordControl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mniAddBabyCircsRecord,
            this.m_mmiModifyBabyCircsRecord,
            this.m_mmiDelBabyCircsRecord});
            this.m_ctmRecordControl.Popup += new System.EventHandler(this.ctmRecordControl_Popup);
            // 
            // m_mniAddBabyCircsRecord
            // 
            this.m_mniAddBabyCircsRecord.Index = 0;
            this.m_mniAddBabyCircsRecord.Text = "添加新生儿情况记录";
            this.m_mniAddBabyCircsRecord.Click += new System.EventHandler(this.m_mniAddBabyCircsRecord_Click);
            // 
            // m_mmiModifyBabyCircsRecord
            // 
            this.m_mmiModifyBabyCircsRecord.Index = 1;
            this.m_mmiModifyBabyCircsRecord.Text = "修改新生儿情况记录";
            this.m_mmiModifyBabyCircsRecord.Click += new System.EventHandler(this.m_mmiModifyBabyCircsRecord_Click);
            // 
            // m_mmiDelBabyCircsRecord
            // 
            this.m_mmiDelBabyCircsRecord.Index = 2;
            this.m_mmiDelBabyCircsRecord.Text = "删除新生儿情况记录";
            this.m_mmiDelBabyCircsRecord.Click += new System.EventHandler(this.m_mmiDelBabyCircsRecord_Click);
            // 
            // m_cboBabySex
            // 
            this.m_cboBabySex.AccessibleDescription = "婴儿性别";
            this.m_cboBabySex.BackColor = System.Drawing.Color.White;
            this.m_cboBabySex.BorderColor = System.Drawing.Color.Black;
            this.m_cboBabySex.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBabySex.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBabySex.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBabySex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBabySex.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBabySex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBabySex.ForeColor = System.Drawing.Color.Black;
            this.m_cboBabySex.ListBackColor = System.Drawing.Color.White;
            this.m_cboBabySex.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBabySex.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBabySex.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBabySex.Location = new System.Drawing.Point(424, 73);
            this.m_cboBabySex.m_BlnEnableItemEventMenu = true;
            this.m_cboBabySex.MaxLength = 32767;
            this.m_cboBabySex.Name = "m_cboBabySex";
            this.m_cboBabySex.SelectedIndex = -1;
            this.m_cboBabySex.SelectedItem = null;
            this.m_cboBabySex.SelectionStart = 0;
            this.m_cboBabySex.Size = new System.Drawing.Size(71, 23);
            this.m_cboBabySex.TabIndex = 10000102;
            this.m_cboBabySex.TextBackColor = System.Drawing.Color.White;
            this.m_cboBabySex.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdRecorder
            // 
            this.m_cmdRecorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdRecorder.DefaultScheme = true;
            this.m_cmdRecorder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRecorder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdRecorder.ForeColor = System.Drawing.Color.Black;
            this.m_cmdRecorder.Hint = "";
            this.m_cmdRecorder.Location = new System.Drawing.Point(618, 69);
            this.m_cmdRecorder.Name = "m_cmdRecorder";
            this.m_cmdRecorder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRecorder.Size = new System.Drawing.Size(72, 24);
            this.m_cmdRecorder.TabIndex = 10000103;
            this.m_cmdRecorder.Text = "记录者:";
            this.m_cmdRecorder.Visible = false;
            // 
            // txtSign
            // 
            this.txtSign.AccessibleDescription = "记录者";
            this.txtSign.AccessibleName = "NoDefault";
            this.txtSign.BackColor = System.Drawing.Color.White;
            this.txtSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSign.ForeColor = System.Drawing.Color.Black;
            this.txtSign.Location = new System.Drawing.Point(692, 70);
            this.txtSign.Name = "txtSign";
            this.txtSign.ReadOnly = true;
            this.txtSign.Size = new System.Drawing.Size(116, 23);
            this.txtSign.TabIndex = 10000104;
            this.txtSign.Visible = false;
            // 
            // m_lblOutHospitalDays
            // 
            this.m_lblOutHospitalDays.AcceptsReturn = true;
            this.m_lblOutHospitalDays.AccessibleDescription = "出院检查>>住院天数";
            this.m_lblOutHospitalDays.Location = new System.Drawing.Point(374, 44);
            this.m_lblOutHospitalDays.Name = "m_lblOutHospitalDays";
            this.m_lblOutHospitalDays.Size = new System.Drawing.Size(100, 23);
            this.m_lblOutHospitalDays.TabIndex = 10000549;
            // 
            // frmNewBabyInRoomRecord
            // 
            this.ClientSize = new System.Drawing.Size(824, 673);
            this.Controls.Add(this.m_cmdRecorder);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_txtCheckDocSign);
            this.Controls.Add(this.m_cmdCheckDoc);
            this.Controls.Add(this.m_txtDoctorSign);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_cboBabySex);
            this.Controls.Add(this.m_cmdDoctorSign);
            this.Name = "frmNewBabyInRoomRecord";
            this.Text = "新生儿入室记录";
            this.Load += new System.EventHandler(this.frmNewBabyInRoomRecord_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblNation, 0);
            this.Controls.SetChildIndex(this.lblNation, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.m_lblLinkMan, 0);
            this.Controls.SetChildIndex(this.m_lblCreateUserName, 0);
            this.Controls.SetChildIndex(this.m_lblMarriaged, 0);
            this.Controls.SetChildIndex(this.m_lblOccupation, 0);
            this.Controls.SetChildIndex(this.m_lblNativePlace, 0);
            this.Controls.SetChildIndex(this.m_cmdCreateID, 0);
            this.Controls.SetChildIndex(this.lblCreateDate, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.lblLinkMan, 0);
            this.Controls.SetChildIndex(this.lblMarriaged, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.lblNativePlace, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
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
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_cboBabySex, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_txtDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_cmdCheckDoc, 0);
            this.Controls.SetChildIndex(this.m_txtCheckDocSign, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.Controls.SetChildIndex(this.m_cmdRecorder, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecord)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 界面逻辑判断
		private void m_rdbBreechDelivery_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_rdbBreechDelivery.Checked)
			{
				panel2.Enabled = true;
			}
			else
			{
				panel2.Enabled = false;
				m_rdbBreechNature.Checked = false;
				m_rdbBreechHalf.Checked = false;
				m_rdbBreechTow.Checked = false; 
			}
		}

		#endregion

		private void m_mniAddBabyCircsRecord_Click(object sender, System.EventArgs e)
		{		
			DateTime dtSelectedInPatientDate = DateTime.MinValue;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }

			if(m_objCurrentPatient == null)
				return;
            //dtSelectedInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			string strOpenDate = "";
			frmNewBabyCircsRecord frm = new frmNewBabyCircsRecord(true,m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text,ref strOpenDate);
			frm.StartPosition = FormStartPosition.CenterParent;
			if(frm.ShowDialog() == DialogResult.Yes)
			{
				clsNewBabyCircsRecord[] objCircsRecordArr;
				long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text,out objCircsRecordArr);

                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                //添加内容到DataTable
                if (strOpenDate == "")
                    strOpenDate = "1900-01-01 00:00:00";
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse(strOpenDate));

                //TreeNode trvTemp=trvTime.SelectedNode;
                //trvTime.SelectedNode=null;
                //trvTime.SelectedNode=trvTemp;
			}
		}

		private void m_mmiDelBabyCircsRecord_Click(object sender, System.EventArgs e)
		{
			DateTime dtSelectedInPatientDate = DateTime.MinValue;
			DateTime dtOpen = DateTime.MinValue;
			DateTime dtModify = DateTime.MinValue;

            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }
			try
			{
				dtOpen = Convert.ToDateTime(m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][1]);
				dtModify = Convert.ToDateTime(m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][2]);
			}
			catch
			{
				MDIParent.ShowInformationMessageBox("请先选择一条记录");
				return;
			}
			//传递参数
			int intSelectedRecordStartRow =m_dtgRecord.CurrentCell.RowNumber;
			//确认
			if(MessageBox.Show("确认要删除选中的病情记录内容？","删除提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.Cancel)
				return;

			//打开窗体
			//删除
			clsNewBabyCircsRecord objDelRecord = new clsNewBabyCircsRecord();
            objDelRecord.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			objDelRecord.m_dtmOpenDate = dtOpen;
			objDelRecord.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
			objDelRecord.m_strDeActivedOperatorID = MDIParent.OperatorID;
			objDelRecord.m_dtmDeActivedDate = DateTime.Now;
			objDelRecord.m_dtmModifyDate = dtModify;

			long lngRes=m_objDomain.m_lngDeleteCircsRecord(objDelRecord);
			//更新
			if (lngRes>0)
			{
                clsNewBabyCircsRecord[] objCircsRecordArr;
                lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, out objCircsRecordArr);

                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                //添加内容到DataTable
                m_dtbRecords.Clear();
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse("1900-01-01 00:00:00"));
			}
		}

		private void m_mmiModifyBabyCircsRecord_Click(object sender, System.EventArgs e)
		{
			DateTime dtSelectedInPatientDate = DateTime.MinValue;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }
			if(m_objCurrentPatient == null)
				return;
            //dtSelectedInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			string strOpenDate =  m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][1].ToString();;
			frmNewBabyCircsRecord frm = new frmNewBabyCircsRecord(false,m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text,ref strOpenDate);
			frm.StartPosition = FormStartPosition.CenterParent;
			if(frm.ShowDialog() == DialogResult.Yes)
			{
				clsNewBabyCircsRecord[] objCircsRecordArr;
				long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text,out objCircsRecordArr);

                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                //添加内容到DataTable
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse("1900-01-01 00:00:00"));

                //TreeNode trvTemp=trvTime.SelectedNode;
                //trvTime.SelectedNode=null;
                //trvTime.SelectedNode=trvTemp;
			}
		}

		private void frmNewBabyInRoomRecord_Load(object sender, System.EventArgs e)
		{
			m_mthInitDataTable(m_dtbRecords);
			m_dtgRecord.DataSource = m_dtbRecords;			
			m_mthSetRichTextBoxAttribInControl(this);
			m_mthSetAllDataGridTextBoxColum();
			m_dtmPreRecordDate = DateTime.MinValue;
		}

		private void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{
			//存放记录时间的字符串
			p_dtbRecordTable.Columns.Add("CreateDate");//0
			//存放记录的OpenDate字符串
			p_dtbRecordTable.Columns.Add("OpenDate");  //1
			//存放记录的ModifyDate字符串
			p_dtbRecordTable.Columns.Add("ModifyDate"); //2

			DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDate");//3
			dc1.DefaultValue = "";
			DataColumn dc2 = p_dtbRecordTable.Columns.Add("BirthDays");//4
			dc2.DefaultValue = "";
			p_dtbRecordTable.Columns.Add("BirthBurl",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//5
			p_dtbRecordTable.Columns.Add("Haematoma",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//6
			p_dtbRecordTable.Columns.Add("Fontanel",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//7
			p_dtbRecordTable.Columns.Add("Conjunctiva",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//8
			p_dtbRecordTable.Columns.Add("Secretion",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//9
			p_dtbRecordTable.Columns.Add("Pharynx",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//10
			p_dtbRecordTable.Columns.Add("WhitePoint",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//11
			p_dtbRecordTable.Columns.Add("Icterus",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//12
			p_dtbRecordTable.Columns.Add("Fester",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//13
			p_dtbRecordTable.Columns.Add("Bleeding",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//14
			p_dtbRecordTable.Columns.Add("Agnail",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//15
			p_dtbRecordTable.Columns.Add("RedStern",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//16
			p_dtbRecordTable.Columns.Add("SternSkin",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//17		
			p_dtbRecordTable.Columns.Add("HeartLung",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue)); //18
			p_dtbRecordTable.Columns.Add("Abdomen",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//19			
			p_dtbRecordTable.Columns.Add("Remark",typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//20
			DataColumn dc3 = p_dtbRecordTable.Columns.Add("Sign");//21
			dc3.DefaultValue = "";

			//设置文字栏
			this.m_clmRecordDate.HeaderText = "日  期";
			this.m_clmBirthDays.HeaderText = "出生天数";
			this.m_dtcBirthBurl.HeaderText = "头-产瘤";
			this.m_dtcHaematoma.HeaderText = "头-血肿";
			this.m_dtcFontanel.HeaderText = "头-前囟";
			this.m_dtcConjunctiva.HeaderText = "眼-结膜充血";
			this.m_dtcSecretion.HeaderText = "眼-分泌物";
			this.m_dtcPharynx.HeaderText = "口-咽充血";
			this.m_dtcWhitePoint.HeaderText = "口-白点";
			this.m_dtcIcterus.HeaderText = "皮肤-黄疸";
			this.m_dtcFester.HeaderText = "皮肤-脓疮";	
			this.m_dtcBleeding.HeaderText = "脐-出血";					
			this.m_dtcAgnail.HeaderText = "脐-发炎";
			this.m_dtcRedStern.HeaderText = "臀-红";
			this.m_dtcSternSkin.HeaderText = "臀-皮肤";
			this.m_dtcHeartLung.HeaderText = "心  肺";
			this.m_dtcAbdomen.HeaderText = "腹  部";
			this.m_dtcRemark.HeaderText = "备  注";
			this.m_clmSign.HeaderText = "签  名";
		}

		private void m_mthSetAllDataGridTextBoxColum()
		{
			m_mthSetControl(m_clmRecordDate);
			m_mthSetControl(m_clmBirthDays);
			m_mthSetControl(m_dtcBirthBurl);
			m_mthSetControl(m_dtcHaematoma);
			m_mthSetControl(m_dtcFontanel);
			m_mthSetControl(m_dtcConjunctiva);
			m_mthSetControl(m_dtcSecretion);
			m_mthSetControl(m_dtcPharynx);
			m_mthSetControl(m_dtcWhitePoint);
			m_mthSetControl(m_dtcIcterus);
			m_mthSetControl(m_dtcFester);
			m_mthSetControl(m_dtcBleeding);
			m_mthSetControl(m_dtcAgnail);
			m_mthSetControl(m_dtcRedStern);
			m_mthSetControl(m_dtcSternSkin);
			m_mthSetControl(m_dtcHeartLung);
			m_mthSetControl(m_dtcAbdomen);
			m_mthSetControl(m_dtcRemark);
			m_mthSetControl(m_clmSign);
		}

		/// <summary>
		/// 设置DataGrid内的控件触发的事件和右键菜单
		/// </summary>
		/// <param name="p_objControl"></param>
		private void m_mthSetControl(DataGridTextBoxColumn p_objControl)
		{
			Control m_objControl;
			m_objControl = (DataGridTextBox)p_objControl.TextBox;
			m_objControl.ContextMenu = m_ctmRecordControl;
			m_objControl.DoubleClick += new EventHandler(m_mthTxtDoubleClick);
		}

		/// <summary>
		/// 设置DataGrid内的控件触发的事件和右键菜单
		/// </summary>
		/// <param name="p_objControl"></param>
		private void m_mthSetControl(com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox p_objControl)
		{
			p_objControl.m_RtbBase.ContextMenu = m_ctmRecordControl;
			p_objControl.m_RtbBase.MouseDown += new MouseEventHandler(cltDataGridDSTRichTextBox_MouseDown);
		}

		/// <summary>
		/// 双击DataGrid内的控件触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private  void m_mthTxtDoubleClick(object sender,EventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			try
			{
				int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecord.CurrentCell.RowNumber);
				if(intSelectedRecordStartRow < 0)
					return;
				string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][1].ToString();
				m_mthModifyRecord(DateTime.Parse(strOpenDate));
			}
			catch(Exception exp)
			{
				string strErrorMessage=exp.Message;
			}
		}

		/// <summary>
		/// 双击DataGrid内的控件触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cltDataGridDSTRichTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			try
			{
				if(e.Clicks > 1)
				{
					int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecord.CurrentCell.RowNumber);
					if(intSelectedRecordStartRow < 0)
						return;
					string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][1].ToString();
                    //m_mthModifyRecord(DateTime.Parse(strOpenDate));

                    DateTime dtSelectedInPatientDate = DateTime.MinValue;
                    if (m_ObjCurrentEmrPatientSession != null)
                    {
                        dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
                    }
                    else
                    {
                        m_dtbRecords.Clear();
                        return;
                    }

                    frmNewBabyCircsRecord frm = new frmNewBabyCircsRecord(false, m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, ref strOpenDate);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        clsNewBabyCircsRecord[] objCircsRecordArr;
                        long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, out objCircsRecordArr);

                        //设置内容到DataTable
                        object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                        //添加内容到DataTable
                        m_mthAddDataToDataTable(objDataArr, DateTime.Parse("1900-01-01 00:00:00"));

                    }
				}
			}
			catch
			{
				
			}
		}

		/// <summary>
		/// 处理之前判断DataGrid与DataTable的关系
		/// </summary>
		/// <returns></returns>
		protected virtual bool m_blnCheckDataGridCurrentRow()
		{
			try
			{
				if(m_dtbRecords.Rows.Count <=0)
					return false;
				if(m_dtgRecord.CurrentCell.RowNumber  >= m_dtbRecords.Rows.Count)
				{
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}

		}

		/// <summary>
		///  获取用户选择的记录的开始行位置
		/// </summary>
		/// <param name="p_intSelectRowIndex">返回索引</param>
		/// <returns></returns>
		protected virtual int m_intGetRecordStartRow(int p_intSelectRowIndex)
		{
			//以p_intSelectRow开始，从后往前循环DataTable
			//如果当前记录的第一个字段不为空
			//返回索引
			for(int i1=p_intSelectRowIndex;i1>=0;i1--)
			{
				if(m_dtbRecords.Rows[i1][1].ToString() != "")
				{
					return i1;
				}
			}

			return -1;
		}

		protected void m_mthModifyRecord(DateTime p_dtmOpenRecordTime)
		{
			if(!m_blnCanShowNewForm)
				return;

			DateTime dtSelectedInPatientDate = DateTime.MinValue;
            //try
            //{
            //    dtSelectedInPatientDate = DateTime.Parse(trvTime.SelectedNode.Text.Trim());
            //}
            //catch
            //{
            //    m_dtbRecords.Clear();
            //}
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
            }
			//获取添加记录的窗体
			string strOpenDate = p_dtmOpenRecordTime.ToString("yyyy-MM-dd HH:mm:ss");
			frmNewBabyCircsRecord frmAddNewForm = new frmNewBabyCircsRecord(false,m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_dtpCreateDate.Text,ref strOpenDate); 

			m_mthShowSubForm(frmAddNewForm);
			
			MDIParent.s_ObjSaveCue.m_mthAddFormStatus(frmAddNewForm);
		}

		protected void m_mthShowSubForm(Form p_frmSubForm)
		{
			p_frmSubForm.Closed += new EventHandler(m_mthSubFormClosed);
			m_blnCanShowNewForm = false;
			m_frmCurrentSub = (frmNewBabyCircsRecord)p_frmSubForm;

			p_frmSubForm.TopMost = true;
			p_frmSubForm.Show();				
		}

		private frmNewBabyCircsRecord m_frmCurrentSub = null;
		private void m_mthSubFormClosed(object p_objSender,EventArgs p_objArg)
		{
			frmNewBabyCircsRecord frmAddNewForm = (frmNewBabyCircsRecord)p_objSender; 			

			m_blnCanShowNewForm = true;
			m_frmCurrentSub = null;
		}

		// 获取病程记录的领域层实例
		protected override clsBaseCaseHistoryDomain  m_objGetDomain()
		{
            return new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.NewBabyInRoomRecord);
		}

		private void ctmRecordControl_Popup(object sender, System.EventArgs e)
		{
			bool blnEnable=true;
			m_mniAddBabyCircsRecord.Enabled = blnEnable;
			m_mmiModifyBabyCircsRecord.Enabled = blnEnable;
			m_mmiDelBabyCircsRecord.Enabled = blnEnable;
		}

		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
				if(m_txtCheckDocSign.Tag != null)
					return m_txtCheckDocSign.Tag.ToString();
				return "";
			}
		}
		#endregion 属性

		protected override void m_mthClearRecordInfo()
		{
            m_lblOutHospitalDate.Text = "";
            m_lblOutHospitalDays.Text = "";
            m_cboBabySex.Text = "";
            m_dtpCreateDate.Text = "";
			m_cboBabySex.SelectedIndex = -1;
			m_cboPregnantWeeks.Text = "";
			m_cboReaction.Text = "";
			m_cboMuscleStrain.Text = "";
			m_cboCryVoice.Text = "";
			m_cboDropsy.Text = "";
			m_cboColor.Text = "";
			m_cboElasticity.Text = "";
			m_cboIcterus.Text = "";
			m_cboPigment.Text = "";
			m_cboPetechia.Text = "";
			m_txtBirthBurl.m_mthClearText();
			m_txtHaematoma.m_mthClearText();
			m_cboSkullSoft.Text = "";
			m_cboBoneSew.Text = "";
			m_txtHeadRound.m_mthClearText();
			m_cboFacialFeatures.Text = "";
			m_cboMouth.Text = "";
			m_cboHeart.Text = "";
			m_cboLung.Text = "";
			m_cboChest.Text = "";
			m_cboVein.Text = "";
			m_cboLiver.Text = "";
			m_cboSpleen.Text = "";
			m_cboHilum.Text = "";
			m_cboActivity.Text = "";
			m_cboArthrosis.Text = "";
			m_cboAbnormality.Text = "";
			m_cboGenitalia.Text = "";
			m_txtOtherRecord.m_mthClearText();
			m_txtWeight.m_mthClearText();
			m_cboHead.Text = "";
			m_cboSkin.Text = "";
			m_cboHeart_OutHospital.Text = "";
			m_cboLung_OutHospital.Text = "";
			m_cboGenitalia_OutHospital.Text = "";
			m_cboAbdomen.Text = "";
			m_cboButtocks.Text = "";
			m_cboLimb.Text = "";
			m_cboNormalCircs.Text = "";
			m_cboLactation.Text = "";
			m_cboBcgVaccine.Text = "";
			m_cboBLiverBacterin.Text = "";
            m_rdbOutHospitalC.Checked = false;
            m_rdbChangeDeptC.Checked = false;
			m_txtOtherCheck.m_mthClearText();
			m_txtOutHospitalAdvice.m_mthClearText();
			m_txtDealWith.m_mthClearText();
			m_dtpUmbilicalCordLeftTime.Text = "";
			m_dtpCheckDate.Value = DateTime.Now;
			m_dtpCreateDate.Value = DateTime.Now;
            //m_lsvAssistant1.Items.Clear();
            //m_lsvAssistant2.Items.Clear();
            //MDIParent.m_mthSetDefaulEmployee(m_lsvAssistant1);
            //MDIParent.m_mthSetDefaulEmployee(m_lsvAssistant2);
            m_txtBedNO.Focus();
		}

		protected override void m_mthUnEnableRichTextBox()
		{
			
		}

		protected override void m_mthEnableRichTextBox()
		{			
			
		}

		// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
		
		}

		// 获取选择已经删除记录的窗体标题
		public    override void m_strReloadFormTitle()
		{
		
		}
		// 是否允许修改特殊记录的记录信息。
		protected override void m_mthEnableModifySub(bool p_blnEnable)
		{

		}

		// 从界面获取特殊记录的值。如果界面值出错，返回null。
		protected  clsNewBabyInRoomRecord m_objGetContentFromGUI()
		{
			clsNewBabyInRoomRecord objContent = new clsNewBabyInRoomRecord();

            #region 获取签名集合
            int intSignCount = 0;

            //intSignCount = m_txtOperator.Items.Count + 1;
            //intSignCount += m_txtAnaesthetist.Items.Count + 1;
            intSignCount = m_lsvAssistant1.Items.Count + 1;
            intSignCount += m_lsvAssistant2.Items.Count + 1;
            //if (m_txtAnaesthetist.Tag != null)
            //{
            //    intSignCount++;
            //}
            //if (m_txtOperator.Tag != null)
            //{
            //    intSignCount++;
            //}
            objContent.objSignerArr = new clsEmrSigns_VO[intSignCount];
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { m_lsvAssistant1, m_lsvAssistant2 }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            #endregion

            string strCHILDBEARING = "";
			strCHILDBEARING += m_rdbSmoothBirth.Checked ? "1":"0";
			strCHILDBEARING += m_rdbClampBirth.Checked ? "1":"0";
			strCHILDBEARING += m_rdbSuctionBirth.Checked ? "1":"0";
			strCHILDBEARING += m_rdbCaesareanBirth.Checked ? "1":"0";
			strCHILDBEARING += m_rdbBreechDelivery.Checked ? "1":"0";
			strCHILDBEARING += m_rdbBreechNature.Checked ? "1":"0";
			strCHILDBEARING += m_rdbBreechHalf.Checked ? "1":"0";
			strCHILDBEARING += m_rdbBreechTow.Checked ? "1":"0";
			objContent.m_strCHILDBEARING = strCHILDBEARING;

			objContent.m_strPREGNANTTIME = m_cboPregnantWeeks.Text;
			objContent.m_strREACTION = m_cboReaction.Text;
			objContent.m_strBABYSEX = m_cboBabySex.Text;
			objContent.m_strMUSCLESTRAIN = m_cboMuscleStrain.Text;
			objContent.m_strCRYVOICE = m_cboCryVoice.Text;
			objContent.m_strDROPSY = m_cboDropsy.Text;
			objContent.m_strSKINCOLOR = m_cboColor.Text;
			objContent.m_strELASTICITY = m_cboElasticity.Text;
			objContent.m_strICTERUS = m_cboIcterus.Text;
			objContent.m_strPIGMENT = m_cboPigment.Text;
			objContent.m_strPETECHIA = m_cboPetechia.Text;
			objContent.m_strBIRTHBURL = m_txtBirthBurl.Text;
			objContent.m_strHAEMATOMA = m_txtHaematoma.Text;
			objContent.m_strSKULLSOFT = m_cboSkullSoft.Text;
			objContent.m_strBONESEW = m_cboBoneSew.Text;

			string strFontanel = "";
			strFontanel += m_rdbFontanelOut.Checked ? "1":"0";
			strFontanel += m_rdbFontanelSatiation.Checked ? "1":"0";
			strFontanel += m_rdbFontanelLow.Checked ? "1":"0";
			strFontanel += m_rdbFontanelFlat.Checked ? "1":"0";
			objContent.m_strFONTANEL = strFontanel;

			objContent.m_strHEADROUND = m_txtHeadRound.Text;
			objContent.m_strFACIALFEATURES = m_cboFacialFeatures.Text;
			objContent.m_strMOUTH = m_cboMouth.Text;
			objContent.m_strHEART = m_cboHeart.Text;
			objContent.m_strLUNG = m_cboLung.Text;
			objContent.m_strCHEST = m_cboChest.Text;
			objContent.m_strVEIN = m_cboVein.Text;
			objContent.m_strLIVER = m_cboLiver.Text;
			objContent.m_strSPLEEN = m_cboSpleen.Text;
			objContent.m_strHILUM = m_cboHilum.Text;
			objContent.m_strACTIVITY = m_cboActivity.Text;
			objContent.m_strARTHROSIS = m_cboArthrosis.Text;
			objContent.m_strABNORMALITY = m_cboAbnormality.Text;
			objContent.m_strGENITALIA = m_cboGenitalia.Text;

			objContent.m_strOTHERRECORD = m_txtOtherRecord.m_strGetRightText();
			objContent.m_strOTHERRECORDXML = m_txtOtherRecord.m_strGetXmlText();

			objContent.m_strWEIGHT = m_txtWeight.Text;
			objContent.m_strHEAD = m_cboHead.Text;
			objContent.m_strSKIN = m_cboSkin.Text;
			objContent.m_strHEART_OUTHOSPITAL = m_cboHeart_OutHospital.Text;
			objContent.m_strLUNG_OUTHOSPITAL = m_cboLung_OutHospital.Text;
			objContent.m_strGENITALIA_OUTHOSPITAL = m_cboGenitalia_OutHospital.Text;
			objContent.m_strABDOMEN = m_cboAbdomen.Text;
			objContent.m_strBUTTOCKS = m_cboButtocks.Text;
			objContent.m_strLIMB = m_cboLimb.Text;
			objContent.m_strNORMALCIRCS = m_cboNormalCircs.Text;
			objContent.m_strLACTATION = m_cboLactation.Text;
			objContent.m_strBCGVACCINE = m_cboBcgVaccine.Text;
			objContent.m_strBLIVERBACTERIN = m_cboBLiverBacterin.Text;
			objContent.m_strOTHERCHECK = m_txtOtherCheck.m_strGetRightText();
			objContent.m_strOTHERCHECKXML = m_txtOtherCheck.m_strGetXmlText();

			objContent.m_strOUTHOSPITALADVICE = m_txtOutHospitalAdvice.m_strGetRightText();
			objContent.m_strOUTHOSPITALADVICEXML = m_txtOutHospitalAdvice.m_strGetXmlText();

			objContent.m_strDEALWITH = m_txtDealWith.m_strGetRightText();
			objContent.m_strDEALWITHXML = m_txtDealWith.m_strGetXmlText();
            //DateTime dtTemp;
            //DateTime.TryParse(m_dtpUmbilicalCordLeftTime.Text, out dtTemp);
            objContent.m_dtmUMBILICALCORDLEFTTIME = m_dtpUmbilicalCordLeftTime.Text;
			objContent.m_dtmCHECKDATE = m_dtpCheckDate.Value;
			objContent.m_dtmBIRTHTIME = m_dtpCreateDate.Value;
            //修改部分
            if (m_rdbOutHospitalC.Checked)
            {
                objContent.m_strCHECKEDCHANGE = "1";
            }
            else if (m_rdbChangeDeptC.Checked)
            {
                objContent.m_strCHECKEDCHANGE = "2";
            }
            else
            {
                objContent.m_strCHECKEDCHANGE = "0";
            }
            objContent.m_strINHOSPITALDAYS = m_lblOutHospitalDays.Text.Trim();
            DateTime dtOut =DateTime.MinValue;
            if (!DateTime.TryParse(m_lblOutHospitalDate.Text.Trim(),out dtOut) || m_lblOutHospitalDate.Text == "    年  月  日" || string.IsNullOrEmpty(m_lblOutHospitalDate.Text.Trim()))
            {
                objContent.m_dtOUTHOSPITALDATE = DateTime.Parse("1900-01-01 00:00:00");
            }
            else
            {
                objContent.m_dtOUTHOSPITALDATE = DateTime.Parse(m_lblOutHospitalDate.Text.Trim());
            }
            string checkname = "";
            for (int i = 0; i < m_lsvAssistant1.Items.Count; i++)
            {
                checkname += m_lsvAssistant1.Items[i].Text.ToString() + " ";
            }
            objContent.m_strINROOMCHECKDOCName = checkname;

            string dtname = "";
            for (int i = 0; i < m_lsvAssistant2.Items.Count; i++)
            {
                dtname += m_lsvAssistant2.Items[i].Text.ToString() + " ";
            }
            //objContent.m_strINROOMCHECKDOCName = m_lsvAssistant1.Items[0].Text.ToString();
            objContent.m_strRECORDSIGNDOCName = dtname;

            //if (m_txtDoctorSign.Tag != null)
            //{
            //    objContent.m_strINROOMCHECKDOCID = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPID_CHR;
            //}
            //else
            //{
            //    objContent.m_strINROOMCHECKDOCID = string.Empty;
            //}

            //if (m_txtCheckDocSign.Tag != null)
            //{
            //    objContent.m_strRECORDSIGNDOCID = ((clsEmrEmployeeBase_VO)m_txtCheckDocSign.Tag).m_strEMPID_CHR;
            //}
            //else
            //{
            //    objContent.m_strRECORDSIGNDOCID = string.Empty;
            //}

            //objContent.m_strINROOMCHECKDOCName = m_txtDoctorSign.Text;
            //objContent.m_strRECORDSIGNDOCName = m_txtCheckDocSign.Text;

			return objContent;

            m_txtBedNO.Focus();
		}

		// 把特殊记录的值显示到界面上。
		protected  void m_mthSetGUIFromContent(clsNewBabyInRoomRecord objContent)
		{
             #region 签名集合
            if (objContent.objSignerArr != null)
            {
                //  m_mthAddSignToListView(new ListView[] { m_lsvAssistant1, m_lsvAssistant2, m_txtOperator, m_txtAnaesthetist }, objRecord.objSignerArr);//, new bool[] { true, true, true, true, true }, false);
                m_mthAddSignToListView(new ListView[] { m_lsvAssistant1, m_lsvAssistant2 }, objContent.objSignerArr,1);
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName == "txtSign")
                //    {
                //        txtSign.Text = objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
                //        txtSign.Tag = objContent.objSignerArr[i].objEmployee;
                //    }
                //}
            }
             #endregion

            if ( objContent.m_strInPatientID !=null && objContent.m_strInPatientID !="")
			{
				m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
			}
			m_rdbSmoothBirth.Checked = objContent.m_strCHILDBEARING[0].ToString()=="1" ? true:false;
			m_rdbClampBirth.Checked = objContent.m_strCHILDBEARING[1].ToString() == "1" ? true:false;
			m_rdbSuctionBirth.Checked = objContent.m_strCHILDBEARING[2].ToString() == "1" ? true:false;
			m_rdbCaesareanBirth.Checked = objContent.m_strCHILDBEARING[3].ToString() == "1" ? true:false;
			m_rdbBreechDelivery.Checked = objContent.m_strCHILDBEARING[4].ToString() == "1" ? true:false;
			m_rdbBreechNature.Checked = objContent.m_strCHILDBEARING[5].ToString() == "1" ? true:false;
			m_rdbBreechHalf.Checked = objContent.m_strCHILDBEARING[6].ToString() == "1" ? true:false;
			m_rdbBreechTow.Checked = objContent.m_strCHILDBEARING[7].ToString() == "1" ? true:false;

			m_cboPregnantWeeks.Text = objContent.m_strPREGNANTTIME;
			m_cboReaction.Text = objContent.m_strREACTION;
			m_cboBabySex.Text = objContent.m_strBABYSEX;
			m_cboMuscleStrain.Text = objContent.m_strMUSCLESTRAIN;
			m_cboCryVoice.Text = objContent.m_strCRYVOICE;
			m_cboDropsy.Text = objContent.m_strDROPSY;
			m_cboColor.Text = objContent.m_strSKINCOLOR;
			m_cboElasticity.Text = objContent.m_strELASTICITY;
			m_cboIcterus.Text = objContent.m_strICTERUS;
			m_cboPigment.Text = objContent.m_strPIGMENT;
			m_cboPetechia.Text = objContent.m_strPETECHIA;
			m_txtBirthBurl.Text = objContent.m_strBIRTHBURL;
			m_txtHaematoma.Text = objContent.m_strHAEMATOMA;
			m_cboSkullSoft.Text = objContent.m_strSKULLSOFT;
			m_cboBoneSew.Text = objContent.m_strBONESEW;

			m_rdbFontanelOut.Checked = objContent.m_strFONTANEL[0].ToString() == "1" ? true:false;
			m_rdbFontanelSatiation.Checked = objContent.m_strFONTANEL[1].ToString() == "1" ? true:false;
			m_rdbFontanelLow.Checked = objContent.m_strFONTANEL[2].ToString() == "1" ? true:false;
			m_rdbFontanelFlat.Checked = objContent.m_strFONTANEL[3].ToString() == "1" ? true:false;

			m_txtHeadRound.Text = objContent.m_strHEADROUND;
			m_cboFacialFeatures.Text = objContent.m_strFACIALFEATURES;
			m_cboMouth.Text = objContent.m_strMOUTH;
			m_cboHeart.Text = objContent.m_strHEART;
			m_cboLung.Text = objContent.m_strLUNG;
			m_cboChest.Text = objContent.m_strCHEST;
			m_cboVein.Text = objContent.m_strVEIN;
			m_cboLiver.Text = objContent.m_strLIVER;
			m_cboSpleen.Text = objContent.m_strSPLEEN;
			m_cboHilum.Text = objContent.m_strHILUM;
			m_cboActivity.Text = objContent.m_strACTIVITY;
			m_cboArthrosis.Text = objContent.m_strARTHROSIS;
			m_cboAbnormality.Text = objContent.m_strABNORMALITY;
			m_cboGenitalia.Text = objContent.m_strGENITALIA;

			m_txtOtherRecord.m_mthSetNewText(objContent.m_strOTHERRECORD, objContent.m_strOTHERRECORDXML);

			m_txtWeight.Text = objContent.m_strWEIGHT;
			m_cboHead.Text = objContent.m_strHEAD;
			m_cboSkin.Text = objContent.m_strSKIN;
			m_cboHeart_OutHospital.Text = objContent.m_strHEART_OUTHOSPITAL;
			m_cboLung_OutHospital.Text = objContent.m_strLUNG_OUTHOSPITAL;
			m_cboGenitalia_OutHospital.Text = objContent.m_strGENITALIA_OUTHOSPITAL;
			m_cboAbdomen.Text = objContent.m_strABDOMEN;
			m_cboButtocks.Text = objContent.m_strBUTTOCKS;
			m_cboLimb.Text = objContent.m_strLIMB;
			m_cboNormalCircs.Text = objContent.m_strNORMALCIRCS;
			m_cboLactation.Text = objContent.m_strLACTATION;
			m_cboBcgVaccine.Text = objContent.m_strBCGVACCINE;
			m_cboBLiverBacterin.Text = objContent.m_strBLIVERBACTERIN;
            if (objContent.m_strCHECKEDCHANGE == "1")
            {
                m_rdbOutHospitalC.Checked = true;
            }
            else if (objContent.m_strCHECKEDCHANGE == "2")
            {
                m_rdbChangeDeptC.Checked = true;
            }
            else
            {
                m_rdbOutHospitalC.Checked = false;
                m_rdbChangeDeptC.Checked = false;
            }

            DateTime dtmInHospitalDate = MDIParent.s_ObjCurrentPatient.m_DtmLastInDate;
            DateTime dtmOutHospitalDate = MDIParent.s_ObjCurrentPatient.m_DtmLastOutDate;
            DateTime dtmOutHospitaldt =DateTime.MinValue;
            if (objContent.m_dtOUTHOSPITALDATE > DateTime.MinValue && objContent.m_dtOUTHOSPITALDATE != DateTime.Parse("1900-01-01 00:00:00"))
            {
                m_lblOutHospitalDate.Text = objContent.m_dtOUTHOSPITALDATE.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else if (dtmOutHospitalDate > DateTime.MinValue && dtmOutHospitalDate != DateTime.Parse("1900-01-01 00:00:00"))
            {
                m_lblOutHospitalDate.Text = dtmOutHospitalDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                m_lblOutHospitalDate.Text = "    年  月  日";
            }
            if (string.IsNullOrEmpty(objContent.m_strINHOSPITALDAYS))
            {
                if (DateTime.TryParse(m_lblOutHospitalDate.Text, out dtmOutHospitaldt))
                {
                    TimeSpan tmp = dtmOutHospitaldt - dtmInHospitalDate;
                    m_lblOutHospitalDays.Text = (tmp.Days + 1).ToString();
                }
                else
                {
                    TimeSpan tmp = DateTime.Now - dtmInHospitalDate;
                    m_lblOutHospitalDays.Text = (tmp.Days + 1).ToString();
                }
            }
            else
            {
                m_lblOutHospitalDays.Text = objContent.m_strINHOSPITALDAYS;
            }
			m_txtOtherCheck.m_mthSetNewText(objContent.m_strOTHERCHECK, objContent.m_strOTHERCHECKXML);

			m_txtOutHospitalAdvice.m_mthSetNewText(objContent.m_strOUTHOSPITALADVICE, objContent.m_strOUTHOSPITALADVICEXML);

			m_txtDealWith.m_mthSetNewText(objContent.m_strDEALWITH, objContent.m_strDEALWITHXML);
            DateTime dt = DateTime.Now;
            if (string.IsNullOrEmpty(objContent.m_dtmUMBILICALCORDLEFTTIME) && DateTime.TryParse(objContent.m_dtmUMBILICALCORDLEFTTIME.Trim(), out dt))
            {
                m_dtpUmbilicalCordLeftTime.Text = DateTime.Parse(objContent.m_dtmUMBILICALCORDLEFTTIME.Trim()).ToString("yyyy年MM月dd日");
            }
            else
            {
                m_dtpUmbilicalCordLeftTime.Text = objContent.m_dtmUMBILICALCORDLEFTTIME;
            }
			m_dtpCheckDate.Value = objContent.m_dtmCHECKDATE;
			m_dtpCreateDate.Value = objContent.m_dtmBIRTHTIME;
			
			m_objCurrentRecordContent = objContent;

            m_txtBedNO.Focus();
		}

		// 把选择时间记录内容重新整理为完全正确的内容。
		protected override void m_mthReAddNewRecord(clsInPatientCaseHistoryContent p_objRecordContent)
		{
		
		}		

		protected override void m_mthHandleAddRecordSucceed()
		{
			if(trvTime.SelectedNode != null)
				trvTime.SelectedNode.Tag =(string)m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") ;
		}

		//审核
		protected override string m_StrCurrentOpenDate
		{
			get
			{
                //if(this.trvTime.SelectedNode==null || this.trvTime.SelectedNode.Tag==null)
                //{
                //    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                //    return "";
                //}
                //return (string)this.trvTime.SelectedNode.Tag;
                if (string.IsNullOrEmpty(m_strCurrentOpenDate))
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                    return string.Empty;
                }
                return m_strCurrentOpenDate;
			}
		}

		protected override bool m_BlnCanApprove
		{
			get
			{
				return true;
			}
		}

		protected override void m_mthSetNewRecord()
		{
			if(m_objCurrentPatient != null)
			{			
				//签名默认值
                //clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtDoctorSign);
                //clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtCheckDocSign);
                MDIParent.m_mthSetDefaulEmployee(m_txtDoctorSign);
                MDIParent.m_mthSetDefaulEmployee(m_txtCheckDocSign);

				//默认值 m_IntCurCase
				new clsDefaultValueTool(this,m_objCurrentPatient).m_mthSetDefaultValue();				

				//设完默认值后回到光标床号
				m_txtBedNO.Focus();

			}
		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			clsNewBabyInRoomRecord objContent=new clsNewBabyInRoomRecord();
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue)
			{
				return ;
			}
		
			long lngRes=m_objDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString ("yyyy-MM-dd HH:mm:ss"),out objContent);
			if(lngRes<=0 || objContent==null)
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

			m_rdbSmoothBirth.Checked = objContent.m_strCHILDBEARING[0].ToString()=="1" ? true:false;
			m_rdbClampBirth.Checked = objContent.m_strCHILDBEARING[1].ToString() == "1" ? true:false;
			m_rdbSuctionBirth.Checked = objContent.m_strCHILDBEARING[2].ToString() == "1" ? true:false;
			m_rdbCaesareanBirth.Checked = objContent.m_strCHILDBEARING[3].ToString() == "1" ? true:false;
			m_rdbBreechDelivery.Checked = objContent.m_strCHILDBEARING[4].ToString() == "1" ? true:false;
			m_rdbBreechNature.Checked = objContent.m_strCHILDBEARING[5].ToString() == "1" ? true:false;
			m_rdbBreechHalf.Checked = objContent.m_strCHILDBEARING[6].ToString() == "1" ? true:false;
			m_rdbBreechTow.Checked = objContent.m_strCHILDBEARING[7].ToString() == "1" ? true:false;

			m_cboPregnantWeeks.Text = objContent.m_strPREGNANTTIME;
			m_cboReaction.Text = objContent.m_strREACTION;
			m_cboBabySex.Text = objContent.m_strBABYSEX;
			m_cboMuscleStrain.Text = objContent.m_strMUSCLESTRAIN;
			m_cboCryVoice.Text = objContent.m_strCRYVOICE;
			m_cboDropsy.Text = objContent.m_strDROPSY;
			m_cboColor.Text = objContent.m_strSKINCOLOR;
			m_cboElasticity.Text = objContent.m_strELASTICITY;
			m_cboIcterus.Text = objContent.m_strICTERUS;
			m_cboPigment.Text = objContent.m_strPIGMENT;
			m_cboPetechia.Text = objContent.m_strPETECHIA;
			m_txtBirthBurl.Text = objContent.m_strBIRTHBURL;
			m_txtHaematoma.Text = objContent.m_strHAEMATOMA;
			m_cboSkullSoft.Text = objContent.m_strSKULLSOFT;
			m_cboBoneSew.Text = objContent.m_strBONESEW;

			m_rdbFontanelOut.Checked = objContent.m_strFONTANEL[0].ToString() == "1" ? true:false;
			m_rdbFontanelSatiation.Checked = objContent.m_strFONTANEL[1].ToString() == "1" ? true:false;
			m_rdbFontanelLow.Checked = objContent.m_strFONTANEL[2].ToString() == "1" ? true:false;
			m_rdbFontanelFlat.Checked = objContent.m_strFONTANEL[3].ToString() == "1" ? true:false;

			m_txtHeadRound.Text = objContent.m_strHEADROUND;
			m_cboFacialFeatures.Text = objContent.m_strFACIALFEATURES;
			m_cboMouth.Text = objContent.m_strMOUTH;
			m_cboHeart.Text = objContent.m_strHEART;
			m_cboLung.Text = objContent.m_strLUNG;
			m_cboChest.Text = objContent.m_strCHEST;
			m_cboVein.Text = objContent.m_strVEIN;
			m_cboLiver.Text = objContent.m_strLIVER;
			m_cboSpleen.Text = objContent.m_strSPLEEN;
			m_cboHilum.Text = objContent.m_strHILUM;
			m_cboActivity.Text = objContent.m_strACTIVITY;
			m_cboArthrosis.Text = objContent.m_strARTHROSIS;
			m_cboAbnormality.Text = objContent.m_strABNORMALITY;
			m_cboGenitalia.Text = objContent.m_strGENITALIA;

			m_txtOtherRecord.Text = objContent.m_strOTHERRECORD;

			m_txtWeight.Text = objContent.m_strWEIGHT;
			m_cboHead.Text = objContent.m_strHEAD;
			m_cboSkin.Text = objContent.m_strSKIN;
			m_cboHeart_OutHospital.Text = objContent.m_strHEART_OUTHOSPITAL;
			m_cboLung_OutHospital.Text = objContent.m_strLUNG_OUTHOSPITAL;
			m_cboGenitalia_OutHospital.Text = objContent.m_strGENITALIA_OUTHOSPITAL;
			m_cboAbdomen.Text = objContent.m_strABDOMEN;
			m_cboButtocks.Text = objContent.m_strBUTTOCKS;
			m_cboLimb.Text = objContent.m_strLIMB;
			m_cboNormalCircs.Text = objContent.m_strNORMALCIRCS;
			m_cboLactation.Text = objContent.m_strLACTATION;
			m_cboBcgVaccine.Text = objContent.m_strBCGVACCINE;
			m_cboBLiverBacterin.Text = objContent.m_strBLIVERBACTERIN;

			m_txtOtherCheck.Text = objContent.m_strOTHERCHECK;

			m_txtOutHospitalAdvice.Text = objContent.m_strOUTHOSPITALADVICE;

			m_txtDealWith.Text = objContent.m_strDEALWITH;

            m_dtpUmbilicalCordLeftTime.Text = objContent.m_dtmUMBILICALCORDLEFTTIME;
			m_dtpCheckDate.Value = objContent.m_dtmCHECKDATE;
			m_dtpCreateDate.Value = objContent.m_dtmBIRTHTIME;

			m_txtDoctorSign.Text = objContent.m_strINROOMCHECKDOCName;
			m_txtCheckDocSign.Text = objContent.m_strRECORDSIGNDOCName;

            
            m_txtBedNO.Focus();
		}

		public	  override int m_IntFormID
		{
			get
			{
				return 82;
			}
		}

		protected new void m_mthSetSelectedRecord(clsPatient p_objPatient,
			string p_strRecordTime)
		{
			//检查参数
			if(p_objPatient==null || m_ObjCurrentEmrPatientSession == null)  
			{
				m_objCurrentRecordContent = null;
				return ;
			}

			clsBaseCaseHistoryInfo  objContent =null;  
			clsPictureBoxValue[] objPicValueArr = null;
			//获取记录

            long lngRes = m_objDomain.m_lngGetRecordContent(p_objPatient.m_StrInPatientID, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"),/*p_strRecordTime ,*/ out objContent, out objPicValueArr);
		
			if(lngRes <= 0 || objContent == null)
			{
				m_objCurrentRecordContent = null;
				return;                            
			}
			
			//设置记录时间     
			m_objCurrentRecordContent =(clsNewBabyInRoomRecord )objContent;

			m_mthSetGUIFromContent((clsNewBabyInRoomRecord )objContent);
			m_mthEnableModify(false);
		
			m_mthSetModifyControl((clsNewBabyInRoomRecord)objContent,false);			

		}

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
		protected void m_mthSetModifyControl(clsNewBabyInRoomRecord p_objRecordContent,
			bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制，由子窗体重载实现
			if(p_blnReset==true)
			{
				m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
				m_mthSetRichTextCanModifyLast(this,true);
			}
			else if(p_objRecordContent!=null)
			{
				m_mthSetRichTextModifyColor(this,Color.Red);
				m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID));
			}

		}


		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>
		private void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor)
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().FullName;			
			if(strTypeName=="com.digitalwave.Utility.Controls.ctlRichTextBox")			
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			else if(strTypeName=="com.digitalwave.controls.ctlRichTextBox")
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			
			if(p_ctlControl.HasChildren && strTypeName !="System.Windows.Forms.DataGrid" )
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
			string strTypeName = p_ctlControl.GetType().FullName;			
			if(strTypeName=="com.digitalwave.Utility.Controls.ctlRichTextBox")
			{				
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			else if(strTypeName=="com.digitalwave.controls.ctlRichTextBox")
			{
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="System.Windows.Forms.DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}	
	
		protected new long m_lngAddNewRecord()
		{
			//检查当前病人变量是否为null
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)
				return (long)enmOperationResult .Parameter_Error;

			//获取服务器时间
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			
			//从界面获取记录信息
			clsNewBabyInRoomRecord  objContent = m_objGetContentFromGUI();     
		           
			//获取画图信息
			clsPictureBoxValue [] objPicValueArr = m_objGetPicContentFromGUI();

			string strDiseaseID = "";
			//界面输入值出错
			if(objContent == null)
				return (long)enmOperationResult.Parameter_Error;
					
			//设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
			string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			objContent.m_bytIfConfirm =0;
			objContent.m_bytStatus =0;
            objContent.m_dtmInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
			objContent.m_dtmModifyDate =DateTime.Parse(strNow); 
			objContent.m_dtmOpenDate =DateTime.Parse(strNow); 
			objContent.m_strCreateUserID =MDIParent.strOperatorID;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strModifyUserID =MDIParent.strOperatorID;
			objContent.m_dtmCreateDate=DateTime.Parse(strNow);
			 
			//保存记录
			clsPreModifyInfo p_objModifyInfo=null;

			long lngRes = m_objDomain.m_lngAddNewRecord(objContent,objPicValueArr,strDiseaseID,m_ObjCurrentEmrPatientSession.m_strDeptId, out p_objModifyInfo);
		     
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
			
					if((enmOperationResult)lngRes == enmOperationResult.DB_Succeed)
					{
						m_objCurrentRecordContent = objContent; 
					
						m_mthHandleAddRecordSucceed();

						//this.m_dtpCheckDate.Enabled=false;
					}
					
					break;   
					//...
				case enmOperationResult.Record_Already_Exist:
					m_mthShowRecordTimeDouble();
					return lngRes;
			}  
			this.trvTime.ExpandAll();
			//返回结果
			return lngRes;
		}



		protected override long m_lngSubModify()
		{
			if(trvTime.Nodes[0].Nodes.Count>0 && trvTime.SelectedNode !=trvTime.Nodes[0].FirstNode)
				return 1;//窗体只读。
			//检查当前病人变量是否为null
			if(m_objCurrentPatient ==null)
				return (long)enmOperationResult .Parameter_Error ;
			//获取服务器时间
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			//从界面获取记录信息
			clsNewBabyInRoomRecord  objContent = m_objGetContentFromGUI();     

			//获取画图信息
			clsPictureBoxValue [] objPicValueArr = m_objGetPicContentFromGUI();

			//获取病名
			string strDiseaseID = "";
		           
			//界面输入值出错           
			if(objContent == null)
				return (long)enmOperationResult .Parameter_Error;
		
			//设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmModifyDate）
			objContent.m_bytIfConfirm =0;
			objContent.m_bytStatus =0;
			objContent.m_dtmInPatientDate =m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmModifyDate =DateTime.Parse(m_objPDomain.m_strGetServerTime()); 
			objContent.m_dtmCreateDate=m_objCurrentRecordContent.m_dtmCreateDate;
			objContent.m_strCreateUserID =MDIParent.strOperatorID;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strModifyUserID =MDIParent.strOperatorID;

			//设置已有记录的开始使用时间
			objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate ;

			clsPreModifyInfo m_objModifyInfo;
			long lngRes = m_objDomain.m_lngModifyRecord(m_objCurrentRecordContent,objContent,objPicValueArr,strDiseaseID,m_ObjCurrentEmrPatientSession.m_strDeptId, out m_objModifyInfo);
		        
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:

					if((enmOperationResult)lngRes == enmOperationResult.DB_Succeed)
					{
						m_objCurrentRecordContent = objContent;	
					}
					break;   
					//...
			}  
			//展开树显示所有时间节点。
			//			trvTime.ExpandAll();
			//返回结果
			return lngRes;
		}	

		protected override long m_lngSubDelete()
		{
			//检查当前病人变量是否为null  
			if(m_objCurrentPatient ==null || m_ObjCurrentEmrPatientSession == null)
			{
				clsPublicFunction.ShowInformationMessageBox("未选定病人,无法删除!");//崔汉瑜，2003-5-27
				return (long)enmOperationResult.Parameter_Error; 
			}
			//检查当前记录是否为null
			if(m_objCurrentRecordContent==null)
			{
				clsPublicFunction.ShowInformationMessageBox("当前记录内容为空,无法删除!");//崔汉瑜，2003-5-27
				return (long)enmOperationResult.Parameter_Error; 
			}
			//获取服务器时间      
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			
			//删除记录
			clsNewBabyInRoomRecord objContent=m_objGetContentFromGUI();
			objContent.m_bytStatus =0;
			objContent.m_dtmCreateDate=m_objCurrentRecordContent.m_dtmCreateDate;
            objContent.m_dtmInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strDeActivedOperatorID =MDIParent.OperatorID ;
			objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate ;  
			
			//设置 m_objCurrentRecordContent 的信息（使用服务器时间设置m_dtmDeActivedDate）
			objContent.m_dtmDeActivedDate =DateTime.Parse(m_objPDomain.m_strGetServerTime()); 
			
			clsPreModifyInfo m_objModifyInfo=null;

			long lngRes = m_objDomain.m_lngDeleteRecord(objContent,out m_objModifyInfo);
		
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					//清空记录信息   
					
					m_objCurrentRecordContent = null;       
					m_mthClearPatientRecordInfo();
					//选中根节点
					m_blnCanTreeAfterSelect = false;
					m_mthUnEnableRichTextBox();  
					m_blnCanTreeAfterSelect = true;

                    m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession,0);
					break;   
					//...
			}  
		
			//返回结果
			return lngRes;
		}

		// 作废重做的数据库保存。
		protected new long m_lngReAddNew()
		{
			//检查当前病人变量是否为null
		
			//获取服务器时间
		
			//从界面获取记录信息
			clsNewBabyInRoomRecord objContent = m_objGetContentFromGUI();     
		           
			//界面输入值出错           
			if(objContent == null)
				return -1;
			clsPreModifyInfo m_objModifyInfo=null;
			long lngRes = m_objDomain.m_lngReAddNewRecord(m_objReAddNewOld,objContent,out m_objModifyInfo);
			
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					m_objCurrentRecordContent = objContent;  
					m_objReAddNewOld = null;
					break;   
					//...
			}  
		
			//返回结果
			return lngRes;

		}

		/// <summary>
		/// 输入框内，内容颜色的设置方法
		/// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
		/// 否则，不可修改
		/// </summary>
		/// <returns></returns>
		private bool m_blnGetCanModifyLast(string p_strModifyUserID)
		{			
			if(p_strModifyUserID==null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
			else 
				return false;
		}

		protected override void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(!m_blnCanTreeAfterSelect)
				return;

			m_mthRecordChangedToSave();

			try
			{
				DateTime dtInDate = DateTime.Parse(trvTime.SelectedNode.Text);
				m_mthClearRecordInfo();

                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrHISInPatientID;
                DateTime dtmEMRInDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_DtmEMRInDate;
                string strEMRInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrEMRInPatientID;

                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(trvTime.SelectedNode.Text);
                m_objCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;

                if (string.IsNullOrEmpty(m_objBaseCurrentPatient.m_StrRegisterId))
                {
                    string strRegisterID = string.Empty;
                    long lngRes = new clsPublicDomain().m_lngGetRegisterID(m_objCurrentPatient.m_StrPatientID, Convert.ToDateTime(trvTime.SelectedNode.Text).ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                }
                m_mthIsReadOnly();

                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				m_mthEnableRichTextBox();
                //m_dtpInHospitalDate.Value = (m_objCurrentPatient.m_DtmSelectedOutDate == DateTime.MinValue || m_objCurrentPatient.m_DtmSelectedOutDate
                //    == Convert.ToDateTime("1900-01-01 00:00:00")) ? DateTime.Now : m_objCurrentPatient.m_DtmSelectedOutDate;
				m_mthSetSelectedRecord(m_objCurrentPatient,(string)this.trvTime.SelectedNode.Tag );
				if(m_objCurrentRecordContent!=null)
				{
					this.m_dtpCreateDate.Enabled=true;

					//当前处于修改记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
				}
				else
				{
					m_mthSetNewRecord();
					//当前处于新增记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				}
			}
			catch (Exception exp)
			{
				string strtemp=exp.Message;
				m_mthClearRecordInfo();

				m_mthUnEnableRichTextBox();

				m_objCurrentRecordContent =null;
				m_mthEnableModify(true);
				this.m_dtpCreateDate.Enabled =true;
				this.m_dtpCreateDate.Text =DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");  
				
				m_mthSetNullPrintContext();

				//当前处于禁止输入状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.None );
			}
			finally
			{
				m_mthDoAfterSelect();
				m_mthAddFormStatusForClosingSave();
			}
		}

		/// <summary>
		/// 选择树节点后的操作
		/// </summary>
		protected override void m_mthDoAfterSelect()
		{
			object [][] objDataArr;
			clsNewBabyCircsRecord[] objCircsRecordArr;
			DateTime dtSelectedInPatientDate = DateTime.MinValue;
            //try
            //{
            //    dtSelectedInPatientDate = DateTime.Parse(trvTime.SelectedNode.Text.Trim());
            //}
            //catch
            //{
            //    m_dtbRecords.Clear();
            //    return;
            //}
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }

			long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text,out objCircsRecordArr);
			objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

			m_dtbRecords.Clear();
			if(objDataArr == null)
				return;
			for(int j2=0;j2<objDataArr.Length;j2++)
			{
				m_dtbRecords.Rows.Add(objDataArr[j2]);	
			}
		}

		/// <summary>
		/// 添加记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
			if(m_objReAddNewOld != null)
				return m_lngReAddNew();
			else  
				return m_lngAddNewRecord();
		

		}

		/// <summary>
		/// 是否是添加新记录的操作。true，添加新记录；false,修改记录
		/// </summary>
		protected override bool m_BlnIsAddNew
		{
			get
			{
				return m_objCurrentRecordContent == null;
			}
		}

		/// <summary>
		/// 获取痕迹保留
		/// </summary>
		/// <param name="p_strText"></param>
		/// <param name="p_strModifyUserID"></param>
		/// <param name="p_strModifyUserName"></param>
		/// <returns></returns>
		private string m_strGetDSTTextXML(string p_strText,string p_strModifyUserID,string p_strModifyUserName)
		{
			return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText,p_strModifyUserID,p_strModifyUserName,Color.Black,Color.White);
		}

		private DataTable m_dtbTempTable;
		private DateTime m_dtmPreRecordDate;
		private object[][] m_objGetRecordsValueArr(clsNewBabyCircsRecord[] p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{
				object[] objData;
				ArrayList objReturnData=new ArrayList();
				m_dtmPreRecordDate = DateTime.MinValue;
		
				com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				if(p_objTransDataInfo == null)
					return null;

				int intRecordCount = p_objTransDataInfo.Length;

				for(int i=0; i<intRecordCount; i++)
				{
					clsNewBabyCircsRecord objCurrent = p_objTransDataInfo[i];
					clsNewBabyCircsRecord objNext = new clsNewBabyCircsRecord();//下一条记录
					if(i < intRecordCount-1)
						objNext = p_objTransDataInfo[i+1];
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate)
                    {
                        continue;
                    }

					#region 存放关键字段
                    objData = new object[22];   
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						objData[2] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
                        
						if(objCurrent.m_dtmRecordDate.ToString("yyyy-MM-dd HH:mm") != m_dtmPreRecordDate.ToString("yyyy-MM-dd HH:mm"))
						{
							objData[3] = objCurrent.m_dtmRecordDate.ToString("yyyy-MM-dd HH:mm") ;//日期字符串
						}
					}
					m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;	
					#endregion ;

					#region 存放单项信息
					//出生天数
					objData[4] = objCurrent.m_strBIRTHDAYS;

					//头>>产瘤
					strText = objCurrent.m_strBIRTHBURL;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBIRTHBURL != objCurrent.m_strBIRTHBURL)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBIRTHBURL ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[5] = objclsDSTRichTextBoxValue;

					//头>>血肿
					strText = objCurrent.m_strHAEMATOMA;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strHAEMATOMA != objCurrent.m_strHAEMATOMA)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strHAEMATOMA ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;

					//头>>前囟
					strText = objCurrent.m_strFONTANEL;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strFONTANEL != objCurrent.m_strFONTANEL)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strFONTANEL ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[7] = objclsDSTRichTextBoxValue;

					//眼>>结膜充血
					strText = objCurrent.m_strCONJUNCTIVA;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCONJUNCTIVA != objCurrent.m_strCONJUNCTIVA)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCONJUNCTIVA ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[8] = objclsDSTRichTextBoxValue;

					//眼>>分泌物
					strText = objCurrent.m_strSECRETION;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSECRETION != objCurrent.m_strSECRETION)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSECRETION ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[9] = objclsDSTRichTextBoxValue;

					//口>>咽充血
					strText = objCurrent.m_strPHARYNX;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPHARYNX != objCurrent.m_strPHARYNX)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPHARYNX ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[10] = objclsDSTRichTextBoxValue;

					//口>>白点
					strText = objCurrent.m_strWHITEPOINT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strWHITEPOINT != objCurrent.m_strWHITEPOINT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strWHITEPOINT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[11] = objclsDSTRichTextBoxValue;

					//皮肤>>黄疸
					strText = objCurrent.m_strICTERUS;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strICTERUS != objCurrent.m_strICTERUS)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strICTERUS ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[12] = objclsDSTRichTextBoxValue;

					//皮肤>>脓疮
					strText = objCurrent.m_strFESTER;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strFESTER != objCurrent.m_strFESTER)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strFESTER ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[13] = objclsDSTRichTextBoxValue;

					//脐>>出血
					strText = objCurrent.m_strBLEEDING;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBLEEDING != objCurrent.m_strBLEEDING)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBLEEDING ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[14] = objclsDSTRichTextBoxValue;

					//脐>>发炎
					strText = objCurrent.m_strAGNAIL;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strAGNAIL != objCurrent.m_strAGNAIL)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strAGNAIL ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[15] = objclsDSTRichTextBoxValue;

					//臀>>红
					strText = objCurrent.m_strREDSTERN;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strREDSTERN != objCurrent.m_strREDSTERN)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strREDSTERN ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[16] = objclsDSTRichTextBoxValue;

					//臀>>皮肤
					strText = objCurrent.m_strSTERNSKIN;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSTERNSKIN != objCurrent.m_strSTERNSKIN)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSTERNSKIN ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[17] = objclsDSTRichTextBoxValue;

					//心肺
					strText = objCurrent.m_strHEARTLUNG;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strHEARTLUNG != objCurrent.m_strHEARTLUNG)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strHEARTLUNG ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[18] = objclsDSTRichTextBoxValue;

					//腹部
					strText = objCurrent.m_strABDOMEN;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strABDOMEN != objCurrent.m_strABDOMEN)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strABDOMEN ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[19] = objclsDSTRichTextBoxValue;

					//备注
					strText = objCurrent.m_strREMARK;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strREMARK != objCurrent.m_strREMARK)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strREMARK ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[20] = objclsDSTRichTextBoxValue;

					//签名	
					objData[21] = objCurrent.m_strSignUserName;

					objReturnData.Add(objData);
					#endregion
				}
				object[][] m_objRe=new object[objReturnData.Count][];

				for(int m=0;m<objReturnData.Count ;m++)
					m_objRe[m]=(object[])objReturnData[m];
				return m_objRe;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );
				return null;
			}
			#endregion
		}

		/// <summary>
		/// 添加数据到DataTable
		/// </summary>
		/// <param name="p_objDataArr"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected void m_mthAddDataToDataTable(object[][] p_objDataArr,
			DateTime p_dtmCreateRecordTime)
		{
			//查找插入点
			//循环DataTable的记录，获取记录的日期（第一字段）
			//如果有记录日期
			//比较已有日期与p_dtmCreateDate
			//如果已有日期比p_dtmCreateDate大
			//在这行记录前添加记录（数组），返回
		
			//没有找到比p_dtmCreateDate大的日期，往DataTable后添加	
			if(p_objDataArr==null)
				return;
			m_dtbRecords.Clear();
			int m_intInsertIndex = -1;
			string m_strRecordTime = null;
			DataRow m_dtrNewRow;
			for(int i1=0;i1<m_dtbRecords.Rows.Count;i1++)
			{
				if(m_dtbRecords.Rows[i1][0].ToString() != "")
				{
					m_strRecordTime = m_dtbRecords.Rows[i1][0].ToString();
					if(DateTime.Parse(m_strRecordTime) > p_dtmCreateRecordTime)
					{
						m_intInsertIndex = i1;
						break;
					}
				}
			}
			if(m_intInsertIndex < 0)//没有找到比p_dtmOpenRecordTime大的日期，往DataTable后添加		
			{
				for(int i1=0;i1<p_objDataArr.Length;i1++)
				{				
					m_dtbRecords.Rows.Add(p_objDataArr[i1]);
				}
			}
			else//否则，将p_dtmCreateDate 之后的记录放到内存中,先添加新增的记录，然后把内存中的记录，再添加回去
			{
				if(m_dtbTempTable == null)
				{
					m_dtbTempTable = m_dtbRecords.Clone();
				}
				while((m_intInsertIndex < m_dtbRecords.Rows.Count))//将p_dtmCreateDate 之后的记录放到内存中
				{
					m_mthSetDataGridFirstRowFocus();
					m_dtrNewRow = m_dtbTempTable.NewRow();
					m_dtrNewRow.ItemArray = m_dtbRecords.Rows[m_intInsertIndex].ItemArray;
					m_dtbTempTable.Rows.Add(m_dtrNewRow);
					m_dtbRecords.Rows.RemoveAt(m_intInsertIndex);
				}
				for(int i1=0;i1<p_objDataArr.Length;i1++)//新增的记录
				{
					m_dtrNewRow = m_dtbRecords.NewRow();
					m_dtrNewRow.ItemArray = p_objDataArr[i1];
					m_dtbRecords.Rows.Add(m_dtrNewRow);
				}
				for(int i1=0;i1<m_dtbTempTable.Rows.Count;i1++)//把内存中的记录，再添加回去
				{
					m_dtrNewRow = m_dtbRecords.NewRow();
					m_dtrNewRow.ItemArray = m_dtbTempTable.Rows[i1].ItemArray;
					m_dtbRecords.Rows.Add(m_dtrNewRow);
				}
				if(m_dtbTempTable != null)
				{
					m_dtbTempTable.Rows.Clear();
				}
			}
		}

		/// <summary>
		/// 使得DataGrid的第一行获得焦点
		/// </summary>
		protected void m_mthSetDataGridFirstRowFocus()
		{
			m_dtgRecord.CurrentCell = new DataGridCell(m_dtbRecords.Rows.Count,0);
		}

		protected override long m_lngSubPrint()
		{
			m_mthPrintRecord();
			return 1;
		}

		private clsNewBabyInRoomPrintTool objPrintTool;
		private void m_mthPrintRecord()
		{
			objPrintTool=new clsNewBabyInRoomPrintTool();
			objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                DateTime dtmTemp = DateTime.MinValue;
                if (!DateTime.TryParse(m_strCurrentOpenDate,out dtmTemp))
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.Parse(m_strCurrentOpenDate));
            }							
			objPrintTool.m_mthInitPrintContent();		
			
			m_mthStartPrint();
		}

		protected override void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			objPrintTool.m_mthPrintPage(e);

			if(ppdPrintPreview != null)
				while(!ppdPrintPreview.m_blnHandlePrint(e))
					objPrintTool.m_mthPrintPage(e);
		}

		protected override void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthBeginPrint(e);				
		}

		protected override void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthEndPrint(e);
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null)
                return;

            m_mthRecordChangedToSave();

            try
            {
                DateTime dtInDate = p_objSelectedSession.m_dtmHISInpatientDate;
                m_mthClearRecordInfo();

                DateTime dtmEMRInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                string strEMRInPatientID = p_objSelectedSession.m_strEMRInpatientId;

                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = dtInDate;
                m_objCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;

                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

                m_mthIsReadOnly();

                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                m_mthEnableRichTextBox();
                //m_dtpInHospitalDate.Value = (p_objSelectedSession.m_dtmOutDate == DateTime.MinValue || p_objSelectedSession.m_dtmOutDate == Convert.ToDateTime("1900-01-01 00:00:00")) ? DateTime.Now : p_objSelectedSession.m_dtmOutDate;
                m_mthSetSelectedRecord(m_objCurrentPatient, string.Empty);
                if (m_objCurrentRecordContent != null)
                {
                    this.m_dtpCreateDate.Enabled = true;

                    //当前处于修改记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);
                }
                else
                {
                    m_mthSetNewRecord();
                    //当前处于新增记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
                }
            }
            catch (Exception exp)
            {
                string strtemp = exp.Message;
                m_mthClearRecordInfo();

                m_mthUnEnableRichTextBox();

                m_objCurrentRecordContent = null;
                m_mthEnableModify(true);
                this.m_dtpCreateDate.Enabled = true;
                this.m_dtpCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");

                m_mthSetNullPrintContext();

                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
            }
            finally
            {
                m_mthDoAfterSelect();
                m_mthAddFormStatusForClosingSave();
            }
        }

        private void m_rdbOutHospitalC_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbOutHospitalC.Checked)
            {
                label43.Text = "出院日期：";
                label60.Text = "出院医嘱：";

            }
        }

        private void m_rdbChangeDeptC_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbChangeDeptC.Checked)
            {
                label43.Text = "转科日期：";
                label60.Text = "转科医嘱：";
            }
        }
	}
}
