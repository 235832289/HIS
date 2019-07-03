using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using Crownwood.Magic.Menus;

namespace iCare
{
	/// <summary>
	/// 住院病历评分
	/// </summary>
	public class frmCaseGrade : iCare.frmHRPBaseForm,PublicFunction
    {
        public static bool s_blnIsBas = true; 
		private clsCaseGradeDomain m_objDomain;
		private clsCaseGradeValue m_objCurrentRecord;
		
		private ArrayList m_arlItems = new ArrayList();
		#region Define 
		private Crownwood.Magic.Controls.TabControl m_tabMain;
		private Crownwood.Magic.Controls.TabPage tbp1st;
		private System.Windows.Forms.Label label1;
		private Crownwood.Magic.Controls.TabPage tbpInPatientRec;
		private System.Windows.Forms.Label label2;
		private Crownwood.Magic.Controls.TabPage tbpDiseaseTrack;
		private Crownwood.Magic.Controls.TabPage tbpOutHospital;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Panel pnlDiseaseTrack1;
		private System.Windows.Forms.Label label116;
		private System.Windows.Forms.Label label117;
		private System.Windows.Forms.Label label118;
		private System.Windows.Forms.Label label119;
		private System.Windows.Forms.Label label120;
		private System.Windows.Forms.Label label121;
		private System.Windows.Forms.Label label122;
		private System.Windows.Forms.Label label123;
		private System.Windows.Forms.Label label124;
		private System.Windows.Forms.Label label125;
		private System.Windows.Forms.Label label126;
		private System.Windows.Forms.Label label127;
		private System.Windows.Forms.Label label128;
		private System.Windows.Forms.Label label129;
		private System.Windows.Forms.Label label130;
		private System.Windows.Forms.Label label131;
		private System.Windows.Forms.Label label132;
		private System.Windows.Forms.Label label133;
		private System.Windows.Forms.Label label134;
		private System.Windows.Forms.Label label135;
		private System.Windows.Forms.Label label136;
		private System.Windows.Forms.Label label137;
		private System.Windows.Forms.Label label138;
		private System.Windows.Forms.Label label139;
		private System.Windows.Forms.Label label140;
		private System.Windows.Forms.Label label141;
		private System.Windows.Forms.Label label142;
		private System.Windows.Forms.Label label143;
		private System.Windows.Forms.Label label144;
		private System.Windows.Forms.Label label145;
		private System.Windows.Forms.Label label146;
		private System.Windows.Forms.Label label147;
		private System.Windows.Forms.Label label148;
		private System.Windows.Forms.Label label149;
		private System.Windows.Forms.Label label150;
		private System.Windows.Forms.Label label151;
		private System.Windows.Forms.Label label152;
		private System.Windows.Forms.Label label163;
		private System.Windows.Forms.Panel pnlDiseaseTrack2;
		private System.Windows.Forms.Label label165;
		private System.Windows.Forms.Label label166;
		private System.Windows.Forms.Label label167;
		private System.Windows.Forms.Label label168;
		private System.Windows.Forms.Label label169;
		private System.Windows.Forms.Label label170;
		private System.Windows.Forms.Label label171;
		private System.Windows.Forms.Label label172;
		private System.Windows.Forms.Label label173;
		private System.Windows.Forms.Label label174;
		private System.Windows.Forms.Label label175;
		private System.Windows.Forms.Label label176;
		private System.Windows.Forms.Label label177;
		private System.Windows.Forms.Label label178;
		private System.Windows.Forms.Label label179;
		private System.Windows.Forms.Label label180;
		private System.Windows.Forms.Label label181;
		private System.Windows.Forms.Label label182;
		private System.Windows.Forms.Label label183;
		private System.Windows.Forms.Label label184;
		private System.Windows.Forms.Label label185;
		private System.Windows.Forms.Label label186;
		private System.Windows.Forms.Label label187;
		private System.Windows.Forms.Label label188;
		private System.Windows.Forms.Label label189;
		private System.Windows.Forms.Label label190;
		private System.Windows.Forms.Label label191;
		private System.Windows.Forms.Label label192;
		private System.Windows.Forms.Label label193;
		private System.Windows.Forms.Label label194;
		private System.Windows.Forms.Label label195;
		private System.Windows.Forms.Label label196;
		private System.Windows.Forms.Label label197;
		private System.Windows.Forms.Label label198;
		private System.Windows.Forms.Label label199;
		private System.Windows.Forms.Label label200;
		private System.Windows.Forms.Label label201;
		private System.Windows.Forms.Label label202;
		private System.Windows.Forms.TextBox m_txtMainResult;
		private System.Windows.Forms.TextBox m_txtInPatResult;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne1;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne2;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne3;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne4;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne7;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne5;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne8;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne6;
		private System.Windows.Forms.TextBox m_txtOutResult;
		private System.Windows.Forms.TextBox m_txtDiseaseResult;
		private System.Windows.Forms.RadioButton m_rdbOne;
		private System.Windows.Forms.RadioButton m_rdbTwo;
		private System.Windows.Forms.TextBox m_txtDiseaseOne1;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne11;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne14;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne16;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne13;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne15;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne9;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne12;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne10;
		private System.Windows.Forms.TextBox m_txtDiseaseOne2;
		private System.Windows.Forms.TextBox m_txtDiseaseOne4;
		private System.Windows.Forms.TextBox m_txtDiseaseOne3;
		private System.Windows.Forms.TextBox m_txtDiseaseOne8;
		private System.Windows.Forms.TextBox m_txtDiseaseOne7;
		private System.Windows.Forms.TextBox m_txtDiseaseOne6;
		private System.Windows.Forms.TextBox m_txtDiseaseOne5;
		private System.Windows.Forms.TextBox m_txtDiseaseOne12;
		private System.Windows.Forms.TextBox m_txtDiseaseOne11;
		private System.Windows.Forms.TextBox m_txtDiseaseOne10;
		private System.Windows.Forms.TextBox m_txtDiseaseOne15;
		private System.Windows.Forms.TextBox m_txtDiseaseOne14;
		private System.Windows.Forms.TextBox m_txtDiseaseOne13;
		private System.Windows.Forms.TextBox m_txtDiseaseOne9;
		private System.Windows.Forms.TextBox m_txtDiseaseOne16;
		private System.Windows.Forms.CheckBox m_chkDiseaseOne17;
		private System.Windows.Forms.TextBox m_txtDiseaseOne17;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo1;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo1;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo2;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo3;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo4;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo7;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo5;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo8;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo6;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo11;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo14;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo16;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo13;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo15;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo9;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo12;
		private System.Windows.Forms.CheckBox m_chkDiseaseTwo10;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo2;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo4;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo3;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo8;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo7;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo6;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo5;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo12;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo11;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo10;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo15;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo14;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo13;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo9;
		private System.Windows.Forms.TextBox m_txtDiseaseTwo16;
		public System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.LinkLabel m_lklCalDisease;
		private System.Windows.Forms.LinkLabel m_lklCalOutResult;
		private System.Windows.Forms.LinkLabel m_lklCalInPatResult;
		private System.Windows.Forms.LinkLabel m_lklMainResult;
		private System.Windows.Forms.Label m_lblInPatGeade;
		private System.Windows.Forms.Label m_lblMainGrade;
		private System.Windows.Forms.Label m_lblDisGrade;
		private Crownwood.Magic.Controls.TabPage tbpResult;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.Label label95;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.Label m_lblRePatientName;
		private System.Windows.Forms.Label label97;
		private System.Windows.Forms.Label m_lblReInpatientID;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.TextBox m_txtAllResult;
		private System.Windows.Forms.Label label101;
		private System.Windows.Forms.Label m_lblReason;
		private System.Windows.Forms.Label label99;
		private System.Windows.Forms.Label label100;
		private System.Windows.Forms.Panel pnlMainGrade;
		private System.Windows.Forms.TextBox m_txtGrade1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox m_chkMain1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox m_chkMain2;
		private System.Windows.Forms.CheckBox m_chkMain3;
		private System.Windows.Forms.CheckBox m_chkMain4;
		private System.Windows.Forms.CheckBox m_chkMain7;
		private System.Windows.Forms.CheckBox m_chkMain5;
		private System.Windows.Forms.CheckBox m_chkMain8;
		private System.Windows.Forms.CheckBox m_chkMain6;
		private System.Windows.Forms.CheckBox m_chkMain11;
		private System.Windows.Forms.CheckBox m_chkMain13;
		private System.Windows.Forms.CheckBox m_chkMain15;
		private System.Windows.Forms.CheckBox m_chkMain9;
		private System.Windows.Forms.CheckBox m_chkMain12;
		private System.Windows.Forms.CheckBox m_chkMain10;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox m_txtGrade2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox m_txtGrade4;
		private System.Windows.Forms.TextBox m_txtGrade3;
		private System.Windows.Forms.TextBox m_txtGrade8;
		private System.Windows.Forms.TextBox m_txtGrade7;
		private System.Windows.Forms.TextBox m_txtGrade6;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox m_txtGrade5;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox m_txtGrade12;
		private System.Windows.Forms.TextBox m_txtGrade11;
		private System.Windows.Forms.TextBox m_txtGrade10;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox m_txtGrade15;
		private System.Windows.Forms.TextBox m_txtGrade14;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox m_txtGrade13;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox m_txtGrade9;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox m_txtGrade16;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Panel pnlInPatientGeade;
		private System.Windows.Forms.TextBox m_txtInPatient1;
		private System.Windows.Forms.CheckBox m_chkInPatient1;
		private System.Windows.Forms.CheckBox m_chkInPatient2;
		private System.Windows.Forms.CheckBox m_chkInPatient3;
		private System.Windows.Forms.CheckBox m_chkInPatient4;
		private System.Windows.Forms.CheckBox m_chkInPatient7;
		private System.Windows.Forms.CheckBox m_chkInPatient5;
		private System.Windows.Forms.CheckBox m_chkInPatient8;
		private System.Windows.Forms.CheckBox m_chkInPatient6;
		private System.Windows.Forms.CheckBox m_chkInPatient11;
		private System.Windows.Forms.CheckBox m_chkInPatient14;
		private System.Windows.Forms.CheckBox m_chkInPatient16;
		private System.Windows.Forms.CheckBox m_chkInPatient13;
		private System.Windows.Forms.CheckBox m_chkInPatient15;
		private System.Windows.Forms.CheckBox m_chkInPatient9;
		private System.Windows.Forms.CheckBox m_chkInPatient12;
		private System.Windows.Forms.CheckBox m_chkInPatient10;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox m_txtInPatient2;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.TextBox m_txtInPatient4;
		private System.Windows.Forms.TextBox m_txtInPatient3;
		private System.Windows.Forms.TextBox m_txtInPatient8;
		private System.Windows.Forms.TextBox m_txtInPatient7;
		private System.Windows.Forms.TextBox m_txtInPatient6;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.TextBox m_txtInPatient5;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.TextBox m_txtInPatient12;
		private System.Windows.Forms.TextBox m_txtInPatient11;
		private System.Windows.Forms.TextBox m_txtInPatient10;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.TextBox m_txtInPatient15;
		private System.Windows.Forms.TextBox m_txtInPatient14;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.TextBox m_txtInPatient13;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.TextBox m_txtInPatient9;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.TextBox m_txtInPatient16;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.CheckBox m_chkInPatient18;
		private System.Windows.Forms.CheckBox m_chkInPatient20;
		private System.Windows.Forms.CheckBox m_chkInPatient17;
		private System.Windows.Forms.CheckBox m_chkInPatient19;
		private System.Windows.Forms.Label label154;
		private System.Windows.Forms.Label label155;
		private System.Windows.Forms.TextBox m_txtInPatient19;
		private System.Windows.Forms.TextBox m_txtInPatient18;
		private System.Windows.Forms.Label label156;
		private System.Windows.Forms.Label label157;
		private System.Windows.Forms.TextBox m_txtInPatient17;
		private System.Windows.Forms.Label label158;
		private System.Windows.Forms.Label label159;
		private System.Windows.Forms.TextBox m_txtInPatient20;
		private System.Windows.Forms.Label label160;
		private System.Windows.Forms.Label label161;
		private System.Windows.Forms.Panel pnlOutGrade;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.CheckBox m_chkOutHos1;
		private System.Windows.Forms.CheckBox m_chkOutHos2;
		private System.Windows.Forms.CheckBox m_chkOutHos4;
		private System.Windows.Forms.CheckBox m_chkOutHos3;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.TextBox m_txtOutHos1;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.TextBox m_txtOutHos2;
		private System.Windows.Forms.TextBox m_txtOutHos4;
		private System.Windows.Forms.TextBox m_txtOutHos3;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.Label label107;
		private System.Windows.Forms.Label label110;
		private System.Windows.Forms.Label label113;
		private System.Windows.Forms.Label label114;
		private System.Windows.Forms.CheckBox m_chkOutHos5;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.TextBox m_txtOutHos5;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.Label m_lblOutgrade;
		private System.Windows.Forms.Label m_lblNotify;
		private System.Windows.Forms.Label label39;
		private PinkieControls.ButtonXP m_cmdDisPlayResult;
		private System.Windows.Forms.CheckBox m_chkMain14;
		private System.Windows.Forms.CheckBox m_chkMain16;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabPage tbpCheck;
		private Crownwood.Magic.Controls.TabPage tbpBasis;
		private Crownwood.Magic.Controls.TabPage tbpAgree;
		private System.Windows.Forms.Label label102;
		private System.Windows.Forms.Label label103;
		private System.Windows.Forms.CheckBox m_chkCheck1;
		private System.Windows.Forms.CheckBox m_chkCheck2;
		private System.Windows.Forms.Label label104;
		private System.Windows.Forms.Label label105;
		private System.Windows.Forms.Label label106;
		private System.Windows.Forms.TextBox m_txtCheck1;
		private System.Windows.Forms.Label label108;
		private System.Windows.Forms.TextBox m_txtCheck2;
		private System.Windows.Forms.Label label153;
		private System.Windows.Forms.Label label162;
		private System.Windows.Forms.CheckBox m_chkCheck3;
		private System.Windows.Forms.Label label164;
		private System.Windows.Forms.TextBox m_txtCheck3;
		private System.Windows.Forms.Label label203;
		private System.Windows.Forms.Label label204;
		private System.Windows.Forms.TextBox m_txtCheckResult;
		private System.Windows.Forms.Label m_lblCheckGrade;
		private System.Windows.Forms.Label label109;
		private System.Windows.Forms.Label label111;
		private System.Windows.Forms.Label label112;
		private System.Windows.Forms.Label label115;
		private System.Windows.Forms.Label label206;
		private System.Windows.Forms.Label label207;
		private System.Windows.Forms.Label label208;
		private System.Windows.Forms.Label label209;
		private System.Windows.Forms.Label label210;
		private System.Windows.Forms.Label label211;
		private System.Windows.Forms.Label label212;
		private System.Windows.Forms.Label label213;
		private System.Windows.Forms.Label label214;
		private System.Windows.Forms.Label label215;
		private System.Windows.Forms.Label label216;
		private System.Windows.Forms.Label label218;
		private System.Windows.Forms.Label label219;
		private System.Windows.Forms.Label label220;
		private System.Windows.Forms.Label label221;
		private System.Windows.Forms.Label label222;
		private System.Windows.Forms.Label label223;
		private System.Windows.Forms.Label label224;
		private System.Windows.Forms.Label label225;
		private System.Windows.Forms.Label label226;
		private System.Windows.Forms.Label label227;
		private System.Windows.Forms.Label label228;
		private System.Windows.Forms.Label label229;
		private System.Windows.Forms.Label label230;
		private System.Windows.Forms.Label label231;
		private System.Windows.Forms.Label label232;
		private System.Windows.Forms.LinkLabel m_lklCalCheck;
		private System.Windows.Forms.CheckBox m_chkBase1;
		private System.Windows.Forms.CheckBox m_chkBase2;
		private System.Windows.Forms.CheckBox m_chkBase4;
		private System.Windows.Forms.CheckBox m_chkBase3;
		private System.Windows.Forms.LinkLabel m_lklCalBase;
		private System.Windows.Forms.TextBox m_txtBaseResult;
		private System.Windows.Forms.CheckBox m_chkBase5;
		private System.Windows.Forms.TextBox m_txtBase1;
		private System.Windows.Forms.TextBox m_txtBase2;
		private System.Windows.Forms.TextBox m_txtBase5;
		private System.Windows.Forms.TextBox m_txtBase4;
		private System.Windows.Forms.TextBox m_txtBase3;
		private System.Windows.Forms.LinkLabel m_lklCalAgree;
		private System.Windows.Forms.TextBox m_txtAgreeResult;
		private System.Windows.Forms.Label m_lblAgreeGrade;
		private System.Windows.Forms.Label m_lblBaseGrade;
		private System.Windows.Forms.CheckBox m_chkAgree1;
		private System.Windows.Forms.CheckBox m_chkAgree2;
		private System.Windows.Forms.CheckBox m_chkAgree5;
		private System.Windows.Forms.CheckBox m_chkAgree4;
		private System.Windows.Forms.TextBox m_txtAgree1;
		private System.Windows.Forms.TextBox m_txtAgree2;
		private System.Windows.Forms.TextBox m_txtAgree5;
		private System.Windows.Forms.TextBox m_txtAgree4;
		private System.Windows.Forms.CheckBox m_chkAgree3;
		private System.Windows.Forms.TextBox m_txtAgree3;
		private System.Windows.Forms.Panel pnlCheckGrade;
		private System.Windows.Forms.Panel pnlBaseGrade;
		private System.Windows.Forms.Panel pnlAgreeGrade;
        private PinkieControls.ButtonXP m_cmdSave;
        private PinkieControls.ButtonXP m_cmdDelete;
		private System.ComponentModel.IContainer components;


		#endregion

		public frmCaseGrade()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_objDomain = new clsCaseGradeDomain();
            this.m_cboDept.DropDown -= new System.EventHandler(this.m_cboDept_DropDown);
			m_mthInitilize();
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("入院日期");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseGrade));
            this.m_tabMain = new Crownwood.Magic.Controls.TabControl();
            this.tbpResult = new Crownwood.Magic.Controls.TabPage();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdDisPlayResult = new PinkieControls.ButtonXP();
            this.m_txtAllResult = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.m_lblRePatientName = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.m_lblReInpatientID = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.m_lblReason = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.m_lblNotify = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.tbp1st = new Crownwood.Magic.Controls.TabPage();
            this.pnlMainGrade = new System.Windows.Forms.Panel();
            this.m_txtGrade1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkMain1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chkMain2 = new System.Windows.Forms.CheckBox();
            this.m_chkMain3 = new System.Windows.Forms.CheckBox();
            this.m_chkMain4 = new System.Windows.Forms.CheckBox();
            this.m_chkMain7 = new System.Windows.Forms.CheckBox();
            this.m_chkMain5 = new System.Windows.Forms.CheckBox();
            this.m_chkMain8 = new System.Windows.Forms.CheckBox();
            this.m_chkMain6 = new System.Windows.Forms.CheckBox();
            this.m_chkMain11 = new System.Windows.Forms.CheckBox();
            this.m_chkMain14 = new System.Windows.Forms.CheckBox();
            this.m_chkMain16 = new System.Windows.Forms.CheckBox();
            this.m_chkMain13 = new System.Windows.Forms.CheckBox();
            this.m_chkMain15 = new System.Windows.Forms.CheckBox();
            this.m_chkMain9 = new System.Windows.Forms.CheckBox();
            this.m_chkMain12 = new System.Windows.Forms.CheckBox();
            this.m_chkMain10 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtGrade2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtGrade4 = new System.Windows.Forms.TextBox();
            this.m_txtGrade3 = new System.Windows.Forms.TextBox();
            this.m_txtGrade8 = new System.Windows.Forms.TextBox();
            this.m_txtGrade7 = new System.Windows.Forms.TextBox();
            this.m_txtGrade6 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtGrade5 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtGrade12 = new System.Windows.Forms.TextBox();
            this.m_txtGrade11 = new System.Windows.Forms.TextBox();
            this.m_txtGrade10 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtGrade15 = new System.Windows.Forms.TextBox();
            this.m_txtGrade14 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.m_txtGrade13 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.m_txtGrade9 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.m_txtGrade16 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.m_lklMainResult = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtMainResult = new System.Windows.Forms.TextBox();
            this.m_lblMainGrade = new System.Windows.Forms.Label();
            this.tbpInPatientRec = new Crownwood.Magic.Controls.TabPage();
            this.pnlInPatientGeade = new System.Windows.Forms.Panel();
            this.m_txtInPatient1 = new System.Windows.Forms.TextBox();
            this.m_chkInPatient1 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient2 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient3 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient4 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient7 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient5 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient8 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient6 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient11 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient14 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient16 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient13 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient15 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient9 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient12 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient10 = new System.Windows.Forms.CheckBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.m_txtInPatient2 = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.m_txtInPatient4 = new System.Windows.Forms.TextBox();
            this.m_txtInPatient3 = new System.Windows.Forms.TextBox();
            this.m_txtInPatient8 = new System.Windows.Forms.TextBox();
            this.m_txtInPatient7 = new System.Windows.Forms.TextBox();
            this.m_txtInPatient6 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.m_txtInPatient5 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.m_txtInPatient12 = new System.Windows.Forms.TextBox();
            this.m_txtInPatient11 = new System.Windows.Forms.TextBox();
            this.m_txtInPatient10 = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.m_txtInPatient15 = new System.Windows.Forms.TextBox();
            this.m_txtInPatient14 = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.m_txtInPatient13 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.m_txtInPatient9 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.m_txtInPatient16 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.m_chkInPatient18 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient20 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient17 = new System.Windows.Forms.CheckBox();
            this.m_chkInPatient19 = new System.Windows.Forms.CheckBox();
            this.label154 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.m_txtInPatient19 = new System.Windows.Forms.TextBox();
            this.m_txtInPatient18 = new System.Windows.Forms.TextBox();
            this.label156 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.m_txtInPatient17 = new System.Windows.Forms.TextBox();
            this.label158 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.m_txtInPatient20 = new System.Windows.Forms.TextBox();
            this.label160 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.m_lklCalInPatResult = new System.Windows.Forms.LinkLabel();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.m_txtInPatResult = new System.Windows.Forms.TextBox();
            this.m_lblInPatGeade = new System.Windows.Forms.Label();
            this.tbpDiseaseTrack = new Crownwood.Magic.Controls.TabPage();
            this.m_lklCalDisease = new System.Windows.Forms.LinkLabel();
            this.label163 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.m_txtDiseaseResult = new System.Windows.Forms.TextBox();
            this.m_rdbOne = new System.Windows.Forms.RadioButton();
            this.m_rdbTwo = new System.Windows.Forms.RadioButton();
            this.m_lblDisGrade = new System.Windows.Forms.Label();
            this.pnlDiseaseTrack2 = new System.Windows.Forms.Panel();
            this.m_txtDiseaseOne1 = new System.Windows.Forms.TextBox();
            this.label165 = new System.Windows.Forms.Label();
            this.m_chkDiseaseOne1 = new System.Windows.Forms.CheckBox();
            this.label166 = new System.Windows.Forms.Label();
            this.m_chkDiseaseOne2 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne3 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne4 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne7 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne5 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne8 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne6 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne11 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne14 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne16 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne13 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne15 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne9 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne12 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseOne10 = new System.Windows.Forms.CheckBox();
            this.label167 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne2 = new System.Windows.Forms.TextBox();
            this.label172 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.label174 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne4 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseOne3 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseOne8 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseOne7 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseOne6 = new System.Windows.Forms.TextBox();
            this.label175 = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne5 = new System.Windows.Forms.TextBox();
            this.label177 = new System.Windows.Forms.Label();
            this.label178 = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.label180 = new System.Windows.Forms.Label();
            this.label181 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne12 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseOne11 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseOne10 = new System.Windows.Forms.TextBox();
            this.label182 = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.label184 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne15 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseOne14 = new System.Windows.Forms.TextBox();
            this.label185 = new System.Windows.Forms.Label();
            this.label186 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne13 = new System.Windows.Forms.TextBox();
            this.label187 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne9 = new System.Windows.Forms.TextBox();
            this.label188 = new System.Windows.Forms.Label();
            this.label189 = new System.Windows.Forms.Label();
            this.label190 = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.label192 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne16 = new System.Windows.Forms.TextBox();
            this.label193 = new System.Windows.Forms.Label();
            this.label194 = new System.Windows.Forms.Label();
            this.label195 = new System.Windows.Forms.Label();
            this.label196 = new System.Windows.Forms.Label();
            this.label197 = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.m_chkDiseaseOne17 = new System.Windows.Forms.CheckBox();
            this.label201 = new System.Windows.Forms.Label();
            this.label202 = new System.Windows.Forms.Label();
            this.m_txtDiseaseOne17 = new System.Windows.Forms.TextBox();
            this.pnlDiseaseTrack1 = new System.Windows.Forms.Panel();
            this.m_txtDiseaseTwo1 = new System.Windows.Forms.TextBox();
            this.label116 = new System.Windows.Forms.Label();
            this.m_chkDiseaseTwo1 = new System.Windows.Forms.CheckBox();
            this.label117 = new System.Windows.Forms.Label();
            this.m_chkDiseaseTwo2 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo3 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo4 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo7 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo5 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo8 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo6 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo11 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo14 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo16 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo13 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo15 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo9 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo12 = new System.Windows.Forms.CheckBox();
            this.m_chkDiseaseTwo10 = new System.Windows.Forms.CheckBox();
            this.label119 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.m_txtDiseaseTwo2 = new System.Windows.Forms.TextBox();
            this.label124 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.m_txtDiseaseTwo4 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseTwo3 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseTwo8 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseTwo7 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseTwo6 = new System.Windows.Forms.TextBox();
            this.label127 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.m_txtDiseaseTwo5 = new System.Windows.Forms.TextBox();
            this.label129 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.m_txtDiseaseTwo12 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseTwo11 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseTwo10 = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.m_txtDiseaseTwo15 = new System.Windows.Forms.TextBox();
            this.m_txtDiseaseTwo14 = new System.Windows.Forms.TextBox();
            this.label137 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.m_txtDiseaseTwo13 = new System.Windows.Forms.TextBox();
            this.label139 = new System.Windows.Forms.Label();
            this.m_txtDiseaseTwo9 = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.m_txtDiseaseTwo16 = new System.Windows.Forms.TextBox();
            this.label145 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.tbpOutHospital = new Crownwood.Magic.Controls.TabPage();
            this.pnlOutGrade = new System.Windows.Forms.Panel();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.m_chkOutHos1 = new System.Windows.Forms.CheckBox();
            this.m_chkOutHos2 = new System.Windows.Forms.CheckBox();
            this.m_chkOutHos4 = new System.Windows.Forms.CheckBox();
            this.m_chkOutHos3 = new System.Windows.Forms.CheckBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.m_txtOutHos1 = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.m_txtOutHos2 = new System.Windows.Forms.TextBox();
            this.m_txtOutHos4 = new System.Windows.Forms.TextBox();
            this.m_txtOutHos3 = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.m_chkOutHos5 = new System.Windows.Forms.CheckBox();
            this.label83 = new System.Windows.Forms.Label();
            this.m_txtOutHos5 = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.m_lklCalOutResult = new System.Windows.Forms.LinkLabel();
            this.label80 = new System.Windows.Forms.Label();
            this.m_txtOutResult = new System.Windows.Forms.TextBox();
            this.m_lblOutgrade = new System.Windows.Forms.Label();
            this.tbpCheck = new Crownwood.Magic.Controls.TabPage();
            this.pnlCheckGrade = new System.Windows.Forms.Panel();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.m_chkCheck1 = new System.Windows.Forms.CheckBox();
            this.m_chkCheck2 = new System.Windows.Forms.CheckBox();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.m_txtCheck1 = new System.Windows.Forms.TextBox();
            this.label108 = new System.Windows.Forms.Label();
            this.m_txtCheck2 = new System.Windows.Forms.TextBox();
            this.label153 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.m_chkCheck3 = new System.Windows.Forms.CheckBox();
            this.label164 = new System.Windows.Forms.Label();
            this.m_txtCheck3 = new System.Windows.Forms.TextBox();
            this.label203 = new System.Windows.Forms.Label();
            this.m_lklCalCheck = new System.Windows.Forms.LinkLabel();
            this.label204 = new System.Windows.Forms.Label();
            this.m_txtCheckResult = new System.Windows.Forms.TextBox();
            this.m_lblCheckGrade = new System.Windows.Forms.Label();
            this.tbpBasis = new Crownwood.Magic.Controls.TabPage();
            this.pnlBaseGrade = new System.Windows.Forms.Panel();
            this.label109 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.m_chkBase1 = new System.Windows.Forms.CheckBox();
            this.m_chkBase2 = new System.Windows.Forms.CheckBox();
            this.m_chkBase5 = new System.Windows.Forms.CheckBox();
            this.m_chkBase4 = new System.Windows.Forms.CheckBox();
            this.label112 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label206 = new System.Windows.Forms.Label();
            this.m_txtBase1 = new System.Windows.Forms.TextBox();
            this.label207 = new System.Windows.Forms.Label();
            this.m_txtBase2 = new System.Windows.Forms.TextBox();
            this.m_txtBase5 = new System.Windows.Forms.TextBox();
            this.m_txtBase4 = new System.Windows.Forms.TextBox();
            this.label208 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.label212 = new System.Windows.Forms.Label();
            this.label213 = new System.Windows.Forms.Label();
            this.m_chkBase3 = new System.Windows.Forms.CheckBox();
            this.label214 = new System.Windows.Forms.Label();
            this.m_txtBase3 = new System.Windows.Forms.TextBox();
            this.label215 = new System.Windows.Forms.Label();
            this.m_lklCalBase = new System.Windows.Forms.LinkLabel();
            this.label216 = new System.Windows.Forms.Label();
            this.m_txtBaseResult = new System.Windows.Forms.TextBox();
            this.m_lblBaseGrade = new System.Windows.Forms.Label();
            this.tbpAgree = new Crownwood.Magic.Controls.TabPage();
            this.pnlAgreeGrade = new System.Windows.Forms.Panel();
            this.label218 = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.m_chkAgree1 = new System.Windows.Forms.CheckBox();
            this.m_chkAgree2 = new System.Windows.Forms.CheckBox();
            this.m_chkAgree5 = new System.Windows.Forms.CheckBox();
            this.m_chkAgree4 = new System.Windows.Forms.CheckBox();
            this.label220 = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.m_txtAgree1 = new System.Windows.Forms.TextBox();
            this.label223 = new System.Windows.Forms.Label();
            this.m_txtAgree2 = new System.Windows.Forms.TextBox();
            this.m_txtAgree5 = new System.Windows.Forms.TextBox();
            this.m_txtAgree4 = new System.Windows.Forms.TextBox();
            this.label224 = new System.Windows.Forms.Label();
            this.label225 = new System.Windows.Forms.Label();
            this.label226 = new System.Windows.Forms.Label();
            this.label227 = new System.Windows.Forms.Label();
            this.label228 = new System.Windows.Forms.Label();
            this.label229 = new System.Windows.Forms.Label();
            this.m_chkAgree3 = new System.Windows.Forms.CheckBox();
            this.label230 = new System.Windows.Forms.Label();
            this.m_txtAgree3 = new System.Windows.Forms.TextBox();
            this.label231 = new System.Windows.Forms.Label();
            this.m_lklCalAgree = new System.Windows.Forms.LinkLabel();
            this.label232 = new System.Windows.Forms.Label();
            this.m_txtAgreeResult = new System.Windows.Forms.TextBox();
            this.m_lblAgreeGrade = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trvTime = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_tabMain.SuspendLayout();
            this.tbpResult.SuspendLayout();
            this.tbp1st.SuspendLayout();
            this.pnlMainGrade.SuspendLayout();
            this.tbpInPatientRec.SuspendLayout();
            this.pnlInPatientGeade.SuspendLayout();
            this.tbpDiseaseTrack.SuspendLayout();
            this.pnlDiseaseTrack2.SuspendLayout();
            this.pnlDiseaseTrack1.SuspendLayout();
            this.tbpOutHospital.SuspendLayout();
            this.pnlOutGrade.SuspendLayout();
            this.tbpCheck.SuspendLayout();
            this.pnlCheckGrade.SuspendLayout();
            this.tbpBasis.SuspendLayout();
            this.pnlBaseGrade.SuspendLayout();
            this.tbpAgree.SuspendLayout();
            this.pnlAgreeGrade.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(644, 46);
            this.lblSex.Size = new System.Drawing.Size(36, 19);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(732, 46);
            this.lblAge.Size = new System.Drawing.Size(44, 19);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(444, 14);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(432, 46);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(596, 14);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(596, 46);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(688, 46);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(232, 46);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(492, 68);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(92, 104);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(488, 45);
            this.txtInPatientID.Size = new System.Drawing.Size(96, 23);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(648, 13);
            this.m_txtPatientName.Size = new System.Drawing.Size(88, 23);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(488, 13);
            this.m_txtBedNO.ReadOnly = true;
            this.m_txtBedNO.Size = new System.Drawing.Size(70, 23);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(280, 44);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(652, 36);
            this.m_lsvPatientName.Size = new System.Drawing.Size(80, 104);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(492, 36);
            this.m_lsvBedNO.Size = new System.Drawing.Size(88, 104);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(280, 12);
            this.m_cboDept.DropDown += new System.EventHandler(this.m_cboDept_CGDropDown);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(232, 14);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(640, 48);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(560, 12);
            this.m_cmdNext.Visible = true;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(372, 12);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(4, 4);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(669, 80);
            // 
            // m_tabMain
            // 
            this.m_tabMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_tabMain.ButtonActiveColor = System.Drawing.Color.LightSkyBlue;
            this.m_tabMain.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.m_tabMain.IDEPixelArea = true;
            this.m_tabMain.Location = new System.Drawing.Point(12, 88);
            this.m_tabMain.Name = "m_tabMain";
            this.m_tabMain.PositionTop = true;
            this.m_tabMain.SelectedIndex = 0;
            this.m_tabMain.SelectedTab = this.tbp1st;
            this.m_tabMain.ShowArrows = true;
            this.m_tabMain.Size = new System.Drawing.Size(768, 472);
            this.m_tabMain.TabIndex = 10000004;
            this.m_tabMain.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tbp1st,
            this.tbpInPatientRec,
            this.tbpDiseaseTrack,
            this.tbpOutHospital,
            this.tbpCheck,
            this.tbpBasis,
            this.tbpAgree,
            this.tbpResult});
            this.m_tabMain.SelectionChanged += new System.EventHandler(this.m_tabMain_SelectionChanged);
            this.m_tabMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // tbpResult
            // 
            this.tbpResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpResult.Controls.Add(this.m_cmdSave);
            this.tbpResult.Controls.Add(this.m_cmdDelete);
            this.tbpResult.Controls.Add(this.m_cmdDisPlayResult);
            this.tbpResult.Controls.Add(this.m_txtAllResult);
            this.tbpResult.Controls.Add(this.label77);
            this.tbpResult.Controls.Add(this.label87);
            this.tbpResult.Controls.Add(this.label88);
            this.tbpResult.Controls.Add(this.label90);
            this.tbpResult.Controls.Add(this.label92);
            this.tbpResult.Controls.Add(this.label93);
            this.tbpResult.Controls.Add(this.label94);
            this.tbpResult.Controls.Add(this.label95);
            this.tbpResult.Controls.Add(this.label96);
            this.tbpResult.Controls.Add(this.m_lblRePatientName);
            this.tbpResult.Controls.Add(this.label97);
            this.tbpResult.Controls.Add(this.m_lblReInpatientID);
            this.tbpResult.Controls.Add(this.label98);
            this.tbpResult.Controls.Add(this.m_lblReason);
            this.tbpResult.Controls.Add(this.label101);
            this.tbpResult.Controls.Add(this.label99);
            this.tbpResult.Controls.Add(this.label100);
            this.tbpResult.Controls.Add(this.m_lblNotify);
            this.tbpResult.Controls.Add(this.label39);
            this.tbpResult.Location = new System.Drawing.Point(0, 25);
            this.tbpResult.Name = "tbpResult";
            this.tbpResult.Selected = false;
            this.tbpResult.Size = new System.Drawing.Size(768, 447);
            this.tbpResult.TabIndex = 7;
            this.tbpResult.Title = "评分结果";
            this.tbpResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(528, 8);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(68, 28);
            this.m_cmdSave.TabIndex = 2;
            this.m_cmdSave.Text = "保  存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(668, 8);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(68, 28);
            this.m_cmdDelete.TabIndex = 2;
            this.m_cmdDelete.Text = "删  除";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdDisPlayResult
            // 
            this.m_cmdDisPlayResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDisPlayResult.DefaultScheme = true;
            this.m_cmdDisPlayResult.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDisPlayResult.Hint = "";
            this.m_cmdDisPlayResult.Location = new System.Drawing.Point(36, 8);
            this.m_cmdDisPlayResult.Name = "m_cmdDisPlayResult";
            this.m_cmdDisPlayResult.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDisPlayResult.Size = new System.Drawing.Size(68, 28);
            this.m_cmdDisPlayResult.TabIndex = 2;
            this.m_cmdDisPlayResult.Text = "显示结果";
            this.m_cmdDisPlayResult.Click += new System.EventHandler(this.m_cmdDisPlayResult_Click);
            // 
            // m_txtAllResult
            // 
            this.m_txtAllResult.AccessibleDescription = "评分结果";
            this.m_txtAllResult.Location = new System.Drawing.Point(424, 64);
            this.m_txtAllResult.Name = "m_txtAllResult";
            this.m_txtAllResult.ReadOnly = true;
            this.m_txtAllResult.Size = new System.Drawing.Size(72, 20);
            this.m_txtAllResult.TabIndex = 1;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(256, 216);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(43, 13);
            this.label77.TabIndex = 0;
            this.label77.Text = "说明：";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(284, 244);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(361, 13);
            this.label87.TabIndex = 0;
            this.label87.Text = "1、适用范围：适用病历医疗文书的环节质量评价及终末质量评价。";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(284, 272);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(457, 13);
            this.label88.TabIndex = 0;
            this.label88.Text = "2、用于病历环节质量评价时，按评分标准找出病历中存在的缺陷，不评定病历等级。";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(284, 300);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(289, 13);
            this.label90.TabIndex = 0;
            this.label90.Text = "3、各项扣分以扣完该项标准分为止，不实行倒扣分。";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(284, 328);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(247, 13);
            this.label92.TabIndex = 0;
            this.label92.Text = "4、总分为100分，根据所得分划分病历等级：";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(304, 356);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(116, 13);
            this.label93.TabIndex = 0;
            this.label93.Text = "(1) ≥90为甲级病案；";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(304, 380);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(140, 13);
            this.label94.TabIndex = 0;
            this.label94.Text = "(2) 75 - 89.9为乙级病案；";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(304, 404);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(116, 13);
            this.label95.TabIndex = 0;
            this.label95.Text = "(3) <75为丙级病案。";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(64, 68);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(43, 13);
            this.label96.TabIndex = 0;
            this.label96.Text = "患者：";
            // 
            // m_lblRePatientName
            // 
            this.m_lblRePatientName.Location = new System.Drawing.Point(108, 68);
            this.m_lblRePatientName.Name = "m_lblRePatientName";
            this.m_lblRePatientName.Size = new System.Drawing.Size(68, 16);
            this.m_lblRePatientName.TabIndex = 0;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(180, 68);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(54, 13);
            this.label97.TabIndex = 0;
            this.label97.Text = "入院ID：";
            // 
            // m_lblReInpatientID
            // 
            this.m_lblReInpatientID.Location = new System.Drawing.Point(236, 68);
            this.m_lblReInpatientID.Name = "m_lblReInpatientID";
            this.m_lblReInpatientID.Size = new System.Drawing.Size(68, 16);
            this.m_lblReInpatientID.TabIndex = 0;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.ForeColor = System.Drawing.Color.Black;
            this.label98.Location = new System.Drawing.Point(308, 68);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(115, 13);
            this.label98.TabIndex = 0;
            this.label98.Text = "的病案质量结果为：";
            // 
            // m_lblReason
            // 
            this.m_lblReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_lblReason.Location = new System.Drawing.Point(64, 92);
            this.m_lblReason.Name = "m_lblReason";
            this.m_lblReason.Size = new System.Drawing.Size(664, 108);
            this.m_lblReason.TabIndex = 0;
            // 
            // label101
            // 
            this.label101.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label101.Location = new System.Drawing.Point(232, 204);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(500, 2);
            this.label101.TabIndex = 0;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(60, 220);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(67, 13);
            this.label99.TabIndex = 0;
            this.label99.Text = "主治医生：";
            this.label99.Visible = false;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(60, 248);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(67, 13);
            this.label100.TabIndex = 0;
            this.label100.Text = "住院医生：";
            this.label100.Visible = false;
            // 
            // m_lblNotify
            // 
            this.m_lblNotify.AutoSize = true;
            this.m_lblNotify.Location = new System.Drawing.Point(40, 23);
            this.m_lblNotify.Name = "m_lblNotify";
            this.m_lblNotify.Size = new System.Drawing.Size(0, 13);
            this.m_lblNotify.TabIndex = 0;
            // 
            // label39
            // 
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label39.Location = new System.Drawing.Point(36, 52);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(700, 2);
            this.label39.TabIndex = 0;
            // 
            // tbp1st
            // 
            this.tbp1st.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbp1st.Controls.Add(this.pnlMainGrade);
            this.tbp1st.Controls.Add(this.m_lklMainResult);
            this.tbp1st.Controls.Add(this.label2);
            this.tbp1st.Controls.Add(this.m_txtMainResult);
            this.tbp1st.Controls.Add(this.m_lblMainGrade);
            this.tbp1st.Location = new System.Drawing.Point(0, 25);
            this.tbp1st.Name = "tbp1st";
            this.tbp1st.Size = new System.Drawing.Size(768, 447);
            this.tbp1st.TabIndex = 3;
            this.tbp1st.Title = "首  页";
            this.m_tipMain.SetToolTip(this.tbp1st, "项目齐全、准确，字迹清楚，严禁涂改。出院24小时内完成");
            this.tbp1st.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // pnlMainGrade
            // 
            this.pnlMainGrade.Controls.Add(this.m_txtGrade1);
            this.pnlMainGrade.Controls.Add(this.label4);
            this.pnlMainGrade.Controls.Add(this.m_chkMain1);
            this.pnlMainGrade.Controls.Add(this.label3);
            this.pnlMainGrade.Controls.Add(this.m_chkMain2);
            this.pnlMainGrade.Controls.Add(this.m_chkMain3);
            this.pnlMainGrade.Controls.Add(this.m_chkMain4);
            this.pnlMainGrade.Controls.Add(this.m_chkMain7);
            this.pnlMainGrade.Controls.Add(this.m_chkMain5);
            this.pnlMainGrade.Controls.Add(this.m_chkMain8);
            this.pnlMainGrade.Controls.Add(this.m_chkMain6);
            this.pnlMainGrade.Controls.Add(this.m_chkMain11);
            this.pnlMainGrade.Controls.Add(this.m_chkMain14);
            this.pnlMainGrade.Controls.Add(this.m_chkMain16);
            this.pnlMainGrade.Controls.Add(this.m_chkMain13);
            this.pnlMainGrade.Controls.Add(this.m_chkMain15);
            this.pnlMainGrade.Controls.Add(this.m_chkMain9);
            this.pnlMainGrade.Controls.Add(this.m_chkMain12);
            this.pnlMainGrade.Controls.Add(this.m_chkMain10);
            this.pnlMainGrade.Controls.Add(this.label5);
            this.pnlMainGrade.Controls.Add(this.label6);
            this.pnlMainGrade.Controls.Add(this.label7);
            this.pnlMainGrade.Controls.Add(this.label8);
            this.pnlMainGrade.Controls.Add(this.label9);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade2);
            this.pnlMainGrade.Controls.Add(this.label10);
            this.pnlMainGrade.Controls.Add(this.label11);
            this.pnlMainGrade.Controls.Add(this.label12);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade4);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade3);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade8);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade7);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade6);
            this.pnlMainGrade.Controls.Add(this.label13);
            this.pnlMainGrade.Controls.Add(this.label14);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade5);
            this.pnlMainGrade.Controls.Add(this.label15);
            this.pnlMainGrade.Controls.Add(this.label16);
            this.pnlMainGrade.Controls.Add(this.label17);
            this.pnlMainGrade.Controls.Add(this.label18);
            this.pnlMainGrade.Controls.Add(this.label19);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade12);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade11);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade10);
            this.pnlMainGrade.Controls.Add(this.label20);
            this.pnlMainGrade.Controls.Add(this.label21);
            this.pnlMainGrade.Controls.Add(this.label22);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade15);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade14);
            this.pnlMainGrade.Controls.Add(this.label23);
            this.pnlMainGrade.Controls.Add(this.label24);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade13);
            this.pnlMainGrade.Controls.Add(this.label25);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade9);
            this.pnlMainGrade.Controls.Add(this.label26);
            this.pnlMainGrade.Controls.Add(this.label27);
            this.pnlMainGrade.Controls.Add(this.label28);
            this.pnlMainGrade.Controls.Add(this.label29);
            this.pnlMainGrade.Controls.Add(this.label30);
            this.pnlMainGrade.Controls.Add(this.m_txtGrade16);
            this.pnlMainGrade.Controls.Add(this.label31);
            this.pnlMainGrade.Controls.Add(this.label32);
            this.pnlMainGrade.Controls.Add(this.label33);
            this.pnlMainGrade.Controls.Add(this.label34);
            this.pnlMainGrade.Controls.Add(this.label35);
            this.pnlMainGrade.Controls.Add(this.label36);
            this.pnlMainGrade.Controls.Add(this.label37);
            this.pnlMainGrade.Controls.Add(this.label38);
            this.pnlMainGrade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMainGrade.Location = new System.Drawing.Point(0, 31);
            this.pnlMainGrade.Name = "pnlMainGrade";
            this.pnlMainGrade.Size = new System.Drawing.Size(764, 412);
            this.pnlMainGrade.TabIndex = 149;
            this.pnlMainGrade.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // m_txtGrade1
            // 
            this.m_txtGrade1.AccessibleDescription = "★3项未填写（自然缺项除外）";
            this.m_txtGrade1.Location = new System.Drawing.Point(508, 56);
            this.m_txtGrade1.Name = "m_txtGrade1";
            this.m_txtGrade1.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade1.TabIndex = 57;
            this.m_txtGrade1.Tag = "乙级";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "缺陷内容";
            // 
            // m_chkMain1
            // 
            this.m_chkMain1.AccessibleDescription = "m_txtGrade1";
            this.m_chkMain1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain1.Location = new System.Drawing.Point(36, 60);
            this.m_chkMain1.Name = "m_chkMain1";
            this.m_chkMain1.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain1.TabIndex = 25;
            this.m_chkMain1.Tag = "-1";
            this.m_chkMain1.Text = "★3项未填写（自然缺项除外）";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(32, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(708, 4);
            this.label3.TabIndex = 19;
            this.label3.Text = "label3";
            // 
            // m_chkMain2
            // 
            this.m_chkMain2.AccessibleDescription = "m_txtGrade2";
            this.m_chkMain2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain2.Location = new System.Drawing.Point(36, 80);
            this.m_chkMain2.Name = "m_chkMain2";
            this.m_chkMain2.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain2.TabIndex = 26;
            this.m_chkMain2.Tag = "-1";
            this.m_chkMain2.Text = "★传染病漏报";
            // 
            // m_chkMain3
            // 
            this.m_chkMain3.AccessibleDescription = "m_txtGrade3";
            this.m_chkMain3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain3.Location = new System.Drawing.Point(36, 100);
            this.m_chkMain3.Name = "m_chkMain3";
            this.m_chkMain3.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain3.TabIndex = 27;
            this.m_chkMain3.Tag = "1";
            this.m_chkMain3.Text = "门(急)诊诊断未填写";
            // 
            // m_chkMain4
            // 
            this.m_chkMain4.AccessibleDescription = "m_txtGrade4";
            this.m_chkMain4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain4.Location = new System.Drawing.Point(36, 120);
            this.m_chkMain4.Name = "m_chkMain4";
            this.m_chkMain4.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain4.TabIndex = 22;
            this.m_chkMain4.Tag = "0.5";
            this.m_chkMain4.Text = "门(急)诊诊断填写有缺陷";
            // 
            // m_chkMain7
            // 
            this.m_chkMain7.AccessibleDescription = "m_txtGrade7";
            this.m_chkMain7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain7.Location = new System.Drawing.Point(36, 180);
            this.m_chkMain7.Name = "m_chkMain7";
            this.m_chkMain7.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain7.TabIndex = 23;
            this.m_chkMain7.Tag = "2";
            this.m_chkMain7.Text = "出院诊断未填写";
            // 
            // m_chkMain5
            // 
            this.m_chkMain5.AccessibleDescription = "m_txtGrade5";
            this.m_chkMain5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain5.Location = new System.Drawing.Point(36, 140);
            this.m_chkMain5.Name = "m_chkMain5";
            this.m_chkMain5.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain5.TabIndex = 24;
            this.m_chkMain5.Tag = "1";
            this.m_chkMain5.Text = "入院诊断未填写";
            // 
            // m_chkMain8
            // 
            this.m_chkMain8.AccessibleDescription = "m_txtGrade8";
            this.m_chkMain8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain8.Location = new System.Drawing.Point(36, 200);
            this.m_chkMain8.Name = "m_chkMain8";
            this.m_chkMain8.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain8.TabIndex = 28;
            this.m_chkMain8.Tag = "0.5";
            this.m_chkMain8.Text = "出院诊断填写有缺陷";
            // 
            // m_chkMain6
            // 
            this.m_chkMain6.AccessibleDescription = "m_txtGrade6";
            this.m_chkMain6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain6.Location = new System.Drawing.Point(36, 160);
            this.m_chkMain6.Name = "m_chkMain6";
            this.m_chkMain6.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain6.TabIndex = 35;
            this.m_chkMain6.Tag = "0.5";
            this.m_chkMain6.Text = "入院诊断填写有缺陷";
            // 
            // m_chkMain11
            // 
            this.m_chkMain11.AccessibleDescription = "m_txtGrade11";
            this.m_chkMain11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain11.Location = new System.Drawing.Point(36, 260);
            this.m_chkMain11.Name = "m_chkMain11";
            this.m_chkMain11.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain11.TabIndex = 34;
            this.m_chkMain11.Tag = "2";
            this.m_chkMain11.Text = "手术、操作名称未填写";
            // 
            // m_chkMain14
            // 
            this.m_chkMain14.AccessibleDescription = "m_txtGrade14";
            this.m_chkMain14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain14.Location = new System.Drawing.Point(36, 320);
            this.m_chkMain14.Name = "m_chkMain14";
            this.m_chkMain14.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain14.TabIndex = 37;
            this.m_chkMain14.Tag = "0";
            this.m_chkMain14.Text = "病理诊断填写有缺陷";
            // 
            // m_chkMain16
            // 
            this.m_chkMain16.AccessibleDescription = "m_txtGrade16";
            this.m_chkMain16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain16.Location = new System.Drawing.Point(36, 360);
            this.m_chkMain16.Name = "m_chkMain16";
            this.m_chkMain16.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain16.TabIndex = 36;
            this.m_chkMain16.Tag = "0";
            this.m_chkMain16.Text = "缺各级医生签名";
            // 
            // m_chkMain13
            // 
            this.m_chkMain13.AccessibleDescription = "m_txtGrade13";
            this.m_chkMain13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain13.Location = new System.Drawing.Point(36, 300);
            this.m_chkMain13.Name = "m_chkMain13";
            this.m_chkMain13.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain13.TabIndex = 30;
            this.m_chkMain13.Tag = "0";
            this.m_chkMain13.Text = "有病理诊断报告、病理诊断未填写";
            // 
            // m_chkMain15
            // 
            this.m_chkMain15.AccessibleDescription = "m_txtGrade15";
            this.m_chkMain15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain15.Location = new System.Drawing.Point(36, 340);
            this.m_chkMain15.Name = "m_chkMain15";
            this.m_chkMain15.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain15.TabIndex = 29;
            this.m_chkMain15.Tag = "1";
            this.m_chkMain15.Text = "过敏药物空白或填写错误";
            // 
            // m_chkMain9
            // 
            this.m_chkMain9.AccessibleDescription = "m_txtGrade9";
            this.m_chkMain9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain9.Location = new System.Drawing.Point(36, 220);
            this.m_chkMain9.Name = "m_chkMain9";
            this.m_chkMain9.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain9.TabIndex = 32;
            this.m_chkMain9.Tag = "0";
            this.m_chkMain9.Text = "出院情况未填写或有缺陷";
            // 
            // m_chkMain12
            // 
            this.m_chkMain12.AccessibleDescription = "m_txtGrade12";
            this.m_chkMain12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain12.Location = new System.Drawing.Point(36, 280);
            this.m_chkMain12.Name = "m_chkMain12";
            this.m_chkMain12.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain12.TabIndex = 31;
            this.m_chkMain12.Tag = "0.5";
            this.m_chkMain12.Text = "手术、操作名称填写有缺陷";
            // 
            // m_chkMain10
            // 
            this.m_chkMain10.AccessibleDescription = "m_txtGrade10";
            this.m_chkMain10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkMain10.Location = new System.Drawing.Point(36, 240);
            this.m_chkMain10.Name = "m_chkMain10";
            this.m_chkMain10.Size = new System.Drawing.Size(236, 16);
            this.m_chkMain10.TabIndex = 33;
            this.m_chkMain10.Tag = "2";
            this.m_chkMain10.Text = "医院感染未填写";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "扣分标准";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "扣  分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "乙级";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(356, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "乙级";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(36, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(650, 1);
            this.label9.TabIndex = 5;
            this.label9.Text = "label3";
            // 
            // m_txtGrade2
            // 
            this.m_txtGrade2.AccessibleDescription = "★传染病漏报";
            this.m_txtGrade2.Location = new System.Drawing.Point(508, 76);
            this.m_txtGrade2.Name = "m_txtGrade2";
            this.m_txtGrade2.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade2.TabIndex = 59;
            this.m_txtGrade2.Tag = "乙级";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "0.5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(356, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "1";
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(36, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(650, 1);
            this.label12.TabIndex = 17;
            this.label12.Text = "label3";
            // 
            // m_txtGrade4
            // 
            this.m_txtGrade4.AccessibleDescription = "门(急)诊诊断填写有缺陷";
            this.m_txtGrade4.Location = new System.Drawing.Point(508, 116);
            this.m_txtGrade4.Name = "m_txtGrade4";
            this.m_txtGrade4.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade4.TabIndex = 58;
            this.m_txtGrade4.Tag = "0.5";
            // 
            // m_txtGrade3
            // 
            this.m_txtGrade3.AccessibleDescription = "门(急)诊诊断未填写";
            this.m_txtGrade3.Location = new System.Drawing.Point(508, 96);
            this.m_txtGrade3.Name = "m_txtGrade3";
            this.m_txtGrade3.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade3.TabIndex = 61;
            this.m_txtGrade3.Tag = "1";
            // 
            // m_txtGrade8
            // 
            this.m_txtGrade8.AccessibleDescription = "出院诊断填写有缺陷";
            this.m_txtGrade8.Location = new System.Drawing.Point(508, 196);
            this.m_txtGrade8.Name = "m_txtGrade8";
            this.m_txtGrade8.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade8.TabIndex = 69;
            this.m_txtGrade8.Tag = "0.5";
            // 
            // m_txtGrade7
            // 
            this.m_txtGrade7.AccessibleDescription = "出院诊断未填写";
            this.m_txtGrade7.Location = new System.Drawing.Point(508, 176);
            this.m_txtGrade7.Name = "m_txtGrade7";
            this.m_txtGrade7.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade7.TabIndex = 68;
            this.m_txtGrade7.Tag = "2";
            // 
            // m_txtGrade6
            // 
            this.m_txtGrade6.AccessibleDescription = "入院诊断填写有缺陷";
            this.m_txtGrade6.Location = new System.Drawing.Point(508, 156);
            this.m_txtGrade6.Name = "m_txtGrade6";
            this.m_txtGrade6.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade6.TabIndex = 72;
            this.m_txtGrade6.Tag = "0.5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(356, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "0.5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(356, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "1";
            // 
            // m_txtGrade5
            // 
            this.m_txtGrade5.AccessibleDescription = "入院诊断未填写";
            this.m_txtGrade5.Location = new System.Drawing.Point(508, 136);
            this.m_txtGrade5.Name = "m_txtGrade5";
            this.m_txtGrade5.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade5.TabIndex = 62;
            this.m_txtGrade5.Tag = "1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(356, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 56;
            this.label15.Text = "0.5";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(356, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 13);
            this.label16.TabIndex = 54;
            this.label16.Text = "2";
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(36, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(650, 1);
            this.label17.TabIndex = 12;
            this.label17.Text = "label3";
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Location = new System.Drawing.Point(36, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(650, 1);
            this.label18.TabIndex = 13;
            this.label18.Text = "label3";
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(36, 356);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(650, 1);
            this.label19.TabIndex = 14;
            this.label19.Text = "label3";
            // 
            // m_txtGrade12
            // 
            this.m_txtGrade12.AccessibleDescription = "手术、操作名称填写有缺陷";
            this.m_txtGrade12.Location = new System.Drawing.Point(508, 276);
            this.m_txtGrade12.Name = "m_txtGrade12";
            this.m_txtGrade12.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade12.TabIndex = 65;
            this.m_txtGrade12.Tag = "0.5";
            // 
            // m_txtGrade11
            // 
            this.m_txtGrade11.AccessibleDescription = "手术、操作名称未填写";
            this.m_txtGrade11.Location = new System.Drawing.Point(508, 256);
            this.m_txtGrade11.Name = "m_txtGrade11";
            this.m_txtGrade11.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade11.TabIndex = 66;
            this.m_txtGrade11.Tag = "2";
            // 
            // m_txtGrade10
            // 
            this.m_txtGrade10.AccessibleDescription = "医院感染未填写";
            this.m_txtGrade10.Location = new System.Drawing.Point(508, 236);
            this.m_txtGrade10.Name = "m_txtGrade10";
            this.m_txtGrade10.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade10.TabIndex = 64;
            this.m_txtGrade10.Tag = "2";
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Location = new System.Drawing.Point(36, 316);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(650, 1);
            this.label20.TabIndex = 15;
            this.label20.Text = "label3";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(356, 240);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 13);
            this.label21.TabIndex = 39;
            this.label21.Text = "2";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(356, 220);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 13);
            this.label22.TabIndex = 38;
            this.label22.Text = "0.5/项";
            // 
            // m_txtGrade15
            // 
            this.m_txtGrade15.AccessibleDescription = "过敏药物空白或填写错误";
            this.m_txtGrade15.Location = new System.Drawing.Point(508, 336);
            this.m_txtGrade15.Name = "m_txtGrade15";
            this.m_txtGrade15.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade15.TabIndex = 63;
            this.m_txtGrade15.Tag = "1";
            // 
            // m_txtGrade14
            // 
            this.m_txtGrade14.AccessibleDescription = "病理诊断填写有缺陷";
            this.m_txtGrade14.Location = new System.Drawing.Point(508, 316);
            this.m_txtGrade14.Name = "m_txtGrade14";
            this.m_txtGrade14.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade14.TabIndex = 67;
            this.m_txtGrade14.Tag = "0.5";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(356, 320);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(39, 13);
            this.label23.TabIndex = 43;
            this.label23.Text = "0.5/项";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(356, 300);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 13);
            this.label24.TabIndex = 44;
            this.label24.Text = "1/项";
            // 
            // m_txtGrade13
            // 
            this.m_txtGrade13.AccessibleDescription = "有病理诊断报告、病理诊断未填写";
            this.m_txtGrade13.Location = new System.Drawing.Point(508, 296);
            this.m_txtGrade13.Name = "m_txtGrade13";
            this.m_txtGrade13.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade13.TabIndex = 71;
            this.m_txtGrade13.Tag = "1";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(356, 360);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 13);
            this.label25.TabIndex = 45;
            this.label25.Text = "2/处";
            // 
            // m_txtGrade9
            // 
            this.m_txtGrade9.AccessibleDescription = "出院情况未填写或有缺陷";
            this.m_txtGrade9.Location = new System.Drawing.Point(508, 216);
            this.m_txtGrade9.Name = "m_txtGrade9";
            this.m_txtGrade9.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade9.TabIndex = 70;
            this.m_txtGrade9.Tag = "0.5";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(356, 280);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(23, 13);
            this.label26.TabIndex = 40;
            this.label26.Text = "0.5";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(356, 340);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(13, 13);
            this.label27.TabIndex = 41;
            this.label27.Text = "1";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(356, 260);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(13, 13);
            this.label28.TabIndex = 42;
            this.label28.Text = "2";
            // 
            // label29
            // 
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label29.Location = new System.Drawing.Point(36, 236);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(650, 1);
            this.label29.TabIndex = 18;
            this.label29.Text = "label3";
            // 
            // label30
            // 
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label30.Location = new System.Drawing.Point(36, 276);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(650, 1);
            this.label30.TabIndex = 16;
            this.label30.Text = "label3";
            // 
            // m_txtGrade16
            // 
            this.m_txtGrade16.AccessibleDescription = "缺各级医生签名";
            this.m_txtGrade16.Location = new System.Drawing.Point(508, 356);
            this.m_txtGrade16.Name = "m_txtGrade16";
            this.m_txtGrade16.Size = new System.Drawing.Size(100, 20);
            this.m_txtGrade16.TabIndex = 60;
            this.m_txtGrade16.Tag = "2";
            // 
            // label31
            // 
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label31.Location = new System.Drawing.Point(36, 216);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(650, 1);
            this.label31.TabIndex = 7;
            this.label31.Text = "label3";
            // 
            // label32
            // 
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label32.Location = new System.Drawing.Point(36, 376);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(650, 1);
            this.label32.TabIndex = 6;
            this.label32.Text = "label3";
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label33.Location = new System.Drawing.Point(36, 256);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(650, 1);
            this.label33.TabIndex = 8;
            this.label33.Text = "label3";
            // 
            // label34
            // 
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label34.Location = new System.Drawing.Point(36, 176);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(650, 1);
            this.label34.TabIndex = 11;
            this.label34.Text = "label3";
            // 
            // label35
            // 
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label35.Location = new System.Drawing.Point(36, 336);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(650, 1);
            this.label35.TabIndex = 10;
            this.label35.Text = "label3";
            // 
            // label36
            // 
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label36.Location = new System.Drawing.Point(36, 296);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(650, 1);
            this.label36.TabIndex = 9;
            this.label36.Text = "label3";
            // 
            // label37
            // 
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label37.Location = new System.Drawing.Point(36, 96);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(650, 1);
            this.label37.TabIndex = 20;
            this.label37.Text = "label3";
            // 
            // label38
            // 
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label38.Location = new System.Drawing.Point(36, 136);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(650, 1);
            this.label38.TabIndex = 21;
            this.label38.Text = "label3";
            // 
            // m_lklMainResult
            // 
            this.m_lklMainResult.AutoSize = true;
            this.m_lklMainResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lklMainResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_lklMainResult.LinkColor = System.Drawing.Color.Red;
            this.m_lklMainResult.Location = new System.Drawing.Point(576, 8);
            this.m_lklMainResult.Name = "m_lklMainResult";
            this.m_lklMainResult.Size = new System.Drawing.Size(67, 13);
            this.m_lklMainResult.TabIndex = 148;
            this.m_lklMainResult.TabStop = true;
            this.m_lklMainResult.Text = "计算扣分：";
            this.m_tipMain.SetToolTip(this.m_lklMainResult, "点击计算本页面的总扣分");
            this.m_lklMainResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMainResult_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "标准分值：  10 分";
            // 
            // m_txtMainResult
            // 
            this.m_txtMainResult.AccessibleDescription = "首页扣分";
            this.m_txtMainResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_txtMainResult.Location = new System.Drawing.Point(644, 6);
            this.m_txtMainResult.Name = "m_txtMainResult";
            this.m_txtMainResult.ReadOnly = true;
            this.m_txtMainResult.Size = new System.Drawing.Size(52, 20);
            this.m_txtMainResult.TabIndex = 4;
            this.m_tipMain.SetToolTip(this.m_txtMainResult, "扣分结果以标准分值为最");
            // 
            // m_lblMainGrade
            // 
            this.m_lblMainGrade.AutoSize = true;
            this.m_lblMainGrade.Location = new System.Drawing.Point(700, 9);
            this.m_lblMainGrade.Name = "m_lblMainGrade";
            this.m_lblMainGrade.Size = new System.Drawing.Size(0, 13);
            this.m_lblMainGrade.TabIndex = 3;
            // 
            // tbpInPatientRec
            // 
            this.tbpInPatientRec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpInPatientRec.Controls.Add(this.pnlInPatientGeade);
            this.tbpInPatientRec.Controls.Add(this.m_lklCalInPatResult);
            this.tbpInPatientRec.Controls.Add(this.label40);
            this.tbpInPatientRec.Controls.Add(this.label41);
            this.tbpInPatientRec.Controls.Add(this.label42);
            this.tbpInPatientRec.Controls.Add(this.label43);
            this.tbpInPatientRec.Controls.Add(this.label44);
            this.tbpInPatientRec.Controls.Add(this.m_txtInPatResult);
            this.tbpInPatientRec.Controls.Add(this.m_lblInPatGeade);
            this.tbpInPatientRec.Location = new System.Drawing.Point(0, 25);
            this.tbpInPatientRec.Name = "tbpInPatientRec";
            this.tbpInPatientRec.Selected = false;
            this.tbpInPatientRec.Size = new System.Drawing.Size(768, 447);
            this.tbpInPatientRec.TabIndex = 4;
            this.tbpInPatientRec.Title = "入院记录";
            this.tbpInPatientRec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // pnlInPatientGeade
            // 
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient1);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient1);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient2);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient3);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient4);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient7);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient5);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient8);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient6);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient11);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient14);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient16);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient13);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient15);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient9);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient12);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient10);
            this.pnlInPatientGeade.Controls.Add(this.label45);
            this.pnlInPatientGeade.Controls.Add(this.label46);
            this.pnlInPatientGeade.Controls.Add(this.label47);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient2);
            this.pnlInPatientGeade.Controls.Add(this.label48);
            this.pnlInPatientGeade.Controls.Add(this.label49);
            this.pnlInPatientGeade.Controls.Add(this.label50);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient4);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient3);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient8);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient7);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient6);
            this.pnlInPatientGeade.Controls.Add(this.label51);
            this.pnlInPatientGeade.Controls.Add(this.label52);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient5);
            this.pnlInPatientGeade.Controls.Add(this.label53);
            this.pnlInPatientGeade.Controls.Add(this.label54);
            this.pnlInPatientGeade.Controls.Add(this.label55);
            this.pnlInPatientGeade.Controls.Add(this.label56);
            this.pnlInPatientGeade.Controls.Add(this.label57);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient12);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient11);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient10);
            this.pnlInPatientGeade.Controls.Add(this.label58);
            this.pnlInPatientGeade.Controls.Add(this.label59);
            this.pnlInPatientGeade.Controls.Add(this.label60);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient15);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient14);
            this.pnlInPatientGeade.Controls.Add(this.label61);
            this.pnlInPatientGeade.Controls.Add(this.label62);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient13);
            this.pnlInPatientGeade.Controls.Add(this.label63);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient9);
            this.pnlInPatientGeade.Controls.Add(this.label64);
            this.pnlInPatientGeade.Controls.Add(this.label65);
            this.pnlInPatientGeade.Controls.Add(this.label66);
            this.pnlInPatientGeade.Controls.Add(this.label67);
            this.pnlInPatientGeade.Controls.Add(this.label68);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient16);
            this.pnlInPatientGeade.Controls.Add(this.label69);
            this.pnlInPatientGeade.Controls.Add(this.label70);
            this.pnlInPatientGeade.Controls.Add(this.label71);
            this.pnlInPatientGeade.Controls.Add(this.label72);
            this.pnlInPatientGeade.Controls.Add(this.label73);
            this.pnlInPatientGeade.Controls.Add(this.label74);
            this.pnlInPatientGeade.Controls.Add(this.label75);
            this.pnlInPatientGeade.Controls.Add(this.label76);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient18);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient20);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient17);
            this.pnlInPatientGeade.Controls.Add(this.m_chkInPatient19);
            this.pnlInPatientGeade.Controls.Add(this.label154);
            this.pnlInPatientGeade.Controls.Add(this.label155);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient19);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient18);
            this.pnlInPatientGeade.Controls.Add(this.label156);
            this.pnlInPatientGeade.Controls.Add(this.label157);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient17);
            this.pnlInPatientGeade.Controls.Add(this.label158);
            this.pnlInPatientGeade.Controls.Add(this.label159);
            this.pnlInPatientGeade.Controls.Add(this.m_txtInPatient20);
            this.pnlInPatientGeade.Controls.Add(this.label160);
            this.pnlInPatientGeade.Controls.Add(this.label161);
            this.pnlInPatientGeade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInPatientGeade.Location = new System.Drawing.Point(0, 39);
            this.pnlInPatientGeade.Name = "pnlInPatientGeade";
            this.pnlInPatientGeade.Size = new System.Drawing.Size(764, 404);
            this.pnlInPatientGeade.TabIndex = 148;
            this.pnlInPatientGeade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // m_txtInPatient1
            // 
            this.m_txtInPatient1.AccessibleDescription = "入院记录（再次或多次入院记录）未按时完成\r\n";
            this.m_txtInPatient1.Location = new System.Drawing.Point(529, 2);
            this.m_txtInPatient1.Name = "m_txtInPatient1";
            this.m_txtInPatient1.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient1.TabIndex = 139;
            this.m_txtInPatient1.Tag = "5";
            this.m_tipMain.SetToolTip(this.m_txtInPatient1, "入院24小时内由住院医师完成");
            // 
            // m_chkInPatient1
            // 
            this.m_chkInPatient1.AccessibleDescription = "m_txtInPatient1";
            this.m_chkInPatient1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient1.Location = new System.Drawing.Point(57, 6);
            this.m_chkInPatient1.Name = "m_chkInPatient1";
            this.m_chkInPatient1.Size = new System.Drawing.Size(276, 16);
            this.m_chkInPatient1.TabIndex = 100;
            this.m_chkInPatient1.Tag = "5";
            this.m_chkInPatient1.Text = "入院记录（再次或多次入院记录）未按时完成\r\n";
            this.m_tipMain.SetToolTip(this.m_chkInPatient1, "入院24小时内由住院医师完成");
            // 
            // m_chkInPatient2
            // 
            this.m_chkInPatient2.AccessibleDescription = "m_txtInPatient2";
            this.m_chkInPatient2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient2.Location = new System.Drawing.Point(57, 26);
            this.m_chkInPatient2.Name = "m_chkInPatient2";
            this.m_chkInPatient2.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient2.TabIndex = 101;
            this.m_chkInPatient2.Tag = "0.5";
            this.m_chkInPatient2.Text = "一般项目填写不全\r\n";
            // 
            // m_chkInPatient3
            // 
            this.m_chkInPatient3.AccessibleDescription = "m_txtInPatient3";
            this.m_chkInPatient3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient3.Location = new System.Drawing.Point(57, 46);
            this.m_chkInPatient3.Name = "m_chkInPatient3";
            this.m_chkInPatient3.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient3.TabIndex = 102;
            this.m_chkInPatient3.Tag = "1";
            this.m_chkInPatient3.Text = "主诉描述有缺陷\r\n";
            // 
            // m_chkInPatient4
            // 
            this.m_chkInPatient4.AccessibleDescription = "m_txtInPatient4";
            this.m_chkInPatient4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient4.Location = new System.Drawing.Point(57, 66);
            this.m_chkInPatient4.Name = "m_chkInPatient4";
            this.m_chkInPatient4.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient4.TabIndex = 99;
            this.m_chkInPatient4.Tag = "1";
            this.m_chkInPatient4.Text = "有症状（或体征）而以诊断代替主诉\r\n";
            // 
            // m_chkInPatient7
            // 
            this.m_chkInPatient7.AccessibleDescription = "m_txtInPatient7";
            this.m_chkInPatient7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient7.Location = new System.Drawing.Point(57, 126);
            this.m_chkInPatient7.Name = "m_chkInPatient7";
            this.m_chkInPatient7.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient7.TabIndex = 96;
            this.m_chkInPatient7.Tag = "2";
            this.m_chkInPatient7.Text = "叙述混乱、颠倒、层次不清\r\n";
            // 
            // m_chkInPatient5
            // 
            this.m_chkInPatient5.AccessibleDescription = "m_txtInPatient5";
            this.m_chkInPatient5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient5.Location = new System.Drawing.Point(57, 86);
            this.m_chkInPatient5.Name = "m_chkInPatient5";
            this.m_chkInPatient5.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient5.TabIndex = 97;
            this.m_chkInPatient5.Tag = "3";
            this.m_chkInPatient5.Text = "现病史描述主要症状不明确\r\n";
            this.m_tipMain.SetToolTip(this.m_chkInPatient5, "现病史必须与主诉相关、相符，能反映本次疾病起始、演变、诊疗过程及一般情况变化，重点突出、概念明确，运用术语准确，有鉴别诊断资料。");
            // 
            // m_chkInPatient8
            // 
            this.m_chkInPatient8.AccessibleDescription = "m_txtInPatient8";
            this.m_chkInPatient8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient8.Location = new System.Drawing.Point(57, 146);
            this.m_chkInPatient8.Name = "m_chkInPatient8";
            this.m_chkInPatient8.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient8.TabIndex = 98;
            this.m_chkInPatient8.Tag = "2";
            this.m_chkInPatient8.Text = "缺必要的鉴别诊断资料\r\n";
            // 
            // m_chkInPatient6
            // 
            this.m_chkInPatient6.AccessibleDescription = "m_txtInPatient6";
            this.m_chkInPatient6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient6.Location = new System.Drawing.Point(57, 106);
            this.m_chkInPatient6.Name = "m_chkInPatient6";
            this.m_chkInPatient6.Size = new System.Drawing.Size(376, 16);
            this.m_chkInPatient6.TabIndex = 111;
            this.m_chkInPatient6.Tag = "2";
            this.m_chkInPatient6.Text = "发病诱因、主要疾病发展变化过程、诊治情况叙述不清，描述不准确\r\n";
            // 
            // m_chkInPatient11
            // 
            this.m_chkInPatient11.AccessibleDescription = "m_txtInPatient11";
            this.m_chkInPatient11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient11.Location = new System.Drawing.Point(57, 206);
            this.m_chkInPatient11.Name = "m_chkInPatient11";
            this.m_chkInPatient11.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient11.TabIndex = 110;
            this.m_chkInPatient11.Tag = "-1";
            this.m_chkInPatient11.Text = "★体格检查遗漏系统或主要阳性体征\r\n";
            // 
            // m_chkInPatient14
            // 
            this.m_chkInPatient14.AccessibleDescription = "m_txtInPatient14";
            this.m_chkInPatient14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient14.Location = new System.Drawing.Point(57, 266);
            this.m_chkInPatient14.Name = "m_chkInPatient14";
            this.m_chkInPatient14.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient14.TabIndex = 113;
            this.m_chkInPatient14.Tag = "-1";
            this.m_chkInPatient14.Text = "★缺必要的专科或重点检查\r\n";
            // 
            // m_chkInPatient16
            // 
            this.m_chkInPatient16.AccessibleDescription = "m_txtInPatient16";
            this.m_chkInPatient16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient16.Location = new System.Drawing.Point(57, 306);
            this.m_chkInPatient16.Name = "m_chkInPatient16";
            this.m_chkInPatient16.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient16.TabIndex = 115;
            this.m_chkInPatient16.Tag = "-2";
            this.m_chkInPatient16.Text = "★主要疾病漏诊";
            // 
            // m_chkInPatient13
            // 
            this.m_chkInPatient13.AccessibleDescription = "m_txtInPatient13";
            this.m_chkInPatient13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient13.Location = new System.Drawing.Point(57, 246);
            this.m_chkInPatient13.Name = "m_chkInPatient13";
            this.m_chkInPatient13.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient13.TabIndex = 109;
            this.m_chkInPatient13.Tag = "1";
            this.m_chkInPatient13.Text = "体格检查记录描述不规范\r\n";
            // 
            // m_chkInPatient15
            // 
            this.m_chkInPatient15.AccessibleDescription = "m_txtInPatient15";
            this.m_chkInPatient15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient15.Location = new System.Drawing.Point(57, 286);
            this.m_chkInPatient15.Name = "m_chkInPatient15";
            this.m_chkInPatient15.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient15.TabIndex = 104;
            this.m_chkInPatient15.Tag = "2";
            this.m_chkInPatient15.Text = "必要的辅助检查空缺\r\n";
            // 
            // m_chkInPatient9
            // 
            this.m_chkInPatient9.AccessibleDescription = "m_txtInPatient9";
            this.m_chkInPatient9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient9.Location = new System.Drawing.Point(57, 166);
            this.m_chkInPatient9.Name = "m_chkInPatient9";
            this.m_chkInPatient9.Size = new System.Drawing.Size(264, 16);
            this.m_chkInPatient9.TabIndex = 107;
            this.m_chkInPatient9.Tag = "2";
            this.m_chkInPatient9.Text = "缺四史（既往史、个人史、婚育史、家族史）\r\n";
            this.m_tipMain.SetToolTip(this.m_chkInPatient9, "? 既往史、个人史、月经生育史、家族史齐全，传染病有流行病史，小儿有喂养史。");
            // 
            // m_chkInPatient12
            // 
            this.m_chkInPatient12.AccessibleDescription = "m_txtInPatient12";
            this.m_chkInPatient12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient12.Location = new System.Drawing.Point(57, 226);
            this.m_chkInPatient12.Name = "m_chkInPatient12";
            this.m_chkInPatient12.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient12.TabIndex = 106;
            this.m_chkInPatient12.Tag = "2";
            this.m_chkInPatient12.Text = "缺有鉴别诊断意义的阴性体征\r\n";
            // 
            // m_chkInPatient10
            // 
            this.m_chkInPatient10.AccessibleDescription = "m_txtInPatient10";
            this.m_chkInPatient10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient10.Location = new System.Drawing.Point(57, 186);
            this.m_chkInPatient10.Name = "m_chkInPatient10";
            this.m_chkInPatient10.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient10.TabIndex = 105;
            this.m_chkInPatient10.Tag = "0.5";
            this.m_chkInPatient10.Text = "体格检查一般项目遗漏\r\n";
            this.m_tipMain.SetToolTip(this.m_chkInPatient10, "体格检查项目 ，记录全面系统，有专科重点检查。");
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(449, 6);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(13, 13);
            this.label45.TabIndex = 130;
            this.label45.Text = "5";
            this.m_tipMain.SetToolTip(this.label45, "入院24小时内由住院医师完成");
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(449, 26);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(39, 13);
            this.label46.TabIndex = 128;
            this.label46.Text = "0.5/项";
            // 
            // label47
            // 
            this.label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label47.Location = new System.Drawing.Point(57, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(650, 1);
            this.label47.TabIndex = 76;
            this.label47.Text = "label3";
            // 
            // m_txtInPatient2
            // 
            this.m_txtInPatient2.AccessibleDescription = "一般项目填写不全\r\n";
            this.m_txtInPatient2.Location = new System.Drawing.Point(529, 22);
            this.m_txtInPatient2.Name = "m_txtInPatient2";
            this.m_txtInPatient2.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient2.TabIndex = 140;
            this.m_txtInPatient2.Tag = "0.5";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(449, 66);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(13, 13);
            this.label48.TabIndex = 132;
            this.label48.Text = "1";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(449, 46);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(13, 13);
            this.label49.TabIndex = 131;
            this.label49.Text = "1";
            // 
            // label50
            // 
            this.label50.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label50.Location = new System.Drawing.Point(57, 62);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(650, 1);
            this.label50.TabIndex = 92;
            this.label50.Text = "label3";
            // 
            // m_txtInPatient4
            // 
            this.m_txtInPatient4.AccessibleDescription = "有症状（或体征）而以诊断代替主诉\r\n";
            this.m_txtInPatient4.Location = new System.Drawing.Point(529, 62);
            this.m_txtInPatient4.Name = "m_txtInPatient4";
            this.m_txtInPatient4.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient4.TabIndex = 138;
            this.m_txtInPatient4.Tag = "1";
            // 
            // m_txtInPatient3
            // 
            this.m_txtInPatient3.AccessibleDescription = "主诉描述有缺陷\r\n";
            this.m_txtInPatient3.Location = new System.Drawing.Point(529, 42);
            this.m_txtInPatient3.Name = "m_txtInPatient3";
            this.m_txtInPatient3.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient3.TabIndex = 151;
            this.m_txtInPatient3.Tag = "1";
            // 
            // m_txtInPatient8
            // 
            this.m_txtInPatient8.AccessibleDescription = "缺必要的鉴别诊断资料\r\n";
            this.m_txtInPatient8.Location = new System.Drawing.Point(529, 142);
            this.m_txtInPatient8.Name = "m_txtInPatient8";
            this.m_txtInPatient8.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient8.TabIndex = 150;
            this.m_txtInPatient8.Tag = "2";
            // 
            // m_txtInPatient7
            // 
            this.m_txtInPatient7.AccessibleDescription = "叙述混乱、颠倒、层次不清\r\n";
            this.m_txtInPatient7.Location = new System.Drawing.Point(529, 122);
            this.m_txtInPatient7.Name = "m_txtInPatient7";
            this.m_txtInPatient7.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient7.TabIndex = 149;
            this.m_txtInPatient7.Tag = "2";
            // 
            // m_txtInPatient6
            // 
            this.m_txtInPatient6.AccessibleDescription = "发病诱因、主要疾病发展变化过程、诊治情况叙述不清，描述不准确\r\n";
            this.m_txtInPatient6.Location = new System.Drawing.Point(529, 102);
            this.m_txtInPatient6.Name = "m_txtInPatient6";
            this.m_txtInPatient6.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient6.TabIndex = 155;
            this.m_txtInPatient6.Tag = "2";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(449, 106);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(29, 13);
            this.label51.TabIndex = 133;
            this.label51.Text = "2/项";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(449, 86);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(13, 13);
            this.label52.TabIndex = 129;
            this.label52.Text = "3";
            this.m_tipMain.SetToolTip(this.label52, "现病史必须与主诉相关、相符，能反映本次疾病起始、演变、诊疗过程及一般情况变化，重点突出、概念明确，运用术语准确，有鉴别诊断资料。");
            // 
            // m_txtInPatient5
            // 
            this.m_txtInPatient5.AccessibleDescription = "现病史描述主要症状不明确\r\n";
            this.m_txtInPatient5.Location = new System.Drawing.Point(529, 82);
            this.m_txtInPatient5.Name = "m_txtInPatient5";
            this.m_txtInPatient5.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient5.TabIndex = 145;
            this.m_txtInPatient5.Tag = "3";
            this.m_tipMain.SetToolTip(this.m_txtInPatient5, "现病史必须与主诉相关、相符，能反映本次疾病起始、演变、诊疗过程及一般情况变化，重点突出、概念明确，运用术语准确，有鉴别诊断资料。");
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(449, 146);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(13, 13);
            this.label53.TabIndex = 135;
            this.label53.Text = "2";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(449, 126);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(13, 13);
            this.label54.TabIndex = 134;
            this.label54.Text = "2";
            // 
            // label55
            // 
            this.label55.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label55.Location = new System.Drawing.Point(57, 102);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(650, 1);
            this.label55.TabIndex = 91;
            this.label55.Text = "label3";
            // 
            // label56
            // 
            this.label56.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label56.Location = new System.Drawing.Point(57, 142);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(650, 1);
            this.label56.TabIndex = 86;
            this.label56.Text = "label3";
            // 
            // label57
            // 
            this.label57.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label57.Location = new System.Drawing.Point(57, 302);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(650, 1);
            this.label57.TabIndex = 87;
            this.label57.Text = "label3";
            // 
            // m_txtInPatient12
            // 
            this.m_txtInPatient12.AccessibleDescription = "缺有鉴别诊断意义的阴性体征\r\n";
            this.m_txtInPatient12.Location = new System.Drawing.Point(529, 222);
            this.m_txtInPatient12.Name = "m_txtInPatient12";
            this.m_txtInPatient12.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient12.TabIndex = 148;
            this.m_txtInPatient12.Tag = "2";
            // 
            // m_txtInPatient11
            // 
            this.m_txtInPatient11.AccessibleDescription = "★体格检查遗漏系统或主要阳性体征\r\n";
            this.m_txtInPatient11.Location = new System.Drawing.Point(529, 202);
            this.m_txtInPatient11.Name = "m_txtInPatient11";
            this.m_txtInPatient11.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient11.TabIndex = 146;
            this.m_txtInPatient11.Tag = "乙级";
            // 
            // m_txtInPatient10
            // 
            this.m_txtInPatient10.AccessibleDescription = "体格检查一般项目遗漏\r\n";
            this.m_txtInPatient10.Location = new System.Drawing.Point(529, 182);
            this.m_txtInPatient10.Name = "m_txtInPatient10";
            this.m_txtInPatient10.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient10.TabIndex = 147;
            this.m_txtInPatient10.Tag = "0.5";
            // 
            // label58
            // 
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label58.Location = new System.Drawing.Point(57, 262);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(650, 1);
            this.label58.TabIndex = 90;
            this.label58.Text = "label3";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(449, 186);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(39, 13);
            this.label59.TabIndex = 117;
            this.label59.Text = "0.5/项";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(449, 166);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(29, 13);
            this.label60.TabIndex = 116;
            this.label60.Text = "2/项";
            this.m_tipMain.SetToolTip(this.label60, "? 既往史、个人史、月经生育史、家族史齐全，传染病有流行病史，小儿有喂养史。");
            // 
            // m_txtInPatient15
            // 
            this.m_txtInPatient15.AccessibleDescription = "必要的辅助检查空缺\r\n";
            this.m_txtInPatient15.Location = new System.Drawing.Point(529, 282);
            this.m_txtInPatient15.Name = "m_txtInPatient15";
            this.m_txtInPatient15.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient15.TabIndex = 141;
            this.m_txtInPatient15.Tag = "2";
            // 
            // m_txtInPatient14
            // 
            this.m_txtInPatient14.AccessibleDescription = "★缺必要的专科或重点检查\r\n";
            this.m_txtInPatient14.Location = new System.Drawing.Point(529, 262);
            this.m_txtInPatient14.Name = "m_txtInPatient14";
            this.m_txtInPatient14.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient14.TabIndex = 143;
            this.m_txtInPatient14.Tag = "乙级";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(449, 266);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(31, 13);
            this.label61.TabIndex = 123;
            this.label61.Text = "乙级";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(449, 246);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(13, 13);
            this.label62.TabIndex = 125;
            this.label62.Text = "1";
            // 
            // m_txtInPatient13
            // 
            this.m_txtInPatient13.AccessibleDescription = "体格检查记录描述不规范\r\n";
            this.m_txtInPatient13.Location = new System.Drawing.Point(529, 242);
            this.m_txtInPatient13.Name = "m_txtInPatient13";
            this.m_txtInPatient13.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient13.TabIndex = 152;
            this.m_txtInPatient13.Tag = "1";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(449, 306);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(31, 13);
            this.label63.TabIndex = 126;
            this.label63.Text = "丙级";
            // 
            // m_txtInPatient9
            // 
            this.m_txtInPatient9.AccessibleDescription = "缺四史（既往史、个人史、婚育史、家族史）\r\n";
            this.m_txtInPatient9.Location = new System.Drawing.Point(529, 162);
            this.m_txtInPatient9.Name = "m_txtInPatient9";
            this.m_txtInPatient9.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient9.TabIndex = 154;
            this.m_txtInPatient9.Tag = "2";
            this.m_tipMain.SetToolTip(this.m_txtInPatient9, "? 既往史、个人史、月经生育史、家族史齐全，传染病有流行病史，小儿有喂养史。");
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(449, 226);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(13, 13);
            this.label64.TabIndex = 118;
            this.label64.Text = "2";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(449, 286);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(13, 13);
            this.label65.TabIndex = 119;
            this.label65.Text = "2";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(449, 206);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(31, 13);
            this.label66.TabIndex = 121;
            this.label66.Text = "乙级";
            // 
            // label67
            // 
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label67.Location = new System.Drawing.Point(57, 182);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(650, 1);
            this.label67.TabIndex = 94;
            this.label67.Text = "label3";
            // 
            // label68
            // 
            this.label68.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label68.Location = new System.Drawing.Point(57, 222);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(650, 1);
            this.label68.TabIndex = 93;
            this.label68.Text = "label3";
            // 
            // m_txtInPatient16
            // 
            this.m_txtInPatient16.AccessibleDescription = "★主要疾病漏诊";
            this.m_txtInPatient16.Location = new System.Drawing.Point(529, 302);
            this.m_txtInPatient16.Name = "m_txtInPatient16";
            this.m_txtInPatient16.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient16.TabIndex = 137;
            this.m_txtInPatient16.Tag = "丙级";
            // 
            // label69
            // 
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label69.Location = new System.Drawing.Point(57, 162);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(650, 1);
            this.label69.TabIndex = 85;
            this.label69.Text = "label3";
            // 
            // label70
            // 
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label70.Location = new System.Drawing.Point(57, 322);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(650, 1);
            this.label70.TabIndex = 77;
            this.label70.Text = "label3";
            // 
            // label71
            // 
            this.label71.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label71.Location = new System.Drawing.Point(57, 202);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(650, 1);
            this.label71.TabIndex = 79;
            this.label71.Text = "label3";
            // 
            // label72
            // 
            this.label72.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label72.Location = new System.Drawing.Point(57, 122);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(650, 1);
            this.label72.TabIndex = 82;
            this.label72.Text = "label3";
            // 
            // label73
            // 
            this.label73.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label73.Location = new System.Drawing.Point(57, 282);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(650, 1);
            this.label73.TabIndex = 84;
            this.label73.Text = "label3";
            // 
            // label74
            // 
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label74.Location = new System.Drawing.Point(57, 242);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(650, 1);
            this.label74.TabIndex = 80;
            this.label74.Text = "label3";
            // 
            // label75
            // 
            this.label75.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label75.Location = new System.Drawing.Point(57, 42);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(650, 1);
            this.label75.TabIndex = 81;
            this.label75.Text = "label3";
            // 
            // label76
            // 
            this.label76.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label76.Location = new System.Drawing.Point(57, 82);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(650, 1);
            this.label76.TabIndex = 95;
            this.label76.Text = "label3";
            // 
            // m_chkInPatient18
            // 
            this.m_chkInPatient18.AccessibleDescription = "m_txtInPatient18";
            this.m_chkInPatient18.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient18.Location = new System.Drawing.Point(57, 346);
            this.m_chkInPatient18.Name = "m_chkInPatient18";
            this.m_chkInPatient18.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient18.TabIndex = 112;
            this.m_chkInPatient18.Tag = "2";
            this.m_chkInPatient18.Text = "应有而无最后诊断或修正诊断";
            // 
            // m_chkInPatient20
            // 
            this.m_chkInPatient20.AccessibleDescription = "m_txtInPatient20";
            this.m_chkInPatient20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient20.Location = new System.Drawing.Point(57, 386);
            this.m_chkInPatient20.Name = "m_chkInPatient20";
            this.m_chkInPatient20.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient20.TabIndex = 114;
            this.m_chkInPatient20.Tag = "2";
            this.m_chkInPatient20.Text = "48小时内无主治医师审核签字\r\n";
            // 
            // m_chkInPatient17
            // 
            this.m_chkInPatient17.AccessibleDescription = "m_txtInPatient17";
            this.m_chkInPatient17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient17.Location = new System.Drawing.Point(57, 326);
            this.m_chkInPatient17.Name = "m_chkInPatient17";
            this.m_chkInPatient17.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient17.TabIndex = 108;
            this.m_chkInPatient17.Tag = "2";
            this.m_chkInPatient17.Text = "诊断不确切、依据不充分\r\n";
            // 
            // m_chkInPatient19
            // 
            this.m_chkInPatient19.AccessibleDescription = "m_txtInPatient19";
            this.m_chkInPatient19.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkInPatient19.Location = new System.Drawing.Point(57, 366);
            this.m_chkInPatient19.Name = "m_chkInPatient19";
            this.m_chkInPatient19.Size = new System.Drawing.Size(236, 16);
            this.m_chkInPatient19.TabIndex = 103;
            this.m_chkInPatient19.Tag = "2";
            this.m_chkInPatient19.Text = "无医师签字\r\n";
            // 
            // label154
            // 
            this.label154.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label154.Location = new System.Drawing.Point(57, 382);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(650, 1);
            this.label154.TabIndex = 88;
            this.label154.Text = "label3";
            // 
            // label155
            // 
            this.label155.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label155.Location = new System.Drawing.Point(57, 342);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(650, 1);
            this.label155.TabIndex = 89;
            this.label155.Text = "label3";
            // 
            // m_txtInPatient19
            // 
            this.m_txtInPatient19.AccessibleDescription = "无医师签字\r\n";
            this.m_txtInPatient19.Location = new System.Drawing.Point(529, 362);
            this.m_txtInPatient19.Name = "m_txtInPatient19";
            this.m_txtInPatient19.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient19.TabIndex = 142;
            this.m_txtInPatient19.Tag = "2";
            // 
            // m_txtInPatient18
            // 
            this.m_txtInPatient18.AccessibleDescription = "应有而无最后诊断或修正诊断";
            this.m_txtInPatient18.Location = new System.Drawing.Point(529, 342);
            this.m_txtInPatient18.Name = "m_txtInPatient18";
            this.m_txtInPatient18.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient18.TabIndex = 144;
            this.m_txtInPatient18.Tag = "2";
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(449, 346);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(13, 13);
            this.label156.TabIndex = 122;
            this.label156.Tag = "";
            this.label156.Text = "2";
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(449, 326);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(13, 13);
            this.label157.TabIndex = 124;
            this.label157.Text = "2";
            // 
            // m_txtInPatient17
            // 
            this.m_txtInPatient17.AccessibleDescription = "诊断不确切、依据不充分\r\n";
            this.m_txtInPatient17.Location = new System.Drawing.Point(529, 322);
            this.m_txtInPatient17.Name = "m_txtInPatient17";
            this.m_txtInPatient17.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient17.TabIndex = 153;
            this.m_txtInPatient17.Tag = "2";
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(449, 386);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(13, 13);
            this.label158.TabIndex = 127;
            this.label158.Text = "2";
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(449, 366);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(13, 13);
            this.label159.TabIndex = 120;
            this.label159.Text = "2";
            // 
            // m_txtInPatient20
            // 
            this.m_txtInPatient20.AccessibleDescription = "48小时内无主治医师审核签字\r\n";
            this.m_txtInPatient20.Location = new System.Drawing.Point(529, 382);
            this.m_txtInPatient20.Name = "m_txtInPatient20";
            this.m_txtInPatient20.Size = new System.Drawing.Size(100, 20);
            this.m_txtInPatient20.TabIndex = 136;
            this.m_txtInPatient20.Tag = "2";
            // 
            // label160
            // 
            this.label160.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label160.Location = new System.Drawing.Point(57, 402);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(650, 1);
            this.label160.TabIndex = 78;
            this.label160.Text = "label3";
            // 
            // label161
            // 
            this.label161.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label161.Location = new System.Drawing.Point(57, 362);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(650, 1);
            this.label161.TabIndex = 83;
            this.label161.Text = "label3";
            // 
            // m_lklCalInPatResult
            // 
            this.m_lklCalInPatResult.AutoSize = true;
            this.m_lklCalInPatResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lklCalInPatResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_lklCalInPatResult.LinkColor = System.Drawing.Color.Red;
            this.m_lklCalInPatResult.Location = new System.Drawing.Point(576, 8);
            this.m_lklCalInPatResult.Name = "m_lklCalInPatResult";
            this.m_lklCalInPatResult.Size = new System.Drawing.Size(67, 13);
            this.m_lklCalInPatResult.TabIndex = 147;
            this.m_lklCalInPatResult.TabStop = true;
            this.m_lklCalInPatResult.Text = "计算扣分：";
            this.m_tipMain.SetToolTip(this.m_lklCalInPatResult, "点击计算本页面的总扣分");
            this.m_lklCalInPatResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklCalInPatResult_LinkClicked);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(116, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(55, 13);
            this.label40.TabIndex = 56;
            this.label40.Text = "缺陷内容";
            // 
            // label41
            // 
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label41.Location = new System.Drawing.Point(36, 32);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(708, 4);
            this.label41.TabIndex = 21;
            this.label41.Text = "label41";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.ForeColor = System.Drawing.Color.Green;
            this.label42.Location = new System.Drawing.Point(4, 4);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(102, 15);
            this.label42.TabIndex = 5;
            this.label42.Text = "标准分值：  20 分";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(420, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(55, 13);
            this.label43.TabIndex = 57;
            this.label43.Text = "扣分标准";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(532, 16);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(37, 13);
            this.label44.TabIndex = 54;
            this.label44.Text = "扣  分";
            // 
            // m_txtInPatResult
            // 
            this.m_txtInPatResult.AccessibleDescription = "入院记录扣分";
            this.m_txtInPatResult.AccessibleName = "";
            this.m_txtInPatResult.Location = new System.Drawing.Point(644, 4);
            this.m_txtInPatResult.Name = "m_txtInPatResult";
            this.m_txtInPatResult.ReadOnly = true;
            this.m_txtInPatResult.Size = new System.Drawing.Size(48, 20);
            this.m_txtInPatResult.TabIndex = 63;
            this.m_tipMain.SetToolTip(this.m_txtInPatResult, "扣分结果以标准分值为最");
            // 
            // m_lblInPatGeade
            // 
            this.m_lblInPatGeade.AutoSize = true;
            this.m_lblInPatGeade.Location = new System.Drawing.Point(696, 6);
            this.m_lblInPatGeade.Name = "m_lblInPatGeade";
            this.m_lblInPatGeade.Size = new System.Drawing.Size(0, 13);
            this.m_lblInPatGeade.TabIndex = 50;
            this.m_tipMain.SetToolTip(this.m_lblInPatGeade, "入院24小时内由住院医师完成");
            // 
            // tbpDiseaseTrack
            // 
            this.tbpDiseaseTrack.BackColor = System.Drawing.SystemColors.Control;
            this.tbpDiseaseTrack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpDiseaseTrack.Controls.Add(this.m_lklCalDisease);
            this.tbpDiseaseTrack.Controls.Add(this.label163);
            this.tbpDiseaseTrack.Controls.Add(this.label118);
            this.tbpDiseaseTrack.Controls.Add(this.m_txtDiseaseResult);
            this.tbpDiseaseTrack.Controls.Add(this.m_rdbOne);
            this.tbpDiseaseTrack.Controls.Add(this.m_rdbTwo);
            this.tbpDiseaseTrack.Controls.Add(this.m_lblDisGrade);
            this.tbpDiseaseTrack.Controls.Add(this.pnlDiseaseTrack2);
            this.tbpDiseaseTrack.Controls.Add(this.pnlDiseaseTrack1);
            this.tbpDiseaseTrack.Location = new System.Drawing.Point(0, 25);
            this.tbpDiseaseTrack.Name = "tbpDiseaseTrack";
            this.tbpDiseaseTrack.Selected = false;
            this.tbpDiseaseTrack.Size = new System.Drawing.Size(768, 447);
            this.tbpDiseaseTrack.TabIndex = 5;
            this.tbpDiseaseTrack.Title = "病程记录";
            this.tbpDiseaseTrack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // m_lklCalDisease
            // 
            this.m_lklCalDisease.AutoSize = true;
            this.m_lklCalDisease.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lklCalDisease.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_lklCalDisease.LinkColor = System.Drawing.Color.Red;
            this.m_lklCalDisease.Location = new System.Drawing.Point(572, 12);
            this.m_lklCalDisease.Name = "m_lklCalDisease";
            this.m_lklCalDisease.Size = new System.Drawing.Size(67, 13);
            this.m_lklCalDisease.TabIndex = 146;
            this.m_lklCalDisease.TabStop = true;
            this.m_lklCalDisease.Text = "计算扣分：";
            this.m_tipMain.SetToolTip(this.m_lklCalDisease, "点击计算本页面的总扣分");
            this.m_lklCalDisease.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklCalDisease_LinkClicked);
            // 
            // label163
            // 
            this.label163.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label163.Location = new System.Drawing.Point(4, 92);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(26, 1);
            this.label163.TabIndex = 144;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label118.ForeColor = System.Drawing.Color.Green;
            this.label118.Location = new System.Drawing.Point(8, 8);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(102, 15);
            this.label118.TabIndex = 76;
            this.label118.Text = "标准分值：  40 分";
            // 
            // m_txtDiseaseResult
            // 
            this.m_txtDiseaseResult.AccessibleDescription = "病程记录扣分";
            this.m_txtDiseaseResult.Location = new System.Drawing.Point(640, 8);
            this.m_txtDiseaseResult.Name = "m_txtDiseaseResult";
            this.m_txtDiseaseResult.ReadOnly = true;
            this.m_txtDiseaseResult.Size = new System.Drawing.Size(56, 20);
            this.m_txtDiseaseResult.TabIndex = 142;
            this.m_tipMain.SetToolTip(this.m_txtDiseaseResult, "扣分结果以标准分值为最");
            // 
            // m_rdbOne
            // 
            this.m_rdbOne.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_rdbOne.BackColor = System.Drawing.Color.White;
            this.m_rdbOne.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_rdbOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_rdbOne.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_rdbOne.Location = new System.Drawing.Point(4, 40);
            this.m_rdbOne.Name = "m_rdbOne";
            this.m_rdbOne.Size = new System.Drawing.Size(28, 48);
            this.m_rdbOne.TabIndex = 143;
            this.m_rdbOne.Text = "第一页";
            this.m_rdbOne.UseVisualStyleBackColor = false;
            this.m_rdbOne.CheckedChanged += new System.EventHandler(this.m_rdb_CheckedChanged);
            // 
            // m_rdbTwo
            // 
            this.m_rdbTwo.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_rdbTwo.BackColor = System.Drawing.Color.Silver;
            this.m_rdbTwo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_rdbTwo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_rdbTwo.ForeColor = System.Drawing.Color.DimGray;
            this.m_rdbTwo.Location = new System.Drawing.Point(4, 96);
            this.m_rdbTwo.Name = "m_rdbTwo";
            this.m_rdbTwo.Size = new System.Drawing.Size(28, 48);
            this.m_rdbTwo.TabIndex = 143;
            this.m_rdbTwo.Text = "第二页";
            this.m_rdbTwo.UseVisualStyleBackColor = false;
            this.m_rdbTwo.CheckedChanged += new System.EventHandler(this.m_rdb_CheckedChanged);
            // 
            // m_lblDisGrade
            // 
            this.m_lblDisGrade.AutoSize = true;
            this.m_lblDisGrade.Location = new System.Drawing.Point(700, 10);
            this.m_lblDisGrade.Name = "m_lblDisGrade";
            this.m_lblDisGrade.Size = new System.Drawing.Size(0, 13);
            this.m_lblDisGrade.TabIndex = 129;
            this.m_lblDisGrade.Tag = "";
            // 
            // pnlDiseaseTrack2
            // 
            this.pnlDiseaseTrack2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne1);
            this.pnlDiseaseTrack2.Controls.Add(this.label165);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne1);
            this.pnlDiseaseTrack2.Controls.Add(this.label166);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne2);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne3);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne4);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne7);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne5);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne8);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne6);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne11);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne14);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne16);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne13);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne15);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne9);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne12);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne10);
            this.pnlDiseaseTrack2.Controls.Add(this.label167);
            this.pnlDiseaseTrack2.Controls.Add(this.label168);
            this.pnlDiseaseTrack2.Controls.Add(this.label169);
            this.pnlDiseaseTrack2.Controls.Add(this.label170);
            this.pnlDiseaseTrack2.Controls.Add(this.label171);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne2);
            this.pnlDiseaseTrack2.Controls.Add(this.label172);
            this.pnlDiseaseTrack2.Controls.Add(this.label173);
            this.pnlDiseaseTrack2.Controls.Add(this.label174);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne4);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne3);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne8);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne7);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne6);
            this.pnlDiseaseTrack2.Controls.Add(this.label175);
            this.pnlDiseaseTrack2.Controls.Add(this.label176);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne5);
            this.pnlDiseaseTrack2.Controls.Add(this.label177);
            this.pnlDiseaseTrack2.Controls.Add(this.label178);
            this.pnlDiseaseTrack2.Controls.Add(this.label179);
            this.pnlDiseaseTrack2.Controls.Add(this.label180);
            this.pnlDiseaseTrack2.Controls.Add(this.label181);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne12);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne11);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne10);
            this.pnlDiseaseTrack2.Controls.Add(this.label182);
            this.pnlDiseaseTrack2.Controls.Add(this.label183);
            this.pnlDiseaseTrack2.Controls.Add(this.label184);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne15);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne14);
            this.pnlDiseaseTrack2.Controls.Add(this.label185);
            this.pnlDiseaseTrack2.Controls.Add(this.label186);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne13);
            this.pnlDiseaseTrack2.Controls.Add(this.label187);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne9);
            this.pnlDiseaseTrack2.Controls.Add(this.label188);
            this.pnlDiseaseTrack2.Controls.Add(this.label189);
            this.pnlDiseaseTrack2.Controls.Add(this.label190);
            this.pnlDiseaseTrack2.Controls.Add(this.label191);
            this.pnlDiseaseTrack2.Controls.Add(this.label192);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne16);
            this.pnlDiseaseTrack2.Controls.Add(this.label193);
            this.pnlDiseaseTrack2.Controls.Add(this.label194);
            this.pnlDiseaseTrack2.Controls.Add(this.label195);
            this.pnlDiseaseTrack2.Controls.Add(this.label196);
            this.pnlDiseaseTrack2.Controls.Add(this.label197);
            this.pnlDiseaseTrack2.Controls.Add(this.label198);
            this.pnlDiseaseTrack2.Controls.Add(this.label199);
            this.pnlDiseaseTrack2.Controls.Add(this.label200);
            this.pnlDiseaseTrack2.Controls.Add(this.m_chkDiseaseOne17);
            this.pnlDiseaseTrack2.Controls.Add(this.label201);
            this.pnlDiseaseTrack2.Controls.Add(this.label202);
            this.pnlDiseaseTrack2.Controls.Add(this.m_txtDiseaseOne17);
            this.pnlDiseaseTrack2.Location = new System.Drawing.Point(32, 40);
            this.pnlDiseaseTrack2.Name = "pnlDiseaseTrack2";
            this.pnlDiseaseTrack2.Size = new System.Drawing.Size(732, 404);
            this.pnlDiseaseTrack2.TabIndex = 145;
            this.pnlDiseaseTrack2.Visible = false;
            this.pnlDiseaseTrack2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // m_txtDiseaseOne1
            // 
            this.m_txtDiseaseOne1.AccessibleDescription = "上级医师首次查房未在48小时内完成\r\n";
            this.m_txtDiseaseOne1.Location = new System.Drawing.Point(519, 40);
            this.m_txtDiseaseOne1.Name = "m_txtDiseaseOne1";
            this.m_txtDiseaseOne1.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne1.TabIndex = 140;
            this.m_txtDiseaseOne1.Tag = "3";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(123, 8);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(55, 13);
            this.label165.TabIndex = 135;
            this.label165.Text = "缺陷内容";
            // 
            // m_chkDiseaseOne1
            // 
            this.m_chkDiseaseOne1.AccessibleDescription = "m_txtDiseaseOne1";
            this.m_chkDiseaseOne1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne1.Location = new System.Drawing.Point(47, 44);
            this.m_chkDiseaseOne1.Name = "m_chkDiseaseOne1";
            this.m_chkDiseaseOne1.Size = new System.Drawing.Size(237, 16);
            this.m_chkDiseaseOne1.TabIndex = 100;
            this.m_chkDiseaseOne1.Tag = "3";
            this.m_chkDiseaseOne1.Text = "上级医师首次查房未在48小时内完成\r\n";
            // 
            // label166
            // 
            this.label166.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label166.Location = new System.Drawing.Point(32, 28);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(688, 4);
            this.label166.TabIndex = 94;
            this.label166.Text = "label117";
            // 
            // m_chkDiseaseOne2
            // 
            this.m_chkDiseaseOne2.AccessibleDescription = "m_txtDiseaseOne2";
            this.m_chkDiseaseOne2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne2.Location = new System.Drawing.Point(47, 64);
            this.m_chkDiseaseOne2.Name = "m_chkDiseaseOne2";
            this.m_chkDiseaseOne2.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne2.TabIndex = 101;
            this.m_chkDiseaseOne2.Tag = "1";
            this.m_chkDiseaseOne2.Text = "上级医师首次查房记录有缺陷\r\n";
            this.m_tipMain.SetToolTip(this.m_chkDiseaseOne2, "内容包括补充的病史和体征，诊疗计划。");
            // 
            // m_chkDiseaseOne3
            // 
            this.m_chkDiseaseOne3.AccessibleDescription = "m_txtDiseaseOne3";
            this.m_chkDiseaseOne3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne3.Location = new System.Drawing.Point(47, 84);
            this.m_chkDiseaseOne3.Name = "m_chkDiseaseOne3";
            this.m_chkDiseaseOne3.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne3.TabIndex = 102;
            this.m_chkDiseaseOne3.Tag = "2";
            this.m_chkDiseaseOne3.Text = "规定时间内无上级医师查房记录\r\n";
            this.m_tipMain.SetToolTip(this.m_chkDiseaseOne3, "上级医师查房记录：病危患者每天、病重患者3天内、病情稳定患者5天内必须有上级医师查房记录，疑难危重病人必须有主任或副主任医师以上人员的查房记录。");
            // 
            // m_chkDiseaseOne4
            // 
            this.m_chkDiseaseOne4.AccessibleDescription = "m_txtDiseaseOne4";
            this.m_chkDiseaseOne4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne4.Location = new System.Drawing.Point(47, 104);
            this.m_chkDiseaseOne4.Name = "m_chkDiseaseOne4";
            this.m_chkDiseaseOne4.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne4.TabIndex = 99;
            this.m_chkDiseaseOne4.Tag = "-1";
            this.m_chkDiseaseOne4.Text = "★择期手术缺术前小结\r\n";
            // 
            // m_chkDiseaseOne7
            // 
            this.m_chkDiseaseOne7.AccessibleDescription = "m_txtDiseaseOne7";
            this.m_chkDiseaseOne7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne7.Location = new System.Drawing.Point(47, 164);
            this.m_chkDiseaseOne7.Name = "m_chkDiseaseOne7";
            this.m_chkDiseaseOne7.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne7.TabIndex = 96;
            this.m_chkDiseaseOne7.Tag = "2";
            this.m_chkDiseaseOne7.Text = "缺麻醉医师术前看过病人的记录\r\n";
            // 
            // m_chkDiseaseOne5
            // 
            this.m_chkDiseaseOne5.AccessibleDescription = "m_txtDiseaseOne5";
            this.m_chkDiseaseOne5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne5.Location = new System.Drawing.Point(47, 124);
            this.m_chkDiseaseOne5.Name = "m_chkDiseaseOne5";
            this.m_chkDiseaseOne5.Size = new System.Drawing.Size(265, 16);
            this.m_chkDiseaseOne5.TabIndex = 97;
            this.m_chkDiseaseOne5.Tag = "-1";
            this.m_chkDiseaseOne5.Text = "★病情较重或难度较大的手术缺术前讨论记录";
            // 
            // m_chkDiseaseOne8
            // 
            this.m_chkDiseaseOne8.AccessibleDescription = "m_txtDiseaseOne8";
            this.m_chkDiseaseOne8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne8.Location = new System.Drawing.Point(47, 184);
            this.m_chkDiseaseOne8.Name = "m_chkDiseaseOne8";
            this.m_chkDiseaseOne8.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne8.TabIndex = 98;
            this.m_chkDiseaseOne8.Tag = "-2";
            this.m_chkDiseaseOne8.Text = "★缺麻醉记录单\r\n";
            // 
            // m_chkDiseaseOne6
            // 
            this.m_chkDiseaseOne6.AccessibleDescription = "m_txtDiseaseOne6";
            this.m_chkDiseaseOne6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne6.Location = new System.Drawing.Point(47, 144);
            this.m_chkDiseaseOne6.Name = "m_chkDiseaseOne6";
            this.m_chkDiseaseOne6.Size = new System.Drawing.Size(261, 16);
            this.m_chkDiseaseOne6.TabIndex = 111;
            this.m_chkDiseaseOne6.Tag = "2";
            this.m_chkDiseaseOne6.Text = "缺术前手术者查看病人的记录\r\n";
            // 
            // m_chkDiseaseOne11
            // 
            this.m_chkDiseaseOne11.AccessibleDescription = "m_txtDiseaseOne11";
            this.m_chkDiseaseOne11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne11.Location = new System.Drawing.Point(47, 244);
            this.m_chkDiseaseOne11.Name = "m_chkDiseaseOne11";
            this.m_chkDiseaseOne11.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne11.TabIndex = 110;
            this.m_chkDiseaseOne11.Tag = "2";
            this.m_chkDiseaseOne11.Text = "手术记录内容有明显缺陷\r\n";
            // 
            // m_chkDiseaseOne14
            // 
            this.m_chkDiseaseOne14.AccessibleDescription = "m_txtDiseaseOne14";
            this.m_chkDiseaseOne14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne14.Location = new System.Drawing.Point(47, 304);
            this.m_chkDiseaseOne14.Name = "m_chkDiseaseOne14";
            this.m_chkDiseaseOne14.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne14.TabIndex = 112;
            this.m_chkDiseaseOne14.Tag = "3";
            this.m_chkDiseaseOne14.Text = "缺术后当天病程记录\r\n";
            // 
            // m_chkDiseaseOne16
            // 
            this.m_chkDiseaseOne16.AccessibleDescription = "m_txtDiseaseOne16";
            this.m_chkDiseaseOne16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne16.Location = new System.Drawing.Point(47, 344);
            this.m_chkDiseaseOne16.Name = "m_chkDiseaseOne16";
            this.m_chkDiseaseOne16.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne16.TabIndex = 114;
            this.m_chkDiseaseOne16.Tag = "1";
            this.m_chkDiseaseOne16.Text = "术后三天病程记录不连续\r\n";
            // 
            // m_chkDiseaseOne13
            // 
            this.m_chkDiseaseOne13.AccessibleDescription = "m_txtDiseaseOne13";
            this.m_chkDiseaseOne13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne13.Location = new System.Drawing.Point(47, 284);
            this.m_chkDiseaseOne13.Name = "m_chkDiseaseOne13";
            this.m_chkDiseaseOne13.Size = new System.Drawing.Size(245, 16);
            this.m_chkDiseaseOne13.TabIndex = 108;
            this.m_chkDiseaseOne13.Tag = "3";
            this.m_chkDiseaseOne13.Text = "手术记录由第一助手书写而无手术者签字\r\n";
            // 
            // m_chkDiseaseOne15
            // 
            this.m_chkDiseaseOne15.AccessibleDescription = "m_txtDiseaseOne15";
            this.m_chkDiseaseOne15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne15.Location = new System.Drawing.Point(47, 324);
            this.m_chkDiseaseOne15.Name = "m_chkDiseaseOne15";
            this.m_chkDiseaseOne15.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne15.TabIndex = 103;
            this.m_chkDiseaseOne15.Tag = "1";
            this.m_chkDiseaseOne15.Text = "术后病程记录有缺陷\r\n";
            // 
            // m_chkDiseaseOne9
            // 
            this.m_chkDiseaseOne9.AccessibleDescription = "m_txtDiseaseOne9";
            this.m_chkDiseaseOne9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne9.Location = new System.Drawing.Point(47, 204);
            this.m_chkDiseaseOne9.Name = "m_chkDiseaseOne9";
            this.m_chkDiseaseOne9.Size = new System.Drawing.Size(264, 16);
            this.m_chkDiseaseOne9.TabIndex = 107;
            this.m_chkDiseaseOne9.Tag = "1";
            this.m_chkDiseaseOne9.Text = "麻醉记录单有缺陷\r\n";
            // 
            // m_chkDiseaseOne12
            // 
            this.m_chkDiseaseOne12.AccessibleDescription = "m_txtDiseaseOne12";
            this.m_chkDiseaseOne12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne12.Location = new System.Drawing.Point(47, 264);
            this.m_chkDiseaseOne12.Name = "m_chkDiseaseOne12";
            this.m_chkDiseaseOne12.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne12.TabIndex = 106;
            this.m_chkDiseaseOne12.Tag = "5";
            this.m_chkDiseaseOne12.Text = "手术记录未在术后24小时内完成";
            // 
            // m_chkDiseaseOne10
            // 
            this.m_chkDiseaseOne10.AccessibleDescription = "m_txtDiseaseOne10";
            this.m_chkDiseaseOne10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne10.Location = new System.Drawing.Point(47, 224);
            this.m_chkDiseaseOne10.Name = "m_chkDiseaseOne10";
            this.m_chkDiseaseOne10.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne10.TabIndex = 105;
            this.m_chkDiseaseOne10.Tag = "-2";
            this.m_chkDiseaseOne10.Text = "★缺手术记录\r\n";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(427, 8);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(55, 13);
            this.label167.TabIndex = 136;
            this.label167.Text = "扣分标准";
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(539, 8);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(37, 13);
            this.label168.TabIndex = 133;
            this.label168.Text = "扣  分";
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Location = new System.Drawing.Point(439, 44);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(13, 13);
            this.label169.TabIndex = 129;
            this.label169.Tag = "";
            this.label169.Text = "3";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Location = new System.Drawing.Point(439, 64);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(13, 13);
            this.label170.TabIndex = 127;
            this.label170.Tag = "";
            this.label170.Text = "1";
            this.m_tipMain.SetToolTip(this.label170, "内容包括补充的病史和体征，诊疗计划。");
            // 
            // label171
            // 
            this.label171.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label171.Location = new System.Drawing.Point(47, 60);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(650, 1);
            this.label171.TabIndex = 77;
            this.label171.Text = "label3";
            // 
            // m_txtDiseaseOne2
            // 
            this.m_txtDiseaseOne2.AccessibleDescription = "上级医师首次查房记录有缺陷\r\n";
            this.m_txtDiseaseOne2.Location = new System.Drawing.Point(519, 60);
            this.m_txtDiseaseOne2.Name = "m_txtDiseaseOne2";
            this.m_txtDiseaseOne2.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne2.TabIndex = 141;
            this.m_txtDiseaseOne2.Tag = "1";
            this.m_tipMain.SetToolTip(this.m_txtDiseaseOne2, "内容包括补充的病史和体征，诊疗计划。");
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Location = new System.Drawing.Point(439, 104);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(31, 13);
            this.label172.TabIndex = 131;
            this.label172.Text = "乙级";
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Location = new System.Drawing.Point(439, 84);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(29, 13);
            this.label173.TabIndex = 130;
            this.label173.Text = "2/次";
            this.m_tipMain.SetToolTip(this.label173, "上级医师查房记录：病危患者每天、病重患者3天内、病情稳定患者5天内必须有上级医师查房记录，疑难危重病人必须有主任或副主任医师以上人员的查房记录。");
            // 
            // label174
            // 
            this.label174.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label174.Location = new System.Drawing.Point(47, 100);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(650, 1);
            this.label174.TabIndex = 91;
            this.label174.Text = "label3";
            // 
            // m_txtDiseaseOne4
            // 
            this.m_txtDiseaseOne4.AccessibleDescription = "★择期手术缺术前小结\r\n";
            this.m_txtDiseaseOne4.Location = new System.Drawing.Point(519, 100);
            this.m_txtDiseaseOne4.Name = "m_txtDiseaseOne4";
            this.m_txtDiseaseOne4.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne4.TabIndex = 139;
            this.m_txtDiseaseOne4.Tag = "乙级";
            // 
            // m_txtDiseaseOne3
            // 
            this.m_txtDiseaseOne3.AccessibleDescription = "规定时间内无上级医师查房记录\r\n";
            this.m_txtDiseaseOne3.Location = new System.Drawing.Point(519, 80);
            this.m_txtDiseaseOne3.Name = "m_txtDiseaseOne3";
            this.m_txtDiseaseOne3.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne3.TabIndex = 153;
            this.m_txtDiseaseOne3.Tag = "2";
            this.m_tipMain.SetToolTip(this.m_txtDiseaseOne3, "上级医师查房记录：病危患者每天、病重患者3天内、病情稳定患者5天内必须有上级医师查房记录，疑难危重病人必须有主任或副主任医师以上人员的查房记录。");
            // 
            // m_txtDiseaseOne8
            // 
            this.m_txtDiseaseOne8.AccessibleDescription = "★缺麻醉记录单\r\n";
            this.m_txtDiseaseOne8.Location = new System.Drawing.Point(519, 180);
            this.m_txtDiseaseOne8.Name = "m_txtDiseaseOne8";
            this.m_txtDiseaseOne8.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne8.TabIndex = 152;
            this.m_txtDiseaseOne8.Tag = "丙级";
            // 
            // m_txtDiseaseOne7
            // 
            this.m_txtDiseaseOne7.AccessibleDescription = "缺麻醉医师术前看过病人的记录\r\n";
            this.m_txtDiseaseOne7.Location = new System.Drawing.Point(519, 160);
            this.m_txtDiseaseOne7.Name = "m_txtDiseaseOne7";
            this.m_txtDiseaseOne7.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne7.TabIndex = 151;
            this.m_txtDiseaseOne7.Tag = "2";
            // 
            // m_txtDiseaseOne6
            // 
            this.m_txtDiseaseOne6.AccessibleDescription = "缺术前手术者查看病人的记录\r\n";
            this.m_txtDiseaseOne6.Location = new System.Drawing.Point(519, 140);
            this.m_txtDiseaseOne6.Name = "m_txtDiseaseOne6";
            this.m_txtDiseaseOne6.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne6.TabIndex = 157;
            this.m_txtDiseaseOne6.Tag = "2";
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Location = new System.Drawing.Point(439, 144);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(13, 13);
            this.label175.TabIndex = 132;
            this.label175.Text = "2";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(439, 124);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(31, 13);
            this.label176.TabIndex = 128;
            this.label176.Text = "乙级";
            // 
            // m_txtDiseaseOne5
            // 
            this.m_txtDiseaseOne5.AccessibleDescription = "★病情较重或难度较大的手术缺术前讨论记录";
            this.m_txtDiseaseOne5.Location = new System.Drawing.Point(519, 120);
            this.m_txtDiseaseOne5.Name = "m_txtDiseaseOne5";
            this.m_txtDiseaseOne5.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne5.TabIndex = 147;
            this.m_txtDiseaseOne5.Tag = "乙级";
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(439, 184);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(31, 13);
            this.label177.TabIndex = 137;
            this.label177.Text = "丙级";
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Location = new System.Drawing.Point(439, 164);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(13, 13);
            this.label178.TabIndex = 134;
            this.label178.Text = "2";
            // 
            // label179
            // 
            this.label179.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label179.Location = new System.Drawing.Point(47, 140);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(650, 1);
            this.label179.TabIndex = 90;
            this.label179.Text = "label3";
            // 
            // label180
            // 
            this.label180.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label180.Location = new System.Drawing.Point(47, 180);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(650, 1);
            this.label180.TabIndex = 86;
            this.label180.Text = "label3";
            // 
            // label181
            // 
            this.label181.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label181.Location = new System.Drawing.Point(47, 340);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(650, 1);
            this.label181.TabIndex = 87;
            this.label181.Text = "label3";
            // 
            // m_txtDiseaseOne12
            // 
            this.m_txtDiseaseOne12.AccessibleDescription = "手术记录未在术后24小时内完成";
            this.m_txtDiseaseOne12.Location = new System.Drawing.Point(519, 260);
            this.m_txtDiseaseOne12.Name = "m_txtDiseaseOne12";
            this.m_txtDiseaseOne12.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne12.TabIndex = 150;
            this.m_txtDiseaseOne12.Tag = "5";
            // 
            // m_txtDiseaseOne11
            // 
            this.m_txtDiseaseOne11.AccessibleDescription = "手术记录内容有明显缺陷\r\n";
            this.m_txtDiseaseOne11.Location = new System.Drawing.Point(519, 240);
            this.m_txtDiseaseOne11.Name = "m_txtDiseaseOne11";
            this.m_txtDiseaseOne11.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne11.TabIndex = 148;
            this.m_txtDiseaseOne11.Tag = "2";
            // 
            // m_txtDiseaseOne10
            // 
            this.m_txtDiseaseOne10.AccessibleDescription = "★缺手术记录\r\n";
            this.m_txtDiseaseOne10.Location = new System.Drawing.Point(519, 220);
            this.m_txtDiseaseOne10.Name = "m_txtDiseaseOne10";
            this.m_txtDiseaseOne10.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne10.TabIndex = 149;
            this.m_txtDiseaseOne10.Tag = "丙级";
            // 
            // label182
            // 
            this.label182.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label182.Location = new System.Drawing.Point(47, 300);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(650, 1);
            this.label182.TabIndex = 89;
            this.label182.Text = "label3";
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Location = new System.Drawing.Point(439, 224);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(31, 13);
            this.label183.TabIndex = 116;
            this.label183.Text = "丙级";
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Location = new System.Drawing.Point(439, 204);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(29, 13);
            this.label184.TabIndex = 115;
            this.label184.Text = "1/项";
            // 
            // m_txtDiseaseOne15
            // 
            this.m_txtDiseaseOne15.AccessibleDescription = "术后病程记录有缺陷\r\n";
            this.m_txtDiseaseOne15.Location = new System.Drawing.Point(519, 320);
            this.m_txtDiseaseOne15.Name = "m_txtDiseaseOne15";
            this.m_txtDiseaseOne15.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne15.TabIndex = 143;
            this.m_txtDiseaseOne15.Tag = "1";
            // 
            // m_txtDiseaseOne14
            // 
            this.m_txtDiseaseOne14.AccessibleDescription = "缺术后当天病程记录\r\n";
            this.m_txtDiseaseOne14.Location = new System.Drawing.Point(519, 300);
            this.m_txtDiseaseOne14.Name = "m_txtDiseaseOne14";
            this.m_txtDiseaseOne14.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne14.TabIndex = 145;
            this.m_txtDiseaseOne14.Tag = "3";
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Location = new System.Drawing.Point(439, 304);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(13, 13);
            this.label185.TabIndex = 122;
            this.label185.Text = "3";
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Location = new System.Drawing.Point(439, 284);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(13, 13);
            this.label186.TabIndex = 124;
            this.label186.Text = "3";
            // 
            // m_txtDiseaseOne13
            // 
            this.m_txtDiseaseOne13.AccessibleDescription = "手术记录由第一助手书写而无手术者签字\r\n";
            this.m_txtDiseaseOne13.Location = new System.Drawing.Point(519, 280);
            this.m_txtDiseaseOne13.Name = "m_txtDiseaseOne13";
            this.m_txtDiseaseOne13.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne13.TabIndex = 155;
            this.m_txtDiseaseOne13.Tag = "3";
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Location = new System.Drawing.Point(439, 344);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(29, 13);
            this.label187.TabIndex = 126;
            this.label187.Text = "1/次";
            // 
            // m_txtDiseaseOne9
            // 
            this.m_txtDiseaseOne9.AccessibleDescription = "麻醉记录单有缺陷\r\n";
            this.m_txtDiseaseOne9.Location = new System.Drawing.Point(519, 200);
            this.m_txtDiseaseOne9.Name = "m_txtDiseaseOne9";
            this.m_txtDiseaseOne9.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne9.TabIndex = 156;
            this.m_txtDiseaseOne9.Tag = "1";
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(439, 264);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(13, 13);
            this.label188.TabIndex = 118;
            this.label188.Text = "5";
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Location = new System.Drawing.Point(439, 324);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(13, 13);
            this.label189.TabIndex = 120;
            this.label189.Text = "1";
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.Location = new System.Drawing.Point(439, 244);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(29, 13);
            this.label190.TabIndex = 121;
            this.label190.Text = "2/处";
            // 
            // label191
            // 
            this.label191.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label191.Location = new System.Drawing.Point(47, 220);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(650, 1);
            this.label191.TabIndex = 93;
            this.label191.Text = "label3";
            // 
            // label192
            // 
            this.label192.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label192.Location = new System.Drawing.Point(47, 260);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(650, 1);
            this.label192.TabIndex = 92;
            this.label192.Text = "label3";
            // 
            // m_txtDiseaseOne16
            // 
            this.m_txtDiseaseOne16.AccessibleDescription = "术后三天病程记录不连续\r\n";
            this.m_txtDiseaseOne16.Location = new System.Drawing.Point(519, 340);
            this.m_txtDiseaseOne16.Name = "m_txtDiseaseOne16";
            this.m_txtDiseaseOne16.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne16.TabIndex = 138;
            this.m_txtDiseaseOne16.Tag = "1";
            // 
            // label193
            // 
            this.label193.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label193.Location = new System.Drawing.Point(47, 200);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(650, 1);
            this.label193.TabIndex = 85;
            this.label193.Text = "label3";
            // 
            // label194
            // 
            this.label194.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label194.Location = new System.Drawing.Point(47, 360);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(650, 1);
            this.label194.TabIndex = 78;
            this.label194.Text = "label3";
            // 
            // label195
            // 
            this.label195.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label195.Location = new System.Drawing.Point(47, 240);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(650, 1);
            this.label195.TabIndex = 79;
            this.label195.Text = "label3";
            // 
            // label196
            // 
            this.label196.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label196.Location = new System.Drawing.Point(47, 160);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(650, 1);
            this.label196.TabIndex = 82;
            this.label196.Text = "label3";
            // 
            // label197
            // 
            this.label197.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label197.Location = new System.Drawing.Point(47, 320);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(650, 1);
            this.label197.TabIndex = 84;
            this.label197.Text = "label3";
            // 
            // label198
            // 
            this.label198.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label198.Location = new System.Drawing.Point(47, 280);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(650, 1);
            this.label198.TabIndex = 80;
            this.label198.Text = "label3";
            // 
            // label199
            // 
            this.label199.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label199.Location = new System.Drawing.Point(47, 80);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(650, 1);
            this.label199.TabIndex = 81;
            this.label199.Text = "label3";
            // 
            // label200
            // 
            this.label200.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label200.Location = new System.Drawing.Point(47, 120);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(650, 1);
            this.label200.TabIndex = 95;
            this.label200.Text = "label3";
            // 
            // m_chkDiseaseOne17
            // 
            this.m_chkDiseaseOne17.AccessibleDescription = "m_txtDiseaseOne17";
            this.m_chkDiseaseOne17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseOne17.Location = new System.Drawing.Point(47, 364);
            this.m_chkDiseaseOne17.Name = "m_chkDiseaseOne17";
            this.m_chkDiseaseOne17.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseOne17.TabIndex = 109;
            this.m_chkDiseaseOne17.Tag = "5";
            this.m_chkDiseaseOne17.Text = "术后三天内无上级医师查看病人的记录\r\n";
            // 
            // label201
            // 
            this.label201.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label201.Location = new System.Drawing.Point(47, 380);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(650, 1);
            this.label201.TabIndex = 88;
            this.label201.Text = "label3";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(439, 364);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(13, 13);
            this.label202.TabIndex = 125;
            this.label202.Text = "5";
            // 
            // m_txtDiseaseOne17
            // 
            this.m_txtDiseaseOne17.AccessibleDescription = "术后三天内无上级医师查看病人的记录\r\n";
            this.m_txtDiseaseOne17.Location = new System.Drawing.Point(519, 360);
            this.m_txtDiseaseOne17.Name = "m_txtDiseaseOne17";
            this.m_txtDiseaseOne17.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseOne17.TabIndex = 154;
            this.m_txtDiseaseOne17.Tag = "5";
            // 
            // pnlDiseaseTrack1
            // 
            this.pnlDiseaseTrack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo1);
            this.pnlDiseaseTrack1.Controls.Add(this.label116);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo1);
            this.pnlDiseaseTrack1.Controls.Add(this.label117);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo2);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo3);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo4);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo7);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo5);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo8);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo6);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo11);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo14);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo16);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo13);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo15);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo9);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo12);
            this.pnlDiseaseTrack1.Controls.Add(this.m_chkDiseaseTwo10);
            this.pnlDiseaseTrack1.Controls.Add(this.label119);
            this.pnlDiseaseTrack1.Controls.Add(this.label120);
            this.pnlDiseaseTrack1.Controls.Add(this.label121);
            this.pnlDiseaseTrack1.Controls.Add(this.label122);
            this.pnlDiseaseTrack1.Controls.Add(this.label123);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo2);
            this.pnlDiseaseTrack1.Controls.Add(this.label124);
            this.pnlDiseaseTrack1.Controls.Add(this.label125);
            this.pnlDiseaseTrack1.Controls.Add(this.label126);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo4);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo3);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo8);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo7);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo6);
            this.pnlDiseaseTrack1.Controls.Add(this.label127);
            this.pnlDiseaseTrack1.Controls.Add(this.label128);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo5);
            this.pnlDiseaseTrack1.Controls.Add(this.label129);
            this.pnlDiseaseTrack1.Controls.Add(this.label130);
            this.pnlDiseaseTrack1.Controls.Add(this.label131);
            this.pnlDiseaseTrack1.Controls.Add(this.label132);
            this.pnlDiseaseTrack1.Controls.Add(this.label133);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo12);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo11);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo10);
            this.pnlDiseaseTrack1.Controls.Add(this.label134);
            this.pnlDiseaseTrack1.Controls.Add(this.label135);
            this.pnlDiseaseTrack1.Controls.Add(this.label136);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo15);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo14);
            this.pnlDiseaseTrack1.Controls.Add(this.label137);
            this.pnlDiseaseTrack1.Controls.Add(this.label138);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo13);
            this.pnlDiseaseTrack1.Controls.Add(this.label139);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo9);
            this.pnlDiseaseTrack1.Controls.Add(this.label140);
            this.pnlDiseaseTrack1.Controls.Add(this.label141);
            this.pnlDiseaseTrack1.Controls.Add(this.label142);
            this.pnlDiseaseTrack1.Controls.Add(this.label143);
            this.pnlDiseaseTrack1.Controls.Add(this.label144);
            this.pnlDiseaseTrack1.Controls.Add(this.m_txtDiseaseTwo16);
            this.pnlDiseaseTrack1.Controls.Add(this.label145);
            this.pnlDiseaseTrack1.Controls.Add(this.label146);
            this.pnlDiseaseTrack1.Controls.Add(this.label147);
            this.pnlDiseaseTrack1.Controls.Add(this.label148);
            this.pnlDiseaseTrack1.Controls.Add(this.label149);
            this.pnlDiseaseTrack1.Controls.Add(this.label150);
            this.pnlDiseaseTrack1.Controls.Add(this.label151);
            this.pnlDiseaseTrack1.Controls.Add(this.label152);
            this.pnlDiseaseTrack1.Location = new System.Drawing.Point(32, 40);
            this.pnlDiseaseTrack1.Name = "pnlDiseaseTrack1";
            this.pnlDiseaseTrack1.Size = new System.Drawing.Size(732, 404);
            this.pnlDiseaseTrack1.TabIndex = 0;
            this.pnlDiseaseTrack1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // m_txtDiseaseTwo1
            // 
            this.m_txtDiseaseTwo1.AccessibleDescription = "首次病程记录未在8小时内完成\r\n";
            this.m_txtDiseaseTwo1.Location = new System.Drawing.Point(519, 40);
            this.m_txtDiseaseTwo1.Name = "m_txtDiseaseTwo1";
            this.m_txtDiseaseTwo1.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo1.TabIndex = 140;
            this.m_txtDiseaseTwo1.Tag = "5";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(123, 8);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(55, 13);
            this.label116.TabIndex = 135;
            this.label116.Text = "缺陷内容";
            // 
            // m_chkDiseaseTwo1
            // 
            this.m_chkDiseaseTwo1.AccessibleDescription = "m_txtDiseaseTwo1";
            this.m_chkDiseaseTwo1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo1.Location = new System.Drawing.Point(47, 44);
            this.m_chkDiseaseTwo1.Name = "m_chkDiseaseTwo1";
            this.m_chkDiseaseTwo1.Size = new System.Drawing.Size(237, 16);
            this.m_chkDiseaseTwo1.TabIndex = 100;
            this.m_chkDiseaseTwo1.Tag = "5";
            this.m_chkDiseaseTwo1.Text = "首次病程记录未在8小时内完成\r\n";
            // 
            // label117
            // 
            this.label117.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label117.Location = new System.Drawing.Point(36, 28);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(684, 4);
            this.label117.TabIndex = 94;
            this.label117.Text = "label117";
            // 
            // m_chkDiseaseTwo2
            // 
            this.m_chkDiseaseTwo2.AccessibleDescription = "m_txtDiseaseTwo2";
            this.m_chkDiseaseTwo2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo2.Location = new System.Drawing.Point(47, 64);
            this.m_chkDiseaseTwo2.Name = "m_chkDiseaseTwo2";
            this.m_chkDiseaseTwo2.Size = new System.Drawing.Size(293, 16);
            this.m_chkDiseaseTwo2.TabIndex = 101;
            this.m_chkDiseaseTwo2.Tag = "3";
            this.m_chkDiseaseTwo2.Text = "首次病程记录中缺诊断依据、鉴别诊断或诊疗计划\r\n";
            // 
            // m_chkDiseaseTwo3
            // 
            this.m_chkDiseaseTwo3.AccessibleDescription = "m_txtDiseaseTwo3";
            this.m_chkDiseaseTwo3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo3.Location = new System.Drawing.Point(47, 84);
            this.m_chkDiseaseTwo3.Name = "m_chkDiseaseTwo3";
            this.m_chkDiseaseTwo3.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo3.TabIndex = 102;
            this.m_chkDiseaseTwo3.Tag = "1";
            this.m_chkDiseaseTwo3.Text = "首次病程记录内容不规范\r\n";
            // 
            // m_chkDiseaseTwo4
            // 
            this.m_chkDiseaseTwo4.AccessibleDescription = "m_txtDiseaseTwo4";
            this.m_chkDiseaseTwo4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo4.Location = new System.Drawing.Point(47, 104);
            this.m_chkDiseaseTwo4.Name = "m_chkDiseaseTwo4";
            this.m_chkDiseaseTwo4.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo4.TabIndex = 99;
            this.m_chkDiseaseTwo4.Tag = "2";
            this.m_chkDiseaseTwo4.Text = "未按规定时间书写病程记录\r\n";
            this.m_tipMain.SetToolTip(this.m_chkDiseaseTwo4, "? 病程记录时限：病危：随时记录，每天至少一次，时间应具体到分钟，病重：至少2天记录一次。稳定（一般）；3天记录一次。慢性：至少5天一次。");
            // 
            // m_chkDiseaseTwo7
            // 
            this.m_chkDiseaseTwo7.AccessibleDescription = "m_txtDiseaseTwo7";
            this.m_chkDiseaseTwo7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo7.Location = new System.Drawing.Point(47, 164);
            this.m_chkDiseaseTwo7.Name = "m_chkDiseaseTwo7";
            this.m_chkDiseaseTwo7.Size = new System.Drawing.Size(369, 16);
            this.m_chkDiseaseTwo7.TabIndex = 96;
            this.m_chkDiseaseTwo7.Tag = "2";
            this.m_chkDiseaseTwo7.Text = "抢救记录内容有缺陷（指病情变化，抢救时间及措施、参加抢救人员姓名、职称\r\n";
            // 
            // m_chkDiseaseTwo5
            // 
            this.m_chkDiseaseTwo5.AccessibleDescription = "m_txtDiseaseTwo5";
            this.m_chkDiseaseTwo5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo5.Location = new System.Drawing.Point(47, 124);
            this.m_chkDiseaseTwo5.Name = "m_chkDiseaseTwo5";
            this.m_chkDiseaseTwo5.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo5.TabIndex = 97;
            this.m_chkDiseaseTwo5.Tag = "1";
            this.m_chkDiseaseTwo5.Text = "病程记录内容不全面（包括其他特殊记录）\r\n";
            // 
            // m_chkDiseaseTwo8
            // 
            this.m_chkDiseaseTwo8.AccessibleDescription = "m_txtDiseaseTwo8";
            this.m_chkDiseaseTwo8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo8.Location = new System.Drawing.Point(47, 184);
            this.m_chkDiseaseTwo8.Name = "m_chkDiseaseTwo8";
            this.m_chkDiseaseTwo8.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo8.TabIndex = 98;
            this.m_chkDiseaseTwo8.Tag = "2";
            this.m_chkDiseaseTwo8.Text = "无交班记录\r\n";
            // 
            // m_chkDiseaseTwo6
            // 
            this.m_chkDiseaseTwo6.AccessibleDescription = "m_txtDiseaseTwo6";
            this.m_chkDiseaseTwo6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo6.Location = new System.Drawing.Point(47, 144);
            this.m_chkDiseaseTwo6.Name = "m_chkDiseaseTwo6";
            this.m_chkDiseaseTwo6.Size = new System.Drawing.Size(233, 16);
            this.m_chkDiseaseTwo6.TabIndex = 111;
            this.m_chkDiseaseTwo6.Tag = "-1";
            this.m_chkDiseaseTwo6.Text = "★抢救病历无抢救记录\r\n";
            this.m_tipMain.SetToolTip(this.m_chkDiseaseTwo6, "抢救记录必须及时完成，特殊情况下必须在抢救后6小时内补记");
            // 
            // m_chkDiseaseTwo11
            // 
            this.m_chkDiseaseTwo11.AccessibleDescription = "m_txtDiseaseTwo11";
            this.m_chkDiseaseTwo11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo11.Location = new System.Drawing.Point(47, 244);
            this.m_chkDiseaseTwo11.Name = "m_chkDiseaseTwo11";
            this.m_chkDiseaseTwo11.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo11.TabIndex = 110;
            this.m_chkDiseaseTwo11.Tag = "5";
            this.m_chkDiseaseTwo11.Text = "缺特殊检查（治疗）记录\r\n";
            // 
            // m_chkDiseaseTwo14
            // 
            this.m_chkDiseaseTwo14.AccessibleDescription = "m_txtDiseaseTwo14";
            this.m_chkDiseaseTwo14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo14.Location = new System.Drawing.Point(47, 304);
            this.m_chkDiseaseTwo14.Name = "m_chkDiseaseTwo14";
            this.m_chkDiseaseTwo14.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo14.TabIndex = 112;
            this.m_chkDiseaseTwo14.Tag = "1";
            this.m_chkDiseaseTwo14.Text = "死亡讨论记录有缺陷";
            // 
            // m_chkDiseaseTwo16
            // 
            this.m_chkDiseaseTwo16.AccessibleDescription = "m_txtDiseaseTwo16";
            this.m_chkDiseaseTwo16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo16.Location = new System.Drawing.Point(47, 344);
            this.m_chkDiseaseTwo16.Name = "m_chkDiseaseTwo16";
            this.m_chkDiseaseTwo16.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo16.TabIndex = 114;
            this.m_chkDiseaseTwo16.Tag = "2";
            this.m_chkDiseaseTwo16.Text = "会诊记录有缺陷\r\n";
            this.m_tipMain.SetToolTip(this.m_chkDiseaseTwo16, "会诊记录内容齐全，包括会诊时间及医师签字");
            // 
            // m_chkDiseaseTwo13
            // 
            this.m_chkDiseaseTwo13.AccessibleDescription = "m_txtDiseaseTwo13";
            this.m_chkDiseaseTwo13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo13.Location = new System.Drawing.Point(47, 284);
            this.m_chkDiseaseTwo13.Name = "m_chkDiseaseTwo13";
            this.m_chkDiseaseTwo13.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo13.TabIndex = 108;
            this.m_chkDiseaseTwo13.Tag = "-1";
            this.m_chkDiseaseTwo13.Text = "★缺死亡讨论记录\r\n";
            this.m_tipMain.SetToolTip(this.m_chkDiseaseTwo13, "死亡讨论记录在患者死亡后一周内完成");
            // 
            // m_chkDiseaseTwo15
            // 
            this.m_chkDiseaseTwo15.AccessibleDescription = "m_txtDiseaseTwo15";
            this.m_chkDiseaseTwo15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo15.Location = new System.Drawing.Point(47, 324);
            this.m_chkDiseaseTwo15.Name = "m_chkDiseaseTwo15";
            this.m_chkDiseaseTwo15.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo15.TabIndex = 103;
            this.m_chkDiseaseTwo15.Tag = "2";
            this.m_chkDiseaseTwo15.Text = "缺会诊记录单";
            // 
            // m_chkDiseaseTwo9
            // 
            this.m_chkDiseaseTwo9.AccessibleDescription = "m_txtDiseaseTwo9";
            this.m_chkDiseaseTwo9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo9.Location = new System.Drawing.Point(47, 204);
            this.m_chkDiseaseTwo9.Name = "m_chkDiseaseTwo9";
            this.m_chkDiseaseTwo9.Size = new System.Drawing.Size(264, 16);
            this.m_chkDiseaseTwo9.TabIndex = 107;
            this.m_chkDiseaseTwo9.Tag = "3";
            this.m_chkDiseaseTwo9.Text = "无阶段小结\r\n";
            this.m_tipMain.SetToolTip(this.m_chkDiseaseTwo9, "住院时间超过一个月的要有阶段小结");
            // 
            // m_chkDiseaseTwo12
            // 
            this.m_chkDiseaseTwo12.AccessibleDescription = "m_txtDiseaseTwo12";
            this.m_chkDiseaseTwo12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo12.Location = new System.Drawing.Point(47, 264);
            this.m_chkDiseaseTwo12.Name = "m_chkDiseaseTwo12";
            this.m_chkDiseaseTwo12.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo12.TabIndex = 106;
            this.m_chkDiseaseTwo12.Tag = "2";
            this.m_chkDiseaseTwo12.Text = "特殊检查（治疗）记录有缺陷\r\n";
            // 
            // m_chkDiseaseTwo10
            // 
            this.m_chkDiseaseTwo10.AccessibleDescription = "m_txtDiseaseTwo10";
            this.m_chkDiseaseTwo10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkDiseaseTwo10.Location = new System.Drawing.Point(47, 224);
            this.m_chkDiseaseTwo10.Name = "m_chkDiseaseTwo10";
            this.m_chkDiseaseTwo10.Size = new System.Drawing.Size(236, 16);
            this.m_chkDiseaseTwo10.TabIndex = 105;
            this.m_chkDiseaseTwo10.Tag = "-1";
            this.m_chkDiseaseTwo10.Text = "★无转出、转入记录\r\n";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(427, 8);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(55, 13);
            this.label119.TabIndex = 136;
            this.label119.Text = "扣分标准";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(539, 8);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(37, 13);
            this.label120.TabIndex = 133;
            this.label120.Text = "扣  分";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(439, 44);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(13, 13);
            this.label121.TabIndex = 129;
            this.label121.Text = "5";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(439, 64);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(29, 13);
            this.label122.TabIndex = 127;
            this.label122.Text = "3/项";
            // 
            // label123
            // 
            this.label123.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label123.Location = new System.Drawing.Point(47, 60);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(650, 1);
            this.label123.TabIndex = 77;
            this.label123.Text = "label3";
            // 
            // m_txtDiseaseTwo2
            // 
            this.m_txtDiseaseTwo2.AccessibleDescription = "首次病程记录中缺诊断依据、鉴别诊断或诊疗计划\r\n";
            this.m_txtDiseaseTwo2.Location = new System.Drawing.Point(519, 60);
            this.m_txtDiseaseTwo2.Name = "m_txtDiseaseTwo2";
            this.m_txtDiseaseTwo2.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo2.TabIndex = 141;
            this.m_txtDiseaseTwo2.Tag = "3";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(439, 104);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(29, 13);
            this.label124.TabIndex = 131;
            this.label124.Text = "2/次";
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(439, 84);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(29, 13);
            this.label125.TabIndex = 130;
            this.label125.Text = "1/项";
            // 
            // label126
            // 
            this.label126.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label126.Location = new System.Drawing.Point(47, 100);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(650, 1);
            this.label126.TabIndex = 91;
            this.label126.Text = "label3";
            // 
            // m_txtDiseaseTwo4
            // 
            this.m_txtDiseaseTwo4.AccessibleDescription = "未按规定时间书写病程记录\r\n";
            this.m_txtDiseaseTwo4.Location = new System.Drawing.Point(519, 100);
            this.m_txtDiseaseTwo4.Name = "m_txtDiseaseTwo4";
            this.m_txtDiseaseTwo4.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo4.TabIndex = 139;
            this.m_txtDiseaseTwo4.Tag = "2";
            // 
            // m_txtDiseaseTwo3
            // 
            this.m_txtDiseaseTwo3.AccessibleDescription = "首次病程记录内容不规范\r\n";
            this.m_txtDiseaseTwo3.Location = new System.Drawing.Point(519, 80);
            this.m_txtDiseaseTwo3.Name = "m_txtDiseaseTwo3";
            this.m_txtDiseaseTwo3.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo3.TabIndex = 153;
            this.m_txtDiseaseTwo3.Tag = "1";
            // 
            // m_txtDiseaseTwo8
            // 
            this.m_txtDiseaseTwo8.AccessibleDescription = "无交班记录\r\n";
            this.m_txtDiseaseTwo8.Location = new System.Drawing.Point(519, 180);
            this.m_txtDiseaseTwo8.Name = "m_txtDiseaseTwo8";
            this.m_txtDiseaseTwo8.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo8.TabIndex = 152;
            this.m_txtDiseaseTwo8.Tag = "2";
            // 
            // m_txtDiseaseTwo7
            // 
            this.m_txtDiseaseTwo7.AccessibleDescription = "抢救记录内容有缺陷（指病情变化，抢救时间及措施、参加抢救人员姓名、职称\r\n";
            this.m_txtDiseaseTwo7.Location = new System.Drawing.Point(519, 160);
            this.m_txtDiseaseTwo7.Name = "m_txtDiseaseTwo7";
            this.m_txtDiseaseTwo7.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo7.TabIndex = 151;
            this.m_txtDiseaseTwo7.Tag = "2";
            // 
            // m_txtDiseaseTwo6
            // 
            this.m_txtDiseaseTwo6.AccessibleDescription = "★抢救病历无抢救记录\r\n";
            this.m_txtDiseaseTwo6.Location = new System.Drawing.Point(519, 140);
            this.m_txtDiseaseTwo6.Name = "m_txtDiseaseTwo6";
            this.m_txtDiseaseTwo6.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo6.TabIndex = 157;
            this.m_txtDiseaseTwo6.Tag = "乙级";
            this.m_tipMain.SetToolTip(this.m_txtDiseaseTwo6, "抢救记录必须及时完成，特殊情况下必须在抢救后6小时内补记");
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(439, 144);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(31, 13);
            this.label127.TabIndex = 132;
            this.label127.Text = "乙级";
            this.m_tipMain.SetToolTip(this.label127, "抢救记录必须及时完成，特殊情况下必须在抢救后6小时内补记");
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(439, 124);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(29, 13);
            this.label128.TabIndex = 128;
            this.label128.Text = "1/项";
            // 
            // m_txtDiseaseTwo5
            // 
            this.m_txtDiseaseTwo5.AccessibleDescription = "病程记录内容不全面（包括其他特殊记录）\r\n";
            this.m_txtDiseaseTwo5.Location = new System.Drawing.Point(519, 120);
            this.m_txtDiseaseTwo5.Name = "m_txtDiseaseTwo5";
            this.m_txtDiseaseTwo5.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo5.TabIndex = 147;
            this.m_txtDiseaseTwo5.Tag = "1";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(439, 184);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(29, 13);
            this.label129.TabIndex = 137;
            this.label129.Text = "2/次";
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(439, 164);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(29, 13);
            this.label130.TabIndex = 134;
            this.label130.Text = "2/项";
            // 
            // label131
            // 
            this.label131.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label131.Location = new System.Drawing.Point(47, 140);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(650, 1);
            this.label131.TabIndex = 90;
            this.label131.Text = "label3";
            // 
            // label132
            // 
            this.label132.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label132.Location = new System.Drawing.Point(47, 180);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(650, 1);
            this.label132.TabIndex = 86;
            this.label132.Text = "label3";
            // 
            // label133
            // 
            this.label133.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label133.Location = new System.Drawing.Point(47, 340);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(650, 1);
            this.label133.TabIndex = 87;
            this.label133.Text = "label3";
            // 
            // m_txtDiseaseTwo12
            // 
            this.m_txtDiseaseTwo12.AccessibleDescription = "特殊检查（治疗）记录有缺陷\r\n";
            this.m_txtDiseaseTwo12.Location = new System.Drawing.Point(519, 260);
            this.m_txtDiseaseTwo12.Name = "m_txtDiseaseTwo12";
            this.m_txtDiseaseTwo12.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo12.TabIndex = 150;
            this.m_txtDiseaseTwo12.Tag = "2";
            // 
            // m_txtDiseaseTwo11
            // 
            this.m_txtDiseaseTwo11.AccessibleDescription = "缺特殊检查（治疗）记录\r\n";
            this.m_txtDiseaseTwo11.Location = new System.Drawing.Point(519, 240);
            this.m_txtDiseaseTwo11.Name = "m_txtDiseaseTwo11";
            this.m_txtDiseaseTwo11.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo11.TabIndex = 148;
            this.m_txtDiseaseTwo11.Tag = "5";
            // 
            // m_txtDiseaseTwo10
            // 
            this.m_txtDiseaseTwo10.AccessibleDescription = "★无转出、转入记录\r\n";
            this.m_txtDiseaseTwo10.Location = new System.Drawing.Point(519, 220);
            this.m_txtDiseaseTwo10.Name = "m_txtDiseaseTwo10";
            this.m_txtDiseaseTwo10.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo10.TabIndex = 149;
            this.m_txtDiseaseTwo10.Tag = "乙级";
            // 
            // label134
            // 
            this.label134.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label134.Location = new System.Drawing.Point(47, 300);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(650, 1);
            this.label134.TabIndex = 89;
            this.label134.Text = "label3";
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(439, 224);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(31, 13);
            this.label135.TabIndex = 116;
            this.label135.Text = "乙级";
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(439, 204);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(29, 13);
            this.label136.TabIndex = 115;
            this.label136.Text = "3/次";
            // 
            // m_txtDiseaseTwo15
            // 
            this.m_txtDiseaseTwo15.AccessibleDescription = "缺会诊记录单";
            this.m_txtDiseaseTwo15.Location = new System.Drawing.Point(519, 320);
            this.m_txtDiseaseTwo15.Name = "m_txtDiseaseTwo15";
            this.m_txtDiseaseTwo15.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo15.TabIndex = 143;
            this.m_txtDiseaseTwo15.Tag = "2";
            // 
            // m_txtDiseaseTwo14
            // 
            this.m_txtDiseaseTwo14.AccessibleDescription = "死亡讨论记录有缺陷";
            this.m_txtDiseaseTwo14.Location = new System.Drawing.Point(519, 300);
            this.m_txtDiseaseTwo14.Name = "m_txtDiseaseTwo14";
            this.m_txtDiseaseTwo14.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo14.TabIndex = 145;
            this.m_txtDiseaseTwo14.Tag = "1";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(439, 304);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(13, 13);
            this.label137.TabIndex = 122;
            this.label137.Text = "1";
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(439, 284);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(31, 13);
            this.label138.TabIndex = 124;
            this.label138.Text = "乙级";
            this.m_tipMain.SetToolTip(this.label138, "死亡讨论记录在患者死亡后一周内完成");
            // 
            // m_txtDiseaseTwo13
            // 
            this.m_txtDiseaseTwo13.AccessibleDescription = "★缺死亡讨论记录\r\n";
            this.m_txtDiseaseTwo13.Location = new System.Drawing.Point(519, 280);
            this.m_txtDiseaseTwo13.Name = "m_txtDiseaseTwo13";
            this.m_txtDiseaseTwo13.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo13.TabIndex = 155;
            this.m_txtDiseaseTwo13.Tag = "乙级";
            this.m_tipMain.SetToolTip(this.m_txtDiseaseTwo13, "死亡讨论记录在患者死亡后一周内完成");
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(439, 344);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(29, 13);
            this.label139.TabIndex = 126;
            this.label139.Text = "2/处";
            this.m_tipMain.SetToolTip(this.label139, "会诊记录内容齐全，包括会诊时间及医师签字");
            // 
            // m_txtDiseaseTwo9
            // 
            this.m_txtDiseaseTwo9.AccessibleDescription = "无阶段小结\r\n";
            this.m_txtDiseaseTwo9.Location = new System.Drawing.Point(519, 200);
            this.m_txtDiseaseTwo9.Name = "m_txtDiseaseTwo9";
            this.m_txtDiseaseTwo9.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo9.TabIndex = 156;
            this.m_txtDiseaseTwo9.Tag = "3";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(439, 264);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(13, 13);
            this.label140.TabIndex = 118;
            this.label140.Text = "2";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(439, 324);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(29, 13);
            this.label141.TabIndex = 120;
            this.label141.Text = "2/次";
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Location = new System.Drawing.Point(439, 244);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(13, 13);
            this.label142.TabIndex = 121;
            this.label142.Text = "5";
            // 
            // label143
            // 
            this.label143.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label143.Location = new System.Drawing.Point(47, 220);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(650, 1);
            this.label143.TabIndex = 93;
            this.label143.Text = "label3";
            // 
            // label144
            // 
            this.label144.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label144.Location = new System.Drawing.Point(47, 260);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(650, 1);
            this.label144.TabIndex = 92;
            this.label144.Text = "label3";
            // 
            // m_txtDiseaseTwo16
            // 
            this.m_txtDiseaseTwo16.AccessibleDescription = "会诊记录有缺陷\r\n";
            this.m_txtDiseaseTwo16.Location = new System.Drawing.Point(519, 340);
            this.m_txtDiseaseTwo16.Name = "m_txtDiseaseTwo16";
            this.m_txtDiseaseTwo16.Size = new System.Drawing.Size(100, 20);
            this.m_txtDiseaseTwo16.TabIndex = 138;
            this.m_txtDiseaseTwo16.Tag = "2";
            this.m_tipMain.SetToolTip(this.m_txtDiseaseTwo16, "会诊记录内容齐全，包括会诊时间及医师签字");
            // 
            // label145
            // 
            this.label145.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label145.Location = new System.Drawing.Point(47, 200);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(650, 1);
            this.label145.TabIndex = 85;
            this.label145.Text = "label3";
            // 
            // label146
            // 
            this.label146.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label146.Location = new System.Drawing.Point(47, 360);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(650, 1);
            this.label146.TabIndex = 78;
            this.label146.Text = "label3";
            // 
            // label147
            // 
            this.label147.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label147.Location = new System.Drawing.Point(47, 240);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(650, 1);
            this.label147.TabIndex = 79;
            this.label147.Text = "label3";
            // 
            // label148
            // 
            this.label148.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label148.Location = new System.Drawing.Point(47, 160);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(650, 1);
            this.label148.TabIndex = 82;
            this.label148.Text = "label3";
            // 
            // label149
            // 
            this.label149.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label149.Location = new System.Drawing.Point(47, 320);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(650, 1);
            this.label149.TabIndex = 84;
            this.label149.Text = "label3";
            // 
            // label150
            // 
            this.label150.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label150.Location = new System.Drawing.Point(47, 280);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(650, 1);
            this.label150.TabIndex = 80;
            this.label150.Text = "label3";
            // 
            // label151
            // 
            this.label151.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label151.Location = new System.Drawing.Point(47, 80);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(650, 1);
            this.label151.TabIndex = 81;
            this.label151.Text = "label3";
            // 
            // label152
            // 
            this.label152.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label152.Location = new System.Drawing.Point(47, 120);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(650, 1);
            this.label152.TabIndex = 95;
            this.label152.Text = "label3";
            // 
            // tbpOutHospital
            // 
            this.tbpOutHospital.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpOutHospital.Controls.Add(this.pnlOutGrade);
            this.tbpOutHospital.Controls.Add(this.m_lklCalOutResult);
            this.tbpOutHospital.Controls.Add(this.label80);
            this.tbpOutHospital.Controls.Add(this.m_txtOutResult);
            this.tbpOutHospital.Controls.Add(this.m_lblOutgrade);
            this.tbpOutHospital.Location = new System.Drawing.Point(0, 25);
            this.tbpOutHospital.Name = "tbpOutHospital";
            this.tbpOutHospital.Selected = false;
            this.tbpOutHospital.Size = new System.Drawing.Size(768, 447);
            this.tbpOutHospital.TabIndex = 6;
            this.tbpOutHospital.Title = "出院记录";
            this.tbpOutHospital.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // pnlOutGrade
            // 
            this.pnlOutGrade.Controls.Add(this.label78);
            this.pnlOutGrade.Controls.Add(this.label79);
            this.pnlOutGrade.Controls.Add(this.m_chkOutHos1);
            this.pnlOutGrade.Controls.Add(this.m_chkOutHos2);
            this.pnlOutGrade.Controls.Add(this.m_chkOutHos4);
            this.pnlOutGrade.Controls.Add(this.m_chkOutHos3);
            this.pnlOutGrade.Controls.Add(this.label81);
            this.pnlOutGrade.Controls.Add(this.label82);
            this.pnlOutGrade.Controls.Add(this.label84);
            this.pnlOutGrade.Controls.Add(this.m_txtOutHos1);
            this.pnlOutGrade.Controls.Add(this.label86);
            this.pnlOutGrade.Controls.Add(this.m_txtOutHos2);
            this.pnlOutGrade.Controls.Add(this.m_txtOutHos4);
            this.pnlOutGrade.Controls.Add(this.m_txtOutHos3);
            this.pnlOutGrade.Controls.Add(this.label89);
            this.pnlOutGrade.Controls.Add(this.label91);
            this.pnlOutGrade.Controls.Add(this.label107);
            this.pnlOutGrade.Controls.Add(this.label110);
            this.pnlOutGrade.Controls.Add(this.label113);
            this.pnlOutGrade.Controls.Add(this.label114);
            this.pnlOutGrade.Controls.Add(this.m_chkOutHos5);
            this.pnlOutGrade.Controls.Add(this.label83);
            this.pnlOutGrade.Controls.Add(this.m_txtOutHos5);
            this.pnlOutGrade.Controls.Add(this.label85);
            this.pnlOutGrade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOutGrade.Location = new System.Drawing.Point(0, 39);
            this.pnlOutGrade.Name = "pnlOutGrade";
            this.pnlOutGrade.Size = new System.Drawing.Size(764, 404);
            this.pnlOutGrade.TabIndex = 148;
            this.pnlOutGrade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(120, 16);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(55, 13);
            this.label78.TabIndex = 92;
            this.label78.Text = "缺陷内容";
            // 
            // label79
            // 
            this.label79.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label79.Location = new System.Drawing.Point(40, 40);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(708, 4);
            this.label79.TabIndex = 79;
            this.label79.Text = "label79";
            // 
            // m_chkOutHos1
            // 
            this.m_chkOutHos1.AccessibleDescription = "m_txtOutHos1";
            this.m_chkOutHos1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkOutHos1.Location = new System.Drawing.Point(44, 72);
            this.m_chkOutHos1.Name = "m_chkOutHos1";
            this.m_chkOutHos1.Size = new System.Drawing.Size(236, 16);
            this.m_chkOutHos1.TabIndex = 85;
            this.m_chkOutHos1.Tag = "-1";
            this.m_chkOutHos1.Text = "★缺出院（死亡）记录";
            // 
            // m_chkOutHos2
            // 
            this.m_chkOutHos2.AccessibleDescription = "m_txtOutHos2";
            this.m_chkOutHos2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkOutHos2.Location = new System.Drawing.Point(44, 112);
            this.m_chkOutHos2.Name = "m_chkOutHos2";
            this.m_chkOutHos2.Size = new System.Drawing.Size(236, 16);
            this.m_chkOutHos2.TabIndex = 84;
            this.m_chkOutHos2.Tag = "5";
            this.m_chkOutHos2.Text = "出院（死亡）记录24小时内未完成\r\n";
            // 
            // m_chkOutHos4
            // 
            this.m_chkOutHos4.AccessibleDescription = "m_txtOutHos4";
            this.m_chkOutHos4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkOutHos4.Location = new System.Drawing.Point(44, 232);
            this.m_chkOutHos4.Name = "m_chkOutHos4";
            this.m_chkOutHos4.Size = new System.Drawing.Size(236, 16);
            this.m_chkOutHos4.TabIndex = 82;
            this.m_chkOutHos4.Tag = "2";
            this.m_chkOutHos4.Text = "出院（死亡）记录缺两级医师签名\r\n";
            // 
            // m_chkOutHos3
            // 
            this.m_chkOutHos3.AccessibleDescription = "m_txtOutHos3";
            this.m_chkOutHos3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkOutHos3.Location = new System.Drawing.Point(44, 192);
            this.m_chkOutHos3.Name = "m_chkOutHos3";
            this.m_chkOutHos3.Size = new System.Drawing.Size(236, 16);
            this.m_chkOutHos3.TabIndex = 86;
            this.m_chkOutHos3.Tag = "1";
            this.m_chkOutHos3.Text = "出院（死亡）记录某一部分内容不全\r\n";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(352, 16);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(55, 13);
            this.label81.TabIndex = 93;
            this.label81.Text = "扣分标准";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(536, 16);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(37, 13);
            this.label82.TabIndex = 91;
            this.label82.Text = "扣  分";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(364, 72);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(31, 13);
            this.label84.TabIndex = 87;
            this.label84.Text = "乙级";
            // 
            // m_txtOutHos1
            // 
            this.m_txtOutHos1.AccessibleDescription = "★缺出院（死亡）记录";
            this.m_txtOutHos1.Location = new System.Drawing.Point(516, 68);
            this.m_txtOutHos1.Name = "m_txtOutHos1";
            this.m_txtOutHos1.Size = new System.Drawing.Size(100, 20);
            this.m_txtOutHos1.TabIndex = 97;
            this.m_txtOutHos1.Tag = "乙级";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(364, 112);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(13, 13);
            this.label86.TabIndex = 89;
            this.label86.Text = "5";
            // 
            // m_txtOutHos2
            // 
            this.m_txtOutHos2.AccessibleDescription = "出院（死亡）记录24小时内未完成\r\n";
            this.m_txtOutHos2.Location = new System.Drawing.Point(516, 108);
            this.m_txtOutHos2.Name = "m_txtOutHos2";
            this.m_txtOutHos2.Size = new System.Drawing.Size(100, 20);
            this.m_txtOutHos2.TabIndex = 96;
            this.m_txtOutHos2.Tag = "5";
            // 
            // m_txtOutHos4
            // 
            this.m_txtOutHos4.AccessibleDescription = "出院（死亡）记录缺两级医师签名\r\n";
            this.m_txtOutHos4.Location = new System.Drawing.Point(516, 228);
            this.m_txtOutHos4.Name = "m_txtOutHos4";
            this.m_txtOutHos4.Size = new System.Drawing.Size(100, 20);
            this.m_txtOutHos4.TabIndex = 98;
            this.m_txtOutHos4.Tag = "2";
            // 
            // m_txtOutHos3
            // 
            this.m_txtOutHos3.AccessibleDescription = "出院（死亡）记录某一部分内容不全\r\n";
            this.m_txtOutHos3.Location = new System.Drawing.Point(516, 188);
            this.m_txtOutHos3.Name = "m_txtOutHos3";
            this.m_txtOutHos3.Size = new System.Drawing.Size(100, 20);
            this.m_txtOutHos3.TabIndex = 99;
            this.m_txtOutHos3.Tag = "1";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(364, 192);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(41, 13);
            this.label89.TabIndex = 90;
            this.label89.Text = "1/部分";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(364, 232);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(29, 13);
            this.label91.TabIndex = 94;
            this.label91.Text = "2/项";
            // 
            // label107
            // 
            this.label107.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label107.Location = new System.Drawing.Point(44, 256);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(650, 1);
            this.label107.TabIndex = 78;
            this.label107.Text = "label3";
            // 
            // label110
            // 
            this.label110.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label110.Location = new System.Drawing.Point(44, 216);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(650, 1);
            this.label110.TabIndex = 77;
            this.label110.Text = "label3";
            // 
            // label113
            // 
            this.label113.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label113.Location = new System.Drawing.Point(44, 96);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(650, 1);
            this.label113.TabIndex = 76;
            this.label113.Text = "label3";
            // 
            // label114
            // 
            this.label114.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label114.Location = new System.Drawing.Point(44, 136);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(650, 1);
            this.label114.TabIndex = 81;
            this.label114.Text = "label3";
            // 
            // m_chkOutHos5
            // 
            this.m_chkOutHos5.AccessibleDescription = "m_txtOutHos5";
            this.m_chkOutHos5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkOutHos5.Location = new System.Drawing.Point(44, 152);
            this.m_chkOutHos5.Name = "m_chkOutHos5";
            this.m_chkOutHos5.Size = new System.Drawing.Size(236, 16);
            this.m_chkOutHos5.TabIndex = 83;
            this.m_chkOutHos5.Tag = "2";
            this.m_chkOutHos5.Text = "出院（死亡）记录缺某一部分内容";
            this.m_tipMain.SetToolTip(this.m_chkOutHos5, "包括主诉、入院情况、入院诊断、诊疗经过、出院情况，出院诊断，出院医嘱、医师签名。");
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(364, 152);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(41, 13);
            this.label83.TabIndex = 88;
            this.label83.Text = "2/部分";
            this.m_tipMain.SetToolTip(this.label83, "包括主诉、入院情况、入院诊断、诊疗经过、出院情况，出院诊断，出院医嘱、医师签名。");
            // 
            // m_txtOutHos5
            // 
            this.m_txtOutHos5.AccessibleDescription = "出院（死亡）记录缺某一部分内容";
            this.m_txtOutHos5.Location = new System.Drawing.Point(516, 148);
            this.m_txtOutHos5.Name = "m_txtOutHos5";
            this.m_txtOutHos5.Size = new System.Drawing.Size(100, 20);
            this.m_txtOutHos5.TabIndex = 95;
            this.m_txtOutHos5.Tag = "2";
            this.m_tipMain.SetToolTip(this.m_txtOutHos5, "包括主诉、入院情况、入院诊断、诊疗经过、出院情况，出院诊断，出院医嘱、医师签名。");
            // 
            // label85
            // 
            this.label85.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label85.Location = new System.Drawing.Point(44, 176);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(650, 1);
            this.label85.TabIndex = 80;
            this.label85.Text = "label3";
            // 
            // m_lklCalOutResult
            // 
            this.m_lklCalOutResult.AutoSize = true;
            this.m_lklCalOutResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lklCalOutResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_lklCalOutResult.LinkColor = System.Drawing.Color.Red;
            this.m_lklCalOutResult.Location = new System.Drawing.Point(576, 12);
            this.m_lklCalOutResult.Name = "m_lklCalOutResult";
            this.m_lklCalOutResult.Size = new System.Drawing.Size(67, 13);
            this.m_lklCalOutResult.TabIndex = 147;
            this.m_lklCalOutResult.TabStop = true;
            this.m_lklCalOutResult.Text = "计算扣分：";
            this.m_tipMain.SetToolTip(this.m_lklCalOutResult, "点击计算本页面的总扣分");
            this.m_lklCalOutResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklCalOutResult_LinkClicked);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label80.ForeColor = System.Drawing.Color.Green;
            this.label80.Location = new System.Drawing.Point(8, 8);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(102, 15);
            this.label80.TabIndex = 5;
            this.label80.Text = "标准分值：  10 分";
            // 
            // m_txtOutResult
            // 
            this.m_txtOutResult.AccessibleDescription = "出院记录扣分";
            this.m_txtOutResult.Location = new System.Drawing.Point(644, 8);
            this.m_txtOutResult.Name = "m_txtOutResult";
            this.m_txtOutResult.ReadOnly = true;
            this.m_txtOutResult.Size = new System.Drawing.Size(48, 20);
            this.m_txtOutResult.TabIndex = 63;
            this.m_tipMain.SetToolTip(this.m_txtOutResult, "扣分结果以标准分值为最");
            // 
            // m_lblOutgrade
            // 
            this.m_lblOutgrade.AutoSize = true;
            this.m_lblOutgrade.Location = new System.Drawing.Point(696, 10);
            this.m_lblOutgrade.Name = "m_lblOutgrade";
            this.m_lblOutgrade.Size = new System.Drawing.Size(0, 13);
            this.m_lblOutgrade.TabIndex = 52;
            // 
            // tbpCheck
            // 
            this.tbpCheck.Controls.Add(this.pnlCheckGrade);
            this.tbpCheck.Controls.Add(this.m_lklCalCheck);
            this.tbpCheck.Controls.Add(this.label204);
            this.tbpCheck.Controls.Add(this.m_txtCheckResult);
            this.tbpCheck.Controls.Add(this.m_lblCheckGrade);
            this.tbpCheck.Location = new System.Drawing.Point(0, 25);
            this.tbpCheck.Name = "tbpCheck";
            this.tbpCheck.Selected = false;
            this.tbpCheck.Size = new System.Drawing.Size(768, 447);
            this.tbpCheck.TabIndex = 8;
            this.tbpCheck.Title = "辅助检查";
            this.tbpCheck.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // pnlCheckGrade
            // 
            this.pnlCheckGrade.Controls.Add(this.label102);
            this.pnlCheckGrade.Controls.Add(this.label103);
            this.pnlCheckGrade.Controls.Add(this.m_chkCheck1);
            this.pnlCheckGrade.Controls.Add(this.m_chkCheck2);
            this.pnlCheckGrade.Controls.Add(this.label104);
            this.pnlCheckGrade.Controls.Add(this.label105);
            this.pnlCheckGrade.Controls.Add(this.label106);
            this.pnlCheckGrade.Controls.Add(this.m_txtCheck1);
            this.pnlCheckGrade.Controls.Add(this.label108);
            this.pnlCheckGrade.Controls.Add(this.m_txtCheck2);
            this.pnlCheckGrade.Controls.Add(this.label153);
            this.pnlCheckGrade.Controls.Add(this.label162);
            this.pnlCheckGrade.Controls.Add(this.m_chkCheck3);
            this.pnlCheckGrade.Controls.Add(this.label164);
            this.pnlCheckGrade.Controls.Add(this.m_txtCheck3);
            this.pnlCheckGrade.Controls.Add(this.label203);
            this.pnlCheckGrade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCheckGrade.Location = new System.Drawing.Point(0, 43);
            this.pnlCheckGrade.Name = "pnlCheckGrade";
            this.pnlCheckGrade.Size = new System.Drawing.Size(768, 404);
            this.pnlCheckGrade.TabIndex = 153;
            this.pnlCheckGrade.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(120, 16);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(55, 13);
            this.label102.TabIndex = 92;
            this.label102.Text = "缺陷内容";
            // 
            // label103
            // 
            this.label103.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label103.Location = new System.Drawing.Point(40, 40);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(708, 4);
            this.label103.TabIndex = 79;
            this.label103.Text = "label79";
            // 
            // m_chkCheck1
            // 
            this.m_chkCheck1.AccessibleDescription = "m_txtCheck1";
            this.m_chkCheck1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkCheck1.Location = new System.Drawing.Point(44, 72);
            this.m_chkCheck1.Name = "m_chkCheck1";
            this.m_chkCheck1.Size = new System.Drawing.Size(240, 16);
            this.m_chkCheck1.TabIndex = 85;
            this.m_chkCheck1.Tag = "-1";
            this.m_chkCheck1.Text = "★缺与主要诊断相关的辅助检查报告单";
            // 
            // m_chkCheck2
            // 
            this.m_chkCheck2.AccessibleDescription = "m_txtCheck2";
            this.m_chkCheck2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkCheck2.Location = new System.Drawing.Point(44, 112);
            this.m_chkCheck2.Name = "m_chkCheck2";
            this.m_chkCheck2.Size = new System.Drawing.Size(236, 16);
            this.m_chkCheck2.TabIndex = 84;
            this.m_chkCheck2.Tag = "1";
            this.m_chkCheck2.Text = "缺应有的检查报告单";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(352, 16);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(55, 13);
            this.label104.TabIndex = 93;
            this.label104.Text = "扣分标准";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(536, 16);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(37, 13);
            this.label105.TabIndex = 91;
            this.label105.Text = "扣  分";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(364, 72);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(31, 13);
            this.label106.TabIndex = 87;
            this.label106.Text = "乙级";
            // 
            // m_txtCheck1
            // 
            this.m_txtCheck1.AccessibleDescription = "★缺与主要诊断相关的辅助检查报告单";
            this.m_txtCheck1.Location = new System.Drawing.Point(516, 68);
            this.m_txtCheck1.Name = "m_txtCheck1";
            this.m_txtCheck1.Size = new System.Drawing.Size(100, 20);
            this.m_txtCheck1.TabIndex = 97;
            this.m_txtCheck1.Tag = "乙级";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(364, 112);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(29, 13);
            this.label108.TabIndex = 89;
            this.label108.Text = "1/张";
            // 
            // m_txtCheck2
            // 
            this.m_txtCheck2.AccessibleDescription = "缺应有的检查报告单";
            this.m_txtCheck2.Location = new System.Drawing.Point(516, 108);
            this.m_txtCheck2.Name = "m_txtCheck2";
            this.m_txtCheck2.Size = new System.Drawing.Size(100, 20);
            this.m_txtCheck2.TabIndex = 96;
            this.m_txtCheck2.Tag = "1";
            // 
            // label153
            // 
            this.label153.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label153.Location = new System.Drawing.Point(44, 96);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(650, 1);
            this.label153.TabIndex = 76;
            this.label153.Text = "label3";
            // 
            // label162
            // 
            this.label162.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label162.Location = new System.Drawing.Point(44, 136);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(650, 1);
            this.label162.TabIndex = 81;
            this.label162.Text = "label3";
            // 
            // m_chkCheck3
            // 
            this.m_chkCheck3.AccessibleDescription = "m_txtCheck3";
            this.m_chkCheck3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkCheck3.Location = new System.Drawing.Point(44, 152);
            this.m_chkCheck3.Name = "m_chkCheck3";
            this.m_chkCheck3.Size = new System.Drawing.Size(272, 16);
            this.m_chkCheck3.TabIndex = 83;
            this.m_chkCheck3.Tag = "1";
            this.m_chkCheck3.Text = "报告单、检验单粘贴不规范、不整齐或缺标记";
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Location = new System.Drawing.Point(364, 152);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(13, 13);
            this.label164.TabIndex = 88;
            this.label164.Text = "1";
            this.m_tipMain.SetToolTip(this.label164, "包括主诉、入院情况、入院诊断、诊疗经过、出院情况，出院诊断，出院医嘱、医师签名。");
            // 
            // m_txtCheck3
            // 
            this.m_txtCheck3.AccessibleDescription = "报告单、检验单粘贴不规范、不整齐或缺标记";
            this.m_txtCheck3.Location = new System.Drawing.Point(516, 148);
            this.m_txtCheck3.Name = "m_txtCheck3";
            this.m_txtCheck3.Size = new System.Drawing.Size(100, 20);
            this.m_txtCheck3.TabIndex = 95;
            this.m_txtCheck3.Tag = "1";
            // 
            // label203
            // 
            this.label203.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label203.Location = new System.Drawing.Point(44, 176);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(650, 1);
            this.label203.TabIndex = 80;
            this.label203.Text = "label3";
            // 
            // m_lklCalCheck
            // 
            this.m_lklCalCheck.AutoSize = true;
            this.m_lklCalCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lklCalCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_lklCalCheck.LinkColor = System.Drawing.Color.Red;
            this.m_lklCalCheck.Location = new System.Drawing.Point(576, 9);
            this.m_lklCalCheck.Name = "m_lklCalCheck";
            this.m_lklCalCheck.Size = new System.Drawing.Size(67, 13);
            this.m_lklCalCheck.TabIndex = 152;
            this.m_lklCalCheck.TabStop = true;
            this.m_lklCalCheck.Text = "计算扣分：";
            this.m_tipMain.SetToolTip(this.m_lklCalCheck, "点击计算本页面的总扣分");
            this.m_lklCalCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklCalCheck_LinkClicked);
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label204.ForeColor = System.Drawing.Color.Green;
            this.label204.Location = new System.Drawing.Point(8, 8);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(96, 15);
            this.label204.TabIndex = 149;
            this.label204.Text = "标准分值：  5 分";
            // 
            // m_txtCheckResult
            // 
            this.m_txtCheckResult.AccessibleDescription = "辅助检查扣分";
            this.m_txtCheckResult.Location = new System.Drawing.Point(644, 7);
            this.m_txtCheckResult.Name = "m_txtCheckResult";
            this.m_txtCheckResult.ReadOnly = true;
            this.m_txtCheckResult.Size = new System.Drawing.Size(48, 20);
            this.m_txtCheckResult.TabIndex = 151;
            this.m_tipMain.SetToolTip(this.m_txtCheckResult, "扣分结果以标准分值为最");
            // 
            // m_lblCheckGrade
            // 
            this.m_lblCheckGrade.AutoSize = true;
            this.m_lblCheckGrade.Location = new System.Drawing.Point(696, 9);
            this.m_lblCheckGrade.Name = "m_lblCheckGrade";
            this.m_lblCheckGrade.Size = new System.Drawing.Size(0, 13);
            this.m_lblCheckGrade.TabIndex = 150;
            // 
            // tbpBasis
            // 
            this.tbpBasis.Controls.Add(this.pnlBaseGrade);
            this.tbpBasis.Controls.Add(this.m_lklCalBase);
            this.tbpBasis.Controls.Add(this.label216);
            this.tbpBasis.Controls.Add(this.m_txtBaseResult);
            this.tbpBasis.Controls.Add(this.m_lblBaseGrade);
            this.tbpBasis.Location = new System.Drawing.Point(0, 25);
            this.tbpBasis.Name = "tbpBasis";
            this.tbpBasis.Selected = false;
            this.tbpBasis.Size = new System.Drawing.Size(768, 447);
            this.tbpBasis.TabIndex = 9;
            this.tbpBasis.Title = "基本要求和医嘱单";
            this.tbpBasis.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // pnlBaseGrade
            // 
            this.pnlBaseGrade.Controls.Add(this.label109);
            this.pnlBaseGrade.Controls.Add(this.label111);
            this.pnlBaseGrade.Controls.Add(this.m_chkBase1);
            this.pnlBaseGrade.Controls.Add(this.m_chkBase2);
            this.pnlBaseGrade.Controls.Add(this.m_chkBase5);
            this.pnlBaseGrade.Controls.Add(this.m_chkBase4);
            this.pnlBaseGrade.Controls.Add(this.label112);
            this.pnlBaseGrade.Controls.Add(this.label115);
            this.pnlBaseGrade.Controls.Add(this.label206);
            this.pnlBaseGrade.Controls.Add(this.m_txtBase1);
            this.pnlBaseGrade.Controls.Add(this.label207);
            this.pnlBaseGrade.Controls.Add(this.m_txtBase2);
            this.pnlBaseGrade.Controls.Add(this.m_txtBase5);
            this.pnlBaseGrade.Controls.Add(this.m_txtBase4);
            this.pnlBaseGrade.Controls.Add(this.label208);
            this.pnlBaseGrade.Controls.Add(this.label209);
            this.pnlBaseGrade.Controls.Add(this.label210);
            this.pnlBaseGrade.Controls.Add(this.label211);
            this.pnlBaseGrade.Controls.Add(this.label212);
            this.pnlBaseGrade.Controls.Add(this.label213);
            this.pnlBaseGrade.Controls.Add(this.m_chkBase3);
            this.pnlBaseGrade.Controls.Add(this.label214);
            this.pnlBaseGrade.Controls.Add(this.m_txtBase3);
            this.pnlBaseGrade.Controls.Add(this.label215);
            this.pnlBaseGrade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBaseGrade.Location = new System.Drawing.Point(0, 43);
            this.pnlBaseGrade.Name = "pnlBaseGrade";
            this.pnlBaseGrade.Size = new System.Drawing.Size(768, 404);
            this.pnlBaseGrade.TabIndex = 153;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(120, 16);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(55, 13);
            this.label109.TabIndex = 92;
            this.label109.Text = "缺陷内容";
            // 
            // label111
            // 
            this.label111.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label111.Location = new System.Drawing.Point(40, 40);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(708, 4);
            this.label111.TabIndex = 79;
            this.label111.Text = "label79";
            // 
            // m_chkBase1
            // 
            this.m_chkBase1.AccessibleDescription = "m_txtBase1";
            this.m_chkBase1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkBase1.Location = new System.Drawing.Point(44, 72);
            this.m_chkBase1.Name = "m_chkBase1";
            this.m_chkBase1.Size = new System.Drawing.Size(236, 16);
            this.m_chkBase1.TabIndex = 85;
            this.m_chkBase1.Tag = "-1";
            this.m_chkBase1.Text = "★缺整页病历记录造成病历不完整";
            // 
            // m_chkBase2
            // 
            this.m_chkBase2.AccessibleDescription = "m_txtBase2";
            this.m_chkBase2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkBase2.Location = new System.Drawing.Point(44, 112);
            this.m_chkBase2.Name = "m_chkBase2";
            this.m_chkBase2.Size = new System.Drawing.Size(308, 16);
            this.m_chkBase2.TabIndex = 84;
            this.m_chkBase2.Tag = "丙级";
            this.m_chkBase2.Text = "★缺主要项目造成病历不完整(如:入院记录、病程记录...)";
            // 
            // m_chkBase5
            // 
            this.m_chkBase5.AccessibleDescription = "m_txtBase5";
            this.m_chkBase5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkBase5.Location = new System.Drawing.Point(44, 232);
            this.m_chkBase5.Name = "m_chkBase5";
            this.m_chkBase5.Size = new System.Drawing.Size(236, 16);
            this.m_chkBase5.TabIndex = 82;
            this.m_chkBase5.Tag = "2";
            this.m_chkBase5.Text = "缺医嘱时间或医师签名";
            // 
            // m_chkBase4
            // 
            this.m_chkBase4.AccessibleDescription = "m_txtBase4";
            this.m_chkBase4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkBase4.Location = new System.Drawing.Point(44, 192);
            this.m_chkBase4.Name = "m_chkBase4";
            this.m_chkBase4.Size = new System.Drawing.Size(236, 16);
            this.m_chkBase4.TabIndex = 86;
            this.m_chkBase4.Tag = "0.2";
            this.m_chkBase4.Text = "病历楣栏填写不完整(姓名、页、住院号等)";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(352, 16);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(55, 13);
            this.label112.TabIndex = 93;
            this.label112.Text = "扣分标准";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(536, 16);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(37, 13);
            this.label115.TabIndex = 91;
            this.label115.Text = "扣  分";
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(364, 72);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(31, 13);
            this.label206.TabIndex = 87;
            this.label206.Text = "乙级";
            // 
            // m_txtBase1
            // 
            this.m_txtBase1.AccessibleDescription = "★缺整页病历记录造成病历不完整";
            this.m_txtBase1.Location = new System.Drawing.Point(516, 68);
            this.m_txtBase1.Name = "m_txtBase1";
            this.m_txtBase1.Size = new System.Drawing.Size(100, 20);
            this.m_txtBase1.TabIndex = 97;
            this.m_txtBase1.Tag = "乙级";
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Location = new System.Drawing.Point(364, 112);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(31, 13);
            this.label207.TabIndex = 89;
            this.label207.Text = "丙级";
            // 
            // m_txtBase2
            // 
            this.m_txtBase2.AccessibleDescription = "★缺主要项目造成病历不完整(如:入院记录、病程记录...)";
            this.m_txtBase2.Location = new System.Drawing.Point(516, 108);
            this.m_txtBase2.Name = "m_txtBase2";
            this.m_txtBase2.Size = new System.Drawing.Size(100, 20);
            this.m_txtBase2.TabIndex = 96;
            this.m_txtBase2.Tag = "丙级";
            // 
            // m_txtBase5
            // 
            this.m_txtBase5.AccessibleDescription = "缺医嘱时间或医师签名";
            this.m_txtBase5.Location = new System.Drawing.Point(516, 228);
            this.m_txtBase5.Name = "m_txtBase5";
            this.m_txtBase5.Size = new System.Drawing.Size(100, 20);
            this.m_txtBase5.TabIndex = 98;
            this.m_txtBase5.Tag = "2";
            // 
            // m_txtBase4
            // 
            this.m_txtBase4.AccessibleDescription = "病历楣栏填写不完整(姓名、页、住院号等)";
            this.m_txtBase4.Location = new System.Drawing.Point(516, 188);
            this.m_txtBase4.Name = "m_txtBase4";
            this.m_txtBase4.Size = new System.Drawing.Size(100, 20);
            this.m_txtBase4.TabIndex = 99;
            this.m_txtBase4.Tag = "0.2";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(364, 192);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(39, 13);
            this.label208.TabIndex = 90;
            this.label208.Text = "0.2/项";
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(364, 232);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(29, 13);
            this.label209.TabIndex = 94;
            this.label209.Text = "2/处";
            // 
            // label210
            // 
            this.label210.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label210.Location = new System.Drawing.Point(44, 256);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(650, 1);
            this.label210.TabIndex = 78;
            this.label210.Text = "label3";
            // 
            // label211
            // 
            this.label211.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label211.Location = new System.Drawing.Point(44, 216);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(650, 1);
            this.label211.TabIndex = 77;
            this.label211.Text = "label3";
            // 
            // label212
            // 
            this.label212.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label212.Location = new System.Drawing.Point(44, 96);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(650, 1);
            this.label212.TabIndex = 76;
            this.label212.Text = "label3";
            // 
            // label213
            // 
            this.label213.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label213.Location = new System.Drawing.Point(44, 136);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(650, 1);
            this.label213.TabIndex = 81;
            this.label213.Text = "label3";
            // 
            // m_chkBase3
            // 
            this.m_chkBase3.AccessibleDescription = "m_txtBase3";
            this.m_chkBase3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkBase3.Location = new System.Drawing.Point(44, 152);
            this.m_chkBase3.Name = "m_chkBase3";
            this.m_chkBase3.Size = new System.Drawing.Size(236, 16);
            this.m_chkBase3.TabIndex = 83;
            this.m_chkBase3.Tag = "1";
            this.m_chkBase3.Text = "有明显涂改";
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(364, 152);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(29, 13);
            this.label214.TabIndex = 88;
            this.label214.Text = "1/处";
            // 
            // m_txtBase3
            // 
            this.m_txtBase3.AccessibleDescription = "有明显涂改";
            this.m_txtBase3.Location = new System.Drawing.Point(516, 148);
            this.m_txtBase3.Name = "m_txtBase3";
            this.m_txtBase3.Size = new System.Drawing.Size(100, 20);
            this.m_txtBase3.TabIndex = 95;
            this.m_txtBase3.Tag = "1";
            // 
            // label215
            // 
            this.label215.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label215.Location = new System.Drawing.Point(44, 176);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(650, 1);
            this.label215.TabIndex = 80;
            this.label215.Text = "label3";
            // 
            // m_lklCalBase
            // 
            this.m_lklCalBase.AutoSize = true;
            this.m_lklCalBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lklCalBase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_lklCalBase.LinkColor = System.Drawing.Color.Red;
            this.m_lklCalBase.Location = new System.Drawing.Point(576, 9);
            this.m_lklCalBase.Name = "m_lklCalBase";
            this.m_lklCalBase.Size = new System.Drawing.Size(67, 13);
            this.m_lklCalBase.TabIndex = 152;
            this.m_lklCalBase.TabStop = true;
            this.m_lklCalBase.Text = "计算扣分：";
            this.m_tipMain.SetToolTip(this.m_lklCalBase, "点击计算本页面的总扣分");
            this.m_lklCalBase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklCalBase_LinkClicked);
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label216.ForeColor = System.Drawing.Color.Green;
            this.label216.Location = new System.Drawing.Point(8, 8);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(96, 15);
            this.label216.TabIndex = 149;
            this.label216.Text = "标准分值：  5 分";
            // 
            // m_txtBaseResult
            // 
            this.m_txtBaseResult.AccessibleDescription = "基本要求和医嘱单扣分";
            this.m_txtBaseResult.Location = new System.Drawing.Point(644, 7);
            this.m_txtBaseResult.Name = "m_txtBaseResult";
            this.m_txtBaseResult.ReadOnly = true;
            this.m_txtBaseResult.Size = new System.Drawing.Size(48, 20);
            this.m_txtBaseResult.TabIndex = 151;
            this.m_tipMain.SetToolTip(this.m_txtBaseResult, "扣分结果以标准分值为最");
            // 
            // m_lblBaseGrade
            // 
            this.m_lblBaseGrade.AutoSize = true;
            this.m_lblBaseGrade.Location = new System.Drawing.Point(696, 9);
            this.m_lblBaseGrade.Name = "m_lblBaseGrade";
            this.m_lblBaseGrade.Size = new System.Drawing.Size(0, 13);
            this.m_lblBaseGrade.TabIndex = 150;
            // 
            // tbpAgree
            // 
            this.tbpAgree.Controls.Add(this.pnlAgreeGrade);
            this.tbpAgree.Controls.Add(this.m_lklCalAgree);
            this.tbpAgree.Controls.Add(this.label232);
            this.tbpAgree.Controls.Add(this.m_txtAgreeResult);
            this.tbpAgree.Controls.Add(this.m_lblAgreeGrade);
            this.tbpAgree.Location = new System.Drawing.Point(0, 25);
            this.tbpAgree.Name = "tbpAgree";
            this.tbpAgree.Selected = false;
            this.tbpAgree.Size = new System.Drawing.Size(768, 447);
            this.tbpAgree.TabIndex = 10;
            this.tbpAgree.Title = "知情同意书";
            this.tbpAgree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tabMain_MouseUp);
            // 
            // pnlAgreeGrade
            // 
            this.pnlAgreeGrade.Controls.Add(this.label218);
            this.pnlAgreeGrade.Controls.Add(this.label219);
            this.pnlAgreeGrade.Controls.Add(this.m_chkAgree1);
            this.pnlAgreeGrade.Controls.Add(this.m_chkAgree2);
            this.pnlAgreeGrade.Controls.Add(this.m_chkAgree5);
            this.pnlAgreeGrade.Controls.Add(this.m_chkAgree4);
            this.pnlAgreeGrade.Controls.Add(this.label220);
            this.pnlAgreeGrade.Controls.Add(this.label221);
            this.pnlAgreeGrade.Controls.Add(this.label222);
            this.pnlAgreeGrade.Controls.Add(this.m_txtAgree1);
            this.pnlAgreeGrade.Controls.Add(this.label223);
            this.pnlAgreeGrade.Controls.Add(this.m_txtAgree2);
            this.pnlAgreeGrade.Controls.Add(this.m_txtAgree5);
            this.pnlAgreeGrade.Controls.Add(this.m_txtAgree4);
            this.pnlAgreeGrade.Controls.Add(this.label224);
            this.pnlAgreeGrade.Controls.Add(this.label225);
            this.pnlAgreeGrade.Controls.Add(this.label226);
            this.pnlAgreeGrade.Controls.Add(this.label227);
            this.pnlAgreeGrade.Controls.Add(this.label228);
            this.pnlAgreeGrade.Controls.Add(this.label229);
            this.pnlAgreeGrade.Controls.Add(this.m_chkAgree3);
            this.pnlAgreeGrade.Controls.Add(this.label230);
            this.pnlAgreeGrade.Controls.Add(this.m_txtAgree3);
            this.pnlAgreeGrade.Controls.Add(this.label231);
            this.pnlAgreeGrade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAgreeGrade.Location = new System.Drawing.Point(0, 43);
            this.pnlAgreeGrade.Name = "pnlAgreeGrade";
            this.pnlAgreeGrade.Size = new System.Drawing.Size(768, 404);
            this.pnlAgreeGrade.TabIndex = 153;
            // 
            // label218
            // 
            this.label218.AutoSize = true;
            this.label218.Location = new System.Drawing.Point(120, 16);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(55, 13);
            this.label218.TabIndex = 92;
            this.label218.Text = "缺陷内容";
            // 
            // label219
            // 
            this.label219.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label219.Location = new System.Drawing.Point(40, 40);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(708, 4);
            this.label219.TabIndex = 79;
            this.label219.Text = "label79";
            // 
            // m_chkAgree1
            // 
            this.m_chkAgree1.AccessibleDescription = "m_txtAgree1";
            this.m_chkAgree1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkAgree1.Location = new System.Drawing.Point(44, 72);
            this.m_chkAgree1.Name = "m_chkAgree1";
            this.m_chkAgree1.Size = new System.Drawing.Size(288, 16);
            this.m_chkAgree1.TabIndex = 85;
            this.m_chkAgree1.Tag = "-1";
            this.m_chkAgree1.Text = "★缺特殊检查(治疗)同意书或缺患者(近亲属)签名";
            // 
            // m_chkAgree2
            // 
            this.m_chkAgree2.AccessibleDescription = "m_txtAgree2";
            this.m_chkAgree2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkAgree2.Location = new System.Drawing.Point(44, 112);
            this.m_chkAgree2.Name = "m_chkAgree2";
            this.m_chkAgree2.Size = new System.Drawing.Size(236, 16);
            this.m_chkAgree2.TabIndex = 84;
            this.m_chkAgree2.Tag = "5";
            this.m_chkAgree2.Text = "★缺手术同意书或缺患者(近亲属)签名";
            // 
            // m_chkAgree5
            // 
            this.m_chkAgree5.AccessibleDescription = "m_txtAgree5";
            this.m_chkAgree5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkAgree5.Location = new System.Drawing.Point(44, 232);
            this.m_chkAgree5.Name = "m_chkAgree5";
            this.m_chkAgree5.Size = new System.Drawing.Size(236, 16);
            this.m_chkAgree5.TabIndex = 82;
            this.m_chkAgree5.Tag = "2";
            this.m_chkAgree5.Text = "缺尸体解剖同意书";
            // 
            // m_chkAgree4
            // 
            this.m_chkAgree4.AccessibleDescription = "m_txtAgree4";
            this.m_chkAgree4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkAgree4.Location = new System.Drawing.Point(44, 192);
            this.m_chkAgree4.Name = "m_chkAgree4";
            this.m_chkAgree4.Size = new System.Drawing.Size(272, 16);
            this.m_chkAgree4.TabIndex = 86;
            this.m_chkAgree4.Tag = "1";
            this.m_chkAgree4.Text = "放弃治疗或抢救，缺患者(近亲属)意见或签名";
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(352, 16);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(55, 13);
            this.label220.TabIndex = 93;
            this.label220.Text = "扣分标准";
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Location = new System.Drawing.Point(536, 16);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(37, 13);
            this.label221.TabIndex = 91;
            this.label221.Text = "扣  分";
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Location = new System.Drawing.Point(364, 72);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(31, 13);
            this.label222.TabIndex = 87;
            this.label222.Text = "乙级";
            // 
            // m_txtAgree1
            // 
            this.m_txtAgree1.AccessibleDescription = "★缺特殊检查(治疗)同意书或缺患者(近亲属)签名";
            this.m_txtAgree1.Location = new System.Drawing.Point(516, 68);
            this.m_txtAgree1.Name = "m_txtAgree1";
            this.m_txtAgree1.Size = new System.Drawing.Size(100, 20);
            this.m_txtAgree1.TabIndex = 97;
            this.m_txtAgree1.Tag = "乙级";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Location = new System.Drawing.Point(364, 112);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(31, 13);
            this.label223.TabIndex = 89;
            this.label223.Text = "乙级";
            // 
            // m_txtAgree2
            // 
            this.m_txtAgree2.AccessibleDescription = "★缺手术同意书或缺患者(近亲属)签名";
            this.m_txtAgree2.Location = new System.Drawing.Point(516, 108);
            this.m_txtAgree2.Name = "m_txtAgree2";
            this.m_txtAgree2.Size = new System.Drawing.Size(100, 20);
            this.m_txtAgree2.TabIndex = 96;
            this.m_txtAgree2.Tag = "乙级";
            // 
            // m_txtAgree5
            // 
            this.m_txtAgree5.AccessibleDescription = "缺尸体解剖同意书";
            this.m_txtAgree5.Location = new System.Drawing.Point(516, 228);
            this.m_txtAgree5.Name = "m_txtAgree5";
            this.m_txtAgree5.Size = new System.Drawing.Size(100, 20);
            this.m_txtAgree5.TabIndex = 98;
            this.m_txtAgree5.Tag = "5";
            // 
            // m_txtAgree4
            // 
            this.m_txtAgree4.AccessibleDescription = "放弃治疗或抢救，缺患者(近亲属)意见或签名";
            this.m_txtAgree4.Location = new System.Drawing.Point(516, 188);
            this.m_txtAgree4.Name = "m_txtAgree4";
            this.m_txtAgree4.Size = new System.Drawing.Size(100, 20);
            this.m_txtAgree4.TabIndex = 99;
            this.m_txtAgree4.Tag = "5";
            // 
            // label224
            // 
            this.label224.AutoSize = true;
            this.label224.Location = new System.Drawing.Point(364, 192);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(13, 13);
            this.label224.TabIndex = 90;
            this.label224.Text = "5";
            // 
            // label225
            // 
            this.label225.AutoSize = true;
            this.label225.Location = new System.Drawing.Point(364, 232);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(13, 13);
            this.label225.TabIndex = 94;
            this.label225.Text = "5";
            // 
            // label226
            // 
            this.label226.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label226.Location = new System.Drawing.Point(44, 256);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(650, 1);
            this.label226.TabIndex = 78;
            this.label226.Text = "label3";
            // 
            // label227
            // 
            this.label227.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label227.Location = new System.Drawing.Point(44, 216);
            this.label227.Name = "label227";
            this.label227.Size = new System.Drawing.Size(650, 1);
            this.label227.TabIndex = 77;
            this.label227.Text = "label3";
            // 
            // label228
            // 
            this.label228.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label228.Location = new System.Drawing.Point(44, 96);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(650, 1);
            this.label228.TabIndex = 76;
            this.label228.Text = "label3";
            // 
            // label229
            // 
            this.label229.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label229.Location = new System.Drawing.Point(44, 136);
            this.label229.Name = "label229";
            this.label229.Size = new System.Drawing.Size(650, 1);
            this.label229.TabIndex = 81;
            this.label229.Text = "label3";
            // 
            // m_chkAgree3
            // 
            this.m_chkAgree3.AccessibleDescription = "m_txtAgree3";
            this.m_chkAgree3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkAgree3.Location = new System.Drawing.Point(44, 152);
            this.m_chkAgree3.Name = "m_chkAgree3";
            this.m_chkAgree3.Size = new System.Drawing.Size(236, 16);
            this.m_chkAgree3.TabIndex = 83;
            this.m_chkAgree3.Tag = "2";
            this.m_chkAgree3.Text = "特殊检查(治疗)、手术同意书缺项";
            this.m_tipMain.SetToolTip(this.m_chkAgree3, "包括主诉、入院情况、入院诊断、诊疗经过、出院情况，出院诊断，出院医嘱、医师签名。");
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.Location = new System.Drawing.Point(364, 152);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(29, 13);
            this.label230.TabIndex = 88;
            this.label230.Text = "2/项";
            this.m_tipMain.SetToolTip(this.label230, "包括主诉、入院情况、入院诊断、诊疗经过、出院情况，出院诊断，出院医嘱、医师签名。");
            // 
            // m_txtAgree3
            // 
            this.m_txtAgree3.AccessibleDescription = "特殊检查(治疗)、手术同意书缺项";
            this.m_txtAgree3.Location = new System.Drawing.Point(516, 148);
            this.m_txtAgree3.Name = "m_txtAgree3";
            this.m_txtAgree3.Size = new System.Drawing.Size(100, 20);
            this.m_txtAgree3.TabIndex = 95;
            this.m_txtAgree3.Tag = "2";
            this.m_tipMain.SetToolTip(this.m_txtAgree3, "包括主诉、入院情况、入院诊断、诊疗经过、出院情况，出院诊断，出院医嘱、医师签名。");
            // 
            // label231
            // 
            this.label231.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label231.Location = new System.Drawing.Point(44, 176);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(650, 1);
            this.label231.TabIndex = 80;
            this.label231.Text = "label3";
            // 
            // m_lklCalAgree
            // 
            this.m_lklCalAgree.AutoSize = true;
            this.m_lklCalAgree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lklCalAgree.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_lklCalAgree.LinkColor = System.Drawing.Color.Red;
            this.m_lklCalAgree.Location = new System.Drawing.Point(576, 9);
            this.m_lklCalAgree.Name = "m_lklCalAgree";
            this.m_lklCalAgree.Size = new System.Drawing.Size(67, 13);
            this.m_lklCalAgree.TabIndex = 152;
            this.m_lklCalAgree.TabStop = true;
            this.m_lklCalAgree.Text = "计算扣分：";
            this.m_tipMain.SetToolTip(this.m_lklCalAgree, "点击计算本页面的总扣分");
            this.m_lklCalAgree.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklCalAgree_LinkClicked);
            // 
            // label232
            // 
            this.label232.AutoSize = true;
            this.label232.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label232.ForeColor = System.Drawing.Color.Green;
            this.label232.Location = new System.Drawing.Point(8, 8);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(102, 15);
            this.label232.TabIndex = 149;
            this.label232.Text = "标准分值：  10 分";
            // 
            // m_txtAgreeResult
            // 
            this.m_txtAgreeResult.AccessibleDescription = "知情同意书扣分";
            this.m_txtAgreeResult.Location = new System.Drawing.Point(644, 7);
            this.m_txtAgreeResult.Name = "m_txtAgreeResult";
            this.m_txtAgreeResult.ReadOnly = true;
            this.m_txtAgreeResult.Size = new System.Drawing.Size(48, 20);
            this.m_txtAgreeResult.TabIndex = 151;
            this.m_tipMain.SetToolTip(this.m_txtAgreeResult, "扣分结果以标准分值为最");
            // 
            // m_lblAgreeGrade
            // 
            this.m_lblAgreeGrade.AutoSize = true;
            this.m_lblAgreeGrade.Location = new System.Drawing.Point(696, 9);
            this.m_lblAgreeGrade.Name = "m_lblAgreeGrade";
            this.m_lblAgreeGrade.Size = new System.Drawing.Size(0, 13);
            this.m_lblAgreeGrade.TabIndex = 150;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(16, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(756, 3);
            this.label1.TabIndex = 10000005;
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.Location = new System.Drawing.Point(12, 12);
            this.trvTime.Name = "trvTime";
            treeNode1.Name = "";
            treeNode1.Text = "入院日期";
            this.trvTime.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(212, 56);
            this.trvTime.TabIndex = 10000089;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // frmCaseGrade
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_tabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaseGrade";
            this.Text = "住院病历评分";
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_tabMain, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_tabMain.ResumeLayout(false);
            this.tbpResult.ResumeLayout(false);
            this.tbpResult.PerformLayout();
            this.tbp1st.ResumeLayout(false);
            this.tbp1st.PerformLayout();
            this.pnlMainGrade.ResumeLayout(false);
            this.pnlMainGrade.PerformLayout();
            this.tbpInPatientRec.ResumeLayout(false);
            this.tbpInPatientRec.PerformLayout();
            this.pnlInPatientGeade.ResumeLayout(false);
            this.pnlInPatientGeade.PerformLayout();
            this.tbpDiseaseTrack.ResumeLayout(false);
            this.tbpDiseaseTrack.PerformLayout();
            this.pnlDiseaseTrack2.ResumeLayout(false);
            this.pnlDiseaseTrack2.PerformLayout();
            this.pnlDiseaseTrack1.ResumeLayout(false);
            this.pnlDiseaseTrack1.PerformLayout();
            this.tbpOutHospital.ResumeLayout(false);
            this.tbpOutHospital.PerformLayout();
            this.pnlOutGrade.ResumeLayout(false);
            this.pnlOutGrade.PerformLayout();
            this.tbpCheck.ResumeLayout(false);
            this.tbpCheck.PerformLayout();
            this.pnlCheckGrade.ResumeLayout(false);
            this.pnlCheckGrade.PerformLayout();
            this.tbpBasis.ResumeLayout(false);
            this.tbpBasis.PerformLayout();
            this.pnlBaseGrade.ResumeLayout(false);
            this.pnlBaseGrade.PerformLayout();
            this.tbpAgree.ResumeLayout(false);
            this.tbpAgree.PerformLayout();
            this.pnlAgreeGrade.ResumeLayout(false);
            this.pnlAgreeGrade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		#region 接口
		public void Copy()
		{
			
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Cut()
		{
			
		}

		public void Delete()
		{
            //long m_lngRe=m_lngDelete(); 
            //if(m_lngRe>0)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("删除成功！");
            //    if(this.trvTime.SelectedNode!=null)
            //    {
            //        this.trvTime_AfterSelect(this.trvTime,new TreeViewEventArgs(this.trvTime.SelectedNode));
            //    }
            //}
		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
			
		}

		public void Print()
		{
            //m_lngPrint();
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
            //long m_lngRe=m_lngSave(); 
            //if(m_lngRe>0)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("保存成功！");
            //    if(this.trvTime.SelectedNode!=null)
            //    {
            //        this.trvTime_AfterSelect(this.trvTime,new TreeViewEventArgs(this.trvTime.SelectedNode));
            //    }
				
            //}
		}


				
		public void Undo()
		{
		
		}

		#endregion

		protected override long m_lngSubAddNew()
		{
			if(m_objBaseCurrentPatient == null)
			{
				return (long)enmOperationResult.Parameter_Error;
			}
			if(trvTime.SelectedNode.Equals(trvTime.Nodes[0]) || trvTime.SelectedNode == null)
			{
#if !Debug
				clsPublicFunction.ShowInformationMessageBox("请选择病人入院日期。");
#endif
				return -7;
			}
			m_objDomain.m_lngDeleteGradeInfo(m_objBaseCurrentPatient.m_StrInPatientID,trvTime.SelectedNode.Tag.ToString());
			clsCaseGradeValue objGradeValue = new clsCaseGradeValue();
			objGradeValue.m_strInPatientID = m_objBaseCurrentPatient.m_StrInPatientID;
            objGradeValue.m_strInPatientDate = trvTime.SelectedNode.Tag.ToString();
			objGradeValue.m_strOpenDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			objGradeValue.m_objItemValueArr = m_objGetInfoFromGUI();
			if(objGradeValue.m_objItemValueArr == null)
				return (long)enmOperationResult.Parameter_Error;
			long lngRes = m_objDomain.m_lngSaveGradeInfo(objGradeValue);
			#region 结果处理
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					m_objCurrentRecord = objGradeValue; 
					break;   
				case enmOperationResult.Record_Already_Exist:
					m_mthShowRecordTimeDouble();
					return lngRes;
			}
			this.trvTime.ExpandAll();
			return lngRes;
			#endregion
		}
		protected override long m_lngSubDelete()
		{
			//检查当前病人变量是否为null  
			if(m_objBaseCurrentPatient ==null)
			{
				clsPublicFunction.ShowInformationMessageBox("未选定病人,无法删除!");
				return (long)enmOperationResult.Parameter_Error; 
			}
			if(trvTime.SelectedNode.Equals(trvTime.Nodes[0]) || trvTime.SelectedNode == null)
			{
#if !Debug
				clsPublicFunction.ShowInformationMessageBox("未选定病人入院日期,无法删除!");
#endif
				return -7;
			}
			long lngRes = m_objDomain.m_lngDeleteGradeInfo(m_objBaseCurrentPatient.m_StrInPatientID,trvTime.SelectedNode.Tag.ToString());
			return lngRes;
		}

        private clsDepartment[] objDeptArr = null;
		/// <summary>
		/// 初始化信息
		/// </summary>
		private void m_mthInitilize()
		{
			pnlDiseaseTrack1.Tag = "";
			pnlDiseaseTrack2.Tag = "";
			pnlMainGrade.Tag = "";
			pnlInPatientGeade.Tag = "";
			pnlOutGrade.Tag = "";

            //clsDepartment[] objDeptArr;
            objDeptArr = new clsDepartmentManager().m_objGetAllInDeptArr();		
			if(objDeptArr !=null)
			{
				m_cboDept.ClearItem();
				for(int i=0;i<objDeptArr.Length;i++)
				{
					if(objDeptArr[i].m_StrDeptName != "")
						m_cboDept.AddItem(objDeptArr[i]);
				}
			}
			if(m_cboDept.GetItemsCount() > 0)
				m_cboDept.SelectedIndex = 0;
            m_mthAddCheckedEvent(m_tabMain);

            if (!s_blnIsBas)
            {
                m_cmdSave.Enabled = false;
                m_cmdDelete.Enabled = false;
            }
			
		}

		private void m_mthCheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox chkCurrent = sender as CheckBox;
			foreach(Control ctl in chkCurrent.Parent.Controls)
			{
				if(ctl.Name == chkCurrent.AccessibleDescription.Trim())
				{
                    if (chkCurrent.Checked)
                    {
                        ctl.Text = ctl.Tag.ToString();
                    }
                    else
                    {
                        ctl.Text = "";
                    }
					break;
				}
			}
		}
		private void m_mthAddCheckedEvent(Control p_objSender)
		{
			if(!p_objSender.HasChildren)
			{
				if(p_objSender is CheckBox)
					((CheckBox)p_objSender).CheckedChanged += new System.EventHandler(m_mthCheckedChanged);
			}
			else
			{
				foreach(Control ctl in p_objSender.Controls)
				{
					m_mthAddCheckedEvent(ctl);
				}
			}
		}

		private void m_rdb_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_rdbOne.Checked == true)
			{
				m_rdbOne.BackColor = Color.White;
				m_rdbOne.ForeColor = Color.Blue;
				m_rdbTwo.BackColor = Color.Silver;
				m_rdbTwo.ForeColor = Color.DimGray;
			}
			else
			{
				m_rdbOne.BackColor = Color.Silver;
				m_rdbOne.ForeColor = Color.DimGray;
				m_rdbTwo.BackColor = Color.White;
				m_rdbTwo.ForeColor = Color.Blue;
			}
			pnlDiseaseTrack1.Visible = m_rdbOne.Checked;
			pnlDiseaseTrack2.Visible = m_rdbTwo.Checked;
		}

		// 设置病人表单信息

        private string[] m_strHISInPatientIDArr = null;
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			//判断病人信息是否为null，如果是，直接返回。
			if(p_objSelectedPatient == null)
				return; 

			m_lblRePatientName.Text = p_objSelectedPatient.m_StrName;
			m_lblReInpatientID.Text = p_objSelectedPatient.m_StrInPatientID;

			//获取病人记录列表
            string[] p_strEMRInPatientDateArr = null;
            string[] p_strHISInPatientDateArr=null;

            long lngRes = m_objDomain.m_lngGetAllInPatientTime(p_objSelectedPatient.m_StrInPatientID, out p_strEMRInPatientDateArr, out p_strHISInPatientDateArr, out m_strHISInPatientIDArr);

            if (lngRes <= 0 || p_strEMRInPatientDateArr.Length <= 0)
				return;

			//清空时间列表树的时间节点   
			if(trvTime.Nodes[0].Nodes.Count >0)
				trvTime.Nodes[0].Nodes.Clear();

			//添加查询到的入院时间到时间树上
            for (int i = 0; i < p_strHISInPatientDateArr.Length; i++)
			{
                TreeNode trnRecordDate = new TreeNode(DateTime.Parse(p_strHISInPatientDateArr[i]).ToString("yyyy年MM月dd日 HH:mm:ss"));
                trnRecordDate.Tag = p_strEMRInPatientDateArr[i];
				trvTime.Nodes[0].Nodes.Add(trnRecordDate);	
				trvTime.ExpandAll();					
			}			

			//选中默认节点
			for(int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
			{
                if (DateTime.Parse(p_strEMRInPatientDateArr[i]) == p_objSelectedPatient.m_DtmSelectedInDate)
					trvTime.SelectedNode = trvTime.Nodes[0].Nodes[i];
			}

			m_mthSetSelectedRecord();
			#region
			Hashtable hasContent;
			m_objDomain.m_lngGetDetailInfo(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),out hasContent);
			if(hasContent != null)
			{
                m_chkMain3.Checked = !hasContent.ContainsKey("门诊诊断") || (string)hasContent["门诊诊断"] != "" ? false : true;
                m_chkMain5.Checked = !hasContent.ContainsKey("入院诊断") || (string)hasContent["入院诊断"] != "" ? false : true;
                m_chkMain7.Checked = !hasContent.ContainsKey("出院诊断") || (string)hasContent["出院诊断"] != "" ? false : true;
                m_chkMain13.Checked = !hasContent.ContainsKey("病理诊断") || (string)hasContent["病理诊断"] != "" ? false : true;
                m_chkMain15.Checked = !hasContent.ContainsKey("过敏药物") || (string)hasContent["过敏药物"] != "" ? false : true;

                m_chkDiseaseTwo8.Checked = !hasContent.ContainsKey("交接班记录") || (string)hasContent["交接班记录"] != "0" ? false : true;
                m_chkDiseaseTwo10.Checked = !hasContent.ContainsKey("转入转出记录") || (string)hasContent["转入转出记录"] != "0" ? false : true;
                m_chkDiseaseTwo9.Checked = !hasContent.ContainsKey("阶段小结") || (string)hasContent["阶段小结"] != "0" ? false : true;
                m_chkDiseaseTwo13.Checked = !hasContent.ContainsKey("死亡病例讨论") || (string)hasContent["死亡病例讨论"] != "0" ? false : true;
                m_chkDiseaseTwo15.Checked = !hasContent.ContainsKey("会诊记录") || (string)hasContent["会诊记录"] != "0" ? false : true;
                m_chkDiseaseOne4.Checked = !hasContent.ContainsKey("术前小结") || (string)hasContent["术前小结"] != "0" ? false : true;
                m_chkDiseaseOne10.Checked = !hasContent.ContainsKey("手术记录单") || (string)hasContent["手术记录单"] != "0" ? false : true;
                m_chkOutHos1.Checked = !hasContent.ContainsKey("出院记录") || (string)hasContent["出院记录"] != "0" ? false : true;
                m_chkAgree2.Checked = !hasContent.ContainsKey("手术知情同意书") || (string)hasContent["手术知情同意书"] != "0" ? false : true;
				
			}
			#endregion
			if(m_objCurrentRecord != null)
				m_cmdDisPlayResult.PerformClick();
		}

		private void m_lklMainResult_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			float fltRe = m_fltCalResult(pnlMainGrade);
			m_txtMainResult.Text = fltRe > 10F?"10":fltRe.ToString();
			m_lblMainGrade.Text = pnlMainGrade.Tag as string;
		}

		private void m_lklCalInPatResult_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			float fltRe = m_fltCalResult(pnlInPatientGeade);
			m_txtInPatResult.Text = fltRe > 20F?"20":fltRe.ToString();
			m_lblInPatGeade.Text = pnlInPatientGeade.Tag as string;
		}

		private void m_lklCalDisease_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			float fltRe =  m_fltCalResult(new Panel[]{pnlDiseaseTrack1,pnlDiseaseTrack2});
			m_txtDiseaseResult.Text = fltRe > 40F?"40":fltRe.ToString();
			string[] strTemp = new string[2];
			strTemp[0] = pnlDiseaseTrack1.Tag as string;
			strTemp[1] = pnlDiseaseTrack2.Tag as string;
			if(strTemp[0] == "丙级" || strTemp[1] == "丙级")
				m_lblDisGrade.Text = "丙级";
			else if(strTemp[0] == "乙级" || strTemp[1] == "乙级")
				m_lblDisGrade.Text = "乙级";
		}

		private void m_lklCalOutResult_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			float fltRe = m_fltCalResult(pnlOutGrade);
			m_txtOutResult.Text = fltRe > 10F?"10":fltRe.ToString();
			m_lblOutgrade.Text = pnlOutGrade.Tag as string;
		}
		private float m_fltStringToFloat(string p_strText)
		{
			if(p_strText =="")
				return 0;
			if(p_strText == "乙级")
				return -1F;
			else if(p_strText == "丙级")
				return -2F;
			float fltRe = 0;
			try
			{
				fltRe = float.Parse(p_strText);
			}
			catch
			{}
			return fltRe;
		}
		private float m_fltCalResult(Panel p_pnlSender)
		{
			if(!p_pnlSender.HasChildren)
				return 0;
			float fltTemp = 0;
			string str = "";
			foreach(Control ctl in p_pnlSender.Controls)
			{
				if(ctl is TextBox)
				{
					float fltCal = m_fltStringToFloat(ctl.Text.Trim());
					if(fltCal > 0)
						fltTemp += fltCal;
					else if(fltCal == -1F && str != "丙级")
						str = "乙级";
					else if(fltCal == -2F)
						str = "丙级";
				}
			}
			p_pnlSender.Tag = str;
			return fltTemp;
		}
		private float m_fltCalResult(Panel[] p_pnlSenderArr)
		{
			float fltResult = 0;
			for(int i=0;i<p_pnlSenderArr.Length;i++)
			{
				fltResult += m_fltCalResult(p_pnlSenderArr[i]);
			}
			return fltResult;
		}

		private void m_tabMain_SelectionChanged(object sender, System.EventArgs e)
		{
//			if(((Crownwood.Magic.Controls.TabPage)sender).Title == "评分结果")
//			{
//				
//			}
		}

		private void m_cmdDisPlayResult_Click(object sender, System.EventArgs e)
		{
			string strResult = "";
			string strReason = "";
			float fltResult = 0;
			this.Cursor = Cursors.WaitCursor;
			m_lklMainResult_LinkClicked(null,null);
			m_lklCalInPatResult_LinkClicked(null,null);
			m_lklCalDisease_LinkClicked(null,null);
			m_lklCalOutResult_LinkClicked(null,null);
			m_lklCalCheck_LinkClicked(null,null);
			m_lklCalBase_LinkClicked(null,null);
			m_lklCalAgree_LinkClicked(null,null);
			#region Cal Result
			float fltRe = m_fltStringToFloat(m_txtMainResult.Text.Trim());
			if(fltRe > 0)
				fltResult += fltRe;
			strReason += "其中：首页扣 " + (fltRe > 0?fltRe.ToString():"0") +"分";
			if(m_lblMainGrade.Text.Trim() != "")
				strReason += ",至少有一项被评定为\"" + m_lblMainGrade.Text + "\"";

			fltRe = m_fltStringToFloat(m_txtInPatResult.Text.Trim());
			if(fltRe > 0)
				fltResult += fltRe;
			strReason += ";\n　　 　入院记录扣 " + (fltRe > 0?fltRe.ToString():"0") +"分";
			if(m_lblInPatGeade.Text.Trim() != "")
				strReason += ",至少有一项被评定为\"" + m_lblInPatGeade.Text + "\"";
			
			fltRe = m_fltStringToFloat(m_txtDiseaseResult.Text.Trim());
			if(fltRe > 0)
				fltResult += fltRe;
			strReason += ";\n　　 　病程记录扣 " + (fltRe > 0?fltRe.ToString():"0") +"分";
			if(m_lblDisGrade.Text.Trim() != "")
				strReason += ",至少有一项被评定为\"" + m_lblDisGrade.Text + "\"";

			fltRe = m_fltStringToFloat(m_txtOutResult.Text.Trim());
			if(fltRe > 0)
				fltResult += fltRe;
			strReason += ";\n　　 　出院记录扣 " + (fltRe > 0?fltRe.ToString():"0") +"分";
			if(m_lblOutgrade.Text.Trim() != "")
				strReason += ",至少有一项被评定为\"" + m_lblOutgrade.Text + "\"。";

			fltRe = m_fltStringToFloat(m_txtCheckResult.Text.Trim());
			if(fltRe > 0)
				fltResult += fltRe;
			strReason += ";\n　　 　 辅助检查扣 " + (fltRe > 0?fltRe.ToString():"0") +"分";
			if(m_lblCheckGrade.Text.Trim() != "")
				strReason += ",至少有一项被评定为\"" + m_lblCheckGrade.Text + "\"。";

			fltRe = m_fltStringToFloat(m_txtBaseResult.Text.Trim());
			if(fltRe > 0)
				fltResult += fltRe;
			strReason += ";\n　　 　基本要求和医嘱单扣 " + (fltRe > 0?fltRe.ToString():"0") +"分";
			if(m_lblBaseGrade.Text.Trim() != "")
				strReason += ",至少有一项被评定为\"" + m_lblBaseGrade.Text + "\"。";

			fltRe = m_fltStringToFloat(m_txtAgreeResult.Text.Trim());
			if(fltRe > 0)
				fltResult += fltRe;
			strReason += ";\n　　 　知情同意书扣 " + (fltRe > 0?fltRe.ToString():"0") +"分";
			if(m_lblAgreeGrade.Text.Trim() != "")
				strReason += ",至少有一项被评定为\"" + m_lblAgreeGrade.Text + "\"。";

			strReason += ";\n总计扣分：  "+fltResult.ToString() + "分";

			if(m_lblMainGrade.Text.Trim() == "丙级" || m_lblInPatGeade.Text.Trim() == "丙级" || m_lblDisGrade.Text.Trim() == "丙级" || m_lblOutgrade.Text.Trim() == "丙级" || m_lblCheckGrade.Text.Trim() == "丙级" || m_lblBaseGrade.Text.Trim() == "丙级" || m_lblAgreeGrade.Text.Trim() == "丙级")
				strResult = "丙级";
			else if(m_lblMainGrade.Text.Trim() == "乙级" || m_lblInPatGeade.Text.Trim() == "乙级" || m_lblDisGrade.Text.Trim() == "乙级" || m_lblOutgrade.Text.Trim() == "乙级" || m_lblCheckGrade.Text.Trim() == "乙级" || m_lblBaseGrade.Text.Trim() == "乙级" || m_lblAgreeGrade.Text.Trim() == "乙级")
				strResult = "乙级";
			fltResult = 100F - fltResult;
            if (strResult != "丙级")
            {
                if (strResult != "乙级")
                {
                    if (fltResult >= 90F)
                        strResult = "甲级";
                    else if (fltResult >= 75F && fltResult < 90F)
                        strResult = "乙级";
                    else
                        strResult = "丙级";
                }
                else if (fltResult < 75F)
                    strResult = "丙级";
            }
			m_txtAllResult.Text = strResult;
			m_lblReason.Text = strReason;
			#endregion
			this.Cursor = Cursors.Default;
		}

		/// <summary>
		///循环清除界面值
		/// </summary>
		/// <param name="p_ctlSender"></param>
		private void m_mthClearAll(Control p_ctlSender)
		{
			if(p_ctlSender.HasChildren)
			{
				foreach(Control ctl in p_ctlSender.Controls)
				{
					m_mthClearAll(ctl);
				}
			}
			else
			{
				if(p_ctlSender is CheckBox)
					((CheckBox)p_ctlSender).Checked = false;
				else if(p_ctlSender is TextBox)
					((TextBox)p_ctlSender).Text = "";
			}
		}

		/// <summary>
		/// 清除界面值
		/// </summary>
		private void m_mthClearGUIInfo()
		{
			m_mthClearAll(m_tabMain);
			pnlDiseaseTrack1.Tag = "";
			pnlDiseaseTrack2.Tag = "";
			pnlMainGrade.Tag = "";
			pnlInPatientGeade.Tag = "";
			pnlOutGrade.Tag = "";
			m_lblNotify.Text = "";
            m_lblReason.Text = "";
            m_lblAgreeGrade.Text = "";
            m_lblBaseGrade.Text = "";
            m_lblCheckGrade.Text = "";
            m_lblDisGrade.Text = "";
            m_lblInPatGeade.Text = "";
            m_lblMainGrade.Text = "";
            m_lblOutgrade.Text = "";
		}
		/// <summary>
		/// 从界面取值
		/// </summary>
		private clsCaseGrade_ItemValue[] m_objGetInfoFromGUI()
		{
			m_arlItems.Clear();

			m_mthAddItemToArray(m_tabMain);

			if(m_arlItems.Count > 0)
				return (clsCaseGrade_ItemValue[])m_arlItems.ToArray(typeof(clsCaseGrade_ItemValue));
		
			return null;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_ctlSender"></param>
		private void m_mthAddItemToArray(Control p_ctlSender)
		{
			if(!p_ctlSender.HasChildren)
			{
				bool blnAdd = false;
				clsCaseGrade_ItemValue objItem = new clsCaseGrade_ItemValue();
				objItem.m_strItemID = p_ctlSender.Name;
				switch(p_ctlSender.GetType().Name)
				{
					case "CheckBox":
						CheckBox chkRTB = (CheckBox)p_ctlSender;
						if(chkRTB.Checked)
						{
							objItem.m_strItemContent = chkRTB.Checked.ToString();
							blnAdd = true;
						}
						break;
					case "TextBox":
						TextBox txtRTB = (TextBox)p_ctlSender;
						if(txtRTB.Text != "")
						{
                            objItem.m_strItemContent = txtRTB.Text;
                            if (txtRTB.Name == "m_txtMainResult" && m_lblMainGrade.Text.Length > 0)
                                objItem.m_strItemContent += ";" + m_lblMainGrade.Text;
                            else if (txtRTB.Name == "m_txtInPatResult" && m_lblInPatGeade.Text.Length > 0)
                                objItem.m_strItemContent += ";" + m_lblInPatGeade.Text;
                            else if (txtRTB.Name == "m_txtDiseaseResult" && m_lblDisGrade.Text.Length > 0)
                                objItem.m_strItemContent += ";" + m_lblDisGrade.Text;
                            else if (txtRTB.Name == "m_txtOutResult" && m_lblOutgrade.Text.Length > 0)
                                objItem.m_strItemContent += ";" + m_lblOutgrade.Text;
                            else if (txtRTB.Name == "m_txtCheckResult" && m_lblCheckGrade.Text.Length > 0)
                                objItem.m_strItemContent += ";" + m_lblCheckGrade.Text;
                            else if (txtRTB.Name == "m_txtBaseResult" && m_lblBaseGrade.Text.Length > 0)
                                objItem.m_strItemContent += ";" + m_lblBaseGrade.Text;
                            else if (txtRTB.Name == "m_txtAgreeResult" && m_lblAgreeGrade.Text.Length > 0)
                                objItem.m_strItemContent += ";" + m_lblAgreeGrade.Text; 
							objItem.m_strDescription = txtRTB.AccessibleDescription;
							blnAdd = true;
						}
						break;
					default:
						break;
				}
				if(blnAdd)
				{
					m_arlItems.Add(objItem);
				}
			}
			else
			{
				for(int i=0;i<p_ctlSender.Controls.Count;i++)
					m_mthAddItemToArray(p_ctlSender.Controls[i]);
			}
		}
		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			if(this.trvTime.SelectedNode.Parent!=null )
			{
                if (m_strHISInPatientIDArr != null && m_strHISInPatientIDArr.Length > 0)
                {
                    txtInPatientID.Text = m_strHISInPatientIDArr[trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1];
                }
				m_mthClearGUIInfo();

                m_mthIsReadOnly();

                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				m_mthSetSelectedRecord();
				if(m_objCurrentRecord != null)
				{
					//当前处于修改记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
				}
				else
				{
					//当前处于新增记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				}
			}
			else
			{
				m_mthClearGUIInfo();
				m_objCurrentRecord =null;
				//当前处于禁止输入状态
//				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.None );				
			}

			m_mthAddFormStatusForClosingSave();
		}
		/// <summary>
		/// 设置选择的记录
		/// </summary>
		private void m_mthSetSelectedRecord()
		{
			if(this.trvTime.SelectedNode == null || this.trvTime.SelectedNode.Text.ToString() == "")
				return;

			clsCaseGradeValue objValue = new clsCaseGradeValue();
			objValue.m_strInPatientID = m_objBaseCurrentPatient.m_StrInPatientID;
            objValue.m_strInPatientDate = trvTime.SelectedNode.Tag.ToString();
			long lngRes = m_objDomain.m_lngGetGradeInfo(ref objValue);
		
			if(lngRes <= 0 || objValue.m_objItemValueArr == null)
			{
				m_objCurrentRecord = null;
				return;
			}
			m_objCurrentRecord = objValue;
			m_mthSetGUIFromContent(m_tabMain,m_objCurrentRecord.m_objItemValueArr);

            m_mthSetText(m_txtMainResult, m_txtMainResult.Text, m_lblMainGrade);

            m_mthSetText(m_txtInPatResult, m_txtInPatResult.Text, m_lblInPatGeade);

            m_mthSetText(m_txtDiseaseResult, m_txtDiseaseResult.Text, m_lblDisGrade);

            m_mthSetText(m_txtOutResult, m_txtOutResult.Text, m_lblOutgrade);

            m_mthSetText(m_txtCheckResult, m_txtCheckResult.Text, m_lblCheckGrade);

            m_mthSetText(m_txtBaseResult, m_txtBaseResult.Text, m_lblBaseGrade);

            m_mthSetText(m_txtAgreeResult, m_txtAgreeResult.Text, m_lblAgreeGrade);

            m_cmdDisPlayResult_Click(null, null);
		}
		/// <summary>
		/// 赋值到界面
		/// </summary>
		/// <param name="p_objContent"></param>
		private void m_mthSetGUIFromContent(Control p_ctlSender,clsCaseGrade_ItemValue[] p_objContentArr)
		{
			if(p_objContentArr == null || p_ctlSender == null)
				return;
			if(p_objContentArr.Length <= 0)
				return;
			if(!p_ctlSender.HasChildren)
			{
				int intIndex = -1;
				for(int i=0;i<p_objContentArr.Length;i++)
				{
					if(p_objContentArr[i].m_strItemID == p_ctlSender.Name)
					{
						intIndex = i;
						break;
					}
				}
				if(intIndex != -1)
				{
					switch(p_ctlSender.GetType().Name)
					{
						case "TextBox":
							TextBox txtRTB = (TextBox)p_ctlSender;
							txtRTB.Text = p_objContentArr[intIndex].m_strItemContent;
							break;
						case "CheckBox":
							((CheckBox)p_ctlSender).Checked = bool.Parse(p_objContentArr[intIndex].m_strItemContent);
							break;
						default:
							break;
					}
				}
			}
			else
			{
				foreach(Control ctlSub in p_ctlSender.Controls)
					m_mthSetGUIFromContent(ctlSub,p_objContentArr);
			}
		}

		private void m_tabMain_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				MenuCommand mncWatchCase = new MenuCommand("查看病案");
				mncWatchCase.ImageList = imageList1;
				mncWatchCase.ImageIndex =1;
				MenuCommand mncMain = new MenuCommand("首页");
				mncMain.Tag = "iCare.frmInHospitalMainRecord";
				mncMain.Click += new System.EventHandler(mncShow_Click);
				MenuCommand mncInHospital = new MenuCommand("入院记录");
				mncInHospital.Tag = "iCare.frmInPatMedRecChoose";
				mncInHospital.Click += new System.EventHandler(mncShowDialog_Click);
				MenuCommand mncDis = new MenuCommand("病程记录");
				mncDis.Tag = "iCare.frmSubDiseaseTrack";
				mncDis.Click += new System.EventHandler(mncShow_Click);
				MenuCommand mncOutHospita = new MenuCommand("出院记录");
				mncOutHospita.Tag = "iCare.frmOutHospital";
				mncOutHospita.Click += new System.EventHandler(mncShow_Click);

				mncWatchCase.MenuCommands.AddRange(new MenuCommand[]{mncMain, mncInHospital, mncDis, mncOutHospita});

				MenuCommand mncCount = new MenuCommand("评分统计");
				mncCount.Tag = "iCare.frmGradeStatistic";
				mncCount.ImageList = imageList1;
				mncCount.ImageIndex =0;
				mncCount.Click += new System.EventHandler(mncShow_Click);
	

				PopupMenu popup = new PopupMenu();
				
				popup.MenuCommands.ExtraText = "iCare";
				popup.MenuCommands.ExtraTextColor = Color.Blue;
				popup.MenuCommands.ExtraBackColor = Color.Gray  ;
				popup.MenuCommands.ExtraFont = new Font("Times New Roman", 10.5f, FontStyle.Bold | FontStyle.Italic); 
				popup.MenuCommands.AddRange(new MenuCommand[]{mncWatchCase, mncCount});
				popup.TrackPopup(((Control)sender).PointToScreen(new Point(e.X, e.Y)));
			}
		}

		private void mncShow_Click(object sender, System.EventArgs e)
		{
			MenuCommand mnc = sender as MenuCommand;
			if(mnc == null)
				return;
			Type type = Type.GetType(mnc.Tag.ToString());
			Form frmMR = (Form)Activator.CreateInstance(type);
			frmMR.MdiParent = clsEMRLogin.s_FrmMDI;
			frmMR.WindowState = FormWindowState.Maximized;
			frmMR.Show();
		}
		private void mncShowDialog_Click(object sender, System.EventArgs e)
		{
			MenuCommand mnc = sender as MenuCommand;
			if(mnc == null)
				return;
			Type type = Type.GetType(mnc.Tag.ToString());
			Form frmMR = (Form)Activator.CreateInstance(type);
			frmMR.ShowDialog();
		}

		private void m_lklCalCheck_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			float fltRe = m_fltCalResult(pnlCheckGrade);
			m_txtCheckResult.Text = fltRe > 5F?"5":fltRe.ToString();
			m_lblCheckGrade.Text = pnlCheckGrade.Tag as string;
		}

		private void m_lklCalBase_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			float fltRe = m_fltCalResult(pnlBaseGrade);
			m_txtBaseResult.Text = fltRe > 5F?"5":fltRe.ToString();
			m_lblBaseGrade.Text = pnlBaseGrade.Tag as string;
		}

		private void m_lklCalAgree_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			float fltRe = m_fltCalResult(pnlAgreeGrade);
			m_txtAgreeResult.Text = fltRe > 10F?"10":fltRe.ToString();
			m_lblAgreeGrade.Text = pnlAgreeGrade.Tag as string;
		}

        private void m_cboDept_CGDropDown(object sender, System.EventArgs e)
        {
            if (objDeptArr != null)
            {
                m_cboDept.ClearItem();
                for (int i = 0; i < objDeptArr.Length; i++)
                {
                    if (objDeptArr[i].m_StrDeptName != "")
                        m_cboDept.AddItem(objDeptArr[i]);
                }
                m_cboArea.ClearItem();
                txtInPatientID.Text = "";
                m_txtPatientName.Text = "";
                lblSex.Text = "";
                lblAge.Text = "";
                m_txtBedNO.Text = "";
                //清空时间列表树的时间节点   
                if (trvTime.Nodes[0].Nodes.Count > 0)
                    trvTime.Nodes[0].Nodes.Clear();
                m_mthClearGUIInfo();
            }
        }

        private void m_cmdDelete_Click(object sender, System.EventArgs e)
        {
            if (!s_blnIsBas) return;

            long m_lngRe = m_lngDelete();
            if (m_lngRe > 0)
            {
                m_tipMain.Show("删除成功！", m_cmdDelete, 2000);
                if (this.trvTime.SelectedNode != null)
                {
                    this.trvTime_AfterSelect(this.trvTime, new TreeViewEventArgs(this.trvTime.SelectedNode));
                }
            }
        }

        private void m_cmdSave_Click(object sender, System.EventArgs e)
        {
            if (!s_blnIsBas) return;

            m_lklMainResult_LinkClicked(null, null);
            m_lklCalInPatResult_LinkClicked(null, null);
            m_lklCalDisease_LinkClicked(null, null);
            m_lklCalOutResult_LinkClicked(null, null);
            m_lklCalCheck_LinkClicked(null, null);
            m_lklCalBase_LinkClicked(null, null);
            m_lklCalAgree_LinkClicked(null, null);
            m_cmdDisPlayResult_Click(null, null);

            long m_lngRe = m_lngSave();
            if (m_lngRe > 0)
            {
                m_tipMain.Show("保存成功！", m_cmdSave,2000);
                if (this.trvTime.SelectedNode != null)
                {
                    this.trvTime_AfterSelect(this.trvTime, new TreeViewEventArgs(this.trvTime.SelectedNode));
                }

            }
        }

        private void m_mthSetText(TextBox p_txtBase, string p_strtext, Label p_lblBase)
        {
            if (p_strtext.IndexOf(";") >= 0)
            {
                string[] strArr = p_strtext.Split(';');
                if (strArr.Length == 2)
                {
                    p_txtBase.Text = strArr[0];
                    p_lblBase.Text = strArr[1];
                }
            }
            else
                p_txtBase.Text = p_strtext;
        }
	}
}
